using System;
using System.Drawing;
using System.Windows.Forms;

// ===============================
// AUTHOR       :   Mohsen Parisay (m_parisa@encs.concordia.ca)
// CREATE DATE  :   December 18, 2018
// PURPOSE      :   This class is responsible for taking screen shots
// ===============================

namespace EyeTapStudy
{
    class ScreenShot
    {
        public void CaptureScreenShot(int userId, Form form, String testingMode, int level)
        {
            var frm = form;
            try
            {
                using (var bmp = new Bitmap(frm.Width, frm.Height))
                {
                    frm.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));
                    FileOperations fo = new FileOperations();
                    fo.SaveScreenShot(userId, testingMode, level, bmp);
                }

            }
            catch(Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
            
        }

    }
}
