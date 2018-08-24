using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace NUnitTesting
{
    /// <summary>
    /// Summary description for NUnitTest
    /// </summary>
    public class NUnitTest
    {
        [TestFixture]
        public class clsEnvironmentTests
        {
            [Test]
            public void pfnConnect_SuccessfulConnection_ReturnTrue()
            {
                clsEnvironment toEnvironment = new clsEnvironment();

                bool r = toEnvironment.pfnConnect(out string err);

                Assert.IsTrue(r);
            }
        }
    }
}