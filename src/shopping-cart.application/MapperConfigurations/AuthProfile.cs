using AutoMapper;
using shopping_cart.application.Auth.Queries;
using shopping_cart.domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shopping_cart.application.MapperConfigurations
{
    public class AuthProfile : Profile
    {
        public AuthProfile()
        {
            CreateMap<RefreshTokenDto, RefreshToken>();
        }
    }
}
