using Application.Contracts;
using Application.Core;
using AutoMapper;
using Domain.Contracts;
using Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Application.Implementation
{
    public class CitiesService : ICitiesService
    {
        private readonly ICitiesRepository _ICitiesRepository;
        private readonly IMapper _mapper;

        public CitiesService(ICitiesRepository _ICitiesRepository, IMapper _mapper)
        { 
            this._ICitiesRepository = _ICitiesRepository;
            this._mapper = _mapper;
        }

        public ResponseApi GetCities()
        {
            try
            {
                List<Cities> lstCities = _ICitiesRepository.GetAll().ToList();
                List<CitiesDto> lstCitiesDto = _mapper.Map<List<Cities>, List<CitiesDto>>(lstCities);

                return new ResponseApi
                {
                    ResponseType = "Success",
                    ResponseStatus = true,
                    ResponseObject = lstCitiesDto
                };
            }
            catch (Exception Ex)
            {
                while (Ex.InnerException != null)
                {
                    Ex = Ex.InnerException;
                }
                return new ResponseApi {
                    ResponseStatus = false,
                    ResponseMessage = Ex.Message,
                    ResponseType = "Error"
                };
            }
        }

    }
}