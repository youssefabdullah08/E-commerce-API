using Store.Data.Entites;
using Store.Serveses.UserService.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Serveses.UserService
{
    public interface IUserService
    {
        Task<UserDTO> login(LoginDTO loginDTO);
        Task<UserDTO> Register(RegsterDTO regsterDTO);
    }
}
