using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMWrapperLibgit2sharp
{
    internal static class Helper
    {
        internal static void WriteLog(string args)
        {
            StreamWriter myfile = new StreamWriter("C:\\Users\\denis\\source\\logs\\log.txt", true);
            myfile.WriteLine(args);
            myfile.Close();
        }
    }
}
