using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using iText.Kernel.Colors;
using CieloFloral;
using System.IO;

namespace MC3_tareaCompleta
{
    public partial class FormMenu : Form
    {
        private string connectionString;
        public FormMenu(int idUsuario, string nombreUsuario)
        {
            InitializeComponent();
            idUsuarioActual = idUsuario;
            nombreUsuarioActual = nombreUsuario;
            lbUsuario.Text = "Bienvenido: " + nombreUsuarioActual;

            string configPath = Path.Combine(Application.StartupPath, "config.txt");
            connectionString = File.ReadAllText(configPath).Trim();
        }
        private int idUsuarioActual;
        private string nombreUsuarioActual;
        private void AbrirFormHijo(object formHijo)
        {
            if (this.panelContenedor.Controls.Count > 0)
                this.panelContenedor.Controls.Clear();
            Form fh = formHijo as Form;
            fh.TopLevel = false;
            this.panelContenedor.Controls.Add(fh);
            fh.Dock = DockStyle.Fill;
            this.panelContenedor.Tag = fh;
            fh.Show();

            if (formHijo is Catalogo catalogoForm)
            {
                catalogoForm.CargarDatos();
            }

        }

        private void AgregarProducto_Click(object sender, EventArgs e)
        {
            AbrirFormHijo(new Productos());
        }

        private void VerCatalogo_Click(object sender, EventArgs e)
        {
            AbrirFormHijo(new Catalogo());
        }


        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Reportes_Click(object sender, EventArgs e)
        {
            AbrirFormHijo(new Reportes());
        }

        private void catalogoUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormHijo(new Usuarios());
        }

        private void agregarUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormHijo(new agregarUsuarios());
        }

        private void catalogoDeClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormHijo(new Clientes());
        }

        private void agregarClienteNuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormHijo(new agregarClientes());
        }

        private void realizarUnaVentaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormHijo(new ventas(idUsuarioActual));
        }

        private void catalogoDeVentasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormHijo(new CatalogoVentas());
        }

        private void proveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormHijo(new Proveedores());
        }

        private void catalogoDeProveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormHijo(new CatalogoProveedor());
        }

        private void panelContenedor_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
