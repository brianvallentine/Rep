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
    public class APOLCOBR_DCLAPOLICE_COBRANCA : VarBasis
    {
        /*"    10 APOLCOBR-COD-EMPRESA       PIC S9(9) USAGE COMP.*/
        public IntBasis APOLCOBR_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 APOLCOBR-COD-FONTE   PIC S9(4) USAGE COMP.*/
        public IntBasis APOLCOBR_COD_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 APOLCOBR-NUM-APOLICE       PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis APOLCOBR_NUM_APOLICE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 APOLCOBR-NUM-ENDOSSO       PIC S9(9) USAGE COMP.*/
        public IntBasis APOLCOBR_NUM_ENDOSSO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 APOLCOBR-COD-PRODUTO       PIC S9(4) USAGE COMP.*/
        public IntBasis APOLCOBR_COD_PRODUTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 APOLCOBR-NUM-MATRICULA       PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis APOLCOBR_NUM_MATRICULA { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 APOLCOBR-TIPO-COBRANCA       PIC X(1).*/
        public StringBasis APOLCOBR_TIPO_COBRANCA { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 APOLCOBR-AGE-COBRANCA       PIC S9(4) USAGE COMP.*/
        public IntBasis APOLCOBR_AGE_COBRANCA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 APOLCOBR-COD-AGENCIA       PIC S9(4) USAGE COMP.*/
        public IntBasis APOLCOBR_COD_AGENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 APOLCOBR-OPERACAO-CONTA       PIC S9(4) USAGE COMP.*/
        public IntBasis APOLCOBR_OPERACAO_CONTA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 APOLCOBR-NUM-CONTA   PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis APOLCOBR_NUM_CONTA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 APOLCOBR-DIG-CONTA   PIC S9(4) USAGE COMP.*/
        public IntBasis APOLCOBR_DIG_CONTA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 APOLCOBR-COD-AGENCIA-DEB       PIC S9(4) USAGE COMP.*/
        public IntBasis APOLCOBR_COD_AGENCIA_DEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 APOLCOBR-OPER-CONTA-DEB       PIC S9(4) USAGE COMP.*/
        public IntBasis APOLCOBR_OPER_CONTA_DEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 APOLCOBR-NUM-CONTA-DEB       PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis APOLCOBR_NUM_CONTA_DEB { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 APOLCOBR-DIG-CONTA-DEB       PIC S9(4) USAGE COMP.*/
        public IntBasis APOLCOBR_DIG_CONTA_DEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 APOLCOBR-NUM-CARTAO  PIC S9(16)V USAGE COMP-3.*/
        public DoubleBasis APOLCOBR_NUM_CARTAO { get; set; } = new DoubleBasis(new PIC("S9", "16", "S9(16)V"), 0);
        /*"    10 APOLCOBR-DIA-DEBITO  PIC S9(4) USAGE COMP.*/
        public IntBasis APOLCOBR_DIA_DEBITO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 APOLCOBR-NR-CERTIF-AUTO       PIC X(25).*/
        public StringBasis APOLCOBR_NR_CERTIF_AUTO { get; set; } = new StringBasis(new PIC("X", "25", "X(25)."), @"");
        /*"    10 APOLCOBR-TIMESTAMP   PIC X(26).*/
        public StringBasis APOLCOBR_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 APOLCOBR-MARGEM-COMERCIAL       PIC S9(3)V9(2) USAGE COMP-3.*/
        public DoubleBasis APOLCOBR_MARGEM_COMERCIAL { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(2)"), 2);
        /*"*/
    }
}