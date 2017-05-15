﻿namespace Project
{
    partial class PokemonQA
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
            this.GameTimer = new System.Windows.Forms.Timer(this.components);
            this.QAPanel = new Project.PanelDoubleBuffered();
            this.QuestionLabel = new System.Windows.Forms.Label();
            this.PokemonPictureBox = new System.Windows.Forms.PictureBox();
            this.Answer4Button = new System.Windows.Forms.Button();
            this.NewQuestionButton = new System.Windows.Forms.Button();
            this.Answer2Button = new System.Windows.Forms.Button();
            this.Answer3Button = new System.Windows.Forms.Button();
            this.Answer1Button = new System.Windows.Forms.Button();
            this.LostPokemonLabel = new System.Windows.Forms.Label();
            this.TimerLabel = new System.Windows.Forms.Label();
            this.EndingPanel = new Project.PanelDoubleBuffered();
            this.EndButton = new System.Windows.Forms.Button();
            this.RestartButton = new System.Windows.Forms.Button();
            this.EndingLabel = new System.Windows.Forms.Label();
            this.IntroPanel = new Project.PanelDoubleBuffered();
            this.StartButton = new System.Windows.Forms.Button();
            this.NumberOfPokemonComp = new System.Windows.Forms.NumericUpDown();
            this.StartPanel = new Project.PanelDoubleBuffered();
            this.TitleLabel = new System.Windows.Forms.Label();
            this.PlayButton = new System.Windows.Forms.Button();
            this.QAPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PokemonPictureBox)).BeginInit();
            this.EndingPanel.SuspendLayout();
            this.IntroPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumberOfPokemonComp)).BeginInit();
            this.StartPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // GameTimer
            // 
            this.GameTimer.Interval = 1000;
            this.GameTimer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // QAPanel
            // 
            this.QAPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.QAPanel.BackColor = System.Drawing.Color.White;
            this.QAPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.QAPanel.Controls.Add(this.QuestionLabel);
            this.QAPanel.Controls.Add(this.PokemonPictureBox);
            this.QAPanel.Controls.Add(this.Answer4Button);
            this.QAPanel.Controls.Add(this.NewQuestionButton);
            this.QAPanel.Controls.Add(this.Answer2Button);
            this.QAPanel.Controls.Add(this.Answer3Button);
            this.QAPanel.Controls.Add(this.Answer1Button);
            this.QAPanel.Controls.Add(this.LostPokemonLabel);
            this.QAPanel.Controls.Add(this.TimerLabel);
            this.QAPanel.Location = new System.Drawing.Point(0, 0);
            this.QAPanel.Name = "QAPanel";
            this.QAPanel.Size = new System.Drawing.Size(825, 590);
            this.QAPanel.TabIndex = 10;
            // 
            // QuestionLabel
            // 
            this.QuestionLabel.BackColor = System.Drawing.Color.Transparent;
            this.QuestionLabel.Location = new System.Drawing.Point(17, 3);
            this.QuestionLabel.Name = "QuestionLabel";
            this.QuestionLabel.Size = new System.Drawing.Size(498, 90);
            this.QuestionLabel.TabIndex = 8;
            this.QuestionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PokemonPictureBox
            // 
            this.PokemonPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PokemonPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.PokemonPictureBox.Location = new System.Drawing.Point(499, 55);
            this.PokemonPictureBox.Name = "PokemonPictureBox";
            this.PokemonPictureBox.Size = new System.Drawing.Size(258, 246);
            this.PokemonPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PokemonPictureBox.TabIndex = 4;
            this.PokemonPictureBox.TabStop = false;
            // 
            // Answer4Button
            // 
            this.Answer4Button.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Answer4Button.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Answer4Button.BackColor = System.Drawing.Color.Transparent;
            this.Answer4Button.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.Answer4Button.FlatAppearance.BorderSize = 0;
            this.Answer4Button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.Answer4Button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.Answer4Button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Answer4Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Answer4Button.Location = new System.Drawing.Point(415, 348);
            this.Answer4Button.Name = "Answer4Button";
            this.Answer4Button.Size = new System.Drawing.Size(250, 90);
            this.Answer4Button.TabIndex = 3;
            this.Answer4Button.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Answer4Button.UseVisualStyleBackColor = false;
            this.Answer4Button.Click += new System.EventHandler(this.Answer4Button_Click);
            // 
            // NewQuestionButton
            // 
            this.NewQuestionButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.NewQuestionButton.BackColor = System.Drawing.Color.Transparent;
            this.NewQuestionButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.NewQuestionButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewQuestionButton.Location = new System.Drawing.Point(12, 252);
            this.NewQuestionButton.Name = "NewQuestionButton";
            this.NewQuestionButton.Size = new System.Drawing.Size(248, 90);
            this.NewQuestionButton.TabIndex = 6;
            this.NewQuestionButton.Text = "New Question";
            this.NewQuestionButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.NewQuestionButton.UseVisualStyleBackColor = false;
            this.NewQuestionButton.Click += new System.EventHandler(this.NewQuestionButton_Click);
            // 
            // Answer2Button
            // 
            this.Answer2Button.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Answer2Button.BackColor = System.Drawing.Color.Transparent;
            this.Answer2Button.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.Answer2Button.FlatAppearance.BorderSize = 0;
            this.Answer2Button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.Answer2Button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.Answer2Button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Answer2Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Answer2Button.Location = new System.Drawing.Point(415, 444);
            this.Answer2Button.Name = "Answer2Button";
            this.Answer2Button.Size = new System.Drawing.Size(250, 90);
            this.Answer2Button.TabIndex = 1;
            this.Answer2Button.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Answer2Button.UseVisualStyleBackColor = false;
            this.Answer2Button.Click += new System.EventHandler(this.Answer2Button_Click);
            // 
            // Answer3Button
            // 
            this.Answer3Button.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Answer3Button.BackColor = System.Drawing.Color.Transparent;
            this.Answer3Button.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.Answer3Button.FlatAppearance.BorderSize = 0;
            this.Answer3Button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.Answer3Button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.Answer3Button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Answer3Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Answer3Button.Location = new System.Drawing.Point(159, 444);
            this.Answer3Button.Name = "Answer3Button";
            this.Answer3Button.Size = new System.Drawing.Size(250, 90);
            this.Answer3Button.TabIndex = 2;
            this.Answer3Button.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Answer3Button.UseVisualStyleBackColor = false;
            this.Answer3Button.Click += new System.EventHandler(this.Answer3Button_Click);
            // 
            // Answer1Button
            // 
            this.Answer1Button.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Answer1Button.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Answer1Button.BackColor = System.Drawing.Color.Transparent;
            this.Answer1Button.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.Answer1Button.FlatAppearance.BorderSize = 0;
            this.Answer1Button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.Answer1Button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.Answer1Button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Answer1Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Answer1Button.Location = new System.Drawing.Point(159, 348);
            this.Answer1Button.Name = "Answer1Button";
            this.Answer1Button.Size = new System.Drawing.Size(250, 90);
            this.Answer1Button.TabIndex = 0;
            this.Answer1Button.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Answer1Button.UseVisualStyleBackColor = false;
            this.Answer1Button.Click += new System.EventHandler(this.Answer1Button_Click);
            // 
            // LostPokemonLabel
            // 
            this.LostPokemonLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.LostPokemonLabel.BackColor = System.Drawing.Color.Transparent;
            this.LostPokemonLabel.Location = new System.Drawing.Point(20, 81);
            this.LostPokemonLabel.Name = "LostPokemonLabel";
            this.LostPokemonLabel.Size = new System.Drawing.Size(415, 84);
            this.LostPokemonLabel.TabIndex = 9;
            // 
            // TimerLabel
            // 
            this.TimerLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.TimerLabel.BackColor = System.Drawing.Color.Transparent;
            this.TimerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TimerLabel.Location = new System.Drawing.Point(12, 174);
            this.TimerLabel.Name = "TimerLabel";
            this.TimerLabel.Size = new System.Drawing.Size(248, 75);
            this.TimerLabel.TabIndex = 7;
            this.TimerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // EndingPanel
            // 
            this.EndingPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EndingPanel.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.EndingPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.EndingPanel.Controls.Add(this.EndButton);
            this.EndingPanel.Controls.Add(this.RestartButton);
            this.EndingPanel.Controls.Add(this.EndingLabel);
            this.EndingPanel.Location = new System.Drawing.Point(0, 0);
            this.EndingPanel.Name = "EndingPanel";
            this.EndingPanel.Size = new System.Drawing.Size(826, 589);
            this.EndingPanel.TabIndex = 11;
            // 
            // EndButton
            // 
            this.EndButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.EndButton.BackColor = System.Drawing.Color.Transparent;
            this.EndButton.FlatAppearance.BorderSize = 0;
            this.EndButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.EndButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.EndButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EndButton.ForeColor = System.Drawing.Color.Red;
            this.EndButton.Location = new System.Drawing.Point(530, 495);
            this.EndButton.Name = "EndButton";
            this.EndButton.Size = new System.Drawing.Size(189, 82);
            this.EndButton.TabIndex = 1;
            this.EndButton.Text = "End";
            this.EndButton.UseVisualStyleBackColor = false;
            this.EndButton.Click += new System.EventHandler(this.EndButton_Click);
            // 
            // RestartButton
            // 
            this.RestartButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.RestartButton.BackColor = System.Drawing.Color.Transparent;
            this.RestartButton.FlatAppearance.BorderSize = 0;
            this.RestartButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.RestartButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.RestartButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RestartButton.ForeColor = System.Drawing.Color.Red;
            this.RestartButton.Location = new System.Drawing.Point(80, 495);
            this.RestartButton.Name = "RestartButton";
            this.RestartButton.Size = new System.Drawing.Size(189, 82);
            this.RestartButton.TabIndex = 1;
            this.RestartButton.Text = "Restart";
            this.RestartButton.UseVisualStyleBackColor = false;
            this.RestartButton.Click += new System.EventHandler(this.RestartButton_Click);
            // 
            // EndingLabel
            // 
            this.EndingLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.EndingLabel.AutoSize = true;
            this.EndingLabel.BackColor = System.Drawing.Color.Transparent;
            this.EndingLabel.ForeColor = System.Drawing.Color.Red;
            this.EndingLabel.Location = new System.Drawing.Point(332, 68);
            this.EndingLabel.Name = "EndingLabel";
            this.EndingLabel.Size = new System.Drawing.Size(66, 13);
            this.EndingLabel.TabIndex = 0;
            this.EndingLabel.Text = "EndingLabel";
            // 
            // IntroPanel
            // 
            this.IntroPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.IntroPanel.BackColor = System.Drawing.Color.Transparent;
            this.IntroPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.IntroPanel.Controls.Add(this.StartButton);
            this.IntroPanel.Controls.Add(this.NumberOfPokemonComp);
            this.IntroPanel.Location = new System.Drawing.Point(0, 0);
            this.IntroPanel.Name = "IntroPanel";
            this.IntroPanel.Size = new System.Drawing.Size(826, 590);
            this.IntroPanel.TabIndex = 2;
            // 
            // StartButton
            // 
            this.StartButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.StartButton.BackColor = System.Drawing.Color.Transparent;
            this.StartButton.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.StartButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StartButton.Location = new System.Drawing.Point(612, 433);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(178, 101);
            this.StartButton.TabIndex = 3;
            this.StartButton.Text = "Start";
            this.StartButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.StartButton.UseVisualStyleBackColor = false;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // NumberOfPokemonComp
            // 
            this.NumberOfPokemonComp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.NumberOfPokemonComp.BackColor = System.Drawing.Color.Gainsboro;
            this.NumberOfPokemonComp.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.NumberOfPokemonComp.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumberOfPokemonComp.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.NumberOfPokemonComp.Location = new System.Drawing.Point(707, 348);
            this.NumberOfPokemonComp.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.NumberOfPokemonComp.Name = "NumberOfPokemonComp";
            this.NumberOfPokemonComp.Size = new System.Drawing.Size(69, 27);
            this.NumberOfPokemonComp.TabIndex = 2;
            this.NumberOfPokemonComp.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // StartPanel
            // 
            this.StartPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.StartPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.StartPanel.BackColor = System.Drawing.Color.Transparent;
            this.StartPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.StartPanel.Controls.Add(this.TitleLabel);
            this.StartPanel.Controls.Add(this.PlayButton);
            this.StartPanel.Location = new System.Drawing.Point(0, 0);
            this.StartPanel.Name = "StartPanel";
            this.StartPanel.Size = new System.Drawing.Size(826, 590);
            this.StartPanel.TabIndex = 10;
            // 
            // TitleLabel
            // 
            this.TitleLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.TitleLabel.BackColor = System.Drawing.Color.Transparent;
            this.TitleLabel.ForeColor = System.Drawing.Color.Red;
            this.TitleLabel.Location = new System.Drawing.Point(298, 55);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(231, 76);
            this.TitleLabel.TabIndex = 1;
            this.TitleLabel.Text = "Pokémon";
            this.TitleLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // PlayButton
            // 
            this.PlayButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.PlayButton.BackColor = System.Drawing.Color.Transparent;
            this.PlayButton.FlatAppearance.BorderSize = 0;
            this.PlayButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.PlayButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.PlayButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PlayButton.ForeColor = System.Drawing.Color.Red;
            this.PlayButton.Location = new System.Drawing.Point(351, 444);
            this.PlayButton.Name = "PlayButton";
            this.PlayButton.Size = new System.Drawing.Size(124, 90);
            this.PlayButton.TabIndex = 0;
            this.PlayButton.Text = "Play";
            this.PlayButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.PlayButton.UseVisualStyleBackColor = false;
            this.PlayButton.Click += new System.EventHandler(this.PlayButton_Click);
            // 
            // PokemonQA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(826, 589);
            this.Controls.Add(this.StartPanel);
            this.Controls.Add(this.QAPanel);
            this.Controls.Add(this.EndingPanel);
            this.Controls.Add(this.IntroPanel);
            this.DoubleBuffered = true;
            this.Name = "PokemonQA";
            this.RightToLeftLayout = true;
            this.Text = "Pokemon";
            this.Load += new System.EventHandler(this.PokemonQA_Load);
            this.QAPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PokemonPictureBox)).EndInit();
            this.EndingPanel.ResumeLayout(false);
            this.EndingPanel.PerformLayout();
            this.IntroPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.NumberOfPokemonComp)).EndInit();
            this.StartPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Answer1Button;
        private System.Windows.Forms.Button Answer2Button;
        private System.Windows.Forms.Button Answer3Button;
        private System.Windows.Forms.Button Answer4Button;
        private System.Windows.Forms.PictureBox PokemonPictureBox;
        private System.Windows.Forms.Timer GameTimer;
        private System.Windows.Forms.Label TimerLabel;
        private System.Windows.Forms.Label QuestionLabel;
        private System.Windows.Forms.Button NewQuestionButton;
        private System.Windows.Forms.Label LostPokemonLabel;
        private PanelDoubleBuffered StartPanel;
        private System.Windows.Forms.Button PlayButton;
        private PanelDoubleBuffered QAPanel;
        private System.Windows.Forms.Label TitleLabel;
        private PanelDoubleBuffered IntroPanel;
        private PanelDoubleBuffered EndingPanel;
        private System.Windows.Forms.Label EndingLabel;
        private System.Windows.Forms.NumericUpDown NumberOfPokemonComp;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Button EndButton;
        private System.Windows.Forms.Button RestartButton;
    }
}

