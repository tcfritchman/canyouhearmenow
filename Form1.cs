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

        private string outputFolder = Path.Combine(Path.GetTempPath(), "canyouhearmenow");
        private string outputFilename;
        private string outputFilePath;
        // TODO: Come up with better means for checking if device exists
        static int deviceNumber = -1;
        static int sampleRate = 44100;
        static int inChannels = NAudio.Wave.WaveIn.GetCapabilities(deviceNumber).Channels;

        string state = "stop";

        public int sampleLocation = 0;
        
        

        public Form1()
        {
            InitializeComponent();
            outputFolder = Path.Combine(Path.GetTempPath(), "NAudioDemo");
            Directory.CreateDirectory(outputFolder);
        }

        NAudio.Wave.WaveIn sourceStream = null;
        NAudio.Wave.DirectSoundOut waveOut = null;
        NAudio.Wave.WaveFileWriter waveWriter = null;
        NAudio.Wave.WaveFileReader waveReader = null;
        NAudio.Wave.DirectSoundOut output = null;

        // Returns a list of device capabilities
        private List<NAudio.Wave.WaveInCapabilities> getDevices()
        {
            List<NAudio.Wave.WaveInCapabilities> sources = new List<NAudio.Wave.WaveInCapabilities>();

            for (int i = -1; i < NAudio.Wave.WaveIn.DeviceCount; i++)
            {
                sources.Add(NAudio.Wave.WaveIn.GetCapabilities(i));
            }
            return sources;
        }

        private void recordButton_Click(object sender, EventArgs e)
        {
            state = "record";
            recordButton.Enabled = false;
            outputFilename = String.Format("Clip {0:yyy-MM-dd HH-mm-ss}.wav", DateTime.Now);
            outputFilePath = Path.Combine(outputFolder, outputFilename);
            Debug.Print(outputFilePath);
            sourceStream = new NAudio.Wave.WaveIn();
            sourceStream.DeviceNumber = deviceNumber;
            sourceStream.WaveFormat = new NAudio.Wave.WaveFormat(sampleRate, inChannels);

            sourceStream.DataAvailable += new EventHandler<NAudio.Wave.WaveInEventArgs>(sourceStream_DataAvailable);
            waveWriter = new NAudio.Wave.WaveFileWriter(outputFilePath, sourceStream.WaveFormat);

            sourceStream.StartRecording();
        }

        private void sourceStream_DataAvailable(object sender, NAudio.Wave.WaveInEventArgs e)
        {
            if (waveWriter == null) return;

            waveWriter.Write(e.Buffer, 0, e.BytesRecorded);
            sampleLocation += e.BytesRecorded / 4;
            labelCurrentTime.Text = ((double)sampleLocation / (double)sampleRate).ToString();
            waveWriter.Flush();
        }
        private void stopButton_Click(object sender, EventArgs e)
        {
            state = "stop";
            playButton.Enabled = true;
            recordButton.Enabled = true;
            if (waveOut != null)
            {
                waveOut.Stop();
                waveOut.Dispose();
                waveOut = null;
            }
            if (sourceStream != null)
            {
                sourceStream.StopRecording();
                sourceStream.Dispose();
                sourceStream = null;
            }
            if (waveWriter != null)
            {
                waveWriter.Dispose();
                waveWriter = null;
            }
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            waveReader = new NAudio.Wave.WaveFileReader(outputFilePath);
            output = new NAudio.Wave.DirectSoundOut(100);
            output.Init(new NAudio.Wave.WaveChannel32(waveReader));
            output.Play();
            playButton.Enabled = false;
            
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (waveOut != null)
            {
                waveOut.Stop();
                waveOut.Dispose();
                waveOut = null;
            }
            if (sourceStream != null)
            {
                sourceStream.StopRecording();
                sourceStream.Dispose();
                sourceStream = null;
            }
            if (waveWriter != null)
            {
                waveWriter.Dispose();
                waveWriter = null;
            }
        }

    }
}
