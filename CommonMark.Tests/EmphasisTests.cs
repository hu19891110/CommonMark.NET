﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CommonMark.Tests
{
    [TestClass]
    public class EmphasisTests
    {
        [TestMethod]
        [TestCategory("Inlines - Emphasis and strong emphasis")]
        public void UnderscoreWithinEmphasis()
        {
            // See https://github.com/jgm/stmd/issues/51 for additional info
            // The rule is that inlines are processed left-to-right

            // Arrange
            var commonMark = Helpers.Normalize("*_*_");
            var expected = Helpers.Normalize("<p><em>_</em>_</p>");

            // Act
            var actual = CommonMarkConverter.Convert(commonMark);

            // Assert
            Helpers.LogValue("Actual", actual);
            Assert.AreEqual(Helpers.Tidy(expected), Helpers.Tidy(actual));
        }

        [TestMethod]
        [TestCategory("Inlines - Emphasis and strong emphasis")]
        public void UnderscoreWithinEmphasis2()
        {
            // See https://github.com/jgm/stmd/issues/51 for additional info

            // Arrange
            var commonMark = Helpers.Normalize("*a _b _c d_ e*");
            var expected = Helpers.Normalize("<p><em>a _b <em>c d</em> e</em></p>");

            // Act
            var actual = CommonMarkConverter.Convert(commonMark);

            // Assert
            Helpers.LogValue("Actual", actual);
            Assert.AreEqual(Helpers.Tidy(expected), Helpers.Tidy(actual));
        }
    }
}