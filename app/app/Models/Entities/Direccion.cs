﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace app.Models.Entities
{
    public class Direccion
    {
        public Direccion()
        {
            Pais = "Venezuela";
        }

        [Key]
        public int Id { get; set; }
        public string Pais { get; set; }
        public string Estado { get; set; }
        public string Ciudad { get; set; }
        public string DireccionLocal { get; set; }
        public string Local { get; set; }           // Nombre del local
        public GoogleMapPoint Position { get; set; }
    }

    public class GoogleMapPoint
    {
        public GoogleMapPoint(float longitud, float latitud)
        {
            this.Longitud = longitud;
            this.Latitud = latitud;
        }

        public float Longitud { get; private set; }
        public float Latitud { get; private set; }
    }
}