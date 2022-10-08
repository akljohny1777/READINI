using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Collections.Generic;

namespace ReadINI
{
    class ReadINI
    {
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);
        [DllImport("kernel32")]
        static extern uint GetPrivateProfileSectionNames(IntPtr SectionReturnBuffer, int size, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileSection(string section, byte[] KeyReturnBuffer, int size, string filePath);
        
    }
}
