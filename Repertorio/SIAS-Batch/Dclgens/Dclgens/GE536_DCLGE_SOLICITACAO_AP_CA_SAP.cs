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
    public class GE536_DCLGE_SOLICITACAO_AP_CA_SAP : VarBasis
    {
        /*"    10 GE536-NUM-IDLG       PIC S9(18) USAGE COMP.*/
        public IntBasis GE536_NUM_IDLG { get; set; } = new IntBasis(new PIC("S9", "18", "S9(18)"));
        /*"    10 GE536-COD-EMPRESA    PIC X(4).*/
        public StringBasis GE536_COD_EMPRESA { get; set; } = new StringBasis(new PIC("X", "4", "X(4)."), @"");
        /*"    10 GE536-COD-SISTEMA    PIC X(2).*/
        public StringBasis GE536_COD_SISTEMA { get; set; } = new StringBasis(new PIC("X", "2", "X(2)."), @"");
        /*"    10 GE536-COD-MODULO     PIC X(2).*/
        public StringBasis GE536_COD_MODULO { get; set; } = new StringBasis(new PIC("X", "2", "X(2)."), @"");
        /*"    10 GE536-COD-ORIGEM     PIC X(4).*/
        public StringBasis GE536_COD_ORIGEM { get; set; } = new StringBasis(new PIC("X", "4", "X(4)."), @"");
        /*"    10 GE536-COD-EVENTO     PIC X(10).*/
        public StringBasis GE536_COD_EVENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 GE536-COD-CHAVE-NEGOCIO       PIC X(40).*/
        public StringBasis GE536_COD_CHAVE_NEGOCIO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"    10 GE536-COD-ULTIMO-TIPO-OCOR       PIC X(2).*/
        public StringBasis GE536_COD_ULTIMO_TIPO_OCOR { get; set; } = new StringBasis(new PIC("X", "2", "X(2)."), @"");
        /*"*/
    }
}