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
    public class GE537_DCLGE_SOLICITA_AP_CA_SAP_HIST : VarBasis
    {
        /*"    10 GE537-SEQ-AP-CA-SAP-HIST       PIC S9(18) USAGE COMP.*/
        public IntBasis GE537_SEQ_AP_CA_SAP_HIST { get; set; } = new IntBasis(new PIC("S9", "18", "S9(18)"));
        /*"    10 GE537-NUM-OCOR-HIST  PIC S9(4) USAGE COMP.*/
        public IntBasis GE537_NUM_OCOR_HIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GE537-NUM-IDLG       PIC S9(18) USAGE COMP.*/
        public IntBasis GE537_NUM_IDLG { get; set; } = new IntBasis(new PIC("S9", "18", "S9(18)"));
        /*"    10 GE537-COD-LOTE-G     PIC X(24).*/
        public StringBasis GE537_COD_LOTE_G { get; set; } = new StringBasis(new PIC("X", "24", "X(24)."), @"");
        /*"    10 GE537-COD-LOTE-A     PIC X(24).*/
        public StringBasis GE537_COD_LOTE_A { get; set; } = new StringBasis(new PIC("X", "24", "X(24)."), @"");
        /*"    10 GE537-SEQ-REGISTRO-LOTE-A       PIC S9(9) USAGE COMP.*/
        public IntBasis GE537_SEQ_REGISTRO_LOTE_A { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 GE537-SEQ-REGISTRO-LOTE-G       PIC S9(9) USAGE COMP.*/
        public IntBasis GE537_SEQ_REGISTRO_LOTE_G { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 GE537-NUM-NSA-SAP    PIC S9(9) USAGE COMP.*/
        public IntBasis GE537_NUM_NSA_SAP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 GE537-SEQ-REGISTRO   PIC S9(9) USAGE COMP.*/
        public IntBasis GE537_SEQ_REGISTRO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 GE537-COD-TIPO-OCOR  PIC X(2).*/
        public StringBasis GE537_COD_TIPO_OCOR { get; set; } = new StringBasis(new PIC("X", "2", "X(2)."), @"");
        /*"    10 GE537-DTA-MOVIMENTO  PIC X(10).*/
        public StringBasis GE537_DTA_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 GE537-COD-USUARIO    PIC X(8).*/
        public StringBasis GE537_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 GE537-NOM-PROGRAMA   PIC X(30).*/
        public StringBasis GE537_NOM_PROGRAMA { get; set; } = new StringBasis(new PIC("X", "30", "X(30)."), @"");
        /*"    10 GE537-COD-ORIGEM     PIC X(4).*/
        public StringBasis GE537_COD_ORIGEM { get; set; } = new StringBasis(new PIC("X", "4", "X(4)."), @"");
        /*"    10 GE537-DTH-CADASTRAMENTO       PIC X(26).*/
        public StringBasis GE537_DTH_CADASTRAMENTO { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 GE537-COD-MODULO-SAP       PIC X(2).*/
        public StringBasis GE537_COD_MODULO_SAP { get; set; } = new StringBasis(new PIC("X", "2", "X(2)."), @"");
        /*"*/
    }
}