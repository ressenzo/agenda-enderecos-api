using System.Collections.Generic;
using System.Linq;
using Api.Models;
using AutoMapper;
using Dominio.Entidades;

namespace Api.Mapeamento
{
    public class CepMapeamento : Profile
    {
        public CepMapeamento()
        {
            CreateMap<Cep, RetornoCepModel>()
                .ForMember(dest => dest.Cep, map => map.MapFrom(src => src.Valor));
        }
    }
}
