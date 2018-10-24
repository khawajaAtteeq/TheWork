using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Web;

namespace TheWork.ErrorHelper
{
    /// <summary>
    /// Api Exception
    /// The directives applied on class as Serializable and DataContract to 
    /// make sure that the class defines or implements
    ///  a data contract is serializable and can be serialize by a serializer.
    /// </summary>
    [Serializable]
    [DataContract]
    public class ApiException : Exception, IApiExceptions
    {
        #region Public Serializable properties.
        [DataMember]
        public int ErrorCode { get; set; }
        [DataMember]
        public string ErrorDescription { get; set; }
        [DataMember]
        public HttpStatusCode HttpStatus { get; set; }

        string _reasonPhrase = "ApiException";

        [DataMember]
        public string ReasonPhrase
        {
            get { return this._reasonPhrase; }

            set { this._reasonPhrase = value; }
        }
        #endregion
    }
}