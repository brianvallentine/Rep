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
    public class GE372_DCLGE_OPER_CREDITO : VarBasis
    {
        /*"    10 GE372-COD-OPER-CREDITO       PIC S9(4) USAGE COMP.*/
        public IntBasis GE372_COD_OPER_CREDITO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GE372-DES-OPER-CREDITO       PIC X(30).*/
        public StringBasis GE372_DES_OPER_CREDITO { get; set; } = new StringBasis(new PIC("X", "30", "X(30)."), @"");
        /*"    10 GE372-DTH-CADASTRAMENTO       PIC X(26).*/
        public StringBasis GE372_DTH_CADASTRAMENTO { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"*/
    }
}