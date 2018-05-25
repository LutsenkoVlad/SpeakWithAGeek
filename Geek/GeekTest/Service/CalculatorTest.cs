using System;
using System.Collections.Generic;
using Geek.Infrastructure.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace GeekTest.Service
{
    [TestClass]
    public class CalculatorTest
    {
        private readonly CalculateService _calculateService;

        public CalculatorTest()
        {
            _calculateService = new CalculateService();
        }

        [TestMethod]
        public void AddReturnFalseGivenValueOf13And22()
        {
            double result = _calculateService.Add(13, 22);
            Assert.AreEqual(35, result);
        }

        [TestMethod]
        public void SubReturnFalseGivenValueOf13And22()
        {
            double result = _calculateService.Sub(142, 23);
            Assert.AreEqual(119, result);
        }

        [TestMethod]
        public void MulReturnFalseGivenValueOf13And22()
        {
            double result = _calculateService.Mul(8, 222);
            Assert.AreEqual(1776, result);
        }

        [TestMethod]
        public void DivReturnFalseGivenValueOf13And22()
        {
            double result = _calculateService.Div(64, 8);
            Assert.AreEqual(8, result);
        }
    }
}
