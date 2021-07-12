using System.Drawing;
using System.Windows.Forms;

// ===============================
// AUTHOR       :   Mohsen Parisay (m_parisa@encs.concordia.ca)
// CREATE DATE  :   December 18, 2018
// PURPOSE      :   Simulation of the eye tracking method 'Smooth Pursuit'
//                  This feature is not yet implemented.                    
// ===============================

namespace EyeTapStudy
{
    class SmoothPursuit
    {
        private static int BUTTON_WIDTH = 60;
        private static int BUTTON_HEIGHT = 40;

        private Button btnUp;
        private Button btnDown;

        public void initButtons()
        {

        }

        public void showButtons(int xLocation, int yLocation)
        {
            int distance = 50;

            Point upLocation = new Point(xLocation, yLocation - distance);
            btnUp.Location = upLocation;

            Point downLocation = new Point(xLocation, yLocation + distance);
            btnDown.Location = downLocation;

            btnUp.Show();
            btnDown.Show();

        }

        public void hideButtons()
        {
            btnUp.Hide();
            btnDown.Hide();
        }
    }
}
