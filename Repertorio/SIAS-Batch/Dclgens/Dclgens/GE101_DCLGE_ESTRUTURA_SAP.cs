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
    public class GE101_DCLGE_ESTRUTURA_SAP : VarBasis
    {
        /*"    10 GE101-NUM-ESTRUTURA  PIC S9(4) USAGE COMP.*/
        public IntBasis GE101_NUM_ESTRUTURA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GE101-DES-ESTRUTURA  PIC X(100).*/
        public StringBasis GE101_DES_ESTRUTURA { get; set; } = new StringBasis(new PIC("X", "100", "X(100)."), @"");
        /*"    10 GE101-DTH-INI-VIGENCIA       PIC X(10).*/
        public StringBasis GE101_DTH_INI_VIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 GE101-DTH-FIM-VIGENCIA       PIC X(10).*/
        public StringBasis GE101_DTH_FIM_VIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 GE101-DTH-CADASTRAMENTO       PIC X(8).*/
        public StringBasis GE101_DTH_CADASTRAMENTO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"*/
    }
}