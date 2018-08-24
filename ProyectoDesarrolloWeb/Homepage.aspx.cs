using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Homepage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {  
        /**
         * Use this to add errors to the Page
         * **/

        try
        {
            
        }
        catch (Exception Err)
        {
            //Retorna el error  
            if (Err.Source != null)
            {
                string tsError = "Exception source: " + Err.Message;
                pnlError.Visible = true;
                lblError.Text = tsError;
            }
        }
    }

    protected void btnChooseExam_Click(object sender, EventArgs e)
    {
        try
        {
            
        }
        catch (Exception Err)
        {
            //Retorna el error  
            if (Err.Source != null)
            {
                string tsError = "Exception source: " + Err.Message;
                pnlError.Visible = true;
                lblError.Text = tsError;
            }
        }
    }
}
