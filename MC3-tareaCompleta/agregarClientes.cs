using iText.Commons.Utils;
using MySql.Data.MySqlClient;
using Mysqlx.Prepare;
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

namespace CieloFloral
{
    public partial class agregarClientes : Form
    {
        private string connectionString;

        public agregarClientes()
        {
            InitializeComponent();

            string configPath = Path.Combine(Application.StartupPath, "config.txt");
            connectionString = File.ReadAllText(configPath).Trim();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtbNomCliente.Clear();
            txtbcorreo.Clear();
            txtbApellido.Clear();
            texttelefono.Clear();
            chActivoCliente.Checked = false;
        }

        private void InsertarCliente()
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
                    string query = "INSERT INTO clientes (nombreCliente, apellidoCliente, correo, telefono, activo)" +
                                   "VALUES (@nombre, @apellido, @correo, @telefono, @activo)";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@nombre", NomCliente);
                        cmd.Parameters.AddWithValue("@apellido", apellido);
                        cmd.Parameters.AddWithValue("@correo", correo);
                        cmd.Parameters.AddWithValue("@telefono", telefono);
                        cmd.Parameters.AddWithValue("@activo", valorActivo);
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Cliente agregado correctamente.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar Cliente: " + ex.Message);
            }
        }

        private void btnGuardarProducto_Click(object sender, EventArgs e)
        {
            InsertarCliente();
        }

        private void txtbNomCliente_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
