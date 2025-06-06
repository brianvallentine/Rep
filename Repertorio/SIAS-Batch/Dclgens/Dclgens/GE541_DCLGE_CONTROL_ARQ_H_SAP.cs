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
    public class GE541_DCLGE_CONTROL_ARQ_H_SAP : VarBasis
    {
        /*"    10 GE541-NUM-NSA-SAP    PIC S9(9) USAGE COMP.*/
        public IntBasis GE541_NUM_NSA_SAP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 GE541-DTA-GERACAO-ARQ       PIC X(10).*/
        public StringBasis GE541_DTA_GERACAO_ARQ { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 GE541-COD-ORIGEM     PIC X(4).*/
        public StringBasis GE541_COD_ORIGEM { get; set; } = new StringBasis(new PIC("X", "4", "X(4)."), @"");
        /*"    10 GE541-QTD-REGISTRO   PIC S9(9) USAGE COMP.*/
        public IntBasis GE541_QTD_REGISTRO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 GE541-NOM-EXTERNO-ARQUIVO       PIC X(50).*/
        public StringBasis GE541_NOM_EXTERNO_ARQUIVO { get; set; } = new StringBasis(new PIC("X", "50", "X(50)."), @"");
        /*"    10 GE541-COD-MODULO-SAP       PIC X(2).*/
        public StringBasis GE541_COD_MODULO_SAP { get; set; } = new StringBasis(new PIC("X", "2", "X(2)."), @"");
        /*"*/
    }
}