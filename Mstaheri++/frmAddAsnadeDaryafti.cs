﻿using CarpetCompanyBLL;
using CarpetCompanyDAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Stimulsoft.Report.StiOptions.Viewer;

namespace Mstaheri__
{
    public partial class frmAddAsnadeDaryafti : Form
    {
        CarpetCompanyBLL.classAsnadeDaryafti Daryaft;
        CarpetCompanyDAL.Mali mal;
        public frmAddAsnadeDaryafti()
        {
            InitializeComponent();
            Daryaft = new CarpetCompanyBLL.classAsnadeDaryafti();
            mal = new CarpetCompanyDAL.Mali();
        }
        private async void button1_Click(object sender, EventArgs e)
        {
            string codeSenad = txtCodeSenad.Text;
            string shomareHesab = comShomareHesab.Text;
            string namHesab = txtNamHesab.Text;
            string daryaft = txtDaryaft.Text;
            string shomareSenad = txtShomareSenad.Text;
            string tarikhSabt = txtTarikhSabt.Text;
            string tarikhSarResid = txtTarikhSarResid.Text;
            string price = txtPrice.Text;
            string tozihat = txtTozihat.Text;
            string vaziat = comVaziat.Text;
            string textForm = this.Text;
            if (this.Text == "Save")
            {
                await Task.Run(() =>
                {
                    var check = Daryaft.Insert(codeSenad, shomareHesab, namHesab, daryaft, shomareSenad,
                    tarikhSabt, tarikhSarResid, price, tozihat, vaziat);
                    if (check.Success == true)
                    {
                        MessageBox.Show(check.Message);
                    }
                    else
                    {
                        MessageBox.Show(check.Message);
                    }
                });
                foreach (var item in this.Controls)
                {
                    if (item is TextBox)
                    {
                        TextBox txt = item as TextBox;
                        txt.Text = "";
                    }
                }

            }
            else if (this.Text == "Edit" || this.Text == "Edit2")
            {
                await Task.Run(() =>
                {
                     var check = Daryaft.Update(codeSenad, shomareHesab, namHesab, daryaft, shomareSenad,
                    tarikhSabt, tarikhSarResid, price, tozihat, vaziat, textForm);
                    if (check.Success == true)
                    {
                        MessageBox.Show(check.Message);
                    }
                    else
                    {
                        MessageBox.Show(check.Message);
                    }
                });
                this.Close();
            }
            
              


        }

        private void txtCodeSenad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(e.KeyChar >= '0' && e.KeyChar <= '9') && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void comVaziat_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comVaziat_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void txtPrice_TextChanged(object sender, EventArgs e)
        {
            string harf = CarpetCompanyDAL.NumberToStringConverter.Convert(txtPrice.Text);
            if (txtPrice.Text != "")
            {
                string st = decimal.Parse(txtPrice.Text).ToString("N0");
                toolTip1.SetToolTip(txtPrice, st + "--" + harf);
            }
            else
            {
                toolTip1.SetToolTip(txtPrice, "" + "--" + "");
            }
        }

        private void frmAddAsnadeDaryafti_Load(object sender, EventArgs e)
        {

        }

        private void comShomareHesab_SelectedIndexChanged(object sender, EventArgs e)
        {
            var check = mal.SelectNamHesab(comShomareHesab.Text);
            if (check.Success == true)
            {
                txtNamHesab.Text = check.Data;
            }
            else
            {
                MessageBox.Show(check.Message);
            }
        }
    }
}
