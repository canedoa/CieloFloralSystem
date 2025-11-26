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
using MC3_tareaCompleta;

namespace CieloFloral
{
    public partial class agregarUsuarios: Form
    {
        public agregarUsuarios()
        {
            InitializeComponent();
        }
        string connectionString = "server=bz3dmbyxjjyg90shengb-mysql.services.clever-cloud.com; database=bz3dmbyxjjyg90shengb; user=updsowqagabncdsq; password=O7g08TzRF8QQEc9E27NE; port=3306;";
        private void InsertUsuario()
        {
            try
            {
                string usuario = txtbUsuario.Text;
                string password = txtbPassword.Text;
                bool activo = chUsuario.Checked;



                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "INSERT INTO usuarios (nombreUsuario, password, Activo) " +
                              "VALUES (@nombreUsuario, @Password, @activo)";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@nombreUsuario",usuario);
                        cmd.Parameters.AddWithValue("@Password", password);
                        cmd.Parameters.AddWithValue("@activo", activo);
                        cmd.ExecuteNonQuery();

                    }
                    MessageBox.Show("Usuario agregado correctamente.");

                }

            }

            catch (Exception ex)

            {
                MessageBox.Show("Error al insertar usuario: " + ex.Message);

            }


        }
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtbUsuario.Clear();
            txtbPassword.Clear();
            chUsuario.Checked = false;
        }

        private void btnGuardarProducto_Click(object sender, EventArgs e)
        {
            InsertUsuario();
        }

        
    }
}
