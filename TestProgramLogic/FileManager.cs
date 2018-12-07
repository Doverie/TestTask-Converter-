using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProgramLogic
{
    /// <summary>
    /// Manager that converts file content
    /// </summary>
    public class FileManager
    {
        public DateTime ConvertToDateTime(string unixTime)
        {
            double unix = Convert.ToDouble(string.Join("", unixTime.ToCharArray().Where(char.IsDigit)));
            DateTime time = new DateTime(1970, 1, 1);
            time = time.AddSeconds(unix);
            return time;
        }

        public string FileNameConverter(string fileName)
        {
            DateTime time = ConvertToDateTime(fileName);
            string currCode = (string.Join("", fileName.ToCharArray().Where(char.IsLetter)));
            string targetFileName = string.Concat(currCode, "_", time.ToString("yyyyMMddHHmmss"));
            ///<currCode>_<YYYYMMdd>.tck only years months and days not enough for making uniq name, that is why i use hours minutes and seconds
            return targetFileName;
        }

        private string FullPathWsFileExtension(string path, string name)
        {
            string nameWsExtension = String.Concat(name+ ".tck");
            string fullPath = Path.Combine(path,nameWsExtension);
            return fullPath;
        }

        public void FileInformationConverter(string oldPath, string newPath, string currCode, string oldName, string newName)
        {
            oldPath = FullPathWsFileExtension(oldPath, oldName);
            newPath = Path.Combine(newPath, newName);
            using (StreamReader sr = new StreamReader(oldPath, System.Text.Encoding.Default))
            {
                using (StreamWriter sw = new StreamWriter(newPath))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] lineParams = line.Split(';');
                        DateTime time = ConvertToDateTime(lineParams[0]);
                        string newLine = String.Concat(currCode, ",", time.Year, time.Month, time.Day, ","
                            , time.Hour, time.Minute, time.Second, lineParams[1], ",", lineParams[2]);
                        sw.WriteLine(newLine);
                    }
                }
                
            }
            File.Delete(oldPath);
        }

        public string CreateNewFolder(string brokerPath, string fileName)
        {
            DateTime time = ConvertToDateTime(fileName);
            string newPath = Path.Combine(brokerPath, time.Year.ToString(), time.Month.ToString());
            System.IO.Directory.CreateDirectory(newPath);
            return newPath;
        }
    }
}
