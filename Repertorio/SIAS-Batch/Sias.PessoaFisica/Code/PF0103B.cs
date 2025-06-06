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
using Sias.PessoaFisica.DB2.PF0103B;

namespace Code
{
    public class PF0103B
    {
        public bool IsCall { get; set; }

        public PF0103B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *-----------------------*                                               */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO ................ LER MOVIMENTO  GERADO  PELO PROGRAMA *      */
        /*"      *                           PF0102B,  PRODUTOS DIRID,  VINDOS DA *      */
        /*"      *                           SULAMERICA E ATUALIZADOS NAS TABELAS *      */
        /*"      *   ANALISE/PROGRAMACAO.... LUIZ CARLOS / REGINALDO              *      */
        /*"      *   PROGRAMA .............. PF0103B                              *      */
        /*"      *   DATA .................. 14/04/2003.                          *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *-------------------   M A N U T E N C O E S   ------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 12             IMPACTO DA INCLUSAO DO CAMPO             *      */
        /*"      *                       IND_TP_CONTA NA TABELA PROPOSTA_FIDELIZ. *      */
        /*"      * ATENDE DEMANDA 175.167                                         *      */
        /*"      *                                                                *      */
        /*"      * PROCURE V.12          MARCUS VALERIO                           *      */
        /*"      *                       27/02/2018                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 11             ABEND  COM  O  ARQUIVO DA SULAMERICA     *      */
        /*"      *                       REGISTRO COM PROBLEMAS DISPLAY R0050.    *      */
        /*"      * ATENDE RDM 3392                                                *      */
        /*"      *                                                                *      */
        /*"      * PROCURE V.11          REGINALDO SILVA                          *      */
        /*"      *                       21/11/2018                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 10             IMPACTO DA INCLUSAO DO CAMPO             *      */
        /*"      * ATENDE CADMUS 140.553 IND_TP_PROPOSTA NA TABELA                *      */
        /*"      *                       PROPOSTA_FIDELIZ.                        *      */
        /*"      * PROCURE V.10          FRANK CARVALHO                           *      */
        /*"      *                       08/08/2016                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 09             ALTERACOES NOS REGISTROS TIPO 3 E TIPO A *      */
        /*"      * ATENDE CADMUS 97713   CAMPOS :  OPERACAO E NUMERO DE CONTA     *      */
        /*"      *                                                                *      */
        /*"      * PROCURE NSGD          REGINALDO SILVA                          *      */
        /*"      *                       13/05/2014                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 08             AJUSTE INSERT HIST_PROP_FIDELIZ          *      */
        /*"      * ATENDE CADMUS 88764   COD-EMPRESA    E   COD-PRODUTO           *      */
        /*"      *                                                                *      */
        /*"      * PROCURE IHP           REGINALDO SILVA                          *      */
        /*"      *                       10/11/2013                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 07             AJUSTE INSERT HIST_PROP_FIDELIZ          *      */
        /*"      * ATENDE CADMUS 84809   DB2.V10  SELECTS                         *      */
        /*"      * PROCURE DB2           REGINALDO DA SILVA                       *      */
        /*"      *                       10/09/2013                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 06    CADMUS 54479                                      *      */
        /*"      *                                                                *      */
        /*"      * COLOCAR CLAUSULA WITH UR NOS COMANDOS DB2 SELECT               *      */
        /*"      * DATA ..... 18/05/2009 - PROCURE POR V.07   - SERGIO LORETO     *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 05    CADMUS 24245                                      *      */
        /*"      *                                                                *      */
        /*"      *   TRATA CODIGO RETORNO -803.                                   *      */
        /*"      *   DATA ..... 18/05/2009 - PROCURE POR V.06   - FAST COMPUTER   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 04                                                    *      */
        /*"      *                                                                *      */
        /*"      *   PASSOU A TRATAR A POSIBILIDADE DE PROCESSAR O MOVIMENTO EM   *      */
        /*"      *   D+1, ASSUMINDO OS DADOS DA CONVERSAO_SICOB.                  *      */
        /*"      *   DATA ..... 05/05/2003 - PROCURE POR V.04                     *      */
        /*"      *                                                                *      */
        /*"      *   ------------------------ // -------------------------        *      */
        /*"      *   VERSAO 03                                                    *      */
        /*"      *                                                                *      */
        /*"      *   PASSOU A GERAR RELATORIO COM AS PROPOSTAS EM DUPLICIDADE.    *      */
        /*"      *   DATA ..... 22/04/2003 - PROCURE POR V.03                     *      */
        /*"      *                                                                *      */
        /*"      *   ------------------------ // -------------------------        *      */
        /*"      *   VERSAO 02                                                    *      */
        /*"      *                                                                *      */
        /*"      *   EM FUNCAO DA ATUALIZACAO DA BASE DO PF, O QUE DEPENDE DA SAI-*      */
        /*"      *   DA DO ON-LINE, ESTE PROGRAMA FOI DESMEMBRADO SENDO CRIADO  O *      */
        /*"      *   PROGRAMA PF0102B, QUE IR  LER O ARQUIVO DE PROPOSTAS SULAME- *      */
        /*"      *   RICA E GERAR O ARQUIVO A SER ENVIADO AO SIGPF. ESTE PROGRAMA *      */
        /*"      *   TEVE AS ROTINAS DE GERACAO DO ARQUIVO DE SAIDA INIBIDO E  NO *      */
        /*"      *   JCL O MESMO FOI REDEFINIDO PARA 'DUMMY'.                     *      */
        /*"      *   DATA ..... 14/04/2003 - PROCURE POR V.02                     *      */
        /*"      *   ------------------------------------------------------------ *      */
        /*"      *   VERSAO 01                                                    *      */
        /*"      *                                                                *      */
        /*"      *   FORAM EXCLUIDOS DO REGISTRO DE CLIENTES, O DD E TELEFONE CE- *      */
        /*"      *   LULAR E INCLUIDOS A 'DATA DE EXPEDICAO DO RG' E O 'CODIGO DO *      */
        /*"      *   SEGMENTO'.                                                   *      */
        /*"      *   DATA ..... 10/04/2003 - PROCURE POR V.01                     *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"1     *--------------------*                                                  */
        #endregion


        #region VARIABLES

        public FileBasis _MOV_SULA { get; set; } = new FileBasis(new PIC("X", "300", "X(300)"));

        public FileBasis MOV_SULA
        {
            get
            {
                _.Move(REG_SULAMERICA, _MOV_SULA); VarBasis.RedefinePassValue(REG_SULAMERICA, _MOV_SULA, REG_SULAMERICA); return _MOV_SULA;
            }
        }
        public FileBasis _MOV_AUTO { get; set; } = new FileBasis(new PIC("X", "300", "X(300)"));

        public FileBasis MOV_AUTO
        {
            get
            {
                _.Move(REG_MOV_AUTO, _MOV_AUTO); VarBasis.RedefinePassValue(REG_MOV_AUTO, _MOV_AUTO, REG_MOV_AUTO); return _MOV_AUTO;
            }
        }
        public FileBasis _RPF0103B { get; set; } = new FileBasis(new PIC("X", "132", "X(132)"));

        public FileBasis RPF0103B
        {
            get
            {
                _.Move(REG_RPF0103B, _RPF0103B); VarBasis.RedefinePassValue(REG_RPF0103B, _RPF0103B, REG_RPF0103B); return _RPF0103B;
            }
        }
        /*"01   REG-SULAMERICA.*/
        public PF0103B_REG_SULAMERICA REG_SULAMERICA { get; set; } = new PF0103B_REG_SULAMERICA();
        public class PF0103B_REG_SULAMERICA : VarBasis
        {
            /*"     10  REG-TIPO-REGISTRO               PIC X(001).*/
            public StringBasis REG_TIPO_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"     10  REG-NUM-PROPOSTA                PIC 9(014).*/
            public IntBasis REG_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
            /*"     10  FILLER REDEFINES REG-NUM-PROPOSTA.*/
            private _REDEF_PF0103B_FILLER_0 _filler_0 { get; set; }
            public _REDEF_PF0103B_FILLER_0 FILLER_0
            {
                get { _filler_0 = new _REDEF_PF0103B_FILLER_0(); _.Move(REG_NUM_PROPOSTA, _filler_0); VarBasis.RedefinePassValue(REG_NUM_PROPOSTA, _filler_0, REG_NUM_PROPOSTA); _filler_0.ValueChanged += () => { _.Move(_filler_0, REG_NUM_PROPOSTA); }; return _filler_0; }
                set { VarBasis.RedefinePassValue(value, _filler_0, REG_NUM_PROPOSTA); }
            }  //Redefines
            public class _REDEF_PF0103B_FILLER_0 : VarBasis
            {
                /*"         15  REG-NOME-ARQUIVO            PIC X(008).*/
                public StringBasis REG_NOME_ARQUIVO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
                /*"         15  FILLER                      PIC X(006).*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)."), @"");
                /*"     10  FILLER                          PIC X(261).*/

                public _REDEF_PF0103B_FILLER_0()
                {
                    REG_NOME_ARQUIVO.ValueChanged += OnValueChanged;
                    FILLER_1.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "261", "X(261)."), @"");
            /*"     10  REG-ORIGEM                      PIC 9(002).*/
            public IntBasis REG_ORIGEM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"     10  FILLER                          PIC X(022).*/
            public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "22", "X(022)."), @"");
            /*"01   REG-MOV-AUTO                        PIC X(300).*/
        }
        public StringBasis REG_MOV_AUTO { get; set; } = new StringBasis(new PIC("X", "300", "X(300)."), @"");
        /*"01   REG-RPF0103B                       PIC X(132).*/
        public StringBasis REG_RPF0103B { get; set; } = new StringBasis(new PIC("X", "132", "X(132)."), @"");

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"*/
        public IntBasis I01 { get; set; } = new IntBasis(new PIC("9", "4", "9(4)"));
        /*"*/
        public IntBasis I02 { get; set; } = new IntBasis(new PIC("9", "4", "9(4)"));
        /*"*/
        public IntBasis I03 { get; set; } = new IntBasis(new PIC("9", "4", "9(4)"));
        /*"*/
        public IntBasis I04 { get; set; } = new IntBasis(new PIC("9", "4", "9(4)"));
        /*"*/
        public IntBasis I05 { get; set; } = new IntBasis(new PIC("9", "4", "9(4)"));
        /*"*/
        public IntBasis I07 { get; set; } = new IntBasis(new PIC("9", "4", "9(4)"));
        /*"01  VIND-CPF                         PIC S9(4) COMP VALUE +0.*/
        public IntBasis VIND_CPF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-SEXO                        PIC S9(4) COMP VALUE +0.*/
        public IntBasis VIND_SEXO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-UF-EXP                      PIC S9(4) COMP VALUE +0.*/
        public IntBasis VIND_UF_EXP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-DT-NASCI                    PIC S9(4) COMP VALUE +0.*/
        public IntBasis VIND_DT_NASCI { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-DTNASCI                     PIC S9(4) COMP VALUE +0.*/
        public IntBasis VIND_DTNASCI { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-COD-CBO                     PIC S9(4) COMP VALUE +0.*/
        public IntBasis VIND_COD_CBO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-TP-IDENT                    PIC S9(4) COMP VALUE +0.*/
        public IntBasis VIND_TP_IDENT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-DTEXPEDI                    PIC S9(4) COMP VALUE +0.*/
        public IntBasis VIND_DTEXPEDI { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-COD-USUR                    PIC S9(4) COMP VALUE +0.*/
        public IntBasis VIND_COD_USUR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-NUM-IDENT                   PIC S9(4) COMP VALUE +0.*/
        public IntBasis VIND_NUM_IDENT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-ORGAO-EXP                   PIC S9(4) COMP VALUE +0.*/
        public IntBasis VIND_ORGAO_EXP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-TIMESTAMP                   PIC S9(4) COMP VALUE +0.*/
        public IntBasis VIND_TIMESTAMP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-COD-PESSOA                  PIC S9(4) COMP VALUE +0.*/
        public IntBasis VIND_COD_PESSOA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-DTNASC-ESPOSA               PIC S9(4) COMP VALUE +0.*/
        public IntBasis VIND_DTNASC_ESPOSA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01       W-REG-HEADER.*/
        public PF0103B_W_REG_HEADER W_REG_HEADER { get; set; } = new PF0103B_W_REG_HEADER();
        public class PF0103B_W_REG_HEADER : VarBasis
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
            public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "44", "X(044)."), @"");
            /*"     05  W-RH-AGE-GERADORA           PIC  9(004).*/
            public IntBasis W_RH_AGE_GERADORA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"     05  FILLER                      PIC  X(226).*/
            public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "226", "X(226)."), @"");
            /*"01  WAREA-AUXILIAR.*/
        }
        public PF0103B_WAREA_AUXILIAR WAREA_AUXILIAR { get; set; } = new PF0103B_WAREA_AUXILIAR();
        public class PF0103B_WAREA_AUXILIAR : VarBasis
        {
            /*"    05  W-FIM-CBO                     PIC X(003)  VALUE SPACES.*/
            public StringBasis W_FIM_CBO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"    05  W-FIM-FONTES                  PIC X(003)  VALUE SPACES.*/
            public StringBasis W_FIM_FONTES { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"    05  W-FIM-MOVTO-SULA              PIC X(003)  VALUE SPACES.*/
            public StringBasis W_FIM_MOVTO_SULA { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"    05  W-FIM-CURSOR-EMAIL            PIC X(003)  VALUE SPACES.*/
            public StringBasis W_FIM_CURSOR_EMAIL { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"    05  W-FIM-CURSOR-ENDERECO         PIC X(003)  VALUE SPACES.*/
            public StringBasis W_FIM_CURSOR_ENDERECO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"    05  W-LIDO-MOVTO-SULA             PIC 9(008)  VALUE ZEROS.*/
            public IntBasis W_LIDO_MOVTO_SULA { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05  W-AC-CONTROLE                 PIC 9(008)  VALUE ZEROS.*/
            public IntBasis W_AC_CONTROLE { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05  W-OBTER-MAX-PESSOA            PIC X(003)  VALUE 'NAO'.*/
            public StringBasis W_OBTER_MAX_PESSOA { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
            /*"    05  W-EXISTE-TP-5                 PIC X(003)  VALUE SPACES.*/
            public StringBasis W_EXISTE_TP_5 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"    05  W-INDEX                       PIC 9(003)  VALUE ZEROS.*/
            public IntBasis W_INDEX { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
            /*"    05  W-IND-BENEF                   PIC 9(003)  VALUE ZEROS.*/
            public IntBasis W_IND_BENEF { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
            /*"    05  W-IND-BENEF-N                 PIC 9(003)  VALUE ZEROS.*/
            public IntBasis W_IND_BENEF_N { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
            /*"    05  W-IND-INFO                    PIC 9(003)  VALUE ZEROS.*/
            public IntBasis W_IND_INFO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
            /*"    05  W-IND-INFO1                   PIC 9(003)  VALUE ZEROS.*/
            public IntBasis W_IND_INFO1 { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
            /*"    05  W-IND-INFO-N                  PIC 9(003)  VALUE ZEROS.*/
            public IntBasis W_IND_INFO_N { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
            /*"    05  W-INDICE-1                    PIC 9(004)  VALUE ZEROS.*/
            public IntBasis W_INDICE_1 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"    05  W-INDICE-2                    PIC 9(004)  VALUE ZEROS.*/
            public IntBasis W_INDICE_2 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"    05  W-INDICE-ERRO                 PIC 9(002)  VALUE ZEROS.*/
            public IntBasis W_INDICE_ERRO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"    05  W-CONT-LINHAS                 PIC 9(003)  VALUE 100.*/
            public IntBasis W_CONT_LINHAS { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"), 100);
            /*"    05  W-IND-CLAU                    PIC 9(003)  VALUE ZEROS.*/
            public IntBasis W_IND_CLAU { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
            /*"    05  W-IND-CLAU-N                  PIC 9(003)  VALUE ZEROS.*/
            public IntBasis W_IND_CLAU_N { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
            /*"    05  W-IND-ENDER                   PIC 9(003)  VALUE ZEROS.*/
            public IntBasis W_IND_ENDER { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
            /*"    05  W-IND-ENDER1                  PIC 9(003)  VALUE ZEROS.*/
            public IntBasis W_IND_ENDER1 { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
            /*"    05  W-IND-ENDER-A                 PIC 9(003)  VALUE ZEROS.*/
            public IntBasis W_IND_ENDER_A { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
            /*"    05  W-IND-ENDER-N                 PIC 9(003)  VALUE ZEROS.*/
            public IntBasis W_IND_ENDER_N { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
            /*"    05  W-CONTROLE-TP-0               PIC 9(002)  VALUE ZEROS.*/
            public IntBasis W_CONTROLE_TP_0 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"    05  W-QTD-CRITICA                 PIC 9(008)  VALUE ZEROS.*/
            public IntBasis W_QTD_CRITICA { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05  W-QTD-LD-SIVPF-0              PIC 9(008)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_SIVPF_0 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05  W-QTD-LD-SIVPF-1              PIC 9(008)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_SIVPF_1 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05  W-QTD-LD-SIVPF-2              PIC 9(008)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_SIVPF_2 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05  W-QTD-LD-SIVPF-3              PIC 9(008)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_SIVPF_3 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05  W-QTD-LD-SIVPF-4              PIC 9(008)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_SIVPF_4 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05  W-QTD-LD-SIVPF-5              PIC 9(008)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_SIVPF_5 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05  W-QTD-LD-SIVPF-6              PIC 9(008)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_SIVPF_6 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05  W-QTD-LD-SIVPF-7              PIC 9(008)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_SIVPF_7 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05  W-QTD-LD-SIVPF-8              PIC 9(008)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_SIVPF_8 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05  W-QTD-LD-SIVPF-9              PIC 9(008)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_SIVPF_9 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05  W-QTD-LD-SIVPF-A              PIC 9(008)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_SIVPF_A { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05  W-QTD-LD-SIVPF-B              PIC 9(008)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_SIVPF_B { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05  W-QTD-LD-SIVPF-C              PIC 9(008)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_SIVPF_C { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05  W-QTD-LD-SIVPF-D              PIC 9(008)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_SIVPF_D { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05  W-QTD-LD-SIVPF-E              PIC 9(008)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_SIVPF_E { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05  W-QTD-LD-SIVPF-F              PIC 9(008)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_SIVPF_F { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05  W-QTD-LD-SIVPF-G              PIC 9(008)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_SIVPF_G { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05  W-QTD-LD-SIVPF-H              PIC 9(008)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_SIVPF_H { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05  W-QTD-LD-SIVPF-I              PIC 9(008)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_SIVPF_I { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05  W-QTD-LD-SIVPF-J              PIC 9(008)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_SIVPF_J { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05  W-QTD-LD-AUTO-0               PIC 9(008)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_AUTO_0 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05  W-QTD-LD-AUTO-1               PIC 9(008)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_AUTO_1 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05  W-QTD-LD-AUTO-2               PIC 9(008)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_AUTO_2 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05  W-QTD-LD-AUTO-3               PIC 9(008)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_AUTO_3 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05  W-QTD-LD-AUTO-4               PIC 9(008)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_AUTO_4 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05  W-QTD-LD-AUTO-5               PIC 9(008)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_AUTO_5 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05  W-QTD-LD-AUTO-6               PIC 9(008)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_AUTO_6 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05  W-QTD-LD-AUTO-7               PIC 9(008)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_AUTO_7 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05  W-QTD-LD-AUTO-8               PIC 9(008)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_AUTO_8 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05  W-QTD-LD-AUTO-9               PIC 9(008)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_AUTO_9 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05  W-QTD-LD-AUTO-A               PIC 9(008)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_AUTO_A { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05  W-QTD-LD-AUTO-B               PIC 9(008)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_AUTO_B { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05  W-QTD-LD-AUTO-C               PIC 9(008)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_AUTO_C { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05  W-QTD-LD-AUTO-D               PIC 9(008)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_AUTO_D { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05  W-QTD-LD-AUTO-E               PIC 9(008)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_AUTO_E { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05  W-QTD-LD-AUTO-F               PIC 9(008)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_AUTO_F { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05  W-QTD-LD-AUTO-G               PIC 9(008)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_AUTO_G { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05  W-QTD-LD-AUTO-H               PIC 9(008)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_AUTO_H { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05  W-QTD-LD-AUTO-I               PIC 9(008)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_AUTO_I { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05  W-QTD-LD-AUTO-J               PIC 9(008)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_AUTO_J { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05  W-QTD-LH-TIPO-2               PIC 9(008)  VALUE ZEROS.*/
            public IntBasis W_QTD_LH_TIPO_2 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05  W-QTD-LH-TIPO-3               PIC 9(008)  VALUE ZEROS.*/
            public IntBasis W_QTD_LH_TIPO_3 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05  W-SEQ-FONE                    PIC 9(004)  VALUE ZEROS.*/
            public IntBasis W_SEQ_FONE { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"    05  W-SEQ-EMAIL                   PIC 9(004)  VALUE ZEROS.*/
            public IntBasis W_SEQ_EMAIL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"    05  W-COD-PESSOA                  PIC 9(009)  VALUE ZEROS.*/
            public IntBasis W_COD_PESSOA { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    05  W-ACHOU-EMAIL                 PIC X(003)  VALUE 'NAO'.*/
            public StringBasis W_ACHOU_EMAIL { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
            /*"    05  W-COD-RELACION                PIC 9(004)  VALUE ZEROS.*/
            public IntBasis W_COD_RELACION { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"    05  W-ACHOU-ENDERECO              PIC X(003)  VALUE 'NAO'.*/
            public StringBasis W_ACHOU_ENDERECO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
            /*"    05  W-ACHOU-TELEFONE              PIC X(003)  VALUE 'NAO'.*/
            public StringBasis W_ACHOU_TELEFONE { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
            /*"    05  W-ACHOU-RELACIONAMENTO        PIC X(003)  VALUE 'NAO'.*/
            public StringBasis W_ACHOU_RELACIONAMENTO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
            /*"    05  W-OCORR-ENDERECO              PIC 9(004)  VALUE ZEROS.*/
            public IntBasis W_OCORR_ENDERECO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"    05  W-NUM-PROPOSTA-ANT            PIC 9(014)  VALUE ZEROS.*/
            public IntBasis W_NUM_PROPOSTA_ANT { get; set; } = new IntBasis(new PIC("9", "14", "9(014)"));
            /*"    05  W-NUM-IDENTIF                 PIC 9(015)  VALUE ZEROS.*/
            public IntBasis W_NUM_IDENTIF { get; set; } = new IntBasis(new PIC("9", "15", "9(015)"));
            /*"    05  W-NUM-BENEF                   PIC 9(004)  VALUE ZEROS.*/
            public IntBasis W_NUM_BENEF { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"    05  WS-STATUS                     PIC X(002)  VALUE '00'.*/
            public StringBasis WS_STATUS { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"00");
            /*"    05  W-NSAS-FILIAL                 PIC 9(006).*/
            public IntBasis W_NSAS_FILIAL { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"    05  W-NUMR-TITULO                 PIC 9(013)  VALUE ZEROS.*/
            public IntBasis W_NUMR_TITULO { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
            /*"    05  FILLER                        REDEFINES   W-NUMR-TITULO.*/
            private _REDEF_PF0103B_FILLER_6 _filler_6 { get; set; }
            public _REDEF_PF0103B_FILLER_6 FILLER_6
            {
                get { _filler_6 = new _REDEF_PF0103B_FILLER_6(); _.Move(W_NUMR_TITULO, _filler_6); VarBasis.RedefinePassValue(W_NUMR_TITULO, _filler_6, W_NUMR_TITULO); _filler_6.ValueChanged += () => { _.Move(_filler_6, W_NUMR_TITULO); }; return _filler_6; }
                set { VarBasis.RedefinePassValue(value, _filler_6, W_NUMR_TITULO); }
            }  //Redefines
            public class _REDEF_PF0103B_FILLER_6 : VarBasis
            {
                /*"      10    WTITL-ZEROS               PIC 9(002).*/
                public IntBasis WTITL_ZEROS { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10    WTITL-SEQUENCIA           PIC 9(010).*/
                public IntBasis WTITL_SEQUENCIA { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
                /*"      10    WTITL-DIGITO              PIC 9(001).*/
                public IntBasis WTITL_DIGITO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    05       W-TAB-BENEFICIARIOS.*/

                public _REDEF_PF0103B_FILLER_6()
                {
                    WTITL_ZEROS.ValueChanged += OnValueChanged;
                    WTITL_SEQUENCIA.ValueChanged += OnValueChanged;
                    WTITL_DIGITO.ValueChanged += OnValueChanged;
                }

            }
            public PF0103B_W_TAB_BENEFICIARIOS W_TAB_BENEFICIARIOS { get; set; } = new PF0103B_W_TAB_BENEFICIARIOS();
            public class PF0103B_W_TAB_BENEFICIARIOS : VarBasis
            {
                /*"       10    W-TAB-BENEF-REG   OCCURS 30  TIMES INDEXED BY I01.*/
                public ListBasis<PF0103B_W_TAB_BENEF_REG> W_TAB_BENEF_REG { get; set; } = new ListBasis<PF0103B_W_TAB_BENEF_REG>(30);
                public class PF0103B_W_TAB_BENEF_REG : VarBasis
                {
                    /*"          15 W-TB-REG-BENEFI   PIC  X(300).*/
                    public StringBasis W_TB_REG_BENEFI { get; set; } = new StringBasis(new PIC("X", "300", "X(300)."), @"");
                    /*"    05       W-TAB-INFORMACOES.*/
                }
            }
            public PF0103B_W_TAB_INFORMACOES W_TAB_INFORMACOES { get; set; } = new PF0103B_W_TAB_INFORMACOES();
            public class PF0103B_W_TAB_INFORMACOES : VarBasis
            {
                /*"       10    W-TAB-INFO-REG   OCCURS 30  TIMES INDEXED BY I02.*/
                public ListBasis<PF0103B_W_TAB_INFO_REG> W_TAB_INFO_REG { get; set; } = new ListBasis<PF0103B_W_TAB_INFO_REG>(30);
                public class PF0103B_W_TAB_INFO_REG : VarBasis
                {
                    /*"          15 W-TB-REG-INFORMACOES PIC  X(300).*/
                    public StringBasis W_TB_REG_INFORMACOES { get; set; } = new StringBasis(new PIC("X", "300", "X(300)."), @"");
                    /*"    05       W-TAB-CLAUSULAS.*/
                }
            }
            public PF0103B_W_TAB_CLAUSULAS W_TAB_CLAUSULAS { get; set; } = new PF0103B_W_TAB_CLAUSULAS();
            public class PF0103B_W_TAB_CLAUSULAS : VarBasis
            {
                /*"       10    W-TAB-CLAU-REG   OCCURS 30 TIMES INDEXED BY I03.*/
                public ListBasis<PF0103B_W_TAB_CLAU_REG> W_TAB_CLAU_REG { get; set; } = new ListBasis<PF0103B_W_TAB_CLAU_REG>(30);
                public class PF0103B_W_TAB_CLAU_REG : VarBasis
                {
                    /*"          15 W-TB-REG-CLAUSULA PIC  X(300).*/
                    public StringBasis W_TB_REG_CLAUSULA { get; set; } = new StringBasis(new PIC("X", "300", "X(300)."), @"");
                    /*"    05       W-TB-ENDERECOS-N.*/
                }
            }
            public PF0103B_W_TB_ENDERECOS_N W_TB_ENDERECOS_N { get; set; } = new PF0103B_W_TB_ENDERECOS_N();
            public class PF0103B_W_TB_ENDERECOS_N : VarBasis
            {
                /*"       10    W-TAB-END-REG-N   OCCURS 30 TIMES INDEXED BY I04.*/
                public ListBasis<PF0103B_W_TAB_END_REG_N> W_TAB_END_REG_N { get; set; } = new ListBasis<PF0103B_W_TAB_END_REG_N>(30);
                public class PF0103B_W_TAB_END_REG_N : VarBasis
                {
                    /*"          15 W-TB-REG-ENDERECOS-N     PIC  X(300).*/
                    public StringBasis W_TB_REG_ENDERECOS_N { get; set; } = new StringBasis(new PIC("X", "300", "X(300)."), @"");
                    /*"    05      W-TB-ENDERECOS-A.*/
                }
            }
            public PF0103B_W_TB_ENDERECOS_A W_TB_ENDERECOS_A { get; set; } = new PF0103B_W_TB_ENDERECOS_A();
            public class PF0103B_W_TB_ENDERECOS_A : VarBasis
            {
                /*"      07    W-TAB-END-REG-A OCCURS 30 TIMES INDEXED BY I05.*/
                public ListBasis<PF0103B_W_TAB_END_REG_A> W_TAB_END_REG_A { get; set; } = new ListBasis<PF0103B_W_TAB_END_REG_A>(30);
                public class PF0103B_W_TAB_END_REG_A : VarBasis
                {
                    /*"        10  W-TB-REG-ENDERECOS-A.*/
                    public PF0103B_W_TB_REG_ENDERECOS_A W_TB_REG_ENDERECOS_A { get; set; } = new PF0103B_W_TB_REG_ENDERECOS_A();
                    public class PF0103B_W_TB_REG_ENDERECOS_A : VarBasis
                    {
                        /*"            15 COD-PESSOA           PIC S9(9) USAGE COMP.*/
                        public IntBasis COD_PESSOA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
                        /*"            15 OCORR-ENDERECO       PIC S9(4) USAGE COMP.*/
                        public IntBasis OCORR_ENDERECO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
                        /*"            15 ENDERECO             PIC X(40).*/
                        public StringBasis ENDERECO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
                        /*"            15 TIPO-ENDER           PIC S9(4) USAGE COMP.*/
                        public IntBasis TIPO_ENDER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
                        /*"            15 COMPL-ENDER          PIC X(15).*/
                        public StringBasis COMPL_ENDER { get; set; } = new StringBasis(new PIC("X", "15", "X(15)."), @"");
                        /*"            15 BAIRRO               PIC X(20).*/
                        public StringBasis BAIRRO { get; set; } = new StringBasis(new PIC("X", "20", "X(20)."), @"");
                        /*"            15 CEP                  PIC S9(9) USAGE COMP.*/
                        public IntBasis CEP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
                        /*"            15 CIDADE               PIC X(20).*/
                        public StringBasis CIDADE { get; set; } = new StringBasis(new PIC("X", "20", "X(20)."), @"");
                        /*"            15 SIGLA-UF             PIC X(2).*/
                        public StringBasis SIGLA_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(2)."), @"");
                        /*"            15 SITUACAO-ENDERECO    PIC X(1).*/
                        public StringBasis SITUACAO_ENDERECO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
                        /*"            15 COD-USUARIO          PIC X(8).*/
                        public StringBasis COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
                        /*"            15 TIMESTAMP            PIC X(26).*/
                        public StringBasis TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
                        /*"    05      TAB-CBO.*/
                    }
                }
            }
            public PF0103B_TAB_CBO TAB_CBO { get; set; } = new PF0103B_TAB_CBO();
            public class PF0103B_TAB_CBO : VarBasis
            {
                /*"     10    FILLER    OCCURS    999   TIMES.*/
                public ListBasis<PF0103B_FILLER_7> FILLER_7 { get; set; } = new ListBasis<PF0103B_FILLER_7>(999);
                public class PF0103B_FILLER_7 : VarBasis
                {
                    /*"       15  TAB-COD-CBO              PIC  9(4).*/
                    public IntBasis TAB_COD_CBO { get; set; } = new IntBasis(new PIC("9", "4", "9(4)."));
                    /*"       15  TAB-DESCR-CBO            PIC  X(5).*/
                    public StringBasis TAB_DESCR_CBO { get; set; } = new StringBasis(new PIC("X", "5", "X(5)."), @"");
                    /*"       15  TAB-DESCR-CBO-C          PIC  X(20).*/
                    public StringBasis TAB_DESCR_CBO_C { get; set; } = new StringBasis(new PIC("X", "20", "X(20)."), @"");
                    /*"    05      TAB-FILIAL.*/
                }
            }
            public PF0103B_TAB_FILIAL TAB_FILIAL { get; set; } = new PF0103B_TAB_FILIAL();
            public class PF0103B_TAB_FILIAL : VarBasis
            {
                /*"     10    TAB-FILIAIS OCCURS    9999   TIMES INDEXED BY I07.*/
                public ListBasis<PF0103B_TAB_FILIAIS> TAB_FILIAIS { get; set; } = new ListBasis<PF0103B_TAB_FILIAIS>(9999);
                public class PF0103B_TAB_FILIAIS : VarBasis
                {
                    /*"       15  TAB-COD-FILIAL           PIC  9(4).*/
                    public IntBasis TAB_COD_FILIAL { get; set; } = new IntBasis(new PIC("9", "4", "9(4)."));
                    /*"    05  W-DATA-TRABALHO               PIC 9(008)  VALUE ZEROS.*/
                }
            }
            public IntBasis W_DATA_TRABALHO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05  FILLER REDEFINES W-DATA-TRABALHO.*/
            private _REDEF_PF0103B_FILLER_8 _filler_8 { get; set; }
            public _REDEF_PF0103B_FILLER_8 FILLER_8
            {
                get { _filler_8 = new _REDEF_PF0103B_FILLER_8(); _.Move(W_DATA_TRABALHO, _filler_8); VarBasis.RedefinePassValue(W_DATA_TRABALHO, _filler_8, W_DATA_TRABALHO); _filler_8.ValueChanged += () => { _.Move(_filler_8, W_DATA_TRABALHO); }; return _filler_8; }
                set { VarBasis.RedefinePassValue(value, _filler_8, W_DATA_TRABALHO); }
            }  //Redefines
            public class _REDEF_PF0103B_FILLER_8 : VarBasis
            {
                /*"        07  W-DIA-TRABALHO            PIC 9(002).*/
                public IntBasis W_DIA_TRABALHO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"        07  W-MES-TRABALHO            PIC 9(002).*/
                public IntBasis W_MES_TRABALHO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"        07  W-ANO-TRABALHO            PIC 9(004).*/
                public IntBasis W_ANO_TRABALHO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05  W-DATA-NASCIMENTO             PIC 9(008)  VALUE ZEROS.*/

                public _REDEF_PF0103B_FILLER_8()
                {
                    W_DIA_TRABALHO.ValueChanged += OnValueChanged;
                    W_MES_TRABALHO.ValueChanged += OnValueChanged;
                    W_ANO_TRABALHO.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis W_DATA_NASCIMENTO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05  FILLER REDEFINES W-DATA-NASCIMENTO.*/
            private _REDEF_PF0103B_FILLER_9 _filler_9 { get; set; }
            public _REDEF_PF0103B_FILLER_9 FILLER_9
            {
                get { _filler_9 = new _REDEF_PF0103B_FILLER_9(); _.Move(W_DATA_NASCIMENTO, _filler_9); VarBasis.RedefinePassValue(W_DATA_NASCIMENTO, _filler_9, W_DATA_NASCIMENTO); _filler_9.ValueChanged += () => { _.Move(_filler_9, W_DATA_NASCIMENTO); }; return _filler_9; }
                set { VarBasis.RedefinePassValue(value, _filler_9, W_DATA_NASCIMENTO); }
            }  //Redefines
            public class _REDEF_PF0103B_FILLER_9 : VarBasis
            {
                /*"        07  W-DIA-NASCIMENTO          PIC 9(002).*/
                public IntBasis W_DIA_NASCIMENTO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"        07  W-MES-NASCIMENTO          PIC 9(002).*/
                public IntBasis W_MES_NASCIMENTO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"        07  W-ANO-NASCIMENTO          PIC 9(004).*/
                public IntBasis W_ANO_NASCIMENTO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05  W-DTMOVABE                    PIC X(010).*/

                public _REDEF_PF0103B_FILLER_9()
                {
                    W_DIA_NASCIMENTO.ValueChanged += OnValueChanged;
                    W_MES_NASCIMENTO.ValueChanged += OnValueChanged;
                    W_ANO_NASCIMENTO.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis W_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    05  W-DTMOVABE1 REDEFINES W-DTMOVABE.*/
            private _REDEF_PF0103B_W_DTMOVABE1 _w_dtmovabe1 { get; set; }
            public _REDEF_PF0103B_W_DTMOVABE1 W_DTMOVABE1
            {
                get { _w_dtmovabe1 = new _REDEF_PF0103B_W_DTMOVABE1(); _.Move(W_DTMOVABE, _w_dtmovabe1); VarBasis.RedefinePassValue(W_DTMOVABE, _w_dtmovabe1, W_DTMOVABE); _w_dtmovabe1.ValueChanged += () => { _.Move(_w_dtmovabe1, W_DTMOVABE); }; return _w_dtmovabe1; }
                set { VarBasis.RedefinePassValue(value, _w_dtmovabe1, W_DTMOVABE); }
            }  //Redefines
            public class _REDEF_PF0103B_W_DTMOVABE1 : VarBasis
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

                public _REDEF_PF0103B_W_DTMOVABE1()
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
            private _REDEF_PF0103B_W_DTMOVABE_I1 _w_dtmovabe_i1 { get; set; }
            public _REDEF_PF0103B_W_DTMOVABE_I1 W_DTMOVABE_I1
            {
                get { _w_dtmovabe_i1 = new _REDEF_PF0103B_W_DTMOVABE_I1(); _.Move(W_DTMOVABE_I, _w_dtmovabe_i1); VarBasis.RedefinePassValue(W_DTMOVABE_I, _w_dtmovabe_i1, W_DTMOVABE_I); _w_dtmovabe_i1.ValueChanged += () => { _.Move(_w_dtmovabe_i1, W_DTMOVABE_I); }; return _w_dtmovabe_i1; }
                set { VarBasis.RedefinePassValue(value, _w_dtmovabe_i1, W_DTMOVABE_I); }
            }  //Redefines
            public class _REDEF_PF0103B_W_DTMOVABE_I1 : VarBasis
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

                public _REDEF_PF0103B_W_DTMOVABE_I1()
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
            private _REDEF_PF0103B_W_DATA_SQL1 _w_data_sql1 { get; set; }
            public _REDEF_PF0103B_W_DATA_SQL1 W_DATA_SQL1
            {
                get { _w_data_sql1 = new _REDEF_PF0103B_W_DATA_SQL1(); _.Move(W_DATA_SQL, _w_data_sql1); VarBasis.RedefinePassValue(W_DATA_SQL, _w_data_sql1, W_DATA_SQL); _w_data_sql1.ValueChanged += () => { _.Move(_w_data_sql1, W_DATA_SQL); }; return _w_data_sql1; }
                set { VarBasis.RedefinePassValue(value, _w_data_sql1, W_DATA_SQL); }
            }  //Redefines
            public class _REDEF_PF0103B_W_DATA_SQL1 : VarBasis
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

                public _REDEF_PF0103B_W_DATA_SQL1()
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
            private _REDEF_PF0103B_W_DATA_SIT_RD _w_data_sit_rd { get; set; }
            public _REDEF_PF0103B_W_DATA_SIT_RD W_DATA_SIT_RD
            {
                get { _w_data_sit_rd = new _REDEF_PF0103B_W_DATA_SIT_RD(); _.Move(W_DATA_SITUACAO, _w_data_sit_rd); VarBasis.RedefinePassValue(W_DATA_SITUACAO, _w_data_sit_rd, W_DATA_SITUACAO); _w_data_sit_rd.ValueChanged += () => { _.Move(_w_data_sit_rd, W_DATA_SITUACAO); }; return _w_data_sit_rd; }
                set { VarBasis.RedefinePassValue(value, _w_data_sit_rd, W_DATA_SITUACAO); }
            }  //Redefines
            public class _REDEF_PF0103B_W_DATA_SIT_RD : VarBasis
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
                /*"    05              DPARM01X.*/

                public _REDEF_PF0103B_W_DATA_SIT_RD()
                {
                    W_DIA_SITUACAO.ValueChanged += OnValueChanged;
                    W_BARRA1_2.ValueChanged += OnValueChanged;
                    W_MES_SITUACAO.ValueChanged += OnValueChanged;
                    W_BARRA2_2.ValueChanged += OnValueChanged;
                    W_ANO_SITUACAO.ValueChanged += OnValueChanged;
                }

            }
            public PF0103B_DPARM01X DPARM01X { get; set; } = new PF0103B_DPARM01X();
            public class PF0103B_DPARM01X : VarBasis
            {
                /*"      07            DPARM01           PIC  9(010).*/
                public IntBasis DPARM01 { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
                /*"      07            DPARM01-R         REDEFINES   DPARM01.*/
                private _REDEF_PF0103B_DPARM01_R _dparm01_r { get; set; }
                public _REDEF_PF0103B_DPARM01_R DPARM01_R
                {
                    get { _dparm01_r = new _REDEF_PF0103B_DPARM01_R(); _.Move(DPARM01, _dparm01_r); VarBasis.RedefinePassValue(DPARM01, _dparm01_r, DPARM01); _dparm01_r.ValueChanged += () => { _.Move(_dparm01_r, DPARM01); }; return _dparm01_r; }
                    set { VarBasis.RedefinePassValue(value, _dparm01_r, DPARM01); }
                }  //Redefines
                public class _REDEF_PF0103B_DPARM01_R : VarBasis
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

                    public _REDEF_PF0103B_DPARM01_R()
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
                /*"01  WS-TIME.*/
            }
        }
        public PF0103B_WS_TIME WS_TIME { get; set; } = new PF0103B_WS_TIME();
        public class PF0103B_WS_TIME : VarBasis
        {
            /*"    05 WS-TIME-N                     PIC 9(06).*/
            public IntBasis WS_TIME_N { get; set; } = new IntBasis(new PIC("9", "6", "9(06)."));
            /*"    05 FILLER                        PIC X(02).*/
            public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "2", "X(02)."), @"");
            /*"01  WS-TIME-EDIT                     PIC 99.99.99.*/
        }
        public IntBasis WS_TIME_EDIT { get; set; } = new IntBasis(new PIC("9", "6", "99.99.99."));
        /*"01  WABEND.*/
        public PF0103B_WABEND WABEND { get; set; } = new PF0103B_WABEND();
        public class PF0103B_WABEND : VarBasis
        {
            /*"      10    FILLER                   PIC  X(010) VALUE            'PF0103B  '.*/
            public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"PF0103B  ");
            /*"      10    FILLER                   PIC  X(028) VALUE            ' *** ERRO  EXEC SQL *** '.*/
            public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @" *** ERRO  EXEC SQL *** ");
            /*"      10    FILLER                   PIC  X(014) VALUE            '    SQLCODE = '.*/
            public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE = ");
            /*"      10    WSQLCODE                 PIC  ZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
            /*"      10    FILLER                   PIC  X(014)   VALUE            '   SQLERRD1 = '.*/
            public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD1 = ");
            /*"      10    WSQLERRD1                PIC  ZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLERRD1 { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
            /*"      10    FILLER                   PIC  X(014)   VALUE            '   SQLERRD2 = '.*/
            public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD2 = ");
            /*"      10    WSQLERRD2                PIC  ZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLERRD2 { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
            /*"      10    FILLER                   PIC  X(014)   VALUE            '   SQLERRD2 = '.*/
            public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD2 = ");
            /*"      10      LOCALIZA-ABEND-1.*/
            public PF0103B_LOCALIZA_ABEND_1 LOCALIZA_ABEND_1 { get; set; } = new PF0103B_LOCALIZA_ABEND_1();
            public class PF0103B_LOCALIZA_ABEND_1 : VarBasis
            {
                /*"        15    FILLER                   PIC  X(012)   VALUE              'PARAGRAFO = '.*/
                public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"PARAGRAFO = ");
                /*"        15    PARAGRAFO                PIC  X(040) VALUE SPACES.*/
                public StringBasis PARAGRAFO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"      10      LOCALIZA-ABEND-2.*/
            }
            public PF0103B_LOCALIZA_ABEND_2 LOCALIZA_ABEND_2 { get; set; } = new PF0103B_LOCALIZA_ABEND_2();
            public class PF0103B_LOCALIZA_ABEND_2 : VarBasis
            {
                /*"        15    FILLER                   PIC  X(012)   VALUE              'COMANDO   = '.*/
                public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"COMANDO   = ");
                /*"        15    COMANDO                  PIC  X(060) VALUE SPACES.*/
                public StringBasis COMANDO { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"");
                /*"01              LC00.*/
            }
        }
        public PF0103B_LC00 LC00 { get; set; } = new PF0103B_LC00();
        public class PF0103B_LC00 : VarBasis
        {
            /*"  05            LC01.*/
            public PF0103B_LC01 LC01 { get; set; } = new PF0103B_LC01();
            public class PF0103B_LC01 : VarBasis
            {
                /*"    10          LC01-RELATORIO  PIC  X(008) VALUE 'RPF0103B'.*/
                public StringBasis LC01_RELATORIO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"RPF0103B");
                /*"    10          FILLER          PIC  X(048) VALUE  SPACES.*/
                public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "48", "X(048)"), @"");
                /*"    10          FILLER          PIC  X(028) VALUE     'C A I X A    S E G U R O S '.*/
                public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @"C A I X A    S E G U R O S ");
                /*"    10          FILLER          PIC  X(025) VALUE  SPACES.*/
                public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"");
                /*"    10          FILLER          PIC  X(012) VALUE '    PAGINA: '*/
                public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"    PAGINA: ");
                /*"    10          LC01-PAGINA     PIC  9(04).*/
                public IntBasis LC01_PAGINA { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                /*"  05            LC02.*/
            }
            public PF0103B_LC02 LC02 { get; set; } = new PF0103B_LC02();
            public class PF0103B_LC02 : VarBasis
            {
                /*"    10          FILLER          PIC  X(113) VALUE  SPACES.*/
                public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "113", "X(113)"), @"");
                /*"    10          FILLER          PIC  X(008) VALUE 'DATA..: '.*/
                public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"DATA..: ");
                /*"    10          LC02-DATA       PIC  X(010) VALUE  SPACES.*/
                public StringBasis LC02_DATA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"  05            LC03.*/
            }
            public PF0103B_LC03 LC03 { get; set; } = new PF0103B_LC03();
            public class PF0103B_LC03 : VarBasis
            {
                /*"    10          FILLER          PIC  X(026) VALUE  SPACES.*/
                public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @"");
                /*"    10          FILLER          PIC  X(057) VALUE    'RELATORIO DE CRITICA DO MOVIMENTO DAS PROPOSTAS RECEBIDAS'.*/
                public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "57", "X(057)"), @"RELATORIO DE CRITICA DO MOVIMENTO DAS PROPOSTAS RECEBIDAS");
                /*"    10          FILLER          PIC  X(023) VALUE    ' - SIMULADOR SULAMERICA'.*/
                public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "23", "X(023)"), @" - SIMULADOR SULAMERICA");
                /*"    10          FILLER          PIC  X(007) VALUE  SPACES.*/
                public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"");
                /*"    10          FILLER          PIC  X(008) VALUE 'HORA..: '.*/
                public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"HORA..: ");
                /*"    10          LC03-HORA       PIC  X(008) VALUE  SPACES.*/
                public StringBasis LC03_HORA { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
                /*"  05            LC04.*/
            }
            public PF0103B_LC04 LC04 { get; set; } = new PF0103B_LC04();
            public class PF0103B_LC04 : VarBasis
            {
                /*"    10          FILLER            PIC  X(020) VALUE               'ARQUIVO PROCESSADO: '.*/
                public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"ARQUIVO PROCESSADO: ");
                /*"    10          LC04-NSAS-SIVPF   PIC  ZZZZZ9.*/
                public IntBasis LC04_NSAS_SIVPF { get; set; } = new IntBasis(new PIC("9", "6", "ZZZZZ9."));
                /*"    10          FILLER            PIC  X(013) VALUE               ' - GERADO EM '.*/
                public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" - GERADO EM ");
                /*"    10          LC04-DATA-GERACAO PIC  X(010).*/
                public StringBasis LC04_DATA_GERACAO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"    10          FILLER            PIC  X(082) VALUE  SPACES.*/
                public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "82", "X(082)"), @"");
                /*"  05            LC05.*/
            }
            public PF0103B_LC05 LC05 { get; set; } = new PF0103B_LC05();
            public class PF0103B_LC05 : VarBasis
            {
                /*"    10          FILLER            PIC  X(013) VALUE               '    PROPOSTA '.*/
                public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"    PROPOSTA ");
                /*"    10          FILLER            PIC  X(017) VALUE               '       ORIGEM    '.*/
                public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "17", "X(017)"), @"       ORIGEM    ");
                /*"    10          FILLER            PIC  X(015) VALUE SPACES.*/
                public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"");
                /*"    10          FILLER            PIC  X(009) VALUE               ' SITUACAO'.*/
                public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @" SITUACAO");
                /*"    10          FILLER            PIC  X(008) VALUE SPACES.*/
                public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
                /*"    10          FILLER            PIC  X(013) VALUE               'DATA SITUACAO'.*/
                public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"DATA SITUACAO");
                /*"    10          FILLER            PIC  X(004) VALUE SPACES.*/
                public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                /*"    10          FILLER            PIC  X(027) VALUE               'DESCRICAO DA INCONSISTENCIA'.*/
                public StringBasis FILLER_40 { get; set; } = new StringBasis(new PIC("X", "27", "X(027)"), @"DESCRICAO DA INCONSISTENCIA");
                /*"  05            LC06.*/
            }
            public PF0103B_LC06 LC06 { get; set; } = new PF0103B_LC06();
            public class PF0103B_LC06 : VarBasis
            {
                /*"    10          FILLER              PIC  X(001) VALUE  SPACES.*/
                public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10          LC06-NUM-PROPOSTA   PIC  9(014).*/
                public IntBasis LC06_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
                /*"    10          FILLER              PIC  X(005) VALUE  SPACES.*/
                public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
                /*"    10          LC06-ORIGEM         PIC  X(021).*/
                public StringBasis LC06_ORIGEM { get; set; } = new StringBasis(new PIC("X", "21", "X(021)."), @"");
                /*"    10          FILLER              PIC  X(007) VALUE  SPACES.*/
                public StringBasis FILLER_43 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"");
                /*"    10          LC06-SITUACAO       PIC  X(003).*/
                public StringBasis LC06_SITUACAO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
                /*"    10          FILLER              PIC  X(012) VALUE  SPACES.*/
                public StringBasis FILLER_44 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"");
                /*"    10          LC06-DATA-SITUACAO  PIC  X(010).*/
                public StringBasis LC06_DATA_SITUACAO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"    10          FILLER              PIC  X(006) VALUE  SPACES.*/
                public StringBasis FILLER_45 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"");
                /*"    10          LC06-DESCRICAO      PIC  X(049).*/
                public StringBasis LC06_DESCRICAO { get; set; } = new StringBasis(new PIC("X", "49", "X(049)."), @"");
                /*"  05            LC07.*/
            }
            public PF0103B_LC07 LC07 { get; set; } = new PF0103B_LC07();
            public class PF0103B_LC07 : VarBasis
            {
                /*"    10          FILLER          PIC  X(132) VALUE ALL '-'.*/
                public StringBasis FILLER_46 { get; set; } = new StringBasis(new PIC("X", "132", "X(132)"), @"ALL");
                /*"01  AREA-DAS-TABELAS.*/
            }
        }
        public PF0103B_AREA_DAS_TABELAS AREA_DAS_TABELAS { get; set; } = new PF0103B_AREA_DAS_TABELAS();
        public class PF0103B_AREA_DAS_TABELAS : VarBasis
        {
            /*"    05 W-TAB-CONSISTENCIA.*/
            public PF0103B_W_TAB_CONSISTENCIA W_TAB_CONSISTENCIA { get; set; } = new PF0103B_W_TAB_CONSISTENCIA();
            public class PF0103B_W_TAB_CONSISTENCIA : VarBasis
            {
                /*"       10 FILLER  OCCURS 500   TIMES.*/
                public ListBasis<PF0103B_FILLER_47> FILLER_47 { get; set; } = new ListBasis<PF0103B_FILLER_47>(500);
                public class PF0103B_FILLER_47 : VarBasis
                {
                    /*"          15 W-TB-CANAL        PIC  9(002).*/
                    public IntBasis W_TB_CANAL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"          15 W-TB-NSAS         PIC  9(006).*/
                    public IntBasis W_TB_NSAS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                    /*"          15 W-TB-ORIGEM       PIC  9(002).*/
                    public IntBasis W_TB_ORIGEM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"          15 W-TB-NUM-PROPOSTA PIC  9(014).*/
                    public IntBasis W_TB_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
                    /*"          15 W-TB-SIT-PROPOSTA PIC  X(003).*/
                    public StringBasis W_TB_SIT_PROPOSTA { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
                    /*"          15 W-TB-DT-SITUACAO  PIC  9(008).*/
                    public IntBasis W_TB_DT_SITUACAO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                    /*"          15 W-TB-COD-DESCRI   PIC  9(002).*/
                    public IntBasis W_TB_COD_DESCRI { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"    05 W-TAB-DESCRICAO.*/
                }
            }
            public PF0103B_W_TAB_DESCRICAO W_TAB_DESCRICAO { get; set; } = new PF0103B_W_TAB_DESCRICAO();
            public class PF0103B_W_TAB_DESCRICAO : VarBasis
            {
                /*"       10 FILLER               PIC  X(050)     VALUE          '01SICOB CEF JA UTILIZADO EM OUTRA PROPOSTA        '.*/
                public StringBasis FILLER_48 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"01SICOB CEF JA UTILIZADO EM OUTRA PROPOSTA        ");
                /*"       10 FILLER               PIC  X(050)     VALUE          '02PROPOSTA EM DUPLICIDADE, JA CADASTRADA NO SISPF '.*/
                public StringBasis FILLER_49 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"02PROPOSTA EM DUPLICIDADE, JA CADASTRADA NO SISPF ");
                /*"    05 W-TAB-DESCRICAO-RD  REDEFINES W-TAB-DESCRICAO                           OCCURS 02.*/
            }
            private ListBasis<_REDEF_PF0103B_W_TAB_DESCRICAO_RD> _w_tab_descricao_rd { get; set; }
            public ListBasis<_REDEF_PF0103B_W_TAB_DESCRICAO_RD> W_TAB_DESCRICAO_RD
            {
                get { _w_tab_descricao_rd = new ListBasis<_REDEF_PF0103B_W_TAB_DESCRICAO_RD>(02); _.Move(W_TAB_DESCRICAO, _w_tab_descricao_rd); VarBasis.RedefinePassValue(W_TAB_DESCRICAO, _w_tab_descricao_rd, W_TAB_DESCRICAO); _w_tab_descricao_rd.ValueChanged += () => { _.Move(_w_tab_descricao_rd, W_TAB_DESCRICAO); }; return _w_tab_descricao_rd; }
                set { VarBasis.RedefinePassValue(value, _w_tab_descricao_rd, W_TAB_DESCRICAO); }
            }  //Redefines
            public class _REDEF_PF0103B_W_TAB_DESCRICAO_RD : VarBasis
            {
                /*"       10 W-TB-CODIGO       PIC  9(002).*/
                public IntBasis W_TB_CODIGO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       10 W-TB-DESCRI-ERRO  PIC  X(048).*/
                public StringBasis W_TB_DESCRI_ERRO { get; set; } = new StringBasis(new PIC("X", "48", "X(048)."), @"");
                /*"    05 W-TAB-CANAL.*/

                public _REDEF_PF0103B_W_TAB_DESCRICAO_RD()
                {
                    W_TB_CODIGO.ValueChanged += OnValueChanged;
                    W_TB_DESCRI_ERRO.ValueChanged += OnValueChanged;
                }

            }
            public PF0103B_W_TAB_CANAL W_TAB_CANAL { get; set; } = new PF0103B_W_TAB_CANAL();
            public class PF0103B_W_TAB_CANAL : VarBasis
            {
                /*"       10 FILLER               PIC  X(015)     VALUE          '01CAIXA    '.*/
                public StringBasis FILLER_50 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"01CAIXA    ");
                /*"       10 FILLER               PIC  X(015)     VALUE          '02CAIXA SEGUROS'.*/
                public StringBasis FILLER_51 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"02CAIXA SEGUROS");
                /*"       10 FILLER               PIC  X(015)     VALUE          '03CORRETOR '.*/
                public StringBasis FILLER_52 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"03CORRETOR ");
                /*"       10 FILLER               PIC  X(015)     VALUE          '04CORREIO  '.*/
                public StringBasis FILLER_53 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"04CORREIO  ");
                /*"       10 FILLER               PIC  X(015)     VALUE          '05GITEL    '.*/
                public StringBasis FILLER_54 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"05GITEL    ");
                /*"       10 FILLER               PIC  X(015)     VALUE          '07INTERNET '.*/
                public StringBasis FILLER_55 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"07INTERNET ");
                /*"       10 FILLER               PIC  X(015)     VALUE          '08INTRANET '.*/
                public StringBasis FILLER_56 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"08INTRANET ");
                /*"    05 W-TAB-CANAL-RD      REDEFINES W-TAB-CANAL                           OCCURS 7.*/
            }
            private ListBasis<_REDEF_PF0103B_W_TAB_CANAL_RD> _w_tab_canal_rd { get; set; }
            public ListBasis<_REDEF_PF0103B_W_TAB_CANAL_RD> W_TAB_CANAL_RD
            {
                get { _w_tab_canal_rd = new ListBasis<_REDEF_PF0103B_W_TAB_CANAL_RD>(7); _.Move(W_TAB_CANAL, _w_tab_canal_rd); VarBasis.RedefinePassValue(W_TAB_CANAL, _w_tab_canal_rd, W_TAB_CANAL); _w_tab_canal_rd.ValueChanged += () => { _.Move(_w_tab_canal_rd, W_TAB_CANAL); }; return _w_tab_canal_rd; }
                set { VarBasis.RedefinePassValue(value, _w_tab_canal_rd, W_TAB_CANAL); }
            }  //Redefines
            public class _REDEF_PF0103B_W_TAB_CANAL_RD : VarBasis
            {
                /*"       10 W-TB-COD-CANAL    PIC  9(002).*/
                public IntBasis W_TB_COD_CANAL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       10 W-TB-DESCRI-CANAL PIC  X(013).*/
                public StringBasis W_TB_DESCRI_CANAL { get; set; } = new StringBasis(new PIC("X", "13", "X(013)."), @"");
                /*"    05 W-TAB-ORIGEM.*/

                public _REDEF_PF0103B_W_TAB_CANAL_RD()
                {
                    W_TB_COD_CANAL.ValueChanged += OnValueChanged;
                    W_TB_DESCRI_CANAL.ValueChanged += OnValueChanged;
                }

            }
            public PF0103B_W_TAB_ORIGEM W_TAB_ORIGEM { get; set; } = new PF0103B_W_TAB_ORIGEM();
            public class PF0103B_W_TAB_ORIGEM : VarBasis
            {
                /*"       10 FILLER               PIC  X(023)     VALUE          '01SIGPF                '.*/
                public StringBasis FILLER_57 { get; set; } = new StringBasis(new PIC("X", "23", "X(023)"), @"01SIGPF                ");
                /*"       10 FILLER               PIC  X(023)     VALUE          '02CAIXA&PREVIDENCIA    '.*/
                public StringBasis FILLER_58 { get; set; } = new StringBasis(new PIC("X", "23", "X(023)"), @"02CAIXA&PREVIDENCIA    ");
                /*"       10 FILLER               PIC  X(023)     VALUE          '03SIGAT                '.*/
                public StringBasis FILLER_59 { get; set; } = new StringBasis(new PIC("X", "23", "X(023)"), @"03SIGAT                ");
                /*"       10 FILLER               PIC  X(023)     VALUE          '04SASSE                '.*/
                public StringBasis FILLER_60 { get; set; } = new StringBasis(new PIC("X", "23", "X(023)"), @"04SASSE                ");
                /*"       10 FILLER               PIC  X(023)     VALUE          '05CAIXA&CAPITALIZACAO  '.*/
                public StringBasis FILLER_61 { get; set; } = new StringBasis(new PIC("X", "23", "X(023)"), @"05CAIXA&CAPITALIZACAO  ");
                /*"       10 FILLER               PIC  X(023)     VALUE          '06MANUAL               '.*/
                public StringBasis FILLER_62 { get; set; } = new StringBasis(new PIC("X", "23", "X(023)"), @"06MANUAL               ");
                /*"       10 FILLER               PIC  X(023)     VALUE          '07VENDAS REMOTAS       '.*/
                public StringBasis FILLER_63 { get; set; } = new StringBasis(new PIC("X", "23", "X(023)"), @"07VENDAS REMOTAS       ");
                /*"       10 FILLER               PIC  X(023)     VALUE          '08INTRANET'.*/
                public StringBasis FILLER_64 { get; set; } = new StringBasis(new PIC("X", "23", "X(023)"), @"08INTRANET");
                /*"       10 FILLER               PIC  X(023)     VALUE          '09INTERNET             '.*/
                public StringBasis FILLER_65 { get; set; } = new StringBasis(new PIC("X", "23", "X(023)"), @"09INTERNET             ");
                /*"       10 FILLER               PIC  X(023)     VALUE          '97REMOTA FILIAL        '.*/
                public StringBasis FILLER_66 { get; set; } = new StringBasis(new PIC("X", "23", "X(023)"), @"97REMOTA FILIAL        ");
                /*"    05 W-TAB-ORIGEM-RD      REDEFINES W-TAB-ORIGEM                           OCCURS 10.*/
            }
            private ListBasis<_REDEF_PF0103B_W_TAB_ORIGEM_RD> _w_tab_origem_rd { get; set; }
            public ListBasis<_REDEF_PF0103B_W_TAB_ORIGEM_RD> W_TAB_ORIGEM_RD
            {
                get { _w_tab_origem_rd = new ListBasis<_REDEF_PF0103B_W_TAB_ORIGEM_RD>(10); _.Move(W_TAB_ORIGEM, _w_tab_origem_rd); VarBasis.RedefinePassValue(W_TAB_ORIGEM, _w_tab_origem_rd, W_TAB_ORIGEM); _w_tab_origem_rd.ValueChanged += () => { _.Move(_w_tab_origem_rd, W_TAB_ORIGEM); }; return _w_tab_origem_rd; }
                set { VarBasis.RedefinePassValue(value, _w_tab_origem_rd, W_TAB_ORIGEM); }
            }  //Redefines
            public class _REDEF_PF0103B_W_TAB_ORIGEM_RD : VarBasis
            {
                /*"       10 W-TB-COD-ORIGEM     PIC  9(002).*/
                public IntBasis W_TB_COD_ORIGEM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       10 W-TB-DESCRI-ORIGEM  PIC  X(021).*/
                public StringBasis W_TB_DESCRI_ORIGEM { get; set; } = new StringBasis(new PIC("X", "21", "X(021)."), @"");
                /*"01  WREA88.*/

                public _REDEF_PF0103B_W_TAB_ORIGEM_RD()
                {
                    W_TB_COD_ORIGEM.ValueChanged += OnValueChanged;
                    W_TB_DESCRI_ORIGEM.ValueChanged += OnValueChanged;
                }

            }
        }
        public PF0103B_WREA88 WREA88 { get; set; } = new PF0103B_WREA88();
        public class PF0103B_WREA88 : VarBasis
        {
            /*"    05 W88-530-ENDERECO               PIC  9(001) VALUE ZERO.*/

            public SelectorBasis W88_530_ENDERECO { get; set; } = new SelectorBasis("001", "ZERO")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 ENDERECO-COM-530                       VALUE 1. */
							new SelectorItemBasis("ENDERECO_COM_530", "1"),
							/*" 88 ENDERECO-SEM-530                       VALUE 2. */
							new SelectorItemBasis("ENDERECO_SEM_530", "2")
                }
            };

            /*"    05 W88-RCAPS                      PIC  9(001) VALUE ZERO.*/

            public SelectorBasis W88_RCAPS { get; set; } = new SelectorBasis("001", "ZERO")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 RCAP-NAO-CADASTRADO                    VALUE 1. */
							new SelectorItemBasis("RCAP_NAO_CADASTRADO", "1"),
							/*" 88 RCAP-CADASTRADO                        VALUE 2. */
							new SelectorItemBasis("RCAP_CADASTRADO", "2")
                }
            };

            /*"    05 W88-CONVERSAO                  PIC  9(001) VALUE ZERO.*/

            public SelectorBasis W88_CONVERSAO { get; set; } = new SelectorBasis("001", "ZERO")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 CONVERSAO-N-CADASTRADA                 VALUE 1. */
							new SelectorItemBasis("CONVERSAO_N_CADASTRADA", "1"),
							/*" 88 CONVERSAO-CADASTRADA                   VALUE 2. */
							new SelectorItemBasis("CONVERSAO_CADASTRADA", "2")
                }
            };

            /*"    05 W88-PROPOSTA                   PIC  9(001) VALUE ZERO.*/

            public SelectorBasis W88_PROPOSTA { get; set; } = new SelectorBasis("001", "ZERO")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 PROPOSTA-NAO-CADASTRADA                VALUE 1. */
							new SelectorItemBasis("PROPOSTA_NAO_CADASTRADA", "1"),
							/*" 88 PROPOSTA-CADASTRADA                    VALUE 2. */
							new SelectorItemBasis("PROPOSTA_CADASTRADA", "2")
                }
            };

            /*"    05 W88-CRITICA-PROPOSTA           PIC  9(001) VALUE ZERO.*/

            public SelectorBasis W88_CRITICA_PROPOSTA { get; set; } = new SelectorBasis("001", "ZERO")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 PROPOSTA-SEM-CRITICA                   VALUE 1. */
							new SelectorItemBasis("PROPOSTA_SEM_CRITICA", "1"),
							/*" 88 PROPOSTA-COM-CRITICA                   VALUE 2. */
							new SelectorItemBasis("PROPOSTA_COM_CRITICA", "2")
                }
            };

            /*"    05  W88-ORIGEM-PROPOSTA           PIC 9(002).*/

            public SelectorBasis W88_ORIGEM_PROPOSTA { get; set; } = new SelectorBasis("002")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 ORIGEM-SIGPF                            VALUE 01. */
							new SelectorItemBasis("ORIGEM_SIGPF", "01"),
							/*" 88 ORIGEM-CAIXA-PREV                       VALUE 02. */
							new SelectorItemBasis("ORIGEM_CAIXA_PREV", "02"),
							/*" 88 ORIGEM-SIGAT                            VALUE 03. */
							new SelectorItemBasis("ORIGEM_SIGAT", "03"),
							/*" 88 ORIGEM-CAIXA-SEGUROS                    VALUE 04. */
							new SelectorItemBasis("ORIGEM_CAIXA_SEGUROS", "04"),
							/*" 88 ORIGEM-CAIXA-CAP                        VALUE 05. */
							new SelectorItemBasis("ORIGEM_CAIXA_CAP", "05"),
							/*" 88 ORIGEM-MANUAL                           VALUE 06. */
							new SelectorItemBasis("ORIGEM_MANUAL", "06"),
							/*" 88 ORIGEM-REMOTA                           VALUE 07. */
							new SelectorItemBasis("ORIGEM_REMOTA", "07"),
							/*" 88 ORIGEM-INTRANET                         VALUE 08. */
							new SelectorItemBasis("ORIGEM_INTRANET", "08"),
							/*" 88 ORIGEM-INTERNET                         VALUE 09. */
							new SelectorItemBasis("ORIGEM_INTERNET", "09")
                }
            };

            /*"    05  W-NUM-PROPOSTA                PIC 9(014).*/
            public IntBasis W_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
            /*"    05  CANAL  REDEFINES W-NUM-PROPOSTA.*/
            private _REDEF_PF0103B_CANAL _canal { get; set; }
            public _REDEF_PF0103B_CANAL CANAL
            {
                get { _canal = new _REDEF_PF0103B_CANAL(); _.Move(W_NUM_PROPOSTA, _canal); VarBasis.RedefinePassValue(W_NUM_PROPOSTA, _canal, W_NUM_PROPOSTA); _canal.ValueChanged += () => { _.Move(_canal, W_NUM_PROPOSTA); }; return _canal; }
                set { VarBasis.RedefinePassValue(value, _canal, W_NUM_PROPOSTA); }
            }  //Redefines
            public class _REDEF_PF0103B_CANAL : VarBasis
            {
                /*"        07  W88-CANAL-PROPOSTA          PIC 9(001).*/

                public SelectorBasis W88_CANAL_PROPOSTA { get; set; } = new SelectorBasis("001")
                {
                    Items = new List<SelectorItemBasis> {
                            /*" 88 CANAL-VENDA-PAPEL                   VALUE 0. */
							new SelectorItemBasis("CANAL_VENDA_PAPEL", "0"),
							/*" 88 CANAL-VENDA-CEF                     VALUE 1. */
							new SelectorItemBasis("CANAL_VENDA_CEF", "1"),
							/*" 88 CANAL-VENDA-SASSE                   VALUE 2. */
							new SelectorItemBasis("CANAL_VENDA_SASSE", "2"),
							/*" 88 CANAL-VENDA-CORRETOR                VALUE 3. */
							new SelectorItemBasis("CANAL_VENDA_CORRETOR", "3"),
							/*" 88 CANAL-VENDA-CORREIO                 VALUE 4. */
							new SelectorItemBasis("CANAL_VENDA_CORREIO", "4"),
							/*" 88 CANAL-VENDA-GITEL                   VALUE 5. */
							new SelectorItemBasis("CANAL_VENDA_GITEL", "5"),
							/*" 88 CANAL-VENDA-MANUAL                  VALUE 6. */
							new SelectorItemBasis("CANAL_VENDA_MANUAL", "6"),
							/*" 88 CANAL-VENDA-INTERNET                VALUE 7. */
							new SelectorItemBasis("CANAL_VENDA_INTERNET", "7"),
							/*" 88 CANAL-VENDA-INTRANET                VALUE 8. */
							new SelectorItemBasis("CANAL_VENDA_INTRANET", "8")
                }
                };

                /*"        07  FILLER                    PIC 9(013).*/
                public IntBasis FILLER_67 { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
                /*"    05 W88-RELACIONAMENTO               PIC  9(001) VALUE ZERO.*/

                public _REDEF_PF0103B_CANAL()
                {
                    W88_CANAL_PROPOSTA.ValueChanged += OnValueChanged;
                    FILLER_67.ValueChanged += OnValueChanged;
                }

            }

            public SelectorBasis W88_RELACIONAMENTO { get; set; } = new SelectorBasis("001", "ZERO")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 SEGURO-VIDA                            VALUE 1. */
							new SelectorItemBasis("SEGURO_VIDA", "1"),
							/*" 88 CAPITALIZACAO                          VALUE 2. */
							new SelectorItemBasis("CAPITALIZACAO", "2"),
							/*" 88 PREVIDENCIA                            VALUE 3. */
							new SelectorItemBasis("PREVIDENCIA", "3"),
							/*" 88 BILHETE                                VALUE 4. */
							new SelectorItemBasis("BILHETE", "4"),
							/*" 88 AUTOMOVEIS                             VALUE 5. */
							new SelectorItemBasis("AUTOMOVEIS", "5"),
							/*" 88 MULTIRISCO                             VALUE 6. */
							new SelectorItemBasis("MULTIRISCO", "6")
                }
            };

            /*"    05 W-TP-REGISTRO                  PIC  X(001) VALUE SPACES.*/

            public SelectorBasis W_TP_REGISTRO { get; set; } = new SelectorBasis("001", "SPACES")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 TPREG-HEADER                            VALUE 'H'. */
							new SelectorItemBasis("TPREG_HEADER", "H"),
							/*" 88 TPREG-TRAILLER                          VALUE 'T'. */
							new SelectorItemBasis("TPREG_TRAILLER", "T"),
							/*" 88 TPREG-PGTO-AVULSO                       VALUE '0'. */
							new SelectorItemBasis("TPREG_PGTO_AVULSO", "0"),
							/*" 88 TPREG-CLIENTE                           VALUE '1'. */
							new SelectorItemBasis("TPREG_CLIENTE", "1"),
							/*" 88 TPREG-ENDERECO                          VALUE '2'. */
							new SelectorItemBasis("TPREG_ENDERECO", "2"),
							/*" 88 TPREG-PROPOSTA                          VALUE '3'. */
							new SelectorItemBasis("TPREG_PROPOSTA", "3"),
							/*" 88 TPREG-BENEFICIARIO                      VALUE '4'. */
							new SelectorItemBasis("TPREG_BENEFICIARIO", "4"),
							/*" 88 TPREG-DADOS-AUTO                        VALUE '4'. */
							new SelectorItemBasis("TPREG_DADOS_AUTO", "4"),
							/*" 88 TPREG-INFO-COMPLEMENTAR                 VALUE '5'. */
							new SelectorItemBasis("TPREG_INFO_COMPLEMENTAR", "5"),
							/*" 88 TPREG-REGISTRO-AUTO                     VALUE '6'. */
							new SelectorItemBasis("TPREG_REGISTRO_AUTO", "6")
                }
            };

        }


        public Copies.LXFPF990 LXFPF990 { get; set; } = new Copies.LXFPF990();
        public Copies.LBFPF000 LBFPF000 { get; set; } = new Copies.LBFPF000();
        public Copies.LBFPF011 LBFPF011 { get; set; } = new Copies.LBFPF011();
        public Copies.LBFPF012 LBFPF012 { get; set; } = new Copies.LBFPF012();
        public Copies.LBFPF014 LBFPF014 { get; set; } = new Copies.LBFPF014();
        public Copies.LBFPF015 LBFPF015 { get; set; } = new Copies.LBFPF015();
        public Copies.LBFPF016 LBFPF016 { get; set; } = new Copies.LBFPF016();
        public Copies.LBFPF991 LBFPF991 { get; set; } = new Copies.LBFPF991();
        public Copies.LXFPF003 LXFPF003 { get; set; } = new Copies.LXFPF003();
        public Copies.LXFPF004 LXFPF004 { get; set; } = new Copies.LXFPF004();
        public Copies.LXFCT004 LXFCT004 { get; set; } = new Copies.LXFCT004();
        public Copies.LBWPF002 LBWPF002 { get; set; } = new Copies.LBWPF002();
        public Dclgens.AGENCEF AGENCEF { get; set; } = new Dclgens.AGENCEF();
        public Dclgens.FDCOMVA FDCOMVA { get; set; } = new Dclgens.FDCOMVA();
        public Dclgens.TARIBCEF TARIBCEF { get; set; } = new Dclgens.TARIBCEF();
        public Dclgens.FONTES FONTES { get; set; } = new Dclgens.FONTES();
        public Dclgens.CEDENTE CEDENTE { get; set; } = new Dclgens.CEDENTE();
        public Dclgens.COVSICOB COVSICOB { get; set; } = new Dclgens.COVSICOB();
        public Dclgens.ESCNEG ESCNEG { get; set; } = new Dclgens.ESCNEG();
        public Dclgens.MALHACEF MALHACEF { get; set; } = new Dclgens.MALHACEF();
        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.PROPOFID PROPOFID { get; set; } = new Dclgens.PROPOFID();
        public Dclgens.PROPFIDH PROPFIDH { get; set; } = new Dclgens.PROPFIDH();
        public Dclgens.COVSIVPF COVSIVPF { get; set; } = new Dclgens.COVSIVPF();
        public Dclgens.ARQSIVPF ARQSIVPF { get; set; } = new Dclgens.ARQSIVPF();
        public Dclgens.PROFIDCO PROFIDCO { get; set; } = new Dclgens.PROFIDCO();
        public Dclgens.PESFONE PESFONE { get; set; } = new Dclgens.PESFONE();
        public Dclgens.PESEMAIL PESEMAIL { get; set; } = new Dclgens.PESEMAIL();
        public Dclgens.IDERELAC IDERELAC { get; set; } = new Dclgens.IDERELAC();
        public Dclgens.RTPRELAC RTPRELAC { get; set; } = new Dclgens.RTPRELAC();
        public Dclgens.TPRELAC TPRELAC { get; set; } = new Dclgens.TPRELAC();
        public Dclgens.PESENDER PESENDER { get; set; } = new Dclgens.PESENDER();
        public Dclgens.TPENDER TPENDER { get; set; } = new Dclgens.TPENDER();
        public Dclgens.PESSOA PESSOA { get; set; } = new Dclgens.PESSOA();
        public Dclgens.PESJUR PESJUR { get; set; } = new Dclgens.PESJUR();
        public Dclgens.PRDSIVPF PRDSIVPF { get; set; } = new Dclgens.PRDSIVPF();
        public Dclgens.PESFIS PESFIS { get; set; } = new Dclgens.PESFIS();
        public Dclgens.CBO CBO { get; set; } = new Dclgens.CBO();
        public PF0103B_EMAIL EMAIL { get; set; } = new PF0103B_EMAIL();
        public PF0103B_ENDERECOS ENDERECOS { get; set; } = new PF0103B_ENDERECOS();
        public PF0103B_FUNDOCOMISVA FUNDOCOMISVA { get; set; } = new PF0103B_FUNDOCOMISVA();
        public PF0103B_CFONTES CFONTES { get; set; } = new PF0103B_CFONTES();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string MOV_SULA_FILE_NAME_P, string MOV_AUTO_FILE_NAME_P, string RPF0103B_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                MOV_SULA.SetFile(MOV_SULA_FILE_NAME_P);
                MOV_AUTO.SetFile(MOV_AUTO_FILE_NAME_P);
                RPF0103B.SetFile(RPF0103B_FILE_NAME_P);

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
            /*" -873- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -874- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -875- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -878- DISPLAY '************************************************' . */
            _.Display($"************************************************");

            /*" -879- DISPLAY '*               PROGRAMA PF0103B               *' . */
            _.Display($"*               PROGRAMA PF0103B               *");

            /*" -880- DISPLAY '*  LER MOV GERADO PELO PF0102B, GERA BASE PF.  *' . */
            _.Display($"*  LER MOV GERADO PELO PF0102B, GERA BASE PF.  *");

            /*" -881- DISPLAY '*           VERSAO:  12 - 27/02/2018           *' . */
            _.Display($"*           VERSAO:  12 - 27/02/2018           *");

            /*" -882- DISPLAY '************************************************' . */
            _.Display($"************************************************");

            /*" -891- DISPLAY '*  PF0103B - INICIO  EM ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2). */

            $"*  PF0103B - INICIO  EM {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
            .Display();

            /*" -893- PERFORM R0000-00-INICIALIZAR. */

            R0000_00_INICIALIZAR_SECTION();

            /*" -895- PERFORM R0050-00-LER-MOV-SULA. */

            R0050_00_LER_MOV_SULA_SECTION();

            /*" -896- IF W-FIM-MOVTO-SULA EQUAL 'FIM' */

            if (WAREA_AUXILIAR.W_FIM_MOVTO_SULA == "FIM")
            {

                /*" -897- DISPLAY ' ' */
                _.Display($" ");

                /*" -898- DISPLAY '************************************************' */
                _.Display($"************************************************");

                /*" -899- DISPLAY '*  PF0103B - ARQUIVO VAZIO - VERIFIQUE         *' */
                _.Display($"*  PF0103B - ARQUIVO VAZIO - VERIFIQUE         *");

                /*" -900- DISPLAY '************************************************' */
                _.Display($"************************************************");

                /*" -902- DISPLAY ' ' . */
                _.Display($" ");
            }


            /*" -904- PERFORM R0117-00-OBTER-NSAS-MOVTO. */

            R0117_00_OBTER_NSAS_MOVTO_SECTION();

            /*" -906- PERFORM R0460-00-GERAR-HEADER */

            R0460_00_GERAR_HEADER_SECTION();

            /*" -909- PERFORM R0250-00-TRATA-EMPRESA UNTIL W-FIM-MOVTO-SULA EQUAL 'FIM' . */

            while (!(WAREA_AUXILIAR.W_FIM_MOVTO_SULA == "FIM"))
            {

                R0250_00_TRATA_EMPRESA_SECTION();
            }

            /*" -911- PERFORM R2050-00-GERAR-TRAILLER-AUTO. */

            R2050_00_GERAR_TRAILLER_AUTO_SECTION();

            /*" -913- PERFORM R2100-00-TB-CONTROLE. */

            R2100_00_TB_CONTROLE_SECTION();

            /*" -915- PERFORM R2000-00-QUEBRA-EMPRESSA. */

            R2000_00_QUEBRA_EMPRESSA_SECTION();

            /*" -917- PERFORM R9988-00-FECHAR-ARQUIVOS. */

            R9988_00_FECHAR_ARQUIVOS_SECTION();

            /*" -918- IF W-INDICE-1 GREATER ZEROS */

            if (WAREA_AUXILIAR.W_INDICE_1 > 00)
            {

                /*" -920- PERFORM R9980-00-GERAR-RELATORIO. */

                R9980_00_GERAR_RELATORIO_SECTION();
            }


            /*" -920- PERFORM R9999-00-FINALIZAR. */

            R9999_00_FINALIZAR_SECTION();

        }

        [StopWatch]
        /*" R0000-00-INICIALIZAR-SECTION */
        private void R0000_00_INICIALIZAR_SECTION()
        {
            /*" -928- MOVE 'R0000-00-INICIALIZAR' TO PARAGRAFO. */
            _.Move("R0000-00-INICIALIZAR", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -930- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -932- PERFORM R0005-00-OBTER-DATA-DIA. */

            R0005_00_OBTER_DATA_DIA_SECTION();

            /*" -934- PERFORM R0010-00-ABRIR-ARQUIVOS. */

            R0010_00_ABRIR_ARQUIVOS_SECTION();

            /*" -937- INITIALIZE TAB-FILIAL, TAB-CBO. */
            _.Initialize(
                WAREA_AUXILIAR.TAB_FILIAL
                , WAREA_AUXILIAR.TAB_CBO
            );

            /*" -939- SET I07 TO 1. */
            I07.Value = 1;

            /*" -941- PERFORM R6200-00-DECLARE-FONTES. */

            R6200_00_DECLARE_FONTES_SECTION();

            /*" -943- PERFORM R6210-00-FETCH-FONTES. */

            R6210_00_FETCH_FONTES_SECTION();

            /*" -944- IF W-FIM-FONTES NOT EQUAL SPACES */

            if (!WAREA_AUXILIAR.W_FIM_FONTES.IsEmpty())
            {

                /*" -945- DISPLAY 'R0000 - PROBLEMA NO FETCH DA V0FONTES ' SQLCODE */
                _.Display($"R0000 - PROBLEMA NO FETCH DA V0FONTES {DB.SQLCODE}");

                /*" -947- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


            /*" -948- PERFORM R6220-00-CARREGA-FONTES UNTIL W-FIM-FONTES EQUAL 'S' . */

            while (!(WAREA_AUXILIAR.W_FIM_FONTES == "S"))
            {

                R6220_00_CARREGA_FONTES_SECTION();
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_SAIDA*/

        [StopWatch]
        /*" R0005-00-OBTER-DATA-DIA-SECTION */
        private void R0005_00_OBTER_DATA_DIA_SECTION()
        {
            /*" -958- MOVE 'R0005-00-OBTER-DATA-DIA' TO PARAGRAFO. */
            _.Move("R0005-00-OBTER-DATA-DIA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -960- MOVE 'SELECT SEGUROS.SISTEMAS' TO COMANDO. */
            _.Move("SELECT SEGUROS.SISTEMAS", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -962- MOVE 'PF' TO SISTEMAS-IDE-SISTEMA OF DCLSISTEMAS. */
            _.Move("PF", SISTEMAS.DCLSISTEMAS.SISTEMAS_IDE_SISTEMA);

            /*" -968- PERFORM R0005_00_OBTER_DATA_DIA_DB_SELECT_1 */

            R0005_00_OBTER_DATA_DIA_DB_SELECT_1();

            /*" -973- MOVE SISTEMAS-DATA-MOV-ABERTO OF DCLSISTEMAS TO W-DTMOVABE. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, WAREA_AUXILIAR.W_DTMOVABE);

            /*" -975- MOVE W-DIA-MOVABE OF W-DTMOVABE1 TO W-DIA-MOVABE OF W-DTMOVABE-I1. */
            _.Move(WAREA_AUXILIAR.W_DTMOVABE1.W_DIA_MOVABE, WAREA_AUXILIAR.W_DTMOVABE_I1.W_DIA_MOVABE_0);

            /*" -977- MOVE W-MES-MOVABE OF W-DTMOVABE1 TO W-MES-MOVABE OF W-DTMOVABE-I1. */
            _.Move(WAREA_AUXILIAR.W_DTMOVABE1.W_MES_MOVABE, WAREA_AUXILIAR.W_DTMOVABE_I1.W_MES_MOVABE_0);

            /*" -980- MOVE W-ANO-MOVABE OF W-DTMOVABE1 TO W-ANO-MOVABE OF W-DTMOVABE-I1. */
            _.Move(WAREA_AUXILIAR.W_DTMOVABE1.W_ANO_MOVABE, WAREA_AUXILIAR.W_DTMOVABE_I1.W_ANO_MOVABE_0);

            /*" -982- MOVE '-' TO W-BARRA1 OF W-DTMOVABE-I1, W-BARRA2 OF W-DTMOVABE-I1. */
            _.Move("-", WAREA_AUXILIAR.W_DTMOVABE_I1.W_BARRA1_0);
            _.Move("-", WAREA_AUXILIAR.W_DTMOVABE_I1.W_BARRA2_0);


        }

        [StopWatch]
        /*" R0005-00-OBTER-DATA-DIA-DB-SELECT-1 */
        public void R0005_00_OBTER_DATA_DIA_DB_SELECT_1()
        {
            /*" -968- EXEC SQL SELECT DATA_MOV_ABERTO INTO :DCLSISTEMAS.SISTEMAS-DATA-MOV-ABERTO FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = :DCLSISTEMAS.SISTEMAS-IDE-SISTEMA WITH UR END-EXEC. */

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
            /*" -992- MOVE 'R0010-00-ABRIR-ARQUIVOS' TO PARAGRAFO. */
            _.Move("R0010-00-ABRIR-ARQUIVOS", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -994- MOVE 'OPEN' TO COMANDO. */
            _.Move("OPEN", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -995- OPEN OUTPUT MOV-AUTO. */
            MOV_AUTO.Open(REG_MOV_AUTO, WAREA_AUXILIAR.WS_STATUS);

            /*" -996- IF WS-STATUS NOT EQUAL '00' */

            if (WAREA_AUXILIAR.WS_STATUS != "00")
            {

                /*" -997- DISPLAY 'PF0103B - FIM ANORMAL' */
                _.Display($"PF0103B - FIM ANORMAL");

                /*" -998- DISPLAY '          ERRO OPEN ARQUIVO MOV-AUTO ' */
                _.Display($"          ERRO OPEN ARQUIVO MOV-AUTO ");

                /*" -1000- DISPLAY '          FILE STATUS............... ' WS-STATUS */
                _.Display($"          FILE STATUS............... {WAREA_AUXILIAR.WS_STATUS}");

                /*" -1001- CLOSE MOV-SULA */
                MOV_SULA.Close();

                /*" -1003- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


            /*" -1004- OPEN INPUT MOV-SULA. */
            MOV_SULA.Open(REG_SULAMERICA, WAREA_AUXILIAR.WS_STATUS);

            /*" -1005- IF WS-STATUS NOT EQUAL '00' */

            if (WAREA_AUXILIAR.WS_STATUS != "00")
            {

                /*" -1006- IF WS-STATUS EQUAL '35' */

                if (WAREA_AUXILIAR.WS_STATUS == "35")
                {

                    /*" -1007- PERFORM R0117-00-OBTER-NSAS-MOVTO */

                    R0117_00_OBTER_NSAS_MOVTO_SECTION();

                    /*" -1008- PERFORM R0460-00-GERAR-HEADER */

                    R0460_00_GERAR_HEADER_SECTION();

                    /*" -1009- PERFORM R2050-00-GERAR-TRAILLER-AUTO */

                    R2050_00_GERAR_TRAILLER_AUTO_SECTION();

                    /*" -1010- PERFORM R2100-00-TB-CONTROLE */

                    R2100_00_TB_CONTROLE_SECTION();

                    /*" -1011- DISPLAY ' ' */
                    _.Display($" ");

                    /*" -1012- DISPLAY '*--------------------------------*' */
                    _.Display($"*--------------------------------*");

                    /*" -1013- DISPLAY '* PF0103B - ARQUIVO VAZIO        *' */
                    _.Display($"* PF0103B - ARQUIVO VAZIO        *");

                    /*" -1014- DISPLAY '*--------------------------------*' */
                    _.Display($"*--------------------------------*");

                    /*" -1016- MOVE 'FIM' TO W-FIM-MOVTO-SULA */
                    _.Move("FIM", WAREA_AUXILIAR.W_FIM_MOVTO_SULA);

                    /*" -1018- CLOSE MOV-AUTO */
                    MOV_AUTO.Close();

                    /*" -1019- PERFORM R9999-00-FINALIZAR */

                    R9999_00_FINALIZAR_SECTION();

                    /*" -1020- ELSE */
                }
                else
                {


                    /*" -1021- DISPLAY 'PF0103B - FIM ANORMAL' */
                    _.Display($"PF0103B - FIM ANORMAL");

                    /*" -1022- DISPLAY '          ERRO OPEN ARQUIVO MOV-SULA ' */
                    _.Display($"          ERRO OPEN ARQUIVO MOV-SULA ");

                    /*" -1024- DISPLAY '          FILE STATUS............... ' WS-STATUS */
                    _.Display($"          FILE STATUS............... {WAREA_AUXILIAR.WS_STATUS}");

                    /*" -1024- PERFORM R9999-00-FINALIZAR. */

                    R9999_00_FINALIZAR_SECTION();
                }

            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0010_SAIDA*/

        [StopWatch]
        /*" R0050-00-LER-MOV-SULA-SECTION */
        private void R0050_00_LER_MOV_SULA_SECTION()
        {
            /*" -1034- MOVE 'R0050-00-LER-MOV-SULA' TO PARAGRAFO. */
            _.Move("R0050-00-LER-MOV-SULA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1036- MOVE 'READ' TO COMANDO. */
            _.Move("READ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1038- READ MOV-SULA */
            MOV_SULA.Read();

            /*" -1039- IF WS-STATUS NOT EQUAL '00' */

            if (WAREA_AUXILIAR.WS_STATUS != "00")
            {

                /*" -1040- IF WS-STATUS NOT EQUAL '10' */

                if (WAREA_AUXILIAR.WS_STATUS != "10")
                {

                    /*" -1041- DISPLAY 'PF0103B - FIM ANORMAL' */
                    _.Display($"PF0103B - FIM ANORMAL");

                    /*" -1042- DISPLAY '          ERRO LEITURA MOV-SULA ' */
                    _.Display($"          ERRO LEITURA MOV-SULA ");

                    /*" -1044- DISPLAY '          FILE STATUS.......... ' WS-STATUS */
                    _.Display($"          FILE STATUS.......... {WAREA_AUXILIAR.WS_STATUS}");

                    /*" -1045- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -1046- PERFORM R9999-00-FINALIZAR */

                    R9999_00_FINALIZAR_SECTION();

                    /*" -1047- ELSE */
                }
                else
                {


                    /*" -1048- MOVE 'FIM' TO W-FIM-MOVTO-SULA */
                    _.Move("FIM", WAREA_AUXILIAR.W_FIM_MOVTO_SULA);

                    /*" -1049- ELSE */
                }

            }
            else
            {


                /*" -1052- ADD 1 TO W-LIDO-MOVTO-SULA, W-AC-CONTROLE */
                WAREA_AUXILIAR.W_LIDO_MOVTO_SULA.Value = WAREA_AUXILIAR.W_LIDO_MOVTO_SULA + 1;
                WAREA_AUXILIAR.W_AC_CONTROLE.Value = WAREA_AUXILIAR.W_AC_CONTROLE + 1;

                /*" -1053- IF W-AC-CONTROLE GREATER 0199 */

                if (WAREA_AUXILIAR.W_AC_CONTROLE > 0199)
                {

                    /*" -1054- ACCEPT WS-TIME FROM TIME */
                    _.Move(_.AcceptDate("TIME"), WS_TIME);

                    /*" -1055- MOVE WS-TIME-N TO WS-TIME-EDIT */
                    _.Move(WS_TIME.WS_TIME_N, WS_TIME_EDIT);

                    /*" -1056- DISPLAY ' ' */
                    _.Display($" ");

                    /*" -1058- DISPLAY 'PF0103B - TOTAL LIDO ' W-LIDO-MOVTO-SULA '  HORAS  ' WS-TIME-EDIT */

                    $"PF0103B - TOTAL LIDO {WAREA_AUXILIAR.W_LIDO_MOVTO_SULA}  HORAS  {WS_TIME_EDIT}"
                    .Display();

                    /*" -1059- MOVE ZEROS TO W-AC-CONTROLE */
                    _.Move(0, WAREA_AUXILIAR.W_AC_CONTROLE);

                    /*" -1061- END-IF */
                }


                /*" -1063- IF REG-TIPO-REGISTRO NOT EQUAL 1 AND 2 AND 3 AND 4 AND 5 AND 6 */

                if (!REG_SULAMERICA.REG_TIPO_REGISTRO.In("1", "2", "3", "4", "5", "6"))
                {

                    /*" -1065- GO TO R0050-00-LER-MOV-SULA. */
                    new Task(() => R0050_00_LER_MOV_SULA_SECTION()).RunSynchronously(); //GOTO
                    return;//Recursividade detectada, cuidado...
                }

            }


            /*" -1066- DISPLAY 'TIPO REGISTRO / NUMERO PROPOSTA.... ' REG-TIPO-REGISTRO ' ' REG-NUM-PROPOSTA. */

            $"TIPO REGISTRO / NUMERO PROPOSTA.... {REG_SULAMERICA.REG_TIPO_REGISTRO} {REG_SULAMERICA.REG_NUM_PROPOSTA}"
            .Display();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0050_SAIDA*/

        [StopWatch]
        /*" R0117-00-OBTER-NSAS-MOVTO-SECTION */
        private void R0117_00_OBTER_NSAS_MOVTO_SECTION()
        {
            /*" -1076- MOVE 'R0117-00-OBTER-NSAS-MOVTO' TO PARAGRAFO. */
            _.Move("R0117-00-OBTER-NSAS-MOVTO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1078- MOVE 'SELECT COUNT ARQUIVOS-SIVPF' TO COMANDO. */
            _.Move("SELECT COUNT ARQUIVOS-SIVPF", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1081- MOVE 'PRPCAVC' TO ARQSIVPF-SIGLA-ARQUIVO OF DCLARQUIVOS-SIVPF. */
            _.Move("PRPCAVC", ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SIGLA_ARQUIVO);

            /*" -1083- MOVE 8 TO ARQSIVPF-SISTEMA-ORIGEM OF DCLARQUIVOS-SIVPF. */
            _.Move(8, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SISTEMA_ORIGEM);

            /*" -1092- PERFORM R0117_00_OBTER_NSAS_MOVTO_DB_SELECT_1 */

            R0117_00_OBTER_NSAS_MOVTO_DB_SELECT_1();

            /*" -1095- IF SQLCODE EQUAL 00 */

            if (DB.SQLCODE == 00)
            {

                /*" -1098- MOVE ARQSIVPF-NSAS-SIVPF OF DCLARQUIVOS-SIVPF TO W-NSAS-FILIAL */
                _.Move(ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF, WAREA_AUXILIAR.W_NSAS_FILIAL);

                /*" -1099- COMPUTE W-NSAS-FILIAL = W-NSAS-FILIAL + 1 */
                WAREA_AUXILIAR.W_NSAS_FILIAL.Value = WAREA_AUXILIAR.W_NSAS_FILIAL + 1;

                /*" -1100- MOVE W-NSAS-FILIAL TO RH-NSAS OF REG-HEADER */
                _.Move(WAREA_AUXILIAR.W_NSAS_FILIAL, LXFPF990.REG_HEADER.RH_NSAS);

                /*" -1101- ELSE */
            }
            else
            {


                /*" -1102- DISPLAY 'PF0103B - FIM ANORMAL' */
                _.Display($"PF0103B - FIM ANORMAL");

                /*" -1104- DISPLAY '          ERRO ACESSO TABELA ARQUIVOS-SIVPF ' SQLCODE */
                _.Display($"          ERRO ACESSO TABELA ARQUIVOS-SIVPF {DB.SQLCODE}");

                /*" -1106- DISPLAY '          SIGLA DO ARQUIVO................. ' ARQSIVPF-NSAS-SIVPF OF DCLARQUIVOS-SIVPF */
                _.Display($"          SIGLA DO ARQUIVO................. {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF}");

                /*" -1107- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -1107- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R0117-00-OBTER-NSAS-MOVTO-DB-SELECT-1 */
        public void R0117_00_OBTER_NSAS_MOVTO_DB_SELECT_1()
        {
            /*" -1092- EXEC SQL SELECT VALUE(MAX(NSAS_SIVPF),0) INTO :DCLARQUIVOS-SIVPF.ARQSIVPF-NSAS-SIVPF FROM SEGUROS.ARQUIVOS_SIVPF WHERE SIGLA_ARQUIVO = :DCLARQUIVOS-SIVPF.ARQSIVPF-SIGLA-ARQUIVO AND SISTEMA_ORIGEM = :DCLARQUIVOS-SIVPF.ARQSIVPF-SISTEMA-ORIGEM WITH UR END-EXEC. */

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
        /*" R0250-00-TRATA-EMPRESA-SECTION */
        private void R0250_00_TRATA_EMPRESA_SECTION()
        {
            /*" -1117- MOVE 'R0250-00-TRATA-EMPRESA' TO PARAGRAFO. */
            _.Move("R0250-00-TRATA-EMPRESA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1119- MOVE '    ' TO COMANDO. */
            _.Move("    ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1121- PERFORM R0270-00-INICIALIZAR-AREAS. */

            R0270_00_INICIALIZAR_AREAS_SECTION();

            /*" -1126- PERFORM R0300-00-TRATA-MOVIMENTO UNTIL W-FIM-MOVTO-SULA EQUAL 'FIM' OR REG-NUM-PROPOSTA OF REG-SULAMERICA NOT EQUAL W-NUM-PROPOSTA-ANT. */

            while (!(WAREA_AUXILIAR.W_FIM_MOVTO_SULA == "FIM" || REG_SULAMERICA.REG_NUM_PROPOSTA != WAREA_AUXILIAR.W_NUM_PROPOSTA_ANT))
            {

                R0300_00_TRATA_MOVIMENTO_SECTION();
            }

            /*" -1127- IF PROPOSTA-SEM-CRITICA */

            if (WREA88.W88_CRITICA_PROPOSTA["PROPOSTA_SEM_CRITICA"])
            {

                /*" -1127- PERFORM R0480-00-GERAR-TAB-PF. */

                R0480_00_GERAR_TAB_PF_SECTION();
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0250_SAIDA*/

        [StopWatch]
        /*" R0270-00-INICIALIZAR-AREAS-SECTION */
        private void R0270_00_INICIALIZAR_AREAS_SECTION()
        {
            /*" -1141- MOVE REG-NUM-PROPOSTA OF REG-SULAMERICA TO W-NUM-PROPOSTA, W-NUM-PROPOSTA-ANT. */
            _.Move(REG_SULAMERICA.REG_NUM_PROPOSTA, WREA88.W_NUM_PROPOSTA, WAREA_AUXILIAR.W_NUM_PROPOSTA_ANT);

            /*" -1152- INITIALIZE W-TAB-BENEFICIARIOS , W-TAB-INFORMACOES , W-TAB-CLAUSULAS , W-TB-ENDERECOS-N , W-IND-BENEF , W-IND-BENEF-N , W-IND-INFO , W-IND-INFO1 , W-IND-INFO-N , W-IND-CLAU , W-IND-CLAU-N , W-IND-ENDER , W-IND-ENDER1 , W-IND-ENDER-N , W-CONTROLE-TP-0 , W-EXISTE-TP-5 , W-TB-ENDERECOS-A , W-IND-ENDER-A , REG-CLIENTES , REG-PROPOSTA-SASSE, REG-BENEFIC , REG-VAL-ACESSORIOS, REG-INFORMACOES , REG-PAG-AVULSO. */
            _.Initialize(
                WAREA_AUXILIAR.W_TAB_BENEFICIARIOS
                , WAREA_AUXILIAR.W_TAB_INFORMACOES
                , WAREA_AUXILIAR.W_TAB_CLAUSULAS
                , WAREA_AUXILIAR.W_TB_ENDERECOS_N
                , WAREA_AUXILIAR.W_IND_BENEF
                , WAREA_AUXILIAR.W_IND_BENEF_N
                , WAREA_AUXILIAR.W_IND_INFO
                , WAREA_AUXILIAR.W_IND_INFO1
                , WAREA_AUXILIAR.W_IND_INFO_N
                , WAREA_AUXILIAR.W_IND_CLAU
                , WAREA_AUXILIAR.W_IND_CLAU_N
                , WAREA_AUXILIAR.W_IND_ENDER
                , WAREA_AUXILIAR.W_IND_ENDER1
                , WAREA_AUXILIAR.W_IND_ENDER_N
                , WAREA_AUXILIAR.W_CONTROLE_TP_0
                , WAREA_AUXILIAR.W_EXISTE_TP_5
                , WAREA_AUXILIAR.W_TB_ENDERECOS_A
                , WAREA_AUXILIAR.W_IND_ENDER_A
                , LBFPF011.REG_CLIENTES
                , LXFCT004.REG_PROPOSTA_SASSE
                , LBFPF014.REG_BENEFIC
                , LBFPF016.REG_VAL_ACESSORIOS
                , LBFPF015.REG_INFORMACOES
                , LBFPF000.REG_PAG_AVULSO
            );

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0270_SAIDA*/

        [StopWatch]
        /*" R0300-00-TRATA-MOVIMENTO-SECTION */
        private void R0300_00_TRATA_MOVIMENTO_SECTION()
        {
            /*" -1163- IF REG-TIPO-REGISTRO EQUAL '3' */

            if (REG_SULAMERICA.REG_TIPO_REGISTRO == "3")
            {

                /*" -1165- MOVE REG-SULAMERICA TO REG-PROPOSTA-SASSE */
                _.Move(MOV_SULA?.Value, LXFCT004.REG_PROPOSTA_SASSE);

                /*" -1167- PERFORM R0302-00-VALIDAR-PROPOSTA */

                R0302_00_VALIDAR_PROPOSTA_SECTION();

                /*" -1168- IF PROPOSTA-COM-CRITICA */

                if (WREA88.W88_CRITICA_PROPOSTA["PROPOSTA_COM_CRITICA"])
                {

                    /*" -1170- GO TO R0300-SAIDA. */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_SAIDA*/ //GOTO
                    return;
                }

            }


            /*" -1171- MOVE 'R0300-00-TRATA-MOVIMENTO' TO PARAGRAFO. */
            _.Move("R0300-00-TRATA-MOVIMENTO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1173- MOVE '    ' TO COMANDO. */
            _.Move("    ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1175- MOVE REG-TIPO-REGISTRO OF REG-SULAMERICA TO W-TP-REGISTRO. */
            _.Move(REG_SULAMERICA.REG_TIPO_REGISTRO, WREA88.W_TP_REGISTRO);

            /*" -1176-  EVALUATE TRUE  */

            /*" -1177-  WHEN TPREG-PGTO-AVULSO  */

            /*" -1177- IF TPREG-PGTO-AVULSO */

            if (WREA88.W_TP_REGISTRO["TPREG_PGTO_AVULSO"])
            {

                /*" -1178- PERFORM R0310-00-MOVTO-AVULSO */

                R0310_00_MOVTO_AVULSO_SECTION();

                /*" -1179-  WHEN TPREG-CLIENTE  */

                /*" -1179- ELSE IF TPREG-CLIENTE */
            }
            else

            if (WREA88.W_TP_REGISTRO["TPREG_CLIENTE"])
            {

                /*" -1180- MOVE REG-SULAMERICA TO REG-CLIENTES */
                _.Move(MOV_SULA?.Value, LBFPF011.REG_CLIENTES);

                /*" -1181-  WHEN TPREG-ENDERECO  */

                /*" -1181- ELSE IF TPREG-ENDERECO */
            }
            else

            if (WREA88.W_TP_REGISTRO["TPREG_ENDERECO"])
            {

                /*" -1182- PERFORM R0315-00-MOVTO-ENDERECO */

                R0315_00_MOVTO_ENDERECO_SECTION();

                /*" -1183-  WHEN TPREG-PROPOSTA  */

                /*" -1183- ELSE IF TPREG-PROPOSTA */
            }
            else

            if (WREA88.W_TP_REGISTRO["TPREG_PROPOSTA"])
            {

                /*" -1184- PERFORM R0320-00-MOVTO-PROPOSTA */

                R0320_00_MOVTO_PROPOSTA_SECTION();

                /*" -1185-  WHEN TPREG-BENEFICIARIO  */

                /*" -1185- ELSE IF TPREG-BENEFICIARIO */
            }
            else

            if (WREA88.W_TP_REGISTRO["TPREG_BENEFICIARIO"])
            {

                /*" -1186- PERFORM R0325-00-MOVTO-BENEFICIARIO */

                R0325_00_MOVTO_BENEFICIARIO_SECTION();

                /*" -1187-  WHEN TPREG-INFO-COMPLEMENTAR  */

                /*" -1187- ELSE IF TPREG-INFO-COMPLEMENTAR */
            }
            else

            if (WREA88.W_TP_REGISTRO["TPREG_INFO_COMPLEMENTAR"])
            {

                /*" -1188- PERFORM R0330-00-MOVTO-INF-COMPLEME */

                R0330_00_MOVTO_INF_COMPLEME_SECTION();

                /*" -1189-  WHEN TPREG-REGISTRO-AUTO  */

                /*" -1189- ELSE IF TPREG-REGISTRO-AUTO */
            }
            else

            if (WREA88.W_TP_REGISTRO["TPREG_REGISTRO_AUTO"])
            {

                /*" -1190- PERFORM R0336-00-MOVTO-CLAUSULA-AUTO */

                R0336_00_MOVTO_CLAUSULA_AUTO_SECTION();

                /*" -1191-  WHEN TPREG-HEADER  */

                /*" -1191- ELSE IF TPREG-HEADER */
            }
            else

            if (WREA88.W_TP_REGISTRO["TPREG_HEADER"])
            {

                /*" -1192- MOVE REG-SULAMERICA TO REG-HEADER */
                _.Move(MOV_SULA?.Value, LXFPF990.REG_HEADER);

                /*" -1193-  WHEN TPREG-TRAILLER  */

                /*" -1193- ELSE IF TPREG-TRAILLER */
            }
            else

            if (WREA88.W_TP_REGISTRO["TPREG_TRAILLER"])
            {

                /*" -1194- MOVE REG-SULAMERICA TO REG-TRAILLER */
                _.Move(MOV_SULA?.Value, LBFPF991.REG_TRAILLER);

                /*" -1195-  WHEN OTHER  */

                /*" -1195- ELSE */
            }
            else
            {


                /*" -1196- DISPLAY 'PF0103B - FIM ANORMAL' */
                _.Display($"PF0103B - FIM ANORMAL");

                /*" -1197- DISPLAY '          TIPO REGISTRO NAO ESPERADO' */
                _.Display($"          TIPO REGISTRO NAO ESPERADO");

                /*" -1199- DISPLAY '          TIPO DE REGISTRO........  ' REG-TIPO-REGISTRO OF REG-SULAMERICA */
                _.Display($"          TIPO DE REGISTRO........  {REG_SULAMERICA.REG_TIPO_REGISTRO}");

                /*" -1201- DISPLAY '          NUMERO DA PROPOSTA......  ' REG-NUM-PROPOSTA OF REG-SULAMERICA */
                _.Display($"          NUMERO DA PROPOSTA......  {REG_SULAMERICA.REG_NUM_PROPOSTA}");

                /*" -1202- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -1203- PERFORM R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION();

                /*" -1203-  END-EVALUATE.  */

                /*" -1203- END-IF. */
            }


            /*" -0- FLUXCONTROL_PERFORM R0300_10 */

            R0300_10();

        }

        [StopWatch]
        /*" R0300-10 */
        private void R0300_10(bool isPerform = false)
        {
            /*" -1207- PERFORM R0050-00-LER-MOV-SULA. */

            R0050_00_LER_MOV_SULA_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_SAIDA*/

        [StopWatch]
        /*" R0302-00-VALIDAR-PROPOSTA-SECTION */
        private void R0302_00_VALIDAR_PROPOSTA_SECTION()
        {
            /*" -1217- MOVE 'R0302-00-VALIDAR-PROPOSTA' TO PARAGRAFO. */
            _.Move("R0302-00-VALIDAR-PROPOSTA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1219- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1223- MOVE 1 TO W88-CRITICA-PROPOSTA W88-CONVERSAO W88-PROPOSTA */
            _.Move(1, WREA88.W88_CRITICA_PROPOSTA, WREA88.W88_CONVERSAO, WREA88.W88_PROPOSTA);

            /*" -1226- MOVE R3-NUM-PROPOSTA OF REG-PROPOSTA-SASSE TO NUM-PROPOSTA-SIVPF OF DCLCONVERSAO-SICOB */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_NUM_PROPOSTA, COVSICOB.DCLCONVERSAO_SICOB.NUM_PROPOSTA_SIVPF);

            /*" -1228- PERFORM R0792-ACESSAR-CONVERSAO-SICOB. */

            R0792_ACESSAR_CONVERSAO_SICOB_SECTION();

            /*" -1231- MOVE REG-NUM-PROPOSTA OF REG-SULAMERICA TO PROPOFID-NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ. */
            _.Move(REG_SULAMERICA.REG_NUM_PROPOSTA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF);

            /*" -1233- PERFORM R9978-00-VERIFICAR-PROPOSTA */

            R9978_00_VERIFICAR_PROPOSTA_SECTION();

            /*" -1234- IF PROPOSTA-CADASTRADA */

            if (WREA88.W88_PROPOSTA["PROPOSTA_CADASTRADA"])
            {

                /*" -1235- MOVE 2 TO W88-CRITICA-PROPOSTA */
                _.Move(2, WREA88.W88_CRITICA_PROPOSTA);

                /*" -1237- ADD 1 TO W-INDICE-1 */
                WAREA_AUXILIAR.W_INDICE_1.Value = WAREA_AUXILIAR.W_INDICE_1 + 1;

                /*" -1239- MOVE 2 TO W-TB-COD-DESCRI (W-INDICE-1) */
                _.Move(2, AREA_DAS_TABELAS.W_TAB_CONSISTENCIA.FILLER_47[WAREA_AUXILIAR.W_INDICE_1].W_TB_COD_DESCRI);

                /*" -1241- PERFORM R9979-00-MONTA-TAB-CRITICA. */

                R9979_00_MONTA_TAB_CRITICA_SECTION();
            }


            /*" -1242- IF PROPOSTA-COM-CRITICA */

            if (WREA88.W88_CRITICA_PROPOSTA["PROPOSTA_COM_CRITICA"])
            {

                /*" -1243- ADD 1 TO W-QTD-CRITICA */
                WAREA_AUXILIAR.W_QTD_CRITICA.Value = WAREA_AUXILIAR.W_QTD_CRITICA + 1;

                /*" -1247- PERFORM R0050-00-LER-MOV-SULA UNTIL W-FIM-MOVTO-SULA EQUAL 'FIM' OR REG-NUM-PROPOSTA OF REG-SULAMERICA NOT EQUAL W-NUM-PROPOSTA-ANT. */

                while (!(WAREA_AUXILIAR.W_FIM_MOVTO_SULA == "FIM" || REG_SULAMERICA.REG_NUM_PROPOSTA != WAREA_AUXILIAR.W_NUM_PROPOSTA_ANT))
                {

                    R0050_00_LER_MOV_SULA_SECTION();
                }
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0302_SAIDA*/

        [StopWatch]
        /*" R0310-00-MOVTO-AVULSO-SECTION */
        private void R0310_00_MOVTO_AVULSO_SECTION()
        {
            /*" -1256- MOVE 'R0310-00-MOVTO-AVULSO' TO PARAGRAFO. */
            _.Move("R0310-00-MOVTO-AVULSO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1258- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1259- MOVE 1 TO W-CONTROLE-TP-0 */
            _.Move(1, WAREA_AUXILIAR.W_CONTROLE_TP_0);

            /*" -1261- MOVE REG-SULAMERICA TO REG-PAG-AVULSO */
            _.Move(MOV_SULA?.Value, LBFPF000.REG_PAG_AVULSO);

            /*" -1261- ADD 1 TO W-QTD-LD-SIVPF-0. */
            WAREA_AUXILIAR.W_QTD_LD_SIVPF_0.Value = WAREA_AUXILIAR.W_QTD_LD_SIVPF_0 + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0310_SAIDA*/

        [StopWatch]
        /*" R0315-00-MOVTO-ENDERECO-SECTION */
        private void R0315_00_MOVTO_ENDERECO_SECTION()
        {
            /*" -1271- MOVE 'R0315-00-MOVTO-ENDERECO' TO PARAGRAFO. */
            _.Move("R0315-00-MOVTO-ENDERECO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1273- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1275- ADD 1 TO W-IND-ENDER-N. */
            WAREA_AUXILIAR.W_IND_ENDER_N.Value = WAREA_AUXILIAR.W_IND_ENDER_N + 1;

            /*" -1276- IF W-IND-ENDER-N GREATER 30 */

            if (WAREA_AUXILIAR.W_IND_ENDER_N > 30)
            {

                /*" -1277- DISPLAY 'PF0103B - FIM ANORMAL' */
                _.Display($"PF0103B - FIM ANORMAL");

                /*" -1278- DISPLAY '          ESTOURO DA TABELA DE ENDERECOS' */
                _.Display($"          ESTOURO DA TABELA DE ENDERECOS");

                /*" -1280- DISPLAY '          NUMERO DA PROPOSTA..........  ' R2-NUM-PROPOSTA OF REG-ENDERECO */
                _.Display($"          NUMERO DA PROPOSTA..........  {LBFPF012.REG_ENDERECO.R2_NUM_PROPOSTA}");

                /*" -1282- DISPLAY '          W-IND-ENDER.................  ' W-IND-ENDER */
                _.Display($"          W-IND-ENDER.................  {WAREA_AUXILIAR.W_IND_ENDER}");

                /*" -1283- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -1285- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


            /*" -1286- MOVE REG-SULAMERICA TO W-TB-REG-ENDERECOS-N(W-IND-ENDER-N). */
            _.Move(MOV_SULA?.Value, WAREA_AUXILIAR.W_TB_ENDERECOS_N.W_TAB_END_REG_N[WAREA_AUXILIAR.W_IND_ENDER_N].W_TB_REG_ENDERECOS_N);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0315_SAIDA*/

        [StopWatch]
        /*" R0320-00-MOVTO-PROPOSTA-SECTION */
        private void R0320_00_MOVTO_PROPOSTA_SECTION()
        {
            /*" -1296- MOVE 'R0320-00-MOVTO-PROPOSTA' TO PARAGRAFO. */
            _.Move("R0320-00-MOVTO-PROPOSTA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1298- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1300- MOVE REG-SULAMERICA TO REG-PROPOSTA-SASSE */
            _.Move(MOV_SULA?.Value, LXFCT004.REG_PROPOSTA_SASSE);

            /*" -1301- MOVE R3-COD-PRODUTO OF REG-PROPOSTA-SASSE TO W-PRODUTO. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_COD_PRODUTO, LBWPF002.W_PRODUTO);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0320_SAIDA*/

        [StopWatch]
        /*" R0325-00-MOVTO-BENEFICIARIO-SECTION */
        private void R0325_00_MOVTO_BENEFICIARIO_SECTION()
        {
            /*" -1311- MOVE 'R0325-00-MOVTO-BENEFICIARIOS' TO PARAGRAFO. */
            _.Move("R0325-00-MOVTO-BENEFICIARIOS", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1313- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1315- ADD 1 TO W-QTD-LD-SIVPF-4 */
            WAREA_AUXILIAR.W_QTD_LD_SIVPF_4.Value = WAREA_AUXILIAR.W_QTD_LD_SIVPF_4 + 1;

            /*" -1317- ADD 1 TO W-IND-BENEF-N. */
            WAREA_AUXILIAR.W_IND_BENEF_N.Value = WAREA_AUXILIAR.W_IND_BENEF_N + 1;

            /*" -1318- IF W-IND-BENEF-N GREATER 30 */

            if (WAREA_AUXILIAR.W_IND_BENEF_N > 30)
            {

                /*" -1319- DISPLAY 'PF0103B - FIM ANORMAL' */
                _.Display($"PF0103B - FIM ANORMAL");

                /*" -1320- DISPLAY '          ESTOURO DA TABELA DE BENEFICIARIOS' */
                _.Display($"          ESTOURO DA TABELA DE BENEFICIARIOS");

                /*" -1322- DISPLAY '          NUMERO DA PROPOSTA..............  ' R4-NUM-PROPOSTA OF REG-BENEFIC */
                _.Display($"          NUMERO DA PROPOSTA..............  {LBFPF014.REG_BENEFIC.R4_NUM_PROPOSTA}");

                /*" -1324- DISPLAY '          W-IND-BENEF-N...................  ' W-IND-BENEF-N */
                _.Display($"          W-IND-BENEF-N...................  {WAREA_AUXILIAR.W_IND_BENEF_N}");

                /*" -1325- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -1327- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


            /*" -1328- MOVE REG-SULAMERICA TO W-TB-REG-BENEFI(W-IND-BENEF-N). */
            _.Move(MOV_SULA?.Value, WAREA_AUXILIAR.W_TAB_BENEFICIARIOS.W_TAB_BENEF_REG[WAREA_AUXILIAR.W_IND_BENEF_N].W_TB_REG_BENEFI);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0325_SAIDA*/

        [StopWatch]
        /*" R0330-00-MOVTO-INF-COMPLEME-SECTION */
        private void R0330_00_MOVTO_INF_COMPLEME_SECTION()
        {
            /*" -1338- MOVE 'R0330-00-MOVTO-INF-COMPLEMENTAR' TO PARAGRAFO. */
            _.Move("R0330-00-MOVTO-INF-COMPLEMENTAR", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1340- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1342- MOVE REG-SULAMERICA TO REG-INFORMACOES. */
            _.Move(MOV_SULA?.Value, LBFPF015.REG_INFORMACOES);

            /*" -1343- IF R5-INFO-COMPLEMEN OF REG-INFORMACOES NOT EQUAL SPACES */

            if (!LBFPF015.REG_INFORMACOES.R5_INFO_COMPLEMEN.IsEmpty())
            {

                /*" -1344- ADD 1 TO W-QTD-LD-SIVPF-5 */
                WAREA_AUXILIAR.W_QTD_LD_SIVPF_5.Value = WAREA_AUXILIAR.W_QTD_LD_SIVPF_5 + 1;

                /*" -1345- MOVE 'SIM' TO W-EXISTE-TP-5 */
                _.Move("SIM", WAREA_AUXILIAR.W_EXISTE_TP_5);

                /*" -1347- ADD 1 TO W-IND-INFO-N */
                WAREA_AUXILIAR.W_IND_INFO_N.Value = WAREA_AUXILIAR.W_IND_INFO_N + 1;

                /*" -1348- IF W-IND-INFO-N GREATER 30 */

                if (WAREA_AUXILIAR.W_IND_INFO_N > 30)
                {

                    /*" -1349- DISPLAY 'PF0103B - FIM ANORMAL' */
                    _.Display($"PF0103B - FIM ANORMAL");

                    /*" -1350- DISPLAY '          ESTOURO DA TABELA INF.COMPLEMENTAR' */
                    _.Display($"          ESTOURO DA TABELA INF.COMPLEMENTAR");

                    /*" -1352- DISPLAY '          NUMERO DA PROPOSTA..............  ' R5-NUM-PROPOSTA OF REG-INFORMACOES */
                    _.Display($"          NUMERO DA PROPOSTA..............  {LBFPF015.REG_INFORMACOES.R5_NUM_PROPOSTA}");

                    /*" -1354- DISPLAY '          W-IND-INFO-N....................  ' W-IND-INFO-N */
                    _.Display($"          W-IND-INFO-N....................  {WAREA_AUXILIAR.W_IND_INFO_N}");

                    /*" -1355- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -1356- PERFORM R9999-00-FINALIZAR */

                    R9999_00_FINALIZAR_SECTION();

                    /*" -1358- END-IF */
                }


                /*" -1358- MOVE REG-SULAMERICA TO W-TB-REG-INFORMACOES(W-IND-INFO-N). */
                _.Move(MOV_SULA?.Value, WAREA_AUXILIAR.W_TAB_INFORMACOES.W_TAB_INFO_REG[WAREA_AUXILIAR.W_IND_INFO_N].W_TB_REG_INFORMACOES);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0330_SAIDA*/

        [StopWatch]
        /*" R0336-00-MOVTO-CLAUSULA-AUTO-SECTION */
        private void R0336_00_MOVTO_CLAUSULA_AUTO_SECTION()
        {
            /*" -1368- MOVE 'R0336-00-MOVTO-CLAUSULA-AUTO' TO PARAGRAFO. */
            _.Move("R0336-00-MOVTO-CLAUSULA-AUTO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1370- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1372- ADD 1 TO W-IND-CLAU-N */
            WAREA_AUXILIAR.W_IND_CLAU_N.Value = WAREA_AUXILIAR.W_IND_CLAU_N + 1;

            /*" -1373- IF W-IND-CLAU-N GREATER 30 */

            if (WAREA_AUXILIAR.W_IND_CLAU_N > 30)
            {

                /*" -1374- DISPLAY 'PF0103B - FIM ANORMAL' */
                _.Display($"PF0103B - FIM ANORMAL");

                /*" -1375- DISPLAY '          ESTOURO TABELA CLAUSULAS AUTOMOVEL' */
                _.Display($"          ESTOURO TABELA CLAUSULAS AUTOMOVEL");

                /*" -1377- DISPLAY '          NUMERO DA PROPOSTA............  ' R6-NUM-PROPOSTA OF REG-VAL-ACESSORIOS */
                _.Display($"          NUMERO DA PROPOSTA............  {LBFPF016.REG_VAL_ACESSORIOS.R6_NUM_PROPOSTA}");

                /*" -1379- DISPLAY '          W-IND-CLAU-N..................  ' W-IND-CLAU-N */
                _.Display($"          W-IND-CLAU-N..................  {WAREA_AUXILIAR.W_IND_CLAU_N}");

                /*" -1380- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -1382- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


            /*" -1382- MOVE REG-SULAMERICA TO W-TB-REG-CLAUSULA(W-IND-CLAU-N). */
            _.Move(MOV_SULA?.Value, WAREA_AUXILIAR.W_TAB_CLAUSULAS.W_TAB_CLAU_REG[WAREA_AUXILIAR.W_IND_CLAU_N].W_TB_REG_CLAUSULA);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0336_SAIDA*/

        [StopWatch]
        /*" R0460-00-GERAR-HEADER-SECTION */
        private void R0460_00_GERAR_HEADER_SECTION()
        {
            /*" -1393- MOVE 'R0460-00-GERAR-HEADER' TO PARAGRAFO. */
            _.Move("R0460-00-GERAR-HEADER", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1395- MOVE 'WHITE REG-HEADER' TO COMANDO. */
            _.Move("WHITE REG-HEADER", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1398- MOVE 'H' TO RH-TIPO-REG OF REG-HEADER */
            _.Move("H", LXFPF990.REG_HEADER.RH_TIPO_REG);

            /*" -1401- MOVE 'PRPSASSE' TO RH-NOME OF REG-HEADER */
            _.Move("PRPSASSE", LXFPF990.REG_HEADER.RH_NOME);

            /*" -1402- MOVE W-DIA-MOVABE OF W-DTMOVABE1 TO W-DIA-TRABALHO */
            _.Move(WAREA_AUXILIAR.W_DTMOVABE1.W_DIA_MOVABE, WAREA_AUXILIAR.FILLER_8.W_DIA_TRABALHO);

            /*" -1403- MOVE W-MES-MOVABE OF W-DTMOVABE1 TO W-MES-TRABALHO */
            _.Move(WAREA_AUXILIAR.W_DTMOVABE1.W_MES_MOVABE, WAREA_AUXILIAR.FILLER_8.W_MES_TRABALHO);

            /*" -1405- MOVE W-ANO-MOVABE OF W-DTMOVABE1 TO W-ANO-TRABALHO */
            _.Move(WAREA_AUXILIAR.W_DTMOVABE1.W_ANO_MOVABE, WAREA_AUXILIAR.FILLER_8.W_ANO_TRABALHO);

            /*" -1408- MOVE W-DATA-TRABALHO TO RH-DATA-GERACAO OF REG-HEADER */
            _.Move(WAREA_AUXILIAR.W_DATA_TRABALHO, LXFPF990.REG_HEADER.RH_DATA_GERACAO);

            /*" -1411- MOVE 8 TO RH-SIST-ORIGEM OF REG-HEADER */
            _.Move(8, LXFPF990.REG_HEADER.RH_SIST_ORIGEM);

            /*" -1413- MOVE 1 TO RH-SIST-DESTINO OF REG-HEADER RH-TIPO-ARQUIVO OF REG-HEADER. */
            _.Move(1, LXFPF990.REG_HEADER.RH_SIST_DESTINO, LXFPF990.REG_HEADER.RH_TIPO_ARQUIVO);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0460_SAIDA*/

        [StopWatch]
        /*" R0480-00-GERAR-TAB-PF-SECTION */
        private void R0480_00_GERAR_TAB_PF_SECTION()
        {
            /*" -1425- MOVE 'R0480-00-GERAR-TAB-PF' TO PARAGRAFO. */
            _.Move("R0480-00-GERAR-TAB-PF", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1427- MOVE '    ' TO COMANDO. */
            _.Move("    ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1428- PERFORM R0500-TRATA-CLIENTE */

            R0500_TRATA_CLIENTE_SECTION();

            /*" -1429- PERFORM R0600-TRATA-END-TEL */

            R0600_TRATA_END_TEL_SECTION();

            /*" -1431- PERFORM R0700-TRATA-PROPOSTA. */

            R0700_TRATA_PROPOSTA_SECTION();

            /*" -1432- IF W-EXISTE-TP-5 EQUAL 'SIM' */

            if (WAREA_AUXILIAR.W_EXISTE_TP_5 == "SIM")
            {

                /*" -1434- PERFORM R0900-TRATA-INF-COMPLEMENTARES VARYING W-IND-INFO1 FROM 1 BY 1 UNTIL W-IND-INFO1 GREATER W-IND-INFO-N. */

                for (WAREA_AUXILIAR.W_IND_INFO1.Value = 1; !(WAREA_AUXILIAR.W_IND_INFO1 > WAREA_AUXILIAR.W_IND_INFO_N); WAREA_AUXILIAR.W_IND_INFO1.Value += 1)
                {

                    R0900_TRATA_INF_COMPLEMENTARES_SECTION();
                }
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0480_SAIDA*/

        [StopWatch]
        /*" R0500-TRATA-CLIENTE-SECTION */
        private void R0500_TRATA_CLIENTE_SECTION()
        {
            /*" -1444- MOVE 'R0500-TRATA-CLIENTE' TO PARAGRAFO. */
            _.Move("R0500-TRATA-CLIENTE", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1446- MOVE '    ' TO COMANDO. */
            _.Move("    ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1448- ADD 1 TO W-QTD-LD-SIVPF-1 */
            WAREA_AUXILIAR.W_QTD_LD_SIVPF_1.Value = WAREA_AUXILIAR.W_QTD_LD_SIVPF_1 + 1;

            /*" -1449- IF R1-DATA-NASCIMENTO OF REG-CLIENTES EQUAL ZEROS */

            if (LBFPF011.REG_CLIENTES.R1_DATA_NASCIMENTO == 00)
            {

                /*" -1451- MOVE 01010001 TO R1-DATA-NASCIMENTO OF REG-CLIENTES. */
                _.Move(01010001, LBFPF011.REG_CLIENTES.R1_DATA_NASCIMENTO);
            }


            /*" -1452- IF R1-TIPO-PESSOA OF REG-CLIENTES EQUAL 1 */

            if (LBFPF011.REG_CLIENTES.R1_TIPO_PESSOA == 1)
            {

                /*" -1453- PERFORM R0505-LER-PESSOA-FISICA */

                R0505_LER_PESSOA_FISICA_SECTION();

                /*" -1454- ELSE */
            }
            else
            {


                /*" -1456- PERFORM R0510-LER-PESSOA-JURIDICA. */

                R0510_LER_PESSOA_JURIDICA_SECTION();
            }


            /*" -1457- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1458- PERFORM R0515-INCLUIR-TAB-CORPORATIVAS */

                R0515_INCLUIR_TAB_CORPORATIVAS_SECTION();

                /*" -1459- ELSE */
            }
            else
            {


                /*" -1460- IF SQLCODE EQUAL 00 */

                if (DB.SQLCODE == 00)
                {

                    /*" -1463- PERFORM R0550-LER-TAB-CORPORATIVAS */

                    R0550_LER_TAB_CORPORATIVAS_SECTION();

                    /*" -1463- PERFORM R0535-INCLUIR-END-EMAIL. */

                    R0535_INCLUIR_END_EMAIL_SECTION();
                }

            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0500_SAIDA*/

        [StopWatch]
        /*" R0505-LER-PESSOA-FISICA-SECTION */
        private void R0505_LER_PESSOA_FISICA_SECTION()
        {
            /*" -1473- MOVE 'R0505-LER-PESSOA-FISICA' TO PARAGRAFO. */
            _.Move("R0505-LER-PESSOA-FISICA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1475- MOVE 'SELECT PESSOA_FISICA' TO COMANDO. */
            _.Move("SELECT PESSOA_FISICA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1478- MOVE R1-CGC-CPF OF REG-CLIENTES TO CPF OF DCLPESSOA-FISICA. */
            _.Move(LBFPF011.REG_CLIENTES.R1_CGC_CPF, PESFIS.DCLPESSOA_FISICA.CPF);

            /*" -1481- MOVE R1-DATA-NASCIMENTO OF REG-CLIENTES TO W-DATA-NASCIMENTO. */
            _.Move(LBFPF011.REG_CLIENTES.R1_DATA_NASCIMENTO, WAREA_AUXILIAR.W_DATA_NASCIMENTO);

            /*" -1484- MOVE W-DIA-NASCIMENTO TO W-DIA-SQL OF W-DATA-SQL1. */
            _.Move(WAREA_AUXILIAR.FILLER_9.W_DIA_NASCIMENTO, WAREA_AUXILIAR.W_DATA_SQL1.W_DIA_SQL);

            /*" -1487- MOVE W-MES-NASCIMENTO TO W-MES-SQL OF W-DATA-SQL1. */
            _.Move(WAREA_AUXILIAR.FILLER_9.W_MES_NASCIMENTO, WAREA_AUXILIAR.W_DATA_SQL1.W_MES_SQL);

            /*" -1490- MOVE W-ANO-NASCIMENTO TO W-ANO-SQL OF W-DATA-SQL1. */
            _.Move(WAREA_AUXILIAR.FILLER_9.W_ANO_NASCIMENTO, WAREA_AUXILIAR.W_DATA_SQL1.W_ANO_SQL);

            /*" -1494- MOVE '-' TO W-BARRA1 OF W-DATA-SQL1, W-BARRA2 OF W-DATA-SQL1. */
            _.Move("-", WAREA_AUXILIAR.W_DATA_SQL1.W_BARRA1_1);
            _.Move("-", WAREA_AUXILIAR.W_DATA_SQL1.W_BARRA2_1);


            /*" -1497- MOVE W-DATA-SQL TO DATA-NASCIMENTO OF DCLPESSOA-FISICA. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL, PESFIS.DCLPESSOA_FISICA.DATA_NASCIMENTO);

            /*" -1498- IF R1-IDE-SEXO OF REG-CLIENTES EQUAL 1 */

            if (LBFPF011.REG_CLIENTES.R1_IDE_SEXO == 1)
            {

                /*" -1500- MOVE 'M' TO SEXO OF DCLPESSOA-FISICA */
                _.Move("M", PESFIS.DCLPESSOA_FISICA.SEXO);

                /*" -1501- ELSE */
            }
            else
            {


                /*" -1504- MOVE 'F' TO SEXO OF DCLPESSOA-FISICA. */
                _.Move("F", PESFIS.DCLPESSOA_FISICA.SEXO);
            }


            /*" -1536- PERFORM R0505_LER_PESSOA_FISICA_DB_SELECT_1 */

            R0505_LER_PESSOA_FISICA_DB_SELECT_1();

            /*" -1539- IF SQLCODE NOT EQUAL 00 AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -1540- DISPLAY 'PF0103B - FIM ANORMAL' */
                _.Display($"PF0103B - FIM ANORMAL");

                /*" -1541- DISPLAY '          ERRO NO ACESSO A PESSOA-FISICA  ' */
                _.Display($"          ERRO NO ACESSO A PESSOA-FISICA  ");

                /*" -1543- DISPLAY '          NUMERO DA PROPOSTA............  ' R1-NUM-PROPOSTA OF REG-CLIENTES */
                _.Display($"          NUMERO DA PROPOSTA............  {LBFPF011.REG_CLIENTES.R1_NUM_PROPOSTA}");

                /*" -1545- DISPLAY '          CPF...........................  ' CPF OF DCLPESSOA-FISICA */
                _.Display($"          CPF...........................  {PESFIS.DCLPESSOA_FISICA.CPF}");

                /*" -1547- DISPLAY '          DATA NASCIMENTO...............  ' DATA-NASCIMENTO OF DCLPESSOA-FISICA */
                _.Display($"          DATA NASCIMENTO...............  {PESFIS.DCLPESSOA_FISICA.DATA_NASCIMENTO}");

                /*" -1549- DISPLAY '          SEXO..........................  ' SEXO OF DCLPESSOA-FISICA */
                _.Display($"          SEXO..........................  {PESFIS.DCLPESSOA_FISICA.SEXO}");

                /*" -1551- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -1552- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -1552- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R0505-LER-PESSOA-FISICA-DB-SELECT-1 */
        public void R0505_LER_PESSOA_FISICA_DB_SELECT_1()
        {
            /*" -1536- EXEC SQL SELECT COD_PESSOA, CPF, DATA_NASCIMENTO, SEXO, TIPO_IDENT_SIVPF, NUM_IDENTIDADE, ORGAO_EXPEDIDOR, UF_EXPEDIDORA, DATA_EXPEDICAO, COD_CBO, COD_USUARIO, ESTADO_CIVIL, TIMESTAMP INTO :DCLPESSOA-FISICA.COD-PESSOA:VIND-COD-PESSOA, :DCLPESSOA-FISICA.CPF:VIND-CPF, :DCLPESSOA-FISICA.DATA-NASCIMENTO:VIND-DTNASCI, :DCLPESSOA-FISICA.SEXO:VIND-SEXO, :DCLPESSOA-FISICA.TIPO-IDENT-SIVPF:VIND-TP-IDENT, :DCLPESSOA-FISICA.NUM-IDENTIDADE:VIND-NUM-IDENT, :DCLPESSOA-FISICA.ORGAO-EXPEDIDOR:VIND-ORGAO-EXP, :DCLPESSOA-FISICA.UF-EXPEDIDORA:VIND-UF-EXP, :DCLPESSOA-FISICA.DATA-EXPEDICAO:VIND-DTEXPEDI, :DCLPESSOA-FISICA.COD-CBO:VIND-COD-CBO, :DCLPESSOA-FISICA.COD-USUARIO:VIND-COD-USUR, :DCLPESSOA-FISICA.ESTADO-CIVIL, :DCLPESSOA-FISICA.TIMESTAMP:VIND-TIMESTAMP FROM SEGUROS.PESSOA_FISICA WHERE CPF = :DCLPESSOA-FISICA.CPF AND DATA_NASCIMENTO = :DCLPESSOA-FISICA.DATA-NASCIMENTO AND SEXO = :DCLPESSOA-FISICA.SEXO WITH UR END-EXEC. */

            var r0505_LER_PESSOA_FISICA_DB_SELECT_1_Query1 = new R0505_LER_PESSOA_FISICA_DB_SELECT_1_Query1()
            {
                DATA_NASCIMENTO = PESFIS.DCLPESSOA_FISICA.DATA_NASCIMENTO.ToString(),
                SEXO = PESFIS.DCLPESSOA_FISICA.SEXO.ToString(),
                CPF = PESFIS.DCLPESSOA_FISICA.CPF.ToString(),
            };

            var executed_1 = R0505_LER_PESSOA_FISICA_DB_SELECT_1_Query1.Execute(r0505_LER_PESSOA_FISICA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.COD_PESSOA, PESFIS.DCLPESSOA_FISICA.COD_PESSOA);
                _.Move(executed_1.VIND_COD_PESSOA, VIND_COD_PESSOA);
                _.Move(executed_1.CPF, PESFIS.DCLPESSOA_FISICA.CPF);
                _.Move(executed_1.VIND_CPF, VIND_CPF);
                _.Move(executed_1.DATA_NASCIMENTO, PESFIS.DCLPESSOA_FISICA.DATA_NASCIMENTO);
                _.Move(executed_1.VIND_DTNASCI, VIND_DTNASCI);
                _.Move(executed_1.SEXO, PESFIS.DCLPESSOA_FISICA.SEXO);
                _.Move(executed_1.VIND_SEXO, VIND_SEXO);
                _.Move(executed_1.TIPO_IDENT_SIVPF, PESFIS.DCLPESSOA_FISICA.TIPO_IDENT_SIVPF);
                _.Move(executed_1.VIND_TP_IDENT, VIND_TP_IDENT);
                _.Move(executed_1.NUM_IDENTIDADE, PESFIS.DCLPESSOA_FISICA.NUM_IDENTIDADE);
                _.Move(executed_1.VIND_NUM_IDENT, VIND_NUM_IDENT);
                _.Move(executed_1.ORGAO_EXPEDIDOR, PESFIS.DCLPESSOA_FISICA.ORGAO_EXPEDIDOR);
                _.Move(executed_1.VIND_ORGAO_EXP, VIND_ORGAO_EXP);
                _.Move(executed_1.UF_EXPEDIDORA, PESFIS.DCLPESSOA_FISICA.UF_EXPEDIDORA);
                _.Move(executed_1.VIND_UF_EXP, VIND_UF_EXP);
                _.Move(executed_1.DATA_EXPEDICAO, PESFIS.DCLPESSOA_FISICA.DATA_EXPEDICAO);
                _.Move(executed_1.VIND_DTEXPEDI, VIND_DTEXPEDI);
                _.Move(executed_1.COD_CBO, PESFIS.DCLPESSOA_FISICA.COD_CBO);
                _.Move(executed_1.VIND_COD_CBO, VIND_COD_CBO);
                _.Move(executed_1.COD_USUARIO, PESFIS.DCLPESSOA_FISICA.COD_USUARIO);
                _.Move(executed_1.VIND_COD_USUR, VIND_COD_USUR);
                _.Move(executed_1.ESTADO_CIVIL, PESFIS.DCLPESSOA_FISICA.ESTADO_CIVIL);
                _.Move(executed_1.TIMESTAMP, PESFIS.DCLPESSOA_FISICA.TIMESTAMP);
                _.Move(executed_1.VIND_TIMESTAMP, VIND_TIMESTAMP);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0505_SAIDA*/

        [StopWatch]
        /*" R0510-LER-PESSOA-JURIDICA-SECTION */
        private void R0510_LER_PESSOA_JURIDICA_SECTION()
        {
            /*" -1648- MOVE 'R0510-LER-PESSOA-JURIDICA' TO PARAGRAFO. */
            _.Move("R0510-LER-PESSOA-JURIDICA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1650- MOVE 'SELECT' TO COMANDO. */
            _.Move("SELECT", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1653- MOVE R1-CGC-CPF OF REG-CLIENTES TO CGC OF DCLPESSOA-JURIDICA. */
            _.Move(LBFPF011.REG_CLIENTES.R1_CGC_CPF, PESJUR.DCLPESSOA_JURIDICA.CGC);

            /*" -1667- PERFORM R0510_LER_PESSOA_JURIDICA_DB_SELECT_1 */

            R0510_LER_PESSOA_JURIDICA_DB_SELECT_1();

            /*" -1670- IF SQLCODE NOT EQUAL 00 AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -1671- DISPLAY 'PF0103B - FIM ANORMAL' */
                _.Display($"PF0103B - FIM ANORMAL");

                /*" -1672- DISPLAY '          ERRO NO ACESSO A PESSOA-JURIDICA' */
                _.Display($"          ERRO NO ACESSO A PESSOA-JURIDICA");

                /*" -1674- DISPLAY '          NUMERO DA PROPOSTA............  ' R1-NUM-PROPOSTA OF REG-CLIENTES */
                _.Display($"          NUMERO DA PROPOSTA............  {LBFPF011.REG_CLIENTES.R1_NUM_PROPOSTA}");

                /*" -1676- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -1677- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -1677- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R0510-LER-PESSOA-JURIDICA-DB-SELECT-1 */
        public void R0510_LER_PESSOA_JURIDICA_DB_SELECT_1()
        {
            /*" -1667- EXEC SQL SELECT COD_PESSOA, CGC, NOME_FANTASIA, COD_USUARIO, TIMESTAMP INTO :DCLPESSOA-JURIDICA.COD-PESSOA, :DCLPESSOA-JURIDICA.CGC, :DCLPESSOA-JURIDICA.NOME-FANTASIA, :DCLPESSOA-JURIDICA.COD-USUARIO, :DCLPESSOA-JURIDICA.TIMESTAMP FROM SEGUROS.PESSOA_JURIDICA WHERE CGC = :DCLPESSOA-JURIDICA.CGC WITH UR END-EXEC. */

            var r0510_LER_PESSOA_JURIDICA_DB_SELECT_1_Query1 = new R0510_LER_PESSOA_JURIDICA_DB_SELECT_1_Query1()
            {
                CGC = PESJUR.DCLPESSOA_JURIDICA.CGC.ToString(),
            };

            var executed_1 = R0510_LER_PESSOA_JURIDICA_DB_SELECT_1_Query1.Execute(r0510_LER_PESSOA_JURIDICA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.COD_PESSOA, PESJUR.DCLPESSOA_JURIDICA.COD_PESSOA);
                _.Move(executed_1.CGC, PESJUR.DCLPESSOA_JURIDICA.CGC);
                _.Move(executed_1.NOME_FANTASIA, PESJUR.DCLPESSOA_JURIDICA.NOME_FANTASIA);
                _.Move(executed_1.COD_USUARIO, PESJUR.DCLPESSOA_JURIDICA.COD_USUARIO);
                _.Move(executed_1.TIMESTAMP, PESJUR.DCLPESSOA_JURIDICA.TIMESTAMP);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0510_SAIDA*/

        [StopWatch]
        /*" R0515-INCLUIR-TAB-CORPORATIVAS-SECTION */
        private void R0515_INCLUIR_TAB_CORPORATIVAS_SECTION()
        {
            /*" -1686- MOVE 'R0515-INCLUIR-TAB-CORPORATIVAS' TO PARAGRAFO. */
            _.Move("R0515-INCLUIR-TAB-CORPORATIVAS", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1688- MOVE '      ' TO COMANDO. */
            _.Move("      ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1690- PERFORM R0520-INCLUIR-TAB-PESSOA. */

            R0520_INCLUIR_TAB_PESSOA_SECTION();

            /*" -1691- IF R1-TIPO-PESSOA OF REG-CLIENTES EQUAL 1 */

            if (LBFPF011.REG_CLIENTES.R1_TIPO_PESSOA == 1)
            {

                /*" -1692- PERFORM R0525-INCLUIR-PESSOA-FISICA */

                R0525_INCLUIR_PESSOA_FISICA_SECTION();

                /*" -1693- ELSE */
            }
            else
            {


                /*" -1695- PERFORM R0530-INCLUIR-PESSOA-JURIDICA. */

                R0530_INCLUIR_PESSOA_JURIDICA_SECTION();
            }


            /*" -1695- PERFORM R0535-INCLUIR-END-EMAIL. */

            R0535_INCLUIR_END_EMAIL_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0515_SAIDA*/

        [StopWatch]
        /*" R0520-INCLUIR-TAB-PESSOA-SECTION */
        private void R0520_INCLUIR_TAB_PESSOA_SECTION()
        {
            /*" -1705- IF W-OBTER-MAX-PESSOA EQUAL 'NAO' */

            if (WAREA_AUXILIAR.W_OBTER_MAX_PESSOA == "NAO")
            {

                /*" -1706- MOVE 'SIM' TO W-OBTER-MAX-PESSOA */
                _.Move("SIM", WAREA_AUXILIAR.W_OBTER_MAX_PESSOA);

                /*" -1708- PERFORM R0521-OBTER-MAX-COD-PESSOA. */

                R0521_OBTER_MAX_COD_PESSOA_SECTION();
            }


            /*" -1709- MOVE 'R0520-INCLUIR-TAB-PESSOA' TO PARAGRAFO. */
            _.Move("R0520-INCLUIR-TAB-PESSOA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1711- MOVE '      ' TO COMANDO. */
            _.Move("      ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1714- COMPUTE W-COD-PESSOA = W-COD-PESSOA + 1 */
            WAREA_AUXILIAR.W_COD_PESSOA.Value = WAREA_AUXILIAR.W_COD_PESSOA + 1;

            /*" -1717- MOVE W-COD-PESSOA TO PESSOA-COD-PESSOA OF DCLPESSOA. */
            _.Move(WAREA_AUXILIAR.W_COD_PESSOA, PESSOA.DCLPESSOA.PESSOA_COD_PESSOA);

            /*" -1720- MOVE R1-NOME-PESSOA OF REG-CLIENTES TO PESSOA-NOME-PESSOA OF DCLPESSOA. */
            _.Move(LBFPF011.REG_CLIENTES.R1_NOME_PESSOA, PESSOA.DCLPESSOA.PESSOA_NOME_PESSOA);

            /*" -1723- MOVE ' ' TO PESSOA-TIPO-PESSOA OF DCLPESSOA. */
            _.Move(" ", PESSOA.DCLPESSOA.PESSOA_TIPO_PESSOA);

            /*" -1724- IF R1-TIPO-PESSOA OF REG-CLIENTES EQUAL 1 */

            if (LBFPF011.REG_CLIENTES.R1_TIPO_PESSOA == 1)
            {

                /*" -1726- MOVE 'F' TO PESSOA-TIPO-PESSOA OF DCLPESSOA */
                _.Move("F", PESSOA.DCLPESSOA.PESSOA_TIPO_PESSOA);

                /*" -1727- ELSE */
            }
            else
            {


                /*" -1728- IF R1-TIPO-PESSOA OF REG-CLIENTES EQUAL 2 */

                if (LBFPF011.REG_CLIENTES.R1_TIPO_PESSOA == 2)
                {

                    /*" -1731- MOVE 'J' TO PESSOA-TIPO-PESSOA OF DCLPESSOA. */
                    _.Move("J", PESSOA.DCLPESSOA.PESSOA_TIPO_PESSOA);
                }

            }


            /*" -1734- MOVE 'PF0103B' TO PESSOA-COD-USUARIO OF DCLPESSOA. */
            _.Move("PF0103B", PESSOA.DCLPESSOA.PESSOA_COD_USUARIO);

            /*" -1742- PERFORM R0520_INCLUIR_TAB_PESSOA_DB_INSERT_1 */

            R0520_INCLUIR_TAB_PESSOA_DB_INSERT_1();

            /*" -1745- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -1746- DISPLAY 'PF0103B - FIM ANORMAL' */
                _.Display($"PF0103B - FIM ANORMAL");

                /*" -1747- DISPLAY '          ERRO INSERT DA TABELA PESSOA' */
                _.Display($"          ERRO INSERT DA TABELA PESSOA");

                /*" -1749- DISPLAY '          CODIGO PESSOA.................  ' PESSOA-COD-PESSOA OF DCLPESSOA */
                _.Display($"          CODIGO PESSOA.................  {PESSOA.DCLPESSOA.PESSOA_COD_PESSOA}");

                /*" -1751- DISPLAY '          NOME DA PESSOA................  ' PESSOA-NOME-PESSOA OF DCLPESSOA */
                _.Display($"          NOME DA PESSOA................  {PESSOA.DCLPESSOA.PESSOA_NOME_PESSOA}");

                /*" -1753- DISPLAY '          NUMERO PROPOSTA...............  ' R1-NUM-PROPOSTA OF REG-CLIENTES */
                _.Display($"          NUMERO PROPOSTA...............  {LBFPF011.REG_CLIENTES.R1_NUM_PROPOSTA}");

                /*" -1755- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -1756- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -1756- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R0520-INCLUIR-TAB-PESSOA-DB-INSERT-1 */
        public void R0520_INCLUIR_TAB_PESSOA_DB_INSERT_1()
        {
            /*" -1742- EXEC SQL INSERT INTO SEGUROS.PESSOA VALUES (:DCLPESSOA.PESSOA-COD-PESSOA, :DCLPESSOA.PESSOA-NOME-PESSOA, CURRENT TIMESTAMP, :DCLPESSOA.PESSOA-COD-USUARIO, :DCLPESSOA.PESSOA-TIPO-PESSOA, NULL) END-EXEC. */

            var r0520_INCLUIR_TAB_PESSOA_DB_INSERT_1_Insert1 = new R0520_INCLUIR_TAB_PESSOA_DB_INSERT_1_Insert1()
            {
                PESSOA_COD_PESSOA = PESSOA.DCLPESSOA.PESSOA_COD_PESSOA.ToString(),
                PESSOA_NOME_PESSOA = PESSOA.DCLPESSOA.PESSOA_NOME_PESSOA.ToString(),
                PESSOA_COD_USUARIO = PESSOA.DCLPESSOA.PESSOA_COD_USUARIO.ToString(),
                PESSOA_TIPO_PESSOA = PESSOA.DCLPESSOA.PESSOA_TIPO_PESSOA.ToString(),
            };

            R0520_INCLUIR_TAB_PESSOA_DB_INSERT_1_Insert1.Execute(r0520_INCLUIR_TAB_PESSOA_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0520_SAIDA*/

        [StopWatch]
        /*" R0521-OBTER-MAX-COD-PESSOA-SECTION */
        private void R0521_OBTER_MAX_COD_PESSOA_SECTION()
        {
            /*" -1766- MOVE 'R0521-OBTER-MAX-COD-PESSOA' TO PARAGRAFO. */
            _.Move("R0521-OBTER-MAX-COD-PESSOA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1768- MOVE 'MAX SEGUROS.PESSOA' TO COMANDO. */
            _.Move("MAX SEGUROS.PESSOA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1773- PERFORM R0521_OBTER_MAX_COD_PESSOA_DB_SELECT_1 */

            R0521_OBTER_MAX_COD_PESSOA_DB_SELECT_1();

            /*" -1776- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -1777- DISPLAY 'PF0103B - FIM ANORMAL' */
                _.Display($"PF0103B - FIM ANORMAL");

                /*" -1778- DISPLAY '          ERRO NO SELECT MAX TAB. PESSOA' */
                _.Display($"          ERRO NO SELECT MAX TAB. PESSOA");

                /*" -1780- DISPLAY '          NUMERO DA PROPOSTA............  ' R1-NUM-PROPOSTA OF REG-CLIENTES */
                _.Display($"          NUMERO DA PROPOSTA............  {LBFPF011.REG_CLIENTES.R1_NUM_PROPOSTA}");

                /*" -1782- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -1783- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -1785- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


            /*" -1786- MOVE PESSOA-COD-PESSOA OF DCLPESSOA TO W-COD-PESSOA. */
            _.Move(PESSOA.DCLPESSOA.PESSOA_COD_PESSOA, WAREA_AUXILIAR.W_COD_PESSOA);

        }

        [StopWatch]
        /*" R0521-OBTER-MAX-COD-PESSOA-DB-SELECT-1 */
        public void R0521_OBTER_MAX_COD_PESSOA_DB_SELECT_1()
        {
            /*" -1773- EXEC SQL SELECT VALUE(MAX(COD_PESSOA),0) INTO :DCLPESSOA.PESSOA-COD-PESSOA FROM SEGUROS.PESSOA WITH UR END-EXEC. */

            var r0521_OBTER_MAX_COD_PESSOA_DB_SELECT_1_Query1 = new R0521_OBTER_MAX_COD_PESSOA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0521_OBTER_MAX_COD_PESSOA_DB_SELECT_1_Query1.Execute(r0521_OBTER_MAX_COD_PESSOA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PESSOA_COD_PESSOA, PESSOA.DCLPESSOA.PESSOA_COD_PESSOA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0521_SAIDA*/

        [StopWatch]
        /*" R0525-INCLUIR-PESSOA-FISICA-SECTION */
        private void R0525_INCLUIR_PESSOA_FISICA_SECTION()
        {
            /*" -1796- MOVE 'R0525-INCLUIR-PESSOAS-FISICA' TO PARAGRAFO. */
            _.Move("R0525-INCLUIR-PESSOAS-FISICA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1798- MOVE 'INSERT PESSOA-FISICA' TO COMANDO. */
            _.Move("INSERT PESSOA-FISICA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1801- MOVE PESSOA-COD-PESSOA OF DCLPESSOA TO COD-PESSOA OF DCLPESSOA-FISICA. */
            _.Move(PESSOA.DCLPESSOA.PESSOA_COD_PESSOA, PESFIS.DCLPESSOA_FISICA.COD_PESSOA);

            /*" -1804- MOVE R1-CGC-CPF OF REG-CLIENTES TO CPF OF DCLPESSOA-FISICA. */
            _.Move(LBFPF011.REG_CLIENTES.R1_CGC_CPF, PESFIS.DCLPESSOA_FISICA.CPF);

            /*" -1807- MOVE R1-DATA-NASCIMENTO OF REG-CLIENTES TO W-DATA-NASCIMENTO. */
            _.Move(LBFPF011.REG_CLIENTES.R1_DATA_NASCIMENTO, WAREA_AUXILIAR.W_DATA_NASCIMENTO);

            /*" -1810- MOVE W-DIA-NASCIMENTO TO W-DIA-SQL OF W-DATA-SQL1. */
            _.Move(WAREA_AUXILIAR.FILLER_9.W_DIA_NASCIMENTO, WAREA_AUXILIAR.W_DATA_SQL1.W_DIA_SQL);

            /*" -1813- MOVE W-MES-NASCIMENTO TO W-MES-SQL OF W-DATA-SQL1. */
            _.Move(WAREA_AUXILIAR.FILLER_9.W_MES_NASCIMENTO, WAREA_AUXILIAR.W_DATA_SQL1.W_MES_SQL);

            /*" -1816- MOVE W-ANO-NASCIMENTO TO W-ANO-SQL OF W-DATA-SQL1. */
            _.Move(WAREA_AUXILIAR.FILLER_9.W_ANO_NASCIMENTO, WAREA_AUXILIAR.W_DATA_SQL1.W_ANO_SQL);

            /*" -1820- MOVE '-' TO W-BARRA1 OF W-DATA-SQL1, W-BARRA2 OF W-DATA-SQL1. */
            _.Move("-", WAREA_AUXILIAR.W_DATA_SQL1.W_BARRA1_1);
            _.Move("-", WAREA_AUXILIAR.W_DATA_SQL1.W_BARRA2_1);


            /*" -1823- MOVE W-DATA-SQL TO DATA-NASCIMENTO OF DCLPESSOA-FISICA. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL, PESFIS.DCLPESSOA_FISICA.DATA_NASCIMENTO);

            /*" -1824- IF R1-IDE-SEXO OF REG-CLIENTES EQUAL 1 */

            if (LBFPF011.REG_CLIENTES.R1_IDE_SEXO == 1)
            {

                /*" -1826- MOVE 'M' TO SEXO OF DCLPESSOA-FISICA */
                _.Move("M", PESFIS.DCLPESSOA_FISICA.SEXO);

                /*" -1827- ELSE */
            }
            else
            {


                /*" -1830- MOVE 'F' TO SEXO OF DCLPESSOA-FISICA. */
                _.Move("F", PESFIS.DCLPESSOA_FISICA.SEXO);
            }


            /*" -1833- MOVE SPACES TO TIPO-IDENT-SIVPF OF DCLPESSOA-FISICA. */
            _.Move("", PESFIS.DCLPESSOA_FISICA.TIPO_IDENT_SIVPF);

            /*" -1836- MOVE R1-NUM-IDENTIDADE OF REG-CLIENTES TO NUM-IDENTIDADE OF DCLPESSOA-FISICA. */
            _.Move(LBFPF011.REG_CLIENTES.R1_NUM_IDENTIDADE, PESFIS.DCLPESSOA_FISICA.NUM_IDENTIDADE);

            /*" -1839- MOVE R1-ORGAO-EXPEDIDOR OF REG-CLIENTES TO ORGAO-EXPEDIDOR OF DCLPESSOA-FISICA. */
            _.Move(LBFPF011.REG_CLIENTES.R1_ORGAO_EXPEDIDOR, PESFIS.DCLPESSOA_FISICA.ORGAO_EXPEDIDOR);

            /*" -1842- MOVE R1-UF-EXPEDIDORA OF REG-CLIENTES TO UF-EXPEDIDORA OF DCLPESSOA-FISICA. */
            _.Move(LBFPF011.REG_CLIENTES.R1_UF_EXPEDIDORA, PESFIS.DCLPESSOA_FISICA.UF_EXPEDIDORA);

            /*" -1843- IF R1-ESTADO-CIVIL OF REG-CLIENTES EQUAL 1 */

            if (LBFPF011.REG_CLIENTES.R1_ESTADO_CIVIL == 1)
            {

                /*" -1845- MOVE 'S' TO ESTADO-CIVIL OF DCLPESSOA-FISICA */
                _.Move("S", PESFIS.DCLPESSOA_FISICA.ESTADO_CIVIL);

                /*" -1846- ELSE */
            }
            else
            {


                /*" -1847- IF R1-ESTADO-CIVIL OF REG-CLIENTES EQUAL 2 */

                if (LBFPF011.REG_CLIENTES.R1_ESTADO_CIVIL == 2)
                {

                    /*" -1849- MOVE 'C' TO ESTADO-CIVIL OF DCLPESSOA-FISICA */
                    _.Move("C", PESFIS.DCLPESSOA_FISICA.ESTADO_CIVIL);

                    /*" -1850- ELSE */
                }
                else
                {


                    /*" -1851- IF R1-ESTADO-CIVIL OF REG-CLIENTES EQUAL 3 */

                    if (LBFPF011.REG_CLIENTES.R1_ESTADO_CIVIL == 3)
                    {

                        /*" -1853- MOVE 'V' TO ESTADO-CIVIL OF DCLPESSOA-FISICA */
                        _.Move("V", PESFIS.DCLPESSOA_FISICA.ESTADO_CIVIL);

                        /*" -1854- ELSE */
                    }
                    else
                    {


                        /*" -1857- MOVE 'O' TO ESTADO-CIVIL OF DCLPESSOA-FISICA. */
                        _.Move("O", PESFIS.DCLPESSOA_FISICA.ESTADO_CIVIL);
                    }

                }

            }


            /*" -1860- MOVE R1-DATA-EXPEDICAO-RG OF REG-CLIENTES TO W-DATA-TRABALHO. */
            _.Move(LBFPF011.REG_CLIENTES.R1_DATA_EXPEDICAO_RG, WAREA_AUXILIAR.W_DATA_TRABALHO);

            /*" -1861- IF W-DATA-TRABALHO NOT NUMERIC */

            if (!WAREA_AUXILIAR.W_DATA_TRABALHO.IsNumeric())
            {

                /*" -1863- MOVE -1 TO VIND-DTEXPEDI */
                _.Move(-1, VIND_DTEXPEDI);

                /*" -1864- ELSE */
            }
            else
            {


                /*" -1866- IF W-DATA-TRABALHO EQUAL 01010001 OR W-DATA-TRABALHO EQUAL ZEROS */

                if (WAREA_AUXILIAR.W_DATA_TRABALHO == 01010001 || WAREA_AUXILIAR.W_DATA_TRABALHO == 00)
                {

                    /*" -1868- MOVE -1 TO VIND-DTEXPEDI */
                    _.Move(-1, VIND_DTEXPEDI);

                    /*" -1869- ELSE */
                }
                else
                {


                    /*" -1871- MOVE W-DIA-TRABALHO TO W-DIA-SQL OF W-DATA-SQL1 */
                    _.Move(WAREA_AUXILIAR.FILLER_8.W_DIA_TRABALHO, WAREA_AUXILIAR.W_DATA_SQL1.W_DIA_SQL);

                    /*" -1873- MOVE W-MES-TRABALHO TO W-MES-SQL OF W-DATA-SQL1 */
                    _.Move(WAREA_AUXILIAR.FILLER_8.W_MES_TRABALHO, WAREA_AUXILIAR.W_DATA_SQL1.W_MES_SQL);

                    /*" -1876- MOVE W-ANO-TRABALHO TO W-ANO-SQL OF W-DATA-SQL1 */
                    _.Move(WAREA_AUXILIAR.FILLER_8.W_ANO_TRABALHO, WAREA_AUXILIAR.W_DATA_SQL1.W_ANO_SQL);

                    /*" -1880- MOVE '-' TO W-BARRA1 OF W-DATA-SQL1, W-BARRA2 OF W-DATA-SQL1 */
                    _.Move("-", WAREA_AUXILIAR.W_DATA_SQL1.W_BARRA1_1);
                    _.Move("-", WAREA_AUXILIAR.W_DATA_SQL1.W_BARRA2_1);


                    /*" -1883- MOVE W-DATA-SQL TO DATA-EXPEDICAO OF DCLPESSOA-FISICA. */
                    _.Move(WAREA_AUXILIAR.W_DATA_SQL, PESFIS.DCLPESSOA_FISICA.DATA_EXPEDICAO);
                }

            }


            /*" -1886- MOVE R1-COD-CBO OF REG-CLIENTES TO COD-CBO OF DCLPESSOA-FISICA. */
            _.Move(LBFPF011.REG_CLIENTES.R1_COD_CBO, PESFIS.DCLPESSOA_FISICA.COD_CBO);

            /*" -1889- MOVE 'PF0103B' TO COD-USUARIO OF DCLPESSOA-FISICA. */
            _.Move("PF0103B", PESFIS.DCLPESSOA_FISICA.COD_USUARIO);

            /*" -1904- PERFORM R0525_INCLUIR_PESSOA_FISICA_DB_INSERT_1 */

            R0525_INCLUIR_PESSOA_FISICA_DB_INSERT_1();

            /*" -1908- IF SQLCODE NOT EQUAL 00 AND SQLCODE NOT EQUAL -530 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != -530)
            {

                /*" -1909- DISPLAY 'PF0103B - FIM ANORMAL' */
                _.Display($"PF0103B - FIM ANORMAL");

                /*" -1910- DISPLAY '          ERRO INSERT DA TABELA PESSOA FISICA 1' */
                _.Display($"          ERRO INSERT DA TABELA PESSOA FISICA 1");

                /*" -1912- DISPLAY '          CODIGO PESSOA.................  ' COD-PESSOA OF DCLPESSOA-FISICA */
                _.Display($"          CODIGO PESSOA.................  {PESFIS.DCLPESSOA_FISICA.COD_PESSOA}");

                /*" -1914- DISPLAY '          NUMERO PROPOSTA...............  ' R1-NUM-PROPOSTA OF REG-CLIENTES */
                _.Display($"          NUMERO PROPOSTA...............  {LBFPF011.REG_CLIENTES.R1_NUM_PROPOSTA}");

                /*" -1916- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -1917- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -1918- PERFORM R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION();

                /*" -1919- ELSE */
            }
            else
            {


                /*" -1920- IF SQLCODE EQUAL -530 */

                if (DB.SQLCODE == -530)
                {

                    /*" -1922- MOVE ZEROS TO COD-CBO OF DCLPESSOA-FISICA */
                    _.Move(0, PESFIS.DCLPESSOA_FISICA.COD_CBO);

                    /*" -1924- MOVE 'RJ' TO UF-EXPEDIDORA OF DCLPESSOA-FISICA */
                    _.Move("RJ", PESFIS.DCLPESSOA_FISICA.UF_EXPEDIDORA);

                    /*" -1939- PERFORM R0525_INCLUIR_PESSOA_FISICA_DB_INSERT_2 */

                    R0525_INCLUIR_PESSOA_FISICA_DB_INSERT_2();

                    /*" -1942- IF SQLCODE NOT EQUAL 00 */

                    if (DB.SQLCODE != 00)
                    {

                        /*" -1943- DISPLAY 'PF0103B - FIM ANORMAL' */
                        _.Display($"PF0103B - FIM ANORMAL");

                        /*" -1944- DISPLAY '          ERRO INSERT DA TAB PESSOA FISICA 2' */
                        _.Display($"          ERRO INSERT DA TAB PESSOA FISICA 2");

                        /*" -1946- DISPLAY '          CODIGO PESSOA.................  ' COD-PESSOA OF DCLPESSOA-FISICA */
                        _.Display($"          CODIGO PESSOA.................  {PESFIS.DCLPESSOA_FISICA.COD_PESSOA}");

                        /*" -1948- DISPLAY '          NUMERO PROPOSTA...............  ' R1-NUM-PROPOSTA OF REG-CLIENTES */
                        _.Display($"          NUMERO PROPOSTA...............  {LBFPF011.REG_CLIENTES.R1_NUM_PROPOSTA}");

                        /*" -1950- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                        _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                        /*" -1951- PERFORM R9988-00-FECHAR-ARQUIVOS */

                        R9988_00_FECHAR_ARQUIVOS_SECTION();

                        /*" -1951- PERFORM R9999-00-FINALIZAR. */

                        R9999_00_FINALIZAR_SECTION();
                    }

                }

            }


        }

        [StopWatch]
        /*" R0525-INCLUIR-PESSOA-FISICA-DB-INSERT-1 */
        public void R0525_INCLUIR_PESSOA_FISICA_DB_INSERT_1()
        {
            /*" -1904- EXEC SQL INSERT INTO SEGUROS.PESSOA_FISICA VALUES (:DCLPESSOA-FISICA.COD-PESSOA, :DCLPESSOA-FISICA.CPF, :DCLPESSOA-FISICA.DATA-NASCIMENTO, :DCLPESSOA-FISICA.SEXO, :DCLPESSOA-FISICA.COD-USUARIO, :DCLPESSOA-FISICA.ESTADO-CIVIL, CURRENT TIMESTAMP, :DCLPESSOA-FISICA.NUM-IDENTIDADE, :DCLPESSOA-FISICA.ORGAO-EXPEDIDOR, :DCLPESSOA-FISICA.UF-EXPEDIDORA, :DCLPESSOA-FISICA.DATA-EXPEDICAO:VIND-DTEXPEDI, :DCLPESSOA-FISICA.COD-CBO, :DCLPESSOA-FISICA.TIPO-IDENT-SIVPF) END-EXEC. */

            var r0525_INCLUIR_PESSOA_FISICA_DB_INSERT_1_Insert1 = new R0525_INCLUIR_PESSOA_FISICA_DB_INSERT_1_Insert1()
            {
                COD_PESSOA = PESFIS.DCLPESSOA_FISICA.COD_PESSOA.ToString(),
                CPF = PESFIS.DCLPESSOA_FISICA.CPF.ToString(),
                DATA_NASCIMENTO = PESFIS.DCLPESSOA_FISICA.DATA_NASCIMENTO.ToString(),
                SEXO = PESFIS.DCLPESSOA_FISICA.SEXO.ToString(),
                COD_USUARIO = PESFIS.DCLPESSOA_FISICA.COD_USUARIO.ToString(),
                ESTADO_CIVIL = PESFIS.DCLPESSOA_FISICA.ESTADO_CIVIL.ToString(),
                NUM_IDENTIDADE = PESFIS.DCLPESSOA_FISICA.NUM_IDENTIDADE.ToString(),
                ORGAO_EXPEDIDOR = PESFIS.DCLPESSOA_FISICA.ORGAO_EXPEDIDOR.ToString(),
                UF_EXPEDIDORA = PESFIS.DCLPESSOA_FISICA.UF_EXPEDIDORA.ToString(),
                DATA_EXPEDICAO = PESFIS.DCLPESSOA_FISICA.DATA_EXPEDICAO.ToString(),
                VIND_DTEXPEDI = VIND_DTEXPEDI.ToString(),
                COD_CBO = PESFIS.DCLPESSOA_FISICA.COD_CBO.ToString(),
                TIPO_IDENT_SIVPF = PESFIS.DCLPESSOA_FISICA.TIPO_IDENT_SIVPF.ToString(),
            };

            R0525_INCLUIR_PESSOA_FISICA_DB_INSERT_1_Insert1.Execute(r0525_INCLUIR_PESSOA_FISICA_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0525_SAIDA*/

        [StopWatch]
        /*" R0525-INCLUIR-PESSOA-FISICA-DB-INSERT-2 */
        public void R0525_INCLUIR_PESSOA_FISICA_DB_INSERT_2()
        {
            /*" -1939- EXEC SQL INSERT INTO SEGUROS.PESSOA_FISICA VALUES (:DCLPESSOA-FISICA.COD-PESSOA, :DCLPESSOA-FISICA.CPF, :DCLPESSOA-FISICA.DATA-NASCIMENTO, :DCLPESSOA-FISICA.SEXO, :DCLPESSOA-FISICA.COD-USUARIO, :DCLPESSOA-FISICA.ESTADO-CIVIL, CURRENT TIMESTAMP, :DCLPESSOA-FISICA.NUM-IDENTIDADE, :DCLPESSOA-FISICA.ORGAO-EXPEDIDOR, :DCLPESSOA-FISICA.UF-EXPEDIDORA, :DCLPESSOA-FISICA.DATA-EXPEDICAO:VIND-DTEXPEDI, :DCLPESSOA-FISICA.COD-CBO, :DCLPESSOA-FISICA.TIPO-IDENT-SIVPF) END-EXEC */

            var r0525_INCLUIR_PESSOA_FISICA_DB_INSERT_2_Insert1 = new R0525_INCLUIR_PESSOA_FISICA_DB_INSERT_2_Insert1()
            {
                COD_PESSOA = PESFIS.DCLPESSOA_FISICA.COD_PESSOA.ToString(),
                CPF = PESFIS.DCLPESSOA_FISICA.CPF.ToString(),
                DATA_NASCIMENTO = PESFIS.DCLPESSOA_FISICA.DATA_NASCIMENTO.ToString(),
                SEXO = PESFIS.DCLPESSOA_FISICA.SEXO.ToString(),
                COD_USUARIO = PESFIS.DCLPESSOA_FISICA.COD_USUARIO.ToString(),
                ESTADO_CIVIL = PESFIS.DCLPESSOA_FISICA.ESTADO_CIVIL.ToString(),
                NUM_IDENTIDADE = PESFIS.DCLPESSOA_FISICA.NUM_IDENTIDADE.ToString(),
                ORGAO_EXPEDIDOR = PESFIS.DCLPESSOA_FISICA.ORGAO_EXPEDIDOR.ToString(),
                UF_EXPEDIDORA = PESFIS.DCLPESSOA_FISICA.UF_EXPEDIDORA.ToString(),
                DATA_EXPEDICAO = PESFIS.DCLPESSOA_FISICA.DATA_EXPEDICAO.ToString(),
                VIND_DTEXPEDI = VIND_DTEXPEDI.ToString(),
                COD_CBO = PESFIS.DCLPESSOA_FISICA.COD_CBO.ToString(),
                TIPO_IDENT_SIVPF = PESFIS.DCLPESSOA_FISICA.TIPO_IDENT_SIVPF.ToString(),
            };

            R0525_INCLUIR_PESSOA_FISICA_DB_INSERT_2_Insert1.Execute(r0525_INCLUIR_PESSOA_FISICA_DB_INSERT_2_Insert1);

        }

        [StopWatch]
        /*" R0530-INCLUIR-PESSOA-JURIDICA-SECTION */
        private void R0530_INCLUIR_PESSOA_JURIDICA_SECTION()
        {
            /*" -1960- MOVE 'R0530-INCLUIR-PESSOAS-JURIDICA' TO PARAGRAFO. */
            _.Move("R0530-INCLUIR-PESSOAS-JURIDICA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1962- MOVE 'INSERT PESSOA-JURIDICA' TO COMANDO. */
            _.Move("INSERT PESSOA-JURIDICA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1965- MOVE PESSOA-COD-PESSOA OF DCLPESSOA TO COD-PESSOA OF DCLPESSOA-JURIDICA */
            _.Move(PESSOA.DCLPESSOA.PESSOA_COD_PESSOA, PESJUR.DCLPESSOA_JURIDICA.COD_PESSOA);

            /*" -1968- MOVE R1-CGC-CPF OF REG-CLIENTES TO CGC OF DCLPESSOA-JURIDICA */
            _.Move(LBFPF011.REG_CLIENTES.R1_CGC_CPF, PESJUR.DCLPESSOA_JURIDICA.CGC);

            /*" -1971- MOVE R1-NOME-PESSOA OF REG-CLIENTES TO NOME-FANTASIA OF DCLPESSOA-JURIDICA */
            _.Move(LBFPF011.REG_CLIENTES.R1_NOME_PESSOA, PESJUR.DCLPESSOA_JURIDICA.NOME_FANTASIA);

            /*" -1974- MOVE 'PF0103B' TO COD-USUARIO OF DCLPESSOA-JURIDICA */
            _.Move("PF0103B", PESJUR.DCLPESSOA_JURIDICA.COD_USUARIO);

            /*" -1981- PERFORM R0530_INCLUIR_PESSOA_JURIDICA_DB_INSERT_1 */

            R0530_INCLUIR_PESSOA_JURIDICA_DB_INSERT_1();

            /*" -1984- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -1985- DISPLAY 'PF0103B - FIM ANORMAL' */
                _.Display($"PF0103B - FIM ANORMAL");

                /*" -1986- DISPLAY '          ERRO INSERT DA TABELA PESSOA JURIDICA' */
                _.Display($"          ERRO INSERT DA TABELA PESSOA JURIDICA");

                /*" -1988- DISPLAY '          CODIGO PESSOA.................  ' COD-PESSOA OF DCLPESSOA-JURIDICA */
                _.Display($"          CODIGO PESSOA.................  {PESJUR.DCLPESSOA_JURIDICA.COD_PESSOA}");

                /*" -1990- DISPLAY '          NUMERO PROPOSTA...............  ' R1-NUM-PROPOSTA OF REG-CLIENTES */
                _.Display($"          NUMERO PROPOSTA...............  {LBFPF011.REG_CLIENTES.R1_NUM_PROPOSTA}");

                /*" -1992- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -1993- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -1993- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R0530-INCLUIR-PESSOA-JURIDICA-DB-INSERT-1 */
        public void R0530_INCLUIR_PESSOA_JURIDICA_DB_INSERT_1()
        {
            /*" -1981- EXEC SQL INSERT INTO SEGUROS.PESSOA_JURIDICA VALUES (:DCLPESSOA-JURIDICA.COD-PESSOA, :DCLPESSOA-JURIDICA.CGC, :DCLPESSOA-JURIDICA.NOME-FANTASIA, :DCLPESSOA-JURIDICA.COD-USUARIO, CURRENT TIMESTAMP) END-EXEC. */

            var r0530_INCLUIR_PESSOA_JURIDICA_DB_INSERT_1_Insert1 = new R0530_INCLUIR_PESSOA_JURIDICA_DB_INSERT_1_Insert1()
            {
                COD_PESSOA = PESJUR.DCLPESSOA_JURIDICA.COD_PESSOA.ToString(),
                CGC = PESJUR.DCLPESSOA_JURIDICA.CGC.ToString(),
                NOME_FANTASIA = PESJUR.DCLPESSOA_JURIDICA.NOME_FANTASIA.ToString(),
                COD_USUARIO = PESJUR.DCLPESSOA_JURIDICA.COD_USUARIO.ToString(),
            };

            R0530_INCLUIR_PESSOA_JURIDICA_DB_INSERT_1_Insert1.Execute(r0530_INCLUIR_PESSOA_JURIDICA_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0530_SAIDA*/

        [StopWatch]
        /*" R0536-RELACIONA-EMAIL-SECTION */
        private void R0536_RELACIONA_EMAIL_SECTION()
        {
            /*" -2003- MOVE 'R0536-RELACIONA-EMAIL' TO PARAGRAFO. */
            _.Move("R0536-RELACIONA-EMAIL", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2005- MOVE 'DECLARE PESSOA-EMAIL' TO COMANDO. */
            _.Move("DECLARE PESSOA-EMAIL", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2008- MOVE PESSOA-COD-PESSOA OF DCLPESSOA TO COD-PESSOA OF DCLPESSOA-EMAIL. */
            _.Move(PESSOA.DCLPESSOA.PESSOA_COD_PESSOA, PESEMAIL.DCLPESSOA_EMAIL.COD_PESSOA);

            /*" -2018- PERFORM R0536_RELACIONA_EMAIL_DB_DECLARE_1 */

            R0536_RELACIONA_EMAIL_DB_DECLARE_1();

            /*" -2022- IF SQLCODE NOT EQUAL 00 AND SQLCODE NOT EQUAL 100 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != 100)
            {

                /*" -2023- DISPLAY 'PF0103B - FIM ANORMAL' */
                _.Display($"PF0103B - FIM ANORMAL");

                /*" -2024- DISPLAY '          ERRO DECLARE DA TABELA PESSOA EMAIL' */
                _.Display($"          ERRO DECLARE DA TABELA PESSOA EMAIL");

                /*" -2026- DISPLAY '          CODIGO PESSOA.................  ' COD-PESSOA OF DCLPESSOA-EMAIL */
                _.Display($"          CODIGO PESSOA.................  {PESEMAIL.DCLPESSOA_EMAIL.COD_PESSOA}");

                /*" -2028- DISPLAY '          NUMERO PROPOSTA...............  ' R1-NUM-PROPOSTA OF REG-CLIENTES */
                _.Display($"          NUMERO PROPOSTA...............  {LBFPF011.REG_CLIENTES.R1_NUM_PROPOSTA}");

                /*" -2030- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -2031- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -2031- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R0536-RELACIONA-EMAIL-DB-DECLARE-1 */
        public void R0536_RELACIONA_EMAIL_DB_DECLARE_1()
        {
            /*" -2018- EXEC SQL DECLARE EMAIL CURSOR FOR SELECT COD_PESSOA, SEQ_EMAIL, EMAIL, SITUACAO_EMAIL FROM SEGUROS.PESSOA_EMAIL WHERE COD_PESSOA = :DCLPESSOA-EMAIL.COD-PESSOA ORDER BY SEQ_EMAIL WITH UR END-EXEC. */
            EMAIL = new PF0103B_EMAIL(true);
            string GetQuery_EMAIL()
            {
                var query = @$"SELECT COD_PESSOA
							, 
							SEQ_EMAIL
							, 
							EMAIL
							, 
							SITUACAO_EMAIL 
							FROM SEGUROS.PESSOA_EMAIL 
							WHERE COD_PESSOA = '{PESEMAIL.DCLPESSOA_EMAIL.COD_PESSOA}' 
							ORDER BY SEQ_EMAIL";

                return query;
            }
            EMAIL.GetQueryEvent += GetQuery_EMAIL;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0536_SAIDA*/

        [StopWatch]
        /*" R0535-INCLUIR-END-EMAIL-SECTION */
        private void R0535_INCLUIR_END_EMAIL_SECTION()
        {
            /*" -2040- MOVE 'R0535-INCLUIR-END-EMAIL' TO PARAGRAFO. */
            _.Move("R0535-INCLUIR-END-EMAIL", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2042- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2044- PERFORM R0536-RELACIONA-EMAIL. */

            R0536_RELACIONA_EMAIL_SECTION();

            /*" -2046- MOVE 'OPEN CURSOR EMAIL' TO COMANDO. */
            _.Move("OPEN CURSOR EMAIL", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2046- PERFORM R0535_INCLUIR_END_EMAIL_DB_OPEN_1 */

            R0535_INCLUIR_END_EMAIL_DB_OPEN_1();

            /*" -2050- MOVE 'NAO' TO W-ACHOU-EMAIL. */
            _.Move("NAO", WAREA_AUXILIAR.W_ACHOU_EMAIL);

            /*" -2052- MOVE SPACES TO W-FIM-CURSOR-EMAIL. */
            _.Move("", WAREA_AUXILIAR.W_FIM_CURSOR_EMAIL);

            /*" -2054- PERFORM R0537-FETCH-EMAIL */

            R0537_FETCH_EMAIL_SECTION();

            /*" -2055- IF W-FIM-CURSOR-EMAIL EQUAL 'SIM' */

            if (WAREA_AUXILIAR.W_FIM_CURSOR_EMAIL == "SIM")
            {

                /*" -2056- IF R1-EMAIL OF REG-CLIENTES EQUAL SPACES */

                if (LBFPF011.REG_CLIENTES.R1_EMAIL.IsEmpty())
                {

                    /*" -2058- MOVE 'SIM' TO W-ACHOU-EMAIL. */
                    _.Move("SIM", WAREA_AUXILIAR.W_ACHOU_EMAIL);
                }

            }


            /*" -2061- PERFORM R0538-VERIFICA-EXISTE-EMAIL UNTIL W-FIM-CURSOR-EMAIL EQUAL 'SIM' . */

            while (!(WAREA_AUXILIAR.W_FIM_CURSOR_EMAIL == "SIM"))
            {

                R0538_VERIFICA_EXISTE_EMAIL_SECTION();
            }

            /*" -2062- IF W-ACHOU-EMAIL EQUAL 'NAO' */

            if (WAREA_AUXILIAR.W_ACHOU_EMAIL == "NAO")
            {

                /*" -2062- PERFORM R0539-INCLUIR-NOVO-EMAIL. */

                R0539_INCLUIR_NOVO_EMAIL_SECTION();
            }


        }

        [StopWatch]
        /*" R0535-INCLUIR-END-EMAIL-DB-OPEN-1 */
        public void R0535_INCLUIR_END_EMAIL_DB_OPEN_1()
        {
            /*" -2046- EXEC SQL OPEN EMAIL END-EXEC. */

            EMAIL.Open();

        }

        [StopWatch]
        /*" R0605A-RELACIONA-ENDERECO-DB-DECLARE-1 */
        public void R0605A_RELACIONA_ENDERECO_DB_DECLARE_1()
        {
            /*" -2500- EXEC SQL DECLARE ENDERECOS CURSOR FOR SELECT OCORR_ENDERECO, COD_PESSOA, ENDERECO, TIPO_ENDER, BAIRRO, CEP, CIDADE, SIGLA_UF, SITUACAO_ENDERECO FROM SEGUROS.PESSOA_ENDERECO WHERE COD_PESSOA = :DCLPESSOA-ENDERECO.COD-PESSOA ORDER BY OCORR_ENDERECO WITH UR END-EXEC. */
            ENDERECOS = new PF0103B_ENDERECOS(true);
            string GetQuery_ENDERECOS()
            {
                var query = @$"SELECT OCORR_ENDERECO
							, 
							COD_PESSOA
							, 
							ENDERECO
							, 
							TIPO_ENDER
							, 
							BAIRRO
							, 
							CEP
							, 
							CIDADE
							, 
							SIGLA_UF
							, 
							SITUACAO_ENDERECO 
							FROM SEGUROS.PESSOA_ENDERECO 
							WHERE COD_PESSOA = '{PESENDER.DCLPESSOA_ENDERECO.COD_PESSOA}' 
							ORDER BY OCORR_ENDERECO";

                return query;
            }
            ENDERECOS.GetQueryEvent += GetQuery_ENDERECOS;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0535_SAIDA*/

        [StopWatch]
        /*" R0537-FETCH-EMAIL-SECTION */
        private void R0537_FETCH_EMAIL_SECTION()
        {
            /*" -2073- MOVE 'R0537-FETCH-EMAIL' TO PARAGRAFO. */
            _.Move("R0537-FETCH-EMAIL", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2075- MOVE 'FETCH CURSOR EMAIL' TO COMANDO. */
            _.Move("FETCH CURSOR EMAIL", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2081- PERFORM R0537_FETCH_EMAIL_DB_FETCH_1 */

            R0537_FETCH_EMAIL_DB_FETCH_1();

            /*" -2084- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -2085- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2086- MOVE 'SIM' TO W-FIM-CURSOR-EMAIL */
                    _.Move("SIM", WAREA_AUXILIAR.W_FIM_CURSOR_EMAIL);

                    /*" -2086- PERFORM R0537_FETCH_EMAIL_DB_CLOSE_1 */

                    R0537_FETCH_EMAIL_DB_CLOSE_1();

                    /*" -2088- ELSE */
                }
                else
                {


                    /*" -2089- DISPLAY 'PF0103B - FIM ANORMAL' */
                    _.Display($"PF0103B - FIM ANORMAL");

                    /*" -2090- DISPLAY '          ERRO FETCH CURSOR EMAIL' */
                    _.Display($"          ERRO FETCH CURSOR EMAIL");

                    /*" -2092- DISPLAY '          CODIGO PESSOA.................  ' COD-PESSOA OF DCLPESSOA-EMAIL */
                    _.Display($"          CODIGO PESSOA.................  {PESEMAIL.DCLPESSOA_EMAIL.COD_PESSOA}");

                    /*" -2094- DISPLAY '          NUMERO PROPOSTA...............  ' R1-NUM-PROPOSTA OF REG-CLIENTES */
                    _.Display($"          NUMERO PROPOSTA...............  {LBFPF011.REG_CLIENTES.R1_NUM_PROPOSTA}");

                    /*" -2096- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                    _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                    /*" -2097- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -2097- PERFORM R9999-00-FINALIZAR. */

                    R9999_00_FINALIZAR_SECTION();
                }

            }


        }

        [StopWatch]
        /*" R0537-FETCH-EMAIL-DB-FETCH-1 */
        public void R0537_FETCH_EMAIL_DB_FETCH_1()
        {
            /*" -2081- EXEC SQL FETCH EMAIL INTO :DCLPESSOA-EMAIL.COD-PESSOA, :DCLPESSOA-EMAIL.SEQ-EMAIL, :DCLPESSOA-EMAIL.EMAIL, :DCLPESSOA-EMAIL.SITUACAO-EMAIL END-EXEC. */

            if (EMAIL.Fetch())
            {
                _.Move(EMAIL.DCLPESSOA_EMAIL_COD_PESSOA, PESEMAIL.DCLPESSOA_EMAIL.COD_PESSOA);
                _.Move(EMAIL.DCLPESSOA_EMAIL_SEQ_EMAIL, PESEMAIL.DCLPESSOA_EMAIL.SEQ_EMAIL);
                _.Move(EMAIL.DCLPESSOA_EMAIL_EMAIL, PESEMAIL.DCLPESSOA_EMAIL.EMAIL);
                _.Move(EMAIL.DCLPESSOA_EMAIL_SITUACAO_EMAIL, PESEMAIL.DCLPESSOA_EMAIL.SITUACAO_EMAIL);
            }

        }

        [StopWatch]
        /*" R0537-FETCH-EMAIL-DB-CLOSE-1 */
        public void R0537_FETCH_EMAIL_DB_CLOSE_1()
        {
            /*" -2086- EXEC SQL CLOSE EMAIL END-EXEC */

            EMAIL.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0537_SAIDA*/

        [StopWatch]
        /*" R0538-VERIFICA-EXISTE-EMAIL-SECTION */
        private void R0538_VERIFICA_EXISTE_EMAIL_SECTION()
        {
            /*" -2107- MOVE 'R0538-VERIFICA-EXISTE-EMAIL' TO PARAGRAFO. */
            _.Move("R0538-VERIFICA-EXISTE-EMAIL", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2109- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2111- IF R1-EMAIL OF REG-CLIENTES EQUAL EMAIL OF DCLPESSOA-EMAIL */

            if (LBFPF011.REG_CLIENTES.R1_EMAIL == PESEMAIL.DCLPESSOA_EMAIL.EMAIL)
            {

                /*" -2113- MOVE 'SIM' TO W-ACHOU-EMAIL. */
                _.Move("SIM", WAREA_AUXILIAR.W_ACHOU_EMAIL);
            }


            /*" -2114- IF R1-EMAIL OF REG-CLIENTES EQUAL SPACES */

            if (LBFPF011.REG_CLIENTES.R1_EMAIL.IsEmpty())
            {

                /*" -2116- MOVE 'SIM' TO W-ACHOU-EMAIL. */
                _.Move("SIM", WAREA_AUXILIAR.W_ACHOU_EMAIL);
            }


            /*" -2116- PERFORM R0537-FETCH-EMAIL. */

            R0537_FETCH_EMAIL_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0538_SAIDA*/

        [StopWatch]
        /*" R0539-INCLUIR-NOVO-EMAIL-SECTION */
        private void R0539_INCLUIR_NOVO_EMAIL_SECTION()
        {
            /*" -2126- MOVE 'R0539-INCLUIR-NOVO-EMAIL' TO PARAGRAFO. */
            _.Move("R0539-INCLUIR-NOVO-EMAIL", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2135- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2138- MOVE SEQ-EMAIL OF DCLPESSOA-EMAIL TO W-SEQ-EMAIL */
            _.Move(PESEMAIL.DCLPESSOA_EMAIL.SEQ_EMAIL, WAREA_AUXILIAR.W_SEQ_EMAIL);

            /*" -2140- COMPUTE W-SEQ-EMAIL = W-SEQ-EMAIL + 1. */
            WAREA_AUXILIAR.W_SEQ_EMAIL.Value = WAREA_AUXILIAR.W_SEQ_EMAIL + 1;

            /*" -2140- PERFORM R0541-INCLUIR-EMAIL. */

            R0541_INCLUIR_EMAIL_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0539_SAIDA*/

        [StopWatch]
        /*" R0540-OBTER-MAX-EMAIL-SECTION */
        private void R0540_OBTER_MAX_EMAIL_SECTION()
        {
            /*" -2150- MOVE 'R0540-OBTER-MAX-EMAIL' TO PARAGRAFO. */
            _.Move("R0540-OBTER-MAX-EMAIL", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2152- MOVE 'MAX SEGUROS.PESSOA_EMAIL' TO COMANDO. */
            _.Move("MAX SEGUROS.PESSOA_EMAIL", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2155- MOVE PESSOA-COD-PESSOA OF DCLPESSOA TO COD-PESSOA OF DCLPESSOA-EMAIL. */
            _.Move(PESSOA.DCLPESSOA.PESSOA_COD_PESSOA, PESEMAIL.DCLPESSOA_EMAIL.COD_PESSOA);

            /*" -2161- PERFORM R0540_OBTER_MAX_EMAIL_DB_SELECT_1 */

            R0540_OBTER_MAX_EMAIL_DB_SELECT_1();

            /*" -2164- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -2165- DISPLAY 'PF0103B - FIM ANORMAL' */
                _.Display($"PF0103B - FIM ANORMAL");

                /*" -2166- DISPLAY '          ERRO NO SELECT MAX TAB. PESSOA-EMAIL' */
                _.Display($"          ERRO NO SELECT MAX TAB. PESSOA-EMAIL");

                /*" -2168- DISPLAY '          NUMERO DA PROPOSTA............  ' R1-NUM-PROPOSTA OF REG-CLIENTES */
                _.Display($"          NUMERO DA PROPOSTA............  {LBFPF011.REG_CLIENTES.R1_NUM_PROPOSTA}");

                /*" -2170- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -2171- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -2171- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R0540-OBTER-MAX-EMAIL-DB-SELECT-1 */
        public void R0540_OBTER_MAX_EMAIL_DB_SELECT_1()
        {
            /*" -2161- EXEC SQL SELECT VALUE(MAX(SEQ_EMAIL),0) INTO :DCLPESSOA-EMAIL.SEQ-EMAIL FROM SEGUROS.PESSOA_EMAIL WHERE COD_PESSOA = :DCLPESSOA-EMAIL.COD-PESSOA WITH UR END-EXEC. */

            var r0540_OBTER_MAX_EMAIL_DB_SELECT_1_Query1 = new R0540_OBTER_MAX_EMAIL_DB_SELECT_1_Query1()
            {
                COD_PESSOA = PESEMAIL.DCLPESSOA_EMAIL.COD_PESSOA.ToString(),
            };

            var executed_1 = R0540_OBTER_MAX_EMAIL_DB_SELECT_1_Query1.Execute(r0540_OBTER_MAX_EMAIL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SEQ_EMAIL, PESEMAIL.DCLPESSOA_EMAIL.SEQ_EMAIL);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0540_SAIDA*/

        [StopWatch]
        /*" R0541-INCLUIR-EMAIL-SECTION */
        private void R0541_INCLUIR_EMAIL_SECTION()
        {
            /*" -2180- MOVE 'R0541-INCLUI-EMAIL' TO PARAGRAFO. */
            _.Move("R0541-INCLUI-EMAIL", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2182- MOVE 'MAX SEGUROS.PESSOA_EMAIL' TO COMANDO. */
            _.Move("MAX SEGUROS.PESSOA_EMAIL", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2185- MOVE PESSOA-COD-PESSOA OF DCLPESSOA TO COD-PESSOA OF DCLPESSOA-EMAIL */
            _.Move(PESSOA.DCLPESSOA.PESSOA_COD_PESSOA, PESEMAIL.DCLPESSOA_EMAIL.COD_PESSOA);

            /*" -2188- MOVE W-SEQ-EMAIL TO SEQ-EMAIL OF DCLPESSOA-EMAIL. */
            _.Move(WAREA_AUXILIAR.W_SEQ_EMAIL, PESEMAIL.DCLPESSOA_EMAIL.SEQ_EMAIL);

            /*" -2191- MOVE R1-EMAIL OF REG-CLIENTES TO EMAIL OF DCLPESSOA-EMAIL */
            _.Move(LBFPF011.REG_CLIENTES.R1_EMAIL, PESEMAIL.DCLPESSOA_EMAIL.EMAIL);

            /*" -2194- MOVE 'A' TO SITUACAO-EMAIL OF DCLPESSOA-EMAIL */
            _.Move("A", PESEMAIL.DCLPESSOA_EMAIL.SITUACAO_EMAIL);

            /*" -2197- MOVE 'PF0103B' TO COD-USUARIO OF DCLPESSOA-EMAIL. */
            _.Move("PF0103B", PESEMAIL.DCLPESSOA_EMAIL.COD_USUARIO);

            /*" -2205- PERFORM R0541_INCLUIR_EMAIL_DB_INSERT_1 */

            R0541_INCLUIR_EMAIL_DB_INSERT_1();

            /*" -2208- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -2209- DISPLAY 'PF0103B - FIM ANORMAL' */
                _.Display($"PF0103B - FIM ANORMAL");

                /*" -2210- DISPLAY '          ERRO INSERT DA TABELA PESSOA-EMAIL' */
                _.Display($"          ERRO INSERT DA TABELA PESSOA-EMAIL");

                /*" -2212- DISPLAY '          CODIGO PESSOA.................  ' PESSOA-COD-PESSOA OF DCLPESSOA */
                _.Display($"          CODIGO PESSOA.................  {PESSOA.DCLPESSOA.PESSOA_COD_PESSOA}");

                /*" -2214- DISPLAY '          NOME DA PESSOA................  ' PESSOA-NOME-PESSOA OF DCLPESSOA */
                _.Display($"          NOME DA PESSOA................  {PESSOA.DCLPESSOA.PESSOA_NOME_PESSOA}");

                /*" -2216- DISPLAY '          NUMERO PROPOSTA...............  ' R1-NUM-PROPOSTA OF REG-CLIENTES */
                _.Display($"          NUMERO PROPOSTA...............  {LBFPF011.REG_CLIENTES.R1_NUM_PROPOSTA}");

                /*" -2218- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -2219- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -2219- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R0541-INCLUIR-EMAIL-DB-INSERT-1 */
        public void R0541_INCLUIR_EMAIL_DB_INSERT_1()
        {
            /*" -2205- EXEC SQL INSERT INTO SEGUROS.PESSOA_EMAIL VALUES (:DCLPESSOA-EMAIL.COD-PESSOA, :DCLPESSOA-EMAIL.SEQ-EMAIL, :DCLPESSOA-EMAIL.EMAIL, :DCLPESSOA-EMAIL.SITUACAO-EMAIL, :DCLPESSOA-EMAIL.COD-USUARIO, CURRENT TIMESTAMP) END-EXEC. */

            var r0541_INCLUIR_EMAIL_DB_INSERT_1_Insert1 = new R0541_INCLUIR_EMAIL_DB_INSERT_1_Insert1()
            {
                COD_PESSOA = PESEMAIL.DCLPESSOA_EMAIL.COD_PESSOA.ToString(),
                SEQ_EMAIL = PESEMAIL.DCLPESSOA_EMAIL.SEQ_EMAIL.ToString(),
                EMAIL = PESEMAIL.DCLPESSOA_EMAIL.EMAIL.ToString(),
                SITUACAO_EMAIL = PESEMAIL.DCLPESSOA_EMAIL.SITUACAO_EMAIL.ToString(),
                COD_USUARIO = PESEMAIL.DCLPESSOA_EMAIL.COD_USUARIO.ToString(),
            };

            R0541_INCLUIR_EMAIL_DB_INSERT_1_Insert1.Execute(r0541_INCLUIR_EMAIL_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0541_SAIDA*/

        [StopWatch]
        /*" R0550-LER-TAB-CORPORATIVAS-SECTION */
        private void R0550_LER_TAB_CORPORATIVAS_SECTION()
        {
            /*" -2229- MOVE 'R0550-LER-TAB-CORPORATIVAS' TO PARAGRAFO. */
            _.Move("R0550-LER-TAB-CORPORATIVAS", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2231- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2232- IF R1-TIPO-PESSOA OF REG-CLIENTES EQUAL 1 */

            if (LBFPF011.REG_CLIENTES.R1_TIPO_PESSOA == 1)
            {

                /*" -2234- MOVE COD-PESSOA OF DCLPESSOA-FISICA TO PESSOA-COD-PESSOA OF DCLPESSOA */
                _.Move(PESFIS.DCLPESSOA_FISICA.COD_PESSOA, PESSOA.DCLPESSOA.PESSOA_COD_PESSOA);

                /*" -2235- ELSE */
            }
            else
            {


                /*" -2238- MOVE COD-PESSOA OF DCLPESSOA-JURIDICA TO PESSOA-COD-PESSOA OF DCLPESSOA. */
                _.Move(PESJUR.DCLPESSOA_JURIDICA.COD_PESSOA, PESSOA.DCLPESSOA.PESSOA_COD_PESSOA);
            }


            /*" -2240- PERFORM R0555-LER-TAB-PESSOA. */

            R0555_LER_TAB_PESSOA_SECTION();

            /*" -2240- PERFORM R0560-LER-TAB-EMAIL. */

            R0560_LER_TAB_EMAIL_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0550_SAIDA*/

        [StopWatch]
        /*" R0555-LER-TAB-PESSOA-SECTION */
        private void R0555_LER_TAB_PESSOA_SECTION()
        {
            /*" -2250- MOVE 'R0550-LER-TAB-PESSOAS' TO PARAGRAFO. */
            _.Move("R0550-LER-TAB-PESSOAS", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2252- MOVE 'SELECT SEGUROS.PESSOAS' TO COMANDO. */
            _.Move("SELECT SEGUROS.PESSOAS", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2266- PERFORM R0555_LER_TAB_PESSOA_DB_SELECT_1 */

            R0555_LER_TAB_PESSOA_DB_SELECT_1();

            /*" -2269- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -2270- DISPLAY 'PF0103B - FIM ANORMAL' */
                _.Display($"PF0103B - FIM ANORMAL");

                /*" -2271- DISPLAY '          ERRO ACESSO TAB. SEGUROS.PESSOA' */
                _.Display($"          ERRO ACESSO TAB. SEGUROS.PESSOA");

                /*" -2273- DISPLAY '          CODIGO PESSOA.................  ' PESSOA-COD-PESSOA OF DCLPESSOA */
                _.Display($"          CODIGO PESSOA.................  {PESSOA.DCLPESSOA.PESSOA_COD_PESSOA}");

                /*" -2275- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -2276- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -2276- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R0555-LER-TAB-PESSOA-DB-SELECT-1 */
        public void R0555_LER_TAB_PESSOA_DB_SELECT_1()
        {
            /*" -2266- EXEC SQL SELECT COD_PESSOA, NOME_PESSOA, TIPO_PESSOA, TIMESTAMP, COD_USUARIO INTO :DCLPESSOA.PESSOA-COD-PESSOA, :DCLPESSOA.PESSOA-NOME-PESSOA, :DCLPESSOA.PESSOA-TIPO-PESSOA, :DCLPESSOA.PESSOA-TIMESTAMP, :DCLPESSOA.PESSOA-COD-USUARIO FROM SEGUROS.PESSOA WHERE COD_PESSOA = :DCLPESSOA.PESSOA-COD-PESSOA WITH UR END-EXEC. */

            var r0555_LER_TAB_PESSOA_DB_SELECT_1_Query1 = new R0555_LER_TAB_PESSOA_DB_SELECT_1_Query1()
            {
                PESSOA_COD_PESSOA = PESSOA.DCLPESSOA.PESSOA_COD_PESSOA.ToString(),
            };

            var executed_1 = R0555_LER_TAB_PESSOA_DB_SELECT_1_Query1.Execute(r0555_LER_TAB_PESSOA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PESSOA_COD_PESSOA, PESSOA.DCLPESSOA.PESSOA_COD_PESSOA);
                _.Move(executed_1.PESSOA_NOME_PESSOA, PESSOA.DCLPESSOA.PESSOA_NOME_PESSOA);
                _.Move(executed_1.PESSOA_TIPO_PESSOA, PESSOA.DCLPESSOA.PESSOA_TIPO_PESSOA);
                _.Move(executed_1.PESSOA_TIMESTAMP, PESSOA.DCLPESSOA.PESSOA_TIMESTAMP);
                _.Move(executed_1.PESSOA_COD_USUARIO, PESSOA.DCLPESSOA.PESSOA_COD_USUARIO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0555_SAIDA*/

        [StopWatch]
        /*" R0560-LER-TAB-EMAIL-SECTION */
        private void R0560_LER_TAB_EMAIL_SECTION()
        {
            /*" -2285- MOVE 'R0560-LER-TAB-EMAIL' TO PARAGRAFO. */
            _.Move("R0560-LER-TAB-EMAIL", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2287- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2289- PERFORM R0565-OBTER-MAX-EMAIL. */

            R0565_OBTER_MAX_EMAIL_SECTION();

            /*" -2289- PERFORM R0570-LER-EMAIL-ATUAL. */

            R0570_LER_EMAIL_ATUAL_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0560_SAIDA*/

        [StopWatch]
        /*" R0565-OBTER-MAX-EMAIL-SECTION */
        private void R0565_OBTER_MAX_EMAIL_SECTION()
        {
            /*" -2299- MOVE 'R0565-OBTER-MAX-EMAIL' TO PARAGRAFO. */
            _.Move("R0565-OBTER-MAX-EMAIL", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2301- MOVE 'MAX SEGUROS.PESSOA_EMAIL' TO COMANDO. */
            _.Move("MAX SEGUROS.PESSOA_EMAIL", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2304- MOVE PESSOA-COD-PESSOA OF DCLPESSOA TO COD-PESSOA OF DCLPESSOA-EMAIL. */
            _.Move(PESSOA.DCLPESSOA.PESSOA_COD_PESSOA, PESEMAIL.DCLPESSOA_EMAIL.COD_PESSOA);

            /*" -2310- PERFORM R0565_OBTER_MAX_EMAIL_DB_SELECT_1 */

            R0565_OBTER_MAX_EMAIL_DB_SELECT_1();

            /*" -2313- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -2314- DISPLAY 'PF0103B - FIM ANORMAL' */
                _.Display($"PF0103B - FIM ANORMAL");

                /*" -2315- DISPLAY '          ERRO SELECT MAX TAB. PESSOA-EMAIL' */
                _.Display($"          ERRO SELECT MAX TAB. PESSOA-EMAIL");

                /*" -2317- DISPLAY '          CODIGO PESSOA.................  ' COD-PESSOA OF DCLPESSOA-EMAIL */
                _.Display($"          CODIGO PESSOA.................  {PESEMAIL.DCLPESSOA_EMAIL.COD_PESSOA}");

                /*" -2319- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -2320- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -2320- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R0565-OBTER-MAX-EMAIL-DB-SELECT-1 */
        public void R0565_OBTER_MAX_EMAIL_DB_SELECT_1()
        {
            /*" -2310- EXEC SQL SELECT VALUE(MAX(SEQ_EMAIL),0) INTO :DCLPESSOA-EMAIL.SEQ-EMAIL FROM SEGUROS.PESSOA_EMAIL WHERE COD_PESSOA = :DCLPESSOA-EMAIL.COD-PESSOA WITH UR END-EXEC. */

            var r0565_OBTER_MAX_EMAIL_DB_SELECT_1_Query1 = new R0565_OBTER_MAX_EMAIL_DB_SELECT_1_Query1()
            {
                COD_PESSOA = PESEMAIL.DCLPESSOA_EMAIL.COD_PESSOA.ToString(),
            };

            var executed_1 = R0565_OBTER_MAX_EMAIL_DB_SELECT_1_Query1.Execute(r0565_OBTER_MAX_EMAIL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SEQ_EMAIL, PESEMAIL.DCLPESSOA_EMAIL.SEQ_EMAIL);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0565_SAIDA*/

        [StopWatch]
        /*" R0570-LER-EMAIL-ATUAL-SECTION */
        private void R0570_LER_EMAIL_ATUAL_SECTION()
        {
            /*" -2330- MOVE 'R0570-LER-EMAIL-ATUAL' TO PARAGRAFO. */
            _.Move("R0570-LER-EMAIL-ATUAL", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2332- MOVE 'SELECT SEGUROS.PESSOA_EMAIL' TO COMANDO. */
            _.Move("SELECT SEGUROS.PESSOA_EMAIL", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2335- MOVE PESSOA-COD-PESSOA OF DCLPESSOA TO COD-PESSOA OF DCLPESSOA-EMAIL. */
            _.Move(PESSOA.DCLPESSOA.PESSOA_COD_PESSOA, PESEMAIL.DCLPESSOA_EMAIL.COD_PESSOA);

            /*" -2352- PERFORM R0570_LER_EMAIL_ATUAL_DB_SELECT_1 */

            R0570_LER_EMAIL_ATUAL_DB_SELECT_1();

            /*" -2356- IF SQLCODE NOT EQUAL 00 AND SQLCODE NOT EQUAL 100 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != 100)
            {

                /*" -2357- DISPLAY 'PF0103B - FIM ANORMAL' */
                _.Display($"PF0103B - FIM ANORMAL");

                /*" -2358- DISPLAY '          ERRO SELECT TAB. PESSOA-EMAIL' */
                _.Display($"          ERRO SELECT TAB. PESSOA-EMAIL");

                /*" -2360- DISPLAY '          CODIGO PESSOA.................  ' COD-PESSOA OF DCLPESSOA-EMAIL */
                _.Display($"          CODIGO PESSOA.................  {PESEMAIL.DCLPESSOA_EMAIL.COD_PESSOA}");

                /*" -2362- DISPLAY '          SEQUENCIAEMAIL................  ' SEQ-EMAIL OF DCLPESSOA-EMAIL */
                _.Display($"          SEQUENCIAEMAIL................  {PESEMAIL.DCLPESSOA_EMAIL.SEQ_EMAIL}");

                /*" -2364- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -2365- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -2365- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R0570-LER-EMAIL-ATUAL-DB-SELECT-1 */
        public void R0570_LER_EMAIL_ATUAL_DB_SELECT_1()
        {
            /*" -2352- EXEC SQL SELECT COD_PESSOA, SEQ_EMAIL, EMAIL, SITUACAO_EMAIL, COD_USUARIO, TIMESTAMP INTO :DCLPESSOA-EMAIL.COD-PESSOA, :DCLPESSOA-EMAIL.SEQ-EMAIL, :DCLPESSOA-EMAIL.EMAIL, :DCLPESSOA-EMAIL.SITUACAO-EMAIL, :DCLPESSOA-EMAIL.COD-USUARIO, :DCLPESSOA-EMAIL.TIMESTAMP FROM SEGUROS.PESSOA_EMAIL WHERE COD_PESSOA = :DCLPESSOA-EMAIL.COD-PESSOA AND SEQ_EMAIL = :DCLPESSOA-EMAIL.SEQ-EMAIL WITH UR END-EXEC. */

            var r0570_LER_EMAIL_ATUAL_DB_SELECT_1_Query1 = new R0570_LER_EMAIL_ATUAL_DB_SELECT_1_Query1()
            {
                COD_PESSOA = PESEMAIL.DCLPESSOA_EMAIL.COD_PESSOA.ToString(),
                SEQ_EMAIL = PESEMAIL.DCLPESSOA_EMAIL.SEQ_EMAIL.ToString(),
            };

            var executed_1 = R0570_LER_EMAIL_ATUAL_DB_SELECT_1_Query1.Execute(r0570_LER_EMAIL_ATUAL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.COD_PESSOA, PESEMAIL.DCLPESSOA_EMAIL.COD_PESSOA);
                _.Move(executed_1.SEQ_EMAIL, PESEMAIL.DCLPESSOA_EMAIL.SEQ_EMAIL);
                _.Move(executed_1.EMAIL, PESEMAIL.DCLPESSOA_EMAIL.EMAIL);
                _.Move(executed_1.SITUACAO_EMAIL, PESEMAIL.DCLPESSOA_EMAIL.SITUACAO_EMAIL);
                _.Move(executed_1.COD_USUARIO, PESEMAIL.DCLPESSOA_EMAIL.COD_USUARIO);
                _.Move(executed_1.TIMESTAMP, PESEMAIL.DCLPESSOA_EMAIL.TIMESTAMP);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0570_SAIDA*/

        [StopWatch]
        /*" R0600-TRATA-END-TEL-SECTION */
        private void R0600_TRATA_END_TEL_SECTION()
        {
            /*" -2375- MOVE 'R0600-TRATA-END-TEL' TO PARAGRAFO. */
            _.Move("R0600-TRATA-END-TEL", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2377- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2381- PERFORM R0601-TRATA-ENDERECO VARYING W-IND-ENDER FROM 1 BY 1 UNTIL W-IND-ENDER GREATER W-IND-ENDER-N. */

            for (WAREA_AUXILIAR.W_IND_ENDER.Value = 1; !(WAREA_AUXILIAR.W_IND_ENDER > WAREA_AUXILIAR.W_IND_ENDER_N); WAREA_AUXILIAR.W_IND_ENDER.Value += 1)
            {

                R0601_TRATA_ENDERECO_SECTION();
            }

            /*" -2383- MOVE ZEROS TO W-INDEX. */
            _.Move(0, WAREA_AUXILIAR.W_INDEX);

            /*" -2383- PERFORM R0650-TRATA-TELEFONES 3 TIMES. */

            for (int i = 0; i < 3; i++)
            {

                R0650_TRATA_TELEFONES_SECTION();

            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0600_SAIDA*/

        [StopWatch]
        /*" R0601-TRATA-ENDERECO-SECTION */
        private void R0601_TRATA_ENDERECO_SECTION()
        {
            /*" -2396- MOVE ZEROS TO OCORR-ENDERECO OF DCLPESSOA-ENDERECO, W-OCORR-ENDERECO. */
            _.Move(0, PESENDER.DCLPESSOA_ENDERECO.OCORR_ENDERECO, WAREA_AUXILIAR.W_OCORR_ENDERECO);

            /*" -2398- PERFORM R0605-TAB-ENDERECO-NOVOS. */

            R0605_TAB_ENDERECO_NOVOS_SECTION();

            /*" -2399- MOVE 'R0601-TRATA-ENDERECO' TO PARAGRAFO. */
            _.Move("R0601-TRATA-ENDERECO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2401- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2403- MOVE W-TB-REG-ENDERECOS-N(W-IND-ENDER) TO REG-ENDERECO */
            _.Move(WAREA_AUXILIAR.W_TB_ENDERECOS_N.W_TAB_END_REG_N[WAREA_AUXILIAR.W_IND_ENDER].W_TB_REG_ENDERECOS_N, LBFPF012.REG_ENDERECO);

            /*" -2405- MOVE 'NAO' TO W-ACHOU-ENDERECO. */
            _.Move("NAO", WAREA_AUXILIAR.W_ACHOU_ENDERECO);

            /*" -2409- IF R2-ENDERECO OF REG-ENDERECO EQUAL SPACES AND R2-BAIRRO OF REG-ENDERECO EQUAL SPACES AND R2-CIDADE OF REG-ENDERECO EQUAL SPACES AND R2-SIGLA-UF OF REG-ENDERECO EQUAL SPACES */

            if (LBFPF012.REG_ENDERECO.R2_ENDERECO.IsEmpty() && LBFPF012.REG_ENDERECO.R2_BAIRRO.IsEmpty() && LBFPF012.REG_ENDERECO.R2_CIDADE.IsEmpty() && LBFPF012.REG_ENDERECO.R2_SIGLA_UF.IsEmpty())
            {

                /*" -2411- MOVE 'SIM' TO W-ACHOU-ENDERECO. */
                _.Move("SIM", WAREA_AUXILIAR.W_ACHOU_ENDERECO);
            }


            /*" -2416- PERFORM R0615-VERIFICA-EXISTE-ENDERECO VARYING W-IND-ENDER1 FROM 1 BY 1 UNTIL W-IND-ENDER1 GREATER W-IND-ENDER-A OR W-ACHOU-ENDERECO EQUAL 'SIM' . */

            for (WAREA_AUXILIAR.W_IND_ENDER1.Value = 1; !(WAREA_AUXILIAR.W_IND_ENDER1 > WAREA_AUXILIAR.W_IND_ENDER_A || WAREA_AUXILIAR.W_ACHOU_ENDERECO == "SIM"); WAREA_AUXILIAR.W_IND_ENDER1.Value += 1)
            {

                R0615_VERIFICA_EXISTE_ENDERECO_SECTION();
            }

            /*" -2417- IF W-ACHOU-ENDERECO EQUAL 'NAO' */

            if (WAREA_AUXILIAR.W_ACHOU_ENDERECO == "NAO")
            {

                /*" -2417- PERFORM R0620-INCLUIR-NOVO-ENDERECO. */

                R0620_INCLUIR_NOVO_ENDERECO_SECTION();
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0601_SAIDA*/

        [StopWatch]
        /*" R0605-TAB-ENDERECO-NOVOS-SECTION */
        private void R0605_TAB_ENDERECO_NOVOS_SECTION()
        {
            /*" -2427- MOVE 'R0605-TAB-ENDERECO-NOVOS' TO PARAGRAFO. */
            _.Move("R0605-TAB-ENDERECO-NOVOS", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2429- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2431- MOVE ZEROS TO W-IND-ENDER-A. */
            _.Move(0, WAREA_AUXILIAR.W_IND_ENDER_A);

            /*" -2433- MOVE 'NAO' TO W-FIM-CURSOR-ENDERECO. */
            _.Move("NAO", WAREA_AUXILIAR.W_FIM_CURSOR_ENDERECO);

            /*" -2440- PERFORM R0605A-RELACIONA-ENDERECO. */

            R0605A_RELACIONA_ENDERECO_SECTION();

            /*" -2441- IF ENDERECO-COM-530 */

            if (WREA88.W88_530_ENDERECO["ENDERECO_COM_530"])
            {

                /*" -2443- MOVE 'SELECT MAX PESSOA_ENDERECO' TO COMANDO */
                _.Move("SELECT MAX PESSOA_ENDERECO", WABEND.LOCALIZA_ABEND_2.COMANDO);

                /*" -2449- PERFORM R0605_TAB_ENDERECO_NOVOS_DB_SELECT_1 */

                R0605_TAB_ENDERECO_NOVOS_DB_SELECT_1();

                /*" -2452- IF SQLCODE NOT EQUAL 00 */

                if (DB.SQLCODE != 00)
                {

                    /*" -2453- DISPLAY 'PF0103B - FIM ANORMAL ' */
                    _.Display($"PF0103B - FIM ANORMAL ");

                    /*" -2454- DISPLAY '          ERRO SELECT MAX PESSOA-ENDERECO' */
                    _.Display($"          ERRO SELECT MAX PESSOA-ENDERECO");

                    /*" -2456- DISPLAY '          CODIGO PESSOA.................  ' PESSOA-COD-PESSOA OF DCLPESSOA */
                    _.Display($"          CODIGO PESSOA.................  {PESSOA.DCLPESSOA.PESSOA_COD_PESSOA}");

                    /*" -2458- DISPLAY '          NUMERO PROPOSTA...............  ' R2-NUM-PROPOSTA OF REG-ENDERECO */
                    _.Display($"          NUMERO PROPOSTA...............  {LBFPF012.REG_ENDERECO.R2_NUM_PROPOSTA}");

                    /*" -2460- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                    _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                    /*" -2461- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -2462- PERFORM R9999-00-FINALIZAR */

                    R9999_00_FINALIZAR_SECTION();

                    /*" -2464- ELSE NEXT SENTENCE */
                }
                else
                {


                    /*" -2465- ELSE */
                }

            }
            else
            {


                /*" -2467- PERFORM R0610-FETCH-ENDERECO */

                R0610_FETCH_ENDERECO_SECTION();

                /*" -2468- PERFORM R0605B-CARREGA-TB-ENDERECO UNTIL W-FIM-CURSOR-ENDERECO EQUAL 'SIM' . */

                while (!(WAREA_AUXILIAR.W_FIM_CURSOR_ENDERECO == "SIM"))
                {

                    R0605B_CARREGA_TB_ENDERECO_SECTION();
                }
            }


        }

        [StopWatch]
        /*" R0605-TAB-ENDERECO-NOVOS-DB-SELECT-1 */
        public void R0605_TAB_ENDERECO_NOVOS_DB_SELECT_1()
        {
            /*" -2449- EXEC SQL SELECT VALUE(MAX(OCORR_ENDERECO),0) INTO :DCLPESSOA-ENDERECO.OCORR-ENDERECO FROM SEGUROS.PESSOA_ENDERECO WHERE COD_PESSOA = :DCLPESSOA.PESSOA-COD-PESSOA WITH UR END-EXEC */

            var r0605_TAB_ENDERECO_NOVOS_DB_SELECT_1_Query1 = new R0605_TAB_ENDERECO_NOVOS_DB_SELECT_1_Query1()
            {
                PESSOA_COD_PESSOA = PESSOA.DCLPESSOA.PESSOA_COD_PESSOA.ToString(),
            };

            var executed_1 = R0605_TAB_ENDERECO_NOVOS_DB_SELECT_1_Query1.Execute(r0605_TAB_ENDERECO_NOVOS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.OCORR_ENDERECO, PESENDER.DCLPESSOA_ENDERECO.OCORR_ENDERECO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0605_SAIDA*/

        [StopWatch]
        /*" R0605A-RELACIONA-ENDERECO-SECTION */
        private void R0605A_RELACIONA_ENDERECO_SECTION()
        {
            /*" -2478- MOVE 'R0605A-RELACIONA-ENDERECO' TO PARAGRAFO. */
            _.Move("R0605A-RELACIONA-ENDERECO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2480- MOVE 'DECLARE PESSOA-ENDERECO' TO COMANDO. */
            _.Move("DECLARE PESSOA-ENDERECO", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2483- MOVE PESSOA-COD-PESSOA OF DCLPESSOA TO COD-PESSOA OF DCLPESSOA-ENDERECO. */
            _.Move(PESSOA.DCLPESSOA.PESSOA_COD_PESSOA, PESENDER.DCLPESSOA_ENDERECO.COD_PESSOA);

            /*" -2485- MOVE 2 TO W88-530-ENDERECO */
            _.Move(2, WREA88.W88_530_ENDERECO);

            /*" -2500- PERFORM R0605A_RELACIONA_ENDERECO_DB_DECLARE_1 */

            R0605A_RELACIONA_ENDERECO_DB_DECLARE_1();

            /*" -2504- IF SQLCODE NOT EQUAL 00 AND SQLCODE NOT EQUAL 100 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != 100)
            {

                /*" -2505- DISPLAY 'PF0103B - FIM ANORMAL - DECLARE' */
                _.Display($"PF0103B - FIM ANORMAL - DECLARE");

                /*" -2506- DISPLAY '          ERRO DECLARE DA TABELA PESSOA-ENDERECO' */
                _.Display($"          ERRO DECLARE DA TABELA PESSOA-ENDERECO");

                /*" -2508- DISPLAY '          CODIGO PESSOA.................  ' COD-PESSOA OF DCLPESSOA-ENDERECO */
                _.Display($"          CODIGO PESSOA.................  {PESENDER.DCLPESSOA_ENDERECO.COD_PESSOA}");

                /*" -2510- DISPLAY '          NUMERO PROPOSTA...............  ' R2-NUM-PROPOSTA OF REG-ENDERECO */
                _.Display($"          NUMERO PROPOSTA...............  {LBFPF012.REG_ENDERECO.R2_NUM_PROPOSTA}");

                /*" -2512- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -2513- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -2514- PERFORM R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION();

                /*" -2515- ELSE */
            }
            else
            {


                /*" -2516- IF SQLCODE EQUAL 530 */

                if (DB.SQLCODE == 530)
                {

                    /*" -2517- MOVE 1 TO W88-530-ENDERECO */
                    _.Move(1, WREA88.W88_530_ENDERECO);

                    /*" -2519- INITIALIZE DCLPESSOA-ENDERECO W-TB-ENDERECOS-N */
                    _.Initialize(
                        PESENDER.DCLPESSOA_ENDERECO
                        , WAREA_AUXILIAR.W_TB_ENDERECOS_N
                    );

                    /*" -2520- DISPLAY 'ENDERECO COM ERRO INTEGRIDADE' */
                    _.Display($"ENDERECO COM ERRO INTEGRIDADE");

                    /*" -2522- DISPLAY '          CODIGO PESSOA.................  ' PESSOA-COD-PESSOA OF DCLPESSOA */
                    _.Display($"          CODIGO PESSOA.................  {PESSOA.DCLPESSOA.PESSOA_COD_PESSOA}");

                    /*" -2524- DISPLAY '          NUMERO PROPOSTA...............  ' R2-NUM-PROPOSTA OF REG-ENDERECO */
                    _.Display($"          NUMERO PROPOSTA...............  {LBFPF012.REG_ENDERECO.R2_NUM_PROPOSTA}");

                    /*" -2526- GO TO R0605A-SAIDA. */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0605A_SAIDA*/ //GOTO
                    return;
                }

            }


            /*" -2528- MOVE 'OPEN CURSOR ENDERECOS' TO COMANDO. */
            _.Move("OPEN CURSOR ENDERECOS", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2528- PERFORM R0605A_RELACIONA_ENDERECO_DB_OPEN_1 */

            R0605A_RELACIONA_ENDERECO_DB_OPEN_1();

            /*" -2531- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -2532- DISPLAY 'PF0103B - FIM ANORMAL - OPEN' */
                _.Display($"PF0103B - FIM ANORMAL - OPEN");

                /*" -2533- DISPLAY '          ERRO OPEN TABELA PESSOA-ENDERECO' */
                _.Display($"          ERRO OPEN TABELA PESSOA-ENDERECO");

                /*" -2535- DISPLAY '          CODIGO PESSOA.................  ' COD-PESSOA OF DCLPESSOA-ENDERECO */
                _.Display($"          CODIGO PESSOA.................  {PESENDER.DCLPESSOA_ENDERECO.COD_PESSOA}");

                /*" -2537- DISPLAY '          NUMERO PROPOSTA...............  ' R2-NUM-PROPOSTA OF REG-ENDERECO */
                _.Display($"          NUMERO PROPOSTA...............  {LBFPF012.REG_ENDERECO.R2_NUM_PROPOSTA}");

                /*" -2539- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -2540- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -2540- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R0605A-RELACIONA-ENDERECO-DB-OPEN-1 */
        public void R0605A_RELACIONA_ENDERECO_DB_OPEN_1()
        {
            /*" -2528- EXEC SQL OPEN ENDERECOS END-EXEC. */

            ENDERECOS.Open();

        }

        [StopWatch]
        /*" R0762-00-OBTER-COMISSAO-DB-DECLARE-1 */
        public void R0762_00_OBTER_COMISSAO_DB_DECLARE_1()
        {
            /*" -3594- EXEC SQL DECLARE FUNDOCOMISVA CURSOR FOR SELECT NUM_CERTIFICADO , VAL_COMISSAO_VG , VAL_COMISSAO_AP FROM SEGUROS.FUNDO_COMISSAO_VA WHERE NUM_CERTIFICADO = :DCLFUNDO-COMISSAO-VA.NUM-CERTIFICADO AND COD_OPERACAO = :DCLFUNDO-COMISSAO-VA.COD-OPERACAO WITH UR END-EXEC. */
            FUNDOCOMISVA = new PF0103B_FUNDOCOMISVA(true);
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
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0605A_SAIDA*/

        [StopWatch]
        /*" R0605B-CARREGA-TB-ENDERECO-SECTION */
        private void R0605B_CARREGA_TB_ENDERECO_SECTION()
        {
            /*" -2550- MOVE 'R0605B-CARREGA-TB-ENDERECO' TO PARAGRAFO. */
            _.Move("R0605B-CARREGA-TB-ENDERECO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2552- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2554- ADD 1 TO W-IND-ENDER-A. */
            WAREA_AUXILIAR.W_IND_ENDER_A.Value = WAREA_AUXILIAR.W_IND_ENDER_A + 1;

            /*" -2557- MOVE DCLPESSOA-ENDERECO TO W-TB-REG-ENDERECOS-A(W-IND-ENDER-A) */
            _.Move(PESENDER.DCLPESSOA_ENDERECO, WAREA_AUXILIAR.W_TB_ENDERECOS_A.W_TAB_END_REG_A[WAREA_AUXILIAR.W_IND_ENDER_A].W_TB_REG_ENDERECOS_A);

            /*" -2557- PERFORM R0610-FETCH-ENDERECO. */

            R0610_FETCH_ENDERECO_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0605B_SAIDA*/

        [StopWatch]
        /*" R0610-FETCH-ENDERECO-SECTION */
        private void R0610_FETCH_ENDERECO_SECTION()
        {
            /*" -2566- MOVE 'R0610-FETCH-ENDERECO' TO PARAGRAFO. */
            _.Move("R0610-FETCH-ENDERECO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2568- MOVE 'FETCH CURSOR ENDERECOS' TO COMANDO. */
            _.Move("FETCH CURSOR ENDERECOS", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2579- PERFORM R0610_FETCH_ENDERECO_DB_FETCH_1 */

            R0610_FETCH_ENDERECO_DB_FETCH_1();

            /*" -2582- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -2583- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2584- MOVE 'SIM' TO W-FIM-CURSOR-ENDERECO */
                    _.Move("SIM", WAREA_AUXILIAR.W_FIM_CURSOR_ENDERECO);

                    /*" -2584- PERFORM R0610_FETCH_ENDERECO_DB_CLOSE_1 */

                    R0610_FETCH_ENDERECO_DB_CLOSE_1();

                    /*" -2586- ELSE */
                }
                else
                {


                    /*" -2587- DISPLAY 'PF0103B - FIM ANORMAL - FETCH' */
                    _.Display($"PF0103B - FIM ANORMAL - FETCH");

                    /*" -2588- DISPLAY '          ERRO FETCH CURSOR ENDERECO' */
                    _.Display($"          ERRO FETCH CURSOR ENDERECO");

                    /*" -2590- DISPLAY '          CODIGO PESSOA.................  ' COD-PESSOA OF DCLPESSOA-ENDERECO */
                    _.Display($"          CODIGO PESSOA.................  {PESENDER.DCLPESSOA_ENDERECO.COD_PESSOA}");

                    /*" -2592- DISPLAY '          NUMERO PROPOSTA...............  ' R2-NUM-PROPOSTA OF REG-ENDERECO */
                    _.Display($"          NUMERO PROPOSTA...............  {LBFPF012.REG_ENDERECO.R2_NUM_PROPOSTA}");

                    /*" -2594- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                    _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                    /*" -2595- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -2595- PERFORM R9999-00-FINALIZAR. */

                    R9999_00_FINALIZAR_SECTION();
                }

            }


        }

        [StopWatch]
        /*" R0610-FETCH-ENDERECO-DB-FETCH-1 */
        public void R0610_FETCH_ENDERECO_DB_FETCH_1()
        {
            /*" -2579- EXEC SQL FETCH ENDERECOS INTO :DCLPESSOA-ENDERECO.OCORR-ENDERECO, :DCLPESSOA-ENDERECO.COD-PESSOA, :DCLPESSOA-ENDERECO.ENDERECO, :DCLPESSOA-ENDERECO.TIPO-ENDER, :DCLPESSOA-ENDERECO.BAIRRO, :DCLPESSOA-ENDERECO.CEP, :DCLPESSOA-ENDERECO.CIDADE, :DCLPESSOA-ENDERECO.SIGLA-UF, :DCLPESSOA-ENDERECO.SITUACAO-ENDERECO END-EXEC. */

            if (ENDERECOS.Fetch())
            {
                _.Move(ENDERECOS.DCLPESSOA_ENDERECO_OCORR_ENDERECO, PESENDER.DCLPESSOA_ENDERECO.OCORR_ENDERECO);
                _.Move(ENDERECOS.DCLPESSOA_ENDERECO_COD_PESSOA, PESENDER.DCLPESSOA_ENDERECO.COD_PESSOA);
                _.Move(ENDERECOS.DCLPESSOA_ENDERECO_ENDERECO, PESENDER.DCLPESSOA_ENDERECO.ENDERECO);
                _.Move(ENDERECOS.DCLPESSOA_ENDERECO_TIPO_ENDER, PESENDER.DCLPESSOA_ENDERECO.TIPO_ENDER);
                _.Move(ENDERECOS.DCLPESSOA_ENDERECO_BAIRRO, PESENDER.DCLPESSOA_ENDERECO.BAIRRO);
                _.Move(ENDERECOS.DCLPESSOA_ENDERECO_CEP, PESENDER.DCLPESSOA_ENDERECO.CEP);
                _.Move(ENDERECOS.DCLPESSOA_ENDERECO_CIDADE, PESENDER.DCLPESSOA_ENDERECO.CIDADE);
                _.Move(ENDERECOS.DCLPESSOA_ENDERECO_SIGLA_UF, PESENDER.DCLPESSOA_ENDERECO.SIGLA_UF);
                _.Move(ENDERECOS.DCLPESSOA_ENDERECO_SITUACAO_ENDERECO, PESENDER.DCLPESSOA_ENDERECO.SITUACAO_ENDERECO);
            }

        }

        [StopWatch]
        /*" R0610-FETCH-ENDERECO-DB-CLOSE-1 */
        public void R0610_FETCH_ENDERECO_DB_CLOSE_1()
        {
            /*" -2584- EXEC SQL CLOSE ENDERECOS END-EXEC */

            ENDERECOS.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0610_SAIDA*/

        [StopWatch]
        /*" R0615-VERIFICA-EXISTE-ENDERECO-SECTION */
        private void R0615_VERIFICA_EXISTE_ENDERECO_SECTION()
        {
            /*" -2605- MOVE 'R0615-VERIFICA-EXISTE-ENDERECO' TO PARAGRAFO. */
            _.Move("R0615-VERIFICA-EXISTE-ENDERECO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2607- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2610- MOVE W-TB-REG-ENDERECOS-A(W-IND-ENDER1) TO DCLPESSOA-ENDERECO. */
            _.Move(WAREA_AUXILIAR.W_TB_ENDERECOS_A.W_TAB_END_REG_A[WAREA_AUXILIAR.W_IND_ENDER1].W_TB_REG_ENDERECOS_A, PESENDER.DCLPESSOA_ENDERECO);

            /*" -2620- IF R2-TIPO-ENDER OF REG-ENDERECO EQUAL TIPO-ENDER OF DCLPESSOA-ENDERECO AND R2-ENDERECO OF REG-ENDERECO EQUAL ENDERECO OF DCLPESSOA-ENDERECO AND R2-CIDADE OF REG-ENDERECO EQUAL CIDADE OF DCLPESSOA-ENDERECO AND R2-SIGLA-UF OF REG-ENDERECO EQUAL SIGLA-UF OF DCLPESSOA-ENDERECO AND R2-CEP OF REG-ENDERECO EQUAL CEP OF DCLPESSOA-ENDERECO */

            if (LBFPF012.REG_ENDERECO.R2_TIPO_ENDER == PESENDER.DCLPESSOA_ENDERECO.TIPO_ENDER && LBFPF012.REG_ENDERECO.R2_ENDERECO == PESENDER.DCLPESSOA_ENDERECO.ENDERECO && LBFPF012.REG_ENDERECO.R2_CIDADE == PESENDER.DCLPESSOA_ENDERECO.CIDADE && LBFPF012.REG_ENDERECO.R2_SIGLA_UF == PESENDER.DCLPESSOA_ENDERECO.SIGLA_UF && LBFPF012.REG_ENDERECO.R2_CEP == PESENDER.DCLPESSOA_ENDERECO.CEP)
            {

                /*" -2620- MOVE 'SIM' TO W-ACHOU-ENDERECO. */
                _.Move("SIM", WAREA_AUXILIAR.W_ACHOU_ENDERECO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0615_SAIDA*/

        [StopWatch]
        /*" R0620-INCLUIR-NOVO-ENDERECO-SECTION */
        private void R0620_INCLUIR_NOVO_ENDERECO_SECTION()
        {
            /*" -2630- MOVE 'R0620-INCLUIR-NOVO-ENDERECO' TO PARAGRAFO. */
            _.Move("R0620-INCLUIR-NOVO-ENDERECO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2632- MOVE 'INSERT PESSOA-ENDERECO' TO COMANDO. */
            _.Move("INSERT PESSOA-ENDERECO", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2634- ADD 1 TO W-QTD-LD-SIVPF-2 */
            WAREA_AUXILIAR.W_QTD_LD_SIVPF_2.Value = WAREA_AUXILIAR.W_QTD_LD_SIVPF_2 + 1;

            /*" -2637- MOVE OCORR-ENDERECO OF DCLPESSOA-ENDERECO TO W-OCORR-ENDERECO */
            _.Move(PESENDER.DCLPESSOA_ENDERECO.OCORR_ENDERECO, WAREA_AUXILIAR.W_OCORR_ENDERECO);

            /*" -2639- COMPUTE W-OCORR-ENDERECO = W-OCORR-ENDERECO + 1. */
            WAREA_AUXILIAR.W_OCORR_ENDERECO.Value = WAREA_AUXILIAR.W_OCORR_ENDERECO + 1;

            /*" -2642- MOVE W-OCORR-ENDERECO TO OCORR-ENDERECO OF DCLPESSOA-ENDERECO. */
            _.Move(WAREA_AUXILIAR.W_OCORR_ENDERECO, PESENDER.DCLPESSOA_ENDERECO.OCORR_ENDERECO);

            /*" -2645- MOVE PESSOA-COD-PESSOA OF DCLPESSOA TO COD-PESSOA OF DCLPESSOA-ENDERECO. */
            _.Move(PESSOA.DCLPESSOA.PESSOA_COD_PESSOA, PESENDER.DCLPESSOA_ENDERECO.COD_PESSOA);

            /*" -2648- MOVE R2-ENDERECO OF REG-ENDERECO TO ENDERECO OF DCLPESSOA-ENDERECO. */
            _.Move(LBFPF012.REG_ENDERECO.R2_ENDERECO, PESENDER.DCLPESSOA_ENDERECO.ENDERECO);

            /*" -2651- MOVE R2-TIPO-ENDER OF REG-ENDERECO TO TIPO-ENDER OF DCLPESSOA-ENDERECO. */
            _.Move(LBFPF012.REG_ENDERECO.R2_TIPO_ENDER, PESENDER.DCLPESSOA_ENDERECO.TIPO_ENDER);

            /*" -2654- MOVE R2-BAIRRO OF REG-ENDERECO TO BAIRRO OF DCLPESSOA-ENDERECO. */
            _.Move(LBFPF012.REG_ENDERECO.R2_BAIRRO, PESENDER.DCLPESSOA_ENDERECO.BAIRRO);

            /*" -2657- MOVE R2-CEP OF REG-ENDERECO TO CEP OF DCLPESSOA-ENDERECO. */
            _.Move(LBFPF012.REG_ENDERECO.R2_CEP, PESENDER.DCLPESSOA_ENDERECO.CEP);

            /*" -2660- MOVE R2-CIDADE OF REG-ENDERECO TO CIDADE OF DCLPESSOA-ENDERECO. */
            _.Move(LBFPF012.REG_ENDERECO.R2_CIDADE, PESENDER.DCLPESSOA_ENDERECO.CIDADE);

            /*" -2663- MOVE R2-SIGLA-UF OF REG-ENDERECO TO SIGLA-UF OF DCLPESSOA-ENDERECO. */
            _.Move(LBFPF012.REG_ENDERECO.R2_SIGLA_UF, PESENDER.DCLPESSOA_ENDERECO.SIGLA_UF);

            /*" -2666- MOVE 'A' TO SITUACAO-ENDERECO OF DCLPESSOA-ENDERECO. */
            _.Move("A", PESENDER.DCLPESSOA_ENDERECO.SITUACAO_ENDERECO);

            /*" -2669- MOVE 'PF0103B' TO COD-USUARIO OF DCLPESSOA-ENDERECO. */
            _.Move("PF0103B", PESENDER.DCLPESSOA_ENDERECO.COD_USUARIO);

            /*" -2683- PERFORM R0620_INCLUIR_NOVO_ENDERECO_DB_INSERT_1 */

            R0620_INCLUIR_NOVO_ENDERECO_DB_INSERT_1();

            /*" -2686- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -2687- DISPLAY 'PF0103B - FIM ANORMAL - INSERT' */
                _.Display($"PF0103B - FIM ANORMAL - INSERT");

                /*" -2688- DISPLAY '          ERRO INSERT TABELA PESSOA-ENDERECO' */
                _.Display($"          ERRO INSERT TABELA PESSOA-ENDERECO");

                /*" -2690- DISPLAY '          CODIGO PESSOA.................  ' COD-PESSOA OF DCLPESSOA-ENDERECO */
                _.Display($"          CODIGO PESSOA.................  {PESENDER.DCLPESSOA_ENDERECO.COD_PESSOA}");

                /*" -2692- DISPLAY '          NUMERO DA PROPOSTA............  ' R2-NUM-PROPOSTA OF REG-ENDERECO */
                _.Display($"          NUMERO DA PROPOSTA............  {LBFPF012.REG_ENDERECO.R2_NUM_PROPOSTA}");

                /*" -2694- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -2695- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -2695- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R0620-INCLUIR-NOVO-ENDERECO-DB-INSERT-1 */
        public void R0620_INCLUIR_NOVO_ENDERECO_DB_INSERT_1()
        {
            /*" -2683- EXEC SQL INSERT INTO SEGUROS.PESSOA_ENDERECO VALUES (:DCLPESSOA-ENDERECO.COD-PESSOA, :DCLPESSOA-ENDERECO.OCORR-ENDERECO, :DCLPESSOA-ENDERECO.ENDERECO, :DCLPESSOA-ENDERECO.TIPO-ENDER, NULL, :DCLPESSOA-ENDERECO.BAIRRO, :DCLPESSOA-ENDERECO.CEP, :DCLPESSOA-ENDERECO.CIDADE, :DCLPESSOA-ENDERECO.SIGLA-UF, :DCLPESSOA-ENDERECO.SITUACAO-ENDERECO, :DCLPESSOA-ENDERECO.COD-USUARIO, CURRENT TIMESTAMP) END-EXEC. */

            var r0620_INCLUIR_NOVO_ENDERECO_DB_INSERT_1_Insert1 = new R0620_INCLUIR_NOVO_ENDERECO_DB_INSERT_1_Insert1()
            {
                COD_PESSOA = PESENDER.DCLPESSOA_ENDERECO.COD_PESSOA.ToString(),
                OCORR_ENDERECO = PESENDER.DCLPESSOA_ENDERECO.OCORR_ENDERECO.ToString(),
                ENDERECO = PESENDER.DCLPESSOA_ENDERECO.ENDERECO.ToString(),
                TIPO_ENDER = PESENDER.DCLPESSOA_ENDERECO.TIPO_ENDER.ToString(),
                BAIRRO = PESENDER.DCLPESSOA_ENDERECO.BAIRRO.ToString(),
                CEP = PESENDER.DCLPESSOA_ENDERECO.CEP.ToString(),
                CIDADE = PESENDER.DCLPESSOA_ENDERECO.CIDADE.ToString(),
                SIGLA_UF = PESENDER.DCLPESSOA_ENDERECO.SIGLA_UF.ToString(),
                SITUACAO_ENDERECO = PESENDER.DCLPESSOA_ENDERECO.SITUACAO_ENDERECO.ToString(),
                COD_USUARIO = PESENDER.DCLPESSOA_ENDERECO.COD_USUARIO.ToString(),
            };

            R0620_INCLUIR_NOVO_ENDERECO_DB_INSERT_1_Insert1.Execute(r0620_INCLUIR_NOVO_ENDERECO_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0620_SAIDA*/

        [StopWatch]
        /*" R0650-TRATA-TELEFONES-SECTION */
        private void R0650_TRATA_TELEFONES_SECTION()
        {
            /*" -2705- MOVE 'R0650-TRATA-TELEFONE' TO PARAGRAFO. */
            _.Move("R0650-TRATA-TELEFONE", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2707- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2709- ADD 1 TO W-INDEX. */
            WAREA_AUXILIAR.W_INDEX.Value = WAREA_AUXILIAR.W_INDEX + 1;

            /*" -2711- MOVE 'NAO' TO W-ACHOU-TELEFONE. */
            _.Move("NAO", WAREA_AUXILIAR.W_ACHOU_TELEFONE);

            /*" -2712- IF R1-NUM-FONE (W-INDEX) GREATER ZEROS */

            if (LBFPF011.REG_CLIENTES.R1_TELEFONE[WAREA_AUXILIAR.W_INDEX].R1_NUM_FONE > 00)
            {

                /*" -2713- PERFORM R0655-LER-TELEFONE */

                R0655_LER_TELEFONE_SECTION();

                /*" -2714- IF W-ACHOU-TELEFONE EQUAL 'NAO' */

                if (WAREA_AUXILIAR.W_ACHOU_TELEFONE == "NAO")
                {

                    /*" -2714- PERFORM R0660-INCLUIR-NOVO-TELEFONE. */

                    R0660_INCLUIR_NOVO_TELEFONE_SECTION();
                }

            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0650_SAIDA*/

        [StopWatch]
        /*" R0655-LER-TELEFONE-SECTION */
        private void R0655_LER_TELEFONE_SECTION()
        {
            /*" -2724- MOVE 'R0655-LER-TELEFONE' TO PARAGRAFO. */
            _.Move("R0655-LER-TELEFONE", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2726- MOVE 'SELECT PESSOA-TELEFONE' TO COMANDO. */
            _.Move("SELECT PESSOA-TELEFONE", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2732- MOVE PESSOA-COD-PESSOA OF DCLPESSOA TO COD-PESSOA OF DCLPESSOA-TELEFONE. */
            _.Move(PESSOA.DCLPESSOA.PESSOA_COD_PESSOA, PESFONE.DCLPESSOA_TELEFONE.COD_PESSOA);

            /*" -2733- IF R1-DDD (W-INDEX) NOT NUMERIC */

            if (!LBFPF011.REG_CLIENTES.R1_TELEFONE[WAREA_AUXILIAR.W_INDEX].R1_DDD.IsNumeric())
            {

                /*" -2735- MOVE ZEROS TO R1-DDD (W-INDEX). */
                _.Move(0, LBFPF011.REG_CLIENTES.R1_TELEFONE[WAREA_AUXILIAR.W_INDEX].R1_DDD);
            }


            /*" -2741- MOVE R1-DDD (W-INDEX) TO DDD OF DCLPESSOA-TELEFONE. */
            _.Move(LBFPF011.REG_CLIENTES.R1_TELEFONE[WAREA_AUXILIAR.W_INDEX].R1_DDD, PESFONE.DCLPESSOA_TELEFONE.DDD);

            /*" -2742- IF R1-NUM-FONE (W-INDEX) NOT NUMERIC */

            if (!LBFPF011.REG_CLIENTES.R1_TELEFONE[WAREA_AUXILIAR.W_INDEX].R1_NUM_FONE.IsNumeric())
            {

                /*" -2744- MOVE ZEROS TO R1-NUM-FONE (W-INDEX). */
                _.Move(0, LBFPF011.REG_CLIENTES.R1_TELEFONE[WAREA_AUXILIAR.W_INDEX].R1_NUM_FONE);
            }


            /*" -2747- MOVE R1-NUM-FONE (W-INDEX) TO NUM-FONE OF DCLPESSOA-TELEFONE. */
            _.Move(LBFPF011.REG_CLIENTES.R1_TELEFONE[WAREA_AUXILIAR.W_INDEX].R1_NUM_FONE, PESFONE.DCLPESSOA_TELEFONE.NUM_FONE);

            /*" -2748- IF R1-NUM-FONE (W-INDEX) EQUAL ZEROS */

            if (LBFPF011.REG_CLIENTES.R1_TELEFONE[WAREA_AUXILIAR.W_INDEX].R1_NUM_FONE == 00)
            {

                /*" -2749- MOVE 'SIM' TO W-ACHOU-TELEFONE */
                _.Move("SIM", WAREA_AUXILIAR.W_ACHOU_TELEFONE);

                /*" -2755- GO TO R0655-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0655_SAIDA*/ //GOTO
                return;
            }


            /*" -2758- MOVE W-INDEX TO TIPO-FONE OF DCLPESSOA-TELEFONE */
            _.Move(WAREA_AUXILIAR.W_INDEX, PESFONE.DCLPESSOA_TELEFONE.TIPO_FONE);

            /*" -2767- PERFORM R0655_LER_TELEFONE_DB_SELECT_1 */

            R0655_LER_TELEFONE_DB_SELECT_1();

            /*" -2770- IF SQLCODE EQUAL 00 */

            if (DB.SQLCODE == 00)
            {

                /*" -2771- MOVE 'SIM' TO W-ACHOU-TELEFONE */
                _.Move("SIM", WAREA_AUXILIAR.W_ACHOU_TELEFONE);

                /*" -2772- ELSE */
            }
            else
            {


                /*" -2773- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2774- MOVE 'NAO' TO W-ACHOU-TELEFONE */
                    _.Move("NAO", WAREA_AUXILIAR.W_ACHOU_TELEFONE);

                    /*" -2775- ELSE */
                }
                else
                {


                    /*" -2776- DISPLAY 'PF0103B - FIM ANORMAL' */
                    _.Display($"PF0103B - FIM ANORMAL");

                    /*" -2777- DISPLAY '          ERRO SELECT TABELA PESSOA-TELEFONE' */
                    _.Display($"          ERRO SELECT TABELA PESSOA-TELEFONE");

                    /*" -2779- DISPLAY '          CODIGO PESSOA.................  ' COD-PESSOA OF DCLPESSOA-TELEFONE */
                    _.Display($"          CODIGO PESSOA.................  {PESFONE.DCLPESSOA_TELEFONE.COD_PESSOA}");

                    /*" -2781- DISPLAY '          NUMERO PROPOSTA...............  ' R2-NUM-PROPOSTA OF REG-ENDERECO */
                    _.Display($"          NUMERO PROPOSTA...............  {LBFPF012.REG_ENDERECO.R2_NUM_PROPOSTA}");

                    /*" -2783- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                    _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                    /*" -2784- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -2784- PERFORM R9999-00-FINALIZAR. */

                    R9999_00_FINALIZAR_SECTION();
                }

            }


        }

        [StopWatch]
        /*" R0655-LER-TELEFONE-DB-SELECT-1 */
        public void R0655_LER_TELEFONE_DB_SELECT_1()
        {
            /*" -2767- EXEC SQL SELECT SITUACAO_FONE INTO :DCLPESSOA-TELEFONE.SITUACAO-FONE FROM SEGUROS.PESSOA_TELEFONE WHERE COD_PESSOA = :DCLPESSOA-TELEFONE.COD-PESSOA AND TIPO_FONE = :DCLPESSOA-TELEFONE.TIPO-FONE AND NUM_FONE = :DCLPESSOA-TELEFONE.NUM-FONE AND DDD = :DCLPESSOA-TELEFONE.DDD WITH UR END-EXEC. */

            var r0655_LER_TELEFONE_DB_SELECT_1_Query1 = new R0655_LER_TELEFONE_DB_SELECT_1_Query1()
            {
                COD_PESSOA = PESFONE.DCLPESSOA_TELEFONE.COD_PESSOA.ToString(),
                TIPO_FONE = PESFONE.DCLPESSOA_TELEFONE.TIPO_FONE.ToString(),
                NUM_FONE = PESFONE.DCLPESSOA_TELEFONE.NUM_FONE.ToString(),
                DDD = PESFONE.DCLPESSOA_TELEFONE.DDD.ToString(),
            };

            var executed_1 = R0655_LER_TELEFONE_DB_SELECT_1_Query1.Execute(r0655_LER_TELEFONE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SITUACAO_FONE, PESFONE.DCLPESSOA_TELEFONE.SITUACAO_FONE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0655_SAIDA*/

        [StopWatch]
        /*" R0660-INCLUIR-NOVO-TELEFONE-SECTION */
        private void R0660_INCLUIR_NOVO_TELEFONE_SECTION()
        {
            /*" -2794- MOVE 'R0660-INCLUIR-NOVO-TELEFONE' TO PARAGRAFO. */
            _.Move("R0660-INCLUIR-NOVO-TELEFONE", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2796- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2798- PERFORM R0665-OBTER-MAX-TELEFONE. */

            R0665_OBTER_MAX_TELEFONE_SECTION();

            /*" -2801- MOVE SEQ-FONE OF DCLPESSOA-TELEFONE TO W-SEQ-FONE */
            _.Move(PESFONE.DCLPESSOA_TELEFONE.SEQ_FONE, WAREA_AUXILIAR.W_SEQ_FONE);

            /*" -2803- COMPUTE W-SEQ-FONE = W-SEQ-FONE + 1. */
            WAREA_AUXILIAR.W_SEQ_FONE.Value = WAREA_AUXILIAR.W_SEQ_FONE + 1;

            /*" -2803- PERFORM R0670-INCLUIR-TELEFONE. */

            R0670_INCLUIR_TELEFONE_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0660_SAIDA*/

        [StopWatch]
        /*" R0665-OBTER-MAX-TELEFONE-SECTION */
        private void R0665_OBTER_MAX_TELEFONE_SECTION()
        {
            /*" -2813- MOVE 'R0665-OBTER-MAX-TELEFONE' TO PARAGRAFO. */
            _.Move("R0665-OBTER-MAX-TELEFONE", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2815- MOVE 'MAX SEGUROS.PESSOA_TELEFONE' TO COMANDO. */
            _.Move("MAX SEGUROS.PESSOA_TELEFONE", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2821- PERFORM R0665_OBTER_MAX_TELEFONE_DB_SELECT_1 */

            R0665_OBTER_MAX_TELEFONE_DB_SELECT_1();

            /*" -2824- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -2825- DISPLAY 'PF0103B - FIM ANORMAL' */
                _.Display($"PF0103B - FIM ANORMAL");

                /*" -2826- DISPLAY '          ERRO SELECT MAX TAB. PESSOA-TELEFONE' */
                _.Display($"          ERRO SELECT MAX TAB. PESSOA-TELEFONE");

                /*" -2828- DISPLAY '          CODIGO PESSOA.................  ' COD-PESSOA OF DCLPESSOA-TELEFONE */
                _.Display($"          CODIGO PESSOA.................  {PESFONE.DCLPESSOA_TELEFONE.COD_PESSOA}");

                /*" -2830- DISPLAY '          NUMERO DA PROPOSTA............  ' R1-NUM-PROPOSTA OF REG-CLIENTES */
                _.Display($"          NUMERO DA PROPOSTA............  {LBFPF011.REG_CLIENTES.R1_NUM_PROPOSTA}");

                /*" -2832- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -2833- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -2833- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R0665-OBTER-MAX-TELEFONE-DB-SELECT-1 */
        public void R0665_OBTER_MAX_TELEFONE_DB_SELECT_1()
        {
            /*" -2821- EXEC SQL SELECT VALUE(MAX(SEQ_FONE),0) INTO :DCLPESSOA-TELEFONE.SEQ-FONE FROM SEGUROS.PESSOA_TELEFONE WHERE COD_PESSOA = :DCLPESSOA-TELEFONE.COD-PESSOA WITH UR END-EXEC. */

            var r0665_OBTER_MAX_TELEFONE_DB_SELECT_1_Query1 = new R0665_OBTER_MAX_TELEFONE_DB_SELECT_1_Query1()
            {
                COD_PESSOA = PESFONE.DCLPESSOA_TELEFONE.COD_PESSOA.ToString(),
            };

            var executed_1 = R0665_OBTER_MAX_TELEFONE_DB_SELECT_1_Query1.Execute(r0665_OBTER_MAX_TELEFONE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SEQ_FONE, PESFONE.DCLPESSOA_TELEFONE.SEQ_FONE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0665_SAIDA*/

        [StopWatch]
        /*" R0670-INCLUIR-TELEFONE-SECTION */
        private void R0670_INCLUIR_TELEFONE_SECTION()
        {
            /*" -2843- MOVE 'R0670-INCLUI-TELEFONE' TO PARAGRAFO. */
            _.Move("R0670-INCLUI-TELEFONE", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2845- MOVE 'INSERT PESSOA-TELEFONE' TO COMANDO. */
            _.Move("INSERT PESSOA-TELEFONE", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2849- MOVE PESSOA-COD-PESSOA OF DCLPESSOA TO COD-PESSOA OF DCLPESSOA-TELEFONE. */
            _.Move(PESSOA.DCLPESSOA.PESSOA_COD_PESSOA, PESFONE.DCLPESSOA_TELEFONE.COD_PESSOA);

            /*" -2852- MOVE W-INDEX TO TIPO-FONE OF DCLPESSOA-TELEFONE. */
            _.Move(WAREA_AUXILIAR.W_INDEX, PESFONE.DCLPESSOA_TELEFONE.TIPO_FONE);

            /*" -2855- MOVE W-SEQ-FONE TO SEQ-FONE OF DCLPESSOA-TELEFONE. */
            _.Move(WAREA_AUXILIAR.W_SEQ_FONE, PESFONE.DCLPESSOA_TELEFONE.SEQ_FONE);

            /*" -2858- MOVE 55 TO DDI OF DCLPESSOA-TELEFONE. */
            _.Move(55, PESFONE.DCLPESSOA_TELEFONE.DDI);

            /*" -2861- MOVE R1-DDD (W-INDEX) TO DDD OF DCLPESSOA-TELEFONE. */
            _.Move(LBFPF011.REG_CLIENTES.R1_TELEFONE[WAREA_AUXILIAR.W_INDEX].R1_DDD, PESFONE.DCLPESSOA_TELEFONE.DDD);

            /*" -2864- MOVE R1-NUM-FONE (W-INDEX) TO NUM-FONE OF DCLPESSOA-TELEFONE. */
            _.Move(LBFPF011.REG_CLIENTES.R1_TELEFONE[WAREA_AUXILIAR.W_INDEX].R1_NUM_FONE, PESFONE.DCLPESSOA_TELEFONE.NUM_FONE);

            /*" -2867- MOVE 'A' TO SITUACAO-FONE OF DCLPESSOA-TELEFONE. */
            _.Move("A", PESFONE.DCLPESSOA_TELEFONE.SITUACAO_FONE);

            /*" -2870- MOVE 'PF0103B' TO COD-USUARIO OF DCLPESSOA-TELEFONE. */
            _.Move("PF0103B", PESFONE.DCLPESSOA_TELEFONE.COD_USUARIO);

            /*" -2881- PERFORM R0670_INCLUIR_TELEFONE_DB_INSERT_1 */

            R0670_INCLUIR_TELEFONE_DB_INSERT_1();

            /*" -2884- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -2885- DISPLAY 'PF0103B - FIM ANORMAL' */
                _.Display($"PF0103B - FIM ANORMAL");

                /*" -2886- DISPLAY '          ERRO INSERT TABELA PESSOA-TELEFONE' */
                _.Display($"          ERRO INSERT TABELA PESSOA-TELEFONE");

                /*" -2888- DISPLAY '          CODIGO PESSOA.................  ' COD-PESSOA OF DCLPESSOA-TELEFONE */
                _.Display($"          CODIGO PESSOA.................  {PESFONE.DCLPESSOA_TELEFONE.COD_PESSOA}");

                /*" -2890- DISPLAY '          NUMERO DA PROPOSTA............  ' R1-NUM-PROPOSTA OF REG-CLIENTES */
                _.Display($"          NUMERO DA PROPOSTA............  {LBFPF011.REG_CLIENTES.R1_NUM_PROPOSTA}");

                /*" -2892- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -2893- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -2893- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R0670-INCLUIR-TELEFONE-DB-INSERT-1 */
        public void R0670_INCLUIR_TELEFONE_DB_INSERT_1()
        {
            /*" -2881- EXEC SQL INSERT INTO SEGUROS.PESSOA_TELEFONE VALUES (:DCLPESSOA-TELEFONE.COD-PESSOA, :DCLPESSOA-TELEFONE.TIPO-FONE, :DCLPESSOA-TELEFONE.SEQ-FONE, :DCLPESSOA-TELEFONE.DDI, :DCLPESSOA-TELEFONE.DDD, :DCLPESSOA-TELEFONE.NUM-FONE, :DCLPESSOA-TELEFONE.SITUACAO-FONE, :DCLPESSOA-TELEFONE.COD-USUARIO, CURRENT TIMESTAMP) END-EXEC. */

            var r0670_INCLUIR_TELEFONE_DB_INSERT_1_Insert1 = new R0670_INCLUIR_TELEFONE_DB_INSERT_1_Insert1()
            {
                COD_PESSOA = PESFONE.DCLPESSOA_TELEFONE.COD_PESSOA.ToString(),
                TIPO_FONE = PESFONE.DCLPESSOA_TELEFONE.TIPO_FONE.ToString(),
                SEQ_FONE = PESFONE.DCLPESSOA_TELEFONE.SEQ_FONE.ToString(),
                DDI = PESFONE.DCLPESSOA_TELEFONE.DDI.ToString(),
                DDD = PESFONE.DCLPESSOA_TELEFONE.DDD.ToString(),
                NUM_FONE = PESFONE.DCLPESSOA_TELEFONE.NUM_FONE.ToString(),
                SITUACAO_FONE = PESFONE.DCLPESSOA_TELEFONE.SITUACAO_FONE.ToString(),
                COD_USUARIO = PESFONE.DCLPESSOA_TELEFONE.COD_USUARIO.ToString(),
            };

            R0670_INCLUIR_TELEFONE_DB_INSERT_1_Insert1.Execute(r0670_INCLUIR_TELEFONE_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0670_SAIDA*/

        [StopWatch]
        /*" R0700-TRATA-PROPOSTA-SECTION */
        private void R0700_TRATA_PROPOSTA_SECTION()
        {
            /*" -2903- MOVE 'R0700-TRATA-PROPOSTA' TO PARAGRAFO. */
            _.Move("R0700-TRATA-PROPOSTA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2905- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2907- ADD 1 TO W-QTD-LD-SIVPF-3 */
            WAREA_AUXILIAR.W_QTD_LD_SIVPF_3.Value = WAREA_AUXILIAR.W_QTD_LD_SIVPF_3 + 1;

            /*" -2909- PERFORM R0710-TRATA-TAB-RELACIONAMENTO. */

            R0710_TRATA_TAB_RELACIONAMENTO_SECTION();

            /*" -2911- PERFORM R0750-TRATA-TAB-IDE-RELACIONAM. */

            R0750_TRATA_TAB_IDE_RELACIONAM_SECTION();

            /*" -2913- PERFORM R0760-TRATA-PROP-FIDELIZACAO. */

            R0760_TRATA_PROP_FIDELIZACAO_SECTION();

            /*" -2915- MOVE PROPOFID-COD-PRODUTO-SIVPF TO W-PRODUTO. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF, LBWPF002.W_PRODUTO);

            /*" -2915- PERFORM R0790-GERA-HIST-FIDELIZACAO. */

            R0790_GERA_HIST_FIDELIZACAO_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0700_SAIDA*/

        [StopWatch]
        /*" R0710-TRATA-TAB-RELACIONAMENTO-SECTION */
        private void R0710_TRATA_TAB_RELACIONAMENTO_SECTION()
        {
            /*" -2925- MOVE 'R0710-TRATA-TAB-RELACIONAMENTO' TO PARAGRAFO. */
            _.Move("R0710-TRATA-TAB-RELACIONAMENTO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2927- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2929- PERFORM R0715-DETERMINA-RELACIONAMENTO */

            R0715_DETERMINA_RELACIONAMENTO_SECTION();

            /*" -2931- MOVE 'NAO' TO W-ACHOU-RELACIONAMENTO. */
            _.Move("NAO", WAREA_AUXILIAR.W_ACHOU_RELACIONAMENTO);

            /*" -2933- PERFORM R0720-VERIFICA-EXISTE-RELACION. */

            R0720_VERIFICA_EXISTE_RELACION_SECTION();

            /*" -2934- IF W-ACHOU-RELACIONAMENTO EQUAL 'NAO' */

            if (WAREA_AUXILIAR.W_ACHOU_RELACIONAMENTO == "NAO")
            {

                /*" -2934- PERFORM R0730-GERA-RELACIONAMENTO. */

                R0730_GERA_RELACIONAMENTO_SECTION();
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0710_SAIDA*/

        [StopWatch]
        /*" R0715-DETERMINA-RELACIONAMENTO-SECTION */
        private void R0715_DETERMINA_RELACIONAMENTO_SECTION()
        {
            /*" -2944- MOVE 'R0715-DETERMINA-RELACIONAMENTO' TO PARAGRAFO. */
            _.Move("R0715-DETERMINA-RELACIONAMENTO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2946- MOVE 'SELECT PRODUTOS_SIVPF' TO COMANDO. */
            _.Move("SELECT PRODUTOS_SIVPF", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2949- MOVE 1 TO PRDSIVPF-COD-EMPRESA-SIVPF OF DCLPRODUTOS-SIVPF. */
            _.Move(1, PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_EMPRESA_SIVPF);

            /*" -2952- MOVE R3-COD-PRODUTO OF REG-PROPOSTA-SASSE TO PRDSIVPF-COD-PRODUTO-SIVPF OF DCLPRODUTOS-SIVPF. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_COD_PRODUTO, PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_PRODUTO_SIVPF);

            /*" -2966- PERFORM R0715_DETERMINA_RELACIONAMENTO_DB_SELECT_1 */

            R0715_DETERMINA_RELACIONAMENTO_DB_SELECT_1();

            /*" -2970- IF SQLCODE NOT EQUAL 00 AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -2971- DISPLAY 'PF0103B - FIM ANORMAL' */
                _.Display($"PF0103B - FIM ANORMAL");

                /*" -2972- DISPLAY '          ERRO SELECT TAB. PRODUTOS-SIVPF' */
                _.Display($"          ERRO SELECT TAB. PRODUTOS-SIVPF");

                /*" -2974- DISPLAY '          NOME EMPRESA.................. ' RH-NOME OF REG-HEADER */
                _.Display($"          NOME EMPRESA.................. {LXFPF990.REG_HEADER.RH_NOME}");

                /*" -2976- DISPLAY '          CODIGO DO PRODUTO............. ' PRDSIVPF-COD-PRODUTO-SIVPF */
                _.Display($"          CODIGO DO PRODUTO............. {PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_PRODUTO_SIVPF}");

                /*" -2978- DISPLAY '          NUMERO DA PROPOSTA............  ' R3-NUM-PROPOSTA OF REG-PROPOSTA-SASSE */
                _.Display($"          NUMERO DA PROPOSTA............  {LXFCT004.REG_PROPOSTA_SASSE.R3_NUM_PROPOSTA}");

                /*" -2980- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -2981- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -2983- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


            /*" -2984- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -2986- MOVE 5 TO PRDSIVPF-COD-RELAC OF DCLPRODUTOS-SIVPF */
                _.Move(5, PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_RELAC);

                /*" -2988- MOVE 47 TO PRDSIVPF-COD-PRODUTO-SIVPF OF DCLPRODUTOS-SIVPF */
                _.Move(47, PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_PRODUTO_SIVPF);

                /*" -2990- END-IF. */
            }


            /*" -2994- MOVE PRDSIVPF-COD-RELAC OF DCLPRODUTOS-SIVPF TO W-COD-RELACION, W88-RELACIONAMENTO. */
            _.Move(PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_RELAC, WAREA_AUXILIAR.W_COD_RELACION, WREA88.W88_RELACIONAMENTO);

            /*" -2995- MOVE PRDSIVPF-COD-PRODUTO-SIVPF OF DCLPRODUTOS-SIVPF TO W-PRODUTO. */
            _.Move(PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_PRODUTO_SIVPF, LBWPF002.W_PRODUTO);

        }

        [StopWatch]
        /*" R0715-DETERMINA-RELACIONAMENTO-DB-SELECT-1 */
        public void R0715_DETERMINA_RELACIONAMENTO_DB_SELECT_1()
        {
            /*" -2966- EXEC SQL SELECT DISTINCT COD_PRODUTO_SIVPF, COD_RELAC INTO :DCLPRODUTOS-SIVPF.PRDSIVPF-COD-PRODUTO-SIVPF, :DCLPRODUTOS-SIVPF.PRDSIVPF-COD-RELAC FROM SEGUROS.PRODUTOS_SIVPF WHERE COD_EMPRESA_SIVPF = :DCLPRODUTOS-SIVPF.PRDSIVPF-COD-EMPRESA-SIVPF AND COD_PRODUTO_SIVPF = :DCLPRODUTOS-SIVPF.PRDSIVPF-COD-PRODUTO-SIVPF ORDER BY COD_PRODUTO_SIVPF, COD_RELAC WITH UR END-EXEC. */

            var r0715_DETERMINA_RELACIONAMENTO_DB_SELECT_1_Query1 = new R0715_DETERMINA_RELACIONAMENTO_DB_SELECT_1_Query1()
            {
                PRDSIVPF_COD_EMPRESA_SIVPF = PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_EMPRESA_SIVPF.ToString(),
                PRDSIVPF_COD_PRODUTO_SIVPF = PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_PRODUTO_SIVPF.ToString(),
            };

            var executed_1 = R0715_DETERMINA_RELACIONAMENTO_DB_SELECT_1_Query1.Execute(r0715_DETERMINA_RELACIONAMENTO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PRDSIVPF_COD_PRODUTO_SIVPF, PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_PRODUTO_SIVPF);
                _.Move(executed_1.PRDSIVPF_COD_RELAC, PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_RELAC);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0715_SAIDA*/

        [StopWatch]
        /*" R0720-VERIFICA-EXISTE-RELACION-SECTION */
        private void R0720_VERIFICA_EXISTE_RELACION_SECTION()
        {
            /*" -3005- MOVE 'R0720-VERIFICA-EXISTE-RELACION' TO PARAGRAFO. */
            _.Move("R0720-VERIFICA-EXISTE-RELACION", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3007- MOVE 'SELECT PESSOAS_TIPORELAC' TO COMANDO. */
            _.Move("SELECT PESSOAS_TIPORELAC", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3010- MOVE PESSOA-COD-PESSOA OF DCLPESSOA TO COD-PESSOA OF DCLR-PESSOA-TIPORELAC. */
            _.Move(PESSOA.DCLPESSOA.PESSOA_COD_PESSOA, RTPRELAC.DCLR_PESSOA_TIPORELAC.COD_PESSOA);

            /*" -3013- MOVE W-COD-RELACION TO COD-RELAC OF DCLR-PESSOA-TIPORELAC. */
            _.Move(WAREA_AUXILIAR.W_COD_RELACION, RTPRELAC.DCLR_PESSOA_TIPORELAC.COD_RELAC);

            /*" -3022- PERFORM R0720_VERIFICA_EXISTE_RELACION_DB_SELECT_1 */

            R0720_VERIFICA_EXISTE_RELACION_DB_SELECT_1();

            /*" -3025- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -3026- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -3027- MOVE 'NAO' TO W-ACHOU-RELACIONAMENTO */
                    _.Move("NAO", WAREA_AUXILIAR.W_ACHOU_RELACIONAMENTO);

                    /*" -3028- ELSE */
                }
                else
                {


                    /*" -3029- DISPLAY 'PF0103B - FIM ANORMAL' */
                    _.Display($"PF0103B - FIM ANORMAL");

                    /*" -3030- DISPLAY '          ERRO SELECT TAB. PESSOA-TIPORELAC' */
                    _.Display($"          ERRO SELECT TAB. PESSOA-TIPORELAC");

                    /*" -3032- DISPLAY '          CODIGO PESSOA.................  ' COD-PESSOA OF DCLR-PESSOA-TIPORELAC */
                    _.Display($"          CODIGO PESSOA.................  {RTPRELAC.DCLR_PESSOA_TIPORELAC.COD_PESSOA}");

                    /*" -3034- DISPLAY '          CODIGO RELACIONAMENTO.........  ' COD-RELAC OF DCLR-PESSOA-TIPORELAC */
                    _.Display($"          CODIGO RELACIONAMENTO.........  {RTPRELAC.DCLR_PESSOA_TIPORELAC.COD_RELAC}");

                    /*" -3036- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                    _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                    /*" -3037- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -3038- PERFORM R9999-00-FINALIZAR */

                    R9999_00_FINALIZAR_SECTION();

                    /*" -3039- ELSE */
                }

            }
            else
            {


                /*" -3039- MOVE 'SIM' TO W-ACHOU-RELACIONAMENTO. */
                _.Move("SIM", WAREA_AUXILIAR.W_ACHOU_RELACIONAMENTO);
            }


        }

        [StopWatch]
        /*" R0720-VERIFICA-EXISTE-RELACION-DB-SELECT-1 */
        public void R0720_VERIFICA_EXISTE_RELACION_DB_SELECT_1()
        {
            /*" -3022- EXEC SQL SELECT COD_PESSOA, COD_RELAC INTO :DCLR-PESSOA-TIPORELAC.COD-PESSOA, :DCLR-PESSOA-TIPORELAC.COD-RELAC FROM SEGUROS.R_PESSOA_TIPORELAC WHERE COD_PESSOA = :DCLR-PESSOA-TIPORELAC.COD-PESSOA AND COD_RELAC = :DCLR-PESSOA-TIPORELAC.COD-RELAC WITH UR END-EXEC. */

            var r0720_VERIFICA_EXISTE_RELACION_DB_SELECT_1_Query1 = new R0720_VERIFICA_EXISTE_RELACION_DB_SELECT_1_Query1()
            {
                COD_PESSOA = RTPRELAC.DCLR_PESSOA_TIPORELAC.COD_PESSOA.ToString(),
                COD_RELAC = RTPRELAC.DCLR_PESSOA_TIPORELAC.COD_RELAC.ToString(),
            };

            var executed_1 = R0720_VERIFICA_EXISTE_RELACION_DB_SELECT_1_Query1.Execute(r0720_VERIFICA_EXISTE_RELACION_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.COD_PESSOA, RTPRELAC.DCLR_PESSOA_TIPORELAC.COD_PESSOA);
                _.Move(executed_1.COD_RELAC, RTPRELAC.DCLR_PESSOA_TIPORELAC.COD_RELAC);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0720_SAIDA*/

        [StopWatch]
        /*" R0730-GERA-RELACIONAMENTO-SECTION */
        private void R0730_GERA_RELACIONAMENTO_SECTION()
        {
            /*" -3049- MOVE 'R0730-GERA-RELACIONAMENTO' TO PARAGRAFO */
            _.Move("R0730-GERA-RELACIONAMENTO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3051- MOVE 'INSERT PESSOAS_TIPORELAC' TO COMANDO */
            _.Move("INSERT PESSOAS_TIPORELAC", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3054- MOVE PESSOA-COD-PESSOA OF DCLPESSOA TO COD-PESSOA OF DCLR-PESSOA-TIPORELAC. */
            _.Move(PESSOA.DCLPESSOA.PESSOA_COD_PESSOA, RTPRELAC.DCLR_PESSOA_TIPORELAC.COD_PESSOA);

            /*" -3057- MOVE W-COD-RELACION TO COD-RELAC OF DCLR-PESSOA-TIPORELAC. */
            _.Move(WAREA_AUXILIAR.W_COD_RELACION, RTPRELAC.DCLR_PESSOA_TIPORELAC.COD_RELAC);

            /*" -3061- PERFORM R0730_GERA_RELACIONAMENTO_DB_INSERT_1 */

            R0730_GERA_RELACIONAMENTO_DB_INSERT_1();

            /*" -3064- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -3065- DISPLAY 'PF0103B - FIM ANORMAL' */
                _.Display($"PF0103B - FIM ANORMAL");

                /*" -3066- DISPLAY '          ERRO INSERT TAB. PESSOA-TIPORELAC' */
                _.Display($"          ERRO INSERT TAB. PESSOA-TIPORELAC");

                /*" -3068- DISPLAY '          CODIGO PESSOA.................  ' COD-PESSOA OF DCLR-PESSOA-TIPORELAC */
                _.Display($"          CODIGO PESSOA.................  {RTPRELAC.DCLR_PESSOA_TIPORELAC.COD_PESSOA}");

                /*" -3070- DISPLAY '          CODIGO RELACIONAMENTO.........  ' COD-RELAC OF DCLR-PESSOA-TIPORELAC */
                _.Display($"          CODIGO RELACIONAMENTO.........  {RTPRELAC.DCLR_PESSOA_TIPORELAC.COD_RELAC}");

                /*" -3072- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -3073- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -3073- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R0730-GERA-RELACIONAMENTO-DB-INSERT-1 */
        public void R0730_GERA_RELACIONAMENTO_DB_INSERT_1()
        {
            /*" -3061- EXEC SQL INSERT INTO SEGUROS.R_PESSOA_TIPORELAC VALUES (:DCLR-PESSOA-TIPORELAC.COD-PESSOA, :DCLR-PESSOA-TIPORELAC.COD-RELAC) END-EXEC. */

            var r0730_GERA_RELACIONAMENTO_DB_INSERT_1_Insert1 = new R0730_GERA_RELACIONAMENTO_DB_INSERT_1_Insert1()
            {
                COD_PESSOA = RTPRELAC.DCLR_PESSOA_TIPORELAC.COD_PESSOA.ToString(),
                COD_RELAC = RTPRELAC.DCLR_PESSOA_TIPORELAC.COD_RELAC.ToString(),
            };

            R0730_GERA_RELACIONAMENTO_DB_INSERT_1_Insert1.Execute(r0730_GERA_RELACIONAMENTO_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0730_SAIDA*/

        [StopWatch]
        /*" R0750-TRATA-TAB-IDE-RELACIONAM-SECTION */
        private void R0750_TRATA_TAB_IDE_RELACIONAM_SECTION()
        {
            /*" -3084- PERFORM R0755-OBTER-MAX-ID-RELACIONAM. */

            R0755_OBTER_MAX_ID_RELACIONAM_SECTION();

            /*" -3085- MOVE 'R0750-TRATA-TAB-RELACIONAM' TO PARAGRAFO. */
            _.Move("R0750-TRATA-TAB-RELACIONAM", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3087- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3090- MOVE NUM-IDENTIFICACAO OF DCLIDENTIFICA-RELAC TO W-NUM-IDENTIF. */
            _.Move(IDERELAC.DCLIDENTIFICA_RELAC.NUM_IDENTIFICACAO, WAREA_AUXILIAR.W_NUM_IDENTIF);

            /*" -3093- COMPUTE W-NUM-IDENTIF = W-NUM-IDENTIF + 1. */
            WAREA_AUXILIAR.W_NUM_IDENTIF.Value = WAREA_AUXILIAR.W_NUM_IDENTIF + 1;

            /*" -3096- MOVE W-NUM-IDENTIF TO NUM-IDENTIFICACAO OF DCLIDENTIFICA-RELAC. */
            _.Move(WAREA_AUXILIAR.W_NUM_IDENTIF, IDERELAC.DCLIDENTIFICA_RELAC.NUM_IDENTIFICACAO);

            /*" -3099- MOVE COD-PESSOA OF DCLR-PESSOA-TIPORELAC TO COD-PESSOA OF DCLIDENTIFICA-RELAC. */
            _.Move(RTPRELAC.DCLR_PESSOA_TIPORELAC.COD_PESSOA, IDERELAC.DCLIDENTIFICA_RELAC.COD_PESSOA);

            /*" -3102- MOVE COD-RELAC OF DCLR-PESSOA-TIPORELAC TO COD-RELAC OF DCLIDENTIFICA-RELAC. */
            _.Move(RTPRELAC.DCLR_PESSOA_TIPORELAC.COD_RELAC, IDERELAC.DCLIDENTIFICA_RELAC.COD_RELAC);

            /*" -3105- MOVE 'PF0103B' TO COD-USUARIO OF DCLIDENTIFICA-RELAC. */
            _.Move("PF0103B", IDERELAC.DCLIDENTIFICA_RELAC.COD_USUARIO);

            /*" -3112- PERFORM R0750_TRATA_TAB_IDE_RELACIONAM_DB_INSERT_1 */

            R0750_TRATA_TAB_IDE_RELACIONAM_DB_INSERT_1();

            /*" -3115- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -3116- DISPLAY 'PF0103B - FIM ANORMAL' */
                _.Display($"PF0103B - FIM ANORMAL");

                /*" -3117- DISPLAY '          ERRO INSERT TABELA IDENTIFICA-RELAC.' */
                _.Display($"          ERRO INSERT TABELA IDENTIFICA-RELAC.");

                /*" -3119- DISPLAY '          NUM IDENTIFICACAO.............  ' NUM-IDENTIFICACAO OF DCLIDENTIFICA-RELAC */
                _.Display($"          NUM IDENTIFICACAO.............  {IDERELAC.DCLIDENTIFICA_RELAC.NUM_IDENTIFICACAO}");

                /*" -3121- DISPLAY '          CODIGO PESSOA.................  ' COD-PESSOA OF DCLIDENTIFICA-RELAC */
                _.Display($"          CODIGO PESSOA.................  {IDERELAC.DCLIDENTIFICA_RELAC.COD_PESSOA}");

                /*" -3123- DISPLAY '          CODIGO RELACIONAMENTO.........  ' COD-RELAC OF DCLIDENTIFICA-RELAC */
                _.Display($"          CODIGO RELACIONAMENTO.........  {IDERELAC.DCLIDENTIFICA_RELAC.COD_RELAC}");

                /*" -3125- DISPLAY '          NUMERO PROPOSTA...............  ' R2-NUM-PROPOSTA OF REG-ENDERECO */
                _.Display($"          NUMERO PROPOSTA...............  {LBFPF012.REG_ENDERECO.R2_NUM_PROPOSTA}");

                /*" -3127- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -3128- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -3128- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R0750-TRATA-TAB-IDE-RELACIONAM-DB-INSERT-1 */
        public void R0750_TRATA_TAB_IDE_RELACIONAM_DB_INSERT_1()
        {
            /*" -3112- EXEC SQL INSERT INTO SEGUROS.IDENTIFICA_RELAC VALUES (:DCLIDENTIFICA-RELAC.NUM-IDENTIFICACAO, :DCLIDENTIFICA-RELAC.COD-PESSOA, :DCLIDENTIFICA-RELAC.COD-RELAC, :DCLIDENTIFICA-RELAC.COD-USUARIO, CURRENT TIMESTAMP) END-EXEC. */

            var r0750_TRATA_TAB_IDE_RELACIONAM_DB_INSERT_1_Insert1 = new R0750_TRATA_TAB_IDE_RELACIONAM_DB_INSERT_1_Insert1()
            {
                NUM_IDENTIFICACAO = IDERELAC.DCLIDENTIFICA_RELAC.NUM_IDENTIFICACAO.ToString(),
                COD_PESSOA = IDERELAC.DCLIDENTIFICA_RELAC.COD_PESSOA.ToString(),
                COD_RELAC = IDERELAC.DCLIDENTIFICA_RELAC.COD_RELAC.ToString(),
                COD_USUARIO = IDERELAC.DCLIDENTIFICA_RELAC.COD_USUARIO.ToString(),
            };

            R0750_TRATA_TAB_IDE_RELACIONAM_DB_INSERT_1_Insert1.Execute(r0750_TRATA_TAB_IDE_RELACIONAM_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0750_SAIDA*/

        [StopWatch]
        /*" R0755-OBTER-MAX-ID-RELACIONAM-SECTION */
        private void R0755_OBTER_MAX_ID_RELACIONAM_SECTION()
        {
            /*" -3138- MOVE 'R0755-OBTER-MAX-ID-RELACIONAM' TO PARAGRAFO. */
            _.Move("R0755-OBTER-MAX-ID-RELACIONAM", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3140- MOVE 'MAX IDENTIFICA_RELAC' TO COMANDO. */
            _.Move("MAX IDENTIFICA_RELAC", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3143- MOVE COD-PESSOA OF DCLR-PESSOA-TIPORELAC TO COD-PESSOA OF DCLIDENTIFICA-RELAC. */
            _.Move(RTPRELAC.DCLR_PESSOA_TIPORELAC.COD_PESSOA, IDERELAC.DCLIDENTIFICA_RELAC.COD_PESSOA);

            /*" -3146- MOVE COD-RELAC OF DCLR-PESSOA-TIPORELAC TO COD-RELAC OF DCLIDENTIFICA-RELAC. */
            _.Move(RTPRELAC.DCLR_PESSOA_TIPORELAC.COD_RELAC, IDERELAC.DCLIDENTIFICA_RELAC.COD_RELAC);

            /*" -3151- PERFORM R0755_OBTER_MAX_ID_RELACIONAM_DB_SELECT_1 */

            R0755_OBTER_MAX_ID_RELACIONAM_DB_SELECT_1();

            /*" -3154- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -3155- DISPLAY 'PF0103B - FIM ANORMAL' */
                _.Display($"PF0103B - FIM ANORMAL");

                /*" -3156- DISPLAY '          ERRO SELECT MAX TAB. IDENTIFICA-RELAC' */
                _.Display($"          ERRO SELECT MAX TAB. IDENTIFICA-RELAC");

                /*" -3158- DISPLAY '          CODIGO PESSOA.................  ' COD-PESSOA OF DCLIDENTIFICA-RELAC */
                _.Display($"          CODIGO PESSOA.................  {IDERELAC.DCLIDENTIFICA_RELAC.COD_PESSOA}");

                /*" -3160- DISPLAY '          CODIGO RELACIONAMENTO.........  ' COD-RELAC OF DCLIDENTIFICA-RELAC */
                _.Display($"          CODIGO RELACIONAMENTO.........  {IDERELAC.DCLIDENTIFICA_RELAC.COD_RELAC}");

                /*" -3162- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -3163- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -3163- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R0755-OBTER-MAX-ID-RELACIONAM-DB-SELECT-1 */
        public void R0755_OBTER_MAX_ID_RELACIONAM_DB_SELECT_1()
        {
            /*" -3151- EXEC SQL SELECT VALUE(MAX(NUM_IDENTIFICACAO),0) INTO :DCLIDENTIFICA-RELAC.NUM-IDENTIFICACAO FROM SEGUROS.IDENTIFICA_RELAC WITH UR END-EXEC. */

            var r0755_OBTER_MAX_ID_RELACIONAM_DB_SELECT_1_Query1 = new R0755_OBTER_MAX_ID_RELACIONAM_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0755_OBTER_MAX_ID_RELACIONAM_DB_SELECT_1_Query1.Execute(r0755_OBTER_MAX_ID_RELACIONAM_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.NUM_IDENTIFICACAO, IDERELAC.DCLIDENTIFICA_RELAC.NUM_IDENTIFICACAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0755_SAIDA*/

        [StopWatch]
        /*" R0760-TRATA-PROP-FIDELIZACAO-SECTION */
        private void R0760_TRATA_PROP_FIDELIZACAO_SECTION()
        {
            /*" -3173- MOVE 'R0760-TRATA-PROP-FIDELIZACAO' TO PARAGRAFO */
            _.Move("R0760-TRATA-PROP-FIDELIZACAO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3175- MOVE ' ' TO COMANDO */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3179- MOVE 8 TO R3-ORIGEM-PROPOSTA OF REG-PROPOSTA-SASSE W88-ORIGEM-PROPOSTA. */
            _.Move(8, LXFCT004.REG_PROPOSTA_SASSE.R3_ORIGEM_PROPOSTA_AIC, WREA88.W88_ORIGEM_PROPOSTA);

            /*" -3182- MOVE R3-NUM-PROPOSTA OF REG-PROPOSTA-SASSE TO PROPOFID-NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_NUM_PROPOSTA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF);

            /*" -3185- MOVE 'N' TO PROPOFID-SITUACAO-ENVIO OF DCLPROPOSTA-FIDELIZ. */
            _.Move("N", PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_SITUACAO_ENVIO);

            /*" -3186- IF CANAL-VENDA-PAPEL */

            if (WREA88.CANAL.W88_CANAL_PROPOSTA["CANAL_VENDA_PAPEL"])
            {

                /*" -3188- MOVE 1 TO PROPOFID-CANAL-PROPOSTA OF DCLPROPOSTA-FIDELIZ */
                _.Move(1, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_CANAL_PROPOSTA);

                /*" -3189- ELSE */
            }
            else
            {


                /*" -3192- MOVE W88-CANAL-PROPOSTA TO PROPOFID-CANAL-PROPOSTA OF DCLPROPOSTA-FIDELIZ. */
                _.Move(WREA88.CANAL.W88_CANAL_PROPOSTA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_CANAL_PROPOSTA);
            }


            /*" -3195- MOVE R3-ORIGEM-PROPOSTA OF REG-PROPOSTA-SASSE TO PROPOFID-ORIGEM-PROPOSTA OF DCLPROPOSTA-FIDELIZ. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_ORIGEM_PROPOSTA_AIC, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_ORIGEM_PROPOSTA);

            /*" -3196- IF R3-VAL-TARIFA OF REG-PROPOSTA-SASSE = ZEROS */

            if (LXFCT004.REG_PROPOSTA_SASSE.R3_VAL_TARIFA == 00)
            {

                /*" -3197- PERFORM R0761-00-OBTER-VAL-TARIFA */

                R0761_00_OBTER_VAL_TARIFA_SECTION();

                /*" -3200- MOVE VAL-TARIFA OF DCLTARIFA-BALCAO-CEF TO R3-VAL-TARIFA OF REG-PROPOSTA-SASSE. */
                _.Move(TARIBCEF.DCLTARIFA_BALCAO_CEF.VAL_TARIFA, LXFCT004.REG_PROPOSTA_SASSE.R3_VAL_TARIFA);
            }


            /*" -3202- PERFORM R0762-00-OBTER-COMISSAO */

            R0762_00_OBTER_COMISSAO_SECTION();

            /*" -3206- COMPUTE R3-VAL-COMISSAO OF REG-PROPOSTA-SASSE = VAL-COMISSAO-VG OF DCLFUNDO-COMISSAO-VA + VAL-COMISSAO-AP OF DCLFUNDO-COMISSAO-VA. */
            LXFCT004.REG_PROPOSTA_SASSE.R3_VAL_COMISSAO.Value = FDCOMVA.DCLFUNDO_COMISSAO_VA.VAL_COMISSAO_VG + FDCOMVA.DCLFUNDO_COMISSAO_VA.VAL_COMISSAO_AP;

            /*" -3209- MOVE 'POB' TO R3-SIT-PROPOSTA OF REG-PROPOSTA-SASSE */
            _.Move("POB", LXFCT004.REG_PROPOSTA_SASSE.R3_SIT_PROPOSTA);

            /*" -3212- MOVE 'SUS' TO R3-SIT-COBRANCA OF REG-PROPOSTA-SASSE */
            _.Move("SUS", LXFCT004.REG_PROPOSTA_SASSE.R3_SIT_COBRANCA);

            /*" -3215- MOVE 1 TO R3-SIT-MOTIVO OF REG-PROPOSTA-SASSE. */
            _.Move(1, LXFCT004.REG_PROPOSTA_SASSE.R3_SIT_MOTIVO);

            /*" -3216- IF CONVERSAO-CADASTRADA */

            if (WREA88.W88_CONVERSAO["CONVERSAO_CADASTRADA"])
            {

                /*" -3219- MOVE NUM-SICOB OF DCLCONVERSAO-SICOB TO PROPOFID-NUM-SICOB OF DCLPROPOSTA-FIDELIZ */
                _.Move(COVSICOB.DCLCONVERSAO_SICOB.NUM_SICOB, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_SICOB);

                /*" -3222- MOVE AGEPGTO OF DCLCONVERSAO-SICOB TO R3-AGEPGTO OF REG-PROPOSTA-SASSE */
                _.Move(COVSICOB.DCLCONVERSAO_SICOB.AGEPGTO, LXFCT004.REG_PROPOSTA_SASSE.R3_AGEPGTO);

                /*" -3224- MOVE DATA-OPERACAO OF DCLCONVERSAO-SICOB TO W-DATA-SQL */
                _.Move(COVSICOB.DCLCONVERSAO_SICOB.DATA_OPERACAO, WAREA_AUXILIAR.W_DATA_SQL);

                /*" -3225- MOVE W-DIA-SQL TO W-DIA-TRABALHO */
                _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_DIA_SQL, WAREA_AUXILIAR.FILLER_8.W_DIA_TRABALHO);

                /*" -3226- MOVE W-MES-SQL TO W-MES-TRABALHO */
                _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_MES_SQL, WAREA_AUXILIAR.FILLER_8.W_MES_TRABALHO);

                /*" -3227- MOVE W-ANO-SQL TO W-ANO-TRABALHO */
                _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_ANO_SQL, WAREA_AUXILIAR.FILLER_8.W_ANO_TRABALHO);

                /*" -3230- MOVE W-DATA-TRABALHO TO R3-DATA-CREDITO OF REG-PROPOSTA-SASSE */
                _.Move(WAREA_AUXILIAR.W_DATA_TRABALHO, LXFCT004.REG_PROPOSTA_SASSE.R3_DATA_CREDITO);

                /*" -3232- MOVE DATA-QUITACAO OF DCLCONVERSAO-SICOB TO W-DATA-SQL */
                _.Move(COVSICOB.DCLCONVERSAO_SICOB.DATA_QUITACAO, WAREA_AUXILIAR.W_DATA_SQL);

                /*" -3233- MOVE W-DIA-SQL TO W-DIA-TRABALHO */
                _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_DIA_SQL, WAREA_AUXILIAR.FILLER_8.W_DIA_TRABALHO);

                /*" -3234- MOVE W-MES-SQL TO W-MES-TRABALHO */
                _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_MES_SQL, WAREA_AUXILIAR.FILLER_8.W_MES_TRABALHO);

                /*" -3235- MOVE W-ANO-SQL TO W-ANO-TRABALHO */
                _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_ANO_SQL, WAREA_AUXILIAR.FILLER_8.W_ANO_TRABALHO);

                /*" -3238- MOVE W-DATA-TRABALHO TO R3-DTQITBCO OF REG-PROPOSTA-SASSE */
                _.Move(WAREA_AUXILIAR.W_DATA_TRABALHO, LXFCT004.REG_PROPOSTA_SASSE.R3_DTQITBCO);

                /*" -3240- MOVE VAL-RCAP OF DCLCONVERSAO-SICOB TO R3-VAL-PAGO OF REG-PROPOSTA-SASSE */
                _.Move(COVSICOB.DCLCONVERSAO_SICOB.VAL_RCAP, LXFCT004.REG_PROPOSTA_SASSE.R3_VAL_PAGO);

                /*" -3241- ELSE */
            }
            else
            {


                /*" -3243- PERFORM R0791-OBTER-NUM-SICOB. */

                R0791_OBTER_NUM_SICOB_SECTION();
            }


            /*" -3246- MOVE PROPOFID-NUM-SICOB OF DCLPROPOSTA-FIDELIZ TO R3-NUM-SICOB OF REG-PROPOSTA-SASSE. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_SICOB, LXFCT004.REG_PROPOSTA_SASSE.R3_NUM_SICOB);

            /*" -3249- MOVE NUM-IDENTIFICACAO OF DCLIDENTIFICA-RELAC TO PROPOFID-NUM-IDENTIFICACAO OF DCLPROPOSTA-FIDELIZ. */
            _.Move(IDERELAC.DCLIDENTIFICA_RELAC.NUM_IDENTIFICACAO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_IDENTIFICACAO);

            /*" -3252- MOVE R3-DATA-PROPOSTA OF REG-PROPOSTA-SASSE TO W-DATA-TRABALHO. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_DATA_PROPOSTA, WAREA_AUXILIAR.W_DATA_TRABALHO);

            /*" -3254- MOVE W-DIA-TRABALHO TO W-DIA-SQL OF W-DATA-SQL1. */
            _.Move(WAREA_AUXILIAR.FILLER_8.W_DIA_TRABALHO, WAREA_AUXILIAR.W_DATA_SQL1.W_DIA_SQL);

            /*" -3256- MOVE W-MES-TRABALHO TO W-MES-SQL OF W-DATA-SQL1. */
            _.Move(WAREA_AUXILIAR.FILLER_8.W_MES_TRABALHO, WAREA_AUXILIAR.W_DATA_SQL1.W_MES_SQL);

            /*" -3259- MOVE W-ANO-TRABALHO TO W-ANO-SQL OF W-DATA-SQL1. */
            _.Move(WAREA_AUXILIAR.FILLER_8.W_ANO_TRABALHO, WAREA_AUXILIAR.W_DATA_SQL1.W_ANO_SQL);

            /*" -3263- MOVE '-' TO W-BARRA1 OF W-DATA-SQL1, W-BARRA2 OF W-DATA-SQL1. */
            _.Move("-", WAREA_AUXILIAR.W_DATA_SQL1.W_BARRA1_1);
            _.Move("-", WAREA_AUXILIAR.W_DATA_SQL1.W_BARRA2_1);


            /*" -3266- MOVE W-DATA-SQL TO PROPOFID-DATA-PROPOSTA OF DCLPROPOSTA-FIDELIZ. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_PROPOSTA);

            /*" -3269- MOVE R3-COD-PRODUTO OF REG-PROPOSTA-SASSE TO PROPOFID-COD-PRODUTO-SIVPF OF DCLPROPOSTA-FIDELIZ. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_COD_PRODUTO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF);

            /*" -3272- MOVE PRDSIVPF-COD-EMPRESA-SIVPF OF DCLPRODUTOS-SIVPF TO PROPOFID-COD-EMPRESA-SIVPF OF DCLPROPOSTA-FIDELIZ. */
            _.Move(PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_EMPRESA_SIVPF, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_EMPRESA_SIVPF);

            /*" -3275- MOVE R3-AGECOBR OF REG-PROPOSTA-SASSE TO PROPOFID-AGECOBR OF DCLPROPOSTA-FIDELIZ. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_AGECOBR, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGECOBR);

            /*" -3278- MOVE R3-DIA-DEBITO OF REG-PROPOSTA-SASSE TO PROPOFID-DIA-DEBITO OF DCLPROPOSTA-FIDELIZ. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_DIA_DEBITO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DIA_DEBITO);

            /*" -3281- MOVE R3-OPCAOPAG OF REG-PROPOSTA-SASSE TO PROPOFID-OPCAOPAG OF DCLPROPOSTA-FIDELIZ. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_OPCAOPAG, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPCAOPAG);

            /*" -3284- MOVE R3-AGECTADEB OF REG-PROPOSTA-SASSE TO PROPOFID-AGECTADEB OF DCLPROPOSTA-FIDELIZ. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_CONTA_DEBITO.R3_AGECTADEB, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGECTADEB);

            /*" -3287- MOVE R3-OPRCTADEB OF REG-PROPOSTA-SASSE TO PROPOFID-OPRCTADEB OF DCLPROPOSTA-FIDELIZ. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_CONTA_DEBITO.R3_OPRCTADEB, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPRCTADEB);

            /*" -3290- MOVE R3-NUMCTADEB OF REG-PROPOSTA-SASSE TO PROPOFID-NUMCTADEB OF DCLPROPOSTA-FIDELIZ. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_CONTA_DEBITO.R3_NUMCTADEB, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUMCTADEB);

            /*" -3293- MOVE R3-DIGCTADEB OF REG-PROPOSTA-SASSE TO PROPOFID-DIGCTADEB OF DCLPROPOSTA-FIDELIZ. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_CONTA_DEBITO.R3_DIGCTADEB, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DIGCTADEB);

            /*" -3296- MOVE R3-PCT-DESCONTO OF REG-PROPOSTA-SASSE TO PROPOFID-PERC-DESCONTO OF DCLPROPOSTA-FIDELIZ. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_PCT_DESCONTO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_PERC_DESCONTO);

            /*" -3299- MOVE R3-NRMATRVEN OF REG-PROPOSTA-SASSE TO PROPOFID-NRMATRVEN OF DCLPROPOSTA-FIDELIZ. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_NRMATRVEN, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NRMATRVEN);

            /*" -3305- MOVE ZEROS TO PROPOFID-AGECTAVEN OF DCLPROPOSTA-FIDELIZ PROPOFID-OPRCTAVEN OF DCLPROPOSTA-FIDELIZ PROPOFID-NUMCTAVEN OF DCLPROPOSTA-FIDELIZ PROPOFID-DIGCTAVEN OF DCLPROPOSTA-FIDELIZ. */
            _.Move(0, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGECTAVEN, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPRCTAVEN, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUMCTAVEN, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DIGCTAVEN);

            /*" -3308- MOVE R3-CGC-CONVENENTE OF REG-PROPOSTA-SASSE TO PROPOFID-CGC-CONVENENTE OF DCLPROPOSTA-FIDELIZ. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_CGC_CONVENENTE, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_CGC_CONVENENTE);

            /*" -3311- MOVE R3-NOME-CONVENENTE OF REG-PROPOSTA-SASSE TO PROPOFID-NOME-CONVENENTE OF DCLPROPOSTA-FIDELIZ. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_NOME_CONVENENTE, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NOME_CONVENENTE);

            /*" -3314- MOVE ZEROS TO PROPOFID-NRMATRCON OF DCLPROPOSTA-FIDELIZ. */
            _.Move(0, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NRMATRCON);

            /*" -3316- IF R3-DTQITBCO OF REG-PROPOSTA-SASSE NOT NUMERIC */

            if (!LXFCT004.REG_PROPOSTA_SASSE.R3_DTQITBCO.IsNumeric())
            {

                /*" -3319- MOVE 01010001 TO R3-DTQITBCO OF REG-PROPOSTA-SASSE. */
                _.Move(01010001, LXFCT004.REG_PROPOSTA_SASSE.R3_DTQITBCO);
            }


            /*" -3321- IF R3-DTQITBCO OF REG-PROPOSTA-SASSE EQUAL ZEROS */

            if (LXFCT004.REG_PROPOSTA_SASSE.R3_DTQITBCO == 00)
            {

                /*" -3324- MOVE 01010001 TO R3-DTQITBCO OF REG-PROPOSTA-SASSE. */
                _.Move(01010001, LXFCT004.REG_PROPOSTA_SASSE.R3_DTQITBCO);
            }


            /*" -3327- MOVE R3-DTQITBCO OF REG-PROPOSTA-SASSE TO W-DATA-TRABALHO. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_DTQITBCO, WAREA_AUXILIAR.W_DATA_TRABALHO);

            /*" -3329- MOVE W-DIA-TRABALHO TO W-DIA-SQL OF W-DATA-SQL1. */
            _.Move(WAREA_AUXILIAR.FILLER_8.W_DIA_TRABALHO, WAREA_AUXILIAR.W_DATA_SQL1.W_DIA_SQL);

            /*" -3331- MOVE W-MES-TRABALHO TO W-MES-SQL OF W-DATA-SQL1. */
            _.Move(WAREA_AUXILIAR.FILLER_8.W_MES_TRABALHO, WAREA_AUXILIAR.W_DATA_SQL1.W_MES_SQL);

            /*" -3334- MOVE W-ANO-TRABALHO TO W-ANO-SQL OF W-DATA-SQL1. */
            _.Move(WAREA_AUXILIAR.FILLER_8.W_ANO_TRABALHO, WAREA_AUXILIAR.W_DATA_SQL1.W_ANO_SQL);

            /*" -3338- MOVE '-' TO W-BARRA1 OF W-DATA-SQL1, W-BARRA2 OF W-DATA-SQL1. */
            _.Move("-", WAREA_AUXILIAR.W_DATA_SQL1.W_BARRA1_1);
            _.Move("-", WAREA_AUXILIAR.W_DATA_SQL1.W_BARRA2_1);


            /*" -3341- MOVE W-DATA-SQL TO PROPOFID-DTQITBCO OF DCLPROPOSTA-FIDELIZ. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DTQITBCO);

            /*" -3343- IF R3-DTQITBCO OF REG-PROPOSTA-SASSE EQUAL 01010001 */

            if (LXFCT004.REG_PROPOSTA_SASSE.R3_DTQITBCO == 01010001)
            {

                /*" -3346- MOVE ZEROS TO R3-DTQITBCO OF REG-PROPOSTA-SASSE. */
                _.Move(0, LXFCT004.REG_PROPOSTA_SASSE.R3_DTQITBCO);
            }


            /*" -3349- MOVE R3-VAL-PAGO OF REG-PROPOSTA-SASSE TO PROPOFID-VAL-PAGO OF DCLPROPOSTA-FIDELIZ. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_VAL_PAGO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_VAL_PAGO);

            /*" -3352- MOVE R3-AGEPGTO OF REG-PROPOSTA-SASSE TO PROPOFID-AGEPGTO OF DCLPROPOSTA-FIDELIZ. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_AGEPGTO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGEPGTO);

            /*" -3355- MOVE R3-VAL-TARIFA OF REG-PROPOSTA-SASSE TO PROPOFID-VAL-TARIFA OF DCLPROPOSTA-FIDELIZ. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_VAL_TARIFA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_VAL_TARIFA);

            /*" -3358- MOVE ZEROS TO PROPOFID-VAL-IOF OF DCLPROPOSTA-FIDELIZ. */
            _.Move(0, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_VAL_IOF);

            /*" -3360- IF R3-DATA-CREDITO OF REG-PROPOSTA-SASSE NOT NUMERIC */

            if (!LXFCT004.REG_PROPOSTA_SASSE.R3_DATA_CREDITO.IsNumeric())
            {

                /*" -3363- MOVE 01010001 TO R3-DATA-CREDITO OF REG-PROPOSTA-SASSE. */
                _.Move(01010001, LXFCT004.REG_PROPOSTA_SASSE.R3_DATA_CREDITO);
            }


            /*" -3365- IF R3-DATA-CREDITO OF REG-PROPOSTA-SASSE EQUAL ZEROS */

            if (LXFCT004.REG_PROPOSTA_SASSE.R3_DATA_CREDITO == 00)
            {

                /*" -3368- MOVE 01010001 TO R3-DATA-CREDITO OF REG-PROPOSTA-SASSE. */
                _.Move(01010001, LXFCT004.REG_PROPOSTA_SASSE.R3_DATA_CREDITO);
            }


            /*" -3371- MOVE R3-DATA-CREDITO OF REG-PROPOSTA-SASSE TO W-DATA-TRABALHO. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_DATA_CREDITO, WAREA_AUXILIAR.W_DATA_TRABALHO);

            /*" -3373- MOVE W-DIA-TRABALHO TO W-DIA-SQL OF W-DATA-SQL1. */
            _.Move(WAREA_AUXILIAR.FILLER_8.W_DIA_TRABALHO, WAREA_AUXILIAR.W_DATA_SQL1.W_DIA_SQL);

            /*" -3375- MOVE W-MES-TRABALHO TO W-MES-SQL OF W-DATA-SQL1. */
            _.Move(WAREA_AUXILIAR.FILLER_8.W_MES_TRABALHO, WAREA_AUXILIAR.W_DATA_SQL1.W_MES_SQL);

            /*" -3378- MOVE W-ANO-TRABALHO TO W-ANO-SQL OF W-DATA-SQL1. */
            _.Move(WAREA_AUXILIAR.FILLER_8.W_ANO_TRABALHO, WAREA_AUXILIAR.W_DATA_SQL1.W_ANO_SQL);

            /*" -3382- MOVE '-' TO W-BARRA1 OF W-DATA-SQL1, W-BARRA2 OF W-DATA-SQL1. */
            _.Move("-", WAREA_AUXILIAR.W_DATA_SQL1.W_BARRA1_1);
            _.Move("-", WAREA_AUXILIAR.W_DATA_SQL1.W_BARRA2_1);


            /*" -3385- MOVE W-DATA-SQL TO PROPOFID-DATA-CREDITO OF DCLPROPOSTA-FIDELIZ. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_CREDITO);

            /*" -3387- IF R3-DATA-CREDITO OF REG-PROPOSTA-SASSE EQUAL 01010001 */

            if (LXFCT004.REG_PROPOSTA_SASSE.R3_DATA_CREDITO == 01010001)
            {

                /*" -3390- MOVE ZEROS TO R3-DATA-CREDITO OF REG-PROPOSTA-SASSE. */
                _.Move(0, LXFCT004.REG_PROPOSTA_SASSE.R3_DATA_CREDITO);
            }


            /*" -3393- MOVE R3-VAL-COMISSAO OF REG-PROPOSTA-SASSE TO PROPOFID-VAL-COMISSAO OF DCLPROPOSTA-FIDELIZ. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_VAL_COMISSAO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_VAL_COMISSAO);

            /*" -3396- MOVE 'CAV' TO PROPOFID-SIT-PROPOSTA OF DCLPROPOSTA-FIDELIZ. */
            _.Move("CAV", PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_SIT_PROPOSTA);

            /*" -3399- MOVE 'PF0103B' TO PROPOFID-COD-USUARIO OF DCLPROPOSTA-FIDELIZ. */
            _.Move("PF0103B", PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_USUARIO);

            /*" -3402- MOVE ZEROS TO PROPOFID-NSAS-SIVPF OF DCLPROPOSTA-FIDELIZ. */
            _.Move(0, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NSAS_SIVPF);

            /*" -3405- MOVE W-QTD-LD-SIVPF-3 TO PROPOFID-NSL OF DCLPROPOSTA-FIDELIZ. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_SIVPF_3, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NSL);

            /*" -3408- MOVE RH-NSAS OF REG-HEADER TO PROPOFID-NSAC-SIVPF OF DCLPROPOSTA-FIDELIZ. */
            _.Move(LXFPF990.REG_HEADER.RH_NSAS, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NSAC_SIVPF);

            /*" -3411- MOVE PESSOA-COD-PESSOA OF DCLPESSOA TO PROPOFID-COD-PESSOA OF DCLPROPOSTA-FIDELIZ. */
            _.Move(PESSOA.DCLPESSOA.PESSOA_COD_PESSOA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PESSOA);

            /*" -3414- MOVE R3-OPCAO-COBER OF REG-PROPOSTA-SASSE TO PROPOFID-OPCAO-COBER OF DCLPROPOSTA-FIDELIZ. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_OPCAO_COBER, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPCAO_COBER);

            /*" -3417- MOVE R3-COD-PLANO OF REG-PROPOSTA-SASSE TO PROPOFID-COD-PLANO OF DCLPROPOSTA-FIDELIZ. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_COD_PLANO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PLANO);

            /*" -3420- MOVE R1-NOME-CONJUGE OF REG-CLIENTES TO PROPOFID-NOME-CONJUGE OF DCLPROPOSTA-FIDELIZ. */
            _.Move(LBFPF011.REG_CLIENTES.R1_NOME_CONJUGE, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NOME_CONJUGE);

            /*" -3423- MOVE R1-DTNASC-CONJUGE OF REG-CLIENTES TO W-DATA-TRABALHO. */
            _.Move(LBFPF011.REG_CLIENTES.R1_DTNASC_CONJUGE, WAREA_AUXILIAR.W_DATA_TRABALHO);

            /*" -3424- IF W-DATA-TRABALHO NOT NUMERIC */

            if (!WAREA_AUXILIAR.W_DATA_TRABALHO.IsNumeric())
            {

                /*" -3426- MOVE -1 TO VIND-DTNASC-ESPOSA */
                _.Move(-1, VIND_DTNASC_ESPOSA);

                /*" -3427- ELSE */
            }
            else
            {


                /*" -3429- IF W-DATA-TRABALHO EQUAL 01010001 OR W-DATA-TRABALHO EQUAL ZEROS */

                if (WAREA_AUXILIAR.W_DATA_TRABALHO == 01010001 || WAREA_AUXILIAR.W_DATA_TRABALHO == 00)
                {

                    /*" -3431- MOVE -1 TO VIND-DTNASC-ESPOSA */
                    _.Move(-1, VIND_DTNASC_ESPOSA);

                    /*" -3432- ELSE */
                }
                else
                {


                    /*" -3434- MOVE W-DIA-TRABALHO TO W-DIA-SQL OF W-DATA-SQL1 */
                    _.Move(WAREA_AUXILIAR.FILLER_8.W_DIA_TRABALHO, WAREA_AUXILIAR.W_DATA_SQL1.W_DIA_SQL);

                    /*" -3436- MOVE W-MES-TRABALHO TO W-MES-SQL OF W-DATA-SQL1 */
                    _.Move(WAREA_AUXILIAR.FILLER_8.W_MES_TRABALHO, WAREA_AUXILIAR.W_DATA_SQL1.W_MES_SQL);

                    /*" -3439- MOVE W-ANO-TRABALHO TO W-ANO-SQL OF W-DATA-SQL1 */
                    _.Move(WAREA_AUXILIAR.FILLER_8.W_ANO_TRABALHO, WAREA_AUXILIAR.W_DATA_SQL1.W_ANO_SQL);

                    /*" -3443- MOVE '-' TO W-BARRA1 OF W-DATA-SQL1, W-BARRA2 OF W-DATA-SQL1 */
                    _.Move("-", WAREA_AUXILIAR.W_DATA_SQL1.W_BARRA1_1);
                    _.Move("-", WAREA_AUXILIAR.W_DATA_SQL1.W_BARRA2_1);


                    /*" -3446- MOVE W-DATA-SQL TO PROPOFID-DATA-NASC-CONJUGE OF DCLPROPOSTA-FIDELIZ. */
                    _.Move(WAREA_AUXILIAR.W_DATA_SQL, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_NASC_CONJUGE);
                }

            }


            /*" -3449- MOVE R1-CBO-CONJUGE OF REG-CLIENTES TO PROPOFID-PROFISSAO-CONJUGE OF DCLPROPOSTA-FIDELIZ. */
            _.Move(LBFPF011.REG_CLIENTES.R1_CBO_CONJUGE, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_PROFISSAO_CONJUGE);

            /*" -3452- MOVE R1-RENDA-INDIVIDUAL OF REG-CLIENTES TO PROPOFID-FAIXA-RENDA-IND OF DCLPROPOSTA-FIDELIZ. */
            _.Move(LBFPF011.REG_CLIENTES.R1_RENDA_INDIVIDUAL, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_FAIXA_RENDA_IND);

            /*" -3455- MOVE R1-RENDA-FAMILIAR OF REG-CLIENTES TO PROPOFID-FAIXA-RENDA-FAM OF DCLPROPOSTA-FIDELIZ. */
            _.Move(LBFPF011.REG_CLIENTES.R1_RENDA_FAMILIAR, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_FAIXA_RENDA_FAM);

            /*" -3457- MOVE 'N' TO PROPOFID-IND-TIPO-CONTA OF DCLPROPOSTA-FIDELIZ. */
            _.Move("N", PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_IND_TIPO_CONTA);

            /*" -3508- PERFORM R0760_TRATA_PROP_FIDELIZACAO_DB_INSERT_1 */

            R0760_TRATA_PROP_FIDELIZACAO_DB_INSERT_1();

            /*" -3511- IF SQLCODE NOT EQUAL 00 AND NOT -803 */

            if (!DB.SQLCODE.In("00", "-803"))
            {

                /*" -3512- DISPLAY 'ENTREI .... ' SQLCODE */
                _.Display($"ENTREI .... {DB.SQLCODE}");

                /*" -3513- DISPLAY 'PF0103B - FIM ANORMAL' */
                _.Display($"PF0103B - FIM ANORMAL");

                /*" -3514- DISPLAY '          ERRO INSERT TABELA PROPOSTA FIDELIZ' */
                _.Display($"          ERRO INSERT TABELA PROPOSTA FIDELIZ");

                /*" -3516- DISPLAY '          CODIGO PESSOA.................  ' PROPOFID-COD-PESSOA OF DCLPROPOSTA-FIDELIZ */
                _.Display($"          CODIGO PESSOA.................  {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PESSOA}");

                /*" -3518- DISPLAY '          NUMERO PROPOSTA...............  ' PROPOFID-NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ */
                _.Display($"          NUMERO PROPOSTA...............  {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}");

                /*" -3520- DISPLAY '          COD-EMPRESA...................  ' PROPOFID-COD-EMPRESA-SIVPF OF DCLPROPOSTA-FIDELIZ */
                _.Display($"          COD-EMPRESA...................  {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_EMPRESA_SIVPF}");

                /*" -3522- DISPLAY '          COD-PRODUTO-SIVPF.............  ' PROPOFID-COD-PRODUTO-SIVPF OF DCLPROPOSTA-FIDELIZ */
                _.Display($"          COD-PRODUTO-SIVPF.............  {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF}");

                /*" -3524- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -3525- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -3525- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R0760-TRATA-PROP-FIDELIZACAO-DB-INSERT-1 */
        public void R0760_TRATA_PROP_FIDELIZACAO_DB_INSERT_1()
        {
            /*" -3508- EXEC SQL INSERT INTO SEGUROS.PROPOSTA_FIDELIZ VALUES (:DCLPROPOSTA-FIDELIZ.PROPOFID-NUM-PROPOSTA-SIVPF, :DCLPROPOSTA-FIDELIZ.PROPOFID-NUM-IDENTIFICACAO, :DCLPROPOSTA-FIDELIZ.PROPOFID-COD-EMPRESA-SIVPF, :DCLPROPOSTA-FIDELIZ.PROPOFID-COD-PESSOA, :DCLPROPOSTA-FIDELIZ.PROPOFID-NUM-SICOB, :DCLPROPOSTA-FIDELIZ.PROPOFID-DATA-PROPOSTA, :DCLPROPOSTA-FIDELIZ.PROPOFID-COD-PRODUTO-SIVPF, :DCLPROPOSTA-FIDELIZ.PROPOFID-AGECOBR, :DCLPROPOSTA-FIDELIZ.PROPOFID-DIA-DEBITO, :DCLPROPOSTA-FIDELIZ.PROPOFID-OPCAOPAG, :DCLPROPOSTA-FIDELIZ.PROPOFID-AGECTADEB, :DCLPROPOSTA-FIDELIZ.PROPOFID-OPRCTADEB, :DCLPROPOSTA-FIDELIZ.PROPOFID-NUMCTADEB, :DCLPROPOSTA-FIDELIZ.PROPOFID-DIGCTADEB, :DCLPROPOSTA-FIDELIZ.PROPOFID-PERC-DESCONTO, :DCLPROPOSTA-FIDELIZ.PROPOFID-NRMATRVEN, :DCLPROPOSTA-FIDELIZ.PROPOFID-AGECTAVEN, :DCLPROPOSTA-FIDELIZ.PROPOFID-OPRCTAVEN, :DCLPROPOSTA-FIDELIZ.PROPOFID-NUMCTAVEN, :DCLPROPOSTA-FIDELIZ.PROPOFID-DIGCTAVEN, :DCLPROPOSTA-FIDELIZ.PROPOFID-CGC-CONVENENTE, :DCLPROPOSTA-FIDELIZ.PROPOFID-NOME-CONVENENTE, :DCLPROPOSTA-FIDELIZ.PROPOFID-NRMATRCON, :DCLPROPOSTA-FIDELIZ.PROPOFID-DTQITBCO, :DCLPROPOSTA-FIDELIZ.PROPOFID-VAL-PAGO, :DCLPROPOSTA-FIDELIZ.PROPOFID-AGEPGTO, :DCLPROPOSTA-FIDELIZ.PROPOFID-VAL-TARIFA, :DCLPROPOSTA-FIDELIZ.PROPOFID-VAL-IOF, :DCLPROPOSTA-FIDELIZ.PROPOFID-DATA-CREDITO, :DCLPROPOSTA-FIDELIZ.PROPOFID-VAL-COMISSAO, :DCLPROPOSTA-FIDELIZ.PROPOFID-SIT-PROPOSTA, :DCLPROPOSTA-FIDELIZ.PROPOFID-COD-USUARIO, :DCLPROPOSTA-FIDELIZ.PROPOFID-CANAL-PROPOSTA, :DCLPROPOSTA-FIDELIZ.PROPOFID-NSAS-SIVPF, :DCLPROPOSTA-FIDELIZ.PROPOFID-ORIGEM-PROPOSTA, CURRENT TIMESTAMP, :DCLPROPOSTA-FIDELIZ.PROPOFID-NSL, :DCLPROPOSTA-FIDELIZ.PROPOFID-NSAC-SIVPF, :DCLPROPOSTA-FIDELIZ.PROPOFID-SITUACAO-ENVIO, :DCLPROPOSTA-FIDELIZ.PROPOFID-OPCAO-COBER, :DCLPROPOSTA-FIDELIZ.PROPOFID-COD-PLANO, :DCLPROPOSTA-FIDELIZ.PROPOFID-NOME-CONJUGE, :DCLPROPOSTA-FIDELIZ.PROPOFID-DATA-NASC-CONJUGE :VIND-DTNASC-ESPOSA, :DCLPROPOSTA-FIDELIZ.PROPOFID-PROFISSAO-CONJUGE, :DCLPROPOSTA-FIDELIZ.PROPOFID-FAIXA-RENDA-IND, :DCLPROPOSTA-FIDELIZ.PROPOFID-FAIXA-RENDA-FAM, NULL, :DCLPROPOSTA-FIDELIZ.PROPOFID-IND-TIPO-CONTA) END-EXEC. */

            var r0760_TRATA_PROP_FIDELIZACAO_DB_INSERT_1_Insert1 = new R0760_TRATA_PROP_FIDELIZACAO_DB_INSERT_1_Insert1()
            {
                PROPOFID_NUM_PROPOSTA_SIVPF = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF.ToString(),
                PROPOFID_NUM_IDENTIFICACAO = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_IDENTIFICACAO.ToString(),
                PROPOFID_COD_EMPRESA_SIVPF = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_EMPRESA_SIVPF.ToString(),
                PROPOFID_COD_PESSOA = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PESSOA.ToString(),
                PROPOFID_NUM_SICOB = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_SICOB.ToString(),
                PROPOFID_DATA_PROPOSTA = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_PROPOSTA.ToString(),
                PROPOFID_COD_PRODUTO_SIVPF = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF.ToString(),
                PROPOFID_AGECOBR = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGECOBR.ToString(),
                PROPOFID_DIA_DEBITO = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DIA_DEBITO.ToString(),
                PROPOFID_OPCAOPAG = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPCAOPAG.ToString(),
                PROPOFID_AGECTADEB = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGECTADEB.ToString(),
                PROPOFID_OPRCTADEB = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPRCTADEB.ToString(),
                PROPOFID_NUMCTADEB = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUMCTADEB.ToString(),
                PROPOFID_DIGCTADEB = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DIGCTADEB.ToString(),
                PROPOFID_PERC_DESCONTO = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_PERC_DESCONTO.ToString(),
                PROPOFID_NRMATRVEN = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NRMATRVEN.ToString(),
                PROPOFID_AGECTAVEN = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGECTAVEN.ToString(),
                PROPOFID_OPRCTAVEN = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPRCTAVEN.ToString(),
                PROPOFID_NUMCTAVEN = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUMCTAVEN.ToString(),
                PROPOFID_DIGCTAVEN = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DIGCTAVEN.ToString(),
                PROPOFID_CGC_CONVENENTE = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_CGC_CONVENENTE.ToString(),
                PROPOFID_NOME_CONVENENTE = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NOME_CONVENENTE.ToString(),
                PROPOFID_NRMATRCON = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NRMATRCON.ToString(),
                PROPOFID_DTQITBCO = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DTQITBCO.ToString(),
                PROPOFID_VAL_PAGO = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_VAL_PAGO.ToString(),
                PROPOFID_AGEPGTO = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGEPGTO.ToString(),
                PROPOFID_VAL_TARIFA = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_VAL_TARIFA.ToString(),
                PROPOFID_VAL_IOF = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_VAL_IOF.ToString(),
                PROPOFID_DATA_CREDITO = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_CREDITO.ToString(),
                PROPOFID_VAL_COMISSAO = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_VAL_COMISSAO.ToString(),
                PROPOFID_SIT_PROPOSTA = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_SIT_PROPOSTA.ToString(),
                PROPOFID_COD_USUARIO = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_USUARIO.ToString(),
                PROPOFID_CANAL_PROPOSTA = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_CANAL_PROPOSTA.ToString(),
                PROPOFID_NSAS_SIVPF = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NSAS_SIVPF.ToString(),
                PROPOFID_ORIGEM_PROPOSTA = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_ORIGEM_PROPOSTA.ToString(),
                PROPOFID_NSL = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NSL.ToString(),
                PROPOFID_NSAC_SIVPF = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NSAC_SIVPF.ToString(),
                PROPOFID_SITUACAO_ENVIO = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_SITUACAO_ENVIO.ToString(),
                PROPOFID_OPCAO_COBER = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPCAO_COBER.ToString(),
                PROPOFID_COD_PLANO = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PLANO.ToString(),
                PROPOFID_NOME_CONJUGE = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NOME_CONJUGE.ToString(),
                PROPOFID_DATA_NASC_CONJUGE = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_NASC_CONJUGE.ToString(),
                VIND_DTNASC_ESPOSA = VIND_DTNASC_ESPOSA.ToString(),
                PROPOFID_PROFISSAO_CONJUGE = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_PROFISSAO_CONJUGE.ToString(),
                PROPOFID_FAIXA_RENDA_IND = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_FAIXA_RENDA_IND.ToString(),
                PROPOFID_FAIXA_RENDA_FAM = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_FAIXA_RENDA_FAM.ToString(),
                PROPOFID_IND_TIPO_CONTA = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_IND_TIPO_CONTA.ToString(),
            };

            R0760_TRATA_PROP_FIDELIZACAO_DB_INSERT_1_Insert1.Execute(r0760_TRATA_PROP_FIDELIZACAO_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0760_SAIDA*/

        [StopWatch]
        /*" R0761-00-OBTER-VAL-TARIFA-SECTION */
        private void R0761_00_OBTER_VAL_TARIFA_SECTION()
        {
            /*" -3535- MOVE 'R0761-00-OBTER-VAL-TARIFA' TO PARAGRAFO. */
            _.Move("R0761-00-OBTER-VAL-TARIFA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3537- MOVE 'SELECT TARIFA-BALCAO-CEF' TO COMANDO. */
            _.Move("SELECT TARIFA-BALCAO-CEF", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3540- MOVE PROPOFID-NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ TO NUM-CERTIFICADO OF DCLTARIFA-BALCAO-CEF. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF, TARIBCEF.DCLTARIFA_BALCAO_CEF.NUM_CERTIFICADO);

            /*" -3552- PERFORM R0761_00_OBTER_VAL_TARIFA_DB_SELECT_1 */

            R0761_00_OBTER_VAL_TARIFA_DB_SELECT_1();

            /*" -3555- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -3556- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -3557- MOVE ZEROS TO VAL-TARIFA OF DCLTARIFA-BALCAO-CEF */
                    _.Move(0, TARIBCEF.DCLTARIFA_BALCAO_CEF.VAL_TARIFA);

                    /*" -3558- ELSE */
                }
                else
                {


                    /*" -3559- DISPLAY 'PF0103B - FIM ANORMAL' */
                    _.Display($"PF0103B - FIM ANORMAL");

                    /*" -3560- DISPLAY '          ERRO SELECT TAB. TARIFA-BALCAO-CEF' */
                    _.Display($"          ERRO SELECT TAB. TARIFA-BALCAO-CEF");

                    /*" -3562- DISPLAY '          NUMERO CERTIFICADO........ ' NUM-CERTIFICADO OF DCLTARIFA-BALCAO-CEF */
                    _.Display($"          NUMERO CERTIFICADO........ {TARIBCEF.DCLTARIFA_BALCAO_CEF.NUM_CERTIFICADO}");

                    /*" -3564- DISPLAY '          SQLCODE................... ' SQLCODE */
                    _.Display($"          SQLCODE................... {DB.SQLCODE}");

                    /*" -3565- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -3565- PERFORM R9999-00-FINALIZAR. */

                    R9999_00_FINALIZAR_SECTION();
                }

            }


        }

        [StopWatch]
        /*" R0761-00-OBTER-VAL-TARIFA-DB-SELECT-1 */
        public void R0761_00_OBTER_VAL_TARIFA_DB_SELECT_1()
        {
            /*" -3552- EXEC SQL SELECT VAL_TARIFA INTO :DCLTARIFA-BALCAO-CEF.VAL-TARIFA FROM SEGUROS.TARIFA_BALCAO_CEF WHERE COD_EMPRESA = 0 AND NUM_MATRICULA = 9999999 AND TIPO_FUNCIONARIO = '5' AND NUM_CERTIFICADO = :DCLTARIFA-BALCAO-CEF.NUM-CERTIFICADO WITH UR END-EXEC. */

            var r0761_00_OBTER_VAL_TARIFA_DB_SELECT_1_Query1 = new R0761_00_OBTER_VAL_TARIFA_DB_SELECT_1_Query1()
            {
                NUM_CERTIFICADO = TARIBCEF.DCLTARIFA_BALCAO_CEF.NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = R0761_00_OBTER_VAL_TARIFA_DB_SELECT_1_Query1.Execute(r0761_00_OBTER_VAL_TARIFA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.VAL_TARIFA, TARIBCEF.DCLTARIFA_BALCAO_CEF.VAL_TARIFA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0761_SAIDA*/

        [StopWatch]
        /*" R0762-00-OBTER-COMISSAO-SECTION */
        private void R0762_00_OBTER_COMISSAO_SECTION()
        {
            /*" -3575- MOVE 'R0762-00-OBTER-COMISSAO' TO PARAGRAFO. */
            _.Move("R0762-00-OBTER-COMISSAO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3577- MOVE 'SELECT FUNDOCOMISVA' TO COMANDO. */
            _.Move("SELECT FUNDOCOMISVA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3580- MOVE PROPOFID-NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ TO NUM-CERTIFICADO OF DCLFUNDO-COMISSAO-VA */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF, FDCOMVA.DCLFUNDO_COMISSAO_VA.NUM_CERTIFICADO);

            /*" -3583- MOVE 1101 TO COD-OPERACAO OF DCLFUNDO-COMISSAO-VA */
            _.Move(1101, FDCOMVA.DCLFUNDO_COMISSAO_VA.COD_OPERACAO);

            /*" -3594- PERFORM R0762_00_OBTER_COMISSAO_DB_DECLARE_1 */

            R0762_00_OBTER_COMISSAO_DB_DECLARE_1();

            /*" -3597- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -3598- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -3601- MOVE ZEROS TO VAL-COMISSAO-VG OF DCLFUNDO-COMISSAO-VA, VAL-COMISSAO-AP OF DCLFUNDO-COMISSAO-VA */
                    _.Move(0, FDCOMVA.DCLFUNDO_COMISSAO_VA.VAL_COMISSAO_VG, FDCOMVA.DCLFUNDO_COMISSAO_VA.VAL_COMISSAO_AP);

                    /*" -3602- GO TO R0762-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0762_SAIDA*/ //GOTO
                    return;

                    /*" -3603- ELSE */
                }
                else
                {


                    /*" -3604- DISPLAY 'PF0103B - FIM ANORMAL 1' */
                    _.Display($"PF0103B - FIM ANORMAL 1");

                    /*" -3605- DISPLAY '          ERRO DECLARE CURSOR FUNDOCOMISVA' */
                    _.Display($"          ERRO DECLARE CURSOR FUNDOCOMISVA");

                    /*" -3607- DISPLAY '          NUMERO CERTIFICADO.............. ' NUM-CERTIFICADO OF DCLFUNDO-COMISSAO-VA */
                    _.Display($"          NUMERO CERTIFICADO.............. {FDCOMVA.DCLFUNDO_COMISSAO_VA.NUM_CERTIFICADO}");

                    /*" -3609- DISPLAY '          SQLCODE......................... ' SQLCODE */
                    _.Display($"          SQLCODE......................... {DB.SQLCODE}");

                    /*" -3610- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -3612- PERFORM R9999-00-FINALIZAR. */

                    R9999_00_FINALIZAR_SECTION();
                }

            }


            /*" -3612- PERFORM R0762_00_OBTER_COMISSAO_DB_OPEN_1 */

            R0762_00_OBTER_COMISSAO_DB_OPEN_1();

            /*" -3615- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -3616- DISPLAY 'PF0103B - FIM ANORMAL 2' */
                _.Display($"PF0103B - FIM ANORMAL 2");

                /*" -3617- DISPLAY '          ERRO OPEN CURSOR FUNDOCOMISVA' */
                _.Display($"          ERRO OPEN CURSOR FUNDOCOMISVA");

                /*" -3619- DISPLAY '          NUMERO CERTIFICADO........... ' NUM-CERTIFICADO OF DCLFUNDO-COMISSAO-VA */
                _.Display($"          NUMERO CERTIFICADO........... {FDCOMVA.DCLFUNDO_COMISSAO_VA.NUM_CERTIFICADO}");

                /*" -3621- DISPLAY '          SQLCODE...................... ' SQLCODE */
                _.Display($"          SQLCODE...................... {DB.SQLCODE}");

                /*" -3622- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -3624- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


            /*" -3630- PERFORM R0762_00_OBTER_COMISSAO_DB_FETCH_1 */

            R0762_00_OBTER_COMISSAO_DB_FETCH_1();

            /*" -3633- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -3634- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -3637- MOVE ZEROS TO VAL-COMISSAO-VG OF DCLFUNDO-COMISSAO-VA, VAL-COMISSAO-AP OF DCLFUNDO-COMISSAO-VA */
                    _.Move(0, FDCOMVA.DCLFUNDO_COMISSAO_VA.VAL_COMISSAO_VG, FDCOMVA.DCLFUNDO_COMISSAO_VA.VAL_COMISSAO_AP);

                    /*" -3638- ELSE */
                }
                else
                {


                    /*" -3639- DISPLAY 'PF0103B - FIM ANORMAL 3' */
                    _.Display($"PF0103B - FIM ANORMAL 3");

                    /*" -3640- DISPLAY '          ERRO SELECT CURSOR FUNDOCOMISVA' */
                    _.Display($"          ERRO SELECT CURSOR FUNDOCOMISVA");

                    /*" -3642- DISPLAY '          NUMERO CERTIFICADO............. ' NUM-CERTIFICADO OF DCLFUNDO-COMISSAO-VA */
                    _.Display($"          NUMERO CERTIFICADO............. {FDCOMVA.DCLFUNDO_COMISSAO_VA.NUM_CERTIFICADO}");

                    /*" -3644- DISPLAY '          SQLCODE........................ ' SQLCODE */
                    _.Display($"          SQLCODE........................ {DB.SQLCODE}");

                    /*" -3645- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -3647- PERFORM R9999-00-FINALIZAR. */

                    R9999_00_FINALIZAR_SECTION();
                }

            }


            /*" -3647- PERFORM R0762_00_OBTER_COMISSAO_DB_CLOSE_1 */

            R0762_00_OBTER_COMISSAO_DB_CLOSE_1();

            /*" -3650- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -3651- DISPLAY 'PF0612B - FIM ANORMAL 4' */
                _.Display($"PF0612B - FIM ANORMAL 4");

                /*" -3652- DISPLAY '          ERRO CLOSE CURSOR FUNDOCOMISVA' */
                _.Display($"          ERRO CLOSE CURSOR FUNDOCOMISVA");

                /*" -3654- DISPLAY '          NUMERO CERTIFICADO............ ' NUM-CERTIFICADO OF DCLFUNDO-COMISSAO-VA */
                _.Display($"          NUMERO CERTIFICADO............ {FDCOMVA.DCLFUNDO_COMISSAO_VA.NUM_CERTIFICADO}");

                /*" -3656- DISPLAY '          SQLCODE....................... ' SQLCODE */
                _.Display($"          SQLCODE....................... {DB.SQLCODE}");

                /*" -3657- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -3657- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R0762-00-OBTER-COMISSAO-DB-OPEN-1 */
        public void R0762_00_OBTER_COMISSAO_DB_OPEN_1()
        {
            /*" -3612- EXEC SQL OPEN FUNDOCOMISVA END-EXEC. */

            FUNDOCOMISVA.Open();

        }

        [StopWatch]
        /*" R6200-00-DECLARE-FONTES-DB-DECLARE-1 */
        public void R6200_00_DECLARE_FONTES_DB_DECLARE_1()
        {
            /*" -4387- EXEC SQL DECLARE CFONTES CURSOR FOR SELECT COD_FONTE, ULT_PROP_AUTOMAT FROM SEGUROS.FONTES ORDER BY COD_FONTE WITH UR END-EXEC. */
            CFONTES = new PF0103B_CFONTES(false);
            string GetQuery_CFONTES()
            {
                var query = @$"SELECT COD_FONTE
							, 
							ULT_PROP_AUTOMAT 
							FROM SEGUROS.FONTES 
							ORDER BY COD_FONTE";

                return query;
            }
            CFONTES.GetQueryEvent += GetQuery_CFONTES;

        }

        [StopWatch]
        /*" R0762-00-OBTER-COMISSAO-DB-FETCH-1 */
        public void R0762_00_OBTER_COMISSAO_DB_FETCH_1()
        {
            /*" -3630- EXEC SQL FETCH FUNDOCOMISVA INTO :DCLFUNDO-COMISSAO-VA.NUM-CERTIFICADO , :DCLFUNDO-COMISSAO-VA.VAL-COMISSAO-VG , :DCLFUNDO-COMISSAO-VA.VAL-COMISSAO-AP END-EXEC. */

            if (FUNDOCOMISVA.Fetch())
            {
                _.Move(FUNDOCOMISVA.DCLFUNDO_COMISSAO_VA_NUM_CERTIFICADO, FDCOMVA.DCLFUNDO_COMISSAO_VA.NUM_CERTIFICADO);
                _.Move(FUNDOCOMISVA.DCLFUNDO_COMISSAO_VA_VAL_COMISSAO_VG, FDCOMVA.DCLFUNDO_COMISSAO_VA.VAL_COMISSAO_VG);
                _.Move(FUNDOCOMISVA.DCLFUNDO_COMISSAO_VA_VAL_COMISSAO_AP, FDCOMVA.DCLFUNDO_COMISSAO_VA.VAL_COMISSAO_AP);
            }

        }

        [StopWatch]
        /*" R0762-00-OBTER-COMISSAO-DB-CLOSE-1 */
        public void R0762_00_OBTER_COMISSAO_DB_CLOSE_1()
        {
            /*" -3647- EXEC SQL CLOSE FUNDOCOMISVA END-EXEC. */

            FUNDOCOMISVA.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0762_SAIDA*/

        [StopWatch]
        /*" R0790-GERA-HIST-FIDELIZACAO-SECTION */
        private void R0790_GERA_HIST_FIDELIZACAO_SECTION()
        {
            /*" -3667- MOVE 'R0790-GERA-HIST-FIDELIZACAO' TO PARAGRAFO. */
            _.Move("R0790-GERA-HIST-FIDELIZACAO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3669- MOVE 'INSERT HIST-PROP-FIDELIZ' TO COMANDO. */
            _.Move("INSERT HIST-PROP-FIDELIZ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3672- MOVE PROPOFID-NUM-IDENTIFICACAO OF DCLPROPOSTA-FIDELIZ TO PROPFIDH-NUM-IDENTIFICACAO. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_IDENTIFICACAO, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NUM_IDENTIFICACAO);

            /*" -3675- MOVE SISTEMAS-DATA-MOV-ABERTO OF DCLSISTEMAS TO PROPFIDH-DATA-SITUACAO. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_DATA_SITUACAO);

            /*" -3678- MOVE RH-NSAS OF REG-HEADER TO PROPFIDH-NSAS-SIVPF. */
            _.Move(LXFPF990.REG_HEADER.RH_NSAS, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NSAS_SIVPF);

            /*" -3681- MOVE W-QTD-LD-SIVPF-3 TO PROPFIDH-NSL. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_SIVPF_3, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NSL);

            /*" -3684- MOVE PROPOFID-SIT-PROPOSTA OF DCLPROPOSTA-FIDELIZ TO PROPFIDH-SIT-PROPOSTA. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_SIT_PROPOSTA, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_PROPOSTA);

            /*" -3687- MOVE R3-SIT-COBRANCA OF REG-PROPOSTA-SASSE TO PROPFIDH-SIT-COBRANCA-SIVPF. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_SIT_COBRANCA, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_COBRANCA_SIVPF);

            /*" -3690- MOVE 199 TO PROPFIDH-SIT-MOTIVO-SIVPF. */
            _.Move(199, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_MOTIVO_SIVPF);

            /*" -3693- MOVE PROPOFID-COD-EMPRESA-SIVPF OF DCLPROPOSTA-FIDELIZ TO PROPFIDH-COD-EMPRESA-SIVPF. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_EMPRESA_SIVPF, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_COD_EMPRESA_SIVPF);

            /*" -3696- MOVE PROPOFID-COD-PRODUTO-SIVPF OF DCLPROPOSTA-FIDELIZ TO PROPFIDH-COD-PRODUTO-SIVPF. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_COD_PRODUTO_SIVPF);

            /*" -3707- PERFORM R0790_GERA_HIST_FIDELIZACAO_DB_INSERT_1 */

            R0790_GERA_HIST_FIDELIZACAO_DB_INSERT_1();

            /*" -3710- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -3711- DISPLAY 'PF0103B - FIM ANORMAL' */
                _.Display($"PF0103B - FIM ANORMAL");

                /*" -3712- DISPLAY '          ERRO INSERT TABELA HIST-PROP-FIDELIZ' */
                _.Display($"          ERRO INSERT TABELA HIST-PROP-FIDELIZ");

                /*" -3714- DISPLAY '          CODIGO PESSOA.................  ' COD-PESSOA OF DCLIDENTIFICA-RELAC */
                _.Display($"          CODIGO PESSOA.................  {IDERELAC.DCLIDENTIFICA_RELAC.COD_PESSOA}");

                /*" -3716- DISPLAY '          NUMERO PROPOSTA...............  ' R3-NUM-PROPOSTA OF REG-PROPOSTA-SASSE */
                _.Display($"          NUMERO PROPOSTA...............  {LXFCT004.REG_PROPOSTA_SASSE.R3_NUM_PROPOSTA}");

                /*" -3718- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -3719- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -3719- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R0790-GERA-HIST-FIDELIZACAO-DB-INSERT-1 */
        public void R0790_GERA_HIST_FIDELIZACAO_DB_INSERT_1()
        {
            /*" -3707- EXEC SQL INSERT INTO SEGUROS.HIST_PROP_FIDELIZ VALUES (:PROPFIDH-NUM-IDENTIFICACAO, :PROPFIDH-DATA-SITUACAO, :PROPFIDH-NSAS-SIVPF, :PROPFIDH-NSL, :PROPFIDH-SIT-PROPOSTA, :PROPFIDH-SIT-COBRANCA-SIVPF, :PROPFIDH-SIT-MOTIVO-SIVPF, :PROPFIDH-COD-EMPRESA-SIVPF, :PROPFIDH-COD-PRODUTO-SIVPF) END-EXEC. */

            var r0790_GERA_HIST_FIDELIZACAO_DB_INSERT_1_Insert1 = new R0790_GERA_HIST_FIDELIZACAO_DB_INSERT_1_Insert1()
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

            R0790_GERA_HIST_FIDELIZACAO_DB_INSERT_1_Insert1.Execute(r0790_GERA_HIST_FIDELIZACAO_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0790_SAIDA*/

        [StopWatch]
        /*" R0791-OBTER-NUM-SICOB-SECTION */
        private void R0791_OBTER_NUM_SICOB_SECTION()
        {
            /*" -3729- MOVE 'R0791-OBTER-NUM-SICOB' TO PARAGRAFO. */
            _.Move("R0791-OBTER-NUM-SICOB", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3731- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3735- MOVE R3-NUM-PROPOSTA OF REG-PROPOSTA-SASSE TO NUM-PROPOSTA-SIVPF OF DCLCONVERSAO-SICOB, W-NUM-PROPOSTA. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_NUM_PROPOSTA, COVSICOB.DCLCONVERSAO_SICOB.NUM_PROPOSTA_SIVPF, WREA88.W_NUM_PROPOSTA);

            /*" -3736- IF CANAL-VENDA-PAPEL */

            if (WREA88.CANAL.W88_CANAL_PROPOSTA["CANAL_VENDA_PAPEL"])
            {

                /*" -3739- MOVE NUM-PROPOSTA-SIVPF OF DCLCONVERSAO-SICOB TO PROPOFID-NUM-SICOB OF DCLPROPOSTA-FIDELIZ, NUM-SICOB OF DCLCONVERSAO-SICOB */
                _.Move(COVSICOB.DCLCONVERSAO_SICOB.NUM_PROPOSTA_SIVPF, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_SICOB, COVSICOB.DCLCONVERSAO_SICOB.NUM_SICOB);

                /*" -3740- ELSE */
            }
            else
            {


                /*" -3741- PERFORM R0793-NUMERAR-SICOB */

                R0793_NUMERAR_SICOB_SECTION();

                /*" -3742- PERFORM R0794-GERA-DE-PARA-NR-SICOB */

                R0794_GERA_DE_PARA_NR_SICOB_SECTION();

                /*" -3743- MOVE NUM-SICOB OF DCLCONVERSAO-SICOB TO PROPOFID-NUM-SICOB OF DCLPROPOSTA-FIDELIZ. */
                _.Move(COVSICOB.DCLCONVERSAO_SICOB.NUM_SICOB, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_SICOB);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0791_SAIDA*/

        [StopWatch]
        /*" R0792-ACESSAR-CONVERSAO-SICOB-SECTION */
        private void R0792_ACESSAR_CONVERSAO_SICOB_SECTION()
        {
            /*" -3753- MOVE 'R0792-ACESSAR-CONVERSAO-SICOB' TO PARAGRAFO. */
            _.Move("R0792-ACESSAR-CONVERSAO-SICOB", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3755- MOVE 'SELECT CONVERSAO-SICOB' TO COMANDO. */
            _.Move("SELECT CONVERSAO-SICOB", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3770- PERFORM R0792_ACESSAR_CONVERSAO_SICOB_DB_SELECT_1 */

            R0792_ACESSAR_CONVERSAO_SICOB_DB_SELECT_1();

            /*" -3773- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -3775- IF SQLCODE EQUAL 100 NEXT SENTENCE */

                if (DB.SQLCODE == 100)
                {

                    /*" -3776- ELSE */
                }
                else
                {


                    /*" -3777- DISPLAY 'PF0103B FIM ANORMAL' */
                    _.Display($"PF0103B FIM ANORMAL");

                    /*" -3778- DISPLAY '        ERRO SELECT TAB. CONVERSAO-SICOB' */
                    _.Display($"        ERRO SELECT TAB. CONVERSAO-SICOB");

                    /*" -3780- DISPLAY '        NUM DA PROPOSTA .... ' NUM-PROPOSTA-SIVPF OF DCLCONVERSAO-SICOB */
                    _.Display($"        NUM DA PROPOSTA .... {COVSICOB.DCLCONVERSAO_SICOB.NUM_PROPOSTA_SIVPF}");

                    /*" -3781- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -3782- PERFORM R9999-00-FINALIZAR */

                    R9999_00_FINALIZAR_SECTION();

                    /*" -3783- ELSE */
                }

            }
            else
            {


                /*" -3783- MOVE 2 TO W88-CONVERSAO. */
                _.Move(2, WREA88.W88_CONVERSAO);
            }


        }

        [StopWatch]
        /*" R0792-ACESSAR-CONVERSAO-SICOB-DB-SELECT-1 */
        public void R0792_ACESSAR_CONVERSAO_SICOB_DB_SELECT_1()
        {
            /*" -3770- EXEC SQL SELECT NUM_SICOB , AGEPGTO , DATA_OPERACAO, DATA_QUITACAO, VAL_RCAP INTO :DCLCONVERSAO-SICOB.NUM-SICOB , :DCLCONVERSAO-SICOB.AGEPGTO , :DCLCONVERSAO-SICOB.DATA-OPERACAO, :DCLCONVERSAO-SICOB.DATA-QUITACAO, :DCLCONVERSAO-SICOB.VAL-RCAP FROM SEGUROS.CONVERSAO_SICOB WHERE NUM_PROPOSTA_SIVPF = :DCLCONVERSAO-SICOB.NUM-PROPOSTA-SIVPF WITH UR END-EXEC. */

            var r0792_ACESSAR_CONVERSAO_SICOB_DB_SELECT_1_Query1 = new R0792_ACESSAR_CONVERSAO_SICOB_DB_SELECT_1_Query1()
            {
                NUM_PROPOSTA_SIVPF = COVSICOB.DCLCONVERSAO_SICOB.NUM_PROPOSTA_SIVPF.ToString(),
            };

            var executed_1 = R0792_ACESSAR_CONVERSAO_SICOB_DB_SELECT_1_Query1.Execute(r0792_ACESSAR_CONVERSAO_SICOB_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.NUM_SICOB, COVSICOB.DCLCONVERSAO_SICOB.NUM_SICOB);
                _.Move(executed_1.AGEPGTO, COVSICOB.DCLCONVERSAO_SICOB.AGEPGTO);
                _.Move(executed_1.DATA_OPERACAO, COVSICOB.DCLCONVERSAO_SICOB.DATA_OPERACAO);
                _.Move(executed_1.DATA_QUITACAO, COVSICOB.DCLCONVERSAO_SICOB.DATA_QUITACAO);
                _.Move(executed_1.VAL_RCAP, COVSICOB.DCLCONVERSAO_SICOB.VAL_RCAP);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0792_SAIDA*/

        [StopWatch]
        /*" R0793-NUMERAR-SICOB-SECTION */
        private void R0793_NUMERAR_SICOB_SECTION()
        {
            /*" -3794- MOVE 'R0793-NUMERAR-SICOB' TO PARAGRAFO. */
            _.Move("R0793-NUMERAR-SICOB", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3796- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3798- MOVE 26 TO CEDENTE-COD-CEDENTE OF DCLCEDENTE */
            _.Move(26, CEDENTE.DCLCEDENTE.CEDENTE_COD_CEDENTE);

            /*" -3806- PERFORM R0793_NUMERAR_SICOB_DB_SELECT_1 */

            R0793_NUMERAR_SICOB_DB_SELECT_1();

            /*" -3809- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -3810- DISPLAY 'PF0103B FIM ANORMAL' */
                _.Display($"PF0103B FIM ANORMAL");

                /*" -3811- DISPLAY '        ERRO SELECT TAB. CEDENTE' */
                _.Display($"        ERRO SELECT TAB. CEDENTE");

                /*" -3813- DISPLAY '        CODIGO CEDENTE...... ' CEDENTE-COD-CEDENTE OF DCLCEDENTE */
                _.Display($"        CODIGO CEDENTE...... {CEDENTE.DCLCEDENTE.CEDENTE_COD_CEDENTE}");

                /*" -3814- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -3816- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


            /*" -3820- MOVE CEDENTE-NUM-TITULO OF DCLCEDENTE TO W-NUMR-TITULO. */
            _.Move(CEDENTE.DCLCEDENTE.CEDENTE_NUM_TITULO, WAREA_AUXILIAR.W_NUMR_TITULO);

            /*" -3822- ADD 1 TO WTITL-SEQUENCIA. */
            WAREA_AUXILIAR.FILLER_6.WTITL_SEQUENCIA.Value = WAREA_AUXILIAR.FILLER_6.WTITL_SEQUENCIA + 1;

            /*" -3824- MOVE WTITL-SEQUENCIA TO DPARM01. */
            _.Move(WAREA_AUXILIAR.FILLER_6.WTITL_SEQUENCIA, WAREA_AUXILIAR.DPARM01X.DPARM01);

            /*" -3826- CALL 'PROTIT01' USING DPARM01X. */
            _.Call("PROTIT01", WAREA_AUXILIAR.DPARM01X);

            /*" -3827- IF DPARM01-RC NOT EQUAL +0 */

            if (WAREA_AUXILIAR.DPARM01X.DPARM01_RC != +0)
            {

                /*" -3828- DISPLAY 'PF0103B FIM ANORMAL' */
                _.Display($"PF0103B FIM ANORMAL");

                /*" -3830- DISPLAY '        ERRO CHAMADA PROTIT01  ' DPARM01-RC */
                _.Display($"        ERRO CHAMADA PROTIT01  {WAREA_AUXILIAR.DPARM01X.DPARM01_RC}");

                /*" -3832- DISPLAY '        CODIGO CEDENTE........ ' CEDENTE-COD-CEDENTE OF DCLCEDENTE */
                _.Display($"        CODIGO CEDENTE........ {CEDENTE.DCLCEDENTE.CEDENTE_COD_CEDENTE}");

                /*" -3833- DISPLAY '        AREA DE PARM.......... ' DPARM01X */
                _.Display($"        AREA DE PARM.......... {WAREA_AUXILIAR.DPARM01X}");

                /*" -3834- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -3836- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


            /*" -3838- MOVE DPARM01-D1 TO WTITL-DIGITO. */
            _.Move(WAREA_AUXILIAR.DPARM01X.DPARM01_D1, WAREA_AUXILIAR.FILLER_6.WTITL_DIGITO);

            /*" -3840- MOVE W-NUMR-TITULO TO CEDENTE-NUM-TITULO OF DCLCEDENTE. */
            _.Move(WAREA_AUXILIAR.W_NUMR_TITULO, CEDENTE.DCLCEDENTE.CEDENTE_NUM_TITULO);

            /*" -3842- IF CEDENTE-NUM-TITULO OF DCLCEDENTE NOT LESS CEDENTE-NUM-TITULO-MAX OF DCLCEDENTE */

            if (CEDENTE.DCLCEDENTE.CEDENTE_NUM_TITULO >= CEDENTE.DCLCEDENTE.CEDENTE_NUM_TITULO_MAX)
            {

                /*" -3843- DISPLAY 'PF0103B FIM ANORMAL' */
                _.Display($"PF0103B FIM ANORMAL");

                /*" -3844- DISPLAY '        NUM. SICOB CALCULADO EXCEDE SICOB MAXIMO' */
                _.Display($"        NUM. SICOB CALCULADO EXCEDE SICOB MAXIMO");

                /*" -3846- DISPLAY '        CODIGO CEDENTE...... ' CEDENTE-COD-CEDENTE OF DCLCEDENTE */
                _.Display($"        CODIGO CEDENTE...... {CEDENTE.DCLCEDENTE.CEDENTE_COD_CEDENTE}");

                /*" -3848- DISPLAY '        SICOB CALCULADO..... ' CEDENTE-NUM-TITULO OF DCLCEDENTE */
                _.Display($"        SICOB CALCULADO..... {CEDENTE.DCLCEDENTE.CEDENTE_NUM_TITULO}");

                /*" -3850- DISPLAY '        SICOB MAXIMO........ ' CEDENTE-NUM-TITULO-MAX OF DCLCEDENTE */
                _.Display($"        SICOB MAXIMO........ {CEDENTE.DCLCEDENTE.CEDENTE_NUM_TITULO_MAX}");

                /*" -3851- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -3855- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


            /*" -3859- PERFORM R0793_NUMERAR_SICOB_DB_UPDATE_1 */

            R0793_NUMERAR_SICOB_DB_UPDATE_1();

            /*" -3862- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -3863- DISPLAY 'PF0103B FIM ANORMAL' */
                _.Display($"PF0103B FIM ANORMAL");

                /*" -3864- DISPLAY '        ERRO UPDATE TAB. CEDENTE' */
                _.Display($"        ERRO UPDATE TAB. CEDENTE");

                /*" -3866- DISPLAY '        CODIGO CEDENTE...... ' CEDENTE-COD-CEDENTE OF DCLCEDENTE */
                _.Display($"        CODIGO CEDENTE...... {CEDENTE.DCLCEDENTE.CEDENTE_COD_CEDENTE}");

                /*" -3867- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -3867- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R0793-NUMERAR-SICOB-DB-SELECT-1 */
        public void R0793_NUMERAR_SICOB_DB_SELECT_1()
        {
            /*" -3806- EXEC SQL SELECT NUM_TITULO, NUM_TITULO_MAX INTO :DCLCEDENTE.CEDENTE-NUM-TITULO, :DCLCEDENTE.CEDENTE-NUM-TITULO-MAX FROM SEGUROS.CEDENTE WHERE COD_CEDENTE = :DCLCEDENTE.CEDENTE-COD-CEDENTE WITH UR END-EXEC. */

            var r0793_NUMERAR_SICOB_DB_SELECT_1_Query1 = new R0793_NUMERAR_SICOB_DB_SELECT_1_Query1()
            {
                CEDENTE_COD_CEDENTE = CEDENTE.DCLCEDENTE.CEDENTE_COD_CEDENTE.ToString(),
            };

            var executed_1 = R0793_NUMERAR_SICOB_DB_SELECT_1_Query1.Execute(r0793_NUMERAR_SICOB_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CEDENTE_NUM_TITULO, CEDENTE.DCLCEDENTE.CEDENTE_NUM_TITULO);
                _.Move(executed_1.CEDENTE_NUM_TITULO_MAX, CEDENTE.DCLCEDENTE.CEDENTE_NUM_TITULO_MAX);
            }


        }

        [StopWatch]
        /*" R0793-NUMERAR-SICOB-DB-UPDATE-1 */
        public void R0793_NUMERAR_SICOB_DB_UPDATE_1()
        {
            /*" -3859- EXEC SQL UPDATE SEGUROS.CEDENTE SET NUM_TITULO = :DCLCEDENTE.CEDENTE-NUM-TITULO WHERE COD_CEDENTE = :DCLCEDENTE.CEDENTE-COD-CEDENTE END-EXEC. */

            var r0793_NUMERAR_SICOB_DB_UPDATE_1_Update1 = new R0793_NUMERAR_SICOB_DB_UPDATE_1_Update1()
            {
                CEDENTE_NUM_TITULO = CEDENTE.DCLCEDENTE.CEDENTE_NUM_TITULO.ToString(),
                CEDENTE_COD_CEDENTE = CEDENTE.DCLCEDENTE.CEDENTE_COD_CEDENTE.ToString(),
            };

            R0793_NUMERAR_SICOB_DB_UPDATE_1_Update1.Execute(r0793_NUMERAR_SICOB_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0793_SAIDA*/

        [StopWatch]
        /*" R0794-GERA-DE-PARA-NR-SICOB-SECTION */
        private void R0794_GERA_DE_PARA_NR_SICOB_SECTION()
        {
            /*" -3877- MOVE 'R0794-GERA-DE-PARA-NR-SICOB' TO PARAGRAFO. */
            _.Move("R0794-GERA-DE-PARA-NR-SICOB", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3879- MOVE 'INSERT CONVERSAO-SICOB' TO COMANDO. */
            _.Move("INSERT CONVERSAO-SICOB", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3882- MOVE R3-NUM-PROPOSTA OF REG-PROPOSTA-SASSE TO NUM-PROPOSTA-SIVPF OF DCLCONVERSAO-SICOB */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_NUM_PROPOSTA, COVSICOB.DCLCONVERSAO_SICOB.NUM_PROPOSTA_SIVPF);

            /*" -3885- MOVE R3-COD-PRODUTO OF REG-PROPOSTA-SASSE TO PRODUTO-SIVPF OF DCLCONVERSAO-SICOB */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_COD_PRODUTO, COVSICOB.DCLCONVERSAO_SICOB.PRODUTO_SIVPF);

            /*" -3887- IF R3-DTQITBCO OF REG-PROPOSTA-SASSE NOT NUMERIC */

            if (!LXFCT004.REG_PROPOSTA_SASSE.R3_DTQITBCO.IsNumeric())
            {

                /*" -3890- MOVE 01010001 TO R3-DTQITBCO OF REG-PROPOSTA-SASSE. */
                _.Move(01010001, LXFCT004.REG_PROPOSTA_SASSE.R3_DTQITBCO);
            }


            /*" -3892- IF R3-DTQITBCO OF REG-PROPOSTA-SASSE EQUAL ZEROS */

            if (LXFCT004.REG_PROPOSTA_SASSE.R3_DTQITBCO == 00)
            {

                /*" -3895- MOVE 01010001 TO R3-DTQITBCO OF REG-PROPOSTA-SASSE. */
                _.Move(01010001, LXFCT004.REG_PROPOSTA_SASSE.R3_DTQITBCO);
            }


            /*" -3898- MOVE R3-DTQITBCO OF REG-PROPOSTA-SASSE TO W-DATA-TRABALHO */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_DTQITBCO, WAREA_AUXILIAR.W_DATA_TRABALHO);

            /*" -3900- MOVE W-DIA-TRABALHO TO W-DIA-SQL OF W-DATA-SQL1 */
            _.Move(WAREA_AUXILIAR.FILLER_8.W_DIA_TRABALHO, WAREA_AUXILIAR.W_DATA_SQL1.W_DIA_SQL);

            /*" -3902- MOVE W-MES-TRABALHO TO W-MES-SQL OF W-DATA-SQL1 */
            _.Move(WAREA_AUXILIAR.FILLER_8.W_MES_TRABALHO, WAREA_AUXILIAR.W_DATA_SQL1.W_MES_SQL);

            /*" -3905- MOVE W-ANO-TRABALHO TO W-ANO-SQL OF W-DATA-SQL1 */
            _.Move(WAREA_AUXILIAR.FILLER_8.W_ANO_TRABALHO, WAREA_AUXILIAR.W_DATA_SQL1.W_ANO_SQL);

            /*" -3909- MOVE '-' TO W-BARRA1 OF W-DATA-SQL1, W-BARRA2 OF W-DATA-SQL1 */
            _.Move("-", WAREA_AUXILIAR.W_DATA_SQL1.W_BARRA1_1);
            _.Move("-", WAREA_AUXILIAR.W_DATA_SQL1.W_BARRA2_1);


            /*" -3912- MOVE W-DATA-SQL TO DATA-QUITACAO OF DCLCONVERSAO-SICOB */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL, COVSICOB.DCLCONVERSAO_SICOB.DATA_QUITACAO);

            /*" -3914- IF R3-DTQITBCO OF REG-PROPOSTA-SASSE EQUAL 01010001 */

            if (LXFCT004.REG_PROPOSTA_SASSE.R3_DTQITBCO == 01010001)
            {

                /*" -3917- MOVE ZEROS TO R3-DTQITBCO OF REG-PROPOSTA-SASSE. */
                _.Move(0, LXFCT004.REG_PROPOSTA_SASSE.R3_DTQITBCO);
            }


            /*" -3920- MOVE R3-AGEPGTO OF REG-PROPOSTA-SASSE TO AGEPGTO OF DCLCONVERSAO-SICOB */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_AGEPGTO, COVSICOB.DCLCONVERSAO_SICOB.AGEPGTO);

            /*" -3923- MOVE R3-VAL-PAGO OF REG-PROPOSTA-SASSE TO VAL-RCAP OF DCLCONVERSAO-SICOB */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_VAL_PAGO, COVSICOB.DCLCONVERSAO_SICOB.VAL_RCAP);

            /*" -3926- MOVE PRDSIVPF-COD-EMPRESA-SIVPF OF DCLPRODUTOS-SIVPF TO COD-EMPRESA-SIVPF OF DCLCONVERSAO-SICOB */
            _.Move(PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_EMPRESA_SIVPF, COVSICOB.DCLCONVERSAO_SICOB.COD_EMPRESA_SIVPF);

            /*" -3929- MOVE SISTEMAS-DATA-MOV-ABERTO OF DCLSISTEMAS TO DATA-OPERACAO OF DCLCONVERSAO-SICOB */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, COVSICOB.DCLCONVERSAO_SICOB.DATA_OPERACAO);

            /*" -3932- MOVE 'PF0103B' TO COD-USUARIO OF DCLCONVERSAO-SICOB. */
            _.Move("PF0103B", COVSICOB.DCLCONVERSAO_SICOB.COD_USUARIO);

            /*" -3935- MOVE CEDENTE-NUM-TITULO OF DCLCEDENTE TO NUM-SICOB OF DCLCONVERSAO-SICOB. */
            _.Move(CEDENTE.DCLCEDENTE.CEDENTE_NUM_TITULO, COVSICOB.DCLCONVERSAO_SICOB.NUM_SICOB);

            /*" -3947- PERFORM R0794_GERA_DE_PARA_NR_SICOB_DB_INSERT_1 */

            R0794_GERA_DE_PARA_NR_SICOB_DB_INSERT_1();

            /*" -3950- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -3951- IF SQLCODE EQUAL -803 */

                if (DB.SQLCODE == -803)
                {

                    /*" -3952- PERFORM R0795-00-TRATA-DUPLICI-SICOB */

                    R0795_00_TRATA_DUPLICI_SICOB_SECTION();

                    /*" -3953- ELSE */
                }
                else
                {


                    /*" -3954- DISPLAY 'PF0103B - FIM ANORMAL' */
                    _.Display($"PF0103B - FIM ANORMAL");

                    /*" -3955- DISPLAY '          ERRO INSERT DA TAB. CONVERSAO-SICOB' */
                    _.Display($"          ERRO INSERT DA TAB. CONVERSAO-SICOB");

                    /*" -3957- DISPLAY '          CODIGO PESSOA.................  ' PESSOA-COD-PESSOA OF DCLPESSOA */
                    _.Display($"          CODIGO PESSOA.................  {PESSOA.DCLPESSOA.PESSOA_COD_PESSOA}");

                    /*" -3959- DISPLAY '          NUMERO PROPOSTA...............  ' NUM-PROPOSTA-SIVPF OF DCLCONVERSAO-SICOB */
                    _.Display($"          NUMERO PROPOSTA...............  {COVSICOB.DCLCONVERSAO_SICOB.NUM_PROPOSTA_SIVPF}");

                    /*" -3961- DISPLAY '          NUMERO SICOB..................  ' NUM-SICOB OF DCLCONVERSAO-SICOB */
                    _.Display($"          NUMERO SICOB..................  {COVSICOB.DCLCONVERSAO_SICOB.NUM_SICOB}");

                    /*" -3963- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                    _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                    /*" -3964- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -3964- PERFORM R9999-00-FINALIZAR. */

                    R9999_00_FINALIZAR_SECTION();
                }

            }


        }

        [StopWatch]
        /*" R0794-GERA-DE-PARA-NR-SICOB-DB-INSERT-1 */
        public void R0794_GERA_DE_PARA_NR_SICOB_DB_INSERT_1()
        {
            /*" -3947- EXEC SQL INSERT INTO SEGUROS.CONVERSAO_SICOB VALUES (:DCLCONVERSAO-SICOB.NUM-PROPOSTA-SIVPF, :DCLCONVERSAO-SICOB.NUM-SICOB, :DCLCONVERSAO-SICOB.COD-EMPRESA-SIVPF, :DCLCONVERSAO-SICOB.PRODUTO-SIVPF, :DCLCONVERSAO-SICOB.AGEPGTO, :DCLCONVERSAO-SICOB.DATA-OPERACAO, :DCLCONVERSAO-SICOB.DATA-QUITACAO, :DCLCONVERSAO-SICOB.VAL-RCAP, :DCLCONVERSAO-SICOB.COD-USUARIO, CURRENT TIMESTAMP) END-EXEC. */

            var r0794_GERA_DE_PARA_NR_SICOB_DB_INSERT_1_Insert1 = new R0794_GERA_DE_PARA_NR_SICOB_DB_INSERT_1_Insert1()
            {
                NUM_PROPOSTA_SIVPF = COVSICOB.DCLCONVERSAO_SICOB.NUM_PROPOSTA_SIVPF.ToString(),
                NUM_SICOB = COVSICOB.DCLCONVERSAO_SICOB.NUM_SICOB.ToString(),
                COD_EMPRESA_SIVPF = COVSICOB.DCLCONVERSAO_SICOB.COD_EMPRESA_SIVPF.ToString(),
                PRODUTO_SIVPF = COVSICOB.DCLCONVERSAO_SICOB.PRODUTO_SIVPF.ToString(),
                AGEPGTO = COVSICOB.DCLCONVERSAO_SICOB.AGEPGTO.ToString(),
                DATA_OPERACAO = COVSICOB.DCLCONVERSAO_SICOB.DATA_OPERACAO.ToString(),
                DATA_QUITACAO = COVSICOB.DCLCONVERSAO_SICOB.DATA_QUITACAO.ToString(),
                VAL_RCAP = COVSICOB.DCLCONVERSAO_SICOB.VAL_RCAP.ToString(),
                COD_USUARIO = COVSICOB.DCLCONVERSAO_SICOB.COD_USUARIO.ToString(),
            };

            R0794_GERA_DE_PARA_NR_SICOB_DB_INSERT_1_Insert1.Execute(r0794_GERA_DE_PARA_NR_SICOB_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0794_SAIDA*/

        [StopWatch]
        /*" R0795-00-TRATA-DUPLICI-SICOB-SECTION */
        private void R0795_00_TRATA_DUPLICI_SICOB_SECTION()
        {
            /*" -3975- MOVE 'R0795-00-TRATA-DUPLICI-SICOB' TO PARAGRAFO. */
            _.Move("R0795-00-TRATA-DUPLICI-SICOB", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3977- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3978- PERFORM R0793-NUMERAR-SICOB */

            R0793_NUMERAR_SICOB_SECTION();

            /*" -3979- PERFORM R0794-GERA-DE-PARA-NR-SICOB. */

            R0794_GERA_DE_PARA_NR_SICOB_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0795_99_SAIDA*/

        [StopWatch]
        /*" R0900-TRATA-INF-COMPLEMENTARES-SECTION */
        private void R0900_TRATA_INF_COMPLEMENTARES_SECTION()
        {
            /*" -3989- MOVE 'R0900-TRATA-INF-COMPLEMENTARES' TO PARAGRAFO. */
            _.Move("R0900-TRATA-INF-COMPLEMENTARES", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3991- MOVE 'INSERT SEGUROS.PROP_FIDELIZ_COMP' TO COMANDO. */
            _.Move("INSERT SEGUROS.PROP_FIDELIZ_COMP", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3993- MOVE W-TB-REG-INFORMACOES(W-IND-INFO1) TO REG-INFORMACOES. */
            _.Move(WAREA_AUXILIAR.W_TAB_INFORMACOES.W_TAB_INFO_REG[WAREA_AUXILIAR.W_IND_INFO1].W_TB_REG_INFORMACOES, LBFPF015.REG_INFORMACOES);

            /*" -3996- MOVE PROPOFID-NUM-IDENTIFICACAO OF DCLPROPOSTA-FIDELIZ TO PROFIDCO-NUM-IDENTIFICACAO OF DCLPROP-FIDELIZ-COMP. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_IDENTIFICACAO, PROFIDCO.DCLPROP_FIDELIZ_COMP.PROFIDCO_NUM_IDENTIFICACAO);

            /*" -3999- MOVE R5-INFO-COMPLEMEN OF REG-INFORMACOES TO PROFIDCO-INFORMACAO-COMPL OF DCLPROP-FIDELIZ-COMP. */
            _.Move(LBFPF015.REG_INFORMACOES.R5_INFO_COMPLEMEN, PROFIDCO.DCLPROP_FIDELIZ_COMP.PROFIDCO_INFORMACAO_COMPL);

            /*" -4002- MOVE '1' TO PROFIDCO-IND-TP-INFORMACAO OF DCLPROP-FIDELIZ-COMP. */
            _.Move("1", PROFIDCO.DCLPROP_FIDELIZ_COMP.PROFIDCO_IND_TP_INFORMACAO);

            /*" -4005- MOVE 'PF0103B' TO PROFIDCO-COD-USUARIO OF DCLPROP-FIDELIZ-COMP. */
            _.Move("PF0103B", PROFIDCO.DCLPROP_FIDELIZ_COMP.PROFIDCO_COD_USUARIO);

            /*" -4012- PERFORM R0900_TRATA_INF_COMPLEMENTARES_DB_INSERT_1 */

            R0900_TRATA_INF_COMPLEMENTARES_DB_INSERT_1();

            /*" -4015- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -4016- IF SQLCODE EQUAL -803 */

                if (DB.SQLCODE == -803)
                {

                    /*" -4017- DISPLAY 'PF0103B - INFORMACAO COMPL. JA EXISTE' */
                    _.Display($"PF0103B - INFORMACAO COMPL. JA EXISTE");

                    /*" -4019- DISPLAY '          CODIGO PESSOA.................  ' COD-PESSOA OF DCLIDENTIFICA-RELAC */
                    _.Display($"          CODIGO PESSOA.................  {IDERELAC.DCLIDENTIFICA_RELAC.COD_PESSOA}");

                    /*" -4021- DISPLAY '          NUMERO IDENTIFICACAO..........  ' PROPOFID-NUM-IDENTIFICACAO OF DCLPROPOSTA-FIDELIZ */
                    _.Display($"          NUMERO IDENTIFICACAO..........  {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_IDENTIFICACAO}");

                    /*" -4023- DISPLAY '          NUMERO PROPOSTA...............  ' PROPOFID-NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ */
                    _.Display($"          NUMERO PROPOSTA...............  {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}");

                    /*" -4024- ELSE */
                }
                else
                {


                    /*" -4025- DISPLAY 'PF0103B - FIM ANORMAL' */
                    _.Display($"PF0103B - FIM ANORMAL");

                    /*" -4026- DISPLAY '          ERRO INSERT TABELA PROPOSTA_COMPL' */
                    _.Display($"          ERRO INSERT TABELA PROPOSTA_COMPL");

                    /*" -4028- DISPLAY '          CODIGO PESSOA.................  ' COD-PESSOA OF DCLIDENTIFICA-RELAC */
                    _.Display($"          CODIGO PESSOA.................  {IDERELAC.DCLIDENTIFICA_RELAC.COD_PESSOA}");

                    /*" -4030- DISPLAY '          NUMERO IDENTIFICACAO..........  ' PROPOFID-NUM-IDENTIFICACAO OF DCLPROPOSTA-FIDELIZ */
                    _.Display($"          NUMERO IDENTIFICACAO..........  {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_IDENTIFICACAO}");

                    /*" -4032- DISPLAY '          NUMERO PROPOSTA...............  ' PROPOFID-NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ */
                    _.Display($"          NUMERO PROPOSTA...............  {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}");

                    /*" -4034- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                    _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                    /*" -4035- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -4035- PERFORM R9999-00-FINALIZAR. */

                    R9999_00_FINALIZAR_SECTION();
                }

            }


        }

        [StopWatch]
        /*" R0900-TRATA-INF-COMPLEMENTARES-DB-INSERT-1 */
        public void R0900_TRATA_INF_COMPLEMENTARES_DB_INSERT_1()
        {
            /*" -4012- EXEC SQL INSERT INTO SEGUROS.PROP_FIDELIZ_COMP VALUES (:DCLPROP-FIDELIZ-COMP.PROFIDCO-NUM-IDENTIFICACAO, :DCLPROP-FIDELIZ-COMP.PROFIDCO-INFORMACAO-COMPL, :DCLPROP-FIDELIZ-COMP.PROFIDCO-COD-USUARIO, CURRENT TIMESTAMP, :DCLPROP-FIDELIZ-COMP.PROFIDCO-IND-TP-INFORMACAO) END-EXEC. */

            var r0900_TRATA_INF_COMPLEMENTARES_DB_INSERT_1_Insert1 = new R0900_TRATA_INF_COMPLEMENTARES_DB_INSERT_1_Insert1()
            {
                PROFIDCO_NUM_IDENTIFICACAO = PROFIDCO.DCLPROP_FIDELIZ_COMP.PROFIDCO_NUM_IDENTIFICACAO.ToString(),
                PROFIDCO_INFORMACAO_COMPL = PROFIDCO.DCLPROP_FIDELIZ_COMP.PROFIDCO_INFORMACAO_COMPL.ToString(),
                PROFIDCO_COD_USUARIO = PROFIDCO.DCLPROP_FIDELIZ_COMP.PROFIDCO_COD_USUARIO.ToString(),
                PROFIDCO_IND_TP_INFORMACAO = PROFIDCO.DCLPROP_FIDELIZ_COMP.PROFIDCO_IND_TP_INFORMACAO.ToString(),
            };

            R0900_TRATA_INF_COMPLEMENTARES_DB_INSERT_1_Insert1.Execute(r0900_TRATA_INF_COMPLEMENTARES_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0900_SAIDA*/

        [StopWatch]
        /*" R1500-00-GERAR-MOV-AUTO-SECTION */
        private void R1500_00_GERAR_MOV_AUTO_SECTION()
        {
            /*" -4045- MOVE 'R1500-00-GERAR-MOV-AUTO' TO PARAGRAFO. */
            _.Move("R1500-00-GERAR-MOV-AUTO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4047- MOVE '    ' TO COMANDO. */
            _.Move("    ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4049- PERFORM R1510-00-GRAVA-REG-CLIENTE */

            R1510_00_GRAVA_REG_CLIENTE_SECTION();

            /*" -4053- PERFORM R1515-00-GRAVA-REG-ENDERECO VARYING W-IND-ENDER1 FROM 1 BY 1 UNTIL W-IND-ENDER1 GREATER W-IND-ENDER-N. */

            for (WAREA_AUXILIAR.W_IND_ENDER1.Value = 1; !(WAREA_AUXILIAR.W_IND_ENDER1 > WAREA_AUXILIAR.W_IND_ENDER_N); WAREA_AUXILIAR.W_IND_ENDER1.Value += 1)
            {

                R1515_00_GRAVA_REG_ENDERECO_SECTION();
            }

            /*" -4055- PERFORM R1520-00-GRAVA-PROPOSTA */

            R1520_00_GRAVA_PROPOSTA_SECTION();

            /*" -4059- PERFORM R1525-00-GRAVA-DADOS-CARRO VARYING W-IND-BENEF FROM 1 BY 1 UNTIL W-IND-BENEF GREATER W-IND-BENEF-N. */

            for (WAREA_AUXILIAR.W_IND_BENEF.Value = 1; !(WAREA_AUXILIAR.W_IND_BENEF > WAREA_AUXILIAR.W_IND_BENEF_N); WAREA_AUXILIAR.W_IND_BENEF.Value += 1)
            {

                R1525_00_GRAVA_DADOS_CARRO_SECTION();
            }

            /*" -4060- IF W-EXISTE-TP-5 EQUAL 'SIM' */

            if (WAREA_AUXILIAR.W_EXISTE_TP_5 == "SIM")
            {

                /*" -4064- PERFORM R1530-00-GRAVA-INF-COMPLE VARYING W-IND-INFO FROM 1 BY 1 UNTIL W-IND-INFO GREATER W-IND-INFO-N. */

                for (WAREA_AUXILIAR.W_IND_INFO.Value = 1; !(WAREA_AUXILIAR.W_IND_INFO > WAREA_AUXILIAR.W_IND_INFO_N); WAREA_AUXILIAR.W_IND_INFO.Value += 1)
                {

                    R1530_00_GRAVA_INF_COMPLE_SECTION();
                }
            }


            /*" -4066- PERFORM R1535-00-GRAVA-CLAUSULAS VARYING W-IND-CLAU FROM 1 BY 1 UNTIL W-IND-CLAU GREATER W-IND-CLAU-N. */

            for (WAREA_AUXILIAR.W_IND_CLAU.Value = 1; !(WAREA_AUXILIAR.W_IND_CLAU > WAREA_AUXILIAR.W_IND_CLAU_N); WAREA_AUXILIAR.W_IND_CLAU.Value += 1)
            {

                R1535_00_GRAVA_CLAUSULAS_SECTION();
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1500_SAIDA*/

        [StopWatch]
        /*" R1510-00-GRAVA-REG-CLIENTE-SECTION */
        private void R1510_00_GRAVA_REG_CLIENTE_SECTION()
        {
            /*" -4076- MOVE 'R1510-00-GRAVA-REG-CLIENTE' TO PARAGRAFO. */
            _.Move("R1510-00-GRAVA-REG-CLIENTE", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4078- MOVE 'WRITE REG-MOV-AUTO' TO COMANDO. */
            _.Move("WRITE REG-MOV-AUTO", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4080- ADD 1 TO W-QTD-LD-AUTO-1 */
            WAREA_AUXILIAR.W_QTD_LD_AUTO_1.Value = WAREA_AUXILIAR.W_QTD_LD_AUTO_1 + 1;

            /*" -4082- MOVE SPACES TO REG-MOV-AUTO */
            _.Move("", REG_MOV_AUTO);

            /*" -4084- MOVE REG-CLIENTES TO REG-MOV-AUTO */
            _.Move(LBFPF011.REG_CLIENTES, REG_MOV_AUTO);

            /*" -4084- WRITE REG-MOV-AUTO. */
            MOV_AUTO.Write(REG_MOV_AUTO.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1510_SAIDA*/

        [StopWatch]
        /*" R1515-00-GRAVA-REG-ENDERECO-SECTION */
        private void R1515_00_GRAVA_REG_ENDERECO_SECTION()
        {
            /*" -4095- MOVE W-TB-REG-ENDERECOS-N(W-IND-ENDER1) TO REG-ENDERECO */
            _.Move(WAREA_AUXILIAR.W_TB_ENDERECOS_N.W_TAB_END_REG_N[WAREA_AUXILIAR.W_IND_ENDER1].W_TB_REG_ENDERECOS_N, LBFPF012.REG_ENDERECO);

            /*" -4097- ADD 1 TO W-QTD-LD-AUTO-2 */
            WAREA_AUXILIAR.W_QTD_LD_AUTO_2.Value = WAREA_AUXILIAR.W_QTD_LD_AUTO_2 + 1;

            /*" -4099- MOVE SPACES TO REG-MOV-AUTO */
            _.Move("", REG_MOV_AUTO);

            /*" -4101- MOVE REG-ENDERECO TO REG-MOV-AUTO */
            _.Move(LBFPF012.REG_ENDERECO, REG_MOV_AUTO);

            /*" -4101- WRITE REG-MOV-AUTO. */
            MOV_AUTO.Write(REG_MOV_AUTO.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1515_SAIDA*/

        [StopWatch]
        /*" R1520-00-GRAVA-PROPOSTA-SECTION */
        private void R1520_00_GRAVA_PROPOSTA_SECTION()
        {
            /*" -4112- ADD 1 TO W-QTD-LD-AUTO-3 */
            WAREA_AUXILIAR.W_QTD_LD_AUTO_3.Value = WAREA_AUXILIAR.W_QTD_LD_AUTO_3 + 1;

            /*" -4114- MOVE SPACES TO REG-MOV-AUTO. */
            _.Move("", REG_MOV_AUTO);

            /*" -4117- MOVE RH-NSAS OF REG-HEADER TO R3-NSAS OF REG-PROPOSTA-SASSE. */
            _.Move(LXFPF990.REG_HEADER.RH_NSAS, LXFCT004.REG_PROPOSTA_SASSE.R3_NSAS);

            /*" -4120- MOVE W-QTD-LD-AUTO-3 TO R3-NSL OF REG-PROPOSTA-SASSE. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_AUTO_3, LXFCT004.REG_PROPOSTA_SASSE.R3_NSL);

            /*" -4122- MOVE REG-PROPOSTA-SASSE TO REG-MOV-AUTO. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE, REG_MOV_AUTO);

            /*" -4122- WRITE REG-MOV-AUTO. */
            MOV_AUTO.Write(REG_MOV_AUTO.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1520_SAIDA*/

        [StopWatch]
        /*" R1525-00-GRAVA-DADOS-CARRO-SECTION */
        private void R1525_00_GRAVA_DADOS_CARRO_SECTION()
        {
            /*" -4133- MOVE W-TB-REG-BENEFI(W-IND-BENEF) TO REG-BENEFIC. */
            _.Move(WAREA_AUXILIAR.W_TAB_BENEFICIARIOS.W_TAB_BENEF_REG[WAREA_AUXILIAR.W_IND_BENEF].W_TB_REG_BENEFI, LBFPF014.REG_BENEFIC);

            /*" -4135- ADD 1 TO W-QTD-LD-AUTO-4 */
            WAREA_AUXILIAR.W_QTD_LD_AUTO_4.Value = WAREA_AUXILIAR.W_QTD_LD_AUTO_4 + 1;

            /*" -4137- MOVE SPACES TO REG-MOV-AUTO */
            _.Move("", REG_MOV_AUTO);

            /*" -4139- MOVE REG-BENEFIC TO REG-MOV-AUTO */
            _.Move(LBFPF014.REG_BENEFIC, REG_MOV_AUTO);

            /*" -4139- WRITE REG-MOV-AUTO. */
            MOV_AUTO.Write(REG_MOV_AUTO.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1525_SAIDA*/

        [StopWatch]
        /*" R1530-00-GRAVA-INF-COMPLE-SECTION */
        private void R1530_00_GRAVA_INF_COMPLE_SECTION()
        {
            /*" -4150- MOVE W-TB-REG-INFORMACOES(W-IND-INFO) TO REG-INFORMACOES. */
            _.Move(WAREA_AUXILIAR.W_TAB_INFORMACOES.W_TAB_INFO_REG[WAREA_AUXILIAR.W_IND_INFO].W_TB_REG_INFORMACOES, LBFPF015.REG_INFORMACOES);

            /*" -4152- ADD 1 TO W-QTD-LD-AUTO-5 */
            WAREA_AUXILIAR.W_QTD_LD_AUTO_5.Value = WAREA_AUXILIAR.W_QTD_LD_AUTO_5 + 1;

            /*" -4154- MOVE SPACES TO REG-MOV-AUTO */
            _.Move("", REG_MOV_AUTO);

            /*" -4156- MOVE REG-INFORMACOES TO REG-MOV-AUTO */
            _.Move(LBFPF015.REG_INFORMACOES, REG_MOV_AUTO);

            /*" -4156- WRITE REG-MOV-AUTO. */
            MOV_AUTO.Write(REG_MOV_AUTO.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1530_SAIDA*/

        [StopWatch]
        /*" R1535-00-GRAVA-CLAUSULAS-SECTION */
        private void R1535_00_GRAVA_CLAUSULAS_SECTION()
        {
            /*" -4167- MOVE W-TB-REG-CLAUSULA(W-IND-CLAU) TO REG-VAL-ACESSORIOS. */
            _.Move(WAREA_AUXILIAR.W_TAB_CLAUSULAS.W_TAB_CLAU_REG[WAREA_AUXILIAR.W_IND_CLAU].W_TB_REG_CLAUSULA, LBFPF016.REG_VAL_ACESSORIOS);

            /*" -4169- ADD 1 TO W-QTD-LD-AUTO-6 */
            WAREA_AUXILIAR.W_QTD_LD_AUTO_6.Value = WAREA_AUXILIAR.W_QTD_LD_AUTO_6 + 1;

            /*" -4171- MOVE SPACES TO REG-MOV-AUTO */
            _.Move("", REG_MOV_AUTO);

            /*" -4173- MOVE REG-VAL-ACESSORIOS TO REG-MOV-AUTO */
            _.Move(LBFPF016.REG_VAL_ACESSORIOS, REG_MOV_AUTO);

            /*" -4173- WRITE REG-MOV-AUTO. */
            MOV_AUTO.Write(REG_MOV_AUTO.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1535_SAIDA*/

        [StopWatch]
        /*" R2000-00-QUEBRA-EMPRESSA-SECTION */
        private void R2000_00_QUEBRA_EMPRESSA_SECTION()
        {
            /*" -4182- DISPLAY ' *---- PROCESSADO MOVIMENTO DA CEF -----*' */
            _.Display($" *---- PROCESSADO MOVIMENTO DA CEF -----*");

            /*" -4184- DISPLAY '       ARQUIVO PROCESSADO.................... ' RH-NSAS OF REG-HEADER */
            _.Display($"       ARQUIVO PROCESSADO.................... {LXFPF990.REG_HEADER.RH_NSAS}");

            /*" -4186- DISPLAY '       GERADO EM............................. ' RH-DATA-GERACAO OF REG-HEADER */
            _.Display($"       GERADO EM............................. {LXFPF990.REG_HEADER.RH_DATA_GERACAO}");

            /*" -4188- DISPLAY '       TOTAL DE REGISTROS PROCESSADOS........ ' W-LIDO-MOVTO-SULA */
            _.Display($"       TOTAL DE REGISTROS PROCESSADOS........ {WAREA_AUXILIAR.W_LIDO_MOVTO_SULA}");

            /*" -4190- DISPLAY '       TOTAL DE PROPOSTAS COM INCOSISTENCIA.. ' W-QTD-CRITICA */
            _.Display($"       TOTAL DE PROPOSTAS COM INCOSISTENCIA.. {WAREA_AUXILIAR.W_QTD_CRITICA}");

            /*" -4191- DISPLAY ' ' */
            _.Display($" ");

            /*" -4193- DISPLAY ' ' . */
            _.Display($" ");

            /*" -4202- MOVE ZEROS TO W-QTD-LD-AUTO-0, W-QTD-LD-AUTO-1, W-QTD-LD-AUTO-2, W-QTD-LD-AUTO-3, W-QTD-LD-AUTO-4, W-QTD-LD-AUTO-5, W-QTD-LD-AUTO-6, W-QTD-LD-AUTO-7, W-QTD-LD-AUTO-8, W-QTD-LD-AUTO-9, W-QTD-LD-AUTO-A, W-QTD-LD-AUTO-B, W-QTD-LD-AUTO-C, W-QTD-LD-AUTO-D, W-QTD-LD-AUTO-E, W-QTD-LD-AUTO-F, W-QTD-LD-AUTO-G, W-QTD-LD-AUTO-H, W-QTD-LD-AUTO-I, W-QTD-LD-AUTO-J. */
            _.Move(0, WAREA_AUXILIAR.W_QTD_LD_AUTO_0, WAREA_AUXILIAR.W_QTD_LD_AUTO_1, WAREA_AUXILIAR.W_QTD_LD_AUTO_2, WAREA_AUXILIAR.W_QTD_LD_AUTO_3, WAREA_AUXILIAR.W_QTD_LD_AUTO_4, WAREA_AUXILIAR.W_QTD_LD_AUTO_5, WAREA_AUXILIAR.W_QTD_LD_AUTO_6, WAREA_AUXILIAR.W_QTD_LD_AUTO_7, WAREA_AUXILIAR.W_QTD_LD_AUTO_8, WAREA_AUXILIAR.W_QTD_LD_AUTO_9, WAREA_AUXILIAR.W_QTD_LD_AUTO_A, WAREA_AUXILIAR.W_QTD_LD_AUTO_B, WAREA_AUXILIAR.W_QTD_LD_AUTO_C, WAREA_AUXILIAR.W_QTD_LD_AUTO_D, WAREA_AUXILIAR.W_QTD_LD_AUTO_E, WAREA_AUXILIAR.W_QTD_LD_AUTO_F, WAREA_AUXILIAR.W_QTD_LD_AUTO_G, WAREA_AUXILIAR.W_QTD_LD_AUTO_H, WAREA_AUXILIAR.W_QTD_LD_AUTO_I, WAREA_AUXILIAR.W_QTD_LD_AUTO_J);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_SAIDA*/

        [StopWatch]
        /*" R2050-00-GERAR-TRAILLER-AUTO-SECTION */
        private void R2050_00_GERAR_TRAILLER_AUTO_SECTION()
        {
            /*" -4218- MOVE 'R2050-00-GERAR-TRAILLER-AUTO' TO PARAGRAFO. */
            _.Move("R2050-00-GERAR-TRAILLER-AUTO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4220- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4222- MOVE SPACES TO REG-TRAILLER. */
            _.Move("", LBFPF991.REG_TRAILLER);

            /*" -4225- MOVE 'T' TO RT-TIPO-REG OF REG-TRAILLER. */
            _.Move("T", LBFPF991.REG_TRAILLER.RT_TIPO_REG);

            /*" -4228- MOVE 'PRPSASSE' TO RT-NOME-EMPRESA OF REG-TRAILLER. */
            _.Move("PRPSASSE", LBFPF991.REG_TRAILLER.RT_NOME_EMPRESA);

            /*" -4231- MOVE W-QTD-LD-AUTO-0 TO RT-QTDE-TIPO-0 OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_AUTO_0, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_0);

            /*" -4234- MOVE W-QTD-LD-AUTO-1 TO RT-QTDE-TIPO-1 OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_AUTO_1, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_1);

            /*" -4237- MOVE W-QTD-LD-AUTO-2 TO RT-QTDE-TIPO-2 OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_AUTO_2, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_2);

            /*" -4240- MOVE W-QTD-LD-AUTO-3 TO RT-QTDE-TIPO-3 OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_AUTO_3, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_3);

            /*" -4243- MOVE W-QTD-LD-AUTO-4 TO RT-QTDE-TIPO-4 OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_AUTO_4, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_4);

            /*" -4246- MOVE W-QTD-LD-AUTO-5 TO RT-QTDE-TIPO-5 OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_AUTO_5, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_5);

            /*" -4249- MOVE W-QTD-LD-AUTO-6 TO RT-QTDE-TIPO-6 OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_AUTO_6, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_6);

            /*" -4252- MOVE W-QTD-LD-AUTO-7 TO RT-QTDE-TIPO-7 OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_AUTO_7, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_7);

            /*" -4255- MOVE W-QTD-LD-AUTO-8 TO RT-QTDE-TIPO-8 OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_AUTO_8, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_8);

            /*" -4258- MOVE W-QTD-LD-AUTO-9 TO RT-QTDE-TIPO-9 OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_AUTO_9, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_9);

            /*" -4261- MOVE W-QTD-LD-AUTO-A TO RT-QTDE-TIPO-A OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_AUTO_A, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_A);

            /*" -4264- MOVE W-QTD-LD-AUTO-B TO RT-QTDE-TIPO-B OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_AUTO_B, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_B);

            /*" -4267- MOVE W-QTD-LD-AUTO-C TO RT-QTDE-TIPO-C OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_AUTO_C, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_C);

            /*" -4270- MOVE W-QTD-LD-AUTO-D TO RT-QTDE-TIPO-D OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_AUTO_D, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_D);

            /*" -4273- MOVE W-QTD-LD-AUTO-E TO RT-QTDE-TIPO-E OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_AUTO_E, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_E);

            /*" -4276- MOVE W-QTD-LD-AUTO-F TO RT-QTDE-TIPO-F OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_AUTO_F, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_F);

            /*" -4279- MOVE W-QTD-LD-AUTO-G TO RT-QTDE-TIPO-G OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_AUTO_G, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_G);

            /*" -4282- MOVE W-QTD-LD-AUTO-H TO RT-QTDE-TIPO-H OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_AUTO_H, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_H);

            /*" -4285- MOVE W-QTD-LD-AUTO-I TO RT-QTDE-TIPO-I OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_AUTO_I, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_I);

            /*" -4288- MOVE W-QTD-LD-AUTO-J TO RT-QTDE-TIPO-J OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_AUTO_J, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_J);

            /*" -4300- COMPUTE RT-QTDE-TOTAL OF REG-TRAILLER = W-QTD-LD-AUTO-1 + W-QTD-LD-AUTO-2 + W-QTD-LD-AUTO-3 + W-QTD-LD-AUTO-4 + W-QTD-LD-AUTO-5 + W-QTD-LD-AUTO-6 + W-QTD-LD-AUTO-7 + W-QTD-LD-AUTO-8 + W-QTD-LD-AUTO-9 + W-QTD-LD-AUTO-A + W-QTD-LD-AUTO-B + W-QTD-LD-AUTO-C + W-QTD-LD-AUTO-D + W-QTD-LD-AUTO-E + W-QTD-LD-AUTO-F + W-QTD-LD-AUTO-G + W-QTD-LD-AUTO-H + W-QTD-LD-AUTO-I + W-QTD-LD-AUTO-J. */
            LBFPF991.REG_TRAILLER.RT_QTDE_TOTAL.Value = WAREA_AUXILIAR.W_QTD_LD_AUTO_1 + WAREA_AUXILIAR.W_QTD_LD_AUTO_2 + WAREA_AUXILIAR.W_QTD_LD_AUTO_3 + WAREA_AUXILIAR.W_QTD_LD_AUTO_4 + WAREA_AUXILIAR.W_QTD_LD_AUTO_5 + WAREA_AUXILIAR.W_QTD_LD_AUTO_6 + WAREA_AUXILIAR.W_QTD_LD_AUTO_7 + WAREA_AUXILIAR.W_QTD_LD_AUTO_8 + WAREA_AUXILIAR.W_QTD_LD_AUTO_9 + WAREA_AUXILIAR.W_QTD_LD_AUTO_A + WAREA_AUXILIAR.W_QTD_LD_AUTO_B + WAREA_AUXILIAR.W_QTD_LD_AUTO_C + WAREA_AUXILIAR.W_QTD_LD_AUTO_D + WAREA_AUXILIAR.W_QTD_LD_AUTO_E + WAREA_AUXILIAR.W_QTD_LD_AUTO_F + WAREA_AUXILIAR.W_QTD_LD_AUTO_G + WAREA_AUXILIAR.W_QTD_LD_AUTO_H + WAREA_AUXILIAR.W_QTD_LD_AUTO_I + WAREA_AUXILIAR.W_QTD_LD_AUTO_J;

            /*" -4300- MOVE REG-TRAILLER TO REG-MOV-AUTO. */
            _.Move(LBFPF991.REG_TRAILLER, REG_MOV_AUTO);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2050_SAIDA*/

        [StopWatch]
        /*" R2100-00-TB-CONTROLE-SECTION */
        private void R2100_00_TB_CONTROLE_SECTION()
        {
            /*" -4317- MOVE 'PRPCAVC' TO ARQSIVPF-SIGLA-ARQUIVO OF DCLARQUIVOS-SIVPF */
            _.Move("PRPCAVC", ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SIGLA_ARQUIVO);

            /*" -4320- MOVE 8 TO ARQSIVPF-SISTEMA-ORIGEM OF DCLARQUIVOS-SIVPF */
            _.Move(8, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SISTEMA_ORIGEM);

            /*" -4323- MOVE RH-NSAS OF REG-HEADER TO ARQSIVPF-NSAS-SIVPF OF DCLARQUIVOS-SIVPF */
            _.Move(LXFPF990.REG_HEADER.RH_NSAS, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF);

            /*" -4326- MOVE SISTEMAS-DATA-MOV-ABERTO OF DCLSISTEMAS TO ARQSIVPF-DATA-PROCESSAMENTO OF DCLARQUIVOS-SIVPF */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_PROCESSAMENTO);

            /*" -4328- MOVE RH-DATA-GERACAO OF REG-HEADER TO W-DATA-TRABALHO */
            _.Move(LXFPF990.REG_HEADER.RH_DATA_GERACAO, WAREA_AUXILIAR.W_DATA_TRABALHO);

            /*" -4330- MOVE W-DIA-TRABALHO TO W-DIA-SQL OF W-DATA-SQL1 */
            _.Move(WAREA_AUXILIAR.FILLER_8.W_DIA_TRABALHO, WAREA_AUXILIAR.W_DATA_SQL1.W_DIA_SQL);

            /*" -4332- MOVE W-MES-TRABALHO TO W-MES-SQL OF W-DATA-SQL1 */
            _.Move(WAREA_AUXILIAR.FILLER_8.W_MES_TRABALHO, WAREA_AUXILIAR.W_DATA_SQL1.W_MES_SQL);

            /*" -4334- MOVE W-ANO-TRABALHO TO W-ANO-SQL OF W-DATA-SQL1 */
            _.Move(WAREA_AUXILIAR.FILLER_8.W_ANO_TRABALHO, WAREA_AUXILIAR.W_DATA_SQL1.W_ANO_SQL);

            /*" -4337- MOVE '-' TO W-BARRA1 OF W-DATA-SQL1, W-BARRA2 OF W-DATA-SQL1 */
            _.Move("-", WAREA_AUXILIAR.W_DATA_SQL1.W_BARRA1_1);
            _.Move("-", WAREA_AUXILIAR.W_DATA_SQL1.W_BARRA2_1);


            /*" -4340- MOVE W-DATA-SQL TO ARQSIVPF-DATA-GERACAO OF DCLARQUIVOS-SIVPF */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_GERACAO);

            /*" -4343- MOVE W-QTD-LD-SIVPF-3 TO ARQSIVPF-QTDE-REG-GER OF DCLARQUIVOS-SIVPF. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_SIVPF_3, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_QTDE_REG_GER);

            /*" -4351- PERFORM R2100_00_TB_CONTROLE_DB_INSERT_1 */

            R2100_00_TB_CONTROLE_DB_INSERT_1();

            /*" -4355- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -4357- MOVE SPACES TO W-FIM-MOVTO-SULA */
                _.Move("", WAREA_AUXILIAR.W_FIM_MOVTO_SULA);

                /*" -4358- DISPLAY 'PF0103B - FIM ANORMAL' */
                _.Display($"PF0103B - FIM ANORMAL");

                /*" -4359- DISPLAY '          ERRO INSERT TABELA ARQUIVOS-SIVPF / 3' */
                _.Display($"          ERRO INSERT TABELA ARQUIVOS-SIVPF / 3");

                /*" -4361- DISPLAY '          SIGLA DO ARQIVO...............  ' ARQSIVPF-SIGLA-ARQUIVO OF DCLARQUIVOS-SIVPF */
                _.Display($"          SIGLA DO ARQIVO...............  {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SIGLA_ARQUIVO}");

                /*" -4363- DISPLAY '          NSAS SIVPF....................  ' ARQSIVPF-NSAS-SIVPF OF DCLARQUIVOS-SIVPF */
                _.Display($"          NSAS SIVPF....................  {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF}");

                /*" -4365- DISPLAY '          DATA GERACAO..................  ' ARQSIVPF-DATA-GERACAO OF DCLARQUIVOS-SIVPF */
                _.Display($"          DATA GERACAO..................  {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_GERACAO}");

                /*" -4367- DISPLAY '          QTDE. REGISTROS...............  ' ARQSIVPF-QTDE-REG-GER OF DCLARQUIVOS-SIVPF */
                _.Display($"          QTDE. REGISTROS...............  {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_QTDE_REG_GER}");

                /*" -4369- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -4370- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -4370- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R2100-00-TB-CONTROLE-DB-INSERT-1 */
        public void R2100_00_TB_CONTROLE_DB_INSERT_1()
        {
            /*" -4351- EXEC SQL INSERT INTO SEGUROS.ARQUIVOS_SIVPF VALUES (:DCLARQUIVOS-SIVPF.ARQSIVPF-SIGLA-ARQUIVO, :DCLARQUIVOS-SIVPF.ARQSIVPF-SISTEMA-ORIGEM, :DCLARQUIVOS-SIVPF.ARQSIVPF-NSAS-SIVPF, :DCLARQUIVOS-SIVPF.ARQSIVPF-DATA-GERACAO, :DCLARQUIVOS-SIVPF.ARQSIVPF-QTDE-REG-GER, :DCLARQUIVOS-SIVPF.ARQSIVPF-DATA-PROCESSAMENTO) END-EXEC. */

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
        /*" R6200-00-DECLARE-FONTES-SECTION */
        private void R6200_00_DECLARE_FONTES_SECTION()
        {
            /*" -4379- MOVE 'R6200-DECLA-FONTES      ' TO PARAGRAFO. */
            _.Move("R6200-DECLA-FONTES      ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4381- MOVE 'DECLARE FONTES         ' TO COMANDO. */
            _.Move("DECLARE FONTES         ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4387- PERFORM R6200_00_DECLARE_FONTES_DB_DECLARE_1 */

            R6200_00_DECLARE_FONTES_DB_DECLARE_1();

            /*" -4389- PERFORM R6200_00_DECLARE_FONTES_DB_OPEN_1 */

            R6200_00_DECLARE_FONTES_DB_OPEN_1();

            /*" -4392- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4393- DISPLAY 'R6200 - PROBLEMAS DECLARE (FONTES   ) ..  ' */
                _.Display($"R6200 - PROBLEMAS DECLARE (FONTES   ) ..  ");

                /*" -4394- DISPLAY 'SQLCODE - ' SQLCODE */
                _.Display($"SQLCODE - {DB.SQLCODE}");

                /*" -4394- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R6200-00-DECLARE-FONTES-DB-OPEN-1 */
        public void R6200_00_DECLARE_FONTES_DB_OPEN_1()
        {
            /*" -4389- EXEC SQL OPEN CFONTES END-EXEC. */

            CFONTES.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R6200_99_SAIDA*/

        [StopWatch]
        /*" R6210-00-FETCH-FONTES-SECTION */
        private void R6210_00_FETCH_FONTES_SECTION()
        {
            /*" -4406- MOVE 'R6210-FETCH-FONTES     ' TO PARAGRAFO. */
            _.Move("R6210-FETCH-FONTES     ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4408- MOVE 'FETCH   FONTES         ' TO COMANDO. */
            _.Move("FETCH   FONTES         ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4411- PERFORM R6210_00_FETCH_FONTES_DB_FETCH_1 */

            R6210_00_FETCH_FONTES_DB_FETCH_1();

            /*" -4414- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4415- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -4416- MOVE 'S' TO W-FIM-FONTES */
                    _.Move("S", WAREA_AUXILIAR.W_FIM_FONTES);

                    /*" -4416- PERFORM R6210_00_FETCH_FONTES_DB_CLOSE_1 */

                    R6210_00_FETCH_FONTES_DB_CLOSE_1();

                    /*" -4418- ELSE */
                }
                else
                {


                    /*" -4418- PERFORM R6210_00_FETCH_FONTES_DB_CLOSE_2 */

                    R6210_00_FETCH_FONTES_DB_CLOSE_2();

                    /*" -4420- DISPLAY '6200 - (PROBLEMAS NO FETCH CFONTES  ) ..' */
                    _.Display($"6200 - (PROBLEMAS NO FETCH CFONTES  ) ..");

                    /*" -4421- DISPLAY 'SQLCODE - ' SQLCODE */
                    _.Display($"SQLCODE - {DB.SQLCODE}");

                    /*" -4421- PERFORM R9999-00-FINALIZAR. */

                    R9999_00_FINALIZAR_SECTION();
                }

            }


        }

        [StopWatch]
        /*" R6210-00-FETCH-FONTES-DB-FETCH-1 */
        public void R6210_00_FETCH_FONTES_DB_FETCH_1()
        {
            /*" -4411- EXEC SQL FETCH CFONTES INTO :DCLFONTES.FONTES-COD-FONTE, :DCLFONTES.FONTES-ULT-PROP-AUTOMAT END-EXEC. */

            if (CFONTES.Fetch())
            {
                _.Move(CFONTES.DCLFONTES_FONTES_COD_FONTE, FONTES.DCLFONTES.FONTES_COD_FONTE);
                _.Move(CFONTES.DCLFONTES_FONTES_ULT_PROP_AUTOMAT, FONTES.DCLFONTES.FONTES_ULT_PROP_AUTOMAT);
            }

        }

        [StopWatch]
        /*" R6210-00-FETCH-FONTES-DB-CLOSE-1 */
        public void R6210_00_FETCH_FONTES_DB_CLOSE_1()
        {
            /*" -4416- EXEC SQL CLOSE CFONTES END-EXEC */

            CFONTES.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R6210_99_SAIDA*/

        [StopWatch]
        /*" R6210-00-FETCH-FONTES-DB-CLOSE-2 */
        public void R6210_00_FETCH_FONTES_DB_CLOSE_2()
        {
            /*" -4418- EXEC SQL CLOSE CFONTES END-EXEC */

            CFONTES.Close();

        }

        [StopWatch]
        /*" R6220-00-CARREGA-FONTES-SECTION */
        private void R6220_00_CARREGA_FONTES_SECTION()
        {
            /*" -4433- MOVE 'R6220-CARREGA-FONTES    ' TO PARAGRAFO. */
            _.Move("R6220-CARREGA-FONTES    ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4435- MOVE 'CARREGA FONTES          ' TO COMANDO. */
            _.Move("CARREGA FONTES          ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4438- MOVE FONTES-COD-FONTE OF DCLFONTES TO TAB-COD-FILIAL (FONTES-COD-FONTE OF DCLFONTES). */
            _.Move(FONTES.DCLFONTES.FONTES_COD_FONTE, WAREA_AUXILIAR.TAB_FILIAL.TAB_FILIAIS[FONTES.DCLFONTES.FONTES_COD_FONTE].TAB_COD_FILIAL);

            /*" -4440- SET I07 UP BY 1. */
            I07.Value += 1;

            /*" -4440- PERFORM R6210-00-FETCH-FONTES. */

            R6210_00_FETCH_FONTES_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R6220_99_SAIDA*/

        [StopWatch]
        /*" R9978-00-VERIFICAR-PROPOSTA-SECTION */
        private void R9978_00_VERIFICAR_PROPOSTA_SECTION()
        {
            /*" -4453- MOVE 'R9978-00-VERIFICAR-PROPOSTA' TO PARAGRAFO. */
            _.Move("R9978-00-VERIFICAR-PROPOSTA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4455- MOVE 'SELECT PROPOSTA_FIDELIZ' TO COMANDO. */
            _.Move("SELECT PROPOSTA_FIDELIZ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4462- PERFORM R9978_00_VERIFICAR_PROPOSTA_DB_SELECT_1 */

            R9978_00_VERIFICAR_PROPOSTA_DB_SELECT_1();

            /*" -4465- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -4467- IF SQLCODE EQUAL 100 NEXT SENTENCE */

                if (DB.SQLCODE == 100)
                {

                    /*" -4468- ELSE */
                }
                else
                {


                    /*" -4469- DISPLAY 'PF0103B FIM ANORMAL' */
                    _.Display($"PF0103B FIM ANORMAL");

                    /*" -4470- DISPLAY '        ERRO SELECT TAB. PROPOSTA-FIDELIZ' */
                    _.Display($"        ERRO SELECT TAB. PROPOSTA-FIDELIZ");

                    /*" -4472- DISPLAY '        NUM DA PROPOSTA .... ' PROPOFID-NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ */
                    _.Display($"        NUM DA PROPOSTA .... {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}");

                    /*" -4473- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -4474- PERFORM R9999-00-FINALIZAR */

                    R9999_00_FINALIZAR_SECTION();

                    /*" -4475- ELSE */
                }

            }
            else
            {


                /*" -4475- MOVE 2 TO W88-PROPOSTA. */
                _.Move(2, WREA88.W88_PROPOSTA);
            }


        }

        [StopWatch]
        /*" R9978-00-VERIFICAR-PROPOSTA-DB-SELECT-1 */
        public void R9978_00_VERIFICAR_PROPOSTA_DB_SELECT_1()
        {
            /*" -4462- EXEC SQL SELECT NUM_SICOB INTO :DCLPROPOSTA-FIDELIZ.PROPOFID-NUM-SICOB FROM SEGUROS.PROPOSTA_FIDELIZ WHERE NUM_PROPOSTA_SIVPF = :DCLPROPOSTA-FIDELIZ.PROPOFID-NUM-PROPOSTA-SIVPF WITH UR END-EXEC. */

            var r9978_00_VERIFICAR_PROPOSTA_DB_SELECT_1_Query1 = new R9978_00_VERIFICAR_PROPOSTA_DB_SELECT_1_Query1()
            {
                PROPOFID_NUM_PROPOSTA_SIVPF = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF.ToString(),
            };

            var executed_1 = R9978_00_VERIFICAR_PROPOSTA_DB_SELECT_1_Query1.Execute(r9978_00_VERIFICAR_PROPOSTA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PROPOFID_NUM_SICOB, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_SICOB);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9978_SAIDA*/

        [StopWatch]
        /*" R9979-00-MONTA-TAB-CRITICA-SECTION */
        private void R9979_00_MONTA_TAB_CRITICA_SECTION()
        {
            /*" -4485- MOVE 'R9979-00-MONTA-TAB-CRITICA' TO PARAGRAFO. */
            _.Move("R9979-00-MONTA-TAB-CRITICA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4488- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4489- IF W-INDICE-1 GREATER 999 */

            if (WAREA_AUXILIAR.W_INDICE_1 > 999)
            {

                /*" -4490- DISPLAY ' ' */
                _.Display($" ");

                /*" -4491- DISPLAY ' ' */
                _.Display($" ");

                /*" -4492- DISPLAY '///////////////////////////////////////////////' */
                _.Display($"///////////////////////////////////////////////");

                /*" -4493- DISPLAY '//                                           //' */
                _.Display($"//                                           //");

                /*" -4494- DISPLAY '//           PROGRAMA =>  PF0103B            //' */
                _.Display($"//           PROGRAMA =>  PF0103B            //");

                /*" -4495- DISPLAY '//                                           //' */
                _.Display($"//                                           //");

                /*" -4496- DISPLAY '//                 TERMINO                   //' */
                _.Display($"//                 TERMINO                   //");

                /*" -4497- DISPLAY '//                                           //' */
                _.Display($"//                                           //");

                /*" -4498- DISPLAY '//       ==>   A N O R M A L     <==         //' */
                _.Display($"//       ==>   A N O R M A L     <==         //");

                /*" -4499- DISPLAY '//                                           //' */
                _.Display($"//                                           //");

                /*" -4500- DISPLAY '//    ==> ESTOURO DA TABELA DE ERROS <==     //' */
                _.Display($"//    ==> ESTOURO DA TABELA DE ERROS <==     //");

                /*" -4501- DISPLAY '//                                           //' */
                _.Display($"//                                           //");

                /*" -4502- DISPLAY '///////////////////////////////////////////////' */
                _.Display($"///////////////////////////////////////////////");

                /*" -4503- DISPLAY ' ' */
                _.Display($" ");

                /*" -4504- DISPLAY ' ' */
                _.Display($" ");

                /*" -4505- DISPLAY 'VALOR DO INDICE     ' W-INDICE-1 */
                _.Display($"VALOR DO INDICE     {WAREA_AUXILIAR.W_INDICE_1}");

                /*" -4506- DISPLAY ' ' */
                _.Display($" ");

                /*" -4507- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -4508- PERFORM R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION();

                /*" -4510- END-IF */
            }


            /*" -4511- IF R3-NSAS OF REG-PROPOSTA-SASSE > ZEROS */

            if (LXFCT004.REG_PROPOSTA_SASSE.R3_NSAS > 00)
            {

                /*" -4513- MOVE R3-NSAS OF REG-PROPOSTA-SASSE TO W-TB-NSAS(W-INDICE-1) */
                _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_NSAS, AREA_DAS_TABELAS.W_TAB_CONSISTENCIA.FILLER_47[WAREA_AUXILIAR.W_INDICE_1].W_TB_NSAS);

                /*" -4514- ELSE */
            }
            else
            {


                /*" -4518- MOVE W-NSAS-FILIAL TO W-TB-NSAS(W-INDICE-1). */
                _.Move(WAREA_AUXILIAR.W_NSAS_FILIAL, AREA_DAS_TABELAS.W_TAB_CONSISTENCIA.FILLER_47[WAREA_AUXILIAR.W_INDICE_1].W_TB_NSAS);
            }


            /*" -4521- MOVE R3-ORIGEM-PROPOSTA OF REG-PROPOSTA-SASSE TO W-TB-ORIGEM(W-INDICE-1) */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_ORIGEM_PROPOSTA_AIC, AREA_DAS_TABELAS.W_TAB_CONSISTENCIA.FILLER_47[WAREA_AUXILIAR.W_INDICE_1].W_TB_ORIGEM);

            /*" -4524- MOVE R3-NUM-PROPOSTA OF REG-PROPOSTA-SASSE TO W-TB-NUM-PROPOSTA(W-INDICE-1) */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_NUM_PROPOSTA, AREA_DAS_TABELAS.W_TAB_CONSISTENCIA.FILLER_47[WAREA_AUXILIAR.W_INDICE_1].W_TB_NUM_PROPOSTA);

            /*" -4527- MOVE R3-SIT-PROPOSTA OF REG-PROPOSTA-SASSE TO W-TB-SIT-PROPOSTA(W-INDICE-1) */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_SIT_PROPOSTA, AREA_DAS_TABELAS.W_TAB_CONSISTENCIA.FILLER_47[WAREA_AUXILIAR.W_INDICE_1].W_TB_SIT_PROPOSTA);

            /*" -4528- MOVE R3-DATA-PROPOSTA OF REG-PROPOSTA-SASSE TO W-TB-DT-SITUACAO(W-INDICE-1). */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_DATA_PROPOSTA, AREA_DAS_TABELAS.W_TAB_CONSISTENCIA.FILLER_47[WAREA_AUXILIAR.W_INDICE_1].W_TB_DT_SITUACAO);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9979_SAIDA*/

        [StopWatch]
        /*" R9980-00-GERAR-RELATORIO-SECTION */
        private void R9980_00_GERAR_RELATORIO_SECTION()
        {
            /*" -4539- MOVE 'R9980-00-GERAR-RELATORIO' TO PARAGRAFO. */
            _.Move("R9980-00-GERAR-RELATORIO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4541- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4543- OPEN OUTPUT RPF0103B */
            RPF0103B.Open(REG_RPF0103B);

            /*" -4546- MOVE '/' TO W-BARRA1 OF W-DTMOVABE-I1, W-BARRA2 OF W-DTMOVABE-I1. */
            _.Move("/", WAREA_AUXILIAR.W_DTMOVABE_I1.W_BARRA1_0);
            _.Move("/", WAREA_AUXILIAR.W_DTMOVABE_I1.W_BARRA2_0);


            /*" -4548- MOVE W-DTMOVABE-I TO LC02-DATA. */
            _.Move(WAREA_AUXILIAR.W_DTMOVABE_I, LC00.LC02.LC02_DATA);

            /*" -4552- PERFORM R9981-00-INCONSISTENCIA VARYING W-INDICE-2 FROM 1 BY 1 UNTIL W-INDICE-2 GREATER W-INDICE-1. */

            for (WAREA_AUXILIAR.W_INDICE_2.Value = 1; !(WAREA_AUXILIAR.W_INDICE_2 > WAREA_AUXILIAR.W_INDICE_1); WAREA_AUXILIAR.W_INDICE_2.Value += 1)
            {

                R9981_00_INCONSISTENCIA_SECTION();
            }

            /*" -4552- CLOSE RPF0103B. */
            RPF0103B.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9980_SAIDA*/

        [StopWatch]
        /*" R9981-00-INCONSISTENCIA-SECTION */
        private void R9981_00_INCONSISTENCIA_SECTION()
        {
            /*" -4563- MOVE 'R9981-00-INCONSISTENCIA' TO PARAGRAFO. */
            _.Move("R9981-00-INCONSISTENCIA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4565- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4568- IF W-TB-NUM-PROPOSTA(W-INDICE-2) NOT NUMERIC OR W-TB-NUM-PROPOSTA(W-INDICE-2) EQUAL ZEROS */

            if (!AREA_DAS_TABELAS.W_TAB_CONSISTENCIA.FILLER_47[WAREA_AUXILIAR.W_INDICE_2].W_TB_NUM_PROPOSTA.IsNumeric() || AREA_DAS_TABELAS.W_TAB_CONSISTENCIA.FILLER_47[WAREA_AUXILIAR.W_INDICE_2].W_TB_NUM_PROPOSTA == 00)
            {

                /*" -4570- COMPUTE W-INDICE-2 = W-INDICE-1 + 1 */
                WAREA_AUXILIAR.W_INDICE_2.Value = WAREA_AUXILIAR.W_INDICE_1 + 1;

                /*" -4572- GO TO R9981-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R9981_SAIDA*/ //GOTO
                return;
            }


            /*" -4574- MOVE W-TB-NUM-PROPOSTA(W-INDICE-2) TO LC06-NUM-PROPOSTA */
            _.Move(AREA_DAS_TABELAS.W_TAB_CONSISTENCIA.FILLER_47[WAREA_AUXILIAR.W_INDICE_2].W_TB_NUM_PROPOSTA, LC00.LC06.LC06_NUM_PROPOSTA);

            /*" -4576- MOVE W-TB-SIT-PROPOSTA(W-INDICE-2) TO LC06-SITUACAO */
            _.Move(AREA_DAS_TABELAS.W_TAB_CONSISTENCIA.FILLER_47[WAREA_AUXILIAR.W_INDICE_2].W_TB_SIT_PROPOSTA, LC00.LC06.LC06_SITUACAO);

            /*" -4577- MOVE W-TB-DT-SITUACAO (W-INDICE-2) TO W-DATA-TRABALHO */
            _.Move(AREA_DAS_TABELAS.W_TAB_CONSISTENCIA.FILLER_47[WAREA_AUXILIAR.W_INDICE_2].W_TB_DT_SITUACAO, WAREA_AUXILIAR.W_DATA_TRABALHO);

            /*" -4578- MOVE W-DIA-TRABALHO TO W-DIA-SITUACAO OF W-DATA-SIT-RD */
            _.Move(WAREA_AUXILIAR.FILLER_8.W_DIA_TRABALHO, WAREA_AUXILIAR.W_DATA_SIT_RD.W_DIA_SITUACAO);

            /*" -4579- MOVE W-MES-TRABALHO TO W-MES-SITUACAO OF W-DATA-SIT-RD */
            _.Move(WAREA_AUXILIAR.FILLER_8.W_MES_TRABALHO, WAREA_AUXILIAR.W_DATA_SIT_RD.W_MES_SITUACAO);

            /*" -4580- MOVE W-ANO-TRABALHO TO W-ANO-SITUACAO OF W-DATA-SIT-RD */
            _.Move(WAREA_AUXILIAR.FILLER_8.W_ANO_TRABALHO, WAREA_AUXILIAR.W_DATA_SIT_RD.W_ANO_SITUACAO);

            /*" -4583- MOVE '/' TO W-BARRA1 OF W-DATA-SIT-RD W-BARRA2 OF W-DATA-SIT-RD. */
            _.Move("/", WAREA_AUXILIAR.W_DATA_SIT_RD.W_BARRA1_2);
            _.Move("/", WAREA_AUXILIAR.W_DATA_SIT_RD.W_BARRA2_2);


            /*" -4590- MOVE W-DATA-SITUACAO TO LC06-DATA-SITUACAO */
            _.Move(WAREA_AUXILIAR.W_DATA_SITUACAO, LC00.LC06.LC06_DATA_SITUACAO);

            /*" -4593- MOVE W-TB-DESCRI-ORIGEM(8) TO LC06-ORIGEM. */
            _.Move(AREA_DAS_TABELAS.W_TAB_ORIGEM_RD[8].W_TB_DESCRI_ORIGEM, LC00.LC06.LC06_ORIGEM);

            /*" -4595- MOVE W-TB-COD-DESCRI (W-INDICE-2) TO W-INDICE-ERRO. */
            _.Move(AREA_DAS_TABELAS.W_TAB_CONSISTENCIA.FILLER_47[WAREA_AUXILIAR.W_INDICE_2].W_TB_COD_DESCRI, WAREA_AUXILIAR.W_INDICE_ERRO);

            /*" -4606- MOVE W-TB-DESCRI-ERRO(W-INDICE-ERRO) TO LC06-DESCRICAO. */
            _.Move(AREA_DAS_TABELAS.W_TAB_DESCRICAO_RD[WAREA_AUXILIAR.W_INDICE_ERRO].W_TB_DESCRI_ERRO, LC00.LC06.LC06_DESCRICAO);

            /*" -4607- IF W-CONT-LINHAS GREATER 60 */

            if (WAREA_AUXILIAR.W_CONT_LINHAS > 60)
            {

                /*" -4609- PERFORM R9982-00-GRAVA-CABECALHO. */

                R9982_00_GRAVA_CABECALHO_SECTION();
            }


            /*" -4611- WRITE REG-RPF0103B FROM LC06 AFTER 1. */
            _.Move(LC00.LC06.GetMoveValues(), REG_RPF0103B);

            RPF0103B.Write(REG_RPF0103B.GetMoveValues().ToString());

            /*" -4611- ADD 1 TO W-CONT-LINHAS. */
            WAREA_AUXILIAR.W_CONT_LINHAS.Value = WAREA_AUXILIAR.W_CONT_LINHAS + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9981_SAIDA*/

        [StopWatch]
        /*" R9982-00-GRAVA-CABECALHO-SECTION */
        private void R9982_00_GRAVA_CABECALHO_SECTION()
        {
            /*" -4623- MOVE 'R9982-00-GRAVA-CABECALHO' TO PARAGRAFO. */
            _.Move("R9982-00-GRAVA-CABECALHO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4625- MOVE 'WRITE' TO COMANDO. */
            _.Move("WRITE", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4627- ADD 1 TO LC01-PAGINA. */
            LC00.LC01.LC01_PAGINA.Value = LC00.LC01.LC01_PAGINA + 1;

            /*" -4629- ACCEPT WS-TIME FROM TIME. */
            _.Move(_.AcceptDate("TIME"), WS_TIME);

            /*" -4630- MOVE WS-TIME-N TO WS-TIME-EDIT */
            _.Move(WS_TIME.WS_TIME_N, WS_TIME_EDIT);

            /*" -4632- MOVE WS-TIME-EDIT TO LC03-HORA. */
            _.Move(WS_TIME_EDIT, LC00.LC03.LC03_HORA);

            /*" -4634- MOVE W-TB-CANAL(W-INDICE-2) TO W-INDICE-ERRO. */
            _.Move(AREA_DAS_TABELAS.W_TAB_CONSISTENCIA.FILLER_47[WAREA_AUXILIAR.W_INDICE_2].W_TB_CANAL, WAREA_AUXILIAR.W_INDICE_ERRO);

            /*" -4636- MOVE W-TB-NSAS(W-INDICE-2) TO LC04-NSAS-SIVPF. */
            _.Move(AREA_DAS_TABELAS.W_TAB_CONSISTENCIA.FILLER_47[WAREA_AUXILIAR.W_INDICE_2].W_TB_NSAS, LC00.LC04.LC04_NSAS_SIVPF);

            /*" -4637- MOVE RH-DATA-GERACAO OF REG-HEADER TO W-DATA-TRABALHO */
            _.Move(LXFPF990.REG_HEADER.RH_DATA_GERACAO, WAREA_AUXILIAR.W_DATA_TRABALHO);

            /*" -4638- MOVE W-DIA-TRABALHO TO W-DIA-MOVABE OF W-DTMOVABE-I1 */
            _.Move(WAREA_AUXILIAR.FILLER_8.W_DIA_TRABALHO, WAREA_AUXILIAR.W_DTMOVABE_I1.W_DIA_MOVABE_0);

            /*" -4639- MOVE W-MES-TRABALHO TO W-MES-MOVABE OF W-DTMOVABE-I1 */
            _.Move(WAREA_AUXILIAR.FILLER_8.W_MES_TRABALHO, WAREA_AUXILIAR.W_DTMOVABE_I1.W_MES_MOVABE_0);

            /*" -4641- MOVE W-ANO-TRABALHO TO W-ANO-MOVABE OF W-DTMOVABE-I1 */
            _.Move(WAREA_AUXILIAR.FILLER_8.W_ANO_TRABALHO, WAREA_AUXILIAR.W_DTMOVABE_I1.W_ANO_MOVABE_0);

            /*" -4643- MOVE W-DTMOVABE-I TO LC04-DATA-GERACAO. */
            _.Move(WAREA_AUXILIAR.W_DTMOVABE_I, LC00.LC04.LC04_DATA_GERACAO);

            /*" -4644- WRITE REG-RPF0103B FROM LC01 AFTER PAGE. */
            _.Move(LC00.LC01.GetMoveValues(), REG_RPF0103B);

            RPF0103B.Write(REG_RPF0103B.GetMoveValues().ToString());

            /*" -4645- WRITE REG-RPF0103B FROM LC02 AFTER 1 */
            _.Move(LC00.LC02.GetMoveValues(), REG_RPF0103B);

            RPF0103B.Write(REG_RPF0103B.GetMoveValues().ToString());

            /*" -4646- WRITE REG-RPF0103B FROM LC03 AFTER 1 */
            _.Move(LC00.LC03.GetMoveValues(), REG_RPF0103B);

            RPF0103B.Write(REG_RPF0103B.GetMoveValues().ToString());

            /*" -4647- WRITE REG-RPF0103B FROM LC04 AFTER 2 */
            _.Move(LC00.LC04.GetMoveValues(), REG_RPF0103B);

            RPF0103B.Write(REG_RPF0103B.GetMoveValues().ToString());

            /*" -4649- WRITE REG-RPF0103B FROM LC07 AFTER 1 */
            _.Move(LC00.LC07.GetMoveValues(), REG_RPF0103B);

            RPF0103B.Write(REG_RPF0103B.GetMoveValues().ToString());

            /*" -4651- WRITE REG-RPF0103B FROM LC05 AFTER 2. */
            _.Move(LC00.LC05.GetMoveValues(), REG_RPF0103B);

            RPF0103B.Write(REG_RPF0103B.GetMoveValues().ToString());

            /*" -4651- MOVE 8 TO W-CONT-LINHAS. */
            _.Move(8, WAREA_AUXILIAR.W_CONT_LINHAS);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9982_SAIDA*/

        [StopWatch]
        /*" R9988-00-FECHAR-ARQUIVOS-SECTION */
        private void R9988_00_FECHAR_ARQUIVOS_SECTION()
        {
            /*" -4664- CLOSE MOV-SULA */
            MOV_SULA.Close();

            /*" -4665- IF WS-STATUS NOT EQUAL '00' */

            if (WAREA_AUXILIAR.WS_STATUS != "00")
            {

                /*" -4666- DISPLAY 'PF0103B - FIM ANORMAL' */
                _.Display($"PF0103B - FIM ANORMAL");

                /*" -4667- DISPLAY '          ERRO CLOSE MOV-SULA ' */
                _.Display($"          ERRO CLOSE MOV-SULA ");

                /*" -4669- DISPLAY '          FILE STATUS........ ' WS-STATUS */
                _.Display($"          FILE STATUS........ {WAREA_AUXILIAR.WS_STATUS}");

                /*" -4670- MOVE SPACES TO W-FIM-MOVTO-SULA */
                _.Move("", WAREA_AUXILIAR.W_FIM_MOVTO_SULA);

                /*" -4672- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


            /*" -4673- CLOSE MOV-AUTO. */
            MOV_AUTO.Close();

            /*" -4674- IF WS-STATUS NOT EQUAL '00' */

            if (WAREA_AUXILIAR.WS_STATUS != "00")
            {

                /*" -4675- DISPLAY 'PF0103B - FIM ANORMAL' */
                _.Display($"PF0103B - FIM ANORMAL");

                /*" -4676- DISPLAY '          ERRO CLOSE MOV-SULA ' */
                _.Display($"          ERRO CLOSE MOV-SULA ");

                /*" -4678- DISPLAY '          FILE STATUS........ ' WS-STATUS */
                _.Display($"          FILE STATUS........ {WAREA_AUXILIAR.WS_STATUS}");

                /*" -4679- MOVE SPACES TO W-FIM-MOVTO-SULA */
                _.Move("", WAREA_AUXILIAR.W_FIM_MOVTO_SULA);

                /*" -4679- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9988_SAIDA*/

        [StopWatch]
        /*" R9999-00-FINALIZAR-SECTION */
        private void R9999_00_FINALIZAR_SECTION()
        {
            /*" -4695- DISPLAY ' ' */
            _.Display($" ");

            /*" -4696- IF W-FIM-MOVTO-SULA = 'FIM' */

            if (WAREA_AUXILIAR.W_FIM_MOVTO_SULA == "FIM")
            {

                /*" -4697- DISPLAY '*--------------------------------*' */
                _.Display($"*--------------------------------*");

                /*" -4698- DISPLAY '* PF0103B - FIM NORMAL           *' */
                _.Display($"* PF0103B - FIM NORMAL           *");

                /*" -4699- DISPLAY '*--------------------------------*' */
                _.Display($"*--------------------------------*");

                /*" -4700- MOVE 'COMMIT WORK' TO COMANDO */
                _.Move("COMMIT WORK", WABEND.LOCALIZA_ABEND_2.COMANDO);

                /*" -4700- EXEC SQL COMMIT WORK END-EXEC */

                DatabaseConnection.Instance.CommitTransaction();

                /*" -4702- MOVE 0 TO RETURN-CODE */
                _.Move(0, RETURN_CODE);

                /*" -4703- ELSE */
            }
            else
            {


                /*" -4704- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, WABEND.WSQLCODE);

                /*" -4705- MOVE SQLERRD(1) TO WSQLERRD1 */
                _.Move(DB.SQLERRD[1], WABEND.WSQLERRD1);

                /*" -4706- MOVE SQLERRD(2) TO WSQLERRD2 */
                _.Move(DB.SQLERRD[2], WABEND.WSQLERRD2);

                /*" -4707- DISPLAY WABEND */
                _.Display(WABEND);

                /*" -4708- DISPLAY '*---------------------------------*' */
                _.Display($"*---------------------------------*");

                /*" -4709- DISPLAY '* PF0103B - FIM ANORMAL           *' */
                _.Display($"* PF0103B - FIM ANORMAL           *");

                /*" -4710- DISPLAY '*           ROLLBACK EM ANDAMENTO *' */
                _.Display($"*           ROLLBACK EM ANDAMENTO *");

                /*" -4711- DISPLAY '*---------------------------------*' */
                _.Display($"*---------------------------------*");

                /*" -4712- MOVE 'ROLLBACK WORK' TO COMANDO */
                _.Move("ROLLBACK WORK", WABEND.LOCALIZA_ABEND_2.COMANDO);

                /*" -4712- EXEC SQL ROLLBACK WORK END-EXEC */

                DatabaseConnection.Instance.RollbackTransaction();

                /*" -4715- MOVE 09 TO RETURN-CODE. */
                _.Move(09, RETURN_CODE);
            }


            /*" -4715- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9999_SAIDA*/
    }
}