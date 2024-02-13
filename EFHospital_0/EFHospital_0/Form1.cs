using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EFHospital_0.Models;

namespace EFHospital_0
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            _db= new HastaneDBEntities();
        
        }
       HastaneDBEntities _db;

        public void Ekle()
        {
            lstHastalar.DataSource = _db.Hastalars.ToList();
            lstHastalar.DisplayMember = "Isim";
            lstHastalar.SelectedIndex = -1;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Ekle();
            cmbDoktor.DataSource=_db.Doktorlars.ToList();
            cmbDoktor.DisplayMember = "Isim";
            cmbDoktor.SelectedIndex = -1;
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            Hastalar h=new Hastalar();
            h.Isim=txtHasta.Text;
            h.Doktorlar = cmbDoktor.SelectedItem as Doktorlar;
            _db.Hastalars.Add(h);
            _db.SaveChanges();
            Ekle();                
           
        }
        Hastalar hasta;
        private void btnSil_Click(object sender, EventArgs e)
        {
            if (lstHastalar.SelectedIndex >-1)
            {
                _db.Hastalars.Remove(hasta);
                _db.SaveChanges();
                Ekle();
                hasta = null;
            }
        }

        private void lstHastalar_Click(object sender, EventArgs e)
        {
            if(lstHastalar.SelectedIndex > -1)
            {
                hasta=lstHastalar.SelectedItem as Hastalar;
            }

        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (hasta!=null)
            {
                hasta.Isim = txtHasta.Text;
                hasta.Doktorlar = cmbDoktor.SelectedItem as Doktorlar;
                _db.SaveChanges();
                Ekle();
                hasta = null;
            }
        }
    }
}

