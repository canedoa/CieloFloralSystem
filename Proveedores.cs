using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CieloFloral
{
    public partial class Proveedores: Form
    {
        public Proveedores()
        {
            InitializeComponent();
        }

        string connectionString = "server=bz3dmbyxjjyg90shengb-mysql.services.clever-cloud.com; database=bz3dmbyxjjyg90shengb; user=updsowqagabncdsq; password=O7g08TzRF8QQEc9E27NE; port=3306;";

        private void btnGuardarProducto_Click(object sender, EventArgs e)
        {
            InsertarProveedor();
        }

        private void InsertarProveedor()
        {
            try
            {
                string NomCliente = txtbNomCliente.Text;
                string apellido = txtbApellido.Text;
                string correo = txtbcorreo.Text;
                string telefono = texttelefono.Text;
                bool ActivoCliente = chActivoCliente.Checked;
                int valorActivo = ActivoCliente ? 1 : 0;




                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "INSERT INTO proveedores (nombreProveedor, apellidoProveedor, correoProveedor, telefonoProveedor, proveedorActivo)" + "VALUES (@nombre, @apellido, @correo, @telefono, @activo)";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@nombre", NomCliente);
                        cmd.Parameters.AddWithValue("@apellido", apellido);
                        cmd.Parameters.AddWithValue("@correo", correo);
                        cmd.Parameters.AddWithValue("@telefono", telefono);
                        cmd.Parameters.AddWithValue("@activo", valorActivo);
                        cmd.ExecuteNonQuery();

                    }

                    MessageBox.Show("Proveedor agregado correctamente.");
                }


            }

            catch (Exception ex)
            {

                MessageBox.Show("Error al insertar Cliente: " + ex.Message);

            }


        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtbNomCliente.Clear();
            txtbcorreo.Clear();
            txtbApellido.Clear();
            texttelefono.Clear();
            chActivoCliente.Checked = false;
        }
    }
}
