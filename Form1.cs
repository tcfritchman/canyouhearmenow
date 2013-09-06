using System;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.ObjectModel;
using NAudio.Wave;
using NAudio.CoreAudioApi;

namespace canyouhearmenow
{
    public partial class Form1 : Form
    {
        // recording
        private IWaveIn waveIn;
        private WaveFileWriter writer;
        private string outputFilename;
        private readonly string outputFolder;

        // playback
        private IWavePlayer wavePlayer;
        private AudioFileReader file;
        private string fileName;

        public Form1()
        {
            InitializeComponent();
            outputFolder = Path.Combine(Path.GetTempPath(), "NAudioDemo");
            Directory.CreateDirectory(outputFolder);
            this.timer1.Interval = 250;
            this.timer1.Tick += new EventHandler(timer1_Tick);
        }

        private static string FormatTimeSpan(TimeSpan ts)
        {
            return string.Format("{0:D2}:{1:D2}", (int)ts.TotalMinutes, ts.Seconds);
        }

        void timer1_Tick(object sender, EventArgs e)
        {
            if (file != null)
            {
                labelCurrentTime.Text = FormatTimeSpan(file.CurrentTime);
            }
        }

        void SimplePlaybackPanel_Disposed(object sender, EventArgs e)
        {
            CleanUp();
        }

        



        private void recordButton_Click(object sender, EventArgs e)
        {
            if (waveIn == null)
            {
                outputFilename = String.Format("NAudioDemo {0:yyy-MM-dd HH-mm-ss}.wav", DateTime.Now);
                waveIn = new WaveIn();
                waveIn.WaveFormat = new WaveFormat(44100, 1);
                writer = new WaveFileWriter(Path.Combine(outputFolder, outputFilename), waveIn.WaveFormat);

                waveIn.DataAvailable += OnDataAvailable;
                waveIn.RecordingStopped += OnRecordingStopped;
                waveIn.StartRecording();
                recordButton.Enabled = false;
            }
        }

        private void BeginPlayback(string filename)
        {
            Debug.Assert(this.wavePlayer == null);
            this.wavePlayer = CreateWavePlayer();
            this.file = new AudioFileReader(Path.Combine(outputFolder, filename));
            this.file.Volume = 1.0F;
            Debug.Print(Path.Combine(outputFolder, filename));
            this.wavePlayer.Init(file);
            this.wavePlayer.PlaybackStopped += wavePlayer_PlaybackStopped;
            this.wavePlayer.Play();
            timer1.Enabled = true; // for updating current time
        }

        private IWavePlayer CreateWavePlayer()
        {
            // WaveOut window callbacks
            return new WaveOutEvent();
        }

        void wavePlayer_PlaybackStopped(object sender, StoppedEventArgs e)
        {
            // we want to be always on the GUI thread and be able to change GUI components
            Debug.Assert(!this.InvokeRequired, "PlaybackStopped on wrong thread");
            // we want it to be safe to clean up input stream and playback device in the handler for PlaybackStopped
            CleanUp();
            //EnableButtons(false);
            timer1.Enabled = false;
            labelCurrentTime.Text = "00:00";
            if (e.Exception != null)
            {
                MessageBox.Show(String.Format("Playback Stopped due to an error {0}", e.Exception.Message));
            }
        }

        void OnRecordingStopped(object sender, StoppedEventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new EventHandler<StoppedEventArgs>(OnRecordingStopped), sender, e);
            }
            else
            {
                Cleanup();
                recordButton.Enabled = true;
                if (e.Exception != null)
                {
                    MessageBox.Show(String.Format("A problem was encountered during recording {0}",
                                                  e.Exception.Message));
                }
            }
        }

        private void Cleanup()
        {
            if (waveIn != null) // working around problem with double raising of RecordingStopped
            {
                waveIn.Dispose();
                waveIn = null;
            }
            if (writer != null)
            {
                writer.Close();
                writer = null;
            }
        }

        private void CleanUp()
        {
            if (this.file != null)
            {
                this.file.Dispose();
                this.file = null;
            }
            if (this.wavePlayer != null)
            {
                this.wavePlayer.Dispose();
                this.wavePlayer = null;
            }
        }


        void OnDataAvailable(object sender, WaveInEventArgs e)
        {
            if (this.InvokeRequired)
            {
                //Debug.WriteLine("Data Available");
                this.BeginInvoke(new EventHandler<WaveInEventArgs>(OnDataAvailable), sender, e);
            }
            else
            {
                //Debug.WriteLine("Flushing Data Available");
                writer.Write(e.Buffer, 0, e.BytesRecorded);
                int secondsRecorded = (int)(writer.Length / writer.WaveFormat.AverageBytesPerSecond);
            
            }
        }

        void StopRecording()
        {
            Debug.WriteLine("StopRecording");
            waveIn.StopRecording();
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            if (waveIn != null)
            {
                StopRecording();
            }
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            if (fileName == null) fileName = outputFilename;
            if (fileName != null)
            {
                BeginPlayback(fileName);
            }
        }

    }
}
