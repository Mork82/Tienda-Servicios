﻿using System;

namespace TiendaServicios.Api.Autor.Modelo
{
    public class AutorDTO
    {    

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public DateTime? FechaNacimiento { get; set; } 

        public string AutorLibroGuid { get; set; }


    }
}
