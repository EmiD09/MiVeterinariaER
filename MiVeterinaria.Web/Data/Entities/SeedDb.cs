using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiVeterinaria.Web.Data.Entities
{
    public class SeedDb
    {
        private readonly DataContext _context;

        public SeedDb(DataContext context)
        {
            _context = context;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckRolesAsync();
            //var administrador = await CheckUserAsync();
            await CheckTipoMascotaAsync();
            await CheckTipoServiciosAsync();
            await CheckPropietariosAsync();
            //await CheckAdministradoresAsync(administrador);
            await CheckMascotasAsync();
            await CheckAgendasAsync();
        }

        private async Task CheckUserAsync()
        {
            throw new NotImplementedException();
        }

        private async Task CheckRolesAsync()
        {

        }
        private async Task CheckTipoServiciosAsync()
        {
            if(!_context.TipoServicios.Any())
            {
                _context.TipoServicios.Add(new TipoServicio { Nombre = "Consulta" });
                _context.TipoServicios.Add(new TipoServicio { Nombre = "Urgencia" });
                _context.TipoServicios.Add(new TipoServicio { Nombre = "Vacunación" });
                await _context.SaveChangesAsync();
            }    
        }
        private async Task CheckTipoMascotaAsync()
        {
            if(!_context.TipoMascotas.Any())
            {
                _context.TipoMascotas.Add(new TipoMascota { Nombre = "Perro" });
                _context.TipoMascotas.Add(new TipoMascota { Nombre = "Gato" });
                await _context.SaveChangesAsync();
            }
        }
        private async Task CheckPropietariosAsync()
        {
            AddPropietario("31234567", "Juan", "Perez", "234 5453", "341 2234456", "Calle San Luis 1345");
            AddPropietario("22234777", "Jose", "Rodriguez", "444 5453", "341 2297456", "Calle San Juan 1845");
            AddPropietario("28234367", "Roberto", "Gomez", "847 5223", "341 2668456", "Calle Mitre 145");
            await _context.SaveChangesAsync();
        }
        private async Task CheckMascotasAsync()
        {
            var propietario = _context.Propietarios.FirstOrDefault();
            var tipoMascota = _context.TipoMascotas.FirstOrDefault();
            if (!_context.Mascotas.Any())
            {
                AddMascota("Otto", propietario, tipoMascota, "Shih tzu");
                AddMascota("Jay", propietario, tipoMascota, "Siames");
                await _context.SaveChangesAsync();
            }    
        }
        private async Task CheckAgendasAsync()
        {
            if(!_context.Agendas.Any())
            {
                var initialDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 8, 0, 0);
                var finalDate = initialDate.AddYears(1);
                while(initialDate < finalDate)
                {
                    if (initialDate.DayOfWeek != DayOfWeek.Sunday)
                    {
                        var finaldate2 = initialDate.AddHours(10);
                        while(initialDate < finaldate2)
                        {
                            _context.Agendas.Add(new Agenda
                            {
                                Fecha = initialDate.ToUniversalTime(),
                                EstaDisponible = true
                            });
                            initialDate = initialDate.AddMinutes(30);
                        }
                        initialDate = initialDate.AddHours(14);
                    }
                    else
                    {
                        initialDate = initialDate.AddDays(1);
                    }
                }
                await _context.SaveChangesAsync();
            }
        }
        private void AddMascota(string name, Propietario propietario, TipoMascota tipoMascota, string race)
        {
            _context.Mascotas.Add(new Mascota
            {
                Nacimiento = DateTime.Now.AddYears(-2),
                Nombre = name,
                Propietario = propietario,
                TipoMascota = tipoMascota,
                Raza = race
            }
            );
        }

        private void AddPropietario(string documento, string nombre, string apellido, string telFijo, string telCelular, string direccion)
        {
            _context.Propietarios.Add(new Propietario
            {
                Direccion = direccion,
                TelCelular = telCelular,
                Documento = documento,
                Nombre = nombre,
                TelFijo = telFijo,
                Apellido = apellido
            });
        }

    }
}
