using Business.Abstract;
using Core.Authentication;
using DataAccess.Abstract;
using Entities.Dtos;

namespace Business.Concrete
{
    public class LoginManager : ILoginService
    {
        private readonly ILoginDal? _loginDal;

        TokenUtils _tokenUtils = new();

        public LoginManager(ILoginDal loginDal)
        {
            _loginDal = loginDal;
        }

        /// <summary>
        /// Kimlik doğrulama
        /// </summary>
        /// <param name="mail"></param>
        /// <param name="password"></param>
        /// <param name="audience"></param>
        /// <param name="issuer"></param>
        /// <param name="secret"></param>
        /// <returns></returns>
        public async Task<UserDto> Authenticate(string mail, string password, string audience, string issuer, string secret)
        {
            var userInfo = await _loginDal.Authenticate(mail, password);

            if (userInfo == null)

                return new UserDto
                {
                    AuthenticateResult = false
                };


            var generatedTokenInfo = await _tokenUtils.GenerateToken(new UserDto { Mail = userInfo.Mail, Role = userInfo.Role }, secret, issuer, audience);

            return new UserDto
            {
                Password = userInfo.Password,
                Mail = userInfo.Mail,
                AccessTokenExpireDate = generatedTokenInfo.TokenExpireDate,
                AuthenticateResult = true,
                AuthToken = generatedTokenInfo.Token,
                RefreshToken = generatedTokenInfo.RefreshToken,
                Role = userInfo.Role               
            };

        }
    }
}
