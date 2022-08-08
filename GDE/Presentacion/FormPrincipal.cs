using Dominio;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Presentacion
{
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            LoaduserData();
            timer1.Start();
            timer3.Start();
        }


        #region Funcionalidades del formulario
        //RESIZE METODO PARA REDIMENCIONAR/CAMBIAR TAMAÑO A FORMULARIO EN TIEMPO DE EJECUCION ----------------------------------------------------------
        private int tolerance = 12;
        private const int WM_NCHITTEST = 132;
        private const int HTBOTTOMRIGHT = 17;
        private Rectangle sizeGripRectangle;


        //----------------COLOR Y GRIP DE RECTANGULO INFERIOR
        protected override void OnPaint(PaintEventArgs e)
        {
            SolidBrush blueBrush = new SolidBrush(Color.FromArgb(244, 244, 244));
            e.Graphics.FillRectangle(blueBrush, sizeGripRectangle);

            base.OnPaint(e);
            ControlPaint.DrawSizeGrip(e.Graphics, Color.Transparent, sizeGripRectangle);
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        //METODO PARA ARRASTRAR EL FORMULARIO---------------------------------------------------------------------
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();




        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void panelformularios_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelMenu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelBarraTitulo_Paint(object sender, PaintEventArgs e)
        {

        }
        #endregion
        //METODO PARA ABRIR FORMULARIOS DENTRO DEL PANEL
        private void AbrirFormulario<MiForm>() where MiForm : Form, new()
        {
            Form formulario;
            formulario = panelformularios.Controls.OfType<MiForm>().FirstOrDefault();//Busca en la colecion el formulario
            //si el formulario/instancia no existe
            if (formulario == null)
            {
                formulario = new MiForm();
                formulario.TopLevel = false;
                formulario.FormBorderStyle = FormBorderStyle.None;
                formulario.Dock = DockStyle.Fill;
                panelformularios.Controls.Add(formulario);
                panelformularios.Tag = formulario;
                formulario.Show();
                formulario.BringToFront();
                formulario.FormClosed += new FormClosedEventHandler(CloseForms);
            }
            //si el formulario/instancia existe
            else
            {
                formulario.BringToFront();
            }
        }
        private void CloseForms(object sender, FormClosedEventArgs e)
        {


            if (Application.OpenForms["Charge"] == null)
                button3.BackColor = Color.FromArgb(15, 15, 15);
            if (Application.OpenForms["nocharge"] == null)
                button1.BackColor = Color.FromArgb(15, 15, 15);

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panelformularios_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AbrirFormulario<charge>();
            button3.BackColor = Color.DimGray;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AbrirFormulario<nocharge>();
            button1.BackColor = Color.DimGray;
        }

        private void creditos_Click(object sender, EventArgs e)
        {

        }

        private void LoaduserData()
        {
            creditos.Text = cache.creditos;
            username.Text = cache.user;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (creditos.Text != cache.creditos)
            {
                creditos.Text = cache.creditos;
            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            string[] blacklist = { "Wireshark",
            "Proxifier",
            "widecap",
            "pcapui",
            "FreeCAD",
            "KKCap",
            "cheatengine-x86_64-SSE4-AVX2",
            "OMATIC",
            "psiphon-115",
            "jgrasp32",
            "jgrasp64",
            "Netbeans32",
            "Netbeans64",
            "idea32",
            "Crack",
            "Magick",
            "MagickChecker",
            "MagickInstall",
            "idea64",
            "idea64",
            "jgrasp",
            "Squalr",
            "dnSpy",
            "Advanced_IP_Scanner_2.5.3850",
            "GlassWire",
            "WeModAuxiliaryService",
            "WeMod",
            "BlueJ",
            "Fiddler Everywhere",
            "Fiddler_Everywhere",
            "Fiddler",
            "portswigger",
            "charles",
            "Nmap",
            "Tcpdump",
            "Procmon64",
            "Procmon",
            "JMeter",
            "Firebug",
            "Git",
            "EtherApe",
            "Kismet",
            "OllyDbg64",
            "OllyDbg",
            "Metasploit",
            "Nessus",
            "angryip",
            "KeePass",
            "HTTP Debugger Pro",
            "HTTP Debugger",
            "HTTPDebuggerSvc",
            "HTTPDebuggerUI",
            "Nagios",
            "HTTP Custom",
            "HTTPCustom",
            "httpcustom",
            "pandorafms"
            };
            foreach (Process proceso in Process.GetProcesses())
            {
                foreach (string p in blacklist)
                {
                    if (proceso.ProcessName == p)
                    {
                        Process[] ins = Process.GetProcessesByName(p);
                        foreach (Process pro in ins)
                        {
                            Application.Exit();
                        }
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AbrirFormulario<peru>();
            button2.BackColor = Color.DimGray;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AbrirFormulario<amazon>();
            button4.BackColor = Color.DimGray;
        }
    }
}
