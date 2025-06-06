using FileTests.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Internal;
using Xunit.Sdk;
using Xunit.v3;

[assembly: CollectionBehavior(DisableTestParallelization = true)]
[assembly: TestCollectionOrderer(typeof(TestAlphabeticalOrderer))]
[assembly: TestCaseOrderer(typeof(TestAlphabeticalOrderer))]
namespace FileTests.Test
{
    public class TestAlphabeticalOrderer : ITestCollectionOrderer, ITestCaseOrderer
    {
        public IReadOnlyCollection<TTestCase> OrderTestCases<TTestCase>(IReadOnlyCollection<TTestCase> testCases) 
            where TTestCase : notnull, ITestCase => testCases.OrderBy(testCase => testCase.TestMethod.MethodName).CastOrToReadOnlyList();

        public IReadOnlyCollection<TTestCollection> OrderTestCollections<TTestCollection>(IReadOnlyCollection<TTestCollection> testCollections)
            where TTestCollection : ITestCollection => testCollections.OrderBy(collection => collection.TestCollectionDisplayName).CastOrToReadOnlyList();
    }
}
