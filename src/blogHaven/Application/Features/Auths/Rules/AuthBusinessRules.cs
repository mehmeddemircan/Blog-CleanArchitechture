using Application.Features.Auths.Constants;
using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;
using Core.Security.Enums;
using Core.Security.Hashing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auths.Rules
{
    public class AuthBusinessRules
    {
        private readonly IUserRepository _userRepository;

        public AuthBusinessRules(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task EmailCanNotBeDuplicatedWhenRegistered(string email)
        {
            User? user = await _userRepository.GetAsync(u => u.Email == email);
            if (user != null) throw new BusinessException("Mail already exists");

        }
        public async Task EmailAuthenticatorShouldBeExists(EmailAuthenticator? emailAuthenticator)
        {
            if (emailAuthenticator is null)
                throw new BusinessException(AuthMessages.EmailAuthenticatorDontExists);
        }

        public async Task OtpAuthenticatorShouldBeExists(OtpAuthenticator? otpAuthenticator)
        {
            if (otpAuthenticator is null)
                throw new BusinessException(AuthMessages.OtpAuthenticatorDontExists);
        }

        public async Task OtpAuthenticatorThatVerifiedShouldNotBeExists(OtpAuthenticator? otpAuthenticator)
        {
            if (otpAuthenticator is not null && otpAuthenticator.IsVerified)
                throw new BusinessException(AuthMessages.AlreadyVerifiedOtpAuthenticatorIsExists);
        }

        public async Task EmailAuthenticatorActivationKeyShouldBeExists(EmailAuthenticator emailAuthenticator)
        {
            if (emailAuthenticator.ActivationKey is null)
                throw new BusinessException(AuthMessages.EmailActivationKeyDontExists);
        }

        public async Task UserShouldBeExistsWhenSelected(User? user)
        {
            if (user == null)
                throw new BusinessException(AuthMessages.UserDontExists);
        }

        public async Task UserShouldNotBeHaveAuthenticator(User user)
        {
            if (user.AuthenticatorType != AuthenticatorType.None)
                throw new BusinessException(AuthMessages.UserHaveAlreadyAAuthenticator);
        }

        public async Task RefreshTokenShouldBeExists(RefreshToken? refreshToken)
        {
            if (refreshToken == null)
                throw new BusinessException(AuthMessages.RefreshDontExists);
        }
     
        public async Task UserPasswordShouldBeMatch(User user, string password)
        {
            if (!HashingHelper.VerifyPasswordHash(password, user!.PasswordHash, user.PasswordSalt))
                throw new BusinessException(AuthMessages.PasswordDontMatch);
        }
    }
}
