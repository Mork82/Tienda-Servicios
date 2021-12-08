﻿using System;
using System.Collections;

namespace TiendaServicios.Api.CarritoCompra.Modelo
{
    public class CarritoSesionDetalle
    {

        public int carritoSesionDetalleId { get; set; }

        public DateTime? fechaCreacion { get; set;  }

        public string productoSeleccionado { get; set; }

        public CarritoSesion carritoSesion{ get; set; }

        public int carritoSesionId { get; set; }


    }
}
