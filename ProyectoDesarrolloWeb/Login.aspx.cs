using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class login : System.Web.UI.Page
{

    string tsError;

    public static clsEnvironment poEnvironment = new clsEnvironment();

    clsUser toUser = new clsUser(poEnvironment);

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            tsError = toUser.pfsClean();

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
    protected void btnRegisterNewUser_Click(object sender, EventArgs e)
    {
        try
        {
            tsError = toUser.pfsRegisterNormalUser(Int32.Parse(txtRegisterCedula.Text), 
                                                txtRegisterName.Text, 
                                                txtRegisterLastName.Text, 
                                                txtRegisterSecondSurname.Text, 
                                                txtRegisterEmail.Text, 
                                                txtRegisterUsername.Text, 
                                                txtRegisterPassword.Text);
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


    protected void btnRegisterCancel_Click(object sender, EventArgs e)
    {
        try {
            txtRegisterName.Text = "";
            txtRegisterLastName.Text = "";
            txtRegisterSecondSurname.Text = "";
            txtRegisterEmail.Text = "";
            txtRegisterUsername.Text = "";
            txtRegisterPassword.Text = "";
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
            toUser.pfsLogin(txtLoginUsername.Text, txtLoginPassword.Text);
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