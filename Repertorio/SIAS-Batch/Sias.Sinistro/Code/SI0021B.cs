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
using Sias.Sinistro.DB2.SI0021B;

namespace Code
{
    public class SI0021B
    {
        public bool IsCall { get; set; }

        public SI0021B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *---------------------------------                                      */
        /*"      *                                                                       */
        /*"      *                                                                       */
        /*"      *--------  ( SI0021B - PARA OS RAMOS DE RISCOS DIVERSOS )-------*       */
        /*"      *--------  ( SI0023B - PARA OS RAMOS DE VIDA            )-------*       */
        /*"      *  SISTEMA ..............    SINISTRO.                          *       */
        /*"      *  PROGRAMA .............    SI0021B.                           *       */
        /*"      *---------------------------------------------------------------*       */
        /*"      *  ANALISTA .............    PROCAS/RENATO.                     *       */
        /*"      *  PROGRAMADOR ..........    PROCAS/ENRICO.                     *       */
        /*"      *  DATA CODIFICACAO .....    NOVEMBRO / 1992.                   *       */
        /*"      *---------------------------------------------------------------*       */
        /*"      *  FUNCAO ...............    EMITE CARTA DE SINISTRO            *       */
        /*"      *                            DE COSSEGURO.                      *       */
        /*"      *                            EMISSAO AUTOMATICA ATRAVES DAS     *       */
        /*"      *                            TABELAS DE SINISTRO.               *       */
        /*"      *---------------------------------------------------------------*       */
        /*"      *  TABELA                       VIEW                   ACESSO   *       */
        /*"      *  ---------------------------  --------------------- --------  *       */
        /*"      *  HISTORICO DE SINISTROS       V1HISTSINI             INPUT    *       */
        /*"      *  MESTRE DE SINISTROS          V1MESTSINI             INPUT    *       */
        /*"      *  APOLICES                     V1APOLICE              INPUT    *       */
        /*"      *  APOLICES COSSEGURADORAS      V1APOLCOSCED           INPUT    *       */
        /*"      *  APOLICES ITENS               V1APOLITEM             INPUT    *       */
        /*"      *  APOLICES VEICULOS            V1APOLVEIC             INPUT    *       */
        /*"      *  ORDEM COSSEGURADORAS         V1ORDECOSCED           INPUT    *       */
        /*"      *  CONGENERES                   V1CONGENERE            INPUT    *       */
        /*"      *  ENDOSSOS                     V1ENDOSSO              INPUT    *       */
        /*"      *  CLIENTES                     V1CLIENTE              INPUT    *       */
        /*"      *  RAMOS                        V1RAMO                 INPUT    *       */
        /*"      *  MOEDAS                       V1MOEDA                INPUT    *       */
        /*"      *  SEGURADOS VIDA GRUPO         V1SEGURAVG             INPUT    *       */
        /*"      *  AVERBACAO NACIONAL           V1AVERBNAC             INPUT     *      */
        /*"      *  AVERBACAO INTERNACIONAL      V1AVERBINT             INPUT     *      */
        /*"      *--------------------------------------------------------------- *      */
        /*"      *                      A L T E R A C O E S                       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO  : 007                                                  *      */
        /*"      * MOTIVO  : ABEND NA SX_EM_ENDOSSO MAIS DE REGISTRO              *      */
        /*"      * JIRA    : 174564                                               *      */
        /*"      * DATA    : 03/06/2019                                           *      */
        /*"      * NOME    : DIOGO MATHEUS                                        *      */
        /*"      * MARCADOR: V.7                                                  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO  : 006                                                  *      */
        /*"      * MOTIVO  : ABEND NA SX_EM_ENDOSSO ACHAR ENDOSSO ZERO            *      */
        /*"      * JIRA    : 174564                                               *      */
        /*"      * DATA    : 15/05/2019                                           *      */
        /*"      * NOME    : DIOGO MATHEUS                                        *      */
        /*"      * MARCADOR: V.6                                                  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.05  * VERSAO  : 005                                                  *      */
        /*"      * MOTIVO  : ALTERADO PARA EMITIR POR CONGENERE E PERIODO         *      */
        /*"      * JAZZ    : 181112                                               *      */
        /*"      * DATA    : 16/04/2019                                           *      */
        /*"      * NOME    : FLAVIO DE LIMA SILVA                                 *      */
        /*"      * MARCADOR: V.05                                                 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO  : 004                                                  *      */
        /*"      * MOTIVO  : ABEND NA SUB-ROTINA LER TABELA V1ENDOSSO             *      */
        /*"      * CADMUS  : 174021                                               *      */
        /*"      * DATA    : 09/04/2019                                           *      */
        /*"      * NOME    : DIOGO MATHEUS                                        *      */
        /*"      * MARCADOR: V.4                                                  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO  : 003                                                  *      */
        /*"      * MOTIVO  : ABEND NA SUB-ROTINA LER TABELA V1APOLCOSCED          *      */
        /*"      * CADMUS  : 173816                                               *      */
        /*"      * DATA    : 27/03/2019                                           *      */
        /*"      * NOME    : DIOGO MATHEUS                                        *      */
        /*"      * MARCADOR: V.3                                                  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.02  *  24/09/2018 - CADMUS 168975 - LISIANE BRAGANCA SOARES          *      */
        /*"      *               MUDANCA NA PLACA DO VEICULO                      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.01  *  VERSAO 01 - CAD 67446 - SAC 1183                              *      */
        /*"      *              NAO PERMITIR ENVIO DE CARTAS DE SINISTRO QUE ES-  *      */
        /*"      *              TAO EM RUN-ON SULAMERICA.                         *      */
        /*"      *                                                                *      */
        /*"      *  EM 09/03/2012 - COREON                    PROCURE POR V.01    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * SSI 16732/2007                                                 *      */
        /*"      * CANCELAR A IMPRESSAO DE CARTAS DE SINITROS DE COSSEGURO MAPFRE *      */
        /*"      *   RAMO 20, 31 E 53                                             *      */
        /*"      * ESTA ALTERACAO PODERA SER LOCALIZADA POR WA3007                *      */
        /*"      *                         WANGER C SILVA - 30/07/2007            *      */
        /*"      *---------------------------------------------------------------*       */
        /*"      *                                                                *      */
        /*"      * RECONVERSAO ANO 2000            CONSEDA4           11/09/1998  *      */
        /*"      *                                                                *      */
        /*"      * MELHORIA DE PERFORMANCE         PRODEXTER            AGO/2000  *      */
        /*"      * (PROCURAR POR JO0800)                                          *      */
        /*"      *---------------------------------------------------------------*       */
        /*"      * A T E N C A O                                                 *       */
        /*"      *                                                               *       */
        /*"      * PARA EMISSAO DE 2 VIA DE CARTA DE SINISTRO DE COSSEGURO,      *       */
        /*"      * NAO PODERAH UTILIZAR A V1SIST-DTMOVABE NA ROTINA (140-000),   *       */
        /*"      * QUE EH A DATA DO SISTEMA DE SINISTRO.                         *       */
        /*"      * SISTEMA DE SINISTRO. O VALOR DA OPERACAO DEVER SER CALCULA-   *       */
        /*"      * DO INDEPENDETE DA DATA. RILDO SICO 23/03/2000.                *       */
        /*"      *---------------------------------------------------------------*       */
        /*"      * 31/03/2005 - PRODEXTER                                        *       */
        /*"      * SUBSTITUICAO DA TABELA PARAMETR_OPER_SINI PELA GE_OPERACAO    *       */
        /*"      *----------------------------------------------------------------*      */
        /*"      * PROJETO FGV (ALTERACOES)     (WELLINGTON VERAS (POLITEC))      *      */
        /*"      *                                                                *      */
        /*"      * 08/09/2008   INIBIR O COMANDO DISPLAY               - WV0908   *      */
        /*"      *----------------------------------------------------------------*      */
        #endregion


        #region VARIABLES

        public FileBasis _SI0021M1 { get; set; } = new FileBasis(new PIC("X", "0", "X(0)"));

        public FileBasis SI0021M1
        {
            get
            {
                _.Move(REG_SI0021M1, _SI0021M1); VarBasis.RedefinePassValue(REG_SI0021M1, _SI0021M1, REG_SI0021M1); return _SI0021M1;
            }
        }
        public FileBasis _SI0021M2 { get; set; } = new FileBasis(new PIC("X", "0", "X(0)"));

        public FileBasis SI0021M2
        {
            get
            {
                _.Move(REG_SI0021M2, _SI0021M2); VarBasis.RedefinePassValue(REG_SI0021M2, _SI0021M2, REG_SI0021M2); return _SI0021M2;
            }
        }
        /*"01  REG-SI0021M1.*/
        public SI0021B_REG_SI0021M1 REG_SI0021M1 { get; set; } = new SI0021B_REG_SI0021M1();
        public class SI0021B_REG_SI0021M1 : VarBasis
        {
            /*"    05          LINHA              PIC  X(132).*/
            public StringBasis LINHA { get; set; } = new StringBasis(new PIC("X", "132", "X(132)."), @"");
            /*"01  REG-SI0021M2.*/
        }
        public SI0021B_REG_SI0021M2 REG_SI0021M2 { get; set; } = new SI0021B_REG_SI0021M2();
        public class SI0021B_REG_SI0021M2 : VarBasis
        {
            /*"    05          LINHA2             PIC  X(132).*/
            public StringBasis LINHA2 { get; set; } = new StringBasis(new PIC("X", "132", "X(132)."), @"");
        }

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77 WS-SEG-INICIAL                 PIC S9(08)V9(4) VALUE 0.*/
        public DoubleBasis WS_SEG_INICIAL { get; set; } = new DoubleBasis(new PIC("S9", "8", "S9(08)V9(4)"), 4);
        /*"77 WS-SEG-FINAL                   PIC S9(08)V9(4) VALUE 0.*/
        public DoubleBasis WS_SEG_FINAL { get; set; } = new DoubleBasis(new PIC("S9", "8", "S9(08)V9(4)"), 4);
        /*"77 WS-TOT-TIME-ED                 PIC ZZZ.ZZ9,9999-.*/
        public DoubleBasis WS_TOT_TIME_ED { get; set; } = new DoubleBasis(new PIC("9", "6", "ZZZ.ZZ9V9999-."), 5);
        /*"77 WS-CONG-INICIAL                PIC S9(04) COMP VALUE 0.*/
        public IntBasis WS_CONG_INICIAL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77 WS-CONG-FINAL                  PIC S9(04) COMP VALUE 0.*/
        public IntBasis WS_CONG_FINAL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77 AN-CONGENERE                   PIC 9(04) VALUE 0.*/
        public IntBasis AN_CONGENERE { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
        /*"77 WS-TIPO-CURSOR                 PIC X(01) VALUE SPACES.*/
        public StringBasis WS_TIPO_CURSOR { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
        /*"77           V1EMPRESA-COD-EMP      PIC S9(004)       COMP.*/
        public IntBasis V1EMPRESA_COD_EMP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77           V1EMPRESA-MNUEMP       PIC  X(040).*/
        public StringBasis V1EMPRESA_MNUEMP { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"77 GEOPERAC-FUNCAO-OPERACAO     PIC X(5)      VALUE SPACES.*/
        public StringBasis GEOPERAC_FUNCAO_OPERACAO { get; set; } = new StringBasis(new PIC("X", "5", "X(5)"), @"");
        /*"77 GEOPERAC-DES-OPERACAO        PIC X(40)     VALUE SPACES.*/
        public StringBasis GEOPERAC_DES_OPERACAO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
        /*"77           V1SIST-DTMOVABE        PIC  X(010).*/
        public StringBasis V1SIST_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77           V1MEST-NUM-APOL        PIC S9(013)       COMP-3.*/
        public IntBasis V1MEST_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77           V1MEST-NRENDOS         PIC S9(009)       COMP.*/
        public IntBasis V1MEST_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77           V1MEST-APOL-SINI       PIC S9(013)       COMP-3.*/
        public IntBasis V1MEST_APOL_SINI { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77           V1MEST-DATCMD          PIC  X(010).*/
        public StringBasis V1MEST_DATCMD { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77           V1MEST-DATORR          PIC  X(010).*/
        public StringBasis V1MEST_DATORR { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77           V1MEST-NRCERTIF        PIC S9(015)       COMP-3.*/
        public IntBasis V1MEST_NRCERTIF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77           V1MEST-NRITEM          PIC S9(009)       COMP.*/
        public IntBasis V1MEST_NRITEM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77           V1MEST-IDTPSEGU        PIC  X(001).*/
        public StringBasis V1MEST_IDTPSEGU { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77           V1MEST-PCPARTIC        PIC S9(004)V9(5)  COMP-3.*/
        public DoubleBasis V1MEST_PCPARTIC { get; set; } = new DoubleBasis(new PIC("S9", "4", "S9(004)V9(5)"), 5);
        /*"77           V1MEST-MOEDA-SINI      PIC S9(004)       COMP.*/
        public IntBasis V1MEST_MOEDA_SINI { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77           V1MEST-CODCAU          PIC S9(004)       COMP.*/
        public IntBasis V1MEST_CODCAU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77           V1MEST-NUMIRB          PIC S9(011)       COMP-3.*/
        public IntBasis V1MEST_NUMIRB { get; set; } = new IntBasis(new PIC("S9", "11", "S9(011)"));
        /*"77           V1MEST-CODSUBES        PIC S9(004)       COMP.*/
        public IntBasis V1MEST_CODSUBES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77           V1MEST-NREMBARQ        PIC S9(009)       COMP.*/
        public IntBasis V1MEST_NREMBARQ { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77           V1MEST-REFEMBQ         PIC S9(004)       COMP.*/
        public IntBasis V1MEST_REFEMBQ { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77           V1MEST-RAMO            PIC S9(004)       COMP.*/
        public IntBasis V1MEST_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77           V1MEST-VALSEGBT        PIC S9(013)V9(2)  COMP-3.*/
        public DoubleBasis V1MEST_VALSEGBT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"77 V0SINI-LOCAL1-NUM-APOL-SINI      PIC S9(013)      COMP-3.*/
        public IntBasis V0SINI_LOCAL1_NUM_APOL_SINI { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77 V0SINI-LOCAL1-ENDERECO-SINI      PIC  X(065).*/
        public StringBasis V0SINI_LOCAL1_ENDERECO_SINI { get; set; } = new StringBasis(new PIC("X", "65", "X(065)."), @"");
        /*"77 V0SINI-ITEM-NUM-APOL-SINI        PIC S9(013)      COMP-3.*/
        public IntBasis V0SINI_ITEM_NUM_APOL_SINI { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77 V0SINI-ITEM-COD-CLIENTE          PIC S9(009) VALUE +0 COMP.*/
        public IntBasis V0SINI_ITEM_COD_CLIENTE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77 V0ENDERECOS-ENDERECO             PIC  X(040).*/
        public StringBasis V0ENDERECOS_ENDERECO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"77 V0ENDERECOS-BAIRRO               PIC  X(020).*/
        public StringBasis V0ENDERECOS_BAIRRO { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
        /*"77 V0ENDERECOS-CIDADE               PIC  X(020).*/
        public StringBasis V0ENDERECOS_CIDADE { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
        /*"77 V0ENDERECOS-SIGLA-UF             PIC  X(002).*/
        public StringBasis V0ENDERECOS_SIGLA_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
        /*"77 V0SINICAUSA-CODCAU               PIC S9(004) VALUE +0 COMP.*/
        public IntBasis V0SINICAUSA_CODCAU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77 V0SINICAUSA-DESCAU               PIC  X(040).*/
        public StringBasis V0SINICAUSA_DESCAU { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"77           V1APCO-CODCOSS         PIC S9(004)      COMP.*/
        public IntBasis V1APCO_CODCOSS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77           V1APCO-PCPARTIC        PIC S9(004)V9(5) COMP-3.*/
        public DoubleBasis V1APCO_PCPARTIC { get; set; } = new DoubleBasis(new PIC("S9", "4", "S9(004)V9(5)"), 5);
        /*"77           V1ORDE-NRORDEM         PIC S9(015)      COMP-3.*/
        public IntBasis V1ORDE_NRORDEM { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77           V1ENDO-DTINIVIG        PIC  X(010).*/
        public StringBasis V1ENDO_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77           V1ENDO-DTTERVIG        PIC  X(010).*/
        public StringBasis V1ENDO_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77           V1ENDO-CORRECAO        PIC  X(001).*/
        public StringBasis V1ENDO_CORRECAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77           V1RELA-COD-USUARIO     PIC  X(008).*/
        public StringBasis V1RELA_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"77           V1RELA-COD-RELATORIO   PIC  X(008).*/
        public StringBasis V1RELA_COD_RELATORIO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"77           V1RELA-SIT-REGISTRO    PIC  X(001).*/
        public StringBasis V1RELA_SIT_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77           V0USU-COD-USUARIO      PIC  X(008).*/
        public StringBasis V0USU_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"77           V0USU-NOME-USUARIO     PIC  X(040).*/
        public StringBasis V0USU_NOME_USUARIO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"77           V0USU-DEPARTAMENTO     PIC  X(010).*/
        public StringBasis V0USU_DEPARTAMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77           V1APVI-CDVEICL         PIC S9(004)   COMP.*/
        public IntBasis V1APVI_CDVEICL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77           V1APVI-PLACAUF         PIC  X(002).*/
        public StringBasis V1APVI_PLACAUF { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
        /*"77           V1APVI-PLACALET        PIC  X(003).*/
        public StringBasis V1APVI_PLACALET { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
        /*"77           V1APVI-PLACANR         PIC  X(004).*/
        public StringBasis V1APVI_PLACANR { get; set; } = new StringBasis(new PIC("X", "4", "X(004)."), @"");
        /*"77           V1APVI-CHASSIS         PIC  X(020).*/
        public StringBasis V1APVI_CHASSIS { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
        /*"77           V1APVI-ANOVEICL        PIC S9(004)   COMP.*/
        public IntBasis V1APVI_ANOVEICL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77           V1APVI-TIPOVEIC        PIC S9(004)   COMP.*/
        public IntBasis V1APVI_TIPOVEIC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77           V1APVI-FABRICAN        PIC S9(004)   COMP.*/
        public IntBasis V1APVI_FABRICAN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77           V1DESC-DESCVEIC        PIC  X(040).*/
        public StringBasis V1DESC_DESCVEIC { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"77           V1AVNA-NRAVERB         PIC S9(004)   COMP.*/
        public IntBasis V1AVNA_NRAVERB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77           V1AVNA-PREFIXO         PIC  X(010).*/
        public StringBasis V1AVNA_PREFIXO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77           V1AVNA-NREMBARQ        PIC S9(009)   COMP.*/
        public IntBasis V1AVNA_NREMBARQ { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77           V1AVNA-MARCMERC        PIC  X(010).*/
        public StringBasis V1AVNA_MARCMERC { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77           V1AVNA-LOCALINI        PIC  X(002).*/
        public StringBasis V1AVNA_LOCALINI { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
        /*"77           V1AVNA-LOCALDES        PIC  X(002).*/
        public StringBasis V1AVNA_LOCALDES { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
        /*"77           V1AVIN-NRAVERB         PIC S9(004)   COMP.*/
        public IntBasis V1AVIN_NRAVERB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77           V1AVIN-PREFIXO         PIC  X(010).*/
        public StringBasis V1AVIN_PREFIXO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77           V1AVIN-DESCMERC        PIC  X(080).*/
        public StringBasis V1AVIN_DESCMERC { get; set; } = new StringBasis(new PIC("X", "80", "X(080)."), @"");
        /*"77           V1AVIN-PAISINI         PIC  X(015).*/
        public StringBasis V1AVIN_PAISINI { get; set; } = new StringBasis(new PIC("X", "15", "X(015)."), @"");
        /*"77           V1AVIN-PAISDEST        PIC  X(015).*/
        public StringBasis V1AVIN_PAISDEST { get; set; } = new StringBasis(new PIC("X", "15", "X(015)."), @"");
        /*"77           V1CONGE-NOMECONG       PIC  X(040).*/
        public StringBasis V1CONGE_NOMECONG { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"77           V1SEGVG-COD-CLI    PIC S9(009)      COMP.*/
        public IntBasis V1SEGVG_COD_CLI { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77           V1SEGVG-DTNASCIM       PIC  X(010).*/
        public StringBasis V1SEGVG_DTNASCIM { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77           V1COND-GARAN-IEA       PIC S9(003)V99   COMP-3.*/
        public DoubleBasis V1COND_GARAN_IEA { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"77           V1COND-GARAN-IPA       PIC S9(003)V99   COMP-3.*/
        public DoubleBasis V1COND_GARAN_IPA { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"77           V1COND-GARAN-IPD       PIC S9(003)V99   COMP-3.*/
        public DoubleBasis V1COND_GARAN_IPD { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"77           V1COND-GARAN-HD        PIC S9(003)V99   COMP-3.*/
        public DoubleBasis V1COND_GARAN_HD { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"77           V1RAMO-NOMERAMO        PIC  X(040).*/
        public StringBasis V1RAMO_NOMERAMO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"77           V1RAMO-RAMO            PIC S9(004)      COMP.*/
        public IntBasis V1RAMO_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77           V1APOL-NOME            PIC  X(040).*/
        public StringBasis V1APOL_NOME { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"77           V1APOL-CODCLIEN        PIC S9(009)      COMP.*/
        public IntBasis V1APOL_CODCLIEN { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77           V1APOL-MODALIDA        PIC S9(004)      COMP.*/
        public IntBasis V1APOL_MODALIDA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77           V1APOL-PODPUBL         PIC  X(001).*/
        public StringBasis V1APOL_PODPUBL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77           V1HIST-OPERACAO        PIC S9(004)       COMP.*/
        public IntBasis V1HIST_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77           V1HIST-VAL-OPER        PIC S9(013)V99    COMP-3.*/
        public DoubleBasis V1HIST_VAL_OPER { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77           V1HIST-OCORHIST        PIC S9(004)       COMP.*/
        public IntBasis V1HIST_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77           V1HIST-DTMOVTO         PIC  X(010).*/
        public StringBasis V1HIST_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77           V1HIST-LIMCRR          PIC  X(010).*/
        public StringBasis V1HIST_LIMCRR { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77           V1HIST-NOMFAV          PIC  X(040).*/
        public StringBasis V1HIST_NOMFAV { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"77           V1MOED-VLCRUZAD        PIC S9(006)V9(09) COMP-3.*/
        public DoubleBasis V1MOED_VLCRUZAD { get; set; } = new DoubleBasis(new PIC("S9", "6", "S9(006)V9(09)"), 9);
        /*"77           V1MOED-SIGLUNIM        PIC  X(006).*/
        public StringBasis V1MOED_SIGLUNIM { get; set; } = new StringBasis(new PIC("X", "6", "X(006)."), @"");
        /*"77           V1APIT-DESCRITEM       PIC  X(080).*/
        public StringBasis V1APIT_DESCRITEM { get; set; } = new StringBasis(new PIC("X", "80", "X(080)."), @"");
        /*"77           V1CLIE-NOME            PIC  X(040).*/
        public StringBasis V1CLIE_NOME { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"77  V0COSSEG-HISTSIN-VAL-OPERACAO   PIC S9(013)V99    COMP-3.*/
        public DoubleBasis V0COSSEG_HISTSIN_VAL_OPERACAO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77  CA-VALOR-TOTAL                  PIC S9(013)V99    COMP-3.*/
        public DoubleBasis CA_VALOR_TOTAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77  WS-SQLCODE                      PIC ---9.*/
        public IntBasis WS_SQLCODE { get; set; } = new IntBasis(new PIC("9", "4", "---9."));
        /*"77  WS-NUM-APOL-SINISTRO            PIC 9(013) VALUE ZEROS.*/
        public IntBasis WS_NUM_APOL_SINISTRO { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
        /*"01  WS-SINISTRO-SMART.*/
        public SI0021B_WS_SINISTRO_SMART WS_SINISTRO_SMART { get; set; } = new SI0021B_WS_SINISTRO_SMART();
        public class SI0021B_WS_SINISTRO_SMART : VarBasis
        {
            /*"  03 WS-FONTE-SINISTRO            PIC  9(003) VALUE ZEROS.*/
            public IntBasis WS_FONTE_SINISTRO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
            /*"  03 WS-SEQ-SINISTRO              PIC  9(010) VALUE ZEROS.*/
            public IntBasis WS_SEQ_SINISTRO { get; set; } = new IntBasis(new PIC("9", "10", "9(010)"));
            /*"01 WS-VARIAVEIS.*/
        }
        public SI0021B_WS_VARIAVEIS WS_VARIAVEIS { get; set; } = new SI0021B_WS_VARIAVEIS();
        public class SI0021B_WS_VARIAVEIS : VarBasis
        {
            /*"   05 WS-PERIODO-1.*/
            public SI0021B_WS_PERIODO_1 WS_PERIODO_1 { get; set; } = new SI0021B_WS_PERIODO_1();
            public class SI0021B_WS_PERIODO_1 : VarBasis
            {
                /*"      10 WS-ANO-1                   PIC 9(04).*/
                public IntBasis WS_ANO_1 { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                /*"      10 FILLER                     PIC X(01).*/
                public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"      10 WS-MES-1                   PIC 9(02).*/
                public IntBasis WS_MES_1 { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"      10 FILLER                     PIC X(01).*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"      10 WS-DIA-1                   PIC 9(02).*/
                public IntBasis WS_DIA_1 { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"   05 WS-PERIODO-2.*/
            }
            public SI0021B_WS_PERIODO_2 WS_PERIODO_2 { get; set; } = new SI0021B_WS_PERIODO_2();
            public class SI0021B_WS_PERIODO_2 : VarBasis
            {
                /*"      10 WS-DIA-2                   PIC 9(02).*/
                public IntBasis WS_DIA_2 { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"      10 FILLER                     PIC X(01) VALUE '/'.*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"/");
                /*"      10 WS-MES-2                   PIC 9(02).*/
                public IntBasis WS_MES_2 { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"      10 FILLER                     PIC X(01) VALUE '/'.*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"/");
                /*"      10 WS-ANO-2                   PIC 9(04).*/
                public IntBasis WS_ANO_2 { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                /*"01 CAPA-RELATORIO.*/
            }
        }
        public SI0021B_CAPA_RELATORIO CAPA_RELATORIO { get; set; } = new SI0021B_CAPA_RELATORIO();
        public class SI0021B_CAPA_RELATORIO : VarBasis
        {
            /*"  03 SEP02.*/
            public SI0021B_SEP02 SEP02 { get; set; } = new SI0021B_SEP02();
            public class SI0021B_SEP02 : VarBasis
            {
                /*"     05 FILLER                        PIC  X(001) VALUE ALL ' '.*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"ALL");
                /*"     05 FILLER                        PIC  X(079) VALUE ALL '*'.*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "79", "X(079)"), @"ALL");
                /*"  03 SEP03.*/
            }
            public SI0021B_SEP03 SEP03 { get; set; } = new SI0021B_SEP03();
            public class SI0021B_SEP03 : VarBasis
            {
                /*"     05 FILLER                        PIC  X(002) VALUE ' *'.*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @" *");
                /*"     05 FILLER                        PIC  X(077) VALUE SPACES.*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "77", "X(077)"), @"");
                /*"     05 FILLER                        PIC  X(001) VALUE '*'.*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"*");
                /*"  03 SEP04.*/
            }
            public SI0021B_SEP04 SEP04 { get; set; } = new SI0021B_SEP04();
            public class SI0021B_SEP04 : VarBasis
            {
                /*"     05 FILLER                        PIC  X(002) VALUE ' *'.*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @" *");
                /*"     05 FILLER                        PIC  X(001) VALUE SPACES.*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"     05 FILLER                        PIC  X(033) VALUE        '*** ATENCAO: ENVIAR OS RELATORIOS'.*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "33", "X(033)"), @"*** ATENCAO: ENVIAR OS RELATORIOS");
                /*"     05 FILLER                        PIC  X(042) VALUE        ' IMPRESSOS A SEGUIR PARA O SEGUINTE LOCAL:'.*/
                public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "42", "X(042)"), @" IMPRESSOS A SEGUIR PARA O SEGUINTE LOCAL:");
                /*"     05 FILLER                        PIC  X(001) VALUE SPACES.*/
                public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"     05 FILLER                        PIC  X(001) VALUE '*'.*/
                public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"*");
                /*"  03 SEP05.*/
            }
            public SI0021B_SEP05 SEP05 { get; set; } = new SI0021B_SEP05();
            public class SI0021B_SEP05 : VarBasis
            {
                /*"     05 FILLER                        PIC  X(002) VALUE ' *'.*/
                public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @" *");
                /*"     05 FILLER                        PIC  X(003) VALUE SPACES.*/
                public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
                /*"     05 FILLER                        PIC  X(020) VALUE        'FONTE.............: '.*/
                public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"FONTE.............: ");
                /*"     05 FONTE-SEP05                   PIC  9(003) VALUE ZEROS.*/
                public IntBasis FONTE_SEP05 { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
                /*"     05 FILLER                        PIC  X(003) VALUE ' - '.*/
                public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" - ");
                /*"     05 NOME-FONTE-SEP05              PIC  X(040) VALUE SPACES.*/
                public StringBasis NOME_FONTE_SEP05 { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"     05 FILLER                        PIC  X(008) VALUE SPACES.*/
                public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
                /*"     05 FILLER                        PIC  X(001) VALUE '*'.*/
                public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"*");
                /*"  03 SEP06.*/
            }
            public SI0021B_SEP06 SEP06 { get; set; } = new SI0021B_SEP06();
            public class SI0021B_SEP06 : VarBasis
            {
                /*"     05 FILLER                        PIC  X(002) VALUE ' *'.*/
                public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @" *");
                /*"     05 FILLER                        PIC  X(003) VALUE SPACES.*/
                public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
                /*"     05 FILLER                        PIC  X(020) VALUE        'PRODUTO...........: '.*/
                public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"PRODUTO...........: ");
                /*"     05 PRODUTO-SEP06                 PIC  9(004) VALUE ZEROS.*/
                public IntBasis PRODUTO_SEP06 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"     05 FILLER                        PIC  X(003) VALUE ' - '.*/
                public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" - ");
                /*"     05 NOME-PRODUTO-SEP06            PIC  X(040) VALUE SPACES.*/
                public StringBasis NOME_PRODUTO_SEP06 { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"     05 FILLER                        PIC  X(007) VALUE SPACES.*/
                public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"");
                /*"     05 FILLER                        PIC  X(001) VALUE '*'.*/
                public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"*");
                /*"  03 SEP07.*/
            }
            public SI0021B_SEP07 SEP07 { get; set; } = new SI0021B_SEP07();
            public class SI0021B_SEP07 : VarBasis
            {
                /*"     05 FILLER                       PIC  X(002) VALUE ' *'.*/
                public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @" *");
                /*"     05 FILLER                       PIC  X(003) VALUE SPACES.*/
                public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
                /*"     05 FILLER                       PIC  X(020) VALUE        'UNIDADE DE DESTINO: '.*/
                public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"UNIDADE DE DESTINO: ");
                /*"     05 LOTACAO-SEP07                PIC  X(010) VALUE SPACES.*/
                public StringBasis LOTACAO_SEP07 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"     05 FILLER                       PIC  X(001) VALUE SPACES.*/
                public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"     05 FILLER                       PIC  X(043) VALUE SPACES.*/
                public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "43", "X(043)"), @"");
                /*"     05 FILLER                       PIC  X(001) VALUE '*'.*/
                public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"*");
                /*"  03 SEP07A.*/
            }
            public SI0021B_SEP07A SEP07A { get; set; } = new SI0021B_SEP07A();
            public class SI0021B_SEP07A : VarBasis
            {
                /*"     05 FILLER                       PIC  X(002) VALUE ' *'.*/
                public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @" *");
                /*"     05 FILLER                       PIC  X(003) VALUE SPACES.*/
                public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
                /*"     05 FILLER                       PIC  X(032) VALUE        'RESPONSAVEL UNIDADE DE DESTINO: '.*/
                public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "32", "X(032)"), @"RESPONSAVEL UNIDADE DE DESTINO: ");
                /*"     05 RESPONSAVEL-SEP07            PIC  X(040) VALUE SPACES.*/
                public StringBasis RESPONSAVEL_SEP07 { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"     05 FILLER                       PIC  X(002) VALUE SPACES.*/
                public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
                /*"     05 FILLER                       PIC  X(001) VALUE '*'.*/
                public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"*");
                /*"  03 SEP08.*/
            }
            public SI0021B_SEP08 SEP08 { get; set; } = new SI0021B_SEP08();
            public class SI0021B_SEP08 : VarBasis
            {
                /*"     05 FILLER                       PIC  X(002) VALUE ' *'.*/
                public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @" *");
                /*"     05 FILLER                       PIC  X(061) VALUE SPACES.*/
                public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "61", "X(061)"), @"");
                /*"     05 TP-OPERACAO-SEP08            PIC  X(016) VALUE SPACES.*/
                public StringBasis TP_OPERACAO_SEP08 { get; set; } = new StringBasis(new PIC("X", "16", "X(016)"), @"");
                /*"     05 FILLER                       PIC  X(001) VALUE '*'.*/
                public StringBasis FILLER_40 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"*");
                /*"01              W.*/
            }
        }
        public SI0021B_W W { get; set; } = new SI0021B_W();
        public class SI0021B_W : VarBasis
        {
            /*"  03            LCB.*/
            public SI0021B_LCB LCB { get; set; } = new SI0021B_LCB();
            public class SI0021B_LCB : VarBasis
            {
                /*"    05          FILLER              PIC  X(132) VALUE SPACES.*/
                public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "132", "X(132)"), @"");
                /*"  03            LC00.*/
            }
            public SI0021B_LC00 LC00 { get; set; } = new SI0021B_LC00();
            public class SI0021B_LC00 : VarBasis
            {
                /*"    05          FILLER              PIC  X(001) VALUE 'I'.*/
                public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"I");
                /*"    05          FILLER              PIC  X(130) VALUE SPACES.*/
                public StringBasis FILLER_43 { get; set; } = new StringBasis(new PIC("X", "130", "X(130)"), @"");
                /*"    05          FILLER              PIC  X(001) VALUE 'I'.*/
                public StringBasis FILLER_44 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"I");
                /*"  03            LC01.*/
            }
            public SI0021B_LC01 LC01 { get; set; } = new SI0021B_LC01();
            public class SI0021B_LC01 : VarBasis
            {
                /*"    05          LC01-RELATORIO      PIC  X(007) VALUE 'SI0021B'.*/
                public StringBasis LC01_RELATORIO { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"SI0021B");
                /*"    05          FILLER              PIC  X(036) VALUE  SPACES.*/
                public StringBasis FILLER_45 { get; set; } = new StringBasis(new PIC("X", "36", "X(036)"), @"");
                /*"    05          LC01-EMPRESA        PIC  X(040) VALUE  SPACES.*/
                public StringBasis LC01_EMPRESA { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"    05          FILLER              PIC  X(034) VALUE  SPACES.*/
                public StringBasis FILLER_46 { get; set; } = new StringBasis(new PIC("X", "34", "X(034)"), @"");
                /*"    05          FILLER              PIC  X(011) VALUE 'PAGINA'.*/
                public StringBasis FILLER_47 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"PAGINA");
                /*"    05          LC01-PAG            PIC  ZZZ9.*/
                public IntBasis LC01_PAG { get; set; } = new IntBasis(new PIC("9", "4", "ZZZ9."));
                /*"  03            LC02.*/
            }
            public SI0021B_LC02 LC02 { get; set; } = new SI0021B_LC02();
            public class SI0021B_LC02 : VarBasis
            {
                /*"    05          FILLER              PIC  X(060) VALUE SPACES.*/
                public StringBasis FILLER_48 { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"");
                /*"    05          FILLER              PIC  X(057) VALUE  SPACES.*/
                public StringBasis FILLER_49 { get; set; } = new StringBasis(new PIC("X", "57", "X(057)"), @"");
                /*"    05          FILLER              PIC  X(005) VALUE 'DATA'.*/
                public StringBasis FILLER_50 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"DATA");
                /*"    05          LC02-DATA           PIC  X(010) VALUE  SPACES.*/
                public StringBasis LC02_DATA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"  03            LC03.*/
            }
            public SI0021B_LC03 LC03 { get; set; } = new SI0021B_LC03();
            public class SI0021B_LC03 : VarBasis
            {
                /*"    05          FILLER              PIC  X(048) VALUE  SPACES.*/
                public StringBasis FILLER_51 { get; set; } = new StringBasis(new PIC("X", "48", "X(048)"), @"");
                /*"    05          FILLER              PIC  X(030) VALUE               'CARTA DE SINISTRO DE COSSEGURO'.*/
                public StringBasis FILLER_52 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"CARTA DE SINISTRO DE COSSEGURO");
                /*"    05          FILLER              PIC  X(039) VALUE  SPACES.*/
                public StringBasis FILLER_53 { get; set; } = new StringBasis(new PIC("X", "39", "X(039)"), @"");
                /*"    05          FILLER              PIC  X(007) VALUE 'HORA'.*/
                public StringBasis FILLER_54 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"HORA");
                /*"    05          LC03-HORA           PIC  X(008) VALUE  SPACES.*/
                public StringBasis LC03_HORA { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
                /*"  03            LC04.*/
            }
            public SI0021B_LC04 LC04 { get; set; } = new SI0021B_LC04();
            public class SI0021B_LC04 : VarBasis
            {
                /*"    05          FILLER              PIC  X(001) VALUE SPACES.*/
                public StringBasis FILLER_55 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          FILLER              PIC  X(006) VALUE               'A CIA.'.*/
                public StringBasis FILLER_56 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"A CIA.");
                /*"    05          FILLER              PIC  X(125) VALUE SPACES.*/
                public StringBasis FILLER_57 { get; set; } = new StringBasis(new PIC("X", "125", "X(125)"), @"");
                /*"  03 LC05.*/
            }
            public SI0021B_LC05 LC05 { get; set; } = new SI0021B_LC05();
            public class SI0021B_LC05 : VarBasis
            {
                /*"    05 FILLER                   PIC X(001) VALUE SPACES.*/
                public StringBasis FILLER_58 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05 LC05-CODCOSS             PIC 9(004).*/
                public IntBasis LC05_CODCOSS { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05 FILLER                   PIC X(002) VALUE SPACES.*/
                public StringBasis FILLER_59 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
                /*"    05 LC05-NOMECONG            PIC X(046) VALUE SPACES.*/
                public StringBasis LC05_NOMECONG { get; set; } = new StringBasis(new PIC("X", "46", "X(046)"), @"");
                /*"    05 LC05-TEXTO-1             PIC X(012) VALUE SPACES.*/
                public StringBasis LC05_TEXTO_1 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"");
                /*"    05 LC05-PERI-INICIAL        PIC X(010) VALUE SPACES.*/
                public StringBasis LC05_PERI_INICIAL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"    05 LC05-TEXTO-2             PIC X(003) VALUE SPACES.*/
                public StringBasis LC05_TEXTO_2 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
                /*"    05 LC05-PERI-FINAL          PIC X(010) VALUE SPACES.*/
                public StringBasis LC05_PERI_FINAL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"    05 FILLER                   PIC X(044) VALUE SPACES.*/
                public StringBasis FILLER_60 { get; set; } = new StringBasis(new PIC("X", "44", "X(044)"), @"");
                /*"  03            LC06.*/
            }
            public SI0021B_LC06 LC06 { get; set; } = new SI0021B_LC06();
            public class SI0021B_LC06 : VarBasis
            {
                /*"    05          FILLER              PIC  X(001) VALUE SPACES.*/
                public StringBasis FILLER_61 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          FILLER              PIC  X(011) VALUE                                               'REFERENTE  '.*/
                public StringBasis FILLER_62 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"REFERENTE  ");
                /*"    05          LC06-REFER          PIC  X(045) VALUE SPACES.*/
                public StringBasis LC06_REFER { get; set; } = new StringBasis(new PIC("X", "45", "X(045)"), @"");
                /*"    05          FILLER              PIC  X(046) VALUE SPACES.*/
                public StringBasis FILLER_63 { get; set; } = new StringBasis(new PIC("X", "46", "X(046)"), @"");
                /*"    05          FILLER              PIC  X(016) VALUE                                   'SINISTRO LIDER  '.*/
                public StringBasis FILLER_64 { get; set; } = new StringBasis(new PIC("X", "16", "X(016)"), @"SINISTRO LIDER  ");
                /*"    05          LC06-SINISTRO       PIC  9(013) VALUE ZEROS.*/
                public IntBasis LC06_SINISTRO { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
                /*"  03            LC07.*/
            }
            public SI0021B_LC07 LC07 { get; set; } = new SI0021B_LC07();
            public class SI0021B_LC07 : VarBasis
            {
                /*"    05          FILLER              PIC  X(001) VALUE '+'.*/
                public StringBasis FILLER_65 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"+");
                /*"    05          FILLER              PIC  X(049) VALUE ALL '-'.*/
                public StringBasis FILLER_66 { get; set; } = new StringBasis(new PIC("X", "49", "X(049)"), @"ALL");
                /*"    05          FILLER              PIC  X(004) VALUE '*   '.*/
                public StringBasis FILLER_67 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"*   ");
                /*"    05          FILLER              PIC  X(024) VALUE                                   'D A D O S    G E R A I S'.*/
                public StringBasis FILLER_68 { get; set; } = new StringBasis(new PIC("X", "24", "X(024)"), @"D A D O S    G E R A I S");
                /*"    05          FILLER              PIC  X(004) VALUE '   *'.*/
                public StringBasis FILLER_69 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"   *");
                /*"    05          FILLER              PIC  X(049) VALUE ALL '-'.*/
                public StringBasis FILLER_70 { get; set; } = new StringBasis(new PIC("X", "49", "X(049)"), @"ALL");
                /*"    05          FILLER              PIC  X(001) VALUE '+'.*/
                public StringBasis FILLER_71 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"+");
                /*"  03            LC08.*/
            }
            public SI0021B_LC08 LC08 { get; set; } = new SI0021B_LC08();
            public class SI0021B_LC08 : VarBasis
            {
                /*"    05          FILLER              PIC  X(001) VALUE 'I'.*/
                public StringBasis FILLER_72 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"I");
                /*"    05          FILLER              PIC  X(001) VALUE SPACES.*/
                public StringBasis FILLER_73 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          FILLER              PIC  X(008) VALUE 'SEGURADO'*/
                public StringBasis FILLER_74 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"SEGURADO");
                /*"    05          FILLER              PIC  X(034) VALUE SPACES.*/
                public StringBasis FILLER_75 { get; set; } = new StringBasis(new PIC("X", "34", "X(034)"), @"");
                /*"    05          FILLER              PIC  X(004) VALUE 'RAMO'.*/
                public StringBasis FILLER_76 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"RAMO");
                /*"    05          FILLER              PIC  X(037) VALUE SPACES.*/
                public StringBasis FILLER_77 { get; set; } = new StringBasis(new PIC("X", "37", "X(037)"), @"");
                /*"    05          FILLER              PIC  X(017) VALUE                                   'PERC.PARTICIPACAO'.*/
                public StringBasis FILLER_78 { get; set; } = new StringBasis(new PIC("X", "17", "X(017)"), @"PERC.PARTICIPACAO");
                /*"    05          FILLER              PIC  X(003) VALUE SPACES.*/
                public StringBasis FILLER_79 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
                /*"    05          FILLER              PIC  X(013) VALUE                                   'DATA SINISTRO'.*/
                public StringBasis FILLER_80 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"DATA SINISTRO");
                /*"    05          FILLER              PIC  X(002) VALUE SPACES.*/
                public StringBasis FILLER_81 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
                /*"    05          FILLER              PIC  X(010) VALUE                                   'DATA AVISO'.*/
                public StringBasis FILLER_82 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"DATA AVISO");
                /*"    05          FILLER              PIC  X(002) VALUE ' I'.*/
                public StringBasis FILLER_83 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @" I");
                /*"  03            LC09.*/
            }
            public SI0021B_LC09 LC09 { get; set; } = new SI0021B_LC09();
            public class SI0021B_LC09 : VarBasis
            {
                /*"    05          FILLER              PIC  X(001) VALUE 'I'.*/
                public StringBasis FILLER_84 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"I");
                /*"    05          FILLER              PIC  X(001) VALUE SPACES.*/
                public StringBasis FILLER_85 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          LC09-NOME           PIC  X(040) VALUE SPACES.*/
                public StringBasis LC09_NOME { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"    05          FILLER              PIC  X(002) VALUE SPACES.*/
                public StringBasis FILLER_86 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
                /*"    05          LC09-NOMERAMO       PIC  X(040) VALUE SPACES.*/
                public StringBasis LC09_NOMERAMO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"    05          FILLER              PIC  X(009) VALUE SPACES.*/
                public StringBasis FILLER_87 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"");
                /*"    05          LC09-PCPARTIC       PIC  ZZ9,99999                                    BLANK WHEN ZERO.*/
                public DoubleBasis LC09_PCPARTIC { get; set; } = new DoubleBasis(new PIC("9", "3", "ZZ9V99999"), 5);
                /*"    05          FILLER              PIC  X(005) VALUE SPACES.*/
                public StringBasis FILLER_88 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
                /*"    05          LC09-DTSINI.*/
                public SI0021B_LC09_DTSINI LC09_DTSINI { get; set; } = new SI0021B_LC09_DTSINI();
                public class SI0021B_LC09_DTSINI : VarBasis
                {
                    /*"      07        LC09-DD-SINI        PIC  9(002).*/
                    public IntBasis LC09_DD_SINI { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"      07        FILLER              PIC  X(001) VALUE '/'.*/
                    public StringBasis FILLER_89 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                    /*"      07        LC09-MM-SINI        PIC  9(002).*/
                    public IntBasis LC09_MM_SINI { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"      07        FILLER              PIC  X(001) VALUE '/'.*/
                    public StringBasis FILLER_90 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                    /*"      07        LC09-AA-SINI        PIC  9(004).*/
                    public IntBasis LC09_AA_SINI { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"    05          FILLER              PIC  X(003) VALUE SPACES.*/
                }
                public StringBasis FILLER_91 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
                /*"    05          LC09-DTAVISO.*/
                public SI0021B_LC09_DTAVISO LC09_DTAVISO { get; set; } = new SI0021B_LC09_DTAVISO();
                public class SI0021B_LC09_DTAVISO : VarBasis
                {
                    /*"      07        LC09-DD-AVISO       PIC  9(002).*/
                    public IntBasis LC09_DD_AVISO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"      07        FILLER              PIC  X(001) VALUE '/'.*/
                    public StringBasis FILLER_92 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                    /*"      07        LC09-MM-AVISO       PIC  9(002).*/
                    public IntBasis LC09_MM_AVISO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"      07        FILLER              PIC  X(001) VALUE '/'.*/
                    public StringBasis FILLER_93 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                    /*"      07        LC09-AA-AVISO       PIC  9(004).*/
                    public IntBasis LC09_AA_AVISO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"    05          FILLER              PIC  X(001) VALUE SPACES.*/
                }
                public StringBasis FILLER_94 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          FILLER              PIC  X(001) VALUE 'I'.*/
                public StringBasis FILLER_95 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"I");
                /*"  03            LC10.*/
            }
            public SI0021B_LC10 LC10 { get; set; } = new SI0021B_LC10();
            public class SI0021B_LC10 : VarBasis
            {
                /*"    05          FILLER              PIC  X(001) VALUE 'I'.*/
                public StringBasis FILLER_96 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"I");
                /*"    05          FILLER              PIC  X(001) VALUE SPACES.*/
                public StringBasis FILLER_97 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          FILLER              PIC  X(007) VALUE                                   'APOLICE'.*/
                public StringBasis FILLER_98 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"APOLICE");
                /*"    05          FILLER              PIC  X(010) VALUE SPACES.*/
                public StringBasis FILLER_99 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"    05          FILLER              PIC  X(015) VALUE                                   'NUMERO DE ORDEM'.*/
                public StringBasis FILLER_100 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"NUMERO DE ORDEM");
                /*"    05          FILLER              PIC  X(010) VALUE SPACES.*/
                public StringBasis FILLER_101 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"    05          FILLER              PIC  X(005) VALUE 'MOEDA'.*/
                public StringBasis FILLER_102 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"MOEDA");
                /*"    05          FILLER              PIC  X(009) VALUE SPACES.*/
                public StringBasis FILLER_103 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"");
                /*"    05          FILLER              PIC  X(015) VALUE                                   'V I G E N C I A'.*/
                public StringBasis FILLER_104 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"V I G E N C I A");
                /*"    05          FILLER              PIC  X(012) VALUE SPACES.*/
                public StringBasis FILLER_105 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"");
                /*"    05          FILLER              PIC  X(004) VALUE 'ITEM'.*/
                public StringBasis FILLER_106 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"ITEM");
                /*"    05          FILLER              PIC  X(034) VALUE SPACES.*/
                public StringBasis FILLER_107 { get; set; } = new StringBasis(new PIC("X", "34", "X(034)"), @"");
                /*"    05          FILLER              PIC  X(007) VALUE 'IS ITEM'.*/
                public StringBasis FILLER_108 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"IS ITEM");
                /*"    05          FILLER              PIC  X(002) VALUE ' I'.*/
                public StringBasis FILLER_109 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @" I");
                /*"  03            LC11.*/
            }
            public SI0021B_LC11 LC11 { get; set; } = new SI0021B_LC11();
            public class SI0021B_LC11 : VarBasis
            {
                /*"    05          FILLER              PIC  X(001) VALUE 'I'.*/
                public StringBasis FILLER_110 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"I");
                /*"    05          FILLER              PIC  X(001) VALUE SPACES.*/
                public StringBasis FILLER_111 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          LC11-APOLICE        PIC  9(013) VALUE ZEROS.*/
                public IntBasis LC11_APOLICE { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
                /*"    05          FILLER              PIC  X(004) VALUE SPACES.*/
                public StringBasis FILLER_112 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                /*"    05          LC11-NRORDEM        PIC  9(015) BLANK WHEN ZERO.*/
                public IntBasis LC11_NRORDEM { get; set; } = new IntBasis(new PIC("9", "15", "9(015)"));
                /*"    05          FILLER              PIC  X(010) VALUE SPACES.*/
                public StringBasis FILLER_113 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"    05          LC11-SIGLUNIM       PIC  X(006) VALUE SPACES.*/
                public StringBasis LC11_SIGLUNIM { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"");
                /*"    05          FILLER              PIC  X(004) VALUE SPACES.*/
                public StringBasis FILLER_114 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                /*"    05          LC11-DTINIVIG.*/
                public SI0021B_LC11_DTINIVIG LC11_DTINIVIG { get; set; } = new SI0021B_LC11_DTINIVIG();
                public class SI0021B_LC11_DTINIVIG : VarBasis
                {
                    /*"      07        LC11-DD-I           PIC  9(002).*/
                    public IntBasis LC11_DD_I { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"      07        FILLER              PIC  X(001) VALUE '/'.*/
                    public StringBasis FILLER_115 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                    /*"      07        LC11-MM-I           PIC  9(002).*/
                    public IntBasis LC11_MM_I { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"      07        FILLER              PIC  X(001) VALUE '/'.*/
                    public StringBasis FILLER_116 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                    /*"      07        LC11-AA-I           PIC  9(004).*/
                    public IntBasis LC11_AA_I { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"    05          FILLER              PIC  X(003) VALUE ' A '.*/
                }
                public StringBasis FILLER_117 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" A ");
                /*"    05          LC11-DTTERVIG.*/
                public SI0021B_LC11_DTTERVIG LC11_DTTERVIG { get; set; } = new SI0021B_LC11_DTTERVIG();
                public class SI0021B_LC11_DTTERVIG : VarBasis
                {
                    /*"      07        LC11-DD-T           PIC  9(002) BLANK WHEN ZERO.*/
                    public IntBasis LC11_DD_T { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                    /*"      07        FILLER              PIC  X(001) VALUE '/'.*/
                    public StringBasis FILLER_118 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                    /*"      07        LC11-MM-T           PIC  9(002) BLANK WHEN ZERO.*/
                    public IntBasis LC11_MM_T { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                    /*"      07        FILLER              PIC  X(001) VALUE '/'.*/
                    public StringBasis FILLER_119 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                    /*"      07        LC11-AA-T           PIC  9(004) BLANK WHEN ZERO.*/
                    public IntBasis LC11_AA_T { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                    /*"    05          FILLER              PIC  X(008) VALUE SPACES.*/
                }
                public StringBasis FILLER_120 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
                /*"    05          LC11-ITEM           PIC  9(015) VALUE ZEROS.*/
                public IntBasis LC11_ITEM { get; set; } = new IntBasis(new PIC("9", "15", "9(015)"));
                /*"    05          FILLER              PIC  X(001) VALUE SPACES.*/
                public StringBasis FILLER_121 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          LC11-IDTPSEGU       PIC  X(001) VALUE ZEROS.*/
                public StringBasis LC11_IDTPSEGU { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          FILLER              PIC  X(008) VALUE SPACES.*/
                public StringBasis FILLER_122 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
                /*"    05          LC11-ISITEM         PIC  Z.ZZZ.ZZZ.ZZZ.ZZ9,99                                    BLANK WHEN ZERO.*/
                public DoubleBasis LC11_ISITEM { get; set; } = new DoubleBasis(new PIC("9", "13", "Z.ZZZ.ZZZ.ZZZ.ZZ9V99"), 2);
                /*"    05          FILLER              PIC  X(002) VALUE ' I'.*/
                public StringBasis FILLER_123 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @" I");
                /*"  03            LC12.*/
            }
            public SI0021B_LC12 LC12 { get; set; } = new SI0021B_LC12();
            public class SI0021B_LC12 : VarBasis
            {
                /*"    05          FILLER              PIC  X(001) VALUE 'I'.*/
                public StringBasis FILLER_124 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"I");
                /*"    05          FILLER              PIC  X(001) VALUE SPACES.*/
                public StringBasis FILLER_125 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          FILLER              PIC  X(010) VALUE                'FAVORECIDO'.*/
                public StringBasis FILLER_126 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"FAVORECIDO");
                /*"    05          FILLER              PIC  X(046) VALUE SPACES.*/
                public StringBasis FILLER_127 { get; set; } = new StringBasis(new PIC("X", "46", "X(046)"), @"");
                /*"    05          FILLER              PIC  X(012) VALUE                'SINISTRO IRB'.*/
                public StringBasis FILLER_128 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"SINISTRO IRB");
                /*"    05          FILLER              PIC  X(015) VALUE SPACES.*/
                public StringBasis FILLER_129 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"");
                /*"    05          LC13-TITULO         PIC  X(014) VALUE SPACES.*/
                public StringBasis LC13_TITULO { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"");
                /*"    05          FILLER              PIC  X(032) VALUE SPACES.*/
                public StringBasis FILLER_130 { get; set; } = new StringBasis(new PIC("X", "32", "X(032)"), @"");
                /*"    05          FILLER              PIC  X(001) VALUE 'I'.*/
                public StringBasis FILLER_131 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"I");
                /*"  03            LC13.*/
            }
            public SI0021B_LC13 LC13 { get; set; } = new SI0021B_LC13();
            public class SI0021B_LC13 : VarBasis
            {
                /*"    05          FILLER              PIC  X(001) VALUE 'I'.*/
                public StringBasis FILLER_132 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"I");
                /*"    05          FILLER              PIC  X(001) VALUE SPACES.*/
                public StringBasis FILLER_133 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          LC13-NOMFAV         PIC  X(030) VALUE SPACES.*/
                public StringBasis LC13_NOMFAV { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"");
                /*"    05          FILLER              PIC  X(026) VALUE SPACES.*/
                public StringBasis FILLER_134 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @"");
                /*"    05          LC13-SINIRB         PIC  9(013) VALUE ZEROS.*/
                public IntBasis LC13_SINIRB { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
                /*"    05          FILLER              PIC  X(016) VALUE SPACES.*/
                public StringBasis FILLER_135 { get; set; } = new StringBasis(new PIC("X", "16", "X(016)"), @"");
                /*"    05          LC13-LIMCRR.*/
                public SI0021B_LC13_LIMCRR LC13_LIMCRR { get; set; } = new SI0021B_LC13_LIMCRR();
                public class SI0021B_LC13_LIMCRR : VarBasis
                {
                    /*"      07       LC13-DDLIMCRR       PIC  X(002) VALUE SPACES.*/
                    public StringBasis LC13_DDLIMCRR { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
                    /*"      07       LC13-BARRA1         PIC  X(001) VALUE SPACES.*/
                    public StringBasis LC13_BARRA1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                    /*"      07       LC13-MMLIMCRR       PIC  X(002) VALUE SPACES.*/
                    public StringBasis LC13_MMLIMCRR { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
                    /*"      07       LC13-BARRA2         PIC  X(001) VALUE SPACES.*/
                    public StringBasis LC13_BARRA2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                    /*"      07       LC13-AALIMCRR       PIC  X(004) VALUE SPACES.*/
                    public StringBasis LC13_AALIMCRR { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                    /*"    05          FILLER              PIC  X(034) VALUE SPACES.*/
                }
                public StringBasis FILLER_136 { get; set; } = new StringBasis(new PIC("X", "34", "X(034)"), @"");
                /*"    05          FILLER              PIC  X(001) VALUE 'I'.*/
                public StringBasis FILLER_137 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"I");
                /*"  03            LC14.*/
            }
            public SI0021B_LC14 LC14 { get; set; } = new SI0021B_LC14();
            public class SI0021B_LC14 : VarBasis
            {
                /*"    05          FILLER              PIC  X(001) VALUE '+'.*/
                public StringBasis FILLER_138 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"+");
                /*"    05          FILLER              PIC  X(048) VALUE ALL '-'.*/
                public StringBasis FILLER_139 { get; set; } = new StringBasis(new PIC("X", "48", "X(048)"), @"ALL");
                /*"    05          FILLER              PIC  X(004) VALUE '*   '.*/
                public StringBasis FILLER_140 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"*   ");
                /*"    05          FILLER              PIC  X(026) VALUE                                   'DADOS ESPECIFICOS AUTO/RCF'.*/
                public StringBasis FILLER_141 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @"DADOS ESPECIFICOS AUTO/RCF");
                /*"    05          FILLER              PIC  X(004) VALUE '   *'.*/
                public StringBasis FILLER_142 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"   *");
                /*"    05          FILLER              PIC  X(048) VALUE ALL '-'.*/
                public StringBasis FILLER_143 { get; set; } = new StringBasis(new PIC("X", "48", "X(048)"), @"ALL");
                /*"    05          FILLER              PIC  X(001) VALUE '+'.*/
                public StringBasis FILLER_144 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"+");
                /*"  03            LC15.*/
            }
            public SI0021B_LC15 LC15 { get; set; } = new SI0021B_LC15();
            public class SI0021B_LC15 : VarBasis
            {
                /*"    05          FILLER              PIC  X(001) VALUE 'I'.*/
                public StringBasis FILLER_145 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"I");
                /*"    05          FILLER              PIC  X(001) VALUE SPACES.*/
                public StringBasis FILLER_146 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          FILLER              PIC  X(005) VALUE 'MARCA'.*/
                public StringBasis FILLER_147 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"MARCA");
                /*"    05          FILLER              PIC  X(051) VALUE SPACES.*/
                public StringBasis FILLER_148 { get; set; } = new StringBasis(new PIC("X", "51", "X(051)"), @"");
                /*"    05          FILLER              PIC  X(005) VALUE 'PLACA'.*/
                public StringBasis FILLER_149 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"PLACA");
                /*"    05          FILLER              PIC  X(023) VALUE SPACES.*/
                public StringBasis FILLER_150 { get; set; } = new StringBasis(new PIC("X", "23", "X(023)"), @"");
                /*"    05          FILLER              PIC  X(007) VALUE 'CHASSIS'.*/
                public StringBasis FILLER_151 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"CHASSIS");
                /*"    05          FILLER              PIC  X(023) VALUE SPACES.*/
                public StringBasis FILLER_152 { get; set; } = new StringBasis(new PIC("X", "23", "X(023)"), @"");
                /*"    05          FILLER              PIC  X(014) VALUE                                   'ANO FABRICACAO'.*/
                public StringBasis FILLER_153 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"ANO FABRICACAO");
                /*"    05          FILLER              PIC  X(002) VALUE ' I'.*/
                public StringBasis FILLER_154 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @" I");
                /*"  03            LC16.*/
            }
            public SI0021B_LC16 LC16 { get; set; } = new SI0021B_LC16();
            public class SI0021B_LC16 : VarBasis
            {
                /*"    05          FILLER              PIC  X(001) VALUE 'I'.*/
                public StringBasis FILLER_155 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"I");
                /*"    05          FILLER              PIC  X(001) VALUE SPACES.*/
                public StringBasis FILLER_156 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          LC16-DESCVEIC       PIC  X(040) VALUE SPACES.*/
                public StringBasis LC16_DESCVEIC { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"    05          FILLER              PIC  X(016) VALUE SPACES.*/
                public StringBasis FILLER_157 { get; set; } = new StringBasis(new PIC("X", "16", "X(016)"), @"");
                /*"    05          LC16-PLACA.*/
                public SI0021B_LC16_PLACA LC16_PLACA { get; set; } = new SI0021B_LC16_PLACA();
                public class SI0021B_LC16_PLACA : VarBasis
                {
                    /*"      07        LC16-PLACALET       PIC  X(003) VALUE SPACES.*/
                    public StringBasis LC16_PLACALET { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
                    /*"      07        FILLER              PIC  X(001) VALUE SPACES.*/
                    public StringBasis FILLER_158 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                    /*"      07        LC16-PLACANR        PIC  X(004) VALUE SPACES.*/
                    public StringBasis LC16_PLACANR { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                    /*"    05          FILLER              PIC  X(020) VALUE SPACES.*/
                }
                public StringBasis FILLER_159 { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"");
                /*"    05          LC16-CHASSIS        PIC  X(022) VALUE SPACES.*/
                public StringBasis LC16_CHASSIS { get; set; } = new StringBasis(new PIC("X", "22", "X(022)"), @"");
                /*"    05          FILLER              PIC  X(013) VALUE SPACES.*/
                public StringBasis FILLER_160 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"");
                /*"    05          LC16-ANOVEICL       PIC  9(004) BLANK WHEN ZERO.*/
                public IntBasis LC16_ANOVEICL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"    05          FILLER              PIC  X(006) VALUE SPACES.*/
                public StringBasis FILLER_161 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"");
                /*"    05          FILLER              PIC  X(001) VALUE 'I'.*/
                public StringBasis FILLER_162 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"I");
                /*"  03            LC17.*/
            }
            public SI0021B_LC17 LC17 { get; set; } = new SI0021B_LC17();
            public class SI0021B_LC17 : VarBasis
            {
                /*"    05          FILLER              PIC  X(001) VALUE '+'.*/
                public StringBasis FILLER_163 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"+");
                /*"    05          FILLER              PIC  X(041) VALUE ALL '-'.*/
                public StringBasis FILLER_164 { get; set; } = new StringBasis(new PIC("X", "41", "X(041)"), @"ALL");
                /*"    05          FILLER              PIC  X(004) VALUE '*   '.*/
                public StringBasis FILLER_165 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"*   ");
                /*"    05          FILLER              PIC  X(039) VALUE                'DADOS ESPECIFICOS INC / LC / RD / R.ENG'.*/
                public StringBasis FILLER_166 { get; set; } = new StringBasis(new PIC("X", "39", "X(039)"), @"DADOS ESPECIFICOS INC / LC / RD / R.ENG");
                /*"    05          FILLER              PIC  X(004) VALUE '   *'.*/
                public StringBasis FILLER_167 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"   *");
                /*"    05          FILLER              PIC  X(042) VALUE ALL '-'.*/
                public StringBasis FILLER_168 { get; set; } = new StringBasis(new PIC("X", "42", "X(042)"), @"ALL");
                /*"    05          FILLER              PIC  X(001) VALUE '+'.*/
                public StringBasis FILLER_169 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"+");
                /*"  03            LC18.*/
            }
            public SI0021B_LC18 LC18 { get; set; } = new SI0021B_LC18();
            public class SI0021B_LC18 : VarBasis
            {
                /*"    05          FILLER              PIC  X(001) VALUE 'I'.*/
                public StringBasis FILLER_170 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"I");
                /*"    05          FILLER              PIC  X(001) VALUE SPACES.*/
                public StringBasis FILLER_171 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          FILLER              PIC  X(016) VALUE                'LOCAL OCORRENCIA'.*/
                public StringBasis FILLER_172 { get; set; } = new StringBasis(new PIC("X", "16", "X(016)"), @"LOCAL OCORRENCIA");
                /*"    05          FILLER              PIC  X(052) VALUE SPACES.*/
                public StringBasis FILLER_173 { get; set; } = new StringBasis(new PIC("X", "52", "X(052)"), @"");
                /*"    05          FILLER              PIC  X(005) VALUE                'CAUSA'.*/
                public StringBasis FILLER_174 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"CAUSA");
                /*"    05          FILLER              PIC  X(056) VALUE SPACES.*/
                public StringBasis FILLER_175 { get; set; } = new StringBasis(new PIC("X", "56", "X(056)"), @"");
                /*"    05          FILLER              PIC  X(001) VALUE 'I'.*/
                public StringBasis FILLER_176 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"I");
                /*"  03            LC19.*/
            }
            public SI0021B_LC19 LC19 { get; set; } = new SI0021B_LC19();
            public class SI0021B_LC19 : VarBasis
            {
                /*"    05          FILLER              PIC  X(001) VALUE 'I'.*/
                public StringBasis FILLER_177 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"I");
                /*"    05          FILLER              PIC  X(001) VALUE SPACES.*/
                public StringBasis FILLER_178 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          LC19-DESCRITEM      PIC  X(100) VALUE SPACES.*/
                public StringBasis LC19_DESCRITEM { get; set; } = new StringBasis(new PIC("X", "100", "X(100)"), @"");
                /*"    05          FILLER              PIC  X(029) VALUE SPACES.*/
                public StringBasis FILLER_179 { get; set; } = new StringBasis(new PIC("X", "29", "X(029)"), @"");
                /*"    05          FILLER              PIC  X(001) VALUE 'I'.*/
                public StringBasis FILLER_180 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"I");
                /*"  03            LC20.*/
            }
            public SI0021B_LC20 LC20 { get; set; } = new SI0021B_LC20();
            public class SI0021B_LC20 : VarBasis
            {
                /*"    05          FILLER              PIC  X(001) VALUE '+'.*/
                public StringBasis FILLER_181 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"+");
                /*"    05          FILLER              PIC  X(019) VALUE ALL '-'.*/
                public StringBasis FILLER_182 { get; set; } = new StringBasis(new PIC("X", "19", "X(019)"), @"ALL");
                /*"    05          FILLER              PIC  X(004) VALUE '*   '.*/
                public StringBasis FILLER_183 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"*   ");
                /*"    05          FILLER              PIC  X(083) VALUE    'DADOS ESPECIFICOS TRANSPORTE / CASCO / AERONAUTICO / PENHOR    'RURAL / CRED.EXPORTACAO'.*/
                public StringBasis FILLER_184 { get; set; } = new StringBasis(new PIC("X", "83", "X(083)"), @"DADOS ESPECIFICOS TRANSPORTE / CASCO / AERONAUTICO / PENHOR    ");
                /*"    05          FILLER              PIC  X(004) VALUE '   *'.*/
                public StringBasis FILLER_185 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"   *");
                /*"    05          FILLER              PIC  X(020) VALUE ALL '-'.*/
                public StringBasis FILLER_186 { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"ALL");
                /*"    05          FILLER              PIC  X(001) VALUE '+'.*/
                public StringBasis FILLER_187 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"+");
                /*"  03            LC21.*/
            }
            public SI0021B_LC21 LC21 { get; set; } = new SI0021B_LC21();
            public class SI0021B_LC21 : VarBasis
            {
                /*"    05          FILLER              PIC  X(001) VALUE 'I'.*/
                public StringBasis FILLER_188 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"I");
                /*"    05          FILLER              PIC  X(001) VALUE SPACES.*/
                public StringBasis FILLER_189 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          FILLER              PIC  X(023) VALUE               'AVERBACAO / CERTIFICADO'.*/
                public StringBasis FILLER_190 { get; set; } = new StringBasis(new PIC("X", "23", "X(023)"), @"AVERBACAO / CERTIFICADO");
                /*"    05          FILLER              PIC  X(006) VALUE SPACES.*/
                public StringBasis FILLER_191 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"");
                /*"    05          FILLER              PIC  X(018) VALUE               'MEIO DE TRANSPORTE'.*/
                public StringBasis FILLER_192 { get; set; } = new StringBasis(new PIC("X", "18", "X(018)"), @"MEIO DE TRANSPORTE");
                /*"    05          FILLER              PIC  X(013) VALUE SPACES.*/
                public StringBasis FILLER_193 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"");
                /*"    05          FILLER              PIC  X(005) VALUE 'PLACA'.*/
                public StringBasis FILLER_194 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"PLACA");
                /*"    05          FILLER              PIC  X(009) VALUE SPACES.*/
                public StringBasis FILLER_195 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"");
                /*"    05          FILLER              PIC  X(007) VALUE 'PREFIXO'.*/
                public StringBasis FILLER_196 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"PREFIXO");
                /*"    05          FILLER              PIC  X(021) VALUE SPACES.*/
                public StringBasis FILLER_197 { get; set; } = new StringBasis(new PIC("X", "21", "X(021)"), @"");
                /*"    05          FILLER              PIC  X(008) VALUE 'EMBARQUE'*/
                public StringBasis FILLER_198 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"EMBARQUE");
                /*"    05          FILLER              PIC  X(019) VALUE SPACES.*/
                public StringBasis FILLER_199 { get; set; } = new StringBasis(new PIC("X", "19", "X(019)"), @"");
                /*"    05          FILLER              PIC  X(001) VALUE 'I'.*/
                public StringBasis FILLER_200 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"I");
                /*"  03            LC22.*/
            }
            public SI0021B_LC22 LC22 { get; set; } = new SI0021B_LC22();
            public class SI0021B_LC22 : VarBasis
            {
                /*"    05          FILLER              PIC  X(001) VALUE 'I'.*/
                public StringBasis FILLER_201 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"I");
                /*"    05          FILLER              PIC  X(006) VALUE SPACES.*/
                public StringBasis FILLER_202 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"");
                /*"    05          LC22-AVERBACAO      PIC  9(013) VALUE ZEROS.*/
                public IntBasis LC22_AVERBACAO { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
                /*"    05          FILLER              PIC  X(011) VALUE SPACES.*/
                public StringBasis FILLER_203 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"");
                /*"    05          LC22-TRANSP         PIC  X(025) VALUE SPACES.*/
                public StringBasis LC22_TRANSP { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"");
                /*"    05          FILLER              PIC  X(006) VALUE SPACES.*/
                public StringBasis FILLER_204 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"");
                /*"    05          LC22-PLACA.*/
                public SI0021B_LC22_PLACA LC22_PLACA { get; set; } = new SI0021B_LC22_PLACA();
                public class SI0021B_LC22_PLACA : VarBasis
                {
                    /*"      07        LC22-PLACLET        PIC  X(003) VALUE SPACES.*/
                    public StringBasis LC22_PLACLET { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
                    /*"      07        FILLER              PIC  X(001) VALUE SPACES.*/
                    public StringBasis FILLER_205 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                    /*"      07        LC22-PLACNUM        PIC  X(004) VALUE SPACES.*/
                    public StringBasis LC22_PLACNUM { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                    /*"    05          FILLER              PIC  X(006) VALUE SPACES.*/
                }
                public StringBasis FILLER_206 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"");
                /*"    05          LC22-PREFIXO        PIC  X(021) VALUE SPACES.*/
                public StringBasis LC22_PREFIXO { get; set; } = new StringBasis(new PIC("X", "21", "X(021)"), @"");
                /*"    05          FILLER              PIC  X(007) VALUE SPACES.*/
                public StringBasis FILLER_207 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"");
                /*"    05          LC22-EMBARQUE       PIC  X(026) VALUE SPACES.*/
                public StringBasis LC22_EMBARQUE { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @"");
                /*"    05          FILLER              PIC  X(001) VALUE SPACES.*/
                public StringBasis FILLER_208 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          FILLER              PIC  X(001) VALUE 'I'.*/
                public StringBasis FILLER_209 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"I");
                /*"  03            LC23.*/
            }
            public SI0021B_LC23 LC23 { get; set; } = new SI0021B_LC23();
            public class SI0021B_LC23 : VarBasis
            {
                /*"    05          FILLER              PIC  X(001) VALUE 'I'.*/
                public StringBasis FILLER_210 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"I");
                /*"    05          FILLER              PIC  X(001) VALUE SPACES.*/
                public StringBasis FILLER_211 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          FILLER              PIC  X(022) VALUE               'EMPRESA TRANSPORTADORA'.*/
                public StringBasis FILLER_212 { get; set; } = new StringBasis(new PIC("X", "22", "X(022)"), @"EMPRESA TRANSPORTADORA");
                /*"    05          FILLER              PIC  X(007) VALUE SPACES.*/
                public StringBasis FILLER_213 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"");
                /*"    05          FILLER              PIC  X(010) VALUE               'MERCADORIA'.*/
                public StringBasis FILLER_214 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"MERCADORIA");
                /*"    05          FILLER              PIC  X(021) VALUE SPACES.*/
                public StringBasis FILLER_215 { get; set; } = new StringBasis(new PIC("X", "21", "X(021)"), @"");
                /*"    05          FILLER              PIC  X(008) VALUE               'NATUREZA'.*/
                public StringBasis FILLER_216 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"NATUREZA");
                /*"    05          FILLER              PIC  X(034) VALUE SPACES.*/
                public StringBasis FILLER_217 { get; set; } = new StringBasis(new PIC("X", "34", "X(034)"), @"");
                /*"    05          FILLER              PIC  X(009) VALUE               'COBERTURA'.*/
                public StringBasis FILLER_218 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"COBERTURA");
                /*"    05          FILLER              PIC  X(018) VALUE SPACES.*/
                public StringBasis FILLER_219 { get; set; } = new StringBasis(new PIC("X", "18", "X(018)"), @"");
                /*"    05          FILLER              PIC  X(001) VALUE 'I'.*/
                public StringBasis FILLER_220 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"I");
                /*"  03            LC24.*/
            }
            public SI0021B_LC24 LC24 { get; set; } = new SI0021B_LC24();
            public class SI0021B_LC24 : VarBasis
            {
                /*"    05          FILLER              PIC  X(001) VALUE 'I'.*/
                public StringBasis FILLER_221 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"I");
                /*"    05          FILLER              PIC  X(001) VALUE SPACES.*/
                public StringBasis FILLER_222 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          LC24-EMPRESA        PIC  X(025) VALUE SPACES.*/
                public StringBasis LC24_EMPRESA { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"");
                /*"    05          FILLER              PIC  X(004) VALUE SPACES.*/
                public StringBasis FILLER_223 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                /*"    05          LC24-MERCAD         PIC  X(025) VALUE SPACES.*/
                public StringBasis LC24_MERCAD { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"");
                /*"    05          FILLER              PIC  X(006) VALUE SPACES.*/
                public StringBasis FILLER_224 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"");
                /*"    05          LC24-NATUREZA       PIC  X(035) VALUE SPACES.*/
                public StringBasis LC24_NATUREZA { get; set; } = new StringBasis(new PIC("X", "35", "X(035)"), @"");
                /*"    05          FILLER              PIC  X(007) VALUE SPACES.*/
                public StringBasis FILLER_225 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"");
                /*"    05          LC24-COBERTUR       PIC  X(026) VALUE SPACES.*/
                public StringBasis LC24_COBERTUR { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @"");
                /*"    05          FILLER              PIC  X(001) VALUE SPACES.*/
                public StringBasis FILLER_226 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          FILLER              PIC  X(001) VALUE 'I'.*/
                public StringBasis FILLER_227 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"I");
                /*"  03            LC25.*/
            }
            public SI0021B_LC25 LC25 { get; set; } = new SI0021B_LC25();
            public class SI0021B_LC25 : VarBasis
            {
                /*"    05          FILLER              PIC  X(001) VALUE 'I'.*/
                public StringBasis FILLER_228 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"I");
                /*"    05          FILLER              PIC  X(001) VALUE SPACES.*/
                public StringBasis FILLER_229 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          FILLER              PIC  X(006) VALUE 'ORIGEM'.*/
                public StringBasis FILLER_230 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"ORIGEM");
                /*"    05          FILLER              PIC  X(023) VALUE SPACES.*/
                public StringBasis FILLER_231 { get; set; } = new StringBasis(new PIC("X", "23", "X(023)"), @"");
                /*"    05          FILLER              PIC  X(007) VALUE 'DESTINO'.*/
                public StringBasis FILLER_232 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"DESTINO");
                /*"    05          FILLER              PIC  X(024) VALUE SPACES.*/
                public StringBasis FILLER_233 { get; set; } = new StringBasis(new PIC("X", "24", "X(024)"), @"");
                /*"    05          FILLER              PIC  X(016) VALUE                'LOCAL OCORRENCIA'.*/
                public StringBasis FILLER_234 { get; set; } = new StringBasis(new PIC("X", "16", "X(016)"), @"LOCAL OCORRENCIA");
                /*"    05          FILLER              PIC  X(026) VALUE SPACES.*/
                public StringBasis FILLER_235 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @"");
                /*"    05          FILLER              PIC  X(006) VALUE 'CIDADE'.*/
                public StringBasis FILLER_236 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"CIDADE");
                /*"    05          FILLER              PIC  X(021) VALUE SPACES.*/
                public StringBasis FILLER_237 { get; set; } = new StringBasis(new PIC("X", "21", "X(021)"), @"");
                /*"    05          FILLER              PIC  X(001) VALUE 'I'.*/
                public StringBasis FILLER_238 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"I");
                /*"  03            LC26.*/
            }
            public SI0021B_LC26 LC26 { get; set; } = new SI0021B_LC26();
            public class SI0021B_LC26 : VarBasis
            {
                /*"    05          FILLER              PIC  X(001) VALUE 'I'.*/
                public StringBasis FILLER_239 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"I");
                /*"    05          FILLER              PIC  X(001) VALUE SPACES.*/
                public StringBasis FILLER_240 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          LC26-ORIGEM         PIC  X(025) VALUE SPACES.*/
                public StringBasis LC26_ORIGEM { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"");
                /*"    05          FILLER              PIC  X(004) VALUE SPACES.*/
                public StringBasis FILLER_241 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                /*"    05          LC26-DESTINO        PIC  X(025) VALUE SPACES.*/
                public StringBasis LC26_DESTINO { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"");
                /*"    05          FILLER              PIC  X(006) VALUE SPACES.*/
                public StringBasis FILLER_242 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"");
                /*"    05          LC26-LOCAL          PIC  X(035) VALUE SPACES.*/
                public StringBasis LC26_LOCAL { get; set; } = new StringBasis(new PIC("X", "35", "X(035)"), @"");
                /*"    05          FILLER              PIC  X(007) VALUE SPACES.*/
                public StringBasis FILLER_243 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"");
                /*"    05          LC26-CIDADE         PIC  X(026) VALUE SPACES.*/
                public StringBasis LC26_CIDADE { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @"");
                /*"    05          FILLER              PIC  X(001) VALUE SPACES.*/
                public StringBasis FILLER_244 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          FILLER              PIC  X(001) VALUE 'I'.*/
                public StringBasis FILLER_245 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"I");
                /*"  03            LC27.*/
            }
            public SI0021B_LC27 LC27 { get; set; } = new SI0021B_LC27();
            public class SI0021B_LC27 : VarBasis
            {
                /*"    05          FILLER              PIC  X(001) VALUE '+'.*/
                public StringBasis FILLER_246 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"+");
                /*"    05          FILLER              PIC  X(048) VALUE ALL '-'.*/
                public StringBasis FILLER_247 { get; set; } = new StringBasis(new PIC("X", "48", "X(048)"), @"ALL");
                /*"    05          FILLER              PIC  X(004) VALUE '*   '.*/
                public StringBasis FILLER_248 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"*   ");
                /*"    05          FILLER              PIC  X(026) VALUE               'DADOS ESPECIFICOS VG / APC'.*/
                public StringBasis FILLER_249 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @"DADOS ESPECIFICOS VG / APC");
                /*"    05          FILLER              PIC  X(004) VALUE '   *'.*/
                public StringBasis FILLER_250 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"   *");
                /*"    05          FILLER              PIC  X(048) VALUE ALL '-'.*/
                public StringBasis FILLER_251 { get; set; } = new StringBasis(new PIC("X", "48", "X(048)"), @"ALL");
                /*"    05          FILLER              PIC  X(001) VALUE '+'.*/
                public StringBasis FILLER_252 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"+");
                /*"  03            LC28.*/
            }
            public SI0021B_LC28 LC28 { get; set; } = new SI0021B_LC28();
            public class SI0021B_LC28 : VarBasis
            {
                /*"    05          FILLER              PIC  X(001) VALUE 'I'.*/
                public StringBasis FILLER_253 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"I");
                /*"    05          FILLER              PIC  X(001) VALUE SPACES.*/
                public StringBasis FILLER_254 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          FILLER              PIC  X(011) VALUE               'ESTIPULANTE'.*/
                public StringBasis FILLER_255 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"ESTIPULANTE");
                /*"    05          FILLER              PIC  X(033) VALUE SPACES.*/
                public StringBasis FILLER_256 { get; set; } = new StringBasis(new PIC("X", "33", "X(033)"), @"");
                /*"    05          FILLER              PIC  X(018) VALUE               'SEGURADO PRINCIPAL'.*/
                public StringBasis FILLER_257 { get; set; } = new StringBasis(new PIC("X", "18", "X(018)"), @"SEGURADO PRINCIPAL");
                /*"    05          FILLER              PIC  X(026) VALUE SPACES.*/
                public StringBasis FILLER_258 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @"");
                /*"    05          FILLER              PIC  X(019) VALUE               'SEGURADO SINISTRADO'.*/
                public StringBasis FILLER_259 { get; set; } = new StringBasis(new PIC("X", "19", "X(019)"), @"SEGURADO SINISTRADO");
                /*"    05          FILLER              PIC  X(022) VALUE SPACES.*/
                public StringBasis FILLER_260 { get; set; } = new StringBasis(new PIC("X", "22", "X(022)"), @"");
                /*"    05          FILLER              PIC  X(001) VALUE 'I'.*/
                public StringBasis FILLER_261 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"I");
                /*"  03            LC29.*/
            }
            public SI0021B_LC29 LC29 { get; set; } = new SI0021B_LC29();
            public class SI0021B_LC29 : VarBasis
            {
                /*"    05          FILLER              PIC  X(001) VALUE 'I'.*/
                public StringBasis FILLER_262 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"I");
                /*"    05          FILLER              PIC  X(001) VALUE SPACES.*/
                public StringBasis FILLER_263 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          LC29-ESTIPUL        PIC  X(040) VALUE SPACES.*/
                public StringBasis LC29_ESTIPUL { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"    05          FILLER              PIC  X(004) VALUE SPACES.*/
                public StringBasis FILLER_264 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                /*"    05          LC29-SEG-PRI        PIC  X(040) VALUE SPACES.*/
                public StringBasis LC29_SEG_PRI { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"    05          FILLER              PIC  X(004) VALUE SPACES.*/
                public StringBasis FILLER_265 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                /*"    05          LC29-SEG-SIN        PIC  X(040) VALUE SPACES.*/
                public StringBasis LC29_SEG_SIN { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"    05          FILLER              PIC  X(001) VALUE SPACES.*/
                public StringBasis FILLER_266 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          FILLER              PIC  X(001) VALUE 'I'.*/
                public StringBasis FILLER_267 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"I");
                /*"  03            LC30.*/
            }
            public SI0021B_LC30 LC30 { get; set; } = new SI0021B_LC30();
            public class SI0021B_LC30 : VarBasis
            {
                /*"    05          FILLER              PIC  X(001) VALUE 'I'.*/
                public StringBasis FILLER_268 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"I");
                /*"    05          FILLER              PIC  X(001) VALUE SPACES.*/
                public StringBasis FILLER_269 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          FILLER              PIC  X(020) VALUE               'GARANTIA DO SEGURADO'.*/
                public StringBasis FILLER_270 { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"GARANTIA DO SEGURADO");
                /*"    05          FILLER              PIC  X(024) VALUE SPACES.*/
                public StringBasis FILLER_271 { get; set; } = new StringBasis(new PIC("X", "24", "X(024)"), @"");
                /*"    05          FILLER              PIC  X(027) VALUE               'DATA NASCIMENTO (PRINCIPAL)'.*/
                public StringBasis FILLER_272 { get; set; } = new StringBasis(new PIC("X", "27", "X(027)"), @"DATA NASCIMENTO (PRINCIPAL)");
                /*"    05          FILLER              PIC  X(017) VALUE SPACES.*/
                public StringBasis FILLER_273 { get; set; } = new StringBasis(new PIC("X", "17", "X(017)"), @"");
                /*"    05          FILLER              PIC  X(028) VALUE               'DATA NASCIMENTO (SINISTRADO)'.*/
                public StringBasis FILLER_274 { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @"DATA NASCIMENTO (SINISTRADO)");
                /*"    05          FILLER              PIC  X(013) VALUE SPACES.*/
                public StringBasis FILLER_275 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"");
                /*"    05          FILLER              PIC  X(001) VALUE 'I'.*/
                public StringBasis FILLER_276 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"I");
                /*"  03            LC31.*/
            }
            public SI0021B_LC31 LC31 { get; set; } = new SI0021B_LC31();
            public class SI0021B_LC31 : VarBasis
            {
                /*"    05          FILLER              PIC  X(001) VALUE 'I'.*/
                public StringBasis FILLER_277 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"I");
                /*"    05          FILLER              PIC  X(001) VALUE SPACES.*/
                public StringBasis FILLER_278 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          LC31-GARANTIA       PIC  X(020) VALUE SPACES.*/
                public StringBasis LC31_GARANTIA { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"");
                /*"    05          FILLER              REDEFINES   LC31-GARANTIA                                    OCCURS  5 TIMES.*/
                private ListBasis<_REDEF_SI0021B_FILLER_279> _filler_279 { get; set; }
                public ListBasis<_REDEF_SI0021B_FILLER_279> FILLER_279
                {
                    get { _filler_279 = new ListBasis<_REDEF_SI0021B_FILLER_279>(5); _.Move(LC31_GARANTIA, _filler_279); VarBasis.RedefinePassValue(LC31_GARANTIA, _filler_279, LC31_GARANTIA); _filler_279.ValueChanged += () => { _.Move(_filler_279, LC31_GARANTIA); }; return _filler_279; }
                    set { VarBasis.RedefinePassValue(value, _filler_279, LC31_GARANTIA); }
                }  //Redefines
                public class _REDEF_SI0021B_FILLER_279 : VarBasis
                {
                    /*"      07        LC31-DESCR          PIC  X(004).*/
                    public StringBasis LC31_DESCR { get; set; } = new StringBasis(new PIC("X", "4", "X(004)."), @"");
                    /*"    05          FILLER              PIC  X(023) VALUE SPACES.*/

                    public _REDEF_SI0021B_FILLER_279()
                    {
                        LC31_DESCR.ValueChanged += OnValueChanged;
                    }

                }
                public StringBasis FILLER_280 { get; set; } = new StringBasis(new PIC("X", "23", "X(023)"), @"");
                /*"    05          LC31-DATA1.*/
                public SI0021B_LC31_DATA1 LC31_DATA1 { get; set; } = new SI0021B_LC31_DATA1();
                public class SI0021B_LC31_DATA1 : VarBasis
                {
                    /*"      07        LC31-DIA1           PIC  9(002) BLANK WHEN ZEROS*/
                    public IntBasis LC31_DIA1 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                    /*"      07        FILLER              PIC  X(001) VALUE '/'.*/
                    public StringBasis FILLER_281 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                    /*"      07        LC31-MES1           PIC  9(002) BLANK WHEN ZEROS*/
                    public IntBasis LC31_MES1 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                    /*"      07        FILLER              PIC  X(001) VALUE '/'.*/
                    public StringBasis FILLER_282 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                    /*"      07        LC31-ANO1           PIC  9(004) BLANK WHEN ZEROS*/
                    public IntBasis LC31_ANO1 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                    /*"    05          FILLER              PIC  X(034) VALUE SPACES.*/
                }
                public StringBasis FILLER_283 { get; set; } = new StringBasis(new PIC("X", "34", "X(034)"), @"");
                /*"    05          LC31-DATA2.*/
                public SI0021B_LC31_DATA2 LC31_DATA2 { get; set; } = new SI0021B_LC31_DATA2();
                public class SI0021B_LC31_DATA2 : VarBasis
                {
                    /*"      07        LC31-DIA2           PIC  9(002) BLANK WHEN ZEROS*/
                    public IntBasis LC31_DIA2 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                    /*"      07        FILLER              PIC  X(001) VALUE '/'.*/
                    public StringBasis FILLER_284 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                    /*"      07        LC31-MES2           PIC  9(002) BLANK WHEN ZEROS*/
                    public IntBasis LC31_MES2 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                    /*"      07        FILLER              PIC  X(001) VALUE '/'.*/
                    public StringBasis FILLER_285 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                    /*"      07        LC31-ANO2           PIC  9(004) BLANK WHEN ZEROS*/
                    public IntBasis LC31_ANO2 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                    /*"    05          FILLER              PIC  X(032) VALUE SPACES.*/
                }
                public StringBasis FILLER_286 { get; set; } = new StringBasis(new PIC("X", "32", "X(032)"), @"");
                /*"    05          FILLER              PIC  X(001) VALUE 'I'.*/
                public StringBasis FILLER_287 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"I");
                /*"  03            LC32.*/
            }
            public SI0021B_LC32 LC32 { get; set; } = new SI0021B_LC32();
            public class SI0021B_LC32 : VarBasis
            {
                /*"    05          FILLER              PIC  X(001) VALUE '+'.*/
                public StringBasis FILLER_288 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"+");
                /*"    05          FILLER              PIC  X(048) VALUE ALL '-'.*/
                public StringBasis FILLER_289 { get; set; } = new StringBasis(new PIC("X", "48", "X(048)"), @"ALL");
                /*"    05          FILLER              PIC  X(004) VALUE '*   '.*/
                public StringBasis FILLER_290 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"*   ");
                /*"    05          FILLER              PIC  X(025) VALUE               'PARTICIPACAO DA CONGENERE'.*/
                public StringBasis FILLER_291 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"PARTICIPACAO DA CONGENERE");
                /*"    05          FILLER              PIC  X(004) VALUE '   *'.*/
                public StringBasis FILLER_292 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"   *");
                /*"    05          FILLER              PIC  X(049) VALUE ALL '-'.*/
                public StringBasis FILLER_293 { get; set; } = new StringBasis(new PIC("X", "49", "X(049)"), @"ALL");
                /*"    05          FILLER              PIC  X(001) VALUE '+'.*/
                public StringBasis FILLER_294 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"+");
                /*"  03            LC33.*/
            }
            public SI0021B_LC33 LC33 { get; set; } = new SI0021B_LC33();
            public class SI0021B_LC33 : VarBasis
            {
                /*"    05          FILLER              PIC  X(001) VALUE 'I'.*/
                public StringBasis FILLER_295 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"I");
                /*"    05          FILLER              PIC  X(001) VALUE SPACES.*/
                public StringBasis FILLER_296 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          LC33-REFER          PIC  X(040) VALUE SPACES.*/
                public StringBasis LC33_REFER { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"    05          FILLER              PIC  X(004) VALUE SPACES.*/
                public StringBasis FILLER_297 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                /*"    05          FILLER              PIC  X(011) VALUE               'VALOR TOTAL'.*/
                public StringBasis FILLER_298 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"VALOR TOTAL");
                /*"    05          FILLER              PIC  X(021) VALUE SPACES.*/
                public StringBasis FILLER_299 { get; set; } = new StringBasis(new PIC("X", "21", "X(021)"), @"");
                /*"    05          FILLER              PIC  X(016) VALUE               'SUA PARTICIPACAO'.*/
                public StringBasis FILLER_300 { get; set; } = new StringBasis(new PIC("X", "16", "X(016)"), @"SUA PARTICIPACAO");
                /*"    05          FILLER              PIC  X(021) VALUE SPACES.*/
                public StringBasis FILLER_301 { get; set; } = new StringBasis(new PIC("X", "21", "X(021)"), @"");
                /*"    05          FILLER              PIC  X(016) VALUE               'TOTAL COSSEGURO '.*/
                public StringBasis FILLER_302 { get; set; } = new StringBasis(new PIC("X", "16", "X(016)"), @"TOTAL COSSEGURO ");
                /*"    05          FILLER              PIC  X(001) VALUE 'I'.*/
                public StringBasis FILLER_303 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"I");
                /*"  03            LC34.*/
            }
            public SI0021B_LC34 LC34 { get; set; } = new SI0021B_LC34();
            public class SI0021B_LC34 : VarBasis
            {
                /*"    05          FILLER              PIC  X(001) VALUE 'I'.*/
                public StringBasis FILLER_304 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"I");
                /*"    05          FILLER              PIC  X(040) VALUE SPACES.*/
                public StringBasis FILLER_305 { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"    05          LC34-VAL-TOTAL      PIC  Z.ZZZ.ZZZ.ZZ9,99.*/
                public DoubleBasis LC34_VAL_TOTAL { get; set; } = new DoubleBasis(new PIC("9", "10", "Z.ZZZ.ZZZ.ZZ9V99."), 2);
                /*"    05          FILLER              PIC  X(021) VALUE SPACES.*/
                public StringBasis FILLER_306 { get; set; } = new StringBasis(new PIC("X", "21", "X(021)"), @"");
                /*"    05          LC34-SUA-PARTIC     PIC  Z.ZZZ.ZZZ.ZZ9,99.*/
                public DoubleBasis LC34_SUA_PARTIC { get; set; } = new DoubleBasis(new PIC("9", "10", "Z.ZZZ.ZZZ.ZZ9V99."), 2);
                /*"    05          FILLER              PIC  X(020) VALUE SPACES.*/
                public StringBasis FILLER_307 { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"");
                /*"    05          LC34-TOT-COSSEG     PIC  Z.ZZZ.ZZZ.ZZ9,99.*/
                public DoubleBasis LC34_TOT_COSSEG { get; set; } = new DoubleBasis(new PIC("9", "10", "Z.ZZZ.ZZZ.ZZ9V99."), 2);
                /*"    05          FILLER              PIC  X(001) VALUE SPACES.*/
                public StringBasis FILLER_308 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          FILLER              PIC  X(001) VALUE 'I'.*/
                public StringBasis FILLER_309 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"I");
                /*"  03            LC35.*/
            }
            public SI0021B_LC35 LC35 { get; set; } = new SI0021B_LC35();
            public class SI0021B_LC35 : VarBasis
            {
                /*"    05          FILLER              PIC  X(001) VALUE 'I'.*/
                public StringBasis FILLER_310 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"I");
                /*"    05          FILLER              PIC  X(040) VALUE SPACES.*/
                public StringBasis FILLER_311 { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"    05          LC35-VAL-TOTAL      PIC  ZZ.ZZZ.ZZ9,99999.*/
                public DoubleBasis LC35_VAL_TOTAL { get; set; } = new DoubleBasis(new PIC("9", "8", "ZZ.ZZZ.ZZ9V99999."), 5);
                /*"    05          FILLER              PIC  X(021) VALUE SPACES.*/
                public StringBasis FILLER_312 { get; set; } = new StringBasis(new PIC("X", "21", "X(021)"), @"");
                /*"    05          LC35-SUA-PARTIC     PIC  ZZ.ZZZ.ZZ9,99999.*/
                public DoubleBasis LC35_SUA_PARTIC { get; set; } = new DoubleBasis(new PIC("9", "8", "ZZ.ZZZ.ZZ9V99999."), 5);
                /*"    05          FILLER              PIC  X(020) VALUE SPACES.*/
                public StringBasis FILLER_313 { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"");
                /*"    05          LC35-TOT-COSSEG     PIC  ZZ.ZZZ.ZZ9,99999.*/
                public DoubleBasis LC35_TOT_COSSEG { get; set; } = new DoubleBasis(new PIC("9", "8", "ZZ.ZZZ.ZZ9V99999."), 5);
                /*"    05          FILLER              PIC  X(001) VALUE SPACES.*/
                public StringBasis FILLER_314 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          FILLER              PIC  X(001) VALUE 'I'.*/
                public StringBasis FILLER_315 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"I");
                /*"  03            LC36.*/
            }
            public SI0021B_LC36 LC36 { get; set; } = new SI0021B_LC36();
            public class SI0021B_LC36 : VarBasis
            {
                /*"    05          FILLER              PIC  X(001) VALUE '+'.*/
                public StringBasis FILLER_316 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"+");
                /*"    05          FILLER              PIC  X(130) VALUE ALL '-'.*/
                public StringBasis FILLER_317 { get; set; } = new StringBasis(new PIC("X", "130", "X(130)"), @"ALL");
                /*"    05          FILLER              PIC  X(001) VALUE '+'.*/
                public StringBasis FILLER_318 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"+");
                /*"  03            LC37.*/
            }
            public SI0021B_LC37 LC37 { get; set; } = new SI0021B_LC37();
            public class SI0021B_LC37 : VarBasis
            {
                /*"    05          FILLER              PIC  X(001) VALUE 'I'.*/
                public StringBasis FILLER_319 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"I");
                /*"    05          FILLER              PIC  X(001) VALUE SPACES.*/
                public StringBasis FILLER_320 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05 LC37-ENDERECO-SINI           PIC  X(065) VALUE SPACES.*/
                public StringBasis LC37_ENDERECO_SINI { get; set; } = new StringBasis(new PIC("X", "65", "X(065)"), @"");
                /*"    05          FILLER              PIC  X(003) VALUE SPACES.*/
                public StringBasis FILLER_321 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
                /*"    05 LC37-CODCAU                  PIC  ZZZ.*/
                public StringBasis LC37_CODCAU { get; set; } = new StringBasis(new PIC("X", "0", "ZZZ."), @"");
                /*"    05          FILLER              PIC  X(003) VALUE ' - '.*/
                public StringBasis FILLER_322 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" - ");
                /*"    05 LC37-DESCAU                  PIC  X(040) VALUE SPACES.*/
                public StringBasis LC37_DESCAU { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"    05          FILLER              PIC  X(015) VALUE SPACES.*/
                public StringBasis FILLER_323 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"");
                /*"    05          FILLER              PIC  X(001) VALUE 'I'.*/
                public StringBasis FILLER_324 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"I");
                /*"  03            LC37A.*/
            }
            public SI0021B_LC37A LC37A { get; set; } = new SI0021B_LC37A();
            public class SI0021B_LC37A : VarBasis
            {
                /*"    05          FILLER            PIC  X(001) VALUE 'I'.*/
                public StringBasis FILLER_325 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"I");
                /*"    05          FILLER            PIC  X(001) VALUE SPACES.*/
                public StringBasis FILLER_326 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          FILLER            PIC  X(008) VALUE 'BAIRRO: '.*/
                public StringBasis FILLER_327 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"BAIRRO: ");
                /*"    05 LC37A-BAIRRO               PIC  X(020) VALUE SPACES.*/
                public StringBasis LC37A_BAIRRO { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"");
                /*"    05          FILLER            PIC  X(003) VALUE SPACES.*/
                public StringBasis FILLER_328 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
                /*"    05          FILLER            PIC  X(008) VALUE 'CIDADE: '.*/
                public StringBasis FILLER_329 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"CIDADE: ");
                /*"    05 LC37A-CIDADE               PIC  X(020) VALUE SPACES.*/
                public StringBasis LC37A_CIDADE { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"");
                /*"    05          FILLER            PIC  X(003) VALUE SPACES.*/
                public StringBasis FILLER_330 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
                /*"    05          FILLER            PIC  X(004) VALUE 'UF: '.*/
                public StringBasis FILLER_331 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"UF: ");
                /*"    05 LC37A-SIGLA-UF             PIC  X(002) VALUE SPACES.*/
                public StringBasis LC37A_SIGLA_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
                /*"    05          FILLER            PIC  X(061) VALUE SPACES.*/
                public StringBasis FILLER_332 { get; set; } = new StringBasis(new PIC("X", "61", "X(061)"), @"");
                /*"    05          FILLER            PIC  X(001) VALUE 'I'.*/
                public StringBasis FILLER_333 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"I");
                /*"  03 CAB01.*/
            }
            public SI0021B_CAB01 CAB01 { get; set; } = new SI0021B_CAB01();
            public class SI0021B_CAB01 : VarBasis
            {
                /*"    05 FILLER                    PIC  X(033) VALUE       'CARTAS DE COSSEGURO EMITIDAS EM :'.*/
                public StringBasis FILLER_334 { get; set; } = new StringBasis(new PIC("X", "33", "X(033)"), @"CARTAS DE COSSEGURO EMITIDAS EM :");
                /*"    05 CAB01-DATA                PIC  X(010) VALUE SPACES.*/
                public StringBasis CAB01_DATA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"  03 CAB02.*/
            }
            public SI0021B_CAB02 CAB02 { get; set; } = new SI0021B_CAB02();
            public class SI0021B_CAB02 : VarBasis
            {
                /*"    05 FILLER                    PIC  X(008) VALUE       'SINISTRO'.*/
                public StringBasis FILLER_335 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"SINISTRO");
                /*"    05 FILLER                    PIC  X(010) VALUE SPACES.*/
                public StringBasis FILLER_336 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"    05 FILLER                    PIC  X(008) VALUE       'SEGURADO'.*/
                public StringBasis FILLER_337 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"SEGURADO");
                /*"  03 CAB03.*/
            }
            public SI0021B_CAB03 CAB03 { get; set; } = new SI0021B_CAB03();
            public class SI0021B_CAB03 : VarBasis
            {
                /*"    05 CAB03-SEM-MOVIMENTACAO    PIC  X(040) VALUE SPACES.*/
                public StringBasis CAB03_SEM_MOVIMENTACAO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"  03 DET01.*/
            }
            public SI0021B_DET01 DET01 { get; set; } = new SI0021B_DET01();
            public class SI0021B_DET01 : VarBasis
            {
                /*"    05 DET01-NUM-APOL-SINISTRO   PIC  9(013) VALUE ZEROS.*/
                public IntBasis DET01_NUM_APOL_SINISTRO { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
                /*"    05 FILLER                    PIC  X(005) VALUE SPACES.*/
                public StringBasis FILLER_338 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
                /*"    05 DET01-NOM-SEGURADO        PIC  X(040) VALUE SPACES.*/
                public StringBasis DET01_NOM_SEGURADO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"    05 FILLER                    PIC  X(006) VALUE SPACES.*/
                public StringBasis FILLER_339 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"");
                /*"    05 DET01-REFER               PIC  X(045) VALUE SPACES.*/
                public StringBasis DET01_REFER { get; set; } = new StringBasis(new PIC("X", "45", "X(045)"), @"");
                /*"  03            WORK9S              PIC 9(16) COMP SYNC VALUE                                    9999999999999999.*/
            }
            public IntBasis WORK9S { get; set; } = new IntBasis(new PIC("9", "16", "9(16)"), 9999999999999999);
            /*"  03            WSQLCODE3           PIC S9(009) COMP.*/
            public IntBasis WSQLCODE3 { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  03            WDATA.*/
            public SI0021B_WDATA WDATA { get; set; } = new SI0021B_WDATA();
            public class SI0021B_WDATA : VarBasis
            {
                /*"    05          WDATA-AA            PIC  9(004).*/
                public IntBasis WDATA_AA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05          FILLER              PIC  X(001) VALUE '-'.*/
                public StringBasis FILLER_340 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"    05          WDATA-MM            PIC  9(002).*/
                public IntBasis WDATA_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05          FILLER              PIC  X(001) VALUE '-'.*/
                public StringBasis FILLER_341 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"    05          WDATA-DD            PIC  9(002).*/
                public IntBasis WDATA_DD { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03            WDATA-R             REDEFINES WDATA                                    PIC  X(010).*/
            }
            private _REDEF_StringBasis _wdata_r { get; set; }
            public _REDEF_StringBasis WDATA_R
            {
                get { _wdata_r = new _REDEF_StringBasis(new PIC("X", "010", "X(010).")); ; _.Move(WDATA, _wdata_r); VarBasis.RedefinePassValue(WDATA, _wdata_r, WDATA); _wdata_r.ValueChanged += () => { _.Move(_wdata_r, WDATA); }; return _wdata_r; }
                set { VarBasis.RedefinePassValue(value, _wdata_r, WDATA); }
            }  //Redefines
            /*"  03            WDT-PGTO.*/
            public SI0021B_WDT_PGTO WDT_PGTO { get; set; } = new SI0021B_WDT_PGTO();
            public class SI0021B_WDT_PGTO : VarBasis
            {
                /*"    05          WDT-AA              PIC  9(004).*/
                public IntBasis WDT_AA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05          FILLER              PIC  X(001) VALUE '-'.*/
                public StringBasis FILLER_342 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"    05          WDT-MM              PIC  9(002).*/
                public IntBasis WDT_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05          FILLER              PIC  X(001) VALUE '-'.*/
                public StringBasis FILLER_343 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"    05          WDT-DD              PIC  9(002).*/
                public IntBasis WDT_DD { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03            WDATA-SQL           PIC  X(010) VALUE SPACES.*/
            }
            public StringBasis WDATA_SQL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  03            FILLER              REDEFINES   WDATA-SQL.*/
            private _REDEF_SI0021B_FILLER_344 _filler_344 { get; set; }
            public _REDEF_SI0021B_FILLER_344 FILLER_344
            {
                get { _filler_344 = new _REDEF_SI0021B_FILLER_344(); _.Move(WDATA_SQL, _filler_344); VarBasis.RedefinePassValue(WDATA_SQL, _filler_344, WDATA_SQL); _filler_344.ValueChanged += () => { _.Move(_filler_344, WDATA_SQL); }; return _filler_344; }
                set { VarBasis.RedefinePassValue(value, _filler_344, WDATA_SQL); }
            }  //Redefines
            public class _REDEF_SI0021B_FILLER_344 : VarBasis
            {
                /*"    05          WDAT-ANO-SQL        PIC  9(004).*/
                public IntBasis WDAT_ANO_SQL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05          FILLER              PIC  X(001).*/
                public StringBasis FILLER_345 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    05          WDAT-MES-SQL        PIC  9(002).*/
                public IntBasis WDAT_MES_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05          FILLER              PIC  X(001).*/
                public StringBasis FILLER_346 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    05          WDAT-DIA-SQL        PIC  9(002).*/
                public IntBasis WDAT_DIA_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03            WDATA-LIT.*/

                public _REDEF_SI0021B_FILLER_344()
                {
                    WDAT_ANO_SQL.ValueChanged += OnValueChanged;
                    FILLER_345.ValueChanged += OnValueChanged;
                    WDAT_MES_SQL.ValueChanged += OnValueChanged;
                    FILLER_346.ValueChanged += OnValueChanged;
                    WDAT_DIA_SQL.ValueChanged += OnValueChanged;
                }

            }
            public SI0021B_WDATA_LIT WDATA_LIT { get; set; } = new SI0021B_WDATA_LIT();
            public class SI0021B_WDATA_LIT : VarBasis
            {
                /*"    05          WDAT-LIT-DIA        PIC  9(002) VALUE ZEROS.*/
                public IntBasis WDAT_LIT_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    05          FILLER              PIC  X(001) VALUE '/'.*/
                public StringBasis FILLER_347 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    05          WDAT-LIT-MES        PIC  9(002) VALUE ZEROS.*/
                public IntBasis WDAT_LIT_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    05          FILLER              PIC  X(001) VALUE '/'.*/
                public StringBasis FILLER_348 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    05          WDAT-LIT-ANO        PIC  9(004) VALUE ZEROS.*/
                public IntBasis WDAT_LIT_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"  03            WDATA-CURR.*/
            }
            public SI0021B_WDATA_CURR WDATA_CURR { get; set; } = new SI0021B_WDATA_CURR();
            public class SI0021B_WDATA_CURR : VarBasis
            {
                /*"    05          WDATA-AA-CURR       PIC  9(004) VALUE ZEROS.*/
                public IntBasis WDATA_AA_CURR { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"    05          FILLER              PIC  X(001).*/
                public StringBasis FILLER_349 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    05          WDATA-MM-CURR       PIC  9(002) VALUE ZEROS.*/
                public IntBasis WDATA_MM_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    05          FILLER              PIC  X(001).*/
                public StringBasis FILLER_350 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    05          WDATA-DD-CURR       PIC  9(002) VALUE ZEROS.*/
                public IntBasis WDATA_DD_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  03            WHORA-CURR.*/
            }
            public SI0021B_WHORA_CURR WHORA_CURR { get; set; } = new SI0021B_WHORA_CURR();
            public class SI0021B_WHORA_CURR : VarBasis
            {
                /*"    05          WHORA-HH-CURR       PIC  9(002) VALUE ZEROS.*/
                public IntBasis WHORA_HH_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    05          WHORA-MM-CURR       PIC  9(002) VALUE ZEROS.*/
                public IntBasis WHORA_MM_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    05          WHORA-SS-CURR       PIC  9(002) VALUE ZEROS.*/
                public IntBasis WHORA_SS_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    05          WHORA-CC-CURR       PIC  9(002) VALUE ZEROS.*/
                public IntBasis WHORA_CC_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  03            WDATA-CABEC.*/
            }
            public SI0021B_WDATA_CABEC WDATA_CABEC { get; set; } = new SI0021B_WDATA_CABEC();
            public class SI0021B_WDATA_CABEC : VarBasis
            {
                /*"    05          WDATA-DD-CABEC      PIC  9(002) VALUE ZEROS.*/
                public IntBasis WDATA_DD_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    05          FILLER              PIC  X(001) VALUE '/'.*/
                public StringBasis FILLER_351 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    05          WDATA-MM-CABEC      PIC  9(002) VALUE ZEROS.*/
                public IntBasis WDATA_MM_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    05          FILLER              PIC  X(001) VALUE '/'.*/
                public StringBasis FILLER_352 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    05          WDATA-AA-CABEC      PIC  9(004) VALUE ZEROS.*/
                public IntBasis WDATA_AA_CABEC { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"  03            WHORA-CABEC.*/
            }
            public SI0021B_WHORA_CABEC WHORA_CABEC { get; set; } = new SI0021B_WHORA_CABEC();
            public class SI0021B_WHORA_CABEC : VarBasis
            {
                /*"    05          WHORA-HH-CABEC      PIC  9(002) VALUE ZEROS.*/
                public IntBasis WHORA_HH_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    05          FILLER              PIC  X(001) VALUE ':'.*/
                public StringBasis FILLER_353 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @":");
                /*"    05          WHORA-MM-CABEC      PIC  9(002) VALUE ZEROS.*/
                public IntBasis WHORA_MM_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    05          FILLER              PIC  X(001) VALUE ':'.*/
                public StringBasis FILLER_354 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @":");
                /*"    05          WHORA-SS-CABEC      PIC  9(002) VALUE ZEROS.*/
                public IntBasis WHORA_SS_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  03            WFIM-V1HISTSINI     PIC  X(001) VALUE SPACES.*/
            }
            public StringBasis WFIM_V1HISTSINI { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  03            WFIM-V1APOLCOSCED   PIC  X(001) VALUE SPACES.*/
            public StringBasis WFIM_V1APOLCOSCED { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  03            AC-PAGINAS          PIC  9(005) VALUE ZEROS.*/
            public IntBasis AC_PAGINAS { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  03            AC-L-V1HISTSINI     PIC  9(006) VALUE ZEROS.*/
            public IntBasis AC_L_V1HISTSINI { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  03            AC-I-V1HISTSINI     PIC  9(006) VALUE ZEROS.*/
            public IntBasis AC_I_V1HISTSINI { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  03 CA-NUM-APOLICE             PIC 9(013)    VALUE ZEROS.*/
            public IntBasis CA_NUM_APOLICE { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
            /*"  03 FILLER REDEFINES CA-NUM-APOLICE.*/
            private _REDEF_SI0021B_FILLER_355 _filler_355 { get; set; }
            public _REDEF_SI0021B_FILLER_355 FILLER_355
            {
                get { _filler_355 = new _REDEF_SI0021B_FILLER_355(); _.Move(CA_NUM_APOLICE, _filler_355); VarBasis.RedefinePassValue(CA_NUM_APOLICE, _filler_355, CA_NUM_APOLICE); _filler_355.ValueChanged += () => { _.Move(_filler_355, CA_NUM_APOLICE); }; return _filler_355; }
                set { VarBasis.RedefinePassValue(value, _filler_355, CA_NUM_APOLICE); }
            }  //Redefines
            public class _REDEF_SI0021B_FILLER_355 : VarBasis
            {
                /*"    05 TRI-POSI-APOLICE          PIC  9(003).*/
                public IntBasis TRI_POSI_APOLICE { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"    05 RESTO-APOLICE             PIC  9(010).*/
                public IntBasis RESTO_APOLICE { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
                /*"  03 CH-CHAVE-ANT.*/

                public _REDEF_SI0021B_FILLER_355()
                {
                    TRI_POSI_APOLICE.ValueChanged += OnValueChanged;
                    RESTO_APOLICE.ValueChanged += OnValueChanged;
                }

            }
            public SI0021B_CH_CHAVE_ANT CH_CHAVE_ANT { get; set; } = new SI0021B_CH_CHAVE_ANT();
            public class SI0021B_CH_CHAVE_ANT : VarBasis
            {
                /*"    05 CH-SINI-ANT              PIC 9(013) VALUE ZEROS.*/
                public IntBasis CH_SINI_ANT { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
                /*"    05 CH-OPER-ANT              PIC 9(004) VALUE ZEROS.*/
                public IntBasis CH_OPER_ANT { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"    05 CH-CURSOR-ANT            PIC X(001) VALUE SPACES.*/
                public StringBasis CH_CURSOR_ANT { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"  03 CH-CHAVE-ATU.*/
            }
            public SI0021B_CH_CHAVE_ATU CH_CHAVE_ATU { get; set; } = new SI0021B_CH_CHAVE_ATU();
            public class SI0021B_CH_CHAVE_ATU : VarBasis
            {
                /*"    05 CH-SINI-ATU              PIC 9(013) VALUE ZEROS.*/
                public IntBasis CH_SINI_ATU { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
                /*"    05 CH-OPER-ATU              PIC 9(004) VALUE ZEROS.*/
                public IntBasis CH_OPER_ATU { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"    05 CH-CURSOR-ATU            PIC X(001) VALUE SPACES.*/
                public StringBasis CH_CURSOR_ATU { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"  03 AT-USUARIO                  PIC X(08)      VALUE LOW-VALUE.*/
            }
            public StringBasis AT_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"  03 AN-USUARIO                  PIC X(08)      VALUE LOW-VALUE.*/
            public StringBasis AN_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"  03            WIND             PIC S9(003)     VALUE +0 COMP-3*/
            public IntBasis WIND { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"));
            /*"  03            W01P1502         PIC S9(015)V99  VALUE +0 COMP-3*/
            public DoubleBasis W01P1502 { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(015)V99"), 2);
            /*"  03            W01P1505         PIC S9(10)V9(5) VALUE +0.*/
            public DoubleBasis W01P1505 { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(5)"), 5);
            /*"  03            W02P1505         PIC S9(10)V9(5) VALUE +0.*/
            public DoubleBasis W02P1505 { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(5)"), 5);
            /*"  03 AT-SINISTRO-MOV.*/
            public SI0021B_AT_SINISTRO_MOV AT_SINISTRO_MOV { get; set; } = new SI0021B_AT_SINISTRO_MOV();
            public class SI0021B_AT_SINISTRO_MOV : VarBasis
            {
                /*"     06 WS-SINISTRO             PIC  9(013)   VALUE ZEROS.*/
                public IntBasis WS_SINISTRO { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
                /*"     06 WS-OPERACAO             PIC  9(004)   VALUE ZEROS.*/
                public IntBasis WS_OPERACAO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"     06 WS-DATA-MOVTO           PIC  X(010)   VALUE SPACES.*/
                public StringBasis WS_DATA_MOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"  03 AN-SINISTRO-MOV.*/
            }
            public SI0021B_AN_SINISTRO_MOV AN_SINISTRO_MOV { get; set; } = new SI0021B_AN_SINISTRO_MOV();
            public class SI0021B_AN_SINISTRO_MOV : VarBasis
            {
                /*"     06 AN-SINISTRO             PIC  9(013)   VALUE ZEROS.*/
                public IntBasis AN_SINISTRO { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
                /*"     06 AN-OPERACAO             PIC  9(004)   VALUE ZEROS.*/
                public IntBasis AN_OPERACAO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"     06 AN-DATA-MOVTO           PIC  X(010)   VALUE SPACES.*/
                public StringBasis AN_DATA_MOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"  03            WS-APOL-SINI        PIC  9(013) VALUE ZEROS.*/
            }
            public IntBasis WS_APOL_SINI { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
            /*"  03            FILLER              REDEFINES   WS-APOL-SINI.*/
            private _REDEF_SI0021B_FILLER_356 _filler_356 { get; set; }
            public _REDEF_SI0021B_FILLER_356 FILLER_356
            {
                get { _filler_356 = new _REDEF_SI0021B_FILLER_356(); _.Move(WS_APOL_SINI, _filler_356); VarBasis.RedefinePassValue(WS_APOL_SINI, _filler_356, WS_APOL_SINI); _filler_356.ValueChanged += () => { _.Move(_filler_356, WS_APOL_SINI); }; return _filler_356; }
                set { VarBasis.RedefinePassValue(value, _filler_356, WS_APOL_SINI); }
            }  //Redefines
            public class _REDEF_SI0021B_FILLER_356 : VarBasis
            {
                /*"    05          WS-ORG-SINI         PIC  9(003).*/
                public IntBasis WS_ORG_SINI { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"    05          WS-RAMO-SINI        PIC  9(002).*/
                public IntBasis WS_RAMO_SINI { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05          WS-NUM-SINI         PIC  9(008).*/
                public IntBasis WS_NUM_SINI { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"  03  W-CHAVE-SINI-TEM-ENDERECO     PIC X(03)  VALUE SPACES.*/

                public _REDEF_SI0021B_FILLER_356()
                {
                    WS_ORG_SINI.ValueChanged += OnValueChanged;
                    WS_RAMO_SINI.ValueChanged += OnValueChanged;
                    WS_NUM_SINI.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis W_CHAVE_SINI_TEM_ENDERECO { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"");
            /*"  03  W-ENDERECO.*/
            public SI0021B_W_ENDERECO W_ENDERECO { get; set; } = new SI0021B_W_ENDERECO();
            public class SI0021B_W_ENDERECO : VarBasis
            {
                /*"      05  W-ENDERECO-1              PIC X(40)  VALUE SPACES.*/
                public StringBasis W_ENDERECO_1 { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
                /*"      05  W-ENDERECO-2              PIC X(20)  VALUE SPACES.*/
                public StringBasis W_ENDERECO_2 { get; set; } = new StringBasis(new PIC("X", "20", "X(20)"), @"");
                /*"  03        WABEND.*/
            }
            public SI0021B_WABEND WABEND { get; set; } = new SI0021B_WABEND();
            public class SI0021B_WABEND : VarBasis
            {
                /*"    05      FILLER              PIC  X(010) VALUE           ' SI0021B'.*/
                public StringBasis FILLER_357 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" SI0021B");
                /*"    05      FILLER              PIC  X(028) VALUE           ' *** ERRO  EXEC SQL  NUMERO '.*/
                public StringBasis FILLER_358 { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @" *** ERRO  EXEC SQL  NUMERO ");
                /*"    05      WNR-EXEC-SQL        PIC  X(004) VALUE '0000'.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"0000");
                /*"    05      FILLER              PIC  X(017) VALUE           ' *** PARAGRAFO = '.*/
                public StringBasis FILLER_359 { get; set; } = new StringBasis(new PIC("X", "17", "X(017)"), @" *** PARAGRAFO = ");
                /*"    05      PARAGRAFO           PIC  X(030) VALUE SPACES.*/
                public StringBasis PARAGRAFO { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"");
                /*"    05      FILLER              PIC  X(014) VALUE           '    SQLCODE = '.*/
                public StringBasis FILLER_360 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE = ");
                /*"    05      WSQLCODE            PIC  ZZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
                /*"    05      FILLER              PIC  X(014) VALUE           '    SQLCODE1= '.*/
                public StringBasis FILLER_361 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE1= ");
                /*"    05      WSQLCODE1           PIC  ZZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE1 { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
                /*"    05      FILLER              PIC  X(014) VALUE           '    SQLCODE2= '.*/
                public StringBasis FILLER_362 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE2= ");
                /*"    05      WSQLCODE2           PIC  ZZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE2 { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
                /*"01          LK-LINK.*/
            }
        }
        public SI0021B_LK_LINK LK_LINK { get; set; } = new SI0021B_LK_LINK();
        public class SI0021B_LK_LINK : VarBasis
        {
            /*"  03        LK-RTCODE           PIC  S9(004)   VALUE +0   COMP.*/
            public IntBasis LK_RTCODE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  03        LK-TAMANHO          PIC  S9(004)   VALUE +40  COMP.*/
            public IntBasis LK_TAMANHO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), +40);
            /*"  03        LK-TITULO           PIC   X(132)   VALUE  SPACES.*/
            public StringBasis LK_TITULO { get; set; } = new StringBasis(new PIC("X", "132", "X(132)"), @"");
            /*"01 WS-VARIAVEIS-GLOBAIS.*/
        }
        public SI0021B_WS_VARIAVEIS_GLOBAIS WS_VARIAVEIS_GLOBAIS { get; set; } = new SI0021B_WS_VARIAVEIS_GLOBAIS();
        public class SI0021B_WS_VARIAVEIS_GLOBAIS : VarBasis
        {
            /*"    05 WS-CURRENT-DATE.*/
            public SI0021B_WS_CURRENT_DATE WS_CURRENT_DATE { get; set; } = new SI0021B_WS_CURRENT_DATE();
            public class SI0021B_WS_CURRENT_DATE : VarBasis
            {
                /*"       10 WS-DATE                  PIC X(16) VALUE SPACES.*/
                public StringBasis WS_DATE { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"");
                /*"       10 WS-DATE-R REDEFINES WS-DATE.*/
                private _REDEF_SI0021B_WS_DATE_R _ws_date_r { get; set; }
                public _REDEF_SI0021B_WS_DATE_R WS_DATE_R
                {
                    get { _ws_date_r = new _REDEF_SI0021B_WS_DATE_R(); _.Move(WS_DATE, _ws_date_r); VarBasis.RedefinePassValue(WS_DATE, _ws_date_r, WS_DATE); _ws_date_r.ValueChanged += () => { _.Move(_ws_date_r, WS_DATE); }; return _ws_date_r; }
                    set { VarBasis.RedefinePassValue(value, _ws_date_r, WS_DATE); }
                }  //Redefines
                public class _REDEF_SI0021B_WS_DATE_R : VarBasis
                {
                    /*"          15 WS-DT-TODAY           PIC 9(08).*/
                    public IntBasis WS_DT_TODAY { get; set; } = new IntBasis(new PIC("9", "8", "9(08)."));
                    /*"          15 FILLER REDEFINES WS-DT-TODAY.*/
                    private _REDEF_SI0021B_FILLER_363 _filler_363 { get; set; }
                    public _REDEF_SI0021B_FILLER_363 FILLER_363
                    {
                        get { _filler_363 = new _REDEF_SI0021B_FILLER_363(); _.Move(WS_DT_TODAY, _filler_363); VarBasis.RedefinePassValue(WS_DT_TODAY, _filler_363, WS_DT_TODAY); _filler_363.ValueChanged += () => { _.Move(_filler_363, WS_DT_TODAY); }; return _filler_363; }
                        set { VarBasis.RedefinePassValue(value, _filler_363, WS_DT_TODAY); }
                    }  //Redefines
                    public class _REDEF_SI0021B_FILLER_363 : VarBasis
                    {
                        /*"             20 WS-ANO-TODAY       PIC 9(04).*/
                        public IntBasis WS_ANO_TODAY { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                        /*"             20 WS-MES-TODAY       PIC 9(02).*/
                        public IntBasis WS_MES_TODAY { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                        /*"             20 WS-DIA-TODAY       PIC 9(02).*/
                        public IntBasis WS_DIA_TODAY { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                        /*"          15 WS-HR-TODAY           PIC 9(06).*/

                        public _REDEF_SI0021B_FILLER_363()
                        {
                            WS_ANO_TODAY.ValueChanged += OnValueChanged;
                            WS_MES_TODAY.ValueChanged += OnValueChanged;
                            WS_DIA_TODAY.ValueChanged += OnValueChanged;
                        }

                    }
                    public IntBasis WS_HR_TODAY { get; set; } = new IntBasis(new PIC("9", "6", "9(06)."));
                    /*"          15 FILLER REDEFINES WS-HR-TODAY.*/
                    private _REDEF_SI0021B_FILLER_364 _filler_364 { get; set; }
                    public _REDEF_SI0021B_FILLER_364 FILLER_364
                    {
                        get { _filler_364 = new _REDEF_SI0021B_FILLER_364(); _.Move(WS_HR_TODAY, _filler_364); VarBasis.RedefinePassValue(WS_HR_TODAY, _filler_364, WS_HR_TODAY); _filler_364.ValueChanged += () => { _.Move(_filler_364, WS_HR_TODAY); }; return _filler_364; }
                        set { VarBasis.RedefinePassValue(value, _filler_364, WS_HR_TODAY); }
                    }  //Redefines
                    public class _REDEF_SI0021B_FILLER_364 : VarBasis
                    {
                        /*"             20 WS-HR-HOR          PIC 9(02).*/
                        public IntBasis WS_HR_HOR { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                        /*"             20 WS-HR-MIN          PIC 9(02).*/
                        public IntBasis WS_HR_MIN { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                        /*"             20 WS-HR-SEG          PIC 9(02).*/
                        public IntBasis WS_HR_SEG { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                        /*"          15 WS-HR-DECSEG          PIC 9(02).*/

                        public _REDEF_SI0021B_FILLER_364()
                        {
                            WS_HR_HOR.ValueChanged += OnValueChanged;
                            WS_HR_MIN.ValueChanged += OnValueChanged;
                            WS_HR_SEG.ValueChanged += OnValueChanged;
                        }

                    }
                    public IntBasis WS_HR_DECSEG { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));

                    public _REDEF_SI0021B_WS_DATE_R()
                    {
                        WS_DT_TODAY.ValueChanged += OnValueChanged;
                        FILLER_363.ValueChanged += OnValueChanged;
                    }

                }
            }
        }


        public Dclgens.SX010 SX010 { get; set; } = new Dclgens.SX010();
        public Dclgens.SX118 SX118 { get; set; } = new Dclgens.SX118();
        public Dclgens.RELATORI RELATORI { get; set; } = new Dclgens.RELATORI();
        public SI0021B_V1APOLCOSCED V1APOLCOSCED { get; set; } = new SI0021B_V1APOLCOSCED();
        public SI0021B_SX_APOLCOSG SX_APOLCOSG { get; set; } = new SI0021B_SX_APOLCOSG();

        public SI0021B_V1HISTSIN V1HISTSIN { get; set; } = new SI0021B_V1HISTSIN(true);
        string GetQuery_V1HISTSIN()
        {
            var query = @$"SELECT A.OPERACAO
							,A.OCORHIST
							,A.NOMFAV
							,A.DTMOVTO
							,A.VAL_OPERACAO
							,A.LIMCRR
							,B.NUM_APOLICE
							,B.NRENDOS
							,B.NUM_APOL_SINISTRO
							,B.DATCMD
							,B.DATORR
							,B.NRCERTIF
							,B.COD_MOEDA_SINI
							,B.IDTPSEGU
							,B.NUMIRB
							,B.CODSUBES
							,B.NREMBARQ
							,B.REFEMBQ
							,B.VALSEGBT
							,B.PCPARTIC
							,B.CODCAU
							,B.RAMO
							,O.DES_OPERACAO
							,O.FUNCAO_OPERACAO
							,'SEG99999'
							,9999
							,'9999-12-31'
							,'9999-12-31'
							,'1'
							FROM SEGUROS.V1HISTSINI A
							,SEGUROS.V1MESTSINI B
							,SEGUROS.GE_OPERACAO O WHERE A.DTMOVTO = '{V1SIST_DTMOVABE}' AND A.NUM_APOL_SINISTRO = B.NUM_APOL_SINISTRO AND B.TIPREG = '1' AND A.OPERACAO = O.COD_OPERACAO AND O.IDE_SISTEMA = 'SI' AND ( A.OPERACAO IN (101
							,107
							,108
							,117
							,118
							, 1001
							,1002
							,1003
							,1004
							,1009
							, 2010
							,3010
							,9001) OR (O.IND_TIPO_FUNCAO IN ('JUR-INDENI'
							,'JUR-DESP'
							, 'JUR-HON') AND O.FUNCAO_OPERACAO IN ('JBHON'
							, 'JBDES'
							, 'JBIND') ) OR O.IND_TIPO_FUNCAO = 'JUR-AVISO' ) AND B.CODPRODU <> 6600 AND B.RAMO NOT IN (20
							,31
							,42
							,53
							,81
							,82
							,93
							,97) UNION ALL SELECT A.OPERACAO
							,A.OCORHIST
							,A.NOMFAV
							,A.DTMOVTO
							,A.VAL_OPERACAO
							,A.LIMCRR
							,B.NUM_APOLICE
							,B.NRENDOS
							,B.NUM_APOL_SINISTRO
							,B.DATCMD
							,B.DATORR
							,B.NRCERTIF
							,B.COD_MOEDA_SINI
							,B.IDTPSEGU
							,B.NUMIRB
							,B.CODSUBES
							,B.NREMBARQ
							,B.REFEMBQ
							,B.VALSEGBT
							,B.PCPARTIC
							,B.CODCAU
							,B.RAMO
							,O.DES_OPERACAO
							,O.FUNCAO_OPERACAO
							,R.COD_USUARIO
							,9999
							,'9999-12-31'
							,'9999-12-31'
							,'2'
							FROM SEGUROS.V1HISTSINI A
							,SEGUROS.V1MESTSINI B
							,SEGUROS.GE_OPERACAO O
							,SEGUROS.RELATORIOS R WHERE R.COD_RELATORIO = 'SI0021B' AND R.SIT_REGISTRO = '0' AND B.NUM_APOL_SINISTRO = R.NUM_SINISTRO AND A.NUM_APOL_SINISTRO = B.NUM_APOL_SINISTRO AND B.TIPREG = '1' AND O.IDE_SISTEMA = 'SI' AND A.OPERACAO = O.COD_OPERACAO AND ( A.OPERACAO IN (101
							,107
							,108
							,117
							,118
							, 1001
							,1002
							,1003
							,1004
							,1009
							, 2010
							,3010
							,9001) OR (O.IND_TIPO_FUNCAO IN ('JUR-INDENI'
							,'JUR-DESP'
							, 'JUR-HON') AND O.FUNCAO_OPERACAO IN ('JBHON'
							,'JBDES'
							,'JBIND') ) OR O.IND_TIPO_FUNCAO = 'JUR-AVISO' ) AND B.CODPRODU <> 6600 AND B.RAMO NOT IN (20
							,31
							,42
							,53
							,81
							,82
							,93
							,97) UNION ALL SELECT B.COD_OPERACAO
							,B.OCORR_HISTORICO
							,B.NOME_FAVORECIDO
							,B.DATA_MOVIMENTO
							,B.VAL_OPERACAO
							,B.DATA_LIM_CORRECAO
							,C.NUM_APOLICE
							,C.NUM_ENDOSSO
							,C.NUM_APOL_SINISTRO
							,C.DATA_COMUNICADO
							,C.DATA_OCORRENCIA
							,C.NUM_CERTIFICADO
							,C.COD_MOEDA_SINI
							,C.TIPO_SEGURADO
							,C.NUM_IRB
							,C.COD_SUBGRUPO
							,C.NUM_EMBARQUE
							,C.REF_EMBARQUE
							,C.IMP_SEGURADA_IX
							,C.PCT_PART_COSSEGURO
							,C.COD_CAUSA
							,C.RAMO
							,D.DES_OPERACAO
							,D.FUNCAO_OPERACAO
							,A.COD_USUARIO
							,A.COD_CONGENERE
							,A.PERI_INICIAL
							,A.PERI_FINAL
							,'3'
							FROM SEGUROS.RELATORIOS A
							,SEGUROS.SINISTRO_HISTORICO B
							,SEGUROS.SINISTRO_MESTRE C
							,SEGUROS.GE_OPERACAO D WHERE A.COD_RELATORIO = 'SI0021B' AND A.SIT_REGISTRO = '0' AND B.DATA_MOVIMENTO BETWEEN A.PERI_INICIAL AND A.PERI_FINAL AND B.NUM_APOL_SINISTRO = C.NUM_APOL_SINISTRO AND C.TIPO_REGISTRO = '1' AND C.COD_PRODUTO <> 6600 AND C.RAMO NOT IN (20
							,31
							,42
							,53
							,81
							,82
							,93
							,97) AND D.IDE_SISTEMA = 'SI' AND B.COD_OPERACAO = D.COD_OPERACAO AND ( B.COD_OPERACAO IN ( 101
							, 107
							, 108
							, 117
							, 118
							, 1001
							,1002
							,1003
							,1004
							,1009
							, 2010
							,3010
							,9001) OR ( D.IND_TIPO_FUNCAO IN ('JUR-INDENI'
							, 'JUR-DESP'
							, 'JUR-HON' ) AND D.FUNCAO_OPERACAO IN ('JBHON'
							, 'JBDES'
							, 'JBIND') ) OR D.IND_TIPO_FUNCAO = 'JUR-AVISO' ) AND EXISTS ( SELECT E.NUM_APOLICE
							FROM SEGUROS.APOL_COSSEGURADORA E WHERE E.NUM_APOLICE = C.NUM_APOLICE AND E.COD_COSSEGURADORA = A.COD_CONGENERE )";

            return query;
        }

        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string SI0021M1_FILE_NAME_P, string SI0021M2_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                SI0021M1.SetFile(SI0021M1_FILE_NAME_P);
                SI0021M2.SetFile(SI0021M2_FILE_NAME_P);
                InitializeGetQuery();

                /*" -0- FLUXCONTROL_PERFORM M-000-000-PRINCIPAL-SECTION */

                M_000_000_PRINCIPAL_SECTION();

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
            V1HISTSIN.GetQueryEvent += GetQuery_V1HISTSIN;
        }

        [StopWatch]
        /*" M-000-000-PRINCIPAL-SECTION */
        private void M_000_000_PRINCIPAL_SECTION()
        {
            /*" -1398- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -1400- EXEC SQL WHENEVER SQLERROR GO TO 999-999-ROT-ERRO END-EXEC. */

            /*" -1404- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -1408- MOVE FUNCTION CURRENT-DATE TO WS-CURRENT-DATE */
            _.Move(_.CurrentDate(), WS_VARIAVEIS_GLOBAIS.WS_CURRENT_DATE);

            /*" -1411- DISPLAY 'DATA INICIO: ' WS-DT-TODAY ' - HORA INICIO: ' WS-HR-TODAY */

            $"DATA INICIO: {WS_VARIAVEIS_GLOBAIS.WS_CURRENT_DATE.WS_DATE_R.WS_DT_TODAY} - HORA INICIO: {WS_VARIAVEIS_GLOBAIS.WS_CURRENT_DATE.WS_DATE_R.WS_HR_TODAY}"
            .Display();

            /*" -1416- COMPUTE WS-SEG-INICIAL = (WS-HR-HOR * 60 * 60) + (WS-HR-MIN * 60) + WS-HR-SEG + (WS-HR-DECSEG / 100) */
            WS_SEG_INICIAL.Value = (WS_VARIAVEIS_GLOBAIS.WS_CURRENT_DATE.WS_DATE_R.FILLER_364.WS_HR_HOR * 60 * 60) + (WS_VARIAVEIS_GLOBAIS.WS_CURRENT_DATE.WS_DATE_R.FILLER_364.WS_HR_MIN * 60) + WS_VARIAVEIS_GLOBAIS.WS_CURRENT_DATE.WS_DATE_R.FILLER_364.WS_HR_SEG + (WS_VARIAVEIS_GLOBAIS.WS_CURRENT_DATE.WS_DATE_R.WS_HR_DECSEG / 100f);

            /*" -1424- DISPLAY 'SI0021B - VERSAO 007 INICIOU PROCESSAMENTO EM ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2) ' ***' . */

            $"SI0021B - VERSAO 007 INICIOU PROCESSAMENTO EM {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss} ***"
            .Display();

            /*" -1426- PERFORM 030-000-INICIO */

            M_030_000_INICIO_SECTION();

            /*" -1442- PERFORM 025-000-SISTEMA */

            M_025_000_SISTEMA_SECTION();

            /*" -1444- OPEN OUTPUT SI0021M2. */
            SI0021M2.Open(REG_SI0021M2);

            /*" -1446- DISPLAY 'DATA DO MOVIMENTO ' V1SIST-DTMOVABE */
            _.Display($"DATA DO MOVIMENTO {V1SIST_DTMOVABE}");

            /*" -1447- MOVE V1SIST-DTMOVABE TO WDATA-SQL */
            _.Move(V1SIST_DTMOVABE, W.WDATA_SQL);

            /*" -1448- MOVE WDAT-DIA-SQL TO WDAT-LIT-DIA */
            _.Move(W.FILLER_344.WDAT_DIA_SQL, W.WDATA_LIT.WDAT_LIT_DIA);

            /*" -1449- MOVE WDAT-MES-SQL TO WDAT-LIT-MES */
            _.Move(W.FILLER_344.WDAT_MES_SQL, W.WDATA_LIT.WDAT_LIT_MES);

            /*" -1450- MOVE WDAT-ANO-SQL TO WDAT-LIT-ANO. */
            _.Move(W.FILLER_344.WDAT_ANO_SQL, W.WDATA_LIT.WDAT_LIT_ANO);

            /*" -1452- MOVE WDATA-LIT TO CAB01-DATA. */
            _.Move(W.WDATA_LIT, W.CAB01.CAB01_DATA);

            /*" -1453- WRITE REG-SI0021M2 FROM CAB01 AFTER PAGE. */
            _.Move(W.CAB01.GetMoveValues(), REG_SI0021M2);

            SI0021M2.Write(REG_SI0021M2.GetMoveValues().ToString());

            /*" -1457- WRITE REG-SI0021M2 FROM CAB02 AFTER 1. */
            _.Move(W.CAB02.GetMoveValues(), REG_SI0021M2);

            SI0021M2.Write(REG_SI0021M2.GetMoveValues().ToString());

            /*" -1459- PERFORM 015-000-CABECALHOS */

            M_015_000_CABECALHOS_SECTION();

            /*" -1460- MOVE SPACES TO WFIM-V1HISTSINI */
            _.Move("", W.WFIM_V1HISTSINI);

            /*" -1461- MOVE SPACES TO WS-DATA-MOVTO. */
            _.Move("", W.AT_SINISTRO_MOV.WS_DATA_MOVTO);

            /*" -1464- MOVE ZEROS TO WS-SINISTRO WS-OPERACAO */
            _.Move(0, W.AT_SINISTRO_MOV.WS_SINISTRO, W.AT_SINISTRO_MOV.WS_OPERACAO);

            /*" -1465- PERFORM 090-000-CURSOR-V1HISTSINI */

            M_090_000_CURSOR_V1HISTSINI_SECTION();

            /*" -1467- PERFORM 100-000-LER-V1HISTSINI */

            M_100_000_LER_V1HISTSINI_SECTION();

            /*" -1468- IF WFIM-V1HISTSINI NOT EQUAL SPACES */

            if (!W.WFIM_V1HISTSINI.IsEmpty())
            {

                /*" -1469- MOVE ZEROS TO RETURN-CODE */
                _.Move(0, RETURN_CODE);

                /*" -1471- PERFORM 910-000-ENCERRA-SEM-MOVTO. */

                M_910_000_ENCERRA_SEM_MOVTO_SECTION();
            }


            /*" -1472- PERFORM 120-000-PROCESSA-REGISTRO UNTIL WFIM-V1HISTSINI NOT EQUAL SPACES. */

            while (!(!W.WFIM_V1HISTSINI.IsEmpty()))
            {

                M_120_000_PROCESSA_REGISTRO_SECTION();
            }

            /*" -0- FLUXCONTROL_PERFORM M_000_900_FINALIZA */

            M_000_900_FINALIZA();

        }

        [StopWatch]
        /*" M-000-900-FINALIZA */
        private void M_000_900_FINALIZA(bool isPerform = false)
        {
            /*" -1478- PERFORM 800-000-UPDATE-RELATORIO. */

            M_800_000_UPDATE_RELATORIO_SECTION();

            /*" -1480- PERFORM 900-000-CLOSE-ARQUIVOS */

            M_900_000_CLOSE_ARQUIVOS_SECTION();

            /*" -1481- DISPLAY '*----------------------------------*' */
            _.Display($"*----------------------------------*");

            /*" -1482- DISPLAY 'I                                  I' */
            _.Display($"I                                  I");

            /*" -1484- DISPLAY 'I REGISTROS LIDOS ....... ' AC-L-V1HISTSINI '   I' */

            $"I REGISTROS LIDOS ....... {W.AC_L_V1HISTSINI}   I"
            .Display();

            /*" -1485- DISPLAY 'I                                  I' */
            _.Display($"I                                  I");

            /*" -1487- DISPLAY 'I REGISTROS IMPRESSOS ... ' AC-I-V1HISTSINI '   I' */

            $"I REGISTROS IMPRESSOS ... {W.AC_I_V1HISTSINI}   I"
            .Display();

            /*" -1488- DISPLAY 'I                                  I' */
            _.Display($"I                                  I");

            /*" -1490- DISPLAY '*----------------------------------*' . */
            _.Display($"*----------------------------------*");

            /*" -1490- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -1495- MOVE FUNCTION CURRENT-DATE TO WS-CURRENT-DATE */
            _.Move(_.CurrentDate(), WS_VARIAVEIS_GLOBAIS.WS_CURRENT_DATE);

            /*" -1498- DISPLAY 'DATA TERMINO: ' WS-DT-TODAY ' - HORA TERMINO: ' WS-HR-TODAY */

            $"DATA TERMINO: {WS_VARIAVEIS_GLOBAIS.WS_CURRENT_DATE.WS_DATE_R.WS_DT_TODAY} - HORA TERMINO: {WS_VARIAVEIS_GLOBAIS.WS_CURRENT_DATE.WS_DATE_R.WS_HR_TODAY}"
            .Display();

            /*" -1503- COMPUTE WS-SEG-FINAL = (WS-HR-HOR * 60 * 60) + (WS-HR-MIN * 60) + WS-HR-SEG + (WS-HR-DECSEG / 100) */
            WS_SEG_FINAL.Value = (WS_VARIAVEIS_GLOBAIS.WS_CURRENT_DATE.WS_DATE_R.FILLER_364.WS_HR_HOR * 60 * 60) + (WS_VARIAVEIS_GLOBAIS.WS_CURRENT_DATE.WS_DATE_R.FILLER_364.WS_HR_MIN * 60) + WS_VARIAVEIS_GLOBAIS.WS_CURRENT_DATE.WS_DATE_R.FILLER_364.WS_HR_SEG + (WS_VARIAVEIS_GLOBAIS.WS_CURRENT_DATE.WS_DATE_R.WS_HR_DECSEG / 100f);

            /*" -1505- SUBTRACT WS-SEG-INICIAL FROM WS-SEG-FINAL */
            WS_SEG_FINAL.Value = WS_SEG_FINAL - WS_SEG_INICIAL;

            /*" -1507- MOVE WS-SEG-FINAL TO WS-TOT-TIME-ED */
            _.Move(WS_SEG_FINAL, WS_TOT_TIME_ED);

            /*" -1509- DISPLAY 'TEMPO SEG: ' WS-TOT-TIME-ED */
            _.Display($"TEMPO SEG: {WS_TOT_TIME_ED}");

            /*" -1511- COMPUTE WS-SEG-FINAL = WS-SEG-FINAL / 60 */
            WS_SEG_FINAL.Value = WS_SEG_FINAL / 60f;

            /*" -1513- MOVE WS-SEG-FINAL TO WS-TOT-TIME-ED */
            _.Move(WS_SEG_FINAL, WS_TOT_TIME_ED);

            /*" -1515- DISPLAY 'TEMPO MIN: ' WS-TOT-TIME-ED */
            _.Display($"TEMPO MIN: {WS_TOT_TIME_ED}");

            /*" -1517- MOVE ZEROS TO RETURN-CODE */
            _.Move(0, RETURN_CODE);

            /*" -1519- DISPLAY 'SI0021B        *** FIM NORMAL ***' . */
            _.Display($"SI0021B        *** FIM NORMAL ***");

            /*" -1519- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_000_999_EXIT*/

        [StopWatch]
        /*" M-015-000-CABECALHOS-SECTION */
        private void M_015_000_CABECALHOS_SECTION()
        {
            /*" -1530- MOVE V1SIST-DTMOVABE TO WDATA-SQL */
            _.Move(V1SIST_DTMOVABE, W.WDATA_SQL);

            /*" -1531- MOVE WDAT-DIA-SQL TO WDATA-DD-CABEC */
            _.Move(W.FILLER_344.WDAT_DIA_SQL, W.WDATA_CABEC.WDATA_DD_CABEC);

            /*" -1532- MOVE WDAT-MES-SQL TO WDATA-MM-CABEC */
            _.Move(W.FILLER_344.WDAT_MES_SQL, W.WDATA_CABEC.WDATA_MM_CABEC);

            /*" -1533- MOVE WDAT-ANO-SQL TO WDATA-AA-CABEC */
            _.Move(W.FILLER_344.WDAT_ANO_SQL, W.WDATA_CABEC.WDATA_AA_CABEC);

            /*" -1535- MOVE WDATA-CABEC TO LC02-DATA */
            _.Move(W.WDATA_CABEC, W.LC02.LC02_DATA);

            /*" -1536- ACCEPT WHORA-CURR FROM TIME */
            _.Move(_.AcceptDate("TIME"), W.WHORA_CURR);

            /*" -1537- MOVE WHORA-HH-CURR TO WHORA-HH-CABEC */
            _.Move(W.WHORA_CURR.WHORA_HH_CURR, W.WHORA_CABEC.WHORA_HH_CABEC);

            /*" -1538- MOVE WHORA-HH-CURR TO WHORA-MM-CABEC */
            _.Move(W.WHORA_CURR.WHORA_HH_CURR, W.WHORA_CABEC.WHORA_MM_CABEC);

            /*" -1539- MOVE WHORA-SS-CURR TO WHORA-SS-CABEC */
            _.Move(W.WHORA_CURR.WHORA_SS_CURR, W.WHORA_CABEC.WHORA_SS_CABEC);

            /*" -1541- MOVE WHORA-CABEC TO LC03-HORA */
            _.Move(W.WHORA_CABEC, W.LC03.LC03_HORA);

            /*" -1543- MOVE '015' TO WNR-EXEC-SQL */
            _.Move("015", W.WABEND.WNR_EXEC_SQL);

            /*" -1547- PERFORM M_015_000_CABECALHOS_DB_SELECT_1 */

            M_015_000_CABECALHOS_DB_SELECT_1();

            /*" -1550- MOVE V1EMPRESA-MNUEMP TO LK-TITULO */
            _.Move(V1EMPRESA_MNUEMP, LK_LINK.LK_TITULO);

            /*" -1552- CALL 'PROALN01' USING LK-LINK */
            _.Call("PROALN01", LK_LINK);

            /*" -1553- IF LK-RTCODE EQUAL ZEROS */

            if (LK_LINK.LK_RTCODE == 00)
            {

                /*" -1554- MOVE LK-TITULO TO LC01-EMPRESA */
                _.Move(LK_LINK.LK_TITULO, W.LC01.LC01_EMPRESA);

                /*" -1555- ELSE */
            }
            else
            {


                /*" -1556- DISPLAY 'SI0021B - PROBLEMAS CALL PROALN02 ... ' */
                _.Display($"SI0021B - PROBLEMAS CALL PROALN02 ... ");

                /*" -1556- STOP RUN. */

                throw new GoBack();   // => STOP RUN.
            }


        }

        [StopWatch]
        /*" M-015-000-CABECALHOS-DB-SELECT-1 */
        public void M_015_000_CABECALHOS_DB_SELECT_1()
        {
            /*" -1547- EXEC SQL SELECT NOME_EMPRESA INTO :V1EMPRESA-MNUEMP FROM SEGUROS.V1EMPRESA WHERE COD_EMPRESA = 0 END-EXEC. */

            var m_015_000_CABECALHOS_DB_SELECT_1_Query1 = new M_015_000_CABECALHOS_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = M_015_000_CABECALHOS_DB_SELECT_1_Query1.Execute(m_015_000_CABECALHOS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1EMPRESA_MNUEMP, V1EMPRESA_MNUEMP);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_015_999_EXIT*/

        [StopWatch]
        /*" M-020-000-MASCARA-SECTION */
        private void M_020_000_MASCARA_SECTION()
        {
            /*" -1567- PERFORM 015-000-CABECALHOS */

            M_015_000_CABECALHOS_SECTION();

            /*" -1599- MOVE ALL 'X' TO LC01-EMPRESA LC05-NOMECONG LC05-PERI-INICIAL LC05-PERI-FINAL LC06-REFER LC09-NOME LC09-NOMERAMO LC11-SIGLUNIM LC13-NOMFAV LC16-DESCVEIC LC16-PLACALET LC16-CHASSIS LC19-DESCRITEM LC22-TRANSP LC22-PLACLET LC22-PREFIXO LC22-EMBARQUE LC24-EMPRESA LC24-MERCAD LC24-NATUREZA LC24-COBERTUR LC26-ORIGEM LC26-DESTINO LC26-LOCAL LC26-CIDADE LC29-ESTIPUL LC29-SEG-PRI LC29-SEG-SIN LC31-GARANTIA LC33-REFER LC16-PLACANR */
            _.MoveAll("X", W.LC01.LC01_EMPRESA, W.LC05.LC05_NOMECONG, W.LC05.LC05_PERI_INICIAL, W.LC05.LC05_PERI_FINAL, W.LC06.LC06_REFER, W.LC09.LC09_NOME, W.LC09.LC09_NOMERAMO, W.LC11.LC11_SIGLUNIM, W.LC13.LC13_NOMFAV, W.LC16.LC16_DESCVEIC, W.LC16.LC16_PLACA.LC16_PLACALET, W.LC16.LC16_CHASSIS, W.LC19.LC19_DESCRITEM, W.LC22.LC22_TRANSP, W.LC22.LC22_PLACA.LC22_PLACLET, W.LC22.LC22_PREFIXO, W.LC22.LC22_EMBARQUE, W.LC24.LC24_EMPRESA, W.LC24.LC24_MERCAD, W.LC24.LC24_NATUREZA, W.LC24.LC24_COBERTUR, W.LC26.LC26_ORIGEM, W.LC26.LC26_DESTINO, W.LC26.LC26_LOCAL, W.LC26.LC26_CIDADE, W.LC29.LC29_ESTIPUL, W.LC29.LC29_SEG_PRI, W.LC29.LC29_SEG_SIN, W.LC31.LC31_GARANTIA, W.LC33.LC33_REFER, W.LC16.LC16_PLACA.LC16_PLACANR);

            /*" -1648- MOVE WORK9S TO LC01-PAG LC05-CODCOSS LC06-SINISTRO LC09-PCPARTIC LC09-DD-SINI LC09-MM-SINI LC09-AA-SINI LC09-DD-AVISO LC09-MM-AVISO LC09-AA-AVISO LC11-APOLICE LC11-NRORDEM LC11-DD-I LC11-MM-I LC11-AA-I LC11-DD-T LC11-MM-T LC11-AA-T LC11-ITEM LC11-ISITEM LC13-SINIRB LC16-ANOVEICL LC22-AVERBACAO LC22-PLACNUM LC31-DIA1 LC31-MES1 LC31-ANO1 LC31-DIA2 LC31-MES2 LC31-ANO2 LC34-VAL-TOTAL LC34-SUA-PARTIC LC34-TOT-COSSEG LC35-VAL-TOTAL LC35-SUA-PARTIC LC35-TOT-COSSEG. */
            _.Move(W.WORK9S, W.LC01.LC01_PAG, W.LC05.LC05_CODCOSS, W.LC06.LC06_SINISTRO, W.LC09.LC09_PCPARTIC, W.LC09.LC09_DTSINI.LC09_DD_SINI, W.LC09.LC09_DTSINI.LC09_MM_SINI, W.LC09.LC09_DTSINI.LC09_AA_SINI, W.LC09.LC09_DTAVISO.LC09_DD_AVISO, W.LC09.LC09_DTAVISO.LC09_MM_AVISO, W.LC09.LC09_DTAVISO.LC09_AA_AVISO, W.LC11.LC11_APOLICE, W.LC11.LC11_NRORDEM, W.LC11.LC11_DTINIVIG.LC11_DD_I, W.LC11.LC11_DTINIVIG.LC11_MM_I, W.LC11.LC11_DTINIVIG.LC11_AA_I, W.LC11.LC11_DTTERVIG.LC11_DD_T, W.LC11.LC11_DTTERVIG.LC11_MM_T, W.LC11.LC11_DTTERVIG.LC11_AA_T, W.LC11.LC11_ITEM, W.LC11.LC11_ISITEM, W.LC13.LC13_SINIRB, W.LC16.LC16_ANOVEICL, W.LC22.LC22_AVERBACAO, W.LC22.LC22_PLACA.LC22_PLACNUM, W.LC31.LC31_DATA1.LC31_DIA1, W.LC31.LC31_DATA1.LC31_MES1, W.LC31.LC31_DATA1.LC31_ANO1, W.LC31.LC31_DATA2.LC31_DIA2, W.LC31.LC31_DATA2.LC31_MES2, W.LC31.LC31_DATA2.LC31_ANO2, W.LC34.LC34_VAL_TOTAL, W.LC34.LC34_SUA_PARTIC, W.LC34.LC34_TOT_COSSEG, W.LC35.LC35_VAL_TOTAL, W.LC35.LC35_SUA_PARTIC, W.LC35.LC35_TOT_COSSEG);

            /*" -1650- PERFORM 700-000-IMPRIME 2 TIMES. */

            for (int i = 0; i < 2; i++)
            {

                M_700_000_IMPRIME_SECTION();

            }

            /*" -1652- PERFORM 750-000-LIMPA-LINHAS. */

            M_750_000_LIMPA_LINHAS_SECTION();

            /*" -1652- MOVE ZEROS TO AC-PAGINAS. */
            _.Move(0, W.AC_PAGINAS);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_020_999_EXIT*/

        [StopWatch]
        /*" M-025-000-SISTEMA-SECTION */
        private void M_025_000_SISTEMA_SECTION()
        {
            /*" -1664- MOVE '025' TO WNR-EXEC-SQL */
            _.Move("025", W.WABEND.WNR_EXEC_SQL);

            /*" -1670- PERFORM M_025_000_SISTEMA_DB_SELECT_1 */

            M_025_000_SISTEMA_DB_SELECT_1();

            /*" -1673- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1674- DISPLAY 'ERRO NO ACESSO A V1SISTEMA ......... ' */
                _.Display($"ERRO NO ACESSO A V1SISTEMA ......... ");

                /*" -1678- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1679- MOVE V1SIST-DTMOVABE TO WDATA-SQL */
            _.Move(V1SIST_DTMOVABE, W.WDATA_SQL);

            /*" -1680- MOVE WDAT-DIA-SQL TO WDAT-LIT-DIA */
            _.Move(W.FILLER_344.WDAT_DIA_SQL, W.WDATA_LIT.WDAT_LIT_DIA);

            /*" -1681- MOVE WDAT-MES-SQL TO WDAT-LIT-MES */
            _.Move(W.FILLER_344.WDAT_MES_SQL, W.WDATA_LIT.WDAT_LIT_MES);

            /*" -1681- MOVE WDAT-ANO-SQL TO WDAT-LIT-ANO. */
            _.Move(W.FILLER_344.WDAT_ANO_SQL, W.WDATA_LIT.WDAT_LIT_ANO);

        }

        [StopWatch]
        /*" M-025-000-SISTEMA-DB-SELECT-1 */
        public void M_025_000_SISTEMA_DB_SELECT_1()
        {
            /*" -1670- EXEC SQL SELECT DTMOVABE INTO :V1SIST-DTMOVABE FROM SEGUROS.V1SISTEMA WHERE IDSISTEM = 'AC' WITH UR END-EXEC. */

            var m_025_000_SISTEMA_DB_SELECT_1_Query1 = new M_025_000_SISTEMA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = M_025_000_SISTEMA_DB_SELECT_1_Query1.Execute(m_025_000_SISTEMA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1SIST_DTMOVABE, V1SIST_DTMOVABE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_025_999_EXIT*/

        [StopWatch]
        /*" M-030-000-INICIO-SECTION */
        private void M_030_000_INICIO_SECTION()
        {
            /*" -1691- OPEN OUTPUT SI0021M1. */
            SI0021M1.Open(REG_SI0021M1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_030_999_EXIT*/

        [StopWatch]
        /*" M-090-000-CURSOR-V1HISTSINI-SECTION */
        private void M_090_000_CURSOR_V1HISTSINI_SECTION()
        {
            /*" -1702- MOVE '090' TO WNR-EXEC-SQL. */
            _.Move("090", W.WABEND.WNR_EXEC_SQL);

            /*" -1702- PERFORM M_090_000_CURSOR_V1HISTSINI_DB_OPEN_1 */

            M_090_000_CURSOR_V1HISTSINI_DB_OPEN_1();

            /*" -1705- IF SQLCODE NOT EQUAL ZERO */

            if (DB.SQLCODE != 00)
            {

                /*" -1706- DISPLAY 'SI0021B - ERRO NO OPEN PRINCIPAL ............ ' */
                _.Display($"SI0021B - ERRO NO OPEN PRINCIPAL ............ ");

                /*" -1706- GO TO R10010199-MENSAGEM-LOCK. */

                R10010199_MENSAGEM_LOCK(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-090-000-CURSOR-V1HISTSINI-DB-OPEN-1 */
        public void M_090_000_CURSOR_V1HISTSINI_DB_OPEN_1()
        {
            /*" -1702- EXEC SQL OPEN V1HISTSIN END-EXEC. */

            V1HISTSIN.Open();

        }

        [StopWatch]
        /*" M-360-000-CURSOR-V1APOLCOSCED-DB-DECLARE-1 */
        public void M_360_000_CURSOR_V1APOLCOSCED_DB_DECLARE_1()
        {
            /*" -2265- EXEC SQL DECLARE V1APOLCOSCED CURSOR FOR SELECT CODCOSS ,PCPARTIC FROM SEGUROS.V1APOLCOSCED WHERE NUM_APOLICE = :V1MEST-NUM-APOL AND DTINIVIG <= :V1MEST-DATORR AND DTTERVIG >= :V1MEST-DATORR AND CODCOSS BETWEEN :WS-CONG-INICIAL AND :WS-CONG-FINAL ORDER BY CODCOSS WITH UR END-EXEC. */
            V1APOLCOSCED = new SI0021B_V1APOLCOSCED(true);
            string GetQuery_V1APOLCOSCED()
            {
                var query = @$"SELECT CODCOSS 
							,PCPARTIC 
							FROM SEGUROS.V1APOLCOSCED 
							WHERE NUM_APOLICE = '{V1MEST_NUM_APOL}' 
							AND DTINIVIG <= '{V1MEST_DATORR}' 
							AND DTTERVIG >= '{V1MEST_DATORR}' 
							AND CODCOSS BETWEEN '{WS_CONG_INICIAL}' 
							AND '{WS_CONG_FINAL}' 
							ORDER BY CODCOSS";

                return query;
            }
            V1APOLCOSCED.GetQueryEvent += GetQuery_V1APOLCOSCED;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_090_999_EXIT*/

        [StopWatch]
        /*" M-100-000-LER-V1HISTSINI-SECTION */
        private void M_100_000_LER_V1HISTSINI_SECTION()
        {
            /*" -1716- MOVE '100' TO WNR-EXEC-SQL. */
            _.Move("100", W.WABEND.WNR_EXEC_SQL);

            /*" -1718- MOVE AT-USUARIO TO AN-USUARIO. */
            _.Move(W.AT_USUARIO, W.AN_USUARIO);

            /*" -1748- PERFORM M_100_000_LER_V1HISTSINI_DB_FETCH_1 */

            M_100_000_LER_V1HISTSINI_DB_FETCH_1();

            /*" -1751- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1752- MOVE 'S' TO WFIM-V1HISTSINI */
                _.Move("S", W.WFIM_V1HISTSINI);

                /*" -1753- MOVE 999999999999 TO CH-SINI-ATU */
                _.Move(999999999999, W.CH_CHAVE_ATU.CH_SINI_ATU);

                /*" -1754- MOVE 9999 TO CH-OPER-ATU */
                _.Move(9999, W.CH_CHAVE_ATU.CH_OPER_ATU);

                /*" -1756- MOVE '9' TO CH-CURSOR-ATU */
                _.Move("9", W.CH_CHAVE_ATU.CH_CURSOR_ATU);

                /*" -1756- PERFORM M_100_000_LER_V1HISTSINI_DB_CLOSE_1 */

                M_100_000_LER_V1HISTSINI_DB_CLOSE_1();

                /*" -1759- IF SQLCODE NOT EQUAL ZERO */

                if (DB.SQLCODE != 00)
                {

                    /*" -1760- DISPLAY 'SI0021B - ERRO NO CLOSE PRINCIPAL .........' */
                    _.Display($"SI0021B - ERRO NO CLOSE PRINCIPAL .........");

                    /*" -1761- GO TO 999-999-ROT-ERRO */

                    M_999_999_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1762- ELSE */
                }
                else
                {


                    /*" -1764- GO TO 100-999-EXIT. */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_100_999_EXIT*/ //GOTO
                    return;
                }

            }


            /*" -1766- IF (SQLCODE NOT EQUAL ZERO) AND (SQLCODE NOT EQUAL 100) */

            if ((DB.SQLCODE != 00) && (DB.SQLCODE != 100))
            {

                /*" -1767- DISPLAY 'SI0021B - ERRO NO FETCH PRINCIPAL .........' */
                _.Display($"SI0021B - ERRO NO FETCH PRINCIPAL .........");

                /*" -1769- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1770- MOVE V1MEST-APOL-SINI TO CH-SINI-ATU. */
            _.Move(V1MEST_APOL_SINI, W.CH_CHAVE_ATU.CH_SINI_ATU);

            /*" -1771- MOVE V1HIST-OPERACAO TO CH-OPER-ATU. */
            _.Move(V1HIST_OPERACAO, W.CH_CHAVE_ATU.CH_OPER_ATU);

            /*" -1772- MOVE WS-TIPO-CURSOR TO CH-CURSOR-ATU. */
            _.Move(WS_TIPO_CURSOR, W.CH_CHAVE_ATU.CH_CURSOR_ATU);

            /*" -1775- MOVE V1RELA-COD-USUARIO TO AT-USUARIO. */
            _.Move(V1RELA_COD_USUARIO, W.AT_USUARIO);

            /*" -1778- IF (AT-USUARIO NOT = AN-USUARIO) OR (RELATORI-COD-CONGENERE NOT = AN-CONGENERE) */

            if ((W.AT_USUARIO != W.AN_USUARIO) || (RELATORI.DCLRELATORIOS.RELATORI_COD_CONGENERE != AN_CONGENERE))
            {

                /*" -1779- IF AN-USUARIO EQUAL LOW-VALUE */

                if (W.AN_USUARIO == "")
                {

                    /*" -1780- MOVE AT-USUARIO TO AN-USUARIO */
                    _.Move(W.AT_USUARIO, W.AN_USUARIO);

                    /*" -1782- END-IF */
                }


                /*" -1784- MOVE RELATORI-COD-CONGENERE TO AN-CONGENERE */
                _.Move(RELATORI.DCLRELATORIOS.RELATORI_COD_CONGENERE, AN_CONGENERE);

                /*" -1785- IF AT-USUARIO NOT EQUAL 'SEG99999' */

                if (W.AT_USUARIO != "SEG99999")
                {

                    /*" -1786- PERFORM R1000-LE-USUARIO */

                    R1000_LE_USUARIO_SECTION();

                    /*" -1788- END-IF */
                }


                /*" -1790- PERFORM R1010-GRAVA-CAPA */

                R1010_GRAVA_CAPA_SECTION();

                /*" -1792- PERFORM 020-000-MASCARA */

                M_020_000_MASCARA_SECTION();

                /*" -1793- IF RELATORI-PERI-INICIAL = '9999-12-31' */

                if (RELATORI.DCLRELATORIOS.RELATORI_PERI_INICIAL == "9999-12-31")
                {

                    /*" -1797- MOVE SPACES TO LC05-TEXTO-1 LC05-TEXTO-2 LC05-PERI-INICIAL LC05-PERI-FINAL */
                    _.Move("", W.LC05.LC05_TEXTO_1, W.LC05.LC05_TEXTO_2, W.LC05.LC05_PERI_INICIAL, W.LC05.LC05_PERI_FINAL);

                    /*" -1798- ELSE */
                }
                else
                {


                    /*" -1799- MOVE '   PERIODO: ' TO LC05-TEXTO-1 */
                    _.Move("   PERIODO: ", W.LC05.LC05_TEXTO_1);

                    /*" -1800- MOVE ' A ' TO LC05-TEXTO-2 */
                    _.Move(" A ", W.LC05.LC05_TEXTO_2);

                    /*" -1801- MOVE RELATORI-PERI-INICIAL TO WS-PERIODO-1 */
                    _.Move(RELATORI.DCLRELATORIOS.RELATORI_PERI_INICIAL, WS_VARIAVEIS.WS_PERIODO_1);

                    /*" -1802- MOVE WS-ANO-1 TO WS-ANO-2 */
                    _.Move(WS_VARIAVEIS.WS_PERIODO_1.WS_ANO_1, WS_VARIAVEIS.WS_PERIODO_2.WS_ANO_2);

                    /*" -1803- MOVE WS-MES-1 TO WS-MES-2 */
                    _.Move(WS_VARIAVEIS.WS_PERIODO_1.WS_MES_1, WS_VARIAVEIS.WS_PERIODO_2.WS_MES_2);

                    /*" -1804- MOVE WS-DIA-1 TO WS-DIA-2 */
                    _.Move(WS_VARIAVEIS.WS_PERIODO_1.WS_DIA_1, WS_VARIAVEIS.WS_PERIODO_2.WS_DIA_2);

                    /*" -1805- MOVE WS-PERIODO-2 TO LC05-PERI-INICIAL */
                    _.Move(WS_VARIAVEIS.WS_PERIODO_2, W.LC05.LC05_PERI_INICIAL);

                    /*" -1806- MOVE RELATORI-PERI-FINAL TO WS-PERIODO-1 */
                    _.Move(RELATORI.DCLRELATORIOS.RELATORI_PERI_FINAL, WS_VARIAVEIS.WS_PERIODO_1);

                    /*" -1807- MOVE WS-ANO-1 TO WS-ANO-2 */
                    _.Move(WS_VARIAVEIS.WS_PERIODO_1.WS_ANO_1, WS_VARIAVEIS.WS_PERIODO_2.WS_ANO_2);

                    /*" -1808- MOVE WS-MES-1 TO WS-MES-2 */
                    _.Move(WS_VARIAVEIS.WS_PERIODO_1.WS_MES_1, WS_VARIAVEIS.WS_PERIODO_2.WS_MES_2);

                    /*" -1809- MOVE WS-DIA-1 TO WS-DIA-2 */
                    _.Move(WS_VARIAVEIS.WS_PERIODO_1.WS_DIA_1, WS_VARIAVEIS.WS_PERIODO_2.WS_DIA_2);

                    /*" -1810- MOVE WS-PERIODO-2 TO LC05-PERI-FINAL */
                    _.Move(WS_VARIAVEIS.WS_PERIODO_2, W.LC05.LC05_PERI_FINAL);

                    /*" -1812- END-IF */
                }


                /*" -1814- END-IF. */
            }


            /*" -1814- ADD 1 TO AC-L-V1HISTSINI. */
            W.AC_L_V1HISTSINI.Value = W.AC_L_V1HISTSINI + 1;

        }

        [StopWatch]
        /*" M-100-000-LER-V1HISTSINI-DB-FETCH-1 */
        public void M_100_000_LER_V1HISTSINI_DB_FETCH_1()
        {
            /*" -1748- EXEC SQL FETCH V1HISTSIN INTO :V1HIST-OPERACAO ,:V1HIST-OCORHIST ,:V1HIST-NOMFAV ,:V1HIST-DTMOVTO ,:V1HIST-VAL-OPER ,:V1HIST-LIMCRR ,:V1MEST-NUM-APOL ,:V1MEST-NRENDOS ,:V1MEST-APOL-SINI ,:V1MEST-DATCMD ,:V1MEST-DATORR ,:V1MEST-NRCERTIF ,:V1MEST-MOEDA-SINI ,:V1MEST-IDTPSEGU ,:V1MEST-NUMIRB ,:V1MEST-CODSUBES ,:V1MEST-NREMBARQ ,:V1MEST-REFEMBQ ,:V1MEST-VALSEGBT ,:V1MEST-PCPARTIC ,:V1MEST-CODCAU ,:V1MEST-RAMO ,:GEOPERAC-DES-OPERACAO ,:GEOPERAC-FUNCAO-OPERACAO ,:V1RELA-COD-USUARIO ,:RELATORI-COD-CONGENERE ,:RELATORI-PERI-INICIAL ,:RELATORI-PERI-FINAL ,:WS-TIPO-CURSOR END-EXEC. */

            if (V1HISTSIN.Fetch())
            {
                _.Move(V1HISTSIN.V1HIST_OPERACAO, V1HIST_OPERACAO);
                _.Move(V1HISTSIN.V1HIST_OCORHIST, V1HIST_OCORHIST);
                _.Move(V1HISTSIN.V1HIST_NOMFAV, V1HIST_NOMFAV);
                _.Move(V1HISTSIN.V1HIST_DTMOVTO, V1HIST_DTMOVTO);
                _.Move(V1HISTSIN.V1HIST_VAL_OPER, V1HIST_VAL_OPER);
                _.Move(V1HISTSIN.V1HIST_LIMCRR, V1HIST_LIMCRR);
                _.Move(V1HISTSIN.V1MEST_NUM_APOL, V1MEST_NUM_APOL);
                _.Move(V1HISTSIN.V1MEST_NRENDOS, V1MEST_NRENDOS);
                _.Move(V1HISTSIN.V1MEST_APOL_SINI, V1MEST_APOL_SINI);
                _.Move(V1HISTSIN.V1MEST_DATCMD, V1MEST_DATCMD);
                _.Move(V1HISTSIN.V1MEST_DATORR, V1MEST_DATORR);
                _.Move(V1HISTSIN.V1MEST_NRCERTIF, V1MEST_NRCERTIF);
                _.Move(V1HISTSIN.V1MEST_MOEDA_SINI, V1MEST_MOEDA_SINI);
                _.Move(V1HISTSIN.V1MEST_IDTPSEGU, V1MEST_IDTPSEGU);
                _.Move(V1HISTSIN.V1MEST_NUMIRB, V1MEST_NUMIRB);
                _.Move(V1HISTSIN.V1MEST_CODSUBES, V1MEST_CODSUBES);
                _.Move(V1HISTSIN.V1MEST_NREMBARQ, V1MEST_NREMBARQ);
                _.Move(V1HISTSIN.V1MEST_REFEMBQ, V1MEST_REFEMBQ);
                _.Move(V1HISTSIN.V1MEST_VALSEGBT, V1MEST_VALSEGBT);
                _.Move(V1HISTSIN.V1MEST_PCPARTIC, V1MEST_PCPARTIC);
                _.Move(V1HISTSIN.V1MEST_CODCAU, V1MEST_CODCAU);
                _.Move(V1HISTSIN.V1MEST_RAMO, V1MEST_RAMO);
                _.Move(V1HISTSIN.GEOPERAC_DES_OPERACAO, GEOPERAC_DES_OPERACAO);
                _.Move(V1HISTSIN.GEOPERAC_FUNCAO_OPERACAO, GEOPERAC_FUNCAO_OPERACAO);
                _.Move(V1HISTSIN.V1RELA_COD_USUARIO, V1RELA_COD_USUARIO);
                _.Move(V1HISTSIN.RELATORI_COD_CONGENERE, RELATORI.DCLRELATORIOS.RELATORI_COD_CONGENERE);
                _.Move(V1HISTSIN.RELATORI_PERI_INICIAL, RELATORI.DCLRELATORIOS.RELATORI_PERI_INICIAL);
                _.Move(V1HISTSIN.RELATORI_PERI_FINAL, RELATORI.DCLRELATORIOS.RELATORI_PERI_FINAL);
                _.Move(V1HISTSIN.WS_TIPO_CURSOR, WS_TIPO_CURSOR);
            }

        }

        [StopWatch]
        /*" M-100-000-LER-V1HISTSINI-DB-CLOSE-1 */
        public void M_100_000_LER_V1HISTSINI_DB_CLOSE_1()
        {
            /*" -1756- EXEC SQL CLOSE V1HISTSIN END-EXEC */

            V1HISTSIN.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_100_999_EXIT*/

        [StopWatch]
        /*" R1000-LE-USUARIO-SECTION */
        private void R1000_LE_USUARIO_SECTION()
        {
            /*" -1825- MOVE '1000' TO WNR-EXEC-SQL */
            _.Move("1000", W.WABEND.WNR_EXEC_SQL);

            /*" -1832- PERFORM R1000_LE_USUARIO_DB_SELECT_1 */

            R1000_LE_USUARIO_DB_SELECT_1();

            /*" -1835- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1836- IF SQLCODE EQUAL +100 */

                if (DB.SQLCODE == +100)
                {

                    /*" -1837- DISPLAY 'SI0021B - USUARIO NAO ACHADO NA TAB USUARIOS' */
                    _.Display($"SI0021B - USUARIO NAO ACHADO NA TAB USUARIOS");

                    /*" -1838- ELSE */
                }
                else
                {


                    /*" -1839- DISPLAY 'SI0021B - ERRO NO SELECT USUARIOS ..........' */
                    _.Display($"SI0021B - ERRO NO SELECT USUARIOS ..........");

                    /*" -1840- END-IF */
                }


                /*" -1841- DISPLAY 'USUARIO  ... ' AT-USUARIO */
                _.Display($"USUARIO  ... {W.AT_USUARIO}");

                /*" -1842- GO TO 999-999-ROT-ERRO */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1842- END-IF. */
            }


        }

        [StopWatch]
        /*" R1000-LE-USUARIO-DB-SELECT-1 */
        public void R1000_LE_USUARIO_DB_SELECT_1()
        {
            /*" -1832- EXEC SQL SELECT NOME_USUARIO ,DEPARTAMENTO INTO :V0USU-NOME-USUARIO ,:V0USU-DEPARTAMENTO FROM SEGUROS.USUARIOS WHERE COD_USUARIO = :AT-USUARIO END-EXEC. */

            var r1000_LE_USUARIO_DB_SELECT_1_Query1 = new R1000_LE_USUARIO_DB_SELECT_1_Query1()
            {
                AT_USUARIO = W.AT_USUARIO.ToString(),
            };

            var executed_1 = R1000_LE_USUARIO_DB_SELECT_1_Query1.Execute(r1000_LE_USUARIO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0USU_NOME_USUARIO, V0USU_NOME_USUARIO);
                _.Move(executed_1.V0USU_DEPARTAMENTO, V0USU_DEPARTAMENTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_EXIT*/

        [StopWatch]
        /*" R1010-GRAVA-CAPA-SECTION */
        private void R1010_GRAVA_CAPA_SECTION()
        {
            /*" -1852- MOVE 10 TO FONTE-SEP05. */
            _.Move(10, CAPA_RELATORIO.SEP05.FONTE_SEP05);

            /*" -1853- MOVE 'MATRIZ' TO NOME-FONTE-SEP05. */
            _.Move("MATRIZ", CAPA_RELATORIO.SEP05.NOME_FONTE_SEP05);

            /*" -1854- MOVE ZEROS TO PRODUTO-SEP06. */
            _.Move(0, CAPA_RELATORIO.SEP06.PRODUTO_SEP06);

            /*" -1856- MOVE SPACES TO NOME-PRODUTO-SEP06. */
            _.Move("", CAPA_RELATORIO.SEP06.NOME_PRODUTO_SEP06);

            /*" -1858- IF AT-USUARIO EQUAL 'SEG99999' */

            if (W.AT_USUARIO == "SEG99999")
            {

                /*" -1859- MOVE 'GERCO' TO LOTACAO-SEP07 */
                _.Move("GERCO", CAPA_RELATORIO.SEP07.LOTACAO_SEP07);

                /*" -1860- MOVE 'MARLINDO LIMA CARDOSO' TO RESPONSAVEL-SEP07 */
                _.Move("MARLINDO LIMA CARDOSO", CAPA_RELATORIO.SEP07A.RESPONSAVEL_SEP07);

                /*" -1861- ELSE */
            }
            else
            {


                /*" -1862- MOVE V0USU-DEPARTAMENTO TO LOTACAO-SEP07 */
                _.Move(V0USU_DEPARTAMENTO, CAPA_RELATORIO.SEP07.LOTACAO_SEP07);

                /*" -1863- MOVE V0USU-NOME-USUARIO TO RESPONSAVEL-SEP07 */
                _.Move(V0USU_NOME_USUARIO, CAPA_RELATORIO.SEP07A.RESPONSAVEL_SEP07);

                /*" -1865- END-IF. */
            }


            /*" -1867- MOVE SPACES TO TP-OPERACAO-SEP08. */
            _.Move("", CAPA_RELATORIO.SEP08.TP_OPERACAO_SEP08);

            /*" -1869- WRITE REG-SI0021M1 FROM LCB AFTER PAGE. */
            _.Move(W.LCB.GetMoveValues(), REG_SI0021M1);

            SI0021M1.Write(REG_SI0021M1.GetMoveValues().ToString());

            /*" -1870- WRITE REG-SI0021M1 FROM SEP02 AFTER 4. */
            _.Move(CAPA_RELATORIO.SEP02.GetMoveValues(), REG_SI0021M1);

            SI0021M1.Write(REG_SI0021M1.GetMoveValues().ToString());

            /*" -1871- WRITE REG-SI0021M1 FROM SEP03 AFTER 1. */
            _.Move(CAPA_RELATORIO.SEP03.GetMoveValues(), REG_SI0021M1);

            SI0021M1.Write(REG_SI0021M1.GetMoveValues().ToString());

            /*" -1872- WRITE REG-SI0021M1 FROM SEP03 AFTER 1. */
            _.Move(CAPA_RELATORIO.SEP03.GetMoveValues(), REG_SI0021M1);

            SI0021M1.Write(REG_SI0021M1.GetMoveValues().ToString());

            /*" -1873- WRITE REG-SI0021M1 FROM SEP04 AFTER 1. */
            _.Move(CAPA_RELATORIO.SEP04.GetMoveValues(), REG_SI0021M1);

            SI0021M1.Write(REG_SI0021M1.GetMoveValues().ToString());

            /*" -1874- WRITE REG-SI0021M1 FROM SEP03 AFTER 1. */
            _.Move(CAPA_RELATORIO.SEP03.GetMoveValues(), REG_SI0021M1);

            SI0021M1.Write(REG_SI0021M1.GetMoveValues().ToString());

            /*" -1875- WRITE REG-SI0021M1 FROM SEP05 AFTER 1. */
            _.Move(CAPA_RELATORIO.SEP05.GetMoveValues(), REG_SI0021M1);

            SI0021M1.Write(REG_SI0021M1.GetMoveValues().ToString());

            /*" -1876- WRITE REG-SI0021M1 FROM SEP03 AFTER 1. */
            _.Move(CAPA_RELATORIO.SEP03.GetMoveValues(), REG_SI0021M1);

            SI0021M1.Write(REG_SI0021M1.GetMoveValues().ToString());

            /*" -1877- WRITE REG-SI0021M1 FROM SEP07A AFTER 1. */
            _.Move(CAPA_RELATORIO.SEP07A.GetMoveValues(), REG_SI0021M1);

            SI0021M1.Write(REG_SI0021M1.GetMoveValues().ToString());

            /*" -1878- WRITE REG-SI0021M1 FROM SEP03 AFTER 1. */
            _.Move(CAPA_RELATORIO.SEP03.GetMoveValues(), REG_SI0021M1);

            SI0021M1.Write(REG_SI0021M1.GetMoveValues().ToString());

            /*" -1879- WRITE REG-SI0021M1 FROM SEP07 AFTER 1. */
            _.Move(CAPA_RELATORIO.SEP07.GetMoveValues(), REG_SI0021M1);

            SI0021M1.Write(REG_SI0021M1.GetMoveValues().ToString());

            /*" -1880- WRITE REG-SI0021M1 FROM SEP03 AFTER 1. */
            _.Move(CAPA_RELATORIO.SEP03.GetMoveValues(), REG_SI0021M1);

            SI0021M1.Write(REG_SI0021M1.GetMoveValues().ToString());

            /*" -1881- WRITE REG-SI0021M1 FROM SEP03 AFTER 1. */
            _.Move(CAPA_RELATORIO.SEP03.GetMoveValues(), REG_SI0021M1);

            SI0021M1.Write(REG_SI0021M1.GetMoveValues().ToString());

            /*" -1882- WRITE REG-SI0021M1 FROM SEP03 AFTER 1. */
            _.Move(CAPA_RELATORIO.SEP03.GetMoveValues(), REG_SI0021M1);

            SI0021M1.Write(REG_SI0021M1.GetMoveValues().ToString());

            /*" -1883- WRITE REG-SI0021M1 FROM SEP08 AFTER 1. */
            _.Move(CAPA_RELATORIO.SEP08.GetMoveValues(), REG_SI0021M1);

            SI0021M1.Write(REG_SI0021M1.GetMoveValues().ToString());

            /*" -1883- WRITE REG-SI0021M1 FROM SEP02 AFTER 1. */
            _.Move(CAPA_RELATORIO.SEP02.GetMoveValues(), REG_SI0021M1);

            SI0021M1.Write(REG_SI0021M1.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1010_EXIT*/

        [StopWatch]
        /*" M-120-000-PROCESSA-REGISTRO-SECTION */
        private void M_120_000_PROCESSA_REGISTRO_SECTION()
        {
            /*" -1901- DISPLAY 'LENDO CURSOR: ' V1MEST-APOL-SINI ' APO ' V1MEST-NUM-APOL ' DT MOV ' V1HIST-DTMOVTO ' DT OCO ' V1MEST-DATORR ' CURSOR ' WS-TIPO-CURSOR ' USUAR ' V1RELA-COD-USUARIO ' CONG ' RELATORI-COD-CONGENERE ' PER ' RELATORI-PERI-INICIAL ' A ' RELATORI-PERI-FINAL */

            $"LENDO CURSOR: {V1MEST_APOL_SINI} APO {V1MEST_NUM_APOL} DT MOV {V1HIST_DTMOVTO} DT OCO {V1MEST_DATORR} CURSOR {WS_TIPO_CURSOR} USUAR {V1RELA_COD_USUARIO} CONG {RELATORI.DCLRELATORIOS.RELATORI_COD_CONGENERE} PER {RELATORI.DCLRELATORIOS.RELATORI_PERI_INICIAL} A {RELATORI.DCLRELATORIOS.RELATORI_PERI_FINAL}"
            .Display();

            /*" -1903- MOVE GEOPERAC-DES-OPERACAO TO LC06-REFER LC33-REFER. */
            _.Move(GEOPERAC_DES_OPERACAO, W.LC06.LC06_REFER, W.LC33.LC33_REFER);

            /*" -1905- MOVE V1MEST-APOL-SINI TO LC06-SINISTRO WS-APOL-SINI. */
            _.Move(V1MEST_APOL_SINI, W.LC06.LC06_SINISTRO, W.WS_APOL_SINI);

            /*" -1906- MOVE V1MEST-DATORR TO WDATA-R */
            _.Move(V1MEST_DATORR, W.WDATA_R);

            /*" -1907- MOVE WDATA-DD TO LC09-DD-SINI */
            _.Move(W.WDATA.WDATA_DD, W.LC09.LC09_DTSINI.LC09_DD_SINI);

            /*" -1908- MOVE WDATA-MM TO LC09-MM-SINI */
            _.Move(W.WDATA.WDATA_MM, W.LC09.LC09_DTSINI.LC09_MM_SINI);

            /*" -1909- MOVE WDATA-AA TO LC09-AA-SINI. */
            _.Move(W.WDATA.WDATA_AA, W.LC09.LC09_DTSINI.LC09_AA_SINI);

            /*" -1910- MOVE V1MEST-DATCMD TO WDATA-R */
            _.Move(V1MEST_DATCMD, W.WDATA_R);

            /*" -1911- MOVE WDATA-DD TO LC09-DD-AVISO */
            _.Move(W.WDATA.WDATA_DD, W.LC09.LC09_DTAVISO.LC09_DD_AVISO);

            /*" -1912- MOVE WDATA-MM TO LC09-MM-AVISO */
            _.Move(W.WDATA.WDATA_MM, W.LC09.LC09_DTAVISO.LC09_MM_AVISO);

            /*" -1913- MOVE WDATA-AA TO LC09-AA-AVISO. */
            _.Move(W.WDATA.WDATA_AA, W.LC09.LC09_DTAVISO.LC09_AA_AVISO);

            /*" -1914- MOVE V1MEST-NUM-APOL TO LC11-APOLICE */
            _.Move(V1MEST_NUM_APOL, W.LC11.LC11_APOLICE);

            /*" -1915- MOVE V1MEST-NRCERTIF TO LC11-ITEM */
            _.Move(V1MEST_NRCERTIF, W.LC11.LC11_ITEM);

            /*" -1916- MOVE V1MEST-VALSEGBT TO LC11-ISITEM */
            _.Move(V1MEST_VALSEGBT, W.LC11.LC11_ISITEM);

            /*" -1917- MOVE V1MEST-NUMIRB TO LC13-SINIRB */
            _.Move(V1MEST_NUMIRB, W.LC13.LC13_SINIRB);

            /*" -1918- MOVE SPACES TO LC13-TITULO. */
            _.Move("", W.LC12.LC13_TITULO);

            /*" -1920- MOVE SPACES TO LC13-LIMCRR. */
            _.Move("", W.LC13.LC13_LIMCRR);

            /*" -1921- IF GEOPERAC-FUNCAO-OPERACAO EQUAL 'IND' OR 'APAG' OR 'JBIND' */

            if (GEOPERAC_FUNCAO_OPERACAO.In("IND", "APAG", "JBIND"))
            {

                /*" -1922- MOVE 'DATA PAGAMENTO' TO LC13-TITULO */
                _.Move("DATA PAGAMENTO", W.LC12.LC13_TITULO);

                /*" -1923- MOVE V1HIST-LIMCRR TO WDT-PGTO */
                _.Move(V1HIST_LIMCRR, W.WDT_PGTO);

                /*" -1924- MOVE WDT-AA TO LC13-AALIMCRR */
                _.Move(W.WDT_PGTO.WDT_AA, W.LC13.LC13_LIMCRR.LC13_AALIMCRR);

                /*" -1925- MOVE '/' TO LC13-BARRA1 */
                _.Move("/", W.LC13.LC13_LIMCRR.LC13_BARRA1);

                /*" -1926- MOVE WDT-MM TO LC13-MMLIMCRR */
                _.Move(W.WDT_PGTO.WDT_MM, W.LC13.LC13_LIMCRR.LC13_MMLIMCRR);

                /*" -1927- MOVE '/' TO LC13-BARRA2 */
                _.Move("/", W.LC13.LC13_LIMCRR.LC13_BARRA2);

                /*" -1928- MOVE WDT-DD TO LC13-DDLIMCRR */
                _.Move(W.WDT_PGTO.WDT_DD, W.LC13.LC13_LIMCRR.LC13_DDLIMCRR);

                /*" -1930- END-IF. */
            }


            /*" -1932- MOVE CH-CHAVE-ATU TO CH-CHAVE-ANT */
            _.Move(W.CH_CHAVE_ATU, W.CH_CHAVE_ANT);

            /*" -1933- PERFORM 130-000-TRATA-SINISTRO UNTIL CH-CHAVE-ATU NOT EQUAL CH-CHAVE-ANT. */

            while (!(W.CH_CHAVE_ATU != W.CH_CHAVE_ANT))
            {

                M_130_000_TRATA_SINISTRO_SECTION();
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_120_999_EXIT*/

        [StopWatch]
        /*" M-130-000-TRATA-SINISTRO-SECTION */
        private void M_130_000_TRATA_SINISTRO_SECTION()
        {
            /*" -1944- MOVE '006' TO WNR-EXEC-SQL */
            _.Move("006", W.WABEND.WNR_EXEC_SQL);

            /*" -1945- MOVE V1MEST-APOL-SINI TO WS-NUM-APOL-SINISTRO */
            _.Move(V1MEST_APOL_SINI, WS_NUM_APOL_SINISTRO);

            /*" -1947- MOVE WS-NUM-APOL-SINISTRO TO WS-SINISTRO-SMART */
            _.Move(WS_NUM_APOL_SINISTRO, WS_SINISTRO_SMART);

            /*" -1949- PERFORM 240-000-LER-V1APOLICE */

            M_240_000_LER_V1APOLICE_SECTION();

            /*" -1950- IF WS-FONTE-SINISTRO = 140 */

            if (WS_SINISTRO_SMART.WS_FONTE_SINISTRO == 140)
            {

                /*" -1951- PERFORM 271-000-LER-ENDOSSO-SMART */

                M_271_000_LER_ENDOSSO_SMART_SECTION();

                /*" -1952- ELSE */
            }
            else
            {


                /*" -1953- PERFORM 270-000-LER-V1ENDOSSO */

                M_270_000_LER_V1ENDOSSO_SECTION();

                /*" -1955- END-IF */
            }


            /*" -1956- MOVE V1HIST-NOMFAV TO LC13-NOMFAV. */
            _.Move(V1HIST_NOMFAV, W.LC13.LC13_NOMFAV);

            /*" -1958- MOVE WS-RAMO-SINI TO V1RAMO-RAMO */
            _.Move(W.FILLER_356.WS_RAMO_SINI, V1RAMO_RAMO);

            /*" -1960- PERFORM 300-000-LER-V1RAMO */

            M_300_000_LER_V1RAMO_SECTION();

            /*" -1961- IF WS-RAMO-SINI EQUAL 93 OR 97 */

            if (W.FILLER_356.WS_RAMO_SINI.In("93", "97"))
            {

                /*" -1962- PERFORM 570-000-LER-V1SEGURAVG */

                M_570_000_LER_V1SEGURAVG_SECTION();

                /*" -1964- END-IF. */
            }


            /*" -1965- MOVE AT-SINISTRO-MOV TO AN-SINISTRO-MOV. */
            _.Move(W.AT_SINISTRO_MOV, W.AN_SINISTRO_MOV);

            /*" -1966- MOVE V1MEST-APOL-SINI TO WS-SINISTRO. */
            _.Move(V1MEST_APOL_SINI, W.AT_SINISTRO_MOV.WS_SINISTRO);

            /*" -1967- MOVE V1HIST-OPERACAO TO WS-OPERACAO. */
            _.Move(V1HIST_OPERACAO, W.AT_SINISTRO_MOV.WS_OPERACAO);

            /*" -1969- MOVE V1HIST-DTMOVTO TO WS-DATA-MOVTO. */
            _.Move(V1HIST_DTMOVTO, W.AT_SINISTRO_MOV.WS_DATA_MOVTO);

            /*" -1974- IF (GEOPERAC-FUNCAO-OPERACAO EQUAL 'DPAG' OR 'HPAG' OR 'JBDESP' OR 'JBHON' ) AND (AT-SINISTRO-MOV NOT EQUAL AN-SINISTRO-MOV) */

            if ((GEOPERAC_FUNCAO_OPERACAO.In("DPAG", "HPAG", "JBDESP", "JBHON")) && (W.AT_SINISTRO_MOV != W.AN_SINISTRO_MOV))
            {

                /*" -1975- PERFORM 140-000-SUMARIZA-OPERACAO */

                M_140_000_SUMARIZA_OPERACAO_SECTION();

                /*" -1985- END-IF. */
            }


            /*" -1986- MOVE SPACES TO WFIM-V1APOLCOSCED */
            _.Move("", W.WFIM_V1APOLCOSCED);

            /*" -1987- MOVE V1MEST-APOL-SINI TO WS-NUM-APOL-SINISTRO */
            _.Move(V1MEST_APOL_SINI, WS_NUM_APOL_SINISTRO);

            /*" -1989- MOVE WS-NUM-APOL-SINISTRO TO WS-SINISTRO-SMART */
            _.Move(WS_NUM_APOL_SINISTRO, WS_SINISTRO_SMART);

            /*" -1990- IF WS-FONTE-SINISTRO = 140 */

            if (WS_SINISTRO_SMART.WS_FONTE_SINISTRO == 140)
            {

                /*" -1991- PERFORM 360-100-CUR-V1APOLCOSCED-SMART */

                M_360_100_CUR_V1APOLCOSCED_SMART_SECTION();

                /*" -1992- PERFORM 370-100-LER-V1APOLCOSCED-SMART */

                M_370_100_LER_V1APOLCOSCED_SMART_SECTION();

                /*" -1993- ELSE */
            }
            else
            {


                /*" -1994- PERFORM 360-000-CURSOR-V1APOLCOSCED */

                M_360_000_CURSOR_V1APOLCOSCED_SECTION();

                /*" -1995- PERFORM 370-000-LER-V1APOLCOSCED */

                M_370_000_LER_V1APOLCOSCED_SECTION();

                /*" -1997- END-IF */
            }


            /*" -1998- PERFORM 400-000-PROCESSA-COSSEGURO UNTIL WFIM-V1APOLCOSCED NOT EQUAL SPACES. */

            while (!(!W.WFIM_V1APOLCOSCED.IsEmpty()))
            {

                M_400_000_PROCESSA_COSSEGURO_SECTION();
            }

            /*" -0- FLUXCONTROL_PERFORM M_130_010_LEITURA */

            M_130_010_LEITURA();

        }

        [StopWatch]
        /*" M-130-010-LEITURA */
        private void M_130_010_LEITURA(bool isPerform = false)
        {
            /*" -2004- PERFORM 100-000-LER-V1HISTSINI. */

            M_100_000_LER_V1HISTSINI_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_130_999_EXIT*/

        [StopWatch]
        /*" M-140-000-SUMARIZA-OPERACAO-SECTION */
        private void M_140_000_SUMARIZA_OPERACAO_SECTION()
        {
            /*" -2015- MOVE '007' TO WNR-EXEC-SQL */
            _.Move("007", W.WABEND.WNR_EXEC_SQL);

            /*" -2022- PERFORM M_140_000_SUMARIZA_OPERACAO_DB_SELECT_1 */

            M_140_000_SUMARIZA_OPERACAO_DB_SELECT_1();

            /*" -2025- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2026- DISPLAY 'SI0021B - ERRO NO SUM DA V1HISTSINI .......... ' */
                _.Display($"SI0021B - ERRO NO SUM DA V1HISTSINI .......... ");

                /*" -2027- DISPLAY 'SINISTRO ... ' V1MEST-APOL-SINI */
                _.Display($"SINISTRO ... {V1MEST_APOL_SINI}");

                /*" -2028- DISPLAY 'OPERACAO ... ' V1HIST-OPERACAO */
                _.Display($"OPERACAO ... {V1HIST_OPERACAO}");

                /*" -2028- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-140-000-SUMARIZA-OPERACAO-DB-SELECT-1 */
        public void M_140_000_SUMARIZA_OPERACAO_DB_SELECT_1()
        {
            /*" -2022- EXEC SQL SELECT VALUE(SUM(VAL_OPERACAO), 0) INTO :CA-VALOR-TOTAL FROM SEGUROS.V1HISTSINI WHERE DTMOVTO = :V1HIST-DTMOVTO AND NUM_APOL_SINISTRO = :V1MEST-APOL-SINI AND OPERACAO = :V1HIST-OPERACAO END-EXEC. */

            var m_140_000_SUMARIZA_OPERACAO_DB_SELECT_1_Query1 = new M_140_000_SUMARIZA_OPERACAO_DB_SELECT_1_Query1()
            {
                V1MEST_APOL_SINI = V1MEST_APOL_SINI.ToString(),
                V1HIST_OPERACAO = V1HIST_OPERACAO.ToString(),
                V1HIST_DTMOVTO = V1HIST_DTMOVTO.ToString(),
            };

            var executed_1 = M_140_000_SUMARIZA_OPERACAO_DB_SELECT_1_Query1.Execute(m_140_000_SUMARIZA_OPERACAO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CA_VALOR_TOTAL, CA_VALOR_TOTAL);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_140_999_EXIT*/

        [StopWatch]
        /*" M-160-000-LER-V1CONGENERE-SECTION */
        private void M_160_000_LER_V1CONGENERE_SECTION()
        {
            /*" -2039- MOVE '160' TO WNR-EXEC-SQL */
            _.Move("160", W.WABEND.WNR_EXEC_SQL);

            /*" -2045- PERFORM M_160_000_LER_V1CONGENERE_DB_SELECT_1 */

            M_160_000_LER_V1CONGENERE_DB_SELECT_1();

            /*" -2049- IF (SQLCODE NOT EQUAL ZEROS) AND (SQLCODE NOT EQUAL 100) */

            if ((DB.SQLCODE != 00) && (DB.SQLCODE != 100))
            {

                /*" -2050- DISPLAY 'SI0021B - ERRO NO SELECT DA V1CONGENERE ...... ' */
                _.Display($"SI0021B - ERRO NO SELECT DA V1CONGENERE ...... ");

                /*" -2052- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2053- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -2054- MOVE SPACES TO LC05-NOMECONG */
                _.Move("", W.LC05.LC05_NOMECONG);

                /*" -2055- ELSE */
            }
            else
            {


                /*" -2055- MOVE V1CONGE-NOMECONG TO LC05-NOMECONG. */
                _.Move(V1CONGE_NOMECONG, W.LC05.LC05_NOMECONG);
            }


        }

        [StopWatch]
        /*" M-160-000-LER-V1CONGENERE-DB-SELECT-1 */
        public void M_160_000_LER_V1CONGENERE_DB_SELECT_1()
        {
            /*" -2045- EXEC SQL SELECT NOMECONG INTO :V1CONGE-NOMECONG FROM SEGUROS.V1CONGENERE WHERE CONGENER = :V1APCO-CODCOSS WITH UR END-EXEC. */

            var m_160_000_LER_V1CONGENERE_DB_SELECT_1_Query1 = new M_160_000_LER_V1CONGENERE_DB_SELECT_1_Query1()
            {
                V1APCO_CODCOSS = V1APCO_CODCOSS.ToString(),
            };

            var executed_1 = M_160_000_LER_V1CONGENERE_DB_SELECT_1_Query1.Execute(m_160_000_LER_V1CONGENERE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1CONGE_NOMECONG, V1CONGE_NOMECONG);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_160_999_EXIT*/

        [StopWatch]
        /*" M-240-000-LER-V1APOLICE-SECTION */
        private void M_240_000_LER_V1APOLICE_SECTION()
        {
            /*" -2067- MOVE '009' TO WNR-EXEC-SQL. */
            _.Move("009", W.WABEND.WNR_EXEC_SQL);

            /*" -2078- PERFORM M_240_000_LER_V1APOLICE_DB_SELECT_1 */

            M_240_000_LER_V1APOLICE_DB_SELECT_1();

            /*" -2081- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2083- DISPLAY 'SI0021B - ERRO NO SELECT V1APOLICE ........... ' ' ' V1MEST-NUM-APOL */

                $"SI0021B - ERRO NO SELECT V1APOLICE ...........  {V1MEST_NUM_APOL}"
                .Display();

                /*" -2085- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2086- IF WS-RAMO-SINI NOT EQUAL 93 OR 97 */

            if (!W.FILLER_356.WS_RAMO_SINI.In("93", "97"))
            {

                /*" -2086- MOVE V1APOL-NOME TO LC09-NOME. */
                _.Move(V1APOL_NOME, W.LC09.LC09_NOME);
            }


        }

        [StopWatch]
        /*" M-240-000-LER-V1APOLICE-DB-SELECT-1 */
        public void M_240_000_LER_V1APOLICE_DB_SELECT_1()
        {
            /*" -2078- EXEC SQL SELECT NOME, MODALIDA, CODCLIEN, PODPUBL INTO :V1APOL-NOME, :V1APOL-MODALIDA, :V1APOL-CODCLIEN, :V1APOL-PODPUBL FROM SEGUROS.V1APOLICE WHERE NUM_APOLICE = :V1MEST-NUM-APOL END-EXEC. */

            var m_240_000_LER_V1APOLICE_DB_SELECT_1_Query1 = new M_240_000_LER_V1APOLICE_DB_SELECT_1_Query1()
            {
                V1MEST_NUM_APOL = V1MEST_NUM_APOL.ToString(),
            };

            var executed_1 = M_240_000_LER_V1APOLICE_DB_SELECT_1_Query1.Execute(m_240_000_LER_V1APOLICE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1APOL_NOME, V1APOL_NOME);
                _.Move(executed_1.V1APOL_MODALIDA, V1APOL_MODALIDA);
                _.Move(executed_1.V1APOL_CODCLIEN, V1APOL_CODCLIEN);
                _.Move(executed_1.V1APOL_PODPUBL, V1APOL_PODPUBL);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_240_999_EXIT*/

        [StopWatch]
        /*" M-270-000-LER-V1ENDOSSO-SECTION */
        private void M_270_000_LER_V1ENDOSSO_SECTION()
        {
            /*" -2095- MOVE '010' TO WNR-EXEC-SQL. */
            _.Move("010", W.WABEND.WNR_EXEC_SQL);

            /*" -2105- PERFORM M_270_000_LER_V1ENDOSSO_DB_SELECT_1 */

            M_270_000_LER_V1ENDOSSO_DB_SELECT_1();

            /*" -2108- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2111- DISPLAY 'SI0021B - ERRO NO ACESSO DA V1ENDOSSO ..........' ' ' V1MEST-NUM-APOL ' ' V1MEST-NRENDOS */

                $"SI0021B - ERRO NO ACESSO DA V1ENDOSSO .......... {V1MEST_NUM_APOL} {V1MEST_NRENDOS}"
                .Display();

                /*" -2113- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2114- MOVE V1ENDO-DTINIVIG TO WDATA-R */
            _.Move(V1ENDO_DTINIVIG, W.WDATA_R);

            /*" -2115- MOVE WDATA-AA TO LC11-AA-I */
            _.Move(W.WDATA.WDATA_AA, W.LC11.LC11_DTINIVIG.LC11_AA_I);

            /*" -2116- MOVE WDATA-MM TO LC11-MM-I */
            _.Move(W.WDATA.WDATA_MM, W.LC11.LC11_DTINIVIG.LC11_MM_I);

            /*" -2118- MOVE WDATA-DD TO LC11-DD-I */
            _.Move(W.WDATA.WDATA_DD, W.LC11.LC11_DTINIVIG.LC11_DD_I);

            /*" -2120- IF WS-RAMO-SINI EQUAL 93 OR 97 OR 21 OR 22 */

            if (W.FILLER_356.WS_RAMO_SINI.In("93", "97", "21", "22"))
            {

                /*" -2123- MOVE ZEROS TO LC11-AA-T LC11-MM-T LC11-DD-T */
                _.Move(0, W.LC11.LC11_DTTERVIG.LC11_AA_T, W.LC11.LC11_DTTERVIG.LC11_MM_T, W.LC11.LC11_DTTERVIG.LC11_DD_T);

                /*" -2124- ELSE */
            }
            else
            {


                /*" -2125- MOVE V1ENDO-DTTERVIG TO WDATA-R */
                _.Move(V1ENDO_DTTERVIG, W.WDATA_R);

                /*" -2126- MOVE WDATA-AA TO LC11-AA-T */
                _.Move(W.WDATA.WDATA_AA, W.LC11.LC11_DTTERVIG.LC11_AA_T);

                /*" -2127- MOVE WDATA-MM TO LC11-MM-T */
                _.Move(W.WDATA.WDATA_MM, W.LC11.LC11_DTTERVIG.LC11_MM_T);

                /*" -2127- MOVE WDATA-DD TO LC11-DD-T. */
                _.Move(W.WDATA.WDATA_DD, W.LC11.LC11_DTTERVIG.LC11_DD_T);
            }


        }

        [StopWatch]
        /*" M-270-000-LER-V1ENDOSSO-DB-SELECT-1 */
        public void M_270_000_LER_V1ENDOSSO_DB_SELECT_1()
        {
            /*" -2105- EXEC SQL SELECT DTINIVIG, DTTERVIG, CORRECAO INTO :V1ENDO-DTINIVIG, :V1ENDO-DTTERVIG, :V1ENDO-CORRECAO FROM SEGUROS.V1ENDOSSO WHERE NUM_APOLICE = :V1MEST-NUM-APOL AND NRENDOS = :V1MEST-NRENDOS END-EXEC. */

            var m_270_000_LER_V1ENDOSSO_DB_SELECT_1_Query1 = new M_270_000_LER_V1ENDOSSO_DB_SELECT_1_Query1()
            {
                V1MEST_NUM_APOL = V1MEST_NUM_APOL.ToString(),
                V1MEST_NRENDOS = V1MEST_NRENDOS.ToString(),
            };

            var executed_1 = M_270_000_LER_V1ENDOSSO_DB_SELECT_1_Query1.Execute(m_270_000_LER_V1ENDOSSO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1ENDO_DTINIVIG, V1ENDO_DTINIVIG);
                _.Move(executed_1.V1ENDO_DTTERVIG, V1ENDO_DTTERVIG);
                _.Move(executed_1.V1ENDO_CORRECAO, V1ENDO_CORRECAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_270_999_EXIT*/

        [StopWatch]
        /*" M-271-000-LER-ENDOSSO-SMART-SECTION */
        private void M_271_000_LER_ENDOSSO_SMART_SECTION()
        {
            /*" -2134- MOVE '116' TO WNR-EXEC-SQL. */
            _.Move("116", W.WABEND.WNR_EXEC_SQL);

            /*" -2147- PERFORM M_271_000_LER_ENDOSSO_SMART_DB_SELECT_1 */

            M_271_000_LER_ENDOSSO_SMART_DB_SELECT_1();

            /*" -2150- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2151- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WS_SQLCODE);

                /*" -2152- DISPLAY 'SI0021B - ERRO NO ACESSO DA SX_EM_ENDOSSO ' */
                _.Display($"SI0021B - ERRO NO ACESSO DA SX_EM_ENDOSSO ");

                /*" -2153- DISPLAY 'SQLCODE           = ' WS-SQLCODE */
                _.Display($"SQLCODE           = {WS_SQLCODE}");

                /*" -2154- DISPLAY 'SX010.NUM_APOLICE = ' V1MEST-NUM-APOL */
                _.Display($"SX010.NUM_APOLICE = {V1MEST_NUM_APOL}");

                /*" -2155- DISPLAY 'SX051.NUM_ENDOSSO = ' V1MEST-NRENDOS */
                _.Display($"SX051.NUM_ENDOSSO = {V1MEST_NRENDOS}");

                /*" -2156- DISPLAY '------------------------------------------' */
                _.Display($"------------------------------------------");

                /*" -2158- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2159- MOVE V1ENDO-DTINIVIG TO WDATA-R */
            _.Move(V1ENDO_DTINIVIG, W.WDATA_R);

            /*" -2160- MOVE WDATA-AA TO LC11-AA-I */
            _.Move(W.WDATA.WDATA_AA, W.LC11.LC11_DTINIVIG.LC11_AA_I);

            /*" -2161- MOVE WDATA-MM TO LC11-MM-I */
            _.Move(W.WDATA.WDATA_MM, W.LC11.LC11_DTINIVIG.LC11_MM_I);

            /*" -2163- MOVE WDATA-DD TO LC11-DD-I */
            _.Move(W.WDATA.WDATA_DD, W.LC11.LC11_DTINIVIG.LC11_DD_I);

            /*" -2165- IF WS-RAMO-SINI EQUAL 93 OR 97 OR 21 OR 22 */

            if (W.FILLER_356.WS_RAMO_SINI.In("93", "97", "21", "22"))
            {

                /*" -2168- MOVE ZEROS TO LC11-AA-T LC11-MM-T LC11-DD-T */
                _.Move(0, W.LC11.LC11_DTTERVIG.LC11_AA_T, W.LC11.LC11_DTTERVIG.LC11_MM_T, W.LC11.LC11_DTTERVIG.LC11_DD_T);

                /*" -2169- ELSE */
            }
            else
            {


                /*" -2170- MOVE V1ENDO-DTTERVIG TO WDATA-R */
                _.Move(V1ENDO_DTTERVIG, W.WDATA_R);

                /*" -2171- MOVE WDATA-AA TO LC11-AA-T */
                _.Move(W.WDATA.WDATA_AA, W.LC11.LC11_DTTERVIG.LC11_AA_T);

                /*" -2172- MOVE WDATA-MM TO LC11-MM-T */
                _.Move(W.WDATA.WDATA_MM, W.LC11.LC11_DTTERVIG.LC11_MM_T);

                /*" -2172- MOVE WDATA-DD TO LC11-DD-T. */
                _.Move(W.WDATA.WDATA_DD, W.LC11.LC11_DTTERVIG.LC11_DD_T);
            }


        }

        [StopWatch]
        /*" M-271-000-LER-ENDOSSO-SMART-DB-SELECT-1 */
        public void M_271_000_LER_ENDOSSO_SMART_DB_SELECT_1()
        {
            /*" -2147- EXEC SQL SELECT DTA_INIVIG_ENDOSSO, DTA_FIMVIG_ENDOSSO INTO :V1ENDO-DTINIVIG, :V1ENDO-DTTERVIG FROM SEGUROS.SX_EM_ENDOSSO SX051, SEGUROS.SX_APOLICE SX010 WHERE SX010.NUM_APOLICE = :V1MEST-NUM-APOL AND SX010.SEQ_PROP_APOL = SX051.SEQ_APOLICE AND (SX051.NUM_ENDOSSO = :V1MEST-NRENDOS OR SX051.NUM_ENDOSSO = 0) ORDER BY SX051.NUM_ENDOSSO DESC FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var m_271_000_LER_ENDOSSO_SMART_DB_SELECT_1_Query1 = new M_271_000_LER_ENDOSSO_SMART_DB_SELECT_1_Query1()
            {
                V1MEST_NUM_APOL = V1MEST_NUM_APOL.ToString(),
                V1MEST_NRENDOS = V1MEST_NRENDOS.ToString(),
            };

            var executed_1 = M_271_000_LER_ENDOSSO_SMART_DB_SELECT_1_Query1.Execute(m_271_000_LER_ENDOSSO_SMART_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1ENDO_DTINIVIG, V1ENDO_DTINIVIG);
                _.Move(executed_1.V1ENDO_DTTERVIG, V1ENDO_DTTERVIG);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_271_999_EXIT*/

        [StopWatch]
        /*" M-300-000-LER-V1RAMO-SECTION */
        private void M_300_000_LER_V1RAMO_SECTION()
        {
            /*" -2181- MOVE '011' TO WNR-EXEC-SQL. */
            _.Move("011", W.WABEND.WNR_EXEC_SQL);

            /*" -2187- PERFORM M_300_000_LER_V1RAMO_DB_SELECT_1 */

            M_300_000_LER_V1RAMO_DB_SELECT_1();

            /*" -2193- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -2194- MOVE SPACES TO LC09-NOMERAMO */
                _.Move("", W.LC09.LC09_NOMERAMO);

                /*" -2196- GO TO 300-999-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_300_999_EXIT*/ //GOTO
                return;
            }


            /*" -2198- IF (SQLCODE NOT EQUAL ZEROS) AND (SQLCODE NOT EQUAL 100) */

            if ((DB.SQLCODE != 00) && (DB.SQLCODE != 100))
            {

                /*" -2199- DISPLAY 'SI0021B - ERRO NO SELECT V1RAMO .......' */
                _.Display($"SI0021B - ERRO NO SELECT V1RAMO .......");

                /*" -2201- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2201- MOVE V1RAMO-NOMERAMO TO LC09-NOMERAMO. */
            _.Move(V1RAMO_NOMERAMO, W.LC09.LC09_NOMERAMO);

        }

        [StopWatch]
        /*" M-300-000-LER-V1RAMO-DB-SELECT-1 */
        public void M_300_000_LER_V1RAMO_DB_SELECT_1()
        {
            /*" -2187- EXEC SQL SELECT NOMERAMO INTO :V1RAMO-NOMERAMO FROM SEGUROS.V1RAMO WHERE RAMO = :V1RAMO-RAMO AND MODALIDA = :V1APOL-MODALIDA END-EXEC. */

            var m_300_000_LER_V1RAMO_DB_SELECT_1_Query1 = new M_300_000_LER_V1RAMO_DB_SELECT_1_Query1()
            {
                V1APOL_MODALIDA = V1APOL_MODALIDA.ToString(),
                V1RAMO_RAMO = V1RAMO_RAMO.ToString(),
            };

            var executed_1 = M_300_000_LER_V1RAMO_DB_SELECT_1_Query1.Execute(m_300_000_LER_V1RAMO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1RAMO_NOMERAMO, V1RAMO_NOMERAMO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_300_999_EXIT*/

        [StopWatch]
        /*" M-330-000-LER-V1ORDECOSCED-SECTION */
        private void M_330_000_LER_V1ORDECOSCED_SECTION()
        {
            /*" -2212- MOVE '012' TO WNR-EXEC-SQL. */
            _.Move("012", W.WABEND.WNR_EXEC_SQL);

            /*" -2219- PERFORM M_330_000_LER_V1ORDECOSCED_DB_SELECT_1 */

            M_330_000_LER_V1ORDECOSCED_DB_SELECT_1();

            /*" -2222- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -2223- MOVE ZEROS TO LC11-NRORDEM */
                _.Move(0, W.LC11.LC11_NRORDEM);

                /*" -2225- GO TO 330-999-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_330_999_EXIT*/ //GOTO
                return;
            }


            /*" -2227- IF (SQLCODE NOT EQUAL ZEROS) AND (SQLCODE NOT EQUAL 100) */

            if ((DB.SQLCODE != 00) && (DB.SQLCODE != 100))
            {

                /*" -2228- DISPLAY 'SI0021B - ERRO NO SELECT V1ORDECOSCED ........ ' */
                _.Display($"SI0021B - ERRO NO SELECT V1ORDECOSCED ........ ");

                /*" -2230- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2230- MOVE V1ORDE-NRORDEM TO LC11-NRORDEM. */
            _.Move(V1ORDE_NRORDEM, W.LC11.LC11_NRORDEM);

        }

        [StopWatch]
        /*" M-330-000-LER-V1ORDECOSCED-DB-SELECT-1 */
        public void M_330_000_LER_V1ORDECOSCED_DB_SELECT_1()
        {
            /*" -2219- EXEC SQL SELECT ORDEM_CEDIDO INTO :V1ORDE-NRORDEM FROM SEGUROS.V1ORDECOSCED WHERE NUM_APOLICE = :V1MEST-NUM-APOL AND NRENDOS = :V1MEST-NRENDOS AND CODCOSS = :V1APCO-CODCOSS END-EXEC. */

            var m_330_000_LER_V1ORDECOSCED_DB_SELECT_1_Query1 = new M_330_000_LER_V1ORDECOSCED_DB_SELECT_1_Query1()
            {
                V1MEST_NUM_APOL = V1MEST_NUM_APOL.ToString(),
                V1MEST_NRENDOS = V1MEST_NRENDOS.ToString(),
                V1APCO_CODCOSS = V1APCO_CODCOSS.ToString(),
            };

            var executed_1 = M_330_000_LER_V1ORDECOSCED_DB_SELECT_1_Query1.Execute(m_330_000_LER_V1ORDECOSCED_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1ORDE_NRORDEM, V1ORDE_NRORDEM);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_330_999_EXIT*/

        [StopWatch]
        /*" M-360-000-CURSOR-V1APOLCOSCED-SECTION */
        private void M_360_000_CURSOR_V1APOLCOSCED_SECTION()
        {
            /*" -2241- MOVE '013' TO WNR-EXEC-SQL. */
            _.Move("013", W.WABEND.WNR_EXEC_SQL);

            /*" -2242- IF RELATORI-COD-CONGENERE = 9999 */

            if (RELATORI.DCLRELATORIOS.RELATORI_COD_CONGENERE == 9999)
            {

                /*" -2243- MOVE 0 TO WS-CONG-INICIAL */
                _.Move(0, WS_CONG_INICIAL);

                /*" -2244- MOVE 9999 TO WS-CONG-FINAL */
                _.Move(9999, WS_CONG_FINAL);

                /*" -2245- ELSE */
            }
            else
            {


                /*" -2247- MOVE RELATORI-COD-CONGENERE TO WS-CONG-INICIAL WS-CONG-FINAL */
                _.Move(RELATORI.DCLRELATORIOS.RELATORI_COD_CONGENERE, WS_CONG_INICIAL, WS_CONG_FINAL);

                /*" -2254- END-IF */
            }


            /*" -2265- PERFORM M_360_000_CURSOR_V1APOLCOSCED_DB_DECLARE_1 */

            M_360_000_CURSOR_V1APOLCOSCED_DB_DECLARE_1();

            /*" -2268- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -2269- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WS_SQLCODE);

                /*" -2270- DISPLAY 'SI0021B - ERRO DECLARE V1APOLCOSCED .......... ' */
                _.Display($"SI0021B - ERRO DECLARE V1APOLCOSCED .......... ");

                /*" -2271- DISPLAY 'SQLCODE           = ' WS-SQLCODE */
                _.Display($"SQLCODE           = {WS_SQLCODE}");

                /*" -2272- DISPLAY 'NUM_APOLICE       = ' V1MEST-NUM-APOL */
                _.Display($"NUM_APOLICE       = {V1MEST_NUM_APOL}");

                /*" -2273- DISPLAY 'V1MEST-DATORR     = ' V1MEST-DATORR */
                _.Display($"V1MEST-DATORR     = {V1MEST_DATORR}");

                /*" -2274- DISPLAY 'NUM-APOL-SISNITRO = ' V1MEST-APOL-SINI */
                _.Display($"NUM-APOL-SISNITRO = {V1MEST_APOL_SINI}");

                /*" -2275- DISPLAY '-----------------------------------------------' */
                _.Display($"-----------------------------------------------");

                /*" -2277- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2279- MOVE '014' TO WNR-EXEC-SQL. */
            _.Move("014", W.WABEND.WNR_EXEC_SQL);

            /*" -2279- PERFORM M_360_000_CURSOR_V1APOLCOSCED_DB_OPEN_1 */

            M_360_000_CURSOR_V1APOLCOSCED_DB_OPEN_1();

            /*" -2282- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -2283- DISPLAY 'SI0021B - ERRO OPEN V1APOLCOSCED .......... ' */
                _.Display($"SI0021B - ERRO OPEN V1APOLCOSCED .......... ");

                /*" -2283- GO TO R10010199-MENSAGEM-LOCK. */

                R10010199_MENSAGEM_LOCK(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-360-000-CURSOR-V1APOLCOSCED-DB-OPEN-1 */
        public void M_360_000_CURSOR_V1APOLCOSCED_DB_OPEN_1()
        {
            /*" -2279- EXEC SQL OPEN V1APOLCOSCED END-EXEC. */

            V1APOLCOSCED.Open();

        }

        [StopWatch]
        /*" M-360-100-CUR-V1APOLCOSCED-SMART-DB-DECLARE-1 */
        public void M_360_100_CUR_V1APOLCOSCED_SMART_DB_DECLARE_1()
        {
            /*" -2342- EXEC SQL DECLARE SX_APOLCOSG CURSOR FOR SELECT VALUE (A.NUM_APOLICE,+0), B.COD_CONGENERE, B.PCT_PARTICIPACAO FROM SEGUROS.SX_APOLICE A, SEGUROS.SX_APOL_COSSEGURO B WHERE A.NUM_APOLICE = :V1MEST-NUM-APOL AND A.STA_APOLICE = 'A' AND B.SEQ_APOLICE = A.SEQ_PROP_APOL AND B.IND_LIDER = 'N' AND B.PCT_PARTICIPACAO >= 0 AND (:V1MEST-DATORR BETWEEN B.DTA_INI_VIGENCIA AND VALUE(B.DTA_FIM_VIGENCIA,DATE( '9999-12-31' ))) ORDER BY B.COD_CONGENERE END-EXEC. */
            SX_APOLCOSG = new SI0021B_SX_APOLCOSG(true);
            string GetQuery_SX_APOLCOSG()
            {
                var query = @$"SELECT 
							VALUE (A.NUM_APOLICE
							,+0)
							, 
							B.COD_CONGENERE
							, 
							B.PCT_PARTICIPACAO 
							FROM SEGUROS.SX_APOLICE A
							, 
							SEGUROS.SX_APOL_COSSEGURO B 
							WHERE A.NUM_APOLICE = '{V1MEST_NUM_APOL}' 
							AND A.STA_APOLICE = 'A' 
							AND B.SEQ_APOLICE = A.SEQ_PROP_APOL 
							AND B.IND_LIDER = 'N' 
							AND B.PCT_PARTICIPACAO >= 0 
							AND ('{V1MEST_DATORR}' BETWEEN B.DTA_INI_VIGENCIA 
							AND VALUE(B.DTA_FIM_VIGENCIA
							,DATE( '9999-12-31' ))) 
							ORDER BY 
							B.COD_CONGENERE";

                return query;
            }
            SX_APOLCOSG.GetQueryEvent += GetQuery_SX_APOLCOSG;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_360_999_EXIT*/

        [StopWatch]
        /*" M-370-000-LER-V1APOLCOSCED-SECTION */
        private void M_370_000_LER_V1APOLCOSCED_SECTION()
        {
            /*" -2294- MOVE '015' TO WNR-EXEC-SQL. */
            _.Move("015", W.WABEND.WNR_EXEC_SQL);

            /*" -2297- PERFORM M_370_000_LER_V1APOLCOSCED_DB_FETCH_1 */

            M_370_000_LER_V1APOLCOSCED_DB_FETCH_1();

            /*" -2300- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -2301- MOVE 'S' TO WFIM-V1APOLCOSCED */
                _.Move("S", W.WFIM_V1APOLCOSCED);

                /*" -2301- PERFORM M_370_000_LER_V1APOLCOSCED_DB_CLOSE_1 */

                M_370_000_LER_V1APOLCOSCED_DB_CLOSE_1();

                /*" -2304- GO TO 370-999-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_370_999_EXIT*/ //GOTO
                return;
            }


            /*" -2306- IF (SQLCODE NOT EQUAL ZEROS) AND (SQLCODE NOT EQUAL 100) */

            if ((DB.SQLCODE != 00) && (DB.SQLCODE != 100))
            {

                /*" -2307- DISPLAY 'SI0021B - ERRO FETCH V1APOLCOSCED .......... ' */
                _.Display($"SI0021B - ERRO FETCH V1APOLCOSCED .......... ");

                /*" -2312- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2313- MOVE V1APCO-CODCOSS TO LC05-CODCOSS */
            _.Move(V1APCO_CODCOSS, W.LC05.LC05_CODCOSS);

            /*" -2315- MOVE V1APCO-PCPARTIC TO LC09-PCPARTIC */
            _.Move(V1APCO_PCPARTIC, W.LC09.LC09_PCPARTIC);

            /*" -2315- PERFORM 380-000-LER-V1MOEDA. */

            M_380_000_LER_V1MOEDA_SECTION();

        }

        [StopWatch]
        /*" M-370-000-LER-V1APOLCOSCED-DB-FETCH-1 */
        public void M_370_000_LER_V1APOLCOSCED_DB_FETCH_1()
        {
            /*" -2297- EXEC SQL FETCH V1APOLCOSCED INTO :V1APCO-CODCOSS ,:V1APCO-PCPARTIC END-EXEC. */

            if (V1APOLCOSCED.Fetch())
            {
                _.Move(V1APOLCOSCED.V1APCO_CODCOSS, V1APCO_CODCOSS);
                _.Move(V1APOLCOSCED.V1APCO_PCPARTIC, V1APCO_PCPARTIC);
            }

        }

        [StopWatch]
        /*" M-370-000-LER-V1APOLCOSCED-DB-CLOSE-1 */
        public void M_370_000_LER_V1APOLCOSCED_DB_CLOSE_1()
        {
            /*" -2301- EXEC SQL CLOSE V1APOLCOSCED END-EXEC */

            V1APOLCOSCED.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_370_999_EXIT*/

        [StopWatch]
        /*" M-360-100-CUR-V1APOLCOSCED-SMART-SECTION */
        private void M_360_100_CUR_V1APOLCOSCED_SMART_SECTION()
        {
            /*" -2326- MOVE '113' TO WNR-EXEC-SQL. */
            _.Move("113", W.WABEND.WNR_EXEC_SQL);

            /*" -2342- PERFORM M_360_100_CUR_V1APOLCOSCED_SMART_DB_DECLARE_1 */

            M_360_100_CUR_V1APOLCOSCED_SMART_DB_DECLARE_1();

            /*" -2346- MOVE SQLCODE TO WS-SQLCODE */
            _.Move(DB.SQLCODE, WS_SQLCODE);

            /*" -2347- MOVE '114' TO WNR-EXEC-SQL. */
            _.Move("114", W.WABEND.WNR_EXEC_SQL);

            /*" -2347- PERFORM M_360_100_CUR_V1APOLCOSCED_SMART_DB_OPEN_1 */

            M_360_100_CUR_V1APOLCOSCED_SMART_DB_OPEN_1();

            /*" -2351- MOVE SQLCODE TO WS-SQLCODE */
            _.Move(DB.SQLCODE, WS_SQLCODE);

            /*" -2352- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -2353- DISPLAY 'SI0021B - ERRO OPEN SX_APOLCOSG ' */
                _.Display($"SI0021B - ERRO OPEN SX_APOLCOSG ");

                /*" -2354- DISPLAY 'SQLCODE           = ' WS-SQLCODE */
                _.Display($"SQLCODE           = {WS_SQLCODE}");

                /*" -2355- DISPLAY 'NUM_APOLICE       = ' V1MEST-NUM-APOL */
                _.Display($"NUM_APOLICE       = {V1MEST_NUM_APOL}");

                /*" -2356- DISPLAY 'V1MEST-DATORR     = ' V1MEST-DATORR */
                _.Display($"V1MEST-DATORR     = {V1MEST_DATORR}");

                /*" -2357- DISPLAY 'NUM-APOL-SISNITRO = ' V1MEST-APOL-SINI */
                _.Display($"NUM-APOL-SISNITRO = {V1MEST_APOL_SINI}");

                /*" -2358- DISPLAY '-----------------------------------------------' */
                _.Display($"-----------------------------------------------");

                /*" -2358- GO TO R10010199-MENSAGEM-LOCK. */

                R10010199_MENSAGEM_LOCK(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-360-100-CUR-V1APOLCOSCED-SMART-DB-OPEN-1 */
        public void M_360_100_CUR_V1APOLCOSCED_SMART_DB_OPEN_1()
        {
            /*" -2347- EXEC SQL OPEN SX_APOLCOSG END-EXEC. */

            SX_APOLCOSG.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_360_100_EXIT*/

        [StopWatch]
        /*" M-370-100-LER-V1APOLCOSCED-SMART-SECTION */
        private void M_370_100_LER_V1APOLCOSCED_SMART_SECTION()
        {
            /*" -2364- MOVE '115' TO WNR-EXEC-SQL. */
            _.Move("115", W.WABEND.WNR_EXEC_SQL);

            /*" -2368- PERFORM M_370_100_LER_V1APOLCOSCED_SMART_DB_FETCH_1 */

            M_370_100_LER_V1APOLCOSCED_SMART_DB_FETCH_1();

            /*" -2371- IF SQLCODE = ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -2372- MOVE SX118-COD-CONGENERE TO V1APCO-CODCOSS */
                _.Move(SX118.DCLSX_APOL_COSSEGURO.SX118_COD_CONGENERE, V1APCO_CODCOSS);

                /*" -2373- MOVE SX118-PCT-PARTICIPACAO TO V1APCO-PCPARTIC */
                _.Move(SX118.DCLSX_APOL_COSSEGURO.SX118_PCT_PARTICIPACAO, V1APCO_PCPARTIC);

                /*" -2375- END-IF */
            }


            /*" -2376- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -2377- MOVE 'S' TO WFIM-V1APOLCOSCED */
                _.Move("S", W.WFIM_V1APOLCOSCED);

                /*" -2377- PERFORM M_370_100_LER_V1APOLCOSCED_SMART_DB_CLOSE_1 */

                M_370_100_LER_V1APOLCOSCED_SMART_DB_CLOSE_1();

                /*" -2380- GO TO 370-100-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_370_100_EXIT*/ //GOTO
                return;
            }


            /*" -2382- IF (SQLCODE NOT EQUAL ZEROS) AND (SQLCODE NOT EQUAL 100) */

            if ((DB.SQLCODE != 00) && (DB.SQLCODE != 100))
            {

                /*" -2383- DISPLAY 'SI0021B - ERRO FETCH SX_APOLCOSG  .......... ' */
                _.Display($"SI0021B - ERRO FETCH SX_APOLCOSG  .......... ");

                /*" -2384- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WS_SQLCODE);

                /*" -2385- DISPLAY 'SQLCODE           = ' WS-SQLCODE */
                _.Display($"SQLCODE           = {WS_SQLCODE}");

                /*" -2386- DISPLAY 'NUM_APOLICE       = ' V1MEST-NUM-APOL */
                _.Display($"NUM_APOLICE       = {V1MEST_NUM_APOL}");

                /*" -2387- DISPLAY 'V1MEST-DATORR     = ' V1MEST-DATORR */
                _.Display($"V1MEST-DATORR     = {V1MEST_DATORR}");

                /*" -2388- DISPLAY 'NUM-APOL-SISNITRO = ' V1MEST-APOL-SINI */
                _.Display($"NUM-APOL-SISNITRO = {V1MEST_APOL_SINI}");

                /*" -2389- DISPLAY '-----------------------------------------------' */
                _.Display($"-----------------------------------------------");

                /*" -2391- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2392- MOVE V1APCO-CODCOSS TO LC05-CODCOSS */
            _.Move(V1APCO_CODCOSS, W.LC05.LC05_CODCOSS);

            /*" -2394- MOVE V1APCO-PCPARTIC TO LC09-PCPARTIC */
            _.Move(V1APCO_PCPARTIC, W.LC09.LC09_PCPARTIC);

            /*" -2394- PERFORM 380-000-LER-V1MOEDA. */

            M_380_000_LER_V1MOEDA_SECTION();

        }

        [StopWatch]
        /*" M-370-100-LER-V1APOLCOSCED-SMART-DB-FETCH-1 */
        public void M_370_100_LER_V1APOLCOSCED_SMART_DB_FETCH_1()
        {
            /*" -2368- EXEC SQL FETCH SX_APOLCOSG INTO :SX010-NUM-APOLICE, :SX118-COD-CONGENERE, :SX118-PCT-PARTICIPACAO END-EXEC. */

            if (SX_APOLCOSG.Fetch())
            {
                _.Move(SX_APOLCOSG.SX010_NUM_APOLICE, SX010.DCLSX_APOLICE.SX010_NUM_APOLICE);
                _.Move(SX_APOLCOSG.SX118_COD_CONGENERE, SX118.DCLSX_APOL_COSSEGURO.SX118_COD_CONGENERE);
                _.Move(SX_APOLCOSG.SX118_PCT_PARTICIPACAO, SX118.DCLSX_APOL_COSSEGURO.SX118_PCT_PARTICIPACAO);
            }

        }

        [StopWatch]
        /*" M-370-100-LER-V1APOLCOSCED-SMART-DB-CLOSE-1 */
        public void M_370_100_LER_V1APOLCOSCED_SMART_DB_CLOSE_1()
        {
            /*" -2377- EXEC SQL CLOSE SX_APOLCOSG END-EXEC */

            SX_APOLCOSG.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_370_100_EXIT*/

        [StopWatch]
        /*" M-380-000-LER-V1MOEDA-SECTION */
        private void M_380_000_LER_V1MOEDA_SECTION()
        {
            /*" -2402- MOVE '016' TO WNR-EXEC-SQL. */
            _.Move("016", W.WABEND.WNR_EXEC_SQL);

            /*" -2411- PERFORM M_380_000_LER_V1MOEDA_DB_SELECT_1 */

            M_380_000_LER_V1MOEDA_DB_SELECT_1();

            /*" -2417- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -2419- GO TO 380-999-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_380_999_EXIT*/ //GOTO
                return;
            }


            /*" -2421- IF (SQLCODE NOT EQUAL ZEROS) AND (SQLCODE NOT EQUAL 100) */

            if ((DB.SQLCODE != 00) && (DB.SQLCODE != 100))
            {

                /*" -2424- DISPLAY 'SI0021B - ERRO SELECT V1MOEDA ... .......... ' ' ' V1MEST-MOEDA-SINI ' ' V1HIST-DTMOVTO */

                $"SI0021B - ERRO SELECT V1MOEDA ... ..........  {V1MEST_MOEDA_SINI} {V1HIST_DTMOVTO}"
                .Display();

                /*" -2426- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2434- MOVE V1MOED-SIGLUNIM TO LC11-SIGLUNIM */
            _.Move(V1MOED_SIGLUNIM, W.LC11.LC11_SIGLUNIM);

            /*" -2436- MOVE '017' TO WNR-EXEC-SQL. */
            _.Move("017", W.WABEND.WNR_EXEC_SQL);

            /*" -2444- PERFORM M_380_000_LER_V1MOEDA_DB_SELECT_2 */

            M_380_000_LER_V1MOEDA_DB_SELECT_2();

            /*" -2447- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2448- IF SQLCODE EQUAL +100 */

                if (DB.SQLCODE == +100)
                {

                    /*" -2449- MOVE V1MEST-NUM-APOL TO CA-NUM-APOLICE */
                    _.Move(V1MEST_NUM_APOL, W.CA_NUM_APOLICE);

                    /*" -2450- IF TRI-POSI-APOLICE EQUAL 010 OR 100 */

                    if (W.FILLER_355.TRI_POSI_APOLICE.In("010", "100"))
                    {

                        /*" -2451- DISPLAY 'SI0021B - V0COSSEG_HISTSIN NAO ENCONTRADA' */
                        _.Display($"SI0021B - V0COSSEG_HISTSIN NAO ENCONTRADA");

                        /*" -2452- DISPLAY 'CONGENERE    = ' V1APCO-CODCOSS */
                        _.Display($"CONGENERE    = {V1APCO_CODCOSS}");

                        /*" -2453- DISPLAY 'SINISTRO     = ' V1MEST-APOL-SINI */
                        _.Display($"SINISTRO     = {V1MEST_APOL_SINI}");

                        /*" -2454- DISPLAY 'OPERACAO     = ' V1HIST-OPERACAO */
                        _.Display($"OPERACAO     = {V1HIST_OPERACAO}");

                        /*" -2455- DISPLAY 'OCORHIST     = ' V1HIST-OCORHIST */
                        _.Display($"OCORHIST     = {V1HIST_OCORHIST}");

                        /*" -2456- GO TO 999-999-ROT-ERRO */

                        M_999_999_ROT_ERRO_SECTION(); //GOTO
                        return;

                        /*" -2457- ELSE */
                    }
                    else
                    {


                        /*" -2458- MOVE ZEROS TO V0COSSEG-HISTSIN-VAL-OPERACAO */
                        _.Move(0, V0COSSEG_HISTSIN_VAL_OPERACAO);

                        /*" -2459- END-IF */
                    }


                    /*" -2460- ELSE */
                }
                else
                {


                    /*" -2461- DISPLAY 'SI0021B - ERRO ACESSO A V0COSSEG_HISTSIN' */
                    _.Display($"SI0021B - ERRO ACESSO A V0COSSEG_HISTSIN");

                    /*" -2462- DISPLAY 'CONGENERE    = ' V1APCO-CODCOSS */
                    _.Display($"CONGENERE    = {V1APCO_CODCOSS}");

                    /*" -2463- DISPLAY 'SINISTRO     = ' V1MEST-APOL-SINI */
                    _.Display($"SINISTRO     = {V1MEST_APOL_SINI}");

                    /*" -2464- DISPLAY 'OPERACAO     = ' V1HIST-OPERACAO */
                    _.Display($"OPERACAO     = {V1HIST_OPERACAO}");

                    /*" -2465- DISPLAY 'OCORHIST     = ' V1HIST-OCORHIST */
                    _.Display($"OCORHIST     = {V1HIST_OCORHIST}");

                    /*" -2466- GO TO 999-999-ROT-ERRO */

                    M_999_999_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2467- END-IF */
                }


                /*" -2484- END-IF. */
            }


            /*" -2486- MOVE ZEROS TO W01P1505 */
            _.Move(0, W.W01P1505);

            /*" -2488- IF GEOPERAC-FUNCAO-OPERACAO EQUAL 'DPAG' OR 'HPAG' OR 'JBDESP' OR 'JBHON' */

            if (GEOPERAC_FUNCAO_OPERACAO.In("DPAG", "HPAG", "JBDESP", "JBHON"))
            {

                /*" -2489- COMPUTE W01P1505 = CA-VALOR-TOTAL / V1MOED-VLCRUZAD */
                W.W01P1505.Value = CA_VALOR_TOTAL / V1MOED_VLCRUZAD;

                /*" -2490- MOVE CA-VALOR-TOTAL TO LC34-VAL-TOTAL */
                _.Move(CA_VALOR_TOTAL, W.LC34.LC34_VAL_TOTAL);

                /*" -2491- ELSE */
            }
            else
            {


                /*" -2492- COMPUTE W01P1505 = V1HIST-VAL-OPER / V1MOED-VLCRUZAD */
                W.W01P1505.Value = V1HIST_VAL_OPER / V1MOED_VLCRUZAD;

                /*" -2493- MOVE V1HIST-VAL-OPER TO LC34-VAL-TOTAL */
                _.Move(V1HIST_VAL_OPER, W.LC34.LC34_VAL_TOTAL);

                /*" -2495- END-IF. */
            }


            /*" -2496- MOVE V0COSSEG-HISTSIN-VAL-OPERACAO TO LC34-SUA-PARTIC. */
            _.Move(V0COSSEG_HISTSIN_VAL_OPERACAO, W.LC34.LC34_SUA_PARTIC);

            /*" -2500- MOVE V0COSSEG-HISTSIN-VAL-OPERACAO TO LC34-TOT-COSSEG. */
            _.Move(V0COSSEG_HISTSIN_VAL_OPERACAO, W.LC34.LC34_TOT_COSSEG);

            /*" -2511- MOVE W01P1505 TO LC35-VAL-TOTAL */
            _.Move(W.W01P1505, W.LC35.LC35_VAL_TOTAL);

            /*" -2513- COMPUTE W02P1505 = V0COSSEG-HISTSIN-VAL-OPERACAO / V1MOED-VLCRUZAD */
            W.W02P1505.Value = V0COSSEG_HISTSIN_VAL_OPERACAO / V1MOED_VLCRUZAD;

            /*" -2514- MOVE W02P1505 TO LC35-SUA-PARTIC */
            _.Move(W.W02P1505, W.LC35.LC35_SUA_PARTIC);

            /*" -2514- MOVE W02P1505 TO LC35-TOT-COSSEG. */
            _.Move(W.W02P1505, W.LC35.LC35_TOT_COSSEG);

        }

        [StopWatch]
        /*" M-380-000-LER-V1MOEDA-DB-SELECT-1 */
        public void M_380_000_LER_V1MOEDA_DB_SELECT_1()
        {
            /*" -2411- EXEC SQL SELECT VLCRUZAD, SIGLUNIM INTO :V1MOED-VLCRUZAD, :V1MOED-SIGLUNIM FROM SEGUROS.V1MOEDA WHERE CODUNIMO = :V1MEST-MOEDA-SINI AND DTINIVIG <= :V1HIST-DTMOVTO AND DTTERVIG >= :V1HIST-DTMOVTO END-EXEC. */

            var m_380_000_LER_V1MOEDA_DB_SELECT_1_Query1 = new M_380_000_LER_V1MOEDA_DB_SELECT_1_Query1()
            {
                V1MEST_MOEDA_SINI = V1MEST_MOEDA_SINI.ToString(),
                V1HIST_DTMOVTO = V1HIST_DTMOVTO.ToString(),
            };

            var executed_1 = M_380_000_LER_V1MOEDA_DB_SELECT_1_Query1.Execute(m_380_000_LER_V1MOEDA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1MOED_VLCRUZAD, V1MOED_VLCRUZAD);
                _.Move(executed_1.V1MOED_SIGLUNIM, V1MOED_SIGLUNIM);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_380_999_EXIT*/

        [StopWatch]
        /*" M-380-000-LER-V1MOEDA-DB-SELECT-2 */
        public void M_380_000_LER_V1MOEDA_DB_SELECT_2()
        {
            /*" -2444- EXEC SQL SELECT VAL_OPERACAO INTO :V0COSSEG-HISTSIN-VAL-OPERACAO FROM SEGUROS.V0COSSEG_HISTSIN WHERE CONGENER = :V1APCO-CODCOSS AND NUM_SINISTRO = :V1MEST-APOL-SINI AND OPERACAO = :V1HIST-OPERACAO AND OCORHIST = :V1HIST-OCORHIST END-EXEC. */

            var m_380_000_LER_V1MOEDA_DB_SELECT_2_Query1 = new M_380_000_LER_V1MOEDA_DB_SELECT_2_Query1()
            {
                V1MEST_APOL_SINI = V1MEST_APOL_SINI.ToString(),
                V1HIST_OPERACAO = V1HIST_OPERACAO.ToString(),
                V1HIST_OCORHIST = V1HIST_OCORHIST.ToString(),
                V1APCO_CODCOSS = V1APCO_CODCOSS.ToString(),
            };

            var executed_1 = M_380_000_LER_V1MOEDA_DB_SELECT_2_Query1.Execute(m_380_000_LER_V1MOEDA_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0COSSEG_HISTSIN_VAL_OPERACAO, V0COSSEG_HISTSIN_VAL_OPERACAO);
            }


        }

        [StopWatch]
        /*" M-400-000-PROCESSA-COSSEGURO-SECTION */
        private void M_400_000_PROCESSA_COSSEGURO_SECTION()
        {
            /*" -2527- MOVE '018' TO WNR-EXEC-SQL. */
            _.Move("018", W.WABEND.WNR_EXEC_SQL);

            /*" -2529- PERFORM 160-000-LER-V1CONGENERE */

            M_160_000_LER_V1CONGENERE_SECTION();

            /*" -2531- PERFORM 330-000-LER-V1ORDECOSCED */

            M_330_000_LER_V1ORDECOSCED_SECTION();

            /*" -2532- IF WS-RAMO-SINI EQUAL 31 OR 53 */

            if (W.FILLER_356.WS_RAMO_SINI.In("31", "53"))
            {

                /*" -2533- PERFORM 420-000-LER-V1APOLVEIC */

                M_420_000_LER_V1APOLVEIC_SECTION();

                /*" -2534- PERFORM 450-000-LER-V1DESCRVEI */

                M_450_000_LER_V1DESCRVEI_SECTION();

                /*" -2535- ELSE */
            }
            else
            {


                /*" -2538- MOVE SPACES TO LC16-DESCVEIC LC16-PLACALET LC16-CHASSIS */
                _.Move("", W.LC16.LC16_DESCVEIC, W.LC16.LC16_PLACA.LC16_PLACALET, W.LC16.LC16_CHASSIS);

                /*" -2540- MOVE ZEROS TO LC16-ANOVEICL */
                _.Move(0, W.LC16.LC16_ANOVEICL);

                /*" -2542- MOVE SPACES TO LC16-PLACANR */
                _.Move("", W.LC16.LC16_PLACA.LC16_PLACANR);

                /*" -2543- IF WS-RAMO-SINI EQUAL 11 OR 41 OR 71 OR 67 */

                if (W.FILLER_356.WS_RAMO_SINI.In("11", "41", "71", "67"))
                {

                    /*" -2544- PERFORM 410-000-LER-V1APOLITEM */

                    M_410_000_LER_V1APOLITEM_SECTION();

                    /*" -2545- ELSE */
                }
                else
                {


                    /*" -2546- IF WS-RAMO-SINI EQUAL 21 */

                    if (W.FILLER_356.WS_RAMO_SINI == 21)
                    {

                        /*" -2547- PERFORM 480-000-LER-V1AVERBNAC */

                        M_480_000_LER_V1AVERBNAC_SECTION();

                        /*" -2548- ELSE */
                    }
                    else
                    {


                        /*" -2549- IF WS-RAMO-SINI EQUAL 22 */

                        if (W.FILLER_356.WS_RAMO_SINI == 22)
                        {

                            /*" -2550- PERFORM 510-000-LER-V1AVERBINT */

                            M_510_000_LER_V1AVERBINT_SECTION();

                            /*" -2551- ELSE */
                        }
                        else
                        {


                            /*" -2552- IF WS-RAMO-SINI EQUAL 93 OR 97 */

                            if (W.FILLER_356.WS_RAMO_SINI.In("93", "97"))
                            {

                                /*" -2554- MOVE V1APOL-NOME TO LC29-ESTIPUL */
                                _.Move(V1APOL_NOME, W.LC29.LC29_ESTIPUL);

                                /*" -2556- PERFORM 576-000-LER-V1CONDTEC */

                                M_576_000_LER_V1CONDTEC_SECTION();

                                /*" -2559- IF V1MEST-IDTPSEGU EQUAL 2 */

                                if (V1MEST_IDTPSEGU == 2)
                                {

                                    /*" -2560- MOVE V1CLIE-NOME TO LC29-SEG-SIN */
                                    _.Move(V1CLIE_NOME, W.LC29.LC29_SEG_SIN);

                                    /*" -2561- MOVE V1SEGVG-DTNASCIM TO WDATA-R */
                                    _.Move(V1SEGVG_DTNASCIM, W.WDATA_R);

                                    /*" -2562- MOVE WDATA-DD TO LC31-DIA2 */
                                    _.Move(W.WDATA.WDATA_DD, W.LC31.LC31_DATA2.LC31_DIA2);

                                    /*" -2563- MOVE WDATA-MM TO LC31-MES2 */
                                    _.Move(W.WDATA.WDATA_MM, W.LC31.LC31_DATA2.LC31_MES2);

                                    /*" -2566- MOVE WDATA-AA TO LC31-ANO2 */
                                    _.Move(W.WDATA.WDATA_AA, W.LC31.LC31_DATA2.LC31_ANO2);

                                    /*" -2568- PERFORM 570-000-LER-V1SEGURAVG */

                                    M_570_000_LER_V1SEGURAVG_SECTION();

                                    /*" -2569- MOVE V1CLIE-NOME TO LC29-SEG-PRI */
                                    _.Move(V1CLIE_NOME, W.LC29.LC29_SEG_PRI);

                                    /*" -2570- MOVE V1SEGVG-DTNASCIM TO WDATA-R */
                                    _.Move(V1SEGVG_DTNASCIM, W.WDATA_R);

                                    /*" -2571- MOVE WDATA-DD TO LC31-DIA1 */
                                    _.Move(W.WDATA.WDATA_DD, W.LC31.LC31_DATA1.LC31_DIA1);

                                    /*" -2572- MOVE WDATA-MM TO LC31-MES1 */
                                    _.Move(W.WDATA.WDATA_MM, W.LC31.LC31_DATA1.LC31_MES1);

                                    /*" -2573- MOVE WDATA-AA TO LC31-ANO1 */
                                    _.Move(W.WDATA.WDATA_AA, W.LC31.LC31_DATA1.LC31_ANO1);

                                    /*" -2576- ELSE */
                                }
                                else
                                {


                                    /*" -2577- MOVE V1CLIE-NOME TO LC29-SEG-PRI */
                                    _.Move(V1CLIE_NOME, W.LC29.LC29_SEG_PRI);

                                    /*" -2578- MOVE V1SEGVG-DTNASCIM TO WDATA-R */
                                    _.Move(V1SEGVG_DTNASCIM, W.WDATA_R);

                                    /*" -2579- MOVE WDATA-DD TO LC31-DIA1 */
                                    _.Move(W.WDATA.WDATA_DD, W.LC31.LC31_DATA1.LC31_DIA1);

                                    /*" -2580- MOVE WDATA-MM TO LC31-MES1 */
                                    _.Move(W.WDATA.WDATA_MM, W.LC31.LC31_DATA1.LC31_MES1);

                                    /*" -2582- MOVE WDATA-AA TO LC31-ANO1 */
                                    _.Move(W.WDATA.WDATA_AA, W.LC31.LC31_DATA1.LC31_ANO1);

                                    /*" -2583- MOVE V1CLIE-NOME TO LC29-SEG-SIN */
                                    _.Move(V1CLIE_NOME, W.LC29.LC29_SEG_SIN);

                                    /*" -2584- MOVE V1SEGVG-DTNASCIM TO WDATA-R */
                                    _.Move(V1SEGVG_DTNASCIM, W.WDATA_R);

                                    /*" -2585- MOVE WDATA-DD TO LC31-DIA2 */
                                    _.Move(W.WDATA.WDATA_DD, W.LC31.LC31_DATA2.LC31_DIA2);

                                    /*" -2586- MOVE WDATA-MM TO LC31-MES2 */
                                    _.Move(W.WDATA.WDATA_MM, W.LC31.LC31_DATA2.LC31_MES2);

                                    /*" -2588- MOVE WDATA-AA TO LC31-ANO2. */
                                    _.Move(W.WDATA.WDATA_AA, W.LC31.LC31_DATA2.LC31_ANO2);
                                }

                            }

                        }

                    }

                }

            }


            /*" -2590- PERFORM 000-00-SELECT-V0SINICAUSA. */

            M_000_00_SELECT_V0SINICAUSA_SECTION();

            /*" -2592- PERFORM 000-00-SELECT-V0SINI-LOCAL1. */

            M_000_00_SELECT_V0SINI_LOCAL1_SECTION();

            /*" -2596- PERFORM 700-000-IMPRIME. */

            M_700_000_IMPRIME_SECTION();

            /*" -2597- IF WS-FONTE-SINISTRO = 140 */

            if (WS_SINISTRO_SMART.WS_FONTE_SINISTRO == 140)
            {

                /*" -2598- PERFORM 370-100-LER-V1APOLCOSCED-SMART */

                M_370_100_LER_V1APOLCOSCED_SMART_SECTION();

                /*" -2599- ELSE */
            }
            else
            {


                /*" -2600- PERFORM 370-000-LER-V1APOLCOSCED */

                M_370_000_LER_V1APOLCOSCED_SECTION();

                /*" -2600- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_400_999_EXIT*/

        [StopWatch]
        /*" M-410-000-LER-V1APOLITEM-SECTION */
        private void M_410_000_LER_V1APOLITEM_SECTION()
        {
            /*" -2611- MOVE '019' TO WNR-EXEC-SQL. */
            _.Move("019", W.WABEND.WNR_EXEC_SQL);

            /*" -2613- MOVE V1MEST-NRCERTIF TO V1MEST-NRITEM. */
            _.Move(V1MEST_NRCERTIF, V1MEST_NRITEM);

            /*" -2621- PERFORM M_410_000_LER_V1APOLITEM_DB_SELECT_1 */

            M_410_000_LER_V1APOLITEM_DB_SELECT_1();

            /*" -2629- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -2630- MOVE SPACES TO LC19-DESCRITEM */
                _.Move("", W.LC19.LC19_DESCRITEM);

                /*" -2632- GO TO 410-999-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_410_999_EXIT*/ //GOTO
                return;
            }


            /*" -2634- IF (SQLCODE NOT EQUAL ZEROS) AND (SQLCODE NOT EQUAL 100) */

            if ((DB.SQLCODE != 00) && (DB.SQLCODE != 100))
            {

                /*" -2639- DISPLAY 'SI0021B - ERRO SELECT V1APOLITEM. .......... ' ' ' V1MEST-NUM-APOL ' ' V1MEST-NRENDOS ' ' V1MEST-NRITEM */

                $"SI0021B - ERRO SELECT V1APOLITEM. ..........  {V1MEST_NUM_APOL} {V1MEST_NRENDOS} {V1MEST_NRITEM}"
                .Display();

                /*" -2641- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2641- MOVE V1APIT-DESCRITEM TO LC19-DESCRITEM. */
            _.Move(V1APIT_DESCRITEM, W.LC19.LC19_DESCRITEM);

        }

        [StopWatch]
        /*" M-410-000-LER-V1APOLITEM-DB-SELECT-1 */
        public void M_410_000_LER_V1APOLITEM_DB_SELECT_1()
        {
            /*" -2621- EXEC SQL SELECT DESCR_ITEM INTO :V1APIT-DESCRITEM FROM SEGUROS.V1APOLITEM WHERE NUM_APOLICE = :V1MEST-NUM-APOL AND NRENDOS = :V1MEST-NRENDOS AND NRITEM = :V1MEST-NRITEM END-EXEC. */

            var m_410_000_LER_V1APOLITEM_DB_SELECT_1_Query1 = new M_410_000_LER_V1APOLITEM_DB_SELECT_1_Query1()
            {
                V1MEST_NUM_APOL = V1MEST_NUM_APOL.ToString(),
                V1MEST_NRENDOS = V1MEST_NRENDOS.ToString(),
                V1MEST_NRITEM = V1MEST_NRITEM.ToString(),
            };

            var executed_1 = M_410_000_LER_V1APOLITEM_DB_SELECT_1_Query1.Execute(m_410_000_LER_V1APOLITEM_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1APIT_DESCRITEM, V1APIT_DESCRITEM);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_410_999_EXIT*/

        [StopWatch]
        /*" M-420-000-LER-V1APOLVEIC-SECTION */
        private void M_420_000_LER_V1APOLVEIC_SECTION()
        {
            /*" -2689- SECTION. */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_420_999_EXIT*/

        [StopWatch]
        /*" M-450-000-LER-V1DESCRVEI-SECTION */
        private void M_450_000_LER_V1DESCRVEI_SECTION()
        {
            /*" -2719- SECTION. */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_450_999_EXIT*/

        [StopWatch]
        /*" M-480-000-LER-V1AVERBNAC-SECTION */
        private void M_480_000_LER_V1AVERBNAC_SECTION()
        {
            /*" -2789- SECTION. */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_480_999_EXIT*/

        [StopWatch]
        /*" M-510-000-LER-V1AVERBINT-SECTION */
        private void M_510_000_LER_V1AVERBINT_SECTION()
        {
            /*" -2858- SECTION. */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_510_999_EXIT*/

        [StopWatch]
        /*" M-570-000-LER-V1SEGURAVG-SECTION */
        private void M_570_000_LER_V1SEGURAVG_SECTION()
        {
            /*" -2865- MOVE '024' TO WNR-EXEC-SQL. */
            _.Move("024", W.WABEND.WNR_EXEC_SQL);

            /*" -2873- PERFORM M_570_000_LER_V1SEGURAVG_DB_SELECT_1 */

            M_570_000_LER_V1SEGURAVG_DB_SELECT_1();

            /*" -2877- IF (SQLCODE NOT EQUAL ZEROS) AND (SQLCODE NOT EQUAL 100) */

            if ((DB.SQLCODE != 00) && (DB.SQLCODE != 100))
            {

                /*" -2880- DISPLAY 'SI0021B - ERRO SELECT V1MOEDA ... .......... ' ' ' V1MEST-MOEDA-SINI ' ' V1HIST-DTMOVTO */

                $"SI0021B - ERRO SELECT V1MOEDA ... ..........  {V1MEST_MOEDA_SINI} {V1HIST_DTMOVTO}"
                .Display();

                /*" -2882- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2887- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -2889- MOVE SPACES TO V1CLIE-NOME LC09-NOME */
                _.Move("", V1CLIE_NOME, W.LC09.LC09_NOME);

                /*" -2890- MOVE ZEROS TO V1SEGVG-DTNASCIM */
                _.Move(0, V1SEGVG_DTNASCIM);

                /*" -2891- ELSE */
            }
            else
            {


                /*" -2891- PERFORM 575-000-LER-V1CLIENTE. */

                M_575_000_LER_V1CLIENTE_SECTION();
            }


        }

        [StopWatch]
        /*" M-570-000-LER-V1SEGURAVG-DB-SELECT-1 */
        public void M_570_000_LER_V1SEGURAVG_DB_SELECT_1()
        {
            /*" -2873- EXEC SQL SELECT COD_CLIENTE, DATA_NASCIMENTO INTO :V1SEGVG-COD-CLI, :V1SEGVG-DTNASCIM FROM SEGUROS.V1SEGURAVG WHERE NUM_APOLICE = :V1MEST-NUM-APOL AND COD_SUBGRUPO = :V1MEST-CODSUBES AND NUM_CERTIFICADO = :V1MEST-NRCERTIF AND TIPO_SEGURADO = :V1MEST-IDTPSEGU END-EXEC. */

            var m_570_000_LER_V1SEGURAVG_DB_SELECT_1_Query1 = new M_570_000_LER_V1SEGURAVG_DB_SELECT_1_Query1()
            {
                V1MEST_NUM_APOL = V1MEST_NUM_APOL.ToString(),
                V1MEST_CODSUBES = V1MEST_CODSUBES.ToString(),
                V1MEST_NRCERTIF = V1MEST_NRCERTIF.ToString(),
                V1MEST_IDTPSEGU = V1MEST_IDTPSEGU.ToString(),
            };

            var executed_1 = M_570_000_LER_V1SEGURAVG_DB_SELECT_1_Query1.Execute(m_570_000_LER_V1SEGURAVG_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1SEGVG_COD_CLI, V1SEGVG_COD_CLI);
                _.Move(executed_1.V1SEGVG_DTNASCIM, V1SEGVG_DTNASCIM);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_570_999_EXIT*/

        [StopWatch]
        /*" M-575-000-LER-V1CLIENTE-SECTION */
        private void M_575_000_LER_V1CLIENTE_SECTION()
        {
            /*" -2900- MOVE '025' TO WNR-EXEC-SQL. */
            _.Move("025", W.WABEND.WNR_EXEC_SQL);

            /*" -2905- PERFORM M_575_000_LER_V1CLIENTE_DB_SELECT_1 */

            M_575_000_LER_V1CLIENTE_DB_SELECT_1();

            /*" -2909- IF (SQLCODE NOT EQUAL ZEROS) AND (SQLCODE NOT EQUAL 100) */

            if ((DB.SQLCODE != 00) && (DB.SQLCODE != 100))
            {

                /*" -2911- DISPLAY 'SI0021B - ERRO SELECT V1CLIENTE ............ ' ' ' V1SEGVG-COD-CLI */

                $"SI0021B - ERRO SELECT V1CLIENTE ............  {V1SEGVG_COD_CLI}"
                .Display();

                /*" -2913- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2916- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -2918- MOVE SPACES TO V1CLIE-NOME LC09-NOME */
                _.Move("", V1CLIE_NOME, W.LC09.LC09_NOME);

                /*" -2919- ELSE */
            }
            else
            {


                /*" -2919- MOVE V1CLIE-NOME TO LC09-NOME. */
                _.Move(V1CLIE_NOME, W.LC09.LC09_NOME);
            }


        }

        [StopWatch]
        /*" M-575-000-LER-V1CLIENTE-DB-SELECT-1 */
        public void M_575_000_LER_V1CLIENTE_DB_SELECT_1()
        {
            /*" -2905- EXEC SQL SELECT NOME_RAZAO INTO :V1CLIE-NOME FROM SEGUROS.V1CLIENTE WHERE COD_CLIENTE = :V1SEGVG-COD-CLI END-EXEC. */

            var m_575_000_LER_V1CLIENTE_DB_SELECT_1_Query1 = new M_575_000_LER_V1CLIENTE_DB_SELECT_1_Query1()
            {
                V1SEGVG_COD_CLI = V1SEGVG_COD_CLI.ToString(),
            };

            var executed_1 = M_575_000_LER_V1CLIENTE_DB_SELECT_1_Query1.Execute(m_575_000_LER_V1CLIENTE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1CLIE_NOME, V1CLIE_NOME);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_575_999_EXIT*/

        [StopWatch]
        /*" M-576-000-LER-V1CONDTEC-SECTION */
        private void M_576_000_LER_V1CONDTEC_SECTION()
        {
            /*" -2928- MOVE '026' TO WNR-EXEC-SQL. */
            _.Move("026", W.WABEND.WNR_EXEC_SQL);

            /*" -2940- PERFORM M_576_000_LER_V1CONDTEC_DB_SELECT_1 */

            M_576_000_LER_V1CONDTEC_DB_SELECT_1();

            /*" -2944- IF (SQLCODE NOT EQUAL ZEROS) AND (SQLCODE NOT EQUAL 100) */

            if ((DB.SQLCODE != 00) && (DB.SQLCODE != 100))
            {

                /*" -2947- DISPLAY 'SI0021B - ERRO SELECT V1CONDTEC ............ ' ' ' V1MEST-NUM-APOL ' ' V1MEST-CODSUBES */

                $"SI0021B - ERRO SELECT V1CONDTEC ............  {V1MEST_NUM_APOL} {V1MEST_CODSUBES}"
                .Display();

                /*" -2949- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2953- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -2954- MOVE SPACES TO LC31-GARANTIA */
                _.Move("", W.LC31.LC31_GARANTIA);

                /*" -2956- GO TO 576-999-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_576_999_EXIT*/ //GOTO
                return;
            }


            /*" -2958- MOVE SPACES TO LC31-GARANTIA */
            _.Move("", W.LC31.LC31_GARANTIA);

            /*" -2960- MOVE 1 TO WIND */
            _.Move(1, W.WIND);

            /*" -2961- IF V1COND-GARAN-IEA GREATER ZEROS */

            if (V1COND_GARAN_IEA > 00)
            {

                /*" -2962- MOVE 'IEA' TO LC31-DESCR (WIND) */
                _.Move("IEA", W.LC31.FILLER_279[W.WIND].LC31_DESCR);

                /*" -2964- ADD 1 TO WIND. */
                W.WIND.Value = W.WIND + 1;
            }


            /*" -2965- IF V1COND-GARAN-IPA GREATER ZEROS */

            if (V1COND_GARAN_IPA > 00)
            {

                /*" -2966- MOVE 'IPA' TO LC31-DESCR (WIND) */
                _.Move("IPA", W.LC31.FILLER_279[W.WIND].LC31_DESCR);

                /*" -2968- ADD 1 TO WIND. */
                W.WIND.Value = W.WIND + 1;
            }


            /*" -2969- IF V1COND-GARAN-IPD GREATER ZEROS */

            if (V1COND_GARAN_IPD > 00)
            {

                /*" -2970- MOVE 'IPD' TO LC31-DESCR (WIND) */
                _.Move("IPD", W.LC31.FILLER_279[W.WIND].LC31_DESCR);

                /*" -2972- ADD 1 TO WIND. */
                W.WIND.Value = W.WIND + 1;
            }


            /*" -2973- IF V1COND-GARAN-HD GREATER ZEROS */

            if (V1COND_GARAN_HD > 00)
            {

                /*" -2974- MOVE 'HD' TO LC31-DESCR (WIND) */
                _.Move("HD", W.LC31.FILLER_279[W.WIND].LC31_DESCR);

                /*" -2976- ADD 1 TO WIND. */
                W.WIND.Value = W.WIND + 1;
            }


            /*" -2976- MOVE ZEROS TO WIND. */
            _.Move(0, W.WIND);

        }

        [StopWatch]
        /*" M-576-000-LER-V1CONDTEC-DB-SELECT-1 */
        public void M_576_000_LER_V1CONDTEC_DB_SELECT_1()
        {
            /*" -2940- EXEC SQL SELECT GARAN_ADIC_IEA, GARAN_ADIC_IPA, GARAN_ADIC_IPD, GARAN_ADIC_HD INTO :V1COND-GARAN-IEA, :V1COND-GARAN-IPA, :V1COND-GARAN-IPD, :V1COND-GARAN-HD FROM SEGUROS.V1CONDTEC WHERE NUM_APOLICE = :V1MEST-NUM-APOL AND COD_SUBGRUPO = :V1MEST-CODSUBES END-EXEC. */

            var m_576_000_LER_V1CONDTEC_DB_SELECT_1_Query1 = new M_576_000_LER_V1CONDTEC_DB_SELECT_1_Query1()
            {
                V1MEST_NUM_APOL = V1MEST_NUM_APOL.ToString(),
                V1MEST_CODSUBES = V1MEST_CODSUBES.ToString(),
            };

            var executed_1 = M_576_000_LER_V1CONDTEC_DB_SELECT_1_Query1.Execute(m_576_000_LER_V1CONDTEC_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1COND_GARAN_IEA, V1COND_GARAN_IEA);
                _.Move(executed_1.V1COND_GARAN_IPA, V1COND_GARAN_IPA);
                _.Move(executed_1.V1COND_GARAN_IPD, V1COND_GARAN_IPD);
                _.Move(executed_1.V1COND_GARAN_HD, V1COND_GARAN_HD);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_576_999_EXIT*/

        [StopWatch]
        /*" M-000-00-SELECT-V0SINICAUSA-SECTION */
        private void M_000_00_SELECT_V0SINICAUSA_SECTION()
        {
            /*" -2983- MOVE '027' TO WNR-EXEC-SQL */
            _.Move("027", W.WABEND.WNR_EXEC_SQL);

            /*" -2989- PERFORM M_000_00_SELECT_V0SINICAUSA_DB_SELECT_1 */

            M_000_00_SELECT_V0SINICAUSA_DB_SELECT_1();

            /*" -2993- IF (SQLCODE NOT EQUAL ZEROS) AND (SQLCODE NOT EQUAL 100) */

            if ((DB.SQLCODE != 00) && (DB.SQLCODE != 100))
            {

                /*" -2996- DISPLAY 'SI0021B - ERRO SELECT V0SINICAUSA .......... ' ' ' V1MEST-CODCAU ' ' V1MEST-RAMO */

                $"SI0021B - ERRO SELECT V0SINICAUSA ..........  {V1MEST_CODCAU} {V1MEST_RAMO}"
                .Display();

                /*" -2998- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2999- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -3000- MOVE V1MEST-CODCAU TO LC37-CODCAU */
                _.Move(V1MEST_CODCAU, W.LC37.LC37_CODCAU);

                /*" -3001- MOVE V0SINICAUSA-DESCAU TO LC37-DESCAU */
                _.Move(V0SINICAUSA_DESCAU, W.LC37.LC37_DESCAU);

                /*" -3002- ELSE */
            }
            else
            {


                /*" -3003- MOVE 999 TO LC37-CODCAU */
                _.Move(999, W.LC37.LC37_CODCAU);

                /*" -3003- MOVE ALL '*' TO LC37-DESCAU. */
                _.MoveAll("*", W.LC37.LC37_DESCAU);
            }


        }

        [StopWatch]
        /*" M-000-00-SELECT-V0SINICAUSA-DB-SELECT-1 */
        public void M_000_00_SELECT_V0SINICAUSA_DB_SELECT_1()
        {
            /*" -2989- EXEC SQL SELECT DESCAU INTO :V0SINICAUSA-DESCAU FROM SEGUROS.V0SINICAUSA WHERE CODCAU = :V1MEST-CODCAU AND RAMO = :V1MEST-RAMO END-EXEC. */

            var m_000_00_SELECT_V0SINICAUSA_DB_SELECT_1_Query1 = new M_000_00_SELECT_V0SINICAUSA_DB_SELECT_1_Query1()
            {
                V1MEST_CODCAU = V1MEST_CODCAU.ToString(),
                V1MEST_RAMO = V1MEST_RAMO.ToString(),
            };

            var executed_1 = M_000_00_SELECT_V0SINICAUSA_DB_SELECT_1_Query1.Execute(m_000_00_SELECT_V0SINICAUSA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0SINICAUSA_DESCAU, V0SINICAUSA_DESCAU);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_000_99_SELECT_V0SINICAUSA*/

        [StopWatch]
        /*" M-000-00-SELECT-V0SINI-LOCAL1-SECTION */
        private void M_000_00_SELECT_V0SINI_LOCAL1_SECTION()
        {
            /*" -3010- MOVE '028' TO WNR-EXEC-SQL */
            _.Move("028", W.WABEND.WNR_EXEC_SQL);

            /*" -3015- PERFORM M_000_00_SELECT_V0SINI_LOCAL1_DB_SELECT_1 */

            M_000_00_SELECT_V0SINI_LOCAL1_DB_SELECT_1();

            /*" -3019- MOVE 'NAO' TO W-CHAVE-SINI-TEM-ENDERECO. */
            _.Move("NAO", W.W_CHAVE_SINI_TEM_ENDERECO);

            /*" -3020- IF SQLCODE EQUAL 0 */

            if (DB.SQLCODE == 0)
            {

                /*" -3021- MOVE V0SINI-LOCAL1-ENDERECO-SINI TO LC37-ENDERECO-SINI */
                _.Move(V0SINI_LOCAL1_ENDERECO_SINI, W.LC37.LC37_ENDERECO_SINI);

                /*" -3023- MOVE 'SIM' TO W-CHAVE-SINI-TEM-ENDERECO */
                _.Move("SIM", W.W_CHAVE_SINI_TEM_ENDERECO);

                /*" -3024- ELSE */
            }
            else
            {


                /*" -3025- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -3026- PERFORM 000-00-SELECT-V0ENDERECOS */

                    M_000_00_SELECT_V0ENDERECOS_SECTION();

                    /*" -3027- ELSE */
                }
                else
                {


                    /*" -3028- DISPLAY 'ERRO NO SELECT DA V0SINI-LOCAL1.........' */
                    _.Display($"ERRO NO SELECT DA V0SINI-LOCAL1.........");

                    /*" -3029- DISPLAY 'NUM. SINISTRO = ' V1MEST-APOL-SINI */
                    _.Display($"NUM. SINISTRO = {V1MEST_APOL_SINI}");

                    /*" -3029- GO TO 999-999-ROT-ERRO. */

                    M_999_999_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" M-000-00-SELECT-V0SINI-LOCAL1-DB-SELECT-1 */
        public void M_000_00_SELECT_V0SINI_LOCAL1_DB_SELECT_1()
        {
            /*" -3015- EXEC SQL SELECT ENDERECO_SINISTRO INTO :V0SINI-LOCAL1-ENDERECO-SINI FROM SEGUROS.V0SINI_LOCAL1 WHERE NUM_APOL_SINISTRO = :V1MEST-APOL-SINI END-EXEC. */

            var m_000_00_SELECT_V0SINI_LOCAL1_DB_SELECT_1_Query1 = new M_000_00_SELECT_V0SINI_LOCAL1_DB_SELECT_1_Query1()
            {
                V1MEST_APOL_SINI = V1MEST_APOL_SINI.ToString(),
            };

            var executed_1 = M_000_00_SELECT_V0SINI_LOCAL1_DB_SELECT_1_Query1.Execute(m_000_00_SELECT_V0SINI_LOCAL1_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0SINI_LOCAL1_ENDERECO_SINI, V0SINI_LOCAL1_ENDERECO_SINI);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_000_99_SELECT_V0SINI_LOCAL1*/

        [StopWatch]
        /*" M-000-00-SELECT-V0ENDERECOS-SECTION */
        private void M_000_00_SELECT_V0ENDERECOS_SECTION()
        {
            /*" -3050- MOVE '030' TO WNR-EXEC-SQL */
            _.Move("030", W.WABEND.WNR_EXEC_SQL);

            /*" -3062- PERFORM M_000_00_SELECT_V0ENDERECOS_DB_SELECT_1 */

            M_000_00_SELECT_V0ENDERECOS_DB_SELECT_1();

            /*" -3065- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -3066- MOVE V0ENDERECOS-ENDERECO TO LC37-ENDERECO-SINI */
                _.Move(V0ENDERECOS_ENDERECO, W.LC37.LC37_ENDERECO_SINI);

                /*" -3067- MOVE V0ENDERECOS-BAIRRO TO LC37A-BAIRRO */
                _.Move(V0ENDERECOS_BAIRRO, W.LC37A.LC37A_BAIRRO);

                /*" -3068- MOVE V0ENDERECOS-CIDADE TO LC37A-CIDADE */
                _.Move(V0ENDERECOS_CIDADE, W.LC37A.LC37A_CIDADE);

                /*" -3069- MOVE V0ENDERECOS-SIGLA-UF TO LC37A-SIGLA-UF */
                _.Move(V0ENDERECOS_SIGLA_UF, W.LC37A.LC37A_SIGLA_UF);

                /*" -3070- ELSE */
            }
            else
            {


                /*" -3071- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -3075- MOVE ALL '*' TO LC37-ENDERECO-SINI LC37A-BAIRRO LC37A-CIDADE LC37A-SIGLA-UF */
                    _.MoveAll("*", W.LC37.LC37_ENDERECO_SINI, W.LC37A.LC37A_BAIRRO, W.LC37A.LC37A_CIDADE, W.LC37A.LC37A_SIGLA_UF);

                    /*" -3076- ELSE */
                }
                else
                {


                    /*" -3077- DISPLAY 'INDO PARA ROTINA DE ERRO' */
                    _.Display($"INDO PARA ROTINA DE ERRO");

                    /*" -3078- DISPLAY 'ERRO NO SELECT DA V0ENDERECOS  .........' */
                    _.Display($"ERRO NO SELECT DA V0ENDERECOS  .........");

                    /*" -3079- DISPLAY 'COD. CLIENTE  = ' V0SINI-ITEM-COD-CLIENTE */
                    _.Display($"COD. CLIENTE  = {V0SINI_ITEM_COD_CLIENTE}");

                    /*" -3079- GO TO 999-999-ROT-ERRO. */

                    M_999_999_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" M-000-00-SELECT-V0ENDERECOS-DB-SELECT-1 */
        public void M_000_00_SELECT_V0ENDERECOS_DB_SELECT_1()
        {
            /*" -3062- EXEC SQL SELECT ENDERECO, BAIRRO, CIDADE, SIGLA_UF INTO :V0ENDERECOS-ENDERECO, :V0ENDERECOS-BAIRRO, :V0ENDERECOS-CIDADE, :V0ENDERECOS-SIGLA-UF FROM SEGUROS.V0ENDERECOS WHERE COD_CLIENTE = :V1APOL-CODCLIEN AND OCORR_ENDERECO = 1 END-EXEC */

            var m_000_00_SELECT_V0ENDERECOS_DB_SELECT_1_Query1 = new M_000_00_SELECT_V0ENDERECOS_DB_SELECT_1_Query1()
            {
                V1APOL_CODCLIEN = V1APOL_CODCLIEN.ToString(),
            };

            var executed_1 = M_000_00_SELECT_V0ENDERECOS_DB_SELECT_1_Query1.Execute(m_000_00_SELECT_V0ENDERECOS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0ENDERECOS_ENDERECO, V0ENDERECOS_ENDERECO);
                _.Move(executed_1.V0ENDERECOS_BAIRRO, V0ENDERECOS_BAIRRO);
                _.Move(executed_1.V0ENDERECOS_CIDADE, V0ENDERECOS_CIDADE);
                _.Move(executed_1.V0ENDERECOS_SIGLA_UF, V0ENDERECOS_SIGLA_UF);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_000_99_SELECT_V0ENDERECOS*/

        [StopWatch]
        /*" M-700-000-IMPRIME-SECTION */
        private void M_700_000_IMPRIME_SECTION()
        {
            /*" -3089- ADD 1 TO AC-PAGINAS */
            W.AC_PAGINAS.Value = W.AC_PAGINAS + 1;

            /*" -3091- MOVE AC-PAGINAS TO LC01-PAG */
            _.Move(W.AC_PAGINAS, W.LC01.LC01_PAG);

            /*" -3092- WRITE REG-SI0021M1 FROM LC01 AFTER PAGE */
            _.Move(W.LC01.GetMoveValues(), REG_SI0021M1);

            SI0021M1.Write(REG_SI0021M1.GetMoveValues().ToString());

            /*" -3093- WRITE REG-SI0021M1 FROM LC02 AFTER 1 */
            _.Move(W.LC02.GetMoveValues(), REG_SI0021M1);

            SI0021M1.Write(REG_SI0021M1.GetMoveValues().ToString());

            /*" -3094- WRITE REG-SI0021M1 FROM LC03 AFTER 1 */
            _.Move(W.LC03.GetMoveValues(), REG_SI0021M1);

            SI0021M1.Write(REG_SI0021M1.GetMoveValues().ToString());

            /*" -3095- WRITE REG-SI0021M1 FROM LC04 AFTER 2 */
            _.Move(W.LC04.GetMoveValues(), REG_SI0021M1);

            SI0021M1.Write(REG_SI0021M1.GetMoveValues().ToString());

            /*" -3096- WRITE REG-SI0021M1 FROM LC05 AFTER 1 */
            _.Move(W.LC05.GetMoveValues(), REG_SI0021M1);

            SI0021M1.Write(REG_SI0021M1.GetMoveValues().ToString());

            /*" -3097- WRITE REG-SI0021M1 FROM LC06 AFTER 2 */
            _.Move(W.LC06.GetMoveValues(), REG_SI0021M1);

            SI0021M1.Write(REG_SI0021M1.GetMoveValues().ToString());

            /*" -3098- WRITE REG-SI0021M1 FROM LC07 AFTER 2 */
            _.Move(W.LC07.GetMoveValues(), REG_SI0021M1);

            SI0021M1.Write(REG_SI0021M1.GetMoveValues().ToString());

            /*" -3099- WRITE REG-SI0021M1 FROM LC00 AFTER 1 */
            _.Move(W.LC00.GetMoveValues(), REG_SI0021M1);

            SI0021M1.Write(REG_SI0021M1.GetMoveValues().ToString());

            /*" -3100- WRITE REG-SI0021M1 FROM LC08 AFTER 1 */
            _.Move(W.LC08.GetMoveValues(), REG_SI0021M1);

            SI0021M1.Write(REG_SI0021M1.GetMoveValues().ToString());

            /*" -3101- WRITE REG-SI0021M1 FROM LC09 AFTER 1 */
            _.Move(W.LC09.GetMoveValues(), REG_SI0021M1);

            SI0021M1.Write(REG_SI0021M1.GetMoveValues().ToString());

            /*" -3102- WRITE REG-SI0021M1 FROM LC00 AFTER 1 */
            _.Move(W.LC00.GetMoveValues(), REG_SI0021M1);

            SI0021M1.Write(REG_SI0021M1.GetMoveValues().ToString());

            /*" -3103- WRITE REG-SI0021M1 FROM LC10 AFTER 1 */
            _.Move(W.LC10.GetMoveValues(), REG_SI0021M1);

            SI0021M1.Write(REG_SI0021M1.GetMoveValues().ToString());

            /*" -3104- WRITE REG-SI0021M1 FROM LC11 AFTER 1 */
            _.Move(W.LC11.GetMoveValues(), REG_SI0021M1);

            SI0021M1.Write(REG_SI0021M1.GetMoveValues().ToString());

            /*" -3105- WRITE REG-SI0021M1 FROM LC00 AFTER 1 */
            _.Move(W.LC00.GetMoveValues(), REG_SI0021M1);

            SI0021M1.Write(REG_SI0021M1.GetMoveValues().ToString());

            /*" -3106- WRITE REG-SI0021M1 FROM LC12 AFTER 1 */
            _.Move(W.LC12.GetMoveValues(), REG_SI0021M1);

            SI0021M1.Write(REG_SI0021M1.GetMoveValues().ToString());

            /*" -3107- WRITE REG-SI0021M1 FROM LC13 AFTER 1 */
            _.Move(W.LC13.GetMoveValues(), REG_SI0021M1);

            SI0021M1.Write(REG_SI0021M1.GetMoveValues().ToString());

            /*" -3108- WRITE REG-SI0021M1 FROM LC00 AFTER 1 */
            _.Move(W.LC00.GetMoveValues(), REG_SI0021M1);

            SI0021M1.Write(REG_SI0021M1.GetMoveValues().ToString());

            /*" -3109- WRITE REG-SI0021M1 FROM LC14 AFTER 1 */
            _.Move(W.LC14.GetMoveValues(), REG_SI0021M1);

            SI0021M1.Write(REG_SI0021M1.GetMoveValues().ToString());

            /*" -3110- WRITE REG-SI0021M1 FROM LC00 AFTER 1 */
            _.Move(W.LC00.GetMoveValues(), REG_SI0021M1);

            SI0021M1.Write(REG_SI0021M1.GetMoveValues().ToString());

            /*" -3111- WRITE REG-SI0021M1 FROM LC15 AFTER 1 */
            _.Move(W.LC15.GetMoveValues(), REG_SI0021M1);

            SI0021M1.Write(REG_SI0021M1.GetMoveValues().ToString());

            /*" -3112- WRITE REG-SI0021M1 FROM LC16 AFTER 1 */
            _.Move(W.LC16.GetMoveValues(), REG_SI0021M1);

            SI0021M1.Write(REG_SI0021M1.GetMoveValues().ToString());

            /*" -3113- WRITE REG-SI0021M1 FROM LC00 AFTER 1 */
            _.Move(W.LC00.GetMoveValues(), REG_SI0021M1);

            SI0021M1.Write(REG_SI0021M1.GetMoveValues().ToString());

            /*" -3114- WRITE REG-SI0021M1 FROM LC17 AFTER 1 */
            _.Move(W.LC17.GetMoveValues(), REG_SI0021M1);

            SI0021M1.Write(REG_SI0021M1.GetMoveValues().ToString());

            /*" -3115- WRITE REG-SI0021M1 FROM LC00 AFTER 1 */
            _.Move(W.LC00.GetMoveValues(), REG_SI0021M1);

            SI0021M1.Write(REG_SI0021M1.GetMoveValues().ToString());

            /*" -3116- WRITE REG-SI0021M1 FROM LC18 AFTER 1 */
            _.Move(W.LC18.GetMoveValues(), REG_SI0021M1);

            SI0021M1.Write(REG_SI0021M1.GetMoveValues().ToString());

            /*" -3117- WRITE REG-SI0021M1 FROM LC37 AFTER 1 */
            _.Move(W.LC37.GetMoveValues(), REG_SI0021M1);

            SI0021M1.Write(REG_SI0021M1.GetMoveValues().ToString());

            /*" -3118- IF W-CHAVE-SINI-TEM-ENDERECO EQUAL 'NAO' */

            if (W.W_CHAVE_SINI_TEM_ENDERECO == "NAO")
            {

                /*" -3119- WRITE REG-SI0021M1 FROM LC37A AFTER 1. */
                _.Move(W.LC37A.GetMoveValues(), REG_SI0021M1);

                SI0021M1.Write(REG_SI0021M1.GetMoveValues().ToString());
            }


            /*" -3120- WRITE REG-SI0021M1 FROM LC19 AFTER 1 */
            _.Move(W.LC19.GetMoveValues(), REG_SI0021M1);

            SI0021M1.Write(REG_SI0021M1.GetMoveValues().ToString());

            /*" -3121- WRITE REG-SI0021M1 FROM LC00 AFTER 1 */
            _.Move(W.LC00.GetMoveValues(), REG_SI0021M1);

            SI0021M1.Write(REG_SI0021M1.GetMoveValues().ToString());

            /*" -3122- WRITE REG-SI0021M1 FROM LC20 AFTER 1 */
            _.Move(W.LC20.GetMoveValues(), REG_SI0021M1);

            SI0021M1.Write(REG_SI0021M1.GetMoveValues().ToString());

            /*" -3123- WRITE REG-SI0021M1 FROM LC00 AFTER 1 */
            _.Move(W.LC00.GetMoveValues(), REG_SI0021M1);

            SI0021M1.Write(REG_SI0021M1.GetMoveValues().ToString());

            /*" -3124- WRITE REG-SI0021M1 FROM LC21 AFTER 1 */
            _.Move(W.LC21.GetMoveValues(), REG_SI0021M1);

            SI0021M1.Write(REG_SI0021M1.GetMoveValues().ToString());

            /*" -3125- WRITE REG-SI0021M1 FROM LC22 AFTER 1 */
            _.Move(W.LC22.GetMoveValues(), REG_SI0021M1);

            SI0021M1.Write(REG_SI0021M1.GetMoveValues().ToString());

            /*" -3126- WRITE REG-SI0021M1 FROM LC00 AFTER 1 */
            _.Move(W.LC00.GetMoveValues(), REG_SI0021M1);

            SI0021M1.Write(REG_SI0021M1.GetMoveValues().ToString());

            /*" -3127- WRITE REG-SI0021M1 FROM LC23 AFTER 1 */
            _.Move(W.LC23.GetMoveValues(), REG_SI0021M1);

            SI0021M1.Write(REG_SI0021M1.GetMoveValues().ToString());

            /*" -3128- WRITE REG-SI0021M1 FROM LC24 AFTER 1 */
            _.Move(W.LC24.GetMoveValues(), REG_SI0021M1);

            SI0021M1.Write(REG_SI0021M1.GetMoveValues().ToString());

            /*" -3129- WRITE REG-SI0021M1 FROM LC00 AFTER 1 */
            _.Move(W.LC00.GetMoveValues(), REG_SI0021M1);

            SI0021M1.Write(REG_SI0021M1.GetMoveValues().ToString());

            /*" -3130- WRITE REG-SI0021M1 FROM LC25 AFTER 1 */
            _.Move(W.LC25.GetMoveValues(), REG_SI0021M1);

            SI0021M1.Write(REG_SI0021M1.GetMoveValues().ToString());

            /*" -3131- WRITE REG-SI0021M1 FROM LC26 AFTER 1 */
            _.Move(W.LC26.GetMoveValues(), REG_SI0021M1);

            SI0021M1.Write(REG_SI0021M1.GetMoveValues().ToString());

            /*" -3132- WRITE REG-SI0021M1 FROM LC00 AFTER 1 */
            _.Move(W.LC00.GetMoveValues(), REG_SI0021M1);

            SI0021M1.Write(REG_SI0021M1.GetMoveValues().ToString());

            /*" -3133- WRITE REG-SI0021M1 FROM LC27 AFTER 1 */
            _.Move(W.LC27.GetMoveValues(), REG_SI0021M1);

            SI0021M1.Write(REG_SI0021M1.GetMoveValues().ToString());

            /*" -3134- WRITE REG-SI0021M1 FROM LC00 AFTER 1 */
            _.Move(W.LC00.GetMoveValues(), REG_SI0021M1);

            SI0021M1.Write(REG_SI0021M1.GetMoveValues().ToString());

            /*" -3135- WRITE REG-SI0021M1 FROM LC28 AFTER 1 */
            _.Move(W.LC28.GetMoveValues(), REG_SI0021M1);

            SI0021M1.Write(REG_SI0021M1.GetMoveValues().ToString());

            /*" -3136- WRITE REG-SI0021M1 FROM LC29 AFTER 1 */
            _.Move(W.LC29.GetMoveValues(), REG_SI0021M1);

            SI0021M1.Write(REG_SI0021M1.GetMoveValues().ToString());

            /*" -3137- WRITE REG-SI0021M1 FROM LC00 AFTER 1 */
            _.Move(W.LC00.GetMoveValues(), REG_SI0021M1);

            SI0021M1.Write(REG_SI0021M1.GetMoveValues().ToString());

            /*" -3138- WRITE REG-SI0021M1 FROM LC30 AFTER 1 */
            _.Move(W.LC30.GetMoveValues(), REG_SI0021M1);

            SI0021M1.Write(REG_SI0021M1.GetMoveValues().ToString());

            /*" -3139- WRITE REG-SI0021M1 FROM LC31 AFTER 1 */
            _.Move(W.LC31.GetMoveValues(), REG_SI0021M1);

            SI0021M1.Write(REG_SI0021M1.GetMoveValues().ToString());

            /*" -3140- WRITE REG-SI0021M1 FROM LC00 AFTER 1 */
            _.Move(W.LC00.GetMoveValues(), REG_SI0021M1);

            SI0021M1.Write(REG_SI0021M1.GetMoveValues().ToString());

            /*" -3141- WRITE REG-SI0021M1 FROM LC00 AFTER 1 */
            _.Move(W.LC00.GetMoveValues(), REG_SI0021M1);

            SI0021M1.Write(REG_SI0021M1.GetMoveValues().ToString());

            /*" -3142- WRITE REG-SI0021M1 FROM LC32 AFTER 1 */
            _.Move(W.LC32.GetMoveValues(), REG_SI0021M1);

            SI0021M1.Write(REG_SI0021M1.GetMoveValues().ToString());

            /*" -3143- WRITE REG-SI0021M1 FROM LC00 AFTER 1 */
            _.Move(W.LC00.GetMoveValues(), REG_SI0021M1);

            SI0021M1.Write(REG_SI0021M1.GetMoveValues().ToString());

            /*" -3144- WRITE REG-SI0021M1 FROM LC33 AFTER 1 */
            _.Move(W.LC33.GetMoveValues(), REG_SI0021M1);

            SI0021M1.Write(REG_SI0021M1.GetMoveValues().ToString());

            /*" -3145- WRITE REG-SI0021M1 FROM LC34 AFTER 1 */
            _.Move(W.LC34.GetMoveValues(), REG_SI0021M1);

            SI0021M1.Write(REG_SI0021M1.GetMoveValues().ToString());

            /*" -3146- WRITE REG-SI0021M1 FROM LC35 AFTER 1 */
            _.Move(W.LC35.GetMoveValues(), REG_SI0021M1);

            SI0021M1.Write(REG_SI0021M1.GetMoveValues().ToString());

            /*" -3149- WRITE REG-SI0021M1 FROM LC36 AFTER 1 */
            _.Move(W.LC36.GetMoveValues(), REG_SI0021M1);

            SI0021M1.Write(REG_SI0021M1.GetMoveValues().ToString());

            /*" -3151- ADD 1 TO AC-I-V1HISTSINI. */
            W.AC_I_V1HISTSINI.Value = W.AC_I_V1HISTSINI + 1;

            /*" -3152- MOVE LC06-SINISTRO TO DET01-NUM-APOL-SINISTRO */
            _.Move(W.LC06.LC06_SINISTRO, W.DET01.DET01_NUM_APOL_SINISTRO);

            /*" -3153- MOVE LC09-NOME TO DET01-NOM-SEGURADO */
            _.Move(W.LC09.LC09_NOME, W.DET01.DET01_NOM_SEGURADO);

            /*" -3155- MOVE LC06-REFER TO DET01-REFER */
            _.Move(W.LC06.LC06_REFER, W.DET01.DET01_REFER);

            /*" -3156- IF DET01-NUM-APOL-SINISTRO NOT EQUAL 9999999999999 */

            if (W.DET01.DET01_NUM_APOL_SINISTRO != 9999999999999)
            {

                /*" -3156- WRITE REG-SI0021M2 FROM DET01 AFTER 1. */
                _.Move(W.DET01.GetMoveValues(), REG_SI0021M2);

                SI0021M2.Write(REG_SI0021M2.GetMoveValues().ToString());
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_700_999_EXIT*/

        [StopWatch]
        /*" M-750-000-LIMPA-LINHAS-SECTION */
        private void M_750_000_LIMPA_LINHAS_SECTION()
        {
            /*" -3195- MOVE SPACES TO LC01-EMPRESA LC05-NOMECONG LC06-REFER LC09-NOME LC09-NOMERAMO LC11-SIGLUNIM LC13-NOMFAV LC16-DESCVEIC LC16-PLACALET LC16-CHASSIS LC19-DESCRITEM LC22-TRANSP LC22-PLACLET LC22-PREFIXO LC22-EMBARQUE LC24-EMPRESA LC24-MERCAD LC24-NATUREZA LC24-COBERTUR LC26-ORIGEM LC26-DESTINO LC26-LOCAL LC26-CIDADE LC29-ESTIPUL LC29-SEG-PRI LC29-SEG-SIN LC31-GARANTIA LC33-REFER LC16-PLACANR */
            _.Move("", W.LC01.LC01_EMPRESA, W.LC05.LC05_NOMECONG, W.LC06.LC06_REFER, W.LC09.LC09_NOME, W.LC09.LC09_NOMERAMO, W.LC11.LC11_SIGLUNIM, W.LC13.LC13_NOMFAV, W.LC16.LC16_DESCVEIC, W.LC16.LC16_PLACA.LC16_PLACALET, W.LC16.LC16_CHASSIS, W.LC19.LC19_DESCRITEM, W.LC22.LC22_TRANSP, W.LC22.LC22_PLACA.LC22_PLACLET, W.LC22.LC22_PREFIXO, W.LC22.LC22_EMBARQUE, W.LC24.LC24_EMPRESA, W.LC24.LC24_MERCAD, W.LC24.LC24_NATUREZA, W.LC24.LC24_COBERTUR, W.LC26.LC26_ORIGEM, W.LC26.LC26_DESTINO, W.LC26.LC26_LOCAL, W.LC26.LC26_CIDADE, W.LC29.LC29_ESTIPUL, W.LC29.LC29_SEG_PRI, W.LC29.LC29_SEG_SIN, W.LC31.LC31_GARANTIA, W.LC33.LC33_REFER, W.LC16.LC16_PLACA.LC16_PLACANR);

            /*" -3231- MOVE ZEROS TO LC01-PAG LC05-CODCOSS LC06-SINISTRO LC09-PCPARTIC LC09-DD-SINI LC09-MM-SINI LC09-AA-SINI LC09-DD-AVISO LC09-MM-AVISO LC09-AA-AVISO LC11-APOLICE LC11-NRORDEM LC11-DD-I LC11-MM-I LC11-AA-I LC11-DD-T LC11-MM-T LC11-AA-T LC11-ITEM LC11-ISITEM LC13-SINIRB LC16-ANOVEICL LC22-AVERBACAO LC22-PLACNUM LC31-DIA1 LC31-MES1 LC31-ANO1 LC31-DIA2 LC31-MES2 LC31-ANO2 LC34-VAL-TOTAL LC34-SUA-PARTIC LC34-TOT-COSSEG LC35-VAL-TOTAL LC35-SUA-PARTIC LC35-TOT-COSSEG. */
            _.Move(0, W.LC01.LC01_PAG, W.LC05.LC05_CODCOSS, W.LC06.LC06_SINISTRO, W.LC09.LC09_PCPARTIC, W.LC09.LC09_DTSINI.LC09_DD_SINI, W.LC09.LC09_DTSINI.LC09_MM_SINI, W.LC09.LC09_DTSINI.LC09_AA_SINI, W.LC09.LC09_DTAVISO.LC09_DD_AVISO, W.LC09.LC09_DTAVISO.LC09_MM_AVISO, W.LC09.LC09_DTAVISO.LC09_AA_AVISO, W.LC11.LC11_APOLICE, W.LC11.LC11_NRORDEM, W.LC11.LC11_DTINIVIG.LC11_DD_I, W.LC11.LC11_DTINIVIG.LC11_MM_I, W.LC11.LC11_DTINIVIG.LC11_AA_I, W.LC11.LC11_DTTERVIG.LC11_DD_T, W.LC11.LC11_DTTERVIG.LC11_MM_T, W.LC11.LC11_DTTERVIG.LC11_AA_T, W.LC11.LC11_ITEM, W.LC11.LC11_ISITEM, W.LC13.LC13_SINIRB, W.LC16.LC16_ANOVEICL, W.LC22.LC22_AVERBACAO, W.LC22.LC22_PLACA.LC22_PLACNUM, W.LC31.LC31_DATA1.LC31_DIA1, W.LC31.LC31_DATA1.LC31_MES1, W.LC31.LC31_DATA1.LC31_ANO1, W.LC31.LC31_DATA2.LC31_DIA2, W.LC31.LC31_DATA2.LC31_MES2, W.LC31.LC31_DATA2.LC31_ANO2, W.LC34.LC34_VAL_TOTAL, W.LC34.LC34_SUA_PARTIC, W.LC34.LC34_TOT_COSSEG, W.LC35.LC35_VAL_TOTAL, W.LC35.LC35_SUA_PARTIC, W.LC35.LC35_TOT_COSSEG);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_750_999_EXIT*/

        [StopWatch]
        /*" M-800-000-UPDATE-RELATORIO-SECTION */
        private void M_800_000_UPDATE_RELATORIO_SECTION()
        {
            /*" -3239- MOVE '031' TO WNR-EXEC-SQL */
            _.Move("031", W.WABEND.WNR_EXEC_SQL);

            /*" -3244- PERFORM M_800_000_UPDATE_RELATORIO_DB_UPDATE_1 */

            M_800_000_UPDATE_RELATORIO_DB_UPDATE_1();

            /*" -3247- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3248- IF SQLCODE NOT EQUAL +100 */

                if (DB.SQLCODE != +100)
                {

                    /*" -3249- DISPLAY 'INDO PARA ROTINA DE ERRO' */
                    _.Display($"INDO PARA ROTINA DE ERRO");

                    /*" -3250- DISPLAY 'ERRO NO UPDATE RELATORIOS' */
                    _.Display($"ERRO NO UPDATE RELATORIOS");

                    /*" -3251- GO TO 999-999-ROT-ERRO */

                    M_999_999_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -3252- END-IF */
                }


                /*" -3252- END-IF. */
            }


        }

        [StopWatch]
        /*" M-800-000-UPDATE-RELATORIO-DB-UPDATE-1 */
        public void M_800_000_UPDATE_RELATORIO_DB_UPDATE_1()
        {
            /*" -3244- EXEC SQL UPDATE SEGUROS.RELATORIOS SET SIT_REGISTRO = '1' WHERE COD_RELATORIO = 'SI0021B' AND SIT_REGISTRO = '0' END-EXEC */

            var m_800_000_UPDATE_RELATORIO_DB_UPDATE_1_Update1 = new M_800_000_UPDATE_RELATORIO_DB_UPDATE_1_Update1()
            {
            };

            M_800_000_UPDATE_RELATORIO_DB_UPDATE_1_Update1.Execute(m_800_000_UPDATE_RELATORIO_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_800_999_EXIT*/

        [StopWatch]
        /*" M-900-000-CLOSE-ARQUIVOS-SECTION */
        private void M_900_000_CLOSE_ARQUIVOS_SECTION()
        {
            /*" -3259- CLOSE SI0021M1 SI0021M2. */
            SI0021M1.Close();
            SI0021M2.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_900_999_EXIT*/

        [StopWatch]
        /*" M-910-000-ENCERRA-SEM-MOVTO-SECTION */
        private void M_910_000_ENCERRA_SEM_MOVTO_SECTION()
        {
            /*" -3266- DISPLAY '*--------------------------------------------*' */
            _.Display($"*--------------------------------------------*");

            /*" -3267- DISPLAY '*                                            *' */
            _.Display($"*                                            *");

            /*" -3268- DISPLAY '*  SI0021B - CARTA DE SINISTRO DE COSSEGURO  *' */
            _.Display($"*  SI0021B - CARTA DE SINISTRO DE COSSEGURO  *");

            /*" -3269- DISPLAY '*                                            *' */
            _.Display($"*                                            *");

            /*" -3270- DISPLAY '*     NAO HOUVE MOVIMENTACAO NESTA DATA      *' */
            _.Display($"*     NAO HOUVE MOVIMENTACAO NESTA DATA      *");

            /*" -3272- DISPLAY '*                 ' WDATA-LIT '                   *' */

            $"*                 {W.WDATA_LIT}                   *"
            .Display();

            /*" -3273- DISPLAY '*                                            *' */
            _.Display($"*                                            *");

            /*" -3275- DISPLAY '*--------------------------------------------*' . */
            _.Display($"*--------------------------------------------*");

            /*" -3277- MOVE 'SEM MOVIMENTACAO NA DATA DE HOJE' TO CAB03-SEM-MOVIMENTACAO. */
            _.Move("SEM MOVIMENTACAO NA DATA DE HOJE", W.CAB03.CAB03_SEM_MOVIMENTACAO);

            /*" -3279- WRITE REG-SI0021M2 FROM CAB03 AFTER 1. */
            _.Move(W.CAB03.GetMoveValues(), REG_SI0021M2);

            SI0021M2.Write(REG_SI0021M2.GetMoveValues().ToString());

            /*" -3281- CLOSE SI0021M1 SI0021M2. */
            SI0021M1.Close();
            SI0021M2.Close();

            /*" -3281- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_910_999_EXIT*/

        [StopWatch]
        /*" M-999-999-ROT-ERRO-SECTION */
        private void M_999_999_ROT_ERRO_SECTION()
        {
            /*" -3288- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3289- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, W.WABEND.WSQLCODE);

                /*" -3290- MOVE SQLERRD(1) TO WSQLCODE1 */
                _.Move(DB.SQLERRD[1], W.WABEND.WSQLCODE1);

                /*" -3291- MOVE SQLERRD(2) TO WSQLCODE2 */
                _.Move(DB.SQLERRD[2], W.WABEND.WSQLCODE2);

                /*" -3293- MOVE SQLCODE TO WSQLCODE3. */
                _.Move(DB.SQLCODE, W.WSQLCODE3);
            }


            /*" -3295- DISPLAY WABEND. */
            _.Display(W.WABEND);

            /*" -3297- CLOSE SI0021M1. */
            SI0021M1.Close();

            /*" -3297- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -3298- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -3302- MOVE 99 TO RETURN-CODE */
            _.Move(99, RETURN_CODE);

            /*" -3302- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" R10010199-MENSAGEM-LOCK */
        private void R10010199_MENSAGEM_LOCK(bool isPerform = false)
        {
            /*" -3310- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, W.WABEND.WSQLCODE);

            /*" -3313- DISPLAY '***********************************************************' UPON CONSOLE WITH NO ADVANCING. */

            $"***********************************************************WITHNOADVANCING"
            .Display();

            /*" -3316- DISPLAY '*      -------------       ----------------------         *' UPON CONSOLE WITH NO ADVANCING. */

            $"*      -------------       ----------------------         *WITHNOADVANCING"
            .Display();

            /*" -3319- DISPLAY '*      A T E N C A O       S R.   O P E R A D O R         *' UPON CONSOLE WITH NO ADVANCING. */

            $"*      A T E N C A O       S R.   O P E R A D O R         *WITHNOADVANCING"
            .Display();

            /*" -3322- DISPLAY '*      -------------       ----------------------         *' UPON CONSOLE WITH NO ADVANCING. */

            $"*      -------------       ----------------------         *WITHNOADVANCING"
            .Display();

            /*" -3325- DISPLAY '*                                                         *' UPON CONSOLE WITH NO ADVANCING. */

            $"*                                                         *WITHNOADVANCING"
            .Display();

            /*" -3328- DISPLAY '*                   PROGRAMA ABENDADO                     *' UPON CONSOLE WITH NO ADVANCING. */

            $"*                   PROGRAMA ABENDADO                     *WITHNOADVANCING"
            .Display();

            /*" -3331- DISPLAY '*                 PROVAVELMENTE POR LOCK                  *' UPON CONSOLE WITH NO ADVANCING. */

            $"*                 PROVAVELMENTE POR LOCK                  *WITHNOADVANCING"
            .Display();

            /*" -3334- DISPLAY '*        VERIFIQUE O LOG ANTES DE LIGAR PARA O ANALISTA   *' UPON CONSOLE WITH NO ADVANCING. */

            $"*        VERIFIQUE O LOG ANTES DE LIGAR PARA O ANALISTA   *WITHNOADVANCING"
            .Display();

            /*" -3337- DISPLAY '*    CONFIRMANDO O LOCK, EXECUTAR NOVAMENTE O PROGRAMA    *' UPON CONSOLE WITH NO ADVANCING. */

            $"*    CONFIRMANDO O LOCK, EXECUTAR NOVAMENTE O PROGRAMA    *WITHNOADVANCING"
            .Display();

            /*" -3340- DISPLAY '*                                                         *' UPON CONSOLE WITH NO ADVANCING. */

            $"*                                                         *WITHNOADVANCING"
            .Display();

            /*" -3343- DISPLAY '*  PERMANECENDO O ERRO, CONTACTAR O ANALISTA RESPONSAVEL  *' UPON CONSOLE WITH NO ADVANCING. */

            $"*  PERMANECENDO O ERRO, CONTACTAR O ANALISTA RESPONSAVEL  *WITHNOADVANCING"
            .Display();

            /*" -3346- DISPLAY '*                                                         *' UPON CONSOLE WITH NO ADVANCING. */

            $"*                                                         *WITHNOADVANCING"
            .Display();

            /*" -3349- DISPLAY '*                                                         *' UPON CONSOLE WITH NO ADVANCING. */

            $"*                                                         *WITHNOADVANCING"
            .Display();

            /*" -3352- DISPLAY '*     SQLCODE DO ABEND ....... ' WSQLCODE UPON CONSOLE WITH NO ADVANCING. */

            $"*     SQLCODE DO ABEND ....... {W.WABEND.WSQLCODE}WITHNOADVANCING"
            .Display();

            /*" -3355- DISPLAY '*                                                         *' UPON CONSOLE WITH NO ADVANCING. */

            $"*                                                         *WITHNOADVANCING"
            .Display();

            /*" -3361- DISPLAY '***********************************************************' UPON CONSOLE WITH NO ADVANCING. */

            $"***********************************************************WITHNOADVANCING"
            .Display();

            /*" -3363- DISPLAY '***********************************************************' */
            _.Display($"***********************************************************");

            /*" -3365- DISPLAY '*      -------------       ----------------------         *' */
            _.Display($"*      -------------       ----------------------         *");

            /*" -3367- DISPLAY '*      A T E N C A O       S R.   O P E R A D O R         *' */
            _.Display($"*      A T E N C A O       S R.   O P E R A D O R         *");

            /*" -3369- DISPLAY '*      -------------       ----------------------         *' */
            _.Display($"*      -------------       ----------------------         *");

            /*" -3371- DISPLAY '*                                                         *' */
            _.Display($"*                                                         *");

            /*" -3373- DISPLAY '*                   PROGRAMA ABENDADO                     *' */
            _.Display($"*                   PROGRAMA ABENDADO                     *");

            /*" -3375- DISPLAY '*                 PROVAVELMENTE POR LOCK                  *' */
            _.Display($"*                 PROVAVELMENTE POR LOCK                  *");

            /*" -3377- DISPLAY '*        VERIFIQUE O LOG ANTES DE LIGAR PARA O ANALISTA   *' */
            _.Display($"*        VERIFIQUE O LOG ANTES DE LIGAR PARA O ANALISTA   *");

            /*" -3379- DISPLAY '*    CONFIRMANDO O LOCK, EXECUTAR NOVAMENTE O PROGRAMA    *' */
            _.Display($"*    CONFIRMANDO O LOCK, EXECUTAR NOVAMENTE O PROGRAMA    *");

            /*" -3381- DISPLAY '*                                                         *' */
            _.Display($"*                                                         *");

            /*" -3383- DISPLAY '*  PERMANECENDO O ERRO, CONTACTAR O ANALISTA RESPONSAVEL  *' */
            _.Display($"*  PERMANECENDO O ERRO, CONTACTAR O ANALISTA RESPONSAVEL  *");

            /*" -3385- DISPLAY '*                                                         *' */
            _.Display($"*                                                         *");

            /*" -3387- DISPLAY '*                                                         *' */
            _.Display($"*                                                         *");

            /*" -3389- DISPLAY '*                                                         *' */
            _.Display($"*                                                         *");

            /*" -3391- DISPLAY '*     SQLCODE DO ABEND ....... ' WSQLCODE */
            _.Display($"*     SQLCODE DO ABEND ....... {W.WABEND.WSQLCODE}");

            /*" -3393- DISPLAY '***********************************************************' */
            _.Display($"***********************************************************");

            /*" -3393- GO TO 999-999-ROT-ERRO. */

            M_999_999_ROT_ERRO_SECTION(); //GOTO
            return;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R10010199_EXIT*/
    }
}