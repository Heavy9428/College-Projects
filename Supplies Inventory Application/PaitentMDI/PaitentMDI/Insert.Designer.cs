namespace PaitentMDI
{
    partial class Insert
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Qty_Hand_Text = new System.Windows.Forms.TextBox();
            this.QTY_Required_Text = new System.Windows.Forms.TextBox();
            this.Item_Name_Text = new System.Windows.Forms.TextBox();
            this.Item_ID_Text = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Cancel_Button = new System.Windows.Forms.Button();
            this.Insert_OK = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Qty_Hand_Text);
            this.groupBox1.Controls.Add(this.QTY_Required_Text);
            this.groupBox1.Controls.Add(this.Item_Name_Text);
            this.groupBox1.Controls.Add(this.Item_ID_Text);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(631, 179);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Item Details";
            // 
            // Qty_Hand_Text
            // 
            this.Qty_Hand_Text.Location = new System.Drawing.Point(189, 126);
            this.Qty_Hand_Text.Name = "Qty_Hand_Text";
            this.Qty_Hand_Text.Size = new System.Drawing.Size(100, 22);
            this.Qty_Hand_Text.TabIndex = 7;
            // 
            // QTY_Required_Text
            // 
            this.QTY_Required_Text.Location = new System.Drawing.Point(189, 98);
            this.QTY_Required_Text.Name = "QTY_Required_Text";
            this.QTY_Required_Text.Size = new System.Drawing.Size(100, 22);
            this.QTY_Required_Text.TabIndex = 6;
            // 
            // Item_Name_Text
            // 
            this.Item_Name_Text.Location = new System.Drawing.Point(189, 70);
            this.Item_Name_Text.Name = "Item_Name_Text";
            this.Item_Name_Text.Size = new System.Drawing.Size(327, 22);
            this.Item_Name_Text.TabIndex = 5;
            // 
            // Item_ID_Text
            // 
            this.Item_ID_Text.Location = new System.Drawing.Point(189, 39);
            this.Item_ID_Text.Name = "Item_ID_Text";
            this.Item_ID_Text.Size = new System.Drawing.Size(100, 22);
            this.Item_ID_Text.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 126);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Qty on hand";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Qty Required";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Item Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Item ID";
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.Location = new System.Drawing.Point(348, 222);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(110, 43);
            this.Cancel_Button.TabIndex = 1;
            this.Cancel_Button.Text = "Cancel";
            this.Cancel_Button.UseVisualStyleBackColor = true;
            this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
            // 
            // Insert_OK
            // 
            this.Insert_OK.Location = new System.Drawing.Point(486, 222);
            this.Insert_OK.Name = "Insert_OK";
            this.Insert_OK.Size = new System.Drawing.Size(120, 43);
            this.Insert_OK.TabIndex = 2;
            this.Insert_OK.Text = "OK";
            this.Insert_OK.UseVisualStyleBackColor = true;
            this.Insert_OK.Click += new System.EventHandler(this.Insert_OK_Click);
            // 
            // Insert
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(655, 277);
            this.Controls.Add(this.Insert_OK);
            this.Controls.Add(this.Cancel_Button);
            this.Controls.Add(this.groupBox1);
            this.Name = "Insert";
            this.Text = "Add Supply Item Form";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox Qty_Hand_Text;
        private System.Windows.Forms.TextBox QTY_Required_Text;
        private System.Windows.Forms.TextBox Item_Name_Text;
        private System.Windows.Forms.TextBox Item_ID_Text;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Cancel_Button;
        private System.Windows.Forms.Button Insert_OK;
    }
}