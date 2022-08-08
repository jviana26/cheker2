using Dominio;
using System.Management;
using System.Runtime.InteropServices;


namespace Presentacion
{
    public partial class Login : Form
    {
        public Login()
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

        private void Login_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }


        private void Login_Load(object sender, EventArgs e)
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



        private void ingresar_Click(object sender, EventArgs e)
        {
            if (Device.SelectedIndex == -1)
            {
                msgError("Escoje una unidad");
            }
            else
            {
                datos user = new datos();
                var validLogin = user.Login(Device.Text);
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

        }
        private void msgError(string msg)
        {
            lblmensajerror.Text = "        " + msg;
            lblmensajerror.Visible = true;
        }

        private void Device_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void registro_Click(object sender, EventArgs e)
        {
            Registro register = new Registro();
            register.Show();
            this.Hide();
        }
    }
}
