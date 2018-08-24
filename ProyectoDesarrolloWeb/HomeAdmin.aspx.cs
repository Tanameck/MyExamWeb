using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class HomeAdmin : System.Web.UI.Page
{

    string tsError = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {

            }
        }
        catch (Exception Err)
        {
            //Retorna el error  
            if (Err.Source != null)
            {
                tsError = "Exception source: " + Err.Message;
                pnlError.Visible = true;
                lblError.Text = tsError;
            }
        }
    }

    protected void btnChooseTopic_Click1(object sender, EventArgs e)
    {
        try
        {
            
        }
        catch (Exception Err)
        {
            //Retorna el error  
            if (Err.Source != null)
            {
                tsError = "Exception source: " + Err.Message;
                pnlError.Visible = true;
                lblError.Text = tsError;
            }
        }
    }

    protected void btnAddExam_Click(object sender, EventArgs e)
    {
        try
        {
            
        }
        catch (Exception Err)
        {
            //Retorna el error  
            if (Err.Source != null)
            {
                tsError = "Exception source: " + Err.Message;
                pnlError.Visible = true;
                lblError.Text = tsError;
            }
        }
    }

    protected void btnDeleteExam_Click(object sender, EventArgs e)
    {
        try
        {
            
        }
        catch (Exception Err)
        {
            //Retorna el error  
            if (Err.Source != null)
            {
                tsError = "Exception source: " + Err.Message;
                pnlError.Visible = true;
                lblError.Text = tsError;
            }
        }
    }

    protected void btnNewTopic_Click(object sender, EventArgs e)
    {

    }

    public void psLoadSubject()
    {
        try
        { 
            
        }
        catch (Exception Err)
        {
            //Retorna el error  
            if (Err.Source != null)
            {
                tsError = "Exception source: " + Err.Message;
                pnlError.Visible = true;
                lblError.Text = tsError;
            }
        }
    }

    public void psLoadExam()
    {
        try
        {
            
        }
        catch (Exception Err)
        {
            //Retorna el error  
            if (Err.Source != null)
            {
                tsError = "Exception source: " + Err.Message;
                pnlError.Visible = true;
                lblError.Text = tsError;
            }
        }
    }

    public void psCleanScreen()
    {
        try
        {
            
        }
        catch (Exception Err)
        {
            //Retorna el error  
            if (Err.Source != null)
            {
                tsError = "Exception source: " + Err.Message;
                pnlError.Visible = true;
                lblError.Text = tsError;
            }
        }
    }

    protected void btnNewTopic_Click1(object sender, EventArgs e)
    {
        try
        {
            
        }
        catch (Exception Err)
        {
            //Retorna el error  
            if (Err.Source != null)
            {
                tsError = "Exception source: " + Err.Message;
                pnlError.Visible = true;
                lblError.Text = tsError;
            }
        }
    }
}