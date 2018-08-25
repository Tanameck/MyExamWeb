using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace prjMyExamWeb1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        public static clsSQL poSQL = new clsSQL();
        clsUser toUser = new clsUser(poSQL);
        string tsError;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegisterNewUser_Click(object sender, EventArgs e)
        {
            try
            {
                /*
                if (!toUser.pfnRegisterNormalUser(out tsError,
                                                    Int32.Parse(txtRegisterCedula.Text),
                                                    txtRegisterName.Text,
                                                    txtRegisterLastName.Text,
                                                    txtRegisterEmail.Text,
                                                    txtRegisterUsername.Text,
                                                    txtRegisterPassword.Text))

                {
                    Console.WriteLine(tsError);
                }
                */
            }
            catch (Exception Err)
            {
                //Retorna el error  
                if (Err.Source != null)
                {
                    tsError = "Exception source: " + Err.Message;
                    Console.WriteLine(tsError);
                }
            }
        }


        public void btnRegisterCancel_Click(object sender, EventArgs e)
        {
            try
            {
                /*
                txtRegisterCedula.Text = "";

                txtRegisterName.Text = "";
                txtRegisterLastName.Text = "";
                txtRegisterSecondSurname.Text = "";
                txtRegisterEmail.Text = "";
                txtRegisterUsername.Text = "";
                txtRegisterPassword.Text = "";
                */
            }
            catch (Exception Err)
            {
                //Retorna el error  
                if (Err.Source != null)
                {
                    tsError = "Exception source: " + Err.Message;
                    Console.WriteLine(tsError);
                }
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (toUser.pfnLogin(out tsError, txtLoginUsername.Text, txtLoginPassword.Text))
                {
                    if (bool.Parse(HttpContext.Current.Session["tipo"].ToString()))
                    {
                        HttpContext.Current.Response.Redirect("Homepage.aspx");
                    }
                    else
                    {
                        HttpContext.Current.Response.Redirect("Homepage.aspx");
                    }
                }
                else
                {
                    Console.WriteLine(tsError);
                }
            }
            catch (Exception Err)
            {
                //Retorna el error  
                if (Err.Source != null)
                {
                    tsError = "Exception source: " + Err.Message;
                    Console.WriteLine(tsError);
                }
            }
        }
    }
}