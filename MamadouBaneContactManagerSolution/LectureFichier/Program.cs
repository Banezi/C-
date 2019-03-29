using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LectureFichier
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = System.IO.File.ReadAllText(@"C:\Users\" + Environment.UserName + @"\Documents\ContactManager.db");

            // Display the file contents to the console. Variable text is a string.
            //System.Console.WriteLine("Contents of WriteText.txt = {0}", text);

            //Conversion en byte[]
            byte[] bytes = new byte[text.Length * sizeof(char)];
            System.Buffer.BlockCopy(text.ToCharArray(), 0, bytes, 0, bytes.Length);
            Console.WriteLine("Mon buffer " + bytes.ToString());
        }
    }
}
