namespace dotNETFinal
{
    partial class NewProperty
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
            addressBox = new TextBox();
            cityBox = new TextBox();
            zipBox = new TextBox();
            priceBox = new TextBox();
            bathroomNumber = new NumericUpDown();
            bedroomNumber = new NumericUpDown();
            descriptionBox = new TextBox();
            dateBox = new DateTimePicker();
            stateBox = new ComboBox();
            newButton = new Button();
            typeBox = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)bathroomNumber).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bedroomNumber).BeginInit();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // addressBox
            // 
            addressBox.Location = new Point(12, 12);
            addressBox.Name = "addressBox";
            addressBox.PlaceholderText = "Address (ex: 123 Example Street NW)";
            addressBox.Size = new Size(233, 23);
            addressBox.TabIndex = 0;
            // 
            // cityBox
            // 
            cityBox.Location = new Point(12, 41);
            cityBox.Name = "cityBox";
            cityBox.PlaceholderText = "City";
            cityBox.Size = new Size(100, 23);
            cityBox.TabIndex = 1;
            // 
            // zipBox
            // 
            zipBox.Location = new Point(12, 70);
            zipBox.MaxLength = 5;
            zipBox.Name = "zipBox";
            zipBox.PlaceholderText = "Zip Code";
            zipBox.Size = new Size(74, 23);
            zipBox.TabIndex = 3;
            // 
            // priceBox
            // 
            priceBox.Location = new Point(92, 70);
            priceBox.Name = "priceBox";
            priceBox.PlaceholderText = "Price (ex: 100000.00)";
            priceBox.Size = new Size(153, 23);
            priceBox.TabIndex = 4;
            // 
            // bathroomNumber
            // 
            bathroomNumber.Location = new Point(130, 172);
            bathroomNumber.Name = "bathroomNumber";
            bathroomNumber.Size = new Size(115, 23);
            bathroomNumber.TabIndex = 9;
            // 
            // bedroomNumber
            // 
            bedroomNumber.Location = new Point(12, 172);
            bedroomNumber.Name = "bedroomNumber";
            bedroomNumber.Size = new Size(112, 23);
            bedroomNumber.TabIndex = 8;
            // 
            // descriptionBox
            // 
            descriptionBox.Location = new Point(12, 128);
            descriptionBox.Name = "descriptionBox";
            descriptionBox.PlaceholderText = "Description";
            descriptionBox.Size = new Size(233, 23);
            descriptionBox.TabIndex = 7;
            // 
            // dateBox
            // 
            dateBox.Location = new Point(106, 99);
            dateBox.Name = "dateBox";
            dateBox.Size = new Size(139, 23);
            dateBox.TabIndex = 6;
            // 
            // stateBox
            // 
            stateBox.FormattingEnabled = true;
            stateBox.Items.AddRange(new object[] { "Alabama", "Alaska", "Arizona", "Arkansas", "California", "Colorado", "Connecticut", "Delaware", "Florida", "Georgia", "Hawaii", "Idaho", "Illinois", "Indiana", "Iowa", "Kansas", "Kentucky", "Louisiana", "Maine", "Maryland", "Massachusetts", "Michigan", "Minnesota", "Mississippi", "Missouri", "Montana", "Nebraska", "Nevada", "New Hampshire", "New Jersey", "New Mexico", "New York", "North Carolina", "North Dakota", "Ohio", "Oklahoma", "Oregon", "Pennsylvania", "Rhode Island", "South Carolina", "South Dakota", "Tennessee", "Texas", "Utah", "Vermont", "Virginia", "Washington", "West Virginia", "Wisconsin", "Wyoming" });
            stateBox.Location = new Point(118, 41);
            stateBox.Name = "stateBox";
            stateBox.Size = new Size(127, 23);
            stateBox.TabIndex = 2;
            stateBox.Text = "State";
            // 
            // newButton
            // 
            newButton.Location = new Point(12, 201);
            newButton.Name = "newButton";
            newButton.Size = new Size(233, 46);
            newButton.TabIndex = 10;
            newButton.Text = "New Entry";
            newButton.UseVisualStyleBackColor = true;
            newButton.Click += newButton_Click;
            // 
            // typeBox
            // 
            typeBox.FormattingEnabled = true;
            typeBox.Items.AddRange(new object[] { "Residential", "Commercial" });
            typeBox.Location = new Point(12, 99);
            typeBox.Name = "typeBox";
            typeBox.Size = new Size(88, 23);
            typeBox.TabIndex = 5;
            typeBox.Text = "Type";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 154);
            label1.Name = "label1";
            label1.Size = new Size(64, 15);
            label1.TabIndex = 13;
            label1.Text = "Bedrooms:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(130, 154);
            label2.Name = "label2";
            label2.Size = new Size(68, 15);
            label2.TabIndex = 14;
            label2.Text = "Bathrooms:";
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1 });
            statusStrip1.Location = new Point(0, 257);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(256, 22);
            statusStrip1.SizingGrip = false;
            statusStrip1.TabIndex = 15;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(118, 17);
            toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // NewProperty
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(256, 279);
            Controls.Add(statusStrip1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(typeBox);
            Controls.Add(newButton);
            Controls.Add(stateBox);
            Controls.Add(dateBox);
            Controls.Add(descriptionBox);
            Controls.Add(bedroomNumber);
            Controls.Add(bathroomNumber);
            Controls.Add(priceBox);
            Controls.Add(zipBox);
            Controls.Add(cityBox);
            Controls.Add(addressBox);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "NewProperty";
            SizeGripStyle = SizeGripStyle.Hide;
            Text = "New Entry";
            Load += NewProperty_Load;
            ((System.ComponentModel.ISupportInitialize)bathroomNumber).EndInit();
            ((System.ComponentModel.ISupportInitialize)bedroomNumber).EndInit();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox addressBox;
        private TextBox cityBox;
        private TextBox zipBox;
        private TextBox priceBox;
        private NumericUpDown bathroomNumber;
        private NumericUpDown bedroomNumber;
        private TextBox descriptionBox;
        private DateTimePicker dateBox;
        private ComboBox stateBox;
        private Button newButton;
        private ComboBox typeBox;
        private Label label1;
        private Label label2;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
    }
}