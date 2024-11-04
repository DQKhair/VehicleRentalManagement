using Microsoft.EntityFrameworkCore;
using ProjectQLThueXe.Domain.Entities;
using ProjectQLThueXe.Domain.Interfaces;
using ProjectQLThueXe.Infrastructure.DBContext;
using Bcr = BCrypt.Net.BCrypt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectQLThueXe.Infrastructure.Repositories
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private readonly MyDBContext _context;
        public AuthenticationRepository(MyDBContext context)
        {
            _context = context;
        }
        public async Task<KT> LoginUserAsync(string phoneNumber, string password)
        {
            var _kt = await _context.KTs.SingleOrDefaultAsync(e => e.KT_Phone == phoneNumber);
            if (_kt != null)
            {
                bool _checkPass = Bcr.Verify(password, _kt.Password);
                if(_checkPass)
                {
                    return _kt;
                }    
            }
            return null!;
        }
    }
}
