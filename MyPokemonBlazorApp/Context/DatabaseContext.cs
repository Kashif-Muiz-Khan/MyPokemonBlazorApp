using Microsoft.EntityFrameworkCore;
using MyPokemonBlazorApp.Model;


namespace MyPokemonBlazorApp.Context
{
    public class DatabaseContext :DbContext
    {
        private IWebHostEnvironment _environment;

        public DbSet<Pokemon> Pokemons { get; set; }
        public DbSet<Trainer> Trainers { get; set; }



        public DatabaseContext(DbContextOptions<DatabaseContext> options, IWebHostEnvironment environment) : base(options)
        {
            _environment = environment;
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionbuilder)
        {
            var folder = Path.Combine(_environment.WebRootPath, "database");
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
            optionbuilder.UseSqlite($"Data Source={folder}/pokemon.db");
        }
        // This is my Database

    }
}
