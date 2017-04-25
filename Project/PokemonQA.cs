using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Text;

namespace Project
{
    public partial class PokemonQA : Form
    {
        List<Panel> listPanel = new List<Panel>();
        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont,
            IntPtr pdv, [System.Runtime.InteropServices.In] ref uint pcFonts);

        private PrivateFontCollection fonts = new PrivateFontCollection();

        Font pokemonFont, pokemonFontIntro;

        private static int wrongAnswers = 0;
        private static int correctAnswers = 0;
        Question question;
        Random rnd = new Random();
        int timeLeft;
        int randomPokemon, pickQuestion;
        int numberOfPokemon;
        string endScreenImage = "EndingScreen";
        

        public PokemonQA()
        {
            InitializeComponent();

            InitializeFont();

        }
        private void NewQuestion()
        {
            ClearButtons();
            randomPokemon = rnd.Next(1, 152);
            pickQuestion = rnd.Next(1, 3);
            if (pickQuestion == 1)
            {
                question = new NameQuestion(randomPokemon);
                SetButtonsName();
            }
            else
            {
                question = new TypeQuestion(randomPokemon);
                SetButtonsType();
            }

            SetButtonsTags();

            ChangeFontColor();
            string randomBackgroundString = question.GetPokemon().GetBackgroundName();
            QAPanel.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject(randomBackgroundString);
            
            string randomPokemonString = question.GetPokemon().GetCorrectName();

            string fileID = randomPokemon.ToString();

            PokemonPictureBox.Image = (Image)Properties.Resources.ResourceManager.GetObject(randomPokemonString);
            PokemonPictureBox.Refresh();
            QuestionLabel.Text = question.GetQuestion();


            timeLeft = 10;
            GameTimer.Start();
        }

        private void NewQuestionButton_Click(object sender, EventArgs e)
        {
            NewQuestion();
        }

        private void Answer1Button_Click(object sender, EventArgs e)
        {
            GameTimer.Stop();
            if (Answer1Button.Tag.ToString() == question.GetCorrectAnswer())
                CheckReward();
            else
                CheckEnding();
        }

        private void Answer2Button_Click(object sender, EventArgs e)
        {
            GameTimer.Stop();
            if (Answer2Button.Tag.ToString() == question.GetCorrectAnswer())
                CheckReward();
            else
                CheckEnding();
        }

        private void Answer3Button_Click(object sender, EventArgs e)
        {
            GameTimer.Stop();
            if (Answer3Button.Tag.ToString() == question.GetCorrectAnswer())
                CheckReward();
            else
                CheckEnding();
        }

        private void Answer4Button_Click(object sender, EventArgs e)
        {
            GameTimer.Stop();
            if (Answer4Button.Tag.ToString() == question.GetCorrectAnswer())
                CheckReward();
            else
                CheckEnding();
        }

        private void CheckReward()
        {
            correctAnswers++;
            if(correctAnswers >= numberOfPokemon)
            {
                endScreenImage += rnd.Next(1, 5);
                EndingPanel.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject(endScreenImage);
                listPanel[3].BringToFront();
                EndingLabel.Text = "You've caught enough Pokémon!";
            }
            else
                NewQuestion();
        }

        private void CheckEnding()
        {
            wrongAnswers++;
            if(wrongAnswers > 3)
            {
                endScreenImage += rnd.Next(1, 5);
                EndingPanel.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject(endScreenImage);
                listPanel[3].BringToFront();
                EndingLabel.Text = "You've lost too many Pokémon...";

            }
            else
            {
                LostPokemonLabel.Text = "You've lost " + wrongAnswers + " Pokémon";
                NewQuestion();
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (timeLeft > 0)
            {
                // Display the new time left
                // by updating the Time Left label.
                timeLeft = timeLeft - 1;
                TimerLabel.Text = timeLeft + " seconds";
            }
            else
            {
                // If the user ran out of time, stop the timer
                GameTimer.Stop();
                TimerLabel.Text = "Time's up!";
                CheckEnding();
            }
        }

        private void ClearButtons()
        {
            TimerLabel.ResetText();
            Answer1Button.ResetText();
            Answer1Button.Image = null;
            Answer2Button.ResetText();
            Answer2Button.Image = null;
            Answer3Button.ResetText();
            Answer3Button.Image = null;
            Answer4Button.ResetText();
            Answer4Button.Image = null;
        }

        private void SetButtonsTags()
        {
            Answer1Button.Tag = question.GetRandomAnswer1();
            Answer2Button.Tag = question.GetRandomAnswer2();
            Answer3Button.Tag = question.GetRandomAnswer3();
            Answer4Button.Tag = question.GetRandomAnswer4();
        }

        private void SetButtonsType()
        {
            Answer1Button.Image = (Image)Properties.Resources.ResourceManager.GetObject(question.GetRandomAnswer1());
            Answer2Button.Image = (Image)Properties.Resources.ResourceManager.GetObject(question.GetRandomAnswer2());
            Answer3Button.Image = (Image)Properties.Resources.ResourceManager.GetObject(question.GetRandomAnswer3());
            Answer4Button.Image = (Image)Properties.Resources.ResourceManager.GetObject(question.GetRandomAnswer4());
        }

        private void SetButtonsName()
        {
            Answer1Button.Text = question.GetRandomAnswer1();
            Answer2Button.Text = question.GetRandomAnswer2();
            Answer3Button.Text = question.GetRandomAnswer3();
            Answer4Button.Text = question.GetRandomAnswer4();
        }

        private void ChangeFontColor()
        {
            int backgroundNumber = question.GetPokemon().GetBackgroundNumber();
            switch (backgroundNumber)
            {
                case 1:case 8:
                    {
                        foreach (Control ctrl in QAPanel.Controls)
                        {
                            if (ctrl is Button)
                                ctrl.ForeColor = Color.Black;
                            if (ctrl is TextBox)
                                ctrl.ForeColor = Color.Black;
                            if (ctrl is Label)
                                ctrl.ForeColor = Color.Black;
                        }
                        break;
                    }
                case 2:case 3:case 4:case 5:case 6:
                    { 
                        foreach (Control ctrl in QAPanel.Controls)
                        {
                            if (ctrl is Button)
                                ctrl.ForeColor = Color.White;
                            if (ctrl is TextBox)
                                ctrl.ForeColor = Color.White;
                            if (ctrl is Label)
                                ctrl.ForeColor = Color.White;
                        }
                        break;
                    }
                case 7:
                    {
                        foreach (Control ctrl in QAPanel.Controls)
                        {
                            if (ctrl is Button)
                                ctrl.ForeColor = Color.Black;
                            if (ctrl is TextBox)
                                ctrl.ForeColor = Color.White;
                            if (ctrl is Label)
                                ctrl.ForeColor = Color.White;
                        }
                        break;
                    }
            }
        }

        private void PlayButton_Click(object sender, EventArgs e)
        {
            listPanel[1].BringToFront();
        }

        private void PokemonQA_Load(object sender, EventArgs e)
        {
            listPanel.Add(StartPanel);
            listPanel.Add(introPanel);
            listPanel.Add(QAPanel);
            listPanel.Add(EndingPanel);
            listPanel[0].BringToFront();
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            numberOfPokemon = (int)NumberOfPokemonComp.Value;
            listPanel[2].BringToFront();
            NewQuestion();
        }

        private void RestartButton_Click(object sender, EventArgs e)
        {
            ResetValues();
            listPanel[1].BringToFront();
        }

        private void EndButton_Click(object sender, EventArgs e)
        {
            Enabled = false;
            System.Threading.Thread.Sleep(1000);
            Application.Exit();
        }

        private void InitializeFont()
        {
            byte[] fontData = Properties.Resources.Pokemon_Hollow;
            IntPtr fontPtr = System.Runtime.InteropServices.Marshal.AllocCoTaskMem(fontData.Length);
            System.Runtime.InteropServices.Marshal.Copy(fontData, 0, fontPtr, fontData.Length);
            uint dummy = 0;
            fonts.AddMemoryFont(fontPtr, Properties.Resources.Pokemon_Hollow.Length);
            AddFontMemResourceEx(fontPtr, (uint)Properties.Resources.Pokemon_Hollow.Length, IntPtr.Zero, ref dummy);
            System.Runtime.InteropServices.Marshal.FreeCoTaskMem(fontPtr);

            pokemonFont = new Font(fonts.Families[0], 20.0F, FontStyle.Bold);
            pokemonFontIntro = new Font(fonts.Families[0], 12.0F, FontStyle.Bold);

            foreach (Control ctrl in StartPanel.Controls)
            {
                if (ctrl is Button)
                    ctrl.Font = pokemonFont;
                if (ctrl is TextBox)
                    ctrl.Font = pokemonFont;
                if (ctrl is Label)
                    ctrl.Font = pokemonFont;
            }

            foreach (Control ctrl in introPanel.Controls)
            {
                if (ctrl is Button)
                    ctrl.Font = pokemonFont;
                if (ctrl is RichTextBox)
                    ctrl.Font = pokemonFontIntro;
                if (ctrl is Label)
                    ctrl.Font = pokemonFontIntro;
                if (ctrl is NumericUpDown)
                    ctrl.Font = pokemonFontIntro;
            }

            foreach (Control ctrl in QAPanel.Controls)
            {
                if (ctrl is Button)
                    ctrl.Font = pokemonFont;
                if (ctrl is TextBox)
                    ctrl.Font = pokemonFont;
                if (ctrl is Label)
                    ctrl.Font = pokemonFont;
            }

            foreach (Control ctrl in EndingPanel.Controls)
            {
                if (ctrl is Button)
                    ctrl.Font = pokemonFont;
                if (ctrl is TextBox)
                    ctrl.Font = pokemonFont;
                if (ctrl is Label)
                    ctrl.Font = pokemonFont;
            }

        }

        private void ResetValues()
        {
            wrongAnswers = 0;
            correctAnswers = 0;
            endScreenImage = "EndingScreen";
            LostPokemonLabel.ResetText();
        }
    }
}
