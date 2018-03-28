using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Home_Bugaltery
{
    public partial class SaldoForm : Form
    {
        HomeBugaltery homeBugaltery;
        decimal sumDebet = 0;
        decimal sumCredit = 0;

        public SaldoForm(HomeBugaltery homeBugaltery)
        {
            InitializeComponent();

            this.homeBugaltery = homeBugaltery;


            panelDate.Enabled = checkBoxDate.Checked;

            homeBugaltery.calculateUsersSaldo();
            updateSaldoForm();
        }

        public void updateSaldoForm()
        {
            decimal sumDebet = 0;
            decimal sumCredit = 0;
            decimal sumSaldo = 0;
            dataGridViewSaldo.Rows.Clear();
            foreach (var saldo in homeBugaltery.UsersSaldo)
            {
                int rowsIndex = dataGridViewSaldo.Rows.Add(saldo.UserName);

                dataGridViewSaldo.Rows[rowsIndex].Cells[1].Value = saldo.Debet;
                dataGridViewSaldo.Rows[rowsIndex].Cells[2].Value = saldo.Credit;
                dataGridViewSaldo.Rows[rowsIndex].Cells[3].Value = saldo.Saldo;
                sumDebet += saldo.Debet;
                sumCredit += saldo.Credit;
                sumSaldo += saldo.Saldo;

            }

            textBoxExpenses.Text = sumDebet.ToString();
            textBoxRevenues.Text = sumCredit.ToString();
            textBoxSaldo.Text = sumSaldo.ToString();

        }

        private void checkBoxDate_CheckedChanged(object sender, EventArgs e)
        {
            panelDate.Enabled = checkBoxDate.Checked;
        }

        private void btnAply_Click(object sender, EventArgs e)
        {
            if (checkBoxDate.Checked)
                homeBugaltery.calculateUsersSaldo(dateTimeFor.Value, dateTimeTo.Value);
            else
                homeBugaltery.calculateUsersSaldo();
            
            updateSaldoForm();
        }

        private void btnClouse_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
