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
using Sias.Outros.DB2.FN0301B;

namespace Code
{
    public class FN0301B
    {
        public bool IsCall { get; set; }

        public FN0301B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  INTERFACE SASSE/FENAE              *      */
        /*"      *   PROGRAMA ...............  FN0301B                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  CONSEDA4                           *      */
        /*"      *   PROGRAMADOR ............  CONSEDA4                           *      */
        /*"      *   DATA CODIFICACAO .......  AGOSTO/1999                        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO .................  CRIACAO DO MOVIMENTO DIARIO DE     *      */
        /*"      *                             EMISSAO                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * TABELA                              VIEW              ACESSO   *      */
        /*"      * -------------------------------------------------------------- *      */
        /*"      * SISTEMAS                            V1SISTEMA         INPUT    *      */
        /*"      * CLIENTES                            V1CLIENTES        INPUT    *      */
        /*"      * ENDERECOS DE CLIENTES               V1ENDERECOS       INPUT    *      */
        /*"      * ENDOSSOS                            V1ENDOSSO         INPUT    *      */
        /*"      * PARCELAS HISTORICO                  V1HISTOPARC       INPUT    *      */
        /*"      * APOLICE AUTO                        V1AUTOAPOL        INPUT    *      */
        /*"      * APOLICE CORRETORRES                 V1APOLCORRET      INPUT    *      */
        /*"      * APOLICE CLAUSULAS                   V1APOLCLAUSULA    INPUT    *      */
        /*"      * APOLICE ACESSORIOS                  V1APOLACESS       INPUT    *      */
        /*"      * APOLICE AUTO TARIFA                 V1AUTOTARIFA      INPUT    *      */
        /*"      * APOLICE AUTO COBERTURAS             V1AUTOCOBER       INPUT    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.06  * 24/09/2018 - CADMUS 168975 - LISIANE BRAGANCA SOARES           *      */
        /*"      *              MUDANCA NA PLACA DO VEICULO                       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.05  * 21/03/2014 - CADMUS 94974 - ALTERA��O NO TRATAMENTO DA         *      */
        /*"      *                             FORMARA��O DO NUMERO DA PROPOSTA   *      */
        /*"      *                             SIVPF NO ARQUIVO DE EMISS�ES       *      */
        /*"      * V.05       - COREON                                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 05             ALTERACOES NOS REGISTROS TIPO 3 E TIPO A *      */
        /*"      * ATENDE CADMUS 97713   CAMPOS :  OPERACAO E NUMERO DE CONTA     *      */
        /*"      *                                                                *      */
        /*"      * PROCURE NSGD          REGINALDO SILVA                          *      */
        /*"      *                       02/06/2014                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *    15/08/2013 - CADMUS 86262 - AJUSTE ROTINA 1215 - MAX DATA   *      */
        /*"      *                                                                *      */
        /*"      *                 REGINALDO SILVA   PROCURAR   ====> C86262      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *    06/04/2011 - CADMUS 54479 - COLOCAR CLAUSULA WITH UR NOS    *      */
        /*"      *                 COMANDOS SELECT                                *      */
        /*"      *                 SERGIO LORETO - PROCURAR POR ====> C54479      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *    23/11/2009 - CADMUS 33062 - ADEQUAR P. TRATAR OS PRODUTOS   *      */
        /*"      *                 COMERCIALIZADOS VIA AIC CREDMINAS              *      */
        /*"      *    WV1109     - W. FRANCISCO R C VERAS (TE39902)  - POLITEC    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *    25/06/2012 - CADMUS 70469 - INCLUSAO DO PANAMENRICANO       *      */
        /*"      *    V.01       - VIVIANE FONSECA  - OUTRAS REDES PROJETO PILOTO *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 03 - ATENDE SSI 23936                                 *      */
        /*"      *               VOLTA AO LAYOUT ANTERIOR OS AQUIVOS ABAIXO:      *      */
        /*"      *               EMIOUTR, FENPARC, FENCOMI, FENCOSS, FENRESS      *      */
        /*"      *                                                                *      */
        /*"      *   EM 20/11/2008 - LUCIA VIEITA             PROCURE POR V.03    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 02 - ATENDE SSI 22318                                 *      */
        /*"      *               COMPLEMENTA O RELATORIO COM PERIODICIDADE DO PGTO*      */
        /*"      *               E TOMADOR                                        *      */
        /*"      *   EM 19/08/2008 - LUCIA VIEIRA             PROCURE POR V.02    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 01 - PASSA A TRATAR O PRODUTO 1804                    *      */
        /*"      *                                                                *      */
        /*"      *   EM 29/03/2007 - FAST COMPUTER            PROCURE POR V.01    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * ALTERACAO: CELSO FERRAZ (CONTRASTE) JULHO/2005 -               *      */
        /*"      *            ACERTAR O NUMERO DA PROPOSTA NO ARQUIVO FENEMIS.    *      */
        /*"      *            IDENTIFICADA PELA SIGLA 'CASF'                      *      */
        /*"      * -------------------------------------------------------------  *      */
        /*"      *    25/06/2012 - CADMUS 70469 - INCLUSAO DO PANAMENRICANO       *      */
        /*"      *    V.04       - VIVIANE FONSECA  - OUTRAS REDES PROJETO PILOTO *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        #endregion


        #region VARIABLES

        public FileBasis _FENEMIS { get; set; } = new FileBasis(new PIC("X", "479", "X(479)"));

        public FileBasis FENEMIS
        {
            get
            {
                _.Move(REG_FENEMIS, _FENEMIS); VarBasis.RedefinePassValue(REG_FENEMIS, _FENEMIS, REG_FENEMIS); return _FENEMIS;
            }
        }
        public FileBasis _FENPANA { get; set; } = new FileBasis(new PIC("X", "479", "X(479)"));

        public FileBasis FENPANA
        {
            get
            {
                _.Move(REG_FENPANA, _FENPANA); VarBasis.RedefinePassValue(REG_FENPANA, _FENPANA, REG_FENPANA); return _FENPANA;
            }
        }
        public FileBasis _FENAUTO { get; set; } = new FileBasis(new PIC("X", "109", "X(109)"));

        public FileBasis FENAUTO
        {
            get
            {
                _.Move(REG_FENAUTO, _FENAUTO); VarBasis.RedefinePassValue(REG_FENAUTO, _FENAUTO, REG_FENAUTO); return _FENAUTO;
            }
        }
        public FileBasis _FENAUT1 { get; set; } = new FileBasis(new PIC("X", "133", "X(133)"));

        public FileBasis FENAUT1
        {
            get
            {
                _.Move(REG_FENAUT1, _FENAUT1); VarBasis.RedefinePassValue(REG_FENAUT1, _FENAUT1, REG_FENAUT1); return _FENAUT1;
            }
        }
        public FileBasis _FENVIDA { get; set; } = new FileBasis(new PIC("X", "096", "X(096)"));

        public FileBasis FENVIDA
        {
            get
            {
                _.Move(REG_FENVIDA, _FENVIDA); VarBasis.RedefinePassValue(REG_FENVIDA, _FENVIDA, REG_FENVIDA); return _FENVIDA;
            }
        }
        public FileBasis _FENOUTR { get; set; } = new FileBasis(new PIC("X", "133", "X(133)"));

        public FileBasis FENOUTR
        {
            get
            {
                _.Move(REG_FENOUTR, _FENOUTR); VarBasis.RedefinePassValue(REG_FENOUTR, _FENOUTR, REG_FENOUTR); return _FENOUTR;
            }
        }
        public FileBasis _FENPARC { get; set; } = new FileBasis(new PIC("X", "077", "X(077)"));

        public FileBasis FENPARC
        {
            get
            {
                _.Move(REG_FENPARC, _FENPARC); VarBasis.RedefinePassValue(REG_FENPARC, _FENPARC, REG_FENPARC); return _FENPARC;
            }
        }
        public FileBasis _FENCOMI { get; set; } = new FileBasis(new PIC("X", "50", "X(50)"));

        public FileBasis FENCOMI
        {
            get
            {
                _.Move(REG_FENCOMI, _FENCOMI); VarBasis.RedefinePassValue(REG_FENCOMI, _FENCOMI, REG_FENCOMI); return _FENCOMI;
            }
        }
        public FileBasis _FENCOSS { get; set; } = new FileBasis(new PIC("X", "36", "X(36)"));

        public FileBasis FENCOSS
        {
            get
            {
                _.Move(REG_FENCOSS, _FENCOSS); VarBasis.RedefinePassValue(REG_FENCOSS, _FENCOSS, REG_FENCOSS); return _FENCOSS;
            }
        }
        public FileBasis _FENRESS { get; set; } = new FileBasis(new PIC("X", "71", "X(71)"));

        public FileBasis FENRESS
        {
            get
            {
                _.Move(REG_FENRESS, _FENRESS); VarBasis.RedefinePassValue(REG_FENRESS, _FENRESS, REG_FENRESS); return _FENRESS;
            }
        }
        /*"01        REG-FENEMIS           PIC  X(479).*/
        public StringBasis REG_FENEMIS { get; set; } = new StringBasis(new PIC("X", "479", "X(479)."), @"");
        /*"01        REG-FENPANA           PIC  X(479).*/
        public StringBasis REG_FENPANA { get; set; } = new StringBasis(new PIC("X", "479", "X(479)."), @"");
        /*"01        REG-FENAUTO           PIC  X(109).*/
        public StringBasis REG_FENAUTO { get; set; } = new StringBasis(new PIC("X", "109", "X(109)."), @"");
        /*"01        REG-FENAUT1           PIC  X(133).*/
        public StringBasis REG_FENAUT1 { get; set; } = new StringBasis(new PIC("X", "133", "X(133)."), @"");
        /*"01        REG-FENVIDA           PIC  X(096).*/
        public StringBasis REG_FENVIDA { get; set; } = new StringBasis(new PIC("X", "96", "X(096)."), @"");
        /*"01        REG-FENOUTR           PIC  X(133).*/
        public StringBasis REG_FENOUTR { get; set; } = new StringBasis(new PIC("X", "133", "X(133)."), @"");
        /*"01        REG-FENPARC           PIC  X(077).*/
        public StringBasis REG_FENPARC { get; set; } = new StringBasis(new PIC("X", "77", "X(077)."), @"");
        /*"01        REG-FENCOMI           PIC  X(050).*/
        public StringBasis REG_FENCOMI { get; set; } = new StringBasis(new PIC("X", "50", "X(050)."), @"");
        /*"01        REG-FENCOSS           PIC  X(036).*/
        public StringBasis REG_FENCOSS { get; set; } = new StringBasis(new PIC("X", "36", "X(036)."), @"");
        /*"01        REG-FENRESS           PIC  X(071).*/
        public StringBasis REG_FENRESS { get; set; } = new StringBasis(new PIC("X", "71", "X(071)."), @"");

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"*/
        public IntBasis INDX { get; set; } = new IntBasis(new PIC("9", "4", "9(4)"));
        /*"77         VIND-CODPRODU       PIC S9(004)   COMP    VALUE -1.*/
        public IntBasis VIND_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), -1);
        /*"77         VIND-DTQITBCO       PIC S9(004)   COMP    VALUE -1.*/
        public IntBasis VIND_DTQITBCO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), -1);
        /*"77         VIND-VLPREMIO       PIC S9(004)   COMP    VALUE -1.*/
        public IntBasis VIND_VLPREMIO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), -1);
        /*"77         VIND-ZEROKM         PIC S9(004)   COMP    VALUE -1.*/
        public IntBasis VIND_ZEROKM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), -1);
        /*"77         VIND-SEGBONUS       PIC S9(004)   COMP    VALUE -1.*/
        public IntBasis VIND_SEGBONUS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), -1);
        /*"77         VIND-NRITEM         PIC S9(004)   COMP    VALUE -1.*/
        public IntBasis VIND_NRITEM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), -1);
        /*"77         VIND-CODRESSEG      PIC S9(004)   COMP    VALUE -1.*/
        public IntBasis VIND_CODRESSEG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), -1);
        /*"77         AC-PARC             PIC S9(004)                COMP.*/
        public IntBasis AC_PARC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         AC-QUOC             PIC S9(009)                COMP-3*/
        public IntBasis AC_QUOC { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         AC-RESTO            PIC S9(009)                COMP-3*/
        public IntBasis AC_RESTO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         WHOST-CODCORR       PIC S9(009)                COMP.*/
        public IntBasis WHOST_CODCORR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         WHOST-COUNT         PIC S9(009)                COMP.*/
        public IntBasis WHOST_COUNT { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         WHOST-CODCLIEN      PIC S9(009)                COMP.*/
        public IntBasis WHOST_CODCLIEN { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         WHOST-NRPARCEL      PIC S9(004)                COMP.*/
        public IntBasis WHOST_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         WHOST-CODENDER      PIC S9(004)                COMP.*/
        public IntBasis WHOST_CODENDER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         WHOST-NRITEM        PIC S9(004)                COMP.*/
        public IntBasis WHOST_NRITEM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         WHOST-MATRIC-IND    PIC S9(015)                COMP-3*/
        public IntBasis WHOST_MATRIC_IND { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77         WHOST-PROPOSTA-VC   PIC S9(015)                COMP-3*/
        public IntBasis WHOST_PROPOSTA_VC { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77         WHOST-NRRCAP        PIC S9(009)                COMP.*/
        public IntBasis WHOST_NRRCAP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         WS-QTD-FENAE        PIC S9(004)                COMP.*/
        public IntBasis WS_QTD_FENAE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         WS-CGCCPF           PIC S9(015)                COMP.*/
        public IntBasis WS_CGCCPF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"01   WS-AULIARES.*/
        public FN0301B_WS_AULIARES WS_AULIARES { get; set; } = new FN0301B_WS_AULIARES();
        public class FN0301B_WS_AULIARES : VarBasis
        {
            /*"  05 WS-PANAMERICANO         PIC X(001).*/

            public SelectorBasis WS_PANAMERICANO { get; set; } = new SelectorBasis("001")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 WS-PANAM-ACHOU       VALUE 'S'. */
							new SelectorItemBasis("WS_PANAM_ACHOU", "S"),
							/*" 88 WS-PANAM-NAO-ACHOU   VALUE 'N'. */
							new SelectorItemBasis("WS_PANAM_NAO_ACHOU", "N")
                }
            };

            /*"77         V1SIST-DTMOVABE     PIC  X(010).*/
        }
        public StringBasis V1SIST_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1SIST-TIMESTAMP    PIC  X(026).*/
        public StringBasis V1SIST_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(026)."), @"");
        /*"77         V1CLIE-NOME        PIC  X(040).*/
        public StringBasis V1CLIE_NOME { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"77         V1CLIE-TPPESSOA    PIC  X(001).*/
        public StringBasis V1CLIE_TPPESSOA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1CLIE-CGCCPF      PIC S9(015)                 COMP-3*/
        public IntBasis V1CLIE_CGCCPF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77         V1PROD-CODPDT      PIC S9(009)                 COMP.*/
        public IntBasis V1PROD_CODPDT { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1PROD-NOMPDT      PIC  X(040).*/
        public StringBasis V1PROD_NOMPDT { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"77         V1PROD-RGSUSEP     PIC  X(013).*/
        public StringBasis V1PROD_RGSUSEP { get; set; } = new StringBasis(new PIC("X", "13", "X(013)."), @"");
        /*"77         V1APCR-NUM-APOL    PIC S9(013)                 COMP-3*/
        public IntBasis V1APCR_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V1APCR-CODSUBES    PIC S9(004)                 COMP.*/
        public IntBasis V1APCR_CODSUBES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1APCR-RAMOFR      PIC S9(004)                 COMP.*/
        public IntBasis V1APCR_RAMOFR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1APCR-CODCORR     PIC S9(009)                 COMP.*/
        public IntBasis V1APCR_CODCORR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1APCR-PCCOMCOR    PIC S9(003)V99              COMP-3*/
        public DoubleBasis V1APCR_PCCOMCOR { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"77         V1APCR-PCPARCOR    PIC S9(003)V99              COMP-3*/
        public DoubleBasis V1APCR_PCPARCOR { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"77         V1APCR-TIPCOM      PIC  X(001).*/
        public StringBasis V1APCR_TIPCOM { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1APCC-NUM-APOL    PIC S9(013)                 COMP-3*/
        public IntBasis V1APCC_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V1APCC-CODCOSS     PIC S9(004)                 COMP.*/
        public IntBasis V1APCC_CODCOSS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1APCC-PCPARTIC    PIC S9(004)V9(5)            COMP-3*/
        public DoubleBasis V1APCC_PCPARTIC { get; set; } = new DoubleBasis(new PIC("S9", "4", "S9(004)V9(5)"), 5);
        /*"77         V1APCC-PCCOMCOS    PIC S9(003)V99              COMP-3*/
        public DoubleBasis V1APCC_PCCOMCOS { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"77         V1HRES-NUMAPOL     PIC S9(013)                 COMP-3*/
        public IntBasis V1HRES_NUMAPOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V1HRES-NRENDOS     PIC S9(009)                 COMP.*/
        public IntBasis V1HRES_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1HRES-NRITEM      PIC S9(009)                 COMP.*/
        public IntBasis V1HRES_NRITEM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1HRES-OCORHIST    PIC S9(004)                 COMP.*/
        public IntBasis V1HRES_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1HRES-CODRESSEG   PIC S9(004)                 COMP.*/
        public IntBasis V1HRES_CODRESSEG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1HRES-RAMOFR      PIC S9(004)                 COMP.*/
        public IntBasis V1HRES_RAMOFR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1HRES-PCTRSP      PIC S9(004)V9(5)            COMP-3*/
        public DoubleBasis V1HRES_PCTRSP { get; set; } = new DoubleBasis(new PIC("S9", "4", "S9(004)V9(5)"), 5);
        /*"77         V1HRES-PCTCOMRS    PIC S9(004)V9(5)            COMP-3*/
        public DoubleBasis V1HRES_PCTCOMRS { get; set; } = new DoubleBasis(new PIC("S9", "4", "S9(004)V9(5)"), 5);
        /*"77          V1ENDE-ENDERECO   PIC  X(040).*/
        public StringBasis V1ENDE_ENDERECO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"77          V1ENDE-CIDADE     PIC  X(020).*/
        public StringBasis V1ENDE_CIDADE { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
        /*"77          V1ENDE-BAIRRO     PIC  X(020).*/
        public StringBasis V1ENDE_BAIRRO { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
        /*"77          V1ENDE-CEP        PIC S9(009)                 COMP.*/
        public IntBasis V1ENDE_CEP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77          V1ENDE-ESTADO     PIC  X(002).*/
        public StringBasis V1ENDE_ESTADO { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
        /*"77          V1ENDE-DDD        PIC S9(004)                 COMP.*/
        public IntBasis V1ENDE_DDD { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V1ENDE-TELEFONE   PIC S9(009)                 COMP.*/
        public IntBasis V1ENDE_TELEFONE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1SUBG-NUMAPOL     PIC S9(013)       COMP-3.*/
        public IntBasis V1SUBG_NUMAPOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V1SUBG-CODSUBES    PIC S9(004)       COMP.*/
        public IntBasis V1SUBG_CODSUBES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1ENDO-NUMAPOL     PIC S9(013)       COMP-3.*/
        public IntBasis V1ENDO_NUMAPOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V1ENDO-NRENDOS     PIC S9(009)       COMP.*/
        public IntBasis V1ENDO_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1ENDO-RAMO        PIC S9(004)       COMP.*/
        public IntBasis V1ENDO_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1ENDO-ORGAO       PIC S9(004)       COMP.*/
        public IntBasis V1ENDO_ORGAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1ENDO-FONTE       PIC S9(004)       COMP.*/
        public IntBasis V1ENDO_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1ENDO-CODCLIEN    PIC S9(009)       COMP.*/
        public IntBasis V1ENDO_CODCLIEN { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1ENDO-DTINIVIG    PIC  X(010).*/
        public StringBasis V1ENDO_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1ENDO-DTTERVIG    PIC  X(010).*/
        public StringBasis V1ENDO_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1ENDO-DTEMIS      PIC  X(010).*/
        public StringBasis V1ENDO_DTEMIS { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1ENDO-QTITENS     PIC S9(004)       COMP.*/
        public IntBasis V1ENDO_QTITENS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1ENDO-CODPRODU    PIC S9(004)       COMP.*/
        public IntBasis V1ENDO_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1ENDO-OCORR-END   PIC S9(004)       COMP.*/
        public IntBasis V1ENDO_OCORR_END { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1ENDO-CORRECAO    PIC  X(001).*/
        public StringBasis V1ENDO_CORRECAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1ENDO-MOEDA-PRM   PIC S9(004)       COMP.*/
        public IntBasis V1ENDO_MOEDA_PRM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1ENDO-MOEDA-IMP   PIC S9(004)       COMP.*/
        public IntBasis V1ENDO_MOEDA_IMP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1ENDO-TIPO-ENDO   PIC  X(001).*/
        public StringBasis V1ENDO_TIPO_ENDO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1ENDO-TIPO-APOL   PIC  X(001).*/
        public StringBasis V1ENDO_TIPO_APOL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1ENDO-NRPROPOS    PIC S9(009)       COMP.*/
        public IntBasis V1ENDO_NRPROPOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1ENDO-QTPARCEL    PIC S9(004)       COMP.*/
        public IntBasis V1ENDO_QTPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1ENDO-CODSUBES    PIC S9(004)       COMP.*/
        public IntBasis V1ENDO_CODSUBES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1ENDO-SITUACAO    PIC  X(001).*/
        public StringBasis V1ENDO_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1ENDO-NUMBIL      PIC S9(015)       COMP-3.*/
        public IntBasis V1ENDO_NUMBIL { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77         V1ENDO-NRRCAP      PIC S9(009)       COMP.*/
        public IntBasis V1ENDO_NRRCAP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1ENDO-APOLANT     PIC S9(013)       COMP-3.*/
        public IntBasis V1ENDO_APOLANT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V1ENDO-AGERCAP     PIC S9(004)       COMP.*/
        public IntBasis V1ENDO_AGERCAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1ENDO-AGECOBR     PIC S9(004)       COMP.*/
        public IntBasis V1ENDO_AGECOBR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0ENDO-NRRCAP      PIC S9(009)       COMP.*/
        public IntBasis V0ENDO_NRRCAP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0RCAP-AGECOBR     PIC S9(004)       COMP.*/
        public IntBasis V0RCAP_AGECOBR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0RCAP-NRCERTIF    PIC S9(015)       COMP-3.*/
        public IntBasis V0RCAP_NRCERTIF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77          V1PARC-NUMAPOL     PIC S9(013)                COMP-3*/
        public IntBasis V1PARC_NUMAPOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77          V1PARC-NRENDOS     PIC S9(009)                COMP.*/
        public IntBasis V1PARC_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77          V1PARC-NRPARCEL    PIC S9(004)                COMP.*/
        public IntBasis V1PARC_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V1PARC-NRTIT       PIC S9(013)                COMP-3*/
        public IntBasis V1PARC_NRTIT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77          V1PARC-QTDOCORR    PIC S9(004)                COMP.*/
        public IntBasis V1PARC_QTDOCORR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V1PARC-VLPRMLIQ    PIC S9(010)V9(05)          COMP-3*/
        public DoubleBasis V1PARC_VLPRMLIQ { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(05)"), 5);
        /*"77          V1PARC-SITUACAO    PIC  X(001).*/
        public StringBasis V1PARC_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77          V1HISP-NUMAPOL     PIC S9(013)                COMP-3*/
        public IntBasis V1HISP_NUMAPOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77          V1HISP-NRENDOS     PIC S9(009)                COMP.*/
        public IntBasis V1HISP_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77          V1HISP-NRPARCEL    PIC S9(004)                COMP.*/
        public IntBasis V1HISP_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V1HISP-OCORHIST    PIC S9(004)                COMP.*/
        public IntBasis V1HISP_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V1HISP-OPERACAO    PIC S9(004)                COMP.*/
        public IntBasis V1HISP_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V1HISP-VLPRMTOT    PIC S9(013)V99             COMP-3*/
        public DoubleBasis V1HISP_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77          V1HISP-VLPRMLIQ    PIC S9(013)V99             COMP-3*/
        public DoubleBasis V1HISP_VLPRMLIQ { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77          V1HISP-DTVENCTO    PIC  X(010).*/
        public StringBasis V1HISP_DTVENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77          V1HISP-DTMOVTO     PIC  X(010).*/
        public StringBasis V1HISP_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77          V1HISP-DTQITBCO    PIC  X(010).*/
        public StringBasis V1HISP_DTQITBCO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77          V1HISP-VLPREMIO    PIC S9(013)V99             COMP-3*/
        public DoubleBasis V1HISP_VLPREMIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77          V1DCVI-CDVEICL    PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V1DCVI_CDVEICL { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77          V1DCVI-DESCMARC   PIC  X(020).*/
        public StringBasis V1DCVI_DESCMARC { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
        /*"77          V1DCVI-DESCVEIC   PIC  X(040).*/
        public StringBasis V1DCVI_DESCVEIC { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"77         V1AUTO-COD-EMPRESA  PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V1AUTO_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1AUTO-FONTE        PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V1AUTO_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1AUTO-NRPROPOS     PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V1AUTO_NRPROPOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1AUTO-NRITEM       PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V1AUTO_NRITEM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1AUTO-DTINIVIG     PIC  X(010).*/
        public StringBasis V1AUTO_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1AUTO-DTTERVIG     PIC  X(010).*/
        public StringBasis V1AUTO_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1AUTO-TIPOVEIC     PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V1AUTO_TIPOVEIC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1AUTO-FABRICAN     PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V1AUTO_FABRICAN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1AUTO-CDVEICL      PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V1AUTO_CDVEICL { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1AUTO-COMBUST      PIC  X(001).*/
        public StringBasis V1AUTO_COMBUST { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1AUTO-ANOVEICL     PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V1AUTO_ANOVEICL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1AUTO-ANOMOD       PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V1AUTO_ANOMOD { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1AUTO-CORVEICL     PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V1AUTO_CORVEICL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1AUTO-CAPACID      PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V1AUTO_CAPACID { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1AUTO-LOTACAO      PIC  X(001).*/
        public StringBasis V1AUTO_LOTACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1AUTO-PLACAUF      PIC  X(002).*/
        public StringBasis V1AUTO_PLACAUF { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
        /*"77         V1AUTO-PLACALET     PIC  X(003).*/
        public StringBasis V1AUTO_PLACALET { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
        /*"77         V1AUTO-PLACANR      PIC  X(004)       VALUE SPACES.*/
        public StringBasis V1AUTO_PLACANR { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
        /*"77         V1AUTO-CHASSIS      PIC  X(020).*/
        public StringBasis V1AUTO_CHASSIS { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
        /*"77         V1AUTO-UTILIZA      PIC  X(001).*/
        public StringBasis V1AUTO_UTILIZA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1AUTO-QTACESS      PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V1AUTO_QTACESS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1AUTO-DTBAIXA      PIC  X(010).*/
        public StringBasis V1AUTO_DTBAIXA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1AUTO-CDVISTOR     PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V1AUTO_CDVISTOR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1AUTO-PROPRIET     PIC  X(040).*/
        public StringBasis V1AUTO_PROPRIET { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"77         V1AUTO-DTIVEXTP     PIC  X(010).*/
        public StringBasis V1AUTO_DTIVEXTP { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1AUTO-ACEITE       PIC  X(001).*/
        public StringBasis V1AUTO_ACEITE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1AUTO-NRPRRESS     PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V1AUTO_NRPRRESS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1AUTO-PROTSINI     PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V1AUTO_PROTSINI { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1AUTO-SITUACAO     PIC  X(001).*/
        public StringBasis V1AUTO_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1AUTO-CODCLIEN     PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V1AUTO_CODCLIEN { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1AUTO-NUMAPOL      PIC S9(013)       VALUE +0 COMP-3*/
        public IntBasis V1AUTO_NUMAPOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V1AUTO-NRENDOS      PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V1AUTO_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1AUTO-ZEROKM       PIC  X(001).*/
        public StringBasis V1AUTO_ZEROKM { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1AUTO-SEGBONUS     PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V1AUTO_SEGBONUS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1AUTO-TIPOCOBER    PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V1AUTO_TIPOCOBER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V2AUTO-QTDITENS     PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V2AUTO_QTDITENS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1CLAU-DESCCLAUS    PIC  X(120)       VALUE SPACES.*/
        public StringBasis V1CLAU_DESCCLAUS { get; set; } = new StringBasis(new PIC("X", "120", "X(120)"), @"");
        /*"77         V1APAC-NUMAPOL      PIC S9(013)       VALUE +0 COMP-3*/
        public IntBasis V1APAC_NUMAPOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V1APAC-NRITEM       PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V1APAC_NRITEM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1APAC-NRENDOS      PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V1APAC_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1APAC-CDACESS      PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V1APAC_CDACESS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1APAC-VRACESS      PIC S9(013)V99    VALUE +0 COMP-3*/
        public DoubleBasis V1APAC_VRACESS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V1APAC-VRPLAACE     PIC S9(013)V99    VALUE +0 COMP-3*/
        public DoubleBasis V1APAC_VRPLAACE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V1APAC-VRPRBACE     PIC S9(013)V99    VALUE +0 COMP-3*/
        public DoubleBasis V1APAC_VRPRBACE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V1APAC-IDEACESS     PIC  X(001)       VALUE SPACES.*/
        public StringBasis V1APAC_IDEACESS { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"77         V1ACES-DESCACESS    PIC  X(040)       VALUE SPACES.*/
        public StringBasis V1ACES_DESCACESS { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
        /*"77         V1TARI-TIPOCOB      PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V1TARI_TIPOCOB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1TARI-REGIAO       PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V1TARI_REGIAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1TARI-FRANQFAC     PIC  X(001)      VALUE SPACES.*/
        public StringBasis V1TARI_FRANQFAC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"77         V1TARI-CLABONAT     PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V1TARI_CLABONAT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1TARI-CATAUTO      PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V1TARI_CATAUTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1TARI-CATRCF       PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V1TARI_CATRCF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1TARI-VRFROBR-IX   PIC S9(013)V99   VALUE +0  COMP-3*/
        public DoubleBasis V1TARI_VRFROBR_IX { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V1TARI-VRFRFACC-IX  PIC S9(013)V99   VALUE +0  COMP-3*/
        public DoubleBasis V1TARI_VRFRFACC_IX { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V1TARI-VRFRFACA-IX  PIC S9(013)V99   VALUE +0  COMP-3*/
        public DoubleBasis V1TARI_VRFRFACA_IX { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V1TARI-VRFRADIC-IX  PIC S9(013)V99   VALUE +0  COMP-3*/
        public DoubleBasis V1TARI_VRFRADIC_IX { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V1TARI-TPCDSBAU     PIC S9(003)V9(2) VALUE +0  COMP-3*/
        public DoubleBasis V1TARI_TPCDSBAU { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(2)"), 2);
        /*"77         V1TARI-TPCPZSEG     PIC S9(005)V99   VALUE +0  COMP-3*/
        public DoubleBasis V1TARI_TPCPZSEG { get; set; } = new DoubleBasis(new PIC("S9", "5", "S9(005)V99"), 2);
        /*"77         V1TARI-TPCBONDM     PIC S9(003)V99   VALUE +0  COMP-3*/
        public DoubleBasis V1TARI_TPCBONDM { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"77         V1TARI-TPCBONDP     PIC S9(003)V99   VALUE +0  COMP-3*/
        public DoubleBasis V1TARI_TPCBONDP { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"77         V1TARI-DTINIVIG     PIC  X(010)      VALUE SPACES.*/
        public StringBasis V1TARI_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77         V1TARI-DTTERVIG     PIC  X(010)      VALUE SPACES.*/
        public StringBasis V1TARI_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77         V1TARI-DTINIVIG-1DIA PIC  X(010)     VALUE SPACES.*/
        public StringBasis V1TARI_DTINIVIG_1DIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77         V1AUCB-COD-EMPRESA  PIC S9(009)      VALUE +0  COMP.*/
        public IntBasis V1AUCB_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1AUCB-FONTE        PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V1AUCB_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1AUCB-NRPROPOS     PIC S9(009)      VALUE +0  COMP.*/
        public IntBasis V1AUCB_NRPROPOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1AUCB-NRITEM       PIC S9(009)      VALUE +0  COMP.*/
        public IntBasis V1AUCB_NRITEM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1AUCB-RAMOFR       PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V1AUCB_RAMOFR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1AUCB-MODALIFR     PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V1AUCB_MODALIFR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1AUCB-CODCOBER     PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V1AUCB_CODCOBER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1AUCB-DTINIVIG     PIC  X(010).*/
        public StringBasis V1AUCB_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1AUCB-DTTERVIG     PIC  X(010).*/
        public StringBasis V1AUCB_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1AUCB-IMP-SEG-IX   PIC S9(013)V99   VALUE +0  COMP-3*/
        public DoubleBasis V1AUCB_IMP_SEG_IX { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V1AUCB-IMP-SEG-VR   PIC S9(013)V99   VALUE +0  COMP-3*/
        public DoubleBasis V1AUCB_IMP_SEG_VR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V1AUCB-TAXA-IS      PIC S9(002)V9(5) VALUE +0  COMP-3*/
        public DoubleBasis V1AUCB_TAXA_IS { get; set; } = new DoubleBasis(new PIC("S9", "2", "S9(002)V9(5)"), 5);
        /*"77         V1AUCB-PRM-ANU-IX   PIC S9(010)V9(5) VALUE +0  COMP-3*/
        public DoubleBasis V1AUCB_PRM_ANU_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77         V1AUCB-PRM-TAR-IX   PIC S9(010)V9(5) VALUE +0  COMP-3*/
        public DoubleBasis V1AUCB_PRM_TAR_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77         V1AUCB-PRM-TAR-VAR  PIC S9(010)V9(5) VALUE +0  COMP-3*/
        public DoubleBasis V1AUCB_PRM_TAR_VAR { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77         V1AUCB-SITUACAO     PIC  X(001).*/
        public StringBasis V1AUCB_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1AUCB-NUMAPOL      PIC S9(013)      VALUE +0  COMP-3*/
        public IntBasis V1AUCB_NUMAPOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V1AUCB-NRENDOS      PIC S9(009)      VALUE +0  COMP.*/
        public IntBasis V1AUCB_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1APCL-COD-EMPRESA  PIC S9(009)      VALUE +0  COMP.*/
        public IntBasis V1APCL_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1APCL-NUMAPOL      PIC S9(013)      VALUE +0  COMP-3*/
        public IntBasis V1APCL_NUMAPOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V1APCL-NRENDOS      PIC S9(009)      VALUE +0  COMP.*/
        public IntBasis V1APCL_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1APCL-RAMOFR       PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V1APCL_RAMOFR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1APCL-MODALIFR     PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V1APCL_MODALIFR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1APCL-CODCOBER     PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V1APCL_CODCOBER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1APCL-DTINIVIG     PIC  X(010).*/
        public StringBasis V1APCL_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1APCL-DTTERVIG     PIC  X(010).*/
        public StringBasis V1APCL_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1APCL-NRITEM       PIC S9(009)      VALUE +0  COMP.*/
        public IntBasis V1APCL_NRITEM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1APCL-CODCLAUS     PIC  X(003).*/
        public StringBasis V1APCL_CODCLAUS { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
        /*"77         V1APCL-TIPOCLAU     PIC  X(001).*/
        public StringBasis V1APCL_TIPOCLAU { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1APCL-LIMINDENIX   PIC S9(010)V9(5) VALUE +0  COMP-3*/
        public DoubleBasis V1APCL_LIMINDENIX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77         V1APCL-TIMESTAMP    PIC  X(026).*/
        public StringBasis V1APCL_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(026)."), @"");
        /*"77         V1FATT-NUMAPOL      PIC S9(013)                COMP-3*/
        public IntBasis V1FATT_NUMAPOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V1FATT-CODSUBES     PIC S9(004)                COMP.*/
        public IntBasis V1FATT_CODSUBES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1FATT-NUM-FATUR    PIC S9(009)                COMP.*/
        public IntBasis V1FATT_NUM_FATUR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1FATT-COD-OPER     PIC S9(004)                COMP.*/
        public IntBasis V1FATT_COD_OPER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1FATT-QT-VIDA-VG   PIC S9(009)                COMP.*/
        public IntBasis V1FATT_QT_VIDA_VG { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1FATT-QT-VIDA-AP   PIC S9(009)                COMP.*/
        public IntBasis V1FATT_QT_VIDA_AP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1FATT-IMP-MORNAT   PIC S9(013)V9(2)           COMP-3*/
        public DoubleBasis V1FATT_IMP_MORNAT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"77         V1FATT-IMP-MORACI   PIC S9(013)V9(2)           COMP-3*/
        public DoubleBasis V1FATT_IMP_MORACI { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"77         V1FATT-IMP-INVPER   PIC S9(013)V9(2)           COMP-3*/
        public DoubleBasis V1FATT_IMP_INVPER { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"77         V1FATT-IMP-AMDS     PIC S9(013)V9(2)           COMP-3*/
        public DoubleBasis V1FATT_IMP_AMDS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"77         V1FATT-IMP-DH       PIC S9(013)V9(2)           COMP-3*/
        public DoubleBasis V1FATT_IMP_DH { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"77         V1FATT-IMP-DIT      PIC S9(013)V9(2)           COMP-3*/
        public DoubleBasis V1FATT_IMP_DIT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"77         V1FATT-PRM-VG       PIC S9(013)V9(2)           COMP-3*/
        public DoubleBasis V1FATT_PRM_VG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"77         V1FATT-PRM-AP       PIC S9(013)V9(2)           COMP-3*/
        public DoubleBasis V1FATT_PRM_AP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"77         V1FATT-SIT-REGIS    PIC  X(001).*/
        public StringBasis V1FATT_SIT_REGIS { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1FATT-COD-EMPRESA  PIC S9(009)                COMP.*/
        public IntBasis V1FATT_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1SEGV-NRCERTIF     PIC S9(015)      VALUE +0  COMP-3*/
        public IntBasis V1SEGV_NRCERTIF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77         V1SEGV-TIPOSEG      PIC  X(001).*/
        public StringBasis V1SEGV_TIPOSEG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1SEGV-DTINIVIG     PIC  X(010).*/
        public StringBasis V1SEGV_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1SEGV-CODCLIEN     PIC S9(009)      VALUE +0  COMP.*/
        public IntBasis V1SEGV_CODCLIEN { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1SEGV-OCORREND     PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V1SEGV_OCORREND { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1SEGV-DATNASC      PIC  X(010).*/
        public StringBasis V1SEGV_DATNASC { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1SEGV-ESTCIV       PIC  X(001).*/
        public StringBasis V1SEGV_ESTCIV { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1SEGV-CODAGENC     PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V1SEGV_CODAGENC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1SEGV-TIPOBENEF    PIC  X(001).*/
        public StringBasis V1SEGV_TIPOBENEF { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1SEGV-NRITEM       PIC S9(009)      VALUE +0  COMP.*/
        public IntBasis V1SEGV_NRITEM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1HSVG-MOEDA-IMP    PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V1HSVG_MOEDA_IMP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1HSVG-MOEDA-PRM    PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V1HSVG_MOEDA_PRM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1COBA-NRITEM       PIC S9(009)      VALUE +0  COMP.*/
        public IntBasis V1COBA_NRITEM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1COBA-CODCOBER     PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V1COBA_CODCOBER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1COBA-RAMOFR       PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V1COBA_RAMOFR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1COBA-DTINIVIG     PIC  X(010).*/
        public StringBasis V1COBA_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1COBA-DTTERVIG     PIC  X(010).*/
        public StringBasis V1COBA_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1COBA-IMP-SEG-IX   PIC S9(013)V99   VALUE +0  COMP-3*/
        public DoubleBasis V1COBA_IMP_SEG_IX { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V1COBA-PRM-TAR-VAR  PIC S9(010)V9(5) VALUE +0  COMP-3*/
        public DoubleBasis V1COBA_PRM_TAR_VAR { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77         V1COBA-PRMVG        PIC S9(010)V9(5) VALUE +0  COMP-3*/
        public DoubleBasis V1COBA_PRMVG { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77         V1COBA-PRMAP        PIC S9(010)V9(5) VALUE +0  COMP-3*/
        public DoubleBasis V1COBA_PRMAP { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77         V1OCOB-NRRISCO      PIC S9(009)      VALUE +0  COMP.*/
        public IntBasis V1OCOB_NRRISCO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1OCOB-CODCOBER     PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V1OCOB_CODCOBER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1OCOB-RAMOFR       PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V1OCOB_RAMOFR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1OCOB-DTINIVIG     PIC  X(010).*/
        public StringBasis V1OCOB_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1OCOB-DTTERVIG     PIC  X(010).*/
        public StringBasis V1OCOB_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1OCOB-IMP-SEG-IX   PIC S9(013)V99   VALUE +0  COMP-3*/
        public DoubleBasis V1OCOB_IMP_SEG_IX { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V1OCOB-PRM-TAR-VAR  PIC S9(010)V9(5) VALUE +0  COMP-3*/
        public DoubleBasis V1OCOB_PRM_TAR_VAR { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77         V1OCOB-VRFROBR-IX   PIC S9(013)V99   VALUE +0  COMP-3*/
        public DoubleBasis V1OCOB_VRFROBR_IX { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V1OCOB-LIMINDENIZ   PIC S9(010)V9(5) VALUE +0  COMP-3*/
        public DoubleBasis V1OCOB_LIMINDENIZ { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77         V1BENF-NUMBENEF     PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V1BENF_NUMBENEF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1BENF-DTINIVIG     PIC  X(010).*/
        public StringBasis V1BENF_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1BENF-DTTERVIG     PIC  X(010).*/
        public StringBasis V1BENF_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1BENF-NOMBENEF     PIC  X(040).*/
        public StringBasis V1BENF_NOMBENEF { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"77         V1BENF-PARENTESCO   PIC  X(010).*/
        public StringBasis V1BENF_PARENTESCO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1BENF-PERCBENEF    PIC S9(003)V99   VALUE +0  COMP-3*/
        public DoubleBasis V1BENF_PERCBENEF { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"01        WS-DESCR-TOMADOR.*/
        public FN0301B_WS_DESCR_TOMADOR WS_DESCR_TOMADOR { get; set; } = new FN0301B_WS_DESCR_TOMADOR();
        public class FN0301B_WS_DESCR_TOMADOR : VarBasis
        {
            /*"   05     FILLER                 PIC X(30)           VALUE 'NAO HA TOMADOR PARA O PRODUTO '.*/
            public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"NAO HA TOMADOR PARA O PRODUTO ");
            /*"   05     WS-COD-PRODUTO         PIC 9(04).*/
            public IntBasis WS_COD_PRODUTO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
            /*"   05     FILLER  VALUE SPACES   PIC X(06).*/
            public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "6", "X(06)."), @"");
            /*"01 WPERI-PGTO.*/
        }
        public FN0301B_WPERI_PGTO WPERI_PGTO { get; set; } = new FN0301B_WPERI_PGTO();
        public class FN0301B_WPERI_PGTO : VarBasis
        {
            /*"   05     PERI-PGTO-WS           PIC 9(04).*/
            public IntBasis PERI_PGTO_WS { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
            /*"01         WREG-HEADER.*/
        }
        public FN0301B_WREG_HEADER WREG_HEADER { get; set; } = new FN0301B_WREG_HEADER();
        public class FN0301B_WREG_HEADER : VarBasis
        {
            /*"  05       FHDR-PROGRAMA         PIC  X(006)    VALUE 'FN0301'.*/
            public StringBasis FHDR_PROGRAMA { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"FN0301");
            /*"  05       FHDR-TIPOREG          PIC  X(008)    VALUE 'HEADER'.*/
            public StringBasis FHDR_TIPOREG { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"HEADER");
            /*"  05       FHDR-DTMOVABE         PIC  X(010).*/
            public StringBasis FHDR_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"01         WREG-TRAILLER.*/
        }
        public FN0301B_WREG_TRAILLER WREG_TRAILLER { get; set; } = new FN0301B_WREG_TRAILLER();
        public class FN0301B_WREG_TRAILLER : VarBasis
        {
            /*"  05       FTRL-PROGRAMA         PIC  X(006)    VALUE 'FN0301'.*/
            public StringBasis FTRL_PROGRAMA { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"FN0301");
            /*"  05       FTRL-TIPOREG          PIC  X(008)    VALUE 'TRAILLER'*/
            public StringBasis FTRL_TIPOREG { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"TRAILLER");
            /*"  05       FTRL-DTMOVABE         PIC  X(010).*/
            public StringBasis FTRL_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  05       FTRL-QTDREG           PIC  9(009).*/
            public IntBasis FTRL_QTDREG { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"01         WREG-FENEMIS.*/
        }
        public FN0301B_WREG_FENEMIS WREG_FENEMIS { get; set; } = new FN0301B_WREG_FENEMIS();
        public class FN0301B_WREG_FENEMIS : VarBasis
        {
            /*"  05       FEMI-NUMAPOL          PIC  9(013).*/
            public IntBasis FEMI_NUMAPOL { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
            /*"  05       FILLER                PIC  X(001)        VALUE ';'.*/
            public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05       FEMI-NRENDOS          PIC  9(009).*/
            public IntBasis FEMI_NRENDOS { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"  05       FILLER                PIC  X(001)        VALUE ';'.*/
            public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05       FEMI-CODSUBES         PIC  9(004).*/
            public IntBasis FEMI_CODSUBES { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05       FILLER                PIC  X(001)        VALUE ';'.*/
            public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05       FEMI-FONTE            PIC  9(004).*/
            public IntBasis FEMI_FONTE { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05       FILLER                PIC  X(001)        VALUE ';'.*/
            public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05       FEMI-NRPROPOS         PIC  9(009).*/
            public IntBasis FEMI_NRPROPOS { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"  05       FILLER                PIC  X(001)        VALUE ';'.*/
            public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05       FEMI-NUMBIL           PIC  9(015).*/
            public IntBasis FEMI_NUMBIL { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
            /*"  05       FILLER                PIC  X(001)        VALUE ';'.*/
            public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05       FEMI-NUMSICOB         PIC  9(009).*/
            public IntBasis FEMI_NUMSICOB { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"  05       FILLER                PIC  X(001)        VALUE ';'.*/
            public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05       FEMI-CODRAMO          PIC  9(004).*/
            public IntBasis FEMI_CODRAMO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05       FILLER                PIC  X(001)        VALUE ';'.*/
            public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05       FEMI-CODPRODU         PIC  9(004).*/
            public IntBasis FEMI_CODPRODU { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05       FILLER                PIC  X(001)        VALUE ';'.*/
            public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05       FEMI-NUMAPOLANT       PIC  9(013).*/
            public IntBasis FEMI_NUMAPOLANT { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
            /*"  05       FILLER                PIC  X(001)        VALUE ';'.*/
            public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05       FEMI-DTEMIS           PIC  X(010).*/
            public StringBasis FEMI_DTEMIS { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  05       FILLER                PIC  X(001)        VALUE ';'.*/
            public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05       FEMI-DTINIVIG         PIC  X(010).*/
            public StringBasis FEMI_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  05       FILLER                PIC  X(001)        VALUE ';'.*/
            public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05       FEMI-DTTERVIG         PIC  X(010).*/
            public StringBasis FEMI_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  05       FILLER                PIC  X(001)        VALUE ';'.*/
            public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05       FEMI-CODCLIEN         PIC  9(009).*/
            public IntBasis FEMI_CODCLIEN { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"  05       FILLER                PIC  X(001)        VALUE ';'.*/
            public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05       FEMI-NOMSEG           PIC  X(040).*/
            public StringBasis FEMI_NOMSEG { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
            /*"  05       FILLER                PIC  X(001)        VALUE ';'.*/
            public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05       FEMI-TIPOPES          PIC  X(001).*/
            public StringBasis FEMI_TIPOPES { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  05       FILLER                PIC  X(001)        VALUE ';'.*/
            public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05       FEMI-CPFCGC           PIC  9(015).*/
            public IntBasis FEMI_CPFCGC { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
            /*"  05       FILLER                PIC  X(001)        VALUE ';'.*/
            public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05       FEMI-OCORREND         PIC  9(004).*/
            public IntBasis FEMI_OCORREND { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05       FILLER                PIC  X(001)        VALUE ';'.*/
            public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05       FEMI-ENDERECO         PIC  X(040).*/
            public StringBasis FEMI_ENDERECO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
            /*"  05       FILLER                PIC  X(001)        VALUE ';'.*/
            public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05       FEMI-BAIRRO           PIC  X(020).*/
            public StringBasis FEMI_BAIRRO { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
            /*"  05       FILLER                PIC  X(001)        VALUE ';'.*/
            public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05       FEMI-CIDADE           PIC  X(020).*/
            public StringBasis FEMI_CIDADE { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
            /*"  05       FILLER                PIC  X(001)        VALUE ';'.*/
            public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05       FEMI-SIGLA-UF         PIC  X(002).*/
            public StringBasis FEMI_SIGLA_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
            /*"  05       FILLER                PIC  X(001)        VALUE ';'.*/
            public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05       FEMI-CEP              PIC  9(009).*/
            public IntBasis FEMI_CEP { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"  05       FILLER                PIC  X(001)        VALUE ';'.*/
            public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05       FEMI-DDD              PIC  9(004).*/
            public IntBasis FEMI_DDD { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05       FILLER                PIC  X(001)        VALUE ';'.*/
            public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05       FEMI-FONE             PIC  9(009).*/
            public IntBasis FEMI_FONE { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"  05       FILLER                PIC  X(001)        VALUE ';'.*/
            public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05       FEMI-VLPRMTOT         PIC  9(013).99.*/
            public IntBasis FEMI_VLPRMTOT { get; set; } = new IntBasis(new PIC("9", "15", "9(013).99."));
            /*"  05       FILLER                PIC  X(001)        VALUE ';'.*/
            public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05       FEMI-VLPRMLIQ         PIC  9(013).99.*/
            public IntBasis FEMI_VLPRMLIQ { get; set; } = new IntBasis(new PIC("9", "15", "9(013).99."));
            /*"  05       FILLER                PIC  X(001)        VALUE ';'.*/
            public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05       FEMI-QTPARCEL         PIC  9(004).*/
            public IntBasis FEMI_QTPARCEL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05       FILLER                PIC  X(001)        VALUE ';'.*/
            public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05       FEMI-CODAGENC         PIC  9(004).*/
            public IntBasis FEMI_CODAGENC { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05       FILLER                PIC  X(001)        VALUE ';'.*/
            public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05       FEMI-MATRIC-IND       PIC  9(015).*/
            public IntBasis FEMI_MATRIC_IND { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
            /*"  05       FILLER                PIC  X(001)        VALUE ';'.*/
            public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05       FEMI-MATRIC-GER       PIC  9(015).*/
            public IntBasis FEMI_MATRIC_GER { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
            /*"  05       FILLER                PIC  X(001)        VALUE ';'.*/
            public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05       FEMI-MATRIC-SUNEG     PIC  9(015).*/
            public IntBasis FEMI_MATRIC_SUNEG { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
            /*"  05       FILLER                PIC  X(001)        VALUE ';'.*/
            public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05       FEMI-CODMOEDA-IMP     PIC  9(004).*/
            public IntBasis FEMI_CODMOEDA_IMP { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05       FILLER                PIC  X(001)        VALUE ';'.*/
            public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05       FEMI-CODMOEDA-PRM     PIC  9(004).*/
            public IntBasis FEMI_CODMOEDA_PRM { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05       FILLER                PIC  X(001)        VALUE ';'.*/
            public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05       FEMI-TIPOENDO         PIC  X(001).*/
            public StringBasis FEMI_TIPOENDO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  05       FILLER                PIC  X(001)        VALUE ';'.*/
            public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05       FEMI-SITUACAO         PIC  X(001).*/
            public StringBasis FEMI_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  05       FILLER                PIC  X(001)        VALUE ';'.*/
            public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05       FEMI-LAYOUT           PIC  9(004).*/
            public IntBasis FEMI_LAYOUT { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05       FILLER                PIC  X(001)        VALUE ';'.*/
            public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05       FEMI-PROPOSTA-SIVPF   PIC  9(015).*/
            public IntBasis FEMI_PROPOSTA_SIVPF { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
            /*"  05       FILLER                PIC  X(001)        VALUE ';'.*/
            public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05       FEMI-TOMADOR          PIC  X(040).*/
            public StringBasis FEMI_TOMADOR { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
            /*"01         WREG-FENPANA.*/
        }
        public FN0301B_WREG_FENPANA WREG_FENPANA { get; set; } = new FN0301B_WREG_FENPANA();
        public class FN0301B_WREG_FENPANA : VarBasis
        {
            /*"  05       PAEM-NUMAPOL          PIC  9(013).*/
            public IntBasis PAEM_NUMAPOL { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
            /*"  05       FILLER                PIC  X(001)        VALUE ';'.*/
            public StringBasis FILLER_40 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05       PAEM-NRENDOS          PIC  9(009).*/
            public IntBasis PAEM_NRENDOS { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"  05       FILLER                PIC  X(001)        VALUE ';'.*/
            public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05       PAEM-CODSUBES         PIC  9(004).*/
            public IntBasis PAEM_CODSUBES { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05       FILLER                PIC  X(001)        VALUE ';'.*/
            public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05       PAEM-FONTE            PIC  9(004).*/
            public IntBasis PAEM_FONTE { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05       FILLER                PIC  X(001)        VALUE ';'.*/
            public StringBasis FILLER_43 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05       PAEM-NRPROPOS         PIC  9(009).*/
            public IntBasis PAEM_NRPROPOS { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"  05       FILLER                PIC  X(001)        VALUE ';'.*/
            public StringBasis FILLER_44 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05       PAEM-NUMBIL           PIC  9(015).*/
            public IntBasis PAEM_NUMBIL { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
            /*"  05       FILLER                PIC  X(001)        VALUE ';'.*/
            public StringBasis FILLER_45 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05       PAEM-NUMSICOB         PIC  9(009).*/
            public IntBasis PAEM_NUMSICOB { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"  05       FILLER                PIC  X(001)        VALUE ';'.*/
            public StringBasis FILLER_46 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05       PAEM-CODRAMO          PIC  9(004).*/
            public IntBasis PAEM_CODRAMO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05       FILLER                PIC  X(001)        VALUE ';'.*/
            public StringBasis FILLER_47 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05       PAEM-CODPRODU         PIC  9(004).*/
            public IntBasis PAEM_CODPRODU { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05       FILLER                PIC  X(001)        VALUE ';'.*/
            public StringBasis FILLER_48 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05       PAEM-NUMAPOLANT       PIC  9(013).*/
            public IntBasis PAEM_NUMAPOLANT { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
            /*"  05       FILLER                PIC  X(001)        VALUE ';'.*/
            public StringBasis FILLER_49 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05       PAEM-DTEMIS           PIC  X(010).*/
            public StringBasis PAEM_DTEMIS { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  05       FILLER                PIC  X(001)        VALUE ';'.*/
            public StringBasis FILLER_50 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05       PAEM-DTINIVIG         PIC  X(010).*/
            public StringBasis PAEM_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  05       FILLER                PIC  X(001)        VALUE ';'.*/
            public StringBasis FILLER_51 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05       PAEM-DTTERVIG         PIC  X(010).*/
            public StringBasis PAEM_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  05       FILLER                PIC  X(001)        VALUE ';'.*/
            public StringBasis FILLER_52 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05       PAEM-CODCLIEN         PIC  9(009).*/
            public IntBasis PAEM_CODCLIEN { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"  05       FILLER                PIC  X(001)        VALUE ';'.*/
            public StringBasis FILLER_53 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05       PAEM-NOMSEG           PIC  X(040).*/
            public StringBasis PAEM_NOMSEG { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
            /*"  05       FILLER                PIC  X(001)        VALUE ';'.*/
            public StringBasis FILLER_54 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05       PAEM-TIPOPES          PIC  X(001).*/
            public StringBasis PAEM_TIPOPES { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  05       FILLER                PIC  X(001)        VALUE ';'.*/
            public StringBasis FILLER_55 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05       PAEM-CPFCGC           PIC  9(015).*/
            public IntBasis PAEM_CPFCGC { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
            /*"  05       FILLER                PIC  X(001)        VALUE ';'.*/
            public StringBasis FILLER_56 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05       PAEM-OCORREND         PIC  9(004).*/
            public IntBasis PAEM_OCORREND { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05       FILLER                PIC  X(001)        VALUE ';'.*/
            public StringBasis FILLER_57 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05       PAEM-ENDERECO         PIC  X(040).*/
            public StringBasis PAEM_ENDERECO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
            /*"  05       FILLER                PIC  X(001)        VALUE ';'.*/
            public StringBasis FILLER_58 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05       PAEM-BAIRRO           PIC  X(020).*/
            public StringBasis PAEM_BAIRRO { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
            /*"  05       FILLER                PIC  X(001)        VALUE ';'.*/
            public StringBasis FILLER_59 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05       PAEM-CIDADE           PIC  X(020).*/
            public StringBasis PAEM_CIDADE { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
            /*"  05       FILLER                PIC  X(001)        VALUE ';'.*/
            public StringBasis FILLER_60 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05       PAEM-SIGLA-UF         PIC  X(002).*/
            public StringBasis PAEM_SIGLA_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
            /*"  05       FILLER                PIC  X(001)        VALUE ';'.*/
            public StringBasis FILLER_61 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05       PAEM-CEP              PIC  9(009).*/
            public IntBasis PAEM_CEP { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"  05       FILLER                PIC  X(001)        VALUE ';'.*/
            public StringBasis FILLER_62 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05       PAEM-DDD              PIC  9(004).*/
            public IntBasis PAEM_DDD { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05       FILLER                PIC  X(001)        VALUE ';'.*/
            public StringBasis FILLER_63 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05       PAEM-FONE             PIC  9(009).*/
            public IntBasis PAEM_FONE { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"  05       FILLER                PIC  X(001)        VALUE ';'.*/
            public StringBasis FILLER_64 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05       PAEM-VLPRMTOT         PIC  9(013).99.*/
            public IntBasis PAEM_VLPRMTOT { get; set; } = new IntBasis(new PIC("9", "15", "9(013).99."));
            /*"  05       FILLER                PIC  X(001)        VALUE ';'.*/
            public StringBasis FILLER_65 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05       PAEM-VLPRMLIQ         PIC  9(013).99.*/
            public IntBasis PAEM_VLPRMLIQ { get; set; } = new IntBasis(new PIC("9", "15", "9(013).99."));
            /*"  05       FILLER                PIC  X(001)        VALUE ';'.*/
            public StringBasis FILLER_66 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05       PAEM-QTPARCEL         PIC  9(004).*/
            public IntBasis PAEM_QTPARCEL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05       FILLER                PIC  X(001)        VALUE ';'.*/
            public StringBasis FILLER_67 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05       PAEM-CODAGENC         PIC  9(004).*/
            public IntBasis PAEM_CODAGENC { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05       FILLER                PIC  X(001)        VALUE ';'.*/
            public StringBasis FILLER_68 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05       PAEM-MATRIC-IND       PIC  9(015).*/
            public IntBasis PAEM_MATRIC_IND { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
            /*"  05       FILLER                PIC  X(001)        VALUE ';'.*/
            public StringBasis FILLER_69 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05       PAEM-MATRIC-GER       PIC  9(015).*/
            public IntBasis PAEM_MATRIC_GER { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
            /*"  05       FILLER                PIC  X(001)        VALUE ';'.*/
            public StringBasis FILLER_70 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05       PAEM-MATRIC-SUNEG     PIC  9(015).*/
            public IntBasis PAEM_MATRIC_SUNEG { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
            /*"  05       FILLER                PIC  X(001)        VALUE ';'.*/
            public StringBasis FILLER_71 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05       PAEM-CODMOEDA-IMP     PIC  9(004).*/
            public IntBasis PAEM_CODMOEDA_IMP { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05       FILLER                PIC  X(001)        VALUE ';'.*/
            public StringBasis FILLER_72 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05       PAEM-CODMOEDA-PRM     PIC  9(004).*/
            public IntBasis PAEM_CODMOEDA_PRM { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05       FILLER                PIC  X(001)        VALUE ';'.*/
            public StringBasis FILLER_73 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05       PAEM-TIPOENDO         PIC  X(001).*/
            public StringBasis PAEM_TIPOENDO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  05       FILLER                PIC  X(001)        VALUE ';'.*/
            public StringBasis FILLER_74 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05       PAEM-SITUACAO         PIC  X(001).*/
            public StringBasis PAEM_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  05       FILLER                PIC  X(001)        VALUE ';'.*/
            public StringBasis FILLER_75 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05       PAEM-LAYOUT           PIC  9(004).*/
            public IntBasis PAEM_LAYOUT { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05       FILLER                PIC  X(001)        VALUE ';'.*/
            public StringBasis FILLER_76 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05       PAEM-PROPOSTA-SIVPF   PIC  9(015).*/
            public IntBasis PAEM_PROPOSTA_SIVPF { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
            /*"  05       FILLER                PIC  X(001)        VALUE ';'.*/
            public StringBasis FILLER_77 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05       PAEM-TOMADOR          PIC  X(040).*/
            public StringBasis PAEM_TOMADOR { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
            /*"01         WREG-FENAUTO.*/
        }
        public FN0301B_WREG_FENAUTO WREG_FENAUTO { get; set; } = new FN0301B_WREG_FENAUTO();
        public class FN0301B_WREG_FENAUTO : VarBasis
        {
            /*"  05       FAUT-NUMAPOL          PIC  9(013).*/
            public IntBasis FAUT_NUMAPOL { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
            /*"  05       FILLER                PIC  X(001)        VALUE ';'.*/
            public StringBasis FILLER_78 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05       FAUT-NRENDOS          PIC  9(009).*/
            public IntBasis FAUT_NRENDOS { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"  05       FILLER                PIC  X(001)        VALUE ';'.*/
            public StringBasis FILLER_79 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05       FAUT-NRITEM           PIC  9(009).*/
            public IntBasis FAUT_NRITEM { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"  05       FILLER                PIC  X(001)        VALUE ';'.*/
            public StringBasis FILLER_80 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05       FAUT-CDVEICL          PIC  9(009).*/
            public IntBasis FAUT_CDVEICL { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"  05       FILLER                PIC  X(001)        VALUE ';'.*/
            public StringBasis FILLER_81 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05       FAUT-ANOVEICL         PIC  9(004).*/
            public IntBasis FAUT_ANOVEICL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05       FILLER                PIC  X(001)        VALUE ';'.*/
            public StringBasis FILLER_82 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05       FAUT-ANOMOD           PIC  9(004).*/
            public IntBasis FAUT_ANOMOD { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05       FILLER                PIC  X(001)        VALUE ';'.*/
            public StringBasis FILLER_83 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05       FAUT-CHASSIS          PIC  X(020).*/
            public StringBasis FAUT_CHASSIS { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
            /*"  05       FILLER                PIC  X(001)        VALUE ';'.*/
            public StringBasis FILLER_84 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05       FAUT-CORVEICL         PIC  X(020).*/
            public StringBasis FAUT_CORVEICL { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
            /*"  05       FILLER                PIC  X(001)        VALUE ';'.*/
            public StringBasis FILLER_85 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05       FAUT-COMBUST          PIC  X(001).*/
            public StringBasis FAUT_COMBUST { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  05       FILLER                PIC  X(001)        VALUE ';'.*/
            public StringBasis FILLER_86 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05       FAUT-PLACALET         PIC  X(003).*/
            public StringBasis FAUT_PLACALET { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
            /*"  05       FILLER                PIC  X(001)        VALUE ';'.*/
            public StringBasis FILLER_87 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05       FAUT-PLACANR          PIC  X(004).*/
            public StringBasis FAUT_PLACANR { get; set; } = new StringBasis(new PIC("X", "4", "X(004)."), @"");
            /*"  05       FILLER                PIC  X(001)        VALUE ';'.*/
            public StringBasis FILLER_88 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05       FAUT-PLACAUF          PIC  X(002).*/
            public StringBasis FAUT_PLACAUF { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
            /*"01         WREG-FENAUT1.*/
        }
        public FN0301B_WREG_FENAUT1 WREG_FENAUT1 { get; set; } = new FN0301B_WREG_FENAUT1();
        public class FN0301B_WREG_FENAUT1 : VarBasis
        {
            /*"  05       FAU1-NUMAPOL          PIC  9(013).*/
            public IntBasis FAU1_NUMAPOL { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
            /*"  05       FILLER                PIC  X(001)        VALUE ';'.*/
            public StringBasis FILLER_89 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05       FAU1-NRENDOS          PIC  9(009).*/
            public IntBasis FAU1_NRENDOS { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"  05       FILLER                PIC  X(001)        VALUE ';'.*/
            public StringBasis FILLER_90 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05       FAU1-NRITEM           PIC  9(009).*/
            public IntBasis FAU1_NRITEM { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"  05       FILLER                PIC  X(001)        VALUE ';'.*/
            public StringBasis FILLER_91 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05       FAU1-RAMOCOBER        PIC  9(004).*/
            public IntBasis FAU1_RAMOCOBER { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05       FILLER                PIC  X(001)        VALUE ';'.*/
            public StringBasis FILLER_92 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05       FAU1-CODCOBER         PIC  9(004).*/
            public IntBasis FAU1_CODCOBER { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05       FILLER                PIC  X(001)        VALUE ';'.*/
            public StringBasis FILLER_93 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05       FAU1-DTINIVIG         PIC  X(010).*/
            public StringBasis FAU1_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  05       FILLER                PIC  X(001)        VALUE ';'.*/
            public StringBasis FILLER_94 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05       FAU1-DTTERVIG         PIC  X(010).*/
            public StringBasis FAU1_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  05       FILLER                PIC  X(001)        VALUE ';'.*/
            public StringBasis FILLER_95 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05       FAU1-IMP-SEGURADA     PIC  9(010).9(5).*/
            public IntBasis FAU1_IMP_SEGURADA { get; set; } = new IntBasis(new PIC("9", "15", "9(010).9(5)."));
            /*"  05       FILLER                PIC  X(001)        VALUE ';'.*/
            public StringBasis FILLER_96 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05       FAU1-VALFRANQ         PIC  9(010)V9(5).*/
            public DoubleBasis FAU1_VALFRANQ { get; set; } = new DoubleBasis(new PIC("9", "10", "9(010)V9(5)."), 5);
            /*"  05       FILLER                PIC  X(001)        VALUE ';'.*/
            public StringBasis FILLER_97 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05       FAU1-LIMINDENIZ       PIC  9(010).9(5).*/
            public IntBasis FAU1_LIMINDENIZ { get; set; } = new IntBasis(new PIC("9", "15", "9(010).9(5)."));
            /*"  05       FILLER                PIC  X(001)        VALUE ';'.*/
            public StringBasis FILLER_98 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05       FAU1-VLPRMLIQ         PIC  9(010).9(5).*/
            public IntBasis FAU1_VLPRMLIQ { get; set; } = new IntBasis(new PIC("9", "15", "9(010).9(5)."));
            /*"01         WREG-FENVIDA.*/
        }
        public FN0301B_WREG_FENVIDA WREG_FENVIDA { get; set; } = new FN0301B_WREG_FENVIDA();
        public class FN0301B_WREG_FENVIDA : VarBasis
        {
            /*"  05       FVID-NUMAPOL          PIC  9(013).*/
            public IntBasis FVID_NUMAPOL { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
            /*"  05       FILLER                PIC  X(001)        VALUE ';'.*/
            public StringBasis FILLER_99 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05       FVID-NRENDOS          PIC  9(009).*/
            public IntBasis FVID_NRENDOS { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"  05       FILLER                PIC  X(001)        VALUE ';'.*/
            public StringBasis FILLER_100 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05       FVID-CODOPER          PIC  9(004).*/
            public IntBasis FVID_CODOPER { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05       FILLER                PIC  X(001)        VALUE ';'.*/
            public StringBasis FILLER_101 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05       FVID-CODRAMO          PIC  9(004).*/
            public IntBasis FVID_CODRAMO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05       FILLER                PIC  X(001)        VALUE ';'.*/
            public StringBasis FILLER_102 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05       FVID-QTDVIDAS         PIC  9(009).*/
            public IntBasis FVID_QTDVIDAS { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"  05       FILLER                PIC  X(001)        VALUE ';'.*/
            public StringBasis FILLER_103 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05       FVID-VLPRMLIQ         PIC  9(013)V99.*/
            public DoubleBasis FVID_VLPRMLIQ { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
            /*"  05       FILLER                PIC  X(001)        VALUE ';'.*/
            public StringBasis FILLER_104 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05       FVID-NUMFATUR         PIC  9(009).*/
            public IntBasis FVID_NUMFATUR { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"  05       FILLER                PIC  X(001)        VALUE ';'.*/
            public StringBasis FILLER_105 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05       FVID-CODSUBES         PIC  9(004).*/
            public IntBasis FVID_CODSUBES { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05       FILLER                PIC  X(001)        VALUE ';'.*/
            public StringBasis FILLER_106 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05       FVID-FONTE            PIC  9(004).*/
            public IntBasis FVID_FONTE { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05       FILLER                PIC  X(001)        VALUE ';'.*/
            public StringBasis FILLER_107 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05       FVID-PERIPGTO         PIC  X(004).*/
            public StringBasis FVID_PERIPGTO { get; set; } = new StringBasis(new PIC("X", "4", "X(004)."), @"");
            /*"  05       FILLER                PIC  X(001)        VALUE ';'.*/
            public StringBasis FILLER_108 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05       FVID-DESC-PERIPGTO    PIC  X(010).*/
            public StringBasis FVID_DESC_PERIPGTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"01         WREG-FENOUTR.*/
        }
        public FN0301B_WREG_FENOUTR WREG_FENOUTR { get; set; } = new FN0301B_WREG_FENOUTR();
        public class FN0301B_WREG_FENOUTR : VarBasis
        {
            /*"  05       FOUR-NUMAPOL          PIC  9(013).*/
            public IntBasis FOUR_NUMAPOL { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
            /*"  05       FILLER                PIC  X(001)        VALUE ';'.*/
            public StringBasis FILLER_109 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05       FOUR-NRENDOS          PIC  9(009).*/
            public IntBasis FOUR_NRENDOS { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"  05       FILLER                PIC  X(001)        VALUE ';'.*/
            public StringBasis FILLER_110 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05       FOUR-NRITEM           PIC  9(009).*/
            public IntBasis FOUR_NRITEM { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"  05       FILLER                PIC  X(001)        VALUE ';'.*/
            public StringBasis FILLER_111 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05       FOUR-RAMOCOBER        PIC  9(004).*/
            public IntBasis FOUR_RAMOCOBER { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05       FILLER                PIC  X(001)        VALUE ';'.*/
            public StringBasis FILLER_112 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05       FOUR-CODCOBER         PIC  9(004).*/
            public IntBasis FOUR_CODCOBER { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05       FILLER                PIC  X(001)        VALUE ';'.*/
            public StringBasis FILLER_113 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05       FOUR-DTINIVIG         PIC  X(010).*/
            public StringBasis FOUR_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  05       FILLER                PIC  X(001)        VALUE ';'.*/
            public StringBasis FILLER_114 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05       FOUR-DTTERVIG         PIC  X(010).*/
            public StringBasis FOUR_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  05       FILLER                PIC  X(001)        VALUE ';'.*/
            public StringBasis FILLER_115 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05       FOUR-IMP-SEGURADA     PIC  9(010).9(5).*/
            public IntBasis FOUR_IMP_SEGURADA { get; set; } = new IntBasis(new PIC("9", "15", "9(010).9(5)."));
            /*"  05       FILLER                PIC  X(001)        VALUE ';'.*/
            public StringBasis FILLER_116 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05       FOUR-LIMINDENIZ       PIC  9(010).9(5).*/
            public IntBasis FOUR_LIMINDENIZ { get; set; } = new IntBasis(new PIC("9", "15", "9(010).9(5)."));
            /*"  05       FILLER                PIC  X(001)        VALUE ';'.*/
            public StringBasis FILLER_117 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05       FOUR-VALFRANQ         PIC  9(010).9(5).*/
            public IntBasis FOUR_VALFRANQ { get; set; } = new IntBasis(new PIC("9", "15", "9(010).9(5)."));
            /*"  05       FILLER                PIC  X(001)        VALUE ';'.*/
            public StringBasis FILLER_118 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05       FOUR-VLPRMLIQ         PIC  9(010).9(5).*/
            public IntBasis FOUR_VLPRMLIQ { get; set; } = new IntBasis(new PIC("9", "15", "9(010).9(5)."));
            /*"01         WREG-FENPARC.*/
        }
        public FN0301B_WREG_FENPARC WREG_FENPARC { get; set; } = new FN0301B_WREG_FENPARC();
        public class FN0301B_WREG_FENPARC : VarBasis
        {
            /*"  05       FPAR-NUMAPOL          PIC  9(013).*/
            public IntBasis FPAR_NUMAPOL { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
            /*"  05       FILLER                PIC  X(001)        VALUE ';'.*/
            public StringBasis FILLER_119 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05       FPAR-NRENDOS          PIC  9(009).*/
            public IntBasis FPAR_NRENDOS { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"  05       FILLER                PIC  X(001)        VALUE ';'.*/
            public StringBasis FILLER_120 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05       FPAR-NRPARCEL         PIC  9(004).*/
            public IntBasis FPAR_NRPARCEL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05       FILLER                PIC  X(001)        VALUE ';'.*/
            public StringBasis FILLER_121 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05       FPAR-NRTIT            PIC  9(013).*/
            public IntBasis FPAR_NRTIT { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
            /*"  05       FILLER                PIC  X(001)        VALUE ';'.*/
            public StringBasis FILLER_122 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05       FPAR-VLPRMLIQ         PIC  9(010).9(5).*/
            public IntBasis FPAR_VLPRMLIQ { get; set; } = new IntBasis(new PIC("9", "15", "9(010).9(5)."));
            /*"  05       FILLER                PIC  X(001)        VALUE ';'.*/
            public StringBasis FILLER_123 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05       FPAR-DTVENCTO         PIC  X(010).*/
            public StringBasis FPAR_DTVENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  05       FILLER                PIC  X(001)        VALUE ';'.*/
            public StringBasis FILLER_124 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05       FPAR-QTDOCORR         PIC  9(004).*/
            public IntBasis FPAR_QTDOCORR { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05       FILLER                PIC  X(001)        VALUE ';'.*/
            public StringBasis FILLER_125 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05       FPAR-SITUACAO         PIC  X(001).*/
            public StringBasis FPAR_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"01         WREG-FENCOMI.*/
        }
        public FN0301B_WREG_FENCOMI WREG_FENCOMI { get; set; } = new FN0301B_WREG_FENCOMI();
        public class FN0301B_WREG_FENCOMI : VarBasis
        {
            /*"  05       FCOM-NUMAPOL          PIC  9(013).*/
            public IntBasis FCOM_NUMAPOL { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
            /*"  05       FILLER                PIC  X(001)        VALUE ';'.*/
            public StringBasis FILLER_126 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05       FCOM-CODSUBES         PIC  9(004).*/
            public IntBasis FCOM_CODSUBES { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05       FILLER                PIC  X(001)        VALUE ';'.*/
            public StringBasis FILLER_127 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05       FCOM-RAMOFR           PIC  9(004).*/
            public IntBasis FCOM_RAMOFR { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05       FILLER                PIC  X(001)        VALUE ';'.*/
            public StringBasis FILLER_128 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05       FCOM-CODCORR          PIC  9(009).*/
            public IntBasis FCOM_CODCORR { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"  05       FILLER                PIC  X(001)        VALUE ';'.*/
            public StringBasis FILLER_129 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05       FCOM-TIPOCOM          PIC  X(001).*/
            public StringBasis FCOM_TIPOCOM { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  05       FILLER                PIC  X(001)        VALUE ';'.*/
            public StringBasis FILLER_130 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05       FCOM-PCTCOM           PIC  9(003).9(2).*/
            public IntBasis FCOM_PCTCOM { get; set; } = new IntBasis(new PIC("9", "5", "9(003).9(2)."));
            /*"  05       FILLER                PIC  X(001)        VALUE ';'.*/
            public StringBasis FILLER_131 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05       FCOM-PCTPART          PIC  9(003).9(2).*/
            public IntBasis FCOM_PCTPART { get; set; } = new IntBasis(new PIC("9", "5", "9(003).9(2)."));
            /*"01         WREG-FENCOSS.*/
        }
        public FN0301B_WREG_FENCOSS WREG_FENCOSS { get; set; } = new FN0301B_WREG_FENCOSS();
        public class FN0301B_WREG_FENCOSS : VarBasis
        {
            /*"  05       FCOS-NUMAPOL          PIC  9(013).*/
            public IntBasis FCOS_NUMAPOL { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
            /*"  05       FILLER                PIC  X(001)        VALUE ';'.*/
            public StringBasis FILLER_132 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05       FCOS-CODCONG          PIC  9(004).*/
            public IntBasis FCOS_CODCONG { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05       FILLER                PIC  X(001)        VALUE ';'.*/
            public StringBasis FILLER_133 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05       FCOS-PCTCOSS          PIC  9(004).9(5).*/
            public IntBasis FCOS_PCTCOSS { get; set; } = new IntBasis(new PIC("9", "9", "9(004).9(5)."));
            /*"  05       FILLER                PIC  X(001)        VALUE ';'.*/
            public StringBasis FILLER_134 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05       FCOS-PCTCOM           PIC  9(003).9(2).*/
            public IntBasis FCOS_PCTCOM { get; set; } = new IntBasis(new PIC("9", "5", "9(003).9(2)."));
            /*"01         WREG-FENRESS.*/
        }
        public FN0301B_WREG_FENRESS WREG_FENRESS { get; set; } = new FN0301B_WREG_FENRESS();
        public class FN0301B_WREG_FENRESS : VarBasis
        {
            /*"  05       FRES-NUMAPOL          PIC  9(013).*/
            public IntBasis FRES_NUMAPOL { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
            /*"  05       FILLER                PIC  X(001)        VALUE ';'.*/
            public StringBasis FILLER_135 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05       FRES-NRENDOS          PIC  9(009).*/
            public IntBasis FRES_NRENDOS { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"  05       FILLER                PIC  X(001)        VALUE ';'.*/
            public StringBasis FILLER_136 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05       FRES-NRITEM           PIC  9(009).*/
            public IntBasis FRES_NRITEM { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"  05       FILLER                PIC  X(001)        VALUE ';'.*/
            public StringBasis FILLER_137 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05       FRES-OCORHIST         PIC  9(004).*/
            public IntBasis FRES_OCORHIST { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05       FILLER                PIC  X(001)        VALUE ';'.*/
            public StringBasis FILLER_138 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05       FRES-CODRESS          PIC  9(004).*/
            public IntBasis FRES_CODRESS { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05       FILLER                PIC  X(001)        VALUE ';'.*/
            public StringBasis FILLER_139 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05       FRES-CODRAMO          PIC  9(004).*/
            public IntBasis FRES_CODRAMO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05       FILLER                PIC  X(001)        VALUE ';'.*/
            public StringBasis FILLER_140 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05       FRES-CODCOBER         PIC  9(004).*/
            public IntBasis FRES_CODCOBER { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05       FILLER                PIC  X(001)        VALUE ';'.*/
            public StringBasis FILLER_141 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05       FRES-TIPORESS         PIC  X(001).*/
            public StringBasis FRES_TIPORESS { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  05       FILLER                PIC  X(001)        VALUE ';'.*/
            public StringBasis FILLER_142 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05       FRES-PCTRESS          PIC  9(003).9(4).*/
            public IntBasis FRES_PCTRESS { get; set; } = new IntBasis(new PIC("9", "7", "9(003).9(4)."));
            /*"  05       FILLER                PIC  X(001)        VALUE ';'.*/
            public StringBasis FILLER_143 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05       FRES-PCTCOM           PIC  9(003).9(2).*/
            public IntBasis FRES_PCTCOM { get; set; } = new IntBasis(new PIC("9", "5", "9(003).9(2)."));
            /*"01           TABELA-ALFA.*/
        }
        public FN0301B_TABELA_ALFA TABELA_ALFA { get; set; } = new FN0301B_TABELA_ALFA();
        public class FN0301B_TABELA_ALFA : VarBasis
        {
            /*"  05   TAB-ALFA-GRUPO  PIC  X(040)     VALUE SPACES.*/
            public StringBasis TAB_ALFA_GRUPO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
            /*"  05   TAB-ALFA-BYTE   OCCURS 40  INDEXED BY INDX  PIC  X(001).*/
            public ListBasis<StringBasis, string> TAB_ALFA_BYTE { get; set; } = new ListBasis<StringBasis, string>(new PIC("9", "1", "X(001)."), 40);
            /*"01           AREA-DE-WORK.*/
        }
        public FN0301B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new FN0301B_AREA_DE_WORK();
        public class FN0301B_AREA_DE_WORK : VarBasis
        {
            /*"  05         WSL-SQLCODE       PIC  9(009)     VALUE ZEROS.*/
            public IntBasis WSL_SQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05         WZEROS            PIC S9(003)     VALUE +0 COMP-3.*/
            public IntBasis WZEROS { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"));
            /*"  05         CH-DESPREZA       PIC  X(001)      VALUE  '0'.*/
            public StringBasis CH_DESPREZA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"0");
            /*"  05         WNRITEM           PIC  9(004).*/
            public IntBasis WNRITEM { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05         FILLLER           REDEFINES        WNRITEM.*/
            private _REDEF_FN0301B_FILLLER _filller { get; set; }
            public _REDEF_FN0301B_FILLLER FILLLER
            {
                get { _filller = new _REDEF_FN0301B_FILLLER(); _.Move(WNRITEM, _filller); VarBasis.RedefinePassValue(WNRITEM, _filller, WNRITEM); _filller.ValueChanged += () => { _.Move(_filller, WNRITEM); }; return _filller; }
                set { VarBasis.RedefinePassValue(value, _filller, WNRITEM); }
            }  //Redefines
            public class _REDEF_FN0301B_FILLLER : VarBasis
            {
                /*"    10       FILLER            PIC  9(002).*/
                public IntBasis FILLER_144 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       WSUBITEM          PIC  9(002).*/
                public IntBasis WSUBITEM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05         CH-VERIFICA       PIC  X(001)      VALUE  SPACES.*/

                public _REDEF_FN0301B_FILLLER()
                {
                    FILLER_144.ValueChanged += OnValueChanged;
                    WSUBITEM.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis CH_VERIFICA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-V1SISTEMA    PIC  X(001)      VALUE  SPACES.*/
            public StringBasis WFIM_V1SISTEMA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-V1HISTOPARC  PIC  X(001)      VALUE  SPACES.*/
            public StringBasis WFIM_V1HISTOPARC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-V1APOLCORRET PIC  X(001)      VALUE  SPACES.*/
            public StringBasis WFIM_V1APOLCORRET { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-V1AUTOAPOL   PIC  X(001)      VALUE  SPACES.*/
            public StringBasis WFIM_V1AUTOAPOL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-V1AUTOCOBER  PIC  X(001)      VALUE  SPACES.*/
            public StringBasis WFIM_V1AUTOCOBER { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-V1COBERAPOL  PIC  X(001)      VALUE  SPACES.*/
            public StringBasis WFIM_V1COBERAPOL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-V1FATURAS    PIC  X(001)      VALUE  SPACES.*/
            public StringBasis WFIM_V1FATURAS { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-V1SEGURAVG   PIC  X(001)      VALUE  SPACES.*/
            public StringBasis WFIM_V1SEGURAVG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-V1COBERVG    PIC  X(001)      VALUE  SPACES.*/
            public StringBasis WFIM_V1COBERVG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-V1BENEFIC    PIC  X(001)      VALUE  SPACES.*/
            public StringBasis WFIM_V1BENEFIC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-V1OUTRCOBER  PIC  X(001)      VALUE  SPACES.*/
            public StringBasis WFIM_V1OUTRCOBER { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-MRAPCOBER   PIC  X(001)      VALUE  SPACES.*/
            public StringBasis WFIM_MRAPCOBER { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         AC-L-V1HISTOPARC  PIC S9(009)      VALUE  +0 COMP-3*/
            public IntBasis AC_L_V1HISTOPARC { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  05         AC-L-V1ENDOSSO    PIC S9(009)      VALUE  +0 COMP-3*/
            public IntBasis AC_L_V1ENDOSSO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  05         AC-G-FENEMIS      PIC S9(009)      VALUE  +0 COMP-3*/
            public IntBasis AC_G_FENEMIS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  05         AC-G-FENPANA      PIC S9(009)      VALUE  +0 COMP-3*/
            public IntBasis AC_G_FENPANA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  05         AC-G-FENPARC      PIC S9(009)      VALUE  +0 COMP-3*/
            public IntBasis AC_G_FENPARC { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  05         AC-G-FENCOMI      PIC S9(009)      VALUE  +0 COMP-3*/
            public IntBasis AC_G_FENCOMI { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  05         AC-G-FENCOSS      PIC S9(009)      VALUE  +0 COMP-3*/
            public IntBasis AC_G_FENCOSS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  05         AC-G-FENRESS      PIC S9(009)      VALUE  +0 COMP-3*/
            public IntBasis AC_G_FENRESS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  05         AC-G-FENAUTO      PIC S9(009)      VALUE  +0 COMP-3*/
            public IntBasis AC_G_FENAUTO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  05         AC-G-FENAUT1      PIC S9(009)      VALUE  +0 COMP-3*/
            public IntBasis AC_G_FENAUT1 { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  05         AC-G-FENVIDA      PIC S9(009)      VALUE  +0 COMP-3*/
            public IntBasis AC_G_FENVIDA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  05         AC-G-FENOUTR      PIC S9(009)      VALUE  +0 COMP-3*/
            public IntBasis AC_G_FENOUTR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  05        WABEND.*/
            public FN0301B_WABEND WABEND { get; set; } = new FN0301B_WABEND();
            public class FN0301B_WABEND : VarBasis
            {
                /*"    10      FILLER              PIC  X(010) VALUE           ' FN0301B'.*/
                public StringBasis FILLER_145 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" FN0301B");
                /*"    10      FILLER              PIC  X(026) VALUE           ' *** ERRO EXEC SQL NUMERO '.*/
                public StringBasis FILLER_146 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @" *** ERRO EXEC SQL NUMERO ");
                /*"    10      WNR-EXEC-SQL        PIC  X(004) VALUE '0000'.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"0000");
                /*"    10      FILLER              PIC  X(013) VALUE           ' *** SQLCODE '.*/
                public StringBasis FILLER_147 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
                /*"    10      WSQLCODE            PIC  ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
            }
        }


        public Dclgens.PROPOFID PROPOFID { get; set; } = new Dclgens.PROPOFID();
        public Dclgens.TOMADOR TOMADOR { get; set; } = new Dclgens.TOMADOR();
        public Dclgens.CLIENTES CLIENTES { get; set; } = new Dclgens.CLIENTES();
        public Dclgens.PLAVAVGA PLAVAVGA { get; set; } = new Dclgens.PLAVAVGA();
        public Dclgens.APOLICES APOLICES { get; set; } = new Dclgens.APOLICES();
        public Dclgens.PRODUVG PRODUVG { get; set; } = new Dclgens.PRODUVG();
        public Dclgens.APOLIAUT APOLIAUT { get; set; } = new Dclgens.APOLIAUT();
        public FN0301B_MOVTO MOVTO { get; set; } = new FN0301B_MOVTO();
        public FN0301B_V1APOLCORRET V1APOLCORRET { get; set; } = new FN0301B_V1APOLCORRET();
        public FN0301B_V1APOLCOSCED V1APOLCOSCED { get; set; } = new FN0301B_V1APOLCOSCED();
        public FN0301B_V1HISTORES V1HISTORES { get; set; } = new FN0301B_V1HISTORES();
        public FN0301B_V1AUTOAPOL V1AUTOAPOL { get; set; } = new FN0301B_V1AUTOAPOL();
        public FN0301B_V1AUTOCOBER V1AUTOCOBER { get; set; } = new FN0301B_V1AUTOCOBER();
        public FN0301B_V1FATURA V1FATURA { get; set; } = new FN0301B_V1FATURA();
        public FN0301B_V1COBERAPOL V1COBERAPOL { get; set; } = new FN0301B_V1COBERAPOL();
        public FN0301B_V1OUTRCOBER V1OUTRCOBER { get; set; } = new FN0301B_V1OUTRCOBER();
        public FN0301B_MRAPCOBER MRAPCOBER { get; set; } = new FN0301B_MRAPCOBER();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string FENPANA_FILE_NAME_P, string FENEMIS_FILE_NAME_P, string FENAUTO_FILE_NAME_P, string FENAUT1_FILE_NAME_P, string FENVIDA_FILE_NAME_P, string FENOUTR_FILE_NAME_P, string FENPARC_FILE_NAME_P, string FENCOMI_FILE_NAME_P, string FENCOSS_FILE_NAME_P, string FENRESS_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                FENPANA.SetFile(FENPANA_FILE_NAME_P);
                FENEMIS.SetFile(FENEMIS_FILE_NAME_P);
                FENAUTO.SetFile(FENAUTO_FILE_NAME_P);
                FENAUT1.SetFile(FENAUT1_FILE_NAME_P);
                FENVIDA.SetFile(FENVIDA_FILE_NAME_P);
                FENOUTR.SetFile(FENOUTR_FILE_NAME_P);
                FENPARC.SetFile(FENPARC_FILE_NAME_P);
                FENCOMI.SetFile(FENCOMI_FILE_NAME_P);
                FENCOSS.SetFile(FENCOSS_FILE_NAME_P);
                FENRESS.SetFile(FENRESS_FILE_NAME_P);

                /*" -1094- MOVE '0000' TO WNR-EXEC-SQL. */
                _.Move("0000", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -1095- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

                /*" -1098- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

                /*" -1101- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

                /*" -1101- FLUXCONTROL_PERFORM R0000-00-PRINCIPAL-SECTION */

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
            /*" -1120- OPEN OUTPUT FENEMIS FENPANA FENAUTO FENAUT1 FENVIDA FENOUTR FENPARC FENCOMI FENCOSS FENRESS */
            FENEMIS.Open(REG_FENEMIS);
            FENPANA.Open(REG_FENPANA);
            FENAUTO.Open(REG_FENAUTO);
            FENAUT1.Open(REG_FENAUT1);
            FENVIDA.Open(REG_FENVIDA);
            FENOUTR.Open(REG_FENOUTR);
            FENPARC.Open(REG_FENPARC);
            FENCOMI.Open(REG_FENCOMI);
            FENCOSS.Open(REG_FENCOSS);
            FENRESS.Open(REG_FENRESS);

            /*" -1121- PERFORM R0100-00-SELECT-V1SISTEMA */

            R0100_00_SELECT_V1SISTEMA_SECTION();

            /*" -1122- IF WFIM-V1SISTEMA NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WFIM_V1SISTEMA.IsEmpty())
            {

                /*" -1124- GO TO R0000-90-FINALIZA. */

                R0000_90_FINALIZA(); //GOTO
                return;
            }


            /*" -1126- PERFORM R0200-00-GRAVA-HEADERS. */

            R0200_00_GRAVA_HEADERS_SECTION();

            /*" -1127- PERFORM R0300-00-DECLARE-V1HISTOPARC */

            R0300_00_DECLARE_V1HISTOPARC_SECTION();

            /*" -1128- PERFORM R0900-00-FETCH-V1HISTOPARC */

            R0900_00_FETCH_V1HISTOPARC_SECTION();

            /*" -1129- IF WFIM-V1HISTOPARC NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WFIM_V1HISTOPARC.IsEmpty())
            {

                /*" -1130- PERFORM R9000-00-ENCERRA-SEM-MOVTO */

                R9000_00_ENCERRA_SEM_MOVTO_SECTION();

                /*" -1132- GO TO R0000-90-FINALIZA. */

                R0000_90_FINALIZA(); //GOTO
                return;
            }


            /*" -1133- PERFORM R1000-00-PROCESSAMENTO UNTIL WFIM-V1HISTOPARC NOT EQUAL SPACES. */

            while (!(!AREA_DE_WORK.WFIM_V1HISTOPARC.IsEmpty()))
            {

                R1000_00_PROCESSAMENTO_SECTION();
            }

            /*" -0- FLUXCONTROL_PERFORM R0000_90_FINALIZA */

            R0000_90_FINALIZA();

        }

        [StopWatch]
        /*" R0000-90-FINALIZA */
        private void R0000_90_FINALIZA(bool isPerform = false)
        {
            /*" -1138- DISPLAY '---------------------------------------------' */
            _.Display($"---------------------------------------------");

            /*" -1139- DISPLAY '                 F N 0 3 0 1 B               ' */
            _.Display($"                 F N 0 3 0 1 B               ");

            /*" -1140- DISPLAY 'DATA DO MOVIMENTO       = ' V1SIST-DTMOVABE */
            _.Display($"DATA DO MOVIMENTO       = {V1SIST_DTMOVABE}");

            /*" -1141- DISPLAY '---------------------------------------------' */
            _.Display($"---------------------------------------------");

            /*" -1142- DISPLAY 'LIDOS V1HISTOPARC       = ' AC-L-V1HISTOPARC */
            _.Display($"LIDOS V1HISTOPARC       = {AREA_DE_WORK.AC_L_V1HISTOPARC}");

            /*" -1143- DISPLAY 'LIDOS V1ENDOSSO         = ' AC-L-V1ENDOSSO */
            _.Display($"LIDOS V1ENDOSSO         = {AREA_DE_WORK.AC_L_V1ENDOSSO}");

            /*" -1144- DISPLAY 'GRAVADOS FENEMIS        = ' AC-G-FENEMIS */
            _.Display($"GRAVADOS FENEMIS        = {AREA_DE_WORK.AC_G_FENEMIS}");

            /*" -1145- DISPLAY 'GRAVADOS FENPANA        = ' AC-G-FENPANA */
            _.Display($"GRAVADOS FENPANA        = {AREA_DE_WORK.AC_G_FENPANA}");

            /*" -1146- DISPLAY 'GRAVADOS FENAUTO        = ' AC-G-FENAUTO */
            _.Display($"GRAVADOS FENAUTO        = {AREA_DE_WORK.AC_G_FENAUTO}");

            /*" -1147- DISPLAY 'GRAVADOS FENAUT1        = ' AC-G-FENAUT1 */
            _.Display($"GRAVADOS FENAUT1        = {AREA_DE_WORK.AC_G_FENAUT1}");

            /*" -1148- DISPLAY 'GRAVADOS FENVIDA        = ' AC-G-FENVIDA */
            _.Display($"GRAVADOS FENVIDA        = {AREA_DE_WORK.AC_G_FENVIDA}");

            /*" -1149- DISPLAY 'GRAVADOS FENOUTR        = ' AC-G-FENOUTR */
            _.Display($"GRAVADOS FENOUTR        = {AREA_DE_WORK.AC_G_FENOUTR}");

            /*" -1150- DISPLAY 'GRAVADOS FENPARC        = ' AC-G-FENPARC */
            _.Display($"GRAVADOS FENPARC        = {AREA_DE_WORK.AC_G_FENPARC}");

            /*" -1151- DISPLAY 'GRAVADOS FENCOMI        = ' AC-G-FENCOMI */
            _.Display($"GRAVADOS FENCOMI        = {AREA_DE_WORK.AC_G_FENCOMI}");

            /*" -1152- DISPLAY 'GRAVADOS FENCOSS        = ' AC-G-FENCOSS */
            _.Display($"GRAVADOS FENCOSS        = {AREA_DE_WORK.AC_G_FENCOSS}");

            /*" -1154- DISPLAY 'GRAVADOS FENRESS        = ' AC-G-FENRESS. */
            _.Display($"GRAVADOS FENRESS        = {AREA_DE_WORK.AC_G_FENRESS}");

            /*" -1156- PERFORM R0400-00-GRAVA-TRAILLERS. */

            R0400_00_GRAVA_TRAILLERS_SECTION();

            /*" -1167- CLOSE FENEMIS FENPANA FENAUTO FENAUT1 FENVIDA FENOUTR FENPARC FENCOMI FENCOSS FENRESS */
            FENEMIS.Close();
            FENPANA.Close();
            FENAUTO.Close();
            FENAUT1.Close();
            FENVIDA.Close();
            FENOUTR.Close();
            FENPARC.Close();
            FENCOMI.Close();
            FENCOSS.Close();
            FENRESS.Close();

            /*" -1167- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -1171- MOVE ZEROS TO RETURN-CODE */
            _.Move(0, RETURN_CODE);

            /*" -1173- DISPLAY 'FN0301B - FIM NORMAL' */
            _.Display($"FN0301B - FIM NORMAL");

            /*" -1173- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0100-00-SELECT-V1SISTEMA-SECTION */
        private void R0100_00_SELECT_V1SISTEMA_SECTION()
        {
            /*" -1186- MOVE '0100' TO WNR-EXEC-SQL. */
            _.Move("0100", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1192- PERFORM R0100_00_SELECT_V1SISTEMA_DB_SELECT_1 */

            R0100_00_SELECT_V1SISTEMA_DB_SELECT_1();

            /*" -1195- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1196- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1197- DISPLAY 'R0100-00 (SISTEMA DE EMISSAO NAO CADASTRADO)' */
                    _.Display($"R0100-00 (SISTEMA DE EMISSAO NAO CADASTRADO)");

                    /*" -1198- MOVE 'S' TO WFIM-V1SISTEMA */
                    _.Move("S", AREA_DE_WORK.WFIM_V1SISTEMA);

                    /*" -1199- GO TO R0100-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/ //GOTO
                    return;

                    /*" -1200- ELSE */
                }
                else
                {


                    /*" -1201- DISPLAY 'R0100-00 (ERRO ACESSO V1SISTEMA)' */
                    _.Display($"R0100-00 (ERRO ACESSO V1SISTEMA)");

                    /*" -1205- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -1205- DISPLAY 'DATA DO MOVIMENTO ' V1SIST-DTMOVABE. */
            _.Display($"DATA DO MOVIMENTO {V1SIST_DTMOVABE}");

        }

        [StopWatch]
        /*" R0100-00-SELECT-V1SISTEMA-DB-SELECT-1 */
        public void R0100_00_SELECT_V1SISTEMA_DB_SELECT_1()
        {
            /*" -1192- EXEC SQL SELECT DTMOVABE, CURRENT TIMESTAMP INTO :V1SIST-DTMOVABE, :V1SIST-TIMESTAMP FROM SEGUROS.V1SISTEMA WHERE IDSISTEM = 'FN' WITH UR END-EXEC. */

            var r0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1 = new R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1.Execute(r0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1SIST_DTMOVABE, V1SIST_DTMOVABE);
                _.Move(executed_1.V1SIST_TIMESTAMP, V1SIST_TIMESTAMP);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/

        [StopWatch]
        /*" R0200-00-GRAVA-HEADERS-SECTION */
        private void R0200_00_GRAVA_HEADERS_SECTION()
        {
            /*" -1215- MOVE V1SIST-DTMOVABE TO FHDR-DTMOVABE */
            _.Move(V1SIST_DTMOVABE, WREG_HEADER.FHDR_DTMOVABE);

            /*" -1217- WRITE REG-FENEMIS FROM WREG-HEADER */
            _.Move(WREG_HEADER.GetMoveValues(), REG_FENEMIS);

            FENEMIS.Write(REG_FENEMIS.GetMoveValues().ToString());

            /*" -1219- WRITE REG-FENPANA FROM WREG-HEADER */
            _.Move(WREG_HEADER.GetMoveValues(), REG_FENPANA);

            FENPANA.Write(REG_FENPANA.GetMoveValues().ToString());

            /*" -1221- WRITE REG-FENPARC FROM WREG-HEADER */
            _.Move(WREG_HEADER.GetMoveValues(), REG_FENPARC);

            FENPARC.Write(REG_FENPARC.GetMoveValues().ToString());

            /*" -1223- WRITE REG-FENCOMI FROM WREG-HEADER */
            _.Move(WREG_HEADER.GetMoveValues(), REG_FENCOMI);

            FENCOMI.Write(REG_FENCOMI.GetMoveValues().ToString());

            /*" -1225- WRITE REG-FENCOSS FROM WREG-HEADER */
            _.Move(WREG_HEADER.GetMoveValues(), REG_FENCOSS);

            FENCOSS.Write(REG_FENCOSS.GetMoveValues().ToString());

            /*" -1227- WRITE REG-FENRESS FROM WREG-HEADER */
            _.Move(WREG_HEADER.GetMoveValues(), REG_FENRESS);

            FENRESS.Write(REG_FENRESS.GetMoveValues().ToString());

            /*" -1229- WRITE REG-FENAUTO FROM WREG-HEADER */
            _.Move(WREG_HEADER.GetMoveValues(), REG_FENAUTO);

            FENAUTO.Write(REG_FENAUTO.GetMoveValues().ToString());

            /*" -1231- WRITE REG-FENAUT1 FROM WREG-HEADER */
            _.Move(WREG_HEADER.GetMoveValues(), REG_FENAUT1);

            FENAUT1.Write(REG_FENAUT1.GetMoveValues().ToString());

            /*" -1233- WRITE REG-FENVIDA FROM WREG-HEADER */
            _.Move(WREG_HEADER.GetMoveValues(), REG_FENVIDA);

            FENVIDA.Write(REG_FENVIDA.GetMoveValues().ToString());

            /*" -1233- WRITE REG-FENOUTR FROM WREG-HEADER. */
            _.Move(WREG_HEADER.GetMoveValues(), REG_FENOUTR);

            FENOUTR.Write(REG_FENOUTR.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_99_SAIDA*/

        [StopWatch]
        /*" R0300-00-DECLARE-V1HISTOPARC-SECTION */
        private void R0300_00_DECLARE_V1HISTOPARC_SECTION()
        {
            /*" -1246- MOVE '0300' TO WNR-EXEC-SQL. */
            _.Move("0300", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1275- PERFORM R0300_00_DECLARE_V1HISTOPARC_DB_DECLARE_1 */

            R0300_00_DECLARE_V1HISTOPARC_DB_DECLARE_1();

            /*" -1277- PERFORM R0300_00_DECLARE_V1HISTOPARC_DB_OPEN_1 */

            R0300_00_DECLARE_V1HISTOPARC_DB_OPEN_1();

            /*" -1280- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1281- DISPLAY 'R0300-00 (ERRO NO DECLARE MOVTO)' */
                _.Display($"R0300-00 (ERRO NO DECLARE MOVTO)");

                /*" -1281- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0300-00-DECLARE-V1HISTOPARC-DB-DECLARE-1 */
        public void R0300_00_DECLARE_V1HISTOPARC_DB_DECLARE_1()
        {
            /*" -1275- EXEC SQL DECLARE MOVTO CURSOR FOR SELECT A.NUM_APOLICE ,A.NRENDOS ,C.COD_PRODUTO ,B.CODSUBES ,B.DTINIVIG ,B.DTTERVIG ,B.SITUACAO FROM SEGUROS.V1HISTOPARC A ,SEGUROS.V0ENDOSSO B ,SEGUROS.APOLICES C WHERE C.ORGAO_EMISSOR <> 90 AND A.NUM_APOLICE NOT IN (109300001662 , 109300001664 , 109300001666 , 107700000014) AND A.NUM_APOLICE = C.NUM_APOLICE AND A.DTMOVTO = :V1SIST-DTMOVABE AND A.NRPARCEL IN (0,1) AND A.OPERACAO BETWEEN 100 AND 199 AND A.NUM_APOLICE = B.NUM_APOLICE AND A.NRENDOS = B.NRENDOS ORDER BY NUM_APOLICE ,NRENDOS WITH UR END-EXEC. */
            MOVTO = new FN0301B_MOVTO(true);
            string GetQuery_MOVTO()
            {
                var query = @$"SELECT A.NUM_APOLICE 
							,A.NRENDOS 
							,C.COD_PRODUTO 
							,B.CODSUBES 
							,B.DTINIVIG 
							,B.DTTERVIG 
							,B.SITUACAO 
							FROM SEGUROS.V1HISTOPARC A 
							,SEGUROS.V0ENDOSSO B 
							,SEGUROS.APOLICES C 
							WHERE C.ORGAO_EMISSOR <> 90 
							AND A.NUM_APOLICE NOT IN (109300001662
							, 
							109300001664
							, 
							109300001666
							, 
							107700000014) 
							AND A.NUM_APOLICE = C.NUM_APOLICE 
							AND A.DTMOVTO = '{V1SIST_DTMOVABE}' 
							AND A.NRPARCEL IN (0
							,1) 
							AND A.OPERACAO BETWEEN 100 AND 199 
							AND A.NUM_APOLICE = B.NUM_APOLICE 
							AND A.NRENDOS = B.NRENDOS 
							ORDER BY NUM_APOLICE 
							,NRENDOS";

                return query;
            }
            MOVTO.GetQueryEvent += GetQuery_MOVTO;

        }

        [StopWatch]
        /*" R0300-00-DECLARE-V1HISTOPARC-DB-OPEN-1 */
        public void R0300_00_DECLARE_V1HISTOPARC_DB_OPEN_1()
        {
            /*" -1277- EXEC SQL OPEN MOVTO END-EXEC. */

            MOVTO.Open();

        }

        [StopWatch]
        /*" R1400-00-GRAVA-FENCOMI-DB-DECLARE-1 */
        public void R1400_00_GRAVA_FENCOMI_DB_DECLARE_1()
        {
            /*" -2294- EXEC SQL DECLARE V1APOLCORRET CURSOR FOR SELECT NUM_APOLICE , CODSUBES , RAMOFR , CODCORR , PCCOMCOR , PCPARCOR , TIPCOM FROM SEGUROS.V1APOLCORRET WHERE NUM_APOLICE = :V1ENDO-NUMAPOL AND CODSUBES = :V1ENDO-CODSUBES ORDER BY NUM_APOLICE,CODSUBES,RAMOFR WITH UR END-EXEC. */
            V1APOLCORRET = new FN0301B_V1APOLCORRET(true);
            string GetQuery_V1APOLCORRET()
            {
                var query = @$"SELECT NUM_APOLICE
							, 
							CODSUBES
							, 
							RAMOFR
							, 
							CODCORR
							, 
							PCCOMCOR
							, 
							PCPARCOR
							, 
							TIPCOM 
							FROM SEGUROS.V1APOLCORRET 
							WHERE NUM_APOLICE = '{V1ENDO_NUMAPOL}' 
							AND CODSUBES = '{V1ENDO_CODSUBES}' 
							ORDER BY NUM_APOLICE
							,CODSUBES
							,RAMOFR";

                return query;
            }
            V1APOLCORRET.GetQueryEvent += GetQuery_V1APOLCORRET;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_99_SAIDA*/

        [StopWatch]
        /*" R0400-00-GRAVA-TRAILLERS-SECTION */
        private void R0400_00_GRAVA_TRAILLERS_SECTION()
        {
            /*" -1294- MOVE V1SIST-DTMOVABE TO FTRL-DTMOVABE */
            _.Move(V1SIST_DTMOVABE, WREG_TRAILLER.FTRL_DTMOVABE);

            /*" -1295- MOVE AC-G-FENEMIS TO FTRL-QTDREG */
            _.Move(AREA_DE_WORK.AC_G_FENEMIS, WREG_TRAILLER.FTRL_QTDREG);

            /*" -1297- WRITE REG-FENEMIS FROM WREG-TRAILLER */
            _.Move(WREG_TRAILLER.GetMoveValues(), REG_FENEMIS);

            FENEMIS.Write(REG_FENEMIS.GetMoveValues().ToString());

            /*" -1298- MOVE AC-G-FENPANA TO FTRL-QTDREG */
            _.Move(AREA_DE_WORK.AC_G_FENPANA, WREG_TRAILLER.FTRL_QTDREG);

            /*" -1300- WRITE REG-FENPANA FROM WREG-TRAILLER */
            _.Move(WREG_TRAILLER.GetMoveValues(), REG_FENPANA);

            FENPANA.Write(REG_FENPANA.GetMoveValues().ToString());

            /*" -1301- MOVE AC-G-FENPARC TO FTRL-QTDREG */
            _.Move(AREA_DE_WORK.AC_G_FENPARC, WREG_TRAILLER.FTRL_QTDREG);

            /*" -1303- WRITE REG-FENPARC FROM WREG-TRAILLER */
            _.Move(WREG_TRAILLER.GetMoveValues(), REG_FENPARC);

            FENPARC.Write(REG_FENPARC.GetMoveValues().ToString());

            /*" -1304- MOVE AC-G-FENCOMI TO FTRL-QTDREG */
            _.Move(AREA_DE_WORK.AC_G_FENCOMI, WREG_TRAILLER.FTRL_QTDREG);

            /*" -1306- WRITE REG-FENCOMI FROM WREG-TRAILLER */
            _.Move(WREG_TRAILLER.GetMoveValues(), REG_FENCOMI);

            FENCOMI.Write(REG_FENCOMI.GetMoveValues().ToString());

            /*" -1307- MOVE AC-G-FENCOSS TO FTRL-QTDREG */
            _.Move(AREA_DE_WORK.AC_G_FENCOSS, WREG_TRAILLER.FTRL_QTDREG);

            /*" -1309- WRITE REG-FENCOSS FROM WREG-TRAILLER */
            _.Move(WREG_TRAILLER.GetMoveValues(), REG_FENCOSS);

            FENCOSS.Write(REG_FENCOSS.GetMoveValues().ToString());

            /*" -1310- MOVE AC-G-FENRESS TO FTRL-QTDREG */
            _.Move(AREA_DE_WORK.AC_G_FENRESS, WREG_TRAILLER.FTRL_QTDREG);

            /*" -1312- WRITE REG-FENRESS FROM WREG-TRAILLER */
            _.Move(WREG_TRAILLER.GetMoveValues(), REG_FENRESS);

            FENRESS.Write(REG_FENRESS.GetMoveValues().ToString());

            /*" -1313- MOVE AC-G-FENAUTO TO FTRL-QTDREG */
            _.Move(AREA_DE_WORK.AC_G_FENAUTO, WREG_TRAILLER.FTRL_QTDREG);

            /*" -1315- WRITE REG-FENAUTO FROM WREG-TRAILLER */
            _.Move(WREG_TRAILLER.GetMoveValues(), REG_FENAUTO);

            FENAUTO.Write(REG_FENAUTO.GetMoveValues().ToString());

            /*" -1316- MOVE AC-G-FENAUT1 TO FTRL-QTDREG */
            _.Move(AREA_DE_WORK.AC_G_FENAUT1, WREG_TRAILLER.FTRL_QTDREG);

            /*" -1318- WRITE REG-FENAUT1 FROM WREG-TRAILLER */
            _.Move(WREG_TRAILLER.GetMoveValues(), REG_FENAUT1);

            FENAUT1.Write(REG_FENAUT1.GetMoveValues().ToString());

            /*" -1319- MOVE AC-G-FENVIDA TO FTRL-QTDREG */
            _.Move(AREA_DE_WORK.AC_G_FENVIDA, WREG_TRAILLER.FTRL_QTDREG);

            /*" -1321- WRITE REG-FENVIDA FROM WREG-TRAILLER */
            _.Move(WREG_TRAILLER.GetMoveValues(), REG_FENVIDA);

            FENVIDA.Write(REG_FENVIDA.GetMoveValues().ToString());

            /*" -1322- MOVE AC-G-FENOUTR TO FTRL-QTDREG */
            _.Move(AREA_DE_WORK.AC_G_FENOUTR, WREG_TRAILLER.FTRL_QTDREG);

            /*" -1322- WRITE REG-FENOUTR FROM WREG-TRAILLER. */
            _.Move(WREG_TRAILLER.GetMoveValues(), REG_FENOUTR);

            FENOUTR.Write(REG_FENOUTR.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0400_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSAMENTO-SECTION */
        private void R1000_00_PROCESSAMENTO_SECTION()
        {
            /*" -1333- MOVE '1000' TO WNR-EXEC-SQL. */
            _.Move("1000", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1335- DISPLAY 'LENDO CURSOR ' V1APCR-NUM-APOL */
            _.Display($"LENDO CURSOR {V1APCR_NUM_APOL}");

            /*" -1337- MOVE ' ' TO WS-PANAMERICANO */
            _.Move(" ", WS_AULIARES.WS_PANAMERICANO);

            /*" -1338- PERFORM R1100-00-SELECT-V1ENDOSSO */

            R1100_00_SELECT_V1ENDOSSO_SECTION();

            /*" -1340- PERFORM R0911-00-VERIF-CORRET-PANAM */

            R0911_00_VERIF_CORRET_PANAM_SECTION();

            /*" -1344- IF APOLICES-COD-PRODUTO EQUAL 4000 OR 4005 OR 4500 OR 4505 OR 7500 OR 7501 OR 7599 NEXT SENTENCE */

            if (APOLICES.DCLAPOLICES.APOLICES_COD_PRODUTO.In("4000", "4005", "4500", "4505", "7500", "7501", "7599"))
            {

                /*" -1345- ELSE */
            }
            else
            {


                /*" -1346- MOVE SPACES TO CLIENTES-NOME-RAZAO */
                _.Move("", CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO);

                /*" -1347- GO TO MOVIMENTA-TOMADOR */

                MOVIMENTA_TOMADOR(); //GOTO
                return;

                /*" -1349- END-IF. */
            }


            /*" -1350- MOVE V1ENDO-NRPROPOS TO TOMADOR-NUM-PROPOSTA. */
            _.Move(V1ENDO_NRPROPOS, TOMADOR.DCLTOMADOR.TOMADOR_NUM_PROPOSTA);

            /*" -1351- MOVE V1ENDO-FONTE TO TOMADOR-COD-FONTE. */
            _.Move(V1ENDO_FONTE, TOMADOR.DCLTOMADOR.TOMADOR_COD_FONTE);

            /*" -1352- PERFORM R2230-00-SELECT-TOMADOR. */

            R2230_00_SELECT_TOMADOR_SECTION();

            /*" -0- FLUXCONTROL_PERFORM MOVIMENTA_TOMADOR */

            MOVIMENTA_TOMADOR();

        }

        [StopWatch]
        /*" MOVIMENTA-TOMADOR */
        private void MOVIMENTA_TOMADOR(bool isPerform = false)
        {
            /*" -1361- MOVE CLIENTES-NOME-RAZAO TO FEMI-TOMADOR. */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO, WREG_FENEMIS.FEMI_TOMADOR);

            /*" -1362- IF WS-PANAMERICANO EQUAL 'S' */

            if (WS_AULIARES.WS_PANAMERICANO == "S")
            {

                /*" -1363- PERFORM R1211-00-GRAVA-FENPANA */

                R1211_00_GRAVA_FENPANA_SECTION();

                /*" -1364- GO TO R1000-90-LEITURA */

                R1000_90_LEITURA(); //GOTO
                return;

                /*" -1366- END-IF */
            }


            /*" -1368- PERFORM R1200-00-GRAVA-FENEMIS */

            R1200_00_GRAVA_FENEMIS_SECTION();

            /*" -1370- PERFORM R1300-00-GRAVA-FENPARC */

            R1300_00_GRAVA_FENPARC_SECTION();

            /*" -1371- IF V1ENDO-TIPO-ENDO EQUAL '0' */

            if (V1ENDO_TIPO_ENDO == "0")
            {

                /*" -1372- PERFORM R1400-00-GRAVA-FENCOMI */

                R1400_00_GRAVA_FENCOMI_SECTION();

                /*" -1373- PERFORM R1500-00-GRAVA-FENCOSS */

                R1500_00_GRAVA_FENCOSS_SECTION();

                /*" -1375- END-IF */
            }


            /*" -1377- PERFORM R1600-00-GRAVA-FENRESS */

            R1600_00_GRAVA_FENRESS_SECTION();

            /*" -1378- IF V1ENDO-RAMO EQUAL 31 OR 53 */

            if (V1ENDO_RAMO.In("31", "53"))
            {

                /*" -1379- PERFORM R2000-00-PROCESSA-AUTO */

                R2000_00_PROCESSA_AUTO_SECTION();

                /*" -1380- ELSE */
            }
            else
            {


                /*" -1381- IF V1ENDO-RAMO EQUAL 93 OR 97 */

                if (V1ENDO_RAMO.In("93", "97"))
                {

                    /*" -1382- PERFORM R3000-00-PROCESSA-VIDA */

                    R3000_00_PROCESSA_VIDA_SECTION();

                    /*" -1383- ELSE */
                }
                else
                {


                    /*" -1387- IF V1ENDO-RAMO EQUAL 71 OR V1ENDO-RAMO EQUAL 14 OR V1ENDO-RAMO EQUAL 16 OR V1ENDO-RAMO EQUAL 18 */

                    if (V1ENDO_RAMO == 71 || V1ENDO_RAMO == 14 || V1ENDO_RAMO == 16 || V1ENDO_RAMO == 18)
                    {

                        /*" -1388- IF V1ENDO-CODPRODU EQUAL 1403 OR 1404 */

                        if (V1ENDO_CODPRODU.In("1403", "1404"))
                        {

                            /*" -1389- PERFORM R6300-00-MR-APO-COBER */

                            R6300_00_MR_APO_COBER_SECTION();

                            /*" -1390- ELSE */
                        }
                        else
                        {


                            /*" -1391- PERFORM R6000-00-PROCESSA-OUTROS */

                            R6000_00_PROCESSA_OUTROS_SECTION();

                            /*" -1392- END-IF */
                        }


                        /*" -1393- ELSE */
                    }
                    else
                    {


                        /*" -1393- PERFORM R5000-00-PROCESSA-OUTROS. */

                        R5000_00_PROCESSA_OUTROS_SECTION();
                    }

                }

            }


        }

        [StopWatch]
        /*" R1000-90-LEITURA */
        private void R1000_90_LEITURA(bool isPerform = false)
        {
            /*" -1397- PERFORM R0900-00-FETCH-V1HISTOPARC. */

            R0900_00_FETCH_V1HISTOPARC_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1100-00-SELECT-V1ENDOSSO-SECTION */
        private void R1100_00_SELECT_V1ENDOSSO_SECTION()
        {
            /*" -1410- MOVE '1100' TO WNR-EXEC-SQL. */
            _.Move("1100", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1459- PERFORM R1100_00_SELECT_V1ENDOSSO_DB_SELECT_1 */

            R1100_00_SELECT_V1ENDOSSO_DB_SELECT_1();

            /*" -1462- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1463- DISPLAY 'R1100-00 (ERRO NO SELECT V1ENDOSSO)' */
                _.Display($"R1100-00 (ERRO NO SELECT V1ENDOSSO)");

                /*" -1464- DISPLAY 'APOLICE = ' V1HISP-NUMAPOL */
                _.Display($"APOLICE = {V1HISP_NUMAPOL}");

                /*" -1465- DISPLAY 'ENDOSSO = ' V1HISP-NRENDOS */
                _.Display($"ENDOSSO = {V1HISP_NRENDOS}");

                /*" -1467- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1469- ADD 1 TO AC-L-V1ENDOSSO */
            AREA_DE_WORK.AC_L_V1ENDOSSO.Value = AREA_DE_WORK.AC_L_V1ENDOSSO + 1;

            /*" -1470- IF VIND-CODPRODU EQUAL -1 */

            if (VIND_CODPRODU == -1)
            {

                /*" -1470- MOVE ZEROS TO V1ENDO-CODPRODU. */
                _.Move(0, V1ENDO_CODPRODU);
            }


        }

        [StopWatch]
        /*" R1100-00-SELECT-V1ENDOSSO-DB-SELECT-1 */
        public void R1100_00_SELECT_V1ENDOSSO_DB_SELECT_1()
        {
            /*" -1459- EXEC SQL SELECT NUM_APOLICE, NRENDOS, CODSUBES, FONTE , NRPROPOS, NUMBIL, NRRCAP, RAMO , CODPRODU, NUM_APOL_ANTERIOR, DTEMIS , DTINIVIG , DTTERVIG , CODCLIEN, QTPARCEL, OCORR_ENDERECO , COD_MOEDA_IMP, COD_MOEDA_PRM, TIPO_ENDOSSO, SITUACAO, AGERCAP, AGECOBR INTO :V1ENDO-NUMAPOL, :V1ENDO-NRENDOS, :V1ENDO-CODSUBES, :V1ENDO-FONTE , :V1ENDO-NRPROPOS, :V1ENDO-NUMBIL, :V1ENDO-NRRCAP, :V1ENDO-RAMO , :V1ENDO-CODPRODU:VIND-CODPRODU, :V1ENDO-APOLANT, :V1ENDO-DTEMIS, :V1ENDO-DTINIVIG, :V1ENDO-DTTERVIG, :V1ENDO-CODCLIEN, :V1ENDO-QTPARCEL, :V1ENDO-OCORR-END , :V1ENDO-MOEDA-IMP, :V1ENDO-MOEDA-PRM, :V1ENDO-TIPO-ENDO, :V1ENDO-SITUACAO, :V1ENDO-AGERCAP, :V1ENDO-AGECOBR FROM SEGUROS.V1ENDOSSO WHERE NUM_APOLICE = :V1HISP-NUMAPOL AND NRENDOS = :V1HISP-NRENDOS WITH UR END-EXEC. */

            var r1100_00_SELECT_V1ENDOSSO_DB_SELECT_1_Query1 = new R1100_00_SELECT_V1ENDOSSO_DB_SELECT_1_Query1()
            {
                V1HISP_NUMAPOL = V1HISP_NUMAPOL.ToString(),
                V1HISP_NRENDOS = V1HISP_NRENDOS.ToString(),
            };

            var executed_1 = R1100_00_SELECT_V1ENDOSSO_DB_SELECT_1_Query1.Execute(r1100_00_SELECT_V1ENDOSSO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1ENDO_NUMAPOL, V1ENDO_NUMAPOL);
                _.Move(executed_1.V1ENDO_NRENDOS, V1ENDO_NRENDOS);
                _.Move(executed_1.V1ENDO_CODSUBES, V1ENDO_CODSUBES);
                _.Move(executed_1.V1ENDO_FONTE, V1ENDO_FONTE);
                _.Move(executed_1.V1ENDO_NRPROPOS, V1ENDO_NRPROPOS);
                _.Move(executed_1.V1ENDO_NUMBIL, V1ENDO_NUMBIL);
                _.Move(executed_1.V1ENDO_NRRCAP, V1ENDO_NRRCAP);
                _.Move(executed_1.V1ENDO_RAMO, V1ENDO_RAMO);
                _.Move(executed_1.V1ENDO_CODPRODU, V1ENDO_CODPRODU);
                _.Move(executed_1.VIND_CODPRODU, VIND_CODPRODU);
                _.Move(executed_1.V1ENDO_APOLANT, V1ENDO_APOLANT);
                _.Move(executed_1.V1ENDO_DTEMIS, V1ENDO_DTEMIS);
                _.Move(executed_1.V1ENDO_DTINIVIG, V1ENDO_DTINIVIG);
                _.Move(executed_1.V1ENDO_DTTERVIG, V1ENDO_DTTERVIG);
                _.Move(executed_1.V1ENDO_CODCLIEN, V1ENDO_CODCLIEN);
                _.Move(executed_1.V1ENDO_QTPARCEL, V1ENDO_QTPARCEL);
                _.Move(executed_1.V1ENDO_OCORR_END, V1ENDO_OCORR_END);
                _.Move(executed_1.V1ENDO_MOEDA_IMP, V1ENDO_MOEDA_IMP);
                _.Move(executed_1.V1ENDO_MOEDA_PRM, V1ENDO_MOEDA_PRM);
                _.Move(executed_1.V1ENDO_TIPO_ENDO, V1ENDO_TIPO_ENDO);
                _.Move(executed_1.V1ENDO_SITUACAO, V1ENDO_SITUACAO);
                _.Move(executed_1.V1ENDO_AGERCAP, V1ENDO_AGERCAP);
                _.Move(executed_1.V1ENDO_AGECOBR, V1ENDO_AGECOBR);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/

        [StopWatch]
        /*" R1200-00-GRAVA-FENEMIS-SECTION */
        private void R1200_00_GRAVA_FENEMIS_SECTION()
        {
            /*" -1483- MOVE '1200' TO WNR-EXEC-SQL. */
            _.Move("1200", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1484- MOVE V1ENDO-CODCLIEN TO WHOST-CODCLIEN */
            _.Move(V1ENDO_CODCLIEN, WHOST_CODCLIEN);

            /*" -1486- PERFORM R1210-00-SELECT-V1CLIENTE */

            R1210_00_SELECT_V1CLIENTE_SECTION();

            /*" -1487- MOVE V1ENDO-OCORR-END TO WHOST-CODENDER */
            _.Move(V1ENDO_OCORR_END, WHOST_CODENDER);

            /*" -1489- PERFORM R1220-00-SELECT-V1ENDERECOS */

            R1220_00_SELECT_V1ENDERECOS_SECTION();

            /*" -1490- MOVE V1ENDO-NUMAPOL TO FEMI-NUMAPOL */
            _.Move(V1ENDO_NUMAPOL, WREG_FENEMIS.FEMI_NUMAPOL);

            /*" -1491- MOVE V1ENDO-NRENDOS TO FEMI-NRENDOS */
            _.Move(V1ENDO_NRENDOS, WREG_FENEMIS.FEMI_NRENDOS);

            /*" -1492- MOVE V1ENDO-CODSUBES TO FEMI-CODSUBES */
            _.Move(V1ENDO_CODSUBES, WREG_FENEMIS.FEMI_CODSUBES);

            /*" -1493- MOVE V1ENDO-FONTE TO FEMI-FONTE */
            _.Move(V1ENDO_FONTE, WREG_FENEMIS.FEMI_FONTE);

            /*" -1494- MOVE V1ENDO-NRPROPOS TO FEMI-NRPROPOS */
            _.Move(V1ENDO_NRPROPOS, WREG_FENEMIS.FEMI_NRPROPOS);

            /*" -1495- MOVE V1ENDO-NUMBIL TO FEMI-NUMBIL */
            _.Move(V1ENDO_NUMBIL, WREG_FENEMIS.FEMI_NUMBIL);

            /*" -1496- MOVE V1ENDO-NRRCAP TO FEMI-NUMSICOB */
            _.Move(V1ENDO_NRRCAP, WREG_FENEMIS.FEMI_NUMSICOB);

            /*" -1497- MOVE V1ENDO-RAMO TO FEMI-CODRAMO */
            _.Move(V1ENDO_RAMO, WREG_FENEMIS.FEMI_CODRAMO);

            /*" -1498- MOVE V1ENDO-CODPRODU TO FEMI-CODPRODU */
            _.Move(V1ENDO_CODPRODU, WREG_FENEMIS.FEMI_CODPRODU);

            /*" -1499- MOVE V1ENDO-APOLANT TO FEMI-NUMAPOLANT */
            _.Move(V1ENDO_APOLANT, WREG_FENEMIS.FEMI_NUMAPOLANT);

            /*" -1500- MOVE V1ENDO-DTEMIS TO FEMI-DTEMIS */
            _.Move(V1ENDO_DTEMIS, WREG_FENEMIS.FEMI_DTEMIS);

            /*" -1501- MOVE V1ENDO-DTINIVIG TO FEMI-DTINIVIG */
            _.Move(V1ENDO_DTINIVIG, WREG_FENEMIS.FEMI_DTINIVIG);

            /*" -1502- MOVE V1ENDO-DTTERVIG TO FEMI-DTTERVIG */
            _.Move(V1ENDO_DTTERVIG, WREG_FENEMIS.FEMI_DTTERVIG);

            /*" -1503- MOVE V1ENDO-CODCLIEN TO FEMI-CODCLIEN */
            _.Move(V1ENDO_CODCLIEN, WREG_FENEMIS.FEMI_CODCLIEN);

            /*" -1504- MOVE V1CLIE-NOME TO FEMI-NOMSEG */
            _.Move(V1CLIE_NOME, WREG_FENEMIS.FEMI_NOMSEG);

            /*" -1505- MOVE V1CLIE-TPPESSOA TO FEMI-TIPOPES */
            _.Move(V1CLIE_TPPESSOA, WREG_FENEMIS.FEMI_TIPOPES);

            /*" -1506- MOVE V1CLIE-CGCCPF TO FEMI-CPFCGC */
            _.Move(V1CLIE_CGCCPF, WREG_FENEMIS.FEMI_CPFCGC);

            /*" -1507- MOVE V1ENDO-OCORR-END TO FEMI-OCORREND */
            _.Move(V1ENDO_OCORR_END, WREG_FENEMIS.FEMI_OCORREND);

            /*" -1508- MOVE V1ENDE-ENDERECO TO FEMI-ENDERECO */
            _.Move(V1ENDE_ENDERECO, WREG_FENEMIS.FEMI_ENDERECO);

            /*" -1509- MOVE V1ENDE-BAIRRO TO FEMI-BAIRRO */
            _.Move(V1ENDE_BAIRRO, WREG_FENEMIS.FEMI_BAIRRO);

            /*" -1510- MOVE V1ENDE-CIDADE TO FEMI-CIDADE */
            _.Move(V1ENDE_CIDADE, WREG_FENEMIS.FEMI_CIDADE);

            /*" -1511- MOVE V1ENDE-ESTADO TO FEMI-SIGLA-UF */
            _.Move(V1ENDE_ESTADO, WREG_FENEMIS.FEMI_SIGLA_UF);

            /*" -1512- MOVE V1ENDE-CEP TO FEMI-CEP */
            _.Move(V1ENDE_CEP, WREG_FENEMIS.FEMI_CEP);

            /*" -1513- MOVE V1ENDE-DDD TO FEMI-DDD */
            _.Move(V1ENDE_DDD, WREG_FENEMIS.FEMI_DDD);

            /*" -1516- MOVE V1ENDE-TELEFONE TO FEMI-FONE */
            _.Move(V1ENDE_TELEFONE, WREG_FENEMIS.FEMI_FONE);

            /*" -1526- PERFORM R1200_00_GRAVA_FENEMIS_DB_SELECT_1 */

            R1200_00_GRAVA_FENEMIS_DB_SELECT_1();

            /*" -1529- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1530- DISPLAY 'R1200-00 (ERRO NO SELECT V1ENDOSSO)' */
                _.Display($"R1200-00 (ERRO NO SELECT V1ENDOSSO)");

                /*" -1531- DISPLAY 'APOLICE = ' V1HISP-NUMAPOL */
                _.Display($"APOLICE = {V1HISP_NUMAPOL}");

                /*" -1532- DISPLAY 'ENDOSSO = ' V1HISP-NRENDOS */
                _.Display($"ENDOSSO = {V1HISP_NRENDOS}");

                /*" -1534- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1535- MOVE V1HISP-VLPRMTOT TO FEMI-VLPRMTOT */
            _.Move(V1HISP_VLPRMTOT, WREG_FENEMIS.FEMI_VLPRMTOT);

            /*" -1536- MOVE V1HISP-VLPRMLIQ TO FEMI-VLPRMLIQ */
            _.Move(V1HISP_VLPRMLIQ, WREG_FENEMIS.FEMI_VLPRMLIQ);

            /*" -1538- MOVE V1ENDO-QTPARCEL TO FEMI-QTPARCEL */
            _.Move(V1ENDO_QTPARCEL, WREG_FENEMIS.FEMI_QTPARCEL);

            /*" -1539- IF V1ENDO-RAMO EQUAL 31 OR 53 */

            if (V1ENDO_RAMO.In("31", "53"))
            {

                /*" -1540- MOVE V1ENDO-AGECOBR TO FEMI-CODAGENC */
                _.Move(V1ENDO_AGECOBR, WREG_FENEMIS.FEMI_CODAGENC);

                /*" -1541- ELSE */
            }
            else
            {


                /*" -1545- IF V1ENDO-RAMO EQUAL 71 OR V1ENDO-RAMO EQUAL 14 OR V1ENDO-RAMO EQUAL 16 OR V1ENDO-RAMO EQUAL 18 */

                if (V1ENDO_RAMO == 71 || V1ENDO_RAMO == 14 || V1ENDO_RAMO == 16 || V1ENDO_RAMO == 18)
                {

                    /*" -1546- PERFORM R1250-00-AGENCIA-RCAP */

                    R1250_00_AGENCIA_RCAP_SECTION();

                    /*" -1547- IF V0RCAP-AGECOBR EQUAL 0 */

                    if (V0RCAP_AGECOBR == 0)
                    {

                        /*" -1548- MOVE V1ENDO-AGERCAP TO FEMI-CODAGENC */
                        _.Move(V1ENDO_AGERCAP, WREG_FENEMIS.FEMI_CODAGENC);

                        /*" -1549- ELSE */
                    }
                    else
                    {


                        /*" -1550- MOVE V0RCAP-AGECOBR TO FEMI-CODAGENC */
                        _.Move(V0RCAP_AGECOBR, WREG_FENEMIS.FEMI_CODAGENC);

                        /*" -1551- ELSE */
                    }

                }
                else
                {


                    /*" -1556- MOVE V1ENDO-AGERCAP TO FEMI-CODAGENC. */
                    _.Move(V1ENDO_AGERCAP, WREG_FENEMIS.FEMI_CODAGENC);
                }

            }


            /*" -1560- IF V1ENDO-CODPRODU EQUAL 1403 OR = 1404 OR V1ENDO-CODPRODU EQUAL 1601 OR = 1602 OR V1ENDO-CODPRODU EQUAL 1801 OR 1802 OR 1804 */

            if (V1ENDO_CODPRODU.In("1403", "1404") || V1ENDO_CODPRODU.In("1601", "1602") || V1ENDO_CODPRODU.In("1801", "1802", "1804"))
            {

                /*" -1563- MOVE V1ENDO-AGECOBR TO FEMI-CODAGENC. */
                _.Move(V1ENDO_AGECOBR, WREG_FENEMIS.FEMI_CODAGENC);
            }


            /*" -1564- IF V1ENDO-RAMO EQUAL 31 */

            if (V1ENDO_RAMO == 31)
            {

                /*" -1565- PERFORM R1230-00-INDICADOR-AUTO */

                R1230_00_INDICADOR_AUTO_SECTION();

                /*" -1566- ELSE */
            }
            else
            {


                /*" -1569- IF V1ENDO-RAMO EQUAL 72 OR V1ENDO-RAMO EQUAL 82 OR V1ENDO-CODPRODU EQUAL 1402 */

                if (V1ENDO_RAMO == 72 || V1ENDO_RAMO == 82 || V1ENDO_CODPRODU == 1402)
                {

                    /*" -1570- PERFORM R1240-00-INDICADOR-BILHETE */

                    R1240_00_INDICADOR_BILHETE_SECTION();

                    /*" -1571- ELSE */
                }
                else
                {


                    /*" -1576- MOVE ZEROS TO WHOST-MATRIC-IND. */
                    _.Move(0, WHOST_MATRIC_IND);
                }

            }


            /*" -1580- IF V1ENDO-CODPRODU EQUAL 1403 OR = 1404 OR V1ENDO-CODPRODU EQUAL 1601 OR = 1602 OR V1ENDO-CODPRODU EQUAL 1801 OR 1802 OR 1804 */

            if (V1ENDO_CODPRODU.In("1403", "1404") || V1ENDO_CODPRODU.In("1601", "1602") || V1ENDO_CODPRODU.In("1801", "1802", "1804"))
            {

                /*" -1583- PERFORM R1230-00-INDICADOR-AUTO. */

                R1230_00_INDICADOR_AUTO_SECTION();
            }


            /*" -1584- MOVE WHOST-MATRIC-IND TO FEMI-MATRIC-IND */
            _.Move(WHOST_MATRIC_IND, WREG_FENEMIS.FEMI_MATRIC_IND);

            /*" -1587- MOVE ZEROS TO FEMI-MATRIC-GER FEMI-MATRIC-SUNEG */
            _.Move(0, WREG_FENEMIS.FEMI_MATRIC_GER, WREG_FENEMIS.FEMI_MATRIC_SUNEG);

            /*" -1588- MOVE V1ENDO-TIPO-ENDO TO FEMI-TIPOENDO */
            _.Move(V1ENDO_TIPO_ENDO, WREG_FENEMIS.FEMI_TIPOENDO);

            /*" -1589- MOVE V1ENDO-SITUACAO TO FEMI-SITUACAO */
            _.Move(V1ENDO_SITUACAO, WREG_FENEMIS.FEMI_SITUACAO);

            /*" -1590- MOVE V1ENDO-MOEDA-IMP TO FEMI-CODMOEDA-IMP */
            _.Move(V1ENDO_MOEDA_IMP, WREG_FENEMIS.FEMI_CODMOEDA_IMP);

            /*" -1591- MOVE V1ENDO-MOEDA-PRM TO FEMI-CODMOEDA-PRM */
            _.Move(V1ENDO_MOEDA_PRM, WREG_FENEMIS.FEMI_CODMOEDA_PRM);

            /*" -1593- MOVE V1ENDO-RAMO TO FEMI-LAYOUT */
            _.Move(V1ENDO_RAMO, WREG_FENEMIS.FEMI_LAYOUT);

            /*" -1598- IF V1ENDO-RAMO EQUAL 31 OR (V1ENDO-RAMO EQUAL 53 AND (V1ENDO-CODPRODU EQUAL 5302 OR V1ENDO-CODPRODU EQUAL 5303 OR V1ENDO-CODPRODU EQUAL 5304)) */

            if (V1ENDO_RAMO == 31 || (V1ENDO_RAMO == 53 && (V1ENDO_CODPRODU == 5302 || V1ENDO_CODPRODU == 5303 || V1ENDO_CODPRODU == 5304)))
            {

                /*" -1599- PERFORM R1260-00-LE-PROPOSTA-CONV-AUTO */

                R1260_00_LE_PROPOSTA_CONV_AUTO_SECTION();

                /*" -1600- MOVE APOLIAUT-NUM-PROPOSTA-CONV TO FEMI-PROPOSTA-SIVPF */
                _.Move(APOLIAUT.DCLAPOLICE_AUTO.APOLIAUT_NUM_PROPOSTA_CONV, WREG_FENEMIS.FEMI_PROPOSTA_SIVPF);

                /*" -1601- ELSE */
            }
            else
            {


                /*" -1603- IF V1ENDO-NRENDOS GREATER ZEROS */

                if (V1ENDO_NRENDOS > 00)
                {

                    /*" -1605- PERFORM R1253-00-BUSCA-ENDO-NRRCAP */

                    R1253_00_BUSCA_ENDO_NRRCAP_SECTION();

                    /*" -1607- MOVE V0ENDO-NRRCAP TO WHOST-NRRCAP */
                    _.Move(V0ENDO_NRRCAP, WHOST_NRRCAP);

                    /*" -1609- PERFORM R1251-00-BUSCA-NCERTIFICADO */

                    R1251_00_BUSCA_NCERTIFICADO_SECTION();

                    /*" -1610- IF SQLCODE EQUAL ZEROS */

                    if (DB.SQLCODE == 00)
                    {

                        /*" -1611- PERFORM R1252-00-SELECT-PROPOFID */

                        R1252_00_SELECT_PROPOFID_SECTION();

                        /*" -1612- IF SQLCODE EQUAL ZEROS */

                        if (DB.SQLCODE == 00)
                        {

                            /*" -1613- MOVE V0RCAP-NRCERTIF TO FEMI-PROPOSTA-SIVPF */
                            _.Move(V0RCAP_NRCERTIF, WREG_FENEMIS.FEMI_PROPOSTA_SIVPF);

                            /*" -1614- ELSE */
                        }
                        else
                        {


                            /*" -1615- MOVE ZEROS TO FEMI-PROPOSTA-SIVPF */
                            _.Move(0, WREG_FENEMIS.FEMI_PROPOSTA_SIVPF);

                            /*" -1616- ELSE */
                        }

                    }
                    else
                    {


                        /*" -1617- MOVE ZEROS TO FEMI-PROPOSTA-SIVPF */
                        _.Move(0, WREG_FENEMIS.FEMI_PROPOSTA_SIVPF);

                        /*" -1618- ELSE */
                    }

                }
                else
                {


                    /*" -1619- MOVE V1ENDO-NRRCAP TO WHOST-NRRCAP */
                    _.Move(V1ENDO_NRRCAP, WHOST_NRRCAP);

                    /*" -1620- PERFORM R1251-00-BUSCA-NCERTIFICADO */

                    R1251_00_BUSCA_NCERTIFICADO_SECTION();

                    /*" -1621- IF SQLCODE EQUAL ZEROS */

                    if (DB.SQLCODE == 00)
                    {

                        /*" -1622- PERFORM R1252-00-SELECT-PROPOFID */

                        R1252_00_SELECT_PROPOFID_SECTION();

                        /*" -1623- IF SQLCODE EQUAL ZEROS */

                        if (DB.SQLCODE == 00)
                        {

                            /*" -1624- MOVE V0RCAP-NRCERTIF TO FEMI-PROPOSTA-SIVPF */
                            _.Move(V0RCAP_NRCERTIF, WREG_FENEMIS.FEMI_PROPOSTA_SIVPF);

                            /*" -1625- ELSE */
                        }
                        else
                        {


                            /*" -1626- MOVE ZEROS TO FEMI-PROPOSTA-SIVPF */
                            _.Move(0, WREG_FENEMIS.FEMI_PROPOSTA_SIVPF);

                            /*" -1627- ELSE */
                        }

                    }
                    else
                    {


                        /*" -1631- MOVE ZEROS TO FEMI-PROPOSTA-SIVPF. */
                        _.Move(0, WREG_FENEMIS.FEMI_PROPOSTA_SIVPF);
                    }

                }

            }


            /*" -1632- MOVE FEMI-NOMSEG TO TAB-ALFA-GRUPO */
            _.Move(WREG_FENEMIS.FEMI_NOMSEG, TABELA_ALFA.TAB_ALFA_GRUPO);

            /*" -1635- PERFORM R0930-00-ALTERA-CAMPO VARYING INDX FROM 1 BY 1 UNTIL INDX GREATER 40 */

            for (INDX.Value = 1; !(INDX > 40); INDX.Value += 1)
            {

                R0930_00_ALTERA_CAMPO_SECTION();
            }

            /*" -1636- MOVE TAB-ALFA-GRUPO TO FEMI-NOMSEG */
            _.Move(TABELA_ALFA.TAB_ALFA_GRUPO, WREG_FENEMIS.FEMI_NOMSEG);

            /*" -1637- MOVE FEMI-ENDERECO TO TAB-ALFA-GRUPO */
            _.Move(WREG_FENEMIS.FEMI_ENDERECO, TABELA_ALFA.TAB_ALFA_GRUPO);

            /*" -1640- PERFORM R0930-00-ALTERA-CAMPO VARYING INDX FROM 1 BY 1 UNTIL INDX GREATER 40 */

            for (INDX.Value = 1; !(INDX > 40); INDX.Value += 1)
            {

                R0930_00_ALTERA_CAMPO_SECTION();
            }

            /*" -1641- MOVE TAB-ALFA-GRUPO TO FEMI-ENDERECO */
            _.Move(TABELA_ALFA.TAB_ALFA_GRUPO, WREG_FENEMIS.FEMI_ENDERECO);

            /*" -1642- MOVE FEMI-BAIRRO TO TAB-ALFA-GRUPO */
            _.Move(WREG_FENEMIS.FEMI_BAIRRO, TABELA_ALFA.TAB_ALFA_GRUPO);

            /*" -1645- PERFORM R0930-00-ALTERA-CAMPO VARYING INDX FROM 1 BY 1 UNTIL INDX GREATER 40 */

            for (INDX.Value = 1; !(INDX > 40); INDX.Value += 1)
            {

                R0930_00_ALTERA_CAMPO_SECTION();
            }

            /*" -1646- MOVE TAB-ALFA-GRUPO TO FEMI-BAIRRO */
            _.Move(TABELA_ALFA.TAB_ALFA_GRUPO, WREG_FENEMIS.FEMI_BAIRRO);

            /*" -1647- MOVE FEMI-CIDADE TO TAB-ALFA-GRUPO */
            _.Move(WREG_FENEMIS.FEMI_CIDADE, TABELA_ALFA.TAB_ALFA_GRUPO);

            /*" -1650- PERFORM R0930-00-ALTERA-CAMPO VARYING INDX FROM 1 BY 1 UNTIL INDX GREATER 40 */

            for (INDX.Value = 1; !(INDX > 40); INDX.Value += 1)
            {

                R0930_00_ALTERA_CAMPO_SECTION();
            }

            /*" -1652- MOVE TAB-ALFA-GRUPO TO FEMI-CIDADE */
            _.Move(TABELA_ALFA.TAB_ALFA_GRUPO, WREG_FENEMIS.FEMI_CIDADE);

            /*" -1654- WRITE REG-FENEMIS FROM WREG-FENEMIS. */
            _.Move(WREG_FENEMIS.GetMoveValues(), REG_FENEMIS);

            FENEMIS.Write(REG_FENEMIS.GetMoveValues().ToString());

            /*" -1654- ADD +1 TO AC-G-FENEMIS. */
            AREA_DE_WORK.AC_G_FENEMIS.Value = AREA_DE_WORK.AC_G_FENEMIS + +1;

        }

        [StopWatch]
        /*" R1200-00-GRAVA-FENEMIS-DB-SELECT-1 */
        public void R1200_00_GRAVA_FENEMIS_DB_SELECT_1()
        {
            /*" -1526- EXEC SQL SELECT SUM(VLPRMLIQ), SUM(VLPRMTOT) INTO :V1HISP-VLPRMLIQ, :V1HISP-VLPRMTOT FROM SEGUROS.V1HISTOPARC WHERE NUM_APOLICE = :V1HISP-NUMAPOL AND NRENDOS = :V1HISP-NRENDOS AND OPERACAO BETWEEN 100 AND 199 WITH UR END-EXEC. */

            var r1200_00_GRAVA_FENEMIS_DB_SELECT_1_Query1 = new R1200_00_GRAVA_FENEMIS_DB_SELECT_1_Query1()
            {
                V1HISP_NUMAPOL = V1HISP_NUMAPOL.ToString(),
                V1HISP_NRENDOS = V1HISP_NRENDOS.ToString(),
            };

            var executed_1 = R1200_00_GRAVA_FENEMIS_DB_SELECT_1_Query1.Execute(r1200_00_GRAVA_FENEMIS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1HISP_VLPRMLIQ, V1HISP_VLPRMLIQ);
                _.Move(executed_1.V1HISP_VLPRMTOT, V1HISP_VLPRMTOT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/

        [StopWatch]
        /*" R1210-00-SELECT-V1CLIENTE-SECTION */
        private void R1210_00_SELECT_V1CLIENTE_SECTION()
        {
            /*" -1664- MOVE '1210' TO WNR-EXEC-SQL. */
            _.Move("1210", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1674- PERFORM R1210_00_SELECT_V1CLIENTE_DB_SELECT_1 */

            R1210_00_SELECT_V1CLIENTE_DB_SELECT_1();

            /*" -1677- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1678- DISPLAY 'R1210-00 (ERRO NO SELECT V1CLIENTE)' */
                _.Display($"R1210-00 (ERRO NO SELECT V1CLIENTE)");

                /*" -1679- DISPLAY 'APOLICE = ' V1ENDO-NUMAPOL */
                _.Display($"APOLICE = {V1ENDO_NUMAPOL}");

                /*" -1680- DISPLAY 'CLIENTE = ' WHOST-CODCLIEN */
                _.Display($"CLIENTE = {WHOST_CODCLIEN}");

                /*" -1680- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1210-00-SELECT-V1CLIENTE-DB-SELECT-1 */
        public void R1210_00_SELECT_V1CLIENTE_DB_SELECT_1()
        {
            /*" -1674- EXEC SQL SELECT NOME_RAZAO , TIPO_PESSOA , CGCCPF INTO :V1CLIE-NOME , :V1CLIE-TPPESSOA , :V1CLIE-CGCCPF FROM SEGUROS.V1CLIENTE WHERE COD_CLIENTE = :WHOST-CODCLIEN WITH UR END-EXEC. */

            var r1210_00_SELECT_V1CLIENTE_DB_SELECT_1_Query1 = new R1210_00_SELECT_V1CLIENTE_DB_SELECT_1_Query1()
            {
                WHOST_CODCLIEN = WHOST_CODCLIEN.ToString(),
            };

            var executed_1 = R1210_00_SELECT_V1CLIENTE_DB_SELECT_1_Query1.Execute(r1210_00_SELECT_V1CLIENTE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1CLIE_NOME, V1CLIE_NOME);
                _.Move(executed_1.V1CLIE_TPPESSOA, V1CLIE_TPPESSOA);
                _.Move(executed_1.V1CLIE_CGCCPF, V1CLIE_CGCCPF);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1210_99_SAIDA*/

        [StopWatch]
        /*" R1211-00-GRAVA-FENPANA-SECTION */
        private void R1211_00_GRAVA_FENPANA_SECTION()
        {
            /*" -1692- MOVE '1211' TO WNR-EXEC-SQL. */
            _.Move("1211", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1693- MOVE V1ENDO-CODCLIEN TO WHOST-CODCLIEN */
            _.Move(V1ENDO_CODCLIEN, WHOST_CODCLIEN);

            /*" -1695- PERFORM R1210-00-SELECT-V1CLIENTE */

            R1210_00_SELECT_V1CLIENTE_SECTION();

            /*" -1696- MOVE V1ENDO-OCORR-END TO WHOST-CODENDER */
            _.Move(V1ENDO_OCORR_END, WHOST_CODENDER);

            /*" -1698- PERFORM R1220-00-SELECT-V1ENDERECOS */

            R1220_00_SELECT_V1ENDERECOS_SECTION();

            /*" -1699- MOVE V1ENDO-NUMAPOL TO PAEM-NUMAPOL */
            _.Move(V1ENDO_NUMAPOL, WREG_FENPANA.PAEM_NUMAPOL);

            /*" -1700- MOVE V1ENDO-NRENDOS TO PAEM-NRENDOS */
            _.Move(V1ENDO_NRENDOS, WREG_FENPANA.PAEM_NRENDOS);

            /*" -1701- MOVE V1ENDO-CODSUBES TO PAEM-CODSUBES */
            _.Move(V1ENDO_CODSUBES, WREG_FENPANA.PAEM_CODSUBES);

            /*" -1702- MOVE V1ENDO-FONTE TO PAEM-FONTE */
            _.Move(V1ENDO_FONTE, WREG_FENPANA.PAEM_FONTE);

            /*" -1703- MOVE V1ENDO-NRPROPOS TO PAEM-NRPROPOS */
            _.Move(V1ENDO_NRPROPOS, WREG_FENPANA.PAEM_NRPROPOS);

            /*" -1704- MOVE V1ENDO-NUMBIL TO PAEM-NUMBIL */
            _.Move(V1ENDO_NUMBIL, WREG_FENPANA.PAEM_NUMBIL);

            /*" -1705- MOVE V1ENDO-NRRCAP TO PAEM-NUMSICOB */
            _.Move(V1ENDO_NRRCAP, WREG_FENPANA.PAEM_NUMSICOB);

            /*" -1706- MOVE V1ENDO-RAMO TO PAEM-CODRAMO */
            _.Move(V1ENDO_RAMO, WREG_FENPANA.PAEM_CODRAMO);

            /*" -1707- MOVE V1ENDO-CODPRODU TO PAEM-CODPRODU */
            _.Move(V1ENDO_CODPRODU, WREG_FENPANA.PAEM_CODPRODU);

            /*" -1708- MOVE V1ENDO-APOLANT TO PAEM-NUMAPOLANT */
            _.Move(V1ENDO_APOLANT, WREG_FENPANA.PAEM_NUMAPOLANT);

            /*" -1709- MOVE V1ENDO-DTEMIS TO PAEM-DTEMIS */
            _.Move(V1ENDO_DTEMIS, WREG_FENPANA.PAEM_DTEMIS);

            /*" -1710- MOVE V1ENDO-DTINIVIG TO PAEM-DTINIVIG */
            _.Move(V1ENDO_DTINIVIG, WREG_FENPANA.PAEM_DTINIVIG);

            /*" -1711- MOVE V1ENDO-DTTERVIG TO PAEM-DTTERVIG */
            _.Move(V1ENDO_DTTERVIG, WREG_FENPANA.PAEM_DTTERVIG);

            /*" -1712- MOVE V1ENDO-CODCLIEN TO PAEM-CODCLIEN */
            _.Move(V1ENDO_CODCLIEN, WREG_FENPANA.PAEM_CODCLIEN);

            /*" -1713- MOVE V1CLIE-NOME TO PAEM-NOMSEG */
            _.Move(V1CLIE_NOME, WREG_FENPANA.PAEM_NOMSEG);

            /*" -1714- MOVE V1CLIE-TPPESSOA TO PAEM-TIPOPES */
            _.Move(V1CLIE_TPPESSOA, WREG_FENPANA.PAEM_TIPOPES);

            /*" -1715- MOVE V1CLIE-CGCCPF TO PAEM-CPFCGC */
            _.Move(V1CLIE_CGCCPF, WREG_FENPANA.PAEM_CPFCGC);

            /*" -1716- MOVE V1ENDO-OCORR-END TO PAEM-OCORREND */
            _.Move(V1ENDO_OCORR_END, WREG_FENPANA.PAEM_OCORREND);

            /*" -1717- MOVE V1ENDE-ENDERECO TO PAEM-ENDERECO */
            _.Move(V1ENDE_ENDERECO, WREG_FENPANA.PAEM_ENDERECO);

            /*" -1718- MOVE V1ENDE-BAIRRO TO PAEM-BAIRRO */
            _.Move(V1ENDE_BAIRRO, WREG_FENPANA.PAEM_BAIRRO);

            /*" -1719- MOVE V1ENDE-CIDADE TO PAEM-CIDADE */
            _.Move(V1ENDE_CIDADE, WREG_FENPANA.PAEM_CIDADE);

            /*" -1720- MOVE V1ENDE-ESTADO TO PAEM-SIGLA-UF */
            _.Move(V1ENDE_ESTADO, WREG_FENPANA.PAEM_SIGLA_UF);

            /*" -1721- MOVE V1ENDE-CEP TO PAEM-CEP */
            _.Move(V1ENDE_CEP, WREG_FENPANA.PAEM_CEP);

            /*" -1722- MOVE V1ENDE-DDD TO PAEM-DDD */
            _.Move(V1ENDE_DDD, WREG_FENPANA.PAEM_DDD);

            /*" -1723- MOVE V1ENDE-TELEFONE TO PAEM-FONE */
            _.Move(V1ENDE_TELEFONE, WREG_FENPANA.PAEM_FONE);

            /*" -1725- MOVE FEMI-TOMADOR TO PAEM-TOMADOR */
            _.Move(WREG_FENEMIS.FEMI_TOMADOR, WREG_FENPANA.PAEM_TOMADOR);

            /*" -1729- PERFORM R1215-00-SELECT-PROPCONV */

            R1215_00_SELECT_PROPCONV_SECTION();

            /*" -1739- PERFORM R1211_00_GRAVA_FENPANA_DB_SELECT_1 */

            R1211_00_GRAVA_FENPANA_DB_SELECT_1();

            /*" -1742- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1743- DISPLAY 'R1200-00 (ERRO NO SELECT V1ENDOSSO)' */
                _.Display($"R1200-00 (ERRO NO SELECT V1ENDOSSO)");

                /*" -1744- DISPLAY 'APOLICE = ' V1HISP-NUMAPOL */
                _.Display($"APOLICE = {V1HISP_NUMAPOL}");

                /*" -1745- DISPLAY 'ENDOSSO = ' V1HISP-NRENDOS */
                _.Display($"ENDOSSO = {V1HISP_NRENDOS}");

                /*" -1747- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1748- MOVE V1HISP-VLPRMTOT TO PAEM-VLPRMTOT */
            _.Move(V1HISP_VLPRMTOT, WREG_FENPANA.PAEM_VLPRMTOT);

            /*" -1749- MOVE V1HISP-VLPRMLIQ TO PAEM-VLPRMLIQ */
            _.Move(V1HISP_VLPRMLIQ, WREG_FENPANA.PAEM_VLPRMLIQ);

            /*" -1751- MOVE V1ENDO-QTPARCEL TO PAEM-QTPARCEL */
            _.Move(V1ENDO_QTPARCEL, WREG_FENPANA.PAEM_QTPARCEL);

            /*" -1752- IF V1ENDO-RAMO EQUAL 31 OR 53 */

            if (V1ENDO_RAMO.In("31", "53"))
            {

                /*" -1753- MOVE V1ENDO-AGECOBR TO PAEM-CODAGENC */
                _.Move(V1ENDO_AGECOBR, WREG_FENPANA.PAEM_CODAGENC);

                /*" -1754- ELSE */
            }
            else
            {


                /*" -1758- IF V1ENDO-RAMO EQUAL 71 OR V1ENDO-RAMO EQUAL 14 OR V1ENDO-RAMO EQUAL 16 OR V1ENDO-RAMO EQUAL 18 */

                if (V1ENDO_RAMO == 71 || V1ENDO_RAMO == 14 || V1ENDO_RAMO == 16 || V1ENDO_RAMO == 18)
                {

                    /*" -1759- PERFORM R1250-00-AGENCIA-RCAP */

                    R1250_00_AGENCIA_RCAP_SECTION();

                    /*" -1760- IF V0RCAP-AGECOBR EQUAL 0 */

                    if (V0RCAP_AGECOBR == 0)
                    {

                        /*" -1761- MOVE V1ENDO-AGERCAP TO PAEM-CODAGENC */
                        _.Move(V1ENDO_AGERCAP, WREG_FENPANA.PAEM_CODAGENC);

                        /*" -1762- ELSE */
                    }
                    else
                    {


                        /*" -1763- MOVE V0RCAP-AGECOBR TO PAEM-CODAGENC */
                        _.Move(V0RCAP_AGECOBR, WREG_FENPANA.PAEM_CODAGENC);

                        /*" -1764- ELSE */
                    }

                }
                else
                {


                    /*" -1769- MOVE V1ENDO-AGERCAP TO PAEM-CODAGENC. */
                    _.Move(V1ENDO_AGERCAP, WREG_FENPANA.PAEM_CODAGENC);
                }

            }


            /*" -1773- IF V1ENDO-CODPRODU EQUAL 1403 OR = 1404 OR V1ENDO-CODPRODU EQUAL 1601 OR = 1602 OR V1ENDO-CODPRODU EQUAL 1801 OR 1802 OR 1804 */

            if (V1ENDO_CODPRODU.In("1403", "1404") || V1ENDO_CODPRODU.In("1601", "1602") || V1ENDO_CODPRODU.In("1801", "1802", "1804"))
            {

                /*" -1776- MOVE V1ENDO-AGECOBR TO PAEM-CODAGENC. */
                _.Move(V1ENDO_AGECOBR, WREG_FENPANA.PAEM_CODAGENC);
            }


            /*" -1777- IF V1ENDO-RAMO EQUAL 31 */

            if (V1ENDO_RAMO == 31)
            {

                /*" -1778- PERFORM R1230-00-INDICADOR-AUTO */

                R1230_00_INDICADOR_AUTO_SECTION();

                /*" -1779- ELSE */
            }
            else
            {


                /*" -1782- IF V1ENDO-RAMO EQUAL 72 OR V1ENDO-RAMO EQUAL 82 OR V1ENDO-CODPRODU EQUAL 1402 */

                if (V1ENDO_RAMO == 72 || V1ENDO_RAMO == 82 || V1ENDO_CODPRODU == 1402)
                {

                    /*" -1783- PERFORM R1240-00-INDICADOR-BILHETE */

                    R1240_00_INDICADOR_BILHETE_SECTION();

                    /*" -1784- ELSE */
                }
                else
                {


                    /*" -1789- MOVE ZEROS TO WHOST-MATRIC-IND. */
                    _.Move(0, WHOST_MATRIC_IND);
                }

            }


            /*" -1793- IF V1ENDO-CODPRODU EQUAL 1403 OR = 1404 OR V1ENDO-CODPRODU EQUAL 1601 OR = 1602 OR V1ENDO-CODPRODU EQUAL 1801 OR 1802 OR 1804 */

            if (V1ENDO_CODPRODU.In("1403", "1404") || V1ENDO_CODPRODU.In("1601", "1602") || V1ENDO_CODPRODU.In("1801", "1802", "1804"))
            {

                /*" -1796- PERFORM R1230-00-INDICADOR-AUTO. */

                R1230_00_INDICADOR_AUTO_SECTION();
            }


            /*" -1797- MOVE WHOST-MATRIC-IND TO PAEM-MATRIC-IND */
            _.Move(WHOST_MATRIC_IND, WREG_FENPANA.PAEM_MATRIC_IND);

            /*" -1800- MOVE ZEROS TO PAEM-MATRIC-GER PAEM-MATRIC-SUNEG */
            _.Move(0, WREG_FENPANA.PAEM_MATRIC_GER, WREG_FENPANA.PAEM_MATRIC_SUNEG);

            /*" -1801- MOVE V1ENDO-TIPO-ENDO TO PAEM-TIPOENDO */
            _.Move(V1ENDO_TIPO_ENDO, WREG_FENPANA.PAEM_TIPOENDO);

            /*" -1802- MOVE V1ENDO-SITUACAO TO PAEM-SITUACAO */
            _.Move(V1ENDO_SITUACAO, WREG_FENPANA.PAEM_SITUACAO);

            /*" -1803- MOVE V1ENDO-MOEDA-IMP TO PAEM-CODMOEDA-IMP */
            _.Move(V1ENDO_MOEDA_IMP, WREG_FENPANA.PAEM_CODMOEDA_IMP);

            /*" -1804- MOVE V1ENDO-MOEDA-PRM TO PAEM-CODMOEDA-PRM */
            _.Move(V1ENDO_MOEDA_PRM, WREG_FENPANA.PAEM_CODMOEDA_PRM);

            /*" -1806- MOVE V1ENDO-RAMO TO PAEM-LAYOUT */
            _.Move(V1ENDO_RAMO, WREG_FENPANA.PAEM_LAYOUT);

            /*" -1808- IF V1ENDO-NRENDOS GREATER ZEROS */

            if (V1ENDO_NRENDOS > 00)
            {

                /*" -1810- PERFORM R1253-00-BUSCA-ENDO-NRRCAP */

                R1253_00_BUSCA_ENDO_NRRCAP_SECTION();

                /*" -1812- MOVE V0ENDO-NRRCAP TO WHOST-NRRCAP */
                _.Move(V0ENDO_NRRCAP, WHOST_NRRCAP);

                /*" -1814- PERFORM R1251-00-BUSCA-NCERTIFICADO */

                R1251_00_BUSCA_NCERTIFICADO_SECTION();

                /*" -1815- IF SQLCODE EQUAL ZEROS */

                if (DB.SQLCODE == 00)
                {

                    /*" -1816- PERFORM R1252-00-SELECT-PROPOFID */

                    R1252_00_SELECT_PROPOFID_SECTION();

                    /*" -1817- IF SQLCODE EQUAL ZEROS */

                    if (DB.SQLCODE == 00)
                    {

                        /*" -1818- MOVE V0RCAP-NRCERTIF TO PAEM-PROPOSTA-SIVPF */
                        _.Move(V0RCAP_NRCERTIF, WREG_FENPANA.PAEM_PROPOSTA_SIVPF);

                        /*" -1819- ELSE */
                    }
                    else
                    {


                        /*" -1820- MOVE ZEROS TO FEMI-PROPOSTA-SIVPF */
                        _.Move(0, WREG_FENEMIS.FEMI_PROPOSTA_SIVPF);

                        /*" -1821- ELSE */
                    }

                }
                else
                {


                    /*" -1822- MOVE ZEROS TO FEMI-PROPOSTA-SIVPF */
                    _.Move(0, WREG_FENEMIS.FEMI_PROPOSTA_SIVPF);

                    /*" -1823- ELSE */
                }

            }
            else
            {


                /*" -1824- MOVE V1ENDO-NRRCAP TO WHOST-NRRCAP */
                _.Move(V1ENDO_NRRCAP, WHOST_NRRCAP);

                /*" -1825- PERFORM R1251-00-BUSCA-NCERTIFICADO */

                R1251_00_BUSCA_NCERTIFICADO_SECTION();

                /*" -1826- IF SQLCODE EQUAL ZEROS */

                if (DB.SQLCODE == 00)
                {

                    /*" -1827- PERFORM R1252-00-SELECT-PROPOFID */

                    R1252_00_SELECT_PROPOFID_SECTION();

                    /*" -1828- IF SQLCODE EQUAL ZEROS */

                    if (DB.SQLCODE == 00)
                    {

                        /*" -1829- MOVE V0RCAP-NRCERTIF TO PAEM-PROPOSTA-SIVPF */
                        _.Move(V0RCAP_NRCERTIF, WREG_FENPANA.PAEM_PROPOSTA_SIVPF);

                        /*" -1830- ELSE */
                    }
                    else
                    {


                        /*" -1831- MOVE ZEROS TO PAEM-PROPOSTA-SIVPF */
                        _.Move(0, WREG_FENPANA.PAEM_PROPOSTA_SIVPF);

                        /*" -1832- ELSE */
                    }

                }
                else
                {


                    /*" -1834- MOVE ZEROS TO PAEM-PROPOSTA-SIVPF. */
                    _.Move(0, WREG_FENPANA.PAEM_PROPOSTA_SIVPF);
                }

            }


            /*" -1836- MOVE WHOST-PROPOSTA-VC TO PAEM-PROPOSTA-SIVPF */
            _.Move(WHOST_PROPOSTA_VC, WREG_FENPANA.PAEM_PROPOSTA_SIVPF);

            /*" -1837- MOVE FEMI-NOMSEG TO TAB-ALFA-GRUPO */
            _.Move(WREG_FENEMIS.FEMI_NOMSEG, TABELA_ALFA.TAB_ALFA_GRUPO);

            /*" -1840- PERFORM R0930-00-ALTERA-CAMPO VARYING INDX FROM 1 BY 1 UNTIL INDX GREATER 40 */

            for (INDX.Value = 1; !(INDX > 40); INDX.Value += 1)
            {

                R0930_00_ALTERA_CAMPO_SECTION();
            }

            /*" -1841- MOVE TAB-ALFA-GRUPO TO PAEM-NOMSEG */
            _.Move(TABELA_ALFA.TAB_ALFA_GRUPO, WREG_FENPANA.PAEM_NOMSEG);

            /*" -1842- MOVE PAEM-ENDERECO TO TAB-ALFA-GRUPO */
            _.Move(WREG_FENPANA.PAEM_ENDERECO, TABELA_ALFA.TAB_ALFA_GRUPO);

            /*" -1845- PERFORM R0930-00-ALTERA-CAMPO VARYING INDX FROM 1 BY 1 UNTIL INDX GREATER 40 */

            for (INDX.Value = 1; !(INDX > 40); INDX.Value += 1)
            {

                R0930_00_ALTERA_CAMPO_SECTION();
            }

            /*" -1846- MOVE TAB-ALFA-GRUPO TO PAEM-ENDERECO */
            _.Move(TABELA_ALFA.TAB_ALFA_GRUPO, WREG_FENPANA.PAEM_ENDERECO);

            /*" -1847- MOVE PAEM-BAIRRO TO TAB-ALFA-GRUPO */
            _.Move(WREG_FENPANA.PAEM_BAIRRO, TABELA_ALFA.TAB_ALFA_GRUPO);

            /*" -1850- PERFORM R0930-00-ALTERA-CAMPO VARYING INDX FROM 1 BY 1 UNTIL INDX GREATER 40 */

            for (INDX.Value = 1; !(INDX > 40); INDX.Value += 1)
            {

                R0930_00_ALTERA_CAMPO_SECTION();
            }

            /*" -1851- MOVE TAB-ALFA-GRUPO TO PAEM-BAIRRO */
            _.Move(TABELA_ALFA.TAB_ALFA_GRUPO, WREG_FENPANA.PAEM_BAIRRO);

            /*" -1852- MOVE PAEM-CIDADE TO TAB-ALFA-GRUPO */
            _.Move(WREG_FENPANA.PAEM_CIDADE, TABELA_ALFA.TAB_ALFA_GRUPO);

            /*" -1855- PERFORM R0930-00-ALTERA-CAMPO VARYING INDX FROM 1 BY 1 UNTIL INDX GREATER 40 */

            for (INDX.Value = 1; !(INDX > 40); INDX.Value += 1)
            {

                R0930_00_ALTERA_CAMPO_SECTION();
            }

            /*" -1857- MOVE TAB-ALFA-GRUPO TO PAEM-CIDADE */
            _.Move(TABELA_ALFA.TAB_ALFA_GRUPO, WREG_FENPANA.PAEM_CIDADE);

            /*" -1859- WRITE REG-FENPANA FROM WREG-FENPANA. */
            _.Move(WREG_FENPANA.GetMoveValues(), REG_FENPANA);

            FENPANA.Write(REG_FENPANA.GetMoveValues().ToString());

            /*" -1859- ADD +1 TO AC-G-FENPANA. */
            AREA_DE_WORK.AC_G_FENPANA.Value = AREA_DE_WORK.AC_G_FENPANA + +1;

        }

        [StopWatch]
        /*" R1211-00-GRAVA-FENPANA-DB-SELECT-1 */
        public void R1211_00_GRAVA_FENPANA_DB_SELECT_1()
        {
            /*" -1739- EXEC SQL SELECT SUM(VLPRMLIQ), SUM(VLPRMTOT) INTO :V1HISP-VLPRMLIQ, :V1HISP-VLPRMTOT FROM SEGUROS.V1HISTOPARC WHERE NUM_APOLICE = :V1HISP-NUMAPOL AND NRENDOS = :V1HISP-NRENDOS AND OPERACAO BETWEEN 100 AND 199 WITH UR END-EXEC. */

            var r1211_00_GRAVA_FENPANA_DB_SELECT_1_Query1 = new R1211_00_GRAVA_FENPANA_DB_SELECT_1_Query1()
            {
                V1HISP_NUMAPOL = V1HISP_NUMAPOL.ToString(),
                V1HISP_NRENDOS = V1HISP_NRENDOS.ToString(),
            };

            var executed_1 = R1211_00_GRAVA_FENPANA_DB_SELECT_1_Query1.Execute(r1211_00_GRAVA_FENPANA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1HISP_VLPRMLIQ, V1HISP_VLPRMLIQ);
                _.Move(executed_1.V1HISP_VLPRMTOT, V1HISP_VLPRMTOT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1211_99_SAIDA*/

        [StopWatch]
        /*" R1215-00-SELECT-PROPCONV-SECTION */
        private void R1215_00_SELECT_PROPCONV_SECTION()
        {
            /*" -1869- MOVE '1215' TO WNR-EXEC-SQL. */
            _.Move("1215", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1871- MOVE ZEROS TO WHOST-PROPOSTA-VC */
            _.Move(0, WHOST_PROPOSTA_VC);

            /*" -1882- PERFORM R1215_00_SELECT_PROPCONV_DB_SELECT_1 */

            R1215_00_SELECT_PROPCONV_DB_SELECT_1();

            /*" -1885- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1887- DISPLAY 'R1215-00 (ERRO NO SELECT AU_PROP_CONV_VC' 'APOLICE = ' V1ENDO-NUMAPOL */

                $"R1215-00 (ERRO NO SELECT AU_PROP_CONV_VCAPOLICE = {V1ENDO_NUMAPOL}"
                .Display();

                /*" -1887- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1215-00-SELECT-PROPCONV-DB-SELECT-1 */
        public void R1215_00_SELECT_PROPCONV_DB_SELECT_1()
        {
            /*" -1882- EXEC SQL SELECT NUM_PROPOSTA_VC INTO :WHOST-PROPOSTA-VC FROM SEGUROS.AU_PROP_CONV_VC A WHERE A.NUM_APOLICE = :V1ENDO-NUMAPOL AND A.DTH_INI_VIGENCIA = ( SELECT MAX (B.DTH_INI_VIGENCIA) FROM SEGUROS.AU_PROP_CONV_VC B WHERE B.NUM_APOLICE = A.NUM_APOLICE ) WITH UR END-EXEC. */

            var r1215_00_SELECT_PROPCONV_DB_SELECT_1_Query1 = new R1215_00_SELECT_PROPCONV_DB_SELECT_1_Query1()
            {
                V1ENDO_NUMAPOL = V1ENDO_NUMAPOL.ToString(),
            };

            var executed_1 = R1215_00_SELECT_PROPCONV_DB_SELECT_1_Query1.Execute(r1215_00_SELECT_PROPCONV_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_PROPOSTA_VC, WHOST_PROPOSTA_VC);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1215_99_SAIDA*/

        [StopWatch]
        /*" R1220-00-SELECT-V1ENDERECOS-SECTION */
        private void R1220_00_SELECT_V1ENDERECOS_SECTION()
        {
            /*" -1897- MOVE '1220' TO WNR-EXEC-SQL. */
            _.Move("1220", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -0- FLUXCONTROL_PERFORM R1220_10_LEITURA */

            R1220_10_LEITURA();

        }

        [StopWatch]
        /*" R1220-10-LEITURA */
        private void R1220_10_LEITURA(bool isPerform = false)
        {
            /*" -1920- PERFORM R1220_10_LEITURA_DB_SELECT_1 */

            R1220_10_LEITURA_DB_SELECT_1();

            /*" -1923- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1924- IF WHOST-CODENDER EQUAL 2 */

                if (WHOST_CODENDER == 2)
                {

                    /*" -1925- MOVE 1 TO WHOST-CODENDER */
                    _.Move(1, WHOST_CODENDER);

                    /*" -1926- GO TO R1220-10-LEITURA */
                    new Task(() => R1220_10_LEITURA()).RunSynchronously(); //GOTO
                    return;//Recursividade detectada, cuidado...

                    /*" -1927- ELSE */
                }
                else
                {


                    /*" -1931- MOVE SPACES TO V1ENDE-ENDERECO V1ENDE-CIDADE V1ENDE-BAIRRO V1ENDE-ESTADO */
                    _.Move("", V1ENDE_ENDERECO, V1ENDE_CIDADE, V1ENDE_BAIRRO, V1ENDE_ESTADO);

                    /*" -1934- MOVE ZEROS TO V1ENDE-CEP V1ENDE-DDD V1ENDE-TELEFONE */
                    _.Move(0, V1ENDE_CEP, V1ENDE_DDD, V1ENDE_TELEFONE);

                    /*" -1935- DISPLAY 'R1220-00 (ENDERECO NAO LOCALIZADO)' */
                    _.Display($"R1220-00 (ENDERECO NAO LOCALIZADO)");

                    /*" -1936- DISPLAY 'APOLICE = ' V1ENDO-NUMAPOL */
                    _.Display($"APOLICE = {V1ENDO_NUMAPOL}");

                    /*" -1937- DISPLAY 'ENDOSSO = ' V1ENDO-NRENDOS */
                    _.Display($"ENDOSSO = {V1ENDO_NRENDOS}");

                    /*" -1938- DISPLAY 'CLIENTE = ' WHOST-CODCLIEN */
                    _.Display($"CLIENTE = {WHOST_CODCLIEN}");

                    /*" -1938- DISPLAY 'ENDERECO= ' WHOST-CODENDER. */
                    _.Display($"ENDERECO= {WHOST_CODENDER}");
                }

            }


        }

        [StopWatch]
        /*" R1220-10-LEITURA-DB-SELECT-1 */
        public void R1220_10_LEITURA_DB_SELECT_1()
        {
            /*" -1920- EXEC SQL SELECT ENDERECO , CIDADE , BAIRRO , CEP , SIGLA_UF , DDD , TELEFONE INTO :V1ENDE-ENDERECO , :V1ENDE-CIDADE, :V1ENDE-BAIRRO, :V1ENDE-CEP , :V1ENDE-ESTADO , :V1ENDE-DDD, :V1ENDE-TELEFONE FROM SEGUROS.V1ENDERECOS WHERE COD_CLIENTE = :WHOST-CODCLIEN AND OCORR_ENDERECO = :WHOST-CODENDER WITH UR END-EXEC. */

            var r1220_10_LEITURA_DB_SELECT_1_Query1 = new R1220_10_LEITURA_DB_SELECT_1_Query1()
            {
                WHOST_CODCLIEN = WHOST_CODCLIEN.ToString(),
                WHOST_CODENDER = WHOST_CODENDER.ToString(),
            };

            var executed_1 = R1220_10_LEITURA_DB_SELECT_1_Query1.Execute(r1220_10_LEITURA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1ENDE_ENDERECO, V1ENDE_ENDERECO);
                _.Move(executed_1.V1ENDE_CIDADE, V1ENDE_CIDADE);
                _.Move(executed_1.V1ENDE_BAIRRO, V1ENDE_BAIRRO);
                _.Move(executed_1.V1ENDE_CEP, V1ENDE_CEP);
                _.Move(executed_1.V1ENDE_ESTADO, V1ENDE_ESTADO);
                _.Move(executed_1.V1ENDE_DDD, V1ENDE_DDD);
                _.Move(executed_1.V1ENDE_TELEFONE, V1ENDE_TELEFONE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1220_99_SAIDA*/

        [StopWatch]
        /*" R1230-00-INDICADOR-AUTO-SECTION */
        private void R1230_00_INDICADOR_AUTO_SECTION()
        {
            /*" -1948- MOVE '1230' TO WNR-EXEC-SQL. */
            _.Move("1230", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1955- PERFORM R1230_00_INDICADOR_AUTO_DB_SELECT_1 */

            R1230_00_INDICADOR_AUTO_DB_SELECT_1();

            /*" -1958- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1959- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1960- MOVE ZEROS TO WHOST-MATRIC-IND */
                    _.Move(0, WHOST_MATRIC_IND);

                    /*" -1961- ELSE */
                }
                else
                {


                    /*" -1962- DISPLAY 'R1230-00 (ERRO NO SELECT V1APOLCOB)' */
                    _.Display($"R1230-00 (ERRO NO SELECT V1APOLCOB)");

                    /*" -1963- DISPLAY 'APOLICE = ' V1ENDO-NUMAPOL */
                    _.Display($"APOLICE = {V1ENDO_NUMAPOL}");

                    /*" -1964- DISPLAY 'ENDOSSO = ' V1ENDO-NRENDOS */
                    _.Display($"ENDOSSO = {V1ENDO_NRENDOS}");

                    /*" -1964- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R1230-00-INDICADOR-AUTO-DB-SELECT-1 */
        public void R1230_00_INDICADOR_AUTO_DB_SELECT_1()
        {
            /*" -1955- EXEC SQL SELECT NUM_MATRICULA INTO :WHOST-MATRIC-IND FROM SEGUROS.V1APOLCOB WHERE NUM_APOLICE = :V1ENDO-NUMAPOL AND NRENDOS = :V1ENDO-NRENDOS WITH UR END-EXEC. */

            var r1230_00_INDICADOR_AUTO_DB_SELECT_1_Query1 = new R1230_00_INDICADOR_AUTO_DB_SELECT_1_Query1()
            {
                V1ENDO_NUMAPOL = V1ENDO_NUMAPOL.ToString(),
                V1ENDO_NRENDOS = V1ENDO_NRENDOS.ToString(),
            };

            var executed_1 = R1230_00_INDICADOR_AUTO_DB_SELECT_1_Query1.Execute(r1230_00_INDICADOR_AUTO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_MATRIC_IND, WHOST_MATRIC_IND);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1230_99_SAIDA*/

        [StopWatch]
        /*" R1240-00-INDICADOR-BILHETE-SECTION */
        private void R1240_00_INDICADOR_BILHETE_SECTION()
        {
            /*" -1974- MOVE '1240' TO WNR-EXEC-SQL. */
            _.Move("1240", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1980- PERFORM R1240_00_INDICADOR_BILHETE_DB_SELECT_1 */

            R1240_00_INDICADOR_BILHETE_DB_SELECT_1();

            /*" -1983- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1984- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1985- MOVE ZEROS TO WHOST-MATRIC-IND */
                    _.Move(0, WHOST_MATRIC_IND);

                    /*" -1986- ELSE */
                }
                else
                {


                    /*" -1987- DISPLAY 'R1240-00 (ERRO NO SELECT V0BILHETE)' */
                    _.Display($"R1240-00 (ERRO NO SELECT V0BILHETE)");

                    /*" -1988- DISPLAY 'APOLICE = ' V1ENDO-NUMAPOL */
                    _.Display($"APOLICE = {V1ENDO_NUMAPOL}");

                    /*" -1988- MOVE ZEROS TO WHOST-MATRIC-IND. */
                    _.Move(0, WHOST_MATRIC_IND);
                }

            }


        }

        [StopWatch]
        /*" R1240-00-INDICADOR-BILHETE-DB-SELECT-1 */
        public void R1240_00_INDICADOR_BILHETE_DB_SELECT_1()
        {
            /*" -1980- EXEC SQL SELECT NUM_MATRICULA INTO :WHOST-MATRIC-IND FROM SEGUROS.V0BILHETE WHERE NUM_APOLICE = :V1ENDO-NUMAPOL WITH UR END-EXEC. */

            var r1240_00_INDICADOR_BILHETE_DB_SELECT_1_Query1 = new R1240_00_INDICADOR_BILHETE_DB_SELECT_1_Query1()
            {
                V1ENDO_NUMAPOL = V1ENDO_NUMAPOL.ToString(),
            };

            var executed_1 = R1240_00_INDICADOR_BILHETE_DB_SELECT_1_Query1.Execute(r1240_00_INDICADOR_BILHETE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_MATRIC_IND, WHOST_MATRIC_IND);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1240_99_SAIDA*/

        [StopWatch]
        /*" R1250-00-AGENCIA-RCAP-SECTION */
        private void R1250_00_AGENCIA_RCAP_SECTION()
        {
            /*" -2003- MOVE '1250' TO WNR-EXEC-SQL. */
            _.Move("1250", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2004- IF V1ENDO-NRRCAP EQUAL ZEROS */

            if (V1ENDO_NRRCAP == 00)
            {

                /*" -2005- MOVE ZEROS TO V0RCAP-AGECOBR */
                _.Move(0, V0RCAP_AGECOBR);

                /*" -2007- GO TO R1250-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1250_99_SAIDA*/ //GOTO
                return;
            }


            /*" -2013- PERFORM R1250_00_AGENCIA_RCAP_DB_SELECT_1 */

            R1250_00_AGENCIA_RCAP_DB_SELECT_1();

            /*" -2016- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2017- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2018- MOVE ZEROS TO V0RCAP-AGECOBR */
                    _.Move(0, V0RCAP_AGECOBR);

                    /*" -2019- ELSE */
                }
                else
                {


                    /*" -2020- DISPLAY 'R1250-00 (ERRO NO SELECT V0RCAP)' */
                    _.Display($"R1250-00 (ERRO NO SELECT V0RCAP)");

                    /*" -2021- DISPLAY 'APOLICE = ' V1ENDO-NUMAPOL */
                    _.Display($"APOLICE = {V1ENDO_NUMAPOL}");

                    /*" -2021- MOVE ZEROS TO WHOST-MATRIC-IND. */
                    _.Move(0, WHOST_MATRIC_IND);
                }

            }


        }

        [StopWatch]
        /*" R1250-00-AGENCIA-RCAP-DB-SELECT-1 */
        public void R1250_00_AGENCIA_RCAP_DB_SELECT_1()
        {
            /*" -2013- EXEC SQL SELECT AGECOBR INTO :V0RCAP-AGECOBR FROM SEGUROS.V0RCAP WHERE NRRCAP = :V1ENDO-NRRCAP WITH UR END-EXEC. */

            var r1250_00_AGENCIA_RCAP_DB_SELECT_1_Query1 = new R1250_00_AGENCIA_RCAP_DB_SELECT_1_Query1()
            {
                V1ENDO_NRRCAP = V1ENDO_NRRCAP.ToString(),
            };

            var executed_1 = R1250_00_AGENCIA_RCAP_DB_SELECT_1_Query1.Execute(r1250_00_AGENCIA_RCAP_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0RCAP_AGECOBR, V0RCAP_AGECOBR);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1250_99_SAIDA*/

        [StopWatch]
        /*" R1251-00-BUSCA-NCERTIFICADO-SECTION */
        private void R1251_00_BUSCA_NCERTIFICADO_SECTION()
        {
            /*" -2035- MOVE '1251' TO WNR-EXEC-SQL. */
            _.Move("1251", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2041- PERFORM R1251_00_BUSCA_NCERTIFICADO_DB_SELECT_1 */

            R1251_00_BUSCA_NCERTIFICADO_DB_SELECT_1();

        }

        [StopWatch]
        /*" R1251-00-BUSCA-NCERTIFICADO-DB-SELECT-1 */
        public void R1251_00_BUSCA_NCERTIFICADO_DB_SELECT_1()
        {
            /*" -2041- EXEC SQL SELECT NRCERTIF INTO :V0RCAP-NRCERTIF FROM SEGUROS.V0RCAP WHERE NRRCAP = :WHOST-NRRCAP WITH UR END-EXEC. */

            var r1251_00_BUSCA_NCERTIFICADO_DB_SELECT_1_Query1 = new R1251_00_BUSCA_NCERTIFICADO_DB_SELECT_1_Query1()
            {
                WHOST_NRRCAP = WHOST_NRRCAP.ToString(),
            };

            var executed_1 = R1251_00_BUSCA_NCERTIFICADO_DB_SELECT_1_Query1.Execute(r1251_00_BUSCA_NCERTIFICADO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0RCAP_NRCERTIF, V0RCAP_NRCERTIF);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1251_99_SAIDA*/

        [StopWatch]
        /*" R1252-00-SELECT-PROPOFID-SECTION */
        private void R1252_00_SELECT_PROPOFID_SECTION()
        {
            /*" -2054- MOVE '1252' TO WNR-EXEC-SQL. */
            _.Move("1252", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2060- PERFORM R1252_00_SELECT_PROPOFID_DB_SELECT_1 */

            R1252_00_SELECT_PROPOFID_DB_SELECT_1();

        }

        [StopWatch]
        /*" R1252-00-SELECT-PROPOFID-DB-SELECT-1 */
        public void R1252_00_SELECT_PROPOFID_DB_SELECT_1()
        {
            /*" -2060- EXEC SQL SELECT NUM_IDENTIFICACAO INTO :PROPOFID-NUM-IDENTIFICACAO FROM SEGUROS.PROPOSTA_FIDELIZ WHERE NUM_PROPOSTA_SIVPF = :V0RCAP-NRCERTIF WITH UR END-EXEC. */

            var r1252_00_SELECT_PROPOFID_DB_SELECT_1_Query1 = new R1252_00_SELECT_PROPOFID_DB_SELECT_1_Query1()
            {
                V0RCAP_NRCERTIF = V0RCAP_NRCERTIF.ToString(),
            };

            var executed_1 = R1252_00_SELECT_PROPOFID_DB_SELECT_1_Query1.Execute(r1252_00_SELECT_PROPOFID_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PROPOFID_NUM_IDENTIFICACAO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_IDENTIFICACAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1252_99_SAIDA*/

        [StopWatch]
        /*" R1253-00-BUSCA-ENDO-NRRCAP-SECTION */
        private void R1253_00_BUSCA_ENDO_NRRCAP_SECTION()
        {
            /*" -2074- MOVE '1253' TO WNR-EXEC-SQL. */
            _.Move("1253", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2081- PERFORM R1253_00_BUSCA_ENDO_NRRCAP_DB_SELECT_1 */

            R1253_00_BUSCA_ENDO_NRRCAP_DB_SELECT_1();

            /*" -2084- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2085- IF SQLCODE EQUAL +100 */

                if (DB.SQLCODE == +100)
                {

                    /*" -2086- MOVE ZEROS TO V0ENDO-NRRCAP */
                    _.Move(0, V0ENDO_NRRCAP);

                    /*" -2087- ELSE */
                }
                else
                {


                    /*" -2088- DISPLAY 'R1260-00 (ERRO NO SELECT ENDOSSOS)' */
                    _.Display($"R1260-00 (ERRO NO SELECT ENDOSSOS)");

                    /*" -2089- DISPLAY 'NUM_APOLICE   ' V1ENDO-NUMAPOL */
                    _.Display($"NUM_APOLICE   {V1ENDO_NUMAPOL}");

                    /*" -2089- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R1253-00-BUSCA-ENDO-NRRCAP-DB-SELECT-1 */
        public void R1253_00_BUSCA_ENDO_NRRCAP_DB_SELECT_1()
        {
            /*" -2081- EXEC SQL SELECT NRRCAP INTO :V0ENDO-NRRCAP FROM SEGUROS.V0ENDOSSO WHERE NUM_APOLICE = :V1ENDO-NUMAPOL AND NRENDOS = 0 WITH UR END-EXEC */

            var r1253_00_BUSCA_ENDO_NRRCAP_DB_SELECT_1_Query1 = new R1253_00_BUSCA_ENDO_NRRCAP_DB_SELECT_1_Query1()
            {
                V1ENDO_NUMAPOL = V1ENDO_NUMAPOL.ToString(),
            };

            var executed_1 = R1253_00_BUSCA_ENDO_NRRCAP_DB_SELECT_1_Query1.Execute(r1253_00_BUSCA_ENDO_NRRCAP_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0ENDO_NRRCAP, V0ENDO_NRRCAP);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1253_99_SAIDA*/

        [StopWatch]
        /*" R1260-00-LE-PROPOSTA-CONV-AUTO-SECTION */
        private void R1260_00_LE_PROPOSTA_CONV_AUTO_SECTION()
        {
            /*" -2104- MOVE '1260' TO WNR-EXEC-SQL. */
            _.Move("1260", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2116- PERFORM R1260_00_LE_PROPOSTA_CONV_AUTO_DB_SELECT_1 */

            R1260_00_LE_PROPOSTA_CONV_AUTO_DB_SELECT_1();

            /*" -2119- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2120- DISPLAY 'R1260-00 (ERRO NO SELECT APOLICE_AUTO)' */
                _.Display($"R1260-00 (ERRO NO SELECT APOLICE_AUTO)");

                /*" -2121- DISPLAY 'NUM_APOLICE   ' V1ENDO-NUMAPOL */
                _.Display($"NUM_APOLICE   {V1ENDO_NUMAPOL}");

                /*" -2121- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1260-00-LE-PROPOSTA-CONV-AUTO-DB-SELECT-1 */
        public void R1260_00_LE_PROPOSTA_CONV_AUTO_DB_SELECT_1()
        {
            /*" -2116- EXEC SQL SELECT T1.NUM_PROPOSTA_CONV INTO :APOLIAUT-NUM-PROPOSTA-CONV FROM SEGUROS.APOLICE_AUTO T1 WHERE T1.NUM_APOLICE = :V1ENDO-NUMAPOL AND T1.NUM_ENDOSSO = 0 AND T1.NUM_ITEM = (SELECT MAX(T2.NUM_ITEM) FROM SEGUROS.APOLICE_AUTO T2 WHERE T2.NUM_APOLICE = T1.NUM_APOLICE AND T2.NUM_ENDOSSO = T1.NUM_ENDOSSO) WITH UR END-EXEC. */

            var r1260_00_LE_PROPOSTA_CONV_AUTO_DB_SELECT_1_Query1 = new R1260_00_LE_PROPOSTA_CONV_AUTO_DB_SELECT_1_Query1()
            {
                V1ENDO_NUMAPOL = V1ENDO_NUMAPOL.ToString(),
            };

            var executed_1 = R1260_00_LE_PROPOSTA_CONV_AUTO_DB_SELECT_1_Query1.Execute(r1260_00_LE_PROPOSTA_CONV_AUTO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.APOLIAUT_NUM_PROPOSTA_CONV, APOLIAUT.DCLAPOLICE_AUTO.APOLIAUT_NUM_PROPOSTA_CONV);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1260_99_SAIDA*/

        [StopWatch]
        /*" R1300-00-GRAVA-FENPARC-SECTION */
        private void R1300_00_GRAVA_FENPARC_SECTION()
        {
            /*" -2132- MOVE '1300' TO WNR-EXEC-SQL. */
            _.Move("1300", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2139- PERFORM R1300_00_GRAVA_FENPARC_DB_SELECT_1 */

            R1300_00_GRAVA_FENPARC_DB_SELECT_1();

            /*" -2142- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2143- DISPLAY 'R1300-00 (ERRO NO SELECT MAX DA PARCELA)' */
                _.Display($"R1300-00 (ERRO NO SELECT MAX DA PARCELA)");

                /*" -2144- DISPLAY 'NUM_APOLICE   ' V1ENDO-NUMAPOL */
                _.Display($"NUM_APOLICE   {V1ENDO_NUMAPOL}");

                /*" -2145- DISPLAY 'ENDOSSO       ' V1ENDO-NRENDOS */
                _.Display($"ENDOSSO       {V1ENDO_NRENDOS}");

                /*" -2149- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2150- IF V1ENDO-QTPARCEL EQUAL ZEROS */

            if (V1ENDO_QTPARCEL == 00)
            {

                /*" -2151- MOVE +0 TO AC-PARC */
                _.Move(+0, AC_PARC);

                /*" -2152- ELSE */
            }
            else
            {


                /*" -2152- MOVE +1 TO AC-PARC. */
                _.Move(+1, AC_PARC);
            }


            /*" -0- FLUXCONTROL_PERFORM R1300_10_PARCELA */

            R1300_10_PARCELA();

        }

        [StopWatch]
        /*" R1300-00-GRAVA-FENPARC-DB-SELECT-1 */
        public void R1300_00_GRAVA_FENPARC_DB_SELECT_1()
        {
            /*" -2139- EXEC SQL SELECT VALUE(MAX(NRPARCEL),0) INTO :V1ENDO-QTPARCEL FROM SEGUROS.V1PARCELA WHERE NUM_APOLICE = :V1ENDO-NUMAPOL AND NRENDOS = :V1ENDO-NRENDOS WITH UR END-EXEC. */

            var r1300_00_GRAVA_FENPARC_DB_SELECT_1_Query1 = new R1300_00_GRAVA_FENPARC_DB_SELECT_1_Query1()
            {
                V1ENDO_NUMAPOL = V1ENDO_NUMAPOL.ToString(),
                V1ENDO_NRENDOS = V1ENDO_NRENDOS.ToString(),
            };

            var executed_1 = R1300_00_GRAVA_FENPARC_DB_SELECT_1_Query1.Execute(r1300_00_GRAVA_FENPARC_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1ENDO_QTPARCEL, V1ENDO_QTPARCEL);
            }


        }

        [StopWatch]
        /*" R1300-10-PARCELA */
        private void R1300_10_PARCELA(bool isPerform = false)
        {
            /*" -2157- IF AC-PARC GREATER V1ENDO-QTPARCEL */

            if (AC_PARC > V1ENDO_QTPARCEL)
            {

                /*" -2159- GO TO R1300-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1300_99_SAIDA*/ //GOTO
                return;
            }


            /*" -2160- IF AC-PARC GREATER 1 */

            if (AC_PARC > 1)
            {

                /*" -2161- PERFORM R1311-00-DEMAIS-PARCELAS */

                R1311_00_DEMAIS_PARCELAS_SECTION();

                /*" -2162- ELSE */
            }
            else
            {


                /*" -2164- PERFORM R1310-00-PRIMEIRA-PARCELA. */

                R1310_00_PRIMEIRA_PARCELA_SECTION();
            }


            /*" -2166- MOVE '1300' TO WNR-EXEC-SQL. */
            _.Move("1300", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2167- MOVE V1PARC-NUMAPOL TO FPAR-NUMAPOL */
            _.Move(V1PARC_NUMAPOL, WREG_FENPARC.FPAR_NUMAPOL);

            /*" -2168- MOVE V1PARC-NRENDOS TO FPAR-NRENDOS */
            _.Move(V1PARC_NRENDOS, WREG_FENPARC.FPAR_NRENDOS);

            /*" -2169- MOVE V1PARC-NRPARCEL TO FPAR-NRPARCEL */
            _.Move(V1PARC_NRPARCEL, WREG_FENPARC.FPAR_NRPARCEL);

            /*" -2170- MOVE V1PARC-NRTIT TO FPAR-NRTIT */
            _.Move(V1PARC_NRTIT, WREG_FENPARC.FPAR_NRTIT);

            /*" -2171- MOVE V1PARC-VLPRMLIQ TO FPAR-VLPRMLIQ */
            _.Move(V1PARC_VLPRMLIQ, WREG_FENPARC.FPAR_VLPRMLIQ);

            /*" -2172- MOVE V1PARC-QTDOCORR TO FPAR-QTDOCORR */
            _.Move(V1PARC_QTDOCORR, WREG_FENPARC.FPAR_QTDOCORR);

            /*" -2173- MOVE V1HISP-DTVENCTO TO FPAR-DTVENCTO */
            _.Move(V1HISP_DTVENCTO, WREG_FENPARC.FPAR_DTVENCTO);

            /*" -2175- MOVE V1PARC-SITUACAO TO FPAR-SITUACAO */
            _.Move(V1PARC_SITUACAO, WREG_FENPARC.FPAR_SITUACAO);

            /*" -2177- WRITE REG-FENPARC FROM WREG-FENPARC. */
            _.Move(WREG_FENPARC.GetMoveValues(), REG_FENPARC);

            FENPARC.Write(REG_FENPARC.GetMoveValues().ToString());

            /*" -2179- ADD +1 TO AC-G-FENPARC */
            AREA_DE_WORK.AC_G_FENPARC.Value = AREA_DE_WORK.AC_G_FENPARC + +1;

            /*" -2181- ADD +1 TO AC-PARC */
            AC_PARC.Value = AC_PARC + +1;

            /*" -2181- GO TO R1300-10-PARCELA. */
            new Task(() => R1300_10_PARCELA()).RunSynchronously(); //GOTO
            return;//Recursividade detectada, cuidado...

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1300_99_SAIDA*/

        [StopWatch]
        /*" R1310-00-PRIMEIRA-PARCELA-SECTION */
        private void R1310_00_PRIMEIRA_PARCELA_SECTION()
        {
            /*" -2191- MOVE '1310' TO WNR-EXEC-SQL. */
            _.Move("1310", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2218- PERFORM R1310_00_PRIMEIRA_PARCELA_DB_SELECT_1 */

            R1310_00_PRIMEIRA_PARCELA_DB_SELECT_1();

            /*" -2221- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2222- DISPLAY 'R1310-00 (ERRO NO SELECT V1PARCELA)' */
                _.Display($"R1310-00 (ERRO NO SELECT V1PARCELA)");

                /*" -2223- DISPLAY 'APOLICE = ' V1ENDO-NUMAPOL */
                _.Display($"APOLICE = {V1ENDO_NUMAPOL}");

                /*" -2224- DISPLAY 'ENDOSSO = ' V1ENDO-NRENDOS */
                _.Display($"ENDOSSO = {V1ENDO_NRENDOS}");

                /*" -2225- DISPLAY 'PARCELA = ' AC-PARC */
                _.Display($"PARCELA = {AC_PARC}");

                /*" -2225- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1310-00-PRIMEIRA-PARCELA-DB-SELECT-1 */
        public void R1310_00_PRIMEIRA_PARCELA_DB_SELECT_1()
        {
            /*" -2218- EXEC SQL SELECT A.NUM_APOLICE , A.NRENDOS , A.NRPARCEL , A.NRTIT , A.OTNPRLIQ , A.OCORHIST , A.SITUACAO , B.DTVENCTO INTO :V1PARC-NUMAPOL , :V1PARC-NRENDOS , :V1PARC-NRPARCEL , :V1PARC-NRTIT , :V1PARC-VLPRMLIQ , :V1PARC-QTDOCORR , :V1PARC-SITUACAO , :V1HISP-DTVENCTO FROM SEGUROS.V1PARCELA A, SEGUROS.V1HISTOPARC B WHERE A.NUM_APOLICE = :V1ENDO-NUMAPOL AND A.NRENDOS = :V1ENDO-NRENDOS AND A.NRPARCEL IN (0, 1) AND A.NUM_APOLICE = B.NUM_APOLICE AND A.NRENDOS = B.NRENDOS AND A.NRPARCEL = B.NRPARCEL AND B.OPERACAO BETWEEN 100 AND 199 WITH UR END-EXEC. */

            var r1310_00_PRIMEIRA_PARCELA_DB_SELECT_1_Query1 = new R1310_00_PRIMEIRA_PARCELA_DB_SELECT_1_Query1()
            {
                V1ENDO_NUMAPOL = V1ENDO_NUMAPOL.ToString(),
                V1ENDO_NRENDOS = V1ENDO_NRENDOS.ToString(),
            };

            var executed_1 = R1310_00_PRIMEIRA_PARCELA_DB_SELECT_1_Query1.Execute(r1310_00_PRIMEIRA_PARCELA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1PARC_NUMAPOL, V1PARC_NUMAPOL);
                _.Move(executed_1.V1PARC_NRENDOS, V1PARC_NRENDOS);
                _.Move(executed_1.V1PARC_NRPARCEL, V1PARC_NRPARCEL);
                _.Move(executed_1.V1PARC_NRTIT, V1PARC_NRTIT);
                _.Move(executed_1.V1PARC_VLPRMLIQ, V1PARC_VLPRMLIQ);
                _.Move(executed_1.V1PARC_QTDOCORR, V1PARC_QTDOCORR);
                _.Move(executed_1.V1PARC_SITUACAO, V1PARC_SITUACAO);
                _.Move(executed_1.V1HISP_DTVENCTO, V1HISP_DTVENCTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1310_99_SAIDA*/

        [StopWatch]
        /*" R1311-00-DEMAIS-PARCELAS-SECTION */
        private void R1311_00_DEMAIS_PARCELAS_SECTION()
        {
            /*" -2235- MOVE '1311' TO WNR-EXEC-SQL. */
            _.Move("1311", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2262- PERFORM R1311_00_DEMAIS_PARCELAS_DB_SELECT_1 */

            R1311_00_DEMAIS_PARCELAS_DB_SELECT_1();

            /*" -2265- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2266- DISPLAY 'R1311-00 (ERRO NO SELECT V1PARCELA)' */
                _.Display($"R1311-00 (ERRO NO SELECT V1PARCELA)");

                /*" -2267- DISPLAY 'APOLICE = ' V1ENDO-NUMAPOL */
                _.Display($"APOLICE = {V1ENDO_NUMAPOL}");

                /*" -2268- DISPLAY 'ENDOSSO = ' V1ENDO-NRENDOS */
                _.Display($"ENDOSSO = {V1ENDO_NRENDOS}");

                /*" -2269- DISPLAY 'PARCELA = ' AC-PARC */
                _.Display($"PARCELA = {AC_PARC}");

                /*" -2269- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1311-00-DEMAIS-PARCELAS-DB-SELECT-1 */
        public void R1311_00_DEMAIS_PARCELAS_DB_SELECT_1()
        {
            /*" -2262- EXEC SQL SELECT A.NUM_APOLICE , A.NRENDOS , A.NRPARCEL , A.NRTIT , A.OTNPRLIQ , A.OCORHIST , A.SITUACAO , B.DTVENCTO INTO :V1PARC-NUMAPOL , :V1PARC-NRENDOS , :V1PARC-NRPARCEL , :V1PARC-NRTIT , :V1PARC-VLPRMLIQ , :V1PARC-QTDOCORR , :V1PARC-SITUACAO , :V1HISP-DTVENCTO FROM SEGUROS.V1PARCELA A, SEGUROS.V1HISTOPARC B WHERE A.NUM_APOLICE = :V1ENDO-NUMAPOL AND A.NRENDOS = :V1ENDO-NRENDOS AND A.NRPARCEL = :AC-PARC AND A.NUM_APOLICE = B.NUM_APOLICE AND A.NRENDOS = B.NRENDOS AND A.NRPARCEL = B.NRPARCEL AND B.OPERACAO BETWEEN 100 AND 199 WITH UR END-EXEC. */

            var r1311_00_DEMAIS_PARCELAS_DB_SELECT_1_Query1 = new R1311_00_DEMAIS_PARCELAS_DB_SELECT_1_Query1()
            {
                V1ENDO_NUMAPOL = V1ENDO_NUMAPOL.ToString(),
                V1ENDO_NRENDOS = V1ENDO_NRENDOS.ToString(),
                AC_PARC = AC_PARC.ToString(),
            };

            var executed_1 = R1311_00_DEMAIS_PARCELAS_DB_SELECT_1_Query1.Execute(r1311_00_DEMAIS_PARCELAS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1PARC_NUMAPOL, V1PARC_NUMAPOL);
                _.Move(executed_1.V1PARC_NRENDOS, V1PARC_NRENDOS);
                _.Move(executed_1.V1PARC_NRPARCEL, V1PARC_NRPARCEL);
                _.Move(executed_1.V1PARC_NRTIT, V1PARC_NRTIT);
                _.Move(executed_1.V1PARC_VLPRMLIQ, V1PARC_VLPRMLIQ);
                _.Move(executed_1.V1PARC_QTDOCORR, V1PARC_QTDOCORR);
                _.Move(executed_1.V1PARC_SITUACAO, V1PARC_SITUACAO);
                _.Move(executed_1.V1HISP_DTVENCTO, V1HISP_DTVENCTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1311_99_SAIDA*/

        [StopWatch]
        /*" R1400-00-GRAVA-FENCOMI-SECTION */
        private void R1400_00_GRAVA_FENCOMI_SECTION()
        {
            /*" -2281- MOVE '1400' TO WNR-EXEC-SQL. */
            _.Move("1400", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2294- PERFORM R1400_00_GRAVA_FENCOMI_DB_DECLARE_1 */

            R1400_00_GRAVA_FENCOMI_DB_DECLARE_1();

            /*" -2296- PERFORM R1400_00_GRAVA_FENCOMI_DB_OPEN_1 */

            R1400_00_GRAVA_FENCOMI_DB_OPEN_1();

            /*" -2299- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2300- DISPLAY 'R1400-00 - ERRO NO DECLARE V0APOLCORRET' */
                _.Display($"R1400-00 - ERRO NO DECLARE V0APOLCORRET");

                /*" -2300- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -0- FLUXCONTROL_PERFORM R1400_10_FETCH */

            R1400_10_FETCH();

        }

        [StopWatch]
        /*" R1400-00-GRAVA-FENCOMI-DB-OPEN-1 */
        public void R1400_00_GRAVA_FENCOMI_DB_OPEN_1()
        {
            /*" -2296- EXEC SQL OPEN V1APOLCORRET END-EXEC. */

            V1APOLCORRET.Open();

        }

        [StopWatch]
        /*" R1500-00-GRAVA-FENCOSS-DB-DECLARE-1 */
        public void R1500_00_GRAVA_FENCOSS_DB_DECLARE_1()
        {
            /*" -2359- EXEC SQL DECLARE V1APOLCOSCED CURSOR FOR SELECT NUM_APOLICE , CODCOSS , PCPARTIC , PCCOMCOS FROM SEGUROS.V1APOLCOSCED WHERE NUM_APOLICE = :V1ENDO-NUMAPOL ORDER BY NUM_APOLICE,CODCOSS WITH UR END-EXEC. */
            V1APOLCOSCED = new FN0301B_V1APOLCOSCED(true);
            string GetQuery_V1APOLCOSCED()
            {
                var query = @$"SELECT NUM_APOLICE
							, 
							CODCOSS
							, 
							PCPARTIC
							, 
							PCCOMCOS 
							FROM SEGUROS.V1APOLCOSCED 
							WHERE NUM_APOLICE = '{V1ENDO_NUMAPOL}' 
							ORDER BY NUM_APOLICE
							,CODCOSS";

                return query;
            }
            V1APOLCOSCED.GetQueryEvent += GetQuery_V1APOLCOSCED;

        }

        [StopWatch]
        /*" R1400-10-FETCH */
        private void R1400_10_FETCH(bool isPerform = false)
        {
            /*" -2316- PERFORM R1400_10_FETCH_DB_FETCH_1 */

            R1400_10_FETCH_DB_FETCH_1();

            /*" -2319- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2320- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2320- PERFORM R1400_10_FETCH_DB_CLOSE_1 */

                    R1400_10_FETCH_DB_CLOSE_1();

                    /*" -2322- GO TO R1400-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1400_99_SAIDA*/ //GOTO
                    return;

                    /*" -2323- ELSE */
                }
                else
                {


                    /*" -2324- DISPLAY 'R1400-10 - ERRO NO FETCH V1APOLCORRET' */
                    _.Display($"R1400-10 - ERRO NO FETCH V1APOLCORRET");

                    /*" -2326- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -2327- MOVE V1APCR-NUM-APOL TO FCOM-NUMAPOL */
            _.Move(V1APCR_NUM_APOL, WREG_FENCOMI.FCOM_NUMAPOL);

            /*" -2328- MOVE V1APCR-CODSUBES TO FCOM-CODSUBES */
            _.Move(V1APCR_CODSUBES, WREG_FENCOMI.FCOM_CODSUBES);

            /*" -2329- MOVE V1APCR-RAMOFR TO FCOM-RAMOFR */
            _.Move(V1APCR_RAMOFR, WREG_FENCOMI.FCOM_RAMOFR);

            /*" -2330- MOVE V1APCR-CODCORR TO FCOM-CODCORR */
            _.Move(V1APCR_CODCORR, WREG_FENCOMI.FCOM_CODCORR);

            /*" -2331- MOVE V1APCR-TIPCOM TO FCOM-TIPOCOM */
            _.Move(V1APCR_TIPCOM, WREG_FENCOMI.FCOM_TIPOCOM);

            /*" -2332- MOVE V1APCR-PCCOMCOR TO FCOM-PCTCOM */
            _.Move(V1APCR_PCCOMCOR, WREG_FENCOMI.FCOM_PCTCOM);

            /*" -2334- MOVE V1APCR-PCPARCOR TO FCOM-PCTPART */
            _.Move(V1APCR_PCPARCOR, WREG_FENCOMI.FCOM_PCTPART);

            /*" -2336- WRITE REG-FENCOMI FROM WREG-FENCOMI */
            _.Move(WREG_FENCOMI.GetMoveValues(), REG_FENCOMI);

            FENCOMI.Write(REG_FENCOMI.GetMoveValues().ToString());

            /*" -2338- ADD +1 TO AC-G-FENCOMI. */
            AREA_DE_WORK.AC_G_FENCOMI.Value = AREA_DE_WORK.AC_G_FENCOMI + +1;

            /*" -2338- GO TO R1400-10-FETCH. */
            new Task(() => R1400_10_FETCH()).RunSynchronously(); //GOTO
            return;//Recursividade detectada, cuidado...

        }

        [StopWatch]
        /*" R1400-10-FETCH-DB-FETCH-1 */
        public void R1400_10_FETCH_DB_FETCH_1()
        {
            /*" -2316- EXEC SQL FETCH V1APOLCORRET INTO :V1APCR-NUM-APOL , :V1APCR-CODSUBES , :V1APCR-RAMOFR , :V1APCR-CODCORR , :V1APCR-PCCOMCOR , :V1APCR-PCPARCOR , :V1APCR-TIPCOM END-EXEC. */

            if (V1APOLCORRET.Fetch())
            {
                _.Move(V1APOLCORRET.V1APCR_NUM_APOL, V1APCR_NUM_APOL);
                _.Move(V1APOLCORRET.V1APCR_CODSUBES, V1APCR_CODSUBES);
                _.Move(V1APOLCORRET.V1APCR_RAMOFR, V1APCR_RAMOFR);
                _.Move(V1APOLCORRET.V1APCR_CODCORR, V1APCR_CODCORR);
                _.Move(V1APOLCORRET.V1APCR_PCCOMCOR, V1APCR_PCCOMCOR);
                _.Move(V1APOLCORRET.V1APCR_PCPARCOR, V1APCR_PCPARCOR);
                _.Move(V1APOLCORRET.V1APCR_TIPCOM, V1APCR_TIPCOM);
            }

        }

        [StopWatch]
        /*" R1400-10-FETCH-DB-CLOSE-1 */
        public void R1400_10_FETCH_DB_CLOSE_1()
        {
            /*" -2320- EXEC SQL CLOSE V1APOLCORRET END-EXEC */

            V1APOLCORRET.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1400_99_SAIDA*/

        [StopWatch]
        /*" R1500-00-GRAVA-FENCOSS-SECTION */
        private void R1500_00_GRAVA_FENCOSS_SECTION()
        {
            /*" -2350- MOVE '1500' TO WNR-EXEC-SQL. */
            _.Move("1500", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2359- PERFORM R1500_00_GRAVA_FENCOSS_DB_DECLARE_1 */

            R1500_00_GRAVA_FENCOSS_DB_DECLARE_1();

            /*" -2361- PERFORM R1500_00_GRAVA_FENCOSS_DB_OPEN_1 */

            R1500_00_GRAVA_FENCOSS_DB_OPEN_1();

            /*" -2364- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2365- DISPLAY 'R1500-00 - ERRO NO DECLARE V1APOLCOSCED' */
                _.Display($"R1500-00 - ERRO NO DECLARE V1APOLCOSCED");

                /*" -2365- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -0- FLUXCONTROL_PERFORM R1500_10_FETCH */

            R1500_10_FETCH();

        }

        [StopWatch]
        /*" R1500-00-GRAVA-FENCOSS-DB-OPEN-1 */
        public void R1500_00_GRAVA_FENCOSS_DB_OPEN_1()
        {
            /*" -2361- EXEC SQL OPEN V1APOLCOSCED END-EXEC. */

            V1APOLCOSCED.Open();

        }

        [StopWatch]
        /*" R1600-00-GRAVA-FENRESS-DB-DECLARE-1 */
        public void R1600_00_GRAVA_FENRESS_DB_DECLARE_1()
        {
            /*" -2429- EXEC SQL DECLARE V1HISTORES CURSOR FOR SELECT NUM_APOLICE , NRENDOS , NRITEM , OCORHIST , CODRESSEG , RAMOFR , PCTRSP , PCTCOMRS FROM SEGUROS.V1HISTORES WHERE NUM_APOLICE = :V1ENDO-NUMAPOL AND NRENDOS = :V1ENDO-NRENDOS AND OPERACAO = 101 AND SITUACAO �= '2' AND PCTRSP > 0 ORDER BY NUM_APOLICE WITH UR END-EXEC. */
            V1HISTORES = new FN0301B_V1HISTORES(true);
            string GetQuery_V1HISTORES()
            {
                var query = @$"SELECT NUM_APOLICE
							, 
							NRENDOS
							, 
							NRITEM
							, 
							OCORHIST
							, 
							CODRESSEG
							, 
							RAMOFR
							, 
							PCTRSP
							, 
							PCTCOMRS 
							FROM SEGUROS.V1HISTORES 
							WHERE NUM_APOLICE = '{V1ENDO_NUMAPOL}' 
							AND NRENDOS = '{V1ENDO_NRENDOS}' 
							AND OPERACAO = 101 
							AND SITUACAO �= '2' 
							AND PCTRSP > 0 
							ORDER BY NUM_APOLICE";

                return query;
            }
            V1HISTORES.GetQueryEvent += GetQuery_V1HISTORES;

        }

        [StopWatch]
        /*" R1500-10-FETCH */
        private void R1500_10_FETCH(bool isPerform = false)
        {
            /*" -2378- PERFORM R1500_10_FETCH_DB_FETCH_1 */

            R1500_10_FETCH_DB_FETCH_1();

            /*" -2381- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2382- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2382- PERFORM R1500_10_FETCH_DB_CLOSE_1 */

                    R1500_10_FETCH_DB_CLOSE_1();

                    /*" -2384- GO TO R1500-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1500_99_SAIDA*/ //GOTO
                    return;

                    /*" -2385- ELSE */
                }
                else
                {


                    /*" -2386- DISPLAY 'R1500-00 - ERRO NO FETCH V1APOLCOSCED' */
                    _.Display($"R1500-00 - ERRO NO FETCH V1APOLCOSCED");

                    /*" -2388- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -2389- MOVE V1APCC-NUM-APOL TO FCOS-NUMAPOL */
            _.Move(V1APCC_NUM_APOL, WREG_FENCOSS.FCOS_NUMAPOL);

            /*" -2390- MOVE V1APCC-CODCOSS TO FCOS-CODCONG */
            _.Move(V1APCC_CODCOSS, WREG_FENCOSS.FCOS_CODCONG);

            /*" -2391- MOVE V1APCC-PCPARTIC TO FCOS-PCTCOSS */
            _.Move(V1APCC_PCPARTIC, WREG_FENCOSS.FCOS_PCTCOSS);

            /*" -2393- MOVE V1APCC-PCCOMCOS TO FCOS-PCTCOM */
            _.Move(V1APCC_PCCOMCOS, WREG_FENCOSS.FCOS_PCTCOM);

            /*" -2395- WRITE REG-FENCOSS FROM WREG-FENCOSS */
            _.Move(WREG_FENCOSS.GetMoveValues(), REG_FENCOSS);

            FENCOSS.Write(REG_FENCOSS.GetMoveValues().ToString());

            /*" -2397- ADD +1 TO AC-G-FENCOSS. */
            AREA_DE_WORK.AC_G_FENCOSS.Value = AREA_DE_WORK.AC_G_FENCOSS + +1;

            /*" -2397- GO TO R1500-10-FETCH. */
            new Task(() => R1500_10_FETCH()).RunSynchronously(); //GOTO
            return;//Recursividade detectada, cuidado...

        }

        [StopWatch]
        /*" R1500-10-FETCH-DB-FETCH-1 */
        public void R1500_10_FETCH_DB_FETCH_1()
        {
            /*" -2378- EXEC SQL FETCH V1APOLCOSCED INTO :V1APCC-NUM-APOL , :V1APCC-CODCOSS , :V1APCC-PCPARTIC , :V1APCC-PCCOMCOS END-EXEC. */

            if (V1APOLCOSCED.Fetch())
            {
                _.Move(V1APOLCOSCED.V1APCC_NUM_APOL, V1APCC_NUM_APOL);
                _.Move(V1APOLCOSCED.V1APCC_CODCOSS, V1APCC_CODCOSS);
                _.Move(V1APOLCOSCED.V1APCC_PCPARTIC, V1APCC_PCPARTIC);
                _.Move(V1APOLCOSCED.V1APCC_PCCOMCOS, V1APCC_PCCOMCOS);
            }

        }

        [StopWatch]
        /*" R1500-10-FETCH-DB-CLOSE-1 */
        public void R1500_10_FETCH_DB_CLOSE_1()
        {
            /*" -2382- EXEC SQL CLOSE V1APOLCOSCED END-EXEC */

            V1APOLCOSCED.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1500_99_SAIDA*/

        [StopWatch]
        /*" R1600-00-GRAVA-FENRESS-SECTION */
        private void R1600_00_GRAVA_FENRESS_SECTION()
        {
            /*" -2412- MOVE '1600' TO WNR-EXEC-SQL. */
            _.Move("1600", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2429- PERFORM R1600_00_GRAVA_FENRESS_DB_DECLARE_1 */

            R1600_00_GRAVA_FENRESS_DB_DECLARE_1();

            /*" -2431- PERFORM R1600_00_GRAVA_FENRESS_DB_OPEN_1 */

            R1600_00_GRAVA_FENRESS_DB_OPEN_1();

            /*" -2434- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2435- DISPLAY 'R1600-00 - ERRO NO DECLARE V1HISTORES' */
                _.Display($"R1600-00 - ERRO NO DECLARE V1HISTORES");

                /*" -2435- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -0- FLUXCONTROL_PERFORM R1600_10_FETCH */

            R1600_10_FETCH();

        }

        [StopWatch]
        /*" R1600-00-GRAVA-FENRESS-DB-OPEN-1 */
        public void R1600_00_GRAVA_FENRESS_DB_OPEN_1()
        {
            /*" -2431- EXEC SQL OPEN V1HISTORES END-EXEC. */

            V1HISTORES.Open();

        }

        [StopWatch]
        /*" R2100-00-DECLARE-V1AUTOAPOL-DB-DECLARE-1 */
        public void R2100_00_DECLARE_V1AUTOAPOL_DB_DECLARE_1()
        {
            /*" -2555- EXEC SQL DECLARE V1AUTOAPOL CURSOR FOR SELECT FONTE , NRPROPOS , NRITEM , CDVEICL , ANOVEICL , ANOMOD , CHASSIS , COMBUST , PLACALET , PLACANR , PLACAUF FROM SEGUROS.V1AUTOAPOL WHERE NUM_APOLICE = :V1ENDO-NUMAPOL AND NRENDOS = :V1ENDO-NRENDOS WITH UR END-EXEC. */
            V1AUTOAPOL = new FN0301B_V1AUTOAPOL(true);
            string GetQuery_V1AUTOAPOL()
            {
                var query = @$"SELECT 
							FONTE
							, 
							NRPROPOS
							, 
							NRITEM
							, 
							CDVEICL
							, 
							ANOVEICL
							, 
							ANOMOD
							, 
							CHASSIS
							, 
							COMBUST
							, 
							PLACALET
							, 
							PLACANR
							, 
							PLACAUF 
							FROM SEGUROS.V1AUTOAPOL 
							WHERE NUM_APOLICE = '{V1ENDO_NUMAPOL}' 
							AND NRENDOS = '{V1ENDO_NRENDOS}'";

                return query;
            }
            V1AUTOAPOL.GetQueryEvent += GetQuery_V1AUTOAPOL;

        }

        [StopWatch]
        /*" R1600-10-FETCH */
        private void R1600_10_FETCH(bool isPerform = false)
        {
            /*" -2453- PERFORM R1600_10_FETCH_DB_FETCH_1 */

            R1600_10_FETCH_DB_FETCH_1();

            /*" -2456- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2457- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2457- PERFORM R1600_10_FETCH_DB_CLOSE_1 */

                    R1600_10_FETCH_DB_CLOSE_1();

                    /*" -2459- GO TO R1600-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1600_99_SAIDA*/ //GOTO
                    return;

                    /*" -2460- ELSE */
                }
                else
                {


                    /*" -2461- DISPLAY 'R1600-10 - ERRO NO FETCH V1HISTORES' */
                    _.Display($"R1600-10 - ERRO NO FETCH V1HISTORES");

                    /*" -2463- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -2464- IF VIND-CODRESSEG EQUAL -1 */

            if (VIND_CODRESSEG == -1)
            {

                /*" -2466- MOVE ZEROS TO V1HRES-CODRESSEG. */
                _.Move(0, V1HRES_CODRESSEG);
            }


            /*" -2467- MOVE V1HRES-NUMAPOL TO FRES-NUMAPOL */
            _.Move(V1HRES_NUMAPOL, WREG_FENRESS.FRES_NUMAPOL);

            /*" -2468- MOVE V1HRES-NRENDOS TO FRES-NRENDOS */
            _.Move(V1HRES_NRENDOS, WREG_FENRESS.FRES_NRENDOS);

            /*" -2469- MOVE V1HRES-NRITEM TO FRES-NRITEM */
            _.Move(V1HRES_NRITEM, WREG_FENRESS.FRES_NRITEM);

            /*" -2470- MOVE V1HRES-OCORHIST TO FRES-OCORHIST */
            _.Move(V1HRES_OCORHIST, WREG_FENRESS.FRES_OCORHIST);

            /*" -2471- MOVE V1HRES-CODRESSEG TO FRES-CODRESS */
            _.Move(V1HRES_CODRESSEG, WREG_FENRESS.FRES_CODRESS);

            /*" -2472- MOVE V1HRES-RAMOFR TO FRES-CODRAMO */
            _.Move(V1HRES_RAMOFR, WREG_FENRESS.FRES_CODRAMO);

            /*" -2473- MOVE ZEROS TO FRES-CODCOBER */
            _.Move(0, WREG_FENRESS.FRES_CODCOBER);

            /*" -2474- MOVE '4' TO FRES-TIPORESS */
            _.Move("4", WREG_FENRESS.FRES_TIPORESS);

            /*" -2475- MOVE V1HRES-PCTRSP TO FRES-PCTRESS */
            _.Move(V1HRES_PCTRSP, WREG_FENRESS.FRES_PCTRESS);

            /*" -2477- MOVE V1HRES-PCTCOMRS TO FRES-PCTCOM */
            _.Move(V1HRES_PCTCOMRS, WREG_FENRESS.FRES_PCTCOM);

            /*" -2479- WRITE REG-FENRESS FROM WREG-FENRESS */
            _.Move(WREG_FENRESS.GetMoveValues(), REG_FENRESS);

            FENRESS.Write(REG_FENRESS.GetMoveValues().ToString());

            /*" -2481- ADD +1 TO AC-G-FENRESS. */
            AREA_DE_WORK.AC_G_FENRESS.Value = AREA_DE_WORK.AC_G_FENRESS + +1;

            /*" -2481- GO TO R1600-10-FETCH. */
            new Task(() => R1600_10_FETCH()).RunSynchronously(); //GOTO
            return;//Recursividade detectada, cuidado...

        }

        [StopWatch]
        /*" R1600-10-FETCH-DB-FETCH-1 */
        public void R1600_10_FETCH_DB_FETCH_1()
        {
            /*" -2453- EXEC SQL FETCH V1HISTORES INTO :V1HRES-NUMAPOL , :V1HRES-NRENDOS , :V1HRES-NRITEM , :V1HRES-OCORHIST , :V1HRES-CODRESSEG:VIND-CODRESSEG, :V1HRES-RAMOFR , :V1HRES-PCTRSP , :V1HRES-PCTCOMRS END-EXEC. */

            if (V1HISTORES.Fetch())
            {
                _.Move(V1HISTORES.V1HRES_NUMAPOL, V1HRES_NUMAPOL);
                _.Move(V1HISTORES.V1HRES_NRENDOS, V1HRES_NRENDOS);
                _.Move(V1HISTORES.V1HRES_NRITEM, V1HRES_NRITEM);
                _.Move(V1HISTORES.V1HRES_OCORHIST, V1HRES_OCORHIST);
                _.Move(V1HISTORES.V1HRES_CODRESSEG, V1HRES_CODRESSEG);
                _.Move(V1HISTORES.VIND_CODRESSEG, VIND_CODRESSEG);
                _.Move(V1HISTORES.V1HRES_RAMOFR, V1HRES_RAMOFR);
                _.Move(V1HISTORES.V1HRES_PCTRSP, V1HRES_PCTRSP);
                _.Move(V1HISTORES.V1HRES_PCTCOMRS, V1HRES_PCTCOMRS);
            }

        }

        [StopWatch]
        /*" R1600-10-FETCH-DB-CLOSE-1 */
        public void R1600_10_FETCH_DB_CLOSE_1()
        {
            /*" -2457- EXEC SQL CLOSE V1HISTORES END-EXEC */

            V1HISTORES.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1600_99_SAIDA*/

        [StopWatch]
        /*" R2000-00-PROCESSA-AUTO-SECTION */
        private void R2000_00_PROCESSA_AUTO_SECTION()
        {
            /*" -2491- MOVE '2000' TO WNR-EXEC-SQL. */
            _.Move("2000", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2493- DISPLAY 'R2000-00-PROCESSA-AUTO' */
            _.Display($"R2000-00-PROCESSA-AUTO");

            /*" -2495- PERFORM R2100-00-DECLARE-V1AUTOAPOL */

            R2100_00_DECLARE_V1AUTOAPOL_SECTION();

            /*" -2497- MOVE SPACES TO WFIM-V1AUTOAPOL */
            _.Move("", AREA_DE_WORK.WFIM_V1AUTOAPOL);

            /*" -2499- PERFORM R0920-00-FETCH-V1AUTOAPOL */

            R0920_00_FETCH_V1AUTOAPOL_SECTION();

            /*" -2503- IF WFIM-V1AUTOAPOL NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WFIM_V1AUTOAPOL.IsEmpty())
            {

                /*" -2504- DISPLAY 'R2000-00 (APOLICE/ENDOSSO SEM ITEM)' */
                _.Display($"R2000-00 (APOLICE/ENDOSSO SEM ITEM)");

                /*" -2505- DISPLAY 'APOLICE = ' V1ENDO-NUMAPOL */
                _.Display($"APOLICE = {V1ENDO_NUMAPOL}");

                /*" -2506- DISPLAY 'ENDOSSO = ' V1ENDO-NRENDOS */
                _.Display($"ENDOSSO = {V1ENDO_NRENDOS}");

                /*" -2506- GO TO R2000-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_99_SAIDA*/ //GOTO
                return;
            }


            /*" -0- FLUXCONTROL_PERFORM R2000_10_LOOP_V1AUTOAPOL */

            R2000_10_LOOP_V1AUTOAPOL();

        }

        [StopWatch]
        /*" R2000-10-LOOP-V1AUTOAPOL */
        private void R2000_10_LOOP_V1AUTOAPOL(bool isPerform = false)
        {
            /*" -2512- PERFORM R2200-00-INCLUI-FENAUTO */

            R2200_00_INCLUI_FENAUTO_SECTION();

            /*" -2516- IF V1AUTO-NRITEM EQUAL ZEROS */

            if (V1AUTO_NRITEM == 00)
            {

                /*" -2518- GO TO R2000-20-FETCH-AUTO. */

                R2000_20_FETCH_AUTO(); //GOTO
                return;
            }


            /*" -2518- PERFORM R2300-00-INCLUI-FENAUT1. */

            R2300_00_INCLUI_FENAUT1_SECTION();

        }

        [StopWatch]
        /*" R2000-20-FETCH-AUTO */
        private void R2000_20_FETCH_AUTO(bool isPerform = false)
        {
            /*" -2524- PERFORM R0920-00-FETCH-V1AUTOAPOL */

            R0920_00_FETCH_V1AUTOAPOL_SECTION();

            /*" -2525- IF WFIM-V1AUTOAPOL EQUAL SPACES */

            if (AREA_DE_WORK.WFIM_V1AUTOAPOL.IsEmpty())
            {

                /*" -2525- GO TO R2000-10-LOOP-V1AUTOAPOL. */

                R2000_10_LOOP_V1AUTOAPOL(); //GOTO
                return;
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_99_SAIDA*/

        [StopWatch]
        /*" R2100-00-DECLARE-V1AUTOAPOL-SECTION */
        private void R2100_00_DECLARE_V1AUTOAPOL_SECTION()
        {
            /*" -2538- MOVE '2100' TO WNR-EXEC-SQL. */
            _.Move("2100", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2555- PERFORM R2100_00_DECLARE_V1AUTOAPOL_DB_DECLARE_1 */

            R2100_00_DECLARE_V1AUTOAPOL_DB_DECLARE_1();

            /*" -2557- PERFORM R2100_00_DECLARE_V1AUTOAPOL_DB_OPEN_1 */

            R2100_00_DECLARE_V1AUTOAPOL_DB_OPEN_1();

            /*" -2560- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2561- DISPLAY 'R2100-00 (ERRO NO DECLARE V1AUTOAPOL)' */
                _.Display($"R2100-00 (ERRO NO DECLARE V1AUTOAPOL)");

                /*" -2562- DISPLAY 'APOLICE   = ' V1ENDO-NUMAPOL */
                _.Display($"APOLICE   = {V1ENDO_NUMAPOL}");

                /*" -2563- DISPLAY 'ENDOSSO   = ' V1ENDO-NRENDOS */
                _.Display($"ENDOSSO   = {V1ENDO_NRENDOS}");

                /*" -2563- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2100-00-DECLARE-V1AUTOAPOL-DB-OPEN-1 */
        public void R2100_00_DECLARE_V1AUTOAPOL_DB_OPEN_1()
        {
            /*" -2557- EXEC SQL OPEN V1AUTOAPOL END-EXEC. */

            V1AUTOAPOL.Open();

        }

        [StopWatch]
        /*" R2310-00-DECLARE-V1AUTOCOBER-DB-DECLARE-1 */
        public void R2310_00_DECLARE_V1AUTOCOBER_DB_DECLARE_1()
        {
            /*" -2735- EXEC SQL DECLARE V1AUTOCOBER CURSOR FOR SELECT RAMOFR , COD_COBERTURA, IMP_SEGURADA_IX, PRM_TARIFARIO_VAR FROM SEGUROS.V1AUTOCOBER WHERE NUM_APOLICE = :V1ENDO-NUMAPOL AND NRENDOS = :V1ENDO-NRENDOS AND NRITEM = :V1AUTO-NRITEM WITH UR END-EXEC. */
            V1AUTOCOBER = new FN0301B_V1AUTOCOBER(true);
            string GetQuery_V1AUTOCOBER()
            {
                var query = @$"SELECT RAMOFR
							, 
							COD_COBERTURA
							, 
							IMP_SEGURADA_IX
							, 
							PRM_TARIFARIO_VAR 
							FROM SEGUROS.V1AUTOCOBER 
							WHERE NUM_APOLICE = '{V1ENDO_NUMAPOL}' 
							AND NRENDOS = '{V1ENDO_NRENDOS}' 
							AND NRITEM = '{V1AUTO_NRITEM}'";

                return query;
            }
            V1AUTOCOBER.GetQueryEvent += GetQuery_V1AUTOCOBER;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2100_99_SAIDA*/

        [StopWatch]
        /*" R2200-00-INCLUI-FENAUTO-SECTION */
        private void R2200_00_INCLUI_FENAUTO_SECTION()
        {
            /*" -2576- PERFORM R2210-00-SELECT-V1AUTOTARIFA */

            R2210_00_SELECT_V1AUTOTARIFA_SECTION();

            /*" -2580- IF V1AUTO-NRITEM EQUAL ZEROS */

            if (V1AUTO_NRITEM == 00)
            {

                /*" -2582- GO TO R2200-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2200_99_SAIDA*/ //GOTO
                return;
            }


            /*" -2584- MOVE '2200' TO WNR-EXEC-SQL. */
            _.Move("2200", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2585- MOVE V1ENDO-NUMAPOL TO FAUT-NUMAPOL */
            _.Move(V1ENDO_NUMAPOL, WREG_FENAUTO.FAUT_NUMAPOL);

            /*" -2586- MOVE V1ENDO-NRENDOS TO FAUT-NRENDOS */
            _.Move(V1ENDO_NRENDOS, WREG_FENAUTO.FAUT_NRENDOS);

            /*" -2587- MOVE V1AUTO-NRITEM TO FAUT-NRITEM */
            _.Move(V1AUTO_NRITEM, WREG_FENAUTO.FAUT_NRITEM);

            /*" -2588- MOVE V1AUTO-CDVEICL TO FAUT-CDVEICL */
            _.Move(V1AUTO_CDVEICL, WREG_FENAUTO.FAUT_CDVEICL);

            /*" -2589- MOVE V1AUTO-COMBUST TO FAUT-COMBUST */
            _.Move(V1AUTO_COMBUST, WREG_FENAUTO.FAUT_COMBUST);

            /*" -2590- MOVE V1AUTO-ANOVEICL TO FAUT-ANOVEICL */
            _.Move(V1AUTO_ANOVEICL, WREG_FENAUTO.FAUT_ANOVEICL);

            /*" -2591- MOVE V1AUTO-ANOMOD TO FAUT-ANOMOD */
            _.Move(V1AUTO_ANOMOD, WREG_FENAUTO.FAUT_ANOMOD);

            /*" -2592- MOVE V1AUTO-CHASSIS TO FAUT-CHASSIS */
            _.Move(V1AUTO_CHASSIS, WREG_FENAUTO.FAUT_CHASSIS);

            /*" -2593- MOVE V1AUTO-PLACALET TO FAUT-PLACALET */
            _.Move(V1AUTO_PLACALET, WREG_FENAUTO.FAUT_PLACALET);

            /*" -2594- MOVE V1AUTO-PLACANR TO FAUT-PLACANR */
            _.Move(V1AUTO_PLACANR, WREG_FENAUTO.FAUT_PLACANR);

            /*" -2596- MOVE V1AUTO-PLACAUF TO FAUT-PLACAUF */
            _.Move(V1AUTO_PLACAUF, WREG_FENAUTO.FAUT_PLACAUF);

            /*" -2598- WRITE REG-FENAUTO FROM WREG-FENAUTO */
            _.Move(WREG_FENAUTO.GetMoveValues(), REG_FENAUTO);

            FENAUTO.Write(REG_FENAUTO.GetMoveValues().ToString());

            /*" -2598- ADD +1 TO AC-G-FENAUTO. */
            AREA_DE_WORK.AC_G_FENAUTO.Value = AREA_DE_WORK.AC_G_FENAUTO + +1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2200_99_SAIDA*/

        [StopWatch]
        /*" R2210-00-SELECT-V1AUTOTARIFA-SECTION */
        private void R2210_00_SELECT_V1AUTOTARIFA_SECTION()
        {
            /*" -2611- MOVE '2210' TO WNR-EXEC-SQL. */
            _.Move("2210", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2651- PERFORM R2210_00_SELECT_V1AUTOTARIFA_DB_SELECT_1 */

            R2210_00_SELECT_V1AUTOTARIFA_DB_SELECT_1();

            /*" -2654- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2655- DISPLAY 'R2210-00 (ERRO NO SELECT V1AUTOTARIFA)' */
                _.Display($"R2210-00 (ERRO NO SELECT V1AUTOTARIFA)");

                /*" -2656- DISPLAY 'APOLICE   = ' V1ENDO-NUMAPOL */
                _.Display($"APOLICE   = {V1ENDO_NUMAPOL}");

                /*" -2657- DISPLAY 'ENDOSSO   = ' V1ENDO-NRENDOS */
                _.Display($"ENDOSSO   = {V1ENDO_NRENDOS}");

                /*" -2658- DISPLAY 'ITEM      = ' V1AUTO-NRITEM */
                _.Display($"ITEM      = {V1AUTO_NRITEM}");

                /*" -2658- MOVE ZEROS TO V1AUTO-NRITEM. */
                _.Move(0, V1AUTO_NRITEM);
            }


        }

        [StopWatch]
        /*" R2210-00-SELECT-V1AUTOTARIFA-DB-SELECT-1 */
        public void R2210_00_SELECT_V1AUTOTARIFA_DB_SELECT_1()
        {
            /*" -2651- EXEC SQL SELECT DTINIVIG , DTTERVIG , TIPOCOB , REGIAO , FRANQFAC , CLABONAT , CATTARIF , CATTARIR , VRFROBR_IX, VRFRFACC_IX, VRFRFACA_IX, VRFRADIC_IX, TPCDSBAU , TPCPZSEG , TPCBONDM , TPCBONDP , DTINIVIG - 1 DAY INTO :V1TARI-DTINIVIG , :V1TARI-DTTERVIG , :V1TARI-TIPOCOB , :V1TARI-REGIAO , :V1TARI-FRANQFAC , :V1TARI-CLABONAT , :V1TARI-CATAUTO , :V1TARI-CATRCF , :V1TARI-VRFROBR-IX , :V1TARI-VRFRFACC-IX , :V1TARI-VRFRFACA-IX , :V1TARI-VRFRADIC-IX , :V1TARI-TPCDSBAU , :V1TARI-TPCPZSEG , :V1TARI-TPCBONDM , :V1TARI-TPCBONDP , :V1TARI-DTINIVIG-1DIA FROM SEGUROS.V1AUTOTARIFA WHERE NUM_APOLICE = :V1ENDO-NUMAPOL AND NRENDOS = :V1ENDO-NRENDOS AND NRITEM = :V1AUTO-NRITEM WITH UR END-EXEC. */

            var r2210_00_SELECT_V1AUTOTARIFA_DB_SELECT_1_Query1 = new R2210_00_SELECT_V1AUTOTARIFA_DB_SELECT_1_Query1()
            {
                V1ENDO_NUMAPOL = V1ENDO_NUMAPOL.ToString(),
                V1ENDO_NRENDOS = V1ENDO_NRENDOS.ToString(),
                V1AUTO_NRITEM = V1AUTO_NRITEM.ToString(),
            };

            var executed_1 = R2210_00_SELECT_V1AUTOTARIFA_DB_SELECT_1_Query1.Execute(r2210_00_SELECT_V1AUTOTARIFA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1TARI_DTINIVIG, V1TARI_DTINIVIG);
                _.Move(executed_1.V1TARI_DTTERVIG, V1TARI_DTTERVIG);
                _.Move(executed_1.V1TARI_TIPOCOB, V1TARI_TIPOCOB);
                _.Move(executed_1.V1TARI_REGIAO, V1TARI_REGIAO);
                _.Move(executed_1.V1TARI_FRANQFAC, V1TARI_FRANQFAC);
                _.Move(executed_1.V1TARI_CLABONAT, V1TARI_CLABONAT);
                _.Move(executed_1.V1TARI_CATAUTO, V1TARI_CATAUTO);
                _.Move(executed_1.V1TARI_CATRCF, V1TARI_CATRCF);
                _.Move(executed_1.V1TARI_VRFROBR_IX, V1TARI_VRFROBR_IX);
                _.Move(executed_1.V1TARI_VRFRFACC_IX, V1TARI_VRFRFACC_IX);
                _.Move(executed_1.V1TARI_VRFRFACA_IX, V1TARI_VRFRFACA_IX);
                _.Move(executed_1.V1TARI_VRFRADIC_IX, V1TARI_VRFRADIC_IX);
                _.Move(executed_1.V1TARI_TPCDSBAU, V1TARI_TPCDSBAU);
                _.Move(executed_1.V1TARI_TPCPZSEG, V1TARI_TPCPZSEG);
                _.Move(executed_1.V1TARI_TPCBONDM, V1TARI_TPCBONDM);
                _.Move(executed_1.V1TARI_TPCBONDP, V1TARI_TPCBONDP);
                _.Move(executed_1.V1TARI_DTINIVIG_1DIA, V1TARI_DTINIVIG_1DIA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2210_99_SAIDA*/

        [StopWatch]
        /*" R2230-00-SELECT-TOMADOR-SECTION */
        private void R2230_00_SELECT_TOMADOR_SECTION()
        {
            /*" -2681- PERFORM R2230_00_SELECT_TOMADOR_DB_SELECT_1 */

            R2230_00_SELECT_TOMADOR_DB_SELECT_1();

            /*" -2684- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2685- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2687- INITIALIZE TOMADOR-COD-FONTE TOMADOR-NUM-PROPOSTA */
                    _.Initialize(
                        TOMADOR.DCLTOMADOR.TOMADOR_COD_FONTE
                        , TOMADOR.DCLTOMADOR.TOMADOR_NUM_PROPOSTA
                    );

                    /*" -2688- MOVE APOLICES-COD-PRODUTO TO WS-COD-PRODUTO */
                    _.Move(APOLICES.DCLAPOLICES.APOLICES_COD_PRODUTO, WS_DESCR_TOMADOR.WS_COD_PRODUTO);

                    /*" -2689- MOVE WS-DESCR-TOMADOR TO CLIENTES-NOME-RAZAO */
                    _.Move(WS_DESCR_TOMADOR, CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO);

                    /*" -2690- GO TO R2230-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R2230_99_SAIDA*/ //GOTO
                    return;

                    /*" -2691- ELSE */
                }
                else
                {


                    /*" -2692- DISPLAY 'ERRO NO SELECT DA TOMADOR' */
                    _.Display($"ERRO NO SELECT DA TOMADOR");

                    /*" -2693- DISPLAY 'COD FONTE....: ' TOMADOR-COD-FONTE */
                    _.Display($"COD FONTE....: {TOMADOR.DCLTOMADOR.TOMADOR_COD_FONTE}");

                    /*" -2694- DISPLAY 'PROPOSTA.....: ' TOMADOR-NUM-PROPOSTA */
                    _.Display($"PROPOSTA.....: {TOMADOR.DCLTOMADOR.TOMADOR_NUM_PROPOSTA}");

                    /*" -2695- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2696- END-IF */
                }


                /*" -2698- END-IF. */
            }


        }

        [StopWatch]
        /*" R2230-00-SELECT-TOMADOR-DB-SELECT-1 */
        public void R2230_00_SELECT_TOMADOR_DB_SELECT_1()
        {
            /*" -2681- EXEC SQL SELECT T.COD_FONTE , T.NUM_PROPOSTA , T.COD_CLIENTE , C.NOME_RAZAO INTO :TOMADOR-COD-FONTE , :TOMADOR-NUM-PROPOSTA , :TOMADOR-COD-CLIENTE , :CLIENTES-NOME-RAZAO FROM SEGUROS.TOMADOR T , SEGUROS.CLIENTES C WHERE T.COD_FONTE = :TOMADOR-COD-FONTE AND T.NUM_PROPOSTA = :TOMADOR-NUM-PROPOSTA AND C.COD_CLIENTE = T.COD_CLIENTE WITH UR END-EXEC. */

            var r2230_00_SELECT_TOMADOR_DB_SELECT_1_Query1 = new R2230_00_SELECT_TOMADOR_DB_SELECT_1_Query1()
            {
                TOMADOR_NUM_PROPOSTA = TOMADOR.DCLTOMADOR.TOMADOR_NUM_PROPOSTA.ToString(),
                TOMADOR_COD_FONTE = TOMADOR.DCLTOMADOR.TOMADOR_COD_FONTE.ToString(),
            };

            var executed_1 = R2230_00_SELECT_TOMADOR_DB_SELECT_1_Query1.Execute(r2230_00_SELECT_TOMADOR_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.TOMADOR_COD_FONTE, TOMADOR.DCLTOMADOR.TOMADOR_COD_FONTE);
                _.Move(executed_1.TOMADOR_NUM_PROPOSTA, TOMADOR.DCLTOMADOR.TOMADOR_NUM_PROPOSTA);
                _.Move(executed_1.TOMADOR_COD_CLIENTE, TOMADOR.DCLTOMADOR.TOMADOR_COD_CLIENTE);
                _.Move(executed_1.CLIENTES_NOME_RAZAO, CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2230_99_SAIDA*/

        [StopWatch]
        /*" R2300-00-INCLUI-FENAUT1-SECTION */
        private void R2300_00_INCLUI_FENAUT1_SECTION()
        {
            /*" -2710- MOVE '2300' TO WNR-EXEC-SQL. */
            _.Move("2300", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2712- MOVE SPACES TO WFIM-V1AUTOCOBER */
            _.Move("", AREA_DE_WORK.WFIM_V1AUTOCOBER);

            /*" -2714- PERFORM R2310-00-DECLARE-V1AUTOCOBER */

            R2310_00_DECLARE_V1AUTOCOBER_SECTION();

            /*" -2715- PERFORM R2320-00-CRIA-FENAUT1 UNTIL WFIM-V1AUTOCOBER NOT EQUAL SPACES. */

            while (!(!AREA_DE_WORK.WFIM_V1AUTOCOBER.IsEmpty()))
            {

                R2320_00_CRIA_FENAUT1_SECTION();
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2300_99_SAIDA*/

        [StopWatch]
        /*" R2310-00-DECLARE-V1AUTOCOBER-SECTION */
        private void R2310_00_DECLARE_V1AUTOCOBER_SECTION()
        {
            /*" -2725- MOVE '2310' TO WNR-EXEC-SQL. */
            _.Move("2310", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2735- PERFORM R2310_00_DECLARE_V1AUTOCOBER_DB_DECLARE_1 */

            R2310_00_DECLARE_V1AUTOCOBER_DB_DECLARE_1();

            /*" -2737- PERFORM R2310_00_DECLARE_V1AUTOCOBER_DB_OPEN_1 */

            R2310_00_DECLARE_V1AUTOCOBER_DB_OPEN_1();

            /*" -2740- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2741- DISPLAY 'R2310-00 (ERRO NO DECLARE V1AUTOCOBER)' */
                _.Display($"R2310-00 (ERRO NO DECLARE V1AUTOCOBER)");

                /*" -2742- DISPLAY 'APOLICE   = ' V1ENDO-NUMAPOL */
                _.Display($"APOLICE   = {V1ENDO_NUMAPOL}");

                /*" -2743- DISPLAY 'ENDOSSO   = ' V1ENDO-NRENDOS */
                _.Display($"ENDOSSO   = {V1ENDO_NRENDOS}");

                /*" -2744- DISPLAY 'ITEM      = ' V1AUTO-NRITEM */
                _.Display($"ITEM      = {V1AUTO_NRITEM}");

                /*" -2744- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2310-00-DECLARE-V1AUTOCOBER-DB-OPEN-1 */
        public void R2310_00_DECLARE_V1AUTOCOBER_DB_OPEN_1()
        {
            /*" -2737- EXEC SQL OPEN V1AUTOCOBER END-EXEC. */

            V1AUTOCOBER.Open();

        }

        [StopWatch]
        /*" R3000-00-PROCESSA-VIDA-DB-DECLARE-1 */
        public void R3000_00_PROCESSA_VIDA_DB_DECLARE_1()
        {
            /*" -2846- EXEC SQL DECLARE V1FATURA CURSOR FOR SELECT A.NUM_APOLICE , A.COD_SUBGRUPO , A.NUM_FATURA , A.COD_OPERACAO , A.QTD_VIDAS_VG , A.QTD_VIDAS_AP , A.IMP_MORNATU , A.IMP_MORACID , A.IMP_INVPERM , A.IMP_AMDS , A.IMP_DH , A.IMP_DIT , A.PRM_VG , A.PRM_AP FROM SEGUROS.V1FATURASTOT A, SEGUROS.V1FATURAS B WHERE B.NUM_APOLICE = :V1ENDO-NUMAPOL AND B.NUM_ENDOSSO = :V1ENDO-NRENDOS AND B.NUM_APOLICE = A.NUM_APOLICE AND B.COD_SUBGRUPO = A.COD_SUBGRUPO AND B.NUM_FATURA = A.NUM_FATURA WITH UR END-EXEC. */
            V1FATURA = new FN0301B_V1FATURA(true);
            string GetQuery_V1FATURA()
            {
                var query = @$"SELECT A.NUM_APOLICE
							, 
							A.COD_SUBGRUPO
							, 
							A.NUM_FATURA
							, 
							A.COD_OPERACAO
							, 
							A.QTD_VIDAS_VG
							, 
							A.QTD_VIDAS_AP
							, 
							A.IMP_MORNATU
							, 
							A.IMP_MORACID
							, 
							A.IMP_INVPERM
							, 
							A.IMP_AMDS
							, 
							A.IMP_DH
							, 
							A.IMP_DIT
							, 
							A.PRM_VG
							, 
							A.PRM_AP 
							FROM SEGUROS.V1FATURASTOT A
							, 
							SEGUROS.V1FATURAS B 
							WHERE B.NUM_APOLICE = '{V1ENDO_NUMAPOL}' 
							AND B.NUM_ENDOSSO = '{V1ENDO_NRENDOS}' 
							AND B.NUM_APOLICE = A.NUM_APOLICE 
							AND B.COD_SUBGRUPO = A.COD_SUBGRUPO 
							AND B.NUM_FATURA = A.NUM_FATURA";

                return query;
            }
            V1FATURA.GetQueryEvent += GetQuery_V1FATURA;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2310_99_SAIDA*/

        [StopWatch]
        /*" R2320-00-CRIA-FENAUT1-SECTION */
        private void R2320_00_CRIA_FENAUT1_SECTION()
        {
            /*" -2757- MOVE '2320' TO WNR-EXEC-SQL. */
            _.Move("2320", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2762- PERFORM R2320_00_CRIA_FENAUT1_DB_FETCH_1 */

            R2320_00_CRIA_FENAUT1_DB_FETCH_1();

            /*" -2765- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2766- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2767- MOVE 'S' TO WFIM-V1AUTOCOBER */
                    _.Move("S", AREA_DE_WORK.WFIM_V1AUTOCOBER);

                    /*" -2767- PERFORM R2320_00_CRIA_FENAUT1_DB_CLOSE_1 */

                    R2320_00_CRIA_FENAUT1_DB_CLOSE_1();

                    /*" -2769- GO TO R2320-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R2320_99_SAIDA*/ //GOTO
                    return;

                    /*" -2770- ELSE */
                }
                else
                {


                    /*" -2771- DISPLAY 'R2320-00 (ERRO NO FETCH V1AUTOCOBER)' */
                    _.Display($"R2320-00 (ERRO NO FETCH V1AUTOCOBER)");

                    /*" -2772- DISPLAY 'APOLICE   = ' V1ENDO-NUMAPOL */
                    _.Display($"APOLICE   = {V1ENDO_NUMAPOL}");

                    /*" -2773- DISPLAY 'ENDOSSO   = ' V1ENDO-NRENDOS */
                    _.Display($"ENDOSSO   = {V1ENDO_NRENDOS}");

                    /*" -2774- DISPLAY 'ITEM      = ' V1AUTO-NRITEM */
                    _.Display($"ITEM      = {V1AUTO_NRITEM}");

                    /*" -2776- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -2776- PERFORM R2321-00-GRAVA-FENAUT1. */

            R2321_00_GRAVA_FENAUT1_SECTION();

        }

        [StopWatch]
        /*" R2320-00-CRIA-FENAUT1-DB-FETCH-1 */
        public void R2320_00_CRIA_FENAUT1_DB_FETCH_1()
        {
            /*" -2762- EXEC SQL FETCH V1AUTOCOBER INTO :V1AUCB-RAMOFR , :V1AUCB-CODCOBER , :V1AUCB-IMP-SEG-IX, :V1AUCB-PRM-TAR-VAR END-EXEC. */

            if (V1AUTOCOBER.Fetch())
            {
                _.Move(V1AUTOCOBER.V1AUCB_RAMOFR, V1AUCB_RAMOFR);
                _.Move(V1AUTOCOBER.V1AUCB_CODCOBER, V1AUCB_CODCOBER);
                _.Move(V1AUTOCOBER.V1AUCB_IMP_SEG_IX, V1AUCB_IMP_SEG_IX);
                _.Move(V1AUTOCOBER.V1AUCB_PRM_TAR_VAR, V1AUCB_PRM_TAR_VAR);
            }

        }

        [StopWatch]
        /*" R2320-00-CRIA-FENAUT1-DB-CLOSE-1 */
        public void R2320_00_CRIA_FENAUT1_DB_CLOSE_1()
        {
            /*" -2767- EXEC SQL CLOSE V1AUTOCOBER END-EXEC */

            V1AUTOCOBER.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2320_99_SAIDA*/

        [StopWatch]
        /*" R2321-00-GRAVA-FENAUT1-SECTION */
        private void R2321_00_GRAVA_FENAUT1_SECTION()
        {
            /*" -2786- MOVE '2321' TO WNR-EXEC-SQL. */
            _.Move("2321", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2787- MOVE V1ENDO-NUMAPOL TO FAU1-NUMAPOL */
            _.Move(V1ENDO_NUMAPOL, WREG_FENAUT1.FAU1_NUMAPOL);

            /*" -2788- MOVE V1ENDO-NRENDOS TO FAU1-NRENDOS */
            _.Move(V1ENDO_NRENDOS, WREG_FENAUT1.FAU1_NRENDOS);

            /*" -2789- MOVE V1TARI-DTINIVIG TO FAU1-DTINIVIG */
            _.Move(V1TARI_DTINIVIG, WREG_FENAUT1.FAU1_DTINIVIG);

            /*" -2790- MOVE V1TARI-DTTERVIG TO FAU1-DTTERVIG */
            _.Move(V1TARI_DTTERVIG, WREG_FENAUT1.FAU1_DTTERVIG);

            /*" -2792- MOVE V1AUTO-NRITEM TO FAU1-NRITEM */
            _.Move(V1AUTO_NRITEM, WREG_FENAUT1.FAU1_NRITEM);

            /*" -2793- MOVE V1AUCB-RAMOFR TO FAU1-RAMOCOBER */
            _.Move(V1AUCB_RAMOFR, WREG_FENAUT1.FAU1_RAMOCOBER);

            /*" -2794- MOVE V1AUCB-CODCOBER TO FAU1-CODCOBER */
            _.Move(V1AUCB_CODCOBER, WREG_FENAUT1.FAU1_CODCOBER);

            /*" -2795- MOVE V1AUCB-IMP-SEG-IX TO FAU1-IMP-SEGURADA */
            _.Move(V1AUCB_IMP_SEG_IX, WREG_FENAUT1.FAU1_IMP_SEGURADA);

            /*" -2797- MOVE V1AUCB-PRM-TAR-VAR TO FAU1-VLPRMLIQ */
            _.Move(V1AUCB_PRM_TAR_VAR, WREG_FENAUT1.FAU1_VLPRMLIQ);

            /*" -2798- IF V1AUCB-CODCOBER EQUAL 3101 */

            if (V1AUCB_CODCOBER == 3101)
            {

                /*" -2799- MOVE V1AUCB-IMP-SEG-IX TO FAU1-LIMINDENIZ */
                _.Move(V1AUCB_IMP_SEG_IX, WREG_FENAUT1.FAU1_LIMINDENIZ);

                /*" -2803- ADD V1TARI-VRFROBR-IX V1TARI-VRFRFACC-IX V1TARI-VRFRADIC-IX GIVING FAU1-VALFRANQ */
                WREG_FENAUT1.FAU1_VALFRANQ.Value = WREG_FENAUT1.FAU1_VALFRANQ + V1TARI_VRFROBR_IX;
                WREG_FENAUT1.FAU1_VALFRANQ.Value = WREG_FENAUT1.FAU1_VALFRANQ + V1TARI_VRFRFACC_IX;
                WREG_FENAUT1.FAU1_VALFRANQ.Value = WREG_FENAUT1.FAU1_VALFRANQ + V1TARI_VRFRADIC_IX;

                /*" -2804- ELSE */
            }
            else
            {


                /*" -2805- IF V1AUCB-CODCOBER EQUAL 3104 */

                if (V1AUCB_CODCOBER == 3104)
                {

                    /*" -2806- MOVE V1AUCB-IMP-SEG-IX TO FAU1-LIMINDENIZ */
                    _.Move(V1AUCB_IMP_SEG_IX, WREG_FENAUT1.FAU1_LIMINDENIZ);

                    /*" -2807- MOVE ZEROS TO FAU1-VALFRANQ */
                    _.Move(0, WREG_FENAUT1.FAU1_VALFRANQ);

                    /*" -2808- ELSE */
                }
                else
                {


                    /*" -2809- MOVE V1AUCB-IMP-SEG-IX TO FAU1-LIMINDENIZ */
                    _.Move(V1AUCB_IMP_SEG_IX, WREG_FENAUT1.FAU1_LIMINDENIZ);

                    /*" -2811- MOVE ZEROS TO FAU1-VALFRANQ. */
                    _.Move(0, WREG_FENAUT1.FAU1_VALFRANQ);
                }

            }


            /*" -2813- WRITE REG-FENAUT1 FROM WREG-FENAUT1. */
            _.Move(WREG_FENAUT1.GetMoveValues(), REG_FENAUT1);

            FENAUT1.Write(REG_FENAUT1.GetMoveValues().ToString());

            /*" -2813- ADD +1 TO AC-G-FENAUT1. */
            AREA_DE_WORK.AC_G_FENAUT1.Value = AREA_DE_WORK.AC_G_FENAUT1 + +1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2321_99_SAIDA*/

        [StopWatch]
        /*" R3000-00-PROCESSA-VIDA-SECTION */
        private void R3000_00_PROCESSA_VIDA_SECTION()
        {
            /*" -2823- MOVE '3000' TO WNR-EXEC-SQL. */
            _.Move("3000", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2846- PERFORM R3000_00_PROCESSA_VIDA_DB_DECLARE_1 */

            R3000_00_PROCESSA_VIDA_DB_DECLARE_1();

            /*" -2848- PERFORM R3000_00_PROCESSA_VIDA_DB_OPEN_1 */

            R3000_00_PROCESSA_VIDA_DB_OPEN_1();

            /*" -2851- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2852- DISPLAY 'R3000-00 (ERRO NO DECLARE V1FATURA)' */
                _.Display($"R3000-00 (ERRO NO DECLARE V1FATURA)");

                /*" -2853- DISPLAY 'APOLICE   = ' V1ENDO-NUMAPOL */
                _.Display($"APOLICE   = {V1ENDO_NUMAPOL}");

                /*" -2854- DISPLAY 'ENDOSSO   = ' V1ENDO-NRENDOS */
                _.Display($"ENDOSSO   = {V1ENDO_NRENDOS}");

                /*" -2855- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2857- END-IF. */
            }


            /*" -2859- MOVE SPACES TO WFIM-V1FATURAS */
            _.Move("", AREA_DE_WORK.WFIM_V1FATURAS);

            /*" -2861- PERFORM R3100-00-FETCH-V1FATURTOT */

            R3100_00_FETCH_V1FATURTOT_SECTION();

            /*" -2862- PERFORM R3200-00-CRIA-FENVIDA UNTIL WFIM-V1FATURAS NOT EQUAL SPACES. */

            while (!(!AREA_DE_WORK.WFIM_V1FATURAS.IsEmpty()))
            {

                R3200_00_CRIA_FENVIDA_SECTION();
            }

        }

        [StopWatch]
        /*" R3000-00-PROCESSA-VIDA-DB-OPEN-1 */
        public void R3000_00_PROCESSA_VIDA_DB_OPEN_1()
        {
            /*" -2848- EXEC SQL OPEN V1FATURA END-EXEC. */

            V1FATURA.Open();

        }

        [StopWatch]
        /*" R5000-00-PROCESSA-OUTROS-DB-DECLARE-1 */
        public void R5000_00_PROCESSA_OUTROS_DB_DECLARE_1()
        {
            /*" -3011- EXEC SQL DECLARE V1COBERAPOL CURSOR FOR SELECT NUM_ITEM , RAMOFR , COD_COBERTURA, DATA_INIVIGENCIA, DATA_TERVIGENCIA, IMP_SEGURADA_IX, PRM_TARIFARIO_VAR FROM SEGUROS.V1COBERAPOL WHERE NUM_APOLICE = :V1ENDO-NUMAPOL AND NRENDOS = :V1ENDO-NRENDOS WITH UR END-EXEC. */
            V1COBERAPOL = new FN0301B_V1COBERAPOL(true);
            string GetQuery_V1COBERAPOL()
            {
                var query = @$"SELECT NUM_ITEM
							, 
							RAMOFR
							, 
							COD_COBERTURA
							, 
							DATA_INIVIGENCIA
							, 
							DATA_TERVIGENCIA
							, 
							IMP_SEGURADA_IX
							, 
							PRM_TARIFARIO_VAR 
							FROM SEGUROS.V1COBERAPOL 
							WHERE NUM_APOLICE = '{V1ENDO_NUMAPOL}' 
							AND NRENDOS = '{V1ENDO_NRENDOS}'";

                return query;
            }
            V1COBERAPOL.GetQueryEvent += GetQuery_V1COBERAPOL;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_99_SAIDA*/

        [StopWatch]
        /*" R3100-00-FETCH-V1FATURTOT-SECTION */
        private void R3100_00_FETCH_V1FATURTOT_SECTION()
        {
            /*" -2874- MOVE '3100' TO WNR-EXEC-SQL. */
            _.Move("3100", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2889- PERFORM R3100_00_FETCH_V1FATURTOT_DB_FETCH_1 */

            R3100_00_FETCH_V1FATURTOT_DB_FETCH_1();

            /*" -2892- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -2893- MOVE 'S' TO WFIM-V1FATURAS */
                _.Move("S", AREA_DE_WORK.WFIM_V1FATURAS);

                /*" -2893- PERFORM R3100_00_FETCH_V1FATURTOT_DB_CLOSE_1 */

                R3100_00_FETCH_V1FATURTOT_DB_CLOSE_1();

                /*" -2894- END-IF. */
            }


        }

        [StopWatch]
        /*" R3100-00-FETCH-V1FATURTOT-DB-FETCH-1 */
        public void R3100_00_FETCH_V1FATURTOT_DB_FETCH_1()
        {
            /*" -2889- EXEC SQL FETCH V1FATURA INTO :V1FATT-NUMAPOL , :V1FATT-CODSUBES , :V1FATT-NUM-FATUR , :V1FATT-COD-OPER , :V1FATT-QT-VIDA-VG , :V1FATT-QT-VIDA-AP , :V1FATT-IMP-MORNAT , :V1FATT-IMP-MORACI , :V1FATT-IMP-INVPER , :V1FATT-IMP-AMDS , :V1FATT-IMP-DH , :V1FATT-IMP-DIT , :V1FATT-PRM-VG , :V1FATT-PRM-AP END-EXEC. */

            if (V1FATURA.Fetch())
            {
                _.Move(V1FATURA.V1FATT_NUMAPOL, V1FATT_NUMAPOL);
                _.Move(V1FATURA.V1FATT_CODSUBES, V1FATT_CODSUBES);
                _.Move(V1FATURA.V1FATT_NUM_FATUR, V1FATT_NUM_FATUR);
                _.Move(V1FATURA.V1FATT_COD_OPER, V1FATT_COD_OPER);
                _.Move(V1FATURA.V1FATT_QT_VIDA_VG, V1FATT_QT_VIDA_VG);
                _.Move(V1FATURA.V1FATT_QT_VIDA_AP, V1FATT_QT_VIDA_AP);
                _.Move(V1FATURA.V1FATT_IMP_MORNAT, V1FATT_IMP_MORNAT);
                _.Move(V1FATURA.V1FATT_IMP_MORACI, V1FATT_IMP_MORACI);
                _.Move(V1FATURA.V1FATT_IMP_INVPER, V1FATT_IMP_INVPER);
                _.Move(V1FATURA.V1FATT_IMP_AMDS, V1FATT_IMP_AMDS);
                _.Move(V1FATURA.V1FATT_IMP_DH, V1FATT_IMP_DH);
                _.Move(V1FATURA.V1FATT_IMP_DIT, V1FATT_IMP_DIT);
                _.Move(V1FATURA.V1FATT_PRM_VG, V1FATT_PRM_VG);
                _.Move(V1FATURA.V1FATT_PRM_AP, V1FATT_PRM_AP);
            }

        }

        [StopWatch]
        /*" R3100-00-FETCH-V1FATURTOT-DB-CLOSE-1 */
        public void R3100_00_FETCH_V1FATURTOT_DB_CLOSE_1()
        {
            /*" -2893- EXEC SQL CLOSE V1FATURA END-EXEC */

            V1FATURA.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3100_99_SAIDA*/

        [StopWatch]
        /*" R3200-00-CRIA-FENVIDA-SECTION */
        private void R3200_00_CRIA_FENVIDA_SECTION()
        {
            /*" -2906- MOVE '3200' TO WNR-EXEC-SQL. */
            _.Move("3200", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2907- MOVE V1ENDO-NUMAPOL TO FVID-NUMAPOL */
            _.Move(V1ENDO_NUMAPOL, WREG_FENVIDA.FVID_NUMAPOL);

            /*" -2908- MOVE V1ENDO-NRENDOS TO FVID-NRENDOS */
            _.Move(V1ENDO_NRENDOS, WREG_FENVIDA.FVID_NRENDOS);

            /*" -2909- MOVE V1FATT-COD-OPER TO FVID-CODOPER */
            _.Move(V1FATT_COD_OPER, WREG_FENVIDA.FVID_CODOPER);

            /*" -2911- MOVE V1ENDO-RAMO TO FVID-CODRAMO */
            _.Move(V1ENDO_RAMO, WREG_FENVIDA.FVID_CODRAMO);

            /*" -2912- IF V1FATT-QT-VIDA-AP EQUAL ZEROS */

            if (V1FATT_QT_VIDA_AP == 00)
            {

                /*" -2913- MOVE V1FATT-QT-VIDA-VG TO FVID-QTDVIDAS */
                _.Move(V1FATT_QT_VIDA_VG, WREG_FENVIDA.FVID_QTDVIDAS);

                /*" -2914- ELSE */
            }
            else
            {


                /*" -2915- IF V1FATT-QT-VIDA-VG EQUAL ZEROS */

                if (V1FATT_QT_VIDA_VG == 00)
                {

                    /*" -2916- MOVE V1FATT-QT-VIDA-AP TO FVID-QTDVIDAS */
                    _.Move(V1FATT_QT_VIDA_AP, WREG_FENVIDA.FVID_QTDVIDAS);

                    /*" -2917- ELSE */
                }
                else
                {


                    /*" -2919- MOVE V1FATT-QT-VIDA-VG TO FVID-QTDVIDAS. */
                    _.Move(V1FATT_QT_VIDA_VG, WREG_FENVIDA.FVID_QTDVIDAS);
                }

            }


            /*" -2921- ADD V1FATT-PRM-VG V1FATT-PRM-AP GIVING FVID-VLPRMLIQ */
            WREG_FENVIDA.FVID_VLPRMLIQ.Value = WREG_FENVIDA.FVID_VLPRMLIQ + V1FATT_PRM_VG;
            WREG_FENVIDA.FVID_VLPRMLIQ.Value = WREG_FENVIDA.FVID_VLPRMLIQ + V1FATT_PRM_AP;

            /*" -2922- MOVE V1FATT-NUM-FATUR TO FVID-NUMFATUR */
            _.Move(V1FATT_NUM_FATUR, WREG_FENVIDA.FVID_NUMFATUR);

            /*" -2923- MOVE V1FATT-CODSUBES TO FVID-CODSUBES */
            _.Move(V1FATT_CODSUBES, WREG_FENVIDA.FVID_CODSUBES);

            /*" -2925- MOVE V1ENDO-FONTE TO FVID-FONTE */
            _.Move(V1ENDO_FONTE, WREG_FENVIDA.FVID_FONTE);

            /*" -2926- PERFORM R3250-00-BUSCA-PERIPGTO. */

            R3250_00_BUSCA_PERIPGTO_SECTION();

            /*" -2927- INITIALIZE FVID-DESC-PERIPGTO. */
            _.Initialize(
                WREG_FENVIDA.FVID_DESC_PERIPGTO
            );

            /*" -2928- IF PRODUVG-PERI-PAGAMENTO EQUAL 99 */

            if (PRODUVG.DCLPRODUTOS_VG.PRODUVG_PERI_PAGAMENTO == 99)
            {

                /*" -2929- MOVE SPACES TO FVID-PERIPGTO */
                _.Move("", WREG_FENVIDA.FVID_PERIPGTO);

                /*" -2930- ELSE */
            }
            else
            {


                /*" -2931- MOVE WPERI-PGTO TO FVID-PERIPGTO */
                _.Move(WPERI_PGTO, WREG_FENVIDA.FVID_PERIPGTO);

                /*" -2933- END-IF. */
            }


            /*" -2934- EVALUATE PRODUVG-PERI-PAGAMENTO */
            switch (PRODUVG.DCLPRODUTOS_VG.PRODUVG_PERI_PAGAMENTO.Value)
            {

                /*" -2935- WHEN  0 */
                case 0:

                    /*" -2936- MOVE 'A VISTA' TO FVID-DESC-PERIPGTO */
                    _.Move("A VISTA", WREG_FENVIDA.FVID_DESC_PERIPGTO);

                    /*" -2937- WHEN  1 */
                    break;
                case 1:

                    /*" -2938- MOVE 'MENSAL' TO FVID-DESC-PERIPGTO */
                    _.Move("MENSAL", WREG_FENVIDA.FVID_DESC_PERIPGTO);

                    /*" -2939- WHEN  2 */
                    break;
                case 2:

                    /*" -2940- MOVE 'BIMESTRAL' TO FVID-DESC-PERIPGTO */
                    _.Move("BIMESTRAL", WREG_FENVIDA.FVID_DESC_PERIPGTO);

                    /*" -2941- WHEN  3 */
                    break;
                case 3:

                    /*" -2942- MOVE 'TRIMESTRAL' TO FVID-DESC-PERIPGTO */
                    _.Move("TRIMESTRAL", WREG_FENVIDA.FVID_DESC_PERIPGTO);

                    /*" -2943- WHEN  6 */
                    break;
                case 6:

                    /*" -2944- MOVE 'SEMESTRAL' TO FVID-DESC-PERIPGTO */
                    _.Move("SEMESTRAL", WREG_FENVIDA.FVID_DESC_PERIPGTO);

                    /*" -2945- WHEN  12 */
                    break;
                case 12:

                    /*" -2946- MOVE 'ANUAL' TO FVID-DESC-PERIPGTO */
                    _.Move("ANUAL", WREG_FENVIDA.FVID_DESC_PERIPGTO);

                    /*" -2947- WHEN OTHER */
                    break;
                default:

                    /*" -2948- MOVE 'NAO CADAST' TO FVID-DESC-PERIPGTO */
                    _.Move("NAO CADAST", WREG_FENVIDA.FVID_DESC_PERIPGTO);

                    /*" -2948- END-EVALUATE. */
                    break;
            }


            /*" -0- FLUXCONTROL_PERFORM R3200_SEGUE */

            R3200_SEGUE();

        }

        [StopWatch]
        /*" R3200-SEGUE */
        private void R3200_SEGUE(bool isPerform = false)
        {
            /*" -2953- WRITE REG-FENVIDA FROM WREG-FENVIDA. */
            _.Move(WREG_FENVIDA.GetMoveValues(), REG_FENVIDA);

            FENVIDA.Write(REG_FENVIDA.GetMoveValues().ToString());

            /*" -2955- ADD +1 TO AC-G-FENVIDA. */
            AREA_DE_WORK.AC_G_FENVIDA.Value = AREA_DE_WORK.AC_G_FENVIDA + +1;

            /*" -2955- PERFORM R3100-00-FETCH-V1FATURTOT. */

            R3100_00_FETCH_V1FATURTOT_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3200_99_SAIDA*/

        [StopWatch]
        /*" R3250-00-BUSCA-PERIPGTO-SECTION */
        private void R3250_00_BUSCA_PERIPGTO_SECTION()
        {
            /*" -2963- MOVE '3250' TO WNR-EXEC-SQL. */
            _.Move("3250", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2964- MOVE FVID-NUMAPOL TO PRODUVG-NUM-APOLICE. */
            _.Move(WREG_FENVIDA.FVID_NUMAPOL, PRODUVG.DCLPRODUTOS_VG.PRODUVG_NUM_APOLICE);

            /*" -2966- MOVE FVID-CODSUBES TO PRODUVG-COD-SUBGRUPO. */
            _.Move(WREG_FENVIDA.FVID_CODSUBES, PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_SUBGRUPO);

            /*" -2968- INITIALIZE WPERI-PGTO. */
            _.Initialize(
                WPERI_PGTO
            );

            /*" -2975- PERFORM R3250_00_BUSCA_PERIPGTO_DB_SELECT_1 */

            R3250_00_BUSCA_PERIPGTO_DB_SELECT_1();

            /*" -2978- IF SQLCODE EQUAL ZEROS OR -811 */

            if (DB.SQLCODE.In("00", "-811"))
            {

                /*" -2979- MOVE PRODUVG-PERI-PAGAMENTO TO PERI-PGTO-WS */
                _.Move(PRODUVG.DCLPRODUTOS_VG.PRODUVG_PERI_PAGAMENTO, WPERI_PGTO.PERI_PGTO_WS);

                /*" -2980- GO TO R3250-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3250_99_SAIDA*/ //GOTO
                return;

                /*" -2982- END-IF. */
            }


            /*" -2983- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -2984- MOVE 99 TO PRODUVG-PERI-PAGAMENTO */
                _.Move(99, PRODUVG.DCLPRODUTOS_VG.PRODUVG_PERI_PAGAMENTO);

                /*" -2985- GO TO R3250-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3250_99_SAIDA*/ //GOTO
                return;

                /*" -2986- ELSE */
            }
            else
            {


                /*" -2987- DISPLAY 'R3250-00 (ERRO SELECT PRODUTOS_VG)' */
                _.Display($"R3250-00 (ERRO SELECT PRODUTOS_VG)");

                /*" -2988- DISPLAY 'APOLICE   = ' FVID-NUMAPOL */
                _.Display($"APOLICE   = {WREG_FENVIDA.FVID_NUMAPOL}");

                /*" -2989- DISPLAY 'SUB GRUPO = ' FVID-CODSUBES */
                _.Display($"SUB GRUPO = {WREG_FENVIDA.FVID_CODSUBES}");

                /*" -2990- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2991- END-IF. */
            }


        }

        [StopWatch]
        /*" R3250-00-BUSCA-PERIPGTO-DB-SELECT-1 */
        public void R3250_00_BUSCA_PERIPGTO_DB_SELECT_1()
        {
            /*" -2975- EXEC SQL SELECT PERI_PAGAMENTO INTO :PRODUVG-PERI-PAGAMENTO FROM SEGUROS.PRODUTOS_VG WHERE NUM_APOLICE = :PRODUVG-NUM-APOLICE AND COD_SUBGRUPO = :PRODUVG-COD-SUBGRUPO WITH UR END-EXEC. */

            var r3250_00_BUSCA_PERIPGTO_DB_SELECT_1_Query1 = new R3250_00_BUSCA_PERIPGTO_DB_SELECT_1_Query1()
            {
                PRODUVG_COD_SUBGRUPO = PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_SUBGRUPO.ToString(),
                PRODUVG_NUM_APOLICE = PRODUVG.DCLPRODUTOS_VG.PRODUVG_NUM_APOLICE.ToString(),
            };

            var executed_1 = R3250_00_BUSCA_PERIPGTO_DB_SELECT_1_Query1.Execute(r3250_00_BUSCA_PERIPGTO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PRODUVG_PERI_PAGAMENTO, PRODUVG.DCLPRODUTOS_VG.PRODUVG_PERI_PAGAMENTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3250_99_SAIDA*/

        [StopWatch]
        /*" R5000-00-PROCESSA-OUTROS-SECTION */
        private void R5000_00_PROCESSA_OUTROS_SECTION()
        {
            /*" -2999- MOVE '5000' TO WNR-EXEC-SQL. */
            _.Move("5000", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3011- PERFORM R5000_00_PROCESSA_OUTROS_DB_DECLARE_1 */

            R5000_00_PROCESSA_OUTROS_DB_DECLARE_1();

            /*" -3013- PERFORM R5000_00_PROCESSA_OUTROS_DB_OPEN_1 */

            R5000_00_PROCESSA_OUTROS_DB_OPEN_1();

            /*" -3016- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3017- DISPLAY 'R5000-00 (ERRO NO DECLARE V1COBERAPOL)' */
                _.Display($"R5000-00 (ERRO NO DECLARE V1COBERAPOL)");

                /*" -3018- DISPLAY 'APOLICE   = ' V1ENDO-NUMAPOL */
                _.Display($"APOLICE   = {V1ENDO_NUMAPOL}");

                /*" -3019- DISPLAY 'ENDOSSO   = ' V1ENDO-NRENDOS */
                _.Display($"ENDOSSO   = {V1ENDO_NRENDOS}");

                /*" -3021- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3023- MOVE SPACES TO WFIM-V1COBERAPOL */
            _.Move("", AREA_DE_WORK.WFIM_V1COBERAPOL);

            /*" -3025- PERFORM R5100-00-FETCH-V1COBERAPOL */

            R5100_00_FETCH_V1COBERAPOL_SECTION();

            /*" -3026- PERFORM R5200-00-CRIA-FENOUTR UNTIL WFIM-V1COBERAPOL NOT EQUAL SPACES. */

            while (!(!AREA_DE_WORK.WFIM_V1COBERAPOL.IsEmpty()))
            {

                R5200_00_CRIA_FENOUTR_SECTION();
            }

        }

        [StopWatch]
        /*" R5000-00-PROCESSA-OUTROS-DB-OPEN-1 */
        public void R5000_00_PROCESSA_OUTROS_DB_OPEN_1()
        {
            /*" -3013- EXEC SQL OPEN V1COBERAPOL END-EXEC. */

            V1COBERAPOL.Open();

        }

        [StopWatch]
        /*" R6000-00-PROCESSA-OUTROS-DB-DECLARE-1 */
        public void R6000_00_PROCESSA_OUTROS_DB_DECLARE_1()
        {
            /*" -3106- EXEC SQL DECLARE V1OUTRCOBER CURSOR FOR SELECT NRRISCO , RAMOFR , COD_COBERTURA , DTINIVIG , DTTERVIG , IMP_SEGURADA_IX , PRM_TARIFARIO_VAR , VRFROBR_IX , LIMITE_INDENIZA_IX FROM SEGUROS.V1OUTROSCOBER WHERE NUM_APOLICE = :V1ENDO-NUMAPOL AND NRENDOS = :V1ENDO-NRENDOS WITH UR END-EXEC. */
            V1OUTRCOBER = new FN0301B_V1OUTRCOBER(true);
            string GetQuery_V1OUTRCOBER()
            {
                var query = @$"SELECT NRRISCO
							, 
							RAMOFR
							, 
							COD_COBERTURA
							, 
							DTINIVIG
							, 
							DTTERVIG
							, 
							IMP_SEGURADA_IX
							, 
							PRM_TARIFARIO_VAR
							, 
							VRFROBR_IX
							, 
							LIMITE_INDENIZA_IX 
							FROM SEGUROS.V1OUTROSCOBER 
							WHERE NUM_APOLICE = '{V1ENDO_NUMAPOL}' 
							AND NRENDOS = '{V1ENDO_NRENDOS}'";

                return query;
            }
            V1OUTRCOBER.GetQueryEvent += GetQuery_V1OUTRCOBER;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R5000_99_SAIDA*/

        [StopWatch]
        /*" R5100-00-FETCH-V1COBERAPOL-SECTION */
        private void R5100_00_FETCH_V1COBERAPOL_SECTION()
        {
            /*" -3036- MOVE '5100' TO WNR-EXEC-SQL. */
            _.Move("5100", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3044- PERFORM R5100_00_FETCH_V1COBERAPOL_DB_FETCH_1 */

            R5100_00_FETCH_V1COBERAPOL_DB_FETCH_1();

            /*" -3047- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3048- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -3049- MOVE 'S' TO WFIM-V1COBERAPOL */
                    _.Move("S", AREA_DE_WORK.WFIM_V1COBERAPOL);

                    /*" -3049- PERFORM R5100_00_FETCH_V1COBERAPOL_DB_CLOSE_1 */

                    R5100_00_FETCH_V1COBERAPOL_DB_CLOSE_1();

                    /*" -3051- GO TO R5100-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R5100_99_SAIDA*/ //GOTO
                    return;

                    /*" -3052- ELSE */
                }
                else
                {


                    /*" -3053- DISPLAY 'R5100-00 (ERRO NO FETCH V1COBERAPOL)' */
                    _.Display($"R5100-00 (ERRO NO FETCH V1COBERAPOL)");

                    /*" -3054- DISPLAY 'APOLICE   = ' V1ENDO-NUMAPOL */
                    _.Display($"APOLICE   = {V1ENDO_NUMAPOL}");

                    /*" -3055- DISPLAY 'ENDOSSO   = ' V1ENDO-NRENDOS */
                    _.Display($"ENDOSSO   = {V1ENDO_NRENDOS}");

                    /*" -3055- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R5100-00-FETCH-V1COBERAPOL-DB-FETCH-1 */
        public void R5100_00_FETCH_V1COBERAPOL_DB_FETCH_1()
        {
            /*" -3044- EXEC SQL FETCH V1COBERAPOL INTO :V1COBA-NRITEM , :V1COBA-RAMOFR , :V1COBA-CODCOBER , :V1COBA-DTINIVIG , :V1COBA-DTTERVIG , :V1COBA-IMP-SEG-IX, :V1COBA-PRM-TAR-VAR END-EXEC. */

            if (V1COBERAPOL.Fetch())
            {
                _.Move(V1COBERAPOL.V1COBA_NRITEM, V1COBA_NRITEM);
                _.Move(V1COBERAPOL.V1COBA_RAMOFR, V1COBA_RAMOFR);
                _.Move(V1COBERAPOL.V1COBA_CODCOBER, V1COBA_CODCOBER);
                _.Move(V1COBERAPOL.V1COBA_DTINIVIG, V1COBA_DTINIVIG);
                _.Move(V1COBERAPOL.V1COBA_DTTERVIG, V1COBA_DTTERVIG);
                _.Move(V1COBERAPOL.V1COBA_IMP_SEG_IX, V1COBA_IMP_SEG_IX);
                _.Move(V1COBERAPOL.V1COBA_PRM_TAR_VAR, V1COBA_PRM_TAR_VAR);
            }

        }

        [StopWatch]
        /*" R5100-00-FETCH-V1COBERAPOL-DB-CLOSE-1 */
        public void R5100_00_FETCH_V1COBERAPOL_DB_CLOSE_1()
        {
            /*" -3049- EXEC SQL CLOSE V1COBERAPOL END-EXEC */

            V1COBERAPOL.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R5100_99_SAIDA*/

        [StopWatch]
        /*" R5200-00-CRIA-FENOUTR-SECTION */
        private void R5200_00_CRIA_FENOUTR_SECTION()
        {
            /*" -3065- MOVE '5200' TO WNR-EXEC-SQL. */
            _.Move("5200", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3066- MOVE V1ENDO-NUMAPOL TO FOUR-NUMAPOL */
            _.Move(V1ENDO_NUMAPOL, WREG_FENOUTR.FOUR_NUMAPOL);

            /*" -3067- MOVE V1ENDO-NRENDOS TO FOUR-NRENDOS */
            _.Move(V1ENDO_NRENDOS, WREG_FENOUTR.FOUR_NRENDOS);

            /*" -3068- MOVE V1COBA-DTINIVIG TO FOUR-DTINIVIG */
            _.Move(V1COBA_DTINIVIG, WREG_FENOUTR.FOUR_DTINIVIG);

            /*" -3069- MOVE V1COBA-DTTERVIG TO FOUR-DTTERVIG */
            _.Move(V1COBA_DTTERVIG, WREG_FENOUTR.FOUR_DTTERVIG);

            /*" -3070- MOVE V1COBA-NRITEM TO FOUR-NRITEM */
            _.Move(V1COBA_NRITEM, WREG_FENOUTR.FOUR_NRITEM);

            /*" -3071- MOVE V1COBA-RAMOFR TO FOUR-RAMOCOBER */
            _.Move(V1COBA_RAMOFR, WREG_FENOUTR.FOUR_RAMOCOBER);

            /*" -3072- MOVE V1COBA-CODCOBER TO FOUR-CODCOBER */
            _.Move(V1COBA_CODCOBER, WREG_FENOUTR.FOUR_CODCOBER);

            /*" -3073- MOVE V1COBA-IMP-SEG-IX TO FOUR-IMP-SEGURADA */
            _.Move(V1COBA_IMP_SEG_IX, WREG_FENOUTR.FOUR_IMP_SEGURADA);

            /*" -3075- MOVE V1COBA-PRM-TAR-VAR TO FOUR-VLPRMLIQ */
            _.Move(V1COBA_PRM_TAR_VAR, WREG_FENOUTR.FOUR_VLPRMLIQ);

            /*" -3078- MOVE ZEROS TO FOUR-LIMINDENIZ FOUR-VALFRANQ */
            _.Move(0, WREG_FENOUTR.FOUR_LIMINDENIZ, WREG_FENOUTR.FOUR_VALFRANQ);

            /*" -3080- WRITE REG-FENOUTR FROM WREG-FENOUTR. */
            _.Move(WREG_FENOUTR.GetMoveValues(), REG_FENOUTR);

            FENOUTR.Write(REG_FENOUTR.GetMoveValues().ToString());

            /*" -3082- ADD +1 TO AC-G-FENOUTR. */
            AREA_DE_WORK.AC_G_FENOUTR.Value = AREA_DE_WORK.AC_G_FENOUTR + +1;

            /*" -3082- PERFORM R5100-00-FETCH-V1COBERAPOL. */

            R5100_00_FETCH_V1COBERAPOL_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R5200_99_SAIDA*/

        [StopWatch]
        /*" R6000-00-PROCESSA-OUTROS-SECTION */
        private void R6000_00_PROCESSA_OUTROS_SECTION()
        {
            /*" -3092- MOVE '6000' TO WNR-EXEC-SQL. */
            _.Move("6000", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3106- PERFORM R6000_00_PROCESSA_OUTROS_DB_DECLARE_1 */

            R6000_00_PROCESSA_OUTROS_DB_DECLARE_1();

            /*" -3108- PERFORM R6000_00_PROCESSA_OUTROS_DB_OPEN_1 */

            R6000_00_PROCESSA_OUTROS_DB_OPEN_1();

            /*" -3111- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3112- DISPLAY 'R6000-00 (ERRO NO DECLARE V1OUTRCOBER)' */
                _.Display($"R6000-00 (ERRO NO DECLARE V1OUTRCOBER)");

                /*" -3113- DISPLAY 'APOLICE   = ' V1ENDO-NUMAPOL */
                _.Display($"APOLICE   = {V1ENDO_NUMAPOL}");

                /*" -3114- DISPLAY 'ENDOSSO   = ' V1ENDO-NRENDOS */
                _.Display($"ENDOSSO   = {V1ENDO_NRENDOS}");

                /*" -3116- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3118- MOVE SPACES TO WFIM-V1OUTRCOBER */
            _.Move("", AREA_DE_WORK.WFIM_V1OUTRCOBER);

            /*" -3120- PERFORM R6100-00-FETCH-V1OUTRCOBER */

            R6100_00_FETCH_V1OUTRCOBER_SECTION();

            /*" -3121- PERFORM R6200-00-CRIA-FENOUTR UNTIL WFIM-V1OUTRCOBER NOT EQUAL SPACES. */

            while (!(!AREA_DE_WORK.WFIM_V1OUTRCOBER.IsEmpty()))
            {

                R6200_00_CRIA_FENOUTR_SECTION();
            }

        }

        [StopWatch]
        /*" R6000-00-PROCESSA-OUTROS-DB-OPEN-1 */
        public void R6000_00_PROCESSA_OUTROS_DB_OPEN_1()
        {
            /*" -3108- EXEC SQL OPEN V1OUTRCOBER END-EXEC. */

            V1OUTRCOBER.Open();

        }

        [StopWatch]
        /*" R6300-00-MR-APO-COBER-DB-DECLARE-1 */
        public void R6300_00_MR_APO_COBER_DB_DECLARE_1()
        {
            /*" -3203- EXEC SQL DECLARE MRAPCOBER CURSOR FOR SELECT NUM_ITEM , RAMO_COBERTURA , COD_COBERTURA , DTH_INI_VIG_COBER , DTH_FIM_VIG_COBER , IMP_SEGURADA_IX , PRM_TARIFARIO_VAR , VAL_MIN_FRANQ_IX , IMP_SEGURADA_IX FROM SEGUROS.MR_APOLICE_COBER WHERE NUM_APOLICE = :V1ENDO-NUMAPOL AND NUM_ENDOSSO = :V1ENDO-NRENDOS WITH UR END-EXEC. */
            MRAPCOBER = new FN0301B_MRAPCOBER(true);
            string GetQuery_MRAPCOBER()
            {
                var query = @$"SELECT NUM_ITEM
							, 
							RAMO_COBERTURA
							, 
							COD_COBERTURA
							, 
							DTH_INI_VIG_COBER
							, 
							DTH_FIM_VIG_COBER
							, 
							IMP_SEGURADA_IX
							, 
							PRM_TARIFARIO_VAR
							, 
							VAL_MIN_FRANQ_IX
							, 
							IMP_SEGURADA_IX 
							FROM SEGUROS.MR_APOLICE_COBER 
							WHERE NUM_APOLICE = '{V1ENDO_NUMAPOL}' 
							AND NUM_ENDOSSO = '{V1ENDO_NRENDOS}'";

                return query;
            }
            MRAPCOBER.GetQueryEvent += GetQuery_MRAPCOBER;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R6000_99_SAIDA*/

        [StopWatch]
        /*" R6100-00-FETCH-V1OUTRCOBER-SECTION */
        private void R6100_00_FETCH_V1OUTRCOBER_SECTION()
        {
            /*" -3131- MOVE '6100' TO WNR-EXEC-SQL. */
            _.Move("6100", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3141- PERFORM R6100_00_FETCH_V1OUTRCOBER_DB_FETCH_1 */

            R6100_00_FETCH_V1OUTRCOBER_DB_FETCH_1();

            /*" -3144- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3145- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -3146- MOVE 'S' TO WFIM-V1OUTRCOBER */
                    _.Move("S", AREA_DE_WORK.WFIM_V1OUTRCOBER);

                    /*" -3146- PERFORM R6100_00_FETCH_V1OUTRCOBER_DB_CLOSE_1 */

                    R6100_00_FETCH_V1OUTRCOBER_DB_CLOSE_1();

                    /*" -3148- GO TO R6100-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R6100_99_SAIDA*/ //GOTO
                    return;

                    /*" -3149- ELSE */
                }
                else
                {


                    /*" -3150- DISPLAY 'R6100-00 (ERRO NO FETCH V1OUTRCOBER)' */
                    _.Display($"R6100-00 (ERRO NO FETCH V1OUTRCOBER)");

                    /*" -3151- DISPLAY 'APOLICE   = ' V1ENDO-NUMAPOL */
                    _.Display($"APOLICE   = {V1ENDO_NUMAPOL}");

                    /*" -3152- DISPLAY 'ENDOSSO   = ' V1ENDO-NRENDOS */
                    _.Display($"ENDOSSO   = {V1ENDO_NRENDOS}");

                    /*" -3152- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R6100-00-FETCH-V1OUTRCOBER-DB-FETCH-1 */
        public void R6100_00_FETCH_V1OUTRCOBER_DB_FETCH_1()
        {
            /*" -3141- EXEC SQL FETCH V1OUTRCOBER INTO :V1OCOB-NRRISCO , :V1OCOB-RAMOFR , :V1OCOB-CODCOBER , :V1OCOB-DTINIVIG , :V1OCOB-DTTERVIG , :V1OCOB-IMP-SEG-IX , :V1OCOB-PRM-TAR-VAR , :V1OCOB-VRFROBR-IX , :V1OCOB-LIMINDENIZ END-EXEC. */

            if (V1OUTRCOBER.Fetch())
            {
                _.Move(V1OUTRCOBER.V1OCOB_NRRISCO, V1OCOB_NRRISCO);
                _.Move(V1OUTRCOBER.V1OCOB_RAMOFR, V1OCOB_RAMOFR);
                _.Move(V1OUTRCOBER.V1OCOB_CODCOBER, V1OCOB_CODCOBER);
                _.Move(V1OUTRCOBER.V1OCOB_DTINIVIG, V1OCOB_DTINIVIG);
                _.Move(V1OUTRCOBER.V1OCOB_DTTERVIG, V1OCOB_DTTERVIG);
                _.Move(V1OUTRCOBER.V1OCOB_IMP_SEG_IX, V1OCOB_IMP_SEG_IX);
                _.Move(V1OUTRCOBER.V1OCOB_PRM_TAR_VAR, V1OCOB_PRM_TAR_VAR);
                _.Move(V1OUTRCOBER.V1OCOB_VRFROBR_IX, V1OCOB_VRFROBR_IX);
                _.Move(V1OUTRCOBER.V1OCOB_LIMINDENIZ, V1OCOB_LIMINDENIZ);
            }

        }

        [StopWatch]
        /*" R6100-00-FETCH-V1OUTRCOBER-DB-CLOSE-1 */
        public void R6100_00_FETCH_V1OUTRCOBER_DB_CLOSE_1()
        {
            /*" -3146- EXEC SQL CLOSE V1OUTRCOBER END-EXEC */

            V1OUTRCOBER.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R6100_99_SAIDA*/

        [StopWatch]
        /*" R6200-00-CRIA-FENOUTR-SECTION */
        private void R6200_00_CRIA_FENOUTR_SECTION()
        {
            /*" -3162- MOVE '6200' TO WNR-EXEC-SQL. */
            _.Move("6200", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3163- MOVE V1ENDO-NUMAPOL TO FOUR-NUMAPOL */
            _.Move(V1ENDO_NUMAPOL, WREG_FENOUTR.FOUR_NUMAPOL);

            /*" -3164- MOVE V1ENDO-NRENDOS TO FOUR-NRENDOS */
            _.Move(V1ENDO_NRENDOS, WREG_FENOUTR.FOUR_NRENDOS);

            /*" -3165- MOVE V1OCOB-DTINIVIG TO FOUR-DTINIVIG */
            _.Move(V1OCOB_DTINIVIG, WREG_FENOUTR.FOUR_DTINIVIG);

            /*" -3166- MOVE V1OCOB-DTTERVIG TO FOUR-DTTERVIG */
            _.Move(V1OCOB_DTTERVIG, WREG_FENOUTR.FOUR_DTTERVIG);

            /*" -3167- MOVE V1OCOB-NRRISCO TO FOUR-NRITEM */
            _.Move(V1OCOB_NRRISCO, WREG_FENOUTR.FOUR_NRITEM);

            /*" -3168- MOVE V1OCOB-RAMOFR TO FOUR-RAMOCOBER */
            _.Move(V1OCOB_RAMOFR, WREG_FENOUTR.FOUR_RAMOCOBER);

            /*" -3169- MOVE V1OCOB-CODCOBER TO FOUR-CODCOBER */
            _.Move(V1OCOB_CODCOBER, WREG_FENOUTR.FOUR_CODCOBER);

            /*" -3170- MOVE V1OCOB-IMP-SEG-IX TO FOUR-IMP-SEGURADA */
            _.Move(V1OCOB_IMP_SEG_IX, WREG_FENOUTR.FOUR_IMP_SEGURADA);

            /*" -3171- MOVE V1OCOB-PRM-TAR-VAR TO FOUR-VLPRMLIQ */
            _.Move(V1OCOB_PRM_TAR_VAR, WREG_FENOUTR.FOUR_VLPRMLIQ);

            /*" -3172- MOVE V1OCOB-VRFROBR-IX TO FOUR-VALFRANQ */
            _.Move(V1OCOB_VRFROBR_IX, WREG_FENOUTR.FOUR_VALFRANQ);

            /*" -3174- MOVE V1OCOB-LIMINDENIZ TO FOUR-LIMINDENIZ. */
            _.Move(V1OCOB_LIMINDENIZ, WREG_FENOUTR.FOUR_LIMINDENIZ);

            /*" -3176- WRITE REG-FENOUTR FROM WREG-FENOUTR. */
            _.Move(WREG_FENOUTR.GetMoveValues(), REG_FENOUTR);

            FENOUTR.Write(REG_FENOUTR.GetMoveValues().ToString());

            /*" -3178- ADD +1 TO AC-G-FENOUTR. */
            AREA_DE_WORK.AC_G_FENOUTR.Value = AREA_DE_WORK.AC_G_FENOUTR + +1;

            /*" -3178- PERFORM R6100-00-FETCH-V1OUTRCOBER. */

            R6100_00_FETCH_V1OUTRCOBER_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R6200_99_SAIDA*/

        [StopWatch]
        /*" R6300-00-MR-APO-COBER-SECTION */
        private void R6300_00_MR_APO_COBER_SECTION()
        {
            /*" -3189- MOVE '6300' TO WNR-EXEC-SQL. */
            _.Move("6300", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3203- PERFORM R6300_00_MR_APO_COBER_DB_DECLARE_1 */

            R6300_00_MR_APO_COBER_DB_DECLARE_1();

            /*" -3205- PERFORM R6300_00_MR_APO_COBER_DB_OPEN_1 */

            R6300_00_MR_APO_COBER_DB_OPEN_1();

            /*" -3208- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3209- DISPLAY 'R6300-00 (ERRO NO DECLARE MRAPCOBER)' */
                _.Display($"R6300-00 (ERRO NO DECLARE MRAPCOBER)");

                /*" -3210- DISPLAY 'APOLICE   = ' V1ENDO-NUMAPOL */
                _.Display($"APOLICE   = {V1ENDO_NUMAPOL}");

                /*" -3211- DISPLAY 'ENDOSSO   = ' V1ENDO-NRENDOS */
                _.Display($"ENDOSSO   = {V1ENDO_NRENDOS}");

                /*" -3213- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3215- MOVE SPACES TO WFIM-MRAPCOBER */
            _.Move("", AREA_DE_WORK.WFIM_MRAPCOBER);

            /*" -3217- PERFORM R6400-00-FETCH-MRAPCOBER */

            R6400_00_FETCH_MRAPCOBER_SECTION();

            /*" -3218- PERFORM R6500-00-CRIA-FENOUTR UNTIL WFIM-MRAPCOBER NOT EQUAL SPACES. */

            while (!(!AREA_DE_WORK.WFIM_MRAPCOBER.IsEmpty()))
            {

                R6500_00_CRIA_FENOUTR_SECTION();
            }

        }

        [StopWatch]
        /*" R6300-00-MR-APO-COBER-DB-OPEN-1 */
        public void R6300_00_MR_APO_COBER_DB_OPEN_1()
        {
            /*" -3205- EXEC SQL OPEN MRAPCOBER END-EXEC. */

            MRAPCOBER.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R6300_99_SAIDA*/

        [StopWatch]
        /*" R6400-00-FETCH-MRAPCOBER-SECTION */
        private void R6400_00_FETCH_MRAPCOBER_SECTION()
        {
            /*" -3229- MOVE '6400' TO WNR-EXEC-SQL. */
            _.Move("6400", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3239- PERFORM R6400_00_FETCH_MRAPCOBER_DB_FETCH_1 */

            R6400_00_FETCH_MRAPCOBER_DB_FETCH_1();

            /*" -3242- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3243- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -3244- MOVE 'S' TO WFIM-MRAPCOBER */
                    _.Move("S", AREA_DE_WORK.WFIM_MRAPCOBER);

                    /*" -3244- PERFORM R6400_00_FETCH_MRAPCOBER_DB_CLOSE_1 */

                    R6400_00_FETCH_MRAPCOBER_DB_CLOSE_1();

                    /*" -3246- GO TO R6400-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R6400_99_SAIDA*/ //GOTO
                    return;

                    /*" -3247- ELSE */
                }
                else
                {


                    /*" -3248- DISPLAY 'R6400-00 (ERRO NO FETCH MRAPCOBER)' */
                    _.Display($"R6400-00 (ERRO NO FETCH MRAPCOBER)");

                    /*" -3249- DISPLAY 'APOLICE   = ' V1ENDO-NUMAPOL */
                    _.Display($"APOLICE   = {V1ENDO_NUMAPOL}");

                    /*" -3250- DISPLAY 'ENDOSSO   = ' V1ENDO-NRENDOS */
                    _.Display($"ENDOSSO   = {V1ENDO_NRENDOS}");

                    /*" -3250- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R6400-00-FETCH-MRAPCOBER-DB-FETCH-1 */
        public void R6400_00_FETCH_MRAPCOBER_DB_FETCH_1()
        {
            /*" -3239- EXEC SQL FETCH MRAPCOBER INTO :V1OCOB-NRRISCO , :V1OCOB-RAMOFR , :V1OCOB-CODCOBER , :V1OCOB-DTINIVIG , :V1OCOB-DTTERVIG , :V1OCOB-IMP-SEG-IX , :V1OCOB-PRM-TAR-VAR , :V1OCOB-VRFROBR-IX , :V1OCOB-LIMINDENIZ END-EXEC. */

            if (MRAPCOBER.Fetch())
            {
                _.Move(MRAPCOBER.V1OCOB_NRRISCO, V1OCOB_NRRISCO);
                _.Move(MRAPCOBER.V1OCOB_RAMOFR, V1OCOB_RAMOFR);
                _.Move(MRAPCOBER.V1OCOB_CODCOBER, V1OCOB_CODCOBER);
                _.Move(MRAPCOBER.V1OCOB_DTINIVIG, V1OCOB_DTINIVIG);
                _.Move(MRAPCOBER.V1OCOB_DTTERVIG, V1OCOB_DTTERVIG);
                _.Move(MRAPCOBER.V1OCOB_IMP_SEG_IX, V1OCOB_IMP_SEG_IX);
                _.Move(MRAPCOBER.V1OCOB_PRM_TAR_VAR, V1OCOB_PRM_TAR_VAR);
                _.Move(MRAPCOBER.V1OCOB_VRFROBR_IX, V1OCOB_VRFROBR_IX);
                _.Move(MRAPCOBER.V1OCOB_LIMINDENIZ, V1OCOB_LIMINDENIZ);
            }

        }

        [StopWatch]
        /*" R6400-00-FETCH-MRAPCOBER-DB-CLOSE-1 */
        public void R6400_00_FETCH_MRAPCOBER_DB_CLOSE_1()
        {
            /*" -3244- EXEC SQL CLOSE MRAPCOBER END-EXEC */

            MRAPCOBER.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R6400_99_SAIDA*/

        [StopWatch]
        /*" R6500-00-CRIA-FENOUTR-SECTION */
        private void R6500_00_CRIA_FENOUTR_SECTION()
        {
            /*" -3261- MOVE '6500' TO WNR-EXEC-SQL. */
            _.Move("6500", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3262- MOVE V1ENDO-NUMAPOL TO FOUR-NUMAPOL */
            _.Move(V1ENDO_NUMAPOL, WREG_FENOUTR.FOUR_NUMAPOL);

            /*" -3263- MOVE V1ENDO-NRENDOS TO FOUR-NRENDOS */
            _.Move(V1ENDO_NRENDOS, WREG_FENOUTR.FOUR_NRENDOS);

            /*" -3264- MOVE V1OCOB-DTINIVIG TO FOUR-DTINIVIG */
            _.Move(V1OCOB_DTINIVIG, WREG_FENOUTR.FOUR_DTINIVIG);

            /*" -3265- MOVE V1OCOB-DTTERVIG TO FOUR-DTTERVIG */
            _.Move(V1OCOB_DTTERVIG, WREG_FENOUTR.FOUR_DTTERVIG);

            /*" -3266- MOVE V1OCOB-NRRISCO TO FOUR-NRITEM */
            _.Move(V1OCOB_NRRISCO, WREG_FENOUTR.FOUR_NRITEM);

            /*" -3267- MOVE V1OCOB-RAMOFR TO FOUR-RAMOCOBER */
            _.Move(V1OCOB_RAMOFR, WREG_FENOUTR.FOUR_RAMOCOBER);

            /*" -3268- MOVE V1OCOB-CODCOBER TO FOUR-CODCOBER */
            _.Move(V1OCOB_CODCOBER, WREG_FENOUTR.FOUR_CODCOBER);

            /*" -3269- MOVE V1OCOB-IMP-SEG-IX TO FOUR-IMP-SEGURADA */
            _.Move(V1OCOB_IMP_SEG_IX, WREG_FENOUTR.FOUR_IMP_SEGURADA);

            /*" -3270- MOVE V1OCOB-PRM-TAR-VAR TO FOUR-VLPRMLIQ */
            _.Move(V1OCOB_PRM_TAR_VAR, WREG_FENOUTR.FOUR_VLPRMLIQ);

            /*" -3271- MOVE V1OCOB-VRFROBR-IX TO FOUR-VALFRANQ */
            _.Move(V1OCOB_VRFROBR_IX, WREG_FENOUTR.FOUR_VALFRANQ);

            /*" -3273- MOVE V1OCOB-LIMINDENIZ TO FOUR-LIMINDENIZ. */
            _.Move(V1OCOB_LIMINDENIZ, WREG_FENOUTR.FOUR_LIMINDENIZ);

            /*" -3275- WRITE REG-FENOUTR FROM WREG-FENOUTR. */
            _.Move(WREG_FENOUTR.GetMoveValues(), REG_FENOUTR);

            FENOUTR.Write(REG_FENOUTR.GetMoveValues().ToString());

            /*" -3277- ADD +1 TO AC-G-FENOUTR. */
            AREA_DE_WORK.AC_G_FENOUTR.Value = AREA_DE_WORK.AC_G_FENOUTR + +1;

            /*" -3277- PERFORM R6400-00-FETCH-MRAPCOBER. */

            R6400_00_FETCH_MRAPCOBER_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R6500_99_SAIDA*/

        [StopWatch]
        /*" R0900-00-FETCH-V1HISTOPARC-SECTION */
        private void R0900_00_FETCH_V1HISTOPARC_SECTION()
        {
            /*" -3285- SECTION. */

            /*" -0- FLUXCONTROL_PERFORM R0900_10_FETCH */

            R0900_10_FETCH();

        }

        [StopWatch]
        /*" R0900-10-FETCH */
        private void R0900_10_FETCH(bool isPerform = false)
        {
            /*" -3289- MOVE '0900' TO WNR-EXEC-SQL. */
            _.Move("0900", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3297- PERFORM R0900_10_FETCH_DB_FETCH_1 */

            R0900_10_FETCH_DB_FETCH_1();

            /*" -3300- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3301- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -3302- MOVE 'S' TO WFIM-V1HISTOPARC */
                    _.Move("S", AREA_DE_WORK.WFIM_V1HISTOPARC);

                    /*" -3302- PERFORM R0900_10_FETCH_DB_CLOSE_1 */

                    R0900_10_FETCH_DB_CLOSE_1();

                    /*" -3304- GO TO R0900-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0900_99_SAIDA*/ //GOTO
                    return;

                    /*" -3305- ELSE */
                }
                else
                {


                    /*" -3306- DISPLAY 'R0900-00 (ERRO NO FETCH MOVTO)' */
                    _.Display($"R0900-00 (ERRO NO FETCH MOVTO)");

                    /*" -3308- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -3310- MOVE '0' TO CH-VERIFICA */
            _.Move("0", AREA_DE_WORK.CH_VERIFICA);

            /*" -3311- PERFORM R0910-00-VERIFICA-CORRET-FENAE */

            R0910_00_VERIFICA_CORRET_FENAE_SECTION();

            /*" -3312- IF CH-VERIFICA EQUAL '0' */

            if (AREA_DE_WORK.CH_VERIFICA == "0")
            {

                /*" -3314- GO TO R0900-10-FETCH. */
                new Task(() => R0900_10_FETCH()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


            /*" -3316- ADD 1 TO AC-L-V1HISTOPARC. */
            AREA_DE_WORK.AC_L_V1HISTOPARC.Value = AREA_DE_WORK.AC_L_V1HISTOPARC + 1;

            /*" -3320- DIVIDE AC-L-V1HISTOPARC BY 1000 GIVING AC-QUOC REMAINDER AC-RESTO */
            _.Divide(AREA_DE_WORK.AC_L_V1HISTOPARC, 1000, AC_QUOC, AC_RESTO);

            /*" -3321- IF AC-RESTO EQUAL ZEROS */

            if (AC_RESTO == 00)
            {

                /*" -3321- DISPLAY 'REGISTROS PROCESSADOS = ' AC-L-V1HISTOPARC. */
                _.Display($"REGISTROS PROCESSADOS = {AREA_DE_WORK.AC_L_V1HISTOPARC}");
            }


        }

        [StopWatch]
        /*" R0900-10-FETCH-DB-FETCH-1 */
        public void R0900_10_FETCH_DB_FETCH_1()
        {
            /*" -3297- EXEC SQL FETCH MOVTO INTO :V1HISP-NUMAPOL , :V1HISP-NRENDOS , :APOLICES-COD-PRODUTO , :V1ENDO-CODSUBES , :V1ENDO-DTINIVIG , :V1ENDO-DTTERVIG , :V1ENDO-SITUACAO END-EXEC. */

            if (MOVTO.Fetch())
            {
                _.Move(MOVTO.V1HISP_NUMAPOL, V1HISP_NUMAPOL);
                _.Move(MOVTO.V1HISP_NRENDOS, V1HISP_NRENDOS);
                _.Move(MOVTO.APOLICES_COD_PRODUTO, APOLICES.DCLAPOLICES.APOLICES_COD_PRODUTO);
                _.Move(MOVTO.V1ENDO_CODSUBES, V1ENDO_CODSUBES);
                _.Move(MOVTO.V1ENDO_DTINIVIG, V1ENDO_DTINIVIG);
                _.Move(MOVTO.V1ENDO_DTTERVIG, V1ENDO_DTTERVIG);
                _.Move(MOVTO.V1ENDO_SITUACAO, V1ENDO_SITUACAO);
            }

        }

        [StopWatch]
        /*" R0900-10-FETCH-DB-CLOSE-1 */
        public void R0900_10_FETCH_DB_CLOSE_1()
        {
            /*" -3302- EXEC SQL CLOSE MOVTO END-EXEC */

            MOVTO.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0900_99_SAIDA*/

        [StopWatch]
        /*" R0910-00-VERIFICA-CORRET-FENAE-SECTION */
        private void R0910_00_VERIFICA_CORRET_FENAE_SECTION()
        {
            /*" -3331- MOVE '0910' TO WNR-EXEC-SQL. */
            _.Move("0910", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3345- PERFORM R0910_00_VERIFICA_CORRET_FENAE_DB_SELECT_1 */

            R0910_00_VERIFICA_CORRET_FENAE_DB_SELECT_1();

            /*" -3348- IF SQLCODE EQUAL 0 OR 811 OR -811 */

            if (DB.SQLCODE.In("0", "811", "-811"))
            {

                /*" -3349- MOVE '1' TO CH-VERIFICA */
                _.Move("1", AREA_DE_WORK.CH_VERIFICA);

                /*" -3350- ELSE */
            }
            else
            {


                /*" -3351- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -3352- MOVE '0' TO CH-VERIFICA */
                    _.Move("0", AREA_DE_WORK.CH_VERIFICA);

                    /*" -3353- ELSE */
                }
                else
                {


                    /*" -3354- DISPLAY 'R0910-00 (ERRO NO SELECT V0PRODUTOR)' */
                    _.Display($"R0910-00 (ERRO NO SELECT V0PRODUTOR)");

                    /*" -3354- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R0910-00-VERIFICA-CORRET-FENAE-DB-SELECT-1 */
        public void R0910_00_VERIFICA_CORRET_FENAE_DB_SELECT_1()
        {
            /*" -3345- EXEC SQL SELECT A.CODCORR INTO :WHOST-CODCORR FROM SEGUROS.V1APOLCORRET A, SEGUROS.V1PRODUTOR B WHERE A.NUM_APOLICE = :V1HISP-NUMAPOL AND A.CODSUBES = :V1ENDO-CODSUBES AND A.DTINIVIG <= :V1ENDO-DTINIVIG AND A.DTTERVIG >= :V1ENDO-DTINIVIG AND A.CODCORR = B.CODPDT AND B.CGCCPF IN (42278473000103, 29552064000187, 14143271000100) WITH UR END-EXEC. */

            var r0910_00_VERIFICA_CORRET_FENAE_DB_SELECT_1_Query1 = new R0910_00_VERIFICA_CORRET_FENAE_DB_SELECT_1_Query1()
            {
                V1ENDO_CODSUBES = V1ENDO_CODSUBES.ToString(),
                V1ENDO_DTINIVIG = V1ENDO_DTINIVIG.ToString(),
                V1HISP_NUMAPOL = V1HISP_NUMAPOL.ToString(),
            };

            var executed_1 = R0910_00_VERIFICA_CORRET_FENAE_DB_SELECT_1_Query1.Execute(r0910_00_VERIFICA_CORRET_FENAE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_CODCORR, WHOST_CODCORR);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/

        [StopWatch]
        /*" R0911-00-VERIF-CORRET-PANAM-SECTION */
        private void R0911_00_VERIF_CORRET_PANAM_SECTION()
        {
            /*" -3366- MOVE '0911' TO WNR-EXEC-SQL. */
            _.Move("0911", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3374- PERFORM R0911_00_VERIF_CORRET_PANAM_DB_SELECT_1 */

            R0911_00_VERIF_CORRET_PANAM_DB_SELECT_1();

            /*" -3377- IF WHOST-COUNT EQUAL ZEROS */

            if (WHOST_COUNT == 00)
            {

                /*" -3378- MOVE 'N' TO WS-PANAMERICANO */
                _.Move("N", WS_AULIARES.WS_PANAMERICANO);

                /*" -3379- ELSE */
            }
            else
            {


                /*" -3380- MOVE 'S' TO WS-PANAMERICANO */
                _.Move("S", WS_AULIARES.WS_PANAMERICANO);

                /*" -3382- END-IF */
            }


            /*" -3383- IF SQLCODE EQUAL 0 OR 811 OR -811 */

            if (DB.SQLCODE.In("0", "811", "-811"))
            {

                /*" -3384- MOVE '1' TO CH-VERIFICA */
                _.Move("1", AREA_DE_WORK.CH_VERIFICA);

                /*" -3385- ELSE */
            }
            else
            {


                /*" -3386- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -3387- MOVE '0' TO CH-VERIFICA */
                    _.Move("0", AREA_DE_WORK.CH_VERIFICA);

                    /*" -3388- ELSE */
                }
                else
                {


                    /*" -3390- DISPLAY 'R0911-00 - ERRO SELECT V0APOLCORRET' ' APOLICE=' V1ENDO-NUMAPOL */

                    $"R0911-00 - ERRO SELECT V0APOLCORRET APOLICE={V1ENDO_NUMAPOL}"
                    .Display();

                    /*" -3390- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R0911-00-VERIF-CORRET-PANAM-DB-SELECT-1 */
        public void R0911_00_VERIF_CORRET_PANAM_DB_SELECT_1()
        {
            /*" -3374- EXEC SQL SELECT COUNT(*) INTO :WHOST-COUNT FROM SEGUROS.V1APOLCORRET WHERE NUM_APOLICE = :V1ENDO-NUMAPOL AND CODCORR = 24619 AND RAMOFR = 31 WITH UR END-EXEC. */

            var r0911_00_VERIF_CORRET_PANAM_DB_SELECT_1_Query1 = new R0911_00_VERIF_CORRET_PANAM_DB_SELECT_1_Query1()
            {
                V1ENDO_NUMAPOL = V1ENDO_NUMAPOL.ToString(),
            };

            var executed_1 = R0911_00_VERIF_CORRET_PANAM_DB_SELECT_1_Query1.Execute(r0911_00_VERIF_CORRET_PANAM_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_COUNT, WHOST_COUNT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0911_99_SAIDA*/

        [StopWatch]
        /*" R0920-00-FETCH-V1AUTOAPOL-SECTION */
        private void R0920_00_FETCH_V1AUTOAPOL_SECTION()
        {
            /*" -3401- MOVE '0920' TO WNR-EXEC-SQL. */
            _.Move("0920", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3414- PERFORM R0920_00_FETCH_V1AUTOAPOL_DB_FETCH_1 */

            R0920_00_FETCH_V1AUTOAPOL_DB_FETCH_1();

            /*" -3417- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3418- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -3419- MOVE 'S' TO WFIM-V1AUTOAPOL */
                    _.Move("S", AREA_DE_WORK.WFIM_V1AUTOAPOL);

                    /*" -3419- PERFORM R0920_00_FETCH_V1AUTOAPOL_DB_CLOSE_1 */

                    R0920_00_FETCH_V1AUTOAPOL_DB_CLOSE_1();

                    /*" -3421- GO TO R0920-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0920_99_SAIDA*/ //GOTO
                    return;

                    /*" -3422- ELSE */
                }
                else
                {


                    /*" -3423- DISPLAY 'R0920-00 (ERRO NO FETCH V1AUTOAPOL)' */
                    _.Display($"R0920-00 (ERRO NO FETCH V1AUTOAPOL)");

                    /*" -3424- DISPLAY 'APOLICE   = ' V1ENDO-NUMAPOL */
                    _.Display($"APOLICE   = {V1ENDO_NUMAPOL}");

                    /*" -3425- DISPLAY 'ENDOSSO   = ' V1ENDO-NRENDOS */
                    _.Display($"ENDOSSO   = {V1ENDO_NRENDOS}");

                    /*" -3427- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -3428- IF VIND-ZEROKM EQUAL -1 */

            if (VIND_ZEROKM == -1)
            {

                /*" -3430- MOVE SPACES TO V1AUTO-ZEROKM. */
                _.Move("", V1AUTO_ZEROKM);
            }


            /*" -3431- IF VIND-SEGBONUS EQUAL -1 */

            if (VIND_SEGBONUS == -1)
            {

                /*" -3431- MOVE ZEROS TO V1AUTO-SEGBONUS. */
                _.Move(0, V1AUTO_SEGBONUS);
            }


        }

        [StopWatch]
        /*" R0920-00-FETCH-V1AUTOAPOL-DB-FETCH-1 */
        public void R0920_00_FETCH_V1AUTOAPOL_DB_FETCH_1()
        {
            /*" -3414- EXEC SQL FETCH V1AUTOAPOL INTO :V1AUTO-FONTE , :V1AUTO-NRPROPOS , :V1AUTO-NRITEM , :V1AUTO-CDVEICL , :V1AUTO-ANOVEICL , :V1AUTO-ANOMOD , :V1AUTO-CHASSIS , :V1AUTO-COMBUST , :V1AUTO-PLACALET , :V1AUTO-PLACANR , :V1AUTO-PLACAUF END-EXEC. */

            if (V1AUTOAPOL.Fetch())
            {
                _.Move(V1AUTOAPOL.V1AUTO_FONTE, V1AUTO_FONTE);
                _.Move(V1AUTOAPOL.V1AUTO_NRPROPOS, V1AUTO_NRPROPOS);
                _.Move(V1AUTOAPOL.V1AUTO_NRITEM, V1AUTO_NRITEM);
                _.Move(V1AUTOAPOL.V1AUTO_CDVEICL, V1AUTO_CDVEICL);
                _.Move(V1AUTOAPOL.V1AUTO_ANOVEICL, V1AUTO_ANOVEICL);
                _.Move(V1AUTOAPOL.V1AUTO_ANOMOD, V1AUTO_ANOMOD);
                _.Move(V1AUTOAPOL.V1AUTO_CHASSIS, V1AUTO_CHASSIS);
                _.Move(V1AUTOAPOL.V1AUTO_COMBUST, V1AUTO_COMBUST);
                _.Move(V1AUTOAPOL.V1AUTO_PLACALET, V1AUTO_PLACALET);
                _.Move(V1AUTOAPOL.V1AUTO_PLACANR, V1AUTO_PLACANR);
                _.Move(V1AUTOAPOL.V1AUTO_PLACAUF, V1AUTO_PLACAUF);
            }

        }

        [StopWatch]
        /*" R0920-00-FETCH-V1AUTOAPOL-DB-CLOSE-1 */
        public void R0920_00_FETCH_V1AUTOAPOL_DB_CLOSE_1()
        {
            /*" -3419- EXEC SQL CLOSE V1AUTOAPOL END-EXEC */

            V1AUTOAPOL.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0920_99_SAIDA*/

        [StopWatch]
        /*" R0930-00-ALTERA-CAMPO-SECTION */
        private void R0930_00_ALTERA_CAMPO_SECTION()
        {
            /*" -3447- MOVE '0930' TO WNR-EXEC-SQL. */
            _.Move("0930", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3448- IF TAB-ALFA-BYTE (INDX) EQUAL "" */

            if (TABELA_ALFA.TAB_ALFA_BYTE[INDX] == "")
            {

                /*" -3450- MOVE SPACES TO TAB-ALFA-BYTE (INDX). */
                _.Move("", TABELA_ALFA.TAB_ALFA_BYTE[INDX]);
            }


            /*" -3451- IF TAB-ALFA-BYTE (INDX) EQUAL ';' */

            if (TABELA_ALFA.TAB_ALFA_BYTE[INDX] == ";")
            {

                /*" -3451- MOVE ',' TO TAB-ALFA-BYTE (INDX). */
                _.Move(",", TABELA_ALFA.TAB_ALFA_BYTE[INDX]);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0930_99_SAIDA*/

        [StopWatch]
        /*" R9000-00-ENCERRA-SEM-MOVTO-SECTION */
        private void R9000_00_ENCERRA_SEM_MOVTO_SECTION()
        {
            /*" -3464- DISPLAY '*------------------------------------------*' */
            _.Display($"*------------------------------------------*");

            /*" -3465- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -3466- DISPLAY '*   FN0301B   -   NAO HOUVE MOVIMENTACAO   *' */
            _.Display($"*   FN0301B   -   NAO HOUVE MOVIMENTACAO   *");

            /*" -3467- DISPLAY '*                       NESTA  DATA        *' */
            _.Display($"*                       NESTA  DATA        *");

            /*" -3469- DISPLAY '*   DATA MOVIMENTO   =>   ' V1SIST-DTMOVABE '       *' */

            $"*   DATA MOVIMENTO   =>   {V1SIST_DTMOVABE}       *"
            .Display();

            /*" -3470- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -3470- DISPLAY '*------------------------------------------*' . */
            _.Display($"*------------------------------------------*");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9000_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -3485- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, AREA_DE_WORK.WABEND.WSQLCODE);

            /*" -3487- DISPLAY WABEND */
            _.Display(AREA_DE_WORK.WABEND);

            /*" -3487- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -3491- MOVE 99 TO RETURN-CODE */
            _.Move(99, RETURN_CODE);

            /*" -3491- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9999_99_SAIDA*/
    }
}