using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Montaza_Lourd_Wpf.Classes
{

    [Table("entites")]
    public class Entite
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string? Name { get; set; }

        [Column("adresse")]
        public string? Adresse { get; set; }

        [Column("ville")]
        public string? Ville { get; set; }

        [Column("code_postal")]
        public string? CodePostal { get; set; }

        [Column("tel")]
        public string? Tel { get; set; }

        [Column("siret")]
        public string? Siret { get; set; }

        [Column("rcs")]
        public string? Rcs { get; set; }

        [Column("numero_tva")]
        public string? NumeroTva { get; set; }

        [Column("code_ape")]
        public string? CodeApe { get; set; }

        [Column("logo")]
        public string? Logo { get; set; }

        [Column("horaires")]
        public string? Horaires { get; set; }
    }
}
