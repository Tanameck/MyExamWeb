using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

/// <summary>
/// Summary description for Usuario
/// </summary>
public class clsUser
{
    /*
    SqlConnection conexion = new SqlConnection("data source = TANAMECK; initial catalog = dbExamenOnline;" + "user id=Tanameck;password=1234");
    //Josue: "data source = DESKTOP-V6P625O\\MSSQLSERVER01; initial catalog = db_demo;" + "user id=josuemartinez;password=josue-18"
    //Vale: "data source = DESKTOP-AU2VG13; initial catalog = db_demo;" + "user id=valeriaba;password=ValeriaB.25"
    //Braulio: "data source = TANAMECK\SQLEXPRESS; initial catalog = dbExamenOnline;" + "user id=Tanameck;password=1234"

    String sql;
    SqlCommand com;
    SqlDataReader rs;
    */

    public clsEnvironment poEnvironment;

    public clsUser(clsEnvironment pvEnvironment)
    {
        poEnvironment = pvEnvironment;
    }

    public string pfsRegisterNormalUser(int piCedula,string psNombre, string psPrimerAp, string psSegundoAp, string psEmail, string psUsuario, string psPassword)
    {
        try
        {
            bool tnError = poEnvironment.pfnConnect(out string tsError);

            if (tsError.Equals(""))
            {
                string tsSQL = "INSERT INTO usuario" +
                    " VALUES('" + psUsuario + "'," +
                            " HASHBYTES('SHA2_512', '" + psPassword + "')," +
                            " '" + psNombre + "'," +
                            " '" + psPrimerAp + "'," +
                            " '" + psSegundoAp + "'," +
                            piCedula + "," +
                            "'" + psEmail + "'," +
                            "0," +
                            "1)";

                tsError = poEnvironment.pfsExecuteQuery(tsSQL, clsEnvironment.peQueryType.Command);

                if (tsError.Equals(""))
                {
                    tsError = poEnvironment.pfsDisconnect();
                }
            }

            return tsError;
            
        }
        catch (Exception Err)
        {
            //Retorna el error  
            if (Err.Source != null)
                return "IOException source: " + Err.Message;
            throw;
        }
    }

    public string pfsLogin(string psUsuario, string psPassword)
    {
        try
        {
            bool tnError = poEnvironment.pfnConnect(out string tsError);

            if (tsError.Equals(""))
            {
                string tsSQL = "SELECT *" +
                                " FROM Usuario" +
                                " WHERE Usuario = '" + psUsuario + "'" +
                                " AND CAST(CASE WHEN CONTRASENA = HASHBYTES('SHA2_512', '" + psPassword + "') then 1 else 0 end as bit) = 1" +
                                " AND estado = 1";

                tsError = poEnvironment.pfsExecuteQuery(tsSQL, clsEnvironment.peQueryType.Query);

                if (tsError.Equals(""))
                {
                    if (poEnvironment.toRs.HasRows)
                    {
                        poEnvironment.toRs.Read();
                        HttpContext.Current.Session["tipo"] = poEnvironment.toRs[8];
                        HttpContext.Current.Session["idUser"] = poEnvironment.toRs[0];
                        HttpContext.Current.Session["nombreCompleto"] = poEnvironment.toRs[3] + " " + poEnvironment.toRs[4] + " " + poEnvironment.toRs[5];
                        HttpContext.Current.Session["preguntaAleatoriaTable"] = "PREGUNTA_ALEATORIA_ID" + HttpContext.Current.Session["idUser"].ToString();

                        tsError = poEnvironment.pfsDisconnect();

                        if (tsError.Equals(""))
                        {
                            if (!HttpContext.Current.Session["tipo"].ToString().Equals(""))
                            {
                                switch (Int32.Parse(HttpContext.Current.Session["tipo"].ToString()))
                                {
                                    case 0: //Normal User
                                        HttpContext.Current.Response.Redirect("Homepage.aspx");
                                        break;
                                    case 1: //Admin
                                        HttpContext.Current.Response.Redirect("HomeAdmin.aspx");
                                        break;
                                    default:
                                        break;
                                }
                            }
                        }
                    }
                }
            }

            return tsError;
        }
        catch (Exception Err)
        {
            //Retorna el error  
            if (Err.Source != null)
                return "IOException source: " + Err.Message;
            throw;
        }
    }

    public string pfsClean()// deletes all the incompled exams and questions of the incompleted exams
    {
        try
        {
            bool tnError = poEnvironment.pfnConnect(out string tsError);

            if (tsError.Equals(""))
            {
                string tsSQL = "DELETE r" +
                    " FROM usuario_respuesta r " +
                    " INNER JOIN usuario_examen e " +
                        " ON(r.usuario_examen_id= e.usuario_examen_id) " +
                    " WHERE e.finalizado= 0" +
                    " DELETE FROM usuario_examen WHERE finalizado = 0";

                tsError = poEnvironment.pfsExecuteQuery(tsSQL, clsEnvironment.peQueryType.Command);

                if (tsError.Equals(""))
                {
                    tsError = poEnvironment.pfsDisconnect();
                }
            }

            return tsError;
        }
        catch (Exception Err)
        {
            //Retorna el error  
            if (Err.Source != null)
                return "IOException source: " + Err.Message;
            throw;
        }
    }
}

