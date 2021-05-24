using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Lab.Model
{
    public class CdiscTestCd
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(8)]
        public string Name { get; set; }
    }
}
