namespace Presentacion
{
    partial class amazon
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(amazon));
            this.btniniciar = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.btnpausa = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.lbldead = new System.Windows.Forms.Label();
            this.lblive = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lives = new System.Windows.Forms.ListBox();
            this.deads = new System.Windows.Forms.ListBox();
            this.btnlimpiar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lblstatus = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lblContador = new System.Windows.Forms.Label();
            this.btncargar = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tContador = new System.Windows.Forms.Timer(this.components);
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.timer4 = new System.Windows.Forms.Timer(this.components);
            this.timer5 = new System.Windows.Forms.Timer(this.components);
            this.timer6 = new System.Windows.Forms.Timer(this.components);
            this.timer7 = new System.Windows.Forms.Timer(this.components);
            this.timer8 = new System.Windows.Forms.Timer(this.components);
            this.vtnlogin = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.password = new System.Windows.Forms.TextBox();
            this.email = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblerror = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.vtnlogin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btniniciar
            // 
            this.btniniciar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            this.btniniciar.FlatAppearance.BorderSize = 0;
            this.btniniciar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btniniciar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btniniciar.ForeColor = System.Drawing.Color.White;
            this.btniniciar.Location = new System.Drawing.Point(953, 19);
            this.btniniciar.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btniniciar.Name = "btniniciar";
            this.btniniciar.Size = new System.Drawing.Size(97, 41);
            this.btniniciar.TabIndex = 37;
            this.btniniciar.Text = "Cerrar";
            this.btniniciar.UseVisualStyleBackColor = false;
            this.btniniciar.Click += new System.EventHandler(this.btniniciar_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.Color.DimGray;
            this.label4.Location = new System.Drawing.Point(648, 112);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 25);
            this.label4.TabIndex = 54;
            this.label4.Text = "CCS";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // btnpausa
            // 
            this.btnpausa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            this.btnpausa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnpausa.FlatAppearance.BorderSize = 0;
            this.btnpausa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnpausa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnpausa.ForeColor = System.Drawing.Color.White;
            this.btnpausa.Location = new System.Drawing.Point(368, 552);
            this.btnpausa.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnpausa.Name = "btnpausa";
            this.btnpausa.Size = new System.Drawing.Size(130, 56);
            this.btnpausa.TabIndex = 53;
            this.btnpausa.Text = "PAUSA";
            this.btnpausa.UseVisualStyleBackColor = false;
            this.btnpausa.Click += new System.EventHandler(this.btnpausa_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(230, 553);
            this.button1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(130, 56);
            this.button1.TabIndex = 52;
            this.button1.Text = "INICIAR";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lbldead
            // 
            this.lbldead.AutoSize = true;
            this.lbldead.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbldead.ForeColor = System.Drawing.Color.DimGray;
            this.lbldead.Location = new System.Drawing.Point(160, 336);
            this.lbldead.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lbldead.Name = "lbldead";
            this.lbldead.Size = new System.Drawing.Size(48, 25);
            this.lbldead.TabIndex = 50;
            this.lbldead.Text = "000";
            this.lbldead.Visible = false;
            // 
            // lblive
            // 
            this.lblive.AutoSize = true;
            this.lblive.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblive.ForeColor = System.Drawing.Color.DimGray;
            this.lblive.Location = new System.Drawing.Point(160, 138);
            this.lblive.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblive.Name = "lblive";
            this.lblive.Size = new System.Drawing.Size(48, 25);
            this.lblive.TabIndex = 51;
            this.lblive.Text = "000";
            this.lblive.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.Location = new System.Drawing.Point(89, 336);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 25);
            this.label2.TabIndex = 49;
            this.label2.Text = "DEAD";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(89, 136);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 25);
            this.label1.TabIndex = 48;
            this.label1.Text = "LIVE";
            // 
            // lives
            // 
            this.lives.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            this.lives.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lives.ForeColor = System.Drawing.Color.Green;
            this.lives.FormattingEnabled = true;
            this.lives.ItemHeight = 20;
            this.lives.Location = new System.Drawing.Point(95, 171);
            this.lives.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.lives.Name = "lives";
            this.lives.Size = new System.Drawing.Size(538, 160);
            this.lives.TabIndex = 46;
            this.lives.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lives_KeyDown);
            // 
            // deads
            // 
            this.deads.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            this.deads.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.deads.ForeColor = System.Drawing.Color.Red;
            this.deads.FormattingEnabled = true;
            this.deads.ItemHeight = 20;
            this.deads.Location = new System.Drawing.Point(90, 371);
            this.deads.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.deads.Name = "deads";
            this.deads.Size = new System.Drawing.Size(538, 160);
            this.deads.TabIndex = 47;
            // 
            // btnlimpiar
            // 
            this.btnlimpiar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            this.btnlimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnlimpiar.FlatAppearance.BorderSize = 0;
            this.btnlimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnlimpiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnlimpiar.ForeColor = System.Drawing.Color.White;
            this.btnlimpiar.Location = new System.Drawing.Point(506, 551);
            this.btnlimpiar.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnlimpiar.Name = "btnlimpiar";
            this.btnlimpiar.Size = new System.Drawing.Size(130, 56);
            this.btnlimpiar.TabIndex = 45;
            this.btnlimpiar.Text = "LIMPIAR";
            this.btnlimpiar.UseVisualStyleBackColor = false;
            this.btnlimpiar.Click += new System.EventHandler(this.btnlimpiar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.DimGray;
            this.label3.Location = new System.Drawing.Point(649, 617);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 25);
            this.label3.TabIndex = 44;
            this.label3.Text = "Status:";
            // 
            // lblstatus
            // 
            this.lblstatus.AutoSize = true;
            this.lblstatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblstatus.ForeColor = System.Drawing.Color.DimGray;
            this.lblstatus.Location = new System.Drawing.Point(740, 621);
            this.lblstatus.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblstatus.Name = "lblstatus";
            this.lblstatus.Size = new System.Drawing.Size(72, 25);
            this.lblstatus.TabIndex = 43;
            this.lblstatus.Text = "Activo";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.ColumnHeadersVisible = false;
            this.dataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.dataGridView1.Location = new System.Drawing.Point(654, 147);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Size = new System.Drawing.Size(274, 467);
            this.dataGridView1.TabIndex = 42;
            // 
            // lblContador
            // 
            this.lblContador.AutoSize = true;
            this.lblContador.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblContador.ForeColor = System.Drawing.Color.DimGray;
            this.lblContador.Location = new System.Drawing.Point(885, 112);
            this.lblContador.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblContador.Name = "lblContador";
            this.lblContador.Size = new System.Drawing.Size(48, 25);
            this.lblContador.TabIndex = 41;
            this.lblContador.Text = "000";
            this.lblContador.Visible = false;
            // 
            // btncargar
            // 
            this.btncargar.AutoSize = true;
            this.btncargar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            this.btncargar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btncargar.FlatAppearance.BorderSize = 0;
            this.btncargar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btncargar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btncargar.ForeColor = System.Drawing.Color.White;
            this.btncargar.Location = new System.Drawing.Point(90, 552);
            this.btncargar.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btncargar.Name = "btncargar";
            this.btncargar.Size = new System.Drawing.Size(130, 56);
            this.btncargar.TabIndex = 40;
            this.btncargar.Text = "CARGAR";
            this.btncargar.UseVisualStyleBackColor = false;
            this.btncargar.Click += new System.EventHandler(this.btncargar_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label6.ForeColor = System.Drawing.Color.DimGray;
            this.label6.Image = ((System.Drawing.Image)(resources.GetObject("label6.Image")));
            this.label6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label6.Location = new System.Drawing.Point(16, 19);
            this.label6.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(206, 25);
            this.label6.TabIndex = 56;
            this.label6.Text = "           Ucrania 2022";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // tContador
            // 
            this.tContador.Tick += new System.EventHandler(this.tContador_Tick);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // vtnlogin
            // 
            this.vtnlogin.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.vtnlogin.Controls.Add(this.button3);
            this.vtnlogin.Controls.Add(this.password);
            this.vtnlogin.Controls.Add(this.email);
            this.vtnlogin.Controls.Add(this.label8);
            this.vtnlogin.Controls.Add(this.label7);
            this.vtnlogin.Controls.Add(this.label5);
            this.vtnlogin.Location = new System.Drawing.Point(401, 112);
            this.vtnlogin.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.vtnlogin.Name = "vtnlogin";
            this.vtnlogin.Size = new System.Drawing.Size(262, 377);
            this.vtnlogin.TabIndex = 57;
            this.vtnlogin.Visible = false;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button3.Location = new System.Drawing.Point(33, 303);
            this.button3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button3.Name = "button3";
            this.button3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.button3.Size = new System.Drawing.Size(192, 41);
            this.button3.TabIndex = 64;
            this.button3.Text = "LOGIN";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // password
            // 
            this.password.BackColor = System.Drawing.Color.Black;
            this.password.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.password.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.password.ForeColor = System.Drawing.Color.Silver;
            this.password.Location = new System.Drawing.Point(33, 227);
            this.password.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(194, 29);
            this.password.TabIndex = 63;
            // 
            // email
            // 
            this.email.BackColor = System.Drawing.Color.Black;
            this.email.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.email.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.email.ForeColor = System.Drawing.Color.Silver;
            this.email.Location = new System.Drawing.Point(33, 125);
            this.email.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.email.Name = "email";
            this.email.Size = new System.Drawing.Size(194, 29);
            this.email.TabIndex = 62;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label8.ForeColor = System.Drawing.Color.Silver;
            this.label8.Location = new System.Drawing.Point(33, 197);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(103, 19);
            this.label8.TabIndex = 60;
            this.label8.Text = "Contraseña";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label7.ForeColor = System.Drawing.Color.Silver;
            this.label7.Location = new System.Drawing.Point(33, 100);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 19);
            this.label7.TabIndex = 59;
            this.label7.Text = "Correo";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.ForeColor = System.Drawing.Color.Silver;
            this.label5.Location = new System.Drawing.Point(21, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(216, 19);
            this.label5.TabIndex = 58;
            this.label5.Text = "LOGIN AMAZON ESPAÑA";
            // 
            // lblerror
            // 
            this.lblerror.AutoSize = true;
            this.lblerror.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblerror.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblerror.ForeColor = System.Drawing.Color.Red;
            this.lblerror.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblerror.Location = new System.Drawing.Point(314, 39);
            this.lblerror.Name = "lblerror";
            this.lblerror.Size = new System.Drawing.Size(533, 30);
            this.lblerror.TabIndex = 65;
            this.lblerror.Text = "RELLENA EL FORMULARIO PARA USAR EL GATE";
            this.lblerror.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(936, 577);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(120, 92);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 66;
            this.pictureBox1.TabStop = false;
            // 
            // amazon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.ClientSize = new System.Drawing.Size(1066, 681);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblerror);
            this.Controls.Add(this.vtnlogin);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnpausa);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lbldead);
            this.Controls.Add(this.lblive);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lives);
            this.Controls.Add(this.deads);
            this.Controls.Add(this.btnlimpiar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblstatus);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.lblContador);
            this.Controls.Add(this.btncargar);
            this.Controls.Add(this.btniniciar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "amazon";
            this.Text = "amazon";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.vtnlogin.ResumeLayout(false);
            this.vtnlogin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btniniciar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnpausa;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lbldead;
        private System.Windows.Forms.Label lblive;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lives;
        private System.Windows.Forms.ListBox deads;
        private System.Windows.Forms.Button btnlimpiar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblstatus;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lblContador;
        private System.Windows.Forms.Button btncargar;
        private System.Windows.Forms.Label label6;
        private OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Timer tContador;
        private NotifyIcon notifyIcon1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Timer timer3;
        private System.Windows.Forms.Timer timer4;
        private System.Windows.Forms.Timer timer5;
        private System.Windows.Forms.Timer timer6;
        private System.Windows.Forms.Timer timer7;
        private System.Windows.Forms.Timer timer8;
        private Panel vtnlogin;
        private Label label8;
        private Label label7;
        private Label label5;
        private TextBox password;
        private TextBox email;
        private Button button3;
        private Label lblerror;
        private PictureBox pictureBox1;
    }
}