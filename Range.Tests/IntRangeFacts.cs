using NUnit.Framework;
using System.Collections.Generic;

namespace Range.Tests
{
    [TestFixture]
    internal sealed class IntRangeFacts
    {
        /* R G R: Red Green Refactor
         * OK 1. Expression is null should fail
         * OK 2. Expression empty should fail
         * OK 3. Valid expression should not fail
         * 4. [2,6) endPoints returns {2, 5}
         */

        [Test]
        public void With_Null_Expression_Should_Fail() {
            string expression = null;

            Assert.That(() => new IntRange(expression),
                Throws.ArgumentNullException);
        }

        [Test]
        public void With_Empty_Expression_Should_Fail()
        {
            string expression = "";

            Assert.That(() => new IntRange(expression),
                Throws.ArgumentException);
        }

        [Test]
        public void With_Valid_Expression_Should_Pass()
        {
            string expression = "[2,6)";

            Assert.That(() => new IntRange(expression),
                Throws.Nothing);
        }

        [Test]
        public void With_Valid_Range_Returns_End_Points()
        {
            string expression = "[2,6)";

            IntRange range = new IntRange(expression);

            ISet<int> endPoints = range.GetEndPoints();

            Assert.That(endPoints, Is.EqualTo(new HashSet<int> { 2, 5 }));
        }

        [Test]
        public void With_Valid_Range_Returns_End_Points2()
        {
            string expression = "[2,6]";

            IntRange range = new IntRange(expression);

            ISet<int> endPoints = range.GetEndPoints();

            Assert.That(endPoints, Is.EqualTo(new HashSet<int> { 2, 6 }));
        }

    }
}
