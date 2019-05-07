using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer;
using System.Configuration;

namespace GuessTheAnimal
{
    /// <summary>
    /// This class represents all the operations related to Add/Edit/Delete/Udpate for Animal
    /// </summary>
    public partial class GuessTheAnimal : Form
    {
        #region Variables
        DataSet dsCreatures;
        DataTable dtAnimalList;
        string database = string.Empty;
        bool animalsFullFeatures = false; 
        BusinessLayer.BusinessLayerOperations BLLayer = null;
        #endregion

        #region Constructor
        public GuessTheAnimal()
        {
            InitializeComponent();
         
            if(ConfigurationManager.ConnectionStrings["DatabaseLocation"] != null)
                database = ConfigurationManager.ConnectionStrings["DatabaseLocation"].ToString();

        }
        #endregion

        #region Load Operations
        private void GuessTheAnimal_Load(object sender, EventArgs e)
        {
            BindGrid(animalsFullFeatures);
        }

        private void BindGrid(bool ShowFullFeatures)
        {
            BLLayer = new BusinessLayerOperations();
            dtAnimalList = BLLayer.ReadXML(database);
            dgvAnimalsList.DataSource = dtAnimalList;

            dgvAnimalsList.Columns[0].Visible = ShowFullFeatures;
            dgvAnimalsList.Columns[2].Visible = ShowFullFeatures;
            dgvAnimalsList.Columns[3].Visible = ShowFullFeatures;
            dgvAnimalsList.Columns[4].Visible = ShowFullFeatures;
        }

        //Load the combo boxes with values from Database
        private void LoadComboBoxes()
        {
            if (dtAnimalList != null && dtAnimalList.Rows.Count > 0)
            {
                cmbAnimalWaySpeaks.BindingContext = this.BindingContext;
                cmbAnimalWaySpeaks.DataSource = dtAnimalList.DefaultView;
                cmbAnimalWaySpeaks.DisplayMember = "WayOfSpeak";
                cmbAnimalWaySpeaks.Text = "Select the Way Your Animal Speaks";

                cmbAnimalHasTail.BindingContext = new BindingContext();
                if (!cmbAnimalHasTail.Items.Contains("YES")) { cmbAnimalHasTail.Items.Add("YES"); }
                if (!cmbAnimalHasTail.Items.Contains("NO")) { cmbAnimalHasTail.Items.Add("NO"); }
                //cmbAnimalHasTail.SelectedIndex = 0;
                cmbAnimalHasTail.Text = "Select Animal Has Tail Or Not";


                cmbAnimalColor.BindingContext = new BindingContext();
                cmbAnimalColor.DataSource = dtAnimalList.DefaultView;
                cmbAnimalColor.DisplayMember = "Colour";
                cmbAnimalColor.Text = "Select Colour Of Your Animal";
            }
        }

        private void tabQuestions_Enter(object sender, EventArgs e)
        {
            //tabList.SelectTab("tabQuestions");
            LoadComboBoxes();
        }

        private void btnAnimalFullFeatures_Click(object sender, EventArgs e)
        {
            string strAnimalFullFeatures = "";

            try
            {
                if (animalsFullFeatures)
                {
                    strAnimalFullFeatures = "see";
                    btnUpdate.Visible = false;
                    animalsFullFeatures = false;
                }
                else
                {
                    strAnimalFullFeatures = "hide";
                    btnUpdate.Visible = true;
                    animalsFullFeatures = true;
                }

                btnAnimalFullFeatures.Text = "Click To " + strAnimalFullFeatures + " Animals with Full Features";
                BindGrid(animalsFullFeatures);
            }
            catch (Exception)
            {
                throw;
            }
           
           
        }

        #endregion

        #region Combobox SelectionChanged Events
        private void cmbAnimalWaySpeaks_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplayLable(FindAnimal());
        }

        private void cmbAnimalHasTail_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplayLable(FindAnimal());
        }

        private void cmbAnimalColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplayLable(FindAnimal());
        }
        #endregion 

        #region Search Animal Based On Selction Criteria
        /// <summary>
        /// Search the Animal on the basis of the Selection Criteria
        /// </summary>
        /// <returns>Name of Animal</returns>
        private string FindAnimal()
        {
            var FeatureOneAnimalWayOfSpeak = cmbAnimalWaySpeaks.Text;
            var FeatureTwoAimalHasTail = cmbAnimalHasTail.Text;
            var FeatureThreeAnimalColour = cmbAnimalColor.Text;

            DataRow[] result = dtAnimalList.Select("WayOfSpeak = '" + FeatureOneAnimalWayOfSpeak + "'" + " and " +
                              "HasTail = '" + FeatureTwoAimalHasTail + "'" + " and " +
                              "Colour = '" + FeatureThreeAnimalColour + "'");

            if (result.Count() > 0 && result[0]["Name"] != null)
                return result[0]["Name"].ToString();
            else
                return "No Match Found !!";
        }


        private void DisplayLable(string identifiedAnimal)
        {
            pictureBox1.Hide();
            lblAnimal.Text = identifiedAnimal;
        }

        #endregion

        #region Update Animal List to Database

        #region Edit The Animal Grid
        /// <summary>
        /// Update The Animal Grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvAnimalsList_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //Get the ID Column Value
            string idColumnVal = dgvAnimalsList.Rows[e.RowIndex].Cells["ID"].Value.ToString();

            //Get the Animal Name Column Value
            string nameColumnVal = dgvAnimalsList.Rows[e.RowIndex].Cells["Name"].Value.ToString();


            //Validate the ID should only be Integer Type
            if (!string.IsNullOrEmpty(idColumnVal) && !ValidateIntegerValue(idColumnVal))
            {
                MessageBox.Show("The entered ID  " + idColumnVal + "  need to be an Integer Only");

                return;
            }

            //Validate Duplicate ID
            if (!string.IsNullOrEmpty(idColumnVal) && IsDuplicateId(idColumnVal))
            {
                MessageBox.Show("The entered ID  " + idColumnVal + " already exists");

                dgvAnimalsList.Rows[e.RowIndex].Cells["ID"].Selected = true;

                return;
            }

            //Validate Duplicate Animal name
            if (!string.IsNullOrEmpty(nameColumnVal) && IsDuplicateAnimal(nameColumnVal))
            {
                MessageBox.Show("The entered Animal " + nameColumnVal + " already exists");

                dgvAnimalsList.Rows[e.RowIndex].Cells["Name"].Selected = true;

                return;
            }
        }
        #endregion

        #region Update Animal List
        /// <summary>
        /// Update the Animal List to database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                dtAnimalList = (DataTable)dgvAnimalsList.DataSource;
                DataSet dsUpdated = new DataSet();
                DataTable dt = dtAnimalList.Copy();
                dsUpdated.Tables.Add(dt);

                BLLayer = new BusinessLayerOperations();
                BLLayer.UpdateDatabase(dsUpdated,database);
                 
                MessageBox.Show("The data has been updated successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception Occured: " + ex.Message + " : stack: " + ex.StackTrace);
            } 
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            BindGrid(animalsFullFeatures);
        }
        #endregion

        #endregion

        #region Guess The Animal/Go Back GUI
        private void btnStartGuess_Click(object sender, EventArgs e)
        {
            tabList.SelectTab("tabQuestions");
            LoadComboBoxes();
        }

        private void btnGoBack_Click(object sender, EventArgs e)
        {
            tabList.SelectTab("tabAnimalsList");
        }
        #endregion

        #region Validations
        /// <summary>
        /// Validation for Integer Value
        /// </summary>
        /// <param name="id"></param>
        /// <returns>bool</returns>
        private bool ValidateIntegerValue(string id)
        {
            bool isValidInteger = false;
            int value;
            if (int.TryParse(id, out value))
            {
                isValidInteger = true;
            }
            return isValidInteger;
        }
       
        /// <summary>
        /// Validation for Duplicate ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>bool</returns>
        private bool IsDuplicateId(string id)
        {
            var row = dtAnimalList.Select("ID = " + id + "");

            return row.Count() > 0;
        }

        /// <summary>
        /// Validation for Duplicate Name of Animal
        /// </summary>
        /// <param name="name"></param>
        /// <returns>bool</returns>
        private bool IsDuplicateAnimal(string name)
        { 
            var row = dtAnimalList.Select("Name = '"+ name +"' ");

            return row.Count() > 0;
        }
        #endregion
    }
}
