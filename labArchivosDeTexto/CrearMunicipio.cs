using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace labArchivosDeTexto
{
    public partial class CrearMunicipio : Form
    {
        public CrearMunicipio()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            StreamWriter write = File.AppendText("Municipio.txt");

            String codeCountry = txtCodePais.Text;
            String country = txtNombrePais.Text;   //1
            String codeDep = txtCodigoDepartamento.Text;
            String dep = txtNombreDepartamento.Text; //3
            String codeMun = txtCodigoMunicipio.Text;
            String mun = txtNombreMunicipio.Text;    //5

            if (validateEmpty(codeCountry, country, codeDep, dep, codeMun, mun))
            {
                MessageBox.Show("No puede dejar campos vacíos");
                write.Close();
            } else
            {
                write.Close();
                if (validateDuplicate(country, dep, mun))
                {
                    MessageBox.Show("Este registro ya existe");
                    write.Close();
                } else
                {
                    write = File.AppendText("Municipio.txt");
                    write.Write(codeCountry + "|");
                    write.Write(country + "|");
                    write.Write(codeDep + "|");
                    write.Write(dep + "|");
                    write.Write(codeMun + "|");
                    write.Write(mun);
                    write.WriteLine();
                    write.Close();

                    MessageBox.Show("Registro almacenado exitosamente");
                    limpiar();
                }
            }
            

        }

        private bool validateEmpty(String codeCountry, String country, String codeDep, String dep, String codeMun, String mun)
        {
            return (String.IsNullOrEmpty(codeCountry.Trim())    ||
                    String.IsNullOrEmpty(country.Trim())        ||
                    String.IsNullOrEmpty(codeDep.Trim())        ||
                    String.IsNullOrEmpty(dep.Trim())            ||
                    String.IsNullOrEmpty(codeMun.Trim())        ||
                    String.IsNullOrEmpty(mun.Trim()));
        }

        private bool validateDuplicate(String country, String dep, String mun)
        {
            StreamReader read = File.OpenText("Municipio.txt");
            String line;  
            List<String> list = new List<String>();

            while ((line = read.ReadLine()) != null)
            {
                list = line.Split('|').ToList();

                if (list[1].Equals(country) && list[3].Equals(dep) && list[5].Equals(mun))
                {
                    read.Close();
                    return true;
                }
            }
            read.Close();
            return false;
        }

        private void limpiar()
        {
            txtCodePais.Text = "";
            txtNombrePais.Text = "";
            txtCodigoDepartamento.Text = "";
            txtNombreDepartamento.Text = "";
            txtCodigoMunicipio.Text = "";
            txtNombreMunicipio.Text = "";
        }

    }
}
