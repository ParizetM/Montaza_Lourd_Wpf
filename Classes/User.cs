using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Montaza_Lourd_Wpf.Classes
{
    [Table("users")]
    public class User
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("first_name")]
        public string? FirstName { get; set; }

        [Column("last_name")]
        public string? LastName { get; set; }

        public string FullName => $"{FirstName} {LastName}";

        [Column("email")]
        public string? Email { get; set; }

        [Column("email_verified_at")]
        public DateTime? EmailVerifiedAt { get; set; }

        [Column("password")]
        public string? Password { get; set; }

        [Column("remember_token")]
        public string? RememberToken { get; set; }

        [Column("phone")]
        public string? Phone { get; set; }

        [Column("role_id")]
        public int RoleId { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [Column("deleted_at")]
        public DateTime? DeletedAt { get; set; }

        public string? RoleNom
        {
            get
            {
                using (var context = new AppDbContext())
                {
                    var role = context.Roles.FirstOrDefault(r => r.Id == RoleId);
                    return role?.Name;
                }
            }
        }
        public string? EntiteNom
        {
            get
            {
                using (var context = new AppDbContext())
                {
                    var role = context.Roles.FirstOrDefault(r => r.Id == RoleId);
                    if (role != null)
                    {
                        var entite = context.Entites.FirstOrDefault(e => e.Id == role.EntiteId);
                        return entite?.Name;
                    }
                    return "erreur de chargement";
                }
            }
        }
    }
}
