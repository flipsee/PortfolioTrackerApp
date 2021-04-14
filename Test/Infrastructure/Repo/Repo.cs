using System;
using Common.Contracts.Repo;
using Common.Helper;
using Common.Models;
using Common.Sessions;
using Infrastructure.Repo;
using Microsoft.VisualStudio.TestTools.UnitTesting; 

namespace Test.Infrastructure.Repo
{
    [TestClass]
    public class RepoTest
    {
        SessionProvider session = new SessionProvider();

        public RepoTest ()
        {
            session.Initialise("Ivan", "my@Mail.com");
        }

        [TestMethod]
        public void TestMethod1()
        {
            //var db = new DBInit();
        }


        [TestMethod]
        public void XMLRepoTest()
        {
            IBaseRepo<Ticker> tickerRepo = new BaseXMLRepo<Ticker>(session, Utils.Logger);
            tickerRepo.Add(new Ticker() { Symbol = "Test", Name = "Test" });
            
        }
    }
}
