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
    public class PFMOTPRO_DCLPF_MOTIVO_PROPOSTA : VarBasis
    {
        /*"    10 PFMOTPRO-SIT-MOTIVO-SIVPF  PIC S9(9) USAGE COMP.*/
        public IntBasis PFMOTPRO_SIT_MOTIVO_SIVPF { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 PFMOTPRO-DES-MOTIVO-SIVPF  PIC X(100).*/
        public StringBasis PFMOTPRO_DES_MOTIVO_SIVPF { get; set; } = new StringBasis(new PIC("X", "100", "X(100)."), @"");
        /*"*/
    }
}