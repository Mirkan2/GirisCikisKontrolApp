using GirisCikisKontrolOtomasyonu.Classlar;
using GirisCikisKontrolOtomasyonu.Formlar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GirisCikisKontrolOtomasyonu
{
    public partial class Form1 : Form
    {
        Classlar.KontrolContext cntx = new Classlar.KontrolContext();
        string[] ports = System.IO.Ports.SerialPort.GetPortNames();
        public Form1()
        {
            InitializeComponent();
            cntx.Database.CreateIfNotExists();
            sp_form1.DataReceived += new SerialDataReceivedEventHandler(sp_form1_DataReceived);
            //cb_doldur();
            list();
           
            Control.CheckForIllegalCrossThreadCalls = false;
            foreach (string port in ports) // pc ye takılı olan device ların portlarını ekle
            {
                cb_cp.Items.Add(port);
            }

            sp_form1.PortName = cb_cp.Items[0].ToString();
            sp_form1.BaudRate = 9600;
            sp_form1.Open();
        }
        public void list()
        {
            var query = cntx.GirisCikis.Select(x => new
            {
               CikisCihazNo = x.CikisCihazNo,
               
            }).ToList();


        }
       
        private void sp_form1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            Thread.Sleep(30);
            Int64 data = Convert.ToInt64(sp_form1.ReadLine());
          
            if (txt_gelenId.InvokeRequired)
            {
                txt_gelenId.Invoke(new MethodInvoker(delegate { txt_gelenId.Text = data+"\r"; }));
                //{+ "\r\n"};
            }
            

        }
        int sira;
        private void txt_gelenId_TextChanged(object sender, EventArgs e)
        {
            Classlar.GirisCikis cihaz = cntx.GirisCikis.FirstOrDefault(a => a.CikisCihazNo == txt_gelenId.Text);
            if (cihaz == null)
            {
                try
                {

                    Classlar.Cihaz cihaz1 = cntx.Cihaz.FirstOrDefault(a => a.CihazNo == txt_gelenId.Text);
                    if (cihaz1 == null)
                    {
                        MessageBox.Show("Giriş Başarısız");
                    }
                    else if (cihaz1.CihazNo == txt_gelenId.Text)
                    {
                        MessageBox.Show("Giriş Başarılı");

                        string kk = txt_gelenId.Text.Substring(0, txt_gelenId.Text.Length);
                        try
                        {
                            var chz = new Classlar.GirisCikis();
                            chz.CikisCihazNo = kk;
                            cntx.GirisCikis.Add(chz);
                            cntx.SaveChanges();
                            sira++;
                        }
                        catch (Exception hata)
                        {
                            MessageBox.Show("Lutfen veriyi bos gecmeyiniz");
                        }
                        finally
                        {

                            list();
                        }

                    }
                }
                catch (Exception hata)
                {

                    MessageBox.Show(hata.Message);
                }

            }

            else if (cihaz.CikisCihazNo==txt_gelenId.Text)
            {
                        try
                        {
                            Classlar.GirisCikis cihaz2 = cntx.GirisCikis.FirstOrDefault(a => a.CikisCihazNo == txt_cikis.Text);
                            if (cihaz2 == null)
                            {
                                MessageBox.Show("Çıkış Başarısız");
                            }
                            else if (cihaz2.CikisCihazNo == txt_cikis.Text)
                            {
                                MessageBox.Show("Çıkış Başarılı");
                                try
                                {
                                    cntx.GirisCikis.Remove(cihaz2);
                                    cntx.SaveChanges();
                                    sira = 0;
                                }
                                catch (Exception hata)
                                {
                                    MessageBox.Show("Lutfen veriyi bos gecmeyiniz");
                                }
                                finally
                                {

                                    list();
                                }
                            }
                        }
                        catch (Exception hata)
                        {

                            MessageBox.Show(hata.Message);
                        }  
            }
            
        }
        
        private void txt_cikis_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sp_form1.Close();
            Formlar.Cihaz cihaz= new Formlar.Cihaz();
            cihaz.Show();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Formlar.Sirket sirket = new Formlar.Sirket();
            sirket.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Formlar.Personel personel = new Formlar.Personel();
            personel.Show();
        }  
    }
}
