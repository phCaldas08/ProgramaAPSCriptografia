using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Programa_APS.Classes;

namespace Programa_APS
{
    public partial class Form1 : Form
    {
        CriptografiaMatriz criptografar = new CriptografiaMatriz();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCriptografar_Click(object sender, EventArgs e)
        {
            txtCriptografado.Text = "";
            txtDescriptografado.Text = "";
            string aux = "";

            if (txtTexto.Text.Length > 27)
                aux = txtTexto.Text.Substring(0, 27);
            else
                aux = txtTexto.Text;

            //Passa o texto que sera criptografado para o método Criptografar
            List<List<int>> list = criptografar.Criptografar(aux);

            //Varre as linhas
            for (int i = 0; i < 9; i++)
            {
                //varre as colunas
                for (int j = 0; j < 3; j++)
                {
                    //mostra o texto criptografado numérico
                    txtCriptografado.Text += (list[i][j] + ",");
                }
            }

            //passa o texto criptografado para o método Descriptografar
            list = criptografar.Descriptografar(list);
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    //mostra o texto descriptografado
                    txtDescriptografado.Text += Convert.ToChar(list[i][j]);
                }
            }
        }       
    }
}
