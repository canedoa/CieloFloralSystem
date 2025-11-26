using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;           
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CieloFloral
{
    public partial class CatalogoProveedor : Form
    {
       
        private string connectionString;

        public CatalogoProveedor()
        {
            InitializeComponent();

           
            string configPath = Path.Combine(Application.StartupPath, "config.txt");

            if (!File.Exists(configPath))
            {
                MessageBox.Show("No se encontró el archivo config.txt con la cadena de conexión.",
                    "Error de configuración",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            else
            {
                connectionString = File.ReadAllText(configPath).Trim();
            }
        }

        private void CargarDatosProveedores()
        {
            string query = "SELECT IdProveedor, nombreProveedor, apellidoProveedor, correoProveedor, telefonoProveedor, proveedorActivo FROM proveedores";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvProveedores.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar los datos: " + ex.Message,
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        private void CatalogoProveedor_Load(object sender, EventArgs e)
        {
            CargarDatosProveedores();
        }

        private void dgvProveedores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
