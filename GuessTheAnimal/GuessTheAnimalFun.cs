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
    public partial class GuessTheAnimalFun : Form
    {
        DataSet dsCreatures;
        DataTable dtAnimalList;
        string database = string.Empty;
        bool animalsFullFeatures = false; 
        BusinessLayer.BusinessLayerOperations BLLayer = null;

        public GuessTheAnimalFun()
        {
            InitializeComponent();
         
            if(ConfigurationManager.ConnectionStrings["DatabaseLocation"] != null)
                database = ConfigurationManager.ConnectionStrings["DatabaseLocation"].ToString();
        }

        private void GuessTheAnimalFun_Load(object sender, EventArgs e)
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
            cmbAnimalWaySpeaks.BindingContext = this.BindingContext;
            cmbAnimalWaySpeaks.DataSource = dtAnimalList.DefaultView;
            cmbAnimalWaySpeaks.DisplayMember = "WayOfSpeak";
           

            cmbAnimalHasTail.BindingContext = new BindingContext();
            cmbAnimalHasTail.Items.Add("Yes");
            cmbAnimalHasTail.Items.Add("No");
            cmbAnimalHasTail.SelectedIndex = 0;


            cmbAnimalColor.BindingContext = new BindingContext();
            cmbAnimalColor.DataSource = dtAnimalList.DefaultView;
            cmbAnimalColor.DisplayMember = "Colour";
        }

        private void tabQuestions_Enter(object sender, EventArgs e)
        {
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

        private void DisplayLable(string identifiedAnimal)
        {
            pictureBox1.Hide();
            lblAnimal.Text = identifiedAnimal;
        }

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

        private void btnStartGuess_Click(object sender, EventArgs e)
        {
            tabList.SelectTab("tabQuestions");
        }

        private void btnGoBack_Click(object sender, EventArgs e)
        {
            tabList.SelectTab("tabAnimalsList");
        }

        private void dgvAnimalsList_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //Get the ID Column Value
            string idColumnVal = dgvAnimalsList.Rows[e.RowIndex].Cells["ID"].Value.ToString();
            
            //Get the Animal Name Column Value
            string nameColumnVal = dgvAnimalsList.Rows[e.RowIndex].Cells["Name"].Value.ToString();


            //Validate the ID should only be Integer Type
            if (!string.IsNullOrEmpty(idColumnVal) && !ValidateIntegerValue(idColumnVal))
            {
                MessageBox.Show("The entered ID  "+ idColumnVal + "  need to be an Integer Only");
                                
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

        private bool IsDuplicateId(string id)
        {
            var row = dtAnimalList.Select("ID = " + id + "");

            return row.Count() > 0;
        }

        private bool IsDuplicateAnimal(string name)
        { 
            var row = dtAnimalList.Select("Name = '"+ name +"' ");

            return row.Count() > 0;
        } 
    }
}
