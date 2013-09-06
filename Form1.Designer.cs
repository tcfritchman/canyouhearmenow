namespace canyouhearmenow
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.playButton = new System.Windows.Forms.Button();
            this.recordButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.RewindButton = new System.Windows.Forms.Button();
            this.fastForwardButton = new System.Windows.Forms.Button();
            this.startButton = new System.Windows.Forms.Button();
            this.endButton = new System.Windows.Forms.Button();
            this.labelCurrentTime = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // playButton
            // 
            this.playButton.Location = new System.Drawing.Point(520, 89);
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(75, 23);
            this.playButton.TabIndex = 0;
            this.playButton.Text = "Play";
            this.playButton.UseVisualStyleBackColor = true;
            this.playButton.Click += new System.EventHandler(this.playButton_Click);
            // 
            // recordButton
            // 
            this.recordButton.Location = new System.Drawing.Point(520, 147);
            this.recordButton.Name = "recordButton";
            this.recordButton.Size = new System.Drawing.Size(75, 23);
            this.recordButton.TabIndex = 1;
            this.recordButton.Text = "Record";
            this.recordButton.UseVisualStyleBackColor = true;
            this.recordButton.Click += new System.EventHandler(this.recordButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.Location = new System.Drawing.Point(520, 118);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(75, 23);
            this.stopButton.TabIndex = 2;
            this.stopButton.Text = "Stop";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // RewindButton
            // 
            this.RewindButton.Location = new System.Drawing.Point(520, 176);
            this.RewindButton.Name = "RewindButton";
            this.RewindButton.Size = new System.Drawing.Size(75, 23);
            this.RewindButton.TabIndex = 3;
            this.RewindButton.Text = "Rew";
            this.RewindButton.UseVisualStyleBackColor = true;
            // 
            // fastForwardButton
            // 
            this.fastForwardButton.Location = new System.Drawing.Point(520, 205);
            this.fastForwardButton.Name = "fastForwardButton";
            this.fastForwardButton.Size = new System.Drawing.Size(75, 23);
            this.fastForwardButton.TabIndex = 4;
            this.fastForwardButton.Text = "FF";
            this.fastForwardButton.UseVisualStyleBackColor = true;
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(520, 234);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(75, 23);
            this.startButton.TabIndex = 5;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            // 
            // endButton
            // 
            this.endButton.Location = new System.Drawing.Point(520, 263);
            this.endButton.Name = "endButton";
            this.endButton.Size = new System.Drawing.Size(75, 23);
            this.endButton.TabIndex = 6;
            this.endButton.Text = "End";
            this.endButton.UseVisualStyleBackColor = true;
            // 
            // labelCurrentTime
            // 
            this.labelCurrentTime.AutoSize = true;
            this.labelCurrentTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCurrentTime.Location = new System.Drawing.Point(514, 43);
            this.labelCurrentTime.Name = "labelCurrentTime";
            this.labelCurrentTime.Size = new System.Drawing.Size(65, 31);
            this.labelCurrentTime.TabIndex = 7;
            this.labelCurrentTime.Text = "time";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(640, 376);
            this.Controls.Add(this.labelCurrentTime);
            this.Controls.Add(this.endButton);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.fastForwardButton);
            this.Controls.Add(this.RewindButton);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.recordButton);
            this.Controls.Add(this.playButton);
            this.Name = "Form1";
            this.Text = "canyouhearmenow?";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button playButton;
        private System.Windows.Forms.Button recordButton;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.Button RewindButton;
        private System.Windows.Forms.Button fastForwardButton;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button endButton;
        private System.Windows.Forms.Label labelCurrentTime;
        private System.Windows.Forms.Timer timer1;
    }
}

