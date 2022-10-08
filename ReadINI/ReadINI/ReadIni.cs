using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Collections.Generic;

namespace ReadINI
{
    class ReadINI
    {
        //constants needed here
        
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);
        [DllImport("kernel32")]
        static extern uint GetPrivateProfileSectionNames(IntPtr SectionReturnBuffer, int size, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileSection(string section, byte[] KeyReturnBuffer, int size, string filePath);
        
        public static List<string> SectionNames(string path)
        {
            IntPtr pReturnedString = Marshal.AllocCoTaskMem((int)SECTION_SIZE);
            uint bytesReturned = GetPrivateProfileSectionNames(pReturnedString, SECTION_SIZE, path);
            //validation needed
            string sectionNamesLocal = Marshal.PtrToStringAnsi(pReturnedString, (int)bytesReturned).ToString();
            string[] tmp = sectionNamesLocal.Split('\0');
            List<string> result = new List<string>();
            //iteration
            Marshal.FreeCoTaskMem(pReturnedString);
            return result;
        }

    }
}
