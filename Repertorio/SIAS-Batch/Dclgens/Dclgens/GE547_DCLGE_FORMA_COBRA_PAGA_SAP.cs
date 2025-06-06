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
    public class GE547_DCLGE_FORMA_COBRA_PAGA_SAP : VarBasis
    {
        /*"    10 GE547-NUM-IDLG       PIC S9(18) USAGE COMP.*/
        public IntBasis GE547_NUM_IDLG { get; set; } = new IntBasis(new PIC("S9", "18", "S9(18)"));
        /*"    10 GE547-COD-CONVENIO   PIC S9(18) USAGE COMP.*/
        public IntBasis GE547_COD_CONVENIO { get; set; } = new IntBasis(new PIC("S9", "18", "S9(18)"));
        /*"    10 GE547-COD-TIPO-CONVENIO       PIC X(1).*/
        public StringBasis GE547_COD_TIPO_CONVENIO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 GE547-COD-FORMA      PIC X(1).*/
        public StringBasis GE547_COD_FORMA { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 GE547-DTA-COBRAR-PAGAR       PIC X(10).*/
        public StringBasis GE547_DTA_COBRAR_PAGAR { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 GE547-VLR-COBRAR-PAGAR       PIC S9(16)V9(2) USAGE COMP-3.*/
        public DoubleBasis GE547_VLR_COBRAR_PAGAR { get; set; } = new DoubleBasis(new PIC("S9", "16", "S9(16)V9(2)"), 2);
        /*"    10 GE547-NUM-CHEQUE-INTERNO       PIC S9(9) USAGE COMP.*/
        public IntBasis GE547_NUM_CHEQUE_INTERNO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 GE547-NUM-DV-CHQ-INTERNO       PIC X(1).*/
        public StringBasis GE547_NUM_DV_CHQ_INTERNO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 GE547-NOM-TITULAR-CC       PIC X(60).*/
        public StringBasis GE547_NOM_TITULAR_CC { get; set; } = new StringBasis(new PIC("X", "60", "X(60)."), @"");
        /*"    10 GE547-COD-BANCO      PIC S9(4) USAGE COMP.*/
        public IntBasis GE547_COD_BANCO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GE547-COD-DV-BANCO   PIC X(2).*/
        public StringBasis GE547_COD_DV_BANCO { get; set; } = new StringBasis(new PIC("X", "2", "X(2)."), @"");
        /*"    10 GE547-COD-AGENCIA    PIC S9(4) USAGE COMP.*/
        public IntBasis GE547_COD_AGENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GE547-COD-DV-AGENCIA       PIC X(2).*/
        public StringBasis GE547_COD_DV_AGENCIA { get; set; } = new StringBasis(new PIC("X", "2", "X(2)."), @"");
        /*"    10 GE547-COD-OPER-CAIXA       PIC S9(4) USAGE COMP.*/
        public IntBasis GE547_COD_OPER_CAIXA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GE547-NUM-CONTA-CORRENTE       PIC S9(18) USAGE COMP.*/
        public IntBasis GE547_NUM_CONTA_CORRENTE { get; set; } = new IntBasis(new PIC("S9", "18", "S9(18)"));
        /*"    10 GE547-COD-DV-CTA-CORRENTE       PIC X(2).*/
        public StringBasis GE547_COD_DV_CTA_CORRENTE { get; set; } = new StringBasis(new PIC("X", "2", "X(2)."), @"");
        /*"    10 GE547-COD-DOC-SIACC  PIC X(30).*/
        public StringBasis GE547_COD_DOC_SIACC { get; set; } = new StringBasis(new PIC("X", "30", "X(30)."), @"");
        /*"    10 GE547-TXT-USO-EMPRESA.*/
        public GE547_GE547_TXT_USO_EMPRESA GE547_TXT_USO_EMPRESA { get; set; } = new GE547_GE547_TXT_USO_EMPRESA();

        public DoubleBasis GE547_VLR_ATUALIZA_MONETARIA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 GE547-VLR-JURO       PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis GE547_VLR_JURO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 GE547-VLR-IOF        PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis GE547_VLR_IOF { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 GE547-QTD-DIAS-BOLETO-BANCO       PIC S9(4) USAGE COMP.*/
        public IntBasis GE547_QTD_DIAS_BOLETO_BANCO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GE547-PCT-MULTA      PIC S9(3)V9(2) USAGE COMP-3.*/
        public DoubleBasis GE547_PCT_MULTA { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(2)"), 2);
        /*"    10 GE547-VLR-JUROS-DIA  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis GE547_VLR_JUROS_DIA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 GE547-VLR-RESTITUI-EVENTO-HAB       PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis GE547_VLR_RESTITUI_EVENTO_HAB { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 GE547-VLR-REMUNERA-EVENTO-HAB       PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis GE547_VLR_REMUNERA_EVENTO_HAB { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"*/
    }
}