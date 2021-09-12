﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using Vehiculos.API.Data;

namespace Vehiculos.API.Helpers
{
    public class CombosHelper : ICombosHelper
    {
        private readonly DataContext _context;

        public CombosHelper(DataContext context)
        {
            _context = context;
        }

        public DataContext Context { get; }

        public IEnumerable<SelectListItem> GetComboBrands()
        {
            List<SelectListItem> list = _context.Brands.Select(x => new SelectListItem
            {
                Text = x.Description,
                Value = $"{x.Id}"
            }).OrderBy(x => x.Text).ToList();
            list.Insert(0, new SelectListItem
            {
                Text = "[Seleccione una marca...]",
                Value = "0"
            });
            return list;
        }

        public IEnumerable<SelectListItem> GetComboDocumentTypes()
        {
            List<SelectListItem> list = _context.DocumentTypes.Select(x => new SelectListItem
            {
                Text = x.Description,
                Value = $"{x.Id}"
            }).OrderBy(x => x.Text).ToList();
            list.Insert(0, new SelectListItem
            {
                Text = "[Seleccione un tipo de documento...]",
                Value = "0"
            });
            return list;
        }

        public IEnumerable<SelectListItem> GetComboProcedures()
        {
            List<SelectListItem> list = _context.Procedures.Select(x => new SelectListItem
            {
                Text = x.Description,
                Value = $"{x.Id}"
            }).OrderBy(x => x.Text).ToList();
            list.Insert(0, new SelectListItem
            {
                Text = "[Seleccione un procedimiento...]",
                Value = "0"
            });
            return list;
        }

        public IEnumerable<SelectListItem> GetComboVehicleTypes()
        {
            List<SelectListItem> list = _context.VehiculoTypes.Select(x => new SelectListItem
            {
                Text = x.Description,
                Value = $"{x.Id}"
            }).OrderBy(x => x.Text).ToList();
            list.Insert(0, new SelectListItem
            {
                Text = "[Seleccione un tipo de vehiculo...]",
                Value = "0"
            });
            return list;
        }
    }
}
