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
using Sias.Sinistro.DB2.SI0851B;

namespace Code
{
    public class SI0851B
    {
        public bool IsCall { get; set; }

        public SI0851B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------                                 */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  SINISTRO                           *      */
        /*"      *   PROGRAMA ...............  SI0851B                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  HEIDER COELHO                      *      */
        /*"      *   PROGRAMADOR ............  HEIDER COELHO                      *      */
        /*"      *   DATA CODIFICACAO .......  MARCO / 1999                       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO ..... GERACAO DO ARQUIVO, PARA O EXCEL, DOS SINISTROS *      */
        /*"      *          COM REINTEGRACAO EM DETERMINADO PERIODO               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * ALTERACAO - RILDO SICO - 17/08/2000 - INCLUSAO DA V0RELATORIOS *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * 07/05/2005 - PRODEXTER                                         *      */
        /*"      * (1) SUBSTITUICAO DA TABELA PARAMETR_OPER_SINI PELA GE_OPERACAO *      */
        /*"      * (2) SUBSTITUICAO DOS CALCULOS DE VALORES ATRAVES DE ACESSO A   *      */
        /*"      *     SINISTRO_HISTORICO PELA CHAMADAS AS SUB-ROTINAS DE CALCULO *      */
        /*"      *----------------------------------------------------------------*      */
        #endregion


        #region VARIABLES

        public FileBasis _ARQMOV { get; set; } = new FileBasis(new PIC("X", "600", "X(600)"));

        public FileBasis ARQMOV
        {
            get
            {
                _.Move(REGISTRO_MOVTO, _ARQMOV); VarBasis.RedefinePassValue(REGISTRO_MOVTO, _ARQMOV, REGISTRO_MOVTO); return _ARQMOV;
            }
        }
        /*"01  REGISTRO-MOVTO.*/
        public SI0851B_REGISTRO_MOVTO REGISTRO_MOVTO { get; set; } = new SI0851B_REGISTRO_MOVTO();
        public class SI0851B_REGISTRO_MOVTO : VarBasis
        {
            /*"    03 REG-MOVTO-RECEBIDO       PIC X(600).*/
            public StringBasis REG_MOVTO_RECEBIDO { get; set; } = new StringBasis(new PIC("X", "600", "X(600)."), @"");
        }

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77  V0SISTEMA-DTMOVABE               PIC  X(10).*/
        public StringBasis V0SISTEMA_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V0REL-IDSISTEM                   PIC  X(02).*/
        public StringBasis V0REL_IDSISTEM { get; set; } = new StringBasis(new PIC("X", "2", "X(02)."), @"");
        /*"77  V0REL-COD-RELAT                  PIC  X(08).*/
        public StringBasis V0REL_COD_RELAT { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
        /*"77  V0REL-PERI-INICIAL               PIC  X(10).*/
        public StringBasis V0REL_PERI_INICIAL { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V0REL-PERI-FINAL                 PIC  X(10).*/
        public StringBasis V0REL_PERI_FINAL { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V0REL-NUM-APOLICE                PIC S9(13) COMP-3 VALUE +0.*/
        public IntBasis V0REL_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"77  V0REL-DATA-SOLICITACAO           PIC  X(10).*/
        public StringBasis V0REL_DATA_SOLICITACAO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V0REL-CODUSU                     PIC  X(08).*/
        public StringBasis V0REL_CODUSU { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
        /*"77  V0HIST-COD-EMPRESA               PIC S9(09) COMP   VALUE +0.*/
        public IntBasis V0HIST_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77  V0HIST-TIPREG                    PIC  X(01).*/
        public StringBasis V0HIST_TIPREG { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"77  V0HIST-NUM-APOL-SINISTRO         PIC S9(13) COMP-3 VALUE +0.*/
        public IntBasis V0HIST_NUM_APOL_SINISTRO { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"77  V0HIST-OCORHIST                  PIC S9(04) COMP   VALUE +0.*/
        public IntBasis V0HIST_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0HIST-OPERACAO                  PIC S9(04) COMP   VALUE +0.*/
        public IntBasis V0HIST_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0HIST-DTMOVTO                   PIC  X(10).*/
        public StringBasis V0HIST_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V0HIST-HORAOPER                  PIC  X(08).*/
        public StringBasis V0HIST_HORAOPER { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
        /*"77  V0HIST-NOMFAV                    PIC  X(40).*/
        public StringBasis V0HIST_NOMFAV { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"77  V0HIST-VAL-OPERACAO              PIC S9(13)V9(2)                                     COMP-3 VALUE +0.*/
        public DoubleBasis V0HIST_VAL_OPERACAO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"77  V0HIST-LIMCRR                    PIC  X(10).*/
        public StringBasis V0HIST_LIMCRR { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V0HIST-TIPFAV                    PIC  X(01).*/
        public StringBasis V0HIST_TIPFAV { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"77  V0HIST-DATNEG                    PIC  X(10).*/
        public StringBasis V0HIST_DATNEG { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V0HIST-FONPAG                    PIC S9(04) COMP   VALUE +0.*/
        public IntBasis V0HIST_FONPAG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0HIST-CODPSVI                   PIC S9(09) COMP   VALUE +0.*/
        public IntBasis V0HIST_CODPSVI { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77  V0HIST-CODSVI                    PIC S9(04) COMP   VALUE +0.*/
        public IntBasis V0HIST_CODSVI { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0HIST-NUMOPG                    PIC S9(09) COMP   VALUE +0.*/
        public IntBasis V0HIST_NUMOPG { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77  V0HIST-NUMREC                    PIC S9(09) COMP   VALUE +0.*/
        public IntBasis V0HIST_NUMREC { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77  V0HIST-MOVPCS                    PIC S9(09) COMP   VALUE +0.*/
        public IntBasis V0HIST_MOVPCS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77  V0HIST-CODUSU                    PIC  X(08).*/
        public StringBasis V0HIST_CODUSU { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
        /*"77  V0HIST-SITCONTB                  PIC  X(01).*/
        public StringBasis V0HIST_SITCONTB { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"77  V0HIST-SITUACAO                  PIC  X(01).*/
        public StringBasis V0HIST_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"77  V0HIST-TIMESTAMP                 PIC  X(26).*/
        public StringBasis V0HIST_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"77  V0MEST-COD-EMPRESA               PIC S9(09) COMP   VALUE +0.*/
        public IntBasis V0MEST_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77  V0MEST-TIPREG                    PIC  X(01).*/
        public StringBasis V0MEST_TIPREG { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"77  V0MEST-FONTE                     PIC S9(04) COMP   VALUE +0.*/
        public IntBasis V0MEST_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0MEST-PROTSINI                  PIC S9(09) COMP   VALUE +0.*/
        public IntBasis V0MEST_PROTSINI { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77  V0MEST-DAC                       PIC  X(01).*/
        public StringBasis V0MEST_DAC { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"77  V0MEST-NUM-APOL-SINISTRO         PIC S9(13) COMP-3 VALUE +0.*/
        public IntBasis V0MEST_NUM_APOL_SINISTRO { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"77  V0MEST-NUM-APOLICE               PIC S9(13) COMP-3 VALUE +0.*/
        public IntBasis V0MEST_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"77  V0MEST-NRENDOS                   PIC S9(09) COMP   VALUE +0.*/
        public IntBasis V0MEST_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77  V0MEST-CODSUBES                  PIC S9(04) COMP   VALUE +0.*/
        public IntBasis V0MEST_CODSUBES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0MEST-NRCERTIF                  PIC S9(15) COMP-3 VALUE +0.*/
        public IntBasis V0MEST_NRCERTIF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"77  V0MEST-DIGCERT                   PIC  X(01).*/
        public StringBasis V0MEST_DIGCERT { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"77  V0MEST-IDTPSEGU                  PIC  X(01).*/
        public StringBasis V0MEST_IDTPSEGU { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"77  V0MEST-NREMBARQ                  PIC S9(09) COMP   VALUE +0.*/
        public IntBasis V0MEST_NREMBARQ { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77  V0MEST-REFEMBQ                   PIC S9(04) COMP   VALUE +0.*/
        public IntBasis V0MEST_REFEMBQ { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0MEST-OCORHIST                  PIC S9(04) COMP   VALUE +0.*/
        public IntBasis V0MEST_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0MEST-CODLIDER                  PIC S9(04) COMP   VALUE +0.*/
        public IntBasis V0MEST_CODLIDER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0MEST-SINLID                    PIC  X(15).*/
        public StringBasis V0MEST_SINLID { get; set; } = new StringBasis(new PIC("X", "15", "X(15)."), @"");
        /*"77  V0MEST-DATCMD                    PIC  X(10).*/
        public StringBasis V0MEST_DATCMD { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V0MEST-DATORR                    PIC  X(10).*/
        public StringBasis V0MEST_DATORR { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V0MEST-DATTEC                    PIC  X(10).*/
        public StringBasis V0MEST_DATTEC { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V0MEST-CODCAU                    PIC S9(04) COMP   VALUE +0.*/
        public IntBasis V0MEST_CODCAU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0MEST-NUMIRB                    PIC S9(11) COMP-3 VALUE +0.*/
        public IntBasis V0MEST_NUMIRB { get; set; } = new IntBasis(new PIC("S9", "11", "S9(11)"));
        /*"77  V0MEST-AVIIRB                    PIC  X(10).*/
        public StringBasis V0MEST_AVIIRB { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V0MEST-COD-MOEDA-SINI            PIC S9(04) COMP   VALUE +0.*/
        public IntBasis V0MEST_COD_MOEDA_SINI { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0MEST-SDOPAGBT                  PIC S9(10)V9(5)                                     COMP-3 VALUE +0.*/
        public DoubleBasis V0MEST_SDOPAGBT { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(5)"), 5);
        /*"77  V0MEST-TOTPAGBT                  PIC S9(10)V9(5)                                     COMP-3 VALUE +0.*/
        public DoubleBasis V0MEST_TOTPAGBT { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(5)"), 5);
        /*"77  V0MEST-SDORCPBT                  PIC S9(10)V9(5)                                     COMP-3 VALUE +0.*/
        public DoubleBasis V0MEST_SDORCPBT { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(5)"), 5);
        /*"77  V0MEST-TOTRCPBT                  PIC S9(10)V9(5)                                     COMP-3 VALUE +0.*/
        public DoubleBasis V0MEST_TOTRCPBT { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(5)"), 5);
        /*"77  V0MEST-SDORSABT                  PIC S9(10)V9(5)                                     COMP-3 VALUE +0.*/
        public DoubleBasis V0MEST_SDORSABT { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(5)"), 5);
        /*"77  V0MEST-TOTRSDBT                  PIC S9(10)V9(5)                                     COMP-3 VALUE +0.*/
        public DoubleBasis V0MEST_TOTRSDBT { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(5)"), 5);
        /*"77  V0MEST-TOTDSABT                  PIC S9(10)V9(5)                                     COMP-3 VALUE +0.*/
        public DoubleBasis V0MEST_TOTDSABT { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(5)"), 5);
        /*"77  V0MEST-TOTHONBT                  PIC S9(10)V9(5)                                     COMP-3 VALUE +0.*/
        public DoubleBasis V0MEST_TOTHONBT { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(5)"), 5);
        /*"77  V0MEST-SDOADTBT                  PIC S9(10)V9(5)                                     COMP-3 VALUE +0.*/
        public DoubleBasis V0MEST_SDOADTBT { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(5)"), 5);
        /*"77  V0MEST-ADTRCPBT                  PIC S9(10)V9(5)                                     COMP-3 VALUE +0.*/
        public DoubleBasis V0MEST_ADTRCPBT { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(5)"), 5);
        /*"77  V0MEST-VALSEGBT                  PIC S9(13)V9(2)                                     COMP-3 VALUE +0.*/
        public DoubleBasis V0MEST_VALSEGBT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"77  V0MEST-PCPARTIC                  PIC S9(04)V9(5)                                     COMP-3 VALUE +0.*/
        public DoubleBasis V0MEST_PCPARTIC { get; set; } = new DoubleBasis(new PIC("S9", "4", "S9(04)V9(5)"), 5);
        /*"77  V0MEST-PCTRES                    PIC S9(04)V9(5)                                     COMP-3 VALUE +0.*/
        public DoubleBasis V0MEST_PCTRES { get; set; } = new DoubleBasis(new PIC("S9", "4", "S9(04)V9(5)"), 5);
        /*"77  V0MEST-APVALD                    PIC S9(09) COMP   VALUE +0.*/
        public IntBasis V0MEST_APVALD { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77  V0MEST-INDSVD                    PIC  X(01).*/
        public StringBasis V0MEST_INDSVD { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"77  V0MEST-PAGITG                    PIC  X(01).*/
        public StringBasis V0MEST_PAGITG { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"77  V0MEST-MOVPCSAT                  PIC S9(09) COMP   VALUE +0.*/
        public IntBasis V0MEST_MOVPCSAT { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77  V0MEST-MOVPCSAN                  PIC S9(09) COMP   VALUE +0.*/
        public IntBasis V0MEST_MOVPCSAN { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77  V0MEST-DTULTMOV                  PIC  X(10).*/
        public StringBasis V0MEST_DTULTMOV { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V0MEST-SITUACAO                  PIC  X(01).*/
        public StringBasis V0MEST_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"77  V0MEST-TIMESTAMP                 PIC  X(26).*/
        public StringBasis V0MEST_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"77  V0MEST-BCO-OP                    PIC S9(04) COMP   VALUE +0.*/
        public IntBasis V0MEST_BCO_OP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0MEST-AGE-OP                    PIC S9(04) COMP   VALUE +0.*/
        public IntBasis V0MEST_AGE_OP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0MEST-TIPO-PAGAMENTO            PIC  X(01).*/
        public StringBasis V0MEST_TIPO_PAGAMENTO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"77  V0MEST-RAMO                      PIC S9(04) COMP   VALUE +0.*/
        public IntBasis V0MEST_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0MEST-NRORDEM                   PIC S9(09) COMP   VALUE +0.*/
        public IntBasis V0MEST_NRORDEM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77  V0MEST-CODPRODU                  PIC S9(04) COMP   VALUE +0.*/
        public IntBasis V0MEST_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0SLOT-COD-LOT-FENAL             PIC S9(09) COMP   VALUE +0.*/
        public IntBasis V0SLOT_COD_LOT_FENAL { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77  V0SLOT-COD-LOT-CEF               PIC S9(13) COMP-3 VALUE +0.*/
        public IntBasis V0SLOT_COD_LOT_CEF { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"77  V0SLOT-NUM-APOL-SINISTRO         PIC S9(13) COMP-3 VALUE +0.*/
        public IntBasis V0SLOT_NUM_APOL_SINISTRO { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"77  V0SLOT-NUM-APOLICE               PIC S9(13) COMP-3 VALUE +0.*/
        public IntBasis V0SLOT_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"77  V0SLOT-COD-CLIENTE               PIC S9(09) COMP   VALUE +0.*/
        public IntBasis V0SLOT_COD_CLIENTE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77  V0SLOT-DTINIVIG                  PIC  X(10).*/
        public StringBasis V0SLOT_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V0CLI-COD-CLIENTE                PIC S9(09) COMP   VALUE +0.*/
        public IntBasis V0CLI_COD_CLIENTE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77  V0CLI-NOME-RAZAO                 PIC  X(40).*/
        public StringBasis V0CLI_NOME_RAZAO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"77  V0END-COD-CLIENTE                PIC S9(09) COMP   VALUE +0.*/
        public IntBasis V0END_COD_CLIENTE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77  V0END-OCORR-ENDERECO             PIC S9(04) COMP   VALUE +0.*/
        public IntBasis V0END_OCORR_ENDERECO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0END-SIGLA-UF                   PIC  X(02).*/
        public StringBasis V0END_SIGLA_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(02)."), @"");
        /*"77  V0ABAT-NUM-APOL-SINISTRO         PIC S9(13) COMP-3 VALUE +0.*/
        public IntBasis V0ABAT_NUM_APOL_SINISTRO { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"77  V0ABAT-COD-RETENCAO              PIC  X(01).*/
        public StringBasis V0ABAT_COD_RETENCAO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"77  V0ABAT-OCORHIST                  PIC S9(04) COMP   VALUE +0.*/
        public IntBasis V0ABAT_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0ABAT-VAL-OPERACAO              PIC S9(13)V9(2)                                     COMP-3 VALUE +0.*/
        public DoubleBasis V0ABAT_VAL_OPERACAO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"77  V0ABAT-DTMOVTO                   PIC  X(10).*/
        public StringBasis V0ABAT_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V0ABAT-HORAOPER                  PIC  X(08).*/
        public StringBasis V0ABAT_HORAOPER { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
        /*"77  V0ABAT-PERCENT-RETENCAO          PIC S9(03)V9(5)                                     COMP-3 VALUE +0.*/
        public DoubleBasis V0ABAT_PERCENT_RETENCAO { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(03)V9(5)"), 5);
        /*"77  V0ABAT-TAXA-IS-FENAL             PIC S9(03)V9(9)                                     COMP-3 VALUE +0.*/
        public DoubleBasis V0ABAT_TAXA_IS_FENAL { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(03)V9(9)"), 9);
        /*"77  V0ABAT-NUM-PARCELA               PIC S9(04) COMP   VALUE +0.*/
        public IntBasis V0ABAT_NUM_PARCELA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0ABAT-TIMESTAMP                 PIC  X(26).*/
        public StringBasis V0ABAT_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"77  HOST-COUNT                       PIC S9(04) COMP   VALUE +0.*/
        public IntBasis HOST_COUNT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  HOST-APOLICE-INICIAL             PIC S9(13) COMP-3 VALUE +0.*/
        public IntBasis HOST_APOLICE_INICIAL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"77  HOST-APOLICE-FINAL               PIC S9(13) COMP-3 VALUE +0.*/
        public IntBasis HOST_APOLICE_FINAL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"01  AREA-DE-WORK.*/
        public SI0851B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new SI0851B_AREA_DE_WORK();
        public class SI0851B_AREA_DE_WORK : VarBasis
        {
            /*"    05 WFIM-LOTERICO              PIC  X(003)       VALUE SPACES*/
            public StringBasis WFIM_LOTERICO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"    05 STATUS-RELATORIO           PIC  X(001)       VALUE SPACES*/

            public SelectorBasis STATUS_RELATORIO { get; set; } = new SelectorBasis("001", "SPACES")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 WFIM-RELATORIO          VALUES 'S'. */
							new SelectorItemBasis("WFIM_RELATORIO", "S")
                }
            };

            /*"    05 W-ENTRADA-LIDOS            PIC  9(05)        VALUE ZEROS.*/
            public IntBasis W_ENTRADA_LIDOS { get; set; } = new IntBasis(new PIC("9", "5", "9(05)"));
            /*"    05 W-ENTRADA-REJEITADOS       PIC  9(05)        VALUE ZEROS.*/
            public IntBasis W_ENTRADA_REJEITADOS { get; set; } = new IntBasis(new PIC("9", "5", "9(05)"));
            /*"    05 W-SINISTROS-GRAVADOS       PIC  9(05)        VALUE ZEROS.*/
            public IntBasis W_SINISTROS_GRAVADOS { get; set; } = new IntBasis(new PIC("9", "5", "9(05)"));
            /*"01  LC00.*/
        }
        public SI0851B_LC00 LC00 { get; set; } = new SI0851B_LC00();
        public class SI0851B_LC00 : VarBasis
        {
            /*"    05 FILLER                     PIC  X(44)        VALUE    '** RELACAO DOS LOTERICOS COM REINTEGRACAO **'.*/
            public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "44", "X(44)"), @"** RELACAO DOS LOTERICOS COM REINTEGRACAO **");
            /*"    05 FILLER                     PIC  X(01)        VALUE ';'.*/
            public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"01  LC01.*/
        }
        public SI0851B_LC01 LC01 { get; set; } = new SI0851B_LC01();
        public class SI0851B_LC01 : VarBasis
        {
            /*"    05 FILLER                     PIC  X(16)        VALUE    'PROCESSADO EM : '.*/
            public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"PROCESSADO EM : ");
            /*"    05 FILLER                     PIC  X(01)        VALUE ';'.*/
            public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05 LC01-DTMOVABE              PIC  X(10)        VALUE SPACES*/
            public StringBasis LC01_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
            /*"    05 FILLER                     PIC  X(01)        VALUE ';'.*/
            public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"01  LC02.*/
        }
        public SI0851B_LC02 LC02 { get; set; } = new SI0851B_LC02();
        public class SI0851B_LC02 : VarBasis
        {
            /*"    05 FILLER                     PIC  X(20)        VALUE    'PERIODO SOLICITADO: '.*/
            public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "20", "X(20)"), @"PERIODO SOLICITADO: ");
            /*"    05 FILLER                     PIC  X(01)        VALUE ';'.*/
            public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05 LC00-PERI-INICIAL          PIC  X(10)        VALUE ' '.*/
            public StringBasis LC00_PERI_INICIAL { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @" ");
            /*"    05 FILLER                     PIC  X(01)        VALUE ';'.*/
            public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05 FILLER                     PIC  X(05)        VALUE    ' ATE '.*/
            public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "5", "X(05)"), @" ATE ");
            /*"    05 FILLER                     PIC  X(01)        VALUE ';'.*/
            public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05 LC00-PERI-FINAL            PIC  X(10)        VALUE ' '.*/
            public StringBasis LC00_PERI_FINAL { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @" ");
            /*"    05 FILLER                     PIC  X(01)        VALUE ';'.*/
            public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05 FILLER                     PIC  X(10)        VALUE       'APOLICE : '.*/
            public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"APOLICE : ");
            /*"    05 FILLER                     PIC  X(01)        VALUE ';'.*/
            public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05 LC00-APOLICE               PIC  X(13)        VALUE SPACES*/
            public StringBasis LC00_APOLICE { get; set; } = new StringBasis(new PIC("X", "13", "X(13)"), @"");
            /*"    05 LC00-APOLICE-R REDEFINES LC00-APOLICE PIC 9(13).*/
            private _REDEF_IntBasis _lc00_apolice_r { get; set; }
            public _REDEF_IntBasis LC00_APOLICE_R
            {
                get { _lc00_apolice_r = new _REDEF_IntBasis(new PIC("9", "13", "9(13).")); ; _.Move(LC00_APOLICE, _lc00_apolice_r); VarBasis.RedefinePassValue(LC00_APOLICE, _lc00_apolice_r, LC00_APOLICE); _lc00_apolice_r.ValueChanged += () => { _.Move(_lc00_apolice_r, LC00_APOLICE); }; return _lc00_apolice_r; }
                set { VarBasis.RedefinePassValue(value, _lc00_apolice_r, LC00_APOLICE); }
            }  //Redefines
            /*"01  LC03.*/
        }
        public SI0851B_LC03 LC03 { get; set; } = new SI0851B_LC03();
        public class SI0851B_LC03 : VarBasis
        {
            /*"    05 FILLER                     PIC  X(13)        VALUE    'APOLICE'.*/
            public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "13", "X(13)"), @"APOLICE");
            /*"    05 FILLER                     PIC  X(01)        VALUE ';'.*/
            public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05 FILLER                     PIC  X(13)        VALUE    'SINISTRO'.*/
            public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "13", "X(13)"), @"SINISTRO");
            /*"    05 FILLER                     PIC  X(01)        VALUE ';'.*/
            public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05 FILLER                     PIC  X(10)        VALUE    'DT. OCORR.'.*/
            public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"DT. OCORR.");
            /*"    05 FILLER                     PIC  X(01)        VALUE ';'.*/
            public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05 FILLER                     PIC  X(10)        VALUE    'DT. COMUN.'.*/
            public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"DT. COMUN.");
            /*"    05 FILLER                     PIC  X(01)        VALUE ';'.*/
            public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05 FILLER                     PIC  X(15)        VALUE    'COD. FENAL'.*/
            public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "15", "X(15)"), @"COD. FENAL");
            /*"    05 FILLER                     PIC  X(01)        VALUE ';'.*/
            public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05 FILLER                     PIC  X(15)        VALUE    'COD. CEF'.*/
            public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "15", "X(15)"), @"COD. CEF");
            /*"    05 FILLER                     PIC  X(01)        VALUE ';'.*/
            public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05 FILLER                     PIC  X(40)        VALUE    'NOME LOTERICO'.*/
            public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"NOME LOTERICO");
            /*"    05 FILLER                     PIC  X(01)        VALUE ';'.*/
            public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05 FILLER                     PIC  X(11)        VALUE    'UF LOTERICO'.*/
            public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "11", "X(11)"), @"UF LOTERICO");
            /*"    05 FILLER                     PIC  X(01)        VALUE ';'.*/
            public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05 FILLER                     PIC  X(10)        VALUE    'DT. CANC.'.*/
            public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"DT. CANC.");
            /*"    05 FILLER                     PIC  X(01)        VALUE ';'.*/
            public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05 FILLER                     PIC  X(20)        VALUE    'VL AVISADO'.*/
            public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "20", "X(20)"), @"VL AVISADO");
            /*"    05 FILLER                     PIC  X(01)        VALUE ';'.*/
            public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05 FILLER                     PIC  X(20)        VALUE    'VL AVI PER'.*/
            public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "20", "X(20)"), @"VL AVI PER");
            /*"    05 FILLER                     PIC  X(01)        VALUE ';'.*/
            public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05 FILLER                     PIC  X(20)        VALUE    'VL APURADO'.*/
            public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "20", "X(20)"), @"VL APURADO");
            /*"    05 FILLER                     PIC  X(01)        VALUE ';'.*/
            public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05 FILLER                     PIC  X(20)        VALUE    'VL APU PER'.*/
            public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "20", "X(20)"), @"VL APU PER");
            /*"    05 FILLER                     PIC  X(01)        VALUE ';'.*/
            public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05 FILLER                     PIC  X(20)        VALUE    'VL FRANQUIA'.*/
            public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "20", "X(20)"), @"VL FRANQUIA");
            /*"    05 FILLER                     PIC  X(01)        VALUE ';'.*/
            public StringBasis FILLER_40 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05 FILLER                     PIC  X(20)        VALUE    'VL FRA PER '.*/
            public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "20", "X(20)"), @"VL FRA PER ");
            /*"    05 FILLER                     PIC  X(01)        VALUE ';'.*/
            public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05 FILLER                     PIC  X(20)        VALUE    'VL REINTEG. MES'.*/
            public StringBasis FILLER_43 { get; set; } = new StringBasis(new PIC("X", "20", "X(20)"), @"VL REINTEG. MES");
            /*"    05 FILLER                     PIC  X(01)        VALUE ';'.*/
            public StringBasis FILLER_44 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05 FILLER                     PIC  X(20)        VALUE    'VL REINTEG. PER'.*/
            public StringBasis FILLER_45 { get; set; } = new StringBasis(new PIC("X", "20", "X(20)"), @"VL REINTEG. PER");
            /*"    05 FILLER                     PIC  X(01)        VALUE ';'.*/
            public StringBasis FILLER_46 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05 FILLER                     PIC  X(20)        VALUE    'VL IOF REINTEG. MES'.*/
            public StringBasis FILLER_47 { get; set; } = new StringBasis(new PIC("X", "20", "X(20)"), @"VL IOF REINTEG. MES");
            /*"    05 FILLER                     PIC  X(01)        VALUE ';'.*/
            public StringBasis FILLER_48 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05 FILLER                     PIC  X(20)        VALUE    'VL IOF REINTEG. PER'.*/
            public StringBasis FILLER_49 { get; set; } = new StringBasis(new PIC("X", "20", "X(20)"), @"VL IOF REINTEG. PER");
            /*"    05 FILLER                     PIC  X(01)        VALUE ';'.*/
            public StringBasis FILLER_50 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05 FILLER                     PIC  X(20)        VALUE    'VL CORRECAO'.*/
            public StringBasis FILLER_51 { get; set; } = new StringBasis(new PIC("X", "20", "X(20)"), @"VL CORRECAO");
            /*"    05 FILLER                     PIC  X(01)        VALUE ';'.*/
            public StringBasis FILLER_52 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05 FILLER                     PIC  X(20)        VALUE    'VL CORRECAO PER'.*/
            public StringBasis FILLER_53 { get; set; } = new StringBasis(new PIC("X", "20", "X(20)"), @"VL CORRECAO PER");
            /*"    05 FILLER                     PIC  X(01)        VALUE ';'.*/
            public StringBasis FILLER_54 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05 FILLER                     PIC  X(20)        VALUE    'VL REINTEG. ANT'.*/
            public StringBasis FILLER_55 { get; set; } = new StringBasis(new PIC("X", "20", "X(20)"), @"VL REINTEG. ANT");
            /*"    05 FILLER                     PIC  X(01)        VALUE ';'.*/
            public StringBasis FILLER_56 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05 FILLER                     PIC  X(20)        VALUE    'VL REINTEG. PER'.*/
            public StringBasis FILLER_57 { get; set; } = new StringBasis(new PIC("X", "20", "X(20)"), @"VL REINTEG. PER");
            /*"    05 FILLER                     PIC  X(01)        VALUE ';'.*/
            public StringBasis FILLER_58 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05 FILLER                     PIC  X(20)        VALUE    'VL IOF REINTEG. ANT'.*/
            public StringBasis FILLER_59 { get; set; } = new StringBasis(new PIC("X", "20", "X(20)"), @"VL IOF REINTEG. ANT");
            /*"    05 FILLER                     PIC  X(01)        VALUE ';'.*/
            public StringBasis FILLER_60 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05 FILLER                     PIC  X(20)        VALUE    'VL IOF REI. ANT PER'.*/
            public StringBasis FILLER_61 { get; set; } = new StringBasis(new PIC("X", "20", "X(20)"), @"VL IOF REI. ANT PER");
            /*"    05 FILLER                     PIC  X(01)        VALUE ';'.*/
            public StringBasis FILLER_62 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05 FILLER                     PIC  X(20)        VALUE    'VL PAGO            '.*/
            public StringBasis FILLER_63 { get; set; } = new StringBasis(new PIC("X", "20", "X(20)"), @"VL PAGO            ");
            /*"    05 FILLER                     PIC  X(01)        VALUE ';'.*/
            public StringBasis FILLER_64 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05 FILLER                     PIC  X(20)        VALUE    'VL PAGO PER        '.*/
            public StringBasis FILLER_65 { get; set; } = new StringBasis(new PIC("X", "20", "X(20)"), @"VL PAGO PER        ");
            /*"    05 FILLER                     PIC  X(01)        VALUE ';'.*/
            public StringBasis FILLER_66 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05 FILLER                     PIC  X(20)        VALUE    'VL PAGO PENDENTE   '.*/
            public StringBasis FILLER_67 { get; set; } = new StringBasis(new PIC("X", "20", "X(20)"), @"VL PAGO PENDENTE   ");
            /*"    05 FILLER                     PIC  X(01)        VALUE ';'.*/
            public StringBasis FILLER_68 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"01  LD01.*/
        }
        public SI0851B_LD01 LD01 { get; set; } = new SI0851B_LD01();
        public class SI0851B_LD01 : VarBasis
        {
            /*"    05 LD01-NUM-APOLICE           PIC  X(13)        VALUE SPACES*/
            public StringBasis LD01_NUM_APOLICE { get; set; } = new StringBasis(new PIC("X", "13", "X(13)"), @"");
            /*"    05 FILLER                     PIC  X(01)        VALUE ';'.*/
            public StringBasis FILLER_69 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05 LD01-NUM-APOL-SINISTRO     PIC  X(13)        VALUE SPACES*/
            public StringBasis LD01_NUM_APOL_SINISTRO { get; set; } = new StringBasis(new PIC("X", "13", "X(13)"), @"");
            /*"    05 FILLER                     PIC  X(01)        VALUE ';'.*/
            public StringBasis FILLER_70 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05 LD01-DATORR                PIC  X(10)        VALUE SPACES*/
            public StringBasis LD01_DATORR { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
            /*"    05 FILLER                     PIC  X(01)        VALUE ';'.*/
            public StringBasis FILLER_71 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05 LD01-DATCMD                PIC  X(10)        VALUE SPACES*/
            public StringBasis LD01_DATCMD { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
            /*"    05 FILLER                     PIC  X(01)        VALUE ';'.*/
            public StringBasis FILLER_72 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05 LD01-COD-LOT-FENAL         PIC  X(15)        VALUE SPACES*/
            public StringBasis LD01_COD_LOT_FENAL { get; set; } = new StringBasis(new PIC("X", "15", "X(15)"), @"");
            /*"    05 FILLER                     PIC  X(01)        VALUE ';'.*/
            public StringBasis FILLER_73 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05 LD01-COD-LOT-CEF           PIC  X(15)        VALUE SPACES*/
            public StringBasis LD01_COD_LOT_CEF { get; set; } = new StringBasis(new PIC("X", "15", "X(15)"), @"");
            /*"    05 FILLER                     PIC  X(01)        VALUE ';'.*/
            public StringBasis FILLER_74 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05 LD01-NOME-LOTERICO         PIC  X(40)        VALUE SPACES*/
            public StringBasis LD01_NOME_LOTERICO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
            /*"    05 FILLER                     PIC  X(01)        VALUE ';'.*/
            public StringBasis FILLER_75 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05 LD01-SIGLA-UF              PIC  X(11)        VALUE SPACES*/
            public StringBasis LD01_SIGLA_UF { get; set; } = new StringBasis(new PIC("X", "11", "X(11)"), @"");
            /*"    05 FILLER                     PIC  X(01)        VALUE ';'.*/
            public StringBasis FILLER_76 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05 LD01-DATA-CANCELAMENTO     PIC  X(10)        VALUE SPACES*/
            public StringBasis LD01_DATA_CANCELAMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
            /*"    05 FILLER                     PIC  X(01)        VALUE ';'.*/
            public StringBasis FILLER_77 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05 LD01-VL-AVISADO            PIC  ----------------9,99.*/
            public DoubleBasis LD01_VL_AVISADO { get; set; } = new DoubleBasis(new PIC("9", "17", "----------------9V99."), 2);
            /*"    05 FILLER                     PIC  X(01)        VALUE ';'.*/
            public StringBasis FILLER_78 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05 LD01-VL-AVISADO-PER        PIC  ----------------9,99.*/
            public DoubleBasis LD01_VL_AVISADO_PER { get; set; } = new DoubleBasis(new PIC("9", "17", "----------------9V99."), 2);
            /*"    05 FILLER                     PIC  X(01)        VALUE ';'.*/
            public StringBasis FILLER_79 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05 LD01-VL-APURADO            PIC  ----------------9,99.*/
            public DoubleBasis LD01_VL_APURADO { get; set; } = new DoubleBasis(new PIC("9", "17", "----------------9V99."), 2);
            /*"    05 FILLER                     PIC  X(01)        VALUE ';'.*/
            public StringBasis FILLER_80 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05 LD01-VL-APURADO-PER        PIC  ----------------9,99.*/
            public DoubleBasis LD01_VL_APURADO_PER { get; set; } = new DoubleBasis(new PIC("9", "17", "----------------9V99."), 2);
            /*"    05 FILLER                     PIC  X(01)        VALUE ';'.*/
            public StringBasis FILLER_81 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05 LD01-VL-FRANQUIA           PIC  ----------------9,99.*/
            public DoubleBasis LD01_VL_FRANQUIA { get; set; } = new DoubleBasis(new PIC("9", "17", "----------------9V99."), 2);
            /*"    05 FILLER                     PIC  X(01)        VALUE ';'.*/
            public StringBasis FILLER_82 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05 LD01-VL-FRANQUIA-PER       PIC  ----------------9,99.*/
            public DoubleBasis LD01_VL_FRANQUIA_PER { get; set; } = new DoubleBasis(new PIC("9", "17", "----------------9V99."), 2);
            /*"    05 FILLER                     PIC  X(01)        VALUE ';'.*/
            public StringBasis FILLER_83 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05 LD01-VL-REINTEG-MES        PIC  ----------------9,99.*/
            public DoubleBasis LD01_VL_REINTEG_MES { get; set; } = new DoubleBasis(new PIC("9", "17", "----------------9V99."), 2);
            /*"    05 FILLER                     PIC  X(01)        VALUE ';'.*/
            public StringBasis FILLER_84 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05 LD01-VL-REINTEG-MES-PER    PIC  ----------------9,99.*/
            public DoubleBasis LD01_VL_REINTEG_MES_PER { get; set; } = new DoubleBasis(new PIC("9", "17", "----------------9V99."), 2);
            /*"    05 FILLER                     PIC  X(01)        VALUE ';'.*/
            public StringBasis FILLER_85 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05 LD01-VL-IOF-REINTEG-MES    PIC  ----------------9,99.*/
            public DoubleBasis LD01_VL_IOF_REINTEG_MES { get; set; } = new DoubleBasis(new PIC("9", "17", "----------------9V99."), 2);
            /*"    05 FILLER                     PIC  X(01)        VALUE ';'.*/
            public StringBasis FILLER_86 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05 LD01-VL-IOF-REINTEG-MES-PER PIC  ----------------9,99.*/
            public DoubleBasis LD01_VL_IOF_REINTEG_MES_PER { get; set; } = new DoubleBasis(new PIC("9", "17", "----------------9V99."), 2);
            /*"    05 FILLER                     PIC  X(01)        VALUE ';'.*/
            public StringBasis FILLER_87 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05 LD01-VL-CORRECAO           PIC  ----------------9,99.*/
            public DoubleBasis LD01_VL_CORRECAO { get; set; } = new DoubleBasis(new PIC("9", "17", "----------------9V99."), 2);
            /*"    05 FILLER                     PIC  X(01)        VALUE ';'.*/
            public StringBasis FILLER_88 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05 LD01-VL-CORRECAO-PER       PIC  ----------------9,99.*/
            public DoubleBasis LD01_VL_CORRECAO_PER { get; set; } = new DoubleBasis(new PIC("9", "17", "----------------9V99."), 2);
            /*"    05 FILLER                     PIC  X(01)        VALUE ';'.*/
            public StringBasis FILLER_89 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05 LD01-VL-REINTEG-ANT        PIC  ----------------9,99.*/
            public DoubleBasis LD01_VL_REINTEG_ANT { get; set; } = new DoubleBasis(new PIC("9", "17", "----------------9V99."), 2);
            /*"    05 FILLER                     PIC  X(01)        VALUE ';'.*/
            public StringBasis FILLER_90 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05 LD01-VL-REINTEG-ANT-PER    PIC  ----------------9,99.*/
            public DoubleBasis LD01_VL_REINTEG_ANT_PER { get; set; } = new DoubleBasis(new PIC("9", "17", "----------------9V99."), 2);
            /*"    05 FILLER                     PIC  X(01)        VALUE ';'.*/
            public StringBasis FILLER_91 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05 LD01-VL-IOF-REINTEG-ANT    PIC  ----------------9,99.*/
            public DoubleBasis LD01_VL_IOF_REINTEG_ANT { get; set; } = new DoubleBasis(new PIC("9", "17", "----------------9V99."), 2);
            /*"    05 FILLER                     PIC  X(01)        VALUE ';'.*/
            public StringBasis FILLER_92 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05 LD01-VL-IOF-REINTEG-ANT-PER PIC  ----------------9,99.*/
            public DoubleBasis LD01_VL_IOF_REINTEG_ANT_PER { get; set; } = new DoubleBasis(new PIC("9", "17", "----------------9V99."), 2);
            /*"    05 FILLER                     PIC  X(01)        VALUE ';'.*/
            public StringBasis FILLER_93 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05 LD01-VL-PAGO               PIC  ----------------9,99.*/
            public DoubleBasis LD01_VL_PAGO { get; set; } = new DoubleBasis(new PIC("9", "17", "----------------9V99."), 2);
            /*"    05 FILLER                     PIC  X(01)        VALUE ';'.*/
            public StringBasis FILLER_94 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05 LD01-VL-PAGO-PER           PIC  ----------------9,99.*/
            public DoubleBasis LD01_VL_PAGO_PER { get; set; } = new DoubleBasis(new PIC("9", "17", "----------------9V99."), 2);
            /*"    05 FILLER                     PIC  X(01)        VALUE ';'.*/
            public StringBasis FILLER_95 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05 LD01-VL-PENDENTE           PIC  ----------------9,99.*/
            public DoubleBasis LD01_VL_PENDENTE { get; set; } = new DoubleBasis(new PIC("9", "17", "----------------9V99."), 2);
            /*"    05 FILLER                     PIC  X(01)        VALUE ';'.*/
            public StringBasis FILLER_96 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"01  FILLER.*/
        }
        public SI0851B_FILLER_97 FILLER_97 { get; set; } = new SI0851B_FILLER_97();
        public class SI0851B_FILLER_97 : VarBasis
        {
            /*"    05 W-DATA-AAAA-MM-DD.*/
            public SI0851B_W_DATA_AAAA_MM_DD W_DATA_AAAA_MM_DD { get; set; } = new SI0851B_W_DATA_AAAA_MM_DD();
            public class SI0851B_W_DATA_AAAA_MM_DD : VarBasis
            {
                /*"       10 W-DATA-AAAA-MM-DD-AAAA     PIC  9(04) VALUE ZEROS.*/
                public IntBasis W_DATA_AAAA_MM_DD_AAAA { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
                /*"       10 FILLER                     PIC  X(01) VALUE '-'.*/
                public StringBasis FILLER_98 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
                /*"       10 W-DATA-AAAA-MM-DD-MM       PIC  9(02) VALUE ZEROS.*/
                public IntBasis W_DATA_AAAA_MM_DD_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"       10 FILLER                     PIC  X(01) VALUE '-'.*/
                public StringBasis FILLER_99 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
                /*"       10 W-DATA-AAAA-MM-DD-DD       PIC  9(02) VALUE ZEROS.*/
                public IntBasis W_DATA_AAAA_MM_DD_DD { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"    05 W-DATA1.*/
            }
            public SI0851B_W_DATA1 W_DATA1 { get; set; } = new SI0851B_W_DATA1();
            public class SI0851B_W_DATA1 : VarBasis
            {
                /*"       10 W-DATA1-AAAA               PIC  9(04) VALUE ZEROS.*/
                public IntBasis W_DATA1_AAAA { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
                /*"       10 FILLER                     PIC  X(01) VALUE '-'.*/
                public StringBasis FILLER_100 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
                /*"       10 W-DATA1-MM                 PIC  9(02) VALUE ZEROS.*/
                public IntBasis W_DATA1_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"       10 FILLER                     PIC  X(01) VALUE '-'.*/
                public StringBasis FILLER_101 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
                /*"       10 W-DATA1-DD                 PIC  9(02) VALUE ZEROS.*/
                public IntBasis W_DATA1_DD { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"    05 W-DATA2.*/
            }
            public SI0851B_W_DATA2 W_DATA2 { get; set; } = new SI0851B_W_DATA2();
            public class SI0851B_W_DATA2 : VarBasis
            {
                /*"       10 W-DATA2-DD                 PIC  9(02) VALUE ZEROS.*/
                public IntBasis W_DATA2_DD { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"       10 FILLER                     PIC  X(01) VALUE '/'.*/
                public StringBasis FILLER_102 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"/");
                /*"       10 W-DATA2-MM                 PIC  9(02) VALUE ZEROS.*/
                public IntBasis W_DATA2_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"       10 FILLER                     PIC  X(01) VALUE '/'.*/
                public StringBasis FILLER_103 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"/");
                /*"       10 W-DATA2-AAAA               PIC  9(04) VALUE ZEROS.*/
                public IntBasis W_DATA2_AAAA { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
                /*"    03 WABEND.*/
            }
            public SI0851B_WABEND WABEND { get; set; } = new SI0851B_WABEND();
            public class SI0851B_WABEND : VarBasis
            {
                /*"       10 FILLER              PIC X(010) VALUE ' SI0851B'.*/
                public StringBasis FILLER_104 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" SI0851B");
                /*"       10 FILLER              PIC X(026) VALUE          ' *** ERRO EXEC SQL NUMERO '.*/
                public StringBasis FILLER_105 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @" *** ERRO EXEC SQL NUMERO ");
                /*"       10 WNR-EXEC-SQL        PIC X(003) VALUE '000'.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"000");
                /*"       10 FILLER              PIC X(013) VALUE ' *** SQLCODE '.*/
                public StringBasis FILLER_106 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
                /*"       10 WSQLCODE            PIC ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
            }
        }


        public Copies.LBSI1001 LBSI1001 { get; set; } = new Copies.LBSI1001();
        public SI0851B_RELATORIO RELATORIO { get; set; } = new SI0851B_RELATORIO();
        public SI0851B_LOTERICO LOTERICO { get; set; } = new SI0851B_LOTERICO();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string ARQMOV_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                ARQMOV.SetFile(ARQMOV_FILE_NAME_P);

                /*" -452- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

                /*" -453- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

                /*" -454- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

                /*" -458- OPEN OUTPUT ARQMOV */
                ARQMOV.Open(REGISTRO_MOVTO);

                /*" -460- PERFORM 005-SELECT-V0SISTEMA THRU 005-EXIT. */

                M_005_SELECT_V0SISTEMA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_005_EXIT*/


                /*" -461- MOVE V0SISTEMA-DTMOVABE TO W-DATA1. */
                _.Move(V0SISTEMA_DTMOVABE, FILLER_97.W_DATA1);

                /*" -462- MOVE W-DATA1-AAAA TO W-DATA2-AAAA. */
                _.Move(FILLER_97.W_DATA1.W_DATA1_AAAA, FILLER_97.W_DATA2.W_DATA2_AAAA);

                /*" -463- MOVE W-DATA1-MM TO W-DATA2-MM. */
                _.Move(FILLER_97.W_DATA1.W_DATA1_MM, FILLER_97.W_DATA2.W_DATA2_MM);

                /*" -464- MOVE W-DATA1-DD TO W-DATA2-DD. */
                _.Move(FILLER_97.W_DATA1.W_DATA1_DD, FILLER_97.W_DATA2.W_DATA2_DD);

                /*" -466- MOVE W-DATA2 TO LC01-DTMOVABE. */
                _.Move(FILLER_97.W_DATA2, LC01.LC01_DTMOVABE);

                /*" -467- WRITE REGISTRO-MOVTO FROM LC00. */
                _.Move(LC00.GetMoveValues(), REGISTRO_MOVTO);

                ARQMOV.Write(REGISTRO_MOVTO.GetMoveValues().ToString());

                /*" -469- WRITE REGISTRO-MOVTO FROM LC01. */
                _.Move(LC01.GetMoveValues(), REGISTRO_MOVTO);

                ARQMOV.Write(REGISTRO_MOVTO.GetMoveValues().ToString());

                /*" -471- PERFORM 007-SELECT-V0RELAT THRU 007-EXIT */

                M_007_SELECT_V0RELAT(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_007_EXIT*/


                /*" -472- IF HOST-COUNT EQUAL ZERO */

                if (HOST_COUNT == 00)
                {

                    /*" -473- DISPLAY '***********************************************' */
                    _.Display($"***********************************************");

                    /*" -474- DISPLAY '                                               ' */
                    _.Display($"                                               ");

                    /*" -475- DISPLAY '             PROGRAMA - SI0851B                ' */
                    _.Display($"             PROGRAMA - SI0851B                ");

                    /*" -476- DISPLAY '                                               ' */
                    _.Display($"                                               ");

                    /*" -477- DISPLAY ' NAO HOUVE SOLICITACAO PARA EXECUCAO DO PROG.  ' */
                    _.Display($" NAO HOUVE SOLICITACAO PARA EXECUCAO DO PROG.  ");

                    /*" -478- DISPLAY '                                               ' */
                    _.Display($"                                               ");

                    /*" -479- DISPLAY '***********************************************' */
                    _.Display($"***********************************************");

                    /*" -481- MOVE 'NAO HOUVE SOLICITACAO PARA EXECUCAO DO PROGRAMA' TO LD01 */
                    _.Move("NAO HOUVE SOLICITACAO PARA EXECUCAO DO PROGRAMA", LD01);

                    /*" -482- WRITE REGISTRO-MOVTO FROM LD01 */
                    _.Move(LD01.GetMoveValues(), REGISTRO_MOVTO);

                    ARQMOV.Write(REGISTRO_MOVTO.GetMoveValues().ToString());

                    /*" -483- GO TO 000-FINALIZA */

                    M_000_FINALIZA(); //GOTO
                    return Result;

                    /*" -485- END-IF */
                }


                /*" -486- MOVE SPACES TO STATUS-RELATORIO */
                _.Move("", AREA_DE_WORK.STATUS_RELATORIO);

                /*" -489- PERFORM 008-FETCH-RELATORIO */

                M_008_FETCH_RELATORIO(true);

                /*" -492- PERFORM 300-PROCESSA-RELATORIO THRU 300-EXIT UNTIL WFIM-RELATORIO */

                while (!(AREA_DE_WORK.STATUS_RELATORIO["WFIM_RELATORIO"]))
                {

                    M_300_PROCESSA_RELATORIO(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_300_EXIT*/

                }

                /*" -494- PERFORM 200-ATUALIZA-RELATORIO */

                M_200_ATUALIZA_RELATORIO(true);

                /*" -495- DISPLAY '***********************************************' */
                _.Display($"***********************************************");

                /*" -496- DISPLAY '             PROGRAMA - SI0851B                ' */
                _.Display($"             PROGRAMA - SI0851B                ");

                /*" -497- DISPLAY '                                               ' */
                _.Display($"                                               ");

                /*" -498- DISPLAY '               TERMINO NORMAL                  ' */
                _.Display($"               TERMINO NORMAL                  ");

                /*" -498- DISPLAY '***********************************************' . */
                _.Display($"***********************************************");

                /*" -498- FLUXCONTROL_PERFORM M-000-FINALIZA */

                M_000_FINALIZA();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { CodigoRetorno = RETURN_CODE.Value };
            return Result;
        }

        [StopWatch]
        /*" M-000-FINALIZA */
        private void M_000_FINALIZA(bool isPerform = false)
        {
            /*" -504- CLOSE ARQMOV. */
            ARQMOV.Close();

            /*" -504- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -510- MOVE ZEROS TO RETURN-CODE */
            _.Move(0, RETURN_CODE);

            /*" -510- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" M-005-SELECT-V0SISTEMA */
        private void M_005_SELECT_V0SISTEMA(bool isPerform = false)
        {
            /*" -516- MOVE '001' TO WNR-EXEC-SQL */
            _.Move("001", FILLER_97.WABEND.WNR_EXEC_SQL);

            /*" -521- PERFORM M_005_SELECT_V0SISTEMA_DB_SELECT_1 */

            M_005_SELECT_V0SISTEMA_DB_SELECT_1();

            /*" -524- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -525- DISPLAY 'ERRO DE SELECT V0SISTEMA ...................' */
                _.Display($"ERRO DE SELECT V0SISTEMA ...................");

                /*" -525- GO TO 9999-ROT-ERRO. */

                M_9999_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-005-SELECT-V0SISTEMA-DB-SELECT-1 */
        public void M_005_SELECT_V0SISTEMA_DB_SELECT_1()
        {
            /*" -521- EXEC SQL SELECT DTMOVABE INTO :V0SISTEMA-DTMOVABE FROM SEGUROS.V0SISTEMA WHERE IDSISTEM = 'SI' END-EXEC. */

            var m_005_SELECT_V0SISTEMA_DB_SELECT_1_Query1 = new M_005_SELECT_V0SISTEMA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = M_005_SELECT_V0SISTEMA_DB_SELECT_1_Query1.Execute(m_005_SELECT_V0SISTEMA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0SISTEMA_DTMOVABE, V0SISTEMA_DTMOVABE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_005_EXIT*/

        [StopWatch]
        /*" M-007-SELECT-V0RELAT */
        private void M_007_SELECT_V0RELAT(bool isPerform = false)
        {
            /*" -533- MOVE '002' TO WNR-EXEC-SQL */
            _.Move("002", FILLER_97.WABEND.WNR_EXEC_SQL);

            /*" -540- PERFORM M_007_SELECT_V0RELAT_DB_SELECT_1 */

            M_007_SELECT_V0RELAT_DB_SELECT_1();

            /*" -543- IF HOST-COUNT EQUAL ZERO */

            if (HOST_COUNT == 00)
            {

                /*" -545- GO TO 007-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_007_EXIT*/ //GOTO
                return;
            }


            /*" -547- MOVE '003' TO WNR-EXEC-SQL */
            _.Move("003", FILLER_97.WABEND.WNR_EXEC_SQL);

            /*" -557- PERFORM M_007_SELECT_V0RELAT_DB_DECLARE_1 */

            M_007_SELECT_V0RELAT_DB_DECLARE_1();

            /*" -560- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -561- DISPLAY '/////////////////////////////////////////////' */
                _.Display($"/////////////////////////////////////////////");

                /*" -562- DISPLAY 'ERRO DE SELECT V0RELATORIOS ................' */
                _.Display($"ERRO DE SELECT V0RELATORIOS ................");

                /*" -563- DISPLAY '/////////////////////////////////////////////' */
                _.Display($"/////////////////////////////////////////////");

                /*" -564- GO TO 9999-ROT-ERRO */

                M_9999_ROT_ERRO(); //GOTO
                return;

                /*" -566- END-IF */
            }


            /*" -566- PERFORM M_007_SELECT_V0RELAT_DB_OPEN_1 */

            M_007_SELECT_V0RELAT_DB_OPEN_1();

        }

        [StopWatch]
        /*" M-007-SELECT-V0RELAT-DB-SELECT-1 */
        public void M_007_SELECT_V0RELAT_DB_SELECT_1()
        {
            /*" -540- EXEC SQL SELECT VALUE(COUNT(*),0) INTO :HOST-COUNT FROM SEGUROS.V0RELATORIOS WHERE IDSISTEM = 'SI' AND CODRELAT = 'SI0851B' AND SITUACAO = '0' END-EXEC. */

            var m_007_SELECT_V0RELAT_DB_SELECT_1_Query1 = new M_007_SELECT_V0RELAT_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = M_007_SELECT_V0RELAT_DB_SELECT_1_Query1.Execute(m_007_SELECT_V0RELAT_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HOST_COUNT, HOST_COUNT);
            }


        }

        [StopWatch]
        /*" M-007-SELECT-V0RELAT-DB-DECLARE-1 */
        public void M_007_SELECT_V0RELAT_DB_DECLARE_1()
        {
            /*" -557- EXEC SQL DECLARE RELATORIO CURSOR FOR SELECT PERI_INICIAL, PERI_FINAL, NUM_APOLICE, DATA_SOLICITACAO, CODUSU FROM SEGUROS.V0RELATORIOS WHERE IDSISTEM = 'SI' AND CODRELAT = 'SI0851B' AND SITUACAO = '0' END-EXEC. */
            RELATORIO = new SI0851B_RELATORIO(false);
            string GetQuery_RELATORIO()
            {
                var query = @$"SELECT PERI_INICIAL
							, 
							PERI_FINAL
							, 
							NUM_APOLICE
							, 
							DATA_SOLICITACAO
							, 
							CODUSU 
							FROM SEGUROS.V0RELATORIOS 
							WHERE IDSISTEM = 'SI' 
							AND CODRELAT = 'SI0851B' 
							AND SITUACAO = '0'";

                return query;
            }
            RELATORIO.GetQueryEvent += GetQuery_RELATORIO;

        }

        [StopWatch]
        /*" M-007-SELECT-V0RELAT-DB-OPEN-1 */
        public void M_007_SELECT_V0RELAT_DB_OPEN_1()
        {
            /*" -566- EXEC SQL OPEN RELATORIO END-EXEC. */

            RELATORIO.Open();

        }

        [StopWatch]
        /*" M-009-DECLARE-LOTERICO-DB-DECLARE-1 */
        public void M_009_DECLARE_LOTERICO_DB_DECLARE_1()
        {
            /*" -636- EXEC SQL DECLARE LOTERICO CURSOR FOR SELECT M.NUM_APOLICE, M.NUM_APOL_SINISTRO, M.SITUACAO, M.DATORR, M.DATCMD, S.COD_LOT_FENAL, S.COD_LOT_CEF, C.NOME_RAZAO, E.SIGLA_UF FROM SEGUROS.V0MESTSINI M, SEGUROS.V0SINI_LOTERICO01 S, SEGUROS.V0CLIENTE C, SEGUROS.V0ENDERECOS E WHERE M.NUM_APOLICE BETWEEN :HOST-APOLICE-INICIAL AND :HOST-APOLICE-FINAL AND M.CODPRODU = 7105 AND M.NUM_APOL_SINISTRO BETWEEN 0107100000000 AND 0107199999999 AND S.NUM_APOL_SINISTRO BETWEEN 0107100000000 AND 0107199999999 AND S.NUM_APOL_SINISTRO = M.NUM_APOL_SINISTRO AND C.COD_CLIENTE = S.COD_CLIENTE AND E.COD_CLIENTE = C.COD_CLIENTE AND E.OCORR_ENDERECO = 1 ORDER BY M.NUM_APOL_SINISTRO END-EXEC */
            LOTERICO = new SI0851B_LOTERICO(true);
            string GetQuery_LOTERICO()
            {
                var query = @$"SELECT M.NUM_APOLICE
							, 
							M.NUM_APOL_SINISTRO
							, 
							M.SITUACAO
							, 
							M.DATORR
							, 
							M.DATCMD
							, 
							S.COD_LOT_FENAL
							, 
							S.COD_LOT_CEF
							, 
							C.NOME_RAZAO
							, 
							E.SIGLA_UF 
							FROM SEGUROS.V0MESTSINI M
							, 
							SEGUROS.V0SINI_LOTERICO01 S
							, 
							SEGUROS.V0CLIENTE C
							, 
							SEGUROS.V0ENDERECOS E 
							WHERE M.NUM_APOLICE BETWEEN '{HOST_APOLICE_INICIAL}' 
							AND '{HOST_APOLICE_FINAL}' 
							AND M.CODPRODU = 7105 
							AND M.NUM_APOL_SINISTRO BETWEEN 0107100000000 
							AND 0107199999999 
							AND S.NUM_APOL_SINISTRO BETWEEN 0107100000000 
							AND 0107199999999 
							AND S.NUM_APOL_SINISTRO = M.NUM_APOL_SINISTRO 
							AND C.COD_CLIENTE = S.COD_CLIENTE 
							AND E.COD_CLIENTE = C.COD_CLIENTE 
							AND E.OCORR_ENDERECO = 1 
							ORDER BY M.NUM_APOL_SINISTRO";

                return query;
            }
            LOTERICO.GetQueryEvent += GetQuery_LOTERICO;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_007_EXIT*/

        [StopWatch]
        /*" M-008-FETCH-RELATORIO */
        private void M_008_FETCH_RELATORIO(bool isPerform = false)
        {
            /*" -574- MOVE '005' TO WNR-EXEC-SQL */
            _.Move("005", FILLER_97.WABEND.WNR_EXEC_SQL);

            /*" -581- PERFORM M_008_FETCH_RELATORIO_DB_FETCH_1 */

            M_008_FETCH_RELATORIO_DB_FETCH_1();

            /*" -584- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -584- PERFORM M_008_FETCH_RELATORIO_DB_CLOSE_1 */

                M_008_FETCH_RELATORIO_DB_CLOSE_1();

                /*" -586- SET WFIM-RELATORIO TO TRUE */
                AREA_DE_WORK.STATUS_RELATORIO["WFIM_RELATORIO"] = true;

                /*" -588- END-IF */
            }


            /*" -590- IF (SQLCODE NOT EQUAL ZEROS) AND (SQLCODE NOT EQUAL 100) */

            if ((DB.SQLCODE != 00) && (DB.SQLCODE != 100))
            {

                /*" -591- DISPLAY '////////////////////////////////////////////' */
                _.Display($"////////////////////////////////////////////");

                /*" -592- DISPLAY 'ERRO DE FETCH RELATORIO ....................' */
                _.Display($"ERRO DE FETCH RELATORIO ....................");

                /*" -593- DISPLAY '////////////////////////////////////////////' */
                _.Display($"////////////////////////////////////////////");

                /*" -594- GO TO 9999-ROT-ERRO */

                M_9999_ROT_ERRO(); //GOTO
                return;

                /*" -596- END-IF */
            }


            /*" -597- DISPLAY '/////////////////////////////////////////////////' */
            _.Display($"/////////////////////////////////////////////////");

            /*" -598- DISPLAY 'DADOS ENCONTRADOS NA V0RELATORIOS' */
            _.Display($"DADOS ENCONTRADOS NA V0RELATORIOS");

            /*" -599- DISPLAY 'DATA SOLICITACAO       = ' V0REL-DATA-SOLICITACAO */
            _.Display($"DATA SOLICITACAO       = {V0REL_DATA_SOLICITACAO}");

            /*" -600- DISPLAY 'USUARIO SOLICITANTE    = ' V0REL-CODUSU */
            _.Display($"USUARIO SOLICITANTE    = {V0REL_CODUSU}");

            /*" -601- DISPLAY 'PERIODO INICIAL SOLIC. = ' V0REL-PERI-INICIAL */
            _.Display($"PERIODO INICIAL SOLIC. = {V0REL_PERI_INICIAL}");

            /*" -602- DISPLAY 'PERIODO FINAL   SOLIC. = ' V0REL-PERI-FINAL */
            _.Display($"PERIODO FINAL   SOLIC. = {V0REL_PERI_FINAL}");

            /*" -602- DISPLAY '/////////////////////////////////////////////////' . */
            _.Display($"/////////////////////////////////////////////////");

        }

        [StopWatch]
        /*" M-008-FETCH-RELATORIO-DB-FETCH-1 */
        public void M_008_FETCH_RELATORIO_DB_FETCH_1()
        {
            /*" -581- EXEC SQL FETCH RELATORIO INTO :V0REL-PERI-INICIAL, :V0REL-PERI-FINAL, :V0REL-NUM-APOLICE, :V0REL-DATA-SOLICITACAO, :V0REL-CODUSU END-EXEC */

            if (RELATORIO.Fetch())
            {
                _.Move(RELATORIO.V0REL_PERI_INICIAL, V0REL_PERI_INICIAL);
                _.Move(RELATORIO.V0REL_PERI_FINAL, V0REL_PERI_FINAL);
                _.Move(RELATORIO.V0REL_NUM_APOLICE, V0REL_NUM_APOLICE);
                _.Move(RELATORIO.V0REL_DATA_SOLICITACAO, V0REL_DATA_SOLICITACAO);
                _.Move(RELATORIO.V0REL_CODUSU, V0REL_CODUSU);
            }

        }

        [StopWatch]
        /*" M-008-FETCH-RELATORIO-DB-CLOSE-1 */
        public void M_008_FETCH_RELATORIO_DB_CLOSE_1()
        {
            /*" -584- EXEC SQL CLOSE RELATORIO END-EXEC */

            RELATORIO.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_008_EXIT*/

        [StopWatch]
        /*" M-009-DECLARE-LOTERICO */
        private void M_009_DECLARE_LOTERICO(bool isPerform = false)
        {
            /*" -610- MOVE '005' TO WNR-EXEC-SQL */
            _.Move("005", FILLER_97.WABEND.WNR_EXEC_SQL);

            /*" -636- PERFORM M_009_DECLARE_LOTERICO_DB_DECLARE_1 */

            M_009_DECLARE_LOTERICO_DB_DECLARE_1();

            /*" -638- PERFORM M_009_DECLARE_LOTERICO_DB_OPEN_1 */

            M_009_DECLARE_LOTERICO_DB_OPEN_1();

        }

        [StopWatch]
        /*" M-009-DECLARE-LOTERICO-DB-OPEN-1 */
        public void M_009_DECLARE_LOTERICO_DB_OPEN_1()
        {
            /*" -638- EXEC SQL OPEN LOTERICO END-EXEC. */

            LOTERICO.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_009_EXIT*/

        [StopWatch]
        /*" M-010-FETCH-SINISTRO */
        private void M_010_FETCH_SINISTRO(bool isPerform = false)
        {
            /*" -646- MOVE '006' TO WNR-EXEC-SQL */
            _.Move("006", FILLER_97.WABEND.WNR_EXEC_SQL);

            /*" -657- PERFORM M_010_FETCH_SINISTRO_DB_FETCH_1 */

            M_010_FETCH_SINISTRO_DB_FETCH_1();

            /*" -660- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -660- PERFORM M_010_FETCH_SINISTRO_DB_CLOSE_1 */

                M_010_FETCH_SINISTRO_DB_CLOSE_1();

                /*" -663- MOVE 'SIM' TO WFIM-LOTERICO. */
                _.Move("SIM", AREA_DE_WORK.WFIM_LOTERICO);
            }


            /*" -665- IF (SQLCODE NOT EQUAL ZEROS) AND (SQLCODE NOT EQUAL 100) */

            if ((DB.SQLCODE != 00) && (DB.SQLCODE != 100))
            {

                /*" -666- DISPLAY 'ERRO DE FETCH LOTERICO  ....................' */
                _.Display($"ERRO DE FETCH LOTERICO  ....................");

                /*" -667- DISPLAY 'NUM. SINISTRO = ' V0MEST-NUM-APOL-SINISTRO */
                _.Display($"NUM. SINISTRO = {V0MEST_NUM_APOL_SINISTRO}");

                /*" -667- GO TO 9999-ROT-ERRO. */

                M_9999_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-010-FETCH-SINISTRO-DB-FETCH-1 */
        public void M_010_FETCH_SINISTRO_DB_FETCH_1()
        {
            /*" -657- EXEC SQL FETCH LOTERICO INTO :V0MEST-NUM-APOLICE, :V0MEST-NUM-APOL-SINISTRO, :V0MEST-SITUACAO, :V0MEST-DATORR, :V0MEST-DATCMD, :V0SLOT-COD-LOT-FENAL, :V0SLOT-COD-LOT-CEF, :V0CLI-NOME-RAZAO, :V0END-SIGLA-UF END-EXEC. */

            if (LOTERICO.Fetch())
            {
                _.Move(LOTERICO.V0MEST_NUM_APOLICE, V0MEST_NUM_APOLICE);
                _.Move(LOTERICO.V0MEST_NUM_APOL_SINISTRO, V0MEST_NUM_APOL_SINISTRO);
                _.Move(LOTERICO.V0MEST_SITUACAO, V0MEST_SITUACAO);
                _.Move(LOTERICO.V0MEST_DATORR, V0MEST_DATORR);
                _.Move(LOTERICO.V0MEST_DATCMD, V0MEST_DATCMD);
                _.Move(LOTERICO.V0SLOT_COD_LOT_FENAL, V0SLOT_COD_LOT_FENAL);
                _.Move(LOTERICO.V0SLOT_COD_LOT_CEF, V0SLOT_COD_LOT_CEF);
                _.Move(LOTERICO.V0CLI_NOME_RAZAO, V0CLI_NOME_RAZAO);
                _.Move(LOTERICO.V0END_SIGLA_UF, V0END_SIGLA_UF);
            }

        }

        [StopWatch]
        /*" M-010-FETCH-SINISTRO-DB-CLOSE-1 */
        public void M_010_FETCH_SINISTRO_DB_CLOSE_1()
        {
            /*" -660- EXEC SQL CLOSE LOTERICO END-EXEC */

            LOTERICO.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_010_EXIT*/

        [StopWatch]
        /*" M-030-PROCESSA-LOTERICO */
        private void M_030_PROCESSA_LOTERICO(bool isPerform = false)
        {
            /*" -674- MOVE V0MEST-NUM-APOLICE TO LD01-NUM-APOLICE */
            _.Move(V0MEST_NUM_APOLICE, LD01.LD01_NUM_APOLICE);

            /*" -675- MOVE V0MEST-NUM-APOL-SINISTRO TO LD01-NUM-APOL-SINISTRO. */
            _.Move(V0MEST_NUM_APOL_SINISTRO, LD01.LD01_NUM_APOL_SINISTRO);

            /*" -676- MOVE V0SLOT-COD-LOT-CEF TO LD01-COD-LOT-CEF. */
            _.Move(V0SLOT_COD_LOT_CEF, LD01.LD01_COD_LOT_CEF);

            /*" -677- MOVE V0SLOT-COD-LOT-FENAL TO LD01-COD-LOT-FENAL. */
            _.Move(V0SLOT_COD_LOT_FENAL, LD01.LD01_COD_LOT_FENAL);

            /*" -678- MOVE V0CLI-NOME-RAZAO TO LD01-NOME-LOTERICO. */
            _.Move(V0CLI_NOME_RAZAO, LD01.LD01_NOME_LOTERICO);

            /*" -679- MOVE V0END-SIGLA-UF TO LD01-SIGLA-UF. */
            _.Move(V0END_SIGLA_UF, LD01.LD01_SIGLA_UF);

            /*" -680- MOVE V0MEST-DATORR TO W-DATA1. */
            _.Move(V0MEST_DATORR, FILLER_97.W_DATA1);

            /*" -681- MOVE W-DATA1-AAAA TO W-DATA2-AAAA. */
            _.Move(FILLER_97.W_DATA1.W_DATA1_AAAA, FILLER_97.W_DATA2.W_DATA2_AAAA);

            /*" -682- MOVE W-DATA1-MM TO W-DATA2-MM. */
            _.Move(FILLER_97.W_DATA1.W_DATA1_MM, FILLER_97.W_DATA2.W_DATA2_MM);

            /*" -683- MOVE W-DATA1-DD TO W-DATA2-DD. */
            _.Move(FILLER_97.W_DATA1.W_DATA1_DD, FILLER_97.W_DATA2.W_DATA2_DD);

            /*" -684- MOVE W-DATA2 TO LD01-DATORR. */
            _.Move(FILLER_97.W_DATA2, LD01.LD01_DATORR);

            /*" -685- MOVE V0MEST-DATCMD TO W-DATA1. */
            _.Move(V0MEST_DATCMD, FILLER_97.W_DATA1);

            /*" -686- MOVE W-DATA1-AAAA TO W-DATA2-AAAA. */
            _.Move(FILLER_97.W_DATA1.W_DATA1_AAAA, FILLER_97.W_DATA2.W_DATA2_AAAA);

            /*" -687- MOVE W-DATA1-MM TO W-DATA2-MM. */
            _.Move(FILLER_97.W_DATA1.W_DATA1_MM, FILLER_97.W_DATA2.W_DATA2_MM);

            /*" -688- MOVE W-DATA1-DD TO W-DATA2-DD. */
            _.Move(FILLER_97.W_DATA1.W_DATA1_DD, FILLER_97.W_DATA2.W_DATA2_DD);

            /*" -690- MOVE W-DATA2 TO LD01-DATCMD. */
            _.Move(FILLER_97.W_DATA2, LD01.LD01_DATCMD);

            /*" -691- IF V0MEST-SITUACAO EQUAL '2' */

            if (V0MEST_SITUACAO == "2")
            {

                /*" -692- PERFORM M-100-SELECT-CANCELAMENTO THRU 100-EXIT */

                M_100_SELECT_CANCELAMENTO(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_100_EXIT*/


                /*" -693- MOVE V0HIST-DTMOVTO TO LD01-DATA-CANCELAMENTO */
                _.Move(V0HIST_DTMOVTO, LD01.LD01_DATA_CANCELAMENTO);

                /*" -694- ELSE */
            }
            else
            {


                /*" -698- MOVE SPACES TO LD01-DATA-CANCELAMENTO. */
                _.Move("", LD01.LD01_DATA_CANCELAMENTO);
            }


            /*" -700- MOVE '007' TO WNR-EXEC-SQL */
            _.Move("007", FILLER_97.WABEND.WNR_EXEC_SQL);

            /*" -702- INITIALIZE SI1001S-PARAMETROS. */
            _.Initialize(
                LBSI1001.SI1001S_PARAMETROS
            );

            /*" -704- MOVE V0MEST-NUM-APOL-SINISTRO TO SI1001S-NUM-APOL-SINISTRO */
            _.Move(V0MEST_NUM_APOL_SINISTRO, LBSI1001.SI1001S_PARAMETROS.SI1001S_ENTRADA.SI1001S_NUM_APOL_SINISTRO);

            /*" -706- CALL 'SI1003S' USING SI1001S-PARAMETROS */
            _.Call("SI1003S", LBSI1001.SI1001S_PARAMETROS);

            /*" -707- IF SI1001S-ERRO-MENSAGEM NOT EQUAL SPACES */

            if (!LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_ERRO_MENSAGEM.IsEmpty())
            {

                /*" -709- DISPLAY 'PROBLEMA CALL SI1003S ' ' ' V0MEST-NUM-APOL-SINISTRO */

                $"PROBLEMA CALL SI1003S  {V0MEST_NUM_APOL_SINISTRO}"
                .Display();

                /*" -710- DISPLAY 'SQLCODE = ' SI1001S-ERRO-SQLCODE */
                _.Display($"SQLCODE = {LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_ERRO_SQLCODE}");

                /*" -711- DISPLAY SI1001S-ERRO-MENSAGEM */
                _.Display(LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_ERRO_MENSAGEM);

                /*" -712- GO TO 9999-ROT-ERRO */

                M_9999_ROT_ERRO(); //GOTO
                return;

                /*" -713- ELSE */
            }
            else
            {


                /*" -717- MOVE SI1001S-VALOR-CALCULADO TO LD01-VL-AVISADO. */
                _.Move(LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_VALOR_CALCULADO, LD01.LD01_VL_AVISADO);
            }


            /*" -719- MOVE '008' TO WNR-EXEC-SQL */
            _.Move("008", FILLER_97.WABEND.WNR_EXEC_SQL);

            /*" -721- INITIALIZE SI1001S-PARAMETROS. */
            _.Initialize(
                LBSI1001.SI1001S_PARAMETROS
            );

            /*" -722- MOVE V0MEST-NUM-APOL-SINISTRO TO SI1001S-NUM-APOL-SINISTRO */
            _.Move(V0MEST_NUM_APOL_SINISTRO, LBSI1001.SI1001S_PARAMETROS.SI1001S_ENTRADA.SI1001S_NUM_APOL_SINISTRO);

            /*" -723- MOVE V0REL-PERI-INICIAL TO SI1001S-DATA-INICIO */
            _.Move(V0REL_PERI_INICIAL, LBSI1001.SI1001S_PARAMETROS.SI1001S_ENTRADA.SI1001S_DATA_INICIO);

            /*" -725- MOVE V0REL-PERI-FINAL TO SI1001S-DATA-FIM */
            _.Move(V0REL_PERI_FINAL, LBSI1001.SI1001S_PARAMETROS.SI1001S_ENTRADA.SI1001S_DATA_FIM);

            /*" -727- CALL 'SI1003S' USING SI1001S-PARAMETROS */
            _.Call("SI1003S", LBSI1001.SI1001S_PARAMETROS);

            /*" -728- IF SI1001S-ERRO-MENSAGEM NOT EQUAL SPACES */

            if (!LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_ERRO_MENSAGEM.IsEmpty())
            {

                /*" -732- DISPLAY 'PROBLEMA CALL SI1003S ' ' ' V0MEST-NUM-APOL-SINISTRO ' ' V0REL-PERI-INICIAL ' ' V0REL-PERI-FINAL */

                $"PROBLEMA CALL SI1003S  {V0MEST_NUM_APOL_SINISTRO} {V0REL_PERI_INICIAL} {V0REL_PERI_FINAL}"
                .Display();

                /*" -733- DISPLAY 'SQLCODE = ' SI1001S-ERRO-SQLCODE */
                _.Display($"SQLCODE = {LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_ERRO_SQLCODE}");

                /*" -734- DISPLAY SI1001S-ERRO-MENSAGEM */
                _.Display(LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_ERRO_MENSAGEM);

                /*" -735- GO TO 9999-ROT-ERRO */

                M_9999_ROT_ERRO(); //GOTO
                return;

                /*" -736- ELSE */
            }
            else
            {


                /*" -738- MOVE SI1001S-VALOR-CALCULADO TO LD01-VL-AVISADO-PER. */
                _.Move(LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_VALOR_CALCULADO, LD01.LD01_VL_AVISADO_PER);
            }


            /*" -740- MOVE '009' TO WNR-EXEC-SQL */
            _.Move("009", FILLER_97.WABEND.WNR_EXEC_SQL);

            /*" -747- PERFORM M_030_PROCESSA_LOTERICO_DB_SELECT_1 */

            M_030_PROCESSA_LOTERICO_DB_SELECT_1();

            /*" -750- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -751- DISPLAY 'ERRO DE SELECT V0HISTSINI ..................' */
                _.Display($"ERRO DE SELECT V0HISTSINI ..................");

                /*" -752- DISPLAY 'NUM. SIN. = ' V0MEST-NUM-APOL-SINISTRO */
                _.Display($"NUM. SIN. = {V0MEST_NUM_APOL_SINISTRO}");

                /*" -754- GO TO 9999-ROT-ERRO. */

                M_9999_ROT_ERRO(); //GOTO
                return;
            }


            /*" -756- MOVE V0HIST-VAL-OPERACAO TO LD01-VL-APURADO. */
            _.Move(V0HIST_VAL_OPERACAO, LD01.LD01_VL_APURADO);

            /*" -758- MOVE '010' TO WNR-EXEC-SQL */
            _.Move("010", FILLER_97.WABEND.WNR_EXEC_SQL);

            /*" -767- PERFORM M_030_PROCESSA_LOTERICO_DB_SELECT_2 */

            M_030_PROCESSA_LOTERICO_DB_SELECT_2();

            /*" -770- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -771- DISPLAY 'ERRO DE SELECT V0HISTSINI ..................' */
                _.Display($"ERRO DE SELECT V0HISTSINI ..................");

                /*" -772- DISPLAY 'NUM. SIN. = ' V0MEST-NUM-APOL-SINISTRO */
                _.Display($"NUM. SIN. = {V0MEST_NUM_APOL_SINISTRO}");

                /*" -774- GO TO 9999-ROT-ERRO. */

                M_9999_ROT_ERRO(); //GOTO
                return;
            }


            /*" -776- MOVE V0HIST-VAL-OPERACAO TO LD01-VL-APURADO-PER. */
            _.Move(V0HIST_VAL_OPERACAO, LD01.LD01_VL_APURADO_PER);

            /*" -778- MOVE '011' TO WNR-EXEC-SQL */
            _.Move("011", FILLER_97.WABEND.WNR_EXEC_SQL);

            /*" -789- PERFORM M_030_PROCESSA_LOTERICO_DB_SELECT_3 */

            M_030_PROCESSA_LOTERICO_DB_SELECT_3();

            /*" -792- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -793- DISPLAY 'ERRO DE SELECT V0HISTSINI ..................' */
                _.Display($"ERRO DE SELECT V0HISTSINI ..................");

                /*" -794- DISPLAY 'NUM. SIN. = ' V0MEST-NUM-APOL-SINISTRO */
                _.Display($"NUM. SIN. = {V0MEST_NUM_APOL_SINISTRO}");

                /*" -796- GO TO 9999-ROT-ERRO. */

                M_9999_ROT_ERRO(); //GOTO
                return;
            }


            /*" -798- MOVE V0HIST-VAL-OPERACAO TO LD01-VL-FRANQUIA. */
            _.Move(V0HIST_VAL_OPERACAO, LD01.LD01_VL_FRANQUIA);

            /*" -800- MOVE '012' TO WNR-EXEC-SQL */
            _.Move("012", FILLER_97.WABEND.WNR_EXEC_SQL);

            /*" -813- PERFORM M_030_PROCESSA_LOTERICO_DB_SELECT_4 */

            M_030_PROCESSA_LOTERICO_DB_SELECT_4();

            /*" -816- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -817- DISPLAY 'ERRO DE SELECT V0HISTSINI ..................' */
                _.Display($"ERRO DE SELECT V0HISTSINI ..................");

                /*" -818- DISPLAY 'NUM. SIN. = ' V0MEST-NUM-APOL-SINISTRO */
                _.Display($"NUM. SIN. = {V0MEST_NUM_APOL_SINISTRO}");

                /*" -820- GO TO 9999-ROT-ERRO. */

                M_9999_ROT_ERRO(); //GOTO
                return;
            }


            /*" -822- MOVE V0HIST-VAL-OPERACAO TO LD01-VL-FRANQUIA-PER. */
            _.Move(V0HIST_VAL_OPERACAO, LD01.LD01_VL_FRANQUIA_PER);

            /*" -824- MOVE '013' TO WNR-EXEC-SQL */
            _.Move("013", FILLER_97.WABEND.WNR_EXEC_SQL);

            /*" -835- PERFORM M_030_PROCESSA_LOTERICO_DB_SELECT_5 */

            M_030_PROCESSA_LOTERICO_DB_SELECT_5();

            /*" -838- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -839- DISPLAY 'ERRO DE SELECT V0HISTSINI ..................' */
                _.Display($"ERRO DE SELECT V0HISTSINI ..................");

                /*" -840- DISPLAY 'NUM. SIN. = ' V0MEST-NUM-APOL-SINISTRO */
                _.Display($"NUM. SIN. = {V0MEST_NUM_APOL_SINISTRO}");

                /*" -842- GO TO 9999-ROT-ERRO. */

                M_9999_ROT_ERRO(); //GOTO
                return;
            }


            /*" -844- MOVE V0HIST-VAL-OPERACAO TO LD01-VL-REINTEG-MES. */
            _.Move(V0HIST_VAL_OPERACAO, LD01.LD01_VL_REINTEG_MES);

            /*" -846- MOVE '014' TO WNR-EXEC-SQL */
            _.Move("014", FILLER_97.WABEND.WNR_EXEC_SQL);

            /*" -859- PERFORM M_030_PROCESSA_LOTERICO_DB_SELECT_6 */

            M_030_PROCESSA_LOTERICO_DB_SELECT_6();

            /*" -862- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -863- DISPLAY 'ERRO DE SELECT V0HISTSINI ..................' */
                _.Display($"ERRO DE SELECT V0HISTSINI ..................");

                /*" -864- DISPLAY 'NUM. SIN. = ' V0MEST-NUM-APOL-SINISTRO */
                _.Display($"NUM. SIN. = {V0MEST_NUM_APOL_SINISTRO}");

                /*" -866- GO TO 9999-ROT-ERRO. */

                M_9999_ROT_ERRO(); //GOTO
                return;
            }


            /*" -868- MOVE V0HIST-VAL-OPERACAO TO LD01-VL-REINTEG-MES-PER. */
            _.Move(V0HIST_VAL_OPERACAO, LD01.LD01_VL_REINTEG_MES_PER);

            /*" -870- MOVE '015' TO WNR-EXEC-SQL */
            _.Move("015", FILLER_97.WABEND.WNR_EXEC_SQL);

            /*" -881- PERFORM M_030_PROCESSA_LOTERICO_DB_SELECT_7 */

            M_030_PROCESSA_LOTERICO_DB_SELECT_7();

            /*" -884- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -885- DISPLAY 'ERRO DE SELECT V0HISTSINI ..................' */
                _.Display($"ERRO DE SELECT V0HISTSINI ..................");

                /*" -886- DISPLAY 'NUM. SIN. = ' V0MEST-NUM-APOL-SINISTRO */
                _.Display($"NUM. SIN. = {V0MEST_NUM_APOL_SINISTRO}");

                /*" -888- GO TO 9999-ROT-ERRO. */

                M_9999_ROT_ERRO(); //GOTO
                return;
            }


            /*" -890- MOVE V0HIST-VAL-OPERACAO TO LD01-VL-IOF-REINTEG-MES. */
            _.Move(V0HIST_VAL_OPERACAO, LD01.LD01_VL_IOF_REINTEG_MES);

            /*" -892- MOVE '016' TO WNR-EXEC-SQL */
            _.Move("016", FILLER_97.WABEND.WNR_EXEC_SQL);

            /*" -905- PERFORM M_030_PROCESSA_LOTERICO_DB_SELECT_8 */

            M_030_PROCESSA_LOTERICO_DB_SELECT_8();

            /*" -908- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -909- DISPLAY 'ERRO DE SELECT V0HISTSINI ..................' */
                _.Display($"ERRO DE SELECT V0HISTSINI ..................");

                /*" -910- DISPLAY 'NUM. SIN. = ' V0MEST-NUM-APOL-SINISTRO */
                _.Display($"NUM. SIN. = {V0MEST_NUM_APOL_SINISTRO}");

                /*" -912- GO TO 9999-ROT-ERRO. */

                M_9999_ROT_ERRO(); //GOTO
                return;
            }


            /*" -914- MOVE V0HIST-VAL-OPERACAO TO LD01-VL-IOF-REINTEG-MES-PER. */
            _.Move(V0HIST_VAL_OPERACAO, LD01.LD01_VL_IOF_REINTEG_MES_PER);

            /*" -916- MOVE '017' TO WNR-EXEC-SQL */
            _.Move("017", FILLER_97.WABEND.WNR_EXEC_SQL);

            /*" -927- PERFORM M_030_PROCESSA_LOTERICO_DB_SELECT_9 */

            M_030_PROCESSA_LOTERICO_DB_SELECT_9();

            /*" -930- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -931- DISPLAY 'ERRO DE SELECT V0HISTSINI ..................' */
                _.Display($"ERRO DE SELECT V0HISTSINI ..................");

                /*" -932- DISPLAY 'NUM. SIN. = ' V0MEST-NUM-APOL-SINISTRO */
                _.Display($"NUM. SIN. = {V0MEST_NUM_APOL_SINISTRO}");

                /*" -934- GO TO 9999-ROT-ERRO. */

                M_9999_ROT_ERRO(); //GOTO
                return;
            }


            /*" -936- MOVE V0HIST-VAL-OPERACAO TO LD01-VL-CORRECAO. */
            _.Move(V0HIST_VAL_OPERACAO, LD01.LD01_VL_CORRECAO);

            /*" -938- MOVE '018' TO WNR-EXEC-SQL */
            _.Move("018", FILLER_97.WABEND.WNR_EXEC_SQL);

            /*" -951- PERFORM M_030_PROCESSA_LOTERICO_DB_SELECT_10 */

            M_030_PROCESSA_LOTERICO_DB_SELECT_10();

            /*" -954- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -955- DISPLAY 'ERRO DE SELECT V0HISTSINI ..................' */
                _.Display($"ERRO DE SELECT V0HISTSINI ..................");

                /*" -956- DISPLAY 'NUM. SIN. = ' V0MEST-NUM-APOL-SINISTRO */
                _.Display($"NUM. SIN. = {V0MEST_NUM_APOL_SINISTRO}");

                /*" -958- GO TO 9999-ROT-ERRO. */

                M_9999_ROT_ERRO(); //GOTO
                return;
            }


            /*" -960- MOVE V0HIST-VAL-OPERACAO TO LD01-VL-CORRECAO-PER. */
            _.Move(V0HIST_VAL_OPERACAO, LD01.LD01_VL_CORRECAO_PER);

            /*" -962- MOVE '019' TO WNR-EXEC-SQL */
            _.Move("019", FILLER_97.WABEND.WNR_EXEC_SQL);

            /*" -973- PERFORM M_030_PROCESSA_LOTERICO_DB_SELECT_11 */

            M_030_PROCESSA_LOTERICO_DB_SELECT_11();

            /*" -976- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -977- DISPLAY 'ERRO DE SELECT V0HISTSINI ..................' */
                _.Display($"ERRO DE SELECT V0HISTSINI ..................");

                /*" -978- DISPLAY 'NUM. SIN. = ' V0MEST-NUM-APOL-SINISTRO */
                _.Display($"NUM. SIN. = {V0MEST_NUM_APOL_SINISTRO}");

                /*" -980- GO TO 9999-ROT-ERRO. */

                M_9999_ROT_ERRO(); //GOTO
                return;
            }


            /*" -982- MOVE V0HIST-VAL-OPERACAO TO LD01-VL-REINTEG-ANT. */
            _.Move(V0HIST_VAL_OPERACAO, LD01.LD01_VL_REINTEG_ANT);

            /*" -984- MOVE '020' TO WNR-EXEC-SQL */
            _.Move("020", FILLER_97.WABEND.WNR_EXEC_SQL);

            /*" -997- PERFORM M_030_PROCESSA_LOTERICO_DB_SELECT_12 */

            M_030_PROCESSA_LOTERICO_DB_SELECT_12();

            /*" -1000- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1001- DISPLAY 'ERRO DE SELECT V0HISTSINI ..................' */
                _.Display($"ERRO DE SELECT V0HISTSINI ..................");

                /*" -1002- DISPLAY 'NUM. SIN. = ' V0MEST-NUM-APOL-SINISTRO */
                _.Display($"NUM. SIN. = {V0MEST_NUM_APOL_SINISTRO}");

                /*" -1004- GO TO 9999-ROT-ERRO. */

                M_9999_ROT_ERRO(); //GOTO
                return;
            }


            /*" -1006- MOVE V0HIST-VAL-OPERACAO TO LD01-VL-REINTEG-ANT-PER. */
            _.Move(V0HIST_VAL_OPERACAO, LD01.LD01_VL_REINTEG_ANT_PER);

            /*" -1008- MOVE '021' TO WNR-EXEC-SQL */
            _.Move("021", FILLER_97.WABEND.WNR_EXEC_SQL);

            /*" -1019- PERFORM M_030_PROCESSA_LOTERICO_DB_SELECT_13 */

            M_030_PROCESSA_LOTERICO_DB_SELECT_13();

            /*" -1022- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1023- DISPLAY 'ERRO DE SELECT V0HISTSINI ..................' */
                _.Display($"ERRO DE SELECT V0HISTSINI ..................");

                /*" -1024- DISPLAY 'NUM. SIN. = ' V0MEST-NUM-APOL-SINISTRO */
                _.Display($"NUM. SIN. = {V0MEST_NUM_APOL_SINISTRO}");

                /*" -1026- GO TO 9999-ROT-ERRO. */

                M_9999_ROT_ERRO(); //GOTO
                return;
            }


            /*" -1028- MOVE V0HIST-VAL-OPERACAO TO LD01-VL-IOF-REINTEG-ANT. */
            _.Move(V0HIST_VAL_OPERACAO, LD01.LD01_VL_IOF_REINTEG_ANT);

            /*" -1030- MOVE '022' TO WNR-EXEC-SQL */
            _.Move("022", FILLER_97.WABEND.WNR_EXEC_SQL);

            /*" -1043- PERFORM M_030_PROCESSA_LOTERICO_DB_SELECT_14 */

            M_030_PROCESSA_LOTERICO_DB_SELECT_14();

            /*" -1046- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1047- DISPLAY 'ERRO DE SELECT V0HISTSINI ..................' */
                _.Display($"ERRO DE SELECT V0HISTSINI ..................");

                /*" -1048- DISPLAY 'NUM. SIN. = ' V0MEST-NUM-APOL-SINISTRO */
                _.Display($"NUM. SIN. = {V0MEST_NUM_APOL_SINISTRO}");

                /*" -1050- GO TO 9999-ROT-ERRO. */

                M_9999_ROT_ERRO(); //GOTO
                return;
            }


            /*" -1054- MOVE V0HIST-VAL-OPERACAO TO LD01-VL-IOF-REINTEG-ANT-PER. */
            _.Move(V0HIST_VAL_OPERACAO, LD01.LD01_VL_IOF_REINTEG_ANT_PER);

            /*" -1056- MOVE '023' TO WNR-EXEC-SQL */
            _.Move("023", FILLER_97.WABEND.WNR_EXEC_SQL);

            /*" -1058- INITIALIZE SI1001S-PARAMETROS. */
            _.Initialize(
                LBSI1001.SI1001S_PARAMETROS
            );

            /*" -1060- MOVE V0MEST-NUM-APOL-SINISTRO TO SI1001S-NUM-APOL-SINISTRO */
            _.Move(V0MEST_NUM_APOL_SINISTRO, LBSI1001.SI1001S_PARAMETROS.SI1001S_ENTRADA.SI1001S_NUM_APOL_SINISTRO);

            /*" -1062- CALL 'SI1002S' USING SI1001S-PARAMETROS */
            _.Call("SI1002S", LBSI1001.SI1001S_PARAMETROS);

            /*" -1063- IF SI1001S-ERRO-MENSAGEM NOT EQUAL SPACES */

            if (!LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_ERRO_MENSAGEM.IsEmpty())
            {

                /*" -1065- DISPLAY 'PROBLEMA CALL SI1002S ' ' ' V0MEST-NUM-APOL-SINISTRO */

                $"PROBLEMA CALL SI1002S  {V0MEST_NUM_APOL_SINISTRO}"
                .Display();

                /*" -1066- DISPLAY 'SQLCODE = ' SI1001S-ERRO-SQLCODE */
                _.Display($"SQLCODE = {LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_ERRO_SQLCODE}");

                /*" -1067- DISPLAY SI1001S-ERRO-MENSAGEM */
                _.Display(LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_ERRO_MENSAGEM);

                /*" -1068- GO TO 9999-ROT-ERRO */

                M_9999_ROT_ERRO(); //GOTO
                return;

                /*" -1069- ELSE */
            }
            else
            {


                /*" -1073- MOVE SI1001S-VALOR-CALCULADO TO LD01-VL-PAGO. */
                _.Move(LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_VALOR_CALCULADO, LD01.LD01_VL_PAGO);
            }


            /*" -1075- MOVE '024' TO WNR-EXEC-SQL */
            _.Move("024", FILLER_97.WABEND.WNR_EXEC_SQL);

            /*" -1077- INITIALIZE SI1001S-PARAMETROS. */
            _.Initialize(
                LBSI1001.SI1001S_PARAMETROS
            );

            /*" -1078- MOVE V0MEST-NUM-APOL-SINISTRO TO SI1001S-NUM-APOL-SINISTRO */
            _.Move(V0MEST_NUM_APOL_SINISTRO, LBSI1001.SI1001S_PARAMETROS.SI1001S_ENTRADA.SI1001S_NUM_APOL_SINISTRO);

            /*" -1079- MOVE V0REL-PERI-INICIAL TO SI1001S-DATA-INICIO */
            _.Move(V0REL_PERI_INICIAL, LBSI1001.SI1001S_PARAMETROS.SI1001S_ENTRADA.SI1001S_DATA_INICIO);

            /*" -1081- MOVE V0REL-PERI-FINAL TO SI1001S-DATA-FIM */
            _.Move(V0REL_PERI_FINAL, LBSI1001.SI1001S_PARAMETROS.SI1001S_ENTRADA.SI1001S_DATA_FIM);

            /*" -1083- CALL 'SI1002S' USING SI1001S-PARAMETROS */
            _.Call("SI1002S", LBSI1001.SI1001S_PARAMETROS);

            /*" -1084- IF SI1001S-ERRO-MENSAGEM NOT EQUAL SPACES */

            if (!LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_ERRO_MENSAGEM.IsEmpty())
            {

                /*" -1088- DISPLAY 'PROBLEMA CALL SI1002S ' ' ' V0MEST-NUM-APOL-SINISTRO ' ' V0REL-PERI-INICIAL ' ' V0REL-PERI-FINAL */

                $"PROBLEMA CALL SI1002S  {V0MEST_NUM_APOL_SINISTRO} {V0REL_PERI_INICIAL} {V0REL_PERI_FINAL}"
                .Display();

                /*" -1089- DISPLAY 'SQLCODE = ' SI1001S-ERRO-SQLCODE */
                _.Display($"SQLCODE = {LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_ERRO_SQLCODE}");

                /*" -1090- DISPLAY SI1001S-ERRO-MENSAGEM */
                _.Display(LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_ERRO_MENSAGEM);

                /*" -1091- GO TO 9999-ROT-ERRO */

                M_9999_ROT_ERRO(); //GOTO
                return;

                /*" -1092- ELSE */
            }
            else
            {


                /*" -1096- MOVE SI1001S-VALOR-CALCULADO TO LD01-VL-PAGO-PER. */
                _.Move(LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_VALOR_CALCULADO, LD01.LD01_VL_PAGO_PER);
            }


            /*" -1098- MOVE '024' TO WNR-EXEC-SQL */
            _.Move("024", FILLER_97.WABEND.WNR_EXEC_SQL);

            /*" -1100- INITIALIZE SI1001S-PARAMETROS. */
            _.Initialize(
                LBSI1001.SI1001S_PARAMETROS
            );

            /*" -1101- MOVE V0MEST-NUM-APOL-SINISTRO TO SI1001S-NUM-APOL-SINISTRO */
            _.Move(V0MEST_NUM_APOL_SINISTRO, LBSI1001.SI1001S_PARAMETROS.SI1001S_ENTRADA.SI1001S_NUM_APOL_SINISTRO);

            /*" -1103- MOVE V0REL-PERI-FINAL TO SI1001S-DATA-FIM */
            _.Move(V0REL_PERI_FINAL, LBSI1001.SI1001S_PARAMETROS.SI1001S_ENTRADA.SI1001S_DATA_FIM);

            /*" -1105- CALL 'SI1001S' USING SI1001S-PARAMETROS */
            _.Call("SI1001S", LBSI1001.SI1001S_PARAMETROS);

            /*" -1106- IF SI1001S-ERRO-MENSAGEM NOT EQUAL SPACES */

            if (!LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_ERRO_MENSAGEM.IsEmpty())
            {

                /*" -1109- DISPLAY 'PROBLEMA CALL SI1001S ' ' ' V0MEST-NUM-APOL-SINISTRO ' ' V0REL-PERI-FINAL */

                $"PROBLEMA CALL SI1001S  {V0MEST_NUM_APOL_SINISTRO} {V0REL_PERI_FINAL}"
                .Display();

                /*" -1110- DISPLAY 'SQLCODE = ' SI1001S-ERRO-SQLCODE */
                _.Display($"SQLCODE = {LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_ERRO_SQLCODE}");

                /*" -1111- DISPLAY SI1001S-ERRO-MENSAGEM */
                _.Display(LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_ERRO_MENSAGEM);

                /*" -1112- GO TO 9999-ROT-ERRO */

                M_9999_ROT_ERRO(); //GOTO
                return;

                /*" -1113- ELSE */
            }
            else
            {


                /*" -1115- MOVE SI1001S-VALOR-CALCULADO TO LD01-VL-PENDENTE. */
                _.Move(LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_VALOR_CALCULADO, LD01.LD01_VL_PENDENTE);
            }


            /*" -1116- WRITE REGISTRO-MOVTO FROM LD01. */
            _.Move(LD01.GetMoveValues(), REGISTRO_MOVTO);

            ARQMOV.Write(REGISTRO_MOVTO.GetMoveValues().ToString());

            /*" -1118- ADD 1 TO W-SINISTROS-GRAVADOS. */
            AREA_DE_WORK.W_SINISTROS_GRAVADOS.Value = AREA_DE_WORK.W_SINISTROS_GRAVADOS + 1;

            /*" -1118- PERFORM 010-FETCH-SINISTRO THRU 010-EXIT. */

            M_010_FETCH_SINISTRO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_010_EXIT*/


        }

        [StopWatch]
        /*" M-030-PROCESSA-LOTERICO-DB-SELECT-1 */
        public void M_030_PROCESSA_LOTERICO_DB_SELECT_1()
        {
            /*" -747- EXEC SQL SELECT VALUE(SUM(H.VAL_OPERACAO),0) INTO :V0HIST-VAL-OPERACAO FROM SEGUROS.V0HISTSINI H WHERE H.NUM_APOL_SINISTRO = :V0MEST-NUM-APOL-SINISTRO AND H.OPERACAO IN (1181,1182,1183,1184) AND H.SITUACAO <> '2' END-EXEC. */

            var m_030_PROCESSA_LOTERICO_DB_SELECT_1_Query1 = new M_030_PROCESSA_LOTERICO_DB_SELECT_1_Query1()
            {
                V0MEST_NUM_APOL_SINISTRO = V0MEST_NUM_APOL_SINISTRO.ToString(),
            };

            var executed_1 = M_030_PROCESSA_LOTERICO_DB_SELECT_1_Query1.Execute(m_030_PROCESSA_LOTERICO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0HIST_VAL_OPERACAO, V0HIST_VAL_OPERACAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_030_EXIT*/

        [StopWatch]
        /*" M-030-PROCESSA-LOTERICO-DB-SELECT-2 */
        public void M_030_PROCESSA_LOTERICO_DB_SELECT_2()
        {
            /*" -767- EXEC SQL SELECT VALUE(SUM(H.VAL_OPERACAO),0) INTO :V0HIST-VAL-OPERACAO FROM SEGUROS.V0HISTSINI H WHERE H.NUM_APOL_SINISTRO = :V0MEST-NUM-APOL-SINISTRO AND H.OPERACAO IN (1181,1182,1183,1184) AND H.SITUACAO <> '2' AND H.DTMOVTO BETWEEN :V0REL-PERI-INICIAL AND :V0REL-PERI-FINAL END-EXEC. */

            var m_030_PROCESSA_LOTERICO_DB_SELECT_2_Query1 = new M_030_PROCESSA_LOTERICO_DB_SELECT_2_Query1()
            {
                V0MEST_NUM_APOL_SINISTRO = V0MEST_NUM_APOL_SINISTRO.ToString(),
                V0REL_PERI_INICIAL = V0REL_PERI_INICIAL.ToString(),
                V0REL_PERI_FINAL = V0REL_PERI_FINAL.ToString(),
            };

            var executed_1 = M_030_PROCESSA_LOTERICO_DB_SELECT_2_Query1.Execute(m_030_PROCESSA_LOTERICO_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0HIST_VAL_OPERACAO, V0HIST_VAL_OPERACAO);
            }


        }

        [StopWatch]
        /*" M-100-SELECT-CANCELAMENTO */
        private void M_100_SELECT_CANCELAMENTO(bool isPerform = false)
        {
            /*" -1126- MOVE '025' TO WNR-EXEC-SQL */
            _.Move("025", FILLER_97.WABEND.WNR_EXEC_SQL);

            /*" -1132- PERFORM M_100_SELECT_CANCELAMENTO_DB_SELECT_1 */

            M_100_SELECT_CANCELAMENTO_DB_SELECT_1();

            /*" -1135- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1136- DISPLAY 'ERRO DE SELECT V0HISTSINI ..................' */
                _.Display($"ERRO DE SELECT V0HISTSINI ..................");

                /*" -1137- DISPLAY 'NUM. SIN. = ' V0MEST-NUM-APOL-SINISTRO */
                _.Display($"NUM. SIN. = {V0MEST_NUM_APOL_SINISTRO}");

                /*" -1137- GO TO 9999-ROT-ERRO. */

                M_9999_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-100-SELECT-CANCELAMENTO-DB-SELECT-1 */
        public void M_100_SELECT_CANCELAMENTO_DB_SELECT_1()
        {
            /*" -1132- EXEC SQL SELECT MAX(DTMOVTO) INTO :V0HIST-DTMOVTO FROM SEGUROS.V0HISTSINI WHERE NUM_APOL_SINISTRO = :V0MEST-NUM-APOL-SINISTRO AND OPERACAO IN (107,108,117,118) END-EXEC. */

            var m_100_SELECT_CANCELAMENTO_DB_SELECT_1_Query1 = new M_100_SELECT_CANCELAMENTO_DB_SELECT_1_Query1()
            {
                V0MEST_NUM_APOL_SINISTRO = V0MEST_NUM_APOL_SINISTRO.ToString(),
            };

            var executed_1 = M_100_SELECT_CANCELAMENTO_DB_SELECT_1_Query1.Execute(m_100_SELECT_CANCELAMENTO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0HIST_DTMOVTO, V0HIST_DTMOVTO);
            }


        }

        [StopWatch]
        /*" M-030-PROCESSA-LOTERICO-DB-SELECT-3 */
        public void M_030_PROCESSA_LOTERICO_DB_SELECT_3()
        {
            /*" -789- EXEC SQL SELECT VALUE(SUM(A.VAL_OPERACAO),0) INTO :V0HIST-VAL-OPERACAO FROM SEGUROS.V0HISTSINI H, SEGUROS.V0SINI_LOT_ABAT01 A WHERE H.NUM_APOL_SINISTRO = :V0MEST-NUM-APOL-SINISTRO AND H.OPERACAO IN (1001,1002,1003,1004,1009) AND H.SITUACAO <> '2' AND A.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO AND A.OCORHIST = H.OCORHIST AND A.COD_RETENCAO = '1' END-EXEC. */

            var m_030_PROCESSA_LOTERICO_DB_SELECT_3_Query1 = new M_030_PROCESSA_LOTERICO_DB_SELECT_3_Query1()
            {
                V0MEST_NUM_APOL_SINISTRO = V0MEST_NUM_APOL_SINISTRO.ToString(),
            };

            var executed_1 = M_030_PROCESSA_LOTERICO_DB_SELECT_3_Query1.Execute(m_030_PROCESSA_LOTERICO_DB_SELECT_3_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0HIST_VAL_OPERACAO, V0HIST_VAL_OPERACAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_100_EXIT*/

        [StopWatch]
        /*" M-030-PROCESSA-LOTERICO-DB-SELECT-4 */
        public void M_030_PROCESSA_LOTERICO_DB_SELECT_4()
        {
            /*" -813- EXEC SQL SELECT VALUE(SUM(A.VAL_OPERACAO),0) INTO :V0HIST-VAL-OPERACAO FROM SEGUROS.V0HISTSINI H, SEGUROS.V0SINI_LOT_ABAT01 A WHERE H.NUM_APOL_SINISTRO = :V0MEST-NUM-APOL-SINISTRO AND H.OPERACAO IN (1001,1002,1003,1004,1009) AND H.SITUACAO <> '2' AND A.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO AND A.OCORHIST = H.OCORHIST AND A.COD_RETENCAO = '1' AND H.DTMOVTO BETWEEN :V0REL-PERI-INICIAL AND :V0REL-PERI-FINAL END-EXEC. */

            var m_030_PROCESSA_LOTERICO_DB_SELECT_4_Query1 = new M_030_PROCESSA_LOTERICO_DB_SELECT_4_Query1()
            {
                V0MEST_NUM_APOL_SINISTRO = V0MEST_NUM_APOL_SINISTRO.ToString(),
                V0REL_PERI_INICIAL = V0REL_PERI_INICIAL.ToString(),
                V0REL_PERI_FINAL = V0REL_PERI_FINAL.ToString(),
            };

            var executed_1 = M_030_PROCESSA_LOTERICO_DB_SELECT_4_Query1.Execute(m_030_PROCESSA_LOTERICO_DB_SELECT_4_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0HIST_VAL_OPERACAO, V0HIST_VAL_OPERACAO);
            }


        }

        [StopWatch]
        /*" M-200-ATUALIZA-RELATORIO */
        private void M_200_ATUALIZA_RELATORIO(bool isPerform = false)
        {
            /*" -1145- MOVE '200' TO WNR-EXEC-SQL */
            _.Move("200", FILLER_97.WABEND.WNR_EXEC_SQL);

            /*" -1151- PERFORM M_200_ATUALIZA_RELATORIO_DB_UPDATE_1 */

            M_200_ATUALIZA_RELATORIO_DB_UPDATE_1();

            /*" -1154- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1155- DISPLAY 'ERRO DE UPDATE V0RELATORIOS ................' */
                _.Display($"ERRO DE UPDATE V0RELATORIOS ................");

                /*" -1156- GO TO 9999-ROT-ERRO */

                M_9999_ROT_ERRO(); //GOTO
                return;

                /*" -1156- END-IF. */
            }


        }

        [StopWatch]
        /*" M-200-ATUALIZA-RELATORIO-DB-UPDATE-1 */
        public void M_200_ATUALIZA_RELATORIO_DB_UPDATE_1()
        {
            /*" -1151- EXEC SQL UPDATE SEGUROS.V0RELATORIOS SET SITUACAO = '1' WHERE IDSISTEM = 'SI' AND CODRELAT = 'SI0851B' AND SITUACAO = '0' END-EXEC */

            var m_200_ATUALIZA_RELATORIO_DB_UPDATE_1_Update1 = new M_200_ATUALIZA_RELATORIO_DB_UPDATE_1_Update1()
            {
            };

            M_200_ATUALIZA_RELATORIO_DB_UPDATE_1_Update1.Execute(m_200_ATUALIZA_RELATORIO_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" M-030-PROCESSA-LOTERICO-DB-SELECT-5 */
        public void M_030_PROCESSA_LOTERICO_DB_SELECT_5()
        {
            /*" -835- EXEC SQL SELECT VALUE(SUM(A.VAL_OPERACAO),0) INTO :V0HIST-VAL-OPERACAO FROM SEGUROS.V0HISTSINI H, SEGUROS.V0SINI_LOT_ABAT01 A WHERE H.NUM_APOL_SINISTRO = :V0MEST-NUM-APOL-SINISTRO AND H.OPERACAO IN (1001,1002,1003,1004,1009) AND H.SITUACAO <> '2' AND A.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO AND A.OCORHIST = H.OCORHIST AND A.COD_RETENCAO = '2' END-EXEC. */

            var m_030_PROCESSA_LOTERICO_DB_SELECT_5_Query1 = new M_030_PROCESSA_LOTERICO_DB_SELECT_5_Query1()
            {
                V0MEST_NUM_APOL_SINISTRO = V0MEST_NUM_APOL_SINISTRO.ToString(),
            };

            var executed_1 = M_030_PROCESSA_LOTERICO_DB_SELECT_5_Query1.Execute(m_030_PROCESSA_LOTERICO_DB_SELECT_5_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0HIST_VAL_OPERACAO, V0HIST_VAL_OPERACAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_200_EXIT*/

        [StopWatch]
        /*" M-030-PROCESSA-LOTERICO-DB-SELECT-6 */
        public void M_030_PROCESSA_LOTERICO_DB_SELECT_6()
        {
            /*" -859- EXEC SQL SELECT VALUE(SUM(A.VAL_OPERACAO),0) INTO :V0HIST-VAL-OPERACAO FROM SEGUROS.V0HISTSINI H, SEGUROS.V0SINI_LOT_ABAT01 A WHERE H.NUM_APOL_SINISTRO = :V0MEST-NUM-APOL-SINISTRO AND H.OPERACAO IN (1001,1002,1003,1004,1009) AND H.SITUACAO <> '2' AND A.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO AND A.OCORHIST = H.OCORHIST AND A.COD_RETENCAO = '2' AND H.DTMOVTO BETWEEN :V0REL-PERI-INICIAL AND :V0REL-PERI-FINAL END-EXEC. */

            var m_030_PROCESSA_LOTERICO_DB_SELECT_6_Query1 = new M_030_PROCESSA_LOTERICO_DB_SELECT_6_Query1()
            {
                V0MEST_NUM_APOL_SINISTRO = V0MEST_NUM_APOL_SINISTRO.ToString(),
                V0REL_PERI_INICIAL = V0REL_PERI_INICIAL.ToString(),
                V0REL_PERI_FINAL = V0REL_PERI_FINAL.ToString(),
            };

            var executed_1 = M_030_PROCESSA_LOTERICO_DB_SELECT_6_Query1.Execute(m_030_PROCESSA_LOTERICO_DB_SELECT_6_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0HIST_VAL_OPERACAO, V0HIST_VAL_OPERACAO);
            }


        }

        [StopWatch]
        /*" M-300-PROCESSA-RELATORIO */
        private void M_300_PROCESSA_RELATORIO(bool isPerform = false)
        {
            /*" -1163- IF V0REL-NUM-APOLICE NOT EQUAL ZERO */

            if (V0REL_NUM_APOLICE != 00)
            {

                /*" -1164- MOVE V0REL-NUM-APOLICE TO LC00-APOLICE-R */
                _.Move(V0REL_NUM_APOLICE, LC02.LC00_APOLICE_R);

                /*" -1165- MOVE V0REL-NUM-APOLICE TO HOST-APOLICE-INICIAL */
                _.Move(V0REL_NUM_APOLICE, HOST_APOLICE_INICIAL);

                /*" -1166- MOVE V0REL-NUM-APOLICE TO HOST-APOLICE-FINAL */
                _.Move(V0REL_NUM_APOLICE, HOST_APOLICE_FINAL);

                /*" -1167- ELSE */
            }
            else
            {


                /*" -1168- MOVE 'TODAS' TO LC00-APOLICE */
                _.Move("TODAS", LC02.LC00_APOLICE);

                /*" -1169- MOVE 0107100000000 TO HOST-APOLICE-INICIAL */
                _.Move(0107100000000, HOST_APOLICE_INICIAL);

                /*" -1170- MOVE 0107199999999 TO HOST-APOLICE-FINAL */
                _.Move(0107199999999, HOST_APOLICE_FINAL);

                /*" -1172- END-IF */
            }


            /*" -1173- MOVE V0REL-PERI-INICIAL TO W-DATA1. */
            _.Move(V0REL_PERI_INICIAL, FILLER_97.W_DATA1);

            /*" -1174- MOVE W-DATA1-AAAA TO W-DATA2-AAAA. */
            _.Move(FILLER_97.W_DATA1.W_DATA1_AAAA, FILLER_97.W_DATA2.W_DATA2_AAAA);

            /*" -1175- MOVE W-DATA1-MM TO W-DATA2-MM. */
            _.Move(FILLER_97.W_DATA1.W_DATA1_MM, FILLER_97.W_DATA2.W_DATA2_MM);

            /*" -1176- MOVE W-DATA1-DD TO W-DATA2-DD. */
            _.Move(FILLER_97.W_DATA1.W_DATA1_DD, FILLER_97.W_DATA2.W_DATA2_DD);

            /*" -1178- MOVE W-DATA2 TO LC00-PERI-INICIAL. */
            _.Move(FILLER_97.W_DATA2, LC02.LC00_PERI_INICIAL);

            /*" -1179- MOVE V0REL-PERI-FINAL TO W-DATA1. */
            _.Move(V0REL_PERI_FINAL, FILLER_97.W_DATA1);

            /*" -1180- MOVE W-DATA1-AAAA TO W-DATA2-AAAA. */
            _.Move(FILLER_97.W_DATA1.W_DATA1_AAAA, FILLER_97.W_DATA2.W_DATA2_AAAA);

            /*" -1181- MOVE W-DATA1-MM TO W-DATA2-MM. */
            _.Move(FILLER_97.W_DATA1.W_DATA1_MM, FILLER_97.W_DATA2.W_DATA2_MM);

            /*" -1182- MOVE W-DATA1-DD TO W-DATA2-DD. */
            _.Move(FILLER_97.W_DATA1.W_DATA1_DD, FILLER_97.W_DATA2.W_DATA2_DD);

            /*" -1184- MOVE W-DATA2 TO LC00-PERI-FINAL. */
            _.Move(FILLER_97.W_DATA2, LC02.LC00_PERI_FINAL);

            /*" -1186- WRITE REGISTRO-MOVTO FROM LC02. */
            _.Move(LC02.GetMoveValues(), REGISTRO_MOVTO);

            ARQMOV.Write(REGISTRO_MOVTO.GetMoveValues().ToString());

            /*" -1187- PERFORM 009-DECLARE-LOTERICO THRU 009-EXIT. */

            M_009_DECLARE_LOTERICO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_009_EXIT*/


            /*" -1188- MOVE 'NAO' TO WFIM-LOTERICO. */
            _.Move("NAO", AREA_DE_WORK.WFIM_LOTERICO);

            /*" -1190- PERFORM 010-FETCH-SINISTRO THRU 010-EXIT. */

            M_010_FETCH_SINISTRO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_010_EXIT*/


            /*" -1191- IF WFIM-LOTERICO EQUAL 'SIM' */

            if (AREA_DE_WORK.WFIM_LOTERICO == "SIM")
            {

                /*" -1192- DISPLAY '*********************************************' */
                _.Display($"*********************************************");

                /*" -1193- DISPLAY '             PROGRAMA - SI0851B              ' */
                _.Display($"             PROGRAMA - SI0851B              ");

                /*" -1194- DISPLAY '                                             ' */
                _.Display($"                                             ");

                /*" -1195- DISPLAY ' GERACAO DO ARQ. DE MOVIMENTO DOS SINISTROS  ' */
                _.Display($" GERACAO DO ARQ. DE MOVIMENTO DOS SINISTROS  ");

                /*" -1196- DISPLAY ' COM REINTEGRACAO.                           ' */
                _.Display($" COM REINTEGRACAO.                           ");

                /*" -1197- DISPLAY ' ==> NAO HOUVE MOVIMENTO NA DATA DE HOJE     ' */
                _.Display($" ==> NAO HOUVE MOVIMENTO NA DATA DE HOJE     ");

                /*" -1198- DISPLAY ' APOLICE    : ' HOST-APOLICE-INICIAL */
                _.Display($" APOLICE    : {HOST_APOLICE_INICIAL}");

                /*" -1199- DISPLAY ' DT INICIAL : ' V0REL-PERI-INICIAL */
                _.Display($" DT INICIAL : {V0REL_PERI_INICIAL}");

                /*" -1200- DISPLAY ' DT FINAL   : ' V0REL-PERI-FINAL */
                _.Display($" DT FINAL   : {V0REL_PERI_FINAL}");

                /*" -1201- DISPLAY '                                             ' */
                _.Display($"                                             ");

                /*" -1202- DISPLAY '*********************************************' */
                _.Display($"*********************************************");

                /*" -1203- MOVE 'NENHUM REGISTRO SELECIONADO - PROBLEMA' TO LD01 */
                _.Move("NENHUM REGISTRO SELECIONADO - PROBLEMA", LD01);

                /*" -1204- WRITE REGISTRO-MOVTO FROM LD01 */
                _.Move(LD01.GetMoveValues(), REGISTRO_MOVTO);

                ARQMOV.Write(REGISTRO_MOVTO.GetMoveValues().ToString());

                /*" -1205- ELSE */
            }
            else
            {


                /*" -1207- WRITE REGISTRO-MOVTO FROM LC03 */
                _.Move(LC03.GetMoveValues(), REGISTRO_MOVTO);

                ARQMOV.Write(REGISTRO_MOVTO.GetMoveValues().ToString());

                /*" -1209- PERFORM 030-PROCESSA-LOTERICO THRU 030-EXIT UNTIL (WFIM-LOTERICO EQUAL 'SIM' ) */

                while (!((AREA_DE_WORK.WFIM_LOTERICO == "SIM")))
                {

                    M_030_PROCESSA_LOTERICO(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_030_EXIT*/

                }

                /*" -1211- END-IF */
            }


            /*" -1211- PERFORM 008-FETCH-RELATORIO. */

            M_008_FETCH_RELATORIO(true);

        }

        [StopWatch]
        /*" M-030-PROCESSA-LOTERICO-DB-SELECT-7 */
        public void M_030_PROCESSA_LOTERICO_DB_SELECT_7()
        {
            /*" -881- EXEC SQL SELECT VALUE(SUM(A.VAL_OPERACAO),0) INTO :V0HIST-VAL-OPERACAO FROM SEGUROS.V0HISTSINI H, SEGUROS.V0SINI_LOT_ABAT01 A WHERE H.NUM_APOL_SINISTRO = :V0MEST-NUM-APOL-SINISTRO AND H.OPERACAO IN (1001,1002,1003,1004,1009) AND H.SITUACAO <> '2' AND A.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO AND A.OCORHIST = H.OCORHIST AND A.COD_RETENCAO = '3' END-EXEC. */

            var m_030_PROCESSA_LOTERICO_DB_SELECT_7_Query1 = new M_030_PROCESSA_LOTERICO_DB_SELECT_7_Query1()
            {
                V0MEST_NUM_APOL_SINISTRO = V0MEST_NUM_APOL_SINISTRO.ToString(),
            };

            var executed_1 = M_030_PROCESSA_LOTERICO_DB_SELECT_7_Query1.Execute(m_030_PROCESSA_LOTERICO_DB_SELECT_7_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0HIST_VAL_OPERACAO, V0HIST_VAL_OPERACAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_300_EXIT*/

        [StopWatch]
        /*" M-030-PROCESSA-LOTERICO-DB-SELECT-8 */
        public void M_030_PROCESSA_LOTERICO_DB_SELECT_8()
        {
            /*" -905- EXEC SQL SELECT VALUE(SUM(A.VAL_OPERACAO),0) INTO :V0HIST-VAL-OPERACAO FROM SEGUROS.V0HISTSINI H, SEGUROS.V0SINI_LOT_ABAT01 A WHERE H.NUM_APOL_SINISTRO = :V0MEST-NUM-APOL-SINISTRO AND H.OPERACAO IN (1001,1002,1003,1004,1009) AND H.SITUACAO <> '2' AND A.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO AND A.OCORHIST = H.OCORHIST AND A.COD_RETENCAO = '3' AND H.DTMOVTO BETWEEN :V0REL-PERI-INICIAL AND :V0REL-PERI-FINAL END-EXEC. */

            var m_030_PROCESSA_LOTERICO_DB_SELECT_8_Query1 = new M_030_PROCESSA_LOTERICO_DB_SELECT_8_Query1()
            {
                V0MEST_NUM_APOL_SINISTRO = V0MEST_NUM_APOL_SINISTRO.ToString(),
                V0REL_PERI_INICIAL = V0REL_PERI_INICIAL.ToString(),
                V0REL_PERI_FINAL = V0REL_PERI_FINAL.ToString(),
            };

            var executed_1 = M_030_PROCESSA_LOTERICO_DB_SELECT_8_Query1.Execute(m_030_PROCESSA_LOTERICO_DB_SELECT_8_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0HIST_VAL_OPERACAO, V0HIST_VAL_OPERACAO);
            }


        }

        [StopWatch]
        /*" M-9999-ROT-ERRO */
        private void M_9999_ROT_ERRO(bool isPerform = false)
        {
            /*" -1221- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, FILLER_97.WABEND.WSQLCODE);

            /*" -1222- DISPLAY WABEND */
            _.Display(FILLER_97.WABEND);

            /*" -1223- CLOSE ARQMOV. */
            ARQMOV.Close();

            /*" -1223- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -1224- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -1226- MOVE 99 TO RETURN-CODE */
            _.Move(99, RETURN_CODE);

            /*" -1226- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" M-030-PROCESSA-LOTERICO-DB-SELECT-9 */
        public void M_030_PROCESSA_LOTERICO_DB_SELECT_9()
        {
            /*" -927- EXEC SQL SELECT VALUE(SUM(A.VAL_OPERACAO),0) INTO :V0HIST-VAL-OPERACAO FROM SEGUROS.V0HISTSINI H, SEGUROS.V0SINI_LOT_ABAT01 A WHERE H.NUM_APOL_SINISTRO = :V0MEST-NUM-APOL-SINISTRO AND H.OPERACAO IN (1001,1002,1003,1004,1009) AND H.SITUACAO <> '2' AND A.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO AND A.OCORHIST = H.OCORHIST AND A.COD_RETENCAO = '4' END-EXEC. */

            var m_030_PROCESSA_LOTERICO_DB_SELECT_9_Query1 = new M_030_PROCESSA_LOTERICO_DB_SELECT_9_Query1()
            {
                V0MEST_NUM_APOL_SINISTRO = V0MEST_NUM_APOL_SINISTRO.ToString(),
            };

            var executed_1 = M_030_PROCESSA_LOTERICO_DB_SELECT_9_Query1.Execute(m_030_PROCESSA_LOTERICO_DB_SELECT_9_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0HIST_VAL_OPERACAO, V0HIST_VAL_OPERACAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_9999_EXIT*/

        [StopWatch]
        /*" M-030-PROCESSA-LOTERICO-DB-SELECT-10 */
        public void M_030_PROCESSA_LOTERICO_DB_SELECT_10()
        {
            /*" -951- EXEC SQL SELECT VALUE(SUM(A.VAL_OPERACAO),0) INTO :V0HIST-VAL-OPERACAO FROM SEGUROS.V0HISTSINI H, SEGUROS.V0SINI_LOT_ABAT01 A WHERE H.NUM_APOL_SINISTRO = :V0MEST-NUM-APOL-SINISTRO AND H.OPERACAO IN (1001,1002,1003,1004,1009) AND H.SITUACAO <> '2' AND A.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO AND A.OCORHIST = H.OCORHIST AND A.COD_RETENCAO = '4' AND H.DTMOVTO BETWEEN :V0REL-PERI-INICIAL AND :V0REL-PERI-FINAL END-EXEC. */

            var m_030_PROCESSA_LOTERICO_DB_SELECT_10_Query1 = new M_030_PROCESSA_LOTERICO_DB_SELECT_10_Query1()
            {
                V0MEST_NUM_APOL_SINISTRO = V0MEST_NUM_APOL_SINISTRO.ToString(),
                V0REL_PERI_INICIAL = V0REL_PERI_INICIAL.ToString(),
                V0REL_PERI_FINAL = V0REL_PERI_FINAL.ToString(),
            };

            var executed_1 = M_030_PROCESSA_LOTERICO_DB_SELECT_10_Query1.Execute(m_030_PROCESSA_LOTERICO_DB_SELECT_10_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0HIST_VAL_OPERACAO, V0HIST_VAL_OPERACAO);
            }


        }

        [StopWatch]
        /*" M-030-PROCESSA-LOTERICO-DB-SELECT-11 */
        public void M_030_PROCESSA_LOTERICO_DB_SELECT_11()
        {
            /*" -973- EXEC SQL SELECT VALUE(SUM(A.VAL_OPERACAO),0) INTO :V0HIST-VAL-OPERACAO FROM SEGUROS.V0HISTSINI H, SEGUROS.V0SINI_LOT_ABAT01 A WHERE H.NUM_APOL_SINISTRO = :V0MEST-NUM-APOL-SINISTRO AND H.OPERACAO IN (1001,1002,1003,1004,1009) AND H.SITUACAO <> '2' AND A.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO AND A.OCORHIST = H.OCORHIST AND A.COD_RETENCAO = '5' END-EXEC. */

            var m_030_PROCESSA_LOTERICO_DB_SELECT_11_Query1 = new M_030_PROCESSA_LOTERICO_DB_SELECT_11_Query1()
            {
                V0MEST_NUM_APOL_SINISTRO = V0MEST_NUM_APOL_SINISTRO.ToString(),
            };

            var executed_1 = M_030_PROCESSA_LOTERICO_DB_SELECT_11_Query1.Execute(m_030_PROCESSA_LOTERICO_DB_SELECT_11_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0HIST_VAL_OPERACAO, V0HIST_VAL_OPERACAO);
            }


        }

        [StopWatch]
        /*" M-030-PROCESSA-LOTERICO-DB-SELECT-12 */
        public void M_030_PROCESSA_LOTERICO_DB_SELECT_12()
        {
            /*" -997- EXEC SQL SELECT VALUE(SUM(A.VAL_OPERACAO),0) INTO :V0HIST-VAL-OPERACAO FROM SEGUROS.V0HISTSINI H, SEGUROS.V0SINI_LOT_ABAT01 A WHERE H.NUM_APOL_SINISTRO = :V0MEST-NUM-APOL-SINISTRO AND H.OPERACAO IN (1001,1002,1003,1004,1009) AND H.SITUACAO <> '2' AND A.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO AND A.OCORHIST = H.OCORHIST AND A.COD_RETENCAO = '5' AND H.DTMOVTO BETWEEN :V0REL-PERI-INICIAL AND :V0REL-PERI-FINAL END-EXEC. */

            var m_030_PROCESSA_LOTERICO_DB_SELECT_12_Query1 = new M_030_PROCESSA_LOTERICO_DB_SELECT_12_Query1()
            {
                V0MEST_NUM_APOL_SINISTRO = V0MEST_NUM_APOL_SINISTRO.ToString(),
                V0REL_PERI_INICIAL = V0REL_PERI_INICIAL.ToString(),
                V0REL_PERI_FINAL = V0REL_PERI_FINAL.ToString(),
            };

            var executed_1 = M_030_PROCESSA_LOTERICO_DB_SELECT_12_Query1.Execute(m_030_PROCESSA_LOTERICO_DB_SELECT_12_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0HIST_VAL_OPERACAO, V0HIST_VAL_OPERACAO);
            }


        }

        [StopWatch]
        /*" M-030-PROCESSA-LOTERICO-DB-SELECT-13 */
        public void M_030_PROCESSA_LOTERICO_DB_SELECT_13()
        {
            /*" -1019- EXEC SQL SELECT VALUE(SUM(A.VAL_OPERACAO),0) INTO :V0HIST-VAL-OPERACAO FROM SEGUROS.V0HISTSINI H, SEGUROS.V0SINI_LOT_ABAT01 A WHERE H.NUM_APOL_SINISTRO = :V0MEST-NUM-APOL-SINISTRO AND H.OPERACAO IN (1001,1002,1003,1004,1009) AND H.SITUACAO <> '2' AND A.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO AND A.OCORHIST = H.OCORHIST AND A.COD_RETENCAO = '6' END-EXEC. */

            var m_030_PROCESSA_LOTERICO_DB_SELECT_13_Query1 = new M_030_PROCESSA_LOTERICO_DB_SELECT_13_Query1()
            {
                V0MEST_NUM_APOL_SINISTRO = V0MEST_NUM_APOL_SINISTRO.ToString(),
            };

            var executed_1 = M_030_PROCESSA_LOTERICO_DB_SELECT_13_Query1.Execute(m_030_PROCESSA_LOTERICO_DB_SELECT_13_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0HIST_VAL_OPERACAO, V0HIST_VAL_OPERACAO);
            }


        }

        [StopWatch]
        /*" M-030-PROCESSA-LOTERICO-DB-SELECT-14 */
        public void M_030_PROCESSA_LOTERICO_DB_SELECT_14()
        {
            /*" -1043- EXEC SQL SELECT VALUE(SUM(A.VAL_OPERACAO),0) INTO :V0HIST-VAL-OPERACAO FROM SEGUROS.V0HISTSINI H, SEGUROS.V0SINI_LOT_ABAT01 A WHERE H.NUM_APOL_SINISTRO = :V0MEST-NUM-APOL-SINISTRO AND H.OPERACAO IN (1001,1002,1003,1004,1009) AND H.SITUACAO <> '2' AND A.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO AND A.OCORHIST = H.OCORHIST AND A.COD_RETENCAO = '6' AND H.DTMOVTO BETWEEN :V0REL-PERI-INICIAL AND :V0REL-PERI-FINAL END-EXEC. */

            var m_030_PROCESSA_LOTERICO_DB_SELECT_14_Query1 = new M_030_PROCESSA_LOTERICO_DB_SELECT_14_Query1()
            {
                V0MEST_NUM_APOL_SINISTRO = V0MEST_NUM_APOL_SINISTRO.ToString(),
                V0REL_PERI_INICIAL = V0REL_PERI_INICIAL.ToString(),
                V0REL_PERI_FINAL = V0REL_PERI_FINAL.ToString(),
            };

            var executed_1 = M_030_PROCESSA_LOTERICO_DB_SELECT_14_Query1.Execute(m_030_PROCESSA_LOTERICO_DB_SELECT_14_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0HIST_VAL_OPERACAO, V0HIST_VAL_OPERACAO);
            }


        }
    }
}