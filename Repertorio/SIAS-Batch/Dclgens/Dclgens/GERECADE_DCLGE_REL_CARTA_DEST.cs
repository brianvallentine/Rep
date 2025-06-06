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
    public class GERECADE_DCLGE_REL_CARTA_DEST : VarBasis
    {
        /*"    10 GERECADE-NUM-CARTA   PIC S9(9) USAGE COMP.*/
        public IntBasis GERECADE_NUM_CARTA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 GERECADE-COD-DESTINATARIO  PIC S9(4) USAGE COMP.*/
        public IntBasis GERECADE_COD_DESTINATARIO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GERECADE-IND-DEST-PRINC  PIC X(1).*/
        public StringBasis GERECADE_IND_DEST_PRINC { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"*/
    }
}