using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterUser : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnLogout_Click(object sender, EventArgs e)
    {
        Session["preguntaAleatoriaTable"] = "";
        Session["nombreExamen"] = "";
        Session["idUsuarioExamen"] = "";
        Session["tipo"] = "";
        Session["idUser"] = "";
        Session["nombreCompleto"] = "";
        Session["idQuestion"] = "";
        Session["idExamen"] = "";
        Session["idUser"] = "";
        Session["idUsuarioExamen"] = "";

        Response.Redirect("login.aspx");
    }
}
