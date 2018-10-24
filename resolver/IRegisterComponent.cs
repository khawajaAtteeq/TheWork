using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resolver
{
    /// <summary>
    /// In this interface I have declared two methods, 
    /// one RegisterType and other in to RegisterType with Controlled life time of the object,
    ///  i.e. the life time of an object will be hierarchal in manner. 
    /// This is kind of same like we do in Unity.
    /// </summary>
    public interface IRegisterComponent
    {
        /// <summary>
        /// Register type method
        /// </summary>
        /// <typeparam name="TFrom"></typeparam>
        /// <typeparam name="TTo"></typeparam>
        /// <param name="withInterception"></param>
        void RegisterType<TFrom, TTo>(bool withInterception = false) where TTo : TFrom;
        /// <summary>
        /// Register type with container controlled life time manager
        /// </summary>
        /// <typeparam name="TFrom"></typeparam>
        /// <typeparam name="TTo"></typeparam>
        /// <param name="withInterception"></param>
        void RegisterTypeWithControlledLifeTime<TFrom, TTo>(bool withInterception = false) where TTo : TFrom;
    }
}
