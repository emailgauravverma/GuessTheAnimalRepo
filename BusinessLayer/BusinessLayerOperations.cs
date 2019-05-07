using DatabaseLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class BusinessLayerOperations
    {
        DatabaseOperations DLLayer = null;

        public DataTable ReadXML(string database)
        {
            DLLayer = new DatabaseOperations();
            var dtAnimalList = DLLayer.ReadXML(database);
            return dtAnimalList;
        } 

        public void UpdateDatabase(DataSet dsUpdated, string database)
        {
            DLLayer = new DatabaseOperations();
            DLLayer.UpdateDatabase(dsUpdated, database);
        }
    }
}
