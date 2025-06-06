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
    public class LBLT2118_LT2118S_SAIDA_ERRO : VarBasis
    {
        /*"    10   LT2118S-COD-RETORNO           PIC  9(002)*/
        public IntBasis LT2118S_COD_RETORNO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
        /*"    10   LT2118S-MSG-RETORNO           PIC  X(070)*/
        public StringBasis LT2118S_MSG_RETORNO { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"");
        /*"  05  LT2118S-PCT-DESC-FIDEL-INFO   PIC S9(03)V9(02) COMP-3*/
    }
}