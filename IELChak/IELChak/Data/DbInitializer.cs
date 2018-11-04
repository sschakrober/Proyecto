using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IELChak.Models;

namespace IELChak.Data
{
    public class DbInitializer
    {
        public static void Initializer (IELChakContext context)
        {
            context.Database.EnsureCreated();
            if(context.Categoria.Any())
            {
                return;
            }

            var categorias = new Categoria[]
            {
                new Categoria {Nombre="Programacion", Descripcion="Curso de Programacion", Estado = true},
                new Categoria {Nombre="Diseño Grafico", Descripcion="Curso de Diseño Grafico", Estado = true},
                new Categoria {Nombre="Juegos 3D", Descripcion="Curso de Plataforma de Video Juegos", Estado = true},
                new Categoria {Nombre="Office", Descripcion="Paquete Office", Estado = true}
            };

            foreach(Categoria c in categorias)
            {
                context.Categoria.Add(c);
            }
            context.SaveChanges();
        }
    }
}
