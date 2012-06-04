namespace UI
{
    partial class IndividualDriversPage
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
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("DRIVERS_UPDATE", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("driver_id");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("driver_type_id");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("compkey");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("override_cost_per_ft");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("override_frequency_years");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("alternative_id");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn7 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("updated_by");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn8 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("update_date");
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand2 = new Infragistics.Win.UltraWinGrid.UltraGridBand("ALTERNATIVES", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn13 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("alternative_id");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn14 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("name");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn15 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("description");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn16 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("asset_set_id");
            this.LabelCompkey = new Infragistics.Win.Misc.UltraLabel();
            this.TextEditorCompkey = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.labelDriversForThisCompkey = new Infragistics.Win.Misc.UltraLabel();
            this.ultraGrid1 = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.dRIVERSUPDATEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sCIPDataSet = new UI.SCIPDataSet();
            this.buttonFetchCompkey = new Infragistics.Win.Misc.UltraButton();
            this.buttonUpdateDrivers = new Infragistics.Win.Misc.UltraButton();
            this.buttonRevertDrivers = new Infragistics.Win.Misc.UltraButton();
            this.dRIVERS_UPDATETableAdapter = new UI.SCIPDataSetTableAdapters.DRIVERS_UPDATETableAdapter();
            this.aLTERNATIVESBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.aLTERNATIVESTableAdapter = new UI.SCIPDataSetTableAdapters.ALTERNATIVESTableAdapter();
            this.ultraComboAlternatives = new Infragistics.Win.UltraWinGrid.UltraCombo();
            this.aLTERNATIVESBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.TextEditorCompkey)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dRIVERSUPDATEBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sCIPDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aLTERNATIVESBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraComboAlternatives)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aLTERNATIVESBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // LabelCompkey
            // 
            this.LabelCompkey.Location = new System.Drawing.Point(293, 46);
            this.LabelCompkey.Name = "LabelCompkey";
            this.LabelCompkey.Size = new System.Drawing.Size(90, 19);
            this.LabelCompkey.TabIndex = 0;
            this.LabelCompkey.Text = "Fetch Compkey:";
            // 
            // TextEditorCompkey
            // 
            this.TextEditorCompkey.Location = new System.Drawing.Point(389, 42);
            this.TextEditorCompkey.Name = "TextEditorCompkey";
            this.TextEditorCompkey.Size = new System.Drawing.Size(100, 21);
            this.TextEditorCompkey.TabIndex = 1;
            this.TextEditorCompkey.Text = "COMPKEY";
            // 
            // labelDriversForThisCompkey
            // 
            this.labelDriversForThisCompkey.Location = new System.Drawing.Point(41, 65);
            this.labelDriversForThisCompkey.Name = "labelDriversForThisCompkey";
            this.labelDriversForThisCompkey.Size = new System.Drawing.Size(164, 19);
            this.labelDriversForThisCompkey.TabIndex = 5;
            this.labelDriversForThisCompkey.Text = "Drivers for this Compkey:";
            // 
            // ultraGrid1
            // 
            this.ultraGrid1.DataSource = this.dRIVERSUPDATEBindingSource;
            appearance1.BackColor = System.Drawing.SystemColors.Window;
            appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.ultraGrid1.DisplayLayout.Appearance = appearance1;
            ultraGridColumn1.CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridColumn1.Hidden = true;
            ultraGridColumn2.CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
            ultraGridColumn2.Header.VisiblePosition = 1;
            ultraGridColumn3.CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
            ultraGridColumn3.Header.VisiblePosition = 2;
            ultraGridColumn4.Header.VisiblePosition = 3;
            ultraGridColumn5.Header.VisiblePosition = 4;
            ultraGridColumn6.CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
            ultraGridColumn6.Header.VisiblePosition = 5;
            ultraGridColumn7.CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
            ultraGridColumn7.Header.VisiblePosition = 6;
            ultraGridColumn8.CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
            ultraGridColumn8.Header.VisiblePosition = 7;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2,
            ultraGridColumn3,
            ultraGridColumn4,
            ultraGridColumn5,
            ultraGridColumn6,
            ultraGridColumn7,
            ultraGridColumn8});
            this.ultraGrid1.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.ultraGrid1.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ultraGrid1.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance2.BorderColor = System.Drawing.SystemColors.Window;
            this.ultraGrid1.DisplayLayout.GroupByBox.Appearance = appearance2;
            appearance3.ForeColor = System.Drawing.SystemColors.GrayText;
            this.ultraGrid1.DisplayLayout.GroupByBox.BandLabelAppearance = appearance3;
            this.ultraGrid1.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance4.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance4.BackColor2 = System.Drawing.SystemColors.Control;
            appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance4.ForeColor = System.Drawing.SystemColors.GrayText;
            this.ultraGrid1.DisplayLayout.GroupByBox.PromptAppearance = appearance4;
            this.ultraGrid1.DisplayLayout.MaxColScrollRegions = 1;
            this.ultraGrid1.DisplayLayout.MaxRowScrollRegions = 1;
            appearance5.BackColor = System.Drawing.SystemColors.Window;
            appearance5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ultraGrid1.DisplayLayout.Override.ActiveCellAppearance = appearance5;
            appearance6.BackColor = System.Drawing.SystemColors.Highlight;
            appearance6.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.ultraGrid1.DisplayLayout.Override.ActiveRowAppearance = appearance6;
            this.ultraGrid1.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.ultraGrid1.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance7.BackColor = System.Drawing.SystemColors.Window;
            this.ultraGrid1.DisplayLayout.Override.CardAreaAppearance = appearance7;
            appearance8.BorderColor = System.Drawing.Color.Silver;
            appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.ultraGrid1.DisplayLayout.Override.CellAppearance = appearance8;
            this.ultraGrid1.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.ultraGrid1.DisplayLayout.Override.CellPadding = 0;
            appearance9.BackColor = System.Drawing.SystemColors.Control;
            appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance9.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance9.BorderColor = System.Drawing.SystemColors.Window;
            this.ultraGrid1.DisplayLayout.Override.GroupByRowAppearance = appearance9;
            appearance10.TextHAlignAsString = "Left";
            this.ultraGrid1.DisplayLayout.Override.HeaderAppearance = appearance10;
            this.ultraGrid1.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.ultraGrid1.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance11.BackColor = System.Drawing.SystemColors.Window;
            appearance11.BorderColor = System.Drawing.Color.Silver;
            this.ultraGrid1.DisplayLayout.Override.RowAppearance = appearance11;
            this.ultraGrid1.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance12.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ultraGrid1.DisplayLayout.Override.TemplateAddRowAppearance = appearance12;
            this.ultraGrid1.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.ultraGrid1.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.ultraGrid1.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.ultraGrid1.Location = new System.Drawing.Point(41, 90);
            this.ultraGrid1.Name = "ultraGrid1";
            this.ultraGrid1.Size = new System.Drawing.Size(828, 171);
            this.ultraGrid1.TabIndex = 6;
            this.ultraGrid1.Text = "ultraGrid1";
            // 
            // dRIVERSUPDATEBindingSource
            // 
            this.dRIVERSUPDATEBindingSource.DataMember = "DRIVERS_UPDATE";
            this.dRIVERSUPDATEBindingSource.DataSource = this.sCIPDataSet;
            // 
            // sCIPDataSet
            // 
            this.sCIPDataSet.DataSetName = "SCIPDataSet";
            this.sCIPDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // buttonFetchCompkey
            // 
            this.buttonFetchCompkey.Location = new System.Drawing.Point(508, 41);
            this.buttonFetchCompkey.Name = "buttonFetchCompkey";
            this.buttonFetchCompkey.Size = new System.Drawing.Size(75, 23);
            this.buttonFetchCompkey.TabIndex = 8;
            this.buttonFetchCompkey.Text = "Fetch!";
            this.buttonFetchCompkey.Click += new System.EventHandler(this.buttonFetchCompkey_Click);
            // 
            // buttonUpdateDrivers
            // 
            this.buttonUpdateDrivers.Location = new System.Drawing.Point(781, 300);
            this.buttonUpdateDrivers.Name = "buttonUpdateDrivers";
            this.buttonUpdateDrivers.Size = new System.Drawing.Size(119, 35);
            this.buttonUpdateDrivers.TabIndex = 9;
            this.buttonUpdateDrivers.Text = "Update Drivers";
            this.buttonUpdateDrivers.Click += new System.EventHandler(this.buttonUpdateDrivers_Click);
            // 
            // buttonRevertDrivers
            // 
            this.buttonRevertDrivers.Location = new System.Drawing.Point(612, 300);
            this.buttonRevertDrivers.Name = "buttonRevertDrivers";
            this.buttonRevertDrivers.Size = new System.Drawing.Size(119, 35);
            this.buttonRevertDrivers.TabIndex = 10;
            this.buttonRevertDrivers.Text = "Revert Drivers";
            this.buttonRevertDrivers.Click += new System.EventHandler(this.buttonRevertDrivers_Click);
            // 
            // dRIVERS_UPDATETableAdapter
            // 
            this.dRIVERS_UPDATETableAdapter.ClearBeforeFill = true;
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
            // ultraComboAlternatives
            // 
            this.ultraComboAlternatives.DataSource = this.aLTERNATIVESBindingSource1;
            ultraGridColumn13.Header.VisiblePosition = 0;
            ultraGridColumn14.Header.VisiblePosition = 1;
            ultraGridColumn15.Header.VisiblePosition = 2;
            ultraGridColumn16.Header.VisiblePosition = 3;
            ultraGridBand2.Columns.AddRange(new object[] {
            ultraGridColumn13,
            ultraGridColumn14,
            ultraGridColumn15,
            ultraGridColumn16});
            this.ultraComboAlternatives.DisplayLayout.BandsSerializer.Add(ultraGridBand2);
            this.ultraComboAlternatives.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraComboAlternatives.Location = new System.Drawing.Point(389, 13);
            this.ultraComboAlternatives.Name = "ultraComboAlternatives";
            this.ultraComboAlternatives.Size = new System.Drawing.Size(100, 22);
            this.ultraComboAlternatives.TabIndex = 11;
            this.ultraComboAlternatives.Text = "Select Alternative";
            // 
            // aLTERNATIVESBindingSource1
            // 
            this.aLTERNATIVESBindingSource1.DataMember = "ALTERNATIVES";
            this.aLTERNATIVESBindingSource1.DataSource = this.sCIPDataSet;
            // 
            // FormIndividualDrivers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(912, 347);
            this.Controls.Add(this.ultraComboAlternatives);
            this.Controls.Add(this.buttonRevertDrivers);
            this.Controls.Add(this.buttonUpdateDrivers);
            this.Controls.Add(this.buttonFetchCompkey);
            this.Controls.Add(this.ultraGrid1);
            this.Controls.Add(this.labelDriversForThisCompkey);
            this.Controls.Add(this.TextEditorCompkey);
            this.Controls.Add(this.LabelCompkey);
            this.Name = "FormIndividualDrivers";
            this.Text = "Individual Drivers";
            this.Load += new System.EventHandler(this.FormIndividualDrivers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TextEditorCompkey)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dRIVERSUPDATEBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sCIPDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aLTERNATIVESBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraComboAlternatives)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aLTERNATIVESBindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Infragistics.Win.Misc.UltraLabel LabelCompkey;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor TextEditorCompkey;
        private Infragistics.Win.Misc.UltraLabel labelDriversForThisCompkey;
        private Infragistics.Win.UltraWinGrid.UltraGrid ultraGrid1;
        private SCIPDataSet sCIPDataSet;
        private System.Windows.Forms.BindingSource dRIVERSUPDATEBindingSource;
        private SCIPDataSetTableAdapters.DRIVERS_UPDATETableAdapter dRIVERS_UPDATETableAdapter;
        private SCIPDataSetTableAdapters.DRIVERSTableAdapter dRIVERSTableAdapter;
        private Infragistics.Win.Misc.UltraButton buttonFetchCompkey;
        private Infragistics.Win.Misc.UltraButton buttonUpdateDrivers;
        private Infragistics.Win.Misc.UltraButton buttonRevertDrivers;
        private System.Windows.Forms.BindingSource aLTERNATIVESBindingSource;
        private SCIPDataSetTableAdapters.ALTERNATIVESTableAdapter aLTERNATIVESTableAdapter;
        private Infragistics.Win.UltraWinGrid.UltraCombo ultraComboAlternatives;
        private System.Windows.Forms.BindingSource aLTERNATIVESBindingSource1;
    }
}