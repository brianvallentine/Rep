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
    public class GEDESCLA_DCLGE_DESTINAT_CLASSE : VarBasis
    {
        /*"    10 GEDESCLA-COD-CLASSE  PIC S9(4) USAGE COMP.*/
        public IntBasis GEDESCLA_COD_CLASSE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GEDESCLA-TIPO-DESTINATARIO  PIC S9(4) USAGE COMP.*/
        public IntBasis GEDESCLA_TIPO_DESTINATARIO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GEDESCLA-COD-DESTINATARIO  PIC S9(4) USAGE COMP.*/
        public IntBasis GEDESCLA_COD_DESTINATARIO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GEDESCLA-COD-USUARIO  PIC X(8).*/
        public StringBasis GEDESCLA_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 GEDESCLA-TIMESTAMP   PIC X(26).*/
        public StringBasis GEDESCLA_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"*/
    }
}