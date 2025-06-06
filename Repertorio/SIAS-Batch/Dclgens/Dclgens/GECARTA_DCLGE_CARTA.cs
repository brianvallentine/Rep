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
    public class GECARTA_DCLGE_CARTA : VarBasis
    {
        /*"    10 GECARTA-NUM-CARTA    PIC S9(9) USAGE COMP.*/
        public IntBasis GECARTA_NUM_CARTA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 GECARTA-NUM-CARTA-REITERA  PIC S9(9) USAGE COMP.*/
        public IntBasis GECARTA_NUM_CARTA_REITERA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 GECARTA-COD-USUARIO  PIC X(8).*/
        public StringBasis GECARTA_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 GECARTA-TIMESTAMP    PIC X(26).*/
        public StringBasis GECARTA_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 GECARTA-STA-ENVIO-CARTA  PIC X(1).*/
        public StringBasis GECARTA_STA_ENVIO_CARTA { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 GECARTA-SEQ-CARTA-REITERA  PIC S9(4) USAGE COMP.*/
        public IntBasis GECARTA_SEQ_CARTA_REITERA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"*/
    }
}