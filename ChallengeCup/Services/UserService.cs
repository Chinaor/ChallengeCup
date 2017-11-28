using ChallengeCup.Data;
using ChallengeCup.Models;
using ChallengeCup.Util;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;

namespace ChallengeCup.Services
{
    public class UserService
    {

        private readonly ChallengeCupDbContext context;

        private readonly ILogger<UserService> logger;

        PasswordHasher<User> hasher;
        public UserService(ChallengeCupDbContext context,
            ILogger<UserService> logger)
        {
            hasher = new PasswordHasher<User>();
            this.context = context;
            this.logger = logger;
        }

        public User GetUserByUsername(string username)=> context.User.SingleOrDefault(user => user.Username == username);

        public bool VertifyPassword(User user)
        {
            var userInDb = GetUserByUsername(user.Username);

            var result = hasher.VerifyHashedPassword(user, userInDb.Password, user.Password);

            if (result == PasswordVerificationResult.Success)
                return true;
            else
                return false;
        }

        public string Login(User user)
        {
            if (!IsUserExist(user)||string.IsNullOrWhiteSpace(user.Username))
            {
                return "用户名不存在";
            }
            
            var result=VertifyPassword(user);

            if (result)
            {
                logger.LogDebug("用户 {}  登陆成功", user.Username);
                //登陆成功
                return "success";
                
            }
            else
            {
                logger.LogDebug("用户 {}  用户名或密码错误", user.Username);
                //登陆失败
                return "用户名或密码错误";
            }

        }

        public bool IsUserExist(User user)
        {
            var userInDb = GetUserByUsername(user.Username);

            if (userInDb == null)
            {
                logger.LogDebug("用户不存在");
                return false;
            }
            else
            {
                logger.LogDebug("用户存在");
                return true;
            }
        }

        public async Task<string> AddUserAsync(User user)
        {
            var userInDb = GetUserByUsername(user.Username);

            if (userInDb != null)
            {
                logger.LogDebug("用户：{} 已存在", user.Username);
                return "用户名已存在";
            }

            user.Password = hasher.HashPassword(user,user.Password);

            await context.User.AddAsync(user);
            await context.SaveChangesAsync();
            logger.LogDebug("用户：{} 注册成功", user.Username);

            return "success";
        }
      
    }
}
