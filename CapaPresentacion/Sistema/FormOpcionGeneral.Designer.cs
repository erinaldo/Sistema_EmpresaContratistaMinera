using Biblioteca.Controles;

namespace CapaPresentacion
{
    partial class FormOpcionGeneral
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
                nOpcionGeneral.Dispose();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormOpcionGeneral));
            this.groupVigencia = new System.Windows.Forms.GroupBox();
            this.miLabel5 = new Biblioteca.Controles.MiLabel();
            this.txtVigenciaExamenMedico = new Biblioteca.Controles.MiMaskedTextBox();
            this.miLabel4 = new Biblioteca.Controles.MiLabel();
            this.txtVigenciaCursoIzaje = new Biblioteca.Controles.MiMaskedTextBox();
            this.miLabel3 = new Biblioteca.Controles.MiLabel();
            this.txtVigenciaCursoInduccion = new Biblioteca.Controles.MiMaskedTextBox();
            this.txtVigenciaCurriculumVitae = new Biblioteca.Controles.MiMaskedTextBox();
            this.txtVigenciaCertificadoAntecedente = new Biblioteca.Controles.MiMaskedTextBox();
            this.miLabel2 = new Biblioteca.Controles.MiLabel();
            this.miLabel1 = new Biblioteca.Controles.MiLabel();
            this.groupAlerta = new System.Windows.Forms.GroupBox();
            this.miLabel11 = new Biblioteca.Controles.MiLabel();
            this.txtAlertaLicenciaConducir = new Biblioteca.Controles.MiMaskedTextBox();
            this.miLabel10 = new Biblioteca.Controles.MiLabel();
            this.txtAlertaExamenMedico = new Biblioteca.Controles.MiMaskedTextBox();
            this.miLabel9 = new Biblioteca.Controles.MiLabel();
            this.txtAlertaEntrevistaTrabajo = new Biblioteca.Controles.MiMaskedTextBox();
            this.miLabel8 = new Biblioteca.Controles.MiLabel();
            this.txtAlertaCursoIzaje = new Biblioteca.Controles.MiMaskedTextBox();
            this.txtAlertaCursoInduccion = new Biblioteca.Controles.MiMaskedTextBox();
            this.txtAlertaCertificadoAntecedente = new Biblioteca.Controles.MiMaskedTextBox();
            this.miLabel7 = new Biblioteca.Controles.MiLabel();
            this.miLabel6 = new Biblioteca.Controles.MiLabel();
            this.groupLiquidacionSueldo = new System.Windows.Forms.GroupBox();
            this.miLabel17 = new Biblioteca.Controles.MiLabel();
            this.txtLiquidacionSueldoSCVO = new Biblioteca.Controles.MiTextBox();
            this.miLabel16 = new Biblioteca.Controles.MiLabel();
            this.txtLiquidacionSueldoTiempoParcial = new Biblioteca.Controles.MiTextBox();
            this.miLabel15 = new Biblioteca.Controles.MiLabel();
            this.txtLiquidacionSueldoTiempoCompleto = new Biblioteca.Controles.MiTextBox();
            this.miLabel14 = new Biblioteca.Controles.MiLabel();
            this.txtLiquidacionSueldoART_Tasa = new Biblioteca.Controles.MiTextBox();
            this.txtLiquidacionSueldoART_Fijo = new Biblioteca.Controles.MiTextBox();
            this.txtLiquidacionSueldoAporte = new Biblioteca.Controles.MiTextBox();
            this.miLabel13 = new Biblioteca.Controles.MiLabel();
            this.miLabel12 = new Biblioteca.Controles.MiLabel();
            this.grouptxtEstadoResultado = new System.Windows.Forms.GroupBox();
            this.miLabel20 = new Biblioteca.Controles.MiLabel();
            this.miLabel19 = new Biblioteca.Controles.MiLabel();
            this.miLabel18 = new Biblioteca.Controles.MiLabel();
            this.txtEstadoResultadoGanancia = new Biblioteca.Controles.MiTextBox();
            this.txtEstadoResultadoSAC = new Biblioteca.Controles.MiTextBox();
            this.txtEstadoResultadoIIBB = new Biblioteca.Controles.MiTextBox();
            this.btnCancelar = new Biblioteca.Controles.MiButtonBase();
            this.btnGuardar = new Biblioteca.Controles.MiButtonBase();
            this.labelPublicacion = new Biblioteca.Controles.MiLabel();
            this.miLabel21 = new Biblioteca.Controles.MiLabel();
            this.txtTPV = new Biblioteca.Controles.MiTextBox();
            this.btnPDF_Registro = new Biblioteca.Controles.MiButtonPDF();
            this.btnExcel_Registro = new Biblioteca.Controles.MiButtonExcel();
            this.miLabel22 = new Biblioteca.Controles.MiLabel();
            this.txtTiempoAnulacion = new Biblioteca.Controles.MiMaskedTextBox();
            this.miLabel23 = new Biblioteca.Controles.MiLabel();
            this.txtTiempoModificacion = new Biblioteca.Controles.MiMaskedTextBox();
            this.groupVigencia.SuspendLayout();
            this.groupAlerta.SuspendLayout();
            this.groupLiquidacionSueldo.SuspendLayout();
            this.grouptxtEstadoResultado.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelTitulo
            // 
            this.labelTitulo.Text = "Opciones Generales";
            // 
            // btnCerrar
            // 
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnCerrar.TabIndex = 13;
            // 
            // labelUsuario
            // 
            this.labelUsuario.TabIndex = 1;
            this.labelUsuario.Text = "Sesión de : ";
            // 
            // groupVigencia
            // 
            this.groupVigencia.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.groupVigencia.Controls.Add(this.miLabel5);
            this.groupVigencia.Controls.Add(this.txtVigenciaExamenMedico);
            this.groupVigencia.Controls.Add(this.miLabel4);
            this.groupVigencia.Controls.Add(this.txtVigenciaCursoIzaje);
            this.groupVigencia.Controls.Add(this.miLabel3);
            this.groupVigencia.Controls.Add(this.txtVigenciaCursoInduccion);
            this.groupVigencia.Controls.Add(this.txtVigenciaCurriculumVitae);
            this.groupVigencia.Controls.Add(this.txtVigenciaCertificadoAntecedente);
            this.groupVigencia.Controls.Add(this.miLabel2);
            this.groupVigencia.Controls.Add(this.miLabel1);
            this.groupVigencia.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupVigencia.ForeColor = System.Drawing.Color.Gray;
            this.groupVigencia.Location = new System.Drawing.Point(160, 169);
            this.groupVigencia.Name = "groupVigencia";
            this.groupVigencia.Size = new System.Drawing.Size(578, 75);
            this.groupVigencia.TabIndex = 6;
            this.groupVigencia.TabStop = false;
            this.groupVigencia.Text = "Vigencias del Sistema: Establecer los tiempos de cada elemento (meses)";
            // 
            // miLabel5
            // 
            this.miLabel5.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel5.BackColor = System.Drawing.Color.Transparent;
            this.miLabel5.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel5.Location = new System.Drawing.Point(382, 22);
            this.miLabel5.Name = "miLabel5";
            this.miLabel5.Size = new System.Drawing.Size(160, 15);
            this.miLabel5.TabIndex = 8;
            this.miLabel5.Text = "Examen médico";
            this.miLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtVigenciaExamenMedico
            // 
            this.txtVigenciaExamenMedico.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtVigenciaExamenMedico.BackColor = System.Drawing.Color.White;
            this.txtVigenciaExamenMedico.BeepOnError = true;
            this.txtVigenciaExamenMedico.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtVigenciaExamenMedico.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtVigenciaExamenMedico.ForeColor = System.Drawing.Color.Black;
            this.txtVigenciaExamenMedico.HidePromptOnLeave = true;
            this.txtVigenciaExamenMedico.Location = new System.Drawing.Point(542, 19);
            this.txtVigenciaExamenMedico.Mask = "999";
            this.txtVigenciaExamenMedico.Name = "txtVigenciaExamenMedico";
            this.txtVigenciaExamenMedico.PromptChar = ' ';
            this.txtVigenciaExamenMedico.Size = new System.Drawing.Size(30, 22);
            this.txtVigenciaExamenMedico.TabIndex = 9;
            // 
            // miLabel4
            // 
            this.miLabel4.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel4.BackColor = System.Drawing.Color.Transparent;
            this.miLabel4.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel4.Location = new System.Drawing.Point(191, 49);
            this.miLabel4.Name = "miLabel4";
            this.miLabel4.Size = new System.Drawing.Size(160, 15);
            this.miLabel4.TabIndex = 6;
            this.miLabel4.Text = "Curso de izaje";
            this.miLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtVigenciaCursoIzaje
            // 
            this.txtVigenciaCursoIzaje.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtVigenciaCursoIzaje.BackColor = System.Drawing.Color.White;
            this.txtVigenciaCursoIzaje.BeepOnError = true;
            this.txtVigenciaCursoIzaje.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtVigenciaCursoIzaje.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtVigenciaCursoIzaje.ForeColor = System.Drawing.Color.Black;
            this.txtVigenciaCursoIzaje.HidePromptOnLeave = true;
            this.txtVigenciaCursoIzaje.Location = new System.Drawing.Point(351, 46);
            this.txtVigenciaCursoIzaje.Mask = "999";
            this.txtVigenciaCursoIzaje.Name = "txtVigenciaCursoIzaje";
            this.txtVigenciaCursoIzaje.PromptChar = ' ';
            this.txtVigenciaCursoIzaje.Size = new System.Drawing.Size(30, 22);
            this.txtVigenciaCursoIzaje.TabIndex = 7;
            // 
            // miLabel3
            // 
            this.miLabel3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel3.BackColor = System.Drawing.Color.Transparent;
            this.miLabel3.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel3.Location = new System.Drawing.Point(191, 22);
            this.miLabel3.Name = "miLabel3";
            this.miLabel3.Size = new System.Drawing.Size(160, 15);
            this.miLabel3.TabIndex = 4;
            this.miLabel3.Text = "Curso de inducción";
            this.miLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtVigenciaCursoInduccion
            // 
            this.txtVigenciaCursoInduccion.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtVigenciaCursoInduccion.BackColor = System.Drawing.Color.White;
            this.txtVigenciaCursoInduccion.BeepOnError = true;
            this.txtVigenciaCursoInduccion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtVigenciaCursoInduccion.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtVigenciaCursoInduccion.ForeColor = System.Drawing.Color.Black;
            this.txtVigenciaCursoInduccion.HidePromptOnLeave = true;
            this.txtVigenciaCursoInduccion.Location = new System.Drawing.Point(351, 19);
            this.txtVigenciaCursoInduccion.Mask = "999";
            this.txtVigenciaCursoInduccion.Name = "txtVigenciaCursoInduccion";
            this.txtVigenciaCursoInduccion.PromptChar = ' ';
            this.txtVigenciaCursoInduccion.Size = new System.Drawing.Size(30, 22);
            this.txtVigenciaCursoInduccion.TabIndex = 5;
            // 
            // txtVigenciaCurriculumVitae
            // 
            this.txtVigenciaCurriculumVitae.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtVigenciaCurriculumVitae.BackColor = System.Drawing.Color.White;
            this.txtVigenciaCurriculumVitae.BeepOnError = true;
            this.txtVigenciaCurriculumVitae.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtVigenciaCurriculumVitae.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtVigenciaCurriculumVitae.ForeColor = System.Drawing.Color.Black;
            this.txtVigenciaCurriculumVitae.HidePromptOnLeave = true;
            this.txtVigenciaCurriculumVitae.Location = new System.Drawing.Point(160, 46);
            this.txtVigenciaCurriculumVitae.Mask = "999";
            this.txtVigenciaCurriculumVitae.Name = "txtVigenciaCurriculumVitae";
            this.txtVigenciaCurriculumVitae.PromptChar = ' ';
            this.txtVigenciaCurriculumVitae.Size = new System.Drawing.Size(30, 22);
            this.txtVigenciaCurriculumVitae.TabIndex = 3;
            // 
            // txtVigenciaCertificadoAntecedente
            // 
            this.txtVigenciaCertificadoAntecedente.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtVigenciaCertificadoAntecedente.BackColor = System.Drawing.Color.White;
            this.txtVigenciaCertificadoAntecedente.BeepOnError = true;
            this.txtVigenciaCertificadoAntecedente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtVigenciaCertificadoAntecedente.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtVigenciaCertificadoAntecedente.ForeColor = System.Drawing.Color.Black;
            this.txtVigenciaCertificadoAntecedente.HidePromptOnLeave = true;
            this.txtVigenciaCertificadoAntecedente.Location = new System.Drawing.Point(160, 19);
            this.txtVigenciaCertificadoAntecedente.Mask = "999";
            this.txtVigenciaCertificadoAntecedente.Name = "txtVigenciaCertificadoAntecedente";
            this.txtVigenciaCertificadoAntecedente.PromptChar = ' ';
            this.txtVigenciaCertificadoAntecedente.Size = new System.Drawing.Size(30, 22);
            this.txtVigenciaCertificadoAntecedente.TabIndex = 1;
            // 
            // miLabel2
            // 
            this.miLabel2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel2.BackColor = System.Drawing.Color.Transparent;
            this.miLabel2.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel2.Location = new System.Drawing.Point(0, 49);
            this.miLabel2.Name = "miLabel2";
            this.miLabel2.Size = new System.Drawing.Size(160, 15);
            this.miLabel2.TabIndex = 2;
            this.miLabel2.Text = "Currículum vitae";
            this.miLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // miLabel1
            // 
            this.miLabel1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel1.BackColor = System.Drawing.Color.Transparent;
            this.miLabel1.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel1.Location = new System.Drawing.Point(0, 22);
            this.miLabel1.Name = "miLabel1";
            this.miLabel1.Size = new System.Drawing.Size(160, 15);
            this.miLabel1.TabIndex = 0;
            this.miLabel1.Text = "Certif. de antecedentes";
            this.miLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupAlerta
            // 
            this.groupAlerta.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.groupAlerta.Controls.Add(this.miLabel11);
            this.groupAlerta.Controls.Add(this.txtAlertaLicenciaConducir);
            this.groupAlerta.Controls.Add(this.miLabel10);
            this.groupAlerta.Controls.Add(this.txtAlertaExamenMedico);
            this.groupAlerta.Controls.Add(this.miLabel9);
            this.groupAlerta.Controls.Add(this.txtAlertaEntrevistaTrabajo);
            this.groupAlerta.Controls.Add(this.miLabel8);
            this.groupAlerta.Controls.Add(this.txtAlertaCursoIzaje);
            this.groupAlerta.Controls.Add(this.txtAlertaCursoInduccion);
            this.groupAlerta.Controls.Add(this.txtAlertaCertificadoAntecedente);
            this.groupAlerta.Controls.Add(this.miLabel7);
            this.groupAlerta.Controls.Add(this.miLabel6);
            this.groupAlerta.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupAlerta.ForeColor = System.Drawing.Color.Gray;
            this.groupAlerta.Location = new System.Drawing.Point(160, 89);
            this.groupAlerta.Name = "groupAlerta";
            this.groupAlerta.Size = new System.Drawing.Size(578, 75);
            this.groupAlerta.TabIndex = 5;
            this.groupAlerta.TabStop = false;
            this.groupAlerta.Text = "Alertas del Sistema: Establecer cuando se debe generar cada alerta (días antes de" +
    "l vencimiento)";
            // 
            // miLabel11
            // 
            this.miLabel11.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel11.BackColor = System.Drawing.Color.Transparent;
            this.miLabel11.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel11.Location = new System.Drawing.Point(382, 49);
            this.miLabel11.Name = "miLabel11";
            this.miLabel11.Size = new System.Drawing.Size(160, 15);
            this.miLabel11.TabIndex = 10;
            this.miLabel11.Text = "Licencia de conducir";
            this.miLabel11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtAlertaLicenciaConducir
            // 
            this.txtAlertaLicenciaConducir.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtAlertaLicenciaConducir.BackColor = System.Drawing.Color.White;
            this.txtAlertaLicenciaConducir.BeepOnError = true;
            this.txtAlertaLicenciaConducir.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAlertaLicenciaConducir.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtAlertaLicenciaConducir.ForeColor = System.Drawing.Color.Black;
            this.txtAlertaLicenciaConducir.HidePromptOnLeave = true;
            this.txtAlertaLicenciaConducir.Location = new System.Drawing.Point(542, 46);
            this.txtAlertaLicenciaConducir.Mask = "999";
            this.txtAlertaLicenciaConducir.Name = "txtAlertaLicenciaConducir";
            this.txtAlertaLicenciaConducir.PromptChar = ' ';
            this.txtAlertaLicenciaConducir.Size = new System.Drawing.Size(30, 22);
            this.txtAlertaLicenciaConducir.TabIndex = 11;
            // 
            // miLabel10
            // 
            this.miLabel10.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel10.BackColor = System.Drawing.Color.Transparent;
            this.miLabel10.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel10.Location = new System.Drawing.Point(382, 22);
            this.miLabel10.Name = "miLabel10";
            this.miLabel10.Size = new System.Drawing.Size(160, 15);
            this.miLabel10.TabIndex = 8;
            this.miLabel10.Text = "Examen médico";
            this.miLabel10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtAlertaExamenMedico
            // 
            this.txtAlertaExamenMedico.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtAlertaExamenMedico.BackColor = System.Drawing.Color.White;
            this.txtAlertaExamenMedico.BeepOnError = true;
            this.txtAlertaExamenMedico.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAlertaExamenMedico.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtAlertaExamenMedico.ForeColor = System.Drawing.Color.Black;
            this.txtAlertaExamenMedico.HidePromptOnLeave = true;
            this.txtAlertaExamenMedico.Location = new System.Drawing.Point(542, 19);
            this.txtAlertaExamenMedico.Mask = "999";
            this.txtAlertaExamenMedico.Name = "txtAlertaExamenMedico";
            this.txtAlertaExamenMedico.PromptChar = ' ';
            this.txtAlertaExamenMedico.Size = new System.Drawing.Size(30, 22);
            this.txtAlertaExamenMedico.TabIndex = 9;
            // 
            // miLabel9
            // 
            this.miLabel9.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel9.BackColor = System.Drawing.Color.Transparent;
            this.miLabel9.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel9.Location = new System.Drawing.Point(191, 49);
            this.miLabel9.Name = "miLabel9";
            this.miLabel9.Size = new System.Drawing.Size(160, 15);
            this.miLabel9.TabIndex = 6;
            this.miLabel9.Text = "Entrevista de trabajo";
            this.miLabel9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtAlertaEntrevistaTrabajo
            // 
            this.txtAlertaEntrevistaTrabajo.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtAlertaEntrevistaTrabajo.BackColor = System.Drawing.Color.White;
            this.txtAlertaEntrevistaTrabajo.BeepOnError = true;
            this.txtAlertaEntrevistaTrabajo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAlertaEntrevistaTrabajo.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtAlertaEntrevistaTrabajo.ForeColor = System.Drawing.Color.Black;
            this.txtAlertaEntrevistaTrabajo.HidePromptOnLeave = true;
            this.txtAlertaEntrevistaTrabajo.Location = new System.Drawing.Point(351, 46);
            this.txtAlertaEntrevistaTrabajo.Mask = "999";
            this.txtAlertaEntrevistaTrabajo.Name = "txtAlertaEntrevistaTrabajo";
            this.txtAlertaEntrevistaTrabajo.PromptChar = ' ';
            this.txtAlertaEntrevistaTrabajo.Size = new System.Drawing.Size(30, 22);
            this.txtAlertaEntrevistaTrabajo.TabIndex = 7;
            // 
            // miLabel8
            // 
            this.miLabel8.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel8.BackColor = System.Drawing.Color.Transparent;
            this.miLabel8.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel8.Location = new System.Drawing.Point(191, 22);
            this.miLabel8.Name = "miLabel8";
            this.miLabel8.Size = new System.Drawing.Size(160, 15);
            this.miLabel8.TabIndex = 4;
            this.miLabel8.Text = "Curso de izaje";
            this.miLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtAlertaCursoIzaje
            // 
            this.txtAlertaCursoIzaje.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtAlertaCursoIzaje.BackColor = System.Drawing.Color.White;
            this.txtAlertaCursoIzaje.BeepOnError = true;
            this.txtAlertaCursoIzaje.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAlertaCursoIzaje.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtAlertaCursoIzaje.ForeColor = System.Drawing.Color.Black;
            this.txtAlertaCursoIzaje.HidePromptOnLeave = true;
            this.txtAlertaCursoIzaje.Location = new System.Drawing.Point(351, 19);
            this.txtAlertaCursoIzaje.Mask = "999";
            this.txtAlertaCursoIzaje.Name = "txtAlertaCursoIzaje";
            this.txtAlertaCursoIzaje.PromptChar = ' ';
            this.txtAlertaCursoIzaje.Size = new System.Drawing.Size(30, 22);
            this.txtAlertaCursoIzaje.TabIndex = 5;
            // 
            // txtAlertaCursoInduccion
            // 
            this.txtAlertaCursoInduccion.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtAlertaCursoInduccion.BackColor = System.Drawing.Color.White;
            this.txtAlertaCursoInduccion.BeepOnError = true;
            this.txtAlertaCursoInduccion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAlertaCursoInduccion.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtAlertaCursoInduccion.ForeColor = System.Drawing.Color.Black;
            this.txtAlertaCursoInduccion.HidePromptOnLeave = true;
            this.txtAlertaCursoInduccion.Location = new System.Drawing.Point(160, 46);
            this.txtAlertaCursoInduccion.Mask = "999";
            this.txtAlertaCursoInduccion.Name = "txtAlertaCursoInduccion";
            this.txtAlertaCursoInduccion.PromptChar = ' ';
            this.txtAlertaCursoInduccion.Size = new System.Drawing.Size(30, 22);
            this.txtAlertaCursoInduccion.TabIndex = 3;
            // 
            // txtAlertaCertificadoAntecedente
            // 
            this.txtAlertaCertificadoAntecedente.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtAlertaCertificadoAntecedente.BackColor = System.Drawing.Color.White;
            this.txtAlertaCertificadoAntecedente.BeepOnError = true;
            this.txtAlertaCertificadoAntecedente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAlertaCertificadoAntecedente.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtAlertaCertificadoAntecedente.ForeColor = System.Drawing.Color.Black;
            this.txtAlertaCertificadoAntecedente.HidePromptOnLeave = true;
            this.txtAlertaCertificadoAntecedente.Location = new System.Drawing.Point(160, 19);
            this.txtAlertaCertificadoAntecedente.Mask = "999";
            this.txtAlertaCertificadoAntecedente.Name = "txtAlertaCertificadoAntecedente";
            this.txtAlertaCertificadoAntecedente.PromptChar = ' ';
            this.txtAlertaCertificadoAntecedente.Size = new System.Drawing.Size(30, 22);
            this.txtAlertaCertificadoAntecedente.TabIndex = 1;
            // 
            // miLabel7
            // 
            this.miLabel7.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel7.BackColor = System.Drawing.Color.Transparent;
            this.miLabel7.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel7.Location = new System.Drawing.Point(0, 49);
            this.miLabel7.Name = "miLabel7";
            this.miLabel7.Size = new System.Drawing.Size(160, 15);
            this.miLabel7.TabIndex = 2;
            this.miLabel7.Text = "Curso de inducción";
            this.miLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // miLabel6
            // 
            this.miLabel6.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel6.BackColor = System.Drawing.Color.Transparent;
            this.miLabel6.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel6.Location = new System.Drawing.Point(0, 22);
            this.miLabel6.Name = "miLabel6";
            this.miLabel6.Size = new System.Drawing.Size(160, 15);
            this.miLabel6.TabIndex = 0;
            this.miLabel6.Text = "Certif. de antecedentes";
            this.miLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupLiquidacionSueldo
            // 
            this.groupLiquidacionSueldo.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.groupLiquidacionSueldo.Controls.Add(this.miLabel17);
            this.groupLiquidacionSueldo.Controls.Add(this.txtLiquidacionSueldoSCVO);
            this.groupLiquidacionSueldo.Controls.Add(this.miLabel16);
            this.groupLiquidacionSueldo.Controls.Add(this.txtLiquidacionSueldoTiempoParcial);
            this.groupLiquidacionSueldo.Controls.Add(this.miLabel15);
            this.groupLiquidacionSueldo.Controls.Add(this.txtLiquidacionSueldoTiempoCompleto);
            this.groupLiquidacionSueldo.Controls.Add(this.miLabel14);
            this.groupLiquidacionSueldo.Controls.Add(this.txtLiquidacionSueldoART_Tasa);
            this.groupLiquidacionSueldo.Controls.Add(this.txtLiquidacionSueldoART_Fijo);
            this.groupLiquidacionSueldo.Controls.Add(this.txtLiquidacionSueldoAporte);
            this.groupLiquidacionSueldo.Controls.Add(this.miLabel13);
            this.groupLiquidacionSueldo.Controls.Add(this.miLabel12);
            this.groupLiquidacionSueldo.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupLiquidacionSueldo.ForeColor = System.Drawing.Color.Gray;
            this.groupLiquidacionSueldo.Location = new System.Drawing.Point(160, 250);
            this.groupLiquidacionSueldo.Name = "groupLiquidacionSueldo";
            this.groupLiquidacionSueldo.Size = new System.Drawing.Size(578, 102);
            this.groupLiquidacionSueldo.TabIndex = 7;
            this.groupLiquidacionSueldo.TabStop = false;
            this.groupLiquidacionSueldo.Text = "Liquidación de sueldos: Establecer valores generales";
            // 
            // miLabel17
            // 
            this.miLabel17.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel17.BackColor = System.Drawing.Color.Transparent;
            this.miLabel17.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel17.Location = new System.Drawing.Point(267, 76);
            this.miLabel17.Name = "miLabel17";
            this.miLabel17.Size = new System.Drawing.Size(250, 15);
            this.miLabel17.TabIndex = 10;
            this.miLabel17.Text = "SCVO %";
            this.miLabel17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtLiquidacionSueldoSCVO
            // 
            this.txtLiquidacionSueldoSCVO.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtLiquidacionSueldoSCVO.BackColor = System.Drawing.Color.White;
            this.txtLiquidacionSueldoSCVO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLiquidacionSueldoSCVO.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtLiquidacionSueldoSCVO.ForeColor = System.Drawing.Color.Black;
            this.txtLiquidacionSueldoSCVO.Location = new System.Drawing.Point(517, 73);
            this.txtLiquidacionSueldoSCVO.MaxLength = 7;
            this.txtLiquidacionSueldoSCVO.Name = "txtLiquidacionSueldoSCVO";
            this.txtLiquidacionSueldoSCVO.Size = new System.Drawing.Size(55, 22);
            this.txtLiquidacionSueldoSCVO.TabIndex = 11;
            this.txtLiquidacionSueldoSCVO.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLiquidacionSueldoSCVO_KeyPress);
            // 
            // miLabel16
            // 
            this.miLabel16.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel16.BackColor = System.Drawing.Color.Transparent;
            this.miLabel16.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel16.Location = new System.Drawing.Point(267, 49);
            this.miLabel16.Name = "miLabel16";
            this.miLabel16.Size = new System.Drawing.Size(250, 15);
            this.miLabel16.TabIndex = 8;
            this.miLabel16.Text = "Contribución patronal - Tiempo parcial %";
            this.miLabel16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtLiquidacionSueldoTiempoParcial
            // 
            this.txtLiquidacionSueldoTiempoParcial.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtLiquidacionSueldoTiempoParcial.BackColor = System.Drawing.Color.White;
            this.txtLiquidacionSueldoTiempoParcial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLiquidacionSueldoTiempoParcial.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtLiquidacionSueldoTiempoParcial.ForeColor = System.Drawing.Color.Black;
            this.txtLiquidacionSueldoTiempoParcial.Location = new System.Drawing.Point(517, 46);
            this.txtLiquidacionSueldoTiempoParcial.MaxLength = 7;
            this.txtLiquidacionSueldoTiempoParcial.Name = "txtLiquidacionSueldoTiempoParcial";
            this.txtLiquidacionSueldoTiempoParcial.Size = new System.Drawing.Size(55, 22);
            this.txtLiquidacionSueldoTiempoParcial.TabIndex = 9;
            this.txtLiquidacionSueldoTiempoParcial.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLiquidacionSueldoTiempoParcial_KeyPress);
            // 
            // miLabel15
            // 
            this.miLabel15.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel15.BackColor = System.Drawing.Color.Transparent;
            this.miLabel15.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel15.Location = new System.Drawing.Point(267, 22);
            this.miLabel15.Name = "miLabel15";
            this.miLabel15.Size = new System.Drawing.Size(250, 15);
            this.miLabel15.TabIndex = 6;
            this.miLabel15.Text = "Contribución patronal - Tiempo completo %";
            this.miLabel15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtLiquidacionSueldoTiempoCompleto
            // 
            this.txtLiquidacionSueldoTiempoCompleto.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtLiquidacionSueldoTiempoCompleto.BackColor = System.Drawing.Color.White;
            this.txtLiquidacionSueldoTiempoCompleto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLiquidacionSueldoTiempoCompleto.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtLiquidacionSueldoTiempoCompleto.ForeColor = System.Drawing.Color.Black;
            this.txtLiquidacionSueldoTiempoCompleto.Location = new System.Drawing.Point(517, 19);
            this.txtLiquidacionSueldoTiempoCompleto.MaxLength = 7;
            this.txtLiquidacionSueldoTiempoCompleto.Name = "txtLiquidacionSueldoTiempoCompleto";
            this.txtLiquidacionSueldoTiempoCompleto.Size = new System.Drawing.Size(55, 22);
            this.txtLiquidacionSueldoTiempoCompleto.TabIndex = 7;
            this.txtLiquidacionSueldoTiempoCompleto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLiquidacionSueldoTiempoCompleto_KeyPress);
            // 
            // miLabel14
            // 
            this.miLabel14.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel14.BackColor = System.Drawing.Color.Transparent;
            this.miLabel14.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel14.Location = new System.Drawing.Point(0, 76);
            this.miLabel14.Name = "miLabel14";
            this.miLabel14.Size = new System.Drawing.Size(180, 15);
            this.miLabel14.TabIndex = 4;
            this.miLabel14.Text = "ART (tasa) %";
            this.miLabel14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtLiquidacionSueldoART_Tasa
            // 
            this.txtLiquidacionSueldoART_Tasa.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtLiquidacionSueldoART_Tasa.BackColor = System.Drawing.Color.White;
            this.txtLiquidacionSueldoART_Tasa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLiquidacionSueldoART_Tasa.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtLiquidacionSueldoART_Tasa.ForeColor = System.Drawing.Color.Black;
            this.txtLiquidacionSueldoART_Tasa.Location = new System.Drawing.Point(180, 73);
            this.txtLiquidacionSueldoART_Tasa.MaxLength = 7;
            this.txtLiquidacionSueldoART_Tasa.Name = "txtLiquidacionSueldoART_Tasa";
            this.txtLiquidacionSueldoART_Tasa.Size = new System.Drawing.Size(55, 22);
            this.txtLiquidacionSueldoART_Tasa.TabIndex = 5;
            this.txtLiquidacionSueldoART_Tasa.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLiquidacionSueldoART_Tasa_KeyPress);
            // 
            // txtLiquidacionSueldoART_Fijo
            // 
            this.txtLiquidacionSueldoART_Fijo.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtLiquidacionSueldoART_Fijo.BackColor = System.Drawing.Color.White;
            this.txtLiquidacionSueldoART_Fijo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLiquidacionSueldoART_Fijo.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtLiquidacionSueldoART_Fijo.ForeColor = System.Drawing.Color.Black;
            this.txtLiquidacionSueldoART_Fijo.Location = new System.Drawing.Point(180, 46);
            this.txtLiquidacionSueldoART_Fijo.MaxLength = 11;
            this.txtLiquidacionSueldoART_Fijo.Name = "txtLiquidacionSueldoART_Fijo";
            this.txtLiquidacionSueldoART_Fijo.Size = new System.Drawing.Size(85, 22);
            this.txtLiquidacionSueldoART_Fijo.TabIndex = 3;
            this.txtLiquidacionSueldoART_Fijo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLiquidacionSueldoART_Fijo_KeyPress);
            // 
            // txtLiquidacionSueldoAporte
            // 
            this.txtLiquidacionSueldoAporte.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtLiquidacionSueldoAporte.BackColor = System.Drawing.Color.White;
            this.txtLiquidacionSueldoAporte.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLiquidacionSueldoAporte.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtLiquidacionSueldoAporte.ForeColor = System.Drawing.Color.Black;
            this.txtLiquidacionSueldoAporte.Location = new System.Drawing.Point(180, 19);
            this.txtLiquidacionSueldoAporte.MaxLength = 7;
            this.txtLiquidacionSueldoAporte.Name = "txtLiquidacionSueldoAporte";
            this.txtLiquidacionSueldoAporte.Size = new System.Drawing.Size(55, 22);
            this.txtLiquidacionSueldoAporte.TabIndex = 1;
            this.txtLiquidacionSueldoAporte.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLiquidacionSueldoAporte_KeyPress);
            // 
            // miLabel13
            // 
            this.miLabel13.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel13.BackColor = System.Drawing.Color.Transparent;
            this.miLabel13.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel13.Location = new System.Drawing.Point(0, 49);
            this.miLabel13.Name = "miLabel13";
            this.miLabel13.Size = new System.Drawing.Size(180, 15);
            this.miLabel13.TabIndex = 2;
            this.miLabel13.Text = "ART (fijo) $";
            this.miLabel13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // miLabel12
            // 
            this.miLabel12.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel12.BackColor = System.Drawing.Color.Transparent;
            this.miLabel12.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel12.Location = new System.Drawing.Point(0, 22);
            this.miLabel12.Name = "miLabel12";
            this.miLabel12.Size = new System.Drawing.Size(180, 15);
            this.miLabel12.TabIndex = 0;
            this.miLabel12.Text = "Aportes (jub. + PAMI + OS) %";
            this.miLabel12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // grouptxtEstadoResultado
            // 
            this.grouptxtEstadoResultado.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.grouptxtEstadoResultado.Controls.Add(this.miLabel20);
            this.grouptxtEstadoResultado.Controls.Add(this.miLabel19);
            this.grouptxtEstadoResultado.Controls.Add(this.miLabel18);
            this.grouptxtEstadoResultado.Controls.Add(this.txtEstadoResultadoGanancia);
            this.grouptxtEstadoResultado.Controls.Add(this.txtEstadoResultadoSAC);
            this.grouptxtEstadoResultado.Controls.Add(this.txtEstadoResultadoIIBB);
            this.grouptxtEstadoResultado.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grouptxtEstadoResultado.ForeColor = System.Drawing.Color.Gray;
            this.grouptxtEstadoResultado.Location = new System.Drawing.Point(160, 357);
            this.grouptxtEstadoResultado.Name = "grouptxtEstadoResultado";
            this.grouptxtEstadoResultado.Size = new System.Drawing.Size(578, 48);
            this.grouptxtEstadoResultado.TabIndex = 8;
            this.grouptxtEstadoResultado.TabStop = false;
            this.grouptxtEstadoResultado.Text = "Reporte - Estado de Resultados: Establecer valores de previsiones";
            // 
            // miLabel20
            // 
            this.miLabel20.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel20.BackColor = System.Drawing.Color.Transparent;
            this.miLabel20.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel20.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel20.Location = new System.Drawing.Point(382, 22);
            this.miLabel20.Name = "miLabel20";
            this.miLabel20.Size = new System.Drawing.Size(135, 15);
            this.miLabel20.TabIndex = 4;
            this.miLabel20.Text = "Ganancias (tasa) %";
            this.miLabel20.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // miLabel19
            // 
            this.miLabel19.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel19.BackColor = System.Drawing.Color.Transparent;
            this.miLabel19.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel19.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel19.Location = new System.Drawing.Point(191, 22);
            this.miLabel19.Name = "miLabel19";
            this.miLabel19.Size = new System.Drawing.Size(135, 15);
            this.miLabel19.TabIndex = 2;
            this.miLabel19.Text = "SAC (tasa) %";
            this.miLabel19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // miLabel18
            // 
            this.miLabel18.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel18.BackColor = System.Drawing.Color.Transparent;
            this.miLabel18.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel18.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel18.Location = new System.Drawing.Point(0, 22);
            this.miLabel18.Name = "miLabel18";
            this.miLabel18.Size = new System.Drawing.Size(135, 15);
            this.miLabel18.TabIndex = 0;
            this.miLabel18.Text = "IIBB (tasa) %";
            this.miLabel18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtEstadoResultadoGanancia
            // 
            this.txtEstadoResultadoGanancia.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtEstadoResultadoGanancia.BackColor = System.Drawing.Color.White;
            this.txtEstadoResultadoGanancia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEstadoResultadoGanancia.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtEstadoResultadoGanancia.ForeColor = System.Drawing.Color.Black;
            this.txtEstadoResultadoGanancia.Location = new System.Drawing.Point(517, 19);
            this.txtEstadoResultadoGanancia.MaxLength = 7;
            this.txtEstadoResultadoGanancia.Name = "txtEstadoResultadoGanancia";
            this.txtEstadoResultadoGanancia.Size = new System.Drawing.Size(55, 22);
            this.txtEstadoResultadoGanancia.TabIndex = 5;
            this.txtEstadoResultadoGanancia.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEstadoResultadoGanancia_KeyPress);
            // 
            // txtEstadoResultadoSAC
            // 
            this.txtEstadoResultadoSAC.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtEstadoResultadoSAC.BackColor = System.Drawing.Color.White;
            this.txtEstadoResultadoSAC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEstadoResultadoSAC.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtEstadoResultadoSAC.ForeColor = System.Drawing.Color.Black;
            this.txtEstadoResultadoSAC.Location = new System.Drawing.Point(326, 19);
            this.txtEstadoResultadoSAC.MaxLength = 7;
            this.txtEstadoResultadoSAC.Name = "txtEstadoResultadoSAC";
            this.txtEstadoResultadoSAC.Size = new System.Drawing.Size(55, 22);
            this.txtEstadoResultadoSAC.TabIndex = 3;
            this.txtEstadoResultadoSAC.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEstadoResultadoSAC_KeyPress);
            // 
            // txtEstadoResultadoIIBB
            // 
            this.txtEstadoResultadoIIBB.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtEstadoResultadoIIBB.BackColor = System.Drawing.Color.White;
            this.txtEstadoResultadoIIBB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEstadoResultadoIIBB.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtEstadoResultadoIIBB.ForeColor = System.Drawing.Color.Black;
            this.txtEstadoResultadoIIBB.Location = new System.Drawing.Point(135, 19);
            this.txtEstadoResultadoIIBB.MaxLength = 7;
            this.txtEstadoResultadoIIBB.Name = "txtEstadoResultadoIIBB";
            this.txtEstadoResultadoIIBB.Size = new System.Drawing.Size(55, 22);
            this.txtEstadoResultadoIIBB.TabIndex = 1;
            this.txtEstadoResultadoIIBB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEstadoResultado_KeyPress);
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
            this.btnCancelar.Location = new System.Drawing.Point(83, 657);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 10;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
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
            this.btnGuardar.Location = new System.Drawing.Point(6, 657);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 9;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // labelPublicacion
            // 
            this.labelPublicacion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelPublicacion.BackColor = System.Drawing.Color.Transparent;
            this.labelPublicacion.Font = new System.Drawing.Font("Arial", 7.5F);
            this.labelPublicacion.ForeColor = System.Drawing.Color.DimGray;
            this.labelPublicacion.Location = new System.Drawing.Point(3, 634);
            this.labelPublicacion.Name = "labelPublicacion";
            this.labelPublicacion.Size = new System.Drawing.Size(519, 14);
            this.labelPublicacion.TabIndex = 2;
            this.labelPublicacion.Text = "S/D";
            this.labelPublicacion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // miLabel21
            // 
            this.miLabel21.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel21.BackColor = System.Drawing.Color.Transparent;
            this.miLabel21.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel21.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel21.Location = new System.Drawing.Point(0, 63);
            this.miLabel21.Name = "miLabel21";
            this.miLabel21.Size = new System.Drawing.Size(160, 15);
            this.miLabel21.TabIndex = 3;
            this.miLabel21.Text = "Punto de Venta";
            this.miLabel21.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtTPV
            // 
            this.txtTPV.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtTPV.BackColor = System.Drawing.Color.White;
            this.txtTPV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTPV.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtTPV.ForeColor = System.Drawing.Color.Black;
            this.txtTPV.Location = new System.Drawing.Point(160, 61);
            this.txtTPV.MaxLength = 5;
            this.txtTPV.Name = "txtTPV";
            this.txtTPV.Size = new System.Drawing.Size(39, 22);
            this.txtTPV.TabIndex = 4;
            this.txtTPV.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTPV_KeyPress);
            this.txtTPV.Validated += new System.EventHandler(this.txtTPV_Validated);
            // 
            // btnPDF_Registro
            // 
            this.btnPDF_Registro.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPDF_Registro.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnPDF_Registro.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPDF_Registro.BackgroundImage")));
            this.btnPDF_Registro.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnPDF_Registro.FlatAppearance.BorderSize = 0;
            this.btnPDF_Registro.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnPDF_Registro.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnPDF_Registro.Font = new System.Drawing.Font("Arial", 9F);
            this.btnPDF_Registro.ForeColor = System.Drawing.Color.Black;
            this.btnPDF_Registro.Location = new System.Drawing.Point(196, 657);
            this.btnPDF_Registro.Name = "btnPDF_Registro";
            this.btnPDF_Registro.Size = new System.Drawing.Size(30, 23);
            this.btnPDF_Registro.TabIndex = 12;
            this.btnPDF_Registro.UseVisualStyleBackColor = false;
            this.btnPDF_Registro.Click += new System.EventHandler(this.btnPDF_Registro_Click);
            // 
            // btnExcel_Registro
            // 
            this.btnExcel_Registro.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExcel_Registro.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnExcel_Registro.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExcel_Registro.BackgroundImage")));
            this.btnExcel_Registro.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnExcel_Registro.FlatAppearance.BorderSize = 0;
            this.btnExcel_Registro.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnExcel_Registro.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnExcel_Registro.Font = new System.Drawing.Font("Arial", 9F);
            this.btnExcel_Registro.ForeColor = System.Drawing.Color.Black;
            this.btnExcel_Registro.Location = new System.Drawing.Point(164, 657);
            this.btnExcel_Registro.Name = "btnExcel_Registro";
            this.btnExcel_Registro.Size = new System.Drawing.Size(30, 23);
            this.btnExcel_Registro.TabIndex = 11;
            this.btnExcel_Registro.UseVisualStyleBackColor = false;
            this.btnExcel_Registro.Click += new System.EventHandler(this.btnExcel_Registro_Click);
            // 
            // miLabel22
            // 
            this.miLabel22.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel22.BackColor = System.Drawing.Color.Transparent;
            this.miLabel22.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel22.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel22.Location = new System.Drawing.Point(0, 412);
            this.miLabel22.Name = "miLabel22";
            this.miLabel22.Size = new System.Drawing.Size(160, 15);
            this.miLabel22.TabIndex = 10;
            this.miLabel22.Text = "Tiempo de anulación";
            this.miLabel22.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtTiempoAnulacion
            // 
            this.txtTiempoAnulacion.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtTiempoAnulacion.BackColor = System.Drawing.Color.White;
            this.txtTiempoAnulacion.BeepOnError = true;
            this.txtTiempoAnulacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTiempoAnulacion.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtTiempoAnulacion.ForeColor = System.Drawing.Color.Black;
            this.txtTiempoAnulacion.HidePromptOnLeave = true;
            this.txtTiempoAnulacion.Location = new System.Drawing.Point(160, 409);
            this.txtTiempoAnulacion.Mask = "999";
            this.txtTiempoAnulacion.Name = "txtTiempoAnulacion";
            this.txtTiempoAnulacion.PromptChar = ' ';
            this.txtTiempoAnulacion.Size = new System.Drawing.Size(30, 22);
            this.txtTiempoAnulacion.TabIndex = 11;
            // 
            // miLabel23
            // 
            this.miLabel23.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel23.BackColor = System.Drawing.Color.Transparent;
            this.miLabel23.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel23.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel23.Location = new System.Drawing.Point(0, 439);
            this.miLabel23.Name = "miLabel23";
            this.miLabel23.Size = new System.Drawing.Size(160, 15);
            this.miLabel23.TabIndex = 14;
            this.miLabel23.Text = "Tiempo de modificación";
            this.miLabel23.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtTiempoModificacion
            // 
            this.txtTiempoModificacion.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtTiempoModificacion.BackColor = System.Drawing.Color.White;
            this.txtTiempoModificacion.BeepOnError = true;
            this.txtTiempoModificacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTiempoModificacion.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtTiempoModificacion.ForeColor = System.Drawing.Color.Black;
            this.txtTiempoModificacion.HidePromptOnLeave = true;
            this.txtTiempoModificacion.Location = new System.Drawing.Point(160, 436);
            this.txtTiempoModificacion.Mask = "999";
            this.txtTiempoModificacion.Name = "txtTiempoModificacion";
            this.txtTiempoModificacion.PromptChar = ' ';
            this.txtTiempoModificacion.Size = new System.Drawing.Size(30, 22);
            this.txtTiempoModificacion.TabIndex = 15;
            // 
            // FormOpcionGeneral
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1006, 687);
            this.Controls.Add(this.miLabel23);
            this.Controls.Add(this.txtTiempoModificacion);
            this.Controls.Add(this.miLabel22);
            this.Controls.Add(this.btnPDF_Registro);
            this.Controls.Add(this.txtTiempoAnulacion);
            this.Controls.Add(this.btnExcel_Registro);
            this.Controls.Add(this.labelPublicacion);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.txtTPV);
            this.Controls.Add(this.miLabel21);
            this.Controls.Add(this.groupVigencia);
            this.Controls.Add(this.groupLiquidacionSueldo);
            this.Controls.Add(this.groupAlerta);
            this.Controls.Add(this.grouptxtEstadoResultado);
            this.Name = "FormOpcionGeneral";
            this.Text = "Opciones Generales";
            this.Load += new System.EventHandler(this.FormOpcionGeneral_Load);
            this.Controls.SetChildIndex(this.grouptxtEstadoResultado, 0);
            this.Controls.SetChildIndex(this.groupAlerta, 0);
            this.Controls.SetChildIndex(this.groupLiquidacionSueldo, 0);
            this.Controls.SetChildIndex(this.groupVigencia, 0);
            this.Controls.SetChildIndex(this.miLabel21, 0);
            this.Controls.SetChildIndex(this.txtTPV, 0);
            this.Controls.SetChildIndex(this.btnGuardar, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.labelPublicacion, 0);
            this.Controls.SetChildIndex(this.labelTitulo, 0);
            this.Controls.SetChildIndex(this.btnCerrar, 0);
            this.Controls.SetChildIndex(this.labelUsuario, 0);
            this.Controls.SetChildIndex(this.btnExcel_Registro, 0);
            this.Controls.SetChildIndex(this.txtTiempoAnulacion, 0);
            this.Controls.SetChildIndex(this.btnPDF_Registro, 0);
            this.Controls.SetChildIndex(this.miLabel22, 0);
            this.Controls.SetChildIndex(this.txtTiempoModificacion, 0);
            this.Controls.SetChildIndex(this.miLabel23, 0);
            this.groupVigencia.ResumeLayout(false);
            this.groupVigencia.PerformLayout();
            this.groupAlerta.ResumeLayout(false);
            this.groupAlerta.PerformLayout();
            this.groupLiquidacionSueldo.ResumeLayout(false);
            this.groupLiquidacionSueldo.PerformLayout();
            this.grouptxtEstadoResultado.ResumeLayout(false);
            this.grouptxtEstadoResultado.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.GroupBox groupVigencia;
        private MiLabel miLabel5;
        private MiMaskedTextBox txtVigenciaExamenMedico;
        private MiLabel miLabel4;
        private MiMaskedTextBox txtVigenciaCursoIzaje;
        private MiLabel miLabel3;
        private MiMaskedTextBox txtVigenciaCursoInduccion;
        private MiMaskedTextBox txtVigenciaCurriculumVitae;
        private MiMaskedTextBox txtVigenciaCertificadoAntecedente;
        private MiLabel miLabel2;
        private MiLabel miLabel1;
        public System.Windows.Forms.GroupBox groupAlerta;
        private MiLabel miLabel11;
        private MiMaskedTextBox txtAlertaLicenciaConducir;
        private MiLabel miLabel10;
        private MiMaskedTextBox txtAlertaExamenMedico;
        private MiLabel miLabel9;
        private MiMaskedTextBox txtAlertaEntrevistaTrabajo;
        private MiLabel miLabel8;
        private MiMaskedTextBox txtAlertaCursoIzaje;
        private MiMaskedTextBox txtAlertaCursoInduccion;
        private MiMaskedTextBox txtAlertaCertificadoAntecedente;
        private MiLabel miLabel7;
        private MiLabel miLabel6;
        public System.Windows.Forms.GroupBox groupLiquidacionSueldo;
        private MiLabel miLabel17;
        private MiTextBox txtLiquidacionSueldoSCVO;
        private MiLabel miLabel16;
        private MiTextBox txtLiquidacionSueldoTiempoParcial;
        private MiLabel miLabel15;
        private MiTextBox txtLiquidacionSueldoTiempoCompleto;
        private MiLabel miLabel14;
        private MiTextBox txtLiquidacionSueldoART_Tasa;
        private MiTextBox txtLiquidacionSueldoART_Fijo;
        private MiTextBox txtLiquidacionSueldoAporte;
        private MiLabel miLabel13;
        private MiLabel miLabel12;
        public System.Windows.Forms.GroupBox grouptxtEstadoResultado;
        private MiLabel miLabel20;
        private MiLabel miLabel19;
        private MiLabel miLabel18;
        private MiTextBox txtEstadoResultadoGanancia;
        private MiTextBox txtEstadoResultadoSAC;
        private MiTextBox txtEstadoResultadoIIBB;
        public MiButtonBase btnCancelar;
        public MiButtonBase btnGuardar;
        public MiLabel labelPublicacion;
        private MiLabel miLabel21;
        private MiTextBox txtTPV;
        public MiButtonPDF btnPDF_Registro;
        public MiButtonExcel btnExcel_Registro;
        private MiLabel miLabel22;
        private MiMaskedTextBox txtTiempoAnulacion;
        private MiLabel miLabel23;
        private MiMaskedTextBox txtTiempoModificacion;
    }
}
