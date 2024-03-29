﻿using Biblioteca.Controles;

namespace Biblioteca.Formularios
{
    partial class FormBaseABM_RRHH
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormBaseABM_RRHH));
            this.labelPublicacion = new Biblioteca.Controles.MiLabel();
            this.btnNuevo = new Biblioteca.Controles.MiButtonBase();
            this.btnGuardar = new Biblioteca.Controles.MiButtonBase();
            this.btnCancelar = new Biblioteca.Controles.MiButtonBase();
            this.btnAnular = new Biblioteca.Controles.MiButtonBase();
            this.btnExcel_Registro = new Biblioteca.Controles.MiButtonExcel();
            this.btnPDF_Registro = new Biblioteca.Controles.MiButtonPDF();
            this.pictureSeparador1 = new System.Windows.Forms.PictureBox();
            this.pictureSeparador2 = new System.Windows.Forms.PictureBox();
            this.pkrFiltroListaDesde = new Biblioteca.Controles.MiDateTimePicker();
            this.pkrFiltroListaHasta = new Biblioteca.Controles.MiDateTimePicker();
            this.lblTituloLista = new System.Windows.Forms.Label();
            this.cmbFiltroLista1 = new Biblioteca.Controles.MiComboBox();
            this.cmbFiltroLista2 = new Biblioteca.Controles.MiComboBox();
            this.txtFiltroLista = new Biblioteca.Controles.MiTextBox();
            this.btnExcel_Lista = new Biblioteca.Controles.MiButtonExcel();
            this.btnPDF_Lista = new Biblioteca.Controles.MiButtonPDF();
            this.fondoPaginacion = new System.Windows.Forms.PictureBox();
            this.lblCatalagoTitulo1 = new System.Windows.Forms.Label();
            this.lblCatalagoTitulo2 = new System.Windows.Forms.Label();
            this.lblCatalagoTitulo3 = new System.Windows.Forms.Label();
            this.lblCatalagoTitulo4 = new System.Windows.Forms.Label();
            this.lblCatalagoTitulo5 = new System.Windows.Forms.Label();
            this.lstCatalogo = new System.Windows.Forms.ListBox();
            this.panelLista = new System.Windows.Forms.Panel();
            this.lblCatalagoTitulo6 = new System.Windows.Forms.Label();
            this.lblPaginacion = new System.Windows.Forms.Label();
            this.btnPaginacionFinal = new Biblioteca.Controles.MiButton20x20();
            this.btnPaginacionPosterior = new Biblioteca.Controles.MiButton20x20();
            this.btnPaginacionAnterior = new Biblioteca.Controles.MiButton20x20();
            this.btnPaginacionInicial = new Biblioteca.Controles.MiButton20x20();
            this.groupNavegacion = new System.Windows.Forms.GroupBox();
            this.navItem14 = new Biblioteca.Controles.MiLabel();
            this.navItem11 = new Biblioteca.Controles.MiLabel();
            this.navItem13 = new Biblioteca.Controles.MiLabel();
            this.navItem10 = new Biblioteca.Controles.MiLabel();
            this.navItem12 = new Biblioteca.Controles.MiLabel();
            this.navItem9 = new Biblioteca.Controles.MiLabel();
            this.navItem8 = new Biblioteca.Controles.MiLabel();
            this.navItem7 = new Biblioteca.Controles.MiLabel();
            this.navItem6 = new Biblioteca.Controles.MiLabel();
            this.navItem5 = new Biblioteca.Controles.MiLabel();
            this.navItem4 = new Biblioteca.Controles.MiLabel();
            this.navItem3 = new Biblioteca.Controles.MiLabel();
            this.navItem2 = new Biblioteca.Controles.MiLabel();
            this.navItem1 = new Biblioteca.Controles.MiLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureSeparador1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureSeparador2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fondoPaginacion)).BeginInit();
            this.panelLista.SuspendLayout();
            this.groupNavegacion.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCerrar
            // 
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnCerrar.TabIndex = 9;
            // 
            // labelUsuario
            // 
            this.labelUsuario.TabIndex = 1;
            this.labelUsuario.Text = "Sesión de : ";
            // 
            // labelPublicacion
            // 
            this.labelPublicacion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelPublicacion.BackColor = System.Drawing.Color.Transparent;
            this.labelPublicacion.Font = new System.Drawing.Font("Arial", 7.5F);
            this.labelPublicacion.ForeColor = System.Drawing.Color.DimGray;
            this.labelPublicacion.Location = new System.Drawing.Point(3, 507);
            this.labelPublicacion.Name = "labelPublicacion";
            this.labelPublicacion.Size = new System.Drawing.Size(519, 14);
            this.labelPublicacion.TabIndex = 2;
            this.labelPublicacion.Text = "S/D";
            this.labelPublicacion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnNuevo
            // 
            this.btnNuevo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNuevo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnNuevo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNuevo.FlatAppearance.BorderSize = 0;
            this.btnNuevo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnNuevo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnNuevo.Font = new System.Drawing.Font("Arial", 9F);
            this.btnNuevo.ForeColor = System.Drawing.Color.Black;
            this.btnNuevo.Location = new System.Drawing.Point(6, 657);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnNuevo.Size = new System.Drawing.Size(75, 23);
            this.btnNuevo.TabIndex = 3;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = false;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnGuardar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnGuardar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnGuardar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnGuardar.Font = new System.Drawing.Font("Arial", 9F);
            this.btnGuardar.ForeColor = System.Drawing.Color.Black;
            this.btnGuardar.Location = new System.Drawing.Point(83, 657);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 4;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancelar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnCancelar.Font = new System.Drawing.Font("Arial", 9F);
            this.btnCancelar.ForeColor = System.Drawing.Color.Black;
            this.btnCancelar.Location = new System.Drawing.Point(160, 657);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            // 
            // btnAnular
            // 
            this.btnAnular.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAnular.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnAnular.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAnular.FlatAppearance.BorderSize = 0;
            this.btnAnular.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnAnular.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAnular.Font = new System.Drawing.Font("Arial", 9F);
            this.btnAnular.ForeColor = System.Drawing.Color.Black;
            this.btnAnular.Location = new System.Drawing.Point(241, 657);
            this.btnAnular.Name = "btnAnular";
            this.btnAnular.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnAnular.Size = new System.Drawing.Size(75, 23);
            this.btnAnular.TabIndex = 6;
            this.btnAnular.Text = "Anular";
            this.btnAnular.UseVisualStyleBackColor = false;
            // 
            // btnExcel_Registro
            // 
            this.btnExcel_Registro.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExcel_Registro.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnExcel_Registro.BackgroundImage = global::Biblioteca.Properties.Resources.icon_excel32;
            this.btnExcel_Registro.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnExcel_Registro.FlatAppearance.BorderSize = 0;
            this.btnExcel_Registro.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnExcel_Registro.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnExcel_Registro.Font = new System.Drawing.Font("Arial", 9F);
            this.btnExcel_Registro.ForeColor = System.Drawing.Color.Black;
            this.btnExcel_Registro.Location = new System.Drawing.Point(322, 657);
            this.btnExcel_Registro.Name = "btnExcel_Registro";
            this.btnExcel_Registro.Size = new System.Drawing.Size(30, 23);
            this.btnExcel_Registro.TabIndex = 7;
            this.btnExcel_Registro.UseVisualStyleBackColor = false;
            this.btnExcel_Registro.Click += new System.EventHandler(this.btnExcel_Registro_Click);
            // 
            // btnPDF_Registro
            // 
            this.btnPDF_Registro.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPDF_Registro.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnPDF_Registro.BackgroundImage = global::Biblioteca.Properties.Resources.icon_pdf32;
            this.btnPDF_Registro.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnPDF_Registro.FlatAppearance.BorderSize = 0;
            this.btnPDF_Registro.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnPDF_Registro.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnPDF_Registro.Font = new System.Drawing.Font("Arial", 9F);
            this.btnPDF_Registro.ForeColor = System.Drawing.Color.Black;
            this.btnPDF_Registro.Location = new System.Drawing.Point(354, 657);
            this.btnPDF_Registro.Name = "btnPDF_Registro";
            this.btnPDF_Registro.Size = new System.Drawing.Size(30, 23);
            this.btnPDF_Registro.TabIndex = 8;
            this.btnPDF_Registro.UseVisualStyleBackColor = false;
            this.btnPDF_Registro.Click += new System.EventHandler(this.btnPDF_Registro_Click);
            // 
            // pictureSeparador1
            // 
            this.pictureSeparador1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureSeparador1.BackColor = System.Drawing.Color.Silver;
            this.pictureSeparador1.Location = new System.Drawing.Point(0, 524);
            this.pictureSeparador1.Name = "pictureSeparador1";
            this.pictureSeparador1.Size = new System.Drawing.Size(1006, 1);
            this.pictureSeparador1.TabIndex = 17;
            this.pictureSeparador1.TabStop = false;
            // 
            // pictureSeparador2
            // 
            this.pictureSeparador2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureSeparador2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(121)))), ((int)(((byte)(107)))));
            this.pictureSeparador2.Location = new System.Drawing.Point(0, 525);
            this.pictureSeparador2.Name = "pictureSeparador2";
            this.pictureSeparador2.Size = new System.Drawing.Size(1006, 1);
            this.pictureSeparador2.TabIndex = 16;
            this.pictureSeparador2.TabStop = false;
            // 
            // pkrFiltroListaDesde
            // 
            this.pkrFiltroListaDesde.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pkrFiltroListaDesde.CalendarForeColor = System.Drawing.Color.Black;
            this.pkrFiltroListaDesde.CalendarMonthBackground = System.Drawing.Color.White;
            this.pkrFiltroListaDesde.CalendarTitleForeColor = System.Drawing.Color.Black;
            this.pkrFiltroListaDesde.CalendarTrailingForeColor = System.Drawing.Color.Gray;
            this.pkrFiltroListaDesde.Cursor = System.Windows.Forms.Cursors.Default;
            this.pkrFiltroListaDesde.CustomFormat = "dd/MM/yyyy";
            this.pkrFiltroListaDesde.Enabled = false;
            this.pkrFiltroListaDesde.Font = new System.Drawing.Font("Arial", 9.5F);
            this.pkrFiltroListaDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.pkrFiltroListaDesde.Location = new System.Drawing.Point(734, 6);
            this.pkrFiltroListaDesde.MaxDate = new System.DateTime(2100, 12, 31, 0, 0, 0, 0);
            this.pkrFiltroListaDesde.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.pkrFiltroListaDesde.Name = "pkrFiltroListaDesde";
            this.pkrFiltroListaDesde.Size = new System.Drawing.Size(102, 22);
            this.pkrFiltroListaDesde.TabIndex = 4;
            this.pkrFiltroListaDesde.Visible = false;
            this.pkrFiltroListaDesde.Validated += new System.EventHandler(this.pkrFiltroListaDesde_Validated);
            // 
            // pkrFiltroListaHasta
            // 
            this.pkrFiltroListaHasta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pkrFiltroListaHasta.CalendarForeColor = System.Drawing.Color.Black;
            this.pkrFiltroListaHasta.CalendarMonthBackground = System.Drawing.Color.White;
            this.pkrFiltroListaHasta.CalendarTitleForeColor = System.Drawing.Color.Black;
            this.pkrFiltroListaHasta.CalendarTrailingForeColor = System.Drawing.Color.Gray;
            this.pkrFiltroListaHasta.Cursor = System.Windows.Forms.Cursors.Default;
            this.pkrFiltroListaHasta.CustomFormat = "dd/MM/yyyy";
            this.pkrFiltroListaHasta.Enabled = false;
            this.pkrFiltroListaHasta.Font = new System.Drawing.Font("Arial", 9.5F);
            this.pkrFiltroListaHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.pkrFiltroListaHasta.Location = new System.Drawing.Point(837, 6);
            this.pkrFiltroListaHasta.MaxDate = new System.DateTime(2100, 12, 31, 0, 0, 0, 0);
            this.pkrFiltroListaHasta.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.pkrFiltroListaHasta.Name = "pkrFiltroListaHasta";
            this.pkrFiltroListaHasta.Size = new System.Drawing.Size(102, 22);
            this.pkrFiltroListaHasta.TabIndex = 5;
            this.pkrFiltroListaHasta.Visible = false;
            this.pkrFiltroListaHasta.Validated += new System.EventHandler(this.pkrFiltroListaHasta_Validated);
            // 
            // lblTituloLista
            // 
            this.lblTituloLista.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTituloLista.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloLista.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(96)))), ((int)(((byte)(100)))));
            this.lblTituloLista.Location = new System.Drawing.Point(3, 4);
            this.lblTituloLista.Name = "lblTituloLista";
            this.lblTituloLista.Size = new System.Drawing.Size(310, 23);
            this.lblTituloLista.TabIndex = 0;
            this.lblTituloLista.Text = "Lista de Elemento";
            this.lblTituloLista.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbFiltroLista1
            // 
            this.cmbFiltroLista1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbFiltroLista1.BackColor = System.Drawing.Color.White;
            this.cmbFiltroLista1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFiltroLista1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbFiltroLista1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.cmbFiltroLista1.ForeColor = System.Drawing.Color.Black;
            this.cmbFiltroLista1.FormattingEnabled = true;
            this.cmbFiltroLista1.ItemHeight = 14;
            this.cmbFiltroLista1.Location = new System.Drawing.Point(330, 6);
            this.cmbFiltroLista1.Margin = new System.Windows.Forms.Padding(1);
            this.cmbFiltroLista1.Name = "cmbFiltroLista1";
            this.cmbFiltroLista1.Size = new System.Drawing.Size(220, 22);
            this.cmbFiltroLista1.Sorted = true;
            this.cmbFiltroLista1.TabIndex = 1;
            this.cmbFiltroLista1.SelectedIndexChanged += new System.EventHandler(this.cmbFiltroLista1_SelectedIndexChanged);
            // 
            // cmbFiltroLista2
            // 
            this.cmbFiltroLista2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbFiltroLista2.BackColor = System.Drawing.Color.White;
            this.cmbFiltroLista2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFiltroLista2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbFiltroLista2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.cmbFiltroLista2.ForeColor = System.Drawing.Color.Black;
            this.cmbFiltroLista2.FormattingEnabled = true;
            this.cmbFiltroLista2.ItemHeight = 14;
            this.cmbFiltroLista2.Location = new System.Drawing.Point(552, 6);
            this.cmbFiltroLista2.Margin = new System.Windows.Forms.Padding(1);
            this.cmbFiltroLista2.Name = "cmbFiltroLista2";
            this.cmbFiltroLista2.Size = new System.Drawing.Size(180, 22);
            this.cmbFiltroLista2.Sorted = true;
            this.cmbFiltroLista2.TabIndex = 2;
            this.cmbFiltroLista2.SelectedIndexChanged += new System.EventHandler(this.cmbFiltroLista2_SelectedIndexChanged);
            // 
            // txtFiltroLista
            // 
            this.txtFiltroLista.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFiltroLista.BackColor = System.Drawing.Color.White;
            this.txtFiltroLista.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFiltroLista.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtFiltroLista.ForeColor = System.Drawing.Color.Black;
            this.txtFiltroLista.Location = new System.Drawing.Point(734, 6);
            this.txtFiltroLista.MaxLength = 15;
            this.txtFiltroLista.Name = "txtFiltroLista";
            this.txtFiltroLista.Size = new System.Drawing.Size(206, 22);
            this.txtFiltroLista.TabIndex = 3;
            this.txtFiltroLista.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtFiltroLista_KeyUp);
            this.txtFiltroLista.LostFocus += new System.EventHandler(this.txtFiltroLista_LostFocus);
            // 
            // btnExcel_Lista
            // 
            this.btnExcel_Lista.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExcel_Lista.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnExcel_Lista.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExcel_Lista.BackgroundImage")));
            this.btnExcel_Lista.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnExcel_Lista.FlatAppearance.BorderSize = 0;
            this.btnExcel_Lista.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnExcel_Lista.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnExcel_Lista.Font = new System.Drawing.Font("Arial", 9F);
            this.btnExcel_Lista.ForeColor = System.Drawing.Color.Black;
            this.btnExcel_Lista.Location = new System.Drawing.Point(941, 5);
            this.btnExcel_Lista.Name = "btnExcel_Lista";
            this.btnExcel_Lista.Size = new System.Drawing.Size(30, 24);
            this.btnExcel_Lista.TabIndex = 6;
            this.btnExcel_Lista.UseVisualStyleBackColor = false;
            this.btnExcel_Lista.Click += new System.EventHandler(this.btnExcel_Lista_Click);
            // 
            // btnPDF_Lista
            // 
            this.btnPDF_Lista.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPDF_Lista.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnPDF_Lista.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPDF_Lista.BackgroundImage")));
            this.btnPDF_Lista.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnPDF_Lista.FlatAppearance.BorderSize = 0;
            this.btnPDF_Lista.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnPDF_Lista.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnPDF_Lista.Font = new System.Drawing.Font("Arial", 9F);
            this.btnPDF_Lista.ForeColor = System.Drawing.Color.Black;
            this.btnPDF_Lista.Location = new System.Drawing.Point(971, 5);
            this.btnPDF_Lista.Name = "btnPDF_Lista";
            this.btnPDF_Lista.Size = new System.Drawing.Size(30, 24);
            this.btnPDF_Lista.TabIndex = 7;
            this.btnPDF_Lista.UseVisualStyleBackColor = false;
            this.btnPDF_Lista.Click += new System.EventHandler(this.btnPDF_Lista_Click);
            // 
            // fondoPaginacion
            // 
            this.fondoPaginacion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fondoPaginacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(121)))), ((int)(((byte)(107)))));
            this.fondoPaginacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fondoPaginacion.Location = new System.Drawing.Point(6, 33);
            this.fondoPaginacion.Name = "fondoPaginacion";
            this.fondoPaginacion.Size = new System.Drawing.Size(994, 20);
            this.fondoPaginacion.TabIndex = 9;
            this.fondoPaginacion.TabStop = false;
            // 
            // lblCatalagoTitulo1
            // 
            this.lblCatalagoTitulo1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCatalagoTitulo1.AutoSize = true;
            this.lblCatalagoTitulo1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(121)))), ((int)(((byte)(107)))));
            this.lblCatalagoTitulo1.ForeColor = System.Drawing.Color.White;
            this.lblCatalagoTitulo1.Location = new System.Drawing.Point(7, 36);
            this.lblCatalagoTitulo1.Name = "lblCatalagoTitulo1";
            this.lblCatalagoTitulo1.Size = new System.Drawing.Size(18, 14);
            this.lblCatalagoTitulo1.TabIndex = 8;
            this.lblCatalagoTitulo1.Text = "N°";
            this.lblCatalagoTitulo1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCatalagoTitulo2
            // 
            this.lblCatalagoTitulo2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCatalagoTitulo2.AutoSize = true;
            this.lblCatalagoTitulo2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(121)))), ((int)(((byte)(107)))));
            this.lblCatalagoTitulo2.ForeColor = System.Drawing.Color.White;
            this.lblCatalagoTitulo2.Location = new System.Drawing.Point(76, 36);
            this.lblCatalagoTitulo2.Name = "lblCatalagoTitulo2";
            this.lblCatalagoTitulo2.Size = new System.Drawing.Size(74, 14);
            this.lblCatalagoTitulo2.TabIndex = 9;
            this.lblCatalagoTitulo2.Text = "Denominación";
            this.lblCatalagoTitulo2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCatalagoTitulo3
            // 
            this.lblCatalagoTitulo3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCatalagoTitulo3.AutoSize = true;
            this.lblCatalagoTitulo3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(121)))), ((int)(((byte)(107)))));
            this.lblCatalagoTitulo3.ForeColor = System.Drawing.Color.White;
            this.lblCatalagoTitulo3.Location = new System.Drawing.Point(307, 36);
            this.lblCatalagoTitulo3.Name = "lblCatalagoTitulo3";
            this.lblCatalagoTitulo3.Size = new System.Drawing.Size(46, 14);
            this.lblCatalagoTitulo3.TabIndex = 10;
            this.lblCatalagoTitulo3.Text = "Campo1";
            this.lblCatalagoTitulo3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCatalagoTitulo4
            // 
            this.lblCatalagoTitulo4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCatalagoTitulo4.AutoSize = true;
            this.lblCatalagoTitulo4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(121)))), ((int)(((byte)(107)))));
            this.lblCatalagoTitulo4.ForeColor = System.Drawing.Color.White;
            this.lblCatalagoTitulo4.Location = new System.Drawing.Point(384, 36);
            this.lblCatalagoTitulo4.Name = "lblCatalagoTitulo4";
            this.lblCatalagoTitulo4.Size = new System.Drawing.Size(46, 14);
            this.lblCatalagoTitulo4.TabIndex = 11;
            this.lblCatalagoTitulo4.Text = "Campo2";
            this.lblCatalagoTitulo4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCatalagoTitulo5
            // 
            this.lblCatalagoTitulo5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCatalagoTitulo5.AutoSize = true;
            this.lblCatalagoTitulo5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(121)))), ((int)(((byte)(107)))));
            this.lblCatalagoTitulo5.ForeColor = System.Drawing.Color.White;
            this.lblCatalagoTitulo5.Location = new System.Drawing.Point(461, 36);
            this.lblCatalagoTitulo5.Name = "lblCatalagoTitulo5";
            this.lblCatalagoTitulo5.Size = new System.Drawing.Size(46, 14);
            this.lblCatalagoTitulo5.TabIndex = 12;
            this.lblCatalagoTitulo5.Text = "Campo3";
            this.lblCatalagoTitulo5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lstCatalogo
            // 
            this.lstCatalogo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstCatalogo.BackColor = System.Drawing.Color.White;
            this.lstCatalogo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstCatalogo.Font = new System.Drawing.Font("Lucida Console", 9F);
            this.lstCatalogo.ForeColor = System.Drawing.Color.Black;
            this.lstCatalogo.FormattingEnabled = true;
            this.lstCatalogo.ItemHeight = 12;
            this.lstCatalogo.Location = new System.Drawing.Point(6, 52);
            this.lstCatalogo.Name = "lstCatalogo";
            this.lstCatalogo.Size = new System.Drawing.Size(994, 62);
            this.lstCatalogo.TabIndex = 19;
            this.lstCatalogo.SelectedIndexChanged += new System.EventHandler(this.lstCatalogo_SelectedIndexChanged);
            // 
            // panelLista
            // 
            this.panelLista.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelLista.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panelLista.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelLista.Controls.Add(this.lblCatalagoTitulo6);
            this.panelLista.Controls.Add(this.lblPaginacion);
            this.panelLista.Controls.Add(this.lblCatalagoTitulo5);
            this.panelLista.Controls.Add(this.btnPaginacionFinal);
            this.panelLista.Controls.Add(this.btnPaginacionPosterior);
            this.panelLista.Controls.Add(this.lblCatalagoTitulo4);
            this.panelLista.Controls.Add(this.btnPaginacionAnterior);
            this.panelLista.Controls.Add(this.lblCatalagoTitulo3);
            this.panelLista.Controls.Add(this.btnPaginacionInicial);
            this.panelLista.Controls.Add(this.lblCatalagoTitulo2);
            this.panelLista.Controls.Add(this.lblCatalagoTitulo1);
            this.panelLista.Controls.Add(this.fondoPaginacion);
            this.panelLista.Controls.Add(this.btnPDF_Lista);
            this.panelLista.Controls.Add(this.btnExcel_Lista);
            this.panelLista.Controls.Add(this.txtFiltroLista);
            this.panelLista.Controls.Add(this.cmbFiltroLista2);
            this.panelLista.Controls.Add(this.cmbFiltroLista1);
            this.panelLista.Controls.Add(this.lblTituloLista);
            this.panelLista.Controls.Add(this.pkrFiltroListaHasta);
            this.panelLista.Controls.Add(this.pkrFiltroListaDesde);
            this.panelLista.Controls.Add(this.lstCatalogo);
            this.panelLista.Font = new System.Drawing.Font("Arial", 8F);
            this.panelLista.Location = new System.Drawing.Point(0, 526);
            this.panelLista.Name = "panelLista";
            this.panelLista.Size = new System.Drawing.Size(1006, 124);
            this.panelLista.TabIndex = 10;
            // 
            // lblCatalagoTitulo6
            // 
            this.lblCatalagoTitulo6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCatalagoTitulo6.AutoSize = true;
            this.lblCatalagoTitulo6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(121)))), ((int)(((byte)(107)))));
            this.lblCatalagoTitulo6.ForeColor = System.Drawing.Color.White;
            this.lblCatalagoTitulo6.Location = new System.Drawing.Point(552, 36);
            this.lblCatalagoTitulo6.Name = "lblCatalagoTitulo6";
            this.lblCatalagoTitulo6.Size = new System.Drawing.Size(46, 14);
            this.lblCatalagoTitulo6.TabIndex = 13;
            this.lblCatalagoTitulo6.Text = "Campo4";
            this.lblCatalagoTitulo6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPaginacion
            // 
            this.lblPaginacion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPaginacion.BackColor = System.Drawing.Color.Gray;
            this.lblPaginacion.Font = new System.Drawing.Font("Arial", 8.25F);
            this.lblPaginacion.ForeColor = System.Drawing.Color.White;
            this.lblPaginacion.Location = new System.Drawing.Point(937, 35);
            this.lblPaginacion.Name = "lblPaginacion";
            this.lblPaginacion.Size = new System.Drawing.Size(25, 16);
            this.lblPaginacion.TabIndex = 16;
            this.lblPaginacion.Text = "1";
            this.lblPaginacion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnPaginacionFinal
            // 
            this.btnPaginacionFinal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPaginacionFinal.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnPaginacionFinal.BackgroundImage = global::Biblioteca.Properties.Resources.icon_paginacion_final;
            this.btnPaginacionFinal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPaginacionFinal.FlatAppearance.BorderSize = 0;
            this.btnPaginacionFinal.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnPaginacionFinal.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnPaginacionFinal.Font = new System.Drawing.Font("Arial", 8F);
            this.btnPaginacionFinal.ForeColor = System.Drawing.Color.Black;
            this.btnPaginacionFinal.Location = new System.Drawing.Point(982, 35);
            this.btnPaginacionFinal.Name = "btnPaginacionFinal";
            this.btnPaginacionFinal.Size = new System.Drawing.Size(16, 16);
            this.btnPaginacionFinal.TabIndex = 18;
            this.btnPaginacionFinal.UseVisualStyleBackColor = false;
            this.btnPaginacionFinal.Click += new System.EventHandler(this.btnPaginacionFinal_Click);
            // 
            // btnPaginacionPosterior
            // 
            this.btnPaginacionPosterior.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPaginacionPosterior.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnPaginacionPosterior.BackgroundImage = global::Biblioteca.Properties.Resources.icon_paginacion_posterior;
            this.btnPaginacionPosterior.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPaginacionPosterior.FlatAppearance.BorderSize = 0;
            this.btnPaginacionPosterior.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnPaginacionPosterior.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnPaginacionPosterior.Font = new System.Drawing.Font("Arial", 8F);
            this.btnPaginacionPosterior.ForeColor = System.Drawing.Color.Black;
            this.btnPaginacionPosterior.Location = new System.Drawing.Point(964, 35);
            this.btnPaginacionPosterior.Name = "btnPaginacionPosterior";
            this.btnPaginacionPosterior.Size = new System.Drawing.Size(16, 16);
            this.btnPaginacionPosterior.TabIndex = 17;
            this.btnPaginacionPosterior.UseVisualStyleBackColor = false;
            this.btnPaginacionPosterior.Click += new System.EventHandler(this.btnPaginacionPosterior_Click);
            // 
            // btnPaginacionAnterior
            // 
            this.btnPaginacionAnterior.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPaginacionAnterior.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnPaginacionAnterior.BackgroundImage = global::Biblioteca.Properties.Resources.icon_paginacion_anterior;
            this.btnPaginacionAnterior.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPaginacionAnterior.FlatAppearance.BorderSize = 0;
            this.btnPaginacionAnterior.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnPaginacionAnterior.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnPaginacionAnterior.Font = new System.Drawing.Font("Arial", 8F);
            this.btnPaginacionAnterior.ForeColor = System.Drawing.Color.Black;
            this.btnPaginacionAnterior.Location = new System.Drawing.Point(919, 35);
            this.btnPaginacionAnterior.Name = "btnPaginacionAnterior";
            this.btnPaginacionAnterior.Size = new System.Drawing.Size(16, 16);
            this.btnPaginacionAnterior.TabIndex = 15;
            this.btnPaginacionAnterior.UseVisualStyleBackColor = false;
            this.btnPaginacionAnterior.Click += new System.EventHandler(this.btnPaginacionAnterior_Click);
            // 
            // btnPaginacionInicial
            // 
            this.btnPaginacionInicial.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPaginacionInicial.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnPaginacionInicial.BackgroundImage = global::Biblioteca.Properties.Resources.icon_paginacion_inicial;
            this.btnPaginacionInicial.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPaginacionInicial.FlatAppearance.BorderSize = 0;
            this.btnPaginacionInicial.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnPaginacionInicial.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnPaginacionInicial.Font = new System.Drawing.Font("Arial", 8F);
            this.btnPaginacionInicial.ForeColor = System.Drawing.Color.Black;
            this.btnPaginacionInicial.Location = new System.Drawing.Point(901, 35);
            this.btnPaginacionInicial.Name = "btnPaginacionInicial";
            this.btnPaginacionInicial.Size = new System.Drawing.Size(16, 16);
            this.btnPaginacionInicial.TabIndex = 14;
            this.btnPaginacionInicial.UseVisualStyleBackColor = false;
            this.btnPaginacionInicial.Click += new System.EventHandler(this.btnPaginacionInicial_Click);
            // 
            // groupNavegacion
            // 
            this.groupNavegacion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupNavegacion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.groupNavegacion.Controls.Add(this.navItem14);
            this.groupNavegacion.Controls.Add(this.navItem11);
            this.groupNavegacion.Controls.Add(this.navItem13);
            this.groupNavegacion.Controls.Add(this.navItem10);
            this.groupNavegacion.Controls.Add(this.navItem12);
            this.groupNavegacion.Controls.Add(this.navItem9);
            this.groupNavegacion.Controls.Add(this.navItem8);
            this.groupNavegacion.Controls.Add(this.navItem7);
            this.groupNavegacion.Controls.Add(this.navItem6);
            this.groupNavegacion.Controls.Add(this.navItem5);
            this.groupNavegacion.Controls.Add(this.navItem4);
            this.groupNavegacion.Controls.Add(this.navItem3);
            this.groupNavegacion.Controls.Add(this.navItem2);
            this.groupNavegacion.Controls.Add(this.navItem1);
            this.groupNavegacion.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupNavegacion.ForeColor = System.Drawing.Color.Gray;
            this.groupNavegacion.Location = new System.Drawing.Point(850, 55);
            this.groupNavegacion.Name = "groupNavegacion";
            this.groupNavegacion.Size = new System.Drawing.Size(150, 230);
            this.groupNavegacion.TabIndex = 11;
            this.groupNavegacion.TabStop = false;
            this.groupNavegacion.Text = "Panel de navegación";
            // 
            // navItem14
            // 
            this.navItem14.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.navItem14.AutoSize = true;
            this.navItem14.BackColor = System.Drawing.Color.Transparent;
            this.navItem14.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.navItem14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.navItem14.Location = new System.Drawing.Point(6, 210);
            this.navItem14.Name = "navItem14";
            this.navItem14.Size = new System.Drawing.Size(92, 15);
            this.navItem14.TabIndex = 13;
            this.navItem14.Text = "• Nuevo Sueldo";
            this.navItem14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.navItem14.Click += new System.EventHandler(this.navItem14_Click);
            this.navItem14.MouseEnter += new System.EventHandler(this.navItem14_MouseEnter);
            this.navItem14.MouseLeave += new System.EventHandler(this.navItem14_MouseLeave);
            // 
            // navItem11
            // 
            this.navItem11.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.navItem11.AutoSize = true;
            this.navItem11.BackColor = System.Drawing.Color.Transparent;
            this.navItem11.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.navItem11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.navItem11.Location = new System.Drawing.Point(6, 165);
            this.navItem11.Name = "navItem11";
            this.navItem11.Size = new System.Drawing.Size(134, 15);
            this.navItem11.TabIndex = 10;
            this.navItem11.Text = "• Nuevo Curso de Izaje";
            this.navItem11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.navItem11.Click += new System.EventHandler(this.navItem11_Click);
            this.navItem11.MouseEnter += new System.EventHandler(this.navItem11_MouseEnter);
            this.navItem11.MouseLeave += new System.EventHandler(this.navItem11_MouseLeave);
            // 
            // navItem13
            // 
            this.navItem13.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.navItem13.AutoSize = true;
            this.navItem13.BackColor = System.Drawing.Color.Transparent;
            this.navItem13.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.navItem13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.navItem13.Location = new System.Drawing.Point(6, 195);
            this.navItem13.Name = "navItem13";
            this.navItem13.Size = new System.Drawing.Size(82, 15);
            this.navItem13.TabIndex = 12;
            this.navItem13.Text = "• Nuevo Pago";
            this.navItem13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.navItem13.Click += new System.EventHandler(this.navItem13_Click);
            this.navItem13.MouseEnter += new System.EventHandler(this.navItem13_MouseEnter);
            this.navItem13.MouseLeave += new System.EventHandler(this.navItem13_MouseLeave);
            // 
            // navItem10
            // 
            this.navItem10.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.navItem10.AutoSize = true;
            this.navItem10.BackColor = System.Drawing.Color.Transparent;
            this.navItem10.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.navItem10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.navItem10.Location = new System.Drawing.Point(6, 150);
            this.navItem10.Name = "navItem10";
            this.navItem10.Size = new System.Drawing.Size(140, 15);
            this.navItem10.TabIndex = 9;
            this.navItem10.Text = "• Nuevo Curso de Induc.";
            this.navItem10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.navItem10.Click += new System.EventHandler(this.navItem10_Click);
            this.navItem10.MouseEnter += new System.EventHandler(this.navItem10_MouseEnter);
            this.navItem10.MouseLeave += new System.EventHandler(this.navItem10_MouseLeave);
            // 
            // navItem12
            // 
            this.navItem12.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.navItem12.AutoSize = true;
            this.navItem12.BackColor = System.Drawing.Color.Transparent;
            this.navItem12.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.navItem12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.navItem12.Location = new System.Drawing.Point(6, 180);
            this.navItem12.Name = "navItem12";
            this.navItem12.Size = new System.Drawing.Size(141, 15);
            this.navItem12.TabIndex = 11;
            this.navItem12.Text = "• Nuevo Examen Médico";
            this.navItem12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.navItem12.Click += new System.EventHandler(this.navItem12_Click);
            this.navItem12.MouseEnter += new System.EventHandler(this.navItem12_MouseEnter);
            this.navItem12.MouseLeave += new System.EventHandler(this.navItem12_MouseLeave);
            // 
            // navItem9
            // 
            this.navItem9.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.navItem9.AutoSize = true;
            this.navItem9.BackColor = System.Drawing.Color.Transparent;
            this.navItem9.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.navItem9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.navItem9.Location = new System.Drawing.Point(6, 135);
            this.navItem9.Name = "navItem9";
            this.navItem9.Size = new System.Drawing.Size(100, 15);
            this.navItem9.TabIndex = 8;
            this.navItem9.Text = "• Nuevo Contrato";
            this.navItem9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.navItem9.Click += new System.EventHandler(this.navItem9_Click);
            this.navItem9.MouseEnter += new System.EventHandler(this.navItem9_MouseEnter);
            this.navItem9.MouseLeave += new System.EventHandler(this.navItem9_MouseLeave);
            // 
            // navItem8
            // 
            this.navItem8.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.navItem8.AutoSize = true;
            this.navItem8.BackColor = System.Drawing.Color.Transparent;
            this.navItem8.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.navItem8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.navItem8.Location = new System.Drawing.Point(6, 120);
            this.navItem8.Name = "navItem8";
            this.navItem8.Size = new System.Drawing.Size(103, 15);
            this.navItem8.TabIndex = 7;
            this.navItem8.Text = "• Nueva Novedad";
            this.navItem8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.navItem8.Click += new System.EventHandler(this.navItem8_Click);
            this.navItem8.MouseEnter += new System.EventHandler(this.navItem8_MouseEnter);
            this.navItem8.MouseLeave += new System.EventHandler(this.navItem8_MouseLeave);
            // 
            // navItem7
            // 
            this.navItem7.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.navItem7.AutoSize = true;
            this.navItem7.BackColor = System.Drawing.Color.Transparent;
            this.navItem7.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.navItem7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.navItem7.Location = new System.Drawing.Point(6, 105);
            this.navItem7.Name = "navItem7";
            this.navItem7.Size = new System.Drawing.Size(107, 15);
            this.navItem7.TabIndex = 6;
            this.navItem7.Text = "• Nueva Entrevista";
            this.navItem7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.navItem7.Click += new System.EventHandler(this.navItem7_Click);
            this.navItem7.MouseEnter += new System.EventHandler(this.navItem7_MouseEnter);
            this.navItem7.MouseLeave += new System.EventHandler(this.navItem7_MouseLeave);
            // 
            // navItem6
            // 
            this.navItem6.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.navItem6.AutoSize = true;
            this.navItem6.BackColor = System.Drawing.Color.Transparent;
            this.navItem6.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.navItem6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.navItem6.Location = new System.Drawing.Point(6, 90);
            this.navItem6.Name = "navItem6";
            this.navItem6.Size = new System.Drawing.Size(125, 15);
            this.navItem6.TabIndex = 5;
            this.navItem6.Text = "• Nueva Capacitación";
            this.navItem6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.navItem6.Click += new System.EventHandler(this.navItem6_Click);
            this.navItem6.MouseEnter += new System.EventHandler(this.navItem6_MouseEnter);
            this.navItem6.MouseLeave += new System.EventHandler(this.navItem6_MouseLeave);
            // 
            // navItem5
            // 
            this.navItem5.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.navItem5.AutoSize = true;
            this.navItem5.BackColor = System.Drawing.Color.Transparent;
            this.navItem5.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.navItem5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.navItem5.Location = new System.Drawing.Point(6, 75);
            this.navItem5.Name = "navItem5";
            this.navItem5.Size = new System.Drawing.Size(123, 15);
            this.navItem5.TabIndex = 4;
            this.navItem5.Text = "• L. Talles (Indumen.)";
            this.navItem5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.navItem5.Click += new System.EventHandler(this.navItem5_Click);
            this.navItem5.MouseEnter += new System.EventHandler(this.navItem5_MouseEnter);
            this.navItem5.MouseLeave += new System.EventHandler(this.navItem5_MouseLeave);
            // 
            // navItem4
            // 
            this.navItem4.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.navItem4.AutoSize = true;
            this.navItem4.BackColor = System.Drawing.Color.Transparent;
            this.navItem4.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.navItem4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.navItem4.Location = new System.Drawing.Point(6, 60);
            this.navItem4.Name = "navItem4";
            this.navItem4.Size = new System.Drawing.Size(76, 15);
            this.navItem4.TabIndex = 3;
            this.navItem4.Text = "• L. Personal";
            this.navItem4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.navItem4.Click += new System.EventHandler(this.navItem4_Click);
            this.navItem4.MouseEnter += new System.EventHandler(this.navItem4_MouseEnter);
            this.navItem4.MouseLeave += new System.EventHandler(this.navItem4_MouseLeave);
            // 
            // navItem3
            // 
            this.navItem3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.navItem3.AutoSize = true;
            this.navItem3.BackColor = System.Drawing.Color.Transparent;
            this.navItem3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.navItem3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.navItem3.Location = new System.Drawing.Point(6, 45);
            this.navItem3.Name = "navItem3";
            this.navItem3.Size = new System.Drawing.Size(70, 15);
            this.navItem3.TabIndex = 2;
            this.navItem3.Text = "• L. Laboral";
            this.navItem3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.navItem3.Click += new System.EventHandler(this.navItem3_Click);
            this.navItem3.MouseEnter += new System.EventHandler(this.navItem3_MouseEnter);
            this.navItem3.MouseLeave += new System.EventHandler(this.navItem3_MouseLeave);
            // 
            // navItem2
            // 
            this.navItem2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.navItem2.AutoSize = true;
            this.navItem2.BackColor = System.Drawing.Color.Transparent;
            this.navItem2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.navItem2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.navItem2.Location = new System.Drawing.Point(6, 30);
            this.navItem2.Name = "navItem2";
            this.navItem2.Size = new System.Drawing.Size(114, 15);
            this.navItem2.TabIndex = 1;
            this.navItem2.Text = "• L. Documentación";
            this.navItem2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.navItem2.Click += new System.EventHandler(this.navItem2_Click);
            this.navItem2.MouseEnter += new System.EventHandler(this.navItem2_MouseEnter);
            this.navItem2.MouseLeave += new System.EventHandler(this.navItem2_MouseLeave);
            // 
            // navItem1
            // 
            this.navItem1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.navItem1.AutoSize = true;
            this.navItem1.BackColor = System.Drawing.Color.Transparent;
            this.navItem1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.navItem1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.navItem1.Location = new System.Drawing.Point(6, 15);
            this.navItem1.Name = "navItem1";
            this.navItem1.Size = new System.Drawing.Size(119, 15);
            this.navItem1.TabIndex = 0;
            this.navItem1.Text = "• L. Currículum Vitae";
            this.navItem1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.navItem1.Click += new System.EventHandler(this.navItem1_Click);
            this.navItem1.MouseEnter += new System.EventHandler(this.navItem1_MouseEnter);
            this.navItem1.MouseLeave += new System.EventHandler(this.navItem1_MouseLeave);
            // 
            // FormBaseABM_RRHH
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1006, 687);
            this.Controls.Add(this.panelLista);
            this.Controls.Add(this.pictureSeparador1);
            this.Controls.Add(this.pictureSeparador2);
            this.Controls.Add(this.btnPDF_Registro);
            this.Controls.Add(this.btnExcel_Registro);
            this.Controls.Add(this.btnAnular);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.labelPublicacion);
            this.Controls.Add(this.groupNavegacion);
            this.Name = "FormBaseABM_RRHH";
            this.Load += new System.EventHandler(this.FormBaseABM_RRHH_Load);
            this.Controls.SetChildIndex(this.groupNavegacion, 0);
            this.Controls.SetChildIndex(this.labelPublicacion, 0);
            this.Controls.SetChildIndex(this.btnNuevo, 0);
            this.Controls.SetChildIndex(this.btnGuardar, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnAnular, 0);
            this.Controls.SetChildIndex(this.btnExcel_Registro, 0);
            this.Controls.SetChildIndex(this.btnPDF_Registro, 0);
            this.Controls.SetChildIndex(this.pictureSeparador2, 0);
            this.Controls.SetChildIndex(this.pictureSeparador1, 0);
            this.Controls.SetChildIndex(this.panelLista, 0);
            this.Controls.SetChildIndex(this.labelTitulo, 0);
            this.Controls.SetChildIndex(this.btnCerrar, 0);
            this.Controls.SetChildIndex(this.labelUsuario, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pictureSeparador1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureSeparador2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fondoPaginacion)).EndInit();
            this.panelLista.ResumeLayout(false);
            this.panelLista.PerformLayout();
            this.groupNavegacion.ResumeLayout(false);
            this.groupNavegacion.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public MiLabel labelPublicacion;
        public MiButtonBase btnNuevo;
        public MiButtonBase btnGuardar;
        public MiButtonBase btnCancelar;
        public MiButtonBase btnAnular;
        public MiButtonExcel btnExcel_Registro;
        public MiButtonPDF btnPDF_Registro;
        private System.Windows.Forms.PictureBox pictureSeparador1;
        private System.Windows.Forms.PictureBox pictureSeparador2;
        public MiDateTimePicker pkrFiltroListaDesde;
        public MiDateTimePicker pkrFiltroListaHasta;
        public System.Windows.Forms.Label lblTituloLista;
        public MiComboBox cmbFiltroLista1;
        public MiComboBox cmbFiltroLista2;
        public MiTextBox txtFiltroLista;
        public MiButtonExcel btnExcel_Lista;
        public MiButtonPDF btnPDF_Lista;
        private System.Windows.Forms.PictureBox fondoPaginacion;
        public System.Windows.Forms.Label lblCatalagoTitulo1;
        public System.Windows.Forms.Label lblCatalagoTitulo2;
        public System.Windows.Forms.Label lblCatalagoTitulo3;
        public System.Windows.Forms.Label lblCatalagoTitulo4;
        public System.Windows.Forms.Label lblCatalagoTitulo5;
        public System.Windows.Forms.ListBox lstCatalogo;
        public System.Windows.Forms.Panel panelLista;
        private System.Windows.Forms.Label lblPaginacion;
        private MiButton20x20 btnPaginacionFinal;
        private MiButton20x20 btnPaginacionPosterior;
        private MiButton20x20 btnPaginacionAnterior;
        private MiButton20x20 btnPaginacionInicial;
        public System.Windows.Forms.Label lblCatalagoTitulo6;
        private System.Windows.Forms.GroupBox groupNavegacion;
        private MiLabel navItem1;
        private MiLabel navItem11;
        private MiLabel navItem13;
        private MiLabel navItem10;
        private MiLabel navItem12;
        private MiLabel navItem9;
        private MiLabel navItem8;
        private MiLabel navItem7;
        private MiLabel navItem6;
        private MiLabel navItem5;
        private MiLabel navItem4;
        private MiLabel navItem3;
        private MiLabel navItem2;
        private MiLabel navItem14;
    }
}
