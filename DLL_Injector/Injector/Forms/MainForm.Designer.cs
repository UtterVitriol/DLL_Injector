namespace Injector
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            processDataGridView = new DataGridView();
            label1 = new Label();
            filterTextBox = new TextBox();
            injectButton = new Button();
            dllButton = new Button();
            dllPathTextBox = new TextBox();
            button1 = new Button();
            groupBox1 = new GroupBox();
            label2 = new Label();
            processColumn = new DataGridViewTextBoxColumn();
            pidColumn = new DataGridViewTextBoxColumn();
            pathColumn = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)processDataGridView).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // processDataGridView
            // 
            processDataGridView.AllowUserToAddRows = false;
            processDataGridView.AllowUserToDeleteRows = false;
            processDataGridView.AllowUserToResizeColumns = false;
            processDataGridView.AllowUserToResizeRows = false;
            processDataGridView.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            processDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            processDataGridView.Columns.AddRange(new DataGridViewColumn[] { processColumn, pidColumn, pathColumn });
            processDataGridView.Location = new Point(12, 260);
            processDataGridView.MultiSelect = false;
            processDataGridView.Name = "processDataGridView";
            processDataGridView.ReadOnly = true;
            processDataGridView.RowHeadersVisible = false;
            processDataGridView.RowHeadersWidth = 62;
            processDataGridView.RowTemplate.Height = 33;
            processDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            processDataGridView.Size = new Size(1119, 473);
            processDataGridView.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(14, 41);
            label1.Name = "label1";
            label1.Size = new Size(128, 25);
            label1.TabIndex = 1;
            label1.Text = "Process Name:";
            // 
            // filterTextBox
            // 
            filterTextBox.Location = new Point(148, 41);
            filterTextBox.Name = "filterTextBox";
            filterTextBox.Size = new Size(409, 31);
            filterTextBox.TabIndex = 2;
            filterTextBox.TextChanged += filterTextBox_TextChanged;
            // 
            // injectButton
            // 
            injectButton.Location = new Point(12, 739);
            injectButton.Name = "injectButton";
            injectButton.Size = new Size(1119, 87);
            injectButton.TabIndex = 3;
            injectButton.Text = "Inject";
            injectButton.UseVisualStyleBackColor = true;
            injectButton.Click += injectButton_Click;
            // 
            // dllButton
            // 
            dllButton.Location = new Point(12, 32);
            dllButton.Name = "dllButton";
            dllButton.Size = new Size(1119, 88);
            dllButton.TabIndex = 4;
            dllButton.Text = "Select DLL";
            dllButton.UseVisualStyleBackColor = true;
            dllButton.Click += dllButton_Click;
            // 
            // dllPathTextBox
            // 
            dllPathTextBox.Location = new Point(160, 126);
            dllPathTextBox.Name = "dllPathTextBox";
            dllPathTextBox.Size = new Size(971, 31);
            dllPathTextBox.TabIndex = 5;
            // 
            // button1
            // 
            button1.Location = new Point(786, 36);
            button1.Name = "button1";
            button1.Size = new Size(188, 34);
            button1.TabIndex = 7;
            button1.Text = "Refresh";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(button1);
            groupBox1.Controls.Add(filterTextBox);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(12, 163);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1119, 91);
            groupBox1.TabIndex = 8;
            groupBox1.TabStop = false;
            groupBox1.Text = "Filter";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(26, 129);
            label2.Name = "label2";
            label2.Size = new Size(116, 25);
            label2.TabIndex = 8;
            label2.Text = "Selected DLL:";
            // 
            // processColumn
            // 
            processColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            processColumn.DataPropertyName = "process";
            processColumn.HeaderText = "Process";
            processColumn.MinimumWidth = 8;
            processColumn.Name = "processColumn";
            processColumn.ReadOnly = true;
            processColumn.Width = 108;
            // 
            // pidColumn
            // 
            pidColumn.DataPropertyName = "pid";
            pidColumn.HeaderText = "PID";
            pidColumn.MinimumWidth = 8;
            pidColumn.Name = "pidColumn";
            pidColumn.ReadOnly = true;
            pidColumn.Width = 150;
            // 
            // pathColumn
            // 
            pathColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            pathColumn.DataPropertyName = "path";
            pathColumn.HeaderText = "Path";
            pathColumn.MinimumWidth = 8;
            pathColumn.Name = "pathColumn";
            pathColumn.ReadOnly = true;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImageLayout = ImageLayout.Zoom;
            ClientSize = new Size(1143, 838);
            Controls.Add(label2);
            Controls.Add(dllPathTextBox);
            Controls.Add(dllButton);
            Controls.Add(injectButton);
            Controls.Add(processDataGridView);
            Controls.Add(groupBox1);
            DoubleBuffered = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MainForm";
            Text = "Basic Injector";
            ((System.ComponentModel.ISupportInitialize)processDataGridView).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView processDataGridView;
        private Label label1;
        private TextBox filterTextBox;
        private Button injectButton;
        private Button dllButton;
        private TextBox dllPathTextBox;
        private Button button1;
        private GroupBox groupBox1;
        private Label label2;
        private DataGridViewTextBoxColumn processColumn;
        private DataGridViewTextBoxColumn pidColumn;
        private DataGridViewTextBoxColumn pathColumn;
    }
}