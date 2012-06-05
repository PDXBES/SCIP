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
      Infragistics.Win.Layout.GridBagConstraint gridBagConstraint10 = new Infragistics.Win.Layout.GridBagConstraint();
      Infragistics.Win.Layout.GridBagConstraint gridBagConstraint9 = new Infragistics.Win.Layout.GridBagConstraint();
      Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
      Infragistics.Win.Layout.GridBagConstraint gridBagConstraint8 = new Infragistics.Win.Layout.GridBagConstraint();
      Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
      Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand2 = new Infragistics.Win.UltraWinGrid.UltraGridBand("DRIVERS_UPDATE", -1);
      Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("driver_id");
      Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("driver_type_id");
      Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("compkey");
      Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("override_cost_per_ft");
      Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("override_frequency_years");
      Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("alternative_id");
      Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn7 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("updated_by");
      Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn8 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("update_date");
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
      Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
      Infragistics.Win.Layout.GridBagConstraint gridBagConstraint6 = new Infragistics.Win.Layout.GridBagConstraint();
      Infragistics.Win.Layout.GridBagConstraint gridBagConstraint7 = new Infragistics.Win.Layout.GridBagConstraint();
      Infragistics.Win.Layout.GridBagConstraint gridBagConstraint2 = new Infragistics.Win.Layout.GridBagConstraint();
      Infragistics.Win.Layout.GridBagConstraint gridBagConstraint1 = new Infragistics.Win.Layout.GridBagConstraint();
      Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("ALTERNATIVES", -1);
      Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn9 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("alternative_id");
      Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn10 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("name");
      Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn11 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("description");
      Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn12 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("asset_set_id");
      Infragistics.Win.Layout.GridBagConstraint gridBagConstraint5 = new Infragistics.Win.Layout.GridBagConstraint();
      Infragistics.Win.Layout.GridBagConstraint gridBagConstraint3 = new Infragistics.Win.Layout.GridBagConstraint();
      Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
      Infragistics.Win.Layout.GridBagConstraint gridBagConstraint4 = new Infragistics.Win.Layout.GridBagConstraint();
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
      this.ultraGridBagLayoutPanel1 = new Infragistics.Win.Misc.UltraGridBagLayoutPanel();
      this.pnlActionButtons = new Infragistics.Win.Misc.UltraGridBagLayoutPanel();
      this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
      ((System.ComponentModel.ISupportInitialize)(this.TextEditorCompkey)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.ultraGrid1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.dRIVERSUPDATEBindingSource)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.sCIPDataSet)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.aLTERNATIVESBindingSource)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.ultraComboAlternatives)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.aLTERNATIVESBindingSource1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.ultraGridBagLayoutPanel1)).BeginInit();
      this.ultraGridBagLayoutPanel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pnlActionButtons)).BeginInit();
      this.pnlActionButtons.SuspendLayout();
      this.SuspendLayout();
      // 
      // LabelCompkey
      // 
      gridBagConstraint10.Fill = Infragistics.Win.Layout.FillType.Both;
      gridBagConstraint10.Insets.Bottom = 8;
      gridBagConstraint10.OriginX = 0;
      gridBagConstraint10.OriginY = 1;
      this.ultraGridBagLayoutPanel1.SetGridBagConstraint(this.LabelCompkey, gridBagConstraint10);
      this.LabelCompkey.Location = new System.Drawing.Point(0, 31);
      this.LabelCompkey.Name = "LabelCompkey";
      this.ultraGridBagLayoutPanel1.SetPreferredSize(this.LabelCompkey, new System.Drawing.Size(90, 19));
      this.LabelCompkey.Size = new System.Drawing.Size(164, 19);
      this.LabelCompkey.TabIndex = 0;
      this.LabelCompkey.Text = "Fetch Compkey:";
      // 
      // TextEditorCompkey
      // 
      gridBagConstraint9.Fill = Infragistics.Win.Layout.FillType.Both;
      gridBagConstraint9.Insets.Right = 8;
      gridBagConstraint9.OriginX = 1;
      gridBagConstraint9.OriginY = 1;
      this.ultraGridBagLayoutPanel1.SetGridBagConstraint(this.TextEditorCompkey, gridBagConstraint9);
      this.TextEditorCompkey.Location = new System.Drawing.Point(164, 31);
      this.TextEditorCompkey.Name = "TextEditorCompkey";
      this.ultraGridBagLayoutPanel1.SetPreferredSize(this.TextEditorCompkey, new System.Drawing.Size(100, 24));
      this.TextEditorCompkey.Size = new System.Drawing.Size(320, 24);
      this.TextEditorCompkey.TabIndex = 1;
      this.TextEditorCompkey.Text = "COMPKEY";
      // 
      // labelDriversForThisCompkey
      // 
      appearance14.TextVAlignAsString = "Middle";
      this.labelDriversForThisCompkey.Appearance = appearance14;
      gridBagConstraint8.Fill = Infragistics.Win.Layout.FillType.Both;
      gridBagConstraint8.Insets.Bottom = 8;
      gridBagConstraint8.OriginX = 0;
      gridBagConstraint8.OriginY = 2;
      this.ultraGridBagLayoutPanel1.SetGridBagConstraint(this.labelDriversForThisCompkey, gridBagConstraint8);
      this.labelDriversForThisCompkey.Location = new System.Drawing.Point(0, 58);
      this.labelDriversForThisCompkey.Name = "labelDriversForThisCompkey";
      this.ultraGridBagLayoutPanel1.SetPreferredSize(this.labelDriversForThisCompkey, new System.Drawing.Size(164, 19));
      this.labelDriversForThisCompkey.Size = new System.Drawing.Size(164, 19);
      this.labelDriversForThisCompkey.TabIndex = 5;
      this.labelDriversForThisCompkey.Text = "Drivers for this Compkey:";
      // 
      // ultraGrid1
      // 
      this.ultraGrid1.DataSource = this.dRIVERSUPDATEBindingSource;
      appearance2.BackColor = System.Drawing.SystemColors.Window;
      appearance2.BorderColor = System.Drawing.SystemColors.InactiveCaption;
      this.ultraGrid1.DisplayLayout.Appearance = appearance2;
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
      ultraGridBand2.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2,
            ultraGridColumn3,
            ultraGridColumn4,
            ultraGridColumn5,
            ultraGridColumn6,
            ultraGridColumn7,
            ultraGridColumn8});
      this.ultraGrid1.DisplayLayout.BandsSerializer.Add(ultraGridBand2);
      this.ultraGrid1.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
      this.ultraGrid1.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
      appearance3.BackColor = System.Drawing.SystemColors.ActiveBorder;
      appearance3.BackColor2 = System.Drawing.SystemColors.ControlDark;
      appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
      appearance3.BorderColor = System.Drawing.SystemColors.Window;
      this.ultraGrid1.DisplayLayout.GroupByBox.Appearance = appearance3;
      appearance4.ForeColor = System.Drawing.SystemColors.GrayText;
      this.ultraGrid1.DisplayLayout.GroupByBox.BandLabelAppearance = appearance4;
      this.ultraGrid1.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
      appearance5.BackColor = System.Drawing.SystemColors.ControlLightLight;
      appearance5.BackColor2 = System.Drawing.SystemColors.Control;
      appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
      appearance5.ForeColor = System.Drawing.SystemColors.GrayText;
      this.ultraGrid1.DisplayLayout.GroupByBox.PromptAppearance = appearance5;
      this.ultraGrid1.DisplayLayout.MaxColScrollRegions = 1;
      this.ultraGrid1.DisplayLayout.MaxRowScrollRegions = 1;
      appearance6.BackColor = System.Drawing.SystemColors.Window;
      appearance6.ForeColor = System.Drawing.SystemColors.ControlText;
      this.ultraGrid1.DisplayLayout.Override.ActiveCellAppearance = appearance6;
      appearance7.BackColor = System.Drawing.SystemColors.Highlight;
      appearance7.ForeColor = System.Drawing.SystemColors.HighlightText;
      this.ultraGrid1.DisplayLayout.Override.ActiveRowAppearance = appearance7;
      this.ultraGrid1.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
      this.ultraGrid1.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
      appearance8.BackColor = System.Drawing.SystemColors.Window;
      this.ultraGrid1.DisplayLayout.Override.CardAreaAppearance = appearance8;
      appearance9.BorderColor = System.Drawing.Color.Silver;
      appearance9.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
      this.ultraGrid1.DisplayLayout.Override.CellAppearance = appearance9;
      this.ultraGrid1.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
      this.ultraGrid1.DisplayLayout.Override.CellPadding = 0;
      appearance10.BackColor = System.Drawing.SystemColors.Control;
      appearance10.BackColor2 = System.Drawing.SystemColors.ControlDark;
      appearance10.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
      appearance10.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
      appearance10.BorderColor = System.Drawing.SystemColors.Window;
      this.ultraGrid1.DisplayLayout.Override.GroupByRowAppearance = appearance10;
      appearance11.TextHAlignAsString = "Left";
      this.ultraGrid1.DisplayLayout.Override.HeaderAppearance = appearance11;
      this.ultraGrid1.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
      this.ultraGrid1.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
      appearance12.BackColor = System.Drawing.SystemColors.Window;
      appearance12.BorderColor = System.Drawing.Color.Silver;
      this.ultraGrid1.DisplayLayout.Override.RowAppearance = appearance12;
      this.ultraGrid1.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
      appearance13.BackColor = System.Drawing.SystemColors.ControlLight;
      this.ultraGrid1.DisplayLayout.Override.TemplateAddRowAppearance = appearance13;
      this.ultraGrid1.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
      this.ultraGrid1.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
      this.ultraGrid1.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
      gridBagConstraint6.Fill = Infragistics.Win.Layout.FillType.Both;
      gridBagConstraint6.Insets.Bottom = 8;
      gridBagConstraint6.OriginX = 0;
      gridBagConstraint6.OriginY = 3;
      gridBagConstraint6.SpanX = 3;
      gridBagConstraint6.WeightY = 1F;
      this.ultraGridBagLayoutPanel1.SetGridBagConstraint(this.ultraGrid1, gridBagConstraint6);
      this.ultraGrid1.Location = new System.Drawing.Point(0, 85);
      this.ultraGrid1.Name = "ultraGrid1";
      this.ultraGridBagLayoutPanel1.SetPreferredSize(this.ultraGrid1, new System.Drawing.Size(828, 171));
      this.ultraGrid1.Size = new System.Drawing.Size(567, 326);
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
      gridBagConstraint7.OriginX = 2;
      gridBagConstraint7.OriginY = 1;
      this.ultraGridBagLayoutPanel1.SetGridBagConstraint(this.buttonFetchCompkey, gridBagConstraint7);
      this.buttonFetchCompkey.Location = new System.Drawing.Point(492, 33);
      this.buttonFetchCompkey.Name = "buttonFetchCompkey";
      this.ultraGridBagLayoutPanel1.SetPreferredSize(this.buttonFetchCompkey, new System.Drawing.Size(75, 23));
      this.buttonFetchCompkey.Size = new System.Drawing.Size(75, 23);
      this.buttonFetchCompkey.TabIndex = 8;
      this.buttonFetchCompkey.Text = "Fetch!";
      this.buttonFetchCompkey.Click += new System.EventHandler(this.buttonFetchCompkey_Click);
      // 
      // buttonUpdateDrivers
      // 
      gridBagConstraint2.Fill = Infragistics.Win.Layout.FillType.Both;
      gridBagConstraint2.OriginX = 1;
      gridBagConstraint2.OriginY = 0;
      this.pnlActionButtons.SetGridBagConstraint(this.buttonUpdateDrivers, gridBagConstraint2);
      this.buttonUpdateDrivers.Location = new System.Drawing.Point(448, 0);
      this.buttonUpdateDrivers.Name = "buttonUpdateDrivers";
      this.pnlActionButtons.SetPreferredSize(this.buttonUpdateDrivers, new System.Drawing.Size(119, 23));
      this.buttonUpdateDrivers.Size = new System.Drawing.Size(119, 23);
      this.buttonUpdateDrivers.TabIndex = 9;
      this.buttonUpdateDrivers.Text = "Update Drivers";
      this.buttonUpdateDrivers.Click += new System.EventHandler(this.buttonUpdateDrivers_Click);
      // 
      // buttonRevertDrivers
      // 
      gridBagConstraint1.Anchor = Infragistics.Win.Layout.AnchorType.Right;
      gridBagConstraint1.OriginX = 0;
      gridBagConstraint1.OriginY = 0;
      gridBagConstraint1.WeightX = 1F;
      this.pnlActionButtons.SetGridBagConstraint(this.buttonRevertDrivers, gridBagConstraint1);
      this.buttonRevertDrivers.Location = new System.Drawing.Point(329, 0);
      this.buttonRevertDrivers.Name = "buttonRevertDrivers";
      this.pnlActionButtons.SetPreferredSize(this.buttonRevertDrivers, new System.Drawing.Size(119, 23));
      this.buttonRevertDrivers.Size = new System.Drawing.Size(119, 23);
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
      ultraGridColumn9.Header.VisiblePosition = 0;
      ultraGridColumn10.Header.VisiblePosition = 1;
      ultraGridColumn11.Header.VisiblePosition = 2;
      ultraGridColumn12.Header.VisiblePosition = 3;
      ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn9,
            ultraGridColumn10,
            ultraGridColumn11,
            ultraGridColumn12});
      this.ultraComboAlternatives.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
      this.ultraComboAlternatives.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      gridBagConstraint5.Fill = Infragistics.Win.Layout.FillType.Both;
      gridBagConstraint5.Insets.Right = 8;
      gridBagConstraint5.OriginX = 1;
      gridBagConstraint5.OriginY = 0;
      gridBagConstraint5.WeightX = 1F;
      this.ultraGridBagLayoutPanel1.SetGridBagConstraint(this.ultraComboAlternatives, gridBagConstraint5);
      this.ultraComboAlternatives.Location = new System.Drawing.Point(164, 0);
      this.ultraComboAlternatives.Name = "ultraComboAlternatives";
      this.ultraGridBagLayoutPanel1.SetPreferredSize(this.ultraComboAlternatives, new System.Drawing.Size(100, 22));
      this.ultraComboAlternatives.Size = new System.Drawing.Size(320, 25);
      this.ultraComboAlternatives.TabIndex = 11;
      this.ultraComboAlternatives.Text = "Select Alternative";
      // 
      // aLTERNATIVESBindingSource1
      // 
      this.aLTERNATIVESBindingSource1.DataMember = "ALTERNATIVES";
      this.aLTERNATIVESBindingSource1.DataSource = this.sCIPDataSet;
      // 
      // ultraGridBagLayoutPanel1
      // 
      this.ultraGridBagLayoutPanel1.Controls.Add(this.pnlActionButtons);
      this.ultraGridBagLayoutPanel1.Controls.Add(this.ultraLabel1);
      this.ultraGridBagLayoutPanel1.Controls.Add(this.ultraComboAlternatives);
      this.ultraGridBagLayoutPanel1.Controls.Add(this.LabelCompkey);
      this.ultraGridBagLayoutPanel1.Controls.Add(this.ultraGrid1);
      this.ultraGridBagLayoutPanel1.Controls.Add(this.buttonFetchCompkey);
      this.ultraGridBagLayoutPanel1.Controls.Add(this.labelDriversForThisCompkey);
      this.ultraGridBagLayoutPanel1.Controls.Add(this.TextEditorCompkey);
      this.ultraGridBagLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.ultraGridBagLayoutPanel1.Location = new System.Drawing.Point(0, 0);
      this.ultraGridBagLayoutPanel1.Name = "ultraGridBagLayoutPanel1";
      this.ultraGridBagLayoutPanel1.Size = new System.Drawing.Size(567, 442);
      this.ultraGridBagLayoutPanel1.TabIndex = 12;
      // 
      // pnlActionButtons
      // 
      this.pnlActionButtons.Controls.Add(this.buttonRevertDrivers);
      this.pnlActionButtons.Controls.Add(this.buttonUpdateDrivers);
      gridBagConstraint3.Fill = Infragistics.Win.Layout.FillType.Both;
      gridBagConstraint3.OriginX = 0;
      gridBagConstraint3.OriginY = 4;
      gridBagConstraint3.SpanX = 3;
      this.ultraGridBagLayoutPanel1.SetGridBagConstraint(this.pnlActionButtons, gridBagConstraint3);
      this.pnlActionButtons.Location = new System.Drawing.Point(0, 419);
      this.pnlActionButtons.Name = "pnlActionButtons";
      this.ultraGridBagLayoutPanel1.SetPreferredSize(this.pnlActionButtons, new System.Drawing.Size(200, 23));
      this.pnlActionButtons.Size = new System.Drawing.Size(567, 23);
      this.pnlActionButtons.TabIndex = 12;
      // 
      // ultraLabel1
      // 
      appearance1.TextVAlignAsString = "Middle";
      this.ultraLabel1.Appearance = appearance1;
      gridBagConstraint4.Fill = Infragistics.Win.Layout.FillType.Both;
      gridBagConstraint4.Insets.Bottom = 8;
      gridBagConstraint4.OriginX = 0;
      gridBagConstraint4.OriginY = 0;
      this.ultraGridBagLayoutPanel1.SetGridBagConstraint(this.ultraLabel1, gridBagConstraint4);
      this.ultraLabel1.Location = new System.Drawing.Point(0, 0);
      this.ultraLabel1.Name = "ultraLabel1";
      this.ultraGridBagLayoutPanel1.SetPreferredSize(this.ultraLabel1, new System.Drawing.Size(100, 23));
      this.ultraLabel1.Size = new System.Drawing.Size(164, 23);
      this.ultraLabel1.TabIndex = 0;
      this.ultraLabel1.Text = "Alternative";
      // 
      // IndividualDriversPage
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(567, 442);
      this.Controls.Add(this.ultraGridBagLayoutPanel1);
      this.Name = "IndividualDriversPage";
      this.Text = "Individual Drivers";
      this.Load += new System.EventHandler(this.FormIndividualDrivers_Load);
      ((System.ComponentModel.ISupportInitialize)(this.TextEditorCompkey)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.ultraGrid1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.dRIVERSUPDATEBindingSource)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.sCIPDataSet)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.aLTERNATIVESBindingSource)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.ultraComboAlternatives)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.aLTERNATIVESBindingSource1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.ultraGridBagLayoutPanel1)).EndInit();
      this.ultraGridBagLayoutPanel1.ResumeLayout(false);
      this.ultraGridBagLayoutPanel1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pnlActionButtons)).EndInit();
      this.pnlActionButtons.ResumeLayout(false);
      this.ResumeLayout(false);

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
        private Infragistics.Win.Misc.UltraGridBagLayoutPanel ultraGridBagLayoutPanel1;
        private Infragistics.Win.Misc.UltraGridBagLayoutPanel pnlActionButtons;
        private Infragistics.Win.Misc.UltraLabel ultraLabel1;
    }
}