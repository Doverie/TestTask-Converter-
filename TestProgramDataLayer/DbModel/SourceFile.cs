using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProgramDataLayer.DbModel
{
    public class SourceFile
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public int? BrokerId { get; set; }
        [Required]
        public string OldFilePath { get; set; }
        [Required]
        public string Name { get; set; }

        [ForeignKey("BrokerId")]
        public Broker Brokers { get; set; }

    }
}

