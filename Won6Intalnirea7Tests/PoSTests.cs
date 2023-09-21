using Microsoft.VisualStudio.TestTools.UnitTesting;
using Won6Intalnirea7;
using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using Won6Intalnirea7.Bank;

namespace Won6Intalnirea7.Tests
{
    [TestClass()]
    public class PoSTests
    {
        [TestMethod()]
        public void PlatesteTest()
        {
            Mock<IPaymentProvider> mock = new Mock<IPaymentProvider>();
            //mock.Setup(p=>p.Plateste(cardId,sumaDePlata)).
            var pos = new PoS(mock.Object);
            var cardMock = new Mock<ICard>();


            pos.Plateste(cardMock.Object, 1000);
        }
    }
}