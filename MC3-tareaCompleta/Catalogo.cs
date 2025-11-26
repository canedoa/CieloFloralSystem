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

namespace MC3_tareaCompleta
{
    public partial class Catalogo : Form
    {

        private string connectionString;

        public Catalogo()
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

        private void Catalogo_Load(object sender, EventArgs e)
        {
            this.dgvCatalogo.CellClick += new DataGridViewCellEventHandler(this.dgvCatalogo_CellContentClick);
        }

        public DataGridView ObtenerDataGridView()
        {
            return dgvCatalogo;
        }

        public void CargarDatos()
        {
            try
            {
                

                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    string query = "SELECT * FROM productos";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dgvCatalogo.DataSource = dt; // Asigna los datos al DataGridView
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar productos: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void dgvCatalogo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // para verificar que se dio clic en la columna de botones "VisualizarProducto"
            if (e.ColumnIndex == dgvCatalogo.Columns["VisualizarProducto"].Index)
            {
                // se obtiene la cadena base64 de la fila seleccionada (de la columna "imgBase64")
                string base64Image = dgvCatalogo.Rows[e.RowIndex].Cells["imgBase64"].Value.ToString();

                // Crea una nueva instancia de FormImagen
                FormImagen formImagen = new FormImagen();

                // MostrarImagen y pasa la cadena base64
                formImagen.MostrarImagen(base64Image);

                // mostrar formulario con la imagen
                formImagen.Show();
            }
        }

        private void dgvCatalogo_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            // Verifica si la celda actual es una celda de botón en la columna VisualizarProducto
            if (e.RowIndex >= 0 && e.ColumnIndex == dgvCatalogo.Columns["VisualizarProducto"].Index)
            {
                // Prevenir la pintura predeterminada
                e.Handled = true;

                // Obtén el rectángulo de la celda
                Rectangle cellRect = e.CellBounds;

                // Calcula el radio para un círculo o elipse
                int radius = Math.Min(cellRect.Width, cellRect.Height) / 2;
                Rectangle circleRect = new Rectangle(
                    cellRect.X + (cellRect.Width / 2 - radius),
                    cellRect.Y + (cellRect.Height / 2 - radius),
                    radius * 2,
                    radius * 2
                );

                // Dibuja el fondo del botón
                using (Brush brush = new SolidBrush(Color.LightSkyBlue))  // Cambia el color de fondo
                {
                    e.Graphics.FillRectangle(brush, cellRect);
                }

                // Dibuja el borde del botón
                using (Pen pen = new Pen(Color.White))  // Cambia el color del borde
                {
                    e.Graphics.DrawRectangle(pen, cellRect);
                }

                using (Brush textBrush = new SolidBrush(Color.White))
                {
                    // Si e.Value es null, muestra "Ver". Si tiene valor, muestra ese valor.
                    string displayText = e.Value?.ToString() ?? "Ver";

                    StringFormat stringFormat = new StringFormat
                    {
                        Alignment = StringAlignment.Center,      // Alinea el texto al centro
                        LineAlignment = StringAlignment.Center  // Alinea el texto verticalmente en el centro
                    };

                    // Dibuja el texto dentro del círculo
                    e.Graphics.DrawString(displayText, e.CellStyle.Font, textBrush, circleRect, stringFormat);
                }
            }
        }
    }
}
