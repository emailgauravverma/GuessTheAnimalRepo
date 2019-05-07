using System;
using System.Configuration;
using System.Data;
using BusinessLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GTAUT
{
    [TestClass]
    public class Tests
    {
        private DataSet dsCreatures;
        private DataTable dtAnimalList;
        private string database = string.Empty;

        [TestInitialize]
        public void SetupConfig()
        {
            //Set Database Connection String
            if (ConfigurationManager.ConnectionStrings["DatabaseLocation"] != null)
            {
                database = ConfigurationManager.ConnectionStrings["DatabaseLocation"].ToString();
            } 
        }

        [TestMethod]
        public void ReadXML()
        {
            //Arrange
            BusinessLayerOperations BLLayer = new BusinessLayerOperations();

            //Act 
            dtAnimalList = BLLayer.ReadXML(database);

            //Assert
            Assert.IsTrue(dtAnimalList.Rows.Count > 0);
        }

        [TestMethod]
        public void UpdateDatabase()
        {
            //Arrange
            BusinessLayerOperations BLLayer = new BusinessLayerOperations();
            DataSet dsUpdated = new DataSet();
            DataTable dt = new DataTable();

            //Act
            //Set dummy data in DataTabel for dtAnimalList
            dtAnimalList = new DataTable("Animals");
            dtAnimalList.Columns.Add("ID", typeof(int));
            dtAnimalList.Columns.Add("Name", typeof(String));
            dtAnimalList.Columns.Add("WayOfSpeak", typeof(String));
            dtAnimalList.Columns.Add("HasTail", typeof(Boolean));
            dtAnimalList.Columns.Add("Colour", typeof(String));
            dtAnimalList.Rows.Add(new object[] { 4, "Cat", "Mio", 0, "White" });
            dtAnimalList.Copy();
            dsUpdated.Tables.Add(dtAnimalList);

            //Assert
            BLLayer.UpdateDatabase(dsUpdated, database);
            dtAnimalList = BLLayer.ReadXML(database);

            //Assert
            Assert.IsTrue(dtAnimalList.Rows.Count > 0);

        }


        //Above are just examples, many more TEST CASES are supposed to be created
    }
}
