﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vehiculos.API.Data.Entities;
using Vehiculos.API.Models;

namespace Vehiculos.API.Helpers
{
    public interface IConverterHelper
    {
        Task<User> ToUserAsync(UserViewModel model, Guid imageId, bool isNew);

        UserViewModel ToUserViewModel(User user);

        //Task<Vehicle> ToVehicleAsync(VehicleViewModel model, bool isNew);

        //VehicleViewModel ToVehicleViewModel(Vehicle vehicle);

        //Task<Detail> ToDetailAsync(DetailViewModel model, bool isNew);

        //DetailViewModel ToDetailViewModel(Detail detail);
    }
}
