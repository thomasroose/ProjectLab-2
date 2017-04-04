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
        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont,
            IntPtr pdv, [System.Runtime.InteropServices.In] ref uint pcFonts);

        private PrivateFontCollection fonts = new PrivateFontCollection();

        Font pokemonFont;

        private static int wrongAnswers = 0;
        Question question;
        Random rnd = new Random();
        int timeLeft;
        int randomPokemon, pickQuestion;

        public PokemonQA()
        {
            InitializeComponent();

            InitializeFont();

            newQuestion();

        }
        private void newQuestion()
        {
            clearButtons();
            randomPokemon = rnd.Next(1, 152);
            pickQuestion = rnd.Next(1, 3);
            if (pickQuestion == 1)
            {
                question = new NameQuestion(randomPokemon);
                setButtonsName();
            }
            else
            {
                question = new TypeQuestion(randomPokemon);
                setButtonsType();
            }

            setButtonsTags();

            ChangeFontColor();
            string randomBackgroundString = question.GetPokemon().GetBackgroundName();
            BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject(randomBackgroundString);
            
            string randomPokemonString = question.GetPokemon().GetCorrectName();

            string fileID = randomPokemon.ToString();

            pokemonPictureBox.Image = (Image)Properties.Resources.ResourceManager.GetObject(randomPokemonString);
            pokemonPictureBox.Refresh();
            questionLabel.Text = question.GetQuestion();


            timeLeft = 30;
            timer.Start();
        }

        private void newQuestionButton_Click(object sender, EventArgs e)
        {
            newQuestion();
        }
        private void answer1Button_Click(object sender, EventArgs e)
        {
            if (answer1Button.Tag.ToString() == question.GetCorrectAnswer())
            {
                newQuestion();
            }
            else
            {
                checkEnding();
            }
        }


        private void answer2Button_Click(object sender, EventArgs e)
        {
            if (answer2Button.Tag.ToString() == question.GetCorrectAnswer())
            {
                newQuestion();
            }
            else
            {
                checkEnding();
            }
        }

        private void answer3Button_Click(object sender, EventArgs e)
        {
            if (answer3Button.Tag.ToString() == question.GetCorrectAnswer())
            {
                newQuestion();
            }
            else
            {
                checkEnding();
            }
        }

        private void answer4Button_Click(object sender, EventArgs e)
        {
            if (answer4Button.Tag.ToString() == question.GetCorrectAnswer())
            {
                newQuestion();
            }
            else
            {
                checkEnding();
            }
        }

        private void checkEnding()
        {
            wrongAnswers++;
            if(wrongAnswers > 4)
            {
                lostPokemonLabel.Text = "You've lost too many Pokémon";
                questionLabel.Text = "Application closing...";
                Enabled = false;
                System.Threading.Thread.Sleep(5000);
                Application.Exit();
            }
            else
            {
                lostPokemonLabel.Text = "You've lost " + wrongAnswers + " Pokémon";
                newQuestion();
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (timeLeft > 0)
            {
                // Display the new time left
                // by updating the Time Left label.
                timeLeft = timeLeft - 1;
                timerLabel.Text = timeLeft + " seconds";
            }
            else
            {
                // If the user ran out of time, stop the timer
                timer.Stop();
                timerLabel.Text = "Time's up!";
            }
        }

        private void clearButtons()
        {
            answer1Button.ResetText();
            answer1Button.Image = null;
            answer2Button.ResetText();
            answer2Button.Image = null;
            answer3Button.ResetText();
            answer3Button.Image = null;
            answer4Button.ResetText();
            answer4Button.Image = null;
        }

        private void setButtonsTags()
        {
            answer1Button.Tag = question.GetRandomAnswer1();
            answer2Button.Tag = question.GetRandomAnswer2();
            answer3Button.Tag = question.GetRandomAnswer3();
            answer4Button.Tag = question.GetRandomAnswer4();
        }

        private void setButtonsType()
        {
            answer1Button.Image = (Image)Properties.Resources.ResourceManager.GetObject(question.GetRandomAnswer1());
            answer2Button.Image = (Image)Properties.Resources.ResourceManager.GetObject(question.GetRandomAnswer2());
            answer3Button.Image = (Image)Properties.Resources.ResourceManager.GetObject(question.GetRandomAnswer3());
            answer4Button.Image = (Image)Properties.Resources.ResourceManager.GetObject(question.GetRandomAnswer4());
        }

        private void setButtonsName()
        {
            answer1Button.Text = question.GetRandomAnswer1();
            answer2Button.Text = question.GetRandomAnswer2();
            answer3Button.Text = question.GetRandomAnswer3();
            answer4Button.Text = question.GetRandomAnswer4();
        }

        private void ChangeFontColor()
        {
            int backgroundNumber = question.GetPokemon().GetBackgroundNumber();
            switch (backgroundNumber)
            {
                case 1:case 7:case 8:
                    {
                        foreach (Control ctrl in Controls)
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
                        foreach (Control ctrl in Controls)
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

                    
            }
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

            foreach (Control ctrl in Controls)
            {
                if (ctrl is Button)
                    ctrl.Font = pokemonFont;
                if (ctrl is TextBox)
                    ctrl.Font = pokemonFont;
                if (ctrl is Label)
                    ctrl.Font = pokemonFont;
            }
        }
    }
}
