using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PreferenceManagement.API.Domain.Entities
{
    [Index(nameof(Key), nameof(Solution), IsUnique = true)]
    public class PreferenceDefinition
    {
        public Guid Id { get; set; }
        public string Key { get; set; }
        [Column(TypeName = "VARCHAR(50)")]
        public Level Level { get; set; }
        public string? Solution { get; set; }
    }
}
