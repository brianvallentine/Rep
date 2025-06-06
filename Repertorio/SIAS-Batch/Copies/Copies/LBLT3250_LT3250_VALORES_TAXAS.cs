using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Copies
{
    public class LBLT3250_LT3250_VALORES_TAXAS : VarBasis
    {
        /*"      10   LT3250-TAXA                  PIC  9(003)V9(9)*/
        public DoubleBasis LT3250_TAXA { get; set; } = new DoubleBasis(new PIC("9", "3", "9(003)V9(9)"), 9);
        /*"  03       LT3250-TAB-COEFICIENTES*/
    }
}