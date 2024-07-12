using LogUploader.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogUploader.Contracts
{
    public interface IAuthenticationRepository
    {
        public Task<bool> Login(LoginModel user);

    }
}
