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
using System.IO;

namespace CieloFloral
{
    public partial class ventas : Form
    {
        private int idUsuarioActual;
        private string connectionString;

        public ventas(int idUsuario)
        {
            InitializeComponent();
            idUsuarioActual = idUsuario;

            string configPath = Path.Combine(Application.StartupPath, "config.txt");
            connectionString = File.ReadAllText(configPath).Trim();
        }

        private void ventas_Load(object sender, EventArgs e)
        {
            CargarProductos();
            CargarClientes();
            dgvDetalleVenta.Columns.Clear();

            dgvDetalleVenta.Columns.Add("IdProducto", "ID Producto");
            dgvDetalleVenta.Columns["IdProducto"].Visible = false; // Ocultamos el ID

            dgvDetalleVenta.Columns.Add("Producto", "Producto");

            dgvDetalleVenta.Columns.Add("Cantidad", "Cantidad");

            dgvDetalleVenta.Columns.Add("PrecioUnitario", "Precio Unitario");
            dgvDetalleVenta.Columns["PrecioUnitario"].DefaultCellStyle.Format = "C2";

            dgvDetalleVenta.Columns.Add("Subtotal", "Subtotal");
            dgvDetalleVenta.Columns["Subtotal"].DefaultCellStyle.Format = "C2";

            dgvDetalleVenta.Columns.Add("IVA", "IVA");
            dgvDetalleVenta.Columns["IVA"].DefaultCellStyle.Format = "C2";

            dgvDetalleVenta.AllowUserToAddRows = false;

            DataGridViewButtonColumn btnEliminar = new DataGridViewButtonColumn();
            btnEliminar.HeaderText = "Acciones";
            btnEliminar.Name = "Eliminar";
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseColumnTextForButtonValue = true;
            dgvDetalleVenta.Columns.Add(btnEliminar);

        }

        private void CalcularTotales()
        {
            decimal subtotal = 0;
            decimal ivaTotal = 0;

            foreach (DataGridViewRow row in dgvDetalleVenta.Rows)
            {
                subtotal += Convert.ToDecimal(row.Cells["Subtotal"].Value);
                ivaTotal += Convert.ToDecimal(row.Cells["IVA"].Value);
            }

            lblSubtotal.Text = (subtotal - ivaTotal).ToString("C");
            lblIVA.Text = ivaTotal.ToString("C");
            lblTotal.Text = subtotal.ToString("C");
        }


        private void dgvDetalleVenta_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvDetalleVenta.Columns["Eliminar"].Index && e.RowIndex >= 0)
            {
                dgvDetalleVenta.Rows.RemoveAt(e.RowIndex);
                CalcularTotales();
            }
        }

        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            if (cbProductos.SelectedItem == null || string.IsNullOrWhiteSpace(txtCantidad.Text))
            {
                MessageBox.Show("Selecciona un producto y cantidad.");
                return;
            }

            int idProducto = Convert.ToInt32(cbProductos.SelectedValue);
            string nombreProducto = cbProductos.Text;
            int cantidad = Convert.ToInt32(txtCantidad.Text);

            decimal precioConIVA = ObtenerPrecioProducto(idProducto);

            decimal precioSinIVA = precioConIVA / 1.16m;
            decimal ivaUnitario = precioConIVA - precioSinIVA;

            decimal subtotal = precioConIVA * cantidad;

            dgvDetalleVenta.Rows.Add(idProducto, nombreProducto, cantidad, precioConIVA, subtotal, ivaUnitario * cantidad);

            CalcularTotales();
        }


        private decimal ObtenerPrecioProducto(int idProducto)
        {
            decimal precio = 0.00m;  // Valor inicial, en caso de que no se encuentre el producto

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT precio FROM productos WHERE Id = @idProducto";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@idProducto", idProducto);

                object result = cmd.ExecuteScalar();
                if (result != null)
                    precio = Convert.ToDecimal(result);  // Convertimos el precio INT a DECIMAL
            }

            return precio;
        }
        private void CargarProductos()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = "SELECT Id, nombreProducto FROM productos";
                MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cbProductos.DataSource = dt;
                cbProductos.DisplayMember = "nombreProducto";
                cbProductos.ValueMember = "Id";
                cbProductos.SelectedIndex = -1; // Ningún producto seleccionado al cargar
            }
        }

        private void CargarClientes()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = "SELECT IdCliente, CONCAT(nombreCliente, ' ', apellidoCliente) AS NombreCompleto FROM clientes WHERE activo = 1";
                MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cbClientes.DataSource = dt;
                cbClientes.DisplayMember = "NombreCompleto";
                cbClientes.ValueMember = "IdCliente";
                cbClientes.SelectedIndex = -1; // Ningun cliente seleccionado al cargar
            }
        }


        private void dgvDetalleVenta_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvDetalleVenta.Columns["Eliminar"].Index && e.RowIndex >= 0)
            {
                dgvDetalleVenta.Rows.RemoveAt(e.RowIndex);
                CalcularTotales();
            }
        }

        private void btnGuardarVenta_Click_1(object sender, EventArgs e)
        {
            if (dgvDetalleVenta.Rows.Count == 0)
            {
                MessageBox.Show("Agrega al menos un producto.");
                return;
            }

            if (cbClientes.SelectedItem == null)
            {
                MessageBox.Show("Selecciona un cliente.");
                return;
            }

            int idCliente = Convert.ToInt32(cbClientes.SelectedValue);
            int idUsuario = idUsuarioActual;

            decimal subtotal = Convert.ToDecimal(lblSubtotal.Text.Replace("$", ""));
            decimal iva = Convert.ToDecimal(lblIVA.Text.Replace("$", ""));
            decimal total = Convert.ToDecimal(lblTotal.Text.Replace("$", ""));

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlTransaction trans = conn.BeginTransaction();

                try
                {
                    // Insertar la venta
                    string sqlVenta = @"INSERT INTO ventas (fechaVenta, IdCliente, subtotal, iva, total, IdUsuario)
                                VALUES (@fecha, @cliente, @subtotal, @iva, @total, @usuario)";
                    MySqlCommand cmdVenta = new MySqlCommand(sqlVenta, conn, trans);
                    cmdVenta.Parameters.AddWithValue("@fecha", DateTime.Now);
                    cmdVenta.Parameters.AddWithValue("@cliente", idCliente);
                    cmdVenta.Parameters.AddWithValue("@subtotal", subtotal);
                    cmdVenta.Parameters.AddWithValue("@iva", iva);
                    cmdVenta.Parameters.AddWithValue("@total", total);
                    cmdVenta.Parameters.AddWithValue("@usuario", idUsuario);

                    cmdVenta.ExecuteNonQuery();
                    int idVenta = (int)cmdVenta.LastInsertedId;

                    //Insertar el detalle de la venta
                    foreach (DataGridViewRow row in dgvDetalleVenta.Rows)
                    {
                        if (row.IsNewRow) continue;

                        int idProducto = Convert.ToInt32(row.Cells["IdProducto"].Value);
                        int cantidad = Convert.ToInt32(row.Cells["Cantidad"].Value);
                        decimal precioUnitario = Convert.ToDecimal(row.Cells["PrecioUnitario"].Value);
                        decimal subtotalItem = Convert.ToDecimal(row.Cells["Subtotal"].Value);

                        string sqlDetalle = @"INSERT INTO detalle_venta (IdVenta, IdProducto, cantidad, precioUnitario, subtotal)
                                      VALUES (@idVenta, @idProducto, @cantidad, @precio, @subtotal)";
                        MySqlCommand cmdDetalle = new MySqlCommand(sqlDetalle, conn, trans);
                        cmdDetalle.Parameters.AddWithValue("@idVenta", idVenta);
                        cmdDetalle.Parameters.AddWithValue("@idProducto", idProducto);
                        cmdDetalle.Parameters.AddWithValue("@cantidad", cantidad);
                        cmdDetalle.Parameters.AddWithValue("@precio", precioUnitario);
                        cmdDetalle.Parameters.AddWithValue("@subtotal", subtotalItem);
                        cmdDetalle.ExecuteNonQuery();
                    }

                    trans.Commit();
                    MessageBox.Show(" Venta registrada correctamente.");

                    // Limpiar después de registrar
                    dgvDetalleVenta.Rows.Clear();
                    lblSubtotal.Text = "$0.00";
                    lblIVA.Text = "$0.00";
                    lblTotal.Text = "$0.00";
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    MessageBox.Show("❌ Error al guardar la venta: " + ex.Message);
                }
            }

        }
    }
}
