using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RenameFilesInDir
{
    class Program
    {
        const string SearchPattern = "*.*";
        static string prepend;

        static void Main(string[] args)
        {

            Console.Write("Enter the folder path: ");
            string folder = Console.ReadLine();

            Console.WriteLine("Renaming files in folder " + folder);
            
            Console.Write("Enter the prepend value: ");
            prepend = Console.ReadLine();

            Console.Write("Start from number: ");
            int counter = Convert.ToInt32(Console.ReadLine()); 

            Console.WriteLine("Renaming in progress..");

            string[] files = Directory.GetFiles(folder, SearchPattern);
            if ((files == null) || (files.Length < 1)) return;

            //int counter = 0;
            foreach (string file in files)
            {
                if (!(File.Exists(file))) return;

                string dest = GenDestName(file, counter);

                /*if (File.Exists(dest))
                {
                    Console.WriteLine("Cannot  rename  " + file + "  to  " +
                       dest + ":    Destination  file  exists");
                    return;
                }*/

                File.Move(file, dest);

                counter++;
            }
        }

        protected static string GenDestName(string source, int counter)
        {
            try
            {
                string dir = Path.GetDirectoryName(source);
                string source_fname = Path.GetFileName(source);
                string source_extn = Path.GetExtension(source);

                string targ_fname = prepend + "_" + counter + source_extn;
                string target = Path.Combine(dir, targ_fname);

                return target;
            }
            catch (Exception e)
            {
                return null;
            }

        }
    }
}
