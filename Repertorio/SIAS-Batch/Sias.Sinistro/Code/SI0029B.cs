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
using Sias.Sinistro.DB2.SI0029B;

namespace Code
{
    public class SI0029B
    {
        public bool IsCall { get; set; }

        public SI0029B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *                                                                       */
        /*"      *                                                                       */
        /*"      *///////////////////////////////////////////////////////////////      */
        /*"      * SISTEMA              = SINISTRO.                                    */
        /*"      * PROGRAMA             = SI0029B.                                     */
        /*"      * OBJETIVO             = GERACAO DO ARQUIVO CONTENDO INFORMACOES      */
        /*"      *                          DOS SINISTROS DE CDG                         */
        /*"      * ANALISTA/PROGRAMADOR = HEIDER                                       */
        /*"      * DATA / CRIACAO       = JAN/2000                                     */
        /*"      *///////////////////////////////////////////////////////////////      */
        /*"      *                                                                       */
        /*"      * ALTERACAO BARAN 09/02/2000: ALTEREI A DATA DO PAGAMENTO PARA          */
        /*"      *                             A DATA DA LIBERACAO, INCLUSIVE ESTA       */
        /*"      *                             NAO ESTAVA SENDO MOVIDA PARA O LD01.      */
        /*"      *                   (O PEDIDO FOI DO JOSE NILTON - NOTES)               */
        /*"      *                                                                       */
        /*"      *                    PROCURAR BR0200                                    */
        /*"      *                                                                       */
        /*"      * PS: O GILSON COLOCOU A DATA NASC. NESTE PGM MAS NAO COMENTOU.         */
        /*"      *///////////////////////////////////////////////////////////////      */
        /*"      *                                                                       */
        /*"      * ALTERACAO TERCIO 29/2/2000: ALTEREI A DATA DO PAGAMENTO PARA          */
        /*"      *                             A DATA DA LIBERACAO, INCLUSIVE ESTA       */
        /*"      *                             NAO ESTAVA SENDO MOVIDA PARA O LD01.      */
        /*"      *                   (O PEDIDO FOI DO JOSE NILTON - NOTES)               */
        /*"      *                                                                       */
        /*"      *                    PROCURAR TL0200                                    */
        /*"      *                                                                       */
        /*"      *///////////////////////////////////////////////////////////////      */
        /*"      *                                                                       */
        /*"      * ALTERACAO ALEXIS 30/6/2003: INCLUSAO DA SITUACAO DA APOLICE E O       */
        /*"      *                             MOTIVO DO CANCELAMENTO QUANDO HOUVER      */
        /*"      *-----------------------------------------------------------------      */
        /*"      *   VERSAO 01 - CAD 10.003                                       *      */
        /*"      *                                                                *      */
        /*"      *              - CONVERSAO DO DB2 PARA A VERSAO 10               *      */
        /*"      *                                                                *      */
        /*"      *   EM 25/09/2013 -  CLAUDIO FREITAS                             *      */
        /*"      *                                                                *      */
        /*"      *                                            PROCURE POR V.01    *      */
        /*"      *----------------------------------------------------------------*      */
        #endregion


        #region VARIABLES

        public FileBasis _SI0029R1 { get; set; } = new FileBasis(new PIC("X", "400", "X(400)"));

        public FileBasis SI0029R1
        {
            get
            {
                _.Move(REG_SI0029R1, _SI0029R1); VarBasis.RedefinePassValue(REG_SI0029R1, _SI0029R1, REG_SI0029R1); return _SI0029R1;
            }
        }
        public FileBasis _SI0029R2 { get; set; } = new FileBasis(new PIC("X", "388", "X(388)"));

        public FileBasis SI0029R2
        {
            get
            {
                _.Move(REG_SI0029R2, _SI0029R2); VarBasis.RedefinePassValue(REG_SI0029R2, _SI0029R2, REG_SI0029R2); return _SI0029R2;
            }
        }
        /*"01  REG-SI0029R1.*/
        public SI0029B_REG_SI0029R1 REG_SI0029R1 { get; set; } = new SI0029B_REG_SI0029R1();
        public class SI0029B_REG_SI0029R1 : VarBasis
        {
            /*"    05 LINHA                    PIC X(400).*/
            public StringBasis LINHA { get; set; } = new StringBasis(new PIC("X", "400", "X(400)."), @"");
            /*"01  REG-SI0029R2.*/
        }
        public SI0029B_REG_SI0029R2 REG_SI0029R2 { get; set; } = new SI0029B_REG_SI0029R2();
        public class SI0029B_REG_SI0029R2 : VarBasis
        {
            /*"    05 LINHA                    PIC X(388).*/
            public StringBasis LINHA_0 { get; set; } = new StringBasis(new PIC("X", "388", "X(388)."), @"");
        }

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77  VIND-DTNASCM                PIC S9(04) COMP   VALUE +0.*/
        public IntBasis VIND_DTNASCM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  VIND-DATNASC                PIC S9(04) COMP   VALUE +0.*/
        public IntBasis VIND_DATNASC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  CA-MOTIV-CANCEL-NULO        PIC S9(04) COMP   VALUE +0.*/
        public IntBasis CA_MOTIV_CANCEL_NULO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0CLI-COD-CLIENTE           PIC S9(09) COMP.*/
        public IntBasis V0CLI_COD_CLIENTE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77  V0CLI-NOME-RAZAO            PIC X(40).*/
        public StringBasis V0CLI_NOME_RAZAO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"77  V0CLI-DATA-NASCM            PIC X(10).*/
        public StringBasis V0CLI_DATA_NASCM { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V0CDGC-DTINIVIG             PIC X(10).*/
        public StringBasis V0CDGC_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V0MEST-FONTE                PIC S9(04) COMP   VALUE +0.*/
        public IntBasis V0MEST_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0MEST-PROTSINI             PIC S9(09) COMP   VALUE +0.*/
        public IntBasis V0MEST_PROTSINI { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77  V0MEST-DAC                  PIC  X(01).*/
        public StringBasis V0MEST_DAC { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"77  V0MEST-NUM-APOL-SINISTRO    PIC S9(13) COMP-3 VALUE +0.*/
        public IntBasis V0MEST_NUM_APOL_SINISTRO { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"77  V0MEST-NUM-APOLICE          PIC S9(13) COMP-3 VALUE +0.*/
        public IntBasis V0MEST_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"77  V0MEST-DATCMD               PIC  X(10).*/
        public StringBasis V0MEST_DATCMD { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V0MEST-DATORR               PIC  X(10).*/
        public StringBasis V0MEST_DATORR { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V0MEST-NRCERTIF             PIC S9(15) COMP-3 VALUE +0.*/
        public IntBasis V0MEST_NRCERTIF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"77  V0MEST-DIGCERT              PIC  X(01).*/
        public StringBasis V0MEST_DIGCERT { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"77  V0MEST-IDTPSEGU             PIC  X(01).*/
        public StringBasis V0MEST_IDTPSEGU { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"77  V0MEST-CODCAU               PIC S9(04) COMP   VALUE +0.*/
        public IntBasis V0MEST_CODCAU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0MEST-CODSUBES             PIC S9(04) COMP   VALUE +0.*/
        public IntBasis V0MEST_CODSUBES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0MEST-DATTEC               PIC  X(10).*/
        public StringBasis V0MEST_DATTEC { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V0MEST-RAMO                 PIC S9(04) COMP   VALUE +0.*/
        public IntBasis V0MEST_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0MEST-CODPRODU             PIC S9(04) COMP   VALUE +0.*/
        public IntBasis V0MEST_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0MEST-SITUACAO             PIC  X(01).*/
        public StringBasis V0MEST_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"77  V0HIST-DTMOVTO              PIC  X(10).*/
        public StringBasis V0HIST_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V0HIST-VAL-OPERACAO         PIC S9(13)V99 COMP-3 VALUE +0.*/
        public DoubleBasis V0HIST_VAL_OPERACAO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77  V0HIST-SITUACAO             PIC  X(01).*/
        public StringBasis V0HIST_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"77  V0HIST-OPERACAO             PIC S9(04)    COMP   VALUE +0.*/
        public IntBasis V0HIST_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0HIST-NOMFAV               PIC  X(40).*/
        public StringBasis V0HIST_NOMFAV { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"77  V0HIST-TIPFAV               PIC  X(01).*/
        public StringBasis V0HIST_TIPFAV { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"77  V0ACOM-OPERACAO             PIC S9(04)    COMP   VALUE +0.*/
        public IntBasis V0ACOM_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0ACOM-DATOPR               PIC  X(10).*/
        public StringBasis V0ACOM_DATOPR { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V0ACOM-CODUSU               PIC  X(08).*/
        public StringBasis V0ACOM_CODUSU { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
        /*"77  V0OPER-DESOPR               PIC  X(40).*/
        public StringBasis V0OPER_DESOPR { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"77  V0SCAU-RAMO                 PIC S9(04) COMP   VALUE +0.*/
        public IntBasis V0SCAU_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0SCAU-CODCAU               PIC S9(04) COMP   VALUE +0.*/
        public IntBasis V0SCAU_CODCAU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0SCAU-DESCAU               PIC  X(40).*/
        public StringBasis V0SCAU_DESCAU { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"77  V0PROP-NRCERTIF             PIC S9(15) COMP-3 VALUE +0.*/
        public IntBasis V0PROP_NRCERTIF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"77  V0PROP-IDADE                PIC S9(04) COMP   VALUE +0.*/
        public IntBasis V0PROP_IDADE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  SEGVGAPH-OCORR-HISTORICO    PIC S9(04) COMP.*/
        public IntBasis SEGVGAPH_OCORR_HISTORICO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  SEGVGAPH-COD-OPERACAO       PIC S9(04) COMP.*/
        public IntBasis SEGVGAPH_COD_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0SAVG-IDE-SEXO             PIC  X(01).*/
        public StringBasis V0SAVG_IDE_SEXO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"77  V0SAVG-DT-NASCM             PIC  X(10).*/
        public StringBasis V0SAVG_DT_NASCM { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V0FON-NOMEFTE               PIC  X(40).*/
        public StringBasis V0FON_NOMEFTE { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"77  SIST-DTMOVABE               PIC  X(10).*/
        public StringBasis SIST_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  W-COUNT                     PIC S9(04) COMP   VALUE +0.*/
        public IntBasis W_COUNT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  CA-IND-ATIVO                PIC X(18)     VALUE SPACES.*/
        public StringBasis CA_IND_ATIVO { get; set; } = new StringBasis(new PIC("X", "18", "X(18)"), @"");
        /*"77  CA-MOTIV-CANCEL             PIC X(40)     VALUE SPACES.*/
        public StringBasis CA_MOTIV_CANCEL { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
        /*"01  W.*/
        public SI0029B_W W { get; set; } = new SI0029B_W();
        public class SI0029B_W : VarBasis
        {
            /*"    03 LC00.*/
            public SI0029B_LC00 LC00 { get; set; } = new SI0029B_LC00();
            public class SI0029B_LC00 : VarBasis
            {
                /*"       05 FILLER                     PIC X(17) VALUE          'PROGRAMA: SI0029B'.*/
                public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "17", "X(17)"), @"PROGRAMA: SI0029B");
                /*"       05 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03 LC01.*/
            }
            public SI0029B_LC01 LC01 { get; set; } = new SI0029B_LC01();
            public class SI0029B_LC01 : VarBasis
            {
                /*"       05 FILLER                     PIC X(06) VALUE          'DATA: '.*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "6", "X(06)"), @"DATA: ");
                /*"       05 LC01-DATA                  PIC X(10) VALUE SPACES.*/
                public StringBasis LC01_DATA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
                /*"       05 FILLER                     PIC X(01) VALUE ' '.*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
                /*"       05 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03 LC02.*/
            }
            public SI0029B_LC02 LC02 { get; set; } = new SI0029B_LC02();
            public class SI0029B_LC02 : VarBasis
            {
                /*"       05 FILLER                     PIC X(17) VALUE          'SINISTRO'.*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "17", "X(17)"), @"SINISTRO");
                /*"       05 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       05 FILLER                     PIC X(05) VALUE          'FONTE'.*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "5", "X(05)"), @"FONTE");
                /*"       05 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       05 FILLER                     PIC X(09) VALUE          'PROTOCOLO'.*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "9", "X(09)"), @"PROTOCOLO");
                /*"       05 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       05 FILLER                     PIC X(13) VALUE          'APOLICE '.*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "13", "X(13)"), @"APOLICE ");
                /*"       05 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       05 FILLER                     PIC X(15) VALUE          'CERTIFICADO'.*/
                public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "15", "X(15)"), @"CERTIFICADO");
                /*"       05 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       05 FILLER                     PIC X(09) VALUE          'SUB-GRUPO'.*/
                public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "9", "X(09)"), @"SUB-GRUPO");
                /*"       05 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       05 FILLER                     PIC X(05) VALUE          'IDADE'.*/
                public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "5", "X(05)"), @"IDADE");
                /*"       05 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       05 FILLER                     PIC X(04) VALUE          'SEXO'.*/
                public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "4", "X(04)"), @"SEXO");
                /*"       05 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       05 FILLER                     PIC X(40) VALUE          'NOME'.*/
                public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"NOME");
                /*"       05 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       05 FILLER                     PIC X(05) VALUE          'CAUSA'.*/
                public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "5", "X(05)"), @"CAUSA");
                /*"       05 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       05 FILLER                     PIC X(40) VALUE          'DESCRICAO DA CAUSA'.*/
                public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"DESCRICAO DA CAUSA");
                /*"       05 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       05 FILLER                     PIC X(28) VALUE          'DT. OCORRENCIA / DIAGNOSTICO'.*/
                public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "28", "X(28)"), @"DT. OCORRENCIA / DIAGNOSTICO");
                /*"       05 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       05 FILLER                     PIC X(14) VALUE          'DT. COMUNICADO'.*/
                public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "14", "X(14)"), @"DT. COMUNICADO");
                /*"       05 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       05 FILLER                     PIC X(14) VALUE          'DT. CADASTRO  '.*/
                public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "14", "X(14)"), @"DT. CADASTRO  ");
                /*"       05 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       05 FILLER                     PIC X(15) VALUE          'STATUS SINISTRO'.*/
                public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "15", "X(15)"), @"STATUS SINISTRO");
                /*"       05 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       05 FILLER                     PIC X(14) VALUE          'DT. LIBERACAO '.*/
                public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "14", "X(14)"), @"DT. LIBERACAO ");
                /*"       05 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       05 FILLER                     PIC X(14) VALUE          'VALOR LIBERADO'.*/
                public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "14", "X(14)"), @"VALOR LIBERADO");
                /*"       05 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       05 FILLER                     PIC X(14) VALUE          'DT. NASCIMENTO'.*/
                public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "14", "X(14)"), @"DT. NASCIMENTO");
                /*"       05 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_40 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       05 FILLER                     PIC X(14) VALUE          'DT. INICIO CDG'.*/
                public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "14", "X(14)"), @"DT. INICIO CDG");
                /*"       05 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       05 FILLER                     PIC X(14) VALUE          'IDADE CDG     '.*/
                public StringBasis FILLER_43 { get; set; } = new StringBasis(new PIC("X", "14", "X(14)"), @"IDADE CDG     ");
                /*"       05 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_44 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       05 FILLER                     PIC X(14) VALUE          'IDADE SINISTRO'.*/
                public StringBasis FILLER_45 { get; set; } = new StringBasis(new PIC("X", "14", "X(14)"), @"IDADE SINISTRO");
                /*"       05 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_46 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       05 FILLER                     PIC X(18) VALUE          'SITUACAO'.*/
                public StringBasis FILLER_47 { get; set; } = new StringBasis(new PIC("X", "18", "X(18)"), @"SITUACAO");
                /*"       05 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_48 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       05 FILLER                     PIC X(40) VALUE          'MOTIVO CANCELAMENTO'.*/
                public StringBasis FILLER_49 { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"MOTIVO CANCELAMENTO");
                /*"       05 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_50 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03 LC03.*/
            }
            public SI0029B_LC03 LC03 { get; set; } = new SI0029B_LC03();
            public class SI0029B_LC03 : VarBasis
            {
                /*"       05 FILLER                     PIC X(17) VALUE          'SINISTRO'.*/
                public StringBasis FILLER_51 { get; set; } = new StringBasis(new PIC("X", "17", "X(17)"), @"SINISTRO");
                /*"       05 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_52 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       05 FILLER                     PIC X(05) VALUE          'FONTE'.*/
                public StringBasis FILLER_53 { get; set; } = new StringBasis(new PIC("X", "5", "X(05)"), @"FONTE");
                /*"       05 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_54 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       05 FILLER                     PIC X(09) VALUE          'PROTOCOLO'.*/
                public StringBasis FILLER_55 { get; set; } = new StringBasis(new PIC("X", "9", "X(09)"), @"PROTOCOLO");
                /*"       05 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_56 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       05 FILLER                     PIC X(15) VALUE          'CERTIFICADO'.*/
                public StringBasis FILLER_57 { get; set; } = new StringBasis(new PIC("X", "15", "X(15)"), @"CERTIFICADO");
                /*"       05 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_58 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       05 FILLER                     PIC X(09) VALUE          'SUB-GRUPO'.*/
                public StringBasis FILLER_59 { get; set; } = new StringBasis(new PIC("X", "9", "X(09)"), @"SUB-GRUPO");
                /*"       05 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_60 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       05 FILLER                     PIC X(05) VALUE          'IDADE'.*/
                public StringBasis FILLER_61 { get; set; } = new StringBasis(new PIC("X", "5", "X(05)"), @"IDADE");
                /*"       05 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_62 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       05 FILLER                     PIC X(04) VALUE          'SEXO'.*/
                public StringBasis FILLER_63 { get; set; } = new StringBasis(new PIC("X", "4", "X(04)"), @"SEXO");
                /*"       05 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_64 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       05 FILLER                     PIC X(40) VALUE          'NOME'.*/
                public StringBasis FILLER_65 { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"NOME");
                /*"       05 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_66 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       05 FILLER                     PIC X(05) VALUE          'CAUSA'.*/
                public StringBasis FILLER_67 { get; set; } = new StringBasis(new PIC("X", "5", "X(05)"), @"CAUSA");
                /*"       05 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_68 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       05 FILLER                     PIC X(40) VALUE          'DESCRICAO DA CAUSA'.*/
                public StringBasis FILLER_69 { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"DESCRICAO DA CAUSA");
                /*"       05 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_70 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       05 FILLER                     PIC X(14) VALUE          'DT. OCORRENCIA'.*/
                public StringBasis FILLER_71 { get; set; } = new StringBasis(new PIC("X", "14", "X(14)"), @"DT. OCORRENCIA");
                /*"       05 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_72 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       05 FILLER                     PIC X(14) VALUE          'DT. COMUNICADO'.*/
                public StringBasis FILLER_73 { get; set; } = new StringBasis(new PIC("X", "14", "X(14)"), @"DT. COMUNICADO");
                /*"       05 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_74 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       05 FILLER                     PIC X(14) VALUE          'DT. CADASTRO  '.*/
                public StringBasis FILLER_75 { get; set; } = new StringBasis(new PIC("X", "14", "X(14)"), @"DT. CADASTRO  ");
                /*"       05 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_76 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       05 FILLER                     PIC X(15) VALUE          'STATUS SINISTRO'.*/
                public StringBasis FILLER_77 { get; set; } = new StringBasis(new PIC("X", "15", "X(15)"), @"STATUS SINISTRO");
                /*"       05 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_78 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       05 FILLER                     PIC X(21) VALUE          'DT. OCORR.  PROTOCOLO'.*/
                public StringBasis FILLER_79 { get; set; } = new StringBasis(new PIC("X", "21", "X(21)"), @"DT. OCORR.  PROTOCOLO");
                /*"       05 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_80 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       05 FILLER                     PIC X(21) VALUE          'COD. OCORR. PROTOCOLO'.*/
                public StringBasis FILLER_81 { get; set; } = new StringBasis(new PIC("X", "21", "X(21)"), @"COD. OCORR. PROTOCOLO");
                /*"       05 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_82 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       05 FILLER                     PIC X(40) VALUE          'DES. OCORR. PROTOCOLO'.*/
                public StringBasis FILLER_83 { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"DES. OCORR. PROTOCOLO");
                /*"       05 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_84 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       05 FILLER                     PIC X(22) VALUE          'USUARIO CAD. PROTOCOLO'.*/
                public StringBasis FILLER_85 { get; set; } = new StringBasis(new PIC("X", "22", "X(22)"), @"USUARIO CAD. PROTOCOLO");
                /*"       05 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_86 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       05 FILLER                     PIC X(14) VALUE          'DT. NASCIMENTO'.*/
                public StringBasis FILLER_87 { get; set; } = new StringBasis(new PIC("X", "14", "X(14)"), @"DT. NASCIMENTO");
                /*"       05 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_88 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       05 FILLER                     PIC X(14) VALUE          'DT. INICIO CDG'.*/
                public StringBasis FILLER_89 { get; set; } = new StringBasis(new PIC("X", "14", "X(14)"), @"DT. INICIO CDG");
                /*"       05 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_90 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       05 FILLER                     PIC X(14) VALUE          'IDADE CDG     '.*/
                public StringBasis FILLER_91 { get; set; } = new StringBasis(new PIC("X", "14", "X(14)"), @"IDADE CDG     ");
                /*"       05 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_92 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       05 FILLER                     PIC X(14) VALUE          'IDADE SINISTRO'.*/
                public StringBasis FILLER_93 { get; set; } = new StringBasis(new PIC("X", "14", "X(14)"), @"IDADE SINISTRO");
                /*"       05 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_94 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03 LD01.*/
            }
            public SI0029B_LD01 LD01 { get; set; } = new SI0029B_LD01();
            public class SI0029B_LD01 : VarBasis
            {
                /*"       05 LD01-NUM-APOL-SINISTRO     PIC X(17) VALUE SPACES.*/
                public StringBasis LD01_NUM_APOL_SINISTRO { get; set; } = new StringBasis(new PIC("X", "17", "X(17)"), @"");
                /*"       05 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_95 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       05 LD01-FONTE                 PIC X(05) VALUE SPACES.*/
                public StringBasis LD01_FONTE { get; set; } = new StringBasis(new PIC("X", "5", "X(05)"), @"");
                /*"       05 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_96 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       05 LD01-PROTSINI              PIC X(09) VALUE SPACES.*/
                public StringBasis LD01_PROTSINI { get; set; } = new StringBasis(new PIC("X", "9", "X(09)"), @"");
                /*"       05 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_97 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       05 LD01-NUM-APOLICE           PIC X(13) VALUE SPACES.*/
                public StringBasis LD01_NUM_APOLICE { get; set; } = new StringBasis(new PIC("X", "13", "X(13)"), @"");
                /*"       05 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_98 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       05 LD01-NRCERTIF              PIC X(15) VALUE SPACES.*/
                public StringBasis LD01_NRCERTIF { get; set; } = new StringBasis(new PIC("X", "15", "X(15)"), @"");
                /*"       05 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_99 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       05 LD01-CODSUBES              PIC X(09) VALUE SPACES.*/
                public StringBasis LD01_CODSUBES { get; set; } = new StringBasis(new PIC("X", "9", "X(09)"), @"");
                /*"       05 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_100 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       05 LD01-IDADE                 PIC X(05) VALUE SPACES.*/
                public StringBasis LD01_IDADE { get; set; } = new StringBasis(new PIC("X", "5", "X(05)"), @"");
                /*"       05 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_101 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       05 LD01-SEXO                  PIC X(04) VALUE SPACES.*/
                public StringBasis LD01_SEXO { get; set; } = new StringBasis(new PIC("X", "4", "X(04)"), @"");
                /*"       05 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_102 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       05 LD01-NOME-RAZAO            PIC X(40) VALUE SPACES.*/
                public StringBasis LD01_NOME_RAZAO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
                /*"       05 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_103 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       05 LD01-CODCAU                PIC X(05) VALUE SPACES.*/
                public StringBasis LD01_CODCAU { get; set; } = new StringBasis(new PIC("X", "5", "X(05)"), @"");
                /*"       05 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_104 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       05 LD01-DESCAU                PIC X(40) VALUE SPACES.*/
                public StringBasis LD01_DESCAU { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
                /*"       05 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_105 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       05 LD01-DATORR                PIC X(28) VALUE SPACES.*/
                public StringBasis LD01_DATORR { get; set; } = new StringBasis(new PIC("X", "28", "X(28)"), @"");
                /*"       05 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_106 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       05 LD01-DATCMD                PIC X(14) VALUE SPACES.*/
                public StringBasis LD01_DATCMD { get; set; } = new StringBasis(new PIC("X", "14", "X(14)"), @"");
                /*"       05 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_107 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       05 LD01-DATTEC                PIC X(14) VALUE SPACES.*/
                public StringBasis LD01_DATTEC { get; set; } = new StringBasis(new PIC("X", "14", "X(14)"), @"");
                /*"       05 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_108 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       05 LD01-STATUS                PIC X(15) VALUE SPACES.*/
                public StringBasis LD01_STATUS { get; set; } = new StringBasis(new PIC("X", "15", "X(15)"), @"");
                /*"       05 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_109 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       05 LD01-DTMOVTO               PIC X(14) VALUE SPACES.*/
                public StringBasis LD01_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "14", "X(14)"), @"");
                /*"       05 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_110 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       05 LD01-VAL-OPERACAO          PIC ZZ.ZZZ.ZZ9,99-.*/
                public DoubleBasis LD01_VAL_OPERACAO { get; set; } = new DoubleBasis(new PIC("9", "8", "ZZ.ZZZ.ZZ9V99-."), 3);
                /*"       05 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_111 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       05 LD01-DATNASC               PIC X(14) VALUE SPACES.*/
                public StringBasis LD01_DATNASC { get; set; } = new StringBasis(new PIC("X", "14", "X(14)"), @"");
                /*"       05 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_112 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       05 LD01-DTINICDG              PIC X(14) VALUE SPACES.*/
                public StringBasis LD01_DTINICDG { get; set; } = new StringBasis(new PIC("X", "14", "X(14)"), @"");
                /*"       05 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_113 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       05 LD01-IDADECDG              PIC X(14) VALUE SPACES.*/
                public StringBasis LD01_IDADECDG { get; set; } = new StringBasis(new PIC("X", "14", "X(14)"), @"");
                /*"       05 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_114 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       05 LD01-IDADESINI             PIC X(14) VALUE SPACES.*/
                public StringBasis LD01_IDADESINI { get; set; } = new StringBasis(new PIC("X", "14", "X(14)"), @"");
                /*"       05 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_115 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       05 LD01-IND-ATIVO             PIC X(18) VALUE SPACES.*/
                public StringBasis LD01_IND_ATIVO { get; set; } = new StringBasis(new PIC("X", "18", "X(18)"), @"");
                /*"       05 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_116 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       05 LD01-MOTIV-CANCEL          PIC X(40) VALUE SPACES.*/
                public StringBasis LD01_MOTIV_CANCEL { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
                /*"       05 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_117 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03 LD02.*/
            }
            public SI0029B_LD02 LD02 { get; set; } = new SI0029B_LD02();
            public class SI0029B_LD02 : VarBasis
            {
                /*"       05 LD02-NUM-APOL-SINISTRO     PIC X(17) VALUE SPACES.*/
                public StringBasis LD02_NUM_APOL_SINISTRO { get; set; } = new StringBasis(new PIC("X", "17", "X(17)"), @"");
                /*"       05 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_118 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       05 LD02-FONTE                 PIC X(05) VALUE SPACES.*/
                public StringBasis LD02_FONTE { get; set; } = new StringBasis(new PIC("X", "5", "X(05)"), @"");
                /*"       05 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_119 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       05 LD02-PROTSINI              PIC X(09) VALUE SPACES.*/
                public StringBasis LD02_PROTSINI { get; set; } = new StringBasis(new PIC("X", "9", "X(09)"), @"");
                /*"       05 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_120 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       05 LD02-NRCERTIF              PIC X(15) VALUE SPACES.*/
                public StringBasis LD02_NRCERTIF { get; set; } = new StringBasis(new PIC("X", "15", "X(15)"), @"");
                /*"       05 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_121 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       05 LD02-CODSUBES              PIC X(09) VALUE SPACES.*/
                public StringBasis LD02_CODSUBES { get; set; } = new StringBasis(new PIC("X", "9", "X(09)"), @"");
                /*"       05 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_122 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       05 LD02-IDADE                 PIC X(05) VALUE SPACES.*/
                public StringBasis LD02_IDADE { get; set; } = new StringBasis(new PIC("X", "5", "X(05)"), @"");
                /*"       05 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_123 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       05 LD02-SEXO                  PIC X(04) VALUE SPACES.*/
                public StringBasis LD02_SEXO { get; set; } = new StringBasis(new PIC("X", "4", "X(04)"), @"");
                /*"       05 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_124 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       05 LD02-NOME-RAZAO            PIC X(40) VALUE SPACES.*/
                public StringBasis LD02_NOME_RAZAO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
                /*"       05 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_125 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       05 LD02-CODCAU                PIC X(05) VALUE SPACES.*/
                public StringBasis LD02_CODCAU { get; set; } = new StringBasis(new PIC("X", "5", "X(05)"), @"");
                /*"       05 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_126 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       05 LD02-DESCAU                PIC X(40) VALUE SPACES.*/
                public StringBasis LD02_DESCAU { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
                /*"       05 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_127 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       05 LD02-DATORR                PIC X(14) VALUE SPACES.*/
                public StringBasis LD02_DATORR { get; set; } = new StringBasis(new PIC("X", "14", "X(14)"), @"");
                /*"       05 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_128 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       05 LD02-DATCMD                PIC X(14) VALUE SPACES.*/
                public StringBasis LD02_DATCMD { get; set; } = new StringBasis(new PIC("X", "14", "X(14)"), @"");
                /*"       05 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_129 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       05 LD02-DATTEC                PIC X(14) VALUE SPACES.*/
                public StringBasis LD02_DATTEC { get; set; } = new StringBasis(new PIC("X", "14", "X(14)"), @"");
                /*"       05 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_130 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       05 LD02-STATUS                PIC X(15) VALUE SPACES.*/
                public StringBasis LD02_STATUS { get; set; } = new StringBasis(new PIC("X", "15", "X(15)"), @"");
                /*"       05 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_131 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       05 LD02-DATOPR                PIC X(21) VALUE SPACES.*/
                public StringBasis LD02_DATOPR { get; set; } = new StringBasis(new PIC("X", "21", "X(21)"), @"");
                /*"       05 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_132 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       05 LD02-CODOPER               PIC X(21) VALUE SPACES.*/
                public StringBasis LD02_CODOPER { get; set; } = new StringBasis(new PIC("X", "21", "X(21)"), @"");
                /*"       05 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_133 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       05 LD02-DESOPR                PIC X(40) VALUE SPACES.*/
                public StringBasis LD02_DESOPR { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
                /*"       05 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_134 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       05 LD02-CODUSU                PIC X(22) VALUE SPACES.*/
                public StringBasis LD02_CODUSU { get; set; } = new StringBasis(new PIC("X", "22", "X(22)"), @"");
                /*"       05 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_135 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       05 LD02-DATNASC               PIC X(14) VALUE SPACES.*/
                public StringBasis LD02_DATNASC { get; set; } = new StringBasis(new PIC("X", "14", "X(14)"), @"");
                /*"       05 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_136 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       05 LD02-DTINICDG              PIC X(14) VALUE SPACES.*/
                public StringBasis LD02_DTINICDG { get; set; } = new StringBasis(new PIC("X", "14", "X(14)"), @"");
                /*"       05 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_137 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       05 LD02-IDADECDG              PIC X(14) VALUE SPACES.*/
                public StringBasis LD02_IDADECDG { get; set; } = new StringBasis(new PIC("X", "14", "X(14)"), @"");
                /*"       05 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_138 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       05 LD02-IDADESINI             PIC X(14) VALUE SPACES.*/
                public StringBasis LD02_IDADESINI { get; set; } = new StringBasis(new PIC("X", "14", "X(14)"), @"");
                /*"       05 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_139 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03 WFIM-PRINCIPAL                PIC X(03) VALUE 'NAO'.*/
            }
            public StringBasis WFIM_PRINCIPAL { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"NAO");
            /*"    03 WFIM-V0ACOMSINI               PIC X(03) VALUE 'NAO'.*/
            public StringBasis WFIM_V0ACOMSINI { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"NAO");
            /*"    03 WFIM-V0RELATORIO              PIC X(03) VALUE 'NAO'.*/
            public StringBasis WFIM_V0RELATORIO { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"NAO");
            /*"    03 W-OCORRENCIA                  PIC 9(03) VALUE ZEROS.*/
            public IntBasis W_OCORRENCIA { get; set; } = new IntBasis(new PIC("9", "3", "9(03)"));
            /*"    03 W-DATA1.*/
            public SI0029B_W_DATA1 W_DATA1 { get; set; } = new SI0029B_W_DATA1();
            public class SI0029B_W_DATA1 : VarBasis
            {
                /*"       05 W-DATA1-AAAA               PIC 9(04) VALUE ZEROS.*/
                public IntBasis W_DATA1_AAAA { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
                /*"       05 FILLER                     PIC X(01) VALUE '-'.*/
                public StringBasis FILLER_140 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
                /*"       05 W-DATA1-MM                 PIC 9(02) VALUE ZEROS.*/
                public IntBasis W_DATA1_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"       05 FILLER                     PIC X(01) VALUE '-'.*/
                public StringBasis FILLER_141 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
                /*"       05 W-DATA1-DD                 PIC 9(02) VALUE ZEROS.*/
                public IntBasis W_DATA1_DD { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"    03 W-DATA2.*/
            }
            public SI0029B_W_DATA2 W_DATA2 { get; set; } = new SI0029B_W_DATA2();
            public class SI0029B_W_DATA2 : VarBasis
            {
                /*"       05 W-DATA2-DD                 PIC 9(02) VALUE ZEROS.*/
                public IntBasis W_DATA2_DD { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"       05 FILLER                     PIC X(01) VALUE '/'.*/
                public StringBasis FILLER_142 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"/");
                /*"       05 W-DATA2-MM                 PIC 9(02) VALUE ZEROS.*/
                public IntBasis W_DATA2_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"       05 FILLER                     PIC X(01) VALUE '/'.*/
                public StringBasis FILLER_143 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"/");
                /*"       05 W-DATA2-AAAA               PIC 9(04) VALUE ZEROS.*/
                public IntBasis W_DATA2_AAAA { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
                /*"    03         WK-DATA1.*/
            }
            public SI0029B_WK_DATA1 WK_DATA1 { get; set; } = new SI0029B_WK_DATA1();
            public class SI0029B_WK_DATA1 : VarBasis
            {
                /*"      10       WK-ANO1           PIC  9(004).*/
                public IntBasis WK_ANO1 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_144 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10       WK-MES1           PIC  9(002).*/
                public IntBasis WK_MES1 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_145 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10       WK-DIA1           PIC  9(002).*/
                public IntBasis WK_DIA1 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    03         WK-DATA2.*/
            }
            public SI0029B_WK_DATA2 WK_DATA2 { get; set; } = new SI0029B_WK_DATA2();
            public class SI0029B_WK_DATA2 : VarBasis
            {
                /*"      10       WK-ANO2           PIC  9(004).*/
                public IntBasis WK_ANO2 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_146 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10       WK-MES2           PIC  9(002).*/
                public IntBasis WK_MES2 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_147 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10       WK-DIA2           PIC  9(002).*/
                public IntBasis WK_DIA2 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    03         WS-IDADE          PIC  9(004).*/
            }
            public IntBasis WS_IDADE { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    03        WABEND.*/
            public SI0029B_WABEND WABEND { get; set; } = new SI0029B_WABEND();
            public class SI0029B_WABEND : VarBasis
            {
                /*"      05      FILLER              PIC  X(010) VALUE             ' SI0029B'.*/
                public StringBasis FILLER_148 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" SI0029B");
                /*"      05      FILLER              PIC  X(028) VALUE             ' *** ERRO  EXEC SQL  NUMERO '.*/
                public StringBasis FILLER_149 { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @" *** ERRO  EXEC SQL  NUMERO ");
                /*"      05      WNR-EXEC-SQL        PIC  X(003) VALUE '000'.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"000");
                /*"      05      FILLER              PIC  X(011) VALUE             ' SQLCODE = '.*/
                public StringBasis FILLER_150 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @" SQLCODE = ");
                /*"      05      WSQLCODE            PIC  ZZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
                /*"      05      FILLER              PIC  X(014) VALUE             '    SQLCODE1= '.*/
                public StringBasis FILLER_151 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE1= ");
                /*"      05      WSQLCODE1           PIC  ZZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE1 { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
                /*"      05      FILLER              PIC  X(014) VALUE             '    SQLCODE2= '.*/
                public StringBasis FILLER_152 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE2= ");
                /*"      05      WSQLCODE2           PIC  ZZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE2 { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
            }
        }


        public SI0029B_PRINCIPAL PRINCIPAL { get; set; } = new SI0029B_PRINCIPAL();
        public SI0029B_V0ACOMSINI V0ACOMSINI { get; set; } = new SI0029B_V0ACOMSINI();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string SI0029R1_FILE_NAME_P, string SI0029R2_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                SI0029R1.SetFile(SI0029R1_FILE_NAME_P);
                SI0029R2.SetFile(SI0029R2_FILE_NAME_P);

                /*" -496- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

                /*" -497- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

                /*" -498- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

                /*" -502- MOVE '001' TO WNR-EXEC-SQL. */
                _.Move("001", W.WABEND.WNR_EXEC_SQL);

                /*" -507- PERFORM Execute_DB_SELECT_1 */

                Execute_DB_SELECT_1();

                /*" -510- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -511- DISPLAY 'ERRO SELECT V0SISTEMA PARA IDSISTEM = SI' */
                    _.Display($"ERRO SELECT V0SISTEMA PARA IDSISTEM = SI");

                    /*" -513- GO TO 999-999-ROT-ERRO. */

                    M_999_999_ROT_ERRO_SECTION(); //GOTO
                    return Result;
                }


                /*" -514- DISPLAY '***********************************' */
                _.Display($"***********************************");

                /*" -515- DISPLAY 'DATA MOVIMENTO ...: ' SIST-DTMOVABE */
                _.Display($"DATA MOVIMENTO ...: {SIST_DTMOVABE}");

                /*" -522- DISPLAY '***********************************' */
                _.Display($"***********************************");

                /*" -524- MOVE '002' TO WNR-EXEC-SQL. */
                _.Move("002", W.WABEND.WNR_EXEC_SQL);

                /*" -531- PERFORM Execute_DB_SELECT_2 */

                Execute_DB_SELECT_2();

                /*" -534- IF (SQLCODE NOT EQUAL ZEROS) AND (SQLCODE NOT EQUAL 100) */

                if ((DB.SQLCODE != 00) && (DB.SQLCODE != 100))
                {

                    /*" -535- DISPLAY 'ERRO NO SELECT NA V0RELATORIOS' */
                    _.Display($"ERRO NO SELECT NA V0RELATORIOS");

                    /*" -537- GO TO 999-999-ROT-ERRO. */

                    M_999_999_ROT_ERRO_SECTION(); //GOTO
                    return Result;
                }


                /*" -538- IF W-COUNT EQUAL ZERO */

                if (W_COUNT == 00)
                {

                    /*" -539- DISPLAY '************************************************' */
                    _.Display($"************************************************");

                    /*" -540- DISPLAY '*                                              *' */
                    _.Display($"*                                              *");

                    /*" -541- DISPLAY '*         PROGRAMA - SI0029B                   *' */
                    _.Display($"*         PROGRAMA - SI0029B                   *");

                    /*" -542- DISPLAY '*                                              *' */
                    _.Display($"*                                              *");

                    /*" -543- DISPLAY '*  NAO FOI ENCONTRADA SOLICITACAO NA           *' */
                    _.Display($"*  NAO FOI ENCONTRADA SOLICITACAO NA           *");

                    /*" -544- DISPLAY '*  V0RELATORIOS PELO USUARIO, PARA EXECUCAO    *' */
                    _.Display($"*  V0RELATORIOS PELO USUARIO, PARA EXECUCAO    *");

                    /*" -545- DISPLAY '*  DO PROGRAMA.                                *' */
                    _.Display($"*  DO PROGRAMA.                                *");

                    /*" -546- DISPLAY '*                                              *' */
                    _.Display($"*                                              *");

                    /*" -547- DISPLAY '*         TERMINO NORMAL DO PROGRAMA           *' */
                    _.Display($"*         TERMINO NORMAL DO PROGRAMA           *");

                    /*" -548- DISPLAY '*                                              *' */
                    _.Display($"*                                              *");

                    /*" -549- DISPLAY '************************************************' */
                    _.Display($"************************************************");

                    /*" -551- GO TO 000-FINALIZACAO. */

                    M_000_FINALIZACAO(); //GOTO
                    return Result;
                }


                /*" -553- OPEN OUTPUT SI0029R1 SI0029R2. */
                SI0029R1.Open(REG_SI0029R1);
                SI0029R2.Open(REG_SI0029R2);

                /*" -554- MOVE SIST-DTMOVABE TO W-DATA1. */
                _.Move(SIST_DTMOVABE, W.W_DATA1);

                /*" -555- MOVE W-DATA1-AAAA TO W-DATA2-AAAA. */
                _.Move(W.W_DATA1.W_DATA1_AAAA, W.W_DATA2.W_DATA2_AAAA);

                /*" -556- MOVE W-DATA1-MM TO W-DATA2-MM. */
                _.Move(W.W_DATA1.W_DATA1_MM, W.W_DATA2.W_DATA2_MM);

                /*" -557- MOVE W-DATA1-DD TO W-DATA2-DD. */
                _.Move(W.W_DATA1.W_DATA1_DD, W.W_DATA2.W_DATA2_DD);

                /*" -559- MOVE W-DATA2 TO LC01-DATA. */
                _.Move(W.W_DATA2, W.LC01.LC01_DATA);

                /*" -560- WRITE REG-SI0029R1 FROM LC00. */
                _.Move(W.LC00.GetMoveValues(), REG_SI0029R1);

                SI0029R1.Write(REG_SI0029R1.GetMoveValues().ToString());

                /*" -561- WRITE REG-SI0029R1 FROM LC01. */
                _.Move(W.LC01.GetMoveValues(), REG_SI0029R1);

                SI0029R1.Write(REG_SI0029R1.GetMoveValues().ToString());

                /*" -563- WRITE REG-SI0029R1 FROM LC02. */
                _.Move(W.LC02.GetMoveValues(), REG_SI0029R1);

                SI0029R1.Write(REG_SI0029R1.GetMoveValues().ToString());

                /*" -564- WRITE REG-SI0029R2 FROM LC00. */
                _.Move(W.LC00.GetMoveValues(), REG_SI0029R2);

                SI0029R2.Write(REG_SI0029R2.GetMoveValues().ToString());

                /*" -565- WRITE REG-SI0029R2 FROM LC01. */
                _.Move(W.LC01.GetMoveValues(), REG_SI0029R2);

                SI0029R2.Write(REG_SI0029R2.GetMoveValues().ToString());

                /*" -567- WRITE REG-SI0029R2 FROM LC03. */
                _.Move(W.LC03.GetMoveValues(), REG_SI0029R2);

                SI0029R2.Write(REG_SI0029R2.GetMoveValues().ToString());

                /*" -568- PERFORM 010-DECLARE-PRINCIPAL THRU 010-EXIT. */

                M_010_DECLARE_PRINCIPAL(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_010_EXIT*/


                /*" -569- MOVE 'NAO' TO WFIM-PRINCIPAL. */
                _.Move("NAO", W.WFIM_PRINCIPAL);

                /*" -571- PERFORM 011-FETCH-PRINCIPAL THRU 011-EXIT. */

                M_011_FETCH_PRINCIPAL(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_011_EXIT*/


                /*" -572- IF WFIM-PRINCIPAL EQUAL 'SIM' */

                if (W.WFIM_PRINCIPAL == "SIM")
                {

                    /*" -573- MOVE 'NADA SELECIONADO PARA A GERACAO DO ARQUIVO' TO LD01 */
                    _.Move("NADA SELECIONADO PARA A GERACAO DO ARQUIVO", W.LD01);

                    /*" -574- MOVE 'NADA SELECIONADO PARA A GERACAO DO ARQUIVO' TO LD02 */
                    _.Move("NADA SELECIONADO PARA A GERACAO DO ARQUIVO", W.LD02);

                    /*" -575- WRITE REG-SI0029R1 FROM LD01 */
                    _.Move(W.LD01.GetMoveValues(), REG_SI0029R1);

                    SI0029R1.Write(REG_SI0029R1.GetMoveValues().ToString());

                    /*" -577- WRITE REG-SI0029R1 FROM LD02. */
                    _.Move(W.LD02.GetMoveValues(), REG_SI0029R1);

                    SI0029R1.Write(REG_SI0029R1.GetMoveValues().ToString());
                }


                /*" -580- PERFORM 020-PROCESSA-PRINCIPAL THRU 020-EXIT UNTIL (WFIM-PRINCIPAL EQUAL 'SIM' ). */

                while (!((W.WFIM_PRINCIPAL == "SIM")))
                {

                    M_020_PROCESSA_PRINCIPAL(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_020_EXIT*/

                }

                /*" -580- CLOSE SI0029R1 SI0029R2. */
                SI0029R1.Close();
                SI0029R2.Close();

                /*" -580- FLUXCONTROL_PERFORM Execute-DB-SELECT-1 */

                Execute_DB_SELECT_1();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { CodigoRetorno = RETURN_CODE.Value };
            return Result;
        }

        [StopWatch]
        /*" Execute-DB-SELECT-1 */
        public void Execute_DB_SELECT_1()
        {
            /*" -507- EXEC SQL SELECT DTMOVABE INTO :SIST-DTMOVABE FROM SEGUROS.V1SISTEMA WHERE IDSISTEM = 'SI' END-EXEC. */

            var execute_DB_SELECT_1_Query1 = new Execute_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = Execute_DB_SELECT_1_Query1.Execute(execute_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SIST_DTMOVABE, SIST_DTMOVABE);
            }


        }

        [StopWatch]
        /*" M-000-FINALIZACAO */
        private void M_000_FINALIZACAO(bool isPerform = false)
        {
            /*" -586- MOVE '003' TO WNR-EXEC-SQL. */
            _.Move("003", W.WABEND.WNR_EXEC_SQL);

            /*" -592- PERFORM M_000_FINALIZACAO_DB_UPDATE_1 */

            M_000_FINALIZACAO_DB_UPDATE_1();

            /*" -595- IF (SQLCODE NOT EQUAL ZEROS) AND (SQLCODE NOT EQUAL 100) */

            if ((DB.SQLCODE != 00) && (DB.SQLCODE != 100))
            {

                /*" -596- DISPLAY 'ERRO NO UPDATE V0RELATORIOS' */
                _.Display($"ERRO NO UPDATE V0RELATORIOS");

                /*" -598- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -599- DISPLAY '***************************************************' */
            _.Display($"***************************************************");

            /*" -600- DISPLAY '*                                                 *' */
            _.Display($"*                                                 *");

            /*" -601- DISPLAY '*              PROGRAMA - SI0029B                 *' */
            _.Display($"*              PROGRAMA - SI0029B                 *");

            /*" -602- DISPLAY '*                                                 *' */
            _.Display($"*                                                 *");

            /*" -603- DISPLAY '*                TERMINO NORMAL                   *' */
            _.Display($"*                TERMINO NORMAL                   *");

            /*" -604- DISPLAY '*                                                 *' */
            _.Display($"*                                                 *");

            /*" -605- DISPLAY '***************************************************' */
            _.Display($"***************************************************");

            /*" -607- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -607- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" M-000-FINALIZACAO-DB-UPDATE-1 */
        public void M_000_FINALIZACAO_DB_UPDATE_1()
        {
            /*" -592- EXEC SQL UPDATE SEGUROS.V0RELATORIOS SET SITUACAO = '1' WHERE CODRELAT = 'SI0029B' AND DATA_SOLICITACAO = :SIST-DTMOVABE AND SITUACAO = '0' END-EXEC. */

            var m_000_FINALIZACAO_DB_UPDATE_1_Update1 = new M_000_FINALIZACAO_DB_UPDATE_1_Update1()
            {
                SIST_DTMOVABE = SIST_DTMOVABE.ToString(),
            };

            M_000_FINALIZACAO_DB_UPDATE_1_Update1.Execute(m_000_FINALIZACAO_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" Execute-DB-SELECT-2 */
        public void Execute_DB_SELECT_2()
        {
            /*" -531- EXEC SQL SELECT VALUE(COUNT(*),0) INTO :W-COUNT FROM SEGUROS.V0RELATORIOS WHERE CODRELAT = 'SI0029B' AND DATA_SOLICITACAO = :SIST-DTMOVABE AND SITUACAO = '0' END-EXEC. */

            var execute_DB_SELECT_2_Query1 = new Execute_DB_SELECT_2_Query1()
            {
                SIST_DTMOVABE = SIST_DTMOVABE.ToString(),
            };

            var executed_1 = Execute_DB_SELECT_2_Query1.Execute(execute_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.W_COUNT, W_COUNT);
            }


        }

        [StopWatch]
        /*" M-010-DECLARE-PRINCIPAL */
        private void M_010_DECLARE_PRINCIPAL(bool isPerform = false)
        {
            /*" -613- MOVE '004' TO WNR-EXEC-SQL. */
            _.Move("004", W.WABEND.WNR_EXEC_SQL);

            /*" -733- PERFORM M_010_DECLARE_PRINCIPAL_DB_DECLARE_1 */

            M_010_DECLARE_PRINCIPAL_DB_DECLARE_1();

            /*" -737- PERFORM M_010_DECLARE_PRINCIPAL_DB_OPEN_1 */

            M_010_DECLARE_PRINCIPAL_DB_OPEN_1();

            /*" -740- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -741- DISPLAY '*** SI0029B - ERRO NO OPEN DO CURSOR PRINCIPAL' */
                _.Display($"*** SI0029B - ERRO NO OPEN DO CURSOR PRINCIPAL");

                /*" -742- GO TO 999-999-ROT-ERRO */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -742- END-IF. */
            }


        }

        [StopWatch]
        /*" M-010-DECLARE-PRINCIPAL-DB-DECLARE-1 */
        public void M_010_DECLARE_PRINCIPAL_DB_DECLARE_1()
        {
            /*" -733- EXEC SQL DECLARE PRINCIPAL CURSOR FOR SELECT M.FONTE , M.PROTSINI , M.NUM_APOL_SINISTRO, M.NUM_APOLICE , M.NRCERTIF , M.CODSUBES , M.CODCAU , M.DATORR , M.DATCMD , M.DATTEC , M.SITUACAO , P.IDADE , S.IDE_SEXO , S.DATA_NASCIMENTO , C.COD_CLIENTE , C.NOME_RAZAO , C.DATA_NASCIMENTO , A.DESCAU , S.DATA_INIVIGENCIA + 6 MONTHS, B.COD_OPERACAO, MAX(B.OCORR_HISTORICO), CASE WHEN B.COD_OPERACAO > 399 AND B.COD_OPERACAO < 500 THEN 'SEGURADO CANCELADO' ELSE 'SEGURADO ATIVO    ' END, CASE B.COD_OPERACAO WHEN 401 THEN 'CANCELAMENTO SOLICITADO                 ' WHEN 402 THEN 'CANCELAMENTO POR AVISO DE SINISTRO      ' WHEN 403 THEN 'CANCELAMENTO FALTA DE PAGAMENTO         ' WHEN 404 THEN 'CANCEL AUTOMAT CONTA ENCER/NAO CADASTR  ' WHEN 405 THEN 'CANCEL AUTOMAT SEGURO DUPLICADO         ' WHEN 406 THEN 'CANCEL AUTOMAT CONTA TAXADA/OUTRAS RESTR' WHEN 407 THEN 'CANCEL AUTOMAT ADESAO NOVO PRODUTO      ' WHEN 408 THEN 'CANCEL AUTOMAT TRANSFERENCIA SUBGRUPO   ' WHEN 409 THEN 'CANCEL AUTOMAT CANCELAMENTO DE SUBGRUPO ' WHEN 410 THEN 'CANCEL AUTOMAT CANCELAMENTO DE APOLICE  ' WHEN 412 THEN 'CANCEL POR REATIVACAO DE SINISTRO       ' WHEN 415 THEN 'CANCEL AUTOMAT VENDA VAL MAIOR          ' WHEN 416 THEN 'CANCEL AUTOMAT VENDA VAL MAIOR          ' WHEN 417 THEN 'CANCELAMENTO POR EMISSAO INDEVIDA       ' WHEN 418 THEN 'CANCEL AUTOMAT TRANSFERENCIA DE APOLICE ' WHEN 499 THEN 'CANCELAMENTO POR SINISTRO DO PRINCIPAL  ' END FROM SEGUROS.V0MESTSINI M, SEGUROS.V0SEGURAVG S, SEGUROS.V0CLIENTE C, SEGUROS.V0PROPOSTAVA P, SEGUROS.SEGURADOSVGAP_HIST B, SEGUROS.V0SINICAUSA A WHERE A.CODCAU = M.CODCAU AND A.GRUPO_CAUSAS = 'C.D.G.' AND S.NUM_CERTIFICADO = M.NRCERTIF AND S.NUM_APOLICE = M.NUM_APOLICE AND S.COD_SUBGRUPO = M.CODSUBES AND C.COD_CLIENTE = S.COD_CLIENTE AND P.NRCERTIF = M.NRCERTIF AND S.NUM_ITEM = B.NUM_ITEM AND S.NUM_APOLICE = B.NUM_APOLICE GROUP BY M.FONTE , M.PROTSINI , M.NUM_APOL_SINISTRO, M.NUM_APOLICE , M.NRCERTIF , M.CODSUBES , M.CODCAU , M.DATORR , M.DATCMD , M.DATTEC , M.SITUACAO , P.IDADE , S.IDE_SEXO , S.DATA_NASCIMENTO , C.COD_CLIENTE , C.NOME_RAZAO , C.DATA_NASCIMENTO , A.DESCAU , S.DATA_INIVIGENCIA, B.COD_OPERACAO ORDER BY M.FONTE , M.PROTSINI , M.NUM_APOL_SINISTRO, M.NUM_APOLICE , M.NRCERTIF , M.CODSUBES , M.CODCAU , M.DATORR , M.DATCMD , M.DATTEC , M.SITUACAO , P.IDADE , S.IDE_SEXO , S.DATA_NASCIMENTO , C.COD_CLIENTE , C.NOME_RAZAO , C.DATA_NASCIMENTO , A.DESCAU , S.DATA_INIVIGENCIA, B.COD_OPERACAO END-EXEC. */
            PRINCIPAL = new SI0029B_PRINCIPAL(false);
            string GetQuery_PRINCIPAL()
            {
                var query = @$"SELECT M.FONTE
							, 
							M.PROTSINI
							, 
							M.NUM_APOL_SINISTRO
							, 
							M.NUM_APOLICE
							, 
							M.NRCERTIF
							, 
							M.CODSUBES
							, 
							M.CODCAU
							, 
							M.DATORR
							, 
							M.DATCMD
							, 
							M.DATTEC
							, 
							M.SITUACAO
							, 
							P.IDADE
							, 
							S.IDE_SEXO
							, 
							S.DATA_NASCIMENTO
							, 
							C.COD_CLIENTE
							, 
							C.NOME_RAZAO
							, 
							C.DATA_NASCIMENTO
							, 
							A.DESCAU
							, 
							S.DATA_INIVIGENCIA + 6 MONTHS
							, 
							B.COD_OPERACAO
							, 
							MAX(B.OCORR_HISTORICO)
							, 
							CASE WHEN B.COD_OPERACAO > 399 
							AND B.COD_OPERACAO < 500 THEN 
							'SEGURADO CANCELADO' 
							ELSE 
							'SEGURADO ATIVO ' 
							END
							, 
							CASE B.COD_OPERACAO 
							WHEN 401 THEN 
							'CANCELAMENTO SOLICITADO ' 
							WHEN 402 THEN 
							'CANCELAMENTO POR AVISO DE SINISTRO ' 
							WHEN 403 THEN 
							'CANCELAMENTO FALTA DE PAGAMENTO ' 
							WHEN 404 THEN 
							'CANCEL AUTOMAT CONTA ENCER/NAO CADASTR ' 
							WHEN 405 THEN 
							'CANCEL AUTOMAT SEGURO DUPLICADO ' 
							WHEN 406 THEN 
							'CANCEL AUTOMAT CONTA TAXADA/OUTRAS RESTR' 
							WHEN 407 THEN 
							'CANCEL AUTOMAT ADESAO NOVO PRODUTO ' 
							WHEN 408 THEN 
							'CANCEL AUTOMAT TRANSFERENCIA SUBGRUPO ' 
							WHEN 409 THEN 
							'CANCEL AUTOMAT CANCELAMENTO DE SUBGRUPO ' 
							WHEN 410 THEN 
							'CANCEL AUTOMAT CANCELAMENTO DE APOLICE ' 
							WHEN 412 THEN 
							'CANCEL POR REATIVACAO DE SINISTRO ' 
							WHEN 415 THEN 
							'CANCEL AUTOMAT VENDA VAL MAIOR ' 
							WHEN 416 THEN 
							'CANCEL AUTOMAT VENDA VAL MAIOR ' 
							WHEN 417 THEN 
							'CANCELAMENTO POR EMISSAO INDEVIDA ' 
							WHEN 418 THEN 
							'CANCEL AUTOMAT TRANSFERENCIA DE APOLICE ' 
							WHEN 499 THEN 
							'CANCELAMENTO POR SINISTRO DO PRINCIPAL ' 
							END 
							FROM SEGUROS.V0MESTSINI M
							, 
							SEGUROS.V0SEGURAVG S
							, 
							SEGUROS.V0CLIENTE C
							, 
							SEGUROS.V0PROPOSTAVA P
							, 
							SEGUROS.SEGURADOSVGAP_HIST B
							, 
							SEGUROS.V0SINICAUSA A 
							WHERE A.CODCAU = M.CODCAU 
							AND A.GRUPO_CAUSAS = 'C.D.G.' 
							AND S.NUM_CERTIFICADO = M.NRCERTIF 
							AND S.NUM_APOLICE = M.NUM_APOLICE 
							AND S.COD_SUBGRUPO = M.CODSUBES 
							AND C.COD_CLIENTE = S.COD_CLIENTE 
							AND P.NRCERTIF = M.NRCERTIF 
							AND S.NUM_ITEM = B.NUM_ITEM 
							AND S.NUM_APOLICE = B.NUM_APOLICE 
							GROUP BY M.FONTE
							, 
							M.PROTSINI
							, 
							M.NUM_APOL_SINISTRO
							, 
							M.NUM_APOLICE
							, 
							M.NRCERTIF
							, 
							M.CODSUBES
							, 
							M.CODCAU
							, 
							M.DATORR
							, 
							M.DATCMD
							, 
							M.DATTEC
							, 
							M.SITUACAO
							, 
							P.IDADE
							, 
							S.IDE_SEXO
							, 
							S.DATA_NASCIMENTO
							, 
							C.COD_CLIENTE
							, 
							C.NOME_RAZAO
							, 
							C.DATA_NASCIMENTO
							, 
							A.DESCAU
							, 
							S.DATA_INIVIGENCIA
							, 
							B.COD_OPERACAO 
							ORDER BY M.FONTE
							, 
							M.PROTSINI
							, 
							M.NUM_APOL_SINISTRO
							, 
							M.NUM_APOLICE
							, 
							M.NRCERTIF
							, 
							M.CODSUBES
							, 
							M.CODCAU
							, 
							M.DATORR
							, 
							M.DATCMD
							, 
							M.DATTEC
							, 
							M.SITUACAO
							, 
							P.IDADE
							, 
							S.IDE_SEXO
							, 
							S.DATA_NASCIMENTO
							, 
							C.COD_CLIENTE
							, 
							C.NOME_RAZAO
							, 
							C.DATA_NASCIMENTO
							, 
							A.DESCAU
							, 
							S.DATA_INIVIGENCIA
							, 
							B.COD_OPERACAO";

                return query;
            }
            PRINCIPAL.GetQueryEvent += GetQuery_PRINCIPAL;

        }

        [StopWatch]
        /*" M-010-DECLARE-PRINCIPAL-DB-OPEN-1 */
        public void M_010_DECLARE_PRINCIPAL_DB_OPEN_1()
        {
            /*" -737- EXEC SQL OPEN PRINCIPAL END-EXEC. */

            PRINCIPAL.Open();

        }

        [StopWatch]
        /*" M-030-DECLARE-V0ACOMSINI-DB-DECLARE-1 */
        public void M_030_DECLARE_V0ACOMSINI_DB_DECLARE_1()
        {
            /*" -1001- EXEC SQL DECLARE V0ACOMSINI CURSOR FOR SELECT A.OPERACAO , A.DATOPR , A.CODUSU , B.DESOPR FROM SEGUROS.V0ACOMSINI A, SEGUROS.V0CODOPER B WHERE A.FONTE = :V0MEST-FONTE AND A.PROTSINI = :V0MEST-PROTSINI AND B.OPERACAO = A.OPERACAO ORDER BY A.DATOPR END-EXEC. */
            V0ACOMSINI = new SI0029B_V0ACOMSINI(true);
            string GetQuery_V0ACOMSINI()
            {
                var query = @$"SELECT A.OPERACAO
							, 
							A.DATOPR
							, 
							A.CODUSU
							, 
							B.DESOPR 
							FROM SEGUROS.V0ACOMSINI A
							, 
							SEGUROS.V0CODOPER B 
							WHERE A.FONTE = '{V0MEST_FONTE}' 
							AND A.PROTSINI = '{V0MEST_PROTSINI}' 
							AND B.OPERACAO = A.OPERACAO 
							ORDER BY A.DATOPR";

                return query;
            }
            V0ACOMSINI.GetQueryEvent += GetQuery_V0ACOMSINI;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_010_EXIT*/

        [StopWatch]
        /*" M-011-FETCH-PRINCIPAL */
        private void M_011_FETCH_PRINCIPAL(bool isPerform = false)
        {
            /*" -749- MOVE '005' TO WNR-EXEC-SQL. */
            _.Move("005", W.WABEND.WNR_EXEC_SQL);

            /*" -751- MOVE SPACES TO CA-MOTIV-CANCEL. */
            _.Move("", CA_MOTIV_CANCEL);

            /*" -776- PERFORM M_011_FETCH_PRINCIPAL_DB_FETCH_1 */

            M_011_FETCH_PRINCIPAL_DB_FETCH_1();

            /*" -779- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -780- MOVE 'SIM' TO WFIM-PRINCIPAL */
                _.Move("SIM", W.WFIM_PRINCIPAL);

                /*" -780- PERFORM M_011_FETCH_PRINCIPAL_DB_CLOSE_1 */

                M_011_FETCH_PRINCIPAL_DB_CLOSE_1();

                /*" -782- GO TO 011-EXIT */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_011_EXIT*/ //GOTO
                return;

                /*" -783- ELSE */
            }
            else
            {


                /*" -784- IF (SQLCODE NOT EQUAL ZEROS) AND (SQLCODE NOT EQUAL 100) */

                if ((DB.SQLCODE != 00) && (DB.SQLCODE != 100))
                {

                    /*" -785- DISPLAY 'ERRO FETCH PRINCIPAL ' */
                    _.Display($"ERRO FETCH PRINCIPAL ");

                    /*" -787- GO TO 999-999-ROT-ERRO. */

                    M_999_999_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -788- IF VIND-DTNASCM < ZEROS */

            if (VIND_DTNASCM < 00)
            {

                /*" -790- MOVE SPACES TO V0SAVG-DT-NASCM. */
                _.Move("", V0SAVG_DT_NASCM);
            }


            /*" -791- IF VIND-DATNASC < ZEROS */

            if (VIND_DATNASC < 00)
            {

                /*" -793- MOVE SPACES TO V0CLI-DATA-NASCM. */
                _.Move("", V0CLI_DATA_NASCM);
            }


            /*" -794- IF CA-MOTIV-CANCEL-NULO EQUAL -1 */

            if (CA_MOTIV_CANCEL_NULO == -1)
            {

                /*" -795- MOVE SPACES TO CA-MOTIV-CANCEL */
                _.Move("", CA_MOTIV_CANCEL);

                /*" -795- END-IF. */
            }


        }

        [StopWatch]
        /*" M-011-FETCH-PRINCIPAL-DB-FETCH-1 */
        public void M_011_FETCH_PRINCIPAL_DB_FETCH_1()
        {
            /*" -776- EXEC SQL FETCH PRINCIPAL INTO :V0MEST-FONTE , :V0MEST-PROTSINI , :V0MEST-NUM-APOL-SINISTRO, :V0MEST-NUM-APOLICE , :V0MEST-NRCERTIF , :V0MEST-CODSUBES , :V0MEST-CODCAU , :V0MEST-DATORR , :V0MEST-DATCMD , :V0MEST-DATTEC , :V0MEST-SITUACAO , :V0PROP-IDADE , :V0SAVG-IDE-SEXO , :V0SAVG-DT-NASCM:VIND-DTNASCM, :V0CLI-COD-CLIENTE , :V0CLI-NOME-RAZAO , :V0CLI-DATA-NASCM:VIND-DATNASC, :V0SCAU-DESCAU , :V0CDGC-DTINIVIG , :SEGVGAPH-OCORR-HISTORICO, :SEGVGAPH-COD-OPERACAO , :CA-IND-ATIVO , :CA-MOTIV-CANCEL:CA-MOTIV-CANCEL-NULO END-EXEC. */

            if (PRINCIPAL.Fetch())
            {
                _.Move(PRINCIPAL.V0MEST_FONTE, V0MEST_FONTE);
                _.Move(PRINCIPAL.V0MEST_PROTSINI, V0MEST_PROTSINI);
                _.Move(PRINCIPAL.V0MEST_NUM_APOL_SINISTRO, V0MEST_NUM_APOL_SINISTRO);
                _.Move(PRINCIPAL.V0MEST_NUM_APOLICE, V0MEST_NUM_APOLICE);
                _.Move(PRINCIPAL.V0MEST_NRCERTIF, V0MEST_NRCERTIF);
                _.Move(PRINCIPAL.V0MEST_CODSUBES, V0MEST_CODSUBES);
                _.Move(PRINCIPAL.V0MEST_CODCAU, V0MEST_CODCAU);
                _.Move(PRINCIPAL.V0MEST_DATORR, V0MEST_DATORR);
                _.Move(PRINCIPAL.V0MEST_DATCMD, V0MEST_DATCMD);
                _.Move(PRINCIPAL.V0MEST_DATTEC, V0MEST_DATTEC);
                _.Move(PRINCIPAL.V0MEST_SITUACAO, V0MEST_SITUACAO);
                _.Move(PRINCIPAL.V0PROP_IDADE, V0PROP_IDADE);
                _.Move(PRINCIPAL.V0SAVG_IDE_SEXO, V0SAVG_IDE_SEXO);
                _.Move(PRINCIPAL.V0SAVG_DT_NASCM, V0SAVG_DT_NASCM);
                _.Move(PRINCIPAL.VIND_DTNASCM, VIND_DTNASCM);
                _.Move(PRINCIPAL.V0CLI_COD_CLIENTE, V0CLI_COD_CLIENTE);
                _.Move(PRINCIPAL.V0CLI_NOME_RAZAO, V0CLI_NOME_RAZAO);
                _.Move(PRINCIPAL.V0CLI_DATA_NASCM, V0CLI_DATA_NASCM);
                _.Move(PRINCIPAL.VIND_DATNASC, VIND_DATNASC);
                _.Move(PRINCIPAL.V0SCAU_DESCAU, V0SCAU_DESCAU);
                _.Move(PRINCIPAL.V0CDGC_DTINIVIG, V0CDGC_DTINIVIG);
                _.Move(PRINCIPAL.SEGVGAPH_OCORR_HISTORICO, SEGVGAPH_OCORR_HISTORICO);
                _.Move(PRINCIPAL.SEGVGAPH_COD_OPERACAO, SEGVGAPH_COD_OPERACAO);
                _.Move(PRINCIPAL.CA_IND_ATIVO, CA_IND_ATIVO);
                _.Move(PRINCIPAL.CA_MOTIV_CANCEL, CA_MOTIV_CANCEL);
                _.Move(PRINCIPAL.CA_MOTIV_CANCEL_NULO, CA_MOTIV_CANCEL_NULO);
            }

        }

        [StopWatch]
        /*" M-011-FETCH-PRINCIPAL-DB-CLOSE-1 */
        public void M_011_FETCH_PRINCIPAL_DB_CLOSE_1()
        {
            /*" -780- EXEC SQL CLOSE PRINCIPAL END-EXEC */

            PRINCIPAL.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_011_EXIT*/

        [StopWatch]
        /*" M-020-PROCESSA-PRINCIPAL */
        private void M_020_PROCESSA_PRINCIPAL(bool isPerform = false)
        {
            /*" -803- MOVE V0MEST-NUM-APOL-SINISTRO TO LD01-NUM-APOL-SINISTRO LD02-NUM-APOL-SINISTRO. */
            _.Move(V0MEST_NUM_APOL_SINISTRO, W.LD01.LD01_NUM_APOL_SINISTRO, W.LD02.LD02_NUM_APOL_SINISTRO);

            /*" -805- MOVE V0MEST-FONTE TO LD01-FONTE LD02-FONTE. */
            _.Move(V0MEST_FONTE, W.LD01.LD01_FONTE, W.LD02.LD02_FONTE);

            /*" -807- MOVE V0MEST-PROTSINI TO LD01-PROTSINI LD02-PROTSINI. */
            _.Move(V0MEST_PROTSINI, W.LD01.LD01_PROTSINI, W.LD02.LD02_PROTSINI);

            /*" -808- MOVE V0MEST-NUM-APOLICE TO LD01-NUM-APOLICE. */
            _.Move(V0MEST_NUM_APOLICE, W.LD01.LD01_NUM_APOLICE);

            /*" -810- MOVE V0MEST-NRCERTIF TO LD01-NRCERTIF LD02-NRCERTIF. */
            _.Move(V0MEST_NRCERTIF, W.LD01.LD01_NRCERTIF, W.LD02.LD02_NRCERTIF);

            /*" -812- MOVE V0MEST-CODSUBES TO LD01-CODSUBES LD02-CODSUBES. */
            _.Move(V0MEST_CODSUBES, W.LD01.LD01_CODSUBES, W.LD02.LD02_CODSUBES);

            /*" -815- MOVE V0MEST-CODCAU TO LD01-CODCAU LD02-CODCAU. */
            _.Move(V0MEST_CODCAU, W.LD01.LD01_CODCAU, W.LD02.LD02_CODCAU);

            /*" -816- MOVE V0MEST-DATORR TO W-DATA1 */
            _.Move(V0MEST_DATORR, W.W_DATA1);

            /*" -817- MOVE W-DATA1-AAAA TO W-DATA2-AAAA. */
            _.Move(W.W_DATA1.W_DATA1_AAAA, W.W_DATA2.W_DATA2_AAAA);

            /*" -818- MOVE W-DATA1-MM TO W-DATA2-MM. */
            _.Move(W.W_DATA1.W_DATA1_MM, W.W_DATA2.W_DATA2_MM);

            /*" -819- MOVE W-DATA1-DD TO W-DATA2-DD. */
            _.Move(W.W_DATA1.W_DATA1_DD, W.W_DATA2.W_DATA2_DD);

            /*" -822- MOVE W-DATA2 TO LD01-DATORR LD02-DATORR. */
            _.Move(W.W_DATA2, W.LD01.LD01_DATORR, W.LD02.LD02_DATORR);

            /*" -823- MOVE V0MEST-DATCMD TO W-DATA1. */
            _.Move(V0MEST_DATCMD, W.W_DATA1);

            /*" -824- MOVE W-DATA1-AAAA TO W-DATA2-AAAA. */
            _.Move(W.W_DATA1.W_DATA1_AAAA, W.W_DATA2.W_DATA2_AAAA);

            /*" -825- MOVE W-DATA1-MM TO W-DATA2-MM. */
            _.Move(W.W_DATA1.W_DATA1_MM, W.W_DATA2.W_DATA2_MM);

            /*" -826- MOVE W-DATA1-DD TO W-DATA2-DD. */
            _.Move(W.W_DATA1.W_DATA1_DD, W.W_DATA2.W_DATA2_DD);

            /*" -829- MOVE W-DATA2 TO LD01-DATCMD LD02-DATCMD. */
            _.Move(W.W_DATA2, W.LD01.LD01_DATCMD, W.LD02.LD02_DATCMD);

            /*" -830- MOVE V0MEST-DATTEC TO W-DATA1. */
            _.Move(V0MEST_DATTEC, W.W_DATA1);

            /*" -831- MOVE W-DATA1-AAAA TO W-DATA2-AAAA. */
            _.Move(W.W_DATA1.W_DATA1_AAAA, W.W_DATA2.W_DATA2_AAAA);

            /*" -832- MOVE W-DATA1-MM TO W-DATA2-MM. */
            _.Move(W.W_DATA1.W_DATA1_MM, W.W_DATA2.W_DATA2_MM);

            /*" -833- MOVE W-DATA1-DD TO W-DATA2-DD. */
            _.Move(W.W_DATA1.W_DATA1_DD, W.W_DATA2.W_DATA2_DD);

            /*" -836- MOVE W-DATA2 TO LD01-DATTEC LD02-DATTEC. */
            _.Move(W.W_DATA2, W.LD01.LD01_DATTEC, W.LD02.LD02_DATTEC);

            /*" -837- MOVE '********' TO LD01-STATUS. */
            _.Move("********", W.LD01.LD01_STATUS);

            /*" -838- IF V0MEST-SITUACAO EQUAL '0' */

            if (V0MEST_SITUACAO == "0")
            {

                /*" -840- MOVE 'EM ANALISE' TO LD01-STATUS LD02-STATUS. */
                _.Move("EM ANALISE", W.LD01.LD01_STATUS, W.LD02.LD02_STATUS);
            }


            /*" -841- IF V0MEST-SITUACAO EQUAL '1' */

            if (V0MEST_SITUACAO == "1")
            {

                /*" -843- MOVE 'PAGO    ' TO LD01-STATUS LD02-STATUS. */
                _.Move("PAGO    ", W.LD01.LD01_STATUS, W.LD02.LD02_STATUS);
            }


            /*" -844- IF V0MEST-SITUACAO EQUAL '2' */

            if (V0MEST_SITUACAO == "2")
            {

                /*" -847- MOVE 'CANCELADO' TO LD01-STATUS LD02-STATUS. */
                _.Move("CANCELADO", W.LD01.LD01_STATUS, W.LD02.LD02_STATUS);
            }


            /*" -849- MOVE V0PROP-IDADE TO LD01-IDADE LD02-IDADE. */
            _.Move(V0PROP_IDADE, W.LD01.LD01_IDADE, W.LD02.LD02_IDADE);

            /*" -851- MOVE V0SAVG-IDE-SEXO TO LD01-SEXO LD02-SEXO. */
            _.Move(V0SAVG_IDE_SEXO, W.LD01.LD01_SEXO, W.LD02.LD02_SEXO);

            /*" -853- MOVE V0CLI-NOME-RAZAO TO LD01-NOME-RAZAO LD02-NOME-RAZAO. */
            _.Move(V0CLI_NOME_RAZAO, W.LD01.LD01_NOME_RAZAO, W.LD02.LD02_NOME_RAZAO);

            /*" -855- MOVE V0SCAU-DESCAU TO LD01-DESCAU LD02-DESCAU. */
            _.Move(V0SCAU_DESCAU, W.LD01.LD01_DESCAU, W.LD02.LD02_DESCAU);

            /*" -856- MOVE CA-IND-ATIVO TO LD01-IND-ATIVO. */
            _.Move(CA_IND_ATIVO, W.LD01.LD01_IND_ATIVO);

            /*" -858- MOVE CA-MOTIV-CANCEL TO LD01-MOTIV-CANCEL. */
            _.Move(CA_MOTIV_CANCEL, W.LD01.LD01_MOTIV_CANCEL);

            /*" -860- MOVE '006' TO WNR-EXEC-SQL. */
            _.Move("006", W.WABEND.WNR_EXEC_SQL);

            /*" -868- PERFORM M_020_PROCESSA_PRINCIPAL_DB_SELECT_1 */

            M_020_PROCESSA_PRINCIPAL_DB_SELECT_1();

            /*" -871- IF (SQLCODE NOT EQUAL ZEROS) AND (SQLCODE NOT EQUAL 100) */

            if ((DB.SQLCODE != 00) && (DB.SQLCODE != 100))
            {

                /*" -872- DISPLAY 'ERRO NO SELECT (SUM) DA V0HISTSINI' */
                _.Display($"ERRO NO SELECT (SUM) DA V0HISTSINI");

                /*" -874- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -876- MOVE V0HIST-VAL-OPERACAO TO LD01-VAL-OPERACAO */
            _.Move(V0HIST_VAL_OPERACAO, W.LD01.LD01_VAL_OPERACAO);

            /*" -877- IF V0HIST-VAL-OPERACAO EQUAL ZERO */

            if (V0HIST_VAL_OPERACAO == 00)
            {

                /*" -878- MOVE SPACES TO LD01-DTMOVTO */
                _.Move("", W.LD01.LD01_DTMOVTO);

                /*" -879- ELSE */
            }
            else
            {


                /*" -880- MOVE '007' TO WNR-EXEC-SQL */
                _.Move("007", W.WABEND.WNR_EXEC_SQL);

                /*" -888- PERFORM M_020_PROCESSA_PRINCIPAL_DB_SELECT_2 */

                M_020_PROCESSA_PRINCIPAL_DB_SELECT_2();

                /*" -891- IF (SQLCODE NOT EQUAL ZEROS) AND (SQLCODE NOT EQUAL 100) */

                if ((DB.SQLCODE != 00) && (DB.SQLCODE != 100))
                {

                    /*" -892- DISPLAY 'ERRO NO SELECT DA V0HISTSINI (DTMOVTO)' */
                    _.Display($"ERRO NO SELECT DA V0HISTSINI (DTMOVTO)");

                    /*" -893- GO TO 999-999-ROT-ERRO */

                    M_999_999_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -894- END-IF */
                }


                /*" -895- MOVE V0HIST-DTMOVTO TO W-DATA1 */
                _.Move(V0HIST_DTMOVTO, W.W_DATA1);

                /*" -896- MOVE W-DATA1-AAAA TO W-DATA2-AAAA */
                _.Move(W.W_DATA1.W_DATA1_AAAA, W.W_DATA2.W_DATA2_AAAA);

                /*" -897- MOVE W-DATA1-MM TO W-DATA2-MM */
                _.Move(W.W_DATA1.W_DATA1_MM, W.W_DATA2.W_DATA2_MM);

                /*" -898- MOVE W-DATA1-DD TO W-DATA2-DD */
                _.Move(W.W_DATA1.W_DATA1_DD, W.W_DATA2.W_DATA2_DD);

                /*" -900- MOVE W-DATA2 TO LD01-DTMOVTO. */
                _.Move(W.W_DATA2, W.LD01.LD01_DTMOVTO);
            }


            /*" -902- IF V0SAVG-DT-NASCM = SPACES AND V0CLI-DATA-NASCM = SPACES */

            if (V0SAVG_DT_NASCM.IsEmpty() && V0CLI_DATA_NASCM.IsEmpty())
            {

                /*" -904- MOVE SPACES TO LD01-DATNASC LD02-DATNASC */
                _.Move("", W.LD01.LD01_DATNASC, W.LD02.LD02_DATNASC);

                /*" -905- ELSE */
            }
            else
            {


                /*" -906- IF V0SAVG-DT-NASCM NOT EQUAL SPACES */

                if (!V0SAVG_DT_NASCM.IsEmpty())
                {

                    /*" -908- MOVE V0SAVG-DT-NASCM TO W-DATA1 WK-DATA1 */
                    _.Move(V0SAVG_DT_NASCM, W.W_DATA1, W.WK_DATA1);

                    /*" -909- MOVE W-DATA1-AAAA TO W-DATA2-AAAA */
                    _.Move(W.W_DATA1.W_DATA1_AAAA, W.W_DATA2.W_DATA2_AAAA);

                    /*" -910- MOVE W-DATA1-MM TO W-DATA2-MM */
                    _.Move(W.W_DATA1.W_DATA1_MM, W.W_DATA2.W_DATA2_MM);

                    /*" -911- MOVE W-DATA1-DD TO W-DATA2-DD */
                    _.Move(W.W_DATA1.W_DATA1_DD, W.W_DATA2.W_DATA2_DD);

                    /*" -913- MOVE W-DATA2 TO LD01-DATNASC LD02-DATNASC */
                    _.Move(W.W_DATA2, W.LD01.LD01_DATNASC, W.LD02.LD02_DATNASC);

                    /*" -914- ELSE */
                }
                else
                {


                    /*" -915- IF V0CLI-DATA-NASCM NOT EQUAL SPACES */

                    if (!V0CLI_DATA_NASCM.IsEmpty())
                    {

                        /*" -917- MOVE V0CLI-DATA-NASCM TO W-DATA1 WK-DATA1 */
                        _.Move(V0CLI_DATA_NASCM, W.W_DATA1, W.WK_DATA1);

                        /*" -918- MOVE W-DATA1-AAAA TO W-DATA2-AAAA */
                        _.Move(W.W_DATA1.W_DATA1_AAAA, W.W_DATA2.W_DATA2_AAAA);

                        /*" -919- MOVE W-DATA1-MM TO W-DATA2-MM */
                        _.Move(W.W_DATA1.W_DATA1_MM, W.W_DATA2.W_DATA2_MM);

                        /*" -920- MOVE W-DATA1-DD TO W-DATA2-DD */
                        _.Move(W.W_DATA1.W_DATA1_DD, W.W_DATA2.W_DATA2_DD);

                        /*" -948- MOVE W-DATA2 TO LD01-DATNASC LD02-DATNASC. */
                        _.Move(W.W_DATA2, W.LD01.LD01_DATNASC, W.LD02.LD02_DATNASC);
                    }

                }

            }


            /*" -950- MOVE V0CDGC-DTINIVIG TO W-DATA1 WK-DATA2. */
            _.Move(V0CDGC_DTINIVIG, W.W_DATA1, W.WK_DATA2);

            /*" -951- MOVE W-DATA1-AAAA TO W-DATA2-AAAA. */
            _.Move(W.W_DATA1.W_DATA1_AAAA, W.W_DATA2.W_DATA2_AAAA);

            /*" -952- MOVE W-DATA1-MM TO W-DATA2-MM. */
            _.Move(W.W_DATA1.W_DATA1_MM, W.W_DATA2.W_DATA2_MM);

            /*" -953- MOVE W-DATA1-DD TO W-DATA2-DD. */
            _.Move(W.W_DATA1.W_DATA1_DD, W.W_DATA2.W_DATA2_DD);

            /*" -956- MOVE W-DATA2 TO LD01-DTINICDG LD02-DTINICDG. */
            _.Move(W.W_DATA2, W.LD01.LD01_DTINICDG, W.LD02.LD02_DTINICDG);

            /*" -958- COMPUTE WS-IDADE = WK-ANO2 - WK-ANO1. */
            W.WS_IDADE.Value = W.WK_DATA2.WK_ANO2 - W.WK_DATA1.WK_ANO1;

            /*" -959- IF WK-MES2 < WK-MES1 */

            if (W.WK_DATA2.WK_MES2 < W.WK_DATA1.WK_MES1)
            {

                /*" -961- SUBTRACT 1 FROM WS-IDADE. */
                W.WS_IDADE.Value = W.WS_IDADE - 1;
            }


            /*" -964- MOVE WS-IDADE TO LD01-IDADECDG LD02-IDADECDG. */
            _.Move(W.WS_IDADE, W.LD01.LD01_IDADECDG, W.LD02.LD02_IDADECDG);

            /*" -965- MOVE V0MEST-DATORR TO WK-DATA2. */
            _.Move(V0MEST_DATORR, W.WK_DATA2);

            /*" -967- COMPUTE WS-IDADE = WK-ANO2 - WK-ANO1. */
            W.WS_IDADE.Value = W.WK_DATA2.WK_ANO2 - W.WK_DATA1.WK_ANO1;

            /*" -968- IF WK-MES2 < WK-MES1 */

            if (W.WK_DATA2.WK_MES2 < W.WK_DATA1.WK_MES1)
            {

                /*" -970- SUBTRACT 1 FROM WS-IDADE. */
                W.WS_IDADE.Value = W.WS_IDADE - 1;
            }


            /*" -973- MOVE WS-IDADE TO LD01-IDADESINI LD02-IDADESINI. */
            _.Move(W.WS_IDADE, W.LD01.LD01_IDADESINI, W.LD02.LD02_IDADESINI);

            /*" -975- WRITE REG-SI0029R1 FROM LD01. */
            _.Move(W.LD01.GetMoveValues(), REG_SI0029R1);

            SI0029R1.Write(REG_SI0029R1.GetMoveValues().ToString());

            /*" -976- PERFORM 030-DECLARE-V0ACOMSINI THRU 030-EXIT. */

            M_030_DECLARE_V0ACOMSINI(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_030_EXIT*/


            /*" -977- MOVE 'NAO' TO WFIM-V0ACOMSINI. */
            _.Move("NAO", W.WFIM_V0ACOMSINI);

            /*" -979- PERFORM 031-FETCH-V0ACOMSINI THRU 031-EXIT. */

            M_031_FETCH_V0ACOMSINI(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_031_EXIT*/


            /*" -982- PERFORM 035-PROCESSA-V0ACOMSINI THRU 035-EXIT UNTIL (WFIM-V0ACOMSINI EQUAL 'SIM' ). */

            while (!((W.WFIM_V0ACOMSINI == "SIM")))
            {

                M_035_PROCESSA_V0ACOMSINI(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_035_EXIT*/

            }

            /*" -982- PERFORM 011-FETCH-PRINCIPAL THRU 011-EXIT. */

            M_011_FETCH_PRINCIPAL(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_011_EXIT*/


        }

        [StopWatch]
        /*" M-020-PROCESSA-PRINCIPAL-DB-SELECT-1 */
        public void M_020_PROCESSA_PRINCIPAL_DB_SELECT_1()
        {
            /*" -868- EXEC SQL SELECT VALUE(SUM(VAL_OPERACAO),0) INTO :V0HIST-VAL-OPERACAO FROM SEGUROS.V0HISTSINI WHERE NUM_APOL_SINISTRO = :V0MEST-NUM-APOL-SINISTRO AND OPERACAO IN (1081,1082,1083,1084) AND SITUACAO <> '2' END-EXEC. */

            var m_020_PROCESSA_PRINCIPAL_DB_SELECT_1_Query1 = new M_020_PROCESSA_PRINCIPAL_DB_SELECT_1_Query1()
            {
                V0MEST_NUM_APOL_SINISTRO = V0MEST_NUM_APOL_SINISTRO.ToString(),
            };

            var executed_1 = M_020_PROCESSA_PRINCIPAL_DB_SELECT_1_Query1.Execute(m_020_PROCESSA_PRINCIPAL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0HIST_VAL_OPERACAO, V0HIST_VAL_OPERACAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_020_EXIT*/

        [StopWatch]
        /*" M-020-PROCESSA-PRINCIPAL-DB-SELECT-2 */
        public void M_020_PROCESSA_PRINCIPAL_DB_SELECT_2()
        {
            /*" -888- EXEC SQL SELECT MAX(DTMOVTO) INTO :V0HIST-DTMOVTO FROM SEGUROS.V0HISTSINI WHERE NUM_APOL_SINISTRO = :V0MEST-NUM-APOL-SINISTRO AND OPERACAO IN (1081,1082,1083,1084) AND SITUACAO <> '2' END-EXEC */

            var m_020_PROCESSA_PRINCIPAL_DB_SELECT_2_Query1 = new M_020_PROCESSA_PRINCIPAL_DB_SELECT_2_Query1()
            {
                V0MEST_NUM_APOL_SINISTRO = V0MEST_NUM_APOL_SINISTRO.ToString(),
            };

            var executed_1 = M_020_PROCESSA_PRINCIPAL_DB_SELECT_2_Query1.Execute(m_020_PROCESSA_PRINCIPAL_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0HIST_DTMOVTO, V0HIST_DTMOVTO);
            }


        }

        [StopWatch]
        /*" M-030-DECLARE-V0ACOMSINI */
        private void M_030_DECLARE_V0ACOMSINI(bool isPerform = false)
        {
            /*" -990- MOVE '008' TO WNR-EXEC-SQL. */
            _.Move("008", W.WABEND.WNR_EXEC_SQL);

            /*" -1001- PERFORM M_030_DECLARE_V0ACOMSINI_DB_DECLARE_1 */

            M_030_DECLARE_V0ACOMSINI_DB_DECLARE_1();

            /*" -1003- PERFORM M_030_DECLARE_V0ACOMSINI_DB_OPEN_1 */

            M_030_DECLARE_V0ACOMSINI_DB_OPEN_1();

        }

        [StopWatch]
        /*" M-030-DECLARE-V0ACOMSINI-DB-OPEN-1 */
        public void M_030_DECLARE_V0ACOMSINI_DB_OPEN_1()
        {
            /*" -1003- EXEC SQL OPEN V0ACOMSINI END-EXEC. */

            V0ACOMSINI.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_030_EXIT*/

        [StopWatch]
        /*" M-031-FETCH-V0ACOMSINI */
        private void M_031_FETCH_V0ACOMSINI(bool isPerform = false)
        {
            /*" -1011- MOVE '009' TO WNR-EXEC-SQL. */
            _.Move("009", W.WABEND.WNR_EXEC_SQL);

            /*" -1017- PERFORM M_031_FETCH_V0ACOMSINI_DB_FETCH_1 */

            M_031_FETCH_V0ACOMSINI_DB_FETCH_1();

            /*" -1020- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1021- MOVE 'SIM' TO WFIM-V0ACOMSINI */
                _.Move("SIM", W.WFIM_V0ACOMSINI);

                /*" -1021- PERFORM M_031_FETCH_V0ACOMSINI_DB_CLOSE_1 */

                M_031_FETCH_V0ACOMSINI_DB_CLOSE_1();

                /*" -1023- ELSE */
            }
            else
            {


                /*" -1024- IF (SQLCODE NOT EQUAL ZEROS) AND (SQLCODE NOT EQUAL 100) */

                if ((DB.SQLCODE != 00) && (DB.SQLCODE != 100))
                {

                    /*" -1025- DISPLAY 'ERRO FETCH V0ACOMSINI' */
                    _.Display($"ERRO FETCH V0ACOMSINI");

                    /*" -1025- GO TO 999-999-ROT-ERRO. */

                    M_999_999_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" M-031-FETCH-V0ACOMSINI-DB-FETCH-1 */
        public void M_031_FETCH_V0ACOMSINI_DB_FETCH_1()
        {
            /*" -1017- EXEC SQL FETCH V0ACOMSINI INTO :V0ACOM-OPERACAO , :V0ACOM-DATOPR , :V0ACOM-CODUSU , :V0OPER-DESOPR END-EXEC. */

            if (V0ACOMSINI.Fetch())
            {
                _.Move(V0ACOMSINI.V0ACOM_OPERACAO, V0ACOM_OPERACAO);
                _.Move(V0ACOMSINI.V0ACOM_DATOPR, V0ACOM_DATOPR);
                _.Move(V0ACOMSINI.V0ACOM_CODUSU, V0ACOM_CODUSU);
                _.Move(V0ACOMSINI.V0OPER_DESOPR, V0OPER_DESOPR);
            }

        }

        [StopWatch]
        /*" M-031-FETCH-V0ACOMSINI-DB-CLOSE-1 */
        public void M_031_FETCH_V0ACOMSINI_DB_CLOSE_1()
        {
            /*" -1021- EXEC SQL CLOSE V0ACOMSINI END-EXEC */

            V0ACOMSINI.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_031_EXIT*/

        [StopWatch]
        /*" M-035-PROCESSA-V0ACOMSINI */
        private void M_035_PROCESSA_V0ACOMSINI(bool isPerform = false)
        {
            /*" -1032- MOVE V0ACOM-DATOPR TO W-DATA1 */
            _.Move(V0ACOM_DATOPR, W.W_DATA1);

            /*" -1033- MOVE W-DATA1-AAAA TO W-DATA2-AAAA */
            _.Move(W.W_DATA1.W_DATA1_AAAA, W.W_DATA2.W_DATA2_AAAA);

            /*" -1034- MOVE W-DATA1-MM TO W-DATA2-MM */
            _.Move(W.W_DATA1.W_DATA1_MM, W.W_DATA2.W_DATA2_MM);

            /*" -1035- MOVE W-DATA1-DD TO W-DATA2-DD */
            _.Move(W.W_DATA1.W_DATA1_DD, W.W_DATA2.W_DATA2_DD);

            /*" -1036- MOVE W-DATA2 TO LD02-DATOPR */
            _.Move(W.W_DATA2, W.LD02.LD02_DATOPR);

            /*" -1037- MOVE V0ACOM-OPERACAO TO LD02-CODOPER */
            _.Move(V0ACOM_OPERACAO, W.LD02.LD02_CODOPER);

            /*" -1038- MOVE V0ACOM-CODUSU TO LD02-CODUSU */
            _.Move(V0ACOM_CODUSU, W.LD02.LD02_CODUSU);

            /*" -1039- MOVE V0OPER-DESOPR TO LD02-DESOPR */
            _.Move(V0OPER_DESOPR, W.LD02.LD02_DESOPR);

            /*" -1041- WRITE REG-SI0029R2 FROM LD02. */
            _.Move(W.LD02.GetMoveValues(), REG_SI0029R2);

            SI0029R2.Write(REG_SI0029R2.GetMoveValues().ToString());

            /*" -1041- PERFORM 031-FETCH-V0ACOMSINI THRU 031-EXIT. */

            M_031_FETCH_V0ACOMSINI(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_031_EXIT*/


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_035_EXIT*/

        [StopWatch]
        /*" M-999-999-ROT-ERRO-SECTION */
        private void M_999_999_ROT_ERRO_SECTION()
        {
            /*" -1051- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1052- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, W.WABEND.WSQLCODE);

                /*" -1053- MOVE SQLERRD(1) TO WSQLCODE1 */
                _.Move(DB.SQLERRD[1], W.WABEND.WSQLCODE1);

                /*" -1055- MOVE SQLERRD(2) TO WSQLCODE2 */
                _.Move(DB.SQLERRD[2], W.WABEND.WSQLCODE2);

                /*" -1056- DISPLAY WABEND */
                _.Display(W.WABEND);

                /*" -1057- DISPLAY ' ' */
                _.Display($" ");

                /*" -1058- DISPLAY SQLERRML ' ' SQLERRMC */

                $"SQLERRML {DB.SQLERRMC}"
                .Display();

                /*" -1065- DISPLAY SQLERRD (1) ' ' SQLERRD (2) ' ' SQLERRD (3) ' ' SQLERRD (4) ' ' SQLERRD (5) ' ' SQLERRD (6). */

                $"{DB.SQLERRD[1]} {DB.SQLERRD[2]} {DB.SQLERRD[3]} {DB.SQLERRD[4]} {DB.SQLERRD[5]} {DB.SQLERRD[6]}"
                .Display();
            }


            /*" -1066- CLOSE SI0029R1 SI0029R2. */
            SI0029R1.Close();
            SI0029R2.Close();

            /*" -1066- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -1067- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -1069- MOVE 99 TO RETURN-CODE */
            _.Move(99, RETURN_CODE);

            /*" -1069- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_999_999_EXIT_ROT_ERRO*/
    }
}