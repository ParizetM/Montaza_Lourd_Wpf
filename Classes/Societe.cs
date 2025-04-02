using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Montaza_Lourd_Wpf.Classes
{
    [Table("societes")]
    public class Societe
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }


        public string? RaisonSociale { get; set; }

        [Column("siren")]
        public int Siren { get; set; }

        [Column("forme_juridique_id")]
        public int FormeJuridiqueId { get; set; }

        [Column("Code_ape_id")]
        public int CodeApeId { get; set; }

        [Column("societe_type_id")]
        public int SocieteTypeId { get; set; }

        [Column("telephone")]
        public string? Telephone { get; set; }

        [Column("email")]
        public string? Email { get; set; }

        [Column("site_web")]
        public string? SiteWeb { get; set; }

        [Column("numero_tva")]
        public string? NumeroTva { get; set; }

        [Column("condition_paiement_id")]
        public int ConditionPaiementId { get; set; }

        [Column("commentaire_id")]
        public int? CommentaireId { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [Column("deleted_at")]
        public DateTime? DeletedAt { get; set; }
    }
}
