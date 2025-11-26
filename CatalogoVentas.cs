using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.draw;


namespace CieloFloral
{
    public partial class CatalogoVentas : Form
    {
        public CatalogoVentas()
        {
            InitializeComponent();
        }

        string connectionString = "server=bz3dmbyxjjyg90shengb-mysql.services.clever-cloud.com;database=bz3dmbyxjjyg90shengb;user=updsowqagabncdsq;password=O7g08TzRF8QQEc9E27NE;port=3306;SslMode=Preferred;";

        private void CatalogoVentas_Load(object sender, EventArgs e)
        {
            CargarDatosVentas();
            AgregarBotones();
            dgvCatalogoVentas.CellContentClick += dgvCatalogoVentas_CellContentClick;


        }
        private void CargarDatosVentas()
        {
            string query = "SELECT * FROM ventas"; // Aquí es donde haces la consulta SQL.



            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
            
                    dgvCatalogoVentas.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar los datos: " + ex.Message);
                }
            }
        }
        
        private void AgregarBotones()
            {
                if (!dgvCatalogoVentas.Columns.Contains("btnGenerarPDF"))
                {
                    DataGridViewButtonColumn btnPDF = new DataGridViewButtonColumn
                    {
                        Name = "btnGenerarPDF",
                        HeaderText = "Acciones",
                        Text = "Generar PDF",
                        UseColumnTextForButtonValue = true
                    };
                    dgvCatalogoVentas.Columns.Add(btnPDF);
                }

                if (!dgvCatalogoVentas.Columns.Contains("btnEnviarCorreo"))
                {
                    DataGridViewButtonColumn btnMail = new DataGridViewButtonColumn
                    {
                        Name = "btnEnviarCorreo",
                        HeaderText = "Correo",
                        Text = "Enviar PDF",
                        UseColumnTextForButtonValue = true
                    };
                    dgvCatalogoVentas.Columns.Add(btnMail);
                }
        }

        private void dgvCatalogoVentas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string columna = dgvCatalogoVentas.Columns[e.ColumnIndex].Name;
                int idVenta = Convert.ToInt32(dgvCatalogoVentas.Rows[e.RowIndex].Cells["IdVenta"].Value);
                int idCliente = Convert.ToInt32(dgvCatalogoVentas.Rows[e.RowIndex].Cells["IdCliente"].Value);  // Acceso a la columna 'IdCliente'

                if (columna == "btnGenerarPDF")
                {
                    GenerarPDFVenta(idVenta);
                }
                else if (columna == "btnEnviarCorreo")
                {
                    EnviarPDFPorCorreo(idVenta, idCliente);  // Pasar el 'IdCliente'
                }
            }
        }

        private void GenerarPDFVenta(int idVenta)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "PDF Files (*.pdf)|*.pdf";

            if (saveFile.ShowDialog() == DialogResult.OK)

            {
                string selectedPath = saveFile.FileName;
                GenerarPDFVenta(idVenta, selectedPath);
            }
        }

        private void GenerarPDFVenta(int idVenta, string pdfPath)
        {
            // Crear un documento con tamaño A4
            Document document = new Document(PageSize.A4);

            using (FileStream fs = new FileStream(pdfPath, FileMode.Create))
            {
                PdfWriter writer = PdfWriter.GetInstance(document, fs);
                document.Open();

                BaseFont baseFont = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                Font font = new Font(baseFont, 12);
                Font headerFont = new Font(baseFont, 16);

                // Información de la empresa
                Paragraph companyInfo = new Paragraph();
                string logoPath = "img/logo.png";

                if (File.Exists(logoPath))
                {
                    iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(logoPath);
                    logo.ScaleToFit(100f, 100f);
                    logo.Alignment = Element.ALIGN_LEFT;
                    document.Add(logo);
                }

                companyInfo.Add(new Chunk("CieloFloral\n", headerFont));
                companyInfo.Add(new Chunk("Dirección: Calle de las Flores, Mérida, Yucatán\n", font));
                companyInfo.Add(new Chunk("Teléfono: (999) 123-4567\n", font));
                companyInfo.Add(new Chunk("Correo: contacto@cielofloral.com\n", font));
                companyInfo.Alignment = Element.ALIGN_LEFT;
                document.Add(companyInfo);

                document.Add(new Chunk(new LineSeparator(1f, 100f, BaseColor.BLACK, Element.ALIGN_CENTER, -1)));
                document.Add(new Paragraph("\n"));
                document.Add(new Paragraph("Detalle de la Venta", headerFont) { Alignment = Element.ALIGN_CENTER });
                document.Add(new Paragraph("\n"));

                PdfPTable table = new PdfPTable(4);
                table.WidthPercentage = 100;
                table.AddCell("Nombre Producto");
                table.AddCell("Descripción");
                table.AddCell("Precio");
                table.AddCell("Imagen");

                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

               string query = "SELECT p.nombreProducto, p.descripcion, p.precio, p.imgBase64 " +
               "FROM detalle_venta d " +
               "INNER JOIN productos p ON d.IdProducto = p.Id " +  // ← nota el espacio al final
               "WHERE d.IdVenta = @idVenta";



                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@idVenta", idVenta);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string nombreProducto = reader["nombreProducto"].ToString();
                                string descripcion = reader["descripcion"].ToString();
                                string precio = reader["precio"].ToString();
                                string imgBase64 = reader["imgBase64"].ToString();

                                table.AddCell(nombreProducto);
                                table.AddCell(descripcion);
                                table.AddCell(precio);

                                if (!string.IsNullOrEmpty(imgBase64))
                                {
                                    try
                                    {
                                        byte[] imageBytes = Convert.FromBase64String(imgBase64);
                                        iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(imageBytes);
                                        img.ScaleToFit(50f, 50f);
                                        PdfPCell imgCell = new PdfPCell(img);
                                        imgCell.HorizontalAlignment = Element.ALIGN_CENTER;
                                        table.AddCell(imgCell);
                                    }
                                    catch
                                    {
                                        table.AddCell("Imagen no válida");
                                    }
                                }
                                else
                                {
                                    table.AddCell("Sin imagen");
                                }
                            }
                        }
                    }

                    document.Add(table);
                    document.Close();
                }


                MessageBox.Show("Reporte generado exitosamente.");
            }
        }


        private void EnviarPDFPorCorreo(int idVenta, int idCliente)
        {
            string correo = "";

            

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT correo FROM clientes WHERE IdCliente = @id", conn);
                cmd.Parameters.AddWithValue("@id", idCliente);
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    correo = reader["correo"].ToString();  // Si existe, guarda el correo
                }
                reader.Close();
            }

            if (string.IsNullOrEmpty(correo))  // Si el correo está vacío, muestra el mensaje
            {
                MessageBox.Show("El cliente no tiene correo registrado.");
                return;
            }

            OpenFileDialog abrir = new OpenFileDialog();
            abrir.Filter = "Archivos PDF (*.pdf)|*.pdf";
            abrir.Title = "Seleccionar PDF";

            if (abrir.ShowDialog() == DialogResult.OK)
            {
                string archivoSeleccionado = abrir.FileName;

                try
                {
                    MailMessage mail = new MailMessage("canedo.amaya.celeste@gmail.com", correo);
                    mail.Subject = "Detalle de tu compra";
                    mail.Body = "Estimado Cliente, adjunto a este correo econtrará su comprobante en PDF. Gracias por tu compra.";
                    mail.Attachments.Add(new Attachment(archivoSeleccionado));

                    SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                    smtp.Credentials = new NetworkCredential("canedo.amaya.celeste@gmail.com", "qnbdxxjovsbwtkjz");
                    smtp.EnableSsl = true;

                    smtp.Send(mail);
                    MessageBox.Show("Correo enviado correctamente.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al enviar correo: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("No se seleccionó ningún archivo.");
            }

        }

        private void dgvCatalogoVentas_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
       
}
