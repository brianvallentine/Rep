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
    public class EF158_DCLEF_MATRICULA_INDICADOR : VarBasis
    {
        /*"    10 EF158-DTA-CARGA      PIC X(10).*/
        public StringBasis EF158_DTA_CARGA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 EF158-DTA-MOVTO      PIC X(10).*/
        public StringBasis EF158_DTA_MOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 EF158-NUM-CONTRATO-TERC       PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis EF158_NUM_CONTRATO_TERC { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 EF158-NOM-ARQUIVO    PIC X(8).*/
        public StringBasis EF158_NOM_ARQUIVO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 EF158-NUM-SUREG-AGENCIA       PIC S9(9) USAGE COMP.*/
        public IntBasis EF158_NUM_SUREG_AGENCIA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 EF158-NUM-AGENCIA    PIC S9(9) USAGE COMP.*/
        public IntBasis EF158_NUM_AGENCIA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 EF158-NUM-OPERACAO   PIC S9(4) USAGE COMP.*/
        public IntBasis EF158_NUM_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 EF158-NUM-CONTRATO   PIC S9(18)V USAGE COMP-3.*/
        public DoubleBasis EF158_NUM_CONTRATO { get; set; } = new DoubleBasis(new PIC("S9", "18", "S9(18)V"), 0);
        /*"    10 EF158-NUM-DV-CONTRATO       PIC S9(4) USAGE COMP.*/
        public IntBasis EF158_NUM_DV_CONTRATO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 EF158-DTA-CONCESSAO  PIC X(10).*/
        public StringBasis EF158_DTA_CONCESSAO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 EF158-COD-PRODUTO    PIC S9(4) USAGE COMP.*/
        public IntBasis EF158_COD_PRODUTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 EF158-NUM-CPF-CGC-CLIENTE       PIC S9(11)V USAGE COMP-3.*/
        public DoubleBasis EF158_NUM_CPF_CGC_CLIENTE { get; set; } = new DoubleBasis(new PIC("S9", "11", "S9(11)V"), 0);
        /*"    10 EF158-NOM-CLIENTE    PIC X(100).*/
        public StringBasis EF158_NOM_CLIENTE { get; set; } = new StringBasis(new PIC("X", "100", "X(100)."), @"");
        /*"    10 EF158-NUM-CPF-CGC-INDICADOR       PIC S9(11)V USAGE COMP-3.*/
        public DoubleBasis EF158_NUM_CPF_CGC_INDICADOR { get; set; } = new DoubleBasis(new PIC("S9", "11", "S9(11)V"), 0);
        /*"    10 EF158-NUM-MATRICULA-INDICADOR       PIC S9(9) USAGE COMP.*/
        public IntBasis EF158_NUM_MATRICULA_INDICADOR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 EF158-NUM-MATRICULA-CCA       PIC S9(9) USAGE COMP.*/
        public IntBasis EF158_NUM_MATRICULA_CCA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 EF158-NUM-DV-MATRICULA-CCA       PIC S9(4) USAGE COMP.*/
        public IntBasis EF158_NUM_DV_MATRICULA_CCA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 EF158-NUM-TIPO-CCA   PIC S9(4) USAGE COMP.*/
        public IntBasis EF158_NUM_TIPO_CCA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 EF158-NUM-PROPOSTA   PIC S9(14)V USAGE COMP-3.*/
        public DoubleBasis EF158_NUM_PROPOSTA { get; set; } = new DoubleBasis(new PIC("S9", "14", "S9(14)V"), 0);
        /*"    10 EF158-NUM-CANAL-RECEBIDO       PIC S9(4) USAGE COMP.*/
        public IntBasis EF158_NUM_CANAL_RECEBIDO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 EF158-NUM-CANAL-ATRIBUIDO       PIC S9(4) USAGE COMP.*/
        public IntBasis EF158_NUM_CANAL_ATRIBUIDO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 EF158-NUM-TIPO-REPASSE       PIC S9(4) USAGE COMP.*/
        public IntBasis EF158_NUM_TIPO_REPASSE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 EF158-NOM-ARQUIVO-ORIGEM       PIC X(10).*/
        public StringBasis EF158_NOM_ARQUIVO_ORIGEM { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 EF158-VLR-CONTRATO   PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis EF158_VLR_CONTRATO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 EF158-VLR-SEGURO     PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis EF158_VLR_SEGURO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 EF158-NUM-PV-RENOVACAO       PIC S9(4) USAGE COMP.*/
        public IntBasis EF158_NUM_PV_RENOVACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"*/
    }
}