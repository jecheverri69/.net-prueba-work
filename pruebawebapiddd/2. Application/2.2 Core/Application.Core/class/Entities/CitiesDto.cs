using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Core
{
    public class CitiesDto
    {
        public int CityId { get; set; }

        public string Name { get; set; }

        public int DepartmentId { get; set; }

        public DepartmentsDto Department { get; set; }
        public Nullable<Decimal> Latitude { get; set; }
        public Nullable<Decimal> Longitude { get; set; }
    }
}