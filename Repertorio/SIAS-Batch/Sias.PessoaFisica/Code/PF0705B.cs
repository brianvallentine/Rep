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
using Sias.PessoaFisica.DB2.PF0705B;

namespace Code
{
    public class PF0705B
    {
        public bool IsCall { get; set; }

        public PF0705B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      ******************************************************************      */
        /*"      ******************************************************************      */
        /*"      *                                                                *      */
        /*"      *   FUNCAO ...............  GERA ARQUIVO DE STATUS DAS PROPOSTAS *      */
        /*"      *                           REJEITADAS DE VIDA.                  *      */
        /*"      *   ANALISTA .............  LUIZ CARLOS.                         *      */
        /*"      *   PROGRAMA .............  PF0705B                              *      */
        /*"      *   DATA .................  08/11/2000.                          *      */
        /*"      *   REVISAO E AJUSTES.....  REGINALDO SILVA                      *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.16  *   VERSAO 16 - DEMANDA 402.982                                  *      */
        /*"      *             - SUBSTITUIR CONSULTA DA TABELA ERROS_PROP_VIDAZUL *      */
        /*"      *               PELA NA NOVA TABELA VG_CRITICA_PROPOSTA          *      */
        /*"      *             - SUBSTITUI CONSULTA DA TABELA ERROS_VIDAZUL PELA  *      */
        /*"      *               NOVA TABELA VG_DM_MSG_CRITICA                    *      */
        /*"      *                                                                *      */
        /*"      *   EM 14/02/2023 - ELIERMES OLIVEIRA                            *      */
        /*"      *                                        PROCURE POR V.16        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 15             AJUSTES TRATAMENTO MOTIVOS DE REJEICAO.  *      */
        /*"      *                       CONVERTER ERROS_VIDAZUL EM ERRO_SIVPF P/ *      */
        /*"      *                       SENSIBILIZAR MOTIVO DO DECLINIO.         *      */
        /*"      *                       COMTEMPLA REVISAO DAS VERSOES 11,12,13,14*      */
        /*"      * HISTORIA              196803                                   *      */
        /*"      *                                                                *      */
        /*"      * PROCURE V.15          BRICE HO.                                *      */
        /*"      *                       15/07/2019                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 14             ALTERACAO NO ENVIO DOS MOTIVOS DE DECLI- *      */
        /*"      * DEMANDA 196803        NIOS ENVIADOS AO SIGPF.                  *      */
        /*"      *                                                                *      */
        /*"      * PROCURE V.14          ANDRES RIERA                             *      */
        /*"      *                       19/06/2019                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 13             ALTERACAO NA QUERY SEGUROS.RELATORIOS    *      */
        /*"      * DEMANDA 196803        VOLTAR CONFORME VERS�O 11.               *      */
        /*"      *                                                                *      */
        /*"      * PROCURE V.13          ANDRES RIERA                             *      */
        /*"      *                       06/05/2019                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 12             ALTERACAO NO ENVIO DOS MOTIVOS DE DECLI- *      */
        /*"      * DEMANDA 196803        NIOS ENVIADOS AO SIGPF.                  *      */
        /*"      *                                                                *      */
        /*"      * PROCURE V.12          ANDRES RIERA                             *      */
        /*"      *                       26/04/2019                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 11             ALTERACAO NO ENVIO DOS MOTIVOS DE DECLI- *      */
        /*"      * DEMANDA 2458          NIOS ENVIADOS AO SIGPF.                  *      */
        /*"      *                                                                *      */
        /*"      * PROCURE V.11          MAURICIO CUNHA                           *      */
        /*"      *                       28/09/2018                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 10             PROPOSTA REJEITADA NAO EXISTE NA TABELA  *      */
        /*"      * ATENDE CADMUS 115246  DE PROPOSTA_VA                           *      */
        /*"      *                                                                *      */
        /*"      * PROCURE V.10          REGINALDO SILVA                          *      */
        /*"      *                       28/05/2015                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 09             AJUSTE INSERT HIST_PROP_FIDELIZ          *      */
        /*"      * ATENDE CADMUS 88764   COD-EMPRESA    E   COD-PRODUTO           *      */
        /*"      *                                                                *      */
        /*"      * PROCURE V.09          REGINALDO SILVA                          *      */
        /*"      *                       11/11/2013                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 8 - ATENDE CADMUS 40619                                 *      */
        /*"      *                                                                *      */
        /*"      * 08/04/2010 PROCURE POR V.08 - EDSON MARQUES.                   *      */
        /*"      * OBJETIVO - IDENTIFICAR E TRATAR AS REJEI��ES DA VENDA NA       *      */
        /*"      *            CENTRAL DO GCS.                                     *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 7 - ATENDE CADMUS32886                                  *      */
        /*"      *                                                                *      */
        /*"      * 18/11/2009 PROCURE POR V.07 - EDILANA CERQUEIRA.               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 6 - RETIRA LIMITACAO DE REGISTROS PROCESSADOS           *      */
        /*"      *                                                                *      */
        /*"      * 21/07/2009 PROCURE POR V.06 - EDILANA CERQUEIRA.               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 5 - ALTERA VARIAVEIS HOST - HIST-PROP-FIDELIZ           *      */
        /*"      *                                                                *      */
        /*"      * 22/05/2009                  - EDILANA CERQUEIRA.               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 4 - NAO GERAR REGISTRO TIPO '8' COM TP-LANCAMENTO = 237 *      */
        /*"      *                                                                *      */
        /*"      * 14/07/2008 PROCURE POR V.04 - LUCIA FREIRE.                    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 3 - NAO GERAR REGISTRO TIPO '8' QUANDO REJEICAO DO VIDA *      */
        /*"      *            DA GENTE COMERCIALIZADO NA GITEL (PGTO AGENDADO).   *      */
        /*"      *                                                                *      */
        /*"      * 04/06/2008 PROCURE POR V.03 - LUCIA FREIRE.                    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 2 - DESPREZAR COD_PRODUTO_SIVPF IGUAL A 48. TRATA-SE DA *      */
        /*"      *            INTERNALIZACAO DE APOLICE ESPECIFICA DE VIDA.       *      */
        /*"      *                                                                *      */
        /*"      * 27/11/2007 PROCURE POR V.02 - MAURICIO LINKE.                  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 01 (V.01) - EM 10/01/2007                               *      */
        /*"      * PASSOU A GERAR O TIPO DE REGISTRO '8' - NOVO MODELO DE         *      */
        /*"      * MENSURACAO DE METAS (BLOCO 33).                                *      */
        /*"      *----------------------------------------------------------------*      */
        #endregion


        #region VARIABLES

        public FileBasis _MOVTO_STA_SASSE { get; set; } = new FileBasis(new PIC("X", "100", "X(100)"));

        public FileBasis MOVTO_STA_SASSE
        {
            get
            {
                _.Move(REG_STA_SASSE, _MOVTO_STA_SASSE); VarBasis.RedefinePassValue(REG_STA_SASSE, _MOVTO_STA_SASSE, REG_STA_SASSE); return _MOVTO_STA_SASSE;
            }
        }
        /*"01   REG-STA-SASSE                      PIC X(100).*/
        public StringBasis REG_STA_SASSE { get; set; } = new StringBasis(new PIC("X", "100", "X(100)."), @"");

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"01  PARAMETROS.*/
        public PF0705B_PARAMETROS PARAMETROS { get; set; } = new PF0705B_PARAMETROS();
        public class PF0705B_PARAMETROS : VarBasis
        {
            /*"    05 LK-APOLICE                     PIC S9(013) COMP-3.*/
            public IntBasis LK_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
            /*"    05 LK-SUBGRUPO                    PIC S9(004) COMP.*/
            public IntBasis LK_SUBGRUPO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05 LK-IDADE                       PIC S9(004) COMP.*/
            public IntBasis LK_IDADE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05 LK-NASCIMENTO.*/
            public PF0705B_LK_NASCIMENTO LK_NASCIMENTO { get; set; } = new PF0705B_LK_NASCIMENTO();
            public class PF0705B_LK_NASCIMENTO : VarBasis
            {
                /*"       10 LK-DATA-NASCIMENTO          PIC  9(008).*/
                public IntBasis LK_DATA_NASCIMENTO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"    05 LK-SALARIO                     PIC S9(013)V99 COMP-3.*/
            }
            public DoubleBasis LK_SALARIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 LK-COBT-MORTE-NATURAL          PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_COBT_MORTE_NATURAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 LK-COBT-MORTE-ACIDENTAL        PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_COBT_MORTE_ACIDENTAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 LK-COBT-INV-PERMANENTE         PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_COBT_INV_PERMANENTE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 LK-COBT-INV-POR-ACIDENTE       PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_COBT_INV_POR_ACIDENTE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 LK-COBT-ASS-MEDICA             PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_COBT_ASS_MEDICA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 LK-COBT-DIARIA-HOSPITALAR      PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_COBT_DIARIA_HOSPITALAR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 LK-COBT-DIARIA-INTERNACAO      PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_COBT_DIARIA_INTERNACAO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 LK-PURO-MORTE-NATURAL          PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_PURO_MORTE_NATURAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 LK-PURO-MORTE-ACIDENTAL        PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_PURO_MORTE_ACIDENTAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 LK-PURO-INV-PERMANENTE         PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_PURO_INV_PERMANENTE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 LK-PURO-ASS-MEDICA             PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_PURO_ASS_MEDICA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 LK-PURO-DIARIA-HOSPITALAR      PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_PURO_DIARIA_HOSPITALAR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 LK-PURO-DIARIA-INTERNACAO      PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_PURO_DIARIA_INTERNACAO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 LK-PREM-MORTE-NATURAL          PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_PREM_MORTE_NATURAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 LK-PREM-ACIDENTES-PESSOAIS     PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_PREM_ACIDENTES_PESSOAIS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 LK-PREM-TOTAL                  PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_PREM_TOTAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 LK-RETURN-CODE                 PIC S9(003)    COMP-3.*/
            public IntBasis LK_RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"));
            /*"    05 LK-MENSAGEM                    PIC  X(077).*/
            public StringBasis LK_MENSAGEM { get; set; } = new StringBasis(new PIC("X", "77", "X(077)."), @"");
            /*"01      W01DIGCERT.*/
        }
        public PF0705B_W01DIGCERT W01DIGCERT { get; set; } = new PF0705B_W01DIGCERT();
        public class PF0705B_W01DIGCERT : VarBasis
        {
            /*"    05  WCERTIFICADO    PIC  9(015)        VALUE  0.*/
            public IntBasis WCERTIFICADO { get; set; } = new IntBasis(new PIC("9", "15", "9(015)"));
            /*"    05  WNUMERO         PIC S9(004)  COMP  VALUE +15.*/
            public IntBasis WNUMERO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), +15);
            /*"    05  WDIG            PIC  X(001)  VALUE SPACES.*/
            public StringBasis WDIG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"01      W-NUM-PROPOSTA-NOVA           PIC  9(014).*/
        }
        public IntBasis W_NUM_PROPOSTA_NOVA { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
        /*"01      CANAL  REDEFINES W-NUM-PROPOSTA-NOVA.*/
        private _REDEF_PF0705B_CANAL _canal { get; set; }
        public _REDEF_PF0705B_CANAL CANAL
        {
            get { _canal = new _REDEF_PF0705B_CANAL(); _.Move(W_NUM_PROPOSTA_NOVA, _canal); VarBasis.RedefinePassValue(W_NUM_PROPOSTA_NOVA, _canal, W_NUM_PROPOSTA_NOVA); _canal.ValueChanged += () => { _.Move(_canal, W_NUM_PROPOSTA_NOVA); }; return _canal; }
            set { VarBasis.RedefinePassValue(value, _canal, W_NUM_PROPOSTA_NOVA); }
        }  //Redefines
        public class _REDEF_PF0705B_CANAL : VarBasis
        {
            /*"    05  W-NUM-PROPOSTA-ATUAL          PIC  9(013).*/
            public IntBasis W_NUM_PROPOSTA_ATUAL { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
            /*"    05  W-DV-PROPOSTA-NOVA            PIC  9(001).*/
            public IntBasis W_DV_PROPOSTA_NOVA { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"01  WAREA-AUXILIAR.*/

            public _REDEF_PF0705B_CANAL()
            {
                W_NUM_PROPOSTA_ATUAL.ValueChanged += OnValueChanged;
                W_DV_PROPOSTA_NOVA.ValueChanged += OnValueChanged;
            }

        }
        public PF0705B_WAREA_AUXILIAR WAREA_AUXILIAR { get; set; } = new PF0705B_WAREA_AUXILIAR();
        public class PF0705B_WAREA_AUXILIAR : VarBasis
        {
            /*"    05  W-FIM-MOVTO-FIDELIZ           PIC X(003)  VALUE SPACES.*/
            public StringBasis W_FIM_MOVTO_FIDELIZ { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"    05  W-IND-IOF                     PIC S9(01)V9(4) COMP-3.*/
            public DoubleBasis W_IND_IOF { get; set; } = new DoubleBasis(new PIC("S9", "1", "S9(01)V9(4)"), 4);
            /*"    05  W-TIME                        PIC  9(08).*/
            public IntBasis W_TIME { get; set; } = new IntBasis(new PIC("9", "8", "9(08)."));
            /*"    05  W-TIME-EDIT                   PIC  99.99.99.99.*/
            public IntBasis W_TIME_EDIT { get; set; } = new IntBasis(new PIC("9", "8", "99.99.99.99."));
            /*"    05  W-CONTROLE                    PIC  9(06)  VALUE ZEROS.*/
            public IntBasis W_CONTROLE { get; set; } = new IntBasis(new PIC("9", "6", "9(06)"));
            /*"    05  W-PRM-LIQ                     PIC  9(13)V99 VALUE ZEROS.*/
            public DoubleBasis W_PRM_LIQ { get; set; } = new DoubleBasis(new PIC("9", "13", "9(13)V99"), 2);
            /*"    05  W-QTD-DESPREZ                 PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_DESPREZ { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-PROCESS                 PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_PROCESS { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
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
            /*"    05  W-QTD-LD-TIPO-8               PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_TIPO_8 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-TOT-GERADO-STA              PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_TOT_GERADO_STA { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-COD-COBERTURA               PIC 9(004)  VALUE ZEROS.*/
            public IntBasis W_COD_COBERTURA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"    05  FILLER REDEFINES W-COD-COBERTURA.*/
            private _REDEF_PF0705B_FILLER_0 _filler_0 { get; set; }
            public _REDEF_PF0705B_FILLER_0 FILLER_0
            {
                get { _filler_0 = new _REDEF_PF0705B_FILLER_0(); _.Move(W_COD_COBERTURA, _filler_0); VarBasis.RedefinePassValue(W_COD_COBERTURA, _filler_0, W_COD_COBERTURA); _filler_0.ValueChanged += () => { _.Move(_filler_0, W_COD_COBERTURA); }; return _filler_0; }
                set { VarBasis.RedefinePassValue(value, _filler_0, W_COD_COBERTURA); }
            }  //Redefines
            public class _REDEF_PF0705B_FILLER_0 : VarBasis
            {
                /*"        10  W-SUBPRODUTO              PIC 9(003).*/
                public IntBasis W_SUBPRODUTO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"        10  W-COBERTURA               PIC 9(001).*/
                public IntBasis W_COBERTURA { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    05  W-NSAS                        PIC 9(006).*/

                public _REDEF_PF0705B_FILLER_0()
                {
                    W_SUBPRODUTO.ValueChanged += OnValueChanged;
                    W_COBERTURA.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis W_NSAS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"    05  W-NSL                         PIC 9(008).*/
            public IntBasis W_NSL { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"    05  W-DATA-TRABALHO               PIC 9(008)  VALUE ZEROS.*/
            public IntBasis W_DATA_TRABALHO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05  FILLER REDEFINES W-DATA-TRABALHO.*/
            private _REDEF_PF0705B_FILLER_1 _filler_1 { get; set; }
            public _REDEF_PF0705B_FILLER_1 FILLER_1
            {
                get { _filler_1 = new _REDEF_PF0705B_FILLER_1(); _.Move(W_DATA_TRABALHO, _filler_1); VarBasis.RedefinePassValue(W_DATA_TRABALHO, _filler_1, W_DATA_TRABALHO); _filler_1.ValueChanged += () => { _.Move(_filler_1, W_DATA_TRABALHO); }; return _filler_1; }
                set { VarBasis.RedefinePassValue(value, _filler_1, W_DATA_TRABALHO); }
            }  //Redefines
            public class _REDEF_PF0705B_FILLER_1 : VarBasis
            {
                /*"        07  W-DIA-TRABALHO            PIC 9(002).*/
                public IntBasis W_DIA_TRABALHO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"        07  W-MES-TRABALHO            PIC 9(002).*/
                public IntBasis W_MES_TRABALHO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"        07  W-ANO-TRABALHO            PIC 9(004).*/
                public IntBasis W_ANO_TRABALHO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05  W-DTMOVABE                    PIC X(010).*/

                public _REDEF_PF0705B_FILLER_1()
                {
                    W_DIA_TRABALHO.ValueChanged += OnValueChanged;
                    W_MES_TRABALHO.ValueChanged += OnValueChanged;
                    W_ANO_TRABALHO.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis W_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    05  W-DTMOVABE1 REDEFINES W-DTMOVABE.*/
            private _REDEF_PF0705B_W_DTMOVABE1 _w_dtmovabe1 { get; set; }
            public _REDEF_PF0705B_W_DTMOVABE1 W_DTMOVABE1
            {
                get { _w_dtmovabe1 = new _REDEF_PF0705B_W_DTMOVABE1(); _.Move(W_DTMOVABE, _w_dtmovabe1); VarBasis.RedefinePassValue(W_DTMOVABE, _w_dtmovabe1, W_DTMOVABE); _w_dtmovabe1.ValueChanged += () => { _.Move(_w_dtmovabe1, W_DTMOVABE); }; return _w_dtmovabe1; }
                set { VarBasis.RedefinePassValue(value, _w_dtmovabe1, W_DTMOVABE); }
            }  //Redefines
            public class _REDEF_PF0705B_W_DTMOVABE1 : VarBasis
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

                public _REDEF_PF0705B_W_DTMOVABE1()
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
            private _REDEF_PF0705B_W_DTMOVABE_I1 _w_dtmovabe_i1 { get; set; }
            public _REDEF_PF0705B_W_DTMOVABE_I1 W_DTMOVABE_I1
            {
                get { _w_dtmovabe_i1 = new _REDEF_PF0705B_W_DTMOVABE_I1(); _.Move(W_DTMOVABE_I, _w_dtmovabe_i1); VarBasis.RedefinePassValue(W_DTMOVABE_I, _w_dtmovabe_i1, W_DTMOVABE_I); _w_dtmovabe_i1.ValueChanged += () => { _.Move(_w_dtmovabe_i1, W_DTMOVABE_I); }; return _w_dtmovabe_i1; }
                set { VarBasis.RedefinePassValue(value, _w_dtmovabe_i1, W_DTMOVABE_I); }
            }  //Redefines
            public class _REDEF_PF0705B_W_DTMOVABE_I1 : VarBasis
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

                public _REDEF_PF0705B_W_DTMOVABE_I1()
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
            private _REDEF_PF0705B_W_DATA_SQL1 _w_data_sql1 { get; set; }
            public _REDEF_PF0705B_W_DATA_SQL1 W_DATA_SQL1
            {
                get { _w_data_sql1 = new _REDEF_PF0705B_W_DATA_SQL1(); _.Move(W_DATA_SQL, _w_data_sql1); VarBasis.RedefinePassValue(W_DATA_SQL, _w_data_sql1, W_DATA_SQL); _w_data_sql1.ValueChanged += () => { _.Move(_w_data_sql1, W_DATA_SQL); }; return _w_data_sql1; }
                set { VarBasis.RedefinePassValue(value, _w_data_sql1, W_DATA_SQL); }
            }  //Redefines
            public class _REDEF_PF0705B_W_DATA_SQL1 : VarBasis
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
                /*"    05 W-TEM-COBERPROPVA              PIC 9(001) VALUE ZERO.*/

                public _REDEF_PF0705B_W_DATA_SQL1()
                {
                    W_ANO_SQL.ValueChanged += OnValueChanged;
                    W_BARRA1_1.ValueChanged += OnValueChanged;
                    W_MES_SQL.ValueChanged += OnValueChanged;
                    W_BARRA2_1.ValueChanged += OnValueChanged;
                    W_DIA_SQL.ValueChanged += OnValueChanged;
                }

            }

            public SelectorBasis W_TEM_COBERPROPVA { get; set; } = new SelectorBasis("001", "ZERO")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 NAO-TEM-COBERPROPVA                    VALUE 1. */
							new SelectorItemBasis("NAO_TEM_COBERPROPVA", "1")
                }
            };

            /*"    05 W-TEM-HISTORICO                PIC 9(001) VALUE ZERO.*/

            public SelectorBasis W_TEM_HISTORICO { get; set; } = new SelectorBasis("001", "ZERO")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88     TEM-HISTORICO                      VALUE 1. */
							new SelectorItemBasis("TEM_HISTORICO", "1"),
							/*" 88 NAO-TEM-HISTORICO                      VALUE 2. */
							new SelectorItemBasis("NAO_TEM_HISTORICO", "2")
                }
            };

            /*"    05 W-TEM-TABPROPOVA               PIC 9(001) VALUE ZERO.*/

            public SelectorBasis W_TEM_TABPROPOVA { get; set; } = new SelectorBasis("001", "ZERO")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88     TEM-TABPROPOVA                     VALUE 1. */
							new SelectorItemBasis("TEM_TABPROPOVA", "1"),
							/*" 88 NAO-TEM-TABPROPOVA                     VALUE 2. */
							new SelectorItemBasis("NAO_TEM_TABPROPOVA", "2")
                }
            };

            /*"    05 W-COD-OPERACAO                 PIC S9(04) COMP.*/
            public IntBasis W_COD_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"01  WABEND.*/
        }
        public PF0705B_WABEND WABEND { get; set; } = new PF0705B_WABEND();
        public class PF0705B_WABEND : VarBasis
        {
            /*"  05        FILLER.*/
            public PF0705B_FILLER_2 FILLER_2 { get; set; } = new PF0705B_FILLER_2();
            public class PF0705B_FILLER_2 : VarBasis
            {
                /*"    10      FILLER                   PIC  X(010) VALUE          'PF0705B  '.*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"PF0705B  ");
                /*"    10      FILLER                   PIC  X(028) VALUE          ' *** ERRO  EXEC SQL *** '.*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @" *** ERRO  EXEC SQL *** ");
                /*"    10      FILLER                   PIC  X(014) VALUE          '    SQLCODE = '.*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE = ");
                /*"    10      WSQLCODE                 PIC  ZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
                /*"    10      FILLER                   PIC  X(014)   VALUE          '   SQLERRD1 = '.*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD1 = ");
                /*"    10      WSQLERRD1                PIC  ZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLERRD1 { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
                /*"    10      FILLER                   PIC  X(014)   VALUE          '   SQLERRD2 = '.*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD2 = ");
                /*"    10      WSQLERRD2                PIC  ZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLERRD2 { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
                /*"    10      FILLER                   PIC  X(014)   VALUE          '   SQLERRD2 = '.*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD2 = ");
                /*"  05        LOCALIZA-ABEND-1.*/
            }
            public PF0705B_LOCALIZA_ABEND_1 LOCALIZA_ABEND_1 { get; set; } = new PF0705B_LOCALIZA_ABEND_1();
            public class PF0705B_LOCALIZA_ABEND_1 : VarBasis
            {
                /*"    10      FILLER                   PIC  X(012)   VALUE          'PARAGRAFO = '.*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"PARAGRAFO = ");
                /*"    10      PARAGRAFO                PIC  X(040)   VALUE SPACES.*/
                public StringBasis PARAGRAFO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"  05        LOCALIZA-ABEND-2.*/
            }
            public PF0705B_LOCALIZA_ABEND_2 LOCALIZA_ABEND_2 { get; set; } = new PF0705B_LOCALIZA_ABEND_2();
            public class PF0705B_LOCALIZA_ABEND_2 : VarBasis
            {
                /*"    10      FILLER                   PIC  X(012)   VALUE          'COMANDO   = '.*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"COMANDO   = ");
                /*"    10      COMANDO                  PIC  X(060)   VALUE SPACES.*/
                public StringBasis COMANDO { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"");
            }
        }


        public Copies.LBFCT011 LBFCT011 { get; set; } = new Copies.LBFCT011();
        public Copies.LBFCT016 LBFCT016 { get; set; } = new Copies.LBFCT016();
        public Copies.LBFPF025 LBFPF025 { get; set; } = new Copies.LBFPF025();
        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.HISCONPA HISCONPA { get; set; } = new Dclgens.HISCONPA();
        public Dclgens.PROPOVA PROPOVA { get; set; } = new Dclgens.PROPOVA();
        public Dclgens.RAMOCOMP RAMOCOMP { get; set; } = new Dclgens.RAMOCOMP();
        public Dclgens.APOLICES APOLICES { get; set; } = new Dclgens.APOLICES();
        public Dclgens.COBPRPVA COBPRPVA { get; set; } = new Dclgens.COBPRPVA();
        public Dclgens.PROPOFID PROPOFID { get; set; } = new Dclgens.PROPOFID();
        public Dclgens.PROPFIDH PROPFIDH { get; set; } = new Dclgens.PROPFIDH();
        public Dclgens.ERRPROVI ERRPROVI { get; set; } = new Dclgens.ERRPROVI();
        public Dclgens.ERROVDAZ ERROVDAZ { get; set; } = new Dclgens.ERROVDAZ();
        public Dclgens.ARQSIVPF ARQSIVPF { get; set; } = new Dclgens.ARQSIVPF();
        public PF0705B_PROPOSTA_FIDELIZ PROPOSTA_FIDELIZ { get; set; } = new PF0705B_PROPOSTA_FIDELIZ();
        public PF0705B_PAGAMENTO PAGAMENTO { get; set; } = new PF0705B_PAGAMENTO();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string MOVTO_STA_SASSE_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                MOVTO_STA_SASSE.SetFile(MOVTO_STA_SASSE_FILE_NAME_P);

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
            /*" -373- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -374- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -375- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -378- DISPLAY '************************************************' . */
            _.Display($"************************************************");

            /*" -379- DISPLAY '*               PROGRAMA PF0705B               *' . */
            _.Display($"*               PROGRAMA PF0705B               *");

            /*" -381- DISPLAY '* GERA ARQ STATUS DAS PROP REJEITADAS DE VIDA  *' . */
            _.Display($"* GERA ARQ STATUS DAS PROP REJEITADAS DE VIDA  *");

            /*" -386- DISPLAY '* VERSAO V.16: ' FUNCTION WHEN-COMPILED ' - 402.982 *' . */

            $"* VERSAO V.16: FUNCTION{_.WhenCompiled()} - 402.982 *"
            .Display();

            /*" -387- DISPLAY '************************************************' . */
            _.Display($"************************************************");

            /*" -395- DISPLAY '*  PF0705B - INICIO  EM ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2). */

            $"*  PF0705B - INICIO  EM {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
            .Display();

            /*" -397- DISPLAY ' ' . */
            _.Display($" ");

            /*" -399- PERFORM R0005-00-OBTER-DATA-DIA. */

            R0005_00_OBTER_DATA_DIA_SECTION();

            /*" -401- PERFORM R0010-00-ABRIR-ARQUIVOS. */

            R0010_00_ABRIR_ARQUIVOS_SECTION();

            /*" -403- PERFORM R0015-00-OBTER-MAX-NSAS. */

            R0015_00_OBTER_MAX_NSAS_SECTION();

            /*" -405- PERFORM R0020-00-SELECIONA-MOVTO */

            R0020_00_SELECIONA_MOVTO_SECTION();

            /*" -407- PERFORM R0025-00-LER-MOVTO */

            R0025_00_LER_MOVTO_SECTION();

            /*" -408- IF W-FIM-MOVTO-FIDELIZ EQUAL 'FIM' */

            if (WAREA_AUXILIAR.W_FIM_MOVTO_FIDELIZ == "FIM")
            {

                /*" -409- DISPLAY '*---------------------------------------------*' */
                _.Display($"*---------------------------------------------*");

                /*" -410- DISPLAY '*  PF0705B - FIM NORMAL, NAO HOUVE MOVIMENTO  *' */
                _.Display($"*  PF0705B - FIM NORMAL, NAO HOUVE MOVIMENTO  *");

                /*" -411- DISPLAY '*---------------------------------------------*' */
                _.Display($"*---------------------------------------------*");

                /*" -412- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -414- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


            /*" -416- PERFORM R0030-00-GERAR-HEADER */

            R0030_00_GERAR_HEADER_SECTION();

            /*" -419- PERFORM R0040-00-PROCESSAR-MOVIMENTO UNTIL W-FIM-MOVTO-FIDELIZ EQUAL 'FIM' . */

            while (!(WAREA_AUXILIAR.W_FIM_MOVTO_FIDELIZ == "FIM"))
            {

                R0040_00_PROCESSAR_MOVIMENTO_SECTION();
            }

            /*" -421- PERFORM R0100-00-GERAR-TRAILLER. */

            R0100_00_GERAR_TRAILLER_SECTION();

            /*" -423- PERFORM R0110-00-CONTROLAR-ARQ-ENVIADO */

            R0110_00_CONTROLAR_ARQ_ENVIADO_SECTION();

            /*" -425- PERFORM R0120-00-GERAR-TOTAIS. */

            R0120_00_GERAR_TOTAIS_SECTION();

            /*" -427- PERFORM R9988-00-FECHAR-ARQUIVOS. */

            R9988_00_FECHAR_ARQUIVOS_SECTION();

            /*" -428- DISPLAY ' ' */
            _.Display($" ");

            /*" -437- DISPLAY '*  PF0705B - TERMINO EM ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2). */

            $"*  PF0705B - TERMINO EM {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
            .Display();

            /*" -437- PERFORM R9999-00-FINALIZAR. */

            R9999_00_FINALIZAR_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_SAIDA*/

        [StopWatch]
        /*" R0005-00-OBTER-DATA-DIA-SECTION */
        private void R0005_00_OBTER_DATA_DIA_SECTION()
        {
            /*" -447- MOVE 'R0005-00-OBTER-DATA-DIA' TO PARAGRAFO. */
            _.Move("R0005-00-OBTER-DATA-DIA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -449- MOVE 'SELECT SEGUROS.SISTEMAS' TO COMANDO. */
            _.Move("SELECT SEGUROS.SISTEMAS", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -451- MOVE 'VA' TO SISTEMAS-IDE-SISTEMA OF DCLSISTEMAS. */
            _.Move("VA", SISTEMAS.DCLSISTEMAS.SISTEMAS_IDE_SISTEMA);

            /*" -457- PERFORM R0005_00_OBTER_DATA_DIA_DB_SELECT_1 */

            R0005_00_OBTER_DATA_DIA_DB_SELECT_1();

            /*" -460- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -461- DISPLAY 'PF0705B - FIM ANORMAL' */
                _.Display($"PF0705B - FIM ANORMAL");

                /*" -462- DISPLAY '          ERRO SELECT SISTEMAS' */
                _.Display($"          ERRO SELECT SISTEMAS");

                /*" -464- DISPLAY '          SQLCODE....................... ' SQLCODE */
                _.Display($"          SQLCODE....................... {DB.SQLCODE}");

                /*" -465- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -467- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


            /*" -470- MOVE SISTEMAS-DATA-MOV-ABERTO OF DCLSISTEMAS TO W-DTMOVABE. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, WAREA_AUXILIAR.W_DTMOVABE);

            /*" -472- MOVE W-DIA-MOVABE OF W-DTMOVABE1 TO W-DIA-MOVABE OF W-DTMOVABE-I1. */
            _.Move(WAREA_AUXILIAR.W_DTMOVABE1.W_DIA_MOVABE, WAREA_AUXILIAR.W_DTMOVABE_I1.W_DIA_MOVABE_0);

            /*" -474- MOVE W-MES-MOVABE OF W-DTMOVABE1 TO W-MES-MOVABE OF W-DTMOVABE-I1. */
            _.Move(WAREA_AUXILIAR.W_DTMOVABE1.W_MES_MOVABE, WAREA_AUXILIAR.W_DTMOVABE_I1.W_MES_MOVABE_0);

            /*" -477- MOVE W-ANO-MOVABE OF W-DTMOVABE1 TO W-ANO-MOVABE OF W-DTMOVABE-I1. */
            _.Move(WAREA_AUXILIAR.W_DTMOVABE1.W_ANO_MOVABE, WAREA_AUXILIAR.W_DTMOVABE_I1.W_ANO_MOVABE_0);

            /*" -479- MOVE '-' TO W-BARRA1 OF W-DTMOVABE-I1, W-BARRA2 OF W-DTMOVABE-I1. */
            _.Move("-", WAREA_AUXILIAR.W_DTMOVABE_I1.W_BARRA1_0);
            _.Move("-", WAREA_AUXILIAR.W_DTMOVABE_I1.W_BARRA2_0);


        }

        [StopWatch]
        /*" R0005-00-OBTER-DATA-DIA-DB-SELECT-1 */
        public void R0005_00_OBTER_DATA_DIA_DB_SELECT_1()
        {
            /*" -457- EXEC SQL SELECT DATA_MOV_ABERTO INTO :DCLSISTEMAS.SISTEMAS-DATA-MOV-ABERTO FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = :DCLSISTEMAS.SISTEMAS-IDE-SISTEMA WITH UR END-EXEC. */

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
            /*" -489- MOVE 'R0010-00-ABRIR-ARQUIVOS' TO PARAGRAFO. */
            _.Move("R0010-00-ABRIR-ARQUIVOS", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -491- MOVE 'OPEN' TO COMANDO. */
            _.Move("OPEN", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -491- OPEN OUTPUT MOVTO-STA-SASSE. */
            MOVTO_STA_SASSE.Open(REG_STA_SASSE);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0010_SAIDA*/

        [StopWatch]
        /*" R0015-00-OBTER-MAX-NSAS-SECTION */
        private void R0015_00_OBTER_MAX_NSAS_SECTION()
        {
            /*" -501- MOVE 'R0015-00-OBTER-MAX-NSAS' TO PARAGRAFO. */
            _.Move("R0015-00-OBTER-MAX-NSAS", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -503- MOVE 'SELECT MAX ARQUIVOS-SIVPF' TO COMANDO. */
            _.Move("SELECT MAX ARQUIVOS-SIVPF", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -506- MOVE 'STASASSE' TO ARQSIVPF-SIGLA-ARQUIVO OF DCLARQUIVOS-SIVPF. */
            _.Move("STASASSE", ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SIGLA_ARQUIVO);

            /*" -510- MOVE 4 TO ARQSIVPF-SISTEMA-ORIGEM OF DCLARQUIVOS-SIVPF. */
            _.Move(4, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SISTEMA_ORIGEM);

            /*" -519- PERFORM R0015_00_OBTER_MAX_NSAS_DB_SELECT_1 */

            R0015_00_OBTER_MAX_NSAS_DB_SELECT_1();

            /*" -522- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -523- DISPLAY 'PF0705B - FIM ANORMAL' */
                _.Display($"PF0705B - FIM ANORMAL");

                /*" -524- DISPLAY '          ERRO SELECT MAX ARQUIVOS-SIVPF' */
                _.Display($"          ERRO SELECT MAX ARQUIVOS-SIVPF");

                /*" -526- DISPLAY '          SQLCODE....................... ' SQLCODE */
                _.Display($"          SQLCODE....................... {DB.SQLCODE}");

                /*" -527- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -529- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


            /*" -532- MOVE ARQSIVPF-NSAS-SIVPF OF DCLARQUIVOS-SIVPF TO W-NSAS. */
            _.Move(ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF, WAREA_AUXILIAR.W_NSAS);

            /*" -534- ADD 1 TO W-NSAS. */
            WAREA_AUXILIAR.W_NSAS.Value = WAREA_AUXILIAR.W_NSAS + 1;

            /*" -535- MOVE W-NSAS TO ARQSIVPF-NSAS-SIVPF OF DCLARQUIVOS-SIVPF. */
            _.Move(WAREA_AUXILIAR.W_NSAS, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF);

        }

        [StopWatch]
        /*" R0015-00-OBTER-MAX-NSAS-DB-SELECT-1 */
        public void R0015_00_OBTER_MAX_NSAS_DB_SELECT_1()
        {
            /*" -519- EXEC SQL SELECT VALUE(MAX(NSAS_SIVPF),0) INTO :DCLARQUIVOS-SIVPF.ARQSIVPF-NSAS-SIVPF FROM SEGUROS.ARQUIVOS_SIVPF WHERE SIGLA_ARQUIVO = :DCLARQUIVOS-SIVPF.ARQSIVPF-SIGLA-ARQUIVO AND SISTEMA_ORIGEM = :DCLARQUIVOS-SIVPF.ARQSIVPF-SISTEMA-ORIGEM WITH UR END-EXEC. */

            var r0015_00_OBTER_MAX_NSAS_DB_SELECT_1_Query1 = new R0015_00_OBTER_MAX_NSAS_DB_SELECT_1_Query1()
            {
                ARQSIVPF_SISTEMA_ORIGEM = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SISTEMA_ORIGEM.ToString(),
                ARQSIVPF_SIGLA_ARQUIVO = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SIGLA_ARQUIVO.ToString(),
            };

            var executed_1 = R0015_00_OBTER_MAX_NSAS_DB_SELECT_1_Query1.Execute(r0015_00_OBTER_MAX_NSAS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.ARQSIVPF_NSAS_SIVPF, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0015_SAIDA*/

        [StopWatch]
        /*" R0020-00-SELECIONA-MOVTO-SECTION */
        private void R0020_00_SELECIONA_MOVTO_SECTION()
        {
            /*" -545- MOVE 'R0020-00-SELECIONA-MOVTO' TO PARAGRAFO. */
            _.Move("R0020-00-SELECIONA-MOVTO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -547- MOVE 'DECLARE PROPOSTA-FIDELIZ' TO COMANDO. */
            _.Move("DECLARE PROPOSTA-FIDELIZ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -548- MOVE 1 TO PROPOFID-COD-EMPRESA-SIVPF */
            _.Move(1, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_EMPRESA_SIVPF);

            /*" -549- MOVE 'S' TO PROPOFID-SITUACAO-ENVIO */
            _.Move("S", PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_SITUACAO_ENVIO);

            /*" -550- MOVE 'REJ' TO PROPOFID-SIT-PROPOSTA */
            _.Move("REJ", PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_SIT_PROPOSTA);

            /*" -552- MOVE 'PF0619B' TO PROPOFID-COD-USUARIO. */
            _.Move("PF0619B", PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_USUARIO);

            /*" -604- PERFORM R0020_00_SELECIONA_MOVTO_DB_DECLARE_1 */

            R0020_00_SELECIONA_MOVTO_DB_DECLARE_1();

            /*" -607- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -608- DISPLAY 'PF0705B - FIM ANORMAL' */
                _.Display($"PF0705B - FIM ANORMAL");

                /*" -609- DISPLAY '          ERRO DECLARE PROPOSTA-FIDELIZ' */
                _.Display($"          ERRO DECLARE PROPOSTA-FIDELIZ");

                /*" -611- DISPLAY '          SQLCODE....................... ' SQLCODE */
                _.Display($"          SQLCODE....................... {DB.SQLCODE}");

                /*" -612- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -614- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


            /*" -614- PERFORM R0020_00_SELECIONA_MOVTO_DB_OPEN_1 */

            R0020_00_SELECIONA_MOVTO_DB_OPEN_1();

            /*" -617- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -618- DISPLAY 'PF0705B - FIM ANORMAL' */
                _.Display($"PF0705B - FIM ANORMAL");

                /*" -619- DISPLAY '          ERRO OPEN PROPOSTA-FIDELIZ' */
                _.Display($"          ERRO OPEN PROPOSTA-FIDELIZ");

                /*" -621- DISPLAY '          SQLCODE....................... ' SQLCODE */
                _.Display($"          SQLCODE....................... {DB.SQLCODE}");

                /*" -622- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -622- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R0020-00-SELECIONA-MOVTO-DB-DECLARE-1 */
        public void R0020_00_SELECIONA_MOVTO_DB_DECLARE_1()
        {
            /*" -604- EXEC SQL DECLARE PROPOSTA-FIDELIZ CURSOR FOR SELECT NUM_PROPOSTA_SIVPF, NUM_IDENTIFICACAO, COD_EMPRESA_SIVPF, COD_PESSOA, NUM_SICOB, DATA_PROPOSTA, COD_PRODUTO_SIVPF, AGECOBR, DIA_DEBITO, OPCAOPAG, AGECTADEB, OPRCTADEB, NUMCTADEB, DIGCTADEB, PERC_DESCONTO, NRMATRVEN, AGECTAVEN, OPRCTAVEN, NUMCTAVEN, DIGCTAVEN, CGC_CONVENENTE, NOME_CONVENENTE, NRMATRCON, DTQITBCO, VAL_PAGO, AGEPGTO, VAL_TARIFA, VAL_IOF, DATA_CREDITO, VAL_COMISSAO, SIT_PROPOSTA, COD_USUARIO, CANAL_PROPOSTA, NSAS_SIVPF, ORIGEM_PROPOSTA, NSL, NSAC_SIVPF, SITUACAO_ENVIO FROM SEGUROS.PROPOSTA_FIDELIZ WHERE COD_EMPRESA_SIVPF = :PROPOFID-COD-EMPRESA-SIVPF AND SITUACAO_ENVIO = :PROPOFID-SITUACAO-ENVIO AND SIT_PROPOSTA = :PROPOFID-SIT-PROPOSTA AND COD_USUARIO = :PROPOFID-COD-USUARIO AND COD_PRODUTO_SIVPF NOT IN (48, 7708, 9341, 9350, 9348) WITH UR END-EXEC. */
            PROPOSTA_FIDELIZ = new PF0705B_PROPOSTA_FIDELIZ(true);
            string GetQuery_PROPOSTA_FIDELIZ()
            {
                var query = @$"SELECT NUM_PROPOSTA_SIVPF
							, 
							NUM_IDENTIFICACAO
							, 
							COD_EMPRESA_SIVPF
							, 
							COD_PESSOA
							, 
							NUM_SICOB
							, 
							DATA_PROPOSTA
							, 
							COD_PRODUTO_SIVPF
							, 
							AGECOBR
							, 
							DIA_DEBITO
							, 
							OPCAOPAG
							, 
							AGECTADEB
							, 
							OPRCTADEB
							, 
							NUMCTADEB
							, 
							DIGCTADEB
							, 
							PERC_DESCONTO
							, 
							NRMATRVEN
							, 
							AGECTAVEN
							, 
							OPRCTAVEN
							, 
							NUMCTAVEN
							, 
							DIGCTAVEN
							, 
							CGC_CONVENENTE
							, 
							NOME_CONVENENTE
							, 
							NRMATRCON
							, 
							DTQITBCO
							, 
							VAL_PAGO
							, 
							AGEPGTO
							, 
							VAL_TARIFA
							, 
							VAL_IOF
							, 
							DATA_CREDITO
							, 
							VAL_COMISSAO
							, 
							SIT_PROPOSTA
							, 
							COD_USUARIO
							, 
							CANAL_PROPOSTA
							, 
							NSAS_SIVPF
							, 
							ORIGEM_PROPOSTA
							, 
							NSL
							, 
							NSAC_SIVPF
							, 
							SITUACAO_ENVIO 
							FROM SEGUROS.PROPOSTA_FIDELIZ 
							WHERE COD_EMPRESA_SIVPF = 
							'{PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_EMPRESA_SIVPF}' 
							AND SITUACAO_ENVIO = 
							'{PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_SITUACAO_ENVIO}' 
							AND SIT_PROPOSTA = 
							'{PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_SIT_PROPOSTA}' 
							AND COD_USUARIO = 
							'{PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_USUARIO}' 
							AND COD_PRODUTO_SIVPF NOT IN 
							(48
							, 7708
							, 9341
							, 9350
							, 9348)";

                return query;
            }
            PROPOSTA_FIDELIZ.GetQueryEvent += GetQuery_PROPOSTA_FIDELIZ;

        }

        [StopWatch]
        /*" R0020-00-SELECIONA-MOVTO-DB-OPEN-1 */
        public void R0020_00_SELECIONA_MOVTO_DB_OPEN_1()
        {
            /*" -614- EXEC SQL OPEN PROPOSTA-FIDELIZ END-EXEC. */

            PROPOSTA_FIDELIZ.Open();

        }

        [StopWatch]
        /*" R0090-00-OBTER-PRM-PAGO-DB-DECLARE-1 */
        public void R0090_00_OBTER_PRM_PAGO_DB_DECLARE_1()
        {
            /*" -1611- EXEC SQL DECLARE PAGAMENTO CURSOR FOR SELECT NUM_CERTIFICADO, NUM_PARCELA , NUM_TITULO , OCORR_HISTORICO, NUM_APOLICE , COD_SUBGRUPO , PREMIO_VG , PREMIO_AP , COD_OPERACAO FROM SEGUROS.HIST_CONT_PARCELVA WHERE NUM_CERTIFICADO = :HISCONPA-NUM-CERTIFICADO AND COD_OPERACAO > 199 AND COD_OPERACAO < 300 WITH UR END-EXEC. */
            PAGAMENTO = new PF0705B_PAGAMENTO(true);
            string GetQuery_PAGAMENTO()
            {
                var query = @$"SELECT NUM_CERTIFICADO
							, 
							NUM_PARCELA
							, 
							NUM_TITULO
							, 
							OCORR_HISTORICO
							, 
							NUM_APOLICE
							, 
							COD_SUBGRUPO
							, 
							PREMIO_VG
							, 
							PREMIO_AP
							, 
							COD_OPERACAO 
							FROM SEGUROS.HIST_CONT_PARCELVA 
							WHERE NUM_CERTIFICADO = '{HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_CERTIFICADO}' 
							AND COD_OPERACAO > 199 
							AND COD_OPERACAO < 300";

                return query;
            }
            PAGAMENTO.GetQueryEvent += GetQuery_PAGAMENTO;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0020_SAIDA*/

        [StopWatch]
        /*" R0025-00-LER-MOVTO-SECTION */
        private void R0025_00_LER_MOVTO_SECTION()
        {
            /*" -632- MOVE 'R0025-00-LER-MOVTO' TO PARAGRAFO. */
            _.Move("R0025-00-LER-MOVTO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -634- MOVE 'FETCH PROPOSTA-FIDELIZ' TO COMANDO. */
            _.Move("FETCH PROPOSTA-FIDELIZ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -674- PERFORM R0025_00_LER_MOVTO_DB_FETCH_1 */

            R0025_00_LER_MOVTO_DB_FETCH_1();

            /*" -677- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -678- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -679- MOVE 'FIM' TO W-FIM-MOVTO-FIDELIZ */
                    _.Move("FIM", WAREA_AUXILIAR.W_FIM_MOVTO_FIDELIZ);

                    /*" -679- PERFORM R0025_00_LER_MOVTO_DB_CLOSE_1 */

                    R0025_00_LER_MOVTO_DB_CLOSE_1();

                    /*" -681- ELSE */
                }
                else
                {


                    /*" -682- DISPLAY 'PF0705B - FIM ANORMAL' */
                    _.Display($"PF0705B - FIM ANORMAL");

                    /*" -683- DISPLAY '          ERRO FETCH CURSOR PROPOSTA-FIDELIZ' */
                    _.Display($"          ERRO FETCH CURSOR PROPOSTA-FIDELIZ");

                    /*" -685- DISPLAY '          SQLCODE.......................... ' SQLCODE */
                    _.Display($"          SQLCODE.......................... {DB.SQLCODE}");

                    /*" -686- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -687- PERFORM R9999-00-FINALIZAR */

                    R9999_00_FINALIZAR_SECTION();

                    /*" -688- ELSE */
                }

            }
            else
            {


                /*" -691- ADD 1 TO W-NSL, W-CONTROLE */
                WAREA_AUXILIAR.W_NSL.Value = WAREA_AUXILIAR.W_NSL + 1;
                WAREA_AUXILIAR.W_CONTROLE.Value = WAREA_AUXILIAR.W_CONTROLE + 1;

                /*" -692- IF W-CONTROLE > 1999 */

                if (WAREA_AUXILIAR.W_CONTROLE > 1999)
                {

                    /*" -693- ACCEPT W-TIME FROM TIME */
                    _.Move(_.AcceptDate("TIME"), WAREA_AUXILIAR.W_TIME);

                    /*" -694- MOVE W-TIME TO W-TIME-EDIT */
                    _.Move(WAREA_AUXILIAR.W_TIME, WAREA_AUXILIAR.W_TIME_EDIT);

                    /*" -695- MOVE ZEROS TO W-CONTROLE */
                    _.Move(0, WAREA_AUXILIAR.W_CONTROLE);

                    /*" -697- DISPLAY '** PF0705B ** TOTAL LIDO ..  ' W-NSL ' ' W-TIME-EDIT */

                    $"** PF0705B ** TOTAL LIDO ..  {WAREA_AUXILIAR.W_NSL} {WAREA_AUXILIAR.W_TIME_EDIT}"
                    .Display();

                    /*" -699- END-IF */
                }


                /*" -703- COMPUTE W-TOT-GERADO-STA = W-QTD-LD-TIPO-1 + W-QTD-LD-TIPO-2 + W-QTD-LD-TIPO-3 + W-QTD-LD-TIPO-4 + W-QTD-LD-TIPO-8. */
                WAREA_AUXILIAR.W_TOT_GERADO_STA.Value = WAREA_AUXILIAR.W_QTD_LD_TIPO_1 + WAREA_AUXILIAR.W_QTD_LD_TIPO_2 + WAREA_AUXILIAR.W_QTD_LD_TIPO_3 + WAREA_AUXILIAR.W_QTD_LD_TIPO_4 + WAREA_AUXILIAR.W_QTD_LD_TIPO_8;
            }


        }

        [StopWatch]
        /*" R0025-00-LER-MOVTO-DB-FETCH-1 */
        public void R0025_00_LER_MOVTO_DB_FETCH_1()
        {
            /*" -674- EXEC SQL FETCH PROPOSTA-FIDELIZ INTO :PROPOFID-NUM-PROPOSTA-SIVPF, :PROPOFID-NUM-IDENTIFICACAO, :PROPOFID-COD-EMPRESA-SIVPF, :PROPOFID-COD-PESSOA, :PROPOFID-NUM-SICOB, :PROPOFID-DATA-PROPOSTA, :PROPOFID-COD-PRODUTO-SIVPF, :PROPOFID-AGECOBR, :PROPOFID-DIA-DEBITO, :PROPOFID-OPCAOPAG, :PROPOFID-AGECTADEB, :PROPOFID-OPRCTADEB, :PROPOFID-NUMCTADEB, :PROPOFID-DIGCTADEB, :PROPOFID-PERC-DESCONTO, :PROPOFID-NRMATRVEN, :PROPOFID-AGECTAVEN, :PROPOFID-OPRCTAVEN, :PROPOFID-NUMCTAVEN, :PROPOFID-DIGCTAVEN, :PROPOFID-CGC-CONVENENTE, :PROPOFID-NOME-CONVENENTE, :PROPOFID-NRMATRCON, :PROPOFID-DTQITBCO, :PROPOFID-VAL-PAGO, :PROPOFID-AGEPGTO, :PROPOFID-VAL-TARIFA, :PROPOFID-VAL-IOF, :PROPOFID-DATA-CREDITO, :PROPOFID-VAL-COMISSAO, :PROPOFID-SIT-PROPOSTA, :PROPOFID-COD-USUARIO, :PROPOFID-CANAL-PROPOSTA, :PROPOFID-NSAS-SIVPF, :PROPOFID-ORIGEM-PROPOSTA, :PROPOFID-NSL, :PROPOFID-NSAC-SIVPF, :PROPOFID-SITUACAO-ENVIO END-EXEC. */

            if (PROPOSTA_FIDELIZ.Fetch())
            {
                _.Move(PROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF);
                _.Move(PROPOSTA_FIDELIZ.PROPOFID_NUM_IDENTIFICACAO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_IDENTIFICACAO);
                _.Move(PROPOSTA_FIDELIZ.PROPOFID_COD_EMPRESA_SIVPF, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_EMPRESA_SIVPF);
                _.Move(PROPOSTA_FIDELIZ.PROPOFID_COD_PESSOA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PESSOA);
                _.Move(PROPOSTA_FIDELIZ.PROPOFID_NUM_SICOB, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_SICOB);
                _.Move(PROPOSTA_FIDELIZ.PROPOFID_DATA_PROPOSTA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_PROPOSTA);
                _.Move(PROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF);
                _.Move(PROPOSTA_FIDELIZ.PROPOFID_AGECOBR, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGECOBR);
                _.Move(PROPOSTA_FIDELIZ.PROPOFID_DIA_DEBITO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DIA_DEBITO);
                _.Move(PROPOSTA_FIDELIZ.PROPOFID_OPCAOPAG, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPCAOPAG);
                _.Move(PROPOSTA_FIDELIZ.PROPOFID_AGECTADEB, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGECTADEB);
                _.Move(PROPOSTA_FIDELIZ.PROPOFID_OPRCTADEB, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPRCTADEB);
                _.Move(PROPOSTA_FIDELIZ.PROPOFID_NUMCTADEB, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUMCTADEB);
                _.Move(PROPOSTA_FIDELIZ.PROPOFID_DIGCTADEB, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DIGCTADEB);
                _.Move(PROPOSTA_FIDELIZ.PROPOFID_PERC_DESCONTO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_PERC_DESCONTO);
                _.Move(PROPOSTA_FIDELIZ.PROPOFID_NRMATRVEN, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NRMATRVEN);
                _.Move(PROPOSTA_FIDELIZ.PROPOFID_AGECTAVEN, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGECTAVEN);
                _.Move(PROPOSTA_FIDELIZ.PROPOFID_OPRCTAVEN, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPRCTAVEN);
                _.Move(PROPOSTA_FIDELIZ.PROPOFID_NUMCTAVEN, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUMCTAVEN);
                _.Move(PROPOSTA_FIDELIZ.PROPOFID_DIGCTAVEN, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DIGCTAVEN);
                _.Move(PROPOSTA_FIDELIZ.PROPOFID_CGC_CONVENENTE, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_CGC_CONVENENTE);
                _.Move(PROPOSTA_FIDELIZ.PROPOFID_NOME_CONVENENTE, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NOME_CONVENENTE);
                _.Move(PROPOSTA_FIDELIZ.PROPOFID_NRMATRCON, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NRMATRCON);
                _.Move(PROPOSTA_FIDELIZ.PROPOFID_DTQITBCO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DTQITBCO);
                _.Move(PROPOSTA_FIDELIZ.PROPOFID_VAL_PAGO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_VAL_PAGO);
                _.Move(PROPOSTA_FIDELIZ.PROPOFID_AGEPGTO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGEPGTO);
                _.Move(PROPOSTA_FIDELIZ.PROPOFID_VAL_TARIFA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_VAL_TARIFA);
                _.Move(PROPOSTA_FIDELIZ.PROPOFID_VAL_IOF, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_VAL_IOF);
                _.Move(PROPOSTA_FIDELIZ.PROPOFID_DATA_CREDITO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_CREDITO);
                _.Move(PROPOSTA_FIDELIZ.PROPOFID_VAL_COMISSAO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_VAL_COMISSAO);
                _.Move(PROPOSTA_FIDELIZ.PROPOFID_SIT_PROPOSTA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_SIT_PROPOSTA);
                _.Move(PROPOSTA_FIDELIZ.PROPOFID_COD_USUARIO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_USUARIO);
                _.Move(PROPOSTA_FIDELIZ.PROPOFID_CANAL_PROPOSTA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_CANAL_PROPOSTA);
                _.Move(PROPOSTA_FIDELIZ.PROPOFID_NSAS_SIVPF, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NSAS_SIVPF);
                _.Move(PROPOSTA_FIDELIZ.PROPOFID_ORIGEM_PROPOSTA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_ORIGEM_PROPOSTA);
                _.Move(PROPOSTA_FIDELIZ.PROPOFID_NSL, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NSL);
                _.Move(PROPOSTA_FIDELIZ.PROPOFID_NSAC_SIVPF, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NSAC_SIVPF);
                _.Move(PROPOSTA_FIDELIZ.PROPOFID_SITUACAO_ENVIO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_SITUACAO_ENVIO);
            }

        }

        [StopWatch]
        /*" R0025-00-LER-MOVTO-DB-CLOSE-1 */
        public void R0025_00_LER_MOVTO_DB_CLOSE_1()
        {
            /*" -679- EXEC SQL CLOSE PROPOSTA-FIDELIZ END-EXEC */

            PROPOSTA_FIDELIZ.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0025_SAIDA*/

        [StopWatch]
        /*" R0030-00-GERAR-HEADER-SECTION */
        private void R0030_00_GERAR_HEADER_SECTION()
        {
            /*" -714- MOVE 'R0030-00-GERAR-HEADER' TO PARAGRAFO. */
            _.Move("R0030-00-GERAR-HEADER", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -716- MOVE 'WRITE REG-HEADER-STA' TO COMANDO. */
            _.Move("WRITE REG-HEADER-STA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -718- MOVE SPACES TO REG-HEADER-STA. */
            _.Move("", LBFCT011.REG_HEADER_STA);

            /*" -721- MOVE 'H' TO RH-TIPO-REG OF REG-HEADER-STA */
            _.Move("H", LBFCT011.REG_HEADER_STA.RH_TIPO_REG);

            /*" -724- MOVE 'STASASSE' TO RH-NOME-EMPRESA OF REG-HEADER-STA */
            _.Move("STASASSE", LBFCT011.REG_HEADER_STA.RH_NOME_EMPRESA);

            /*" -727- MOVE W-DIA-MOVABE OF W-DTMOVABE1 TO W-DIA-TRABALHO */
            _.Move(WAREA_AUXILIAR.W_DTMOVABE1.W_DIA_MOVABE, WAREA_AUXILIAR.FILLER_1.W_DIA_TRABALHO);

            /*" -730- MOVE W-MES-MOVABE OF W-DTMOVABE1 TO W-MES-TRABALHO */
            _.Move(WAREA_AUXILIAR.W_DTMOVABE1.W_MES_MOVABE, WAREA_AUXILIAR.FILLER_1.W_MES_TRABALHO);

            /*" -733- MOVE W-ANO-MOVABE OF W-DTMOVABE1 TO W-ANO-TRABALHO */
            _.Move(WAREA_AUXILIAR.W_DTMOVABE1.W_ANO_MOVABE, WAREA_AUXILIAR.FILLER_1.W_ANO_TRABALHO);

            /*" -736- MOVE W-DATA-TRABALHO TO RH-DATA-GERACAO OF REG-HEADER-STA */
            _.Move(WAREA_AUXILIAR.W_DATA_TRABALHO, LBFCT011.REG_HEADER_STA.RH_DATA_GERACAO);

            /*" -739- MOVE 4 TO RH-SIST-ORIGEM OF REG-HEADER-STA */
            _.Move(4, LBFCT011.REG_HEADER_STA.RH_SIST_ORIGEM);

            /*" -742- MOVE 1 TO RH-SIST-DESTINO OF REG-HEADER-STA */
            _.Move(1, LBFCT011.REG_HEADER_STA.RH_SIST_DESTINO);

            /*" -745- MOVE ARQSIVPF-NSAS-SIVPF OF DCLARQUIVOS-SIVPF TO RH-NSAS OF REG-HEADER-STA */
            _.Move(ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF, LBFCT011.REG_HEADER_STA.RH_NSAS);

            /*" -745- WRITE REG-STA-SASSE FROM REG-HEADER-STA. */
            _.Move(LBFCT011.REG_HEADER_STA.GetMoveValues(), REG_STA_SASSE);

            MOVTO_STA_SASSE.Write(REG_STA_SASSE.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0030_SAIDA*/

        [StopWatch]
        /*" R0040-00-PROCESSAR-MOVIMENTO-SECTION */
        private void R0040_00_PROCESSAR_MOVIMENTO_SECTION()
        {
            /*" -756- MOVE 'R0040-00-PROCESSAR-MOVIMENTO' TO PARAGRAFO. */
            _.Move("R0040-00-PROCESSAR-MOVIMENTO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -758- MOVE SPACES TO COMANDO. */
            _.Move("", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -760- IF PROPOFID-NUM-PROPOSTA-SIVPF NOT LESS 10000000000 AND PROPOFID-NUM-PROPOSTA-SIVPF NOT GREATER 19999999999 */

            if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF >= 10000000000 && PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF <= 19999999999)
            {

                /*" -763- MOVE PROPOFID-NUM-PROPOSTA-SIVPF TO WCERTIFICADO W-NUM-PROPOSTA-ATUAL */
                _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF, W01DIGCERT.WCERTIFICADO, CANAL.W_NUM_PROPOSTA_ATUAL);

                /*" -764- PERFORM R0042-000-ROTINA-DIGITO */

                R0042_000_ROTINA_DIGITO_SECTION();

                /*" -766- MOVE WDIG TO W-DV-PROPOSTA-NOVA */
                _.Move(W01DIGCERT.WDIG, CANAL.W_DV_PROPOSTA_NOVA);

                /*" -767- ELSE */
            }
            else
            {


                /*" -769- MOVE PROPOFID-NUM-PROPOSTA-SIVPF TO W-NUM-PROPOSTA-NOVA */
                _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF, W_NUM_PROPOSTA_NOVA);

                /*" -771- END-IF. */
            }


            /*" -777- MOVE ZEROS TO W-TEM-HISTORICO W-TEM-TABPROPOVA. */
            _.Move(0, WAREA_AUXILIAR.W_TEM_HISTORICO, WAREA_AUXILIAR.W_TEM_TABPROPOVA);

            /*" -778- PERFORM R0043-00-LER-H-PROP-FIDEL */

            R0043_00_LER_H_PROP_FIDEL_SECTION();

            /*" -780- IF TEM-HISTORICO */

            if (WAREA_AUXILIAR.W_TEM_HISTORICO["TEM_HISTORICO"])
            {

                /*" -781- ADD 1 TO W-QTD-DESPREZ */
                WAREA_AUXILIAR.W_QTD_DESPREZ.Value = WAREA_AUXILIAR.W_QTD_DESPREZ + 1;

                /*" -782- PERFORM R0046-00-ALTERA-PROPFIDEL */

                R0046_00_ALTERA_PROPFIDEL_SECTION();

                /*" -788- GO TO R0040-10-LER. */

                R0040_10_LER(); //GOTO
                return;
            }


            /*" -789- PERFORM R0045-00-ACESSAR-PROPOSTAVA. */

            R0045_00_ACESSAR_PROPOSTAVA_SECTION();

            /*" -790- IF TEM-TABPROPOVA */

            if (WAREA_AUXILIAR.W_TEM_TABPROPOVA["TEM_TABPROPOVA"])
            {

                /*" -791- CONTINUE */

                /*" -792- ELSE */
            }
            else
            {


                /*" -793- ADD 1 TO W-QTD-DESPREZ */
                WAREA_AUXILIAR.W_QTD_DESPREZ.Value = WAREA_AUXILIAR.W_QTD_DESPREZ + 1;

                /*" -795- GO TO R0040-10-LER. */

                R0040_10_LER(); //GOTO
                return;
            }


            /*" -797- PERFORM R0050-00-GERA-H-PROP-FIDEL. */

            R0050_00_GERA_H_PROP_FIDEL_SECTION();

            /*" -799- PERFORM R0055-00-GERAR-REGISTRO-TP1. */

            R0055_00_GERAR_REGISTRO_TP1_SECTION();

            /*" -801- PERFORM R0060-00-ACESSA-COBERPROPVA. */

            R0060_00_ACESSA_COBERPROPVA_SECTION();

            /*" -803- IF NAO-TEM-COBERPROPVA NEXT SENTENCE */

            if (WAREA_AUXILIAR.W_TEM_COBERPROPVA["NAO_TEM_COBERPROPVA"])
            {

                /*" -804- ELSE */
            }
            else
            {


                /*" -805- MOVE PROPOFID-COD-PRODUTO-SIVPF TO W-SUBPRODUTO */
                _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF, WAREA_AUXILIAR.FILLER_0.W_SUBPRODUTO);

                /*" -806- PERFORM R0065-00-CALL-VG0710S */

                R0065_00_CALL_VG0710S_SECTION();

                /*" -807- PERFORM R0070-00-ACESSA-APOLICE */

                R0070_00_ACESSA_APOLICE_SECTION();

                /*" -808- PERFORM R0075-00-OBTER-PCT-IOF */

                R0075_00_OBTER_PCT_IOF_SECTION();

                /*" -809- PERFORM R0080-00-GERAR-REGISTRO-TP2 */

                R0080_00_GERAR_REGISTRO_TP2_SECTION();

                /*" -811- PERFORM R0085-00-GERAR-REGISTRO-TP3. */

                R0085_00_GERAR_REGISTRO_TP3_SECTION();
            }


            /*" -813- PERFORM R0086-00-GERAR-REGISTRO-TP4. */

            R0086_00_GERAR_REGISTRO_TP4_SECTION();

            /*" -819- MOVE ZERO TO W-TEM-HISTORICO. */
            _.Move(0, WAREA_AUXILIAR.W_TEM_HISTORICO);

            /*" -820- PERFORM R0044-00-LER-H-PROP-FIDEL */

            R0044_00_LER_H_PROP_FIDEL_SECTION();

            /*" -821- IF NAO-TEM-HISTORICO */

            if (WAREA_AUXILIAR.W_TEM_HISTORICO["NAO_TEM_HISTORICO"])
            {

                /*" -828- GO TO R0040-05. */

                R0040_05(); //GOTO
                return;
            }


            /*" -831- IF PROPOFID-COD-PRODUTO-SIVPF EQUAL 11 AND PROPOFID-CANAL-PROPOSTA EQUAL 5 AND PROPOFID-ORIGEM-PROPOSTA EQUAL 3 */

            if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF == 11 && PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_CANAL_PROPOSTA == 5 && PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_ORIGEM_PROPOSTA == 3)
            {

                /*" -833- GO TO R0040-05. */

                R0040_05(); //GOTO
                return;
            }


            /*" -834- IF PROPOFID-ORIGEM-PROPOSTA NOT EQUAL 12 */

            if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_ORIGEM_PROPOSTA != 12)
            {

                /*" -835- INITIALIZE R8-PONTUACAO-SIDEM */
                _.Initialize(
                    LBFPF025.R8_PONTUACAO_SIDEM
                );

                /*" -836- PERFORM R0090-00-OBTER-PRM-PAGO */

                R0090_00_OBTER_PRM_PAGO_SECTION();

                /*" -836- PERFORM R0100-00-GERAR-REGISTRO-TP8. */

                R0100_00_GERAR_REGISTRO_TP8_SECTION();
            }


            /*" -0- FLUXCONTROL_PERFORM R0040_05 */

            R0040_05();

        }

        [StopWatch]
        /*" R0040-05 */
        private void R0040_05(bool isPerform = false)
        {
            /*" -843- MOVE ARQSIVPF-NSAS-SIVPF OF DCLARQUIVOS-SIVPF TO PROPOFID-NSAC-SIVPF. */
            _.Move(ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NSAC_SIVPF);

            /*" -845- PERFORM R0046-00-ALTERA-PROPFIDEL. */

            R0046_00_ALTERA_PROPFIDEL_SECTION();

            /*" -845- ADD 1 TO W-QTD-PROCESS. */
            WAREA_AUXILIAR.W_QTD_PROCESS.Value = WAREA_AUXILIAR.W_QTD_PROCESS + 1;

        }

        [StopWatch]
        /*" R0040-10-LER */
        private void R0040_10_LER(bool isPerform = false)
        {
            /*" -849- PERFORM R0025-00-LER-MOVTO. */

            R0025_00_LER_MOVTO_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0040_SAIDA*/

        [StopWatch]
        /*" R0042-000-ROTINA-DIGITO-SECTION */
        private void R0042_000_ROTINA_DIGITO_SECTION()
        {
            /*" -860- MOVE '270-000-ROTINA-DIGITO' TO PARAGRAFO. */
            _.Move("270-000-ROTINA-DIGITO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -862- MOVE 'CALL PROM1101' TO COMANDO. */
            _.Move("CALL PROM1101", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -862- CALL 'PROM1101' USING W01DIGCERT. */
            _.Call("PROM1101", W01DIGCERT);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0042_SAIDA*/

        [StopWatch]
        /*" R0043-00-LER-H-PROP-FIDEL-SECTION */
        private void R0043_00_LER_H_PROP_FIDEL_SECTION()
        {
            /*" -872- MOVE 'R0043-LER-H-PROP-FIDEL' TO PARAGRAFO. */
            _.Move("R0043-LER-H-PROP-FIDEL", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -874- MOVE 'SELECT HIST PROP FIDELIZ' TO COMANDO. */
            _.Move("SELECT HIST PROP FIDELIZ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -877- MOVE PROPOFID-NUM-IDENTIFICACAO TO PROPFIDH-NUM-IDENTIFICACAO. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_IDENTIFICACAO, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NUM_IDENTIFICACAO);

            /*" -880- MOVE 'REJ' TO PROPFIDH-SIT-PROPOSTA. */
            _.Move("REJ", PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_PROPOSTA);

            /*" -891- PERFORM R0043_00_LER_H_PROP_FIDEL_DB_SELECT_1 */

            R0043_00_LER_H_PROP_FIDEL_DB_SELECT_1();

            /*" -894- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -895- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -896- MOVE 2 TO W-TEM-HISTORICO */
                    _.Move(2, WAREA_AUXILIAR.W_TEM_HISTORICO);

                    /*" -897- ELSE */
                }
                else
                {


                    /*" -898- DISPLAY 'PF0705B - FIM ANORMAL' */
                    _.Display($"PF0705B - FIM ANORMAL");

                    /*" -899- DISPLAY '          ERRO SELECT HIST-PROP-FIDELIZ' */
                    _.Display($"          ERRO SELECT HIST-PROP-FIDELIZ");

                    /*" -901- DISPLAY '          NUMERO PROPOSTA............  ' PROPOFID-NUM-PROPOSTA-SIVPF */
                    _.Display($"          NUMERO PROPOSTA............  {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}");

                    /*" -903- DISPLAY '          NUMERO IDENTIFICACAO.......  ' PROPOFID-NUM-IDENTIFICACAO */
                    _.Display($"          NUMERO IDENTIFICACAO.......  {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_IDENTIFICACAO}");

                    /*" -905- DISPLAY '          SQLCODE....................  ' SQLCODE */
                    _.Display($"          SQLCODE....................  {DB.SQLCODE}");

                    /*" -906- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -907- PERFORM R9999-00-FINALIZAR */

                    R9999_00_FINALIZAR_SECTION();

                    /*" -908- ELSE */
                }

            }
            else
            {


                /*" -908- MOVE 1 TO W-TEM-HISTORICO. */
                _.Move(1, WAREA_AUXILIAR.W_TEM_HISTORICO);
            }


        }

        [StopWatch]
        /*" R0043-00-LER-H-PROP-FIDEL-DB-SELECT-1 */
        public void R0043_00_LER_H_PROP_FIDEL_DB_SELECT_1()
        {
            /*" -891- EXEC SQL SELECT NSAS_SIVPF , NSL INTO :PROPFIDH-NSAS-SIVPF ,:PROPFIDH-NSL FROM SEGUROS.HIST_PROP_FIDELIZ WHERE NUM_IDENTIFICACAO = :PROPFIDH-NUM-IDENTIFICACAO AND SIT_PROPOSTA = :PROPFIDH-SIT-PROPOSTA WITH UR END-EXEC. */

            var r0043_00_LER_H_PROP_FIDEL_DB_SELECT_1_Query1 = new R0043_00_LER_H_PROP_FIDEL_DB_SELECT_1_Query1()
            {
                PROPFIDH_NUM_IDENTIFICACAO = PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NUM_IDENTIFICACAO.ToString(),
                PROPFIDH_SIT_PROPOSTA = PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_PROPOSTA.ToString(),
            };

            var executed_1 = R0043_00_LER_H_PROP_FIDEL_DB_SELECT_1_Query1.Execute(r0043_00_LER_H_PROP_FIDEL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PROPFIDH_NSAS_SIVPF, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NSAS_SIVPF);
                _.Move(executed_1.PROPFIDH_NSL, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NSL);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0043_SAIDA*/

        [StopWatch]
        /*" R0044-00-LER-H-PROP-FIDEL-SECTION */
        private void R0044_00_LER_H_PROP_FIDEL_SECTION()
        {
            /*" -918- MOVE 'R0044-LER-H-PROP-FIDEL' TO PARAGRAFO. */
            _.Move("R0044-LER-H-PROP-FIDEL", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -920- MOVE 'SELECT HIST PROP FIDELIZ' TO COMANDO. */
            _.Move("SELECT HIST PROP FIDELIZ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -923- MOVE PROPOFID-NUM-IDENTIFICACAO TO PROPFIDH-NUM-IDENTIFICACAO. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_IDENTIFICACAO, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NUM_IDENTIFICACAO);

            /*" -926- MOVE 'ENV' TO PROPFIDH-SIT-PROPOSTA. */
            _.Move("ENV", PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_PROPOSTA);

            /*" -933- PERFORM R0044_00_LER_H_PROP_FIDEL_DB_SELECT_1 */

            R0044_00_LER_H_PROP_FIDEL_DB_SELECT_1();

            /*" -936- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -937- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -938- MOVE 2 TO W-TEM-HISTORICO */
                    _.Move(2, WAREA_AUXILIAR.W_TEM_HISTORICO);

                    /*" -939- ELSE */
                }
                else
                {


                    /*" -940- DISPLAY 'PF0705B - FIM ANORMAL' */
                    _.Display($"PF0705B - FIM ANORMAL");

                    /*" -941- DISPLAY '          ERRO SELECT HIST-PROP-FIDELIZ' */
                    _.Display($"          ERRO SELECT HIST-PROP-FIDELIZ");

                    /*" -943- DISPLAY '          NUMERO PROPOSTA............  ' PROPOFID-NUM-PROPOSTA-SIVPF */
                    _.Display($"          NUMERO PROPOSTA............  {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}");

                    /*" -945- DISPLAY '          NUMERO IDENTIFICACAO.......  ' PROPOFID-NUM-IDENTIFICACAO */
                    _.Display($"          NUMERO IDENTIFICACAO.......  {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_IDENTIFICACAO}");

                    /*" -947- DISPLAY '          SQLCODE....................  ' SQLCODE */
                    _.Display($"          SQLCODE....................  {DB.SQLCODE}");

                    /*" -948- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -949- PERFORM R9999-00-FINALIZAR */

                    R9999_00_FINALIZAR_SECTION();

                    /*" -950- ELSE */
                }

            }
            else
            {


                /*" -950- MOVE 1 TO W-TEM-HISTORICO. */
                _.Move(1, WAREA_AUXILIAR.W_TEM_HISTORICO);
            }


        }

        [StopWatch]
        /*" R0044-00-LER-H-PROP-FIDEL-DB-SELECT-1 */
        public void R0044_00_LER_H_PROP_FIDEL_DB_SELECT_1()
        {
            /*" -933- EXEC SQL SELECT NUM_IDENTIFICACAO INTO :PROPFIDH-NUM-IDENTIFICACAO FROM SEGUROS.HIST_PROP_FIDELIZ WHERE NUM_IDENTIFICACAO = :PROPFIDH-NUM-IDENTIFICACAO AND SIT_PROPOSTA = :PROPFIDH-SIT-PROPOSTA WITH UR END-EXEC. */

            var r0044_00_LER_H_PROP_FIDEL_DB_SELECT_1_Query1 = new R0044_00_LER_H_PROP_FIDEL_DB_SELECT_1_Query1()
            {
                PROPFIDH_NUM_IDENTIFICACAO = PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NUM_IDENTIFICACAO.ToString(),
                PROPFIDH_SIT_PROPOSTA = PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_PROPOSTA.ToString(),
            };

            var executed_1 = R0044_00_LER_H_PROP_FIDEL_DB_SELECT_1_Query1.Execute(r0044_00_LER_H_PROP_FIDEL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PROPFIDH_NUM_IDENTIFICACAO, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NUM_IDENTIFICACAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0044_SAIDA*/

        [StopWatch]
        /*" R0045-00-ACESSAR-PROPOSTAVA-SECTION */
        private void R0045_00_ACESSAR_PROPOSTAVA_SECTION()
        {
            /*" -960- MOVE 'R0045-00-ACESSAR-PROPOSTAVA' TO PARAGRAFO. */
            _.Move("R0045-00-ACESSAR-PROPOSTAVA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -962- MOVE 'SELECT PROPOSTAVA' TO COMANDO. */
            _.Move("SELECT PROPOSTAVA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -965- MOVE PROPOFID-NUM-PROPOSTA-SIVPF TO PROPOVA-NUM-CERTIFICADO. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO);

            /*" -979- PERFORM R0045_00_ACESSAR_PROPOSTAVA_DB_SELECT_1 */

            R0045_00_ACESSAR_PROPOSTAVA_DB_SELECT_1();

            /*" -982- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -983- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -984- MOVE 2 TO W-TEM-TABPROPOVA */
                    _.Move(2, WAREA_AUXILIAR.W_TEM_TABPROPOVA);

                    /*" -986- DISPLAY 'PF0705B  CERTIF NAO EXISTE PROPOVA -> ' PROPOVA-NUM-CERTIFICADO */
                    _.Display($"PF0705B  CERTIF NAO EXISTE PROPOVA -> {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                    /*" -987- ELSE */
                }
                else
                {


                    /*" -988- DISPLAY 'PF0705B - FIM ANORMAL' */
                    _.Display($"PF0705B - FIM ANORMAL");

                    /*" -989- DISPLAY '          ERRO SELECT TABELA PROPOSTAS_VA' */
                    _.Display($"          ERRO SELECT TABELA PROPOSTAS_VA");

                    /*" -991- DISPLAY '          CERTIFICADO...... ' PROPOVA-NUM-CERTIFICADO */
                    _.Display($"          CERTIFICADO...... {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                    /*" -993- DISPLAY '          SQLCODE.......... ' SQLCODE */
                    _.Display($"          SQLCODE.......... {DB.SQLCODE}");

                    /*" -994- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -995- PERFORM R9999-00-FINALIZAR */

                    R9999_00_FINALIZAR_SECTION();

                    /*" -996- ELSE */
                }

            }
            else
            {


                /*" -997- MOVE 1 TO W-TEM-TABPROPOVA */
                _.Move(1, WAREA_AUXILIAR.W_TEM_TABPROPOVA);

                /*" -997- END-IF. */
            }


        }

        [StopWatch]
        /*" R0045-00-ACESSAR-PROPOSTAVA-DB-SELECT-1 */
        public void R0045_00_ACESSAR_PROPOSTAVA_DB_SELECT_1()
        {
            /*" -979- EXEC SQL SELECT NUM_APOLICE, COD_SUBGRUPO, COD_PRODUTO, DATA_MOVIMENTO, IDE_SEXO INTO :PROPOVA-NUM-APOLICE, :PROPOVA-COD-SUBGRUPO, :PROPOVA-COD-PRODUTO, :PROPOVA-DATA-MOVIMENTO, :PROPOVA-IDE-SEXO FROM SEGUROS.PROPOSTAS_VA WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO WITH UR END-EXEC. */

            var r0045_00_ACESSAR_PROPOSTAVA_DB_SELECT_1_Query1 = new R0045_00_ACESSAR_PROPOSTAVA_DB_SELECT_1_Query1()
            {
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = R0045_00_ACESSAR_PROPOSTAVA_DB_SELECT_1_Query1.Execute(r0045_00_ACESSAR_PROPOSTAVA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PROPOVA_NUM_APOLICE, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE);
                _.Move(executed_1.PROPOVA_COD_SUBGRUPO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_SUBGRUPO);
                _.Move(executed_1.PROPOVA_COD_PRODUTO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO);
                _.Move(executed_1.PROPOVA_DATA_MOVIMENTO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DATA_MOVIMENTO);
                _.Move(executed_1.PROPOVA_IDE_SEXO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_IDE_SEXO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0045_SAIDA*/

        [StopWatch]
        /*" R0046-00-ALTERA-PROPFIDEL-SECTION */
        private void R0046_00_ALTERA_PROPFIDEL_SECTION()
        {
            /*" -1015- PERFORM R0046_00_ALTERA_PROPFIDEL_DB_UPDATE_1 */

            R0046_00_ALTERA_PROPFIDEL_DB_UPDATE_1();

            /*" -1018- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1019- DISPLAY 'PF0705B - FIM ANORMAL' */
                _.Display($"PF0705B - FIM ANORMAL");

                /*" -1020- DISPLAY '          ERRO UPDATE TABELA PROPOSTA_FIDELIZ' */
                _.Display($"          ERRO UPDATE TABELA PROPOSTA_FIDELIZ");

                /*" -1022- DISPLAY '          NUMERO PROPOSTA...............  ' PROPOFID-NUM-PROPOSTA-SIVPF */
                _.Display($"          NUMERO PROPOSTA...............  {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}");

                /*" -1024- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -1025- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -1026- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R0046-00-ALTERA-PROPFIDEL-DB-UPDATE-1 */
        public void R0046_00_ALTERA_PROPFIDEL_DB_UPDATE_1()
        {
            /*" -1015- EXEC SQL UPDATE SEGUROS.PROPOSTA_FIDELIZ SET SITUACAO_ENVIO = 'R' ,NSAS_SIVPF = :PROPFIDH-NSAS-SIVPF ,NSL = :PROPFIDH-NSL ,COD_USUARIO = 'PF0705B' ,TIMESTAMP = CURRENT TIMESTAMP WHERE NUM_PROPOSTA_SIVPF = :PROPOFID-NUM-PROPOSTA-SIVPF END-EXEC. */

            var r0046_00_ALTERA_PROPFIDEL_DB_UPDATE_1_Update1 = new R0046_00_ALTERA_PROPFIDEL_DB_UPDATE_1_Update1()
            {
                PROPFIDH_NSAS_SIVPF = PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NSAS_SIVPF.ToString(),
                PROPFIDH_NSL = PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NSL.ToString(),
                PROPOFID_NUM_PROPOSTA_SIVPF = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF.ToString(),
            };

            R0046_00_ALTERA_PROPFIDEL_DB_UPDATE_1_Update1.Execute(r0046_00_ALTERA_PROPFIDEL_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0046_SAIDA*/

        [StopWatch]
        /*" R0050-00-GERA-H-PROP-FIDEL-SECTION */
        private void R0050_00_GERA_H_PROP_FIDEL_SECTION()
        {
            /*" -1036- MOVE 'R0050-00-GERA-H-PROP-FIDEL' TO PARAGRAFO. */
            _.Move("R0050-00-GERA-H-PROP-FIDEL", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1039- MOVE PROPOFID-NUM-IDENTIFICACAO TO PROPFIDH-NUM-IDENTIFICACAO. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_IDENTIFICACAO, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NUM_IDENTIFICACAO);

            /*" -1042- MOVE ARQSIVPF-NSAS-SIVPF OF DCLARQUIVOS-SIVPF TO PROPFIDH-NSAS-SIVPF. */
            _.Move(ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NSAS_SIVPF);

            /*" -1044- ADD 1 TO W-QTD-LD-TIPO-1. */
            WAREA_AUXILIAR.W_QTD_LD_TIPO_1.Value = WAREA_AUXILIAR.W_QTD_LD_TIPO_1 + 1;

            /*" -1045- MOVE W-QTD-LD-TIPO-1 TO PROPFIDH-NSL. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_1, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NSL);

            /*" -1046- MOVE 'REJ' TO PROPFIDH-SIT-PROPOSTA. */
            _.Move("REJ", PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_PROPOSTA);

            /*" -1047- MOVE 'SUS' TO PROPFIDH-SIT-COBRANCA-SIVPF. */
            _.Move("SUS", PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_COBRANCA_SIVPF);

            /*" -1049- MOVE ZEROS TO W-COD-OPERACAO. */
            _.Move(0, WAREA_AUXILIAR.W_COD_OPERACAO);

            /*" -1063- PERFORM R0200-00-LER-ERROS-PROPOSTA */

            R0200_00_LER_ERROS_PROPOSTA_SECTION();

            /*" -1064- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1066- DISPLAY PROPOFID-NUM-PROPOSTA-SIVPF ' - ' 'CERTIFICADO SEM ERRO NA VG_CRITICA_PROPOSTA' */

                $"{PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF} - CERTIFICADO SEM ERRO NA VG_CRITICA_PROPOSTA"
                .Display();

                /*" -1067- MOVE 209 TO W-COD-OPERACAO */
                _.Move(209, WAREA_AUXILIAR.W_COD_OPERACAO);

                /*" -1068- ELSE */
            }
            else
            {


                /*" -1069- PERFORM R0220-00-CONV-ERRO-SIVPF */

                R0220_00_CONV_ERRO_SIVPF_SECTION();

                /*" -1070- IF SQLCODE EQUAL ZEROS */

                if (DB.SQLCODE == 00)
                {

                    /*" -1071- IF ERROVDAZ-COD-ERRO-SIVPF EQUAL ZEROS */

                    if (ERROVDAZ.DCLERROS_VIDAZUL.ERROVDAZ_COD_ERRO_SIVPF == 00)
                    {

                        /*" -1072- MOVE 209 TO W-COD-OPERACAO */
                        _.Move(209, WAREA_AUXILIAR.W_COD_OPERACAO);

                        /*" -1076- DISPLAY PROPOFID-NUM-PROPOSTA-SIVPF ' - ' 'ERRO SEM CORRESPONDENTE SIVPF, ' ERROVDAZ-COD-ERRO '/' ERROVDAZ-COD-ERRO-SIVPF */

                        $"{PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF} - ERRO SEM CORRESPONDENTE SIVPF, {ERROVDAZ.DCLERROS_VIDAZUL.ERROVDAZ_COD_ERRO}/{ERROVDAZ.DCLERROS_VIDAZUL.ERROVDAZ_COD_ERRO_SIVPF}"
                        .Display();

                        /*" -1077- ELSE */
                    }
                    else
                    {


                        /*" -1079- IF ERROVDAZ-COD-ERRO-SIVPF GREATER 999 */

                        if (ERROVDAZ.DCLERROS_VIDAZUL.ERROVDAZ_COD_ERRO_SIVPF > 999)
                        {

                            /*" -1083- DISPLAY PROPOFID-NUM-PROPOSTA-SIVPF ' - ' 'ERRO SIVPF MAIOR QUE 999, ' ERROVDAZ-COD-ERRO '/' ERROVDAZ-COD-ERRO-SIVPF */

                            $"{PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF} - ERRO SIVPF MAIOR QUE 999, {ERROVDAZ.DCLERROS_VIDAZUL.ERROVDAZ_COD_ERRO}/{ERROVDAZ.DCLERROS_VIDAZUL.ERROVDAZ_COD_ERRO_SIVPF}"
                            .Display();

                            /*" -1084- MOVE 209 TO W-COD-OPERACAO */
                            _.Move(209, WAREA_AUXILIAR.W_COD_OPERACAO);

                            /*" -1085- ELSE */
                        }
                        else
                        {


                            /*" -1087- MOVE ERROVDAZ-COD-ERRO-SIVPF TO W-COD-OPERACAO */
                            _.Move(ERROVDAZ.DCLERROS_VIDAZUL.ERROVDAZ_COD_ERRO_SIVPF, WAREA_AUXILIAR.W_COD_OPERACAO);

                            /*" -1088- END-IF */
                        }


                        /*" -1089- END-IF */
                    }


                    /*" -1090- ELSE */
                }
                else
                {


                    /*" -1091- DISPLAY PROPOFID-NUM-PROPOSTA-SIVPF ' - ' */
                    _.Display($"{PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF} - ");

                    /*" -1093- DISPLAY 'ERRO NAO CADASTRADO NA ERROS_VIDAZUL ' W-COD-OPERACAO */
                    _.Display($"ERRO NAO CADASTRADO NA ERROS_VIDAZUL {WAREA_AUXILIAR.W_COD_OPERACAO}");

                    /*" -1094- MOVE 209 TO W-COD-OPERACAO */
                    _.Move(209, WAREA_AUXILIAR.W_COD_OPERACAO);

                    /*" -1095- END-IF */
                }


                /*" -1097- END-IF. */
            }


            /*" -1100- MOVE W-COD-OPERACAO TO PROPFIDH-SIT-MOTIVO-SIVPF. */
            _.Move(WAREA_AUXILIAR.W_COD_OPERACAO, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_MOTIVO_SIVPF);

            /*" -1103- MOVE PROPOVA-DATA-MOVIMENTO TO PROPFIDH-DATA-SITUACAO. */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DATA_MOVIMENTO, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_DATA_SITUACAO);

            /*" -1106- MOVE PROPOFID-COD-EMPRESA-SIVPF OF DCLPROPOSTA-FIDELIZ TO PROPFIDH-COD-EMPRESA-SIVPF. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_EMPRESA_SIVPF, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_COD_EMPRESA_SIVPF);

            /*" -1109- MOVE PROPOFID-COD-PRODUTO-SIVPF OF DCLPROPOSTA-FIDELIZ TO PROPFIDH-COD-PRODUTO-SIVPF. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_COD_PRODUTO_SIVPF);

            /*" -1112- MOVE 'INSERT HIST PROP FIDELIZ' TO COMANDO. */
            _.Move("INSERT HIST PROP FIDELIZ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1123- PERFORM R0050_00_GERA_H_PROP_FIDEL_DB_INSERT_1 */

            R0050_00_GERA_H_PROP_FIDEL_DB_INSERT_1();

            /*" -1126- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -1127- DISPLAY 'PF0705B - FIM ANORMAL' */
                _.Display($"PF0705B - FIM ANORMAL");

                /*" -1128- DISPLAY '          ERRO INSERT TABELA HIST-PROP-FIDELIZ' */
                _.Display($"          ERRO INSERT TABELA HIST-PROP-FIDELIZ");

                /*" -1130- DISPLAY '          NUMERO PROPOSTA...............  ' PROPOFID-NUM-PROPOSTA-SIVPF */
                _.Display($"          NUMERO PROPOSTA...............  {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}");

                /*" -1132- DISPLAY '          NUMERO IDENTIFICACAO..........  ' PROPOFID-NUM-IDENTIFICACAO */
                _.Display($"          NUMERO IDENTIFICACAO..........  {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_IDENTIFICACAO}");

                /*" -1134- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -1135- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -1135- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R0050-00-GERA-H-PROP-FIDEL-DB-INSERT-1 */
        public void R0050_00_GERA_H_PROP_FIDEL_DB_INSERT_1()
        {
            /*" -1123- EXEC SQL INSERT INTO SEGUROS.HIST_PROP_FIDELIZ VALUES (:PROPFIDH-NUM-IDENTIFICACAO , :PROPFIDH-DATA-SITUACAO , :PROPFIDH-NSAS-SIVPF , :PROPFIDH-NSL , :PROPFIDH-SIT-PROPOSTA , :PROPFIDH-SIT-COBRANCA-SIVPF, :PROPFIDH-SIT-MOTIVO-SIVPF , :PROPFIDH-COD-EMPRESA-SIVPF , :PROPFIDH-COD-PRODUTO-SIVPF) END-EXEC. */

            var r0050_00_GERA_H_PROP_FIDEL_DB_INSERT_1_Insert1 = new R0050_00_GERA_H_PROP_FIDEL_DB_INSERT_1_Insert1()
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

            R0050_00_GERA_H_PROP_FIDEL_DB_INSERT_1_Insert1.Execute(r0050_00_GERA_H_PROP_FIDEL_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0050_SAIDA*/

        [StopWatch]
        /*" R0055-00-GERAR-REGISTRO-TP1-SECTION */
        private void R0055_00_GERAR_REGISTRO_TP1_SECTION()
        {
            /*" -1145- MOVE 'R0055-00-GERAR-REGISTRO-TP1' TO PARAGRAFO. */
            _.Move("R0055-00-GERAR-REGISTRO-TP1", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1146- MOVE SPACES TO COMANDO. */
            _.Move("", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1148- MOVE SPACES TO REG-STA-PROPOSTA. */
            _.Move("", LBFCT011.REG_STA_PROPOSTA);

            /*" -1151- MOVE '1' TO R1-TIPO-REG OF REG-STA-PROPOSTA. */
            _.Move("1", LBFCT011.REG_STA_PROPOSTA.R1_TIPO_REG);

            /*" -1154- MOVE W-NUM-PROPOSTA-NOVA TO R1-NUM-PROPOSTA OF REG-STA-PROPOSTA. */
            _.Move(W_NUM_PROPOSTA_NOVA, LBFCT011.REG_STA_PROPOSTA.R1_NUM_PROPOSTA);

            /*" -1157- MOVE PROPFIDH-SIT-PROPOSTA TO R1-SIT-PROPOSTA OF REG-STA-PROPOSTA. */
            _.Move(PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_PROPOSTA, LBFCT011.REG_STA_PROPOSTA.R1_SIT_PROPOSTA);

            /*" -1160- MOVE PROPFIDH-SIT-MOTIVO-SIVPF TO R1-SIT-MOTIVO OF REG-STA-PROPOSTA. */
            _.Move(PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_MOTIVO_SIVPF, LBFCT011.REG_STA_PROPOSTA.R1_SIT_MOTIVO);

            /*" -1163- MOVE PROPFIDH-DATA-SITUACAO TO W-DATA-SQL. */
            _.Move(PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_DATA_SITUACAO, WAREA_AUXILIAR.W_DATA_SQL);

            /*" -1164- MOVE W-DIA-SQL TO W-DIA-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_DIA_SQL, WAREA_AUXILIAR.FILLER_1.W_DIA_TRABALHO);

            /*" -1165- MOVE W-MES-SQL TO W-MES-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_MES_SQL, WAREA_AUXILIAR.FILLER_1.W_MES_TRABALHO);

            /*" -1167- MOVE W-ANO-SQL TO W-ANO-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_ANO_SQL, WAREA_AUXILIAR.FILLER_1.W_ANO_TRABALHO);

            /*" -1170- MOVE W-DATA-TRABALHO TO R1-DATA-SITUACAO OF REG-STA-PROPOSTA. */
            _.Move(WAREA_AUXILIAR.W_DATA_TRABALHO, LBFCT011.REG_STA_PROPOSTA.R1_DATA_SITUACAO);

            /*" -1173- MOVE ARQSIVPF-NSAS-SIVPF OF DCLARQUIVOS-SIVPF TO R1-NSAS OF REG-STA-PROPOSTA. */
            _.Move(ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF, LBFCT011.REG_STA_PROPOSTA.R1_NSAS);

            /*" -1176- MOVE W-QTD-LD-TIPO-1 TO R1-NSL OF REG-STA-PROPOSTA. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_1, LBFCT011.REG_STA_PROPOSTA.R1_NSL);

            /*" -1176- WRITE REG-STA-SASSE FROM REG-STA-PROPOSTA. */
            _.Move(LBFCT011.REG_STA_PROPOSTA.GetMoveValues(), REG_STA_SASSE);

            MOVTO_STA_SASSE.Write(REG_STA_SASSE.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0055_SAIDA*/

        [StopWatch]
        /*" R0060-00-ACESSA-COBERPROPVA-SECTION */
        private void R0060_00_ACESSA_COBERPROPVA_SECTION()
        {
            /*" -1186- MOVE 'R0060-00-ACESSA-COBERPROPVA' TO PARAGRAFO. */
            _.Move("R0060-00-ACESSA-COBERPROPVA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1188- MOVE 'SELECT V0COBERPROPVA' TO COMANDO. */
            _.Move("SELECT V0COBERPROPVA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1191- MOVE PROPOFID-NUM-PROPOSTA-SIVPF TO NUM-CERTIFICADO OF DCLHIS-COBER-PROPOST. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF, COBPRPVA.DCLHIS_COBER_PROPOST.NUM_CERTIFICADO);

            /*" -1223- PERFORM R0060_00_ACESSA_COBERPROPVA_DB_SELECT_1 */

            R0060_00_ACESSA_COBERPROPVA_DB_SELECT_1();

            /*" -1226- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -1227- IF SQLCODE NOT EQUAL 100 */

                if (DB.SQLCODE != 100)
                {

                    /*" -1228- DISPLAY 'PF0705B - FIM ANORMAL' */
                    _.Display($"PF0705B - FIM ANORMAL");

                    /*" -1229- DISPLAY '          ERRO SELECT COBERPROPVA' */
                    _.Display($"          ERRO SELECT COBERPROPVA");

                    /*" -1232- DISPLAY '          NUMERO DO CERTIFICADO............ ' NUM-CERTIFICADO OF DCLHIS-COBER-PROPOST */
                    _.Display($"          NUMERO DO CERTIFICADO............ {COBPRPVA.DCLHIS_COBER_PROPOST.NUM_CERTIFICADO}");

                    /*" -1234- DISPLAY '          SQLCODE.......................... ' SQLCODE */
                    _.Display($"          SQLCODE.......................... {DB.SQLCODE}");

                    /*" -1235- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -1236- PERFORM R9999-00-FINALIZAR */

                    R9999_00_FINALIZAR_SECTION();

                    /*" -1237- ELSE */
                }
                else
                {


                    /*" -1238- MOVE 1 TO W-TEM-COBERPROPVA */
                    _.Move(1, WAREA_AUXILIAR.W_TEM_COBERPROPVA);

                    /*" -1239- END-IF */
                }


                /*" -1240- ELSE */
            }
            else
            {


                /*" -1242- IF IMP-MORNATU OF DCLHIS-COBER-PROPOST EQUAL ZEROS AND IMPMORACID OF DCLHIS-COBER-PROPOST EQUAL ZEROS */

                if (COBPRPVA.DCLHIS_COBER_PROPOST.IMP_MORNATU == 00 && COBPRPVA.DCLHIS_COBER_PROPOST.IMPMORACID == 00)
                {

                    /*" -1243- MOVE 1 TO W-TEM-COBERPROPVA */
                    _.Move(1, WAREA_AUXILIAR.W_TEM_COBERPROPVA);

                    /*" -1244- ELSE */
                }
                else
                {


                    /*" -1245- MOVE 0 TO W-TEM-COBERPROPVA */
                    _.Move(0, WAREA_AUXILIAR.W_TEM_COBERPROPVA);

                    /*" -1246- END-IF */
                }


                /*" -1246- END-IF. */
            }


        }

        [StopWatch]
        /*" R0060-00-ACESSA-COBERPROPVA-DB-SELECT-1 */
        public void R0060_00_ACESSA_COBERPROPVA_DB_SELECT_1()
        {
            /*" -1223- EXEC SQL SELECT NUM_CERTIFICADO, DATA_INIVIGENCIA, DATA_TERVIGENCIA, IMPSEGUR, IMP_MORNATU, IMPMORACID, IMPINVPERM, IMPAMDS, IMPDH, IMPDIT, VLPREMIO, PRMVG, PRMAP INTO :DCLHIS-COBER-PROPOST.NUM-CERTIFICADO, :DCLHIS-COBER-PROPOST.DATA-INIVIGENCIA, :DCLHIS-COBER-PROPOST.DATA-TERVIGENCIA, :DCLHIS-COBER-PROPOST.IMPSEGUR, :DCLHIS-COBER-PROPOST.IMP-MORNATU, :DCLHIS-COBER-PROPOST.IMPMORACID, :DCLHIS-COBER-PROPOST.IMPINVPERM, :DCLHIS-COBER-PROPOST.IMPAMDS, :DCLHIS-COBER-PROPOST.IMPDH, :DCLHIS-COBER-PROPOST.IMPDIT, :DCLHIS-COBER-PROPOST.VLPREMIO, :DCLHIS-COBER-PROPOST.PRMVG, :DCLHIS-COBER-PROPOST.PRMAP FROM SEGUROS.HIS_COBER_PROPOST WHERE NUM_CERTIFICADO = :DCLHIS-COBER-PROPOST.NUM-CERTIFICADO AND COD_OPERACAO BETWEEN 100 AND 199 WITH UR END-EXEC. */

            var r0060_00_ACESSA_COBERPROPVA_DB_SELECT_1_Query1 = new R0060_00_ACESSA_COBERPROPVA_DB_SELECT_1_Query1()
            {
                NUM_CERTIFICADO = COBPRPVA.DCLHIS_COBER_PROPOST.NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = R0060_00_ACESSA_COBERPROPVA_DB_SELECT_1_Query1.Execute(r0060_00_ACESSA_COBERPROPVA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.NUM_CERTIFICADO, COBPRPVA.DCLHIS_COBER_PROPOST.NUM_CERTIFICADO);
                _.Move(executed_1.DATA_INIVIGENCIA, COBPRPVA.DCLHIS_COBER_PROPOST.DATA_INIVIGENCIA);
                _.Move(executed_1.DATA_TERVIGENCIA, COBPRPVA.DCLHIS_COBER_PROPOST.DATA_TERVIGENCIA);
                _.Move(executed_1.IMPSEGUR, COBPRPVA.DCLHIS_COBER_PROPOST.IMPSEGUR);
                _.Move(executed_1.IMP_MORNATU, COBPRPVA.DCLHIS_COBER_PROPOST.IMP_MORNATU);
                _.Move(executed_1.IMPMORACID, COBPRPVA.DCLHIS_COBER_PROPOST.IMPMORACID);
                _.Move(executed_1.IMPINVPERM, COBPRPVA.DCLHIS_COBER_PROPOST.IMPINVPERM);
                _.Move(executed_1.IMPAMDS, COBPRPVA.DCLHIS_COBER_PROPOST.IMPAMDS);
                _.Move(executed_1.IMPDH, COBPRPVA.DCLHIS_COBER_PROPOST.IMPDH);
                _.Move(executed_1.IMPDIT, COBPRPVA.DCLHIS_COBER_PROPOST.IMPDIT);
                _.Move(executed_1.VLPREMIO, COBPRPVA.DCLHIS_COBER_PROPOST.VLPREMIO);
                _.Move(executed_1.PRMVG, COBPRPVA.DCLHIS_COBER_PROPOST.PRMVG);
                _.Move(executed_1.PRMAP, COBPRPVA.DCLHIS_COBER_PROPOST.PRMAP);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0060_SAIDA*/

        [StopWatch]
        /*" R0065-00-CALL-VG0710S-SECTION */
        private void R0065_00_CALL_VG0710S_SECTION()
        {
            /*" -1257- MOVE 'R0065-CALL-VG0710S' TO PARAGRAFO. */
            _.Move("R0065-CALL-VG0710S", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1259- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1262- MOVE PROPOVA-NUM-APOLICE TO LK-APOLICE. */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE, PARAMETROS.LK_APOLICE);

            /*" -1265- MOVE PROPOVA-COD-SUBGRUPO TO LK-SUBGRUPO. */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_SUBGRUPO, PARAMETROS.LK_SUBGRUPO);

            /*" -1287- MOVE ZEROS TO LK-IDADE LK-DATA-NASCIMENTO LK-SALARIO LK-PURO-MORTE-NATURAL LK-PURO-MORTE-ACIDENTAL LK-PURO-INV-PERMANENTE LK-PURO-ASS-MEDICA LK-PURO-DIARIA-HOSPITALAR LK-PURO-DIARIA-INTERNACAO LK-COBT-MORTE-NATURAL LK-COBT-MORTE-ACIDENTAL LK-COBT-INV-PERMANENTE LK-COBT-INV-POR-ACIDENTE LK-COBT-ASS-MEDICA LK-COBT-DIARIA-HOSPITALAR LK-COBT-DIARIA-INTERNACAO LK-PREM-MORTE-NATURAL LK-PREM-ACIDENTES-PESSOAIS LK-PREM-TOTAL LK-RETURN-CODE LK-MENSAGEM. */
            _.Move(0, PARAMETROS.LK_IDADE, PARAMETROS.LK_NASCIMENTO.LK_DATA_NASCIMENTO, PARAMETROS.LK_SALARIO, PARAMETROS.LK_PURO_MORTE_NATURAL, PARAMETROS.LK_PURO_MORTE_ACIDENTAL, PARAMETROS.LK_PURO_INV_PERMANENTE, PARAMETROS.LK_PURO_ASS_MEDICA, PARAMETROS.LK_PURO_DIARIA_HOSPITALAR, PARAMETROS.LK_PURO_DIARIA_INTERNACAO, PARAMETROS.LK_COBT_MORTE_NATURAL, PARAMETROS.LK_COBT_MORTE_ACIDENTAL, PARAMETROS.LK_COBT_INV_PERMANENTE, PARAMETROS.LK_COBT_INV_POR_ACIDENTE, PARAMETROS.LK_COBT_ASS_MEDICA, PARAMETROS.LK_COBT_DIARIA_HOSPITALAR, PARAMETROS.LK_COBT_DIARIA_INTERNACAO, PARAMETROS.LK_PREM_MORTE_NATURAL, PARAMETROS.LK_PREM_ACIDENTES_PESSOAIS, PARAMETROS.LK_PREM_TOTAL, PARAMETROS.LK_RETURN_CODE, PARAMETROS.LK_MENSAGEM);

            /*" -1290- MOVE IMP-MORNATU OF DCLHIS-COBER-PROPOST TO LK-PURO-MORTE-NATURAL */
            _.Move(COBPRPVA.DCLHIS_COBER_PROPOST.IMP_MORNATU, PARAMETROS.LK_PURO_MORTE_NATURAL);

            /*" -1293- MOVE IMPMORACID OF DCLHIS-COBER-PROPOST TO LK-PURO-MORTE-ACIDENTAL */
            _.Move(COBPRPVA.DCLHIS_COBER_PROPOST.IMPMORACID, PARAMETROS.LK_PURO_MORTE_ACIDENTAL);

            /*" -1296- MOVE IMPINVPERM OF DCLHIS-COBER-PROPOST TO LK-PURO-INV-PERMANENTE */
            _.Move(COBPRPVA.DCLHIS_COBER_PROPOST.IMPINVPERM, PARAMETROS.LK_PURO_INV_PERMANENTE);

            /*" -1299- MOVE IMPAMDS OF DCLHIS-COBER-PROPOST TO LK-PURO-ASS-MEDICA */
            _.Move(COBPRPVA.DCLHIS_COBER_PROPOST.IMPAMDS, PARAMETROS.LK_PURO_ASS_MEDICA);

            /*" -1302- MOVE IMPDH OF DCLHIS-COBER-PROPOST TO LK-PURO-DIARIA-HOSPITALAR */
            _.Move(COBPRPVA.DCLHIS_COBER_PROPOST.IMPDH, PARAMETROS.LK_PURO_DIARIA_HOSPITALAR);

            /*" -1305- MOVE IMPDIT OF DCLHIS-COBER-PROPOST TO LK-PURO-DIARIA-INTERNACAO. */
            _.Move(COBPRPVA.DCLHIS_COBER_PROPOST.IMPDIT, PARAMETROS.LK_PURO_DIARIA_INTERNACAO);

            /*" -1307- CALL 'VG0710S' USING PARAMETROS. */
            _.Call("VG0710S", PARAMETROS);

            /*" -1308- IF LK-RETURN-CODE NOT EQUAL ZEROS */

            if (PARAMETROS.LK_RETURN_CODE != 00)
            {

                /*" -1309- DISPLAY 'PF0705B - FIM ANORMAL' */
                _.Display($"PF0705B - FIM ANORMAL");

                /*" -1310- DISPLAY '          ERRO SUBROTINA VG0710S ' */
                _.Display($"          ERRO SUBROTINA VG0710S ");

                /*" -1312- DISPLAY '          MENSAGEM.............. ' LK-MENSAGEM */
                _.Display($"          MENSAGEM.............. {PARAMETROS.LK_MENSAGEM}");

                /*" -1314- DISPLAY '          CERTIFICADO........... ' PROPOFID-NUM-PROPOSTA-SIVPF */
                _.Display($"          CERTIFICADO........... {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}");

                /*" -1316- DISPLAY '          LK-RETURN-CODE........ ' LK-RETURN-CODE */
                _.Display($"          LK-RETURN-CODE........ {PARAMETROS.LK_RETURN_CODE}");

                /*" -1317- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -1317- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0065_SAIDA*/

        [StopWatch]
        /*" R0070-00-ACESSA-APOLICE-SECTION */
        private void R0070_00_ACESSA_APOLICE_SECTION()
        {
            /*" -1327- MOVE 'R0070-ACESSA-APOLICE' TO PARAGRAFO. */
            _.Move("R0070-ACESSA-APOLICE", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1329- MOVE 'SELECT APOLICES' TO COMANDO. */
            _.Move("SELECT APOLICES", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1332- MOVE PROPOVA-NUM-APOLICE TO APOLICES-NUM-APOLICE OF DCLAPOLICES. */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE, APOLICES.DCLAPOLICES.APOLICES_NUM_APOLICE);

            /*" -1338- PERFORM R0070_00_ACESSA_APOLICE_DB_SELECT_1 */

            R0070_00_ACESSA_APOLICE_DB_SELECT_1();

            /*" -1341- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -1342- DISPLAY 'PF0705B - FIM ANORMAL' */
                _.Display($"PF0705B - FIM ANORMAL");

                /*" -1343- DISPLAY '          ERRO SELECT TAB. APOLICE' */
                _.Display($"          ERRO SELECT TAB. APOLICE");

                /*" -1345- DISPLAY '          NUMERO APOLICE........  ' APOLICES-NUM-APOLICE OF DCLAPOLICES */
                _.Display($"          NUMERO APOLICE........  {APOLICES.DCLAPOLICES.APOLICES_NUM_APOLICE}");

                /*" -1347- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -1348- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -1348- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R0070-00-ACESSA-APOLICE-DB-SELECT-1 */
        public void R0070_00_ACESSA_APOLICE_DB_SELECT_1()
        {
            /*" -1338- EXEC SQL SELECT RAMO_EMISSOR INTO :DCLAPOLICES.APOLICES-RAMO-EMISSOR FROM SEGUROS.APOLICES WHERE NUM_APOLICE = :DCLAPOLICES.APOLICES-NUM-APOLICE WITH UR END-EXEC. */

            var r0070_00_ACESSA_APOLICE_DB_SELECT_1_Query1 = new R0070_00_ACESSA_APOLICE_DB_SELECT_1_Query1()
            {
                APOLICES_NUM_APOLICE = APOLICES.DCLAPOLICES.APOLICES_NUM_APOLICE.ToString(),
            };

            var executed_1 = R0070_00_ACESSA_APOLICE_DB_SELECT_1_Query1.Execute(r0070_00_ACESSA_APOLICE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.APOLICES_RAMO_EMISSOR, APOLICES.DCLAPOLICES.APOLICES_RAMO_EMISSOR);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0070_SAIDA*/

        [StopWatch]
        /*" R0075-00-OBTER-PCT-IOF-SECTION */
        private void R0075_00_OBTER_PCT_IOF_SECTION()
        {
            /*" -1358- MOVE 'R0075-OBTER-PCT-IOF' TO PARAGRAFO. */
            _.Move("R0075-OBTER-PCT-IOF", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1360- MOVE 'SELECT RAMO COMPL' TO COMANDO. */
            _.Move("SELECT RAMO COMPL", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1363- MOVE APOLICES-RAMO-EMISSOR OF DCLAPOLICES TO RAMOCOMP-RAMO-EMISSOR OF DCLRAMO-COMPLEMENTAR. */
            _.Move(APOLICES.DCLAPOLICES.APOLICES_RAMO_EMISSOR, RAMOCOMP.DCLRAMO_COMPLEMENTAR.RAMOCOMP_RAMO_EMISSOR);

            /*" -1366- MOVE DATA-INIVIGENCIA OF DCLHIS-COBER-PROPOST TO RAMOCOMP-DATA-INIVIGENCIA OF DCLRAMO-COMPLEMENTAR. */
            _.Move(COBPRPVA.DCLHIS_COBER_PROPOST.DATA_INIVIGENCIA, RAMOCOMP.DCLRAMO_COMPLEMENTAR.RAMOCOMP_DATA_INIVIGENCIA);

            /*" -1377- PERFORM R0075_00_OBTER_PCT_IOF_DB_SELECT_1 */

            R0075_00_OBTER_PCT_IOF_DB_SELECT_1();

            /*" -1380- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -1381- DISPLAY 'PF0705B - FIM ANORMAL' */
                _.Display($"PF0705B - FIM ANORMAL");

                /*" -1382- DISPLAY '          ERRO SELECT RAMO_COMPLEMENTAR' */
                _.Display($"          ERRO SELECT RAMO_COMPLEMENTAR");

                /*" -1385- DISPLAY '          CODIGO DO RAMO........  ' RAMOCOMP-RAMO-EMISSOR OF DCLRAMO-COMPLEMENTAR */
                _.Display($"          CODIGO DO RAMO........  {RAMOCOMP.DCLRAMO_COMPLEMENTAR.RAMOCOMP_RAMO_EMISSOR}");

                /*" -1388- DISPLAY '          DATA INICIO VIGENCIA..  ' RAMOCOMP-DATA-INIVIGENCIA OF DCLRAMO-COMPLEMENTAR */
                _.Display($"          DATA INICIO VIGENCIA..  {RAMOCOMP.DCLRAMO_COMPLEMENTAR.RAMOCOMP_DATA_INIVIGENCIA}");

                /*" -1390- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -1391- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -1393- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


            /*" -1394- COMPUTE W-IND-IOF = (RAMOCOMP-PCT-IOCC-RAMO OF DCLRAMO-COMPLEMENTAR / 100) + 1. */
            WAREA_AUXILIAR.W_IND_IOF.Value = (RAMOCOMP.DCLRAMO_COMPLEMENTAR.RAMOCOMP_PCT_IOCC_RAMO / 100f) + 1;

        }

        [StopWatch]
        /*" R0075-00-OBTER-PCT-IOF-DB-SELECT-1 */
        public void R0075_00_OBTER_PCT_IOF_DB_SELECT_1()
        {
            /*" -1377- EXEC SQL SELECT PCT_IOCC_RAMO INTO :DCLRAMO-COMPLEMENTAR.RAMOCOMP-PCT-IOCC-RAMO FROM SEGUROS.RAMO_COMPLEMENTAR WHERE RAMO_EMISSOR = :DCLRAMO-COMPLEMENTAR.RAMOCOMP-RAMO-EMISSOR AND DATA_INIVIGENCIA <= :DCLRAMO-COMPLEMENTAR.RAMOCOMP-DATA-INIVIGENCIA AND DATA_TERVIGENCIA >= :DCLRAMO-COMPLEMENTAR.RAMOCOMP-DATA-INIVIGENCIA WITH UR END-EXEC. */

            var r0075_00_OBTER_PCT_IOF_DB_SELECT_1_Query1 = new R0075_00_OBTER_PCT_IOF_DB_SELECT_1_Query1()
            {
                RAMOCOMP_DATA_INIVIGENCIA = RAMOCOMP.DCLRAMO_COMPLEMENTAR.RAMOCOMP_DATA_INIVIGENCIA.ToString(),
                RAMOCOMP_RAMO_EMISSOR = RAMOCOMP.DCLRAMO_COMPLEMENTAR.RAMOCOMP_RAMO_EMISSOR.ToString(),
            };

            var executed_1 = R0075_00_OBTER_PCT_IOF_DB_SELECT_1_Query1.Execute(r0075_00_OBTER_PCT_IOF_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.RAMOCOMP_PCT_IOCC_RAMO, RAMOCOMP.DCLRAMO_COMPLEMENTAR.RAMOCOMP_PCT_IOCC_RAMO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0075_SAIDA*/

        [StopWatch]
        /*" R0080-00-GERAR-REGISTRO-TP2-SECTION */
        private void R0080_00_GERAR_REGISTRO_TP2_SECTION()
        {
            /*" -1404- MOVE 'R0080-00-GERAR-REGISTRO-TP2' TO PARAGRAFO. */
            _.Move("R0080-00-GERAR-REGISTRO-TP2", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1406- MOVE 'WRITE REG-APOL-SASSE' TO COMANDO. */
            _.Move("WRITE REG-APOL-SASSE", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1409- MOVE SPACES TO REG-APOL-SASSE. */
            _.Move("", LBFCT016.REG_APOL_SASSE);

            /*" -1412- MOVE '2' TO R2-TIPO-REG OF REG-APOL-SASSE. */
            _.Move("2", LBFCT016.REG_APOL_SASSE.R2_TIPO_REG);

            /*" -1416- MOVE W-NUM-PROPOSTA-NOVA TO R2-NUM-PROPOSTA OF REG-APOL-SASSE, R2-NRCERTIF OF REG-APOL-SASSE. */
            _.Move(W_NUM_PROPOSTA_NOVA, LBFCT016.REG_APOL_SASSE.R2_NUM_PROPOSTA, LBFCT016.REG_APOL_SASSE.R2_NRCERTIF);

            /*" -1419- MOVE DATA-INIVIGENCIA OF DCLHIS-COBER-PROPOST TO W-DATA-SQL. */
            _.Move(COBPRPVA.DCLHIS_COBER_PROPOST.DATA_INIVIGENCIA, WAREA_AUXILIAR.W_DATA_SQL);

            /*" -1422- MOVE W-DIA-SQL OF W-DATA-SQL1 TO W-DIA-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_DIA_SQL, WAREA_AUXILIAR.FILLER_1.W_DIA_TRABALHO);

            /*" -1425- MOVE W-MES-SQL OF W-DATA-SQL1 TO W-MES-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_MES_SQL, WAREA_AUXILIAR.FILLER_1.W_MES_TRABALHO);

            /*" -1428- MOVE W-ANO-SQL OF W-DATA-SQL1 TO W-ANO-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_ANO_SQL, WAREA_AUXILIAR.FILLER_1.W_ANO_TRABALHO);

            /*" -1431- MOVE W-DATA-TRABALHO TO R2-DTINIVIG OF REG-APOL-SASSE. */
            _.Move(WAREA_AUXILIAR.W_DATA_TRABALHO, LBFCT016.REG_APOL_SASSE.R2_DTINIVIG);

            /*" -1434- MOVE DATA-TERVIGENCIA OF DCLHIS-COBER-PROPOST TO W-DATA-SQL. */
            _.Move(COBPRPVA.DCLHIS_COBER_PROPOST.DATA_TERVIGENCIA, WAREA_AUXILIAR.W_DATA_SQL);

            /*" -1437- MOVE W-DIA-SQL OF W-DATA-SQL1 TO W-DIA-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_DIA_SQL, WAREA_AUXILIAR.FILLER_1.W_DIA_TRABALHO);

            /*" -1440- MOVE W-MES-SQL OF W-DATA-SQL1 TO W-MES-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_MES_SQL, WAREA_AUXILIAR.FILLER_1.W_MES_TRABALHO);

            /*" -1443- MOVE W-ANO-SQL OF W-DATA-SQL1 TO W-ANO-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_ANO_SQL, WAREA_AUXILIAR.FILLER_1.W_ANO_TRABALHO);

            /*" -1446- MOVE W-DATA-TRABALHO TO R2-DTTERVIG OF REG-APOL-SASSE. */
            _.Move(WAREA_AUXILIAR.W_DATA_TRABALHO, LBFCT016.REG_APOL_SASSE.R2_DTTERVIG);

            /*" -1449- MOVE VLPREMIO OF DCLHIS-COBER-PROPOST TO R2-VAL-PREMIO OF REG-APOL-SASSE. */
            _.Move(COBPRPVA.DCLHIS_COBER_PROPOST.VLPREMIO, LBFCT016.REG_APOL_SASSE.R2_VAL_PREMIO);

            /*" -1453- COMPUTE W-PRM-LIQ = R2-VAL-PREMIO OF REG-APOL-SASSE / W-IND-IOF. */
            WAREA_AUXILIAR.W_PRM_LIQ.Value = LBFCT016.REG_APOL_SASSE.R2_VAL_PREMIO / WAREA_AUXILIAR.W_IND_IOF;

            /*" -1457- COMPUTE R2-VAL-IOF OF REG-APOL-SASSE = R2-VAL-PREMIO OF REG-APOL-SASSE - W-PRM-LIQ. */
            LBFCT016.REG_APOL_SASSE.R2_VAL_IOF.Value = LBFCT016.REG_APOL_SASSE.R2_VAL_PREMIO - WAREA_AUXILIAR.W_PRM_LIQ;

            /*" -1459- WRITE REG-STA-SASSE FROM REG-APOL-SASSE. */
            _.Move(LBFCT016.REG_APOL_SASSE.GetMoveValues(), REG_STA_SASSE);

            MOVTO_STA_SASSE.Write(REG_STA_SASSE.GetMoveValues().ToString());

            /*" -1459- ADD 1 TO W-QTD-LD-TIPO-2. */
            WAREA_AUXILIAR.W_QTD_LD_TIPO_2.Value = WAREA_AUXILIAR.W_QTD_LD_TIPO_2 + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0080_SAIDA*/

        [StopWatch]
        /*" R0085-00-GERAR-REGISTRO-TP3-SECTION */
        private void R0085_00_GERAR_REGISTRO_TP3_SECTION()
        {
            /*" -1469- MOVE 'R0085-00-GERAR-REGISTRO-TP3' TO PARAGRAFO. */
            _.Move("R0085-00-GERAR-REGISTRO-TP3", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1471- MOVE 'WRITE REG-COBER-SASSE' TO COMANDO. */
            _.Move("WRITE REG-COBER-SASSE", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1474- MOVE SPACES TO REG-COBER-SASSE. */
            _.Move("", LBFCT016.REG_COBER_SASSE);

            /*" -1477- MOVE '3' TO R3-TIPO-REG OF REG-COBER-SASSE. */
            _.Move("3", LBFCT016.REG_COBER_SASSE.R3_TIPO_REG);

            /*" -1480- MOVE W-NUM-PROPOSTA-NOVA TO R3-NUM-PROPOSTA OF REG-COBER-SASSE. */
            _.Move(W_NUM_PROPOSTA_NOVA, LBFCT016.REG_COBER_SASSE.R3_NUM_PROPOSTA);

            /*" -1481- IF IMP-MORNATU OF DCLHIS-COBER-PROPOST GREATER ZEROS */

            if (COBPRPVA.DCLHIS_COBER_PROPOST.IMP_MORNATU > 00)
            {

                /*" -1483- MOVE IMP-MORNATU OF DCLHIS-COBER-PROPOST TO R3-VAL-COBERTURA OF REG-COBER-SASSE */
                _.Move(COBPRPVA.DCLHIS_COBER_PROPOST.IMP_MORNATU, LBFCT016.REG_COBER_SASSE.R3_VAL_COBERTURA);

                /*" -1485- MOVE 1 TO W-COBERTURA */
                _.Move(1, WAREA_AUXILIAR.FILLER_0.W_COBERTURA);

                /*" -1487- MOVE W-COD-COBERTURA TO R3-COD-COBERTURA OF REG-COBER-SASSE */
                _.Move(WAREA_AUXILIAR.W_COD_COBERTURA, LBFCT016.REG_COBER_SASSE.R3_COD_COBERTURA);

                /*" -1488- ADD 1 TO W-QTD-LD-TIPO-3 */
                WAREA_AUXILIAR.W_QTD_LD_TIPO_3.Value = WAREA_AUXILIAR.W_QTD_LD_TIPO_3 + 1;

                /*" -1490- WRITE REG-STA-SASSE FROM REG-COBER-SASSE. */
                _.Move(LBFCT016.REG_COBER_SASSE.GetMoveValues(), REG_STA_SASSE);

                MOVTO_STA_SASSE.Write(REG_STA_SASSE.GetMoveValues().ToString());
            }


            /*" -1491- IF IMPMORACID OF DCLHIS-COBER-PROPOST GREATER ZEROS */

            if (COBPRPVA.DCLHIS_COBER_PROPOST.IMPMORACID > 00)
            {

                /*" -1493- MOVE IMPMORACID OF DCLHIS-COBER-PROPOST TO R3-VAL-COBERTURA OF REG-COBER-SASSE */
                _.Move(COBPRPVA.DCLHIS_COBER_PROPOST.IMPMORACID, LBFCT016.REG_COBER_SASSE.R3_VAL_COBERTURA);

                /*" -1495- MOVE 2 TO W-COBERTURA */
                _.Move(2, WAREA_AUXILIAR.FILLER_0.W_COBERTURA);

                /*" -1497- MOVE W-COD-COBERTURA TO R3-COD-COBERTURA OF REG-COBER-SASSE */
                _.Move(WAREA_AUXILIAR.W_COD_COBERTURA, LBFCT016.REG_COBER_SASSE.R3_COD_COBERTURA);

                /*" -1498- ADD 1 TO W-QTD-LD-TIPO-3 */
                WAREA_AUXILIAR.W_QTD_LD_TIPO_3.Value = WAREA_AUXILIAR.W_QTD_LD_TIPO_3 + 1;

                /*" -1500- WRITE REG-STA-SASSE FROM REG-COBER-SASSE. */
                _.Move(LBFCT016.REG_COBER_SASSE.GetMoveValues(), REG_STA_SASSE);

                MOVTO_STA_SASSE.Write(REG_STA_SASSE.GetMoveValues().ToString());
            }


            /*" -1501- IF IMPINVPERM OF DCLHIS-COBER-PROPOST GREATER ZEROS */

            if (COBPRPVA.DCLHIS_COBER_PROPOST.IMPINVPERM > 00)
            {

                /*" -1503- MOVE IMPINVPERM OF DCLHIS-COBER-PROPOST TO R3-VAL-COBERTURA OF REG-COBER-SASSE */
                _.Move(COBPRPVA.DCLHIS_COBER_PROPOST.IMPINVPERM, LBFCT016.REG_COBER_SASSE.R3_VAL_COBERTURA);

                /*" -1505- MOVE 3 TO W-COBERTURA */
                _.Move(3, WAREA_AUXILIAR.FILLER_0.W_COBERTURA);

                /*" -1507- MOVE W-COD-COBERTURA TO R3-COD-COBERTURA OF REG-COBER-SASSE */
                _.Move(WAREA_AUXILIAR.W_COD_COBERTURA, LBFCT016.REG_COBER_SASSE.R3_COD_COBERTURA);

                /*" -1508- ADD 1 TO W-QTD-LD-TIPO-3 */
                WAREA_AUXILIAR.W_QTD_LD_TIPO_3.Value = WAREA_AUXILIAR.W_QTD_LD_TIPO_3 + 1;

                /*" -1510- WRITE REG-STA-SASSE FROM REG-COBER-SASSE. */
                _.Move(LBFCT016.REG_COBER_SASSE.GetMoveValues(), REG_STA_SASSE);

                MOVTO_STA_SASSE.Write(REG_STA_SASSE.GetMoveValues().ToString());
            }


            /*" -1511- IF LK-COBT-INV-POR-ACIDENTE GREATER ZEROS */

            if (PARAMETROS.LK_COBT_INV_POR_ACIDENTE > 00)
            {

                /*" -1513- MOVE LK-COBT-INV-POR-ACIDENTE TO R3-VAL-COBERTURA OF REG-COBER-SASSE */
                _.Move(PARAMETROS.LK_COBT_INV_POR_ACIDENTE, LBFCT016.REG_COBER_SASSE.R3_VAL_COBERTURA);

                /*" -1515- MOVE 4 TO W-COBERTURA */
                _.Move(4, WAREA_AUXILIAR.FILLER_0.W_COBERTURA);

                /*" -1517- MOVE W-COD-COBERTURA TO R3-COD-COBERTURA OF REG-COBER-SASSE */
                _.Move(WAREA_AUXILIAR.W_COD_COBERTURA, LBFCT016.REG_COBER_SASSE.R3_COD_COBERTURA);

                /*" -1518- ADD 1 TO W-QTD-LD-TIPO-3 */
                WAREA_AUXILIAR.W_QTD_LD_TIPO_3.Value = WAREA_AUXILIAR.W_QTD_LD_TIPO_3 + 1;

                /*" -1522- WRITE REG-STA-SASSE FROM REG-COBER-SASSE. */
                _.Move(LBFCT016.REG_COBER_SASSE.GetMoveValues(), REG_STA_SASSE);

                MOVTO_STA_SASSE.Write(REG_STA_SASSE.GetMoveValues().ToString());
            }


            /*" -1523- IF PROPOVA-COD-PRODUTO EQUAL 9707 */

            if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO == 9707)
            {

                /*" -1524- IF PROPOVA-IDE-SEXO EQUAL 'M' */

                if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_IDE_SEXO == "M")
                {

                    /*" -1526- IF IMP-MORNATU OF DCLHIS-COBER-PROPOST GREATER ZEROS */

                    if (COBPRPVA.DCLHIS_COBER_PROPOST.IMP_MORNATU > 00)
                    {

                        /*" -1528- COMPUTE R3-VAL-COBERTURA OF REG-COBER-SASSE = IMP-MORNATU OF DCLHIS-COBER-PROPOST / 2 */
                        LBFCT016.REG_COBER_SASSE.R3_VAL_COBERTURA.Value = COBPRPVA.DCLHIS_COBER_PROPOST.IMP_MORNATU / 2f;

                        /*" -1529- MOVE 5 TO W-COBERTURA */
                        _.Move(5, WAREA_AUXILIAR.FILLER_0.W_COBERTURA);

                        /*" -1531- MOVE W-COD-COBERTURA TO R3-COD-COBERTURA OF REG-COBER-SASSE */
                        _.Move(WAREA_AUXILIAR.W_COD_COBERTURA, LBFCT016.REG_COBER_SASSE.R3_COD_COBERTURA);

                        /*" -1532- ADD 1 TO W-QTD-LD-TIPO-3 */
                        WAREA_AUXILIAR.W_QTD_LD_TIPO_3.Value = WAREA_AUXILIAR.W_QTD_LD_TIPO_3 + 1;

                        /*" -1536- WRITE REG-STA-SASSE FROM REG-COBER-SASSE. */
                        _.Move(LBFCT016.REG_COBER_SASSE.GetMoveValues(), REG_STA_SASSE);

                        MOVTO_STA_SASSE.Write(REG_STA_SASSE.GetMoveValues().ToString());
                    }

                }

            }


            /*" -1537- IF PROPOVA-COD-PRODUTO EQUAL 9705 */

            if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO == 9705)
            {

                /*" -1539- IF IMP-MORNATU OF DCLHIS-COBER-PROPOST GREATER ZEROS */

                if (COBPRPVA.DCLHIS_COBER_PROPOST.IMP_MORNATU > 00)
                {

                    /*" -1541- COMPUTE R3-VAL-COBERTURA OF REG-COBER-SASSE = IMP-MORNATU OF DCLHIS-COBER-PROPOST / 2 */
                    LBFCT016.REG_COBER_SASSE.R3_VAL_COBERTURA.Value = COBPRPVA.DCLHIS_COBER_PROPOST.IMP_MORNATU / 2f;

                    /*" -1542- MOVE 5 TO W-COBERTURA */
                    _.Move(5, WAREA_AUXILIAR.FILLER_0.W_COBERTURA);

                    /*" -1544- MOVE W-COD-COBERTURA TO R3-COD-COBERTURA OF REG-COBER-SASSE */
                    _.Move(WAREA_AUXILIAR.W_COD_COBERTURA, LBFCT016.REG_COBER_SASSE.R3_COD_COBERTURA);

                    /*" -1545- ADD 1 TO W-QTD-LD-TIPO-3 */
                    WAREA_AUXILIAR.W_QTD_LD_TIPO_3.Value = WAREA_AUXILIAR.W_QTD_LD_TIPO_3 + 1;

                    /*" -1545- WRITE REG-STA-SASSE FROM REG-COBER-SASSE. */
                    _.Move(LBFCT016.REG_COBER_SASSE.GetMoveValues(), REG_STA_SASSE);

                    MOVTO_STA_SASSE.Write(REG_STA_SASSE.GetMoveValues().ToString());
                }

            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0085_SAIDA*/

        [StopWatch]
        /*" R0086-00-GERAR-REGISTRO-TP4-SECTION */
        private void R0086_00_GERAR_REGISTRO_TP4_SECTION()
        {
            /*" -1555- MOVE 'R0086-00-GERAR-REGISTRO-TP4' TO PARAGRAFO. */
            _.Move("R0086-00-GERAR-REGISTRO-TP4", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1557- MOVE 'WRITE REG-PGTO-SASSE' TO COMANDO. */
            _.Move("WRITE REG-PGTO-SASSE", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1559- MOVE SPACES TO REG-PGTO-SASSE. */
            _.Move("", LBFCT016.REG_PGTO_SASSE);

            /*" -1561- MOVE '4' TO R4-TIPO-REG. */
            _.Move("4", LBFCT016.REG_PGTO_SASSE.R4_TIPO_REG);

            /*" -1564- MOVE W-NUM-PROPOSTA-NOVA TO R4-NUM-PROPOSTA. */
            _.Move(W_NUM_PROPOSTA_NOVA, LBFCT016.REG_PGTO_SASSE.R4_NUM_PROPOSTA);

            /*" -1567- MOVE PROPFIDH-SIT-COBRANCA-SIVPF TO R4-SIT-COBRANCA. */
            _.Move(PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_COBRANCA_SIVPF, LBFCT016.REG_PGTO_SASSE.R4_SIT_COBRANCA);

            /*" -1570- MOVE PROPFIDH-DATA-SITUACAO TO W-DATA-SQL. */
            _.Move(PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_DATA_SITUACAO, WAREA_AUXILIAR.W_DATA_SQL);

            /*" -1571- MOVE W-DIA-SQL TO W-DIA-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_DIA_SQL, WAREA_AUXILIAR.FILLER_1.W_DIA_TRABALHO);

            /*" -1572- MOVE W-MES-SQL TO W-MES-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_MES_SQL, WAREA_AUXILIAR.FILLER_1.W_MES_TRABALHO);

            /*" -1574- MOVE W-ANO-SQL TO W-ANO-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_ANO_SQL, WAREA_AUXILIAR.FILLER_1.W_ANO_TRABALHO);

            /*" -1577- MOVE W-DATA-TRABALHO TO R4-DATA-SITUACAO OF REG-PGTO-SASSE. */
            _.Move(WAREA_AUXILIAR.W_DATA_TRABALHO, LBFCT016.REG_PGTO_SASSE.R4_DATA_SITUACAO);

            /*" -1580- MOVE ZEROS TO R4-PARCELAS-PAGAS R4-TOTAL-PARCELAS. */
            _.Move(0, LBFCT016.REG_PGTO_SASSE.R4_PARCELAS_PAGAS, LBFCT016.REG_PGTO_SASSE.R4_TOTAL_PARCELAS);

            /*" -1581- WRITE REG-STA-SASSE FROM REG-PGTO-SASSE. */
            _.Move(LBFCT016.REG_PGTO_SASSE.GetMoveValues(), REG_STA_SASSE);

            MOVTO_STA_SASSE.Write(REG_STA_SASSE.GetMoveValues().ToString());

            /*" -1581- ADD 1 TO W-QTD-LD-TIPO-4. */
            WAREA_AUXILIAR.W_QTD_LD_TIPO_4.Value = WAREA_AUXILIAR.W_QTD_LD_TIPO_4 + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0086_SAIDA*/

        [StopWatch]
        /*" R0090-00-OBTER-PRM-PAGO-SECTION */
        private void R0090_00_OBTER_PRM_PAGO_SECTION()
        {
            /*" -1591- MOVE 'R0090-00-OBTER-PRM-PAGO' TO PARAGRAFO. */
            _.Move("R0090-00-OBTER-PRM-PAGO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1593- MOVE 'DECLARE CURSOR' TO COMANDO. */
            _.Move("DECLARE CURSOR", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1595- MOVE W-NUM-PROPOSTA-NOVA TO HISCONPA-NUM-CERTIFICADO */
            _.Move(W_NUM_PROPOSTA_NOVA, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_CERTIFICADO);

            /*" -1611- PERFORM R0090_00_OBTER_PRM_PAGO_DB_DECLARE_1 */

            R0090_00_OBTER_PRM_PAGO_DB_DECLARE_1();

            /*" -1615- MOVE 'OPEN' TO COMANDO. */
            _.Move("OPEN", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1615- PERFORM R0090_00_OBTER_PRM_PAGO_DB_OPEN_1 */

            R0090_00_OBTER_PRM_PAGO_DB_OPEN_1();

            /*" -1618- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -1619- DISPLAY 'PF0705B - FIM ANORMAL' */
                _.Display($"PF0705B - FIM ANORMAL");

                /*" -1620- DISPLAY '          ERRO OPEN CURSOR PAGAMENTO' */
                _.Display($"          ERRO OPEN CURSOR PAGAMENTO");

                /*" -1622- DISPLAY '          SQLCODE.................. ' SQLCODE */
                _.Display($"          SQLCODE.................. {DB.SQLCODE}");

                /*" -1624- DISPLAY '          PROPOSTA................. ' HISCONPA-NUM-CERTIFICADO */
                _.Display($"          PROPOSTA................. {HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_CERTIFICADO}");

                /*" -1625- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -1627- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


            /*" -1629- MOVE 'FETCH' TO COMANDO. */
            _.Move("FETCH", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1640- PERFORM R0090_00_OBTER_PRM_PAGO_DB_FETCH_1 */

            R0090_00_OBTER_PRM_PAGO_DB_FETCH_1();

            /*" -1643- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -1644- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1646- MOVE VLPREMIO OF DCLHIS-COBER-PROPOST TO R8-VLR-LANCAMENTO */
                    _.Move(COBPRPVA.DCLHIS_COBER_PROPOST.VLPREMIO, LBFPF025.R8_PONTUACAO_SIDEM.R8_VLR_LANCAMENTO);

                    /*" -1647- ELSE */
                }
                else
                {


                    /*" -1648- DISPLAY 'PF0705B - FIM ANORMAL' */
                    _.Display($"PF0705B - FIM ANORMAL");

                    /*" -1649- DISPLAY '          ERRO FETCH CURSOR PAGAMENTO' */
                    _.Display($"          ERRO FETCH CURSOR PAGAMENTO");

                    /*" -1651- DISPLAY '          SQLCODE................... ' SQLCODE */
                    _.Display($"          SQLCODE................... {DB.SQLCODE}");

                    /*" -1653- DISPLAY '          PROPOSTA.................. ' HISCONPA-NUM-CERTIFICADO */
                    _.Display($"          PROPOSTA.................. {HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_CERTIFICADO}");

                    /*" -1654- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -1655- PERFORM R9999-00-FINALIZAR */

                    R9999_00_FINALIZAR_SECTION();

                    /*" -1656- ELSE */
                }

            }
            else
            {


                /*" -1659- COMPUTE R8-VLR-LANCAMENTO = HISCONPA-PREMIO-VG + HISCONPA-PREMIO-AP. */
                LBFPF025.R8_PONTUACAO_SIDEM.R8_VLR_LANCAMENTO.Value = HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_PREMIO_VG + HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_PREMIO_AP;
            }


            /*" -1661- MOVE 'CLOSE' TO COMANDO. */
            _.Move("CLOSE", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1661- PERFORM R0090_00_OBTER_PRM_PAGO_DB_CLOSE_1 */

            R0090_00_OBTER_PRM_PAGO_DB_CLOSE_1();

            /*" -1664- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -1665- DISPLAY 'PF0705B - FIM ANORMAL' */
                _.Display($"PF0705B - FIM ANORMAL");

                /*" -1666- DISPLAY '          ERRO CLOSE CURSOR PAGAMENTO' */
                _.Display($"          ERRO CLOSE CURSOR PAGAMENTO");

                /*" -1668- DISPLAY '          SQLCODE................... ' SQLCODE */
                _.Display($"          SQLCODE................... {DB.SQLCODE}");

                /*" -1670- DISPLAY '          PROPOSTA.................. ' HISCONPA-NUM-CERTIFICADO */
                _.Display($"          PROPOSTA.................. {HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_CERTIFICADO}");

                /*" -1671- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -1671- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R0090-00-OBTER-PRM-PAGO-DB-OPEN-1 */
        public void R0090_00_OBTER_PRM_PAGO_DB_OPEN_1()
        {
            /*" -1615- EXEC SQL OPEN PAGAMENTO END-EXEC. */

            PAGAMENTO.Open();

        }

        [StopWatch]
        /*" R0090-00-OBTER-PRM-PAGO-DB-FETCH-1 */
        public void R0090_00_OBTER_PRM_PAGO_DB_FETCH_1()
        {
            /*" -1640- EXEC SQL FETCH PAGAMENTO INTO :HISCONPA-NUM-CERTIFICADO, :HISCONPA-NUM-PARCELA , :HISCONPA-NUM-TITULO , :HISCONPA-OCORR-HISTORICO, :HISCONPA-NUM-APOLICE , :HISCONPA-COD-SUBGRUPO , :HISCONPA-PREMIO-VG , :HISCONPA-PREMIO-AP , :HISCONPA-COD-OPERACAO END-EXEC. */

            if (PAGAMENTO.Fetch())
            {
                _.Move(PAGAMENTO.HISCONPA_NUM_CERTIFICADO, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_CERTIFICADO);
                _.Move(PAGAMENTO.HISCONPA_NUM_PARCELA, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_PARCELA);
                _.Move(PAGAMENTO.HISCONPA_NUM_TITULO, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_TITULO);
                _.Move(PAGAMENTO.HISCONPA_OCORR_HISTORICO, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_OCORR_HISTORICO);
                _.Move(PAGAMENTO.HISCONPA_NUM_APOLICE, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_APOLICE);
                _.Move(PAGAMENTO.HISCONPA_COD_SUBGRUPO, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_COD_SUBGRUPO);
                _.Move(PAGAMENTO.HISCONPA_PREMIO_VG, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_PREMIO_VG);
                _.Move(PAGAMENTO.HISCONPA_PREMIO_AP, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_PREMIO_AP);
                _.Move(PAGAMENTO.HISCONPA_COD_OPERACAO, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_COD_OPERACAO);
            }

        }

        [StopWatch]
        /*" R0090-00-OBTER-PRM-PAGO-DB-CLOSE-1 */
        public void R0090_00_OBTER_PRM_PAGO_DB_CLOSE_1()
        {
            /*" -1661- EXEC SQL CLOSE PAGAMENTO END-EXEC. */

            PAGAMENTO.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0090_SAIDA*/

        [StopWatch]
        /*" R0100-00-GERAR-REGISTRO-TP8-SECTION */
        private void R0100_00_GERAR_REGISTRO_TP8_SECTION()
        {
            /*" -1681- MOVE 'R0100-00-GERAR-REGISTRO-TP8' TO PARAGRAFO. */
            _.Move("R0100-00-GERAR-REGISTRO-TP8", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1683- MOVE 'WRITE REGISTRO SIDEM' TO COMANDO. */
            _.Move("WRITE REGISTRO SIDEM", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1685- MOVE 8 TO R8-IDENTIFICACAO */
            _.Move(8, LBFPF025.R8_PONTUACAO_SIDEM.R8_IDENTIFICACAO);

            /*" -1687- MOVE W-NUM-PROPOSTA-NOVA TO R8-NUM-PROPOSTA. */
            _.Move(W_NUM_PROPOSTA_NOVA, LBFPF025.R8_PONTUACAO_SIDEM.R8_NUM_PROPOSTA);

            /*" -1692- MOVE ZEROS TO R8-NUM-PARCELA, R8-VLR-ESTOQUE. */
            _.Move(0, LBFPF025.R8_PONTUACAO_SIDEM.R8_NUM_PARCELA, LBFPF025.R8_PONTUACAO_SIDEM.R8_VLR_ESTOQUE);

            /*" -1694- WRITE REG-STA-SASSE FROM R8-PONTUACAO-SIDEM. */
            _.Move(LBFPF025.R8_PONTUACAO_SIDEM.GetMoveValues(), REG_STA_SASSE);

            MOVTO_STA_SASSE.Write(REG_STA_SASSE.GetMoveValues().ToString());

            /*" -1694- ADD 1 TO W-QTD-LD-TIPO-8. */
            WAREA_AUXILIAR.W_QTD_LD_TIPO_8.Value = WAREA_AUXILIAR.W_QTD_LD_TIPO_8 + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_00_SAIDA*/

        [StopWatch]
        /*" R0100-00-GERAR-TRAILLER-SECTION */
        private void R0100_00_GERAR_TRAILLER_SECTION()
        {
            /*" -1704- MOVE 'R0100-00-GERAR-TRAILLER' TO PARAGRAFO. */
            _.Move("R0100-00-GERAR-TRAILLER", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1706- MOVE SPACES TO COMANDO. */
            _.Move("", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1708- MOVE SPACES TO REG-TRAILLER-STA. */
            _.Move("", LBFCT011.REG_TRAILLER_STA);

            /*" -1711- MOVE 'T' TO RT-TIPO-REG OF REG-TRAILLER-STA */
            _.Move("T", LBFCT011.REG_TRAILLER_STA.RT_TIPO_REG);

            /*" -1714- MOVE 'STASASSE' TO RT-NOME-EMPRESA OF REG-TRAILLER-STA */
            _.Move("STASASSE", LBFCT011.REG_TRAILLER_STA.RT_NOME_EMPRESA);

            /*" -1717- MOVE W-QTD-LD-TIPO-1 TO RT-QTDE-TIPO-1 OF REG-TRAILLER-STA */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_1, LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_1);

            /*" -1720- MOVE W-QTD-LD-TIPO-2 TO RT-QTDE-TIPO-2 OF REG-TRAILLER-STA */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_2, LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_2);

            /*" -1723- MOVE W-QTD-LD-TIPO-3 TO RT-QTDE-TIPO-3 OF REG-TRAILLER-STA */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_3, LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_3);

            /*" -1726- MOVE W-QTD-LD-TIPO-4 TO RT-QTDE-TIPO-4 OF REG-TRAILLER-STA */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_4, LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_4);

            /*" -1729- MOVE ZEROS TO RT-QTDE-TIPO-5 OF REG-TRAILLER-STA */
            _.Move(0, LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_5);

            /*" -1732- MOVE ZEROS TO RT-QTDE-TIPO-6 OF REG-TRAILLER-STA */
            _.Move(0, LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_6);

            /*" -1735- MOVE ZEROS TO RT-QTDE-TIPO-7 OF REG-TRAILLER-STA */
            _.Move(0, LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_7);

            /*" -1738- MOVE W-QTD-LD-TIPO-8 TO RT-QTDE-TIPO-8 OF REG-TRAILLER-STA */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_8, LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_8);

            /*" -1741- MOVE ZEROS TO RT-QTDE-TIPO-9 OF REG-TRAILLER-STA */
            _.Move(0, LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_9);

            /*" -1752- COMPUTE RT-QTDE-TOTAL OF REG-TRAILLER-STA = RT-QTDE-TIPO-1 + RT-QTDE-TIPO-2 + RT-QTDE-TIPO-3 + RT-QTDE-TIPO-4 + RT-QTDE-TIPO-5 + RT-QTDE-TIPO-6 + RT-QTDE-TIPO-7 + RT-QTDE-TIPO-8 + RT-QTDE-TIPO-9. */
            LBFCT011.REG_TRAILLER_STA.RT_QTDE_TOTAL.Value = LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_1 + LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_2 + LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_3 + LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_4 + LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_5 + LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_6 + LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_7 + LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_8 + LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_9;

            /*" -1752- WRITE REG-STA-SASSE FROM REG-TRAILLER-STA. */
            _.Move(LBFCT011.REG_TRAILLER_STA.GetMoveValues(), REG_STA_SASSE);

            MOVTO_STA_SASSE.Write(REG_STA_SASSE.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_SAIDA*/

        [StopWatch]
        /*" R0110-00-CONTROLAR-ARQ-ENVIADO-SECTION */
        private void R0110_00_CONTROLAR_ARQ_ENVIADO_SECTION()
        {
            /*" -1762- MOVE 'R0110-00-CONTROLAR-ARQ-ENVIADO' TO PARAGRAFO. */
            _.Move("R0110-00-CONTROLAR-ARQ-ENVIADO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1764- MOVE 'INSERT ARQUIVOS-SIVPF' TO COMANDO. */
            _.Move("INSERT ARQUIVOS-SIVPF", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1767- MOVE 'STASASSE' TO ARQSIVPF-SIGLA-ARQUIVO OF DCLARQUIVOS-SIVPF. */
            _.Move("STASASSE", ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SIGLA_ARQUIVO);

            /*" -1770- MOVE 4 TO ARQSIVPF-SISTEMA-ORIGEM OF DCLARQUIVOS-SIVPF. */
            _.Move(4, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SISTEMA_ORIGEM);

            /*" -1774- MOVE SISTEMAS-DATA-MOV-ABERTO OF DCLSISTEMAS TO ARQSIVPF-DATA-PROCESSAMENTO OF DCLARQUIVOS-SIVPF, ARQSIVPF-DATA-GERACAO OF DCLARQUIVOS-SIVPF. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_PROCESSAMENTO, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_GERACAO);

            /*" -1777- MOVE RT-QTDE-TIPO-1 OF REG-TRAILLER-STA TO ARQSIVPF-QTDE-REG-GER OF DCLARQUIVOS-SIVPF. */
            _.Move(LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_1, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_QTDE_REG_GER);

            /*" -1785- PERFORM R0110_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1 */

            R0110_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1();

            /*" -1788- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -1789- DISPLAY 'PF0705B - FIM ANORMAL' */
                _.Display($"PF0705B - FIM ANORMAL");

                /*" -1790- DISPLAY '          ERRO INSERT TABELA ARQUIVOS-SIVPF' */
                _.Display($"          ERRO INSERT TABELA ARQUIVOS-SIVPF");

                /*" -1793- DISPLAY '          SIGLA DO ARQIVO...............  ' ARQSIVPF-SIGLA-ARQUIVO OF DCLARQUIVOS-SIVPF */
                _.Display($"          SIGLA DO ARQIVO...............  {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SIGLA_ARQUIVO}");

                /*" -1796- DISPLAY '          NSAS SIVPF....................  ' ARQSIVPF-NSAS-SIVPF OF DCLARQUIVOS-SIVPF */
                _.Display($"          NSAS SIVPF....................  {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF}");

                /*" -1799- DISPLAY '          DATA GERACAO..................  ' ARQSIVPF-DATA-GERACAO OF DCLARQUIVOS-SIVPF */
                _.Display($"          DATA GERACAO..................  {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_GERACAO}");

                /*" -1802- DISPLAY '          QTDE. REGISTROS...............  ' ARQSIVPF-QTDE-REG-GER OF DCLARQUIVOS-SIVPF */
                _.Display($"          QTDE. REGISTROS...............  {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_QTDE_REG_GER}");

                /*" -1804- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -1805- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -1805- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R0110-00-CONTROLAR-ARQ-ENVIADO-DB-INSERT-1 */
        public void R0110_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1()
        {
            /*" -1785- EXEC SQL INSERT INTO SEGUROS.ARQUIVOS_SIVPF VALUES (:DCLARQUIVOS-SIVPF.ARQSIVPF-SIGLA-ARQUIVO, :DCLARQUIVOS-SIVPF.ARQSIVPF-SISTEMA-ORIGEM, :DCLARQUIVOS-SIVPF.ARQSIVPF-NSAS-SIVPF, :DCLARQUIVOS-SIVPF.ARQSIVPF-DATA-GERACAO, :DCLARQUIVOS-SIVPF.ARQSIVPF-QTDE-REG-GER, :DCLARQUIVOS-SIVPF.ARQSIVPF-DATA-PROCESSAMENTO) END-EXEC. */

            var r0110_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1_Insert1 = new R0110_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1_Insert1()
            {
                ARQSIVPF_SIGLA_ARQUIVO = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SIGLA_ARQUIVO.ToString(),
                ARQSIVPF_SISTEMA_ORIGEM = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SISTEMA_ORIGEM.ToString(),
                ARQSIVPF_NSAS_SIVPF = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF.ToString(),
                ARQSIVPF_DATA_GERACAO = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_GERACAO.ToString(),
                ARQSIVPF_QTDE_REG_GER = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_QTDE_REG_GER.ToString(),
                ARQSIVPF_DATA_PROCESSAMENTO = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_PROCESSAMENTO.ToString(),
            };

            R0110_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1_Insert1.Execute(r0110_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0110_SAIDA*/

        [StopWatch]
        /*" R0120-00-GERAR-TOTAIS-SECTION */
        private void R0120_00_GERAR_TOTAIS_SECTION()
        {
            /*" -1815- MOVE 'R0120-00-GERAR-TOTIAS' TO PARAGRAFO. */
            _.Move("R0120-00-GERAR-TOTIAS", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1817- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1823- COMPUTE W-TOT-GERADO-STA = W-QTD-LD-TIPO-1 + W-QTD-LD-TIPO-2 + W-QTD-LD-TIPO-3 + W-QTD-LD-TIPO-4 + W-QTD-LD-TIPO-8. */
            WAREA_AUXILIAR.W_TOT_GERADO_STA.Value = WAREA_AUXILIAR.W_QTD_LD_TIPO_1 + WAREA_AUXILIAR.W_QTD_LD_TIPO_2 + WAREA_AUXILIAR.W_QTD_LD_TIPO_3 + WAREA_AUXILIAR.W_QTD_LD_TIPO_4 + WAREA_AUXILIAR.W_QTD_LD_TIPO_8;

            /*" -1824- DISPLAY '          TOTAIS DO PROCESSAMENTO' */
            _.Display($"          TOTAIS DO PROCESSAMENTO");

            /*" -1826- DISPLAY '          TOTAL  REGISTROS LIDOS...... ' W-NSL */
            _.Display($"          TOTAL  REGISTROS LIDOS...... {WAREA_AUXILIAR.W_NSL}");

            /*" -1828- DISPLAY '          TOTAL  REGISTROS PROCESSADOS ' W-QTD-PROCESS */
            _.Display($"          TOTAL  REGISTROS PROCESSADOS {WAREA_AUXILIAR.W_QTD_PROCESS}");

            /*" -1830- DISPLAY '          TOTAL  REGISTROS DESPREZADOS ' W-QTD-DESPREZ */
            _.Display($"          TOTAL  REGISTROS DESPREZADOS {WAREA_AUXILIAR.W_QTD_DESPREZ}");

            /*" -1831- DISPLAY ' ' */
            _.Display($" ");

            /*" -1832- DISPLAY '          TOTAL  GERADO ARQ. STATUS ' */
            _.Display($"          TOTAL  GERADO ARQ. STATUS ");

            /*" -1834- DISPLAY '          TOTAL  REGISTROS TP-1....... ' W-QTD-LD-TIPO-1 */
            _.Display($"          TOTAL  REGISTROS TP-1....... {WAREA_AUXILIAR.W_QTD_LD_TIPO_1}");

            /*" -1836- DISPLAY '          TOTAL  REGISTROS TP-2....... ' W-QTD-LD-TIPO-2 */
            _.Display($"          TOTAL  REGISTROS TP-2....... {WAREA_AUXILIAR.W_QTD_LD_TIPO_2}");

            /*" -1838- DISPLAY '          TOTAL  REGISTROS TP-3....... ' W-QTD-LD-TIPO-3 */
            _.Display($"          TOTAL  REGISTROS TP-3....... {WAREA_AUXILIAR.W_QTD_LD_TIPO_3}");

            /*" -1840- DISPLAY '          TOTAL  REGISTROS TP-4....... ' W-QTD-LD-TIPO-4 */
            _.Display($"          TOTAL  REGISTROS TP-4....... {WAREA_AUXILIAR.W_QTD_LD_TIPO_4}");

            /*" -1842- DISPLAY '          TOTAL  REGISTROS TP-8....... ' W-QTD-LD-TIPO-8 */
            _.Display($"          TOTAL  REGISTROS TP-8....... {WAREA_AUXILIAR.W_QTD_LD_TIPO_8}");

            /*" -1843- DISPLAY '          TOTAL  REGISTROS GERADOS.... ' W-TOT-GERADO-STA. */
            _.Display($"          TOTAL  REGISTROS GERADOS.... {WAREA_AUXILIAR.W_TOT_GERADO_STA}");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0120_SAIDA*/

        [StopWatch]
        /*" R0200-00-LER-ERROS-PROPOSTA-SECTION */
        private void R0200_00_LER_ERROS_PROPOSTA_SECTION()
        {
            /*" -1853- MOVE 'R0200-00-LER-ERROS-PROPOSTA' TO PARAGRAFO. */
            _.Move("R0200-00-LER-ERROS-PROPOSTA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1855- MOVE 'SELECT ERROS_PROP_VIDAZUL' TO COMANDO. */
            _.Move("SELECT ERROS_PROP_VIDAZUL", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1867- MOVE PROPOFID-NUM-PROPOSTA-SIVPF TO ERRPROVI-NUM-CERTIFICADO. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF, ERRPROVI.DCLERROS_PROP_VIDAZUL.ERRPROVI_NUM_CERTIFICADO);

            /*" -1878- PERFORM R0200_00_LER_ERROS_PROPOSTA_DB_SELECT_1 */

            R0200_00_LER_ERROS_PROPOSTA_DB_SELECT_1();

            /*" -1881- IF SQLCODE NOT EQUAL ZEROS AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -1882- DISPLAY 'PF0705B - FIM ANORMAL' */
                _.Display($"PF0705B - FIM ANORMAL");

                /*" -1883- DISPLAY '          ERRO SELECT VG_CRITICA_PROPOSTA' */
                _.Display($"          ERRO SELECT VG_CRITICA_PROPOSTA");

                /*" -1885- DISPLAY '          NUMERO PROPOSTA............  ' PROPOFID-NUM-PROPOSTA-SIVPF */
                _.Display($"          NUMERO PROPOSTA............  {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}");

                /*" -1887- DISPLAY '          SQLCODE....................  ' SQLCODE */
                _.Display($"          SQLCODE....................  {DB.SQLCODE}");

                /*" -1888- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -1889- PERFORM R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION();

                /*" -1895- END-IF. */
            }


            /*" -1896- IF W-COD-OPERACAO EQUAL 1800 */

            if (WAREA_AUXILIAR.W_COD_OPERACAO == 1800)
            {

                /*" -1897- MOVE 1808 TO W-COD-OPERACAO */
                _.Move(1808, WAREA_AUXILIAR.W_COD_OPERACAO);

                /*" -1898- END-IF. */
            }


        }

        [StopWatch]
        /*" R0200-00-LER-ERROS-PROPOSTA-DB-SELECT-1 */
        public void R0200_00_LER_ERROS_PROPOSTA_DB_SELECT_1()
        {
            /*" -1878- EXEC SQL SELECT A.COD_MSG_CRITICA INTO :W-COD-OPERACAO FROM SEGUROS.VG_CRITICA_PROPOSTA A, SEGUROS.VG_DM_MSG_CRITICA B WHERE A.NUM_CERTIFICADO = :ERRPROVI-NUM-CERTIFICADO AND A.STA_CRITICA IN ( '0' , '1' , '2' , '4' , '5' , '8' ) AND A.COD_MSG_CRITICA = B.COD_MSG_CRITICA AND B.COD_TP_MSG_CRITICA <> '3' FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var r0200_00_LER_ERROS_PROPOSTA_DB_SELECT_1_Query1 = new R0200_00_LER_ERROS_PROPOSTA_DB_SELECT_1_Query1()
            {
                ERRPROVI_NUM_CERTIFICADO = ERRPROVI.DCLERROS_PROP_VIDAZUL.ERRPROVI_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = R0200_00_LER_ERROS_PROPOSTA_DB_SELECT_1_Query1.Execute(r0200_00_LER_ERROS_PROPOSTA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.W_COD_OPERACAO, WAREA_AUXILIAR.W_COD_OPERACAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_SAIDA*/

        [StopWatch]
        /*" R0220-00-CONV-ERRO-SIVPF-SECTION */
        private void R0220_00_CONV_ERRO_SIVPF_SECTION()
        {
            /*" -1908- MOVE 'R0220-00-CONV-ERRO-SIVPF' TO PARAGRAFO. */
            _.Move("R0220-00-CONV-ERRO-SIVPF", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1910- MOVE 'SELECT ERROS_VIDAZUL' TO COMANDO. */
            _.Move("SELECT ERROS_VIDAZUL", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1920- MOVE W-COD-OPERACAO TO ERROVDAZ-COD-ERRO */
            _.Move(WAREA_AUXILIAR.W_COD_OPERACAO, ERROVDAZ.DCLERROS_VIDAZUL.ERROVDAZ_COD_ERRO);

            /*" -1926- PERFORM R0220_00_CONV_ERRO_SIVPF_DB_SELECT_1 */

            R0220_00_CONV_ERRO_SIVPF_DB_SELECT_1();

            /*" -1929- IF SQLCODE NOT EQUAL ZEROS AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -1930- DISPLAY 'PF0705B - FIM ANORMAL' */
                _.Display($"PF0705B - FIM ANORMAL");

                /*" -1931- DISPLAY '          ERRO SELECT VG_DM_MSG_CRITICA' */
                _.Display($"          ERRO SELECT VG_DM_MSG_CRITICA");

                /*" -1933- DISPLAY '          COD. ERRO .................  ' ERROVDAZ-COD-ERRO */
                _.Display($"          COD. ERRO .................  {ERROVDAZ.DCLERROS_VIDAZUL.ERROVDAZ_COD_ERRO}");

                /*" -1935- DISPLAY '          SQLCODE....................  ' SQLCODE */
                _.Display($"          SQLCODE....................  {DB.SQLCODE}");

                /*" -1936- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -1937- PERFORM R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION();

                /*" -1938- END-IF. */
            }


        }

        [StopWatch]
        /*" R0220-00-CONV-ERRO-SIVPF-DB-SELECT-1 */
        public void R0220_00_CONV_ERRO_SIVPF_DB_SELECT_1()
        {
            /*" -1926- EXEC SQL SELECT IFNULL(COD_ERRO_SIVPF, 0) INTO :ERROVDAZ-COD-ERRO-SIVPF FROM SEGUROS.VG_DM_MSG_CRITICA WHERE COD_MSG_CRITICA = :ERROVDAZ-COD-ERRO WITH UR END-EXEC. */

            var r0220_00_CONV_ERRO_SIVPF_DB_SELECT_1_Query1 = new R0220_00_CONV_ERRO_SIVPF_DB_SELECT_1_Query1()
            {
                ERROVDAZ_COD_ERRO = ERROVDAZ.DCLERROS_VIDAZUL.ERROVDAZ_COD_ERRO.ToString(),
            };

            var executed_1 = R0220_00_CONV_ERRO_SIVPF_DB_SELECT_1_Query1.Execute(r0220_00_CONV_ERRO_SIVPF_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.ERROVDAZ_COD_ERRO_SIVPF, ERROVDAZ.DCLERROS_VIDAZUL.ERROVDAZ_COD_ERRO_SIVPF);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0220_SAIDA*/

        [StopWatch]
        /*" R9988-00-FECHAR-ARQUIVOS-SECTION */
        private void R9988_00_FECHAR_ARQUIVOS_SECTION()
        {
            /*" -1946- CLOSE MOVTO-STA-SASSE. */
            MOVTO_STA_SASSE.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9988_SAIDA*/

        [StopWatch]
        /*" R9999-00-FINALIZAR-SECTION */
        private void R9999_00_FINALIZAR_SECTION()
        {
            /*" -1957- DISPLAY ' ' */
            _.Display($" ");

            /*" -1958- IF W-FIM-MOVTO-FIDELIZ = 'FIM' */

            if (WAREA_AUXILIAR.W_FIM_MOVTO_FIDELIZ == "FIM")
            {

                /*" -1959- DISPLAY 'PF0705B - FIM NORMAL' */
                _.Display($"PF0705B - FIM NORMAL");

                /*" -1960- MOVE 0 TO RETURN-CODE */
                _.Move(0, RETURN_CODE);

                /*" -1960- EXEC SQL COMMIT WORK END-EXEC */

                DatabaseConnection.Instance.CommitTransaction();

                /*" -1962- ELSE */
            }
            else
            {


                /*" -1963- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, WABEND.FILLER_2.WSQLCODE);

                /*" -1964- MOVE SQLERRD(1) TO WSQLERRD1 */
                _.Move(DB.SQLERRD[1], WABEND.FILLER_2.WSQLERRD1);

                /*" -1965- MOVE SQLERRD(2) TO WSQLERRD2 */
                _.Move(DB.SQLERRD[2], WABEND.FILLER_2.WSQLERRD2);

                /*" -1966- DISPLAY WABEND */
                _.Display(WABEND);

                /*" -1967- DISPLAY '*** PF0705B *** ROLLBACK EM ANDAMENTO ...' */
                _.Display($"*** PF0705B *** ROLLBACK EM ANDAMENTO ...");

                /*" -1968- MOVE 'ROLLBACK WORK' TO COMANDO */
                _.Move("ROLLBACK WORK", WABEND.LOCALIZA_ABEND_2.COMANDO);

                /*" -1968- EXEC SQL ROLLBACK WORK END-EXEC */

                DatabaseConnection.Instance.RollbackTransaction();

                /*" -1971- MOVE 09 TO RETURN-CODE. */
                _.Move(09, RETURN_CODE);
            }


            /*" -1971- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9999_SAIDA*/
    }
}