using FlixUp.API.Models;

namespace FlixUp.API.Data
{
    public static class DbSeeder
    {
        public static void Seed(ApplicationDbContext db)
        {
            if (!db.Usuarios.Any())
            {
                db.Usuarios.AddRange(
                    new Usuario { Nome = "Admin", Email = "admin@flixup.com", SenhaHash = "123456", Papel = "Admin" },
                    new Usuario { Nome = "Criador", Email = "criador@flixup.com", SenhaHash = "123456", Papel = "Criador" },
                    new Usuario { Nome = "Cliente", Email = "cliente@flixup.com", SenhaHash = "123456", Papel = "Cliente" }
                );
                db.SaveChanges();
            }

            if (!db.Criadores.Any())
            {
                var criador = new Criador { Nome = "Studio X" };
                db.Criadores.Add(criador);
                db.SaveChanges();

                db.Conteudos.AddRange(
                    new Conteudo { Titulo = "Trailer 1", Tipo = "Video", CriadorID = criador.ID },
                    new Conteudo { Titulo = "Episódio 1", Tipo = "Video", CriadorID = criador.ID }
                );
                db.SaveChanges();
            }
        }
    }
}
