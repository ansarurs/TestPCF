using System;
using System.Linq;
using System.Threading.Tasks;

namespace PCF_POC
{
    public class Service
    {
        private readonly MyDbContext _context;
        public Service()
        {
            _context = new MyDbContext();
        }

        /// <summary>
        /// Validates user credentials
        /// </summary>
        /// <param name="userData"></param>
        /// <returns></returns>
        public async Task<bool> ValidateUser(UserModel userData)
        {
            var result = false;            
            try
            {
                await Task.Delay(0);

                result =  _context.TblUsers.ToList().Any(x => x.Username.Equals(userData.Username, StringComparison.OrdinalIgnoreCase) && x.Password.Equals(userData.Password, StringComparison.OrdinalIgnoreCase));
            }
            catch (Exception ex)
            {
                throw;
            }
            return result;
        }
    }
}
