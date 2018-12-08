using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using TestProgramLogic.Model;

namespace TestProgramLogic
{
    /// <summary>
    /// Manager that converts file content
    /// </summary>
    public class FileManager
    {
        public DateTime ConvertToDateTime(string oldName)
        {
            double unix = Convert.ToDouble(string.Join("", oldName.ToCharArray().Where(char.IsDigit)));
            DateTime time = new DateTime(1970, 1, 1);
            time = time.AddSeconds(unix);
            return time;
        }

        public string FileNameConverter(string fileName)
        {
            DateTime time = ConvertToDateTime(fileName);
            string currCode = (string.Join("", fileName.ToCharArray().Where(char.IsLetter)));
            //Изменя формат yyyyMMddHHmmss на yyyyMMdd
            string targetFileName = string.Concat(currCode, "_", time.ToString("yyyyMMdd"));
            ///<currCode>_<YYYYMMdd>.tck only years months and days not enough for making uniq name, that is why i use hours minutes and seconds
            return targetFileName;
        }

        private string FullPathVsFileExtension(string oldPath, string oldName)
        {
            string nameVsExtension = String.Concat(oldName, ".tck");
            string fullPath = Path.Combine(oldPath, nameVsExtension);
            return fullPath;
        }

        private string FullPathToNewFile(string newPath, DateTime date)
        {
            string fullPath = Path.Combine(newPath,date.Year.ToString(),date.Month.ToString());
            return fullPath;
        }

        public List<FileRow> GetFileConvertedRows (string oldPath, string currCode, string oldName)
        {
            oldPath = FullPathVsFileExtension(oldPath, oldName);
            List<FileRow> fileRow = new List<FileRow>();

            using (StreamReader sr = new StreamReader(oldPath, System.Text.Encoding.Default))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] lineParams = line.Split(';');
                    DateTime time = ConvertToDateTime(lineParams[0]);
                    fileRow.Add(new FileRow
                    {
                        Ask = lineParams[2],Bid = lineParams[1],CurrentCode = currCode,DateTime = time
                    });
                }
            }
            File.Delete(oldPath);
            
            return fileRow;
        }

        public void RecordBrokerFiles(string brokerTargetPath, Dictionary<string,List<FileRow>> dict)
        {
            foreach (var pair in dict)
            {
                CreateFile(brokerTargetPath,pair.Key, pair.Value);
            }
        }

        public void CreateFile(string brokerTargetPath, string newFileName, List<FileRow> rows)
        {
            string dateValue = string.Join("", newFileName.ToCharArray().Where(char.IsDigit));
            DateTime date = DateTime.ParseExact(dateValue, "yyyyMMdd",null);

            string fileNameWithExtention = String.Concat(newFileName, ".tck");
            string fullPathToFile = FullPathToNewFile(brokerTargetPath, date);
            System.IO.Directory.CreateDirectory(fullPathToFile);
            //rows.GroupBy(elem => elem.DateTime).Select(group => group.First());
            rows = rows.OrderBy(x => x.DateTime).ToList().Distinct( new RowsComparer()).ToList();

            using (StreamWriter sw = new StreamWriter(Path.Combine(fullPathToFile,fileNameWithExtention), true, Encoding.Default))
            {
                foreach (FileRow row in rows)
                {
                    string newRow = String.Concat(row.CurrentCode, ",", row.DateTime.ToString("yyyyMMdd,HHmmss"), ",", row.Bid, ",", row.Ask);
                    sw.WriteLine(newRow);
                }                                    
            }
        }

        //public string CreateNewFolder(string brokerPath, string fileName)
        //{
        //    DateTime time = ConvertToDateTime(fileName);
        //    string newPath = Path.Combine(brokerPath, time.Year.ToString(), time.Month.ToString());
        //    System.IO.Directory.CreateDirectory(newPath);
        //    return newPath;
        //}
    }
}
