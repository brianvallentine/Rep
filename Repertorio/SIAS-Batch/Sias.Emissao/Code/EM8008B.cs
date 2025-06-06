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
using Sias.Emissao.DB2.EM8008B;

namespace Code
{
    public class EM8008B
    {
        public bool IsCall { get; set; }

        public EM8008B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *----------------------------------------------------------------*      */
        /*"      *--------------------------------------------------------------- *      */
        /*"      *   SISTEMA ................  COBRANCA                           *      */
        /*"      *   PROGRAMA ...............  EM8008B                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA DE REQUISITOS..  CLOVIS/DANIELA MARTINO             *      */
        /*"      *   PROGRAMADOR ............  WANGER C SILVA                     *      */
        /*"      *   CADMUS .... ............  XX.XXX    (PROJETO VISAO)          *      */
        /*"      *   DATA CODIFICACAO .......  11/10/2010                         *      */
        /*"      *   DATA REVISAO ...........  07/12/2010 - CLOVIS                *      */
        /*"      *   DATA REVISAO ...........  21/12/2010 - CLOVIS                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO .................  GERACAO DE ARQUIVOS DO LATOUT      *      */
        /*"      *                             ARQUIVO H PARA O CNAB ( SICOV )    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                    A L T E R A C O E S                         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 16  - INCIDENTE 541.687                               *      */
        /*"      *              - DESPREZAR OS NSAC 9999 E 99999 QUE SAO UTILIZA- *      */
        /*"      *                DOS PELO SAP PARA TRATATIVAS MANUAIS.           *      */
        /*"      *                                                                *      */
        /*"      *   EM 18/10/2023 - FRANK CARVALHO                               *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.16         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 15  - TRATAMENTO PARA EVITAR ERRO DE PROCESSAMENTO    *      */
        /*"      *                COM NUMERO DE FITA JA UTILIZADA.                *      */
        /*"      *                ( ERRO ACONTECIA NA JPVAD00 - E0030806 )        *      */
        /*"      *                                                                *      */
        /*"      *   EM 16/02/2023 - ROGER PIRES DOS SANTOS                       *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.15         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 14  - AJUSTE NO RANGE NR.DO AVISO DE DEBITO.          *      */
        /*"      *              - INCIDENTE 417312, 417787, 418175 (JAZZ).        *      */
        /*"      *                                                                *      */
        /*"      *   FEITO O AJUSTE DO RANGE NR2 912109997 PARA 912108999 E       *      */
        /*"      *   FEITO O AJUSTE DO RANGE NR4 912189999 PARA 912188999 PARA O  *      */
        /*"      *   CONVENIO 600121 NA V.14, PARA GERAR ARQUIVO COM NSAS MENOR   *      */
        /*"      *   QUE O LIMITE JA GRAVADO ANTERIORMENTE.                       *      */
        /*"      *                                                                *      */
        /*"      *   EM 22/08/2022 - FLAVIO DE LIMA SILVA                         *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.14         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 13  - AJUSTE NO RANGE NR.DO AVISO DE DEBITO.          *      */
        /*"      *              - INCIDENTE 374136 (JAZZ).                        *      */
        /*"      *                                                                *      */
        /*"      *   FEITO O AJUSTE DO RANGE 912109997 PARA 912109996 PARA O CON- *      */
        /*"      *   VENIO 600121 NA V.12, PARA GERAR ARQUIVO COM NSAS MENOR QUE O*      */
        /*"      *   LIMITE JA GRAVADO ANTERIORMENTE.                             *      */
        /*"      *                                                                *      */
        /*"      *   EM 21/03/2022 - FLAVIO DE LIMA SILVA                         *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.12.2       *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 12.1 - AJUSTE DO RANGE DO NR.DO AVISO DE DEBITO TAMBEM*      */
        /*"      *   VERSAO 12 - INCIDENTES 368135,368504,368977 ABEND NO CB0092B *      */
        /*"      *             - AJUSTAR O NR.DO AVISO DE CREDITO PARA O CONVENIO *      */
        /*"      *               600121 POR OCORRENCIA DE DUPLICIDADE             *      */
        /*"      *                                                                *      */
        /*"      *   EM 03/03/2022 - FLAVIO DE LIMA SILVA                         *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.12         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 11 - DEMANDA 349969/349831 ABEND NO CB0092B           *      */
        /*"      *             - AJUSTAR O NR.DO AVISO DE CREDITO PARA O CONVENIO *      */
        /*"      *               600139 POR OCORRENCIA DE DUPLICIDADE             *      */
        /*"      *                                                                *      */
        /*"      *   EM 28/12/2021 - MILLENIUM                                    *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.11         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 10 - DEMANDA 278.146                                  *      */
        /*"      *             - INCLUIR O CAMPO MOTIVO DE COMPENSACAO PARA SER   *      */
        /*"      *               UTILIZADO NAS NOVAS REGRAS DA REGUA DE COBRANCA. *      */
        /*"      *                                                                *      */
        /*"      *   EM 23/03/2021 - FRANK CARVALHO                               *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.10         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 09 - DEMANDA 256.184                                  *      */
        /*"      *             - ENVIO DOS CAMPOS DE ADVERTENCIA CRIADOS PELO SAP *      */
        /*"      *               PARA INDICAR A REGUA DE COBRANCA DEBITO EM CONTA *      */
        /*"      *                                                                *      */
        /*"      *   EM 05/12/2020 - FRANK CARVALHO                               *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.09         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 08 -   NSGD - CADMUS 103659.                          *      */
        /*"      *               - NOVA SOLUCAO DE GESTAO DE DEPOSITOS            *      */
        /*"      *                                                                *      */
        /*"      *   EM 08/07/2015 - COREON                                       *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.08         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.07  *  VERSAO...: V.07                                               *      */
        /*"      *  CADMUS...:                 PROGRAMADOR: GUILHERME CORREIA     *      */
        /*"      *  DATA ....: 15/12/2014                                         *      */
        /*"      *                                                                *      */
        /*"      *  DESCRICAO: INCLUIR RANGE 9149 PARA DEMAIS PARCELAS CCA, COM   *      */
        /*"      *             A FAIXA DE 91498... PARA CASOS QUE EXISTA APENAS   *      */
        /*"      *             MOVIMENTO DE CREDITO.                              *      */
        /*"      *                                            ABEND 107141        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO  : 006                                                  *      */
        /*"      * MOTIVO  : CRIACAO DO ARQUIVO 609500 PARA O PRODUTO 7705 DO EF  *      */
        /*"      * CADMUS  : 88832                                                *      */
        /*"      * DATA    : 23/05/2014                                           *      */
        /*"      * NOME    : DIOGO MATHEUS                                        *      */
        /*"      * MARCADOR: V.6                                                  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.05  *  VERSAO...: V.05                                               *      */
        /*"      *  CADMUS...:                 PROGRAMADOR: GUILHERME CORREIA     *      */
        /*"      *  DATA ....: 20/03/2014                                         *      */
        /*"      *                                                                *      */
        /*"      *  DESCRICAO: INCLUIR RANGE 9149 PARA DEMAIS PARCELAS CCA        *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.04  *  VERSAO...: V.04                                               *      */
        /*"      *  CADMUS...:                 PROGRAMADOR: GUILHERME CORREIA     *      */
        /*"      *  DATA ....: 12/02/2014                                         *      */
        /*"      *                                                                *      */
        /*"      *  DESCRICAO: CORRECAO DO RANGE DE AVISO DO CONVENIO 600149      *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.03  *  VERSAO...: V.03                                               *      */
        /*"      *  CADMUS...:                 PROGRAMADOR: OLIVEIRA              *      */
        /*"      *  DATA ....: 07/11/2013                                         *      */
        /*"      *                                                                *      */
        /*"      *  DESCRICAO: INCLUIR O CONVENIO 600149 - LOTERICO CCA           *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.02  *  VERSAO...: V.02                                               *      */
        /*"      *  CADMUS...:                 PROGRAMADOR: CLOVIS                *      */
        /*"      *  DATA ....: 29/07/2013                                         *      */
        /*"      *                                                                *      */
        /*"      *  DESCRICAO: ERRO EXEC SQL NUMERO 240 SQLCODE 803-              *      */
        /*"      *             CB6114B - PROBLEMAS INSERT V0AVISOSALDO            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *TRATAR ABEND DE DUPLICIDADE OCORRIDO NOS PROGRAMAS CB0092B E    *      */
        /*"      *CB6114B - VIVIANE FONSECA - 24/07/2013                      V.01*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
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
        public FileBasis _SAIDA05 { get; set; } = new FileBasis(new PIC("X", "150", "X(150)"));

        public FileBasis SAIDA05
        {
            get
            {
                _.Move(REG_SAIDA05, _SAIDA05); VarBasis.RedefinePassValue(REG_SAIDA05, _SAIDA05, REG_SAIDA05); return _SAIDA05;
            }
        }
        public FileBasis _SAIDA06 { get; set; } = new FileBasis(new PIC("X", "150", "X(150)"));

        public FileBasis SAIDA06
        {
            get
            {
                _.Move(REG_SAIDA06, _SAIDA06); VarBasis.RedefinePassValue(REG_SAIDA06, _SAIDA06, REG_SAIDA06); return _SAIDA06;
            }
        }
        public FileBasis _SAIDA07 { get; set; } = new FileBasis(new PIC("X", "150", "X(150)"));

        public FileBasis SAIDA07
        {
            get
            {
                _.Move(REG_SAIDA07, _SAIDA07); VarBasis.RedefinePassValue(REG_SAIDA07, _SAIDA07, REG_SAIDA07); return _SAIDA07;
            }
        }
        public FileBasis _SAIDA08 { get; set; } = new FileBasis(new PIC("X", "150", "X(150)"));

        public FileBasis SAIDA08
        {
            get
            {
                _.Move(REG_SAIDA08, _SAIDA08); VarBasis.RedefinePassValue(REG_SAIDA08, _SAIDA08, REG_SAIDA08); return _SAIDA08;
            }
        }
        public FileBasis _SAIDA09 { get; set; } = new FileBasis(new PIC("X", "150", "X(150)"));

        public FileBasis SAIDA09
        {
            get
            {
                _.Move(REG_SAIDA09, _SAIDA09); VarBasis.RedefinePassValue(REG_SAIDA09, _SAIDA09, REG_SAIDA09); return _SAIDA09;
            }
        }
        public FileBasis _SAIDA10 { get; set; } = new FileBasis(new PIC("X", "150", "X(150)"));

        public FileBasis SAIDA10
        {
            get
            {
                _.Move(REG_SAIDA10, _SAIDA10); VarBasis.RedefinePassValue(REG_SAIDA10, _SAIDA10, REG_SAIDA10); return _SAIDA10;
            }
        }
        public FileBasis _SAIDA11 { get; set; } = new FileBasis(new PIC("X", "150", "X(150)"));

        public FileBasis SAIDA11
        {
            get
            {
                _.Move(REG_SAIDA11, _SAIDA11); VarBasis.RedefinePassValue(REG_SAIDA11, _SAIDA11, REG_SAIDA11); return _SAIDA11;
            }
        }
        public FileBasis _SAIDA12 { get; set; } = new FileBasis(new PIC("X", "150", "X(150)"));

        public FileBasis SAIDA12
        {
            get
            {
                _.Move(REG_SAIDA12, _SAIDA12); VarBasis.RedefinePassValue(REG_SAIDA12, _SAIDA12, REG_SAIDA12); return _SAIDA12;
            }
        }
        public FileBasis _SAIDA13 { get; set; } = new FileBasis(new PIC("X", "150", "X(150)"));

        public FileBasis SAIDA13
        {
            get
            {
                _.Move(REG_SAIDA13, _SAIDA13); VarBasis.RedefinePassValue(REG_SAIDA13, _SAIDA13, REG_SAIDA13); return _SAIDA13;
            }
        }
        public FileBasis _SAIDA14 { get; set; } = new FileBasis(new PIC("X", "150", "X(150)"));

        public FileBasis SAIDA14
        {
            get
            {
                _.Move(REG_SAIDA14, _SAIDA14); VarBasis.RedefinePassValue(REG_SAIDA14, _SAIDA14, REG_SAIDA14); return _SAIDA14;
            }
        }
        public FileBasis _SAIDA15 { get; set; } = new FileBasis(new PIC("X", "150", "X(150)"));

        public FileBasis SAIDA15
        {
            get
            {
                _.Move(REG_SAIDA15, _SAIDA15); VarBasis.RedefinePassValue(REG_SAIDA15, _SAIDA15, REG_SAIDA15); return _SAIDA15;
            }
        }
        public SortBasis<EM8008B_REG_ARQSORT> ARQSORT { get; set; } = new SortBasis<EM8008B_REG_ARQSORT>(new EM8008B_REG_ARQSORT());
        /*"01        REG-ARQSORT.*/
        public EM8008B_REG_ARQSORT REG_ARQSORT { get; set; } = new EM8008B_REG_ARQSORT();
        public class EM8008B_REG_ARQSORT : VarBasis
        {
            /*"  05      SOR-TIPO-ARQUIVO         PIC  X(010).*/
            public StringBasis SOR_TIPO_ARQUIVO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  05      SOR-CODBANCO             PIC  9(003).*/
            public IntBasis SOR_CODBANCO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
            /*"  05      SOR-CONVENIO             PIC  9(006).*/
            public IntBasis SOR_CONVENIO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"  05      SOR-NSAS                 PIC  9(005).*/
            public IntBasis SOR_NSAS { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
            /*"  05      SOR-CONVENIO-SAP         PIC  9(006).*/
            public IntBasis SOR_CONVENIO_SAP { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"  05      SOR-NSAC                 PIC  9(005).*/
            public IntBasis SOR_NSAC { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
            /*"  05      SOR-DTGERACAO.*/
            public EM8008B_SOR_DTGERACAO SOR_DTGERACAO { get; set; } = new EM8008B_SOR_DTGERACAO();
            public class EM8008B_SOR_DTGERACAO : VarBasis
            {
                /*"    10    SOR-ANO-HEADER           PIC  9(004).*/
                public IntBasis SOR_ANO_HEADER { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10    SOR-MES-HEADER           PIC  9(002).*/
                public IntBasis SOR_MES_HEADER { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10    SOR-DIA-HEADER           PIC  9(002).*/
                public IntBasis SOR_DIA_HEADER { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05      SOR-IDTCLIEMP            PIC  X(025).*/
            }
            public StringBasis SOR_IDTCLIEMP { get; set; } = new StringBasis(new PIC("X", "25", "X(025)."), @"");
            /*"  05      SOR-IDTCLIBAN.*/
            public EM8008B_SOR_IDTCLIBAN SOR_IDTCLIBAN { get; set; } = new EM8008B_SOR_IDTCLIBAN();
            public class EM8008B_SOR_IDTCLIBAN : VarBasis
            {
                /*"    10    SOR-AGECONTA             PIC  9(004).*/
                public IntBasis SOR_AGECONTA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10    SOR-OPECONTA             PIC  9(004).*/
                public IntBasis SOR_OPECONTA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10    SOR-NUMCONTA             PIC  9(012).*/
                public IntBasis SOR_NUMCONTA { get; set; } = new IntBasis(new PIC("9", "12", "9(012)."));
                /*"    10    SOR-DIGCONTA             PIC  9(001).*/
                public IntBasis SOR_DIGCONTA { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    10    FILLER                   PIC  X(002).*/
                public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"  05      SOR-DTCREDITO.*/
            }
            public EM8008B_SOR_DTCREDITO SOR_DTCREDITO { get; set; } = new EM8008B_SOR_DTCREDITO();
            public class EM8008B_SOR_DTCREDITO : VarBasis
            {
                /*"    10    SOR-ANO                  PIC  9(004).*/
                public IntBasis SOR_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10    SOR-MES                  PIC  9(002).*/
                public IntBasis SOR_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10    SOR-DIA                  PIC  9(002).*/
                public IntBasis SOR_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05      SOR-VLDEBCRE             PIC  9(013)V99.*/
            }
            public DoubleBasis SOR_VLDEBCRE { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
            /*"  05      SOR-RETORNO              PIC  X(002).*/
            public StringBasis SOR_RETORNO { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
            /*"  05      SOR-USOEMPRESA           PIC  X(060).*/
            public StringBasis SOR_USOEMPRESA { get; set; } = new StringBasis(new PIC("X", "60", "X(060)."), @"");
            /*"  05      SOR-PROC-ADVERT          PIC  X(002).*/
            public StringBasis SOR_PROC_ADVERT { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
            /*"  05      SOR-NIVE-ADVERT          PIC  X(002).*/
            public StringBasis SOR_NIVE_ADVERT { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
            /*"  05      SOR-MOTI-COMPEN          PIC  9(002).*/
            public IntBasis SOR_MOTI_COMPEN { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"  05      FILLER                   PIC  X(009).*/
            public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)."), @"");
            /*"  05      SOR-CODMOV               PIC  9(001).*/
            public IntBasis SOR_CODMOV { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"  05      SOR-IDLG                 PIC  X(040).*/
            public StringBasis SOR_IDLG { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
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
        /*"01        REG-SAIDA05                 PIC  X(150).*/
        public StringBasis REG_SAIDA05 { get; set; } = new StringBasis(new PIC("X", "150", "X(150)."), @"");
        /*"01        REG-SAIDA06                 PIC  X(150).*/
        public StringBasis REG_SAIDA06 { get; set; } = new StringBasis(new PIC("X", "150", "X(150)."), @"");
        /*"01        REG-SAIDA07                 PIC  X(150).*/
        public StringBasis REG_SAIDA07 { get; set; } = new StringBasis(new PIC("X", "150", "X(150)."), @"");
        /*"01        REG-SAIDA08                 PIC  X(150).*/
        public StringBasis REG_SAIDA08 { get; set; } = new StringBasis(new PIC("X", "150", "X(150)."), @"");
        /*"01        REG-SAIDA09                 PIC  X(150).*/
        public StringBasis REG_SAIDA09 { get; set; } = new StringBasis(new PIC("X", "150", "X(150)."), @"");
        /*"01        REG-SAIDA10                 PIC  X(150).*/
        public StringBasis REG_SAIDA10 { get; set; } = new StringBasis(new PIC("X", "150", "X(150)."), @"");
        /*"01        REG-SAIDA11                 PIC  X(150).*/
        public StringBasis REG_SAIDA11 { get; set; } = new StringBasis(new PIC("X", "150", "X(150)."), @"");
        /*"01        REG-SAIDA12                 PIC  X(150).*/
        public StringBasis REG_SAIDA12 { get; set; } = new StringBasis(new PIC("X", "150", "X(150)."), @"");
        /*"01        REG-SAIDA13                 PIC  X(150).*/
        public StringBasis REG_SAIDA13 { get; set; } = new StringBasis(new PIC("X", "150", "X(150)."), @"");
        /*"01        REG-SAIDA14                 PIC  X(150).*/
        public StringBasis REG_SAIDA14 { get; set; } = new StringBasis(new PIC("X", "150", "X(150)."), @"");
        /*"01        REG-SAIDA15                 PIC  X(150).*/
        public StringBasis REG_SAIDA15 { get; set; } = new StringBasis(new PIC("X", "150", "X(150)."), @"");

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77    WSHOST-NRAVISO1           PIC S9(009)    VALUE +0   COMP.*/
        public IntBasis WSHOST_NRAVISO1 { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    WSHOST-NRAVISO2           PIC S9(009)    VALUE +0   COMP.*/
        public IntBasis WSHOST_NRAVISO2 { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    WSHOST-NRAVISO3           PIC S9(009)    VALUE +0   COMP.*/
        public IntBasis WSHOST_NRAVISO3 { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    WSHOST-NRAVISO4           PIC S9(009)    VALUE +0   COMP.*/
        public IntBasis WSHOST_NRAVISO4 { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    V1SIST-DTCURRENT-18       PIC  X(010)    VALUE  SPACES.*/
        public StringBasis V1SIST_DTCURRENT_18 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"01    WS-NSAC-6088              PIC  9(005)    VALUE ZEROS.*/
        public IntBasis WS_NSAC_6088 { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
        /*"01  W.*/
        public EM8008B_W W { get; set; } = new EM8008B_W();
        public class EM8008B_W : VarBasis
        {
            /*"  03  WFIM-MOVIMENTO            PIC  X(001)    VALUE  'N'.*/
            public StringBasis WFIM_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
            /*"  03  WFIM-CONFITCE             PIC  X(001)    VALUE  'N'.*/
            public StringBasis WFIM_CONFITCE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
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
            /*"  03  AC-GRAV-SAIDA05           PIC  9(009)    VALUE   ZEROS.*/
            public IntBasis AC_GRAV_SAIDA05 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  AC-GRAV-SAIDA06           PIC  9(009)    VALUE   ZEROS.*/
            public IntBasis AC_GRAV_SAIDA06 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  AC-GRAV-SAIDA07           PIC  9(009)    VALUE   ZEROS.*/
            public IntBasis AC_GRAV_SAIDA07 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  AC-GRAV-SAIDA08           PIC  9(009)    VALUE   ZEROS.*/
            public IntBasis AC_GRAV_SAIDA08 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  AC-GRAV-SAIDA09           PIC  9(009)    VALUE   ZEROS.*/
            public IntBasis AC_GRAV_SAIDA09 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  AC-GRAV-SAIDA10           PIC  9(009)    VALUE   ZEROS.*/
            public IntBasis AC_GRAV_SAIDA10 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  AC-GRAV-SAIDA11           PIC  9(009)    VALUE   ZEROS.*/
            public IntBasis AC_GRAV_SAIDA11 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  AC-GRAV-SAIDA12           PIC  9(009)    VALUE   ZEROS.*/
            public IntBasis AC_GRAV_SAIDA12 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  AC-GRAV-SAIDA13           PIC  9(009)    VALUE   ZEROS.*/
            public IntBasis AC_GRAV_SAIDA13 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  AC-GRAV-SAIDA14           PIC  9(009)    VALUE   ZEROS.*/
            public IntBasis AC_GRAV_SAIDA14 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  AC-GRAV-SAIDA15           PIC  9(009)    VALUE   ZEROS.*/
            public IntBasis AC_GRAV_SAIDA15 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  WS-NRSEQ                  PIC  9(009)    VALUE   ZEROS.*/
            public IntBasis WS_NRSEQ { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  WS-TOTREG                 PIC  9(009)    VALUE   ZEROS.*/
            public IntBasis WS_TOTREG { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  WS-VALOR-0                PIC S9(16)V99  VALUE  +0.*/
            public DoubleBasis WS_VALOR_0 { get; set; } = new DoubleBasis(new PIC("S9", "16", "S9(16)V99"), 2);
            /*"  03  WS-VALOR-2                PIC S9(16)V99  VALUE  +0.*/
            public DoubleBasis WS_VALOR_2 { get; set; } = new DoubleBasis(new PIC("S9", "16", "S9(16)V99"), 2);
            /*"  03  WS9-NRO-NSAC              PIC  9(004)    VALUE   ZEROS.*/
            public IntBasis WS9_NRO_NSAC { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  03  WS-FITACEF                PIC  9(006)    VALUE   ZEROS.*/
            public IntBasis WS_FITACEF { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  03         WDATA-CABEC.*/
            public EM8008B_WDATA_CABEC WDATA_CABEC { get; set; } = new EM8008B_WDATA_CABEC();
            public class EM8008B_WDATA_CABEC : VarBasis
            {
                /*"    05       WDATA-DD-CABEC    PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WDATA_DD_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    05       FILLER            PIC  X(001)    VALUE '/'.*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    05       WDATA-MM-CABEC    PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WDATA_MM_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    05       FILLER            PIC  X(001)    VALUE '/'.*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    05       WDATA-AA-CABEC    PIC  9(004)    VALUE ZEROS.*/
                public IntBasis WDATA_AA_CABEC { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"  03         WDATA-REL          PIC  X(010)    VALUE   SPACES.*/
            }
            public StringBasis WDATA_REL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  03         FILLER             REDEFINES      WDATA-REL.*/
            private _REDEF_EM8008B_FILLER_4 _filler_4 { get; set; }
            public _REDEF_EM8008B_FILLER_4 FILLER_4
            {
                get { _filler_4 = new _REDEF_EM8008B_FILLER_4(); _.Move(WDATA_REL, _filler_4); VarBasis.RedefinePassValue(WDATA_REL, _filler_4, WDATA_REL); _filler_4.ValueChanged += () => { _.Move(_filler_4, WDATA_REL); }; return _filler_4; }
                set { VarBasis.RedefinePassValue(value, _filler_4, WDATA_REL); }
            }  //Redefines
            public class _REDEF_EM8008B_FILLER_4 : VarBasis
            {
                /*"    10       WDAT-REL-ANO       PIC  9(004).*/
                public IntBasis WDAT_REL_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       FILLER             PIC  X(001).*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDAT-REL-MES       PIC  9(002).*/
                public IntBasis WDAT_REL_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       FILLER             PIC  X(001).*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDAT-REL-DIA       PIC  9(002).*/
                public IntBasis WDAT_REL_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03         WS0-NRAVISO        PIC  9(009)    VALUE   ZEROS.*/

                public _REDEF_EM8008B_FILLER_4()
                {
                    WDAT_REL_ANO.ValueChanged += OnValueChanged;
                    FILLER_5.ValueChanged += OnValueChanged;
                    WDAT_REL_MES.ValueChanged += OnValueChanged;
                    FILLER_6.ValueChanged += OnValueChanged;
                    WDAT_REL_DIA.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WS0_NRAVISO { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03         FILLER             REDEFINES      WS0-NRAVISO.*/
            private _REDEF_EM8008B_FILLER_7 _filler_7 { get; set; }
            public _REDEF_EM8008B_FILLER_7 FILLER_7
            {
                get { _filler_7 = new _REDEF_EM8008B_FILLER_7(); _.Move(WS0_NRAVISO, _filler_7); VarBasis.RedefinePassValue(WS0_NRAVISO, _filler_7, WS0_NRAVISO); _filler_7.ValueChanged += () => { _.Move(_filler_7, WS0_NRAVISO); }; return _filler_7; }
                set { VarBasis.RedefinePassValue(value, _filler_7, WS0_NRAVISO); }
            }  //Redefines
            public class _REDEF_EM8008B_FILLER_7 : VarBasis
            {
                /*"    10       WS0-PRE-AVISO      PIC  9(004).*/
                public IntBasis WS0_PRE_AVISO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       WS0-NRO-MOV        PIC  9(001).*/
                public IntBasis WS0_NRO_MOV { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    10       WS0-NRO-NSAC       PIC  9(004).*/
                public IntBasis WS0_NRO_NSAC { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"  03         WS2-NRAVISO        PIC  9(009)    VALUE   ZEROS.*/

                public _REDEF_EM8008B_FILLER_7()
                {
                    WS0_PRE_AVISO.ValueChanged += OnValueChanged;
                    WS0_NRO_MOV.ValueChanged += OnValueChanged;
                    WS0_NRO_NSAC.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WS2_NRAVISO { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03         FILLER             REDEFINES      WS2-NRAVISO.*/
            private _REDEF_EM8008B_FILLER_8 _filler_8 { get; set; }
            public _REDEF_EM8008B_FILLER_8 FILLER_8
            {
                get { _filler_8 = new _REDEF_EM8008B_FILLER_8(); _.Move(WS2_NRAVISO, _filler_8); VarBasis.RedefinePassValue(WS2_NRAVISO, _filler_8, WS2_NRAVISO); _filler_8.ValueChanged += () => { _.Move(_filler_8, WS2_NRAVISO); }; return _filler_8; }
                set { VarBasis.RedefinePassValue(value, _filler_8, WS2_NRAVISO); }
            }  //Redefines
            public class _REDEF_EM8008B_FILLER_8 : VarBasis
            {
                /*"    10       WS2-PRE-AVISO      PIC  9(004).*/
                public IntBasis WS2_PRE_AVISO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       WS2-NRO-MOV        PIC  9(001).*/
                public IntBasis WS2_NRO_MOV { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    10       WS2-NRO-NSAC       PIC  9(004).*/
                public IntBasis WS2_NRO_NSAC { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"  03         WS3-NSAC           PIC  9(006)    VALUE   ZEROS.*/

                public _REDEF_EM8008B_FILLER_8()
                {
                    WS2_PRE_AVISO.ValueChanged += OnValueChanged;
                    WS2_NRO_MOV.ValueChanged += OnValueChanged;
                    WS2_NRO_NSAC.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WS3_NSAC { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  03         FILLER             REDEFINES      WS3-NSAC.*/
            private _REDEF_EM8008B_FILLER_9 _filler_9 { get; set; }
            public _REDEF_EM8008B_FILLER_9 FILLER_9
            {
                get { _filler_9 = new _REDEF_EM8008B_FILLER_9(); _.Move(WS3_NSAC, _filler_9); VarBasis.RedefinePassValue(WS3_NSAC, _filler_9, WS3_NSAC); _filler_9.ValueChanged += () => { _.Move(_filler_9, WS3_NSAC); }; return _filler_9; }
                set { VarBasis.RedefinePassValue(value, _filler_9, WS3_NSAC); }
            }  //Redefines
            public class _REDEF_EM8008B_FILLER_9 : VarBasis
            {
                /*"    10       FILLER             PIC  9(003).*/
                public IntBasis FILLER_10 { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"    10       WS3-NRO-NSAC       PIC  9(003).*/
                public IntBasis WS3_NRO_NSAC { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"01  ABEN.*/

                public _REDEF_EM8008B_FILLER_9()
                {
                    FILLER_10.ValueChanged += OnValueChanged;
                    WS3_NRO_NSAC.ValueChanged += OnValueChanged;
                }

            }
        }
        public EM8008B_ABEN ABEN { get; set; } = new EM8008B_ABEN();
        public class EM8008B_ABEN : VarBasis
        {
            /*"  03        WABEND.*/
            public EM8008B_WABEND WABEND { get; set; } = new EM8008B_WABEND();
            public class EM8008B_WABEND : VarBasis
            {
                /*"    05      FILLER              PIC  X(010) VALUE           ' EM8008B  '.*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" EM8008B  ");
                /*"    05      FILLER              PIC  X(028) VALUE           ' *** ERRO  EXEC SQL  NUMERO '.*/
                public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @" *** ERRO  EXEC SQL  NUMERO ");
                /*"    05      WNR-EXEC-SQL        PIC  X(040) VALUE    SPACES.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"  03        WABEND1.*/
            }
            public EM8008B_WABEND1 WABEND1 { get; set; } = new EM8008B_WABEND1();
            public class EM8008B_WABEND1 : VarBasis
            {
                /*"    05      FILLER              PIC  X(011) VALUE           ' SQLCODE = '.*/
                public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @" SQLCODE = ");
                /*"    05      WSQLCODE            PIC  ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                /*"    05      FILLER              PIC  X(012) VALUE           ' SQLERRD1 = '.*/
                public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @" SQLERRD1 = ");
                /*"    05      WSQLERRD1           PIC  ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLERRD1 { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                /*"    05      FILLER              PIC  X(012) VALUE           ' SQLERRD2 = '.*/
                public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @" SQLERRD2 = ");
                /*"    05      WSQLERRD2           PIC  ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLERRD2 { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                /*"01        HEADER-REGISTRO.*/
            }
        }
        public EM8008B_HEADER_REGISTRO HEADER_REGISTRO { get; set; } = new EM8008B_HEADER_REGISTRO();
        public class EM8008B_HEADER_REGISTRO : VarBasis
        {
            /*"  05      HEADER-CODREGISTRO       PIC  X(001).*/
            public StringBasis HEADER_CODREGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  05      HEADER-CODREMESSA        PIC  X(001).*/
            public StringBasis HEADER_CODREMESSA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  05      HEADER-CODCONVENIO       PIC  9(006).*/
            public IntBasis HEADER_CODCONVENIO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"  05      FILLER                   PIC  X(014).*/
            public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)."), @"");
            /*"  05      HEADER-NOMEMPRESA        PIC  X(020).*/
            public StringBasis HEADER_NOMEMPRESA { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
            /*"  05      HEADER-CODBANCO          PIC  X(003).*/
            public StringBasis HEADER_CODBANCO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
            /*"  05      HEADER-NOMBANCO          PIC  X(020).*/
            public StringBasis HEADER_NOMBANCO { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
            /*"  05      HEADER-DATGERACAO.*/
            public EM8008B_HEADER_DATGERACAO HEADER_DATGERACAO { get; set; } = new EM8008B_HEADER_DATGERACAO();
            public class EM8008B_HEADER_DATGERACAO : VarBasis
            {
                /*"    10    HEADER-ANO               PIC  9(004).*/
                public IntBasis HEADER_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10    HEADER-MES               PIC  9(002).*/
                public IntBasis HEADER_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10    HEADER-DIA               PIC  9(002).*/
                public IntBasis HEADER_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05      HEADER-NSA               PIC  9(006).*/
            }
            public IntBasis HEADER_NSA { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"  05      FILLER         REDEFINES      HEADER-NSA.*/
            private _REDEF_EM8008B_FILLER_17 _filler_17 { get; set; }
            public _REDEF_EM8008B_FILLER_17 FILLER_17
            {
                get { _filler_17 = new _REDEF_EM8008B_FILLER_17(); _.Move(HEADER_NSA, _filler_17); VarBasis.RedefinePassValue(HEADER_NSA, _filler_17, HEADER_NSA); _filler_17.ValueChanged += () => { _.Move(_filler_17, HEADER_NSA); }; return _filler_17; }
                set { VarBasis.RedefinePassValue(value, _filler_17, HEADER_NSA); }
            }  //Redefines
            public class _REDEF_EM8008B_FILLER_17 : VarBasis
            {
                /*"    10    FILLER                   PIC  9(003).*/
                public IntBasis FILLER_18 { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"    10    WS-NSAC                  PIC  9(003).*/
                public IntBasis WS_NSAC { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"  05      HEADER-VERSAO            PIC  X(002).*/

                public _REDEF_EM8008B_FILLER_17()
                {
                    FILLER_18.ValueChanged += OnValueChanged;
                    WS_NSAC.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis HEADER_VERSAO { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
            /*"  05      HEADER-DEBCREDAUT        PIC  X(017).*/
            public StringBasis HEADER_DEBCREDAUT { get; set; } = new StringBasis(new PIC("X", "17", "X(017)."), @"");
            /*"  05      FILLER                   PIC  X(052).*/
            public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "52", "X(052)."), @"");
            /*"01        MOVCC-REGISTRO.*/
        }
        public EM8008B_MOVCC_REGISTRO MOVCC_REGISTRO { get; set; } = new EM8008B_MOVCC_REGISTRO();
        public class EM8008B_MOVCC_REGISTRO : VarBasis
        {
            /*"  05      MOVCC-CODREG             PIC  X(001).*/
            public StringBasis MOVCC_CODREG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  05      MOVCC-IDTCLIEMP.*/
            public EM8008B_MOVCC_IDTCLIEMP MOVCC_IDTCLIEMP { get; set; } = new EM8008B_MOVCC_IDTCLIEMP();
            public class EM8008B_MOVCC_IDTCLIEMP : VarBasis
            {
                /*"    10    MOVCC-EMPRESA            PIC  X(025).*/
                public StringBasis MOVCC_EMPRESA { get; set; } = new StringBasis(new PIC("X", "25", "X(025)."), @"");
                /*"  05      MOVCC-IDTCLIBAN.*/
            }
            public EM8008B_MOVCC_IDTCLIBAN MOVCC_IDTCLIBAN { get; set; } = new EM8008B_MOVCC_IDTCLIBAN();
            public class EM8008B_MOVCC_IDTCLIBAN : VarBasis
            {
                /*"    10    MOVCC-AGECONTA           PIC  9(004).*/
                public IntBasis MOVCC_AGECONTA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10    MOVCC-OPECONTA           PIC  9(004).*/
                public IntBasis MOVCC_OPECONTA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10    MOVCC-NUMCONTA           PIC  9(012).*/
                public IntBasis MOVCC_NUMCONTA { get; set; } = new IntBasis(new PIC("9", "12", "9(012)."));
                /*"    10    MOVCC-DIGCONTA           PIC  9(001).*/
                public IntBasis MOVCC_DIGCONTA { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    10    FILLER                   PIC  X(002).*/
                public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"  05      MOVCC-DTCREDITO.*/
            }
            public EM8008B_MOVCC_DTCREDITO MOVCC_DTCREDITO { get; set; } = new EM8008B_MOVCC_DTCREDITO();
            public class EM8008B_MOVCC_DTCREDITO : VarBasis
            {
                /*"    10    MOVCC-ANO                PIC  9(004).*/
                public IntBasis MOVCC_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10    MOVCC-MES                PIC  9(002).*/
                public IntBasis MOVCC_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10    MOVCC-DIA                PIC  9(002).*/
                public IntBasis MOVCC_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05      MOVCC-VLDEBCRE           PIC  9(013)V99.*/
            }
            public DoubleBasis MOVCC_VLDEBCRE { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
            /*"  05      MOVCC-RETORNO            PIC  X(002).*/
            public StringBasis MOVCC_RETORNO { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
            /*"  05      MOVCC-USOEMPRESA         PIC  X(060).*/
            public StringBasis MOVCC_USOEMPRESA { get; set; } = new StringBasis(new PIC("X", "60", "X(060)."), @"");
            /*"  05      MOVCC-PROC-ADVERT        PIC  X(002).*/
            public StringBasis MOVCC_PROC_ADVERT { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
            /*"  05      MOVCC-NIVE-ADVERT        PIC  X(002).*/
            public StringBasis MOVCC_NIVE_ADVERT { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
            /*"  05      MOVCC-MOTI-COMPEN        PIC  9(002).*/
            public IntBasis MOVCC_MOTI_COMPEN { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"  05      FILLER                   PIC  X(009).*/
            public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)."), @"");
            /*"  05      MOVCC-CODMOV             PIC  9(001).*/
            public IntBasis MOVCC_CODMOV { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"01        MOVCC-REGISTRO2.*/
        }
        public EM8008B_MOVCC_REGISTRO2 MOVCC_REGISTRO2 { get; set; } = new EM8008B_MOVCC_REGISTRO2();
        public class EM8008B_MOVCC_REGISTRO2 : VarBasis
        {
            /*"  05      MOVCC-CODREG2            PIC  X(001).*/
            public StringBasis MOVCC_CODREG2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  05      MOVCC-IDTCLIEMP2.*/
            public EM8008B_MOVCC_IDTCLIEMP2 MOVCC_IDTCLIEMP2 { get; set; } = new EM8008B_MOVCC_IDTCLIEMP2();
            public class EM8008B_MOVCC_IDTCLIEMP2 : VarBasis
            {
                /*"    10    MOVCC-EMPRESA2           PIC  X(025).*/
                public StringBasis MOVCC_EMPRESA2 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)."), @"");
                /*"  05      MOVCC-IDTCLIBAN2.*/
            }
            public EM8008B_MOVCC_IDTCLIBAN2 MOVCC_IDTCLIBAN2 { get; set; } = new EM8008B_MOVCC_IDTCLIBAN2();
            public class EM8008B_MOVCC_IDTCLIBAN2 : VarBasis
            {
                /*"    10    MOVCC-AGECONTA2          PIC  9(004).*/
                public IntBasis MOVCC_AGECONTA2 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10    MOVCC-OPECONTA2          PIC  9(004).*/
                public IntBasis MOVCC_OPECONTA2 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10    MOVCC-NUMCONTA2          PIC  9(012).*/
                public IntBasis MOVCC_NUMCONTA2 { get; set; } = new IntBasis(new PIC("9", "12", "9(012)."));
                /*"    10    MOVCC-DIGCONTA2          PIC  9(001).*/
                public IntBasis MOVCC_DIGCONTA2 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    10    FILLER                   PIC  X(002).*/
                public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"  05      MOVCC-DTCREDITO2.*/
            }
            public EM8008B_MOVCC_DTCREDITO2 MOVCC_DTCREDITO2 { get; set; } = new EM8008B_MOVCC_DTCREDITO2();
            public class EM8008B_MOVCC_DTCREDITO2 : VarBasis
            {
                /*"    10    MOVCC-ANO2               PIC  9(004).*/
                public IntBasis MOVCC_ANO2 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10    MOVCC-MES2               PIC  9(002).*/
                public IntBasis MOVCC_MES2 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10    MOVCC-DIA2               PIC  9(002).*/
                public IntBasis MOVCC_DIA2 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05      MOVCC-VLDEBCRE2          PIC  9(013)V99.*/
            }
            public DoubleBasis MOVCC_VLDEBCRE2 { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
            /*"  05      MOVCC-RETORNO2           PIC  X(002).*/
            public StringBasis MOVCC_RETORNO2 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
            /*"  05      MOVCC-IDLG2              PIC  X(040).*/
            public StringBasis MOVCC_IDLG2 { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
            /*"  05      FILLER2                  PIC  X(035).*/
            public StringBasis FILLER2 { get; set; } = new StringBasis(new PIC("X", "35", "X(035)."), @"");
            /*"  05      MOVCC-CODMOV2            PIC  9(001).*/
            public IntBasis MOVCC_CODMOV2 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"01        TRAILL-REGISTRO.*/
        }
        public EM8008B_TRAILL_REGISTRO TRAILL_REGISTRO { get; set; } = new EM8008B_TRAILL_REGISTRO();
        public class EM8008B_TRAILL_REGISTRO : VarBasis
        {
            /*"  05      TRAILL-CODREGISTRO       PIC  X(001).*/
            public StringBasis TRAILL_CODREGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  05      TRAILL-TOTREGISTRO       PIC  9(006).*/
            public IntBasis TRAILL_TOTREGISTRO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"  05      TRAILL-VLRTOTDEB         PIC  9(015)V99.*/
            public DoubleBasis TRAILL_VLRTOTDEB { get; set; } = new DoubleBasis(new PIC("9", "15", "9(015)V99."), 2);
            /*"  05      TRAILL-VLRTOTCRE         PIC  9(015)V99.*/
            public DoubleBasis TRAILL_VLRTOTCRE { get; set; } = new DoubleBasis(new PIC("9", "15", "9(015)V99."), 2);
            /*"  05      TRAILL-FILLER            PIC  X(109).*/
            public StringBasis TRAILL_FILLER { get; set; } = new StringBasis(new PIC("X", "109", "X(109)."), @"");
        }


        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.AVISOCRE AVISOCRE { get; set; } = new Dclgens.AVISOCRE();
        public Dclgens.CONFITCE CONFITCE { get; set; } = new Dclgens.CONFITCE();
        public Dclgens.GEARDETA GEARDETA { get; set; } = new Dclgens.GEARDETA();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string ARQSORT_FILE_NAME_P, string ENTRADA_FILE_NAME_P, string SAIDA01_FILE_NAME_P, string SAIDA02_FILE_NAME_P, string SAIDA03_FILE_NAME_P, string SAIDA04_FILE_NAME_P, string SAIDA05_FILE_NAME_P, string SAIDA06_FILE_NAME_P, string SAIDA07_FILE_NAME_P, string SAIDA08_FILE_NAME_P, string SAIDA09_FILE_NAME_P, string SAIDA10_FILE_NAME_P, string SAIDA11_FILE_NAME_P, string SAIDA12_FILE_NAME_P, string SAIDA13_FILE_NAME_P, string SAIDA14_FILE_NAME_P, string SAIDA15_FILE_NAME_P) //PROCEDURE DIVISION 
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
                SAIDA05.SetFile(SAIDA05_FILE_NAME_P);
                SAIDA06.SetFile(SAIDA06_FILE_NAME_P);
                SAIDA07.SetFile(SAIDA07_FILE_NAME_P);
                SAIDA08.SetFile(SAIDA08_FILE_NAME_P);
                SAIDA09.SetFile(SAIDA09_FILE_NAME_P);
                SAIDA10.SetFile(SAIDA10_FILE_NAME_P);
                SAIDA11.SetFile(SAIDA11_FILE_NAME_P);
                SAIDA12.SetFile(SAIDA12_FILE_NAME_P);
                SAIDA13.SetFile(SAIDA13_FILE_NAME_P);
                SAIDA14.SetFile(SAIDA14_FILE_NAME_P);
                SAIDA15.SetFile(SAIDA15_FILE_NAME_P);

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
            /*" -594- MOVE '0000' TO WNR-EXEC-SQL. */
            _.Move("0000", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -595- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -597- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -599- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -609- DISPLAY 'EM8008B VERSAO 16 - INICIO PROCESSAMENTO EM ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2). */

            $"EM8008B VERSAO 16 - INICIO PROCESSAMENTO EM {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
            .Display();

            /*" -612- PERFORM R0050-00-INICIO. */

            R0050_00_INICIO_SECTION();

            /*" -624- SORT ARQSORT ON ASCENDING KEY SOR-CODBANCO SOR-CONVENIO SOR-CODMOV SOR-NSAS INPUT PROCEDURE R0200-00-INPUT-SORT THRU R0200-99-SAIDA OUTPUT PROCEDURE R0500-00-OUTPUT-SORT THRU R0500-99-SAIDA. */
            ARQSORT.Sort("SOR-CODBANCO,SOR-CONVENIO,SOR-CODMOV,SOR-NSAS", () => R0200_00_INPUT_SORT_SECTION(), () => R0500_00_OUTPUT_SORT_SECTION());

            /*" -0- FLUXCONTROL_PERFORM R0000_90_FINALIZA */

            R0000_90_FINALIZA();

        }

        [StopWatch]
        /*" R0000-90-FINALIZA */
        private void R0000_90_FINALIZA(bool isPerform = false)
        {
            /*" -629- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -648- CLOSE ENTRADA SAIDA01 SAIDA02 SAIDA03 SAIDA04 SAIDA05 SAIDA06 SAIDA07 SAIDA08 SAIDA09 SAIDA10 SAIDA11 SAIDA12 SAIDA13 SAIDA14 SAIDA15. */
            ENTRADA.Close();
            SAIDA01.Close();
            SAIDA02.Close();
            SAIDA03.Close();
            SAIDA04.Close();
            SAIDA05.Close();
            SAIDA06.Close();
            SAIDA07.Close();
            SAIDA08.Close();
            SAIDA09.Close();
            SAIDA10.Close();
            SAIDA11.Close();
            SAIDA12.Close();
            SAIDA13.Close();
            SAIDA14.Close();
            SAIDA15.Close();

            /*" -650- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -651- DISPLAY ' ' */
            _.Display($" ");

            /*" -652- DISPLAY 'EM8008B - FIM NORMAL' . */
            _.Display($"EM8008B - FIM NORMAL");

            /*" -654- DISPLAY ' ' . */
            _.Display($" ");

            /*" -654- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0050-00-INICIO-SECTION */
        private void R0050_00_INICIO_SECTION()
        {
            /*" -667- MOVE '0050' TO WNR-EXEC-SQL. */
            _.Move("0050", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -668- OPEN INPUT ENTRADA */
            ENTRADA.Open(REG_ENTRADA);

            /*" -685- OUTPUT SAIDA01 SAIDA02 SAIDA03 SAIDA04 SAIDA05 SAIDA06 SAIDA07 SAIDA08 SAIDA09 SAIDA10 SAIDA11 SAIDA12 SAIDA13 SAIDA14 SAIDA15. */
            SAIDA15.Open(REG_SAIDA15);

            /*" -687- PERFORM R0100-00-SELECT-SISTEMA. */

            R0100_00_SELECT_SISTEMA_SECTION();

            /*" -688- MOVE SPACES TO WFIM-MOVIMENTO. */
            _.Move("", W.WFIM_MOVIMENTO);

            /*" -691- PERFORM R0300-00-LER-MOVIMENTO. */

            R0300_00_LER_MOVIMENTO_SECTION();

            /*" -692- IF WFIM-MOVIMENTO NOT EQUAL SPACES */

            if (!W.WFIM_MOVIMENTO.IsEmpty())
            {

                /*" -692- GO TO R9990-00-SEM-MOVIMENTO. */

                R9990_00_SEM_MOVIMENTO_SECTION(); //GOTO
                return;
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0050_99_SAIDA*/

        [StopWatch]
        /*" R0100-00-SELECT-SISTEMA-SECTION */
        private void R0100_00_SELECT_SISTEMA_SECTION()
        {
            /*" -705- MOVE '0100' TO WNR-EXEC-SQL. */
            _.Move("0100", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -715- PERFORM R0100_00_SELECT_SISTEMA_DB_SELECT_1 */

            R0100_00_SELECT_SISTEMA_DB_SELECT_1();

            /*" -718- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -719- DISPLAY 'R0100-00 - PROBLEMAS NO SELECT(SISTEMAS)' */
                _.Display($"R0100-00 - PROBLEMAS NO SELECT(SISTEMAS)");

                /*" -719- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0100-00-SELECT-SISTEMA-DB-SELECT-1 */
        public void R0100_00_SELECT_SISTEMA_DB_SELECT_1()
        {
            /*" -715- EXEC SQL SELECT DATA_MOV_ABERTO , (CURRENT DATE - 18 MONTHS) INTO :SISTEMAS-DATA-MOV-ABERTO , :V1SIST-DTCURRENT-18 FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'EM' WITH UR END-EXEC. */

            var r0100_00_SELECT_SISTEMA_DB_SELECT_1_Query1 = new R0100_00_SELECT_SISTEMA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0100_00_SELECT_SISTEMA_DB_SELECT_1_Query1.Execute(r0100_00_SELECT_SISTEMA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);
                _.Move(executed_1.V1SIST_DTCURRENT_18, V1SIST_DTCURRENT_18);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/

        [StopWatch]
        /*" R0200-00-INPUT-SORT-SECTION */
        private void R0200_00_INPUT_SORT_SECTION()
        {
            /*" -732- MOVE '0200' TO WNR-EXEC-SQL. */
            _.Move("0200", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -736- PERFORM R0350-00-PROCESSA-MOVIMENTO UNTIL WFIM-MOVIMENTO NOT EQUAL SPACES. */

            while (!(!W.WFIM_MOVIMENTO.IsEmpty()))
            {

                R0350_00_PROCESSA_MOVIMENTO_SECTION();
            }

            /*" -737- DISPLAY ' ' */
            _.Display($" ");

            /*" -738- DISPLAY 'LIDOS MOVIMENTO ....... ' LD-MOVIMENTO */
            _.Display($"LIDOS MOVIMENTO ....... {W.LD_MOVIMENTO}");

            /*" -739- DISPLAY 'DESPREZA MOVIMENTO .... ' DP-MOVIMENTO */
            _.Display($"DESPREZA MOVIMENTO .... {W.DP_MOVIMENTO}");

            /*" -740- DISPLAY 'GRAVADOS SORT ......... ' GV-SORT */
            _.Display($"GRAVADOS SORT ......... {W.GV_SORT}");

            /*" -740- DISPLAY ' ' . */
            _.Display($" ");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_99_SAIDA*/

        [StopWatch]
        /*" R0300-00-LER-MOVIMENTO-SECTION */
        private void R0300_00_LER_MOVIMENTO_SECTION()
        {
            /*" -753- MOVE '0300' TO WNR-EXEC-SQL. */
            _.Move("0300", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -754- READ ENTRADA AT END */
            try
            {
                ENTRADA.Read(() =>
                {

                    /*" -756- MOVE 'S' TO WFIM-MOVIMENTO */
                    _.Move("S", W.WFIM_MOVIMENTO);

                    /*" -759- GO TO R0300-99-SAIDA. */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_99_SAIDA*/ //GOTO
                    return;
                });

                _.Move(ENTRADA.Value, REG_ENTRADA);

            }
            catch (GoToException ex)
            {
                return;
            }
            /*" -759- ADD 1 TO LD-MOVIMENTO. */
            W.LD_MOVIMENTO.Value = W.LD_MOVIMENTO + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_99_SAIDA*/

        [StopWatch]
        /*" R0350-00-PROCESSA-MOVIMENTO-SECTION */
        private void R0350_00_PROCESSA_MOVIMENTO_SECTION()
        {
            /*" -772- MOVE '0350' TO WNR-EXEC-SQL. */
            _.Move("0350", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -775- MOVE REG-ENTRADA TO REG-ARQSORT. */
            _.Move(ENTRADA?.Value, REG_ARQSORT);

            /*" -790- IF SOR-CONVENIO EQUAL 600114 OR 600119 OR 600120 OR 600121 OR 600123 OR 600128 OR 600139 OR 600140 OR 600149 OR 608800 OR 609000 OR 613100 OR 613200 OR 900662 OR 609500 */

            if (REG_ARQSORT.SOR_CONVENIO.In("600114", "600119", "600120", "600121", "600123", "600128", "600139", "600140", "600149", "608800", "609000", "613100", "613200", "900662", "609500"))
            {

                /*" -791- RELEASE REG-ARQSORT */
                ARQSORT.Release(REG_ARQSORT);

                /*" -793- ADD 1 TO GV-SORT */
                W.GV_SORT.Value = W.GV_SORT + 1;

                /*" -795- IF SOR-CONVENIO EQUAL 608800 AND (SOR-NSAC NOT EQUAL 9999 AND 99999) */

                if (REG_ARQSORT.SOR_CONVENIO == 608800 && (!REG_ARQSORT.SOR_NSAC.In("9999", "99999")))
                {

                    /*" -796- IF SOR-NSAC GREATER WS-NSAC-6088 */

                    if (REG_ARQSORT.SOR_NSAC > WS_NSAC_6088)
                    {

                        /*" -797- MOVE SOR-NSAC TO WS-NSAC-6088 */
                        _.Move(REG_ARQSORT.SOR_NSAC, WS_NSAC_6088);

                        /*" -798- END-IF */
                    }


                    /*" -800- END-IF */
                }


                /*" -801- ELSE */
            }
            else
            {


                /*" -801- ADD 1 TO DP-MOVIMENTO. */
                W.DP_MOVIMENTO.Value = W.DP_MOVIMENTO + 1;
            }


            /*" -0- FLUXCONTROL_PERFORM R0350_90_LEITURA */

            R0350_90_LEITURA();

        }

        [StopWatch]
        /*" R0350-90-LEITURA */
        private void R0350_90_LEITURA(bool isPerform = false)
        {
            /*" -806- PERFORM R0300-00-LER-MOVIMENTO. */

            R0300_00_LER_MOVIMENTO_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0350_99_SAIDA*/

        [StopWatch]
        /*" R0500-00-OUTPUT-SORT-SECTION */
        private void R0500_00_OUTPUT_SORT_SECTION()
        {
            /*" -818- MOVE '0500' TO WNR-EXEC-SQL. */
            _.Move("0500", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -819- MOVE SPACES TO WFIM-SORT. */
            _.Move("", W.WFIM_SORT);

            /*" -822- PERFORM R0510-00-LE-ARQSORT. */

            R0510_00_LE_ARQSORT_SECTION();

            /*" -826- PERFORM R0550-00-PROCESSA-SORT UNTIL WFIM-SORT NOT EQUAL SPACES. */

            while (!(!W.WFIM_SORT.IsEmpty()))
            {

                R0550_00_PROCESSA_SORT_SECTION();
            }

            /*" -827- DISPLAY ' ' */
            _.Display($" ");

            /*" -828- DISPLAY 'LIDOS SORT ............ ' LD-SORT */
            _.Display($"LIDOS SORT ............ {W.LD_SORT}");

            /*" -829- DISPLAY 'GRAVADOS SICOV 600114 . ' AC-GRAV-SAIDA01. */
            _.Display($"GRAVADOS SICOV 600114 . {W.AC_GRAV_SAIDA01}");

            /*" -830- DISPLAY 'GRAVADOS SICOV 600119 . ' AC-GRAV-SAIDA02. */
            _.Display($"GRAVADOS SICOV 600119 . {W.AC_GRAV_SAIDA02}");

            /*" -831- DISPLAY 'GRAVADOS SICOV 600120 . ' AC-GRAV-SAIDA03. */
            _.Display($"GRAVADOS SICOV 600120 . {W.AC_GRAV_SAIDA03}");

            /*" -832- DISPLAY 'GRAVADOS SICOV 600121 . ' AC-GRAV-SAIDA04. */
            _.Display($"GRAVADOS SICOV 600121 . {W.AC_GRAV_SAIDA04}");

            /*" -833- DISPLAY 'GRAVADOS SICOV 600123 . ' AC-GRAV-SAIDA05. */
            _.Display($"GRAVADOS SICOV 600123 . {W.AC_GRAV_SAIDA05}");

            /*" -834- DISPLAY 'GRAVADOS SICOV 600128 . ' AC-GRAV-SAIDA06. */
            _.Display($"GRAVADOS SICOV 600128 . {W.AC_GRAV_SAIDA06}");

            /*" -835- DISPLAY 'GRAVADOS SICOV 600139 . ' AC-GRAV-SAIDA07. */
            _.Display($"GRAVADOS SICOV 600139 . {W.AC_GRAV_SAIDA07}");

            /*" -836- DISPLAY 'GRAVADOS SICOV 600140 . ' AC-GRAV-SAIDA08. */
            _.Display($"GRAVADOS SICOV 600140 . {W.AC_GRAV_SAIDA08}");

            /*" -837- DISPLAY 'GRAVADOS SICOV 608800 . ' AC-GRAV-SAIDA09. */
            _.Display($"GRAVADOS SICOV 608800 . {W.AC_GRAV_SAIDA09}");

            /*" -838- DISPLAY 'GRAVADOS SICOV 609000 . ' AC-GRAV-SAIDA10. */
            _.Display($"GRAVADOS SICOV 609000 . {W.AC_GRAV_SAIDA10}");

            /*" -839- DISPLAY 'GRAVADOS SICOV 613100 . ' AC-GRAV-SAIDA11. */
            _.Display($"GRAVADOS SICOV 613100 . {W.AC_GRAV_SAIDA11}");

            /*" -840- DISPLAY 'GRAVADOS SICOV 613200 . ' AC-GRAV-SAIDA12. */
            _.Display($"GRAVADOS SICOV 613200 . {W.AC_GRAV_SAIDA12}");

            /*" -841- DISPLAY 'GRAVADOS SICOV 900662 . ' AC-GRAV-SAIDA13. */
            _.Display($"GRAVADOS SICOV 900662 . {W.AC_GRAV_SAIDA13}");

            /*" -842- DISPLAY 'GRAVADOS SICOV 600149 . ' AC-GRAV-SAIDA14. */
            _.Display($"GRAVADOS SICOV 600149 . {W.AC_GRAV_SAIDA14}");

            /*" -843- DISPLAY 'GRAVADOS SICOV 609500 . ' AC-GRAV-SAIDA15. */
            _.Display($"GRAVADOS SICOV 609500 . {W.AC_GRAV_SAIDA15}");

            /*" -843- DISPLAY ' ' . */
            _.Display($" ");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0500_99_SAIDA*/

        [StopWatch]
        /*" R0510-00-LE-ARQSORT-SECTION */
        private void R0510_00_LE_ARQSORT_SECTION()
        {
            /*" -856- MOVE '0510' TO WNR-EXEC-SQL. */
            _.Move("0510", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -858- RETURN ARQSORT AT END */
            try
            {
                ARQSORT.Return(REG_ARQSORT, () =>
                {

                    /*" -859- MOVE ZEROS TO ATU-CONVENIO */
                    _.Move(0, W.ATU_CONVENIO);

                    /*" -860- MOVE 'S' TO WFIM-SORT */
                    _.Move("S", W.WFIM_SORT);

                    /*" -863- GO TO R0510-99-SAIDA. */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0510_99_SAIDA*/ //GOTO
                    return;

                });
            }
            catch (GoToException ex)
            {
                return;
            }
            /*" -865- ADD 1 TO LD-SORT. */
            W.LD_SORT.Value = W.LD_SORT + 1;

            /*" -865- MOVE SOR-CONVENIO TO ATU-CONVENIO. */
            _.Move(REG_ARQSORT.SOR_CONVENIO, W.ATU_CONVENIO);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0510_99_SAIDA*/

        [StopWatch]
        /*" R0550-00-PROCESSA-SORT-SECTION */
        private void R0550_00_PROCESSA_SORT_SECTION()
        {
            /*" -878- MOVE '0550' TO WNR-EXEC-SQL. */
            _.Move("0550", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -880- MOVE ATU-CONVENIO TO ANT-CONVENIO. */
            _.Move(W.ATU_CONVENIO, W.ANT_CONVENIO);

            /*" -882- IF SOR-CONVENIO EQUAL 608800 AND (SOR-NSAC NOT EQUAL 9999 AND 99999) */

            if (REG_ARQSORT.SOR_CONVENIO == 608800 && (!REG_ARQSORT.SOR_NSAC.In("9999", "99999")))
            {

                /*" -883- MOVE SOR-NSAC TO WS-NSAC-6088 */
                _.Move(REG_ARQSORT.SOR_NSAC, WS_NSAC_6088);

                /*" -884- PERFORM 550-10-CONSISTE-NSAC-6088 */

                M_550_10_CONSISTE_NSAC_6088_SECTION();

                /*" -885- MOVE WS-NSAC-6088 TO SOR-NSAC */
                _.Move(WS_NSAC_6088, REG_ARQSORT.SOR_NSAC);

                /*" -887- END-IF. */
            }


            /*" -890- PERFORM R1100-00-GRAVA-HEADER. */

            R1100_00_GRAVA_HEADER_SECTION();

            /*" -895- PERFORM R1000-00-PROCESSA-DETALHE UNTIL ATU-CONVENIO NOT EQUAL ANT-CONVENIO OR WFIM-SORT NOT EQUAL SPACES. */

            while (!(W.ATU_CONVENIO != W.ANT_CONVENIO || !W.WFIM_SORT.IsEmpty()))
            {

                R1000_00_PROCESSA_DETALHE_SECTION();
            }

            /*" -895- PERFORM R1200-00-GRAVA-TRAILLER. */

            R1200_00_GRAVA_TRAILLER_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0550_99_SAIDA*/

        [StopWatch]
        /*" M-550-10-CONSISTE-NSAC-6088-SECTION */
        private void M_550_10_CONSISTE_NSAC_6088_SECTION()
        {
            /*" -907- MOVE WS-NSAC-6088 TO GEARDETA-SEQ-GERACAO. */
            _.Move(WS_NSAC_6088, GEARDETA.DCLGE_AR_DETALHE.GEARDETA_SEQ_GERACAO);

            /*" -913- PERFORM M_550_10_CONSISTE_NSAC_6088_DB_SELECT_1 */

            M_550_10_CONSISTE_NSAC_6088_DB_SELECT_1();

            /*" -916- IF SQLCODE EQUAL ZERO */

            if (DB.SQLCODE == 00)
            {

                /*" -917- PERFORM 550-11-NOVO-NSAC-6088 */

                M_550_11_NOVO_NSAC_6088_SECTION();

                /*" -918- ELSE */
            }
            else
            {


                /*" -919- IF SQLCODE EQUAL +100 */

                if (DB.SQLCODE == +100)
                {

                    /*" -920- CONTINUE */

                    /*" -921- ELSE */
                }
                else
                {


                    /*" -922- DISPLAY 'ERRO SECTION 550-10-CONSISTE-NSAC-6088' */
                    _.Display($"ERRO SECTION 550-10-CONSISTE-NSAC-6088");

                    /*" -923- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -923- END-IF. */
                }

            }


        }

        [StopWatch]
        /*" M-550-10-CONSISTE-NSAC-6088-DB-SELECT-1 */
        public void M_550_10_CONSISTE_NSAC_6088_DB_SELECT_1()
        {
            /*" -913- EXEC SQL SELECT SEQ_GERACAO INTO :GEARDETA-SEQ-GERACAO FROM SEGUROS.GE_AR_DETALHE WHERE NOM_ARQUIVO = 'R608800' AND SEQ_GERACAO = :GEARDETA-SEQ-GERACAO END-EXEC. */

            var m_550_10_CONSISTE_NSAC_6088_DB_SELECT_1_Query1 = new M_550_10_CONSISTE_NSAC_6088_DB_SELECT_1_Query1()
            {
                GEARDETA_SEQ_GERACAO = GEARDETA.DCLGE_AR_DETALHE.GEARDETA_SEQ_GERACAO.ToString(),
            };

            var executed_1 = M_550_10_CONSISTE_NSAC_6088_DB_SELECT_1_Query1.Execute(m_550_10_CONSISTE_NSAC_6088_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.GEARDETA_SEQ_GERACAO, GEARDETA.DCLGE_AR_DETALHE.GEARDETA_SEQ_GERACAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_550_10_CONSISTE_NSAC_6088_SAI*/

        [StopWatch]
        /*" M-550-11-NOVO-NSAC-6088-SECTION */
        private void M_550_11_NOVO_NSAC_6088_SECTION()
        {
            /*" -938- PERFORM M_550_11_NOVO_NSAC_6088_DB_SELECT_1 */

            M_550_11_NOVO_NSAC_6088_DB_SELECT_1();

            /*" -941- IF SQLCODE EQUAL ZERO */

            if (DB.SQLCODE == 00)
            {

                /*" -943- ADD 1 TO GEARDETA-SEQ-GERACAO GIVING WS-NSAC-6088 */
                WS_NSAC_6088.Value = GEARDETA.DCLGE_AR_DETALHE.GEARDETA_SEQ_GERACAO + 1;

                /*" -944- ELSE */
            }
            else
            {


                /*" -945- DISPLAY 'ERRO SECTION 550-11-NOVO-NSAC-6088' */
                _.Display($"ERRO SECTION 550-11-NOVO-NSAC-6088");

                /*" -946- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -946- END-IF. */
            }


        }

        [StopWatch]
        /*" M-550-11-NOVO-NSAC-6088-DB-SELECT-1 */
        public void M_550_11_NOVO_NSAC_6088_DB_SELECT_1()
        {
            /*" -938- EXEC SQL SELECT MAX(SEQ_GERACAO) INTO :GEARDETA-SEQ-GERACAO FROM SEGUROS.GE_AR_DETALHE WHERE NOM_ARQUIVO = 'R608800' AND SEQ_GERACAO <= 99999 END-EXEC. */

            var m_550_11_NOVO_NSAC_6088_DB_SELECT_1_Query1 = new M_550_11_NOVO_NSAC_6088_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = M_550_11_NOVO_NSAC_6088_DB_SELECT_1_Query1.Execute(m_550_11_NOVO_NSAC_6088_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.GEARDETA_SEQ_GERACAO, GEARDETA.DCLGE_AR_DETALHE.GEARDETA_SEQ_GERACAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_550_11_NOVO_NSAC_6088_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-DETALHE-SECTION */
        private void R1000_00_PROCESSA_DETALHE_SECTION()
        {
            /*" -958- MOVE '1000' TO WNR-EXEC-SQL. */
            _.Move("1000", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -960- MOVE SPACES TO MOVCC-REGISTRO. */
            _.Move("", MOVCC_REGISTRO);

            /*" -962- MOVE 'F' TO MOVCC-CODREG. */
            _.Move("F", MOVCC_REGISTRO.MOVCC_CODREG);

            /*" -964- MOVE SOR-IDTCLIEMP TO MOVCC-EMPRESA. */
            _.Move(REG_ARQSORT.SOR_IDTCLIEMP, MOVCC_REGISTRO.MOVCC_IDTCLIEMP.MOVCC_EMPRESA);

            /*" -966- MOVE SOR-IDTCLIBAN TO MOVCC-IDTCLIBAN. */
            _.Move(REG_ARQSORT.SOR_IDTCLIBAN, MOVCC_REGISTRO.MOVCC_IDTCLIBAN);

            /*" -968- MOVE SOR-DTCREDITO TO MOVCC-DTCREDITO. */
            _.Move(REG_ARQSORT.SOR_DTCREDITO, MOVCC_REGISTRO.MOVCC_DTCREDITO);

            /*" -970- MOVE SOR-VLDEBCRE TO MOVCC-VLDEBCRE. */
            _.Move(REG_ARQSORT.SOR_VLDEBCRE, MOVCC_REGISTRO.MOVCC_VLDEBCRE);

            /*" -972- MOVE SOR-RETORNO TO MOVCC-RETORNO. */
            _.Move(REG_ARQSORT.SOR_RETORNO, MOVCC_REGISTRO.MOVCC_RETORNO);

            /*" -974- MOVE SOR-USOEMPRESA TO MOVCC-USOEMPRESA. */
            _.Move(REG_ARQSORT.SOR_USOEMPRESA, MOVCC_REGISTRO.MOVCC_USOEMPRESA);

            /*" -976- MOVE SOR-CODMOV TO MOVCC-CODMOV. */
            _.Move(REG_ARQSORT.SOR_CODMOV, MOVCC_REGISTRO.MOVCC_CODMOV);

            /*" -977- IF SOR-PROC-ADVERT EQUAL LOW-VALUES */

            if (REG_ARQSORT.SOR_PROC_ADVERT.IsLowValues())
            {

                /*" -978- MOVE SPACES TO SOR-PROC-ADVERT */
                _.Move("", REG_ARQSORT.SOR_PROC_ADVERT);

                /*" -979- END-IF */
            }


            /*" -980- IF SOR-NIVE-ADVERT EQUAL LOW-VALUES */

            if (REG_ARQSORT.SOR_NIVE_ADVERT.IsLowValues())
            {

                /*" -981- MOVE SPACES TO SOR-NIVE-ADVERT */
                _.Move("", REG_ARQSORT.SOR_NIVE_ADVERT);

                /*" -982- END-IF */
            }


            /*" -984- MOVE SOR-PROC-ADVERT TO MOVCC-PROC-ADVERT. */
            _.Move(REG_ARQSORT.SOR_PROC_ADVERT, MOVCC_REGISTRO.MOVCC_PROC_ADVERT);

            /*" -986- MOVE SOR-NIVE-ADVERT TO MOVCC-NIVE-ADVERT. */
            _.Move(REG_ARQSORT.SOR_NIVE_ADVERT, MOVCC_REGISTRO.MOVCC_NIVE_ADVERT);

            /*" -989- MOVE SOR-MOTI-COMPEN TO MOVCC-MOTI-COMPEN. */
            _.Move(REG_ARQSORT.SOR_MOTI_COMPEN, MOVCC_REGISTRO.MOVCC_MOTI_COMPEN);

            /*" -990- IF SOR-CODMOV EQUAL 0 */

            if (REG_ARQSORT.SOR_CODMOV == 0)
            {

                /*" -992- COMPUTE WS-VALOR-0 EQUAL (WS-VALOR-0 + SOR-VLDEBCRE) */
                W.WS_VALOR_0.Value = (W.WS_VALOR_0 + REG_ARQSORT.SOR_VLDEBCRE);

                /*" -993- ELSE */
            }
            else
            {


                /*" -994- IF SOR-CODMOV EQUAL 2 */

                if (REG_ARQSORT.SOR_CODMOV == 2)
                {

                    /*" -997- COMPUTE WS-VALOR-2 EQUAL (WS-VALOR-2 + SOR-VLDEBCRE). */
                    W.WS_VALOR_2.Value = (W.WS_VALOR_2 + REG_ARQSORT.SOR_VLDEBCRE);
                }

            }


            /*" -1000- ADD 1 TO WS-TOTREG. */
            W.WS_TOTREG.Value = W.WS_TOTREG + 1;

            /*" -1001- IF ANT-CONVENIO EQUAL 600114 */

            if (W.ANT_CONVENIO == 600114)
            {

                /*" -1002- WRITE REG-SAIDA01 FROM MOVCC-REGISTRO */
                _.Move(MOVCC_REGISTRO.GetMoveValues(), REG_SAIDA01);

                SAIDA01.Write(REG_SAIDA01.GetMoveValues().ToString());

                /*" -1003- ADD 1 TO AC-GRAV-SAIDA01 */
                W.AC_GRAV_SAIDA01.Value = W.AC_GRAV_SAIDA01 + 1;

                /*" -1004- ELSE */
            }
            else
            {


                /*" -1005- IF ANT-CONVENIO EQUAL 600119 */

                if (W.ANT_CONVENIO == 600119)
                {

                    /*" -1006- WRITE REG-SAIDA02 FROM MOVCC-REGISTRO */
                    _.Move(MOVCC_REGISTRO.GetMoveValues(), REG_SAIDA02);

                    SAIDA02.Write(REG_SAIDA02.GetMoveValues().ToString());

                    /*" -1007- ADD 1 TO AC-GRAV-SAIDA02 */
                    W.AC_GRAV_SAIDA02.Value = W.AC_GRAV_SAIDA02 + 1;

                    /*" -1008- ELSE */
                }
                else
                {


                    /*" -1009- IF ANT-CONVENIO EQUAL 600120 */

                    if (W.ANT_CONVENIO == 600120)
                    {

                        /*" -1010- WRITE REG-SAIDA03 FROM MOVCC-REGISTRO */
                        _.Move(MOVCC_REGISTRO.GetMoveValues(), REG_SAIDA03);

                        SAIDA03.Write(REG_SAIDA03.GetMoveValues().ToString());

                        /*" -1011- ADD 1 TO AC-GRAV-SAIDA03 */
                        W.AC_GRAV_SAIDA03.Value = W.AC_GRAV_SAIDA03 + 1;

                        /*" -1012- ELSE */
                    }
                    else
                    {


                        /*" -1013- IF ANT-CONVENIO EQUAL 600121 */

                        if (W.ANT_CONVENIO == 600121)
                        {

                            /*" -1014- WRITE REG-SAIDA04 FROM MOVCC-REGISTRO */
                            _.Move(MOVCC_REGISTRO.GetMoveValues(), REG_SAIDA04);

                            SAIDA04.Write(REG_SAIDA04.GetMoveValues().ToString());

                            /*" -1015- ADD 1 TO AC-GRAV-SAIDA04 */
                            W.AC_GRAV_SAIDA04.Value = W.AC_GRAV_SAIDA04 + 1;

                            /*" -1016- ELSE */
                        }
                        else
                        {


                            /*" -1017- IF ANT-CONVENIO EQUAL 600123 */

                            if (W.ANT_CONVENIO == 600123)
                            {

                                /*" -1018- WRITE REG-SAIDA05 FROM MOVCC-REGISTRO */
                                _.Move(MOVCC_REGISTRO.GetMoveValues(), REG_SAIDA05);

                                SAIDA05.Write(REG_SAIDA05.GetMoveValues().ToString());

                                /*" -1019- ADD 1 TO AC-GRAV-SAIDA05 */
                                W.AC_GRAV_SAIDA05.Value = W.AC_GRAV_SAIDA05 + 1;

                                /*" -1020- ELSE */
                            }
                            else
                            {


                                /*" -1021- IF ANT-CONVENIO EQUAL 600128 */

                                if (W.ANT_CONVENIO == 600128)
                                {

                                    /*" -1022- WRITE REG-SAIDA06 FROM MOVCC-REGISTRO */
                                    _.Move(MOVCC_REGISTRO.GetMoveValues(), REG_SAIDA06);

                                    SAIDA06.Write(REG_SAIDA06.GetMoveValues().ToString());

                                    /*" -1023- ADD 1 TO AC-GRAV-SAIDA06 */
                                    W.AC_GRAV_SAIDA06.Value = W.AC_GRAV_SAIDA06 + 1;

                                    /*" -1024- ELSE */
                                }
                                else
                                {


                                    /*" -1025- IF ANT-CONVENIO EQUAL 600139 */

                                    if (W.ANT_CONVENIO == 600139)
                                    {

                                        /*" -1026- WRITE REG-SAIDA07 FROM MOVCC-REGISTRO */
                                        _.Move(MOVCC_REGISTRO.GetMoveValues(), REG_SAIDA07);

                                        SAIDA07.Write(REG_SAIDA07.GetMoveValues().ToString());

                                        /*" -1027- ADD 1 TO AC-GRAV-SAIDA07 */
                                        W.AC_GRAV_SAIDA07.Value = W.AC_GRAV_SAIDA07 + 1;

                                        /*" -1028- ELSE */
                                    }
                                    else
                                    {


                                        /*" -1029- IF ANT-CONVENIO EQUAL 600140 */

                                        if (W.ANT_CONVENIO == 600140)
                                        {

                                            /*" -1030- WRITE REG-SAIDA08 FROM MOVCC-REGISTRO */
                                            _.Move(MOVCC_REGISTRO.GetMoveValues(), REG_SAIDA08);

                                            SAIDA08.Write(REG_SAIDA08.GetMoveValues().ToString());

                                            /*" -1031- ADD 1 TO AC-GRAV-SAIDA08 */
                                            W.AC_GRAV_SAIDA08.Value = W.AC_GRAV_SAIDA08 + 1;

                                            /*" -1032- ELSE */
                                        }
                                        else
                                        {


                                            /*" -1033- IF ANT-CONVENIO EQUAL 608800 */

                                            if (W.ANT_CONVENIO == 608800)
                                            {

                                                /*" -1034- WRITE REG-SAIDA09 FROM MOVCC-REGISTRO */
                                                _.Move(MOVCC_REGISTRO.GetMoveValues(), REG_SAIDA09);

                                                SAIDA09.Write(REG_SAIDA09.GetMoveValues().ToString());

                                                /*" -1035- ADD 1 TO AC-GRAV-SAIDA09 */
                                                W.AC_GRAV_SAIDA09.Value = W.AC_GRAV_SAIDA09 + 1;

                                                /*" -1036- ELSE */
                                            }
                                            else
                                            {


                                                /*" -1037- IF ANT-CONVENIO EQUAL 609000 */

                                                if (W.ANT_CONVENIO == 609000)
                                                {

                                                    /*" -1038- WRITE REG-SAIDA10 FROM MOVCC-REGISTRO */
                                                    _.Move(MOVCC_REGISTRO.GetMoveValues(), REG_SAIDA10);

                                                    SAIDA10.Write(REG_SAIDA10.GetMoveValues().ToString());

                                                    /*" -1039- ADD 1 TO AC-GRAV-SAIDA10 */
                                                    W.AC_GRAV_SAIDA10.Value = W.AC_GRAV_SAIDA10 + 1;

                                                    /*" -1040- ELSE */
                                                }
                                                else
                                                {


                                                    /*" -1041- IF ANT-CONVENIO EQUAL 613100 */

                                                    if (W.ANT_CONVENIO == 613100)
                                                    {

                                                        /*" -1042- WRITE REG-SAIDA11 FROM MOVCC-REGISTRO */
                                                        _.Move(MOVCC_REGISTRO.GetMoveValues(), REG_SAIDA11);

                                                        SAIDA11.Write(REG_SAIDA11.GetMoveValues().ToString());

                                                        /*" -1043- ADD 1 TO AC-GRAV-SAIDA11 */
                                                        W.AC_GRAV_SAIDA11.Value = W.AC_GRAV_SAIDA11 + 1;

                                                        /*" -1044- ELSE */
                                                    }
                                                    else
                                                    {


                                                        /*" -1045- IF ANT-CONVENIO EQUAL 613200 */

                                                        if (W.ANT_CONVENIO == 613200)
                                                        {

                                                            /*" -1046- WRITE REG-SAIDA12 FROM MOVCC-REGISTRO */
                                                            _.Move(MOVCC_REGISTRO.GetMoveValues(), REG_SAIDA12);

                                                            SAIDA12.Write(REG_SAIDA12.GetMoveValues().ToString());

                                                            /*" -1047- ADD 1 TO AC-GRAV-SAIDA12 */
                                                            W.AC_GRAV_SAIDA12.Value = W.AC_GRAV_SAIDA12 + 1;

                                                            /*" -1048- ELSE */
                                                        }
                                                        else
                                                        {


                                                            /*" -1049- IF ANT-CONVENIO EQUAL 900662 */

                                                            if (W.ANT_CONVENIO == 900662)
                                                            {

                                                                /*" -1050- WRITE REG-SAIDA13 FROM MOVCC-REGISTRO */
                                                                _.Move(MOVCC_REGISTRO.GetMoveValues(), REG_SAIDA13);

                                                                SAIDA13.Write(REG_SAIDA13.GetMoveValues().ToString());

                                                                /*" -1051- ADD 1 TO AC-GRAV-SAIDA13 */
                                                                W.AC_GRAV_SAIDA13.Value = W.AC_GRAV_SAIDA13 + 1;

                                                                /*" -1052- ELSE */
                                                            }
                                                            else
                                                            {


                                                                /*" -1053- IF ANT-CONVENIO EQUAL 600149 */

                                                                if (W.ANT_CONVENIO == 600149)
                                                                {

                                                                    /*" -1054- WRITE REG-SAIDA14 FROM MOVCC-REGISTRO */
                                                                    _.Move(MOVCC_REGISTRO.GetMoveValues(), REG_SAIDA14);

                                                                    SAIDA14.Write(REG_SAIDA14.GetMoveValues().ToString());

                                                                    /*" -1055- ADD 1 TO AC-GRAV-SAIDA14 */
                                                                    W.AC_GRAV_SAIDA14.Value = W.AC_GRAV_SAIDA14 + 1;

                                                                    /*" -1056- ELSE */
                                                                }
                                                                else
                                                                {


                                                                    /*" -1057- IF ANT-CONVENIO EQUAL 609500 */

                                                                    if (W.ANT_CONVENIO == 609500)
                                                                    {

                                                                        /*" -1058- MOVE MOVCC-REGISTRO TO MOVCC-REGISTRO2 */
                                                                        _.Move(MOVCC_REGISTRO, MOVCC_REGISTRO2);

                                                                        /*" -1059- MOVE SOR-IDLG TO MOVCC-IDLG2 */
                                                                        _.Move(REG_ARQSORT.SOR_IDLG, MOVCC_REGISTRO2.MOVCC_IDLG2);

                                                                        /*" -1060- MOVE SPACES TO FILLER2 */
                                                                        _.Move("", MOVCC_REGISTRO2.FILLER2);

                                                                        /*" -1061- WRITE REG-SAIDA15 FROM MOVCC-REGISTRO2 */
                                                                        _.Move(MOVCC_REGISTRO2.GetMoveValues(), REG_SAIDA15);

                                                                        SAIDA15.Write(REG_SAIDA15.GetMoveValues().ToString());

                                                                        /*" -1061- ADD 1 TO AC-GRAV-SAIDA15. */
                                                                        W.AC_GRAV_SAIDA15.Value = W.AC_GRAV_SAIDA15 + 1;
                                                                    }

                                                                }

                                                            }

                                                        }

                                                    }

                                                }

                                            }

                                        }

                                    }

                                }

                            }

                        }

                    }

                }

            }


            /*" -0- FLUXCONTROL_PERFORM R1000_90_LEITURA */

            R1000_90_LEITURA();

        }

        [StopWatch]
        /*" R1000-90-LEITURA */
        private void R1000_90_LEITURA(bool isPerform = false)
        {
            /*" -1065- PERFORM R0510-00-LE-ARQSORT. */

            R0510_00_LE_ARQSORT_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1100-00-GRAVA-HEADER-SECTION */
        private void R1100_00_GRAVA_HEADER_SECTION()
        {
            /*" -1077- MOVE '1100' TO WNR-EXEC-SQL. */
            _.Move("1100", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -1079- MOVE SPACES TO HEADER-REGISTRO. */
            _.Move("", HEADER_REGISTRO);

            /*" -1082- MOVE ZEROS TO WS-NRSEQ WS-VALOR-0 WS-VALOR-2. */
            _.Move(0, W.WS_NRSEQ, W.WS_VALOR_0, W.WS_VALOR_2);

            /*" -1084- MOVE 1 TO WS-TOTREG. */
            _.Move(1, W.WS_TOTREG);

            /*" -1086- MOVE 'A' TO HEADER-CODREGISTRO. */
            _.Move("A", HEADER_REGISTRO.HEADER_CODREGISTRO);

            /*" -1088- MOVE '2' TO HEADER-CODREMESSA. */
            _.Move("2", HEADER_REGISTRO.HEADER_CODREMESSA);

            /*" -1090- MOVE SOR-CONVENIO TO HEADER-CODCONVENIO. */
            _.Move(REG_ARQSORT.SOR_CONVENIO, HEADER_REGISTRO.HEADER_CODCONVENIO);

            /*" -1092- MOVE 'CAIXA SEGURADORA SA' TO HEADER-NOMEMPRESA. */
            _.Move("CAIXA SEGURADORA SA", HEADER_REGISTRO.HEADER_NOMEMPRESA);

            /*" -1094- MOVE SOR-CODBANCO TO HEADER-CODBANCO. */
            _.Move(REG_ARQSORT.SOR_CODBANCO, HEADER_REGISTRO.HEADER_CODBANCO);

            /*" -1096- MOVE 'CAIXA ECON. FEDERAL' TO HEADER-NOMBANCO. */
            _.Move("CAIXA ECON. FEDERAL", HEADER_REGISTRO.HEADER_NOMBANCO);

            /*" -1098- MOVE SOR-ANO-HEADER TO HEADER-ANO. */
            _.Move(REG_ARQSORT.SOR_DTGERACAO.SOR_ANO_HEADER, HEADER_REGISTRO.HEADER_DATGERACAO.HEADER_ANO);

            /*" -1100- MOVE SOR-MES-HEADER TO HEADER-MES. */
            _.Move(REG_ARQSORT.SOR_DTGERACAO.SOR_MES_HEADER, HEADER_REGISTRO.HEADER_DATGERACAO.HEADER_MES);

            /*" -1102- MOVE SOR-DIA-HEADER TO HEADER-DIA. */
            _.Move(REG_ARQSORT.SOR_DTGERACAO.SOR_DIA_HEADER, HEADER_REGISTRO.HEADER_DATGERACAO.HEADER_DIA);

            /*" -1105- MOVE SOR-NSAC TO HEADER-NSA WS9-NRO-NSAC. */
            _.Move(REG_ARQSORT.SOR_NSAC, HEADER_REGISTRO.HEADER_NSA, W.WS9_NRO_NSAC);

            /*" -1107- MOVE '04' TO HEADER-VERSAO. */
            _.Move("04", HEADER_REGISTRO.HEADER_VERSAO);

            /*" -1111- MOVE 'DEBITO AUTOMATICO' TO HEADER-DEBCREDAUT. */
            _.Move("DEBITO AUTOMATICO", HEADER_REGISTRO.HEADER_DEBCREDAUT);

            /*" -1112- IF ANT-CONVENIO EQUAL 600139 */

            if (W.ANT_CONVENIO == 600139)
            {

                /*" -1114- MOVE 0 TO WS9-NRO-NSAC HEADER-NSA */
                _.Move(0, W.WS9_NRO_NSAC, HEADER_REGISTRO.HEADER_NSA);

                /*" -1117- END-IF. */
            }


            /*" -1118- IF ANT-CONVENIO EQUAL 600114 */

            if (W.ANT_CONVENIO == 600114)
            {

                /*" -1121- MOVE 611400000 TO WSHOST-NRAVISO1 */
                _.Move(611400000, WSHOST_NRAVISO1);

                /*" -1122- MOVE 611409998 TO WSHOST-NRAVISO2 */
                _.Move(611409998, WSHOST_NRAVISO2);

                /*" -1124- MOVE 611480001 TO WSHOST-NRAVISO3 */
                _.Move(611480001, WSHOST_NRAVISO3);

                /*" -1125- MOVE 611489998 TO WSHOST-NRAVISO4 */
                _.Move(611489998, WSHOST_NRAVISO4);

                /*" -1126- PERFORM R1110-00-TRATA-NSAC */

                R1110_00_TRATA_NSAC_SECTION();

                /*" -1127- WRITE REG-SAIDA01 FROM HEADER-REGISTRO */
                _.Move(HEADER_REGISTRO.GetMoveValues(), REG_SAIDA01);

                SAIDA01.Write(REG_SAIDA01.GetMoveValues().ToString());

                /*" -1128- ADD 1 TO AC-GRAV-SAIDA01 */
                W.AC_GRAV_SAIDA01.Value = W.AC_GRAV_SAIDA01 + 1;

                /*" -1129- ELSE */
            }
            else
            {


                /*" -1130- IF ANT-CONVENIO EQUAL 600119 */

                if (W.ANT_CONVENIO == 600119)
                {

                    /*" -1131- MOVE 611900000 TO WSHOST-NRAVISO1 */
                    _.Move(611900000, WSHOST_NRAVISO1);

                    /*" -1132- MOVE 611980000 TO WSHOST-NRAVISO2 */
                    _.Move(611980000, WSHOST_NRAVISO2);

                    /*" -1133- MOVE 611980001 TO WSHOST-NRAVISO3 */
                    _.Move(611980001, WSHOST_NRAVISO3);

                    /*" -1134- MOVE 611989999 TO WSHOST-NRAVISO4 */
                    _.Move(611989999, WSHOST_NRAVISO4);

                    /*" -1135- PERFORM R1110-00-TRATA-NSAC */

                    R1110_00_TRATA_NSAC_SECTION();

                    /*" -1136- WRITE REG-SAIDA02 FROM HEADER-REGISTRO */
                    _.Move(HEADER_REGISTRO.GetMoveValues(), REG_SAIDA02);

                    SAIDA02.Write(REG_SAIDA02.GetMoveValues().ToString());

                    /*" -1137- ADD 1 TO AC-GRAV-SAIDA02 */
                    W.AC_GRAV_SAIDA02.Value = W.AC_GRAV_SAIDA02 + 1;

                    /*" -1138- ELSE */
                }
                else
                {


                    /*" -1139- IF ANT-CONVENIO EQUAL 600120 */

                    if (W.ANT_CONVENIO == 600120)
                    {

                        /*" -1140- MOVE 612000000 TO WSHOST-NRAVISO1 */
                        _.Move(612000000, WSHOST_NRAVISO1);

                        /*" -1141- MOVE 612080000 TO WSHOST-NRAVISO2 */
                        _.Move(612080000, WSHOST_NRAVISO2);

                        /*" -1142- MOVE 612080001 TO WSHOST-NRAVISO3 */
                        _.Move(612080001, WSHOST_NRAVISO3);

                        /*" -1143- MOVE 612089999 TO WSHOST-NRAVISO4 */
                        _.Move(612089999, WSHOST_NRAVISO4);

                        /*" -1144- PERFORM R1110-00-TRATA-NSAC */

                        R1110_00_TRATA_NSAC_SECTION();

                        /*" -1145- WRITE REG-SAIDA03 FROM HEADER-REGISTRO */
                        _.Move(HEADER_REGISTRO.GetMoveValues(), REG_SAIDA03);

                        SAIDA03.Write(REG_SAIDA03.GetMoveValues().ToString());

                        /*" -1146- ADD 1 TO AC-GRAV-SAIDA03 */
                        W.AC_GRAV_SAIDA03.Value = W.AC_GRAV_SAIDA03 + 1;

                        /*" -1147- ELSE */
                    }
                    else
                    {


                        /*" -1148- IF ANT-CONVENIO EQUAL 600121 */

                        if (W.ANT_CONVENIO == 600121)
                        {

                            /*" -1149- MOVE 912100000 TO WSHOST-NRAVISO1 */
                            _.Move(912100000, WSHOST_NRAVISO1);

                            /*" -1150- MOVE 912108999 TO WSHOST-NRAVISO2 */
                            _.Move(912108999, WSHOST_NRAVISO2);

                            /*" -1151- MOVE 912180000 TO WSHOST-NRAVISO3 */
                            _.Move(912180000, WSHOST_NRAVISO3);

                            /*" -1154- MOVE 912188999 TO WSHOST-NRAVISO4 */
                            _.Move(912188999, WSHOST_NRAVISO4);

                            /*" -1155- PERFORM R1110-00-TRATA-NSAC */

                            R1110_00_TRATA_NSAC_SECTION();

                            /*" -1156- WRITE REG-SAIDA04 FROM HEADER-REGISTRO */
                            _.Move(HEADER_REGISTRO.GetMoveValues(), REG_SAIDA04);

                            SAIDA04.Write(REG_SAIDA04.GetMoveValues().ToString());

                            /*" -1157- ADD 1 TO AC-GRAV-SAIDA04 */
                            W.AC_GRAV_SAIDA04.Value = W.AC_GRAV_SAIDA04 + 1;

                            /*" -1158- ELSE */
                        }
                        else
                        {


                            /*" -1159- IF ANT-CONVENIO EQUAL 600123 */

                            if (W.ANT_CONVENIO == 600123)
                            {

                                /*" -1160- MOVE 612300000 TO WSHOST-NRAVISO1 */
                                _.Move(612300000, WSHOST_NRAVISO1);

                                /*" -1161- MOVE 612380000 TO WSHOST-NRAVISO2 */
                                _.Move(612380000, WSHOST_NRAVISO2);

                                /*" -1162- MOVE 612380001 TO WSHOST-NRAVISO3 */
                                _.Move(612380001, WSHOST_NRAVISO3);

                                /*" -1163- MOVE 612389999 TO WSHOST-NRAVISO4 */
                                _.Move(612389999, WSHOST_NRAVISO4);

                                /*" -1164- PERFORM R1110-00-TRATA-NSAC */

                                R1110_00_TRATA_NSAC_SECTION();

                                /*" -1165- WRITE REG-SAIDA05 FROM HEADER-REGISTRO */
                                _.Move(HEADER_REGISTRO.GetMoveValues(), REG_SAIDA05);

                                SAIDA05.Write(REG_SAIDA05.GetMoveValues().ToString());

                                /*" -1166- ADD 1 TO AC-GRAV-SAIDA05 */
                                W.AC_GRAV_SAIDA05.Value = W.AC_GRAV_SAIDA05 + 1;

                                /*" -1167- ELSE */
                            }
                            else
                            {


                                /*" -1168- IF ANT-CONVENIO EQUAL 600128 */

                                if (W.ANT_CONVENIO == 600128)
                                {

                                    /*" -1169- MOVE 612800000 TO WSHOST-NRAVISO1 */
                                    _.Move(612800000, WSHOST_NRAVISO1);

                                    /*" -1170- MOVE 612880000 TO WSHOST-NRAVISO2 */
                                    _.Move(612880000, WSHOST_NRAVISO2);

                                    /*" -1171- MOVE 612880001 TO WSHOST-NRAVISO3 */
                                    _.Move(612880001, WSHOST_NRAVISO3);

                                    /*" -1172- MOVE 612889999 TO WSHOST-NRAVISO4 */
                                    _.Move(612889999, WSHOST_NRAVISO4);

                                    /*" -1173- PERFORM R1110-00-TRATA-NSAC */

                                    R1110_00_TRATA_NSAC_SECTION();

                                    /*" -1174- WRITE REG-SAIDA06 FROM HEADER-REGISTRO */
                                    _.Move(HEADER_REGISTRO.GetMoveValues(), REG_SAIDA06);

                                    SAIDA06.Write(REG_SAIDA06.GetMoveValues().ToString());

                                    /*" -1175- ADD 1 TO AC-GRAV-SAIDA06 */
                                    W.AC_GRAV_SAIDA06.Value = W.AC_GRAV_SAIDA06 + 1;

                                    /*" -1176- ELSE */
                                }
                                else
                                {


                                    /*" -1177- IF ANT-CONVENIO EQUAL 600139 */

                                    if (W.ANT_CONVENIO == 600139)
                                    {

                                        /*" -1180- MOVE 613900000 TO WSHOST-NRAVISO1 */
                                        _.Move(613900000, WSHOST_NRAVISO1);

                                        /*" -1181- MOVE 613909997 TO WSHOST-NRAVISO2 */
                                        _.Move(613909997, WSHOST_NRAVISO2);

                                        /*" -1182- MOVE 613980001 TO WSHOST-NRAVISO3 */
                                        _.Move(613980001, WSHOST_NRAVISO3);

                                        /*" -1183- MOVE 613989999 TO WSHOST-NRAVISO4 */
                                        _.Move(613989999, WSHOST_NRAVISO4);

                                        /*" -1184- PERFORM R1110-00-TRATA-NSAC */

                                        R1110_00_TRATA_NSAC_SECTION();

                                        /*" -1185- WRITE REG-SAIDA07 FROM HEADER-REGISTRO */
                                        _.Move(HEADER_REGISTRO.GetMoveValues(), REG_SAIDA07);

                                        SAIDA07.Write(REG_SAIDA07.GetMoveValues().ToString());

                                        /*" -1186- ADD 1 TO AC-GRAV-SAIDA07 */
                                        W.AC_GRAV_SAIDA07.Value = W.AC_GRAV_SAIDA07 + 1;

                                        /*" -1187- ELSE */
                                    }
                                    else
                                    {


                                        /*" -1188- IF ANT-CONVENIO EQUAL 600140 */

                                        if (W.ANT_CONVENIO == 600140)
                                        {

                                            /*" -1189- MOVE 614000000 TO WSHOST-NRAVISO1 */
                                            _.Move(614000000, WSHOST_NRAVISO1);

                                            /*" -1190- MOVE 614080000 TO WSHOST-NRAVISO2 */
                                            _.Move(614080000, WSHOST_NRAVISO2);

                                            /*" -1191- MOVE 614080001 TO WSHOST-NRAVISO3 */
                                            _.Move(614080001, WSHOST_NRAVISO3);

                                            /*" -1192- MOVE 614089999 TO WSHOST-NRAVISO4 */
                                            _.Move(614089999, WSHOST_NRAVISO4);

                                            /*" -1193- PERFORM R1110-00-TRATA-NSAC */

                                            R1110_00_TRATA_NSAC_SECTION();

                                            /*" -1194- WRITE REG-SAIDA08 FROM HEADER-REGISTRO */
                                            _.Move(HEADER_REGISTRO.GetMoveValues(), REG_SAIDA08);

                                            SAIDA08.Write(REG_SAIDA08.GetMoveValues().ToString());

                                            /*" -1195- ADD 1 TO AC-GRAV-SAIDA08 */
                                            W.AC_GRAV_SAIDA08.Value = W.AC_GRAV_SAIDA08 + 1;

                                            /*" -1196- ELSE */
                                        }
                                        else
                                        {


                                            /*" -1197- IF ANT-CONVENIO EQUAL 608800 */

                                            if (W.ANT_CONVENIO == 608800)
                                            {

                                                /*" -1198- MOVE 608800000 TO WSHOST-NRAVISO1 */
                                                _.Move(608800000, WSHOST_NRAVISO1);

                                                /*" -1199- MOVE 608880000 TO WSHOST-NRAVISO2 */
                                                _.Move(608880000, WSHOST_NRAVISO2);

                                                /*" -1200- MOVE 608880001 TO WSHOST-NRAVISO3 */
                                                _.Move(608880001, WSHOST_NRAVISO3);

                                                /*" -1201- MOVE 608889999 TO WSHOST-NRAVISO4 */
                                                _.Move(608889999, WSHOST_NRAVISO4);

                                                /*" -1202- PERFORM R1110-00-TRATA-NSAC */

                                                R1110_00_TRATA_NSAC_SECTION();

                                                /*" -1203- WRITE REG-SAIDA09 FROM HEADER-REGISTRO */
                                                _.Move(HEADER_REGISTRO.GetMoveValues(), REG_SAIDA09);

                                                SAIDA09.Write(REG_SAIDA09.GetMoveValues().ToString());

                                                /*" -1204- ADD 1 TO AC-GRAV-SAIDA09 */
                                                W.AC_GRAV_SAIDA09.Value = W.AC_GRAV_SAIDA09 + 1;

                                                /*" -1205- ELSE */
                                            }
                                            else
                                            {


                                                /*" -1206- IF ANT-CONVENIO EQUAL 609000 */

                                                if (W.ANT_CONVENIO == 609000)
                                                {

                                                    /*" -1207- MOVE 609000000 TO WSHOST-NRAVISO1 */
                                                    _.Move(609000000, WSHOST_NRAVISO1);

                                                    /*" -1208- MOVE 609080000 TO WSHOST-NRAVISO2 */
                                                    _.Move(609080000, WSHOST_NRAVISO2);

                                                    /*" -1209- MOVE 609080001 TO WSHOST-NRAVISO3 */
                                                    _.Move(609080001, WSHOST_NRAVISO3);

                                                    /*" -1210- MOVE 609089999 TO WSHOST-NRAVISO4 */
                                                    _.Move(609089999, WSHOST_NRAVISO4);

                                                    /*" -1211- PERFORM R1110-00-TRATA-NSAC */

                                                    R1110_00_TRATA_NSAC_SECTION();

                                                    /*" -1212- WRITE REG-SAIDA10 FROM HEADER-REGISTRO */
                                                    _.Move(HEADER_REGISTRO.GetMoveValues(), REG_SAIDA10);

                                                    SAIDA10.Write(REG_SAIDA10.GetMoveValues().ToString());

                                                    /*" -1213- ADD 1 TO AC-GRAV-SAIDA10 */
                                                    W.AC_GRAV_SAIDA10.Value = W.AC_GRAV_SAIDA10 + 1;

                                                    /*" -1214- ELSE */
                                                }
                                                else
                                                {


                                                    /*" -1215- IF ANT-CONVENIO EQUAL 613100 */

                                                    if (W.ANT_CONVENIO == 613100)
                                                    {

                                                        /*" -1216- MOVE 613100000 TO WSHOST-NRAVISO1 */
                                                        _.Move(613100000, WSHOST_NRAVISO1);

                                                        /*" -1217- MOVE 613180000 TO WSHOST-NRAVISO2 */
                                                        _.Move(613180000, WSHOST_NRAVISO2);

                                                        /*" -1218- MOVE 613180001 TO WSHOST-NRAVISO3 */
                                                        _.Move(613180001, WSHOST_NRAVISO3);

                                                        /*" -1219- MOVE 613189999 TO WSHOST-NRAVISO4 */
                                                        _.Move(613189999, WSHOST_NRAVISO4);

                                                        /*" -1220- PERFORM R1110-00-TRATA-NSAC */

                                                        R1110_00_TRATA_NSAC_SECTION();

                                                        /*" -1221- WRITE REG-SAIDA11 FROM HEADER-REGISTRO */
                                                        _.Move(HEADER_REGISTRO.GetMoveValues(), REG_SAIDA11);

                                                        SAIDA11.Write(REG_SAIDA11.GetMoveValues().ToString());

                                                        /*" -1222- ADD 1 TO AC-GRAV-SAIDA11 */
                                                        W.AC_GRAV_SAIDA11.Value = W.AC_GRAV_SAIDA11 + 1;

                                                        /*" -1223- ELSE */
                                                    }
                                                    else
                                                    {


                                                        /*" -1224- IF ANT-CONVENIO EQUAL 613200 */

                                                        if (W.ANT_CONVENIO == 613200)
                                                        {

                                                            /*" -1225- MOVE 613200000 TO WSHOST-NRAVISO1 */
                                                            _.Move(613200000, WSHOST_NRAVISO1);

                                                            /*" -1226- MOVE 613280000 TO WSHOST-NRAVISO2 */
                                                            _.Move(613280000, WSHOST_NRAVISO2);

                                                            /*" -1227- MOVE 613280001 TO WSHOST-NRAVISO3 */
                                                            _.Move(613280001, WSHOST_NRAVISO3);

                                                            /*" -1228- MOVE 613289999 TO WSHOST-NRAVISO4 */
                                                            _.Move(613289999, WSHOST_NRAVISO4);

                                                            /*" -1229- PERFORM R1110-00-TRATA-NSAC */

                                                            R1110_00_TRATA_NSAC_SECTION();

                                                            /*" -1230- WRITE REG-SAIDA12 FROM HEADER-REGISTRO */
                                                            _.Move(HEADER_REGISTRO.GetMoveValues(), REG_SAIDA12);

                                                            SAIDA12.Write(REG_SAIDA12.GetMoveValues().ToString());

                                                            /*" -1231- ADD 1 TO AC-GRAV-SAIDA12 */
                                                            W.AC_GRAV_SAIDA12.Value = W.AC_GRAV_SAIDA12 + 1;

                                                            /*" -1232- ELSE */
                                                        }
                                                        else
                                                        {


                                                            /*" -1233- IF ANT-CONVENIO EQUAL 900662 */

                                                            if (W.ANT_CONVENIO == 900662)
                                                            {

                                                                /*" -1234- MOVE 966200000 TO WSHOST-NRAVISO1 */
                                                                _.Move(966200000, WSHOST_NRAVISO1);

                                                                /*" -1235- MOVE 966280000 TO WSHOST-NRAVISO2 */
                                                                _.Move(966280000, WSHOST_NRAVISO2);

                                                                /*" -1236- MOVE 966280001 TO WSHOST-NRAVISO3 */
                                                                _.Move(966280001, WSHOST_NRAVISO3);

                                                                /*" -1237- MOVE 966289999 TO WSHOST-NRAVISO4 */
                                                                _.Move(966289999, WSHOST_NRAVISO4);

                                                                /*" -1238- PERFORM R1110-00-TRATA-NSAC */

                                                                R1110_00_TRATA_NSAC_SECTION();

                                                                /*" -1239- WRITE REG-SAIDA13 FROM HEADER-REGISTRO */
                                                                _.Move(HEADER_REGISTRO.GetMoveValues(), REG_SAIDA13);

                                                                SAIDA13.Write(REG_SAIDA13.GetMoveValues().ToString());

                                                                /*" -1240- ADD 1 TO AC-GRAV-SAIDA13 */
                                                                W.AC_GRAV_SAIDA13.Value = W.AC_GRAV_SAIDA13 + 1;

                                                                /*" -1241- ELSE */
                                                            }
                                                            else
                                                            {


                                                                /*" -1242- IF ANT-CONVENIO EQUAL 600149 */

                                                                if (W.ANT_CONVENIO == 600149)
                                                                {

                                                                    /*" -1243- MOVE 914900000 TO WSHOST-NRAVISO1 */
                                                                    _.Move(914900000, WSHOST_NRAVISO1);

                                                                    /*" -1244- MOVE 914980000 TO WSHOST-NRAVISO2 */
                                                                    _.Move(914980000, WSHOST_NRAVISO2);

                                                                    /*" -1245- MOVE 914900001 TO WSHOST-NRAVISO3 */
                                                                    _.Move(914900001, WSHOST_NRAVISO3);

                                                                    /*" -1246- MOVE 914989999 TO WSHOST-NRAVISO4 */
                                                                    _.Move(914989999, WSHOST_NRAVISO4);

                                                                    /*" -1247- PERFORM R1110-00-TRATA-NSAC */

                                                                    R1110_00_TRATA_NSAC_SECTION();

                                                                    /*" -1248- WRITE REG-SAIDA14 FROM HEADER-REGISTRO */
                                                                    _.Move(HEADER_REGISTRO.GetMoveValues(), REG_SAIDA14);

                                                                    SAIDA14.Write(REG_SAIDA14.GetMoveValues().ToString());

                                                                    /*" -1248- ADD 1 TO AC-GRAV-SAIDA14. */
                                                                    W.AC_GRAV_SAIDA14.Value = W.AC_GRAV_SAIDA14 + 1;
                                                                }

                                                            }

                                                        }

                                                    }

                                                }

                                            }

                                        }

                                    }

                                }

                            }

                        }

                    }

                }

            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/

        [StopWatch]
        /*" R1110-00-TRATA-NSAC-SECTION */
        private void R1110_00_TRATA_NSAC_SECTION()
        {
            /*" -1261- MOVE '1110' TO WNR-EXEC-SQL. */
            _.Move("1110", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -1263- PERFORM R1150-00-SELECT-AVISOCRE. */

            R1150_00_SELECT_AVISOCRE_SECTION();

            /*" -1266- MOVE AVISOCRE-NUM-AVISO-CREDITO TO WS0-NRAVISO. */
            _.Move(AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_NUM_AVISO_CREDITO, W.WS0_NRAVISO);

            /*" -1268- PERFORM R1160-00-SELECT-AVISOCRE. */

            R1160_00_SELECT_AVISOCRE_SECTION();

            /*" -1272- MOVE AVISOCRE-NUM-AVISO-CREDITO TO WS2-NRAVISO. */
            _.Move(AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_NUM_AVISO_CREDITO, W.WS2_NRAVISO);

            /*" -1273- IF WS0-NRO-NSAC GREATER WS2-NRO-NSAC */

            if (W.FILLER_7.WS0_NRO_NSAC > W.FILLER_8.WS2_NRO_NSAC)
            {

                /*" -1274- IF WS0-NRO-NSAC GREATER WS9-NRO-NSAC */

                if (W.FILLER_7.WS0_NRO_NSAC > W.WS9_NRO_NSAC)
                {

                    /*" -1275- MOVE WS0-NRO-NSAC TO HEADER-NSA */
                    _.Move(W.FILLER_7.WS0_NRO_NSAC, HEADER_REGISTRO.HEADER_NSA);

                    /*" -1276- ELSE */
                }
                else
                {


                    /*" -1277- MOVE WS9-NRO-NSAC TO HEADER-NSA */
                    _.Move(W.WS9_NRO_NSAC, HEADER_REGISTRO.HEADER_NSA);

                    /*" -1278- ELSE */
                }

            }
            else
            {


                /*" -1279- IF WS2-NRO-NSAC GREATER WS9-NRO-NSAC */

                if (W.FILLER_8.WS2_NRO_NSAC > W.WS9_NRO_NSAC)
                {

                    /*" -1280- MOVE WS2-NRO-NSAC TO HEADER-NSA */
                    _.Move(W.FILLER_8.WS2_NRO_NSAC, HEADER_REGISTRO.HEADER_NSA);

                    /*" -1281- ELSE */
                }
                else
                {


                    /*" -1284- MOVE WS9-NRO-NSAC TO HEADER-NSA. */
                    _.Move(W.WS9_NRO_NSAC, HEADER_REGISTRO.HEADER_NSA);
                }

            }


            /*" -1285- IF ANT-CONVENIO EQUAL 600121 */

            if (W.ANT_CONVENIO == 600121)
            {

                /*" -1286- MOVE 712100000 TO WSHOST-NRAVISO1 */
                _.Move(712100000, WSHOST_NRAVISO1);

                /*" -1287- MOVE 712180000 TO WSHOST-NRAVISO2 */
                _.Move(712180000, WSHOST_NRAVISO2);

                /*" -1288- PERFORM R1170-00-TRATA-NSAC */

                R1170_00_TRATA_NSAC_SECTION();

                /*" -1290- GO TO R1110-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1110_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1291- IF ANT-CONVENIO EQUAL 600149 */

            if (W.ANT_CONVENIO == 600149)
            {

                /*" -1292- MOVE 714900000 TO WSHOST-NRAVISO1 */
                _.Move(714900000, WSHOST_NRAVISO1);

                /*" -1293- MOVE 714980000 TO WSHOST-NRAVISO2 */
                _.Move(714980000, WSHOST_NRAVISO2);

                /*" -1294- PERFORM R1170-00-TRATA-NSAC */

                R1170_00_TRATA_NSAC_SECTION();

                /*" -1297- GO TO R1110-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1110_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1298- IF ANT-CONVENIO EQUAL 608800 */

            if (W.ANT_CONVENIO == 608800)
            {

                /*" -1300- COMPUTE CONFITCE-NSAC EQUAL (WS-NSAC + 23000) */
                CONFITCE.DCLCONTROLE_FITAS_CEF.CONFITCE_NSAC.Value = (HEADER_REGISTRO.FILLER_17.WS_NSAC + 23000);

                /*" -1301- ELSE */
            }
            else
            {


                /*" -1302- IF ANT-CONVENIO EQUAL 609000 */

                if (W.ANT_CONVENIO == 609000)
                {

                    /*" -1304- COMPUTE CONFITCE-NSAC EQUAL (WS-NSAC + 21000) */
                    CONFITCE.DCLCONTROLE_FITAS_CEF.CONFITCE_NSAC.Value = (HEADER_REGISTRO.FILLER_17.WS_NSAC + 21000);

                    /*" -1305- ELSE */
                }
                else
                {


                    /*" -1306- IF ANT-CONVENIO EQUAL 613100 */

                    if (W.ANT_CONVENIO == 613100)
                    {

                        /*" -1308- COMPUTE CONFITCE-NSAC EQUAL (WS-NSAC + 29000) */
                        CONFITCE.DCLCONTROLE_FITAS_CEF.CONFITCE_NSAC.Value = (HEADER_REGISTRO.FILLER_17.WS_NSAC + 29000);

                        /*" -1309- ELSE */
                    }
                    else
                    {


                        /*" -1310- IF ANT-CONVENIO EQUAL 613200 */

                        if (W.ANT_CONVENIO == 613200)
                        {

                            /*" -1312- COMPUTE CONFITCE-NSAC EQUAL (WS-NSAC + 28000) */
                            CONFITCE.DCLCONTROLE_FITAS_CEF.CONFITCE_NSAC.Value = (HEADER_REGISTRO.FILLER_17.WS_NSAC + 28000);

                            /*" -1313- ELSE */
                        }
                        else
                        {


                            /*" -1316- GO TO R1110-99-SAIDA. */
                            /*Método Suprimido por falta de linha ou apenas EXIT nome: R1110_99_SAIDA*/ //GOTO
                            return;
                        }

                    }

                }

            }


            /*" -1318- MOVE CONFITCE-NSAC TO WS3-NSAC. */
            _.Move(CONFITCE.DCLCONTROLE_FITAS_CEF.CONFITCE_NSAC, W.WS3_NSAC);

            /*" -1318- PERFORM R1180-00-TRATA-FITACEF. */

            R1180_00_TRATA_FITACEF_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1110_99_SAIDA*/

        [StopWatch]
        /*" R1150-00-SELECT-AVISOCRE-SECTION */
        private void R1150_00_SELECT_AVISOCRE_SECTION()
        {
            /*" -1331- MOVE '1150' TO WNR-EXEC-SQL. */
            _.Move("1150", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -1339- PERFORM R1150_00_SELECT_AVISOCRE_DB_SELECT_1 */

            R1150_00_SELECT_AVISOCRE_DB_SELECT_1();

            /*" -1343- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1344- DISPLAY 'R1150-00 - PROBLEMAS NO SELECT(AVISOCRE)' */
                _.Display($"R1150-00 - PROBLEMAS NO SELECT(AVISOCRE)");

                /*" -1347- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1348- ADD 1 TO AVISOCRE-NUM-AVISO-CREDITO. */
            AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_NUM_AVISO_CREDITO.Value = AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_NUM_AVISO_CREDITO + 1;

        }

        [StopWatch]
        /*" R1150-00-SELECT-AVISOCRE-DB-SELECT-1 */
        public void R1150_00_SELECT_AVISOCRE_DB_SELECT_1()
        {
            /*" -1339- EXEC SQL SELECT VALUE(MAX(NUM_AVISO_CREDITO),0) INTO :AVISOCRE-NUM-AVISO-CREDITO FROM SEGUROS.AVISO_CREDITO WHERE NUM_AVISO_CREDITO BETWEEN :WSHOST-NRAVISO1 AND :WSHOST-NRAVISO2 WITH UR END-EXEC. */

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
        /*" R1160-00-SELECT-AVISOCRE-SECTION */
        private void R1160_00_SELECT_AVISOCRE_SECTION()
        {
            /*" -1361- MOVE '1160' TO WNR-EXEC-SQL. */
            _.Move("1160", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -1369- PERFORM R1160_00_SELECT_AVISOCRE_DB_SELECT_1 */

            R1160_00_SELECT_AVISOCRE_DB_SELECT_1();

            /*" -1373- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1374- DISPLAY 'R1160-00 - PROBLEMAS NO SELECT(AVISOCRE)' */
                _.Display($"R1160-00 - PROBLEMAS NO SELECT(AVISOCRE)");

                /*" -1377- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1378- ADD 1 TO AVISOCRE-NUM-AVISO-CREDITO. */
            AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_NUM_AVISO_CREDITO.Value = AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_NUM_AVISO_CREDITO + 1;

        }

        [StopWatch]
        /*" R1160-00-SELECT-AVISOCRE-DB-SELECT-1 */
        public void R1160_00_SELECT_AVISOCRE_DB_SELECT_1()
        {
            /*" -1369- EXEC SQL SELECT VALUE(MAX(NUM_AVISO_CREDITO),0) INTO :AVISOCRE-NUM-AVISO-CREDITO FROM SEGUROS.AVISO_CREDITO WHERE NUM_AVISO_CREDITO BETWEEN :WSHOST-NRAVISO3 AND :WSHOST-NRAVISO4 WITH UR END-EXEC. */

            var r1160_00_SELECT_AVISOCRE_DB_SELECT_1_Query1 = new R1160_00_SELECT_AVISOCRE_DB_SELECT_1_Query1()
            {
                WSHOST_NRAVISO3 = WSHOST_NRAVISO3.ToString(),
                WSHOST_NRAVISO4 = WSHOST_NRAVISO4.ToString(),
            };

            var executed_1 = R1160_00_SELECT_AVISOCRE_DB_SELECT_1_Query1.Execute(r1160_00_SELECT_AVISOCRE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.AVISOCRE_NUM_AVISO_CREDITO, AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_NUM_AVISO_CREDITO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1160_99_SAIDA*/

        [StopWatch]
        /*" R1170-00-TRATA-NSAC-SECTION */
        private void R1170_00_TRATA_NSAC_SECTION()
        {
            /*" -1391- MOVE '1170' TO WNR-EXEC-SQL. */
            _.Move("1170", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -1393- PERFORM R1150-00-SELECT-AVISOCRE. */

            R1150_00_SELECT_AVISOCRE_SECTION();

            /*" -1396- MOVE AVISOCRE-NUM-AVISO-CREDITO TO WS0-NRAVISO. */
            _.Move(AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_NUM_AVISO_CREDITO, W.WS0_NRAVISO);

            /*" -1400- MOVE HEADER-NSA TO WS2-NRO-NSAC. */
            _.Move(HEADER_REGISTRO.HEADER_NSA, W.FILLER_8.WS2_NRO_NSAC);

            /*" -1401- IF WS0-NRO-NSAC GREATER WS2-NRO-NSAC */

            if (W.FILLER_7.WS0_NRO_NSAC > W.FILLER_8.WS2_NRO_NSAC)
            {

                /*" -1402- MOVE WS0-NRO-NSAC TO HEADER-NSA */
                _.Move(W.FILLER_7.WS0_NRO_NSAC, HEADER_REGISTRO.HEADER_NSA);

                /*" -1403- ELSE */
            }
            else
            {


                /*" -1403- MOVE WS2-NRO-NSAC TO HEADER-NSA. */
                _.Move(W.FILLER_8.WS2_NRO_NSAC, HEADER_REGISTRO.HEADER_NSA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1170_99_SAIDA*/

        [StopWatch]
        /*" R1180-00-TRATA-FITACEF-SECTION */
        private void R1180_00_TRATA_FITACEF_SECTION()
        {
            /*" -1416- MOVE '1180' TO WNR-EXEC-SQL. */
            _.Move("1180", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -1418- MOVE SPACES TO WFIM-CONFITCE. */
            _.Move("", W.WFIM_CONFITCE);

            /*" -1422- PERFORM R1190-00-SELECT-CONFITCE UNTIL WFIM-CONFITCE NOT EQUAL SPACES. */

            while (!(!W.WFIM_CONFITCE.IsEmpty()))
            {

                R1190_00_SELECT_CONFITCE_SECTION();
            }

            /*" -1423- IF ANT-CONVENIO EQUAL 608800 */

            if (W.ANT_CONVENIO == 608800)
            {

                /*" -1425- COMPUTE WS3-NSAC EQUAL (WS3-NSAC - 23000) */
                W.WS3_NSAC.Value = (W.WS3_NSAC - 23000);

                /*" -1426- ELSE */
            }
            else
            {


                /*" -1427- IF ANT-CONVENIO EQUAL 609000 */

                if (W.ANT_CONVENIO == 609000)
                {

                    /*" -1429- COMPUTE WS3-NSAC EQUAL (WS3-NSAC - 21000) */
                    W.WS3_NSAC.Value = (W.WS3_NSAC - 21000);

                    /*" -1430- ELSE */
                }
                else
                {


                    /*" -1431- IF ANT-CONVENIO EQUAL 613100 */

                    if (W.ANT_CONVENIO == 613100)
                    {

                        /*" -1433- COMPUTE WS3-NSAC EQUAL (WS3-NSAC - 29000) */
                        W.WS3_NSAC.Value = (W.WS3_NSAC - 29000);

                        /*" -1434- ELSE */
                    }
                    else
                    {


                        /*" -1435- IF ANT-CONVENIO EQUAL 613200 */

                        if (W.ANT_CONVENIO == 613200)
                        {

                            /*" -1437- COMPUTE WS3-NSAC EQUAL (WS3-NSAC - 28000) */
                            W.WS3_NSAC.Value = (W.WS3_NSAC - 28000);

                            /*" -1438- ELSE */
                        }
                        else
                        {


                            /*" -1441- GO TO R1180-99-SAIDA. */
                            /*Método Suprimido por falta de linha ou apenas EXIT nome: R1180_99_SAIDA*/ //GOTO
                            return;
                        }

                    }

                }

            }


            /*" -1442- IF WS3-NRO-NSAC GREATER WS-NSAC */

            if (W.FILLER_9.WS3_NRO_NSAC > HEADER_REGISTRO.FILLER_17.WS_NSAC)
            {

                /*" -1442- MOVE WS3-NRO-NSAC TO WS-NSAC. */
                _.Move(W.FILLER_9.WS3_NRO_NSAC, HEADER_REGISTRO.FILLER_17.WS_NSAC);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1180_99_SAIDA*/

        [StopWatch]
        /*" R1190-00-SELECT-CONFITCE-SECTION */
        private void R1190_00_SELECT_CONFITCE_SECTION()
        {
            /*" -1455- MOVE '1190' TO WNR-EXEC-SQL. */
            _.Move("1190", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -1462- PERFORM R1190_00_SELECT_CONFITCE_DB_SELECT_1 */

            R1190_00_SELECT_CONFITCE_DB_SELECT_1();

            /*" -1466- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -1468- ADD 1 TO CONFITCE-NSAC */
                CONFITCE.DCLCONTROLE_FITAS_CEF.CONFITCE_NSAC.Value = CONFITCE.DCLCONTROLE_FITAS_CEF.CONFITCE_NSAC + 1;

                /*" -1469- MOVE CONFITCE-NSAC TO WS3-NSAC */
                _.Move(CONFITCE.DCLCONTROLE_FITAS_CEF.CONFITCE_NSAC, W.WS3_NSAC);

                /*" -1470- ELSE */
            }
            else
            {


                /*" -1471- MOVE 'S' TO WFIM-CONFITCE */
                _.Move("S", W.WFIM_CONFITCE);

                /*" -1472- IF SQLCODE NOT EQUAL 100 */

                if (DB.SQLCODE != 100)
                {

                    /*" -1473- DISPLAY 'R1190-00 - PROBLEMAS NO SELECT(CONFITCE)' */
                    _.Display($"R1190-00 - PROBLEMAS NO SELECT(CONFITCE)");

                    /*" -1473- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R1190-00-SELECT-CONFITCE-DB-SELECT-1 */
        public void R1190_00_SELECT_CONFITCE_DB_SELECT_1()
        {
            /*" -1462- EXEC SQL SELECT NSAC INTO :CONFITCE-NSAC FROM SEGUROS.CONTROLE_FITAS_CEF WHERE NSAC = :CONFITCE-NSAC AND DATA_GERACAO > :V1SIST-DTCURRENT-18 WITH UR END-EXEC. */

            var r1190_00_SELECT_CONFITCE_DB_SELECT_1_Query1 = new R1190_00_SELECT_CONFITCE_DB_SELECT_1_Query1()
            {
                V1SIST_DTCURRENT_18 = V1SIST_DTCURRENT_18.ToString(),
                CONFITCE_NSAC = CONFITCE.DCLCONTROLE_FITAS_CEF.CONFITCE_NSAC.ToString(),
            };

            var executed_1 = R1190_00_SELECT_CONFITCE_DB_SELECT_1_Query1.Execute(r1190_00_SELECT_CONFITCE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CONFITCE_NSAC, CONFITCE.DCLCONTROLE_FITAS_CEF.CONFITCE_NSAC);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1190_99_SAIDA*/

        [StopWatch]
        /*" R1200-00-GRAVA-TRAILLER-SECTION */
        private void R1200_00_GRAVA_TRAILLER_SECTION()
        {
            /*" -1486- MOVE '1200' TO WNR-EXEC-SQL. */
            _.Move("1200", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -1488- MOVE SPACES TO TRAILL-REGISTRO. */
            _.Move("", TRAILL_REGISTRO);

            /*" -1491- MOVE 'Z' TO TRAILL-CODREGISTRO. */
            _.Move("Z", TRAILL_REGISTRO.TRAILL_CODREGISTRO);

            /*" -1492- ADD 1 TO WS-TOTREG. */
            W.WS_TOTREG.Value = W.WS_TOTREG + 1;

            /*" -1495- MOVE WS-TOTREG TO TRAILL-TOTREGISTRO. */
            _.Move(W.WS_TOTREG, TRAILL_REGISTRO.TRAILL_TOTREGISTRO);

            /*" -1498- MOVE WS-VALOR-0 TO TRAILL-VLRTOTDEB. */
            _.Move(W.WS_VALOR_0, TRAILL_REGISTRO.TRAILL_VLRTOTDEB);

            /*" -1502- MOVE WS-VALOR-2 TO TRAILL-VLRTOTCRE. */
            _.Move(W.WS_VALOR_2, TRAILL_REGISTRO.TRAILL_VLRTOTCRE);

            /*" -1503- IF ANT-CONVENIO EQUAL 600114 */

            if (W.ANT_CONVENIO == 600114)
            {

                /*" -1504- WRITE REG-SAIDA01 FROM TRAILL-REGISTRO */
                _.Move(TRAILL_REGISTRO.GetMoveValues(), REG_SAIDA01);

                SAIDA01.Write(REG_SAIDA01.GetMoveValues().ToString());

                /*" -1505- ADD 1 TO AC-GRAV-SAIDA01 */
                W.AC_GRAV_SAIDA01.Value = W.AC_GRAV_SAIDA01 + 1;

                /*" -1506- ELSE */
            }
            else
            {


                /*" -1507- IF ANT-CONVENIO EQUAL 600119 */

                if (W.ANT_CONVENIO == 600119)
                {

                    /*" -1508- WRITE REG-SAIDA02 FROM TRAILL-REGISTRO */
                    _.Move(TRAILL_REGISTRO.GetMoveValues(), REG_SAIDA02);

                    SAIDA02.Write(REG_SAIDA02.GetMoveValues().ToString());

                    /*" -1509- ADD 1 TO AC-GRAV-SAIDA02 */
                    W.AC_GRAV_SAIDA02.Value = W.AC_GRAV_SAIDA02 + 1;

                    /*" -1510- ELSE */
                }
                else
                {


                    /*" -1511- IF ANT-CONVENIO EQUAL 600120 */

                    if (W.ANT_CONVENIO == 600120)
                    {

                        /*" -1512- WRITE REG-SAIDA03 FROM TRAILL-REGISTRO */
                        _.Move(TRAILL_REGISTRO.GetMoveValues(), REG_SAIDA03);

                        SAIDA03.Write(REG_SAIDA03.GetMoveValues().ToString());

                        /*" -1513- ADD 1 TO AC-GRAV-SAIDA03 */
                        W.AC_GRAV_SAIDA03.Value = W.AC_GRAV_SAIDA03 + 1;

                        /*" -1514- ELSE */
                    }
                    else
                    {


                        /*" -1515- IF ANT-CONVENIO EQUAL 600121 */

                        if (W.ANT_CONVENIO == 600121)
                        {

                            /*" -1516- WRITE REG-SAIDA04 FROM TRAILL-REGISTRO */
                            _.Move(TRAILL_REGISTRO.GetMoveValues(), REG_SAIDA04);

                            SAIDA04.Write(REG_SAIDA04.GetMoveValues().ToString());

                            /*" -1517- ADD 1 TO AC-GRAV-SAIDA04 */
                            W.AC_GRAV_SAIDA04.Value = W.AC_GRAV_SAIDA04 + 1;

                            /*" -1518- ELSE */
                        }
                        else
                        {


                            /*" -1519- IF ANT-CONVENIO EQUAL 600123 */

                            if (W.ANT_CONVENIO == 600123)
                            {

                                /*" -1520- WRITE REG-SAIDA05 FROM TRAILL-REGISTRO */
                                _.Move(TRAILL_REGISTRO.GetMoveValues(), REG_SAIDA05);

                                SAIDA05.Write(REG_SAIDA05.GetMoveValues().ToString());

                                /*" -1521- ADD 1 TO AC-GRAV-SAIDA05 */
                                W.AC_GRAV_SAIDA05.Value = W.AC_GRAV_SAIDA05 + 1;

                                /*" -1522- ELSE */
                            }
                            else
                            {


                                /*" -1523- IF ANT-CONVENIO EQUAL 600128 */

                                if (W.ANT_CONVENIO == 600128)
                                {

                                    /*" -1524- WRITE REG-SAIDA06 FROM TRAILL-REGISTRO */
                                    _.Move(TRAILL_REGISTRO.GetMoveValues(), REG_SAIDA06);

                                    SAIDA06.Write(REG_SAIDA06.GetMoveValues().ToString());

                                    /*" -1525- ADD 1 TO AC-GRAV-SAIDA06 */
                                    W.AC_GRAV_SAIDA06.Value = W.AC_GRAV_SAIDA06 + 1;

                                    /*" -1526- ELSE */
                                }
                                else
                                {


                                    /*" -1527- IF ANT-CONVENIO EQUAL 600139 */

                                    if (W.ANT_CONVENIO == 600139)
                                    {

                                        /*" -1528- WRITE REG-SAIDA07 FROM TRAILL-REGISTRO */
                                        _.Move(TRAILL_REGISTRO.GetMoveValues(), REG_SAIDA07);

                                        SAIDA07.Write(REG_SAIDA07.GetMoveValues().ToString());

                                        /*" -1529- ADD 1 TO AC-GRAV-SAIDA07 */
                                        W.AC_GRAV_SAIDA07.Value = W.AC_GRAV_SAIDA07 + 1;

                                        /*" -1530- ELSE */
                                    }
                                    else
                                    {


                                        /*" -1531- IF ANT-CONVENIO EQUAL 600140 */

                                        if (W.ANT_CONVENIO == 600140)
                                        {

                                            /*" -1532- WRITE REG-SAIDA08 FROM TRAILL-REGISTRO */
                                            _.Move(TRAILL_REGISTRO.GetMoveValues(), REG_SAIDA08);

                                            SAIDA08.Write(REG_SAIDA08.GetMoveValues().ToString());

                                            /*" -1533- ADD 1 TO AC-GRAV-SAIDA08 */
                                            W.AC_GRAV_SAIDA08.Value = W.AC_GRAV_SAIDA08 + 1;

                                            /*" -1534- ELSE */
                                        }
                                        else
                                        {


                                            /*" -1535- IF ANT-CONVENIO EQUAL 608800 */

                                            if (W.ANT_CONVENIO == 608800)
                                            {

                                                /*" -1536- WRITE REG-SAIDA09 FROM TRAILL-REGISTRO */
                                                _.Move(TRAILL_REGISTRO.GetMoveValues(), REG_SAIDA09);

                                                SAIDA09.Write(REG_SAIDA09.GetMoveValues().ToString());

                                                /*" -1537- ADD 1 TO AC-GRAV-SAIDA09 */
                                                W.AC_GRAV_SAIDA09.Value = W.AC_GRAV_SAIDA09 + 1;

                                                /*" -1538- ELSE */
                                            }
                                            else
                                            {


                                                /*" -1539- IF ANT-CONVENIO EQUAL 609000 */

                                                if (W.ANT_CONVENIO == 609000)
                                                {

                                                    /*" -1540- WRITE REG-SAIDA10 FROM TRAILL-REGISTRO */
                                                    _.Move(TRAILL_REGISTRO.GetMoveValues(), REG_SAIDA10);

                                                    SAIDA10.Write(REG_SAIDA10.GetMoveValues().ToString());

                                                    /*" -1541- ADD 1 TO AC-GRAV-SAIDA10 */
                                                    W.AC_GRAV_SAIDA10.Value = W.AC_GRAV_SAIDA10 + 1;

                                                    /*" -1542- ELSE */
                                                }
                                                else
                                                {


                                                    /*" -1543- IF ANT-CONVENIO EQUAL 613100 */

                                                    if (W.ANT_CONVENIO == 613100)
                                                    {

                                                        /*" -1544- WRITE REG-SAIDA11 FROM TRAILL-REGISTRO */
                                                        _.Move(TRAILL_REGISTRO.GetMoveValues(), REG_SAIDA11);

                                                        SAIDA11.Write(REG_SAIDA11.GetMoveValues().ToString());

                                                        /*" -1545- ADD 1 TO AC-GRAV-SAIDA11 */
                                                        W.AC_GRAV_SAIDA11.Value = W.AC_GRAV_SAIDA11 + 1;

                                                        /*" -1546- ELSE */
                                                    }
                                                    else
                                                    {


                                                        /*" -1547- IF ANT-CONVENIO EQUAL 613200 */

                                                        if (W.ANT_CONVENIO == 613200)
                                                        {

                                                            /*" -1548- WRITE REG-SAIDA12 FROM TRAILL-REGISTRO */
                                                            _.Move(TRAILL_REGISTRO.GetMoveValues(), REG_SAIDA12);

                                                            SAIDA12.Write(REG_SAIDA12.GetMoveValues().ToString());

                                                            /*" -1549- ADD 1 TO AC-GRAV-SAIDA12 */
                                                            W.AC_GRAV_SAIDA12.Value = W.AC_GRAV_SAIDA12 + 1;

                                                            /*" -1550- ELSE */
                                                        }
                                                        else
                                                        {


                                                            /*" -1551- IF ANT-CONVENIO EQUAL 900662 */

                                                            if (W.ANT_CONVENIO == 900662)
                                                            {

                                                                /*" -1552- WRITE REG-SAIDA13 FROM TRAILL-REGISTRO */
                                                                _.Move(TRAILL_REGISTRO.GetMoveValues(), REG_SAIDA13);

                                                                SAIDA13.Write(REG_SAIDA13.GetMoveValues().ToString());

                                                                /*" -1553- ADD 1 TO AC-GRAV-SAIDA13 */
                                                                W.AC_GRAV_SAIDA13.Value = W.AC_GRAV_SAIDA13 + 1;

                                                                /*" -1554- ELSE */
                                                            }
                                                            else
                                                            {


                                                                /*" -1555- IF ANT-CONVENIO EQUAL 600149 */

                                                                if (W.ANT_CONVENIO == 600149)
                                                                {

                                                                    /*" -1556- WRITE REG-SAIDA14 FROM TRAILL-REGISTRO */
                                                                    _.Move(TRAILL_REGISTRO.GetMoveValues(), REG_SAIDA14);

                                                                    SAIDA14.Write(REG_SAIDA14.GetMoveValues().ToString());

                                                                    /*" -1556- ADD 1 TO AC-GRAV-SAIDA14. */
                                                                    W.AC_GRAV_SAIDA14.Value = W.AC_GRAV_SAIDA14 + 1;
                                                                }

                                                            }

                                                        }

                                                    }

                                                }

                                            }

                                        }

                                    }

                                }

                            }

                        }

                    }

                }

            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/

        [StopWatch]
        /*" R9990-00-SEM-MOVIMENTO-SECTION */
        private void R9990_00_SEM_MOVIMENTO_SECTION()
        {
            /*" -1568- MOVE SISTEMAS-DATA-MOV-ABERTO TO WDATA-REL */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, W.WDATA_REL);

            /*" -1569- MOVE WDAT-REL-DIA TO WDATA-DD-CABEC */
            _.Move(W.FILLER_4.WDAT_REL_DIA, W.WDATA_CABEC.WDATA_DD_CABEC);

            /*" -1570- MOVE WDAT-REL-MES TO WDATA-MM-CABEC */
            _.Move(W.FILLER_4.WDAT_REL_MES, W.WDATA_CABEC.WDATA_MM_CABEC);

            /*" -1572- MOVE WDAT-REL-ANO TO WDATA-AA-CABEC. */
            _.Move(W.FILLER_4.WDAT_REL_ANO, W.WDATA_CABEC.WDATA_AA_CABEC);

            /*" -1574- DISPLAY 'SEM MOVIMENTO NESTA DATA  ' WDATA-CABEC. */
            _.Display($"SEM MOVIMENTO NESTA DATA  {W.WDATA_CABEC}");

            /*" -1591- CLOSE ENTRADA SAIDA01 SAIDA02 SAIDA03 SAIDA04 SAIDA05 SAIDA06 SAIDA07 SAIDA08 SAIDA09 SAIDA10 SAIDA11 SAIDA12 SAIDA13 SAIDA14 SAIDA15. */
            ENTRADA.Close();
            SAIDA01.Close();
            SAIDA02.Close();
            SAIDA03.Close();
            SAIDA04.Close();
            SAIDA05.Close();
            SAIDA06.Close();
            SAIDA07.Close();
            SAIDA08.Close();
            SAIDA09.Close();
            SAIDA10.Close();
            SAIDA11.Close();
            SAIDA12.Close();
            SAIDA13.Close();
            SAIDA14.Close();
            SAIDA15.Close();

            /*" -1593- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -1593- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -1600- MOVE SQLCODE TO WSQLCODE */
            _.Move(DB.SQLCODE, ABEN.WABEND1.WSQLCODE);

            /*" -1601- MOVE SQLERRD(1) TO WSQLERRD1 */
            _.Move(DB.SQLERRD[1], ABEN.WABEND1.WSQLERRD1);

            /*" -1602- MOVE SQLERRD(2) TO WSQLERRD2 */
            _.Move(DB.SQLERRD[2], ABEN.WABEND1.WSQLERRD2);

            /*" -1603- DISPLAY WABEND. */
            _.Display(ABEN.WABEND);

            /*" -1605- DISPLAY WABEND1. */
            _.Display(ABEN.WABEND1);

            /*" -1605- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -1624- CLOSE ENTRADA SAIDA01 SAIDA02 SAIDA03 SAIDA04 SAIDA05 SAIDA06 SAIDA07 SAIDA08 SAIDA09 SAIDA10 SAIDA11 SAIDA12 SAIDA13 SAIDA14 SAIDA15. */
            ENTRADA.Close();
            SAIDA01.Close();
            SAIDA02.Close();
            SAIDA03.Close();
            SAIDA04.Close();
            SAIDA05.Close();
            SAIDA06.Close();
            SAIDA07.Close();
            SAIDA08.Close();
            SAIDA09.Close();
            SAIDA10.Close();
            SAIDA11.Close();
            SAIDA12.Close();
            SAIDA13.Close();
            SAIDA14.Close();
            SAIDA15.Close();

            /*" -1626- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -1626- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}