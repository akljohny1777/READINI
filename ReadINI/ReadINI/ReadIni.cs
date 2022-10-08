using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Collections.Generic;

namespace ReadINI
{
    class ReadINI
    {
        public const int SECTION_SIZE = 32767;
        
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
            if (bytesReturned == 0)
                return null;
            string sectionNamesLocal = Marshal.PtrToStringAnsi(pReturnedString, (int)bytesReturned).ToString();
            string[] tmp = sectionNamesLocal.Split('\0');
            List<string> result = new List<string>();
            foreach (string entry in tmp)
            {
                result.Add(entry);
            }
            Marshal.FreeCoTaskMem(pReturnedString);
            return result;
        }

    }
}
