namespace CapaPresentacion
{
    partial class FormBusquedaPostulante
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                nBusquedaPostulante.Dispose();
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.miLabel1 = new Biblioteca.Controles.MiLabel();
            this.cmbPerfilLaboral = new Biblioteca.Controles.MiComboBox();
            this.chkTrabajoEmpreminsa = new Biblioteca.Controles.MiCheckBox();
            this.cmbDisponibilidad = new Biblioteca.Controles.MiComboBox();
            this.miLabel9 = new Biblioteca.Controles.MiLabel();
            this.cmbCalificacion = new Biblioteca.Controles.MiComboBox();
            this.miLabel7 = new Biblioteca.Controles.MiLabel();
            this.chkCurriculumVitaeVigente = new Biblioteca.Controles.MiCheckBox();
            this.chkCertificadoAntecedentesVigente = new Biblioteca.Controles.MiCheckBox();
            this.chkCursoInduccionVigenteAprobado = new Biblioteca.Controles.MiCheckBox();
            this.chkCursoIzajeVigente = new Biblioteca.Controles.MiCheckBox();
            this.chkLicenciaConducirVigente = new Biblioteca.Controles.MiCheckBox();
            this.chkExamenMedicoVigenteApto = new Biblioteca.Controles.MiCheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.fondoPaginacion)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCatalagoTitulo5
            // 
            this.lblCatalagoTitulo5.Location = new System.Drawing.Point(849, 220);
            this.lblCatalagoTitulo5.TabIndex = 21;
            this.lblCatalagoTitulo5.Visible = false;
            // 
            // lblCatalagoTitulo4
            // 
            this.lblCatalagoTitulo4.Location = new System.Drawing.Point(609, 220);
            this.lblCatalagoTitulo4.Size = new System.Drawing.Size(60, 14);
            this.lblCatalagoTitulo4.TabIndex = 20;
            this.lblCatalagoTitulo4.Text = "Celular(es)";
            // 
            // lblCatalagoTitulo3
            // 
            this.lblCatalagoTitulo3.Location = new System.Drawing.Point(497, 220);
            this.lblCatalagoTitulo3.Size = new System.Drawing.Size(54, 14);
            this.lblCatalagoTitulo3.TabIndex = 19;
            this.lblCatalagoTitulo3.Text = "CUIL/CUIT";
            // 
            // lblCatalagoTitulo2
            // 
            this.lblCatalagoTitulo2.Location = new System.Drawing.Point(231, 220);
            this.lblCatalagoTitulo2.TabIndex = 18;
            // 
            // lblCatalagoTitulo1
            // 
            this.lblCatalagoTitulo1.Location = new System.Drawing.Point(161, 220);
            this.lblCatalagoTitulo1.TabIndex = 17;
            // 
            // lstCatalogo
            // 
            this.lstCatalogo.Location = new System.Drawing.Point(160, 236);
            this.lstCatalogo.Size = new System.Drawing.Size(840, 398);
            this.lstCatalogo.TabIndex = 27;
            // 
            // fondoPaginacion
            // 
            this.fondoPaginacion.Location = new System.Drawing.Point(160, 217);
            this.fondoPaginacion.Size = new System.Drawing.Size(840, 20);
            // 
            // lblPaginacion
            // 
            this.lblPaginacion.Location = new System.Drawing.Point(937, 219);
            this.lblPaginacion.TabIndex = 24;
            // 
            // btnPaginacionFinal
            // 
            this.btnPaginacionFinal.FlatAppearance.BorderSize = 0;
            this.btnPaginacionFinal.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnPaginacionFinal.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnPaginacionFinal.Location = new System.Drawing.Point(982, 219);
            this.btnPaginacionFinal.TabIndex = 26;
            // 
            // btnPaginacionPosterior
            // 
            this.btnPaginacionPosterior.FlatAppearance.BorderSize = 0;
            this.btnPaginacionPosterior.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnPaginacionPosterior.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnPaginacionPosterior.Location = new System.Drawing.Point(964, 219);
            this.btnPaginacionPosterior.TabIndex = 25;
            // 
            // btnPaginacionAnterior
            // 
            this.btnPaginacionAnterior.FlatAppearance.BorderSize = 0;
            this.btnPaginacionAnterior.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnPaginacionAnterior.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnPaginacionAnterior.Location = new System.Drawing.Point(919, 219);
            this.btnPaginacionAnterior.TabIndex = 23;
            // 
            // btnPaginacionInicial
            // 
            this.btnPaginacionInicial.FlatAppearance.BorderSize = 0;
            this.btnPaginacionInicial.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnPaginacionInicial.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnPaginacionInicial.Location = new System.Drawing.Point(901, 219);
            this.btnPaginacionInicial.TabIndex = 22;
            // 
            // btnPDF_Lista
            // 
            this.btnPDF_Lista.Enabled = false;
            this.btnPDF_Lista.FlatAppearance.BorderSize = 0;
            this.btnPDF_Lista.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnPDF_Lista.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnPDF_Lista.Location = new System.Drawing.Point(401, 60);
            this.btnPDF_Lista.TabIndex = 5;
            this.btnPDF_Lista.Visible = false;
            // 
            // btnExcel_Lista
            // 
            this.btnExcel_Lista.FlatAppearance.BorderSize = 0;
            this.btnExcel_Lista.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnExcel_Lista.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnExcel_Lista.Location = new System.Drawing.Point(371, 60);
            this.btnExcel_Lista.TabIndex = 4;
            // 
            // labelTitulo
            // 
            this.labelTitulo.Text = "Búsqueda de Postulantes";
            // 
            // btnCerrar
            // 
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnCerrar.TabIndex = 28;
            // 
            // miLabel1
            // 
            this.miLabel1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel1.BackColor = System.Drawing.Color.Transparent;
            this.miLabel1.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel1.Location = new System.Drawing.Point(0, 64);
            this.miLabel1.Name = "miLabel1";
            this.miLabel1.Size = new System.Drawing.Size(160, 15);
            this.miLabel1.TabIndex = 2;
            this.miLabel1.Text = "Perfil laboral";
            this.miLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbPerfilLaboral
            // 
            this.cmbPerfilLaboral.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cmbPerfilLaboral.BackColor = System.Drawing.Color.White;
            this.cmbPerfilLaboral.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPerfilLaboral.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbPerfilLaboral.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.cmbPerfilLaboral.ForeColor = System.Drawing.Color.Black;
            this.cmbPerfilLaboral.FormattingEnabled = true;
            this.cmbPerfilLaboral.ItemHeight = 14;
            this.cmbPerfilLaboral.Location = new System.Drawing.Point(160, 61);
            this.cmbPerfilLaboral.Margin = new System.Windows.Forms.Padding(1);
            this.cmbPerfilLaboral.Name = "cmbPerfilLaboral";
            this.cmbPerfilLaboral.Size = new System.Drawing.Size(210, 22);
            this.cmbPerfilLaboral.Sorted = true;
            this.cmbPerfilLaboral.TabIndex = 3;
            this.cmbPerfilLaboral.SelectedIndexChanged += new System.EventHandler(this.cmbPerfilLaboral_SelectedIndexChanged);
            // 
            // chkTrabajoEmpreminsa
            // 
            this.chkTrabajoEmpreminsa.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.chkTrabajoEmpreminsa.AutoSize = true;
            this.chkTrabajoEmpreminsa.BackColor = System.Drawing.Color.Transparent;
            this.chkTrabajoEmpreminsa.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.chkTrabajoEmpreminsa.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkTrabajoEmpreminsa.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.chkTrabajoEmpreminsa.Location = new System.Drawing.Point(160, 91);
            this.chkTrabajoEmpreminsa.Name = "chkTrabajoEmpreminsa";
            this.chkTrabajoEmpreminsa.Size = new System.Drawing.Size(160, 19);
            this.chkTrabajoEmpreminsa.TabIndex = 6;
            this.chkTrabajoEmpreminsa.Text = "Trabajó en Empreminsa";
            this.chkTrabajoEmpreminsa.UseVisualStyleBackColor = false;
            this.chkTrabajoEmpreminsa.CheckedChanged += new System.EventHandler(this.chkTrabajoEmpreminsa_CheckedChanged);
            // 
            // cmbDisponibilidad
            // 
            this.cmbDisponibilidad.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cmbDisponibilidad.BackColor = System.Drawing.Color.White;
            this.cmbDisponibilidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDisponibilidad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbDisponibilidad.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.cmbDisponibilidad.ForeColor = System.Drawing.Color.Black;
            this.cmbDisponibilidad.FormattingEnabled = true;
            this.cmbDisponibilidad.Items.AddRange(new object[] {
            "ALTA",
            "BAJA",
            "MEDIA",
            "NULA",
            "TODOS"});
            this.cmbDisponibilidad.Location = new System.Drawing.Point(160, 115);
            this.cmbDisponibilidad.Margin = new System.Windows.Forms.Padding(1);
            this.cmbDisponibilidad.Name = "cmbDisponibilidad";
            this.cmbDisponibilidad.Size = new System.Drawing.Size(65, 22);
            this.cmbDisponibilidad.Sorted = true;
            this.cmbDisponibilidad.TabIndex = 8;
            this.cmbDisponibilidad.SelectedIndexChanged += new System.EventHandler(this.cmbDisponibilidad_SelectedIndexChanged);
            // 
            // miLabel9
            // 
            this.miLabel9.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel9.BackColor = System.Drawing.Color.Transparent;
            this.miLabel9.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel9.Location = new System.Drawing.Point(0, 118);
            this.miLabel9.Name = "miLabel9";
            this.miLabel9.Size = new System.Drawing.Size(160, 15);
            this.miLabel9.TabIndex = 7;
            this.miLabel9.Text = "Disponibilidad laboral";
            this.miLabel9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbCalificacion
            // 
            this.cmbCalificacion.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cmbCalificacion.BackColor = System.Drawing.Color.White;
            this.cmbCalificacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCalificacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbCalificacion.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.cmbCalificacion.ForeColor = System.Drawing.Color.Black;
            this.cmbCalificacion.FormattingEnabled = true;
            this.cmbCalificacion.Items.AddRange(new object[] {
            "1 - REPROBADO",
            "2 - ACEPTABLE",
            "3 - COMPETENTE",
            "4 - EXCELENTE",
            "S/CALIFICACION",
            "TODOS"});
            this.cmbCalificacion.Location = new System.Drawing.Point(160, 142);
            this.cmbCalificacion.Margin = new System.Windows.Forms.Padding(1);
            this.cmbCalificacion.Name = "cmbCalificacion";
            this.cmbCalificacion.Size = new System.Drawing.Size(118, 22);
            this.cmbCalificacion.Sorted = true;
            this.cmbCalificacion.TabIndex = 10;
            this.cmbCalificacion.SelectedIndexChanged += new System.EventHandler(this.cmbCalificacion_SelectedIndexChanged);
            // 
            // miLabel7
            // 
            this.miLabel7.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel7.BackColor = System.Drawing.Color.Transparent;
            this.miLabel7.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel7.Location = new System.Drawing.Point(0, 145);
            this.miLabel7.Name = "miLabel7";
            this.miLabel7.Size = new System.Drawing.Size(160, 15);
            this.miLabel7.TabIndex = 9;
            this.miLabel7.Text = "Calificación";
            this.miLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkCurriculumVitaeVigente
            // 
            this.chkCurriculumVitaeVigente.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.chkCurriculumVitaeVigente.AutoSize = true;
            this.chkCurriculumVitaeVigente.BackColor = System.Drawing.Color.Transparent;
            this.chkCurriculumVitaeVigente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.chkCurriculumVitaeVigente.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCurriculumVitaeVigente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.chkCurriculumVitaeVigente.Location = new System.Drawing.Point(160, 193);
            this.chkCurriculumVitaeVigente.Name = "chkCurriculumVitaeVigente";
            this.chkCurriculumVitaeVigente.Size = new System.Drawing.Size(165, 19);
            this.chkCurriculumVitaeVigente.TabIndex = 12;
            this.chkCurriculumVitaeVigente.Text = "Currículum vitae (vigente)";
            this.chkCurriculumVitaeVigente.UseVisualStyleBackColor = false;
            this.chkCurriculumVitaeVigente.CheckedChanged += new System.EventHandler(this.chkCurriculumVitaeVigente_CheckedChanged);
            // 
            // chkCertificadoAntecedentesVigente
            // 
            this.chkCertificadoAntecedentesVigente.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.chkCertificadoAntecedentesVigente.AutoSize = true;
            this.chkCertificadoAntecedentesVigente.BackColor = System.Drawing.Color.Transparent;
            this.chkCertificadoAntecedentesVigente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.chkCertificadoAntecedentesVigente.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCertificadoAntecedentesVigente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.chkCertificadoAntecedentesVigente.Location = new System.Drawing.Point(160, 172);
            this.chkCertificadoAntecedentesVigente.Name = "chkCertificadoAntecedentesVigente";
            this.chkCertificadoAntecedentesVigente.Size = new System.Drawing.Size(230, 19);
            this.chkCertificadoAntecedentesVigente.TabIndex = 11;
            this.chkCertificadoAntecedentesVigente.Text = "Certificado de antecedentes (vigente)";
            this.chkCertificadoAntecedentesVigente.UseVisualStyleBackColor = false;
            this.chkCertificadoAntecedentesVigente.CheckedChanged += new System.EventHandler(this.chkCertificadoAntecedentesVigente_CheckedChanged);
            // 
            // chkCursoInduccionVigenteAprobado
            // 
            this.chkCursoInduccionVigenteAprobado.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.chkCursoInduccionVigenteAprobado.AutoSize = true;
            this.chkCursoInduccionVigenteAprobado.BackColor = System.Drawing.Color.Transparent;
            this.chkCursoInduccionVigenteAprobado.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.chkCursoInduccionVigenteAprobado.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCursoInduccionVigenteAprobado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.chkCursoInduccionVigenteAprobado.Location = new System.Drawing.Point(439, 172);
            this.chkCursoInduccionVigenteAprobado.Name = "chkCursoInduccionVigenteAprobado";
            this.chkCursoInduccionVigenteAprobado.Size = new System.Drawing.Size(247, 19);
            this.chkCursoInduccionVigenteAprobado.TabIndex = 13;
            this.chkCursoInduccionVigenteAprobado.Text = "Curso de Inducción (vigente y aprobado)";
            this.chkCursoInduccionVigenteAprobado.UseVisualStyleBackColor = false;
            this.chkCursoInduccionVigenteAprobado.CheckedChanged += new System.EventHandler(this.chkCursoInduccionVigenteAprobado_CheckedChanged);
            // 
            // chkCursoIzajeVigente
            // 
            this.chkCursoIzajeVigente.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.chkCursoIzajeVigente.AutoSize = true;
            this.chkCursoIzajeVigente.BackColor = System.Drawing.Color.Transparent;
            this.chkCursoIzajeVigente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.chkCursoIzajeVigente.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCursoIzajeVigente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.chkCursoIzajeVigente.Location = new System.Drawing.Point(439, 193);
            this.chkCursoIzajeVigente.Name = "chkCursoIzajeVigente";
            this.chkCursoIzajeVigente.Size = new System.Drawing.Size(155, 19);
            this.chkCursoIzajeVigente.TabIndex = 14;
            this.chkCursoIzajeVigente.Text = "Curso de Izaje (vigente)";
            this.chkCursoIzajeVigente.UseVisualStyleBackColor = false;
            this.chkCursoIzajeVigente.CheckedChanged += new System.EventHandler(this.chkCursoIzajeVigente_CheckedChanged);
            // 
            // chkLicenciaConducirVigente
            // 
            this.chkLicenciaConducirVigente.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.chkLicenciaConducirVigente.AutoSize = true;
            this.chkLicenciaConducirVigente.BackColor = System.Drawing.Color.Transparent;
            this.chkLicenciaConducirVigente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.chkLicenciaConducirVigente.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkLicenciaConducirVigente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.chkLicenciaConducirVigente.Location = new System.Drawing.Point(718, 193);
            this.chkLicenciaConducirVigente.Name = "chkLicenciaConducirVigente";
            this.chkLicenciaConducirVigente.Size = new System.Drawing.Size(189, 19);
            this.chkLicenciaConducirVigente.TabIndex = 16;
            this.chkLicenciaConducirVigente.Text = "Licencia de conducir (vigente)";
            this.chkLicenciaConducirVigente.UseVisualStyleBackColor = false;
            this.chkLicenciaConducirVigente.CheckedChanged += new System.EventHandler(this.chkLicenciaConducirVigente_CheckedChanged);
            // 
            // chkExamenMedicoVigenteApto
            // 
            this.chkExamenMedicoVigenteApto.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.chkExamenMedicoVigenteApto.AutoSize = true;
            this.chkExamenMedicoVigenteApto.BackColor = System.Drawing.Color.Transparent;
            this.chkExamenMedicoVigenteApto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.chkExamenMedicoVigenteApto.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkExamenMedicoVigenteApto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.chkExamenMedicoVigenteApto.Location = new System.Drawing.Point(718, 172);
            this.chkExamenMedicoVigenteApto.Name = "chkExamenMedicoVigenteApto";
            this.chkExamenMedicoVigenteApto.Size = new System.Drawing.Size(200, 19);
            this.chkExamenMedicoVigenteApto.TabIndex = 15;
            this.chkExamenMedicoVigenteApto.Text = "Examen médico (vigente y apto)";
            this.chkExamenMedicoVigenteApto.UseVisualStyleBackColor = false;
            this.chkExamenMedicoVigenteApto.CheckedChanged += new System.EventHandler(this.chkExamenMedicoVigenteApto_CheckedChanged);
            // 
            // FormBusquedaPostulante
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 687);
            this.Controls.Add(this.chkLicenciaConducirVigente);
            this.Controls.Add(this.chkExamenMedicoVigenteApto);
            this.Controls.Add(this.chkCursoIzajeVigente);
            this.Controls.Add(this.chkCursoInduccionVigenteAprobado);
            this.Controls.Add(this.chkCurriculumVitaeVigente);
            this.Controls.Add(this.chkCertificadoAntecedentesVigente);
            this.Controls.Add(this.cmbCalificacion);
            this.Controls.Add(this.miLabel7);
            this.Controls.Add(this.cmbDisponibilidad);
            this.Controls.Add(this.miLabel9);
            this.Controls.Add(this.chkTrabajoEmpreminsa);
            this.Controls.Add(this.miLabel1);
            this.Controls.Add(this.cmbPerfilLaboral);
            this.Name = "FormBusquedaPostulante";
            this.Text = "Búsqueda de Postulantes";
            this.Load += new System.EventHandler(this.FormBusquedaPostulante_Load);
            this.Controls.SetChildIndex(this.btnPDF_Lista, 0);
            this.Controls.SetChildIndex(this.fondoPaginacion, 0);
            this.Controls.SetChildIndex(this.labelTitulo, 0);
            this.Controls.SetChildIndex(this.btnCerrar, 0);
            this.Controls.SetChildIndex(this.labelUsuario, 0);
            this.Controls.SetChildIndex(this.lstCatalogo, 0);
            this.Controls.SetChildIndex(this.btnPaginacionInicial, 0);
            this.Controls.SetChildIndex(this.btnPaginacionAnterior, 0);
            this.Controls.SetChildIndex(this.btnPaginacionPosterior, 0);
            this.Controls.SetChildIndex(this.btnPaginacionFinal, 0);
            this.Controls.SetChildIndex(this.lblPaginacion, 0);
            this.Controls.SetChildIndex(this.lblCatalagoTitulo1, 0);
            this.Controls.SetChildIndex(this.lblCatalagoTitulo2, 0);
            this.Controls.SetChildIndex(this.lblCatalagoTitulo3, 0);
            this.Controls.SetChildIndex(this.lblCatalagoTitulo4, 0);
            this.Controls.SetChildIndex(this.lblCatalagoTitulo5, 0);
            this.Controls.SetChildIndex(this.btnExcel_Lista, 0);
            this.Controls.SetChildIndex(this.cmbPerfilLaboral, 0);
            this.Controls.SetChildIndex(this.miLabel1, 0);
            this.Controls.SetChildIndex(this.chkTrabajoEmpreminsa, 0);
            this.Controls.SetChildIndex(this.miLabel9, 0);
            this.Controls.SetChildIndex(this.cmbDisponibilidad, 0);
            this.Controls.SetChildIndex(this.miLabel7, 0);
            this.Controls.SetChildIndex(this.cmbCalificacion, 0);
            this.Controls.SetChildIndex(this.chkCertificadoAntecedentesVigente, 0);
            this.Controls.SetChildIndex(this.chkCurriculumVitaeVigente, 0);
            this.Controls.SetChildIndex(this.chkCursoInduccionVigenteAprobado, 0);
            this.Controls.SetChildIndex(this.chkCursoIzajeVigente, 0);
            this.Controls.SetChildIndex(this.chkExamenMedicoVigenteApto, 0);
            this.Controls.SetChildIndex(this.chkLicenciaConducirVigente, 0);
            ((System.ComponentModel.ISupportInitialize)(this.fondoPaginacion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Biblioteca.Controles.MiLabel miLabel1;
        private Biblioteca.Controles.MiComboBox cmbPerfilLaboral;
        private Biblioteca.Controles.MiCheckBox chkTrabajoEmpreminsa;
        private Biblioteca.Controles.MiComboBox cmbDisponibilidad;
        private Biblioteca.Controles.MiLabel miLabel9;
        private Biblioteca.Controles.MiComboBox cmbCalificacion;
        private Biblioteca.Controles.MiLabel miLabel7;
        private Biblioteca.Controles.MiCheckBox chkCurriculumVitaeVigente;
        private Biblioteca.Controles.MiCheckBox chkCertificadoAntecedentesVigente;
        private Biblioteca.Controles.MiCheckBox chkCursoInduccionVigenteAprobado;
        private Biblioteca.Controles.MiCheckBox chkCursoIzajeVigente;
        private Biblioteca.Controles.MiCheckBox chkLicenciaConducirVigente;
        private Biblioteca.Controles.MiCheckBox chkExamenMedicoVigenteApto;
    }
}