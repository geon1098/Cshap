using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUD_4.Models
{
    public class Language
    {
        public int LanguageId { get; set; }
        public string Name { get; set; }
        public DateTime LastUpdate { get; set; }
    }
}