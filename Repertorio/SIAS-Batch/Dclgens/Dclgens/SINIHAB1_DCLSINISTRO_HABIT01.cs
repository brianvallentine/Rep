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
    public class SINIHAB1_DCLSINISTRO_HABIT01 : VarBasis
    {
        /*"    10 SINIHAB1-NUM-APOL-SINISTRO       PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis SINIHAB1_NUM_APOL_SINISTRO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 SINIHAB1-COD-PRODUTO       PIC S9(4) USAGE COMP.*/
        public IntBasis SINIHAB1_COD_PRODUTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SINIHAB1-COD-CLIENTE       PIC S9(9) USAGE COMP.*/
        public IntBasis SINIHAB1_COD_CLIENTE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 SINIHAB1-NUM-APOLICE       PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis SINIHAB1_NUM_APOLICE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 SINIHAB1-OPERACAO    PIC S9(4) USAGE COMP.*/
        public IntBasis SINIHAB1_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SINIHAB1-PONTO-VENDA       PIC S9(4) USAGE COMP.*/
        public IntBasis SINIHAB1_PONTO_VENDA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SINIHAB1-NUM-CONTRATO       PIC S9(9) USAGE COMP.*/
        public IntBasis SINIHAB1_NUM_CONTRATO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 SINIHAB1-SITUACAO    PIC X(1).*/
        public StringBasis SINIHAB1_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 SINIHAB1-COD-COBERTURA       PIC S9(4) USAGE COMP.*/
        public IntBasis SINIHAB1_COD_COBERTURA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SINIHAB1-CGCCPF      PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis SINIHAB1_CGCCPF { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 SINIHAB1-NOME-SEGURADO       PIC X(40).*/
        public StringBasis SINIHAB1_NOME_SEGURADO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"    10 SINIHAB1-TIMESTAMP   PIC X(26).*/
        public StringBasis SINIHAB1_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 SINIHAB1-DATA-NASC   PIC X(10).*/
        public StringBasis SINIHAB1_DATA_NASC { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 SINIHAB1-NOME-PROCURADOR       PIC X(40).*/
        public StringBasis SINIHAB1_NOME_PROCURADOR { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"    10 SINIHAB1-COD-UNO     PIC S9(4) USAGE COMP.*/
        public IntBasis SINIHAB1_COD_UNO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SINIHAB1-RENDA-PACTUADA       PIC S9(5)V9(2) USAGE COMP-3.*/
        public DoubleBasis SINIHAB1_RENDA_PACTUADA { get; set; } = new DoubleBasis(new PIC("S9", "5", "S9(5)V9(2)"), 2);
        /*"    10 SINIHAB1-IND-CAUSADOR-TERC       PIC X(1).*/
        public StringBasis SINIHAB1_IND_CAUSADOR_TERC { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 SINIHAB1-NUM-CONTRATO-TERC       PIC S9(18) USAGE COMP.*/
        public IntBasis SINIHAB1_NUM_CONTRATO_TERC { get; set; } = new IntBasis(new PIC("S9", "18", "S9(18)"));
        /*"    10 SINIHAB1-NUM-DV-CONTRATO-TERC       PIC X(2).*/
        public StringBasis SINIHAB1_NUM_DV_CONTRATO_TERC { get; set; } = new StringBasis(new PIC("X", "2", "X(2)."), @"");
        /*"*/
    }
}