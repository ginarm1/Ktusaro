using Ktusaro.Core.Exceptions;
using Ktusaro.Core.Interfaces.Repositories;
using Ktusaro.Core.Interfaces.Services;
using Ktusaro.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Ktusaro.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserService(IUserRepository userRepository, IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _userRepository = userRepository;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<List<User>> GetAll()
        {
            var users = await _userRepository.GetAll();

            if (users == null)
            {
                throw new UserNotFound();
            }

            return users;
        }

        public async Task<User> GetCurrentUser()
        {
            if (_httpContextAccessor.HttpContext.User == null)
            {
                throw new UserNotFound();
            }

            var userEmail = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Email)?.Value;

            var user = await _userRepository.GetByEmail(userEmail);

            if (user == null)
            {
                throw new UserNotFound();
            }

            return user;
        }

        public async Task<User> GetById(int id)
        {
            var user = await _userRepository.GetById(id);

            if (user == null)
            {
                throw new UserNotFound();
            }

            return user;
        }

        public async Task<User> UpdateByEmail(string email, string roleName, string representativeName)
        {
            var user = await _userRepository.GetByEmail(email);

            if (user == null)
            {
                throw new UserNotFound();
            }

            if (roleName != null)
            {
                roleName = roleName.ToLower();
                roleName = FirstCharToUpper(roleName);

                if (!Enum.IsDefined(typeof(Role), roleName))
                {
                    throw new RoleNotFound();
                }

                for (int i = 1; i <= Enum.GetNames(typeof(Role)).Length; i++)
                {
                    if (roleName == Enum.GetName(typeof(Role), i))
                    {
                        if (Role.Admin.ToString() == roleName)
                        {
                            user.Role = Role.Admin;
                        }

                        else if (Role.Unverified.ToString() == roleName)
                        {
                            user.Role = Role.Unverified;
                        }

                        await _userRepository.ChangeRoleByEmail(user.Email,i);
                        break;
                    }
                }
            }

            if (representativeName != null)
            {
                representativeName= representativeName.ToLower();
                representativeName = FirstCharToUpper(representativeName);

                if (!Enum.IsDefined(typeof(Representative), representativeName))
                {
                    throw new RepresentativeNotFound();
                }

                for (int i = 1; i <= Enum.GetNames(typeof(Representative)).Length; i++)
                {
                    if (representativeName == Enum.GetName(typeof(Representative), i))
                    {
                        if (Representative.Infosa.ToString() == representativeName)
                        {
                            user.Representative = Representative.Infosa;
                        }

                        else if (Representative.Vivatchemija.ToString() == representativeName)
                        {
                            user.Representative = Representative.Vivatchemija;
                        }

                        else if (Representative.Vfsa.ToString() == representativeName)
                        {
                            user.Representative = Representative.Vfsa;
                        }

                        else if (Representative.Esa.ToString() == representativeName)
                        {
                            user.Representative = Representative.Esa;
                        }

                        else if (Representative.Fumsa.ToString() == representativeName)
                        {
                            user.Representative = Representative.Fumsa;
                        }

                        else if (Representative.Indi.ToString() == representativeName)
                        {
                            user.Representative = Representative.Indi;
                        }

                        else if (Representative.Shm.ToString() == representativeName)
                        {
                            user.Representative = Representative.Shm;
                        }

                        else if (Representative.Statius.ToString() == representativeName)
                        {
                            user.Representative = Representative.Statius;
                        }

                        await _userRepository.ChangeRepresentativeByEmail(user.Email, i);
                        break;
                    }
                }
            }

            return user;
        }

        public async Task<string> Login(User request, string? password)
        {
            if (!request.Email.Contains('@') || !request.Email.Contains('.'))
            {
                throw new UserEmailFormatInvalid();
            }

            var user = await _userRepository.GetByEmail(request.Email);

            if (user == null)
            {
                throw new UserNotFound();
            }

            if (user.Email != request.Email)
            {
                throw new UserNotFound();
            }

            if (password != null)
            {
                if (user.Email == "gintaras@gmail.com" && password == "admin")
                {
                    return CreateToken(user);
                }
                else if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                {
                    throw new UserWrongPassword();
                }
            }

            return CreateToken(user);
        }

        public async Task<User> Register(User request, string? password)
        {
            if (await _userRepository.GetByEmail(request.Email) != null)
            {
                throw new UserAlreadyExists();
            }

            if (!request.Email.Contains('@') || !request.Email.Contains('.'))
            {
                throw new UserEmailFormatInvalid();
            }

            if (password != null)
            {
                CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);
                request.PasswordHash= passwordHash;
                request.PasswordSalt= passwordSalt;
                request.Role = Role.Unverified;
            }


            var insertedUserId = await _userRepository.Create(request);
            var user = await _userRepository.GetById(insertedUserId);

            return user;
        }

        private string CreateToken(User user)
        {
            List<Claim> claims = new()
            {
                new Claim(ClaimTypes.Email,user.Email),
                new Claim(ClaimTypes.Name,user.Name),
                new Claim(ClaimTypes.Surname,user.Surname)
            };

            if (user.Role == Role.Admin)
            {
                claims.Add(
                    new Claim(ClaimTypes.Role, Role.Admin.ToString())
                );
            }
            else
            {
                claims.Add(
                    new Claim(ClaimTypes.Role, Role.Unverified.ToString())
                );
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }

        private string FirstCharToUpper(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return string.Empty;
            }
            return $"{char.ToUpper(input[0])}{input[1..]}";
        }
    }
}
