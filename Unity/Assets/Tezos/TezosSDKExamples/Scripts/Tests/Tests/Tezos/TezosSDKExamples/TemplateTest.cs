using NUnit.Framework;

namespace TezosSDKExamples.Templates
{
    /// <summary>
    /// Replace with comments...
    /// </summary>
    [Category("TezosSDKExamples")]
    public class TemplateTest
    {
        //  Events ----------------------------------------


        //  Properties ------------------------------------


        //  Fields ----------------------------------------


        //  Initialization --------------------------------


        //  Methods ---------------------------------------
        [Test]
        public void Add_ResultIs15_WhenInputIs10And5()
        {
            // Arrange
            int a = 10;
            int b = 5;

            // Act
            int result = a + b;

            // Assert
            Assert.That(result, Is.EqualTo(15));
            
        }


        //  Event Handlers --------------------------------
    }
}