using ProjectQLThueXe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectQLThueXe.Domain.Interfaces
{
    public interface IAuthenticationRepository
    {
        public Task<KT> LoginUserAsync(string phoneNumber, string password);
    }
}
