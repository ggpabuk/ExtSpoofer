using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ExtSpoofer
{
    internal static class Program
    {
        private static string ReverseString(string str)
        {
            char[] arr = str.ToCharArray();
            Array.Reverse(arr);
            return new String(arr);
        }

        [STAThread]
        private static void Main()
        {
            while (true)
            {
                var openFile = new OpenFileDialog();

                if (openFile.ShowDialog() != DialogResult.OK)
                    break;

                var saveFile = new SaveFileDialog();
                
                if (saveFile.ShowDialog() != DialogResult.OK)
                    break;
            
                string trueExtension = Path.GetExtension(openFile.FileName).TrimStart('.');
                string fakeExtension = Path.GetExtension(saveFile.FileName);
                string saveBase = saveFile.FileName.Replace(fakeExtension, String.Empty);

                File.Copy(openFile.FileName, 
                    saveBase + '\u202e' + ReverseString(fakeExtension) + trueExtension);

                Console.Write("Press any key to continue...");
                Console.ReadKey(false);
            }
        }
    }
}
