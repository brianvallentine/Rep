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
using Sias.VidaAzul.DB2.VA4648B;

namespace Code
{
    public class VA4648B
    {
        public bool IsCall { get; set; }

        public VA4648B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      ******************************************************************      */
        /*"      ******************************************************************      */
        /*"      *                                                                *      */
        /*"      *   FUNCAO ...............  GERA ARQUIVO NO PADRAO SIVPF         *      */
        /*"      *                           COM SEGUROS DE PRODUTOS COM          *      */
        /*"      *                           PAGAMENTO ANUAL                      *      */
        /*"      *                                                                *      */
        /*"      *                           RETENCAO PAR                         *      */
        /*"      *                                                                *      */
        /*"      *   ANALISE/PROGRAMACAO...  EDIVALDO GOMES                       *      */
        /*"      *                                                                *      */
        /*"      *   PROGRAMA .............  VA4648B                              *      */
        /*"      *                                                                *      */
        /*"      *   DATA .................  22/04/2011.                          *      */
        /*"      *                                                                *      */
        /*"      *   CADMUS ...............  55.157                               *      */
        /*"      *                                                                *      */
        /*"1     ******************************************************************      */
        /*"JV.01 *   VERSAO 04 - PROJETO JOINT VENTURE (JV)                       *      */
        /*"=     *             - AVALIAR IMPACTO PRODUTO, APOLICE, ORGAO, ETC.    *      */
        /*"=     *             - Historia: 190050.                                *      */
        /*"=     *    EM 05/02/2019 - HERVAL SOUZA                                *      */
        /*"=     *                                        PROCURE POR JV.01       *      */
        /*"JV.01 *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 03 -   NSGD - CADMUS 103659.                          *      */
        /*"      *               - NOVA SOLUCAO DE GESTAO DE DEPOSITOS            *      */
        /*"      *                                                                *      */
        /*"      *   EM 05/11/2014 - COREON                                       *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.03         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  VERSAO 02 - CAD 10.003                                        *      */
        /*"      *                                                                *      */
        /*"      *             - CONVERSAO DO DB2 PARA A VERSAO 10                *      */
        /*"      *                                                                *      */
        /*"      *  EM 30/09/2013 -  ROGERIO PEREIRA                              *      */
        /*"      *                                                                *      */
        /*"      *                                           PROCURE POR V.02     *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 01 - CAD 67.592                                       *      */
        /*"      *                                                                *      */
        /*"      *         AJUSTE PARA DISPONIBILIZAR INFORMACOES SOBRE O VALOR   *      */
        /*"      *         DE CAPITAL E PREMIO NOS ARQUIVOS A SEREM ENVIADOS A    *      */
        /*"      *         FAST.                                                  *      */
        /*"      *                                                                *      */
        /*"      *   EM 05/07/2012 - AUGUSTO ANASTACIO (FASTCOMPUTER)             *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.01         *      */
        /*"      *----------------------------------------------------------------*      */
        #endregion


        #region VARIABLES

        public FileBasis _MOVTO_PRP_SASSE { get; set; } = new FileBasis(new PIC("X", "300", "X(300)"));

        public FileBasis MOVTO_PRP_SASSE
        {
            get
            {
                _.Move(REG_PRP_SASSE, _MOVTO_PRP_SASSE); VarBasis.RedefinePassValue(REG_PRP_SASSE, _MOVTO_PRP_SASSE, REG_PRP_SASSE); return _MOVTO_PRP_SASSE;
            }
        }
        public FileBasis _MOVTO_PRP_DISC { get; set; } = new FileBasis(new PIC("X", "600", "X(600)"));

        public FileBasis MOVTO_PRP_DISC
        {
            get
            {
                _.Move(REG_PRP_DISC, _MOVTO_PRP_DISC); VarBasis.RedefinePassValue(REG_PRP_DISC, _MOVTO_PRP_DISC, REG_PRP_DISC); return _MOVTO_PRP_DISC;
            }
        }
        /*"01   REG-PRP-SASSE                      PIC X(300).*/
        public StringBasis REG_PRP_SASSE { get; set; } = new StringBasis(new PIC("X", "300", "X(300)."), @"");
        /*"01   REG-PRP-DISC                       PIC X(600).*/
        public StringBasis REG_PRP_DISC { get; set; } = new StringBasis(new PIC("X", "600", "X(600)."), @"");

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77            WHOST-DT-INICIO     PIC  X(10).*/
        public StringBasis WHOST_DT_INICIO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77            WHOST-DT-FIM        PIC  X(10).*/
        public StringBasis WHOST_DT_FIM { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77            WHOST-DT-CORRENTE   PIC  X(10).*/
        public StringBasis WHOST_DT_CORRENTE { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  WS-REG-DISCADOR.*/
        public VA4648B_WS_REG_DISCADOR WS_REG_DISCADOR { get; set; } = new VA4648B_WS_REG_DISCADOR();
        public class VA4648B_WS_REG_DISCADOR : VarBasis
        {
            /*"   05 DISC-COD-PRODUTO                PIC  9(004).*/
            public IntBasis DISC_COD_PRODUTO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"   05 FILLER                          PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"   05 DISC-NOM-PRODUTO                PIC  X(030).*/
            public StringBasis DISC_NOM_PRODUTO { get; set; } = new StringBasis(new PIC("X", "30", "X(030)."), @"");
            /*"   05 FILLER                          PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"   05 DISC-NUM-CERTIFICADO            PIC  9(015).*/
            public IntBasis DISC_NUM_CERTIFICADO { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
            /*"   05 FILLER                          PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"   05 DISC-NOME-CLIENTE               PIC  X(040).*/
            public StringBasis DISC_NOME_CLIENTE { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
            /*"   05 FILLER                          PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"   05 DISC-CPF                        PIC  9(011).*/
            public IntBasis DISC_CPF { get; set; } = new IntBasis(new PIC("9", "11", "9(011)."));
            /*"   05 FILLER                          PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"   05 DISC-DDD1                       PIC  9(002).*/
            public IntBasis DISC_DDD1 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"   05 FILLER                          PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"   05 DISC-TELEFONE1                  PIC  9(009).*/
            public IntBasis DISC_TELEFONE1 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"   05 FILLER                          PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"   05 DISC-DDD2                       PIC  9(002).*/
            public IntBasis DISC_DDD2 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"   05 FILLER                          PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"   05 DISC-TELEFONE2                  PIC  9(009).*/
            public IntBasis DISC_TELEFONE2 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"   05 FILLER                          PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"   05 DISC-DDD3                       PIC  9(002).*/
            public IntBasis DISC_DDD3 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"   05 FILLER                          PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"   05 DISC-TELEFONE3                  PIC  9(009).*/
            public IntBasis DISC_TELEFONE3 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"   05 FILLER                          PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"   05 DISC-ENDERECO                   PIC  X(072).*/
            public StringBasis DISC_ENDERECO { get; set; } = new StringBasis(new PIC("X", "72", "X(072)."), @"");
            /*"   05 FILLER                          PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"   05 DISC-BAIRRO                     PIC  X(072).*/
            public StringBasis DISC_BAIRRO { get; set; } = new StringBasis(new PIC("X", "72", "X(072)."), @"");
            /*"   05 FILLER                          PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"   05 DISC-CIDADE                     PIC  X(072).*/
            public StringBasis DISC_CIDADE { get; set; } = new StringBasis(new PIC("X", "72", "X(072)."), @"");
            /*"   05 FILLER                          PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"   05 DISC-UF                         PIC  X(002).*/
            public StringBasis DISC_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
            /*"   05 FILLER                          PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"   05 DISC-CEP                        PIC  9(009).*/
            public IntBasis DISC_CEP { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"   05 FILLER                          PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"   05 DISC-EMAIL                      PIC  X(040).*/
            public StringBasis DISC_EMAIL { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
            /*"   05 FILLER                          PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"   05 DISC-DATA-INIVIGENCIA           PIC  X(010).*/
            public StringBasis DISC_DATA_INIVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"   05 FILLER                          PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"   05 DISC-DATA-VENCIMENTO            PIC  X(010).*/
            public StringBasis DISC_DATA_VENCIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"   05 FILLER                          PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"   05 DISC-OPCAO-PAGAMENTO            PIC  X(040).*/
            public StringBasis DISC_OPCAO_PAGAMENTO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
            /*"   05 FILLER                          PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"   05 DISC-AGE-CTA-DEBITO             PIC  9(004).*/
            public IntBasis DISC_AGE_CTA_DEBITO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"   05 FILLER                          PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"   05 DISC-OPE-CTA-DEBITO             PIC  9(004).*/
            public IntBasis DISC_OPE_CTA_DEBITO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"   05 FILLER                          PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"   05 DISC-NUM-CTA-DEBITO             PIC  9(012).*/
            public IntBasis DISC_NUM_CTA_DEBITO { get; set; } = new IntBasis(new PIC("9", "12", "9(012)."));
            /*"   05 FILLER                          PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"   05 DISC-DIG-CTA-DEBITO             PIC  9(001).*/
            public IntBasis DISC_DIG_CTA_DEBITO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"   05 FILLER                          PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"   05 DISC-VAL-PREMIO                 PIC  9(013)V99.*/
            public DoubleBasis DISC_VAL_PREMIO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
            /*"   05 FILLER                          PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"   05 DISC-VAL-CAPITAL                PIC  9(014)V99.*/
            public DoubleBasis DISC_VAL_CAPITAL { get; set; } = new DoubleBasis(new PIC("9", "14", "9(014)V99."), 2);
            /*"   05 FILLER                          PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"   05 FILLER                          PIC  X(062) VALUE SPACES.*/
            public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "62", "X(062)"), @"");
            /*"01  WS-CTA-LIDOS                      PIC S9(4)  COMP VALUE +0.*/
        }
        public IntBasis WS_CTA_LIDOS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  WS-SQLCODE-R0711                  PIC S9(4)  COMP VALUE +0.*/
        public IntBasis WS_SQLCODE_R0711 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  WS-SQLCODE-R0720                  PIC S9(4)  COMP VALUE +0.*/
        public IntBasis WS_SQLCODE_R0720 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  WS-MAX-PARCELA                    PIC S9(4)  COMP VALUE +0.*/
        public IntBasis WS_MAX_PARCELA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  WS-CODRET                         PIC S9(4)  COMP VALUE +0.*/
        public IntBasis WS_CODRET { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-FAIXA-RENDA-IND              PIC S9(4)  COMP VALUE +0.*/
        public IntBasis VIND_FAIXA_RENDA_IND { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-FAIXA-RENDA-FAM              PIC S9(4)  COMP VALUE +0.*/
        public IntBasis VIND_FAIXA_RENDA_FAM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-APOS-INVALIDEZ               PIC S9(4)  COMP VALUE +0.*/
        public IntBasis VIND_APOS_INVALIDEZ { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-PROFIS-ESPOSA                PIC S9(4)  COMP VALUE +0.*/
        public IntBasis VIND_PROFIS_ESPOSA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-DTNASC-ESPOSA                PIC S9(4)  COMP VALUE +0.*/
        public IntBasis VIND_DTNASC_ESPOSA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-NOME-ESPOSA                  PIC S9(4)  COMP VALUE +0.*/
        public IntBasis VIND_NOME_ESPOSA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-DPS-TITULAR                  PIC S9(4)  COMP VALUE +0.*/
        public IntBasis VIND_DPS_TITULAR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-DPS-ESPOSA                   PIC S9(4)  COMP VALUE +0.*/
        public IntBasis VIND_DPS_ESPOSA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-OPRCTADEB                    PIC S9(4)  COMP VALUE +0.*/
        public IntBasis VIND_OPRCTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-NUMCTADEB                    PIC S9(4)  COMP VALUE +0.*/
        public IntBasis VIND_NUMCTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-DIGCTADEB                    PIC S9(4)  COMP VALUE +0.*/
        public IntBasis VIND_DIGCTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-INFO-COMP                    PIC S9(4)  COMP VALUE +0.*/
        public IntBasis VIND_INFO_COMP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-COD-CCT                      PIC S9(4)  COMP VALUE +0.*/
        public IntBasis VIND_COD_CCT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-DTNASCI                      PIC S9(4)  COMP VALUE +0.*/
        public IntBasis VIND_DTNASCI { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-DTNASBENEF                   PIC S9(4)  COMP VALUE +0.*/
        public IntBasis VIND_DTNASBENEF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-AGEDEB                       PIC S9(4)  COMP VALUE +0.*/
        public IntBasis VIND_AGEDEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-CPF                          PIC S9(4) COMP VALUE +0.*/
        public IntBasis VIND_CPF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-SEXO                         PIC S9(4) COMP VALUE +0.*/
        public IntBasis VIND_SEXO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-UF-EXP                       PIC S9(4) COMP VALUE +0.*/
        public IntBasis VIND_UF_EXP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-COD-CBO                      PIC S9(4) COMP VALUE +0.*/
        public IntBasis VIND_COD_CBO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-TP-IDENT                     PIC S9(4) COMP VALUE +0.*/
        public IntBasis VIND_TP_IDENT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-DTEXPEDI                     PIC S9(4) COMP VALUE +0.*/
        public IntBasis VIND_DTEXPEDI { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-COD-USUR                     PIC S9(4) COMP VALUE +0.*/
        public IntBasis VIND_COD_USUR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-NUM-IDENT                    PIC S9(4) COMP VALUE +0.*/
        public IntBasis VIND_NUM_IDENT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-ORGAO-EXP                    PIC S9(4) COMP VALUE +0.*/
        public IntBasis VIND_ORGAO_EXP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-TIMESTAMP                    PIC S9(4) COMP VALUE +0.*/
        public IntBasis VIND_TIMESTAMP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-COD-PESSOA                   PIC S9(4) COMP VALUE +0.*/
        public IntBasis VIND_COD_PESSOA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-NRCERTIF                     PIC S9(4) COMP VALUE +0.*/
        public IntBasis VIND_NRCERTIF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  COD-CBO-TIT                       PIC S9(9)  COMP.*/
        public IntBasis COD_CBO_TIT { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"01  COD-CBO-CONJ                      PIC S9(9)  COMP.*/
        public IntBasis COD_CBO_CONJ { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"01  VIND-COD-UF                       PIC S9(4)  COMP.*/
        public IntBasis VIND_COD_UF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  WAREA-AUXILIAR.*/
        public VA4648B_WAREA_AUXILIAR WAREA_AUXILIAR { get; set; } = new VA4648B_WAREA_AUXILIAR();
        public class VA4648B_WAREA_AUXILIAR : VarBasis
        {
            /*"    05       WS-DTH-CRITICA       PIC  9(008).*/
            public IntBasis WS_DTH_CRITICA { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"    05       WS-DTH-CRITICA-R     REDEFINES   WS-DTH-CRITICA.*/
            private _REDEF_VA4648B_WS_DTH_CRITICA_R _ws_dth_critica_r { get; set; }
            public _REDEF_VA4648B_WS_DTH_CRITICA_R WS_DTH_CRITICA_R
            {
                get { _ws_dth_critica_r = new _REDEF_VA4648B_WS_DTH_CRITICA_R(); _.Move(WS_DTH_CRITICA, _ws_dth_critica_r); VarBasis.RedefinePassValue(WS_DTH_CRITICA, _ws_dth_critica_r, WS_DTH_CRITICA); _ws_dth_critica_r.ValueChanged += () => { _.Move(_ws_dth_critica_r, WS_DTH_CRITICA); }; return _ws_dth_critica_r; }
                set { VarBasis.RedefinePassValue(value, _ws_dth_critica_r, WS_DTH_CRITICA); }
            }  //Redefines
            public class _REDEF_VA4648B_WS_DTH_CRITICA_R : VarBasis
            {
                /*"      10     WS-CRITICA-ANO       PIC  9(004).*/
                public IntBasis WS_CRITICA_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      10     WS-CRITICA-MES       PIC  9(002).*/
                public IntBasis WS_CRITICA_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10     WS-CRITICA-DIA       PIC  9(002).*/
                public IntBasis WS_CRITICA_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05  WS-ERRO-DATA                  PIC X(003)  VALUE SPACES.*/

                public _REDEF_VA4648B_WS_DTH_CRITICA_R()
                {
                    WS_CRITICA_ANO.ValueChanged += OnValueChanged;
                    WS_CRITICA_MES.ValueChanged += OnValueChanged;
                    WS_CRITICA_DIA.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WS_ERRO_DATA { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"    05  AUX-RESULTADO                 PIC 9(009)  VALUE ZEROS.*/
            public IntBasis AUX_RESULTADO { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    05  AUX-RESTO                     PIC 9(009)  VALUE ZEROS.*/
            public IntBasis AUX_RESTO { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    05  W-FIM-PROPOVA                 PIC X(003)  VALUE SPACES.*/
            public StringBasis W_FIM_PROPOVA { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"    05  W-FIM-OBTER-DATA              PIC X(003)  VALUE SPACES.*/
            public StringBasis W_FIM_OBTER_DATA { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"    05  W-FIM-BENEFICIARIOS           PIC X(003)  VALUE SPACES.*/
            public StringBasis W_FIM_BENEFICIARIOS { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"    05  W-FIM-BILHETE-COB             PIC X(003)  VALUE SPACES.*/
            public StringBasis W_FIM_BILHETE_COB { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"    05  W-EXISTE-FIDELIZ              PIC X(003)  VALUE SPACES.*/
            public StringBasis W_EXISTE_FIDELIZ { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"    05  W-FIM-CURSOR-EMAIL            PIC X(003)  VALUE SPACES.*/
            public StringBasis W_FIM_CURSOR_EMAIL { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"    05  W-FIM-CURSOR-ENDERECO         PIC X(003)  VALUE SPACES.*/
            public StringBasis W_FIM_CURSOR_ENDERECO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"    05  W-FIM-CURSOR-TELEFONE         PIC X(003)  VALUE SPACES.*/
            public StringBasis W_FIM_CURSOR_TELEFONE { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"    05  W-TOT-PROCESSADO              PIC 9(006)  VALUE ZEROS.*/
            public IntBasis W_TOT_PROCESSADO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05  W-AC-CONTROLE                 PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_AC_CONTROLE { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-INDEX                       PIC  9(01)  VALUE ZERO.*/
            public IntBasis W_INDEX { get; set; } = new IntBasis(new PIC("9", "1", "9(01)"));
            /*"    05  W-IND-BENEF                   PIC  9(02)  VALUE ZEROS.*/
            public IntBasis W_IND_BENEF { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
            /*"    05  W-IND-BENEF1                  PIC  9(02)  VALUE ZEROS.*/
            public IntBasis W_IND_BENEF1 { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
            /*"    05  W-COD-OPERACAO                PIC  9(03)  VALUE ZEROS.*/
            public IntBasis W_COD_OPERACAO { get; set; } = new IntBasis(new PIC("9", "3", "9(03)"));
            /*"    05  W-COD-RETBANCO                PIC  9(02)  VALUE ZEROS.*/
            public IntBasis W_COD_RETBANCO { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
            /*"    05  W-TIME                        PIC X(08).*/
            public StringBasis W_TIME { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
            /*"    05  W-TIME-EDIT                   PIC 99.99.99.99.*/
            public IntBasis W_TIME_EDIT { get; set; } = new IntBasis(new PIC("9", "8", "99.99.99.99."));
            /*"    05  W-DESPREZADO                  PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_DESPREZADO { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-TIPO-0               PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_TIPO_0 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-TIPO-1               PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_TIPO_1 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-TIPO-2               PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_TIPO_2 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-TIPO-3               PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_TIPO_3 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-TIPO-4               PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_TIPO_4 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-TIPO-5               PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_TIPO_5 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-TIPO-6               PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_TIPO_6 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-TIPO-7               PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_TIPO_7 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-TIPO-8               PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_TIPO_8 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-TIPO-9               PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_TIPO_9 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-TIPO-A               PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_TIPO_A { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-TIPO-B               PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_TIPO_B { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-TIPO-C               PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_TIPO_C { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-TIPO-D               PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_TIPO_D { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-TIPO-E               PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_TIPO_E { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-TIPO-F               PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_TIPO_F { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-TIPO-G               PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_TIPO_G { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-TIPO-H               PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_TIPO_H { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-TIPO-I               PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_TIPO_I { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-TIPO-J               PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_TIPO_J { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-TOT-GERADO-PRP              PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_TOT_GERADO_PRP { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-SEQ-FONE                    PIC 9(004)  VALUE ZEROS.*/
            public IntBasis W_SEQ_FONE { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"    05  W-SEQ-EMAIL                   PIC 9(004)  VALUE ZEROS.*/
            public IntBasis W_SEQ_EMAIL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"    05  W-COD-PESSOA                  PIC 9(009)  VALUE ZEROS.*/
            public IntBasis W_COD_PESSOA { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    05  W-COD-RELACION                PIC 9(004)  VALUE ZEROS.*/
            public IntBasis W_COD_RELACION { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"    05  W-ACHOU-EMAIL                 PIC X(003)  VALUE 'NAO'.*/
            public StringBasis W_ACHOU_EMAIL { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
            /*"    05  W-ACHOU-FILIAL                PIC X(003)  VALUE 'NAO'.*/
            public StringBasis W_ACHOU_FILIAL { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
            /*"    05  W-ACHOU-AGENCIA               PIC X(003)  VALUE 'NAO'.*/
            public StringBasis W_ACHOU_AGENCIA { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
            /*"    05  W-ACHOU-TELEFONE              PIC X(003)  VALUE 'NAO'.*/
            public StringBasis W_ACHOU_TELEFONE { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
            /*"    05  W-ACHOU-ENDERECO              PIC X(003)  VALUE 'NAO'.*/
            public StringBasis W_ACHOU_ENDERECO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
            /*"    05  W-ACHOU-PROFISSAO             PIC X(003)  VALUE 'NAO'.*/
            public StringBasis W_ACHOU_PROFISSAO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
            /*"    05  W-ACHOU-RELACIONAMENTO        PIC X(003)  VALUE 'NAO'.*/
            public StringBasis W_ACHOU_RELACIONAMENTO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
            /*"    05  W-OCORR-ENDERECO              PIC 9(004)  VALUE ZEROS.*/
            public IntBasis W_OCORR_ENDERECO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"    05  W-OBTER-MAX-RELAC             PIC X(003)  VALUE 'NAO'.*/
            public StringBasis W_OBTER_MAX_RELAC { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
            /*"    05  W-OBTER-MAX-PESSOA            PIC X(003)  VALUE 'NAO'.*/
            public StringBasis W_OBTER_MAX_PESSOA { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
            /*"    05  W-NUM-IDENTIF                 PIC 9(015)  VALUE ZEROS.*/
            public IntBasis W_NUM_IDENTIF { get; set; } = new IntBasis(new PIC("9", "15", "9(015)"));
            /*"    05  W-NUM-BENEF                   PIC 9(004)  VALUE ZEROS.*/
            public IntBasis W_NUM_BENEF { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"    05  W-PRAZO-PERCEPCAO             PIC 9(002)  VALUE ZEROS.*/
            public IntBasis W_PRAZO_PERCEPCAO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"    05  FILLER REDEFINES W-PRAZO-PERCEPCAO.*/
            private _REDEF_VA4648B_FILLER_27 _filler_27 { get; set; }
            public _REDEF_VA4648B_FILLER_27 FILLER_27
            {
                get { _filler_27 = new _REDEF_VA4648B_FILLER_27(); _.Move(W_PRAZO_PERCEPCAO, _filler_27); VarBasis.RedefinePassValue(W_PRAZO_PERCEPCAO, _filler_27, W_PRAZO_PERCEPCAO); _filler_27.ValueChanged += () => { _.Move(_filler_27, W_PRAZO_PERCEPCAO); }; return _filler_27; }
                set { VarBasis.RedefinePassValue(value, _filler_27, W_PRAZO_PERCEPCAO); }
            }  //Redefines
            public class _REDEF_VA4648B_FILLER_27 : VarBasis
            {
                /*"        07  W-PERCEPCAO               PIC X(002).*/
                public StringBasis W_PERCEPCAO { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"    05  W-NR-IDENTIDADE               PIC 9(008)  VALUE ZEROS.*/

                public _REDEF_VA4648B_FILLER_27()
                {
                    W_PERCEPCAO.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis W_NR_IDENTIDADE { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05  FILLER REDEFINES W-NR-IDENTIDADE.*/
            private _REDEF_VA4648B_FILLER_28 _filler_28 { get; set; }
            public _REDEF_VA4648B_FILLER_28 FILLER_28
            {
                get { _filler_28 = new _REDEF_VA4648B_FILLER_28(); _.Move(W_NR_IDENTIDADE, _filler_28); VarBasis.RedefinePassValue(W_NR_IDENTIDADE, _filler_28, W_NR_IDENTIDADE); _filler_28.ValueChanged += () => { _.Move(_filler_28, W_NR_IDENTIDADE); }; return _filler_28; }
                set { VarBasis.RedefinePassValue(value, _filler_28, W_NR_IDENTIDADE); }
            }  //Redefines
            public class _REDEF_VA4648B_FILLER_28 : VarBasis
            {
                /*"        07  W-NR-RG                   PIC X(008).*/
                public StringBasis W_NR_RG { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
                /*"    05  W-NSAS                        PIC 9(006).*/

                public _REDEF_VA4648B_FILLER_28()
                {
                    W_NR_RG.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis W_NSAS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"    05  W-NSL                         PIC 9(006).*/
            public IntBasis W_NSL { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"    05  W-CONTROLE                    PIC 9(006).*/
            public IntBasis W_CONTROLE { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"    05  W-CONTROLE-TP-0               PIC 9(001)  VALUE ZERO.*/
            public IntBasis W_CONTROLE_TP_0 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*"    05  W-DATA-TRABALHO               PIC 9(008)  VALUE ZEROS.*/
            public IntBasis W_DATA_TRABALHO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05  FILLER REDEFINES W-DATA-TRABALHO.*/
            private _REDEF_VA4648B_FILLER_29 _filler_29 { get; set; }
            public _REDEF_VA4648B_FILLER_29 FILLER_29
            {
                get { _filler_29 = new _REDEF_VA4648B_FILLER_29(); _.Move(W_DATA_TRABALHO, _filler_29); VarBasis.RedefinePassValue(W_DATA_TRABALHO, _filler_29, W_DATA_TRABALHO); _filler_29.ValueChanged += () => { _.Move(_filler_29, W_DATA_TRABALHO); }; return _filler_29; }
                set { VarBasis.RedefinePassValue(value, _filler_29, W_DATA_TRABALHO); }
            }  //Redefines
            public class _REDEF_VA4648B_FILLER_29 : VarBasis
            {
                /*"        07  W-DIA-TRABALHO            PIC 9(002).*/
                public IntBasis W_DIA_TRABALHO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"        07  W-MES-TRABALHO            PIC 9(002).*/
                public IntBasis W_MES_TRABALHO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"        07  W-ANO-TRABALHO            PIC 9(004).*/
                public IntBasis W_ANO_TRABALHO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05  W-DATA-NASCIMENTO             PIC 9(008)  VALUE ZEROS.*/

                public _REDEF_VA4648B_FILLER_29()
                {
                    W_DIA_TRABALHO.ValueChanged += OnValueChanged;
                    W_MES_TRABALHO.ValueChanged += OnValueChanged;
                    W_ANO_TRABALHO.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis W_DATA_NASCIMENTO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05  FILLER REDEFINES W-DATA-NASCIMENTO.*/
            private _REDEF_VA4648B_FILLER_30 _filler_30 { get; set; }
            public _REDEF_VA4648B_FILLER_30 FILLER_30
            {
                get { _filler_30 = new _REDEF_VA4648B_FILLER_30(); _.Move(W_DATA_NASCIMENTO, _filler_30); VarBasis.RedefinePassValue(W_DATA_NASCIMENTO, _filler_30, W_DATA_NASCIMENTO); _filler_30.ValueChanged += () => { _.Move(_filler_30, W_DATA_NASCIMENTO); }; return _filler_30; }
                set { VarBasis.RedefinePassValue(value, _filler_30, W_DATA_NASCIMENTO); }
            }  //Redefines
            public class _REDEF_VA4648B_FILLER_30 : VarBasis
            {
                /*"        07  W-DIA-NASCIMENTO          PIC 9(002).*/
                public IntBasis W_DIA_NASCIMENTO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"        07  W-MES-NASCIMENTO          PIC 9(002).*/
                public IntBasis W_MES_NASCIMENTO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"        07  W-ANO-NASCIMENTO          PIC 9(004).*/
                public IntBasis W_ANO_NASCIMENTO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05  HOST-DT-TERVIG1               PIC X(010)  VALUE        '1999-12-31'.*/

                public _REDEF_VA4648B_FILLER_30()
                {
                    W_DIA_NASCIMENTO.ValueChanged += OnValueChanged;
                    W_MES_NASCIMENTO.ValueChanged += OnValueChanged;
                    W_ANO_NASCIMENTO.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis HOST_DT_TERVIG1 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"1999-12-31");
            /*"    05  HOST-DT-TERVIG2               PIC X(010)  VALUE        '9999-12-31'.*/
            public StringBasis HOST_DT_TERVIG2 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"9999-12-31");
            /*"    05  W-DTMOVABE                    PIC X(010).*/
            public StringBasis W_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    05  W-DTMOVABE1 REDEFINES W-DTMOVABE.*/
            private _REDEF_VA4648B_W_DTMOVABE1 _w_dtmovabe1 { get; set; }
            public _REDEF_VA4648B_W_DTMOVABE1 W_DTMOVABE1
            {
                get { _w_dtmovabe1 = new _REDEF_VA4648B_W_DTMOVABE1(); _.Move(W_DTMOVABE, _w_dtmovabe1); VarBasis.RedefinePassValue(W_DTMOVABE, _w_dtmovabe1, W_DTMOVABE); _w_dtmovabe1.ValueChanged += () => { _.Move(_w_dtmovabe1, W_DTMOVABE); }; return _w_dtmovabe1; }
                set { VarBasis.RedefinePassValue(value, _w_dtmovabe1, W_DTMOVABE); }
            }  //Redefines
            public class _REDEF_VA4648B_W_DTMOVABE1 : VarBasis
            {
                /*"        07  W-ANO-MOVABE              PIC 9(004).*/
                public IntBasis W_ANO_MOVABE { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"        07  W-BARRA1                  PIC X(001).*/
                public StringBasis W_BARRA1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"        07  W-MES-MOVABE              PIC 9(002).*/
                public IntBasis W_MES_MOVABE { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"        07  W-BARRA2                  PIC X(001).*/
                public StringBasis W_BARRA2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"        07  W-DIA-MOVABE              PIC 9(002).*/
                public IntBasis W_DIA_MOVABE { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05  W-DTMOVABE-I                  PIC X(010).*/

                public _REDEF_VA4648B_W_DTMOVABE1()
                {
                    W_ANO_MOVABE.ValueChanged += OnValueChanged;
                    W_BARRA1.ValueChanged += OnValueChanged;
                    W_MES_MOVABE.ValueChanged += OnValueChanged;
                    W_BARRA2.ValueChanged += OnValueChanged;
                    W_DIA_MOVABE.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis W_DTMOVABE_I { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    05  W-DTMOVABE-I1 REDEFINES W-DTMOVABE-I.*/
            private _REDEF_VA4648B_W_DTMOVABE_I1 _w_dtmovabe_i1 { get; set; }
            public _REDEF_VA4648B_W_DTMOVABE_I1 W_DTMOVABE_I1
            {
                get { _w_dtmovabe_i1 = new _REDEF_VA4648B_W_DTMOVABE_I1(); _.Move(W_DTMOVABE_I, _w_dtmovabe_i1); VarBasis.RedefinePassValue(W_DTMOVABE_I, _w_dtmovabe_i1, W_DTMOVABE_I); _w_dtmovabe_i1.ValueChanged += () => { _.Move(_w_dtmovabe_i1, W_DTMOVABE_I); }; return _w_dtmovabe_i1; }
                set { VarBasis.RedefinePassValue(value, _w_dtmovabe_i1, W_DTMOVABE_I); }
            }  //Redefines
            public class _REDEF_VA4648B_W_DTMOVABE_I1 : VarBasis
            {
                /*"        07  W-DIA-MOVABE              PIC 9(002).*/
                public IntBasis W_DIA_MOVABE_0 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"        07  W-BARRA1                  PIC X(001).*/
                public StringBasis W_BARRA1_0 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"        07  W-MES-MOVABE              PIC 9(002).*/
                public IntBasis W_MES_MOVABE_0 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"        07  W-BARRA2                  PIC X(001).*/
                public StringBasis W_BARRA2_0 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"        07  W-ANO-MOVABE              PIC 9(004).*/
                public IntBasis W_ANO_MOVABE_0 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05  W-DATA-SQL                    PIC X(010).*/

                public _REDEF_VA4648B_W_DTMOVABE_I1()
                {
                    W_DIA_MOVABE_0.ValueChanged += OnValueChanged;
                    W_BARRA1_0.ValueChanged += OnValueChanged;
                    W_MES_MOVABE_0.ValueChanged += OnValueChanged;
                    W_BARRA2_0.ValueChanged += OnValueChanged;
                    W_ANO_MOVABE_0.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis W_DATA_SQL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    05  W-DATA-SQL1 REDEFINES W-DATA-SQL.*/
            private _REDEF_VA4648B_W_DATA_SQL1 _w_data_sql1 { get; set; }
            public _REDEF_VA4648B_W_DATA_SQL1 W_DATA_SQL1
            {
                get { _w_data_sql1 = new _REDEF_VA4648B_W_DATA_SQL1(); _.Move(W_DATA_SQL, _w_data_sql1); VarBasis.RedefinePassValue(W_DATA_SQL, _w_data_sql1, W_DATA_SQL); _w_data_sql1.ValueChanged += () => { _.Move(_w_data_sql1, W_DATA_SQL); }; return _w_data_sql1; }
                set { VarBasis.RedefinePassValue(value, _w_data_sql1, W_DATA_SQL); }
            }  //Redefines
            public class _REDEF_VA4648B_W_DATA_SQL1 : VarBasis
            {
                /*"        07  W-ANO-SQL                 PIC 9(004).*/
                public IntBasis W_ANO_SQL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"        07  W-BARRA1                  PIC X(001).*/
                public StringBasis W_BARRA1_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"        07  W-MES-SQL                 PIC 9(002).*/
                public IntBasis W_MES_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"        07  W-BARRA2                  PIC X(001).*/
                public StringBasis W_BARRA2_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"        07  W-DIA-SQL                 PIC 9(002).*/
                public IntBasis W_DIA_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05  W-NR-SICOB                    PIC 9(015).*/

                public _REDEF_VA4648B_W_DATA_SQL1()
                {
                    W_ANO_SQL.ValueChanged += OnValueChanged;
                    W_BARRA1_1.ValueChanged += OnValueChanged;
                    W_MES_SQL.ValueChanged += OnValueChanged;
                    W_BARRA2_1.ValueChanged += OnValueChanged;
                    W_DIA_SQL.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis W_NR_SICOB { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
            /*"    05  FILLER REDEFINES W-NR-SICOB.*/
            private _REDEF_VA4648B_FILLER_31 _filler_31 { get; set; }
            public _REDEF_VA4648B_FILLER_31 FILLER_31
            {
                get { _filler_31 = new _REDEF_VA4648B_FILLER_31(); _.Move(W_NR_SICOB, _filler_31); VarBasis.RedefinePassValue(W_NR_SICOB, _filler_31, W_NR_SICOB); _filler_31.ValueChanged += () => { _.Move(_filler_31, W_NR_SICOB); }; return _filler_31; }
                set { VarBasis.RedefinePassValue(value, _filler_31, W_NR_SICOB); }
            }  //Redefines
            public class _REDEF_VA4648B_FILLER_31 : VarBasis
            {
                /*"        07  W-NR-PROD-SICOB           PIC 9(003).*/
                public IntBasis W_NR_PROD_SICOB { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"        07  W-NR-NSAC-SICOB           PIC 9(006).*/
                public IntBasis W_NR_NSAC_SICOB { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"        07  W-NR-NSL-SICOB            PIC 9(006).*/
                public IntBasis W_NR_NSL_SICOB { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"    05  W-NOM-ORGAO-EXP               PIC X(030).*/

                public _REDEF_VA4648B_FILLER_31()
                {
                    W_NR_PROD_SICOB.ValueChanged += OnValueChanged;
                    W_NR_NSAC_SICOB.ValueChanged += OnValueChanged;
                    W_NR_NSL_SICOB.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis W_NOM_ORGAO_EXP { get; set; } = new StringBasis(new PIC("X", "30", "X(030)."), @"");
            /*"    05  FILLER REDEFINES W-NOM-ORGAO-EXP.*/
            private _REDEF_VA4648B_FILLER_32 _filler_32 { get; set; }
            public _REDEF_VA4648B_FILLER_32 FILLER_32
            {
                get { _filler_32 = new _REDEF_VA4648B_FILLER_32(); _.Move(W_NOM_ORGAO_EXP, _filler_32); VarBasis.RedefinePassValue(W_NOM_ORGAO_EXP, _filler_32, W_NOM_ORGAO_EXP); _filler_32.ValueChanged += () => { _.Move(_filler_32, W_NOM_ORGAO_EXP); }; return _filler_32; }
                set { VarBasis.RedefinePassValue(value, _filler_32, W_NOM_ORGAO_EXP); }
            }  //Redefines
            public class _REDEF_VA4648B_FILLER_32 : VarBasis
            {
                /*"        07  W-ORGAO-EXPEDIDOR         PIC X(005).*/
                public StringBasis W_ORGAO_EXPEDIDOR { get; set; } = new StringBasis(new PIC("X", "5", "X(005)."), @"");
                /*"        07  FILLER                    PIC X(025).*/
                public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)."), @"");
                /*"    05 W-OBTER-DADOS-RG               PIC  9(001) VALUE ZERO.*/

                public _REDEF_VA4648B_FILLER_32()
                {
                    W_ORGAO_EXPEDIDOR.ValueChanged += OnValueChanged;
                    FILLER_33.ValueChanged += OnValueChanged;
                }

            }

            public SelectorBasis W_OBTER_DADOS_RG { get; set; } = new SelectorBasis("001", "ZERO")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 OBTEVE-DADOS-RG                         VALUE 1. */
							new SelectorItemBasis("OBTEVE_DADOS_RG", "1")
                }
            };

            /*"    05 W-CONVERSAO                    PIC  9(001) VALUE ZERO.*/

            public SelectorBasis W_CONVERSAO { get; set; } = new SelectorBasis("001", "ZERO")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 CONVERSAO-CADASTRADA                    VALUE 1. */
							new SelectorItemBasis("CONVERSAO_CADASTRADA", "1")
                }
            };

            /*"    05  W-NUM-PROPOSTA-NOVA           PIC 9(014).*/
            public IntBasis W_NUM_PROPOSTA_NOVA { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
            /*"    05  FILLER REDEFINES W-NUM-PROPOSTA-NOVA.*/
            private _REDEF_VA4648B_FILLER_34 _filler_34 { get; set; }
            public _REDEF_VA4648B_FILLER_34 FILLER_34
            {
                get { _filler_34 = new _REDEF_VA4648B_FILLER_34(); _.Move(W_NUM_PROPOSTA_NOVA, _filler_34); VarBasis.RedefinePassValue(W_NUM_PROPOSTA_NOVA, _filler_34, W_NUM_PROPOSTA_NOVA); _filler_34.ValueChanged += () => { _.Move(_filler_34, W_NUM_PROPOSTA_NOVA); }; return _filler_34; }
                set { VarBasis.RedefinePassValue(value, _filler_34, W_NUM_PROPOSTA_NOVA); }
            }  //Redefines
            public class _REDEF_VA4648B_FILLER_34 : VarBasis
            {
                /*"        07  W-NUM-PROPOSTA-ATUAL      PIC 9(013).*/
                public IntBasis W_NUM_PROPOSTA_ATUAL { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
                /*"        07  W-DV-PROPOSTA-NOVA        PIC 9(001).*/
                public IntBasis W_DV_PROPOSTA_NOVA { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    05  W-NUM-PROPOSTA                PIC 9(014).*/

                public _REDEF_VA4648B_FILLER_34()
                {
                    W_NUM_PROPOSTA_ATUAL.ValueChanged += OnValueChanged;
                    W_DV_PROPOSTA_NOVA.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis W_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
            /*"    05  CANAL  REDEFINES W-NUM-PROPOSTA.*/
            private _REDEF_VA4648B_CANAL _canal { get; set; }
            public _REDEF_VA4648B_CANAL CANAL
            {
                get { _canal = new _REDEF_VA4648B_CANAL(); _.Move(W_NUM_PROPOSTA, _canal); VarBasis.RedefinePassValue(W_NUM_PROPOSTA, _canal, W_NUM_PROPOSTA); _canal.ValueChanged += () => { _.Move(_canal, W_NUM_PROPOSTA); }; return _canal; }
                set { VarBasis.RedefinePassValue(value, _canal, W_NUM_PROPOSTA); }
            }  //Redefines
            public class _REDEF_VA4648B_CANAL : VarBasis
            {
                /*"        07  W-CANAL-PROPOSTA          PIC 9(001).*/

                public SelectorBasis W_CANAL_PROPOSTA { get; set; } = new SelectorBasis("001")
                {
                    Items = new List<SelectorItemBasis> {
                            /*" 88 CANAL-VENDA-PAPEL                  VALUE 0, 6. */
							new SelectorItemBasis("CANAL_VENDA_PAPEL", "0,6"),
							/*" 88 CANAL-VENDA-CEF                    VALUE 1. */
							new SelectorItemBasis("CANAL_VENDA_CEF", "1"),
							/*" 88 CANAL-SASSE-FILIAL                 VALUE 2. */
							new SelectorItemBasis("CANAL_SASSE_FILIAL", "2"),
							/*" 88 CANAL-CORRETOR                     VALUE 3. */
							new SelectorItemBasis("CANAL_CORRETOR", "3"),
							/*" 88 CANAL-CORREIO                      VALUE 4. */
							new SelectorItemBasis("CANAL_CORREIO", "4"),
							/*" 88 CANAL-GITEL                        VALUE 5. */
							new SelectorItemBasis("CANAL_GITEL", "5"),
							/*" 88 CANAL-INTERNET                     VALUE 7. */
							new SelectorItemBasis("CANAL_INTERNET", "7"),
							/*" 88 CANAL-INTRANET                     VALUE 8. */
							new SelectorItemBasis("CANAL_INTRANET", "8")
                }
                };

                /*"        07  FILLER                    PIC X(013).*/
                public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)."), @"");
                /*"    05  FAIXAS  REDEFINES W-NUM-PROPOSTA.*/

                public _REDEF_VA4648B_CANAL()
                {
                    W_CANAL_PROPOSTA.ValueChanged += OnValueChanged;
                    FILLER_35.ValueChanged += OnValueChanged;
                }

            }
            private _REDEF_VA4648B_FAIXAS _faixas { get; set; }
            public _REDEF_VA4648B_FAIXAS FAIXAS
            {
                get { _faixas = new _REDEF_VA4648B_FAIXAS(); _.Move(W_NUM_PROPOSTA, _faixas); VarBasis.RedefinePassValue(W_NUM_PROPOSTA, _faixas, W_NUM_PROPOSTA); _faixas.ValueChanged += () => { _.Move(_faixas, W_NUM_PROPOSTA); }; return _faixas; }
                set { VarBasis.RedefinePassValue(value, _faixas, W_NUM_PROPOSTA); }
            }  //Redefines
            public class _REDEF_VA4648B_FAIXAS : VarBasis
            {
                /*"        07  FILLER                    PIC 9(003).*/
                public IntBasis FILLER_36 { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"        07  FAIXA-NUMERACAO           PIC 9(003).*/

                public SelectorBasis FAIXA_NUMERACAO { get; set; } = new SelectorBasis("003")
                {
                    Items = new List<SelectorItemBasis> {
                            /*" 88 FAIXA-NUMERACAO-MULT-SUPER VALUE               845, 846. */
							new SelectorItemBasis("FAIXA_NUMERACAO_MULT_SUPER", "845,846"),
							/*" 88 FAIXA-NUMERACAO-MULT       VALUE               848, 850. */
							new SelectorItemBasis("FAIXA_NUMERACAO_MULT", "848,850"),
							/*" 88 FAIXA-NUMERACAO-BILHETE    VALUE               823, 824, 826, 827, 829, 837, 850, 845, 846. */
							new SelectorItemBasis("FAIXA_NUMERACAO_BILHETE", "823,824,826,827,829,837,850,845,846"),
							/*" 88 FAIXA-NUMERACAO-SENIOR     VALUE               821, 850, 845, 846. */
							new SelectorItemBasis("FAIXA_NUMERACAO_SENIOR", "821,850,845,846"),
							/*" 88 FAIXA-NUMERACAO-EXECUTIVO  VALUE               821, 850, 845, 846. */
							new SelectorItemBasis("FAIXA_NUMERACAO_EXECUTIVO", "821,850,845,846"),
							/*" 88 FAIXA-NUMERACAO-AUTO       VALUE               828, 837, 847, 845, 846. */
							new SelectorItemBasis("FAIXA_NUMERACAO_AUTO", "828,837,847,845,846")
                }
                };

                /*"        07  FILLER                    PIC 9(008).*/
                public IntBasis FILLER_37 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"    05  W-NUMR-TITULO               PIC  9(013)   VALUE ZEROS.*/

                public _REDEF_VA4648B_FAIXAS()
                {
                    FILLER_36.ValueChanged += OnValueChanged;
                    FAIXA_NUMERACAO.ValueChanged += OnValueChanged;
                    FILLER_37.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis W_NUMR_TITULO { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
            /*"    05  FILLER                      REDEFINES    W-NUMR-TITULO.*/
            private _REDEF_VA4648B_FILLER_38 _filler_38 { get; set; }
            public _REDEF_VA4648B_FILLER_38 FILLER_38
            {
                get { _filler_38 = new _REDEF_VA4648B_FILLER_38(); _.Move(W_NUMR_TITULO, _filler_38); VarBasis.RedefinePassValue(W_NUMR_TITULO, _filler_38, W_NUMR_TITULO); _filler_38.ValueChanged += () => { _.Move(_filler_38, W_NUMR_TITULO); }; return _filler_38; }
                set { VarBasis.RedefinePassValue(value, _filler_38, W_NUMR_TITULO); }
            }  //Redefines
            public class _REDEF_VA4648B_FILLER_38 : VarBasis
            {
                /*"      10    WTITL-ZEROS             PIC  9(002).*/
                public IntBasis WTITL_ZEROS { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10    WTITL-SEQUENCIA         PIC  9(010).*/
                public IntBasis WTITL_SEQUENCIA { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
                /*"      10    WTITL-DIGITO            PIC  9(001).*/
                public IntBasis WTITL_DIGITO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    05              DPARM01X.*/

                public _REDEF_VA4648B_FILLER_38()
                {
                    WTITL_ZEROS.ValueChanged += OnValueChanged;
                    WTITL_SEQUENCIA.ValueChanged += OnValueChanged;
                    WTITL_DIGITO.ValueChanged += OnValueChanged;
                }

            }
            public VA4648B_DPARM01X DPARM01X { get; set; } = new VA4648B_DPARM01X();
            public class VA4648B_DPARM01X : VarBasis
            {
                /*"      07            DPARM01           PIC  9(010).*/
                public IntBasis DPARM01 { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
                /*"      07            DPARM01-R         REDEFINES   DPARM01.*/
                private _REDEF_VA4648B_DPARM01_R _dparm01_r { get; set; }
                public _REDEF_VA4648B_DPARM01_R DPARM01_R
                {
                    get { _dparm01_r = new _REDEF_VA4648B_DPARM01_R(); _.Move(DPARM01, _dparm01_r); VarBasis.RedefinePassValue(DPARM01, _dparm01_r, DPARM01); _dparm01_r.ValueChanged += () => { _.Move(_dparm01_r, DPARM01); }; return _dparm01_r; }
                    set { VarBasis.RedefinePassValue(value, _dparm01_r, DPARM01); }
                }  //Redefines
                public class _REDEF_VA4648B_DPARM01_R : VarBasis
                {
                    /*"        10          DPARM01-1         PIC  9(001).*/
                    public IntBasis DPARM01_1 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        10          DPARM01-2         PIC  9(001).*/
                    public IntBasis DPARM01_2 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        10          DPARM01-3         PIC  9(001).*/
                    public IntBasis DPARM01_3 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        10          DPARM01-4         PIC  9(001).*/
                    public IntBasis DPARM01_4 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        10          DPARM01-5         PIC  9(001).*/
                    public IntBasis DPARM01_5 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        10          DPARM01-6         PIC  9(001).*/
                    public IntBasis DPARM01_6 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        10          DPARM01-7         PIC  9(001).*/
                    public IntBasis DPARM01_7 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        10          DPARM01-8         PIC  9(001).*/
                    public IntBasis DPARM01_8 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        10          DPARM01-9         PIC  9(001).*/
                    public IntBasis DPARM01_9 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        10          DPARM01-10        PIC  9(001).*/
                    public IntBasis DPARM01_10 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"      07            DPARM01-D1        PIC  9(001).*/

                    public _REDEF_VA4648B_DPARM01_R()
                    {
                        DPARM01_1.ValueChanged += OnValueChanged;
                        DPARM01_2.ValueChanged += OnValueChanged;
                        DPARM01_3.ValueChanged += OnValueChanged;
                        DPARM01_4.ValueChanged += OnValueChanged;
                        DPARM01_5.ValueChanged += OnValueChanged;
                        DPARM01_6.ValueChanged += OnValueChanged;
                        DPARM01_7.ValueChanged += OnValueChanged;
                        DPARM01_8.ValueChanged += OnValueChanged;
                        DPARM01_9.ValueChanged += OnValueChanged;
                        DPARM01_10.ValueChanged += OnValueChanged;
                    }

                }
                public IntBasis DPARM01_D1 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"      07            DPARM01-RC        PIC S9(004) COMP VALUE +0.*/
                public IntBasis DPARM01_RC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"    05 W-LER-CLIENTE                  PIC  9(001) VALUE ZERO.*/
            }

            public SelectorBasis W_LER_CLIENTE { get; set; } = new SelectorBasis("001", "ZERO")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 EXISTE-CLIENTE                          VALUE 1. */
							new SelectorItemBasis("EXISTE_CLIENTE", "1")
                }
            };

            /*"    05 W-COD-EMPRESA                  PIC  9(001) VALUE ZERO.*/

            public SelectorBasis W_COD_EMPRESA { get; set; } = new SelectorBasis("001", "ZERO")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 SASSE                                   VALUE 1. */
							new SelectorItemBasis("SASSE", "1"),
							/*" 88 FEDERALPREV                             VALUE 2. */
							new SelectorItemBasis("FEDERALPREV", "2"),
							/*" 88 FEDERALCAP                              VALUE 3. */
							new SelectorItemBasis("FEDERALCAP", "3")
                }
            };

            /*"    05 W-RELACIONAMENTO               PIC  9(001) VALUE ZERO.*/

            public SelectorBasis W_RELACIONAMENTO { get; set; } = new SelectorBasis("001", "ZERO")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 SEGURO-VIDA                             VALUE 1. */
							new SelectorItemBasis("SEGURO_VIDA", "1"),
							/*" 88 CAPITALIZACAO                           VALUE 2. */
							new SelectorItemBasis("CAPITALIZACAO", "2"),
							/*" 88 PREVIDENCIA                             VALUE 3. */
							new SelectorItemBasis("PREVIDENCIA", "3"),
							/*" 88 BILHETE                                 VALUE 4. */
							new SelectorItemBasis("BILHETE", "4"),
							/*" 88 AUTOMOVEIL                              VALUE 5. */
							new SelectorItemBasis("AUTOMOVEIL", "5"),
							/*" 88 MULTIRISCO                              VALUE 6. */
							new SelectorItemBasis("MULTIRISCO", "6")
                }
            };

            /*"    05 W-TP-MOVIMENTO                 PIC  9(001) VALUE ZERO.*/

            public SelectorBasis W_TP_MOVIMENTO { get; set; } = new SelectorBasis("001", "ZERO")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 MOVTO-AVULSO                            VALUE 1. */
							new SelectorItemBasis("MOVTO_AVULSO", "1"),
							/*" 88 MOVTO-ADESAO                            VALUE 2. */
							new SelectorItemBasis("MOVTO_ADESAO", "2")
                }
            };

            /*"    05 W-CURSOR                       PIC  9(001) VALUE ZERO.*/

            public SelectorBasis W_CURSOR { get; set; } = new SelectorBasis("001", "ZERO")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 CURSOR-MONTADO                          VALUE 1. */
							new SelectorItemBasis("CURSOR_MONTADO", "1"),
							/*" 88 CURSOR-N-MONTADO                        VALUE 2. */
							new SelectorItemBasis("CURSOR_N_MONTADO", "2")
                }
            };

            /*"    05       WPAR-PARAMETROS     PIC  X(16).*/
            public StringBasis WPAR_PARAMETROS { get; set; } = new StringBasis(new PIC("X", "16", "X(16)."), @"");
            /*"    05        FILLER REDEFINES    WPAR-PARAMETROS.*/
            private _REDEF_VA4648B_FILLER_39 _filler_39 { get; set; }
            public _REDEF_VA4648B_FILLER_39 FILLER_39
            {
                get { _filler_39 = new _REDEF_VA4648B_FILLER_39(); _.Move(WPAR_PARAMETROS, _filler_39); VarBasis.RedefinePassValue(WPAR_PARAMETROS, _filler_39, WPAR_PARAMETROS); _filler_39.ValueChanged += () => { _.Move(_filler_39, WPAR_PARAMETROS); }; return _filler_39; }
                set { VarBasis.RedefinePassValue(value, _filler_39, WPAR_PARAMETROS); }
            }  //Redefines
            public class _REDEF_VA4648B_FILLER_39 : VarBasis
            {
                /*"      10     WPAR-INICIO         PIC  X(08).*/
                public StringBasis WPAR_INICIO { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
                /*"      10     WPAR-FIM            PIC  X(08).*/
                public StringBasis WPAR_FIM { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
                /*"01  WABEND.*/

                public _REDEF_VA4648B_FILLER_39()
                {
                    WPAR_INICIO.ValueChanged += OnValueChanged;
                    WPAR_FIM.ValueChanged += OnValueChanged;
                }

            }
        }
        public VA4648B_WABEND WABEND { get; set; } = new VA4648B_WABEND();
        public class VA4648B_WABEND : VarBasis
        {
            /*"  03  FILLER                   PIC  X(010) VALUE      'VA4648B  '.*/
            public StringBasis FILLER_40 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"VA4648B  ");
            /*"  03  FILLER                   PIC  X(028) VALUE      ' *** ERRO  EXEC SQL *** '.*/
            public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @" *** ERRO  EXEC SQL *** ");
            /*"  03  FILLER                   PIC  X(014) VALUE      '    SQLCODE = '.*/
            public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE = ");
            /*"  03  WSQLCODE                 PIC  ZZZZ999  VALUE ZEROS.*/
            public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "7", "ZZZZ999"));
            /*"  03  FILLER                   PIC  X(014)   VALUE      '   SQLERRD1 = '.*/
            public StringBasis FILLER_43 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD1 = ");
            /*"  03  WSQLERRD1                PIC  ZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLERRD1 { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
            /*"  03  FILLER                   PIC  X(014)   VALUE      '   SQLERRD2 = '.*/
            public StringBasis FILLER_44 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD2 = ");
            /*"  03  WSQLERRD2                PIC  ZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLERRD2 { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
            /*"  03  FILLER                   PIC  X(014)   VALUE      '   SQLERRD2 = '.*/
            public StringBasis FILLER_45 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD2 = ");
            /*"  03  LOCALIZA-ABEND-1.*/
            public VA4648B_LOCALIZA_ABEND_1 LOCALIZA_ABEND_1 { get; set; } = new VA4648B_LOCALIZA_ABEND_1();
            public class VA4648B_LOCALIZA_ABEND_1 : VarBasis
            {
                /*"      05  FILLER                   PIC  X(012)   VALUE          'PARAGRAFO = '.*/
                public StringBasis FILLER_46 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"PARAGRAFO = ");
                /*"      05  PARAGRAFO                PIC  X(040)   VALUE SPACES.*/
                public StringBasis PARAGRAFO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"  03  LOCALIZA-ABEND-2.*/
            }
            public VA4648B_LOCALIZA_ABEND_2 LOCALIZA_ABEND_2 { get; set; } = new VA4648B_LOCALIZA_ABEND_2();
            public class VA4648B_LOCALIZA_ABEND_2 : VarBasis
            {
                /*"      05  FILLER                   PIC  X(012)   VALUE          'COMANDO   = '.*/
                public StringBasis FILLER_47 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"COMANDO   = ");
                /*"      05  COMANDO                  PIC  X(060)   VALUE SPACES.*/
                public StringBasis COMANDO { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"");
                /*"01    WS-HORAS.*/
            }
        }
        public VA4648B_WS_HORAS WS_HORAS { get; set; } = new VA4648B_WS_HORAS();
        public class VA4648B_WS_HORAS : VarBasis
        {
            /*"  03  WS-HORA-INI               PIC  X(008).*/
            public StringBasis WS_HORA_INI { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"  03  WS-HORA-INI-R REDEFINES WS-HORA-INI.*/
            private _REDEF_VA4648B_WS_HORA_INI_R _ws_hora_ini_r { get; set; }
            public _REDEF_VA4648B_WS_HORA_INI_R WS_HORA_INI_R
            {
                get { _ws_hora_ini_r = new _REDEF_VA4648B_WS_HORA_INI_R(); _.Move(WS_HORA_INI, _ws_hora_ini_r); VarBasis.RedefinePassValue(WS_HORA_INI, _ws_hora_ini_r, WS_HORA_INI); _ws_hora_ini_r.ValueChanged += () => { _.Move(_ws_hora_ini_r, WS_HORA_INI); }; return _ws_hora_ini_r; }
                set { VarBasis.RedefinePassValue(value, _ws_hora_ini_r, WS_HORA_INI); }
            }  //Redefines
            public class _REDEF_VA4648B_WS_HORA_INI_R : VarBasis
            {
                /*"      05  HI                    PIC  9(002).*/
                public IntBasis HI { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      05  MI                    PIC  9(002).*/
                public IntBasis MI { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      05  SI                    PIC  9(002).*/
                public IntBasis SI { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      05  DI                    PIC  9(002).*/
                public IntBasis DI { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03  WS-HORA-FIM               PIC  X(008).*/

                public _REDEF_VA4648B_WS_HORA_INI_R()
                {
                    HI.ValueChanged += OnValueChanged;
                    MI.ValueChanged += OnValueChanged;
                    SI.ValueChanged += OnValueChanged;
                    DI.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WS_HORA_FIM { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"  03  WS-HORA-FIM-R REDEFINES WS-HORA-FIM.*/
            private _REDEF_VA4648B_WS_HORA_FIM_R _ws_hora_fim_r { get; set; }
            public _REDEF_VA4648B_WS_HORA_FIM_R WS_HORA_FIM_R
            {
                get { _ws_hora_fim_r = new _REDEF_VA4648B_WS_HORA_FIM_R(); _.Move(WS_HORA_FIM, _ws_hora_fim_r); VarBasis.RedefinePassValue(WS_HORA_FIM, _ws_hora_fim_r, WS_HORA_FIM); _ws_hora_fim_r.ValueChanged += () => { _.Move(_ws_hora_fim_r, WS_HORA_FIM); }; return _ws_hora_fim_r; }
                set { VarBasis.RedefinePassValue(value, _ws_hora_fim_r, WS_HORA_FIM); }
            }  //Redefines
            public class _REDEF_VA4648B_WS_HORA_FIM_R : VarBasis
            {
                /*"      05  HF                    PIC  9(002).*/
                public IntBasis HF { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      05  MF                    PIC  9(002).*/
                public IntBasis MF { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      05  SF                    PIC  9(002).*/
                public IntBasis SF { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      05  DF                    PIC  9(002).*/
                public IntBasis DF { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03  SIT                       PIC S9(013)V99 COMP-3.*/

                public _REDEF_VA4648B_WS_HORA_FIM_R()
                {
                    HF.ValueChanged += OnValueChanged;
                    MF.ValueChanged += OnValueChanged;
                    SF.ValueChanged += OnValueChanged;
                    DF.ValueChanged += OnValueChanged;
                }

            }
            public DoubleBasis SIT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  03  SFT                       PIC S9(013)V99 COMP-3.*/
            public DoubleBasis SFT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  03  SII                       PIC S9(004)    COMP.*/
            public IntBasis SII { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  03  STT-DISP                  PIC --.---.---.---.--9,99.*/
            public DoubleBasis STT_DISP { get; set; } = new DoubleBasis(new PIC("9", "14", "--.---.---.---.--9V99."), 2);
            /*"01  TOTAIS-ROT.*/
        }
        public VA4648B_TOTAIS_ROT TOTAIS_ROT { get; set; } = new VA4648B_TOTAIS_ROT();
        public class VA4648B_TOTAIS_ROT : VarBasis
        {
            /*"    03  FILLER  OCCURS 70 TIMES.*/
            public ListBasis<VA4648B_FILLER_48> FILLER_48 { get; set; } = new ListBasis<VA4648B_FILLER_48>(70);
            public class VA4648B_FILLER_48 : VarBasis
            {
                /*"        05  STT                       PIC S9(013)V99 COMP-3.*/
                public DoubleBasis STT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
                /*"        05  SQT                       PIC S9(015)    COMP-3.*/
                public IntBasis SQT { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
            }
        }


        public Copies.LBFPF990 LBFPF990 { get; set; } = new Copies.LBFPF990();
        public Copies.LBFPF011 LBFPF011 { get; set; } = new Copies.LBFPF011();
        public Copies.LBFPF012 LBFPF012 { get; set; } = new Copies.LBFPF012();
        public Copies.LBFPF014 LBFPF014 { get; set; } = new Copies.LBFPF014();
        public Copies.LBFPF991 LBFPF991 { get; set; } = new Copies.LBFPF991();
        public Copies.LXFPF024 LXFPF024 { get; set; } = new Copies.LXFPF024();
        public Copies.LXFCT004 LXFCT004 { get; set; } = new Copies.LXFCT004();
        public Copies.LBWPF002 LBWPF002 { get; set; } = new Copies.LBWPF002();
        public Dclgens.TARIBCEF TARIBCEF { get; set; } = new Dclgens.TARIBCEF();
        public Dclgens.CLIENEMA CLIENEMA { get; set; } = new Dclgens.CLIENEMA();
        public Dclgens.SUBGVGAP SUBGVGAP { get; set; } = new Dclgens.SUBGVGAP();
        public Dclgens.PROPSSVD PROPSSVD { get; set; } = new Dclgens.PROPSSVD();
        public Dclgens.COVSIVPF COVSIVPF { get; set; } = new Dclgens.COVSIVPF();
        public Dclgens.MALHACEF MALHACEF { get; set; } = new Dclgens.MALHACEF();
        public Dclgens.ESCNEG ESCNEG { get; set; } = new Dclgens.ESCNEG();
        public Dclgens.AGENCEF AGENCEF { get; set; } = new Dclgens.AGENCEF();
        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.PRDSIVPF PRDSIVPF { get; set; } = new Dclgens.PRDSIVPF();
        public Dclgens.FDCOMVA FDCOMVA { get; set; } = new Dclgens.FDCOMVA();
        public Dclgens.PRODUVG PRODUVG { get; set; } = new Dclgens.PRODUVG();
        public Dclgens.PROPFID PROPFID { get; set; } = new Dclgens.PROPFID();
        public Dclgens.CLIENTE CLIENTE { get; set; } = new Dclgens.CLIENTE();
        public Dclgens.CBO CBO { get; set; } = new Dclgens.CBO();
        public Dclgens.ENDERECO ENDERECO { get; set; } = new Dclgens.ENDERECO();
        public Dclgens.OPPAGVA OPPAGVA { get; set; } = new Dclgens.OPPAGVA();
        public Dclgens.RELATORI RELATORI { get; set; } = new Dclgens.RELATORI();
        public Dclgens.GEDOCCLI GEDOCCLI { get; set; } = new Dclgens.GEDOCCLI();
        public Dclgens.PROPVA PROPVA { get; set; } = new Dclgens.PROPVA();
        public Dclgens.HISCOBPR HISCOBPR { get; set; } = new Dclgens.HISCOBPR();
        public Dclgens.ARQSIVPF ARQSIVPF { get; set; } = new Dclgens.ARQSIVPF();
        public Dclgens.JVBKINCL JVBKINCL { get; set; } = new Dclgens.JVBKINCL();
        public VA4648B_CPROPOVA CPROPOVA { get; set; } = new VA4648B_CPROPOVA();
        public VA4648B_FUNDOCOMISVA FUNDOCOMISVA { get; set; } = new VA4648B_FUNDOCOMISVA();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string MOVTO_PRP_SASSE_FILE_NAME_P, string MOVTO_PRP_DISC_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                MOVTO_PRP_SASSE.SetFile(MOVTO_PRP_SASSE_FILE_NAME_P);
                MOVTO_PRP_DISC.SetFile(MOVTO_PRP_DISC_FILE_NAME_P);

                /*" -0- FLUXCONTROL_PERFORM M-0000-PRINCIPAL */

                M_0000_PRINCIPAL();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { CodigoRetorno = RETURN_CODE.Value };
            return Result;
        }

        [StopWatch]
        /*" M-0000-PRINCIPAL */
        private void M_0000_PRINCIPAL(bool isPerform = false)
        {
            /*" -622- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -624- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -626- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -629- DISPLAY '------------------------------' */
            _.Display($"------------------------------");

            /*" -630- DISPLAY 'PROGRAMA EM EXECUCAO VA4648B  ' */
            _.Display($"PROGRAMA EM EXECUCAO VA4648B  ");

            /*" -631- DISPLAY '                              ' */
            _.Display($"                              ");

            /*" -636- DISPLAY 'VERSAO V.04 190050 05/02/2019 ' */
            _.Display($"VERSAO V.04 190050 05/02/2019 ");

            /*" -637- DISPLAY '                              ' */
            _.Display($"                              ");

            /*" -639- DISPLAY '------------------------------' . */
            _.Display($"------------------------------");

            /*" -641- INITIALIZE TOTAIS-ROT. */
            _.Initialize(
                TOTAIS_ROT
            );

            /*" -643- PERFORM R0005-00-OBTER-DATA-DIA. */

            R0005_00_OBTER_DATA_DIA_SECTION();

            /*" -645- PERFORM R0010-00-ABRIR-ARQUIVOS. */

            R0010_00_ABRIR_ARQUIVOS_SECTION();

            /*" -647- PERFORM R0020-00-OBTER-MAX-NSAS. */

            R0020_00_OBTER_MAX_NSAS_SECTION();

            /*" -649- MOVE 1 TO W-CURSOR. */
            _.Move(1, WAREA_AUXILIAR.W_CURSOR);

            /*" -651- PERFORM R0050-00-SELECIONA-MOVTO */

            R0050_00_SELECIONA_MOVTO_SECTION();

            /*" -653- PERFORM R0070-00-LER-MOVTO */

            R0070_00_LER_MOVTO_SECTION();

            /*" -655- PERFORM R0080-00-GERAR-HEADER */

            R0080_00_GERAR_HEADER_SECTION();

            /*" -658- PERFORM R0150-00-PROCESSAR-MOVIMENTO UNTIL W-FIM-PROPOVA EQUAL 'FIM' . */

            while (!(WAREA_AUXILIAR.W_FIM_PROPOVA == "FIM"))
            {

                R0150_00_PROCESSAR_MOVIMENTO_SECTION();
            }

            /*" -662- PERFORM R1000-00-GERAR-TRAILLER. */

            R1000_00_GERAR_TRAILLER_SECTION();

            /*" -664- PERFORM R1100-00-GERAR-TOTAIS. */

            R1100_00_GERAR_TOTAIS_SECTION();

            /*" -666- PERFORM R9988-00-FECHAR-ARQUIVOS. */

            R9988_00_FECHAR_ARQUIVOS_SECTION();

            /*" -666- PERFORM R9999-00-FINALIZAR. */

            R9999_00_FINALIZAR_SECTION();

        }

        [StopWatch]
        /*" R0005-00-OBTER-DATA-DIA-SECTION */
        private void R0005_00_OBTER_DATA_DIA_SECTION()
        {
            /*" -674- MOVE 'R0005-00-OBTER-DATA-DIA' TO PARAGRAFO. */
            _.Move("R0005-00-OBTER-DATA-DIA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -676- MOVE 'SELECT SEGUROS.SISTEMAS' TO COMANDO. */
            _.Move("SELECT SEGUROS.SISTEMAS", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -678- MOVE 'VA' TO SISTEMAS-IDE-SISTEMA OF DCLSISTEMAS. */
            _.Move("VA", SISTEMAS.DCLSISTEMAS.SISTEMAS_IDE_SISTEMA);

            /*" -683- PERFORM R0005_00_OBTER_DATA_DIA_DB_SELECT_1 */

            R0005_00_OBTER_DATA_DIA_DB_SELECT_1();

            /*" -690- MOVE SISTEMAS-DATA-MOV-ABERTO OF DCLSISTEMAS TO W-DTMOVABE WHOST-DT-INICIO WHOST-DT-FIM */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, WAREA_AUXILIAR.W_DTMOVABE, WHOST_DT_INICIO, WHOST_DT_FIM);

            /*" -693- MOVE '01' TO WHOST-DT-INICIO(9:2). */
            _.MoveAtPosition("01", WHOST_DT_INICIO, 9, 2);

            /*" -696- MOVE '28' TO WHOST-DT-FIM (9:2). */
            _.MoveAtPosition("28", WHOST_DT_FIM, 9, 2);

            /*" -698- MOVE W-DIA-MOVABE OF W-DTMOVABE1 TO W-DIA-MOVABE OF W-DTMOVABE-I1. */
            _.Move(WAREA_AUXILIAR.W_DTMOVABE1.W_DIA_MOVABE, WAREA_AUXILIAR.W_DTMOVABE_I1.W_DIA_MOVABE_0);

            /*" -700- MOVE W-MES-MOVABE OF W-DTMOVABE1 TO W-MES-MOVABE OF W-DTMOVABE-I1. */
            _.Move(WAREA_AUXILIAR.W_DTMOVABE1.W_MES_MOVABE, WAREA_AUXILIAR.W_DTMOVABE_I1.W_MES_MOVABE_0);

            /*" -703- MOVE W-ANO-MOVABE OF W-DTMOVABE1 TO W-ANO-MOVABE OF W-DTMOVABE-I1. */
            _.Move(WAREA_AUXILIAR.W_DTMOVABE1.W_ANO_MOVABE, WAREA_AUXILIAR.W_DTMOVABE_I1.W_ANO_MOVABE_0);

            /*" -707- MOVE '-' TO W-BARRA1 OF W-DTMOVABE-I1, W-BARRA2 OF W-DTMOVABE-I1. */
            _.Move("-", WAREA_AUXILIAR.W_DTMOVABE_I1.W_BARRA1_0);
            _.Move("-", WAREA_AUXILIAR.W_DTMOVABE_I1.W_BARRA2_0);


            /*" -710- DISPLAY 'PERIODO DE ' WHOST-DT-INICIO ' ATE ' WHOST-DT-FIM . */

            $"PERIODO DE {WHOST_DT_INICIO} ATE {WHOST_DT_FIM}"
            .Display();

        }

        [StopWatch]
        /*" R0005-00-OBTER-DATA-DIA-DB-SELECT-1 */
        public void R0005_00_OBTER_DATA_DIA_DB_SELECT_1()
        {
            /*" -683- EXEC SQL SELECT DATA_MOV_ABERTO + 2 MONTHS INTO :DCLSISTEMAS.SISTEMAS-DATA-MOV-ABERTO FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = :DCLSISTEMAS.SISTEMAS-IDE-SISTEMA END-EXEC. */

            var r0005_00_OBTER_DATA_DIA_DB_SELECT_1_Query1 = new R0005_00_OBTER_DATA_DIA_DB_SELECT_1_Query1()
            {
                SISTEMAS_IDE_SISTEMA = SISTEMAS.DCLSISTEMAS.SISTEMAS_IDE_SISTEMA.ToString(),
            };

            var executed_1 = R0005_00_OBTER_DATA_DIA_DB_SELECT_1_Query1.Execute(r0005_00_OBTER_DATA_DIA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0005_SAIDA*/

        [StopWatch]
        /*" R0010-00-ABRIR-ARQUIVOS-SECTION */
        private void R0010_00_ABRIR_ARQUIVOS_SECTION()
        {
            /*" -721- MOVE 'R0010-00-ABRIR-ARQUIVOS' TO PARAGRAFO. */
            _.Move("R0010-00-ABRIR-ARQUIVOS", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -723- MOVE 'OPEN' TO COMANDO. */
            _.Move("OPEN", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -724- OPEN OUTPUT MOVTO-PRP-SASSE. */
            MOVTO_PRP_SASSE.Open(REG_PRP_SASSE);

            /*" -724- OPEN OUTPUT MOVTO-PRP-DISC. */
            MOVTO_PRP_DISC.Open(REG_PRP_DISC);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0010_SAIDA*/

        [StopWatch]
        /*" R0020-00-OBTER-MAX-NSAS-SECTION */
        private void R0020_00_OBTER_MAX_NSAS_SECTION()
        {
            /*" -734- MOVE 'R0020-00-OBTER-MAX-NSAS' TO PARAGRAFO. */
            _.Move("R0020-00-OBTER-MAX-NSAS", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -736- MOVE 'SELECT MAX ARQUIVOS-SIVPF' TO COMANDO. */
            _.Move("SELECT MAX ARQUIVOS-SIVPF", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -742- PERFORM R0020_00_OBTER_MAX_NSAS_DB_SELECT_1 */

            R0020_00_OBTER_MAX_NSAS_DB_SELECT_1();

            /*" -745- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -746- DISPLAY 'VA4648B - FIM ANORMAL' */
                _.Display($"VA4648B - FIM ANORMAL");

                /*" -747- DISPLAY '          ERRO SELECT MAX ARQUIVOS-SIVPF' */
                _.Display($"          ERRO SELECT MAX ARQUIVOS-SIVPF");

                /*" -749- DISPLAY '          SQLCODE........................ ' SQLCODE */
                _.Display($"          SQLCODE........................ {DB.SQLCODE}");

                /*" -750- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -752- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


            /*" -755- MOVE ARQSIVPF-NSAS-SIVPF OF DCLARQUIVOS-SIVPF TO W-NSAS. */
            _.Move(ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF, WAREA_AUXILIAR.W_NSAS);

            /*" -757- ADD 1 TO W-NSAS. */
            WAREA_AUXILIAR.W_NSAS.Value = WAREA_AUXILIAR.W_NSAS + 1;

            /*" -757- MOVE W-NSAS TO ARQSIVPF-NSAS-SIVPF OF DCLARQUIVOS-SIVPF. */
            _.Move(WAREA_AUXILIAR.W_NSAS, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF);

        }

        [StopWatch]
        /*" R0020-00-OBTER-MAX-NSAS-DB-SELECT-1 */
        public void R0020_00_OBTER_MAX_NSAS_DB_SELECT_1()
        {
            /*" -742- EXEC SQL SELECT VALUE(MAX(NSAS_SIVPF),0) INTO :DCLARQUIVOS-SIVPF.ARQSIVPF-NSAS-SIVPF FROM SEGUROS.ARQUIVOS_SIVPF WHERE SIGLA_ARQUIVO = 'PRPPAR' AND SISTEMA_ORIGEM = 4 END-EXEC. */

            var r0020_00_OBTER_MAX_NSAS_DB_SELECT_1_Query1 = new R0020_00_OBTER_MAX_NSAS_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0020_00_OBTER_MAX_NSAS_DB_SELECT_1_Query1.Execute(r0020_00_OBTER_MAX_NSAS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.ARQSIVPF_NSAS_SIVPF, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0020_SAIDA*/

        [StopWatch]
        /*" R0050-00-SELECIONA-MOVTO-SECTION */
        private void R0050_00_SELECIONA_MOVTO_SECTION()
        {
            /*" -767- MOVE 'R0050-00-SELECIONA-MOVTO' TO PARAGRAFO. */
            _.Move("R0050-00-SELECIONA-MOVTO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -769- MOVE 'DECLER MOVIMENTO' TO COMANDO. */
            _.Move("DECLER MOVIMENTO", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -770- ACCEPT W-TIME FROM TIME. */
            _.Move(_.AcceptDate("TIME"), WAREA_AUXILIAR.W_TIME);

            /*" -772- MOVE W-TIME TO W-TIME-EDIT. */
            _.Move(WAREA_AUXILIAR.W_TIME, WAREA_AUXILIAR.W_TIME_EDIT);

            /*" -775- DISPLAY '** VA4648B ** INICIO DECLARE V0MOVIMENTO...  ' W-TIME-EDIT. */
            _.Display($"** VA4648B ** INICIO DECLARE V0MOVIMENTO...  {WAREA_AUXILIAR.W_TIME_EDIT}");

            /*" -838- PERFORM R0050_00_SELECIONA_MOVTO_DB_DECLARE_1 */

            R0050_00_SELECIONA_MOVTO_DB_DECLARE_1();

            /*" -840- PERFORM R0050_00_SELECIONA_MOVTO_DB_OPEN_1 */

            R0050_00_SELECIONA_MOVTO_DB_OPEN_1();

            /*" -843- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -845- MOVE 2 TO W-CURSOR. */
                _.Move(2, WAREA_AUXILIAR.W_CURSOR);
            }


            /*" -846- ACCEPT W-TIME FROM TIME. */
            _.Move(_.AcceptDate("TIME"), WAREA_AUXILIAR.W_TIME);

            /*" -848- MOVE W-TIME TO W-TIME-EDIT. */
            _.Move(WAREA_AUXILIAR.W_TIME, WAREA_AUXILIAR.W_TIME_EDIT);

            /*" -850- DISPLAY '** VA4648B ** FIM    DECLARE CPROPOVA .....  ' W-TIME-EDIT */
            _.Display($"** VA4648B ** FIM    DECLARE CPROPOVA .....  {WAREA_AUXILIAR.W_TIME_EDIT}");

            /*" -850- DISPLAY ' ' . */
            _.Display($" ");

        }

        [StopWatch]
        /*" R0050-00-SELECIONA-MOVTO-DB-DECLARE-1 */
        public void R0050_00_SELECIONA_MOVTO_DB_DECLARE_1()
        {
            /*" -838- EXEC SQL DECLARE CPROPOVA CURSOR FOR SELECT NUM_CERTIFICADO , COD_PRODUTO , COD_CLIENTE , OCOREND , COD_FONTE , AGE_COBRANCA , OPCAO_COBERTURA , DATA_QUITACAO , COD_AGE_VENDEDOR , OPE_CONTA_VENDEDOR , NUM_CONTA_VENDEDOR , DIG_CONTA_VENDEDOR , NUM_MATRI_VENDEDOR , COD_OPERACAO , PROFISSAO , DTINCLUS , DATA_MOVIMENTO , SIT_REGISTRO , NUM_APOLICE , COD_SUBGRUPO , OCORR_HISTORICO , NRPRIPARATZ , QTDPARATZ , DTPROXVEN , NUM_PARCELA , DATA_VENCIMENTO , SIT_INTERFACE , DTFENAE , COD_USUARIO , TIMESTAMP , IDADE , IDE_SEXO , ESTADO_CIVIL , APOS_INVALIDEZ , NOME_ESPOSA , DTNASC_ESPOSA , PROFIS_ESPOSA , DPS_TITULAR , DPS_ESPOSA , INFO_COMPLEMENTAR , COD_CCT, FAIXA_RENDA_IND, FAIXA_RENDA_FAM FROM SEGUROS.PROPOSTAS_VA WHERE DTPROXVEN BETWEEN :WHOST-DT-INICIO AND :WHOST-DT-FIM AND SIT_REGISTRO = '3' AND COD_PRODUTO IN ( 9321, 9332, 9319, 9352, 9351, 9333, 9328, 9334, :JVPRD9321, :JVPRD9332, :JVPRD9351, :JVPRD9352, :JVPRD9328, :JVPRD9334 ) END-EXEC. */
            CPROPOVA = new VA4648B_CPROPOVA(true);
            string GetQuery_CPROPOVA()
            {
                var query = @$"SELECT 
							NUM_CERTIFICADO
							, 
							COD_PRODUTO
							, 
							COD_CLIENTE
							, 
							OCOREND
							, 
							COD_FONTE
							, 
							AGE_COBRANCA
							, 
							OPCAO_COBERTURA
							, 
							DATA_QUITACAO
							, 
							COD_AGE_VENDEDOR
							, 
							OPE_CONTA_VENDEDOR
							, 
							NUM_CONTA_VENDEDOR
							, 
							DIG_CONTA_VENDEDOR
							, 
							NUM_MATRI_VENDEDOR
							, 
							COD_OPERACAO
							, 
							PROFISSAO
							, 
							DTINCLUS
							, 
							DATA_MOVIMENTO
							, 
							SIT_REGISTRO
							, 
							NUM_APOLICE
							, 
							COD_SUBGRUPO
							, 
							OCORR_HISTORICO
							, 
							NRPRIPARATZ
							, 
							QTDPARATZ
							, 
							DTPROXVEN
							, 
							NUM_PARCELA
							, 
							DATA_VENCIMENTO
							, 
							SIT_INTERFACE
							, 
							DTFENAE
							, 
							COD_USUARIO
							, 
							TIMESTAMP
							, 
							IDADE
							, 
							IDE_SEXO
							, 
							ESTADO_CIVIL
							, 
							APOS_INVALIDEZ
							, 
							NOME_ESPOSA
							, 
							DTNASC_ESPOSA
							, 
							PROFIS_ESPOSA
							, 
							DPS_TITULAR
							, 
							DPS_ESPOSA
							, 
							INFO_COMPLEMENTAR
							, 
							COD_CCT
							, 
							FAIXA_RENDA_IND
							, 
							FAIXA_RENDA_FAM 
							FROM SEGUROS.PROPOSTAS_VA 
							WHERE DTPROXVEN BETWEEN '{WHOST_DT_INICIO}' 
							AND '{WHOST_DT_FIM}' 
							AND SIT_REGISTRO = '3' 
							AND COD_PRODUTO IN 
							( 
							9321
							, 
							9332
							, 
							9319
							, 
							9352
							, 
							9351
							, 
							9333
							, 
							9328
							, 
							9334
							, 
							'{JVBKINCL.JV_PRODUTOS.JVPRD9321}'
							, '{JVBKINCL.JV_PRODUTOS.JVPRD9332}'
							, '{JVBKINCL.JV_PRODUTOS.JVPRD9351}'
							, 
							'{JVBKINCL.JV_PRODUTOS.JVPRD9352}'
							, '{JVBKINCL.JV_PRODUTOS.JVPRD9328}'
							, '{JVBKINCL.JV_PRODUTOS.JVPRD9334}' 
							)";

                return query;
            }
            CPROPOVA.GetQueryEvent += GetQuery_CPROPOVA;

        }

        [StopWatch]
        /*" R0050-00-SELECIONA-MOVTO-DB-OPEN-1 */
        public void R0050_00_SELECIONA_MOVTO_DB_OPEN_1()
        {
            /*" -840- EXEC SQL OPEN CPROPOVA END-EXEC. */

            CPROPOVA.Open();

        }

        [StopWatch]
        /*" R0570-00-LER-COMISSAO-DB-DECLARE-1 */
        public void R0570_00_LER_COMISSAO_DB_DECLARE_1()
        {
            /*" -1576- EXEC SQL DECLARE FUNDOCOMISVA CURSOR FOR SELECT NUM_CERTIFICADO , VAL_COMISSAO_VG , VAL_COMISSAO_AP FROM SEGUROS.FUNDO_COMISSAO_VA WHERE NUM_CERTIFICADO = :DCLFUNDO-COMISSAO-VA.NUM-CERTIFICADO AND COD_OPERACAO = :DCLFUNDO-COMISSAO-VA.COD-OPERACAO END-EXEC. */
            FUNDOCOMISVA = new VA4648B_FUNDOCOMISVA(true);
            string GetQuery_FUNDOCOMISVA()
            {
                var query = @$"SELECT NUM_CERTIFICADO
							, 
							VAL_COMISSAO_VG
							, 
							VAL_COMISSAO_AP 
							FROM SEGUROS.FUNDO_COMISSAO_VA 
							WHERE NUM_CERTIFICADO = 
							'{FDCOMVA.DCLFUNDO_COMISSAO_VA.NUM_CERTIFICADO}' 
							AND COD_OPERACAO = 
							'{FDCOMVA.DCLFUNDO_COMISSAO_VA.COD_OPERACAO}'";

                return query;
            }
            FUNDOCOMISVA.GetQueryEvent += GetQuery_FUNDOCOMISVA;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0050_SAIDA*/

        [StopWatch]
        /*" R0070-00-LER-MOVTO-SECTION */
        private void R0070_00_LER_MOVTO_SECTION()
        {
            /*" -860- MOVE 'R0070-00-LER-MOVTO' TO PARAGRAFO. */
            _.Move("R0070-00-LER-MOVTO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -862- MOVE 'FETCH MOVIMENTO-VGAP' TO COMANDO. */
            _.Move("FETCH MOVIMENTO-VGAP", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -908- PERFORM R0070_00_LER_MOVTO_DB_FETCH_1 */

            R0070_00_LER_MOVTO_DB_FETCH_1();

            /*" -911- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -912- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -913- MOVE 'FIM' TO W-FIM-PROPOVA */
                    _.Move("FIM", WAREA_AUXILIAR.W_FIM_PROPOVA);

                    /*" -913- PERFORM R0070_00_LER_MOVTO_DB_CLOSE_1 */

                    R0070_00_LER_MOVTO_DB_CLOSE_1();

                    /*" -915- ELSE */
                }
                else
                {


                    /*" -916- DISPLAY 'VA4648B - FIM ANORMAL' */
                    _.Display($"VA4648B - FIM ANORMAL");

                    /*" -918- DISPLAY '          ERRO FETCH CURSOR V0MOVIMENTO  ' SQLCODE */
                    _.Display($"          ERRO FETCH CURSOR V0MOVIMENTO  {DB.SQLCODE}");

                    /*" -919- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -920- PERFORM R9999-00-FINALIZAR */

                    R9999_00_FINALIZAR_SECTION();

                    /*" -921- ELSE */
                }

            }
            else
            {


                /*" -924- ADD 1 TO W-NSL, W-CONTROLE */
                WAREA_AUXILIAR.W_NSL.Value = WAREA_AUXILIAR.W_NSL + 1;
                WAREA_AUXILIAR.W_CONTROLE.Value = WAREA_AUXILIAR.W_CONTROLE + 1;

                /*" -936- COMPUTE W-TOT-PROCESSADO = W-QTD-LD-TIPO-1 + W-QTD-LD-TIPO-2 + W-QTD-LD-TIPO-3 + W-QTD-LD-TIPO-4 + W-QTD-LD-TIPO-5 + W-QTD-LD-TIPO-6 + W-QTD-LD-TIPO-7 + W-QTD-LD-TIPO-8 + W-QTD-LD-TIPO-9 + W-QTD-LD-TIPO-A + W-QTD-LD-TIPO-B + W-QTD-LD-TIPO-C + W-QTD-LD-TIPO-D + W-QTD-LD-TIPO-E + W-QTD-LD-TIPO-F + W-QTD-LD-TIPO-G + W-QTD-LD-TIPO-H + W-QTD-LD-TIPO-I + W-QTD-LD-TIPO-J */
                WAREA_AUXILIAR.W_TOT_PROCESSADO.Value = WAREA_AUXILIAR.W_QTD_LD_TIPO_1 + WAREA_AUXILIAR.W_QTD_LD_TIPO_2 + WAREA_AUXILIAR.W_QTD_LD_TIPO_3 + WAREA_AUXILIAR.W_QTD_LD_TIPO_4 + WAREA_AUXILIAR.W_QTD_LD_TIPO_5 + WAREA_AUXILIAR.W_QTD_LD_TIPO_6 + WAREA_AUXILIAR.W_QTD_LD_TIPO_7 + WAREA_AUXILIAR.W_QTD_LD_TIPO_8 + WAREA_AUXILIAR.W_QTD_LD_TIPO_9 + WAREA_AUXILIAR.W_QTD_LD_TIPO_A + WAREA_AUXILIAR.W_QTD_LD_TIPO_B + WAREA_AUXILIAR.W_QTD_LD_TIPO_C + WAREA_AUXILIAR.W_QTD_LD_TIPO_D + WAREA_AUXILIAR.W_QTD_LD_TIPO_E + WAREA_AUXILIAR.W_QTD_LD_TIPO_F + WAREA_AUXILIAR.W_QTD_LD_TIPO_G + WAREA_AUXILIAR.W_QTD_LD_TIPO_H + WAREA_AUXILIAR.W_QTD_LD_TIPO_I + WAREA_AUXILIAR.W_QTD_LD_TIPO_J;

                /*" -939- IF W-CONTROLE > 999 */

                if (WAREA_AUXILIAR.W_CONTROLE > 999)
                {

                    /*" -940- ACCEPT W-TIME FROM TIME */
                    _.Move(_.AcceptDate("TIME"), WAREA_AUXILIAR.W_TIME);

                    /*" -941- MOVE W-TIME TO W-TIME-EDIT */
                    _.Move(WAREA_AUXILIAR.W_TIME, WAREA_AUXILIAR.W_TIME_EDIT);

                    /*" -942- MOVE ZEROS TO W-CONTROLE */
                    _.Move(0, WAREA_AUXILIAR.W_CONTROLE);

                    /*" -943- DISPLAY ' ' */
                    _.Display($" ");

                    /*" -945- DISPLAY '** VA4648B ** TOTAL LIDO ..  ' W-NSL ' ' W-TIME-EDIT */

                    $"** VA4648B ** TOTAL LIDO ..  {WAREA_AUXILIAR.W_NSL} {WAREA_AUXILIAR.W_TIME_EDIT}"
                    .Display();

                    /*" -945- DISPLAY ' ' . */
                    _.Display($" ");
                }

            }


        }

        [StopWatch]
        /*" R0070-00-LER-MOVTO-DB-FETCH-1 */
        public void R0070_00_LER_MOVTO_DB_FETCH_1()
        {
            /*" -908- EXEC SQL FETCH CPROPOVA INTO :DCLPROPOSTAS-VA.NUM-CERTIFICADO , :DCLPROPOSTAS-VA.COD-PRODUTO , :DCLPROPOSTAS-VA.COD-CLIENTE , :DCLPROPOSTAS-VA.OCOREND , :DCLPROPOSTAS-VA.COD-FONTE , :DCLPROPOSTAS-VA.AGE-COBRANCA , :DCLPROPOSTAS-VA.OPCAO-COBERTURA , :DCLPROPOSTAS-VA.DATA-QUITACAO , :DCLPROPOSTAS-VA.COD-AGE-VENDEDOR , :DCLPROPOSTAS-VA.OPE-CONTA-VENDEDOR , :DCLPROPOSTAS-VA.NUM-CONTA-VENDEDOR , :DCLPROPOSTAS-VA.DIG-CONTA-VENDEDOR , :DCLPROPOSTAS-VA.NUM-MATRI-VENDEDOR , :DCLPROPOSTAS-VA.COD-OPERACAO , :DCLPROPOSTAS-VA.PROFISSAO , :DCLPROPOSTAS-VA.DTINCLUS , :DCLPROPOSTAS-VA.DATA-MOVIMENTO , :DCLPROPOSTAS-VA.SIT-REGISTRO , :DCLPROPOSTAS-VA.NUM-APOLICE , :DCLPROPOSTAS-VA.COD-SUBGRUPO , :DCLPROPOSTAS-VA.OCORR-HISTORICO , :DCLPROPOSTAS-VA.NRPRIPARATZ , :DCLPROPOSTAS-VA.QTDPARATZ , :DCLPROPOSTAS-VA.DTPROXVEN , :DCLPROPOSTAS-VA.NUM-PARCELA , :DCLPROPOSTAS-VA.DATA-VENCIMENTO , :DCLPROPOSTAS-VA.SIT-INTERFACE , :DCLPROPOSTAS-VA.DTFENAE , :DCLPROPOSTAS-VA.COD-USUARIO , :DCLPROPOSTAS-VA.TIMESTAMP , :DCLPROPOSTAS-VA.IDADE , :DCLPROPOSTAS-VA.IDE-SEXO , :DCLPROPOSTAS-VA.ESTADO-CIVIL , :DCLPROPOSTAS-VA.APOS-INVALIDEZ:VIND-APOS-INVALIDEZ, :DCLPROPOSTAS-VA.NOME-ESPOSA:VIND-NOME-ESPOSA, :DCLPROPOSTAS-VA.DTNASC-ESPOSA:VIND-DTNASC-ESPOSA, :DCLPROPOSTAS-VA.PROFIS-ESPOSA:VIND-PROFIS-ESPOSA, :DCLPROPOSTAS-VA.DPS-TITULAR:VIND-DPS-TITULAR, :DCLPROPOSTAS-VA.DPS-ESPOSA:VIND-DPS-ESPOSA, :DCLPROPOSTAS-VA.INFO-COMPLEMENTAR:VIND-INFO-COMP, :DCLPROPOSTAS-VA.COD-CCT:VIND-COD-CCT, :DCLPROPOSTAS-VA.FAIXA-RENDA-IND:VIND-FAIXA-RENDA-IND, :DCLPROPOSTAS-VA.FAIXA-RENDA-FAM:VIND-FAIXA-RENDA-FAM END-EXEC. */

            if (CPROPOVA.Fetch())
            {
                _.Move(CPROPOVA.DCLPROPOSTAS_VA_NUM_CERTIFICADO, PROPVA.DCLPROPOSTAS_VA.NUM_CERTIFICADO);
                _.Move(CPROPOVA.DCLPROPOSTAS_VA_COD_PRODUTO, PROPVA.DCLPROPOSTAS_VA.COD_PRODUTO);
                _.Move(CPROPOVA.DCLPROPOSTAS_VA_COD_CLIENTE, PROPVA.DCLPROPOSTAS_VA.COD_CLIENTE);
                _.Move(CPROPOVA.DCLPROPOSTAS_VA_OCOREND, PROPVA.DCLPROPOSTAS_VA.OCOREND);
                _.Move(CPROPOVA.DCLPROPOSTAS_VA_COD_FONTE, PROPVA.DCLPROPOSTAS_VA.COD_FONTE);
                _.Move(CPROPOVA.DCLPROPOSTAS_VA_AGE_COBRANCA, PROPVA.DCLPROPOSTAS_VA.AGE_COBRANCA);
                _.Move(CPROPOVA.DCLPROPOSTAS_VA_OPCAO_COBERTURA, PROPVA.DCLPROPOSTAS_VA.OPCAO_COBERTURA);
                _.Move(CPROPOVA.DCLPROPOSTAS_VA_DATA_QUITACAO, PROPVA.DCLPROPOSTAS_VA.DATA_QUITACAO);
                _.Move(CPROPOVA.DCLPROPOSTAS_VA_COD_AGE_VENDEDOR, PROPVA.DCLPROPOSTAS_VA.COD_AGE_VENDEDOR);
                _.Move(CPROPOVA.DCLPROPOSTAS_VA_OPE_CONTA_VENDEDOR, PROPVA.DCLPROPOSTAS_VA.OPE_CONTA_VENDEDOR);
                _.Move(CPROPOVA.DCLPROPOSTAS_VA_NUM_CONTA_VENDEDOR, PROPVA.DCLPROPOSTAS_VA.NUM_CONTA_VENDEDOR);
                _.Move(CPROPOVA.DCLPROPOSTAS_VA_DIG_CONTA_VENDEDOR, PROPVA.DCLPROPOSTAS_VA.DIG_CONTA_VENDEDOR);
                _.Move(CPROPOVA.DCLPROPOSTAS_VA_NUM_MATRI_VENDEDOR, PROPVA.DCLPROPOSTAS_VA.NUM_MATRI_VENDEDOR);
                _.Move(CPROPOVA.DCLPROPOSTAS_VA_COD_OPERACAO, PROPVA.DCLPROPOSTAS_VA.COD_OPERACAO);
                _.Move(CPROPOVA.DCLPROPOSTAS_VA_PROFISSAO, PROPVA.DCLPROPOSTAS_VA.PROFISSAO);
                _.Move(CPROPOVA.DCLPROPOSTAS_VA_DTINCLUS, PROPVA.DCLPROPOSTAS_VA.DTINCLUS);
                _.Move(CPROPOVA.DCLPROPOSTAS_VA_DATA_MOVIMENTO, PROPVA.DCLPROPOSTAS_VA.DATA_MOVIMENTO);
                _.Move(CPROPOVA.DCLPROPOSTAS_VA_SIT_REGISTRO, PROPVA.DCLPROPOSTAS_VA.SIT_REGISTRO);
                _.Move(CPROPOVA.DCLPROPOSTAS_VA_NUM_APOLICE, PROPVA.DCLPROPOSTAS_VA.NUM_APOLICE);
                _.Move(CPROPOVA.DCLPROPOSTAS_VA_COD_SUBGRUPO, PROPVA.DCLPROPOSTAS_VA.COD_SUBGRUPO);
                _.Move(CPROPOVA.DCLPROPOSTAS_VA_OCORR_HISTORICO, PROPVA.DCLPROPOSTAS_VA.OCORR_HISTORICO);
                _.Move(CPROPOVA.DCLPROPOSTAS_VA_NRPRIPARATZ, PROPVA.DCLPROPOSTAS_VA.NRPRIPARATZ);
                _.Move(CPROPOVA.DCLPROPOSTAS_VA_QTDPARATZ, PROPVA.DCLPROPOSTAS_VA.QTDPARATZ);
                _.Move(CPROPOVA.DCLPROPOSTAS_VA_DTPROXVEN, PROPVA.DCLPROPOSTAS_VA.DTPROXVEN);
                _.Move(CPROPOVA.DCLPROPOSTAS_VA_NUM_PARCELA, PROPVA.DCLPROPOSTAS_VA.NUM_PARCELA);
                _.Move(CPROPOVA.DCLPROPOSTAS_VA_DATA_VENCIMENTO, PROPVA.DCLPROPOSTAS_VA.DATA_VENCIMENTO);
                _.Move(CPROPOVA.DCLPROPOSTAS_VA_SIT_INTERFACE, PROPVA.DCLPROPOSTAS_VA.SIT_INTERFACE);
                _.Move(CPROPOVA.DCLPROPOSTAS_VA_DTFENAE, PROPVA.DCLPROPOSTAS_VA.DTFENAE);
                _.Move(CPROPOVA.DCLPROPOSTAS_VA_COD_USUARIO, PROPVA.DCLPROPOSTAS_VA.COD_USUARIO);
                _.Move(CPROPOVA.DCLPROPOSTAS_VA_TIMESTAMP, PROPVA.DCLPROPOSTAS_VA.TIMESTAMP);
                _.Move(CPROPOVA.DCLPROPOSTAS_VA_IDADE, PROPVA.DCLPROPOSTAS_VA.IDADE);
                _.Move(CPROPOVA.DCLPROPOSTAS_VA_IDE_SEXO, PROPVA.DCLPROPOSTAS_VA.IDE_SEXO);
                _.Move(CPROPOVA.DCLPROPOSTAS_VA_ESTADO_CIVIL, PROPVA.DCLPROPOSTAS_VA.ESTADO_CIVIL);
                _.Move(CPROPOVA.DCLPROPOSTAS_VA_APOS_INVALIDEZ, PROPVA.DCLPROPOSTAS_VA.APOS_INVALIDEZ);
                _.Move(CPROPOVA.VIND_APOS_INVALIDEZ, VIND_APOS_INVALIDEZ);
                _.Move(CPROPOVA.DCLPROPOSTAS_VA_NOME_ESPOSA, PROPVA.DCLPROPOSTAS_VA.NOME_ESPOSA);
                _.Move(CPROPOVA.VIND_NOME_ESPOSA, VIND_NOME_ESPOSA);
                _.Move(CPROPOVA.DCLPROPOSTAS_VA_DTNASC_ESPOSA, PROPVA.DCLPROPOSTAS_VA.DTNASC_ESPOSA);
                _.Move(CPROPOVA.VIND_DTNASC_ESPOSA, VIND_DTNASC_ESPOSA);
                _.Move(CPROPOVA.DCLPROPOSTAS_VA_PROFIS_ESPOSA, PROPVA.DCLPROPOSTAS_VA.PROFIS_ESPOSA);
                _.Move(CPROPOVA.VIND_PROFIS_ESPOSA, VIND_PROFIS_ESPOSA);
                _.Move(CPROPOVA.DCLPROPOSTAS_VA_DPS_TITULAR, PROPVA.DCLPROPOSTAS_VA.DPS_TITULAR);
                _.Move(CPROPOVA.VIND_DPS_TITULAR, VIND_DPS_TITULAR);
                _.Move(CPROPOVA.DCLPROPOSTAS_VA_DPS_ESPOSA, PROPVA.DCLPROPOSTAS_VA.DPS_ESPOSA);
                _.Move(CPROPOVA.VIND_DPS_ESPOSA, VIND_DPS_ESPOSA);
                _.Move(CPROPOVA.DCLPROPOSTAS_VA_INFO_COMPLEMENTAR, PROPVA.DCLPROPOSTAS_VA.INFO_COMPLEMENTAR);
                _.Move(CPROPOVA.VIND_INFO_COMP, VIND_INFO_COMP);
                _.Move(CPROPOVA.DCLPROPOSTAS_VA_COD_CCT, PROPVA.DCLPROPOSTAS_VA.COD_CCT);
                _.Move(CPROPOVA.VIND_COD_CCT, VIND_COD_CCT);
                _.Move(CPROPOVA.DCLPROPOSTAS_VA_FAIXA_RENDA_IND, PROPVA.DCLPROPOSTAS_VA.FAIXA_RENDA_IND);
                _.Move(CPROPOVA.VIND_FAIXA_RENDA_IND, VIND_FAIXA_RENDA_IND);
                _.Move(CPROPOVA.DCLPROPOSTAS_VA_FAIXA_RENDA_FAM, PROPVA.DCLPROPOSTAS_VA.FAIXA_RENDA_FAM);
                _.Move(CPROPOVA.VIND_FAIXA_RENDA_FAM, VIND_FAIXA_RENDA_FAM);
            }

        }

        [StopWatch]
        /*" R0070-00-LER-MOVTO-DB-CLOSE-1 */
        public void R0070_00_LER_MOVTO_DB_CLOSE_1()
        {
            /*" -913- EXEC SQL CLOSE CPROPOVA END-EXEC */

            CPROPOVA.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0070_SAIDA*/

        [StopWatch]
        /*" R0080-00-GERAR-HEADER-SECTION */
        private void R0080_00_GERAR_HEADER_SECTION()
        {
            /*" -955- MOVE 'R0080-00-GERAR-HEADER' TO PARAGRAFO. */
            _.Move("R0080-00-GERAR-HEADER", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -957- MOVE 'WRITE REG-HEADER' TO COMANDO. */
            _.Move("WRITE REG-HEADER", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -959- MOVE SPACES TO REG-HEADER. */
            _.Move("", LBFPF990.REG_HEADER);

            /*" -962- MOVE 'H' TO RH-TIPO-REG OF REG-HEADER */
            _.Move("H", LBFPF990.REG_HEADER.RH_TIPO_REG);

            /*" -965- MOVE 'PRPPAR' TO RH-NOME OF REG-HEADER */
            _.Move("PRPPAR", LBFPF990.REG_HEADER.RH_NOME);

            /*" -966- MOVE W-DIA-MOVABE OF W-DTMOVABE1 TO W-DIA-TRABALHO */
            _.Move(WAREA_AUXILIAR.W_DTMOVABE1.W_DIA_MOVABE, WAREA_AUXILIAR.FILLER_29.W_DIA_TRABALHO);

            /*" -967- MOVE W-MES-MOVABE OF W-DTMOVABE1 TO W-MES-TRABALHO */
            _.Move(WAREA_AUXILIAR.W_DTMOVABE1.W_MES_MOVABE, WAREA_AUXILIAR.FILLER_29.W_MES_TRABALHO);

            /*" -969- MOVE W-ANO-MOVABE OF W-DTMOVABE1 TO W-ANO-TRABALHO */
            _.Move(WAREA_AUXILIAR.W_DTMOVABE1.W_ANO_MOVABE, WAREA_AUXILIAR.FILLER_29.W_ANO_TRABALHO);

            /*" -972- MOVE W-DATA-TRABALHO TO RH-DATA-GERACAO OF REG-HEADER */
            _.Move(WAREA_AUXILIAR.W_DATA_TRABALHO, LBFPF990.REG_HEADER.RH_DATA_GERACAO);

            /*" -975- MOVE 4 TO RH-SIST-ORIGEM OF REG-HEADER */
            _.Move(4, LBFPF990.REG_HEADER.RH_SIST_ORIGEM);

            /*" -978- MOVE 1 TO RH-SIST-DESTINO OF REG-HEADER */
            _.Move(1, LBFPF990.REG_HEADER.RH_SIST_DESTINO);

            /*" -981- MOVE ARQSIVPF-NSAS-SIVPF OF DCLARQUIVOS-SIVPF TO RH-NSAS OF REG-HEADER */
            _.Move(ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF, LBFPF990.REG_HEADER.RH_NSAS);

            /*" -983- MOVE 1 TO RH-TIPO-ARQUIVO OF REG-HEADER. */
            _.Move(1, LBFPF990.REG_HEADER.RH_TIPO_ARQUIVO);

            /*" -983- WRITE REG-PRP-SASSE FROM REG-HEADER. */
            _.Move(LBFPF990.REG_HEADER.GetMoveValues(), REG_PRP_SASSE);

            MOVTO_PRP_SASSE.Write(REG_PRP_SASSE.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0080_SAIDA*/

        [StopWatch]
        /*" R0150-00-PROCESSAR-MOVIMENTO-SECTION */
        private void R0150_00_PROCESSAR_MOVIMENTO_SECTION()
        {
            /*" -993- MOVE 'R0150-00-PROCESSA-MOVIMENTO' TO PARAGRAFO. */
            _.Move("R0150-00-PROCESSA-MOVIMENTO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -995- MOVE '    ' TO COMANDO. */
            _.Move("    ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -999- MOVE SPACES TO REG-CLIENTES. */
            _.Move("", LBFPF011.REG_CLIENTES);

            /*" -1000- MOVE 'NAO' TO W-EXISTE-FIDELIZ. */
            _.Move("NAO", WAREA_AUXILIAR.W_EXISTE_FIDELIZ);

            /*" -1003- MOVE ZEROS TO WS-SQLCODE-R0711 WS-SQLCODE-R0720 */
            _.Move(0, WS_SQLCODE_R0711, WS_SQLCODE_R0720);

            /*" -1005- PERFORM R0200-00-LER-PROP-FIDELIZ. */

            R0200_00_LER_PROP_FIDELIZ_SECTION();

            /*" -1007- PERFORM R0210-00-LER-HISCOBPR. */

            R0210_00_LER_HISCOBPR_SECTION();

            /*" -1008- IF VIND-FAIXA-RENDA-IND LESS 0 */

            if (VIND_FAIXA_RENDA_IND < 0)
            {

                /*" -1011- MOVE SPACE TO FAIXA-RENDA-IND OF DCLPROPOSTAS-VA. */
                _.Move("", PROPVA.DCLPROPOSTAS_VA.FAIXA_RENDA_IND);
            }


            /*" -1012- IF VIND-FAIXA-RENDA-FAM LESS 0 */

            if (VIND_FAIXA_RENDA_FAM < 0)
            {

                /*" -1015- MOVE SPACE TO FAIXA-RENDA-FAM OF DCLPROPOSTAS-VA. */
                _.Move("", PROPVA.DCLPROPOSTAS_VA.FAIXA_RENDA_FAM);
            }


            /*" -1018- MOVE FAIXA-RENDA-IND OF DCLPROPOSTAS-VA TO R1-RENDA-INDIVIDUAL. */
            _.Move(PROPVA.DCLPROPOSTAS_VA.FAIXA_RENDA_IND, LBFPF011.REG_CLIENTES.R1_RENDA_INDIVIDUAL);

            /*" -1021- MOVE FAIXA-RENDA-FAM OF DCLPROPOSTAS-VA TO R1-RENDA-FAMILIAR. */
            _.Move(PROPVA.DCLPROPOSTAS_VA.FAIXA_RENDA_FAM, LBFPF011.REG_CLIENTES.R1_RENDA_FAMILIAR);

            /*" -1022- IF SQLCODE NOT EQUAL 100 */

            if (DB.SQLCODE != 100)
            {

                /*" -1026- PERFORM R0300-00-LER-CLIENTE */

                R0300_00_LER_CLIENTE_SECTION();

                /*" -1028- IF VIND-DTNASCI LESS ZEROS AND CGCCPF OF DCLCLIENTES EQUAL ZEROS */

                if (VIND_DTNASCI < 00 && CLIENTE.DCLCLIENTES.CGCCPF == 00)
                {

                    /*" -1029- DISPLAY 'VA4648B - SEGURO NAO ENVIADO A CEF' */
                    _.Display($"VA4648B - SEGURO NAO ENVIADO A CEF");

                    /*" -1032- DISPLAY '          CPF/DT.NASCIMENTO ZEROS   ' NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ '  ' COD-CLIENTE OF DCLCLIENTES */

                    $"          CPF/DT.NASCIMENTO ZEROS   {PROPFID.DCLPROPOSTA_FIDELIZ.NUM_PROPOSTA_SIVPF}  {CLIENTE.DCLCLIENTES.COD_CLIENTE}"
                    .Display();

                    /*" -1033- ADD 1 TO W-DESPREZADO */
                    WAREA_AUXILIAR.W_DESPREZADO.Value = WAREA_AUXILIAR.W_DESPREZADO + 1;

                    /*" -1034- ELSE */
                }
                else
                {


                    /*" -1035- PERFORM R0310-00-LER-EMAIL */

                    R0310_00_LER_EMAIL_SECTION();

                    /*" -1036- PERFORM R0320-00-LER-PRODUVG */

                    R0320_00_LER_PRODUVG_SECTION();

                    /*" -1037- PERFORM R0330-00-LER-SUBGVGAP */

                    R0330_00_LER_SUBGVGAP_SECTION();

                    /*" -1038- PERFORM R0350-00-LER-ENDERECO */

                    R0350_00_LER_ENDERECO_SECTION();

                    /*" -1039- PERFORM R0400-00-LER-PROFISSAO */

                    R0400_00_LER_PROFISSAO_SECTION();

                    /*" -1040- PERFORM R0550-00-LER-OPCAOPAGVA */

                    R0550_00_LER_OPCAOPAGVA_SECTION();

                    /*" -1041- PERFORM R0570-00-LER-COMISSAO */

                    R0570_00_LER_COMISSAO_SECTION();

                    /*" -1042- PERFORM R0580-00-OBTER-VAL-TARIFA */

                    R0580_00_OBTER_VAL_TARIFA_SECTION();

                    /*" -1043- PERFORM R0600-00-GERAR-REGISTRO-TP1 */

                    R0600_00_GERAR_REGISTRO_TP1_SECTION();

                    /*" -1044- PERFORM R0650-00-GERAR-REGISTRO-TP2 */

                    R0650_00_GERAR_REGISTRO_TP2_SECTION();

                    /*" -1044- PERFORM R0700-00-GERAR-REGISTRO-TP3. */

                    R0700_00_GERAR_REGISTRO_TP3_SECTION();
                }

            }


            /*" -0- FLUXCONTROL_PERFORM R0150_LEITURA */

            R0150_LEITURA();

        }

        [StopWatch]
        /*" R0150-LEITURA */
        private void R0150_LEITURA(bool isPerform = false)
        {
            /*" -1049- IF W-FIM-PROPOVA NOT EQUAL 'FIM' */

            if (WAREA_AUXILIAR.W_FIM_PROPOVA != "FIM")
            {

                /*" -1049- PERFORM R0070-00-LER-MOVTO. */

                R0070_00_LER_MOVTO_SECTION();
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0150_SAIDA*/

        [StopWatch]
        /*" R0200-00-LER-PROP-FIDELIZ-SECTION */
        private void R0200_00_LER_PROP_FIDELIZ_SECTION()
        {
            /*" -1059- MOVE 'R0200-00-LER-PROP-FIDELIZ' TO PARAGRAFO. */
            _.Move("R0200-00-LER-PROP-FIDELIZ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1061- MOVE 'SELECT PROPOSTA-FIDELIZ' TO COMANDO. */
            _.Move("SELECT PROPOSTA-FIDELIZ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1063- INITIALIZE DCLPROPOSTA-FIDELIZ */
            _.Initialize(
                PROPFID.DCLPROPOSTA_FIDELIZ
            );

            /*" -1066- MOVE NUM-CERTIFICADO OF DCLPROPOSTAS-VA TO NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ. */
            _.Move(PROPVA.DCLPROPOSTAS_VA.NUM_CERTIFICADO, PROPFID.DCLPROPOSTA_FIDELIZ.NUM_PROPOSTA_SIVPF);

            /*" -1092- PERFORM R0200_00_LER_PROP_FIDELIZ_DB_SELECT_1 */

            R0200_00_LER_PROP_FIDELIZ_DB_SELECT_1();

            /*" -1095- IF SQLCODE EQUAL 00 */

            if (DB.SQLCODE == 00)
            {

                /*" -1096- MOVE 'SIM' TO W-EXISTE-FIDELIZ */
                _.Move("SIM", WAREA_AUXILIAR.W_EXISTE_FIDELIZ);

                /*" -1097- ELSE */
            }
            else
            {


                /*" -1098- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1099- MOVE 'NAO' TO W-EXISTE-FIDELIZ */
                    _.Move("NAO", WAREA_AUXILIAR.W_EXISTE_FIDELIZ);

                    /*" -1100- ELSE */
                }
                else
                {


                    /*" -1101- DISPLAY 'VA4648B - FIM ANORMAL' */
                    _.Display($"VA4648B - FIM ANORMAL");

                    /*" -1102- DISPLAY '          ERRO SELECT PROPOSTA-FIDELIZ' */
                    _.Display($"          ERRO SELECT PROPOSTA-FIDELIZ");

                    /*" -1104- DISPLAY '          NUMERO DA PROPOSTA......... ' NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ */
                    _.Display($"          NUMERO DA PROPOSTA......... {PROPFID.DCLPROPOSTA_FIDELIZ.NUM_PROPOSTA_SIVPF}");

                    /*" -1106- DISPLAY '          SQLCODE.................... ' SQLCODE */
                    _.Display($"          SQLCODE.................... {DB.SQLCODE}");

                    /*" -1107- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -1107- PERFORM R9999-00-FINALIZAR. */

                    R9999_00_FINALIZAR_SECTION();
                }

            }


        }

        [StopWatch]
        /*" R0200-00-LER-PROP-FIDELIZ-DB-SELECT-1 */
        public void R0200_00_LER_PROP_FIDELIZ_DB_SELECT_1()
        {
            /*" -1092- EXEC SQL SELECT COD_PRODUTO_SIVPF, SIT_PROPOSTA, NUM_SICOB, DATA_PROPOSTA, AGECOBR, NOME_CONVENENTE, NRMATRCON, CGC_CONVENENTE, PERC_DESCONTO, COD_PLANO, ORIGEM_PROPOSTA INTO :DCLPROPOSTA-FIDELIZ.COD-PRODUTO-SIVPF, :DCLPROPOSTA-FIDELIZ.SIT-PROPOSTA, :DCLPROPOSTA-FIDELIZ.NUM-SICOB, :DCLPROPOSTA-FIDELIZ.DATA-PROPOSTA, :DCLPROPOSTA-FIDELIZ.AGECOBR, :DCLPROPOSTA-FIDELIZ.NOME-CONVENENTE, :DCLPROPOSTA-FIDELIZ.NRMATRCON, :DCLPROPOSTA-FIDELIZ.CGC-CONVENENTE, :DCLPROPOSTA-FIDELIZ.PERC-DESCONTO, :DCLPROPOSTA-FIDELIZ.COD-PLANO, :DCLPROPOSTA-FIDELIZ.ORIGEM-PROPOSTA FROM SEGUROS.PROPOSTA_FIDELIZ WHERE NUM_PROPOSTA_SIVPF = :DCLPROPOSTA-FIDELIZ.NUM-PROPOSTA-SIVPF END-EXEC. */

            var r0200_00_LER_PROP_FIDELIZ_DB_SELECT_1_Query1 = new R0200_00_LER_PROP_FIDELIZ_DB_SELECT_1_Query1()
            {
                NUM_PROPOSTA_SIVPF = PROPFID.DCLPROPOSTA_FIDELIZ.NUM_PROPOSTA_SIVPF.ToString(),
            };

            var executed_1 = R0200_00_LER_PROP_FIDELIZ_DB_SELECT_1_Query1.Execute(r0200_00_LER_PROP_FIDELIZ_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.COD_PRODUTO_SIVPF, PROPFID.DCLPROPOSTA_FIDELIZ.COD_PRODUTO_SIVPF);
                _.Move(executed_1.SIT_PROPOSTA, PROPFID.DCLPROPOSTA_FIDELIZ.SIT_PROPOSTA);
                _.Move(executed_1.NUM_SICOB, PROPFID.DCLPROPOSTA_FIDELIZ.NUM_SICOB);
                _.Move(executed_1.DATA_PROPOSTA, PROPFID.DCLPROPOSTA_FIDELIZ.DATA_PROPOSTA);
                _.Move(executed_1.AGECOBR, PROPFID.DCLPROPOSTA_FIDELIZ.AGECOBR);
                _.Move(executed_1.NOME_CONVENENTE, PROPFID.DCLPROPOSTA_FIDELIZ.NOME_CONVENENTE);
                _.Move(executed_1.NRMATRCON, PROPFID.DCLPROPOSTA_FIDELIZ.NRMATRCON);
                _.Move(executed_1.CGC_CONVENENTE, PROPFID.DCLPROPOSTA_FIDELIZ.CGC_CONVENENTE);
                _.Move(executed_1.PERC_DESCONTO, PROPFID.DCLPROPOSTA_FIDELIZ.PERC_DESCONTO);
                _.Move(executed_1.COD_PLANO, PROPFID.DCLPROPOSTA_FIDELIZ.COD_PLANO);
                _.Move(executed_1.ORIGEM_PROPOSTA, PROPFID.DCLPROPOSTA_FIDELIZ.ORIGEM_PROPOSTA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_SAIDA*/

        [StopWatch]
        /*" R0210-00-LER-HISCOBPR-SECTION */
        private void R0210_00_LER_HISCOBPR_SECTION()
        {
            /*" -1117- MOVE 'R0210-00-LER-HIS-COBPR   ' TO PARAGRAFO. */
            _.Move("R0210-00-LER-HIS-COBPR   ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1119- MOVE 'SELECT HISCOBPR        ' TO COMANDO. */
            _.Move("SELECT HISCOBPR        ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1122- MOVE NUM-CERTIFICADO OF DCLPROPOSTAS-VA TO HISCOBPR-NUM-CERTIFICADO. */
            _.Move(PROPVA.DCLPROPOSTAS_VA.NUM_CERTIFICADO, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_NUM_CERTIFICADO);

            /*" -1130- PERFORM R0210_00_LER_HISCOBPR_DB_SELECT_1 */

            R0210_00_LER_HISCOBPR_DB_SELECT_1();

            /*" -1133- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -1134- DISPLAY 'VA4648B - FIM ANORMAL' */
                _.Display($"VA4648B - FIM ANORMAL");

                /*" -1135- DISPLAY '          ERRO SELECT HISCOBPR        ' */
                _.Display($"          ERRO SELECT HISCOBPR        ");

                /*" -1137- DISPLAY '          NUMERO DA PROPOSTA......... ' NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ */
                _.Display($"          NUMERO DA PROPOSTA......... {PROPFID.DCLPROPOSTA_FIDELIZ.NUM_PROPOSTA_SIVPF}");

                /*" -1139- DISPLAY '          SQLCODE.................... ' SQLCODE */
                _.Display($"          SQLCODE.................... {DB.SQLCODE}");

                /*" -1140- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -1140- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R0210-00-LER-HISCOBPR-DB-SELECT-1 */
        public void R0210_00_LER_HISCOBPR_DB_SELECT_1()
        {
            /*" -1130- EXEC SQL SELECT VLPREMIO, IMP_MORNATU INTO :HISCOBPR-VLPREMIO, :HISCOBPR-IMP-MORNATU FROM SEGUROS.HIS_COBER_PROPOST WHERE NUM_CERTIFICADO = :HISCOBPR-NUM-CERTIFICADO AND DATA_TERVIGENCIA = '9999-12-31' END-EXEC. */

            var r0210_00_LER_HISCOBPR_DB_SELECT_1_Query1 = new R0210_00_LER_HISCOBPR_DB_SELECT_1_Query1()
            {
                HISCOBPR_NUM_CERTIFICADO = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = R0210_00_LER_HISCOBPR_DB_SELECT_1_Query1.Execute(r0210_00_LER_HISCOBPR_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HISCOBPR_VLPREMIO, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_VLPREMIO);
                _.Move(executed_1.HISCOBPR_IMP_MORNATU, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMP_MORNATU);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_SAIDA*/

        [StopWatch]
        /*" R0210-00-LER-SICOB-SECTION */
        private void R0210_00_LER_SICOB_SECTION()
        {
            /*" -1150- MOVE 'R0210-00-LER-SICOB' TO PARAGRAFO. */
            _.Move("R0210-00-LER-SICOB", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1152- MOVE 'SELECT PROPOSTA-FIDELIZ' TO COMANDO. */
            _.Move("SELECT PROPOSTA-FIDELIZ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1160- PERFORM R0210_00_LER_SICOB_DB_SELECT_1 */

            R0210_00_LER_SICOB_DB_SELECT_1();

            /*" -1163- IF SQLCODE EQUAL 00 */

            if (DB.SQLCODE == 00)
            {

                /*" -1164- MOVE 'SIM' TO W-EXISTE-FIDELIZ */
                _.Move("SIM", WAREA_AUXILIAR.W_EXISTE_FIDELIZ);

                /*" -1165- ELSE */
            }
            else
            {


                /*" -1166- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1167- MOVE 'NAO' TO W-EXISTE-FIDELIZ */
                    _.Move("NAO", WAREA_AUXILIAR.W_EXISTE_FIDELIZ);

                    /*" -1168- ELSE */
                }
                else
                {


                    /*" -1169- DISPLAY 'VA4648B - FIM ANORMAL' */
                    _.Display($"VA4648B - FIM ANORMAL");

                    /*" -1170- DISPLAY '          ERRO SELECT PROPOSTA-FIDELIZ' */
                    _.Display($"          ERRO SELECT PROPOSTA-FIDELIZ");

                    /*" -1172- DISPLAY '          NUMERO DO SICOB............ ' NUM-SICOB OF DCLPROPOSTA-FIDELIZ */
                    _.Display($"          NUMERO DO SICOB............ {PROPFID.DCLPROPOSTA_FIDELIZ.NUM_SICOB}");

                    /*" -1174- DISPLAY '          SQLCODE.................... ' SQLCODE */
                    _.Display($"          SQLCODE.................... {DB.SQLCODE}");

                    /*" -1175- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -1175- PERFORM R9999-00-FINALIZAR. */

                    R9999_00_FINALIZAR_SECTION();
                }

            }


        }

        [StopWatch]
        /*" R0210-00-LER-SICOB-DB-SELECT-1 */
        public void R0210_00_LER_SICOB_DB_SELECT_1()
        {
            /*" -1160- EXEC SQL SELECT SIT_PROPOSTA, NUM_PROPOSTA_SIVPF INTO :DCLPROPOSTA-FIDELIZ.SIT-PROPOSTA, :DCLPROPOSTA-FIDELIZ.NUM-PROPOSTA-SIVPF FROM SEGUROS.PROPOSTA_FIDELIZ WHERE NUM_SICOB = :DCLPROPOSTA-FIDELIZ.NUM-SICOB END-EXEC. */

            var r0210_00_LER_SICOB_DB_SELECT_1_Query1 = new R0210_00_LER_SICOB_DB_SELECT_1_Query1()
            {
                NUM_SICOB = PROPFID.DCLPROPOSTA_FIDELIZ.NUM_SICOB.ToString(),
            };

            var executed_1 = R0210_00_LER_SICOB_DB_SELECT_1_Query1.Execute(r0210_00_LER_SICOB_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SIT_PROPOSTA, PROPFID.DCLPROPOSTA_FIDELIZ.SIT_PROPOSTA);
                _.Move(executed_1.NUM_PROPOSTA_SIVPF, PROPFID.DCLPROPOSTA_FIDELIZ.NUM_PROPOSTA_SIVPF);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0210_SAIDA*/

        [StopWatch]
        /*" R0300-00-LER-CLIENTE-SECTION */
        private void R0300_00_LER_CLIENTE_SECTION()
        {
            /*" -1185- MOVE 'R0300-00-LER-CLIENTES' TO PARAGRAFO. */
            _.Move("R0300-00-LER-CLIENTES", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1187- MOVE 'SELECT CLIENTES' TO COMANDO. */
            _.Move("SELECT CLIENTES", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1190- MOVE COD-CLIENTE OF DCLPROPOSTAS-VA TO COD-CLIENTE OF DCLCLIENTES. */
            _.Move(PROPVA.DCLPROPOSTAS_VA.COD_CLIENTE, CLIENTE.DCLCLIENTES.COD_CLIENTE);

            /*" -1207- PERFORM R0300_00_LER_CLIENTE_DB_SELECT_1 */

            R0300_00_LER_CLIENTE_DB_SELECT_1();

            /*" -1210- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -1211- DISPLAY 'VA4648B - FIM ANORMAL' */
                _.Display($"VA4648B - FIM ANORMAL");

                /*" -1212- DISPLAY '          ERRO SELECT TABELA CLIENTES' */
                _.Display($"          ERRO SELECT TABELA CLIENTES");

                /*" -1214- DISPLAY '          NUMERO CERTIFICADO......... ' NUM-CERTIFICADO OF DCLPROPOSTAS-VA */
                _.Display($"          NUMERO CERTIFICADO......... {PROPVA.DCLPROPOSTAS_VA.NUM_CERTIFICADO}");

                /*" -1216- DISPLAY '          CODIGO DO CLIENTE.......... ' COD-CLIENTE OF DCLCLIENTES */
                _.Display($"          CODIGO DO CLIENTE.......... {CLIENTE.DCLCLIENTES.COD_CLIENTE}");

                /*" -1218- DISPLAY '          SQLCODE.................... ' SQLCODE */
                _.Display($"          SQLCODE.................... {DB.SQLCODE}");

                /*" -1219- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -1219- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R0300-00-LER-CLIENTE-DB-SELECT-1 */
        public void R0300_00_LER_CLIENTE_DB_SELECT_1()
        {
            /*" -1207- EXEC SQL SELECT COD_CLIENTE , NOME_RAZAO , TIPO_PESSOA , CGCCPF , SIT_REGISTRO , DATA_NASCIMENTO INTO :DCLCLIENTES.COD-CLIENTE , :DCLCLIENTES.NOME-RAZAO , :DCLCLIENTES.TIPO-PESSOA , :DCLCLIENTES.CGCCPF , :DCLCLIENTES.SIT-REGISTRO , :DCLCLIENTES.DATA-NASCIMENTO:VIND-DTNASCI FROM SEGUROS.CLIENTES WHERE COD_CLIENTE = :DCLCLIENTES.COD-CLIENTE END-EXEC. */

            var r0300_00_LER_CLIENTE_DB_SELECT_1_Query1 = new R0300_00_LER_CLIENTE_DB_SELECT_1_Query1()
            {
                COD_CLIENTE = CLIENTE.DCLCLIENTES.COD_CLIENTE.ToString(),
            };

            var executed_1 = R0300_00_LER_CLIENTE_DB_SELECT_1_Query1.Execute(r0300_00_LER_CLIENTE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.COD_CLIENTE, CLIENTE.DCLCLIENTES.COD_CLIENTE);
                _.Move(executed_1.NOME_RAZAO, CLIENTE.DCLCLIENTES.NOME_RAZAO);
                _.Move(executed_1.TIPO_PESSOA, CLIENTE.DCLCLIENTES.TIPO_PESSOA);
                _.Move(executed_1.CGCCPF, CLIENTE.DCLCLIENTES.CGCCPF);
                _.Move(executed_1.SIT_REGISTRO, CLIENTE.DCLCLIENTES.SIT_REGISTRO);
                _.Move(executed_1.DATA_NASCIMENTO, CLIENTE.DCLCLIENTES.DATA_NASCIMENTO);
                _.Move(executed_1.VIND_DTNASCI, VIND_DTNASCI);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_SAIDA*/

        [StopWatch]
        /*" R0310-00-LER-EMAIL-SECTION */
        private void R0310_00_LER_EMAIL_SECTION()
        {
            /*" -1229- MOVE 'R0310-00-LER-EMAIL   ' TO PARAGRAFO. */
            _.Move("R0310-00-LER-EMAIL   ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1231- MOVE 'SELECT EMAIL   ' TO COMANDO. */
            _.Move("SELECT EMAIL   ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1234- MOVE COD-CLIENTE OF DCLPROPOSTAS-VA TO CLIENEMA-COD-CLIENTE. */
            _.Move(PROPVA.DCLPROPOSTAS_VA.COD_CLIENTE, CLIENEMA.DCLCLIENTE_EMAIL.CLIENEMA_COD_CLIENTE);

            /*" -1241- PERFORM R0310_00_LER_EMAIL_DB_SELECT_1 */

            R0310_00_LER_EMAIL_DB_SELECT_1();

            /*" -1244- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -1245- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1247- MOVE SPACES TO CLIENEMA-EMAIL */
                    _.Move("", CLIENEMA.DCLCLIENTE_EMAIL.CLIENEMA_EMAIL);

                    /*" -1248- ELSE */
                }
                else
                {


                    /*" -1249- DISPLAY 'VA4648B - FIM ANORMAL' */
                    _.Display($"VA4648B - FIM ANORMAL");

                    /*" -1250- DISPLAY '          ERRO SELECT TABELA CLIENTES' */
                    _.Display($"          ERRO SELECT TABELA CLIENTES");

                    /*" -1252- DISPLAY '          NUMERO CERTIFICADO......... ' NUM-CERTIFICADO OF DCLPROPOSTAS-VA */
                    _.Display($"          NUMERO CERTIFICADO......... {PROPVA.DCLPROPOSTAS_VA.NUM_CERTIFICADO}");

                    /*" -1254- DISPLAY '          CODIGO DO CLIENTE.......... ' COD-CLIENTE OF DCLCLIENTES */
                    _.Display($"          CODIGO DO CLIENTE.......... {CLIENTE.DCLCLIENTES.COD_CLIENTE}");

                    /*" -1256- DISPLAY '          SQLCODE.................... ' SQLCODE */
                    _.Display($"          SQLCODE.................... {DB.SQLCODE}");

                    /*" -1257- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -1257- PERFORM R9999-00-FINALIZAR. */

                    R9999_00_FINALIZAR_SECTION();
                }

            }


        }

        [StopWatch]
        /*" R0310-00-LER-EMAIL-DB-SELECT-1 */
        public void R0310_00_LER_EMAIL_DB_SELECT_1()
        {
            /*" -1241- EXEC SQL SELECT EMAIL INTO :CLIENEMA-EMAIL FROM SEGUROS.CLIENTE_EMAIL WHERE COD_CLIENTE = :DCLCLIENTES.COD-CLIENTE END-EXEC. */

            var r0310_00_LER_EMAIL_DB_SELECT_1_Query1 = new R0310_00_LER_EMAIL_DB_SELECT_1_Query1()
            {
                COD_CLIENTE = CLIENTE.DCLCLIENTES.COD_CLIENTE.ToString(),
            };

            var executed_1 = R0310_00_LER_EMAIL_DB_SELECT_1_Query1.Execute(r0310_00_LER_EMAIL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CLIENEMA_EMAIL, CLIENEMA.DCLCLIENTE_EMAIL.CLIENEMA_EMAIL);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0310_SAIDA*/

        [StopWatch]
        /*" R0320-00-LER-PRODUVG-SECTION */
        private void R0320_00_LER_PRODUVG_SECTION()
        {
            /*" -1267- MOVE 'R0320-00-LER-PRODUVG ' TO PARAGRAFO. */
            _.Move("R0320-00-LER-PRODUVG ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1269- MOVE 'SELECT PRODUVG ' TO COMANDO. */
            _.Move("SELECT PRODUVG ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1272- MOVE NUM-APOLICE OF DCLPROPOSTAS-VA TO PRODUVG-NUM-APOLICE. */
            _.Move(PROPVA.DCLPROPOSTAS_VA.NUM_APOLICE, PRODUVG.DCLPRODUTOS_VG.PRODUVG_NUM_APOLICE);

            /*" -1275- MOVE COD-SUBGRUPO OF DCLPROPOSTAS-VA TO PRODUVG-COD-SUBGRUPO. */
            _.Move(PROPVA.DCLPROPOSTAS_VA.COD_SUBGRUPO, PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_SUBGRUPO);

            /*" -1285- PERFORM R0320_00_LER_PRODUVG_DB_SELECT_1 */

            R0320_00_LER_PRODUVG_DB_SELECT_1();

            /*" -1288- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -1289- DISPLAY 'VA4648B - FIM ANORMAL' */
                _.Display($"VA4648B - FIM ANORMAL");

                /*" -1290- DISPLAY '          ERRO SELECT TABELA PRODUVG ' */
                _.Display($"          ERRO SELECT TABELA PRODUVG ");

                /*" -1292- DISPLAY '          NUMERO CERTIFICADO......... ' NUM-CERTIFICADO OF DCLPROPOSTAS-VA */
                _.Display($"          NUMERO CERTIFICADO......... {PROPVA.DCLPROPOSTAS_VA.NUM_CERTIFICADO}");

                /*" -1294- DISPLAY '          CODIGO DO CLIENTE.......... ' COD-CLIENTE OF DCLCLIENTES */
                _.Display($"          CODIGO DO CLIENTE.......... {CLIENTE.DCLCLIENTES.COD_CLIENTE}");

                /*" -1296- DISPLAY '          SQLCODE.................... ' SQLCODE */
                _.Display($"          SQLCODE.................... {DB.SQLCODE}");

                /*" -1297- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -1297- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R0320-00-LER-PRODUVG-DB-SELECT-1 */
        public void R0320_00_LER_PRODUVG_DB_SELECT_1()
        {
            /*" -1285- EXEC SQL SELECT COD_PRODUTO, NOME_PRODUTO INTO :PRODUVG-COD-PRODUTO, :PRODUVG-NOME-PRODUTO FROM SEGUROS.PRODUTOS_VG WHERE NUM_APOLICE = :PRODUVG-NUM-APOLICE AND COD_SUBGRUPO = :PRODUVG-COD-SUBGRUPO END-EXEC. */

            var r0320_00_LER_PRODUVG_DB_SELECT_1_Query1 = new R0320_00_LER_PRODUVG_DB_SELECT_1_Query1()
            {
                PRODUVG_COD_SUBGRUPO = PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_SUBGRUPO.ToString(),
                PRODUVG_NUM_APOLICE = PRODUVG.DCLPRODUTOS_VG.PRODUVG_NUM_APOLICE.ToString(),
            };

            var executed_1 = R0320_00_LER_PRODUVG_DB_SELECT_1_Query1.Execute(r0320_00_LER_PRODUVG_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PRODUVG_COD_PRODUTO, PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_PRODUTO);
                _.Move(executed_1.PRODUVG_NOME_PRODUTO, PRODUVG.DCLPRODUTOS_VG.PRODUVG_NOME_PRODUTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0320_SAIDA*/

        [StopWatch]
        /*" R0330-00-LER-SUBGVGAP-SECTION */
        private void R0330_00_LER_SUBGVGAP_SECTION()
        {
            /*" -1307- MOVE 'R0330-00-LER-SUBGVGAP' TO PARAGRAFO. */
            _.Move("R0330-00-LER-SUBGVGAP", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1309- MOVE 'SELECT SUBGVGAP' TO COMANDO. */
            _.Move("SELECT SUBGVGAP", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1312- MOVE NUM-APOLICE OF DCLPROPOSTAS-VA TO SUBGVGAP-NUM-APOLICE. */
            _.Move(PROPVA.DCLPROPOSTAS_VA.NUM_APOLICE, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_NUM_APOLICE);

            /*" -1315- MOVE COD-SUBGRUPO OF DCLPROPOSTAS-VA TO SUBGVGAP-COD-SUBGRUPO. */
            _.Move(PROPVA.DCLPROPOSTAS_VA.COD_SUBGRUPO, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_SUBGRUPO);

            /*" -1323- PERFORM R0330_00_LER_SUBGVGAP_DB_SELECT_1 */

            R0330_00_LER_SUBGVGAP_DB_SELECT_1();

            /*" -1326- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -1327- DISPLAY 'VA4648B - FIM ANORMAL' */
                _.Display($"VA4648B - FIM ANORMAL");

                /*" -1328- DISPLAY '          ERRO SELECT TABELA SUBGVGA ' */
                _.Display($"          ERRO SELECT TABELA SUBGVGA ");

                /*" -1330- DISPLAY '          NUMERO CERTIFICADO......... ' NUM-CERTIFICADO OF DCLPROPOSTAS-VA */
                _.Display($"          NUMERO CERTIFICADO......... {PROPVA.DCLPROPOSTAS_VA.NUM_CERTIFICADO}");

                /*" -1332- DISPLAY '          CODIGO DO CLIENTE.......... ' COD-CLIENTE OF DCLCLIENTES */
                _.Display($"          CODIGO DO CLIENTE.......... {CLIENTE.DCLCLIENTES.COD_CLIENTE}");

                /*" -1334- DISPLAY '          SQLCODE.................... ' SQLCODE */
                _.Display($"          SQLCODE.................... {DB.SQLCODE}");

                /*" -1335- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -1335- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R0330-00-LER-SUBGVGAP-DB-SELECT-1 */
        public void R0330_00_LER_SUBGVGAP_DB_SELECT_1()
        {
            /*" -1323- EXEC SQL SELECT OPCAO_CONJUGE INTO :SUBGVGAP-OPCAO-CONJUGE FROM SEGUROS.SUBGRUPOS_VGAP WHERE NUM_APOLICE = :SUBGVGAP-NUM-APOLICE AND COD_SUBGRUPO = :SUBGVGAP-COD-SUBGRUPO END-EXEC. */

            var r0330_00_LER_SUBGVGAP_DB_SELECT_1_Query1 = new R0330_00_LER_SUBGVGAP_DB_SELECT_1_Query1()
            {
                SUBGVGAP_COD_SUBGRUPO = SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_SUBGRUPO.ToString(),
                SUBGVGAP_NUM_APOLICE = SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_NUM_APOLICE.ToString(),
            };

            var executed_1 = R0330_00_LER_SUBGVGAP_DB_SELECT_1_Query1.Execute(r0330_00_LER_SUBGVGAP_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SUBGVGAP_OPCAO_CONJUGE, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_OPCAO_CONJUGE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0330_SAIDA*/

        [StopWatch]
        /*" R0350-00-LER-ENDERECO-SECTION */
        private void R0350_00_LER_ENDERECO_SECTION()
        {
            /*" -1345- MOVE 'R0350-00-LER-ENDERECO' TO PARAGRAFO. */
            _.Move("R0350-00-LER-ENDERECO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1347- MOVE 'SELECT ENDERECOS' TO COMANDO. */
            _.Move("SELECT ENDERECOS", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1350- MOVE COD-CLIENTE OF DCLPROPOSTAS-VA TO ENDERECO-COD-CLIENTE OF DCLENDERECOS. */
            _.Move(PROPVA.DCLPROPOSTAS_VA.COD_CLIENTE, ENDERECO.DCLENDERECOS.ENDERECO_COD_CLIENTE);

            /*" -1384- PERFORM R0350_00_LER_ENDERECO_DB_SELECT_1 */

            R0350_00_LER_ENDERECO_DB_SELECT_1();

            /*" -1387- IF SQLCODE NOT EQUAL 00 AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -1388- DISPLAY 'VA4648B - FIM ANORMAL' */
                _.Display($"VA4648B - FIM ANORMAL");

                /*" -1389- DISPLAY '          ERRO SELECT TABELA ENDERECOS' */
                _.Display($"          ERRO SELECT TABELA ENDERECOS");

                /*" -1391- DISPLAY '          NUMERO CERTIFICADO.......... ' NUM-CERTIFICADO OF DCLPROPOSTAS-VA */
                _.Display($"          NUMERO CERTIFICADO.......... {PROPVA.DCLPROPOSTAS_VA.NUM_CERTIFICADO}");

                /*" -1393- DISPLAY '          CODIGO DO CLIENTE........... ' ENDERECO-COD-CLIENTE OF DCLENDERECOS */
                _.Display($"          CODIGO DO CLIENTE........... {ENDERECO.DCLENDERECOS.ENDERECO_COD_CLIENTE}");

                /*" -1395- DISPLAY '          SQLCODE..................... ' SQLCODE */
                _.Display($"          SQLCODE..................... {DB.SQLCODE}");

                /*" -1396- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -1396- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R0350-00-LER-ENDERECO-DB-SELECT-1 */
        public void R0350_00_LER_ENDERECO_DB_SELECT_1()
        {
            /*" -1384- EXEC SQL SELECT COD_CLIENTE , COD_ENDERECO , OCORR_ENDERECO , ENDERECO , BAIRRO , CIDADE , SIGLA_UF , CEP , DDD , TELEFONE , FAX , TELEX , SIT_REGISTRO INTO :DCLENDERECOS.ENDERECO-COD-CLIENTE , :DCLENDERECOS.ENDERECO-COD-ENDERECO , :DCLENDERECOS.ENDERECO-OCORR-ENDERECO , :DCLENDERECOS.ENDERECO-ENDERECO , :DCLENDERECOS.ENDERECO-BAIRRO , :DCLENDERECOS.ENDERECO-CIDADE , :DCLENDERECOS.ENDERECO-SIGLA-UF , :DCLENDERECOS.ENDERECO-CEP , :DCLENDERECOS.ENDERECO-DDD , :DCLENDERECOS.ENDERECO-TELEFONE , :DCLENDERECOS.ENDERECO-FAX , :DCLENDERECOS.ENDERECO-TELEX , :DCLENDERECOS.ENDERECO-SIT-REGISTRO FROM SEGUROS.ENDERECOS A WHERE A.COD_CLIENTE = :DCLENDERECOS.ENDERECO-COD-CLIENTE AND A.OCORR_ENDERECO = :DCLPROPOSTAS-VA.OCOREND END-EXEC. */

            var r0350_00_LER_ENDERECO_DB_SELECT_1_Query1 = new R0350_00_LER_ENDERECO_DB_SELECT_1_Query1()
            {
                ENDERECO_COD_CLIENTE = ENDERECO.DCLENDERECOS.ENDERECO_COD_CLIENTE.ToString(),
                OCOREND = PROPVA.DCLPROPOSTAS_VA.OCOREND.ToString(),
            };

            var executed_1 = R0350_00_LER_ENDERECO_DB_SELECT_1_Query1.Execute(r0350_00_LER_ENDERECO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.ENDERECO_COD_CLIENTE, ENDERECO.DCLENDERECOS.ENDERECO_COD_CLIENTE);
                _.Move(executed_1.ENDERECO_COD_ENDERECO, ENDERECO.DCLENDERECOS.ENDERECO_COD_ENDERECO);
                _.Move(executed_1.ENDERECO_OCORR_ENDERECO, ENDERECO.DCLENDERECOS.ENDERECO_OCORR_ENDERECO);
                _.Move(executed_1.ENDERECO_ENDERECO, ENDERECO.DCLENDERECOS.ENDERECO_ENDERECO);
                _.Move(executed_1.ENDERECO_BAIRRO, ENDERECO.DCLENDERECOS.ENDERECO_BAIRRO);
                _.Move(executed_1.ENDERECO_CIDADE, ENDERECO.DCLENDERECOS.ENDERECO_CIDADE);
                _.Move(executed_1.ENDERECO_SIGLA_UF, ENDERECO.DCLENDERECOS.ENDERECO_SIGLA_UF);
                _.Move(executed_1.ENDERECO_CEP, ENDERECO.DCLENDERECOS.ENDERECO_CEP);
                _.Move(executed_1.ENDERECO_DDD, ENDERECO.DCLENDERECOS.ENDERECO_DDD);
                _.Move(executed_1.ENDERECO_TELEFONE, ENDERECO.DCLENDERECOS.ENDERECO_TELEFONE);
                _.Move(executed_1.ENDERECO_FAX, ENDERECO.DCLENDERECOS.ENDERECO_FAX);
                _.Move(executed_1.ENDERECO_TELEX, ENDERECO.DCLENDERECOS.ENDERECO_TELEX);
                _.Move(executed_1.ENDERECO_SIT_REGISTRO, ENDERECO.DCLENDERECOS.ENDERECO_SIT_REGISTRO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0350_SAIDA*/

        [StopWatch]
        /*" R0400-00-LER-PROFISSAO-SECTION */
        private void R0400_00_LER_PROFISSAO_SECTION()
        {
            /*" -1409- MOVE 'R0400-00-LER-PROFISSAO' TO PARAGRAFO. */
            _.Move("R0400-00-LER-PROFISSAO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1411- IF PROFISSAO OF DCLPROPOSTAS-VA NOT EQUAL SPACES */

            if (!PROPVA.DCLPROPOSTAS_VA.PROFISSAO.IsEmpty())
            {

                /*" -1413- IF PROFISSAO OF DCLPROPOSTAS-VA NOT EQUAL 'OUTROS' */

                if (PROPVA.DCLPROPOSTAS_VA.PROFISSAO != "OUTROS")
                {

                    /*" -1417- MOVE PROFISSAO OF DCLPROPOSTAS-VA TO CBO-DESCR-CBO OF DCLCBO R1-DESCRICAO-PROFISSAO */
                    _.Move(PROPVA.DCLPROPOSTAS_VA.PROFISSAO, CBO.DCLCBO.CBO_DESCR_CBO, LBFPF011.REG_CLIENTES.R1_DESCRICAO_PROFISSAO);

                    /*" -1419- PERFORM R0410-00-LER-CBO */

                    R0410_00_LER_CBO_SECTION();

                    /*" -1420- IF SQLCODE EQUAL 00 */

                    if (DB.SQLCODE == 00)
                    {

                        /*" -1422- MOVE CBO-COD-CBO OF DCLCBO TO COD-CBO-TIT */
                        _.Move(CBO.DCLCBO.CBO_COD_CBO, COD_CBO_TIT);

                        /*" -1423- ELSE */
                    }
                    else
                    {


                        /*" -1424- MOVE ZEROS TO COD-CBO-TIT */
                        _.Move(0, COD_CBO_TIT);

                        /*" -1425- ELSE */
                    }

                }
                else
                {


                    /*" -1426- MOVE ZEROS TO COD-CBO-TIT */
                    _.Move(0, COD_CBO_TIT);

                    /*" -1428- MOVE PROFISSAO OF DCLPROPOSTAS-VA TO R1-DESCRICAO-PROFISSAO */
                    _.Move(PROPVA.DCLPROPOSTAS_VA.PROFISSAO, LBFPF011.REG_CLIENTES.R1_DESCRICAO_PROFISSAO);

                    /*" -1429- ELSE */
                }

            }
            else
            {


                /*" -1430- MOVE 'OUTROS' TO R1-DESCRICAO-PROFISSAO */
                _.Move("OUTROS", LBFPF011.REG_CLIENTES.R1_DESCRICAO_PROFISSAO);

                /*" -1434- MOVE ZEROS TO COD-CBO-TIT. */
                _.Move(0, COD_CBO_TIT);
            }


            /*" -1435- IF VIND-PROFIS-ESPOSA LESS ZEROS */

            if (VIND_PROFIS_ESPOSA < 00)
            {

                /*" -1436- MOVE ZEROS TO COD-CBO-CONJ */
                _.Move(0, COD_CBO_CONJ);

                /*" -1437- ELSE */
            }
            else
            {


                /*" -1439- IF PROFIS-ESPOSA OF DCLPROPOSTAS-VA NOT EQUAL SPACES */

                if (!PROPVA.DCLPROPOSTAS_VA.PROFIS_ESPOSA.IsEmpty())
                {

                    /*" -1441- IF PROFIS-ESPOSA OF DCLPROPOSTAS-VA NOT EQUAL 'OUTROS' */

                    if (PROPVA.DCLPROPOSTAS_VA.PROFIS_ESPOSA != "OUTROS")
                    {

                        /*" -1444- MOVE PROFIS-ESPOSA OF DCLPROPOSTAS-VA TO CBO-DESCR-CBO OF DCLCBO */
                        _.Move(PROPVA.DCLPROPOSTAS_VA.PROFIS_ESPOSA, CBO.DCLCBO.CBO_DESCR_CBO);

                        /*" -1446- PERFORM R0410-00-LER-CBO */

                        R0410_00_LER_CBO_SECTION();

                        /*" -1447- IF SQLCODE EQUAL 00 */

                        if (DB.SQLCODE == 00)
                        {

                            /*" -1449- MOVE CBO-COD-CBO OF DCLCBO TO COD-CBO-CONJ */
                            _.Move(CBO.DCLCBO.CBO_COD_CBO, COD_CBO_CONJ);

                            /*" -1450- ELSE */
                        }
                        else
                        {


                            /*" -1451- MOVE ZEROS TO COD-CBO-CONJ */
                            _.Move(0, COD_CBO_CONJ);

                            /*" -1452- ELSE */
                        }

                    }
                    else
                    {


                        /*" -1453- MOVE ZEROS TO COD-CBO-CONJ */
                        _.Move(0, COD_CBO_CONJ);

                        /*" -1454- ELSE */
                    }

                }
                else
                {


                    /*" -1454- MOVE ZEROS TO COD-CBO-CONJ. */
                    _.Move(0, COD_CBO_CONJ);
                }

            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0400_SAIDA*/

        [StopWatch]
        /*" R0410-00-LER-CBO-SECTION */
        private void R0410_00_LER_CBO_SECTION()
        {
            /*" -1464- MOVE 'R0400-00-LER-CBO' TO PARAGRAFO. */
            _.Move("R0400-00-LER-CBO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1466- MOVE 'SELECT CBO' TO COMANDO. */
            _.Move("SELECT CBO", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1479- PERFORM R0410_00_LER_CBO_DB_SELECT_1 */

            R0410_00_LER_CBO_DB_SELECT_1();

            /*" -1482- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -1484- IF SQLCODE EQUAL 811 OR -811 NEXT SENTENCE */

                if (DB.SQLCODE.In("811", "-811"))
                {

                    /*" -1485- ELSE */
                }
                else
                {


                    /*" -1486- IF SQLCODE NOT EQUAL 100 */

                    if (DB.SQLCODE != 100)
                    {

                        /*" -1487- DISPLAY 'VA4648B - FIM ANORMAL' */
                        _.Display($"VA4648B - FIM ANORMAL");

                        /*" -1488- DISPLAY '          ERRO SELECT TABELA CBO' */
                        _.Display($"          ERRO SELECT TABELA CBO");

                        /*" -1490- DISPLAY '          NUMERO CERTIFICADO...... ' NUM-CERTIFICADO OF DCLPROPOSTAS-VA */
                        _.Display($"          NUMERO CERTIFICADO...... {PROPVA.DCLPROPOSTAS_VA.NUM_CERTIFICADO}");

                        /*" -1492- DISPLAY '          DESCRICAO DA PROFISSAO.. ' CBO-DESCR-CBO OF DCLCBO */
                        _.Display($"          DESCRICAO DA PROFISSAO.. {CBO.DCLCBO.CBO_DESCR_CBO}");

                        /*" -1494- DISPLAY '          SQLCODE................. ' SQLCODE */
                        _.Display($"          SQLCODE................. {DB.SQLCODE}");

                        /*" -1495- PERFORM R9988-00-FECHAR-ARQUIVOS */

                        R9988_00_FECHAR_ARQUIVOS_SECTION();

                        /*" -1495- PERFORM R9999-00-FINALIZAR. */

                        R9999_00_FINALIZAR_SECTION();
                    }

                }

            }


        }

        [StopWatch]
        /*" R0410-00-LER-CBO-DB-SELECT-1 */
        public void R0410_00_LER_CBO_DB_SELECT_1()
        {
            /*" -1479- EXEC SQL SELECT DISTINCT COD_CBO , DESCR_CBO INTO :DCLCBO.CBO-COD-CBO , :DCLCBO.CBO-DESCR-CBO FROM SEGUROS.CBO WHERE DESCR_CBO = :DCLCBO.CBO-DESCR-CBO AND COD_CBO < 1000 ORDER BY COD_CBO , DESCR_CBO END-EXEC. */

            var r0410_00_LER_CBO_DB_SELECT_1_Query1 = new R0410_00_LER_CBO_DB_SELECT_1_Query1()
            {
                CBO_DESCR_CBO = CBO.DCLCBO.CBO_DESCR_CBO.ToString(),
            };

            var executed_1 = R0410_00_LER_CBO_DB_SELECT_1_Query1.Execute(r0410_00_LER_CBO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CBO_COD_CBO, CBO.DCLCBO.CBO_COD_CBO);
                _.Move(executed_1.CBO_DESCR_CBO, CBO.DCLCBO.CBO_DESCR_CBO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0410_SAIDA*/

        [StopWatch]
        /*" R0550-00-LER-OPCAOPAGVA-SECTION */
        private void R0550_00_LER_OPCAOPAGVA_SECTION()
        {
            /*" -1505- MOVE 'R0550-00-LER-OPCAOPAGVA' TO PARAGRAFO. */
            _.Move("R0550-00-LER-OPCAOPAGVA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1507- MOVE 'SELECT OPCAOPAGVA' TO COMANDO. */
            _.Move("SELECT OPCAOPAGVA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1509- INITIALIZE DCLOPCAO-PAG-VIDAZUL */
            _.Initialize(
                OPPAGVA.DCLOPCAO_PAG_VIDAZUL
            );

            /*" -1512- MOVE NUM-CERTIFICADO OF DCLPROPOSTAS-VA TO OPPAGVA-NUM-CERTIFICADO. */
            _.Move(PROPVA.DCLPROPOSTAS_VA.NUM_CERTIFICADO, OPPAGVA.DCLOPCAO_PAG_VIDAZUL.OPPAGVA_NUM_CERTIFICADO);

            /*" -1538- PERFORM R0550_00_LER_OPCAOPAGVA_DB_SELECT_1 */

            R0550_00_LER_OPCAOPAGVA_DB_SELECT_1();

            /*" -1541- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -1542- DISPLAY 'VA4648B - FIM ANORMAL' */
                _.Display($"VA4648B - FIM ANORMAL");

                /*" -1543- DISPLAY '          ERRO SELECT OPCAOPAGVA' */
                _.Display($"          ERRO SELECT OPCAOPAGVA");

                /*" -1545- DISPLAY '          NUMERO CERTIFICADO.....' OPPAGVA-NUM-CERTIFICADO */
                _.Display($"          NUMERO CERTIFICADO.....{OPPAGVA.DCLOPCAO_PAG_VIDAZUL.OPPAGVA_NUM_CERTIFICADO}");

                /*" -1547- DISPLAY '          SQLCODE................ ' SQLCODE */
                _.Display($"          SQLCODE................ {DB.SQLCODE}");

                /*" -1548- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -1548- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R0550-00-LER-OPCAOPAGVA-DB-SELECT-1 */
        public void R0550_00_LER_OPCAOPAGVA_DB_SELECT_1()
        {
            /*" -1538- EXEC SQL SELECT NUM_CERTIFICADO , DATA_INIVIGENCIA , DATA_TERVIGENCIA , OPCAO_PAGAMENTO , DIA_DEBITO , COD_AGENCIA_DEBITO , OPE_CONTA_DEBITO , NUM_CONTA_DEBITO , DIG_CONTA_DEBITO INTO :OPPAGVA-NUM-CERTIFICADO , :OPPAGVA-DATA-INIVIGENCIA , :OPPAGVA-DATA-TERVIGENCIA , :OPPAGVA-OPCAO-PAGAMENTO , :OPPAGVA-DIA-DEBITO , :OPPAGVA-COD-AGENCIA-DEBITO:VIND-AGEDEB, :OPPAGVA-OPE-CONTA-DEBITO:VIND-OPRCTADEB, :OPPAGVA-NUM-CONTA-DEBITO:VIND-NUMCTADEB, :OPPAGVA-DIG-CONTA-DEBITO:VIND-DIGCTADEB FROM SEGUROS.OPCAO_PAG_VIDAZUL WHERE NUM_CERTIFICADO = :OPPAGVA-NUM-CERTIFICADO AND DATA_TERVIGENCIA IN (:HOST-DT-TERVIG1, :HOST-DT-TERVIG2) END-EXEC. */

            var r0550_00_LER_OPCAOPAGVA_DB_SELECT_1_Query1 = new R0550_00_LER_OPCAOPAGVA_DB_SELECT_1_Query1()
            {
                OPPAGVA_NUM_CERTIFICADO = OPPAGVA.DCLOPCAO_PAG_VIDAZUL.OPPAGVA_NUM_CERTIFICADO.ToString(),
                HOST_DT_TERVIG1 = WAREA_AUXILIAR.HOST_DT_TERVIG1.ToString(),
                HOST_DT_TERVIG2 = WAREA_AUXILIAR.HOST_DT_TERVIG2.ToString(),
            };

            var executed_1 = R0550_00_LER_OPCAOPAGVA_DB_SELECT_1_Query1.Execute(r0550_00_LER_OPCAOPAGVA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.OPPAGVA_NUM_CERTIFICADO, OPPAGVA.DCLOPCAO_PAG_VIDAZUL.OPPAGVA_NUM_CERTIFICADO);
                _.Move(executed_1.OPPAGVA_DATA_INIVIGENCIA, OPPAGVA.DCLOPCAO_PAG_VIDAZUL.OPPAGVA_DATA_INIVIGENCIA);
                _.Move(executed_1.OPPAGVA_DATA_TERVIGENCIA, OPPAGVA.DCLOPCAO_PAG_VIDAZUL.OPPAGVA_DATA_TERVIGENCIA);
                _.Move(executed_1.OPPAGVA_OPCAO_PAGAMENTO, OPPAGVA.DCLOPCAO_PAG_VIDAZUL.OPPAGVA_OPCAO_PAGAMENTO);
                _.Move(executed_1.OPPAGVA_DIA_DEBITO, OPPAGVA.DCLOPCAO_PAG_VIDAZUL.OPPAGVA_DIA_DEBITO);
                _.Move(executed_1.OPPAGVA_COD_AGENCIA_DEBITO, OPPAGVA.DCLOPCAO_PAG_VIDAZUL.OPPAGVA_COD_AGENCIA_DEBITO);
                _.Move(executed_1.VIND_AGEDEB, VIND_AGEDEB);
                _.Move(executed_1.OPPAGVA_OPE_CONTA_DEBITO, OPPAGVA.DCLOPCAO_PAG_VIDAZUL.OPPAGVA_OPE_CONTA_DEBITO);
                _.Move(executed_1.VIND_OPRCTADEB, VIND_OPRCTADEB);
                _.Move(executed_1.OPPAGVA_NUM_CONTA_DEBITO, OPPAGVA.DCLOPCAO_PAG_VIDAZUL.OPPAGVA_NUM_CONTA_DEBITO);
                _.Move(executed_1.VIND_NUMCTADEB, VIND_NUMCTADEB);
                _.Move(executed_1.OPPAGVA_DIG_CONTA_DEBITO, OPPAGVA.DCLOPCAO_PAG_VIDAZUL.OPPAGVA_DIG_CONTA_DEBITO);
                _.Move(executed_1.VIND_DIGCTADEB, VIND_DIGCTADEB);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0550_SAIDA*/

        [StopWatch]
        /*" R0570-00-LER-COMISSAO-SECTION */
        private void R0570_00_LER_COMISSAO_SECTION()
        {
            /*" -1558- MOVE 'R0570-00-LER-COMISSAO' TO PARAGRAFO. */
            _.Move("R0570-00-LER-COMISSAO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1560- MOVE 'SELECT FUNDOCOMISVA' TO COMANDO. */
            _.Move("SELECT FUNDOCOMISVA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1563- MOVE NUM-CERTIFICADO OF DCLPROPOSTAS-VA TO NUM-CERTIFICADO OF DCLFUNDO-COMISSAO-VA */
            _.Move(PROPVA.DCLPROPOSTAS_VA.NUM_CERTIFICADO, FDCOMVA.DCLFUNDO_COMISSAO_VA.NUM_CERTIFICADO);

            /*" -1566- MOVE 1101 TO COD-OPERACAO OF DCLFUNDO-COMISSAO-VA */
            _.Move(1101, FDCOMVA.DCLFUNDO_COMISSAO_VA.COD_OPERACAO);

            /*" -1576- PERFORM R0570_00_LER_COMISSAO_DB_DECLARE_1 */

            R0570_00_LER_COMISSAO_DB_DECLARE_1();

            /*" -1579- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -1580- DISPLAY 'VA4648B - FIM ANORMAL' */
                _.Display($"VA4648B - FIM ANORMAL");

                /*" -1581- DISPLAY '          ERRO DECLARE CURSOR FUNDOCOMISVA' */
                _.Display($"          ERRO DECLARE CURSOR FUNDOCOMISVA");

                /*" -1583- DISPLAY '          NUMERO CERTIFICADO.............. ' NUM-CERTIFICADO OF DCLFUNDO-COMISSAO-VA */
                _.Display($"          NUMERO CERTIFICADO.............. {FDCOMVA.DCLFUNDO_COMISSAO_VA.NUM_CERTIFICADO}");

                /*" -1585- DISPLAY '          SQLCODE......................... ' SQLCODE */
                _.Display($"          SQLCODE......................... {DB.SQLCODE}");

                /*" -1586- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -1588- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


            /*" -1588- PERFORM R0570_00_LER_COMISSAO_DB_OPEN_1 */

            R0570_00_LER_COMISSAO_DB_OPEN_1();

            /*" -1591- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -1592- DISPLAY 'VA4648B - FIM ANORMAL' */
                _.Display($"VA4648B - FIM ANORMAL");

                /*" -1593- DISPLAY '          ERRO OPEN CURSOR FUNDOCOMISVA' */
                _.Display($"          ERRO OPEN CURSOR FUNDOCOMISVA");

                /*" -1595- DISPLAY '          NUMERO CERTIFICADO........... ' NUM-CERTIFICADO OF DCLFUNDO-COMISSAO-VA */
                _.Display($"          NUMERO CERTIFICADO........... {FDCOMVA.DCLFUNDO_COMISSAO_VA.NUM_CERTIFICADO}");

                /*" -1597- DISPLAY '          SQLCODE...................... ' SQLCODE */
                _.Display($"          SQLCODE...................... {DB.SQLCODE}");

                /*" -1598- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -1600- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


            /*" -1606- PERFORM R0570_00_LER_COMISSAO_DB_FETCH_1 */

            R0570_00_LER_COMISSAO_DB_FETCH_1();

            /*" -1609- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -1610- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1613- MOVE ZEROS TO VAL-COMISSAO-VG OF DCLFUNDO-COMISSAO-VA, VAL-COMISSAO-AP OF DCLFUNDO-COMISSAO-VA */
                    _.Move(0, FDCOMVA.DCLFUNDO_COMISSAO_VA.VAL_COMISSAO_VG, FDCOMVA.DCLFUNDO_COMISSAO_VA.VAL_COMISSAO_AP);

                    /*" -1614- ELSE */
                }
                else
                {


                    /*" -1615- DISPLAY 'VA4648B - FIM ANORMAL' */
                    _.Display($"VA4648B - FIM ANORMAL");

                    /*" -1616- DISPLAY '          ERRO SELECT CURSOR FUNDOCOMISVA' */
                    _.Display($"          ERRO SELECT CURSOR FUNDOCOMISVA");

                    /*" -1618- DISPLAY '          NUMERO CERTIFICADO............. ' NUM-CERTIFICADO OF DCLFUNDO-COMISSAO-VA */
                    _.Display($"          NUMERO CERTIFICADO............. {FDCOMVA.DCLFUNDO_COMISSAO_VA.NUM_CERTIFICADO}");

                    /*" -1620- DISPLAY '          SQLCODE........................ ' SQLCODE */
                    _.Display($"          SQLCODE........................ {DB.SQLCODE}");

                    /*" -1621- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -1623- PERFORM R9999-00-FINALIZAR. */

                    R9999_00_FINALIZAR_SECTION();
                }

            }


            /*" -1623- PERFORM R0570_00_LER_COMISSAO_DB_CLOSE_1 */

            R0570_00_LER_COMISSAO_DB_CLOSE_1();

            /*" -1626- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -1627- DISPLAY 'VA4648B - FIM ANORMAL' */
                _.Display($"VA4648B - FIM ANORMAL");

                /*" -1628- DISPLAY '          ERRO CLOSE CURSOR FUNDOCOMISVA' */
                _.Display($"          ERRO CLOSE CURSOR FUNDOCOMISVA");

                /*" -1630- DISPLAY '          NUMERO CERTIFICADO............ ' NUM-CERTIFICADO OF DCLFUNDO-COMISSAO-VA */
                _.Display($"          NUMERO CERTIFICADO............ {FDCOMVA.DCLFUNDO_COMISSAO_VA.NUM_CERTIFICADO}");

                /*" -1632- DISPLAY '          SQLCODE....................... ' SQLCODE */
                _.Display($"          SQLCODE....................... {DB.SQLCODE}");

                /*" -1633- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -1633- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R0570-00-LER-COMISSAO-DB-OPEN-1 */
        public void R0570_00_LER_COMISSAO_DB_OPEN_1()
        {
            /*" -1588- EXEC SQL OPEN FUNDOCOMISVA END-EXEC. */

            FUNDOCOMISVA.Open();

        }

        [StopWatch]
        /*" R0570-00-LER-COMISSAO-DB-FETCH-1 */
        public void R0570_00_LER_COMISSAO_DB_FETCH_1()
        {
            /*" -1606- EXEC SQL FETCH FUNDOCOMISVA INTO :DCLFUNDO-COMISSAO-VA.NUM-CERTIFICADO , :DCLFUNDO-COMISSAO-VA.VAL-COMISSAO-VG , :DCLFUNDO-COMISSAO-VA.VAL-COMISSAO-AP END-EXEC. */

            if (FUNDOCOMISVA.Fetch())
            {
                _.Move(FUNDOCOMISVA.DCLFUNDO_COMISSAO_VA_NUM_CERTIFICADO, FDCOMVA.DCLFUNDO_COMISSAO_VA.NUM_CERTIFICADO);
                _.Move(FUNDOCOMISVA.DCLFUNDO_COMISSAO_VA_VAL_COMISSAO_VG, FDCOMVA.DCLFUNDO_COMISSAO_VA.VAL_COMISSAO_VG);
                _.Move(FUNDOCOMISVA.DCLFUNDO_COMISSAO_VA_VAL_COMISSAO_AP, FDCOMVA.DCLFUNDO_COMISSAO_VA.VAL_COMISSAO_AP);
            }

        }

        [StopWatch]
        /*" R0570-00-LER-COMISSAO-DB-CLOSE-1 */
        public void R0570_00_LER_COMISSAO_DB_CLOSE_1()
        {
            /*" -1623- EXEC SQL CLOSE FUNDOCOMISVA END-EXEC. */

            FUNDOCOMISVA.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0570_SAIDA*/

        [StopWatch]
        /*" R0580-00-OBTER-VAL-TARIFA-SECTION */
        private void R0580_00_OBTER_VAL_TARIFA_SECTION()
        {
            /*" -1643- MOVE 'R0580-00-OBTER-VAL-TARIFA' TO PARAGRAFO. */
            _.Move("R0580-00-OBTER-VAL-TARIFA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1645- MOVE 'SELECT TARIFA-BALCAO-CEF' TO COMANDO. */
            _.Move("SELECT TARIFA-BALCAO-CEF", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1648- MOVE NUM-CERTIFICADO OF DCLPROPOSTAS-VA TO NUM-CERTIFICADO OF DCLTARIFA-BALCAO-CEF. */
            _.Move(PROPVA.DCLPROPOSTAS_VA.NUM_CERTIFICADO, TARIBCEF.DCLTARIFA_BALCAO_CEF.NUM_CERTIFICADO);

            /*" -1659- PERFORM R0580_00_OBTER_VAL_TARIFA_DB_SELECT_1 */

            R0580_00_OBTER_VAL_TARIFA_DB_SELECT_1();

            /*" -1662- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -1663- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1664- MOVE ZEROS TO VAL-TARIFA OF DCLTARIFA-BALCAO-CEF */
                    _.Move(0, TARIBCEF.DCLTARIFA_BALCAO_CEF.VAL_TARIFA);

                    /*" -1665- ELSE */
                }
                else
                {


                    /*" -1666- DISPLAY 'VA4648B - FIM ANORMAL' */
                    _.Display($"VA4648B - FIM ANORMAL");

                    /*" -1667- DISPLAY '          ERRO SELECT TAB. TARIFA-BALCAO-CEF' */
                    _.Display($"          ERRO SELECT TAB. TARIFA-BALCAO-CEF");

                    /*" -1669- DISPLAY '          NUMERO CERTIFICADO........ ' NUM-CERTIFICADO OF DCLTARIFA-BALCAO-CEF */
                    _.Display($"          NUMERO CERTIFICADO........ {TARIBCEF.DCLTARIFA_BALCAO_CEF.NUM_CERTIFICADO}");

                    /*" -1671- DISPLAY '          SQLCODE................... ' SQLCODE */
                    _.Display($"          SQLCODE................... {DB.SQLCODE}");

                    /*" -1672- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -1672- PERFORM R9999-00-FINALIZAR. */

                    R9999_00_FINALIZAR_SECTION();
                }

            }


        }

        [StopWatch]
        /*" R0580-00-OBTER-VAL-TARIFA-DB-SELECT-1 */
        public void R0580_00_OBTER_VAL_TARIFA_DB_SELECT_1()
        {
            /*" -1659- EXEC SQL SELECT VAL_TARIFA INTO :DCLTARIFA-BALCAO-CEF.VAL-TARIFA FROM SEGUROS.TARIFA_BALCAO_CEF WHERE COD_EMPRESA = 0 AND NUM_MATRICULA = 9999999 AND TIPO_FUNCIONARIO = '5' AND NUM_CERTIFICADO = :DCLTARIFA-BALCAO-CEF.NUM-CERTIFICADO END-EXEC. */

            var r0580_00_OBTER_VAL_TARIFA_DB_SELECT_1_Query1 = new R0580_00_OBTER_VAL_TARIFA_DB_SELECT_1_Query1()
            {
                NUM_CERTIFICADO = TARIBCEF.DCLTARIFA_BALCAO_CEF.NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = R0580_00_OBTER_VAL_TARIFA_DB_SELECT_1_Query1.Execute(r0580_00_OBTER_VAL_TARIFA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.VAL_TARIFA, TARIBCEF.DCLTARIFA_BALCAO_CEF.VAL_TARIFA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0580_SAIDA*/

        [StopWatch]
        /*" R0600-00-GERAR-REGISTRO-TP1-SECTION */
        private void R0600_00_GERAR_REGISTRO_TP1_SECTION()
        {
            /*" -1683- MOVE 'R0600-00-GERAR-REGISTRO-TP1' TO PARAGRAFO. */
            _.Move("R0600-00-GERAR-REGISTRO-TP1", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1685- MOVE SPACES TO REG-PRP-SASSE. */
            _.Move("", REG_PRP_SASSE);

            /*" -1688- MOVE '1' TO R1-TIPO-REG OF REG-CLIENTES. */
            _.Move("1", LBFPF011.REG_CLIENTES.R1_TIPO_REG);

            /*" -1692- MOVE NUM-CERTIFICADO OF DCLPROPOSTAS-VA TO R1-NUM-PROPOSTA OF REG-CLIENTES DISC-NUM-CERTIFICADO */
            _.Move(PROPVA.DCLPROPOSTAS_VA.NUM_CERTIFICADO, LBFPF011.REG_CLIENTES.R1_NUM_PROPOSTA, WS_REG_DISCADOR.DISC_NUM_CERTIFICADO);

            /*" -1695- MOVE PRODUVG-COD-PRODUTO TO DISC-COD-PRODUTO */
            _.Move(PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_PRODUTO, WS_REG_DISCADOR.DISC_COD_PRODUTO);

            /*" -1698- MOVE PRODUVG-NOME-PRODUTO TO DISC-NOM-PRODUTO */
            _.Move(PRODUVG.DCLPRODUTOS_VG.PRODUVG_NOME_PRODUTO, WS_REG_DISCADOR.DISC_NOM_PRODUTO);

            /*" -1701- MOVE CLIENEMA-EMAIL TO DISC-EMAIL */
            _.Move(CLIENEMA.DCLCLIENTE_EMAIL.CLIENEMA_EMAIL, WS_REG_DISCADOR.DISC_EMAIL);

            /*" -1705- MOVE CGCCPF OF DCLCLIENTES TO R1-CGC-CPF OF REG-CLIENTES DISC-CPF */
            _.Move(CLIENTE.DCLCLIENTES.CGCCPF, LBFPF011.REG_CLIENTES.R1_CGC_CPF, WS_REG_DISCADOR.DISC_CPF);

            /*" -1706- IF VIND-DTNASCI LESS ZEROS */

            if (VIND_DTNASCI < 00)
            {

                /*" -1709- MOVE '1960-01-01' TO DATA-NASCIMENTO OF DCLCLIENTES. */
                _.Move("1960-01-01", CLIENTE.DCLCLIENTES.DATA_NASCIMENTO);
            }


            /*" -1711- MOVE DATA-NASCIMENTO OF DCLCLIENTES TO W-DATA-SQL */
            _.Move(CLIENTE.DCLCLIENTES.DATA_NASCIMENTO, WAREA_AUXILIAR.W_DATA_SQL);

            /*" -1712- MOVE W-DIA-SQL TO W-DIA-TRABALHO */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_DIA_SQL, WAREA_AUXILIAR.FILLER_29.W_DIA_TRABALHO);

            /*" -1713- MOVE W-MES-SQL TO W-MES-TRABALHO */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_MES_SQL, WAREA_AUXILIAR.FILLER_29.W_MES_TRABALHO);

            /*" -1714- MOVE W-ANO-SQL TO W-ANO-TRABALHO */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_ANO_SQL, WAREA_AUXILIAR.FILLER_29.W_ANO_TRABALHO);

            /*" -1717- MOVE W-DATA-TRABALHO TO R1-DATA-NASCIMENTO OF REG-CLIENTES. */
            _.Move(WAREA_AUXILIAR.W_DATA_TRABALHO, LBFPF011.REG_CLIENTES.R1_DATA_NASCIMENTO);

            /*" -1721- MOVE NOME-RAZAO OF DCLCLIENTES TO R1-NOME-PESSOA OF REG-CLIENTES DISC-NOME-CLIENTE */
            _.Move(CLIENTE.DCLCLIENTES.NOME_RAZAO, LBFPF011.REG_CLIENTES.R1_NOME_PESSOA, WS_REG_DISCADOR.DISC_NOME_CLIENTE);

            /*" -1722- IF TIPO-PESSOA OF DCLCLIENTES EQUAL 'F' */

            if (CLIENTE.DCLCLIENTES.TIPO_PESSOA == "F")
            {

                /*" -1723- MOVE 1 TO R1-TIPO-PESSOA OF REG-CLIENTES */
                _.Move(1, LBFPF011.REG_CLIENTES.R1_TIPO_PESSOA);

                /*" -1724- ELSE */
            }
            else
            {


                /*" -1726- MOVE 2 TO R1-TIPO-PESSOA OF REG-CLIENTES. */
                _.Move(2, LBFPF011.REG_CLIENTES.R1_TIPO_PESSOA);
            }


            /*" -1731- MOVE SPACES TO R1-UF-EXPEDIDORA OF REG-CLIENTES R1-CODIGO-SEGMENTO OF REG-CLIENTES R1-ORGAO-EXPEDIDOR OF REG-CLIENTES. */
            _.Move("", LBFPF011.REG_CLIENTES.R1_UF_EXPEDIDORA, LBFPF011.REG_CLIENTES.R1_CODIGO_SEGMENTO, LBFPF011.REG_CLIENTES.R1_ORGAO_EXPEDIDOR);

            /*" -1735- MOVE ZEROS TO R1-NUM-IDENTIDADE OF REG-CLIENTES R1-DATA-EXPEDICAO-RG OF REG-CLIENTES. */
            _.Move(0, LBFPF011.REG_CLIENTES.R1_NUM_IDENTIDADE, LBFPF011.REG_CLIENTES.R1_DATA_EXPEDICAO_RG);

            /*" -1737- MOVE ZERO TO W-OBTER-DADOS-RG. */
            _.Move(0, WAREA_AUXILIAR.W_OBTER_DADOS_RG);

            /*" -1739- PERFORM R0620-00-DADOS-RG. */

            R0620_00_DADOS_RG_SECTION();

            /*" -1740- IF OBTEVE-DADOS-RG */

            if (WAREA_AUXILIAR.W_OBTER_DADOS_RG["OBTEVE_DADOS_RG"])
            {

                /*" -1743- MOVE GEDOCCLI-COD-IDENTIFICACAO TO R1-NUM-IDENTIDADE OF REG-CLIENTES */
                _.Move(GEDOCCLI.DCLGE_DOC_CLIENTE.GEDOCCLI_COD_IDENTIFICACAO, LBFPF011.REG_CLIENTES.R1_NUM_IDENTIDADE);

                /*" -1746- MOVE GEDOCCLI-NOM-ORGAO-EXP TO W-NOM-ORGAO-EXP */
                _.Move(GEDOCCLI.DCLGE_DOC_CLIENTE.GEDOCCLI_NOM_ORGAO_EXP, WAREA_AUXILIAR.W_NOM_ORGAO_EXP);

                /*" -1749- MOVE W-ORGAO-EXPEDIDOR TO R1-ORGAO-EXPEDIDOR OF REG-CLIENTES */
                _.Move(WAREA_AUXILIAR.FILLER_32.W_ORGAO_EXPEDIDOR, LBFPF011.REG_CLIENTES.R1_ORGAO_EXPEDIDOR);

                /*" -1751- MOVE GEDOCCLI-DTH-EXPEDICAO TO W-DATA-SQL */
                _.Move(GEDOCCLI.DCLGE_DOC_CLIENTE.GEDOCCLI_DTH_EXPEDICAO, WAREA_AUXILIAR.W_DATA_SQL);

                /*" -1752- MOVE W-DIA-SQL TO W-DIA-TRABALHO */
                _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_DIA_SQL, WAREA_AUXILIAR.FILLER_29.W_DIA_TRABALHO);

                /*" -1753- MOVE W-MES-SQL TO W-MES-TRABALHO */
                _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_MES_SQL, WAREA_AUXILIAR.FILLER_29.W_MES_TRABALHO);

                /*" -1754- MOVE W-ANO-SQL TO W-ANO-TRABALHO */
                _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_ANO_SQL, WAREA_AUXILIAR.FILLER_29.W_ANO_TRABALHO);

                /*" -1757- MOVE W-DATA-TRABALHO TO R1-DATA-EXPEDICAO-RG OF REG-CLIENTES */
                _.Move(WAREA_AUXILIAR.W_DATA_TRABALHO, LBFPF011.REG_CLIENTES.R1_DATA_EXPEDICAO_RG);

                /*" -1760- MOVE GEDOCCLI-COD-UF TO R1-UF-EXPEDIDORA OF REG-CLIENTES. */
                _.Move(GEDOCCLI.DCLGE_DOC_CLIENTE.GEDOCCLI_COD_UF, LBFPF011.REG_CLIENTES.R1_UF_EXPEDIDORA);
            }


            /*" -1761- IF ESTADO-CIVIL OF DCLPROPOSTAS-VA EQUAL 'S' */

            if (PROPVA.DCLPROPOSTAS_VA.ESTADO_CIVIL == "S")
            {

                /*" -1762- MOVE 1 TO R1-ESTADO-CIVIL OF REG-CLIENTES */
                _.Move(1, LBFPF011.REG_CLIENTES.R1_ESTADO_CIVIL);

                /*" -1763- ELSE */
            }
            else
            {


                /*" -1764- IF ESTADO-CIVIL OF DCLPROPOSTAS-VA EQUAL 'C' */

                if (PROPVA.DCLPROPOSTAS_VA.ESTADO_CIVIL == "C")
                {

                    /*" -1765- MOVE 2 TO R1-ESTADO-CIVIL OF REG-CLIENTES */
                    _.Move(2, LBFPF011.REG_CLIENTES.R1_ESTADO_CIVIL);

                    /*" -1766- ELSE */
                }
                else
                {


                    /*" -1767- IF ESTADO-CIVIL OF DCLPROPOSTAS-VA EQUAL 'V' */

                    if (PROPVA.DCLPROPOSTAS_VA.ESTADO_CIVIL == "V")
                    {

                        /*" -1768- MOVE 3 TO R1-ESTADO-CIVIL OF REG-CLIENTES */
                        _.Move(3, LBFPF011.REG_CLIENTES.R1_ESTADO_CIVIL);

                        /*" -1769- ELSE */
                    }
                    else
                    {


                        /*" -1771- MOVE 4 TO R1-ESTADO-CIVIL OF REG-CLIENTES. */
                        _.Move(4, LBFPF011.REG_CLIENTES.R1_ESTADO_CIVIL);
                    }

                }

            }


            /*" -1772- IF IDE-SEXO OF DCLPROPOSTAS-VA EQUAL 'M' */

            if (PROPVA.DCLPROPOSTAS_VA.IDE_SEXO == "M")
            {

                /*" -1773- MOVE 1 TO R1-IDE-SEXO OF REG-CLIENTES */
                _.Move(1, LBFPF011.REG_CLIENTES.R1_IDE_SEXO);

                /*" -1774- ELSE */
            }
            else
            {


                /*" -1776- MOVE 2 TO R1-IDE-SEXO OF REG-CLIENTES. */
                _.Move(2, LBFPF011.REG_CLIENTES.R1_IDE_SEXO);
            }


            /*" -1779- MOVE COD-CBO-TIT TO R1-COD-CBO OF REG-CLIENTES. */
            _.Move(COD_CBO_TIT, LBFPF011.REG_CLIENTES.R1_COD_CBO);

            /*" -1783- MOVE ENDERECO-DDD OF DCLENDERECOS TO R1-DDD(1) DISC-DDD1 */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_DDD, LBFPF011.REG_CLIENTES.R1_TELEFONE[1].R1_DDD, WS_REG_DISCADOR.DISC_DDD1);

            /*" -1787- MOVE ENDERECO-TELEFONE OF DCLENDERECOS TO R1-NUM-FONE(1) DISC-TELEFONE1 */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_TELEFONE, LBFPF011.REG_CLIENTES.R1_TELEFONE[1].R1_NUM_FONE, WS_REG_DISCADOR.DISC_TELEFONE1);

            /*" -1791- MOVE ENDERECO-DDD OF DCLENDERECOS TO R1-DDD(2) DISC-DDD2 */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_DDD, LBFPF011.REG_CLIENTES.R1_TELEFONE[2].R1_DDD, WS_REG_DISCADOR.DISC_DDD2);

            /*" -1795- MOVE ENDERECO-DDD OF DCLENDERECOS TO R1-DDD(3) DISC-DDD3 */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_DDD, LBFPF011.REG_CLIENTES.R1_TELEFONE[3].R1_DDD, WS_REG_DISCADOR.DISC_DDD3);

            /*" -1799- MOVE ENDERECO-FAX OF DCLENDERECOS TO R1-NUM-FONE(2) DISC-TELEFONE2 */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_FAX, LBFPF011.REG_CLIENTES.R1_TELEFONE[2].R1_NUM_FONE, WS_REG_DISCADOR.DISC_TELEFONE2);

            /*" -1803- MOVE ENDERECO-TELEX OF DCLENDERECOS TO R1-NUM-FONE(3) DISC-TELEFONE3 */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_TELEX, LBFPF011.REG_CLIENTES.R1_TELEFONE[3].R1_NUM_FONE, WS_REG_DISCADOR.DISC_TELEFONE3);

            /*" -1804- IF VIND-NOME-ESPOSA LESS ZEROS */

            if (VIND_NOME_ESPOSA < 00)
            {

                /*" -1806- MOVE SPACES TO R1-NOME-CONJUGE OF REG-CLIENTES */
                _.Move("", LBFPF011.REG_CLIENTES.R1_NOME_CONJUGE);

                /*" -1807- ELSE */
            }
            else
            {


                /*" -1810- MOVE NOME-ESPOSA OF DCLPROPOSTAS-VA TO R1-NOME-CONJUGE OF REG-CLIENTES. */
                _.Move(PROPVA.DCLPROPOSTAS_VA.NOME_ESPOSA, LBFPF011.REG_CLIENTES.R1_NOME_CONJUGE);
            }


            /*" -1811- IF VIND-DTNASC-ESPOSA LESS ZEROS */

            if (VIND_DTNASC_ESPOSA < 00)
            {

                /*" -1813- MOVE ZEROS TO R1-DTNASC-CONJUGE OF REG-CLIENTES */
                _.Move(0, LBFPF011.REG_CLIENTES.R1_DTNASC_CONJUGE);

                /*" -1815- MOVE -1 TO VIND-DTNASC-ESPOSA */
                _.Move(-1, VIND_DTNASC_ESPOSA);

                /*" -1816- ELSE */
            }
            else
            {


                /*" -1819- MOVE DTNASC-ESPOSA OF DCLPROPOSTAS-VA TO W-DATA-SQL */
                _.Move(PROPVA.DCLPROPOSTAS_VA.DTNASC_ESPOSA, WAREA_AUXILIAR.W_DATA_SQL);

                /*" -1820- MOVE W-DIA-SQL TO W-DIA-TRABALHO */
                _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_DIA_SQL, WAREA_AUXILIAR.FILLER_29.W_DIA_TRABALHO);

                /*" -1821- MOVE W-MES-SQL TO W-MES-TRABALHO */
                _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_MES_SQL, WAREA_AUXILIAR.FILLER_29.W_MES_TRABALHO);

                /*" -1822- MOVE W-ANO-SQL TO W-ANO-TRABALHO */
                _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_ANO_SQL, WAREA_AUXILIAR.FILLER_29.W_ANO_TRABALHO);

                /*" -1825- MOVE W-DATA-TRABALHO TO R1-DTNASC-CONJUGE OF REG-CLIENTES. */
                _.Move(WAREA_AUXILIAR.W_DATA_TRABALHO, LBFPF011.REG_CLIENTES.R1_DTNASC_CONJUGE);
            }


            /*" -1828- MOVE COD-CBO-CONJ TO R1-CBO-CONJUGE OF REG-CLIENTES. */
            _.Move(COD_CBO_CONJ, LBFPF011.REG_CLIENTES.R1_CBO_CONJUGE);

            /*" -1831- MOVE SPACES TO R1-EMAIL OF REG-CLIENTES. */
            _.Move("", LBFPF011.REG_CLIENTES.R1_EMAIL);

            /*" -1833- WRITE REG-PRP-SASSE FROM REG-CLIENTES. */
            _.Move(LBFPF011.REG_CLIENTES.GetMoveValues(), REG_PRP_SASSE);

            MOVTO_PRP_SASSE.Write(REG_PRP_SASSE.GetMoveValues().ToString());

            /*" -1833- ADD 1 TO W-QTD-LD-TIPO-1. */
            WAREA_AUXILIAR.W_QTD_LD_TIPO_1.Value = WAREA_AUXILIAR.W_QTD_LD_TIPO_1 + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0600_SAIDA*/

        [StopWatch]
        /*" R0620-00-DADOS-RG-SECTION */
        private void R0620_00_DADOS_RG_SECTION()
        {
            /*" -1843- MOVE 'R0620-00-DADOS-RG' TO PARAGRAFO. */
            _.Move("R0620-00-DADOS-RG", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1845- MOVE 'SELECT GE_DOC_CLIENTES' TO COMANDO. */
            _.Move("SELECT GE_DOC_CLIENTES", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1848- MOVE COD-CLIENTE OF DCLCLIENTES TO GEDOCCLI-COD-CLIENTE. */
            _.Move(CLIENTE.DCLCLIENTES.COD_CLIENTE, GEDOCCLI.DCLGE_DOC_CLIENTE.GEDOCCLI_COD_CLIENTE);

            /*" -1863- PERFORM R0620_00_DADOS_RG_DB_SELECT_1 */

            R0620_00_DADOS_RG_DB_SELECT_1();

            /*" -1866- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -1868- IF SQLCODE EQUAL 100 NEXT SENTENCE */

                if (DB.SQLCODE == 100)
                {

                    /*" -1869- ELSE */
                }
                else
                {


                    /*" -1870- DISPLAY 'VA4648B - FIM ANORMAL' */
                    _.Display($"VA4648B - FIM ANORMAL");

                    /*" -1871- DISPLAY '          ERRO SELECT TAB. GE_DOC_CLIENTES' */
                    _.Display($"          ERRO SELECT TAB. GE_DOC_CLIENTES");

                    /*" -1873- DISPLAY '          NUMERO CERTIFICADO.............. ' NUM-CERTIFICADO OF DCLPROPOSTAS-VA */
                    _.Display($"          NUMERO CERTIFICADO.............. {PROPVA.DCLPROPOSTAS_VA.NUM_CERTIFICADO}");

                    /*" -1875- DISPLAY '          CODIGO DO CLIENTE............... ' GEDOCCLI-COD-CLIENTE */
                    _.Display($"          CODIGO DO CLIENTE............... {GEDOCCLI.DCLGE_DOC_CLIENTE.GEDOCCLI_COD_CLIENTE}");

                    /*" -1877- DISPLAY '          SQLCODE......................... ' SQLCODE */
                    _.Display($"          SQLCODE......................... {DB.SQLCODE}");

                    /*" -1878- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -1879- PERFORM R9999-00-FINALIZAR */

                    R9999_00_FINALIZAR_SECTION();

                    /*" -1880- ELSE */
                }

            }
            else
            {


                /*" -1881- IF VIND-COD-UF LESS ZEROS */

                if (VIND_COD_UF < 00)
                {

                    /*" -1882- MOVE SPACES TO GEDOCCLI-COD-UF */
                    _.Move("", GEDOCCLI.DCLGE_DOC_CLIENTE.GEDOCCLI_COD_UF);

                    /*" -1883- END-IF */
                }


                /*" -1883- MOVE 1 TO W-OBTER-DADOS-RG. */
                _.Move(1, WAREA_AUXILIAR.W_OBTER_DADOS_RG);
            }


        }

        [StopWatch]
        /*" R0620-00-DADOS-RG-DB-SELECT-1 */
        public void R0620_00_DADOS_RG_DB_SELECT_1()
        {
            /*" -1863- EXEC SQL SELECT COD_CLIENTE , COD_IDENTIFICACAO , NOM_ORGAO_EXP , DTH_EXPEDICAO , COD_UF INTO :GEDOCCLI-COD-CLIENTE , :GEDOCCLI-COD-IDENTIFICACAO, :GEDOCCLI-NOM-ORGAO-EXP , :GEDOCCLI-DTH-EXPEDICAO , :GEDOCCLI-COD-UF :VIND-COD-UF FROM SEGUROS.GE_DOC_CLIENTE WHERE COD_CLIENTE = :GEDOCCLI-COD-CLIENTE END-EXEC. */

            var r0620_00_DADOS_RG_DB_SELECT_1_Query1 = new R0620_00_DADOS_RG_DB_SELECT_1_Query1()
            {
                GEDOCCLI_COD_CLIENTE = GEDOCCLI.DCLGE_DOC_CLIENTE.GEDOCCLI_COD_CLIENTE.ToString(),
            };

            var executed_1 = R0620_00_DADOS_RG_DB_SELECT_1_Query1.Execute(r0620_00_DADOS_RG_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.GEDOCCLI_COD_CLIENTE, GEDOCCLI.DCLGE_DOC_CLIENTE.GEDOCCLI_COD_CLIENTE);
                _.Move(executed_1.GEDOCCLI_COD_IDENTIFICACAO, GEDOCCLI.DCLGE_DOC_CLIENTE.GEDOCCLI_COD_IDENTIFICACAO);
                _.Move(executed_1.GEDOCCLI_NOM_ORGAO_EXP, GEDOCCLI.DCLGE_DOC_CLIENTE.GEDOCCLI_NOM_ORGAO_EXP);
                _.Move(executed_1.GEDOCCLI_DTH_EXPEDICAO, GEDOCCLI.DCLGE_DOC_CLIENTE.GEDOCCLI_DTH_EXPEDICAO);
                _.Move(executed_1.GEDOCCLI_COD_UF, GEDOCCLI.DCLGE_DOC_CLIENTE.GEDOCCLI_COD_UF);
                _.Move(executed_1.VIND_COD_UF, VIND_COD_UF);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0620_SAIDA*/

        [StopWatch]
        /*" R0650-00-GERAR-REGISTRO-TP2-SECTION */
        private void R0650_00_GERAR_REGISTRO_TP2_SECTION()
        {
            /*" -1894- MOVE 'R0650-00-GERAR-REGISTRO-TP2' TO PARAGRAFO. */
            _.Move("R0650-00-GERAR-REGISTRO-TP2", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1897- MOVE SPACES TO REG-ENDERECO, REG-PRP-SASSE. */
            _.Move("", LBFPF012.REG_ENDERECO, REG_PRP_SASSE);

            /*" -1900- MOVE '2' TO R2-TIPO-REG OF REG-ENDERECO. */
            _.Move("2", LBFPF012.REG_ENDERECO.R2_TIPO_REG);

            /*" -1903- MOVE NUM-CERTIFICADO OF DCLPROPOSTAS-VA TO R2-NUM-PROPOSTA OF REG-ENDERECO. */
            _.Move(PROPVA.DCLPROPOSTAS_VA.NUM_CERTIFICADO, LBFPF012.REG_ENDERECO.R2_NUM_PROPOSTA);

            /*" -1906- MOVE '2' TO R2-TIPO-ENDER OF REG-ENDERECO. */
            _.Move("2", LBFPF012.REG_ENDERECO.R2_TIPO_ENDER);

            /*" -1910- MOVE ENDERECO-ENDERECO OF DCLENDERECOS TO R2-ENDERECO OF REG-ENDERECO DISC-ENDERECO */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_ENDERECO, LBFPF012.REG_ENDERECO.R2_ENDERECO, WS_REG_DISCADOR.DISC_ENDERECO);

            /*" -1914- MOVE ENDERECO-BAIRRO OF DCLENDERECOS TO R2-BAIRRO OF REG-ENDERECO DISC-BAIRRO */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_BAIRRO, LBFPF012.REG_ENDERECO.R2_BAIRRO, WS_REG_DISCADOR.DISC_BAIRRO);

            /*" -1918- MOVE ENDERECO-CIDADE OF DCLENDERECOS TO R2-CIDADE OF REG-ENDERECO DISC-CIDADE */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_CIDADE, LBFPF012.REG_ENDERECO.R2_CIDADE, WS_REG_DISCADOR.DISC_CIDADE);

            /*" -1922- MOVE ENDERECO-SIGLA-UF OF DCLENDERECOS TO R2-SIGLA-UF OF REG-ENDERECO DISC-UF */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_SIGLA_UF, LBFPF012.REG_ENDERECO.R2_SIGLA_UF, WS_REG_DISCADOR.DISC_UF);

            /*" -1926- MOVE ENDERECO-CEP OF DCLENDERECOS TO R2-CEP OF REG-ENDERECO DISC-CEP */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_CEP, LBFPF012.REG_ENDERECO.R2_CEP, WS_REG_DISCADOR.DISC_CEP);

            /*" -1928- WRITE REG-PRP-SASSE FROM REG-ENDERECO. */
            _.Move(LBFPF012.REG_ENDERECO.GetMoveValues(), REG_PRP_SASSE);

            MOVTO_PRP_SASSE.Write(REG_PRP_SASSE.GetMoveValues().ToString());

            /*" -1928- ADD 1 TO W-QTD-LD-TIPO-2. */
            WAREA_AUXILIAR.W_QTD_LD_TIPO_2.Value = WAREA_AUXILIAR.W_QTD_LD_TIPO_2 + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0650_SAIDA*/

        [StopWatch]
        /*" R0700-00-GERAR-REGISTRO-TP3-SECTION */
        private void R0700_00_GERAR_REGISTRO_TP3_SECTION()
        {
            /*" -1939- MOVE 'R0700-00-GERAR-REGISTRO-TP3' TO PARAGRAFO. */
            _.Move("R0700-00-GERAR-REGISTRO-TP3", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1942- MOVE SPACES TO REG-PROPOSTA-SASSE REG-PRP-SASSE. */
            _.Move("", LXFCT004.REG_PROPOSTA_SASSE, REG_PRP_SASSE);

            /*" -1945- MOVE '3' TO R3-TIPO-REG OF REG-PROPOSTA-SASSE */
            _.Move("3", LXFCT004.REG_PROPOSTA_SASSE.R3_TIPO_REG);

            /*" -1948- MOVE NUM-CERTIFICADO OF DCLPROPOSTAS-VA TO R3-NUM-PROPOSTA OF REG-PROPOSTA-SASSE */
            _.Move(PROPVA.DCLPROPOSTAS_VA.NUM_CERTIFICADO, LXFCT004.REG_PROPOSTA_SASSE.R3_NUM_PROPOSTA);

            /*" -1951- MOVE PRODUVG-COD-PRODUTO TO R3-COD-PRODUTO OF REG-PROPOSTA-SASSE */
            _.Move(PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_PRODUTO, LXFCT004.REG_PROPOSTA_SASSE.R3_COD_PRODUTO);

            /*" -1954- MOVE AGE-COBRANCA OF DCLPROPOSTAS-VA TO R3-AGECOBR OF REG-PROPOSTA-SASSE */
            _.Move(PROPVA.DCLPROPOSTAS_VA.AGE_COBRANCA, LXFCT004.REG_PROPOSTA_SASSE.R3_AGECOBR);

            /*" -1957- MOVE DATA-QUITACAO OF DCLPROPOSTAS-VA TO W-DATA-SQL DISC-DATA-INIVIGENCIA */
            _.Move(PROPVA.DCLPROPOSTAS_VA.DATA_QUITACAO, WAREA_AUXILIAR.W_DATA_SQL, WS_REG_DISCADOR.DISC_DATA_INIVIGENCIA);

            /*" -1958- MOVE W-DIA-SQL TO W-DIA-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_DIA_SQL, WAREA_AUXILIAR.FILLER_29.W_DIA_TRABALHO);

            /*" -1959- MOVE W-MES-SQL TO W-MES-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_MES_SQL, WAREA_AUXILIAR.FILLER_29.W_MES_TRABALHO);

            /*" -1960- MOVE W-ANO-SQL TO W-ANO-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_ANO_SQL, WAREA_AUXILIAR.FILLER_29.W_ANO_TRABALHO);

            /*" -1963- MOVE W-DATA-TRABALHO TO R3-DATA-PROPOSTA OF REG-PROPOSTA-SASSE */
            _.Move(WAREA_AUXILIAR.W_DATA_TRABALHO, LXFCT004.REG_PROPOSTA_SASSE.R3_DATA_PROPOSTA);

            /*" -1966- MOVE OPPAGVA-OPCAO-PAGAMENTO TO R3-OPCAOPAG OF REG-PROPOSTA-SASSE */
            _.Move(OPPAGVA.DCLOPCAO_PAG_VIDAZUL.OPPAGVA_OPCAO_PAGAMENTO, LXFCT004.REG_PROPOSTA_SASSE.R3_OPCAOPAG);

            /*" -1967- IF R3-OPCAOPAG OF REG-PROPOSTA-SASSE = 1 OR 2 */

            if (LXFCT004.REG_PROPOSTA_SASSE.R3_OPCAOPAG.In("1", "2"))
            {

                /*" -1969- MOVE 1 TO R3-OPCAOPAG OF REG-PROPOSTA-SASSE */
                _.Move(1, LXFCT004.REG_PROPOSTA_SASSE.R3_OPCAOPAG);

                /*" -1971- MOVE 'DEBITO EM CONTA' TO DISC-OPCAO-PAGAMENTO */
                _.Move("DEBITO EM CONTA", WS_REG_DISCADOR.DISC_OPCAO_PAGAMENTO);

                /*" -1972- ELSE */
            }
            else
            {


                /*" -1973- IF R3-OPCAOPAG OF REG-PROPOSTA-SASSE = 3 */

                if (LXFCT004.REG_PROPOSTA_SASSE.R3_OPCAOPAG == 3)
                {

                    /*" -1975- MOVE 2 TO R3-OPCAOPAG OF REG-PROPOSTA-SASSE */
                    _.Move(2, LXFCT004.REG_PROPOSTA_SASSE.R3_OPCAOPAG);

                    /*" -1977- MOVE 'BOLETO' TO DISC-OPCAO-PAGAMENTO */
                    _.Move("BOLETO", WS_REG_DISCADOR.DISC_OPCAO_PAGAMENTO);

                    /*" -1978- ELSE */
                }
                else
                {


                    /*" -1979- IF R3-OPCAOPAG OF REG-PROPOSTA-SASSE = 5 */

                    if (LXFCT004.REG_PROPOSTA_SASSE.R3_OPCAOPAG == 5)
                    {

                        /*" -1981- MOVE 3 TO R3-OPCAOPAG OF REG-PROPOSTA-SASSE */
                        _.Move(3, LXFCT004.REG_PROPOSTA_SASSE.R3_OPCAOPAG);

                        /*" -1984- MOVE 'CARTAO DE CREDITO' TO DISC-OPCAO-PAGAMENTO. */
                        _.Move("CARTAO DE CREDITO", WS_REG_DISCADOR.DISC_OPCAO_PAGAMENTO);
                    }

                }

            }


            /*" -1988- MOVE DTPROXVEN OF DCLPROPOSTAS-VA TO DISC-DATA-VENCIMENTO */
            _.Move(PROPVA.DCLPROPOSTAS_VA.DTPROXVEN, WS_REG_DISCADOR.DISC_DATA_VENCIMENTO);

            /*" -1989- IF VIND-AGEDEB LESS ZEROS */

            if (VIND_AGEDEB < 00)
            {

                /*" -1992- MOVE ZEROS TO R3-AGECTADEB OF REG-PROPOSTA-SASSE DISC-AGE-CTA-DEBITO */
                _.Move(0, LXFCT004.REG_PROPOSTA_SASSE.R3_CONTA_DEBITO.R3_AGECTADEB, WS_REG_DISCADOR.DISC_AGE_CTA_DEBITO);

                /*" -1993- ELSE */
            }
            else
            {


                /*" -1997- MOVE OPPAGVA-COD-AGENCIA-DEBITO TO R3-AGECTADEB OF REG-PROPOSTA-SASSE DISC-AGE-CTA-DEBITO. */
                _.Move(OPPAGVA.DCLOPCAO_PAG_VIDAZUL.OPPAGVA_COD_AGENCIA_DEBITO, LXFCT004.REG_PROPOSTA_SASSE.R3_CONTA_DEBITO.R3_AGECTADEB, WS_REG_DISCADOR.DISC_AGE_CTA_DEBITO);
            }


            /*" -1998- IF VIND-OPRCTADEB LESS ZEROS */

            if (VIND_OPRCTADEB < 00)
            {

                /*" -2001- MOVE ZEROS TO R3-OPRCTADEB OF REG-PROPOSTA-SASSE DISC-OPE-CTA-DEBITO */
                _.Move(0, LXFCT004.REG_PROPOSTA_SASSE.R3_CONTA_DEBITO.R3_OPRCTADEB, WS_REG_DISCADOR.DISC_OPE_CTA_DEBITO);

                /*" -2002- ELSE */
            }
            else
            {


                /*" -2006- MOVE OPPAGVA-OPE-CONTA-DEBITO TO R3-OPRCTADEB OF REG-PROPOSTA-SASSE DISC-OPE-CTA-DEBITO. */
                _.Move(OPPAGVA.DCLOPCAO_PAG_VIDAZUL.OPPAGVA_OPE_CONTA_DEBITO, LXFCT004.REG_PROPOSTA_SASSE.R3_CONTA_DEBITO.R3_OPRCTADEB, WS_REG_DISCADOR.DISC_OPE_CTA_DEBITO);
            }


            /*" -2007- IF VIND-NUMCTADEB LESS ZEROS */

            if (VIND_NUMCTADEB < 00)
            {

                /*" -2010- MOVE ZEROS TO R3-NUMCTADEB OF REG-PROPOSTA-SASSE DISC-NUM-CTA-DEBITO */
                _.Move(0, LXFCT004.REG_PROPOSTA_SASSE.R3_CONTA_DEBITO.R3_NUMCTADEB, WS_REG_DISCADOR.DISC_NUM_CTA_DEBITO);

                /*" -2011- ELSE */
            }
            else
            {


                /*" -2015- MOVE OPPAGVA-NUM-CONTA-DEBITO TO R3-NUMCTADEB OF REG-PROPOSTA-SASSE DISC-NUM-CTA-DEBITO. */
                _.Move(OPPAGVA.DCLOPCAO_PAG_VIDAZUL.OPPAGVA_NUM_CONTA_DEBITO, LXFCT004.REG_PROPOSTA_SASSE.R3_CONTA_DEBITO.R3_NUMCTADEB, WS_REG_DISCADOR.DISC_NUM_CTA_DEBITO);
            }


            /*" -2016- IF VIND-DIGCTADEB LESS ZEROS */

            if (VIND_DIGCTADEB < 00)
            {

                /*" -2019- MOVE ZEROS TO R3-DIGCTADEB OF REG-PROPOSTA-SASSE DISC-DIG-CTA-DEBITO */
                _.Move(0, LXFCT004.REG_PROPOSTA_SASSE.R3_CONTA_DEBITO.R3_DIGCTADEB, WS_REG_DISCADOR.DISC_DIG_CTA_DEBITO);

                /*" -2020- ELSE */
            }
            else
            {


                /*" -2024- MOVE OPPAGVA-DIG-CONTA-DEBITO TO R3-DIGCTADEB OF REG-PROPOSTA-SASSE DISC-DIG-CTA-DEBITO. */
                _.Move(OPPAGVA.DCLOPCAO_PAG_VIDAZUL.OPPAGVA_DIG_CONTA_DEBITO, LXFCT004.REG_PROPOSTA_SASSE.R3_CONTA_DEBITO.R3_DIGCTADEB, WS_REG_DISCADOR.DISC_DIG_CTA_DEBITO);
            }


            /*" -2025- IF VIND-DPS-TITULAR LESS ZEROS */

            if (VIND_DPS_TITULAR < 00)
            {

                /*" -2027- MOVE SPACES TO R3-DPS-TITULAR OF REG-PROPOSTA-SASSE */
                _.Move("", LXFCT004.REG_PROPOSTA_SASSE.R3_DPS_TITULAR);

                /*" -2028- ELSE */
            }
            else
            {


                /*" -2031- MOVE DPS-TITULAR OF DCLPROPOSTAS-VA TO R3-DPS-TITULAR OF REG-PROPOSTA-SASSE. */
                _.Move(PROPVA.DCLPROPOSTAS_VA.DPS_TITULAR, LXFCT004.REG_PROPOSTA_SASSE.R3_DPS_TITULAR);
            }


            /*" -2032- IF VIND-DPS-ESPOSA LESS ZEROS */

            if (VIND_DPS_ESPOSA < 00)
            {

                /*" -2034- MOVE SPACES TO R3-DPS-CONJUGE OF REG-PROPOSTA-SASSE */
                _.Move("", LXFCT004.REG_PROPOSTA_SASSE.R3_DPS_CONJUGE);

                /*" -2035- ELSE */
            }
            else
            {


                /*" -2043- MOVE DPS-ESPOSA OF DCLPROPOSTAS-VA TO R3-DPS-CONJUGE OF REG-PROPOSTA-SASSE. */
                _.Move(PROPVA.DCLPROPOSTAS_VA.DPS_ESPOSA, LXFCT004.REG_PROPOSTA_SASSE.R3_DPS_CONJUGE);
            }


            /*" -2046- MOVE NUM-MATRI-VENDEDOR OF DCLPROPOSTAS-VA TO R3-NRMATRVEN OF REG-PROPOSTA-SASSE */
            _.Move(PROPVA.DCLPROPOSTAS_VA.NUM_MATRI_VENDEDOR, LXFCT004.REG_PROPOSTA_SASSE.R3_NRMATRVEN);

            /*" -2047- IF VIND-APOS-INVALIDEZ LESS 0 */

            if (VIND_APOS_INVALIDEZ < 0)
            {

                /*" -2049- MOVE SPACES TO R3-APOS-INVALIDEZ OF REG-PROPOSTA-SASSE */
                _.Move("", LXFCT004.REG_PROPOSTA_SASSE.R3_APOS_INVALIDEZ);

                /*" -2050- ELSE */
            }
            else
            {


                /*" -2053- MOVE APOS-INVALIDEZ OF DCLPROPOSTAS-VA TO R3-APOS-INVALIDEZ OF REG-PROPOSTA-SASSE. */
                _.Move(PROPVA.DCLPROPOSTAS_VA.APOS_INVALIDEZ, LXFCT004.REG_PROPOSTA_SASSE.R3_APOS_INVALIDEZ);
            }


            /*" -2056- MOVE SPACES TO R3-RENOVACAO-AUTOM OF REG-PROPOSTA-SASSE */
            _.Move("", LXFCT004.REG_PROPOSTA_SASSE.R3_RENOVACAO_AUTOM);

            /*" -2059- MOVE OPPAGVA-DIA-DEBITO TO R3-DIA-DEBITO OF REG-PROPOSTA-SASSE */
            _.Move(OPPAGVA.DCLOPCAO_PAG_VIDAZUL.OPPAGVA_DIA_DEBITO, LXFCT004.REG_PROPOSTA_SASSE.R3_DIA_DEBITO);

            /*" -2062- MOVE PERC-DESCONTO OF DCLPROPOSTA-FIDELIZ TO R3-PCT-DESCONTO OF REG-PROPOSTA-SASSE */
            _.Move(PROPFID.DCLPROPOSTA_FIDELIZ.PERC_DESCONTO, LXFCT004.REG_PROPOSTA_SASSE.R3_PCT_DESCONTO);

            /*" -2065- MOVE CGC-CONVENENTE OF DCLPROPOSTA-FIDELIZ TO R3-CGC-CONVENENTE OF REG-PROPOSTA-SASSE */
            _.Move(PROPFID.DCLPROPOSTA_FIDELIZ.CGC_CONVENENTE, LXFCT004.REG_PROPOSTA_SASSE.R3_CGC_CONVENENTE);

            /*" -2068- MOVE NOME-CONVENENTE OF DCLPROPOSTA-FIDELIZ TO R3-NOME-CONVENENTE OF REG-PROPOSTA-SASSE */
            _.Move(PROPFID.DCLPROPOSTA_FIDELIZ.NOME_CONVENENTE, LXFCT004.REG_PROPOSTA_SASSE.R3_NOME_CONVENENTE);

            /*" -2074- MOVE ORIGEM-PROPOSTA OF DCLPROPOSTA-FIDELIZ TO R3-ORIGEM-PROPOSTA OF REG-PROPOSTA-SASSE. */
            _.Move(PROPFID.DCLPROPOSTA_FIDELIZ.ORIGEM_PROPOSTA, LXFCT004.REG_PROPOSTA_SASSE.R3_ORIGEM_PROPOSTA_AIC);

            /*" -2077- MOVE 'EMT' TO R3-SIT-PROPOSTA OF REG-PROPOSTA-SASSE. */
            _.Move("EMT", LXFCT004.REG_PROPOSTA_SASSE.R3_SIT_PROPOSTA);

            /*" -2080- MOVE 'PAG' TO R3-SIT-COBRANCA OF REG-PROPOSTA-SASSE. */
            _.Move("PAG", LXFCT004.REG_PROPOSTA_SASSE.R3_SIT_COBRANCA);

            /*" -2083- MOVE 228 TO R3-SIT-MOTIVO OF REG-PROPOSTA-SASSE. */
            _.Move(228, LXFCT004.REG_PROPOSTA_SASSE.R3_SIT_MOTIVO);

            /*" -2086- MOVE OPCAO-COBERTURA OF DCLPROPOSTAS-VA TO R3-OPCAO-COBER OF REG-PROPOSTA-SASSE. */
            _.Move(PROPVA.DCLPROPOSTAS_VA.OPCAO_COBERTURA, LXFCT004.REG_PROPOSTA_SASSE.R3_OPCAO_COBER);

            /*" -2089- MOVE COD-PLANO OF DCLPROPOSTA-FIDELIZ TO R3-COD-PLANO OF REG-PROPOSTA-SASSE. */
            _.Move(PROPFID.DCLPROPOSTA_FIDELIZ.COD_PLANO, LXFCT004.REG_PROPOSTA_SASSE.R3_COD_PLANO);

            /*" -2092- MOVE DATA-QUITACAO OF DCLPROPOSTAS-VA TO W-DATA-SQL */
            _.Move(PROPVA.DCLPROPOSTAS_VA.DATA_QUITACAO, WAREA_AUXILIAR.W_DATA_SQL);

            /*" -2093- MOVE W-DIA-SQL TO W-DIA-TRABALHO */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_DIA_SQL, WAREA_AUXILIAR.FILLER_29.W_DIA_TRABALHO);

            /*" -2094- MOVE W-MES-SQL TO W-MES-TRABALHO */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_MES_SQL, WAREA_AUXILIAR.FILLER_29.W_MES_TRABALHO);

            /*" -2095- MOVE W-ANO-SQL TO W-ANO-TRABALHO */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_ANO_SQL, WAREA_AUXILIAR.FILLER_29.W_ANO_TRABALHO);

            /*" -2098- MOVE W-DATA-TRABALHO TO R3-DTQITBCO OF REG-PROPOSTA-SASSE. */
            _.Move(WAREA_AUXILIAR.W_DATA_TRABALHO, LXFCT004.REG_PROPOSTA_SASSE.R3_DTQITBCO);

            /*" -2102- MOVE HISCOBPR-VLPREMIO TO R3-VAL-PAGO OF REG-PROPOSTA-SASSE DISC-VAL-PREMIO */
            _.Move(HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_VLPREMIO, LXFCT004.REG_PROPOSTA_SASSE.R3_VAL_PAGO, WS_REG_DISCADOR.DISC_VAL_PREMIO);

            /*" -2106- MOVE HISCOBPR-IMP-MORNATU TO R3-VALOR-PREMIO-TOTAL OF REG-PROPOSTA-SASSE DISC-VAL-CAPITAL */
            _.Move(HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMP_MORNATU, LXFCT004.REG_PROPOSTA_SASSE.R3_VALOR_PREMIO_TOTAL, WS_REG_DISCADOR.DISC_VAL_CAPITAL);

            /*" -2109- MOVE AGE-COBRANCA OF DCLPROPOSTAS-VA TO R3-AGEPGTO OF REG-PROPOSTA-SASSE. */
            _.Move(PROPVA.DCLPROPOSTAS_VA.AGE_COBRANCA, LXFCT004.REG_PROPOSTA_SASSE.R3_AGEPGTO);

            /*" -2112- MOVE VAL-TARIFA OF DCLTARIFA-BALCAO-CEF TO R3-VAL-TARIFA OF REG-PROPOSTA-SASSE. */
            _.Move(TARIBCEF.DCLTARIFA_BALCAO_CEF.VAL_TARIFA, LXFCT004.REG_PROPOSTA_SASSE.R3_VAL_TARIFA);

            /*" -2114- MOVE DATA-QUITACAO OF DCLPROPOSTAS-VA TO W-DATA-SQL */
            _.Move(PROPVA.DCLPROPOSTAS_VA.DATA_QUITACAO, WAREA_AUXILIAR.W_DATA_SQL);

            /*" -2115- MOVE W-DIA-SQL TO W-DIA-TRABALHO */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_DIA_SQL, WAREA_AUXILIAR.FILLER_29.W_DIA_TRABALHO);

            /*" -2116- MOVE W-MES-SQL TO W-MES-TRABALHO */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_MES_SQL, WAREA_AUXILIAR.FILLER_29.W_MES_TRABALHO);

            /*" -2117- MOVE W-ANO-SQL TO W-ANO-TRABALHO */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_ANO_SQL, WAREA_AUXILIAR.FILLER_29.W_ANO_TRABALHO);

            /*" -2120- MOVE W-DATA-TRABALHO TO R3-DATA-CREDITO OF REG-PROPOSTA-SASSE. */
            _.Move(WAREA_AUXILIAR.W_DATA_TRABALHO, LXFCT004.REG_PROPOSTA_SASSE.R3_DATA_CREDITO);

            /*" -2123- MOVE ZEROS TO R3-VAL-COMISSAO OF REG-PROPOSTA-SASSE */
            _.Move(0, LXFCT004.REG_PROPOSTA_SASSE.R3_VAL_COMISSAO);

            /*" -2126- MOVE ARQSIVPF-NSAS-SIVPF OF DCLARQUIVOS-SIVPF TO R3-NSAS OF REG-PROPOSTA-SASSE. */
            _.Move(ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF, LXFCT004.REG_PROPOSTA_SASSE.R3_NSAS);

            /*" -2127- IF SUBGVGAP-OPCAO-CONJUGE EQUAL '3' */

            if (SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_OPCAO_CONJUGE == "3")
            {

                /*" -2128- MOVE 'N' TO R3-OPCAO-CONJUGE */
                _.Move("N", LXFCT004.REG_PROPOSTA_SASSE.R3_OPCAO_CONJUGE);

                /*" -2129- ELSE */
            }
            else
            {


                /*" -2130- MOVE 'S' TO R3-OPCAO-CONJUGE */
                _.Move("S", LXFCT004.REG_PROPOSTA_SASSE.R3_OPCAO_CONJUGE);

                /*" -2132- END-IF. */
            }


            /*" -2134- ADD 1 TO W-QTD-LD-TIPO-3. */
            WAREA_AUXILIAR.W_QTD_LD_TIPO_3.Value = WAREA_AUXILIAR.W_QTD_LD_TIPO_3 + 1;

            /*" -2137- MOVE W-QTD-LD-TIPO-3 TO R3-NSL OF REG-PROPOSTA-SASSE. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_3, LXFCT004.REG_PROPOSTA_SASSE.R3_NSL);

            /*" -2138- WRITE REG-PRP-SASSE FROM REG-PROPOSTA-SASSE. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.GetMoveValues(), REG_PRP_SASSE);

            MOVTO_PRP_SASSE.Write(REG_PRP_SASSE.GetMoveValues().ToString());

            /*" -2138- WRITE REG-PRP-DISC FROM WS-REG-DISCADOR. */
            _.Move(WS_REG_DISCADOR.GetMoveValues(), REG_PRP_DISC);

            MOVTO_PRP_DISC.Write(REG_PRP_DISC.GetMoveValues().ToString());

        }

        [StopWatch]
        /*" R1000-00-GERAR-TRAILLER-SECTION */
        private void R1000_00_GERAR_TRAILLER_SECTION()
        {
            /*" -2150- MOVE 'R1000-00-GERAR-TRAILLER' TO PARAGRAFO. */
            _.Move("R1000-00-GERAR-TRAILLER", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2152- MOVE 'WRITE REG-TRAILLER' TO COMANDO. */
            _.Move("WRITE REG-TRAILLER", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2155- MOVE SPACES TO REG-TRAILLER, REG-PRP-SASSE */
            _.Move("", LBFPF991.REG_TRAILLER, REG_PRP_SASSE);

            /*" -2158- MOVE 'T' TO RT-TIPO-REG OF REG-TRAILLER. */
            _.Move("T", LBFPF991.REG_TRAILLER.RT_TIPO_REG);

            /*" -2161- MOVE 'PRPPAR' TO RT-NOME-EMPRESA OF REG-TRAILLER. */
            _.Move("PRPPAR", LBFPF991.REG_TRAILLER.RT_NOME_EMPRESA);

            /*" -2164- MOVE W-QTD-LD-TIPO-0 TO RT-QTDE-TIPO-0 OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_0, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_0);

            /*" -2167- MOVE W-QTD-LD-TIPO-1 TO RT-QTDE-TIPO-1 OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_1, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_1);

            /*" -2170- MOVE W-QTD-LD-TIPO-2 TO RT-QTDE-TIPO-2 OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_2, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_2);

            /*" -2173- MOVE W-QTD-LD-TIPO-3 TO RT-QTDE-TIPO-3 OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_3, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_3);

            /*" -2176- MOVE W-QTD-LD-TIPO-4 TO RT-QTDE-TIPO-4 OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_4, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_4);

            /*" -2179- MOVE W-QTD-LD-TIPO-5 TO RT-QTDE-TIPO-5 OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_5, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_5);

            /*" -2182- MOVE W-QTD-LD-TIPO-6 TO RT-QTDE-TIPO-6 OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_6, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_6);

            /*" -2185- MOVE W-QTD-LD-TIPO-7 TO RT-QTDE-TIPO-7 OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_7, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_7);

            /*" -2188- MOVE W-QTD-LD-TIPO-8 TO RT-QTDE-TIPO-8 OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_8, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_8);

            /*" -2191- MOVE W-QTD-LD-TIPO-9 TO RT-QTDE-TIPO-9 OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_9, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_9);

            /*" -2194- MOVE W-QTD-LD-TIPO-A TO RT-QTDE-TIPO-A OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_A, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_A);

            /*" -2197- MOVE W-QTD-LD-TIPO-B TO RT-QTDE-TIPO-B OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_B, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_B);

            /*" -2200- MOVE W-QTD-LD-TIPO-C TO RT-QTDE-TIPO-C OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_C, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_C);

            /*" -2203- MOVE W-QTD-LD-TIPO-D TO RT-QTDE-TIPO-D OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_D, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_D);

            /*" -2206- MOVE W-QTD-LD-TIPO-E TO RT-QTDE-TIPO-E OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_E, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_E);

            /*" -2209- MOVE W-QTD-LD-TIPO-F TO RT-QTDE-TIPO-F OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_F, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_F);

            /*" -2212- MOVE W-QTD-LD-TIPO-G TO RT-QTDE-TIPO-G OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_G, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_G);

            /*" -2215- MOVE W-QTD-LD-TIPO-H TO RT-QTDE-TIPO-H OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_H, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_H);

            /*" -2218- MOVE W-QTD-LD-TIPO-I TO RT-QTDE-TIPO-I OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_I, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_I);

            /*" -2221- MOVE W-QTD-LD-TIPO-J TO RT-QTDE-TIPO-J OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_J, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_J);

            /*" -2243- COMPUTE RT-QTDE-TOTAL OF REG-TRAILLER = RT-QTDE-TIPO-0 + RT-QTDE-TIPO-1 + RT-QTDE-TIPO-2 + RT-QTDE-TIPO-3 + RT-QTDE-TIPO-4 + RT-QTDE-TIPO-5 + RT-QTDE-TIPO-6 + RT-QTDE-TIPO-7 + RT-QTDE-TIPO-8 + RT-QTDE-TIPO-9 + RT-QTDE-TIPO-A + RT-QTDE-TIPO-B + RT-QTDE-TIPO-C + RT-QTDE-TIPO-D + RT-QTDE-TIPO-E + RT-QTDE-TIPO-F + RT-QTDE-TIPO-G + RT-QTDE-TIPO-H + RT-QTDE-TIPO-I + RT-QTDE-TIPO-J */
            LBFPF991.REG_TRAILLER.RT_QTDE_TOTAL.Value = LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_0 + LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_1 + LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_2 + LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_3 + LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_4 + LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_5 + LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_6 + LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_7 + LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_8 + LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_9 + LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_A + LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_B + LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_C + LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_D + LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_E + LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_F + LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_G + LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_H + LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_I + LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_J;

            /*" -2243- WRITE REG-PRP-SASSE FROM REG-TRAILLER. */
            _.Move(LBFPF991.REG_TRAILLER.GetMoveValues(), REG_PRP_SASSE);

            MOVTO_PRP_SASSE.Write(REG_PRP_SASSE.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_SAIDA*/

        [StopWatch]
        /*" R1050-00-CONTROLAR-ARQ-ENVIADO-SECTION */
        private void R1050_00_CONTROLAR_ARQ_ENVIADO_SECTION()
        {
            /*" -2256- MOVE 'R1050-00-CONTROLAR-ARQ-ENVIADO' TO PARAGRAFO. */
            _.Move("R1050-00-CONTROLAR-ARQ-ENVIADO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2258- MOVE 'INSERT ARQUIVOS-SIVPF' TO COMANDO. */
            _.Move("INSERT ARQUIVOS-SIVPF", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2261- MOVE 'PRPPAR' TO ARQSIVPF-SIGLA-ARQUIVO OF DCLARQUIVOS-SIVPF. */
            _.Move("PRPPAR", ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SIGLA_ARQUIVO);

            /*" -2264- MOVE 4 TO ARQSIVPF-SISTEMA-ORIGEM OF DCLARQUIVOS-SIVPF. */
            _.Move(4, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SISTEMA_ORIGEM);

            /*" -2268- MOVE SISTEMAS-DATA-MOV-ABERTO OF DCLSISTEMAS TO ARQSIVPF-DATA-GERACAO OF DCLARQUIVOS-SIVPF, ARQSIVPF-DATA-PROCESSAMENTO OF DCLARQUIVOS-SIVPF. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_GERACAO, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_PROCESSAMENTO);

            /*" -2271- MOVE RT-QTDE-TIPO-3 OF REG-TRAILLER TO ARQSIVPF-QTDE-REG-GER OF DCLARQUIVOS-SIVPF. */
            _.Move(LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_3, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_QTDE_REG_GER);

            /*" -2279- PERFORM R1050_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1 */

            R1050_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1();

            /*" -2282- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -2283- DISPLAY 'VA4648B - FIM ANORMAL' */
                _.Display($"VA4648B - FIM ANORMAL");

                /*" -2284- DISPLAY '          ERRO INSERT TABELA ARQUIVOS-SIVPF' */
                _.Display($"          ERRO INSERT TABELA ARQUIVOS-SIVPF");

                /*" -2286- DISPLAY '          SIGLA DO ARQIVO..................  ' ARQSIVPF-SIGLA-ARQUIVO OF DCLARQUIVOS-SIVPF */
                _.Display($"          SIGLA DO ARQIVO..................  {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SIGLA_ARQUIVO}");

                /*" -2288- DISPLAY '          NSAS SIVPF.......................  ' ARQSIVPF-NSAS-SIVPF OF DCLARQUIVOS-SIVPF */
                _.Display($"          NSAS SIVPF.......................  {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF}");

                /*" -2290- DISPLAY '          DATA GERACAO.....................  ' ARQSIVPF-DATA-GERACAO OF DCLARQUIVOS-SIVPF */
                _.Display($"          DATA GERACAO.....................  {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_GERACAO}");

                /*" -2292- DISPLAY '          QTDE. REGISTROS..................  ' ARQSIVPF-QTDE-REG-GER OF DCLARQUIVOS-SIVPF */
                _.Display($"          QTDE. REGISTROS..................  {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_QTDE_REG_GER}");

                /*" -2294- DISPLAY '          SQLCODE..........................  ' SQLCODE */
                _.Display($"          SQLCODE..........................  {DB.SQLCODE}");

                /*" -2295- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -2295- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R1050-00-CONTROLAR-ARQ-ENVIADO-DB-INSERT-1 */
        public void R1050_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1()
        {
            /*" -2279- EXEC SQL INSERT INTO SEGUROS.ARQUIVOS_SIVPF VALUES (:DCLARQUIVOS-SIVPF.ARQSIVPF-SIGLA-ARQUIVO, :DCLARQUIVOS-SIVPF.ARQSIVPF-SISTEMA-ORIGEM, :DCLARQUIVOS-SIVPF.ARQSIVPF-NSAS-SIVPF, :DCLARQUIVOS-SIVPF.ARQSIVPF-DATA-GERACAO, :DCLARQUIVOS-SIVPF.ARQSIVPF-QTDE-REG-GER, :DCLARQUIVOS-SIVPF.ARQSIVPF-DATA-PROCESSAMENTO) END-EXEC. */

            var r1050_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1_Insert1 = new R1050_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1_Insert1()
            {
                ARQSIVPF_SIGLA_ARQUIVO = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SIGLA_ARQUIVO.ToString(),
                ARQSIVPF_SISTEMA_ORIGEM = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SISTEMA_ORIGEM.ToString(),
                ARQSIVPF_NSAS_SIVPF = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF.ToString(),
                ARQSIVPF_DATA_GERACAO = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_GERACAO.ToString(),
                ARQSIVPF_QTDE_REG_GER = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_QTDE_REG_GER.ToString(),
                ARQSIVPF_DATA_PROCESSAMENTO = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_PROCESSAMENTO.ToString(),
            };

            R1050_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1_Insert1.Execute(r1050_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1050_SAIDA*/

        [StopWatch]
        /*" R1100-00-GERAR-TOTAIS-SECTION */
        private void R1100_00_GERAR_TOTAIS_SECTION()
        {
            /*" -2306- MOVE 'R1100-00-GERAR-TOTIAS' TO PARAGRAFO. */
            _.Move("R1100-00-GERAR-TOTIAS", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2308- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2328- COMPUTE W-TOT-GERADO-PRP = W-QTD-LD-TIPO-1 + W-QTD-LD-TIPO-2 + W-QTD-LD-TIPO-3 + W-QTD-LD-TIPO-4 + W-QTD-LD-TIPO-5 + W-QTD-LD-TIPO-6 + W-QTD-LD-TIPO-7 + W-QTD-LD-TIPO-8 + W-QTD-LD-TIPO-9 + W-QTD-LD-TIPO-A + W-QTD-LD-TIPO-B + W-QTD-LD-TIPO-C + W-QTD-LD-TIPO-D + W-QTD-LD-TIPO-E + W-QTD-LD-TIPO-F + W-QTD-LD-TIPO-G + W-QTD-LD-TIPO-H + W-QTD-LD-TIPO-I + W-QTD-LD-TIPO-J. */
            WAREA_AUXILIAR.W_TOT_GERADO_PRP.Value = WAREA_AUXILIAR.W_QTD_LD_TIPO_1 + WAREA_AUXILIAR.W_QTD_LD_TIPO_2 + WAREA_AUXILIAR.W_QTD_LD_TIPO_3 + WAREA_AUXILIAR.W_QTD_LD_TIPO_4 + WAREA_AUXILIAR.W_QTD_LD_TIPO_5 + WAREA_AUXILIAR.W_QTD_LD_TIPO_6 + WAREA_AUXILIAR.W_QTD_LD_TIPO_7 + WAREA_AUXILIAR.W_QTD_LD_TIPO_8 + WAREA_AUXILIAR.W_QTD_LD_TIPO_9 + WAREA_AUXILIAR.W_QTD_LD_TIPO_A + WAREA_AUXILIAR.W_QTD_LD_TIPO_B + WAREA_AUXILIAR.W_QTD_LD_TIPO_C + WAREA_AUXILIAR.W_QTD_LD_TIPO_D + WAREA_AUXILIAR.W_QTD_LD_TIPO_E + WAREA_AUXILIAR.W_QTD_LD_TIPO_F + WAREA_AUXILIAR.W_QTD_LD_TIPO_G + WAREA_AUXILIAR.W_QTD_LD_TIPO_H + WAREA_AUXILIAR.W_QTD_LD_TIPO_I + WAREA_AUXILIAR.W_QTD_LD_TIPO_J;

            /*" -2329- DISPLAY 'VA4648B - TOTAIS DO PROCESSAMENTO' */
            _.Display($"VA4648B - TOTAIS DO PROCESSAMENTO");

            /*" -2330- DISPLAY '          TOTAL  REGISTROS LIDOS........... ' W-NSL */
            _.Display($"          TOTAL  REGISTROS LIDOS........... {WAREA_AUXILIAR.W_NSL}");

            /*" -2332- DISPLAY '          TOTAL  PROCESSADO................ ' W-QTD-LD-TIPO-1 */
            _.Display($"          TOTAL  PROCESSADO................ {WAREA_AUXILIAR.W_QTD_LD_TIPO_1}");

            /*" -2334- DISPLAY '          TOTAL  NAO PROCESSADO............ ' W-DESPREZADO */
            _.Display($"          TOTAL  NAO PROCESSADO............ {WAREA_AUXILIAR.W_DESPREZADO}");

            /*" -2335- DISPLAY '          TOTAL  REGISTROS GERADOS PRPSASSE' */
            _.Display($"          TOTAL  REGISTROS GERADOS PRPSASSE");

            /*" -2337- DISPLAY '          TOTAL  REGISTROS TP-1............ ' W-QTD-LD-TIPO-1 */
            _.Display($"          TOTAL  REGISTROS TP-1............ {WAREA_AUXILIAR.W_QTD_LD_TIPO_1}");

            /*" -2339- DISPLAY '          TOTAL  REGISTROS TP-2............ ' W-QTD-LD-TIPO-2 */
            _.Display($"          TOTAL  REGISTROS TP-2............ {WAREA_AUXILIAR.W_QTD_LD_TIPO_2}");

            /*" -2341- DISPLAY '          TOTAL  REGISTROS TP-3............ ' W-QTD-LD-TIPO-3 */
            _.Display($"          TOTAL  REGISTROS TP-3............ {WAREA_AUXILIAR.W_QTD_LD_TIPO_3}");

            /*" -2343- DISPLAY '          TOTAL  REGISTROS TP-4............ ' W-QTD-LD-TIPO-4 */
            _.Display($"          TOTAL  REGISTROS TP-4............ {WAREA_AUXILIAR.W_QTD_LD_TIPO_4}");

            /*" -2344- DISPLAY '          TOTAL  GERAL..................... ' W-TOT-GERADO-PRP. */
            _.Display($"          TOTAL  GERAL..................... {WAREA_AUXILIAR.W_TOT_GERADO_PRP}");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_SAIDA*/

        [StopWatch]
        /*" R0740-00-UPDATE-RELATORIOS-SECTION */
        private void R0740_00_UPDATE_RELATORIOS_SECTION()
        {
            /*" -2353- MOVE 'R0740-00-UPDATE-RELATORIOS' TO PARAGRAFO. */
            _.Move("R0740-00-UPDATE-RELATORIOS", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2355- MOVE 'UPDATE RELATORIOS' TO COMANDO. */
            _.Move("UPDATE RELATORIOS", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2365- PERFORM R0740_00_UPDATE_RELATORIOS_DB_UPDATE_1 */

            R0740_00_UPDATE_RELATORIOS_DB_UPDATE_1();

            /*" -2368- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -2369- DISPLAY 'VA4648B - FIM ANORMAL' */
                _.Display($"VA4648B - FIM ANORMAL");

                /*" -2370- DISPLAY '          ERRO UPDATE RELATORIOS' */
                _.Display($"          ERRO UPDATE RELATORIOS");

                /*" -2372- DISPLAY '          SQLCODE........................ ' SQLCODE */
                _.Display($"          SQLCODE........................ {DB.SQLCODE}");

                /*" -2373- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -2373- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R0740-00-UPDATE-RELATORIOS-DB-UPDATE-1 */
        public void R0740_00_UPDATE_RELATORIOS_DB_UPDATE_1()
        {
            /*" -2365- EXEC SQL UPDATE SEGUROS.RELATORIOS SET SIT_REGISTRO = '1' , TIMESTAMP = CURRENT TIMESTAMP WHERE IDE_SISTEMA = 'PF' AND COD_RELATORIO = 'VA4648B' AND NUM_CERTIFICADO = :DCLPROPOSTA-FIDELIZ.NUM-PROPOSTA-SIVPF AND SIT_REGISTRO = '0' END-EXEC. */

            var r0740_00_UPDATE_RELATORIOS_DB_UPDATE_1_Update1 = new R0740_00_UPDATE_RELATORIOS_DB_UPDATE_1_Update1()
            {
                NUM_PROPOSTA_SIVPF = PROPFID.DCLPROPOSTA_FIDELIZ.NUM_PROPOSTA_SIVPF.ToString(),
            };

            R0740_00_UPDATE_RELATORIOS_DB_UPDATE_1_Update1.Execute(r0740_00_UPDATE_RELATORIOS_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0740_SAIDA*/

        [StopWatch]
        /*" R0730-ATUALIZA-FIDELIZACAO-SECTION */
        private void R0730_ATUALIZA_FIDELIZACAO_SECTION()
        {
            /*" -2383- MOVE 'R0730-ATUALIZA-FIDELIZACAO' TO PARAGRAFO. */
            _.Move("R0730-ATUALIZA-FIDELIZACAO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2386- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2389- MOVE R3-DTQITBCO OF REG-PROPOSTA-SASSE TO W-DATA-TRABALHO. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_DTQITBCO, WAREA_AUXILIAR.W_DATA_TRABALHO);

            /*" -2391- MOVE W-DIA-TRABALHO TO W-DIA-SQL OF W-DATA-SQL1. */
            _.Move(WAREA_AUXILIAR.FILLER_29.W_DIA_TRABALHO, WAREA_AUXILIAR.W_DATA_SQL1.W_DIA_SQL);

            /*" -2393- MOVE W-MES-TRABALHO TO W-MES-SQL OF W-DATA-SQL1. */
            _.Move(WAREA_AUXILIAR.FILLER_29.W_MES_TRABALHO, WAREA_AUXILIAR.W_DATA_SQL1.W_MES_SQL);

            /*" -2396- MOVE W-ANO-TRABALHO TO W-ANO-SQL OF W-DATA-SQL1. */
            _.Move(WAREA_AUXILIAR.FILLER_29.W_ANO_TRABALHO, WAREA_AUXILIAR.W_DATA_SQL1.W_ANO_SQL);

            /*" -2400- MOVE '-' TO W-BARRA1 OF W-DATA-SQL1, W-BARRA2 OF W-DATA-SQL1. */
            _.Move("-", WAREA_AUXILIAR.W_DATA_SQL1.W_BARRA1_1);
            _.Move("-", WAREA_AUXILIAR.W_DATA_SQL1.W_BARRA2_1);


            /*" -2403- MOVE W-DATA-SQL TO DTQITBCO OF DCLPROPOSTA-FIDELIZ. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL, PROPFID.DCLPROPOSTA_FIDELIZ.DTQITBCO);

            /*" -2406- MOVE R3-VAL-PAGO OF REG-PROPOSTA-SASSE TO VAL-PAGO OF DCLPROPOSTA-FIDELIZ. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_VAL_PAGO, PROPFID.DCLPROPOSTA_FIDELIZ.VAL_PAGO);

            /*" -2409- MOVE R3-AGEPGTO OF REG-PROPOSTA-SASSE TO AGEPGTO OF DCLPROPOSTA-FIDELIZ. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_AGEPGTO, PROPFID.DCLPROPOSTA_FIDELIZ.AGEPGTO);

            /*" -2412- MOVE R3-VAL-TARIFA OF REG-PROPOSTA-SASSE TO VAL-TARIFA OF DCLPROPOSTA-FIDELIZ. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_VAL_TARIFA, PROPFID.DCLPROPOSTA_FIDELIZ.VAL_TARIFA);

            /*" -2415- MOVE R3-DATA-CREDITO OF REG-PROPOSTA-SASSE TO W-DATA-TRABALHO. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_DATA_CREDITO, WAREA_AUXILIAR.W_DATA_TRABALHO);

            /*" -2417- MOVE W-DIA-TRABALHO TO W-DIA-SQL OF W-DATA-SQL1. */
            _.Move(WAREA_AUXILIAR.FILLER_29.W_DIA_TRABALHO, WAREA_AUXILIAR.W_DATA_SQL1.W_DIA_SQL);

            /*" -2419- MOVE W-MES-TRABALHO TO W-MES-SQL OF W-DATA-SQL1. */
            _.Move(WAREA_AUXILIAR.FILLER_29.W_MES_TRABALHO, WAREA_AUXILIAR.W_DATA_SQL1.W_MES_SQL);

            /*" -2422- MOVE W-ANO-TRABALHO TO W-ANO-SQL OF W-DATA-SQL1. */
            _.Move(WAREA_AUXILIAR.FILLER_29.W_ANO_TRABALHO, WAREA_AUXILIAR.W_DATA_SQL1.W_ANO_SQL);

            /*" -2426- MOVE '-' TO W-BARRA1 OF W-DATA-SQL1, W-BARRA2 OF W-DATA-SQL1. */
            _.Move("-", WAREA_AUXILIAR.W_DATA_SQL1.W_BARRA1_1);
            _.Move("-", WAREA_AUXILIAR.W_DATA_SQL1.W_BARRA2_1);


            /*" -2429- MOVE W-DATA-SQL TO DATA-CREDITO OF DCLPROPOSTA-FIDELIZ. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL, PROPFID.DCLPROPOSTA_FIDELIZ.DATA_CREDITO);

            /*" -2432- MOVE R3-VAL-COMISSAO OF REG-PROPOSTA-SASSE TO VAL-COMISSAO OF DCLPROPOSTA-FIDELIZ. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_VAL_COMISSAO, PROPFID.DCLPROPOSTA_FIDELIZ.VAL_COMISSAO);

            /*" -2435- MOVE 'VA4648B' TO COD-USUARIO OF DCLPROPOSTA-FIDELIZ. */
            _.Move("VA4648B", PROPFID.DCLPROPOSTA_FIDELIZ.COD_USUARIO);

            /*" -2438- MOVE ZEROS TO NSAS-SIVPF OF DCLPROPOSTA-FIDELIZ. */
            _.Move(0, PROPFID.DCLPROPOSTA_FIDELIZ.NSAS_SIVPF);

            /*" -2441- MOVE RH-NSAS OF REG-HEADER TO NSAC-SIVPF OF DCLPROPOSTA-FIDELIZ. */
            _.Move(LBFPF990.REG_HEADER.RH_NSAS, PROPFID.DCLPROPOSTA_FIDELIZ.NSAC_SIVPF);

            /*" -2445- MOVE W-QTD-LD-TIPO-3 TO NSL OF DCLPROPOSTA-FIDELIZ. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_3, PROPFID.DCLPROPOSTA_FIDELIZ.NSL);

            /*" -2463- PERFORM R0730_ATUALIZA_FIDELIZACAO_DB_UPDATE_1 */

            R0730_ATUALIZA_FIDELIZACAO_DB_UPDATE_1();

            /*" -2466- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -2467- DISPLAY 'VA4648B - FIM ANORMAL' */
                _.Display($"VA4648B - FIM ANORMAL");

                /*" -2468- DISPLAY '          ERRO UPDATE TABELA PROPOSTA FIDELIZ' */
                _.Display($"          ERRO UPDATE TABELA PROPOSTA FIDELIZ");

                /*" -2470- DISPLAY '          NUMERO PROPOSTA...............  ' NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ */
                _.Display($"          NUMERO PROPOSTA...............  {PROPFID.DCLPROPOSTA_FIDELIZ.NUM_PROPOSTA_SIVPF}");

                /*" -2472- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -2473- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -2473- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R0730-ATUALIZA-FIDELIZACAO-DB-UPDATE-1 */
        public void R0730_ATUALIZA_FIDELIZACAO_DB_UPDATE_1()
        {
            /*" -2463- EXEC SQL UPDATE SEGUROS.PROPOSTA_FIDELIZ SET DTQITBCO =:DCLPROPOSTA-FIDELIZ.DTQITBCO, VAL_PAGO =:DCLPROPOSTA-FIDELIZ.VAL-PAGO, AGEPGTO =:DCLPROPOSTA-FIDELIZ.AGEPGTO, VAL_TARIFA =:DCLPROPOSTA-FIDELIZ.VAL-TARIFA, DATA_CREDITO =:DCLPROPOSTA-FIDELIZ.DATA-CREDITO, VAL_COMISSAO =:DCLPROPOSTA-FIDELIZ.VAL-COMISSAO, COD_USUARIO =:DCLPROPOSTA-FIDELIZ.COD-USUARIO, NSAS_SIVPF =:DCLPROPOSTA-FIDELIZ.NSAS-SIVPF, NSAC_SIVPF =:DCLPROPOSTA-FIDELIZ.NSAC-SIVPF, NSL =:DCLPROPOSTA-FIDELIZ.NSL WHERE NUM_PROPOSTA_SIVPF = :DCLPROPOSTA-FIDELIZ.NUM-PROPOSTA-SIVPF END-EXEC. */

            var r0730_ATUALIZA_FIDELIZACAO_DB_UPDATE_1_Update1 = new R0730_ATUALIZA_FIDELIZACAO_DB_UPDATE_1_Update1()
            {
                DATA_CREDITO = PROPFID.DCLPROPOSTA_FIDELIZ.DATA_CREDITO.ToString(),
                VAL_COMISSAO = PROPFID.DCLPROPOSTA_FIDELIZ.VAL_COMISSAO.ToString(),
                COD_USUARIO = PROPFID.DCLPROPOSTA_FIDELIZ.COD_USUARIO.ToString(),
                VAL_TARIFA = PROPFID.DCLPROPOSTA_FIDELIZ.VAL_TARIFA.ToString(),
                NSAS_SIVPF = PROPFID.DCLPROPOSTA_FIDELIZ.NSAS_SIVPF.ToString(),
                NSAC_SIVPF = PROPFID.DCLPROPOSTA_FIDELIZ.NSAC_SIVPF.ToString(),
                DTQITBCO = PROPFID.DCLPROPOSTA_FIDELIZ.DTQITBCO.ToString(),
                VAL_PAGO = PROPFID.DCLPROPOSTA_FIDELIZ.VAL_PAGO.ToString(),
                AGEPGTO = PROPFID.DCLPROPOSTA_FIDELIZ.AGEPGTO.ToString(),
                NSL = PROPFID.DCLPROPOSTA_FIDELIZ.NSL.ToString(),
                NUM_PROPOSTA_SIVPF = PROPFID.DCLPROPOSTA_FIDELIZ.NUM_PROPOSTA_SIVPF.ToString(),
            };

            R0730_ATUALIZA_FIDELIZACAO_DB_UPDATE_1_Update1.Execute(r0730_ATUALIZA_FIDELIZACAO_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0730_SAIDA*/

        [StopWatch]
        /*" R9988-00-FECHAR-ARQUIVOS-SECTION */
        private void R9988_00_FECHAR_ARQUIVOS_SECTION()
        {
            /*" -2482- CLOSE MOVTO-PRP-SASSE. */
            MOVTO_PRP_SASSE.Close();

            /*" -2482- CLOSE MOVTO-PRP-DISC. */
            MOVTO_PRP_DISC.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9988_SAIDA*/

        [StopWatch]
        /*" R9999-00-FINALIZAR-SECTION */
        private void R9999_00_FINALIZAR_SECTION()
        {
            /*" -2494- DISPLAY ' ' */
            _.Display($" ");

            /*" -2495- IF W-FIM-PROPOVA = 'FIM' */

            if (WAREA_AUXILIAR.W_FIM_PROPOVA == "FIM")
            {

                /*" -2496- DISPLAY 'VA4648B - FIM NORMAL' */
                _.Display($"VA4648B - FIM NORMAL");

                /*" -2497- MOVE 0 TO RETURN-CODE */
                _.Move(0, RETURN_CODE);

                /*" -2498- MOVE 'COMMIT WORK' TO COMANDO */
                _.Move("COMMIT WORK", WABEND.LOCALIZA_ABEND_2.COMANDO);

                /*" -2498- EXEC SQL COMMIT WORK END-EXEC */

                DatabaseConnection.Instance.CommitTransaction();

                /*" -2500- ELSE */
            }
            else
            {


                /*" -2501- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, WABEND.WSQLCODE);

                /*" -2502- MOVE SQLERRD(1) TO WSQLERRD1 */
                _.Move(DB.SQLERRD[1], WABEND.WSQLERRD1);

                /*" -2503- MOVE SQLERRD(2) TO WSQLERRD2 */
                _.Move(DB.SQLERRD[2], WABEND.WSQLERRD2);

                /*" -2504- DISPLAY WABEND */
                _.Display(WABEND);

                /*" -2505- DISPLAY '*** VA4648B *** ROLLBACK EM ANDAMENTO ...' */
                _.Display($"*** VA4648B *** ROLLBACK EM ANDAMENTO ...");

                /*" -2506- MOVE 'ROLLBACK WORK' TO COMANDO */
                _.Move("ROLLBACK WORK", WABEND.LOCALIZA_ABEND_2.COMANDO);

                /*" -2506- EXEC SQL ROLLBACK WORK END-EXEC */

                DatabaseConnection.Instance.RollbackTransaction();

                /*" -2509- MOVE 09 TO RETURN-CODE. */
                _.Move(09, RETURN_CODE);
            }


            /*" -2509- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9999_SAIDA*/
    }
}