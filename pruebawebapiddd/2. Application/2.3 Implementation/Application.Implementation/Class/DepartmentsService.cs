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
    public class DepartmentsService : IDepartmentsService
    {
        private readonly IDepartmentsRepository _IDepartmentsRepository;
        private readonly IMapper _mapper;

        public DepartmentsService(IDepartmentsRepository _IDepartmentsRepository, IMapper _mapper)
        { 
            this._IDepartmentsRepository = _IDepartmentsRepository;
            this._mapper = _mapper;
        }

        public ResponseApi GetDepartments()
        {
            try
            {
                List<Departments> lstDepartments = _IDepartmentsRepository.GetAll().ToList();
                List<DepartmentsDto> lstDepartmentsDto = _mapper.Map<List<Departments>, List<DepartmentsDto>>(lstDepartments);

                return new ResponseApi
                {
                    ResponseType = "Success",
                    ResponseStatus = true,
                    ResponseObject = lstDepartmentsDto
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