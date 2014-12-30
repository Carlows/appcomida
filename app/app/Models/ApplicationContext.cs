using app.Models.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.Data.Entity;

namespace app.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
            Database.SetInitializer<ApplicationDbContext>(new AppInitializer());
        }

        public DbSet<Registro> Registros { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Registro>()
                .HasRequired(x => x.Producto)
                .WithRequiredPrincipal();

            modelBuilder.Entity<Registro>()
                .HasRequired(x => x.Direccion)
                .WithRequiredPrincipal();

            base.OnModelCreating(modelBuilder);
        }

    }

    public class AppInitializer : DropCreateDatabaseAlways<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext db)
        {
            List<Registro> registros = new List<Registro>
            {
                new Registro { Producto = new Producto { Nombre = "Harina Pan", Precio = 120, Regulado = false }, Direccion = new Direccion { Estado = "Carabobo", Ciudad = "Valencia", Local = "Farmatodo", DireccionLocal = "Sector 1 lorem ipsumSector 1 lorem ipsumSector 1 lorem ipsumSector 1 lorem ipsumSector 1 lorem ipsum", Position = new GoogleMapPoint { Latitud = 9.82743f, Longitud = -68.24695f } }},
                new Registro { Producto = new Producto { Nombre = "Harina Pannn nnn", Precio = 1200, Regulado = true }, Direccion = new Direccion { Estado = "Carabobo", Ciudad = "Guacara", Local = "SAS", DireccionLocal = "Sector 1 lorem ipsumSector 1 lorem ipsumSector 1 lorem ipsumSector 1 lorem ipsumSector 1 lorem ipsum", Position = new GoogleMapPoint { Latitud = 2.0f, Longitud = 2.0f } }},
                new Registro { Producto = new Producto { Nombre = "Harinas adasd sadsa dsadas Pan", Precio = 12000, Regulado = false }, Direccion = new Direccion { Estado = "Carabobo", Ciudad = "San Diego", Local = "Bicentenario", DireccionLocal = "Sector 3 lorem ipsumSector 1 lorem ipsumSector 1 lorem ipsumSector 1 lorem ipsumSector 1 lorem ipsumSector 1 lorem ipsum", Position = new GoogleMapPoint { Latitud = 2.0f, Longitud = 2.0f } }},
                new Registro { Producto = new Producto { Nombre = "Harina asdsa dadsadas dsaPan", Precio = 120000, Regulado = false }, Direccion = new Direccion { Estado = "Carabobo", Ciudad = "Valencia", Local = "Farmatodo", DireccionLocal = "Sector 1 lorem ipsum", Position = new GoogleMapPoint { Latitud = 2.0f, Longitud = 2.0f } }},
                new Registro { Producto = new Producto { Nombre = "Harina Pan", Precio = 1200000, Regulado = true }, Direccion = new Direccion { Estado = "Carabobo", Ciudad = "Guacara", Local = "SAS", DireccionLocal = "Sector 2 lorem ipsum", Position = new GoogleMapPoint { Latitud = 2.0f, Longitud = 2.0f } }},
                new Registro { Producto = new Producto { Nombre = "Harina Pan", Precio = 1200, Regulado = true }, Direccion = new Direccion { Estado = "Carabobo", Ciudad = "San Diego", Local = "Bicentenario", DireccionLocal = "Sector 3 lorem ipsum", Position = new GoogleMapPoint { Latitud = 2.0f, Longitud = 2.0f } }},
                new Registro { Producto = new Producto { Nombre = "Harina Pan", Precio = 1200, Regulado = false }, Direccion = new Direccion { Estado = "Carabobo", Ciudad = "Valencia", Local = "Farmatodo", DireccionLocal = "Sector 1 lorem ipsum", Position = new GoogleMapPoint { Latitud = 2.0f, Longitud = 2.0f } }},
                new Registro { Producto = new Producto { Nombre = "Harina Pan", Precio = 1200, Regulado = false }, Direccion = new Direccion { Estado = "Carabobo", Ciudad = "Guacara", Local = "SAS", DireccionLocal = "Sector 2 lorem ipsum", Position = new GoogleMapPoint { Latitud = 2.0f, Longitud = 2.0f } }},
                new Registro { Producto = new Producto { Nombre = "Harina Pan", Precio = 1200, Regulado = false }, Direccion = new Direccion { Estado = "Carabobo", Ciudad = "San Diego", Local = "Bicentenario", DireccionLocal = "Sector 3 lorem ipsum", Position = new GoogleMapPoint { Latitud = 2.0f, Longitud = 2.0f } }},
                new Registro { Producto = new Producto { Nombre = "Harina Pan", Precio = 120, Regulado = false }, Direccion = new Direccion { Estado = "Carabobo", Ciudad = "Valencia", Local = "Farmatodo", DireccionLocal = "Sector 1 lorem ipsum", Position = new GoogleMapPoint { Latitud = 2.0f, Longitud = 2.0f } }},
                new Registro { Producto = new Producto { Nombre = "Harina Pan", Precio = 120, Regulado = true }, Direccion = new Direccion { Estado = "Carabobo", Ciudad = "Guacara", Local = "SAS", DireccionLocal = "Sector 2 lorem ipsum", Position = new GoogleMapPoint { Latitud = 2.0f, Longitud = 2.0f } }},
                new Registro { Producto = new Producto { Nombre = "Harina Pan", Precio = 120, Regulado = false }, Direccion = new Direccion { Estado = "Carabobo", Ciudad = "San Diego", Local = "Bicentenario", DireccionLocal = "Sector 3 lorem ipsum", Position = new GoogleMapPoint { Latitud = 2.0f, Longitud = 2.0f } }},
                new Registro { Producto = new Producto { Nombre = "Harina Pan", Precio = 12000, Regulado = false }, Direccion = new Direccion { Estado = "Carabobo", Ciudad = "Valencia", Local = "Farmatodo", DireccionLocal = "Sector 1 lorem ipsum", Position = new GoogleMapPoint { Latitud = 2.0f, Longitud = 2.0f } }},
                new Registro { Producto = new Producto { Nombre = "Harina Pan", Precio = 1200000, Regulado = true }, Direccion = new Direccion { Estado = "Carabobo", Ciudad = "Guacara", Local = "SAS", DireccionLocal = "Sector 2 lorem ipsum", Position = new GoogleMapPoint { Latitud = 2.0f, Longitud = 2.0f } }},
                new Registro { Producto = new Producto { Nombre = "Harina Pan", Precio = 12000000, Regulado = true }, Direccion = new Direccion { Estado = "Carabobo", Ciudad = "San Diego", Local = "Bicentenario", DireccionLocal = "Sector 3 lorem ipsum", Position = new GoogleMapPoint { Latitud = 2.0f, Longitud = 2.0f } }},
                new Registro { Producto = new Producto { Nombre = "Harina Pan", Precio = 120, Regulado = false }, Direccion = new Direccion { Estado = "Carabobo", Ciudad = "Valencia", Local = "Farmatodo", DireccionLocal = "Sector 1 lorem ipsum", Position = new GoogleMapPoint { Latitud = 2.0f, Longitud = 2.0f } }},
                new Registro { Producto = new Producto { Nombre = "Harina Pan", Precio = 120, Regulado = true }, Direccion = new Direccion { Estado = "Carabobo", Ciudad = "Guacara", Local = "SAS", DireccionLocal = "Sector 2 lorem ipsum", Position = new GoogleMapPoint { Latitud = 2.0f, Longitud = 2.0f } }},
                new Registro { Producto = new Producto { Nombre = "Harina Pan", Precio = 120, Regulado = false }, Direccion = new Direccion { Estado = "Carabobo", Ciudad = "San Diego", Local = "Bicentenario", DireccionLocal = "Sector 3 lorem ipsum", Position = new GoogleMapPoint { Latitud = 2.0f, Longitud = 2.0f } }},
            };

            foreach (Registro p in registros)
                db.Registros.Add(p);

            base.Seed(db);
        }
    }
}