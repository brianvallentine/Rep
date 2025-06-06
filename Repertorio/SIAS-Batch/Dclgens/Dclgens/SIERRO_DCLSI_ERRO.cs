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
    public class SIERRO_DCLSI_ERRO : VarBasis
    {
        /*"    10 SIERRO-COD-ERRO      PIC S9(4) USAGE COMP.*/
        public IntBasis SIERRO_COD_ERRO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SIERRO-DES-ERRO      PIC X(100).*/
        public StringBasis SIERRO_DES_ERRO { get; set; } = new StringBasis(new PIC("X", "100", "X(100)."), @"");
    }
}