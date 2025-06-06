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
using Sias.VidaAzul.DB2.VA0126B;

namespace Code
{
    public class VA0126B
    {
        public bool IsCall { get; set; }

        public VA0126B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *=================================================================      */
        /*"      *                                                                       */
        /*"      * FUNCAO .....: SENSIBILIZACAO SIGPF DOS CERTIFICADOS PESSOA            */
        /*"      *               FISICA ANTECIPADOS QUE MIGRARAM P/MENSAL (VA0123B)      */
        /*"      *               AFINS DE ALTERAR A PERIODICIDADE DE PAGAMENTO DE        */
        /*"      *               ANUAL (12) PARA MENSAL (1).                             */
        /*"      *                                                                       */
        /*"      *               O PROGRAMA GERA ARQUIVO DE PROPOSTAS (REG 1 E 3).       */
        /*"      *                                                                       */
        /*"      *               CONTROLE DE EXECUCAO VIA TABELA RELATORIOS.             */
        /*"      *                                                                       */
        /*"      * DATA .......: 28/07/2014.                                             */
        /*"      * CADMUS .....: 100.458                                                 */
        /*"      *                                                                       */
        /*"      *=================================================================      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 01 -   NSGD - CADMUS 103659.                          *      */
        /*"      *               - NOVA SOLUCAO DE GESTAO DE DEPOSITOS            *      */
        /*"      *                                                                *      */
        /*"      *   EM 02/11/2014 - COREON                                       *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.01         *      */
        /*"      *                                                                *      */
        /*"      *=================================================================      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 02   - AJUSTE PARA ENVIO DE PROPOSTA COM STATUS DA    *      */
        /*"      *                 PROPOSTA FIDELIZ, POIS AS PROPOSTAS ENVIADAS   *      */
        /*"      *                 ESTAVAM ALTENRANDO PARA STATUS MAN NO SIGPF    *      */
        /*"      *                                                                *      */
        /*"      *   EM 22/11/2024 - THIAGO BLAIER                                *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.02         *      */
        /*"      *                                                                *      */
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
        /*"01   REG-PRP-SASSE              PIC X(300).*/
        public StringBasis REG_PRP_SASSE { get; set; } = new StringBasis(new PIC("X", "300", "X(300)."), @"");

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"01  WHOST-DATA-REFERENCIA       PIC  X(10).*/
        public StringBasis WHOST_DATA_REFERENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  VIND-RCAP                   PIC S9(04)  COMP VALUE +0.*/
        public IntBasis VIND_RCAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  VIND-DTNASCI                PIC S9(04)  COMP VALUE +0.*/
        public IntBasis VIND_DTNASCI { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  VIND-VAL-IOCC               PIC S9(04)  COMP VALUE +0.*/
        public IntBasis VIND_VAL_IOCC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  VIND-VAL-RCAP               PIC S9(04)  COMP VALUE +0.*/
        public IntBasis VIND_VAL_RCAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  VIND-DATA-RCAP              PIC S9(04)  COMP VALUE +0.*/
        public IntBasis VIND_DATA_RCAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  VIND-AGE-COBRANCA           PIC S9(04)  COMP VALUE +0.*/
        public IntBasis VIND_AGE_COBRANCA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  VIND-AGECTADEB              PIC S9(04)  COMP VALUE +0.*/
        public IntBasis VIND_AGECTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  VIND-OPRCTADEB              PIC S9(04)  COMP VALUE +0.*/
        public IntBasis VIND_OPRCTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  VIND-NUMCTADEB              PIC S9(04)  COMP VALUE +0.*/
        public IntBasis VIND_NUMCTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  VIND-DIGCTADEB              PIC S9(04)  COMP VALUE +0.*/
        public IntBasis VIND_DIGCTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  VIND-APOS-INVALIDEZ         PIC S9(04)  COMP VALUE +0.*/
        public IntBasis VIND_APOS_INVALIDEZ { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  VIND-NOME-ESPOSA            PIC S9(04)  COMP VALUE +0.*/
        public IntBasis VIND_NOME_ESPOSA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  VIND-PROFIS-ESPOSA          PIC S9(04)  COMP VALUE +0.*/
        public IntBasis VIND_PROFIS_ESPOSA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  VIND-DPS-TITULAR            PIC S9(04)  COMP VALUE +0.*/
        public IntBasis VIND_DPS_TITULAR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  VIND-DPS-ESPOSA             PIC S9(04)  COMP VALUE +0.*/
        public IntBasis VIND_DPS_ESPOSA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  VIND-COD-ORIGEM-PROP        PIC S9(04)  COMP VALUE +0.*/
        public IntBasis VIND_COD_ORIGEM_PROP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  VIND-FAIXA-RENDA-IND        PIC S9(04)  COMP VALUE +0.*/
        public IntBasis VIND_FAIXA_RENDA_IND { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  VIND-FAIXA-RENDA-FAM        PIC S9(04)  COMP VALUE +0.*/
        public IntBasis VIND_FAIXA_RENDA_FAM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  VIND-DTNASC-ESPOSA          PIC S9(04)  COMP VALUE +0.*/
        public IntBasis VIND_DTNASC_ESPOSA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  VIND-NUM-MATRICULA          PIC S9(04)  COMP VALUE +0.*/
        public IntBasis VIND_NUM_MATRICULA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  VIND-NUM-PRAZO-FIN          PIC S9(04)  COMP VALUE +0.*/
        public IntBasis VIND_NUM_PRAZO_FIN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  VIND-STA-ANTECIPACAO        PIC S9(04)  COMP VALUE +0.*/
        public IntBasis VIND_STA_ANTECIPACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  VIND-STA-MUDANCA            PIC S9(04)  COMP VALUE +0.*/
        public IntBasis VIND_STA_MUDANCA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  VIND-IMPSEGAUXF             PIC S9(04)  COMP VALUE +0.*/
        public IntBasis VIND_IMPSEGAUXF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  VIND-VLCUSTAUXF             PIC S9(04)  COMP VALUE +0.*/
        public IntBasis VIND_VLCUSTAUXF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  VIND-PRMDIT                 PIC S9(04)  COMP VALUE +0.*/
        public IntBasis VIND_PRMDIT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  VIND-QTMDIT                 PIC S9(04)  COMP VALUE +0.*/
        public IntBasis VIND_QTMDIT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  VIND-COD-UF                 PIC S9(04)  COMP VALUE +0.*/
        public IntBasis VIND_COD_UF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  COD-CBO-TIT                 PIC S9(09)  COMP.*/
        public IntBasis COD_CBO_TIT { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"01  COD-CBO-CONJ                PIC S9(09)  COMP.*/
        public IntBasis COD_CBO_CONJ { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"01  TAB-FILIAIS.*/
        public VA0126B_TAB_FILIAIS TAB_FILIAIS { get; set; } = new VA0126B_TAB_FILIAIS();
        public class VA0126B_TAB_FILIAIS : VarBasis
        {
            /*"    05  FILLER   OCCURS   9999  TIMES.*/
            public ListBasis<VA0126B_FILLER_0> FILLER_0 { get; set; } = new ListBasis<VA0126B_FILLER_0>(9999);
            public class VA0126B_FILLER_0 : VarBasis
            {
                /*"        15  TAB-AGENCIA         PIC  9(04).*/
                public IntBasis TAB_AGENCIA { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                /*"        15  TAB-FONTE           PIC  9(04).*/
                public IntBasis TAB_FONTE { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                /*"01  W-FIM-MOVIMENTO             PIC  X(03)  VALUE SPACES.*/
            }
        }
        public StringBasis W_FIM_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"");
        /*"01  WFIM-AGENCEF                PIC  X(01)  VALUE ' '.*/
        public StringBasis WFIM_AGENCEF { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
        /*"01  WFIM-ENDERECOS              PIC  X(01)  VALUE ' '.*/
        public StringBasis WFIM_ENDERECOS { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
        /*"01  W-TIME                      PIC  X(08).*/
        public StringBasis W_TIME { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
        /*"01  W-TIME-EDIT                 PIC  99.99.99.99.*/
        public IntBasis W_TIME_EDIT { get; set; } = new IntBasis(new PIC("9", "8", "99.99.99.99."));
        /*"01  W-DESPREZADO                PIC  9(08)  VALUE ZEROS.*/
        public IntBasis W_DESPREZADO { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
        /*"01  W-CANCELADO                 PIC  9(08)  VALUE ZEROS.*/
        public IntBasis W_CANCELADO { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
        /*"01  W-NAO-MIGRADO               PIC  9(08)  VALUE ZEROS.*/
        public IntBasis W_NAO_MIGRADO { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
        /*"01  W-ORIGEM-12                 PIC  9(08)  VALUE ZEROS.*/
        public IntBasis W_ORIGEM_12 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
        /*"01  W-PROCESSADO                PIC  9(08)  VALUE ZEROS.*/
        public IntBasis W_PROCESSADO { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
        /*"01  W-DATA-ULT-VA0126B          PIC  X(10).*/
        public StringBasis W_DATA_ULT_VA0126B { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  W-QTD-LD-TIPO-0             PIC  9(08)  VALUE ZEROS.*/
        public IntBasis W_QTD_LD_TIPO_0 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
        /*"01  W-QTD-LD-TIPO-1             PIC  9(08)  VALUE ZEROS.*/
        public IntBasis W_QTD_LD_TIPO_1 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
        /*"01  W-QTD-LD-TIPO-2             PIC  9(08)  VALUE ZEROS.*/
        public IntBasis W_QTD_LD_TIPO_2 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
        /*"01  W-QTD-LD-TIPO-3             PIC  9(08)  VALUE ZEROS.*/
        public IntBasis W_QTD_LD_TIPO_3 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
        /*"01  W-QTD-LD-TIPO-4             PIC  9(08)  VALUE ZEROS.*/
        public IntBasis W_QTD_LD_TIPO_4 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
        /*"01  W-QTD-LD-TIPO-5             PIC  9(08)  VALUE ZEROS.*/
        public IntBasis W_QTD_LD_TIPO_5 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
        /*"01  W-QTD-LD-TIPO-6             PIC  9(08)  VALUE ZEROS.*/
        public IntBasis W_QTD_LD_TIPO_6 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
        /*"01  W-QTD-LD-TIPO-7             PIC  9(08)  VALUE ZEROS.*/
        public IntBasis W_QTD_LD_TIPO_7 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
        /*"01  W-QTD-LD-TIPO-8             PIC  9(08)  VALUE ZEROS.*/
        public IntBasis W_QTD_LD_TIPO_8 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
        /*"01  W-QTD-LD-TIPO-9             PIC  9(08)  VALUE ZEROS.*/
        public IntBasis W_QTD_LD_TIPO_9 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
        /*"01  W-QTD-LD-TIPO-A             PIC  9(08)  VALUE ZEROS.*/
        public IntBasis W_QTD_LD_TIPO_A { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
        /*"01  W-QTD-LD-TIPO-B             PIC  9(08)  VALUE ZEROS.*/
        public IntBasis W_QTD_LD_TIPO_B { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
        /*"01  W-QTD-LD-TIPO-C             PIC  9(08)  VALUE ZEROS.*/
        public IntBasis W_QTD_LD_TIPO_C { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
        /*"01  W-QTD-LD-TIPO-D             PIC  9(08)  VALUE ZEROS.*/
        public IntBasis W_QTD_LD_TIPO_D { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
        /*"01  W-QTD-LD-TIPO-E             PIC  9(08)  VALUE ZEROS.*/
        public IntBasis W_QTD_LD_TIPO_E { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
        /*"01  W-QTD-LD-TIPO-F             PIC  9(08)  VALUE ZEROS.*/
        public IntBasis W_QTD_LD_TIPO_F { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
        /*"01  W-QTD-LD-TIPO-G             PIC  9(08)  VALUE ZEROS.*/
        public IntBasis W_QTD_LD_TIPO_G { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
        /*"01  W-QTD-LD-TIPO-H             PIC  9(08)  VALUE ZEROS.*/
        public IntBasis W_QTD_LD_TIPO_H { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
        /*"01  W-QTD-LD-TIPO-I             PIC  9(08)  VALUE ZEROS.*/
        public IntBasis W_QTD_LD_TIPO_I { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
        /*"01  W-QTD-LD-TIPO-J             PIC  9(08)  VALUE ZEROS.*/
        public IntBasis W_QTD_LD_TIPO_J { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
        /*"01  W-TOT-GERADO-PRP            PIC  9(08)  VALUE ZEROS.*/
        public IntBasis W_TOT_GERADO_PRP { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
        /*"01  W-LIDOS                     PIC  9(08)  VALUE ZEROS.*/
        public IntBasis W_LIDOS { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
        /*"01  W-CONTROLE                  PIC  9(06)  VALUE ZEROS.*/
        public IntBasis W_CONTROLE { get; set; } = new IntBasis(new PIC("9", "6", "9(06)"));
        /*"01  W-DATA-TRABALHO             PIC  9(08)  VALUE ZEROS.*/
        public IntBasis W_DATA_TRABALHO { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
        /*"01  FILLER REDEFINES W-DATA-TRABALHO.*/
        private _REDEF_VA0126B_FILLER_1 _filler_1 { get; set; }
        public _REDEF_VA0126B_FILLER_1 FILLER_1
        {
            get { _filler_1 = new _REDEF_VA0126B_FILLER_1(); _.Move(W_DATA_TRABALHO, _filler_1); VarBasis.RedefinePassValue(W_DATA_TRABALHO, _filler_1, W_DATA_TRABALHO); _filler_1.ValueChanged += () => { _.Move(_filler_1, W_DATA_TRABALHO); }; return _filler_1; }
            set { VarBasis.RedefinePassValue(value, _filler_1, W_DATA_TRABALHO); }
        }  //Redefines
        public class _REDEF_VA0126B_FILLER_1 : VarBasis
        {
            /*"    03  W-DIA-TRABALHO          PIC  9(02).*/
            public IntBasis W_DIA_TRABALHO { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
            /*"    03  W-MES-TRABALHO          PIC  9(02).*/
            public IntBasis W_MES_TRABALHO { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
            /*"    03  W-ANO-TRABALHO          PIC  9(04).*/
            public IntBasis W_ANO_TRABALHO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
            /*"01  W-DTMOVABE                  PIC  X(10).*/

            public _REDEF_VA0126B_FILLER_1()
            {
                W_DIA_TRABALHO.ValueChanged += OnValueChanged;
                W_MES_TRABALHO.ValueChanged += OnValueChanged;
                W_ANO_TRABALHO.ValueChanged += OnValueChanged;
            }

        }
        public StringBasis W_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  W-DTMOVABE1 REDEFINES W-DTMOVABE.*/
        private _REDEF_VA0126B_W_DTMOVABE1 _w_dtmovabe1 { get; set; }
        public _REDEF_VA0126B_W_DTMOVABE1 W_DTMOVABE1
        {
            get { _w_dtmovabe1 = new _REDEF_VA0126B_W_DTMOVABE1(); _.Move(W_DTMOVABE, _w_dtmovabe1); VarBasis.RedefinePassValue(W_DTMOVABE, _w_dtmovabe1, W_DTMOVABE); _w_dtmovabe1.ValueChanged += () => { _.Move(_w_dtmovabe1, W_DTMOVABE); }; return _w_dtmovabe1; }
            set { VarBasis.RedefinePassValue(value, _w_dtmovabe1, W_DTMOVABE); }
        }  //Redefines
        public class _REDEF_VA0126B_W_DTMOVABE1 : VarBasis
        {
            /*"    03  W-ANO-MOVABE            PIC  9(04).*/
            public IntBasis W_ANO_MOVABE { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
            /*"    03  W-BARRA1                PIC  X(01).*/
            public StringBasis W_BARRA1 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    03  W-MES-MOVABE            PIC  9(02).*/
            public IntBasis W_MES_MOVABE { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
            /*"    03  W-BARRA2                PIC  X(01).*/
            public StringBasis W_BARRA2 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    03  W-DIA-MOVABE            PIC  9(02).*/
            public IntBasis W_DIA_MOVABE { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
            /*"01  W-DTMOVABE-I                PIC  X(10).*/

            public _REDEF_VA0126B_W_DTMOVABE1()
            {
                W_ANO_MOVABE.ValueChanged += OnValueChanged;
                W_BARRA1.ValueChanged += OnValueChanged;
                W_MES_MOVABE.ValueChanged += OnValueChanged;
                W_BARRA2.ValueChanged += OnValueChanged;
                W_DIA_MOVABE.ValueChanged += OnValueChanged;
            }

        }
        public StringBasis W_DTMOVABE_I { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  W-DTMOVABE-I1 REDEFINES W-DTMOVABE-I.*/
        private _REDEF_VA0126B_W_DTMOVABE_I1 _w_dtmovabe_i1 { get; set; }
        public _REDEF_VA0126B_W_DTMOVABE_I1 W_DTMOVABE_I1
        {
            get { _w_dtmovabe_i1 = new _REDEF_VA0126B_W_DTMOVABE_I1(); _.Move(W_DTMOVABE_I, _w_dtmovabe_i1); VarBasis.RedefinePassValue(W_DTMOVABE_I, _w_dtmovabe_i1, W_DTMOVABE_I); _w_dtmovabe_i1.ValueChanged += () => { _.Move(_w_dtmovabe_i1, W_DTMOVABE_I); }; return _w_dtmovabe_i1; }
            set { VarBasis.RedefinePassValue(value, _w_dtmovabe_i1, W_DTMOVABE_I); }
        }  //Redefines
        public class _REDEF_VA0126B_W_DTMOVABE_I1 : VarBasis
        {
            /*"    03  W-DIA-MOVABE            PIC  9(02).*/
            public IntBasis W_DIA_MOVABE_0 { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
            /*"    03  W-BARRA1                PIC  X(01).*/
            public StringBasis W_BARRA1_0 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    03  W-MES-MOVABE            PIC  9(02).*/
            public IntBasis W_MES_MOVABE_0 { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
            /*"    03  W-BARRA2                PIC  X(01).*/
            public StringBasis W_BARRA2_0 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    03  W-ANO-MOVABE            PIC  9(04).*/
            public IntBasis W_ANO_MOVABE_0 { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
            /*"01  W-DATA-SQL                  PIC  X(10).*/

            public _REDEF_VA0126B_W_DTMOVABE_I1()
            {
                W_DIA_MOVABE_0.ValueChanged += OnValueChanged;
                W_BARRA1_0.ValueChanged += OnValueChanged;
                W_MES_MOVABE_0.ValueChanged += OnValueChanged;
                W_BARRA2_0.ValueChanged += OnValueChanged;
                W_ANO_MOVABE_0.ValueChanged += OnValueChanged;
            }

        }
        public StringBasis W_DATA_SQL { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  W-DATA-SQL1 REDEFINES W-DATA-SQL.*/
        private _REDEF_VA0126B_W_DATA_SQL1 _w_data_sql1 { get; set; }
        public _REDEF_VA0126B_W_DATA_SQL1 W_DATA_SQL1
        {
            get { _w_data_sql1 = new _REDEF_VA0126B_W_DATA_SQL1(); _.Move(W_DATA_SQL, _w_data_sql1); VarBasis.RedefinePassValue(W_DATA_SQL, _w_data_sql1, W_DATA_SQL); _w_data_sql1.ValueChanged += () => { _.Move(_w_data_sql1, W_DATA_SQL); }; return _w_data_sql1; }
            set { VarBasis.RedefinePassValue(value, _w_data_sql1, W_DATA_SQL); }
        }  //Redefines
        public class _REDEF_VA0126B_W_DATA_SQL1 : VarBasis
        {
            /*"    03  W-ANO-SQL               PIC  9(04).*/
            public IntBasis W_ANO_SQL { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
            /*"    03  W-BARRA1                PIC  X(01).*/
            public StringBasis W_BARRA1_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    03  W-MES-SQL               PIC  9(02).*/
            public IntBasis W_MES_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
            /*"    03  W-BARRA2                PIC  X(01).*/
            public StringBasis W_BARRA2_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    03  W-DIA-SQL               PIC  9(02).*/
            public IntBasis W_DIA_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
            /*"01  W-NUM-PROPOSTA              PIC  9(14).*/

            public _REDEF_VA0126B_W_DATA_SQL1()
            {
                W_ANO_SQL.ValueChanged += OnValueChanged;
                W_BARRA1_1.ValueChanged += OnValueChanged;
                W_MES_SQL.ValueChanged += OnValueChanged;
                W_BARRA2_1.ValueChanged += OnValueChanged;
                W_DIA_SQL.ValueChanged += OnValueChanged;
            }

        }
        public IntBasis W_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "14", "9(14)."));
        /*"01  CANAL  REDEFINES  W-NUM-PROPOSTA.*/
        private _REDEF_VA0126B_CANAL _canal { get; set; }
        public _REDEF_VA0126B_CANAL CANAL
        {
            get { _canal = new _REDEF_VA0126B_CANAL(); _.Move(W_NUM_PROPOSTA, _canal); VarBasis.RedefinePassValue(W_NUM_PROPOSTA, _canal, W_NUM_PROPOSTA); _canal.ValueChanged += () => { _.Move(_canal, W_NUM_PROPOSTA); }; return _canal; }
            set { VarBasis.RedefinePassValue(value, _canal, W_NUM_PROPOSTA); }
        }  //Redefines
        public class _REDEF_VA0126B_CANAL : VarBasis
        {
            /*"    03  W-CANAL-PROPOSTA        PIC  9(01).*/

            public SelectorBasis W_CANAL_PROPOSTA { get; set; } = new SelectorBasis("01")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 CANAL-VENDA-PAPEL         VALUE 0. */
							new SelectorItemBasis("CANAL_VENDA_PAPEL", "0"),
							/*" 88 CANAL-VENDA-CEF           VALUE 1. */
							new SelectorItemBasis("CANAL_VENDA_CEF", "1"),
							/*" 88 CANAL-SASSE-FILIAL        VALUE 2. */
							new SelectorItemBasis("CANAL_SASSE_FILIAL", "2"),
							/*" 88 CANAL-CORRETOR            VALUE 3. */
							new SelectorItemBasis("CANAL_CORRETOR", "3"),
							/*" 88 CANAL-CORREIO             VALUE 4. */
							new SelectorItemBasis("CANAL_CORREIO", "4"),
							/*" 88 CANAL-GITEL               VALUE 5. */
							new SelectorItemBasis("CANAL_GITEL", "5"),
							/*" 88 CANAL-INTERNET            VALUE 7. */
							new SelectorItemBasis("CANAL_INTERNET", "7"),
							/*" 88 CANAL-INTRANET            VALUE 8. */
							new SelectorItemBasis("CANAL_INTRANET", "8")
                }
            };

            /*"    03  FILLER                  PIC  X(13).*/
            public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "13", "X(13)."), @"");
            /*"01  W-RCAPS                     PIC  9(01) VALUE ZERO.*/

            public _REDEF_VA0126B_CANAL()
            {
                W_CANAL_PROPOSTA.ValueChanged += OnValueChanged;
                FILLER_2.ValueChanged += OnValueChanged;
            }

        }

        public SelectorBasis W_RCAPS { get; set; } = new SelectorBasis("01", "ZERO")
        {
            Items = new List<SelectorItemBasis> {
                            /*" 88 RCAP-CADASTRADO                     VALUE 1. */
							new SelectorItemBasis("RCAP_CADASTRADO", "1"),
							/*" 88 RCAP-N-CADASTRADO                   VALUE 2. */
							new SelectorItemBasis("RCAP_N_CADASTRADO", "2")
                }
        };

        /*"01  W-RCAPCOMP                  PIC  9(01) VALUE ZERO.*/

        public SelectorBasis W_RCAPCOMP { get; set; } = new SelectorBasis("01", "ZERO")
        {
            Items = new List<SelectorItemBasis> {
                            /*" 88 RCAPCOMP-CADASTRADO                 VALUE 1. */
							new SelectorItemBasis("RCAPCOMP_CADASTRADO", "1"),
							/*" 88 RCAPCOMP-N-CADASTRADO               VALUE 2. */
							new SelectorItemBasis("RCAPCOMP_N_CADASTRADO", "2")
                }
        };

        /*"01  W-CLIENTE                   PIC  9(01) VALUE ZERO.*/

        public SelectorBasis W_CLIENTE { get; set; } = new SelectorBasis("01", "ZERO")
        {
            Items = new List<SelectorItemBasis> {
                            /*" 88 CLIENTE-CADASTRADO                  VALUE 1. */
							new SelectorItemBasis("CLIENTE_CADASTRADO", "1"),
							/*" 88 CLIENTE-NAO-CADASTRADO              VALUE 2. */
							new SelectorItemBasis("CLIENTE_NAO_CADASTRADO", "2")
                }
        };

        /*"01  W-ENDERECO                  PIC  9(01) VALUE ZERO.*/

        public SelectorBasis W_ENDERECO { get; set; } = new SelectorBasis("01", "ZERO")
        {
            Items = new List<SelectorItemBasis> {
                            /*" 88 ENDERECO-CADASTRADO                 VALUE 1. */
							new SelectorItemBasis("ENDERECO_CADASTRADO", "1"),
							/*" 88 ENDERECO-NAO-CADASTRADO             VALUE 2. */
							new SelectorItemBasis("ENDERECO_NAO_CADASTRADO", "2")
                }
        };

        /*"01  W-SUBGRUPO                  PIC  9(01) VALUE ZERO.*/

        public SelectorBasis W_SUBGRUPO { get; set; } = new SelectorBasis("01", "ZERO")
        {
            Items = new List<SelectorItemBasis> {
                            /*" 88 SUBGRUPO-CADASTRADO                 VALUE 1. */
							new SelectorItemBasis("SUBGRUPO_CADASTRADO", "1"),
							/*" 88 SUBGRUPO-NAO-CADASTRADO             VALUE 2. */
							new SelectorItemBasis("SUBGRUPO_NAO_CADASTRADO", "2")
                }
        };

        /*"01  W-COBERTURAS                PIC  9(01) VALUE ZERO.*/

        public SelectorBasis W_COBERTURAS { get; set; } = new SelectorBasis("01", "ZERO")
        {
            Items = new List<SelectorItemBasis> {
                            /*" 88 COBERTURA-CADASTRADA                VALUE 1. */
							new SelectorItemBasis("COBERTURA_CADASTRADA", "1"),
							/*" 88 COBERTURA-NAO-CADASTRADA            VALUE 2. */
							new SelectorItemBasis("COBERTURA_NAO_CADASTRADA", "2")
                }
        };

        /*"01  W-OPCAOPAG                  PIC  9(01) VALUE ZERO.*/

        public SelectorBasis W_OPCAOPAG { get; set; } = new SelectorBasis("01", "ZERO")
        {
            Items = new List<SelectorItemBasis> {
                            /*" 88 OPCAO-PAG-CADASTRADA                VALUE 1. */
							new SelectorItemBasis("OPCAO_PAG_CADASTRADA", "1"),
							/*" 88 OPCAO-PAG-NAO-CADASTRADA            VALUE 2. */
							new SelectorItemBasis("OPCAO_PAG_NAO_CADASTRADA", "2")
                }
        };

        /*"01  W-PROPFIDEL                 PIC  9(01) VALUE ZERO.*/

        public SelectorBasis W_PROPFIDEL { get; set; } = new SelectorBasis("01", "ZERO")
        {
            Items = new List<SelectorItemBasis> {
                            /*" 88 PROPO-FID-CADASTRADA                VALUE 1. */
							new SelectorItemBasis("PROPO_FID_CADASTRADA", "1"),
							/*" 88 PROPO-FID-NAO-CADASTRADA            VALUE 2. */
							new SelectorItemBasis("PROPO_FID_NAO_CADASTRADA", "2")
                }
        };

        /*"01  W-OBTER-DADOS-RG            PIC  9(01) VALUE ZERO.*/

        public SelectorBasis W_OBTER_DADOS_RG { get; set; } = new SelectorBasis("01", "ZERO")
        {
            Items = new List<SelectorItemBasis> {
                            /*" 88 OBTEVE-DADOS-RG                     VALUE 1. */
							new SelectorItemBasis("OBTEVE_DADOS_RG", "1")
                }
        };

        /*"01  W-NOM-ORGAO-EXP             PIC X(30).*/
        public StringBasis W_NOM_ORGAO_EXP { get; set; } = new StringBasis(new PIC("X", "30", "X(30)."), @"");
        /*"01  FILLER REDEFINES W-NOM-ORGAO-EXP.*/
        private _REDEF_VA0126B_FILLER_3 _filler_3 { get; set; }
        public _REDEF_VA0126B_FILLER_3 FILLER_3
        {
            get { _filler_3 = new _REDEF_VA0126B_FILLER_3(); _.Move(W_NOM_ORGAO_EXP, _filler_3); VarBasis.RedefinePassValue(W_NOM_ORGAO_EXP, _filler_3, W_NOM_ORGAO_EXP); _filler_3.ValueChanged += () => { _.Move(_filler_3, W_NOM_ORGAO_EXP); }; return _filler_3; }
            set { VarBasis.RedefinePassValue(value, _filler_3, W_NOM_ORGAO_EXP); }
        }  //Redefines
        public class _REDEF_VA0126B_FILLER_3 : VarBasis
        {
            /*"    03 W-ORGAO-EXPEDIDOR        PIC X(05).*/
            public StringBasis W_ORGAO_EXPEDIDOR { get; set; } = new StringBasis(new PIC("X", "5", "X(05)."), @"");
            /*"    03 FILLER                   PIC X(25).*/
            public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "25", "X(25)."), @"");
            /*"01  WABEND1.*/

            public _REDEF_VA0126B_FILLER_3()
            {
                W_ORGAO_EXPEDIDOR.ValueChanged += OnValueChanged;
                FILLER_4.ValueChanged += OnValueChanged;
            }

        }
        public VA0126B_WABEND1 WABEND1 { get; set; } = new VA0126B_WABEND1();
        public class VA0126B_WABEND1 : VarBasis
        {
            /*"    03  FILLER                  PIC X(010)    VALUE        'VA0126B  '.*/
            public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"VA0126B  ");
            /*"    03  FILLER                  PIC X(028)    VALUE        ' *** ERRO  EXEC SQL *** '.*/
            public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @" *** ERRO  EXEC SQL *** ");
            /*"    03  FILLER                  PIC X(014)    VALUE        '    SQLCODE = '.*/
            public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE = ");
            /*"    03  WSQLCODE                PIC ZZZZ999-  VALUE ZEROS.*/
            public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
            /*"    03  FILLER                  PIC X(014)    VALUE        '   SQLERRD1 = '.*/
            public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD1 = ");
            /*"    03  WSQLERRD1               PIC ZZZZ999-  VALUE ZEROS.*/
            public IntBasis WSQLERRD1 { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
            /*"    03  FILLER                  PIC X(014)    VALUE        '   SQLERRD2 = '.*/
            public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD2 = ");
            /*"    03  WSQLERRD2               PIC ZZZZ999-  VALUE ZEROS.*/
            public IntBasis WSQLERRD2 { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
            /*"01  WABEND2.*/
        }
        public VA0126B_WABEND2 WABEND2 { get; set; } = new VA0126B_WABEND2();
        public class VA0126B_WABEND2 : VarBasis
        {
            /*"    03  FILLER                  PIC X(010)    VALUE SPACES.*/
            public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"    03  FILLER                  PIC X(012)    VALUE        'PARAGRAFO = '.*/
            public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"PARAGRAFO = ");
            /*"    03  PARAGRAFO               PIC X(040)    VALUE SPACES.*/
            public StringBasis PARAGRAFO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
            /*"    03  FILLER                  PIC X(012)    VALUE        'COMANDO   = '.*/
            public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"COMANDO   = ");
            /*"    03  COMANDO                 PIC X(060)    VALUE SPACES.*/
            public StringBasis COMANDO { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"");
        }


        public Copies.LBFPF990 LBFPF990 { get; set; } = new Copies.LBFPF990();
        public Copies.LBFPF011 LBFPF011 { get; set; } = new Copies.LBFPF011();
        public Copies.LBFPF012 LBFPF012 { get; set; } = new Copies.LBFPF012();
        public Copies.LXFCT004 LXFCT004 { get; set; } = new Copies.LXFCT004();
        public Copies.LBFPF991 LBFPF991 { get; set; } = new Copies.LBFPF991();
        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.RELATORI RELATORI { get; set; } = new Dclgens.RELATORI();
        public Dclgens.TARIBCEF TARIBCEF { get; set; } = new Dclgens.TARIBCEF();
        public Dclgens.FDCOMVA FDCOMVA { get; set; } = new Dclgens.FDCOMVA();
        public Dclgens.GEDOCCLI GEDOCCLI { get; set; } = new Dclgens.GEDOCCLI();
        public Dclgens.PRDSIVPF PRDSIVPF { get; set; } = new Dclgens.PRDSIVPF();
        public Dclgens.PROPOVA PROPOVA { get; set; } = new Dclgens.PROPOVA();
        public Dclgens.CBO CBO { get; set; } = new Dclgens.CBO();
        public Dclgens.OPCPAGVI OPCPAGVI { get; set; } = new Dclgens.OPCPAGVI();
        public Dclgens.HISCOBPR HISCOBPR { get; set; } = new Dclgens.HISCOBPR();
        public Dclgens.CLIENTES CLIENTES { get; set; } = new Dclgens.CLIENTES();
        public Dclgens.ENDERECO ENDERECO { get; set; } = new Dclgens.ENDERECO();
        public Dclgens.RCAPS RCAPS { get; set; } = new Dclgens.RCAPS();
        public Dclgens.RCAPCOMP RCAPCOMP { get; set; } = new Dclgens.RCAPCOMP();
        public Dclgens.AGENCEF AGENCEF { get; set; } = new Dclgens.AGENCEF();
        public Dclgens.MALHACEF MALHACEF { get; set; } = new Dclgens.MALHACEF();
        public Dclgens.ARQSIVPF ARQSIVPF { get; set; } = new Dclgens.ARQSIVPF();
        public Dclgens.PROPOFID PROPOFID { get; set; } = new Dclgens.PROPOFID();
        public VA0126B_CUR_MOVTO CUR_MOVTO { get; set; } = new VA0126B_CUR_MOVTO();
        public VA0126B_C01_ENDERECO C01_ENDERECO { get; set; } = new VA0126B_C01_ENDERECO();
        public VA0126B_C01_CBO C01_CBO { get; set; } = new VA0126B_C01_CBO();
        public VA0126B_COBERTURAS COBERTURAS { get; set; } = new VA0126B_COBERTURAS();
        public VA0126B_FUNDOCOMISVA FUNDOCOMISVA { get; set; } = new VA0126B_FUNDOCOMISVA();
        public VA0126B_C01_AGENCEF C01_AGENCEF { get; set; } = new VA0126B_C01_AGENCEF();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string MOVTO_PRP_SASSE_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                MOVTO_PRP_SASSE.SetFile(MOVTO_PRP_SASSE_FILE_NAME_P);

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
            /*" -329- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -330- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -331- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -334- DISPLAY '------------------------------' */
            _.Display($"------------------------------");

            /*" -335- DISPLAY 'PROGRAMA EM EXECUCAO VA0126B  ' */
            _.Display($"PROGRAMA EM EXECUCAO VA0126B  ");

            /*" -336- DISPLAY '                              ' */
            _.Display($"                              ");

            /*" -338- DISPLAY 'VERSAO V.01 NSGD    02/11/2014' */
            _.Display($"VERSAO V.01 NSGD    02/11/2014");

            /*" -340- DISPLAY '------------------------------' . */
            _.Display($"------------------------------");

            /*" -348- DISPLAY 'VA0126B - INICIO  EM ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2). */

            $"VA0126B - INICIO  EM {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
            .Display();

            /*" -350- DISPLAY ' ' . */
            _.Display($" ");

            /*" -351- PERFORM R0001-00-INICIALIZAR */

            R0001_00_INICIALIZAR_SECTION();

            /*" -352- PERFORM R0005-00-OBTER-DATA-DIA */

            R0005_00_OBTER_DATA_DIA_SECTION();

            /*" -353- PERFORM R0010-00-BUSCA-ULT-VA0126B */

            R0010_00_BUSCA_ULT_VA0126B_SECTION();

            /*" -354- PERFORM R0050-00-SELECIONA-MOVTO */

            R0050_00_SELECIONA_MOVTO_SECTION();

            /*" -356- PERFORM R0070-00-LER-MOVTO. */

            R0070_00_LER_MOVTO_SECTION();

            /*" -357- IF W-FIM-MOVIMENTO EQUAL 'FIM' */

            if (W_FIM_MOVIMENTO == "FIM")
            {

                /*" -358- DISPLAY 'VA0126B - NAO HOUVE MOVIMENTO' */
                _.Display($"VA0126B - NAO HOUVE MOVIMENTO");

                /*" -359- MOVE ZEROS TO RT-QTDE-TOTAL OF REG-TRAILLER */
                _.Move(0, LBFPF991.REG_TRAILLER.RT_QTDE_TOTAL);

                /*" -360- ELSE */
            }
            else
            {


                /*" -361- OPEN OUTPUT MOVTO-PRP-SASSE */
                MOVTO_PRP_SASSE.Open(REG_PRP_SASSE);

                /*" -362- INITIALIZE REG-TRAILLER */
                _.Initialize(
                    LBFPF991.REG_TRAILLER
                );

                /*" -363- MOVE ZEROS TO RT-QTDE-TOTAL OF REG-TRAILLER */
                _.Move(0, LBFPF991.REG_TRAILLER.RT_QTDE_TOTAL);

                /*" -365- PERFORM R0080-00-GERAR-HEADER */

                R0080_00_GERAR_HEADER_SECTION();

                /*" -368- PERFORM R0150-00-PROCESSAR-MOVIMENTO UNTIL W-FIM-MOVIMENTO EQUAL 'FIM' */

                while (!(W_FIM_MOVIMENTO == "FIM"))
                {

                    R0150_00_PROCESSAR_MOVIMENTO_SECTION();
                }

                /*" -369- PERFORM R1000-00-GERAR-TRAILLER */

                R1000_00_GERAR_TRAILLER_SECTION();

                /*" -370- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -372- END-IF. */
            }


            /*" -373- PERFORM R1100-00-GERAR-TOTAIS. */

            R1100_00_GERAR_TOTAIS_SECTION();

            /*" -374- PERFORM R1200-00-GRAVA-RELATORIO. */

            R1200_00_GRAVA_RELATORIO_SECTION();

            /*" -374- PERFORM R9999-00-FINALIZAR. */

            R9999_00_FINALIZAR_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_SAIDA*/

        [StopWatch]
        /*" R0001-00-INICIALIZAR-SECTION */
        private void R0001_00_INICIALIZAR_SECTION()
        {
            /*" -384- MOVE ZEROS TO TAB-FILIAIS. */
            _.Move(0, TAB_FILIAIS);

            /*" -385- PERFORM R6000-00-DECLARE-AGENCEF. */

            R6000_00_DECLARE_AGENCEF_SECTION();

            /*" -387- PERFORM R6010-00-FETCH-AGENCEF. */

            R6010_00_FETCH_AGENCEF_SECTION();

            /*" -388- PERFORM R6020-00-CARREGA-FILIAL UNTIL WFIM-AGENCEF EQUAL 'S' . */

            while (!(WFIM_AGENCEF == "S"))
            {

                R6020_00_CARREGA_FILIAL_SECTION();
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0001_SAIDA*/

        [StopWatch]
        /*" R0005-00-OBTER-DATA-DIA-SECTION */
        private void R0005_00_OBTER_DATA_DIA_SECTION()
        {
            /*" -398- MOVE 'R0005-00-OBTER-DATA-DIA' TO PARAGRAFO. */
            _.Move("R0005-00-OBTER-DATA-DIA", WABEND2.PARAGRAFO);

            /*" -400- MOVE 'SELECT SISTEMAS' TO COMANDO. */
            _.Move("SELECT SISTEMAS", WABEND2.COMANDO);

            /*" -402- MOVE 'VA' TO SISTEMAS-IDE-SISTEMA */
            _.Move("VA", SISTEMAS.DCLSISTEMAS.SISTEMAS_IDE_SISTEMA);

            /*" -410- PERFORM R0005_00_OBTER_DATA_DIA_DB_SELECT_1 */

            R0005_00_OBTER_DATA_DIA_DB_SELECT_1();

            /*" -413- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -414- DISPLAY 'VA0126B - ERRO SELECT SISTEMAS' */
                _.Display($"VA0126B - ERRO SELECT SISTEMAS");

                /*" -415- PERFORM R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION();

                /*" -417- END-IF. */
            }


            /*" -420- MOVE SISTEMAS-DATA-MOV-ABERTO OF DCLSISTEMAS TO W-DTMOVABE. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, W_DTMOVABE);

            /*" -423- MOVE W-DIA-MOVABE OF W-DTMOVABE1 TO W-DIA-MOVABE OF W-DTMOVABE-I1. */
            _.Move(W_DTMOVABE1.W_DIA_MOVABE, W_DTMOVABE_I1.W_DIA_MOVABE_0);

            /*" -426- MOVE W-MES-MOVABE OF W-DTMOVABE1 TO W-MES-MOVABE OF W-DTMOVABE-I1. */
            _.Move(W_DTMOVABE1.W_MES_MOVABE, W_DTMOVABE_I1.W_MES_MOVABE_0);

            /*" -429- MOVE W-ANO-MOVABE OF W-DTMOVABE1 TO W-ANO-MOVABE OF W-DTMOVABE-I1. */
            _.Move(W_DTMOVABE1.W_ANO_MOVABE, W_DTMOVABE_I1.W_ANO_MOVABE_0);

            /*" -431- MOVE '-' TO W-BARRA1 OF W-DTMOVABE-I1 W-BARRA2 OF W-DTMOVABE-I1. */
            _.Move("-", W_DTMOVABE_I1.W_BARRA1_0);
            _.Move("-", W_DTMOVABE_I1.W_BARRA2_0);


        }

        [StopWatch]
        /*" R0005-00-OBTER-DATA-DIA-DB-SELECT-1 */
        public void R0005_00_OBTER_DATA_DIA_DB_SELECT_1()
        {
            /*" -410- EXEC SQL SELECT DATA_MOV_ABERTO, DATA_MOV_ABERTO INTO :SISTEMAS-DATA-MOV-ABERTO ,:WHOST-DATA-REFERENCIA FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = :SISTEMAS-IDE-SISTEMA WITH UR END-EXEC. */

            var r0005_00_OBTER_DATA_DIA_DB_SELECT_1_Query1 = new R0005_00_OBTER_DATA_DIA_DB_SELECT_1_Query1()
            {
                SISTEMAS_IDE_SISTEMA = SISTEMAS.DCLSISTEMAS.SISTEMAS_IDE_SISTEMA.ToString(),
            };

            var executed_1 = R0005_00_OBTER_DATA_DIA_DB_SELECT_1_Query1.Execute(r0005_00_OBTER_DATA_DIA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);
                _.Move(executed_1.WHOST_DATA_REFERENCIA, WHOST_DATA_REFERENCIA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0005_SAIDA*/

        [StopWatch]
        /*" R0010-00-BUSCA-ULT-VA0126B-SECTION */
        private void R0010_00_BUSCA_ULT_VA0126B_SECTION()
        {
            /*" -441- MOVE 'R0010-00-BUSCA-ULT-VA0126B' TO PARAGRAFO. */
            _.Move("R0010-00-BUSCA-ULT-VA0126B", WABEND2.PARAGRAFO);

            /*" -443- MOVE 'SELECT RELATORIO' TO COMANDO. */
            _.Move("SELECT RELATORIO", WABEND2.COMANDO);

            /*" -444- MOVE 'VA0126B' TO RELATORI-COD-USUARIO */
            _.Move("VA0126B", RELATORI.DCLRELATORIOS.RELATORI_COD_USUARIO);

            /*" -446- MOVE 'VA' TO RELATORI-IDE-SISTEMA */
            _.Move("VA", RELATORI.DCLRELATORIOS.RELATORI_IDE_SISTEMA);

            /*" -453- PERFORM R0010_00_BUSCA_ULT_VA0126B_DB_SELECT_1 */

            R0010_00_BUSCA_ULT_VA0126B_DB_SELECT_1();

            /*" -456- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -458- MOVE RELATORI-DATA-SOLICITACAO TO W-DATA-ULT-VA0126B */
                _.Move(RELATORI.DCLRELATORIOS.RELATORI_DATA_SOLICITACAO, W_DATA_ULT_VA0126B);

                /*" -459- ELSE */
            }
            else
            {


                /*" -460- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -461- MOVE '0001-01-01' TO W-DATA-ULT-VA0126B */
                    _.Move("0001-01-01", W_DATA_ULT_VA0126B);

                    /*" -462- ELSE */
                }
                else
                {


                    /*" -463- DISPLAY 'VA0126B - ERRO SELECT RELATORIOS' */
                    _.Display($"VA0126B - ERRO SELECT RELATORIOS");

                    /*" -465- DISPLAY '          COD-USUARIO = ' RELATORI-COD-USUARIO */
                    _.Display($"          COD-USUARIO = {RELATORI.DCLRELATORIOS.RELATORI_COD_USUARIO}");

                    /*" -467- DISPLAY '          IDE_SISTEMA = ' RELATORI-IDE-SISTEMA */
                    _.Display($"          IDE_SISTEMA = {RELATORI.DCLRELATORIOS.RELATORI_IDE_SISTEMA}");

                    /*" -468- PERFORM R9999-00-FINALIZAR */

                    R9999_00_FINALIZAR_SECTION();

                    /*" -469- END-IF */
                }


                /*" -469- END-IF. */
            }


        }

        [StopWatch]
        /*" R0010-00-BUSCA-ULT-VA0126B-DB-SELECT-1 */
        public void R0010_00_BUSCA_ULT_VA0126B_DB_SELECT_1()
        {
            /*" -453- EXEC SQL SELECT DATA_SOLICITACAO INTO :RELATORI-DATA-SOLICITACAO FROM SEGUROS.RELATORIOS WHERE COD_USUARIO = :RELATORI-COD-USUARIO AND IDE_SISTEMA = :RELATORI-IDE-SISTEMA WITH UR END-EXEC. */

            var r0010_00_BUSCA_ULT_VA0126B_DB_SELECT_1_Query1 = new R0010_00_BUSCA_ULT_VA0126B_DB_SELECT_1_Query1()
            {
                RELATORI_COD_USUARIO = RELATORI.DCLRELATORIOS.RELATORI_COD_USUARIO.ToString(),
                RELATORI_IDE_SISTEMA = RELATORI.DCLRELATORIOS.RELATORI_IDE_SISTEMA.ToString(),
            };

            var executed_1 = R0010_00_BUSCA_ULT_VA0126B_DB_SELECT_1_Query1.Execute(r0010_00_BUSCA_ULT_VA0126B_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.RELATORI_DATA_SOLICITACAO, RELATORI.DCLRELATORIOS.RELATORI_DATA_SOLICITACAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0010_SAIDA*/

        [StopWatch]
        /*" R0050-00-SELECIONA-MOVTO-SECTION */
        private void R0050_00_SELECIONA_MOVTO_SECTION()
        {
            /*" -478- MOVE 'R0050-00-SELECIONA-MOVTO' TO PARAGRAFO. */
            _.Move("R0050-00-SELECIONA-MOVTO", WABEND2.PARAGRAFO);

            /*" -483- MOVE 'DECLARE CUR-MOVTO' TO COMANDO. */
            _.Move("DECLARE CUR-MOVTO", WABEND2.COMANDO);

            /*" -484- MOVE 'VA0123B' TO RELATORI-COD-USUARIO */
            _.Move("VA0123B", RELATORI.DCLRELATORIOS.RELATORI_COD_USUARIO);

            /*" -485- MOVE 'VA' TO RELATORI-IDE-SISTEMA */
            _.Move("VA", RELATORI.DCLRELATORIOS.RELATORI_IDE_SISTEMA);

            /*" -486- MOVE 'VLNXA' TO RELATORI-COD-RELATORIO */
            _.Move("VLNXA", RELATORI.DCLRELATORIOS.RELATORI_COD_RELATORIO);

            /*" -487- MOVE '1' TO RELATORI-SIT-REGISTRO */
            _.Move("1", RELATORI.DCLRELATORIOS.RELATORI_SIT_REGISTRO);

            /*" -489- MOVE 1 TO RELATORI-NUM-COPIAS. */
            _.Move(1, RELATORI.DCLRELATORIOS.RELATORI_NUM_COPIAS);

            /*" -542- PERFORM R0050_00_SELECIONA_MOVTO_DB_DECLARE_1 */

            R0050_00_SELECIONA_MOVTO_DB_DECLARE_1();

            /*" -545- MOVE 'OPEN CUR-MOVTO' TO COMANDO. */
            _.Move("OPEN CUR-MOVTO", WABEND2.COMANDO);

            /*" -545- PERFORM R0050_00_SELECIONA_MOVTO_DB_OPEN_1 */

            R0050_00_SELECIONA_MOVTO_DB_OPEN_1();

            /*" -548- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -549- DISPLAY 'VA0126B - ERRO OPEN CURSOR CUR-MOVTO' */
                _.Display($"VA0126B - ERRO OPEN CURSOR CUR-MOVTO");

                /*" -550- MOVE 'OPEN CUR-MOVTO' TO COMANDO */
                _.Move("OPEN CUR-MOVTO", WABEND2.COMANDO);

                /*" -551- PERFORM R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION();

                /*" -551- END-IF. */
            }


        }

        [StopWatch]
        /*" R0050-00-SELECIONA-MOVTO-DB-DECLARE-1 */
        public void R0050_00_SELECIONA_MOVTO_DB_DECLARE_1()
        {
            /*" -542- EXEC SQL DECLARE CUR-MOVTO CURSOR FOR SELECT COD_USUARIO ,DATA_SOLICITACAO ,IDE_SISTEMA ,COD_RELATORIO ,NUM_COPIAS ,QUANTIDADE ,PERI_INICIAL ,PERI_FINAL ,DATA_REFERENCIA ,MES_REFERENCIA ,ANO_REFERENCIA ,ORGAO_EMISSOR ,COD_FONTE ,COD_PRODUTOR ,RAMO_EMISSOR ,COD_MODALIDADE ,COD_CONGENERE ,NUM_APOLICE ,NUM_ENDOSSO ,NUM_PARCELA ,NUM_CERTIFICADO ,NUM_TITULO ,COD_SUBGRUPO ,COD_OPERACAO ,COD_PLANO ,OCORR_HISTORICO ,NUM_APOL_LIDER ,ENDOS_LIDER ,NUM_PARC_LIDER ,NUM_SINISTRO ,NUM_SINI_LIDER ,NUM_ORDEM ,COD_MOEDA ,TIPO_CORRECAO ,SIT_REGISTRO ,IND_PREV_DEFINIT ,IND_ANAL_RESUMO ,COD_EMPRESA ,PERI_RENOVACAO ,PCT_AUMENTO ,TIMESTAMP FROM SEGUROS.RELATORIOS WHERE COD_USUARIO = :RELATORI-COD-USUARIO AND IDE_SISTEMA = :RELATORI-IDE-SISTEMA AND COD_RELATORIO = :RELATORI-COD-RELATORIO AND SIT_REGISTRO = :RELATORI-SIT-REGISTRO AND NUM_COPIAS = :RELATORI-NUM-COPIAS AND DATA_SOLICITACAO BETWEEN :W-DATA-ULT-VA0126B AND :SISTEMAS-DATA-MOV-ABERTO AND DATA_SOLICITACAO = DATA_REFERENCIA WITH UR END-EXEC. */
            CUR_MOVTO = new VA0126B_CUR_MOVTO(true);
            string GetQuery_CUR_MOVTO()
            {
                var query = @$"SELECT COD_USUARIO 
							,DATA_SOLICITACAO 
							,IDE_SISTEMA 
							,COD_RELATORIO 
							,NUM_COPIAS 
							,QUANTIDADE 
							,PERI_INICIAL 
							,PERI_FINAL 
							,DATA_REFERENCIA 
							,MES_REFERENCIA 
							,ANO_REFERENCIA 
							,ORGAO_EMISSOR 
							,COD_FONTE 
							,COD_PRODUTOR 
							,RAMO_EMISSOR 
							,COD_MODALIDADE 
							,COD_CONGENERE 
							,NUM_APOLICE 
							,NUM_ENDOSSO 
							,NUM_PARCELA 
							,NUM_CERTIFICADO 
							,NUM_TITULO 
							,COD_SUBGRUPO 
							,COD_OPERACAO 
							,COD_PLANO 
							,OCORR_HISTORICO 
							,NUM_APOL_LIDER 
							,ENDOS_LIDER 
							,NUM_PARC_LIDER 
							,NUM_SINISTRO 
							,NUM_SINI_LIDER 
							,NUM_ORDEM 
							,COD_MOEDA 
							,TIPO_CORRECAO 
							,SIT_REGISTRO 
							,IND_PREV_DEFINIT 
							,IND_ANAL_RESUMO 
							,COD_EMPRESA 
							,PERI_RENOVACAO 
							,PCT_AUMENTO 
							,TIMESTAMP 
							FROM SEGUROS.RELATORIOS 
							WHERE COD_USUARIO = '{RELATORI.DCLRELATORIOS.RELATORI_COD_USUARIO}' 
							AND IDE_SISTEMA = '{RELATORI.DCLRELATORIOS.RELATORI_IDE_SISTEMA}' 
							AND COD_RELATORIO = '{RELATORI.DCLRELATORIOS.RELATORI_COD_RELATORIO}' 
							AND SIT_REGISTRO = '{RELATORI.DCLRELATORIOS.RELATORI_SIT_REGISTRO}' 
							AND NUM_COPIAS = '{RELATORI.DCLRELATORIOS.RELATORI_NUM_COPIAS}' 
							AND DATA_SOLICITACAO 
							BETWEEN '{W_DATA_ULT_VA0126B}' 
							AND '{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}' 
							AND DATA_SOLICITACAO = DATA_REFERENCIA";

                return query;
            }
            CUR_MOVTO.GetQueryEvent += GetQuery_CUR_MOVTO;

        }

        [StopWatch]
        /*" R0050-00-SELECIONA-MOVTO-DB-OPEN-1 */
        public void R0050_00_SELECIONA_MOVTO_DB_OPEN_1()
        {
            /*" -545- EXEC SQL OPEN CUR-MOVTO END-EXEC. */

            CUR_MOVTO.Open();

        }

        [StopWatch]
        /*" R0350-00-DECLARE-ENDERECO-DB-DECLARE-1 */
        public void R0350_00_DECLARE_ENDERECO_DB_DECLARE_1()
        {
            /*" -1039- EXEC SQL DECLARE C01_ENDERECO CURSOR FOR SELECT COD_CLIENTE , COD_ENDERECO , OCORR_ENDERECO , ENDERECO , BAIRRO , CIDADE , SIGLA_UF , CEP , DDD , TELEFONE , FAX , TELEX , SIT_REGISTRO FROM SEGUROS.ENDERECOS WHERE COD_CLIENTE = :ENDERECO-COD-CLIENTE AND SIT_REGISTRO = '0' ORDER BY COD_ENDERECO END-EXEC. */
            C01_ENDERECO = new VA0126B_C01_ENDERECO(true);
            string GetQuery_C01_ENDERECO()
            {
                var query = @$"SELECT 
							COD_CLIENTE 
							, COD_ENDERECO 
							, OCORR_ENDERECO 
							, ENDERECO 
							, BAIRRO 
							, CIDADE 
							, SIGLA_UF 
							, CEP 
							, DDD 
							, TELEFONE 
							, FAX 
							, TELEX 
							, SIT_REGISTRO 
							FROM SEGUROS.ENDERECOS 
							WHERE COD_CLIENTE = 
							'{ENDERECO.DCLENDERECOS.ENDERECO_COD_CLIENTE}' 
							AND SIT_REGISTRO = '0' 
							ORDER BY COD_ENDERECO";

                return query;
            }
            C01_ENDERECO.GetQueryEvent += GetQuery_C01_ENDERECO;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0050_SAIDA*/

        [StopWatch]
        /*" R0070-00-LER-MOVTO-SECTION */
        private void R0070_00_LER_MOVTO_SECTION()
        {
            /*" -560- MOVE 'R0070-00-LER-MOVTO' TO PARAGRAFO. */
            _.Move("R0070-00-LER-MOVTO", WABEND2.PARAGRAFO);

            /*" -562- MOVE 'FETCH CUR-MOVTO   ' TO COMANDO. */
            _.Move("FETCH CUR-MOVTO   ", WABEND2.COMANDO);

            /*" -606- PERFORM R0070_00_LER_MOVTO_DB_FETCH_1 */

            R0070_00_LER_MOVTO_DB_FETCH_1();

            /*" -609- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -610- ADD 1 TO W-LIDOS W-CONTROLE */
                W_LIDOS.Value = W_LIDOS + 1;
                W_CONTROLE.Value = W_CONTROLE + 1;

                /*" -611- ELSE */
            }
            else
            {


                /*" -612- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -613- MOVE 'FIM' TO W-FIM-MOVIMENTO */
                    _.Move("FIM", W_FIM_MOVIMENTO);

                    /*" -613- PERFORM R0070_00_LER_MOVTO_DB_CLOSE_1 */

                    R0070_00_LER_MOVTO_DB_CLOSE_1();

                    /*" -615- ELSE */
                }
                else
                {


                    /*" -616- DISPLAY 'VA0126B - ERRO FETCH CURSOR CUR-MOVTO' */
                    _.Display($"VA0126B - ERRO FETCH CURSOR CUR-MOVTO");

                    /*" -617- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -618- PERFORM R9999-00-FINALIZAR */

                    R9999_00_FINALIZAR_SECTION();

                    /*" -619- END-IF */
                }


                /*" -621- END-IF. */
            }


            /*" -622- IF W-CONTROLE > 9999 */

            if (W_CONTROLE > 9999)
            {

                /*" -623- ACCEPT W-TIME FROM TIME */
                _.Move(_.AcceptDate("TIME"), W_TIME);

                /*" -624- MOVE W-TIME TO W-TIME-EDIT */
                _.Move(W_TIME, W_TIME_EDIT);

                /*" -625- MOVE ZEROS TO W-CONTROLE */
                _.Move(0, W_CONTROLE);

                /*" -627- DISPLAY 'VA0126B - REGISTROS LIDOS = ' W-LIDOS ' ' W-TIME-EDIT */

                $"VA0126B - REGISTROS LIDOS = {W_LIDOS} {W_TIME_EDIT}"
                .Display();

                /*" -627- END-IF. */
            }


        }

        [StopWatch]
        /*" R0070-00-LER-MOVTO-DB-FETCH-1 */
        public void R0070_00_LER_MOVTO_DB_FETCH_1()
        {
            /*" -606- EXEC SQL FETCH CUR-MOVTO INTO :RELATORI-COD-USUARIO ,:RELATORI-DATA-SOLICITACAO ,:RELATORI-IDE-SISTEMA ,:RELATORI-COD-RELATORIO ,:RELATORI-NUM-COPIAS ,:RELATORI-QUANTIDADE ,:RELATORI-PERI-INICIAL ,:RELATORI-PERI-FINAL ,:RELATORI-DATA-REFERENCIA ,:RELATORI-MES-REFERENCIA ,:RELATORI-ANO-REFERENCIA ,:RELATORI-ORGAO-EMISSOR ,:RELATORI-COD-FONTE ,:RELATORI-COD-PRODUTOR ,:RELATORI-RAMO-EMISSOR ,:RELATORI-COD-MODALIDADE ,:RELATORI-COD-CONGENERE ,:RELATORI-NUM-APOLICE ,:RELATORI-NUM-ENDOSSO ,:RELATORI-NUM-PARCELA ,:RELATORI-NUM-CERTIFICADO ,:RELATORI-NUM-TITULO ,:RELATORI-COD-SUBGRUPO ,:RELATORI-COD-OPERACAO ,:RELATORI-COD-PLANO ,:RELATORI-OCORR-HISTORICO ,:RELATORI-NUM-APOL-LIDER ,:RELATORI-ENDOS-LIDER ,:RELATORI-NUM-PARC-LIDER ,:RELATORI-NUM-SINISTRO ,:RELATORI-NUM-SINI-LIDER ,:RELATORI-NUM-ORDEM ,:RELATORI-COD-MOEDA ,:RELATORI-TIPO-CORRECAO ,:RELATORI-SIT-REGISTRO ,:RELATORI-IND-PREV-DEFINIT ,:RELATORI-IND-ANAL-RESUMO ,:RELATORI-COD-EMPRESA ,:RELATORI-PERI-RENOVACAO ,:RELATORI-PCT-AUMENTO ,:RELATORI-TIMESTAMP END-EXEC. */

            if (CUR_MOVTO.Fetch())
            {
                _.Move(CUR_MOVTO.RELATORI_COD_USUARIO, RELATORI.DCLRELATORIOS.RELATORI_COD_USUARIO);
                _.Move(CUR_MOVTO.RELATORI_DATA_SOLICITACAO, RELATORI.DCLRELATORIOS.RELATORI_DATA_SOLICITACAO);
                _.Move(CUR_MOVTO.RELATORI_IDE_SISTEMA, RELATORI.DCLRELATORIOS.RELATORI_IDE_SISTEMA);
                _.Move(CUR_MOVTO.RELATORI_COD_RELATORIO, RELATORI.DCLRELATORIOS.RELATORI_COD_RELATORIO);
                _.Move(CUR_MOVTO.RELATORI_NUM_COPIAS, RELATORI.DCLRELATORIOS.RELATORI_NUM_COPIAS);
                _.Move(CUR_MOVTO.RELATORI_QUANTIDADE, RELATORI.DCLRELATORIOS.RELATORI_QUANTIDADE);
                _.Move(CUR_MOVTO.RELATORI_PERI_INICIAL, RELATORI.DCLRELATORIOS.RELATORI_PERI_INICIAL);
                _.Move(CUR_MOVTO.RELATORI_PERI_FINAL, RELATORI.DCLRELATORIOS.RELATORI_PERI_FINAL);
                _.Move(CUR_MOVTO.RELATORI_DATA_REFERENCIA, RELATORI.DCLRELATORIOS.RELATORI_DATA_REFERENCIA);
                _.Move(CUR_MOVTO.RELATORI_MES_REFERENCIA, RELATORI.DCLRELATORIOS.RELATORI_MES_REFERENCIA);
                _.Move(CUR_MOVTO.RELATORI_ANO_REFERENCIA, RELATORI.DCLRELATORIOS.RELATORI_ANO_REFERENCIA);
                _.Move(CUR_MOVTO.RELATORI_ORGAO_EMISSOR, RELATORI.DCLRELATORIOS.RELATORI_ORGAO_EMISSOR);
                _.Move(CUR_MOVTO.RELATORI_COD_FONTE, RELATORI.DCLRELATORIOS.RELATORI_COD_FONTE);
                _.Move(CUR_MOVTO.RELATORI_COD_PRODUTOR, RELATORI.DCLRELATORIOS.RELATORI_COD_PRODUTOR);
                _.Move(CUR_MOVTO.RELATORI_RAMO_EMISSOR, RELATORI.DCLRELATORIOS.RELATORI_RAMO_EMISSOR);
                _.Move(CUR_MOVTO.RELATORI_COD_MODALIDADE, RELATORI.DCLRELATORIOS.RELATORI_COD_MODALIDADE);
                _.Move(CUR_MOVTO.RELATORI_COD_CONGENERE, RELATORI.DCLRELATORIOS.RELATORI_COD_CONGENERE);
                _.Move(CUR_MOVTO.RELATORI_NUM_APOLICE, RELATORI.DCLRELATORIOS.RELATORI_NUM_APOLICE);
                _.Move(CUR_MOVTO.RELATORI_NUM_ENDOSSO, RELATORI.DCLRELATORIOS.RELATORI_NUM_ENDOSSO);
                _.Move(CUR_MOVTO.RELATORI_NUM_PARCELA, RELATORI.DCLRELATORIOS.RELATORI_NUM_PARCELA);
                _.Move(CUR_MOVTO.RELATORI_NUM_CERTIFICADO, RELATORI.DCLRELATORIOS.RELATORI_NUM_CERTIFICADO);
                _.Move(CUR_MOVTO.RELATORI_NUM_TITULO, RELATORI.DCLRELATORIOS.RELATORI_NUM_TITULO);
                _.Move(CUR_MOVTO.RELATORI_COD_SUBGRUPO, RELATORI.DCLRELATORIOS.RELATORI_COD_SUBGRUPO);
                _.Move(CUR_MOVTO.RELATORI_COD_OPERACAO, RELATORI.DCLRELATORIOS.RELATORI_COD_OPERACAO);
                _.Move(CUR_MOVTO.RELATORI_COD_PLANO, RELATORI.DCLRELATORIOS.RELATORI_COD_PLANO);
                _.Move(CUR_MOVTO.RELATORI_OCORR_HISTORICO, RELATORI.DCLRELATORIOS.RELATORI_OCORR_HISTORICO);
                _.Move(CUR_MOVTO.RELATORI_NUM_APOL_LIDER, RELATORI.DCLRELATORIOS.RELATORI_NUM_APOL_LIDER);
                _.Move(CUR_MOVTO.RELATORI_ENDOS_LIDER, RELATORI.DCLRELATORIOS.RELATORI_ENDOS_LIDER);
                _.Move(CUR_MOVTO.RELATORI_NUM_PARC_LIDER, RELATORI.DCLRELATORIOS.RELATORI_NUM_PARC_LIDER);
                _.Move(CUR_MOVTO.RELATORI_NUM_SINISTRO, RELATORI.DCLRELATORIOS.RELATORI_NUM_SINISTRO);
                _.Move(CUR_MOVTO.RELATORI_NUM_SINI_LIDER, RELATORI.DCLRELATORIOS.RELATORI_NUM_SINI_LIDER);
                _.Move(CUR_MOVTO.RELATORI_NUM_ORDEM, RELATORI.DCLRELATORIOS.RELATORI_NUM_ORDEM);
                _.Move(CUR_MOVTO.RELATORI_COD_MOEDA, RELATORI.DCLRELATORIOS.RELATORI_COD_MOEDA);
                _.Move(CUR_MOVTO.RELATORI_TIPO_CORRECAO, RELATORI.DCLRELATORIOS.RELATORI_TIPO_CORRECAO);
                _.Move(CUR_MOVTO.RELATORI_SIT_REGISTRO, RELATORI.DCLRELATORIOS.RELATORI_SIT_REGISTRO);
                _.Move(CUR_MOVTO.RELATORI_IND_PREV_DEFINIT, RELATORI.DCLRELATORIOS.RELATORI_IND_PREV_DEFINIT);
                _.Move(CUR_MOVTO.RELATORI_IND_ANAL_RESUMO, RELATORI.DCLRELATORIOS.RELATORI_IND_ANAL_RESUMO);
                _.Move(CUR_MOVTO.RELATORI_COD_EMPRESA, RELATORI.DCLRELATORIOS.RELATORI_COD_EMPRESA);
                _.Move(CUR_MOVTO.RELATORI_PERI_RENOVACAO, RELATORI.DCLRELATORIOS.RELATORI_PERI_RENOVACAO);
                _.Move(CUR_MOVTO.RELATORI_PCT_AUMENTO, RELATORI.DCLRELATORIOS.RELATORI_PCT_AUMENTO);
                _.Move(CUR_MOVTO.RELATORI_TIMESTAMP, RELATORI.DCLRELATORIOS.RELATORI_TIMESTAMP);
            }

        }

        [StopWatch]
        /*" R0070-00-LER-MOVTO-DB-CLOSE-1 */
        public void R0070_00_LER_MOVTO_DB_CLOSE_1()
        {
            /*" -613- EXEC SQL CLOSE CUR-MOVTO END-EXEC */

            CUR_MOVTO.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0070_SAIDA*/

        [StopWatch]
        /*" R0080-00-GERAR-HEADER-SECTION */
        private void R0080_00_GERAR_HEADER_SECTION()
        {
            /*" -636- MOVE 'R0080-00-GERAR-HEADER' TO PARAGRAFO. */
            _.Move("R0080-00-GERAR-HEADER", WABEND2.PARAGRAFO);

            /*" -640- MOVE 'WRITE REG-HEADER' TO COMANDO. */
            _.Move("WRITE REG-HEADER", WABEND2.COMANDO);

            /*" -643- MOVE 'H' TO RH-TIPO-REG OF REG-HEADER */
            _.Move("H", LBFPF990.REG_HEADER.RH_TIPO_REG);

            /*" -646- MOVE 'PRPSASSE' TO RH-NOME OF REG-HEADER */
            _.Move("PRPSASSE", LBFPF990.REG_HEADER.RH_NOME);

            /*" -649- MOVE W-DIA-MOVABE OF W-DTMOVABE1 TO W-DIA-TRABALHO. */
            _.Move(W_DTMOVABE1.W_DIA_MOVABE, FILLER_1.W_DIA_TRABALHO);

            /*" -652- MOVE W-MES-MOVABE OF W-DTMOVABE1 TO W-MES-TRABALHO. */
            _.Move(W_DTMOVABE1.W_MES_MOVABE, FILLER_1.W_MES_TRABALHO);

            /*" -655- MOVE W-ANO-MOVABE OF W-DTMOVABE1 TO W-ANO-TRABALHO. */
            _.Move(W_DTMOVABE1.W_ANO_MOVABE, FILLER_1.W_ANO_TRABALHO);

            /*" -658- MOVE W-DATA-TRABALHO TO RH-DATA-GERACAO OF REG-HEADER. */
            _.Move(W_DATA_TRABALHO, LBFPF990.REG_HEADER.RH_DATA_GERACAO);

            /*" -661- MOVE 4 TO RH-SIST-ORIGEM OF REG-HEADER. */
            _.Move(4, LBFPF990.REG_HEADER.RH_SIST_ORIGEM);

            /*" -664- MOVE 1 TO RH-SIST-DESTINO OF REG-HEADER. */
            _.Move(1, LBFPF990.REG_HEADER.RH_SIST_DESTINO);

            /*" -667- MOVE 000001 TO RH-NSAS OF REG-HEADER. */
            _.Move(000001, LBFPF990.REG_HEADER.RH_NSAS);

            /*" -670- MOVE 1 TO RH-TIPO-ARQUIVO OF REG-HEADER. */
            _.Move(1, LBFPF990.REG_HEADER.RH_TIPO_ARQUIVO);

            /*" -670- WRITE REG-PRP-SASSE FROM REG-HEADER. */
            _.Move(LBFPF990.REG_HEADER.GetMoveValues(), REG_PRP_SASSE);

            MOVTO_PRP_SASSE.Write(REG_PRP_SASSE.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0080_SAIDA*/

        [StopWatch]
        /*" R0150-00-PROCESSAR-MOVIMENTO-SECTION */
        private void R0150_00_PROCESSAR_MOVIMENTO_SECTION()
        {
            /*" -679- MOVE 'R0150-00-PROCESSAR-MOVIMENTO' TO PARAGRAFO. */
            _.Move("R0150-00-PROCESSAR-MOVIMENTO", WABEND2.PARAGRAFO);

            /*" -681- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND2.COMANDO);

            /*" -683- MOVE 'N' TO WFIM-ENDERECOS. */
            _.Move("N", WFIM_ENDERECOS);

            /*" -685- PERFORM R0170-00-LER-CERTIFICADO */

            R0170_00_LER_CERTIFICADO_SECTION();

            /*" -686- IF VIND-COD-ORIGEM-PROP LESS ZEROS */

            if (VIND_COD_ORIGEM_PROP < 00)
            {

                /*" -689- MOVE ZEROS TO PROPOVA-COD-ORIGEM-PROPOSTA. */
                _.Move(0, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_ORIGEM_PROPOSTA);
            }


            /*" -690- IF VIND-COD-ORIGEM-PROP EQUAL 12 */

            if (VIND_COD_ORIGEM_PROP == 12)
            {

                /*" -691- ADD 1 TO W-ORIGEM-12 */
                W_ORIGEM_12.Value = W_ORIGEM_12 + 1;

                /*" -694- GO TO R0150-LEITURA. */

                R0150_LEITURA(); //GOTO
                return;
            }


            /*" -695- IF PROPOVA-SIT-REGISTRO NOT EQUAL '3' AND '6' */

            if (!PROPOVA.DCLPROPOSTAS_VA.PROPOVA_SIT_REGISTRO.In("3", "6"))
            {

                /*" -696- ADD 1 TO W-CANCELADO */
                W_CANCELADO.Value = W_CANCELADO + 1;

                /*" -699- GO TO R0150-LEITURA. */

                R0150_LEITURA(); //GOTO
                return;
            }


            /*" -702- IF PROPOVA-STA-ANTECIPACAO EQUAL 'N' AND PROPOVA-STA-MUDANCA-PLANO EQUAL 'S' NEXT SENTENCE */

            if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_STA_ANTECIPACAO == "N" && PROPOVA.DCLPROPOSTAS_VA.PROPOVA_STA_MUDANCA_PLANO == "S")
            {

                /*" -703- ELSE */
            }
            else
            {


                /*" -704- ADD 1 TO W-NAO-MIGRADO */
                W_NAO_MIGRADO.Value = W_NAO_MIGRADO + 1;

                /*" -706- GO TO R0150-LEITURA. */

                R0150_LEITURA(); //GOTO
                return;
            }


            /*" -708- PERFORM R0200-00-LER-RCAPS */

            R0200_00_LER_RCAPS_SECTION();

            /*" -709- IF RCAP-N-CADASTRADO */

            if (W_RCAPS["RCAP_N_CADASTRADO"])
            {

                /*" -710- ADD 1 TO W-DESPREZADO */
                W_DESPREZADO.Value = W_DESPREZADO + 1;

                /*" -712- DISPLAY 'VA0126B - CERTIFICADO SEM RCAP = ' PROPOVA-NUM-CERTIFICADO */
                _.Display($"VA0126B - CERTIFICADO SEM RCAP = {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                /*" -714- GO TO R0150-LEITURA. */

                R0150_LEITURA(); //GOTO
                return;
            }


            /*" -716- PERFORM R0300-00-LER-CLIENTE */

            R0300_00_LER_CLIENTE_SECTION();

            /*" -717- IF CLIENTE-NAO-CADASTRADO */

            if (W_CLIENTE["CLIENTE_NAO_CADASTRADO"])
            {

                /*" -718- ADD 1 TO W-DESPREZADO */
                W_DESPREZADO.Value = W_DESPREZADO + 1;

                /*" -719- DISPLAY 'VA0126B - CLIENTE NAO CADASTRADO' */
                _.Display($"VA0126B - CLIENTE NAO CADASTRADO");

                /*" -721- DISPLAY '          CERTIFICADO = ' PROPOVA-NUM-CERTIFICADO */
                _.Display($"          CERTIFICADO = {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                /*" -723- DISPLAY '          CLIENTE     = ' PROPOVA-COD-CLIENTE */
                _.Display($"          CLIENTE     = {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_CLIENTE}");

                /*" -725- GO TO R0150-LEITURA. */

                R0150_LEITURA(); //GOTO
                return;
            }


            /*" -726- IF CLIENTES-CGCCPF EQUAL ZEROS */

            if (CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF == 00)
            {

                /*" -727- ADD 1 TO W-DESPREZADO */
                W_DESPREZADO.Value = W_DESPREZADO + 1;

                /*" -728- DISPLAY 'VA0126B - CLIENTE SEM CNPJ' */
                _.Display($"VA0126B - CLIENTE SEM CNPJ");

                /*" -730- DISPLAY '          CERTIFICADO = ' PROPOVA-NUM-CERTIFICADO */
                _.Display($"          CERTIFICADO = {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                /*" -732- DISPLAY '          CLIENTE     = ' PROPOVA-COD-CLIENTE */
                _.Display($"          CLIENTE     = {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_CLIENTE}");

                /*" -734- GO TO R0150-LEITURA. */

                R0150_LEITURA(); //GOTO
                return;
            }


            /*" -737- PERFORM R0350-00-DECLARE-ENDERECO. */

            R0350_00_DECLARE_ENDERECO_SECTION();

            /*" -739- PERFORM R0370-00-LER-ENDERECO. */

            R0370_00_LER_ENDERECO_SECTION();

            /*" -740- PERFORM R0400-00-LER-PROFISSAO */

            R0400_00_LER_PROFISSAO_SECTION();

            /*" -741- PERFORM R0450-00-LER-PRODUTOS-SIVPF */

            R0450_00_LER_PRODUTOS_SIVPF_SECTION();

            /*" -743- PERFORM R0450-00-OBTER-COBERTURA. */

            R0450_00_OBTER_COBERTURA_SECTION();

            /*" -744- IF COBERTURA-NAO-CADASTRADA */

            if (W_COBERTURAS["COBERTURA_NAO_CADASTRADA"])
            {

                /*" -745- ADD 1 TO W-DESPREZADO */
                W_DESPREZADO.Value = W_DESPREZADO + 1;

                /*" -746- DISPLAY 'VA0126B - COBERTURA NAO CADASTRADA ' */
                _.Display($"VA0126B - COBERTURA NAO CADASTRADA ");

                /*" -748- DISPLAY '          CERTIFICADO = ' PROPOVA-NUM-CERTIFICADO */
                _.Display($"          CERTIFICADO = {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                /*" -750- GO TO R0150-LEITURA. */

                R0150_LEITURA(); //GOTO
                return;
            }


            /*" -752- PERFORM R0500-00-OBTER-OPCAOPAG. */

            R0500_00_OBTER_OPCAOPAG_SECTION();

            /*" -753- IF OPCAO-PAG-NAO-CADASTRADA */

            if (W_OPCAOPAG["OPCAO_PAG_NAO_CADASTRADA"])
            {

                /*" -754- ADD 1 TO W-DESPREZADO */
                W_DESPREZADO.Value = W_DESPREZADO + 1;

                /*" -755- DISPLAY 'VA0126B - OPCAOPAG NAO CADASTRADA' */
                _.Display($"VA0126B - OPCAOPAG NAO CADASTRADA");

                /*" -757- DISPLAY '          CERTIFICADO = ' PROPOVA-NUM-CERTIFICADO */
                _.Display($"          CERTIFICADO = {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                /*" -759- GO TO R0150-LEITURA. */

                R0150_LEITURA(); //GOTO
                return;
            }


            /*" -760- PERFORM R0570-00-LER-COMISSAO */

            R0570_00_LER_COMISSAO_SECTION();

            /*" -761- PERFORM R0580-00-OBTER-VAL-TARIFA. */

            R0580_00_OBTER_VAL_TARIFA_SECTION();

            /*" -763- PERFORM R0590-00-LER-PROPOSTA-FIDELIZ. */

            R0590_00_LER_PROPOSTA_FIDELIZ_SECTION();

            /*" -764- IF PROPO-FID-NAO-CADASTRADA */

            if (W_PROPFIDEL["PROPO_FID_NAO_CADASTRADA"])
            {

                /*" -765- ADD 1 TO W-DESPREZADO */
                W_DESPREZADO.Value = W_DESPREZADO + 1;

                /*" -766- DISPLAY 'VA0126B - PROPOSTA FIDELIZ NAO CADASTRADA' */
                _.Display($"VA0126B - PROPOSTA FIDELIZ NAO CADASTRADA");

                /*" -768- DISPLAY '          CERTIFICADO = ' PROPOVA-NUM-CERTIFICADO */
                _.Display($"          CERTIFICADO = {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                /*" -772- GO TO R0150-LEITURA. */

                R0150_LEITURA(); //GOTO
                return;
            }


            /*" -773- PERFORM R0600-00-PROPOSTA-REGISTRO-TP1. */

            R0600_00_PROPOSTA_REGISTRO_TP1_SECTION();

            /*" -773- PERFORM R0700-00-PROPOSTA-REGISTRO-TP3. */

            R0700_00_PROPOSTA_REGISTRO_TP3_SECTION();

            /*" -0- FLUXCONTROL_PERFORM R0150_LEITURA */

            R0150_LEITURA();

        }

        [StopWatch]
        /*" R0150-LEITURA */
        private void R0150_LEITURA(bool isPerform = false)
        {
            /*" -777- PERFORM R0070-00-LER-MOVTO. */

            R0070_00_LER_MOVTO_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0150_SAIDA*/

        [StopWatch]
        /*" R0170-00-LER-CERTIFICADO-SECTION */
        private void R0170_00_LER_CERTIFICADO_SECTION()
        {
            /*" -787- MOVE 'R0170-00-LER-CERTIFICADO' TO PARAGRAFO. */
            _.Move("R0170-00-LER-CERTIFICADO", WABEND2.PARAGRAFO);

            /*" -789- MOVE 'SELECT PROPOSTA' TO COMANDO. */
            _.Move("SELECT PROPOSTA", WABEND2.COMANDO);

            /*" -885- PERFORM R0170_00_LER_CERTIFICADO_DB_SELECT_1 */

            R0170_00_LER_CERTIFICADO_DB_SELECT_1();

            /*" -888- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -889- DISPLAY 'VA0126B - CERTIFICADO SEM PROPOSTA_VA' */
                _.Display($"VA0126B - CERTIFICADO SEM PROPOSTA_VA");

                /*" -891- DISPLAY '          CERTIFICADO = ' RELATORI-NUM-CERTIFICADO */
                _.Display($"          CERTIFICADO = {RELATORI.DCLRELATORIOS.RELATORI_NUM_CERTIFICADO}");

                /*" -892- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -893- PERFORM R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION();

                /*" -893- END-IF. */
            }


        }

        [StopWatch]
        /*" R0170-00-LER-CERTIFICADO-DB-SELECT-1 */
        public void R0170_00_LER_CERTIFICADO_DB_SELECT_1()
        {
            /*" -885- EXEC SQL SELECT NUM_CERTIFICADO , COD_PRODUTO , COD_CLIENTE , OCOREND , COD_FONTE , AGE_COBRANCA , OPCAO_COBERTURA , DATA_QUITACAO , COD_AGE_VENDEDOR , OPE_CONTA_VENDEDOR , NUM_CONTA_VENDEDOR , DIG_CONTA_VENDEDOR , NUM_MATRI_VENDEDOR , COD_OPERACAO , PROFISSAO , DTINCLUS , DATA_MOVIMENTO , SIT_REGISTRO , NUM_APOLICE , COD_SUBGRUPO , OCORR_HISTORICO , NRPRIPARATZ , QTDPARATZ , DTPROXVEN , NUM_PARCELA , DATA_VENCIMENTO , SIT_INTERFACE , DTFENAE , COD_USUARIO , TIMESTAMP , IDADE , IDE_SEXO , ESTADO_CIVIL , APOS_INVALIDEZ , NOME_ESPOSA , DTNASC_ESPOSA , PROFIS_ESPOSA , DPS_TITULAR , DPS_ESPOSA , NUM_MATRICULA , FAIXA_RENDA_IND , FAIXA_RENDA_FAM , COD_ORIGEM_PROPOSTA , NUM_PRAZO_FIN , STA_ANTECIPACAO , STA_MUDANCA_PLANO INTO :PROPOVA-NUM-CERTIFICADO ,:PROPOVA-COD-PRODUTO ,:PROPOVA-COD-CLIENTE ,:PROPOVA-OCOREND ,:PROPOVA-COD-FONTE ,:PROPOVA-AGE-COBRANCA ,:PROPOVA-OPCAO-COBERTURA ,:PROPOVA-DATA-QUITACAO ,:PROPOVA-COD-AGE-VENDEDOR ,:PROPOVA-OPE-CONTA-VENDEDOR ,:PROPOVA-NUM-CONTA-VENDEDOR ,:PROPOVA-DIG-CONTA-VENDEDOR ,:PROPOVA-NUM-MATRI-VENDEDOR ,:PROPOVA-COD-OPERACAO ,:PROPOVA-PROFISSAO ,:PROPOVA-DTINCLUS ,:PROPOVA-DATA-MOVIMENTO ,:PROPOVA-SIT-REGISTRO ,:PROPOVA-NUM-APOLICE ,:PROPOVA-COD-SUBGRUPO ,:PROPOVA-OCORR-HISTORICO ,:PROPOVA-NRPRIPARATZ ,:PROPOVA-QTDPARATZ ,:PROPOVA-DTPROXVEN ,:PROPOVA-NUM-PARCELA ,:PROPOVA-DATA-VENCIMENTO ,:PROPOVA-SIT-INTERFACE ,:PROPOVA-DTFENAE ,:PROPOVA-COD-USUARIO ,:PROPOVA-TIMESTAMP ,:PROPOVA-IDADE ,:PROPOVA-IDE-SEXO ,:PROPOVA-ESTADO-CIVIL ,:PROPOVA-APOS-INVALIDEZ:VIND-APOS-INVALIDEZ ,:PROPOVA-NOME-ESPOSA:VIND-NOME-ESPOSA ,:PROPOVA-DTNASC-ESPOSA:VIND-DTNASC-ESPOSA ,:PROPOVA-PROFIS-ESPOSA:VIND-PROFIS-ESPOSA ,:PROPOVA-DPS-TITULAR:VIND-DPS-TITULAR ,:PROPOVA-DPS-ESPOSA:VIND-DPS-ESPOSA ,:PROPOVA-NUM-MATRICULA:VIND-NUM-MATRICULA ,:PROPOVA-FAIXA-RENDA-IND:VIND-FAIXA-RENDA-IND ,:PROPOVA-FAIXA-RENDA-FAM:VIND-FAIXA-RENDA-FAM ,:PROPOVA-COD-ORIGEM-PROPOSTA :VIND-COD-ORIGEM-PROP ,:PROPOVA-NUM-PRAZO-FIN:VIND-NUM-PRAZO-FIN ,:PROPOVA-STA-ANTECIPACAO:VIND-STA-ANTECIPACAO ,:PROPOVA-STA-MUDANCA-PLANO:VIND-STA-MUDANCA FROM SEGUROS.PROPOSTAS_VA WHERE NUM_CERTIFICADO = :RELATORI-NUM-CERTIFICADO END-EXEC. */

            var r0170_00_LER_CERTIFICADO_DB_SELECT_1_Query1 = new R0170_00_LER_CERTIFICADO_DB_SELECT_1_Query1()
            {
                RELATORI_NUM_CERTIFICADO = RELATORI.DCLRELATORIOS.RELATORI_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = R0170_00_LER_CERTIFICADO_DB_SELECT_1_Query1.Execute(r0170_00_LER_CERTIFICADO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PROPOVA_NUM_CERTIFICADO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO);
                _.Move(executed_1.PROPOVA_COD_PRODUTO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO);
                _.Move(executed_1.PROPOVA_COD_CLIENTE, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_CLIENTE);
                _.Move(executed_1.PROPOVA_OCOREND, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_OCOREND);
                _.Move(executed_1.PROPOVA_COD_FONTE, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_FONTE);
                _.Move(executed_1.PROPOVA_AGE_COBRANCA, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_AGE_COBRANCA);
                _.Move(executed_1.PROPOVA_OPCAO_COBERTURA, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_OPCAO_COBERTURA);
                _.Move(executed_1.PROPOVA_DATA_QUITACAO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DATA_QUITACAO);
                _.Move(executed_1.PROPOVA_COD_AGE_VENDEDOR, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_AGE_VENDEDOR);
                _.Move(executed_1.PROPOVA_OPE_CONTA_VENDEDOR, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_OPE_CONTA_VENDEDOR);
                _.Move(executed_1.PROPOVA_NUM_CONTA_VENDEDOR, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CONTA_VENDEDOR);
                _.Move(executed_1.PROPOVA_DIG_CONTA_VENDEDOR, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DIG_CONTA_VENDEDOR);
                _.Move(executed_1.PROPOVA_NUM_MATRI_VENDEDOR, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_MATRI_VENDEDOR);
                _.Move(executed_1.PROPOVA_COD_OPERACAO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_OPERACAO);
                _.Move(executed_1.PROPOVA_PROFISSAO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_PROFISSAO);
                _.Move(executed_1.PROPOVA_DTINCLUS, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DTINCLUS);
                _.Move(executed_1.PROPOVA_DATA_MOVIMENTO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DATA_MOVIMENTO);
                _.Move(executed_1.PROPOVA_SIT_REGISTRO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_SIT_REGISTRO);
                _.Move(executed_1.PROPOVA_NUM_APOLICE, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE);
                _.Move(executed_1.PROPOVA_COD_SUBGRUPO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_SUBGRUPO);
                _.Move(executed_1.PROPOVA_OCORR_HISTORICO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_OCORR_HISTORICO);
                _.Move(executed_1.PROPOVA_NRPRIPARATZ, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NRPRIPARATZ);
                _.Move(executed_1.PROPOVA_QTDPARATZ, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_QTDPARATZ);
                _.Move(executed_1.PROPOVA_DTPROXVEN, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DTPROXVEN);
                _.Move(executed_1.PROPOVA_NUM_PARCELA, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_PARCELA);
                _.Move(executed_1.PROPOVA_DATA_VENCIMENTO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DATA_VENCIMENTO);
                _.Move(executed_1.PROPOVA_SIT_INTERFACE, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_SIT_INTERFACE);
                _.Move(executed_1.PROPOVA_DTFENAE, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DTFENAE);
                _.Move(executed_1.PROPOVA_COD_USUARIO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_USUARIO);
                _.Move(executed_1.PROPOVA_TIMESTAMP, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_TIMESTAMP);
                _.Move(executed_1.PROPOVA_IDADE, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_IDADE);
                _.Move(executed_1.PROPOVA_IDE_SEXO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_IDE_SEXO);
                _.Move(executed_1.PROPOVA_ESTADO_CIVIL, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_ESTADO_CIVIL);
                _.Move(executed_1.PROPOVA_APOS_INVALIDEZ, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_APOS_INVALIDEZ);
                _.Move(executed_1.VIND_APOS_INVALIDEZ, VIND_APOS_INVALIDEZ);
                _.Move(executed_1.PROPOVA_NOME_ESPOSA, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NOME_ESPOSA);
                _.Move(executed_1.VIND_NOME_ESPOSA, VIND_NOME_ESPOSA);
                _.Move(executed_1.PROPOVA_DTNASC_ESPOSA, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DTNASC_ESPOSA);
                _.Move(executed_1.VIND_DTNASC_ESPOSA, VIND_DTNASC_ESPOSA);
                _.Move(executed_1.PROPOVA_PROFIS_ESPOSA, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_PROFIS_ESPOSA);
                _.Move(executed_1.VIND_PROFIS_ESPOSA, VIND_PROFIS_ESPOSA);
                _.Move(executed_1.PROPOVA_DPS_TITULAR, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DPS_TITULAR);
                _.Move(executed_1.VIND_DPS_TITULAR, VIND_DPS_TITULAR);
                _.Move(executed_1.PROPOVA_DPS_ESPOSA, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DPS_ESPOSA);
                _.Move(executed_1.VIND_DPS_ESPOSA, VIND_DPS_ESPOSA);
                _.Move(executed_1.PROPOVA_NUM_MATRICULA, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_MATRICULA);
                _.Move(executed_1.VIND_NUM_MATRICULA, VIND_NUM_MATRICULA);
                _.Move(executed_1.PROPOVA_FAIXA_RENDA_IND, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_FAIXA_RENDA_IND);
                _.Move(executed_1.VIND_FAIXA_RENDA_IND, VIND_FAIXA_RENDA_IND);
                _.Move(executed_1.PROPOVA_FAIXA_RENDA_FAM, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_FAIXA_RENDA_FAM);
                _.Move(executed_1.VIND_FAIXA_RENDA_FAM, VIND_FAIXA_RENDA_FAM);
                _.Move(executed_1.PROPOVA_COD_ORIGEM_PROPOSTA, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_ORIGEM_PROPOSTA);
                _.Move(executed_1.VIND_COD_ORIGEM_PROP, VIND_COD_ORIGEM_PROP);
                _.Move(executed_1.PROPOVA_NUM_PRAZO_FIN, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_PRAZO_FIN);
                _.Move(executed_1.VIND_NUM_PRAZO_FIN, VIND_NUM_PRAZO_FIN);
                _.Move(executed_1.PROPOVA_STA_ANTECIPACAO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_STA_ANTECIPACAO);
                _.Move(executed_1.VIND_STA_ANTECIPACAO, VIND_STA_ANTECIPACAO);
                _.Move(executed_1.PROPOVA_STA_MUDANCA_PLANO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_STA_MUDANCA_PLANO);
                _.Move(executed_1.VIND_STA_MUDANCA, VIND_STA_MUDANCA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0170_SAIDA*/

        [StopWatch]
        /*" R0200-00-LER-RCAPS-SECTION */
        private void R0200_00_LER_RCAPS_SECTION()
        {
            /*" -902- MOVE 'R0200-00-LER-RCAPS' TO PARAGRAFO. */
            _.Move("R0200-00-LER-RCAPS", WABEND2.PARAGRAFO);

            /*" -905- MOVE 'SELECT RCAPS' TO COMANDO. */
            _.Move("SELECT RCAPS", WABEND2.COMANDO);

            /*" -910- MOVE PROPOVA-NUM-CERTIFICADO TO RCAPS-NUM-CERTIFICADO. */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO, RCAPS.DCLRCAPS.RCAPS_NUM_CERTIFICADO);

            /*" -942- PERFORM R0200_00_LER_RCAPS_DB_SELECT_1 */

            R0200_00_LER_RCAPS_DB_SELECT_1();

            /*" -947- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -948- MOVE 1 TO W-RCAPS */
                _.Move(1, W_RCAPS);

                /*" -949- GO TO R0200-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_SAIDA*/ //GOTO
                return;

                /*" -950- ELSE */
            }
            else
            {


                /*" -951- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -952- MOVE 2 TO W-RCAPS */
                    _.Move(2, W_RCAPS);

                    /*" -953- ELSE */
                }
                else
                {


                    /*" -954- DISPLAY 'VA0126B - ERRO SELECT RCAPS P/PROPOSTA' */
                    _.Display($"VA0126B - ERRO SELECT RCAPS P/PROPOSTA");

                    /*" -956- DISPLAY '          CERTIFICADO = ' RCAPS-NUM-CERTIFICADO */
                    _.Display($"          CERTIFICADO = {RCAPS.DCLRCAPS.RCAPS_NUM_CERTIFICADO}");

                    /*" -957- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -958- PERFORM R9999-00-FINALIZAR */

                    R9999_00_FINALIZAR_SECTION();

                    /*" -959- END-IF */
                }


                /*" -959- END-IF. */
            }


        }

        [StopWatch]
        /*" R0200-00-LER-RCAPS-DB-SELECT-1 */
        public void R0200_00_LER_RCAPS_DB_SELECT_1()
        {
            /*" -942- EXEC SQL SELECT COD_FONTE , NUM_PROPOSTA , VAL_RCAP , VAL_RCAP_PRINCIPAL , DATA_CADASTRAMENTO , DATA_MOVIMENTO , SIT_REGISTRO , COD_OPERACAO , NUM_PARCELA , NUM_TITULO , AGE_COBRANCA , NUM_RCAP INTO :RCAPS-COD-FONTE ,:RCAPS-NUM-PROPOSTA ,:RCAPS-VAL-RCAP ,:RCAPS-VAL-RCAP-PRINCIPAL ,:RCAPS-DATA-CADASTRAMENTO ,:RCAPS-DATA-MOVIMENTO ,:RCAPS-SIT-REGISTRO ,:RCAPS-COD-OPERACAO ,:RCAPS-NUM-PARCELA ,:RCAPS-NUM-TITULO ,:RCAPS-AGE-COBRANCA:VIND-AGE-COBRANCA ,:RCAPS-NUM-RCAP FROM SEGUROS.RCAPS WHERE NUM_CERTIFICADO = :RCAPS-NUM-CERTIFICADO AND NUM_PARCELA = 0 FETCH FIRST 01 ROWS ONLY WITH UR END-EXEC */

            var r0200_00_LER_RCAPS_DB_SELECT_1_Query1 = new R0200_00_LER_RCAPS_DB_SELECT_1_Query1()
            {
                RCAPS_NUM_CERTIFICADO = RCAPS.DCLRCAPS.RCAPS_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = R0200_00_LER_RCAPS_DB_SELECT_1_Query1.Execute(r0200_00_LER_RCAPS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.RCAPS_COD_FONTE, RCAPS.DCLRCAPS.RCAPS_COD_FONTE);
                _.Move(executed_1.RCAPS_NUM_PROPOSTA, RCAPS.DCLRCAPS.RCAPS_NUM_PROPOSTA);
                _.Move(executed_1.RCAPS_VAL_RCAP, RCAPS.DCLRCAPS.RCAPS_VAL_RCAP);
                _.Move(executed_1.RCAPS_VAL_RCAP_PRINCIPAL, RCAPS.DCLRCAPS.RCAPS_VAL_RCAP_PRINCIPAL);
                _.Move(executed_1.RCAPS_DATA_CADASTRAMENTO, RCAPS.DCLRCAPS.RCAPS_DATA_CADASTRAMENTO);
                _.Move(executed_1.RCAPS_DATA_MOVIMENTO, RCAPS.DCLRCAPS.RCAPS_DATA_MOVIMENTO);
                _.Move(executed_1.RCAPS_SIT_REGISTRO, RCAPS.DCLRCAPS.RCAPS_SIT_REGISTRO);
                _.Move(executed_1.RCAPS_COD_OPERACAO, RCAPS.DCLRCAPS.RCAPS_COD_OPERACAO);
                _.Move(executed_1.RCAPS_NUM_PARCELA, RCAPS.DCLRCAPS.RCAPS_NUM_PARCELA);
                _.Move(executed_1.RCAPS_NUM_TITULO, RCAPS.DCLRCAPS.RCAPS_NUM_TITULO);
                _.Move(executed_1.RCAPS_AGE_COBRANCA, RCAPS.DCLRCAPS.RCAPS_AGE_COBRANCA);
                _.Move(executed_1.VIND_AGE_COBRANCA, VIND_AGE_COBRANCA);
                _.Move(executed_1.RCAPS_NUM_RCAP, RCAPS.DCLRCAPS.RCAPS_NUM_RCAP);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_SAIDA*/

        [StopWatch]
        /*" R0300-00-LER-CLIENTE-SECTION */
        private void R0300_00_LER_CLIENTE_SECTION()
        {
            /*" -968- MOVE 'R0300-00-LER-CLIENTES' TO PARAGRAFO. */
            _.Move("R0300-00-LER-CLIENTES", WABEND2.PARAGRAFO);

            /*" -970- MOVE 'SELECT CLIENTES' TO COMANDO. */
            _.Move("SELECT CLIENTES", WABEND2.COMANDO);

            /*" -973- MOVE PROPOVA-COD-CLIENTE TO CLIENTES-COD-CLIENTE. */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_CLIENTE, CLIENTES.DCLCLIENTES.CLIENTES_COD_CLIENTE);

            /*" -991- PERFORM R0300_00_LER_CLIENTE_DB_SELECT_1 */

            R0300_00_LER_CLIENTE_DB_SELECT_1();

            /*" -994- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -995- MOVE 1 TO W-CLIENTE */
                _.Move(1, W_CLIENTE);

                /*" -996- ELSE */
            }
            else
            {


                /*" -997- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -998- MOVE 2 TO W-CLIENTE */
                    _.Move(2, W_CLIENTE);

                    /*" -999- ELSE */
                }
                else
                {


                    /*" -1000- DISPLAY 'VA0126B - ERRO SELECT CLIENTES ' */
                    _.Display($"VA0126B - ERRO SELECT CLIENTES ");

                    /*" -1002- DISPLAY '          CERTIFICADO = ' PROPOVA-NUM-CERTIFICADO */
                    _.Display($"          CERTIFICADO = {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                    /*" -1004- DISPLAY '          COD CLIENTE = ' PROPOVA-COD-CLIENTE */
                    _.Display($"          COD CLIENTE = {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_CLIENTE}");

                    /*" -1005- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -1005- PERFORM R9999-00-FINALIZAR. */

                    R9999_00_FINALIZAR_SECTION();
                }

            }


        }

        [StopWatch]
        /*" R0300-00-LER-CLIENTE-DB-SELECT-1 */
        public void R0300_00_LER_CLIENTE_DB_SELECT_1()
        {
            /*" -991- EXEC SQL SELECT COD_CLIENTE , NOME_RAZAO , TIPO_PESSOA , CGCCPF , SIT_REGISTRO , DATA_NASCIMENTO INTO :CLIENTES-COD-CLIENTE ,:CLIENTES-NOME-RAZAO ,:CLIENTES-TIPO-PESSOA ,:CLIENTES-CGCCPF ,:CLIENTES-SIT-REGISTRO ,:CLIENTES-DATA-NASCIMENTO:VIND-DTNASCI FROM SEGUROS.CLIENTES WHERE COD_CLIENTE = :CLIENTES-COD-CLIENTE WITH UR END-EXEC. */

            var r0300_00_LER_CLIENTE_DB_SELECT_1_Query1 = new R0300_00_LER_CLIENTE_DB_SELECT_1_Query1()
            {
                CLIENTES_COD_CLIENTE = CLIENTES.DCLCLIENTES.CLIENTES_COD_CLIENTE.ToString(),
            };

            var executed_1 = R0300_00_LER_CLIENTE_DB_SELECT_1_Query1.Execute(r0300_00_LER_CLIENTE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CLIENTES_COD_CLIENTE, CLIENTES.DCLCLIENTES.CLIENTES_COD_CLIENTE);
                _.Move(executed_1.CLIENTES_NOME_RAZAO, CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO);
                _.Move(executed_1.CLIENTES_TIPO_PESSOA, CLIENTES.DCLCLIENTES.CLIENTES_TIPO_PESSOA);
                _.Move(executed_1.CLIENTES_CGCCPF, CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF);
                _.Move(executed_1.CLIENTES_SIT_REGISTRO, CLIENTES.DCLCLIENTES.CLIENTES_SIT_REGISTRO);
                _.Move(executed_1.CLIENTES_DATA_NASCIMENTO, CLIENTES.DCLCLIENTES.CLIENTES_DATA_NASCIMENTO);
                _.Move(executed_1.VIND_DTNASCI, VIND_DTNASCI);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_SAIDA*/

        [StopWatch]
        /*" R0350-00-DECLARE-ENDERECO-SECTION */
        private void R0350_00_DECLARE_ENDERECO_SECTION()
        {
            /*" -1014- MOVE 'R0350-00-DECLARE-ENDERECO' TO PARAGRAFO. */
            _.Move("R0350-00-DECLARE-ENDERECO", WABEND2.PARAGRAFO);

            /*" -1016- MOVE 'DECLARE ENDERECO ' TO COMANDO. */
            _.Move("DECLARE ENDERECO ", WABEND2.COMANDO);

            /*" -1019- MOVE PROPOVA-COD-CLIENTE TO ENDERECO-COD-CLIENTE. */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_CLIENTE, ENDERECO.DCLENDERECOS.ENDERECO_COD_CLIENTE);

            /*" -1039- PERFORM R0350_00_DECLARE_ENDERECO_DB_DECLARE_1 */

            R0350_00_DECLARE_ENDERECO_DB_DECLARE_1();

            /*" -1042- MOVE 'OPEN C01_ENDERECO ' TO COMANDO. */
            _.Move("OPEN C01_ENDERECO ", WABEND2.COMANDO);

            /*" -1042- PERFORM R0350_00_DECLARE_ENDERECO_DB_OPEN_1 */

            R0350_00_DECLARE_ENDERECO_DB_OPEN_1();

            /*" -1044- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1045- DISPLAY 'VA0126B - ERRO OPEN CURSOR ENDERECO ' */
                _.Display($"VA0126B - ERRO OPEN CURSOR ENDERECO ");

                /*" -1047- DISPLAY '          CERTIFICADO = ' PROPOVA-NUM-CERTIFICADO */
                _.Display($"          CERTIFICADO = {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                /*" -1048- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -1048- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R0350-00-DECLARE-ENDERECO-DB-OPEN-1 */
        public void R0350_00_DECLARE_ENDERECO_DB_OPEN_1()
        {
            /*" -1042- EXEC SQL OPEN C01_ENDERECO END-EXEC. */

            C01_ENDERECO.Open();

        }

        [StopWatch]
        /*" R0410-00-LER-CBO-DB-DECLARE-1 */
        public void R0410_00_LER_CBO_DB_DECLARE_1()
        {
            /*" -1164- EXEC SQL DECLARE C01_CBO CURSOR FOR SELECT COD_CBO , DESCR_CBO FROM SEGUROS.CBO WHERE DESCR_CBO = :CBO-DESCR-CBO ORDER BY COD_CBO END-EXEC */
            C01_CBO = new VA0126B_C01_CBO(true);
            string GetQuery_C01_CBO()
            {
                var query = @$"SELECT COD_CBO 
							, DESCR_CBO 
							FROM SEGUROS.CBO 
							WHERE DESCR_CBO = '{CBO.DCLCBO.CBO_DESCR_CBO}' 
							ORDER BY COD_CBO";

                return query;
            }
            C01_CBO.GetQueryEvent += GetQuery_C01_CBO;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0350_SAIDA*/

        [StopWatch]
        /*" R0370-00-LER-ENDERECO-SECTION */
        private void R0370_00_LER_ENDERECO_SECTION()
        {
            /*" -1057- MOVE 'R0370-00-LER-ENDERECO' TO PARAGRAFO. */
            _.Move("R0370-00-LER-ENDERECO", WABEND2.PARAGRAFO);

            /*" -1059- MOVE 'FETCH ENDERECOS' TO COMANDO. */
            _.Move("FETCH ENDERECOS", WABEND2.COMANDO);

            /*" -1075- PERFORM R0370_00_LER_ENDERECO_DB_FETCH_1 */

            R0370_00_LER_ENDERECO_DB_FETCH_1();

            /*" -1078- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1079- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1080- MOVE 'S' TO WFIM-ENDERECOS */
                    _.Move("S", WFIM_ENDERECOS);

                    /*" -1081- MOVE 2 TO W-ENDERECO */
                    _.Move(2, W_ENDERECO);

                    /*" -1081- PERFORM R0370_00_LER_ENDERECO_DB_CLOSE_1 */

                    R0370_00_LER_ENDERECO_DB_CLOSE_1();

                    /*" -1083- GO TO R0370-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0370_SAIDA*/ //GOTO
                    return;

                    /*" -1084- ELSE */
                }
                else
                {


                    /*" -1085- DISPLAY 'VA0126B - ERRO FETCH CURSOR ENDERECO' */
                    _.Display($"VA0126B - ERRO FETCH CURSOR ENDERECO");

                    /*" -1087- DISPLAY '          CERTIFICADO = ' PROPOVA-NUM-CERTIFICADO */
                    _.Display($"          CERTIFICADO = {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                    /*" -1089- DISPLAY '          CLIENTE     = ' ENDERECO-COD-CLIENTE */
                    _.Display($"          CLIENTE     = {ENDERECO.DCLENDERECOS.ENDERECO_COD_CLIENTE}");

                    /*" -1090- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -1091- PERFORM R9999-00-FINALIZAR */

                    R9999_00_FINALIZAR_SECTION();

                    /*" -1092- ELSE */
                }

            }
            else
            {


                /*" -1093- MOVE 1 TO W-ENDERECO */
                _.Move(1, W_ENDERECO);

                /*" -1094- MOVE 'S' TO WFIM-ENDERECOS */
                _.Move("S", WFIM_ENDERECOS);

                /*" -1094- PERFORM R0370_00_LER_ENDERECO_DB_CLOSE_2 */

                R0370_00_LER_ENDERECO_DB_CLOSE_2();

                /*" -1095- GO TO R0370-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0370_SAIDA*/ //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0370-00-LER-ENDERECO-DB-FETCH-1 */
        public void R0370_00_LER_ENDERECO_DB_FETCH_1()
        {
            /*" -1075- EXEC SQL FETCH C01_ENDERECO INTO :ENDERECO-COD-CLIENTE ,:ENDERECO-COD-ENDERECO ,:ENDERECO-OCORR-ENDERECO ,:ENDERECO-ENDERECO ,:ENDERECO-BAIRRO ,:ENDERECO-CIDADE ,:ENDERECO-SIGLA-UF ,:ENDERECO-CEP ,:ENDERECO-DDD ,:ENDERECO-TELEFONE ,:ENDERECO-FAX ,:ENDERECO-TELEX ,:ENDERECO-SIT-REGISTRO END-EXEC. */

            if (C01_ENDERECO.Fetch())
            {
                _.Move(C01_ENDERECO.ENDERECO_COD_CLIENTE, ENDERECO.DCLENDERECOS.ENDERECO_COD_CLIENTE);
                _.Move(C01_ENDERECO.ENDERECO_COD_ENDERECO, ENDERECO.DCLENDERECOS.ENDERECO_COD_ENDERECO);
                _.Move(C01_ENDERECO.ENDERECO_OCORR_ENDERECO, ENDERECO.DCLENDERECOS.ENDERECO_OCORR_ENDERECO);
                _.Move(C01_ENDERECO.ENDERECO_ENDERECO, ENDERECO.DCLENDERECOS.ENDERECO_ENDERECO);
                _.Move(C01_ENDERECO.ENDERECO_BAIRRO, ENDERECO.DCLENDERECOS.ENDERECO_BAIRRO);
                _.Move(C01_ENDERECO.ENDERECO_CIDADE, ENDERECO.DCLENDERECOS.ENDERECO_CIDADE);
                _.Move(C01_ENDERECO.ENDERECO_SIGLA_UF, ENDERECO.DCLENDERECOS.ENDERECO_SIGLA_UF);
                _.Move(C01_ENDERECO.ENDERECO_CEP, ENDERECO.DCLENDERECOS.ENDERECO_CEP);
                _.Move(C01_ENDERECO.ENDERECO_DDD, ENDERECO.DCLENDERECOS.ENDERECO_DDD);
                _.Move(C01_ENDERECO.ENDERECO_TELEFONE, ENDERECO.DCLENDERECOS.ENDERECO_TELEFONE);
                _.Move(C01_ENDERECO.ENDERECO_FAX, ENDERECO.DCLENDERECOS.ENDERECO_FAX);
                _.Move(C01_ENDERECO.ENDERECO_TELEX, ENDERECO.DCLENDERECOS.ENDERECO_TELEX);
                _.Move(C01_ENDERECO.ENDERECO_SIT_REGISTRO, ENDERECO.DCLENDERECOS.ENDERECO_SIT_REGISTRO);
            }

        }

        [StopWatch]
        /*" R0370-00-LER-ENDERECO-DB-CLOSE-1 */
        public void R0370_00_LER_ENDERECO_DB_CLOSE_1()
        {
            /*" -1081- EXEC SQL CLOSE C01_ENDERECO END-EXEC */

            C01_ENDERECO.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0370_SAIDA*/

        [StopWatch]
        /*" R0370-00-LER-ENDERECO-DB-CLOSE-2 */
        public void R0370_00_LER_ENDERECO_DB_CLOSE_2()
        {
            /*" -1094- EXEC SQL CLOSE C01_ENDERECO END-EXEC */

            C01_ENDERECO.Close();

        }

        [StopWatch]
        /*" R0400-00-LER-PROFISSAO-SECTION */
        private void R0400_00_LER_PROFISSAO_SECTION()
        {
            /*" -1105- MOVE 'R0400-00-LER-PROFISSAO' TO PARAGRAFO. */
            _.Move("R0400-00-LER-PROFISSAO", WABEND2.PARAGRAFO);

            /*" -1109- MOVE '                      ' TO COMANDO. */
            _.Move("                      ", WABEND2.COMANDO);

            /*" -1110- IF PROPOVA-PROFISSAO NOT EQUAL SPACES */

            if (!PROPOVA.DCLPROPOSTAS_VA.PROPOVA_PROFISSAO.IsEmpty())
            {

                /*" -1112- MOVE PROPOVA-PROFISSAO TO CBO-DESCR-CBO OF DCLCBO */
                _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_PROFISSAO, CBO.DCLCBO.CBO_DESCR_CBO);

                /*" -1113- PERFORM R0410-00-LER-CBO */

                R0410_00_LER_CBO_SECTION();

                /*" -1114- IF SQLCODE EQUAL ZEROS */

                if (DB.SQLCODE == 00)
                {

                    /*" -1116- MOVE CBO-COD-CBO OF DCLCBO TO COD-CBO-TIT */
                    _.Move(CBO.DCLCBO.CBO_COD_CBO, COD_CBO_TIT);

                    /*" -1117- ELSE */
                }
                else
                {


                    /*" -1118- MOVE ZEROS TO COD-CBO-TIT */
                    _.Move(0, COD_CBO_TIT);

                    /*" -1119- ELSE */
                }

            }
            else
            {


                /*" -1123- MOVE ZEROS TO COD-CBO-TIT. */
                _.Move(0, COD_CBO_TIT);
            }


            /*" -1124- IF VIND-PROFIS-ESPOSA LESS ZEROS */

            if (VIND_PROFIS_ESPOSA < 00)
            {

                /*" -1125- MOVE ZEROS TO COD-CBO-CONJ */
                _.Move(0, COD_CBO_CONJ);

                /*" -1126- ELSE */
            }
            else
            {


                /*" -1127- IF PROPOVA-PROFIS-ESPOSA NOT EQUAL SPACES */

                if (!PROPOVA.DCLPROPOSTAS_VA.PROPOVA_PROFIS_ESPOSA.IsEmpty())
                {

                    /*" -1129- MOVE PROPOVA-PROFIS-ESPOSA TO CBO-DESCR-CBO OF DCLCBO */
                    _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_PROFIS_ESPOSA, CBO.DCLCBO.CBO_DESCR_CBO);

                    /*" -1130- PERFORM R0410-00-LER-CBO */

                    R0410_00_LER_CBO_SECTION();

                    /*" -1131- IF SQLCODE EQUAL ZEROS */

                    if (DB.SQLCODE == 00)
                    {

                        /*" -1133- MOVE CBO-COD-CBO OF DCLCBO TO COD-CBO-CONJ */
                        _.Move(CBO.DCLCBO.CBO_COD_CBO, COD_CBO_CONJ);

                        /*" -1134- ELSE */
                    }
                    else
                    {


                        /*" -1135- MOVE ZEROS TO COD-CBO-CONJ */
                        _.Move(0, COD_CBO_CONJ);

                        /*" -1136- ELSE */
                    }

                }
                else
                {


                    /*" -1136- MOVE ZEROS TO COD-CBO-CONJ. */
                    _.Move(0, COD_CBO_CONJ);
                }

            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0400_SAIDA*/

        [StopWatch]
        /*" R0410-00-LER-CBO-SECTION */
        private void R0410_00_LER_CBO_SECTION()
        {
            /*" -1145- MOVE 'R0400-00-LER-CBO' TO PARAGRAFO. */
            _.Move("R0400-00-LER-CBO", WABEND2.PARAGRAFO);

            /*" -1147- MOVE 'SELECT CBO' TO COMANDO. */
            _.Move("SELECT CBO", WABEND2.COMANDO);

            /*" -1154- PERFORM R0410_00_LER_CBO_DB_SELECT_1 */

            R0410_00_LER_CBO_DB_SELECT_1();

            /*" -1157- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1158- IF SQLCODE EQUAL -811 */

                if (DB.SQLCODE == -811)
                {

                    /*" -1164- PERFORM R0410_00_LER_CBO_DB_DECLARE_1 */

                    R0410_00_LER_CBO_DB_DECLARE_1();

                    /*" -1166- PERFORM R0410_00_LER_CBO_DB_OPEN_1 */

                    R0410_00_LER_CBO_DB_OPEN_1();

                    /*" -1168- IF SQLCODE EQUAL ZEROS */

                    if (DB.SQLCODE == 00)
                    {

                        /*" -1172- PERFORM R0410_00_LER_CBO_DB_FETCH_1 */

                        R0410_00_LER_CBO_DB_FETCH_1();

                        /*" -1173- PERFORM R0410_00_LER_CBO_DB_CLOSE_1 */

                        R0410_00_LER_CBO_DB_CLOSE_1();

                        /*" -1176- ELSE NEXT SENTENCE */
                    }
                    else
                    {


                        /*" -1177- ELSE */
                    }

                }
                else
                {


                    /*" -1178- IF SQLCODE NOT EQUAL 100 */

                    if (DB.SQLCODE != 100)
                    {

                        /*" -1179- DISPLAY 'VA0126B - ERRO SELECT TABELA CBO' */
                        _.Display($"VA0126B - ERRO SELECT TABELA CBO");

                        /*" -1181- DISPLAY '          NUMERO CERTIFICADO....' PROPOVA-NUM-CERTIFICADO */
                        _.Display($"          NUMERO CERTIFICADO....{PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                        /*" -1182- PERFORM R9988-00-FECHAR-ARQUIVOS */

                        R9988_00_FECHAR_ARQUIVOS_SECTION();

                        /*" -1182- PERFORM R9999-00-FINALIZAR. */

                        R9999_00_FINALIZAR_SECTION();
                    }

                }

            }


        }

        [StopWatch]
        /*" R0410-00-LER-CBO-DB-SELECT-1 */
        public void R0410_00_LER_CBO_DB_SELECT_1()
        {
            /*" -1154- EXEC SQL SELECT COD_CBO , DESCR_CBO INTO :CBO-COD-CBO ,:CBO-DESCR-CBO FROM SEGUROS.CBO WHERE DESCR_CBO = :CBO-DESCR-CBO END-EXEC. */

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

        [StopWatch]
        /*" R0410-00-LER-CBO-DB-OPEN-1 */
        public void R0410_00_LER_CBO_DB_OPEN_1()
        {
            /*" -1166- EXEC SQL OPEN C01_CBO END-EXEC */

            C01_CBO.Open();

        }

        [StopWatch]
        /*" R0450-00-OBTER-COBERTURA-DB-DECLARE-1 */
        public void R0450_00_OBTER_COBERTURA_DB_DECLARE_1()
        {
            /*" -1317- EXEC SQL DECLARE COBERTURAS CURSOR FOR SELECT NUM_CERTIFICADO , OCORR_HISTORICO , DATA_INIVIGENCIA , DATA_TERVIGENCIA , IMPSEGUR , QUANT_VIDAS , IMPSEGIND , COD_OPERACAO , OPCAO_COBERTURA , IMP_MORNATU , IMPMORACID , IMPINVPERM , IMPAMDS , IMPDH , IMPDIT , VLPREMIO , PRMVG , PRMAP , QTDE_TIT_CAPITALIZ , VAL_TIT_CAPITALIZ , VAL_CUSTO_CAPITALI , IMPSEGCDG , VLCUSTCDG , COD_USUARIO , TIMESTAMP , IMPSEGAUXF , VLCUSTAUXF , PRMDIT , QTMDIT FROM SEGUROS.HIS_COBER_PROPOST WHERE NUM_CERTIFICADO = :HISCOBPR-NUM-CERTIFICADO AND DATA_TERVIGENCIA = :HISCOBPR-DATA-TERVIGENCIA ORDER BY OCORR_HISTORICO WITH UR END-EXEC. */
            COBERTURAS = new VA0126B_COBERTURAS(true);
            string GetQuery_COBERTURAS()
            {
                var query = @$"SELECT NUM_CERTIFICADO 
							, OCORR_HISTORICO 
							, DATA_INIVIGENCIA 
							, DATA_TERVIGENCIA 
							, IMPSEGUR 
							, QUANT_VIDAS 
							, IMPSEGIND 
							, COD_OPERACAO 
							, OPCAO_COBERTURA 
							, IMP_MORNATU 
							, IMPMORACID 
							, IMPINVPERM 
							, IMPAMDS 
							, IMPDH 
							, IMPDIT 
							, VLPREMIO 
							, PRMVG 
							, PRMAP 
							, QTDE_TIT_CAPITALIZ 
							, VAL_TIT_CAPITALIZ 
							, VAL_CUSTO_CAPITALI 
							, IMPSEGCDG 
							, VLCUSTCDG 
							, COD_USUARIO 
							, TIMESTAMP 
							, IMPSEGAUXF 
							, VLCUSTAUXF 
							, PRMDIT 
							, QTMDIT 
							FROM SEGUROS.HIS_COBER_PROPOST 
							WHERE NUM_CERTIFICADO = '{HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_NUM_CERTIFICADO}' 
							AND DATA_TERVIGENCIA = '{HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_DATA_TERVIGENCIA}' 
							ORDER BY OCORR_HISTORICO";

                return query;
            }
            COBERTURAS.GetQueryEvent += GetQuery_COBERTURAS;

        }

        [StopWatch]
        /*" R0410-00-LER-CBO-DB-FETCH-1 */
        public void R0410_00_LER_CBO_DB_FETCH_1()
        {
            /*" -1172- EXEC SQL FETCH C01_CBO INTO :CBO-COD-CBO ,:CBO-DESCR-CBO END-EXEC */

            if (C01_CBO.Fetch())
            {
                _.Move(C01_CBO.CBO_COD_CBO, CBO.DCLCBO.CBO_COD_CBO);
                _.Move(C01_CBO.CBO_DESCR_CBO, CBO.DCLCBO.CBO_DESCR_CBO);
            }

        }

        [StopWatch]
        /*" R0410-00-LER-CBO-DB-CLOSE-1 */
        public void R0410_00_LER_CBO_DB_CLOSE_1()
        {
            /*" -1173- EXEC SQL CLOSE C01_CBO END-EXEC */

            C01_CBO.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0410_SAIDA*/

        [StopWatch]
        /*" R0450-00-LER-PRODUTOS-SIVPF-SECTION */
        private void R0450_00_LER_PRODUTOS_SIVPF_SECTION()
        {
            /*" -1191- MOVE 'R0450-00-LER-PRODUTOS-SIVPF' TO PARAGRAFO. */
            _.Move("R0450-00-LER-PRODUTOS-SIVPF", WABEND2.PARAGRAFO);

            /*" -1193- MOVE 'SELECT PRODUTOS-SIVPF' TO COMANDO. */
            _.Move("SELECT PRODUTOS-SIVPF", WABEND2.COMANDO);

            /*" -1196- MOVE PROPOVA-COD-PRODUTO TO PRDSIVPF-COD-PRODUTO */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO, PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_PRODUTO);

            /*" -1209- PERFORM R0450_00_LER_PRODUTOS_SIVPF_DB_SELECT_1 */

            R0450_00_LER_PRODUTOS_SIVPF_DB_SELECT_1();

            /*" -1212- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1213- DISPLAY 'VA0126B - ERRO SELECT PRODUTOS_SIVPF' */
                _.Display($"VA0126B - ERRO SELECT PRODUTOS_SIVPF");

                /*" -1215- DISPLAY '          NUMERO CERTIFICADO = ' PROPOVA-NUM-CERTIFICADO */
                _.Display($"          NUMERO CERTIFICADO = {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                /*" -1217- DISPLAY '          CODIGO PRODUTO     = ' PRDSIVPF-COD-PRODUTO */
                _.Display($"          CODIGO PRODUTO     = {PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_PRODUTO}");

                /*" -1218- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -1218- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R0450-00-LER-PRODUTOS-SIVPF-DB-SELECT-1 */
        public void R0450_00_LER_PRODUTOS_SIVPF_DB_SELECT_1()
        {
            /*" -1209- EXEC SQL SELECT COD_EMPRESA_SIVPF , COD_PRODUTO_SIVPF , COD_PRODUTO , COD_RELAC INTO :PRDSIVPF-COD-EMPRESA-SIVPF ,:PRDSIVPF-COD-PRODUTO-SIVPF ,:PRDSIVPF-COD-PRODUTO ,:PRDSIVPF-COD-RELAC FROM SEGUROS.PRODUTOS_SIVPF WHERE COD_EMPRESA_SIVPF = 1 AND COD_PRODUTO = :PRDSIVPF-COD-PRODUTO END-EXEC. */

            var r0450_00_LER_PRODUTOS_SIVPF_DB_SELECT_1_Query1 = new R0450_00_LER_PRODUTOS_SIVPF_DB_SELECT_1_Query1()
            {
                PRDSIVPF_COD_PRODUTO = PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_PRODUTO.ToString(),
            };

            var executed_1 = R0450_00_LER_PRODUTOS_SIVPF_DB_SELECT_1_Query1.Execute(r0450_00_LER_PRODUTOS_SIVPF_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PRDSIVPF_COD_EMPRESA_SIVPF, PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_EMPRESA_SIVPF);
                _.Move(executed_1.PRDSIVPF_COD_PRODUTO_SIVPF, PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_PRODUTO_SIVPF);
                _.Move(executed_1.PRDSIVPF_COD_PRODUTO, PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_PRODUTO);
                _.Move(executed_1.PRDSIVPF_COD_RELAC, PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_RELAC);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0450_SAIDA*/

        [StopWatch]
        /*" R0500-00-OBTER-OPCAOPAG-SECTION */
        private void R0500_00_OBTER_OPCAOPAG_SECTION()
        {
            /*" -1227- MOVE 'R0500-00-OBTER-OPCAOPAG' TO PARAGRAFO. */
            _.Move("R0500-00-OBTER-OPCAOPAG", WABEND2.PARAGRAFO);

            /*" -1229- MOVE 'SELECT OPCAOPAGVA' TO COMANDO. */
            _.Move("SELECT OPCAOPAGVA", WABEND2.COMANDO);

            /*" -1230- MOVE PROPOVA-NUM-CERTIFICADO TO OPCPAGVI-NUM-CERTIFICADO */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CERTIFICADO);

            /*" -1232- MOVE '9999-12-31' TO OPCPAGVI-DATA-TERVIGENCIA */
            _.Move("9999-12-31", OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_DATA_TERVIGENCIA);

            /*" -1253- PERFORM R0500_00_OBTER_OPCAOPAG_DB_SELECT_1 */

            R0500_00_OBTER_OPCAOPAG_DB_SELECT_1();

            /*" -1256- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -1257- MOVE 1 TO W-OPCAOPAG */
                _.Move(1, W_OPCAOPAG);

                /*" -1258- ELSE */
            }
            else
            {


                /*" -1259- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1260- MOVE 2 TO W-OPCAOPAG */
                    _.Move(2, W_OPCAOPAG);

                    /*" -1261- ELSE */
                }
                else
                {


                    /*" -1262- DISPLAY 'VA0126B - ERRO SELECT OPCAOPAGVA ' */
                    _.Display($"VA0126B - ERRO SELECT OPCAOPAGVA ");

                    /*" -1264- DISPLAY '          CERTIFICADO = ' OPCPAGVI-NUM-CERTIFICADO */
                    _.Display($"          CERTIFICADO = {OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CERTIFICADO}");

                    /*" -1266- DISPLAY '          TERVIGENCIA = ' OPCPAGVI-DATA-TERVIGENCIA */
                    _.Display($"          TERVIGENCIA = {OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_DATA_TERVIGENCIA}");

                    /*" -1267- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -1267- PERFORM R9999-00-FINALIZAR. */

                    R9999_00_FINALIZAR_SECTION();
                }

            }


        }

        [StopWatch]
        /*" R0500-00-OBTER-OPCAOPAG-DB-SELECT-1 */
        public void R0500_00_OBTER_OPCAOPAG_DB_SELECT_1()
        {
            /*" -1253- EXEC SQL SELECT OPCAO_PAGAMENTO , PERI_PAGAMENTO , DIA_DEBITO , COD_AGENCIA_DEBITO , OPE_CONTA_DEBITO , NUM_CONTA_DEBITO , DIG_CONTA_DEBITO INTO :OPCPAGVI-OPCAO-PAGAMENTO , :OPCPAGVI-PERI-PAGAMENTO , :OPCPAGVI-DIA-DEBITO , :OPCPAGVI-COD-AGENCIA-DEBITO:VIND-AGECTADEB , :OPCPAGVI-OPE-CONTA-DEBITO:VIND-OPRCTADEB , :OPCPAGVI-NUM-CONTA-DEBITO:VIND-NUMCTADEB , :OPCPAGVI-DIG-CONTA-DEBITO:VIND-DIGCTADEB FROM SEGUROS.OPCAO_PAG_VIDAZUL WHERE NUM_CERTIFICADO = :OPCPAGVI-NUM-CERTIFICADO AND DATA_TERVIGENCIA = :OPCPAGVI-DATA-TERVIGENCIA WITH UR END-EXEC. */

            var r0500_00_OBTER_OPCAOPAG_DB_SELECT_1_Query1 = new R0500_00_OBTER_OPCAOPAG_DB_SELECT_1_Query1()
            {
                OPCPAGVI_DATA_TERVIGENCIA = OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_DATA_TERVIGENCIA.ToString(),
                OPCPAGVI_NUM_CERTIFICADO = OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = R0500_00_OBTER_OPCAOPAG_DB_SELECT_1_Query1.Execute(r0500_00_OBTER_OPCAOPAG_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.OPCPAGVI_OPCAO_PAGAMENTO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPCAO_PAGAMENTO);
                _.Move(executed_1.OPCPAGVI_PERI_PAGAMENTO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_PERI_PAGAMENTO);
                _.Move(executed_1.OPCPAGVI_DIA_DEBITO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_DIA_DEBITO);
                _.Move(executed_1.OPCPAGVI_COD_AGENCIA_DEBITO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_COD_AGENCIA_DEBITO);
                _.Move(executed_1.VIND_AGECTADEB, VIND_AGECTADEB);
                _.Move(executed_1.OPCPAGVI_OPE_CONTA_DEBITO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPE_CONTA_DEBITO);
                _.Move(executed_1.VIND_OPRCTADEB, VIND_OPRCTADEB);
                _.Move(executed_1.OPCPAGVI_NUM_CONTA_DEBITO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CONTA_DEBITO);
                _.Move(executed_1.VIND_NUMCTADEB, VIND_NUMCTADEB);
                _.Move(executed_1.OPCPAGVI_DIG_CONTA_DEBITO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_DIG_CONTA_DEBITO);
                _.Move(executed_1.VIND_DIGCTADEB, VIND_DIGCTADEB);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0500_SAIDA*/

        [StopWatch]
        /*" R0450-00-OBTER-COBERTURA-SECTION */
        private void R0450_00_OBTER_COBERTURA_SECTION()
        {
            /*" -1276- MOVE 'R0450-00-OBTER-COBERTURA' TO PARAGRAFO. */
            _.Move("R0450-00-OBTER-COBERTURA", WABEND2.PARAGRAFO);

            /*" -1278- MOVE 'DECLARE COBERPROPVA' TO COMANDO. */
            _.Move("DECLARE COBERPROPVA", WABEND2.COMANDO);

            /*" -1279- MOVE PROPOVA-NUM-CERTIFICADO TO HISCOBPR-NUM-CERTIFICADO */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_NUM_CERTIFICADO);

            /*" -1280- MOVE '9999-12-31' TO HISCOBPR-DATA-TERVIGENCIA */
            _.Move("9999-12-31", HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_DATA_TERVIGENCIA);

            /*" -1282- MOVE 2 TO W-COBERTURAS */
            _.Move(2, W_COBERTURAS);

            /*" -1317- PERFORM R0450_00_OBTER_COBERTURA_DB_DECLARE_1 */

            R0450_00_OBTER_COBERTURA_DB_DECLARE_1();

            /*" -1320- MOVE 'OPEN COBERPROPVA' TO COMANDO. */
            _.Move("OPEN COBERPROPVA", WABEND2.COMANDO);

            /*" -1320- PERFORM R0450_00_OBTER_COBERTURA_DB_OPEN_1 */

            R0450_00_OBTER_COBERTURA_DB_OPEN_1();

            /*" -1323- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1324- DISPLAY 'VA0126B - ERRO OPEN COBERTURAS      ' */
                _.Display($"VA0126B - ERRO OPEN COBERTURAS      ");

                /*" -1326- DISPLAY '          CERTIFICADO = ' HISCOBPR-NUM-CERTIFICADO */
                _.Display($"          CERTIFICADO = {HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_NUM_CERTIFICADO}");

                /*" -1328- DISPLAY '          TERVIGENCIA = ' HISCOBPR-DATA-TERVIGENCIA */
                _.Display($"          TERVIGENCIA = {HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_DATA_TERVIGENCIA}");

                /*" -1329- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -1331- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


            /*" -1363- PERFORM R0450_00_OBTER_COBERTURA_DB_FETCH_1 */

            R0450_00_OBTER_COBERTURA_DB_FETCH_1();

            /*" -1366- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1367- DISPLAY 'VA0126B - ERRO FETCH COBERTURAS  ' */
                _.Display($"VA0126B - ERRO FETCH COBERTURAS  ");

                /*" -1369- DISPLAY '          CERTIFICADO = ' PROPOVA-NUM-CERTIFICADO */
                _.Display($"          CERTIFICADO = {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                /*" -1370- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -1372- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


            /*" -1372- PERFORM R0450_00_OBTER_COBERTURA_DB_CLOSE_1 */

            R0450_00_OBTER_COBERTURA_DB_CLOSE_1();

            /*" -1375- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -1376- MOVE 1 TO W-COBERTURAS */
                _.Move(1, W_COBERTURAS);

                /*" -1377- ELSE */
            }
            else
            {


                /*" -1378- DISPLAY 'VA0126B - ERRO CLOSE CURSOR COBERTURAS ' */
                _.Display($"VA0126B - ERRO CLOSE CURSOR COBERTURAS ");

                /*" -1380- DISPLAY '          CERTIFICADO = ' PROPOVA-NUM-CERTIFICADO */
                _.Display($"          CERTIFICADO = {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                /*" -1381- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -1381- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R0450-00-OBTER-COBERTURA-DB-OPEN-1 */
        public void R0450_00_OBTER_COBERTURA_DB_OPEN_1()
        {
            /*" -1320- EXEC SQL OPEN COBERTURAS END-EXEC. */

            COBERTURAS.Open();

        }

        [StopWatch]
        /*" R0570-00-LER-COMISSAO-DB-DECLARE-1 */
        public void R0570_00_LER_COMISSAO_DB_DECLARE_1()
        {
            /*" -1408- EXEC SQL DECLARE FUNDOCOMISVA CURSOR FOR SELECT NUM_CERTIFICADO , VAL_COMISSAO_VG , VAL_COMISSAO_AP FROM SEGUROS.FUNDO_COMISSAO_VA WHERE NUM_CERTIFICADO = :DCLFUNDO-COMISSAO-VA.NUM-CERTIFICADO AND COD_OPERACAO = :DCLFUNDO-COMISSAO-VA.COD-OPERACAO WITH UR END-EXEC. */
            FUNDOCOMISVA = new VA0126B_FUNDOCOMISVA(true);
            string GetQuery_FUNDOCOMISVA()
            {
                var query = @$"SELECT NUM_CERTIFICADO 
							, VAL_COMISSAO_VG 
							, VAL_COMISSAO_AP 
							FROM SEGUROS.FUNDO_COMISSAO_VA 
							WHERE NUM_CERTIFICADO = 
							'{FDCOMVA.DCLFUNDO_COMISSAO_VA.NUM_CERTIFICADO}' 
							AND COD_OPERACAO = 
							'{FDCOMVA.DCLFUNDO_COMISSAO_VA.COD_OPERACAO}'";

                return query;
            }
            FUNDOCOMISVA.GetQueryEvent += GetQuery_FUNDOCOMISVA;

        }

        [StopWatch]
        /*" R0450-00-OBTER-COBERTURA-DB-FETCH-1 */
        public void R0450_00_OBTER_COBERTURA_DB_FETCH_1()
        {
            /*" -1363- EXEC SQL FETCH COBERTURAS INTO :HISCOBPR-NUM-CERTIFICADO ,:HISCOBPR-OCORR-HISTORICO ,:HISCOBPR-DATA-INIVIGENCIA ,:HISCOBPR-DATA-TERVIGENCIA ,:HISCOBPR-IMPSEGUR ,:HISCOBPR-QUANT-VIDAS ,:HISCOBPR-IMPSEGIND ,:HISCOBPR-COD-OPERACAO ,:HISCOBPR-OPCAO-COBERTURA ,:HISCOBPR-IMP-MORNATU ,:HISCOBPR-IMPMORACID ,:HISCOBPR-IMPINVPERM ,:HISCOBPR-IMPAMDS ,:HISCOBPR-IMPDH ,:HISCOBPR-IMPDIT ,:HISCOBPR-VLPREMIO ,:HISCOBPR-PRMVG ,:HISCOBPR-PRMAP ,:HISCOBPR-QTDE-TIT-CAPITALIZ ,:HISCOBPR-VAL-TIT-CAPITALIZ ,:HISCOBPR-VAL-CUSTO-CAPITALI ,:HISCOBPR-IMPSEGCDG ,:HISCOBPR-VLCUSTCDG ,:HISCOBPR-COD-USUARIO ,:HISCOBPR-TIMESTAMP ,:HISCOBPR-IMPSEGAUXF:VIND-IMPSEGAUXF ,:HISCOBPR-VLCUSTAUXF:VIND-VLCUSTAUXF ,:HISCOBPR-PRMDIT:VIND-PRMDIT ,:HISCOBPR-QTMDIT:VIND-QTMDIT END-EXEC. */

            if (COBERTURAS.Fetch())
            {
                _.Move(COBERTURAS.HISCOBPR_NUM_CERTIFICADO, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_NUM_CERTIFICADO);
                _.Move(COBERTURAS.HISCOBPR_OCORR_HISTORICO, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_OCORR_HISTORICO);
                _.Move(COBERTURAS.HISCOBPR_DATA_INIVIGENCIA, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_DATA_INIVIGENCIA);
                _.Move(COBERTURAS.HISCOBPR_DATA_TERVIGENCIA, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_DATA_TERVIGENCIA);
                _.Move(COBERTURAS.HISCOBPR_IMPSEGUR, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPSEGUR);
                _.Move(COBERTURAS.HISCOBPR_QUANT_VIDAS, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_QUANT_VIDAS);
                _.Move(COBERTURAS.HISCOBPR_IMPSEGIND, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPSEGIND);
                _.Move(COBERTURAS.HISCOBPR_COD_OPERACAO, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_COD_OPERACAO);
                _.Move(COBERTURAS.HISCOBPR_OPCAO_COBERTURA, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_OPCAO_COBERTURA);
                _.Move(COBERTURAS.HISCOBPR_IMP_MORNATU, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMP_MORNATU);
                _.Move(COBERTURAS.HISCOBPR_IMPMORACID, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPMORACID);
                _.Move(COBERTURAS.HISCOBPR_IMPINVPERM, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPINVPERM);
                _.Move(COBERTURAS.HISCOBPR_IMPAMDS, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPAMDS);
                _.Move(COBERTURAS.HISCOBPR_IMPDH, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPDH);
                _.Move(COBERTURAS.HISCOBPR_IMPDIT, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPDIT);
                _.Move(COBERTURAS.HISCOBPR_VLPREMIO, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_VLPREMIO);
                _.Move(COBERTURAS.HISCOBPR_PRMVG, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_PRMVG);
                _.Move(COBERTURAS.HISCOBPR_PRMAP, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_PRMAP);
                _.Move(COBERTURAS.HISCOBPR_QTDE_TIT_CAPITALIZ, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_QTDE_TIT_CAPITALIZ);
                _.Move(COBERTURAS.HISCOBPR_VAL_TIT_CAPITALIZ, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_VAL_TIT_CAPITALIZ);
                _.Move(COBERTURAS.HISCOBPR_VAL_CUSTO_CAPITALI, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_VAL_CUSTO_CAPITALI);
                _.Move(COBERTURAS.HISCOBPR_IMPSEGCDG, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPSEGCDG);
                _.Move(COBERTURAS.HISCOBPR_VLCUSTCDG, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_VLCUSTCDG);
                _.Move(COBERTURAS.HISCOBPR_COD_USUARIO, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_COD_USUARIO);
                _.Move(COBERTURAS.HISCOBPR_TIMESTAMP, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_TIMESTAMP);
                _.Move(COBERTURAS.HISCOBPR_IMPSEGAUXF, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPSEGAUXF);
                _.Move(COBERTURAS.VIND_IMPSEGAUXF, VIND_IMPSEGAUXF);
                _.Move(COBERTURAS.HISCOBPR_VLCUSTAUXF, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_VLCUSTAUXF);
                _.Move(COBERTURAS.VIND_VLCUSTAUXF, VIND_VLCUSTAUXF);
                _.Move(COBERTURAS.HISCOBPR_PRMDIT, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_PRMDIT);
                _.Move(COBERTURAS.VIND_PRMDIT, VIND_PRMDIT);
                _.Move(COBERTURAS.HISCOBPR_QTMDIT, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_QTMDIT);
                _.Move(COBERTURAS.VIND_QTMDIT, VIND_QTMDIT);
            }

        }

        [StopWatch]
        /*" R0450-00-OBTER-COBERTURA-DB-CLOSE-1 */
        public void R0450_00_OBTER_COBERTURA_DB_CLOSE_1()
        {
            /*" -1372- EXEC SQL CLOSE COBERTURAS END-EXEC. */

            COBERTURAS.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0450_SAIDA*/

        [StopWatch]
        /*" R0570-00-LER-COMISSAO-SECTION */
        private void R0570_00_LER_COMISSAO_SECTION()
        {
            /*" -1390- MOVE 'R0570-00-LER-COMISSAO' TO PARAGRAFO. */
            _.Move("R0570-00-LER-COMISSAO", WABEND2.PARAGRAFO);

            /*" -1392- MOVE 'DECLARE FUNDOCOMISVA' TO COMANDO. */
            _.Move("DECLARE FUNDOCOMISVA", WABEND2.COMANDO);

            /*" -1395- MOVE PROPOVA-NUM-CERTIFICADO TO NUM-CERTIFICADO OF DCLFUNDO-COMISSAO-VA. */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO, FDCOMVA.DCLFUNDO_COMISSAO_VA.NUM_CERTIFICADO);

            /*" -1398- MOVE 1101 TO COD-OPERACAO OF DCLFUNDO-COMISSAO-VA. */
            _.Move(1101, FDCOMVA.DCLFUNDO_COMISSAO_VA.COD_OPERACAO);

            /*" -1408- PERFORM R0570_00_LER_COMISSAO_DB_DECLARE_1 */

            R0570_00_LER_COMISSAO_DB_DECLARE_1();

            /*" -1411- MOVE 'OPEN FUNDOCOMISVA' TO COMANDO. */
            _.Move("OPEN FUNDOCOMISVA", WABEND2.COMANDO);

            /*" -1411- PERFORM R0570_00_LER_COMISSAO_DB_OPEN_1 */

            R0570_00_LER_COMISSAO_DB_OPEN_1();

            /*" -1414- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1415- DISPLAY 'VA0126B - ERRO OPEN CURSOR FUNDOCOMISVA' */
                _.Display($"VA0126B - ERRO OPEN CURSOR FUNDOCOMISVA");

                /*" -1417- DISPLAY '          CERTIFICADO = ' NUM-CERTIFICADO OF DCLFUNDO-COMISSAO-VA */
                _.Display($"          CERTIFICADO = {FDCOMVA.DCLFUNDO_COMISSAO_VA.NUM_CERTIFICADO}");

                /*" -1419- DISPLAY '          OPERACAO    = ' COD-OPERACAO OF DCLFUNDO-COMISSAO-VA */
                _.Display($"          OPERACAO    = {FDCOMVA.DCLFUNDO_COMISSAO_VA.COD_OPERACAO}");

                /*" -1420- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -1422- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


            /*" -1428- PERFORM R0570_00_LER_COMISSAO_DB_FETCH_1 */

            R0570_00_LER_COMISSAO_DB_FETCH_1();

            /*" -1431- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1432- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1434- MOVE ZEROS TO VAL-COMISSAO-VG OF DCLFUNDO-COMISSAO-VA */
                    _.Move(0, FDCOMVA.DCLFUNDO_COMISSAO_VA.VAL_COMISSAO_VG);

                    /*" -1436- MOVE ZEROS TO VAL-COMISSAO-AP OF DCLFUNDO-COMISSAO-VA */
                    _.Move(0, FDCOMVA.DCLFUNDO_COMISSAO_VA.VAL_COMISSAO_AP);

                    /*" -1437- ELSE */
                }
                else
                {


                    /*" -1438- DISPLAY 'VA0126B - ERRO SELECT CURSOR FUNDOCOMISVA' */
                    _.Display($"VA0126B - ERRO SELECT CURSOR FUNDOCOMISVA");

                    /*" -1440- DISPLAY '          CERTIFICADO = ' NUM-CERTIFICADO OF DCLFUNDO-COMISSAO-VA */
                    _.Display($"          CERTIFICADO = {FDCOMVA.DCLFUNDO_COMISSAO_VA.NUM_CERTIFICADO}");

                    /*" -1442- DISPLAY '          OPERACAO    = ' COD-OPERACAO OF DCLFUNDO-COMISSAO-VA */
                    _.Display($"          OPERACAO    = {FDCOMVA.DCLFUNDO_COMISSAO_VA.COD_OPERACAO}");

                    /*" -1443- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -1445- PERFORM R9999-00-FINALIZAR. */

                    R9999_00_FINALIZAR_SECTION();
                }

            }


            /*" -1445- PERFORM R0570_00_LER_COMISSAO_DB_CLOSE_1 */

            R0570_00_LER_COMISSAO_DB_CLOSE_1();

            /*" -1448- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1449- DISPLAY 'VA0126B - ERRO CLOSE CURSOR FUNDOCOMISVA ' */
                _.Display($"VA0126B - ERRO CLOSE CURSOR FUNDOCOMISVA ");

                /*" -1451- DISPLAY '          CERTIFICADO = ' NUM-CERTIFICADO OF DCLFUNDO-COMISSAO-VA */
                _.Display($"          CERTIFICADO = {FDCOMVA.DCLFUNDO_COMISSAO_VA.NUM_CERTIFICADO}");

                /*" -1453- DISPLAY '          OPERACAO    = ' COD-OPERACAO OF DCLFUNDO-COMISSAO-VA */
                _.Display($"          OPERACAO    = {FDCOMVA.DCLFUNDO_COMISSAO_VA.COD_OPERACAO}");

                /*" -1454- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -1454- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R0570-00-LER-COMISSAO-DB-OPEN-1 */
        public void R0570_00_LER_COMISSAO_DB_OPEN_1()
        {
            /*" -1411- EXEC SQL OPEN FUNDOCOMISVA END-EXEC. */

            FUNDOCOMISVA.Open();

        }

        [StopWatch]
        /*" R6000-00-DECLARE-AGENCEF-DB-DECLARE-1 */
        public void R6000_00_DECLARE_AGENCEF_DB_DECLARE_1()
        {
            /*" -2236- EXEC SQL DECLARE C01_AGENCEF CURSOR FOR SELECT A.COD_AGENCIA ,B.COD_FONTE FROM SEGUROS.AGENCIAS_CEF A ,SEGUROS.MALHA_CEF B WHERE A.COD_ESCNEG > 99 AND A.COD_ESCNEG < 1000 AND A.COD_ESCNEG = B.COD_SUREG ORDER BY A.COD_AGENCIA WITH UR END-EXEC. */
            C01_AGENCEF = new VA0126B_C01_AGENCEF(false);
            string GetQuery_C01_AGENCEF()
            {
                var query = @$"SELECT A.COD_AGENCIA 
							,B.COD_FONTE 
							FROM SEGUROS.AGENCIAS_CEF A 
							,SEGUROS.MALHA_CEF B 
							WHERE A.COD_ESCNEG > 99 
							AND A.COD_ESCNEG < 1000 
							AND A.COD_ESCNEG = B.COD_SUREG 
							ORDER BY A.COD_AGENCIA";

                return query;
            }
            C01_AGENCEF.GetQueryEvent += GetQuery_C01_AGENCEF;

        }

        [StopWatch]
        /*" R0570-00-LER-COMISSAO-DB-FETCH-1 */
        public void R0570_00_LER_COMISSAO_DB_FETCH_1()
        {
            /*" -1428- EXEC SQL FETCH FUNDOCOMISVA INTO :DCLFUNDO-COMISSAO-VA.NUM-CERTIFICADO ,:DCLFUNDO-COMISSAO-VA.VAL-COMISSAO-VG ,:DCLFUNDO-COMISSAO-VA.VAL-COMISSAO-AP END-EXEC. */

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
            /*" -1445- EXEC SQL CLOSE FUNDOCOMISVA END-EXEC. */

            FUNDOCOMISVA.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0570_SAIDA*/

        [StopWatch]
        /*" R0580-00-OBTER-VAL-TARIFA-SECTION */
        private void R0580_00_OBTER_VAL_TARIFA_SECTION()
        {
            /*" -1463- MOVE 'R0580-00-OBTER-VAL-TARIFA' TO PARAGRAFO. */
            _.Move("R0580-00-OBTER-VAL-TARIFA", WABEND2.PARAGRAFO);

            /*" -1465- MOVE 'SELECT TARIFA-BALCAO-CEF' TO COMANDO. */
            _.Move("SELECT TARIFA-BALCAO-CEF", WABEND2.COMANDO);

            /*" -1468- MOVE PROPOVA-NUM-CERTIFICADO TO NUM-CERTIFICADO OF DCLTARIFA-BALCAO-CEF. */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO, TARIBCEF.DCLTARIFA_BALCAO_CEF.NUM_CERTIFICADO);

            /*" -1478- PERFORM R0580_00_OBTER_VAL_TARIFA_DB_SELECT_1 */

            R0580_00_OBTER_VAL_TARIFA_DB_SELECT_1();

            /*" -1481- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1482- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1484- MOVE ZEROS TO VAL-TARIFA OF DCLTARIFA-BALCAO-CEF */
                    _.Move(0, TARIBCEF.DCLTARIFA_BALCAO_CEF.VAL_TARIFA);

                    /*" -1485- ELSE */
                }
                else
                {


                    /*" -1486- DISPLAY 'VA0126B - ERRO SELECT TARIFA-BALCAO-CEF' */
                    _.Display($"VA0126B - ERRO SELECT TARIFA-BALCAO-CEF");

                    /*" -1488- DISPLAY '          CERTIFICADO = ' NUM-CERTIFICADO OF DCLTARIFA-BALCAO-CEF */
                    _.Display($"          CERTIFICADO = {TARIBCEF.DCLTARIFA_BALCAO_CEF.NUM_CERTIFICADO}");

                    /*" -1489- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -1489- PERFORM R9999-00-FINALIZAR. */

                    R9999_00_FINALIZAR_SECTION();
                }

            }


        }

        [StopWatch]
        /*" R0580-00-OBTER-VAL-TARIFA-DB-SELECT-1 */
        public void R0580_00_OBTER_VAL_TARIFA_DB_SELECT_1()
        {
            /*" -1478- EXEC SQL SELECT VAL_TARIFA INTO :DCLTARIFA-BALCAO-CEF.VAL-TARIFA FROM SEGUROS.TARIFA_BALCAO_CEF WHERE COD_EMPRESA = 0 AND NUM_MATRICULA = 9999999 AND TIPO_FUNCIONARIO = '5' AND NUM_CERTIFICADO = :DCLTARIFA-BALCAO-CEF.NUM-CERTIFICADO WITH UR END-EXEC. */

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
        /*" R0590-00-LER-PROPOSTA-FIDELIZ-SECTION */
        private void R0590_00_LER_PROPOSTA_FIDELIZ_SECTION()
        {
            /*" -1498- MOVE 'R0590-00-LER-PROPOSTA-FIDELIZ' TO PARAGRAFO. */
            _.Move("R0590-00-LER-PROPOSTA-FIDELIZ", WABEND2.PARAGRAFO);

            /*" -1500- MOVE 'SELECT PROPOSTA_FIDELIZ' TO COMANDO. */
            _.Move("SELECT PROPOSTA_FIDELIZ", WABEND2.COMANDO);

            /*" -1513- PERFORM R0590_00_LER_PROPOSTA_FIDELIZ_DB_SELECT_1 */

            R0590_00_LER_PROPOSTA_FIDELIZ_DB_SELECT_1();

            /*" -1516- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -1517- MOVE 1 TO W-PROPFIDEL */
                _.Move(1, W_PROPFIDEL);

                /*" -1518- ELSE */
            }
            else
            {


                /*" -1519- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1520- MOVE 2 TO W-PROPFIDEL */
                    _.Move(2, W_PROPFIDEL);

                    /*" -1521- ELSE */
                }
                else
                {


                    /*" -1522- DISPLAY 'VA0126B - ERRO SELECT PROPOSTA_FIDELIZ ' */
                    _.Display($"VA0126B - ERRO SELECT PROPOSTA_FIDELIZ ");

                    /*" -1524- DISPLAY '          CERTIFICADO = ' PROPOVA-NUM-CERTIFICADO */
                    _.Display($"          CERTIFICADO = {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                    /*" -1525- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -1526- PERFORM R9999-00-FINALIZAR */

                    R9999_00_FINALIZAR_SECTION();

                    /*" -1527- END-IF */
                }


                /*" -1527- END-IF. */
            }


        }

        [StopWatch]
        /*" R0590-00-LER-PROPOSTA-FIDELIZ-DB-SELECT-1 */
        public void R0590_00_LER_PROPOSTA_FIDELIZ_DB_SELECT_1()
        {
            /*" -1513- EXEC SQL SELECT SIT_PROPOSTA, DATA_PROPOSTA, NUM_IDENTIFICACAO, NUM_PROPOSTA_SIVPF INTO :PROPOFID-SIT-PROPOSTA, :PROPOFID-DATA-PROPOSTA, :PROPOFID-NUM-IDENTIFICACAO, :PROPOFID-NUM-PROPOSTA-SIVPF FROM SEGUROS.PROPOSTA_FIDELIZ WHERE NUM_PROPOSTA_SIVPF = :PROPOVA-NUM-CERTIFICADO END-EXEC. */

            var r0590_00_LER_PROPOSTA_FIDELIZ_DB_SELECT_1_Query1 = new R0590_00_LER_PROPOSTA_FIDELIZ_DB_SELECT_1_Query1()
            {
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = R0590_00_LER_PROPOSTA_FIDELIZ_DB_SELECT_1_Query1.Execute(r0590_00_LER_PROPOSTA_FIDELIZ_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PROPOFID_SIT_PROPOSTA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_SIT_PROPOSTA);
                _.Move(executed_1.PROPOFID_DATA_PROPOSTA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_PROPOSTA);
                _.Move(executed_1.PROPOFID_NUM_IDENTIFICACAO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_IDENTIFICACAO);
                _.Move(executed_1.PROPOFID_NUM_PROPOSTA_SIVPF, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0590_SAIDA*/

        [StopWatch]
        /*" R0600-00-PROPOSTA-REGISTRO-TP1-SECTION */
        private void R0600_00_PROPOSTA_REGISTRO_TP1_SECTION()
        {
            /*" -1539- MOVE SPACES TO REG-CLIENTES. */
            _.Move("", LBFPF011.REG_CLIENTES);

            /*" -1542- MOVE '1' TO R1-TIPO-REG OF REG-CLIENTES. */
            _.Move("1", LBFPF011.REG_CLIENTES.R1_TIPO_REG);

            /*" -1545- MOVE PROPOVA-NUM-CERTIFICADO TO R1-NUM-PROPOSTA OF REG-CLIENTES. */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO, LBFPF011.REG_CLIENTES.R1_NUM_PROPOSTA);

            /*" -1548- MOVE CLIENTES-CGCCPF TO R1-CGC-CPF OF REG-CLIENTES. */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF, LBFPF011.REG_CLIENTES.R1_CGC_CPF);

            /*" -1549- IF VIND-DTNASCI LESS ZEROS */

            if (VIND_DTNASCI < 00)
            {

                /*" -1551- MOVE ZEROS TO R1-DATA-NASCIMENTO OF REG-CLIENTES */
                _.Move(0, LBFPF011.REG_CLIENTES.R1_DATA_NASCIMENTO);

                /*" -1552- ELSE */
            }
            else
            {


                /*" -1554- MOVE CLIENTES-DATA-NASCIMENTO TO W-DATA-SQL */
                _.Move(CLIENTES.DCLCLIENTES.CLIENTES_DATA_NASCIMENTO, W_DATA_SQL);

                /*" -1555- MOVE W-DIA-SQL TO W-DIA-TRABALHO */
                _.Move(W_DATA_SQL1.W_DIA_SQL, FILLER_1.W_DIA_TRABALHO);

                /*" -1556- MOVE W-MES-SQL TO W-MES-TRABALHO */
                _.Move(W_DATA_SQL1.W_MES_SQL, FILLER_1.W_MES_TRABALHO);

                /*" -1557- MOVE W-ANO-SQL TO W-ANO-TRABALHO */
                _.Move(W_DATA_SQL1.W_ANO_SQL, FILLER_1.W_ANO_TRABALHO);

                /*" -1559- MOVE W-DATA-TRABALHO TO R1-DATA-NASCIMENTO OF REG-CLIENTES */
                _.Move(W_DATA_TRABALHO, LBFPF011.REG_CLIENTES.R1_DATA_NASCIMENTO);

                /*" -1561- END-IF. */
            }


            /*" -1564- MOVE CLIENTES-NOME-RAZAO TO R1-NOME-PESSOA OF REG-CLIENTES. */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO, LBFPF011.REG_CLIENTES.R1_NOME_PESSOA);

            /*" -1565- IF CLIENTES-TIPO-PESSOA EQUAL 'F' */

            if (CLIENTES.DCLCLIENTES.CLIENTES_TIPO_PESSOA == "F")
            {

                /*" -1567- MOVE 1 TO R1-TIPO-PESSOA OF REG-CLIENTES */
                _.Move(1, LBFPF011.REG_CLIENTES.R1_TIPO_PESSOA);

                /*" -1568- ELSE */
            }
            else
            {


                /*" -1570- MOVE 2 TO R1-TIPO-PESSOA OF REG-CLIENTES */
                _.Move(2, LBFPF011.REG_CLIENTES.R1_TIPO_PESSOA);

                /*" -1572- END-IF. */
            }


            /*" -1576- MOVE ZEROS TO R1-NUM-IDENTIDADE OF REG-CLIENTES R1-DATA-EXPEDICAO-RG OF REG-CLIENTES. */
            _.Move(0, LBFPF011.REG_CLIENTES.R1_NUM_IDENTIDADE, LBFPF011.REG_CLIENTES.R1_DATA_EXPEDICAO_RG);

            /*" -1577- MOVE ZERO TO W-OBTER-DADOS-RG. */
            _.Move(0, W_OBTER_DADOS_RG);

            /*" -1579- PERFORM R0620-00-DADOS-RG. */

            R0620_00_DADOS_RG_SECTION();

            /*" -1580- IF OBTEVE-DADOS-RG */

            if (W_OBTER_DADOS_RG["OBTEVE_DADOS_RG"])
            {

                /*" -1583- MOVE GEDOCCLI-COD-IDENTIFICACAO TO R1-NUM-IDENTIDADE OF REG-CLIENTES */
                _.Move(GEDOCCLI.DCLGE_DOC_CLIENTE.GEDOCCLI_COD_IDENTIFICACAO, LBFPF011.REG_CLIENTES.R1_NUM_IDENTIDADE);

                /*" -1586- MOVE GEDOCCLI-NOM-ORGAO-EXP TO W-NOM-ORGAO-EXP */
                _.Move(GEDOCCLI.DCLGE_DOC_CLIENTE.GEDOCCLI_NOM_ORGAO_EXP, W_NOM_ORGAO_EXP);

                /*" -1589- MOVE W-ORGAO-EXPEDIDOR TO R1-ORGAO-EXPEDIDOR OF REG-CLIENTES */
                _.Move(FILLER_3.W_ORGAO_EXPEDIDOR, LBFPF011.REG_CLIENTES.R1_ORGAO_EXPEDIDOR);

                /*" -1591- MOVE GEDOCCLI-DTH-EXPEDICAO TO W-DATA-SQL */
                _.Move(GEDOCCLI.DCLGE_DOC_CLIENTE.GEDOCCLI_DTH_EXPEDICAO, W_DATA_SQL);

                /*" -1592- MOVE W-DIA-SQL TO W-DIA-TRABALHO */
                _.Move(W_DATA_SQL1.W_DIA_SQL, FILLER_1.W_DIA_TRABALHO);

                /*" -1593- MOVE W-MES-SQL TO W-MES-TRABALHO */
                _.Move(W_DATA_SQL1.W_MES_SQL, FILLER_1.W_MES_TRABALHO);

                /*" -1594- MOVE W-ANO-SQL TO W-ANO-TRABALHO */
                _.Move(W_DATA_SQL1.W_ANO_SQL, FILLER_1.W_ANO_TRABALHO);

                /*" -1597- MOVE W-DATA-TRABALHO TO R1-DATA-EXPEDICAO-RG OF REG-CLIENTES */
                _.Move(W_DATA_TRABALHO, LBFPF011.REG_CLIENTES.R1_DATA_EXPEDICAO_RG);

                /*" -1598- IF VIND-COD-UF LESS ZERO */

                if (VIND_COD_UF < 00)
                {

                    /*" -1600- MOVE SPACES TO R1-UF-EXPEDIDORA OF REG-CLIENTES */
                    _.Move("", LBFPF011.REG_CLIENTES.R1_UF_EXPEDIDORA);

                    /*" -1601- ELSE */
                }
                else
                {


                    /*" -1603- MOVE GEDOCCLI-COD-UF TO R1-UF-EXPEDIDORA OF REG-CLIENTES */
                    _.Move(GEDOCCLI.DCLGE_DOC_CLIENTE.GEDOCCLI_COD_UF, LBFPF011.REG_CLIENTES.R1_UF_EXPEDIDORA);

                    /*" -1604- END-IF */
                }


                /*" -1606- END-IF. */
            }


            /*" -1609- MOVE SPACES TO R1-CODIGO-SEGMENTO OF REG-CLIENTES. */
            _.Move("", LBFPF011.REG_CLIENTES.R1_CODIGO_SEGMENTO);

            /*" -1610- IF PROPOVA-ESTADO-CIVIL EQUAL 'S' */

            if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_ESTADO_CIVIL == "S")
            {

                /*" -1612- MOVE 1 TO R1-ESTADO-CIVIL OF REG-CLIENTES */
                _.Move(1, LBFPF011.REG_CLIENTES.R1_ESTADO_CIVIL);

                /*" -1613- ELSE */
            }
            else
            {


                /*" -1614- IF PROPOVA-ESTADO-CIVIL EQUAL 'C' */

                if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_ESTADO_CIVIL == "C")
                {

                    /*" -1616- MOVE 2 TO R1-ESTADO-CIVIL OF REG-CLIENTES */
                    _.Move(2, LBFPF011.REG_CLIENTES.R1_ESTADO_CIVIL);

                    /*" -1617- ELSE */
                }
                else
                {


                    /*" -1618- IF PROPOVA-ESTADO-CIVIL EQUAL 'V' */

                    if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_ESTADO_CIVIL == "V")
                    {

                        /*" -1620- MOVE 3 TO R1-ESTADO-CIVIL OF REG-CLIENTES */
                        _.Move(3, LBFPF011.REG_CLIENTES.R1_ESTADO_CIVIL);

                        /*" -1621- ELSE */
                    }
                    else
                    {


                        /*" -1624- MOVE 4 TO R1-ESTADO-CIVIL OF REG-CLIENTES. */
                        _.Move(4, LBFPF011.REG_CLIENTES.R1_ESTADO_CIVIL);
                    }

                }

            }


            /*" -1625- IF PROPOVA-IDE-SEXO EQUAL 'M' */

            if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_IDE_SEXO == "M")
            {

                /*" -1626- MOVE 1 TO R1-IDE-SEXO OF REG-CLIENTES */
                _.Move(1, LBFPF011.REG_CLIENTES.R1_IDE_SEXO);

                /*" -1627- ELSE */
            }
            else
            {


                /*" -1629- MOVE 2 TO R1-IDE-SEXO OF REG-CLIENTES. */
                _.Move(2, LBFPF011.REG_CLIENTES.R1_IDE_SEXO);
            }


            /*" -1632- MOVE COD-CBO-TIT TO R1-COD-CBO OF REG-CLIENTES. */
            _.Move(COD_CBO_TIT, LBFPF011.REG_CLIENTES.R1_COD_CBO);

            /*" -1636- MOVE ZEROS TO R1-DDD(1) R1-DDD(2) R1-DDD(3) R1-NUM-FONE(1) R1-NUM-FONE(2) R1-NUM-FONE(3). */
            _.Move(0, LBFPF011.REG_CLIENTES.R1_TELEFONE[1].R1_DDD, LBFPF011.REG_CLIENTES.R1_TELEFONE[2].R1_DDD, LBFPF011.REG_CLIENTES.R1_TELEFONE[3].R1_DDD, LBFPF011.REG_CLIENTES.R1_TELEFONE[1].R1_NUM_FONE, LBFPF011.REG_CLIENTES.R1_TELEFONE[2].R1_NUM_FONE, LBFPF011.REG_CLIENTES.R1_TELEFONE[3].R1_NUM_FONE);

            /*" -1637- IF ENDERECO-CADASTRADO */

            if (W_ENDERECO["ENDERECO_CADASTRADO"])
            {

                /*" -1639- MOVE ENDERECO-DDD OF DCLENDERECOS TO R1-DDD(1) */
                _.Move(ENDERECO.DCLENDERECOS.ENDERECO_DDD, LBFPF011.REG_CLIENTES.R1_TELEFONE[1].R1_DDD);

                /*" -1641- MOVE ENDERECO-TELEFONE OF DCLENDERECOS TO R1-NUM-FONE(1) */
                _.Move(ENDERECO.DCLENDERECOS.ENDERECO_TELEFONE, LBFPF011.REG_CLIENTES.R1_TELEFONE[1].R1_NUM_FONE);

                /*" -1643- MOVE ENDERECO-FAX OF DCLENDERECOS TO R1-NUM-FONE(3) */
                _.Move(ENDERECO.DCLENDERECOS.ENDERECO_FAX, LBFPF011.REG_CLIENTES.R1_TELEFONE[3].R1_NUM_FONE);

                /*" -1645- END-IF. */
            }


            /*" -1646- IF VIND-NOME-ESPOSA LESS ZEROS */

            if (VIND_NOME_ESPOSA < 00)
            {

                /*" -1648- MOVE SPACES TO R1-NOME-CONJUGE OF REG-CLIENTES */
                _.Move("", LBFPF011.REG_CLIENTES.R1_NOME_CONJUGE);

                /*" -1649- ELSE */
            }
            else
            {


                /*" -1652- MOVE PROPOVA-NOME-ESPOSA TO R1-NOME-CONJUGE OF REG-CLIENTES. */
                _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NOME_ESPOSA, LBFPF011.REG_CLIENTES.R1_NOME_CONJUGE);
            }


            /*" -1653- IF VIND-DTNASC-ESPOSA LESS ZEROS */

            if (VIND_DTNASC_ESPOSA < 00)
            {

                /*" -1655- MOVE ZEROS TO R1-DTNASC-CONJUGE OF REG-CLIENTES */
                _.Move(0, LBFPF011.REG_CLIENTES.R1_DTNASC_CONJUGE);

                /*" -1657- MOVE -1 TO VIND-DTNASC-ESPOSA */
                _.Move(-1, VIND_DTNASC_ESPOSA);

                /*" -1658- ELSE */
            }
            else
            {


                /*" -1660- MOVE PROPOVA-DTNASC-ESPOSA TO W-DATA-SQL */
                _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DTNASC_ESPOSA, W_DATA_SQL);

                /*" -1661- MOVE W-DIA-SQL TO W-DIA-TRABALHO */
                _.Move(W_DATA_SQL1.W_DIA_SQL, FILLER_1.W_DIA_TRABALHO);

                /*" -1662- MOVE W-MES-SQL TO W-MES-TRABALHO */
                _.Move(W_DATA_SQL1.W_MES_SQL, FILLER_1.W_MES_TRABALHO);

                /*" -1663- MOVE W-ANO-SQL TO W-ANO-TRABALHO */
                _.Move(W_DATA_SQL1.W_ANO_SQL, FILLER_1.W_ANO_TRABALHO);

                /*" -1666- MOVE W-DATA-TRABALHO TO R1-DTNASC-CONJUGE OF REG-CLIENTES. */
                _.Move(W_DATA_TRABALHO, LBFPF011.REG_CLIENTES.R1_DTNASC_CONJUGE);
            }


            /*" -1669- MOVE COD-CBO-CONJ TO R1-CBO-CONJUGE OF REG-CLIENTES. */
            _.Move(COD_CBO_CONJ, LBFPF011.REG_CLIENTES.R1_CBO_CONJUGE);

            /*" -1672- MOVE SPACES TO R1-EMAIL OF REG-CLIENTES. */
            _.Move("", LBFPF011.REG_CLIENTES.R1_EMAIL);

            /*" -1675- MOVE PROPOVA-PROFIS-ESPOSA TO R1-DESCRICAO-PROFISSAO OF REG-CLIENTES. */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_PROFIS_ESPOSA, LBFPF011.REG_CLIENTES.R1_DESCRICAO_PROFISSAO);

            /*" -1676- IF VIND-FAIXA-RENDA-IND NOT LESS ZEROS */

            if (VIND_FAIXA_RENDA_IND >= 00)
            {

                /*" -1679- MOVE PROPOVA-FAIXA-RENDA-IND TO R1-RENDA-INDIVIDUAL OF REG-CLIENTES. */
                _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_FAIXA_RENDA_IND, LBFPF011.REG_CLIENTES.R1_RENDA_INDIVIDUAL);
            }


            /*" -1680- IF VIND-FAIXA-RENDA-FAM NOT LESS ZEROS */

            if (VIND_FAIXA_RENDA_FAM >= 00)
            {

                /*" -1683- MOVE PROPOVA-FAIXA-RENDA-FAM TO R1-RENDA-FAMILIAR OF REG-CLIENTES. */
                _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_FAIXA_RENDA_FAM, LBFPF011.REG_CLIENTES.R1_RENDA_FAMILIAR);
            }


            /*" -1684- WRITE REG-PRP-SASSE FROM REG-CLIENTES. */
            _.Move(LBFPF011.REG_CLIENTES.GetMoveValues(), REG_PRP_SASSE);

            MOVTO_PRP_SASSE.Write(REG_PRP_SASSE.GetMoveValues().ToString());

            /*" -1684- ADD 1 TO W-QTD-LD-TIPO-1. */
            W_QTD_LD_TIPO_1.Value = W_QTD_LD_TIPO_1 + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0600_SAIDA*/

        [StopWatch]
        /*" R0620-00-DADOS-RG-SECTION */
        private void R0620_00_DADOS_RG_SECTION()
        {
            /*" -1693- MOVE 'R0620-00-DADOS-RG' TO PARAGRAFO. */
            _.Move("R0620-00-DADOS-RG", WABEND2.PARAGRAFO);

            /*" -1695- MOVE 'SELECT GE_DOC_CLIENTES' TO COMANDO. */
            _.Move("SELECT GE_DOC_CLIENTES", WABEND2.COMANDO);

            /*" -1697- MOVE CLIENTES-COD-CLIENTE TO GEDOCCLI-COD-CLIENTE. */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_COD_CLIENTE, GEDOCCLI.DCLGE_DOC_CLIENTE.GEDOCCLI_COD_CLIENTE);

            /*" -1712- PERFORM R0620_00_DADOS_RG_DB_SELECT_1 */

            R0620_00_DADOS_RG_DB_SELECT_1();

            /*" -1715- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1717- IF SQLCODE EQUAL 100 NEXT SENTENCE */

                if (DB.SQLCODE == 100)
                {

                    /*" -1718- ELSE */
                }
                else
                {


                    /*" -1719- DISPLAY 'VA0126B - ERRO SELECT TAB. GE_DOC_CLIENTE' */
                    _.Display($"VA0126B - ERRO SELECT TAB. GE_DOC_CLIENTE");

                    /*" -1721- DISPLAY '          NUMERO CERTIFICADO = ' PROPOVA-NUM-CERTIFICADO */
                    _.Display($"          NUMERO CERTIFICADO = {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                    /*" -1723- DISPLAY '          CODIGO DO CLIENTE  = ' GEDOCCLI-COD-CLIENTE */
                    _.Display($"          CODIGO DO CLIENTE  = {GEDOCCLI.DCLGE_DOC_CLIENTE.GEDOCCLI_COD_CLIENTE}");

                    /*" -1724- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -1725- PERFORM R9999-00-FINALIZAR */

                    R9999_00_FINALIZAR_SECTION();

                    /*" -1726- ELSE */
                }

            }
            else
            {


                /*" -1726- MOVE 1 TO W-OBTER-DADOS-RG. */
                _.Move(1, W_OBTER_DADOS_RG);
            }


        }

        [StopWatch]
        /*" R0620-00-DADOS-RG-DB-SELECT-1 */
        public void R0620_00_DADOS_RG_DB_SELECT_1()
        {
            /*" -1712- EXEC SQL SELECT COD_CLIENTE , COD_IDENTIFICACAO , NOM_ORGAO_EXP , DTH_EXPEDICAO , COD_UF INTO :GEDOCCLI-COD-CLIENTE , :GEDOCCLI-COD-IDENTIFICACAO , :GEDOCCLI-NOM-ORGAO-EXP , :GEDOCCLI-DTH-EXPEDICAO , :GEDOCCLI-COD-UF:VIND-COD-UF FROM SEGUROS.GE_DOC_CLIENTE WHERE COD_CLIENTE = :GEDOCCLI-COD-CLIENTE END-EXEC. */

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
        /*" R0700-00-PROPOSTA-REGISTRO-TP3-SECTION */
        private void R0700_00_PROPOSTA_REGISTRO_TP3_SECTION()
        {
            /*" -1738- MOVE SPACES TO REG-PROPOSTA-SASSE. */
            _.Move("", LXFCT004.REG_PROPOSTA_SASSE);

            /*" -1741- MOVE '3' TO R3-TIPO-REG OF REG-PROPOSTA-SASSE. */
            _.Move("3", LXFCT004.REG_PROPOSTA_SASSE.R3_TIPO_REG);

            /*" -1744- MOVE PROPOVA-NUM-CERTIFICADO TO R3-NUM-PROPOSTA OF REG-PROPOSTA-SASSE. */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO, LXFCT004.REG_PROPOSTA_SASSE.R3_NUM_PROPOSTA);

            /*" -1747- MOVE PRDSIVPF-COD-PRODUTO-SIVPF OF DCLPRODUTOS-SIVPF TO R3-COD-PRODUTO OF REG-PROPOSTA-SASSE. */
            _.Move(PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_PRODUTO_SIVPF, LXFCT004.REG_PROPOSTA_SASSE.R3_COD_PRODUTO);

            /*" -1750- MOVE PROPOVA-AGE-COBRANCA TO R3-AGECOBR OF REG-PROPOSTA-SASSE. */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_AGE_COBRANCA, LXFCT004.REG_PROPOSTA_SASSE.R3_AGECOBR);

            /*" -1751- MOVE PROPOVA-DATA-QUITACAO TO W-DATA-SQL */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DATA_QUITACAO, W_DATA_SQL);

            /*" -1752- MOVE W-DIA-SQL TO W-DIA-TRABALHO */
            _.Move(W_DATA_SQL1.W_DIA_SQL, FILLER_1.W_DIA_TRABALHO);

            /*" -1753- MOVE W-MES-SQL TO W-MES-TRABALHO */
            _.Move(W_DATA_SQL1.W_MES_SQL, FILLER_1.W_MES_TRABALHO);

            /*" -1755- MOVE W-ANO-SQL TO W-ANO-TRABALHO. */
            _.Move(W_DATA_SQL1.W_ANO_SQL, FILLER_1.W_ANO_TRABALHO);

            /*" -1760- MOVE W-DATA-TRABALHO TO R3-DATA-PROPOSTA OF REG-PROPOSTA-SASSE. */
            _.Move(W_DATA_TRABALHO, LXFCT004.REG_PROPOSTA_SASSE.R3_DATA_PROPOSTA);

            /*" -1763- IF OPCPAGVI-OPCAO-PAGAMENTO EQUAL 1 OR 2 */

            if (OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPCAO_PAGAMENTO.In("1", "2"))
            {

                /*" -1765- MOVE 1 TO R3-OPCAOPAG OF REG-PROPOSTA-SASSE. */
                _.Move(1, LXFCT004.REG_PROPOSTA_SASSE.R3_OPCAOPAG);
            }


            /*" -1767- IF OPCPAGVI-OPCAO-PAGAMENTO EQUAL 3 */

            if (OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPCAO_PAGAMENTO == 3)
            {

                /*" -1769- MOVE 2 TO R3-OPCAOPAG OF REG-PROPOSTA-SASSE. */
                _.Move(2, LXFCT004.REG_PROPOSTA_SASSE.R3_OPCAOPAG);
            }


            /*" -1771- IF OPCPAGVI-OPCAO-PAGAMENTO EQUAL 4 */

            if (OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPCAO_PAGAMENTO == 4)
            {

                /*" -1773- MOVE 4 TO R3-OPCAOPAG OF REG-PROPOSTA-SASSE. */
                _.Move(4, LXFCT004.REG_PROPOSTA_SASSE.R3_OPCAOPAG);
            }


            /*" -1775- IF OPCPAGVI-OPCAO-PAGAMENTO EQUAL 5 */

            if (OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPCAO_PAGAMENTO == 5)
            {

                /*" -1777- MOVE 3 TO R3-OPCAOPAG OF REG-PROPOSTA-SASSE. */
                _.Move(3, LXFCT004.REG_PROPOSTA_SASSE.R3_OPCAOPAG);
            }


            /*" -1778- IF R3-OPCAOPAG OF REG-PROPOSTA-SASSE EQUAL 1 OR 4 */

            if (LXFCT004.REG_PROPOSTA_SASSE.R3_OPCAOPAG.In("1", "4"))
            {

                /*" -1781- MOVE OPCPAGVI-DIA-DEBITO TO R3-DIA-DEBITO OF REG-PROPOSTA-SASSE. */
                _.Move(OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_DIA_DEBITO, LXFCT004.REG_PROPOSTA_SASSE.R3_DIA_DEBITO);
            }


            /*" -1782- IF VIND-AGECTADEB LESS ZEROS */

            if (VIND_AGECTADEB < 00)
            {

                /*" -1784- MOVE ZEROS TO R3-AGECTADEB OF REG-PROPOSTA-SASSE */
                _.Move(0, LXFCT004.REG_PROPOSTA_SASSE.R3_CONTA_DEBITO.R3_AGECTADEB);

                /*" -1785- ELSE */
            }
            else
            {


                /*" -1787- MOVE OPCPAGVI-COD-AGENCIA-DEBITO TO R3-AGECTADEB OF REG-PROPOSTA-SASSE */
                _.Move(OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_COD_AGENCIA_DEBITO, LXFCT004.REG_PROPOSTA_SASSE.R3_CONTA_DEBITO.R3_AGECTADEB);

                /*" -1789- END-IF. */
            }


            /*" -1790- IF VIND-OPRCTADEB LESS ZEROS */

            if (VIND_OPRCTADEB < 00)
            {

                /*" -1792- MOVE ZEROS TO R3-OPRCTADEB OF REG-PROPOSTA-SASSE */
                _.Move(0, LXFCT004.REG_PROPOSTA_SASSE.R3_CONTA_DEBITO.R3_OPRCTADEB);

                /*" -1793- ELSE */
            }
            else
            {


                /*" -1795- MOVE OPCPAGVI-OPE-CONTA-DEBITO TO R3-OPRCTADEB OF REG-PROPOSTA-SASSE */
                _.Move(OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPE_CONTA_DEBITO, LXFCT004.REG_PROPOSTA_SASSE.R3_CONTA_DEBITO.R3_OPRCTADEB);

                /*" -1797- END-IF. */
            }


            /*" -1798- IF VIND-NUMCTADEB LESS ZEROS */

            if (VIND_NUMCTADEB < 00)
            {

                /*" -1800- MOVE ZEROS TO R3-NUMCTADEB OF REG-PROPOSTA-SASSE */
                _.Move(0, LXFCT004.REG_PROPOSTA_SASSE.R3_CONTA_DEBITO.R3_NUMCTADEB);

                /*" -1801- ELSE */
            }
            else
            {


                /*" -1803- MOVE OPCPAGVI-NUM-CONTA-DEBITO TO R3-NUMCTADEB OF REG-PROPOSTA-SASSE */
                _.Move(OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CONTA_DEBITO, LXFCT004.REG_PROPOSTA_SASSE.R3_CONTA_DEBITO.R3_NUMCTADEB);

                /*" -1805- END-IF. */
            }


            /*" -1806- IF VIND-DIGCTADEB LESS ZEROS */

            if (VIND_DIGCTADEB < 00)
            {

                /*" -1808- MOVE ZEROS TO R3-DIGCTADEB OF REG-PROPOSTA-SASSE */
                _.Move(0, LXFCT004.REG_PROPOSTA_SASSE.R3_CONTA_DEBITO.R3_DIGCTADEB);

                /*" -1809- ELSE */
            }
            else
            {


                /*" -1811- MOVE OPCPAGVI-DIG-CONTA-DEBITO TO R3-DIGCTADEB OF REG-PROPOSTA-SASSE */
                _.Move(OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_DIG_CONTA_DEBITO, LXFCT004.REG_PROPOSTA_SASSE.R3_CONTA_DEBITO.R3_DIGCTADEB);

                /*" -1813- END-IF. */
            }


            /*" -1816- MOVE PROPOVA-NUM-MATRI-VENDEDOR TO R3-NRMATRVEN OF REG-PROPOSTA-SASSE. */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_MATRI_VENDEDOR, LXFCT004.REG_PROPOSTA_SASSE.R3_NRMATRVEN);

            /*" -1817- IF VIND-DPS-TITULAR LESS ZEROS */

            if (VIND_DPS_TITULAR < 00)
            {

                /*" -1819- MOVE SPACES TO R3-DPS-TITULAR OF REG-PROPOSTA-SASSE */
                _.Move("", LXFCT004.REG_PROPOSTA_SASSE.R3_DPS_TITULAR);

                /*" -1820- ELSE */
            }
            else
            {


                /*" -1823- MOVE PROPOVA-DPS-TITULAR TO R3-DPS-TITULAR OF REG-PROPOSTA-SASSE. */
                _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DPS_TITULAR, LXFCT004.REG_PROPOSTA_SASSE.R3_DPS_TITULAR);
            }


            /*" -1824- IF VIND-DPS-ESPOSA LESS ZEROS */

            if (VIND_DPS_ESPOSA < 00)
            {

                /*" -1826- MOVE SPACES TO R3-DPS-CONJUGE OF REG-PROPOSTA-SASSE */
                _.Move("", LXFCT004.REG_PROPOSTA_SASSE.R3_DPS_CONJUGE);

                /*" -1827- ELSE */
            }
            else
            {


                /*" -1830- MOVE PROPOVA-DPS-ESPOSA TO R3-DPS-CONJUGE OF REG-PROPOSTA-SASSE. */
                _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DPS_ESPOSA, LXFCT004.REG_PROPOSTA_SASSE.R3_DPS_CONJUGE);
            }


            /*" -1831- IF VIND-APOS-INVALIDEZ LESS ZEROS */

            if (VIND_APOS_INVALIDEZ < 00)
            {

                /*" -1833- MOVE SPACES TO R3-APOS-INVALIDEZ OF REG-PROPOSTA-SASSE */
                _.Move("", LXFCT004.REG_PROPOSTA_SASSE.R3_APOS_INVALIDEZ);

                /*" -1834- ELSE */
            }
            else
            {


                /*" -1837- MOVE PROPOVA-APOS-INVALIDEZ TO R3-APOS-INVALIDEZ OF REG-PROPOSTA-SASSE. */
                _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_APOS_INVALIDEZ, LXFCT004.REG_PROPOSTA_SASSE.R3_APOS_INVALIDEZ);
            }


            /*" -1841- MOVE SPACES TO R3-RENOVACAO-AUTOM OF REG-PROPOSTA-SASSE R3-NOME-CONVENENTE OF REG-PROPOSTA-SASSE. */
            _.Move("", LXFCT004.REG_PROPOSTA_SASSE.R3_RENOVACAO_AUTOM, LXFCT004.REG_PROPOSTA_SASSE.R3_NOME_CONVENENTE);

            /*" -1848- MOVE ZEROS TO R3-PCT-DESCONTO OF REG-PROPOSTA-SASSE R3-CGC-CONVENENTE OF REG-PROPOSTA-SASSE R3-SIT-MOTIVO OF REG-PROPOSTA-SASSE. */
            _.Move(0, LXFCT004.REG_PROPOSTA_SASSE.R3_PCT_DESCONTO, LXFCT004.REG_PROPOSTA_SASSE.R3_CGC_CONVENENTE, LXFCT004.REG_PROPOSTA_SASSE.R3_SIT_MOTIVO);

            /*" -1851- MOVE PROPOFID-SIT-PROPOSTA TO R3-SIT-PROPOSTA OF REG-PROPOSTA-SASSE. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_SIT_PROPOSTA, LXFCT004.REG_PROPOSTA_SASSE.R3_SIT_PROPOSTA);

            /*" -1854- MOVE 'PAG' TO R3-SIT-COBRANCA OF REG-PROPOSTA-SASSE. */
            _.Move("PAG", LXFCT004.REG_PROPOSTA_SASSE.R3_SIT_COBRANCA);

            /*" -1858- MOVE PROPOVA-OPCAO-COBERTURA TO R3-OPCAO-COBER OF REG-PROPOSTA-SASSE. */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_OPCAO_COBERTURA, LXFCT004.REG_PROPOSTA_SASSE.R3_OPCAO_COBER);

            /*" -1861- MOVE PROPOVA-NUM-PRAZO-FIN TO R3-COD-PLANO OF REG-PROPOSTA-SASSE. */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_PRAZO_FIN, LXFCT004.REG_PROPOSTA_SASSE.R3_COD_PLANO);

            /*" -1863- MOVE PROPOVA-DATA-QUITACAO TO W-DATA-SQL. */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DATA_QUITACAO, W_DATA_SQL);

            /*" -1864- MOVE W-DIA-SQL TO W-DIA-TRABALHO */
            _.Move(W_DATA_SQL1.W_DIA_SQL, FILLER_1.W_DIA_TRABALHO);

            /*" -1865- MOVE W-MES-SQL TO W-MES-TRABALHO */
            _.Move(W_DATA_SQL1.W_MES_SQL, FILLER_1.W_MES_TRABALHO);

            /*" -1866- MOVE W-ANO-SQL TO W-ANO-TRABALHO */
            _.Move(W_DATA_SQL1.W_ANO_SQL, FILLER_1.W_ANO_TRABALHO);

            /*" -1870- MOVE W-DATA-TRABALHO TO R3-DTQITBCO OF REG-PROPOSTA-SASSE. */
            _.Move(W_DATA_TRABALHO, LXFCT004.REG_PROPOSTA_SASSE.R3_DTQITBCO);

            /*" -1874- MOVE HISCOBPR-VLPREMIO TO R3-VALOR-PREMIO-TOTAL OF REG-PROPOSTA-SASSE. */
            _.Move(HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_VLPREMIO, LXFCT004.REG_PROPOSTA_SASSE.R3_VALOR_PREMIO_TOTAL);

            /*" -1877- MOVE RCAPS-VAL-RCAP TO R3-VAL-PAGO OF REG-PROPOSTA-SASSE. */
            _.Move(RCAPS.DCLRCAPS.RCAPS_VAL_RCAP, LXFCT004.REG_PROPOSTA_SASSE.R3_VAL_PAGO);

            /*" -1880- MOVE RCAPS-AGE-COBRANCA TO R3-AGEPGTO OF REG-PROPOSTA-SASSE. */
            _.Move(RCAPS.DCLRCAPS.RCAPS_AGE_COBRANCA, LXFCT004.REG_PROPOSTA_SASSE.R3_AGEPGTO);

            /*" -1883- MOVE VAL-TARIFA OF DCLTARIFA-BALCAO-CEF TO R3-VAL-TARIFA OF REG-PROPOSTA-SASSE. */
            _.Move(TARIBCEF.DCLTARIFA_BALCAO_CEF.VAL_TARIFA, LXFCT004.REG_PROPOSTA_SASSE.R3_VAL_TARIFA);

            /*" -1885- MOVE RCAPS-DATA-MOVIMENTO TO W-DATA-SQL. */
            _.Move(RCAPS.DCLRCAPS.RCAPS_DATA_MOVIMENTO, W_DATA_SQL);

            /*" -1886- MOVE W-DIA-SQL TO W-DIA-TRABALHO */
            _.Move(W_DATA_SQL1.W_DIA_SQL, FILLER_1.W_DIA_TRABALHO);

            /*" -1887- MOVE W-MES-SQL TO W-MES-TRABALHO */
            _.Move(W_DATA_SQL1.W_MES_SQL, FILLER_1.W_MES_TRABALHO);

            /*" -1888- MOVE W-ANO-SQL TO W-ANO-TRABALHO */
            _.Move(W_DATA_SQL1.W_ANO_SQL, FILLER_1.W_ANO_TRABALHO);

            /*" -1891- MOVE W-DATA-TRABALHO TO R3-DATA-CREDITO OF REG-PROPOSTA-SASSE. */
            _.Move(W_DATA_TRABALHO, LXFCT004.REG_PROPOSTA_SASSE.R3_DATA_CREDITO);

            /*" -1895- COMPUTE R3-VAL-COMISSAO OF REG-PROPOSTA-SASSE = VAL-COMISSAO-VG OF DCLFUNDO-COMISSAO-VA + VAL-COMISSAO-AP OF DCLFUNDO-COMISSAO-VA. */
            LXFCT004.REG_PROPOSTA_SASSE.R3_VAL_COMISSAO.Value = FDCOMVA.DCLFUNDO_COMISSAO_VA.VAL_COMISSAO_VG + FDCOMVA.DCLFUNDO_COMISSAO_VA.VAL_COMISSAO_AP;

            /*" -1898- MOVE OPCPAGVI-PERI-PAGAMENTO TO R3-PERIPGTO OF REG-PROPOSTA-SASSE. */
            _.Move(OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_PERI_PAGAMENTO, LXFCT004.REG_PROPOSTA_SASSE.R3_PERIPGTO);

            /*" -1901- MOVE RH-NSAS OF REG-HEADER TO R3-NSAS OF REG-PROPOSTA-SASSE. */
            _.Move(LBFPF990.REG_HEADER.RH_NSAS, LXFCT004.REG_PROPOSTA_SASSE.R3_NSAS);

            /*" -1905- MOVE 6 TO R3-ORIGEM-PROPOSTA OF REG-PROPOSTA-SASSE. */
            _.Move(6, LXFCT004.REG_PROPOSTA_SASSE.R3_ORIGEM_PROPOSTA_AIC);

            /*" -1906- ADD 1 TO W-QTD-LD-TIPO-3. */
            W_QTD_LD_TIPO_3.Value = W_QTD_LD_TIPO_3 + 1;

            /*" -1909- MOVE W-QTD-LD-TIPO-3 TO R3-NSL OF REG-PROPOSTA-SASSE. */
            _.Move(W_QTD_LD_TIPO_3, LXFCT004.REG_PROPOSTA_SASSE.R3_NSL);

            /*" -1909- WRITE REG-PRP-SASSE FROM REG-PROPOSTA-SASSE. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.GetMoveValues(), REG_PRP_SASSE);

            MOVTO_PRP_SASSE.Write(REG_PRP_SASSE.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0700_SAIDA*/

        [StopWatch]
        /*" R1000-00-GERAR-TRAILLER-SECTION */
        private void R1000_00_GERAR_TRAILLER_SECTION()
        {
            /*" -1922- MOVE 'T' TO RT-TIPO-REG OF REG-TRAILLER. */
            _.Move("T", LBFPF991.REG_TRAILLER.RT_TIPO_REG);

            /*" -1925- MOVE 'PRPSASSE' TO RT-NOME-EMPRESA OF REG-TRAILLER. */
            _.Move("PRPSASSE", LBFPF991.REG_TRAILLER.RT_NOME_EMPRESA);

            /*" -1928- MOVE W-QTD-LD-TIPO-0 TO RT-QTDE-TIPO-0 OF REG-TRAILLER. */
            _.Move(W_QTD_LD_TIPO_0, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_0);

            /*" -1931- MOVE W-QTD-LD-TIPO-1 TO RT-QTDE-TIPO-1 OF REG-TRAILLER. */
            _.Move(W_QTD_LD_TIPO_1, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_1);

            /*" -1934- MOVE W-QTD-LD-TIPO-2 TO RT-QTDE-TIPO-2 OF REG-TRAILLER. */
            _.Move(W_QTD_LD_TIPO_2, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_2);

            /*" -1937- MOVE W-QTD-LD-TIPO-3 TO RT-QTDE-TIPO-3 OF REG-TRAILLER. */
            _.Move(W_QTD_LD_TIPO_3, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_3);

            /*" -1940- MOVE W-QTD-LD-TIPO-4 TO RT-QTDE-TIPO-4 OF REG-TRAILLER. */
            _.Move(W_QTD_LD_TIPO_4, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_4);

            /*" -1943- MOVE W-QTD-LD-TIPO-5 TO RT-QTDE-TIPO-5 OF REG-TRAILLER. */
            _.Move(W_QTD_LD_TIPO_5, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_5);

            /*" -1946- MOVE W-QTD-LD-TIPO-6 TO RT-QTDE-TIPO-6 OF REG-TRAILLER. */
            _.Move(W_QTD_LD_TIPO_6, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_6);

            /*" -1949- MOVE W-QTD-LD-TIPO-7 TO RT-QTDE-TIPO-7 OF REG-TRAILLER. */
            _.Move(W_QTD_LD_TIPO_7, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_7);

            /*" -1952- MOVE W-QTD-LD-TIPO-8 TO RT-QTDE-TIPO-8 OF REG-TRAILLER. */
            _.Move(W_QTD_LD_TIPO_8, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_8);

            /*" -1955- MOVE W-QTD-LD-TIPO-9 TO RT-QTDE-TIPO-9 OF REG-TRAILLER. */
            _.Move(W_QTD_LD_TIPO_9, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_9);

            /*" -1958- MOVE W-QTD-LD-TIPO-A TO RT-QTDE-TIPO-A OF REG-TRAILLER. */
            _.Move(W_QTD_LD_TIPO_A, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_A);

            /*" -1961- MOVE W-QTD-LD-TIPO-B TO RT-QTDE-TIPO-B OF REG-TRAILLER. */
            _.Move(W_QTD_LD_TIPO_B, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_B);

            /*" -1964- MOVE W-QTD-LD-TIPO-C TO RT-QTDE-TIPO-C OF REG-TRAILLER. */
            _.Move(W_QTD_LD_TIPO_C, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_C);

            /*" -1967- MOVE W-QTD-LD-TIPO-D TO RT-QTDE-TIPO-D OF REG-TRAILLER. */
            _.Move(W_QTD_LD_TIPO_D, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_D);

            /*" -1970- MOVE W-QTD-LD-TIPO-E TO RT-QTDE-TIPO-E OF REG-TRAILLER. */
            _.Move(W_QTD_LD_TIPO_E, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_E);

            /*" -1973- MOVE W-QTD-LD-TIPO-F TO RT-QTDE-TIPO-F OF REG-TRAILLER. */
            _.Move(W_QTD_LD_TIPO_F, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_F);

            /*" -1976- MOVE W-QTD-LD-TIPO-G TO RT-QTDE-TIPO-G OF REG-TRAILLER. */
            _.Move(W_QTD_LD_TIPO_G, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_G);

            /*" -1979- MOVE W-QTD-LD-TIPO-H TO RT-QTDE-TIPO-H OF REG-TRAILLER. */
            _.Move(W_QTD_LD_TIPO_H, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_H);

            /*" -1982- MOVE W-QTD-LD-TIPO-I TO RT-QTDE-TIPO-I OF REG-TRAILLER. */
            _.Move(W_QTD_LD_TIPO_I, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_I);

            /*" -1985- MOVE W-QTD-LD-TIPO-J TO RT-QTDE-TIPO-J OF REG-TRAILLER. */
            _.Move(W_QTD_LD_TIPO_J, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_J);

            /*" -2007- COMPUTE RT-QTDE-TOTAL OF REG-TRAILLER EQUAL RT-QTDE-TIPO-0 OF REG-TRAILLER + RT-QTDE-TIPO-1 OF REG-TRAILLER + RT-QTDE-TIPO-2 OF REG-TRAILLER + RT-QTDE-TIPO-3 OF REG-TRAILLER + RT-QTDE-TIPO-4 OF REG-TRAILLER + RT-QTDE-TIPO-5 OF REG-TRAILLER + RT-QTDE-TIPO-6 OF REG-TRAILLER + RT-QTDE-TIPO-7 OF REG-TRAILLER + RT-QTDE-TIPO-8 OF REG-TRAILLER + RT-QTDE-TIPO-9 OF REG-TRAILLER + RT-QTDE-TIPO-A OF REG-TRAILLER + RT-QTDE-TIPO-B OF REG-TRAILLER + RT-QTDE-TIPO-C OF REG-TRAILLER + RT-QTDE-TIPO-D OF REG-TRAILLER + RT-QTDE-TIPO-E OF REG-TRAILLER + RT-QTDE-TIPO-F OF REG-TRAILLER + RT-QTDE-TIPO-G OF REG-TRAILLER + RT-QTDE-TIPO-H OF REG-TRAILLER + RT-QTDE-TIPO-I OF REG-TRAILLER + RT-QTDE-TIPO-J OF REG-TRAILLER. */
            LBFPF991.REG_TRAILLER.RT_QTDE_TOTAL.Value = LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_0 + LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_1 + LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_2 + LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_3 + LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_4 + LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_5 + LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_6 + LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_7 + LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_8 + LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_9 + LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_A + LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_B + LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_C + LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_D + LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_E + LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_F + LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_G + LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_H + LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_I + LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_J;

            /*" -2007- WRITE REG-PRP-SASSE FROM REG-TRAILLER. */
            _.Move(LBFPF991.REG_TRAILLER.GetMoveValues(), REG_PRP_SASSE);

            MOVTO_PRP_SASSE.Write(REG_PRP_SASSE.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_SAIDA*/

        [StopWatch]
        /*" R1100-00-GERAR-TOTAIS-SECTION */
        private void R1100_00_GERAR_TOTAIS_SECTION()
        {
            /*" -2035- COMPUTE W-TOT-GERADO-PRP = W-QTD-LD-TIPO-1 + W-QTD-LD-TIPO-2 + W-QTD-LD-TIPO-3 + W-QTD-LD-TIPO-4 + W-QTD-LD-TIPO-5 + W-QTD-LD-TIPO-6 + W-QTD-LD-TIPO-7 + W-QTD-LD-TIPO-8 + W-QTD-LD-TIPO-9 + W-QTD-LD-TIPO-A + W-QTD-LD-TIPO-B + W-QTD-LD-TIPO-C + W-QTD-LD-TIPO-D + W-QTD-LD-TIPO-E + W-QTD-LD-TIPO-F + W-QTD-LD-TIPO-G + W-QTD-LD-TIPO-H + W-QTD-LD-TIPO-I + W-QTD-LD-TIPO-J. */
            W_TOT_GERADO_PRP.Value = W_QTD_LD_TIPO_1 + W_QTD_LD_TIPO_2 + W_QTD_LD_TIPO_3 + W_QTD_LD_TIPO_4 + W_QTD_LD_TIPO_5 + W_QTD_LD_TIPO_6 + W_QTD_LD_TIPO_7 + W_QTD_LD_TIPO_8 + W_QTD_LD_TIPO_9 + W_QTD_LD_TIPO_A + W_QTD_LD_TIPO_B + W_QTD_LD_TIPO_C + W_QTD_LD_TIPO_D + W_QTD_LD_TIPO_E + W_QTD_LD_TIPO_F + W_QTD_LD_TIPO_G + W_QTD_LD_TIPO_H + W_QTD_LD_TIPO_I + W_QTD_LD_TIPO_J;

            /*" -2036- DISPLAY ' ' . */
            _.Display($" ");

            /*" -2037- DISPLAY 'VA0126B - TOTAIS DO PROCESSAMENTO' . */
            _.Display($"VA0126B - TOTAIS DO PROCESSAMENTO");

            /*" -2039- DISPLAY '          DATA ULT VA0126B................. ' W-DATA-ULT-VA0126B */
            _.Display($"          DATA ULT VA0126B................. {W_DATA_ULT_VA0126B}");

            /*" -2041- DISPLAY '          DATA MOV ABERTO.................. ' SISTEMAS-DATA-MOV-ABERTO */
            _.Display($"          DATA MOV ABERTO.................. {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}");

            /*" -2043- DISPLAY '          TOTAL CERTIFICADOS LIDOS......... ' W-LIDOS. */
            _.Display($"          TOTAL CERTIFICADOS LIDOS......... {W_LIDOS}");

            /*" -2045- DISPLAY '          TOTAL CERTIFICADOS ORIGEM 12..... ' W-ORIGEM-12. */
            _.Display($"          TOTAL CERTIFICADOS ORIGEM 12..... {W_ORIGEM_12}");

            /*" -2047- DISPLAY '          TOTAL CERTIFICADOS CANCELADOS.... ' W-CANCELADO. */
            _.Display($"          TOTAL CERTIFICADOS CANCELADOS.... {W_CANCELADO}");

            /*" -2049- DISPLAY '          TOTAL CERTIFICADOS NAO MIGRADOS.. ' W-NAO-MIGRADO */
            _.Display($"          TOTAL CERTIFICADOS NAO MIGRADOS.. {W_NAO_MIGRADO}");

            /*" -2052- DISPLAY '          TOTAL CERTIFICADOS DESPREZADOS... ' W-DESPREZADO. */
            _.Display($"          TOTAL CERTIFICADOS DESPREZADOS... {W_DESPREZADO}");

            /*" -2058- COMPUTE W-PROCESSADO = W-LIDOS - W-CANCELADO - W-NAO-MIGRADO - W-ORIGEM-12 - W-DESPREZADO. */
            W_PROCESSADO.Value = W_LIDOS - W_CANCELADO - W_NAO_MIGRADO - W_ORIGEM_12 - W_DESPREZADO;

            /*" -2060- DISPLAY '          TOTAL CERTIFICADOS PROCESSADOS....' W-PROCESSADO. */
            _.Display($"          TOTAL CERTIFICADOS PROCESSADOS....{W_PROCESSADO}");

            /*" -2061- DISPLAY '          TOTAL REGISTROS ARQUIVO PROPOSTA. ' RT-QTDE-TOTAL OF REG-TRAILLER. */
            _.Display($"          TOTAL REGISTROS ARQUIVO PROPOSTA. {LBFPF991.REG_TRAILLER.RT_QTDE_TOTAL}");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_SAIDA*/

        [StopWatch]
        /*" R1200-00-GRAVA-RELATORIO-SECTION */
        private void R1200_00_GRAVA_RELATORIO_SECTION()
        {
            /*" -2072- IF W-DATA-ULT-VA0126B EQUAL '0001-01-01' */

            if (W_DATA_ULT_VA0126B == "0001-01-01")
            {

                /*" -2073- PERFORM R1300-00-INSERT-RELATORIO */

                R1300_00_INSERT_RELATORIO_SECTION();

                /*" -2074- ELSE */
            }
            else
            {


                /*" -2075- PERFORM R1350-00-UPDATE-RELATORIO */

                R1350_00_UPDATE_RELATORIO_SECTION();

                /*" -2075- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_SAIDA*/

        [StopWatch]
        /*" R1300-00-INSERT-RELATORIO-SECTION */
        private void R1300_00_INSERT_RELATORIO_SECTION()
        {
            /*" -2084- MOVE 'R1300-00-INSERT-RELATORIO' TO PARAGRAFO. */
            _.Move("R1300-00-INSERT-RELATORIO", WABEND2.PARAGRAFO);

            /*" -2086- MOVE 'INSERT RELATORIO' TO COMANDO. */
            _.Move("INSERT RELATORIO", WABEND2.COMANDO);

            /*" -2087- INITIALIZE DCLRELATORIOS */
            _.Initialize(
                RELATORI.DCLRELATORIOS
            );

            /*" -2088- MOVE 'VA0126B' TO RELATORI-COD-USUARIO. */
            _.Move("VA0126B", RELATORI.DCLRELATORIOS.RELATORI_COD_USUARIO);

            /*" -2092- MOVE SISTEMAS-DATA-MOV-ABERTO TO RELATORI-DATA-SOLICITACAO RELATORI-DATA-REFERENCIA RELATORI-PERI-INICIAL RELATORI-PERI-FINAL */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, RELATORI.DCLRELATORIOS.RELATORI_DATA_SOLICITACAO, RELATORI.DCLRELATORIOS.RELATORI_DATA_REFERENCIA, RELATORI.DCLRELATORIOS.RELATORI_PERI_INICIAL, RELATORI.DCLRELATORIOS.RELATORI_PERI_FINAL);

            /*" -2093- MOVE 'VA' TO RELATORI-IDE-SISTEMA. */
            _.Move("VA", RELATORI.DCLRELATORIOS.RELATORI_IDE_SISTEMA);

            /*" -2094- MOVE 'VA0126B' TO RELATORI-COD-RELATORIO. */
            _.Move("VA0126B", RELATORI.DCLRELATORIOS.RELATORI_COD_RELATORIO);

            /*" -2095- MOVE 0 TO RELATORI-NUM-COPIAS */
            _.Move(0, RELATORI.DCLRELATORIOS.RELATORI_NUM_COPIAS);

            /*" -2097- MOVE '1' TO RELATORI-SIT-REGISTRO. */
            _.Move("1", RELATORI.DCLRELATORIOS.RELATORI_SIT_REGISTRO);

            /*" -2185- PERFORM R1300_00_INSERT_RELATORIO_DB_INSERT_1 */

            R1300_00_INSERT_RELATORIO_DB_INSERT_1();

            /*" -2188- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2189- DISPLAY 'VA0126B - ERRO INSERT RELATORIOS' */
                _.Display($"VA0126B - ERRO INSERT RELATORIOS");

                /*" -2190- PERFORM R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION();

                /*" -2190- END-IF. */
            }


        }

        [StopWatch]
        /*" R1300-00-INSERT-RELATORIO-DB-INSERT-1 */
        public void R1300_00_INSERT_RELATORIO_DB_INSERT_1()
        {
            /*" -2185- EXEC SQL INSERT INTO SEGUROS.RELATORIOS ( COD_USUARIO , DATA_SOLICITACAO , IDE_SISTEMA , COD_RELATORIO , NUM_COPIAS , QUANTIDADE , PERI_INICIAL , PERI_FINAL , DATA_REFERENCIA , MES_REFERENCIA , ANO_REFERENCIA , ORGAO_EMISSOR , COD_FONTE , COD_PRODUTOR , RAMO_EMISSOR , COD_MODALIDADE , COD_CONGENERE , NUM_APOLICE , NUM_ENDOSSO , NUM_PARCELA , NUM_CERTIFICADO , NUM_TITULO , COD_SUBGRUPO , COD_OPERACAO , COD_PLANO , OCORR_HISTORICO , NUM_APOL_LIDER , ENDOS_LIDER , NUM_PARC_LIDER , NUM_SINISTRO , NUM_SINI_LIDER , NUM_ORDEM , COD_MOEDA , TIPO_CORRECAO , SIT_REGISTRO , IND_PREV_DEFINIT , IND_ANAL_RESUMO , COD_EMPRESA , PERI_RENOVACAO , PCT_AUMENTO , TIMESTAMP ) VALUES ( :RELATORI-COD-USUARIO ,:RELATORI-DATA-SOLICITACAO ,:RELATORI-IDE-SISTEMA ,:RELATORI-COD-RELATORIO ,:RELATORI-NUM-COPIAS ,:RELATORI-QUANTIDADE ,:RELATORI-PERI-INICIAL ,:RELATORI-PERI-FINAL ,:RELATORI-DATA-REFERENCIA ,:RELATORI-MES-REFERENCIA ,:RELATORI-ANO-REFERENCIA ,:RELATORI-ORGAO-EMISSOR ,:RELATORI-COD-FONTE ,:RELATORI-COD-PRODUTOR ,:RELATORI-RAMO-EMISSOR ,:RELATORI-COD-MODALIDADE ,:RELATORI-COD-CONGENERE ,:RELATORI-NUM-APOLICE ,:RELATORI-NUM-ENDOSSO ,:RELATORI-NUM-PARCELA ,:RELATORI-NUM-CERTIFICADO ,:RELATORI-NUM-TITULO ,:RELATORI-COD-SUBGRUPO ,:RELATORI-COD-OPERACAO ,:RELATORI-COD-PLANO ,:RELATORI-OCORR-HISTORICO ,:RELATORI-NUM-APOL-LIDER ,:RELATORI-ENDOS-LIDER ,:RELATORI-NUM-PARC-LIDER ,:RELATORI-NUM-SINISTRO ,:RELATORI-NUM-SINI-LIDER ,:RELATORI-NUM-ORDEM ,:RELATORI-COD-MOEDA ,:RELATORI-TIPO-CORRECAO ,:RELATORI-SIT-REGISTRO ,:RELATORI-IND-PREV-DEFINIT ,:RELATORI-IND-ANAL-RESUMO ,:RELATORI-COD-EMPRESA ,:RELATORI-PERI-RENOVACAO ,:RELATORI-PCT-AUMENTO , CURRENT TIMESTAMP ) END-EXEC. */

            var r1300_00_INSERT_RELATORIO_DB_INSERT_1_Insert1 = new R1300_00_INSERT_RELATORIO_DB_INSERT_1_Insert1()
            {
                RELATORI_COD_USUARIO = RELATORI.DCLRELATORIOS.RELATORI_COD_USUARIO.ToString(),
                RELATORI_DATA_SOLICITACAO = RELATORI.DCLRELATORIOS.RELATORI_DATA_SOLICITACAO.ToString(),
                RELATORI_IDE_SISTEMA = RELATORI.DCLRELATORIOS.RELATORI_IDE_SISTEMA.ToString(),
                RELATORI_COD_RELATORIO = RELATORI.DCLRELATORIOS.RELATORI_COD_RELATORIO.ToString(),
                RELATORI_NUM_COPIAS = RELATORI.DCLRELATORIOS.RELATORI_NUM_COPIAS.ToString(),
                RELATORI_QUANTIDADE = RELATORI.DCLRELATORIOS.RELATORI_QUANTIDADE.ToString(),
                RELATORI_PERI_INICIAL = RELATORI.DCLRELATORIOS.RELATORI_PERI_INICIAL.ToString(),
                RELATORI_PERI_FINAL = RELATORI.DCLRELATORIOS.RELATORI_PERI_FINAL.ToString(),
                RELATORI_DATA_REFERENCIA = RELATORI.DCLRELATORIOS.RELATORI_DATA_REFERENCIA.ToString(),
                RELATORI_MES_REFERENCIA = RELATORI.DCLRELATORIOS.RELATORI_MES_REFERENCIA.ToString(),
                RELATORI_ANO_REFERENCIA = RELATORI.DCLRELATORIOS.RELATORI_ANO_REFERENCIA.ToString(),
                RELATORI_ORGAO_EMISSOR = RELATORI.DCLRELATORIOS.RELATORI_ORGAO_EMISSOR.ToString(),
                RELATORI_COD_FONTE = RELATORI.DCLRELATORIOS.RELATORI_COD_FONTE.ToString(),
                RELATORI_COD_PRODUTOR = RELATORI.DCLRELATORIOS.RELATORI_COD_PRODUTOR.ToString(),
                RELATORI_RAMO_EMISSOR = RELATORI.DCLRELATORIOS.RELATORI_RAMO_EMISSOR.ToString(),
                RELATORI_COD_MODALIDADE = RELATORI.DCLRELATORIOS.RELATORI_COD_MODALIDADE.ToString(),
                RELATORI_COD_CONGENERE = RELATORI.DCLRELATORIOS.RELATORI_COD_CONGENERE.ToString(),
                RELATORI_NUM_APOLICE = RELATORI.DCLRELATORIOS.RELATORI_NUM_APOLICE.ToString(),
                RELATORI_NUM_ENDOSSO = RELATORI.DCLRELATORIOS.RELATORI_NUM_ENDOSSO.ToString(),
                RELATORI_NUM_PARCELA = RELATORI.DCLRELATORIOS.RELATORI_NUM_PARCELA.ToString(),
                RELATORI_NUM_CERTIFICADO = RELATORI.DCLRELATORIOS.RELATORI_NUM_CERTIFICADO.ToString(),
                RELATORI_NUM_TITULO = RELATORI.DCLRELATORIOS.RELATORI_NUM_TITULO.ToString(),
                RELATORI_COD_SUBGRUPO = RELATORI.DCLRELATORIOS.RELATORI_COD_SUBGRUPO.ToString(),
                RELATORI_COD_OPERACAO = RELATORI.DCLRELATORIOS.RELATORI_COD_OPERACAO.ToString(),
                RELATORI_COD_PLANO = RELATORI.DCLRELATORIOS.RELATORI_COD_PLANO.ToString(),
                RELATORI_OCORR_HISTORICO = RELATORI.DCLRELATORIOS.RELATORI_OCORR_HISTORICO.ToString(),
                RELATORI_NUM_APOL_LIDER = RELATORI.DCLRELATORIOS.RELATORI_NUM_APOL_LIDER.ToString(),
                RELATORI_ENDOS_LIDER = RELATORI.DCLRELATORIOS.RELATORI_ENDOS_LIDER.ToString(),
                RELATORI_NUM_PARC_LIDER = RELATORI.DCLRELATORIOS.RELATORI_NUM_PARC_LIDER.ToString(),
                RELATORI_NUM_SINISTRO = RELATORI.DCLRELATORIOS.RELATORI_NUM_SINISTRO.ToString(),
                RELATORI_NUM_SINI_LIDER = RELATORI.DCLRELATORIOS.RELATORI_NUM_SINI_LIDER.ToString(),
                RELATORI_NUM_ORDEM = RELATORI.DCLRELATORIOS.RELATORI_NUM_ORDEM.ToString(),
                RELATORI_COD_MOEDA = RELATORI.DCLRELATORIOS.RELATORI_COD_MOEDA.ToString(),
                RELATORI_TIPO_CORRECAO = RELATORI.DCLRELATORIOS.RELATORI_TIPO_CORRECAO.ToString(),
                RELATORI_SIT_REGISTRO = RELATORI.DCLRELATORIOS.RELATORI_SIT_REGISTRO.ToString(),
                RELATORI_IND_PREV_DEFINIT = RELATORI.DCLRELATORIOS.RELATORI_IND_PREV_DEFINIT.ToString(),
                RELATORI_IND_ANAL_RESUMO = RELATORI.DCLRELATORIOS.RELATORI_IND_ANAL_RESUMO.ToString(),
                RELATORI_COD_EMPRESA = RELATORI.DCLRELATORIOS.RELATORI_COD_EMPRESA.ToString(),
                RELATORI_PERI_RENOVACAO = RELATORI.DCLRELATORIOS.RELATORI_PERI_RENOVACAO.ToString(),
                RELATORI_PCT_AUMENTO = RELATORI.DCLRELATORIOS.RELATORI_PCT_AUMENTO.ToString(),
            };

            R1300_00_INSERT_RELATORIO_DB_INSERT_1_Insert1.Execute(r1300_00_INSERT_RELATORIO_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1300_SAIDA*/

        [StopWatch]
        /*" R1350-00-UPDATE-RELATORIO-SECTION */
        private void R1350_00_UPDATE_RELATORIO_SECTION()
        {
            /*" -2199- MOVE 'R1350-00-UPDATE-RELATORIO' TO PARAGRAFO. */
            _.Move("R1350-00-UPDATE-RELATORIO", WABEND2.PARAGRAFO);

            /*" -2201- MOVE 'UPDATE RELATORIO' TO COMANDO. */
            _.Move("UPDATE RELATORIO", WABEND2.COMANDO);

            /*" -2203- PERFORM R0010-00-BUSCA-ULT-VA0126B */

            R0010_00_BUSCA_ULT_VA0126B_SECTION();

            /*" -2209- PERFORM R1350_00_UPDATE_RELATORIO_DB_UPDATE_1 */

            R1350_00_UPDATE_RELATORIO_DB_UPDATE_1();

            /*" -2212- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2213- DISPLAY 'VA0126B - ERRO UPDATE RELATORIOS' */
                _.Display($"VA0126B - ERRO UPDATE RELATORIOS");

                /*" -2214- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -2215- PERFORM R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION();

                /*" -2215- END-IF. */
            }


        }

        [StopWatch]
        /*" R1350-00-UPDATE-RELATORIO-DB-UPDATE-1 */
        public void R1350_00_UPDATE_RELATORIO_DB_UPDATE_1()
        {
            /*" -2209- EXEC SQL UPDATE SEGUROS.RELATORIOS SET DATA_SOLICITACAO = :SISTEMAS-DATA-MOV-ABERTO ,TIMESTAMP = CURRENT TIMESTAMP WHERE COD_USUARIO = :RELATORI-COD-USUARIO AND IDE_SISTEMA = :RELATORI-IDE-SISTEMA END-EXEC. */

            var r1350_00_UPDATE_RELATORIO_DB_UPDATE_1_Update1 = new R1350_00_UPDATE_RELATORIO_DB_UPDATE_1_Update1()
            {
                SISTEMAS_DATA_MOV_ABERTO = SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.ToString(),
                RELATORI_COD_USUARIO = RELATORI.DCLRELATORIOS.RELATORI_COD_USUARIO.ToString(),
                RELATORI_IDE_SISTEMA = RELATORI.DCLRELATORIOS.RELATORI_IDE_SISTEMA.ToString(),
            };

            R1350_00_UPDATE_RELATORIO_DB_UPDATE_1_Update1.Execute(r1350_00_UPDATE_RELATORIO_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1350_SAIDA*/

        [StopWatch]
        /*" R6000-00-DECLARE-AGENCEF-SECTION */
        private void R6000_00_DECLARE_AGENCEF_SECTION()
        {
            /*" -2224- MOVE 'R6000-DECLA-AGENCEF' TO PARAGRAFO. */
            _.Move("R6000-DECLA-AGENCEF", WABEND2.PARAGRAFO);

            /*" -2226- MOVE 'DECLARE AGENCIACEF ' TO COMANDO. */
            _.Move("DECLARE AGENCIACEF ", WABEND2.COMANDO);

            /*" -2236- PERFORM R6000_00_DECLARE_AGENCEF_DB_DECLARE_1 */

            R6000_00_DECLARE_AGENCEF_DB_DECLARE_1();

            /*" -2239- MOVE 'OPEN AGENCIACEF ' TO COMANDO. */
            _.Move("OPEN AGENCIACEF ", WABEND2.COMANDO);

            /*" -2239- PERFORM R6000_00_DECLARE_AGENCEF_DB_OPEN_1 */

            R6000_00_DECLARE_AGENCEF_DB_OPEN_1();

            /*" -2242- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2243- DISPLAY 'VA0126B - ERRO OPEN CURSOR AGENCEF' */
                _.Display($"VA0126B - ERRO OPEN CURSOR AGENCEF");

                /*" -2244- MOVE 'OPEN CURSOR AGENCEF' TO COMANDO */
                _.Move("OPEN CURSOR AGENCEF", WABEND2.COMANDO);

                /*" -2244- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R6000-00-DECLARE-AGENCEF-DB-OPEN-1 */
        public void R6000_00_DECLARE_AGENCEF_DB_OPEN_1()
        {
            /*" -2239- EXEC SQL OPEN C01_AGENCEF END-EXEC. */

            C01_AGENCEF.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R6000_SAIDA*/

        [StopWatch]
        /*" R6010-00-FETCH-AGENCEF-SECTION */
        private void R6010_00_FETCH_AGENCEF_SECTION()
        {
            /*" -2253- MOVE 'R6010-FETCH-AGENCEF' TO PARAGRAFO. */
            _.Move("R6010-FETCH-AGENCEF", WABEND2.PARAGRAFO);

            /*" -2255- MOVE 'FETCH   AGENCIACEF ' TO COMANDO. */
            _.Move("FETCH   AGENCIACEF ", WABEND2.COMANDO);

            /*" -2259- PERFORM R6010_00_FETCH_AGENCEF_DB_FETCH_1 */

            R6010_00_FETCH_AGENCEF_DB_FETCH_1();

            /*" -2262- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2263- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2264- MOVE 'S' TO WFIM-AGENCEF */
                    _.Move("S", WFIM_AGENCEF);

                    /*" -2264- PERFORM R6010_00_FETCH_AGENCEF_DB_CLOSE_1 */

                    R6010_00_FETCH_AGENCEF_DB_CLOSE_1();

                    /*" -2266- ELSE */
                }
                else
                {


                    /*" -2267- DISPLAY 'VA0126B - ERRO FETCH AGENCEF' */
                    _.Display($"VA0126B - ERRO FETCH AGENCEF");

                    /*" -2268- PERFORM R9999-00-FINALIZAR */

                    R9999_00_FINALIZAR_SECTION();

                    /*" -2269- END-IF */
                }


                /*" -2269- END-IF. */
            }


        }

        [StopWatch]
        /*" R6010-00-FETCH-AGENCEF-DB-FETCH-1 */
        public void R6010_00_FETCH_AGENCEF_DB_FETCH_1()
        {
            /*" -2259- EXEC SQL FETCH C01_AGENCEF INTO :DCLAGENCIAS-CEF.COD-AGENCIA ,:DCLMALHA-CEF.MALHACEF-COD-FONTE END-EXEC. */

            if (C01_AGENCEF.Fetch())
            {
                _.Move(C01_AGENCEF.DCLAGENCIAS_CEF_COD_AGENCIA, AGENCEF.DCLAGENCIAS_CEF.COD_AGENCIA);
                _.Move(C01_AGENCEF.DCLMALHA_CEF_MALHACEF_COD_FONTE, MALHACEF.DCLMALHA_CEF.MALHACEF_COD_FONTE);
            }

        }

        [StopWatch]
        /*" R6010-00-FETCH-AGENCEF-DB-CLOSE-1 */
        public void R6010_00_FETCH_AGENCEF_DB_CLOSE_1()
        {
            /*" -2264- EXEC SQL CLOSE C01_AGENCEF END-EXEC */

            C01_AGENCEF.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R6010_SAIDA*/

        [StopWatch]
        /*" R6020-00-CARREGA-FILIAL-SECTION */
        private void R6020_00_CARREGA_FILIAL_SECTION()
        {
            /*" -2280- MOVE COD-AGENCIA OF DCLAGENCIAS-CEF TO TAB-AGENCIA (COD-AGENCIA OF DCLAGENCIAS-CEF) */
            _.Move(AGENCEF.DCLAGENCIAS_CEF.COD_AGENCIA, TAB_FILIAIS.FILLER_0[AGENCEF.DCLAGENCIAS_CEF.COD_AGENCIA].TAB_AGENCIA);

            /*" -2283- MOVE MALHACEF-COD-FONTE OF DCLMALHA-CEF TO TAB-FONTE (COD-AGENCIA OF DCLAGENCIAS-CEF) */
            _.Move(MALHACEF.DCLMALHA_CEF.MALHACEF_COD_FONTE, TAB_FILIAIS.FILLER_0[AGENCEF.DCLAGENCIAS_CEF.COD_AGENCIA].TAB_FONTE);

            /*" -2283- PERFORM R6010-00-FETCH-AGENCEF. */

            R6010_00_FETCH_AGENCEF_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R6020_SAIDA*/

        [StopWatch]
        /*" R9988-00-FECHAR-ARQUIVOS-SECTION */
        private void R9988_00_FECHAR_ARQUIVOS_SECTION()
        {
            /*" -2291- CLOSE MOVTO-PRP-SASSE. */
            MOVTO_PRP_SASSE.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9988_SAIDA*/

        [StopWatch]
        /*" R9999-00-FINALIZAR-SECTION */
        private void R9999_00_FINALIZAR_SECTION()
        {
            /*" -2300- IF W-FIM-MOVIMENTO EQUAL 'FIM' */

            if (W_FIM_MOVIMENTO == "FIM")
            {

                /*" -2301- DISPLAY 'VA0126B - FIM NORMAL' */
                _.Display($"VA0126B - FIM NORMAL");

                /*" -2302- MOVE 0 TO RETURN-CODE */
                _.Move(0, RETURN_CODE);

                /*" -2302- EXEC SQL COMMIT WORK END-EXEC */

                DatabaseConnection.Instance.CommitTransaction();

                /*" -2304- ELSE */
            }
            else
            {


                /*" -2305- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, WABEND1.WSQLCODE);

                /*" -2306- MOVE SQLERRD(1) TO WSQLERRD1 */
                _.Move(DB.SQLERRD[1], WABEND1.WSQLERRD1);

                /*" -2307- MOVE SQLERRD(2) TO WSQLERRD2 */
                _.Move(DB.SQLERRD[2], WABEND1.WSQLERRD2);

                /*" -2308- DISPLAY WABEND1 */
                _.Display(WABEND1);

                /*" -2309- DISPLAY WABEND2 */
                _.Display(WABEND2);

                /*" -2310- DISPLAY 'VA0126B - ROLLBACK EM ANDAMENTO' */
                _.Display($"VA0126B - ROLLBACK EM ANDAMENTO");

                /*" -2310- EXEC SQL ROLLBACK WORK END-EXEC */

                DatabaseConnection.Instance.RollbackTransaction();

                /*" -2312- DISPLAY ' ' */
                _.Display($" ");

                /*" -2313- MOVE 99 TO RETURN-CODE */
                _.Move(99, RETURN_CODE);

                /*" -2315- END-IF. */
            }


            /*" -2323- DISPLAY 'VA0126B - TERMINO EM ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2). */

            $"VA0126B - TERMINO EM {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
            .Display();

            /*" -2323- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9999_SAIDA*/
    }
}