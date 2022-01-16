using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Primitives;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Net;
using WebApiFormatter.Helpers;
using WebApiFormatter.Services;

namespace WebApiUnitTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test,Order(0)]
        public void Test_Validate_OnValidStringData_ShouldBe_True()
        {
            Validator validator = new Validator();

            validator.Validate("mike");

            Assert.IsFalse(validator.IsNumeric);
            Assert.IsTrue(validator.IsDataVald);
        }

        [Test,Order(1)]
        public void Test_Validate_EmptyData_ShouldBe_False()
        {
            Validator validator = new Validator();

            validator.Validate("");

            Assert.IsFalse(validator.IsDataVald);
        }

        [Test,Order(2)]
        public void Test_Validate_OnValidIntNumber_ShouldBe_True()
        {
            Validator validator = new Validator();

            validator.Validate("815783");

            Assert.IsTrue(validator.IsNumeric);
            Assert.IsTrue(validator.IsDataVald);
        }


        [Test,Order(3)]
        public void Test_Validate_OnFloatNumberValue_ShouldBe_True()
        {
            Validator validator = new Validator();

            validator.Validate("-0,064");

            Assert.IsTrue(validator.IsNumeric);
            Assert.IsTrue(validator.IsDataVald);
        }

        [Test,Order(4)]
        public  void Test_NegotiveNumberFormatter_ShouldBe_Equal_negotive8()
        {
            NumberFormatter formatter = new NumberFormatter();

            var result = formatter.Format("-64");
            
            Assert.AreEqual(result, (-8).ToString());
        }

        [Test,Order(5)]
        public void Test_NumberFormatter_ShouldBe_Equal_8()
        {
            NumberFormatter formatter = new NumberFormatter();

            var result = formatter.Format("64");

            Assert.AreEqual(result, 8.ToString());
        }

        [Test,Order(6)]
        public void Test_StringFormatter_ShouldBe_Equal_olleH()
        {
            StringFormatter formatter = new StringFormatter();

            var result = formatter.Format("Hello");

            Assert.AreEqual(result,"olleH");
        }
    }
}