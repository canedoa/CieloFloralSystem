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

namespace MC3_tareaCompleta
{
    public partial class FormImagen: Form
    {
        public FormImagen()
        {
            InitializeComponent();
        }

        private void FormImagen_Load(object sender, EventArgs e)
        {

        }
        // Este método se encuentra en el formulario FormImagen
        public void MostrarImagen(string base64Image)
        {
            try
            {
                // Convierte la cadena base64 a un arreglo de bytes
                byte[] imageBytes = Convert.FromBase64String(base64Image);

                // Crea un flujo de memoria con los bytes de la imagen
                using (MemoryStream ms = new MemoryStream(imageBytes))
                {
                    // Asigna la imagen al PictureBox
                    pictureBox.Image = Image.FromStream(ms);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al mostrar la imagen: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
