using CoduranceTwitter.DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CoduranceTwitter.Tests
{
    public class BaseTest
    {
        [TestInitialize]
        public void Setup()
        {
            MemoryRepository.Init();
        }
    }
}
