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
    public class SITIPMOT_DCLSI_TIPO_MOTIVO : VarBasis
    {
        /*"    10 SITIPMOT-COD-TIPO-MOTIVO  PIC S9(4) USAGE COMP.*/
        public IntBasis SITIPMOT_COD_TIPO_MOTIVO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SITIPMOT-COD-GRUPO-MOTIVO  PIC S9(4) USAGE COMP.*/
        public IntBasis SITIPMOT_COD_GRUPO_MOTIVO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SITIPMOT-DES-TIPO-MOTIVO  PIC X(40).*/
        public StringBasis SITIPMOT_DES_TIPO_MOTIVO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
    }
}