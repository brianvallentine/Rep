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
using Sias.Bilhetes.DB2.BI0602B;

namespace Code
{
    public class BI0602B
    {
        public bool IsCall { get; set; }

        public BI0602B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  SIAS - SSI 18.941                  *      */
        /*"      *   PROGRAMA ...............  BI0602B                            *      */
        /*"      *   ANALISTA ...............  FAST COMPUPER                      *      */
        /*"      *   programador ............  TERCIO CARVALHO                    *      */
        /*"      *   DATA CODIFICACAO .......  25 / OUTUBRO / 2007                *      */
        /*"      *   FUNCAO .................  RELATORIO PARA ACOMPANHAMENTO      *      */
        /*"      *                             DE VENDAS CENTRAIS RELACIONAMENTO  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 09 - CAD-74.516                                       *      */
        /*"      *                                                                *      */
        /*"      *             - ALTERACAO DOS PARAMENTOS DO CURSOR PRINCIPAL     *      */
        /*"      *               VISANDO MELHORIA DE PERFORMANCE DO PROGRAMA.     *      */
        /*"      *                                                                *      */
        /*"      *   EM 25/09/2012 - PEDRO SILVERIO  (FAST COMPUTER)              *      */
        /*"      *                                                                *      */
        /*"      *                                            PROCURE POR V.09    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 08 - CAD-68.235                                       *      */
        /*"      *                                                                *      */
        /*"      *             - CUSTOMIZACAO PARA O CANAL DE VENDA MAIS ESTUDO   *      */
        /*"      *               OS PROGRAMAS                                     *      */
        /*"      *                                                                *      */
        /*"      *                  . BI3600B                                     *      */
        /*"      *                  . BI3602B                                     *      */
        /*"      *                  . BI0030B                                     *      */
        /*"      *                  . BI0031B                                     *      */
        /*"      *                  . BI0422B                                     *      */
        /*"      *                  . BI0602B                                     *      */
        /*"      *                  . BI6032B                                     *      */
        /*"      *                  . BI7028B                                     *      */
        /*"      *                  . BI7029B                                     *      */
        /*"      *                                                                *      */
        /*"      *                FORAM PREPARADOS PARA TRABALHAR COM PARAMETROS  *      */
        /*"      *                DEFINIDOS NA SEGUROS.ARQUIVOS_SIVPF.                   */
        /*"      *                                                                *      */
        /*"      *   EM 14/04/2012 - TERCIO CARVALHO (FAST COMPUTER)              *      */
        /*"      *                                                                *      */
        /*"      *                                            PROCURE POR V.08    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 07 - CAD 47.775                                       *      */
        /*"      *               - PASSA A TRATAR A ORIGEM 1002 PARA OS PRODUTOS  *      */
        /*"      *                 DO GRUPO FIGUEIREDO. - 8119                    *      */
        /*"      *                                      - 8120                    *      */
        /*"      *                                      - 8121                    *      */
        /*"      *                                      - 8122                    *      */
        /*"      *                                      - 8123                    *      */
        /*"      *                                                                *      */
        /*"      *   EM 01/10/2010 - TERCIO FREITAS (FAST COMPUTER)               *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.07         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ALTERACAO ..............  20/08/2010                         *      */
        /*"      *   CAD-45765   - MARCO PAIVA (FAST COMPUTER)                    *      */
        /*"      *                 TRATAR OS PRODUTOS (SYSTEM CRED)               *      */
        /*"      *                 - 8114 (AP VIDA TRANQUILA PREMIADO EDUCACIONAL)*      */
        /*"      *                 - 8115 (AP VIDA TRANQUILA PREMIADO SAF)        *      */
        /*"      *                 - 8116 (AP VIDA TRANQUILO PREMIADO CHECK LAR)  *      */
        /*"      *                 - 8117 (AP VIDA TRANQUILO PREMIADO HELP DESK)  *      */
        /*"      *                 - 8118 (AP VIDA TRANQUILO PREMIADO NUTRICIONAL)*      */
        /*"      *                                                                *      */
        /*"      *                                         PROCURE POR V.06       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *          ACOMPANHAMENTO DE VENDAS SAF LOTERICO                 *      */
        /*"      *                                                                *      */
        /*"      * EM 15/09/2008      WANGER(FAST COMPUTER)                       *      */
        /*"      *                                       PROCURAR   V.05          *      */
        /*"      * ---------------------------------------------------------------*      */
        /*"      * V.04  -  ATENDIMENTO A SSI-10098.                              *      */
        /*"      *          ACOMPANHAMENTO DE VENDAS VIDA DA GENTE - GITEL        *      */
        /*"      *                                                                *      */
        /*"      * EM 28/05/2008      MARCO PAIVA(FAST COMPUTER)                  *      */
        /*"      *                                       PROCURAR   V.04          *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * V.03  -  Corrige abend paragrafo R1950-00-BUSCA-MOTIVO-CEF     *      */
        /*"      *                                                                *      */
        /*"      * EM 04/12/2006      LUCIA VIEIRA       PROCURAR   V.03          *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * V.02  -  Passa a  tratar   situacao '7'                        *      */
        /*"      *                                                                *      */
        /*"      * EM 25/10/2006      LUCIA VIEIRA       PROCURAR   V.02          *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * V.01  -  PASSA A  INFORMAR DESCRICAO DA SITUACAO E O MOTIVO    *      */
        /*"      *           DESCRITO NA  SEGUROS.V0MOVDEBCC_CEF.                 *      */
        /*"      *                                                                *      */
        /*"      * EM 25/10/2006      LUCIA VIEIRA       PROCURAR   V.01          *      */
        /*"      *----------------------------------------------------------------*      */
        #endregion


        #region VARIABLES

        public FileBasis _RELATORIO { get; set; } = new FileBasis(new PIC("X", "300", "X(300)"));

        public FileBasis RELATORIO
        {
            get
            {
                _.Move(REG_RELAT, _RELATORIO); VarBasis.RedefinePassValue(REG_RELAT, _RELATORIO, REG_RELAT); return _RELATORIO;
            }
        }
        /*"01          REG-RELAT           PIC  X(300).*/
        public StringBasis REG_RELAT { get; set; } = new StringBasis(new PIC("X", "300", "X(300)."), @"");

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77    WIND-NULL                 PIC S9(004)     COMP VALUE +0.*/
        public IntBasis WIND_NULL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    WIND-NULL1                PIC S9(004)     COMP VALUE +0.*/
        public IntBasis WIND_NULL1 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    WSCONTA                   PIC S9(008)     VALUE ZEROS.*/
        public IntBasis WSCONTA { get; set; } = new IntBasis(new PIC("S9", "8", "S9(008)"));
        /*"77    WS-TIME                   PIC X(008).*/
        public StringBasis WS_TIME { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"77    WTEM-BILHETE              PIC X(001).*/
        public StringBasis WTEM_BILHETE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77    WTEM-NRCERTIF             PIC X(001).*/
        public StringBasis WTEM_NRCERTIF { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77    WS-NUM-PROPOSTA           PIC 9(015).*/
        public IntBasis WS_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
        /*"77    WHOST-COD-UNIDADE         PIC S9(004) COMP.*/
        public IntBasis WHOST_COD_UNIDADE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    WHOST-CANAL-DE-VENDA      PIC  X(030)     VALUE SPACES.*/
        public StringBasis WHOST_CANAL_DE_VENDA { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"");
        /*"01  W-TAB-SISTEMA-ORIGEM.*/
        public BI0602B_W_TAB_SISTEMA_ORIGEM W_TAB_SISTEMA_ORIGEM { get; set; } = new BI0602B_W_TAB_SISTEMA_ORIGEM();
        public class BI0602B_W_TAB_SISTEMA_ORIGEM : VarBasis
        {
            /*"    05  WTAB-SISTEMA-ORIGEM   OCCURS    200  TIMES                                PIC  S9(004) COMP.*/
            public ListBasis<IntBasis, Int64> WTAB_SISTEMA_ORIGEM { get; set; } = new ListBasis<IntBasis, Int64>(new PIC("S9", "4", "S9(004)"), 200);
            /*"01  WORK-AREA.*/
        }
        public BI0602B_WORK_AREA WORK_AREA { get; set; } = new BI0602B_WORK_AREA();
        public class BI0602B_WORK_AREA : VarBasis
        {
            /*"    05   WFIM-SISTEMA-ORIGEM          PIC  X(003) VALUE SPACES.*/
            public StringBasis WFIM_SISTEMA_ORIGEM { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"    05   WIND                         PIC S9(004) COMP VALUE +0.*/
            public IntBasis WIND { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05   WIND1                        PIC S9(004) COMP VALUE +0.*/
            public IntBasis WIND1 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05   WINF                         PIC S9(004) COMP VALUE +0.*/
            public IntBasis WINF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05   WSUP                         PIC S9(004) COMP VALUE +0.*/
            public IntBasis WSUP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05   WTEM-SISTEMA-ORIGEM          PIC  X(003) VALUE SPACES.*/
            public StringBasis WTEM_SISTEMA_ORIGEM { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"01  REG-CABEC0.*/
        }
        public BI0602B_REG_CABEC0 REG_CABEC0 { get; set; } = new BI0602B_REG_CABEC0();
        public class BI0602B_REG_CABEC0 : VarBasis
        {
            /*"    05          FILLER         PIC X(07) VALUE 'PF0600B'.*/
            public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "7", "X(07)"), @"PF0600B");
            /*"    05          FILLER         PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05          FILLER         PIC X(45) VALUE               'ACOMPANHAMENTO DE VENDAS BILHETES FACIL GITEL'.*/
            public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "45", "X(45)"), @"ACOMPANHAMENTO DE VENDAS BILHETES FACIL GITEL");
            /*"    05          FILLER         PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05          FILLER         PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05          FILLER         PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05          FILLER         PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05          FILLER         PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05          FILLER         PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05          FILLER         PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05          FILLER         PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05          FILLER         PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05          FILLER         PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05          FILLER         PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05          CABEC0-DTPROC  PIC X(10) VALUE 'DTPROCES'.*/
            public StringBasis CABEC0_DTPROC { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"DTPROCES");
            /*"    05          FILLER         PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"01  REG-CABEC.*/
        }
        public BI0602B_REG_CABEC REG_CABEC { get; set; } = new BI0602B_REG_CABEC();
        public class BI0602B_REG_CABEC : VarBasis
        {
            /*"    05          FILLER         PIC X(06) VALUE 'ORIGEM'.*/
            public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "6", "X(06)"), @"ORIGEM");
            /*"    05          FILLER         PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05          FILLER         PIC X(07) VALUE 'PRODUTO'.*/
            public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "7", "X(07)"), @"PRODUTO");
            /*"    05          FILLER         PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05          FILLER         PIC X(07) VALUE 'UNIDADE'.*/
            public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "7", "X(07)"), @"UNIDADE");
            /*"    05          FILLER         PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05          FILLER         PIC X(08) VALUE 'PROPOSTA'.*/
            public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"PROPOSTA");
            /*"    05          FILLER         PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05          FILLER         PIC X(10) VALUE 'DTPROPOSTA'.*/
            public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"DTPROPOSTA");
            /*"    05          FILLER         PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05          FILLER         PIC X(06) VALUE 'CGCCPF'.*/
            public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "6", "X(06)"), @"CGCCPF");
            /*"    05          FILLER         PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05          FILLER         PIC X(10) VALUE 'DIA DEBITO'.*/
            public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"DIA DEBITO");
            /*"    05          FILLER         PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05          FILLER         PIC X(07) VALUE 'BILHETE'.*/
            public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "7", "X(07)"), @"BILHETE");
            /*"    05          FILLER         PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05          FILLER         PIC X(11) VALUE 'PONTO VENDA'.*/
            public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "11", "X(11)"), @"PONTO VENDA");
            /*"    05          FILLER         PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05          FILLER         PIC X(06) VALUE 'PREMIO'.*/
            public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "6", "X(06)"), @"PREMIO");
            /*"    05          FILLER         PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05          FILLER         PIC X(09) VALUE 'DTVENCTO1'.*/
            public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "9", "X(09)"), @"DTVENCTO1");
            /*"    05          FILLER         PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05          FILLER         PIC X(11) VALUE 'SIT BILHETE'.*/
            public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "11", "X(11)"), @"SIT BILHETE");
            /*"    05          FILLER         PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05          FILLER         PIC X(14) VALUE 'SIT LANCAMENTO'.*/
            public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "14", "X(14)"), @"SIT LANCAMENTO");
            /*"    05          FILLER         PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_40 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05          FILLER         PIC X(10) VALUE 'DTVENCTO2'.*/
            public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"DTVENCTO2");
            /*"    05          FILLER         PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05          FILLER         PIC X(10) VALUE 'DTMOVTO'.*/
            public StringBasis FILLER_43 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"DTMOVTO");
            /*"    05          FILLER         PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_44 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"01  REG-SAIDA.*/
        }
        public BI0602B_REG_SAIDA REG_SAIDA { get; set; } = new BI0602B_REG_SAIDA();
        public class BI0602B_REG_SAIDA : VarBasis
        {
            /*"    05          SAIDA-ORIGEM               PIC X(30).*/
            public StringBasis SAIDA_ORIGEM { get; set; } = new StringBasis(new PIC("X", "30", "X(30)."), @"");
            /*"    05          FILLER1                    PIC X(01) VALUE ';'.*/
            public StringBasis FILLER1 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05          SAIDA-PRODUTO              PIC X(25).*/
            public StringBasis SAIDA_PRODUTO { get; set; } = new StringBasis(new PIC("X", "25", "X(25)."), @"");
            /*"    05          FILLER111                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER111 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05          SAIDA-COD-UNIDADE          PIC 9(04).*/
            public IntBasis SAIDA_COD_UNIDADE { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
            /*"    05          FILLER1A                   PIC X(01) VALUE '-'.*/
            public StringBasis FILLER1A { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
            /*"    05          SAIDA-NOME-UNIDADE         PIC X(40).*/
            public StringBasis SAIDA_NOME_UNIDADE { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
            /*"    05          FILLER1B                   PIC X(01) VALUE ';'.*/
            public StringBasis FILLER1B { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05          SAIDA-NUM-PROPOSTA-SIVPF   PIC 9(15).*/
            public IntBasis SAIDA_NUM_PROPOSTA_SIVPF { get; set; } = new IntBasis(new PIC("9", "15", "9(15)."));
            /*"    05          FILLER2                    PIC X(01) VALUE ';'.*/
            public StringBasis FILLER2 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05          SAIDA-DATA-PROPOSTA        PIC X(10).*/
            public StringBasis SAIDA_DATA_PROPOSTA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"    05          FILLER3                    PIC X(01) VALUE ';'.*/
            public StringBasis FILLER3 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05          SAIDA-CGCCPF               PIC 9(14).*/
            public IntBasis SAIDA_CGCCPF { get; set; } = new IntBasis(new PIC("9", "14", "9(14)."));
            /*"    05          FILLER31                   PIC X(01) VALUE ';'.*/
            public StringBasis FILLER31 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05          SAIDA-DIA-DEBITO           PIC 9(02).*/
            public IntBasis SAIDA_DIA_DEBITO { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
            /*"    05          FILLER4                    PIC X(01) VALUE ';'.*/
            public StringBasis FILLER4 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05          SAIDA-NUM-SICOB            PIC 9(15).*/
            public IntBasis SAIDA_NUM_SICOB { get; set; } = new IntBasis(new PIC("9", "15", "9(15)."));
            /*"    05          FILLER5                    PIC X(01) VALUE ';'.*/
            public StringBasis FILLER5 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05          SAIDA-AGECOBR              PIC 9(04).*/
            public IntBasis SAIDA_AGECOBR { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
            /*"    05          FILLER6                    PIC X(01) VALUE ';'.*/
            public StringBasis FILLER6 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05          SAIDA-VAL-PAGO             PIC 999999999,99.*/
            public DoubleBasis SAIDA_VAL_PAGO { get; set; } = new DoubleBasis(new PIC("9", "9", "999999999V99."), 2);
            /*"    05          FILLER7                    PIC X(01) VALUE ';'.*/
            public StringBasis FILLER7 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05          SAIDA-DATA-QUITACAO-AUX    PIC X(10).*/
            public StringBasis SAIDA_DATA_QUITACAO_AUX { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"    05          FILLER8                    PIC X(01) VALUE ';'.*/
            public StringBasis FILLER8 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05          SAIDA-DSCR-SITUACAO        PIC X(43).*/
            public StringBasis SAIDA_DSCR_SITUACAO { get; set; } = new StringBasis(new PIC("X", "43", "X(43)."), @"");
            /*"    05          FILLER9                    PIC X(01) VALUE ';'.*/
            public StringBasis FILLER9 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05          SAIDA-MOTIVO               PIC X(25).*/
            public StringBasis SAIDA_MOTIVO { get; set; } = new StringBasis(new PIC("X", "25", "X(25)."), @"");
            /*"    05          FILLER10                   PIC X(01) VALUE ';'.*/
            public StringBasis FILLER10 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05          SAIDA-DATA-VENCIMENTO      PIC X(10).*/
            public StringBasis SAIDA_DATA_VENCIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"    05          FILLER11                   PIC X(01) VALUE ';'.*/
            public StringBasis FILLER11 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05          SAIDA-DATA-MOVIMENTO       PIC X(10).*/
            public StringBasis SAIDA_DATA_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"    05          FILLER12                   PIC X(01) VALUE ';'.*/
            public StringBasis FILLER12 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"01  TESTA-FIM-CURS01            PIC   9.*/
        }

        public SelectorBasis TESTA_FIM_CURS01 { get; set; } = new SelectorBasis("9")
        {
            Items = new List<SelectorItemBasis> {
                            /*" 88 FIM-CURSOR01             VALUE 1. */
							new SelectorItemBasis("FIM_CURSOR01", "1")
                }
        };

        /*"01  WS-ACABOU-PESQ              PIC   9.*/

        public SelectorBasis WS_ACABOU_PESQ { get; set; } = new SelectorBasis("9")
        {
            Items = new List<SelectorItemBasis> {
                            /*" 88 WS-ACABOU                VALUE 1. */
							new SelectorItemBasis("WS_ACABOU", "1")
                }
        };

        /*"01  WS-DT-QUIT-AUX.*/
        public BI0602B_WS_DT_QUIT_AUX WS_DT_QUIT_AUX { get; set; } = new BI0602B_WS_DT_QUIT_AUX();
        public class BI0602B_WS_DT_QUIT_AUX : VarBasis
        {
            /*"    05  WS-ANO-QUIT-AUX          PIC X(04).*/
            public StringBasis WS_ANO_QUIT_AUX { get; set; } = new StringBasis(new PIC("X", "4", "X(04)."), @"");
            /*"    05  FILLER                   PIC X(06).*/
            public StringBasis FILLER_45 { get; set; } = new StringBasis(new PIC("X", "6", "X(06)."), @"");
            /*"01  WS-HISTCON-NRCERTIF      PIC S9(15)V      COMP-3 VALUE ZEROS*/
        }
        public DoubleBasis WS_HISTCON_NRCERTIF { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"01  WS-BILHETE-AUX           PIC S9(15)V      COMP-3 VALUE ZEROS*/
        public DoubleBasis WS_BILHETE_AUX { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"01  WS-APOLICE-AUX           PIC S9(13)V      COMP-3 VALUE ZEROS*/
        public DoubleBasis WS_APOLICE_AUX { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"01  WS-CLIENTE-AUX           PIC S9(9)        COMP   VALUE ZEROS*/
        public IntBasis WS_CLIENTE_AUX { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"01  WS-OPC-COBERT-AUX        PIC S9(4)        COMP   VALUE ZEROS*/
        public IntBasis WS_OPC_COBERT_AUX { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  WS-VAL-RCAP-AUX          PIC S9(13)V9(2)  COMP-3 VALUE ZEROS*/
        public DoubleBasis WS_VAL_RCAP_AUX { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"01  WS-DATA-QUITACAO-AUX     PIC  X(10)       VALUE  SPACES.*/
        public StringBasis WS_DATA_QUITACAO_AUX { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
        /*"01  WS-DT-QUIT-RED  REDEFINES WS-DATA-QUITACAO-AUX.*/
        private _REDEF_BI0602B_WS_DT_QUIT_RED _ws_dt_quit_red { get; set; }
        public _REDEF_BI0602B_WS_DT_QUIT_RED WS_DT_QUIT_RED
        {
            get { _ws_dt_quit_red = new _REDEF_BI0602B_WS_DT_QUIT_RED(); _.Move(WS_DATA_QUITACAO_AUX, _ws_dt_quit_red); VarBasis.RedefinePassValue(WS_DATA_QUITACAO_AUX, _ws_dt_quit_red, WS_DATA_QUITACAO_AUX); _ws_dt_quit_red.ValueChanged += () => { _.Move(_ws_dt_quit_red, WS_DATA_QUITACAO_AUX); }; return _ws_dt_quit_red; }
            set { VarBasis.RedefinePassValue(value, _ws_dt_quit_red, WS_DATA_QUITACAO_AUX); }
        }  //Redefines
        public class _REDEF_BI0602B_WS_DT_QUIT_RED : VarBasis
        {
            /*"    05  WS-ANO-QUIT          PIC  9(04).*/
            public IntBasis WS_ANO_QUIT { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
            /*"    05  FILLER               PIC  X(06).*/
            public StringBasis FILLER_46 { get; set; } = new StringBasis(new PIC("X", "6", "X(06)."), @"");
            /*"01  WS-PROXIMA-DT-QUIT       PIC  X(10).*/

            public _REDEF_BI0602B_WS_DT_QUIT_RED()
            {
                WS_ANO_QUIT.ValueChanged += OnValueChanged;
                FILLER_46.ValueChanged += OnValueChanged;
            }

        }
        public StringBasis WS_PROXIMA_DT_QUIT { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  WS-PROXIMA-DT-QUIT-RED  REDEFINES WS-PROXIMA-DT-QUIT.*/
        private _REDEF_BI0602B_WS_PROXIMA_DT_QUIT_RED _ws_proxima_dt_quit_red { get; set; }
        public _REDEF_BI0602B_WS_PROXIMA_DT_QUIT_RED WS_PROXIMA_DT_QUIT_RED
        {
            get { _ws_proxima_dt_quit_red = new _REDEF_BI0602B_WS_PROXIMA_DT_QUIT_RED(); _.Move(WS_PROXIMA_DT_QUIT, _ws_proxima_dt_quit_red); VarBasis.RedefinePassValue(WS_PROXIMA_DT_QUIT, _ws_proxima_dt_quit_red, WS_PROXIMA_DT_QUIT); _ws_proxima_dt_quit_red.ValueChanged += () => { _.Move(_ws_proxima_dt_quit_red, WS_PROXIMA_DT_QUIT); }; return _ws_proxima_dt_quit_red; }
            set { VarBasis.RedefinePassValue(value, _ws_proxima_dt_quit_red, WS_PROXIMA_DT_QUIT); }
        }  //Redefines
        public class _REDEF_BI0602B_WS_PROXIMA_DT_QUIT_RED : VarBasis
        {
            /*"    05  WS-PROX-ANO-QUIT     PIC  9(04).*/
            public IntBasis WS_PROX_ANO_QUIT { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
            /*"    05  FILLER               PIC  X(06).*/
            public StringBasis FILLER_47 { get; set; } = new StringBasis(new PIC("X", "6", "X(06)."), @"");
            /*"01  WS-SITUACAO              PIC  X(01)       VALUE SPACES.*/

            public _REDEF_BI0602B_WS_PROXIMA_DT_QUIT_RED()
            {
                WS_PROX_ANO_QUIT.ValueChanged += OnValueChanged;
                FILLER_47.ValueChanged += OnValueChanged;
            }

        }
        public StringBasis WS_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
        /*"01  WS-TIP-CANCELAMENTO      PIC  X(01)       VALUE SPACES.*/
        public StringBasis WS_TIP_CANCELAMENTO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
        /*"01  WS-SIT-SINISTRO          PIC  X(01)       VALUE SPACES.*/
        public StringBasis WS_SIT_SINISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
        /*"01  WS-SITUAC-CEF            PIC S9(04)       COMP  VALUE ZEROS.*/
        public IntBasis WS_SITUAC_CEF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  WS-SITUAC-CEF-AUX        PIC S9(04)             VALUE ZEROS.*/
        public IntBasis WS_SITUAC_CEF_AUX { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  WS-COBERTURA             PIC 9(04)        VALUE ZEROS.*/
        public IntBasis WS_COBERTURA { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
        /*"01  WS-COBERTURA-RED  REDEFINES WS-COBERTURA.*/
        private _REDEF_BI0602B_WS_COBERTURA_RED _ws_cobertura_red { get; set; }
        public _REDEF_BI0602B_WS_COBERTURA_RED WS_COBERTURA_RED
        {
            get { _ws_cobertura_red = new _REDEF_BI0602B_WS_COBERTURA_RED(); _.Move(WS_COBERTURA, _ws_cobertura_red); VarBasis.RedefinePassValue(WS_COBERTURA, _ws_cobertura_red, WS_COBERTURA); _ws_cobertura_red.ValueChanged += () => { _.Move(_ws_cobertura_red, WS_COBERTURA); }; return _ws_cobertura_red; }
            set { VarBasis.RedefinePassValue(value, _ws_cobertura_red, WS_COBERTURA); }
        }  //Redefines
        public class _REDEF_BI0602B_WS_COBERTURA_RED : VarBasis
        {
            /*"    05  FILLER               PIC 9(03).*/
            public IntBasis FILLER_48 { get; set; } = new IntBasis(new PIC("9", "3", "9(03)."));
            /*"    05  WS-COBERT-RED        PIC 9(01).*/
            public IntBasis WS_COBERT_RED { get; set; } = new IntBasis(new PIC("9", "1", "9(01)."));
            /*"01  AREA-DE-WORK.*/

            public _REDEF_BI0602B_WS_COBERTURA_RED()
            {
                FILLER_48.ValueChanged += OnValueChanged;
                WS_COBERT_RED.ValueChanged += OnValueChanged;
            }

        }
        public BI0602B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new BI0602B_AREA_DE_WORK();
        public class BI0602B_AREA_DE_WORK : VarBasis
        {
            /*"    05  WS-ULT-DATA-QUIT     PIC  X(10)       VALUE SPACES.*/
            public StringBasis WS_ULT_DATA_QUIT { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
            /*"    05  WS-NUM-ULTIMO-BIL    PIC S9(15)V      COMP-3 VALUE ZEROS*/
            public DoubleBasis WS_NUM_ULTIMO_BIL { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
            /*"    05  WS-ULT-APOL-ANTERIOR PIC S9(15)V      COMP-3 VALUE ZEROS*/
            public DoubleBasis WS_ULT_APOL_ANTERIOR { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
            /*"    05  WS-ULT-SITUACAO      PIC  X(01)       VALUE SPACES.*/
            public StringBasis WS_ULT_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
            /*"    05  WS-ULT-TIP-CANCEL    PIC  X(01)       VALUE SPACES.*/
            public StringBasis WS_ULT_TIP_CANCEL { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
            /*"    05  WS-ULT-TIP-SINISTRO  PIC  X(01)       VALUE SPACES.*/
            public StringBasis WS_ULT_TIP_SINISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
            /*"    05 TAB-SITUACAO-SYSTEM.*/
            public BI0602B_TAB_SITUACAO_SYSTEM TAB_SITUACAO_SYSTEM { get; set; } = new BI0602B_TAB_SITUACAO_SYSTEM();
            public class BI0602B_TAB_SITUACAO_SYSTEM : VarBasis
            {
                /*"       10  FILLER  PIC X(020) VALUE  'DEBITO EFETUADO     '    .*/
                public StringBasis FILLER_49 { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"DEBITO EFETUADO     ");
                /*"       10  FILLER  PIC X(020) VALUE  'INSUFICIENCIA FUNDOS'    .*/
                public StringBasis FILLER_50 { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"INSUFICIENCIA FUNDOS");
                /*"       10  FILLER  PIC X(020) VALUE  'CARTAO CANCELADO    '    .*/
                public StringBasis FILLER_51 { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"CARTAO CANCELADO    ");
                /*"       10  FILLER  PIC X(020) VALUE  'SUBSTITUICAO CARTAO '    .*/
                public StringBasis FILLER_52 { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"SUBSTITUICAO CARTAO ");
                /*"       10  FILLER  PIC X(020) VALUE  'CARTAO INVALIDO     '    .*/
                public StringBasis FILLER_53 { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"CARTAO INVALIDO     ");
                /*"       10  FILLER  PIC X(020) VALUE  'ESTORNO SEM COBRANCA'    .*/
                public StringBasis FILLER_54 { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"ESTORNO SEM COBRANCA");
                /*"       10  FILLER  PIC X(020) VALUE  'ESTORNO COM COBRANCA'    .*/
                public StringBasis FILLER_55 { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"ESTORNO COM COBRANCA");
                /*"       10  FILLER  PIC X(020) VALUE  'CANCELA SEGURO      '    .*/
                public StringBasis FILLER_56 { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"CANCELA SEGURO      ");
                /*"    05  TAB-SITUACAO-CEF-RED1 REDEFINES TAB-SITUACAO-SYSTEM.*/
            }
            private _REDEF_BI0602B_TAB_SITUACAO_CEF_RED1 _tab_situacao_cef_red1 { get; set; }
            public _REDEF_BI0602B_TAB_SITUACAO_CEF_RED1 TAB_SITUACAO_CEF_RED1
            {
                get { _tab_situacao_cef_red1 = new _REDEF_BI0602B_TAB_SITUACAO_CEF_RED1(); _.Move(TAB_SITUACAO_SYSTEM, _tab_situacao_cef_red1); VarBasis.RedefinePassValue(TAB_SITUACAO_SYSTEM, _tab_situacao_cef_red1, TAB_SITUACAO_SYSTEM); _tab_situacao_cef_red1.ValueChanged += () => { _.Move(_tab_situacao_cef_red1, TAB_SITUACAO_SYSTEM); }; return _tab_situacao_cef_red1; }
                set { VarBasis.RedefinePassValue(value, _tab_situacao_cef_red1, TAB_SITUACAO_SYSTEM); }
            }  //Redefines
            public class _REDEF_BI0602B_TAB_SITUACAO_CEF_RED1 : VarBasis
            {
                /*"      10  TB-SITUACAO-CEF  OCCURS 8  TIMES.*/
                public ListBasis<BI0602B_TB_SITUACAO_CEF> TB_SITUACAO_CEF { get; set; } = new ListBasis<BI0602B_TB_SITUACAO_CEF>(8);
                public class BI0602B_TB_SITUACAO_CEF : VarBasis
                {
                    /*"        15  TAB-DESC-RET1              PIC X(20).*/
                    public StringBasis TAB_DESC_RET1 { get; set; } = new StringBasis(new PIC("X", "20", "X(20)."), @"");
                    /*"    05 TAB-SITUACAO-CEF.*/

                    public BI0602B_TB_SITUACAO_CEF()
                    {
                        TAB_DESC_RET1.ValueChanged += OnValueChanged;
                    }

                }

                public _REDEF_BI0602B_TAB_SITUACAO_CEF_RED1()
                {
                    TB_SITUACAO_CEF.ValueChanged += OnValueChanged;
                }

            }
            public BI0602B_TAB_SITUACAO_CEF TAB_SITUACAO_CEF { get; set; } = new BI0602B_TAB_SITUACAO_CEF();
            public class BI0602B_TAB_SITUACAO_CEF : VarBasis
            {
                /*"       10  FILLER   PIC X(020) VALUE  'EFETUADO            ' .*/
                public StringBasis FILLER_57 { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"EFETUADO            ");
                /*"       10  FILLER   PIC X(020) VALUE  'SALDO INSUFICIENTE  ' .*/
                public StringBasis FILLER_58 { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"SALDO INSUFICIENTE  ");
                /*"       10  FILLER   PIC X(020) VALUE  'CONTA NAO CADASTRADA' .*/
                public StringBasis FILLER_59 { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"CONTA NAO CADASTRADA");
                /*"       10  FILLER   PIC X(020) VALUE  'OUTRAS RESTRICOES   ' .*/
                public StringBasis FILLER_60 { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"OUTRAS RESTRICOES   ");
                /*"       10  FILLER   PIC X(020) VALUE  'AGENCIA ENCERRADA   ' .*/
                public StringBasis FILLER_61 { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"AGENCIA ENCERRADA   ");
                /*"       10  FILLER   PIC X(020) VALUE  'VALOR INVALIDO      ' .*/
                public StringBasis FILLER_62 { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"VALOR INVALIDO      ");
                /*"       10  FILLER   PIC X(020) VALUE  'AGENCIA INVALID     ' .*/
                public StringBasis FILLER_63 { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"AGENCIA INVALID     ");
                /*"       10  FILLER   PIC X(020) VALUE  'DATA INVALIDA       ' .*/
                public StringBasis FILLER_64 { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"DATA INVALIDA       ");
                /*"       10  FILLER   PIC X(020) VALUE  'DATA INVALIDA       ' .*/
                public StringBasis FILLER_65 { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"DATA INVALIDA       ");
                /*"       10  FILLER   PIC X(020) VALUE  'SEM CONTRATO        ' .*/
                public StringBasis FILLER_66 { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"SEM CONTRATO        ");
                /*"       10  FILLER   PIC X(020) VALUE  'VALOR ZERADO        ' .*/
                public StringBasis FILLER_67 { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"VALOR ZERADO        ");
                /*"       10  FILLER   PIC X(020) VALUE  'ESTORNADO           ' .*/
                public StringBasis FILLER_68 { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"ESTORNADO           ");
                /*"    05  TAB-SITUACAO-CEF-RED  REDEFINES TAB-SITUACAO-CEF.*/
            }
            private _REDEF_BI0602B_TAB_SITUACAO_CEF_RED _tab_situacao_cef_red { get; set; }
            public _REDEF_BI0602B_TAB_SITUACAO_CEF_RED TAB_SITUACAO_CEF_RED
            {
                get { _tab_situacao_cef_red = new _REDEF_BI0602B_TAB_SITUACAO_CEF_RED(); _.Move(TAB_SITUACAO_CEF, _tab_situacao_cef_red); VarBasis.RedefinePassValue(TAB_SITUACAO_CEF, _tab_situacao_cef_red, TAB_SITUACAO_CEF); _tab_situacao_cef_red.ValueChanged += () => { _.Move(_tab_situacao_cef_red, TAB_SITUACAO_CEF); }; return _tab_situacao_cef_red; }
                set { VarBasis.RedefinePassValue(value, _tab_situacao_cef_red, TAB_SITUACAO_CEF); }
            }  //Redefines
            public class _REDEF_BI0602B_TAB_SITUACAO_CEF_RED : VarBasis
            {
                /*"      10  TB-SITUACAO-CEF  OCCURS 12 TIMES.*/
                public ListBasis<BI0602B_TB_SITUACAO_CEF_0> TB_SITUACAO_CEF_0 { get; set; } = new ListBasis<BI0602B_TB_SITUACAO_CEF_0>(12);
                public class BI0602B_TB_SITUACAO_CEF_0 : VarBasis
                {
                    /*"        15  TAB-DESC-RET               PIC X(20).*/
                    public StringBasis TAB_DESC_RET { get; set; } = new StringBasis(new PIC("X", "20", "X(20)."), @"");
                    /*"    05 TAB-SITUACAO.*/

                    public BI0602B_TB_SITUACAO_CEF_0()
                    {
                        TAB_DESC_RET.ValueChanged += OnValueChanged;
                    }

                }

                public _REDEF_BI0602B_TAB_SITUACAO_CEF_RED()
                {
                    TB_SITUACAO_CEF_0.ValueChanged += OnValueChanged;
                }

            }
            public BI0602B_TAB_SITUACAO TAB_SITUACAO { get; set; } = new BI0602B_TAB_SITUACAO();
            public class BI0602B_TAB_SITUACAO : VarBasis
            {
                /*"       10  FILLER                        PIC X(043)                  VALUE  'PENDENTE A INTEGRAR                 '.*/
                public StringBasis FILLER_69 { get; set; } = new StringBasis(new PIC("X", "43", "X(043)"), @"PENDENTE A INTEGRAR                 ");
                /*"       10  FILLER                        PIC X(043)           VALUE  'EM CRITICA                                 '.*/
                public StringBasis FILLER_70 { get; set; } = new StringBasis(new PIC("X", "43", "X(043)"), @"EM CRITICA                                 ");
                /*"       10  FILLER                        PIC X(043)           VALUE  'FALTA RCAP E NAO ESTA EM CRITICA           '.*/
                public StringBasis FILLER_71 { get; set; } = new StringBasis(new PIC("X", "43", "X(043)"), @"FALTA RCAP E NAO ESTA EM CRITICA           ");
                /*"       10  FILLER                        PIC X(043)           VALUE  'FALTA RCAP E ESTA EM CRITICA               '.*/
                public StringBasis FILLER_72 { get; set; } = new StringBasis(new PIC("X", "43", "X(043)"), @"FALTA RCAP E ESTA EM CRITICA               ");
                /*"       10  FILLER                        PIC X(043)           VALUE  'RCAP CADASTRADO INDEVIDAMENTE (ON-LINE)    '.*/
                public StringBasis FILLER_73 { get; set; } = new StringBasis(new PIC("X", "43", "X(043)"), @"RCAP CADASTRADO INDEVIDAMENTE (ON-LINE)    ");
                /*"       10  FILLER                        PIC X(043)           VALUE  'A DEBITAR                                  '.*/
                public StringBasis FILLER_74 { get; set; } = new StringBasis(new PIC("X", "43", "X(043)"), @"A DEBITAR                                  ");
                /*"       10  FILLER                        PIC X(043)           VALUE  'DEBITO JA ENVIDADO                         '.*/
                public StringBasis FILLER_75 { get; set; } = new StringBasis(new PIC("X", "43", "X(043)"), @"DEBITO JA ENVIDADO                         ");
                /*"       10  FILLER                        PIC X(043)           VALUE  'NAO EMITIDO - RESTRICAO NA CONTA BANCARIA  '.*/
                public StringBasis FILLER_76 { get; set; } = new StringBasis(new PIC("X", "43", "X(043)"), @"NAO EMITIDO - RESTRICAO NA CONTA BANCARIA  ");
                /*"       10  FILLER                        PIC X(043)           VALUE  'CANCELADO                                  '.*/
                public StringBasis FILLER_77 { get; set; } = new StringBasis(new PIC("X", "43", "X(043)"), @"CANCELADO                                  ");
                /*"       10  FILLER                        PIC X(043)           VALUE  'CADASTRADO - JA EMITIDO                    '.*/
                public StringBasis FILLER_78 { get; set; } = new StringBasis(new PIC("X", "43", "X(043)"), @"CADASTRADO - JA EMITIDO                    ");
                /*"       10  FILLER                        PIC X(043)           VALUE  'NAO RENOVADO - CTA DEBITO = CTA INDICADOR  '.*/
                public StringBasis FILLER_79 { get; set; } = new StringBasis(new PIC("X", "43", "X(043)"), @"NAO RENOVADO - CTA DEBITO = CTA INDICADOR  ");
                /*"    05  TAB-SITUACAO-RED REDEFINES TAB-SITUACAO.*/
            }
            private _REDEF_BI0602B_TAB_SITUACAO_RED _tab_situacao_red { get; set; }
            public _REDEF_BI0602B_TAB_SITUACAO_RED TAB_SITUACAO_RED
            {
                get { _tab_situacao_red = new _REDEF_BI0602B_TAB_SITUACAO_RED(); _.Move(TAB_SITUACAO, _tab_situacao_red); VarBasis.RedefinePassValue(TAB_SITUACAO, _tab_situacao_red, TAB_SITUACAO); _tab_situacao_red.ValueChanged += () => { _.Move(_tab_situacao_red, TAB_SITUACAO); }; return _tab_situacao_red; }
                set { VarBasis.RedefinePassValue(value, _tab_situacao_red, TAB_SITUACAO); }
            }  //Redefines
            public class _REDEF_BI0602B_TAB_SITUACAO_RED : VarBasis
            {
                /*"      10  TB-SITUACAO-CEF  OCCURS 11 TIMES.*/
                public ListBasis<BI0602B_TB_SITUACAO_CEF_1> TB_SITUACAO_CEF_1 { get; set; } = new ListBasis<BI0602B_TB_SITUACAO_CEF_1>(11);
                public class BI0602B_TB_SITUACAO_CEF_1 : VarBasis
                {
                    /*"        15  TAB-DESC-SITUACAO          PIC X(43).*/
                    public StringBasis TAB_DESC_SITUACAO { get; set; } = new StringBasis(new PIC("X", "43", "X(43)."), @"");
                    /*"    05 TAB-SITUACAO-VIDA.*/

                    public BI0602B_TB_SITUACAO_CEF_1()
                    {
                        TAB_DESC_SITUACAO.ValueChanged += OnValueChanged;
                    }

                }

                public _REDEF_BI0602B_TAB_SITUACAO_RED()
                {
                    TB_SITUACAO_CEF_1.ValueChanged += OnValueChanged;
                }

            }
            public BI0602B_TAB_SITUACAO_VIDA TAB_SITUACAO_VIDA { get; set; } = new BI0602B_TAB_SITUACAO_VIDA();
            public class BI0602B_TAB_SITUACAO_VIDA : VarBasis
            {
                /*"       10  FILLER                        PIC X(043)                  VALUE  'ACEITO.AGUARDA EMISSAO              '.*/
                public StringBasis FILLER_80 { get; set; } = new StringBasis(new PIC("X", "43", "X(043)"), @"ACEITO.AGUARDA EMISSAO              ");
                /*"       10  FILLER                        PIC X(043)           VALUE  'EM CRITICA                                 '.*/
                public StringBasis FILLER_81 { get; set; } = new StringBasis(new PIC("X", "43", "X(043)"), @"EM CRITICA                                 ");
                /*"       10  FILLER                        PIC X(043)           VALUE  'NAO ACEITO                                 '.*/
                public StringBasis FILLER_82 { get; set; } = new StringBasis(new PIC("X", "43", "X(043)"), @"NAO ACEITO                                 ");
                /*"       10  FILLER                        PIC X(043)           VALUE  'INTEGRADO                                  '.*/
                public StringBasis FILLER_83 { get; set; } = new StringBasis(new PIC("X", "43", "X(043)"), @"INTEGRADO                                  ");
                /*"       10  FILLER                        PIC X(043)           VALUE  'CANCELADO APOS EMISSAO                     '.*/
                public StringBasis FILLER_84 { get; set; } = new StringBasis(new PIC("X", "43", "X(043)"), @"CANCELADO APOS EMISSAO                     ");
                /*"       10  FILLER                        PIC X(043)           VALUE  'RCAP NAO ENCONTRADO                        '.*/
                public StringBasis FILLER_85 { get; set; } = new StringBasis(new PIC("X", "43", "X(043)"), @"RCAP NAO ENCONTRADO                        ");
                /*"       10  FILLER                        PIC X(043)           VALUE  'COBERTURA SUSPENSA                         '.*/
                public StringBasis FILLER_86 { get; set; } = new StringBasis(new PIC("X", "43", "X(043)"), @"COBERTURA SUSPENSA                         ");
                /*"       10  FILLER                        PIC X(043)           VALUE  'AGUARDA EMISSAO 1A PARCEL                  '.*/
                public StringBasis FILLER_87 { get; set; } = new StringBasis(new PIC("X", "43", "X(043)"), @"AGUARDA EMISSAO 1A PARCEL                  ");
                /*"       10  FILLER                        PIC X(043)           VALUE  'AGUARDA PGTO 1A PARCELA                    '.*/
                public StringBasis FILLER_88 { get; set; } = new StringBasis(new PIC("X", "43", "X(043)"), @"AGUARDA PGTO 1A PARCELA                    ");
                /*"       10  FILLER                        PIC X(043)           VALUE  'AGUARDA PROPOSTA FISICA                    '.*/
                public StringBasis FILLER_89 { get; set; } = new StringBasis(new PIC("X", "43", "X(043)"), @"AGUARDA PROPOSTA FISICA                    ");
                /*"       10  FILLER                        PIC X(043)           VALUE  'INTEGRAR                                   '.*/
                public StringBasis FILLER_90 { get; set; } = new StringBasis(new PIC("X", "43", "X(043)"), @"INTEGRAR                                   ");
                /*"       10  FILLER                        PIC X(043)           VALUE  'INTEGRADA PROPOSTA NOVA                    '.*/
                public StringBasis FILLER_91 { get; set; } = new StringBasis(new PIC("X", "43", "X(043)"), @"INTEGRADA PROPOSTA NOVA                    ");
                /*"       10  FILLER                        PIC X(043)           VALUE  'INTEGRADA MIGRADA                          '.*/
                public StringBasis FILLER_92 { get; set; } = new StringBasis(new PIC("X", "43", "X(043)"), @"INTEGRADA MIGRADA                          ");
                /*"       10  FILLER                        PIC X(043)           VALUE  'UTILIZADO PELO SAUDE                       '.*/
                public StringBasis FILLER_93 { get; set; } = new StringBasis(new PIC("X", "43", "X(043)"), @"UTILIZADO PELO SAUDE                       ");
                /*"       10  FILLER                        PIC X(043)           VALUE  'AGUARDANDO CRIVO                           '.*/
                public StringBasis FILLER_94 { get; set; } = new StringBasis(new PIC("X", "43", "X(043)"), @"AGUARDANDO CRIVO                           ");
                /*"    05  TAB-SITUACAO-RED-VIDA REDEFINES TAB-SITUACAO-VIDA.*/
            }
            private _REDEF_BI0602B_TAB_SITUACAO_RED_VIDA _tab_situacao_red_vida { get; set; }
            public _REDEF_BI0602B_TAB_SITUACAO_RED_VIDA TAB_SITUACAO_RED_VIDA
            {
                get { _tab_situacao_red_vida = new _REDEF_BI0602B_TAB_SITUACAO_RED_VIDA(); _.Move(TAB_SITUACAO_VIDA, _tab_situacao_red_vida); VarBasis.RedefinePassValue(TAB_SITUACAO_VIDA, _tab_situacao_red_vida, TAB_SITUACAO_VIDA); _tab_situacao_red_vida.ValueChanged += () => { _.Move(_tab_situacao_red_vida, TAB_SITUACAO_VIDA); }; return _tab_situacao_red_vida; }
                set { VarBasis.RedefinePassValue(value, _tab_situacao_red_vida, TAB_SITUACAO_VIDA); }
            }  //Redefines
            public class _REDEF_BI0602B_TAB_SITUACAO_RED_VIDA : VarBasis
            {
                /*"      10  TB-SITUACAO-VIDA  OCCURS 15 TIMES.*/
                public ListBasis<BI0602B_TB_SITUACAO_VIDA> TB_SITUACAO_VIDA { get; set; } = new ListBasis<BI0602B_TB_SITUACAO_VIDA>(15);
                public class BI0602B_TB_SITUACAO_VIDA : VarBasis
                {
                    /*"        15  TAB-DESC-SIT-VIDA     PIC X(43).*/
                    public StringBasis TAB_DESC_SIT_VIDA { get; set; } = new StringBasis(new PIC("X", "43", "X(43)."), @"");
                    /*"    05 TAB-SIT-SINISTRO.*/

                    public BI0602B_TB_SITUACAO_VIDA()
                    {
                        TAB_DESC_SIT_VIDA.ValueChanged += OnValueChanged;
                    }

                }

                public _REDEF_BI0602B_TAB_SITUACAO_RED_VIDA()
                {
                    TB_SITUACAO_VIDA.ValueChanged += OnValueChanged;
                }

            }
            public BI0602B_TAB_SIT_SINISTRO TAB_SIT_SINISTRO { get; set; } = new BI0602B_TAB_SIT_SINISTRO();
            public class BI0602B_TAB_SIT_SINISTRO : VarBasis
            {
                /*"       10  FILLER                        PIC X(029)           VALUE  'CANCELAMENTO POR SOLICITACAO'.*/
                public StringBasis FILLER_95 { get; set; } = new StringBasis(new PIC("X", "29", "X(029)"), @"CANCELAMENTO POR SOLICITACAO");
                /*"       10  FILLER                        PIC X(029)           VALUE  'CANCELAMENTO POR SINISTRO   '.*/
                public StringBasis FILLER_96 { get; set; } = new StringBasis(new PIC("X", "29", "X(029)"), @"CANCELAMENTO POR SINISTRO   ");
                /*"    05  TAB-SIT-SINISTRO-RED REDEFINES TAB-SIT-SINISTRO.*/
            }
            private _REDEF_BI0602B_TAB_SIT_SINISTRO_RED _tab_sit_sinistro_red { get; set; }
            public _REDEF_BI0602B_TAB_SIT_SINISTRO_RED TAB_SIT_SINISTRO_RED
            {
                get { _tab_sit_sinistro_red = new _REDEF_BI0602B_TAB_SIT_SINISTRO_RED(); _.Move(TAB_SIT_SINISTRO, _tab_sit_sinistro_red); VarBasis.RedefinePassValue(TAB_SIT_SINISTRO, _tab_sit_sinistro_red, TAB_SIT_SINISTRO); _tab_sit_sinistro_red.ValueChanged += () => { _.Move(_tab_sit_sinistro_red, TAB_SIT_SINISTRO); }; return _tab_sit_sinistro_red; }
                set { VarBasis.RedefinePassValue(value, _tab_sit_sinistro_red, TAB_SIT_SINISTRO); }
            }  //Redefines
            public class _REDEF_BI0602B_TAB_SIT_SINISTRO_RED : VarBasis
            {
                /*"      10  TB-SITUACAO-CEF  OCCURS 02 TIMES.*/
                public ListBasis<BI0602B_TB_SITUACAO_CEF_2> TB_SITUACAO_CEF_2 { get; set; } = new ListBasis<BI0602B_TB_SITUACAO_CEF_2>(02);
                public class BI0602B_TB_SITUACAO_CEF_2 : VarBasis
                {
                    /*"        15  TAB-DESC-SIT-SINISTRO      PIC X(29).*/
                    public StringBasis TAB_DESC_SIT_SINISTRO { get; set; } = new StringBasis(new PIC("X", "29", "X(29)."), @"");
                    /*"    05  WS-CONT-RENOVACAO       PIC  9(002)   VALUE ZEROS.*/

                    public BI0602B_TB_SITUACAO_CEF_2()
                    {
                        TAB_DESC_SIT_SINISTRO.ValueChanged += OnValueChanged;
                    }

                }

                public _REDEF_BI0602B_TAB_SIT_SINISTRO_RED()
                {
                    TB_SITUACAO_CEF_2.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WS_CONT_RENOVACAO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"    05  WS-QTDE-A-RENOVAR       PIC S9(003)   VALUE ZEROS.*/
            public IntBasis WS_QTDE_A_RENOVAR { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"));
            /*"    05  WS-TOT-LIDOS            PIC  9(008)   VALUE ZEROS.*/
            public IntBasis WS_TOT_LIDOS { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05  WS-TOTAL-GRAV           PIC  9(008)   VALUE ZEROS.*/
            public IntBasis WS_TOTAL_GRAV { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05  WS-DATA-HOJE            PIC  X(010)   VALUE SPACES.*/
            public StringBasis WS_DATA_HOJE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"    05  WS-DATA-HOJE-AUX.*/
            public BI0602B_WS_DATA_HOJE_AUX WS_DATA_HOJE_AUX { get; set; } = new BI0602B_WS_DATA_HOJE_AUX();
            public class BI0602B_WS_DATA_HOJE_AUX : VarBasis
            {
                /*"        10  WS-ANO-HOJE         PIC  9(004)   VALUE ZEROS.*/
                public IntBasis WS_ANO_HOJE { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"        10  FILLER              PIC  X(001)   VALUE '-'.*/
                public StringBasis FILLER_97 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"        10  WS-MES-HOJE         PIC  9(002)   VALUE ZEROS.*/
                public IntBasis WS_MES_HOJE { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"        10  FILLER              PIC  X(001)   VALUE '-'.*/
                public StringBasis FILLER_98 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"        10  WS-DIA-HOJE         PIC  9(002)   VALUE ZEROS.*/
                public IntBasis WS_DIA_HOJE { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    05  WS-DATA-FINAL           PIC  X(010)    VALUE  SPACES.*/
            }
            public StringBasis WS_DATA_FINAL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"    05  WS-DATA-INICIO          PIC  X(010)    VALUE  SPACES.*/
            public StringBasis WS_DATA_INICIO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"    05  FILLER                  REDEFINES    WS-DATA-INICIO.*/
            private _REDEF_BI0602B_FILLER_99 _filler_99 { get; set; }
            public _REDEF_BI0602B_FILLER_99 FILLER_99
            {
                get { _filler_99 = new _REDEF_BI0602B_FILLER_99(); _.Move(WS_DATA_INICIO, _filler_99); VarBasis.RedefinePassValue(WS_DATA_INICIO, _filler_99, WS_DATA_INICIO); _filler_99.ValueChanged += () => { _.Move(_filler_99, WS_DATA_INICIO); }; return _filler_99; }
                set { VarBasis.RedefinePassValue(value, _filler_99, WS_DATA_INICIO); }
            }  //Redefines
            public class _REDEF_BI0602B_FILLER_99 : VarBasis
            {
                /*"        10  WS-ANO-INICIO       PIC  9(004).*/
                public IntBasis WS_ANO_INICIO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"        10  FILLER              PIC  X(001).*/
                public StringBasis FILLER_100 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"        10  WS-MES-INICIO       PIC  9(002).*/
                public IntBasis WS_MES_INICIO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"        10  FILLER              PIC  X(001).*/
                public StringBasis FILLER_101 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"        10  WS-DIA-INICIO       PIC  9(002).*/
                public IntBasis WS_DIA_INICIO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05  WS-DATA-ACCEPT.*/

                public _REDEF_BI0602B_FILLER_99()
                {
                    WS_ANO_INICIO.ValueChanged += OnValueChanged;
                    FILLER_100.ValueChanged += OnValueChanged;
                    WS_MES_INICIO.ValueChanged += OnValueChanged;
                    FILLER_101.ValueChanged += OnValueChanged;
                    WS_DIA_INICIO.ValueChanged += OnValueChanged;
                }

            }
            public BI0602B_WS_DATA_ACCEPT WS_DATA_ACCEPT { get; set; } = new BI0602B_WS_DATA_ACCEPT();
            public class BI0602B_WS_DATA_ACCEPT : VarBasis
            {
                /*"        10  WS-ANO-ACCEPT       PIC  9(002)    VALUE  ZEROS.*/
                public IntBasis WS_ANO_ACCEPT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"        10  WS-MES-ACCEPT       PIC  9(002)    VALUE  ZEROS.*/
                public IntBasis WS_MES_ACCEPT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"        10  WS-DIA-ACCEPT       PIC  9(002)    VALUE  ZEROS.*/
                public IntBasis WS_DIA_ACCEPT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    05  WS-HORA-ACCEPT.*/
            }
            public BI0602B_WS_HORA_ACCEPT WS_HORA_ACCEPT { get; set; } = new BI0602B_WS_HORA_ACCEPT();
            public class BI0602B_WS_HORA_ACCEPT : VarBasis
            {
                /*"        10  WS-HOR-ACCEPT       PIC  9(002)    VALUE  ZEROS.*/
                public IntBasis WS_HOR_ACCEPT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"        10  WS-MIN-ACCEPT       PIC  9(002)    VALUE  ZEROS.*/
                public IntBasis WS_MIN_ACCEPT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"        10  WS-SEG-ACCEPT       PIC  9(002)    VALUE  ZEROS.*/
                public IntBasis WS_SEG_ACCEPT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    05  WS-DATA-CURR.*/
            }
            public BI0602B_WS_DATA_CURR WS_DATA_CURR { get; set; } = new BI0602B_WS_DATA_CURR();
            public class BI0602B_WS_DATA_CURR : VarBasis
            {
                /*"        10  WS-DIA-CURR         PIC  9(002)    VALUE  ZEROS.*/
                public IntBasis WS_DIA_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"        10  FILLER              PIC  X(001)    VALUE  '-'.*/
                public StringBasis FILLER_102 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"        10  WS-MES-CURR         PIC  9(002)    VALUE  ZEROS.*/
                public IntBasis WS_MES_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"        10  FILLER              PIC  X(001)    VALUE  '-'.*/
                public StringBasis FILLER_103 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"        10  WS-ANO-CURR         PIC  9(004)    VALUE  ZEROS.*/
                public IntBasis WS_ANO_CURR { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"    05  WS-HORA-CURR.*/
            }
            public BI0602B_WS_HORA_CURR WS_HORA_CURR { get; set; } = new BI0602B_WS_HORA_CURR();
            public class BI0602B_WS_HORA_CURR : VarBasis
            {
                /*"        10  WS-HOR-CURR         PIC  9(002)    VALUE  ZEROS.*/
                public IntBasis WS_HOR_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"        10  FILLER              PIC  X(001)    VALUE  ':'.*/
                public StringBasis FILLER_104 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @":");
                /*"        10  WS-MIN-CURR         PIC  9(002)    VALUE  ZEROS.*/
                public IntBasis WS_MIN_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"        10  FILLER              PIC  X(001)    VALUE  ':'.*/
                public StringBasis FILLER_105 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @":");
                /*"        10  WS-SEG-CURR         PIC  9(002)    VALUE  ZEROS.*/
                public IntBasis WS_SEG_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    05  WREG-CABECALHO-01.*/
            }
            public BI0602B_WREG_CABECALHO_01 WREG_CABECALHO_01 { get; set; } = new BI0602B_WREG_CABECALHO_01();
            public class BI0602B_WREG_CABECALHO_01 : VarBasis
            {
                /*"        10  FILLER              PIC  X(007) VALUE 'ANO EMS'.*/
                public StringBasis FILLER_106 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"ANO EMS");
                /*"        10  FILLER              PIC  X(001) VALUE  ';'.*/
                public StringBasis FILLER_107 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"        10  FILLER              PIC  X(007) VALUE 'CGC/CPF'.*/
                public StringBasis FILLER_108 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"CGC/CPF");
                /*"        10  FILLER              PIC  X(008) VALUE  SPACES.*/
                public StringBasis FILLER_109 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
                /*"        10  FILLER              PIC  X(001) VALUE  ';'.*/
                public StringBasis FILLER_110 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"        10  FILLER              PIC  X(008) VALUE  'SEGURADO'.*/
                public StringBasis FILLER_111 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"SEGURADO");
                /*"        10  FILLER              PIC  X(032) VALUE  SPACES.*/
                public StringBasis FILLER_112 { get; set; } = new StringBasis(new PIC("X", "32", "X(032)"), @"");
                /*"        10  FILLER              PIC  X(001) VALUE  ';'.*/
                public StringBasis FILLER_113 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"        10  FILLER              PIC  X(011) VALUE  'NUM BILHETE'*/
                public StringBasis FILLER_114 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"NUM BILHETE");
                /*"        10  FILLER              PIC  X(004) VALUE  SPACES.*/
                public StringBasis FILLER_115 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                /*"        10  FILLER              PIC  X(001) VALUE  ';'.*/
                public StringBasis FILLER_116 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"        10  FILLER              PIC  X(011) VALUE  'DT QUITACAO'*/
                public StringBasis FILLER_117 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"DT QUITACAO");
                /*"        10  FILLER              PIC  X(001) VALUE  ';'.*/
                public StringBasis FILLER_118 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"        10  FILLER              PIC  X(011) VALUE  'DT PROX QIT'*/
                public StringBasis FILLER_119 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"DT PROX QIT");
                /*"        10  FILLER              PIC  X(001) VALUE  ';'.*/
                public StringBasis FILLER_120 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"        10  FILLER              PIC  X(009) VALUE 'COBERTURA'.*/
                public StringBasis FILLER_121 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"COBERTURA");
                /*"        10  FILLER              PIC  X(011) VALUE  SPACES.*/
                public StringBasis FILLER_122 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"");
                /*"        10  FILLER              PIC  X(001) VALUE  ';'.*/
                public StringBasis FILLER_123 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"        10  FILLER              PIC  X(006) VALUE  'PREMIO'.*/
                public StringBasis FILLER_124 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"PREMIO");
                /*"        10  FILLER              PIC  X(011) VALUE  SPACES.*/
                public StringBasis FILLER_125 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"");
                /*"        10  FILLER              PIC  X(001) VALUE  ';'.*/
                public StringBasis FILLER_126 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"        10  FILLER              PIC  X(008) VALUE  'SITUACAO'.*/
                public StringBasis FILLER_127 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"SITUACAO");
                /*"        10  FILLER              PIC  X(027) VALUE  SPACES.*/
                public StringBasis FILLER_128 { get; set; } = new StringBasis(new PIC("X", "27", "X(027)"), @"");
                /*"        10  FILLER              PIC  X(001) VALUE  ';'.*/
                public StringBasis FILLER_129 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"        10  FILLER              PIC  X(006) VALUE  'MOTIVO'.*/
                public StringBasis FILLER_130 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"MOTIVO");
                /*"        10  FILLER              PIC  X(013) VALUE  SPACES.*/
                public StringBasis FILLER_131 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"");
                /*"        10  FILLER              PIC  X(001) VALUE  ';'.*/
                public StringBasis FILLER_132 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    05  WREG-DETALHE.*/
            }
            public BI0602B_WREG_DETALHE WREG_DETALHE { get; set; } = new BI0602B_WREG_DETALHE();
            public class BI0602B_WREG_DETALHE : VarBasis
            {
                /*"        10 WREG-ANO-EMS         PIC  9(004)     VALUE ZEROS.*/
                public IntBasis WREG_ANO_EMS { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"        10 FILLER               PIC  X(004)     VALUE '   ;'.*/
                public StringBasis FILLER_133 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"   ;");
                /*"        10 WREG-CGCCPF          PIC  9(015)     VALUE ZEROS.*/
                public IntBasis WREG_CGCCPF { get; set; } = new IntBasis(new PIC("9", "15", "9(015)"));
                /*"        10 FILLER               PIC  X(001)     VALUE ';'.*/
                public StringBasis FILLER_134 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"        10 WREG-SEGURADO        PIC  X(040)     VALUE SPACES.*/
                public StringBasis WREG_SEGURADO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"        10 FILLER               PIC  X(001)     VALUE ';'.*/
                public StringBasis FILLER_135 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"        10 WREG-BILHETE         PIC  9(015)     VALUE ZEROS.*/
                public IntBasis WREG_BILHETE { get; set; } = new IntBasis(new PIC("9", "15", "9(015)"));
                /*"        10 FILLER               PIC  X(001)     VALUE ';'.*/
                public StringBasis FILLER_136 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"        10 WREG-INIVIGENCIA     PIC  X(010)     VALUE SPACES.*/
                public StringBasis WREG_INIVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"        10 FILLER               PIC  X(002)     VALUE ' ;'.*/
                public StringBasis FILLER_137 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @" ;");
                /*"        10 WREG-TERVIGENCIA     PIC  X(010)     VALUE SPACES.*/
                public StringBasis WREG_TERVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"        10 FILLER               PIC  X(002)     VALUE ' ;'.*/
                public StringBasis FILLER_138 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @" ;");
                /*"        10 WREG-COBERTURA       PIC  X(020)     VALUE SPACES.*/
                public StringBasis WREG_COBERTURA { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"");
                /*"        10 FILLER               PIC  X(001)     VALUE ';'.*/
                public StringBasis FILLER_139 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"        10 WREG-PREMIO          PIC  9(015)V99  VALUE ZEROS.*/
                public DoubleBasis WREG_PREMIO { get; set; } = new DoubleBasis(new PIC("9", "15", "9(015)V99"), 2);
                /*"        10 FILLER               PIC  X(001)     VALUE ';'.*/
                public StringBasis FILLER_140 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"        10 WREG-DSCR-SITUACAO   PIC  X(035)     VALUE SPACES.*/
                public StringBasis WREG_DSCR_SITUACAO { get; set; } = new StringBasis(new PIC("X", "35", "X(035)"), @"");
                /*"        10 FILLER               PIC  X(001)     VALUE ';'.*/
                public StringBasis FILLER_141 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"        10 WREG-MOTIVO          PIC  X(019)     VALUE SPACES.*/
                public StringBasis WREG_MOTIVO { get; set; } = new StringBasis(new PIC("X", "19", "X(019)"), @"");
                /*"        10 FILLER               PIC  X(001)     VALUE ';'.*/
                public StringBasis FILLER_142 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    05  WREG-TRACOS             PIC  X(200)  VALUE ALL '-'.*/
            }
            public StringBasis WREG_TRACOS { get; set; } = new StringBasis(new PIC("X", "200", "X(200)"), @"ALL");
            /*"    05  WREG-RODAPE.*/
            public BI0602B_WREG_RODAPE WREG_RODAPE { get; set; } = new BI0602B_WREG_RODAPE();
            public class BI0602B_WREG_RODAPE : VarBasis
            {
                /*"        10  FILLER              PIC  X(008)  VALUE 'BI0602B'.*/
                public StringBasis FILLER_143 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"BI0602B");
                /*"        10  FILLER              PIC  X(192)  VALUE  SPACES.*/
                public StringBasis FILLER_144 { get; set; } = new StringBasis(new PIC("X", "192", "X(192)"), @"");
                /*"  05        WABEND.*/
                public BI0602B_WABEND WABEND { get; set; } = new BI0602B_WABEND();
                public class BI0602B_WABEND : VarBasis
                {
                    /*"    10      FILLER              PIC  X(010)     VALUE           ' BI0602B'.*/
                }
            }
            public StringBasis FILLER_145 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" BI0602B");
            /*"    10      FILLER              PIC  X(026)     VALUE           ' *** ERRO EXEC SQL NUMERO '.*/
            public StringBasis FILLER_146 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @" *** ERRO EXEC SQL NUMERO ");
            /*"    10      WNR-EXEC-SQL        PIC  X(004)     VALUE '0000'.*/
            public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"0000");
            /*"    10      FILLER              PIC  X(013)     VALUE           ' *** SQLCODE '.*/
            public StringBasis FILLER_147 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
            /*"    10      WSQLCODE            PIC  ZZZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
        }


        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.BILHETE BILHETE { get; set; } = new Dclgens.BILHETE();
        public Dclgens.CLIENTES CLIENTES { get; set; } = new Dclgens.CLIENTES();
        public Dclgens.MOVDEBCE MOVDEBCE { get; set; } = new Dclgens.MOVDEBCE();
        public Dclgens.PROPOFID PROPOFID { get; set; } = new Dclgens.PROPOFID();
        public Dclgens.UNIDACEF UNIDACEF { get; set; } = new Dclgens.UNIDACEF();
        public Dclgens.PROPOVA PROPOVA { get; set; } = new Dclgens.PROPOVA();
        public Dclgens.ARQSIVPF ARQSIVPF { get; set; } = new Dclgens.ARQSIVPF();
        public BI0602B_CORIGEM CORIGEM { get; set; } = new BI0602B_CORIGEM();

        public BI0602B_CURSOR01 CURSOR01 { get; set; } = new BI0602B_CURSOR01(true);
        string GetQuery_CURSOR01()
        {
            var query = @$"SELECT 'REDE1'
							, NUM_PROPOSTA_SIVPF
							, COD_PRODUTO_SIVPF
							, ORIGEM_PROPOSTA
							, DATA_PROPOSTA
							, DIA_DEBITO
							, NUM_SICOB
							, SIT_PROPOSTA
							, AGECOBR
							, VAL_PAGO
							FROM SEGUROS.PROPOSTA_FIDELIZ WHERE COD_PRODUTO_SIVPF IN (9
							,11) AND DATA_PROPOSTA BETWEEN '{AREA_DE_WORK.WS_DATA_INICIO}' AND '{AREA_DE_WORK.WS_DATA_FINAL}' AND NUM_PROPOSTA_SIVPF BETWEEN 50000000000000 AND 59999999999999 UNION SELECT 'REDE2'
							, NUM_PROPOSTA_SIVPF
							, COD_PRODUTO_SIVPF
							, ORIGEM_PROPOSTA
							, DATA_PROPOSTA
							, DIA_DEBITO
							, NUM_SICOB
							, SIT_PROPOSTA
							, AGECOBR
							, VAL_PAGO
							FROM SEGUROS.PROPOSTA_FIDELIZ WHERE COD_PRODUTO_SIVPF = 9 AND DATA_PROPOSTA BETWEEN '{AREA_DE_WORK.WS_DATA_INICIO}' AND '{AREA_DE_WORK.WS_DATA_FINAL}' AND NUM_PROPOSTA_SIVPF BETWEEN 90000000000000 AND 99999999999999 UNION SELECT 'EXTRA-REDE'
							, NUM_PROPOSTA_SIVPF
							, COD_PRODUTO_SIVPF
							, ORIGEM_PROPOSTA
							, DATA_PROPOSTA
							, DIA_DEBITO
							, NUM_SICOB
							, SIT_PROPOSTA
							, AGECOBR
							, VAL_PAGO
							FROM SEGUROS.PROPOSTA_FIDELIZ WHERE DATA_PROPOSTA BETWEEN '{AREA_DE_WORK.WS_DATA_INICIO}' AND '{AREA_DE_WORK.WS_DATA_FINAL}' AND ORIGEM_PROPOSTA > 1000 UNION SELECT 'CENTRAL CAIXA SEGUROS'
							, NUM_PROPOSTA_SIVPF
							, COD_PRODUTO_SIVPF
							, ORIGEM_PROPOSTA
							, DATA_PROPOSTA
							, DIA_DEBITO
							, NUM_SICOB
							, SIT_PROPOSTA
							, AGECOBR
							, VAL_PAGO
							FROM SEGUROS.PROPOSTA_FIDELIZ WHERE ORIGEM_PROPOSTA = 12 AND DATA_PROPOSTA BETWEEN '{AREA_DE_WORK.WS_DATA_INICIO}' AND '{AREA_DE_WORK.WS_DATA_FINAL}' ORDER BY COD_PRODUTO_SIVPF
							, DATA_PROPOSTA DESC";

            return query;
        }


        public BI0602B_CURSOR02 CURSOR02 { get; set; } = new BI0602B_CURSOR02(true);
        string GetQuery_CURSOR02()
        {
            var query = @$"SELECT CODRET
							, DTVENCTO
							, TIMESTAMP
							FROM SEGUROS.V0HISTCONTAVA WHERE NRCERTIF = '{WS_HISTCON_NRCERTIF}' AND NRPARCEL = 1 AND TIPLANC = '1'";

            return query;
        }

        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string RELATORIO_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                RELATORIO.SetFile(RELATORIO_FILE_NAME_P);
                InitializeGetQuery();

                /*" -0- FLUXCONTROL_PERFORM R0000-00-PROCESSO-PROGRAMA-SECTION */

                R0000_00_PROCESSO_PROGRAMA_SECTION();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { CodigoRetorno = RETURN_CODE.Value };
            return Result;
        }

        public void InitializeGetQuery()
        {
            CURSOR01.GetQueryEvent += GetQuery_CURSOR01;
            CURSOR02.GetQueryEvent += GetQuery_CURSOR02;
        }

        [StopWatch]
        /*" R0000-00-PROCESSO-PROGRAMA-SECTION */
        private void R0000_00_PROCESSO_PROGRAMA_SECTION()
        {
            /*" -603- MOVE '0000' TO WNR-EXEC-SQL. */
            _.Move("0000", AREA_DE_WORK.WNR_EXEC_SQL);

            /*" -604- DISPLAY '-------------------------------------------' . */
            _.Display($"-------------------------------------------");

            /*" -605- DISPLAY 'PROGRAMA EM EXECUCAO: BI0602B              ' . */
            _.Display($"PROGRAMA EM EXECUCAO: BI0602B              ");

            /*" -606- DISPLAY '                                           ' . */
            _.Display($"                                           ");

            /*" -610- DISPLAY 'VERSAO: V.09 / CAD-74.516 / DATA:25/09/2012' . */
            _.Display($"VERSAO: V.09 / CAD-74.516 / DATA:25/09/2012");

            /*" -611- DISPLAY '                                           ' . */
            _.Display($"                                           ");

            /*" -613- DISPLAY '-------------------------------------------' . */
            _.Display($"-------------------------------------------");

            /*" -613- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -614- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -615- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -619- PERFORM R0100-00-PROCESSO-INICIAL. */

            R0100_00_PROCESSO_INICIAL_SECTION();

            /*" -621- PERFORM R1000-00-PROCESSO-PRINCIPAL. */

            R1000_00_PROCESSO_PRINCIPAL_SECTION();

            /*" -623- PERFORM R9000-00-PROCESSO-FINAL. */

            R9000_00_PROCESSO_FINAL_SECTION();

            /*" -623- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" R0100-00-PROCESSO-INICIAL-SECTION */
        private void R0100_00_PROCESSO_INICIAL_SECTION()
        {
            /*" -630- MOVE '0100' TO WNR-EXEC-SQL. */
            _.Move("0100", AREA_DE_WORK.WNR_EXEC_SQL);

            /*" -633- MOVE ZERO TO TESTA-FIM-CURS01 WS-ACABOU-PESQ. */
            _.Move(0, TESTA_FIM_CURS01, WS_ACABOU_PESQ);

            /*" -634- MOVE '00/00/0000' TO WS-DATA-CURR */
            _.Move("00/00/0000", AREA_DE_WORK.WS_DATA_CURR);

            /*" -635- MOVE '0000-00-00' TO WS-DATA-HOJE */
            _.Move("0000-00-00", AREA_DE_WORK.WS_DATA_HOJE);

            /*" -636- ACCEPT WS-DATA-ACCEPT FROM DATE */
            _.Move(_.AcceptDate("DATE"), AREA_DE_WORK.WS_DATA_ACCEPT);

            /*" -637- MOVE WS-DIA-ACCEPT TO WS-DIA-CURR WS-DIA-HOJE */
            _.Move(AREA_DE_WORK.WS_DATA_ACCEPT.WS_DIA_ACCEPT, AREA_DE_WORK.WS_DATA_CURR.WS_DIA_CURR, AREA_DE_WORK.WS_DATA_HOJE_AUX.WS_DIA_HOJE);

            /*" -638- MOVE WS-MES-ACCEPT TO WS-MES-CURR WS-MES-HOJE */
            _.Move(AREA_DE_WORK.WS_DATA_ACCEPT.WS_MES_ACCEPT, AREA_DE_WORK.WS_DATA_CURR.WS_MES_CURR, AREA_DE_WORK.WS_DATA_HOJE_AUX.WS_MES_HOJE);

            /*" -639- MOVE WS-ANO-ACCEPT TO WS-ANO-CURR WS-ANO-HOJE */
            _.Move(AREA_DE_WORK.WS_DATA_ACCEPT.WS_ANO_ACCEPT, AREA_DE_WORK.WS_DATA_CURR.WS_ANO_CURR, AREA_DE_WORK.WS_DATA_HOJE_AUX.WS_ANO_HOJE);

            /*" -640- ADD 2000 TO WS-ANO-CURR WS-ANO-HOJE */
            AREA_DE_WORK.WS_DATA_CURR.WS_ANO_CURR.Value = AREA_DE_WORK.WS_DATA_CURR.WS_ANO_CURR + 2000;
            AREA_DE_WORK.WS_DATA_HOJE_AUX.WS_ANO_HOJE.Value = AREA_DE_WORK.WS_DATA_HOJE_AUX.WS_ANO_HOJE + 2000;

            /*" -642- MOVE WS-DATA-HOJE-AUX TO WS-DATA-HOJE. */
            _.Move(AREA_DE_WORK.WS_DATA_HOJE_AUX, AREA_DE_WORK.WS_DATA_HOJE);

            /*" -643- MOVE '00:00:00' TO WS-HORA-CURR */
            _.Move("00:00:00", AREA_DE_WORK.WS_HORA_CURR);

            /*" -644- ACCEPT WS-HORA-ACCEPT FROM TIME */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WS_HORA_ACCEPT);

            /*" -645- MOVE WS-HOR-ACCEPT TO WS-HOR-CURR */
            _.Move(AREA_DE_WORK.WS_HORA_ACCEPT.WS_HOR_ACCEPT, AREA_DE_WORK.WS_HORA_CURR.WS_HOR_CURR);

            /*" -646- MOVE WS-MIN-ACCEPT TO WS-MIN-CURR */
            _.Move(AREA_DE_WORK.WS_HORA_ACCEPT.WS_MIN_ACCEPT, AREA_DE_WORK.WS_HORA_CURR.WS_MIN_CURR);

            /*" -648- MOVE WS-SEG-ACCEPT TO WS-SEG-CURR. */
            _.Move(AREA_DE_WORK.WS_HORA_ACCEPT.WS_SEG_ACCEPT, AREA_DE_WORK.WS_HORA_CURR.WS_SEG_CURR);

            /*" -651- DISPLAY 'BI0602B - Inicio de execucao (' WS-DATA-CURR ' - ' WS-HORA-CURR ')' . */

            $"BI0602B - Inicio de execucao ({AREA_DE_WORK.WS_DATA_CURR} - {AREA_DE_WORK.WS_HORA_CURR})"
            .Display();

            /*" -654- OPEN OUTPUT RELATORIO. */
            RELATORIO.Open(REG_RELAT);

            /*" -655- PERFORM R0200-00-SELECT-SISTEMAS. */

            R0200_00_SELECT_SISTEMAS_SECTION();

            /*" -655- PERFORM R0250-00-CARREGA-ORIGEM. */

            R0250_00_CARREGA_ORIGEM_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/

        [StopWatch]
        /*" R0200-00-SELECT-SISTEMAS-SECTION */
        private void R0200_00_SELECT_SISTEMAS_SECTION()
        {
            /*" -666- MOVE '0200' TO WNR-EXEC-SQL. */
            _.Move("0200", AREA_DE_WORK.WNR_EXEC_SQL);

            /*" -671- PERFORM R0200_00_SELECT_SISTEMAS_DB_SELECT_1 */

            R0200_00_SELECT_SISTEMAS_DB_SELECT_1();

            /*" -674- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -675- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, AREA_DE_WORK.WSQLCODE);

                /*" -676- DISPLAY 'ERRO SELECT SISTEMAS (BI)' */
                _.Display($"ERRO SELECT SISTEMAS (BI)");

                /*" -678- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -681- MOVE SISTEMAS-DATA-MOV-ABERTO TO CABEC0-DTPROC. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, REG_CABEC0.CABEC0_DTPROC);

            /*" -683- MOVE SISTEMAS-DATA-MOV-ABERTO TO WS-DATA-FINAL. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, AREA_DE_WORK.WS_DATA_FINAL);

            /*" -685- MOVE SISTEMAS-DATA-MOV-ABERTO TO WS-DATA-INICIO. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, AREA_DE_WORK.WS_DATA_INICIO);

            /*" -686- MOVE 01 TO WS-DIA-INICIO. */
            _.Move(01, AREA_DE_WORK.FILLER_99.WS_DIA_INICIO);

            /*" -688- MOVE 01 TO WS-MES-INICIO. */
            _.Move(01, AREA_DE_WORK.FILLER_99.WS_MES_INICIO);

            /*" -689- WRITE REG-RELAT FROM REG-CABEC0. */
            _.Move(REG_CABEC0.GetMoveValues(), REG_RELAT);

            RELATORIO.Write(REG_RELAT.GetMoveValues().ToString());

            /*" -689- WRITE REG-RELAT FROM REG-CABEC. */
            _.Move(REG_CABEC.GetMoveValues(), REG_RELAT);

            RELATORIO.Write(REG_RELAT.GetMoveValues().ToString());

        }

        [StopWatch]
        /*" R0200-00-SELECT-SISTEMAS-DB-SELECT-1 */
        public void R0200_00_SELECT_SISTEMAS_DB_SELECT_1()
        {
            /*" -671- EXEC SQL SELECT DATA_MOV_ABERTO INTO :SISTEMAS-DATA-MOV-ABERTO FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'BI' END-EXEC. */

            var r0200_00_SELECT_SISTEMAS_DB_SELECT_1_Query1 = new R0200_00_SELECT_SISTEMAS_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0200_00_SELECT_SISTEMAS_DB_SELECT_1_Query1.Execute(r0200_00_SELECT_SISTEMAS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_99_SAIDA*/

        [StopWatch]
        /*" R0250-00-CARREGA-ORIGEM-SECTION */
        private void R0250_00_CARREGA_ORIGEM_SECTION()
        {
            /*" -699- MOVE '0250' TO WNR-EXEC-SQL. */
            _.Move("0250", AREA_DE_WORK.WNR_EXEC_SQL);

            /*" -705- PERFORM R0250_00_CARREGA_ORIGEM_DB_DECLARE_1 */

            R0250_00_CARREGA_ORIGEM_DB_DECLARE_1();

            /*" -707- PERFORM R0250_00_CARREGA_ORIGEM_DB_OPEN_1 */

            R0250_00_CARREGA_ORIGEM_DB_OPEN_1();

            /*" -710- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -711- DISPLAY 'PROBLEMAS NO OPEN CORIGEM ' */
                _.Display($"PROBLEMAS NO OPEN CORIGEM ");

                /*" -713- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -715- MOVE '0251' TO WNR-EXEC-SQL. */
            _.Move("0251", AREA_DE_WORK.WNR_EXEC_SQL);

            /*" -716- PERFORM UNTIL WFIM-SISTEMA-ORIGEM EQUAL 'SIM' */

            while (!(WORK_AREA.WFIM_SISTEMA_ORIGEM == "SIM"))
            {

                /*" -718- PERFORM R0250_00_CARREGA_ORIGEM_DB_FETCH_1 */

                R0250_00_CARREGA_ORIGEM_DB_FETCH_1();

                /*" -720- IF SQLCODE EQUAL ZEROS */

                if (DB.SQLCODE == 00)
                {

                    /*" -721- ADD 1 TO WIND1 */
                    WORK_AREA.WIND1.Value = WORK_AREA.WIND1 + 1;

                    /*" -723- MOVE ARQSIVPF-SISTEMA-ORIGEM TO WTAB-SISTEMA-ORIGEM (WIND1) */
                    _.Move(ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SISTEMA_ORIGEM, W_TAB_SISTEMA_ORIGEM.WTAB_SISTEMA_ORIGEM[WORK_AREA.WIND1]);

                    /*" -724- ELSE */
                }
                else
                {


                    /*" -725- IF SQLCODE EQUAL 100 */

                    if (DB.SQLCODE == 100)
                    {

                        /*" -726- MOVE 'SIM' TO WFIM-SISTEMA-ORIGEM */
                        _.Move("SIM", WORK_AREA.WFIM_SISTEMA_ORIGEM);

                        /*" -726- PERFORM R0250_00_CARREGA_ORIGEM_DB_CLOSE_1 */

                        R0250_00_CARREGA_ORIGEM_DB_CLOSE_1();

                        /*" -728- ELSE */
                    }
                    else
                    {


                        /*" -729- DISPLAY 'PROBLEMAS NO FETCH CORIGEM ' */
                        _.Display($"PROBLEMAS NO FETCH CORIGEM ");

                        /*" -730- GO TO R9999-00-ROT-ERRO */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;

                        /*" -731- END-IF */
                    }


                    /*" -732- END-IF */
                }


                /*" -732- END-PERFORM. */
            }

        }

        [StopWatch]
        /*" R0250-00-CARREGA-ORIGEM-DB-DECLARE-1 */
        public void R0250_00_CARREGA_ORIGEM_DB_DECLARE_1()
        {
            /*" -705- EXEC SQL DECLARE CORIGEM CURSOR FOR SELECT SISTEMA_ORIGEM FROM SEGUROS.ARQUIVOS_SIVPF WHERE DATA_GERACAO = '9999-12-31' AND QTDE_REG_GER = 981 ORDER BY SISTEMA_ORIGEM END-EXEC. */
            CORIGEM = new BI0602B_CORIGEM(false);
            string GetQuery_CORIGEM()
            {
                var query = @$"SELECT SISTEMA_ORIGEM 
							FROM SEGUROS.ARQUIVOS_SIVPF 
							WHERE DATA_GERACAO = '9999-12-31' 
							AND QTDE_REG_GER = 981 
							ORDER BY SISTEMA_ORIGEM";

                return query;
            }
            CORIGEM.GetQueryEvent += GetQuery_CORIGEM;

        }

        [StopWatch]
        /*" R0250-00-CARREGA-ORIGEM-DB-OPEN-1 */
        public void R0250_00_CARREGA_ORIGEM_DB_OPEN_1()
        {
            /*" -707- EXEC SQL OPEN CORIGEM END-EXEC. */

            CORIGEM.Open();

        }

        [StopWatch]
        /*" R0250-00-CARREGA-ORIGEM-DB-FETCH-1 */
        public void R0250_00_CARREGA_ORIGEM_DB_FETCH_1()
        {
            /*" -718- EXEC SQL FETCH CORIGEM INTO :ARQSIVPF-SISTEMA-ORIGEM END-EXEC */

            if (CORIGEM.Fetch())
            {
                _.Move(CORIGEM.ARQSIVPF_SISTEMA_ORIGEM, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SISTEMA_ORIGEM);
            }

        }

        [StopWatch]
        /*" R0250-00-CARREGA-ORIGEM-DB-CLOSE-1 */
        public void R0250_00_CARREGA_ORIGEM_DB_CLOSE_1()
        {
            /*" -726- EXEC SQL CLOSE CORIGEM END-EXEC */

            CORIGEM.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0250_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSO-PRINCIPAL-SECTION */
        private void R1000_00_PROCESSO_PRINCIPAL_SECTION()
        {
            /*" -742- MOVE '1000' TO WNR-EXEC-SQL. */
            _.Move("1000", AREA_DE_WORK.WNR_EXEC_SQL);

            /*" -744- PERFORM R1400-00-OPEN-CURSOR01. */

            R1400_00_OPEN_CURSOR01_SECTION();

            /*" -745- PERFORM R1500-00-FETCH-CURSOR01. */

            R1500_00_FETCH_CURSOR01_SECTION();

            /*" -746- IF FIM-CURSOR01 */

            if (TESTA_FIM_CURS01["FIM_CURSOR01"])
            {

                /*" -747- GO TO R1000-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/ //GOTO
                return;

                /*" -749- END-IF. */
            }


            /*" -749- PERFORM R1600-00-PROCESSA-CURSOR01 UNTIL FIM-CURSOR01. */

            while (!(TESTA_FIM_CURS01["FIM_CURSOR01"]))
            {

                R1600_00_PROCESSA_CURSOR01_SECTION();
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1010-00-VERIFICA-ORIGEM-SECTION */
        private void R1010_00_VERIFICA_ORIGEM_SECTION()
        {
            /*" -759- MOVE '1010' TO WNR-EXEC-SQL. */
            _.Move("1010", AREA_DE_WORK.WNR_EXEC_SQL);

            /*" -760- MOVE 1 TO WINF. */
            _.Move(1, WORK_AREA.WINF);

            /*" -761- MOVE WIND1 TO WSUP. */
            _.Move(WORK_AREA.WIND1, WORK_AREA.WSUP);

            /*" -763- MOVE SPACES TO WTEM-SISTEMA-ORIGEM */
            _.Move("", WORK_AREA.WTEM_SISTEMA_ORIGEM);

            /*" -764- PERFORM UNTIL WTEM-SISTEMA-ORIGEM NOT EQUAL SPACES */

            while (!(!WORK_AREA.WTEM_SISTEMA_ORIGEM.IsEmpty()))
            {

                /*" -765- IF WINF > WSUP */

                if (WORK_AREA.WINF > WORK_AREA.WSUP)
                {

                    /*" -766- MOVE 'NAO' TO WTEM-SISTEMA-ORIGEM */
                    _.Move("NAO", WORK_AREA.WTEM_SISTEMA_ORIGEM);

                    /*" -767- ELSE */
                }
                else
                {


                    /*" -768- COMPUTE WIND = (WSUP + WINF) / 2 */
                    WORK_AREA.WIND.Value = (WORK_AREA.WSUP + WORK_AREA.WINF) / 2;

                    /*" -770- IF PROPOFID-ORIGEM-PROPOSTA < WTAB-SISTEMA-ORIGEM(WIND) */

                    if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_ORIGEM_PROPOSTA < W_TAB_SISTEMA_ORIGEM.WTAB_SISTEMA_ORIGEM[WORK_AREA.WIND])
                    {

                        /*" -771- COMPUTE WSUP = WIND - 1 */
                        WORK_AREA.WSUP.Value = WORK_AREA.WIND - 1;

                        /*" -772- ELSE */
                    }
                    else
                    {


                        /*" -774- IF PROPOFID-ORIGEM-PROPOSTA > WTAB-SISTEMA-ORIGEM(WIND) */

                        if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_ORIGEM_PROPOSTA > W_TAB_SISTEMA_ORIGEM.WTAB_SISTEMA_ORIGEM[WORK_AREA.WIND])
                        {

                            /*" -775- COMPUTE WINF = WIND + 1 */
                            WORK_AREA.WINF.Value = WORK_AREA.WIND + 1;

                            /*" -776- ELSE */
                        }
                        else
                        {


                            /*" -777- MOVE 'SIM' TO WTEM-SISTEMA-ORIGEM */
                            _.Move("SIM", WORK_AREA.WTEM_SISTEMA_ORIGEM);

                            /*" -778- END-IF */
                        }


                        /*" -779- END-IF */
                    }


                    /*" -780- END-IF */
                }


                /*" -780- END-PERFORM. */
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1010_99_SAIDA*/

        [StopWatch]
        /*" R1400-00-OPEN-CURSOR01-SECTION */
        private void R1400_00_OPEN_CURSOR01_SECTION()
        {
            /*" -790- MOVE '1400' TO WNR-EXEC-SQL. */
            _.Move("1400", AREA_DE_WORK.WNR_EXEC_SQL);

            /*" -790- PERFORM R1400_00_OPEN_CURSOR01_DB_OPEN_1 */

            R1400_00_OPEN_CURSOR01_DB_OPEN_1();

            /*" -792- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -793- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, AREA_DE_WORK.WSQLCODE);

                /*" -794- DISPLAY 'ERRO OPEN CURSOR01' */
                _.Display($"ERRO OPEN CURSOR01");

                /*" -795- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -795- END-IF. */
            }


        }

        [StopWatch]
        /*" R1400-00-OPEN-CURSOR01-DB-OPEN-1 */
        public void R1400_00_OPEN_CURSOR01_DB_OPEN_1()
        {
            /*" -790- EXEC SQL OPEN CURSOR01 END-EXEC. */

            CURSOR01.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1400_99_SAIDA*/

        [StopWatch]
        /*" R1500-00-FETCH-CURSOR01-SECTION */
        private void R1500_00_FETCH_CURSOR01_SECTION()
        {
            /*" -805- MOVE '1500' TO WNR-EXEC-SQL. */
            _.Move("1500", AREA_DE_WORK.WNR_EXEC_SQL);

            /*" -817- PERFORM R1500_00_FETCH_CURSOR01_DB_FETCH_1 */

            R1500_00_FETCH_CURSOR01_DB_FETCH_1();

            /*" -820- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -821- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -822- MOVE 1 TO TESTA-FIM-CURS01 */
                    _.Move(1, TESTA_FIM_CURS01);

                    /*" -822- PERFORM R1500_00_FETCH_CURSOR01_DB_CLOSE_1 */

                    R1500_00_FETCH_CURSOR01_DB_CLOSE_1();

                    /*" -824- GO TO R1500-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1500_99_SAIDA*/ //GOTO
                    return;

                    /*" -825- ELSE */
                }
                else
                {


                    /*" -826- MOVE SQLCODE TO WSQLCODE */
                    _.Move(DB.SQLCODE, AREA_DE_WORK.WSQLCODE);

                    /*" -827- DISPLAY 'ERRO FETCH CURSOR01 SQLCODE = ' WSQLCODE */
                    _.Display($"ERRO FETCH CURSOR01 SQLCODE = {AREA_DE_WORK.WSQLCODE}");

                    /*" -828- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -829- END-IF */
                }


                /*" -831- END-IF. */
            }


            /*" -833- ADD 1 TO WS-TOT-LIDOS WSCONTA. */
            AREA_DE_WORK.WS_TOT_LIDOS.Value = AREA_DE_WORK.WS_TOT_LIDOS + 1;
            WSCONTA.Value = WSCONTA + 1;

            /*" -834- IF WSCONTA > 9999 */

            if (WSCONTA > 9999)
            {

                /*" -835- MOVE ZEROS TO WSCONTA */
                _.Move(0, WSCONTA);

                /*" -836- ACCEPT WS-TIME FROM TIME */
                _.Move(_.AcceptDate("TIME"), WS_TIME);

                /*" -839- DISPLAY 'LIDOS .... ' WS-TOT-LIDOS ' ' PROPOFID-NUM-PROPOSTA-SIVPF ' ' WS-TIME */

                $"LIDOS .... {AREA_DE_WORK.WS_TOT_LIDOS} {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF} {WS_TIME}"
                .Display();

                /*" -841- END-IF. */
            }


            /*" -844- COMPUTE WS-QTDE-A-RENOVAR = WS-ANO-CURR - WS-ANO-QUIT. */
            AREA_DE_WORK.WS_QTDE_A_RENOVAR.Value = AREA_DE_WORK.WS_DATA_CURR.WS_ANO_CURR - WS_DT_QUIT_RED.WS_ANO_QUIT;

            /*" -846- MOVE PROPOFID-NUM-SICOB TO WS-BILHETE-AUX. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_SICOB, WS_BILHETE_AUX);

            /*" -849- MOVE PROPOFID-NUM-PROPOSTA-SIVPF TO WS-HISTCON-NRCERTIF. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF, WS_HISTCON_NRCERTIF);

            /*" -852- MOVE PROPOFID-NUM-PROPOSTA-SIVPF TO WS-NUM-PROPOSTA. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF, WS_NUM_PROPOSTA);

            /*" -853- MOVE WS-NUM-PROPOSTA(3:4) TO WHOST-COD-UNIDADE. */
            _.Move(WS_NUM_PROPOSTA.Substring(3, 4), WHOST_COD_UNIDADE);

        }

        [StopWatch]
        /*" R1500-00-FETCH-CURSOR01-DB-FETCH-1 */
        public void R1500_00_FETCH_CURSOR01_DB_FETCH_1()
        {
            /*" -817- EXEC SQL FETCH CURSOR01 INTO :WHOST-CANAL-DE-VENDA , :PROPOFID-NUM-PROPOSTA-SIVPF , :PROPOFID-COD-PRODUTO-SIVPF , :PROPOFID-ORIGEM-PROPOSTA , :PROPOFID-DATA-PROPOSTA , :PROPOFID-DIA-DEBITO , :PROPOFID-NUM-SICOB , :PROPOFID-SIT-PROPOSTA , :PROPOFID-AGECOBR , :PROPOFID-VAL-PAGO END-EXEC. */

            if (CURSOR01.Fetch())
            {
                _.Move(CURSOR01.WHOST_CANAL_DE_VENDA, WHOST_CANAL_DE_VENDA);
                _.Move(CURSOR01.PROPOFID_NUM_PROPOSTA_SIVPF, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF);
                _.Move(CURSOR01.PROPOFID_COD_PRODUTO_SIVPF, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF);
                _.Move(CURSOR01.PROPOFID_ORIGEM_PROPOSTA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_ORIGEM_PROPOSTA);
                _.Move(CURSOR01.PROPOFID_DATA_PROPOSTA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_PROPOSTA);
                _.Move(CURSOR01.PROPOFID_DIA_DEBITO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DIA_DEBITO);
                _.Move(CURSOR01.PROPOFID_NUM_SICOB, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_SICOB);
                _.Move(CURSOR01.PROPOFID_SIT_PROPOSTA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_SIT_PROPOSTA);
                _.Move(CURSOR01.PROPOFID_AGECOBR, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGECOBR);
                _.Move(CURSOR01.PROPOFID_VAL_PAGO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_VAL_PAGO);
            }

        }

        [StopWatch]
        /*" R1500-00-FETCH-CURSOR01-DB-CLOSE-1 */
        public void R1500_00_FETCH_CURSOR01_DB_CLOSE_1()
        {
            /*" -822- EXEC SQL CLOSE CURSOR01 END-EXEC */

            CURSOR01.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1500_99_SAIDA*/

        [StopWatch]
        /*" R1501-00-SELECT-BILHETE-SECTION */
        private void R1501_00_SELECT_BILHETE_SECTION()
        {
            /*" -863- MOVE '1501' TO WNR-EXEC-SQL. */
            _.Move("1501", AREA_DE_WORK.WNR_EXEC_SQL);

            /*" -865- INITIALIZE DCLBILHETE. */
            _.Initialize(
                BILHETE.DCLBILHETE
            );

            /*" -867- MOVE 'S' TO WTEM-BILHETE */
            _.Move("S", WTEM_BILHETE);

            /*" -891- PERFORM R1501_00_SELECT_BILHETE_DB_SELECT_1 */

            R1501_00_SELECT_BILHETE_DB_SELECT_1();

            /*" -894- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -895- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -896- MOVE 'N' TO WTEM-BILHETE */
                    _.Move("N", WTEM_BILHETE);

                    /*" -897- ELSE */
                }
                else
                {


                    /*" -899- DISPLAY 'ERRO SELECT SEGUROS.BILHETE BILHETE = ' WS-BILHETE-AUX */
                    _.Display($"ERRO SELECT SEGUROS.BILHETE BILHETE = {WS_BILHETE_AUX}");

                    /*" -900- MOVE SQLCODE TO WSQLCODE */
                    _.Move(DB.SQLCODE, AREA_DE_WORK.WSQLCODE);

                    /*" -902- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -903- IF WTEM-BILHETE = 'S' */

            if (WTEM_BILHETE == "S")
            {

                /*" -904- MOVE '1592' TO WNR-EXEC-SQL */
                _.Move("1592", AREA_DE_WORK.WNR_EXEC_SQL);

                /*" -905- INITIALIZE DCLCLIENTES */
                _.Initialize(
                    CLIENTES.DCLCLIENTES
                );

                /*" -911- PERFORM R1501_00_SELECT_BILHETE_DB_SELECT_2 */

                R1501_00_SELECT_BILHETE_DB_SELECT_2();

                /*" -913- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -914- IF SQLCODE EQUAL 100 */

                    if (DB.SQLCODE == 100)
                    {

                        /*" -915- MOVE ZEROS TO CLIENTES-CGCCPF */
                        _.Move(0, CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF);

                        /*" -916- ELSE */
                    }
                    else
                    {


                        /*" -918- DISPLAY 'ERRO SELECT SEGUROS.CLIENTE BILHETE = ' WS-BILHETE-AUX */
                        _.Display($"ERRO SELECT SEGUROS.CLIENTE BILHETE = {WS_BILHETE_AUX}");

                        /*" -919- MOVE SQLCODE TO WSQLCODE */
                        _.Move(DB.SQLCODE, AREA_DE_WORK.WSQLCODE);

                        /*" -919- GO TO R9999-00-ROT-ERRO. */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;
                    }

                }

            }


        }

        [StopWatch]
        /*" R1501-00-SELECT-BILHETE-DB-SELECT-1 */
        public void R1501_00_SELECT_BILHETE_DB_SELECT_1()
        {
            /*" -891- EXEC SQL SELECT NUM_BILHETE , NUM_APOLICE , COD_CLIENTE , OPC_COBERTURA , VAL_RCAP , DATA_QUITACAO , DATA_QUITACAO + 1 YEAR , SITUACAO , TIP_CANCELAMENTO , SIT_SINISTRO INTO :WS-BILHETE-AUX , :WS-APOLICE-AUX , :WS-CLIENTE-AUX , :WS-OPC-COBERT-AUX , :WS-VAL-RCAP-AUX , :WS-DATA-QUITACAO-AUX , :WS-PROXIMA-DT-QUIT , :WS-SITUACAO , :WS-TIP-CANCELAMENTO , :WS-SIT-SINISTRO FROM SEGUROS.BILHETE WHERE NUM_BILHETE = :WS-BILHETE-AUX END-EXEC. */

            var r1501_00_SELECT_BILHETE_DB_SELECT_1_Query1 = new R1501_00_SELECT_BILHETE_DB_SELECT_1_Query1()
            {
                WS_BILHETE_AUX = WS_BILHETE_AUX.ToString(),
            };

            var executed_1 = R1501_00_SELECT_BILHETE_DB_SELECT_1_Query1.Execute(r1501_00_SELECT_BILHETE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_BILHETE_AUX, WS_BILHETE_AUX);
                _.Move(executed_1.WS_APOLICE_AUX, WS_APOLICE_AUX);
                _.Move(executed_1.WS_CLIENTE_AUX, WS_CLIENTE_AUX);
                _.Move(executed_1.WS_OPC_COBERT_AUX, WS_OPC_COBERT_AUX);
                _.Move(executed_1.WS_VAL_RCAP_AUX, WS_VAL_RCAP_AUX);
                _.Move(executed_1.WS_DATA_QUITACAO_AUX, WS_DATA_QUITACAO_AUX);
                _.Move(executed_1.WS_PROXIMA_DT_QUIT, WS_PROXIMA_DT_QUIT);
                _.Move(executed_1.WS_SITUACAO, WS_SITUACAO);
                _.Move(executed_1.WS_TIP_CANCELAMENTO, WS_TIP_CANCELAMENTO);
                _.Move(executed_1.WS_SIT_SINISTRO, WS_SIT_SINISTRO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1501_99_SAIDA*/

        [StopWatch]
        /*" R1501-00-SELECT-BILHETE-DB-SELECT-2 */
        public void R1501_00_SELECT_BILHETE_DB_SELECT_2()
        {
            /*" -911- EXEC SQL SELECT CGCCPF INTO :CLIENTES-CGCCPF FROM SEGUROS.CLIENTES WHERE COD_CLIENTE = :WS-CLIENTE-AUX END-EXEC */

            var r1501_00_SELECT_BILHETE_DB_SELECT_2_Query1 = new R1501_00_SELECT_BILHETE_DB_SELECT_2_Query1()
            {
                WS_CLIENTE_AUX = WS_CLIENTE_AUX.ToString(),
            };

            var executed_1 = R1501_00_SELECT_BILHETE_DB_SELECT_2_Query1.Execute(r1501_00_SELECT_BILHETE_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CLIENTES_CGCCPF, CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF);
            }


        }

        [StopWatch]
        /*" R1502-00-SELECT-UNIDACEF-SECTION */
        private void R1502_00_SELECT_UNIDACEF_SECTION()
        {
            /*" -929- MOVE '1502' TO WNR-EXEC-SQL. */
            _.Move("1502", AREA_DE_WORK.WNR_EXEC_SQL);

            /*" -931- INITIALIZE DCLUNIDADE-CEF. */
            _.Initialize(
                UNIDACEF.DCLUNIDADE_CEF
            );

            /*" -934- MOVE WHOST-COD-UNIDADE TO UNIDACEF-COD-UNIDADE. */
            _.Move(WHOST_COD_UNIDADE, UNIDACEF.DCLUNIDADE_CEF.UNIDACEF_COD_UNIDADE);

            /*" -940- PERFORM R1502_00_SELECT_UNIDACEF_DB_SELECT_1 */

            R1502_00_SELECT_UNIDACEF_DB_SELECT_1();

            /*" -943- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -944- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -946- MOVE 'UNIDADE NAO CADASTRADA' TO UNIDACEF-NOME-UNIDADE */
                    _.Move("UNIDADE NAO CADASTRADA", UNIDACEF.DCLUNIDADE_CEF.UNIDACEF_NOME_UNIDADE);

                    /*" -947- ELSE */
                }
                else
                {


                    /*" -949- DISPLAY 'ERRO SELECT SEGUROS.UNIDADE_CEF UNIDADE = ' UNIDACEF-COD-UNIDADE */
                    _.Display($"ERRO SELECT SEGUROS.UNIDADE_CEF UNIDADE = {UNIDACEF.DCLUNIDADE_CEF.UNIDACEF_COD_UNIDADE}");

                    /*" -950- MOVE SQLCODE TO WSQLCODE */
                    _.Move(DB.SQLCODE, AREA_DE_WORK.WSQLCODE);

                    /*" -950- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R1502-00-SELECT-UNIDACEF-DB-SELECT-1 */
        public void R1502_00_SELECT_UNIDACEF_DB_SELECT_1()
        {
            /*" -940- EXEC SQL SELECT NOME_UNIDADE INTO :UNIDACEF-NOME-UNIDADE FROM SEGUROS.UNIDADE_CEF WHERE COD_UNIDADE = :UNIDACEF-COD-UNIDADE END-EXEC. */

            var r1502_00_SELECT_UNIDACEF_DB_SELECT_1_Query1 = new R1502_00_SELECT_UNIDACEF_DB_SELECT_1_Query1()
            {
                UNIDACEF_COD_UNIDADE = UNIDACEF.DCLUNIDADE_CEF.UNIDACEF_COD_UNIDADE.ToString(),
            };

            var executed_1 = R1502_00_SELECT_UNIDACEF_DB_SELECT_1_Query1.Execute(r1502_00_SELECT_UNIDACEF_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.UNIDACEF_NOME_UNIDADE, UNIDACEF.DCLUNIDADE_CEF.UNIDACEF_NOME_UNIDADE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1502_99_SAIDA*/

        [StopWatch]
        /*" R1503-00-SELECT-PROPOVA-SECTION */
        private void R1503_00_SELECT_PROPOVA_SECTION()
        {
            /*" -960- MOVE '1503' TO WNR-EXEC-SQL. */
            _.Move("1503", AREA_DE_WORK.WNR_EXEC_SQL);

            /*" -962- INITIALIZE DCLPROPOSTAS-VA. */
            _.Initialize(
                PROPOVA.DCLPROPOSTAS_VA
            );

            /*" -964- MOVE 'S' TO WTEM-NRCERTIF */
            _.Move("S", WTEM_NRCERTIF);

            /*" -980- PERFORM R1503_00_SELECT_PROPOVA_DB_SELECT_1 */

            R1503_00_SELECT_PROPOVA_DB_SELECT_1();

            /*" -983- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -984- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -985- MOVE 'N' TO WTEM-NRCERTIF */
                    _.Move("N", WTEM_NRCERTIF);

                    /*" -986- ELSE */
                }
                else
                {


                    /*" -987- DISPLAY 'ERRO SELECT SEGUROS.PROPOSTAS_VA' */
                    _.Display($"ERRO SELECT SEGUROS.PROPOSTAS_VA");

                    /*" -988- DISPLAY 'CERTIFICADO = ' WS-HISTCON-NRCERTIF */
                    _.Display($"CERTIFICADO = {WS_HISTCON_NRCERTIF}");

                    /*" -989- MOVE SQLCODE TO WSQLCODE */
                    _.Move(DB.SQLCODE, AREA_DE_WORK.WSQLCODE);

                    /*" -991- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -992- IF WTEM-NRCERTIF = 'S' */

            if (WTEM_NRCERTIF == "S")
            {

                /*" -993- MOVE '1592' TO WNR-EXEC-SQL */
                _.Move("1592", AREA_DE_WORK.WNR_EXEC_SQL);

                /*" -994- INITIALIZE DCLCLIENTES */
                _.Initialize(
                    CLIENTES.DCLCLIENTES
                );

                /*" -1000- PERFORM R1503_00_SELECT_PROPOVA_DB_SELECT_2 */

                R1503_00_SELECT_PROPOVA_DB_SELECT_2();

                /*" -1002- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -1003- IF SQLCODE EQUAL 100 */

                    if (DB.SQLCODE == 100)
                    {

                        /*" -1004- MOVE ZEROS TO CLIENTES-CGCCPF */
                        _.Move(0, CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF);

                        /*" -1005- ELSE */
                    }
                    else
                    {


                        /*" -1006- DISPLAY 'ERRO SELECT SEGUROS.CLIENTE-I' */
                        _.Display($"ERRO SELECT SEGUROS.CLIENTE-I");

                        /*" -1007- DISPLAY 'CERTIFICADO = ' WS-HISTCON-NRCERTIF */
                        _.Display($"CERTIFICADO = {WS_HISTCON_NRCERTIF}");

                        /*" -1008- MOVE SQLCODE TO WSQLCODE */
                        _.Move(DB.SQLCODE, AREA_DE_WORK.WSQLCODE);

                        /*" -1008- GO TO R9999-00-ROT-ERRO. */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;
                    }

                }

            }


        }

        [StopWatch]
        /*" R1503-00-SELECT-PROPOVA-DB-SELECT-1 */
        public void R1503_00_SELECT_PROPOVA_DB_SELECT_1()
        {
            /*" -980- EXEC SQL SELECT NUM_CERTIFICADO , NUM_APOLICE , COD_CLIENTE , DATA_QUITACAO , DATA_QUITACAO + 1 YEAR , SIT_REGISTRO INTO :WS-HISTCON-NRCERTIF , :WS-APOLICE-AUX , :WS-CLIENTE-AUX , :WS-DATA-QUITACAO-AUX , :WS-PROXIMA-DT-QUIT , :WS-SITUACAO FROM SEGUROS.PROPOSTAS_VA WHERE NUM_CERTIFICADO = :WS-HISTCON-NRCERTIF END-EXEC. */

            var r1503_00_SELECT_PROPOVA_DB_SELECT_1_Query1 = new R1503_00_SELECT_PROPOVA_DB_SELECT_1_Query1()
            {
                WS_HISTCON_NRCERTIF = WS_HISTCON_NRCERTIF.ToString(),
            };

            var executed_1 = R1503_00_SELECT_PROPOVA_DB_SELECT_1_Query1.Execute(r1503_00_SELECT_PROPOVA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_HISTCON_NRCERTIF, WS_HISTCON_NRCERTIF);
                _.Move(executed_1.WS_APOLICE_AUX, WS_APOLICE_AUX);
                _.Move(executed_1.WS_CLIENTE_AUX, WS_CLIENTE_AUX);
                _.Move(executed_1.WS_DATA_QUITACAO_AUX, WS_DATA_QUITACAO_AUX);
                _.Move(executed_1.WS_PROXIMA_DT_QUIT, WS_PROXIMA_DT_QUIT);
                _.Move(executed_1.WS_SITUACAO, WS_SITUACAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1503_99_SAIDA*/

        [StopWatch]
        /*" R1503-00-SELECT-PROPOVA-DB-SELECT-2 */
        public void R1503_00_SELECT_PROPOVA_DB_SELECT_2()
        {
            /*" -1000- EXEC SQL SELECT CGCCPF INTO :CLIENTES-CGCCPF FROM SEGUROS.CLIENTES WHERE COD_CLIENTE = :WS-CLIENTE-AUX END-EXEC */

            var r1503_00_SELECT_PROPOVA_DB_SELECT_2_Query1 = new R1503_00_SELECT_PROPOVA_DB_SELECT_2_Query1()
            {
                WS_CLIENTE_AUX = WS_CLIENTE_AUX.ToString(),
            };

            var executed_1 = R1503_00_SELECT_PROPOVA_DB_SELECT_2_Query1.Execute(r1503_00_SELECT_PROPOVA_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CLIENTES_CGCCPF, CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF);
            }


        }

        [StopWatch]
        /*" R1600-00-PROCESSA-CURSOR01-SECTION */
        private void R1600_00_PROCESSA_CURSOR01_SECTION()
        {
            /*" -1018- MOVE '1600' TO WNR-EXEC-SQL. */
            _.Move("1600", AREA_DE_WORK.WNR_EXEC_SQL);

            /*" -1019- IF WHOST-CANAL-DE-VENDA = 'EXTRA-REDE' */

            if (WHOST_CANAL_DE_VENDA == "EXTRA-REDE")
            {

                /*" -1020- PERFORM R1010-00-VERIFICA-ORIGEM */

                R1010_00_VERIFICA_ORIGEM_SECTION();

                /*" -1021- IF WTEM-SISTEMA-ORIGEM = 'NAO' */

                if (WORK_AREA.WTEM_SISTEMA_ORIGEM == "NAO")
                {

                    /*" -1022- GO TO R1600-20-NEXT */

                    R1600_20_NEXT(); //GOTO
                    return;

                    /*" -1023- END-IF */
                }


                /*" -1025- END-IF. */
            }


            /*" -1030- INITIALIZE REG-SAIDA WS-DATA-QUITACAO-AUX WREG-DSCR-SITUACAO WREG-MOTIVO */
            _.Initialize(
                REG_SAIDA
                , WS_DATA_QUITACAO_AUX
                , AREA_DE_WORK.WREG_DETALHE.WREG_DSCR_SITUACAO
                , AREA_DE_WORK.WREG_DETALHE.WREG_MOTIVO
            );

            /*" -1035- MOVE ';' TO FILLER1 FILLER2 FILLER3 FILLER4 FILLER5 FILLER6 FILLER7 FILLER8 FILLER9 FILLER10 FILLER11 FILLER12 FILLER1A FILLER1B FILLER31 FILLER111 */
            _.Move(";", REG_SAIDA.FILLER1, REG_SAIDA.FILLER2, REG_SAIDA.FILLER3, REG_SAIDA.FILLER4, REG_SAIDA.FILLER5, REG_SAIDA.FILLER6, REG_SAIDA.FILLER7, REG_SAIDA.FILLER8, REG_SAIDA.FILLER9, REG_SAIDA.FILLER10, REG_SAIDA.FILLER11, REG_SAIDA.FILLER12, REG_SAIDA.FILLER1A, REG_SAIDA.FILLER1B, REG_SAIDA.FILLER31, REG_SAIDA.FILLER111);

            /*" -1037- MOVE '-' TO FILLER1A */
            _.Move("-", REG_SAIDA.FILLER1A);

            /*" -1039- PERFORM R1502-00-SELECT-UNIDACEF */

            R1502_00_SELECT_UNIDACEF_SECTION();

            /*" -1040- IF PROPOFID-COD-PRODUTO-SIVPF = 11 */

            if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF == 11)
            {

                /*" -1041- PERFORM R1503-00-SELECT-PROPOVA */

                R1503_00_SELECT_PROPOVA_SECTION();

                /*" -1042- IF WTEM-NRCERTIF EQUAL 'N' */

                if (WTEM_NRCERTIF == "N")
                {

                    /*" -1044- MOVE 'CERTIFICADO NAO GERADO' TO WREG-DSCR-SITUACAO */
                    _.Move("CERTIFICADO NAO GERADO", AREA_DE_WORK.WREG_DETALHE.WREG_DSCR_SITUACAO);

                    /*" -1045- GO TO R1600-10-CONTINUA */

                    R1600_10_CONTINUA(); //GOTO
                    return;

                    /*" -1046- END-IF */
                }


                /*" -1047- PERFORM R1951-00-BUSCA-MOTIVO */

                R1951_00_BUSCA_MOTIVO_SECTION();

                /*" -1048- ELSE */
            }
            else
            {


                /*" -1049- PERFORM R1501-00-SELECT-BILHETE */

                R1501_00_SELECT_BILHETE_SECTION();

                /*" -1050- IF WTEM-BILHETE EQUAL 'N' */

                if (WTEM_BILHETE == "N")
                {

                    /*" -1052- MOVE 'BILHETE NAO GERADO' TO WREG-DSCR-SITUACAO */
                    _.Move("BILHETE NAO GERADO", AREA_DE_WORK.WREG_DETALHE.WREG_DSCR_SITUACAO);

                    /*" -1053- GO TO R1600-10-CONTINUA */

                    R1600_10_CONTINUA(); //GOTO
                    return;

                    /*" -1054- END-IF */
                }


                /*" -1055- PERFORM R1950-00-BUSCA-MOTIVO-CEF */

                R1950_00_BUSCA_MOTIVO_CEF_SECTION();

                /*" -1057- END-IF. */
            }


            /*" -1057- PERFORM R1953-00-BUSCA-SITUACAO. */

            R1953_00_BUSCA_SITUACAO_SECTION();

            /*" -0- FLUXCONTROL_PERFORM R1600_10_CONTINUA */

            R1600_10_CONTINUA();

        }

        [StopWatch]
        /*" R1600-10-CONTINUA */
        private void R1600_10_CONTINUA(bool isPerform = false)
        {
            /*" -1063- IF PROPOFID-COD-PRODUTO-SIVPF = 09 */

            if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF == 09)
            {

                /*" -1066- MOVE 'FACIL ACIDENTES PESSOAIS' TO SAIDA-PRODUTO. */
                _.Move("FACIL ACIDENTES PESSOAIS", REG_SAIDA.SAIDA_PRODUTO);
            }


            /*" -1067- IF PROPOFID-COD-PRODUTO-SIVPF = 11 */

            if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF == 11)
            {

                /*" -1070- MOVE 'VIDA DA GENTE' TO SAIDA-PRODUTO. */
                _.Move("VIDA DA GENTE", REG_SAIDA.SAIDA_PRODUTO);
            }


            /*" -1072- MOVE UNIDACEF-COD-UNIDADE TO SAIDA-COD-UNIDADE */
            _.Move(UNIDACEF.DCLUNIDADE_CEF.UNIDACEF_COD_UNIDADE, REG_SAIDA.SAIDA_COD_UNIDADE);

            /*" -1074- MOVE UNIDACEF-NOME-UNIDADE TO SAIDA-NOME-UNIDADE */
            _.Move(UNIDACEF.DCLUNIDADE_CEF.UNIDACEF_NOME_UNIDADE, REG_SAIDA.SAIDA_NOME_UNIDADE);

            /*" -1076- MOVE PROPOFID-NUM-PROPOSTA-SIVPF TO SAIDA-NUM-PROPOSTA-SIVPF */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF, REG_SAIDA.SAIDA_NUM_PROPOSTA_SIVPF);

            /*" -1078- MOVE PROPOFID-DATA-PROPOSTA TO SAIDA-DATA-PROPOSTA */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_PROPOSTA, REG_SAIDA.SAIDA_DATA_PROPOSTA);

            /*" -1080- MOVE PROPOFID-DIA-DEBITO TO SAIDA-DIA-DEBITO */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DIA_DEBITO, REG_SAIDA.SAIDA_DIA_DEBITO);

            /*" -1082- MOVE PROPOFID-NUM-SICOB TO SAIDA-NUM-SICOB */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_SICOB, REG_SAIDA.SAIDA_NUM_SICOB);

            /*" -1084- MOVE PROPOFID-AGECOBR TO SAIDA-AGECOBR */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGECOBR, REG_SAIDA.SAIDA_AGECOBR);

            /*" -1086- MOVE PROPOFID-VAL-PAGO TO SAIDA-VAL-PAGO */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_VAL_PAGO, REG_SAIDA.SAIDA_VAL_PAGO);

            /*" -1088- MOVE WS-DATA-QUITACAO-AUX TO SAIDA-DATA-QUITACAO-AUX */
            _.Move(WS_DATA_QUITACAO_AUX, REG_SAIDA.SAIDA_DATA_QUITACAO_AUX);

            /*" -1090- MOVE WREG-DSCR-SITUACAO TO SAIDA-DSCR-SITUACAO */
            _.Move(AREA_DE_WORK.WREG_DETALHE.WREG_DSCR_SITUACAO, REG_SAIDA.SAIDA_DSCR_SITUACAO);

            /*" -1092- MOVE MOVDEBCE-DATA-VENCIMENTO TO SAIDA-DATA-VENCIMENTO */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_VENCIMENTO, REG_SAIDA.SAIDA_DATA_VENCIMENTO);

            /*" -1094- MOVE MOVDEBCE-DATA-MOVIMENTO TO SAIDA-DATA-MOVIMENTO */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_MOVIMENTO, REG_SAIDA.SAIDA_DATA_MOVIMENTO);

            /*" -1096- MOVE CLIENTES-CGCCPF TO SAIDA-CGCCPF */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF, REG_SAIDA.SAIDA_CGCCPF);

            /*" -1099- MOVE WREG-MOTIVO TO SAIDA-MOTIVO */
            _.Move(AREA_DE_WORK.WREG_DETALHE.WREG_MOTIVO, REG_SAIDA.SAIDA_MOTIVO);

            /*" -1100- IF PROPOFID-ORIGEM-PROPOSTA EQUAL 1001 */

            if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_ORIGEM_PROPOSTA == 1001)
            {

                /*" -1102- MOVE 'SYSTEM CRED' TO SAIDA-ORIGEM */
                _.Move("SYSTEM CRED", REG_SAIDA.SAIDA_ORIGEM);

                /*" -1103- ELSE */
            }
            else
            {


                /*" -1104- IF PROPOFID-ORIGEM-PROPOSTA EQUAL 1002 */

                if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_ORIGEM_PROPOSTA == 1002)
                {

                    /*" -1106- MOVE 'GRUPO FIGUE' TO SAIDA-ORIGEM */
                    _.Move("GRUPO FIGUE", REG_SAIDA.SAIDA_ORIGEM);

                    /*" -1107- ELSE */
                }
                else
                {


                    /*" -1108- IF PROPOFID-ORIGEM-PROPOSTA EQUAL 1003 */

                    if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_ORIGEM_PROPOSTA == 1003)
                    {

                        /*" -1110- MOVE 'BR ASSIST  ' TO SAIDA-ORIGEM */
                        _.Move("BR ASSIST  ", REG_SAIDA.SAIDA_ORIGEM);

                        /*" -1111- ELSE */
                    }
                    else
                    {


                        /*" -1112- IF PROPOFID-ORIGEM-PROPOSTA EQUAL 1004 */

                        if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_ORIGEM_PROPOSTA == 1004)
                        {

                            /*" -1114- MOVE 'PAR CORRET ' TO SAIDA-ORIGEM */
                            _.Move("PAR CORRET ", REG_SAIDA.SAIDA_ORIGEM);

                            /*" -1115- ELSE */
                        }
                        else
                        {


                            /*" -1116- IF PROPOFID-ORIGEM-PROPOSTA EQUAL 1005 */

                            if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_ORIGEM_PROPOSTA == 1005)
                            {

                                /*" -1118- MOVE 'AD MEDICAL ' TO SAIDA-ORIGEM */
                                _.Move("AD MEDICAL ", REG_SAIDA.SAIDA_ORIGEM);

                                /*" -1119- ELSE */
                            }
                            else
                            {


                                /*" -1120- IF PROPOFID-ORIGEM-PROPOSTA EQUAL 1006 */

                                if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_ORIGEM_PROPOSTA == 1006)
                                {

                                    /*" -1122- MOVE 'TRAY       ' TO SAIDA-ORIGEM */
                                    _.Move("TRAY       ", REG_SAIDA.SAIDA_ORIGEM);

                                    /*" -1123- ELSE */
                                }
                                else
                                {


                                    /*" -1124- IF PROPOFID-ORIGEM-PROPOSTA EQUAL 1007 */

                                    if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_ORIGEM_PROPOSTA == 1007)
                                    {

                                        /*" -1126- MOVE 'MAIS ESTUDO' TO SAIDA-ORIGEM */
                                        _.Move("MAIS ESTUDO", REG_SAIDA.SAIDA_ORIGEM);

                                        /*" -1127- ELSE */
                                    }
                                    else
                                    {


                                        /*" -1128- IF PROPOFID-ORIGEM-PROPOSTA EQUAL 1008 */

                                        if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_ORIGEM_PROPOSTA == 1008)
                                        {

                                            /*" -1130- MOVE 'VIDAX      ' TO SAIDA-ORIGEM */
                                            _.Move("VIDAX      ", REG_SAIDA.SAIDA_ORIGEM);

                                            /*" -1131- ELSE */
                                        }
                                        else
                                        {


                                            /*" -1133- IF PROPOFID-ORIGEM-PROPOSTA EQUAL 12 */

                                            if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_ORIGEM_PROPOSTA == 12)
                                            {

                                                /*" -1135- MOVE 'CENTRAL CAIXA SEGUROS' TO SAIDA-ORIGEM */
                                                _.Move("CENTRAL CAIXA SEGUROS", REG_SAIDA.SAIDA_ORIGEM);

                                                /*" -1136- ELSE */
                                            }
                                            else
                                            {


                                                /*" -1137- IF PROPOFID-ORIGEM-PROPOSTA EQUAL 13 */

                                                if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_ORIGEM_PROPOSTA == 13)
                                                {

                                                    /*" -1139- MOVE 'SAF  ' TO SAIDA-ORIGEM */
                                                    _.Move("SAF  ", REG_SAIDA.SAIDA_ORIGEM);

                                                    /*" -1140- ELSE */
                                                }
                                                else
                                                {


                                                    /*" -1142- MOVE 'GITEL' TO SAIDA-ORIGEM */
                                                    _.Move("GITEL", REG_SAIDA.SAIDA_ORIGEM);

                                                    /*" -1143- END-IF */
                                                }


                                                /*" -1145- END-IF. */
                                            }

                                        }

                                    }

                                }

                            }

                        }

                    }

                }

            }


            /*" -1147- WRITE REG-RELAT FROM REG-SAIDA. */
            _.Move(REG_SAIDA.GetMoveValues(), REG_RELAT);

            RELATORIO.Write(REG_RELAT.GetMoveValues().ToString());

            /*" -1148- ADD 1 TO WS-TOTAL-GRAV. */
            AREA_DE_WORK.WS_TOTAL_GRAV.Value = AREA_DE_WORK.WS_TOTAL_GRAV + 1;

            /*" -1148- GO TO R1600-20-NEXT. */

            R1600_20_NEXT(); //GOTO
            return;

        }

        [StopWatch]
        /*" R1600-20-NEXT */
        private void R1600_20_NEXT(bool isPerform = false)
        {
            /*" -1152- PERFORM R1500-00-FETCH-CURSOR01. */

            R1500_00_FETCH_CURSOR01_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1600_99_SAIDA*/

        [StopWatch]
        /*" R1950-00-BUSCA-MOTIVO-CEF-SECTION */
        private void R1950_00_BUSCA_MOTIVO_CEF_SECTION()
        {
            /*" -1162- MOVE '1950' TO WNR-EXEC-SQL. */
            _.Move("1950", AREA_DE_WORK.WNR_EXEC_SQL);

            /*" -1164- INITIALIZE DCLMOVTO-DEBITOCC-CEF */
            _.Initialize(
                MOVDEBCE.DCLMOVTO_DEBITOCC_CEF
            );

            /*" -1166- MOVE WS-BILHETE-AUX TO MOVDEBCE-NUM-APOLICE */
            _.Move(WS_BILHETE_AUX, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE);

            /*" -1177- PERFORM R1950_00_BUSCA_MOTIVO_CEF_DB_SELECT_1 */

            R1950_00_BUSCA_MOTIVO_CEF_DB_SELECT_1();

            /*" -1180- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1181- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1182- IF WS-DATA-QUITACAO-AUX < SISTEMAS-DATA-MOV-ABERTO */

                    if (WS_DATA_QUITACAO_AUX < SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO)
                    {

                        /*" -1183- MOVE 'LANCAMENTO NAO GERADO' TO WREG-MOTIVO */
                        _.Move("LANCAMENTO NAO GERADO", AREA_DE_WORK.WREG_DETALHE.WREG_MOTIVO);

                        /*" -1184- ELSE */
                    }
                    else
                    {


                        /*" -1185- MOVE SPACES TO WREG-MOTIVO */
                        _.Move("", AREA_DE_WORK.WREG_DETALHE.WREG_MOTIVO);

                        /*" -1186- END-IF */
                    }


                    /*" -1187- GO TO R1950-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1950_99_SAIDA*/ //GOTO
                    return;

                    /*" -1188- ELSE */
                }
                else
                {


                    /*" -1189- IF SQLCODE EQUAL -811 */

                    if (DB.SQLCODE == -811)
                    {

                        /*" -1190- DISPLAY 'DUPLICADO ' MOVDEBCE-NUM-APOLICE */
                        _.Display($"DUPLICADO {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE}");

                        /*" -1191- MOVE 'DUPLICADO ' TO WREG-MOTIVO */
                        _.Move("DUPLICADO ", AREA_DE_WORK.WREG_DETALHE.WREG_MOTIVO);

                        /*" -1192- GO TO R1950-99-SAIDA */
                        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1950_99_SAIDA*/ //GOTO
                        return;

                        /*" -1193- ELSE */
                    }
                    else
                    {


                        /*" -1194- MOVE SQLCODE TO WSQLCODE */
                        _.Move(DB.SQLCODE, AREA_DE_WORK.WSQLCODE);

                        /*" -1195- DISPLAY 'ERRO SELECT SEGUROS.MOVTO_DEBITOCC_CEF' */
                        _.Display($"ERRO SELECT SEGUROS.MOVTO_DEBITOCC_CEF");

                        /*" -1196- DISPLAY 'BILHETE = ' WS-BILHETE-AUX */
                        _.Display($"BILHETE = {WS_BILHETE_AUX}");

                        /*" -1198- GO TO R9999-00-ROT-ERRO. */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;
                    }

                }

            }


            /*" -1199- IF WIND-NULL LESS THAN ZERO */

            if (WIND_NULL < 00)
            {

                /*" -1200- MOVE SPACES TO WREG-MOTIVO */
                _.Move("", AREA_DE_WORK.WREG_DETALHE.WREG_MOTIVO);

                /*" -1201- GO TO R1950-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1950_99_SAIDA*/ //GOTO
                return;

                /*" -1203- END-IF. */
            }


            /*" -1204- IF WS-SITUAC-CEF NOT EQUAL ZERO */

            if (WS_SITUAC_CEF != 00)
            {

                /*" -1205- EVALUATE WS-SITUAC-CEF */
                switch (WS_SITUAC_CEF.Value)
                {

                    /*" -1206- WHEN  0000 */
                    case 0000:

                        /*" -1207- MOVE TAB-DESC-RET (1) TO WREG-MOTIVO */
                        _.Move(AREA_DE_WORK.TAB_SITUACAO_CEF_RED.TB_SITUACAO_CEF_0[1].TAB_DESC_RET, AREA_DE_WORK.WREG_DETALHE.WREG_MOTIVO);

                        /*" -1208- WHEN  0001 */
                        break;
                    case 0001:

                        /*" -1209- MOVE TAB-DESC-RET (2) TO WREG-MOTIVO */
                        _.Move(AREA_DE_WORK.TAB_SITUACAO_CEF_RED.TB_SITUACAO_CEF_0[2].TAB_DESC_RET, AREA_DE_WORK.WREG_DETALHE.WREG_MOTIVO);

                        /*" -1210- WHEN  0002 */
                        break;
                    case 0002:

                        /*" -1211- MOVE TAB-DESC-RET (3) TO WREG-MOTIVO */
                        _.Move(AREA_DE_WORK.TAB_SITUACAO_CEF_RED.TB_SITUACAO_CEF_0[3].TAB_DESC_RET, AREA_DE_WORK.WREG_DETALHE.WREG_MOTIVO);

                        /*" -1212- WHEN  0004 */
                        break;
                    case 0004:

                        /*" -1213- MOVE TAB-DESC-RET (4) TO WREG-MOTIVO */
                        _.Move(AREA_DE_WORK.TAB_SITUACAO_CEF_RED.TB_SITUACAO_CEF_0[4].TAB_DESC_RET, AREA_DE_WORK.WREG_DETALHE.WREG_MOTIVO);

                        /*" -1214- WHEN  0010 */
                        break;
                    case 0010:

                        /*" -1215- MOVE TAB-DESC-RET (5) TO WREG-MOTIVO */
                        _.Move(AREA_DE_WORK.TAB_SITUACAO_CEF_RED.TB_SITUACAO_CEF_0[5].TAB_DESC_RET, AREA_DE_WORK.WREG_DETALHE.WREG_MOTIVO);

                        /*" -1216- WHEN  0012 */
                        break;
                    case 0012:

                        /*" -1217- MOVE TAB-DESC-RET (6) TO WREG-MOTIVO */
                        _.Move(AREA_DE_WORK.TAB_SITUACAO_CEF_RED.TB_SITUACAO_CEF_0[6].TAB_DESC_RET, AREA_DE_WORK.WREG_DETALHE.WREG_MOTIVO);

                        /*" -1218- WHEN  0014 */
                        break;
                    case 0014:

                        /*" -1219- MOVE TAB-DESC-RET (7) TO WREG-MOTIVO */
                        _.Move(AREA_DE_WORK.TAB_SITUACAO_CEF_RED.TB_SITUACAO_CEF_0[7].TAB_DESC_RET, AREA_DE_WORK.WREG_DETALHE.WREG_MOTIVO);

                        /*" -1220- WHEN  0015 */
                        break;
                    case 0015:

                        /*" -1221- MOVE TAB-DESC-RET (8) TO WREG-MOTIVO */
                        _.Move(AREA_DE_WORK.TAB_SITUACAO_CEF_RED.TB_SITUACAO_CEF_0[8].TAB_DESC_RET, AREA_DE_WORK.WREG_DETALHE.WREG_MOTIVO);

                        /*" -1222- WHEN  0018 */
                        break;
                    case 0018:

                        /*" -1223- MOVE TAB-DESC-RET (9) TO WREG-MOTIVO */
                        _.Move(AREA_DE_WORK.TAB_SITUACAO_CEF_RED.TB_SITUACAO_CEF_0[9].TAB_DESC_RET, AREA_DE_WORK.WREG_DETALHE.WREG_MOTIVO);

                        /*" -1224- WHEN  0030 */
                        break;
                    case 0030:

                        /*" -1225- MOVE TAB-DESC-RET (10) TO WREG-MOTIVO */
                        _.Move(AREA_DE_WORK.TAB_SITUACAO_CEF_RED.TB_SITUACAO_CEF_0[10].TAB_DESC_RET, AREA_DE_WORK.WREG_DETALHE.WREG_MOTIVO);

                        /*" -1226- WHEN  0096 */
                        break;
                    case 0096:

                        /*" -1227- MOVE TAB-DESC-RET (11) TO WREG-MOTIVO */
                        _.Move(AREA_DE_WORK.TAB_SITUACAO_CEF_RED.TB_SITUACAO_CEF_0[11].TAB_DESC_RET, AREA_DE_WORK.WREG_DETALHE.WREG_MOTIVO);

                        /*" -1228- WHEN  0099 */
                        break;
                    case 0099:

                        /*" -1229- MOVE TAB-DESC-RET (12) TO WREG-MOTIVO */
                        _.Move(AREA_DE_WORK.TAB_SITUACAO_CEF_RED.TB_SITUACAO_CEF_0[12].TAB_DESC_RET, AREA_DE_WORK.WREG_DETALHE.WREG_MOTIVO);

                        /*" -1230- WHEN  OTHER */
                        break;
                    default:

                        /*" -1231- MOVE SPACES TO WREG-MOTIVO */
                        _.Move("", AREA_DE_WORK.WREG_DETALHE.WREG_MOTIVO);

                        /*" -1232- END-EVALUATE */
                        break;
                }


                /*" -1232- END-IF. */
            }


        }

        [StopWatch]
        /*" R1950-00-BUSCA-MOTIVO-CEF-DB-SELECT-1 */
        public void R1950_00_BUSCA_MOTIVO_CEF_DB_SELECT_1()
        {
            /*" -1177- EXEC SQL SELECT COD_RETORNO_CEF, DATA_VENCIMENTO , DATA_MOVIMENTO , TIMESTAMP INTO :WS-SITUAC-CEF:WIND-NULL , :MOVDEBCE-DATA-VENCIMENTO , :MOVDEBCE-DATA-MOVIMENTO , :MOVDEBCE-TIMESTAMP FROM SEGUROS.MOVTO_DEBITOCC_CEF WHERE NUM_APOLICE = :MOVDEBCE-NUM-APOLICE END-EXEC. */

            var r1950_00_BUSCA_MOTIVO_CEF_DB_SELECT_1_Query1 = new R1950_00_BUSCA_MOTIVO_CEF_DB_SELECT_1_Query1()
            {
                MOVDEBCE_NUM_APOLICE = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE.ToString(),
            };

            var executed_1 = R1950_00_BUSCA_MOTIVO_CEF_DB_SELECT_1_Query1.Execute(r1950_00_BUSCA_MOTIVO_CEF_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_SITUAC_CEF, WS_SITUAC_CEF);
                _.Move(executed_1.WIND_NULL, WIND_NULL);
                _.Move(executed_1.MOVDEBCE_DATA_VENCIMENTO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_VENCIMENTO);
                _.Move(executed_1.MOVDEBCE_DATA_MOVIMENTO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_MOVIMENTO);
                _.Move(executed_1.MOVDEBCE_TIMESTAMP, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_TIMESTAMP);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1950_99_SAIDA*/

        [StopWatch]
        /*" R1951-00-BUSCA-MOTIVO-SECTION */
        private void R1951_00_BUSCA_MOTIVO_SECTION()
        {
            /*" -1241- MOVE '1951' TO WNR-EXEC-SQL. */
            _.Move("1951", AREA_DE_WORK.WNR_EXEC_SQL);

            /*" -1242- INITIALIZE DCLMOVTO-DEBITOCC-CEF */
            _.Initialize(
                MOVDEBCE.DCLMOVTO_DEBITOCC_CEF
            );

            /*" -1242- PERFORM R1951_00_BUSCA_MOTIVO_DB_OPEN_1 */

            R1951_00_BUSCA_MOTIVO_DB_OPEN_1();

            /*" -1244- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1245- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, AREA_DE_WORK.WSQLCODE);

                /*" -1246- DISPLAY 'ERRO OPEN CURSOR02' */
                _.Display($"ERRO OPEN CURSOR02");

                /*" -1247- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1249- END-IF. */
            }


            /*" -1254- PERFORM R1951_00_BUSCA_MOTIVO_DB_FETCH_1 */

            R1951_00_BUSCA_MOTIVO_DB_FETCH_1();

            /*" -1256- PERFORM R1951_00_BUSCA_MOTIVO_DB_CLOSE_1 */

            R1951_00_BUSCA_MOTIVO_DB_CLOSE_1();

            /*" -1259- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1260- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1261- IF WS-DATA-QUITACAO-AUX < SISTEMAS-DATA-MOV-ABERTO */

                    if (WS_DATA_QUITACAO_AUX < SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO)
                    {

                        /*" -1262- MOVE 'LANCAMENTO NAO GERADO' TO WREG-MOTIVO */
                        _.Move("LANCAMENTO NAO GERADO", AREA_DE_WORK.WREG_DETALHE.WREG_MOTIVO);

                        /*" -1263- ELSE */
                    }
                    else
                    {


                        /*" -1264- MOVE SPACES TO WREG-MOTIVO */
                        _.Move("", AREA_DE_WORK.WREG_DETALHE.WREG_MOTIVO);

                        /*" -1265- END-IF */
                    }


                    /*" -1266- GO TO R1951-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1951_99_SAIDA*/ //GOTO
                    return;

                    /*" -1267- ELSE */
                }
                else
                {


                    /*" -1268- MOVE SQLCODE TO WSQLCODE */
                    _.Move(DB.SQLCODE, AREA_DE_WORK.WSQLCODE);

                    /*" -1269- DISPLAY 'ERRO FETCH CURSOR02' */
                    _.Display($"ERRO FETCH CURSOR02");

                    /*" -1270- DISPLAY 'CERTIFICADO = ' WS-HISTCON-NRCERTIF */
                    _.Display($"CERTIFICADO = {WS_HISTCON_NRCERTIF}");

                    /*" -1272- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -1273- IF WIND-NULL1 LESS THAN ZERO */

            if (WIND_NULL1 < 00)
            {

                /*" -1274- MOVE SPACES TO WREG-MOTIVO */
                _.Move("", AREA_DE_WORK.WREG_DETALHE.WREG_MOTIVO);

                /*" -1275- GO TO R1951-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1951_99_SAIDA*/ //GOTO
                return;

                /*" -1277- END-IF. */
            }


            /*" -1279- MOVE MOVDEBCE-TIMESTAMP(1:10) TO MOVDEBCE-DATA-MOVIMENTO. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_TIMESTAMP.Substring(1, 10), MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_MOVIMENTO);

            /*" -1281- IF WS-SITUAC-CEF NOT EQUAL ZERO */

            if (WS_SITUAC_CEF != 00)
            {

                /*" -1282- IF PROPOFID-ORIGEM-PROPOSTA EQUAL 1001 OR 1002 */

                if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_ORIGEM_PROPOSTA.In("1001", "1002"))
                {

                    /*" -1283- EVALUATE WS-SITUAC-CEF */
                    switch (WS_SITUAC_CEF.Value)
                    {

                        /*" -1284- WHEN 0000 */
                        case 0000:

                            /*" -1285- MOVE TAB-DESC-RET1 (1) TO WREG-MOTIVO */
                            _.Move(AREA_DE_WORK.TAB_SITUACAO_CEF_RED1.TB_SITUACAO_CEF[1].TAB_DESC_RET1, AREA_DE_WORK.WREG_DETALHE.WREG_MOTIVO);

                            /*" -1286- WHEN 0001 */
                            break;
                        case 0001:

                            /*" -1287- MOVE TAB-DESC-RET1 (2) TO WREG-MOTIVO */
                            _.Move(AREA_DE_WORK.TAB_SITUACAO_CEF_RED1.TB_SITUACAO_CEF[2].TAB_DESC_RET1, AREA_DE_WORK.WREG_DETALHE.WREG_MOTIVO);

                            /*" -1288- WHEN 0002 */
                            break;
                        case 0002:

                            /*" -1289- MOVE TAB-DESC-RET1 (3) TO WREG-MOTIVO */
                            _.Move(AREA_DE_WORK.TAB_SITUACAO_CEF_RED1.TB_SITUACAO_CEF[3].TAB_DESC_RET1, AREA_DE_WORK.WREG_DETALHE.WREG_MOTIVO);

                            /*" -1290- WHEN 0003 */
                            break;
                        case 0003:

                            /*" -1291- MOVE TAB-DESC-RET1 (4) TO WREG-MOTIVO */
                            _.Move(AREA_DE_WORK.TAB_SITUACAO_CEF_RED1.TB_SITUACAO_CEF[4].TAB_DESC_RET1, AREA_DE_WORK.WREG_DETALHE.WREG_MOTIVO);

                            /*" -1292- WHEN 0004 */
                            break;
                        case 0004:

                            /*" -1293- MOVE TAB-DESC-RET1 (5) TO WREG-MOTIVO */
                            _.Move(AREA_DE_WORK.TAB_SITUACAO_CEF_RED1.TB_SITUACAO_CEF[5].TAB_DESC_RET1, AREA_DE_WORK.WREG_DETALHE.WREG_MOTIVO);

                            /*" -1294- WHEN 0097 */
                            break;
                        case 0097:

                            /*" -1295- MOVE TAB-DESC-RET1 (6) TO WREG-MOTIVO */
                            _.Move(AREA_DE_WORK.TAB_SITUACAO_CEF_RED1.TB_SITUACAO_CEF[6].TAB_DESC_RET1, AREA_DE_WORK.WREG_DETALHE.WREG_MOTIVO);

                            /*" -1296- WHEN 0098 */
                            break;
                        case 0098:

                            /*" -1297- MOVE TAB-DESC-RET1 (7) TO WREG-MOTIVO */
                            _.Move(AREA_DE_WORK.TAB_SITUACAO_CEF_RED1.TB_SITUACAO_CEF[7].TAB_DESC_RET1, AREA_DE_WORK.WREG_DETALHE.WREG_MOTIVO);

                            /*" -1298- WHEN 0099 */
                            break;
                        case 0099:

                            /*" -1299- MOVE TAB-DESC-RET1 (8) TO WREG-MOTIVO */
                            _.Move(AREA_DE_WORK.TAB_SITUACAO_CEF_RED1.TB_SITUACAO_CEF[8].TAB_DESC_RET1, AREA_DE_WORK.WREG_DETALHE.WREG_MOTIVO);

                            /*" -1300- WHEN OTHER */
                            break;
                        default:

                            /*" -1301- MOVE SPACES TO WREG-MOTIVO */
                            _.Move("", AREA_DE_WORK.WREG_DETALHE.WREG_MOTIVO);

                            /*" -1302- END-EVALUATE */
                            break;
                    }


                    /*" -1303- ELSE */
                }
                else
                {


                    /*" -1304- EVALUATE WS-SITUAC-CEF */
                    switch (WS_SITUAC_CEF.Value)
                    {

                        /*" -1305- WHEN  0000 */
                        case 0000:

                            /*" -1306- MOVE TAB-DESC-RET (1) TO WREG-MOTIVO */
                            _.Move(AREA_DE_WORK.TAB_SITUACAO_CEF_RED.TB_SITUACAO_CEF_0[1].TAB_DESC_RET, AREA_DE_WORK.WREG_DETALHE.WREG_MOTIVO);

                            /*" -1307- WHEN  0001 */
                            break;
                        case 0001:

                            /*" -1308- MOVE TAB-DESC-RET (2) TO WREG-MOTIVO */
                            _.Move(AREA_DE_WORK.TAB_SITUACAO_CEF_RED.TB_SITUACAO_CEF_0[2].TAB_DESC_RET, AREA_DE_WORK.WREG_DETALHE.WREG_MOTIVO);

                            /*" -1309- WHEN  0002 */
                            break;
                        case 0002:

                            /*" -1310- MOVE TAB-DESC-RET (3) TO WREG-MOTIVO */
                            _.Move(AREA_DE_WORK.TAB_SITUACAO_CEF_RED.TB_SITUACAO_CEF_0[3].TAB_DESC_RET, AREA_DE_WORK.WREG_DETALHE.WREG_MOTIVO);

                            /*" -1311- WHEN  0004 */
                            break;
                        case 0004:

                            /*" -1312- MOVE TAB-DESC-RET (4) TO WREG-MOTIVO */
                            _.Move(AREA_DE_WORK.TAB_SITUACAO_CEF_RED.TB_SITUACAO_CEF_0[4].TAB_DESC_RET, AREA_DE_WORK.WREG_DETALHE.WREG_MOTIVO);

                            /*" -1313- WHEN  0010 */
                            break;
                        case 0010:

                            /*" -1314- MOVE TAB-DESC-RET (5) TO WREG-MOTIVO */
                            _.Move(AREA_DE_WORK.TAB_SITUACAO_CEF_RED.TB_SITUACAO_CEF_0[5].TAB_DESC_RET, AREA_DE_WORK.WREG_DETALHE.WREG_MOTIVO);

                            /*" -1315- WHEN  0012 */
                            break;
                        case 0012:

                            /*" -1316- MOVE TAB-DESC-RET (6) TO WREG-MOTIVO */
                            _.Move(AREA_DE_WORK.TAB_SITUACAO_CEF_RED.TB_SITUACAO_CEF_0[6].TAB_DESC_RET, AREA_DE_WORK.WREG_DETALHE.WREG_MOTIVO);

                            /*" -1317- WHEN  0014 */
                            break;
                        case 0014:

                            /*" -1318- MOVE TAB-DESC-RET (7) TO WREG-MOTIVO */
                            _.Move(AREA_DE_WORK.TAB_SITUACAO_CEF_RED.TB_SITUACAO_CEF_0[7].TAB_DESC_RET, AREA_DE_WORK.WREG_DETALHE.WREG_MOTIVO);

                            /*" -1319- WHEN  0015 */
                            break;
                        case 0015:

                            /*" -1320- MOVE TAB-DESC-RET (8) TO WREG-MOTIVO */
                            _.Move(AREA_DE_WORK.TAB_SITUACAO_CEF_RED.TB_SITUACAO_CEF_0[8].TAB_DESC_RET, AREA_DE_WORK.WREG_DETALHE.WREG_MOTIVO);

                            /*" -1321- WHEN  0018 */
                            break;
                        case 0018:

                            /*" -1322- MOVE TAB-DESC-RET (9) TO WREG-MOTIVO */
                            _.Move(AREA_DE_WORK.TAB_SITUACAO_CEF_RED.TB_SITUACAO_CEF_0[9].TAB_DESC_RET, AREA_DE_WORK.WREG_DETALHE.WREG_MOTIVO);

                            /*" -1323- WHEN  0030 */
                            break;
                        case 0030:

                            /*" -1324- MOVE TAB-DESC-RET (10) TO WREG-MOTIVO */
                            _.Move(AREA_DE_WORK.TAB_SITUACAO_CEF_RED.TB_SITUACAO_CEF_0[10].TAB_DESC_RET, AREA_DE_WORK.WREG_DETALHE.WREG_MOTIVO);

                            /*" -1325- WHEN  0096 */
                            break;
                        case 0096:

                            /*" -1326- MOVE TAB-DESC-RET (11) TO WREG-MOTIVO */
                            _.Move(AREA_DE_WORK.TAB_SITUACAO_CEF_RED.TB_SITUACAO_CEF_0[11].TAB_DESC_RET, AREA_DE_WORK.WREG_DETALHE.WREG_MOTIVO);

                            /*" -1327- WHEN  0099 */
                            break;
                        case 0099:

                            /*" -1328- MOVE TAB-DESC-RET (12) TO WREG-MOTIVO */
                            _.Move(AREA_DE_WORK.TAB_SITUACAO_CEF_RED.TB_SITUACAO_CEF_0[12].TAB_DESC_RET, AREA_DE_WORK.WREG_DETALHE.WREG_MOTIVO);

                            /*" -1329- WHEN  OTHER */
                            break;
                        default:

                            /*" -1330- MOVE SPACES TO WREG-MOTIVO */
                            _.Move("", AREA_DE_WORK.WREG_DETALHE.WREG_MOTIVO);

                            /*" -1331- END-EVALUATE */
                            break;
                    }


                    /*" -1332- END-IF. */
                }

            }


        }

        [StopWatch]
        /*" R1951-00-BUSCA-MOTIVO-DB-OPEN-1 */
        public void R1951_00_BUSCA_MOTIVO_DB_OPEN_1()
        {
            /*" -1242- EXEC SQL OPEN CURSOR02 END-EXEC. */

            CURSOR02.Open();

        }

        [StopWatch]
        /*" R1951-00-BUSCA-MOTIVO-DB-FETCH-1 */
        public void R1951_00_BUSCA_MOTIVO_DB_FETCH_1()
        {
            /*" -1254- EXEC SQL FETCH CURSOR02 INTO :WS-SITUAC-CEF:WIND-NULL1, :MOVDEBCE-DATA-VENCIMENTO , :MOVDEBCE-TIMESTAMP END-EXEC. */

            if (CURSOR02.Fetch())
            {
                _.Move(CURSOR02.WS_SITUAC_CEF, WS_SITUAC_CEF);
                _.Move(CURSOR02.WIND_NULL1, WIND_NULL1);
                _.Move(CURSOR02.MOVDEBCE_DATA_VENCIMENTO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_VENCIMENTO);
                _.Move(CURSOR02.MOVDEBCE_TIMESTAMP, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_TIMESTAMP);
            }

        }

        [StopWatch]
        /*" R1951-00-BUSCA-MOTIVO-DB-CLOSE-1 */
        public void R1951_00_BUSCA_MOTIVO_DB_CLOSE_1()
        {
            /*" -1256- EXEC SQL CLOSE CURSOR02 END-EXEC */

            CURSOR02.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1951_99_SAIDA*/

        [StopWatch]
        /*" R1953-00-BUSCA-SITUACAO-SECTION */
        private void R1953_00_BUSCA_SITUACAO_SECTION()
        {
            /*" -1340- MOVE '1953' TO WNR-EXEC-SQL. */
            _.Move("1953", AREA_DE_WORK.WNR_EXEC_SQL);

            /*" -1342- IF PROPOFID-COD-PRODUTO-SIVPF = 11 */

            if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF == 11)
            {

                /*" -1343- EVALUATE WS-SITUACAO */
                switch (WS_SITUACAO.Value.Trim())
                {

                    /*" -1344- WHEN '0' */
                    case "0":

                        /*" -1345- MOVE TAB-DESC-SIT-VIDA (1) TO WREG-DSCR-SITUACAO */
                        _.Move(AREA_DE_WORK.TAB_SITUACAO_RED_VIDA.TB_SITUACAO_VIDA[1].TAB_DESC_SIT_VIDA, AREA_DE_WORK.WREG_DETALHE.WREG_DSCR_SITUACAO);

                        /*" -1346- WHEN '1' */
                        break;
                    case "1":

                        /*" -1347- MOVE TAB-DESC-SIT-VIDA (2) TO WREG-DSCR-SITUACAO */
                        _.Move(AREA_DE_WORK.TAB_SITUACAO_RED_VIDA.TB_SITUACAO_VIDA[2].TAB_DESC_SIT_VIDA, AREA_DE_WORK.WREG_DETALHE.WREG_DSCR_SITUACAO);

                        /*" -1348- WHEN '2' */
                        break;
                    case "2":

                        /*" -1349- MOVE TAB-DESC-SIT-VIDA (3) TO WREG-DSCR-SITUACAO */
                        _.Move(AREA_DE_WORK.TAB_SITUACAO_RED_VIDA.TB_SITUACAO_VIDA[3].TAB_DESC_SIT_VIDA, AREA_DE_WORK.WREG_DETALHE.WREG_DSCR_SITUACAO);

                        /*" -1350- WHEN '3' */
                        break;
                    case "3":

                        /*" -1351- MOVE TAB-DESC-SIT-VIDA (4) TO WREG-DSCR-SITUACAO */
                        _.Move(AREA_DE_WORK.TAB_SITUACAO_RED_VIDA.TB_SITUACAO_VIDA[4].TAB_DESC_SIT_VIDA, AREA_DE_WORK.WREG_DETALHE.WREG_DSCR_SITUACAO);

                        /*" -1352- WHEN '4' */
                        break;
                    case "4":

                        /*" -1353- MOVE TAB-DESC-SIT-VIDA (5) TO WREG-DSCR-SITUACAO */
                        _.Move(AREA_DE_WORK.TAB_SITUACAO_RED_VIDA.TB_SITUACAO_VIDA[5].TAB_DESC_SIT_VIDA, AREA_DE_WORK.WREG_DETALHE.WREG_DSCR_SITUACAO);

                        /*" -1354- WHEN '5' */
                        break;
                    case "5":

                        /*" -1355- MOVE TAB-DESC-SIT-VIDA (6) TO WREG-DSCR-SITUACAO */
                        _.Move(AREA_DE_WORK.TAB_SITUACAO_RED_VIDA.TB_SITUACAO_VIDA[6].TAB_DESC_SIT_VIDA, AREA_DE_WORK.WREG_DETALHE.WREG_DSCR_SITUACAO);

                        /*" -1356- WHEN '6' */
                        break;
                    case "6":

                        /*" -1357- MOVE TAB-DESC-SIT-VIDA (7) TO WREG-DSCR-SITUACAO */
                        _.Move(AREA_DE_WORK.TAB_SITUACAO_RED_VIDA.TB_SITUACAO_VIDA[7].TAB_DESC_SIT_VIDA, AREA_DE_WORK.WREG_DETALHE.WREG_DSCR_SITUACAO);

                        /*" -1358- WHEN '7' */
                        break;
                    case "7":

                        /*" -1359- MOVE TAB-DESC-SIT-VIDA (8) TO WREG-DSCR-SITUACAO */
                        _.Move(AREA_DE_WORK.TAB_SITUACAO_RED_VIDA.TB_SITUACAO_VIDA[8].TAB_DESC_SIT_VIDA, AREA_DE_WORK.WREG_DETALHE.WREG_DSCR_SITUACAO);

                        /*" -1360- WHEN '8' */
                        break;
                    case "8":

                        /*" -1361- MOVE TAB-DESC-SIT-VIDA (9) TO WREG-DSCR-SITUACAO */
                        _.Move(AREA_DE_WORK.TAB_SITUACAO_RED_VIDA.TB_SITUACAO_VIDA[9].TAB_DESC_SIT_VIDA, AREA_DE_WORK.WREG_DETALHE.WREG_DSCR_SITUACAO);

                        /*" -1362- WHEN '9' */
                        break;
                    case "9":

                        /*" -1363- MOVE TAB-DESC-SIT-VIDA (10) TO WREG-DSCR-SITUACAO */
                        _.Move(AREA_DE_WORK.TAB_SITUACAO_RED_VIDA.TB_SITUACAO_VIDA[10].TAB_DESC_SIT_VIDA, AREA_DE_WORK.WREG_DETALHE.WREG_DSCR_SITUACAO);

                        /*" -1364- WHEN 'A' */
                        break;
                    case "A":

                        /*" -1365- MOVE TAB-DESC-SIT-VIDA (11) TO WREG-DSCR-SITUACAO */
                        _.Move(AREA_DE_WORK.TAB_SITUACAO_RED_VIDA.TB_SITUACAO_VIDA[11].TAB_DESC_SIT_VIDA, AREA_DE_WORK.WREG_DETALHE.WREG_DSCR_SITUACAO);

                        /*" -1366- WHEN 'B' */
                        break;
                    case "B":

                        /*" -1367- MOVE TAB-DESC-SIT-VIDA (12) TO WREG-DSCR-SITUACAO */
                        _.Move(AREA_DE_WORK.TAB_SITUACAO_RED_VIDA.TB_SITUACAO_VIDA[12].TAB_DESC_SIT_VIDA, AREA_DE_WORK.WREG_DETALHE.WREG_DSCR_SITUACAO);

                        /*" -1368- WHEN 'C' */
                        break;
                    case "C":

                        /*" -1369- MOVE TAB-DESC-SIT-VIDA (13) TO WREG-DSCR-SITUACAO */
                        _.Move(AREA_DE_WORK.TAB_SITUACAO_RED_VIDA.TB_SITUACAO_VIDA[13].TAB_DESC_SIT_VIDA, AREA_DE_WORK.WREG_DETALHE.WREG_DSCR_SITUACAO);

                        /*" -1370- WHEN 'D' */
                        break;
                    case "D":

                        /*" -1371- MOVE TAB-DESC-SIT-VIDA (14) TO WREG-DSCR-SITUACAO */
                        _.Move(AREA_DE_WORK.TAB_SITUACAO_RED_VIDA.TB_SITUACAO_VIDA[14].TAB_DESC_SIT_VIDA, AREA_DE_WORK.WREG_DETALHE.WREG_DSCR_SITUACAO);

                        /*" -1372- WHEN 'E' */
                        break;
                    case "E":

                        /*" -1373- MOVE TAB-DESC-SIT-VIDA (15) TO WREG-DSCR-SITUACAO */
                        _.Move(AREA_DE_WORK.TAB_SITUACAO_RED_VIDA.TB_SITUACAO_VIDA[15].TAB_DESC_SIT_VIDA, AREA_DE_WORK.WREG_DETALHE.WREG_DSCR_SITUACAO);

                        /*" -1374- WHEN OTHER */
                        break;
                    default:

                        /*" -1375- MOVE SPACES TO WREG-DSCR-SITUACAO */
                        _.Move("", AREA_DE_WORK.WREG_DETALHE.WREG_DSCR_SITUACAO);

                        /*" -1376- END-EVALUATE */
                        break;
                }


                /*" -1377- ELSE */
            }
            else
            {


                /*" -1378- EVALUATE WS-SITUACAO */
                switch (WS_SITUACAO.Value.Trim())
                {

                    /*" -1379- WHEN '0' */
                    case "0":

                        /*" -1380- MOVE TAB-DESC-SITUACAO (1) TO WREG-DSCR-SITUACAO */
                        _.Move(AREA_DE_WORK.TAB_SITUACAO_RED.TB_SITUACAO_CEF_1[1].TAB_DESC_SITUACAO, AREA_DE_WORK.WREG_DETALHE.WREG_DSCR_SITUACAO);

                        /*" -1381- WHEN '1' */
                        break;
                    case "1":

                        /*" -1382- MOVE TAB-DESC-SITUACAO (2) TO WREG-DSCR-SITUACAO */
                        _.Move(AREA_DE_WORK.TAB_SITUACAO_RED.TB_SITUACAO_CEF_1[2].TAB_DESC_SITUACAO, AREA_DE_WORK.WREG_DETALHE.WREG_DSCR_SITUACAO);

                        /*" -1383- WHEN '2' */
                        break;
                    case "2":

                        /*" -1384- MOVE TAB-DESC-SITUACAO (3) TO WREG-DSCR-SITUACAO */
                        _.Move(AREA_DE_WORK.TAB_SITUACAO_RED.TB_SITUACAO_CEF_1[3].TAB_DESC_SITUACAO, AREA_DE_WORK.WREG_DETALHE.WREG_DSCR_SITUACAO);

                        /*" -1385- WHEN '3' */
                        break;
                    case "3":

                        /*" -1386- MOVE TAB-DESC-SITUACAO (4) TO WREG-DSCR-SITUACAO */
                        _.Move(AREA_DE_WORK.TAB_SITUACAO_RED.TB_SITUACAO_CEF_1[4].TAB_DESC_SITUACAO, AREA_DE_WORK.WREG_DETALHE.WREG_DSCR_SITUACAO);

                        /*" -1387- WHEN '4' */
                        break;
                    case "4":

                        /*" -1388- MOVE TAB-DESC-SITUACAO (5) TO WREG-DSCR-SITUACAO */
                        _.Move(AREA_DE_WORK.TAB_SITUACAO_RED.TB_SITUACAO_CEF_1[5].TAB_DESC_SITUACAO, AREA_DE_WORK.WREG_DETALHE.WREG_DSCR_SITUACAO);

                        /*" -1389- WHEN '5' */
                        break;
                    case "5":

                        /*" -1390- MOVE TAB-DESC-SITUACAO (6) TO WREG-DSCR-SITUACAO */
                        _.Move(AREA_DE_WORK.TAB_SITUACAO_RED.TB_SITUACAO_CEF_1[6].TAB_DESC_SITUACAO, AREA_DE_WORK.WREG_DETALHE.WREG_DSCR_SITUACAO);

                        /*" -1391- WHEN '6' */
                        break;
                    case "6":

                        /*" -1392- MOVE TAB-DESC-SITUACAO (7) TO WREG-DSCR-SITUACAO */
                        _.Move(AREA_DE_WORK.TAB_SITUACAO_RED.TB_SITUACAO_CEF_1[7].TAB_DESC_SITUACAO, AREA_DE_WORK.WREG_DETALHE.WREG_DSCR_SITUACAO);

                        /*" -1393- WHEN '7' */
                        break;
                    case "7":

                        /*" -1394- MOVE TAB-DESC-SITUACAO (8) TO WREG-DSCR-SITUACAO */
                        _.Move(AREA_DE_WORK.TAB_SITUACAO_RED.TB_SITUACAO_CEF_1[8].TAB_DESC_SITUACAO, AREA_DE_WORK.WREG_DETALHE.WREG_DSCR_SITUACAO);

                        /*" -1395- WHEN '8' */
                        break;
                    case "8":

                        /*" -1396- MOVE TAB-DESC-SITUACAO (9) TO WREG-DSCR-SITUACAO */
                        _.Move(AREA_DE_WORK.TAB_SITUACAO_RED.TB_SITUACAO_CEF_1[9].TAB_DESC_SITUACAO, AREA_DE_WORK.WREG_DETALHE.WREG_DSCR_SITUACAO);

                        /*" -1397- WHEN '9' */
                        break;
                    case "9":

                        /*" -1398- MOVE TAB-DESC-SITUACAO (10) TO WREG-DSCR-SITUACAO */
                        _.Move(AREA_DE_WORK.TAB_SITUACAO_RED.TB_SITUACAO_CEF_1[10].TAB_DESC_SITUACAO, AREA_DE_WORK.WREG_DETALHE.WREG_DSCR_SITUACAO);

                        /*" -1399- WHEN '*' */
                        break;
                    case "*":

                        /*" -1400- MOVE TAB-DESC-SITUACAO (11) TO WREG-DSCR-SITUACAO */
                        _.Move(AREA_DE_WORK.TAB_SITUACAO_RED.TB_SITUACAO_CEF_1[11].TAB_DESC_SITUACAO, AREA_DE_WORK.WREG_DETALHE.WREG_DSCR_SITUACAO);

                        /*" -1401- WHEN OTHER */
                        break;
                    default:

                        /*" -1402- MOVE SPACES TO WREG-DSCR-SITUACAO */
                        _.Move("", AREA_DE_WORK.WREG_DETALHE.WREG_DSCR_SITUACAO);

                        /*" -1403- END-EVALUATE */
                        break;
                }


                /*" -1403- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1953_99_SAIDA*/

        [StopWatch]
        /*" R9000-00-PROCESSO-FINAL-SECTION */
        private void R9000_00_PROCESSO_FINAL_SECTION()
        {
            /*" -1412- MOVE '9000' TO WNR-EXEC-SQL. */
            _.Move("9000", AREA_DE_WORK.WNR_EXEC_SQL);

            /*" -1413- DISPLAY ' REGS. LIDOS ....... ' WS-TOT-LIDOS. */
            _.Display($" REGS. LIDOS ....... {AREA_DE_WORK.WS_TOT_LIDOS}");

            /*" -1416- DISPLAY ' REGS. GRAVADOS .... ' WS-TOTAL-GRAV. */
            _.Display($" REGS. GRAVADOS .... {AREA_DE_WORK.WS_TOTAL_GRAV}");

            /*" -1418- CLOSE RELATORIO. */
            RELATORIO.Close();

            /*" -1419- MOVE '00/00/0000' TO WS-DATA-CURR. */
            _.Move("00/00/0000", AREA_DE_WORK.WS_DATA_CURR);

            /*" -1420- ACCEPT WS-DATA-ACCEPT FROM DATE. */
            _.Move(_.AcceptDate("DATE"), AREA_DE_WORK.WS_DATA_ACCEPT);

            /*" -1421- MOVE WS-DIA-ACCEPT TO WS-DIA-CURR */
            _.Move(AREA_DE_WORK.WS_DATA_ACCEPT.WS_DIA_ACCEPT, AREA_DE_WORK.WS_DATA_CURR.WS_DIA_CURR);

            /*" -1422- MOVE WS-MES-ACCEPT TO WS-MES-CURR */
            _.Move(AREA_DE_WORK.WS_DATA_ACCEPT.WS_MES_ACCEPT, AREA_DE_WORK.WS_DATA_CURR.WS_MES_CURR);

            /*" -1423- MOVE WS-ANO-ACCEPT TO WS-ANO-CURR */
            _.Move(AREA_DE_WORK.WS_DATA_ACCEPT.WS_ANO_ACCEPT, AREA_DE_WORK.WS_DATA_CURR.WS_ANO_CURR);

            /*" -1425- ADD 2000 TO WS-ANO-CURR. */
            AREA_DE_WORK.WS_DATA_CURR.WS_ANO_CURR.Value = AREA_DE_WORK.WS_DATA_CURR.WS_ANO_CURR + 2000;

            /*" -1426- MOVE '00:00:00' TO WS-HORA-CURR. */
            _.Move("00:00:00", AREA_DE_WORK.WS_HORA_CURR);

            /*" -1427- ACCEPT WS-HORA-ACCEPT FROM TIME. */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WS_HORA_ACCEPT);

            /*" -1428- MOVE WS-HOR-ACCEPT TO WS-HOR-CURR */
            _.Move(AREA_DE_WORK.WS_HORA_ACCEPT.WS_HOR_ACCEPT, AREA_DE_WORK.WS_HORA_CURR.WS_HOR_CURR);

            /*" -1429- MOVE WS-MIN-ACCEPT TO WS-MIN-CURR */
            _.Move(AREA_DE_WORK.WS_HORA_ACCEPT.WS_MIN_ACCEPT, AREA_DE_WORK.WS_HORA_CURR.WS_MIN_CURR);

            /*" -1431- MOVE WS-SEG-ACCEPT TO WS-SEG-CURR. */
            _.Move(AREA_DE_WORK.WS_HORA_ACCEPT.WS_SEG_ACCEPT, AREA_DE_WORK.WS_HORA_CURR.WS_SEG_CURR);

            /*" -1432- DISPLAY 'BI0602B - Final de execucao  (' WS-DATA-CURR ' - ' WS-HORA-CURR ')' . */

            $"BI0602B - Final de execucao  ({AREA_DE_WORK.WS_DATA_CURR} - {AREA_DE_WORK.WS_HORA_CURR})"
            .Display();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9000_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -1448- CLOSE RELATORIO. */
            RELATORIO.Close();

            /*" -1450- DISPLAY WABEND */
            _.Display(AREA_DE_WORK.WREG_RODAPE.WABEND);

            /*" -1450- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -1454- MOVE 99 TO RETURN-CODE */
            _.Move(99, RETURN_CODE);

            /*" -1456- DISPLAY 'BI0602B - RETURN CODE = ' RETURN-CODE */
            _.Display($"BI0602B - RETURN CODE = {RETURN_CODE}");

            /*" -1456- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}