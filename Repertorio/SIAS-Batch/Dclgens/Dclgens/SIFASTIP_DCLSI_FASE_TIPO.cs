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
    public class SIFASTIP_DCLSI_FASE_TIPO : VarBasis
    {
        /*"    10 SIFASTIP-COD-FASE    PIC S9(4) USAGE COMP.*/
        public IntBasis SIFASTIP_COD_FASE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SIFASTIP-DESCR-FASE  PIC X(30).*/
        public StringBasis SIFASTIP_DESCR_FASE { get; set; } = new StringBasis(new PIC("X", "30", "X(30)."), @"");
        /*"    10 SIFASTIP-SIGLA-FASE  PIC X(12).*/
        public StringBasis SIFASTIP_SIGLA_FASE { get; set; } = new StringBasis(new PIC("X", "12", "X(12)."), @"");
        /*"    10 SIFASTIP-COD-USUARIO  PIC X(8).*/
        public StringBasis SIFASTIP_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 SIFASTIP-TIMESTAMP   PIC X(26).*/
        public StringBasis SIFASTIP_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"*/
    }
}