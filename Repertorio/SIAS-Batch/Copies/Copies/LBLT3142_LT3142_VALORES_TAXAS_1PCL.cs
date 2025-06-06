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
    public class LBLT3142_LT3142_VALORES_TAXAS_1PCL : VarBasis
    {
        /*"      10   LT3142-TAXA-1PCL             PIC  9(003)V9(9)*/
        public DoubleBasis LT3142_TAXA_1PCL { get; set; } = new DoubleBasis(new PIC("9", "3", "9(003)V9(9)"), 9);
        /*"  03       LT3142-DISPLAY               PIC  X(001)*/
    }
}