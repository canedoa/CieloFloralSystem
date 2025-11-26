namespace MC3_tareaCompleta
{
    partial class FormMenu
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.ToolStripMenuItem catalogoDeClientesToolStripMenuItem;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMenu));
            this.menu = new System.Windows.Forms.MenuStrip();
            this.MenuUsuarios = new System.Windows.Forms.ToolStripMenuItem();
            this.catalogoUsuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.agregarUsuarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuProductos = new System.Windows.Forms.ToolStripMenuItem();
            this.Catalogo = new System.Windows.Forms.ToolStripMenuItem();
            this.AgregarProducto = new System.Windows.Forms.ToolStripMenuItem();
            this.VerCatalogo = new System.Windows.Forms.ToolStripMenuItem();
            this.Reportes = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuCompras = new System.Windows.Forms.ToolStripMenuItem();
            this.proveedoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.catalogoDeProveedoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuVentas = new System.Windows.Forms.ToolStripMenuItem();
            this.realizarUnaVentaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.catalogoDeVentasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuClientes = new System.Windows.Forms.ToolStripMenuItem();
            this.agregarClienteNuevoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menutitulo = new System.Windows.Forms.MenuStrip();
            this.Titulo = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelContenedor = new System.Windows.Forms.Panel();
            this.lbUsuario = new System.Windows.Forms.Label();
            this.btnSalir = new System.Windows.Forms.Button();
            catalogoDeClientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // catalogoDeClientesToolStripMenuItem
            // 
            catalogoDeClientesToolStripMenuItem.ForeColor = System.Drawing.Color.DeepSkyBlue;
            catalogoDeClientesToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("catalogoDeClientesToolStripMenuItem.Image")));
            catalogoDeClientesToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            catalogoDeClientesToolStripMenuItem.Name = "catalogoDeClientesToolStripMenuItem";
            catalogoDeClientesToolStripMenuItem.Size = new System.Drawing.Size(374, 60);
            catalogoDeClientesToolStripMenuItem.Text = "Catalogo de Clientes";
            catalogoDeClientesToolStripMenuItem.Click += new System.EventHandler(this.catalogoDeClientesToolStripMenuItem_Click);
            // 
            // menu
            // 
            this.menu.BackColor = System.Drawing.Color.LightSkyBlue;
            this.menu.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuUsuarios,
            this.MenuProductos,
            this.MenuCompras,
            this.MenuVentas,
            this.MenuClientes});
            this.menu.Location = new System.Drawing.Point(0, 65);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(838, 56);
            this.menu.TabIndex = 1;
            this.menu.Text = "menu";
            // 
            // MenuUsuarios
            // 
            this.MenuUsuarios.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.catalogoUsuariosToolStripMenuItem,
            this.agregarUsuarioToolStripMenuItem});
            this.MenuUsuarios.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MenuUsuarios.ForeColor = System.Drawing.Color.White;
            this.MenuUsuarios.Image = ((System.Drawing.Image)(resources.GetObject("MenuUsuarios.Image")));
            this.MenuUsuarios.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.MenuUsuarios.Name = "MenuUsuarios";
            this.MenuUsuarios.Size = new System.Drawing.Size(166, 52);
            this.MenuUsuarios.Text = "Usuarios";
            // 
            // catalogoUsuariosToolStripMenuItem
            // 
            this.catalogoUsuariosToolStripMenuItem.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.catalogoUsuariosToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("catalogoUsuariosToolStripMenuItem.Image")));
            this.catalogoUsuariosToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.catalogoUsuariosToolStripMenuItem.Name = "catalogoUsuariosToolStripMenuItem";
            this.catalogoUsuariosToolStripMenuItem.Size = new System.Drawing.Size(340, 58);
            this.catalogoUsuariosToolStripMenuItem.Text = "Usuarios existentes";
            this.catalogoUsuariosToolStripMenuItem.Click += new System.EventHandler(this.catalogoUsuariosToolStripMenuItem_Click);
            // 
            // agregarUsuarioToolStripMenuItem
            // 
            this.agregarUsuarioToolStripMenuItem.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.agregarUsuarioToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("agregarUsuarioToolStripMenuItem.Image")));
            this.agregarUsuarioToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.agregarUsuarioToolStripMenuItem.Name = "agregarUsuarioToolStripMenuItem";
            this.agregarUsuarioToolStripMenuItem.Size = new System.Drawing.Size(340, 58);
            this.agregarUsuarioToolStripMenuItem.Text = "Agregar Usuario";
            this.agregarUsuarioToolStripMenuItem.Click += new System.EventHandler(this.agregarUsuarioToolStripMenuItem_Click);
            // 
            // MenuProductos
            // 
            this.MenuProductos.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Catalogo,
            this.Reportes});
            this.MenuProductos.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MenuProductos.ForeColor = System.Drawing.Color.White;
            this.MenuProductos.Image = ((System.Drawing.Image)(resources.GetObject("MenuProductos.Image")));
            this.MenuProductos.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.MenuProductos.Name = "MenuProductos";
            this.MenuProductos.Size = new System.Drawing.Size(183, 52);
            this.MenuProductos.Text = "Productos";
            // 
            // Catalogo
            // 
            this.Catalogo.BackColor = System.Drawing.Color.White;
            this.Catalogo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AgregarProducto,
            this.VerCatalogo});
            this.Catalogo.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.Catalogo.Image = ((System.Drawing.Image)(resources.GetObject("Catalogo.Image")));
            this.Catalogo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.Catalogo.Name = "Catalogo";
            this.Catalogo.Size = new System.Drawing.Size(233, 58);
            this.Catalogo.Text = "Catalogo";
            // 
            // AgregarProducto
            // 
            this.AgregarProducto.BackColor = System.Drawing.Color.White;
            this.AgregarProducto.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.AgregarProducto.Image = ((System.Drawing.Image)(resources.GetObject("AgregarProducto.Image")));
            this.AgregarProducto.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.AgregarProducto.Name = "AgregarProducto";
            this.AgregarProducto.Size = new System.Drawing.Size(337, 58);
            this.AgregarProducto.Text = "Agregar Productos";
            this.AgregarProducto.Click += new System.EventHandler(this.AgregarProducto_Click);
            // 
            // VerCatalogo
            // 
            this.VerCatalogo.BackColor = System.Drawing.Color.White;
            this.VerCatalogo.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.VerCatalogo.Image = ((System.Drawing.Image)(resources.GetObject("VerCatalogo.Image")));
            this.VerCatalogo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.VerCatalogo.Name = "VerCatalogo";
            this.VerCatalogo.Size = new System.Drawing.Size(337, 58);
            this.VerCatalogo.Text = "Ver Catalogo";
            this.VerCatalogo.Click += new System.EventHandler(this.VerCatalogo_Click);
            // 
            // Reportes
            // 
            this.Reportes.BackColor = System.Drawing.Color.White;
            this.Reportes.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.Reportes.Image = ((System.Drawing.Image)(resources.GetObject("Reportes.Image")));
            this.Reportes.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.Reportes.Name = "Reportes";
            this.Reportes.Size = new System.Drawing.Size(233, 58);
            this.Reportes.Text = "Reportes";
            this.Reportes.Click += new System.EventHandler(this.Reportes_Click);
            // 
            // MenuCompras
            // 
            this.MenuCompras.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.proveedoresToolStripMenuItem,
            this.catalogoDeProveedoresToolStripMenuItem});
            this.MenuCompras.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MenuCompras.ForeColor = System.Drawing.Color.White;
            this.MenuCompras.Image = ((System.Drawing.Image)(resources.GetObject("MenuCompras.Image")));
            this.MenuCompras.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.MenuCompras.Name = "MenuCompras";
            this.MenuCompras.Size = new System.Drawing.Size(169, 52);
            this.MenuCompras.Text = "Compras";
            // 
            // proveedoresToolStripMenuItem
            // 
            this.proveedoresToolStripMenuItem.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.proveedoresToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("proveedoresToolStripMenuItem.Image")));
            this.proveedoresToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.proveedoresToolStripMenuItem.Name = "proveedoresToolStripMenuItem";
            this.proveedoresToolStripMenuItem.Size = new System.Drawing.Size(413, 70);
            this.proveedoresToolStripMenuItem.Text = "Proveedores";
            this.proveedoresToolStripMenuItem.Click += new System.EventHandler(this.proveedoresToolStripMenuItem_Click);
            // 
            // catalogoDeProveedoresToolStripMenuItem
            // 
            this.catalogoDeProveedoresToolStripMenuItem.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.catalogoDeProveedoresToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("catalogoDeProveedoresToolStripMenuItem.Image")));
            this.catalogoDeProveedoresToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.catalogoDeProveedoresToolStripMenuItem.Name = "catalogoDeProveedoresToolStripMenuItem";
            this.catalogoDeProveedoresToolStripMenuItem.Size = new System.Drawing.Size(413, 70);
            this.catalogoDeProveedoresToolStripMenuItem.Text = "Catalogo de proveedores";
            this.catalogoDeProveedoresToolStripMenuItem.Click += new System.EventHandler(this.catalogoDeProveedoresToolStripMenuItem_Click);
            // 
            // MenuVentas
            // 
            this.MenuVentas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.realizarUnaVentaToolStripMenuItem,
            this.catalogoDeVentasToolStripMenuItem});
            this.MenuVentas.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MenuVentas.ForeColor = System.Drawing.Color.White;
            this.MenuVentas.Image = ((System.Drawing.Image)(resources.GetObject("MenuVentas.Image")));
            this.MenuVentas.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.MenuVentas.Name = "MenuVentas";
            this.MenuVentas.Size = new System.Drawing.Size(147, 52);
            this.MenuVentas.Text = "Ventas";
            // 
            // realizarUnaVentaToolStripMenuItem
            // 
            this.realizarUnaVentaToolStripMenuItem.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.realizarUnaVentaToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("realizarUnaVentaToolStripMenuItem.Image")));
            this.realizarUnaVentaToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.realizarUnaVentaToolStripMenuItem.Name = "realizarUnaVentaToolStripMenuItem";
            this.realizarUnaVentaToolStripMenuItem.Size = new System.Drawing.Size(343, 60);
            this.realizarUnaVentaToolStripMenuItem.Text = "Realizar una Venta";
            this.realizarUnaVentaToolStripMenuItem.Click += new System.EventHandler(this.realizarUnaVentaToolStripMenuItem_Click);
            // 
            // catalogoDeVentasToolStripMenuItem
            // 
            this.catalogoDeVentasToolStripMenuItem.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.catalogoDeVentasToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("catalogoDeVentasToolStripMenuItem.Image")));
            this.catalogoDeVentasToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.catalogoDeVentasToolStripMenuItem.Name = "catalogoDeVentasToolStripMenuItem";
            this.catalogoDeVentasToolStripMenuItem.Size = new System.Drawing.Size(343, 60);
            this.catalogoDeVentasToolStripMenuItem.Text = "Catalogo de Ventas";
            this.catalogoDeVentasToolStripMenuItem.Click += new System.EventHandler(this.catalogoDeVentasToolStripMenuItem_Click);
            // 
            // MenuClientes
            // 
            this.MenuClientes.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            catalogoDeClientesToolStripMenuItem,
            this.agregarClienteNuevoToolStripMenuItem});
            this.MenuClientes.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MenuClientes.ForeColor = System.Drawing.Color.White;
            this.MenuClientes.Image = ((System.Drawing.Image)(resources.GetObject("MenuClientes.Image")));
            this.MenuClientes.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.MenuClientes.Name = "MenuClientes";
            this.MenuClientes.Size = new System.Drawing.Size(159, 52);
            this.MenuClientes.Text = "Clientes";
            // 
            // agregarClienteNuevoToolStripMenuItem
            // 
            this.agregarClienteNuevoToolStripMenuItem.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.agregarClienteNuevoToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("agregarClienteNuevoToolStripMenuItem.Image")));
            this.agregarClienteNuevoToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.agregarClienteNuevoToolStripMenuItem.Name = "agregarClienteNuevoToolStripMenuItem";
            this.agregarClienteNuevoToolStripMenuItem.Size = new System.Drawing.Size(374, 60);
            this.agregarClienteNuevoToolStripMenuItem.Text = "Agregar Cliente nuevo";
            this.agregarClienteNuevoToolStripMenuItem.Click += new System.EventHandler(this.agregarClienteNuevoToolStripMenuItem_Click);
            // 
            // menutitulo
            // 
            this.menutitulo.AutoSize = false;
            this.menutitulo.BackColor = System.Drawing.Color.White;
            this.menutitulo.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menutitulo.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menutitulo.Location = new System.Drawing.Point(0, 0);
            this.menutitulo.Name = "menutitulo";
            this.menutitulo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.menutitulo.Size = new System.Drawing.Size(838, 65);
            this.menutitulo.TabIndex = 2;
            // 
            // Titulo
            // 
            this.Titulo.AutoSize = true;
            this.Titulo.BackColor = System.Drawing.Color.White;
            this.Titulo.Font = new System.Drawing.Font("Monotype Corsiva", 22F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Titulo.ForeColor = System.Drawing.Color.LightSkyBlue;
            this.Titulo.Location = new System.Drawing.Point(71, 8);
            this.Titulo.Name = "Titulo";
            this.Titulo.Size = new System.Drawing.Size(430, 53);
            this.Titulo.TabIndex = 3;
            this.Titulo.Text = " Bienvenido a Cielo Floral";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(53, 50);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // panelContenedor
            // 
            this.panelContenedor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.panelContenedor.Location = new System.Drawing.Point(0, 121);
            this.panelContenedor.Margin = new System.Windows.Forms.Padding(0);
            this.panelContenedor.Name = "panelContenedor";
            this.panelContenedor.Size = new System.Drawing.Size(838, 455);
            this.panelContenedor.TabIndex = 5;
            this.panelContenedor.Paint += new System.Windows.Forms.PaintEventHandler(this.panelContenedor_Paint);
            // 
            // lbUsuario
            // 
            this.lbUsuario.AutoSize = true;
            this.lbUsuario.Font = new System.Drawing.Font("Segoe UI Black", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUsuario.ForeColor = System.Drawing.Color.LightSkyBlue;
            this.lbUsuario.Location = new System.Drawing.Point(558, 19);
            this.lbUsuario.Name = "lbUsuario";
            this.lbUsuario.Size = new System.Drawing.Size(118, 30);
            this.lbUsuario.TabIndex = 7;
            this.lbUsuario.Text = "lbUsuario";
            // 
            // btnSalir
            // 
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.Location = new System.Drawing.Point(777, 12);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(49, 46);
            this.btnSalir.TabIndex = 8;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // FormMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(838, 576);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.panelContenedor);
            this.Controls.Add(this.lbUsuario);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Titulo);
            this.Controls.Add(this.menu);
            this.Controls.Add(this.menutitulo);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menu;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cielo Floral Panel";
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.MenuStrip menutitulo;
        private System.Windows.Forms.Label Titulo;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem MenuUsuarios;
        private System.Windows.Forms.ToolStripMenuItem MenuCompras;
        private System.Windows.Forms.ToolStripMenuItem MenuClientes;
        private System.Windows.Forms.ToolStripMenuItem MenuProductos;
        private System.Windows.Forms.ToolStripMenuItem MenuVentas;
        private System.Windows.Forms.Panel panelContenedor;
        private System.Windows.Forms.Label lbUsuario;
        private System.Windows.Forms.ToolStripMenuItem Catalogo;
        private System.Windows.Forms.ToolStripMenuItem Reportes;
        private System.Windows.Forms.ToolStripMenuItem AgregarProducto;
        private System.Windows.Forms.ToolStripMenuItem VerCatalogo;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.ToolStripMenuItem catalogoUsuariosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem agregarUsuarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem agregarClienteNuevoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem proveedoresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem realizarUnaVentaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem catalogoDeVentasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem catalogoDeProveedoresToolStripMenuItem;
    }
}

