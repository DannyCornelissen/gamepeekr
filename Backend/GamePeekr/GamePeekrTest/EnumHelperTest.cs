using GamepeekrReviewManagement.Helpers;

namespace GamePeekrTest
{
    [TestClass]
    public class EnumHelperTest
    {
        internal enum SampleEnum
        {
            Value1,
            Value2,
            Value3
        }

        [TestMethod]
        public void EnumToList_ValidEnum_ReturnsListWithAllValues()
        {
            // Arrange
            var expectedValues = new List<string> { "Value1", "Value2", "Value3" };

            // Act
            var result = EnumHelper.EnumToList<SampleEnum>();

            // Assert
            CollectionAssert.AreEqual(expectedValues, result.ToList());
        }

        [TestMethod]
        public void EnumToString_ValidEnumValue_ReturnsStringValue()
        {
            // Arrange
            int enumId = 2;
            // Act
            string result = EnumHelper.EnumToString<SampleEnum>(enumId);

            // Assert
            Assert.AreEqual("Value3", result);
        }

        [TestMethod]
        public void EnumParse_ValidStringValue_ReturnsEnumId()
        {
            // Arrange
            string enumValue = "Value2";

            // Act
            int result = EnumHelper.EnumParse<SampleEnum>(enumValue);

            // Assert
            Assert.AreEqual(1, result);
        }
    }
}