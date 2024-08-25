namespace DynamicButtons
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGridSensor = new DataGridView();
            flowpanelSensor = new FlowLayoutPanel();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            txtSensorName = new TextBox();
            txtSensorType = new TextBox();
            lblID = new Label();
            btnSave = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridSensor).BeginInit();
            SuspendLayout();
            // 
            // dataGridSensor
            // 
            dataGridSensor.AllowUserToAddRows = false;
            dataGridSensor.AllowUserToDeleteRows = false;
            dataGridSensor.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridSensor.Location = new Point(12, 241);
            dataGridSensor.Name = "dataGridSensor";
            dataGridSensor.ReadOnly = true;
            dataGridSensor.Size = new Size(386, 197);
            dataGridSensor.TabIndex = 6;
            dataGridSensor.CellClick += dataGridSensor_CellClick;
            // 
            // flowpanelSensor
            // 
            flowpanelSensor.BorderStyle = BorderStyle.FixedSingle;
            flowpanelSensor.Location = new Point(12, 32);
            flowpanelSensor.Name = "flowpanelSensor";
            flowpanelSensor.Size = new Size(386, 165);
            flowpanelSensor.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            label1.Location = new Point(12, 14);
            label1.Name = "label1";
            label1.Size = new Size(188, 17);
            label1.TabIndex = 2;
            label1.Text = "Available sensors as buttons:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            label2.Location = new Point(12, 223);
            label2.Name = "label2";
            label2.Size = new Size(168, 17);
            label2.TabIndex = 2;
            label2.Text = "Sensors as data grid view:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(427, 107);
            label3.Name = "label3";
            label3.Size = new Size(29, 20);
            label3.TabIndex = 2;
            label3.Text = "ID:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(427, 150);
            label4.Name = "label4";
            label4.Size = new Size(103, 20);
            label4.TabIndex = 2;
            label4.Text = "Sensor name:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(427, 218);
            label5.Name = "label5";
            label5.Size = new Size(95, 20);
            label5.TabIndex = 2;
            label5.Text = "Sensor type:";
            // 
            // txtSensorName
            // 
            txtSensorName.Location = new Point(430, 173);
            txtSensorName.Multiline = true;
            txtSensorName.Name = "txtSensorName";
            txtSensorName.Size = new Size(242, 32);
            txtSensorName.TabIndex = 0;
            // 
            // txtSensorType
            // 
            txtSensorType.Location = new Point(430, 241);
            txtSensorType.Multiline = true;
            txtSensorType.Name = "txtSensorType";
            txtSensorType.Size = new Size(242, 32);
            txtSensorType.TabIndex = 1;
            // 
            // lblID
            // 
            lblID.AutoSize = true;
            lblID.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblID.Location = new Point(462, 107);
            lblID.Name = "lblID";
            lblID.Size = new Size(17, 20);
            lblID.TabIndex = 2;
            lblID.Text = "0";
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(128, 255, 128);
            btnSave.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnSave.Location = new Point(430, 305);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(78, 42);
            btnSave.TabIndex = 2;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.FromArgb(255, 192, 128);
            btnUpdate.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnUpdate.Location = new Point(512, 305);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(78, 42);
            btnUpdate.TabIndex = 3;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(255, 128, 128);
            btnDelete.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnDelete.Location = new Point(594, 305);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(78, 42);
            btnDelete.TabIndex = 4;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(696, 450);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnSave);
            Controls.Add(txtSensorType);
            Controls.Add(txtSensorName);
            Controls.Add(label2);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(lblID);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(flowpanelSensor);
            Controls.Add(dataGridSensor);
            Name = "Form1";
            Text = " ";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridSensor).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridSensor;
        private FlowLayoutPanel flowpanelSensor;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox txtSensorName;
        private TextBox txtSensorType;
        private Label lblID;
        private Button btnSave;
        private Button btnUpdate;
        private Button btnDelete;
    }
}
