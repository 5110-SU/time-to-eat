using ContosoCrafts.WebSite.Pages.Restaurants;
using NUnit.Framework;
using System.Linq;

namespace UnitTests.Pages.Restaurants
{
    /// <summary>
    /// Unit tests for the IndexModel class
    /// </summary>
    public class IndexTests
    {
        #region TestSetup

        // Index model page instance 
        public static IndexModel pageModel;

        /// <summary>
        /// SetUp IndexModel for tests
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            pageModel = new IndexModel(TestHelper.ProductService)
            {
            };
        }

        #endregion TestSetup

        #region OnGet

        /// <summary>
        /// Tests OnGet method should retrieve all products
        /// </summary>
        [Test]
        public void OnGet_Should_Retrieve_All_Products()
        {
            // Arrange
            var data = TestHelper.ProductService.GetAllData().Count();
            // Act
            pageModel.OnGet();
      
            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual(data, pageModel.Products.Count());
        }

        #endregion OnGet
    }
}
