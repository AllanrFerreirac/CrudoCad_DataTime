using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUDBARTO
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Cadastro cadastro = new Cadastro();
            cadastro.Inserir(txtNome.Text, dtpDate.Value.Date, txtEmail.Text, txtCelular.Text, txtCidade.Text);
            MessageBox.Show("Cadastro Realizado com secesso!");
            List<Cadastro> cadastros = cadastro.listacadastro();
            dgvCad.DataSource = cadastros;
            txtNome.Text = "";
            dtpDate.Value = DateTime.Now.Date;
            txtEmail.Text = "";
            txtCelular.Text = "";
            txtCidade.Text = "";
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            int Id = Convert.ToInt32(txtId.Text.Trim());
            Cadastro cadastro = new Cadastro();
            cadastro.Localiza(Id);
            txtNome.Text = cadastro.nome;
            dtpDate.Text = cadastro.data_nas;
            txtEmail.Text = cadastro.email;
            txtCelular.Text = cadastro.celular;
            txtCidade.Text = cadastro.cidade;
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvCad_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Cadastro cadastro = new Cadastro();
            List<Cadastro> cadastros = cadastro.listacadastro();
            dgvCad.DataSource = cadastros;
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            int Id = Convert.ToInt32(txtId.Text.Trim());
            Cadastro cadastro = new Cadastro();
            cadastro.Excluir(Id);
            MessageBox.Show("Cadastro Excluido com secesso!");
            List<Cadastro> cadastros = cadastro.listacadastro();
            dgvCad.DataSource = cadastros;
            txtNome.Text = "";
            dtpDate.Value = DateTime.Now.Date;
            txtEmail.Text = "";
            txtCelular.Text = "";
            txtCidade.Text = "";
        }

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
