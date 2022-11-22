using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Be7_fs4_uc9.Interfaces
{
    public class Endereco
    {
         public string? logradouro { get; set; }
        
        public int numero { get; set; }
        
        public string? complemento { get; set; }
        
        public bool endComercial  { get; set; }
        
    }
}