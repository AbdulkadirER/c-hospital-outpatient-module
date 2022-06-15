namespace Poliklinik_Defteri
{
    partial class CiktiAl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CiktiAl));
            this.pdYazici = new System.Drawing.Printing.PrintDocument();
            this.ppdDiyalog = new System.Windows.Forms.PrintPreviewDialog();
            this.btnYazdir = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // pdYazici
            // 
            this.pdYazici.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.pdYazici_PrintPage);
            // 
            // ppdDiyalog
            // 
            this.ppdDiyalog.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.ppdDiyalog.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.ppdDiyalog.ClientSize = new System.Drawing.Size(400, 300);
            this.ppdDiyalog.Document = this.pdYazici;
            this.ppdDiyalog.Enabled = true;
            this.ppdDiyalog.Icon = ((System.Drawing.Icon)(resources.GetObject("ppdDiyalog.Icon")));
            this.ppdDiyalog.Name = "ppdDiyalog";
            this.ppdDiyalog.Visible = false;
            // 
            // btnYazdir
            // 
            this.btnYazdir.Location = new System.Drawing.Point(354, 343);
            this.btnYazdir.Margin = new System.Windows.Forms.Padding(4);
            this.btnYazdir.Name = "btnYazdir";
            this.btnYazdir.Size = new System.Drawing.Size(106, 40);
            this.btnYazdir.TabIndex = 0;
            this.btnYazdir.Text = "Yazdır";
            this.btnYazdir.UseVisualStyleBackColor = true;
            this.btnYazdir.Click += new System.EventHandler(this.btnYazdir_Click);
            // 
            // listView1
            // 
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(180, 12);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(491, 258);
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(315, 283);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 23);
            this.dateTimePicker1.TabIndex = 2;
            // 
            // CiktiAl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(876, 505);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.btnYazdir);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "CiktiAl";
            this.Text = "CiktiAl";
            this.Load += new System.EventHandler(this.CiktiAl_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Drawing.Printing.PrintDocument pdYazici;
        private System.Windows.Forms.PrintPreviewDialog ppdDiyalog;
        private System.Windows.Forms.Button btnYazdir;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
    }
}