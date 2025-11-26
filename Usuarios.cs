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

namespace CieloFloral
{
    public partial class Usuarios: Form
    {
        public Usuarios()
        {
            InitializeComponent();
        }
        private string connectionString = "server=bz3dmbyxjjyg90shengb-mysql.services.clever-cloud.com; database=bz3dmbyxjjyg90shengb; user=updsowqagabncdsq; password=O7g08TzRF8QQEc9E27NE; port=3306;";
       
        private void CargarUsuarios()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT IdUsuario, nombreUsuario, password, Activo FROM usuarios";

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn))
                    {
                        DataTable tablaUsuarios = new DataTable();
                        adapter.Fill(tablaUsuarios);
                        dgvUsuarios.DataSource = tablaUsuarios;

                       // Convertir columna "activo" en checkbox
                        dgvUsuarios.Columns["activo"].HeaderText = "Activo";
                        dgvUsuarios.Columns["activo"].ReadOnly = false;
                        dgvUsuarios.Columns["activo"].CellTemplate = new DataGridViewCheckBoxCell();

                        //otras columnas solo lectura
                        dgvUsuarios.Columns["IdUsuario"].ReadOnly = true;
                        dgvUsuarios.Columns["nombreUsuario"].ReadOnly = true;
                        dgvUsuarios.Columns["password"].ReadOnly = true;

                        if (!dgvUsuarios.Columns.Contains("btnModificar"))
                        {
                            DataGridViewButtonColumn btnModificar = new DataGridViewButtonColumn();
                            btnModificar.HeaderText = "Acción";
                            btnModificar.Text = "Modificar";
                            btnModificar.UseColumnTextForButtonValue = true;
                            btnModificar.Name = "btnModificar";
                            dgvUsuarios.Columns.Add(btnModificar);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar usuarios: " + ex.Message);
                }

            }

        }

        private void Usuarios_Load(object sender, EventArgs e)
        {
            CargarUsuarios();
            dgvUsuarios.CellClick += dgvUsuarios_CellClick;
        }

        private void ActualizarEstadoUsuario(int idUsuario, bool activo)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "UPDATE usuarios SET Activo = @activo WHERE IdUsuario = @idUsuario";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@activo", activo ? 1 : 0);
                        cmd.Parameters.AddWithValue("@idUsuario", idUsuario);
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Estado del usuario actualizado correctamente.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar usuario: " + ex.Message);
            }
        }

        private void dgvUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvUsuarios.Columns[e.ColumnIndex].Name == "btnModificar")
            {
                // Obtener valores de la fila seleccionada
                int idUsuario = Convert.ToInt32(dgvUsuarios.Rows[e.RowIndex].Cells["IdUsuario"].Value);
                bool activo = Convert.ToBoolean(dgvUsuarios.Rows[e.RowIndex].Cells["activo"].Value);

                // Llamar al método que actualiza el estado
                ActualizarEstadoUsuario(idUsuario, activo);

                // Recargar la tabla
                CargarUsuarios();
            }
        }

       
    }
}
