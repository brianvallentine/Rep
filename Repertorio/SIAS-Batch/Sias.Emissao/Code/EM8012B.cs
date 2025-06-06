using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;
using Dclgens;
using Copies;
using Sias.Emissao.DB2.EM8012B;

namespace Code
{
    public class EM8012B
    {
        public bool IsCall { get; set; }

        public EM8012B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------                                 */
        /*"      *                                                                       */
        /*"      *                                                                       */
        /*"      *-DIEGO----------------------------------------------------------*      */
        /*"      *   SISTEMA ................  COBRANCA                           *      */
        /*"      *   PROGRAMA ...............  EM8012B                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA DE REQUISITOS..  CLOVIS                             *      */
        /*"      *   PROGRAMADOR ............  CLOVIS                             *      */
        /*"      *   CADMUS .... ............  XX.XXX    (PROJETO BANCOOB)        *      */
        /*"      *   DATA CODIFICACAO .......  06/06/2011                         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO .................  GERACAO DE ARQUIVOS DO LATOUT      *      */
        /*"      *                             ARQUIVO H PARA O CNAB ( SICOB )    *      */
        /*"      *                             BANCOOB.                           *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *    AVALIADO PELO PROJETO JV1 EM 16/01/2019                     *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * NO   VERSAO    DATA       PROGRAMADOR      ALTERACAO           *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * 1.    1.0    06/06/2011   CLOVIS           CODIFICACAO         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * 2.    2.0    09/11/2011   PATRICIA SALES   "ROMINA, SEGUE      *      */
        /*"      * RESPOSTA DO BANCOOB COM RELACAO DO CAMPO: O NUMERO CONVENENTE -*      */
        /*"      * LIDER (NUMERO CONVENIO), NO HEADER DO ARQUIVO, NAO RECEBE      *      */
        /*"      * QUALQUER TRATAMENTO DE GRAVACAO NO SISTEMA, APESAR DE RETORNAR *      */
        /*"      * O NUMERO DA CONTA CORRENTE DO CEDENTE, AINDA COM 6 POSICOES.   *      */
        /*"      * ENTAO ESSE CAMPO(11), POSICOES (45 A 46) DEVERA SER            *      */
        /*"      * DESCONSIDERADO. PORTANTO O PARECER EH QUE O CAMPO NAO DEVE SER *      */
        /*"      * REGISTRADO NO CAP. ATT. DIEGO GIRON.                           *      */
        /*"      * EMAIL ENVIADO EM 01/11/2011.                   PROCURE V.02    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * 3.    3.0    24/01/2012   TERCIO FREITAS                       *      */
        /*"      * AJUSTE AO MONTAR O NUMERO DE AVISO BANCOOB.    PROCURE V.03    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 04 -   NSGD - CADMUS 103659.                          *      */
        /*"      *               - NOVA SOLUCAO DE GESTAO DE DEPOSITOS            *      */
        /*"      *                                                                *      */
        /*"      *   EM 30/04/2015 - COREON                                       *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.04         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        #endregion


        #region VARIABLES

        public FileBasis _ENTRADA { get; set; } = new FileBasis(new PIC("X", "400", "X(400)"));

        public FileBasis ENTRADA
        {
            get
            {
                _.Move(REG_ENTRADA, _ENTRADA); VarBasis.RedefinePassValue(REG_ENTRADA, _ENTRADA, REG_ENTRADA); return _ENTRADA;
            }
        }
        public FileBasis _SAIDA01 { get; set; } = new FileBasis(new PIC("X", "400", "X(400)"));

        public FileBasis SAIDA01
        {
            get
            {
                _.Move(REG_SAIDA01, _SAIDA01); VarBasis.RedefinePassValue(REG_SAIDA01, _SAIDA01, REG_SAIDA01); return _SAIDA01;
            }
        }
        public FileBasis _SAIDA02 { get; set; } = new FileBasis(new PIC("X", "400", "X(400)"));

        public FileBasis SAIDA02
        {
            get
            {
                _.Move(REG_SAIDA02, _SAIDA02); VarBasis.RedefinePassValue(REG_SAIDA02, _SAIDA02, REG_SAIDA02); return _SAIDA02;
            }
        }
        public FileBasis _SAIDA03 { get; set; } = new FileBasis(new PIC("X", "400", "X(400)"));

        public FileBasis SAIDA03
        {
            get
            {
                _.Move(REG_SAIDA03, _SAIDA03); VarBasis.RedefinePassValue(REG_SAIDA03, _SAIDA03, REG_SAIDA03); return _SAIDA03;
            }
        }
        public SortBasis<EM8012B_REG_ARQSORT> ARQSORT { get; set; } = new SortBasis<EM8012B_REG_ARQSORT>(new EM8012B_REG_ARQSORT());
        /*"01        REG-ARQSORT.*/
        public EM8012B_REG_ARQSORT REG_ARQSORT { get; set; } = new EM8012B_REG_ARQSORT();
        public class EM8012B_REG_ARQSORT : VarBasis
        {
            /*"  10      SOR-TIPO-ARQUIVO         PIC  X(010).*/
            public StringBasis SOR_TIPO_ARQUIVO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  10      SOR-COD-REGISTRO         PIC  9(001).*/
            public IntBasis SOR_COD_REGISTRO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"  10      SOR-TIPO-INSCRICAO       PIC  9(002).*/
            public IntBasis SOR_TIPO_INSCRICAO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"  10      SOR-NUM-INSCRICAO        PIC  9(014).*/
            public IntBasis SOR_NUM_INSCRICAO { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
            /*"  10      SOR-COD-AGENCIA          PIC  9(004).*/
            public IntBasis SOR_COD_AGENCIA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  10      SOR-DIG-AGENCIA          PIC  9(001).*/
            public IntBasis SOR_DIG_AGENCIA { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"  10      SOR-NRO-CONTA            PIC  9(012).*/
            public IntBasis SOR_NRO_CONTA { get; set; } = new IntBasis(new PIC("9", "12", "9(012)."));
            /*"  10      SOR-DIG-CONTA            PIC  9(001).*/
            public IntBasis SOR_DIG_CONTA { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"  10      SOR-CEDENTE              PIC  9(008).*/
            public IntBasis SOR_CEDENTE { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"  10      SOR-CONVENIO             PIC  9(006).*/
            public IntBasis SOR_CONVENIO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"  10      SOR-CONTROLE             PIC  X(025).*/
            public StringBasis SOR_CONTROLE { get; set; } = new StringBasis(new PIC("X", "25", "X(025)."), @"");
            /*"  10      SOR-NRO-TITULO           PIC  9(011).*/
            public IntBasis SOR_NRO_TITULO { get; set; } = new IntBasis(new PIC("9", "11", "9(011)."));
            /*"  10      SOR-DIG-TITULO           PIC  9(001).*/
            public IntBasis SOR_DIG_TITULO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"  10      SOR-NRO-PARCELA          PIC  9(002).*/
            public IntBasis SOR_NRO_PARCELA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"  10      SOR-DIAS-CALCULO         PIC  9(004).*/
            public IntBasis SOR_DIAS_CALCULO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  10      SOR-MOTIVO               PIC  9(002).*/
            public IntBasis SOR_MOTIVO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"  10      SOR-PREFIXO              PIC  X(003).*/
            public StringBasis SOR_PREFIXO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
            /*"  10      SOR-VARIACAO             PIC  9(003).*/
            public IntBasis SOR_VARIACAO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
            /*"  10      SOR-CAUCAO               PIC  9(001).*/
            public IntBasis SOR_CAUCAO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"  10      SOR-RESPONSABIL          PIC  9(005).*/
            public IntBasis SOR_RESPONSABIL { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
            /*"  10      SOR-DIGITO               PIC  9(001).*/
            public IntBasis SOR_DIGITO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"  10      SOR-TAXA-DESCON          PIC  9(003)V99.*/
            public DoubleBasis SOR_TAXA_DESCON { get; set; } = new DoubleBasis(new PIC("9", "3", "9(003)V99."), 2);
            /*"  10      SOR-TAXA-IOF             PIC  9(001)V9999.*/
            public DoubleBasis SOR_TAXA_IOF { get; set; } = new DoubleBasis(new PIC("9", "1", "9(001)V9999."), 4);
            /*"  10      FILLER                   PIC  X(001).*/
            public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  10      SOR-CARTEIRA             PIC  9(002).*/
            public IntBasis SOR_CARTEIRA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"  10      SOR-COMANDO              PIC  9(002).*/
            public IntBasis SOR_COMANDO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"  10      SOR-DTLIQUIDA.*/
            public EM8012B_SOR_DTLIQUIDA SOR_DTLIQUIDA { get; set; } = new EM8012B_SOR_DTLIQUIDA();
            public class EM8012B_SOR_DTLIQUIDA : VarBasis
            {
                /*"    15    SOR-DIA-LIQUIDA          PIC  9(002).*/
                public IntBasis SOR_DIA_LIQUIDA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    15    SOR-MES-LIQUIDA          PIC  9(002).*/
                public IntBasis SOR_MES_LIQUIDA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    15    SOR-ANO-LIQUIDA          PIC  9(002).*/
                public IntBasis SOR_ANO_LIQUIDA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  10      SOR-SEU-NUMERO           PIC  X(010).*/
            }
            public StringBasis SOR_SEU_NUMERO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  10      FILLER                   PIC  X(020).*/
            public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
            /*"  10      SOR-DTVENCTO.*/
            public EM8012B_SOR_DTVENCTO SOR_DTVENCTO { get; set; } = new EM8012B_SOR_DTVENCTO();
            public class EM8012B_SOR_DTVENCTO : VarBasis
            {
                /*"    15    SOR-DIA-VENCTO           PIC  9(002).*/
                public IntBasis SOR_DIA_VENCTO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    15    SOR-MES-VENCTO           PIC  9(002).*/
                public IntBasis SOR_MES_VENCTO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    15    SOR-ANO-VENCTO           PIC  9(002).*/
                public IntBasis SOR_ANO_VENCTO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  10      SOR-VLR-NOMINAL-TIT      PIC  9(011)V99.*/
            }
            public DoubleBasis SOR_VLR_NOMINAL_TIT { get; set; } = new DoubleBasis(new PIC("9", "11", "9(011)V99."), 2);
            /*"  10      SOR-COD-BANCO            PIC  9(003).*/
            public IntBasis SOR_COD_BANCO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
            /*"  10      SOR-AGE-COBR             PIC  9(004).*/
            public IntBasis SOR_AGE_COBR { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  10      SOR-AGE-DIG-COBR         PIC  9(001).*/
            public IntBasis SOR_AGE_DIG_COBR { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"  10      SOR-ESPECIE              PIC  9(002).*/
            public IntBasis SOR_ESPECIE { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"  10      SOR-DATA-CREDITO.*/
            public EM8012B_SOR_DATA_CREDITO SOR_DATA_CREDITO { get; set; } = new EM8012B_SOR_DATA_CREDITO();
            public class EM8012B_SOR_DATA_CREDITO : VarBasis
            {
                /*"    15    SOR-DIA-CRED             PIC  9(002).*/
                public IntBasis SOR_DIA_CRED { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    15    SOR-MES-CRED             PIC  9(002).*/
                public IntBasis SOR_MES_CRED { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    15    SOR-ANO-CRED             PIC  9(002).*/
                public IntBasis SOR_ANO_CRED { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  10      SOR-VLR-TARIFA           PIC  9(005)V99.*/
            }
            public DoubleBasis SOR_VLR_TARIFA { get; set; } = new DoubleBasis(new PIC("9", "5", "9(005)V99."), 2);
            /*"  10      SOR-VLR-DESPESAS         PIC  9(011)V99.*/
            public DoubleBasis SOR_VLR_DESPESAS { get; set; } = new DoubleBasis(new PIC("9", "11", "9(011)V99."), 2);
            /*"  10      SOR-VLR-JUROS            PIC  9(011)V99.*/
            public DoubleBasis SOR_VLR_JUROS { get; set; } = new DoubleBasis(new PIC("9", "11", "9(011)V99."), 2);
            /*"  10      SOR-VLR-IOF              PIC  9(011)V99.*/
            public DoubleBasis SOR_VLR_IOF { get; set; } = new DoubleBasis(new PIC("9", "11", "9(011)V99."), 2);
            /*"  10      SOR-VLR-ABATIMENTO       PIC  9(011)V99.*/
            public DoubleBasis SOR_VLR_ABATIMENTO { get; set; } = new DoubleBasis(new PIC("9", "11", "9(011)V99."), 2);
            /*"  10      SOR-VLR-DESCONTO         PIC  9(011)V99.*/
            public DoubleBasis SOR_VLR_DESCONTO { get; set; } = new DoubleBasis(new PIC("9", "11", "9(011)V99."), 2);
            /*"  10      SOR-VLR-RECEBIDO         PIC  9(011)V99.*/
            public DoubleBasis SOR_VLR_RECEBIDO { get; set; } = new DoubleBasis(new PIC("9", "11", "9(011)V99."), 2);
            /*"  10      SOR-VLR-MORA             PIC  9(011)V99.*/
            public DoubleBasis SOR_VLR_MORA { get; set; } = new DoubleBasis(new PIC("9", "11", "9(011)V99."), 2);
            /*"  10      SOR-VLR-OUTROS           PIC  9(011)V99.*/
            public DoubleBasis SOR_VLR_OUTROS { get; set; } = new DoubleBasis(new PIC("9", "11", "9(011)V99."), 2);
            /*"  10      SOR-VLR-ABATNAO          PIC  9(011)V99.*/
            public DoubleBasis SOR_VLR_ABATNAO { get; set; } = new DoubleBasis(new PIC("9", "11", "9(011)V99."), 2);
            /*"  10      SOR-VLR-LANCADO          PIC  9(011)V99.*/
            public DoubleBasis SOR_VLR_LANCADO { get; set; } = new DoubleBasis(new PIC("9", "11", "9(011)V99."), 2);
            /*"  10      SOR-IND-DEBCRE           PIC  9(001).*/
            public IntBasis SOR_IND_DEBCRE { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"  10      SOR-IND-VALOR            PIC  9(001).*/
            public IntBasis SOR_IND_VALOR { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"  10      SOR-VLR-AJUSTE           PIC  9(010)V99.*/
            public DoubleBasis SOR_VLR_AJUSTE { get; set; } = new DoubleBasis(new PIC("9", "10", "9(010)V99."), 2);
            /*"  10      FILLER                   PIC  X(010).*/
            public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  10      SOR-BANCO                PIC  9(003).*/
            public IntBasis SOR_BANCO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
            /*"  10      SOR-DIGBCO               PIC  9(001).*/
            public IntBasis SOR_DIGBCO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"  10      SOR-NSAC                 PIC  9(006).*/
            public IntBasis SOR_NSAC { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"  10      SOR-DTGERACAO.*/
            public EM8012B_SOR_DTGERACAO SOR_DTGERACAO { get; set; } = new EM8012B_SOR_DTGERACAO();
            public class EM8012B_SOR_DTGERACAO : VarBasis
            {
                /*"    15    SOR-DIA-HEADER           PIC  9(002).*/
                public IntBasis SOR_DIA_HEADER { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    15    SOR-MES-HEADER           PIC  9(002).*/
                public IntBasis SOR_MES_HEADER { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    15    SOR-ANO-HEADER           PIC  9(002).*/
                public IntBasis SOR_ANO_HEADER { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"01        REG-ENTRADA              PIC  X(400).*/
            }
        }
        public StringBasis REG_ENTRADA { get; set; } = new StringBasis(new PIC("X", "400", "X(400)."), @"");
        /*"01        REG-SAIDA01                 PIC  X(400).*/
        public StringBasis REG_SAIDA01 { get; set; } = new StringBasis(new PIC("X", "400", "X(400)."), @"");
        /*"01        REG-SAIDA02                 PIC  X(400).*/
        public StringBasis REG_SAIDA02 { get; set; } = new StringBasis(new PIC("X", "400", "X(400)."), @"");
        /*"01        REG-SAIDA03                 PIC  X(400).*/
        public StringBasis REG_SAIDA03 { get; set; } = new StringBasis(new PIC("X", "400", "X(400)."), @"");

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77    V0CNAB-COD-EMP            PIC S9(009)    VALUE +0   COMP.*/
        public IntBasis V0CNAB_COD_EMP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    V0CNAB-ORGAO              PIC S9(004)    VALUE +0   COMP.*/
        public IntBasis V0CNAB_ORGAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0CNAB-NRCTACED           PIC S9(021)    VALUE +0   COMP-3*/
        public IntBasis V0CNAB_NRCTACED { get; set; } = new IntBasis(new PIC("S9", "21", "S9(021)"));
        /*"77    V0CNAB-TIPOCOB            PIC  X(001).*/
        public StringBasis V0CNAB_TIPOCOB { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77    V0CNAB-DTMOVTO            PIC  X(010).*/
        public StringBasis V0CNAB_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    V0CNAB-DATCEF             PIC  X(010).*/
        public StringBasis V0CNAB_DATCEF { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    V0CNAB-NRSEQ              PIC S9(009)    VALUE +0   COMP.*/
        public IntBasis V0CNAB_NRSEQ { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    V0CNAB-QTDREG             PIC S9(004)    VALUE +0   COMP.*/
        public IntBasis V0CNAB_QTDREG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    WSHOST-NRAVISO1           PIC S9(009)    VALUE +0   COMP.*/
        public IntBasis WSHOST_NRAVISO1 { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    WSHOST-NRAVISO2           PIC S9(009)    VALUE +0   COMP.*/
        public IntBasis WSHOST_NRAVISO2 { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01  W.*/
        public EM8012B_W W { get; set; } = new EM8012B_W();
        public class EM8012B_W : VarBasis
        {
            /*"  03  WFIM-MOVIMENTO            PIC  X(001)    VALUE  'N'.*/
            public StringBasis WFIM_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
            /*"  03  LD-MOVIMENTO              PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis LD_MOVIMENTO { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  DP-MOVIMENTO              PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis DP_MOVIMENTO { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  GV-SORT                   PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis GV_SORT { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  WFIM-SORT                 PIC  X(001)    VALUE  'N'.*/
            public StringBasis WFIM_SORT { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
            /*"  03  LD-SORT                   PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis LD_SORT { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  ATU-COD-CEDENTE           PIC  9(016)    VALUE   ZEROS.*/
            public IntBasis ATU_COD_CEDENTE { get; set; } = new IntBasis(new PIC("9", "16", "9(016)"));
            /*"  03  ANT-COD-CEDENTE           PIC  9(016)    VALUE   ZEROS.*/
            public IntBasis ANT_COD_CEDENTE { get; set; } = new IntBasis(new PIC("9", "16", "9(016)"));
            /*"  03  AC-GRAV-SAIDA01           PIC  9(009)    VALUE   ZEROS.*/
            public IntBasis AC_GRAV_SAIDA01 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  AC-GRAV-SAIDA02           PIC  9(009)    VALUE   ZEROS.*/
            public IntBasis AC_GRAV_SAIDA02 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  AC-GRAV-SAIDA03           PIC  9(009)    VALUE   ZEROS.*/
            public IntBasis AC_GRAV_SAIDA03 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  WS-NRSEQ                  PIC  9(009)    VALUE   ZEROS.*/
            public IntBasis WS_NRSEQ { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03         WS0-NRAVISO        PIC  9(009)    VALUE   ZEROS.*/
            public IntBasis WS0_NRAVISO { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03         FILLER             REDEFINES      WS0-NRAVISO.*/
            private _REDEF_EM8012B_FILLER_3 _filler_3 { get; set; }
            public _REDEF_EM8012B_FILLER_3 FILLER_3
            {
                get { _filler_3 = new _REDEF_EM8012B_FILLER_3(); _.Move(WS0_NRAVISO, _filler_3); VarBasis.RedefinePassValue(WS0_NRAVISO, _filler_3, WS0_NRAVISO); _filler_3.ValueChanged += () => { _.Move(_filler_3, WS0_NRAVISO); }; return _filler_3; }
                set { VarBasis.RedefinePassValue(value, _filler_3, WS0_NRAVISO); }
            }  //Redefines
            public class _REDEF_EM8012B_FILLER_3 : VarBasis
            {
                /*"    10       DS0-PRE-AVISO      PIC  9(004).*/
                public IntBasis DS0_PRE_AVISO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       WS0-NRO-NSAC       PIC  9(005).*/
                public IntBasis WS0_NRO_NSAC { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                /*"  03         WDATA-CABEC.*/

                public _REDEF_EM8012B_FILLER_3()
                {
                    DS0_PRE_AVISO.ValueChanged += OnValueChanged;
                    WS0_NRO_NSAC.ValueChanged += OnValueChanged;
                }

            }
            public EM8012B_WDATA_CABEC WDATA_CABEC { get; set; } = new EM8012B_WDATA_CABEC();
            public class EM8012B_WDATA_CABEC : VarBasis
            {
                /*"    05       WDATA-DD-CABEC    PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WDATA_DD_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    05       FILLER            PIC  X(001)    VALUE '/'.*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    05       WDATA-MM-CABEC    PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WDATA_MM_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    05       FILLER            PIC  X(001)    VALUE '/'.*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    05       WDATA-AA-CABEC    PIC  9(004)    VALUE ZEROS.*/
                public IntBasis WDATA_AA_CABEC { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"  03         WDATA-REL          PIC  X(010)    VALUE   SPACES.*/
            }
            public StringBasis WDATA_REL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  03         FILLER             REDEFINES      WDATA-REL.*/
            private _REDEF_EM8012B_FILLER_6 _filler_6 { get; set; }
            public _REDEF_EM8012B_FILLER_6 FILLER_6
            {
                get { _filler_6 = new _REDEF_EM8012B_FILLER_6(); _.Move(WDATA_REL, _filler_6); VarBasis.RedefinePassValue(WDATA_REL, _filler_6, WDATA_REL); _filler_6.ValueChanged += () => { _.Move(_filler_6, WDATA_REL); }; return _filler_6; }
                set { VarBasis.RedefinePassValue(value, _filler_6, WDATA_REL); }
            }  //Redefines
            public class _REDEF_EM8012B_FILLER_6 : VarBasis
            {
                /*"    10       WDAT-REL-ANO       PIC  9(004).*/
                public IntBasis WDAT_REL_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       FILLER             PIC  X(001).*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDAT-REL-MES       PIC  9(002).*/
                public IntBasis WDAT_REL_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       FILLER             PIC  X(001).*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDAT-REL-DIA       PIC  9(002).*/
                public IntBasis WDAT_REL_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"01  ABEN.*/

                public _REDEF_EM8012B_FILLER_6()
                {
                    WDAT_REL_ANO.ValueChanged += OnValueChanged;
                    FILLER_7.ValueChanged += OnValueChanged;
                    WDAT_REL_MES.ValueChanged += OnValueChanged;
                    FILLER_8.ValueChanged += OnValueChanged;
                    WDAT_REL_DIA.ValueChanged += OnValueChanged;
                }

            }
        }
        public EM8012B_ABEN ABEN { get; set; } = new EM8012B_ABEN();
        public class EM8012B_ABEN : VarBasis
        {
            /*"  03        WABEND.*/
            public EM8012B_WABEND WABEND { get; set; } = new EM8012B_WABEND();
            public class EM8012B_WABEND : VarBasis
            {
                /*"    05      FILLER              PIC  X(010) VALUE           ' EM8012B  '.*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" EM8012B  ");
                /*"    05      FILLER              PIC  X(028) VALUE           ' *** ERRO  EXEC SQL  NUMERO '.*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @" *** ERRO  EXEC SQL  NUMERO ");
                /*"    05      WNR-EXEC-SQL        PIC  X(040) VALUE    SPACES.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"  03        WABEND1.*/
            }
            public EM8012B_WABEND1 WABEND1 { get; set; } = new EM8012B_WABEND1();
            public class EM8012B_WABEND1 : VarBasis
            {
                /*"    05      FILLER              PIC  X(011) VALUE           ' SQLCODE = '.*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @" SQLCODE = ");
                /*"    05      WSQLCODE            PIC  ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                /*"    05      FILLER              PIC  X(012) VALUE           ' SQLERRD1 = '.*/
                public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @" SQLERRD1 = ");
                /*"    05      WSQLERRD1           PIC  ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLERRD1 { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                /*"    05      FILLER              PIC  X(012) VALUE           ' SQLERRD2 = '.*/
                public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @" SQLERRD2 = ");
                /*"    05      WSQLERRD2           PIC  ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLERRD2 { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                /*"01        HEADER-REGISTRO.*/
            }
        }
        public EM8012B_HEADER_REGISTRO HEADER_REGISTRO { get; set; } = new EM8012B_HEADER_REGISTRO();
        public class EM8012B_HEADER_REGISTRO : VarBasis
        {
            /*"  05      HEADER-CODREGISTR        PIC  X(001).*/
            public StringBasis HEADER_CODREGISTR { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  05      HEADER-CODRETORNO        PIC  X(001).*/
            public StringBasis HEADER_CODRETORNO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  05      HEADER-LITRETORNO        PIC  X(007).*/
            public StringBasis HEADER_LITRETORNO { get; set; } = new StringBasis(new PIC("X", "7", "X(007)."), @"");
            /*"  05      HEADER-CODSERVICO        PIC  X(002).*/
            public StringBasis HEADER_CODSERVICO { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
            /*"  05      HEADER-LITSERVICO        PIC  X(008).*/
            public StringBasis HEADER_LITSERVICO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"  05      FILLER                   PIC  X(007).*/
            public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)."), @"");
            /*"  05      HEADER-COD-AGENCIA       PIC  9(004).*/
            public IntBasis HEADER_COD_AGENCIA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05      HEADER-DIG-AGENCIA       PIC  9(001).*/
            public IntBasis HEADER_DIG_AGENCIA { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"  05      HEADER-CEDENTE           PIC  9(009).*/
            public IntBasis HEADER_CEDENTE { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"  05      HEADER-CONVENIO          PIC  9(006).*/
            public IntBasis HEADER_CONVENIO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"  05      HEADER-NOMEMPRESA        PIC  X(030).*/
            public StringBasis HEADER_NOMEMPRESA { get; set; } = new StringBasis(new PIC("X", "30", "X(030)."), @"");
            /*"  05      HEADER-CODBANCO          PIC  X(003).*/
            public StringBasis HEADER_CODBANCO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
            /*"  05      HEADER-NOMEBANCO         PIC  X(015).*/
            public StringBasis HEADER_NOMEBANCO { get; set; } = new StringBasis(new PIC("X", "15", "X(015)."), @"");
            /*"  05      HEADER-DTGERACAO         PIC  X(006).*/
            public StringBasis HEADER_DTGERACAO { get; set; } = new StringBasis(new PIC("X", "6", "X(006)."), @"");
            /*"  05      HEADER-NUMFITA           PIC  9(007).*/
            public IntBasis HEADER_NUMFITA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)."));
            /*"  05      FILLER                   PIC  X(287).*/
            public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "287", "X(287)."), @"");
            /*"  05      HEADER-NRSEQ             PIC  9(006).*/
            public IntBasis HEADER_NRSEQ { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"01        COBRAN-REGISTRO.*/
        }
        public EM8012B_COBRAN_REGISTRO COBRAN_REGISTRO { get; set; } = new EM8012B_COBRAN_REGISTRO();
        public class EM8012B_COBRAN_REGISTRO : VarBasis
        {
            /*"  05      COBRAN-COD-REGISTRO      PIC  X(001).*/
            public StringBasis COBRAN_COD_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  05      COBRAN-TIPO-INSCRICAO    PIC  9(002).*/
            public IntBasis COBRAN_TIPO_INSCRICAO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"  05      COBRAN-NUM-INSCRICAO     PIC  9(014).*/
            public IntBasis COBRAN_NUM_INSCRICAO { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
            /*"  05      COBRAN-COD-AGENCIA       PIC  9(004).*/
            public IntBasis COBRAN_COD_AGENCIA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05      COBRAN-DIG-AGENCIA       PIC  9(001).*/
            public IntBasis COBRAN_DIG_AGENCIA { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"  05      COBRAN-NRO-CONTA         PIC  9(012).*/
            public IntBasis COBRAN_NRO_CONTA { get; set; } = new IntBasis(new PIC("9", "12", "9(012)."));
            /*"  05      COBRAN-DIG-CONTA         PIC  9(001).*/
            public IntBasis COBRAN_DIG_CONTA { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"  05      COBRAN-CONVENIO          PIC  9(006).*/
            public IntBasis COBRAN_CONVENIO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"  05      COBRAN-CONTROLE          PIC  X(025).*/
            public StringBasis COBRAN_CONTROLE { get; set; } = new StringBasis(new PIC("X", "25", "X(025)."), @"");
            /*"  05      COBRAN-NRO-TITULO        PIC  9(011).*/
            public IntBasis COBRAN_NRO_TITULO { get; set; } = new IntBasis(new PIC("9", "11", "9(011)."));
            /*"  05      COBRAN-DIG-TITULO        PIC  9(001).*/
            public IntBasis COBRAN_DIG_TITULO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"  05      COBRAN-NRO-PARCELA       PIC  9(002).*/
            public IntBasis COBRAN_NRO_PARCELA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"  05      COBRAN-DIAS-CALCULO      PIC  9(004).*/
            public IntBasis COBRAN_DIAS_CALCULO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05      COBRAN-MOTIVO            PIC  9(002).*/
            public IntBasis COBRAN_MOTIVO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"  05      COBRAN-PREFIXO           PIC  X(003).*/
            public StringBasis COBRAN_PREFIXO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
            /*"  05      COBRAN-VARIACAO          PIC  9(003).*/
            public IntBasis COBRAN_VARIACAO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
            /*"  05      COBRAN-CAUCAO            PIC  9(001).*/
            public IntBasis COBRAN_CAUCAO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"  05      COBRAN-RESPONSABIL       PIC  9(005).*/
            public IntBasis COBRAN_RESPONSABIL { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
            /*"  05      COBRAN-DIGITO            PIC  9(001).*/
            public IntBasis COBRAN_DIGITO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"  05      COBRAN-TAXA-DESCON       PIC  9(003)V99.*/
            public DoubleBasis COBRAN_TAXA_DESCON { get; set; } = new DoubleBasis(new PIC("9", "3", "9(003)V99."), 2);
            /*"  05      COBRAN-TAXA-IOF          PIC  9(001)V9999.*/
            public DoubleBasis COBRAN_TAXA_IOF { get; set; } = new DoubleBasis(new PIC("9", "1", "9(001)V9999."), 4);
            /*"  05      FILLER                   PIC  X(001).*/
            public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  05      COBRAN-CARTEIRA          PIC  9(002).*/
            public IntBasis COBRAN_CARTEIRA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"  05      COBRAN-COMANDO           PIC  9(002).*/
            public IntBasis COBRAN_COMANDO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"  05      COBRAN-DTLIQUIDA         PIC  X(006).*/
            public StringBasis COBRAN_DTLIQUIDA { get; set; } = new StringBasis(new PIC("X", "6", "X(006)."), @"");
            /*"  05      COBRAN-SEU-NUMERO        PIC  X(010).*/
            public StringBasis COBRAN_SEU_NUMERO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  05      FILLER                   PIC  X(020).*/
            public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
            /*"  05      COBRAN-DTVENCTO          PIC  X(006).*/
            public StringBasis COBRAN_DTVENCTO { get; set; } = new StringBasis(new PIC("X", "6", "X(006)."), @"");
            /*"  05      COBRAN-VLR-NOMINAL-TIT   PIC  9(011)V99.*/
            public DoubleBasis COBRAN_VLR_NOMINAL_TIT { get; set; } = new DoubleBasis(new PIC("9", "11", "9(011)V99."), 2);
            /*"  05      COBRAN-COD-BANCO         PIC  9(003).*/
            public IntBasis COBRAN_COD_BANCO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
            /*"  05      COBRAN-AGE-COBR          PIC  9(004).*/
            public IntBasis COBRAN_AGE_COBR { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05      COBRAN-AGE-DIG-COBR      PIC  9(001).*/
            public IntBasis COBRAN_AGE_DIG_COBR { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"  05      COBRAN-ESPECIE           PIC  9(002).*/
            public IntBasis COBRAN_ESPECIE { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"  05      COBRAN-DATA-CREDITO      PIC  X(006).*/
            public StringBasis COBRAN_DATA_CREDITO { get; set; } = new StringBasis(new PIC("X", "6", "X(006)."), @"");
            /*"  05      COBRAN-VLR-TARIFA        PIC  9(005)V99.*/
            public DoubleBasis COBRAN_VLR_TARIFA { get; set; } = new DoubleBasis(new PIC("9", "5", "9(005)V99."), 2);
            /*"  05      COBRAN-VLR-DESPESAS      PIC  9(011)V99.*/
            public DoubleBasis COBRAN_VLR_DESPESAS { get; set; } = new DoubleBasis(new PIC("9", "11", "9(011)V99."), 2);
            /*"  05      COBRAN-VLR-JUROS         PIC  9(011)V99.*/
            public DoubleBasis COBRAN_VLR_JUROS { get; set; } = new DoubleBasis(new PIC("9", "11", "9(011)V99."), 2);
            /*"  05      COBRAN-VLR-IOF           PIC  9(011)V99.*/
            public DoubleBasis COBRAN_VLR_IOF { get; set; } = new DoubleBasis(new PIC("9", "11", "9(011)V99."), 2);
            /*"  05      COBRAN-VLR-ABATIMENTO    PIC  9(011)V99.*/
            public DoubleBasis COBRAN_VLR_ABATIMENTO { get; set; } = new DoubleBasis(new PIC("9", "11", "9(011)V99."), 2);
            /*"  05      COBRAN-VLR-DESCONTO      PIC  9(011)V99.*/
            public DoubleBasis COBRAN_VLR_DESCONTO { get; set; } = new DoubleBasis(new PIC("9", "11", "9(011)V99."), 2);
            /*"  05      COBRAN-VLR-RECEBIDO      PIC  9(011)V99.*/
            public DoubleBasis COBRAN_VLR_RECEBIDO { get; set; } = new DoubleBasis(new PIC("9", "11", "9(011)V99."), 2);
            /*"  05      COBRAN-VLR-MORA          PIC  9(011)V99.*/
            public DoubleBasis COBRAN_VLR_MORA { get; set; } = new DoubleBasis(new PIC("9", "11", "9(011)V99."), 2);
            /*"  05      COBRAN-VLR-OUTROS        PIC  9(011)V99.*/
            public DoubleBasis COBRAN_VLR_OUTROS { get; set; } = new DoubleBasis(new PIC("9", "11", "9(011)V99."), 2);
            /*"  05      COBRAN-VLR-ABATNAO       PIC  9(011)V99.*/
            public DoubleBasis COBRAN_VLR_ABATNAO { get; set; } = new DoubleBasis(new PIC("9", "11", "9(011)V99."), 2);
            /*"  05      COBRAN-VLR-LANCADO       PIC  9(011)V99.*/
            public DoubleBasis COBRAN_VLR_LANCADO { get; set; } = new DoubleBasis(new PIC("9", "11", "9(011)V99."), 2);
            /*"  05      COBRAN-IND-DEBCRE        PIC  9(001).*/
            public IntBasis COBRAN_IND_DEBCRE { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"  05      COBRAN-IND-VALOR         PIC  9(001).*/
            public IntBasis COBRAN_IND_VALOR { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"  05      COBRAN-VLR-AJUSTE        PIC  9(010)V99.*/
            public DoubleBasis COBRAN_VLR_AJUSTE { get; set; } = new DoubleBasis(new PIC("9", "10", "9(010)V99."), 2);
            /*"  05      FILLER                   PIC  X(010).*/
            public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  05      COBRAN-CPFCNPJ           PIC  9(014).*/
            public IntBasis COBRAN_CPFCNPJ { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
            /*"  05      FILLER.*/
            public EM8012B_FILLER_19 FILLER_19 { get; set; } = new EM8012B_FILLER_19();
            public class EM8012B_FILLER_19 : VarBasis
            {
                /*"    10    COBRAN-ZEROS01           PIC  9(015).*/
                public IntBasis COBRAN_ZEROS01 { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
                /*"    10    COBRAN-ZEROS02           PIC  9(015).*/
                public IntBasis COBRAN_ZEROS02 { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
                /*"    10    COBRAN-ZEROS03           PIC  9(004).*/
                public IntBasis COBRAN_ZEROS03 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"  05      COBRAN-NRSEQ             PIC  9(006).*/
            }
            public IntBasis COBRAN_NRSEQ { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"01        TRAILL-REGISTRO.*/
        }
        public EM8012B_TRAILL_REGISTRO TRAILL_REGISTRO { get; set; } = new EM8012B_TRAILL_REGISTRO();
        public class EM8012B_TRAILL_REGISTRO : VarBasis
        {
            /*"  05      TRAILL-CODREGISTR        PIC  X(001).*/
            public StringBasis TRAILL_CODREGISTR { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  05      TRAILL-COD-SERVICO       PIC  9(002).*/
            public IntBasis TRAILL_COD_SERVICO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"  05      TRAILL-COD-BANCO         PIC  9(003).*/
            public IntBasis TRAILL_COD_BANCO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
            /*"  05      TRAILL-COD-AGENCIA       PIC  9(004).*/
            public IntBasis TRAILL_COD_AGENCIA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05      FILLER                   PIC  X(384).*/
            public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "384", "X(384)."), @"");
            /*"  05      TRAILL-NRSEQ             PIC  9(006).*/
            public IntBasis TRAILL_NRSEQ { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
        }


        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.AVISOCRE AVISOCRE { get; set; } = new Dclgens.AVISOCRE();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string ARQSORT_FILE_NAME_P, string ENTRADA_FILE_NAME_P, string SAIDA01_FILE_NAME_P, string SAIDA02_FILE_NAME_P, string SAIDA03_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                ARQSORT.SetFile(ARQSORT_FILE_NAME_P);
                ENTRADA.SetFile(ENTRADA_FILE_NAME_P);
                SAIDA01.SetFile(SAIDA01_FILE_NAME_P);
                SAIDA02.SetFile(SAIDA02_FILE_NAME_P);
                SAIDA03.SetFile(SAIDA03_FILE_NAME_P);

                /*" -0- FLUXCONTROL_PERFORM R0000-00-PRINCIPAL-SECTION */

                R0000_00_PRINCIPAL_SECTION();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { CodigoRetorno = RETURN_CODE.Value };
            return Result;
        }

        [StopWatch]
        /*" R0000-00-PRINCIPAL-SECTION */
        private void R0000_00_PRINCIPAL_SECTION()
        {
            /*" -372- MOVE '0000' TO WNR-EXEC-SQL. */
            _.Move("0000", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -373- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -375- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -377- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -383- PERFORM R0050-00-INICIO. */

            R0050_00_INICIO_SECTION();

            /*" -399- SORT ARQSORT ON ASCENDING KEY SOR-NUM-INSCRICAO SOR-CEDENTE SOR-CONVENIO SOR-DTGERACAO SOR-BANCO SOR-NSAC SOR-NRO-TITULO SOR-DATA-CREDITO INPUT PROCEDURE R0200-00-INPUT-SORT THRU R0200-99-SAIDA OUTPUT PROCEDURE R0500-00-OUTPUT-SORT THRU R0500-99-SAIDA. */
            ARQSORT.Sort("SOR-NUM-INSCRICAO,SOR-CEDENTE,SOR-CONVENIO,SOR-DTGERACAO,SOR-BANCO,SOR-NSAC,SOR-NRO-TITULO,SOR-DATA-CREDITO", () => R0200_00_INPUT_SORT_SECTION(), () => R0500_00_OUTPUT_SORT_SECTION());

            /*" -0- FLUXCONTROL_PERFORM R0000_90_FINALIZA */

            R0000_90_FINALIZA();

        }

        [StopWatch]
        /*" R0000-90-FINALIZA */
        private void R0000_90_FINALIZA(bool isPerform = false)
        {
            /*" -404- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -411- CLOSE ENTRADA SAIDA01 SAIDA02 SAIDA03. */
            ENTRADA.Close();
            SAIDA01.Close();
            SAIDA02.Close();
            SAIDA03.Close();

            /*" -413- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -414- DISPLAY ' ' */
            _.Display($" ");

            /*" -415- DISPLAY 'EM8012B - FIM NORMAL' . */
            _.Display($"EM8012B - FIM NORMAL");

            /*" -417- DISPLAY ' ' . */
            _.Display($" ");

            /*" -417- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0050-00-INICIO-SECTION */
        private void R0050_00_INICIO_SECTION()
        {
            /*" -430- MOVE '0050' TO WNR-EXEC-SQL. */
            _.Move("0050", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -431- OPEN INPUT ENTRADA */
            ENTRADA.Open(REG_ENTRADA);

            /*" -436- OUTPUT SAIDA01 SAIDA02 SAIDA03. */
            SAIDA03.Open(REG_SAIDA03);

            /*" -438- PERFORM R0100-00-SELECT-SISTEMA. */

            R0100_00_SELECT_SISTEMA_SECTION();

            /*" -439- MOVE SPACES TO WFIM-MOVIMENTO. */
            _.Move("", W.WFIM_MOVIMENTO);

            /*" -442- PERFORM R0300-00-LER-MOVIMENTO. */

            R0300_00_LER_MOVIMENTO_SECTION();

            /*" -443- IF WFIM-MOVIMENTO NOT EQUAL SPACES */

            if (!W.WFIM_MOVIMENTO.IsEmpty())
            {

                /*" -443- GO TO R9990-00-SEM-MOVIMENTO. */

                R9990_00_SEM_MOVIMENTO_SECTION(); //GOTO
                return;
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0050_99_SAIDA*/

        [StopWatch]
        /*" R0100-00-SELECT-SISTEMA-SECTION */
        private void R0100_00_SELECT_SISTEMA_SECTION()
        {
            /*" -456- MOVE '0100' TO WNR-EXEC-SQL. */
            _.Move("0100", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -464- PERFORM R0100_00_SELECT_SISTEMA_DB_SELECT_1 */

            R0100_00_SELECT_SISTEMA_DB_SELECT_1();

            /*" -467- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -468- DISPLAY 'R0100-00 - PROBLEMAS NO SELECT(SISTEMAS)' */
                _.Display($"R0100-00 - PROBLEMAS NO SELECT(SISTEMAS)");

                /*" -468- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0100-00-SELECT-SISTEMA-DB-SELECT-1 */
        public void R0100_00_SELECT_SISTEMA_DB_SELECT_1()
        {
            /*" -464- EXEC SQL SELECT DATA_MOV_ABERTO INTO :SISTEMAS-DATA-MOV-ABERTO FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'EM' WITH UR END-EXEC. */

            var r0100_00_SELECT_SISTEMA_DB_SELECT_1_Query1 = new R0100_00_SELECT_SISTEMA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0100_00_SELECT_SISTEMA_DB_SELECT_1_Query1.Execute(r0100_00_SELECT_SISTEMA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/

        [StopWatch]
        /*" R0200-00-INPUT-SORT-SECTION */
        private void R0200_00_INPUT_SORT_SECTION()
        {
            /*" -481- MOVE '0200' TO WNR-EXEC-SQL. */
            _.Move("0200", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -485- PERFORM R0350-00-PROCESSA-MOVIMENTO UNTIL WFIM-MOVIMENTO NOT EQUAL SPACES. */

            while (!(!W.WFIM_MOVIMENTO.IsEmpty()))
            {

                R0350_00_PROCESSA_MOVIMENTO_SECTION();
            }

            /*" -486- DISPLAY ' ' */
            _.Display($" ");

            /*" -487- DISPLAY 'LIDOS MOVIMENTO ....... ' LD-MOVIMENTO */
            _.Display($"LIDOS MOVIMENTO ....... {W.LD_MOVIMENTO}");

            /*" -488- DISPLAY 'DESPREZA MOVIMENTO .... ' DP-MOVIMENTO */
            _.Display($"DESPREZA MOVIMENTO .... {W.DP_MOVIMENTO}");

            /*" -489- DISPLAY 'GRAVADOS SORT ......... ' GV-SORT */
            _.Display($"GRAVADOS SORT ......... {W.GV_SORT}");

            /*" -489- DISPLAY ' ' . */
            _.Display($" ");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_99_SAIDA*/

        [StopWatch]
        /*" R0300-00-LER-MOVIMENTO-SECTION */
        private void R0300_00_LER_MOVIMENTO_SECTION()
        {
            /*" -502- MOVE '0300' TO WNR-EXEC-SQL. */
            _.Move("0300", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -503- READ ENTRADA AT END */
            try
            {
                ENTRADA.Read(() =>
                {

                    /*" -505- MOVE 'S' TO WFIM-MOVIMENTO */
                    _.Move("S", W.WFIM_MOVIMENTO);

                    /*" -508- GO TO R0300-99-SAIDA. */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_99_SAIDA*/ //GOTO
                    return;
                });

                _.Move(ENTRADA.Value, REG_ENTRADA);

            }
            catch (GoToException ex)
            {
                return;
            }
            /*" -508- ADD 1 TO LD-MOVIMENTO. */
            W.LD_MOVIMENTO.Value = W.LD_MOVIMENTO + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_99_SAIDA*/

        [StopWatch]
        /*" R0350-00-PROCESSA-MOVIMENTO-SECTION */
        private void R0350_00_PROCESSA_MOVIMENTO_SECTION()
        {
            /*" -521- MOVE '0350' TO WNR-EXEC-SQL. */
            _.Move("0350", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -524- MOVE REG-ENTRADA TO REG-ARQSORT. */
            _.Move(ENTRADA?.Value, REG_ARQSORT);

            /*" -525- IF SOR-TIPO-ARQUIVO NOT EQUAL 'BANCOOB   ' */

            if (REG_ARQSORT.SOR_TIPO_ARQUIVO != "BANCOOB   ")
            {

                /*" -526- ADD 1 TO DP-MOVIMENTO */
                W.DP_MOVIMENTO.Value = W.DP_MOVIMENTO + 1;

                /*" -527- ELSE */
            }
            else
            {


                /*" -529- IF SOR-CEDENTE EQUAL 05012376 */

                if (REG_ARQSORT.SOR_CEDENTE == 05012376)
                {

                    /*" -530- RELEASE REG-ARQSORT */
                    ARQSORT.Release(REG_ARQSORT);

                    /*" -531- ADD 1 TO GV-SORT */
                    W.GV_SORT.Value = W.GV_SORT + 1;

                    /*" -532- ELSE */
                }
                else
                {


                    /*" -532- ADD 1 TO DP-MOVIMENTO. */
                    W.DP_MOVIMENTO.Value = W.DP_MOVIMENTO + 1;
                }

            }


            /*" -0- FLUXCONTROL_PERFORM R0350_90_LEITURA */

            R0350_90_LEITURA();

        }

        [StopWatch]
        /*" R0350-90-LEITURA */
        private void R0350_90_LEITURA(bool isPerform = false)
        {
            /*" -537- PERFORM R0300-00-LER-MOVIMENTO. */

            R0300_00_LER_MOVIMENTO_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0350_99_SAIDA*/

        [StopWatch]
        /*" R0500-00-OUTPUT-SORT-SECTION */
        private void R0500_00_OUTPUT_SORT_SECTION()
        {
            /*" -549- MOVE '0500' TO WNR-EXEC-SQL. */
            _.Move("0500", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -550- MOVE SPACES TO WFIM-SORT. */
            _.Move("", W.WFIM_SORT);

            /*" -553- PERFORM R0510-00-LE-ARQSORT. */

            R0510_00_LE_ARQSORT_SECTION();

            /*" -557- PERFORM R0550-00-PROCESSA-SORT UNTIL WFIM-SORT NOT EQUAL SPACES. */

            while (!(!W.WFIM_SORT.IsEmpty()))
            {

                R0550_00_PROCESSA_SORT_SECTION();
            }

            /*" -558- DISPLAY ' ' */
            _.Display($" ");

            /*" -559- DISPLAY 'LIDOS SORT ............ ' LD-SORT */
            _.Display($"LIDOS SORT ............ {W.LD_SORT}");

            /*" -560- DISPLAY 'GRAVADOS BANCOOB 1575 . ' AC-GRAV-SAIDA01. */
            _.Display($"GRAVADOS BANCOOB 1575 . {W.AC_GRAV_SAIDA01}");

            /*" -561- DISPLAY 'GRAVADOS SICOB       .. ' AC-GRAV-SAIDA02. */
            _.Display($"GRAVADOS SICOB       .. {W.AC_GRAV_SAIDA02}");

            /*" -562- DISPLAY 'GRAVADOS SICOB       .. ' AC-GRAV-SAIDA03. */
            _.Display($"GRAVADOS SICOB       .. {W.AC_GRAV_SAIDA03}");

            /*" -562- DISPLAY ' ' . */
            _.Display($" ");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0500_99_SAIDA*/

        [StopWatch]
        /*" R0510-00-LE-ARQSORT-SECTION */
        private void R0510_00_LE_ARQSORT_SECTION()
        {
            /*" -575- MOVE '0510' TO WNR-EXEC-SQL. */
            _.Move("0510", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -577- RETURN ARQSORT AT END */
            try
            {
                ARQSORT.Return(REG_ARQSORT, () =>
                {

                    /*" -578- MOVE ZEROS TO ATU-COD-CEDENTE */
                    _.Move(0, W.ATU_COD_CEDENTE);

                    /*" -579- MOVE 'S' TO WFIM-SORT */
                    _.Move("S", W.WFIM_SORT);

                    /*" -582- GO TO R0510-99-SAIDA. */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0510_99_SAIDA*/ //GOTO
                    return;

                });
            }
            catch (GoToException ex)
            {
                return;
            }
            /*" -584- ADD 1 TO LD-SORT. */
            W.LD_SORT.Value = W.LD_SORT + 1;

            /*" -584- MOVE SOR-CEDENTE TO ATU-COD-CEDENTE. */
            _.Move(REG_ARQSORT.SOR_CEDENTE, W.ATU_COD_CEDENTE);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0510_99_SAIDA*/

        [StopWatch]
        /*" R0550-00-PROCESSA-SORT-SECTION */
        private void R0550_00_PROCESSA_SORT_SECTION()
        {
            /*" -597- MOVE '0550' TO WNR-EXEC-SQL. */
            _.Move("0550", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -599- MOVE ATU-COD-CEDENTE TO ANT-COD-CEDENTE. */
            _.Move(W.ATU_COD_CEDENTE, W.ANT_COD_CEDENTE);

            /*" -602- PERFORM R1100-00-GRAVA-HEADER. */

            R1100_00_GRAVA_HEADER_SECTION();

            /*" -607- PERFORM R1000-00-PROCESSA-DETALHE UNTIL ATU-COD-CEDENTE NOT EQUAL ANT-COD-CEDENTE OR WFIM-SORT NOT EQUAL SPACES. */

            while (!(W.ATU_COD_CEDENTE != W.ANT_COD_CEDENTE || !W.WFIM_SORT.IsEmpty()))
            {

                R1000_00_PROCESSA_DETALHE_SECTION();
            }

            /*" -607- PERFORM R1200-00-GRAVA-TRAILLER. */

            R1200_00_GRAVA_TRAILLER_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0550_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-DETALHE-SECTION */
        private void R1000_00_PROCESSA_DETALHE_SECTION()
        {
            /*" -620- MOVE '1000' TO WNR-EXEC-SQL. */
            _.Move("1000", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -622- MOVE SPACES TO COBRAN-REGISTRO. */
            _.Move("", COBRAN_REGISTRO);

            /*" -624- MOVE '1' TO COBRAN-COD-REGISTRO. */
            _.Move("1", COBRAN_REGISTRO.COBRAN_COD_REGISTRO);

            /*" -626- MOVE SOR-TIPO-INSCRICAO TO COBRAN-TIPO-INSCRICAO. */
            _.Move(REG_ARQSORT.SOR_TIPO_INSCRICAO, COBRAN_REGISTRO.COBRAN_TIPO_INSCRICAO);

            /*" -628- MOVE SOR-NUM-INSCRICAO TO COBRAN-NUM-INSCRICAO. */
            _.Move(REG_ARQSORT.SOR_NUM_INSCRICAO, COBRAN_REGISTRO.COBRAN_NUM_INSCRICAO);

            /*" -630- MOVE SOR-COD-AGENCIA TO COBRAN-COD-AGENCIA. */
            _.Move(REG_ARQSORT.SOR_COD_AGENCIA, COBRAN_REGISTRO.COBRAN_COD_AGENCIA);

            /*" -632- MOVE SOR-DIG-AGENCIA TO COBRAN-DIG-AGENCIA. */
            _.Move(REG_ARQSORT.SOR_DIG_AGENCIA, COBRAN_REGISTRO.COBRAN_DIG_AGENCIA);

            /*" -634- MOVE SOR-NRO-CONTA TO COBRAN-NRO-CONTA. */
            _.Move(REG_ARQSORT.SOR_NRO_CONTA, COBRAN_REGISTRO.COBRAN_NRO_CONTA);

            /*" -636- MOVE SOR-DIG-CONTA TO COBRAN-DIG-CONTA. */
            _.Move(REG_ARQSORT.SOR_DIG_CONTA, COBRAN_REGISTRO.COBRAN_DIG_CONTA);

            /*" -638- MOVE SOR-CONVENIO TO COBRAN-CONVENIO. */
            _.Move(REG_ARQSORT.SOR_CONVENIO, COBRAN_REGISTRO.COBRAN_CONVENIO);

            /*" -640- MOVE SOR-CONTROLE TO COBRAN-CONTROLE. */
            _.Move(REG_ARQSORT.SOR_CONTROLE, COBRAN_REGISTRO.COBRAN_CONTROLE);

            /*" -642- MOVE SOR-NRO-TITULO TO COBRAN-NRO-TITULO. */
            _.Move(REG_ARQSORT.SOR_NRO_TITULO, COBRAN_REGISTRO.COBRAN_NRO_TITULO);

            /*" -644- MOVE SOR-DIG-TITULO TO COBRAN-DIG-TITULO. */
            _.Move(REG_ARQSORT.SOR_DIG_TITULO, COBRAN_REGISTRO.COBRAN_DIG_TITULO);

            /*" -646- MOVE SOR-NRO-PARCELA TO COBRAN-NRO-PARCELA. */
            _.Move(REG_ARQSORT.SOR_NRO_PARCELA, COBRAN_REGISTRO.COBRAN_NRO_PARCELA);

            /*" -648- MOVE SOR-DIAS-CALCULO TO COBRAN-DIAS-CALCULO. */
            _.Move(REG_ARQSORT.SOR_DIAS_CALCULO, COBRAN_REGISTRO.COBRAN_DIAS_CALCULO);

            /*" -650- MOVE SOR-MOTIVO TO COBRAN-MOTIVO. */
            _.Move(REG_ARQSORT.SOR_MOTIVO, COBRAN_REGISTRO.COBRAN_MOTIVO);

            /*" -652- MOVE SOR-PREFIXO TO COBRAN-PREFIXO. */
            _.Move(REG_ARQSORT.SOR_PREFIXO, COBRAN_REGISTRO.COBRAN_PREFIXO);

            /*" -654- MOVE SOR-VARIACAO TO COBRAN-VARIACAO. */
            _.Move(REG_ARQSORT.SOR_VARIACAO, COBRAN_REGISTRO.COBRAN_VARIACAO);

            /*" -656- MOVE SOR-CAUCAO TO COBRAN-CAUCAO. */
            _.Move(REG_ARQSORT.SOR_CAUCAO, COBRAN_REGISTRO.COBRAN_CAUCAO);

            /*" -658- MOVE SOR-RESPONSABIL TO COBRAN-RESPONSABIL. */
            _.Move(REG_ARQSORT.SOR_RESPONSABIL, COBRAN_REGISTRO.COBRAN_RESPONSABIL);

            /*" -660- MOVE SOR-DIGITO TO COBRAN-DIGITO. */
            _.Move(REG_ARQSORT.SOR_DIGITO, COBRAN_REGISTRO.COBRAN_DIGITO);

            /*" -662- MOVE SOR-TAXA-DESCON TO COBRAN-TAXA-DESCON. */
            _.Move(REG_ARQSORT.SOR_TAXA_DESCON, COBRAN_REGISTRO.COBRAN_TAXA_DESCON);

            /*" -664- MOVE SOR-TAXA-IOF TO COBRAN-TAXA-IOF. */
            _.Move(REG_ARQSORT.SOR_TAXA_IOF, COBRAN_REGISTRO.COBRAN_TAXA_IOF);

            /*" -666- MOVE SOR-CARTEIRA TO COBRAN-CARTEIRA. */
            _.Move(REG_ARQSORT.SOR_CARTEIRA, COBRAN_REGISTRO.COBRAN_CARTEIRA);

            /*" -668- MOVE SOR-COMANDO TO COBRAN-COMANDO. */
            _.Move(REG_ARQSORT.SOR_COMANDO, COBRAN_REGISTRO.COBRAN_COMANDO);

            /*" -670- MOVE SOR-DTLIQUIDA TO COBRAN-DTLIQUIDA. */
            _.Move(REG_ARQSORT.SOR_DTLIQUIDA, COBRAN_REGISTRO.COBRAN_DTLIQUIDA);

            /*" -672- MOVE SOR-SEU-NUMERO TO COBRAN-SEU-NUMERO. */
            _.Move(REG_ARQSORT.SOR_SEU_NUMERO, COBRAN_REGISTRO.COBRAN_SEU_NUMERO);

            /*" -674- MOVE SOR-DTVENCTO TO COBRAN-DTVENCTO. */
            _.Move(REG_ARQSORT.SOR_DTVENCTO, COBRAN_REGISTRO.COBRAN_DTVENCTO);

            /*" -676- MOVE SOR-VLR-NOMINAL-TIT TO COBRAN-VLR-NOMINAL-TIT. */
            _.Move(REG_ARQSORT.SOR_VLR_NOMINAL_TIT, COBRAN_REGISTRO.COBRAN_VLR_NOMINAL_TIT);

            /*" -678- MOVE SOR-COD-BANCO TO COBRAN-COD-BANCO. */
            _.Move(REG_ARQSORT.SOR_COD_BANCO, COBRAN_REGISTRO.COBRAN_COD_BANCO);

            /*" -680- MOVE SOR-AGE-COBR TO COBRAN-AGE-COBR. */
            _.Move(REG_ARQSORT.SOR_AGE_COBR, COBRAN_REGISTRO.COBRAN_AGE_COBR);

            /*" -682- MOVE SOR-AGE-DIG-COBR TO COBRAN-AGE-DIG-COBR. */
            _.Move(REG_ARQSORT.SOR_AGE_DIG_COBR, COBRAN_REGISTRO.COBRAN_AGE_DIG_COBR);

            /*" -684- MOVE SOR-ESPECIE TO COBRAN-ESPECIE. */
            _.Move(REG_ARQSORT.SOR_ESPECIE, COBRAN_REGISTRO.COBRAN_ESPECIE);

            /*" -686- MOVE SOR-DATA-CREDITO TO COBRAN-DATA-CREDITO. */
            _.Move(REG_ARQSORT.SOR_DATA_CREDITO, COBRAN_REGISTRO.COBRAN_DATA_CREDITO);

            /*" -688- MOVE SOR-VLR-TARIFA TO COBRAN-VLR-TARIFA. */
            _.Move(REG_ARQSORT.SOR_VLR_TARIFA, COBRAN_REGISTRO.COBRAN_VLR_TARIFA);

            /*" -690- MOVE SOR-VLR-DESPESAS TO COBRAN-VLR-DESPESAS. */
            _.Move(REG_ARQSORT.SOR_VLR_DESPESAS, COBRAN_REGISTRO.COBRAN_VLR_DESPESAS);

            /*" -692- MOVE SOR-VLR-JUROS TO COBRAN-VLR-JUROS. */
            _.Move(REG_ARQSORT.SOR_VLR_JUROS, COBRAN_REGISTRO.COBRAN_VLR_JUROS);

            /*" -694- MOVE SOR-VLR-IOF TO COBRAN-VLR-IOF. */
            _.Move(REG_ARQSORT.SOR_VLR_IOF, COBRAN_REGISTRO.COBRAN_VLR_IOF);

            /*" -696- MOVE SOR-VLR-ABATIMENTO TO COBRAN-VLR-ABATIMENTO. */
            _.Move(REG_ARQSORT.SOR_VLR_ABATIMENTO, COBRAN_REGISTRO.COBRAN_VLR_ABATIMENTO);

            /*" -698- MOVE SOR-VLR-DESCONTO TO COBRAN-VLR-DESCONTO. */
            _.Move(REG_ARQSORT.SOR_VLR_DESCONTO, COBRAN_REGISTRO.COBRAN_VLR_DESCONTO);

            /*" -700- MOVE SOR-VLR-RECEBIDO TO COBRAN-VLR-RECEBIDO. */
            _.Move(REG_ARQSORT.SOR_VLR_RECEBIDO, COBRAN_REGISTRO.COBRAN_VLR_RECEBIDO);

            /*" -702- MOVE SOR-VLR-MORA TO COBRAN-VLR-MORA. */
            _.Move(REG_ARQSORT.SOR_VLR_MORA, COBRAN_REGISTRO.COBRAN_VLR_MORA);

            /*" -704- MOVE SOR-VLR-OUTROS TO COBRAN-VLR-OUTROS. */
            _.Move(REG_ARQSORT.SOR_VLR_OUTROS, COBRAN_REGISTRO.COBRAN_VLR_OUTROS);

            /*" -706- MOVE SOR-VLR-ABATNAO TO COBRAN-VLR-ABATNAO. */
            _.Move(REG_ARQSORT.SOR_VLR_ABATNAO, COBRAN_REGISTRO.COBRAN_VLR_ABATNAO);

            /*" -708- MOVE SOR-VLR-LANCADO TO COBRAN-VLR-LANCADO. */
            _.Move(REG_ARQSORT.SOR_VLR_LANCADO, COBRAN_REGISTRO.COBRAN_VLR_LANCADO);

            /*" -710- MOVE SOR-IND-DEBCRE TO COBRAN-IND-DEBCRE. */
            _.Move(REG_ARQSORT.SOR_IND_DEBCRE, COBRAN_REGISTRO.COBRAN_IND_DEBCRE);

            /*" -712- MOVE SOR-IND-VALOR TO COBRAN-IND-VALOR. */
            _.Move(REG_ARQSORT.SOR_IND_VALOR, COBRAN_REGISTRO.COBRAN_IND_VALOR);

            /*" -714- MOVE SOR-VLR-AJUSTE TO COBRAN-VLR-AJUSTE. */
            _.Move(REG_ARQSORT.SOR_VLR_AJUSTE, COBRAN_REGISTRO.COBRAN_VLR_AJUSTE);

            /*" -720- MOVE ZEROS TO COBRAN-CPFCNPJ COBRAN-ZEROS01 COBRAN-ZEROS02 COBRAN-ZEROS03. */
            _.Move(0, COBRAN_REGISTRO.COBRAN_CPFCNPJ, COBRAN_REGISTRO.FILLER_19.COBRAN_ZEROS01, COBRAN_REGISTRO.FILLER_19.COBRAN_ZEROS02, COBRAN_REGISTRO.FILLER_19.COBRAN_ZEROS03);

            /*" -722- ADD 1 TO WS-NRSEQ. */
            W.WS_NRSEQ.Value = W.WS_NRSEQ + 1;

            /*" -726- MOVE WS-NRSEQ TO COBRAN-NRSEQ. */
            _.Move(W.WS_NRSEQ, COBRAN_REGISTRO.COBRAN_NRSEQ);

            /*" -728- IF SOR-CEDENTE EQUAL 05012376 */

            if (REG_ARQSORT.SOR_CEDENTE == 05012376)
            {

                /*" -729- WRITE REG-SAIDA01 FROM COBRAN-REGISTRO */
                _.Move(COBRAN_REGISTRO.GetMoveValues(), REG_SAIDA01);

                SAIDA01.Write(REG_SAIDA01.GetMoveValues().ToString());

                /*" -729- ADD 1 TO AC-GRAV-SAIDA01. */
                W.AC_GRAV_SAIDA01.Value = W.AC_GRAV_SAIDA01 + 1;
            }


            /*" -0- FLUXCONTROL_PERFORM R1000_90_LEITURA */

            R1000_90_LEITURA();

        }

        [StopWatch]
        /*" R1000-90-LEITURA */
        private void R1000_90_LEITURA(bool isPerform = false)
        {
            /*" -734- PERFORM R0510-00-LE-ARQSORT. */

            R0510_00_LE_ARQSORT_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1100-00-GRAVA-HEADER-SECTION */
        private void R1100_00_GRAVA_HEADER_SECTION()
        {
            /*" -746- MOVE '1100' TO WNR-EXEC-SQL. */
            _.Move("1100", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -748- MOVE SPACES TO HEADER-REGISTRO. */
            _.Move("", HEADER_REGISTRO);

            /*" -750- MOVE '0' TO HEADER-CODREGISTR. */
            _.Move("0", HEADER_REGISTRO.HEADER_CODREGISTR);

            /*" -752- MOVE '2' TO HEADER-CODRETORNO. */
            _.Move("2", HEADER_REGISTRO.HEADER_CODRETORNO);

            /*" -754- MOVE 'RETORNO' TO HEADER-LITRETORNO. */
            _.Move("RETORNO", HEADER_REGISTRO.HEADER_LITRETORNO);

            /*" -756- MOVE '01' TO HEADER-CODSERVICO. */
            _.Move("01", HEADER_REGISTRO.HEADER_CODSERVICO);

            /*" -758- MOVE 'COBRANCA' TO HEADER-LITSERVICO. */
            _.Move("COBRANCA", HEADER_REGISTRO.HEADER_LITSERVICO);

            /*" -760- MOVE 'CAIXA SEGURADORA SA' TO HEADER-NOMEMPRESA. */
            _.Move("CAIXA SEGURADORA SA", HEADER_REGISTRO.HEADER_NOMEMPRESA);

            /*" -762- MOVE '756' TO HEADER-CODBANCO. */
            _.Move("756", HEADER_REGISTRO.HEADER_CODBANCO);

            /*" -764- MOVE ' - BANCOOB S/A' TO HEADER-NOMEBANCO. */
            _.Move(" - BANCOOB S/A", HEADER_REGISTRO.HEADER_NOMEBANCO);

            /*" -768- MOVE 1 TO WS-NRSEQ HEADER-NRSEQ. */
            _.Move(1, W.WS_NRSEQ, HEADER_REGISTRO.HEADER_NRSEQ);

            /*" -770- MOVE SOR-COD-AGENCIA TO HEADER-COD-AGENCIA. */
            _.Move(REG_ARQSORT.SOR_COD_AGENCIA, HEADER_REGISTRO.HEADER_COD_AGENCIA);

            /*" -772- MOVE SOR-DIG-AGENCIA TO HEADER-DIG-AGENCIA. */
            _.Move(REG_ARQSORT.SOR_DIG_AGENCIA, HEADER_REGISTRO.HEADER_DIG_AGENCIA);

            /*" -774- MOVE SOR-CEDENTE TO HEADER-CEDENTE. */
            _.Move(REG_ARQSORT.SOR_CEDENTE, HEADER_REGISTRO.HEADER_CEDENTE);

            /*" -776- MOVE SOR-CONVENIO TO HEADER-CONVENIO. */
            _.Move(REG_ARQSORT.SOR_CONVENIO, HEADER_REGISTRO.HEADER_CONVENIO);

            /*" -779- MOVE SOR-DTGERACAO TO HEADER-DTGERACAO. */
            _.Move(REG_ARQSORT.SOR_DTGERACAO, HEADER_REGISTRO.HEADER_DTGERACAO);

            /*" -783- MOVE SOR-NSAC TO HEADER-NUMFITA. */
            _.Move(REG_ARQSORT.SOR_NSAC, HEADER_REGISTRO.HEADER_NUMFITA);

            /*" -787- IF SOR-CEDENTE EQUAL 05012376 */

            if (REG_ARQSORT.SOR_CEDENTE == 05012376)
            {

                /*" -788- MOVE 876700000 TO WSHOST-NRAVISO1 */
                _.Move(876700000, WSHOST_NRAVISO1);

                /*" -789- MOVE 876799999 TO WSHOST-NRAVISO2 */
                _.Move(876799999, WSHOST_NRAVISO2);

                /*" -790- PERFORM R1170-00-TRATA-NSAC */

                R1170_00_TRATA_NSAC_SECTION();

                /*" -791- WRITE REG-SAIDA01 FROM HEADER-REGISTRO */
                _.Move(HEADER_REGISTRO.GetMoveValues(), REG_SAIDA01);

                SAIDA01.Write(REG_SAIDA01.GetMoveValues().ToString());

                /*" -791- ADD 1 TO AC-GRAV-SAIDA01. */
                W.AC_GRAV_SAIDA01.Value = W.AC_GRAV_SAIDA01 + 1;
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/

        [StopWatch]
        /*" R1170-00-TRATA-NSAC-SECTION */
        private void R1170_00_TRATA_NSAC_SECTION()
        {
            /*" -804- MOVE '1170' TO WNR-EXEC-SQL. */
            _.Move("1170", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -806- PERFORM R1180-00-SELECT-AVISOCRE. */

            R1180_00_SELECT_AVISOCRE_SECTION();

            /*" -810- MOVE AVISOCRE-NUM-AVISO-CREDITO TO WS0-NRAVISO. */
            _.Move(AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_NUM_AVISO_CREDITO, W.WS0_NRAVISO);

            /*" -811- IF WS0-NRO-NSAC GREATER HEADER-NUMFITA */

            if (W.FILLER_3.WS0_NRO_NSAC > HEADER_REGISTRO.HEADER_NUMFITA)
            {

                /*" -811- MOVE WS0-NRO-NSAC TO HEADER-NUMFITA. */
                _.Move(W.FILLER_3.WS0_NRO_NSAC, HEADER_REGISTRO.HEADER_NUMFITA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1170_99_SAIDA*/

        [StopWatch]
        /*" R1180-00-SELECT-AVISOCRE-SECTION */
        private void R1180_00_SELECT_AVISOCRE_SECTION()
        {
            /*" -824- MOVE '1180' TO WNR-EXEC-SQL. */
            _.Move("1180", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -832- PERFORM R1180_00_SELECT_AVISOCRE_DB_SELECT_1 */

            R1180_00_SELECT_AVISOCRE_DB_SELECT_1();

            /*" -836- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -837- DISPLAY 'R1180-00 - PROBLEMAS NO SELECT(AVISOCRE)' */
                _.Display($"R1180-00 - PROBLEMAS NO SELECT(AVISOCRE)");

                /*" -840- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -841- ADD 1 TO AVISOCRE-NUM-AVISO-CREDITO. */
            AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_NUM_AVISO_CREDITO.Value = AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_NUM_AVISO_CREDITO + 1;

        }

        [StopWatch]
        /*" R1180-00-SELECT-AVISOCRE-DB-SELECT-1 */
        public void R1180_00_SELECT_AVISOCRE_DB_SELECT_1()
        {
            /*" -832- EXEC SQL SELECT VALUE(MAX(NUM_AVISO_CREDITO),0) INTO :AVISOCRE-NUM-AVISO-CREDITO FROM SEGUROS.AVISO_CREDITO WHERE NUM_AVISO_CREDITO BETWEEN :WSHOST-NRAVISO1 AND :WSHOST-NRAVISO2 WITH UR END-EXEC. */

            var r1180_00_SELECT_AVISOCRE_DB_SELECT_1_Query1 = new R1180_00_SELECT_AVISOCRE_DB_SELECT_1_Query1()
            {
                WSHOST_NRAVISO1 = WSHOST_NRAVISO1.ToString(),
                WSHOST_NRAVISO2 = WSHOST_NRAVISO2.ToString(),
            };

            var executed_1 = R1180_00_SELECT_AVISOCRE_DB_SELECT_1_Query1.Execute(r1180_00_SELECT_AVISOCRE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.AVISOCRE_NUM_AVISO_CREDITO, AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_NUM_AVISO_CREDITO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1180_99_SAIDA*/

        [StopWatch]
        /*" R1200-00-GRAVA-TRAILLER-SECTION */
        private void R1200_00_GRAVA_TRAILLER_SECTION()
        {
            /*" -854- MOVE '1200' TO WNR-EXEC-SQL. */
            _.Move("1200", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -856- MOVE SPACES TO TRAILL-REGISTRO. */
            _.Move("", TRAILL_REGISTRO);

            /*" -858- MOVE '9' TO TRAILL-CODREGISTR. */
            _.Move("9", TRAILL_REGISTRO.TRAILL_CODREGISTR);

            /*" -860- MOVE 02 TO TRAILL-COD-SERVICO. */
            _.Move(02, TRAILL_REGISTRO.TRAILL_COD_SERVICO);

            /*" -862- MOVE 756 TO TRAILL-COD-BANCO. */
            _.Move(756, TRAILL_REGISTRO.TRAILL_COD_BANCO);

            /*" -865- MOVE HEADER-COD-AGENCIA TO TRAILL-COD-AGENCIA. */
            _.Move(HEADER_REGISTRO.HEADER_COD_AGENCIA, TRAILL_REGISTRO.TRAILL_COD_AGENCIA);

            /*" -866- ADD 1 TO WS-NRSEQ. */
            W.WS_NRSEQ.Value = W.WS_NRSEQ + 1;

            /*" -868- MOVE WS-NRSEQ TO TRAILL-NRSEQ. */
            _.Move(W.WS_NRSEQ, TRAILL_REGISTRO.TRAILL_NRSEQ);

            /*" -870- IF HEADER-CEDENTE EQUAL 05012376 */

            if (HEADER_REGISTRO.HEADER_CEDENTE == 05012376)
            {

                /*" -871- WRITE REG-SAIDA01 FROM TRAILL-REGISTRO */
                _.Move(TRAILL_REGISTRO.GetMoveValues(), REG_SAIDA01);

                SAIDA01.Write(REG_SAIDA01.GetMoveValues().ToString());

                /*" -871- ADD 1 TO AC-GRAV-SAIDA01. */
                W.AC_GRAV_SAIDA01.Value = W.AC_GRAV_SAIDA01 + 1;
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/

        [StopWatch]
        /*" R9990-00-SEM-MOVIMENTO-SECTION */
        private void R9990_00_SEM_MOVIMENTO_SECTION()
        {
            /*" -883- MOVE SISTEMAS-DATA-MOV-ABERTO TO WDATA-REL */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, W.WDATA_REL);

            /*" -884- MOVE WDAT-REL-DIA TO WDATA-DD-CABEC */
            _.Move(W.FILLER_6.WDAT_REL_DIA, W.WDATA_CABEC.WDATA_DD_CABEC);

            /*" -885- MOVE WDAT-REL-MES TO WDATA-MM-CABEC */
            _.Move(W.FILLER_6.WDAT_REL_MES, W.WDATA_CABEC.WDATA_MM_CABEC);

            /*" -887- MOVE WDAT-REL-ANO TO WDATA-AA-CABEC. */
            _.Move(W.FILLER_6.WDAT_REL_ANO, W.WDATA_CABEC.WDATA_AA_CABEC);

            /*" -889- DISPLAY 'SEM MOVIMENTO NESTA DATA  ' WDATA-CABEC. */
            _.Display($"SEM MOVIMENTO NESTA DATA  {W.WDATA_CABEC}");

            /*" -894- CLOSE ENTRADA SAIDA01 SAIDA02 SAIDA03. */
            ENTRADA.Close();
            SAIDA01.Close();
            SAIDA02.Close();
            SAIDA03.Close();

            /*" -896- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -896- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -903- MOVE SQLCODE TO WSQLCODE */
            _.Move(DB.SQLCODE, ABEN.WABEND1.WSQLCODE);

            /*" -904- MOVE SQLERRD(1) TO WSQLERRD1 */
            _.Move(DB.SQLERRD[1], ABEN.WABEND1.WSQLERRD1);

            /*" -905- MOVE SQLERRD(2) TO WSQLERRD2 */
            _.Move(DB.SQLERRD[2], ABEN.WABEND1.WSQLERRD2);

            /*" -906- DISPLAY WABEND. */
            _.Display(ABEN.WABEND);

            /*" -908- DISPLAY WABEND1. */
            _.Display(ABEN.WABEND1);

            /*" -908- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -915- CLOSE ENTRADA SAIDA01 SAIDA02 SAIDA03. */
            ENTRADA.Close();
            SAIDA01.Close();
            SAIDA02.Close();
            SAIDA03.Close();

            /*" -917- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -917- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}