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
    public class GE408_DCLGE_RETORNO_CA_CIELO : VarBasis
    {
        /*"    10 GE408-NUM-PROPOSTA   PIC S9(18) USAGE COMP.*/
        public IntBasis GE408_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("S9", "18", "S9(18)"));
        /*"    10 GE408-NUM-CERTIFICADO       PIC S9(18) USAGE COMP.*/
        public IntBasis GE408_NUM_CERTIFICADO { get; set; } = new IntBasis(new PIC("S9", "18", "S9(18)"));
        /*"    10 GE408-NUM-PARCELA    PIC S9(4) USAGE COMP.*/
        public IntBasis GE408_NUM_PARCELA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GE408-NUM-APOLICE    PIC S9(18) USAGE COMP.*/
        public IntBasis GE408_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "18", "S9(18)"));
        /*"    10 GE408-NUM-ENDOSSO    PIC S9(18) USAGE COMP.*/
        public IntBasis GE408_NUM_ENDOSSO { get; set; } = new IntBasis(new PIC("S9", "18", "S9(18)"));
        /*"    10 GE408-SEQ-CONTROL-CARTAO       PIC S9(4) USAGE COMP.*/
        public IntBasis GE408_SEQ_CONTROL_CARTAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GE408-SEQ-RET-CONTROL-HIST       PIC S9(4) USAGE COMP.*/
        public IntBasis GE408_SEQ_RET_CONTROL_HIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GE408-DTA-MOVIMENTO  PIC X(10).*/
        public StringBasis GE408_DTA_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 GE408-NUM-COM-CIELO  PIC S9(18) USAGE COMP.*/
        public IntBasis GE408_NUM_COM_CIELO { get; set; } = new IntBasis(new PIC("S9", "18", "S9(18)"));
        /*"    10 GE408-COD-BCO-CRED   PIC S9(4) USAGE COMP.*/
        public IntBasis GE408_COD_BCO_CRED { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GE408-NUM-AGE-CRED   PIC S9(4) USAGE COMP.*/
        public IntBasis GE408_NUM_AGE_CRED { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GE408-NUM-CTA-CRED   PIC S9(9) USAGE COMP.*/
        public IntBasis GE408_NUM_CTA_CRED { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 GE408-NUM-DIG-CTA-CRED       PIC S9(4) USAGE COMP.*/
        public IntBasis GE408_NUM_DIG_CTA_CRED { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GE408-COD-CART-BANDEIRA       PIC S9(4) USAGE COMP.*/
        public IntBasis GE408_COD_CART_BANDEIRA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GE408-NUM-CARTAO     PIC X(25).*/
        public StringBasis GE408_NUM_CARTAO { get; set; } = new StringBasis(new PIC("X", "25", "X(25)."), @"");
        /*"    10 GE408-COD-TOKEN-CARTAO       PIC X(40).*/
        public StringBasis GE408_COD_TOKEN_CARTAO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"    10 GE408-STA-CART-PADRAO-SAP       PIC X(1).*/
        public StringBasis GE408_STA_CART_PADRAO_SAP { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 GE408-COD-TID-CIELO  PIC X(20).*/
        public StringBasis GE408_COD_TID_CIELO { get; set; } = new StringBasis(new PIC("X", "20", "X(20)."), @"");
        /*"    10 GE408-VLR-COBRANCA   PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis GE408_VLR_COBRANCA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 GE408-VLR-LIQUIDO    PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis GE408_VLR_LIQUIDO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 GE408-VLR-TAX-ADM    PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis GE408_VLR_TAX_ADM { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 GE408-DTA-VENCIMENTO       PIC X(10).*/
        public StringBasis GE408_DTA_VENCIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 GE408-DTA-CREDITO    PIC X(10).*/
        public StringBasis GE408_DTA_CREDITO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 GE408-DTA-DEB-TARIFA-ADM       PIC X(10).*/
        public StringBasis GE408_DTA_DEB_TARIFA_ADM { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 GE408-DTA-AJU-CAPTURA       PIC X(10).*/
        public StringBasis GE408_DTA_AJU_CAPTURA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 GE408-COD-MOVIMENTO  PIC X(2).*/
        public StringBasis GE408_COD_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "2", "X(2)."), @"");
        /*"    10 GE408-COD-RETORNO    PIC X(3).*/
        public StringBasis GE408_COD_RETORNO { get; set; } = new StringBasis(new PIC("X", "3", "X(3)."), @"");
        /*"    10 GE408-COD-USUARIO    PIC X(8).*/
        public StringBasis GE408_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 GE408-DTH-PROCESSAMENTO       PIC X(26).*/
        public StringBasis GE408_DTH_PROCESSAMENTO { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 GE408-COD-PROCE-ADVERTENCIA       PIC X(2).*/
        public StringBasis GE408_COD_PROCE_ADVERTENCIA { get; set; } = new StringBasis(new PIC("X", "2", "X(2)."), @"");
        /*"    10 GE408-COD-NIVEL-ADVERTENCIA       PIC X(2).*/
        public StringBasis GE408_COD_NIVEL_ADVERTENCIA { get; set; } = new StringBasis(new PIC("X", "2", "X(2)."), @"");
        /*"*/
    }
}