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
    public partial class CatalogoProveedor: Form
    {
        public CatalogoProveedor()
        {
            InitializeComponent();
        }

        string connectionString = "server=bz3dmbyxjjyg90shengb-mysql.services.clever-cloud.com; database=bz3dmbyxjjyg90shengb; user=updsowqagabncdsq; password=O7g08TzRF8QQEc9E27NE; port=3306;";


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
                    MessageBox.Show("Error al cargar los datos: " + ex.Message);
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
