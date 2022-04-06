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
    public partial class BuscarMunicipio : Form
    {
        public BuscarMunicipio()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            String country = txtPais.Text;
            String dep = txtDepartamento.Text; 
            String mun = txtMunicpio.Text;  


            if(validateEmpty(country, dep, mun))
            {
                MessageBox.Show("No hay ningun parametro de busqueda");
            } else
            {
                StreamReader read = File.OpenText("Municipio.txt");
                String line;
                List<String> list = new List<String>();

                while ((line = read.ReadLine()) != null)
                {
                    list = line.Split('|').ToList();
                    if (list[1].Equals(country) || list[3].Equals(dep) || list[5].Equals(mun))
                    {
                        setValues(list);
                    }
                }
               
            }
        }

        private bool validateEmpty (String country, String dep, String mun)
        {
            return (String.IsNullOrEmpty(country) &&
                    String.IsNullOrEmpty(dep) &&
                    String.IsNullOrEmpty(mun));
        }

        private void setValues(List<String> list)
        {
            txtCodePais.Text = list[0];
            txtNombrePais.Text = list[1];
            txtCodigoDepartamento.Text = list[2];
            txtNombreDepartamento.Text = list[3];
            txtCodigoMunicipio.Text = list[4];
            txtNombreMunicipio.Text = list[5];
        }

    }
}
