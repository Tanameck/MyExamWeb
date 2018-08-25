using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class clsSQLTests
{
    [TestMethod]
    public void pfnConnect_SuccessfulConnect_ReturnTrue()
    {
        clsSQL toSQL = new clsSQL();
        bool tnResult = false;
        string tsError = "";

        tnResult = toSQL.pfnConnect(out tsError);

        Assert.IsTrue(tnResult);
    }

    [TestMethod]
    public void pfnConnect_SuccessfulDisconnect_ReturnTrue()
    {
        clsSQL toSQL = new clsSQL();
        bool tnResult = false;
        string tsError = "";

        if (toSQL.pfnConnect(out string err))
        {
            tnResult = toSQL.pfnDisconnect(out tsError);
        }
        else
        {
            tnResult = false;
        }

        Assert.IsTrue(tnResult);
    }

    [TestMethod]
    public void pfnConnect_SuccessfulQuery_ReturnTrue()
    {
        clsSQL toSQL = new clsSQL();
        bool tnResult = false;
        string tsError = "";

        if (toSQL.pfnConnect(out string err))
        {
            tnResult = toSQL.pfnExecuteQuery(out tsError,"SELECT * FROM [dbo].[USER]",clsSQL.peQueryType.Query);

            bool tnResult1 = toSQL.pfnDisconnect(out tsError);
        }
        else
        {
            tnResult = false;
        }

        Assert.IsTrue(tnResult);
    }

    [TestMethod]
    public void pfnConnect_SuccessfulCommandInsert_ReturnTrue()
    {
        clsSQL toSQL = new clsSQL();

        bool tnResult = false;
        string tsError = "";
        string tsSQL = "INSERT INTO [dbo].[USER]" + 
                        "VALUES('unit_test'," + 
                                "HASHBYTES('SHA2_512', '1234')," +
                                "'Unit'," + 
                                "'Test'," +
                                "000000000," +
                                "'unit_test@info.com'," +
                                "1," +
                                "1)";

        if (toSQL.pfnConnect(out string err))
        {
            tnResult = toSQL.pfnExecuteQuery(out tsError, tsSQL, clsSQL.peQueryType.Command);

            bool tnResult1 = toSQL.pfnDisconnect(out tsError);
        }
        else
        {
            tnResult = false;
        }

        Assert.IsTrue(tnResult);
    }

    [TestMethod]
    public void pfnConnect_SuccessfulCommandInsert_ReturnID()
    {
        clsSQL toSQL = new clsSQL();

        int tiID = 0;
        string tsError = "";
        string tsSQL = "INSERT INTO [dbo].[USER]" +
                        "VALUES('unit_test'," +
                                "HASHBYTES('SHA2_512', '1234')," +
                                "'Unit'," +
                                "'Test'," +
                                "000000000," +
                                "'unit_test@info.com'," +
                                "1," +
                                "1)";

        if (toSQL.pfnConnect(out string err))
        {
            if (toSQL.pfnExecuteQuery(out tsError, tsSQL, clsSQL.peQueryType.Command, true))
            {
                tiID = toSQL.piLastID;

                bool tnResult1 = toSQL.pfnDisconnect(out tsError);
            }
            else
            {
                tiID = 0;
            }
        }
        else
        {
            tiID = 0;
        }

        Assert.IsFalse(0 == tiID);
    }

    [TestMethod]
    public void pfnConnect_SuccessfulCommandDelete_ReturnTrue()
    {
        clsSQL toSQL = new clsSQL();

        bool tnResult = false;
        string tsError = "";
        string tsSQL = "DELETE FROM [dbo].[USER]" +
                        "WHERE username = 'unit_test'";

        if (toSQL.pfnConnect(out string err))
        {
            tnResult = toSQL.pfnExecuteQuery(out tsError, tsSQL, clsSQL.peQueryType.Command);

            bool tnResult1 = toSQL.pfnDisconnect(out tsError);
        }
        else
        {
            tnResult = false;
        }

        Assert.IsTrue(tnResult);
    }
}
