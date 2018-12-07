using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProgramDataLayer.DbModel
{
    public class Broker
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BrokerId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string OldBaseFolder { get; set; }
        [Required]
        public string NewBaseFolder { get; set; }

        //public virtual ICollection<SourceFile> sourceFile { get; set; }
        //public virtual ICollection<TargetFile> targetFile { get; set; }
    }
}
