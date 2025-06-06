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
    public class PRODVG_DCLPRODUTOS_VG : VarBasis
    {
        /*"    10 NUM-APOLICE          PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis NUM_APOLICE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 COD-SUBGRUPO         PIC S9(4) USAGE COMP.*/
        public IntBasis COD_SUBGRUPO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 ID-SISTEMA           PIC X(2).*/
        public StringBasis ID_SISTEMA { get; set; } = new StringBasis(new PIC("X", "2", "X(2)."), @"");
        /*"    10 COD-PRODUTO-AZUL     PIC X(3).*/
        public StringBasis COD_PRODUTO_AZUL { get; set; } = new StringBasis(new PIC("X", "3", "X(3)."), @"");
        /*"    10 COD-PRODUTO          PIC S9(4) USAGE COMP.*/
        public IntBasis COD_PRODUTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 NOME-PRODUTO         PIC X(30).*/
        public StringBasis NOME_PRODUTO { get; set; } = new StringBasis(new PIC("X", "30", "X(30)."), @"");
        /*"    10 PERI-PAGAMENTO       PIC S9(4) USAGE COMP.*/
        public IntBasis PERI_PAGAMENTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 DIAS-INICIO-VIGENC   PIC S9(4) USAGE COMP.*/
        public IntBasis DIAS_INICIO_VIGENC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 DATA-MINVIGENCIA     PIC X(10).*/
        public StringBasis DATA_MINVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 DATA-MAXVIGENCIA     PIC X(10).*/
        public StringBasis DATA_MAXVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 SIT-PLANO-CEF        PIC X(1).*/
        public StringBasis SIT_PLANO_CEF { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 OPCAO-PAGAMENTO      PIC X(1).*/
        public StringBasis OPCAO_PAGAMENTO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 COD-CEDENTE          PIC S9(4) USAGE COMP.*/
        public IntBasis COD_CEDENTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 OPC-AGENCTO-SUREG    PIC X(1).*/
        public StringBasis OPC_AGENCTO_SUREG { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 OPCAO-CAPITALIZ      PIC S9(4) USAGE COMP.*/
        public IntBasis OPCAO_CAPITALIZ { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 COD-SERIE            PIC X(1).*/
        public StringBasis COD_SERIE { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 NUM-SEQ-TITULO       PIC S9(9) USAGE COMP.*/
        public IntBasis NUM_SEQ_TITULO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 NUM-MALA-DIRETA      PIC S9(4) USAGE COMP.*/
        public IntBasis NUM_MALA_DIRETA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 RAMO                 PIC S9(4) USAGE COMP.*/
        public IntBasis RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 CANCELA-ANTIGO       PIC X(1).*/
        public StringBasis CANCELA_ANTIGO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 IND-RCAP             PIC X(1).*/
        public StringBasis IND_RCAP { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 NRMSCAP              PIC S9(4) USAGE COMP.*/
        public IntBasis NRMSCAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 NRMFDCAP             PIC S9(4) USAGE COMP.*/
        public IntBasis NRMFDCAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 DTMVFDCAP            PIC X(10).*/
        public StringBasis DTMVFDCAP { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 NRNSAF               PIC S9(4) USAGE COMP.*/
        public IntBasis NRNSAF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 NLMSAF               PIC S9(9) USAGE COMP.*/
        public IntBasis NLMSAF { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 TEM-CDG              PIC X(1).*/
        public StringBasis TEM_CDG { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 PRI-CDG              PIC X(1).*/
        public StringBasis PRI_CDG { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 TEM-SAF              PIC X(1).*/
        public StringBasis TEM_SAF { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 PRI-SAF              PIC X(1).*/
        public StringBasis PRI_SAF { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 CODEMPRSA            PIC S9(9) USAGE COMP.*/
        public IntBasis CODEMPRSA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 NRMATRSA             PIC S9(9) USAGE COMP.*/
        public IntBasis NRMATRSA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 DTAVERB              PIC X(10).*/
        public StringBasis DTAVERB { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 COD-RUBRICA          PIC S9(4) USAGE COMP.*/
        public IntBasis COD_RUBRICA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 COD-CCT              PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis COD_CCT { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 TRANSF-SUBGRUPO      PIC X(1).*/
        public StringBasis TRANSF_SUBGRUPO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 DIA-FATURA           PIC S9(4) USAGE COMP.*/
        public IntBasis DIA_FATURA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 ARQ-FDCAP            PIC S9(4) USAGE COMP.*/
        public IntBasis ARQ_FDCAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 ESTR-COBR            PIC X(10).*/
        public StringBasis ESTR_COBR { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 ESTR-EMISS           PIC X(10).*/
        public StringBasis ESTR_EMISS { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 ORIG-PRODU           PIC X(10).*/
        public StringBasis ORIG_PRODU { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 COD-AGENCIADOR       PIC S9(9) USAGE COMP.*/
        public IntBasis COD_AGENCIADOR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 CONSISTE-MATRIC      PIC X(1).*/
        public StringBasis CONSISTE_MATRIC { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 MOV-INTERFACE        PIC X(1).*/
        public StringBasis MOV_INTERFACE { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 RISCO                PIC X(1).*/
        public StringBasis RISCO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 COD-SEGURADORA       PIC S9(4) USAGE COMP.*/
        public IntBasis COD_SEGURADORA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 COD-SEGU-SAF         PIC S9(4) USAGE COMP.*/
        public IntBasis COD_SEGU_SAF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 CODRELAT             PIC X(8).*/
        public StringBasis CODRELAT { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 TEM-FAIXAETA         PIC X(1).*/
        public StringBasis TEM_FAIXAETA { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 TEM-IGPM             PIC X(1).*/
        public StringBasis TEM_IGPM { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 ROT-SAF              PIC X(10).*/
        public StringBasis ROT_SAF { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 COD-PRODUTO-EA       PIC X(2).*/
        public StringBasis COD_PRODUTO_EA { get; set; } = new StringBasis(new PIC("X", "2", "X(2)."), @"");
        /*"*/
    }
}