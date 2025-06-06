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
    public class CB042_DCLCB_AVISO_SALDO_ANALITICO : VarBasis
    {
        /*"    10 CB042-NUM-AGE-AVISO  PIC S9(4) USAGE COMP.*/
        public IntBasis CB042_NUM_AGE_AVISO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 CB042-NUM-TIPO-SEGURO       PIC X(1).*/
        public StringBasis CB042_NUM_TIPO_SEGURO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 CB042-NUM-AVISO-CREDITO       PIC S9(9) USAGE COMP.*/
        public IntBasis CB042_NUM_AVISO_CREDITO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 CB042-NUM-BCO-AVISO  PIC S9(4) USAGE COMP.*/
        public IntBasis CB042_NUM_BCO_AVISO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 CB042-NUM-ANO-PROCESS       PIC S9(4) USAGE COMP.*/
        public IntBasis CB042_NUM_ANO_PROCESS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 CB042-NUM-MES-PROCESS       PIC S9(4) USAGE COMP.*/
        public IntBasis CB042_NUM_MES_PROCESS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 CB042-VLR-BAIXA      PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis CB042_VLR_BAIXA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 CB042-VLR-ESTORNO    PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis CB042_VLR_ESTORNO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 CB042-VLR-DEVOLUCAO  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis CB042_VLR_DEVOLUCAO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 CB042-VLR-DEVOLUCAO-ESTORNO       PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis CB042_VLR_DEVOLUCAO_ESTORNO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 CB042-VLR-CANCELAMENTO       PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis CB042_VLR_CANCELAMENTO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 CB042-VLR-REATIVACAO       PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis CB042_VLR_REATIVACAO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 CB042-VLR-DEV-FOLLOWUP       PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis CB042_VLR_DEV_FOLLOWUP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 CB042-VLR-CANCEL-FOLLOWUP       PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis CB042_VLR_CANCEL_FOLLOWUP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 CB042-VLR-SALDO-RESIDUAL       PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis CB042_VLR_SALDO_RESIDUAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"*/
    }
}