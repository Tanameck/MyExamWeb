using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class clsUserTests
{
    [TestMethod]
    public void pfnLogin_UserLogin_ReturnTrue()
    {
        clsUser toUser = new clsUser();
        clsSQL toSQL = new clsSQL();
        bool tnResult = false;
        string tsError = "";

        if (toSQL.pfnConnect(out string err))
        {
            tnResult = toUser.pfnLogin(out tsError, "braulio", "1234");

            bool tnResult1 = toSQL.pfnDisconnect(out tsError);
        }
        else
        {
            tnResult = false;
        }

        Assert.IsTrue(tnResult);
    }
}
