using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

// ===============================
// AUTHOR       :   Mohsen Parisay (m_parisa@encs.concordia.ca)
// CREATE DATE  :   June 6, 2018
// PURPOSE      :   This class handles I/O events
// ===============================

namespace EyeTapStudy
{
    class FileOperations
    {
        private static string OUTPUT_FOLDER = "C:/TEMP/UserStudy/";
        private String screenShotPath = OUTPUT_FOLDER + "Screenshots/";
        private String pointerPositionPath = OUTPUT_FOLDER + "Pointer/";
        private String standardPositions = OUTPUT_FOLDER + "STDP/STDP_";
        private String logFileDirectory = OUTPUT_FOLDER + "/Log/";

        private List<String> targetList = new List<string>();
        public static String FULL_TYPE = "yyyyMMdd_HHmmss";
        public static String SHORT_TYPE = "HH:mm:ss";
        public static String MILLISEC_TYPE = "HHmmss_ffffff";
        private String filePath;

        public void SaveScreenShot(int userId, String testingMode, int level, System.Drawing.Bitmap bmp)
        {
            DateTime dateTime = this.GetCurrentLocalDate();
            String localDate = this.FormatDateTime(dateTime, FULL_TYPE);       
            String fileName = screenShotPath + "USER_" + userId + "_" + testingMode + "_level_" + level + "_" + localDate + ".jpg";
            bmp.Save(fileName);
        }        

        public void WriteMousePositions(int userId, String testingMode, int level, String data)
        {            
            String path = pointerPositionPath + "USER_" + userId + "_" + testingMode + "_" + level + ".csv";
            File.WriteAllText(path, data);
        }

        public void WriteStandardPositions(int userId, String testingMode, int level, String data)
        {            
            String path = standardPositions + "USER_" + userId + "_" + testingMode + "_" + level + ".csv";
            File.WriteAllText(path, data);
        }

        public void WriteElapsedTime(int userId, int level, String testingMode, long elapsedTime)
        {
            this.WriteLogTime();
            File.AppendAllText(filePath, "Level: " + level + ", " + testingMode + ", duration, " + elapsedTime + Environment.NewLine);
            File.AppendAllText(filePath, Environment.NewLine);
        }

        private void WriteStatistics(int level, String testingMode, int wrongSelection)
        {
            this.WriteLogTime();
            File.AppendAllText(filePath, "Level: " + level + ", " + testingMode + ", wrong, " + wrongSelection + Environment.NewLine);            
            File.AppendAllText(filePath, Environment.NewLine);
        }

        public void ProtocolAction(int userId, int level, String testingMode, String targetNumber)
        {           
            DateTime localDate = this.GetCurrentLocalDate();
            filePath = logFileDirectory + "USER_" + userId +  "_log_" + localDate.ToShortDateString() + "_.csv";

            StringBuilder data = new StringBuilder();
            data.Append(testingMode);
            data.Append(", item, ");
            data.Append(targetNumber);
                        
            this.WriteLogTime();
            File.AppendAllText(filePath, "Level: " + level + ", " + data.ToString() + Environment.NewLine);
        }

        public void WriteLogTime()
        {            
            String localDate = this.FormatDateTime(this.GetCurrentLocalDate(), SHORT_TYPE);
            File.AppendAllText(filePath, localDate + ", ");
        }

        public DateTime GetCurrentLocalDate()
        {
            return DateTime.Now;
        }

        public String FormatDateTime(DateTime dt, String formatType)
        {
            String formattedDateTime = dt.ToString(formatType);
            return formattedDateTime;
        }

    }
}
