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
    public class GEDOCCLI_DCLGE_DOC_CLIENTE : VarBasis
    {
        /*"    10 GEDOCCLI-COD-CLIENTE  PIC S9(9) USAGE COMP.*/
        public IntBasis GEDOCCLI_COD_CLIENTE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 GEDOCCLI-COD-IDENTIFICACAO  PIC X(15).*/
        public StringBasis GEDOCCLI_COD_IDENTIFICACAO { get; set; } = new StringBasis(new PIC("X", "15", "X(15)."), @"");
        /*"    10 GEDOCCLI-NOM-ORGAO-EXP  PIC X(30).*/
        public StringBasis GEDOCCLI_NOM_ORGAO_EXP { get; set; } = new StringBasis(new PIC("X", "30", "X(30)."), @"");
        /*"    10 GEDOCCLI-DTH-EXPEDICAO  PIC X(10).*/
        public StringBasis GEDOCCLI_DTH_EXPEDICAO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 GEDOCCLI-COD-UF      PIC X(2).*/
        public StringBasis GEDOCCLI_COD_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(2)."), @"");
        /*"*/
    }
}