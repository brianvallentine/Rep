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
    public class CONTACOR_DCLCONTA_CORRENTE : VarBasis
    {
        /*"    10 CONTACOR-COD-CLIENTE       PIC S9(9) USAGE COMP.*/
        public IntBasis CONTACOR_COD_CLIENTE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 CONTACOR-NUM-APOLICE       PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis CONTACOR_NUM_APOLICE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 CONTACOR-COD-BANCO   PIC S9(4) USAGE COMP.*/
        public IntBasis CONTACOR_COD_BANCO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 CONTACOR-COD-AGENCIA       PIC S9(4) USAGE COMP.*/
        public IntBasis CONTACOR_COD_AGENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 CONTACOR-NUM-CTA-CORRENTE       PIC S9(17)V USAGE COMP-3.*/
        public DoubleBasis CONTACOR_NUM_CTA_CORRENTE { get; set; } = new DoubleBasis(new PIC("S9", "17", "S9(17)V"), 0);
        /*"    10 CONTACOR-DAC-CTA-CORRENTE       PIC X(1).*/
        public StringBasis CONTACOR_DAC_CTA_CORRENTE { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 CONTACOR-SIT-REGISTRO       PIC X(1).*/
        public StringBasis CONTACOR_SIT_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 CONTACOR-NUM-CERTIFICADO       PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis CONTACOR_NUM_CERTIFICADO { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 CONTACOR-COD-EMPRESA       PIC S9(9) USAGE COMP.*/
        public IntBasis CONTACOR_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 CONTACOR-AGENCIA-ORIGEM       PIC S9(4) USAGE COMP.*/
        public IntBasis CONTACOR_AGENCIA_ORIGEM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 CONTACOR-DIA-DEBITO  PIC S9(4) USAGE COMP.*/
        public IntBasis CONTACOR_DIA_DEBITO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 CONTACOR-OPCAO-PAGAMENTO       PIC X(1).*/
        public StringBasis CONTACOR_OPCAO_PAGAMENTO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 CONTACOR-OPCAO-CAPITALIZ       PIC S9(4) USAGE COMP.*/
        public IntBasis CONTACOR_OPCAO_CAPITALIZ { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 CONTACOR-NUM-PARCELA       PIC S9(4) USAGE COMP.*/
        public IntBasis CONTACOR_NUM_PARCELA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"*/
    }
}