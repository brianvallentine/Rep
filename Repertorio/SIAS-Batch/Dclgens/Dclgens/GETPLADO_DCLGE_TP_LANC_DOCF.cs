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
    public class GETPLADO_DCLGE_TP_LANC_DOCF : VarBasis
    {
        /*"    10 GETPLADO-COD-TP-LANCDOCF  PIC S9(4) USAGE COMP.*/
        public IntBasis GETPLADO_COD_TP_LANCDOCF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GETPLADO-DT-INIVIG-LANCDOCF  PIC X(10).*/
        public StringBasis GETPLADO_DT_INIVIG_LANCDOCF { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 GETPLADO-DT-TERVIG-LANCDOCF  PIC X(10).*/
        public StringBasis GETPLADO_DT_TERVIG_LANCDOCF { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 GETPLADO-DESCRICAO-LANCDOCF  PIC X(40).*/
        public StringBasis GETPLADO_DESCRICAO_LANCDOCF { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"    10 GETPLADO-ABREV-LANCDOCF  PIC X(20).*/
        public StringBasis GETPLADO_ABREV_LANCDOCF { get; set; } = new StringBasis(new PIC("X", "20", "X(20)."), @"");
        /*"    10 GETPLADO-COD-USUARIO  PIC X(8).*/
        public StringBasis GETPLADO_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 GETPLADO-TIMESTAMP   PIC X(26).*/
        public StringBasis GETPLADO_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"*/
    }
}