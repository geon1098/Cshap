using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUD_3.Models
{
    public class Language
    {
        [Column("language_id")]
        public int LanguageId { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("last_update")]
        public DateTime LastUpdate { get; set; }
    }
}
