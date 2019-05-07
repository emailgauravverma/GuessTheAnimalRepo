using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLayer
{
    public class DatabaseOperations
    {
        DataSet dsCreatures;
        DataTable dtAnimalList;

        public DataTable ReadXML(string database)
        {
            if (File.Exists(database))
            {
                dsCreatures = new DataSet();
                dsCreatures.ReadXml(database);
                dtAnimalList = dsCreatures.Tables[0]; 
            }
            return dtAnimalList;
        } 

        public void UpdateDatabase(DataSet dsUpdated, string database)
        {
            dsUpdated.WriteXml(database, System.Data.XmlWriteMode.IgnoreSchema);
        }
    }
}
