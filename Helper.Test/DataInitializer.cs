using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel;

namespace Helper.Test
{
    /// <summary>
    /// Data initializer for unit tests
    /// </summary>
    public class DataInitializer
    {
        /// <summary>
        /// Dummy products
        /// </summary>
        /// <returns></returns>
        public static List<Product> GetAllProducts()
        {
            var products = new List<Product>
                               {
                                   new Product() {ProductName = "Laptop"},
                                   new Product() {ProductName = "Mobile"},
                                   new Product() {ProductName = "HardDrive"},
                                   new Product() {ProductName = "IPhone"},
                                   new Product() {ProductName = "IPad"}
                               };
            return products;
        }

        /// <summary>
        /// Dummy tokens
        /// </summary>
        /// <returns></returns>
        public static List<Token> GetAllTokens()
        {
            var tokens = new List<Token>
                               {
                                   new Token()
                                       {
                                           AuthToken = "9f907bdf-f6de-425d-be5b-b4852eb77761",
                                           ExpiresOn = DateTime.Now.AddHours(2),
                                           IssuedOn = DateTime.Now,
                                           UserId = 1
                                       },
                                   new Token()
                                       {
                                           AuthToken = "9f907bdf-f6de-425d-be5b-b4852eb77762",
                                           ExpiresOn = DateTime.Now.AddHours(1),
                                           IssuedOn = DateTime.Now,
                                           UserId = 2
                                       }
                               };

            return tokens;
        }

        /// <summary>
        /// Dummy users
        /// </summary>
        /// <returns></returns>
        public static List<UserInformation> GetAllUsers()
        {
            var users = new List<UserInformation>
                               {
                                   new UserInformation()
                                       {
                                           UserName = "khawaja",
                                           Password = "khawaja",
                                           FirstName = "Khawaja",
                                           LastName = "Atteeq",
                                       },
                                   new UserInformation()
                                       {
                                           UserName = "wajahat",
                                           Password = "wajahat",
                                           FirstName = "Wajahat",
                                           LastName = "Awan",
                                       },
                                   new UserInformation()
                                       {
                                           UserName = "kashmir",
                                           Password = "kashmir",
                                           FirstName = "State of",
                                           LastName = "Kashmir",
                                       }
                               };

            return users;
        }

    }

}
