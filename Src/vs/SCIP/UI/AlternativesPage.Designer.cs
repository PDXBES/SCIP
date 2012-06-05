namespace UI
{
    partial class AlternativesPage
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
      Infragistics.Win.Layout.GridBagConstraint gridBagConstraint4 = new Infragistics.Win.Layout.GridBagConstraint();
      Infragistics.Win.Layout.GridBagConstraint gridBagConstraint2 = new Infragistics.Win.Layout.GridBagConstraint();
      Infragistics.Win.Layout.GridBagConstraint gridBagConstraint1 = new Infragistics.Win.Layout.GridBagConstraint();
      Infragistics.Win.Layout.GridBagConstraint gridBagConstraint3 = new Infragistics.Win.Layout.GridBagConstraint();
      this.ultraGridAlternatives = new Infragistics.Win.UltraWinGrid.UltraGrid();
      this.aLTERNATIVESBindingSource = new System.Windows.Forms.BindingSource(this.components);
      this.sCIPDataSet = new UI.SCIPDataSet();
      this.aLTERNATIVESTableAdapter = new UI.SCIPDataSetTableAdapters.ALTERNATIVESTableAdapter();
      this.ultraButtonSaveChanges = new Infragistics.Win.Misc.UltraButton();
      this.ultraButtonDiscardChanges = new Infragistics.Win.Misc.UltraButton();
      this.ultraGridBagLayoutPanel1 = new Infragistics.Win.Misc.UltraGridBagLayoutPanel();
      this.ultraGridBagLayoutPanel2 = new Infragistics.Win.Misc.UltraGridBagLayoutPanel();
      ((System.ComponentModel.ISupportInitialize)(this.ultraGridAlternatives)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.aLTERNATIVESBindingSource)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.sCIPDataSet)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.ultraGridBagLayoutPanel1)).BeginInit();
      this.ultraGridBagLayoutPanel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.ultraGridBagLayoutPanel2)).BeginInit();
      this.ultraGridBagLayoutPanel2.SuspendLayout();
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
      gridBagConstraint4.Fill = Infragistics.Win.Layout.FillType.Both;
      gridBagConstraint4.Insets.Bottom = 8;
      gridBagConstraint4.OriginX = 0;
      gridBagConstraint4.OriginY = 0;
      gridBagConstraint4.WeightX = 1F;
      gridBagConstraint4.WeightY = 1F;
      this.ultraGridBagLayoutPanel1.SetGridBagConstraint(this.ultraGridAlternatives, gridBagConstraint4);
      this.ultraGridAlternatives.Location = new System.Drawing.Point(0, 0);
      this.ultraGridAlternatives.Name = "ultraGridAlternatives";
      this.ultraGridBagLayoutPanel1.SetPreferredSize(this.ultraGridAlternatives, new System.Drawing.Size(700, 143));
      this.ultraGridAlternatives.Size = new System.Drawing.Size(724, 397);
      this.ultraGridAlternatives.TabIndex = 0;
      this.ultraGridAlternatives.Text = "Alternatives";
      // 
      // aLTERNATIVESBindingSource
      // 
      this.aLTERNATIVESBindingSource.DataMember = "ALTERNATIVES";
      this.aLTERNATIVESBindingSource.DataSource = this.sCIPDataSet;
      // 
      // sCIPDataSet
      // 
      this.sCIPDataSet.DataSetName = "SCIPDataSet";
      this.sCIPDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
      // 
      // aLTERNATIVESTableAdapter
      // 
      this.aLTERNATIVESTableAdapter.ClearBeforeFill = true;
      // 
      // ultraButtonSaveChanges
      // 
      this.ultraButtonSaveChanges.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      gridBagConstraint2.Fill = Infragistics.Win.Layout.FillType.Both;
      gridBagConstraint2.OriginX = 1;
      gridBagConstraint2.OriginY = 0;
      this.ultraGridBagLayoutPanel2.SetGridBagConstraint(this.ultraButtonSaveChanges, gridBagConstraint2);
      this.ultraButtonSaveChanges.Location = new System.Drawing.Point(615, 0);
      this.ultraButtonSaveChanges.Name = "ultraButtonSaveChanges";
      this.ultraGridBagLayoutPanel2.SetPreferredSize(this.ultraButtonSaveChanges, new System.Drawing.Size(109, 23));
      this.ultraButtonSaveChanges.Size = new System.Drawing.Size(109, 23);
      this.ultraButtonSaveChanges.TabIndex = 1;
      this.ultraButtonSaveChanges.Text = "Save Changes";
      this.ultraButtonSaveChanges.Click += new System.EventHandler(this.ultraButtonSaveChanges_Click);
      // 
      // ultraButtonDiscardChanges
      // 
      this.ultraButtonDiscardChanges.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      gridBagConstraint1.Anchor = Infragistics.Win.Layout.AnchorType.Right;
      gridBagConstraint1.OriginX = 0;
      gridBagConstraint1.OriginY = 0;
      gridBagConstraint1.WeightX = 1F;
      this.ultraGridBagLayoutPanel2.SetGridBagConstraint(this.ultraButtonDiscardChanges, gridBagConstraint1);
      this.ultraButtonDiscardChanges.Location = new System.Drawing.Point(506, 0);
      this.ultraButtonDiscardChanges.Name = "ultraButtonDiscardChanges";
      this.ultraGridBagLayoutPanel2.SetPreferredSize(this.ultraButtonDiscardChanges, new System.Drawing.Size(109, 23));
      this.ultraButtonDiscardChanges.Size = new System.Drawing.Size(109, 23);
      this.ultraButtonDiscardChanges.TabIndex = 2;
      this.ultraButtonDiscardChanges.Text = "Discard Changes";
      this.ultraButtonDiscardChanges.Click += new System.EventHandler(this.ultraButtonDiscardChanges_Click);
      // 
      // ultraGridBagLayoutPanel1
      // 
      this.ultraGridBagLayoutPanel1.Controls.Add(this.ultraGridBagLayoutPanel2);
      this.ultraGridBagLayoutPanel1.Controls.Add(this.ultraGridAlternatives);
      this.ultraGridBagLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.ultraGridBagLayoutPanel1.Location = new System.Drawing.Point(0, 0);
      this.ultraGridBagLayoutPanel1.Name = "ultraGridBagLayoutPanel1";
      this.ultraGridBagLayoutPanel1.Size = new System.Drawing.Size(724, 428);
      this.ultraGridBagLayoutPanel1.TabIndex = 3;
      // 
      // ultraGridBagLayoutPanel2
      // 
      this.ultraGridBagLayoutPanel2.Controls.Add(this.ultraButtonDiscardChanges);
      this.ultraGridBagLayoutPanel2.Controls.Add(this.ultraButtonSaveChanges);
      gridBagConstraint3.Fill = Infragistics.Win.Layout.FillType.Both;
      gridBagConstraint3.OriginX = 0;
      gridBagConstraint3.OriginY = 1;
      this.ultraGridBagLayoutPanel1.SetGridBagConstraint(this.ultraGridBagLayoutPanel2, gridBagConstraint3);
      this.ultraGridBagLayoutPanel2.Location = new System.Drawing.Point(0, 405);
      this.ultraGridBagLayoutPanel2.Name = "ultraGridBagLayoutPanel2";
      this.ultraGridBagLayoutPanel1.SetPreferredSize(this.ultraGridBagLayoutPanel2, new System.Drawing.Size(200, 23));
      this.ultraGridBagLayoutPanel2.Size = new System.Drawing.Size(724, 23);
      this.ultraGridBagLayoutPanel2.TabIndex = 1;
      // 
      // AlternativesPage
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(724, 428);
      this.Controls.Add(this.ultraGridBagLayoutPanel1);
      this.Name = "AlternativesPage";
      this.Text = "Manage Alternatives";
      this.Load += new System.EventHandler(this.FormManageAlternatives_Load);
      ((System.ComponentModel.ISupportInitialize)(this.ultraGridAlternatives)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.aLTERNATIVESBindingSource)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.sCIPDataSet)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.ultraGridBagLayoutPanel1)).EndInit();
      this.ultraGridBagLayoutPanel1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.ultraGridBagLayoutPanel2)).EndInit();
      this.ultraGridBagLayoutPanel2.ResumeLayout(false);
      this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.UltraWinGrid.UltraGrid ultraGridAlternatives;
        private SCIPDataSet sCIPDataSet;
        private System.Windows.Forms.BindingSource aLTERNATIVESBindingSource;
        private SCIPDataSetTableAdapters.ALTERNATIVESTableAdapter aLTERNATIVESTableAdapter;
        private Infragistics.Win.Misc.UltraButton ultraButtonSaveChanges;
        private Infragistics.Win.Misc.UltraButton ultraButtonDiscardChanges;
        private Infragistics.Win.Misc.UltraGridBagLayoutPanel ultraGridBagLayoutPanel1;
        private Infragistics.Win.Misc.UltraGridBagLayoutPanel ultraGridBagLayoutPanel2;
    }
}