namespace PaitentMDI
{
    partial class Child_Form
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
            this.Records_For_Patients = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Practice_Name = new System.Windows.Forms.Label();
            this.Item_Information = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Records_For_Patients
            // 
            this.Records_For_Patients.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.Records_For_Patients.FormattingEnabled = true;
            this.Records_For_Patients.ItemHeight = 22;
            this.Records_For_Patients.Location = new System.Drawing.Point(12, 161);
            this.Records_For_Patients.Name = "Records_For_Patients";
            this.Records_For_Patients.Size = new System.Drawing.Size(1081, 268);
            this.Records_For_Patients.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 20F);
            this.label1.Location = new System.Drawing.Point(152, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(427, 39);
            this.label1.TabIndex = 1;
            this.label1.Text = "Below are supply item details.";
            // 
            // Practice_Name
            // 
            this.Practice_Name.AutoSize = true;
            this.Practice_Name.Font = new System.Drawing.Font("Times New Roman", 20F);
            this.Practice_Name.Location = new System.Drawing.Point(152, 59);
            this.Practice_Name.Name = "Practice_Name";
            this.Practice_Name.Size = new System.Drawing.Size(204, 39);
            this.Practice_Name.TabIndex = 2;
            this.Practice_Name.Text = "pracitce name";
            // 
            // Item_Information
            // 
            this.Item_Information.AutoSize = true;
            this.Item_Information.Font = new System.Drawing.Font("Times New Roman", 20F);
            this.Item_Information.Location = new System.Drawing.Point(156, 119);
            this.Item_Information.Name = "Item_Information";
            this.Item_Information.Size = new System.Drawing.Size(243, 39);
            this.Item_Information.TabIndex = 3;
            this.Item_Information.Text = "Item information";
            // 
            // Child_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1096, 442);
            this.Controls.Add(this.Item_Information);
            this.Controls.Add(this.Practice_Name);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Records_For_Patients);
            this.Name = "Child_Form";
            this.Text = "child Form";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox Records_For_Patients;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Practice_Name;
        private System.Windows.Forms.Label Item_Information;
    }
}