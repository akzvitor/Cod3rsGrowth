using Cod3rsGrowth.Dominio.Enums;
using LinqToDB.Mapping;

namespace Cod3rsGrowth.Dominio.Entidades
{
    [Table("Obras")]
    public class Obra
    {
        [PrimaryKey, Identity]
        public int Id { get; set; }

        [Column("Título"), NotNull]
        public string Titulo { get; set; }

        [Column("Autor"), NotNull]
        public string Autor { get; set; }
        public List<Genero> Generos { get; set; }
        public string Sinopse { get; set; }
        public string CapaImagemBase64 { get; set; }

        [Column("Número de capítulos"), NotNull]
        public int NumeroCapitulos { get; set; }

        [Column("Valor"), NotNull]
        public decimal ValorObra { get; set; }

        [Column("Formato"), NotNull]
        public Formato Formato { get; set; }

        [Column("Foi finalizada"), NotNull]
        public bool FoiFinalizada { get; set; }

        [Column("Início da Publicação"), NotNull]
        public DateTime InicioPublicacao { get; set; }
    }
}
