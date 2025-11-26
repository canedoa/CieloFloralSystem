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
    public partial class Productos: Form
    {
      string connectionString = "server=bz3dmbyxjjyg90shengb-mysql.services.clever-cloud.com; database=bz3dmbyxjjyg90shengb; user=updsowqagabncdsq; password=O7g08TzRF8QQEc9E27NE; port=3306;";


        public Productos()
        {
            InitializeComponent();


        }
        private string ConvertImageToBase64(Image image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                // Guarda la imagen en un flujo de memoria
                image.Save(ms, image.RawFormat);
                byte[] imageBytes = ms.ToArray();

                // Convierte los bytes a una cadena Base64
                return Convert.ToBase64String(imageBytes);
            }
        }
        private void InsertProduct()
        {
            try
            {
                // Recoge los valores de los TextBoxes
                string nombreProducto = txtbProducto.Text;
                string descripcion = txtbDescripcion.Text;
                decimal precio = decimal.Parse(txtbPrecio.Text);
                string imgBase64 = pictureBoxBase64.Image != null ? ConvertImageToBase64(pictureBoxBase64.Image) : string.Empty;

                // Crear la conexión MySQL
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    // Comando SQL para insertar un nuevo producto
                    string query = "INSERT INTO productos (nombreProducto, descripcion, precio, imgBase64) " +
                                   "VALUES (@nombreProducto, @descripcion, @precio, @imgBase64)";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        // Parámetros para prevenir inyecciones SQL
                        cmd.Parameters.AddWithValue("@nombreProducto", nombreProducto);
                        cmd.Parameters.AddWithValue("@descripcion", descripcion);
                        cmd.Parameters.AddWithValue("@precio", precio);
                        cmd.Parameters.AddWithValue("@imgBase64", imgBase64);

                        // Ejecutar la inserción
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
                // Cargar la imagen en el PictureBox
                pictureBoxBase64.Image = Image.FromFile(openFileDialog.FileName);

                // Convertir la imagen a Base64 y almacenar en el PictureBox
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

        
    }
}
