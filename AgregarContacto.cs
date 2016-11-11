using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace LlamadaParaPruebas
{
    public partial class AgregarContacto : DevExpress.XtraEditors.XtraForm
    {
        string cliente = "";
        string sec = "";
        public AgregarContacto(string _cliente, string _sec)
        {
            cliente = _cliente;
            sec = _sec;
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = "";
            if (this.txtNombre.Text == "")
            {
                MessageBox.Show("Debe indicar el nombre que desea a agregar.");
            }
            else
            {
                sql = "insert into crm_contactos(cliente, nombre,cargo, correo,telefonos,status) " +
                 " values('" + this.lblCodigoCliente.Text + "','" + this.txtNombre.Text + "', '" + this.txtCargo.Text + "', '" + this.txtCorreo.Text + "', '" + this.txtTelefono.Text + "', 1)";
                AccesoDatos.EjecutaQuerySql(sql);
                Close();
            }
        }

        private void AgregarContacto_Load(object sender, EventArgs e)
        {
            this.lblCodigoCliente.Text = cliente;
            this.lblSec.Text = sec;
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}