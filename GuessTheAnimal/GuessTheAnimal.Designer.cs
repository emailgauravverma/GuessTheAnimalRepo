namespace GuessTheAnimal
{
    partial class GuessTheAnimal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnUpdate = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblAnimal = new System.Windows.Forms.Label();
            this.btnAnimalFullFeatures = new System.Windows.Forms.Button();
            this.cmbAnimalColor = new System.Windows.Forms.ComboBox();
            this.tabQuestions = new System.Windows.Forms.TabPage();
            this.btnGoBack = new System.Windows.Forms.Button();
            this.cmbAnimalHasTail = new System.Windows.Forms.ComboBox();
            this.cmbAnimalWaySpeaks = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabList = new System.Windows.Forms.TabControl();
            this.tabAnimalsList = new System.Windows.Forms.TabPage();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.dgvAnimalsList = new System.Windows.Forms.DataGridView();
            this.btnStartGuess = new System.Windows.Forms.Button();
            this.lblInfo = new System.Windows.Forms.Label();
            this.dataSet1 = new System.Data.DataSet();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabQuestions.SuspendLayout();
            this.tabList.SuspendLayout();
            this.tabAnimalsList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAnimalsList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(558, 63);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(110, 208);
            this.btnUpdate.TabIndex = 4;
            this.btnUpdate.Text = "UPDATE";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Visible = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.ErrorImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(349, 74);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(315, 164);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // lblAnimal
            // 
            this.lblAnimal.AutoSize = true;
            this.lblAnimal.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAnimal.Location = new System.Drawing.Point(463, 139);
            this.lblAnimal.Name = "lblAnimal";
            this.lblAnimal.Size = new System.Drawing.Size(0, 29);
            this.lblAnimal.TabIndex = 2;
            // 
            // btnAnimalFullFeatures
            // 
            this.btnAnimalFullFeatures.Location = new System.Drawing.Point(303, 34);
            this.btnAnimalFullFeatures.Name = "btnAnimalFullFeatures";
            this.btnAnimalFullFeatures.Size = new System.Drawing.Size(241, 23);
            this.btnAnimalFullFeatures.TabIndex = 3;
            this.btnAnimalFullFeatures.Text = "Click To See Animals with Full Features";
            this.btnAnimalFullFeatures.UseVisualStyleBackColor = true;
            this.btnAnimalFullFeatures.Click += new System.EventHandler(this.btnAnimalFullFeatures_Click);
            // 
            // cmbAnimalColor
            // 
            this.cmbAnimalColor.FormattingEnabled = true;
            this.cmbAnimalColor.Location = new System.Drawing.Point(37, 203);
            this.cmbAnimalColor.Name = "cmbAnimalColor";
            this.cmbAnimalColor.Size = new System.Drawing.Size(270, 21);
            this.cmbAnimalColor.TabIndex = 1;
            this.cmbAnimalColor.SelectedIndexChanged += new System.EventHandler(this.cmbAnimalColor_SelectedIndexChanged);
            // 
            // tabQuestions
            // 
            this.tabQuestions.Controls.Add(this.btnGoBack);
            this.tabQuestions.Controls.Add(this.pictureBox1);
            this.tabQuestions.Controls.Add(this.lblAnimal);
            this.tabQuestions.Controls.Add(this.cmbAnimalColor);
            this.tabQuestions.Controls.Add(this.cmbAnimalHasTail);
            this.tabQuestions.Controls.Add(this.cmbAnimalWaySpeaks);
            this.tabQuestions.Controls.Add(this.label3);
            this.tabQuestions.Controls.Add(this.label2);
            this.tabQuestions.Controls.Add(this.label6);
            this.tabQuestions.Controls.Add(this.label1);
            this.tabQuestions.Location = new System.Drawing.Point(4, 22);
            this.tabQuestions.Name = "tabQuestions";
            this.tabQuestions.Padding = new System.Windows.Forms.Padding(3);
            this.tabQuestions.Size = new System.Drawing.Size(728, 327);
            this.tabQuestions.TabIndex = 1;
            this.tabQuestions.Text = "Questions";
            this.tabQuestions.UseVisualStyleBackColor = true;
            this.tabQuestions.Enter += new System.EventHandler(this.tabQuestions_Enter);
            // 
            // btnGoBack
            // 
            this.btnGoBack.Location = new System.Drawing.Point(37, 244);
            this.btnGoBack.Name = "btnGoBack";
            this.btnGoBack.Size = new System.Drawing.Size(270, 23);
            this.btnGoBack.TabIndex = 4;
            this.btnGoBack.Text = "<<<< Go Back";
            this.btnGoBack.UseVisualStyleBackColor = true;
            this.btnGoBack.Click += new System.EventHandler(this.btnGoBack_Click);
            // 
            // cmbAnimalHasTail
            // 
            this.cmbAnimalHasTail.FormattingEnabled = true;
            this.cmbAnimalHasTail.Location = new System.Drawing.Point(37, 127);
            this.cmbAnimalHasTail.Name = "cmbAnimalHasTail";
            this.cmbAnimalHasTail.Size = new System.Drawing.Size(270, 21);
            this.cmbAnimalHasTail.TabIndex = 1;
            this.cmbAnimalHasTail.SelectedIndexChanged += new System.EventHandler(this.cmbAnimalHasTail_SelectedIndexChanged);
            // 
            // cmbAnimalWaySpeaks
            // 
            this.cmbAnimalWaySpeaks.FormattingEnabled = true;
            this.cmbAnimalWaySpeaks.Location = new System.Drawing.Point(37, 62);
            this.cmbAnimalWaySpeaks.Name = "cmbAnimalWaySpeaks";
            this.cmbAnimalWaySpeaks.Size = new System.Drawing.Size(270, 21);
            this.cmbAnimalWaySpeaks.TabIndex = 1;
            this.cmbAnimalWaySpeaks.SelectedIndexChanged += new System.EventHandler(this.cmbAnimalWaySpeaks_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 187);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(135, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "What color your animal has";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Has your animal got Tail";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(346, 58);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(147, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Here is your favourite Animal :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(159, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Choose how your animal speaks";
            // 
            // tabList
            // 
            this.tabList.Controls.Add(this.tabAnimalsList);
            this.tabList.Controls.Add(this.tabQuestions);
            this.tabList.Location = new System.Drawing.Point(32, 9);
            this.tabList.Name = "tabList";
            this.tabList.SelectedIndex = 0;
            this.tabList.Size = new System.Drawing.Size(736, 353);
            this.tabList.TabIndex = 4;
            // 
            // tabAnimalsList
            // 
            this.tabAnimalsList.Controls.Add(this.btnRefresh);
            this.tabAnimalsList.Controls.Add(this.btnUpdate);
            this.tabAnimalsList.Controls.Add(this.btnAnimalFullFeatures);
            this.tabAnimalsList.Controls.Add(this.dgvAnimalsList);
            this.tabAnimalsList.Controls.Add(this.btnStartGuess);
            this.tabAnimalsList.Controls.Add(this.lblInfo);
            this.tabAnimalsList.Location = new System.Drawing.Point(4, 22);
            this.tabAnimalsList.Name = "tabAnimalsList";
            this.tabAnimalsList.Padding = new System.Windows.Forms.Padding(3);
            this.tabAnimalsList.Size = new System.Drawing.Size(728, 327);
            this.tabAnimalsList.TabIndex = 0;
            this.tabAnimalsList.Text = "Animals";
            this.tabAnimalsList.UseVisualStyleBackColor = true;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(221, 34);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 5;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // dgvAnimalsList
            // 
            this.dgvAnimalsList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAnimalsList.Location = new System.Drawing.Point(6, 63);
            this.dgvAnimalsList.Name = "dgvAnimalsList";
            this.dgvAnimalsList.Size = new System.Drawing.Size(546, 209);
            this.dgvAnimalsList.TabIndex = 0;
            this.dgvAnimalsList.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAnimalsList_CellEndEdit);
            // 
            // btnStartGuess
            // 
            this.btnStartGuess.Location = new System.Drawing.Point(160, 278);
            this.btnStartGuess.Name = "btnStartGuess";
            this.btnStartGuess.Size = new System.Drawing.Size(392, 23);
            this.btnStartGuess.TabIndex = 1;
            this.btnStartGuess.Text = "Let us Guess the Animal you have think about ->";
            this.btnStartGuess.UseVisualStyleBackColor = true;
            this.btnStartGuess.Click += new System.EventHandler(this.btnStartGuess_Click);
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new System.Drawing.Point(6, 47);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(209, 13);
            this.lblInfo.TabIndex = 2;
            this.lblInfo.Text = "Please think of one animal in the list below:";
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "NewDataSet";
            // 
            // GuessTheAnimal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(811, 384);
            this.Controls.Add(this.tabList);
            this.Name = "GuessTheAnimal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Guess The Animal";
            this.Load += new System.EventHandler(this.GuessTheAnimal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabQuestions.ResumeLayout(false);
            this.tabQuestions.PerformLayout();
            this.tabList.ResumeLayout(false);
            this.tabAnimalsList.ResumeLayout(false);
            this.tabAnimalsList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAnimalsList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblAnimal;
        private System.Windows.Forms.Button btnAnimalFullFeatures;
        private System.Windows.Forms.ComboBox cmbAnimalColor;
        private System.Windows.Forms.TabPage tabQuestions;
        private System.Windows.Forms.ComboBox cmbAnimalHasTail;
        private System.Windows.Forms.ComboBox cmbAnimalWaySpeaks;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabList;
        private System.Windows.Forms.TabPage tabAnimalsList;
        private System.Windows.Forms.DataGridView dgvAnimalsList;
        private System.Windows.Forms.Button btnStartGuess;
        private System.Windows.Forms.Label lblInfo;
        private System.Data.DataSet dataSet1;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnGoBack;
    }
}

