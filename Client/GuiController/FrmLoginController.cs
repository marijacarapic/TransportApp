using Client.ServerCommunication;
using Common.Domen;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.GuiController
{
    public class FrmLoginController
    {
        public FrmLogin FrmLogin { get; set; }

        public FrmLogin CreateLoginForm()
        {
            FrmLogin = new FrmLogin();
            FrmLogin.StartPosition = FormStartPosition.CenterScreen;
            FrmLogin.btnLogin.Click += btnLogin_Click;
            return FrmLogin;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if(!Validacija())
            {
                MessageBox.Show("Popunite polja kako bi se uspešno ulogovali!");
                return;
            }
            
            try
            {
                AdministratorTransporta administrator = new AdministratorTransporta
                {
                    Username = FrmLogin.txtUsername.Text,
                    Password = FrmLogin.txtPassword.Text
                 
                };
                administrator = Communication.Instance.Login(administrator);

                if (administrator != null)
                {
                   
                    MessageBox.Show("Uspešna prijava!");
                    Coordinator.Instance.OpenMainForm();
                    FrmLogin.Dispose();
                }
                else
                {
                    MessageBox.Show("Ne postoji administrator sa unetim kredencijalima!", "Transport", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool Validacija()
        {
            bool validacija = true;

            if(string.IsNullOrEmpty(FrmLogin.txtUsername.Text))
            {
                validacija = false;
                FrmLogin.txtUsername.BackColor = Color.Salmon;

            } else
            {
                FrmLogin.txtUsername.BackColor = Color.White;

            }
            if (string.IsNullOrEmpty(FrmLogin.txtPassword.Text))
            {
                validacija = false;
                FrmLogin.txtPassword.BackColor = Color.Salmon;

            }
            else
            {
                FrmLogin.txtPassword.BackColor = Color.White;

            }
            return validacija;
        }
    }
}
