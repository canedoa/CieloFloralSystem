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
using static System.Resources.ResXFileRef;
using System.IO;

namespace CieloFloral
{
    public partial class Clientes : Form
    {
        public Clientes()
        {
            InitializeComponent();
            string configPath = Path.Combine(Application.StartupPath, "config.txt");
            connectionString = File.ReadAllText(configPath).Trim();
        }

        private string connectionString;



        private void CargarClientes()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {


                try
                {
                    //abrimos la conexion a la bdd y posterior la query
                    conn.Open();
                    string query = "select IdCliente, nombreCliente, apellidoCliente, correo, telefono, fechaRegistro, activo  from clientes";
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn))
                    {
                        DataTable tablaClientes = new DataTable();
                        adapter.Fill(tablaClientes);
                        dgvClientes.DataSource = tablaClientes;

                        // Convertir columna "activo" en checkbox
                        dgvClientes.Columns["activo"].HeaderText = "activo";
                        dgvClientes.Columns["activo"].ReadOnly = false;
                        dgvClientes.Columns["activo"].CellTemplate = new DataGridViewCheckBoxCell();

                        if (!dgvClientes.Columns.Contains("btnModificar"))
                        {
                            DataGridViewButtonColumn btnModificar = new DataGridViewButtonColumn();
                            btnModificar.HeaderText = "Acción";
                            btnModificar.Text = "Modificar";
                            btnModificar.UseColumnTextForButtonValue = true;
                            btnModificar.Name = "btnModificar";
                            dgvClientes.Columns.Add(btnModificar);
                        }

                    }

                }

                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar Clientes: " + ex.Message);

                }


            }


        }


        private void Clientes_Load(object sender, EventArgs e)
        {
            CargarClientes();
            dgvClientes.CellClick += dgvClientes_CellClick;

        }
        private void ActualizarCliente(int id, string nombre, string apellido, string correo, string telefono, bool activo)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "UPDATE clientes SET nombreCliente = @nombre, apellidoCliente = @apellido, correo = @correo, telefono = @telefono, activo = @activo WHERE IdCliente = @id";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@nombre", nombre);
                        cmd.Parameters.AddWithValue("@apellido", apellido);
                        cmd.Parameters.AddWithValue("@correo", correo);
                        cmd.Parameters.AddWithValue("@telefono", telefono);
                        cmd.Parameters.AddWithValue("@activo", activo ? 1 : 0);
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Cliente actualizado correctamente.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar cliente: " + ex.Message);
            }
        }

        private void dgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvClientes.Columns[e.ColumnIndex].Name == "btnModificar")
            {
                // Obtener valores de la fila seleccionada
                int idCliente = Convert.ToInt32(dgvClientes.Rows[e.RowIndex].Cells["IdCliente"].Value);
                string nombre = dgvClientes.Rows[e.RowIndex].Cells["nombreCliente"].Value.ToString();
                string apellido = dgvClientes.Rows[e.RowIndex].Cells["apellidoCliente"].Value.ToString();
                string correo = dgvClientes.Rows[e.RowIndex].Cells["correo"].Value.ToString();
                string telefono = dgvClientes.Rows[e.RowIndex].Cells["telefono"].Value.ToString();
                bool activo = Convert.ToBoolean(dgvClientes.Rows[e.RowIndex].Cells["activo"].Value);

                // llamamos a método para actualizar en la base de datos
                ActualizarCliente(idCliente, nombre, apellido, correo, telefono, activo);

                // actualizar la tabla
                CargarClientes();
            }
        }

        private void dgvClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
