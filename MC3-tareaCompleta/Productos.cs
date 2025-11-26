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
using MySql.Data.MySqlClient;


namespace MC3_tareaCompleta
{
    public partial class Productos : Form
    {
        private string connectionString;

        public Productos()
        {
            InitializeComponent();

            string configPath = Path.Combine(Application.StartupPath, "config.txt");
            connectionString = File.ReadAllText(configPath).Trim();
        }

        private string ConvertImageToBase64(Image image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, image.RawFormat);
                byte[] imageBytes = ms.ToArray();
                return Convert.ToBase64String(imageBytes);
            }
        }

        private void InsertProduct()
        {
            try
            {
                string nombreProducto = txtbProducto.Text;
                string descripcion = txtbDescripcion.Text;
                decimal precio = decimal.Parse(txtbPrecio.Text);
                string imgBase64 = pictureBoxBase64.Image != null ? ConvertImageToBase64(pictureBoxBase64.Image) : string.Empty;

                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    string query = "INSERT INTO productos (nombreProducto, descripcion, precio, imgBase64) " +
                                   "VALUES (@nombreProducto, @descripcion, @precio, @imgBase64)";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@nombreProducto", nombreProducto);
                        cmd.Parameters.AddWithValue("@descripcion", descripcion);
                        cmd.Parameters.AddWithValue("@precio", precio);
                        cmd.Parameters.AddWithValue("@imgBase64", imgBase64);
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Producto insertado correctamente.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al insertar el producto: {ex.Message}");
            }
        }


        private void btnGuardarProducto_Click(object sender, EventArgs e)
        {
            InsertProduct();
        }

        private void btnSeleccionarImagen_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Archivos de Imagen|*.jpg;*.png;*.gif;*.bmp";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBoxBase64.Image = Image.FromFile(openFileDialog.FileName);
                string imgBase64 = ConvertImageToBase64(pictureBoxBase64.Image);
            }

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtbProducto.Clear();
            txtbDescripcion.Clear();
            txtbPrecio.Clear();
            pictureBoxBase64.Image = null;

        }

        private void txtbProducto_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
