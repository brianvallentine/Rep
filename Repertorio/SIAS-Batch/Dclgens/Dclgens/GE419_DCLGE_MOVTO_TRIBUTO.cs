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
    public class GE419_DCLGE_MOVTO_TRIBUTO : VarBasis
    {
        /*"    10 GE419-NUM-ID-ENVIO   PIC S9(18) USAGE COMP.*/
        public IntBasis GE419_NUM_ID_ENVIO { get; set; } = new IntBasis(new PIC("S9", "18", "S9(18)"));
        /*"    10 GE419-SEQ-ID-ENVIO-HIST       PIC S9(4) USAGE COMP.*/
        public IntBasis GE419_SEQ_ID_ENVIO_HIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GE419-COD-IMPOSTO-INTERNO       PIC S9(4) USAGE COMP.*/
        public IntBasis GE419_COD_IMPOSTO_INTERNO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GE419-COD-TRIBUTO-SAP       PIC X(2).*/
        public StringBasis GE419_COD_TRIBUTO_SAP { get; set; } = new StringBasis(new PIC("X", "2", "X(2)."), @"");
        /*"    10 GE419-IND-TP-TRIBUTO       PIC S9(4) USAGE COMP.*/
        public IntBasis GE419_IND_TP_TRIBUTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GE419-PCT-ALIQUOTA   PIC S9(3)V9(5) USAGE COMP-3.*/
        public DoubleBasis GE419_PCT_ALIQUOTA { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(5)"), 5);
        /*"    10 GE419-VLR-BASE-TRIB  PIC S9(14)V9(2) USAGE COMP-3.*/
        public DoubleBasis GE419_VLR_BASE_TRIB { get; set; } = new DoubleBasis(new PIC("S9", "14", "S9(14)V9(2)"), 2);
        /*"    10 GE419-VLR-TRIBUTO    PIC S9(14)V9(2) USAGE COMP-3.*/
        public DoubleBasis GE419_VLR_TRIBUTO { get; set; } = new DoubleBasis(new PIC("S9", "14", "S9(14)V9(2)"), 2);
        /*"    10 GE419-NOM-PROGRAMA   PIC X(10).*/
        public StringBasis GE419_NOM_PROGRAMA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 GE419-DTH-CADASTRAMENTO       PIC X(26).*/
        public StringBasis GE419_DTH_CADASTRAMENTO { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"*/
    }
}