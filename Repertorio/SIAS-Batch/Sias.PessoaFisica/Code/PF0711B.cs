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
using Sias.PessoaFisica.DB2.PF0711B;

namespace Code
{
    public class PF0711B
    {
        public bool IsCall { get; set; }

        public PF0711B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *-----------------------*                                               */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   FUNCAO .................  GERA STATUS DAS PROPOSTAS DE MULTI-*      */
        /*"      *                             RISCO RESIDENCIAL.                 *      */
        /*"      *   ANALISE/PROGRAMACAO.....  LUIZ CARLOS.                       *      */
        /*"      *   PROGRAMA ...............  PF0711B                            *      */
        /*"      *   DATA PROMOCAO...........  14/01/2004.                        *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 09             AJUSTE NO INSERT HIST_PROP_FIDELIZ       *      */
        /*"      * ATENDE CADMUS 93192                                            *      */
        /*"      *                                                                *      */
        /*"      * PROCURE IHP           REGINALDO SILVA                          *      */
        /*"      *                       24/01/2014                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 08             AJUSTE INSERT HIST_PROP_FIDELIZ          *      */
        /*"      * ATENDE CADMUS 88764   COD-EMPRESA    E   COD-PRODUTO           *      */
        /*"      *                                                                *      */
        /*"      * PROCURE IHP           REGINALDO SILVA                          *      */
        /*"      *                       11/11/2013                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   V.01                                                         *      */
        /*"      *   DATA DA VERSAO .........  XX/XX/XXXX.     PROCURE POR V.01   *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 02                         SANDRA SALES- STEFANINI    *      */
        /*"      *   DATA ...:  02/12/2005 - PROCURE POR V.02                     *      */
        /*"      *                                                                *      */
        /*"      *   CRIAR NOVO ARQUIVO DE SAIDA COM O MESMO LAYOUT:              *      */
        /*"      *     - NO ARQCEF INCLUIR O DIGITO '0' NO ULTIMA POSICAO DO NUM. *      */
        /*"      *       DA PROPOSTA PARA A FAIXA 101400000000  E  101499999999   *      */
        /*"      *     - NO ARQFNAE MANTER O NUMERO DA PROPOSTA CONFORME ARQUIVO  *      */
        /*"      *       DE ENTRADA                                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 03                         LUCIA VIEIRA - STEFANINI   *      */
        /*"      *   DATA ...:  06/06/2006 - PROCURE POR V.03                     *      */
        /*"      *                                                                *      */
        /*"      *   CORRIGE ABEND 4038 - INCLUI COMANDO FILE STATUS PARA ARQUI-  *      */
        /*"      *                        VO  SEQUENCIAL  DE ENTRADA.             *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   V.04 ADEQUADO PARA TRATAR REGISTRO TIPO 8 - BLOCO 33 - SIDEM *      */
        /*"      *                                                                *      */
        /*"      *   DATA DA VERSAO .........  30/01/2007.     PROCURE POR V.04   *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   V.05 ADEQUADO PARA GERAR TODOS OS  TIPO 8 - BLOCO 33 - SIDEM *      */
        /*"      *        QDO INFORMADO MAIS DE UMA PARCELA.                      *      */
        /*"      *                                                                *      */
        /*"      *        PRIMEIRA EXECUCAO EM 21/02/2008                         *      */
        /*"      *                                                                *      */
        /*"      *   DATA DA VERSAO .........  21/02/2008.     PROCURE POR V.05   *      */
        /*"      *                                                                *      */
        /*"      *   LUCIA VIEIRA                                                 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   V.06 PASSA A ZERAR CONT-SIDEM QDO  SITUACAO JA ESTIVER GRAVA-*      */
        /*"      *        DA NA  TAB  HIST-PROP-FIDELIZ EVITANDO ASSIM O REENVIO  *      */
        /*"      *                                                                *      */
        /*"      *   DATA DA VERSAO .........  14/07/2008.     PROCURE POR V.06   *      */
        /*"      *                                                                *      */
        /*"      *   LUCIA VIEIRA                                                 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   V.07   CORRIGIR PROGRAMA PARA GERAR A MESMA QUANTIDADE DE    *      */
        /*"      *          REGISTROS TIPO 8 DO ARQUIVO DE ENTRADA NO DE SAIDA.   *      */
        /*"      *                                                                *      */
        /*"      *   DATA DA VERSAO .........  23/09/2009.     PROCURE POR V.07   *      */
        /*"      *                                                                *      */
        /*"      *   SERGIO LORETO                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"1     *--------------------*                                                  */
        #endregion


        #region VARIABLES

        public FileBasis _MOV_STA_MR { get; set; } = new FileBasis(new PIC("X", "100", "X(100)"));

        public FileBasis MOV_STA_MR
        {
            get
            {
                _.Move(REG_STA_MR, _MOV_STA_MR); VarBasis.RedefinePassValue(REG_STA_MR, _MOV_STA_MR, REG_STA_MR); return _MOV_STA_MR;
            }
        }
        public FileBasis _MOV_STA_CEF { get; set; } = new FileBasis(new PIC("X", "100", "X(100)"));

        public FileBasis MOV_STA_CEF
        {
            get
            {
                _.Move(REG_STA_CEF, _MOV_STA_CEF); VarBasis.RedefinePassValue(REG_STA_CEF, _MOV_STA_CEF, REG_STA_CEF); return _MOV_STA_CEF;
            }
        }
        public FileBasis _MOV_STA_FNAE { get; set; } = new FileBasis(new PIC("X", "100", "X(100)"));

        public FileBasis MOV_STA_FNAE
        {
            get
            {
                _.Move(REG_STA_FNAE, _MOV_STA_FNAE); VarBasis.RedefinePassValue(REG_STA_FNAE, _MOV_STA_FNAE, REG_STA_FNAE); return _MOV_STA_FNAE;
            }
        }
        public FileBasis _RPF0711B { get; set; } = new FileBasis(new PIC("X", "132", "X(132)"));

        public FileBasis RPF0711B
        {
            get
            {
                _.Move(REG_RPF0711B, _RPF0711B); VarBasis.RedefinePassValue(REG_RPF0711B, _RPF0711B, REG_RPF0711B); return _RPF0711B;
            }
        }
        /*"01   REG-STA-MR.*/
        public PF0711B_REG_STA_MR REG_STA_MR { get; set; } = new PF0711B_REG_STA_MR();
        public class PF0711B_REG_STA_MR : VarBasis
        {
            /*"     10  REG-TIPO-REGISTRO               PIC X(001).*/
            public StringBasis REG_TIPO_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"     10  FILLER REDEFINES REG-TIPO-REGISTRO.*/
            private _REDEF_PF0711B_FILLER_0 _filler_0 { get; set; }
            public _REDEF_PF0711B_FILLER_0 FILLER_0
            {
                get { _filler_0 = new _REDEF_PF0711B_FILLER_0(); _.Move(REG_TIPO_REGISTRO, _filler_0); VarBasis.RedefinePassValue(REG_TIPO_REGISTRO, _filler_0, REG_TIPO_REGISTRO); _filler_0.ValueChanged += () => { _.Move(_filler_0, REG_TIPO_REGISTRO); }; return _filler_0; }
                set { VarBasis.RedefinePassValue(value, _filler_0, REG_TIPO_REGISTRO); }
            }  //Redefines
            public class _REDEF_PF0711B_FILLER_0 : VarBasis
            {
                /*"        15  REG-TIPO-REGISTRO-R             PIC 9(001).*/
                public IntBasis REG_TIPO_REGISTRO_R { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"     10  REG-NUM-PROPOSTA                PIC X(014).*/

                public _REDEF_PF0711B_FILLER_0()
                {
                    REG_TIPO_REGISTRO_R.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis REG_NUM_PROPOSTA { get; set; } = new StringBasis(new PIC("X", "14", "X(014)."), @"");
            /*"     10  FILLER                          PIC X(085).*/
            public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "85", "X(085)."), @"");
            /*"01   REG-STA-CEF                        PIC X(100).*/
        }
        public StringBasis REG_STA_CEF { get; set; } = new StringBasis(new PIC("X", "100", "X(100)."), @"");
        /*"01   REG-STA-FNAE                       PIC X(100).*/
        public StringBasis REG_STA_FNAE { get; set; } = new StringBasis(new PIC("X", "100", "X(100)."), @"");
        /*"01   REG-RPF0711B                       PIC X(132).*/
        public StringBasis REG_RPF0711B { get; set; } = new StringBasis(new PIC("X", "132", "X(132)."), @"");

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77  S-I                    PIC 9(02)   VALUE ZEROS.*/
        public IntBasis S_I { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
        /*"77  CONT-SIDEM             PIC 9(02)   VALUE ZEROS.*/
        public IntBasis CONT_SIDEM { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
        /*"01  VIND-RCAPS-AGE                   PIC S9(4) COMP VALUE +0.*/
        public IntBasis VIND_RCAPS_AGE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01       W-REG-HEADER.*/
        public PF0711B_W_REG_HEADER W_REG_HEADER { get; set; } = new PF0711B_W_REG_HEADER();
        public class PF0711B_W_REG_HEADER : VarBasis
        {
            /*"     05  W-RH-TIPO-REG               PIC  X(001).*/
            public StringBasis W_RH_TIPO_REG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"     05  W-RH-NOME                   PIC  X(008).*/
            public StringBasis W_RH_NOME { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"     05  W-RH-DATA-GERACAO           PIC  9(008).*/
            public IntBasis W_RH_DATA_GERACAO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"     05  W-RH-SIST-ORIGEM            PIC  9(001).*/
            public IntBasis W_RH_SIST_ORIGEM { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"     05  W-RH-SIST-DESTINO           PIC  9(001).*/
            public IntBasis W_RH_SIST_DESTINO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"     05  W-RH-NSAS                   PIC  9(006).*/
            public IntBasis W_RH_NSAS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"     05  W-RH-TIPO-ARQUIVO           PIC  9(001).*/
            public IntBasis W_RH_TIPO_ARQUIVO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"     05  FILLER                      PIC  X(044).*/
            public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "44", "X(044)."), @"");
            /*"     05  W-RH-AGE-GERADORA           PIC  9(004).*/
            public IntBasis W_RH_AGE_GERADORA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"     05  FILLER                      PIC  X(226).*/
            public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "226", "X(226)."), @"");
            /*"01  WAREA-AUXILIAR.*/
        }
        public PF0711B_WAREA_AUXILIAR WAREA_AUXILIAR { get; set; } = new PF0711B_WAREA_AUXILIAR();
        public class PF0711B_WAREA_AUXILIAR : VarBasis
        {
            /*"    05  W-FIM-MOVTO-MR                PIC X(003)  VALUE SPACES.*/
            public StringBasis W_FIM_MOVTO_MR { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"    05  W-LIDO-MOVTO-MR               PIC 9(008)  VALUE ZEROS.*/
            public IntBasis W_LIDO_MOVTO_MR { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05  W-AC-CONTROLE                 PIC 9(008)  VALUE ZEROS.*/
            public IntBasis W_AC_CONTROLE { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05  W-NUM-PROPOSTA-ANT            PIC X(014)  VALUE ZEROS.*/
            public StringBasis W_NUM_PROPOSTA_ANT { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"");
            /*"    05  W-TIPO-REG-ANT                PIC 9(001)  VALUE ZERO.*/
            public IntBasis W_TIPO_REG_ANT { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*"    05  W-TIPO-REG-AUX-ANT            PIC 9(001)  VALUE ZERO.*/
            public IntBasis W_TIPO_REG_AUX_ANT { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*"    05  WS-REG-STA-MR                 PIC X(100)  VALUE SPACES.*/
            public StringBasis WS_REG_STA_MR { get; set; } = new StringBasis(new PIC("X", "100", "X(100)"), @"");
            /*"    05  W-QTD-LD-MR-0                 PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_MR_0 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-MR-1                 PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_MR_1 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-MR-2                 PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_MR_2 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-MR-3                 PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_MR_3 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-MR-4                 PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_MR_4 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-MR-5                 PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_MR_5 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-MR-6                 PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_MR_6 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-MR-7                 PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_MR_7 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-MR-8                 PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_MR_8 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-MR-9                 PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_MR_9 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-PC-MR-1                 PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_PC_MR_1 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-NP-MR-1                 PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_NP_MR_1 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-ST-MR-1                 PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_ST_MR_1 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-TOT-PC-MR                   PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_TOT_PC_MR { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-NSAS-MR                     PIC 9(006)  VALUE ZEROS.*/
            public IntBasis W_NSAS_MR { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05  W-NSAS-PRP-CEF                PIC 9(006)  VALUE ZEROS.*/
            public IntBasis W_NSAS_PRP_CEF { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05  W-INDICE-1                    PIC 9(005)  VALUE ZEROS.*/
            public IntBasis W_INDICE_1 { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"    05  W-INDICE-2                    PIC 9(005)  VALUE ZEROS.*/
            public IntBasis W_INDICE_2 { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"    05  W-INDICE-3                    PIC 9(005)  VALUE ZEROS.*/
            public IntBasis W_INDICE_3 { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"    05  W-INDICE-4                    PIC 9(005)  VALUE ZEROS.*/
            public IntBasis W_INDICE_4 { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"    05  W-INDICE-ERRO                 PIC 9(002)  VALUE ZEROS.*/
            public IntBasis W_INDICE_ERRO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"    05  W-CONT-LINHAS                 PIC 9(003)  VALUE 100.*/
            public IntBasis W_CONT_LINHAS { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"), 100);
            /*"01  W-DATAS.*/
        }
        public PF0711B_W_DATAS W_DATAS { get; set; } = new PF0711B_W_DATAS();
        public class PF0711B_W_DATAS : VarBasis
        {
            /*"    05  W-DATA-TRABALHO               PIC 9(008)  VALUE ZEROS.*/
            public IntBasis W_DATA_TRABALHO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05  FILLER REDEFINES W-DATA-TRABALHO.*/
            private _REDEF_PF0711B_FILLER_4 _filler_4 { get; set; }
            public _REDEF_PF0711B_FILLER_4 FILLER_4
            {
                get { _filler_4 = new _REDEF_PF0711B_FILLER_4(); _.Move(W_DATA_TRABALHO, _filler_4); VarBasis.RedefinePassValue(W_DATA_TRABALHO, _filler_4, W_DATA_TRABALHO); _filler_4.ValueChanged += () => { _.Move(_filler_4, W_DATA_TRABALHO); }; return _filler_4; }
                set { VarBasis.RedefinePassValue(value, _filler_4, W_DATA_TRABALHO); }
            }  //Redefines
            public class _REDEF_PF0711B_FILLER_4 : VarBasis
            {
                /*"        07  W-DIA-TRABALHO            PIC 9(002).*/
                public IntBasis W_DIA_TRABALHO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"        07  W-MES-TRABALHO            PIC 9(002).*/
                public IntBasis W_MES_TRABALHO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"        07  W-ANO-TRABALHO            PIC 9(004).*/
                public IntBasis W_ANO_TRABALHO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05  W-DTMOVABE                    PIC X(010).*/

                public _REDEF_PF0711B_FILLER_4()
                {
                    W_DIA_TRABALHO.ValueChanged += OnValueChanged;
                    W_MES_TRABALHO.ValueChanged += OnValueChanged;
                    W_ANO_TRABALHO.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis W_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    05  W-DTMOVABE1 REDEFINES W-DTMOVABE.*/
            private _REDEF_PF0711B_W_DTMOVABE1 _w_dtmovabe1 { get; set; }
            public _REDEF_PF0711B_W_DTMOVABE1 W_DTMOVABE1
            {
                get { _w_dtmovabe1 = new _REDEF_PF0711B_W_DTMOVABE1(); _.Move(W_DTMOVABE, _w_dtmovabe1); VarBasis.RedefinePassValue(W_DTMOVABE, _w_dtmovabe1, W_DTMOVABE); _w_dtmovabe1.ValueChanged += () => { _.Move(_w_dtmovabe1, W_DTMOVABE); }; return _w_dtmovabe1; }
                set { VarBasis.RedefinePassValue(value, _w_dtmovabe1, W_DTMOVABE); }
            }  //Redefines
            public class _REDEF_PF0711B_W_DTMOVABE1 : VarBasis
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

                public _REDEF_PF0711B_W_DTMOVABE1()
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
            private _REDEF_PF0711B_W_DTMOVABE_I1 _w_dtmovabe_i1 { get; set; }
            public _REDEF_PF0711B_W_DTMOVABE_I1 W_DTMOVABE_I1
            {
                get { _w_dtmovabe_i1 = new _REDEF_PF0711B_W_DTMOVABE_I1(); _.Move(W_DTMOVABE_I, _w_dtmovabe_i1); VarBasis.RedefinePassValue(W_DTMOVABE_I, _w_dtmovabe_i1, W_DTMOVABE_I); _w_dtmovabe_i1.ValueChanged += () => { _.Move(_w_dtmovabe_i1, W_DTMOVABE_I); }; return _w_dtmovabe_i1; }
                set { VarBasis.RedefinePassValue(value, _w_dtmovabe_i1, W_DTMOVABE_I); }
            }  //Redefines
            public class _REDEF_PF0711B_W_DTMOVABE_I1 : VarBasis
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

                public _REDEF_PF0711B_W_DTMOVABE_I1()
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
            private _REDEF_PF0711B_W_DATA_SQL1 _w_data_sql1 { get; set; }
            public _REDEF_PF0711B_W_DATA_SQL1 W_DATA_SQL1
            {
                get { _w_data_sql1 = new _REDEF_PF0711B_W_DATA_SQL1(); _.Move(W_DATA_SQL, _w_data_sql1); VarBasis.RedefinePassValue(W_DATA_SQL, _w_data_sql1, W_DATA_SQL); _w_data_sql1.ValueChanged += () => { _.Move(_w_data_sql1, W_DATA_SQL); }; return _w_data_sql1; }
                set { VarBasis.RedefinePassValue(value, _w_data_sql1, W_DATA_SQL); }
            }  //Redefines
            public class _REDEF_PF0711B_W_DATA_SQL1 : VarBasis
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
                /*"    05  W-DATA-SITUACAO               PIC X(010).*/

                public _REDEF_PF0711B_W_DATA_SQL1()
                {
                    W_ANO_SQL.ValueChanged += OnValueChanged;
                    W_BARRA1_1.ValueChanged += OnValueChanged;
                    W_MES_SQL.ValueChanged += OnValueChanged;
                    W_BARRA2_1.ValueChanged += OnValueChanged;
                    W_DIA_SQL.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis W_DATA_SITUACAO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    05  W-DATA-SIT-RD REDEFINES W-DATA-SITUACAO.*/
            private _REDEF_PF0711B_W_DATA_SIT_RD _w_data_sit_rd { get; set; }
            public _REDEF_PF0711B_W_DATA_SIT_RD W_DATA_SIT_RD
            {
                get { _w_data_sit_rd = new _REDEF_PF0711B_W_DATA_SIT_RD(); _.Move(W_DATA_SITUACAO, _w_data_sit_rd); VarBasis.RedefinePassValue(W_DATA_SITUACAO, _w_data_sit_rd, W_DATA_SITUACAO); _w_data_sit_rd.ValueChanged += () => { _.Move(_w_data_sit_rd, W_DATA_SITUACAO); }; return _w_data_sit_rd; }
                set { VarBasis.RedefinePassValue(value, _w_data_sit_rd, W_DATA_SITUACAO); }
            }  //Redefines
            public class _REDEF_PF0711B_W_DATA_SIT_RD : VarBasis
            {
                /*"        07  W-DIA-SITUACAO            PIC 9(002).*/
                public IntBasis W_DIA_SITUACAO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"        07  W-BARRA1                  PIC X(001).*/
                public StringBasis W_BARRA1_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"        07  W-MES-SITUACAO            PIC 9(002).*/
                public IntBasis W_MES_SITUACAO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"        07  W-BARRA2                  PIC X(001).*/
                public StringBasis W_BARRA2_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"        07  W-ANO-SITUACAO            PIC 9(004).*/
                public IntBasis W_ANO_SITUACAO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05  W-NUM-PROPOSTA                PIC  9(014) VALUE ZEROS.*/

                public _REDEF_PF0711B_W_DATA_SIT_RD()
                {
                    W_DIA_SITUACAO.ValueChanged += OnValueChanged;
                    W_BARRA1_2.ValueChanged += OnValueChanged;
                    W_MES_SITUACAO.ValueChanged += OnValueChanged;
                    W_BARRA2_2.ValueChanged += OnValueChanged;
                    W_ANO_SITUACAO.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis W_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "14", "9(014)"));
            /*"    05  FILLER                      REDEFINES  W-NUM-PROPOSTA.*/
            private _REDEF_PF0711B_FILLER_5 _filler_5 { get; set; }
            public _REDEF_PF0711B_FILLER_5 FILLER_5
            {
                get { _filler_5 = new _REDEF_PF0711B_FILLER_5(); _.Move(W_NUM_PROPOSTA, _filler_5); VarBasis.RedefinePassValue(W_NUM_PROPOSTA, _filler_5, W_NUM_PROPOSTA); _filler_5.ValueChanged += () => { _.Move(_filler_5, W_NUM_PROPOSTA); }; return _filler_5; }
                set { VarBasis.RedefinePassValue(value, _filler_5, W_NUM_PROPOSTA); }
            }  //Redefines
            public class _REDEF_PF0711B_FILLER_5 : VarBasis
            {
                /*"      10    WNUM-PROP-13              PIC  9(013).*/
                public IntBasis WNUM_PROP_13 { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
                /*"      10    WDIG-PROP                 PIC  9.*/
                public IntBasis WDIG_PROP { get; set; } = new IntBasis(new PIC("9", "1", "9."));
                /*"    05  W-REG-SAIDA                   PIC  X(100) VALUE SPACES.*/

                public _REDEF_PF0711B_FILLER_5()
                {
                    WNUM_PROP_13.ValueChanged += OnValueChanged;
                    WDIG_PROP.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis W_REG_SAIDA { get; set; } = new StringBasis(new PIC("X", "100", "X(100)"), @"");
            /*"    05  FILLER   REDEFINES W-REG-SAIDA.*/
            private _REDEF_PF0711B_FILLER_6 _filler_6 { get; set; }
            public _REDEF_PF0711B_FILLER_6 FILLER_6
            {
                get { _filler_6 = new _REDEF_PF0711B_FILLER_6(); _.Move(W_REG_SAIDA, _filler_6); VarBasis.RedefinePassValue(W_REG_SAIDA, _filler_6, W_REG_SAIDA); _filler_6.ValueChanged += () => { _.Move(_filler_6, W_REG_SAIDA); }; return _filler_6; }
                set { VarBasis.RedefinePassValue(value, _filler_6, W_REG_SAIDA); }
            }  //Redefines
            public class _REDEF_PF0711B_FILLER_6 : VarBasis
            {
                /*"     10  FILLER                          PIC X(001).*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"     10  WSD-NUM-PROPOSTA                PIC 9(014).*/
                public IntBasis WSD_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
                /*"     10  FILLER                          PIC X(085).*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "85", "X(085)."), @"");
                /*"01  WS-TIME.*/

                public _REDEF_PF0711B_FILLER_6()
                {
                    FILLER_7.ValueChanged += OnValueChanged;
                    WSD_NUM_PROPOSTA.ValueChanged += OnValueChanged;
                    FILLER_8.ValueChanged += OnValueChanged;
                }

            }
        }
        public PF0711B_WS_TIME WS_TIME { get; set; } = new PF0711B_WS_TIME();
        public class PF0711B_WS_TIME : VarBasis
        {
            /*"    05 WS-TIME-N                     PIC 9(06).*/
            public IntBasis WS_TIME_N { get; set; } = new IntBasis(new PIC("9", "6", "9(06)."));
            /*"    05 FILLER                        PIC X(02).*/
            public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "2", "X(02)."), @"");
            /*"01  WS-TIME-EDIT                     PIC 99.99.99.*/
        }
        public IntBasis WS_TIME_EDIT { get; set; } = new IntBasis(new PIC("9", "6", "99.99.99."));
        /*"01  WABEND.*/
        public PF0711B_WABEND WABEND { get; set; } = new PF0711B_WABEND();
        public class PF0711B_WABEND : VarBasis
        {
            /*"      10    FILLER                   PIC  X(010) VALUE            'PF0711B  '.*/
            public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"PF0711B  ");
            /*"      10    FILLER                   PIC  X(028) VALUE            ' *** ERRO  EXEC SQL *** '.*/
            public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @" *** ERRO  EXEC SQL *** ");
            /*"      10    FILLER                   PIC  X(014) VALUE            '    SQLCODE = '.*/
            public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE = ");
            /*"      10    WSQLCODE                 PIC  ZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
            /*"      10    FILLER                   PIC  X(014)   VALUE            '   SQLERRD1 = '.*/
            public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD1 = ");
            /*"      10    WSQLERRD1                PIC  ZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLERRD1 { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
            /*"      10    FILLER                   PIC  X(014)   VALUE            '   SQLERRD2 = '.*/
            public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD2 = ");
            /*"      10    WSQLERRD2                PIC  ZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLERRD2 { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
            /*"      10    FILLER                   PIC  X(014)   VALUE            '   SQLERRD2 = '.*/
            public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD2 = ");
            /*"      05      LOCALIZA-ABEND-1.*/
            public PF0711B_LOCALIZA_ABEND_1 LOCALIZA_ABEND_1 { get; set; } = new PF0711B_LOCALIZA_ABEND_1();
            public class PF0711B_LOCALIZA_ABEND_1 : VarBasis
            {
                /*"        10    FILLER                   PIC  X(012)   VALUE              'PARAGRAFO = '.*/
                public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"PARAGRAFO = ");
                /*"        10    PARAGRAFO               PIC  X(040)   VALUE SPACES*/
                public StringBasis PARAGRAFO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"      05      LOCALIZA-ABEND-2.*/
            }
            public PF0711B_LOCALIZA_ABEND_2 LOCALIZA_ABEND_2 { get; set; } = new PF0711B_LOCALIZA_ABEND_2();
            public class PF0711B_LOCALIZA_ABEND_2 : VarBasis
            {
                /*"        10    FILLER                   PIC  X(012)   VALUE              'COMANDO   = '.*/
                public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"COMANDO   = ");
                /*"        10    COMANDO                 PIC  X(060)   VALUE SPACES*/
                public StringBasis COMANDO { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"");
                /*"      05  WSQLERRO.*/
            }
            public PF0711B_WSQLERRO WSQLERRO { get; set; } = new PF0711B_WSQLERRO();
            public class PF0711B_WSQLERRO : VarBasis
            {
                /*"        10    FILLER                   PIC X(014)  VALUE              ' *** SQLERRMC '.*/
                public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @" *** SQLERRMC ");
                /*"        10    WSQLERRMC                PIC X(070)  VALUE SPACES.*/
                public StringBasis WSQLERRMC { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"");
                /*"01  WREA88.*/
            }
        }
        public PF0711B_WREA88 WREA88 { get; set; } = new PF0711B_WREA88();
        public class PF0711B_WREA88 : VarBasis
        {
            /*"    05 W-TIPO-MOVIMENTO               PIC  9(001) VALUE ZERO.*/

            public SelectorBasis W_TIPO_MOVIMENTO { get; set; } = new SelectorBasis("001", "ZERO")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 REGISTRO-ENDOSSO                        VALUE 0. */
							new SelectorItemBasis("REGISTRO_ENDOSSO", "0"),
							/*" 88 REGISTRO-PROPOSTA                       VALUE 1. */
							new SelectorItemBasis("REGISTRO_PROPOSTA", "1"),
							/*" 88 REGISTRO-APOLICE                        VALUE 2. */
							new SelectorItemBasis("REGISTRO_APOLICE", "2"),
							/*" 88 REGISTRO-COBERTURA                      VALUE 3. */
							new SelectorItemBasis("REGISTRO_COBERTURA", "3"),
							/*" 88 REGISTRO-PAGAMENTO                      VALUE 4. */
							new SelectorItemBasis("REGISTRO_PAGAMENTO", "4"),
							/*" 88 REGISTRO-SIDEM-BL-33                    VALUE 8. */
							new SelectorItemBasis("REGISTRO_SIDEM_BL_33", "8")
                }
            };

            /*"    05 W-REGISTRO-ENDOSSO             PIC  9      VALUE ZERO.*/

            public SelectorBasis W_REGISTRO_ENDOSSO { get; set; } = new SelectorBasis("9", "ZERO")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 TEM-REGISTRO-ENDOSSO                    VALUE 1. */
							new SelectorItemBasis("TEM_REGISTRO_ENDOSSO", "1")
                }
            };

            /*"    05 W-REGISTRO-PROPOSTA            PIC  9      VALUE ZERO.*/

            public SelectorBasis W_REGISTRO_PROPOSTA { get; set; } = new SelectorBasis("9", "ZERO")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 TEM-REGISTRO-PROPOSTA                   VALUE 1. */
							new SelectorItemBasis("TEM_REGISTRO_PROPOSTA", "1")
                }
            };

            /*"    05 W-REGISTRO-APOLICE             PIC  9      VALUE ZERO.*/

            public SelectorBasis W_REGISTRO_APOLICE { get; set; } = new SelectorBasis("9", "ZERO")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 TEM-REGISTRO-APOLICE                    VALUE 1. */
							new SelectorItemBasis("TEM_REGISTRO_APOLICE", "1")
                }
            };

            /*"    05 W-LEU-PRP-FIDELIZ              PIC  9      VALUE ZERO.*/

            public SelectorBasis W_LEU_PRP_FIDELIZ { get; set; } = new SelectorBasis("9", "ZERO")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 NAO-LEU-PROPOSTA                        VALUE 0. */
							new SelectorItemBasis("NAO_LEU_PROPOSTA", "0")
                }
            };

            /*"    05 W-REGISTRO-COBERTURA           PIC  9      VALUE ZERO.*/

            public SelectorBasis W_REGISTRO_COBERTURA { get; set; } = new SelectorBasis("9", "ZERO")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 TEM-REGISTRO-COBERTURA                  VALUE 1. */
							new SelectorItemBasis("TEM_REGISTRO_COBERTURA", "1")
                }
            };

            /*"    05 W-REGISTRO-PAGAMENTO           PIC  9      VALUE ZERO.*/

            public SelectorBasis W_REGISTRO_PAGAMENTO { get; set; } = new SelectorBasis("9", "ZERO")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 TEM-REGISTRO-PAGAMENTO                  VALUE 1. */
							new SelectorItemBasis("TEM_REGISTRO_PAGAMENTO", "1")
                }
            };

            /*"    05 W-EXISTE-FIDELIZ               PIC  9(001) VALUE ZERO.*/

            public SelectorBasis W_EXISTE_FIDELIZ { get; set; } = new SelectorBasis("001", "ZERO")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 TEM-PROPOSTA-FIDELIZ                    VALUE 1. */
							new SelectorItemBasis("TEM_PROPOSTA_FIDELIZ", "1")
                }
            };

            /*"    05 W-GEROU-MOVTO-CEF              PIC  9(001) VALUE ZERO.*/

            public SelectorBasis W_GEROU_MOVTO_CEF { get; set; } = new SelectorBasis("001", "ZERO")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 GEROU-MOVTO-CEF                         VALUE 1. */
							new SelectorItemBasis("GEROU_MOVTO_CEF", "1")
                }
            };

            /*"    05 W-HEADER-STA-CEF               PIC  9(001) VALUE ZERO.*/

            public SelectorBasis W_HEADER_STA_CEF { get; set; } = new SelectorBasis("001", "ZERO")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 HDSTA-NAO-GERADO                        VALUE 1. */
							new SelectorItemBasis("HDSTA_NAO_GERADO", "1"),
							/*" 88 HDSTA-FOI-GERADO                        VALUE 2. */
							new SelectorItemBasis("HDSTA_FOI_GERADO", "2")
                }
            };

            /*"    05 W-HISTORICO                    PIC  9(001) VALUE ZERO.*/

            public SelectorBasis W_HISTORICO { get; set; } = new SelectorBasis("001", "ZERO")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 HISTORICO-CADASTRADO                    VALUE 1. */
							new SelectorItemBasis("HISTORICO_CADASTRADO", "1"),
							/*" 88 HISTORICO-NAO-CADASTRADO                VALUE 2. */
							new SelectorItemBasis("HISTORICO_NAO_CADASTRADO", "2")
                }
            };

            /*"    05 W-LEITURA-RCAP                 PIC  9(001) VALUE ZERO.*/

            public SelectorBasis W_LEITURA_RCAP { get; set; } = new SelectorBasis("001", "ZERO")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 RCAP-CADASTRADO                         VALUE 1. */
							new SelectorItemBasis("RCAP_CADASTRADO", "1"),
							/*" 88 RCAP-NAO-CADASTRADO                     VALUE 2. */
							new SelectorItemBasis("RCAP_NAO_CADASTRADO", "2")
                }
            };

            /*"    05 W-UPDATE-PROPOSTA              PIC  9(001) VALUE ZERO.*/

            public SelectorBasis W_UPDATE_PROPOSTA { get; set; } = new SelectorBasis("001", "ZERO")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 ATUALIZAR-PROPOSTA                      VALUE 1. */
							new SelectorItemBasis("ATUALIZAR_PROPOSTA", "1"),
							/*" 88 NAO-ATUALIZAR-PROPOSTA                  VALUE 2. */
							new SelectorItemBasis("NAO_ATUALIZAR_PROPOSTA", "2")
                }
            };

            /*"    05 W-REGISTRO-SIDEM-BL-33         PIC  9      VALUE ZERO.*/

            public SelectorBasis W_REGISTRO_SIDEM_BL_33 { get; set; } = new SelectorBasis("9", "ZERO")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 TEM-REGISTRO-SIDEM-BL-33                VALUE 1. */
							new SelectorItemBasis("TEM_REGISTRO_SIDEM_BL_33", "1")
                }
            };

            /*"    05 WS-FILE-STATUS                 PIC  9(002) VALUE ZERO.*/
            public IntBasis WS_FILE_STATUS { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"01              LC00.*/
        }
        public PF0711B_LC00 LC00 { get; set; } = new PF0711B_LC00();
        public class PF0711B_LC00 : VarBasis
        {
            /*"  05            LC01.*/
            public PF0711B_LC01 LC01 { get; set; } = new PF0711B_LC01();
            public class PF0711B_LC01 : VarBasis
            {
                /*"    10          LC01-RELATORIO  PIC  X(008) VALUE 'RPF0711B'.*/
                public StringBasis LC01_RELATORIO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"RPF0711B");
                /*"    10          FILLER          PIC  X(050) VALUE  SPACES.*/
                public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"");
                /*"    10          FILLER          PIC  X(028) VALUE     'C A I X A    S E G U R O S '.*/
                public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @"C A I X A    S E G U R O S ");
                /*"    10          FILLER          PIC  X(023) VALUE  SPACES.*/
                public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "23", "X(023)"), @"");
                /*"    10          FILLER          PIC  X(012) VALUE '    PAGINA: '*/
                public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"    PAGINA: ");
                /*"    10          LC01-PAGINA     PIC  9(04).*/
                public IntBasis LC01_PAGINA { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                /*"  05            LC02.*/
            }
            public PF0711B_LC02 LC02 { get; set; } = new PF0711B_LC02();
            public class PF0711B_LC02 : VarBasis
            {
                /*"    10          FILLER          PIC  X(113) VALUE  SPACES.*/
                public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "113", "X(113)"), @"");
                /*"    10          FILLER          PIC  X(008) VALUE 'DATA..: '.*/
                public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"DATA..: ");
                /*"    10          LC02-DATA       PIC  X(010) VALUE  SPACES.*/
                public StringBasis LC02_DATA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"  05            LC03.*/
            }
            public PF0711B_LC03 LC03 { get; set; } = new PF0711B_LC03();
            public class PF0711B_LC03 : VarBasis
            {
                /*"    10          FILLER          PIC  X(039) VALUE  SPACES.*/
                public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "39", "X(039)"), @"");
                /*"    10          FILLER          PIC  X(056) VALUE    'RELATORIO DE CRITICAS DO RETORNO STATUS MULTIRISCO RESI'.*/
                public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "56", "X(056)"), @"RELATORIO DE CRITICAS DO RETORNO STATUS MULTIRISCO RESI");
                /*"    10          FILLER          PIC  X(013) VALUE    'DENCIAL A CEF'.*/
                public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"DENCIAL A CEF");
                /*"    10          FILLER          PIC  X(007) VALUE  SPACES.*/
                public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"");
                /*"    10          FILLER          PIC  X(008) VALUE 'HORA..: '.*/
                public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"HORA..: ");
                /*"    10          LC03-HORA       PIC  X(008) VALUE  SPACES.*/
                public StringBasis LC03_HORA { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
                /*"  05            LC04.*/
            }
            public PF0711B_LC04 LC04 { get; set; } = new PF0711B_LC04();
            public class PF0711B_LC04 : VarBasis
            {
                /*"    10          FILLER            PIC  X(020) VALUE               'ARQUIVO PROCESSADO: '.*/
                public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"ARQUIVO PROCESSADO: ");
                /*"    10          LC04-NSAS-SIVPF   PIC  ZZZ9.*/
                public IntBasis LC04_NSAS_SIVPF { get; set; } = new IntBasis(new PIC("9", "4", "ZZZ9."));
                /*"    10          FILLER            PIC  X(013) VALUE               ' - GERADO EM '.*/
                public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" - GERADO EM ");
                /*"    10          LC04-DATA-GERACAO PIC  X(010).*/
                public StringBasis LC04_DATA_GERACAO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"    10          FILLER            PIC  X(082) VALUE  SPACES.*/
                public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "82", "X(082)"), @"");
                /*"  05            LC05.*/
            }
            public PF0711B_LC05 LC05 { get; set; } = new PF0711B_LC05();
            public class PF0711B_LC05 : VarBasis
            {
                /*"    10          FILLER            PIC  X(013) VALUE               '    PROPOSTA '.*/
                public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"    PROPOSTA ");
                /*"    10          FILLER            PIC  X(015) VALUE SPACES.*/
                public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"");
                /*"    10          FILLER            PIC  X(009) VALUE               ' SITUACAO'.*/
                public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @" SITUACAO");
                /*"    10          FILLER            PIC  X(013) VALUE SPACES.*/
                public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"");
                /*"    10          FILLER            PIC  X(013) VALUE               'DATA SITUACAO'.*/
                public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"DATA SITUACAO");
                /*"    10          FILLER            PIC  X(017) VALUE SPACES.*/
                public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "17", "X(017)"), @"");
                /*"    10          FILLER            PIC  X(027) VALUE               'DESCRICAO DA INCONSISTENCIA'.*/
                public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "27", "X(027)"), @"DESCRICAO DA INCONSISTENCIA");
                /*"  05            LC06.*/
            }
            public PF0711B_LC06 LC06 { get; set; } = new PF0711B_LC06();
            public class PF0711B_LC06 : VarBasis
            {
                /*"    10          FILLER              PIC  X(001) VALUE  SPACES.*/
                public StringBasis FILLER_40 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10          LC06-NUM-PROPOSTA   PIC  9(014).*/
                public IntBasis LC06_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
                /*"    10          FILLER              PIC  X(016) VALUE  SPACES.*/
                public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "16", "X(016)"), @"");
                /*"    10          LC06-SITUACAO       PIC  X(003).*/
                public StringBasis LC06_SITUACAO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
                /*"    10          FILLER              PIC  X(017) VALUE  SPACES.*/
                public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "17", "X(017)"), @"");
                /*"    10          LC06-DATA-SITUACAO  PIC  X(010).*/
                public StringBasis LC06_DATA_SITUACAO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"    10          FILLER              PIC  X(019) VALUE  SPACES.*/
                public StringBasis FILLER_43 { get; set; } = new StringBasis(new PIC("X", "19", "X(019)"), @"");
                /*"    10          LC06-DESCRICAO      PIC  X(050).*/
                public StringBasis LC06_DESCRICAO { get; set; } = new StringBasis(new PIC("X", "50", "X(050)."), @"");
                /*"  05            LC07.*/
            }
            public PF0711B_LC07 LC07 { get; set; } = new PF0711B_LC07();
            public class PF0711B_LC07 : VarBasis
            {
                /*"    10          LC07-FILLER          PIC  X(132) VALUE ALL '-'.*/
                public StringBasis LC07_FILLER { get; set; } = new StringBasis(new PIC("X", "132", "X(132)"), @"ALL");
                /*"01  AREA-DAS-TABELAS.*/
            }
        }
        public PF0711B_AREA_DAS_TABELAS AREA_DAS_TABELAS { get; set; } = new PF0711B_AREA_DAS_TABELAS();
        public class PF0711B_AREA_DAS_TABELAS : VarBasis
        {
            /*"    05 W-TAB-CONSISTENCIA.*/
            public PF0711B_W_TAB_CONSISTENCIA W_TAB_CONSISTENCIA { get; set; } = new PF0711B_W_TAB_CONSISTENCIA();
            public class PF0711B_W_TAB_CONSISTENCIA : VarBasis
            {
                /*"       10 FILLER  OCCURS 30000 TIMES.*/
                public ListBasis<PF0711B_FILLER_44> FILLER_44 { get; set; } = new ListBasis<PF0711B_FILLER_44>(30000);
                public class PF0711B_FILLER_44 : VarBasis
                {
                    /*"          15 W-TB-NUM-PROPOSTA PIC  9(014).*/
                    public IntBasis W_TB_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
                    /*"          15 W-TB-SIT-PROPOSTA PIC  X(003).*/
                    public StringBasis W_TB_SIT_PROPOSTA { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
                    /*"          15 W-TB-DT-SITUACAO  PIC  9(008).*/
                    public IntBasis W_TB_DT_SITUACAO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                    /*"          15 W-TB-COD-DESCRI   PIC  9(001).*/
                    public IntBasis W_TB_COD_DESCRI { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"    05 W-TAB-DESCRICAO.*/
                }
            }
            public PF0711B_W_TAB_DESCRICAO W_TAB_DESCRICAO { get; set; } = new PF0711B_W_TAB_DESCRICAO();
            public class PF0711B_W_TAB_DESCRICAO : VarBasis
            {
                /*"       10 FILLER               PIC  X(060)     VALUE          '01PROPOSTA NAO CADASTRADA '.*/
                public StringBasis FILLER_45 { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"01PROPOSTA NAO CADASTRADA ");
                /*"       10 FILLER               PIC  X(060)     VALUE          '02STATUS ENVIADO A CEF EM PROCESSAMENTO ANTERIOR'.*/
                public StringBasis FILLER_46 { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"02STATUS ENVIADO A CEF EM PROCESSAMENTO ANTERIOR");
                /*"    05 W-TAB-DESCRICAO-RD  REDEFINES W-TAB-DESCRICAO                           OCCURS 2.*/
            }
            private ListBasis<_REDEF_PF0711B_W_TAB_DESCRICAO_RD> _w_tab_descricao_rd { get; set; }
            public ListBasis<_REDEF_PF0711B_W_TAB_DESCRICAO_RD> W_TAB_DESCRICAO_RD
            {
                get { _w_tab_descricao_rd = new ListBasis<_REDEF_PF0711B_W_TAB_DESCRICAO_RD>(2); _.Move(W_TAB_DESCRICAO, _w_tab_descricao_rd); VarBasis.RedefinePassValue(W_TAB_DESCRICAO, _w_tab_descricao_rd, W_TAB_DESCRICAO); _w_tab_descricao_rd.ValueChanged += () => { _.Move(_w_tab_descricao_rd, W_TAB_DESCRICAO); }; return _w_tab_descricao_rd; }
                set { VarBasis.RedefinePassValue(value, _w_tab_descricao_rd, W_TAB_DESCRICAO); }
            }  //Redefines
            public class _REDEF_PF0711B_W_TAB_DESCRICAO_RD : VarBasis
            {
                /*"       10 W-TB-CODIGO       PIC  9(002).*/
                public IntBasis W_TB_CODIGO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       10 W-TB-DESCRI-ERRO  PIC  X(058).*/
                public StringBasis W_TB_DESCRI_ERRO { get; set; } = new StringBasis(new PIC("X", "58", "X(058)."), @"");
                /*"    05 W-TAB-COBERTURA.*/

                public _REDEF_PF0711B_W_TAB_DESCRICAO_RD()
                {
                    W_TB_CODIGO.ValueChanged += OnValueChanged;
                    W_TB_DESCRI_ERRO.ValueChanged += OnValueChanged;
                }

            }
            public PF0711B_W_TAB_COBERTURA W_TAB_COBERTURA { get; set; } = new PF0711B_W_TAB_COBERTURA();
            public class PF0711B_W_TAB_COBERTURA : VarBasis
            {
                /*"       10 FILLER  OCCURS 500 TIMES.*/
                public ListBasis<PF0711B_FILLER_47> FILLER_47 { get; set; } = new ListBasis<PF0711B_FILLER_47>(500);
                public class PF0711B_FILLER_47 : VarBasis
                {
                    /*"          15 W-TB-REGISTRO-COBERTURA PIC  X(100).*/
                    public StringBasis W_TB_REGISTRO_COBERTURA { get; set; } = new StringBasis(new PIC("X", "100", "X(100)."), @"");
                    /*"    05 W-TAB-REG-SIDEM.*/
                }
            }
            public PF0711B_W_TAB_REG_SIDEM W_TAB_REG_SIDEM { get; set; } = new PF0711B_W_TAB_REG_SIDEM();
            public class PF0711B_W_TAB_REG_SIDEM : VarBasis
            {
                /*"       10 FILLER  OCCURS 30 TIMES.*/
                public ListBasis<PF0711B_FILLER_48> FILLER_48 { get; set; } = new ListBasis<PF0711B_FILLER_48>(30);
                public class PF0711B_FILLER_48 : VarBasis
                {
                    /*"          15 W-TB-REGISTRO-SIDEM     PIC  X(100).*/
                    public StringBasis W_TB_REGISTRO_SIDEM { get; set; } = new StringBasis(new PIC("X", "100", "X(100)."), @"");
                    /*"          15 FILLER REDEFINES W-TB-REGISTRO-SIDEM.*/
                    private _REDEF_PF0711B_FILLER_49 _filler_49 { get; set; }
                    public _REDEF_PF0711B_FILLER_49 FILLER_49
                    {
                        get { _filler_49 = new _REDEF_PF0711B_FILLER_49(); _.Move(W_TB_REGISTRO_SIDEM, _filler_49); VarBasis.RedefinePassValue(W_TB_REGISTRO_SIDEM, _filler_49, W_TB_REGISTRO_SIDEM); _filler_49.ValueChanged += () => { _.Move(_filler_49, W_TB_REGISTRO_SIDEM); }; return _filler_49; }
                        set { VarBasis.RedefinePassValue(value, _filler_49, W_TB_REGISTRO_SIDEM); }
                    }  //Redefines
                    public class _REDEF_PF0711B_FILLER_49 : VarBasis
                    {
                        /*"             20  FILLER              PIC  9(01).*/
                        public IntBasis FILLER_50 { get; set; } = new IntBasis(new PIC("9", "1", "9(01)."));
                        /*"             20  PROP-TAB-SIDEM      PIC  9(14).*/
                        public IntBasis PROP_TAB_SIDEM { get; set; } = new IntBasis(new PIC("9", "14", "9(14)."));
                        /*"             20  FILLER              PIC  X(85).*/
                        public StringBasis FILLER_51 { get; set; } = new StringBasis(new PIC("X", "85", "X(85)."), @"");

                        public _REDEF_PF0711B_FILLER_49()
                        {
                            FILLER_50.ValueChanged += OnValueChanged;
                            PROP_TAB_SIDEM.ValueChanged += OnValueChanged;
                            FILLER_51.ValueChanged += OnValueChanged;
                        }

                    }
                }
            }
        }


        public Copies.LBFCT000 LBFCT000 { get; set; } = new Copies.LBFCT000();
        public Copies.LBFCT011 LBFCT011 { get; set; } = new Copies.LBFCT011();
        public Copies.LBFCT016 LBFCT016 { get; set; } = new Copies.LBFCT016();
        public Copies.LBFPF025 LBFPF025 { get; set; } = new Copies.LBFPF025();
        public Dclgens.MALHACEF MALHACEF { get; set; } = new Dclgens.MALHACEF();
        public Dclgens.RCAPS RCAPS { get; set; } = new Dclgens.RCAPS();
        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.PROPFID PROPFID { get; set; } = new Dclgens.PROPFID();
        public Dclgens.PROPFIDH PROPFIDH { get; set; } = new Dclgens.PROPFIDH();
        public Dclgens.COVSIVPF COVSIVPF { get; set; } = new Dclgens.COVSIVPF();
        public Dclgens.ARQSIVPF ARQSIVPF { get; set; } = new Dclgens.ARQSIVPF();
        public Dclgens.PROPFIDC PROPFIDC { get; set; } = new Dclgens.PROPFIDC();
        public Dclgens.PRDSIVPF PRDSIVPF { get; set; } = new Dclgens.PRDSIVPF();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string MOV_STA_MR_FILE_NAME_P, string MOV_STA_CEF_FILE_NAME_P, string MOV_STA_FNAE_FILE_NAME_P, string RPF0711B_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                MOV_STA_MR.SetFile(MOV_STA_MR_FILE_NAME_P);
                MOV_STA_CEF.SetFile(MOV_STA_CEF_FILE_NAME_P);
                MOV_STA_FNAE.SetFile(MOV_STA_FNAE_FILE_NAME_P);
                RPF0711B.SetFile(RPF0711B_FILE_NAME_P);

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
            /*" -565- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -566- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -567- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -570- DISPLAY '************************************************' . */
            _.Display($"************************************************");

            /*" -571- DISPLAY '*               PROGRAMA PF0711B               *' . */
            _.Display($"*               PROGRAMA PF0711B               *");

            /*" -572- DISPLAY '* GERA STATUS DE PROPOSTAS DE MULTIRISCO RESID *' . */
            _.Display($"* GERA STATUS DE PROPOSTAS DE MULTIRISCO RESID *");

            /*" -573- DISPLAY '*           VERSAO:  10 - 14/03/2014           *' . */
            _.Display($"*           VERSAO:  10 - 14/03/2014           *");

            /*" -574- DISPLAY '************************************************' . */
            _.Display($"************************************************");

            /*" -584- DISPLAY '*  PF0711B - INICIO  EM ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2). */

            $"*  PF0711B - INICIO  EM {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
            .Display();

            /*" -586- PERFORM R0000-00-INICIALIZAR. */

            R0000_00_INICIALIZAR_SECTION();

            /*" -588- PERFORM R0050-00-LER-MOV-MR. */

            R0050_00_LER_MOV_MR_SECTION();

            /*" -589- IF W-FIM-MOVTO-MR EQUAL 'FIM' */

            if (WAREA_AUXILIAR.W_FIM_MOVTO_MR == "FIM")
            {

                /*" -590- DISPLAY '************************************************' */
                _.Display($"************************************************");

                /*" -591- DISPLAY '*                   PF0711B                    *' */
                _.Display($"*                   PF0711B                    *");

                /*" -592- DISPLAY '*               TERMINO  NORMAL                *' */
                _.Display($"*               TERMINO  NORMAL                *");

                /*" -593- DISPLAY '*                                              *' */
                _.Display($"*                                              *");

                /*" -594- DISPLAY '*             NAO HOUVE MOVIMENTO              *' */
                _.Display($"*             NAO HOUVE MOVIMENTO              *");

                /*" -595- DISPLAY '************************************************' */
                _.Display($"************************************************");

                /*" -596- PERFORM R9977-00-FECHAR-ARQUIVOS */

                R9977_00_FECHAR_ARQUIVOS_SECTION();

                /*" -598- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


            /*" -600- MOVE 1 TO W-HEADER-STA-CEF. */
            _.Move(1, WREA88.W_HEADER_STA_CEF);

            /*" -603- PERFORM R0200-00-PROCESSAR-MOVIMENTO UNTIL W-FIM-MOVTO-MR EQUAL 'FIM' . */

            while (!(WAREA_AUXILIAR.W_FIM_MOVTO_MR == "FIM"))
            {

                R0200_00_PROCESSAR_MOVIMENTO_SECTION();
            }

            /*" -604- IF HDSTA-FOI-GERADO */

            if (WREA88.W_HEADER_STA_CEF["HDSTA_FOI_GERADO"])
            {

                /*" -605- PERFORM R2080-00-TRAILLER-CEF */

                R2080_00_TRAILLER_CEF_SECTION();

                /*" -606- PERFORM R2090-00-ATUALIZAR-ARQSIVPF */

                R2090_00_ATUALIZAR_ARQSIVPF_SECTION();

                /*" -608- END-IF */
            }


            /*" -610- PERFORM R9966-00-GERAR-TOTAIS. */

            R9966_00_GERAR_TOTAIS_SECTION();

            /*" -612- PERFORM R9977-00-FECHAR-ARQUIVOS. */

            R9977_00_FECHAR_ARQUIVOS_SECTION();

            /*" -613- IF W-INDICE-1 GREATER ZEROS */

            if (WAREA_AUXILIAR.W_INDICE_1 > 00)
            {

                /*" -615- PERFORM R9980-00-GERAR-RELATORIO. */

                R9980_00_GERAR_RELATORIO_SECTION();
            }


            /*" -615- PERFORM R9999-00-FINALIZAR. */

            R9999_00_FINALIZAR_SECTION();

        }

        [StopWatch]
        /*" R0000-00-INICIALIZAR-SECTION */
        private void R0000_00_INICIALIZAR_SECTION()
        {
            /*" -623- MOVE 'R0000-00-INICIALIZAR' TO PARAGRAFO. */
            _.Move("R0000-00-INICIALIZAR", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -625- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -627- MOVE SPACES TO W-REG-HEADER. */
            _.Move("", W_REG_HEADER);

            /*" -629- PERFORM R0005-00-OBTER-DATA-DIA. */

            R0005_00_OBTER_DATA_DIA_SECTION();

            /*" -631- PERFORM R0010-00-ABRIR-ARQUIVOS. */

            R0010_00_ABRIR_ARQUIVOS_SECTION();

            /*" -631- INITIALIZE W-TAB-CONSISTENCIA. */
            _.Initialize(
                AREA_DAS_TABELAS.W_TAB_CONSISTENCIA
            );

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_SAIDA*/

        [StopWatch]
        /*" R0005-00-OBTER-DATA-DIA-SECTION */
        private void R0005_00_OBTER_DATA_DIA_SECTION()
        {
            /*" -641- MOVE 'R0005-00-OBTER-DATA-DIA' TO PARAGRAFO. */
            _.Move("R0005-00-OBTER-DATA-DIA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -643- MOVE 'SELECT SEGUROS.SISTEMAS' TO COMANDO. */
            _.Move("SELECT SEGUROS.SISTEMAS", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -645- MOVE 'PF' TO SISTEMAS-IDE-SISTEMA OF DCLSISTEMAS. */
            _.Move("PF", SISTEMAS.DCLSISTEMAS.SISTEMAS_IDE_SISTEMA);

            /*" -651- PERFORM R0005_00_OBTER_DATA_DIA_DB_SELECT_1 */

            R0005_00_OBTER_DATA_DIA_DB_SELECT_1();

            /*" -656- MOVE SISTEMAS-DATA-MOV-ABERTO OF DCLSISTEMAS TO W-DTMOVABE. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, W_DATAS.W_DTMOVABE);

            /*" -658- MOVE W-DIA-MOVABE OF W-DTMOVABE1 TO W-DIA-MOVABE OF W-DTMOVABE-I1. */
            _.Move(W_DATAS.W_DTMOVABE1.W_DIA_MOVABE, W_DATAS.W_DTMOVABE_I1.W_DIA_MOVABE_0);

            /*" -660- MOVE W-MES-MOVABE OF W-DTMOVABE1 TO W-MES-MOVABE OF W-DTMOVABE-I1. */
            _.Move(W_DATAS.W_DTMOVABE1.W_MES_MOVABE, W_DATAS.W_DTMOVABE_I1.W_MES_MOVABE_0);

            /*" -663- MOVE W-ANO-MOVABE OF W-DTMOVABE1 TO W-ANO-MOVABE OF W-DTMOVABE-I1. */
            _.Move(W_DATAS.W_DTMOVABE1.W_ANO_MOVABE, W_DATAS.W_DTMOVABE_I1.W_ANO_MOVABE_0);

            /*" -665- MOVE '-' TO W-BARRA1 OF W-DTMOVABE-I1, W-BARRA2 OF W-DTMOVABE-I1. */
            _.Move("-", W_DATAS.W_DTMOVABE_I1.W_BARRA1_0);
            _.Move("-", W_DATAS.W_DTMOVABE_I1.W_BARRA2_0);


        }

        [StopWatch]
        /*" R0005-00-OBTER-DATA-DIA-DB-SELECT-1 */
        public void R0005_00_OBTER_DATA_DIA_DB_SELECT_1()
        {
            /*" -651- EXEC SQL SELECT DATA_MOV_ABERTO INTO :DCLSISTEMAS.SISTEMAS-DATA-MOV-ABERTO FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = :DCLSISTEMAS.SISTEMAS-IDE-SISTEMA WITH UR END-EXEC. */

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
            /*" -675- MOVE 'R0010-00-ABRIR-ARQUIVOS' TO PARAGRAFO. */
            _.Move("R0010-00-ABRIR-ARQUIVOS", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -677- MOVE 'OPEN' TO COMANDO. */
            _.Move("OPEN", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -678- OPEN INPUT MOV-STA-MR. */
            MOV_STA_MR.Open(REG_STA_MR, WREA88.WS_FILE_STATUS);

            /*" -679- IF WS-FILE-STATUS NOT EQUAL ZERO */

            if (WREA88.WS_FILE_STATUS != 00)
            {

                /*" -680- DISPLAY '**--------------------------------------**' */
                _.Display($"**--------------------------------------**");

                /*" -681- DISPLAY '** ERRO NA ABERTURA DO ARQUIVO DDN=STAMR**' */
                _.Display($"** ERRO NA ABERTURA DO ARQUIVO DDN=STAMR**");

                /*" -682- DISPLAY '** FILE STATUS = ' WS-FILE-STATUS */
                _.Display($"** FILE STATUS = {WREA88.WS_FILE_STATUS}");

                /*" -683- DISPLAY '** VERIFICAR ARQUIVO DE ENTRADA         **' */
                _.Display($"** VERIFICAR ARQUIVO DE ENTRADA         **");

                /*" -684- DISPLAY '**--------------------------------------**' */
                _.Display($"**--------------------------------------**");

                /*" -685- STOP RUN */

                throw new GoBack();   // => STOP RUN.

                /*" -687- END-IF. */
            }


            /*" -688- OPEN OUTPUT MOV-STA-CEF MOV-STA-FNAE. */
            MOV_STA_CEF.Open(REG_STA_CEF);
            MOV_STA_FNAE.Open(REG_STA_FNAE);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0010_SAIDA*/

        [StopWatch]
        /*" R0050-00-LER-MOV-MR-SECTION */
        private void R0050_00_LER_MOV_MR_SECTION()
        {
            /*" -698- MOVE 'R0050-00-LER-MOV-MR' TO PARAGRAFO. */
            _.Move("R0050-00-LER-MOV-MR", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -700- MOVE 'READ' TO COMANDO. */
            _.Move("READ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -701- READ MOV-STA-MR AT END */
            try
            {
                MOV_STA_MR.Read(() =>
                {

                    /*" -704- MOVE 'FIM' TO W-FIM-MOVTO-MR. */
                    _.Move("FIM", WAREA_AUXILIAR.W_FIM_MOVTO_MR);
                });

                _.Move(MOV_STA_MR.Value, REG_STA_MR);

            }
            catch (GoToException ex)
            {
                return;
            }
            /*" -705- IF REG-TIPO-REGISTRO-R EQUAL 'T' */

            if (REG_STA_MR.FILLER_0.REG_TIPO_REGISTRO_R == "T")
            {

                /*" -706- MOVE REG-STA-MR TO WS-REG-STA-MR */
                _.Move(MOV_STA_MR?.Value, WAREA_AUXILIAR.WS_REG_STA_MR);

                /*" -707- MOVE ZEROS TO REG-STA-MR */
                _.Move(0, REG_STA_MR);

                /*" -708- END-IF. */
            }


            /*" -709- IF W-FIM-MOVTO-MR EQUAL 'FIM' */

            if (WAREA_AUXILIAR.W_FIM_MOVTO_MR == "FIM")
            {

                /*" -710- MOVE WS-REG-STA-MR TO REG-STA-MR */
                _.Move(WAREA_AUXILIAR.WS_REG_STA_MR, REG_STA_MR);

                /*" -712- END-IF. */
            }


            /*" -714- IF W-FIM-MOVTO-MR NOT EQUAL 'FIM' */

            if (WAREA_AUXILIAR.W_FIM_MOVTO_MR != "FIM")
            {

                /*" -715- IF W-LIDO-MOVTO-MR EQUAL ZEROS */

                if (WAREA_AUXILIAR.W_LIDO_MOVTO_MR == 00)
                {

                    /*" -716- IF REG-TIPO-REGISTRO NOT EQUAL 'H' */

                    if (REG_STA_MR.REG_TIPO_REGISTRO != "H")
                    {

                        /*" -717- MOVE 'FIM' TO W-FIM-MOVTO-MR */
                        _.Move("FIM", WAREA_AUXILIAR.W_FIM_MOVTO_MR);

                        /*" -718- GO TO R0050-SAIDA */
                        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0050_SAIDA*/ //GOTO
                        return;

                        /*" -719- END-IF */
                    }


                    /*" -721- END-IF */
                }


                /*" -722- IF W-LIDO-MOVTO-MR EQUAL 1 */

                if (WAREA_AUXILIAR.W_LIDO_MOVTO_MR == 1)
                {

                    /*" -723- IF REG-TIPO-REGISTRO EQUAL 'T' */

                    if (REG_STA_MR.REG_TIPO_REGISTRO == "T")
                    {

                        /*" -724- MOVE 'FIM' TO W-FIM-MOVTO-MR */
                        _.Move("FIM", WAREA_AUXILIAR.W_FIM_MOVTO_MR);

                        /*" -725- GO TO R0050-SAIDA */
                        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0050_SAIDA*/ //GOTO
                        return;

                        /*" -726- END-IF */
                    }


                    /*" -728- END-IF */
                }


                /*" -731- ADD 1 TO W-LIDO-MOVTO-MR, W-AC-CONTROLE */
                WAREA_AUXILIAR.W_LIDO_MOVTO_MR.Value = WAREA_AUXILIAR.W_LIDO_MOVTO_MR + 1;
                WAREA_AUXILIAR.W_AC_CONTROLE.Value = WAREA_AUXILIAR.W_AC_CONTROLE + 1;

                /*" -732- IF REG-TIPO-REGISTRO EQUAL 'H' */

                if (REG_STA_MR.REG_TIPO_REGISTRO == "H")
                {

                    /*" -733- MOVE REG-STA-MR TO REG-HEADER-STA */
                    _.Move(MOV_STA_MR?.Value, LBFCT011.REG_HEADER_STA);

                    /*" -734- PERFORM R0100-00-VALIDAR-HEADER */

                    R0100_00_VALIDAR_HEADER_SECTION();

                    /*" -735- GO TO R0050-00-LER-MOV-MR */
                    new Task(() => R0050_00_LER_MOV_MR_SECTION()).RunSynchronously(); //GOTO
                    return;//Recursividade detectada, cuidado...

                    /*" -736- ELSE */
                }
                else
                {


                    /*" -737- IF REG-TIPO-REGISTRO EQUAL 'T' */

                    if (REG_STA_MR.REG_TIPO_REGISTRO == "T")
                    {

                        /*" -738- MOVE REG-STA-MR TO REG-TRAILLER-STA */
                        _.Move(MOV_STA_MR?.Value, LBFCT011.REG_TRAILLER_STA);

                        /*" -739- MOVE 'FIM' TO W-FIM-MOVTO-MR */
                        _.Move("FIM", WAREA_AUXILIAR.W_FIM_MOVTO_MR);

                        /*" -740- ELSE */
                    }
                    else
                    {


                        /*" -741- IF W-AC-CONTROLE GREATER 999 */

                        if (WAREA_AUXILIAR.W_AC_CONTROLE > 999)
                        {

                            /*" -742- ACCEPT WS-TIME FROM TIME */
                            _.Move(_.AcceptDate("TIME"), WS_TIME);

                            /*" -743- MOVE WS-TIME-N TO WS-TIME-EDIT */
                            _.Move(WS_TIME.WS_TIME_N, WS_TIME_EDIT);

                            /*" -744- DISPLAY ' ' */
                            _.Display($" ");

                            /*" -747- DISPLAY 'PF0711B - TOTAL LIDO ' W-LIDO-MOVTO-MR '  HORAS  ' WS-TIME-EDIT */

                            $"PF0711B - TOTAL LIDO {WAREA_AUXILIAR.W_LIDO_MOVTO_MR}  HORAS  {WS_TIME_EDIT}"
                            .Display();

                            /*" -747- MOVE ZEROS TO W-AC-CONTROLE. */
                            _.Move(0, WAREA_AUXILIAR.W_AC_CONTROLE);
                        }

                    }

                }

            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0050_SAIDA*/

        [StopWatch]
        /*" R0100-00-VALIDAR-HEADER-SECTION */
        private void R0100_00_VALIDAR_HEADER_SECTION()
        {
            /*" -757- MOVE 'R0100-00-VALIDAR-HEADER' TO PARAGRAFO. */
            _.Move("R0100-00-VALIDAR-HEADER", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -759- MOVE '    ' TO COMANDO. */
            _.Move("    ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -760- IF RH-TIPO-REG OF REG-HEADER-STA NOT EQUAL 'H' */

            if (LBFCT011.REG_HEADER_STA.RH_TIPO_REG != "H")
            {

                /*" -761- DISPLAY 'PF0711B - FIM ANORMAL' */
                _.Display($"PF0711B - FIM ANORMAL");

                /*" -762- DISPLAY '          MOVIMENTO NAO POSSUI HEADER ' */
                _.Display($"          MOVIMENTO NAO POSSUI HEADER ");

                /*" -764- DISPLAY '          NOME DO ARQUIVO...........  ' RH-NOME-EMPRESA OF REG-HEADER-STA */
                _.Display($"          NOME DO ARQUIVO...........  {LBFCT011.REG_HEADER_STA.RH_NOME_EMPRESA}");

                /*" -766- DISPLAY '          DATA GERACAO..............  ' RH-DATA-GERACAO OF REG-HEADER-STA */
                _.Display($"          DATA GERACAO..............  {LBFCT011.REG_HEADER_STA.RH_DATA_GERACAO}");

                /*" -767- PERFORM R9977-00-FECHAR-ARQUIVOS */

                R9977_00_FECHAR_ARQUIVOS_SECTION();

                /*" -769- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


            /*" -770- IF RH-NOME-EMPRESA OF REG-HEADER-STA NOT EQUAL 'STASASSE' */

            if (LBFCT011.REG_HEADER_STA.RH_NOME_EMPRESA != "STASASSE")
            {

                /*" -771- DISPLAY 'PF0711B - FIM ANORMAL' */
                _.Display($"PF0711B - FIM ANORMAL");

                /*" -772- DISPLAY '          HEADER INVALIDO' */
                _.Display($"          HEADER INVALIDO");

                /*" -774- DISPLAY '          NOME DO ARQUIVO...........  ' RH-NOME-EMPRESA OF REG-HEADER-STA */
                _.Display($"          NOME DO ARQUIVO...........  {LBFCT011.REG_HEADER_STA.RH_NOME_EMPRESA}");

                /*" -776- DISPLAY '          DATA GERACAO..............  ' RH-DATA-GERACAO OF REG-HEADER-STA */
                _.Display($"          DATA GERACAO..............  {LBFCT011.REG_HEADER_STA.RH_DATA_GERACAO}");

                /*" -777- PERFORM R9977-00-FECHAR-ARQUIVOS */

                R9977_00_FECHAR_ARQUIVOS_SECTION();

                /*" -779- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


            /*" -781- PERFORM R0110-00-VALIDAR-CONVENIO. */

            R0110_00_VALIDAR_CONVENIO_SECTION();

            /*" -782- IF RH-DATA-GERACAO OF REG-HEADER-STA NOT NUMERIC */

            if (!LBFCT011.REG_HEADER_STA.RH_DATA_GERACAO.IsNumeric())
            {

                /*" -783- DISPLAY 'PF0711B - FIM ANORMAL' */
                _.Display($"PF0711B - FIM ANORMAL");

                /*" -784- DISPLAY '          HEADER INVALIDO' */
                _.Display($"          HEADER INVALIDO");

                /*" -786- DISPLAY '          NOME DO ARQUIVO...........  ' RH-NOME-EMPRESA OF REG-HEADER-STA */
                _.Display($"          NOME DO ARQUIVO...........  {LBFCT011.REG_HEADER_STA.RH_NOME_EMPRESA}");

                /*" -788- DISPLAY '          DATA GERACAO..............  ' RH-DATA-GERACAO OF REG-HEADER-STA */
                _.Display($"          DATA GERACAO..............  {LBFCT011.REG_HEADER_STA.RH_DATA_GERACAO}");

                /*" -789- PERFORM R9977-00-FECHAR-ARQUIVOS */

                R9977_00_FECHAR_ARQUIVOS_SECTION();

                /*" -791- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


            /*" -792- IF RH-DATA-GERACAO OF REG-HEADER-STA EQUAL ZEROS */

            if (LBFCT011.REG_HEADER_STA.RH_DATA_GERACAO == 00)
            {

                /*" -793- DISPLAY 'PF0711B - FIM ANORMAL' */
                _.Display($"PF0711B - FIM ANORMAL");

                /*" -794- DISPLAY '          DATA GERACAO HEADER INVALIDA' */
                _.Display($"          DATA GERACAO HEADER INVALIDA");

                /*" -796- DISPLAY '          NOME DO ARQUIVO...........  ' RH-NOME-EMPRESA OF REG-HEADER-STA */
                _.Display($"          NOME DO ARQUIVO...........  {LBFCT011.REG_HEADER_STA.RH_NOME_EMPRESA}");

                /*" -798- DISPLAY '          DATA GERACAO..............  ' RH-DATA-GERACAO OF REG-HEADER-STA */
                _.Display($"          DATA GERACAO..............  {LBFCT011.REG_HEADER_STA.RH_DATA_GERACAO}");

                /*" -799- PERFORM R9977-00-FECHAR-ARQUIVOS */

                R9977_00_FECHAR_ARQUIVOS_SECTION();

                /*" -801- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


            /*" -802- IF RH-SIST-ORIGEM OF REG-HEADER-STA NOT EQUAL 4 */

            if (LBFCT011.REG_HEADER_STA.RH_SIST_ORIGEM != 4)
            {

                /*" -803- DISPLAY 'PF0711B - FIM ANORMAL' */
                _.Display($"PF0711B - FIM ANORMAL");

                /*" -804- DISPLAY '          HEADER INVALIDO' */
                _.Display($"          HEADER INVALIDO");

                /*" -805- DISPLAY '          SISTEMA ORIGEM INVALIDO  ' */
                _.Display($"          SISTEMA ORIGEM INVALIDO  ");

                /*" -807- DISPLAY '          NOME DO ARQUIVO...........  ' RH-NOME-EMPRESA OF REG-HEADER-STA */
                _.Display($"          NOME DO ARQUIVO...........  {LBFCT011.REG_HEADER_STA.RH_NOME_EMPRESA}");

                /*" -809- DISPLAY '          DATA GERACAO..............  ' RH-DATA-GERACAO OF REG-HEADER-STA */
                _.Display($"          DATA GERACAO..............  {LBFCT011.REG_HEADER_STA.RH_DATA_GERACAO}");

                /*" -811- DISPLAY '          SISTEMA ORIGEM............  ' RH-SIST-ORIGEM OF REG-HEADER-STA */
                _.Display($"          SISTEMA ORIGEM............  {LBFCT011.REG_HEADER_STA.RH_SIST_ORIGEM}");

                /*" -812- PERFORM R9977-00-FECHAR-ARQUIVOS */

                R9977_00_FECHAR_ARQUIVOS_SECTION();

                /*" -814- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


            /*" -816- PERFORM R0117-00-OBTER-NSAS-MOVTO */

            R0117_00_OBTER_NSAS_MOVTO_SECTION();

            /*" -817- IF RH-NSAS OF REG-HEADER-STA EQUAL ZEROS */

            if (LBFCT011.REG_HEADER_STA.RH_NSAS == 00)
            {

                /*" -818- DISPLAY 'PF0711B - FIM ANORMAL' */
                _.Display($"PF0711B - FIM ANORMAL");

                /*" -819- DISPLAY '          HEADER INVALIDO' */
                _.Display($"          HEADER INVALIDO");

                /*" -820- DISPLAY '          SEQUENCIAL DO ARQUIVO INVALIDO  ' */
                _.Display($"          SEQUENCIAL DO ARQUIVO INVALIDO  ");

                /*" -822- DISPLAY '          NOME DO ARQUIVO...........  ' RH-NOME-EMPRESA OF REG-HEADER-STA */
                _.Display($"          NOME DO ARQUIVO...........  {LBFCT011.REG_HEADER_STA.RH_NOME_EMPRESA}");

                /*" -824- DISPLAY '          DATA GERACAO..............  ' RH-DATA-GERACAO OF REG-HEADER-STA */
                _.Display($"          DATA GERACAO..............  {LBFCT011.REG_HEADER_STA.RH_DATA_GERACAO}");

                /*" -826- DISPLAY '          SISTEMA ORIGEM............  ' RH-SIST-ORIGEM OF REG-HEADER-STA */
                _.Display($"          SISTEMA ORIGEM............  {LBFCT011.REG_HEADER_STA.RH_SIST_ORIGEM}");

                /*" -827- PERFORM R9977-00-FECHAR-ARQUIVOS */

                R9977_00_FECHAR_ARQUIVOS_SECTION();

                /*" -827- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_SAIDA*/

        [StopWatch]
        /*" R0110-00-VALIDAR-CONVENIO-SECTION */
        private void R0110_00_VALIDAR_CONVENIO_SECTION()
        {
            /*" -837- MOVE 'R0110-00-VALIDAR-CONVENIO' TO PARAGRAFO. */
            _.Move("R0110-00-VALIDAR-CONVENIO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -839- MOVE 'SELECT CONVENIO_SIVPF' TO COMANDO. */
            _.Move("SELECT CONVENIO_SIVPF", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -842- MOVE 'STAMRISC' TO SIGLA-ARQUIVO OF DCLCONVENIO-SIVPF. */
            _.Move("STAMRISC", COVSIVPF.DCLCONVENIO_SIVPF.SIGLA_ARQUIVO);

            /*" -848- PERFORM R0110_00_VALIDAR_CONVENIO_DB_SELECT_1 */

            R0110_00_VALIDAR_CONVENIO_DB_SELECT_1();

            /*" -851- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -852- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -853- DISPLAY 'PF0711B - FIM ANORMAL' */
                    _.Display($"PF0711B - FIM ANORMAL");

                    /*" -854- DISPLAY '          CONVENIO NAO CADASTRADO' */
                    _.Display($"          CONVENIO NAO CADASTRADO");

                    /*" -856- DISPLAY '          CODIGO CONVENIO..... ' SIGLA-ARQUIVO OF DCLCONVENIO-SIVPF */
                    _.Display($"          CODIGO CONVENIO..... {COVSIVPF.DCLCONVENIO_SIVPF.SIGLA_ARQUIVO}");

                    /*" -857- DISPLAY ' ' */
                    _.Display($" ");

                    /*" -859- DISPLAY '          NOME ARQUIVO........ ' RH-NOME-EMPRESA OF REG-HEADER-STA */
                    _.Display($"          NOME ARQUIVO........ {LBFCT011.REG_HEADER_STA.RH_NOME_EMPRESA}");

                    /*" -861- DISPLAY '          DATA GERACAO........ ' RH-DATA-GERACAO OF REG-HEADER-STA */
                    _.Display($"          DATA GERACAO........ {LBFCT011.REG_HEADER_STA.RH_DATA_GERACAO}");

                    /*" -863- DISPLAY '          SISTEMA ORIGEM...... ' RH-SIST-ORIGEM OF REG-HEADER-STA */
                    _.Display($"          SISTEMA ORIGEM...... {LBFCT011.REG_HEADER_STA.RH_SIST_ORIGEM}");

                    /*" -865- DISPLAY '          SISTEMA DESTINO..... ' RH-SIST-DESTINO OF REG-HEADER-STA */
                    _.Display($"          SISTEMA DESTINO..... {LBFCT011.REG_HEADER_STA.RH_SIST_DESTINO}");

                    /*" -867- DISPLAY '          NSAS................ ' RH-NSAS OF REG-HEADER-STA */
                    _.Display($"          NSAS................ {LBFCT011.REG_HEADER_STA.RH_NSAS}");

                    /*" -868- PERFORM R9977-00-FECHAR-ARQUIVOS */

                    R9977_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -869- PERFORM R9999-00-FINALIZAR */

                    R9999_00_FINALIZAR_SECTION();

                    /*" -870- ELSE */
                }
                else
                {


                    /*" -871- DISPLAY 'PF0711B - FIM ANORMAL' */
                    _.Display($"PF0711B - FIM ANORMAL");

                    /*" -872- DISPLAY '          PROBLEMAS ACESSO CONVENIO-SIVPF' */
                    _.Display($"          PROBLEMAS ACESSO CONVENIO-SIVPF");

                    /*" -874- DISPLAY '          CODIGO CONVENIO..... ' SIGLA-ARQUIVO OF DCLCONVENIO-SIVPF */
                    _.Display($"          CODIGO CONVENIO..... {COVSIVPF.DCLCONVENIO_SIVPF.SIGLA_ARQUIVO}");

                    /*" -875- DISPLAY ' ' */
                    _.Display($" ");

                    /*" -877- DISPLAY '          NOME ARQUIVO........ ' RH-NOME-EMPRESA OF REG-HEADER-STA */
                    _.Display($"          NOME ARQUIVO........ {LBFCT011.REG_HEADER_STA.RH_NOME_EMPRESA}");

                    /*" -879- DISPLAY '          DATA GERACAO........ ' RH-DATA-GERACAO OF REG-HEADER-STA */
                    _.Display($"          DATA GERACAO........ {LBFCT011.REG_HEADER_STA.RH_DATA_GERACAO}");

                    /*" -881- DISPLAY '          SISTEMA ORIGEM...... ' RH-SIST-ORIGEM OF REG-HEADER-STA */
                    _.Display($"          SISTEMA ORIGEM...... {LBFCT011.REG_HEADER_STA.RH_SIST_ORIGEM}");

                    /*" -883- DISPLAY '          SISTEMA DESTINO..... ' RH-SIST-DESTINO OF REG-HEADER-STA */
                    _.Display($"          SISTEMA DESTINO..... {LBFCT011.REG_HEADER_STA.RH_SIST_DESTINO}");

                    /*" -885- DISPLAY '          NSAS................ ' RH-NSAS OF REG-HEADER-STA */
                    _.Display($"          NSAS................ {LBFCT011.REG_HEADER_STA.RH_NSAS}");

                    /*" -887- DISPLAY '          SQLCODE............. ' SQLCODE */
                    _.Display($"          SQLCODE............. {DB.SQLCODE}");

                    /*" -888- PERFORM R9977-00-FECHAR-ARQUIVOS */

                    R9977_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -888- PERFORM R9999-00-FINALIZAR. */

                    R9999_00_FINALIZAR_SECTION();
                }

            }


        }

        [StopWatch]
        /*" R0110-00-VALIDAR-CONVENIO-DB-SELECT-1 */
        public void R0110_00_VALIDAR_CONVENIO_DB_SELECT_1()
        {
            /*" -848- EXEC SQL SELECT DESCR_ARQUIVO INTO :DCLCONVENIO-SIVPF.DESCR-ARQUIVO FROM SEGUROS.CONVENIO_SIVPF WHERE SIGLA_ARQUIVO = :DCLCONVENIO-SIVPF.SIGLA-ARQUIVO WITH UR END-EXEC. */

            var r0110_00_VALIDAR_CONVENIO_DB_SELECT_1_Query1 = new R0110_00_VALIDAR_CONVENIO_DB_SELECT_1_Query1()
            {
                SIGLA_ARQUIVO = COVSIVPF.DCLCONVENIO_SIVPF.SIGLA_ARQUIVO.ToString(),
            };

            var executed_1 = R0110_00_VALIDAR_CONVENIO_DB_SELECT_1_Query1.Execute(r0110_00_VALIDAR_CONVENIO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.DESCR_ARQUIVO, COVSIVPF.DCLCONVENIO_SIVPF.DESCR_ARQUIVO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0110_SAIDA*/

        [StopWatch]
        /*" R0117-00-OBTER-NSAS-MOVTO-SECTION */
        private void R0117_00_OBTER_NSAS_MOVTO_SECTION()
        {
            /*" -898- MOVE 'R0117-00-OBTER-NSAS-MOVTO' TO PARAGRAFO. */
            _.Move("R0117-00-OBTER-NSAS-MOVTO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -900- MOVE 'SELECT COUNT ARQUIVOS-SIVPF' TO COMANDO. */
            _.Move("SELECT COUNT ARQUIVOS-SIVPF", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -903- MOVE 'STAMRISC' TO ARQSIVPF-SIGLA-ARQUIVO OF DCLARQUIVOS-SIVPF. */
            _.Move("STAMRISC", ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SIGLA_ARQUIVO);

            /*" -906- MOVE RH-SIST-ORIGEM OF REG-HEADER-STA TO ARQSIVPF-SISTEMA-ORIGEM OF DCLARQUIVOS-SIVPF. */
            _.Move(LBFCT011.REG_HEADER_STA.RH_SIST_ORIGEM, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SISTEMA_ORIGEM);

            /*" -915- PERFORM R0117_00_OBTER_NSAS_MOVTO_DB_SELECT_1 */

            R0117_00_OBTER_NSAS_MOVTO_DB_SELECT_1();

            /*" -918- IF SQLCODE EQUAL 00 */

            if (DB.SQLCODE == 00)
            {

                /*" -921- MOVE ARQSIVPF-NSAS-SIVPF OF DCLARQUIVOS-SIVPF TO W-NSAS-MR */
                _.Move(ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF, WAREA_AUXILIAR.W_NSAS_MR);

                /*" -924- COMPUTE W-NSAS-MR = W-NSAS-MR + 1 */
                WAREA_AUXILIAR.W_NSAS_MR.Value = WAREA_AUXILIAR.W_NSAS_MR + 1;

                /*" -925- MOVE W-NSAS-MR TO RH-NSAS OF REG-HEADER-STA */
                _.Move(WAREA_AUXILIAR.W_NSAS_MR, LBFCT011.REG_HEADER_STA.RH_NSAS);

                /*" -926- ELSE */
            }
            else
            {


                /*" -927- DISPLAY 'PF0711B - FIM ANORMAL' */
                _.Display($"PF0711B - FIM ANORMAL");

                /*" -929- DISPLAY '          ERRO ACESSO TABELA ARQUIVOS-SIVPF ' SQLCODE */
                _.Display($"          ERRO ACESSO TABELA ARQUIVOS-SIVPF {DB.SQLCODE}");

                /*" -931- DISPLAY '          SIGLA DO ARQUIVO................. ' ARQSIVPF-NSAS-SIVPF OF DCLARQUIVOS-SIVPF */
                _.Display($"          SIGLA DO ARQUIVO................. {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF}");

                /*" -932- PERFORM R9977-00-FECHAR-ARQUIVOS */

                R9977_00_FECHAR_ARQUIVOS_SECTION();

                /*" -932- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R0117-00-OBTER-NSAS-MOVTO-DB-SELECT-1 */
        public void R0117_00_OBTER_NSAS_MOVTO_DB_SELECT_1()
        {
            /*" -915- EXEC SQL SELECT VALUE(MAX(NSAS_SIVPF),0) INTO :DCLARQUIVOS-SIVPF.ARQSIVPF-NSAS-SIVPF FROM SEGUROS.ARQUIVOS_SIVPF WHERE SIGLA_ARQUIVO = :DCLARQUIVOS-SIVPF.ARQSIVPF-SIGLA-ARQUIVO AND SISTEMA_ORIGEM = :DCLARQUIVOS-SIVPF.ARQSIVPF-SISTEMA-ORIGEM WITH UR END-EXEC. */

            var r0117_00_OBTER_NSAS_MOVTO_DB_SELECT_1_Query1 = new R0117_00_OBTER_NSAS_MOVTO_DB_SELECT_1_Query1()
            {
                ARQSIVPF_SISTEMA_ORIGEM = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SISTEMA_ORIGEM.ToString(),
                ARQSIVPF_SIGLA_ARQUIVO = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SIGLA_ARQUIVO.ToString(),
            };

            var executed_1 = R0117_00_OBTER_NSAS_MOVTO_DB_SELECT_1_Query1.Execute(r0117_00_OBTER_NSAS_MOVTO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.ARQSIVPF_NSAS_SIVPF, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0117_SAIDA*/

        [StopWatch]
        /*" R0200-00-PROCESSAR-MOVIMENTO-SECTION */
        private void R0200_00_PROCESSAR_MOVIMENTO_SECTION()
        {
            /*" -942- MOVE 'R0200-00-PROCESSA-MOVIMENTO' TO PARAGRAFO. */
            _.Move("R0200-00-PROCESSA-MOVIMENTO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -944- MOVE '    ' TO COMANDO. */
            _.Move("    ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -948- PERFORM R0250-00-TRATA-EMPRESA UNTIL W-FIM-MOVTO-MR EQUAL 'FIM' OR REG-TIPO-REGISTRO OF REG-STA-MR EQUAL 'T' . */

            while (!(WAREA_AUXILIAR.W_FIM_MOVTO_MR == "FIM" || REG_STA_MR.REG_TIPO_REGISTRO == "T"))
            {

                R0250_00_TRATA_EMPRESA_SECTION();
            }

            /*" -948- PERFORM R2100-00-TB-CONTROLE. */

            R2100_00_TB_CONTROLE_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_SAIDA*/

        [StopWatch]
        /*" R0250-00-TRATA-EMPRESA-SECTION */
        private void R0250_00_TRATA_EMPRESA_SECTION()
        {
            /*" -959- MOVE 'R0250-00-TRATA-EMPRESA' TO PARAGRAFO. */
            _.Move("R0250-00-TRATA-EMPRESA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -960- IF CONT-SIDEM GREATER ZEROS */

            if (CONT_SIDEM > 00)
            {

                /*" -961- MOVE 1 TO S-I */
                _.Move(1, S_I);

                /*" -963- PERFORM R0261-IMPRIME-REG-SIDEM UNTIL S-I GREATER CONT-SIDEM */

                while (!(S_I > CONT_SIDEM))
                {

                    R0261_IMPRIME_REG_SIDEM_SECTION();
                }

                /*" -965- END-IF. */
            }


            /*" -966- IF REG-NUM-PROPOSTA IS NOT NUMERIC */

            if (!REG_STA_MR.REG_NUM_PROPOSTA.IsNumeric())
            {

                /*" -968- DISPLAY 'PF0711B - NUMERO PROPOSTA..... ' REG-NUM-PROPOSTA */
                _.Display($"PF0711B - NUMERO PROPOSTA..... {REG_STA_MR.REG_NUM_PROPOSTA}");

                /*" -969- GO TO R0250-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0250_SAIDA*/ //GOTO
                return;

                /*" -971- END-IF. */
            }


            /*" -972- MOVE REG-NUM-PROPOSTA TO W-NUM-PROPOSTA-ANT. */
            _.Move(REG_STA_MR.REG_NUM_PROPOSTA, WAREA_AUXILIAR.W_NUM_PROPOSTA_ANT);

            /*" -974- MOVE REG-TIPO-REGISTRO TO W-TIPO-REG-AUX-ANT. */
            _.Move(REG_STA_MR.REG_TIPO_REGISTRO, WAREA_AUXILIAR.W_TIPO_REG_AUX_ANT);

            /*" -980- INITIALIZE REGISTRO-ENDOSSOS REG-STA-PROPOSTA REG-APOL-SASSE REG-PGTO-SASSE R8-PONTUACAO-SIDEM. */
            _.Initialize(
                LBFCT000.REGISTRO_ENDOSSOS
                , LBFCT011.REG_STA_PROPOSTA
                , LBFCT016.REG_APOL_SASSE
                , LBFCT016.REG_PGTO_SASSE
                , LBFPF025.R8_PONTUACAO_SIDEM
            );

            /*" -983- MOVE ZEROS TO W-INDICE-3, W-INDICE-4. */
            _.Move(0, WAREA_AUXILIAR.W_INDICE_3, WAREA_AUXILIAR.W_INDICE_4);

            /*" -993- MOVE ZERO TO W-LEU-PRP-FIDELIZ , W-REGISTRO-ENDOSSO , W-REGISTRO-APOLICE , W-REGISTRO-PROPOSTA , W-REGISTRO-COBERTURA, W-REGISTRO-PAGAMENTO, S-I , CONT-SIDEM , W-REGISTRO-SIDEM-BL-33. */
            _.Move(0, WREA88.W_LEU_PRP_FIDELIZ, WREA88.W_REGISTRO_ENDOSSO, WREA88.W_REGISTRO_APOLICE, WREA88.W_REGISTRO_PROPOSTA, WREA88.W_REGISTRO_COBERTURA, WREA88.W_REGISTRO_PAGAMENTO, S_I, CONT_SIDEM, WREA88.W_REGISTRO_SIDEM_BL_33);

            /*" -999- PERFORM R0260-00-TRATA-MOVIMENTO UNTIL W-FIM-MOVTO-MR EQUAL 'FIM' OR REG-TIPO-REGISTRO EQUAL 'T' OR REG-NUM-PROPOSTA NOT EQUAL W-NUM-PROPOSTA-ANT OR REG-TIPO-REGISTRO NOT EQUAL W-TIPO-REG-AUX-ANT. */

            while (!(WAREA_AUXILIAR.W_FIM_MOVTO_MR == "FIM" || REG_STA_MR.REG_TIPO_REGISTRO == "T" || REG_STA_MR.REG_NUM_PROPOSTA != WAREA_AUXILIAR.W_NUM_PROPOSTA_ANT || REG_STA_MR.REG_TIPO_REGISTRO != WAREA_AUXILIAR.W_TIPO_REG_AUX_ANT))
            {

                R0260_00_TRATA_MOVIMENTO_SECTION();
            }

            /*" -1000- IF NOT TEM-PROPOSTA-FIDELIZ */

            if (!WREA88.W_EXISTE_FIDELIZ["TEM_PROPOSTA_FIDELIZ"])
            {

                /*" -1003- GO TO R0250-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0250_SAIDA*/ //GOTO
                return;
            }


            /*" -1005- IF TEM-REGISTRO-PROPOSTA */

            if (WREA88.W_REGISTRO_PROPOSTA["TEM_REGISTRO_PROPOSTA"])
            {

                /*" -1007- PERFORM R0280-00-LER-HIST-FIDELIZ */

                R0280_00_LER_HIST_FIDELIZ_SECTION();

                /*" -1009- IF HISTORICO-CADASTRADO */

                if (WREA88.W_HISTORICO["HISTORICO_CADASTRADO"])
                {

                    /*" -1011- MOVE ZEROS TO CONT-SIDEM */
                    _.Move(0, CONT_SIDEM);

                    /*" -1013- ADD 1 TO W-QTD-ST-MR-1 */
                    WAREA_AUXILIAR.W_QTD_ST_MR_1.Value = WAREA_AUXILIAR.W_QTD_ST_MR_1 + 1;

                    /*" -1015- ADD 1 TO W-INDICE-1 */
                    WAREA_AUXILIAR.W_INDICE_1.Value = WAREA_AUXILIAR.W_INDICE_1 + 1;

                    /*" -1016- IF W-INDICE-1 >= 29999 */

                    if (WAREA_AUXILIAR.W_INDICE_1 >= 29999)
                    {

                        /*" -1017- DISPLAY 'PF0711B - FIM ANORMAL' */
                        _.Display($"PF0711B - FIM ANORMAL");

                        /*" -1018- DISPLAY '          ESTOURO DA TABELA DE ERROS - 1' */
                        _.Display($"          ESTOURO DA TABELA DE ERROS - 1");

                        /*" -1019- PERFORM R9977-00-FECHAR-ARQUIVOS */

                        R9977_00_FECHAR_ARQUIVOS_SECTION();

                        /*" -1020- PERFORM R9999-00-FINALIZAR */

                        R9999_00_FINALIZAR_SECTION();

                        /*" -1022- END-IF */
                    }


                    /*" -1023- MOVE R1-NUM-PROPOSTA TO W-TB-NUM-PROPOSTA(W-INDICE-1) */
                    _.Move(LBFCT011.REG_STA_PROPOSTA.R1_NUM_PROPOSTA, AREA_DAS_TABELAS.W_TAB_CONSISTENCIA.FILLER_44[WAREA_AUXILIAR.W_INDICE_1].W_TB_NUM_PROPOSTA);

                    /*" -1024- MOVE R1-SIT-PROPOSTA TO W-TB-SIT-PROPOSTA(W-INDICE-1) */
                    _.Move(LBFCT011.REG_STA_PROPOSTA.R1_SIT_PROPOSTA, AREA_DAS_TABELAS.W_TAB_CONSISTENCIA.FILLER_44[WAREA_AUXILIAR.W_INDICE_1].W_TB_SIT_PROPOSTA);

                    /*" -1025- MOVE R1-DATA-SITUACAO TO W-TB-DT-SITUACAO (W-INDICE-1) */
                    _.Move(LBFCT011.REG_STA_PROPOSTA.R1_DATA_SITUACAO, AREA_DAS_TABELAS.W_TAB_CONSISTENCIA.FILLER_44[WAREA_AUXILIAR.W_INDICE_1].W_TB_DT_SITUACAO);

                    /*" -1027- MOVE 2 TO W-TB-COD-DESCRI (W-INDICE-1) */
                    _.Move(2, AREA_DAS_TABELAS.W_TAB_CONSISTENCIA.FILLER_44[WAREA_AUXILIAR.W_INDICE_1].W_TB_COD_DESCRI);

                    /*" -1030- GO TO R0250-SAIDA. */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0250_SAIDA*/ //GOTO
                    return;
                }

            }


            /*" -1031- IF HDSTA-NAO-GERADO */

            if (WREA88.W_HEADER_STA_CEF["HDSTA_NAO_GERADO"])
            {

                /*" -1032- PERFORM R0450-00-OBTER-NSAS-MOV-CEF */

                R0450_00_OBTER_NSAS_MOV_CEF_SECTION();

                /*" -1035- PERFORM R0460-00-GERAR-HEADER. */

                R0460_00_GERAR_HEADER_SECTION();
            }


            /*" -1037- IF TEM-REGISTRO-ENDOSSO */

            if (WREA88.W_REGISTRO_ENDOSSO["TEM_REGISTRO_ENDOSSO"])
            {

                /*" -1039- MOVE SPACES TO REG-STA-CEF */
                _.Move("", REG_STA_CEF);

                /*" -1041- ADD 1 TO W-QTD-LD-MR-0 */
                WAREA_AUXILIAR.W_QTD_LD_MR_0.Value = WAREA_AUXILIAR.W_QTD_LD_MR_0 + 1;

                /*" -1045- MOVE REGISTRO-ENDOSSOS TO REG-STA-CEF REG-STA-FNAE W-REG-SAIDA */
                _.Move(LBFCT000.REGISTRO_ENDOSSOS, REG_STA_CEF, REG_STA_FNAE, W_DATAS.W_REG_SAIDA);

                /*" -1047- WRITE REG-STA-FNAE */
                MOV_STA_FNAE.Write(REG_STA_FNAE.GetMoveValues().ToString());

                /*" -1049- IF WSD-NUM-PROPOSTA > 101400000000 AND WSD-NUM-PROPOSTA < 101499999999 */

                if (W_DATAS.FILLER_6.WSD_NUM_PROPOSTA > 101400000000 && W_DATAS.FILLER_6.WSD_NUM_PROPOSTA < 101499999999)
                {

                    /*" -1050- MOVE WSD-NUM-PROPOSTA TO WNUM-PROP-13 */
                    _.Move(W_DATAS.FILLER_6.WSD_NUM_PROPOSTA, W_DATAS.FILLER_5.WNUM_PROP_13);

                    /*" -1051- MOVE ZEROS TO WDIG-PROP */
                    _.Move(0, W_DATAS.FILLER_5.WDIG_PROP);

                    /*" -1052- MOVE W-NUM-PROPOSTA TO WSD-NUM-PROPOSTA */
                    _.Move(W_DATAS.W_NUM_PROPOSTA, W_DATAS.FILLER_6.WSD_NUM_PROPOSTA);

                    /*" -1053- END-IF */
                }


                /*" -1054- MOVE W-REG-SAIDA TO REG-STA-CEF */
                _.Move(W_DATAS.W_REG_SAIDA, REG_STA_CEF);

                /*" -1055- IF REG-STA-CEF NOT EQUAL SPACES */

                if (!REG_STA_CEF.IsEmpty())
                {

                    /*" -1057- WRITE REG-STA-CEF. */
                    MOV_STA_CEF.Write(REG_STA_CEF.GetMoveValues().ToString());
                }

            }


            /*" -1059- IF TEM-REGISTRO-PROPOSTA */

            if (WREA88.W_REGISTRO_PROPOSTA["TEM_REGISTRO_PROPOSTA"])
            {

                /*" -1061- MOVE SPACES TO REG-STA-CEF */
                _.Move("", REG_STA_CEF);

                /*" -1063- ADD 1 TO W-QTD-PC-MR-1 */
                WAREA_AUXILIAR.W_QTD_PC_MR_1.Value = WAREA_AUXILIAR.W_QTD_PC_MR_1 + 1;

                /*" -1065- ADD 1 TO W-TOT-PC-MR */
                WAREA_AUXILIAR.W_TOT_PC_MR.Value = WAREA_AUXILIAR.W_TOT_PC_MR + 1;

                /*" -1068- MOVE W-RH-NSAS OF W-REG-HEADER TO R1-NSAS, NSAS-SIVPF OF DCLPROPOSTA-FIDELIZ */
                _.Move(W_REG_HEADER.W_RH_NSAS, LBFCT011.REG_STA_PROPOSTA.R1_NSAS, PROPFID.DCLPROPOSTA_FIDELIZ.NSAS_SIVPF);

                /*" -1071- MOVE W-TOT-PC-MR TO R1-NSL, NSL OF DCLPROPOSTA-FIDELIZ */
                _.Move(WAREA_AUXILIAR.W_TOT_PC_MR, LBFCT011.REG_STA_PROPOSTA.R1_NSL, PROPFID.DCLPROPOSTA_FIDELIZ.NSL);

                /*" -1073- PERFORM R0254-00-TESTAR-SIT-PROPOSTA */

                R0254_00_TESTAR_SIT_PROPOSTA_SECTION();

                /*" -1075- MOVE 'PF0711B' TO COD-USUARIO OF DCLPROPOSTA-FIDELIZ */
                _.Move("PF0711B", PROPFID.DCLPROPOSTA_FIDELIZ.COD_USUARIO);

                /*" -1077- MOVE 'R' TO SITUACAO-ENVIO OF DCLPROPOSTA-FIDELIZ */
                _.Move("R", PROPFID.DCLPROPOSTA_FIDELIZ.SITUACAO_ENVIO);

                /*" -1079- MOVE REG-STA-PROPOSTA TO REG-STA-CEF */
                _.Move(LBFCT011.REG_STA_PROPOSTA, REG_STA_CEF);

                /*" -1081- PERFORM R0300-00-ATUALIZAR-PRP-FIDELIZ */

                R0300_00_ATUALIZAR_PRP_FIDELIZ_SECTION();

                /*" -1084- MOVE NUM-IDENTIFICACAO OF DCLPROPOSTA-FIDELIZ TO PROPFIDH-NUM-IDENTIFICACAO. */
                _.Move(PROPFID.DCLPROPOSTA_FIDELIZ.NUM_IDENTIFICACAO, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NUM_IDENTIFICACAO);
            }


            /*" -1087- MOVE NSAS-SIVPF OF DCLPROPOSTA-FIDELIZ TO PROPFIDH-NSAS-SIVPF. */
            _.Move(PROPFID.DCLPROPOSTA_FIDELIZ.NSAS_SIVPF, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NSAS_SIVPF);

            /*" -1090- MOVE NSL OF DCLPROPOSTA-FIDELIZ TO PROPFIDH-NSL. */
            _.Move(PROPFID.DCLPROPOSTA_FIDELIZ.NSL, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NSL);

            /*" -1093- MOVE R1-SIT-PROPOSTA TO PROPFIDH-SIT-PROPOSTA. */
            _.Move(LBFCT011.REG_STA_PROPOSTA.R1_SIT_PROPOSTA, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_PROPOSTA);

            /*" -1096- MOVE R1-SIT-MOTIVO TO PROPFIDH-SIT-MOTIVO-SIVPF. */
            _.Move(LBFCT011.REG_STA_PROPOSTA.R1_SIT_MOTIVO, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_MOTIVO_SIVPF);

            /*" -1098- MOVE R1-DATA-SITUACAO TO W-DATA-TRABALHO */
            _.Move(LBFCT011.REG_STA_PROPOSTA.R1_DATA_SITUACAO, W_DATAS.W_DATA_TRABALHO);

            /*" -1099- IF W-DATA-TRABALHO EQUAL ZEROS */

            if (W_DATAS.W_DATA_TRABALHO == 00)
            {

                /*" -1100- MOVE 01 TO W-DIA-TRABALHO */
                _.Move(01, W_DATAS.FILLER_4.W_DIA_TRABALHO);

                /*" -1101- MOVE 01 TO W-MES-TRABALHO */
                _.Move(01, W_DATAS.FILLER_4.W_MES_TRABALHO);

                /*" -1102- MOVE 0001 TO W-ANO-TRABALHO */
                _.Move(0001, W_DATAS.FILLER_4.W_ANO_TRABALHO);

                /*" -1104- END-IF */
            }


            /*" -1105- MOVE W-DIA-TRABALHO TO W-DIA-SQL OF W-DATA-SQL1 */
            _.Move(W_DATAS.FILLER_4.W_DIA_TRABALHO, W_DATAS.W_DATA_SQL1.W_DIA_SQL);

            /*" -1106- MOVE W-MES-TRABALHO TO W-MES-SQL OF W-DATA-SQL1 */
            _.Move(W_DATAS.FILLER_4.W_MES_TRABALHO, W_DATAS.W_DATA_SQL1.W_MES_SQL);

            /*" -1107- MOVE W-ANO-TRABALHO TO W-ANO-SQL OF W-DATA-SQL1 */
            _.Move(W_DATAS.FILLER_4.W_ANO_TRABALHO, W_DATAS.W_DATA_SQL1.W_ANO_SQL);

            /*" -1109- MOVE '-' TO W-BARRA1 OF W-DATA-SQL1 W-BARRA2 OF W-DATA-SQL1 */
            _.Move("-", W_DATAS.W_DATA_SQL1.W_BARRA1_1);
            _.Move("-", W_DATAS.W_DATA_SQL1.W_BARRA2_1);


            /*" -1112- MOVE W-DATA-SQL TO PROPFIDH-DATA-SITUACAO. */
            _.Move(W_DATAS.W_DATA_SQL, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_DATA_SITUACAO);

            /*" -1115- MOVE 1 TO PROPFIDH-COD-EMPRESA-SIVPF. */
            _.Move(1, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_COD_EMPRESA_SIVPF);

            /*" -1118- MOVE COD-PRODUTO-SIVPF OF DCLPROPOSTA-FIDELIZ TO PROPFIDH-COD-PRODUTO-SIVPF. */
            _.Move(PROPFID.DCLPROPOSTA_FIDELIZ.COD_PRODUTO_SIVPF, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_COD_PRODUTO_SIVPF);

            /*" -1120- PERFORM R0350-00-GERAR-HIST-FIDELIZ. */

            R0350_00_GERAR_HIST_FIDELIZ_SECTION();

            /*" -1122- IF PROPFIDH-SIT-PROPOSTA OF DCLHIST-PROP-FIDELIZ EQUAL 'END' */

            if (PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_PROPOSTA == "END")
            {

                /*" -1123- MOVE R2-DTTERVIG TO W-DATA-TRABALHO */
                _.Move(LBFCT016.REG_APOL_SASSE.R2_DTTERVIG, W_DATAS.W_DATA_TRABALHO);

                /*" -1124- MOVE W-DIA-TRABALHO TO W-DIA-SQL OF W-DATA-SQL1 */
                _.Move(W_DATAS.FILLER_4.W_DIA_TRABALHO, W_DATAS.W_DATA_SQL1.W_DIA_SQL);

                /*" -1125- MOVE W-MES-TRABALHO TO W-MES-SQL OF W-DATA-SQL1 */
                _.Move(W_DATAS.FILLER_4.W_MES_TRABALHO, W_DATAS.W_DATA_SQL1.W_MES_SQL);

                /*" -1126- MOVE W-ANO-TRABALHO TO W-ANO-SQL OF W-DATA-SQL1 */
                _.Move(W_DATAS.FILLER_4.W_ANO_TRABALHO, W_DATAS.W_DATA_SQL1.W_ANO_SQL);

                /*" -1129- MOVE '-' TO W-BARRA1 OF W-DATA-SQL1 W-BARRA2 OF W-DATA-SQL1 */
                _.Move("-", W_DATAS.W_DATA_SQL1.W_BARRA1_1);
                _.Move("-", W_DATAS.W_DATA_SQL1.W_BARRA2_1);


                /*" -1131- IF PROPFIDH-DATA-SITUACAO OF DCLHIST-PROP-FIDELIZ > W-DATA-SQL */

                if (PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_DATA_SITUACAO > W_DATAS.W_DATA_SQL)
                {

                    /*" -1132- SUBTRACT 1 FROM W-QTD-PC-MR-1 */
                    WAREA_AUXILIAR.W_QTD_PC_MR_1.Value = WAREA_AUXILIAR.W_QTD_PC_MR_1 - 1;

                    /*" -1133- ELSE */
                }
                else
                {


                    /*" -1135- MOVE REG-STA-CEF TO REG-STA-FNAE W-REG-SAIDA */
                    _.Move(MOV_STA_CEF?.Value, REG_STA_FNAE, W_DATAS.W_REG_SAIDA);

                    /*" -1137- WRITE REG-STA-FNAE */
                    MOV_STA_FNAE.Write(REG_STA_FNAE.GetMoveValues().ToString());

                    /*" -1139- IF WSD-NUM-PROPOSTA > 101400000000 AND WSD-NUM-PROPOSTA < 101499999999 */

                    if (W_DATAS.FILLER_6.WSD_NUM_PROPOSTA > 101400000000 && W_DATAS.FILLER_6.WSD_NUM_PROPOSTA < 101499999999)
                    {

                        /*" -1140- MOVE WSD-NUM-PROPOSTA TO WNUM-PROP-13 */
                        _.Move(W_DATAS.FILLER_6.WSD_NUM_PROPOSTA, W_DATAS.FILLER_5.WNUM_PROP_13);

                        /*" -1141- MOVE ZEROS TO WDIG-PROP */
                        _.Move(0, W_DATAS.FILLER_5.WDIG_PROP);

                        /*" -1142- MOVE W-NUM-PROPOSTA TO WSD-NUM-PROPOSTA */
                        _.Move(W_DATAS.W_NUM_PROPOSTA, W_DATAS.FILLER_6.WSD_NUM_PROPOSTA);

                        /*" -1143- END-IF */
                    }


                    /*" -1145- MOVE W-REG-SAIDA TO REG-STA-CEF */
                    _.Move(W_DATAS.W_REG_SAIDA, REG_STA_CEF);

                    /*" -1146- IF REG-STA-CEF NOT EQUAL SPACES */

                    if (!REG_STA_CEF.IsEmpty())
                    {

                        /*" -1147- WRITE REG-STA-CEF */
                        MOV_STA_CEF.Write(REG_STA_CEF.GetMoveValues().ToString());

                        /*" -1148- ELSE */
                    }
                    else
                    {


                        /*" -1150- MOVE REG-STA-CEF TO REG-STA-FNAE W-REG-SAIDA */
                        _.Move(MOV_STA_CEF?.Value, REG_STA_FNAE, W_DATAS.W_REG_SAIDA);

                        /*" -1152- WRITE REG-STA-FNAE */
                        MOV_STA_FNAE.Write(REG_STA_FNAE.GetMoveValues().ToString());

                        /*" -1154- IF WSD-NUM-PROPOSTA > 101400000000 AND WSD-NUM-PROPOSTA < 101499999999 */

                        if (W_DATAS.FILLER_6.WSD_NUM_PROPOSTA > 101400000000 && W_DATAS.FILLER_6.WSD_NUM_PROPOSTA < 101499999999)
                        {

                            /*" -1155- MOVE WSD-NUM-PROPOSTA TO WNUM-PROP-13 */
                            _.Move(W_DATAS.FILLER_6.WSD_NUM_PROPOSTA, W_DATAS.FILLER_5.WNUM_PROP_13);

                            /*" -1156- MOVE ZEROS TO WDIG-PROP */
                            _.Move(0, W_DATAS.FILLER_5.WDIG_PROP);

                            /*" -1157- MOVE W-NUM-PROPOSTA TO WSD-NUM-PROPOSTA */
                            _.Move(W_DATAS.W_NUM_PROPOSTA, W_DATAS.FILLER_6.WSD_NUM_PROPOSTA);

                            /*" -1158- END-IF */
                        }


                        /*" -1161- MOVE W-REG-SAIDA TO REG-STA-CEF */
                        _.Move(W_DATAS.W_REG_SAIDA, REG_STA_CEF);

                        /*" -1162- WRITE REG-STA-CEF */
                        MOV_STA_CEF.Write(REG_STA_CEF.GetMoveValues().ToString());

                        /*" -1164- END-IF. */
                    }

                }

            }


            /*" -1166- IF TEM-REGISTRO-APOLICE */

            if (WREA88.W_REGISTRO_APOLICE["TEM_REGISTRO_APOLICE"])
            {

                /*" -1168- MOVE SPACES TO REG-STA-CEF */
                _.Move("", REG_STA_CEF);

                /*" -1172- ADD 1 TO W-QTD-LD-MR-2 */
                WAREA_AUXILIAR.W_QTD_LD_MR_2.Value = WAREA_AUXILIAR.W_QTD_LD_MR_2 + 1;

                /*" -1175- MOVE R2-VAL-IOF TO VAL-IOF OF DCLPROPOSTA-FIDELIZ */
                _.Move(LBFCT016.REG_APOL_SASSE.R2_VAL_IOF, PROPFID.DCLPROPOSTA_FIDELIZ.VAL_IOF);

                /*" -1176- IF R2-VAL-IOF GREATER ZEROS */

                if (LBFCT016.REG_APOL_SASSE.R2_VAL_IOF > 00)
                {

                    /*" -1177- PERFORM R0330-00-ATUALIZAR-IOF */

                    R0330_00_ATUALIZAR_IOF_SECTION();

                    /*" -1179- END-IF */
                }


                /*" -1183- MOVE REG-APOL-SASSE TO REG-STA-CEF REG-STA-FNAE W-REG-SAIDA */
                _.Move(LBFCT016.REG_APOL_SASSE, REG_STA_CEF, REG_STA_FNAE, W_DATAS.W_REG_SAIDA);

                /*" -1185- WRITE REG-STA-FNAE */
                MOV_STA_FNAE.Write(REG_STA_FNAE.GetMoveValues().ToString());

                /*" -1187- IF WSD-NUM-PROPOSTA > 101400000000 AND WSD-NUM-PROPOSTA < 101499999999 */

                if (W_DATAS.FILLER_6.WSD_NUM_PROPOSTA > 101400000000 && W_DATAS.FILLER_6.WSD_NUM_PROPOSTA < 101499999999)
                {

                    /*" -1188- MOVE WSD-NUM-PROPOSTA TO WNUM-PROP-13 */
                    _.Move(W_DATAS.FILLER_6.WSD_NUM_PROPOSTA, W_DATAS.FILLER_5.WNUM_PROP_13);

                    /*" -1189- MOVE ZEROS TO WDIG-PROP */
                    _.Move(0, W_DATAS.FILLER_5.WDIG_PROP);

                    /*" -1190- MOVE W-NUM-PROPOSTA TO WSD-NUM-PROPOSTA */
                    _.Move(W_DATAS.W_NUM_PROPOSTA, W_DATAS.FILLER_6.WSD_NUM_PROPOSTA);

                    /*" -1191- END-IF */
                }


                /*" -1193- MOVE W-REG-SAIDA TO REG-STA-CEF */
                _.Move(W_DATAS.W_REG_SAIDA, REG_STA_CEF);

                /*" -1194- IF REG-STA-CEF NOT EQUAL SPACES */

                if (!REG_STA_CEF.IsEmpty())
                {

                    /*" -1197- WRITE REG-STA-CEF. */
                    MOV_STA_CEF.Write(REG_STA_CEF.GetMoveValues().ToString());
                }

            }


            /*" -1199- IF TEM-REGISTRO-COBERTURA */

            if (WREA88.W_REGISTRO_COBERTURA["TEM_REGISTRO_COBERTURA"])
            {

                /*" -1201- ADD 1 TO W-INDICE-4 */
                WAREA_AUXILIAR.W_INDICE_4.Value = WAREA_AUXILIAR.W_INDICE_4 + 1;

                /*" -1205- PERFORM R0255-00-GERAR-COBERTURA UNTIL W-INDICE-4 GREATER W-INDICE-3. */

                while (!(WAREA_AUXILIAR.W_INDICE_4 > WAREA_AUXILIAR.W_INDICE_3))
                {

                    R0255_00_GERAR_COBERTURA_SECTION();
                }
            }


            /*" -1207- IF TEM-REGISTRO-PAGAMENTO */

            if (WREA88.W_REGISTRO_PAGAMENTO["TEM_REGISTRO_PAGAMENTO"])
            {

                /*" -1211- ADD 1 TO W-QTD-LD-MR-4 */
                WAREA_AUXILIAR.W_QTD_LD_MR_4.Value = WAREA_AUXILIAR.W_QTD_LD_MR_4 + 1;

                /*" -1212- IF R4-SIT-COBRANCA EQUAL 'ATZ' */

                if (LBFCT016.REG_PGTO_SASSE.R4_SIT_COBRANCA == "ATZ")
                {

                    /*" -1213- PERFORM R0256-00-PARCELA-EM-ATRASO */

                    R0256_00_PARCELA_EM_ATRASO_SECTION();

                    /*" -1215- END-IF */
                }


                /*" -1216- IF R4-SIT-COBRANCA EQUAL 'BXA' */

                if (LBFCT016.REG_PGTO_SASSE.R4_SIT_COBRANCA == "BXA")
                {

                    /*" -1217- PERFORM R0257-00-PARCELA-EM-DIA */

                    R0257_00_PARCELA_EM_DIA_SECTION();

                    /*" -1219- END-IF */
                }


                /*" -1223- MOVE REG-PGTO-SASSE TO REG-STA-CEF REG-STA-FNAE W-REG-SAIDA */
                _.Move(LBFCT016.REG_PGTO_SASSE, REG_STA_CEF, REG_STA_FNAE, W_DATAS.W_REG_SAIDA);

                /*" -1225- WRITE REG-STA-FNAE */
                MOV_STA_FNAE.Write(REG_STA_FNAE.GetMoveValues().ToString());

                /*" -1227- IF WSD-NUM-PROPOSTA > 101400000000 AND WSD-NUM-PROPOSTA < 101499999999 */

                if (W_DATAS.FILLER_6.WSD_NUM_PROPOSTA > 101400000000 && W_DATAS.FILLER_6.WSD_NUM_PROPOSTA < 101499999999)
                {

                    /*" -1228- MOVE WSD-NUM-PROPOSTA TO WNUM-PROP-13 */
                    _.Move(W_DATAS.FILLER_6.WSD_NUM_PROPOSTA, W_DATAS.FILLER_5.WNUM_PROP_13);

                    /*" -1229- MOVE ZEROS TO WDIG-PROP */
                    _.Move(0, W_DATAS.FILLER_5.WDIG_PROP);

                    /*" -1230- MOVE W-NUM-PROPOSTA TO WSD-NUM-PROPOSTA */
                    _.Move(W_DATAS.W_NUM_PROPOSTA, W_DATAS.FILLER_6.WSD_NUM_PROPOSTA);

                    /*" -1231- END-IF */
                }


                /*" -1233- MOVE W-REG-SAIDA TO REG-STA-CEF */
                _.Move(W_DATAS.W_REG_SAIDA, REG_STA_CEF);

                /*" -1234- IF REG-STA-CEF NOT EQUAL SPACES */

                if (!REG_STA_CEF.IsEmpty())
                {

                    /*" -1236- WRITE REG-STA-CEF. */
                    MOV_STA_CEF.Write(REG_STA_CEF.GetMoveValues().ToString());
                }

            }


            /*" -1238- IF TEM-REGISTRO-SIDEM-BL-33 */

            if (WREA88.W_REGISTRO_SIDEM_BL_33["TEM_REGISTRO_SIDEM_BL_33"])
            {

                /*" -1243- ADD 1 TO W-QTD-LD-MR-8 */
                WAREA_AUXILIAR.W_QTD_LD_MR_8.Value = WAREA_AUXILIAR.W_QTD_LD_MR_8 + 1;

                /*" -1251- GO TO R0250-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0250_SAIDA*/ //GOTO
                return;
            }


            /*" -1256- IF DTQITBCO OF DCLPROPOSTA-FIDELIZ = '0001-01-01' OR DATA-CREDITO OF DCLPROPOSTA-FIDELIZ = '0001-01-01' OR VAL-PAGO OF DCLPROPOSTA-FIDELIZ = ZEROS OR AGEPGTO OF DCLPROPOSTA-FIDELIZ = ZEROS NEXT SENTENCE */

            if (PROPFID.DCLPROPOSTA_FIDELIZ.DTQITBCO == "0001-01-01" || PROPFID.DCLPROPOSTA_FIDELIZ.DATA_CREDITO == "0001-01-01" || PROPFID.DCLPROPOSTA_FIDELIZ.VAL_PAGO == 00 || PROPFID.DCLPROPOSTA_FIDELIZ.AGEPGTO == 00)
            {

                /*" -1257- ELSE */
            }
            else
            {


                /*" -1259- GO TO R0250-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0250_SAIDA*/ //GOTO
                return;
            }


            /*" -1261- PERFORM R0763-00-LER-RCAP. */

            R0763_00_LER_RCAP_SECTION();

            /*" -1262- IF RCAP-NAO-CADASTRADO */

            if (WREA88.W_LEITURA_RCAP["RCAP_NAO_CADASTRADO"])
            {

                /*" -1264- GO TO R0250-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0250_SAIDA*/ //GOTO
                return;
            }


            /*" -1266- MOVE 2 TO W-UPDATE-PROPOSTA. */
            _.Move(2, WREA88.W_UPDATE_PROPOSTA);

            /*" -1267- IF DTQITBCO OF DCLPROPOSTA-FIDELIZ EQUAL '0001-01-01' */

            if (PROPFID.DCLPROPOSTA_FIDELIZ.DTQITBCO == "0001-01-01")
            {

                /*" -1268- MOVE 1 TO W-UPDATE-PROPOSTA */
                _.Move(1, WREA88.W_UPDATE_PROPOSTA);

                /*" -1271- MOVE RCAPS-DATA-CADASTRAMENTO OF DCLRCAPS TO DTQITBCO OF DCLPROPOSTA-FIDELIZ. */
                _.Move(RCAPS.DCLRCAPS.RCAPS_DATA_CADASTRAMENTO, PROPFID.DCLPROPOSTA_FIDELIZ.DTQITBCO);
            }


            /*" -1272- IF DATA-CREDITO OF DCLPROPOSTA-FIDELIZ EQUAL '0001-01-01' */

            if (PROPFID.DCLPROPOSTA_FIDELIZ.DATA_CREDITO == "0001-01-01")
            {

                /*" -1273- MOVE 1 TO W-UPDATE-PROPOSTA */
                _.Move(1, WREA88.W_UPDATE_PROPOSTA);

                /*" -1276- MOVE RCAPS-DATA-MOVIMENTO OF DCLRCAPS TO DATA-CREDITO OF DCLPROPOSTA-FIDELIZ. */
                _.Move(RCAPS.DCLRCAPS.RCAPS_DATA_MOVIMENTO, PROPFID.DCLPROPOSTA_FIDELIZ.DATA_CREDITO);
            }


            /*" -1277- IF VAL-PAGO OF DCLPROPOSTA-FIDELIZ EQUAL ZEROS */

            if (PROPFID.DCLPROPOSTA_FIDELIZ.VAL_PAGO == 00)
            {

                /*" -1278- MOVE 1 TO W-UPDATE-PROPOSTA */
                _.Move(1, WREA88.W_UPDATE_PROPOSTA);

                /*" -1281- MOVE RCAPS-VAL-RCAP OF DCLRCAPS TO VAL-PAGO OF DCLPROPOSTA-FIDELIZ. */
                _.Move(RCAPS.DCLRCAPS.RCAPS_VAL_RCAP, PROPFID.DCLPROPOSTA_FIDELIZ.VAL_PAGO);
            }


            /*" -1282- IF AGEPGTO OF DCLPROPOSTA-FIDELIZ EQUAL ZEROS */

            if (PROPFID.DCLPROPOSTA_FIDELIZ.AGEPGTO == 00)
            {

                /*" -1283- IF RCAPS-AGE-COBRANCA OF DCLRCAPS GREATER ZEROS */

                if (RCAPS.DCLRCAPS.RCAPS_AGE_COBRANCA > 00)
                {

                    /*" -1284- MOVE 1 TO W-UPDATE-PROPOSTA */
                    _.Move(1, WREA88.W_UPDATE_PROPOSTA);

                    /*" -1287- MOVE RCAPS-AGE-COBRANCA OF DCLRCAPS TO AGEPGTO OF DCLPROPOSTA-FIDELIZ. */
                    _.Move(RCAPS.DCLRCAPS.RCAPS_AGE_COBRANCA, PROPFID.DCLPROPOSTA_FIDELIZ.AGEPGTO);
                }

            }


            /*" -1288- IF ATUALIZAR-PROPOSTA */

            if (WREA88.W_UPDATE_PROPOSTA["ATUALIZAR_PROPOSTA"])
            {

                /*" -1300- PERFORM R0250_00_TRATA_EMPRESA_DB_UPDATE_1 */

                R0250_00_TRATA_EMPRESA_DB_UPDATE_1();

                /*" -1303- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -1304- DISPLAY 'PF0711B - FIM ANORMAL' */
                    _.Display($"PF0711B - FIM ANORMAL");

                    /*" -1305- DISPLAY '          ERRO UPDATE PROPOSTA  ' SQLCODE */
                    _.Display($"          ERRO UPDATE PROPOSTA  {DB.SQLCODE}");

                    /*" -1307- DISPLAY '          NUMERO PROPOSTA       ' NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ */
                    _.Display($"          NUMERO PROPOSTA       {PROPFID.DCLPROPOSTA_FIDELIZ.NUM_PROPOSTA_SIVPF}");

                    /*" -1308- PERFORM R9977-00-FECHAR-ARQUIVOS */

                    R9977_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -1309- PERFORM R9999-00-FINALIZAR */

                    R9999_00_FINALIZAR_SECTION();

                    /*" -1309- END-IF. */
                }

            }


        }

        [StopWatch]
        /*" R0250-00-TRATA-EMPRESA-DB-UPDATE-1 */
        public void R0250_00_TRATA_EMPRESA_DB_UPDATE_1()
        {
            /*" -1300- EXEC SQL UPDATE SEGUROS.PROPOSTA_FIDELIZ SET DTQITBCO = :DCLPROPOSTA-FIDELIZ.DTQITBCO , VAL_PAGO = :DCLPROPOSTA-FIDELIZ.VAL-PAGO , AGEPGTO = :DCLPROPOSTA-FIDELIZ.AGEPGTO , DATA_CREDITO = :DCLPROPOSTA-FIDELIZ.DATA-CREDITO WHERE NUM_PROPOSTA_SIVPF = :DCLPROPOSTA-FIDELIZ.NUM-PROPOSTA-SIVPF END-EXEC */

            var r0250_00_TRATA_EMPRESA_DB_UPDATE_1_Update1 = new R0250_00_TRATA_EMPRESA_DB_UPDATE_1_Update1()
            {
                DATA_CREDITO = PROPFID.DCLPROPOSTA_FIDELIZ.DATA_CREDITO.ToString(),
                DTQITBCO = PROPFID.DCLPROPOSTA_FIDELIZ.DTQITBCO.ToString(),
                VAL_PAGO = PROPFID.DCLPROPOSTA_FIDELIZ.VAL_PAGO.ToString(),
                AGEPGTO = PROPFID.DCLPROPOSTA_FIDELIZ.AGEPGTO.ToString(),
                NUM_PROPOSTA_SIVPF = PROPFID.DCLPROPOSTA_FIDELIZ.NUM_PROPOSTA_SIVPF.ToString(),
            };

            R0250_00_TRATA_EMPRESA_DB_UPDATE_1_Update1.Execute(r0250_00_TRATA_EMPRESA_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0250_SAIDA*/

        [StopWatch]
        /*" R0254-00-TESTAR-SIT-PROPOSTA-SECTION */
        private void R0254_00_TESTAR_SIT_PROPOSTA_SECTION()
        {
            /*" -1317- MOVE 'R0254-00-TESTAR-SIT-PROPOSTA' TO PARAGRAFO. */
            _.Move("R0254-00-TESTAR-SIT-PROPOSTA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1319- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1321- IF R1-SIT-PROPOSTA EQUAL 'NRE' OR 'ALT' NEXT SENTENCE */

            if (LBFCT011.REG_STA_PROPOSTA.R1_SIT_PROPOSTA.In("NRE", "ALT"))
            {

                /*" -1322- ELSE */
            }
            else
            {


                /*" -1323- IF R1-SIT-PROPOSTA EQUAL 'END' OR 'RTV' */

                if (LBFCT011.REG_STA_PROPOSTA.R1_SIT_PROPOSTA.In("END", "RTV"))
                {

                    /*" -1324- IF ORIGEM-PROPOSTA OF DCLPROPOSTA-FIDELIZ = 6 */

                    if (PROPFID.DCLPROPOSTA_FIDELIZ.ORIGEM_PROPOSTA == 6)
                    {

                        /*" -1326- MOVE 'MAN' TO SIT-PROPOSTA OF DCLPROPOSTA-FIDELIZ */
                        _.Move("MAN", PROPFID.DCLPROPOSTA_FIDELIZ.SIT_PROPOSTA);

                        /*" -1327- ELSE */
                    }
                    else
                    {


                        /*" -1329- MOVE 'EMT' TO SIT-PROPOSTA OF DCLPROPOSTA-FIDELIZ */
                        _.Move("EMT", PROPFID.DCLPROPOSTA_FIDELIZ.SIT_PROPOSTA);

                        /*" -1330- ELSE */
                    }

                }
                else
                {


                    /*" -1331- IF R1-SIT-PROPOSTA EQUAL 'EMT' */

                    if (LBFCT011.REG_STA_PROPOSTA.R1_SIT_PROPOSTA == "EMT")
                    {

                        /*" -1332- IF ORIGEM-PROPOSTA OF DCLPROPOSTA-FIDELIZ = 6 */

                        if (PROPFID.DCLPROPOSTA_FIDELIZ.ORIGEM_PROPOSTA == 6)
                        {

                            /*" -1334- MOVE 'MAN' TO SIT-PROPOSTA OF DCLPROPOSTA-FIDELIZ */
                            _.Move("MAN", PROPFID.DCLPROPOSTA_FIDELIZ.SIT_PROPOSTA);

                            /*" -1335- ELSE */
                        }
                        else
                        {


                            /*" -1337- MOVE R1-SIT-PROPOSTA TO SIT-PROPOSTA OF DCLPROPOSTA-FIDELIZ */
                            _.Move(LBFCT011.REG_STA_PROPOSTA.R1_SIT_PROPOSTA, PROPFID.DCLPROPOSTA_FIDELIZ.SIT_PROPOSTA);

                            /*" -1338- ELSE */
                        }

                    }
                    else
                    {


                        /*" -1341- MOVE R1-SIT-PROPOSTA TO SIT-PROPOSTA OF DCLPROPOSTA-FIDELIZ. */
                        _.Move(LBFCT011.REG_STA_PROPOSTA.R1_SIT_PROPOSTA, PROPFID.DCLPROPOSTA_FIDELIZ.SIT_PROPOSTA);
                    }

                }

            }


            /*" -1342- IF TEM-REGISTRO-PAGAMENTO */

            if (WREA88.W_REGISTRO_PAGAMENTO["TEM_REGISTRO_PAGAMENTO"])
            {

                /*" -1345- MOVE R4-SIT-COBRANCA TO PROPFIDH-SIT-COBRANCA-SIVPF OF DCLHIST-PROP-FIDELIZ */
                _.Move(LBFCT016.REG_PGTO_SASSE.R4_SIT_COBRANCA, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_COBRANCA_SIVPF);

                /*" -1346- ELSE */
            }
            else
            {


                /*" -1347- IF R1-SIT-PROPOSTA EQUAL 'ANA' */

                if (LBFCT011.REG_STA_PROPOSTA.R1_SIT_PROPOSTA == "ANA")
                {

                    /*" -1349- MOVE 'PAG' TO PROPFIDH-SIT-COBRANCA-SIVPF OF DCLHIST-PROP-FIDELIZ. */
                    _.Move("PAG", PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_COBRANCA_SIVPF);
                }

            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0254_SAIDA*/

        [StopWatch]
        /*" R0255-00-GERAR-COBERTURA-SECTION */
        private void R0255_00_GERAR_COBERTURA_SECTION()
        {
            /*" -1359- MOVE 'R0255-00-GERAR-COBERTURA' TO PARAGRAFO. */
            _.Move("R0255-00-GERAR-COBERTURA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1361- MOVE 'WRITE' TO COMANDO. */
            _.Move("WRITE", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1365- ADD 1 TO W-QTD-LD-MR-3 */
            WAREA_AUXILIAR.W_QTD_LD_MR_3.Value = WAREA_AUXILIAR.W_QTD_LD_MR_3 + 1;

            /*" -1367- MOVE SPACES TO REG-STA-CEF */
            _.Move("", REG_STA_CEF);

            /*" -1371- MOVE W-TB-REGISTRO-COBERTURA(W-INDICE-4) TO REG-STA-CEF REG-STA-FNAE W-REG-SAIDA */
            _.Move(AREA_DAS_TABELAS.W_TAB_COBERTURA.FILLER_47[WAREA_AUXILIAR.W_INDICE_4].W_TB_REGISTRO_COBERTURA, REG_STA_CEF, REG_STA_FNAE, W_DATAS.W_REG_SAIDA);

            /*" -1373- WRITE REG-STA-FNAE */
            MOV_STA_FNAE.Write(REG_STA_FNAE.GetMoveValues().ToString());

            /*" -1375- IF WSD-NUM-PROPOSTA > 101400000000 AND WSD-NUM-PROPOSTA < 101499999999 */

            if (W_DATAS.FILLER_6.WSD_NUM_PROPOSTA > 101400000000 && W_DATAS.FILLER_6.WSD_NUM_PROPOSTA < 101499999999)
            {

                /*" -1376- MOVE WSD-NUM-PROPOSTA TO WNUM-PROP-13 */
                _.Move(W_DATAS.FILLER_6.WSD_NUM_PROPOSTA, W_DATAS.FILLER_5.WNUM_PROP_13);

                /*" -1377- MOVE ZEROS TO WDIG-PROP */
                _.Move(0, W_DATAS.FILLER_5.WDIG_PROP);

                /*" -1378- MOVE W-NUM-PROPOSTA TO WSD-NUM-PROPOSTA */
                _.Move(W_DATAS.W_NUM_PROPOSTA, W_DATAS.FILLER_6.WSD_NUM_PROPOSTA);

                /*" -1379- END-IF */
            }


            /*" -1381- MOVE W-REG-SAIDA TO REG-STA-CEF */
            _.Move(W_DATAS.W_REG_SAIDA, REG_STA_CEF);

            /*" -1382- IF REG-STA-CEF NOT EQUAL SPACES */

            if (!REG_STA_CEF.IsEmpty())
            {

                /*" -1384- WRITE REG-STA-CEF. */
                MOV_STA_CEF.Write(REG_STA_CEF.GetMoveValues().ToString());
            }


            /*" -1384- ADD 1 TO W-INDICE-4. */
            WAREA_AUXILIAR.W_INDICE_4.Value = WAREA_AUXILIAR.W_INDICE_4 + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0255_SAIDA*/

        [StopWatch]
        /*" R0256-00-PARCELA-EM-ATRASO-SECTION */
        private void R0256_00_PARCELA_EM_ATRASO_SECTION()
        {
            /*" -1395- MOVE 'R0256-00-PARCELA-EM-ATRASO' TO PARAGRAFO. */
            _.Move("R0256-00-PARCELA-EM-ATRASO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1397- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1400- MOVE W-RH-NSAS OF W-REG-HEADER TO R1-NSAS, NSAS-SIVPF OF DCLPROPOSTA-FIDELIZ */
            _.Move(W_REG_HEADER.W_RH_NSAS, LBFCT011.REG_STA_PROPOSTA.R1_NSAS, PROPFID.DCLPROPOSTA_FIDELIZ.NSAS_SIVPF);

            /*" -1403- MOVE W-TOT-PC-MR TO R1-NSL, NSL OF DCLPROPOSTA-FIDELIZ */
            _.Move(WAREA_AUXILIAR.W_TOT_PC_MR, LBFCT011.REG_STA_PROPOSTA.R1_NSL, PROPFID.DCLPROPOSTA_FIDELIZ.NSL);

            /*" -1406- MOVE 'PF0711B' TO COD-USUARIO OF DCLPROPOSTA-FIDELIZ */
            _.Move("PF0711B", PROPFID.DCLPROPOSTA_FIDELIZ.COD_USUARIO);

            /*" -1408- MOVE 'ATR' TO R4-SIT-COBRANCA */
            _.Move("ATR", LBFCT016.REG_PGTO_SASSE.R4_SIT_COBRANCA);

            /*" -1410- MOVE 'R' TO SITUACAO-ENVIO OF DCLPROPOSTA-FIDELIZ */
            _.Move("R", PROPFID.DCLPROPOSTA_FIDELIZ.SITUACAO_ENVIO);

            /*" -1412- PERFORM R0300-00-ATUALIZAR-PRP-FIDELIZ */

            R0300_00_ATUALIZAR_PRP_FIDELIZ_SECTION();

            /*" -1415- MOVE NUM-IDENTIFICACAO OF DCLPROPOSTA-FIDELIZ TO PROPFIDH-NUM-IDENTIFICACAO OF DCLHIST-PROP-FIDELIZ */
            _.Move(PROPFID.DCLPROPOSTA_FIDELIZ.NUM_IDENTIFICACAO, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NUM_IDENTIFICACAO);

            /*" -1417- MOVE R4-DATA-SITUACAO TO W-DATA-TRABALHO */
            _.Move(LBFCT016.REG_PGTO_SASSE.R4_DATA_SITUACAO, W_DATAS.W_DATA_TRABALHO);

            /*" -1418- MOVE W-DIA-TRABALHO TO W-DIA-SQL OF W-DATA-SQL1 */
            _.Move(W_DATAS.FILLER_4.W_DIA_TRABALHO, W_DATAS.W_DATA_SQL1.W_DIA_SQL);

            /*" -1419- MOVE W-MES-TRABALHO TO W-MES-SQL OF W-DATA-SQL1 */
            _.Move(W_DATAS.FILLER_4.W_MES_TRABALHO, W_DATAS.W_DATA_SQL1.W_MES_SQL);

            /*" -1420- MOVE W-ANO-TRABALHO TO W-ANO-SQL OF W-DATA-SQL1 */
            _.Move(W_DATAS.FILLER_4.W_ANO_TRABALHO, W_DATAS.W_DATA_SQL1.W_ANO_SQL);

            /*" -1423- MOVE '-' TO W-BARRA1 OF W-DATA-SQL1, W-BARRA2 OF W-DATA-SQL1 */
            _.Move("-", W_DATAS.W_DATA_SQL1.W_BARRA1_1);
            _.Move("-", W_DATAS.W_DATA_SQL1.W_BARRA2_1);


            /*" -1426- MOVE W-DATA-SQL TO PROPFIDH-DATA-SITUACAO OF DCLHIST-PROP-FIDELIZ */
            _.Move(W_DATAS.W_DATA_SQL, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_DATA_SITUACAO);

            /*" -1429- MOVE NSAS-SIVPF OF DCLPROPOSTA-FIDELIZ TO PROPFIDH-NSAS-SIVPF OF DCLHIST-PROP-FIDELIZ */
            _.Move(PROPFID.DCLPROPOSTA_FIDELIZ.NSAS_SIVPF, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NSAS_SIVPF);

            /*" -1432- MOVE NSL OF DCLPROPOSTA-FIDELIZ TO PROPFIDH-NSL OF DCLHIST-PROP-FIDELIZ */
            _.Move(PROPFID.DCLPROPOSTA_FIDELIZ.NSL, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NSL);

            /*" -1435- MOVE 'EMT' TO PROPFIDH-SIT-PROPOSTA OF DCLHIST-PROP-FIDELIZ */
            _.Move("EMT", PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_PROPOSTA);

            /*" -1438- MOVE 'ATR' TO PROPFIDH-SIT-COBRANCA-SIVPF OF DCLHIST-PROP-FIDELIZ */
            _.Move("ATR", PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_COBRANCA_SIVPF);

            /*" -1441- MOVE 100 TO PROPFIDH-SIT-MOTIVO-SIVPF OF DCLHIST-PROP-FIDELIZ. */
            _.Move(100, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_MOTIVO_SIVPF);

            /*" -1441- PERFORM R0350-00-GERAR-HIST-FIDELIZ. */

            R0350_00_GERAR_HIST_FIDELIZ_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0256_SAIDA*/

        [StopWatch]
        /*" R0257-00-PARCELA-EM-DIA-SECTION */
        private void R0257_00_PARCELA_EM_DIA_SECTION()
        {
            /*" -1452- MOVE 'R0257-00-PARCELA-EM-DIA' TO PARAGRAFO. */
            _.Move("R0257-00-PARCELA-EM-DIA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1454- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1457- MOVE W-RH-NSAS OF W-REG-HEADER TO R1-NSAS, NSAS-SIVPF OF DCLPROPOSTA-FIDELIZ */
            _.Move(W_REG_HEADER.W_RH_NSAS, LBFCT011.REG_STA_PROPOSTA.R1_NSAS, PROPFID.DCLPROPOSTA_FIDELIZ.NSAS_SIVPF);

            /*" -1460- MOVE W-TOT-PC-MR TO R1-NSL, NSL OF DCLPROPOSTA-FIDELIZ */
            _.Move(WAREA_AUXILIAR.W_TOT_PC_MR, LBFCT011.REG_STA_PROPOSTA.R1_NSL, PROPFID.DCLPROPOSTA_FIDELIZ.NSL);

            /*" -1463- MOVE 'PF0711B' TO COD-USUARIO OF DCLPROPOSTA-FIDELIZ */
            _.Move("PF0711B", PROPFID.DCLPROPOSTA_FIDELIZ.COD_USUARIO);

            /*" -1465- MOVE 'PAG' TO R4-SIT-COBRANCA */
            _.Move("PAG", LBFCT016.REG_PGTO_SASSE.R4_SIT_COBRANCA);

            /*" -1467- MOVE 'R' TO SITUACAO-ENVIO OF DCLPROPOSTA-FIDELIZ */
            _.Move("R", PROPFID.DCLPROPOSTA_FIDELIZ.SITUACAO_ENVIO);

            /*" -1469- PERFORM R0300-00-ATUALIZAR-PRP-FIDELIZ */

            R0300_00_ATUALIZAR_PRP_FIDELIZ_SECTION();

            /*" -1472- MOVE NUM-IDENTIFICACAO OF DCLPROPOSTA-FIDELIZ TO PROPFIDH-NUM-IDENTIFICACAO OF DCLHIST-PROP-FIDELIZ */
            _.Move(PROPFID.DCLPROPOSTA_FIDELIZ.NUM_IDENTIFICACAO, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NUM_IDENTIFICACAO);

            /*" -1474- MOVE R4-DATA-SITUACAO TO W-DATA-TRABALHO */
            _.Move(LBFCT016.REG_PGTO_SASSE.R4_DATA_SITUACAO, W_DATAS.W_DATA_TRABALHO);

            /*" -1475- MOVE W-DIA-TRABALHO TO W-DIA-SQL OF W-DATA-SQL1 */
            _.Move(W_DATAS.FILLER_4.W_DIA_TRABALHO, W_DATAS.W_DATA_SQL1.W_DIA_SQL);

            /*" -1476- MOVE W-MES-TRABALHO TO W-MES-SQL OF W-DATA-SQL1 */
            _.Move(W_DATAS.FILLER_4.W_MES_TRABALHO, W_DATAS.W_DATA_SQL1.W_MES_SQL);

            /*" -1477- MOVE W-ANO-TRABALHO TO W-ANO-SQL OF W-DATA-SQL1 */
            _.Move(W_DATAS.FILLER_4.W_ANO_TRABALHO, W_DATAS.W_DATA_SQL1.W_ANO_SQL);

            /*" -1480- MOVE '-' TO W-BARRA1 OF W-DATA-SQL1, W-BARRA2 OF W-DATA-SQL1 */
            _.Move("-", W_DATAS.W_DATA_SQL1.W_BARRA1_1);
            _.Move("-", W_DATAS.W_DATA_SQL1.W_BARRA2_1);


            /*" -1483- MOVE W-DATA-SQL TO PROPFIDH-DATA-SITUACAO OF DCLHIST-PROP-FIDELIZ */
            _.Move(W_DATAS.W_DATA_SQL, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_DATA_SITUACAO);

            /*" -1486- MOVE NSAS-SIVPF OF DCLPROPOSTA-FIDELIZ TO PROPFIDH-NSAS-SIVPF OF DCLHIST-PROP-FIDELIZ */
            _.Move(PROPFID.DCLPROPOSTA_FIDELIZ.NSAS_SIVPF, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NSAS_SIVPF);

            /*" -1489- MOVE NSL OF DCLPROPOSTA-FIDELIZ TO PROPFIDH-NSL OF DCLHIST-PROP-FIDELIZ */
            _.Move(PROPFID.DCLPROPOSTA_FIDELIZ.NSL, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NSL);

            /*" -1492- MOVE 'EMT' TO PROPFIDH-SIT-PROPOSTA OF DCLHIST-PROP-FIDELIZ */
            _.Move("EMT", PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_PROPOSTA);

            /*" -1495- MOVE 'PAG' TO PROPFIDH-SIT-COBRANCA-SIVPF OF DCLHIST-PROP-FIDELIZ */
            _.Move("PAG", PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_COBRANCA_SIVPF);

            /*" -1498- MOVE 000 TO PROPFIDH-SIT-MOTIVO-SIVPF OF DCLHIST-PROP-FIDELIZ. */
            _.Move(000, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_MOTIVO_SIVPF);

            /*" -1498- PERFORM R0350-00-GERAR-HIST-FIDELIZ. */

            R0350_00_GERAR_HIST_FIDELIZ_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0257_SAIDA*/

        [StopWatch]
        /*" R0260-00-TRATA-MOVIMENTO-SECTION */
        private void R0260_00_TRATA_MOVIMENTO_SECTION()
        {
            /*" -1508- MOVE 'R0260-00-TRATA-MOVIMENTO' TO PARAGRAFO. */
            _.Move("R0260-00-TRATA-MOVIMENTO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1510- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1512- MOVE REG-TIPO-REGISTRO-R TO W-TIPO-REG-ANT. */
            _.Move(REG_STA_MR.FILLER_0.REG_TIPO_REGISTRO_R, WAREA_AUXILIAR.W_TIPO_REG_ANT);

            /*" -1514- MOVE REG-TIPO-REGISTRO TO W-TIPO-MOVIMENTO. */
            _.Move(REG_STA_MR.REG_TIPO_REGISTRO, WREA88.W_TIPO_MOVIMENTO);

            /*" -1516- IF NAO-LEU-PROPOSTA */

            if (WREA88.W_LEU_PRP_FIDELIZ["NAO_LEU_PROPOSTA"])
            {

                /*" -1518- MOVE 1 TO W-LEU-PRP-FIDELIZ */
                _.Move(1, WREA88.W_LEU_PRP_FIDELIZ);

                /*" -1520- PERFORM R0270-00-LER-PROP-FIDELIZ */

                R0270_00_LER_PROP_FIDELIZ_SECTION();

                /*" -1522- IF NOT TEM-PROPOSTA-FIDELIZ */

                if (!WREA88.W_EXISTE_FIDELIZ["TEM_PROPOSTA_FIDELIZ"])
                {

                    /*" -1525- ADD 1 TO W-QTD-NP-MR-1, W-INDICE-1 */
                    WAREA_AUXILIAR.W_QTD_NP_MR_1.Value = WAREA_AUXILIAR.W_QTD_NP_MR_1 + 1;
                    WAREA_AUXILIAR.W_INDICE_1.Value = WAREA_AUXILIAR.W_INDICE_1 + 1;

                    /*" -1526- IF W-INDICE-1 >= 29999 */

                    if (WAREA_AUXILIAR.W_INDICE_1 >= 29999)
                    {

                        /*" -1527- DISPLAY 'PF0711B - FIM ANORMAL' */
                        _.Display($"PF0711B - FIM ANORMAL");

                        /*" -1528- DISPLAY '          ESTOURO DA TABELA DE ERROS - 2' */
                        _.Display($"          ESTOURO DA TABELA DE ERROS - 2");

                        /*" -1529- PERFORM R9977-00-FECHAR-ARQUIVOS */

                        R9977_00_FECHAR_ARQUIVOS_SECTION();

                        /*" -1530- PERFORM R9999-00-FINALIZAR */

                        R9999_00_FINALIZAR_SECTION();

                        /*" -1532- END-IF */
                    }


                    /*" -1534- IF REGISTRO-PROPOSTA */

                    if (WREA88.W_TIPO_MOVIMENTO["REGISTRO_PROPOSTA"])
                    {

                        /*" -1536- MOVE REG-STA-MR TO REG-STA-PROPOSTA */
                        _.Move(MOV_STA_MR?.Value, LBFCT011.REG_STA_PROPOSTA);

                        /*" -1538- MOVE R1-NUM-PROPOSTA TO W-TB-NUM-PROPOSTA (W-INDICE-1) */
                        _.Move(LBFCT011.REG_STA_PROPOSTA.R1_NUM_PROPOSTA, AREA_DAS_TABELAS.W_TAB_CONSISTENCIA.FILLER_44[WAREA_AUXILIAR.W_INDICE_1].W_TB_NUM_PROPOSTA);

                        /*" -1540- MOVE R1-SIT-PROPOSTA TO W-TB-SIT-PROPOSTA (W-INDICE-1) */
                        _.Move(LBFCT011.REG_STA_PROPOSTA.R1_SIT_PROPOSTA, AREA_DAS_TABELAS.W_TAB_CONSISTENCIA.FILLER_44[WAREA_AUXILIAR.W_INDICE_1].W_TB_SIT_PROPOSTA);

                        /*" -1542- MOVE R1-DATA-SITUACAO TO W-TB-DT-SITUACAO (W-INDICE-1) */
                        _.Move(LBFCT011.REG_STA_PROPOSTA.R1_DATA_SITUACAO, AREA_DAS_TABELAS.W_TAB_CONSISTENCIA.FILLER_44[WAREA_AUXILIAR.W_INDICE_1].W_TB_DT_SITUACAO);

                        /*" -1544- ELSE */
                    }
                    else
                    {


                        /*" -1546- MOVE REG-STA-MR TO REG-PGTO-SASSE */
                        _.Move(MOV_STA_MR?.Value, LBFCT016.REG_PGTO_SASSE);

                        /*" -1548- MOVE R4-NUM-PROPOSTA TO W-TB-NUM-PROPOSTA (W-INDICE-1) */
                        _.Move(LBFCT016.REG_PGTO_SASSE.R4_NUM_PROPOSTA, AREA_DAS_TABELAS.W_TAB_CONSISTENCIA.FILLER_44[WAREA_AUXILIAR.W_INDICE_1].W_TB_NUM_PROPOSTA);

                        /*" -1550- MOVE R4-SIT-COBRANCA TO W-TB-SIT-PROPOSTA (W-INDICE-1) */
                        _.Move(LBFCT016.REG_PGTO_SASSE.R4_SIT_COBRANCA, AREA_DAS_TABELAS.W_TAB_CONSISTENCIA.FILLER_44[WAREA_AUXILIAR.W_INDICE_1].W_TB_SIT_PROPOSTA);

                        /*" -1552- MOVE R4-DATA-SITUACAO TO W-TB-DT-SITUACAO (W-INDICE-1) */
                        _.Move(LBFCT016.REG_PGTO_SASSE.R4_DATA_SITUACAO, AREA_DAS_TABELAS.W_TAB_CONSISTENCIA.FILLER_44[WAREA_AUXILIAR.W_INDICE_1].W_TB_DT_SITUACAO);

                        /*" -1554- END-IF */
                    }


                    /*" -1556- MOVE 1 TO W-TB-COD-DESCRI (W-INDICE-1) */
                    _.Move(1, AREA_DAS_TABELAS.W_TAB_CONSISTENCIA.FILLER_44[WAREA_AUXILIAR.W_INDICE_1].W_TB_COD_DESCRI);

                    /*" -1561- PERFORM R0050-00-LER-MOV-MR UNTIL W-FIM-MOVTO-MR EQUAL 'FIM' OR REG-TIPO-REGISTRO EQUAL 'T' OR REG-NUM-PROPOSTA NOT EQUAL W-NUM-PROPOSTA-ANT */

                    while (!(WAREA_AUXILIAR.W_FIM_MOVTO_MR == "FIM" || REG_STA_MR.REG_TIPO_REGISTRO == "T" || REG_STA_MR.REG_NUM_PROPOSTA != WAREA_AUXILIAR.W_NUM_PROPOSTA_ANT))
                    {

                        R0050_00_LER_MOV_MR_SECTION();
                    }

                    /*" -1563- GO TO R0260-SAIDA. */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0260_SAIDA*/ //GOTO
                    return;
                }

            }


            /*" -1565- IF REGISTRO-ENDOSSO */

            if (WREA88.W_TIPO_MOVIMENTO["REGISTRO_ENDOSSO"])
            {

                /*" -1567- MOVE REG-STA-MR TO REGISTRO-ENDOSSOS */
                _.Move(MOV_STA_MR?.Value, LBFCT000.REGISTRO_ENDOSSOS);

                /*" -1568- IF R0-VAL-DIF-ENDOSSO GREATER ZEROS */

                if (LBFCT000.REGISTRO_ENDOSSOS.R0_VAL_DIF_ENDOSSO > 00)
                {

                    /*" -1569- MOVE 1 TO W-REGISTRO-ENDOSSO */
                    _.Move(1, WREA88.W_REGISTRO_ENDOSSO);

                    /*" -1570- ELSE */
                }
                else
                {


                    /*" -1572- MOVE 0 TO W-REGISTRO-ENDOSSO. */
                    _.Move(0, WREA88.W_REGISTRO_ENDOSSO);
                }

            }


            /*" -1574- IF REGISTRO-PROPOSTA */

            if (WREA88.W_TIPO_MOVIMENTO["REGISTRO_PROPOSTA"])
            {

                /*" -1576- ADD 1 TO W-QTD-LD-MR-1 */
                WAREA_AUXILIAR.W_QTD_LD_MR_1.Value = WAREA_AUXILIAR.W_QTD_LD_MR_1 + 1;

                /*" -1578- MOVE 1 TO W-REGISTRO-PROPOSTA */
                _.Move(1, WREA88.W_REGISTRO_PROPOSTA);

                /*" -1581- MOVE REG-STA-MR TO REG-STA-PROPOSTA. */
                _.Move(MOV_STA_MR?.Value, LBFCT011.REG_STA_PROPOSTA);
            }


            /*" -1583- IF REGISTRO-APOLICE */

            if (WREA88.W_TIPO_MOVIMENTO["REGISTRO_APOLICE"])
            {

                /*" -1585- MOVE 1 TO W-REGISTRO-APOLICE */
                _.Move(1, WREA88.W_REGISTRO_APOLICE);

                /*" -1588- MOVE REG-STA-MR TO REG-APOL-SASSE. */
                _.Move(MOV_STA_MR?.Value, LBFCT016.REG_APOL_SASSE);
            }


            /*" -1590- IF REGISTRO-COBERTURA */

            if (WREA88.W_TIPO_MOVIMENTO["REGISTRO_COBERTURA"])
            {

                /*" -1592- ADD 1 TO W-INDICE-3 */
                WAREA_AUXILIAR.W_INDICE_3.Value = WAREA_AUXILIAR.W_INDICE_3 + 1;

                /*" -1593- IF W-INDICE-3 GREATER 500 */

                if (WAREA_AUXILIAR.W_INDICE_3 > 500)
                {

                    /*" -1594- DISPLAY 'PF0711B - FIM ANORMAL' */
                    _.Display($"PF0711B - FIM ANORMAL");

                    /*" -1595- DISPLAY '          ESTOURO DA TABELA DE COBERTURAS 3' */
                    _.Display($"          ESTOURO DA TABELA DE COBERTURAS 3");

                    /*" -1597- DISPLAY '          NUMERO DA PROPOSTA............. ' R3-NUM-PROPOSTA */
                    _.Display($"          NUMERO DA PROPOSTA............. {LBFCT016.REG_COBER_SASSE.R3_NUM_PROPOSTA}");

                    /*" -1598- PERFORM R9977-00-FECHAR-ARQUIVOS */

                    R9977_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -1599- PERFORM R9999-00-FINALIZAR */

                    R9999_00_FINALIZAR_SECTION();

                    /*" -1601- END-IF */
                }


                /*" -1604- MOVE REG-STA-MR TO W-TB-REGISTRO-COBERTURA (W-INDICE-3) */
                _.Move(MOV_STA_MR?.Value, AREA_DAS_TABELAS.W_TAB_COBERTURA.FILLER_47[WAREA_AUXILIAR.W_INDICE_3].W_TB_REGISTRO_COBERTURA);

                /*" -1607- MOVE 1 TO W-REGISTRO-COBERTURA. */
                _.Move(1, WREA88.W_REGISTRO_COBERTURA);
            }


            /*" -1609- IF REGISTRO-PAGAMENTO */

            if (WREA88.W_TIPO_MOVIMENTO["REGISTRO_PAGAMENTO"])
            {

                /*" -1611- MOVE 1 TO W-REGISTRO-PAGAMENTO */
                _.Move(1, WREA88.W_REGISTRO_PAGAMENTO);

                /*" -1613- MOVE REG-STA-MR TO REG-PGTO-SASSE. */
                _.Move(MOV_STA_MR?.Value, LBFCT016.REG_PGTO_SASSE);
            }


            /*" -1615- IF REGISTRO-SIDEM-BL-33 */

            if (WREA88.W_TIPO_MOVIMENTO["REGISTRO_SIDEM_BL_33"])
            {

                /*" -1617- MOVE 1 TO W-REGISTRO-SIDEM-BL-33 */
                _.Move(1, WREA88.W_REGISTRO_SIDEM_BL_33);

                /*" -1618- MOVE REG-STA-MR TO R8-PONTUACAO-SIDEM */
                _.Move(MOV_STA_MR?.Value, LBFPF025.R8_PONTUACAO_SIDEM);

                /*" -1619- ADD 1 TO S-I */
                S_I.Value = S_I + 1;

                /*" -1620- IF S-I GREATER THAN 30 */

                if (S_I > 30)
                {

                    /*" -1621- DISPLAY 'PF0711L - FIM ANORMAL' */
                    _.Display($"PF0711L - FIM ANORMAL");

                    /*" -1622- DISPLAY 'PF0711L - ESTOURO TABELA SIDEM' */
                    _.Display($"PF0711L - ESTOURO TABELA SIDEM");

                    /*" -1623- PERFORM R9977-00-FECHAR-ARQUIVOS */

                    R9977_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -1624- PERFORM R9999-00-FINALIZAR */

                    R9999_00_FINALIZAR_SECTION();

                    /*" -1625- ELSE */
                }
                else
                {


                    /*" -1626- ADD 1 TO CONT-SIDEM */
                    CONT_SIDEM.Value = CONT_SIDEM + 1;

                    /*" -1627- MOVE R8-PONTUACAO-SIDEM TO W-TB-REGISTRO-SIDEM (S-I) */
                    _.Move(LBFPF025.R8_PONTUACAO_SIDEM, AREA_DAS_TABELAS.W_TAB_REG_SIDEM.FILLER_48[S_I].W_TB_REGISTRO_SIDEM);

                    /*" -1631- END-IF. */
                }

            }


            /*" -1640- PERFORM R0050-00-LER-MOV-MR. */

            R0050_00_LER_MOV_MR_SECTION();

            /*" -1641- IF REG-TIPO-REGISTRO-R LESS W-TIPO-REG-ANT */

            if (REG_STA_MR.FILLER_0.REG_TIPO_REGISTRO_R < WAREA_AUXILIAR.W_TIPO_REG_ANT)
            {

                /*" -1642- IF REG-NUM-PROPOSTA EQUAL W-NUM-PROPOSTA-ANT */

                if (REG_STA_MR.REG_NUM_PROPOSTA == WAREA_AUXILIAR.W_NUM_PROPOSTA_ANT)
                {

                    /*" -1642- MOVE ZEROS TO W-NUM-PROPOSTA-ANT. */
                    _.Move(0, WAREA_AUXILIAR.W_NUM_PROPOSTA_ANT);
                }

            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0260_SAIDA*/

        [StopWatch]
        /*" R0261-IMPRIME-REG-SIDEM-SECTION */
        private void R0261_IMPRIME_REG_SIDEM_SECTION()
        {
            /*" -1649- MOVE W-TB-REGISTRO-SIDEM (S-I) TO R8-PONTUACAO-SIDEM. */
            _.Move(AREA_DAS_TABELAS.W_TAB_REG_SIDEM.FILLER_48[S_I].W_TB_REGISTRO_SIDEM, LBFPF025.R8_PONTUACAO_SIDEM);

            /*" -1652- MOVE R8-PONTUACAO-SIDEM TO REG-STA-CEF REG-STA-FNAE W-REG-SAIDA. */
            _.Move(LBFPF025.R8_PONTUACAO_SIDEM, REG_STA_CEF, REG_STA_FNAE, W_DATAS.W_REG_SAIDA);

            /*" -1653- IF REG-STA-CEF NOT EQUAL SPACES */

            if (!REG_STA_CEF.IsEmpty())
            {

                /*" -1654- WRITE REG-STA-CEF. */
                MOV_STA_CEF.Write(REG_STA_CEF.GetMoveValues().ToString());
            }


            /*" -1655- ADD 1 TO S-I. */
            S_I.Value = S_I + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0261_SAIDA*/

        [StopWatch]
        /*" R0270-00-LER-PROP-FIDELIZ-SECTION */
        private void R0270_00_LER_PROP_FIDELIZ_SECTION()
        {
            /*" -1665- MOVE 'R0200-00-LER-PROP-FIDELIZ' TO PARAGRAFO. */
            _.Move("R0200-00-LER-PROP-FIDELIZ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1667- MOVE 'SELECT PROPOSTA-FIDELIZ' TO COMANDO. */
            _.Move("SELECT PROPOSTA-FIDELIZ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1670- MOVE REG-NUM-PROPOSTA TO NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ. */
            _.Move(REG_STA_MR.REG_NUM_PROPOSTA, PROPFID.DCLPROPOSTA_FIDELIZ.NUM_PROPOSTA_SIVPF);

            /*" -1691- PERFORM R0270_00_LER_PROP_FIDELIZ_DB_SELECT_1 */

            R0270_00_LER_PROP_FIDELIZ_DB_SELECT_1();

            /*" -1694- IF SQLCODE EQUAL 00 */

            if (DB.SQLCODE == 00)
            {

                /*" -1695- MOVE 1 TO W-EXISTE-FIDELIZ */
                _.Move(1, WREA88.W_EXISTE_FIDELIZ);

                /*" -1696- ELSE */
            }
            else
            {


                /*" -1697- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1698- MOVE 2 TO W-EXISTE-FIDELIZ */
                    _.Move(2, WREA88.W_EXISTE_FIDELIZ);

                    /*" -1699- ELSE */
                }
                else
                {


                    /*" -1700- DISPLAY 'PF0711B - FIM ANORMAL' */
                    _.Display($"PF0711B - FIM ANORMAL");

                    /*" -1701- DISPLAY '          ERRO SELECT PROPOSTA FIDELIZ' */
                    _.Display($"          ERRO SELECT PROPOSTA FIDELIZ");

                    /*" -1703- DISPLAY '          NUM PROPOSTA............... ' NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ */
                    _.Display($"          NUM PROPOSTA............... {PROPFID.DCLPROPOSTA_FIDELIZ.NUM_PROPOSTA_SIVPF}");

                    /*" -1705- DISPLAY '          SQLCODE.................... ' SQLCODE */
                    _.Display($"          SQLCODE.................... {DB.SQLCODE}");

                    /*" -1706- PERFORM R9977-00-FECHAR-ARQUIVOS */

                    R9977_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -1706- PERFORM R9999-00-FINALIZAR. */

                    R9999_00_FINALIZAR_SECTION();
                }

            }


        }

        [StopWatch]
        /*" R0270-00-LER-PROP-FIDELIZ-DB-SELECT-1 */
        public void R0270_00_LER_PROP_FIDELIZ_DB_SELECT_1()
        {
            /*" -1691- EXEC SQL SELECT NUM_IDENTIFICACAO, COD_EMPRESA_SIVPF, COD_PRODUTO_SIVPF, SIT_PROPOSTA , DTQITBCO , VAL_PAGO , AGEPGTO , DATA_CREDITO INTO :DCLPROPOSTA-FIDELIZ.NUM-IDENTIFICACAO, :DCLPROPOSTA-FIDELIZ.COD-EMPRESA-SIVPF, :DCLPROPOSTA-FIDELIZ.COD-PRODUTO-SIVPF, :DCLPROPOSTA-FIDELIZ.SIT-PROPOSTA , :DCLPROPOSTA-FIDELIZ.DTQITBCO , :DCLPROPOSTA-FIDELIZ.VAL-PAGO , :DCLPROPOSTA-FIDELIZ.AGEPGTO , :DCLPROPOSTA-FIDELIZ.DATA-CREDITO FROM SEGUROS.PROPOSTA_FIDELIZ WHERE NUM_PROPOSTA_SIVPF = :DCLPROPOSTA-FIDELIZ.NUM-PROPOSTA-SIVPF WITH UR END-EXEC. */

            var r0270_00_LER_PROP_FIDELIZ_DB_SELECT_1_Query1 = new R0270_00_LER_PROP_FIDELIZ_DB_SELECT_1_Query1()
            {
                NUM_PROPOSTA_SIVPF = PROPFID.DCLPROPOSTA_FIDELIZ.NUM_PROPOSTA_SIVPF.ToString(),
            };

            var executed_1 = R0270_00_LER_PROP_FIDELIZ_DB_SELECT_1_Query1.Execute(r0270_00_LER_PROP_FIDELIZ_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.NUM_IDENTIFICACAO, PROPFID.DCLPROPOSTA_FIDELIZ.NUM_IDENTIFICACAO);
                _.Move(executed_1.COD_EMPRESA_SIVPF, PROPFID.DCLPROPOSTA_FIDELIZ.COD_EMPRESA_SIVPF);
                _.Move(executed_1.COD_PRODUTO_SIVPF, PROPFID.DCLPROPOSTA_FIDELIZ.COD_PRODUTO_SIVPF);
                _.Move(executed_1.SIT_PROPOSTA, PROPFID.DCLPROPOSTA_FIDELIZ.SIT_PROPOSTA);
                _.Move(executed_1.DTQITBCO, PROPFID.DCLPROPOSTA_FIDELIZ.DTQITBCO);
                _.Move(executed_1.VAL_PAGO, PROPFID.DCLPROPOSTA_FIDELIZ.VAL_PAGO);
                _.Move(executed_1.AGEPGTO, PROPFID.DCLPROPOSTA_FIDELIZ.AGEPGTO);
                _.Move(executed_1.DATA_CREDITO, PROPFID.DCLPROPOSTA_FIDELIZ.DATA_CREDITO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0270_SAIDA*/

        [StopWatch]
        /*" R0280-00-LER-HIST-FIDELIZ-SECTION */
        private void R0280_00_LER_HIST_FIDELIZ_SECTION()
        {
            /*" -1716- MOVE 'R0280-00-LER-HIST-FIDELIZ' TO PARAGRAFO. */
            _.Move("R0280-00-LER-HIST-FIDELIZ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1718- MOVE 'SELECT HIST-PROP-FIDELIZ' TO COMANDO. */
            _.Move("SELECT HIST-PROP-FIDELIZ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1721- MOVE NUM-IDENTIFICACAO OF DCLPROPOSTA-FIDELIZ TO PROPFIDH-NUM-IDENTIFICACAO OF DCLHIST-PROP-FIDELIZ. */
            _.Move(PROPFID.DCLPROPOSTA_FIDELIZ.NUM_IDENTIFICACAO, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NUM_IDENTIFICACAO);

            /*" -1724- MOVE R1-SIT-PROPOSTA TO PROPFIDH-SIT-PROPOSTA OF DCLHIST-PROP-FIDELIZ */
            _.Move(LBFCT011.REG_STA_PROPOSTA.R1_SIT_PROPOSTA, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_PROPOSTA);

            /*" -1726- MOVE R1-DATA-SITUACAO TO W-DATA-TRABALHO */
            _.Move(LBFCT011.REG_STA_PROPOSTA.R1_DATA_SITUACAO, W_DATAS.W_DATA_TRABALHO);

            /*" -1727- MOVE W-DIA-TRABALHO TO W-DIA-SQL OF W-DATA-SQL1 */
            _.Move(W_DATAS.FILLER_4.W_DIA_TRABALHO, W_DATAS.W_DATA_SQL1.W_DIA_SQL);

            /*" -1728- MOVE W-MES-TRABALHO TO W-MES-SQL OF W-DATA-SQL1 */
            _.Move(W_DATAS.FILLER_4.W_MES_TRABALHO, W_DATAS.W_DATA_SQL1.W_MES_SQL);

            /*" -1729- MOVE W-ANO-TRABALHO TO W-ANO-SQL OF W-DATA-SQL1 */
            _.Move(W_DATAS.FILLER_4.W_ANO_TRABALHO, W_DATAS.W_DATA_SQL1.W_ANO_SQL);

            /*" -1731- MOVE '-' TO W-BARRA1 OF W-DATA-SQL1, W-BARRA2 OF W-DATA-SQL1. */
            _.Move("-", W_DATAS.W_DATA_SQL1.W_BARRA1_1);
            _.Move("-", W_DATAS.W_DATA_SQL1.W_BARRA2_1);


            /*" -1734- MOVE W-DATA-SQL TO PROPFIDH-DATA-SITUACAO OF DCLHIST-PROP-FIDELIZ */
            _.Move(W_DATAS.W_DATA_SQL, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_DATA_SITUACAO);

            /*" -1735- IF R1-SIT-PROPOSTA EQUAL 'REJ' OR 'ANA' OR 'CAN' */

            if (LBFCT011.REG_STA_PROPOSTA.R1_SIT_PROPOSTA.In("REJ", "ANA", "CAN"))
            {

                /*" -1744- PERFORM R0280_00_LER_HIST_FIDELIZ_DB_SELECT_1 */

                R0280_00_LER_HIST_FIDELIZ_DB_SELECT_1();

                /*" -1746- ELSE */
            }
            else
            {


                /*" -1757- PERFORM R0280_00_LER_HIST_FIDELIZ_DB_SELECT_2 */

                R0280_00_LER_HIST_FIDELIZ_DB_SELECT_2();

                /*" -1760- IF SQLCODE NOT EQUAL 00 AND -811 */

                if (!DB.SQLCODE.In("00", "-811"))
                {

                    /*" -1761- IF SQLCODE EQUAL 100 */

                    if (DB.SQLCODE == 100)
                    {

                        /*" -1762- MOVE 2 TO W-HISTORICO */
                        _.Move(2, WREA88.W_HISTORICO);

                        /*" -1763- ELSE */
                    }
                    else
                    {


                        /*" -1764- DISPLAY 'PF0711B - FIM ANORMAL' */
                        _.Display($"PF0711B - FIM ANORMAL");

                        /*" -1765- DISPLAY '          ERRO ACESSO HIST-PROP-FIDELIZ' */
                        _.Display($"          ERRO ACESSO HIST-PROP-FIDELIZ");

                        /*" -1767- DISPLAY '          EMPRESA............. ' RH-NOME-EMPRESA OF REG-HEADER-STA */
                        _.Display($"          EMPRESA............. {LBFCT011.REG_HEADER_STA.RH_NOME_EMPRESA}");

                        /*" -1769- DISPLAY '          NUMERO DA PROPOSTA.. ' R1-NUM-PROPOSTA OF REG-STA-PROPOSTA */
                        _.Display($"          NUMERO DA PROPOSTA.. {LBFCT011.REG_STA_PROPOSTA.R1_NUM_PROPOSTA}");

                        /*" -1771- DISPLAY '          NUMERO IDENTIFICACAO ' PROPFIDH-NUM-IDENTIFICACAO OF DCLHIST-PROP-FIDELIZ */
                        _.Display($"          NUMERO IDENTIFICACAO {PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NUM_IDENTIFICACAO}");

                        /*" -1773- DISPLAY '          SQLCODE............. ' SQLCODE */
                        _.Display($"          SQLCODE............. {DB.SQLCODE}");

                        /*" -1774- PERFORM R9977-00-FECHAR-ARQUIVOS */

                        R9977_00_FECHAR_ARQUIVOS_SECTION();

                        /*" -1775- PERFORM R9999-00-FINALIZAR */

                        R9999_00_FINALIZAR_SECTION();

                        /*" -1776- ELSE */
                    }

                }
                else
                {


                    /*" -1776- MOVE 1 TO W-HISTORICO. */
                    _.Move(1, WREA88.W_HISTORICO);
                }

            }


        }

        [StopWatch]
        /*" R0280-00-LER-HIST-FIDELIZ-DB-SELECT-1 */
        public void R0280_00_LER_HIST_FIDELIZ_DB_SELECT_1()
        {
            /*" -1744- EXEC SQL SELECT NUM_IDENTIFICACAO INTO :DCLHIST-PROP-FIDELIZ.PROPFIDH-NUM-IDENTIFICACAO FROM SEGUROS.HIST_PROP_FIDELIZ WHERE NUM_IDENTIFICACAO = :DCLHIST-PROP-FIDELIZ.PROPFIDH-NUM-IDENTIFICACAO AND SIT_PROPOSTA = :DCLHIST-PROP-FIDELIZ.PROPFIDH-SIT-PROPOSTA WITH UR END-EXEC */

            var r0280_00_LER_HIST_FIDELIZ_DB_SELECT_1_Query1 = new R0280_00_LER_HIST_FIDELIZ_DB_SELECT_1_Query1()
            {
                PROPFIDH_NUM_IDENTIFICACAO = PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NUM_IDENTIFICACAO.ToString(),
                PROPFIDH_SIT_PROPOSTA = PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_PROPOSTA.ToString(),
            };

            var executed_1 = R0280_00_LER_HIST_FIDELIZ_DB_SELECT_1_Query1.Execute(r0280_00_LER_HIST_FIDELIZ_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PROPFIDH_NUM_IDENTIFICACAO, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NUM_IDENTIFICACAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0280_SAIDA*/

        [StopWatch]
        /*" R0280-00-LER-HIST-FIDELIZ-DB-SELECT-2 */
        public void R0280_00_LER_HIST_FIDELIZ_DB_SELECT_2()
        {
            /*" -1757- EXEC SQL SELECT NUM_IDENTIFICACAO INTO :DCLHIST-PROP-FIDELIZ.PROPFIDH-NUM-IDENTIFICACAO FROM SEGUROS.HIST_PROP_FIDELIZ WHERE NUM_IDENTIFICACAO = :DCLHIST-PROP-FIDELIZ.PROPFIDH-NUM-IDENTIFICACAO AND DATA_SITUACAO = :DCLHIST-PROP-FIDELIZ.PROPFIDH-DATA-SITUACAO AND SIT_PROPOSTA = :DCLHIST-PROP-FIDELIZ.PROPFIDH-SIT-PROPOSTA WITH UR END-EXEC. */

            var r0280_00_LER_HIST_FIDELIZ_DB_SELECT_2_Query1 = new R0280_00_LER_HIST_FIDELIZ_DB_SELECT_2_Query1()
            {
                PROPFIDH_NUM_IDENTIFICACAO = PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NUM_IDENTIFICACAO.ToString(),
                PROPFIDH_DATA_SITUACAO = PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_DATA_SITUACAO.ToString(),
                PROPFIDH_SIT_PROPOSTA = PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_PROPOSTA.ToString(),
            };

            var executed_1 = R0280_00_LER_HIST_FIDELIZ_DB_SELECT_2_Query1.Execute(r0280_00_LER_HIST_FIDELIZ_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PROPFIDH_NUM_IDENTIFICACAO, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NUM_IDENTIFICACAO);
            }


        }

        [StopWatch]
        /*" R0300-00-ATUALIZAR-PRP-FIDELIZ-SECTION */
        private void R0300_00_ATUALIZAR_PRP_FIDELIZ_SECTION()
        {
            /*" -1786- MOVE 'R0300-00-ATUALIZAR-FIDELIZ' TO PARAGRAFO. */
            _.Move("R0300-00-ATUALIZAR-FIDELIZ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1788- MOVE 'UPDATE PROPOSTA-FIDELIZ' TO COMANDO. */
            _.Move("UPDATE PROPOSTA-FIDELIZ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1797- PERFORM R0300_00_ATUALIZAR_PRP_FIDELIZ_DB_UPDATE_1 */

            R0300_00_ATUALIZAR_PRP_FIDELIZ_DB_UPDATE_1();

            /*" -1800- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -1801- DISPLAY 'PF0711B - FIM ANORMAL' */
                _.Display($"PF0711B - FIM ANORMAL");

                /*" -1802- DISPLAY '          ERRO UPDATE PROPOSTA-FIDELIZ' */
                _.Display($"          ERRO UPDATE PROPOSTA-FIDELIZ");

                /*" -1804- DISPLAY '          PROPOSTA................... ' NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ */
                _.Display($"          PROPOSTA................... {PROPFID.DCLPROPOSTA_FIDELIZ.NUM_PROPOSTA_SIVPF}");

                /*" -1806- DISPLAY '          SQLCODE.................... ' SQLCODE */
                _.Display($"          SQLCODE.................... {DB.SQLCODE}");

                /*" -1807- PERFORM R9977-00-FECHAR-ARQUIVOS */

                R9977_00_FECHAR_ARQUIVOS_SECTION();

                /*" -1807- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R0300-00-ATUALIZAR-PRP-FIDELIZ-DB-UPDATE-1 */
        public void R0300_00_ATUALIZAR_PRP_FIDELIZ_DB_UPDATE_1()
        {
            /*" -1797- EXEC SQL UPDATE SEGUROS.PROPOSTA_FIDELIZ SET NSAS_SIVPF = :DCLPROPOSTA-FIDELIZ.NSAS-SIVPF, NSL = :DCLPROPOSTA-FIDELIZ.NSL, SIT_PROPOSTA = :DCLPROPOSTA-FIDELIZ.SIT-PROPOSTA, COD_USUARIO = :DCLPROPOSTA-FIDELIZ.COD-USUARIO, SITUACAO_ENVIO = :DCLPROPOSTA-FIDELIZ.SITUACAO-ENVIO WHERE NUM_PROPOSTA_SIVPF = :DCLPROPOSTA-FIDELIZ.NUM-PROPOSTA-SIVPF END-EXEC. */

            var r0300_00_ATUALIZAR_PRP_FIDELIZ_DB_UPDATE_1_Update1 = new R0300_00_ATUALIZAR_PRP_FIDELIZ_DB_UPDATE_1_Update1()
            {
                SITUACAO_ENVIO = PROPFID.DCLPROPOSTA_FIDELIZ.SITUACAO_ENVIO.ToString(),
                SIT_PROPOSTA = PROPFID.DCLPROPOSTA_FIDELIZ.SIT_PROPOSTA.ToString(),
                COD_USUARIO = PROPFID.DCLPROPOSTA_FIDELIZ.COD_USUARIO.ToString(),
                NSAS_SIVPF = PROPFID.DCLPROPOSTA_FIDELIZ.NSAS_SIVPF.ToString(),
                NSL = PROPFID.DCLPROPOSTA_FIDELIZ.NSL.ToString(),
                NUM_PROPOSTA_SIVPF = PROPFID.DCLPROPOSTA_FIDELIZ.NUM_PROPOSTA_SIVPF.ToString(),
            };

            R0300_00_ATUALIZAR_PRP_FIDELIZ_DB_UPDATE_1_Update1.Execute(r0300_00_ATUALIZAR_PRP_FIDELIZ_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_SAIDA*/

        [StopWatch]
        /*" R0330-00-ATUALIZAR-IOF-SECTION */
        private void R0330_00_ATUALIZAR_IOF_SECTION()
        {
            /*" -1817- MOVE 'R0300-00-ATUALIZAR-IOF' TO PARAGRAFO. */
            _.Move("R0300-00-ATUALIZAR-IOF", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1819- MOVE 'UPDATE PROPOSTA-FIDELIZ' TO COMANDO. */
            _.Move("UPDATE PROPOSTA-FIDELIZ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1824- PERFORM R0330_00_ATUALIZAR_IOF_DB_UPDATE_1 */

            R0330_00_ATUALIZAR_IOF_DB_UPDATE_1();

            /*" -1827- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -1828- DISPLAY 'PF0711B - FIM ANORMAL' */
                _.Display($"PF0711B - FIM ANORMAL");

                /*" -1829- DISPLAY '          ERRO UPDATE PROPOSTA-FIDELIZ' */
                _.Display($"          ERRO UPDATE PROPOSTA-FIDELIZ");

                /*" -1831- DISPLAY '          PROPOSTA................... ' NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ */
                _.Display($"          PROPOSTA................... {PROPFID.DCLPROPOSTA_FIDELIZ.NUM_PROPOSTA_SIVPF}");

                /*" -1833- DISPLAY '          SQLCODE.................... ' SQLCODE */
                _.Display($"          SQLCODE.................... {DB.SQLCODE}");

                /*" -1834- PERFORM R9977-00-FECHAR-ARQUIVOS */

                R9977_00_FECHAR_ARQUIVOS_SECTION();

                /*" -1834- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R0330-00-ATUALIZAR-IOF-DB-UPDATE-1 */
        public void R0330_00_ATUALIZAR_IOF_DB_UPDATE_1()
        {
            /*" -1824- EXEC SQL UPDATE SEGUROS.PROPOSTA_FIDELIZ SET VAL_IOF = :DCLPROPOSTA-FIDELIZ.VAL-IOF WHERE NUM_PROPOSTA_SIVPF = :DCLPROPOSTA-FIDELIZ.NUM-PROPOSTA-SIVPF END-EXEC. */

            var r0330_00_ATUALIZAR_IOF_DB_UPDATE_1_Update1 = new R0330_00_ATUALIZAR_IOF_DB_UPDATE_1_Update1()
            {
                VAL_IOF = PROPFID.DCLPROPOSTA_FIDELIZ.VAL_IOF.ToString(),
                NUM_PROPOSTA_SIVPF = PROPFID.DCLPROPOSTA_FIDELIZ.NUM_PROPOSTA_SIVPF.ToString(),
            };

            R0330_00_ATUALIZAR_IOF_DB_UPDATE_1_Update1.Execute(r0330_00_ATUALIZAR_IOF_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0330_SAIDA*/

        [StopWatch]
        /*" R0350-00-GERAR-HIST-FIDELIZ-SECTION */
        private void R0350_00_GERAR_HIST_FIDELIZ_SECTION()
        {
            /*" -1845- MOVE 'R0350-00-GERAR-HIST-FIDELIZ' TO PARAGRAFO. */
            _.Move("R0350-00-GERAR-HIST-FIDELIZ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1848- MOVE W-NUM-PROPOSTA-ANT TO NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ. */
            _.Move(WAREA_AUXILIAR.W_NUM_PROPOSTA_ANT, PROPFID.DCLPROPOSTA_FIDELIZ.NUM_PROPOSTA_SIVPF);

            /*" -1859- PERFORM R0350_00_GERAR_HIST_FIDELIZ_DB_SELECT_1 */

            R0350_00_GERAR_HIST_FIDELIZ_DB_SELECT_1();

            /*" -1862- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1863- GO TO R0350-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0350_SAIDA*/ //GOTO
                return;

                /*" -1864- ELSE */
            }
            else
            {


                /*" -1865- IF SQLCODE NOT EQUAL 00 */

                if (DB.SQLCODE != 00)
                {

                    /*" -1866- DISPLAY 'PF0711B - FIM ANORMAL' */
                    _.Display($"PF0711B - FIM ANORMAL");

                    /*" -1867- DISPLAY '  R0350 - ERRO CONSULTA TAB PROP-FIDELIZ' */
                    _.Display($"  R0350 - ERRO CONSULTA TAB PROP-FIDELIZ");

                    /*" -1869- DISPLAY '          REG NUM PROPOSTA... ' REG-NUM-PROPOSTA */
                    _.Display($"          REG NUM PROPOSTA... {REG_STA_MR.REG_NUM_PROPOSTA}");

                    /*" -1871- DISPLAY '          SQLCODE............ ' SQLCODE */
                    _.Display($"          SQLCODE............ {DB.SQLCODE}");

                    /*" -1872- PERFORM R9977-00-FECHAR-ARQUIVOS */

                    R9977_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -1873- PERFORM R9999-00-FINALIZAR */

                    R9999_00_FINALIZAR_SECTION();

                    /*" -1875- END-IF. */
                }

            }


            /*" -1886- PERFORM R0350_00_GERAR_HIST_FIDELIZ_DB_INSERT_1 */

            R0350_00_GERAR_HIST_FIDELIZ_DB_INSERT_1();

            /*" -1889- MOVE SQLERRMC TO WSQLERRMC. */
            _.Move(DB.SQLERRMC, WABEND.WSQLERRO.WSQLERRMC);

            /*" -1891- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, WABEND.WSQLCODE);

            /*" -1892- IF SQLCODE NOT EQUAL 00 AND -803 */

            if (!DB.SQLCODE.In("00", "-803"))
            {

                /*" -1893- DISPLAY 'PF0711B - FIM ANORMAL' */
                _.Display($"PF0711B - FIM ANORMAL");

                /*" -1894- DISPLAY '          ERRO INSERT HIST-PROP-FIDELIZ' */
                _.Display($"          ERRO INSERT HIST-PROP-FIDELIZ");

                /*" -1896- DISPLAY '          REGISTRO........... ' REG-STA-MR (1:60) */
                _.Display($"          REGISTRO........... REG-STA-MR(1:60)");

                /*" -1898- DISPLAY '          IDENTIFICACAO...... ' PROPFIDH-NUM-IDENTIFICACAO OF DCLHIST-PROP-FIDELIZ */
                _.Display($"          IDENTIFICACAO...... {PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NUM_IDENTIFICACAO}");

                /*" -1900- DISPLAY '          NUM PROPOSTA....... ' REG-NUM-PROPOSTA */
                _.Display($"          NUM PROPOSTA....... {REG_STA_MR.REG_NUM_PROPOSTA}");

                /*" -1902- DISPLAY '          DATA SITUACAO...... ' PROPFIDH-DATA-SITUACAO */
                _.Display($"          DATA SITUACAO...... {PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_DATA_SITUACAO}");

                /*" -1904- DISPLAY '          SIT PROPOSTA....... ' PROPFIDH-SIT-PROPOSTA */
                _.Display($"          SIT PROPOSTA....... {PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_PROPOSTA}");

                /*" -1906- DISPLAY '          SIT COBRANCA....... ' PROPFIDH-SIT-COBRANCA-SIVPF */
                _.Display($"          SIT COBRANCA....... {PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_COBRANCA_SIVPF}");

                /*" -1908- DISPLAY '          SIT MOTIVO......... ' PROPFIDH-SIT-MOTIVO-SIVPF */
                _.Display($"          SIT MOTIVO......... {PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_MOTIVO_SIVPF}");

                /*" -1910- DISPLAY '          NSAS-SIVPF......... ' PROPFIDH-NSAS-SIVPF */
                _.Display($"          NSAS-SIVPF......... {PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NSAS_SIVPF}");

                /*" -1912- DISPLAY '          NSL................ ' PROPFIDH-NSL */
                _.Display($"          NSL................ {PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NSL}");

                /*" -1914- DISPLAY '          COD EMPRESA........ ' PROPFIDH-COD-EMPRESA-SIVPF */
                _.Display($"          COD EMPRESA........ {PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_COD_EMPRESA_SIVPF}");

                /*" -1916- DISPLAY '          COD PRODUTO........ ' PROPFIDH-COD-PRODUTO-SIVPF */
                _.Display($"          COD PRODUTO........ {PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_COD_PRODUTO_SIVPF}");

                /*" -1919- DISPLAY '          SQLCODE / SQLERRMC  ' SQLCODE WSQLERRMC */

                $"          SQLCODE / SQLERRMC  {DB.SQLCODE}{WABEND.WSQLERRO.WSQLERRMC}"
                .Display();

                /*" -1920- IF SQLCODE NOT EQUAL -803 */

                if (DB.SQLCODE != -803)
                {

                    /*" -1921- PERFORM R9977-00-FECHAR-ARQUIVOS */

                    R9977_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -1922- PERFORM R9999-00-FINALIZAR */

                    R9999_00_FINALIZAR_SECTION();

                    /*" -1923- END-IF */
                }


                /*" -1923- END-IF. */
            }


        }

        [StopWatch]
        /*" R0350-00-GERAR-HIST-FIDELIZ-DB-SELECT-1 */
        public void R0350_00_GERAR_HIST_FIDELIZ_DB_SELECT_1()
        {
            /*" -1859- EXEC SQL SELECT NUM_IDENTIFICACAO, COD_EMPRESA_SIVPF, COD_PRODUTO_SIVPF INTO :PROPFIDH-NUM-IDENTIFICACAO , :PROPFIDH-COD-EMPRESA-SIVPF , :PROPFIDH-COD-PRODUTO-SIVPF FROM SEGUROS.PROPOSTA_FIDELIZ WHERE NUM_PROPOSTA_SIVPF = :DCLPROPOSTA-FIDELIZ.NUM-PROPOSTA-SIVPF WITH UR END-EXEC. */

            var r0350_00_GERAR_HIST_FIDELIZ_DB_SELECT_1_Query1 = new R0350_00_GERAR_HIST_FIDELIZ_DB_SELECT_1_Query1()
            {
                NUM_PROPOSTA_SIVPF = PROPFID.DCLPROPOSTA_FIDELIZ.NUM_PROPOSTA_SIVPF.ToString(),
            };

            var executed_1 = R0350_00_GERAR_HIST_FIDELIZ_DB_SELECT_1_Query1.Execute(r0350_00_GERAR_HIST_FIDELIZ_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PROPFIDH_NUM_IDENTIFICACAO, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NUM_IDENTIFICACAO);
                _.Move(executed_1.PROPFIDH_COD_EMPRESA_SIVPF, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_COD_EMPRESA_SIVPF);
                _.Move(executed_1.PROPFIDH_COD_PRODUTO_SIVPF, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_COD_PRODUTO_SIVPF);
            }


        }

        [StopWatch]
        /*" R0350-00-GERAR-HIST-FIDELIZ-DB-INSERT-1 */
        public void R0350_00_GERAR_HIST_FIDELIZ_DB_INSERT_1()
        {
            /*" -1886- EXEC SQL INSERT INTO SEGUROS.HIST_PROP_FIDELIZ VALUES (:PROPFIDH-NUM-IDENTIFICACAO , :PROPFIDH-DATA-SITUACAO , :PROPFIDH-NSAS-SIVPF , :PROPFIDH-NSL , :PROPFIDH-SIT-PROPOSTA , :PROPFIDH-SIT-COBRANCA-SIVPF, :PROPFIDH-SIT-MOTIVO-SIVPF , :PROPFIDH-COD-EMPRESA-SIVPF , :PROPFIDH-COD-PRODUTO-SIVPF) END-EXEC. */

            var r0350_00_GERAR_HIST_FIDELIZ_DB_INSERT_1_Insert1 = new R0350_00_GERAR_HIST_FIDELIZ_DB_INSERT_1_Insert1()
            {
                PROPFIDH_NUM_IDENTIFICACAO = PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NUM_IDENTIFICACAO.ToString(),
                PROPFIDH_DATA_SITUACAO = PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_DATA_SITUACAO.ToString(),
                PROPFIDH_NSAS_SIVPF = PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NSAS_SIVPF.ToString(),
                PROPFIDH_NSL = PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NSL.ToString(),
                PROPFIDH_SIT_PROPOSTA = PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_PROPOSTA.ToString(),
                PROPFIDH_SIT_COBRANCA_SIVPF = PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_COBRANCA_SIVPF.ToString(),
                PROPFIDH_SIT_MOTIVO_SIVPF = PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_MOTIVO_SIVPF.ToString(),
                PROPFIDH_COD_EMPRESA_SIVPF = PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_COD_EMPRESA_SIVPF.ToString(),
                PROPFIDH_COD_PRODUTO_SIVPF = PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_COD_PRODUTO_SIVPF.ToString(),
            };

            R0350_00_GERAR_HIST_FIDELIZ_DB_INSERT_1_Insert1.Execute(r0350_00_GERAR_HIST_FIDELIZ_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0350_SAIDA*/

        [StopWatch]
        /*" R0450-00-OBTER-NSAS-MOV-CEF-SECTION */
        private void R0450_00_OBTER_NSAS_MOV_CEF_SECTION()
        {
            /*" -1933- MOVE 'R0450-00-OBTER-NSAS-CEF' TO PARAGRAFO. */
            _.Move("R0450-00-OBTER-NSAS-CEF", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1935- MOVE 'SELECT MAX ARQUIVOS-SIVPF' TO COMANDO. */
            _.Move("SELECT MAX ARQUIVOS-SIVPF", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1942- PERFORM R0450_00_OBTER_NSAS_MOV_CEF_DB_SELECT_1 */

            R0450_00_OBTER_NSAS_MOV_CEF_DB_SELECT_1();

            /*" -1945- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -1946- DISPLAY 'PF0711B - FIM ANORMAL' */
                _.Display($"PF0711B - FIM ANORMAL");

                /*" -1947- DISPLAY '          ERRO SELECT MAX ARQUIVOS-SIVPF' */
                _.Display($"          ERRO SELECT MAX ARQUIVOS-SIVPF");

                /*" -1949- DISPLAY '          SQLCODE........................ ' SQLCODE */
                _.Display($"          SQLCODE........................ {DB.SQLCODE}");

                /*" -1950- PERFORM R9977-00-FECHAR-ARQUIVOS */

                R9977_00_FECHAR_ARQUIVOS_SECTION();

                /*" -1952- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


            /*" -1955- MOVE ARQSIVPF-NSAS-SIVPF OF DCLARQUIVOS-SIVPF TO W-RH-NSAS OF W-REG-HEADER */
            _.Move(ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF, W_REG_HEADER.W_RH_NSAS);

            /*" -1957- ADD 1 TO W-RH-NSAS OF W-REG-HEADER */
            W_REG_HEADER.W_RH_NSAS.Value = W_REG_HEADER.W_RH_NSAS + 1;

            /*" -1960- MOVE W-RH-NSAS OF W-REG-HEADER TO W-NSAS-PRP-CEF */
            _.Move(W_REG_HEADER.W_RH_NSAS, WAREA_AUXILIAR.W_NSAS_PRP_CEF);

            /*" -1960- MOVE 1 TO W-GEROU-MOVTO-CEF. */
            _.Move(1, WREA88.W_GEROU_MOVTO_CEF);

        }

        [StopWatch]
        /*" R0450-00-OBTER-NSAS-MOV-CEF-DB-SELECT-1 */
        public void R0450_00_OBTER_NSAS_MOV_CEF_DB_SELECT_1()
        {
            /*" -1942- EXEC SQL SELECT VALUE(MAX(NSAS_SIVPF),0) INTO :DCLARQUIVOS-SIVPF.ARQSIVPF-NSAS-SIVPF FROM SEGUROS.ARQUIVOS_SIVPF WHERE SIGLA_ARQUIVO = 'STASASSE' AND SISTEMA_ORIGEM = 4 WITH UR END-EXEC. */

            var r0450_00_OBTER_NSAS_MOV_CEF_DB_SELECT_1_Query1 = new R0450_00_OBTER_NSAS_MOV_CEF_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0450_00_OBTER_NSAS_MOV_CEF_DB_SELECT_1_Query1.Execute(r0450_00_OBTER_NSAS_MOV_CEF_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.ARQSIVPF_NSAS_SIVPF, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0450_SAIDA*/

        [StopWatch]
        /*" R0460-00-GERAR-HEADER-SECTION */
        private void R0460_00_GERAR_HEADER_SECTION()
        {
            /*" -1971- MOVE 'R0460-00-GERAR-HEADER' TO PARAGRAFO. */
            _.Move("R0460-00-GERAR-HEADER", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1973- MOVE 'WRITE REG-HEADER' TO COMANDO. */
            _.Move("WRITE REG-HEADER", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1975- MOVE 2 TO W-HEADER-STA-CEF. */
            _.Move(2, WREA88.W_HEADER_STA_CEF);

            /*" -1978- MOVE 'H' TO W-RH-TIPO-REG OF W-REG-HEADER */
            _.Move("H", W_REG_HEADER.W_RH_TIPO_REG);

            /*" -1981- MOVE 'STASASSE' TO W-RH-NOME OF W-REG-HEADER */
            _.Move("STASASSE", W_REG_HEADER.W_RH_NOME);

            /*" -1982- MOVE W-DIA-MOVABE OF W-DTMOVABE1 TO W-DIA-TRABALHO */
            _.Move(W_DATAS.W_DTMOVABE1.W_DIA_MOVABE, W_DATAS.FILLER_4.W_DIA_TRABALHO);

            /*" -1983- MOVE W-MES-MOVABE OF W-DTMOVABE1 TO W-MES-TRABALHO */
            _.Move(W_DATAS.W_DTMOVABE1.W_MES_MOVABE, W_DATAS.FILLER_4.W_MES_TRABALHO);

            /*" -1985- MOVE W-ANO-MOVABE OF W-DTMOVABE1 TO W-ANO-TRABALHO */
            _.Move(W_DATAS.W_DTMOVABE1.W_ANO_MOVABE, W_DATAS.FILLER_4.W_ANO_TRABALHO);

            /*" -1988- MOVE W-DATA-TRABALHO TO W-RH-DATA-GERACAO OF W-REG-HEADER */
            _.Move(W_DATAS.W_DATA_TRABALHO, W_REG_HEADER.W_RH_DATA_GERACAO);

            /*" -1991- MOVE 4 TO W-RH-SIST-ORIGEM OF W-REG-HEADER */
            _.Move(4, W_REG_HEADER.W_RH_SIST_ORIGEM);

            /*" -1995- MOVE 1 TO W-RH-SIST-DESTINO OF W-REG-HEADER W-RH-TIPO-ARQUIVO OF W-REG-HEADER. */
            _.Move(1, W_REG_HEADER.W_RH_SIST_DESTINO, W_REG_HEADER.W_RH_TIPO_ARQUIVO);

            /*" -1996- WRITE REG-STA-CEF FROM W-REG-HEADER. */
            _.Move(W_REG_HEADER.GetMoveValues(), REG_STA_CEF);

            MOV_STA_CEF.Write(REG_STA_CEF.GetMoveValues().ToString());

            /*" -1996- WRITE REG-STA-FNAE FROM W-REG-HEADER. */
            _.Move(W_REG_HEADER.GetMoveValues(), REG_STA_FNAE);

            MOV_STA_FNAE.Write(REG_STA_FNAE.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0460_SAIDA*/

        [StopWatch]
        /*" R0763-00-LER-RCAP-SECTION */
        private void R0763_00_LER_RCAP_SECTION()
        {
            /*" -2006- MOVE 'R0763-00-LER-RCAP' TO PARAGRAFO. */
            _.Move("R0763-00-LER-RCAP", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2008- MOVE 'SELECT RCAP' TO COMANDO. */
            _.Move("SELECT RCAP", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2011- MOVE NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ TO RCAPS-NUM-CERTIFICADO OF DCLRCAPS. */
            _.Move(PROPFID.DCLPROPOSTA_FIDELIZ.NUM_PROPOSTA_SIVPF, RCAPS.DCLRCAPS.RCAPS_NUM_CERTIFICADO);

            /*" -2024- PERFORM R0763_00_LER_RCAP_DB_SELECT_1 */

            R0763_00_LER_RCAP_DB_SELECT_1();

            /*" -2027- IF SQLCODE EQUAL 00 */

            if (DB.SQLCODE == 00)
            {

                /*" -2029- MOVE 1 TO W-LEITURA-RCAP */
                _.Move(1, WREA88.W_LEITURA_RCAP);

                /*" -2030- IF VIND-RCAPS-AGE LESS ZERO */

                if (VIND_RCAPS_AGE < 00)
                {

                    /*" -2031- MOVE ZEROS TO RCAPS-AGE-COBRANCA OF DCLRCAPS */
                    _.Move(0, RCAPS.DCLRCAPS.RCAPS_AGE_COBRANCA);

                    /*" -2032- END-IF */
                }


                /*" -2033- ELSE */
            }
            else
            {


                /*" -2034- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2035- MOVE 2 TO W-LEITURA-RCAP */
                    _.Move(2, WREA88.W_LEITURA_RCAP);

                    /*" -2036- ELSE */
                }
                else
                {


                    /*" -2037- DISPLAY 'PF0711B - FIM ANORMAL' */
                    _.Display($"PF0711B - FIM ANORMAL");

                    /*" -2038- DISPLAY '          ERRO LEITURA RCAP ' SQLCODE */
                    _.Display($"          ERRO LEITURA RCAP {DB.SQLCODE}");

                    /*" -2040- DISPLAY '          NUMERO PROPOSTA   ' NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ */
                    _.Display($"          NUMERO PROPOSTA   {PROPFID.DCLPROPOSTA_FIDELIZ.NUM_PROPOSTA_SIVPF}");

                    /*" -2041- PERFORM R9977-00-FECHAR-ARQUIVOS */

                    R9977_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -2041- PERFORM R9999-00-FINALIZAR. */

                    R9999_00_FINALIZAR_SECTION();
                }

            }


        }

        [StopWatch]
        /*" R0763-00-LER-RCAP-DB-SELECT-1 */
        public void R0763_00_LER_RCAP_DB_SELECT_1()
        {
            /*" -2024- EXEC SQL SELECT VAL_RCAP , DATA_CADASTRAMENTO , DATA_MOVIMENTO , AGE_COBRANCA INTO :DCLRCAPS.RCAPS-VAL-RCAP , :DCLRCAPS.RCAPS-DATA-CADASTRAMENTO, :DCLRCAPS.RCAPS-DATA-MOVIMENTO , :DCLRCAPS.RCAPS-AGE-COBRANCA:VIND-RCAPS-AGE FROM SEGUROS.RCAPS WHERE NUM_CERTIFICADO = :DCLRCAPS.RCAPS-NUM-CERTIFICADO AND COD_OPERACAO BETWEEN 100 AND 199 WITH UR END-EXEC. */

            var r0763_00_LER_RCAP_DB_SELECT_1_Query1 = new R0763_00_LER_RCAP_DB_SELECT_1_Query1()
            {
                RCAPS_NUM_CERTIFICADO = RCAPS.DCLRCAPS.RCAPS_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = R0763_00_LER_RCAP_DB_SELECT_1_Query1.Execute(r0763_00_LER_RCAP_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.RCAPS_VAL_RCAP, RCAPS.DCLRCAPS.RCAPS_VAL_RCAP);
                _.Move(executed_1.RCAPS_DATA_CADASTRAMENTO, RCAPS.DCLRCAPS.RCAPS_DATA_CADASTRAMENTO);
                _.Move(executed_1.RCAPS_DATA_MOVIMENTO, RCAPS.DCLRCAPS.RCAPS_DATA_MOVIMENTO);
                _.Move(executed_1.RCAPS_AGE_COBRANCA, RCAPS.DCLRCAPS.RCAPS_AGE_COBRANCA);
                _.Move(executed_1.VIND_RCAPS_AGE, VIND_RCAPS_AGE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0763_99_SAIDA*/

        [StopWatch]
        /*" R2080-00-TRAILLER-CEF-SECTION */
        private void R2080_00_TRAILLER_CEF_SECTION()
        {
            /*" -2051- MOVE 'R2080-00-GERAR-CEF' TO PARAGRAFO. */
            _.Move("R2080-00-GERAR-CEF", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2053- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2055- MOVE SPACES TO REG-TRAILLER-STA. */
            _.Move("", LBFCT011.REG_TRAILLER_STA);

            /*" -2058- MOVE 'T' TO RT-TIPO-REG OF REG-TRAILLER-STA. */
            _.Move("T", LBFCT011.REG_TRAILLER_STA.RT_TIPO_REG);

            /*" -2061- MOVE 'STASASSE' TO RT-NOME-EMPRESA OF REG-TRAILLER-STA. */
            _.Move("STASASSE", LBFCT011.REG_TRAILLER_STA.RT_NOME_EMPRESA);

            /*" -2064- MOVE W-QTD-LD-MR-0 TO RT-QTDE-TIPO-0 OF REG-TRAILLER-STA. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_MR_0, LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_0);

            /*" -2067- MOVE W-QTD-PC-MR-1 TO RT-QTDE-TIPO-1 OF REG-TRAILLER-STA. */
            _.Move(WAREA_AUXILIAR.W_QTD_PC_MR_1, LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_1);

            /*" -2070- MOVE W-QTD-LD-MR-2 TO RT-QTDE-TIPO-2 OF REG-TRAILLER-STA. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_MR_2, LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_2);

            /*" -2073- MOVE W-QTD-LD-MR-3 TO RT-QTDE-TIPO-3 OF REG-TRAILLER-STA. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_MR_3, LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_3);

            /*" -2076- MOVE W-QTD-LD-MR-4 TO RT-QTDE-TIPO-4 OF REG-TRAILLER-STA. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_MR_4, LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_4);

            /*" -2079- MOVE W-QTD-LD-MR-5 TO RT-QTDE-TIPO-5 OF REG-TRAILLER-STA. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_MR_5, LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_5);

            /*" -2082- MOVE W-QTD-LD-MR-6 TO RT-QTDE-TIPO-6 OF REG-TRAILLER-STA. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_MR_6, LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_6);

            /*" -2085- MOVE W-QTD-LD-MR-7 TO RT-QTDE-TIPO-7 OF REG-TRAILLER-STA. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_MR_7, LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_7);

            /*" -2088- MOVE W-QTD-LD-MR-8 TO RT-QTDE-TIPO-8 OF REG-TRAILLER-STA. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_MR_8, LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_8);

            /*" -2092- MOVE W-QTD-LD-MR-9 TO RT-QTDE-TIPO-9 OF REG-TRAILLER-STA. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_MR_9, LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_9);

            /*" -2099- COMPUTE RT-QTDE-TOTAL OF REG-TRAILLER-STA = W-QTD-PC-MR-1 + W-QTD-LD-MR-2 + W-QTD-LD-MR-3 + W-QTD-LD-MR-4 + W-QTD-LD-MR-5 + W-QTD-LD-MR-6 + W-QTD-LD-MR-7 + W-QTD-LD-MR-8 + W-QTD-LD-MR-9 + W-QTD-LD-MR-0. */
            LBFCT011.REG_TRAILLER_STA.RT_QTDE_TOTAL.Value = WAREA_AUXILIAR.W_QTD_PC_MR_1 + WAREA_AUXILIAR.W_QTD_LD_MR_2 + WAREA_AUXILIAR.W_QTD_LD_MR_3 + WAREA_AUXILIAR.W_QTD_LD_MR_4 + WAREA_AUXILIAR.W_QTD_LD_MR_5 + WAREA_AUXILIAR.W_QTD_LD_MR_6 + WAREA_AUXILIAR.W_QTD_LD_MR_7 + WAREA_AUXILIAR.W_QTD_LD_MR_8 + WAREA_AUXILIAR.W_QTD_LD_MR_9 + WAREA_AUXILIAR.W_QTD_LD_MR_0;

            /*" -2100- WRITE REG-STA-CEF FROM REG-TRAILLER-STA. */
            _.Move(LBFCT011.REG_TRAILLER_STA.GetMoveValues(), REG_STA_CEF);

            MOV_STA_CEF.Write(REG_STA_CEF.GetMoveValues().ToString());

            /*" -2100- WRITE REG-STA-FNAE FROM REG-TRAILLER-STA. */
            _.Move(LBFCT011.REG_TRAILLER_STA.GetMoveValues(), REG_STA_FNAE);

            MOV_STA_FNAE.Write(REG_STA_FNAE.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2080_SAIDA*/

        [StopWatch]
        /*" R2090-00-ATUALIZAR-ARQSIVPF-SECTION */
        private void R2090_00_ATUALIZAR_ARQSIVPF_SECTION()
        {
            /*" -2110- MOVE 'R2090-00-ATUALIZAR-ARQSIVPF' TO PARAGRAFO. */
            _.Move("R2090-00-ATUALIZAR-ARQSIVPF", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2112- MOVE 'INSERT ARQUIVOS-SIVPF' TO COMANDO. */
            _.Move("INSERT ARQUIVOS-SIVPF", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2115- MOVE 'STASASSE' TO ARQSIVPF-SIGLA-ARQUIVO OF DCLARQUIVOS-SIVPF */
            _.Move("STASASSE", ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SIGLA_ARQUIVO);

            /*" -2117- MOVE 4 TO ARQSIVPF-SISTEMA-ORIGEM OF DCLARQUIVOS-SIVPF */
            _.Move(4, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SISTEMA_ORIGEM);

            /*" -2120- MOVE W-NSAS-PRP-CEF TO ARQSIVPF-NSAS-SIVPF OF DCLARQUIVOS-SIVPF */
            _.Move(WAREA_AUXILIAR.W_NSAS_PRP_CEF, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF);

            /*" -2124- MOVE SISTEMAS-DATA-MOV-ABERTO OF DCLSISTEMAS TO ARQSIVPF-DATA-PROCESSAMENTO OF DCLARQUIVOS-SIVPF ARQSIVPF-DATA-GERACAO OF DCLARQUIVOS-SIVPF */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_PROCESSAMENTO, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_GERACAO);

            /*" -2127- MOVE W-TOT-PC-MR TO ARQSIVPF-QTDE-REG-GER OF DCLARQUIVOS-SIVPF. */
            _.Move(WAREA_AUXILIAR.W_TOT_PC_MR, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_QTDE_REG_GER);

            /*" -2135- PERFORM R2090_00_ATUALIZAR_ARQSIVPF_DB_INSERT_1 */

            R2090_00_ATUALIZAR_ARQSIVPF_DB_INSERT_1();

            /*" -2138- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -2139- DISPLAY 'PF0711B - FIM ANORMAL' */
                _.Display($"PF0711B - FIM ANORMAL");

                /*" -2140- DISPLAY '          ERRO INSERT TABELA ARQUIVOS-SIVPF' */
                _.Display($"          ERRO INSERT TABELA ARQUIVOS-SIVPF");

                /*" -2142- DISPLAY '          SIGLA DO ARQIVO...............  ' ARQSIVPF-SIGLA-ARQUIVO OF DCLARQUIVOS-SIVPF */
                _.Display($"          SIGLA DO ARQIVO...............  {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SIGLA_ARQUIVO}");

                /*" -2144- DISPLAY '          NSAS SIVPF....................  ' ARQSIVPF-NSAS-SIVPF OF DCLARQUIVOS-SIVPF */
                _.Display($"          NSAS SIVPF....................  {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF}");

                /*" -2146- DISPLAY '          DATA GERACAO..................  ' ARQSIVPF-DATA-GERACAO OF DCLARQUIVOS-SIVPF */
                _.Display($"          DATA GERACAO..................  {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_GERACAO}");

                /*" -2148- DISPLAY '          QTDE. REGISTROS...............  ' ARQSIVPF-QTDE-REG-GER OF DCLARQUIVOS-SIVPF */
                _.Display($"          QTDE. REGISTROS...............  {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_QTDE_REG_GER}");

                /*" -2150- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -2151- PERFORM R9977-00-FECHAR-ARQUIVOS */

                R9977_00_FECHAR_ARQUIVOS_SECTION();

                /*" -2152- PERFORM R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION();

                /*" -2152- END-IF. */
            }


        }

        [StopWatch]
        /*" R2090-00-ATUALIZAR-ARQSIVPF-DB-INSERT-1 */
        public void R2090_00_ATUALIZAR_ARQSIVPF_DB_INSERT_1()
        {
            /*" -2135- EXEC SQL INSERT INTO SEGUROS.ARQUIVOS_SIVPF VALUES (:DCLARQUIVOS-SIVPF.ARQSIVPF-SIGLA-ARQUIVO, :DCLARQUIVOS-SIVPF.ARQSIVPF-SISTEMA-ORIGEM, :DCLARQUIVOS-SIVPF.ARQSIVPF-NSAS-SIVPF, :DCLARQUIVOS-SIVPF.ARQSIVPF-DATA-GERACAO, :DCLARQUIVOS-SIVPF.ARQSIVPF-QTDE-REG-GER, :DCLARQUIVOS-SIVPF.ARQSIVPF-DATA-PROCESSAMENTO) END-EXEC. */

            var r2090_00_ATUALIZAR_ARQSIVPF_DB_INSERT_1_Insert1 = new R2090_00_ATUALIZAR_ARQSIVPF_DB_INSERT_1_Insert1()
            {
                ARQSIVPF_SIGLA_ARQUIVO = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SIGLA_ARQUIVO.ToString(),
                ARQSIVPF_SISTEMA_ORIGEM = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SISTEMA_ORIGEM.ToString(),
                ARQSIVPF_NSAS_SIVPF = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF.ToString(),
                ARQSIVPF_DATA_GERACAO = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_GERACAO.ToString(),
                ARQSIVPF_QTDE_REG_GER = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_QTDE_REG_GER.ToString(),
                ARQSIVPF_DATA_PROCESSAMENTO = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_PROCESSAMENTO.ToString(),
            };

            R2090_00_ATUALIZAR_ARQSIVPF_DB_INSERT_1_Insert1.Execute(r2090_00_ATUALIZAR_ARQSIVPF_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2090_SAIDA*/

        [StopWatch]
        /*" R2100-00-TB-CONTROLE-SECTION */
        private void R2100_00_TB_CONTROLE_SECTION()
        {
            /*" -2164- MOVE RH-SIST-ORIGEM OF REG-HEADER-STA TO ARQSIVPF-SISTEMA-ORIGEM OF DCLARQUIVOS-SIVPF */
            _.Move(LBFCT011.REG_HEADER_STA.RH_SIST_ORIGEM, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SISTEMA_ORIGEM);

            /*" -2167- MOVE RH-NSAS OF REG-HEADER-STA TO ARQSIVPF-NSAS-SIVPF OF DCLARQUIVOS-SIVPF */
            _.Move(LBFCT011.REG_HEADER_STA.RH_NSAS, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF);

            /*" -2170- MOVE SISTEMAS-DATA-MOV-ABERTO OF DCLSISTEMAS TO ARQSIVPF-DATA-PROCESSAMENTO OF DCLARQUIVOS-SIVPF */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_PROCESSAMENTO);

            /*" -2172- MOVE RH-DATA-GERACAO OF REG-HEADER-STA TO W-DATA-TRABALHO */
            _.Move(LBFCT011.REG_HEADER_STA.RH_DATA_GERACAO, W_DATAS.W_DATA_TRABALHO);

            /*" -2174- MOVE W-DIA-TRABALHO TO W-DIA-SQL OF W-DATA-SQL1 */
            _.Move(W_DATAS.FILLER_4.W_DIA_TRABALHO, W_DATAS.W_DATA_SQL1.W_DIA_SQL);

            /*" -2176- MOVE W-MES-TRABALHO TO W-MES-SQL OF W-DATA-SQL1 */
            _.Move(W_DATAS.FILLER_4.W_MES_TRABALHO, W_DATAS.W_DATA_SQL1.W_MES_SQL);

            /*" -2178- MOVE W-ANO-TRABALHO TO W-ANO-SQL OF W-DATA-SQL1 */
            _.Move(W_DATAS.FILLER_4.W_ANO_TRABALHO, W_DATAS.W_DATA_SQL1.W_ANO_SQL);

            /*" -2181- MOVE '-' TO W-BARRA1 OF W-DATA-SQL1, W-BARRA2 OF W-DATA-SQL1 */
            _.Move("-", W_DATAS.W_DATA_SQL1.W_BARRA1_1);
            _.Move("-", W_DATAS.W_DATA_SQL1.W_BARRA2_1);


            /*" -2184- MOVE W-DATA-SQL TO ARQSIVPF-DATA-GERACAO OF DCLARQUIVOS-SIVPF */
            _.Move(W_DATAS.W_DATA_SQL, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_GERACAO);

            /*" -2187- MOVE W-TOT-PC-MR TO ARQSIVPF-QTDE-REG-GER OF DCLARQUIVOS-SIVPF. */
            _.Move(WAREA_AUXILIAR.W_TOT_PC_MR, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_QTDE_REG_GER);

            /*" -2195- PERFORM R2100_00_TB_CONTROLE_DB_INSERT_1 */

            R2100_00_TB_CONTROLE_DB_INSERT_1();

            /*" -2198- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -2199- DISPLAY 'PF0711B - FIM ANORMAL' */
                _.Display($"PF0711B - FIM ANORMAL");

                /*" -2200- DISPLAY '          ERRO INSERT TABELA ARQUIVOS-SIVPF' */
                _.Display($"          ERRO INSERT TABELA ARQUIVOS-SIVPF");

                /*" -2202- DISPLAY '          SIGLA DO ARQIVO...............  ' ARQSIVPF-SIGLA-ARQUIVO OF DCLARQUIVOS-SIVPF */
                _.Display($"          SIGLA DO ARQIVO...............  {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SIGLA_ARQUIVO}");

                /*" -2204- DISPLAY '          NSAS SIVPF....................  ' ARQSIVPF-NSAS-SIVPF OF DCLARQUIVOS-SIVPF */
                _.Display($"          NSAS SIVPF....................  {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF}");

                /*" -2206- DISPLAY '          DATA GERACAO..................  ' ARQSIVPF-DATA-GERACAO OF DCLARQUIVOS-SIVPF */
                _.Display($"          DATA GERACAO..................  {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_GERACAO}");

                /*" -2208- DISPLAY '          QTDE. REGISTROS...............  ' ARQSIVPF-QTDE-REG-GER OF DCLARQUIVOS-SIVPF */
                _.Display($"          QTDE. REGISTROS...............  {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_QTDE_REG_GER}");

                /*" -2210- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -2211- PERFORM R9977-00-FECHAR-ARQUIVOS */

                R9977_00_FECHAR_ARQUIVOS_SECTION();

                /*" -2212- PERFORM R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION();

                /*" -2212- END-IF. */
            }


        }

        [StopWatch]
        /*" R2100-00-TB-CONTROLE-DB-INSERT-1 */
        public void R2100_00_TB_CONTROLE_DB_INSERT_1()
        {
            /*" -2195- EXEC SQL INSERT INTO SEGUROS.ARQUIVOS_SIVPF VALUES (:DCLARQUIVOS-SIVPF.ARQSIVPF-SIGLA-ARQUIVO, :DCLARQUIVOS-SIVPF.ARQSIVPF-SISTEMA-ORIGEM, :DCLARQUIVOS-SIVPF.ARQSIVPF-NSAS-SIVPF, :DCLARQUIVOS-SIVPF.ARQSIVPF-DATA-GERACAO, :DCLARQUIVOS-SIVPF.ARQSIVPF-QTDE-REG-GER, :DCLARQUIVOS-SIVPF.ARQSIVPF-DATA-PROCESSAMENTO) END-EXEC. */

            var r2100_00_TB_CONTROLE_DB_INSERT_1_Insert1 = new R2100_00_TB_CONTROLE_DB_INSERT_1_Insert1()
            {
                ARQSIVPF_SIGLA_ARQUIVO = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SIGLA_ARQUIVO.ToString(),
                ARQSIVPF_SISTEMA_ORIGEM = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SISTEMA_ORIGEM.ToString(),
                ARQSIVPF_NSAS_SIVPF = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF.ToString(),
                ARQSIVPF_DATA_GERACAO = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_GERACAO.ToString(),
                ARQSIVPF_QTDE_REG_GER = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_QTDE_REG_GER.ToString(),
                ARQSIVPF_DATA_PROCESSAMENTO = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_PROCESSAMENTO.ToString(),
            };

            R2100_00_TB_CONTROLE_DB_INSERT_1_Insert1.Execute(r2100_00_TB_CONTROLE_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2100_SAIDA*/

        [StopWatch]
        /*" R9966-00-GERAR-TOTAIS-SECTION */
        private void R9966_00_GERAR_TOTAIS_SECTION()
        {
            /*" -2225- DISPLAY ' ' */
            _.Display($" ");

            /*" -2226- DISPLAY 'PF0711B - FIM NORMAL' */
            _.Display($"PF0711B - FIM NORMAL");

            /*" -2228- DISPLAY '          ARQUIVO PROCESSADO..................  ' RH-NSAS OF REG-HEADER-STA */
            _.Display($"          ARQUIVO PROCESSADO..................  {LBFCT011.REG_HEADER_STA.RH_NSAS}");

            /*" -2230- DISPLAY '          ESTE ARQUIVO FOI GERADO EM..........  ' RH-DATA-GERACAO OF REG-HEADER-STA */
            _.Display($"          ESTE ARQUIVO FOI GERADO EM..........  {LBFCT011.REG_HEADER_STA.RH_DATA_GERACAO}");

            /*" -2232- DISPLAY '          TOTAL DE REGISTROS LIDOS............  ' W-LIDO-MOVTO-MR */
            _.Display($"          TOTAL DE REGISTROS LIDOS............  {WAREA_AUXILIAR.W_LIDO_MOVTO_MR}");

            /*" -2234- DISPLAY '          TOTAL DE REGISTROS PROCESSADOS......  ' W-TOT-PC-MR */
            _.Display($"          TOTAL DE REGISTROS PROCESSADOS......  {WAREA_AUXILIAR.W_TOT_PC_MR}");

            /*" -2236- DISPLAY '          TOTAL DE PROPOSTAS NAO CADASTRADAS..  ' W-QTD-NP-MR-1 */
            _.Display($"          TOTAL DE PROPOSTAS NAO CADASTRADAS..  {WAREA_AUXILIAR.W_QTD_NP_MR_1}");

            /*" -2238- DISPLAY '          STATUS ENVIADOS A CEF ANTERIORMENTE.  ' W-QTD-ST-MR-1 */
            _.Display($"          STATUS ENVIADOS A CEF ANTERIORMENTE.  {WAREA_AUXILIAR.W_QTD_ST_MR_1}");

            /*" -2238- DISPLAY ' ' . */
            _.Display($" ");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9966_SAIDA*/

        [StopWatch]
        /*" R9977-00-FECHAR-ARQUIVOS-SECTION */
        private void R9977_00_FECHAR_ARQUIVOS_SECTION()
        {
            /*" -2255- CLOSE MOV-STA-MR MOV-STA-CEF MOV-STA-FNAE. */
            MOV_STA_MR.Close();
            MOV_STA_CEF.Close();
            MOV_STA_FNAE.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9977_SAIDA*/

        [StopWatch]
        /*" R9980-00-GERAR-RELATORIO-SECTION */
        private void R9980_00_GERAR_RELATORIO_SECTION()
        {
            /*" -2266- MOVE 'R9980-00-GERAR-RELATORIO' TO PARAGRAFO. */
            _.Move("R9980-00-GERAR-RELATORIO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2268- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2270- OPEN OUTPUT RPF0711B */
            RPF0711B.Open(REG_RPF0711B);

            /*" -2274- PERFORM R9981-00-INCONSISTENCIA VARYING W-INDICE-2 FROM 1 BY 1 UNTIL W-INDICE-2 GREATER W-INDICE-1. */

            for (WAREA_AUXILIAR.W_INDICE_2.Value = 1; !(WAREA_AUXILIAR.W_INDICE_2 > WAREA_AUXILIAR.W_INDICE_1); WAREA_AUXILIAR.W_INDICE_2.Value += 1)
            {

                R9981_00_INCONSISTENCIA_SECTION();
            }

            /*" -2274- CLOSE RPF0711B. */
            RPF0711B.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9980_SAIDA*/

        [StopWatch]
        /*" R9981-00-INCONSISTENCIA-SECTION */
        private void R9981_00_INCONSISTENCIA_SECTION()
        {
            /*" -2285- MOVE 'R9981-00-INCONSISTENCIA' TO PARAGRAFO. */
            _.Move("R9981-00-INCONSISTENCIA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2287- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2290- IF W-TB-NUM-PROPOSTA(W-INDICE-2) NOT NUMERIC OR W-TB-NUM-PROPOSTA(W-INDICE-2) EQUAL ZEROS */

            if (!AREA_DAS_TABELAS.W_TAB_CONSISTENCIA.FILLER_44[WAREA_AUXILIAR.W_INDICE_2].W_TB_NUM_PROPOSTA.IsNumeric() || AREA_DAS_TABELAS.W_TAB_CONSISTENCIA.FILLER_44[WAREA_AUXILIAR.W_INDICE_2].W_TB_NUM_PROPOSTA == 00)
            {

                /*" -2292- COMPUTE W-INDICE-2 = W-INDICE-1 + 1 */
                WAREA_AUXILIAR.W_INDICE_2.Value = WAREA_AUXILIAR.W_INDICE_1 + 1;

                /*" -2295- GO TO R9981-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R9981_SAIDA*/ //GOTO
                return;
            }


            /*" -2297- MOVE W-TB-NUM-PROPOSTA(W-INDICE-2) TO LC06-NUM-PROPOSTA */
            _.Move(AREA_DAS_TABELAS.W_TAB_CONSISTENCIA.FILLER_44[WAREA_AUXILIAR.W_INDICE_2].W_TB_NUM_PROPOSTA, LC00.LC06.LC06_NUM_PROPOSTA);

            /*" -2299- MOVE W-TB-SIT-PROPOSTA(W-INDICE-2) TO LC06-SITUACAO */
            _.Move(AREA_DAS_TABELAS.W_TAB_CONSISTENCIA.FILLER_44[WAREA_AUXILIAR.W_INDICE_2].W_TB_SIT_PROPOSTA, LC00.LC06.LC06_SITUACAO);

            /*" -2300- MOVE W-TB-DT-SITUACAO (W-INDICE-2) TO W-DATA-TRABALHO */
            _.Move(AREA_DAS_TABELAS.W_TAB_CONSISTENCIA.FILLER_44[WAREA_AUXILIAR.W_INDICE_2].W_TB_DT_SITUACAO, W_DATAS.W_DATA_TRABALHO);

            /*" -2301- MOVE W-DIA-TRABALHO TO W-DIA-SITUACAO OF W-DATA-SIT-RD */
            _.Move(W_DATAS.FILLER_4.W_DIA_TRABALHO, W_DATAS.W_DATA_SIT_RD.W_DIA_SITUACAO);

            /*" -2302- MOVE W-MES-TRABALHO TO W-MES-SITUACAO OF W-DATA-SIT-RD */
            _.Move(W_DATAS.FILLER_4.W_MES_TRABALHO, W_DATAS.W_DATA_SIT_RD.W_MES_SITUACAO);

            /*" -2303- MOVE W-ANO-TRABALHO TO W-ANO-SITUACAO OF W-DATA-SIT-RD */
            _.Move(W_DATAS.FILLER_4.W_ANO_TRABALHO, W_DATAS.W_DATA_SIT_RD.W_ANO_SITUACAO);

            /*" -2306- MOVE '/' TO W-BARRA1 OF W-DATA-SIT-RD W-BARRA2 OF W-DATA-SIT-RD. */
            _.Move("/", W_DATAS.W_DATA_SIT_RD.W_BARRA1_2);
            _.Move("/", W_DATAS.W_DATA_SIT_RD.W_BARRA2_2);


            /*" -2308- MOVE W-DATA-SITUACAO TO LC06-DATA-SITUACAO */
            _.Move(W_DATAS.W_DATA_SITUACAO, LC00.LC06.LC06_DATA_SITUACAO);

            /*" -2310- MOVE W-TB-COD-DESCRI (W-INDICE-2) TO W-INDICE-ERRO. */
            _.Move(AREA_DAS_TABELAS.W_TAB_CONSISTENCIA.FILLER_44[WAREA_AUXILIAR.W_INDICE_2].W_TB_COD_DESCRI, WAREA_AUXILIAR.W_INDICE_ERRO);

            /*" -2312- MOVE W-TB-DESCRI-ERRO(W-INDICE-ERRO) TO LC06-DESCRICAO */
            _.Move(AREA_DAS_TABELAS.W_TAB_DESCRICAO_RD[WAREA_AUXILIAR.W_INDICE_ERRO].W_TB_DESCRI_ERRO, LC00.LC06.LC06_DESCRICAO);

            /*" -2313- IF W-CONT-LINHAS GREATER 60 */

            if (WAREA_AUXILIAR.W_CONT_LINHAS > 60)
            {

                /*" -2315- PERFORM R9982-00-GRAVA-CABECALHO. */

                R9982_00_GRAVA_CABECALHO_SECTION();
            }


            /*" -2317- WRITE REG-RPF0711B FROM LC06 AFTER 1. */
            _.Move(LC00.LC06.GetMoveValues(), REG_RPF0711B);

            RPF0711B.Write(REG_RPF0711B.GetMoveValues().ToString());

            /*" -2317- ADD 1 TO W-CONT-LINHAS. */
            WAREA_AUXILIAR.W_CONT_LINHAS.Value = WAREA_AUXILIAR.W_CONT_LINHAS + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9981_SAIDA*/

        [StopWatch]
        /*" R9982-00-GRAVA-CABECALHO-SECTION */
        private void R9982_00_GRAVA_CABECALHO_SECTION()
        {
            /*" -2329- MOVE 'R9982-00-GRAVA-CABECALHO' TO PARAGRAFO. */
            _.Move("R9982-00-GRAVA-CABECALHO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2331- MOVE 'WRITE' TO COMANDO. */
            _.Move("WRITE", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2333- ADD 1 TO LC01-PAGINA. */
            LC00.LC01.LC01_PAGINA.Value = LC00.LC01.LC01_PAGINA + 1;

            /*" -2335- ACCEPT WS-TIME FROM TIME. */
            _.Move(_.AcceptDate("TIME"), WS_TIME);

            /*" -2336- MOVE WS-TIME-N TO WS-TIME-EDIT */
            _.Move(WS_TIME.WS_TIME_N, WS_TIME_EDIT);

            /*" -2338- MOVE WS-TIME-EDIT TO LC03-HORA. */
            _.Move(WS_TIME_EDIT, LC00.LC03.LC03_HORA);

            /*" -2340- MOVE W-NSAS-MR TO LC04-NSAS-SIVPF. */
            _.Move(WAREA_AUXILIAR.W_NSAS_MR, LC00.LC04.LC04_NSAS_SIVPF);

            /*" -2343- MOVE '/' TO W-BARRA1 OF W-DTMOVABE-I1, W-BARRA2 OF W-DTMOVABE-I1. */
            _.Move("/", W_DATAS.W_DTMOVABE_I1.W_BARRA1_0);
            _.Move("/", W_DATAS.W_DTMOVABE_I1.W_BARRA2_0);


            /*" -2345- MOVE W-DTMOVABE-I TO LC02-DATA. */
            _.Move(W_DATAS.W_DTMOVABE_I, LC00.LC02.LC02_DATA);

            /*" -2346- MOVE RH-DATA-GERACAO OF REG-HEADER-STA TO W-DATA-TRABALHO */
            _.Move(LBFCT011.REG_HEADER_STA.RH_DATA_GERACAO, W_DATAS.W_DATA_TRABALHO);

            /*" -2347- MOVE W-DIA-TRABALHO TO W-DIA-MOVABE OF W-DTMOVABE-I1 */
            _.Move(W_DATAS.FILLER_4.W_DIA_TRABALHO, W_DATAS.W_DTMOVABE_I1.W_DIA_MOVABE_0);

            /*" -2348- MOVE W-MES-TRABALHO TO W-MES-MOVABE OF W-DTMOVABE-I1 */
            _.Move(W_DATAS.FILLER_4.W_MES_TRABALHO, W_DATAS.W_DTMOVABE_I1.W_MES_MOVABE_0);

            /*" -2350- MOVE W-ANO-TRABALHO TO W-ANO-MOVABE OF W-DTMOVABE-I1 */
            _.Move(W_DATAS.FILLER_4.W_ANO_TRABALHO, W_DATAS.W_DTMOVABE_I1.W_ANO_MOVABE_0);

            /*" -2352- MOVE W-DTMOVABE-I TO LC04-DATA-GERACAO. */
            _.Move(W_DATAS.W_DTMOVABE_I, LC00.LC04.LC04_DATA_GERACAO);

            /*" -2354- MOVE ALL '-' TO LC07-FILLER. */
            _.MoveAll("-", LC00.LC07.LC07_FILLER);

            /*" -2355- WRITE REG-RPF0711B FROM LC01 AFTER PAGE. */
            _.Move(LC00.LC01.GetMoveValues(), REG_RPF0711B);

            RPF0711B.Write(REG_RPF0711B.GetMoveValues().ToString());

            /*" -2356- WRITE REG-RPF0711B FROM LC02 AFTER 1 */
            _.Move(LC00.LC02.GetMoveValues(), REG_RPF0711B);

            RPF0711B.Write(REG_RPF0711B.GetMoveValues().ToString());

            /*" -2357- WRITE REG-RPF0711B FROM LC03 AFTER 1 */
            _.Move(LC00.LC03.GetMoveValues(), REG_RPF0711B);

            RPF0711B.Write(REG_RPF0711B.GetMoveValues().ToString());

            /*" -2358- WRITE REG-RPF0711B FROM LC04 AFTER 2 */
            _.Move(LC00.LC04.GetMoveValues(), REG_RPF0711B);

            RPF0711B.Write(REG_RPF0711B.GetMoveValues().ToString());

            /*" -2360- WRITE REG-RPF0711B FROM LC07 AFTER 1 */
            _.Move(LC00.LC07.GetMoveValues(), REG_RPF0711B);

            RPF0711B.Write(REG_RPF0711B.GetMoveValues().ToString());

            /*" -2362- WRITE REG-RPF0711B FROM LC05 AFTER 2. */
            _.Move(LC00.LC05.GetMoveValues(), REG_RPF0711B);

            RPF0711B.Write(REG_RPF0711B.GetMoveValues().ToString());

            /*" -2362- MOVE 8 TO W-CONT-LINHAS. */
            _.Move(8, WAREA_AUXILIAR.W_CONT_LINHAS);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9982_SAIDA*/

        [StopWatch]
        /*" R9999-00-FINALIZAR-SECTION */
        private void R9999_00_FINALIZAR_SECTION()
        {
            /*" -2376- DISPLAY ' ' */
            _.Display($" ");

            /*" -2377- IF W-FIM-MOVTO-MR = 'FIM' */

            if (WAREA_AUXILIAR.W_FIM_MOVTO_MR == "FIM")
            {

                /*" -2378- DISPLAY 'PF0711B - FIM NORMAL ' */
                _.Display($"PF0711B - FIM NORMAL ");

                /*" -2379- MOVE 'COMMIT WORK' TO COMANDO */
                _.Move("COMMIT WORK", WABEND.LOCALIZA_ABEND_2.COMANDO);

                /*" -2379- EXEC SQL COMMIT WORK END-EXEC */

                DatabaseConnection.Instance.CommitTransaction();

                /*" -2381- MOVE 0 TO RETURN-CODE */
                _.Move(0, RETURN_CODE);

                /*" -2382- ELSE */
            }
            else
            {


                /*" -2383- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, WABEND.WSQLCODE);

                /*" -2384- MOVE SQLERRD(1) TO WSQLERRD1 */
                _.Move(DB.SQLERRD[1], WABEND.WSQLERRD1);

                /*" -2385- MOVE SQLERRD(2) TO WSQLERRD2 */
                _.Move(DB.SQLERRD[2], WABEND.WSQLERRD2);

                /*" -2386- DISPLAY WABEND */
                _.Display(WABEND);

                /*" -2387- DISPLAY '*** PF0711B *** ROLLBACK EM ANDAMENTO ...' */
                _.Display($"*** PF0711B *** ROLLBACK EM ANDAMENTO ...");

                /*" -2388- MOVE 'ROLLBACK WORK' TO COMANDO */
                _.Move("ROLLBACK WORK", WABEND.LOCALIZA_ABEND_2.COMANDO);

                /*" -2388- EXEC SQL ROLLBACK WORK END-EXEC */

                DatabaseConnection.Instance.RollbackTransaction();

                /*" -2390- MOVE 99 TO RETURN-CODE */
                _.Move(99, RETURN_CODE);

                /*" -2392- END-IF */
            }


            /*" -2392- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9999_SAIDA*/
    }
}