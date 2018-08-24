﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.IO;

/// <summary>
/// Summary description for Environment
/// </summary>
public class clsEnvironment
{

    String tsSQL;

    public static SqlCommand toCom = new SqlCommand();
    public static SqlConnection toCon = new SqlConnection();

    public SqlDataReader toRs;
    public int piLastID;

    //Josue: "data source = DESKTOP-V6P625O\\MSSQLSERVER01; initial catalog = dbExamenOnline;" + "user id=josuemartinez;password=josue-18"
    //Vale: "data source = DESKTOP-IJU2U32; initial catalog = dbExamenOnline;" + "user id=valeriaba;password=1234"
    //Braulio: "data source = TANAMECK\SQLEXPRESS; initial catalog = dbExamenOnline;" + "user id=Tanameck;password=1234"

    public enum peQueryType { Query, Command };

    public clsEnvironment()
    {
    }

    public string pfsConnect()
    {
        try
        {
            if (toCon.State != System.Data.ConnectionState.Open)
            {
                toCon.ConnectionString = "DATA SOURCE = TANAMECK;" +
                                                "INITIAL CATALOG = dbExamenOnline;" +
                                                "USER ID=Tanameck;" +
                                                "PASSWORD=1234";

                toCon.Open(); //Iniciar conexion
            }
            return "";
        }
        catch (Exception Err)
        {
            //Retorna el error  
            if (Err.Source != null)
                return "IOException source: " + Err.Message;
            throw;
        }
    }

    public string pfsDisconnect()
    {
        try
        {
            if (toCon.State == System.Data.ConnectionState.Open)
            {
                toCon.Close(); //terminar conexion
            }

            return "";
        }
        catch (Exception Err)
        {
            //Retorna el error  
            if (Err.Source != null)
                return "IOException source: " + Err.Message;
            throw;
        }
    }

    public string pfsExecuteQuery(string psSQL, peQueryType piType, bool pbReturnID=false)
    {
        try
        {
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
            } else if(piType == peQueryType.Query)
            {           
                toRs = toCom.ExecuteReader();
            }

            //Retorna vacio ya que no hubo ningun error
            return "";
        }
        catch (Exception Err)
        {
            //Retorna el error  
            if (Err.Source != null)
                toRs.Close();
                toCon.Close();
                return "IOException source: " + Err.Message;
            throw;
        }
    }
}