using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//
using System.IO; 

namespace EmoEngineClientLibrary
{
    class ESUM_Util
    {
        public static string FolderNameToExportTo { get { return "ESUM_Export"; } }
        public static string LogFolderPrefix { get { return "ESUM_LOG_";  } }
        public static readonly  int[] BaudRates = { 9600, 14400, 19200, 28800, 38400, 57600, 115200 };
        public static string tabLine { get { return "\t # \t # \t # \t # \t # \t #"; } }
        public static string newLine { get { return "\n"; } }
        //
        private static int numOfFramesToExport = 2;
        public static int NumOfFramesToExport { get { return numOfFramesToExport; } }
        //
        private static string fileExtension = ".csv";
        public static string FileExtension { get { return fileExtension; } }

        public static string programStamp { get { return "*** ESUM Backpack Logger \n*** Chair of Information Architecture ETH Zurich 2015 \n*** Last update 13/02/15 / Constantinos"; } }

        public static TimeSpan RunTime(DateTime startTime)
        {
            TimeSpan duration = startTime - DateTime.Now;
            return duration; 
        }


        /*
         *  EXPORTING
         */
        public static string exportFolder;

        public static void CreateDirectory()
        {
            string timeString = GetDateTime();
            //assemble folder path
            exportFolder = (System.IO.Path.Combine(Environment.ExpandEnvironmentVariables("%userprofile%"), "Documents", ESUM_Util.FolderNameToExportTo, ESUM_Util.LogFolderPrefix + timeString));

            //if it doesnt exist create it 
            bool exists = System.IO.Directory.Exists(exportFolder);
            if (!exists)
                System.IO.Directory.CreateDirectory(exportFolder);

            Console.WriteLine("populated export folder");
        }
        //used for folder 
        public static string GetDateTime()
        {
            DateTime time = DateTime.Now;
            string format = "yy_MM_d_HH_mm";
            return time.ToString(format);
        }
        //for each frame
        public static string GetTimeStamp()
        {
            DateTime time = DateTime.Now;
            string format = "yy_M_d_HH_mm_ss";
            return time.ToString(format);
        }


        /*
         * WRITE FILE
         */
        public static void ExportText(string deviceName, string textToExport)
        {
            //combine paths to create new file 
            string currentExportPath = System.IO.Path.Combine(exportFolder, deviceName + FileExtension);

            try
            {
                using (StreamWriter sw = new StreamWriter(currentExportPath, true)) // true is for append
                {
                    sw.Write(textToExport);
                    Console.WriteLine("Exported! " + currentExportPath);
                }
            }
            catch
            {
                Console.WriteLine("Failed to export :" + currentExportPath);
            }

        }
       
    }//end class
}
