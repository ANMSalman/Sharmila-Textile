using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Sharmila_Textile_WebApp.HtmlEntities {
    public static class Miscellaneous {
        public static void CreateFolder(string path) {
            
            try {
                if (Directory.Exists(path)) {
                    Console.WriteLine("That path exists already.");

                }
                else {
                    DirectoryInfo di = Directory.CreateDirectory(path);
                    Console.WriteLine("The directory was created successfully at {0}.", Directory.GetCreationTime(path));
                }

            }
            catch (Exception e) {
                Console.WriteLine("The process failed: {0}", e.ToString());
            }
            finally { }
        }

        public static string SplitCamelCase(string str) {
            var output = Regex.Replace(str, "(\\B[A-Z])", " $1");
            return output;
        }
    }
}
