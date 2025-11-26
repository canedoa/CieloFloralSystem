using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.draw;
using System.Net;

namespace CieloFloral
{

    public partial class Reportes : Form
    {
        private string connectionString;
        private string smtpEmail;
        private string smtpPassword;

        public Reportes()
        {
            InitializeComponent();
            this.Load += Reportes_Load;
            dgvProductos.CellContentClick += dgvProductos_CellContentClick;

            string configPath = Path.Combine(Application.StartupPath, "config.txt");
            if (File.Exists(configPath))
            {
                connectionString = File.ReadAllText(configPath).Trim();
            }

            string emailConfigPath = Path.Combine(Application.StartupPath, "emailConfig.txt");
            if (File.Exists(emailConfigPath))
            {
                string[] lines = File.ReadAllLines(emailConfigPath);
                if (lines.Length >= 2)
                {
                    smtpEmail = lines[0].Trim();
                    smtpPassword = lines[1].Trim();
                }
            }
        }

        private void CargarDatos()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM productos";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    dgvProductos.DataSource = dataTable;


                    if (!dgvProductos.Columns.Contains("Generar Reporte"))
                    {

                        DataGridViewButtonColumn btnGenerarReporte = new DataGridViewButtonColumn();
                        btnGenerarReporte.HeaderText = "Generar Reporte";
                        btnGenerarReporte.Name = "Generar Reporte";
                        btnGenerarReporte.Text = "Generar Reporte";
                        btnGenerarReporte.UseColumnTextForButtonValue = true;
                        dgvProductos.Columns.Add(btnGenerarReporte);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos: " + ex.Message);
            }
        }

        private void dgvProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == dgvProductos.Columns["Generar Reporte"].Index && e.RowIndex >= 0)
            {
                int productId = Convert.ToInt32(dgvProductos.Rows[e.RowIndex].Cells["id"].Value);
                GenerarReporteProducto(productId);
            }
        }
        private void GenerarReporteProducto(int productId)
        {

            string query = "SELECT * FROM productos WHERE id = @productId";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@productId", productId);

                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {

                    Document document = new Document(PageSize.A4);
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "PDF Files (*.pdf)|*.pdf";
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string pdfPath = saveFileDialog.FileName;


                        PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(pdfPath, FileMode.Create));
                        document.Open();


                        string logoPath = "img/logo.png";
                        if (File.Exists(logoPath))
                        {
                            iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(logoPath);  // Usa iTextSharp.text.Image
                            logo.ScaleToFit(200f, 200f);
                            document.Add(logo);
                        }


                        PdfPTable table = new PdfPTable(2);

                        table.AddCell("Nombre Producto");
                        table.AddCell(reader["nombreProducto"].ToString());
                        table.AddCell("Descripción");
                        table.AddCell(reader["descripcion"].ToString());
                        table.AddCell("Precio");
                        table.AddCell(reader["precio"].ToString());


                        string imgBase64 = reader["imgBase64"].ToString();
                        if (!string.IsNullOrEmpty(imgBase64))
                        {
                            byte[] imageBytes = Convert.FromBase64String(imgBase64);
                            iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(imageBytes);


                            float maxWidth = 150f;
                            float maxHeight = 150f;
                            img.ScaleToFit(maxWidth, maxHeight);


                            PdfPCell imageCell = new PdfPCell(img);
                            imageCell.Colspan = 2;
                            imageCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            imageCell.FixedHeight = 160f;

                            table.AddCell(imageCell);
                        }


                        document.Add(table);
                        document.Close();


                        MessageBox.Show("Reporte generado exitosamente.");
                    }
                }
                else
                {
                    MessageBox.Show("Producto no encontrado.");
                }
            }
        }


        private void Reportes_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void btnGenerarReporteTodos_Click(object sender, EventArgs e)
        {



            GeneratePdfReport();

        }
        public void GeneratePdfReport()
        {

            Document document = new Document(PageSize.A4);
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PDF Files (*.pdf)|*.pdf";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string pdfPath = saveFileDialog.FileName;


                using (FileStream fs = new FileStream(pdfPath, FileMode.Create))
                {
                    PdfWriter writer = PdfWriter.GetInstance(document, fs);
                    document.Open();

                    BaseFont baseFont = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                    Font font = new Font(baseFont, 16);


                    Paragraph companyInfo = new Paragraph();

                    string logoPath = "img/logo.png";
                    if (File.Exists(logoPath))
                    {
                        iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(logoPath);
                        logo.ScaleToFit(200f, 200f);
                        logo.Alignment = Element.ALIGN_LEFT;
                        document.Add(logo);
                    }



                    companyInfo.Add(new Chunk("CieloFloral\n", font));
                    companyInfo.Add(new Chunk("Dirección: Calle de las Flores, Mérida, Yucatán\n"));
                    companyInfo.Add(new Chunk("Teléfono: (999) 123-4567\n"));
                    companyInfo.Add(new Chunk("Correo: contacto@cielofloral.com\n"));
                    companyInfo.Alignment = Element.ALIGN_LEFT;
                    document.Add(companyInfo);

                    // Línea separadora
                    LineSeparator line = new LineSeparator(1f, 100f, BaseColor.BLACK, Element.ALIGN_CENTER, -1);
                    document.Add(new Chunk(line));


                    document.Add(new Paragraph("\n"));



                    PdfPTable table = new PdfPTable(4);


                    table.AddCell("Nombre Producto");
                    table.AddCell("Descripción");
                    table.AddCell("Precio");
                    table.AddCell("Imagen");


                    foreach (DataGridViewRow row in dgvProductos.Rows)
                    {
                        if (row.IsNewRow) continue;

                        string nombreProducto = row.Cells["nombreProducto"].Value.ToString();
                        string descripcion = row.Cells["descripcion"].Value.ToString();
                        string precio = row.Cells["precio"].Value.ToString();
                        string imgBase64 = row.Cells["imgBase64"].Value.ToString();

                        // Decodificar la imagen base64
                        byte[] imageBytes = Convert.FromBase64String(imgBase64);


                        if (imageBytes.Length > 0)
                        {
                            try
                            {
                                iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(imageBytes);
                                img.ScaleToFit(50f, 50f);
                                table.AddCell(img);
                            }
                            catch (Exception ex)
                            {
                                table.AddCell("Imagen no válida");
                            }
                        }
                        else
                        {
                            table.AddCell("Imagen no disponible");
                        }


                        table.AddCell(nombreProducto);
                        table.AddCell(descripcion);
                        table.AddCell(precio);
                    }


                    document.Add(table);


                    document.Close();
                }


                MessageBox.Show("Reporte generado exitosamente.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCorreoDestino.Text))
            {
                MessageBox.Show("Por favor, ingresá el correo de destino.");
                return;
            }

            // Seleccionamos el archivo PDF
            OpenFileDialog abrir = new OpenFileDialog();
            abrir.Filter = "Archivos PDF (*.pdf)|*.pdf";
            abrir.Title = "Seleccionar PDF";
            if (abrir.ShowDialog() == DialogResult.OK)
            {
                string rutaPdf = abrir.FileName;

                try
                {
                    MailMessage mensaje = new MailMessage();
                    mensaje.From = new MailAddress(smtpEmail);
                    mensaje.To.Add(txtCorreoDestino.Text.Trim());
                    mensaje.Subject = "Te envío la cotización solicitada";
                    mensaje.Body = "Adjunto encontrarás el archivo PDF que seleccionaste.";

                    Attachment adjunto = new Attachment(rutaPdf);
                    mensaje.Attachments.Add(adjunto);

                    SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                    smtp.Credentials = new NetworkCredential(smtpEmail, smtpPassword);
                    smtp.EnableSsl = true;

                    smtp.Send(mensaje);

                    MessageBox.Show("Correo enviado correctamente.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al enviar el correo: " + ex.Message);
                }
            }

        }
    }
}
