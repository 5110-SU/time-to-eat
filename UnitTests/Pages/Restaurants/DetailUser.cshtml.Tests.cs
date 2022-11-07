﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContosoCrafts.WebSite.Pages.Restaurants;
using NUnit.Framework;

namespace UnitTests.Pages.Restaurants
{
    internal class DetailUserTests
    {
        #region TestSetup

        // Read Model Page instance to test
        public static DetailUserModel pageModel;

        /// <summary>
        /// SetUp ReadModel for the tests
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            pageModel = new DetailUserModel(TestHelper.ProductService)
            {
            };
        }

        #endregion TestSetup

        #region OnGet

        /// <summary>
        /// Test the Valid OnGet Http request method with random product id
        /// </summary>
        [Test]
        public void OnGet_Valid_With_New_Product_ID_Should_Retrieve_Null()
        {
            // Arrange
            var Id = System.Guid.NewGuid().ToString();

            // Act
            pageModel.OnGet(Id);

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual(null, pageModel.Product);
        }

        /// <summary>
        /// Test the OnGet Http request method with existing product id
        /// </summary>
        [Test]
        public void OnGet_Valid_With_Existing_Product_ID_Should_Retrieve_Expected_Product()
        {
            // Arrange
            var Product = TestHelper.ProductService.GetProducts().First();

            // Act
            pageModel.OnGet(Product.Id);

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual(Product.Id, pageModel.Product.Id);
        }

        #endregion OnGet
    }
}
