using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using PingPong.DataContract;
using DataBaseAccess.Domain;

namespace PingPong.WebAPI.AutoMapper
{
   public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Player, PlayerDTO>();
        }

    }
}