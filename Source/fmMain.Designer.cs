namespace KeybordRegsChanger
{
    partial class fmMain
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.dgvKeybord = new System.Windows.Forms.DataGridView();
            this.Enable = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Type = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.KeybordName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InstanceID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmbAllSetting = new System.Windows.Forms.ComboBox();
            this.chkAllSetting = new System.Windows.Forms.CheckBox();
            this.chkKorSetting = new System.Windows.Forms.CheckBox();
            this.cmbKorSetting = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKeybord)).BeginInit();
            this.SuspendLayout();
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnUpdate.Location = new System.Drawing.Point(15, 27);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(4);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(238, 29);
            this.btnUpdate.TabIndex = 0;
            this.btnUpdate.Text = "再読み込み";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.LightGreen;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSave.Location = new System.Drawing.Point(260, 27);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(238, 29);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "レジストリへ書き込み";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dgvKeybord
            // 
            this.dgvKeybord.AllowUserToAddRows = false;
            this.dgvKeybord.AllowUserToDeleteRows = false;
            this.dgvKeybord.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvKeybord.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvKeybord.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvKeybord.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKeybord.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Enable,
            this.Type,
            this.KeybordName,
            this.InstanceID});
            this.dgvKeybord.Location = new System.Drawing.Point(15, 173);
            this.dgvKeybord.Margin = new System.Windows.Forms.Padding(4);
            this.dgvKeybord.MultiSelect = false;
            this.dgvKeybord.Name = "dgvKeybord";
            this.dgvKeybord.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.Snow;
            this.dgvKeybord.RowTemplate.Height = 30;
            this.dgvKeybord.Size = new System.Drawing.Size(851, 307);
            this.dgvKeybord.TabIndex = 2;
            // 
            // Enable
            // 
            this.Enable.DataPropertyName = "Enable";
            this.Enable.FalseValue = "false";
            this.Enable.HeaderText = "Enable";
            this.Enable.IndeterminateValue = "true";
            this.Enable.Name = "Enable";
            this.Enable.TrueValue = "true";
            // 
            // Type
            // 
            this.Type.DataPropertyName = "Type";
            this.Type.HeaderText = "Type";
            this.Type.Items.AddRange(new object[] {
            "(なし)",
            "JIS",
            "US"});
            this.Type.Name = "Type";
            // 
            // KeybordName
            // 
            this.KeybordName.DataPropertyName = "KeybordName";
            this.KeybordName.HeaderText = "KeybordName";
            this.KeybordName.Name = "KeybordName";
            // 
            // InstanceID
            // 
            this.InstanceID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.InstanceID.DataPropertyName = "InstanceID";
            this.InstanceID.HeaderText = "InctanceID";
            this.InstanceID.Name = "InstanceID";
            this.InstanceID.Width = 122;
            // 
            // cmbAllSetting
            // 
            this.cmbAllSetting.FormattingEnabled = true;
            this.cmbAllSetting.Items.AddRange(new object[] {
            "(なし)",
            "JIS",
            "US"});
            this.cmbAllSetting.Location = new System.Drawing.Point(274, 114);
            this.cmbAllSetting.Margin = new System.Windows.Forms.Padding(4);
            this.cmbAllSetting.Name = "cmbAllSetting";
            this.cmbAllSetting.Size = new System.Drawing.Size(150, 27);
            this.cmbAllSetting.TabIndex = 2;
            this.cmbAllSetting.Text = "US";
            // 
            // chkAllSetting
            // 
            this.chkAllSetting.AutoSize = true;
            this.chkAllSetting.Checked = true;
            this.chkAllSetting.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAllSetting.Location = new System.Drawing.Point(15, 116);
            this.chkAllSetting.Name = "chkAllSetting";
            this.chkAllSetting.Size = new System.Drawing.Size(234, 23);
            this.chkAllSetting.TabIndex = 4;
            this.chkAllSetting.Text = "システム全体の設定を変更";
            this.chkAllSetting.UseVisualStyleBackColor = true;
            // 
            // chkKorSetting
            // 
            this.chkKorSetting.AutoSize = true;
            this.chkKorSetting.Location = new System.Drawing.Point(500, 116);
            this.chkKorSetting.Name = "chkKorSetting";
            this.chkKorSetting.Size = new System.Drawing.Size(139, 23);
            this.chkKorSetting.TabIndex = 5;
            this.chkKorSetting.Text = "韓国語の有無";
            this.chkKorSetting.UseVisualStyleBackColor = true;
            // 
            // cmbKorSetting
            // 
            this.cmbKorSetting.FormattingEnabled = true;
            this.cmbKorSetting.Items.AddRange(new object[] {
            "無し",
            "有り"});
            this.cmbKorSetting.Location = new System.Drawing.Point(660, 114);
            this.cmbKorSetting.Margin = new System.Windows.Forms.Padding(4);
            this.cmbKorSetting.Name = "cmbKorSetting";
            this.cmbKorSetting.Size = new System.Drawing.Size(150, 27);
            this.cmbKorSetting.TabIndex = 6;
            this.cmbKorSetting.Text = "無し";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.LightYellow;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(12, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 19);
            this.label1.TabIndex = 7;
            this.label1.Text = "メッセージ";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // fmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MintCream;
            this.ClientSize = new System.Drawing.Size(879, 493);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbKorSetting);
            this.Controls.Add(this.chkKorSetting);
            this.Controls.Add(this.chkAllSetting);
            this.Controls.Add(this.cmbAllSetting);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.dgvKeybord);
            this.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.Name = "fmMain";
            this.Text = "KeybordRegs";
            this.Load += new System.EventHandler(this.fmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKeybord)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridView dgvKeybord;
        private System.Windows.Forms.ComboBox cmbAllSetting;
        private System.Windows.Forms.CheckBox chkAllSetting;
        private System.Windows.Forms.CheckBox chkKorSetting;
        private System.Windows.Forms.ComboBox cmbKorSetting;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Enable;
        private System.Windows.Forms.DataGridViewComboBoxColumn Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn KeybordName;
        private System.Windows.Forms.DataGridViewTextBoxColumn InstanceID;
        private System.Windows.Forms.Label label1;
    }
}

