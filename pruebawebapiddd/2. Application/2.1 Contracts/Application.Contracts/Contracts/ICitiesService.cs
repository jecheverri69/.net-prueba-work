using Application.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Contracts
{
    public interface ICitiesService
    {
        ResponseApi GetCities();
    }
}