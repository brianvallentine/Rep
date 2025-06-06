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
    public class BILHEERR_DCLBILHETE_ERROS : VarBasis
    {
        /*"    10 BILHEERR-NUM-BILHETE  PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis BILHEERR_NUM_BILHETE { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 BILHEERR-COD-ERRO    PIC S9(4) USAGE COMP.*/
        public IntBasis BILHEERR_COD_ERRO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
    }
}