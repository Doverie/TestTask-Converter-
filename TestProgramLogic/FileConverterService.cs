using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProgramLogic.Model;
using TestProgramDataLayer;


namespace TestProgramLogic
{
    /// <summary>
    /// Service that manages files
    /// </summary>
    public class FileConverterService
    {
        public void FillModels(string sourcePathFormUser, string targetPathFormUser)
        {
            List<string> brokers = GetBrokersNames(sourcePathFormUser);
            List<string> folders = new List<string>();
            List<string> files = new List<string>();
            FileManager converter = new FileManager();

            List<TestProgramDataLayer.DbModel.Broker> brokersModels = new List<TestProgramDataLayer.DbModel.Broker>();
            List<TestProgramDataLayer.DbModel.TargetFile> targetFilesModels = new List<TestProgramDataLayer.DbModel.TargetFile>();

            ModelsRepository repo = new ModelsRepository();

            repo.CheckDbExist();

            foreach (var broker in brokers)
            {
                var brokerSourcePath = Path.Combine(sourcePathFormUser, broker);
                var brokerTargetPath = Path.Combine(targetPathFormUser, broker);
                var brokerModel = new TestProgramDataLayer.DbModel.Broker
                {
                    Name = broker, NewBaseFolder = brokerTargetPath, OldBaseFolder = brokerSourcePath
                };

                brokersModels.Add(brokerModel);
                int brokerId = repo.AddBrokerModelToDB(brokerModel);

                folders = GetFoldersInBrokerNames(brokerSourcePath);

                foreach (var folder in folders)
                {
                    var folderPath = Path.Combine(brokerSourcePath, folder);
                    files = GetFileNames(folderPath);
                    
                    foreach (var file in files)
                    {
                        var sourceFileModel = new TestProgramDataLayer.DbModel.SourceFile
                        {
                            Name = file,
                            OldFilePath = folderPath,
                            BrokerId = brokerId
                        };
                        repo.AddSourceFileModelToDB(sourceFileModel);

                        string newFileName = converter.FileNameConverter(file);
                       
                        string newPath = converter.CreateNewFolder(brokerTargetPath, file);
                        DateTime fileDate = converter.ConvertToDateTime(file);
                        string currCode = (string.Join("", file.ToCharArray().Where(char.IsLetter)));

                        var targetFileModel = new TestProgramDataLayer.DbModel.TargetFile
                        {
                            FileName = newFileName, NewFolder = newPath, BrokerId = brokerId, FileDate = fileDate
                        };
                        converter.FileInformationConverter(folderPath, newPath, currCode, file, newFileName);
                        targetFilesModels.Add(targetFileModel);
                    }
                }
            }

            var orderedNewFiles = targetFilesModels.OrderBy(el => el.FileDate).ToList();
            repo.AddTargetFileModelsToDB(orderedNewFiles);
        }

        private List<string> GetBrokersNames(string sourcePathFromUser)
        {
            List<string> brokers = new List<string>();
            string path = sourcePathFromUser;
            string[] brokersInfo = Directory.GetDirectories(path);
            foreach (string broker in brokersInfo)
            {
                brokers.Add(Path.GetFileName(broker));
            }
            return brokers;
        }

        private List<string> GetFoldersInBrokerNames(string path)
        {
            List<string> foldersInBroker = new List<string>();
            string[] foldersInfo = Directory.GetDirectories(path);
            foreach (string folder in foldersInfo)
            {
                foldersInBroker.Add(Path.GetFileName(folder));
            }
            return foldersInBroker;
        }

        private List<string> GetFileNames(string path)
        {
            List<string> filesInFolder = new List<string>();
            string[] filesInfo = Directory.GetFiles(path);

            foreach (string file in filesInfo)
            {
                filesInFolder.Add(Path.GetFileNameWithoutExtension(file));
            }

            return filesInFolder;
        }

    }
}

