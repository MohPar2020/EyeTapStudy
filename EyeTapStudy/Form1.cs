using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;

// ===============================
// AUTHOR       :   Mohsen Parisay (m_parisa@encs.concordia.ca)
// CREATE DATE  :   June 6, 2018
// PURPOSE      :   User study prototype to measure the accuracy and performance of eye tracking techniques.
// ===============================

namespace EyeTapStudy
{
    public partial class Form1 : Form
    {
        private int currentLevel = -1;
        private long elapsed_time = 0;
        private int previousSelection = 0;
        private Boolean levelWrittenToFile = false;
        private String testingMode = String.Empty;

        private Timer dwellTimer;
        private int TIME_INTERVAL = 100;    // 100 milliseconds
        private int counter = 5;            // 5 times running the timer       

        private Color original;
        private Stopwatch stopwatch;
        private object currentFocusedButton;

        private List<Int32> invalidNumbers = new List<Int32>();
        private List<Button> levelButtons = new List<Button>();
        private List<Control> allButtons = new List<Control>();        

        private ControlManager ctl = new ControlManager();
        private PositionManager psm = new PositionManager();
        private ScreenShot sc = new ScreenShot();
        private FileOperations fo = new FileOperations();

        int userId = -1;

        public Form1()
        {
            InitializeComponent();
            CreateButtons();
            RegisterButtonEvents();
            RegisterMouseMovements();
            ChangeCursor();
            InitInvalidNumbersList();
            lblCurrentLevel.Text = "";
            btnNext.Visible = false;
        }

        private void SetUserId()
        {
            String value = txtUserId.Text;
            if (String.IsNullOrEmpty(value))
            {
                userId = 0;
            }
            else
            {
                userId = Convert.ToInt32(value);
            }
        }

        private void CreateButtons()
        {
            List<Button> buttonsList = ctl.CreateButtons();
            foreach (Button btn in buttonsList)
            {
                mainPanel.Controls.Add(btn);
                allButtons.Add(btn);
            }

            original = mainPanel.Controls[1].BackColor;
        }

        private void RegisterButtonEvents()
        {
            foreach (var btn in allButtons)
            {
                btn.MouseEnter += OnMouseEnterButton;
                btn.MouseLeave += OnMouseLeaveButton;
                btn.Click += OnButtonClick;
            }
        }

        private void RegisterMouseMovements()
        {
            mainPanel.MouseMove += OnMouseMove;
        }

        private void OnMouseEnterButton(object sender, EventArgs e)
        {
            Button currentSelected = (Button)sender;

            if (this.testingMode.Equals("DwellTime") && !this.levelWrittenToFile)
            {
                this.currentFocusedButton = sender;
                SetTimer();
            }
        }

        private void ChangeCursor()
        {            
            String cursorPath = "black_circle.ico";
            Cursor crs = new Cursor(cursorPath);            
            mainPanel.Cursor = crs;            
        }

        private void InitInvalidNumbersList()
        {
            invalidNumbers = ctl.GenerateInvalidNumbers();
        }

        private void SelectLevel()
        {
            ResetButtons();
            int levelNumber = ctl.SelectLevel(this.currentLevel);
            ShowLevelButtons(levelNumber);
        }

        private void ShowLevelButtons(int levelNumber)
        {
            Console.WriteLine("levelNumber -> " + levelNumber);

            List<int> randomNumbers = new List<int>();
            for (int i = 0; i < levelNumber; i++)
            {
                int number = ctl.GetRandomNumber();
                while (randomNumbers.Contains(number))
                {
                    System.Threading.Thread.Sleep(50);
                    number = ctl.GetRandomNumber();
                }
                randomNumbers.Add(number);

                Control ctn = mainPanel.Controls[number];                
                ctn.Text = (i + 1).ToString();
                ctn.BackColor = Color.LightGreen;
                AddLevelButton((Button)ctn);
            }

            
            HideRestOfButtons(levelNumber);
            
        }

        private void HideRestOfButtons(int levelNumber)
        {            
            for (int j = 1; j < levelNumber; j++)
            {
                String currentNumber = levelButtons[j].Text;               
                levelButtons[j].Text = "";
                levelButtons[j].BackColor = original;
            }
        }

        private void ShowNextButton()
        {
            foreach (Button b in levelButtons)
            {
                if (b.Text.Equals(""))
                {
                    b.Text = (previousSelection + 1).ToString();
                    b.BackColor = Color.LightGreen;
                    break;
                }
            }
        }

        private void AddLevelButton(Button btn)
        {
            levelButtons.Add(btn);
        }

        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            if (stopwatch != null && stopwatch.IsRunning)
            {
                psm.AddPointerLocation(e.X, e.Y);
            }
        }

        private void SetTimer()
        {
            dwellTimer = new Timer();
            dwellTimer.Tick += new EventHandler(Tick);
            dwellTimer.Interval = this.TIME_INTERVAL;
            dwellTimer.Start();
        }

        private void Tick(object sender, EventArgs e)
        {
            if (counter == 0)
            {
                dwellTimer.Stop();
                HandleDwellTime(this.currentFocusedButton);
            }
            counter--;

        }

        void OnButtonClick(object sender, EventArgs e)
        {
            if (testingMode.Equals("MouseOnly") || testingMode.Equals("EyeTAP") || testingMode.Equals("VoiceRecognition"))
            {
                ProcessButtonEvent(sender);
            }

        }

        private void ProcessButtonEvent(object sender)
        {
            String buttonName = GetSenderName(sender);
            Button tmp = (Button)sender;

            if (ContainsButton(tmp))
            {
                foreach (var btn in levelButtons)
                {
                    if (btn.Name.Equals(buttonName))
                    {
                        if (IsItemInOrder(btn))
                        {
                            HighlightButton(buttonName);
                            ShowNextButton();                                                                                       
                        }
                        else
                        {
                            ((Button)sender).TabStop = false;
                        }
                    }

                }// end of foreach
            }
            else
            {
                tmp.BackColor = Color.Red;
            }

            String textToWrite = tmp.Text;
            if (String.IsNullOrEmpty(textToWrite))
            {
                textToWrite = "ERROR";
            }

            fo.ProtocolAction(userId, currentLevel, testingMode, textToWrite);

            if (IsLastItem(tmp.Text))
            {
                StopTimer();                
            }
        }

        private void OnMouseLeaveButton(object sender, EventArgs e)
        {
            if (dwellTimer != null)
            {
                dwellTimer.Stop();
                ResetCounter();
            }
        }

        private void ResetCounter()
        {
            counter = 3;
        }

        public Boolean ContainsButton(Button input)
        {
            return ctl.ContainsButton(input, levelButtons);
        }

        private void HandleDwellTime(object sender)
        {
            String buttonName = GetSenderName(sender);
            Button tmp = (Button)sender;

            if (ContainsButton(tmp))
            {
                foreach (var btn in levelButtons)
                {
                    if (btn.Name.Equals(buttonName))
                    {
                        if (IsItemInOrder(btn))
                        {
                            HighlightButton(buttonName);
                            ShowNextButton();
                        }
                        else
                        {
                            ((Button)sender).TabStop = false;
                        }
                    }
                }// end of foreach                
            }
            else
            {
                tmp.BackColor = Color.Red;
            }

            String textToWrite = tmp.Text;
            if (String.IsNullOrEmpty(textToWrite))
            {
                textToWrite = "ERROR";
            }

            fo.ProtocolAction(userId, this.currentLevel, this.testingMode, textToWrite);

            if (IsLastItem(tmp.Text))
            {
                StopTimer();
            }

        }

        private Boolean IsItemInOrder(Button currentButton)
        {
            Boolean result = false;
            bool sucess = Int32.TryParse(currentButton.Text, out int currentValue);

            if (sucess)
            {
                if (currentValue == previousSelection + 1)
                {
                    previousSelection = currentValue;
                    result = true;
                }
            }

            return result;
        }

        private String GetSenderName(object sender)
        {
            Button btn = (Button)sender;
            return btn.Name;
        }

        private void HighlightButton(String buttonName)
        {
            Control ctn = mainPanel.Controls[buttonName];
            ctn.BackColor = Color.Aqua;

            if (IsFirstItem(ctn.Text))
            {
                ActivateTimer();
            }

            // store the location of the selected button                        
            psm.AddButtonLocation(ctn.Location);            
        }

        private Boolean IsFirstItem(String buttonText)
        {
            return buttonText.Equals("1");
        }

        private Boolean IsLastItem(String buttonText)
        {
            return ctl.IsLastItem(buttonText, this.currentLevel);
        }

        private void ActivateTimer()
        {
            stopwatch = new Stopwatch();
            stopwatch.Start();
        }

        private void StopTimer()
        {
            if (stopwatch != null)
            {
                stopwatch.Stop();
                elapsed_time = stopwatch.ElapsedMilliseconds;
                if (!this.levelWrittenToFile)
                {
                    fo.WriteElapsedTime(userId, this.currentLevel, this.testingMode, elapsed_time);
                    this.levelWrittenToFile = true;
                    sc.CaptureScreenShot(this.userId, Form.ActiveForm, this.testingMode, this.currentLevel);
                    psm.StoreStandardLocations(this.userId, this.testingMode, this.currentLevel);
                    psm.StorePointerLocations(this.userId, this.testingMode, this.currentLevel);

                }
            }

            elapsed_time = 0;

            ActivateTimer();
            GoToNextLevel();
        }

        private void ApplyDelay()
        {

        }

        private Boolean TestingModeSelected()
        {
            return !String.IsNullOrEmpty(this.testingMode);
        }

        private void level1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetSelection(1);
        }

        private void level2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetSelection(2);
        }

        private void level3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetSelection(3);
        }

        private void level4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetSelection(4);
        }

        private void level5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetSelection(5);
        }

        private void SetSelection(int level)
        {
            SetUserId();
            if (userId < 1)
            {
                MessageBox.Show("Please enter user id");
                return;
            }

            if (TestingModeSelected())
            {
                ResetLevel();
                this.currentLevel = level;
                SelectLevel();

                String newTitle = this.testingMode + " Level (" + level + ") of 5";
                lblCurrentLevel.Text = newTitle;
                btnNext.Visible = true;
            }
            else
            {
                ShowSelectionMessage();
            }
        }

        private void ShowSelectionMessage()
        {
            MessageBox.Show("Please select testing mode");
        }

        private void ResetButtons()
        {
            foreach (var btn in allButtons)
            {
                btn.Text = "";
                btn.BackColor = this.original;
            }
        }

        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResetEveryThing();
        }

        private void ResetEveryThing()
        {
            StopTimer();
            ResetVariables();
            SetTestingMode(String.Empty);
            ResetButtons();
            lblCurrentLevel.Text = "";
            btnNext.Visible = false;
        }

        private void ResetLevel()
        {
            ResetVariables();
            ResetButtons();

        }

        private void ResetVariables()
        {
            levelButtons.Clear();
            this.currentLevel = -1;

            this.previousSelection = 0;
            this.levelWrittenToFile = false;
            this.elapsed_time = 0;
        }

        private void mouseOnlyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetTestingMode("MouseOnly");
        }

        private void dwellTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetTestingMode("DwellTime");
        }

        private void voiceRecognitionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetTestingMode("VoiceRecognition");
        }

        private void eyeTAPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetTestingMode("EyeTAP");
        }

        private void SetTestingMode(String mode)
        {
            this.testingMode = mode;
        }

        private void smoothPursuitToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            GoToNextLevel();
        }

        private void GoToNextLevel()
        {
            if (this.currentLevel <= 4 && this.currentLevel >= 1)
            {
                this.currentLevel += 1;
                SetSelection(this.currentLevel);
                mainPanel.Visible = false;
                mainPanel.Visible = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
