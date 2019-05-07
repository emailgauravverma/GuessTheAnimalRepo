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

        /// <summary>
        /// Read data from the XML File and pass it back to the calling layer as DataTable
        /// </summary>
        /// <param name="database"></param>
        /// <returns>datatable</returns>
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

        /// <summary>
        /// Updates the database/XML
        /// </summary>
        /// <param name="dsUpdated"></param>
        /// <param name="database"></param>
        public void UpdateDatabase(DataSet dsUpdated, string database)
        {
            dsUpdated.WriteXml(database, System.Data.XmlWriteMode.IgnoreSchema);
        }
    }
}
