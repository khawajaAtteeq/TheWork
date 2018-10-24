using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel;

namespace Helper.Test
{
    /// <summary>
    /// we got two lists to compare, one _products list i.e. the actual products and
    ///  another productList i.e. the products returned from the service. We have written
    ///  a helper class and compare method to convert the two Product list in TestHelper 
    /// project. This method checks the list items and compares them for equality of values.
    ///  You can add a class named ProductComparer to TestHelper project with following implementations,
    /// </summary>
    public class ProductComparer : IComparer, IComparer<Product>
    {
        public int Compare(object expected, object actual)
        {
            var lhs = expected as Product;
            var rhs = actual as Product;
            if (lhs == null || rhs == null) throw new InvalidOperationException();
            return Compare(lhs, rhs);
        }

        public int Compare(Product expected, Product actual)
        {
            int temp;
            return (temp = expected.Id.CompareTo(actual.Id)) != 0 ? 
                temp : expected.ProductName.CompareTo(actual.ProductName);
        }
    }

}
