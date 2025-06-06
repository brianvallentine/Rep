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
    public class GE104_DCLGE_ERROS_SAP : VarBasis
    {
        /*"    10 GE104-COD-ERRO       PIC S9(9) USAGE COMP.*/
        public IntBasis GE104_COD_ERRO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 GE104-DES-ERRO       PIC X(220).*/
        public StringBasis GE104_DES_ERRO { get; set; } = new StringBasis(new PIC("X", "220", "X(220)."), @"");
        /*"    10 GE104-COD-ERRO-SAP   PIC S9(9) USAGE COMP.*/
        public IntBasis GE104_COD_ERRO_SAP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"*/
    }
}