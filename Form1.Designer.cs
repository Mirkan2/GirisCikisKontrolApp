namespace GirisCikisKontrolOtomasyonu
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.sp_form1 = new System.IO.Ports.SerialPort(this.components);
            this.cb_cp = new System.Windows.Forms.ComboBox();
            this.txt_gelenId = new System.Windows.Forms.TextBox();
            this.txt_cikis = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 86);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(195, 47);
            this.button1.TabIndex = 0;
            this.button1.Text = "Cihaz";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(195, 47);
            this.button2.TabIndex = 1;
            this.button2.Text = "Şirket";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(12, 160);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(195, 47);
            this.button3.TabIndex = 2;
            this.button3.Text = "Personel";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // sp_form1
            // 
            this.sp_form1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.sp_form1_DataReceived);
            // 
            // cb_cp
            // 
            this.cb_cp.FormattingEnabled = true;
            this.cb_cp.Location = new System.Drawing.Point(213, 12);
            this.cb_cp.Name = "cb_cp";
            this.cb_cp.Size = new System.Drawing.Size(121, 24);
            this.cb_cp.TabIndex = 3;
            this.cb_cp.Visible = false;
            // 
            // txt_gelenId
            // 
            this.txt_gelenId.Location = new System.Drawing.Point(356, 12);
            this.txt_gelenId.Name = "txt_gelenId";
            this.txt_gelenId.Size = new System.Drawing.Size(121, 22);
            this.txt_gelenId.TabIndex = 4;
            this.txt_gelenId.TextChanged += new System.EventHandler(this.txt_gelenId_TextChanged);
            // 
            // txt_cikis
            // 
            this.txt_cikis.Location = new System.Drawing.Point(213, 56);
            this.txt_cikis.Name = "txt_cikis";
            this.txt_cikis.Size = new System.Drawing.Size(121, 22);
            this.txt_cikis.TabIndex = 5;
            this.txt_cikis.TextChanged += new System.EventHandler(this.txt_cikis_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(489, 432);
            this.Controls.Add(this.txt_cikis);
            this.Controls.Add(this.txt_gelenId);
            this.Controls.Add(this.cb_cp);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Kontrol";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.IO.Ports.SerialPort sp_form1;
        private System.Windows.Forms.ComboBox cb_cp;
        private System.Windows.Forms.TextBox txt_gelenId;
        private System.Windows.Forms.TextBox txt_cikis;
    }
}

