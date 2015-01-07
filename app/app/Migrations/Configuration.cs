namespace app.Migrations
{
    using app.Models;
    using app.Models.Entities;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<app.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(app.Models.ApplicationDbContext context)
        {
            if (context.Registros.Count() > 0)
                return;

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
                context.Registros.Add(p);

            var store = new UserStore<ApplicationUser>(context);
            var manager = new UserManager<ApplicationUser>(store);
            var user = new ApplicationUser { UserName = "admin" };

            manager.Create(user, "admin12");
        }
    }
}
