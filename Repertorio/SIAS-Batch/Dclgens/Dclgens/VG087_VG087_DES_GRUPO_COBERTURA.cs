using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Dclgens
{
    public class VG087_VG087_DES_GRUPO_COBERTURA : VarBasis
    {
        /*"       49 VG087-DES-GRUPO-COBERTURA-LEN          PIC S9(4) USAGE COMP.*/
        public IntBasis VG087_DES_GRUPO_COBERTURA_LEN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"       49 VG087-DES-GRUPO-COBERTURA-TEXT          PIC X(500).*/
        public StringBasis VG087_DES_GRUPO_COBERTURA_TEXT { get; set; } = new StringBasis(new PIC("X", "500", "X(500)."), @"");
        /*"    10 VG087-IND-CONJUGE    PIC X(1).*/
    }
}