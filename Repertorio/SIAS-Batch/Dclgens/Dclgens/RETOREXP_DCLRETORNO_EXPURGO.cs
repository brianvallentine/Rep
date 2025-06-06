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
    public class RETOREXP_DCLRETORNO_EXPURGO : VarBasis
    {
        /*"    10 RETOREXP-DATA-SITUACAO-RET  PIC X(10).*/
        public StringBasis RETOREXP_DATA_SITUACAO_RET { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 RETOREXP-NUM-APOLICE  PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis RETOREXP_NUM_APOLICE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 RETOREXP-NUM-ITEM    PIC S9(9) USAGE COMP.*/
        public IntBasis RETOREXP_NUM_ITEM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 RETOREXP-ID-MESTRE-EXPURGO  PIC S9(4) USAGE COMP.*/
        public IntBasis RETOREXP_ID_MESTRE_EXPURGO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 RETOREXP-COD-USUARIO  PIC X(8).*/
        public StringBasis RETOREXP_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 RETOREXP-SITUACAO-RETORNO  PIC S9(4) USAGE COMP.*/
        public IntBasis RETOREXP_SITUACAO_RETORNO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
    }
}