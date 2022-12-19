using GirisCikisKontrolOtomasyonu.Classlar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GirisCikisKontrolOtomasyonu.Formlar
{
   
    public partial class Sirket : Form
    {
        Classlar.KontrolContext cntx = new Classlar.KontrolContext();
        public Sirket()
        {
            InitializeComponent();
            list();
            btn_guncelle.Enabled = false;
            btn_sil.Enabled = false;
        }
        public void list()
        {
            var liste = cntx.Sirket.ToList();
            dataGridView1.DataSource = liste;
            dataGridView1.Columns["SirketId"].Visible = false;
        }

        private void btn_ekle_Click(object sender, EventArgs e)
        {
            try
            {
                // oluşturduğunuz dbcontext bir nesne olustur
                var sirket = new Classlar.Sirket();
                sirket.SirketAdi = txt_ekle.Text;
                cntx.Sirket.Add(sirket);
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
        string SirketAdi = "";
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["SirketId"].Value.ToString());
            SirketAdi = dataGridView1.CurrentRow.Cells["SirketAdi"].Value.ToString();
            txt_guncellesil.Text = SirketAdi;


            btn_guncelle.Enabled = true;
            btn_sil.Enabled = true;
        }

        private void btn_guncelle_Click(object sender, EventArgs e)
        {
            Classlar.Sirket sirket = cntx.Sirket.FirstOrDefault(a => a.SirketId == ID);
            sirket.SirketAdi = txt_guncellesil.Text; // disaridan gireceğiniz değerler yazılır(kirmizi olanlar disaridan gelen değerler)
            cntx.SaveChanges();
            list();
            btn_guncelle.Enabled = false;
            btn_sil.Enabled = false;
            txt_guncellesil.Text = "";
        }

        private void btn_sil_Click(object sender, EventArgs e)
        {
            Classlar.Sirket sirket = cntx.Sirket.FirstOrDefault(a => a.SirketId == ID);
            cntx.Sirket.Remove(sirket);
            cntx.SaveChanges();
            list();
            btn_guncelle.Enabled = false;
            btn_sil.Enabled = false;
            ID = 0;
            txt_guncellesil.Text = "";
        }

        private void btn_ara_Click(object sender, EventArgs e)
        {
            var ara = from x in cntx.Sirket select x;
            if (txt_ara.Text != null)
            {
                dataGridView1.DataSource = ara.Where(x => x.SirketAdi.Contains(txt_ara.Text)).ToList();
            }

        }
    }
}
