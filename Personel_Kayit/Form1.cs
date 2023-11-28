﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Personel_Kayit
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            label8.Visible = false;
        }
       
        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            label8.Visible = true;
          if(radioButton1.Checked == true)
            {
                label8.Text = "True";
            }
            else if (radioButton1.Checked == false)
            {
                radioButton1.Checked = false;
            }

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            label8.Visible = true;
            if (radioButton2.Checked == true)
            {
                label8.Text = "False";
            }
            else if(radioButton2.Checked == false)
            {
                radioButton2.Checked = false;
            }
            
        }
        SqlConnection baglanti = new SqlConnection ("Data Source=DESKTOP-33VDDOP\\SQLEXPRESS04;Initial Catalog=PersonelVeriTabani;Integrated Security=True");

        void temizle()
        {
            Txtid.Text = "";
            TxtAd.Text = "";
            TxtSoyad.Text = "";
            CmbSehir.Text = "";
            MskMaas.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            TxtMeslek.Text = "";
            TxtAd.Focus();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

            this.tbl_PersonelTableAdapter.Fill(this.personelVeriTabaniDataSet.Tbl_Personel);

        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            this.tbl_PersonelTableAdapter.Fill(this.personelVeriTabaniDataSet.Tbl_Personel);
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into Tbl_Personel (PerAd,PerSoyad,PerSehir,PerMaas,PerMeslek,PerDurum) values (@p1,@p2,@p3,@p4,@p5,@p6)", baglanti);
            komut.Parameters.AddWithValue("@p1", TxtAd.Text);
            komut.Parameters.AddWithValue("@p2", TxtSoyad.Text);
            komut.Parameters.AddWithValue("@p3", CmbSehir.Text);
            komut.Parameters.AddWithValue("@p4", MskMaas.Text);
            komut.Parameters.AddWithValue("@p5", TxtMeslek.Text);
            komut.Parameters.AddWithValue("@p6", label8.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
        }

        private void TxtMeslek_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            Txtid.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            TxtAd.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            TxtSoyad.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            CmbSehir.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            MskMaas.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            label8.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            TxtMeslek.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();

        }

        private void label8_TextChanged(object sender, EventArgs e)
        {
            if(label8.Text == "True")
            {
                radioButton1.Checked = true;
            }
            if(label8.Text == "False")
            {
                radioButton2.Checked = true;
            }
            
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand sil = new SqlCommand("Delete From Tbl_Personel Where Personelid = @k1",baglanti);
            sil.Parameters.AddWithValue("@k1", Txtid.Text);
            sil.ExecuteNonQuery();
            baglanti.Close();
        }

        private void BtnGüncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand guncelle = new SqlCommand("Update Tbl_Personel Set PerAD=@a1,PerSoyad=@a2,PerSehir=@a3,PerMaas=@a4,PerDurum=@a5,PerMeslek=@a6 where Personelid=@a7",baglanti);
            guncelle.Parameters.AddWithValue("@a1", TxtAd.Text);
            guncelle.Parameters.AddWithValue("@a2", TxtSoyad.Text);
            guncelle.Parameters.AddWithValue("@a3", CmbSehir.Text);
            guncelle.Parameters.AddWithValue("@a4", MskMaas.Text);
            guncelle.Parameters.AddWithValue("@a5", label8.Text);
            guncelle.Parameters.AddWithValue("@a6", TxtMeslek.Text);
            guncelle.Parameters.AddWithValue("@a7", Txtid.Text);


            guncelle.ExecuteNonQuery();
            
            baglanti.Close();
            MessageBox.Show("Personel bilgisi güncellendi..!");
        }
    }
}
