using System;
using NUnit.Framework;

[TestFixture]
public class clsEnvironmentTests
{
    [TestCase]
    public void pfnConnect_SuccessfulConnection_ReturnTrue()
    {
        clsEnvironment toEnvironment = new clsEnvironment();

        bool r = toEnvironment.pfnConnect(out string err);

        Assert.IsTrue(r);
    }
}
