﻿namespace Cadru.UnitTest.Framework.UnitTests.Collections
{
    using Cadru.Collections;
    using Cadru.UnitTest.Framework;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Diagnostics.CodeAnalysis;

    [TestClass, ExcludeFromCodeCoverageAttribute]
    public class ComparisonComparerTests
    {
        /// <summary>
        ///A test for Compare (object, object)
        ///</summary>
        [TestMethod]
        public void Compare()
        {
            var comparer = ComparisonComparer<DateTime>.Create((a, b) => a.Date.Month.CompareTo(b.Date.Month));
            var x = new DateTime(2006, 10, 31);
            var y = new DateTime(2006, 11, 1);
            Assert.IsTrue(comparer.Compare(x, y) < 0);
            Assert.IsTrue(comparer.Compare(y, x) > 0);
            Assert.IsTrue(comparer.Compare(x, x) == 0);
            ExceptionAssert.Throws<ArgumentNullException>(() => ComparisonComparer<string>.Create(null));
        }
    }
}