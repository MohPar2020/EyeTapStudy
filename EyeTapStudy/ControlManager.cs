using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace EyeTapStudy
{
    class ControlManager
    {
        private static int ROWS = 9;
        private static int COLUMNS = 13;

        private static int BUTTON_WIDTH = 110;
        private static int BUTTON_HEIGHT = 80;

        private static int LEVEL_1_COUNT = 4;
        private static int LEVEL_2_COUNT = 6;
        private static int LEVEL_3_COUNT = 8;
        private static int LEVEL_4_COUNT = 10;
        private static int LEVEL_5_COUNT = 12;
        
        private Random rnd = new Random();
        private List<Int32> invalidNumbers;

        public List<Button> CreateButtons()
        {
            List<Button> buttonsList = new List<Button>();

            int index = 1;
            for (int i = 0; i < ROWS; i++)
            {
                for (int j = 0; j < COLUMNS; j++)
                {
                    Button btn = new Button();
                    btn.Name = (index - 1).ToString();
                    btn.Text = "";
                    btn.Font = new Font(btn.Font.Name, 11, FontStyle.Bold);
                    btn.Width = BUTTON_WIDTH;
                    btn.Height = BUTTON_HEIGHT;
                    btn.TabStop = false;

                    Point newLocation = new Point((j * (btn.Width + 39)), (i * 100) + 50);
                    btn.Location = newLocation;

                    buttonsList.Add(btn);

                    index++;
                }
            }


            return buttonsList;
        }

        public List<Int32> GenerateInvalidNumbers()
        {
            List<Int32> invalidNumbers = new List<Int32>();

            for (int i = 0; i <= 12; i++)
                invalidNumbers.Add(i);

            for (int j = 104; j <= 116; j++)
                invalidNumbers.Add(j);

            for (int k = 1; k <= 7; k++)
            {
                int number = 13 * k;
                invalidNumbers.Add(number);
            }

            for (int m = 25; m <= 103; m += 13)
            {
                invalidNumbers.Add(m);
            }

            this.invalidNumbers = invalidNumbers;

            return invalidNumbers;
        }

        private void PrintNumbers(List<Int32> invalidNumbers)
        {
            foreach (var number in invalidNumbers)
            {
                Console.WriteLine(number + " ");
            }
        }

        public int SelectLevel(int currentLevel)
        {
            int levelNumber = 0;
            switch (currentLevel)
            {
                case 1:
                    levelNumber = LEVEL_1_COUNT;
                    break;
                case 2:
                    levelNumber = LEVEL_2_COUNT;
                    break;
                case 3:
                    levelNumber = LEVEL_3_COUNT;
                    break;
                case 4:
                    levelNumber = LEVEL_4_COUNT;
                    break;
                case 5:
                    levelNumber = LEVEL_5_COUNT;
                    break;
            }
            return levelNumber;
        }

        public int GetRandomNumber()
        {
            int number = rnd.Next(0, ROWS * COLUMNS);

            if (IsRandomNumberValid(number))
            {
                return number;
            }
            return GetRandomNumber();
        }

        private Boolean IsRandomNumberValid(int number)
        {            
            return !invalidNumbers.Contains(number);
        }

        public Boolean IsLastItem(String buttonText, int currentLevel)
        {
            Boolean result = false;

            switch (currentLevel)
            {
                case 1:
                    if (buttonText.Equals(LEVEL_1_COUNT.ToString()))
                    {
                        result = true;
                    }
                    break;

                case 2:
                    if (buttonText.Equals(LEVEL_2_COUNT.ToString()))
                    {
                        result = true;
                    }
                    break;

                case 3:
                    if (buttonText.Equals(LEVEL_3_COUNT.ToString()))
                    {
                        result = true;
                    }
                    break;

                case 4:
                    if (buttonText.Equals(LEVEL_4_COUNT.ToString()))
                    {
                        result = true;
                    }
                    break;

                case 5:
                    if (buttonText.Equals(LEVEL_5_COUNT.ToString()))
                    {
                        result = true;
                    }
                    break;
            }

            return result;
        }

        public Boolean ContainsButton(Button input, List<Button> levelButtons)
        {
            foreach (var btn in levelButtons)
            {
                if (btn.Name == input.Name)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
