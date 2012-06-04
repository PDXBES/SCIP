namespace UI
{
    partial class FormManageAlternatives
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
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("ALTERNATIVES", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("alternative_id");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("name");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("description");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("asset_set_id");
            this.ultraGridAlternatives = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.sCIPDataSet = new UI.SCIPDataSet();
            this.aLTERNATIVESBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.aLTERNATIVESTableAdapter = new UI.SCIPDataSetTableAdapters.ALTERNATIVESTableAdapter();
            this.ultraButtonSaveChanges = new Infragistics.Win.Misc.UltraButton();
            this.ultraButtonDiscardChanges = new Infragistics.Win.Misc.UltraButton();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGridAlternatives)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sCIPDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aLTERNATIVESBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // ultraGridAlternatives
            // 
            this.ultraGridAlternatives.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ultraGridAlternatives.DataSource = this.aLTERNATIVESBindingSource;
            this.ultraGridAlternatives.DisplayLayout.AddNewBox.Hidden = false;
            ultraGridColumn1.CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridColumn2.Header.VisiblePosition = 1;
            ultraGridColumn3.Header.VisiblePosition = 2;
            ultraGridColumn4.Header.VisiblePosition = 3;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2,
            ultraGridColumn3,
            ultraGridColumn4});
            this.ultraGridAlternatives.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.ultraGridAlternatives.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraGridAlternatives.Location = new System.Drawing.Point(12, 73);
            this.ultraGridAlternatives.Name = "ultraGridAlternatives";
            this.ultraGridAlternatives.Size = new System.Drawing.Size(635, 143);
            this.ultraGridAlternatives.TabIndex = 0;
            this.ultraGridAlternatives.Text = "Alternatives";
            // 
            // sCIPDataSet
            // 
            this.sCIPDataSet.DataSetName = "SCIPDataSet";
            this.sCIPDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // aLTERNATIVESBindingSource
            // 
            this.aLTERNATIVESBindingSource.DataMember = "ALTERNATIVES";
            this.aLTERNATIVESBindingSource.DataSource = this.sCIPDataSet;
            // 
            // aLTERNATIVESTableAdapter
            // 
            this.aLTERNATIVESTableAdapter.ClearBeforeFill = true;
            // 
            // ultraButtonSaveChanges
            // 
            this.ultraButtonSaveChanges.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ultraButtonSaveChanges.Location = new System.Drawing.Point(537, 231);
            this.ultraButtonSaveChanges.Name = "ultraButtonSaveChanges";
            this.ultraButtonSaveChanges.Size = new System.Drawing.Size(109, 23);
            this.ultraButtonSaveChanges.TabIndex = 1;
            this.ultraButtonSaveChanges.Text = "Save Changes";
            this.ultraButtonSaveChanges.Click += new System.EventHandler(this.ultraButtonSaveChanges_Click);
            // 
            // ultraButtonDiscardChanges
            // 
            this.ultraButtonDiscardChanges.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ultraButtonDiscardChanges.Location = new System.Drawing.Point(422, 231);
            this.ultraButtonDiscardChanges.Name = "ultraButtonDiscardChanges";
            this.ultraButtonDiscardChanges.Size = new System.Drawing.Size(109, 23);
            this.ultraButtonDiscardChanges.TabIndex = 2;
            this.ultraButtonDiscardChanges.Text = "Discard Changes";
            this.ultraButtonDiscardChanges.Click += new System.EventHandler(this.ultraButtonDiscardChanges_Click);
            // 
            // FormManageAlternatives
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 266);
            this.Controls.Add(this.ultraButtonDiscardChanges);
            this.Controls.Add(this.ultraButtonSaveChanges);
            this.Controls.Add(this.ultraGridAlternatives);
            this.Name = "FormManageAlternatives";
            this.Text = "Manage Alternatives";
            this.Load += new System.EventHandler(this.FormManageAlternatives_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGridAlternatives)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sCIPDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aLTERNATIVESBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.UltraWinGrid.UltraGrid ultraGridAlternatives;
        private SCIPDataSet sCIPDataSet;
        private System.Windows.Forms.BindingSource aLTERNATIVESBindingSource;
        private SCIPDataSetTableAdapters.ALTERNATIVESTableAdapter aLTERNATIVESTableAdapter;
        private Infragistics.Win.Misc.UltraButton ultraButtonSaveChanges;
        private Infragistics.Win.Misc.UltraButton ultraButtonDiscardChanges;
    }
}