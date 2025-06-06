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
    public class PROPCOBR_DCLPROPOSTA_COBRANCA : VarBasis
    {
        /*"    10 PROPCOBR-COD-EMPRESA       PIC S9(9) USAGE COMP.*/
        public IntBasis PROPCOBR_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 PROPCOBR-COD-FONTE   PIC S9(4) USAGE COMP.*/
        public IntBasis PROPCOBR_COD_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PROPCOBR-NUM-PROPOSTA       PIC S9(9) USAGE COMP.*/
        public IntBasis PROPCOBR_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 PROPCOBR-COD-PRODUTO       PIC S9(4) USAGE COMP.*/
        public IntBasis PROPCOBR_COD_PRODUTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PROPCOBR-NUM-MATRICULA       PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis PROPCOBR_NUM_MATRICULA { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 PROPCOBR-COD-AGENCIA       PIC S9(4) USAGE COMP.*/
        public IntBasis PROPCOBR_COD_AGENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PROPCOBR-OPERACAO-CONTA       PIC S9(4) USAGE COMP.*/
        public IntBasis PROPCOBR_OPERACAO_CONTA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PROPCOBR-NUM-CONTA   PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis PROPCOBR_NUM_CONTA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 PROPCOBR-DIG-CONTA   PIC S9(4) USAGE COMP.*/
        public IntBasis PROPCOBR_DIG_CONTA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PROPCOBR-VALOR-COMISSAO-CEF       PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis PROPCOBR_VALOR_COMISSAO_CEF { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 PROPCOBR-TIPO-COBRANCA       PIC X(1).*/
        public StringBasis PROPCOBR_TIPO_COBRANCA { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 PROPCOBR-COD-AGENCIA-DEB       PIC S9(4) USAGE COMP.*/
        public IntBasis PROPCOBR_COD_AGENCIA_DEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PROPCOBR-OPER-CONTA-DEB       PIC S9(4) USAGE COMP.*/
        public IntBasis PROPCOBR_OPER_CONTA_DEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PROPCOBR-NUM-CONTA-DEB       PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis PROPCOBR_NUM_CONTA_DEB { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 PROPCOBR-DIG-CONTA-DEB       PIC S9(4) USAGE COMP.*/
        public IntBasis PROPCOBR_DIG_CONTA_DEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PROPCOBR-NUM-CARTAO  PIC S9(16)V USAGE COMP-3.*/
        public DoubleBasis PROPCOBR_NUM_CARTAO { get; set; } = new DoubleBasis(new PIC("S9", "16", "S9(16)V"), 0);
        /*"    10 PROPCOBR-DIA-DEBITO  PIC S9(4) USAGE COMP.*/
        public IntBasis PROPCOBR_DIA_DEBITO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PROPCOBR-NR-CERTIF-AUTO       PIC X(25).*/
        public StringBasis PROPCOBR_NR_CERTIF_AUTO { get; set; } = new StringBasis(new PIC("X", "25", "X(25)."), @"");
        /*"    10 PROPCOBR-TIMESTAMP   PIC X(26).*/
        public StringBasis PROPCOBR_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 PROPCOBR-MARGEM-COMERCIAL       PIC S9(3)V9(2) USAGE COMP-3.*/
        public DoubleBasis PROPCOBR_MARGEM_COMERCIAL { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(2)"), 2);
        /*"*/
    }
}