using NUnit.Framework;
using OpenQA.Selenium.Remote;

namespace API_Tests_by_IrynaShelevii
{
    public class WebServicesTests
    {
        [Test]
        public void SoapTestLangList()
        {
            var langList = new SoapWeb();
            Assert.IsNotNull(langList.InvokeSoapService());
        }

        [Test]

    public void RestTestCreateNewUser()
        {
            var userInst = new RestWeb();
            var response = userInst.CreateNewUser("Ivan", "Tester", "/api/users");
            Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.Created);
        }
    }

   
}