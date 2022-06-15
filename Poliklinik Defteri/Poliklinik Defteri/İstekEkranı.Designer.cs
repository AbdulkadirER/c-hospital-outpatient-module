namespace Poliklinik_Defteri
{
    partial class İstekEkranı
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.chcbxRadyoloji = new System.Windows.Forms.CheckedListBox();
            this.chcbxBiyoKimya = new System.Windows.Forms.CheckedListBox();
            this.btnİstekEkle = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.chcbxİdrar = new System.Windows.Forms.CheckedListBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.chcbxİdrar);
            this.panel1.Controls.Add(this.dateTimePicker1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.chcbxRadyoloji);
            this.panel1.Controls.Add(this.chcbxBiyoKimya);
            this.panel1.Controls.Add(this.btnİstekEkle);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Location = new System.Drawing.Point(0, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(421, 488);
            this.panel1.TabIndex = 0;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(3, 458);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 23);
            this.dateTimePicker1.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 464);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 17);
            this.label1.TabIndex = 13;
            this.label1.Visible = false;
            // 
            // chcbxRadyoloji
            // 
            this.chcbxRadyoloji.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.chcbxRadyoloji.FormattingEnabled = true;
            this.chcbxRadyoloji.Items.AddRange(new object[] {
            "EKG",
            "Röntgen",
            "Tomografi",
            "MR",
            "Ultrason"});
            this.chcbxRadyoloji.Location = new System.Drawing.Point(3, 320);
            this.chcbxRadyoloji.Name = "chcbxRadyoloji";
            this.chcbxRadyoloji.Size = new System.Drawing.Size(415, 112);
            this.chcbxRadyoloji.TabIndex = 2;
            // 
            // chcbxBiyoKimya
            // 
            this.chcbxBiyoKimya.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.chcbxBiyoKimya.FormattingEnabled = true;
            this.chcbxBiyoKimya.Items.AddRange(new object[] {
            "Glukoz",
            "Kreatinin",
            "Albümin",
            "Bilirubin",
            "Kalsiyum",
            "Magnezyum",
            "Kolesterol"});
            this.chcbxBiyoKimya.Location = new System.Drawing.Point(0, 33);
            this.chcbxBiyoKimya.Name = "chcbxBiyoKimya";
            this.chcbxBiyoKimya.Size = new System.Drawing.Size(421, 130);
            this.chcbxBiyoKimya.TabIndex = 12;
            // 
            // btnİstekEkle
            // 
            this.btnİstekEkle.Image = global::Poliklinik_Defteri.Properties.Resources.plus;
            this.btnİstekEkle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnİstekEkle.Location = new System.Drawing.Point(309, 437);
            this.btnİstekEkle.Name = "btnİstekEkle";
            this.btnİstekEkle.Size = new System.Drawing.Size(112, 51);
            this.btnİstekEkle.TabIndex = 11;
            this.btnİstekEkle.Text = "İstek Ekle";
            this.btnİstekEkle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnİstekEkle.UseVisualStyleBackColor = true;
            this.btnİstekEkle.Click += new System.EventHandler(this.btnİstekEkle_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button3.Location = new System.Drawing.Point(0, 286);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(421, 34);
            this.button3.TabIndex = 2;
            this.button3.Text = "Radyoloji";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button2.Location = new System.Drawing.Point(0, 162);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(421, 34);
            this.button2.TabIndex = 2;
            this.button2.Text = "İdrar Laboratuvarı";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(421, 34);
            this.button1.TabIndex = 0;
            this.button1.Text = "Biyokimya Laboratuvarı";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.Padding = new System.Windows.Forms.Padding(0, 6, 0, 6);
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridView1.Location = new System.Drawing.Point(427, 1);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 100;
            this.dataGridView1.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridView1.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.CadetBlue;
            this.dataGridView1.RowTemplate.Height = 37;
            this.dataGridView1.Size = new System.Drawing.Size(837, 488);
            this.dataGridView1.TabIndex = 15;
            // 
            // chcbxİdrar
            // 
            this.chcbxİdrar.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.chcbxİdrar.FormattingEnabled = true;
            this.chcbxİdrar.Items.AddRange(new object[] {
            "İdrar Tetkiki"});
            this.chcbxİdrar.Location = new System.Drawing.Point(2, 195);
            this.chcbxİdrar.Name = "chcbxİdrar";
            this.chcbxİdrar.Size = new System.Drawing.Size(416, 94);
            this.chcbxİdrar.TabIndex = 15;
            // 
            // İstekEkranı
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1268, 490);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "İstekEkranı";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "İstekEkranı";
            this.Load += new System.EventHandler(this.İstekEkranı_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnİstekEkle;
        private System.Windows.Forms.CheckedListBox chcbxRadyoloji;
        private System.Windows.Forms.CheckedListBox chcbxBiyoKimya;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.CheckedListBox chcbxİdrar;
    }
}