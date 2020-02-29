namespace TypeOfPipeInsulatuion
{
    partial class Form1
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
            this.DiametersGridView = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TypesOfInsulationCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.OuterDiameterColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserInsulationDiameter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DiametersGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // DiametersGridView
            // 
            this.DiametersGridView.AllowUserToAddRows = false;
            this.DiametersGridView.AllowUserToDeleteRows = false;
            this.DiametersGridView.AllowUserToResizeRows = false;
            this.DiametersGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DiametersGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.OuterDiameterColumn,
            this.UserInsulationDiameter});
            this.DiametersGridView.Location = new System.Drawing.Point(227, 20);
            this.DiametersGridView.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.DiametersGridView.Name = "DiametersGridView";
            this.DiametersGridView.RowHeadersVisible = false;
            this.DiametersGridView.RowHeadersWidth = 51;
            this.DiametersGridView.RowTemplate.Height = 24;
            this.DiametersGridView.Size = new System.Drawing.Size(146, 154);
            this.DiametersGridView.TabIndex = 0;
            this.DiametersGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DiametersGridView_CellContentClick);
            this.DiametersGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DiametersGridView_CellValueChanged);
            this.DiametersGridView.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.DiametersGridView_EditingControlShowing);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(143, 178);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(93, 27);
            this.button1.TabIndex = 2;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 3);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Типы изоляции";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(224, 3);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Соотношения диаметров";
            // 
            // TypesOfInsulationCheckedListBox
            // 
            this.TypesOfInsulationCheckedListBox.FormattingEnabled = true;
            this.TypesOfInsulationCheckedListBox.Location = new System.Drawing.Point(9, 20);
            this.TypesOfInsulationCheckedListBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.TypesOfInsulationCheckedListBox.Name = "TypesOfInsulationCheckedListBox";
            this.TypesOfInsulationCheckedListBox.Size = new System.Drawing.Size(146, 154);
            this.TypesOfInsulationCheckedListBox.TabIndex = 5;
            this.TypesOfInsulationCheckedListBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.TypesOfInsulationChekedBox_ItemCheck);
            this.TypesOfInsulationCheckedListBox.SelectedIndexChanged += new System.EventHandler(this.TypesOfInsulationCheckedListBox_SelectedIndexChanged);
            // 
            // OuterDiameterColumn
            // 
            this.OuterDiameterColumn.HeaderText = "Внешний";
            this.OuterDiameterColumn.MinimumWidth = 6;
            this.OuterDiameterColumn.Name = "OuterDiameterColumn";
            this.OuterDiameterColumn.ReadOnly = true;
            this.OuterDiameterColumn.Width = 74;
            // 
            // UserInsulationDiameter
            // 
            this.UserInsulationDiameter.HeaderText = "Изоляции";
            this.UserInsulationDiameter.MinimumWidth = 6;
            this.UserInsulationDiameter.Name = "UserInsulationDiameter";
            this.UserInsulationDiameter.Width = 74;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(384, 216);
            this.Controls.Add(this.TypesOfInsulationCheckedListBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.DiametersGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Надстройка соотношения диаметров";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DiametersGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.DataGridView DiametersGridView;
        public System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.CheckedListBox TypesOfInsulationCheckedListBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn OuterDiameterColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserInsulationDiameter;
    }
}