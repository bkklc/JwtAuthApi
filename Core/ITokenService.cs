using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public interface ITokenService
    {
        string CreateToken(int userId, string email, string firstName, string lastName);
    }
}
