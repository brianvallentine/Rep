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
    public class SINISACO_SINISACO_DES_OCORR_TEC : VarBasis
    {
        /*"       49 SINISACO-DES-OCORR-TEC-LEN          PIC S9(4) USAGE COMP.*/
        public IntBasis SINISACO_DES_OCORR_TEC_LEN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"       49 SINISACO-DES-OCORR-TEC-TEXT          PIC X(400).*/
        public StringBasis SINISACO_DES_OCORR_TEC_TEXT { get; set; } = new StringBasis(new PIC("X", "400", "X(400)."), @"");
        /*"*/
    }
}