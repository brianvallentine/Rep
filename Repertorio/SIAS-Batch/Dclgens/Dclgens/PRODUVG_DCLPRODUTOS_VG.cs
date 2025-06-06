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
    public class PRODUVG_DCLPRODUTOS_VG : VarBasis
    {
        /*"    10 PRODUVG-NUM-APOLICE  PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis PRODUVG_NUM_APOLICE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 PRODUVG-COD-SUBGRUPO  PIC S9(4) USAGE COMP.*/
        public IntBasis PRODUVG_COD_SUBGRUPO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PRODUVG-ID-SISTEMA   PIC X(2).*/
        public StringBasis PRODUVG_ID_SISTEMA { get; set; } = new StringBasis(new PIC("X", "2", "X(2)."), @"");
        /*"    10 PRODUVG-COD-PRODUTO-AZUL  PIC X(3).*/
        public StringBasis PRODUVG_COD_PRODUTO_AZUL { get; set; } = new StringBasis(new PIC("X", "3", "X(3)."), @"");
        /*"    10 PRODUVG-COD-PRODUTO  PIC S9(4) USAGE COMP.*/
        public IntBasis PRODUVG_COD_PRODUTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PRODUVG-NOME-PRODUTO  PIC X(30).*/
        public StringBasis PRODUVG_NOME_PRODUTO { get; set; } = new StringBasis(new PIC("X", "30", "X(30)."), @"");
        /*"    10 PRODUVG-PERI-PAGAMENTO  PIC S9(4) USAGE COMP.*/
        public IntBasis PRODUVG_PERI_PAGAMENTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PRODUVG-DIAS-INICIO-VIGENC  PIC S9(4) USAGE COMP.*/
        public IntBasis PRODUVG_DIAS_INICIO_VIGENC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PRODUVG-DATA-MINVIGENCIA  PIC X(10).*/
        public StringBasis PRODUVG_DATA_MINVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 PRODUVG-DATA-MAXVIGENCIA  PIC X(10).*/
        public StringBasis PRODUVG_DATA_MAXVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 PRODUVG-SIT-PLANO-CEF  PIC X(1).*/
        public StringBasis PRODUVG_SIT_PLANO_CEF { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 PRODUVG-OPCAO-PAGAMENTO  PIC X(1).*/
        public StringBasis PRODUVG_OPCAO_PAGAMENTO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 PRODUVG-COD-CEDENTE  PIC S9(4) USAGE COMP.*/
        public IntBasis PRODUVG_COD_CEDENTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PRODUVG-OPC-AGENCTO-SUREG  PIC X(1).*/
        public StringBasis PRODUVG_OPC_AGENCTO_SUREG { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 PRODUVG-OPCAO-CAPITALIZ  PIC S9(4) USAGE COMP.*/
        public IntBasis PRODUVG_OPCAO_CAPITALIZ { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PRODUVG-COD-SERIE    PIC X(1).*/
        public StringBasis PRODUVG_COD_SERIE { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 PRODUVG-NUM-SEQ-TITULO  PIC S9(9) USAGE COMP.*/
        public IntBasis PRODUVG_NUM_SEQ_TITULO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 PRODUVG-NUM-MALA-DIRETA  PIC S9(4) USAGE COMP.*/
        public IntBasis PRODUVG_NUM_MALA_DIRETA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PRODUVG-RAMO         PIC S9(4) USAGE COMP.*/
        public IntBasis PRODUVG_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PRODUVG-CANCELA-ANTIGO  PIC X(1).*/
        public StringBasis PRODUVG_CANCELA_ANTIGO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 PRODUVG-IND-RCAP     PIC X(1).*/
        public StringBasis PRODUVG_IND_RCAP { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 PRODUVG-NRMSCAP      PIC S9(4) USAGE COMP.*/
        public IntBasis PRODUVG_NRMSCAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PRODUVG-NRMFDCAP     PIC S9(4) USAGE COMP.*/
        public IntBasis PRODUVG_NRMFDCAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PRODUVG-DTMVFDCAP    PIC X(10).*/
        public StringBasis PRODUVG_DTMVFDCAP { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 PRODUVG-NRNSAF       PIC S9(4) USAGE COMP.*/
        public IntBasis PRODUVG_NRNSAF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PRODUVG-NLMSAF       PIC S9(9) USAGE COMP.*/
        public IntBasis PRODUVG_NLMSAF { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 PRODUVG-TEM-CDG      PIC X(1).*/
        public StringBasis PRODUVG_TEM_CDG { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 PRODUVG-PRI-CDG      PIC X(1).*/
        public StringBasis PRODUVG_PRI_CDG { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 PRODUVG-TEM-SAF      PIC X(1).*/
        public StringBasis PRODUVG_TEM_SAF { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 PRODUVG-PRI-SAF      PIC X(1).*/
        public StringBasis PRODUVG_PRI_SAF { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 PRODUVG-CODEMPRSA    PIC S9(9) USAGE COMP.*/
        public IntBasis PRODUVG_CODEMPRSA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 PRODUVG-NRMATRSA     PIC S9(9) USAGE COMP.*/
        public IntBasis PRODUVG_NRMATRSA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 PRODUVG-DTAVERB      PIC X(10).*/
        public StringBasis PRODUVG_DTAVERB { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 PRODUVG-COD-RUBRICA  PIC S9(4) USAGE COMP.*/
        public IntBasis PRODUVG_COD_RUBRICA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PRODUVG-COD-CCT      PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis PRODUVG_COD_CCT { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 PRODUVG-TRANSF-SUBGRUPO  PIC X(1).*/
        public StringBasis PRODUVG_TRANSF_SUBGRUPO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 PRODUVG-DIA-FATURA   PIC S9(4) USAGE COMP.*/
        public IntBasis PRODUVG_DIA_FATURA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PRODUVG-ARQ-FDCAP    PIC S9(4) USAGE COMP.*/
        public IntBasis PRODUVG_ARQ_FDCAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PRODUVG-ESTR-COBR    PIC X(10).*/
        public StringBasis PRODUVG_ESTR_COBR { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 PRODUVG-ESTR-EMISS   PIC X(10).*/
        public StringBasis PRODUVG_ESTR_EMISS { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 PRODUVG-ORIG-PRODU   PIC X(10).*/
        public StringBasis PRODUVG_ORIG_PRODU { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 PRODUVG-COD-AGENCIADOR  PIC S9(9) USAGE COMP.*/
        public IntBasis PRODUVG_COD_AGENCIADOR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 PRODUVG-MOV-INTERFACE  PIC X(1).*/
        public StringBasis PRODUVG_MOV_INTERFACE { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 PRODUVG-CONSISTE-MATRIC  PIC X(1).*/
        public StringBasis PRODUVG_CONSISTE_MATRIC { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 PRODUVG-RISCO        PIC X(1).*/
        public StringBasis PRODUVG_RISCO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 PRODUVG-COD-SEGURADORA  PIC S9(4) USAGE COMP.*/
        public IntBasis PRODUVG_COD_SEGURADORA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PRODUVG-COD-SEGU-SAF  PIC S9(4) USAGE COMP.*/
        public IntBasis PRODUVG_COD_SEGU_SAF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PRODUVG-CODRELAT     PIC X(8).*/
        public StringBasis PRODUVG_CODRELAT { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 PRODUVG-TEM-FAIXAETA  PIC X(1).*/
        public StringBasis PRODUVG_TEM_FAIXAETA { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 PRODUVG-TEM-IGPM     PIC X(1).*/
        public StringBasis PRODUVG_TEM_IGPM { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 PRODUVG-ROT-SAF      PIC X(10).*/
        public StringBasis PRODUVG_ROT_SAF { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 PRODUVG-COD-PRODUTO-EA  PIC X(2).*/
        public StringBasis PRODUVG_COD_PRODUTO_EA { get; set; } = new StringBasis(new PIC("X", "2", "X(2)."), @"");
        /*"    10 PRODUVG-COBERADIC-PREMIO  PIC X(1).*/
        public StringBasis PRODUVG_COBERADIC_PREMIO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 PRODUVG-CUSTOCAP-TOTAL  PIC X(1).*/
        public StringBasis PRODUVG_CUSTOCAP_TOTAL { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 PRODUVG-DESCONTO-ADESAO  PIC S9(3)V9(5) USAGE COMP-3.*/
        public DoubleBasis PRODUVG_DESCONTO_ADESAO { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(5)"), 5);
        /*"    10 PRODUVG-QTD-ANO-REMISSAO  PIC S9(4) USAGE COMP.*/
        public IntBasis PRODUVG_QTD_ANO_REMISSAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"*/
    }
}