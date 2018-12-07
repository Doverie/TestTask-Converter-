using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProgramDataLayer.DbModel;

namespace TestProgramDataLayer
{
    public class ModelsRepository
    {
        public void CheckDbExist()
        {
            using (DBContext context = new DBContext())
            {
                if (context.Database.Exists())
                {
                    context.Database.Delete();
                    context.SaveChanges();
                }
            }
        }
        public int AddBrokerModelToDB(Broker brokerModel)
        {
            using (DBContext context = new DBContext())
            {
                context.Broker.Add(brokerModel);
                context.SaveChanges();
                int id = brokerModel.BrokerId;
                return id;
            }
        }

        public void AddSourceFileModelToDB(SourceFiles souceFileModel)
        {
            using (DBContext context = new DBContext())
            {
                context.SourceFile.Add(souceFileModel);
                context.SaveChanges();

            }
        }

        public void AddTargetFileModelsToDB(List<TargetFile> targetFileModels)
        {
            using (DBContext context = new DBContext())
            {
                context.TargetFile.AddRange(targetFileModels);
                context.SaveChanges();
            }
        }

    }
}
