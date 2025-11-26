using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using MC3_tareaCompleta;
using System.Drawing;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;
using iText.StyledXmlParser.Jsoup.Select;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.IO; 

namespace CieloFloral
{
    public partial class login : Form
    {
       
        private string connectionString;

        public login()
        {
            InitializeComponent();

            
            string configPath = Path.Combine(Application.StartupPath, "config.txt");

            if (File.Exists(configPath))
            {
             
                connectionString = File.ReadAllText(configPath).Trim();
            }
            else
            {
                MessageBox.Show(
                    "No se encontró el archivo 'config.txt' con la configuración de la base de datos.\n\n" +
                    "Crea un archivo config.txt en la carpeta del ejecutable con la cadena de conexión.",
                    "Error de configuración",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                
            }
        }

        private void btnlogin_Click_1(object sender, EventArgs e)
        {
            string usuario = txtusuario.Text.Trim();
            string password = txtpassword.Text;

          
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                MessageBox.Show(
                    "La cadena de conexión no está configurada. Verifica el archivo config.txt.",
                    "Error de conexión",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    string query = "SELECT IdUsuario, nombreUsuario " +
                                   "FROM usuarios " +
                                   "WHERE nombreUsuario = @usuario " +
                                   "AND password = @password " +
                                   "AND Activo = 1";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@usuario", usuario);
                        cmd.Parameters.AddWithValue("@password", password);

                     
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int idUsuario = reader.GetInt32("IdUsuario");
                                string nombreUsuario = reader.GetString("nombreUsuario");

                                MessageBox.Show("Inicio de sesión exitoso.");

                                this.Hide();

                                
                                FormMenu panel = new FormMenu(idUsuario, nombreUsuario);
                                panel.Show();
                            }
                            else
                            {
                                MessageBox.Show(
                                    "Usuario o contraseña incorrectos.",
                                    "Error",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error
                                );
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "Error: " + ex.Message,
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
        }

        private void btncerrar_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtusuario_TextChanged(object sender, EventArgs e)
        {
            txtusuario.Padding = new Padding(5);
        }
    }
}
