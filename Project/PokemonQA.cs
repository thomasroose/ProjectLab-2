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
        const int gameTimerStartValue = 10;
        const int searchTimerStartValue = 30;

        Question question;
        Random rnd = new Random();
        int timeLeft, searchTimeLeft;
        int randomPokemon, pickQuestion;
        int numberToWin;
        string endScreenImage = "EndingScreen";
        

        public PokemonQA()
        {
            InitializeComponent();
            //Initialize custom Pokémon font
            InitializeFont();

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

            //Changing font of each control on every panel
            foreach (Control ctrl in StartPanel.Controls)
            {
                if (ctrl is Button)
                    ctrl.Font = pokemonFont;
                if (ctrl is TextBox)
                    ctrl.Font = pokemonFont;
                if (ctrl is Label)
                    ctrl.Font = pokemonFont;
            }

            foreach (Control ctrl in IntroPanel.Controls)
            {
                if (ctrl is Button)
                    ctrl.Font = pokemonFont;
                if (ctrl is NumericUpDown)
                    ctrl.Font = pokemonFontIntro;
            }

            foreach (Control ctrl in SearchPanel.Controls)
            {
                if (ctrl is Button)
                    ctrl.Font = pokemonFont;
                if (ctrl is Label)
                    ctrl.Font = pokemonFont;
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
        private void PokemonQA_Load(object sender, EventArgs e)
        {
            //Adding every panel to a List
            listPanel.Add(StartPanel);
            listPanel.Add(IntroPanel);
            listPanel.Add(SearchPanel);
            listPanel.Add(QAPanel);
            listPanel.Add(BufferPanel);
            listPanel.Add(EndingPanel);
            //On startup → Bring StartPanel to front
            listPanel[0].BringToFront();
        }


        /*Components on StartPanel (Panel 0)
        ________________________________________________________*/
        private void PlayButton_Click(object sender, EventArgs e)
        {
            //When Play is clicked → Bring IntroPanel to front
            listPanel[1].BringToFront();
        }


        /*Components on IntroPanel (Panel 1)
       ________________________________________________________*/
        private void StartButton_Click(object sender, EventArgs e)
        {
            //Grab value of NumericUpDown; Bring QAPanel to front; Generate new question
            numberToWin = (int)NumberOfPokemonComp.Value;
            listPanel[2].BringToFront();
            searchTimeLeft = searchTimerStartValue;
            SearchTimer.Start();
        }


        /*Components on SearchPanel (Panel 2)
        ________________________________________________________*/
        private void ActAsInput_Click(object sender, EventArgs e)
        {
            listPanel[3].BringToFront();
            NewQuestion();
        }
        private void SearchTimer_Tick(object sender, EventArgs e)
        {
            if (searchTimeLeft > 0)
            {
                // Display the new time left
                // by updating the Time Left label.
                searchTimeLeft--;
                SearchTimerLabel.Text = searchTimeLeft.ToString();
            }
            else
            {
                // If the user ran out of time, stop the timer
                SearchTimer.Stop();
                SearchTimerLabel.Text = "You ran out of time!";
                CheckEnding();
            }
        }


        /*Components on QAPanel (Panel 3)
        ________________________________________________________*/
        private void NewQuestionButton_Click(object sender, EventArgs e)
        {
            NewQuestion();
        }
        //Clicking AnswerButtons stops GameTimer & checks whether answer is (in)correct
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
        private void Timer_Tick(object sender, EventArgs e)
        {
            if (timeLeft > 0)
            {
                // Display the new time left
                // by updating the Time Left label.
                timeLeft--;
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
        

        /*Functions to generate new Question
        ________________________________________________________*/
        private void NewQuestion()
        {
            ClearButtons(); //Reset text & image of AnswerButtons & TimerLabel
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

            SetButtonsTags(); //Use tag to store answer as some answers are images

            ChangeFontColor(); //Change font color depending on background to make text more visible

            //Display correct image for background
            string randomBackgroundString = question.GetPokemon().GetBackgroundName();
            QAPanel.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject(randomBackgroundString);

            //Display correct image for Pokémon
            string randomPokemonString = question.GetPokemon().GetCorrectName();
            PokemonPictureBox.Image = (Image)Properties.Resources.ResourceManager.GetObject(randomPokemonString);
            PokemonPictureBox.Refresh();

            //Display correct question
            QuestionLabel.Text = question.GetQuestion();


            timeLeft = gameTimerStartValue;
            GameTimer.Start();
        }
        private void ClearButtons()
        {
            //Reset text & image of AnswerButtons & TimerLabel
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
            //Use tag to store answer as some answers are images
            Answer1Button.Tag = question.GetRandomAnswer1();
            Answer2Button.Tag = question.GetRandomAnswer2();
            Answer3Button.Tag = question.GetRandomAnswer3();
            Answer4Button.Tag = question.GetRandomAnswer4();
        }
        private void SetButtonsType()
        {
            //Display types as images on AnswerButtons
            Answer1Button.Image = (Image)Properties.Resources.ResourceManager.GetObject(question.GetRandomAnswer1());
            Answer2Button.Image = (Image)Properties.Resources.ResourceManager.GetObject(question.GetRandomAnswer2());
            Answer3Button.Image = (Image)Properties.Resources.ResourceManager.GetObject(question.GetRandomAnswer3());
            Answer4Button.Image = (Image)Properties.Resources.ResourceManager.GetObject(question.GetRandomAnswer4());
        }
        private void SetButtonsName()
        {
            //Display names as text on AnswerButtons
            Answer1Button.Text = question.GetRandomAnswer1();
            Answer2Button.Text = question.GetRandomAnswer2();
            Answer3Button.Text = question.GetRandomAnswer3();
            Answer4Button.Text = question.GetRandomAnswer4();
        }
        private void ChangeFontColor()
        {
            //Change font color depending on background to make text more visible
            int backgroundNumber = question.GetPokemon().GetBackgroundNumber();
            switch (backgroundNumber)
            {
                case 1:
                case 8:
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
                case 2:
                case 3:
                case 4:
                case 5:
                case 6:
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


        /*Used to check if won/lost after you answer a question
        ________________________________________________________*/
        private void CheckReward()
        {
            correctAnswers++;
            if (correctAnswers >= numberToWin)
            {
                //When you've answered enough questions correctly → set random background & bring EndingPanel to front
                endScreenImage += rnd.Next(1, 5);
                EndingPanel.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject(endScreenImage);
                listPanel[5].BringToFront();
                EndingLabel.Text = "You've caught enough Pokémon!";
            }
            else
            {
                //set some text to gj u got the pokemon but theres X more or something
                //BufferPanel.BackgroundImage = //some relevant image
                DisplayBufferPanel();
            }
        }
        private void CheckEnding()
        {
            wrongAnswers++;
            if(wrongAnswers > 3)
            {
                //When you've answered too many questions incorrectly → set random background & bring EndingPanel to front 
                endScreenImage += rnd.Next(1, 5);
                EndingPanel.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject(endScreenImage);
                listPanel[5].BringToFront();
                EndingLabel.Text = "You've lost too many Pokémon...";

            }
            else
            {
                //set some text to gj u got the pokemon but theres X more or something
                //BufferPanel.BackgroundImage = //some relevant image
                LostPokemonLabel.Text = "You've lost " + wrongAnswers + " Pokémon";
                DisplayBufferPanel();
            }
        }


        private void DisplayBufferPanel()
        {
            listPanel[4].BringToFront();
            //make thread sleep? or use another timer(BufferTimer) for X seconds then restart searchtimer
            SearchTimerLabel.ResetText();
            listPanel[2].BringToFront();
            searchTimeLeft = searchTimerStartValue;
            SearchTimer.Start();
        }

        /*Components on EndingPanel (Panel 5)
        ________________________________________________________*/
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

        /*Used to reset values when restarting game
        ________________________________________________________*/
        private void ResetValues()
        {
            wrongAnswers = 0;
            correctAnswers = 0;
            endScreenImage = "EndingScreen";
            LostPokemonLabel.ResetText();
        }
    }
}
