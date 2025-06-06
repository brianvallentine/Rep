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
    public class GE102_GE102_TXT_REG_SAP : VarBasis
    {
        /*"       49 GE102-TXT-REG-SAP-LEN          PIC S9(4) USAGE COMP.*/
        public IntBasis GE102_TXT_REG_SAP_LEN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"       49 GE102-TXT-REG-SAP-TEXT          PIC X(4834).*/
        public StringBasis GE102_TXT_REG_SAP_TEXT { get; set; } = new StringBasis(new PIC("X", "4834", "X(4834)."), @"");
        /*"    10 GE102-NUM-OCORR-MOVTO       PIC S9(18)V USAGE COMP-3.*/
    }
}