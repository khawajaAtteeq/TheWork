using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel.UnitOfWork;

namespace BusinessServices
{
    public class UserServices:IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        // constructor 
        public UserServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        // auth method will take two parameters and find if user exist or not 

        public int Authenticate(string userName, string password)
        {
            try
            {
                var user = _unitOfWork.UserRepository.Get(u => u.UserName == userName
                                                               && u.Password == password
                    );
                if (user != null && user.Id > 0)
                {
                    return user.Id;
                }
                return 0;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
