using Dominio;
using System.Management;
using System.Runtime.InteropServices;

namespace Presentacion
{
    public partial class Registro : Form
    {
        public Registro()
        {
            InitializeComponent();
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);
        private void salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (user.Text != "USER")
            {
                if (licencia.Text != "LICENCIA")
                {
                    if (Device.SelectedIndex != -1)
                    {
                        datos usr = new datos();
                        var validLogin = usr.Register(user.Text, licencia.Text, Device.Text);
                        if (validLogin == true)
                        {
                            FormPrincipal mainMenu = new FormPrincipal();
                            mainMenu.Show();
                            this.Hide();
                        }
                        else
                        {
                            msgError("Incorrecto!");
                        }
                    }
                    else
                    {
                        msgError("Selecciona una unidad");
                    }
                }
                else
                {
                    msgError("Ingresa una licencia");
                }
            }
            else
            {
                msgError("Ingresa un usuario");
            }
        }

        private void user_Enter(object sender, EventArgs e)
        {
            if (user.Text == "USER")
            {
                user.Text = "";
            }
        }

        private void user_Leave(object sender, EventArgs e)
        {
            if (user.Text == "")
            {
                user.Text = "USER";
            }
        }

        private void licencia_Enter(object sender, EventArgs e)
        {
            if (licencia.Text == "LICENCIA")
            {
                licencia.Text = "";
            }
        }

        private void licencia_Leave(object sender, EventArgs e)
        {
            if (licencia.Text == "")
            {
                licencia.Text = "LICENCIA";
            }
        }

        private void Registro_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void msgError(string msg)
        {
            lblmensajerror.Text = msg;
            lblmensajerror.Visible = true;
        }

        private void Registro_Load(object sender, EventArgs e)
        {
            try
            {
                ManagementObjectSearcher searcher =
                    new ManagementObjectSearcher("root\\CIMV2",
                    "SELECT * FROM Win32_DiskDrive");

                foreach (ManagementObject queryObj in searcher.Get())
                {
                    Device.Items.Add(queryObj["SerialNumber"]);
                }
            }
            catch (ManagementException se)
            {
                Device.Items.Add("ERROR");
            }
        }
    }
}
