using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class clsUserTests
{
    [TestMethod]
    public void pfnLogin_UserLogin_ReturnTrue()
    {
        clsSQL toSQL = new clsSQL();
        clsUser toUser = new clsUser(toSQL);
        bool tnResult = false;
        string tsError = "";

        tnResult = toUser.pfnLogin(out tsError, "braulio", "1234");

        Assert.IsTrue(tnResult);
    }
}
