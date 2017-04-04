namespace Project
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
            this.answer1Button = new System.Windows.Forms.Button();
            this.answer2Button = new System.Windows.Forms.Button();
            this.answer3Button = new System.Windows.Forms.Button();
            this.answer4Button = new System.Windows.Forms.Button();
            this.newQuestionButton = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.timerLabel = new System.Windows.Forms.Label();
            this.pokemonPictureBox = new System.Windows.Forms.PictureBox();
            this.questionLabel = new System.Windows.Forms.Label();
            this.lostPokemonLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pokemonPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // answer1Button
            // 
            this.answer1Button.BackColor = System.Drawing.Color.Transparent;
            this.answer1Button.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.answer1Button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.answer1Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.answer1Button.Location = new System.Drawing.Point(152, 387);
            this.answer1Button.Name = "answer1Button";
            this.answer1Button.Size = new System.Drawing.Size(250, 90);
            this.answer1Button.TabIndex = 0;
            this.answer1Button.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.answer1Button.UseVisualStyleBackColor = false;
            this.answer1Button.Click += new System.EventHandler(this.answer1Button_Click);
            // 
            // answer2Button
            // 
            this.answer2Button.BackColor = System.Drawing.Color.Transparent;
            this.answer2Button.FlatAppearance.BorderSize = 0;
            this.answer2Button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.answer2Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.answer2Button.Location = new System.Drawing.Point(406, 387);
            this.answer2Button.Name = "answer2Button";
            this.answer2Button.Size = new System.Drawing.Size(250, 90);
            this.answer2Button.TabIndex = 1;
            this.answer2Button.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.answer2Button.UseVisualStyleBackColor = false;
            this.answer2Button.Click += new System.EventHandler(this.answer2Button_Click);
            // 
            // answer3Button
            // 
            this.answer3Button.BackColor = System.Drawing.Color.Transparent;
            this.answer3Button.FlatAppearance.BorderSize = 0;
            this.answer3Button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.answer3Button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.answer3Button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.answer3Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.answer3Button.Location = new System.Drawing.Point(152, 483);
            this.answer3Button.Name = "answer3Button";
            this.answer3Button.Size = new System.Drawing.Size(250, 90);
            this.answer3Button.TabIndex = 2;
            this.answer3Button.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.answer3Button.UseVisualStyleBackColor = false;
            this.answer3Button.Click += new System.EventHandler(this.answer3Button_Click);
            // 
            // answer4Button
            // 
            this.answer4Button.BackColor = System.Drawing.Color.Transparent;
            this.answer4Button.FlatAppearance.BorderSize = 0;
            this.answer4Button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.answer4Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.answer4Button.Location = new System.Drawing.Point(406, 483);
            this.answer4Button.Name = "answer4Button";
            this.answer4Button.Size = new System.Drawing.Size(250, 90);
            this.answer4Button.TabIndex = 3;
            this.answer4Button.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.answer4Button.UseVisualStyleBackColor = false;
            this.answer4Button.Click += new System.EventHandler(this.answer4Button_Click);
            // 
            // newQuestionButton
            // 
            this.newQuestionButton.BackColor = System.Drawing.Color.Transparent;
            this.newQuestionButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.newQuestionButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newQuestionButton.Location = new System.Drawing.Point(12, 268);
            this.newQuestionButton.Name = "newQuestionButton";
            this.newQuestionButton.Size = new System.Drawing.Size(248, 90);
            this.newQuestionButton.TabIndex = 6;
            this.newQuestionButton.Text = "New Question";
            this.newQuestionButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.newQuestionButton.UseVisualStyleBackColor = false;
            this.newQuestionButton.Click += new System.EventHandler(this.newQuestionButton_Click);
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // timerLabel
            // 
            this.timerLabel.BackColor = System.Drawing.Color.Transparent;
            this.timerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timerLabel.Location = new System.Drawing.Point(12, 190);
            this.timerLabel.Name = "timerLabel";
            this.timerLabel.Size = new System.Drawing.Size(248, 75);
            this.timerLabel.TabIndex = 7;
            this.timerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pokemonPictureBox
            // 
            this.pokemonPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.pokemonPictureBox.Location = new System.Drawing.Point(513, 12);
            this.pokemonPictureBox.Name = "pokemonPictureBox";
            this.pokemonPictureBox.Size = new System.Drawing.Size(301, 308);
            this.pokemonPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pokemonPictureBox.TabIndex = 4;
            this.pokemonPictureBox.TabStop = false;
            // 
            // questionLabel
            // 
            this.questionLabel.BackColor = System.Drawing.Color.Transparent;
            this.questionLabel.Location = new System.Drawing.Point(9, 12);
            this.questionLabel.Name = "questionLabel";
            this.questionLabel.Size = new System.Drawing.Size(498, 90);
            this.questionLabel.TabIndex = 8;
            this.questionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lostPokemonLabel
            // 
            this.lostPokemonLabel.BackColor = System.Drawing.Color.Transparent;
            this.lostPokemonLabel.Location = new System.Drawing.Point(12, 107);
            this.lostPokemonLabel.Name = "lostPokemonLabel";
            this.lostPokemonLabel.Size = new System.Drawing.Size(495, 90);
            this.lostPokemonLabel.TabIndex = 9;
            // 
            // PokemonQA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(826, 589);
            this.Controls.Add(this.lostPokemonLabel);
            this.Controls.Add(this.questionLabel);
            this.Controls.Add(this.timerLabel);
            this.Controls.Add(this.newQuestionButton);
            this.Controls.Add(this.pokemonPictureBox);
            this.Controls.Add(this.answer4Button);
            this.Controls.Add(this.answer3Button);
            this.Controls.Add(this.answer2Button);
            this.Controls.Add(this.answer1Button);
            this.DoubleBuffered = true;
            this.Name = "PokemonQA";
            this.RightToLeftLayout = true;
            this.Text = "Pokemon";
            ((System.ComponentModel.ISupportInitialize)(this.pokemonPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button answer1Button;
        private System.Windows.Forms.Button answer2Button;
        private System.Windows.Forms.Button answer3Button;
        private System.Windows.Forms.Button answer4Button;
        private System.Windows.Forms.PictureBox pokemonPictureBox;
        private System.Windows.Forms.Button newQuestionButton;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label timerLabel;
        private System.Windows.Forms.Label questionLabel;
        private System.Windows.Forms.Label lostPokemonLabel;
    }
}

