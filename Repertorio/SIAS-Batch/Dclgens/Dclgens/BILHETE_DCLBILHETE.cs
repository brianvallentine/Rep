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
    public class BILHETE_DCLBILHETE : VarBasis
    {
        /*"    10 BILHETE-NUM-BILHETE  PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis BILHETE_NUM_BILHETE { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 BILHETE-NUM-APOLICE  PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis BILHETE_NUM_APOLICE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 BILHETE-FONTE        PIC S9(4) USAGE COMP.*/
        public IntBasis BILHETE_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 BILHETE-AGE-COBRANCA       PIC S9(4) USAGE COMP.*/
        public IntBasis BILHETE_AGE_COBRANCA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 BILHETE-NUM-MATRICULA       PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis BILHETE_NUM_MATRICULA { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 BILHETE-COD-AGENCIA  PIC S9(4) USAGE COMP.*/
        public IntBasis BILHETE_COD_AGENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 BILHETE-OPERACAO-CONTA       PIC S9(4) USAGE COMP.*/
        public IntBasis BILHETE_OPERACAO_CONTA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 BILHETE-NUM-CONTA    PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis BILHETE_NUM_CONTA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 BILHETE-DIG-CONTA    PIC S9(4) USAGE COMP.*/
        public IntBasis BILHETE_DIG_CONTA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 BILHETE-COD-CLIENTE  PIC S9(9) USAGE COMP.*/
        public IntBasis BILHETE_COD_CLIENTE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 BILHETE-PROFISSAO    PIC X(20).*/
        public StringBasis BILHETE_PROFISSAO { get; set; } = new StringBasis(new PIC("X", "20", "X(20)."), @"");
        /*"    10 BILHETE-IDE-SEXO     PIC X(1).*/
        public StringBasis BILHETE_IDE_SEXO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 BILHETE-ESTADO-CIVIL       PIC X(1).*/
        public StringBasis BILHETE_ESTADO_CIVIL { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 BILHETE-OCORR-ENDERECO       PIC S9(4) USAGE COMP.*/
        public IntBasis BILHETE_OCORR_ENDERECO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 BILHETE-COD-AGENCIA-DEB       PIC S9(4) USAGE COMP.*/
        public IntBasis BILHETE_COD_AGENCIA_DEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 BILHETE-OPERACAO-CONTA-DEB       PIC S9(4) USAGE COMP.*/
        public IntBasis BILHETE_OPERACAO_CONTA_DEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 BILHETE-NUM-CONTA-DEB       PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis BILHETE_NUM_CONTA_DEB { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 BILHETE-DIG-CONTA-DEB       PIC S9(4) USAGE COMP.*/
        public IntBasis BILHETE_DIG_CONTA_DEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 BILHETE-OPC-COBERTURA       PIC S9(4) USAGE COMP.*/
        public IntBasis BILHETE_OPC_COBERTURA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 BILHETE-DATA-QUITACAO       PIC X(10).*/
        public StringBasis BILHETE_DATA_QUITACAO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 BILHETE-VAL-RCAP     PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis BILHETE_VAL_RCAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 BILHETE-RAMO         PIC S9(4) USAGE COMP.*/
        public IntBasis BILHETE_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 BILHETE-DATA-VENDA   PIC X(10).*/
        public StringBasis BILHETE_DATA_VENDA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 BILHETE-DATA-MOVIMENTO       PIC X(10).*/
        public StringBasis BILHETE_DATA_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 BILHETE-NUM-APOL-ANTERIOR       PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis BILHETE_NUM_APOL_ANTERIOR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 BILHETE-SITUACAO     PIC X(1).*/
        public StringBasis BILHETE_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 BILHETE-TIP-CANCELAMENTO       PIC X(1).*/
        public StringBasis BILHETE_TIP_CANCELAMENTO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 BILHETE-SIT-SINISTRO       PIC X(1).*/
        public StringBasis BILHETE_SIT_SINISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 BILHETE-COD-USUARIO  PIC X(8).*/
        public StringBasis BILHETE_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 BILHETE-TIMESTAMP    PIC X(26).*/
        public StringBasis BILHETE_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 BILHETE-DATA-CANCELAMENTO       PIC X(10).*/
        public StringBasis BILHETE_DATA_CANCELAMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 BILHETE-BI-FAIXA-RENDA-IND       PIC S9(4) USAGE COMP.*/
        public IntBasis BILHETE_BI_FAIXA_RENDA_IND { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 BILHETE-BI-FAIXA-RENDA-FAM       PIC S9(4) USAGE COMP.*/
        public IntBasis BILHETE_BI_FAIXA_RENDA_FAM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 BILHETE-COD-PRODUTO  PIC S9(4) USAGE COMP.*/
        public IntBasis BILHETE_COD_PRODUTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"*/
    }
}