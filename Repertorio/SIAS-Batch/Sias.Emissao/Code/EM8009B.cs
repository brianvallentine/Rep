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
using Sias.Emissao.DB2.EM8009B;

namespace Code
{
    public class EM8009B
    {
        public bool IsCall { get; set; }

        public EM8009B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------                                 */
        /*"      *                                                                       */
        /*"      *                                                                       */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  COBRANCA                           *      */
        /*"      *   PROGRAMA ...............  EM8009B                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA DE REQUISITOS..  CLOVIS/DANIELA MARTINO             *      */
        /*"      *   PROGRAMADOR ............  WANGER C SILVA                     *      */
        /*"      *   CADMUS .... ............  XX.XXX    (PROJETO VISAO)          *      */
        /*"      *   DATA CODIFICACAO .......  11/10/2010                         *      */
        /*"      *   DATA REVISAO ...........  09/12/2010 - CLOVIS                *      */
        /*"      *   DATA REVISAO ...........  21/12/2010 - CLOVIS                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO .................  GERACAO DE ARQUIVOS DO LATOUT      *      */
        /*"      *                             ARQUIVO H PARA O CNAB ( SICAP )    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                    A L T E R A C O E S                         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 11 - DEMANDA 582106                                   *      */
        /*"      *             - APONTAR O CONVENIO 912085 PARA A SAIDA4, POIS ELE*      */
        /*"      *               SUBSTITUIRA O 912861 CRIADO PARA O AMPARO NO     *      */
        /*"      *               SISPL. ELE PRECISA IR PARA O CB6249B E NAO PARA O*      */
        /*"      *               CB6241B, POIS NAO TEM NUMERO DE APOLICE GERADO NO*      */
        /*"      *               MOMENTO DA VENDA, COMO ERA O AMPARO WEB.         *      */
        /*"      *   EM 16/08/2024 - FRANK CARVALHO                               *      */
        /*"      *                                       PROCURE POR V.11         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 10 - DEMANDA 255354                                   *      */
        /*"      *             - CORRE��O PARA QUE O CONVENIO 912085 VOLTE A SER  *      */
        /*"      *               PROCESSADO.                                      *      */
        /*"      *   EM 24/08/2020 - FELIPE TOGAWA                                *      */
        /*"      *                                       PROCURE POR V.10         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 09 - DEMANDA 245802                                   *      */
        /*"      *             - PASSA A PROCESSAR O CONVENIO 912090, DE PROPOSTAS*      */
        /*"      *               VENDIDAS NO CAIXA TEM (PRODUTO 3716).            *      */
        /*"      *             - COLOQUEI NO MESMO ARQUIVO DO 912086 PORQUE SERA  *      */
        /*"      *               PROCESSADO PELO CB6248B TAMBEM.                  *      */
        /*"      *                                                                *      */
        /*"      *   EM 27/07/2020 - CLAUDETE RADEL                               *      */
        /*"      *                                       PROCURE POR V.09         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 08 - ABEND 183004/INCIDENTE JAZZ 251036               *      */
        /*"      *             - CRIAR UM CODIGO DE AVISO DIFERENTE PARA OS CONVE-*      */
        /*"      *               NIOS 912086 E 912087, POIS SE CHEGAR UM ARQUIVO  *      */
        /*"      *               DO CONVEIO VELHO E UM ARQUIVO DO CONVENIO NOVO,  *      */
        /*"      *               E GERADO UM MESMO NUMERO DE NSAC E DA ERRO NO    *      */
        /*"      *               CB6249B, AO INSERIR NA AVISO_CREDITO.            *      */
        /*"      *                                                                *      */
        /*"      *   EM 09/07/2020 - CLAUDETE RADEL                               *      */
        /*"      *                                       PROCURE POR V.08         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 07 - DEMANDA 247278                                   *      */
        /*"      *             - PASSAR A PROCESSAR OS CONVENIOS 912086 E 912087, *      */
        /*"      *               QUE IRAO SUBSTITUIR OS CONVENIOS 911334 E 912014,*      */
        /*"      *               RESPECTIVAMENTE.                                 *      */
        /*"      *             - A PRINCIPIO OS DOIS CONVENIOS VAO CONVIVER JUNTOS*      */
        /*"      *               MAS O OBJETIVO � QUE OS CONVENIOS ANTIGOS NAO SE-*      */
        /*"      *               JAM PROCESSADOS MAIS, POR ISSO, NAO ME XINGUE    *      */
        /*"      *               PERGUNTANDO PORQUE NAO CRIEI ARQUIVOS NOVOS.:)   *      */
        /*"      *                                                                *      */
        /*"      *   EM 09/06/2020 - CLAUDETE RADEL                               *      */
        /*"      *                                       PROCURE POR V.07         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 06 - HIST 188.377                                     *      */
        /*"      *             - PREPARAR PROGRAMA PARA PROCESSAMENTO DA JV1      *      */
        /*"      *                                                                *      */
        /*"      *   EM 19/01/2019 - HUSNI ALI HUSNI                              *      */
        /*"      *                                       PROCURE POR JV101        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 05 - ATENDER O NOVO CONVENIO 912014                   *      */
        /*"      *             - DEMANDA 169178                                   *      */
        /*"      *                                                                *      */
        /*"      *   EM 19/10/2018 - RILDO SICO                                   *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.05         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 04 -   NSGD - CADMUS 103659.                          *      */
        /*"      *               - NOVA SOLUCAO DE GESTAO DE DEPOSITOS            *      */
        /*"      *                                                                *      */
        /*"      *   EM 29/04/2015 - COREON                                       *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.04         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 03 - CAD  60.449                                      *      */
        /*"      *                                                                *      */
        /*"      *              - TRATAR AJUSTE NO LAYOUT DO ARQ-H PARA EMPRESAS  *      */
        /*"      *                PARCEIRAS.                                      *      */
        /*"      *              - RETIRADA DO AJUSTE EFETUADO NA V.02             *      */
        /*"      *                                                                *      */
        /*"      *   EM 18/10/2012 - CLOVIS                                       *      */
        /*"      *                                          PROCURE POR V.03      *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 02 - CAD  58.719 / 58.917                             *      */
        /*"      *                                                                *      */
        /*"      *              - TRATAR AJUSTE NO LAYOUT DO ARQ-H PARA EMPRESAS. *      */
        /*"      *                PARCEIRAS.                                      *      */
        /*"      *                                                                *      */
        /*"      *   EM 10/11/2011 - MARCO PAIVA (FAST COMPUTER)                  *      */
        /*"      *                                          PROCURE POR V.02      *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 01 - CAD 201.132                                      *      */
        /*"      *                                                                *      */
        /*"      *              - PASSA A TRATAR O CONVENIO 02100 (TRAY)          *      */
        /*"      *                                                                *      */
        /*"      *   EM 06/09/2011 - MARCO PAIVA (FAST COMPUTER)                  *      */
        /*"      *                                          PROCURE POR V.01      *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        #endregion


        #region VARIABLES

        public FileBasis _ENTRADA { get; set; } = new FileBasis(new PIC("X", "300", "X(300)"));

        public FileBasis ENTRADA
        {
            get
            {
                _.Move(REG_ENTRADA, _ENTRADA); VarBasis.RedefinePassValue(REG_ENTRADA, _ENTRADA, REG_ENTRADA); return _ENTRADA;
            }
        }
        public FileBasis _SAIDA01 { get; set; } = new FileBasis(new PIC("X", "150", "X(150)"));

        public FileBasis SAIDA01
        {
            get
            {
                _.Move(REG_SAIDA01, _SAIDA01); VarBasis.RedefinePassValue(REG_SAIDA01, _SAIDA01, REG_SAIDA01); return _SAIDA01;
            }
        }
        public FileBasis _SAIDA02 { get; set; } = new FileBasis(new PIC("X", "150", "X(150)"));

        public FileBasis SAIDA02
        {
            get
            {
                _.Move(REG_SAIDA02, _SAIDA02); VarBasis.RedefinePassValue(REG_SAIDA02, _SAIDA02, REG_SAIDA02); return _SAIDA02;
            }
        }
        public FileBasis _SAIDA03 { get; set; } = new FileBasis(new PIC("X", "150", "X(150)"));

        public FileBasis SAIDA03
        {
            get
            {
                _.Move(REG_SAIDA03, _SAIDA03); VarBasis.RedefinePassValue(REG_SAIDA03, _SAIDA03, REG_SAIDA03); return _SAIDA03;
            }
        }
        public FileBasis _SAIDA04 { get; set; } = new FileBasis(new PIC("X", "150", "X(150)"));

        public FileBasis SAIDA04
        {
            get
            {
                _.Move(REG_SAIDA04, _SAIDA04); VarBasis.RedefinePassValue(REG_SAIDA04, _SAIDA04, REG_SAIDA04); return _SAIDA04;
            }
        }
        public SortBasis<EM8009B_REG_ARQSORT> ARQSORT { get; set; } = new SortBasis<EM8009B_REG_ARQSORT>(new EM8009B_REG_ARQSORT());
        /*"01        REG-ARQSORT.*/
        public EM8009B_REG_ARQSORT REG_ARQSORT { get; set; } = new EM8009B_REG_ARQSORT();
        public class EM8009B_REG_ARQSORT : VarBasis
        {
            /*"  10      SOR-TIPO-ARQUIVO         PIC  X(010).*/
            public StringBasis SOR_TIPO_ARQUIVO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  10      SOR-BANCO                PIC  9(003).*/
            public IntBasis SOR_BANCO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
            /*"  10      SOR-CONVENIO             PIC  9(006).*/
            public IntBasis SOR_CONVENIO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"  10      SOR-NSAC                 PIC  9(005).*/
            public IntBasis SOR_NSAC { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
            /*"  10      SOR-DTGERACAO.*/
            public EM8009B_SOR_DTGERACAO SOR_DTGERACAO { get; set; } = new EM8009B_SOR_DTGERACAO();
            public class EM8009B_SOR_DTGERACAO : VarBasis
            {
                /*"    15    SOR-ANO-HEADER           PIC  9(004).*/
                public IntBasis SOR_ANO_HEADER { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    15    SOR-MES-HEADER           PIC  9(002).*/
                public IntBasis SOR_MES_HEADER { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    15    SOR-DIA-HEADER           PIC  9(002).*/
                public IntBasis SOR_DIA_HEADER { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  10      SOR-COD-REGISTRO         PIC  X(001).*/
            }
            public StringBasis SOR_COD_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  10      SOR-AGENCIA              PIC  9(004).*/
            public IntBasis SOR_AGENCIA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  10      SOR-OPERACAO             PIC  9(004).*/
            public IntBasis SOR_OPERACAO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  10      SOR-NUM-CONTA            PIC  9(012).*/
            public IntBasis SOR_NUM_CONTA { get; set; } = new IntBasis(new PIC("9", "12", "9(012)."));
            /*"  10      SOR-DIG-CONTA            PIC  9(001).*/
            public IntBasis SOR_DIG_CONTA { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"  10      SOR-DATA-PAGTO.*/
            public EM8009B_SOR_DATA_PAGTO SOR_DATA_PAGTO { get; set; } = new EM8009B_SOR_DATA_PAGTO();
            public class EM8009B_SOR_DATA_PAGTO : VarBasis
            {
                /*"    15    SOR-ANO-PAGTO            PIC  9(004).*/
                public IntBasis SOR_ANO_PAGTO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    15    SOR-MES-PAGTO            PIC  9(002).*/
                public IntBasis SOR_MES_PAGTO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    15    SOR-DIA-PAGTO            PIC  9(002).*/
                public IntBasis SOR_DIA_PAGTO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  10      SOR-DATA-CREDITO.*/
            }
            public EM8009B_SOR_DATA_CREDITO SOR_DATA_CREDITO { get; set; } = new EM8009B_SOR_DATA_CREDITO();
            public class EM8009B_SOR_DATA_CREDITO : VarBasis
            {
                /*"    15    SOR-ANO-CRED             PIC  9(004).*/
                public IntBasis SOR_ANO_CRED { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    15    SOR-MES-CRED             PIC  9(002).*/
                public IntBasis SOR_MES_CRED { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    15    SOR-DIA-CRED             PIC  9(002).*/
                public IntBasis SOR_DIA_CRED { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  10      SOR-BARRA01              PIC  X(016).*/
            }
            public StringBasis SOR_BARRA01 { get; set; } = new StringBasis(new PIC("X", "16", "X(016)."), @"");
            /*"  10      SOR-CODBANCO             PIC  9(003).*/
            public IntBasis SOR_CODBANCO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
            /*"  10      SOR-BARRA02              PIC  X(005).*/
            public StringBasis SOR_BARRA02 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)."), @"");
            /*"  10      SOR-NUM-SIVPF            PIC  9(013).*/
            public IntBasis SOR_NUM_SIVPF { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
            /*"  10      SOR-BARRA03              PIC  X(007).*/
            public StringBasis SOR_BARRA03 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)."), @"");
            /*"  10      SOR-VALOR-PAGO           PIC  9(010)V99.*/
            public DoubleBasis SOR_VALOR_PAGO { get; set; } = new DoubleBasis(new PIC("9", "10", "9(010)V99."), 2);
            /*"  10      SOR-VALOR-TARIFA         PIC  9(005)V99.*/
            public DoubleBasis SOR_VALOR_TARIFA { get; set; } = new DoubleBasis(new PIC("9", "5", "9(005)V99."), 2);
            /*"  10      SOR-DADOS-BANCO          PIC  X(026).*/
            public StringBasis SOR_DADOS_BANCO { get; set; } = new StringBasis(new PIC("X", "26", "X(026)."), @"");
            /*"01        REG-ENTRADA              PIC  X(300).*/
        }
        public StringBasis REG_ENTRADA { get; set; } = new StringBasis(new PIC("X", "300", "X(300)."), @"");
        /*"01        REG-SAIDA01                 PIC  X(150).*/
        public StringBasis REG_SAIDA01 { get; set; } = new StringBasis(new PIC("X", "150", "X(150)."), @"");
        /*"01        REG-SAIDA02                 PIC  X(150).*/
        public StringBasis REG_SAIDA02 { get; set; } = new StringBasis(new PIC("X", "150", "X(150)."), @"");
        /*"01        REG-SAIDA03                 PIC  X(150).*/
        public StringBasis REG_SAIDA03 { get; set; } = new StringBasis(new PIC("X", "150", "X(150)."), @"");
        /*"01        REG-SAIDA04                 PIC  X(150).*/
        public StringBasis REG_SAIDA04 { get; set; } = new StringBasis(new PIC("X", "150", "X(150)."), @"");

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77    WSHOST-NRAVISO1           PIC S9(009)    VALUE +0   COMP.*/
        public IntBasis WSHOST_NRAVISO1 { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    WSHOST-NRAVISO2           PIC S9(009)    VALUE +0   COMP.*/
        public IntBasis WSHOST_NRAVISO2 { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01  W.*/
        public EM8009B_W W { get; set; } = new EM8009B_W();
        public class EM8009B_W : VarBasis
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
            /*"  03  ATU-CONVENIO              PIC  9(006)    VALUE   ZEROS.*/
            public IntBasis ATU_CONVENIO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  03  ANT-CONVENIO              PIC  9(006)    VALUE   ZEROS.*/
            public IntBasis ANT_CONVENIO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  03  AC-GRAV-SAIDA01           PIC  9(009)    VALUE   ZEROS.*/
            public IntBasis AC_GRAV_SAIDA01 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  AC-GRAV-SAIDA02           PIC  9(009)    VALUE   ZEROS.*/
            public IntBasis AC_GRAV_SAIDA02 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  AC-GRAV-SAIDA03           PIC  9(009)    VALUE   ZEROS.*/
            public IntBasis AC_GRAV_SAIDA03 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  AC-GRAV-SAIDA04           PIC  9(009)    VALUE   ZEROS.*/
            public IntBasis AC_GRAV_SAIDA04 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  AC-GRAV-CV912086          PIC  9(009)    VALUE   ZEROS.*/
            public IntBasis AC_GRAV_CV912086 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  AC-GRAV-CV912087          PIC  9(009)    VALUE   ZEROS.*/
            public IntBasis AC_GRAV_CV912087 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  AC-GRAV-CV912090          PIC  9(009)    VALUE   ZEROS.*/
            public IntBasis AC_GRAV_CV912090 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  AC-GRAV-CV912085          PIC  9(009)    VALUE   ZEROS.*/
            public IntBasis AC_GRAV_CV912085 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  WS-NRSEQ                  PIC  9(009)    VALUE   ZEROS.*/
            public IntBasis WS_NRSEQ { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  WS-TOTREG                 PIC  9(009)    VALUE   ZEROS.*/
            public IntBasis WS_TOTREG { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  WS-VALOR-0                PIC S9(16)V99  VALUE  +0.*/
            public DoubleBasis WS_VALOR_0 { get; set; } = new DoubleBasis(new PIC("S9", "16", "S9(16)V99"), 2);
            /*"  03  WS9-NRO-NSAC              PIC  9(004)    VALUE   ZEROS.*/
            public IntBasis WS9_NRO_NSAC { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  03         WDATA-CABEC.*/
            public EM8009B_WDATA_CABEC WDATA_CABEC { get; set; } = new EM8009B_WDATA_CABEC();
            public class EM8009B_WDATA_CABEC : VarBasis
            {
                /*"    05       WDATA-DD-CABEC    PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WDATA_DD_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    05       FILLER            PIC  X(001)    VALUE '/'.*/
                public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    05       WDATA-MM-CABEC    PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WDATA_MM_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    05       FILLER            PIC  X(001)    VALUE '/'.*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    05       WDATA-AA-CABEC    PIC  9(004)    VALUE ZEROS.*/
                public IntBasis WDATA_AA_CABEC { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"  03         WDATA-REL          PIC  X(010)    VALUE   SPACES.*/
            }
            public StringBasis WDATA_REL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  03         FILLER             REDEFINES      WDATA-REL.*/
            private _REDEF_EM8009B_FILLER_2 _filler_2 { get; set; }
            public _REDEF_EM8009B_FILLER_2 FILLER_2
            {
                get { _filler_2 = new _REDEF_EM8009B_FILLER_2(); _.Move(WDATA_REL, _filler_2); VarBasis.RedefinePassValue(WDATA_REL, _filler_2, WDATA_REL); _filler_2.ValueChanged += () => { _.Move(_filler_2, WDATA_REL); }; return _filler_2; }
                set { VarBasis.RedefinePassValue(value, _filler_2, WDATA_REL); }
            }  //Redefines
            public class _REDEF_EM8009B_FILLER_2 : VarBasis
            {
                /*"    10       WDAT-REL-ANO       PIC  9(004).*/
                public IntBasis WDAT_REL_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       FILLER             PIC  X(001).*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDAT-REL-MES       PIC  9(002).*/
                public IntBasis WDAT_REL_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       FILLER             PIC  X(001).*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDAT-REL-DIA       PIC  9(002).*/
                public IntBasis WDAT_REL_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03         WS0-NRAVISO        PIC  9(009)    VALUE   ZEROS.*/

                public _REDEF_EM8009B_FILLER_2()
                {
                    WDAT_REL_ANO.ValueChanged += OnValueChanged;
                    FILLER_3.ValueChanged += OnValueChanged;
                    WDAT_REL_MES.ValueChanged += OnValueChanged;
                    FILLER_4.ValueChanged += OnValueChanged;
                    WDAT_REL_DIA.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WS0_NRAVISO { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03         FILLER             REDEFINES      WS0-NRAVISO.*/
            private _REDEF_EM8009B_FILLER_5 _filler_5 { get; set; }
            public _REDEF_EM8009B_FILLER_5 FILLER_5
            {
                get { _filler_5 = new _REDEF_EM8009B_FILLER_5(); _.Move(WS0_NRAVISO, _filler_5); VarBasis.RedefinePassValue(WS0_NRAVISO, _filler_5, WS0_NRAVISO); _filler_5.ValueChanged += () => { _.Move(_filler_5, WS0_NRAVISO); }; return _filler_5; }
                set { VarBasis.RedefinePassValue(value, _filler_5, WS0_NRAVISO); }
            }  //Redefines
            public class _REDEF_EM8009B_FILLER_5 : VarBasis
            {
                /*"    10       WS0-PRE-AVISO      PIC  9(004).*/
                public IntBasis WS0_PRE_AVISO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       WS0-NRO-MOV        PIC  9(001).*/
                public IntBasis WS0_NRO_MOV { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    10       WS0-NRO-NSAC       PIC  9(004).*/
                public IntBasis WS0_NRO_NSAC { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"01  ABEN.*/

                public _REDEF_EM8009B_FILLER_5()
                {
                    WS0_PRE_AVISO.ValueChanged += OnValueChanged;
                    WS0_NRO_MOV.ValueChanged += OnValueChanged;
                    WS0_NRO_NSAC.ValueChanged += OnValueChanged;
                }

            }
        }
        public EM8009B_ABEN ABEN { get; set; } = new EM8009B_ABEN();
        public class EM8009B_ABEN : VarBasis
        {
            /*"  03        WABEND.*/
            public EM8009B_WABEND WABEND { get; set; } = new EM8009B_WABEND();
            public class EM8009B_WABEND : VarBasis
            {
                /*"    05      FILLER              PIC  X(010) VALUE           ' EM8009B  '.*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" EM8009B  ");
                /*"    05      FILLER              PIC  X(028) VALUE           ' *** ERRO  EXEC SQL  NUMERO '.*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @" *** ERRO  EXEC SQL  NUMERO ");
                /*"    05      WNR-EXEC-SQL        PIC  X(040) VALUE    SPACES.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"  03        WABEND1.*/
            }
            public EM8009B_WABEND1 WABEND1 { get; set; } = new EM8009B_WABEND1();
            public class EM8009B_WABEND1 : VarBasis
            {
                /*"    05      FILLER              PIC  X(011) VALUE           ' SQLCODE = '.*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @" SQLCODE = ");
                /*"    05      WSQLCODE            PIC  ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                /*"    05      FILLER              PIC  X(012) VALUE           ' SQLERRD1 = '.*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @" SQLERRD1 = ");
                /*"    05      WSQLERRD1           PIC  ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLERRD1 { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                /*"    05      FILLER              PIC  X(012) VALUE           ' SQLERRD2 = '.*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @" SQLERRD2 = ");
                /*"    05      WSQLERRD2           PIC  ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLERRD2 { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                /*"01        HEADER-REGISTRO.*/
            }
        }
        public EM8009B_HEADER_REGISTRO HEADER_REGISTRO { get; set; } = new EM8009B_HEADER_REGISTRO();
        public class EM8009B_HEADER_REGISTRO : VarBasis
        {
            /*"  05      HEADER-CODREGISTRO  PIC  X(001).*/
            public StringBasis HEADER_CODREGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  05      HEADER-CODREMESSA   PIC  9(001).*/
            public IntBasis HEADER_CODREMESSA { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"  05      HEADER-CODCONVENIO  PIC  9(006).*/
            public IntBasis HEADER_CODCONVENIO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"  05      FILLER              PIC  X(014).*/
            public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)."), @"");
            /*"  05      HEADER-NOMEMPRESA   PIC  X(020).*/
            public StringBasis HEADER_NOMEMPRESA { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
            /*"  05      HEADER-CODBANCO     PIC  9(003).*/
            public IntBasis HEADER_CODBANCO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
            /*"  05      HEADER-NOMBANCO     PIC  X(020).*/
            public StringBasis HEADER_NOMBANCO { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
            /*"  05      HEADER-DATGERACAO.*/
            public EM8009B_HEADER_DATGERACAO HEADER_DATGERACAO { get; set; } = new EM8009B_HEADER_DATGERACAO();
            public class EM8009B_HEADER_DATGERACAO : VarBasis
            {
                /*"    10    HEADER-ANO          PIC  9(004).*/
                public IntBasis HEADER_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10    HEADER-MES          PIC  9(002).*/
                public IntBasis HEADER_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10    HEADER-DIA          PIC  9(002).*/
                public IntBasis HEADER_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05      HEADER-NSA          PIC  9(006).*/
            }
            public IntBasis HEADER_NSA { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"  05      HEADER-VERSAO       PIC  9(002).*/
            public IntBasis HEADER_VERSAO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"  05      FILLER              PIC  X(069).*/
            public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "69", "X(069)."), @"");
            /*"01        MOVCC-REGISTRO.*/
        }
        public EM8009B_MOVCC_REGISTRO MOVCC_REGISTRO { get; set; } = new EM8009B_MOVCC_REGISTRO();
        public class EM8009B_MOVCC_REGISTRO : VarBasis
        {
            /*"  05      MOVCC-CODREGISTRO  PIC  X(001).*/
            public StringBasis MOVCC_CODREGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  05      MOVCC-CTACOBRANCA.*/
            public EM8009B_MOVCC_CTACOBRANCA MOVCC_CTACOBRANCA { get; set; } = new EM8009B_MOVCC_CTACOBRANCA();
            public class EM8009B_MOVCC_CTACOBRANCA : VarBasis
            {
                /*"    10    MOVCC-AGENCIA      PIC  9(004).*/
                public IntBasis MOVCC_AGENCIA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10    MOVCC-OPERACAO     PIC  9(004).*/
                public IntBasis MOVCC_OPERACAO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10    MOVCC-NUMCTA       PIC  9(012).*/
                public IntBasis MOVCC_NUMCTA { get; set; } = new IntBasis(new PIC("9", "12", "9(012)."));
                /*"    10    MOVCC-DIGCTA       PIC  9(001).*/
                public IntBasis MOVCC_DIGCTA { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    10    FILLER             PIC  X(004).*/
                public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)."), @"");
                /*"  05      MOVCC-DTPAGTO.*/
            }
            public EM8009B_MOVCC_DTPAGTO MOVCC_DTPAGTO { get; set; } = new EM8009B_MOVCC_DTPAGTO();
            public class EM8009B_MOVCC_DTPAGTO : VarBasis
            {
                /*"    10    MOVCC-ANOPAG       PIC  9(004).*/
                public IntBasis MOVCC_ANOPAG { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10    MOVCC-MESPAG       PIC  9(002).*/
                public IntBasis MOVCC_MESPAG { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10    MOVCC-DIAPAG       PIC  9(002).*/
                public IntBasis MOVCC_DIAPAG { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05      MOVCC-DTCREDITO.*/
            }
            public EM8009B_MOVCC_DTCREDITO MOVCC_DTCREDITO { get; set; } = new EM8009B_MOVCC_DTCREDITO();
            public class EM8009B_MOVCC_DTCREDITO : VarBasis
            {
                /*"    10    MOVCC-ANOCRE       PIC  9(004).*/
                public IntBasis MOVCC_ANOCRE { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10    MOVCC-MESCRE       PIC  9(002).*/
                public IntBasis MOVCC_MESCRE { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10    MOVCC-DIACRE       PIC  9(002).*/
                public IntBasis MOVCC_DIACRE { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05      MOVCC-CODBARRA.*/
            }
            public EM8009B_MOVCC_CODBARRA MOVCC_CODBARRA { get; set; } = new EM8009B_MOVCC_CODBARRA();
            public class EM8009B_MOVCC_CODBARRA : VarBasis
            {
                /*"    10    MOVCC-BARRA01      PIC  X(016).*/
                public StringBasis MOVCC_BARRA01 { get; set; } = new StringBasis(new PIC("X", "16", "X(016)."), @"");
                /*"    10    MOVCC-BANCO        PIC  9(003).*/
                public IntBasis MOVCC_BANCO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"    10    MOVCC-BARRA02      PIC  X(005).*/
                public StringBasis MOVCC_BARRA02 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)."), @"");
                /*"    10    MOVCC-NUMSIVPF     PIC  9(013).*/
                public IntBasis MOVCC_NUMSIVPF { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
                /*"    10    MOVCC-BARRA03      PIC  X(007).*/
                public StringBasis MOVCC_BARRA03 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)."), @"");
                /*"  05      MOVCC-VLRPAGO      PIC  9(010)V99.*/
            }
            public DoubleBasis MOVCC_VLRPAGO { get; set; } = new DoubleBasis(new PIC("9", "10", "9(010)V99."), 2);
            /*"  05      MOVCC-VLRTARIFA    PIC  9(005)V99.*/
            public DoubleBasis MOVCC_VLRTARIFA { get; set; } = new DoubleBasis(new PIC("9", "5", "9(005)V99."), 2);
            /*"  05      MOVCC-NRSEQREG     PIC  9(008).*/
            public IntBasis MOVCC_NRSEQREG { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"  05      MOVCC-PTOVENDA     PIC  9(004).*/
            public IntBasis MOVCC_PTOVENDA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05      FILLER             PIC  X(004).*/
            public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)."), @"");
            /*"  05      MOVCC-ANEXO1       PIC  X(001).*/
            public StringBasis MOVCC_ANEXO1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  05      MOVCC-ANEXO2       PIC  X(023).*/
            public StringBasis MOVCC_ANEXO2 { get; set; } = new StringBasis(new PIC("X", "23", "X(023)."), @"");
            /*"  05      MOVCC-FORMAPAG     PIC  9(001).*/
            public IntBasis MOVCC_FORMAPAG { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"  05      MOVCC-FUTURO       PIC  X(004).*/
            public StringBasis MOVCC_FUTURO { get; set; } = new StringBasis(new PIC("X", "4", "X(004)."), @"");
            /*"01        TRAILL-REGISTRO.*/
        }
        public EM8009B_TRAILL_REGISTRO TRAILL_REGISTRO { get; set; } = new EM8009B_TRAILL_REGISTRO();
        public class EM8009B_TRAILL_REGISTRO : VarBasis
        {
            /*"  05      TRAILL-CODREGISTRO  PIC  X(001).*/
            public StringBasis TRAILL_CODREGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  05      TRAILL-TOTREGISTRO  PIC  9(006).*/
            public IntBasis TRAILL_TOTREGISTRO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"  05      TRAILL-VLRTOTPAG    PIC  9(015)V99.*/
            public DoubleBasis TRAILL_VLRTOTPAG { get; set; } = new DoubleBasis(new PIC("9", "15", "9(015)V99."), 2);
            /*"  05      FILLER              PIC  X(126).*/
            public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "126", "X(126)."), @"");
        }


        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.AVISOCRE AVISOCRE { get; set; } = new Dclgens.AVISOCRE();
        public Dclgens.JVBKINCL JVBKINCL { get; set; } = new Dclgens.JVBKINCL();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string ARQSORT_FILE_NAME_P, string ENTRADA_FILE_NAME_P, string SAIDA01_FILE_NAME_P, string SAIDA02_FILE_NAME_P, string SAIDA03_FILE_NAME_P, string SAIDA04_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                ARQSORT.SetFile(ARQSORT_FILE_NAME_P);
                ENTRADA.SetFile(ENTRADA_FILE_NAME_P);
                SAIDA01.SetFile(SAIDA01_FILE_NAME_P);
                SAIDA02.SetFile(SAIDA02_FILE_NAME_P);
                SAIDA03.SetFile(SAIDA03_FILE_NAME_P);
                SAIDA04.SetFile(SAIDA04_FILE_NAME_P);

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
            /*" -388- MOVE '0000' TO WNR-EXEC-SQL. */
            _.Move("0000", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -389- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -391- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -393- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -396- DISPLAY '---------------------------------------------------' */
            _.Display($"---------------------------------------------------");

            /*" -397- DISPLAY '       EM8009B - PROCESSA ARQUIVO <SICAP>          ' */
            _.Display($"       EM8009B - PROCESSA ARQUIVO <SICAP>          ");

            /*" -398- DISPLAY '                                                   ' */
            _.Display($"                                                   ");

            /*" -400- DISPLAY 'VERSAO V.11: ' FUNCTION WHEN-COMPILED ' - DEMANDA 582106 - 16/08/2024.' */

            $"VERSAO V.11: FUNCTION{_.WhenCompiled()} - DEMANDA 582106 - 16/08/2024."
            .Display();

            /*" -401- DISPLAY ' ' */
            _.Display($" ");

            /*" -408- DISPLAY 'INICIOU PROCESSAMENTO EM ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2) */

            $"INICIOU PROCESSAMENTO EM {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
            .Display();

            /*" -409- DISPLAY '   ' */
            _.Display($"   ");

            /*" -411- DISPLAY '------------------------------------------------' */
            _.Display($"------------------------------------------------");

            /*" -413- PERFORM R0050-00-INICIO. */

            R0050_00_INICIO_SECTION();

            /*" -422- SORT ARQSORT ON ASCENDING KEY SOR-BANCO SOR-CONVENIO SOR-NSAC INPUT PROCEDURE R0200-00-INPUT-SORT THRU R0200-99-SAIDA OUTPUT PROCEDURE R0500-00-OUTPUT-SORT THRU R0500-99-SAIDA. */
            ARQSORT.Sort("SOR-BANCO,SOR-CONVENIO,SOR-NSAC", () => R0200_00_INPUT_SORT_SECTION(), () => R0500_00_OUTPUT_SORT_SECTION());

            /*" -0- FLUXCONTROL_PERFORM R0000_90_FINALIZA */

            R0000_90_FINALIZA();

        }

        [StopWatch]
        /*" R0000-90-FINALIZA */
        private void R0000_90_FINALIZA(bool isPerform = false)
        {
            /*" -426- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -434- CLOSE ENTRADA SAIDA01 SAIDA02 SAIDA03 SAIDA04. */
            ENTRADA.Close();
            SAIDA01.Close();
            SAIDA02.Close();
            SAIDA03.Close();
            SAIDA04.Close();

            /*" -436- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -437- DISPLAY ' ' */
            _.Display($" ");

            /*" -438- DISPLAY 'EM8009B - FIM NORMAL' . */
            _.Display($"EM8009B - FIM NORMAL");

            /*" -440- DISPLAY ' ' . */
            _.Display($" ");

            /*" -440- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0050-00-INICIO-SECTION */
        private void R0050_00_INICIO_SECTION()
        {
            /*" -450- MOVE '0050' TO WNR-EXEC-SQL. */
            _.Move("0050", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -451- OPEN INPUT ENTRADA */
            ENTRADA.Open(REG_ENTRADA);

            /*" -456- OUTPUT SAIDA01 SAIDA02 SAIDA03 SAIDA04. */
            SAIDA04.Open(REG_SAIDA04);

            /*" -458- PERFORM R0100-00-SELECT-SISTEMA. */

            R0100_00_SELECT_SISTEMA_SECTION();

            /*" -459- MOVE SPACES TO WFIM-MOVIMENTO. */
            _.Move("", W.WFIM_MOVIMENTO);

            /*" -461- PERFORM R0300-00-LER-MOVIMENTO. */

            R0300_00_LER_MOVIMENTO_SECTION();

            /*" -462- IF WFIM-MOVIMENTO NOT EQUAL SPACES */

            if (!W.WFIM_MOVIMENTO.IsEmpty())
            {

                /*" -462- GO TO R9990-00-SEM-MOVIMENTO. */

                R9990_00_SEM_MOVIMENTO_SECTION(); //GOTO
                return;
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0050_99_SAIDA*/

        [StopWatch]
        /*" R0100-00-SELECT-SISTEMA-SECTION */
        private void R0100_00_SELECT_SISTEMA_SECTION()
        {
            /*" -472- MOVE '0100' TO WNR-EXEC-SQL. */
            _.Move("0100", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -480- PERFORM R0100_00_SELECT_SISTEMA_DB_SELECT_1 */

            R0100_00_SELECT_SISTEMA_DB_SELECT_1();

            /*" -483- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -484- DISPLAY 'R0100-00 - PROBLEMAS NO SELECT(SISTEMAS)' */
                _.Display($"R0100-00 - PROBLEMAS NO SELECT(SISTEMAS)");

                /*" -484- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0100-00-SELECT-SISTEMA-DB-SELECT-1 */
        public void R0100_00_SELECT_SISTEMA_DB_SELECT_1()
        {
            /*" -480- EXEC SQL SELECT DATA_MOV_ABERTO INTO :SISTEMAS-DATA-MOV-ABERTO FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'EM' WITH UR END-EXEC. */

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
            /*" -494- MOVE '0200' TO WNR-EXEC-SQL. */
            _.Move("0200", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -497- PERFORM R0350-00-PROCESSA-MOVIMENTO UNTIL WFIM-MOVIMENTO NOT EQUAL SPACES. */

            while (!(!W.WFIM_MOVIMENTO.IsEmpty()))
            {

                R0350_00_PROCESSA_MOVIMENTO_SECTION();
            }

            /*" -498- DISPLAY ' ' */
            _.Display($" ");

            /*" -499- DISPLAY 'LIDOS MOVIMENTO ....... ' LD-MOVIMENTO */
            _.Display($"LIDOS MOVIMENTO ....... {W.LD_MOVIMENTO}");

            /*" -500- DISPLAY 'DESPREZA MOVIMENTO .... ' DP-MOVIMENTO */
            _.Display($"DESPREZA MOVIMENTO .... {W.DP_MOVIMENTO}");

            /*" -501- DISPLAY 'GRAVADOS SORT ......... ' GV-SORT */
            _.Display($"GRAVADOS SORT ......... {W.GV_SORT}");

            /*" -501- DISPLAY ' ' . */
            _.Display($" ");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_99_SAIDA*/

        [StopWatch]
        /*" R0300-00-LER-MOVIMENTO-SECTION */
        private void R0300_00_LER_MOVIMENTO_SECTION()
        {
            /*" -511- MOVE '0300' TO WNR-EXEC-SQL. */
            _.Move("0300", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -512- READ ENTRADA AT END */
            try
            {
                ENTRADA.Read(() =>
                {

                    /*" -514- MOVE 'S' TO WFIM-MOVIMENTO */
                    _.Move("S", W.WFIM_MOVIMENTO);

                    /*" -516- GO TO R0300-99-SAIDA. */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_99_SAIDA*/ //GOTO
                    return;
                });

                _.Move(ENTRADA.Value, REG_ENTRADA);

            }
            catch (GoToException ex)
            {
                return;
            }
            /*" -516- ADD 1 TO LD-MOVIMENTO. */
            W.LD_MOVIMENTO.Value = W.LD_MOVIMENTO + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_99_SAIDA*/

        [StopWatch]
        /*" R0350-00-PROCESSA-MOVIMENTO-SECTION */
        private void R0350_00_PROCESSA_MOVIMENTO_SECTION()
        {
            /*" -526- MOVE '0350' TO WNR-EXEC-SQL. */
            _.Move("0350", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -533- MOVE REG-ENTRADA TO REG-ARQSORT. */
            _.Move(ENTRADA?.Value, REG_ARQSORT);

            /*" -534-  EVALUATE SOR-CONVENIO  */

            /*" -535-  WHEN     911241  */

            /*" -535- IF   SOR-CONVENIO EQUALS      911241 */

            if (REG_ARQSORT.SOR_CONVENIO == 911241)
            {

                /*" -536- RELEASE REG-ARQSORT */
                ARQSORT.Release(REG_ARQSORT);

                /*" -537- ADD 1 TO GV-SORT */
                W.GV_SORT.Value = W.GV_SORT + 1;

                /*" -539-  WHEN     CVPCV-911241  */

                /*" -539- ELSE IF   SOR-CONVENIO EQUALS      CVPCV-911241 */
            }
            else

            if (REG_ARQSORT.SOR_CONVENIO == JVBKINCL.JV_CONVENIOS.CVPCV_911241)
            {

                /*" -540- RELEASE REG-ARQSORT */
                ARQSORT.Release(REG_ARQSORT);

                /*" -541- ADD 1 TO GV-SORT */
                W.GV_SORT.Value = W.GV_SORT + 1;

                /*" -542-  WHEN     JV1CV-911241  */

                /*" -542- ELSE IF   SOR-CONVENIO EQUALS      JV1CV-911241 */
            }
            else

            if (REG_ARQSORT.SOR_CONVENIO == JVBKINCL.JV_CONVENIOS.JV1CV_911241)
            {

                /*" -543- MOVE 911241 TO SOR-CONVENIO */
                _.Move(911241, REG_ARQSORT.SOR_CONVENIO);

                /*" -544- RELEASE REG-ARQSORT */
                ARQSORT.Release(REG_ARQSORT);

                /*" -545- ADD 1 TO GV-SORT */
                W.GV_SORT.Value = W.GV_SORT + 1;

                /*" -546-  WHEN     911334  */

                /*" -546- ELSE IF   SOR-CONVENIO EQUALS      911334 */
            }
            else

            if (REG_ARQSORT.SOR_CONVENIO == 911334)
            {

                /*" -547- RELEASE REG-ARQSORT */
                ARQSORT.Release(REG_ARQSORT);

                /*" -548- ADD 1 TO GV-SORT */
                W.GV_SORT.Value = W.GV_SORT + 1;

                /*" -550-  WHEN     CVPCV-911334  */

                /*" -550- ELSE IF   SOR-CONVENIO EQUALS      CVPCV-911334 */
            }
            else

            if (REG_ARQSORT.SOR_CONVENIO == JVBKINCL.JV_CONVENIOS.CVPCV_911334)
            {

                /*" -551- RELEASE REG-ARQSORT */
                ARQSORT.Release(REG_ARQSORT);

                /*" -552- ADD 1 TO GV-SORT */
                W.GV_SORT.Value = W.GV_SORT + 1;

                /*" -553-  WHEN     JV1CV-911334  */

                /*" -553- ELSE IF   SOR-CONVENIO EQUALS      JV1CV-911334 */
            }
            else

            if (REG_ARQSORT.SOR_CONVENIO == JVBKINCL.JV_CONVENIOS.JV1CV_911334)
            {

                /*" -554- MOVE 911334 TO SOR-CONVENIO */
                _.Move(911334, REG_ARQSORT.SOR_CONVENIO);

                /*" -555- RELEASE REG-ARQSORT */
                ARQSORT.Release(REG_ARQSORT);

                /*" -556- ADD 1 TO GV-SORT */
                W.GV_SORT.Value = W.GV_SORT + 1;

                /*" -557-  WHEN     021000  */

                /*" -557- ELSE IF   SOR-CONVENIO EQUALS      021000 */
            }
            else

            if (REG_ARQSORT.SOR_CONVENIO == 021000)
            {

                /*" -558- RELEASE REG-ARQSORT */
                ARQSORT.Release(REG_ARQSORT);

                /*" -559- ADD 1 TO GV-SORT */
                W.GV_SORT.Value = W.GV_SORT + 1;

                /*" -561-  WHEN     CVPCV-021000  */

                /*" -561- ELSE IF   SOR-CONVENIO EQUALS      CVPCV-021000 */
            }
            else

            if (REG_ARQSORT.SOR_CONVENIO == JVBKINCL.JV_CONVENIOS.CVPCV_021000)
            {

                /*" -562- RELEASE REG-ARQSORT */
                ARQSORT.Release(REG_ARQSORT);

                /*" -563- ADD 1 TO GV-SORT */
                W.GV_SORT.Value = W.GV_SORT + 1;

                /*" -564-  WHEN     JV1CV-021000  */

                /*" -564- ELSE IF   SOR-CONVENIO EQUALS      JV1CV-021000 */
            }
            else

            if (REG_ARQSORT.SOR_CONVENIO == JVBKINCL.JV_CONVENIOS.JV1CV_021000)
            {

                /*" -565- MOVE 021000 TO SOR-CONVENIO */
                _.Move(021000, REG_ARQSORT.SOR_CONVENIO);

                /*" -566- RELEASE REG-ARQSORT */
                ARQSORT.Release(REG_ARQSORT);

                /*" -567- ADD 1 TO GV-SORT */
                W.GV_SORT.Value = W.GV_SORT + 1;

                /*" -568-  WHEN     912014  */

                /*" -568- ELSE IF   SOR-CONVENIO EQUALS      912014 */
            }
            else

            if (REG_ARQSORT.SOR_CONVENIO == 912014)
            {

                /*" -569- RELEASE REG-ARQSORT */
                ARQSORT.Release(REG_ARQSORT);

                /*" -570- ADD 1 TO GV-SORT */
                W.GV_SORT.Value = W.GV_SORT + 1;

                /*" -572-  WHEN     CVPCV-912014  */

                /*" -572- ELSE IF   SOR-CONVENIO EQUALS      CVPCV-912014 */
            }
            else

            if (REG_ARQSORT.SOR_CONVENIO == JVBKINCL.JV_CONVENIOS.CVPCV_912014)
            {

                /*" -573- RELEASE REG-ARQSORT */
                ARQSORT.Release(REG_ARQSORT);

                /*" -574- ADD 1 TO GV-SORT */
                W.GV_SORT.Value = W.GV_SORT + 1;

                /*" -575-  WHEN     JV1CV-912014  */

                /*" -575- ELSE IF   SOR-CONVENIO EQUALS      JV1CV-912014 */
            }
            else

            if (REG_ARQSORT.SOR_CONVENIO == JVBKINCL.JV_CONVENIOS.JV1CV_912014)
            {

                /*" -576- MOVE 912014 TO SOR-CONVENIO */
                _.Move(912014, REG_ARQSORT.SOR_CONVENIO);

                /*" -577- RELEASE REG-ARQSORT */
                ARQSORT.Release(REG_ARQSORT);

                /*" -578- ADD 1 TO GV-SORT */
                W.GV_SORT.Value = W.GV_SORT + 1;

                /*" -579-  WHEN     912090  */

                /*" -579- ELSE IF   SOR-CONVENIO EQUALS      912090 */
            }
            else

            if (REG_ARQSORT.SOR_CONVENIO == 912090)
            {

                /*" -580- RELEASE REG-ARQSORT */
                ARQSORT.Release(REG_ARQSORT);

                /*" -581- ADD 1 TO GV-SORT */
                W.GV_SORT.Value = W.GV_SORT + 1;

                /*" -582-  WHEN OTHER  */

                /*" -582- ELSE */
            }
            else
            {


                /*" -583- ADD 1 TO DP-MOVIMENTO */
                W.DP_MOVIMENTO.Value = W.DP_MOVIMENTO + 1;

                /*" -584-  END-EVALUATE  */

                /*" -584- END-IF */
            }


            /*" -584- . */

            /*" -0- FLUXCONTROL_PERFORM R0350_90_LEITURA */

            R0350_90_LEITURA();

        }

        [StopWatch]
        /*" R0350-90-LEITURA */
        private void R0350_90_LEITURA(bool isPerform = false)
        {
            /*" -588- PERFORM R0300-00-LER-MOVIMENTO. */

            R0300_00_LER_MOVIMENTO_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0350_99_SAIDA*/

        [StopWatch]
        /*" R0500-00-OUTPUT-SORT-SECTION */
        private void R0500_00_OUTPUT_SORT_SECTION()
        {
            /*" -598- MOVE '0500' TO WNR-EXEC-SQL. */
            _.Move("0500", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -599- MOVE SPACES TO WFIM-SORT. */
            _.Move("", W.WFIM_SORT);

            /*" -601- PERFORM R0510-00-LE-ARQSORT. */

            R0510_00_LE_ARQSORT_SECTION();

            /*" -604- PERFORM R0550-00-PROCESSA-SORT UNTIL WFIM-SORT NOT EQUAL SPACES. */

            while (!(!W.WFIM_SORT.IsEmpty()))
            {

                R0550_00_PROCESSA_SORT_SECTION();
            }

            /*" -605- DISPLAY ' ' */
            _.Display($" ");

            /*" -606- DISPLAY 'LIDOS SORT ............ ' LD-SORT */
            _.Display($"LIDOS SORT ............ {W.LD_SORT}");

            /*" -607- DISPLAY 'GRAVADOS ARQ01 911241 : ' */
            _.Display($"GRAVADOS ARQ01 911241 : ");

            /*" -608- DISPLAY '      CONVENIO 911241 . ' AC-GRAV-SAIDA01. */
            _.Display($"      CONVENIO 911241 . {W.AC_GRAV_SAIDA01}");

            /*" -609- DISPLAY 'GRAVADOS ARQ02 911334 : ' */
            _.Display($"GRAVADOS ARQ02 911334 : ");

            /*" -610- DISPLAY '      CONVENIO 911334 . ' AC-GRAV-SAIDA02. */
            _.Display($"      CONVENIO 911334 . {W.AC_GRAV_SAIDA02}");

            /*" -611- DISPLAY '      CONVENIO 912086 . ' AC-GRAV-CV912086. */
            _.Display($"      CONVENIO 912086 . {W.AC_GRAV_CV912086}");

            /*" -612- DISPLAY '      CONVENIO 912090 . ' AC-GRAV-CV912090. */
            _.Display($"      CONVENIO 912090 . {W.AC_GRAV_CV912090}");

            /*" -613- DISPLAY 'GRAVADOS ARQ03 021000 : ' */
            _.Display($"GRAVADOS ARQ03 021000 : ");

            /*" -614- DISPLAY '      CONVENIO 021000 . ' AC-GRAV-SAIDA03. */
            _.Display($"      CONVENIO 021000 . {W.AC_GRAV_SAIDA03}");

            /*" -615- DISPLAY 'GRAVADOS ARQ04 912014 : ' */
            _.Display($"GRAVADOS ARQ04 912014 : ");

            /*" -616- DISPLAY '      CONVENIO 912014 . ' AC-GRAV-SAIDA04. */
            _.Display($"      CONVENIO 912014 . {W.AC_GRAV_SAIDA04}");

            /*" -617- DISPLAY '      CONVENIO 912087 . ' AC-GRAV-CV912087. */
            _.Display($"      CONVENIO 912087 . {W.AC_GRAV_CV912087}");

            /*" -618- DISPLAY '      CONVENIO 912085 . ' AC-GRAV-CV912085. */
            _.Display($"      CONVENIO 912085 . {W.AC_GRAV_CV912085}");

            /*" -618- DISPLAY ' ' . */
            _.Display($" ");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0500_99_SAIDA*/

        [StopWatch]
        /*" R0510-00-LE-ARQSORT-SECTION */
        private void R0510_00_LE_ARQSORT_SECTION()
        {
            /*" -628- MOVE '0510' TO WNR-EXEC-SQL. */
            _.Move("0510", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -630- RETURN ARQSORT AT END */
            try
            {
                ARQSORT.Return(REG_ARQSORT, () =>
                {

                    /*" -631- MOVE ZEROS TO ATU-CONVENIO */
                    _.Move(0, W.ATU_CONVENIO);

                    /*" -632- MOVE 'S' TO WFIM-SORT */
                    _.Move("S", W.WFIM_SORT);

                    /*" -634- GO TO R0510-99-SAIDA. */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0510_99_SAIDA*/ //GOTO
                    return;

                });
            }
            catch (GoToException ex)
            {
                return;
            }
            /*" -636- ADD 1 TO LD-SORT. */
            W.LD_SORT.Value = W.LD_SORT + 1;

            /*" -636- MOVE SOR-CONVENIO TO ATU-CONVENIO. */
            _.Move(REG_ARQSORT.SOR_CONVENIO, W.ATU_CONVENIO);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0510_99_SAIDA*/

        [StopWatch]
        /*" R0550-00-PROCESSA-SORT-SECTION */
        private void R0550_00_PROCESSA_SORT_SECTION()
        {
            /*" -646- MOVE '0550' TO WNR-EXEC-SQL. */
            _.Move("0550", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -648- MOVE ATU-CONVENIO TO ANT-CONVENIO. */
            _.Move(W.ATU_CONVENIO, W.ANT_CONVENIO);

            /*" -650- PERFORM R1100-00-GRAVA-HEADER. */

            R1100_00_GRAVA_HEADER_SECTION();

            /*" -654- PERFORM R1000-00-PROCESSA-DETALHE UNTIL ATU-CONVENIO NOT EQUAL ANT-CONVENIO OR WFIM-SORT NOT EQUAL SPACES. */

            while (!(W.ATU_CONVENIO != W.ANT_CONVENIO || !W.WFIM_SORT.IsEmpty()))
            {

                R1000_00_PROCESSA_DETALHE_SECTION();
            }

            /*" -654- PERFORM R1200-00-GRAVA-TRAILLER. */

            R1200_00_GRAVA_TRAILLER_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0550_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-DETALHE-SECTION */
        private void R1000_00_PROCESSA_DETALHE_SECTION()
        {
            /*" -664- MOVE '1000' TO WNR-EXEC-SQL. */
            _.Move("1000", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -666- MOVE SPACES TO MOVCC-REGISTRO. */
            _.Move("", MOVCC_REGISTRO);

            /*" -668- MOVE 'G' TO MOVCC-CODREGISTRO. */
            _.Move("G", MOVCC_REGISTRO.MOVCC_CODREGISTRO);

            /*" -670- MOVE SOR-AGENCIA TO MOVCC-AGENCIA. */
            _.Move(REG_ARQSORT.SOR_AGENCIA, MOVCC_REGISTRO.MOVCC_CTACOBRANCA.MOVCC_AGENCIA);

            /*" -672- MOVE SOR-OPERACAO TO MOVCC-OPERACAO */
            _.Move(REG_ARQSORT.SOR_OPERACAO, MOVCC_REGISTRO.MOVCC_CTACOBRANCA.MOVCC_OPERACAO);

            /*" -674- MOVE SOR-NUM-CONTA TO MOVCC-NUMCTA. */
            _.Move(REG_ARQSORT.SOR_NUM_CONTA, MOVCC_REGISTRO.MOVCC_CTACOBRANCA.MOVCC_NUMCTA);

            /*" -676- MOVE SOR-DIG-CONTA TO MOVCC-DIGCTA. */
            _.Move(REG_ARQSORT.SOR_DIG_CONTA, MOVCC_REGISTRO.MOVCC_CTACOBRANCA.MOVCC_DIGCTA);

            /*" -678- MOVE SOR-ANO-PAGTO TO MOVCC-ANOPAG. */
            _.Move(REG_ARQSORT.SOR_DATA_PAGTO.SOR_ANO_PAGTO, MOVCC_REGISTRO.MOVCC_DTPAGTO.MOVCC_ANOPAG);

            /*" -680- MOVE SOR-MES-PAGTO TO MOVCC-MESPAG. */
            _.Move(REG_ARQSORT.SOR_DATA_PAGTO.SOR_MES_PAGTO, MOVCC_REGISTRO.MOVCC_DTPAGTO.MOVCC_MESPAG);

            /*" -682- MOVE SOR-DIA-PAGTO TO MOVCC-DIAPAG. */
            _.Move(REG_ARQSORT.SOR_DATA_PAGTO.SOR_DIA_PAGTO, MOVCC_REGISTRO.MOVCC_DTPAGTO.MOVCC_DIAPAG);

            /*" -684- MOVE SOR-ANO-CRED TO MOVCC-ANOCRE. */
            _.Move(REG_ARQSORT.SOR_DATA_CREDITO.SOR_ANO_CRED, MOVCC_REGISTRO.MOVCC_DTCREDITO.MOVCC_ANOCRE);

            /*" -686- MOVE SOR-MES-CRED TO MOVCC-MESCRE. */
            _.Move(REG_ARQSORT.SOR_DATA_CREDITO.SOR_MES_CRED, MOVCC_REGISTRO.MOVCC_DTCREDITO.MOVCC_MESCRE);

            /*" -688- MOVE SOR-DIA-CRED TO MOVCC-DIACRE. */
            _.Move(REG_ARQSORT.SOR_DATA_CREDITO.SOR_DIA_CRED, MOVCC_REGISTRO.MOVCC_DTCREDITO.MOVCC_DIACRE);

            /*" -690- MOVE SOR-BARRA01 TO MOVCC-BARRA01. */
            _.Move(REG_ARQSORT.SOR_BARRA01, MOVCC_REGISTRO.MOVCC_CODBARRA.MOVCC_BARRA01);

            /*" -692- MOVE SOR-CODBANCO TO MOVCC-BANCO. */
            _.Move(REG_ARQSORT.SOR_CODBANCO, MOVCC_REGISTRO.MOVCC_CODBARRA.MOVCC_BANCO);

            /*" -694- MOVE SOR-BARRA02 TO MOVCC-BARRA02. */
            _.Move(REG_ARQSORT.SOR_BARRA02, MOVCC_REGISTRO.MOVCC_CODBARRA.MOVCC_BARRA02);

            /*" -696- MOVE SOR-NUM-SIVPF TO MOVCC-NUMSIVPF. */
            _.Move(REG_ARQSORT.SOR_NUM_SIVPF, MOVCC_REGISTRO.MOVCC_CODBARRA.MOVCC_NUMSIVPF);

            /*" -698- MOVE SOR-BARRA03 TO MOVCC-BARRA03. */
            _.Move(REG_ARQSORT.SOR_BARRA03, MOVCC_REGISTRO.MOVCC_CODBARRA.MOVCC_BARRA03);

            /*" -700- MOVE SOR-VALOR-PAGO TO MOVCC-VLRPAGO. */
            _.Move(REG_ARQSORT.SOR_VALOR_PAGO, MOVCC_REGISTRO.MOVCC_VLRPAGO);

            /*" -702- MOVE SOR-VALOR-TARIFA TO MOVCC-VLRTARIFA. */
            _.Move(REG_ARQSORT.SOR_VALOR_TARIFA, MOVCC_REGISTRO.MOVCC_VLRTARIFA);

            /*" -704- ADD 1 TO WS-NRSEQ WS-TOTREG. */
            W.WS_NRSEQ.Value = W.WS_NRSEQ + 1;
            W.WS_TOTREG.Value = W.WS_TOTREG + 1;

            /*" -706- MOVE WS-NRSEQ TO MOVCC-NRSEQREG. */
            _.Move(W.WS_NRSEQ, MOVCC_REGISTRO.MOVCC_NRSEQREG);

            /*" -708- MOVE ZEROS TO MOVCC-PTOVENDA. */
            _.Move(0, MOVCC_REGISTRO.MOVCC_PTOVENDA);

            /*" -711- MOVE SPACES TO MOVCC-ANEXO1 MOVCC-ANEXO2. */
            _.Move("", MOVCC_REGISTRO.MOVCC_ANEXO1, MOVCC_REGISTRO.MOVCC_ANEXO2);

            /*" -714- MOVE 1 TO MOVCC-FORMAPAG. */
            _.Move(1, MOVCC_REGISTRO.MOVCC_FORMAPAG);

            /*" -717- COMPUTE WS-VALOR-0 EQUAL (WS-VALOR-0 + SOR-VALOR-PAGO). */
            W.WS_VALOR_0.Value = (W.WS_VALOR_0 + REG_ARQSORT.SOR_VALOR_PAGO);

            /*" -718- EVALUATE ANT-CONVENIO */
            switch (W.ANT_CONVENIO.Value)
            {

                /*" -719- WHEN 911241 */
                case 911241:

                    /*" -720- WRITE REG-SAIDA01 FROM MOVCC-REGISTRO */
                    _.Move(MOVCC_REGISTRO.GetMoveValues(), REG_SAIDA01);

                    SAIDA01.Write(REG_SAIDA01.GetMoveValues().ToString());

                    /*" -724- ADD 1 TO AC-GRAV-SAIDA01 */
                    W.AC_GRAV_SAIDA01.Value = W.AC_GRAV_SAIDA01 + 1;

                    /*" -725- WHEN 911334 */
                    break;
                case 911334:

                    /*" -726- WRITE REG-SAIDA02 FROM MOVCC-REGISTRO */
                    _.Move(MOVCC_REGISTRO.GetMoveValues(), REG_SAIDA02);

                    SAIDA02.Write(REG_SAIDA02.GetMoveValues().ToString());

                    /*" -727- ADD 1 TO AC-GRAV-SAIDA02 */
                    W.AC_GRAV_SAIDA02.Value = W.AC_GRAV_SAIDA02 + 1;

                    /*" -728- WHEN 912086 */
                    break;
                case 912086:

                    /*" -729- WRITE REG-SAIDA02 FROM MOVCC-REGISTRO */
                    _.Move(MOVCC_REGISTRO.GetMoveValues(), REG_SAIDA02);

                    SAIDA02.Write(REG_SAIDA02.GetMoveValues().ToString());

                    /*" -730- ADD 1 TO AC-GRAV-CV912086 */
                    W.AC_GRAV_CV912086.Value = W.AC_GRAV_CV912086 + 1;

                    /*" -731- WHEN 912090 */
                    break;
                case 912090:

                    /*" -732- WRITE REG-SAIDA02 FROM MOVCC-REGISTRO */
                    _.Move(MOVCC_REGISTRO.GetMoveValues(), REG_SAIDA02);

                    SAIDA02.Write(REG_SAIDA02.GetMoveValues().ToString());

                    /*" -733- ADD 1 TO AC-GRAV-CV912090 */
                    W.AC_GRAV_CV912090.Value = W.AC_GRAV_CV912090 + 1;

                    /*" -734- WHEN 021000 */
                    break;
                case 021000:

                    /*" -735- WRITE REG-SAIDA03 FROM MOVCC-REGISTRO */
                    _.Move(MOVCC_REGISTRO.GetMoveValues(), REG_SAIDA03);

                    SAIDA03.Write(REG_SAIDA03.GetMoveValues().ToString());

                    /*" -736- ADD 1 TO AC-GRAV-SAIDA03 */
                    W.AC_GRAV_SAIDA03.Value = W.AC_GRAV_SAIDA03 + 1;

                    /*" -737- WHEN 912014 */
                    break;
                case 912014:

                    /*" -738- WRITE REG-SAIDA04 FROM MOVCC-REGISTRO */
                    _.Move(MOVCC_REGISTRO.GetMoveValues(), REG_SAIDA04);

                    SAIDA04.Write(REG_SAIDA04.GetMoveValues().ToString());

                    /*" -739- ADD 1 TO AC-GRAV-SAIDA04 */
                    W.AC_GRAV_SAIDA04.Value = W.AC_GRAV_SAIDA04 + 1;

                    /*" -740- WHEN 912087 */
                    break;
                case 912087:

                    /*" -741- WRITE REG-SAIDA04 FROM MOVCC-REGISTRO */
                    _.Move(MOVCC_REGISTRO.GetMoveValues(), REG_SAIDA04);

                    SAIDA04.Write(REG_SAIDA04.GetMoveValues().ToString());

                    /*" -742- ADD 1 TO AC-GRAV-CV912087 */
                    W.AC_GRAV_CV912087.Value = W.AC_GRAV_CV912087 + 1;

                    /*" -743- WHEN 912085 */
                    break;
                case 912085:

                    /*" -744- WRITE REG-SAIDA04 FROM MOVCC-REGISTRO */
                    _.Move(MOVCC_REGISTRO.GetMoveValues(), REG_SAIDA04);

                    SAIDA04.Write(REG_SAIDA04.GetMoveValues().ToString());

                    /*" -745- ADD 1 TO AC-GRAV-CV912085 */
                    W.AC_GRAV_CV912085.Value = W.AC_GRAV_CV912085 + 1;

                    /*" -745- END-EVALUATE. */
                    break;
            }


            /*" -0- FLUXCONTROL_PERFORM R1000_90_LEITURA */

            R1000_90_LEITURA();

        }

        [StopWatch]
        /*" R1000-90-LEITURA */
        private void R1000_90_LEITURA(bool isPerform = false)
        {
            /*" -749- PERFORM R0510-00-LE-ARQSORT. */

            R0510_00_LE_ARQSORT_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1100-00-GRAVA-HEADER-SECTION */
        private void R1100_00_GRAVA_HEADER_SECTION()
        {
            /*" -759- MOVE '1100' TO WNR-EXEC-SQL. */
            _.Move("1100", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -761- MOVE SPACES TO HEADER-REGISTRO. */
            _.Move("", HEADER_REGISTRO);

            /*" -763- MOVE ZEROS TO WS-NRSEQ WS-VALOR-0. */
            _.Move(0, W.WS_NRSEQ, W.WS_VALOR_0);

            /*" -765- MOVE 1 TO WS-TOTREG. */
            _.Move(1, W.WS_TOTREG);

            /*" -767- MOVE 'A' TO HEADER-CODREGISTRO. */
            _.Move("A", HEADER_REGISTRO.HEADER_CODREGISTRO);

            /*" -769- MOVE '2' TO HEADER-CODREMESSA. */
            _.Move("2", HEADER_REGISTRO.HEADER_CODREMESSA);

            /*" -771- MOVE SOR-CONVENIO TO HEADER-CODCONVENIO. */
            _.Move(REG_ARQSORT.SOR_CONVENIO, HEADER_REGISTRO.HEADER_CODCONVENIO);

            /*" -773- MOVE 'CAIXA SEGURADORA SA' TO HEADER-NOMEMPRESA. */
            _.Move("CAIXA SEGURADORA SA", HEADER_REGISTRO.HEADER_NOMEMPRESA);

            /*" -775- MOVE SOR-CODBANCO TO HEADER-CODBANCO. */
            _.Move(REG_ARQSORT.SOR_CODBANCO, HEADER_REGISTRO.HEADER_CODBANCO);

            /*" -777- MOVE 'CAIXA ECON. FEDERAL' TO HEADER-NOMBANCO. */
            _.Move("CAIXA ECON. FEDERAL", HEADER_REGISTRO.HEADER_NOMBANCO);

            /*" -779- MOVE SOR-ANO-HEADER TO HEADER-ANO. */
            _.Move(REG_ARQSORT.SOR_DTGERACAO.SOR_ANO_HEADER, HEADER_REGISTRO.HEADER_DATGERACAO.HEADER_ANO);

            /*" -781- MOVE SOR-MES-HEADER TO HEADER-MES. */
            _.Move(REG_ARQSORT.SOR_DTGERACAO.SOR_MES_HEADER, HEADER_REGISTRO.HEADER_DATGERACAO.HEADER_MES);

            /*" -783- MOVE SOR-DIA-HEADER TO HEADER-DIA. */
            _.Move(REG_ARQSORT.SOR_DTGERACAO.SOR_DIA_HEADER, HEADER_REGISTRO.HEADER_DATGERACAO.HEADER_DIA);

            /*" -786- MOVE SOR-NSAC TO HEADER-NSA WS9-NRO-NSAC. */
            _.Move(REG_ARQSORT.SOR_NSAC, HEADER_REGISTRO.HEADER_NSA, W.WS9_NRO_NSAC);

            /*" -790- MOVE '03' TO HEADER-VERSAO. */
            _.Move("03", HEADER_REGISTRO.HEADER_VERSAO);

            /*" -791- EVALUATE ANT-CONVENIO */
            switch (W.ANT_CONVENIO.Value)
            {

                /*" -792- WHEN 911241 */
                case 911241:

                    /*" -793- MOVE 924100000 TO WSHOST-NRAVISO1 */
                    _.Move(924100000, WSHOST_NRAVISO1);

                    /*" -794- MOVE 924189999 TO WSHOST-NRAVISO2 */
                    _.Move(924189999, WSHOST_NRAVISO2);

                    /*" -795- PERFORM R1110-00-TRATA-NSAC */

                    R1110_00_TRATA_NSAC_SECTION();

                    /*" -796- WRITE REG-SAIDA01 FROM HEADER-REGISTRO */
                    _.Move(HEADER_REGISTRO.GetMoveValues(), REG_SAIDA01);

                    SAIDA01.Write(REG_SAIDA01.GetMoveValues().ToString());

                    /*" -797- WHEN 911334 */
                    break;
                case 911334:

                    /*" -798- MOVE 933400000 TO WSHOST-NRAVISO1 */
                    _.Move(933400000, WSHOST_NRAVISO1);

                    /*" -799- MOVE 933489999 TO WSHOST-NRAVISO2 */
                    _.Move(933489999, WSHOST_NRAVISO2);

                    /*" -800- PERFORM R1110-00-TRATA-NSAC */

                    R1110_00_TRATA_NSAC_SECTION();

                    /*" -801- WRITE REG-SAIDA02 FROM HEADER-REGISTRO */
                    _.Move(HEADER_REGISTRO.GetMoveValues(), REG_SAIDA02);

                    SAIDA02.Write(REG_SAIDA02.GetMoveValues().ToString());

                    /*" -802- WHEN 912086 */
                    break;
                case 912086:

                    /*" -803- MOVE 908600000 TO WSHOST-NRAVISO1 */
                    _.Move(908600000, WSHOST_NRAVISO1);

                    /*" -804- MOVE 908689999 TO WSHOST-NRAVISO2 */
                    _.Move(908689999, WSHOST_NRAVISO2);

                    /*" -805- PERFORM R1110-00-TRATA-NSAC */

                    R1110_00_TRATA_NSAC_SECTION();

                    /*" -806- WRITE REG-SAIDA02 FROM HEADER-REGISTRO */
                    _.Move(HEADER_REGISTRO.GetMoveValues(), REG_SAIDA02);

                    SAIDA02.Write(REG_SAIDA02.GetMoveValues().ToString());

                    /*" -807- WHEN 912090 */
                    break;
                case 912090:

                    /*" -808- MOVE 909000000 TO WSHOST-NRAVISO1 */
                    _.Move(909000000, WSHOST_NRAVISO1);

                    /*" -809- MOVE 909089999 TO WSHOST-NRAVISO2 */
                    _.Move(909089999, WSHOST_NRAVISO2);

                    /*" -810- PERFORM R1110-00-TRATA-NSAC */

                    R1110_00_TRATA_NSAC_SECTION();

                    /*" -811- WRITE REG-SAIDA02 FROM HEADER-REGISTRO */
                    _.Move(HEADER_REGISTRO.GetMoveValues(), REG_SAIDA02);

                    SAIDA02.Write(REG_SAIDA02.GetMoveValues().ToString());

                    /*" -812- WHEN 021000 */
                    break;
                case 021000:

                    /*" -814- MOVE 'SUPERPAY' TO HEADER-NOMBANCO */
                    _.Move("SUPERPAY", HEADER_REGISTRO.HEADER_NOMBANCO);

                    /*" -815- MOVE 902100000 TO WSHOST-NRAVISO1 */
                    _.Move(902100000, WSHOST_NRAVISO1);

                    /*" -818- MOVE 902189999 TO WSHOST-NRAVISO2 */
                    _.Move(902189999, WSHOST_NRAVISO2);

                    /*" -819- PERFORM R1110-00-TRATA-NSAC */

                    R1110_00_TRATA_NSAC_SECTION();

                    /*" -820- WRITE REG-SAIDA03 FROM HEADER-REGISTRO */
                    _.Move(HEADER_REGISTRO.GetMoveValues(), REG_SAIDA03);

                    SAIDA03.Write(REG_SAIDA03.GetMoveValues().ToString());

                    /*" -821- WHEN 912014 */
                    break;
                case 912014:

                    /*" -822- MOVE 901400000 TO WSHOST-NRAVISO1 */
                    _.Move(901400000, WSHOST_NRAVISO1);

                    /*" -823- MOVE 901489999 TO WSHOST-NRAVISO2 */
                    _.Move(901489999, WSHOST_NRAVISO2);

                    /*" -824- PERFORM R1110-00-TRATA-NSAC */

                    R1110_00_TRATA_NSAC_SECTION();

                    /*" -825- WRITE REG-SAIDA04 FROM HEADER-REGISTRO */
                    _.Move(HEADER_REGISTRO.GetMoveValues(), REG_SAIDA04);

                    SAIDA04.Write(REG_SAIDA04.GetMoveValues().ToString());

                    /*" -826- WHEN 912087 */
                    break;
                case 912087:

                    /*" -827- MOVE 908700000 TO WSHOST-NRAVISO1 */
                    _.Move(908700000, WSHOST_NRAVISO1);

                    /*" -828- MOVE 908789999 TO WSHOST-NRAVISO2 */
                    _.Move(908789999, WSHOST_NRAVISO2);

                    /*" -829- PERFORM R1110-00-TRATA-NSAC */

                    R1110_00_TRATA_NSAC_SECTION();

                    /*" -830- WRITE REG-SAIDA04 FROM HEADER-REGISTRO */
                    _.Move(HEADER_REGISTRO.GetMoveValues(), REG_SAIDA04);

                    SAIDA04.Write(REG_SAIDA04.GetMoveValues().ToString());

                    /*" -831- WHEN 912085 */
                    break;
                case 912085:

                    /*" -832- MOVE 908500000 TO WSHOST-NRAVISO1 */
                    _.Move(908500000, WSHOST_NRAVISO1);

                    /*" -833- MOVE 908589999 TO WSHOST-NRAVISO2 */
                    _.Move(908589999, WSHOST_NRAVISO2);

                    /*" -835- PERFORM R1110-00-TRATA-NSAC */

                    R1110_00_TRATA_NSAC_SECTION();

                    /*" -836- WRITE REG-SAIDA04 FROM HEADER-REGISTRO */
                    _.Move(HEADER_REGISTRO.GetMoveValues(), REG_SAIDA04);

                    SAIDA04.Write(REG_SAIDA04.GetMoveValues().ToString());

                    /*" -836- END-EVALUATE. */
                    break;
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/

        [StopWatch]
        /*" R1110-00-TRATA-NSAC-SECTION */
        private void R1110_00_TRATA_NSAC_SECTION()
        {
            /*" -846- MOVE '1110' TO WNR-EXEC-SQL. */
            _.Move("1110", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -848- PERFORM R1150-00-SELECT-AVISOCRE. */

            R1150_00_SELECT_AVISOCRE_SECTION();

            /*" -851- MOVE AVISOCRE-NUM-AVISO-CREDITO TO WS0-NRAVISO. */
            _.Move(AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_NUM_AVISO_CREDITO, W.WS0_NRAVISO);

            /*" -852- IF WS0-NRO-NSAC GREATER WS9-NRO-NSAC */

            if (W.FILLER_5.WS0_NRO_NSAC > W.WS9_NRO_NSAC)
            {

                /*" -853- MOVE WS0-NRO-NSAC TO HEADER-NSA */
                _.Move(W.FILLER_5.WS0_NRO_NSAC, HEADER_REGISTRO.HEADER_NSA);

                /*" -854- ELSE */
            }
            else
            {


                /*" -854- MOVE WS9-NRO-NSAC TO HEADER-NSA. */
                _.Move(W.WS9_NRO_NSAC, HEADER_REGISTRO.HEADER_NSA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1110_99_SAIDA*/

        [StopWatch]
        /*" R1150-00-SELECT-AVISOCRE-SECTION */
        private void R1150_00_SELECT_AVISOCRE_SECTION()
        {
            /*" -864- MOVE '1150' TO WNR-EXEC-SQL. */
            _.Move("1150", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -872- PERFORM R1150_00_SELECT_AVISOCRE_DB_SELECT_1 */

            R1150_00_SELECT_AVISOCRE_DB_SELECT_1();

            /*" -875- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -876- DISPLAY 'R1150-00 - PROBLEMAS NO SELECT(AVISOCRE)' */
                _.Display($"R1150-00 - PROBLEMAS NO SELECT(AVISOCRE)");

                /*" -878- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -879- ADD 1 TO AVISOCRE-NUM-AVISO-CREDITO. */
            AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_NUM_AVISO_CREDITO.Value = AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_NUM_AVISO_CREDITO + 1;

        }

        [StopWatch]
        /*" R1150-00-SELECT-AVISOCRE-DB-SELECT-1 */
        public void R1150_00_SELECT_AVISOCRE_DB_SELECT_1()
        {
            /*" -872- EXEC SQL SELECT VALUE(MAX(NUM_AVISO_CREDITO),0) INTO :AVISOCRE-NUM-AVISO-CREDITO FROM SEGUROS.AVISO_CREDITO WHERE NUM_AVISO_CREDITO BETWEEN :WSHOST-NRAVISO1 AND :WSHOST-NRAVISO2 WITH UR END-EXEC. */

            var r1150_00_SELECT_AVISOCRE_DB_SELECT_1_Query1 = new R1150_00_SELECT_AVISOCRE_DB_SELECT_1_Query1()
            {
                WSHOST_NRAVISO1 = WSHOST_NRAVISO1.ToString(),
                WSHOST_NRAVISO2 = WSHOST_NRAVISO2.ToString(),
            };

            var executed_1 = R1150_00_SELECT_AVISOCRE_DB_SELECT_1_Query1.Execute(r1150_00_SELECT_AVISOCRE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.AVISOCRE_NUM_AVISO_CREDITO, AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_NUM_AVISO_CREDITO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1150_99_SAIDA*/

        [StopWatch]
        /*" R1200-00-GRAVA-TRAILLER-SECTION */
        private void R1200_00_GRAVA_TRAILLER_SECTION()
        {
            /*" -889- MOVE '1200' TO WNR-EXEC-SQL. */
            _.Move("1200", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -891- MOVE SPACES TO TRAILL-REGISTRO. */
            _.Move("", TRAILL_REGISTRO);

            /*" -894- MOVE 'Z' TO TRAILL-CODREGISTRO. */
            _.Move("Z", TRAILL_REGISTRO.TRAILL_CODREGISTRO);

            /*" -895- ADD 1 TO WS-TOTREG. */
            W.WS_TOTREG.Value = W.WS_TOTREG + 1;

            /*" -898- MOVE WS-TOTREG TO TRAILL-TOTREGISTRO. */
            _.Move(W.WS_TOTREG, TRAILL_REGISTRO.TRAILL_TOTREGISTRO);

            /*" -901- MOVE WS-VALOR-0 TO TRAILL-VLRTOTPAG. */
            _.Move(W.WS_VALOR_0, TRAILL_REGISTRO.TRAILL_VLRTOTPAG);

            /*" -902- EVALUATE ANT-CONVENIO */
            switch (W.ANT_CONVENIO.Value)
            {

                /*" -903- WHEN     911241 */
                case 911241:

                    /*" -904- WRITE REG-SAIDA01 FROM TRAILL-REGISTRO */
                    _.Move(TRAILL_REGISTRO.GetMoveValues(), REG_SAIDA01);

                    SAIDA01.Write(REG_SAIDA01.GetMoveValues().ToString());

                    /*" -905- WHEN     911334 */
                    break;
                case 911334:

                /*" -906- WHEN     912086 */
                case 912086:

                    /*" -907- WHEN     912090 */
                    break;
                case 912090:

                    /*" -908- WRITE REG-SAIDA02 FROM TRAILL-REGISTRO */
                    _.Move(TRAILL_REGISTRO.GetMoveValues(), REG_SAIDA02);

                    SAIDA02.Write(REG_SAIDA02.GetMoveValues().ToString());

                    /*" -909- WHEN     021000 */
                    break;
                case 021000:

                    /*" -910- WRITE REG-SAIDA03 FROM TRAILL-REGISTRO */
                    _.Move(TRAILL_REGISTRO.GetMoveValues(), REG_SAIDA03);

                    SAIDA03.Write(REG_SAIDA03.GetMoveValues().ToString());

                    /*" -911- WHEN     912014 */
                    break;
                case 912014:

                /*" -912- WHEN     912087 */
                case 912087:

                    /*" -913- WHEN     912085 */
                    break;
                case 912085:

                    /*" -914- WRITE REG-SAIDA04 FROM TRAILL-REGISTRO */
                    _.Move(TRAILL_REGISTRO.GetMoveValues(), REG_SAIDA04);

                    SAIDA04.Write(REG_SAIDA04.GetMoveValues().ToString());

                    /*" -915- END-EVALUATE */
                    break;
            }


            /*" -915- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/

        [StopWatch]
        /*" R9990-00-SEM-MOVIMENTO-SECTION */
        private void R9990_00_SEM_MOVIMENTO_SECTION()
        {
            /*" -925- MOVE SISTEMAS-DATA-MOV-ABERTO TO WDATA-REL */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, W.WDATA_REL);

            /*" -926- MOVE WDAT-REL-DIA TO WDATA-DD-CABEC */
            _.Move(W.FILLER_2.WDAT_REL_DIA, W.WDATA_CABEC.WDATA_DD_CABEC);

            /*" -927- MOVE WDAT-REL-MES TO WDATA-MM-CABEC */
            _.Move(W.FILLER_2.WDAT_REL_MES, W.WDATA_CABEC.WDATA_MM_CABEC);

            /*" -929- MOVE WDAT-REL-ANO TO WDATA-AA-CABEC. */
            _.Move(W.FILLER_2.WDAT_REL_ANO, W.WDATA_CABEC.WDATA_AA_CABEC);

            /*" -931- DISPLAY 'SEM MOVIMENTO NESTA DATA  ' WDATA-CABEC. */
            _.Display($"SEM MOVIMENTO NESTA DATA  {W.WDATA_CABEC}");

            /*" -936- CLOSE ENTRADA SAIDA01 SAIDA02 SAIDA03. */
            ENTRADA.Close();
            SAIDA01.Close();
            SAIDA02.Close();
            SAIDA03.Close();

            /*" -938- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -938- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -944- MOVE SQLCODE TO WSQLCODE */
            _.Move(DB.SQLCODE, ABEN.WABEND1.WSQLCODE);

            /*" -945- MOVE SQLERRD(1) TO WSQLERRD1 */
            _.Move(DB.SQLERRD[1], ABEN.WABEND1.WSQLERRD1);

            /*" -946- MOVE SQLERRD(2) TO WSQLERRD2 */
            _.Move(DB.SQLERRD[2], ABEN.WABEND1.WSQLERRD2);

            /*" -947- DISPLAY WABEND. */
            _.Display(ABEN.WABEND);

            /*" -949- DISPLAY WABEND1. */
            _.Display(ABEN.WABEND1);

            /*" -949- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -955- CLOSE ENTRADA SAIDA01 SAIDA02. */
            ENTRADA.Close();
            SAIDA01.Close();
            SAIDA02.Close();

            /*" -957- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -957- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}