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
    public class COBHISVI_DCLCOBER_HIST_VIDAZUL : VarBasis
    {
        /*"    10 COBHISVI-NUM-CERTIFICADO  PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis COBHISVI_NUM_CERTIFICADO { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 COBHISVI-NUM-PARCELA  PIC S9(4) USAGE COMP.*/
        public IntBasis COBHISVI_NUM_PARCELA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 COBHISVI-NUM-TITULO  PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis COBHISVI_NUM_TITULO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 COBHISVI-DATA-VENCIMENTO  PIC X(10).*/
        public StringBasis COBHISVI_DATA_VENCIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 COBHISVI-PRM-TOTAL   PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis COBHISVI_PRM_TOTAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 COBHISVI-OPCAO-PAGAMENTO  PIC X(1).*/
        public StringBasis COBHISVI_OPCAO_PAGAMENTO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 COBHISVI-SIT-REGISTRO  PIC X(1).*/
        public StringBasis COBHISVI_SIT_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 COBHISVI-COD-OPERACAO  PIC S9(4) USAGE COMP.*/
        public IntBasis COBHISVI_COD_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 COBHISVI-OCORR-HISTORICO  PIC S9(4) USAGE COMP.*/
        public IntBasis COBHISVI_OCORR_HISTORICO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 COBHISVI-COD-DEVOLUCAO  PIC S9(4) USAGE COMP.*/
        public IntBasis COBHISVI_COD_DEVOLUCAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 COBHISVI-BCO-AVISO   PIC S9(4) USAGE COMP.*/
        public IntBasis COBHISVI_BCO_AVISO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 COBHISVI-AGE-AVISO   PIC S9(4) USAGE COMP.*/
        public IntBasis COBHISVI_AGE_AVISO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 COBHISVI-NUM-AVISO-CREDITO  PIC S9(9) USAGE COMP.*/
        public IntBasis COBHISVI_NUM_AVISO_CREDITO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 COBHISVI-NUM-TITULO-COMP  PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis COBHISVI_NUM_TITULO_COMP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"*/
    }
}