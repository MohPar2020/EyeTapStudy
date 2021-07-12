using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

// ===============================
// AUTHOR       :   Mohsen Parisay (m_parisa@encs.concordia.ca)
// CREATE DATE  :   December 19, 2018
// PURPOSE      :   This class handles the mouse and eye pointer positions on the screen
// ===============================

namespace EyeTapStudy
{
    class PositionManager
    {
        private List<Point> buttonsLocation = new List<Point>();
        private StringBuilder pointerPosition = new StringBuilder();
        FileOperations fo = new FileOperations();

        public void AddButtonLocation(Point location)
        {
            buttonsLocation.Add(location);
        }

        public void AddPointerLocation(int x, int y)
        {
            String localDate = fo.FormatDateTime(fo.GetCurrentLocalDate(), FileOperations.MILLISEC_TYPE);

            pointerPosition.Append(localDate);
            pointerPosition.Append(",");
            pointerPosition.Append(x);
            pointerPosition.Append(",");
            pointerPosition.Append(y);
            pointerPosition.Append("\n");
        }

        public void StorePointerLocations(int userId, String testingMode, int level)
        {
            FileOperations fo = new FileOperations();
            fo.WriteMousePositions(userId, testingMode, level, pointerPosition.ToString());
            pointerPosition.Clear();
        }

        public void StoreStandardLocations(int userId, String testingMode, int level)
        {
            StringBuilder sb = new StringBuilder();

            foreach (Point pnt in buttonsLocation)
            {                
                sb.Append(pnt.X);
                sb.Append(",");
                sb.Append(pnt.Y);
                sb.Append("\n");
            }

            
            fo.WriteStandardPositions(userId, testingMode, level, sb.ToString());
            buttonsLocation.Clear();
        }

    }
}
