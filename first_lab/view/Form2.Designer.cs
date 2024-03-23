namespace first_lab
{
    partial class Form2
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
            this.buttonApplyFilter = new System.Windows.Forms.Button();
            this.textBoxDestination = new System.Windows.Forms.TextBox();
            this.dateTimePickerFilterDate = new System.Windows.Forms.DateTimePicker();
            this.name = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonReset = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonApplyFilter
            // 
            this.buttonApplyFilter.Font = new System.Drawing.Font("Bloom", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonApplyFilter.ForeColor = System.Drawing.Color.SkyBlue;
            this.buttonApplyFilter.Location = new System.Drawing.Point(89, 278);
            this.buttonApplyFilter.Name = "buttonApplyFilter";
            this.buttonApplyFilter.Size = new System.Drawing.Size(107, 29);
            this.buttonApplyFilter.TabIndex = 24;
            this.buttonApplyFilter.Text = "Apply";
            this.buttonApplyFilter.UseVisualStyleBackColor = true;
            this.buttonApplyFilter.Click += new System.EventHandler(this.buttonApplyFilter_Click_1);
            // 
            // textBoxDestination
            // 
            this.textBoxDestination.Location = new System.Drawing.Point(45, 79);
            this.textBoxDestination.Name = "textBoxDestination";
            this.textBoxDestination.Size = new System.Drawing.Size(213, 27);
            this.textBoxDestination.TabIndex = 25;
            // 
            // dateTimePickerFilterDate
            // 
            this.dateTimePickerFilterDate.CustomFormat = "dd/MM/yyyy";
            this.dateTimePickerFilterDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerFilterDate.Location = new System.Drawing.Point(45, 174);
            this.dateTimePickerFilterDate.Name = "dateTimePickerFilterDate";
            this.dateTimePickerFilterDate.Size = new System.Drawing.Size(216, 27);
            this.dateTimePickerFilterDate.TabIndex = 26;
            this.dateTimePickerFilterDate.Value = new System.DateTime(2023, 10, 2, 0, 0, 0, 0);
            // 
            // name
            // 
            this.name.AutoSize = true;
            this.name.Font = new System.Drawing.Font("Bloom", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.name.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.name.Location = new System.Drawing.Point(11, 39);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(250, 37);
            this.name.TabIndex = 27;
            this.name.Text = "Destination";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Bloom", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(12, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 37);
            this.label3.TabIndex = 28;
            this.label3.Text = "Date";
            // 
            // buttonReset
            // 
            this.buttonReset.Font = new System.Drawing.Font("Bloom", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonReset.ForeColor = System.Drawing.Color.SkyBlue;
            this.buttonReset.Location = new System.Drawing.Point(89, 313);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(107, 29);
            this.buttonReset.TabIndex = 29;
            this.buttonReset.Text = "Reset";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Aquamarine;
            this.ClientSize = new System.Drawing.Size(298, 365);
            this.Controls.Add(this.buttonReset);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.name);
            this.Controls.Add(this.dateTimePickerFilterDate);
            this.Controls.Add(this.textBoxDestination);
            this.Controls.Add(this.buttonApplyFilter);
            this.Name = "Form2";
            this.Text = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Button buttonApplyFilter;
        private DateTimePicker dateTimePickerFilterDate;
        private TextBox textBoxDestination;
        private Label name;
        private Label label3;
        private Button buttonReset;
    }
}