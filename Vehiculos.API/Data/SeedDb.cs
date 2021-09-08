using System.Linq;
using System.Threading.Tasks;
using Vehiculos.API.Data.Entities;

namespace Vehiculos.API.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;

        public SeedDb(DataContext contex)
        {
            _context = contex;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await checkVehiclesTypeAsync();
            await checkDocumentsTypeAsync();
            await checkProceduresAsync();
            await checkBrandsAsync();
        }

        private async Task checkBrandsAsync()
        {
            if (!_context.Brands.Any())
            {
                _context.Brands.Add(new Brand { Description = "Ducati" });
                _context.Brands.Add(new Brand { Description = "Harley Davidson" });
                _context.Brands.Add(new Brand { Description = "KTM" });
                _context.Brands.Add(new Brand { Description = "BMW" });
                _context.Brands.Add(new Brand { Description = "Triumph" });
                _context.Brands.Add(new Brand { Description = "Visctoria" });
                _context.Brands.Add(new Brand { Description = "Honda" });
                _context.Brands.Add(new Brand { Description = "Suzuki" });
                _context.Brands.Add(new Brand { Description = "Kawasaki" });
                _context.Brands.Add(new Brand { Description = "TVS" });
                _context.Brands.Add(new Brand { Description = "Bajaj" });
                _context.Brands.Add(new Brand { Description = "Yamaha" });
                _context.Brands.Add(new Brand { Description = "Chevrolet" });
                _context.Brands.Add(new Brand { Description = "Mazda" });
                _context.Brands.Add(new Brand { Description = "Renault" });
                _context.Brands.Add(new Brand { Description = "Audi" });
                _context.Brands.Add(new Brand { Description = "Mercedez" });
                _context.Brands.Add(new Brand { Description = "Nissan" });
                _context.Brands.Add(new Brand { Description = "Volkswagen" });
                await _context.SaveChangesAsync();
            }
        }

        private async Task checkProceduresAsync()
        {
            if (!_context.Procedures.Any())
            {
                if (!_context.Procedures.Any())
                {
                    _context.Procedures.Add(new Procedure { Price = 10000, Description = "Alineación" });
                    _context.Procedures.Add(new Procedure { Price = 10000, Description = "Lubricación de suspención delantera" });
                    _context.Procedures.Add(new Procedure { Price = 10000, Description = "Lubricación de suspención trasera" });
                    _context.Procedures.Add(new Procedure { Price = 10000, Description = "Frenos delanteros" });
                    _context.Procedures.Add(new Procedure { Price = 10000, Description = "Frenos traseros" });
                    _context.Procedures.Add(new Procedure { Price = 10000, Description = "Líquido frenos delanteros" });
                    _context.Procedures.Add(new Procedure { Price = 10000, Description = "Líquido frenos traseros" });
                    _context.Procedures.Add(new Procedure { Price = 10000, Description = "Calibración de válvulas" });
                    _context.Procedures.Add(new Procedure { Price = 10000, Description = "Alineación carburador" });
                    _context.Procedures.Add(new Procedure { Price = 10000, Description = "Aceite motor" });
                    _context.Procedures.Add(new Procedure { Price = 10000, Description = "Aceite caja" });
                    _context.Procedures.Add(new Procedure { Price = 10000, Description = "Filtro de aire" });
                    _context.Procedures.Add(new Procedure { Price = 10000, Description = "Sistema eléctrico" });
                    _context.Procedures.Add(new Procedure { Price = 10000, Description = "Guayas" });
                    _context.Procedures.Add(new Procedure { Price = 10000, Description = "Cambio llanta delantera" });
                    _context.Procedures.Add(new Procedure { Price = 10000, Description = "Cambio llanta trasera" });
                    _context.Procedures.Add(new Procedure { Price = 10000, Description = "Reparación de motor" });
                    _context.Procedures.Add(new Procedure { Price = 10000, Description = "Kit arrastre" });
                    _context.Procedures.Add(new Procedure { Price = 10000, Description = "Banda transmisión" });
                    _context.Procedures.Add(new Procedure { Price = 10000, Description = "Cambio batería" });
                    _context.Procedures.Add(new Procedure { Price = 10000, Description = "Lavado sistema de inyección" });
                    _context.Procedures.Add(new Procedure { Price = 10000, Description = "Lavada de tanque" });
                    _context.Procedures.Add(new Procedure { Price = 10000, Description = "Cambio de bujia" });
                    _context.Procedures.Add(new Procedure { Price = 10000, Description = "Cambio rodamiento delantero" });
                    _context.Procedures.Add(new Procedure { Price = 10000, Description = "Cambio rodamiento trasero" });
                    _context.Procedures.Add(new Procedure { Price = 10000, Description = "Accesorios" });
                    await _context.SaveChangesAsync();
                }
            }
        }

        private async Task checkDocumentsTypeAsync()
        {
            _context.DocumentTypes.Add(new DocumentType { Description = "Cedula" });
            _context.DocumentTypes.Add(new DocumentType { Description = "Tarjeta de Identidad" });
            _context.DocumentTypes.Add(new DocumentType { Description = "Nit" });
            _context.DocumentTypes.Add(new DocumentType { Description = "Pasaporte" });
            await _context.SaveChangesAsync();
        }

        private async Task checkVehiclesTypeAsync()
        {
            if (!_context.VehiculoTypes.Any())
            {
                _context.VehiculoTypes.Add(new VehiculoType { Description = "Carro" });
                _context.VehiculoTypes.Add(new VehiculoType { Description = "Moto" });
                await _context.SaveChangesAsync();
            }
        }
    }
}
