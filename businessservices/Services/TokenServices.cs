using System;
using System.Configuration;
using System.Linq;
using BusinessEntities;
using DataModel;
using DataModel.UnitOfWork;


namespace BusinessServices
{
    public class TokenServices : ITokenServices
    {

        #region Private member variables.
        private readonly IUnitOfWork _unitOfWork;
        #endregion

        #region Public constructor.
        /// <summary>
        /// Public constructor.
        /// </summary>
        public TokenServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #endregion


        #region Public member methods.

        /// <summary>
        ///  Function to generate unique token with expiry against the provided userId.
        ///  Also add a record in database for generated token.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public TokenEntity GenerateToken(int userId)
        {
            string token = Guid.NewGuid().ToString();
            DateTime issuedOn = DateTime.Now;
            DateTime expiredOn = DateTime.Now.AddSeconds(
                                              Convert.ToDouble(ConfigurationManager.AppSettings["AuthTokenExpiry"]));
            var tokendomain = new Token
            {
                UserId = userId,
                AuthToken = token,
                IssuedOn = issuedOn,
                ExpiresOn = expiredOn
            };

            _unitOfWork.TokenRepository.Insert(tokendomain);
            _unitOfWork.Save();
            var tokenModel = new TokenEntity()
            {
                UserId = userId,
                IssuedOn = issuedOn,
                ExpiresOn = expiredOn,
                AuthToken = token
            };

            return tokenModel;
        }

        /// <summary>
        /// Method to validate token against expiry and existence in database.
        ///We can certainly use these tokens to maintain session as well.
        //The tokens are issues for 900 seconds i.e. 15 minutes.Now we
        //want that user should continue to use this token if he is using
        //other services as well for our application.Or suppose there is 
        //a case where we only want user to finish his work on the site 
        //within 15 minutes or within his session time before he makes a
        //new request.So while validating token in TokenServices,what we have
        //done is, to increase the time of the token by 900 seconds whenever
        //a valid request comes with a valid token,
        /// </summary>
        /// <param name="tokenId"></param>
        /// <returns></returns>
        public bool ValidateToken(string tokenId)
        {
            var token = _unitOfWork.TokenRepository.Get(t => t.AuthToken == tokenId && t.ExpiresOn > DateTime.Now);
            //first we check if the requested token exists in the database and is not 
            //expired.We check expiry by comparing it with current date time.If it is
            //valid token we just update the 
            //token into database with a new ExpiresOn time that is adding 900 seconds AKA 15 mins.

            if (token != null && !(DateTime.Now > token.ExpiresOn))
            {
                if (token.ExpiresOn != null)
                    token.ExpiresOn = token.ExpiresOn.Value.AddSeconds(
                        Convert.ToDouble(ConfigurationManager.AppSettings["AuthTokenExpiry"]));
                _unitOfWork.TokenRepository.Update(token);
                _unitOfWork.Save();
                return true;
            }
            return false;
        }

        /// <summary>
        /// Method to kill the provided token id.
        /// </summary>
        /// <param name="tokenId">true for successful delete</param>
        public bool Kill(string tokenId)
        {
            _unitOfWork.TokenRepository.Delete(x => x.AuthToken == tokenId);
            _unitOfWork.Save();
            var isNotDeleted = _unitOfWork.TokenRepository.GetMany(x => x.AuthToken == tokenId).Any();
            if (isNotDeleted) { return false; }
            return true;
        }

        /// <summary>
        /// Delete tokens for the specific deleted user
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>true for successful delete</returns>
        public bool DeleteByUserId(int userId)
        {
            _unitOfWork.TokenRepository.Delete(x => x.UserId == userId);
            _unitOfWork.Save();

            var isNotDeleted = _unitOfWork.TokenRepository.GetMany(x => x.UserId == userId).Any();
            return !isNotDeleted;
        }

        #endregion
 
    }
}
