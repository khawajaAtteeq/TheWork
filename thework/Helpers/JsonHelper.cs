using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace TheWork.Helpers
{
    public static class JsonHelper
    {
        #region Public extension methods.
        /// <summary>
        /// Extened method of object class
        /// Converts an object to a json string.
        /// In the above code “ToJson()” method is an extension of base Object class, 
        /// which serializes supplied the object 
        /// to a JSon string. The method using “JavaScriptSerializer” class
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ToJson(this object obj)
        {
            var serializer = new JavaScriptSerializer();
            try
            {
                return serializer.Serialize(obj);
            }
            catch (Exception ex)
            {
                return "";
            }
        }
        #endregion
    }
}