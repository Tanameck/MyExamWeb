﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

public class clsSQL
{
    public enum peQueryType { Query, Command };

    public static SqlConnection toCon = new SqlConnection();
    public static SqlCommand toCom = new SqlCommand();
    public SqlDataReader toRs;
    public int piLastID;

    public bool pfnConnect(out string osError)
    {
        try
        {
            osError = "";

            if (toCon.State != System.Data.ConnectionState.Open)
            {
                toCon.ConnectionString = "Server = tcp:ulacitserver.database.windows.net,1433;" +
                                            " Initial Catalog = dbMyExam;" +
                                            " Persist Security Info = False;" +
                                            " User ID = usrMyExam;" +
                                            " Password = Pass1234;" +
                                            " MultipleActiveResultSets = False;" +
                                            " Encrypt = True;" +
                                            " TrustServerCertificate = False;" +
                                            " Connection Timeout = 30;";

                toCon.Open(); //Iniciar conexion
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

    public bool pfnDisconnect(out string osError)
    {
        try
        {
            osError = "";

            if (toCon.State == System.Data.ConnectionState.Open)
            {
                toCon.Close(); //terminar conexion
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

    public bool pfnExecuteQuery(out string osError, string psSQL, peQueryType piType, bool pbReturnID = false)
    {
        try
        {
            osError = "";

            toCom = toCon.CreateCommand();
            toCom.CommandText = psSQL;

            if (toRs != null)
            {
                if (!toRs.IsClosed)
                {
                    toRs.Close();
                }
            }

            //0: Consulta | 1: Comando
            if (piType == peQueryType.Command)
            {
                if (pbReturnID)
                {
                    piLastID = (int)toCom.ExecuteScalar();
                }
                else
                {
                    toCom.ExecuteNonQuery();
                }
            }
            else if (piType == peQueryType.Query)
            {
                toRs = toCom.ExecuteReader();
            }

            //Retorna vacio ya que no hubo ningun error
            return true;
        }
        catch (Exception Err)
        {
            //Retorna el error  
            if (Err.Source != null)
            {
                toRs.Close();
                toCon.Close();
                osError = "IOException source: " + Err.Message;
                return false;
            }
            throw;
        }
    }
}