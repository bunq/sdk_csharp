using System;
using System.Collections.Generic;
using System.Linq;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace Bunq.Sdk.Tests.Util
{
    public class TestPriorityOrderer: ITestCaseOrderer
    {
        public IEnumerable<TTestCase> OrderTestCases<TTestCase>(IEnumerable<TTestCase> allTestCase) where TTestCase : ITestCase
        {
            SortedDictionary<int, List<TTestCase>> sortedMethods = new SortedDictionary<int, List<TTestCase>>();

            foreach (TTestCase testCase in allTestCase)
            {
                string orderAttributeName = typeof(TestPriorityAttribute).AssemblyQualifiedName;
                IEnumerable<IAttributeInfo> allAttributeInfo = testCase.TestMethod.Method.GetCustomAttributes(orderAttributeName);

                int testPriority = 0;
                foreach (IAttributeInfo attributeInfo in allAttributeInfo)
                {
                    testPriority = attributeInfo.GetNamedArgument<int>("Priority");
                }

                GetOrCreate(sortedMethods, testPriority).Add(testCase);
            }
            
            foreach (var list in sortedMethods.Keys.Select(priority => sortedMethods[priority]))
            {
                list.Sort((method1, method2) =>
                {
                    return StringComparer.OrdinalIgnoreCase.Compare(
                        method1.TestMethod.Method.Name,
                        method2.TestMethod.Method.Name
                    );
                });
                
                foreach (TTestCase testCase in list)
                    yield return testCase;
            }
        }

        static TValue GetOrCreate<TKey, TValue>(IDictionary<TKey, TValue> dictionary, TKey key) where TValue : new()
        {
            TValue result;

            if (dictionary.TryGetValue(key, out result)) 
                return result;

            result = new TValue();
            dictionary[key] = result;

            return result;
        }
    }
}
