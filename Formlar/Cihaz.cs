using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GirisCikisKontrolOtomasyonu.Formlar
{
    public partial class Cihaz : Form
    {
        Classlar.KontrolContext cntx = new Classlar.KontrolContext();
        string[] ports = System.IO.Ports.SerialPort.GetPortNames();
        public Cihaz()
        {
            InitializeComponent();
            list();
            FormClosing += Cihaz_FormClosing;
            serialPort1.DataReceived += new SerialDataReceivedEventHandler(serialPort1_DataReceived);
            btn_guncelle.Enabled = false;
            btn_sil.Enabled = false;
        }
        public void list()
        {
            var liste = cntx.Cihaz.ToList(); 
            dataGridView1.DataSource = liste; 
            dataGridView1.Columns["CihazId"].Visible = false;
        }

        private void btn_ekle_Click(object sender, EventArgs e)
        {
            string kk = txt_ekle.Text.Substring(0, txt_ekle.Text.Length);
            try
            {
                var cihaz = new Classlar.Cihaz();
                cihaz.CihazNo=kk;
                cntx.Cihaz.Add(cihaz);
                cntx.SaveChanges();
            }
            catch (Exception hata)
            {
                MessageBox.Show("Lutfen veriyi bos gecmeyiniz");
            }
            finally
            {
                txt_ekle.Text = "";
                list();
            }
        }
        int ID = 0;
        string CihazNo = "";
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["CihazId"].Value.ToString());
            CihazNo = dataGridView1.CurrentRow.Cells["CihazNo"].Value.ToString();
            txt_silguncelle.Text = CihazNo;


            btn_guncelle.Enabled = true;
            btn_sil.Enabled = true;
        }

        private void btn_guncelle_Click(object sender, EventArgs e)
        {
            Classlar.Cihaz cihaz = cntx.Cihaz.FirstOrDefault(a => a.CihazId == ID);
            cihaz.CihazNo = txt_silguncelle.Text; // disaridan gireceğiniz değerler yazılır(kirmizi olanlar disaridan gelen değerler)
            cntx.SaveChanges();
            list();
            btn_guncelle.Enabled = false;
            btn_sil.Enabled = false;
            txt_silguncelle.Text = "";
        }

        private void btn_sil_Click(object sender, EventArgs e)
        {
            Classlar.Cihaz cihaz = cntx.Cihaz.FirstOrDefault(a => a.CihazId == ID);
            cntx.Cihaz.Remove(cihaz);
            cntx.SaveChanges();
            list();
            btn_guncelle.Enabled = false;
            btn_sil.Enabled = false;
            ID = 0;
            txt_silguncelle.Text = "";
        }

        private void Cihaz_Load(object sender, EventArgs e)
        {
            foreach (string port in ports) // pc ye takılı olan device ların portlarını ekle
            {
                cb_cp.Items.Add(port);
            }

            // baudrate leri yükle
            cb_br.Items.Add("300");
            cb_br.Items.Add("600");
            cb_br.Items.Add("1200");
            cb_br.Items.Add("2400");
            cb_br.Items.Add("4800");
            cb_br.Items.Add("9600");
            cb_br.Items.Add("19200");
            cb_br.Items.Add("57600");
            cb_br.Items.Add("115200");
        }

        private void Cihaz_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (serialPort1.IsOpen == true)
            {
                serialPort1.Close();

            }
        }
        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            Thread.Sleep(30);

            string data = serialPort1.ReadLine();

            if (txt_ekle.InvokeRequired)
            {
                txt_ekle.Invoke(new MethodInvoker(delegate { txt_ekle.Text = data ; }));
            }
            //if (txt_silguncelle.InvokeRequired)
            //{
            //    txt_silguncelle.Invoke(new MethodInvoker(delegate { txt_silguncelle.Text = data; }));
            //}
        }

        private void btn_baglan_Click(object sender, EventArgs e)
        {
            if (btn_baglan.Text == "Bağlan")
            {
                btn_baglan.Text = "Bağlantıyı Kes";
                label4.Text = cb_cp.Text + "," + cb_br.Text + ", Hat Açık";
                serialPort1.PortName = cb_cp.Text;
                serialPort1.BaudRate = Convert.ToInt32(cb_br.Text);
                serialPort1.Open();
            }
            else// bağlan
            {
                btn_baglan.Text = "Bağlan";
                label4.Text = "Hat Kapalı";
                serialPort1.Close();
                cb_br.Text = "";
                cb_cp.Text = "";
            }
        }
    }
}
