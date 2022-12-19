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
    public partial class Personel : Form
    {
        Classlar.KontrolContext cntx = new Classlar.KontrolContext();
        public Personel()
        {
            InitializeComponent();
            cb_doldur();
            cb_gsdoldur();
            list();
        }
        public void cb_doldur()
        {
            cb_yCihaz.Items.Clear();
            var lcihaz = cntx.Cihaz.ToList();
            var lsirket = cntx.Sirket.ToList();
            cb_yCihaz.DataSource = lcihaz;
            cb_ysirket.DataSource = lsirket;
            cb_yCihaz.DisplayMember = "CihazNo";
            cb_yCihaz.ValueMember = "CihazId";
            cb_ysirket.DisplayMember = "SirketAdi";
            cb_ysirket.ValueMember = "SirketId";
        }
        public void cb_gsdoldur()
        {
            cb_gsCihaz.Items.Clear();
            var lcihaz = cntx.Cihaz.ToList();
            var lsirket = cntx.Sirket.ToList();
            cb_gsCihaz.DataSource = lcihaz;
            cb_gsSirket.DataSource = lsirket;
            cb_gsCihaz.DisplayMember = "CihazNo";
            cb_gsCihaz.ValueMember = "CihazId";
            cb_gsSirket.DisplayMember = "SirketAdi";
            cb_gsSirket.ValueMember = "SirketId";
        }
        public void list()
        {
            var query = cntx.Personel.Select(x => new
            {
                PeresonelId = x.PeresonelId,
                PersonelAdi = x.PersonelAdi,
                PersonelSoyAdi = x.PersonelSoyAdi,
                PersonelCinsiyet = x.PersonelCinsiyet,
                PersonelTC = x.PersonelTC,
                PersonelTelNO = x.PersonelTelNO,
                PersonelEmailAdresi = x.PersonelEmailAdresi,
                CihazId = x.Cihaz.CihazId,
                CihazNo = x.Cihaz.CihazNo,
                SirketId = x.Sirket.SirketId,
                SirketAdi = x.Sirket.SirketAdi,
            }).ToList();

            dataGridView1.DataSource = query;
            dataGridView1.Columns["CihazId"].Visible = false;
            dataGridView1.Columns["SirketId"].Visible = false;
            dataGridView1.Columns["PeresonelId"].Visible = false;

        }
        int PeresonelId = 0;
        int CihazId = 0;
        int SirketId = 0;
        string PersonelTC = "";
        string PersonelTelNO = "";
        string PersonelAdi = "";
        string PersonelSoyAdi = "";
        string emailadresi = "";
        string cinsiyet = "";
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            PeresonelId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["PeresonelId"].Value.ToString());
            CihazId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["CihazId"].Value.ToString());
            SirketId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["SirketId"].Value.ToString());
            PersonelAdi = dataGridView1.CurrentRow.Cells["PersonelAdi"].Value.ToString();
            PersonelSoyAdi = dataGridView1.CurrentRow.Cells["PersonelSoyAdi"].Value.ToString();
            PersonelTC = dataGridView1.CurrentRow.Cells["PersonelTC"].Value.ToString();
            PersonelTelNO = dataGridView1.CurrentRow.Cells["PersonelTelNO"].Value.ToString();
            emailadresi = dataGridView1.CurrentRow.Cells["PersonelEmailAdresi"].Value.ToString();
            cinsiyet = dataGridView1.CurrentRow.Cells["PersonelCinsiyet"].Value.ToString();
            txt_gsAdi.Text = PersonelAdi.ToString();
            txt_gsSoyadi.Text = PersonelSoyAdi.ToString();
            cb_gsCinsiyet.Text = cinsiyet.ToString();
            txt_gsMail.Text = emailadresi.ToString();
            txt_gsTc.Text = PersonelTC.ToString();
            mtxt_gsTel.Text = PersonelTelNO.ToString();
            cb_gsCihaz.SelectedValue = CihazId;
            cb_gsSirket.SelectedValue = SirketId;
        }

        private void btn_ekle_Click(object sender, EventArgs e)
        {

            try
            {
                // oluşturduğunuz dbcontext bir nesne olustur
                var personel = new Classlar.Personel();
                personel.PersonelAdi = txt_yAdi.Text;
                personel.PersonelSoyAdi = txt_ySoyadi.Text;
                personel.PersonelTelNO = mtxt_yTel.Text;
                personel.PersonelCinsiyet = cb_ycinsiyet.Text;
                personel.PersonelTC = txt_yTc.Text;
                personel.PersonelEmailAdresi = txt_ymail.Text;
                personel.CihazId = Convert.ToInt32(cb_yCihaz.SelectedValue.ToString());
                personel.SirketId = Convert.ToInt32(cb_ysirket.SelectedValue.ToString());

                cntx.Personel.Add(personel);
                cntx.SaveChanges();
            }
            catch (Exception hata)
            {
                MessageBox.Show("Lutfen veriyi bos gecmeyiniz");
            }
            finally
            {
                list();
                txt_yAdi.Text = "";
                txt_ySoyadi.Text = "";
                txt_yTc.Text = "";
                txt_ymail.Text = "";
                mtxt_yTel.Text = "";
                cb_ycinsiyet.Text = null;
                cb_yCihaz.Text = null;
                cb_ysirket.Text = null;
            }
        }

        private void btn_guncelle_Click(object sender, EventArgs e)
        {
            Classlar.Personel personel = cntx.Personel.FirstOrDefault(a => a.PeresonelId == PeresonelId);
            try
            {
                personel.PersonelAdi = txt_gsAdi.Text;
                personel.PersonelSoyAdi = txt_gsSoyadi.Text;
                personel.PersonelTelNO = mtxt_gsTel.Text;
                personel.PersonelCinsiyet = cb_gsCinsiyet.Text;
                personel.PersonelTC = txt_gsTc.Text;
                personel.PersonelEmailAdresi = txt_gsMail.Text;
                personel.CihazId = Convert.ToInt32(cb_gsCihaz.SelectedValue.ToString());
                personel.SirketId = Convert.ToInt32(cb_gsSirket.SelectedValue.ToString());
                cntx.SaveChanges();
            }
            catch (Exception hata)
            {
                MessageBox.Show("Lutfen veriyi bos gecmeyiniz");
            }
            finally
            {
                list();
                txt_yAdi.Text = "";
                txt_ySoyadi.Text = "";
                txt_yTc.Text = "";
                txt_ymail.Text = "";
                mtxt_yTel.Text = "";
                cb_ycinsiyet.Text = null;
                cb_yCihaz.Text = null;
                cb_ysirket.Text = null;
            }
        }

        private void btn_sil_Click(object sender, EventArgs e)
        {
            Classlar.Personel personel = cntx.Personel.FirstOrDefault(a => a.PeresonelId == PeresonelId);
            cntx.Personel.Remove(personel);
            list();
            txt_yAdi.Text = "";
            txt_ySoyadi.Text = "";
            txt_yTc.Text = "";
            txt_ymail.Text = "";
            mtxt_yTel.Text = "";
            cb_ycinsiyet.Text = null;
            cb_yCihaz.Text = null;
            cb_ysirket.Text = null;
        }

        private void btn_ara_Click(object sender, EventArgs e)
        {
            var ara = from x in cntx.Personel select x;
            if (txt_araadi.Text != null)
            {
                dataGridView1.DataSource = ara.Where(x => x.PersonelAdi.Contains(txt_araadi.Text)).ToList();
                dataGridView1.DataSource = ara.Where(x => x.PersonelSoyAdi.Contains(txt_araSoyadi.Text)).ToList();
            }
        }
    }
}
