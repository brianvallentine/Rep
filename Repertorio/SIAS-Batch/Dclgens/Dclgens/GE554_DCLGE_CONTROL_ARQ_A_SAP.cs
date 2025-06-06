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
    public class GE554_DCLGE_CONTROL_ARQ_A_SAP : VarBasis
    {
        /*"    10 GE554-COD-LOTE-A     PIC X(24).*/
        public StringBasis GE554_COD_LOTE_A { get; set; } = new StringBasis(new PIC("X", "24", "X(24)."), @"");
        /*"    10 GE554-COD-ORIGEM     PIC X(4).*/
        public StringBasis GE554_COD_ORIGEM { get; set; } = new StringBasis(new PIC("X", "4", "X(4)."), @"");
        /*"    10 GE554-DTA-GERACAO-ARQ       PIC X(10).*/
        public StringBasis GE554_DTA_GERACAO_ARQ { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 GE554-VLR-TOTAL      PIC S9(16)V9(2) USAGE COMP-3.*/
        public DoubleBasis GE554_VLR_TOTAL { get; set; } = new DoubleBasis(new PIC("S9", "16", "S9(16)V9(2)"), 2);
        /*"    10 GE554-QTD-REGISTRO   PIC S9(9) USAGE COMP.*/
        public IntBasis GE554_QTD_REGISTRO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 GE554-NOM-EXTERNO-ARQUIVO       PIC X(50).*/
        public StringBasis GE554_NOM_EXTERNO_ARQUIVO { get; set; } = new StringBasis(new PIC("X", "50", "X(50)."), @"");
        /*"*/
    }
}