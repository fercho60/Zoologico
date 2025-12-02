using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Zoologico_Modelos;

    public class Zoologico_apiContext : DbContext
    {
        public Zoologico_apiContext (DbContextOptions<Zoologico_apiContext> options)
            : base(options)
        {
        }

        public DbSet<Raza> Raza { get; set; } = default!;

public DbSet<Especie> Especie { get; set; } = default!;

    public DbSet<Animal> Animal { get; set; } = default!;
}
