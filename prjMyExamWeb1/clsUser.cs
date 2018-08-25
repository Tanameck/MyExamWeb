using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

public class clsUser
{
    public clsSQL poSQL;
    bool tnError;

    public clsUser()
    {
    }

    public clsUser(clsSQL pvSQL)
    {
        poSQL = pvSQL;
    }

    public bool pfnRegisterNormalUser(out string osError, int piCedula, string psNombre, string psPrimerAp, string psEmail, string psUsuario, string psPassword)
    {
        try
        {
            if (poSQL.pfnConnect(out osError))
            {
                string tsSQL = "INSERT INTO [dbo].[USER]" +
                    " VALUES('" + psUsuario + "'," +
                            " HASHBYTES('SHA2_512', '" + psPassword + "')," +
                            " '" + psNombre + "'," +
                            " '" + psPrimerAp + "'," +
                            piCedula + "," +
                            "'" + psEmail + "'," +
                            "0," +
                            "1)";

                if (poSQL.pfnExecuteQuery(out osError, tsSQL, clsSQL.peQueryType.Command))
                {
                    tnError = poSQL.pfnDisconnect(out osError);
                }
            }

            return true;

        }
        catch (Exception Err)
        {
            //Retorna el error  
            if (Err.Source != null)
            {
                osError = "IOException source: " + Err.Message;
                return false;
            }
            throw;
        }
    }

    public bool pfnLogin(out string osError, string psUsuario, string psPassword)
    {
        try
        {
            if (poSQL.pfnConnect(out osError))
            {
                string tsSQL = "SELECT *" +
                                " FROM [dbo].[USER]" +
                                " WHERE username = '" + psUsuario + "'" +
                                " AND CAST(CASE WHEN password = HASHBYTES('SHA2_512', '" + psPassword + "') then 1 else 0 end as bit) = 1" +
                                " AND status = 1";

                if (poSQL.pfnExecuteQuery(out osError, tsSQL, clsSQL.peQueryType.Query))
                {
                    if (poSQL.toRs.HasRows)
                    {
                        poSQL.toRs.Read();

                        HttpContext.Current.Session["tipo"] = poSQL.toRs[7].ToString();
                        //HttpContext.Current.Session["idUser"] = poSQL.toRs[0];
                        //HttpContext.Current.Session["nombreCompleto"] = poSQL.toRs[3] + " " + poSQL.toRs[4] + " " + poSQL.toRs[5];
                        //HttpContext.Current.Session["preguntaAleatoriaTable"] = "PREGUNTA_ALEATORIA_ID" + HttpContext.Current.Session["idUser"].ToString();

                        if (!poSQL.pfnDisconnect(out osError))
                        {
                            return false;
                        }
                    }
                } 
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

            return true;
        }
        catch (Exception Err)
        {
            //Retorna el error  
            if (Err.Source != null)
            {
                osError = "IOException source: " + Err.Message;
                return false;
            }
            throw;
        }

    }
}

