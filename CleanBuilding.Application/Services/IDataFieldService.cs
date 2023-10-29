﻿using CleanBuilding.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanBuilding.Application.Services
{
    public interface IDataFieldService
    {
        Task<IList<DataFieldDTO>> GetDataFieldData();
    }
}
