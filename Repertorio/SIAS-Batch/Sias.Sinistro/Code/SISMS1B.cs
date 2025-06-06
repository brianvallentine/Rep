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
using Sias.Sinistro.DB2.SISMS1B;

namespace Code
{
    public class SISMS1B
    {
        public bool IsCall { get; set; }

        public SISMS1B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------                                 */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  SINISTRO / VIDA                    *      */
        /*"      *   PROGRAMA ...............  SISMS1B                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  DIPREV                             *      */
        /*"      *   PROGRAMADOR ............  THIAGO BATISTA / ALTRAN            *      */
        /*"      *   DATA CODIFICACAO .......  JANEIRO/2021                       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO ....... GERAR O ARQUIVO PARA ENVIO DE SMS PARA OS     *      */
        /*"      *       FAVORECIDOS DOS PAGAMENTOS DE INDENIZA��O DE SINISTRO           */
        /*"      *       QUANDO O RETORNO DO BANCO FOR COM SUCESSO                       */
        /*"      *                                                                       */
        /*"      *   JAZZ: 240648                                                        */
        /*"      *                                                                       */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        /*"      *   VERSAO 02 - TROCAR ACESSO DA SINISTRO_ITEM PELA              *      */
        /*"      *               SEGURADOS_VGAP                                   *      */
        /*"      *                                                                       */
        /*"      *    JAZZ: 240648                                                *      */
        /*"      *                                                                       */
        /*"      *    EM 08/02/2021 - THIAGO BARBOSA                                     */
        /*"      *                                        PROCURE POR  V02        *      */
        /*"      *----------------------------------------------------------------*      */
        #endregion


        #region VARIABLES

        public FileBasis _ARQSMSCS { get; set; } = new FileBasis(new PIC("X", "400", "X(400)"));

        public FileBasis ARQSMSCS
        {
            get
            {
                _.Move(REG_ARQSMSCS, _ARQSMSCS); VarBasis.RedefinePassValue(REG_ARQSMSCS, _ARQSMSCS, REG_ARQSMSCS); return _ARQSMSCS;
            }
        }
        public FileBasis _ARQMOVSS { get; set; } = new FileBasis(new PIC("X", "400", "X(400)"));

        public FileBasis ARQMOVSS
        {
            get
            {
                _.Move(REG_ARQMOVSS, _ARQMOVSS); VarBasis.RedefinePassValue(REG_ARQMOVSS, _ARQMOVSS, REG_ARQMOVSS); return _ARQMOVSS;
            }
        }
        /*"01        REG-ARQSMSCS        PIC  X(400).*/
        public StringBasis REG_ARQSMSCS { get; set; } = new StringBasis(new PIC("X", "400", "X(400)."), @"");
        /*"01        REG-ARQMOVSS       PIC  X(400).*/
        public StringBasis REG_ARQMOVSS { get; set; } = new StringBasis(new PIC("X", "400", "X(400)."), @"");

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77 WS-QT-REG-CAPA-LOTE            PIC S9(04) COMP VALUE +0.*/
        public IntBasis WS_QT_REG_CAPA_LOTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  HOST-DATA-CORRENTE          PIC X(10).*/
        public StringBasis HOST_DATA_CORRENTE { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  HOST-HORA-CORRENTE          PIC X(10).*/
        public StringBasis HOST_HORA_CORRENTE { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  WS-IND                      PIC S9(04) COMP    VALUE +0.*/
        public IntBasis WS_IND { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  WS-OCOR-ERRO                PIC S9(04) COMP    VALUE +0.*/
        public IntBasis WS_OCOR_ERRO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  IND-ERRO                    PIC S9(04) COMP    VALUE +0.*/
        public IntBasis IND_ERRO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  WS-CHAVE                    PIC  X(001)    VALUE SPACES.*/
        public StringBasis WS_CHAVE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"77  W-SALVA-OPERACAO-RETORNO    PIC S9(04) COMP    VALUE +0.*/
        public IntBasis W_SALVA_OPERACAO_RETORNO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  W-SALVA-OCORHIST-RETORNO    PIC S9(04) COMP    VALUE +0.*/
        public IntBasis W_SALVA_OCORHIST_RETORNO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  HOST-NSA                    PIC S9(04) COMP    VALUE +0.*/
        public IntBasis HOST_NSA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  IND-NULL1                   PIC S9(004)     COMP.*/
        public IntBasis IND_NULL1 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  IND-NULL2                   PIC S9(004)     COMP.*/
        public IntBasis IND_NULL2 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  IND-NULL3                   PIC S9(004)     COMP.*/
        public IntBasis IND_NULL3 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  IND-NULL4                   PIC S9(004)     COMP.*/
        public IntBasis IND_NULL4 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  IND-NULL5                   PIC S9(004)     COMP.*/
        public IntBasis IND_NULL5 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  IND-NULL10                  PIC S9(004)     COMP.*/
        public IntBasis IND_NULL10 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  IND-NULL11                  PIC S9(004)     COMP.*/
        public IntBasis IND_NULL11 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  IND-NULL12                  PIC S9(004)     COMP.*/
        public IntBasis IND_NULL12 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  IND-NULL13                  PIC S9(004)     COMP.*/
        public IntBasis IND_NULL13 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  IND-NULL14                  PIC S9(004)     COMP.*/
        public IntBasis IND_NULL14 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77 WIND-DATA-RETORNO            PIC S9(004) COMP.*/
        public IntBasis WIND_DATA_RETORNO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77 WIND-DATA-COMPENSACAO        PIC S9(004) COMP.*/
        public IntBasis WIND_DATA_COMPENSACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77 WIND-COD-RETORNO-CEF         PIC S9(004) COMP.*/
        public IntBasis WIND_COD_RETORNO_CEF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77 WIND-DTCREDITO               PIC S9(004) COMP.*/
        public IntBasis WIND_DTCREDITO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77 WIND-DIA-DEBITO              PIC S9(004) COMP.*/
        public IntBasis WIND_DIA_DEBITO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77 WIND-DATA-ENVIO              PIC S9(004) COMP.*/
        public IntBasis WIND_DATA_ENVIO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77 WIND-DATA-EMISSAO            PIC S9(004) COMP.*/
        public IntBasis WIND_DATA_EMISSAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77 WIND-COD-EMPRESA             PIC S9(004) COMP.*/
        public IntBasis WIND_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77 WIND-SIT-REGISTRO            PIC S9(004) COMP.*/
        public IntBasis WIND_SIT_REGISTRO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77 WIND-TIMESTAMP               PIC S9(004) COMP.*/
        public IntBasis WIND_TIMESTAMP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77 WIND-COD-FONTE               PIC S9(004) COMP.*/
        public IntBasis WIND_COD_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WPARM01-AUX                 PIC S9(09) COMP-3  VALUE +0.*/
        public IntBasis WPARM01_AUX { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77  WQUOCIENTE                  PIC S9(04) COMP-3  VALUE +0.*/
        public IntBasis WQUOCIENTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  WRESTO                      PIC S9(04) COMP-3  VALUE +0.*/
        public IntBasis WRESTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  W-SALVA-DATA-CREDITO        PIC  X(10).*/
        public StringBasis W_SALVA_DATA_CREDITO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  HOST-CHQINT                 PIC S9(09) COMP   VALUE +0.*/
        public IntBasis HOST_CHQINT { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"01  AREA-DE-WORK.*/
        public SISMS1B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new SISMS1B_AREA_DE_WORK();
        public class SISMS1B_AREA_DE_WORK : VarBasis
        {
            /*"    05 W-LIDOS-MOVDEBCC              PIC 9(09)    VALUE ZEROS.*/
            public IntBasis W_LIDOS_MOVDEBCC { get; set; } = new IntBasis(new PIC("9", "9", "9(09)"));
            /*"    05 W-GRAVADO-COM-SUCESSO         PIC 9(09)    VALUE ZEROS.*/
            public IntBasis W_GRAVADO_COM_SUCESSO { get; set; } = new IntBasis(new PIC("9", "9", "9(09)"));
            /*"    05 W-GRAVADO-SEM-SUCESSO         PIC 9(09)V99 VALUE ZEROS.*/
            public DoubleBasis W_GRAVADO_SEM_SUCESSO { get; set; } = new DoubleBasis(new PIC("9", "9", "9(09)V99"), 2);
            /*"    05 W-EDICAO                      PIC ZZZ.ZZZ.ZZ9,99-.*/
            public DoubleBasis W_EDICAO { get; set; } = new DoubleBasis(new PIC("9", "9", "ZZZ.ZZZ.ZZ9V99-."), 3);
            /*"    05 W-VALOR-TEMP                  PIC 9(13)V99 VALUE ZEROS.*/
            public DoubleBasis W_VALOR_TEMP { get; set; } = new DoubleBasis(new PIC("9", "13", "9(13)V99"), 2);
            /*"    05 W-ORIGEM                      PIC X(80)    VALUE ' '.*/
            public StringBasis W_ORIGEM { get; set; } = new StringBasis(new PIC("X", "80", "X(80)"), @" ");
            /*"    05 W-DATA-DD-MM-AAAA.*/
            public SISMS1B_W_DATA_DD_MM_AAAA W_DATA_DD_MM_AAAA { get; set; } = new SISMS1B_W_DATA_DD_MM_AAAA();
            public class SISMS1B_W_DATA_DD_MM_AAAA : VarBasis
            {
                /*"       10 W-DATA-DD-MM-AAAA-DD       PIC 9(02)       VALUE ZEROS*/
                public IntBasis W_DATA_DD_MM_AAAA_DD { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"       10 W-DATA-DD-MM-AAAA-F1       PIC X(01)       VALUE '/'.*/
                public StringBasis W_DATA_DD_MM_AAAA_F1 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"/");
                /*"       10 W-DATA-DD-MM-AAAA-MM       PIC 9(02)       VALUE ZEROS*/
                public IntBasis W_DATA_DD_MM_AAAA_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"       10 W-DATA-DD-MM-AAAA-F2       PIC X(01)       VALUE '/'.*/
                public StringBasis W_DATA_DD_MM_AAAA_F2 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"/");
                /*"       10 W-DATA-DD-MM-AAAA-AAAA     PIC 9(04)       VALUE ZEROS*/
                public IntBasis W_DATA_DD_MM_AAAA_AAAA { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
                /*"    05 W-DATA-AAAA-MM-DD.*/
            }
            public SISMS1B_W_DATA_AAAA_MM_DD W_DATA_AAAA_MM_DD { get; set; } = new SISMS1B_W_DATA_AAAA_MM_DD();
            public class SISMS1B_W_DATA_AAAA_MM_DD : VarBasis
            {
                /*"       10 W-DATA-AAAA-MM-DD-AAAA     PIC 9(04)       VALUE ZEROS*/
                public IntBasis W_DATA_AAAA_MM_DD_AAAA { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
                /*"       10 W-DATA-AAAA-MM-DD-F1       PIC X(01)       VALUE '-'.*/
                public StringBasis W_DATA_AAAA_MM_DD_F1 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
                /*"       10 W-DATA-AAAA-MM-DD-MM       PIC 9(02)       VALUE ZEROS*/
                public IntBasis W_DATA_AAAA_MM_DD_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"       10 W-DATA-AAAA-MM-DD-F2       PIC X(01)       VALUE '-'.*/
                public StringBasis W_DATA_AAAA_MM_DD_F2 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
                /*"       10 W-DATA-AAAA-MM-DD-DD       PIC 9(02)       VALUE ZEROS*/
                public IntBasis W_DATA_AAAA_MM_DD_DD { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"    05 W-NUM-CPF.*/
            }
            public SISMS1B_W_NUM_CPF W_NUM_CPF { get; set; } = new SISMS1B_W_NUM_CPF();
            public class SISMS1B_W_NUM_CPF : VarBasis
            {
                /*"       10 W-NUM-CPF-NUM              PIC 9(09)  VALUE ZEROS.*/
                public IntBasis W_NUM_CPF_NUM { get; set; } = new IntBasis(new PIC("9", "9", "9(09)"));
                /*"       10 W-NUM-CPF-DV               PIC 9(02)  VALUE ZEROS.*/
                public IntBasis W_NUM_CPF_DV { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"    05 W-CHAVE-FIM-MOVDEBCC          PIC X(03)  VALUE SPACES.*/
            }
            public StringBasis W_CHAVE_FIM_MOVDEBCC { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"");
            /*"    05 W-CHAVE-FIM-TELEFONE          PIC X(03)  VALUE SPACES.*/
            public StringBasis W_CHAVE_FIM_TELEFONE { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"");
            /*"    05 W-CHAVE-ACHOU-TEL-CELULAR     PIC X(03)  VALUE SPACES.*/
            public StringBasis W_CHAVE_ACHOU_TEL_CELULAR { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"");
            /*"    05 W-REGISTRO-SMS-LC01.*/
            public SISMS1B_W_REGISTRO_SMS_LC01 W_REGISTRO_SMS_LC01 { get; set; } = new SISMS1B_W_REGISTRO_SMS_LC01();
            public class SISMS1B_W_REGISTRO_SMS_LC01 : VarBasis
            {
                /*"       10 FILLER                 PIC  X(14) VALUE                                 'CPF-RECLAMANTE'.*/
                public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "14", "X(14)"), @"CPF_RECLAMANTE");
                /*"       10 FILLER                 PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 FILLER                 PIC  X(08) VALUE                                 'SEGURADO'.*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"SEGURADO");
                /*"       10 FILLER                 PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 FILLER                 PIC  X(12) VALUE                                 'CPF-SEGURADO'.*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"CPF_SEGURADO");
                /*"       10 FILLER                 PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 FILLER                 PIC  X(07) VALUE                                 'APOLICE'.*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "7", "X(07)"), @"APOLICE");
                /*"       10 FILLER                 PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 FILLER                 PIC  X(11) VALUE                                 'CERTIFICADO'.*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "11", "X(11)"), @"CERTIFICADO");
                /*"       10 FILLER                 PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 FILLER                 PIC  X(09) VALUE                                 'PROTOCOLO'.*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "9", "X(09)"), @"PROTOCOLO");
                /*"       10 FILLER                 PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 FILLER                 PIC  X(08) VALUE                                 'SINISTRO'.*/
                public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"SINISTRO");
                /*"       10 FILLER                 PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 FILLER                 PIC  X(10) VALUE                                 'RECLAMANTE'.*/
                public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"RECLAMANTE");
                /*"       10 FILLER                 PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 FILLER                 PIC  X(11) VALUE                                 'DDD-CELULAR'.*/
                public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "11", "X(11)"), @"DDD_CELULAR");
                /*"       10 FILLER                 PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 FILLER                 PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 FILLER                 PIC  X(13) VALUE                                 'DATA-OPERACAO'.*/
                public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "13", "X(13)"), @"DATA_OPERACAO");
                /*"       10 FILLER                 PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 FILLER                 PIC  X(05) VALUE                                 'EMAIL'.*/
                public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "5", "X(05)"), @"EMAIL");
                /*"       10 FILLER                 PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 FILLER                 PIC  X(08) VALUE                                 'OPERACAO'.*/
                public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"OPERACAO");
                /*"       10 FILLER                 PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 FILLER                 PIC  X(14) VALUE                                 'DATA-MOVIMENTO'.*/
                public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "14", "X(14)"), @"DATA_MOVIMENTO");
                /*"    05 W-REGISTRO-SMS.*/
            }
            public SISMS1B_W_REGISTRO_SMS W_REGISTRO_SMS { get; set; } = new SISMS1B_W_REGISTRO_SMS();
            public class SISMS1B_W_REGISTRO_SMS : VarBasis
            {
                /*"       10 W-SMS-CPF-FAVORECIDO       PIC  9(11)  VALUE ZEROS.*/
                public IntBasis W_SMS_CPF_FAVORECIDO { get; set; } = new IntBasis(new PIC("9", "11", "9(11)"));
                /*"       10 FILLER                     PIC  X(01)  VALUE ';'.*/
                public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 W-SMS-NOME-SEGURADO        PIC  X(40)  VALUE ' '.*/
                public StringBasis W_SMS_NOME_SEGURADO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @" ");
                /*"       10 FILLER                     PIC  X(01)  VALUE ';'.*/
                public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 W-SMS-CPF-SEGURADO         PIC  9(11)  VALUE ZEROS.*/
                public IntBasis W_SMS_CPF_SEGURADO { get; set; } = new IntBasis(new PIC("9", "11", "9(11)"));
                /*"       10 FILLER                     PIC  X(01)  VALUE ';'.*/
                public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 W-SMS-NUM-APOLICE          PIC  9(13)  VALUE ZEROS.*/
                public IntBasis W_SMS_NUM_APOLICE { get; set; } = new IntBasis(new PIC("9", "13", "9(13)"));
                /*"       10 FILLER                     PIC  X(01)  VALUE ';'.*/
                public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 W-SMS-NUM-CERTIFICADO      PIC  9(19)  VALUE ZEROS.*/
                public IntBasis W_SMS_NUM_CERTIFICADO { get; set; } = new IntBasis(new PIC("9", "19", "9(19)"));
                /*"       10 FILLER                     PIC  X(01)  VALUE ';'.*/
                public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 W-SMS-NUM-PROTOCOLO        PIC  9(07)  VALUE ZEROS.*/
                public IntBasis W_SMS_NUM_PROTOCOLO { get; set; } = new IntBasis(new PIC("9", "7", "9(07)"));
                /*"       10 FILLER                     PIC  X(01)  VALUE ';'.*/
                public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 W-SMS-NUM-SINISTRO         PIC  9(13)  VALUE ZEROS.*/
                public IntBasis W_SMS_NUM_SINISTRO { get; set; } = new IntBasis(new PIC("9", "13", "9(13)"));
                /*"       10 FILLER                     PIC  X(01)  VALUE ';'.*/
                public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 W-SMS-NOME-RECLAMANTE      PIC  X(40)  VALUE ALL 'X'.*/
                public StringBasis W_SMS_NOME_RECLAMANTE { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"ALL");
                /*"       10 FILLER                     PIC  X(01)  VALUE ';'.*/
                public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 W-SMS-DDD-CEL-FAVORECIDO   PIC  9(02)  VALUE 0.*/
                public IntBasis W_SMS_DDD_CEL_FAVORECIDO { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"       10 W-SMS-CEL-FAVORECIDO       PIC  9(09)  VALUE 0.*/
                public IntBasis W_SMS_CEL_FAVORECIDO { get; set; } = new IntBasis(new PIC("9", "9", "9(09)"));
                /*"       10 FILLER                     PIC  X(01)  VALUE ';'.*/
                public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 W-SMS-DATA-MOV-RETORNO     PIC  X(10)  VALUE ' '.*/
                public StringBasis W_SMS_DATA_MOV_RETORNO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @" ");
                /*"       10 FILLER                     PIC  X(01)  VALUE ';'.*/
                public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 W-SMS-EMAIL-FAVORECIDO     PIC  X(40)  VALUE ALL 'X'.*/
                public StringBasis W_SMS_EMAIL_FAVORECIDO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"ALL");
                /*"       10 FILLER                     PIC  X(01)  VALUE ';'.*/
                public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 W-SMS-OPERACAO             PIC  X(08)  VALUE ALL 'X'.*/
                public StringBasis W_SMS_OPERACAO { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"ALL");
                /*"       10 FILLER                     PIC  X(01)  VALUE ';'.*/
                public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 W-SMS-DATA-SISTEMA         PIC  X(10)  VALUE ' '.*/
                public StringBasis W_SMS_DATA_SISTEMA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @" ");
                /*"    05 W-REGISTRO-ERRO-LC01.*/
            }
            public SISMS1B_W_REGISTRO_ERRO_LC01 W_REGISTRO_ERRO_LC01 { get; set; } = new SISMS1B_W_REGISTRO_ERRO_LC01();
            public class SISMS1B_W_REGISTRO_ERRO_LC01 : VarBasis
            {
                /*"       10 FILLER                 PIC  X(05) VALUE                                 'FONTE'.*/
                public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "5", "X(05)"), @"FONTE");
                /*"       10 FILLER                 PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 FILLER                 PIC  X(09) VALUE                                 'PROTOCOLO'.*/
                public StringBasis FILLER_40 { get; set; } = new StringBasis(new PIC("X", "9", "X(09)"), @"PROTOCOLO");
                /*"       10 FILLER                 PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 FILLER                 PIC  X(03) VALUE                                 'DAC'.*/
                public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"DAC");
                /*"       10 FILLER                 PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_43 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 FILLER                 PIC  X(11) VALUE                                 'NUM-COD-GCS'.*/
                public StringBasis FILLER_44 { get; set; } = new StringBasis(new PIC("X", "11", "X(11)"), @"NUM-COD-GCS");
                /*"       10 FILLER                 PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_45 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 FILLER                 PIC  X(13) VALUE                                 'NOME-SEGURADO'.*/
                public StringBasis FILLER_46 { get; set; } = new StringBasis(new PIC("X", "13", "X(13)"), @"NOME-SEGURADO");
                /*"       10 FILLER                 PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_47 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 FILLER                 PIC  X(12) VALUE                                 'CPF-SEGURADO'.*/
                public StringBasis FILLER_48 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"CPF-SEGURADO");
                /*"       10 FILLER                 PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_49 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 FILLER                 PIC  X(11) VALUE                                 'NUM-APOLICE'.*/
                public StringBasis FILLER_50 { get; set; } = new StringBasis(new PIC("X", "11", "X(11)"), @"NUM-APOLICE");
                /*"       10 FILLER                 PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_51 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 FILLER                 PIC  X(15) VALUE                                 'NUM-CERTIFICADO'.*/
                public StringBasis FILLER_52 { get; set; } = new StringBasis(new PIC("X", "15", "X(15)"), @"NUM-CERTIFICADO");
                /*"       10 FILLER                 PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_53 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 FILLER                 PIC  X(12) VALUE                                 'NUM-SINISTRO'.*/
                public StringBasis FILLER_54 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"NUM-SINISTRO");
                /*"       10 FILLER                 PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_55 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 FILLER                 PIC  X(14) VALUE                                 'NOM-RECLAMANTE'.*/
                public StringBasis FILLER_56 { get; set; } = new StringBasis(new PIC("X", "14", "X(14)"), @"NOM-RECLAMANTE");
                /*"       10 FILLER                 PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_57 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 FILLER                 PIC  X(02) VALUE                                 'DD'.*/
                public StringBasis FILLER_58 { get; set; } = new StringBasis(new PIC("X", "2", "X(02)"), @"DD");
                /*"       10 FILLER                 PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_59 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 FILLER                 PIC  X(07) VALUE                                 'CELULAR'.*/
                public StringBasis FILLER_60 { get; set; } = new StringBasis(new PIC("X", "7", "X(07)"), @"CELULAR");
                /*"       10 FILLER                 PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_61 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 FILLER                 PIC  X(10) VALUE                                 'DATA-GERAC'.*/
                public StringBasis FILLER_62 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"DATA-GERAC");
                /*"       10 FILLER                 PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_63 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 FILLER                 PIC  X(05) VALUE                                 'PRODU'.*/
                public StringBasis FILLER_64 { get; set; } = new StringBasis(new PIC("X", "5", "X(05)"), @"PRODU");
                /*"       10 FILLER                 PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_65 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 FILLER                 PIC  X(08) VALUE                                 'MENSAGEM'.*/
                public StringBasis FILLER_66 { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"MENSAGEM");
                /*"       10 FILLER                 PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_67 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 FILLER                 PIC  X(08) VALUE                                 'OPERACAO'.*/
                public StringBasis FILLER_68 { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"OPERACAO");
                /*"    05 W-REGISTRO-ERRO.*/
            }
            public SISMS1B_W_REGISTRO_ERRO W_REGISTRO_ERRO { get; set; } = new SISMS1B_W_REGISTRO_ERRO();
            public class SISMS1B_W_REGISTRO_ERRO : VarBasis
            {
                /*"       10 W-ERRO-FONTE               PIC  9(03)  VALUE ZEROS.*/
                public IntBasis W_ERRO_FONTE { get; set; } = new IntBasis(new PIC("9", "3", "9(03)"));
                /*"       10 FILLER                     PIC  X(01)  VALUE ';'.*/
                public StringBasis FILLER_69 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 W-ERRO-PROTOCOLO           PIC  9(07)  VALUE ZEROS.*/
                public IntBasis W_ERRO_PROTOCOLO { get; set; } = new IntBasis(new PIC("9", "7", "9(07)"));
                /*"       10 FILLER                     PIC  X(01)  VALUE ';'.*/
                public StringBasis FILLER_70 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 W-ERRO-DAC                 PIC  9(02)  VALUE ZEROS.*/
                public IntBasis W_ERRO_DAC { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"       10 FILLER                     PIC  X(01)  VALUE ';'.*/
                public StringBasis FILLER_71 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 W-ERRO-NUM-COD-GCS         PIC  9(11)  VALUE ZEROS.*/
                public IntBasis W_ERRO_NUM_COD_GCS { get; set; } = new IntBasis(new PIC("9", "11", "9(11)"));
                /*"       10 FILLER                     PIC  X(01)  VALUE ';'.*/
                public StringBasis FILLER_72 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 W-ERRO-NOME-SEGURADO       PIC  X(40)  VALUE ALL 'W'.*/
                public StringBasis W_ERRO_NOME_SEGURADO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"ALL");
                /*"       10 FILLER                     PIC  X(01)  VALUE ';'.*/
                public StringBasis FILLER_73 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 W-ERRO-CPF-SEGURADO        PIC  9(11)  VALUE 0.*/
                public IntBasis W_ERRO_CPF_SEGURADO { get; set; } = new IntBasis(new PIC("9", "11", "9(11)"));
                /*"       10 FILLER                     PIC  X(01)  VALUE ';'.*/
                public StringBasis FILLER_74 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 W-ERRO-APOLICE             PIC  9(13)  VALUE 0.*/
                public IntBasis W_ERRO_APOLICE { get; set; } = new IntBasis(new PIC("9", "13", "9(13)"));
                /*"       10 FILLER                     PIC  X(01)  VALUE ';'.*/
                public StringBasis FILLER_75 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 W-ERRO-CERTIFICADO         PIC  9(15)  VALUE 0.*/
                public IntBasis W_ERRO_CERTIFICADO { get; set; } = new IntBasis(new PIC("9", "15", "9(15)"));
                /*"       10 FILLER                     PIC  X(01)  VALUE ';'.*/
                public StringBasis FILLER_76 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 W-ERRO-SINISTRO            PIC  9(13)  VALUE 0.*/
                public IntBasis W_ERRO_SINISTRO { get; set; } = new IntBasis(new PIC("9", "13", "9(13)"));
                /*"       10 FILLER                     PIC  X(01)  VALUE ';'.*/
                public StringBasis FILLER_77 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 W-ERRO-NOME-RECLAMANTE     PIC  X(40)  VALUE ' '.*/
                public StringBasis W_ERRO_NOME_RECLAMANTE { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @" ");
                /*"       10 FILLER                     PIC  X(01)  VALUE ';'.*/
                public StringBasis FILLER_78 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 W-ERRO-DDD                 PIC  9(02)  VALUE 0.*/
                public IntBasis W_ERRO_DDD { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"       10 FILLER                     PIC  X(01)  VALUE ';'.*/
                public StringBasis FILLER_79 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 W-ERRO-CELULAR             PIC  9(09)  VALUE 0.*/
                public IntBasis W_ERRO_CELULAR { get; set; } = new IntBasis(new PIC("9", "9", "9(09)"));
                /*"       10 FILLER                     PIC  X(01)  VALUE ';'.*/
                public StringBasis FILLER_80 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 W-ERRO-DATA-GERACAO        PIC  X(10)  VALUE ' '.*/
                public StringBasis W_ERRO_DATA_GERACAO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @" ");
                /*"       10 FILLER                     PIC  X(01)  VALUE ';'.*/
                public StringBasis FILLER_81 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 W-ERRO-PRODUTO             PIC  9(04)  VALUE 0.*/
                public IntBasis W_ERRO_PRODUTO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
                /*"       10 FILLER                     PIC  X(01)  VALUE ';'.*/
                public StringBasis FILLER_82 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 W-ERRO-MENSAGEM            PIC  X(150) VALUE SPACES.*/
                public StringBasis W_ERRO_MENSAGEM { get; set; } = new StringBasis(new PIC("X", "150", "X(150)"), @"");
                /*"       10 FILLER                     PIC  X(01)  VALUE ';'.*/
                public StringBasis FILLER_83 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 W-ERRO-OPERACAO            PIC  X(08) VALUE SPACES.*/
                public StringBasis W_ERRO_OPERACAO { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
                /*"    05 W-TELEFONE-NUMERICO           PIC 9(10).*/
            }
            public IntBasis W_TELEFONE_NUMERICO { get; set; } = new IntBasis(new PIC("9", "10", "9(10)."));
            /*"    05 W-TELEFONE-ALFA  REDEFINES  W-TELEFONE-NUMERICO.*/
            private _REDEF_SISMS1B_W_TELEFONE_ALFA _w_telefone_alfa { get; set; }
            public _REDEF_SISMS1B_W_TELEFONE_ALFA W_TELEFONE_ALFA
            {
                get { _w_telefone_alfa = new _REDEF_SISMS1B_W_TELEFONE_ALFA(); _.Move(W_TELEFONE_NUMERICO, _w_telefone_alfa); VarBasis.RedefinePassValue(W_TELEFONE_NUMERICO, _w_telefone_alfa, W_TELEFONE_NUMERICO); _w_telefone_alfa.ValueChanged += () => { _.Move(_w_telefone_alfa, W_TELEFONE_NUMERICO); }; return _w_telefone_alfa; }
                set { VarBasis.RedefinePassValue(value, _w_telefone_alfa, W_TELEFONE_NUMERICO); }
            }  //Redefines
            public class _REDEF_SISMS1B_W_TELEFONE_ALFA : VarBasis
            {
                /*"       10 W-TELEFONE-BASE-DIGITO     PIC X(01) OCCURS 10 TIMES.*/
                public ListBasis<StringBasis, string> W_TELEFONE_BASE_DIGITO { get; set; } = new ListBasis<StringBasis, string>(new PIC("X", "1", "X(01)"), 10);
                /*"    05 W-TELEFONE-SMS.*/

                public _REDEF_SISMS1B_W_TELEFONE_ALFA()
                {
                    W_TELEFONE_BASE_DIGITO.ValueChanged += OnValueChanged;
                }

            }
            public SISMS1B_W_TELEFONE_SMS W_TELEFONE_SMS { get; set; } = new SISMS1B_W_TELEFONE_SMS();
            public class SISMS1B_W_TELEFONE_SMS : VarBasis
            {
                /*"       10 W-TELEFONE-SMS-DIGITO      PIC X(01) OCCURS 9 TIMES.*/
                public ListBasis<StringBasis, string> W_TELEFONE_SMS_DIGITO { get; set; } = new ListBasis<StringBasis, string>(new PIC("X", "1", "X(01)"), 9);
                /*"    05 W-IND-TEL-ALFA                PIC 9(01) VALUE ZEROS.*/
            }
            public IntBasis W_IND_TEL_ALFA { get; set; } = new IntBasis(new PIC("9", "1", "9(01)"));
            /*"    05 W-IND-TEL-SMS                 PIC 9(01) VALUE ZEROS.*/
            public IntBasis W_IND_TEL_SMS { get; set; } = new IntBasis(new PIC("9", "1", "9(01)"));
            /*"    05 WABEND.*/
            public SISMS1B_WABEND WABEND { get; set; } = new SISMS1B_WABEND();
            public class SISMS1B_WABEND : VarBasis
            {
                /*"       07 WABEND1.*/
                public SISMS1B_WABEND1 WABEND1 { get; set; } = new SISMS1B_WABEND1();
                public class SISMS1B_WABEND1 : VarBasis
                {
                    /*"       10 FILLER         PIC  X(008)      VALUE          'SISMS1B '.*/
                    public StringBasis FILLER_84 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"SISMS1B ");
                    /*"       07 WABEND2.*/
                    public SISMS1B_WABEND2 WABEND2 { get; set; } = new SISMS1B_WABEND2();
                    public class SISMS1B_WABEND2 : VarBasis
                    {
                        /*"       10 FILLER         PIC  X(025)      VALUE          '*** ERRO EXEC SQL NUMERO '.*/
                        public StringBasis FILLER_85 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"*** ERRO EXEC SQL NUMERO ");
                        /*"       10 WNR-EXEC-SQL   PIC  X(004)      VALUE   '0000'.*/
                        public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"0000");
                        /*"       07 WABEND3.*/
                        public SISMS1B_WABEND3 WABEND3 { get; set; } = new SISMS1B_WABEND3();
                        public class SISMS1B_WABEND3 : VarBasis
                        {
                            /*"       10 FILLER         PIC  X(013)      VALUE          '*** SQLCODE '.*/
                            public StringBasis FILLER_86 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"*** SQLCODE ");
                            /*"       10 WSQLCODE       PIC  ZZZZZ999-   VALUE    ZEROS.*/
                            public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                        }
                    }
                }
            }
        }


        public Dclgens.CLIENTES CLIENTES { get; set; } = new Dclgens.CLIENTES();
        public Dclgens.GE369 GE369 { get; set; } = new Dclgens.GE369();
        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.MOVDEBCE MOVDEBCE { get; set; } = new Dclgens.MOVDEBCE();
        public Dclgens.SINISHIS SINISHIS { get; set; } = new Dclgens.SINISHIS();
        public Dclgens.SINISMES SINISMES { get; set; } = new Dclgens.SINISMES();
        public Dclgens.OD001 OD001 { get; set; } = new Dclgens.OD001();
        public Dclgens.OD002 OD002 { get; set; } = new Dclgens.OD002();
        public Dclgens.OD004 OD004 { get; set; } = new Dclgens.OD004();
        public Dclgens.OD005 OD005 { get; set; } = new Dclgens.OD005();
        public Dclgens.OD003 OD003 { get; set; } = new Dclgens.OD003();
        public Dclgens.EMPRESAS EMPRESAS { get; set; } = new Dclgens.EMPRESAS();
        public Dclgens.PRODUTO PRODUTO { get; set; } = new Dclgens.PRODUTO();
        public Dclgens.GE366 GE366 { get; set; } = new Dclgens.GE366();
        public Dclgens.GE367 GE367 { get; set; } = new Dclgens.GE367();
        public SISMS1B_MOVDEBCC MOVDEBCC { get; set; } = new SISMS1B_MOVDEBCC();
        public SISMS1B_TELEFONE TELEFONE { get; set; } = new SISMS1B_TELEFONE();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string ARQSMSCS_FILE_NAME_P, string ARQMOVSS_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                ARQSMSCS.SetFile(ARQSMSCS_FILE_NAME_P);
                ARQMOVSS.SetFile(ARQMOVSS_FILE_NAME_P);

                /*" -406- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

                /*" -407- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

                /*" -408- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

                /*" -411- DISPLAY ' ' */
                _.Display($" ");

                /*" -419- DISPLAY 'SISMS1B VERSAO 002 - INICIO  PROCESSAMENTO EM  ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2) */

                $"SISMS1B VERSAO 002 - INICIO  PROCESSAMENTO EM  {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
                .Display();

                /*" -421- OPEN OUTPUT ARQSMSCS ARQMOVSS. */
                ARQSMSCS.Open(REG_ARQSMSCS);
                ARQMOVSS.Open(REG_ARQMOVSS);

                /*" -422- WRITE REG-ARQSMSCS FROM W-REGISTRO-SMS-LC01. */
                _.Move(AREA_DE_WORK.W_REGISTRO_SMS_LC01.GetMoveValues(), REG_ARQSMSCS);

                ARQSMSCS.Write(REG_ARQSMSCS.GetMoveValues().ToString());

                /*" -424- WRITE REG-ARQMOVSS FROM W-REGISTRO-ERRO-LC01. */
                _.Move(AREA_DE_WORK.W_REGISTRO_ERRO_LC01.GetMoveValues(), REG_ARQMOVSS);

                ARQMOVSS.Write(REG_ARQMOVSS.GetMoveValues().ToString());

                /*" -425- PERFORM R005-LE-SISTEMAS THRU R005-EXIT. */

                R005_LE_SISTEMAS(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R005_EXIT*/


                /*" -427- PERFORM R010-DECLARE-MOVDEBCC THRU R010-EXIT. */

                R010_DECLARE_MOVDEBCC(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R010_EXIT*/


                /*" -429- MOVE 'NAO' TO W-CHAVE-FIM-MOVDEBCC. */
                _.Move("NAO", AREA_DE_WORK.W_CHAVE_FIM_MOVDEBCC);

                /*" -431- PERFORM R011-FETCH-MOVDEBCC THRU R011-EXIT. */

                R011_FETCH_MOVDEBCC(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R011_EXIT*/


                /*" -432- IF W-CHAVE-FIM-MOVDEBCC EQUAL 'SIM' */

                if (AREA_DE_WORK.W_CHAVE_FIM_MOVDEBCC == "SIM")
                {

                    /*" -433- DISPLAY '**********************************************' */
                    _.Display($"**********************************************");

                    /*" -434- DISPLAY '*                                            *' */
                    _.Display($"*                                            *");

                    /*" -435- DISPLAY '*           PROGRAMA SISMS1B                 *' */
                    _.Display($"*           PROGRAMA SISMS1B                 *");

                    /*" -436- DISPLAY '*                                            *' */
                    _.Display($"*                                            *");

                    /*" -437- DISPLAY '*         SEM MOVIMENTO NO DIA               *' */
                    _.Display($"*         SEM MOVIMENTO NO DIA               *");

                    /*" -438- DISPLAY '*                                            *' */
                    _.Display($"*                                            *");

                    /*" -439- DISPLAY '**********************************************' */
                    _.Display($"**********************************************");

                    /*" -440- MOVE 'SEM MOVIMENTO NO DIA' TO W-REGISTRO-SMS */
                    _.Move("SEM MOVIMENTO NO DIA", AREA_DE_WORK.W_REGISTRO_SMS);

                    /*" -441- WRITE REG-ARQSMSCS FROM W-REGISTRO-SMS */
                    _.Move(AREA_DE_WORK.W_REGISTRO_SMS.GetMoveValues(), REG_ARQSMSCS);

                    ARQSMSCS.Write(REG_ARQSMSCS.GetMoveValues().ToString());

                    /*" -442- MOVE 'SEM MOVIMENTO NO DIA' TO W-REGISTRO-ERRO */
                    _.Move("SEM MOVIMENTO NO DIA", AREA_DE_WORK.W_REGISTRO_ERRO);

                    /*" -443- WRITE REG-ARQMOVSS FROM W-REGISTRO-ERRO */
                    _.Move(AREA_DE_WORK.W_REGISTRO_ERRO.GetMoveValues(), REG_ARQMOVSS);

                    ARQMOVSS.Write(REG_ARQMOVSS.GetMoveValues().ToString());

                    /*" -446- GO TO R000-FIM. */

                    R000_FIM(); //GOTO
                    return Result;
                }


                /*" -449- PERFORM R100-PROCESSA-MOVDEBCC THRU R100-EXIT UNTIL W-CHAVE-FIM-MOVDEBCC EQUAL 'SIM' . */

                while (!(AREA_DE_WORK.W_CHAVE_FIM_MOVDEBCC == "SIM"))
                {

                    R100_PROCESSA_MOVDEBCC(true);

                    R100_LE_MOVDEBCC(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R100_EXIT*/

                }

                /*" -450- DISPLAY '**********************************************' */
                _.Display($"**********************************************");

                /*" -451- DISPLAY '*                                            *' */
                _.Display($"*                                            *");

                /*" -452- DISPLAY '*           PROGRAMA SISMS1B                 *' */
                _.Display($"*           PROGRAMA SISMS1B                 *");

                /*" -453- DISPLAY '*                                            *' */
                _.Display($"*                                            *");

                /*" -454- DISPLAY '*              FIM NORMAL                    *' */
                _.Display($"*              FIM NORMAL                    *");

                /*" -455- DISPLAY '*                                            *' */
                _.Display($"*                                            *");

                /*" -456- DISPLAY '**********************************************' */
                _.Display($"**********************************************");

                /*" -456- DISPLAY ' ' . */
                _.Display($" ");

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { CodigoRetorno = RETURN_CODE.Value };
            return Result;
        }

        [StopWatch]
        /*" R000-FIM */
        private void R000_FIM(bool isPerform = false)
        {
            /*" -461- DISPLAY 'MOVIMENTO LIDO ......... : ' W-LIDOS-MOVDEBCC. */
            _.Display($"MOVIMENTO LIDO ......... : {AREA_DE_WORK.W_LIDOS_MOVDEBCC}");

            /*" -462- DISPLAY 'GERADOS NO ARQUIVO SMS . : ' W-GRAVADO-COM-SUCESSO. */
            _.Display($"GERADOS NO ARQUIVO SMS . : {AREA_DE_WORK.W_GRAVADO_COM_SUCESSO}");

            /*" -464- DISPLAY 'MOVIMENTO REJEITADO .... : ' W-GRAVADO-SEM-SUCESSO. */
            _.Display($"MOVIMENTO REJEITADO .... : {AREA_DE_WORK.W_GRAVADO_SEM_SUCESSO}");

            /*" -467- CLOSE ARQSMSCS ARQMOVSS. */
            ARQSMSCS.Close();
            ARQMOVSS.Close();

            /*" -467- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -471- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -471- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" R005-LE-SISTEMAS */
        private void R005_LE_SISTEMAS(bool isPerform = false)
        {
            /*" -477- MOVE '010' TO WNR-EXEC-SQL. */
            _.Move("010", AREA_DE_WORK.WABEND.WABEND1.WABEND2.WNR_EXEC_SQL);

            /*" -484- PERFORM R005_LE_SISTEMAS_DB_SELECT_1 */

            R005_LE_SISTEMAS_DB_SELECT_1();

            /*" -487- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -488- DISPLAY 'SISMS1B - SISTEMA SI NAO CADASTRADO' */
                _.Display($"SISMS1B - SISTEMA SI NAO CADASTRADO");

                /*" -490- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -496- DISPLAY 'DATA DO SISTEMA DE SINISTRO (SI) - ' SISTEMAS-DATA-MOV-ABERTO(9:2) SISTEMAS-DATA-MOV-ABERTO(8:1) SISTEMAS-DATA-MOV-ABERTO(6:2) SISTEMAS-DATA-MOV-ABERTO(5:1) SISTEMAS-DATA-MOV-ABERTO(1:4). */

            $"DATA DO SISTEMA DE SINISTRO (SI) - {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(9, 2)}{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(8, 1)}{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(6, 2)}{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(5, 1)}{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(1, 4)}"
            .Display();

            /*" -498- DISPLAY ' ' . */
            _.Display($" ");

            /*" -499- MOVE SISTEMAS-DATA-MOV-ABERTO(9:2) TO W-DATA-DD-MM-AAAA-DD */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(9, 2), AREA_DE_WORK.W_DATA_DD_MM_AAAA.W_DATA_DD_MM_AAAA_DD);

            /*" -500- MOVE SISTEMAS-DATA-MOV-ABERTO(6:2) TO W-DATA-DD-MM-AAAA-MM */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(6, 2), AREA_DE_WORK.W_DATA_DD_MM_AAAA.W_DATA_DD_MM_AAAA_MM);

            /*" -502- MOVE SISTEMAS-DATA-MOV-ABERTO(1:4) TO W-DATA-DD-MM-AAAA-AAAA */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(1, 4), AREA_DE_WORK.W_DATA_DD_MM_AAAA.W_DATA_DD_MM_AAAA_AAAA);

            /*" -503- MOVE HOST-DATA-CORRENTE(9:2) TO W-DATA-DD-MM-AAAA-DD */
            _.Move(HOST_DATA_CORRENTE.Substring(9, 2), AREA_DE_WORK.W_DATA_DD_MM_AAAA.W_DATA_DD_MM_AAAA_DD);

            /*" -504- MOVE HOST-DATA-CORRENTE(6:2) TO W-DATA-DD-MM-AAAA-MM */
            _.Move(HOST_DATA_CORRENTE.Substring(6, 2), AREA_DE_WORK.W_DATA_DD_MM_AAAA.W_DATA_DD_MM_AAAA_MM);

            /*" -504- MOVE HOST-DATA-CORRENTE(1:4) TO W-DATA-DD-MM-AAAA-AAAA. */
            _.Move(HOST_DATA_CORRENTE.Substring(1, 4), AREA_DE_WORK.W_DATA_DD_MM_AAAA.W_DATA_DD_MM_AAAA_AAAA);

        }

        [StopWatch]
        /*" R005-LE-SISTEMAS-DB-SELECT-1 */
        public void R005_LE_SISTEMAS_DB_SELECT_1()
        {
            /*" -484- EXEC SQL SELECT DATA_MOV_ABERTO, CURRENT DATE, CURRENT TIME INTO :SISTEMAS-DATA-MOV-ABERTO, :HOST-DATA-CORRENTE, :HOST-HORA-CORRENTE FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'SI' END-EXEC. */

            var r005_LE_SISTEMAS_DB_SELECT_1_Query1 = new R005_LE_SISTEMAS_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R005_LE_SISTEMAS_DB_SELECT_1_Query1.Execute(r005_LE_SISTEMAS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);
                _.Move(executed_1.HOST_DATA_CORRENTE, HOST_DATA_CORRENTE);
                _.Move(executed_1.HOST_HORA_CORRENTE, HOST_HORA_CORRENTE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R005_EXIT*/

        [StopWatch]
        /*" R010-DECLARE-MOVDEBCC */
        private void R010_DECLARE_MOVDEBCC(bool isPerform = false)
        {
            /*" -512- MOVE '010' TO WNR-EXEC-SQL. */
            _.Move("010", AREA_DE_WORK.WABEND.WABEND1.WABEND2.WNR_EXEC_SQL);

            /*" -602- PERFORM R010_DECLARE_MOVDEBCC_DB_DECLARE_1 */

            R010_DECLARE_MOVDEBCC_DB_DECLARE_1();

            /*" -605- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -606- DISPLAY 'SISMS1B - ERRO DECLARE MOVDEBCC' */
                _.Display($"SISMS1B - ERRO DECLARE MOVDEBCC");

                /*" -608- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -608- PERFORM R010_DECLARE_MOVDEBCC_DB_OPEN_1 */

            R010_DECLARE_MOVDEBCC_DB_OPEN_1();

            /*" -611- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -612- DISPLAY 'SISMS1B - ERRO OPEN MOVDEBCC' */
                _.Display($"SISMS1B - ERRO OPEN MOVDEBCC");

                /*" -612- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R010-DECLARE-MOVDEBCC-DB-DECLARE-1 */
        public void R010_DECLARE_MOVDEBCC_DB_DECLARE_1()
        {
            /*" -602- EXEC SQL DECLARE MOVDEBCC CURSOR FOR SELECT M.RAMO , H.NUM_APOL_SINISTRO AS SINISTRO , H.OCORR_HISTORICO AS OCORR , H.COD_OPERACAO AS OPER , M.COD_PRODUTO AS "COD. PROD" , PROD.DESCR_PRODUTO AS PRODUTO , H.NOME_FAVORECIDO AS FAVORECIDO , E.NUM_PESSOA AS "NUM PESSOA" , A.DATA_VENCIMENTO AS "DTA_VENCIMENTO" , VALUE(A.DATA_ENVIO, '9999-12-31' ) AS "DTA ENVIO" , VALUE(A.DATA_RETORNO, '9999-12-31' ) AS "DTA RETORNO" , A.DATA_MOVIMENTO AS "MOV MOVDEBCC" , H.VAL_OPERACAO AS VAL_OPERACAO , A.VLR_CREDITO AS VAL_CREDITO , VALUE(F.COD_BANCO,0) AS BCO , VALUE(F.COD_AGENCIA,0) AS AGE , VALUE(F.NUM_CONTA_CNB, 'SEM CONTA' ) AS CONTA , VALUE(F.NUM_DV_CONTA_CNB, 'XXX' ) AS DV , X2.NOME_RAZAO AS NOME_SEGURADO , X2.CGCCPF AS CPF_SEGURADO , VALUE(PF.NOM_PESSOA, 'SEM NOME CAD.' ) AS NOME_FAVORECIDO , VALUE(PF.NUM_CPF,999999999) AS NUM_CPF , VALUE(PF.NUM_DV_CPF,99) AS DV_CPF , VALUE(EMAIL.DES_EMAIL, 'SEM EMAIL' ) AS EMAIL_FAVORECIDO , M.COD_FONTE , M.NUM_PROTOCOLO_SINI , M.NUM_APOLICE , M.NUM_CERTIFICADO FROM SEGUROS.MOVTO_DEBITOCC_CEF A LEFT JOIN SEGUROS.GE_MOVTO_CONTA F ON F.NUM_APOLICE = A.NUM_APOLICE AND F.NUM_ENDOSSO = A.NUM_ENDOSSO AND F.NUM_PARCELA = A.NUM_PARCELA AND F.COD_CONVENIO = A.COD_CONVENIO AND F.NSAS = A.NSAS , SEGUROS.SI_SINI_CHEQUE B , SEGUROS.SINISTRO_MESTRE M , SEGUROS.PRODUTO PROD , SEGUROS.GE_SIS_FUNCAO_OPER W , SEGUROS.SINISTRO_HISTORICO H , SEGUROS.SI_PESS_SINISTRO C , SEGUROS.GE_LEGADO_PESSOA E LEFT JOIN ODS.OD_PESSOA_FISICA PF ON PF.NUM_PESSOA = E.NUM_PESSOA LEFT JOIN ODS.OD_PESSOA_EMAIL EMAIL ON EMAIL.NUM_PESSOA = E.NUM_PESSOA , SEGUROS.CLIENTES X2 , SEGUROS.SEGURADOS_VGAP X1 WHERE A.DATA_RETORNO = :SISTEMAS-DATA-MOV-ABERTO AND M.RAMO IN ( 77, 81, 91, 93, 97 ) AND A.SITUACAO_COBRANCA = '2' AND B.NUM_APOL_SINISTRO = A.NUM_APOLICE AND B.OCORR_HISTORICO = A.NUM_PARCELA AND B.COD_OPERACAO = A.NUM_ENDOSSO AND M.NUM_APOL_SINISTRO = B.NUM_APOL_SINISTRO AND PROD.COD_PRODUTO = M.COD_PRODUTO AND H.NUM_APOL_SINISTRO = B.NUM_APOL_SINISTRO AND H.OCORR_HISTORICO = B.OCORR_HISTORICO AND H.COD_OPERACAO = B.COD_OPERACAO AND C.NUM_APOL_SINISTRO = B.NUM_APOL_SINISTRO AND C.OCORR_HISTORICO = B.OCORR_HISTORICO AND C.COD_OPERACAO = B.COD_OPERACAO AND E.NUM_OCORR_MOVTO = C.NUM_OCORR_MOVTO AND W.IDE_SISTEMA = 'SI' AND W.COD_FUNCAO = '2' AND W.COD_OPERACAO <> 1050 AND W.COD_OPERACAO = H.COD_OPERACAO AND X1.NUM_CERTIFICADO = M.NUM_CERTIFICADO AND X2.COD_CLIENTE = X1.COD_CLIENTE ORDER BY A.NUM_APOLICE, A.NUM_ENDOSSO, A.NUM_PARCELA WITH UR END-EXEC. */
            MOVDEBCC = new SISMS1B_MOVDEBCC(true);
            string GetQuery_MOVDEBCC()
            {
                var query = @$"SELECT 
							M.RAMO 
							, H.NUM_APOL_SINISTRO AS SINISTRO 
							, H.OCORR_HISTORICO AS OCORR 
							, H.COD_OPERACAO AS OPER 
							, M.COD_PRODUTO AS CODPROD 
							, PROD.DESCR_PRODUTO AS PRODUTO 
							, H.NOME_FAVORECIDO AS FAVORECIDO 
							, E.NUM_PESSOA AS NUMPESSOA 
							, A.DATA_VENCIMENTO AS DTA_VENCIMENTO 
							, VALUE(A.DATA_ENVIO
							, '9999-12-31' ) AS DTAENVIO 
							, VALUE(A.DATA_RETORNO
							, '9999-12-31' ) AS DTARETORNO 
							, A.DATA_MOVIMENTO AS MOVMOVDEBCC 
							, H.VAL_OPERACAO AS VAL_OPERACAO 
							, A.VLR_CREDITO AS VAL_CREDITO 
							, VALUE(F.COD_BANCO
							,0) AS BCO 
							, VALUE(F.COD_AGENCIA
							,0) AS AGE 
							, VALUE(F.NUM_CONTA_CNB
							, 'SEM CONTA' ) AS CONTA 
							, VALUE(F.NUM_DV_CONTA_CNB
							, 'XXX' ) AS DV 
							, X2.NOME_RAZAO AS NOME_SEGURADO 
							, X2.CGCCPF AS CPF_SEGURADO 
							, VALUE(PF.NOM_PESSOA
							, 'SEM NOME CAD.' ) AS NOME_FAVORECIDO 
							, VALUE(PF.NUM_CPF
							,999999999) AS NUM_CPF 
							, VALUE(PF.NUM_DV_CPF
							,99) AS DV_CPF 
							, VALUE(EMAIL.DES_EMAIL
							, 'SEM EMAIL' ) AS EMAIL_FAVORECIDO 
							, M.COD_FONTE 
							, M.NUM_PROTOCOLO_SINI 
							, M.NUM_APOLICE 
							, M.NUM_CERTIFICADO 
							FROM SEGUROS.MOVTO_DEBITOCC_CEF A 
							LEFT
							JOIN SEGUROS.GE_MOVTO_CONTA F 
							ON F.NUM_APOLICE = A.NUM_APOLICE 
							AND F.NUM_ENDOSSO = A.NUM_ENDOSSO 
							AND F.NUM_PARCELA = A.NUM_PARCELA 
							AND F.COD_CONVENIO = A.COD_CONVENIO 
							AND F.NSAS = A.NSAS 
							, SEGUROS.SI_SINI_CHEQUE B 
							, SEGUROS.SINISTRO_MESTRE M 
							, SEGUROS.PRODUTO PROD 
							, SEGUROS.GE_SIS_FUNCAO_OPER W 
							, SEGUROS.SINISTRO_HISTORICO H 
							, SEGUROS.SI_PESS_SINISTRO C 
							, SEGUROS.GE_LEGADO_PESSOA E 
							LEFT
							JOIN ODS.OD_PESSOA_FISICA PF 
							ON PF.NUM_PESSOA = E.NUM_PESSOA 
							LEFT
							JOIN ODS.OD_PESSOA_EMAIL EMAIL 
							ON EMAIL.NUM_PESSOA = E.NUM_PESSOA 
							, SEGUROS.CLIENTES X2 
							, SEGUROS.SEGURADOS_VGAP X1 
							WHERE A.DATA_RETORNO = '{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}' 
							AND M.RAMO IN ( 77
							, 81
							, 91
							, 93
							, 97 ) 
							AND A.SITUACAO_COBRANCA = '2' 
							AND B.NUM_APOL_SINISTRO = A.NUM_APOLICE 
							AND B.OCORR_HISTORICO = A.NUM_PARCELA 
							AND B.COD_OPERACAO = A.NUM_ENDOSSO 
							AND M.NUM_APOL_SINISTRO = B.NUM_APOL_SINISTRO 
							AND PROD.COD_PRODUTO = M.COD_PRODUTO 
							AND H.NUM_APOL_SINISTRO = B.NUM_APOL_SINISTRO 
							AND H.OCORR_HISTORICO = B.OCORR_HISTORICO 
							AND H.COD_OPERACAO = B.COD_OPERACAO 
							AND C.NUM_APOL_SINISTRO = B.NUM_APOL_SINISTRO 
							AND C.OCORR_HISTORICO = B.OCORR_HISTORICO 
							AND C.COD_OPERACAO = B.COD_OPERACAO 
							AND E.NUM_OCORR_MOVTO = C.NUM_OCORR_MOVTO 
							AND W.IDE_SISTEMA = 'SI' 
							AND W.COD_FUNCAO = '2' 
							AND W.COD_OPERACAO <> 1050 
							AND W.COD_OPERACAO = H.COD_OPERACAO 
							AND X1.NUM_CERTIFICADO = M.NUM_CERTIFICADO 
							AND X2.COD_CLIENTE = X1.COD_CLIENTE 
							ORDER BY A.NUM_APOLICE
							, A.NUM_ENDOSSO
							, A.NUM_PARCELA";

                return query;
            }
            MOVDEBCC.GetQueryEvent += GetQuery_MOVDEBCC;

        }

        [StopWatch]
        /*" R010-DECLARE-MOVDEBCC-DB-OPEN-1 */
        public void R010_DECLARE_MOVDEBCC_DB_OPEN_1()
        {
            /*" -608- EXEC SQL OPEN MOVDEBCC END-EXEC. */

            MOVDEBCC.Open();

        }

        [StopWatch]
        /*" R200-DECLARE-TELEFONE-DB-DECLARE-1 */
        public void R200_DECLARE_TELEFONE_DB_DECLARE_1()
        {
            /*" -769- EXEC SQL DECLARE TELEFONE CURSOR FOR SELECT T.NUM_PESSOA , VALUE(T.SEQ_TELEFONE,0) , VALUE(T.NUM_DDI,0) , VALUE(T.NUM_DDD,0) , VALUE(T.COD_TELEFONE,000000000) FROM ODS.OD_PESSOA_TELEFONE T WHERE T.NUM_PESSOA = :OD004-NUM-PESSOA ORDER BY T.SEQ_TELEFONE DESC WITH UR END-EXEC. */
            TELEFONE = new SISMS1B_TELEFONE(true);
            string GetQuery_TELEFONE()
            {
                var query = @$"SELECT 
							T.NUM_PESSOA 
							, VALUE(T.SEQ_TELEFONE
							,0) 
							, VALUE(T.NUM_DDI
							,0) 
							, VALUE(T.NUM_DDD
							,0) 
							, VALUE(T.COD_TELEFONE
							,000000000) 
							FROM ODS.OD_PESSOA_TELEFONE T 
							WHERE T.NUM_PESSOA = '{OD004.DCLOD_PESSOA_TELEFONE.OD004_NUM_PESSOA}' 
							ORDER BY T.SEQ_TELEFONE DESC";

                return query;
            }
            TELEFONE.GetQueryEvent += GetQuery_TELEFONE;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R010_EXIT*/

        [StopWatch]
        /*" R011-FETCH-MOVDEBCC */
        private void R011_FETCH_MOVDEBCC(bool isPerform = false)
        {
            /*" -621- MOVE '010' TO WNR-EXEC-SQL. */
            _.Move("010", AREA_DE_WORK.WABEND.WABEND1.WABEND2.WNR_EXEC_SQL);

            /*" -657- PERFORM R011_FETCH_MOVDEBCC_DB_FETCH_1 */

            R011_FETCH_MOVDEBCC_DB_FETCH_1();

            /*" -660- IF (SQLCODE EQUAL 0) */

            if ((DB.SQLCODE == 0))
            {

                /*" -662- ADD 1 TO W-LIDOS-MOVDEBCC. */
                AREA_DE_WORK.W_LIDOS_MOVDEBCC.Value = AREA_DE_WORK.W_LIDOS_MOVDEBCC + 1;
            }


            /*" -663- IF (SQLCODE EQUAL 100) */

            if ((DB.SQLCODE == 100))
            {

                /*" -664- MOVE 'SIM' TO W-CHAVE-FIM-MOVDEBCC */
                _.Move("SIM", AREA_DE_WORK.W_CHAVE_FIM_MOVDEBCC);

                /*" -664- PERFORM R011_FETCH_MOVDEBCC_DB_CLOSE_1 */

                R011_FETCH_MOVDEBCC_DB_CLOSE_1();

                /*" -666- IF (SQLCODE NOT EQUAL 0) */

                if ((DB.SQLCODE != 0))
                {

                    /*" -667- DISPLAY 'SISMS1B - ERRO CLOSE MOVDEBCC' */
                    _.Display($"SISMS1B - ERRO CLOSE MOVDEBCC");

                    /*" -669- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -670- IF (SQLCODE NOT EQUAL 0) AND (SQLCODE NOT EQUAL 100) */

            if ((DB.SQLCODE != 0) && (DB.SQLCODE != 100))
            {

                /*" -671- DISPLAY 'SISMS1B - ERRO FETCH MOVDEBCC' */
                _.Display($"SISMS1B - ERRO FETCH MOVDEBCC");

                /*" -671- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R011-FETCH-MOVDEBCC-DB-FETCH-1 */
        public void R011_FETCH_MOVDEBCC_DB_FETCH_1()
        {
            /*" -657- EXEC SQL FETCH MOVDEBCC INTO :SINISMES-RAMO ,:SINISHIS-NUM-APOL-SINISTRO ,:SINISHIS-OCORR-HISTORICO ,:SINISHIS-COD-OPERACAO ,:SINISMES-COD-PRODUTO ,:PRODUTO-DESCR-PRODUTO ,:SINISHIS-NOME-FAVORECIDO ,:GE367-NUM-PESSOA ,:MOVDEBCE-DATA-VENCIMENTO ,:MOVDEBCE-DATA-ENVIO ,:MOVDEBCE-DATA-RETORNO ,:MOVDEBCE-DATA-MOVIMENTO ,:SINISHIS-VAL-OPERACAO ,:MOVDEBCE-VLR-CREDITO ,:GE369-COD-BANCO ,:GE369-COD-AGENCIA ,:GE369-NUM-CONTA-CNB ,:GE369-NUM-DV-CONTA-CNB , :CLIENTES-NOME-RAZAO , :CLIENTES-CGCCPF , :OD002-NOM-PESSOA , :OD002-NUM-CPF , :OD002-NUM-DV-CPF , :OD005-DES-EMAIL , :SINISMES-COD-FONTE , :SINISMES-NUM-PROTOCOLO-SINI , :SINISMES-NUM-APOLICE , :SINISMES-NUM-CERTIFICADO END-EXEC. */

            if (MOVDEBCC.Fetch())
            {
                _.Move(MOVDEBCC.SINISMES_RAMO, SINISMES.DCLSINISTRO_MESTRE.SINISMES_RAMO);
                _.Move(MOVDEBCC.SINISHIS_NUM_APOL_SINISTRO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO);
                _.Move(MOVDEBCC.SINISHIS_OCORR_HISTORICO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO);
                _.Move(MOVDEBCC.SINISHIS_COD_OPERACAO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO);
                _.Move(MOVDEBCC.SINISMES_COD_PRODUTO, SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_PRODUTO);
                _.Move(MOVDEBCC.PRODUTO_DESCR_PRODUTO, PRODUTO.DCLPRODUTO.PRODUTO_DESCR_PRODUTO);
                _.Move(MOVDEBCC.SINISHIS_NOME_FAVORECIDO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NOME_FAVORECIDO);
                _.Move(MOVDEBCC.GE367_NUM_PESSOA, GE367.DCLGE_LEGADO_PESSOA.GE367_NUM_PESSOA);
                _.Move(MOVDEBCC.MOVDEBCE_DATA_VENCIMENTO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_VENCIMENTO);
                _.Move(MOVDEBCC.MOVDEBCE_DATA_ENVIO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_ENVIO);
                _.Move(MOVDEBCC.MOVDEBCE_DATA_RETORNO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_RETORNO);
                _.Move(MOVDEBCC.MOVDEBCE_DATA_MOVIMENTO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_MOVIMENTO);
                _.Move(MOVDEBCC.SINISHIS_VAL_OPERACAO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO);
                _.Move(MOVDEBCC.MOVDEBCE_VLR_CREDITO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_VLR_CREDITO);
                _.Move(MOVDEBCC.GE369_COD_BANCO, GE369.DCLGE_MOVTO_CONTA.GE369_COD_BANCO);
                _.Move(MOVDEBCC.GE369_COD_AGENCIA, GE369.DCLGE_MOVTO_CONTA.GE369_COD_AGENCIA);
                _.Move(MOVDEBCC.GE369_NUM_CONTA_CNB, GE369.DCLGE_MOVTO_CONTA.GE369_NUM_CONTA_CNB);
                _.Move(MOVDEBCC.GE369_NUM_DV_CONTA_CNB, GE369.DCLGE_MOVTO_CONTA.GE369_NUM_DV_CONTA_CNB);
                _.Move(MOVDEBCC.CLIENTES_NOME_RAZAO, CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO);
                _.Move(MOVDEBCC.CLIENTES_CGCCPF, CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF);
                _.Move(MOVDEBCC.OD002_NOM_PESSOA, OD002.DCLOD_PESSOA_FISICA.OD002_NOM_PESSOA);
                _.Move(MOVDEBCC.OD002_NUM_CPF, OD002.DCLOD_PESSOA_FISICA.OD002_NUM_CPF);
                _.Move(MOVDEBCC.OD002_NUM_DV_CPF, OD002.DCLOD_PESSOA_FISICA.OD002_NUM_DV_CPF);
                _.Move(MOVDEBCC.OD005_DES_EMAIL, OD005.DCLOD_PESSOA_EMAIL.OD005_DES_EMAIL);
                _.Move(MOVDEBCC.SINISMES_COD_FONTE, SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_FONTE);
                _.Move(MOVDEBCC.SINISMES_NUM_PROTOCOLO_SINI, SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_PROTOCOLO_SINI);
                _.Move(MOVDEBCC.SINISMES_NUM_APOLICE, SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOLICE);
                _.Move(MOVDEBCC.SINISMES_NUM_CERTIFICADO, SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_CERTIFICADO);
            }

        }

        [StopWatch]
        /*" R011-FETCH-MOVDEBCC-DB-CLOSE-1 */
        public void R011_FETCH_MOVDEBCC_DB_CLOSE_1()
        {
            /*" -664- EXEC SQL CLOSE MOVDEBCC END-EXEC */

            MOVDEBCC.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R011_EXIT*/

        [StopWatch]
        /*" R100-PROCESSA-MOVDEBCC */
        private void R100_PROCESSA_MOVDEBCC(bool isPerform = false)
        {
            /*" -702- DISPLAY ' LIDO MOVDEBCC SIN ' SINISHIS-NUM-APOL-SINISTRO ' OCO ' SINISHIS-OCORR-HISTORICO ' OPE ' SINISHIS-COD-OPERACAO ' PESSOA ' GE367-NUM-PESSOA */

            $" LIDO MOVDEBCC SIN {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO} OCO {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO} OPE {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO} PESSOA {GE367.DCLGE_LEGADO_PESSOA.GE367_NUM_PESSOA}"
            .Display();

            /*" -717- . */

            /*" -718- MOVE OD002-NUM-CPF TO W-NUM-CPF-NUM */
            _.Move(OD002.DCLOD_PESSOA_FISICA.OD002_NUM_CPF, AREA_DE_WORK.W_NUM_CPF.W_NUM_CPF_NUM);

            /*" -720- MOVE OD002-NUM-DV-CPF TO W-NUM-CPF-DV */
            _.Move(OD002.DCLOD_PESSOA_FISICA.OD002_NUM_DV_CPF, AREA_DE_WORK.W_NUM_CPF.W_NUM_CPF_DV);

            /*" -722- PERFORM R200-DECLARE-TELEFONE THRU R200-EXIT. */

            R200_DECLARE_TELEFONE(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R200_EXIT*/


            /*" -724- MOVE 'NAO' TO W-CHAVE-FIM-TELEFONE. */
            _.Move("NAO", AREA_DE_WORK.W_CHAVE_FIM_TELEFONE);

            /*" -726- PERFORM R201-FETCH-TELEFONE THRU R201-EXIT. */

            R201_FETCH_TELEFONE(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R201_EXIT*/


            /*" -728- IF W-CHAVE-FIM-TELEFONE EQUAL 'SIM' */

            if (AREA_DE_WORK.W_CHAVE_FIM_TELEFONE == "SIM")
            {

                /*" -730- MOVE 'MOVIMENTO SEM TELEFONE CADASTRADO' TO W-ERRO-MENSAGEM */
                _.Move("MOVIMENTO SEM TELEFONE CADASTRADO", AREA_DE_WORK.W_REGISTRO_ERRO.W_ERRO_MENSAGEM);

                /*" -731- PERFORM R400-GRAVA-ARQTELSS THRU R400-EXIT */

                R400_GRAVA_ARQTELSS(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R400_EXIT*/


                /*" -733- GO TO R100-LE-MOVDEBCC. */

                R100_LE_MOVDEBCC(); //GOTO
                return;
            }


            /*" -735- MOVE 'NAO' TO W-CHAVE-ACHOU-TEL-CELULAR */
            _.Move("NAO", AREA_DE_WORK.W_CHAVE_ACHOU_TEL_CELULAR);

            /*" -738- PERFORM R300-TRATA-TELEFONE THRU R300-EXIT UNTIL W-CHAVE-FIM-TELEFONE EQUAL 'SIM' . */

            while (!(AREA_DE_WORK.W_CHAVE_FIM_TELEFONE == "SIM"))
            {

                R300_TRATA_TELEFONE(true);

                R300_LE_TELEFONE(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R300_EXIT*/

            }

            /*" -740- IF W-CHAVE-ACHOU-TEL-CELULAR EQUAL 'NAO' */

            if (AREA_DE_WORK.W_CHAVE_ACHOU_TEL_CELULAR == "NAO")
            {

                /*" -742- MOVE 'MOVIMENTO SEM TELEFONE CELULAR OU INVALIDO' TO W-ERRO-MENSAGEM */
                _.Move("MOVIMENTO SEM TELEFONE CELULAR OU INVALIDO", AREA_DE_WORK.W_REGISTRO_ERRO.W_ERRO_MENSAGEM);

                /*" -743- PERFORM R400-GRAVA-ARQTELSS THRU R400-EXIT */

                R400_GRAVA_ARQTELSS(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R400_EXIT*/


                /*" -743- GO TO R100-LE-MOVDEBCC. */

                R100_LE_MOVDEBCC(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R100-LE-MOVDEBCC */
        private void R100_LE_MOVDEBCC(bool isPerform = false)
        {
            /*" -747- PERFORM R011-FETCH-MOVDEBCC THRU R011-EXIT. */

            R011_FETCH_MOVDEBCC(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R011_EXIT*/


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R100_EXIT*/

        [StopWatch]
        /*" R200-DECLARE-TELEFONE */
        private void R200_DECLARE_TELEFONE(bool isPerform = false)
        {
            /*" -755- MOVE '200' TO WNR-EXEC-SQL. */
            _.Move("200", AREA_DE_WORK.WABEND.WABEND1.WABEND2.WNR_EXEC_SQL);

            /*" -756- MOVE GE367-NUM-PESSOA TO OD004-NUM-PESSOA */
            _.Move(GE367.DCLGE_LEGADO_PESSOA.GE367_NUM_PESSOA, OD004.DCLOD_PESSOA_TELEFONE.OD004_NUM_PESSOA);

            /*" -758- DISPLAY 'LENDO TELEFONE - PESSOA: ' OD004-NUM-PESSOA */
            _.Display($"LENDO TELEFONE - PESSOA: {OD004.DCLOD_PESSOA_TELEFONE.OD004_NUM_PESSOA}");

            /*" -769- PERFORM R200_DECLARE_TELEFONE_DB_DECLARE_1 */

            R200_DECLARE_TELEFONE_DB_DECLARE_1();

            /*" -772- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -773- DISPLAY 'SISMS1B - ERRO DECLARE TELEFONE' */
                _.Display($"SISMS1B - ERRO DECLARE TELEFONE");

                /*" -775- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -775- PERFORM R200_DECLARE_TELEFONE_DB_OPEN_1 */

            R200_DECLARE_TELEFONE_DB_OPEN_1();

            /*" -778- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -779- DISPLAY 'SISMS1B - ERRO OPEN TELEFONE' */
                _.Display($"SISMS1B - ERRO OPEN TELEFONE");

                /*" -779- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R200-DECLARE-TELEFONE-DB-OPEN-1 */
        public void R200_DECLARE_TELEFONE_DB_OPEN_1()
        {
            /*" -775- EXEC SQL OPEN TELEFONE END-EXEC. */

            TELEFONE.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R200_EXIT*/

        [StopWatch]
        /*" R201-FETCH-TELEFONE */
        private void R201_FETCH_TELEFONE(bool isPerform = false)
        {
            /*" -787- MOVE '201' TO WNR-EXEC-SQL. */
            _.Move("201", AREA_DE_WORK.WABEND.WABEND1.WABEND2.WNR_EXEC_SQL);

            /*" -794- PERFORM R201_FETCH_TELEFONE_DB_FETCH_1 */

            R201_FETCH_TELEFONE_DB_FETCH_1();

            /*" -797- IF (SQLCODE EQUAL 100) */

            if ((DB.SQLCODE == 100))
            {

                /*" -798- MOVE 'SIM' TO W-CHAVE-FIM-TELEFONE */
                _.Move("SIM", AREA_DE_WORK.W_CHAVE_FIM_TELEFONE);

                /*" -798- PERFORM R201_FETCH_TELEFONE_DB_CLOSE_1 */

                R201_FETCH_TELEFONE_DB_CLOSE_1();

                /*" -800- IF (SQLCODE NOT EQUAL 0) */

                if ((DB.SQLCODE != 0))
                {

                    /*" -802- DISPLAY 'SISMS1B - ERRO CLOSE TELEFONE' . */
                    _.Display($"SISMS1B - ERRO CLOSE TELEFONE");
                }

            }


            /*" -803- IF (SQLCODE NOT EQUAL 0) AND (SQLCODE NOT EQUAL 100) */

            if ((DB.SQLCODE != 0) && (DB.SQLCODE != 100))
            {

                /*" -804- DISPLAY 'SISMS1B - ERRO FETCH TELEFONE' */
                _.Display($"SISMS1B - ERRO FETCH TELEFONE");

                /*" -804- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R201-FETCH-TELEFONE-DB-FETCH-1 */
        public void R201_FETCH_TELEFONE_DB_FETCH_1()
        {
            /*" -794- EXEC SQL FETCH TELEFONE INTO :OD004-NUM-PESSOA:IND-NULL1 ,:OD004-SEQ-TELEFONE:IND-NULL2 ,:OD004-NUM-DDI:IND-NULL3 ,:OD004-NUM-DDD:IND-NULL4 ,:OD004-COD-TELEFONE:IND-NULL5 END-EXEC. */

            if (TELEFONE.Fetch())
            {
                _.Move(TELEFONE.OD004_NUM_PESSOA, OD004.DCLOD_PESSOA_TELEFONE.OD004_NUM_PESSOA);
                _.Move(TELEFONE.IND_NULL1, IND_NULL1);
                _.Move(TELEFONE.OD004_SEQ_TELEFONE, OD004.DCLOD_PESSOA_TELEFONE.OD004_SEQ_TELEFONE);
                _.Move(TELEFONE.IND_NULL2, IND_NULL2);
                _.Move(TELEFONE.OD004_NUM_DDI, OD004.DCLOD_PESSOA_TELEFONE.OD004_NUM_DDI);
                _.Move(TELEFONE.IND_NULL3, IND_NULL3);
                _.Move(TELEFONE.OD004_NUM_DDD, OD004.DCLOD_PESSOA_TELEFONE.OD004_NUM_DDD);
                _.Move(TELEFONE.IND_NULL4, IND_NULL4);
                _.Move(TELEFONE.OD004_COD_TELEFONE, OD004.DCLOD_PESSOA_TELEFONE.OD004_COD_TELEFONE);
                _.Move(TELEFONE.IND_NULL5, IND_NULL5);
            }

        }

        [StopWatch]
        /*" R201-FETCH-TELEFONE-DB-CLOSE-1 */
        public void R201_FETCH_TELEFONE_DB_CLOSE_1()
        {
            /*" -798- EXEC SQL CLOSE TELEFONE END-EXEC */

            TELEFONE.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R201_EXIT*/

        [StopWatch]
        /*" R300-TRATA-TELEFONE */
        private void R300_TRATA_TELEFONE(bool isPerform = false)
        {
            /*" -815- MOVE SPACES TO W-TELEFONE-SMS. */
            _.Move("", AREA_DE_WORK.W_TELEFONE_SMS);

            /*" -816- MOVE OD004-COD-TELEFONE TO W-TELEFONE-NUMERICO */
            _.Move(OD004.DCLOD_PESSOA_TELEFONE.OD004_COD_TELEFONE, AREA_DE_WORK.W_TELEFONE_NUMERICO);

            /*" -817- DISPLAY '#################' */
            _.Display($"#################");

            /*" -818- DISPLAY 'OD004-COD-TELEFONE :#' OD004-COD-TELEFONE '#' */

            $"OD004-COD-TELEFONE :#{OD004.DCLOD_PESSOA_TELEFONE.OD004_COD_TELEFONE}#"
            .Display();

            /*" -819- DISPLAY 'W-TELEFONE-NUMERICO:#' W-TELEFONE-NUMERICO '#' */

            $"W-TELEFONE-NUMERICO:#{AREA_DE_WORK.W_TELEFONE_NUMERICO}#"
            .Display();

            /*" -831- DISPLAY ' ' */
            _.Display($" ");

            /*" -833- IF W-TELEFONE-BASE-DIGITO(2) = '9' NEXT SENTENCE */

            if (AREA_DE_WORK.W_TELEFONE_ALFA.W_TELEFONE_BASE_DIGITO[2] == "9")
            {

                /*" -834- ELSE */
            }
            else
            {


                /*" -837- IF (W-TELEFONE-BASE-DIGITO(3) >= '6' ) AND (W-TELEFONE-BASE-DIGITO(3) <= '9' ) NEXT SENTENCE */

                if ((AREA_DE_WORK.W_TELEFONE_ALFA.W_TELEFONE_BASE_DIGITO[3] >= "6") && (AREA_DE_WORK.W_TELEFONE_ALFA.W_TELEFONE_BASE_DIGITO[3] <= "9"))
                {

                    /*" -838- ELSE */
                }
                else
                {


                    /*" -839- DISPLAY '====> TELEFONE DESPREZADO' */
                    _.Display($"====> TELEFONE DESPREZADO");

                    /*" -840- GO TO R300-LE-TELEFONE */

                    R300_LE_TELEFONE(); //GOTO
                    return;

                    /*" -841- END-IF */
                }


                /*" -843- END-IF. */
            }


            /*" -844- IF W-TELEFONE-BASE-DIGITO(2) EQUAL '9' */

            if (AREA_DE_WORK.W_TELEFONE_ALFA.W_TELEFONE_BASE_DIGITO[2] == "9")
            {

                /*" -845- DISPLAY 'PRIMEIRO NUMERO DO TEL EH 9' */
                _.Display($"PRIMEIRO NUMERO DO TEL EH 9");

                /*" -847- MOVE W-TELEFONE-BASE-DIGITO(2) TO W-TELEFONE-SMS-DIGITO(1) */
                _.Move(AREA_DE_WORK.W_TELEFONE_ALFA.W_TELEFONE_BASE_DIGITO[2], AREA_DE_WORK.W_TELEFONE_SMS.W_TELEFONE_SMS_DIGITO[1]);

                /*" -849- MOVE W-TELEFONE-BASE-DIGITO(3) TO W-TELEFONE-SMS-DIGITO(2) */
                _.Move(AREA_DE_WORK.W_TELEFONE_ALFA.W_TELEFONE_BASE_DIGITO[3], AREA_DE_WORK.W_TELEFONE_SMS.W_TELEFONE_SMS_DIGITO[2]);

                /*" -851- MOVE W-TELEFONE-BASE-DIGITO(4) TO W-TELEFONE-SMS-DIGITO(3) */
                _.Move(AREA_DE_WORK.W_TELEFONE_ALFA.W_TELEFONE_BASE_DIGITO[4], AREA_DE_WORK.W_TELEFONE_SMS.W_TELEFONE_SMS_DIGITO[3]);

                /*" -853- MOVE W-TELEFONE-BASE-DIGITO(5) TO W-TELEFONE-SMS-DIGITO(4) */
                _.Move(AREA_DE_WORK.W_TELEFONE_ALFA.W_TELEFONE_BASE_DIGITO[5], AREA_DE_WORK.W_TELEFONE_SMS.W_TELEFONE_SMS_DIGITO[4]);

                /*" -855- MOVE W-TELEFONE-BASE-DIGITO(6) TO W-TELEFONE-SMS-DIGITO(5) */
                _.Move(AREA_DE_WORK.W_TELEFONE_ALFA.W_TELEFONE_BASE_DIGITO[6], AREA_DE_WORK.W_TELEFONE_SMS.W_TELEFONE_SMS_DIGITO[5]);

                /*" -857- MOVE W-TELEFONE-BASE-DIGITO(7) TO W-TELEFONE-SMS-DIGITO(6) */
                _.Move(AREA_DE_WORK.W_TELEFONE_ALFA.W_TELEFONE_BASE_DIGITO[7], AREA_DE_WORK.W_TELEFONE_SMS.W_TELEFONE_SMS_DIGITO[6]);

                /*" -859- MOVE W-TELEFONE-BASE-DIGITO(8) TO W-TELEFONE-SMS-DIGITO(7) */
                _.Move(AREA_DE_WORK.W_TELEFONE_ALFA.W_TELEFONE_BASE_DIGITO[8], AREA_DE_WORK.W_TELEFONE_SMS.W_TELEFONE_SMS_DIGITO[7]);

                /*" -861- MOVE W-TELEFONE-BASE-DIGITO(9) TO W-TELEFONE-SMS-DIGITO(8) */
                _.Move(AREA_DE_WORK.W_TELEFONE_ALFA.W_TELEFONE_BASE_DIGITO[9], AREA_DE_WORK.W_TELEFONE_SMS.W_TELEFONE_SMS_DIGITO[8]);

                /*" -863- MOVE W-TELEFONE-BASE-DIGITO(10) TO W-TELEFONE-SMS-DIGITO(9) */
                _.Move(AREA_DE_WORK.W_TELEFONE_ALFA.W_TELEFONE_BASE_DIGITO[10], AREA_DE_WORK.W_TELEFONE_SMS.W_TELEFONE_SMS_DIGITO[9]);

                /*" -865- MOVE W-TELEFONE-BASE-DIGITO(4) TO W-TELEFONE-SMS-DIGITO(2) */
                _.Move(AREA_DE_WORK.W_TELEFONE_ALFA.W_TELEFONE_BASE_DIGITO[4], AREA_DE_WORK.W_TELEFONE_SMS.W_TELEFONE_SMS_DIGITO[2]);

                /*" -869- DISPLAY '1 - TELEFONE CELULAR COMPLETO PARA O ARQUIVO:#' W-TELEFONE-SMS '#' . */

                $"1 - TELEFONE CELULAR COMPLETO PARA O ARQUIVO:#{AREA_DE_WORK.W_TELEFONE_SMS}#"
                .Display();
            }


            /*" -871- IF (W-TELEFONE-BASE-DIGITO(3) >= '6' ) AND (W-TELEFONE-BASE-DIGITO(3) <= '9' ) */

            if ((AREA_DE_WORK.W_TELEFONE_ALFA.W_TELEFONE_BASE_DIGITO[3] >= "6") && (AREA_DE_WORK.W_TELEFONE_ALFA.W_TELEFONE_BASE_DIGITO[3] <= "9"))
            {

                /*" -872- DISPLAY 'SEGUNDO NUMERO DO TEL EH MAIOR OU IGUAL A 6' */
                _.Display($"SEGUNDO NUMERO DO TEL EH MAIOR OU IGUAL A 6");

                /*" -874- MOVE '9' TO W-TELEFONE-SMS-DIGITO(1) */
                _.Move("9", AREA_DE_WORK.W_TELEFONE_SMS.W_TELEFONE_SMS_DIGITO[1]);

                /*" -876- MOVE W-TELEFONE-BASE-DIGITO(3) TO W-TELEFONE-SMS-DIGITO(2) */
                _.Move(AREA_DE_WORK.W_TELEFONE_ALFA.W_TELEFONE_BASE_DIGITO[3], AREA_DE_WORK.W_TELEFONE_SMS.W_TELEFONE_SMS_DIGITO[2]);

                /*" -878- MOVE W-TELEFONE-BASE-DIGITO(4) TO W-TELEFONE-SMS-DIGITO(3) */
                _.Move(AREA_DE_WORK.W_TELEFONE_ALFA.W_TELEFONE_BASE_DIGITO[4], AREA_DE_WORK.W_TELEFONE_SMS.W_TELEFONE_SMS_DIGITO[3]);

                /*" -880- MOVE W-TELEFONE-BASE-DIGITO(5) TO W-TELEFONE-SMS-DIGITO(4) */
                _.Move(AREA_DE_WORK.W_TELEFONE_ALFA.W_TELEFONE_BASE_DIGITO[5], AREA_DE_WORK.W_TELEFONE_SMS.W_TELEFONE_SMS_DIGITO[4]);

                /*" -882- MOVE W-TELEFONE-BASE-DIGITO(6) TO W-TELEFONE-SMS-DIGITO(5) */
                _.Move(AREA_DE_WORK.W_TELEFONE_ALFA.W_TELEFONE_BASE_DIGITO[6], AREA_DE_WORK.W_TELEFONE_SMS.W_TELEFONE_SMS_DIGITO[5]);

                /*" -884- MOVE W-TELEFONE-BASE-DIGITO(7) TO W-TELEFONE-SMS-DIGITO(6) */
                _.Move(AREA_DE_WORK.W_TELEFONE_ALFA.W_TELEFONE_BASE_DIGITO[7], AREA_DE_WORK.W_TELEFONE_SMS.W_TELEFONE_SMS_DIGITO[6]);

                /*" -886- MOVE W-TELEFONE-BASE-DIGITO(8) TO W-TELEFONE-SMS-DIGITO(7) */
                _.Move(AREA_DE_WORK.W_TELEFONE_ALFA.W_TELEFONE_BASE_DIGITO[8], AREA_DE_WORK.W_TELEFONE_SMS.W_TELEFONE_SMS_DIGITO[7]);

                /*" -888- MOVE W-TELEFONE-BASE-DIGITO(9) TO W-TELEFONE-SMS-DIGITO(8) */
                _.Move(AREA_DE_WORK.W_TELEFONE_ALFA.W_TELEFONE_BASE_DIGITO[9], AREA_DE_WORK.W_TELEFONE_SMS.W_TELEFONE_SMS_DIGITO[8]);

                /*" -890- MOVE W-TELEFONE-BASE-DIGITO(10) TO W-TELEFONE-SMS-DIGITO(9) */
                _.Move(AREA_DE_WORK.W_TELEFONE_ALFA.W_TELEFONE_BASE_DIGITO[10], AREA_DE_WORK.W_TELEFONE_SMS.W_TELEFONE_SMS_DIGITO[9]);

                /*" -893- DISPLAY '2 - TELEFONE PARA O ARQUIVO:#' W-TELEFONE-SMS '#' . */

                $"2 - TELEFONE PARA O ARQUIVO:#{AREA_DE_WORK.W_TELEFONE_SMS}#"
                .Display();
            }


            /*" -895- PERFORM R500-GRAVA-ARQSMSCS THRU R500-EXIT */

            R500_GRAVA_ARQSMSCS(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R500_EXIT*/


            /*" -897- MOVE 'SIM' TO W-CHAVE-ACHOU-TEL-CELULAR. */
            _.Move("SIM", AREA_DE_WORK.W_CHAVE_ACHOU_TEL_CELULAR);

            /*" -897- PERFORM R300_TRATA_TELEFONE_DB_CLOSE_1 */

            R300_TRATA_TELEFONE_DB_CLOSE_1();

            /*" -899- IF (SQLCODE NOT EQUAL 0) */

            if ((DB.SQLCODE != 0))
            {

                /*" -900- DISPLAY 'SISMS1B - ERRO CLOSE TELEFONE' */
                _.Display($"SISMS1B - ERRO CLOSE TELEFONE");

                /*" -901- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -902- END-IF */
            }


            /*" -903- MOVE 'SIM' TO W-CHAVE-FIM-TELEFONE */
            _.Move("SIM", AREA_DE_WORK.W_CHAVE_FIM_TELEFONE);

            /*" -903- GO TO R300-EXIT. */
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R300_EXIT*/ //GOTO
            return;

        }

        [StopWatch]
        /*" R300-TRATA-TELEFONE-DB-CLOSE-1 */
        public void R300_TRATA_TELEFONE_DB_CLOSE_1()
        {
            /*" -897- EXEC SQL CLOSE TELEFONE END-EXEC */

            TELEFONE.Close();

        }

        [StopWatch]
        /*" R300-LE-TELEFONE */
        private void R300_LE_TELEFONE(bool isPerform = false)
        {
            /*" -909- PERFORM R201-FETCH-TELEFONE THRU R201-EXIT. */

            R201_FETCH_TELEFONE(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R201_EXIT*/


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R300_EXIT*/

        [StopWatch]
        /*" R400-GRAVA-ARQTELSS */
        private void R400_GRAVA_ARQTELSS(bool isPerform = false)
        {
            /*" -920- MOVE SINISMES-COD-FONTE TO W-ERRO-FONTE */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_FONTE, AREA_DE_WORK.W_REGISTRO_ERRO.W_ERRO_FONTE);

            /*" -922- MOVE SINISMES-NUM-PROTOCOLO-SINI TO W-ERRO-PROTOCOLO */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_PROTOCOLO_SINI, AREA_DE_WORK.W_REGISTRO_ERRO.W_ERRO_PROTOCOLO);

            /*" -923- MOVE 0 TO W-ERRO-DAC */
            _.Move(0, AREA_DE_WORK.W_REGISTRO_ERRO.W_ERRO_DAC);

            /*" -924- MOVE W-NUM-CPF TO W-ERRO-NUM-COD-GCS */
            _.Move(AREA_DE_WORK.W_NUM_CPF, AREA_DE_WORK.W_REGISTRO_ERRO.W_ERRO_NUM_COD_GCS);

            /*" -925- MOVE CLIENTES-NOME-RAZAO TO W-ERRO-NOME-SEGURADO */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO, AREA_DE_WORK.W_REGISTRO_ERRO.W_ERRO_NOME_SEGURADO);

            /*" -926- MOVE CLIENTES-CGCCPF TO W-ERRO-CPF-SEGURADO */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF, AREA_DE_WORK.W_REGISTRO_ERRO.W_ERRO_CPF_SEGURADO);

            /*" -927- MOVE SINISMES-NUM-APOLICE TO W-ERRO-APOLICE */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOLICE, AREA_DE_WORK.W_REGISTRO_ERRO.W_ERRO_APOLICE);

            /*" -929- MOVE SINISMES-NUM-CERTIFICADO TO W-ERRO-CERTIFICADO */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_CERTIFICADO, AREA_DE_WORK.W_REGISTRO_ERRO.W_ERRO_CERTIFICADO);

            /*" -932- MOVE SINISHIS-NUM-APOL-SINISTRO TO W-ERRO-SINISTRO */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO, AREA_DE_WORK.W_REGISTRO_ERRO.W_ERRO_SINISTRO);

            /*" -933- DISPLAY 'COXA - OD002-NOM-PESSOA #' OD002-NOM-PESSOA */
            _.Display($"COXA - OD002-NOM-PESSOA #{OD002.DCLOD_PESSOA_FISICA.OD002_NOM_PESSOA}");

            /*" -936- DISPLAY 'COXA - OD002-NOM-PESSOA-TEXT #' OD002-NOM-PESSOA-TEXT */
            _.Display($"COXA - OD002-NOM-PESSOA-TEXT #{OD002.DCLOD_PESSOA_FISICA.OD002_NOM_PESSOA.OD002_NOM_PESSOA_TEXT}");

            /*" -937- MOVE OD002-NOM-PESSOA-TEXT TO W-ERRO-NOME-RECLAMANTE */
            _.Move(OD002.DCLOD_PESSOA_FISICA.OD002_NOM_PESSOA.OD002_NOM_PESSOA_TEXT, AREA_DE_WORK.W_REGISTRO_ERRO.W_ERRO_NOME_RECLAMANTE);

            /*" -938- MOVE OD004-NUM-DDD TO W-ERRO-DDD */
            _.Move(OD004.DCLOD_PESSOA_TELEFONE.OD004_NUM_DDD, AREA_DE_WORK.W_REGISTRO_ERRO.W_ERRO_DDD);

            /*" -940- MOVE OD004-COD-TELEFONE TO W-ERRO-CELULAR */
            _.Move(OD004.DCLOD_PESSOA_TELEFONE.OD004_COD_TELEFONE, AREA_DE_WORK.W_REGISTRO_ERRO.W_ERRO_CELULAR);

            /*" -941- MOVE SISTEMAS-DATA-MOV-ABERTO TO W-DATA-AAAA-MM-DD */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, AREA_DE_WORK.W_DATA_AAAA_MM_DD);

            /*" -942- MOVE W-DATA-AAAA-MM-DD-AAAA TO W-DATA-DD-MM-AAAA-AAAA */
            _.Move(AREA_DE_WORK.W_DATA_AAAA_MM_DD.W_DATA_AAAA_MM_DD_AAAA, AREA_DE_WORK.W_DATA_DD_MM_AAAA.W_DATA_DD_MM_AAAA_AAAA);

            /*" -943- MOVE W-DATA-AAAA-MM-DD-MM TO W-DATA-DD-MM-AAAA-MM */
            _.Move(AREA_DE_WORK.W_DATA_AAAA_MM_DD.W_DATA_AAAA_MM_DD_MM, AREA_DE_WORK.W_DATA_DD_MM_AAAA.W_DATA_DD_MM_AAAA_MM);

            /*" -944- MOVE W-DATA-AAAA-MM-DD-DD TO W-DATA-DD-MM-AAAA-DD */
            _.Move(AREA_DE_WORK.W_DATA_AAAA_MM_DD.W_DATA_AAAA_MM_DD_DD, AREA_DE_WORK.W_DATA_DD_MM_AAAA.W_DATA_DD_MM_AAAA_DD);

            /*" -946- MOVE W-DATA-DD-MM-AAAA TO W-ERRO-DATA-GERACAO */
            _.Move(AREA_DE_WORK.W_DATA_DD_MM_AAAA, AREA_DE_WORK.W_REGISTRO_ERRO.W_ERRO_DATA_GERACAO);

            /*" -947- MOVE SINISMES-COD-PRODUTO TO W-ERRO-PRODUTO */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_PRODUTO, AREA_DE_WORK.W_REGISTRO_ERRO.W_ERRO_PRODUTO);

            /*" -950- MOVE 'PAGAMEFE' TO W-ERRO-OPERACAO. */
            _.Move("PAGAMEFE", AREA_DE_WORK.W_REGISTRO_ERRO.W_ERRO_OPERACAO);

            /*" -952- DISPLAY 'GRAVOU ARQUIVO DE ERRO' . */
            _.Display($"GRAVOU ARQUIVO DE ERRO");

            /*" -954- WRITE REG-ARQMOVSS FROM W-REGISTRO-ERRO. */
            _.Move(AREA_DE_WORK.W_REGISTRO_ERRO.GetMoveValues(), REG_ARQMOVSS);

            ARQMOVSS.Write(REG_ARQMOVSS.GetMoveValues().ToString());

            /*" -954- ADD 1 TO W-GRAVADO-SEM-SUCESSO. */
            AREA_DE_WORK.W_GRAVADO_SEM_SUCESSO.Value = AREA_DE_WORK.W_GRAVADO_SEM_SUCESSO + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R400_EXIT*/

        [StopWatch]
        /*" R500-GRAVA-ARQSMSCS */
        private void R500_GRAVA_ARQSMSCS(bool isPerform = false)
        {
            /*" -963- MOVE CLIENTES-CGCCPF TO W-SMS-CPF-SEGURADO */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF, AREA_DE_WORK.W_REGISTRO_SMS.W_SMS_CPF_SEGURADO);

            /*" -965- MOVE CLIENTES-NOME-RAZAO TO W-SMS-NOME-SEGURADO */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO, AREA_DE_WORK.W_REGISTRO_SMS.W_SMS_NOME_SEGURADO);

            /*" -966- MOVE W-NUM-CPF TO W-SMS-CPF-FAVORECIDO */
            _.Move(AREA_DE_WORK.W_NUM_CPF, AREA_DE_WORK.W_REGISTRO_SMS.W_SMS_CPF_FAVORECIDO);

            /*" -967- MOVE SINISMES-NUM-APOLICE TO W-SMS-NUM-APOLICE */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOLICE, AREA_DE_WORK.W_REGISTRO_SMS.W_SMS_NUM_APOLICE);

            /*" -969- MOVE SINISMES-NUM-CERTIFICADO TO W-SMS-NUM-CERTIFICADO */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_CERTIFICADO, AREA_DE_WORK.W_REGISTRO_SMS.W_SMS_NUM_CERTIFICADO);

            /*" -971- MOVE SINISMES-NUM-PROTOCOLO-SINI TO W-SMS-NUM-PROTOCOLO */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_PROTOCOLO_SINI, AREA_DE_WORK.W_REGISTRO_SMS.W_SMS_NUM_PROTOCOLO);

            /*" -973- MOVE SINISHIS-NUM-APOL-SINISTRO TO W-SMS-NUM-SINISTRO */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO, AREA_DE_WORK.W_REGISTRO_SMS.W_SMS_NUM_SINISTRO);

            /*" -974- DISPLAY 'ASA - SINISTRO #' SINISHIS-NUM-APOL-SINISTRO */
            _.Display($"ASA - SINISTRO #{SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO}");

            /*" -975- DISPLAY 'ASA - OD002-NOM-PESSOA #' OD002-NOM-PESSOA */
            _.Display($"ASA - OD002-NOM-PESSOA #{OD002.DCLOD_PESSOA_FISICA.OD002_NOM_PESSOA}");

            /*" -979- DISPLAY 'ASA - OD002-NOM-PESSOA-TEXT #' OD002-NOM-PESSOA-TEXT */
            _.Display($"ASA - OD002-NOM-PESSOA-TEXT #{OD002.DCLOD_PESSOA_FISICA.OD002_NOM_PESSOA.OD002_NOM_PESSOA_TEXT}");

            /*" -981- MOVE OD002-NOM-PESSOA-TEXT TO W-SMS-NOME-RECLAMANTE */
            _.Move(OD002.DCLOD_PESSOA_FISICA.OD002_NOM_PESSOA.OD002_NOM_PESSOA_TEXT, AREA_DE_WORK.W_REGISTRO_SMS.W_SMS_NOME_RECLAMANTE);

            /*" -982- MOVE OD004-NUM-DDD TO W-SMS-DDD-CEL-FAVORECIDO */
            _.Move(OD004.DCLOD_PESSOA_TELEFONE.OD004_NUM_DDD, AREA_DE_WORK.W_REGISTRO_SMS.W_SMS_DDD_CEL_FAVORECIDO);

            /*" -984- MOVE W-TELEFONE-SMS TO W-SMS-CEL-FAVORECIDO */
            _.Move(AREA_DE_WORK.W_TELEFONE_SMS, AREA_DE_WORK.W_REGISTRO_SMS.W_SMS_CEL_FAVORECIDO);

            /*" -985- MOVE MOVDEBCE-DATA-RETORNO TO W-DATA-AAAA-MM-DD */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_RETORNO, AREA_DE_WORK.W_DATA_AAAA_MM_DD);

            /*" -986- MOVE W-DATA-AAAA-MM-DD-AAAA TO W-DATA-DD-MM-AAAA-AAAA */
            _.Move(AREA_DE_WORK.W_DATA_AAAA_MM_DD.W_DATA_AAAA_MM_DD_AAAA, AREA_DE_WORK.W_DATA_DD_MM_AAAA.W_DATA_DD_MM_AAAA_AAAA);

            /*" -987- MOVE W-DATA-AAAA-MM-DD-MM TO W-DATA-DD-MM-AAAA-MM */
            _.Move(AREA_DE_WORK.W_DATA_AAAA_MM_DD.W_DATA_AAAA_MM_DD_MM, AREA_DE_WORK.W_DATA_DD_MM_AAAA.W_DATA_DD_MM_AAAA_MM);

            /*" -988- MOVE W-DATA-AAAA-MM-DD-DD TO W-DATA-DD-MM-AAAA-DD */
            _.Move(AREA_DE_WORK.W_DATA_AAAA_MM_DD.W_DATA_AAAA_MM_DD_DD, AREA_DE_WORK.W_DATA_DD_MM_AAAA.W_DATA_DD_MM_AAAA_DD);

            /*" -990- MOVE W-DATA-DD-MM-AAAA TO W-SMS-DATA-MOV-RETORNO */
            _.Move(AREA_DE_WORK.W_DATA_DD_MM_AAAA, AREA_DE_WORK.W_REGISTRO_SMS.W_SMS_DATA_MOV_RETORNO);

            /*" -991- MOVE SISTEMAS-DATA-MOV-ABERTO TO W-DATA-AAAA-MM-DD */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, AREA_DE_WORK.W_DATA_AAAA_MM_DD);

            /*" -992- MOVE W-DATA-AAAA-MM-DD-AAAA TO W-DATA-DD-MM-AAAA-AAAA */
            _.Move(AREA_DE_WORK.W_DATA_AAAA_MM_DD.W_DATA_AAAA_MM_DD_AAAA, AREA_DE_WORK.W_DATA_DD_MM_AAAA.W_DATA_DD_MM_AAAA_AAAA);

            /*" -993- MOVE W-DATA-AAAA-MM-DD-MM TO W-DATA-DD-MM-AAAA-MM */
            _.Move(AREA_DE_WORK.W_DATA_AAAA_MM_DD.W_DATA_AAAA_MM_DD_MM, AREA_DE_WORK.W_DATA_DD_MM_AAAA.W_DATA_DD_MM_AAAA_MM);

            /*" -994- MOVE W-DATA-AAAA-MM-DD-DD TO W-DATA-DD-MM-AAAA-DD */
            _.Move(AREA_DE_WORK.W_DATA_AAAA_MM_DD.W_DATA_AAAA_MM_DD_DD, AREA_DE_WORK.W_DATA_DD_MM_AAAA.W_DATA_DD_MM_AAAA_DD);

            /*" -996- MOVE W-DATA-DD-MM-AAAA TO W-SMS-DATA-SISTEMA */
            _.Move(AREA_DE_WORK.W_DATA_DD_MM_AAAA, AREA_DE_WORK.W_REGISTRO_SMS.W_SMS_DATA_SISTEMA);

            /*" -997- MOVE OD005-DES-EMAIL TO W-SMS-EMAIL-FAVORECIDO */
            _.Move(OD005.DCLOD_PESSOA_EMAIL.OD005_DES_EMAIL, AREA_DE_WORK.W_REGISTRO_SMS.W_SMS_EMAIL_FAVORECIDO);

            /*" -1000- MOVE 'PAGAMEFE' TO W-SMS-OPERACAO. */
            _.Move("PAGAMEFE", AREA_DE_WORK.W_REGISTRO_SMS.W_SMS_OPERACAO);

            /*" -1001- DISPLAY 'GRAVOU O ARQUIVO DE SMS' . */
            _.Display($"GRAVOU O ARQUIVO DE SMS");

            /*" -1004- DISPLAY 'REGISTRO ARQ-SMS: ' W-REGISTRO-SMS */
            _.Display($"REGISTRO ARQ-SMS: {AREA_DE_WORK.W_REGISTRO_SMS}");

            /*" -1006- WRITE REG-ARQSMSCS FROM W-REGISTRO-SMS. */
            _.Move(AREA_DE_WORK.W_REGISTRO_SMS.GetMoveValues(), REG_ARQSMSCS);

            ARQSMSCS.Write(REG_ARQSMSCS.GetMoveValues().ToString());

            /*" -1006- ADD 1 TO W-GRAVADO-COM-SUCESSO. */
            AREA_DE_WORK.W_GRAVADO_COM_SUCESSO.Value = AREA_DE_WORK.W_GRAVADO_COM_SUCESSO + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R500_EXIT*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -1013- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, AREA_DE_WORK.WABEND.WABEND1.WABEND2.WABEND3.WSQLCODE);

            /*" -1014- DISPLAY WABEND1. */
            _.Display(AREA_DE_WORK.WABEND.WABEND1);

            /*" -1015- DISPLAY WABEND2. */
            _.Display(AREA_DE_WORK.WABEND.WABEND1.WABEND2);

            /*" -1016- DISPLAY WABEND3. */
            _.Display(AREA_DE_WORK.WABEND.WABEND1.WABEND2.WABEND3);

            /*" -1017- DISPLAY SQLERRMC. */
            _.Display(DB.SQLERRMC);

            /*" -1017- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -1018- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -1020- MOVE 99 TO RETURN-CODE */
            _.Move(99, RETURN_CODE);

            /*" -1020- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}