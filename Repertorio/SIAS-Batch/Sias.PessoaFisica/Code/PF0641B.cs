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
using Sias.PessoaFisica.DB2.PF0641B;

namespace Code
{
    public class PF0641B
    {
        public bool IsCall { get; set; }

        public PF0641B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *-----------------------*                                               */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO .................  LER MOVIMENTO DE ESTOQUE DE M.R  E *      */
        /*"      *                             GERA TABELAS CORPORATIVAS PRODUTOS *      */
        /*"      *                             DE FIDELIZACAO, E MOVIMENTO A CEF. *      */
        /*"      *   ANALISE/PROGRAMACAO.....  LUIZ CARLOS / REGINALDO SILVA      *      */
        /*"      *   PROGRAMA ...............  PF0641B                            *      */
        /*"      *   DATA PROMOCAO...........  14/01/2010.                        *      */
        /*"      *                                                                *      */
        /*"      *   ESTE PROGRAMA FOI GERADO COM BASE NO PROGRAMA PF0621B, CASO  *      */
        /*"      *   SEJA NECESSARIO SE ALTERAR UM DOS PROGRAMAS, ANALISAR SE  A  *      */
        /*"      *   ALTERACAO DEVE SER IMPLEMENTADA EM AMBOS.                    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 06             IMPACTO DA INCLUSAO DO CAMPO             *      */
        /*"      *                       IND_TP_CONTA NA TABELA PROPOSTA_FIDELIZ. *      */
        /*"      * ATENDE DEMANDA 175.167                                         *      */
        /*"      *                                                                *      */
        /*"      * PROCURE V.06          MARCUS VALERIO                           *      */
        /*"      *                       03/12/2018                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 05             CRIAR A ROTINA DE INCLUSAO DO REGISTRO   *      */
        /*"      * ATENDE REDMINE 3224   TIPO C - VENDAS DE PROPOSTAS NO CORRESP  *      */
        /*"      *                       CAIXA - SICAQ                            *      */
        /*"      *                                                                *      */
        /*"      * PROCURE V.05          REGINALDO SILVA                          *      */
        /*"      *                                                                *      */
        /*"      *                       21/08/2018                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 04             IMPACTO DA INCLUSAO DO CAMPO             *      */
        /*"      * ATENDE CADMUS 140.553 IND_TP_PROPOSTA NA TABELA                *      */
        /*"      *                       PROPOSTA_FIDELIZ.                        *      */
        /*"      * PROCURE V.04          FRANK CARVALHO                           *      */
        /*"      *                       08/08/2016                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 03             ALTERACOES NOS REGISTROS TIPO 3 E TIPO A *      */
        /*"      * ATENDE CADMUS 97713   CAMPOS :  OPERACAO E NUMERO DE CONTA     *      */
        /*"      *                                                                *      */
        /*"      * PROCURE NSGD          REGINALDO SILVA                          *      */
        /*"      *                       22/05/2014                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 02             AJUSTE INSERT HIST_PROP_FIDELIZ          *      */
        /*"      * ATENDE CADMUS 88764   COD-EMPRESA    E   COD-PRODUTO           *      */
        /*"      *                                                                *      */
        /*"      * PROCURE IHP           REGINALDO SILVA                          *      */
        /*"      *                       11/11/2013                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 01             AJUSTE NOS SELECTS DB2 V10               *      */
        /*"      * ATENDE CADMUS 84809   DB2.V10  SELECTS                         *      */
        /*"      *                                                                *      */
        /*"      * PROCURE DB2           REGINALDO SILVA                          *      */
        /*"      *                       10/09/2013                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"1     *--------------------*                                                  */
        #endregion


        #region VARIABLES

        public FileBasis _MOV_MRISCO { get; set; } = new FileBasis(new PIC("X", "300", "X(300)"));

        public FileBasis MOV_MRISCO
        {
            get
            {
                _.Move(REG_MRISCO, _MOV_MRISCO); VarBasis.RedefinePassValue(REG_MRISCO, _MOV_MRISCO, REG_MRISCO); return _MOV_MRISCO;
            }
        }
        public FileBasis _MOV_CEF { get; set; } = new FileBasis(new PIC("X", "300", "X(300)"));

        public FileBasis MOV_CEF
        {
            get
            {
                _.Move(REG_MOV_CEF, _MOV_CEF); VarBasis.RedefinePassValue(REG_MOV_CEF, _MOV_CEF, REG_MOV_CEF); return _MOV_CEF;
            }
        }
        public FileBasis _MOV_FNAE { get; set; } = new FileBasis(new PIC("X", "300", "X(300)"));

        public FileBasis MOV_FNAE
        {
            get
            {
                _.Move(REG_MOV_FNAE, _MOV_FNAE); VarBasis.RedefinePassValue(REG_MOV_FNAE, _MOV_FNAE, REG_MOV_FNAE); return _MOV_FNAE;
            }
        }
        /*"01   REG-MRISCO.*/
        public PF0641B_REG_MRISCO REG_MRISCO { get; set; } = new PF0641B_REG_MRISCO();
        public class PF0641B_REG_MRISCO : VarBasis
        {
            /*"     10  REG-TIPO-SIGAT                  PIC X(001).*/
            public StringBasis REG_TIPO_SIGAT { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"     10  REG-NUM-PROPOSTA                PIC 9(014).*/
            public IntBasis REG_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
            /*"     10  FILLER                          PIC X(285).*/
            public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "285", "X(285)."), @"");
            /*"01   REG-MOV-CEF                        PIC X(300).*/
        }
        public StringBasis REG_MOV_CEF { get; set; } = new StringBasis(new PIC("X", "300", "X(300)."), @"");
        /*"01   REG-MOV-FNAE                       PIC X(300).*/
        public StringBasis REG_MOV_FNAE { get; set; } = new StringBasis(new PIC("X", "300", "X(300)."), @"");

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
        public IntBasis I06 { get; set; } = new IntBasis(new PIC("9", "4", "9(4)"));
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
        public PF0641B_W_REG_HEADER W_REG_HEADER { get; set; } = new PF0641B_W_REG_HEADER();
        public class PF0641B_W_REG_HEADER : VarBasis
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
            public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "44", "X(044)."), @"");
            /*"     05  W-RH-AGE-GERADORA           PIC  9(004).*/
            public IntBasis W_RH_AGE_GERADORA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"     05  FILLER                      PIC  X(226).*/
            public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "226", "X(226)."), @"");
            /*"01  WAREA-AUXILIAR.*/
        }
        public PF0641B_WAREA_AUXILIAR WAREA_AUXILIAR { get; set; } = new PF0641B_WAREA_AUXILIAR();
        public class PF0641B_WAREA_AUXILIAR : VarBasis
        {
            /*"    05  WSTATUS                       PIC X(002)  VALUE '00'.*/
            public StringBasis WSTATUS { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"00");
            /*"    05  W-FIM-CBO                     PIC X(003)  VALUE SPACES.*/
            public StringBasis W_FIM_CBO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"    05  W-FIM-FONTES                  PIC X(003)  VALUE SPACES.*/
            public StringBasis W_FIM_FONTES { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"    05  W-FIM-MOVTO-MR                PIC X(003)  VALUE SPACES.*/
            public StringBasis W_FIM_MOVTO_MR { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"    05  W-FIM-CURSOR-EMAIL            PIC X(003)  VALUE SPACES.*/
            public StringBasis W_FIM_CURSOR_EMAIL { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"    05  W-FIM-CURSOR-ENDERECO         PIC X(003)  VALUE SPACES.*/
            public StringBasis W_FIM_CURSOR_ENDERECO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"    05  W-LIDO-MOVTO-SIGAT            PIC 9(008)  VALUE ZEROS.*/
            public IntBasis W_LIDO_MOVTO_SIGAT { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05  W-DESP-MOVTO-SIGAT            PIC 9(008)  VALUE ZEROS.*/
            public IntBasis W_DESP_MOVTO_SIGAT { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05  W-AC-CONTROLE                 PIC 9(008)  VALUE ZEROS.*/
            public IntBasis W_AC_CONTROLE { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05  W-EXISTE-PROPOSTA             PIC X(003)  VALUE 'NAO'.*/
            public StringBasis W_EXISTE_PROPOSTA { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
            /*"    05  W-EXISTE-SICOB                PIC X(003)  VALUE 'NAO'.*/
            public StringBasis W_EXISTE_SICOB { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
            /*"    05  W-EXISTE-TP-2                 PIC X(003)  VALUE SPACES.*/
            public StringBasis W_EXISTE_TP_2 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"    05  W-EXISTE-TP-6                 PIC X(003)  VALUE SPACES.*/
            public StringBasis W_EXISTE_TP_6 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"    05  W-EXISTE-TP-C                 PIC X(003)  VALUE SPACES.*/
            public StringBasis W_EXISTE_TP_C { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"    05  W-INDEX                       PIC  9(01)  VALUE ZERO.*/
            public IntBasis W_INDEX { get; set; } = new IntBasis(new PIC("9", "1", "9(01)"));
            /*"    05  W-IND-BENEF                   PIC  9(04)  VALUE ZEROS.*/
            public IntBasis W_IND_BENEF { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
            /*"    05  W-IND-BENEF-N                 PIC  9(04)  VALUE ZEROS.*/
            public IntBasis W_IND_BENEF_N { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
            /*"    05  W-IND-INFO-N                  PIC  9(02)  VALUE ZEROS.*/
            public IntBasis W_IND_INFO_N { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
            /*"    05  W-IND-SICAQ                   PIC  9(03)  VALUE ZEROS.*/
            public IntBasis W_IND_SICAQ { get; set; } = new IntBasis(new PIC("9", "3", "9(03)"));
            /*"    05  W-IND-SICAQ-N                 PIC  9(03)  VALUE ZEROS.*/
            public IntBasis W_IND_SICAQ_N { get; set; } = new IntBasis(new PIC("9", "3", "9(03)"));
            /*"    05  W-IND-DIVERSOS                PIC  9(03)  VALUE ZEROS.*/
            public IntBasis W_IND_DIVERSOS { get; set; } = new IntBasis(new PIC("9", "3", "9(03)"));
            /*"    05  W-IND-DIVERSOS-N              PIC  9(03)  VALUE ZEROS.*/
            public IntBasis W_IND_DIVERSOS_N { get; set; } = new IntBasis(new PIC("9", "3", "9(03)"));
            /*"    05  W-IND-ENDER                   PIC  9(03)  VALUE ZEROS.*/
            public IntBasis W_IND_ENDER { get; set; } = new IntBasis(new PIC("9", "3", "9(03)"));
            /*"    05  W-IND-ENDER1                  PIC  9(03)  VALUE ZEROS.*/
            public IntBasis W_IND_ENDER1 { get; set; } = new IntBasis(new PIC("9", "3", "9(03)"));
            /*"    05  W-IND-ENDER-A                 PIC  9(03)  VALUE ZEROS.*/
            public IntBasis W_IND_ENDER_A { get; set; } = new IntBasis(new PIC("9", "3", "9(03)"));
            /*"    05  W-IND-ENDER-N                 PIC  9(03)  VALUE ZEROS.*/
            public IntBasis W_IND_ENDER_N { get; set; } = new IntBasis(new PIC("9", "3", "9(03)"));
            /*"    05  W-CONTROLE-TP-0               PIC  9(01)  VALUE ZEROS.*/
            public IntBasis W_CONTROLE_TP_0 { get; set; } = new IntBasis(new PIC("9", "1", "9(01)"));
            /*"    05  W-QTD-MOV-MR-0                PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_MOV_MR_0 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-MOV-MR-1                PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_MOV_MR_1 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-MOV-MR-2                PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_MOV_MR_2 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-MOV-MR-3                PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_MOV_MR_3 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-MOV-MR-4                PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_MOV_MR_4 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-MOV-MR-5                PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_MOV_MR_5 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-MOV-MR-6                PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_MOV_MR_6 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-MOV-MR-7                PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_MOV_MR_7 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-MOV-MR-8                PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_MOV_MR_8 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-MOV-MR-9                PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_MOV_MR_9 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-MOV-MR-A                PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_MOV_MR_A { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-MOV-MR-B                PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_MOV_MR_B { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-MOV-MR-C                PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_MOV_MR_C { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-MOV-MR-D                PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_MOV_MR_D { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-MOV-MR-E                PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_MOV_MR_E { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-MOV-MR-F                PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_MOV_MR_F { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-MOV-MR-G                PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_MOV_MR_G { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-MOV-MR-H                PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_MOV_MR_H { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-MOV-MR-I                PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_MOV_MR_I { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-MOV-MR-J                PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_MOV_MR_J { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-MOV-CEF-0               PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_MOV_CEF_0 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-MOV-CEF-1               PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_MOV_CEF_1 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-MOV-CEF-2               PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_MOV_CEF_2 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-MOV-CEF-3               PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_MOV_CEF_3 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-MOV-CEF-4               PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_MOV_CEF_4 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-MOV-CEF-5               PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_MOV_CEF_5 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-MOV-CEF-6               PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_MOV_CEF_6 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-MOV-CEF-7               PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_MOV_CEF_7 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-MOV-CEF-8               PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_MOV_CEF_8 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-MOV-CEF-9               PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_MOV_CEF_9 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-MOV-CEF-A               PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_MOV_CEF_A { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-MOV-CEF-B               PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_MOV_CEF_B { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-MOV-CEF-C               PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_MOV_CEF_C { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-MOV-CEF-D               PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_MOV_CEF_D { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-MOV-CEF-E               PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_MOV_CEF_E { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-MOV-CEF-F               PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_MOV_CEF_F { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-MOV-CEF-G               PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_MOV_CEF_G { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-MOV-CEF-H               PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_MOV_CEF_H { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-MOV-CEF-I               PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_MOV_CEF_I { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-MOV-CEF-J               PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_MOV_CEF_J { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LH-TIPO-2               PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LH_TIPO_2 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LH-TIPO-3               PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LH_TIPO_3 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-SEQ-FONE                    PIC 9(004)  VALUE ZEROS.*/
            public IntBasis W_SEQ_FONE { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"    05  W-SEQ-EMAIL                   PIC 9(004)  VALUE ZEROS.*/
            public IntBasis W_SEQ_EMAIL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"    05  W-COD-PESSOA                  PIC 9(009)  VALUE ZEROS.*/
            public IntBasis W_COD_PESSOA { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    05  W-ACHOU-SICOB                 PIC X(003)  VALUE 'NAO'.*/
            public StringBasis W_ACHOU_SICOB { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
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
            /*"    05  W-NSL-SASSE                   PIC 9(006).*/
            public IntBasis W_NSL_SASSE { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"    05  W-NSAS-MR                 PIC 9(006).*/
            public IntBasis W_NSAS_MR { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"    05  W-NSAS-PRP-CEF                PIC 9(006).*/
            public IntBasis W_NSAS_PRP_CEF { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"    05  W-SIGLA-ARQUIVO               PIC X(008)  VALUE SPACES.*/
            public StringBasis W_SIGLA_ARQUIVO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
            /*"    05  FILLER REDEFINES W-SIGLA-ARQUIVO.*/
            private _REDEF_PF0641B_FILLER_3 _filler_3 { get; set; }
            public _REDEF_PF0641B_FILLER_3 FILLER_3
            {
                get { _filler_3 = new _REDEF_PF0641B_FILLER_3(); _.Move(W_SIGLA_ARQUIVO, _filler_3); VarBasis.RedefinePassValue(W_SIGLA_ARQUIVO, _filler_3, W_SIGLA_ARQUIVO); _filler_3.ValueChanged += () => { _.Move(_filler_3, W_SIGLA_ARQUIVO); }; return _filler_3; }
                set { VarBasis.RedefinePassValue(value, _filler_3, W_SIGLA_ARQUIVO); }
            }  //Redefines
            public class _REDEF_PF0641B_FILLER_3 : VarBasis
            {
                /*"        07  W-IDE-SIGLA               PIC X(004).*/
                public StringBasis W_IDE_SIGLA { get; set; } = new StringBasis(new PIC("X", "4", "X(004)."), @"");
                /*"        07  W-IDE-FILIAL              PIC 9(004).*/
                public IntBasis W_IDE_FILIAL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05  W-NR-SICOB                    PIC 9(015).*/

                public _REDEF_PF0641B_FILLER_3()
                {
                    W_IDE_SIGLA.ValueChanged += OnValueChanged;
                    W_IDE_FILIAL.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis W_NR_SICOB { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
            /*"    05  FILLER REDEFINES W-NR-SICOB.*/
            private _REDEF_PF0641B_FILLER_4 _filler_4 { get; set; }
            public _REDEF_PF0641B_FILLER_4 FILLER_4
            {
                get { _filler_4 = new _REDEF_PF0641B_FILLER_4(); _.Move(W_NR_SICOB, _filler_4); VarBasis.RedefinePassValue(W_NR_SICOB, _filler_4, W_NR_SICOB); _filler_4.ValueChanged += () => { _.Move(_filler_4, W_NR_SICOB); }; return _filler_4; }
                set { VarBasis.RedefinePassValue(value, _filler_4, W_NR_SICOB); }
            }  //Redefines
            public class _REDEF_PF0641B_FILLER_4 : VarBasis
            {
                /*"        07  W-NR-PROD-SICOB           PIC 9(003).*/
                public IntBasis W_NR_PROD_SICOB { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"        07  W-NR-NSAC-SICOB           PIC 9(006).*/
                public IntBasis W_NR_NSAC_SICOB { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"        07  W-NR-NSL-SICOB            PIC 9(006).*/
                public IntBasis W_NR_NSL_SICOB { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"    05  W-NUMR-TITULO               PIC  9(013)   VALUE ZEROS.*/

                public _REDEF_PF0641B_FILLER_4()
                {
                    W_NR_PROD_SICOB.ValueChanged += OnValueChanged;
                    W_NR_NSAC_SICOB.ValueChanged += OnValueChanged;
                    W_NR_NSL_SICOB.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis W_NUMR_TITULO { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
            /*"    05  FILLER                      REDEFINES    W-NUMR-TITULO.*/
            private _REDEF_PF0641B_FILLER_5 _filler_5 { get; set; }
            public _REDEF_PF0641B_FILLER_5 FILLER_5
            {
                get { _filler_5 = new _REDEF_PF0641B_FILLER_5(); _.Move(W_NUMR_TITULO, _filler_5); VarBasis.RedefinePassValue(W_NUMR_TITULO, _filler_5, W_NUMR_TITULO); _filler_5.ValueChanged += () => { _.Move(_filler_5, W_NUMR_TITULO); }; return _filler_5; }
                set { VarBasis.RedefinePassValue(value, _filler_5, W_NUMR_TITULO); }
            }  //Redefines
            public class _REDEF_PF0641B_FILLER_5 : VarBasis
            {
                /*"      10    WTITL-ZEROS             PIC  9(002).*/
                public IntBasis WTITL_ZEROS { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10    WTITL-SEQUENCIA         PIC  9(010).*/
                public IntBasis WTITL_SEQUENCIA { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
                /*"      10    WTITL-DIGITO            PIC  9(001).*/
                public IntBasis WTITL_DIGITO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    05  WS-PROPOSTA              PIC  9(014)   VALUE ZEROS.*/

                public _REDEF_PF0641B_FILLER_5()
                {
                    WTITL_ZEROS.ValueChanged += OnValueChanged;
                    WTITL_SEQUENCIA.ValueChanged += OnValueChanged;
                    WTITL_DIGITO.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WS_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "14", "9(014)"));
            /*"    05  FILLER                      REDEFINES  WS-PROPOSTA.*/
            private _REDEF_PF0641B_FILLER_6 _filler_6 { get; set; }
            public _REDEF_PF0641B_FILLER_6 FILLER_6
            {
                get { _filler_6 = new _REDEF_PF0641B_FILLER_6(); _.Move(WS_PROPOSTA, _filler_6); VarBasis.RedefinePassValue(WS_PROPOSTA, _filler_6, WS_PROPOSTA); _filler_6.ValueChanged += () => { _.Move(_filler_6, WS_PROPOSTA); }; return _filler_6; }
                set { VarBasis.RedefinePassValue(value, _filler_6, WS_PROPOSTA); }
            }  //Redefines
            public class _REDEF_PF0641B_FILLER_6 : VarBasis
            {
                /*"      10    WNUM-PROP-13            PIC  9(013).*/
                public IntBasis WNUM_PROP_13 { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
                /*"      10    WDIG-PROP               PIC  9.*/
                public IntBasis WDIG_PROP { get; set; } = new IntBasis(new PIC("9", "1", "9."));
                /*"    05       W-TAB-BENEFICIARIOS.*/

                public _REDEF_PF0641B_FILLER_6()
                {
                    WNUM_PROP_13.ValueChanged += OnValueChanged;
                    WDIG_PROP.ValueChanged += OnValueChanged;
                }

            }
            public PF0641B_W_TAB_BENEFICIARIOS W_TAB_BENEFICIARIOS { get; set; } = new PF0641B_W_TAB_BENEFICIARIOS();
            public class PF0641B_W_TAB_BENEFICIARIOS : VarBasis
            {
                /*"       10    W-TAB-BENEF-REG   OCCURS 500 TIMES INDEXED BY I01.*/
                public ListBasis<PF0641B_W_TAB_BENEF_REG> W_TAB_BENEF_REG { get; set; } = new ListBasis<PF0641B_W_TAB_BENEF_REG>(500);
                public class PF0641B_W_TAB_BENEF_REG : VarBasis
                {
                    /*"          15 W-TB-REG-BENEFI   PIC  X(300).*/
                    public StringBasis W_TB_REG_BENEFI { get; set; } = new StringBasis(new PIC("X", "300", "X(300)."), @"");
                    /*"    05       W-TAB-INFORMACOES.*/
                }
            }
            public PF0641B_W_TAB_INFORMACOES W_TAB_INFORMACOES { get; set; } = new PF0641B_W_TAB_INFORMACOES();
            public class PF0641B_W_TAB_INFORMACOES : VarBasis
            {
                /*"       10    W-TAB-INFO-REG   OCCURS 500 TIMES INDEXED BY I02.*/
                public ListBasis<PF0641B_W_TAB_INFO_REG> W_TAB_INFO_REG { get; set; } = new ListBasis<PF0641B_W_TAB_INFO_REG>(500);
                public class PF0641B_W_TAB_INFO_REG : VarBasis
                {
                    /*"          15 W-TB-REG-INFORMACOES PIC  X(300).*/
                    public StringBasis W_TB_REG_INFORMACOES { get; set; } = new StringBasis(new PIC("X", "300", "X(300)."), @"");
                    /*"    05       W-TAB-DIVERSOS.*/
                }
            }
            public PF0641B_W_TAB_DIVERSOS W_TAB_DIVERSOS { get; set; } = new PF0641B_W_TAB_DIVERSOS();
            public class PF0641B_W_TAB_DIVERSOS : VarBasis
            {
                /*"       10    W-TAB-DIV-REG   OCCURS 300 TIMES INDEXED BY I03.*/
                public ListBasis<PF0641B_W_TAB_DIV_REG> W_TAB_DIV_REG { get; set; } = new ListBasis<PF0641B_W_TAB_DIV_REG>(300);
                public class PF0641B_W_TAB_DIV_REG : VarBasis
                {
                    /*"         15  W-TB-REG-DIVERSOS        PIC  X(300).*/
                    public StringBasis W_TB_REG_DIVERSOS { get; set; } = new StringBasis(new PIC("X", "300", "X(300)."), @"");
                    /*"    05       W-TB-ENDERECOS-N.*/
                }
            }
            public PF0641B_W_TB_ENDERECOS_N W_TB_ENDERECOS_N { get; set; } = new PF0641B_W_TB_ENDERECOS_N();
            public class PF0641B_W_TB_ENDERECOS_N : VarBasis
            {
                /*"       10    W-TAB-END-REG-N   OCCURS 100 TIMES INDEXED BY I04.*/
                public ListBasis<PF0641B_W_TAB_END_REG_N> W_TAB_END_REG_N { get; set; } = new ListBasis<PF0641B_W_TAB_END_REG_N>(100);
                public class PF0641B_W_TAB_END_REG_N : VarBasis
                {
                    /*"          15 W-TB-REG-ENDERECOS-N     PIC  X(300).*/
                    public StringBasis W_TB_REG_ENDERECOS_N { get; set; } = new StringBasis(new PIC("X", "300", "X(300)."), @"");
                    /*"    05      W-TB-ENDERECOS-A.*/
                }
            }
            public PF0641B_W_TB_ENDERECOS_A W_TB_ENDERECOS_A { get; set; } = new PF0641B_W_TB_ENDERECOS_A();
            public class PF0641B_W_TB_ENDERECOS_A : VarBasis
            {
                /*"      07    W-TAB-END-REG-A OCCURS 1800 TIMES INDEXED BY I05.*/
                public ListBasis<PF0641B_W_TAB_END_REG_A> W_TAB_END_REG_A { get; set; } = new ListBasis<PF0641B_W_TAB_END_REG_A>(1800);
                public class PF0641B_W_TAB_END_REG_A : VarBasis
                {
                    /*"        10  W-TB-REG-ENDERECOS-A.*/
                    public PF0641B_W_TB_REG_ENDERECOS_A W_TB_REG_ENDERECOS_A { get; set; } = new PF0641B_W_TB_REG_ENDERECOS_A();
                    public class PF0641B_W_TB_REG_ENDERECOS_A : VarBasis
                    {
                        /*"          15 COD-PESSOA             PIC S9(9) USAGE COMP.*/
                        public IntBasis COD_PESSOA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
                        /*"          15 OCORR-ENDERECO         PIC S9(4) USAGE COMP.*/
                        public IntBasis OCORR_ENDERECO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
                        /*"          15 ENDERECO               PIC X(40).*/
                        public StringBasis ENDERECO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
                        /*"          15 TIPO-ENDER             PIC S9(4) USAGE COMP.*/
                        public IntBasis TIPO_ENDER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
                        /*"          15 COMPL-ENDER            PIC X(15).*/
                        public StringBasis COMPL_ENDER { get; set; } = new StringBasis(new PIC("X", "15", "X(15)."), @"");
                        /*"          15 BAIRRO                 PIC X(20).*/
                        public StringBasis BAIRRO { get; set; } = new StringBasis(new PIC("X", "20", "X(20)."), @"");
                        /*"          15 CEP                    PIC S9(9) USAGE COMP.*/
                        public IntBasis CEP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
                        /*"          15 CIDADE                 PIC X(20).*/
                        public StringBasis CIDADE { get; set; } = new StringBasis(new PIC("X", "20", "X(20)."), @"");
                        /*"          15 SIGLA-UF               PIC X(2).*/
                        public StringBasis SIGLA_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(2)."), @"");
                        /*"          15 SITUACAO-ENDERECO      PIC X(1).*/
                        public StringBasis SITUACAO_ENDERECO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
                        /*"          15 COD-USUARIO            PIC X(8).*/
                        public StringBasis COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
                        /*"          15 TIMESTAMP              PIC X(26).*/
                        public StringBasis TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
                        /*"    05      W-TAB-CORRESP-CAIXA.*/
                    }
                }
            }
            public PF0641B_W_TAB_CORRESP_CAIXA W_TAB_CORRESP_CAIXA { get; set; } = new PF0641B_W_TAB_CORRESP_CAIXA();
            public class PF0641B_W_TAB_CORRESP_CAIXA : VarBasis
            {
                /*"      10    W-TAB-SCQ-REG   OCCURS 300 TIMES INDEXED BY I06.*/
                public ListBasis<PF0641B_W_TAB_SCQ_REG> W_TAB_SCQ_REG { get; set; } = new ListBasis<PF0641B_W_TAB_SCQ_REG>(300);
                public class PF0641B_W_TAB_SCQ_REG : VarBasis
                {
                    /*"        15  W-TB-REG-SICAQ          PIC X(300).*/
                    public StringBasis W_TB_REG_SICAQ { get; set; } = new StringBasis(new PIC("X", "300", "X(300)."), @"");
                    /*"    05      TAB-CBO.*/
                }
            }
            public PF0641B_TAB_CBO TAB_CBO { get; set; } = new PF0641B_TAB_CBO();
            public class PF0641B_TAB_CBO : VarBasis
            {
                /*"      10    FILLER   OCCURS 999 TIMES.*/
                public ListBasis<PF0641B_FILLER_7> FILLER_7 { get; set; } = new ListBasis<PF0641B_FILLER_7>(999);
                public class PF0641B_FILLER_7 : VarBasis
                {
                    /*"        15  TAB-COD-CBO              PIC  9(4).*/
                    public IntBasis TAB_COD_CBO { get; set; } = new IntBasis(new PIC("9", "4", "9(4)."));
                    /*"        15  TAB-DESCR-CBO            PIC  X(5).*/
                    public StringBasis TAB_DESCR_CBO { get; set; } = new StringBasis(new PIC("X", "5", "X(5)."), @"");
                    /*"        15  TAB-DESCR-CBO-C          PIC  X(20).*/
                    public StringBasis TAB_DESCR_CBO_C { get; set; } = new StringBasis(new PIC("X", "20", "X(20)."), @"");
                    /*"    05      W-DATA-TRABALHO               PIC 9(008)  VALUE ZEROS    05      W-DATA-TRABALHO-A  REDEFINES W-DATA-TRABALHO.*/
                }
            }
            private _REDEF_IntBasis _w_data_trabalho { get; set; }
            public _REDEF_IntBasis W_DATA_TRABALHO
            {
                get { _w_data_trabalho = new _REDEF_IntBasis(new PIC("9", "008", "9(008)")); ; _.Move(W_DATA_TRABALHO, _w_data_trabalho); VarBasis.RedefinePassValue(W_DATA_TRABALHO, _w_data_trabalho, W_DATA_TRABALHO); _w_data_trabalho.ValueChanged += () => { _.Move(_w_data_trabalho, W_DATA_TRABALHO); }; return _w_data_trabalho; }
                set { VarBasis.RedefinePassValue(value, _w_data_trabalho, W_DATA_TRABALHO); }
            }  //Redefines
            /*"      07    W-DIA-TRABALHO            PIC 9(002).*/
            public IntBasis W_DIA_TRABALHO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"      07    W-MES-TRABALHO            PIC 9(002).*/
            public IntBasis W_MES_TRABALHO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"      07    W-ANO-TRABALHO            PIC 9(004).*/
            public IntBasis W_ANO_TRABALHO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    05      W-DATA-NASCIMENTO             PIC 9(008)  VALUE ZEROS    05      FILLER REDEFINES W-DATA-NASCIMENTO.*/
        }
        private _REDEF_IntBasis _w_data_nascimento { get; set; }
        public _REDEF_IntBasis W_DATA_NASCIMENTO
        {
            get { _w_data_nascimento = new _REDEF_IntBasis(new PIC("9", "008", "9(008)")); ; _.Move(W_DATA_NASCIMENTO, _w_data_nascimento); VarBasis.RedefinePassValue(W_DATA_NASCIMENTO, _w_data_nascimento, W_DATA_NASCIMENTO); _w_data_nascimento.ValueChanged += () => { _.Move(_w_data_nascimento, W_DATA_NASCIMENTO); }; return _w_data_nascimento; }
            set { VarBasis.RedefinePassValue(value, _w_data_nascimento, W_DATA_NASCIMENTO); }
        }  //Redefines
        /*"      07    W-DIA-NASCIMENTO          PIC 9(002).*/
        public IntBasis W_DIA_NASCIMENTO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
        /*"      07    W-MES-NASCIMENTO          PIC 9(002).*/
        public IntBasis W_MES_NASCIMENTO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
        /*"      07    W-ANO-NASCIMENTO          PIC 9(004).*/
        public IntBasis W_ANO_NASCIMENTO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
        /*"    05      W-DTMOVABE                    PIC X(010).*/
        public StringBasis W_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"    05      W-DTMOVABE1 REDEFINES W-DTMOVABE.*/
        private _REDEF_PF0641B_W_DTMOVABE1 _w_dtmovabe1 { get; set; }
        public _REDEF_PF0641B_W_DTMOVABE1 W_DTMOVABE1
        {
            get { _w_dtmovabe1 = new _REDEF_PF0641B_W_DTMOVABE1(); _.Move(W_DTMOVABE, _w_dtmovabe1); VarBasis.RedefinePassValue(W_DTMOVABE, _w_dtmovabe1, W_DTMOVABE); _w_dtmovabe1.ValueChanged += () => { _.Move(_w_dtmovabe1, W_DTMOVABE); }; return _w_dtmovabe1; }
            set { VarBasis.RedefinePassValue(value, _w_dtmovabe1, W_DTMOVABE); }
        }  //Redefines
        public class _REDEF_PF0641B_W_DTMOVABE1 : VarBasis
        {
            /*"      07    W-ANO-MOVABE              PIC 9(004).*/
            public IntBasis W_ANO_MOVABE { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"      07    W-BARRA1                  PIC X(001).*/
            public StringBasis W_BARRA1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"      07    W-MES-MOVABE              PIC 9(002).*/
            public IntBasis W_MES_MOVABE { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"      07    W-BARRA2                  PIC X(001).*/
            public StringBasis W_BARRA2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"      07    W-DIA-MOVABE              PIC 9(002).*/
            public IntBasis W_DIA_MOVABE { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"    05      W-DTMOVABE-I                  PIC X(010).*/

            public _REDEF_PF0641B_W_DTMOVABE1()
            {
                W_ANO_MOVABE.ValueChanged += OnValueChanged;
                W_BARRA1.ValueChanged += OnValueChanged;
                W_MES_MOVABE.ValueChanged += OnValueChanged;
                W_BARRA2.ValueChanged += OnValueChanged;
                W_DIA_MOVABE.ValueChanged += OnValueChanged;
            }

        }
        public StringBasis W_DTMOVABE_I { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"    05      W-DTMOVABE-I1 REDEFINES W-DTMOVABE-I.*/
        private _REDEF_PF0641B_W_DTMOVABE_I1 _w_dtmovabe_i1 { get; set; }
        public _REDEF_PF0641B_W_DTMOVABE_I1 W_DTMOVABE_I1
        {
            get { _w_dtmovabe_i1 = new _REDEF_PF0641B_W_DTMOVABE_I1(); _.Move(W_DTMOVABE_I, _w_dtmovabe_i1); VarBasis.RedefinePassValue(W_DTMOVABE_I, _w_dtmovabe_i1, W_DTMOVABE_I); _w_dtmovabe_i1.ValueChanged += () => { _.Move(_w_dtmovabe_i1, W_DTMOVABE_I); }; return _w_dtmovabe_i1; }
            set { VarBasis.RedefinePassValue(value, _w_dtmovabe_i1, W_DTMOVABE_I); }
        }  //Redefines
        public class _REDEF_PF0641B_W_DTMOVABE_I1 : VarBasis
        {
            /*"      07    W-DIA-MOVABE              PIC 9(002).*/
            public IntBasis W_DIA_MOVABE_0 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"      07    W-BARRA1                  PIC X(001).*/
            public StringBasis W_BARRA1_0 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"      07    W-MES-MOVABE              PIC 9(002).*/
            public IntBasis W_MES_MOVABE_0 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"      07    W-BARRA2                  PIC X(001).*/
            public StringBasis W_BARRA2_0 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"      07    W-ANO-MOVABE              PIC 9(004).*/
            public IntBasis W_ANO_MOVABE_0 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    05      W-DATA-SQL                    PIC X(010).*/

            public _REDEF_PF0641B_W_DTMOVABE_I1()
            {
                W_DIA_MOVABE_0.ValueChanged += OnValueChanged;
                W_BARRA1_0.ValueChanged += OnValueChanged;
                W_MES_MOVABE_0.ValueChanged += OnValueChanged;
                W_BARRA2_0.ValueChanged += OnValueChanged;
                W_ANO_MOVABE_0.ValueChanged += OnValueChanged;
            }

        }
        public StringBasis W_DATA_SQL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"    05      W-DATA-SQL1 REDEFINES W-DATA-SQL.*/
        private _REDEF_PF0641B_W_DATA_SQL1 _w_data_sql1 { get; set; }
        public _REDEF_PF0641B_W_DATA_SQL1 W_DATA_SQL1
        {
            get { _w_data_sql1 = new _REDEF_PF0641B_W_DATA_SQL1(); _.Move(W_DATA_SQL, _w_data_sql1); VarBasis.RedefinePassValue(W_DATA_SQL, _w_data_sql1, W_DATA_SQL); _w_data_sql1.ValueChanged += () => { _.Move(_w_data_sql1, W_DATA_SQL); }; return _w_data_sql1; }
            set { VarBasis.RedefinePassValue(value, _w_data_sql1, W_DATA_SQL); }
        }  //Redefines
        public class _REDEF_PF0641B_W_DATA_SQL1 : VarBasis
        {
            /*"      07    W-ANO-SQL                 PIC 9(004).*/
            public IntBasis W_ANO_SQL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"      07    W-BARRA1                  PIC X(001).*/
            public StringBasis W_BARRA1_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"      07    W-MES-SQL                 PIC 9(002).*/
            public IntBasis W_MES_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"      07    W-BARRA2                  PIC X(001).*/
            public StringBasis W_BARRA2_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"      07    W-DIA-SQL                 PIC 9(002).*/
            public IntBasis W_DIA_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"    05              DPARM01X.*/

            public _REDEF_PF0641B_W_DATA_SQL1()
            {
                W_ANO_SQL.ValueChanged += OnValueChanged;
                W_BARRA1_1.ValueChanged += OnValueChanged;
                W_MES_SQL.ValueChanged += OnValueChanged;
                W_BARRA2_1.ValueChanged += OnValueChanged;
                W_DIA_SQL.ValueChanged += OnValueChanged;
            }

        }
        public PF0641B_DPARM01X DPARM01X { get; set; } = new PF0641B_DPARM01X();
        public class PF0641B_DPARM01X : VarBasis
        {
            /*"      07            DPARM01           PIC  9(010).*/
            public IntBasis DPARM01 { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
            /*"      07            DPARM01-R         REDEFINES   DPARM01.*/
            private _REDEF_PF0641B_DPARM01_R _dparm01_r { get; set; }
            public _REDEF_PF0641B_DPARM01_R DPARM01_R
            {
                get { _dparm01_r = new _REDEF_PF0641B_DPARM01_R(); _.Move(DPARM01, _dparm01_r); VarBasis.RedefinePassValue(DPARM01, _dparm01_r, DPARM01); _dparm01_r.ValueChanged += () => { _.Move(_dparm01_r, DPARM01); }; return _dparm01_r; }
                set { VarBasis.RedefinePassValue(value, _dparm01_r, DPARM01); }
            }  //Redefines
            public class _REDEF_PF0641B_DPARM01_R : VarBasis
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

                public _REDEF_PF0641B_DPARM01_R()
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
            /*"01  WS-REGISTRO-LIDO.*/
        }
        public PF0641B_WS_REGISTRO_LIDO WS_REGISTRO_LIDO { get; set; } = new PF0641B_WS_REGISTRO_LIDO();
        public class PF0641B_WS_REGISTRO_LIDO : VarBasis
        {
            /*"    05 WS-REGISTRO-TP-1              PIC 9(001)  VALUE ZERO.*/
            public IntBasis WS_REGISTRO_TP_1 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*"    05 WS-REGISTRO-TP-2              PIC 9(001)  VALUE ZERO.*/
            public IntBasis WS_REGISTRO_TP_2 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*"    05 WS-REGISTRO-TP-3              PIC 9(001)  VALUE ZERO.*/
            public IntBasis WS_REGISTRO_TP_3 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*"    05 WS-REGISTRO-TP-4              PIC 9(001)  VALUE ZERO.*/
            public IntBasis WS_REGISTRO_TP_4 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*"    05 WS-REGISTRO-TP-5              PIC 9(001)  VALUE ZERO.*/
            public IntBasis WS_REGISTRO_TP_5 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*"    05 WS-REGISTRO-TP-6              PIC 9(001)  VALUE ZERO.*/
            public IntBasis WS_REGISTRO_TP_6 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*"    05 WS-REGISTRO-TP-C              PIC X(001)  VALUE SPACES.*/
            public StringBasis WS_REGISTRO_TP_C { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"01  FILLER REDEFINES WS-REGISTRO-LIDO.*/
        }
        private _REDEF_PF0641B_FILLER_8 _filler_8 { get; set; }
        public _REDEF_PF0641B_FILLER_8 FILLER_8
        {
            get { _filler_8 = new _REDEF_PF0641B_FILLER_8(); _.Move(WS_REGISTRO_LIDO, _filler_8); VarBasis.RedefinePassValue(WS_REGISTRO_LIDO, _filler_8, WS_REGISTRO_LIDO); _filler_8.ValueChanged += () => { _.Move(_filler_8, WS_REGISTRO_LIDO); }; return _filler_8; }
            set { VarBasis.RedefinePassValue(value, _filler_8, WS_REGISTRO_LIDO); }
        }  //Redefines
        public class _REDEF_PF0641B_FILLER_8 : VarBasis
        {
            /*"    05 WS-REGISTRO-VALIDO            PIC 9(003).*/
            public IntBasis WS_REGISTRO_VALIDO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
            /*"01  WS-TIME.*/

            public _REDEF_PF0641B_FILLER_8()
            {
                WS_REGISTRO_VALIDO.ValueChanged += OnValueChanged;
            }

        }
        public PF0641B_WS_TIME WS_TIME { get; set; } = new PF0641B_WS_TIME();
        public class PF0641B_WS_TIME : VarBasis
        {
            /*"    05 WS-TIME-N                     PIC 9(06).*/
            public IntBasis WS_TIME_N { get; set; } = new IntBasis(new PIC("9", "6", "9(06)."));
            /*"    05 FILLER                        PIC X(02).*/
            public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "2", "X(02)."), @"");
            /*"01  WS-TIME-EDIT                     PIC 99.99.99.*/
        }
        public IntBasis WS_TIME_EDIT { get; set; } = new IntBasis(new PIC("9", "6", "99.99.99."));
        /*"01  WABEND*/
        public PF0641B_WABEND WABEND { get; set; } = new PF0641B_WABEND();
        public class PF0641B_WABEND : VarBasis
        {
            /*"    05 FILLER.*/
            public PF0641B_FILLER_10 FILLER_10 { get; set; } = new PF0641B_FILLER_10();
            public class PF0641B_FILLER_10 : VarBasis
            {
                /*"      10    FILLER                   PIC  X(010) VALUE            'PF0641B  '.*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"PF0641B  ");
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
                /*"      05    LOCALIZA-ABEND-1.*/
                public PF0641B_LOCALIZA_ABEND_1 LOCALIZA_ABEND_1 { get; set; } = new PF0641B_LOCALIZA_ABEND_1();
                public class PF0641B_LOCALIZA_ABEND_1 : VarBasis
                {
                    /*"         10    FILLER                PIC  X(012)   VALUE               'PARAGRAFO = '.*/
                    public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"PARAGRAFO = ");
                    /*"         10    PARAGRAFO             PIC  X(040)   VALUE SPACES.*/
                    public StringBasis PARAGRAFO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                    /*"      05    LOCALIZA-ABEND-2.*/
                }
                public PF0641B_LOCALIZA_ABEND_2 LOCALIZA_ABEND_2 { get; set; } = new PF0641B_LOCALIZA_ABEND_2();
                public class PF0641B_LOCALIZA_ABEND_2 : VarBasis
                {
                    /*"         10    FILLER                PIC  X(012)   VALUE               'COMANDO   = '.*/
                    public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"COMANDO   = ");
                    /*"         10    COMANDO               PIC  X(060)   VALUE SPACES.*/
                    public StringBasis COMANDO { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"");
                    /*"01  WREA88.*/
                }
            }
        }
        public PF0641B_WREA88 WREA88 { get; set; } = new PF0641B_WREA88();
        public class PF0641B_WREA88 : VarBasis
        {
            /*"    05      W-NUM-PROPOSTA                     PIC 9(014).*/
            public IntBasis W_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
            /*"    05      FILLER REDEFINES W-NUM-PROPOSTA.*/
            private _REDEF_PF0641B_FILLER_19 _filler_19 { get; set; }
            public _REDEF_PF0641B_FILLER_19 FILLER_19
            {
                get { _filler_19 = new _REDEF_PF0641B_FILLER_19(); _.Move(W_NUM_PROPOSTA, _filler_19); VarBasis.RedefinePassValue(W_NUM_PROPOSTA, _filler_19, W_NUM_PROPOSTA); _filler_19.ValueChanged += () => { _.Move(_filler_19, W_NUM_PROPOSTA); }; return _filler_19; }
                set { VarBasis.RedefinePassValue(value, _filler_19, W_NUM_PROPOSTA); }
            }  //Redefines
            public class _REDEF_PF0641B_FILLER_19 : VarBasis
            {
                /*"        07  W-CANAL-PROPOSTA                   PIC 9(001).*/

                public SelectorBasis W_CANAL_PROPOSTA { get; set; } = new SelectorBasis("001")
                {
                    Items = new List<SelectorItemBasis> {
                            /*" 88 CANAL-VENDA-PAPEL                       VALUE 0, 6 */
							new SelectorItemBasis("CANAL_VENDA_PAPEL", "0,6")
                }
                };

                /*"        07  W-FILLER                           PIC 9(013).*/
                public IntBasis W_FILLER { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
                /*"    05 W-GEROU-MOVTO-CEF              PIC  9(001) VALUE ZERO.*/

                public _REDEF_PF0641B_FILLER_19()
                {
                    W_CANAL_PROPOSTA.ValueChanged += OnValueChanged;
                    W_FILLER.ValueChanged += OnValueChanged;
                }

            }

            public SelectorBasis W_GEROU_MOVTO_CEF { get; set; } = new SelectorBasis("001", "ZERO")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 GEROU-MOVTO-CEF                         VALUE 1. */
							new SelectorItemBasis("GEROU_MOVTO_CEF", "1")
                }
            };

            /*"    05 W-LEITURA-RCAP                 PIC  9(001) VALUE ZERO.*/

            public SelectorBasis W_LEITURA_RCAP { get; set; } = new SelectorBasis("001", "ZERO")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 ENCONTROU-RCAP                          VALUE 1. */
							new SelectorItemBasis("ENCONTROU_RCAP", "1"),
							/*" 88 NAO-ENCONTROU-RCAP                      VALUE 2. */
							new SelectorItemBasis("NAO_ENCONTROU_RCAP", "2")
                }
            };

            /*"    05 W-LEITURA-RCAPCOMP             PIC  9(001) VALUE ZERO.*/

            public SelectorBasis W_LEITURA_RCAPCOMP { get; set; } = new SelectorBasis("001", "ZERO")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 ENCONTROU-RCAPCOMP                      VALUE 1. */
							new SelectorItemBasis("ENCONTROU_RCAPCOMP", "1"),
							/*" 88 NAO-ENCONTROU-RCAPCOMP                  VALUE 2. */
							new SelectorItemBasis("NAO_ENCONTROU_RCAPCOMP", "2")
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
							/*" 88 TPREG-CLIENTE                           VALUE '1'. */
							new SelectorItemBasis("TPREG_CLIENTE", "1"),
							/*" 88 TPREG-ENDERECO                          VALUE '2'. */
							new SelectorItemBasis("TPREG_ENDERECO", "2"),
							/*" 88 TPREG-PROPOSTA                          VALUE '3'. */
							new SelectorItemBasis("TPREG_PROPOSTA", "3"),
							/*" 88 TPREG-BENEFICIARIO                      VALUE '4'. */
							new SelectorItemBasis("TPREG_BENEFICIARIO", "4"),
							/*" 88 TPREG-INFO-COMPLEMENTAR                 VALUE '5'. */
							new SelectorItemBasis("TPREG_INFO_COMPLEMENTAR", "5"),
							/*" 88 TPREG-DIVERSOS-MR                       VALUE '6'. */
							new SelectorItemBasis("TPREG_DIVERSOS_MR", "6"),
							/*" 88 TPREG-CORRESP-CAIXA                     VALUE 'C'. */
							new SelectorItemBasis("TPREG_CORRESP_CAIXA", "C")
                }
            };

            /*"    05 W-PRP-REMOTO                   PIC  9(001) VALUE ZERO.*/

            public SelectorBasis W_PRP_REMOTO { get; set; } = new SelectorBasis("001", "ZERO")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 W-EXISTE-PRP-REMOTO                     VALUE 1. */
							new SelectorItemBasis("W_EXISTE_PRP_REMOTO", "1")
                }
            };

            /*"    05 W-HEADER-PRP-FILIAL            PIC  9(001) VALUE ZERO.*/

            public SelectorBasis W_HEADER_PRP_FILIAL { get; set; } = new SelectorBasis("001", "ZERO")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 HDFIL-NAO-GERADO                        VALUE 1. */
							new SelectorItemBasis("HDFIL_NAO_GERADO", "1"),
							/*" 88 HDFIL-FOI-GERADO                        VALUE 2. */
							new SelectorItemBasis("HDFIL_FOI_GERADO", "2")
                }
            };

        }


        public Copies.LXFPF990 LXFPF990 { get; set; } = new Copies.LXFPF990();
        public Copies.LBFPF000 LBFPF000 { get; set; } = new Copies.LBFPF000();
        public Copies.LBFPF011 LBFPF011 { get; set; } = new Copies.LBFPF011();
        public Copies.LBFPF012 LBFPF012 { get; set; } = new Copies.LBFPF012();
        public Copies.LXFCT004 LXFCT004 { get; set; } = new Copies.LXFCT004();
        public Copies.LBFPF014 LBFPF014 { get; set; } = new Copies.LBFPF014();
        public Copies.LBFPF015 LBFPF015 { get; set; } = new Copies.LBFPF015();
        public Copies.LBFPF016 LBFPF016 { get; set; } = new Copies.LBFPF016();
        public Copies.LBFPF026 LBFPF026 { get; set; } = new Copies.LBFPF026();
        public Copies.LBFPF991 LBFPF991 { get; set; } = new Copies.LBFPF991();
        public Dclgens.AGENCEF AGENCEF { get; set; } = new Dclgens.AGENCEF();
        public Dclgens.TARIBCEF TARIBCEF { get; set; } = new Dclgens.TARIBCEF();
        public Dclgens.FONTES FONTES { get; set; } = new Dclgens.FONTES();
        public Dclgens.RCAPS RCAPS { get; set; } = new Dclgens.RCAPS();
        public Dclgens.RCAPCOMP RCAPCOMP { get; set; } = new Dclgens.RCAPCOMP();
        public Dclgens.CEDENTE CEDENTE { get; set; } = new Dclgens.CEDENTE();
        public Dclgens.COVSICOB COVSICOB { get; set; } = new Dclgens.COVSICOB();
        public Dclgens.PRODVG PRODVG { get; set; } = new Dclgens.PRODVG();
        public Dclgens.ESCNEG ESCNEG { get; set; } = new Dclgens.ESCNEG();
        public Dclgens.MALHACEF MALHACEF { get; set; } = new Dclgens.MALHACEF();
        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.PROPFID PROPFID { get; set; } = new Dclgens.PROPFID();
        public Dclgens.PROPFIDH PROPFIDH { get; set; } = new Dclgens.PROPFIDH();
        public Dclgens.COVSIVPF COVSIVPF { get; set; } = new Dclgens.COVSIVPF();
        public Dclgens.ARQSIVPF ARQSIVPF { get; set; } = new Dclgens.ARQSIVPF();
        public Dclgens.PROPFIDC PROPFIDC { get; set; } = new Dclgens.PROPFIDC();
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
        public PF0641B_EMAIL EMAIL { get; set; } = new PF0641B_EMAIL();
        public PF0641B_ENDERECOS ENDERECOS { get; set; } = new PF0641B_ENDERECOS();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string MOV_MRISCO_FILE_NAME_P, string MOV_CEF_FILE_NAME_P, string MOV_FNAE_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                MOV_MRISCO.SetFile(MOV_MRISCO_FILE_NAME_P);
                MOV_CEF.SetFile(MOV_CEF_FILE_NAME_P);
                MOV_FNAE.SetFile(MOV_FNAE_FILE_NAME_P);

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
            /*" -721- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -722- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -723- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -726- DISPLAY '************************************************' . */
            _.Display($"************************************************");

            /*" -727- DISPLAY '*               PROGRAMA PF0641B               *' . */
            _.Display($"*               PROGRAMA PF0641B               *");

            /*" -728- DISPLAY '*  MOV ESTOQUE M.R. E GERAR TABS CORPORATIVAS  *' . */
            _.Display($"*  MOV ESTOQUE M.R. E GERAR TABS CORPORATIVAS  *");

            /*" -729- DISPLAY '*           VERSA0:  06 - 03/12/2018           *' . */
            _.Display($"*           VERSA0:  06 - 03/12/2018           *");

            /*" -730- DISPLAY '************************************************' . */
            _.Display($"************************************************");

            /*" -740- DISPLAY '*  PF0641B - INICIO  EM ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2). */

            $"*  PF0641B - INICIO  EM {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
            .Display();

            /*" -742- PERFORM R0000-00-INICIALIZAR. */

            R0000_00_INICIALIZAR_SECTION();

            /*" -744- PERFORM R0050-00-LER-MOV-MRISCO. */

            R0050_00_LER_MOV_MRISCO_SECTION();

            /*" -745- IF W-FIM-MOVTO-MR EQUAL 'FIM' */

            if (WAREA_AUXILIAR.W_FIM_MOVTO_MR == "FIM")
            {

                /*" -746- DISPLAY '************************************************' */
                _.Display($"************************************************");

                /*" -747- DISPLAY '*                   PF0641B                    *' */
                _.Display($"*                   PF0641B                    *");

                /*" -748- DISPLAY '*               TERMINO  NORMAL                *' */
                _.Display($"*               TERMINO  NORMAL                *");

                /*" -749- DISPLAY '*             NAO HOUVE MOVIMENTO              *' */
                _.Display($"*             NAO HOUVE MOVIMENTO              *");

                /*" -750- DISPLAY '************************************************' */
                _.Display($"************************************************");

                /*" -751- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -753- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


            /*" -755- MOVE 1 TO W-HEADER-PRP-FILIAL */
            _.Move(1, WREA88.W_HEADER_PRP_FILIAL);

            /*" -758- PERFORM R0200-00-PROCESSAR-MOVIMENTO UNTIL W-FIM-MOVTO-MR EQUAL 'FIM' . */

            while (!(WAREA_AUXILIAR.W_FIM_MOVTO_MR == "FIM"))
            {

                R0200_00_PROCESSAR_MOVIMENTO_SECTION();
            }

            /*" -759- IF HDFIL-FOI-GERADO */

            if (WREA88.W_HEADER_PRP_FILIAL["HDFIL_FOI_GERADO"])
            {

                /*" -760- PERFORM R2080-00-TRAILLER-FILIAIS */

                R2080_00_TRAILLER_FILIAIS_SECTION();

                /*" -761- PERFORM R2090-00-ATUALIZAR-ARQSIVPF */

                R2090_00_ATUALIZAR_ARQSIVPF_SECTION();

                /*" -763- END-IF */
            }


            /*" -765- PERFORM R9988-00-FECHAR-ARQUIVOS. */

            R9988_00_FECHAR_ARQUIVOS_SECTION();

            /*" -765- PERFORM R9999-00-FINALIZAR. */

            R9999_00_FINALIZAR_SECTION();

        }

        [StopWatch]
        /*" R0000-00-INICIALIZAR-SECTION */
        private void R0000_00_INICIALIZAR_SECTION()
        {
            /*" -773- MOVE 'R0000-00-INICIALIZAR' TO PARAGRAFO. */
            _.Move("R0000-00-INICIALIZAR", WABEND.FILLER_10.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -775- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.FILLER_10.LOCALIZA_ABEND_2.COMANDO);

            /*" -777- INITIALIZE TAB-CBO. */
            _.Initialize(
                WAREA_AUXILIAR.TAB_CBO
            );

            /*" -779- PERFORM R0005-00-OBTER-DATA-DIA. */

            R0005_00_OBTER_DATA_DIA_SECTION();

            /*" -781- PERFORM R0010-00-ABRIR-ARQUIVOS. */

            R0010_00_ABRIR_ARQUIVOS_SECTION();

            /*" -781- PERFORM R0015-OBTER-MAX-COD-PESSOA. */

            R0015_OBTER_MAX_COD_PESSOA_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_SAIDA*/

        [StopWatch]
        /*" R0005-00-OBTER-DATA-DIA-SECTION */
        private void R0005_00_OBTER_DATA_DIA_SECTION()
        {
            /*" -791- MOVE 'R0005-00-OBTER-DATA-DIA' TO PARAGRAFO. */
            _.Move("R0005-00-OBTER-DATA-DIA", WABEND.FILLER_10.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -793- MOVE 'SELECT SEGUROS.SISTEMAS' TO COMANDO. */
            _.Move("SELECT SEGUROS.SISTEMAS", WABEND.FILLER_10.LOCALIZA_ABEND_2.COMANDO);

            /*" -795- MOVE 'PF' TO SISTEMAS-IDE-SISTEMA OF DCLSISTEMAS. */
            _.Move("PF", SISTEMAS.DCLSISTEMAS.SISTEMAS_IDE_SISTEMA);

            /*" -801- PERFORM R0005_00_OBTER_DATA_DIA_DB_SELECT_1 */

            R0005_00_OBTER_DATA_DIA_DB_SELECT_1();

            /*" -806- MOVE SISTEMAS-DATA-MOV-ABERTO OF DCLSISTEMAS TO W-DTMOVABE. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, W_DTMOVABE);

            /*" -808- MOVE W-DIA-MOVABE OF W-DTMOVABE1 TO W-DIA-MOVABE OF W-DTMOVABE-I1. */
            _.Move(W_DTMOVABE1.W_DIA_MOVABE, W_DTMOVABE_I1.W_DIA_MOVABE_0);

            /*" -810- MOVE W-MES-MOVABE OF W-DTMOVABE1 TO W-MES-MOVABE OF W-DTMOVABE-I1. */
            _.Move(W_DTMOVABE1.W_MES_MOVABE, W_DTMOVABE_I1.W_MES_MOVABE_0);

            /*" -813- MOVE W-ANO-MOVABE OF W-DTMOVABE1 TO W-ANO-MOVABE OF W-DTMOVABE-I1. */
            _.Move(W_DTMOVABE1.W_ANO_MOVABE, W_DTMOVABE_I1.W_ANO_MOVABE_0);

            /*" -815- MOVE '-' TO W-BARRA1 OF W-DTMOVABE-I1, W-BARRA2 OF W-DTMOVABE-I1. */
            _.Move("-", W_DTMOVABE_I1.W_BARRA1_0);
            _.Move("-", W_DTMOVABE_I1.W_BARRA2_0);


        }

        [StopWatch]
        /*" R0005-00-OBTER-DATA-DIA-DB-SELECT-1 */
        public void R0005_00_OBTER_DATA_DIA_DB_SELECT_1()
        {
            /*" -801- EXEC SQL SELECT DATA_MOV_ABERTO INTO :DCLSISTEMAS.SISTEMAS-DATA-MOV-ABERTO FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = :DCLSISTEMAS.SISTEMAS-IDE-SISTEMA WITH UR END-EXEC. */

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
            /*" -825- MOVE 'R0010-00-ABRIR-ARQUIVOS' TO PARAGRAFO. */
            _.Move("R0010-00-ABRIR-ARQUIVOS", WABEND.FILLER_10.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -827- MOVE 'OPEN' TO COMANDO. */
            _.Move("OPEN", WABEND.FILLER_10.LOCALIZA_ABEND_2.COMANDO);

            /*" -828- OPEN INPUT MOV-MRISCO */
            MOV_MRISCO.Open(REG_MRISCO, WAREA_AUXILIAR.WSTATUS);

            /*" -829- IF WSTATUS NOT EQUAL '00' */

            if (WAREA_AUXILIAR.WSTATUS != "00")
            {

                /*" -830- IF WSTATUS NOT EQUAL '35' */

                if (WAREA_AUXILIAR.WSTATUS != "35")
                {

                    /*" -831- DISPLAY 'ERRO OPEN ARQUIVO MOV-MRISCO' */
                    _.Display($"ERRO OPEN ARQUIVO MOV-MRISCO");

                    /*" -832- DISPLAY 'STATUS ... ' WSTATUS */
                    _.Display($"STATUS ... {WAREA_AUXILIAR.WSTATUS}");

                    /*" -833- PERFORM R9999-00-FINALIZAR */

                    R9999_00_FINALIZAR_SECTION();

                    /*" -834- ELSE */
                }
                else
                {


                    /*" -835- DISPLAY 'ARQUIVO VAZIO - TERMINO NORMAL ' */
                    _.Display($"ARQUIVO VAZIO - TERMINO NORMAL ");

                    /*" -836- DISPLAY 'STATUS ... ' WSTATUS */
                    _.Display($"STATUS ... {WAREA_AUXILIAR.WSTATUS}");

                    /*" -837- MOVE 'FIM' TO W-FIM-MOVTO-MR */
                    _.Move("FIM", WAREA_AUXILIAR.W_FIM_MOVTO_MR);

                    /*" -839- PERFORM R9999-00-FINALIZAR. */

                    R9999_00_FINALIZAR_SECTION();
                }

            }


            /*" -840- OPEN OUTPUT MOV-CEF */
            MOV_CEF.Open(REG_MOV_CEF, WAREA_AUXILIAR.WSTATUS);

            /*" -841- IF WSTATUS NOT EQUAL '00' */

            if (WAREA_AUXILIAR.WSTATUS != "00")
            {

                /*" -842- DISPLAY 'ERRO OPEN ARQUIVO MOV-CEF' */
                _.Display($"ERRO OPEN ARQUIVO MOV-CEF");

                /*" -843- DISPLAY 'STATUS ... ' WSTATUS */
                _.Display($"STATUS ... {WAREA_AUXILIAR.WSTATUS}");

                /*" -844- CLOSE MOV-MRISCO */
                MOV_MRISCO.Close();

                /*" -846- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


            /*" -847- OPEN OUTPUT MOV-FNAE */
            MOV_FNAE.Open(REG_MOV_FNAE, WAREA_AUXILIAR.WSTATUS);

            /*" -848- IF WSTATUS NOT EQUAL '00' */

            if (WAREA_AUXILIAR.WSTATUS != "00")
            {

                /*" -849- DISPLAY 'ERRO OPEN ARQUIVO MOV-FNAE' */
                _.Display($"ERRO OPEN ARQUIVO MOV-FNAE");

                /*" -850- DISPLAY 'STATUS ... ' WSTATUS */
                _.Display($"STATUS ... {WAREA_AUXILIAR.WSTATUS}");

                /*" -851- CLOSE MOV-CEF */
                MOV_CEF.Close();

                /*" -851- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0010_SAIDA*/

        [StopWatch]
        /*" R0015-OBTER-MAX-COD-PESSOA-SECTION */
        private void R0015_OBTER_MAX_COD_PESSOA_SECTION()
        {
            /*" -861- MOVE 'R0015-OBTER-MAX-COD-PESSOA' TO PARAGRAFO. */
            _.Move("R0015-OBTER-MAX-COD-PESSOA", WABEND.FILLER_10.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -863- MOVE 'MAX SEGUROS.PESSOA' TO COMANDO. */
            _.Move("MAX SEGUROS.PESSOA", WABEND.FILLER_10.LOCALIZA_ABEND_2.COMANDO);

            /*" -868- PERFORM R0015_OBTER_MAX_COD_PESSOA_DB_SELECT_1 */

            R0015_OBTER_MAX_COD_PESSOA_DB_SELECT_1();

            /*" -871- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -872- DISPLAY 'PF0641B - FIM ANORMAL' */
                _.Display($"PF0641B - FIM ANORMAL");

                /*" -873- DISPLAY '          ERRO NO SELECT MAX TAB. PESSOA' */
                _.Display($"          ERRO NO SELECT MAX TAB. PESSOA");

                /*" -875- DISPLAY '          NUMERO DA PROPOSTA............  ' R1-NUM-PROPOSTA OF REG-CLIENTES */
                _.Display($"          NUMERO DA PROPOSTA............  {LBFPF011.REG_CLIENTES.R1_NUM_PROPOSTA}");

                /*" -877- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -878- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -880- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


            /*" -881- MOVE PESSOA-COD-PESSOA OF DCLPESSOA TO W-COD-PESSOA. */
            _.Move(PESSOA.DCLPESSOA.PESSOA_COD_PESSOA, WAREA_AUXILIAR.W_COD_PESSOA);

        }

        [StopWatch]
        /*" R0015-OBTER-MAX-COD-PESSOA-DB-SELECT-1 */
        public void R0015_OBTER_MAX_COD_PESSOA_DB_SELECT_1()
        {
            /*" -868- EXEC SQL SELECT VALUE(MAX(COD_PESSOA),0) INTO :DCLPESSOA.PESSOA-COD-PESSOA FROM SEGUROS.PESSOA WITH UR END-EXEC. */

            var r0015_OBTER_MAX_COD_PESSOA_DB_SELECT_1_Query1 = new R0015_OBTER_MAX_COD_PESSOA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0015_OBTER_MAX_COD_PESSOA_DB_SELECT_1_Query1.Execute(r0015_OBTER_MAX_COD_PESSOA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PESSOA_COD_PESSOA, PESSOA.DCLPESSOA.PESSOA_COD_PESSOA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0015_SAIDA*/

        [StopWatch]
        /*" R0050-00-LER-MOV-MRISCO-SECTION */
        private void R0050_00_LER_MOV_MRISCO_SECTION()
        {
            /*" -891- MOVE 'R0050-00-LER-MOV-MRISCO' TO PARAGRAFO. */
            _.Move("R0050-00-LER-MOV-MRISCO", WABEND.FILLER_10.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -893- MOVE 'READ' TO COMANDO. */
            _.Move("READ", WABEND.FILLER_10.LOCALIZA_ABEND_2.COMANDO);

            /*" -894- READ MOV-MRISCO */
            MOV_MRISCO.Read();

            /*" -895- IF WSTATUS NOT EQUAL '00' */

            if (WAREA_AUXILIAR.WSTATUS != "00")
            {

                /*" -896- IF WSTATUS EQUAL '10' */

                if (WAREA_AUXILIAR.WSTATUS == "10")
                {

                    /*" -897- MOVE 'FIM' TO W-FIM-MOVTO-MR */
                    _.Move("FIM", WAREA_AUXILIAR.W_FIM_MOVTO_MR);

                    /*" -898- ELSE */
                }
                else
                {


                    /*" -899- DISPLAY 'ERRO READ ARQUIVO MOV-MRISCO ' WSTATUS */
                    _.Display($"ERRO READ ARQUIVO MOV-MRISCO {WAREA_AUXILIAR.WSTATUS}");

                    /*" -900- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -902- PERFORM R9999-00-FINALIZAR. */

                    R9999_00_FINALIZAR_SECTION();
                }

            }


            /*" -904- IF W-FIM-MOVTO-MR NOT EQUAL 'FIM' */

            if (WAREA_AUXILIAR.W_FIM_MOVTO_MR != "FIM")
            {

                /*" -905- IF W-LIDO-MOVTO-SIGAT EQUAL ZEROS */

                if (WAREA_AUXILIAR.W_LIDO_MOVTO_SIGAT == 00)
                {

                    /*" -906- IF REG-TIPO-SIGAT NOT EQUAL 'H' */

                    if (REG_MRISCO.REG_TIPO_SIGAT != "H")
                    {

                        /*" -907- MOVE 'FIM' TO W-FIM-MOVTO-MR */
                        _.Move("FIM", WAREA_AUXILIAR.W_FIM_MOVTO_MR);

                        /*" -908- GO TO R0050-SAIDA */
                        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0050_SAIDA*/ //GOTO
                        return;

                        /*" -909- END-IF */
                    }


                    /*" -911- END-IF */
                }


                /*" -912- IF W-LIDO-MOVTO-SIGAT EQUAL 1 */

                if (WAREA_AUXILIAR.W_LIDO_MOVTO_SIGAT == 1)
                {

                    /*" -913- IF REG-TIPO-SIGAT EQUAL 'T' */

                    if (REG_MRISCO.REG_TIPO_SIGAT == "T")
                    {

                        /*" -914- MOVE 'FIM' TO W-FIM-MOVTO-MR */
                        _.Move("FIM", WAREA_AUXILIAR.W_FIM_MOVTO_MR);

                        /*" -915- GO TO R0050-SAIDA */
                        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0050_SAIDA*/ //GOTO
                        return;

                        /*" -916- END-IF */
                    }


                    /*" -918- END-IF */
                }


                /*" -921- ADD 1 TO W-LIDO-MOVTO-SIGAT, W-AC-CONTROLE */
                WAREA_AUXILIAR.W_LIDO_MOVTO_SIGAT.Value = WAREA_AUXILIAR.W_LIDO_MOVTO_SIGAT + 1;
                WAREA_AUXILIAR.W_AC_CONTROLE.Value = WAREA_AUXILIAR.W_AC_CONTROLE + 1;

                /*" -922- IF REG-TIPO-SIGAT EQUAL ' ' OR '0' */

                if (REG_MRISCO.REG_TIPO_SIGAT.In(" ", "0"))
                {

                    /*" -923- GO TO R0050-00-LER-MOV-MRISCO */
                    new Task(() => R0050_00_LER_MOV_MRISCO_SECTION()).RunSynchronously(); //GOTO
                    return;//Recursividade detectada, cuidado...

                    /*" -924- ELSE */
                }
                else
                {


                    /*" -925- IF REG-TIPO-SIGAT EQUAL 'H' */

                    if (REG_MRISCO.REG_TIPO_SIGAT == "H")
                    {

                        /*" -927- MOVE REG-MRISCO TO REG-HEADER W-REG-HEADER */
                        _.Move(MOV_MRISCO?.Value, LXFPF990.REG_HEADER, W_REG_HEADER);

                        /*" -929- IF RH-TIPO-ARQUIVO OF REG-HEADER EQUAL 1 AND RH-NOME OF REG-HEADER EQUAL 'PRPSASSE' */

                        if (LXFPF990.REG_HEADER.RH_TIPO_ARQUIVO == 1 && LXFPF990.REG_HEADER.RH_NOME == "PRPSASSE")
                        {

                            /*" -930- PERFORM R0100-00-VALIDAR-HEADER */

                            R0100_00_VALIDAR_HEADER_SECTION();

                            /*" -931- END-IF */
                        }


                        /*" -932- GO TO R0050-00-LER-MOV-MRISCO */
                        new Task(() => R0050_00_LER_MOV_MRISCO_SECTION()).RunSynchronously(); //GOTO
                        return;//Recursividade detectada, cuidado...

                        /*" -933- ELSE */
                    }
                    else
                    {


                        /*" -934- IF REG-TIPO-SIGAT EQUAL 'T' */

                        if (REG_MRISCO.REG_TIPO_SIGAT == "T")
                        {

                            /*" -935- MOVE REG-MRISCO TO REG-TRAILLER */
                            _.Move(MOV_MRISCO?.Value, LBFPF991.REG_TRAILLER);

                            /*" -936- ELSE */
                        }
                        else
                        {


                            /*" -937- IF W-AC-CONTROLE GREATER 999 */

                            if (WAREA_AUXILIAR.W_AC_CONTROLE > 999)
                            {

                                /*" -938- ACCEPT WS-TIME FROM TIME */
                                _.Move(_.AcceptDate("TIME"), WS_TIME);

                                /*" -939- MOVE WS-TIME-N TO WS-TIME-EDIT */
                                _.Move(WS_TIME.WS_TIME_N, WS_TIME_EDIT);

                                /*" -940- DISPLAY ' ' */
                                _.Display($" ");

                                /*" -943- DISPLAY 'PF0641B - TOTAL LIDO ' W-LIDO-MOVTO-SIGAT '  HORAS  ' WS-TIME-EDIT */

                                $"PF0641B - TOTAL LIDO {WAREA_AUXILIAR.W_LIDO_MOVTO_SIGAT}  HORAS  {WS_TIME_EDIT}"
                                .Display();

                                /*" -943- MOVE ZEROS TO W-AC-CONTROLE. */
                                _.Move(0, WAREA_AUXILIAR.W_AC_CONTROLE);
                            }

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
            /*" -953- MOVE 'R0100-00-VALIDAR-HEADER' TO PARAGRAFO. */
            _.Move("R0100-00-VALIDAR-HEADER", WABEND.FILLER_10.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -955- MOVE '    ' TO COMANDO. */
            _.Move("    ", WABEND.FILLER_10.LOCALIZA_ABEND_2.COMANDO);

            /*" -956- IF RH-TIPO-REG OF REG-HEADER NOT EQUAL 'H' */

            if (LXFPF990.REG_HEADER.RH_TIPO_REG != "H")
            {

                /*" -957- DISPLAY 'PF0641B - FIM ANORMAL' */
                _.Display($"PF0641B - FIM ANORMAL");

                /*" -960- DISPLAY '          MOVMENTO NAO POSSUI HEADER  ' RH-NOME OF REG-HEADER '  ' RH-DATA-GERACAO OF REG-HEADER */

                $"          MOVMENTO NAO POSSUI HEADER  {LXFPF990.REG_HEADER.RH_NOME}  {LXFPF990.REG_HEADER.RH_DATA_GERACAO}"
                .Display();

                /*" -961- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -963- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


            /*" -964- IF RH-NOME OF REG-HEADER NOT EQUAL 'PRPSASSE' */

            if (LXFPF990.REG_HEADER.RH_NOME != "PRPSASSE")
            {

                /*" -965- DISPLAY 'PF0641B - FIM ANORMAL' */
                _.Display($"PF0641B - FIM ANORMAL");

                /*" -966- DISPLAY '          HEADER INVALIDO' */
                _.Display($"          HEADER INVALIDO");

                /*" -969- DISPLAY '          NOME DO ARQUIVO INVALIDO  ' RH-NOME OF REG-HEADER '  ' RH-DATA-GERACAO OF REG-HEADER */

                $"          NOME DO ARQUIVO INVALIDO  {LXFPF990.REG_HEADER.RH_NOME}  {LXFPF990.REG_HEADER.RH_DATA_GERACAO}"
                .Display();

                /*" -970- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -972- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


            /*" -974- PERFORM R0110-00-VALIDAR-CONVENIO. */

            R0110_00_VALIDAR_CONVENIO_SECTION();

            /*" -975- IF RH-DATA-GERACAO OF REG-HEADER NOT NUMERIC */

            if (!LXFPF990.REG_HEADER.RH_DATA_GERACAO.IsNumeric())
            {

                /*" -976- DISPLAY 'PF0641B - FIM ANORMAL' */
                _.Display($"PF0641B - FIM ANORMAL");

                /*" -977- DISPLAY '          HEADER INVALIDO' */
                _.Display($"          HEADER INVALIDO");

                /*" -980- DISPLAY '          DATA DA GERACAO INVALIDA  ' RH-NOME OF REG-HEADER '  ' RH-DATA-GERACAO OF REG-HEADER */

                $"          DATA DA GERACAO INVALIDA  {LXFPF990.REG_HEADER.RH_NOME}  {LXFPF990.REG_HEADER.RH_DATA_GERACAO}"
                .Display();

                /*" -981- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -983- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


            /*" -984- IF RH-DATA-GERACAO OF REG-HEADER EQUAL ZEROS */

            if (LXFPF990.REG_HEADER.RH_DATA_GERACAO == 00)
            {

                /*" -985- DISPLAY 'PF0641B - FIM ANORMAL' */
                _.Display($"PF0641B - FIM ANORMAL");

                /*" -986- DISPLAY '          HEADER INVALIDO' */
                _.Display($"          HEADER INVALIDO");

                /*" -989- DISPLAY '          DATA DA GERACAO INVALIDA  ' RH-NOME OF REG-HEADER '  ' RH-DATA-GERACAO OF REG-HEADER */

                $"          DATA DA GERACAO INVALIDA  {LXFPF990.REG_HEADER.RH_NOME}  {LXFPF990.REG_HEADER.RH_DATA_GERACAO}"
                .Display();

                /*" -990- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -992- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


            /*" -993- IF RH-SIST-ORIGEM OF REG-HEADER NOT EQUAL 4 */

            if (LXFPF990.REG_HEADER.RH_SIST_ORIGEM != 4)
            {

                /*" -994- DISPLAY 'PF0641B - FIM ANORMAL' */
                _.Display($"PF0641B - FIM ANORMAL");

                /*" -995- DISPLAY '          HEADER INVALIDO' */
                _.Display($"          HEADER INVALIDO");

                /*" -999- DISPLAY '          SISTEMA ORIGEM INVALIDO  ' RH-NOME OF REG-HEADER '  ' RH-SIST-ORIGEM OF REG-HEADER '  ' RH-DATA-GERACAO OF REG-HEADER */

                $"          SISTEMA ORIGEM INVALIDO  {LXFPF990.REG_HEADER.RH_NOME}  {LXFPF990.REG_HEADER.RH_SIST_ORIGEM}  {LXFPF990.REG_HEADER.RH_DATA_GERACAO}"
                .Display();

                /*" -1000- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -1002- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


            /*" -1003- IF RH-SIST-DESTINO OF REG-HEADER NOT EQUAL 1 */

            if (LXFPF990.REG_HEADER.RH_SIST_DESTINO != 1)
            {

                /*" -1004- DISPLAY 'PF0641B - FIM ANORMAL' */
                _.Display($"PF0641B - FIM ANORMAL");

                /*" -1005- DISPLAY '          HEADER INVALIDO' */
                _.Display($"          HEADER INVALIDO");

                /*" -1009- DISPLAY '          SISTEMA DESTINO INVALIDO  ' RH-NOME OF REG-HEADER '  ' RH-SIST-DESTINO OF REG-HEADER '  ' RH-DATA-GERACAO OF REG-HEADER */

                $"          SISTEMA DESTINO INVALIDO  {LXFPF990.REG_HEADER.RH_NOME}  {LXFPF990.REG_HEADER.RH_SIST_DESTINO}  {LXFPF990.REG_HEADER.RH_DATA_GERACAO}"
                .Display();

                /*" -1010- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -1012- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


            /*" -1013- IF RH-TIPO-ARQUIVO OF REG-HEADER NOT EQUAL 1 */

            if (LXFPF990.REG_HEADER.RH_TIPO_ARQUIVO != 1)
            {

                /*" -1014- DISPLAY 'PF0641B  -  FIM ANORMAL' */
                _.Display($"PF0641B  -  FIM ANORMAL");

                /*" -1015- DISPLAY '            HEADER INVALIDO' */
                _.Display($"            HEADER INVALIDO");

                /*" -1016- DISPLAY '            TIPO DE ARQUIVO INVALIDO ' */
                _.Display($"            TIPO DE ARQUIVO INVALIDO ");

                /*" -1018- DISPLAY '            RH-NOME................. ' RH-NOME OF REG-HEADER */
                _.Display($"            RH-NOME................. {LXFPF990.REG_HEADER.RH_NOME}");

                /*" -1020- DISPLAY '            RH-DATA-GERACAO......... ' RH-DATA-GERACAO OF REG-HEADER */
                _.Display($"            RH-DATA-GERACAO......... {LXFPF990.REG_HEADER.RH_DATA_GERACAO}");

                /*" -1022- DISPLAY '            RH-TIPO-ARQUIVO......... ' RH-TIPO-ARQUIVO OF REG-HEADER */
                _.Display($"            RH-TIPO-ARQUIVO......... {LXFPF990.REG_HEADER.RH_TIPO_ARQUIVO}");

                /*" -1023- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -1025- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


            /*" -1027- PERFORM R0117-00-OBTER-NSAS-MOVTO */

            R0117_00_OBTER_NSAS_MOVTO_SECTION();

            /*" -1028- IF RH-NSAS OF REG-HEADER EQUAL ZEROS */

            if (LXFPF990.REG_HEADER.RH_NSAS == 00)
            {

                /*" -1029- DISPLAY 'PF0641B - FIM ANORMAL' */
                _.Display($"PF0641B - FIM ANORMAL");

                /*" -1030- DISPLAY '          HEADER INVALIDO' */
                _.Display($"          HEADER INVALIDO");

                /*" -1034- DISPLAY '          SEQUENCIAL DO ARQUIVO INVALIDO  ' RH-NOME OF REG-HEADER ' ' RH-SIST-ORIGEM OF REG-HEADER ' ' RH-DATA-GERACAO OF REG-HEADER */

                $"          SEQUENCIAL DO ARQUIVO INVALIDO  {LXFPF990.REG_HEADER.RH_NOME} {LXFPF990.REG_HEADER.RH_SIST_ORIGEM} {LXFPF990.REG_HEADER.RH_DATA_GERACAO}"
                .Display();

                /*" -1035- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -1035- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_SAIDA*/

        [StopWatch]
        /*" R0110-00-VALIDAR-CONVENIO-SECTION */
        private void R0110_00_VALIDAR_CONVENIO_SECTION()
        {
            /*" -1045- MOVE 'R0110-00-VALIDAR-CONVENIO' TO PARAGRAFO. */
            _.Move("R0110-00-VALIDAR-CONVENIO", WABEND.FILLER_10.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1047- MOVE 'SELECT CONVEIO_SIVPF' TO COMANDO. */
            _.Move("SELECT CONVEIO_SIVPF", WABEND.FILLER_10.LOCALIZA_ABEND_2.COMANDO);

            /*" -1050- MOVE RH-NOME OF REG-HEADER TO SIGLA-ARQUIVO OF DCLCONVENIO-SIVPF. */
            _.Move(LXFPF990.REG_HEADER.RH_NOME, COVSIVPF.DCLCONVENIO_SIVPF.SIGLA_ARQUIVO);

            /*" -1056- PERFORM R0110_00_VALIDAR_CONVENIO_DB_SELECT_1 */

            R0110_00_VALIDAR_CONVENIO_DB_SELECT_1();

            /*" -1059- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -1060- DISPLAY 'PF0641B - FIM ANORMAL' */
                _.Display($"PF0641B - FIM ANORMAL");

                /*" -1061- DISPLAY '          CONVENIO NAO CADASTRADO' */
                _.Display($"          CONVENIO NAO CADASTRADO");

                /*" -1063- DISPLAY '          NOME ARQUIVO........ ' RH-NOME OF REG-HEADER */
                _.Display($"          NOME ARQUIVO........ {LXFPF990.REG_HEADER.RH_NOME}");

                /*" -1065- DISPLAY '          DATA GERACAO........ ' RH-DATA-GERACAO OF REG-HEADER */
                _.Display($"          DATA GERACAO........ {LXFPF990.REG_HEADER.RH_DATA_GERACAO}");

                /*" -1067- DISPLAY '          SISTEMA ORIGEM...... ' RH-SIST-ORIGEM OF REG-HEADER */
                _.Display($"          SISTEMA ORIGEM...... {LXFPF990.REG_HEADER.RH_SIST_ORIGEM}");

                /*" -1069- DISPLAY '          SISTEMA DESTINO..... ' RH-SIST-DESTINO OF REG-HEADER */
                _.Display($"          SISTEMA DESTINO..... {LXFPF990.REG_HEADER.RH_SIST_DESTINO}");

                /*" -1071- DISPLAY '          NSAS................ ' RH-NSAS OF REG-HEADER */
                _.Display($"          NSAS................ {LXFPF990.REG_HEADER.RH_NSAS}");

                /*" -1072- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -1072- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R0110-00-VALIDAR-CONVENIO-DB-SELECT-1 */
        public void R0110_00_VALIDAR_CONVENIO_DB_SELECT_1()
        {
            /*" -1056- EXEC SQL SELECT DESCR_ARQUIVO INTO :DCLCONVENIO-SIVPF.DESCR-ARQUIVO FROM SEGUROS.CONVENIO_SIVPF WHERE SIGLA_ARQUIVO = :DCLCONVENIO-SIVPF.SIGLA-ARQUIVO WITH UR END-EXEC. */

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
            /*" -1082- MOVE 'R0117-00-OBTER-NSAS-MOVTO' TO PARAGRAFO. */
            _.Move("R0117-00-OBTER-NSAS-MOVTO", WABEND.FILLER_10.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1084- MOVE 'SELECT COUNT ARQUIVOS-SIVPF' TO COMANDO. */
            _.Move("SELECT COUNT ARQUIVOS-SIVPF", WABEND.FILLER_10.LOCALIZA_ABEND_2.COMANDO);

            /*" -1087- MOVE 'PRPMRISC' TO ARQSIVPF-SIGLA-ARQUIVO OF DCLARQUIVOS-SIVPF. */
            _.Move("PRPMRISC", ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SIGLA_ARQUIVO);

            /*" -1090- MOVE RH-SIST-ORIGEM OF REG-HEADER TO ARQSIVPF-SISTEMA-ORIGEM OF DCLARQUIVOS-SIVPF. */
            _.Move(LXFPF990.REG_HEADER.RH_SIST_ORIGEM, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SISTEMA_ORIGEM);

            /*" -1099- PERFORM R0117_00_OBTER_NSAS_MOVTO_DB_SELECT_1 */

            R0117_00_OBTER_NSAS_MOVTO_DB_SELECT_1();

            /*" -1102- IF SQLCODE EQUAL 00 */

            if (DB.SQLCODE == 00)
            {

                /*" -1105- MOVE ARQSIVPF-NSAS-SIVPF OF DCLARQUIVOS-SIVPF TO W-NSAS-MR */
                _.Move(ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF, WAREA_AUXILIAR.W_NSAS_MR);

                /*" -1106- COMPUTE W-NSAS-MR = W-NSAS-MR + 1 */
                WAREA_AUXILIAR.W_NSAS_MR.Value = WAREA_AUXILIAR.W_NSAS_MR + 1;

                /*" -1107- MOVE W-NSAS-MR TO RH-NSAS OF REG-HEADER */
                _.Move(WAREA_AUXILIAR.W_NSAS_MR, LXFPF990.REG_HEADER.RH_NSAS);

                /*" -1108- ELSE */
            }
            else
            {


                /*" -1109- DISPLAY 'PF0641B - FIM ANORMAL' */
                _.Display($"PF0641B - FIM ANORMAL");

                /*" -1111- DISPLAY '          ERRO ACESSO TABELA ARQUIVOS-SIVPF ' SQLCODE */
                _.Display($"          ERRO ACESSO TABELA ARQUIVOS-SIVPF {DB.SQLCODE}");

                /*" -1113- DISPLAY '          SIGLA DO ARQUIVO................. ' ARQSIVPF-NSAS-SIVPF OF DCLARQUIVOS-SIVPF */
                _.Display($"          SIGLA DO ARQUIVO................. {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF}");

                /*" -1114- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -1114- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R0117-00-OBTER-NSAS-MOVTO-DB-SELECT-1 */
        public void R0117_00_OBTER_NSAS_MOVTO_DB_SELECT_1()
        {
            /*" -1099- EXEC SQL SELECT VALUE(MAX(NSAS_SIVPF),0) INTO :DCLARQUIVOS-SIVPF.ARQSIVPF-NSAS-SIVPF FROM SEGUROS.ARQUIVOS_SIVPF WHERE SIGLA_ARQUIVO = :DCLARQUIVOS-SIVPF.ARQSIVPF-SIGLA-ARQUIVO AND SISTEMA_ORIGEM = :DCLARQUIVOS-SIVPF.ARQSIVPF-SISTEMA-ORIGEM WITH UR END-EXEC. */

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
            /*" -1124- MOVE 'R0200-00-PROCESSA-MOVIMENTO' TO PARAGRAFO. */
            _.Move("R0200-00-PROCESSA-MOVIMENTO", WABEND.FILLER_10.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1126- MOVE '    ' TO COMANDO. */
            _.Move("    ", WABEND.FILLER_10.LOCALIZA_ABEND_2.COMANDO);

            /*" -1130- PERFORM R0250-00-TRATA-EMPRESA UNTIL W-FIM-MOVTO-MR EQUAL 'FIM' OR REG-TIPO-SIGAT OF REG-MRISCO EQUAL 'T' . */

            while (!(WAREA_AUXILIAR.W_FIM_MOVTO_MR == "FIM" || REG_MRISCO.REG_TIPO_SIGAT == "T"))
            {

                R0250_00_TRATA_EMPRESA_SECTION();
            }

            /*" -1132- PERFORM R2100-00-TB-CONTROLE. */

            R2100_00_TB_CONTROLE_SECTION();

            /*" -1132- PERFORM R2000-00-QUEBRA-EMPRESSA. */

            R2000_00_QUEBRA_EMPRESSA_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_SAIDA*/

        [StopWatch]
        /*" R0250-00-TRATA-EMPRESA-SECTION */
        private void R0250_00_TRATA_EMPRESA_SECTION()
        {
            /*" -1142- MOVE 'R0250-00-TRATA-EMPRESA' TO PARAGRAFO. */
            _.Move("R0250-00-TRATA-EMPRESA", WABEND.FILLER_10.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1144- MOVE '    ' TO COMANDO. */
            _.Move("    ", WABEND.FILLER_10.LOCALIZA_ABEND_2.COMANDO);

            /*" -1146- PERFORM R0270-00-INICIALIZAR-AREAS. */

            R0270_00_INICIALIZAR_AREAS_SECTION();

            /*" -1152- PERFORM R0300-00-TRATA-MOVIMENTO UNTIL W-FIM-MOVTO-MR EQUAL 'FIM' OR REG-TIPO-SIGAT OF REG-MRISCO EQUAL 'T' OR REG-NUM-PROPOSTA OF REG-MRISCO NOT EQUAL W-NUM-PROPOSTA-ANT. */

            while (!(WAREA_AUXILIAR.W_FIM_MOVTO_MR == "FIM" || REG_MRISCO.REG_TIPO_SIGAT == "T" || REG_MRISCO.REG_NUM_PROPOSTA != WAREA_AUXILIAR.W_NUM_PROPOSTA_ANT))
            {

                R0300_00_TRATA_MOVIMENTO_SECTION();
            }

            /*" -1153- IF WS-REGISTRO-VALIDO NOT EQUAL 123 */

            if (FILLER_8.WS_REGISTRO_VALIDO != 123)
            {

                /*" -1154- DISPLAY 'PF0641B - PROPOSTA FALTA REGISTRO' */
                _.Display($"PF0641B - PROPOSTA FALTA REGISTRO");

                /*" -1156- DISPLAY '          NUMERO DA PROPOSTA...  ' W-NUM-PROPOSTA-ANT */
                _.Display($"          NUMERO DA PROPOSTA...  {WAREA_AUXILIAR.W_NUM_PROPOSTA_ANT}");

                /*" -1157- ADD 1 TO W-DESP-MOVTO-SIGAT */
                WAREA_AUXILIAR.W_DESP_MOVTO_SIGAT.Value = WAREA_AUXILIAR.W_DESP_MOVTO_SIGAT + 1;

                /*" -1159- GO TO R0250-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0250_SAIDA*/ //GOTO
                return;
            }


            /*" -1160- IF HDFIL-NAO-GERADO */

            if (WREA88.W_HEADER_PRP_FILIAL["HDFIL_NAO_GERADO"])
            {

                /*" -1161- PERFORM R0450-00-OBTER-NSAS-MOV-CEF */

                R0450_00_OBTER_NSAS_MOV_CEF_SECTION();

                /*" -1163- PERFORM R0460-00-GERAR-HEADER. */

                R0460_00_GERAR_HEADER_SECTION();
            }


            /*" -1168- MOVE 'NAO' TO W-EXISTE-PROPOSTA W-EXISTE-SICOB. */
            _.Move("NAO", WAREA_AUXILIAR.W_EXISTE_PROPOSTA, WAREA_AUXILIAR.W_EXISTE_SICOB);

            /*" -1169- IF R3-COD-PRODUTO = 10 OR 48 OR 50 OR 71 OR 72 */

            if (LXFCT004.REG_PROPOSTA_SASSE.R3_COD_PRODUTO.In("10", "48", "50", "71", "72"))
            {

                /*" -1171- MOVE R3-NUM-PROPOSTA OF REG-PROPOSTA-SASSE TO R3-NUM-SICOB OF REG-PROPOSTA-SASSE */
                _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_NUM_PROPOSTA, LXFCT004.REG_PROPOSTA_SASSE.R3_NUM_SICOB);

                /*" -1173- END-IF. */
            }


            /*" -1175- PERFORM R0465-00-LER-SICOB. */

            R0465_00_LER_SICOB_SECTION();

            /*" -1178- IF W-EXISTE-SICOB EQUAL 'SIM' */

            if (WAREA_AUXILIAR.W_EXISTE_SICOB == "SIM")
            {

                /*" -1179- ADD 1 TO W-QTD-MOV-MR-3 */
                WAREA_AUXILIAR.W_QTD_MOV_MR_3.Value = WAREA_AUXILIAR.W_QTD_MOV_MR_3 + 1;

                /*" -1180- PERFORM R0471-00-ATUALIZAR-TAB-PF */

                R0471_00_ATUALIZAR_TAB_PF_SECTION();

                /*" -1189- PERFORM R1500-00-GERAR-MOV-CEF */

                R1500_00_GERAR_MOV_CEF_SECTION();

                /*" -1190- ELSE */
            }
            else
            {


                /*" -1192- PERFORM R0470-00-LER-PROPOSTA */

                R0470_00_LER_PROPOSTA_SECTION();

                /*" -1193- IF W-EXISTE-PROPOSTA EQUAL 'SIM' */

                if (WAREA_AUXILIAR.W_EXISTE_PROPOSTA == "SIM")
                {

                    /*" -1194- ADD 1 TO W-QTD-MOV-MR-3 */
                    WAREA_AUXILIAR.W_QTD_MOV_MR_3.Value = WAREA_AUXILIAR.W_QTD_MOV_MR_3 + 1;

                    /*" -1195- PERFORM R0471-00-ATUALIZAR-TAB-PF */

                    R0471_00_ATUALIZAR_TAB_PF_SECTION();

                    /*" -1196- ELSE */
                }
                else
                {


                    /*" -1197- PERFORM R0480-00-GERAR-TAB-PF */

                    R0480_00_GERAR_TAB_PF_SECTION();

                    /*" -1199- END-IF */
                }


                /*" -1199- PERFORM R1500-00-GERAR-MOV-CEF. */

                R1500_00_GERAR_MOV_CEF_SECTION();
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0250_SAIDA*/

        [StopWatch]
        /*" R0270-00-INICIALIZAR-AREAS-SECTION */
        private void R0270_00_INICIALIZAR_AREAS_SECTION()
        {
            /*" -1211- MOVE REG-NUM-PROPOSTA OF REG-MRISCO TO W-NUM-PROPOSTA, W-NUM-PROPOSTA-ANT. */
            _.Move(REG_MRISCO.REG_NUM_PROPOSTA, WREA88.W_NUM_PROPOSTA, WAREA_AUXILIAR.W_NUM_PROPOSTA_ANT);

            /*" -1231- INITIALIZE W-TAB-DIVERSOS , W-TB-ENDERECOS-N , W-TAB-BENEFICIARIOS , W-TB-ENDERECOS-A , W-IND-DIVERSOS , W-IND-DIVERSOS-N , W-IND-ENDER , W-IND-ENDER1 , W-IND-ENDER-N , W-IND-ENDER-A , W-EXISTE-TP-2 , W-IND-BENEF , W-IND-BENEF-N , W-IND-SICAQ , W-IND-SICAQ-N , W-IND-INFO-N , W-EXISTE-TP-6 , W-CONTROLE-TP-0 , W-EXISTE-TP-C , REG-CLIENTES , REG-PROPOSTA-SASSE, REG-BENEFIC , REG-VAL-ACESSORIOS, REG-INFORMACOES , REG-PAG-AVULSO , REG-TIPO-C , WS-REGISTRO-TP-1 , WS-REGISTRO-TP-2 , WS-REGISTRO-TP-3 , WS-REGISTRO-TP-4 , WS-REGISTRO-TP-5 , WS-REGISTRO-TP-6 , WS-REGISTRO-TP-C , DCLPESSOA , DCLPROPOSTA-FIDELIZ. */
            _.Initialize(
                WAREA_AUXILIAR.W_TAB_DIVERSOS
                , WAREA_AUXILIAR.W_TB_ENDERECOS_N
                , WAREA_AUXILIAR.W_TAB_BENEFICIARIOS
                , WAREA_AUXILIAR.W_TB_ENDERECOS_A
                , WAREA_AUXILIAR.W_IND_DIVERSOS
                , WAREA_AUXILIAR.W_IND_DIVERSOS_N
                , WAREA_AUXILIAR.W_IND_ENDER
                , WAREA_AUXILIAR.W_IND_ENDER1
                , WAREA_AUXILIAR.W_IND_ENDER_N
                , WAREA_AUXILIAR.W_IND_ENDER_A
                , WAREA_AUXILIAR.W_EXISTE_TP_2
                , WAREA_AUXILIAR.W_IND_BENEF
                , WAREA_AUXILIAR.W_IND_BENEF_N
                , WAREA_AUXILIAR.W_IND_SICAQ
                , WAREA_AUXILIAR.W_IND_SICAQ_N
                , WAREA_AUXILIAR.W_IND_INFO_N
                , WAREA_AUXILIAR.W_EXISTE_TP_6
                , WAREA_AUXILIAR.W_CONTROLE_TP_0
                , WAREA_AUXILIAR.W_EXISTE_TP_C
                , LBFPF011.REG_CLIENTES
                , LXFCT004.REG_PROPOSTA_SASSE
                , LBFPF014.REG_BENEFIC
                , LBFPF016.REG_VAL_ACESSORIOS
                , LBFPF015.REG_INFORMACOES
                , LBFPF000.REG_PAG_AVULSO
                , LBFPF026.REG_TIPO_C
                , WS_REGISTRO_LIDO.WS_REGISTRO_TP_1
                , WS_REGISTRO_LIDO.WS_REGISTRO_TP_2
                , WS_REGISTRO_LIDO.WS_REGISTRO_TP_3
                , WS_REGISTRO_LIDO.WS_REGISTRO_TP_4
                , WS_REGISTRO_LIDO.WS_REGISTRO_TP_5
                , WS_REGISTRO_LIDO.WS_REGISTRO_TP_6
                , WS_REGISTRO_LIDO.WS_REGISTRO_TP_C
                , PESSOA.DCLPESSOA
                , PROPFID.DCLPROPOSTA_FIDELIZ
            );

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0270_SAIDA*/

        [StopWatch]
        /*" R0300-00-TRATA-MOVIMENTO-SECTION */
        private void R0300_00_TRATA_MOVIMENTO_SECTION()
        {
            /*" -1240- MOVE 'R0300-00-TRATA-MOVIMENTO' TO PARAGRAFO. */
            _.Move("R0300-00-TRATA-MOVIMENTO", WABEND.FILLER_10.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1242- MOVE '    ' TO COMANDO. */
            _.Move("    ", WABEND.FILLER_10.LOCALIZA_ABEND_2.COMANDO);

            /*" -1244- MOVE REG-TIPO-SIGAT OF REG-MRISCO TO W-TP-REGISTRO. */
            _.Move(REG_MRISCO.REG_TIPO_SIGAT, WREA88.W_TP_REGISTRO);

            /*" -1245-  EVALUATE TRUE  */

            /*" -1246-  WHEN TPREG-CLIENTE  */

            /*" -1246- IF TPREG-CLIENTE */

            if (WREA88.W_TP_REGISTRO["TPREG_CLIENTE"])
            {

                /*" -1247- MOVE REG-MRISCO TO REG-CLIENTES */
                _.Move(MOV_MRISCO?.Value, LBFPF011.REG_CLIENTES);

                /*" -1249- MOVE 1 TO WS-REGISTRO-TP-1 */
                _.Move(1, WS_REGISTRO_LIDO.WS_REGISTRO_TP_1);

                /*" -1250-  WHEN TPREG-ENDERECO  */

                /*" -1250- ELSE IF TPREG-ENDERECO */
            }
            else

            if (WREA88.W_TP_REGISTRO["TPREG_ENDERECO"])
            {

                /*" -1251- PERFORM R0315-00-MOVTO-ENDERECO */

                R0315_00_MOVTO_ENDERECO_SECTION();

                /*" -1253- MOVE 2 TO WS-REGISTRO-TP-2 */
                _.Move(2, WS_REGISTRO_LIDO.WS_REGISTRO_TP_2);

                /*" -1254-  WHEN TPREG-PROPOSTA  */

                /*" -1254- ELSE IF TPREG-PROPOSTA */
            }
            else

            if (WREA88.W_TP_REGISTRO["TPREG_PROPOSTA"])
            {

                /*" -1255- PERFORM R0320-00-MOVTO-PROPOSTA */

                R0320_00_MOVTO_PROPOSTA_SECTION();

                /*" -1257- MOVE 3 TO WS-REGISTRO-TP-3 */
                _.Move(3, WS_REGISTRO_LIDO.WS_REGISTRO_TP_3);

                /*" -1258-  WHEN TPREG-BENEFICIARIO  */

                /*" -1258- ELSE IF TPREG-BENEFICIARIO */
            }
            else

            if (WREA88.W_TP_REGISTRO["TPREG_BENEFICIARIO"])
            {

                /*" -1259- PERFORM R0325-00-MOVTO-BENEFICIARIO */

                R0325_00_MOVTO_BENEFICIARIO_SECTION();

                /*" -1261- MOVE 4 TO WS-REGISTRO-TP-4 */
                _.Move(4, WS_REGISTRO_LIDO.WS_REGISTRO_TP_4);

                /*" -1262-  WHEN TPREG-INFO-COMPLEMENTAR  */

                /*" -1262- ELSE IF TPREG-INFO-COMPLEMENTAR */
            }
            else

            if (WREA88.W_TP_REGISTRO["TPREG_INFO_COMPLEMENTAR"])
            {

                /*" -1263- PERFORM R0330-00-MOVTO-INF-COMPLEME */

                R0330_00_MOVTO_INF_COMPLEME_SECTION();

                /*" -1265- MOVE 5 TO WS-REGISTRO-TP-5 */
                _.Move(5, WS_REGISTRO_LIDO.WS_REGISTRO_TP_5);

                /*" -1266-  WHEN TPREG-DIVERSOS-MR  */

                /*" -1266- ELSE IF TPREG-DIVERSOS-MR */
            }
            else

            if (WREA88.W_TP_REGISTRO["TPREG_DIVERSOS_MR"])
            {

                /*" -1267- PERFORM R0335-00-MOVTO-DIVERSOS-MR */

                R0335_00_MOVTO_DIVERSOS_MR_SECTION();

                /*" -1269- MOVE 6 TO WS-REGISTRO-TP-6 */
                _.Move(6, WS_REGISTRO_LIDO.WS_REGISTRO_TP_6);

                /*" -1270-  WHEN TPREG-CORRESP-CAIXA  */

                /*" -1270- ELSE IF TPREG-CORRESP-CAIXA */
            }
            else

            if (WREA88.W_TP_REGISTRO["TPREG_CORRESP_CAIXA"])
            {

                /*" -1271- PERFORM R0340-00-MOVTO-CORRESP-CAIXA */

                R0340_00_MOVTO_CORRESP_CAIXA_SECTION();

                /*" -1273- MOVE 'C' TO WS-REGISTRO-TP-C */
                _.Move("C", WS_REGISTRO_LIDO.WS_REGISTRO_TP_C);

                /*" -1274-  WHEN TPREG-HEADER  */

                /*" -1274- ELSE IF TPREG-HEADER */
            }
            else

            if (WREA88.W_TP_REGISTRO["TPREG_HEADER"])
            {

                /*" -1276- MOVE REG-MRISCO TO REG-HEADER */
                _.Move(MOV_MRISCO?.Value, LXFPF990.REG_HEADER);

                /*" -1277-  WHEN TPREG-TRAILLER  */

                /*" -1277- ELSE IF TPREG-TRAILLER */
            }
            else

            if (WREA88.W_TP_REGISTRO["TPREG_TRAILLER"])
            {

                /*" -1279- MOVE REG-MRISCO TO REG-TRAILLER */
                _.Move(MOV_MRISCO?.Value, LBFPF991.REG_TRAILLER);

                /*" -1280-  WHEN OTHER  */

                /*" -1280- ELSE */
            }
            else
            {


                /*" -1281- DISPLAY 'PF0641B - FIM ANORMAL' */
                _.Display($"PF0641B - FIM ANORMAL");

                /*" -1282- DISPLAY '          TIPO REGISTRO NAO ESPERADO' */
                _.Display($"          TIPO REGISTRO NAO ESPERADO");

                /*" -1284- DISPLAY '          TIPO DE REGISTRO........  ' REG-TIPO-SIGAT OF REG-MRISCO */
                _.Display($"          TIPO DE REGISTRO........  {REG_MRISCO.REG_TIPO_SIGAT}");

                /*" -1286- DISPLAY '          NUMERO DA PROPOSTA......  ' REG-NUM-PROPOSTA OF REG-MRISCO */
                _.Display($"          NUMERO DA PROPOSTA......  {REG_MRISCO.REG_NUM_PROPOSTA}");

                /*" -1287- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -1288- PERFORM R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION();

                /*" -1288-  END-EVALUATE.  */

                /*" -1288- END-IF. */
            }


            /*" -0- FLUXCONTROL_PERFORM R0300_10 */

            R0300_10();

        }

        [StopWatch]
        /*" R0300-10 */
        private void R0300_10(bool isPerform = false)
        {
            /*" -1292- PERFORM R0050-00-LER-MOV-MRISCO. */

            R0050_00_LER_MOV_MRISCO_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_SAIDA*/

        [StopWatch]
        /*" R0315-00-MOVTO-ENDERECO-SECTION */
        private void R0315_00_MOVTO_ENDERECO_SECTION()
        {
            /*" -1302- MOVE 'R0315-00-MOVTO-ENDERECO' TO PARAGRAFO. */
            _.Move("R0315-00-MOVTO-ENDERECO", WABEND.FILLER_10.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1304- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.FILLER_10.LOCALIZA_ABEND_2.COMANDO);

            /*" -1305- MOVE 'SIM' TO W-EXISTE-TP-2 */
            _.Move("SIM", WAREA_AUXILIAR.W_EXISTE_TP_2);

            /*" -1307- ADD 1 TO W-IND-ENDER-N. */
            WAREA_AUXILIAR.W_IND_ENDER_N.Value = WAREA_AUXILIAR.W_IND_ENDER_N + 1;

            /*" -1308- IF W-IND-ENDER-N GREATER 100 */

            if (WAREA_AUXILIAR.W_IND_ENDER_N > 100)
            {

                /*" -1309- DISPLAY 'PF0641B - FIM ANORMAL' */
                _.Display($"PF0641B - FIM ANORMAL");

                /*" -1310- DISPLAY '          ESTOURO DA TABELA DE ENDERECOS' */
                _.Display($"          ESTOURO DA TABELA DE ENDERECOS");

                /*" -1312- DISPLAY '          NUMERO DA PROPOSTA..........  ' R2-NUM-PROPOSTA OF REG-ENDERECO */
                _.Display($"          NUMERO DA PROPOSTA..........  {LBFPF012.REG_ENDERECO.R2_NUM_PROPOSTA}");

                /*" -1314- DISPLAY '          W-IND-ENDER.................  ' W-IND-ENDER */
                _.Display($"          W-IND-ENDER.................  {WAREA_AUXILIAR.W_IND_ENDER}");

                /*" -1315- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -1317- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


            /*" -1318- MOVE REG-MRISCO TO W-TB-REG-ENDERECOS-N(W-IND-ENDER-N). */
            _.Move(MOV_MRISCO?.Value, WAREA_AUXILIAR.W_TB_ENDERECOS_N.W_TAB_END_REG_N[WAREA_AUXILIAR.W_IND_ENDER_N].W_TB_REG_ENDERECOS_N);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0315_SAIDA*/

        [StopWatch]
        /*" R0320-00-MOVTO-PROPOSTA-SECTION */
        private void R0320_00_MOVTO_PROPOSTA_SECTION()
        {
            /*" -1328- MOVE 'R0320-00-MOVTO-PROPOSTA' TO PARAGRAFO. */
            _.Move("R0320-00-MOVTO-PROPOSTA", WABEND.FILLER_10.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1330- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.FILLER_10.LOCALIZA_ABEND_2.COMANDO);

            /*" -1330- MOVE REG-MRISCO TO REG-PROPOSTA-SASSE. */
            _.Move(MOV_MRISCO?.Value, LXFCT004.REG_PROPOSTA_SASSE);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0320_SAIDA*/

        [StopWatch]
        /*" R0325-00-MOVTO-BENEFICIARIO-SECTION */
        private void R0325_00_MOVTO_BENEFICIARIO_SECTION()
        {
            /*" -1340- MOVE 'R0325-00-MOVTO-BENEFICIARIOS' TO PARAGRAFO. */
            _.Move("R0325-00-MOVTO-BENEFICIARIOS", WABEND.FILLER_10.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1342- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.FILLER_10.LOCALIZA_ABEND_2.COMANDO);

            /*" -1344- ADD 1 TO W-IND-BENEF-N. */
            WAREA_AUXILIAR.W_IND_BENEF_N.Value = WAREA_AUXILIAR.W_IND_BENEF_N + 1;

            /*" -1345- IF W-IND-BENEF-N GREATER 999 */

            if (WAREA_AUXILIAR.W_IND_BENEF_N > 999)
            {

                /*" -1346- DISPLAY 'PF0641B - FIM ANORMAL' */
                _.Display($"PF0641B - FIM ANORMAL");

                /*" -1347- DISPLAY '          ESTOURO DA TABELA DE BENEFICIARIOS' */
                _.Display($"          ESTOURO DA TABELA DE BENEFICIARIOS");

                /*" -1349- DISPLAY '          NUMERO DA PROPOSTA..............  ' R4-NUM-PROPOSTA OF REG-BENEFIC */
                _.Display($"          NUMERO DA PROPOSTA..............  {LBFPF014.REG_BENEFIC.R4_NUM_PROPOSTA}");

                /*" -1351- DISPLAY '          W-IND-BENEF-N...................  ' W-IND-BENEF-N */
                _.Display($"          W-IND-BENEF-N...................  {WAREA_AUXILIAR.W_IND_BENEF_N}");

                /*" -1352- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -1354- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


            /*" -1355- MOVE REG-MRISCO TO W-TB-REG-BENEFI(W-IND-BENEF-N). */
            _.Move(MOV_MRISCO?.Value, WAREA_AUXILIAR.W_TAB_BENEFICIARIOS.W_TAB_BENEF_REG[WAREA_AUXILIAR.W_IND_BENEF_N].W_TB_REG_BENEFI);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0325_SAIDA*/

        [StopWatch]
        /*" R0330-00-MOVTO-INF-COMPLEME-SECTION */
        private void R0330_00_MOVTO_INF_COMPLEME_SECTION()
        {
            /*" -1365- MOVE 'R0330-00-MOVTO-INF-COMPLEMENTAR' TO PARAGRAFO. */
            _.Move("R0330-00-MOVTO-INF-COMPLEMENTAR", WABEND.FILLER_10.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1367- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.FILLER_10.LOCALIZA_ABEND_2.COMANDO);

            /*" -1369- MOVE REG-MRISCO TO REG-INFORMACOES. */
            _.Move(MOV_MRISCO?.Value, LBFPF015.REG_INFORMACOES);

            /*" -1370- IF R5-INFO-COMPLEMEN OF REG-INFORMACOES NOT EQUAL SPACES */

            if (!LBFPF015.REG_INFORMACOES.R5_INFO_COMPLEMEN.IsEmpty())
            {

                /*" -1372- ADD 1 TO W-IND-INFO-N */
                WAREA_AUXILIAR.W_IND_INFO_N.Value = WAREA_AUXILIAR.W_IND_INFO_N + 1;

                /*" -1373- IF W-IND-INFO-N GREATER 30 */

                if (WAREA_AUXILIAR.W_IND_INFO_N > 30)
                {

                    /*" -1374- DISPLAY 'PF0641B - FIM ANORMAL' */
                    _.Display($"PF0641B - FIM ANORMAL");

                    /*" -1375- DISPLAY '          R0330 - ESTOURO TAB  REG INF COMPL' */
                    _.Display($"          R0330 - ESTOURO TAB  REG INF COMPL");

                    /*" -1377- DISPLAY '          NUMERO DA PROPOSTA..............  ' R5-NUM-PROPOSTA OF REG-INFORMACOES */
                    _.Display($"          NUMERO DA PROPOSTA..............  {LBFPF015.REG_INFORMACOES.R5_NUM_PROPOSTA}");

                    /*" -1379- DISPLAY '          W-IND-INFO-N....................  ' W-IND-INFO-N */
                    _.Display($"          W-IND-INFO-N....................  {WAREA_AUXILIAR.W_IND_INFO_N}");

                    /*" -1380- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -1381- PERFORM R9999-00-FINALIZAR */

                    R9999_00_FINALIZAR_SECTION();

                    /*" -1383- END-IF */
                }


                /*" -1383- MOVE REG-MRISCO TO W-TB-REG-INFORMACOES(W-IND-INFO-N). */
                _.Move(MOV_MRISCO?.Value, WAREA_AUXILIAR.W_TAB_INFORMACOES.W_TAB_INFO_REG[WAREA_AUXILIAR.W_IND_INFO_N].W_TB_REG_INFORMACOES);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0330_SAIDA*/

        [StopWatch]
        /*" R0335-00-MOVTO-DIVERSOS-MR-SECTION */
        private void R0335_00_MOVTO_DIVERSOS_MR_SECTION()
        {
            /*" -1393- MOVE 'R0335-00-MOVTO-DIVERSOS-MR' TO PARAGRAFO. */
            _.Move("R0335-00-MOVTO-DIVERSOS-MR", WABEND.FILLER_10.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1395- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.FILLER_10.LOCALIZA_ABEND_2.COMANDO);

            /*" -1397- MOVE 'SIM' TO W-EXISTE-TP-6 */
            _.Move("SIM", WAREA_AUXILIAR.W_EXISTE_TP_6);

            /*" -1399- ADD 1 TO W-IND-DIVERSOS-N */
            WAREA_AUXILIAR.W_IND_DIVERSOS_N.Value = WAREA_AUXILIAR.W_IND_DIVERSOS_N + 1;

            /*" -1400- IF W-IND-DIVERSOS-N GREATER 300 */

            if (WAREA_AUXILIAR.W_IND_DIVERSOS_N > 300)
            {

                /*" -1401- DISPLAY 'PF0641B - FIM ANORMAL' */
                _.Display($"PF0641B - FIM ANORMAL");

                /*" -1402- DISPLAY '          R0335 - ESTOURO TAB REGISTROS DIVERSOS' */
                _.Display($"          R0335 - ESTOURO TAB REGISTROS DIVERSOS");

                /*" -1404- DISPLAY '          NUMERO DA PROPOSTA............     ' R6-NUM-PROPOSTA OF REG-VAL-ACESSORIOS */
                _.Display($"          NUMERO DA PROPOSTA............     {LBFPF016.REG_VAL_ACESSORIOS.R6_NUM_PROPOSTA}");

                /*" -1406- DISPLAY '          W-IND-DIVERSOS-N..................  ' W-IND-DIVERSOS-N */
                _.Display($"          W-IND-DIVERSOS-N..................  {WAREA_AUXILIAR.W_IND_DIVERSOS_N}");

                /*" -1407- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -1409- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


            /*" -1409- MOVE REG-MRISCO TO W-TB-REG-DIVERSOS(W-IND-DIVERSOS-N). */
            _.Move(MOV_MRISCO?.Value, WAREA_AUXILIAR.W_TAB_DIVERSOS.W_TAB_DIV_REG[WAREA_AUXILIAR.W_IND_DIVERSOS_N].W_TB_REG_DIVERSOS);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0335_SAIDA*/

        [StopWatch]
        /*" R0340-00-MOVTO-CORRESP-CAIXA-SECTION */
        private void R0340_00_MOVTO_CORRESP_CAIXA_SECTION()
        {
            /*" -1419- MOVE 'R0340-00-MOVTO-CORRESP-CAIXA' TO PARAGRAFO. */
            _.Move("R0340-00-MOVTO-CORRESP-CAIXA", WABEND.FILLER_10.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1421- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.FILLER_10.LOCALIZA_ABEND_2.COMANDO);

            /*" -1423- MOVE 'SIM' TO W-EXISTE-TP-C */
            _.Move("SIM", WAREA_AUXILIAR.W_EXISTE_TP_C);

            /*" -1425- ADD 1 TO W-IND-SICAQ-N */
            WAREA_AUXILIAR.W_IND_SICAQ_N.Value = WAREA_AUXILIAR.W_IND_SICAQ_N + 1;

            /*" -1426- IF W-IND-SICAQ-N GREATER 30 */

            if (WAREA_AUXILIAR.W_IND_SICAQ_N > 30)
            {

                /*" -1427- DISPLAY 'PF0641B - FIM ANORMAL' */
                _.Display($"PF0641B - FIM ANORMAL");

                /*" -1428- DISPLAY '          R0340 - ESTOURO TAB REG TIPOC - SICAQ ' */
                _.Display($"          R0340 - ESTOURO TAB REG TIPOC - SICAQ ");

                /*" -1430- DISPLAY '          NUMERO DA PROPOSTA........... ' REGC-NUM-PROPOSTA OF REG-TIPO-C */
                _.Display($"          NUMERO DA PROPOSTA........... {LBFPF026.REG_TIPO_C.REGC_NUM_PROPOSTA}");

                /*" -1432- DISPLAY '          W-IND-SICAQ.................. ' W-IND-SICAQ */
                _.Display($"          W-IND-SICAQ.................. {WAREA_AUXILIAR.W_IND_SICAQ}");

                /*" -1433- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -1435- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


            /*" -1436- MOVE REG-MRISCO TO W-TB-REG-SICAQ (W-IND-SICAQ-N). */
            _.Move(MOV_MRISCO?.Value, WAREA_AUXILIAR.W_TAB_CORRESP_CAIXA.W_TAB_SCQ_REG[WAREA_AUXILIAR.W_IND_SICAQ_N].W_TB_REG_SICAQ);

            /*" -1437- DISPLAY 'ACHEI REGISTRO TIPO C ... ' W-TB-REG-SICAQ (W-IND-SICAQ-N). */
            _.Display($"ACHEI REGISTRO TIPO C ... {WAREA_AUXILIAR.W_TAB_CORRESP_CAIXA.W_TAB_SCQ_REG[WAREA_AUXILIAR.W_IND_SICAQ_N]}");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0340_SAIDA*/

        [StopWatch]
        /*" R0338-00-LER-ENDERECO-COBR-SECTION */
        private void R0338_00_LER_ENDERECO_COBR_SECTION()
        {
            /*" -1447- MOVE 'R0338-00-LER-ENDERECO-COBR' TO PARAGRAFO. */
            _.Move("R0338-00-LER-ENDERECO-COBR", WABEND.FILLER_10.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1449- MOVE 'SELECT PESSOA_ENDERECO' TO COMANDO. */
            _.Move("SELECT PESSOA_ENDERECO", WABEND.FILLER_10.LOCALIZA_ABEND_2.COMANDO);

            /*" -1457- PERFORM R0338_00_LER_ENDERECO_COBR_DB_SELECT_1 */

            R0338_00_LER_ENDERECO_COBR_DB_SELECT_1();

            /*" -1479- PERFORM R0338_00_LER_ENDERECO_COBR_DB_SELECT_2 */

            R0338_00_LER_ENDERECO_COBR_DB_SELECT_2();

            /*" -1483- IF SQLCODE EQUAL 00 OR 100 NEXT SENTENCE */

            if (DB.SQLCODE.In("00", "100"))
            {

                /*" -1484- ELSE */
            }
            else
            {


                /*" -1485- DISPLAY 'PF0641B - FIM ANORMAL' */
                _.Display($"PF0641B - FIM ANORMAL");

                /*" -1486- DISPLAY '          ERRO ACESSO SEGUROS.PESSOA-ENDERECO' */
                _.Display($"          ERRO ACESSO SEGUROS.PESSOA-ENDERECO");

                /*" -1488- DISPLAY '          CODIGO PESSOA.................  ' PESSOA-COD-PESSOA OF DCLPESSOA */
                _.Display($"          CODIGO PESSOA.................  {PESSOA.DCLPESSOA.PESSOA_COD_PESSOA}");

                /*" -1490- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -1491- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -1491- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R0338-00-LER-ENDERECO-COBR-DB-SELECT-1 */
        public void R0338_00_LER_ENDERECO_COBR_DB_SELECT_1()
        {
            /*" -1457- EXEC SQL SELECT VALUE(MAX(OCORR_ENDERECO),0) INTO :DCLPESSOA-ENDERECO.OCORR-ENDERECO FROM SEGUROS.PESSOA_ENDERECO WHERE COD_PESSOA = :DCLPESSOA.PESSOA-COD-PESSOA AND TIPO_ENDER = 2 AND SITUACAO_ENDERECO = 'A' WITH UR END-EXEC. */

            var r0338_00_LER_ENDERECO_COBR_DB_SELECT_1_Query1 = new R0338_00_LER_ENDERECO_COBR_DB_SELECT_1_Query1()
            {
                PESSOA_COD_PESSOA = PESSOA.DCLPESSOA.PESSOA_COD_PESSOA.ToString(),
            };

            var executed_1 = R0338_00_LER_ENDERECO_COBR_DB_SELECT_1_Query1.Execute(r0338_00_LER_ENDERECO_COBR_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.OCORR_ENDERECO, PESENDER.DCLPESSOA_ENDERECO.OCORR_ENDERECO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0338_SAIDA*/

        [StopWatch]
        /*" R0338-00-LER-ENDERECO-COBR-DB-SELECT-2 */
        public void R0338_00_LER_ENDERECO_COBR_DB_SELECT_2()
        {
            /*" -1479- EXEC SQL SELECT OCORR_ENDERECO, ENDERECO, BAIRRO, CIDADE, SIGLA_UF, CEP INTO :DCLPESSOA-ENDERECO.OCORR-ENDERECO, :DCLPESSOA-ENDERECO.ENDERECO, :DCLPESSOA-ENDERECO.BAIRRO, :DCLPESSOA-ENDERECO.CIDADE, :DCLPESSOA-ENDERECO.SIGLA-UF, :DCLPESSOA-ENDERECO.CEP FROM SEGUROS.PESSOA_ENDERECO WHERE COD_PESSOA = :DCLPESSOA.PESSOA-COD-PESSOA AND TIPO_ENDER = 2 AND SITUACAO_ENDERECO = 'A' AND OCORR_ENDERECO = :DCLPESSOA-ENDERECO.OCORR-ENDERECO WITH UR END-EXEC. */

            var r0338_00_LER_ENDERECO_COBR_DB_SELECT_2_Query1 = new R0338_00_LER_ENDERECO_COBR_DB_SELECT_2_Query1()
            {
                OCORR_ENDERECO = PESENDER.DCLPESSOA_ENDERECO.OCORR_ENDERECO.ToString(),
                PESSOA_COD_PESSOA = PESSOA.DCLPESSOA.PESSOA_COD_PESSOA.ToString(),
            };

            var executed_1 = R0338_00_LER_ENDERECO_COBR_DB_SELECT_2_Query1.Execute(r0338_00_LER_ENDERECO_COBR_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.OCORR_ENDERECO, PESENDER.DCLPESSOA_ENDERECO.OCORR_ENDERECO);
                _.Move(executed_1.ENDERECO, PESENDER.DCLPESSOA_ENDERECO.ENDERECO);
                _.Move(executed_1.BAIRRO, PESENDER.DCLPESSOA_ENDERECO.BAIRRO);
                _.Move(executed_1.CIDADE, PESENDER.DCLPESSOA_ENDERECO.CIDADE);
                _.Move(executed_1.SIGLA_UF, PESENDER.DCLPESSOA_ENDERECO.SIGLA_UF);
                _.Move(executed_1.CEP, PESENDER.DCLPESSOA_ENDERECO.CEP);
            }


        }

        [StopWatch]
        /*" R0450-00-OBTER-NSAS-MOV-CEF-SECTION */
        private void R0450_00_OBTER_NSAS_MOV_CEF_SECTION()
        {
            /*" -1501- MOVE 'R0450-00-OBTER-NSAS-CEF' TO PARAGRAFO. */
            _.Move("R0450-00-OBTER-NSAS-CEF", WABEND.FILLER_10.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1503- MOVE 'SELECT MAX ARQUIVOS-SIVPF' TO COMANDO. */
            _.Move("SELECT MAX ARQUIVOS-SIVPF", WABEND.FILLER_10.LOCALIZA_ABEND_2.COMANDO);

            /*" -1510- PERFORM R0450_00_OBTER_NSAS_MOV_CEF_DB_SELECT_1 */

            R0450_00_OBTER_NSAS_MOV_CEF_DB_SELECT_1();

            /*" -1513- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -1514- DISPLAY 'PF0641B - FIM ANORMAL' */
                _.Display($"PF0641B - FIM ANORMAL");

                /*" -1515- DISPLAY '          ERRO SELECT MAX ARQUIVOS-SIVPF' */
                _.Display($"          ERRO SELECT MAX ARQUIVOS-SIVPF");

                /*" -1517- DISPLAY '          SQLCODE........................ ' SQLCODE */
                _.Display($"          SQLCODE........................ {DB.SQLCODE}");

                /*" -1518- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -1520- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


            /*" -1523- MOVE ARQSIVPF-NSAS-SIVPF OF DCLARQUIVOS-SIVPF TO W-RH-NSAS OF W-REG-HEADER */
            _.Move(ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF, W_REG_HEADER.W_RH_NSAS);

            /*" -1525- ADD 1 TO W-RH-NSAS OF W-REG-HEADER */
            W_REG_HEADER.W_RH_NSAS.Value = W_REG_HEADER.W_RH_NSAS + 1;

            /*" -1529- MOVE W-RH-NSAS OF W-REG-HEADER TO W-NSAS-PRP-CEF, ARQSIVPF-NSAS-SIVPF OF DCLARQUIVOS-SIVPF. */
            _.Move(W_REG_HEADER.W_RH_NSAS, WAREA_AUXILIAR.W_NSAS_PRP_CEF, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF);

            /*" -1529- MOVE 1 TO W-GEROU-MOVTO-CEF. */
            _.Move(1, WREA88.W_GEROU_MOVTO_CEF);

        }

        [StopWatch]
        /*" R0450-00-OBTER-NSAS-MOV-CEF-DB-SELECT-1 */
        public void R0450_00_OBTER_NSAS_MOV_CEF_DB_SELECT_1()
        {
            /*" -1510- EXEC SQL SELECT VALUE(MAX(NSAS_SIVPF),0) INTO :DCLARQUIVOS-SIVPF.ARQSIVPF-NSAS-SIVPF FROM SEGUROS.ARQUIVOS_SIVPF WHERE SIGLA_ARQUIVO = 'PRPSASSE' AND SISTEMA_ORIGEM = 4 WITH UR END-EXEC. */

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
            /*" -1539- MOVE 'R0460-00-GERAR-HEADER' TO PARAGRAFO. */
            _.Move("R0460-00-GERAR-HEADER", WABEND.FILLER_10.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1541- MOVE 'WHITE REG-HEADER' TO COMANDO. */
            _.Move("WHITE REG-HEADER", WABEND.FILLER_10.LOCALIZA_ABEND_2.COMANDO);

            /*" -1543- MOVE 2 TO W-HEADER-PRP-FILIAL */
            _.Move(2, WREA88.W_HEADER_PRP_FILIAL);

            /*" -1546- MOVE 'H' TO W-RH-TIPO-REG OF W-REG-HEADER */
            _.Move("H", W_REG_HEADER.W_RH_TIPO_REG);

            /*" -1549- MOVE 'PRPSASSE' TO W-RH-NOME OF W-REG-HEADER */
            _.Move("PRPSASSE", W_REG_HEADER.W_RH_NOME);

            /*" -1550- MOVE W-DIA-MOVABE OF W-DTMOVABE1 TO W-DIA-TRABALHO */
            _.Move(W_DTMOVABE1.W_DIA_MOVABE, WAREA_AUXILIAR.W_DIA_TRABALHO);

            /*" -1551- MOVE W-MES-MOVABE OF W-DTMOVABE1 TO W-MES-TRABALHO */
            _.Move(W_DTMOVABE1.W_MES_MOVABE, WAREA_AUXILIAR.W_MES_TRABALHO);

            /*" -1553- MOVE W-ANO-MOVABE OF W-DTMOVABE1 TO W-ANO-TRABALHO */
            _.Move(W_DTMOVABE1.W_ANO_MOVABE, WAREA_AUXILIAR.W_ANO_TRABALHO);

            /*" -1556- MOVE W-DATA-TRABALHO TO W-RH-DATA-GERACAO OF W-REG-HEADER */
            _.Move(WAREA_AUXILIAR.W_DATA_TRABALHO, W_REG_HEADER.W_RH_DATA_GERACAO);

            /*" -1559- MOVE 4 TO W-RH-SIST-ORIGEM OF W-REG-HEADER */
            _.Move(4, W_REG_HEADER.W_RH_SIST_ORIGEM);

            /*" -1563- MOVE 1 TO W-RH-SIST-DESTINO OF W-REG-HEADER W-RH-TIPO-ARQUIVO OF W-REG-HEADER. */
            _.Move(1, W_REG_HEADER.W_RH_SIST_DESTINO, W_REG_HEADER.W_RH_TIPO_ARQUIVO);

            /*" -1564- WRITE REG-MOV-CEF FROM W-REG-HEADER. */
            _.Move(W_REG_HEADER.GetMoveValues(), REG_MOV_CEF);

            MOV_CEF.Write(REG_MOV_CEF.GetMoveValues().ToString());

            /*" -1564- WRITE REG-MOV-FNAE FROM W-REG-HEADER. */
            _.Move(W_REG_HEADER.GetMoveValues(), REG_MOV_FNAE);

            MOV_FNAE.Write(REG_MOV_FNAE.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0460_SAIDA*/

        [StopWatch]
        /*" R0465-00-LER-SICOB-SECTION */
        private void R0465_00_LER_SICOB_SECTION()
        {
            /*" -1574- MOVE 'R0465-00-LER-SICOB' TO PARAGRAFO. */
            _.Move("R0465-00-LER-SICOB", WABEND.FILLER_10.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1576- MOVE 'SELECT PROPOSTA_FIDELIZ' TO COMANDO. */
            _.Move("SELECT PROPOSTA_FIDELIZ", WABEND.FILLER_10.LOCALIZA_ABEND_2.COMANDO);

            /*" -1579- MOVE R3-NUM-SICOB OF REG-PROPOSTA-SASSE TO NUM-SICOB OF DCLPROPOSTA-FIDELIZ. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_NUM_SICOB, PROPFID.DCLPROPOSTA_FIDELIZ.NUM_SICOB);

            /*" -1665- PERFORM R0465_00_LER_SICOB_DB_SELECT_1 */

            R0465_00_LER_SICOB_DB_SELECT_1();

            /*" -1668- IF SQLCODE EQUAL 00 */

            if (DB.SQLCODE == 00)
            {

                /*" -1669- MOVE 'SIM' TO W-EXISTE-SICOB */
                _.Move("SIM", WAREA_AUXILIAR.W_EXISTE_SICOB);

                /*" -1670- ELSE */
            }
            else
            {


                /*" -1671- IF SQLCODE EQUAL 100 OR -811 */

                if (DB.SQLCODE.In("100", "-811"))
                {

                    /*" -1673- MOVE 'NAO' TO W-EXISTE-SICOB */
                    _.Move("NAO", WAREA_AUXILIAR.W_EXISTE_SICOB);

                    /*" -1674- IF NUM-SICOB OF DCLPROPOSTA-FIDELIZ EQUAL ZEROS */

                    if (PROPFID.DCLPROPOSTA_FIDELIZ.NUM_SICOB == 00)
                    {

                        /*" -1676- DISPLAY '  PROPOSTA SICOB ZERADO  ' R3-NUM-PROPOSTA OF REG-PROPOSTA-SASSE */
                        _.Display($"  PROPOSTA SICOB ZERADO  {LXFCT004.REG_PROPOSTA_SASSE.R3_NUM_PROPOSTA}");

                        /*" -1678- END-IF */
                    }


                    /*" -1679- ELSE */
                }
                else
                {


                    /*" -1680- DISPLAY 'PF0641B - FIM ANORMAL' */
                    _.Display($"PF0641B - FIM ANORMAL");

                    /*" -1682- DISPLAY '          NUMERO SICOB........ ' NUM-SICOB OF DCLPROPOSTA-FIDELIZ */
                    _.Display($"          NUMERO SICOB........ {PROPFID.DCLPROPOSTA_FIDELIZ.NUM_SICOB}");

                    /*" -1683- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -1683- PERFORM R9999-00-FINALIZAR. */

                    R9999_00_FINALIZAR_SECTION();
                }

            }


        }

        [StopWatch]
        /*" R0465-00-LER-SICOB-DB-SELECT-1 */
        public void R0465_00_LER_SICOB_DB_SELECT_1()
        {
            /*" -1665- EXEC SQL SELECT NUM_PROPOSTA_SIVPF, NUM_IDENTIFICACAO, COD_EMPRESA_SIVPF, COD_PESSOA, NUM_SICOB, DATA_PROPOSTA, COD_PRODUTO_SIVPF, AGECOBR, DIA_DEBITO, OPCAOPAG, AGECTADEB, OPRCTADEB, NUMCTADEB, DIGCTADEB, PERC_DESCONTO, NRMATRVEN, AGECTAVEN, OPRCTAVEN, NUMCTAVEN, DIGCTAVEN, CGC_CONVENENTE, NOME_CONVENENTE, NRMATRCON, DTQITBCO, VAL_PAGO, AGEPGTO, VAL_TARIFA, VAL_IOF, DATA_CREDITO, VAL_COMISSAO, SIT_PROPOSTA, COD_USUARIO, CANAL_PROPOSTA, NSAS_SIVPF, ORIGEM_PROPOSTA, NSL, NSAC_SIVPF, SITUACAO_ENVIO, OPCAO_COBER, COD_PLANO INTO :DCLPROPOSTA-FIDELIZ.NUM-PROPOSTA-SIVPF, :DCLPROPOSTA-FIDELIZ.NUM-IDENTIFICACAO, :DCLPROPOSTA-FIDELIZ.COD-EMPRESA-SIVPF, :DCLPROPOSTA-FIDELIZ.COD-PESSOA, :DCLPROPOSTA-FIDELIZ.NUM-SICOB, :DCLPROPOSTA-FIDELIZ.DATA-PROPOSTA, :DCLPROPOSTA-FIDELIZ.COD-PRODUTO-SIVPF, :DCLPROPOSTA-FIDELIZ.AGECOBR, :DCLPROPOSTA-FIDELIZ.DIA-DEBITO, :DCLPROPOSTA-FIDELIZ.OPCAOPAG, :DCLPROPOSTA-FIDELIZ.AGECTADEB, :DCLPROPOSTA-FIDELIZ.OPRCTADEB, :DCLPROPOSTA-FIDELIZ.NUMCTADEB, :DCLPROPOSTA-FIDELIZ.DIGCTADEB, :DCLPROPOSTA-FIDELIZ.PERC-DESCONTO, :DCLPROPOSTA-FIDELIZ.NRMATRVEN, :DCLPROPOSTA-FIDELIZ.AGECTAVEN, :DCLPROPOSTA-FIDELIZ.OPRCTAVEN, :DCLPROPOSTA-FIDELIZ.NUMCTAVEN, :DCLPROPOSTA-FIDELIZ.DIGCTAVEN, :DCLPROPOSTA-FIDELIZ.CGC-CONVENENTE, :DCLPROPOSTA-FIDELIZ.NOME-CONVENENTE, :DCLPROPOSTA-FIDELIZ.NRMATRCON, :DCLPROPOSTA-FIDELIZ.DTQITBCO, :DCLPROPOSTA-FIDELIZ.VAL-PAGO, :DCLPROPOSTA-FIDELIZ.AGEPGTO, :DCLPROPOSTA-FIDELIZ.VAL-TARIFA, :DCLPROPOSTA-FIDELIZ.VAL-IOF, :DCLPROPOSTA-FIDELIZ.DATA-CREDITO, :DCLPROPOSTA-FIDELIZ.VAL-COMISSAO, :DCLPROPOSTA-FIDELIZ.SIT-PROPOSTA, :DCLPROPOSTA-FIDELIZ.COD-USUARIO, :DCLPROPOSTA-FIDELIZ.CANAL-PROPOSTA, :DCLPROPOSTA-FIDELIZ.NSAS-SIVPF, :DCLPROPOSTA-FIDELIZ.ORIGEM-PROPOSTA, :DCLPROPOSTA-FIDELIZ.NSL, :DCLPROPOSTA-FIDELIZ.NSAC-SIVPF, :DCLPROPOSTA-FIDELIZ.SITUACAO-ENVIO, :DCLPROPOSTA-FIDELIZ.OPCAO-COBER, :DCLPROPOSTA-FIDELIZ.COD-PLANO FROM SEGUROS.PROPOSTA_FIDELIZ WHERE NUM_SICOB = :DCLPROPOSTA-FIDELIZ.NUM-SICOB AND NUM_SICOB > 0 WITH UR END-EXEC. */

            var r0465_00_LER_SICOB_DB_SELECT_1_Query1 = new R0465_00_LER_SICOB_DB_SELECT_1_Query1()
            {
                NUM_SICOB = PROPFID.DCLPROPOSTA_FIDELIZ.NUM_SICOB.ToString(),
            };

            var executed_1 = R0465_00_LER_SICOB_DB_SELECT_1_Query1.Execute(r0465_00_LER_SICOB_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.NUM_PROPOSTA_SIVPF, PROPFID.DCLPROPOSTA_FIDELIZ.NUM_PROPOSTA_SIVPF);
                _.Move(executed_1.NUM_IDENTIFICACAO, PROPFID.DCLPROPOSTA_FIDELIZ.NUM_IDENTIFICACAO);
                _.Move(executed_1.COD_EMPRESA_SIVPF, PROPFID.DCLPROPOSTA_FIDELIZ.COD_EMPRESA_SIVPF);
                _.Move(executed_1.COD_PESSOA, PROPFID.DCLPROPOSTA_FIDELIZ.COD_PESSOA);
                _.Move(executed_1.NUM_SICOB, PROPFID.DCLPROPOSTA_FIDELIZ.NUM_SICOB);
                _.Move(executed_1.DATA_PROPOSTA, PROPFID.DCLPROPOSTA_FIDELIZ.DATA_PROPOSTA);
                _.Move(executed_1.COD_PRODUTO_SIVPF, PROPFID.DCLPROPOSTA_FIDELIZ.COD_PRODUTO_SIVPF);
                _.Move(executed_1.AGECOBR, PROPFID.DCLPROPOSTA_FIDELIZ.AGECOBR);
                _.Move(executed_1.DIA_DEBITO, PROPFID.DCLPROPOSTA_FIDELIZ.DIA_DEBITO);
                _.Move(executed_1.OPCAOPAG, PROPFID.DCLPROPOSTA_FIDELIZ.OPCAOPAG);
                _.Move(executed_1.AGECTADEB, PROPFID.DCLPROPOSTA_FIDELIZ.AGECTADEB);
                _.Move(executed_1.OPRCTADEB, PROPFID.DCLPROPOSTA_FIDELIZ.OPRCTADEB);
                _.Move(executed_1.NUMCTADEB, PROPFID.DCLPROPOSTA_FIDELIZ.NUMCTADEB);
                _.Move(executed_1.DIGCTADEB, PROPFID.DCLPROPOSTA_FIDELIZ.DIGCTADEB);
                _.Move(executed_1.PERC_DESCONTO, PROPFID.DCLPROPOSTA_FIDELIZ.PERC_DESCONTO);
                _.Move(executed_1.NRMATRVEN, PROPFID.DCLPROPOSTA_FIDELIZ.NRMATRVEN);
                _.Move(executed_1.AGECTAVEN, PROPFID.DCLPROPOSTA_FIDELIZ.AGECTAVEN);
                _.Move(executed_1.OPRCTAVEN, PROPFID.DCLPROPOSTA_FIDELIZ.OPRCTAVEN);
                _.Move(executed_1.NUMCTAVEN, PROPFID.DCLPROPOSTA_FIDELIZ.NUMCTAVEN);
                _.Move(executed_1.DIGCTAVEN, PROPFID.DCLPROPOSTA_FIDELIZ.DIGCTAVEN);
                _.Move(executed_1.CGC_CONVENENTE, PROPFID.DCLPROPOSTA_FIDELIZ.CGC_CONVENENTE);
                _.Move(executed_1.NOME_CONVENENTE, PROPFID.DCLPROPOSTA_FIDELIZ.NOME_CONVENENTE);
                _.Move(executed_1.NRMATRCON, PROPFID.DCLPROPOSTA_FIDELIZ.NRMATRCON);
                _.Move(executed_1.DTQITBCO, PROPFID.DCLPROPOSTA_FIDELIZ.DTQITBCO);
                _.Move(executed_1.VAL_PAGO, PROPFID.DCLPROPOSTA_FIDELIZ.VAL_PAGO);
                _.Move(executed_1.AGEPGTO, PROPFID.DCLPROPOSTA_FIDELIZ.AGEPGTO);
                _.Move(executed_1.VAL_TARIFA, PROPFID.DCLPROPOSTA_FIDELIZ.VAL_TARIFA);
                _.Move(executed_1.VAL_IOF, PROPFID.DCLPROPOSTA_FIDELIZ.VAL_IOF);
                _.Move(executed_1.DATA_CREDITO, PROPFID.DCLPROPOSTA_FIDELIZ.DATA_CREDITO);
                _.Move(executed_1.VAL_COMISSAO, PROPFID.DCLPROPOSTA_FIDELIZ.VAL_COMISSAO);
                _.Move(executed_1.SIT_PROPOSTA, PROPFID.DCLPROPOSTA_FIDELIZ.SIT_PROPOSTA);
                _.Move(executed_1.COD_USUARIO, PROPFID.DCLPROPOSTA_FIDELIZ.COD_USUARIO);
                _.Move(executed_1.CANAL_PROPOSTA, PROPFID.DCLPROPOSTA_FIDELIZ.CANAL_PROPOSTA);
                _.Move(executed_1.NSAS_SIVPF, PROPFID.DCLPROPOSTA_FIDELIZ.NSAS_SIVPF);
                _.Move(executed_1.ORIGEM_PROPOSTA, PROPFID.DCLPROPOSTA_FIDELIZ.ORIGEM_PROPOSTA);
                _.Move(executed_1.NSL, PROPFID.DCLPROPOSTA_FIDELIZ.NSL);
                _.Move(executed_1.NSAC_SIVPF, PROPFID.DCLPROPOSTA_FIDELIZ.NSAC_SIVPF);
                _.Move(executed_1.SITUACAO_ENVIO, PROPFID.DCLPROPOSTA_FIDELIZ.SITUACAO_ENVIO);
                _.Move(executed_1.OPCAO_COBER, PROPFID.DCLPROPOSTA_FIDELIZ.OPCAO_COBER);
                _.Move(executed_1.COD_PLANO, PROPFID.DCLPROPOSTA_FIDELIZ.COD_PLANO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0465_SAIDA*/

        [StopWatch]
        /*" R0470-00-LER-PROPOSTA-SECTION */
        private void R0470_00_LER_PROPOSTA_SECTION()
        {
            /*" -1693- MOVE 'R0470-00-LER-PROPOSTA' TO PARAGRAFO. */
            _.Move("R0470-00-LER-PROPOSTA", WABEND.FILLER_10.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1695- MOVE 'SELECT PROPOSTA_FIDELIZ' TO COMANDO. */
            _.Move("SELECT PROPOSTA_FIDELIZ", WABEND.FILLER_10.LOCALIZA_ABEND_2.COMANDO);

            /*" -1698- MOVE R3-NUM-PROPOSTA OF REG-PROPOSTA-SASSE TO NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_NUM_PROPOSTA, PROPFID.DCLPROPOSTA_FIDELIZ.NUM_PROPOSTA_SIVPF);

            /*" -1784- PERFORM R0470_00_LER_PROPOSTA_DB_SELECT_1 */

            R0470_00_LER_PROPOSTA_DB_SELECT_1();

            /*" -1787- IF SQLCODE EQUAL 00 */

            if (DB.SQLCODE == 00)
            {

                /*" -1788- MOVE 'SIM' TO W-EXISTE-PROPOSTA */
                _.Move("SIM", WAREA_AUXILIAR.W_EXISTE_PROPOSTA);

                /*" -1789- ELSE */
            }
            else
            {


                /*" -1790- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1791- MOVE 'NAO' TO W-EXISTE-PROPOSTA */
                    _.Move("NAO", WAREA_AUXILIAR.W_EXISTE_PROPOSTA);

                    /*" -1792- ELSE */
                }
                else
                {


                    /*" -1793- DISPLAY 'PF0641B - FIM ANORMAL' */
                    _.Display($"PF0641B - FIM ANORMAL");

                    /*" -1795- DISPLAY '          NUMERO DA PROPOSTA.. ' NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ */
                    _.Display($"          NUMERO DA PROPOSTA.. {PROPFID.DCLPROPOSTA_FIDELIZ.NUM_PROPOSTA_SIVPF}");

                    /*" -1796- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -1796- PERFORM R9999-00-FINALIZAR. */

                    R9999_00_FINALIZAR_SECTION();
                }

            }


        }

        [StopWatch]
        /*" R0470-00-LER-PROPOSTA-DB-SELECT-1 */
        public void R0470_00_LER_PROPOSTA_DB_SELECT_1()
        {
            /*" -1784- EXEC SQL SELECT NUM_PROPOSTA_SIVPF, NUM_IDENTIFICACAO, COD_EMPRESA_SIVPF, COD_PESSOA, NUM_SICOB, DATA_PROPOSTA, COD_PRODUTO_SIVPF, AGECOBR, DIA_DEBITO, OPCAOPAG, AGECTADEB, OPRCTADEB, NUMCTADEB, DIGCTADEB, PERC_DESCONTO, NRMATRVEN, AGECTAVEN, OPRCTAVEN, NUMCTAVEN, DIGCTAVEN, CGC_CONVENENTE, NOME_CONVENENTE, NRMATRCON, DTQITBCO, VAL_PAGO, AGEPGTO, VAL_TARIFA, VAL_IOF, DATA_CREDITO, VAL_COMISSAO, SIT_PROPOSTA, COD_USUARIO, CANAL_PROPOSTA, NSAS_SIVPF, ORIGEM_PROPOSTA, NSL, NSAC_SIVPF, SITUACAO_ENVIO, OPCAO_COBER, COD_PLANO INTO :DCLPROPOSTA-FIDELIZ.NUM-PROPOSTA-SIVPF, :DCLPROPOSTA-FIDELIZ.NUM-IDENTIFICACAO, :DCLPROPOSTA-FIDELIZ.COD-EMPRESA-SIVPF, :DCLPROPOSTA-FIDELIZ.COD-PESSOA, :DCLPROPOSTA-FIDELIZ.NUM-SICOB, :DCLPROPOSTA-FIDELIZ.DATA-PROPOSTA, :DCLPROPOSTA-FIDELIZ.COD-PRODUTO-SIVPF, :DCLPROPOSTA-FIDELIZ.AGECOBR, :DCLPROPOSTA-FIDELIZ.DIA-DEBITO, :DCLPROPOSTA-FIDELIZ.OPCAOPAG, :DCLPROPOSTA-FIDELIZ.AGECTADEB, :DCLPROPOSTA-FIDELIZ.OPRCTADEB, :DCLPROPOSTA-FIDELIZ.NUMCTADEB, :DCLPROPOSTA-FIDELIZ.DIGCTADEB, :DCLPROPOSTA-FIDELIZ.PERC-DESCONTO, :DCLPROPOSTA-FIDELIZ.NRMATRVEN, :DCLPROPOSTA-FIDELIZ.AGECTAVEN, :DCLPROPOSTA-FIDELIZ.OPRCTAVEN, :DCLPROPOSTA-FIDELIZ.NUMCTAVEN, :DCLPROPOSTA-FIDELIZ.DIGCTAVEN, :DCLPROPOSTA-FIDELIZ.CGC-CONVENENTE, :DCLPROPOSTA-FIDELIZ.NOME-CONVENENTE, :DCLPROPOSTA-FIDELIZ.NRMATRCON, :DCLPROPOSTA-FIDELIZ.DTQITBCO, :DCLPROPOSTA-FIDELIZ.VAL-PAGO, :DCLPROPOSTA-FIDELIZ.AGEPGTO, :DCLPROPOSTA-FIDELIZ.VAL-TARIFA, :DCLPROPOSTA-FIDELIZ.VAL-IOF, :DCLPROPOSTA-FIDELIZ.DATA-CREDITO, :DCLPROPOSTA-FIDELIZ.VAL-COMISSAO, :DCLPROPOSTA-FIDELIZ.SIT-PROPOSTA, :DCLPROPOSTA-FIDELIZ.COD-USUARIO, :DCLPROPOSTA-FIDELIZ.CANAL-PROPOSTA, :DCLPROPOSTA-FIDELIZ.NSAS-SIVPF, :DCLPROPOSTA-FIDELIZ.ORIGEM-PROPOSTA, :DCLPROPOSTA-FIDELIZ.NSL, :DCLPROPOSTA-FIDELIZ.NSAC-SIVPF, :DCLPROPOSTA-FIDELIZ.SITUACAO-ENVIO, :DCLPROPOSTA-FIDELIZ.OPCAO-COBER, :DCLPROPOSTA-FIDELIZ.COD-PLANO FROM SEGUROS.PROPOSTA_FIDELIZ WHERE NUM_PROPOSTA_SIVPF = :DCLPROPOSTA-FIDELIZ.NUM-PROPOSTA-SIVPF WITH UR END-EXEC. */

            var r0470_00_LER_PROPOSTA_DB_SELECT_1_Query1 = new R0470_00_LER_PROPOSTA_DB_SELECT_1_Query1()
            {
                NUM_PROPOSTA_SIVPF = PROPFID.DCLPROPOSTA_FIDELIZ.NUM_PROPOSTA_SIVPF.ToString(),
            };

            var executed_1 = R0470_00_LER_PROPOSTA_DB_SELECT_1_Query1.Execute(r0470_00_LER_PROPOSTA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.NUM_PROPOSTA_SIVPF, PROPFID.DCLPROPOSTA_FIDELIZ.NUM_PROPOSTA_SIVPF);
                _.Move(executed_1.NUM_IDENTIFICACAO, PROPFID.DCLPROPOSTA_FIDELIZ.NUM_IDENTIFICACAO);
                _.Move(executed_1.COD_EMPRESA_SIVPF, PROPFID.DCLPROPOSTA_FIDELIZ.COD_EMPRESA_SIVPF);
                _.Move(executed_1.COD_PESSOA, PROPFID.DCLPROPOSTA_FIDELIZ.COD_PESSOA);
                _.Move(executed_1.NUM_SICOB, PROPFID.DCLPROPOSTA_FIDELIZ.NUM_SICOB);
                _.Move(executed_1.DATA_PROPOSTA, PROPFID.DCLPROPOSTA_FIDELIZ.DATA_PROPOSTA);
                _.Move(executed_1.COD_PRODUTO_SIVPF, PROPFID.DCLPROPOSTA_FIDELIZ.COD_PRODUTO_SIVPF);
                _.Move(executed_1.AGECOBR, PROPFID.DCLPROPOSTA_FIDELIZ.AGECOBR);
                _.Move(executed_1.DIA_DEBITO, PROPFID.DCLPROPOSTA_FIDELIZ.DIA_DEBITO);
                _.Move(executed_1.OPCAOPAG, PROPFID.DCLPROPOSTA_FIDELIZ.OPCAOPAG);
                _.Move(executed_1.AGECTADEB, PROPFID.DCLPROPOSTA_FIDELIZ.AGECTADEB);
                _.Move(executed_1.OPRCTADEB, PROPFID.DCLPROPOSTA_FIDELIZ.OPRCTADEB);
                _.Move(executed_1.NUMCTADEB, PROPFID.DCLPROPOSTA_FIDELIZ.NUMCTADEB);
                _.Move(executed_1.DIGCTADEB, PROPFID.DCLPROPOSTA_FIDELIZ.DIGCTADEB);
                _.Move(executed_1.PERC_DESCONTO, PROPFID.DCLPROPOSTA_FIDELIZ.PERC_DESCONTO);
                _.Move(executed_1.NRMATRVEN, PROPFID.DCLPROPOSTA_FIDELIZ.NRMATRVEN);
                _.Move(executed_1.AGECTAVEN, PROPFID.DCLPROPOSTA_FIDELIZ.AGECTAVEN);
                _.Move(executed_1.OPRCTAVEN, PROPFID.DCLPROPOSTA_FIDELIZ.OPRCTAVEN);
                _.Move(executed_1.NUMCTAVEN, PROPFID.DCLPROPOSTA_FIDELIZ.NUMCTAVEN);
                _.Move(executed_1.DIGCTAVEN, PROPFID.DCLPROPOSTA_FIDELIZ.DIGCTAVEN);
                _.Move(executed_1.CGC_CONVENENTE, PROPFID.DCLPROPOSTA_FIDELIZ.CGC_CONVENENTE);
                _.Move(executed_1.NOME_CONVENENTE, PROPFID.DCLPROPOSTA_FIDELIZ.NOME_CONVENENTE);
                _.Move(executed_1.NRMATRCON, PROPFID.DCLPROPOSTA_FIDELIZ.NRMATRCON);
                _.Move(executed_1.DTQITBCO, PROPFID.DCLPROPOSTA_FIDELIZ.DTQITBCO);
                _.Move(executed_1.VAL_PAGO, PROPFID.DCLPROPOSTA_FIDELIZ.VAL_PAGO);
                _.Move(executed_1.AGEPGTO, PROPFID.DCLPROPOSTA_FIDELIZ.AGEPGTO);
                _.Move(executed_1.VAL_TARIFA, PROPFID.DCLPROPOSTA_FIDELIZ.VAL_TARIFA);
                _.Move(executed_1.VAL_IOF, PROPFID.DCLPROPOSTA_FIDELIZ.VAL_IOF);
                _.Move(executed_1.DATA_CREDITO, PROPFID.DCLPROPOSTA_FIDELIZ.DATA_CREDITO);
                _.Move(executed_1.VAL_COMISSAO, PROPFID.DCLPROPOSTA_FIDELIZ.VAL_COMISSAO);
                _.Move(executed_1.SIT_PROPOSTA, PROPFID.DCLPROPOSTA_FIDELIZ.SIT_PROPOSTA);
                _.Move(executed_1.COD_USUARIO, PROPFID.DCLPROPOSTA_FIDELIZ.COD_USUARIO);
                _.Move(executed_1.CANAL_PROPOSTA, PROPFID.DCLPROPOSTA_FIDELIZ.CANAL_PROPOSTA);
                _.Move(executed_1.NSAS_SIVPF, PROPFID.DCLPROPOSTA_FIDELIZ.NSAS_SIVPF);
                _.Move(executed_1.ORIGEM_PROPOSTA, PROPFID.DCLPROPOSTA_FIDELIZ.ORIGEM_PROPOSTA);
                _.Move(executed_1.NSL, PROPFID.DCLPROPOSTA_FIDELIZ.NSL);
                _.Move(executed_1.NSAC_SIVPF, PROPFID.DCLPROPOSTA_FIDELIZ.NSAC_SIVPF);
                _.Move(executed_1.SITUACAO_ENVIO, PROPFID.DCLPROPOSTA_FIDELIZ.SITUACAO_ENVIO);
                _.Move(executed_1.OPCAO_COBER, PROPFID.DCLPROPOSTA_FIDELIZ.OPCAO_COBER);
                _.Move(executed_1.COD_PLANO, PROPFID.DCLPROPOSTA_FIDELIZ.COD_PLANO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0470_SAIDA*/

        [StopWatch]
        /*" R0471-00-ATUALIZAR-TAB-PF-SECTION */
        private void R0471_00_ATUALIZAR_TAB_PF_SECTION()
        {
            /*" -1806- MOVE 'R0471-00-ATUALIZA-TAB-PF' TO PARAGRAFO. */
            _.Move("R0471-00-ATUALIZA-TAB-PF", WABEND.FILLER_10.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1808- MOVE '    ' TO COMANDO. */
            _.Move("    ", WABEND.FILLER_10.LOCALIZA_ABEND_2.COMANDO);

            /*" -1811- MOVE COD-PESSOA OF DCLPROPOSTA-FIDELIZ TO PESSOA-COD-PESSOA OF DCLPESSOA */
            _.Move(PROPFID.DCLPROPOSTA_FIDELIZ.COD_PESSOA, PESSOA.DCLPESSOA.PESSOA_COD_PESSOA);

            /*" -1812- PERFORM R0600-TRATA-END-TEL. */

            R0600_TRATA_END_TEL_SECTION();

            /*" -1812- PERFORM R0472-ATUALIZA-PROP-FIDELIZ. */

            R0472_ATUALIZA_PROP_FIDELIZ_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0471_SAIDA*/

        [StopWatch]
        /*" R0472-ATUALIZA-PROP-FIDELIZ-SECTION */
        private void R0472_ATUALIZA_PROP_FIDELIZ_SECTION()
        {
            /*" -1822- MOVE 'R0472-ATUALIZA-PROP-FIDELIZ' TO PARAGRAFO */
            _.Move("R0472-ATUALIZA-PROP-FIDELIZ", WABEND.FILLER_10.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1824- MOVE 'UPDATE' TO COMANDO */
            _.Move("UPDATE", WABEND.FILLER_10.LOCALIZA_ABEND_2.COMANDO);

            /*" -1827- MOVE 'S' TO SITUACAO-ENVIO OF DCLPROPOSTA-FIDELIZ. */
            _.Move("S", PROPFID.DCLPROPOSTA_FIDELIZ.SITUACAO_ENVIO);

            /*" -1830- MOVE R3-NUM-SICOB OF REG-PROPOSTA-SASSE TO NUM-SICOB OF DCLPROPOSTA-FIDELIZ. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_NUM_SICOB, PROPFID.DCLPROPOSTA_FIDELIZ.NUM_SICOB);

            /*" -1833- MOVE R3-SIT-PROPOSTA OF REG-PROPOSTA-SASSE TO SIT-PROPOSTA OF DCLPROPOSTA-FIDELIZ. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_SIT_PROPOSTA, PROPFID.DCLPROPOSTA_FIDELIZ.SIT_PROPOSTA);

            /*" -1836- MOVE DATA-PROPOSTA OF DCLPROPOSTA-FIDELIZ TO W-DATA-SQL. */
            _.Move(PROPFID.DCLPROPOSTA_FIDELIZ.DATA_PROPOSTA, W_DATA_SQL);

            /*" -1838- MOVE W-DIA-SQL OF W-DATA-SQL1 TO W-DIA-TRABALHO. */
            _.Move(W_DATA_SQL1.W_DIA_SQL, WAREA_AUXILIAR.W_DIA_TRABALHO);

            /*" -1840- MOVE W-MES-SQL OF W-DATA-SQL1 TO W-MES-TRABALHO. */
            _.Move(W_DATA_SQL1.W_MES_SQL, WAREA_AUXILIAR.W_MES_TRABALHO);

            /*" -1843- MOVE W-ANO-SQL OF W-DATA-SQL1 TO W-ANO-TRABALHO. */
            _.Move(W_DATA_SQL1.W_ANO_SQL, WAREA_AUXILIAR.W_ANO_TRABALHO);

            /*" -1849- MOVE W-DATA-TRABALHO TO R3-DATA-PROPOSTA OF REG-PROPOSTA-SASSE. */
            _.Move(WAREA_AUXILIAR.W_DATA_TRABALHO, LXFCT004.REG_PROPOSTA_SASSE.R3_DATA_PROPOSTA);

            /*" -1855- MOVE COD-PRODUTO-SIVPF OF DCLPROPOSTA-FIDELIZ TO R3-COD-PRODUTO OF REG-PROPOSTA-SASSE. */
            _.Move(PROPFID.DCLPROPOSTA_FIDELIZ.COD_PRODUTO_SIVPF, LXFCT004.REG_PROPOSTA_SASSE.R3_COD_PRODUTO);

            /*" -1858- MOVE AGECOBR OF DCLPROPOSTA-FIDELIZ TO R3-AGECOBR OF REG-PROPOSTA-SASSE. */
            _.Move(PROPFID.DCLPROPOSTA_FIDELIZ.AGECOBR, LXFCT004.REG_PROPOSTA_SASSE.R3_AGECOBR);

            /*" -1861- MOVE R3-DIA-DEBITO OF REG-PROPOSTA-SASSE TO DIA-DEBITO OF DCLPROPOSTA-FIDELIZ. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_DIA_DEBITO, PROPFID.DCLPROPOSTA_FIDELIZ.DIA_DEBITO);

            /*" -1864- MOVE R3-OPCAOPAG OF REG-PROPOSTA-SASSE TO OPCAOPAG OF DCLPROPOSTA-FIDELIZ. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_OPCAOPAG, PROPFID.DCLPROPOSTA_FIDELIZ.OPCAOPAG);

            /*" -1867- MOVE R3-AGECTADEB OF REG-PROPOSTA-SASSE TO AGECTADEB OF DCLPROPOSTA-FIDELIZ. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_CONTA_DEBITO.R3_AGECTADEB, PROPFID.DCLPROPOSTA_FIDELIZ.AGECTADEB);

            /*" -1870- MOVE R3-OPRCTADEB OF REG-PROPOSTA-SASSE TO OPRCTADEB OF DCLPROPOSTA-FIDELIZ. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_CONTA_DEBITO.R3_OPRCTADEB, PROPFID.DCLPROPOSTA_FIDELIZ.OPRCTADEB);

            /*" -1873- MOVE R3-NUMCTADEB OF REG-PROPOSTA-SASSE TO NUMCTADEB OF DCLPROPOSTA-FIDELIZ. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_CONTA_DEBITO.R3_NUMCTADEB, PROPFID.DCLPROPOSTA_FIDELIZ.NUMCTADEB);

            /*" -1876- MOVE R3-DIGCTADEB OF REG-PROPOSTA-SASSE TO DIGCTADEB OF DCLPROPOSTA-FIDELIZ. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_CONTA_DEBITO.R3_DIGCTADEB, PROPFID.DCLPROPOSTA_FIDELIZ.DIGCTADEB);

            /*" -1879- MOVE R3-PCT-DESCONTO OF REG-PROPOSTA-SASSE TO PERC-DESCONTO OF DCLPROPOSTA-FIDELIZ. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_PCT_DESCONTO, PROPFID.DCLPROPOSTA_FIDELIZ.PERC_DESCONTO);

            /*" -1882- MOVE R3-NRMATRVEN OF REG-PROPOSTA-SASSE TO NRMATRVEN OF DCLPROPOSTA-FIDELIZ. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_NRMATRVEN, PROPFID.DCLPROPOSTA_FIDELIZ.NRMATRVEN);

            /*" -1888- MOVE ZEROS TO AGECTAVEN OF DCLPROPOSTA-FIDELIZ OPRCTAVEN OF DCLPROPOSTA-FIDELIZ NUMCTAVEN OF DCLPROPOSTA-FIDELIZ DIGCTAVEN OF DCLPROPOSTA-FIDELIZ. */
            _.Move(0, PROPFID.DCLPROPOSTA_FIDELIZ.AGECTAVEN, PROPFID.DCLPROPOSTA_FIDELIZ.OPRCTAVEN, PROPFID.DCLPROPOSTA_FIDELIZ.NUMCTAVEN, PROPFID.DCLPROPOSTA_FIDELIZ.DIGCTAVEN);

            /*" -1891- MOVE R3-CGC-CONVENENTE OF REG-PROPOSTA-SASSE TO CGC-CONVENENTE OF DCLPROPOSTA-FIDELIZ. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_CGC_CONVENENTE, PROPFID.DCLPROPOSTA_FIDELIZ.CGC_CONVENENTE);

            /*" -1894- MOVE R3-NOME-CONVENENTE OF REG-PROPOSTA-SASSE TO NOME-CONVENENTE OF DCLPROPOSTA-FIDELIZ. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_NOME_CONVENENTE, PROPFID.DCLPROPOSTA_FIDELIZ.NOME_CONVENENTE);

            /*" -1897- MOVE ZEROS TO NRMATRCON OF DCLPROPOSTA-FIDELIZ. */
            _.Move(0, PROPFID.DCLPROPOSTA_FIDELIZ.NRMATRCON);

            /*" -1900- MOVE R3-DTQITBCO OF REG-PROPOSTA-SASSE TO W-DATA-TRABALHO. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_DTQITBCO, WAREA_AUXILIAR.W_DATA_TRABALHO);

            /*" -1902- MOVE W-DIA-TRABALHO TO W-DIA-SQL OF W-DATA-SQL1. */
            _.Move(WAREA_AUXILIAR.W_DIA_TRABALHO, W_DATA_SQL1.W_DIA_SQL);

            /*" -1904- MOVE W-MES-TRABALHO TO W-MES-SQL OF W-DATA-SQL1. */
            _.Move(WAREA_AUXILIAR.W_MES_TRABALHO, W_DATA_SQL1.W_MES_SQL);

            /*" -1907- MOVE W-ANO-TRABALHO TO W-ANO-SQL OF W-DATA-SQL1. */
            _.Move(WAREA_AUXILIAR.W_ANO_TRABALHO, W_DATA_SQL1.W_ANO_SQL);

            /*" -1911- MOVE '-' TO W-BARRA1 OF W-DATA-SQL1, W-BARRA2 OF W-DATA-SQL1. */
            _.Move("-", W_DATA_SQL1.W_BARRA1_1);
            _.Move("-", W_DATA_SQL1.W_BARRA2_1);


            /*" -1914- MOVE W-DATA-SQL TO DTQITBCO OF DCLPROPOSTA-FIDELIZ. */
            _.Move(W_DATA_SQL, PROPFID.DCLPROPOSTA_FIDELIZ.DTQITBCO);

            /*" -1917- MOVE R3-VAL-PAGO OF REG-PROPOSTA-SASSE TO VAL-PAGO OF DCLPROPOSTA-FIDELIZ. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_VAL_PAGO, PROPFID.DCLPROPOSTA_FIDELIZ.VAL_PAGO);

            /*" -1920- MOVE R3-AGEPGTO OF REG-PROPOSTA-SASSE TO AGEPGTO OF DCLPROPOSTA-FIDELIZ. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_AGEPGTO, PROPFID.DCLPROPOSTA_FIDELIZ.AGEPGTO);

            /*" -1921- IF R3-DATA-CREDITO OF REG-PROPOSTA-SASSE EQUAL SPACES */

            if (LXFCT004.REG_PROPOSTA_SASSE.R3_DATA_CREDITO.IsEmpty())
            {

                /*" -1924- MOVE 01010001 TO R3-DATA-CREDITO OF REG-PROPOSTA-SASSE. */
                _.Move(01010001, LXFCT004.REG_PROPOSTA_SASSE.R3_DATA_CREDITO);
            }


            /*" -1927- MOVE R3-DATA-CREDITO OF REG-PROPOSTA-SASSE TO W-DATA-TRABALHO. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_DATA_CREDITO, WAREA_AUXILIAR.W_DATA_TRABALHO);

            /*" -1929- MOVE W-DIA-TRABALHO TO W-DIA-SQL OF W-DATA-SQL1. */
            _.Move(WAREA_AUXILIAR.W_DIA_TRABALHO, W_DATA_SQL1.W_DIA_SQL);

            /*" -1931- MOVE W-MES-TRABALHO TO W-MES-SQL OF W-DATA-SQL1. */
            _.Move(WAREA_AUXILIAR.W_MES_TRABALHO, W_DATA_SQL1.W_MES_SQL);

            /*" -1934- MOVE W-ANO-TRABALHO TO W-ANO-SQL OF W-DATA-SQL1. */
            _.Move(WAREA_AUXILIAR.W_ANO_TRABALHO, W_DATA_SQL1.W_ANO_SQL);

            /*" -1938- MOVE '-' TO W-BARRA1 OF W-DATA-SQL1, W-BARRA2 OF W-DATA-SQL1. */
            _.Move("-", W_DATA_SQL1.W_BARRA1_1);
            _.Move("-", W_DATA_SQL1.W_BARRA2_1);


            /*" -1941- MOVE W-DATA-SQL TO DATA-CREDITO OF DCLPROPOSTA-FIDELIZ. */
            _.Move(W_DATA_SQL, PROPFID.DCLPROPOSTA_FIDELIZ.DATA_CREDITO);

            /*" -1947- MOVE R3-VAL-COMISSAO OF REG-PROPOSTA-SASSE TO VAL-COMISSAO OF DCLPROPOSTA-FIDELIZ. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_VAL_COMISSAO, PROPFID.DCLPROPOSTA_FIDELIZ.VAL_COMISSAO);

            /*" -1950- MOVE 'PF0641B' TO COD-USUARIO OF DCLPROPOSTA-FIDELIZ. */
            _.Move("PF0641B", PROPFID.DCLPROPOSTA_FIDELIZ.COD_USUARIO);

            /*" -1953- MOVE W-QTD-MOV-MR-3 TO NSL OF DCLPROPOSTA-FIDELIZ. */
            _.Move(WAREA_AUXILIAR.W_QTD_MOV_MR_3, PROPFID.DCLPROPOSTA_FIDELIZ.NSL);

            /*" -1956- MOVE RH-NSAS OF REG-HEADER TO NSAC-SIVPF OF DCLPROPOSTA-FIDELIZ. */
            _.Move(LXFPF990.REG_HEADER.RH_NSAS, PROPFID.DCLPROPOSTA_FIDELIZ.NSAC_SIVPF);

            /*" -1959- MOVE R3-OPCAO-COBER OF REG-PROPOSTA-SASSE TO OPCAO-COBER OF DCLPROPOSTA-FIDELIZ. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_OPCAO_COBER, PROPFID.DCLPROPOSTA_FIDELIZ.OPCAO_COBER);

            /*" -1962- MOVE R3-COD-PLANO OF REG-PROPOSTA-SASSE TO COD-PLANO OF DCLPROPOSTA-FIDELIZ. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_COD_PLANO, PROPFID.DCLPROPOSTA_FIDELIZ.COD_PLANO);

            /*" -2031- PERFORM R0472_ATUALIZA_PROP_FIDELIZ_DB_UPDATE_1 */

            R0472_ATUALIZA_PROP_FIDELIZ_DB_UPDATE_1();

            /*" -2034- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -2035- DISPLAY 'PF0641B - FIM ANORMAL' */
                _.Display($"PF0641B - FIM ANORMAL");

                /*" -2036- DISPLAY '          ERRO UPDATE TABELA PROPOSTA FIDELIZ' */
                _.Display($"          ERRO UPDATE TABELA PROPOSTA FIDELIZ");

                /*" -2038- DISPLAY '          NUMERO PROPOSTA...............  ' NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ */
                _.Display($"          NUMERO PROPOSTA...............  {PROPFID.DCLPROPOSTA_FIDELIZ.NUM_PROPOSTA_SIVPF}");

                /*" -2040- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -2041- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -2041- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R0472-ATUALIZA-PROP-FIDELIZ-DB-UPDATE-1 */
        public void R0472_ATUALIZA_PROP_FIDELIZ_DB_UPDATE_1()
        {
            /*" -2031- EXEC SQL UPDATE SEGUROS.PROPOSTA_FIDELIZ SET NUM_SICOB = :DCLPROPOSTA-FIDELIZ.NUM-SICOB , DATA_PROPOSTA = :DCLPROPOSTA-FIDELIZ.DATA-PROPOSTA , COD_PRODUTO_SIVPF = :DCLPROPOSTA-FIDELIZ.COD-PRODUTO-SIVPF , AGECOBR = :DCLPROPOSTA-FIDELIZ.AGECOBR , DIA_DEBITO = :DCLPROPOSTA-FIDELIZ.DIA-DEBITO , OPCAOPAG = :DCLPROPOSTA-FIDELIZ.OPCAOPAG , AGECTADEB = :DCLPROPOSTA-FIDELIZ.AGECTADEB , OPRCTADEB = :DCLPROPOSTA-FIDELIZ.OPRCTADEB , NUMCTADEB = :DCLPROPOSTA-FIDELIZ.NUMCTADEB , DIGCTADEB = :DCLPROPOSTA-FIDELIZ.DIGCTADEB , PERC_DESCONTO = :DCLPROPOSTA-FIDELIZ.PERC-DESCONTO , NRMATRVEN = :DCLPROPOSTA-FIDELIZ.NRMATRVEN , AGECTAVEN = :DCLPROPOSTA-FIDELIZ.AGECTAVEN , OPRCTAVEN = :DCLPROPOSTA-FIDELIZ.OPRCTAVEN , NUMCTAVEN = :DCLPROPOSTA-FIDELIZ.NUMCTAVEN , DIGCTAVEN = :DCLPROPOSTA-FIDELIZ.DIGCTAVEN , CGC_CONVENENTE = :DCLPROPOSTA-FIDELIZ.CGC-CONVENENTE , NOME_CONVENENTE = :DCLPROPOSTA-FIDELIZ.NOME-CONVENENTE , NRMATRCON = :DCLPROPOSTA-FIDELIZ.NRMATRCON , DTQITBCO = :DCLPROPOSTA-FIDELIZ.DTQITBCO , VAL_PAGO = :DCLPROPOSTA-FIDELIZ.VAL-PAGO , AGEPGTO = :DCLPROPOSTA-FIDELIZ.AGEPGTO , DATA_CREDITO = :DCLPROPOSTA-FIDELIZ.DATA-CREDITO , SIT_PROPOSTA = :DCLPROPOSTA-FIDELIZ.SIT-PROPOSTA , COD_USUARIO = :DCLPROPOSTA-FIDELIZ.COD-USUARIO , TIMESTAMP = CURRENT TIMESTAMP , NSL = :DCLPROPOSTA-FIDELIZ.NSL , NSAC_SIVPF = :DCLPROPOSTA-FIDELIZ.NSAC-SIVPF , SITUACAO_ENVIO = :DCLPROPOSTA-FIDELIZ.SITUACAO-ENVIO , OPCAO_COBER = :DCLPROPOSTA-FIDELIZ.OPCAO-COBER , COD_PLANO = :DCLPROPOSTA-FIDELIZ.COD-PLANO WHERE NUM_PROPOSTA_SIVPF = :DCLPROPOSTA-FIDELIZ.NUM-PROPOSTA-SIVPF END-EXEC. */

            var r0472_ATUALIZA_PROP_FIDELIZ_DB_UPDATE_1_Update1 = new R0472_ATUALIZA_PROP_FIDELIZ_DB_UPDATE_1_Update1()
            {
                COD_PRODUTO_SIVPF = PROPFID.DCLPROPOSTA_FIDELIZ.COD_PRODUTO_SIVPF.ToString(),
                NOME_CONVENENTE = PROPFID.DCLPROPOSTA_FIDELIZ.NOME_CONVENENTE.ToString(),
                CGC_CONVENENTE = PROPFID.DCLPROPOSTA_FIDELIZ.CGC_CONVENENTE.ToString(),
                SITUACAO_ENVIO = PROPFID.DCLPROPOSTA_FIDELIZ.SITUACAO_ENVIO.ToString(),
                DATA_PROPOSTA = PROPFID.DCLPROPOSTA_FIDELIZ.DATA_PROPOSTA.ToString(),
                PERC_DESCONTO = PROPFID.DCLPROPOSTA_FIDELIZ.PERC_DESCONTO.ToString(),
                DATA_CREDITO = PROPFID.DCLPROPOSTA_FIDELIZ.DATA_CREDITO.ToString(),
                SIT_PROPOSTA = PROPFID.DCLPROPOSTA_FIDELIZ.SIT_PROPOSTA.ToString(),
                COD_USUARIO = PROPFID.DCLPROPOSTA_FIDELIZ.COD_USUARIO.ToString(),
                OPCAO_COBER = PROPFID.DCLPROPOSTA_FIDELIZ.OPCAO_COBER.ToString(),
                DIA_DEBITO = PROPFID.DCLPROPOSTA_FIDELIZ.DIA_DEBITO.ToString(),
                NSAC_SIVPF = PROPFID.DCLPROPOSTA_FIDELIZ.NSAC_SIVPF.ToString(),
                NUM_SICOB = PROPFID.DCLPROPOSTA_FIDELIZ.NUM_SICOB.ToString(),
                AGECTADEB = PROPFID.DCLPROPOSTA_FIDELIZ.AGECTADEB.ToString(),
                OPRCTADEB = PROPFID.DCLPROPOSTA_FIDELIZ.OPRCTADEB.ToString(),
                NUMCTADEB = PROPFID.DCLPROPOSTA_FIDELIZ.NUMCTADEB.ToString(),
                DIGCTADEB = PROPFID.DCLPROPOSTA_FIDELIZ.DIGCTADEB.ToString(),
                NRMATRVEN = PROPFID.DCLPROPOSTA_FIDELIZ.NRMATRVEN.ToString(),
                AGECTAVEN = PROPFID.DCLPROPOSTA_FIDELIZ.AGECTAVEN.ToString(),
                OPRCTAVEN = PROPFID.DCLPROPOSTA_FIDELIZ.OPRCTAVEN.ToString(),
                NUMCTAVEN = PROPFID.DCLPROPOSTA_FIDELIZ.NUMCTAVEN.ToString(),
                DIGCTAVEN = PROPFID.DCLPROPOSTA_FIDELIZ.DIGCTAVEN.ToString(),
                NRMATRCON = PROPFID.DCLPROPOSTA_FIDELIZ.NRMATRCON.ToString(),
                COD_PLANO = PROPFID.DCLPROPOSTA_FIDELIZ.COD_PLANO.ToString(),
                OPCAOPAG = PROPFID.DCLPROPOSTA_FIDELIZ.OPCAOPAG.ToString(),
                DTQITBCO = PROPFID.DCLPROPOSTA_FIDELIZ.DTQITBCO.ToString(),
                VAL_PAGO = PROPFID.DCLPROPOSTA_FIDELIZ.VAL_PAGO.ToString(),
                AGECOBR = PROPFID.DCLPROPOSTA_FIDELIZ.AGECOBR.ToString(),
                AGEPGTO = PROPFID.DCLPROPOSTA_FIDELIZ.AGEPGTO.ToString(),
                NSL = PROPFID.DCLPROPOSTA_FIDELIZ.NSL.ToString(),
                NUM_PROPOSTA_SIVPF = PROPFID.DCLPROPOSTA_FIDELIZ.NUM_PROPOSTA_SIVPF.ToString(),
            };

            R0472_ATUALIZA_PROP_FIDELIZ_DB_UPDATE_1_Update1.Execute(r0472_ATUALIZA_PROP_FIDELIZ_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0472_SAIDA*/

        [StopWatch]
        /*" R0480-00-GERAR-TAB-PF-SECTION */
        private void R0480_00_GERAR_TAB_PF_SECTION()
        {
            /*" -2051- MOVE 'R0480-00-GERAR-TAB-PF' TO PARAGRAFO. */
            _.Move("R0480-00-GERAR-TAB-PF", WABEND.FILLER_10.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2053- MOVE '    ' TO COMANDO. */
            _.Move("    ", WABEND.FILLER_10.LOCALIZA_ABEND_2.COMANDO);

            /*" -2054- PERFORM R0500-TRATA-CLIENTE */

            R0500_TRATA_CLIENTE_SECTION();

            /*" -2055- PERFORM R0600-TRATA-END-TEL */

            R0600_TRATA_END_TEL_SECTION();

            /*" -2055- PERFORM R0700-TRATA-PROPOSTA. */

            R0700_TRATA_PROPOSTA_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0480_SAIDA*/

        [StopWatch]
        /*" R0500-TRATA-CLIENTE-SECTION */
        private void R0500_TRATA_CLIENTE_SECTION()
        {
            /*" -2065- MOVE 'R0500-TRATA-CLIENTE' TO PARAGRAFO. */
            _.Move("R0500-TRATA-CLIENTE", WABEND.FILLER_10.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2075- MOVE '    ' TO COMANDO. */
            _.Move("    ", WABEND.FILLER_10.LOCALIZA_ABEND_2.COMANDO);

            /*" -2077- ADD 1 TO W-QTD-MOV-MR-1 */
            WAREA_AUXILIAR.W_QTD_MOV_MR_1.Value = WAREA_AUXILIAR.W_QTD_MOV_MR_1 + 1;

            /*" -2079- IF R1-DATA-NASCIMENTO OF REG-CLIENTES EQUAL ZEROS OR R1-DATA-NASCIMENTO OF REG-CLIENTES EQUAL 99999999 */

            if (LBFPF011.REG_CLIENTES.R1_DATA_NASCIMENTO == 00 || LBFPF011.REG_CLIENTES.R1_DATA_NASCIMENTO == 99999999)
            {

                /*" -2081- MOVE 01010001 TO R1-DATA-NASCIMENTO OF REG-CLIENTES. */
                _.Move(01010001, LBFPF011.REG_CLIENTES.R1_DATA_NASCIMENTO);
            }


            /*" -2082- IF R1-TIPO-PESSOA OF REG-CLIENTES EQUAL 1 */

            if (LBFPF011.REG_CLIENTES.R1_TIPO_PESSOA == 1)
            {

                /*" -2083- PERFORM R0505-LER-PESSOA-FISICA */

                R0505_LER_PESSOA_FISICA_SECTION();

                /*" -2084- ELSE */
            }
            else
            {


                /*" -2086- PERFORM R0510-LER-PESSOA-JURIDICA. */

                R0510_LER_PESSOA_JURIDICA_SECTION();
            }


            /*" -2087- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -2088- PERFORM R0515-INCLUIR-TAB-CORPORATIVAS */

                R0515_INCLUIR_TAB_CORPORATIVAS_SECTION();

                /*" -2089- ELSE */
            }
            else
            {


                /*" -2090- IF SQLCODE EQUAL 00 */

                if (DB.SQLCODE == 00)
                {

                    /*" -2093- PERFORM R0550-LER-TAB-CORPORATIVAS */

                    R0550_LER_TAB_CORPORATIVAS_SECTION();

                    /*" -2094- PERFORM R0535-INCLUIR-END-EMAIL */

                    R0535_INCLUIR_END_EMAIL_SECTION();

                    /*" -2095- END-IF */
                }


                /*" -2095- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0500_SAIDA*/

        [StopWatch]
        /*" R0505-LER-PESSOA-FISICA-SECTION */
        private void R0505_LER_PESSOA_FISICA_SECTION()
        {
            /*" -2105- MOVE 'R0505-LER-PESSOA-FISICA' TO PARAGRAFO. */
            _.Move("R0505-LER-PESSOA-FISICA", WABEND.FILLER_10.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2107- MOVE 'SELECT PESSOA_FISICA' TO COMANDO. */
            _.Move("SELECT PESSOA_FISICA", WABEND.FILLER_10.LOCALIZA_ABEND_2.COMANDO);

            /*" -2110- MOVE R1-CGC-CPF OF REG-CLIENTES TO CPF OF DCLPESSOA-FISICA. */
            _.Move(LBFPF011.REG_CLIENTES.R1_CGC_CPF, PESFIS.DCLPESSOA_FISICA.CPF);

            /*" -2113- MOVE R1-DATA-NASCIMENTO OF REG-CLIENTES TO W-DATA-NASCIMENTO. */
            _.Move(LBFPF011.REG_CLIENTES.R1_DATA_NASCIMENTO, W_DATA_NASCIMENTO);

            /*" -2116- MOVE W-DIA-NASCIMENTO TO W-DIA-SQL OF W-DATA-SQL1. */
            _.Move(W_DIA_NASCIMENTO, W_DATA_SQL1.W_DIA_SQL);

            /*" -2119- MOVE W-MES-NASCIMENTO TO W-MES-SQL OF W-DATA-SQL1. */
            _.Move(W_MES_NASCIMENTO, W_DATA_SQL1.W_MES_SQL);

            /*" -2122- MOVE W-ANO-NASCIMENTO TO W-ANO-SQL OF W-DATA-SQL1. */
            _.Move(W_ANO_NASCIMENTO, W_DATA_SQL1.W_ANO_SQL);

            /*" -2126- MOVE '-' TO W-BARRA1 OF W-DATA-SQL1, W-BARRA2 OF W-DATA-SQL1. */
            _.Move("-", W_DATA_SQL1.W_BARRA1_1);
            _.Move("-", W_DATA_SQL1.W_BARRA2_1);


            /*" -2129- MOVE W-DATA-SQL TO DATA-NASCIMENTO OF DCLPESSOA-FISICA. */
            _.Move(W_DATA_SQL, PESFIS.DCLPESSOA_FISICA.DATA_NASCIMENTO);

            /*" -2130- IF R1-IDE-SEXO OF REG-CLIENTES EQUAL 1 */

            if (LBFPF011.REG_CLIENTES.R1_IDE_SEXO == 1)
            {

                /*" -2132- MOVE 'M' TO SEXO OF DCLPESSOA-FISICA */
                _.Move("M", PESFIS.DCLPESSOA_FISICA.SEXO);

                /*" -2133- ELSE */
            }
            else
            {


                /*" -2136- MOVE 'F' TO SEXO OF DCLPESSOA-FISICA. */
                _.Move("F", PESFIS.DCLPESSOA_FISICA.SEXO);
            }


            /*" -2168- PERFORM R0505_LER_PESSOA_FISICA_DB_SELECT_1 */

            R0505_LER_PESSOA_FISICA_DB_SELECT_1();

            /*" -2171- IF SQLCODE NOT EQUAL 00 AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -2172- DISPLAY 'PF0641B - FIM ANORMAL' */
                _.Display($"PF0641B - FIM ANORMAL");

                /*" -2173- DISPLAY '          ERRO NO ACESSO A PESSOA-FISICA  ' */
                _.Display($"          ERRO NO ACESSO A PESSOA-FISICA  ");

                /*" -2175- DISPLAY '          NUMERO DA PROPOSTA............  ' R1-NUM-PROPOSTA OF REG-CLIENTES */
                _.Display($"          NUMERO DA PROPOSTA............  {LBFPF011.REG_CLIENTES.R1_NUM_PROPOSTA}");

                /*" -2177- DISPLAY '          CPF...........................  ' CPF OF DCLPESSOA-FISICA */
                _.Display($"          CPF...........................  {PESFIS.DCLPESSOA_FISICA.CPF}");

                /*" -2179- DISPLAY '          DATA NASCIMENTO...............  ' DATA-NASCIMENTO OF DCLPESSOA-FISICA */
                _.Display($"          DATA NASCIMENTO...............  {PESFIS.DCLPESSOA_FISICA.DATA_NASCIMENTO}");

                /*" -2181- DISPLAY '          SEXO..........................  ' SEXO OF DCLPESSOA-FISICA */
                _.Display($"          SEXO..........................  {PESFIS.DCLPESSOA_FISICA.SEXO}");

                /*" -2183- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -2184- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -2186- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


            /*" -2187- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -2188- IF COD-CBO OF DCLPESSOA-FISICA EQUAL ZEROS */

                if (PESFIS.DCLPESSOA_FISICA.COD_CBO == 00)
                {

                    /*" -2190- IF R1-COD-CBO OF REG-CLIENTES GREATER ZEROS */

                    if (LBFPF011.REG_CLIENTES.R1_COD_CBO > 00)
                    {

                        /*" -2193- MOVE R1-COD-CBO OF REG-CLIENTES TO COD-CBO OF DCLPESSOA-FISICA */
                        _.Move(LBFPF011.REG_CLIENTES.R1_COD_CBO, PESFIS.DCLPESSOA_FISICA.COD_CBO);

                        /*" -2197- PERFORM R0505_LER_PESSOA_FISICA_DB_UPDATE_1 */

                        R0505_LER_PESSOA_FISICA_DB_UPDATE_1();

                        /*" -2200- IF SQLCODE NOT EQUAL 00 */

                        if (DB.SQLCODE != 00)
                        {

                            /*" -2201- DISPLAY 'PF0600B - FIM ANORMAL' */
                            _.Display($"PF0600B - FIM ANORMAL");

                            /*" -2202- DISPLAY '          PROBLEMA UPDATE PESSOA-FISICA' */
                            _.Display($"          PROBLEMA UPDATE PESSOA-FISICA");

                            /*" -2204- DISPLAY '          NUMERO DA PROPOSTA............  ' R1-NUM-PROPOSTA OF REG-CLIENTES */
                            _.Display($"          NUMERO DA PROPOSTA............  {LBFPF011.REG_CLIENTES.R1_NUM_PROPOSTA}");

                            /*" -2206- DISPLAY '          COD-PESSOA....................  ' COD-CBO OF DCLPESSOA-FISICA */
                            _.Display($"          COD-PESSOA....................  {PESFIS.DCLPESSOA_FISICA.COD_CBO}");

                            /*" -2208- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                            _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                            /*" -2209- PERFORM R9988-00-FECHAR-ARQUIVOS */

                            R9988_00_FECHAR_ARQUIVOS_SECTION();

                            /*" -2210- PERFORM R9999-00-FINALIZAR */

                            R9999_00_FINALIZAR_SECTION();

                            /*" -2211- END-IF */
                        }


                        /*" -2212- END-IF */
                    }


                    /*" -2216- IF R1-DATA-EXPEDICAO-RG OF REG-CLIENTES NUMERIC AND R1-DATA-EXPEDICAO-RG OF REG-CLIENTES > ZEROS AND R1-DATA-EXPEDICAO-RG OF REG-CLIENTES NOT EQUAL 01010001 */

                    if (LBFPF011.REG_CLIENTES.R1_DATA_EXPEDICAO_RG.IsNumeric() && LBFPF011.REG_CLIENTES.R1_DATA_EXPEDICAO_RG > 00 && LBFPF011.REG_CLIENTES.R1_DATA_EXPEDICAO_RG != 01010001)
                    {

                        /*" -2217- IF VIND-DTEXPEDI LESS ZERO */

                        if (VIND_DTEXPEDI < 00)
                        {

                            /*" -2220- MOVE R1-DATA-EXPEDICAO-RG OF REG-CLIENTES TO W-DATA-TRABALHO */
                            _.Move(LBFPF011.REG_CLIENTES.R1_DATA_EXPEDICAO_RG, WAREA_AUXILIAR.W_DATA_TRABALHO);

                            /*" -2222- MOVE W-DIA-TRABALHO TO W-DIA-SQL OF W-DATA-SQL1 */
                            _.Move(WAREA_AUXILIAR.W_DIA_TRABALHO, W_DATA_SQL1.W_DIA_SQL);

                            /*" -2224- MOVE W-MES-TRABALHO TO W-MES-SQL OF W-DATA-SQL1 */
                            _.Move(WAREA_AUXILIAR.W_MES_TRABALHO, W_DATA_SQL1.W_MES_SQL);

                            /*" -2227- MOVE W-ANO-TRABALHO TO W-ANO-SQL OF W-DATA-SQL1 */
                            _.Move(WAREA_AUXILIAR.W_ANO_TRABALHO, W_DATA_SQL1.W_ANO_SQL);

                            /*" -2231- MOVE '-' TO W-BARRA1 OF W-DATA-SQL1, W-BARRA2 OF W-DATA-SQL1 */
                            _.Move("-", W_DATA_SQL1.W_BARRA1_1);
                            _.Move("-", W_DATA_SQL1.W_BARRA2_1);


                            /*" -2234- MOVE W-DATA-SQL TO DATA-EXPEDICAO OF DCLPESSOA-FISICA */
                            _.Move(W_DATA_SQL, PESFIS.DCLPESSOA_FISICA.DATA_EXPEDICAO);

                            /*" -2239- PERFORM R0505_LER_PESSOA_FISICA_DB_UPDATE_2 */

                            R0505_LER_PESSOA_FISICA_DB_UPDATE_2();

                            /*" -2242- IF SQLCODE NOT EQUAL 00 */

                            if (DB.SQLCODE != 00)
                            {

                                /*" -2243- DISPLAY 'PF0001B - FIM ANORMAL' */
                                _.Display($"PF0001B - FIM ANORMAL");

                                /*" -2244- DISPLAY '          PROBLEMA UPDATE PESSOA-FISICA' */
                                _.Display($"          PROBLEMA UPDATE PESSOA-FISICA");

                                /*" -2246- DISPLAY '          NUMERO DA PROPOSTA............  ' R1-NUM-PROPOSTA OF REG-CLIENTES */
                                _.Display($"          NUMERO DA PROPOSTA............  {LBFPF011.REG_CLIENTES.R1_NUM_PROPOSTA}");

                                /*" -2248- DISPLAY '          COD-PESSOA....................  ' COD-CBO OF DCLPESSOA-FISICA */
                                _.Display($"          COD-PESSOA....................  {PESFIS.DCLPESSOA_FISICA.COD_CBO}");

                                /*" -2250- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                                /*" -2251- PERFORM R9988-00-FECHAR-ARQUIVOS */

                                R9988_00_FECHAR_ARQUIVOS_SECTION();

                                /*" -2252- PERFORM R9999-00-FINALIZAR */

                                R9999_00_FINALIZAR_SECTION();

                                /*" -2252- END-IF. */
                            }

                        }

                    }

                }

            }


        }

        [StopWatch]
        /*" R0505-LER-PESSOA-FISICA-DB-SELECT-1 */
        public void R0505_LER_PESSOA_FISICA_DB_SELECT_1()
        {
            /*" -2168- EXEC SQL SELECT COD_PESSOA, CPF, DATA_NASCIMENTO, SEXO, TIPO_IDENT_SIVPF, NUM_IDENTIDADE, ORGAO_EXPEDIDOR, UF_EXPEDIDORA, DATA_EXPEDICAO, COD_CBO, COD_USUARIO, ESTADO_CIVIL, TIMESTAMP INTO :DCLPESSOA-FISICA.COD-PESSOA:VIND-COD-PESSOA, :DCLPESSOA-FISICA.CPF:VIND-CPF, :DCLPESSOA-FISICA.DATA-NASCIMENTO:VIND-DTNASCI, :DCLPESSOA-FISICA.SEXO:VIND-SEXO, :DCLPESSOA-FISICA.TIPO-IDENT-SIVPF:VIND-TP-IDENT, :DCLPESSOA-FISICA.NUM-IDENTIDADE:VIND-NUM-IDENT, :DCLPESSOA-FISICA.ORGAO-EXPEDIDOR:VIND-ORGAO-EXP, :DCLPESSOA-FISICA.UF-EXPEDIDORA:VIND-UF-EXP, :DCLPESSOA-FISICA.DATA-EXPEDICAO:VIND-DTEXPEDI, :DCLPESSOA-FISICA.COD-CBO:VIND-COD-CBO, :DCLPESSOA-FISICA.COD-USUARIO:VIND-COD-USUR, :DCLPESSOA-FISICA.ESTADO-CIVIL, :DCLPESSOA-FISICA.TIMESTAMP:VIND-TIMESTAMP FROM SEGUROS.PESSOA_FISICA WHERE CPF = :DCLPESSOA-FISICA.CPF AND DATA_NASCIMENTO = :DCLPESSOA-FISICA.DATA-NASCIMENTO AND SEXO = :DCLPESSOA-FISICA.SEXO WITH UR END-EXEC. */

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

        [StopWatch]
        /*" R0505-LER-PESSOA-FISICA-DB-UPDATE-1 */
        public void R0505_LER_PESSOA_FISICA_DB_UPDATE_1()
        {
            /*" -2197- EXEC SQL UPDATE SEGUROS.PESSOA_FISICA SET COD_CBO = :DCLPESSOA-FISICA.COD-CBO WHERE COD_PESSOA = :DCLPESSOA-FISICA.COD-PESSOA END-EXEC */

            var r0505_LER_PESSOA_FISICA_DB_UPDATE_1_Update1 = new R0505_LER_PESSOA_FISICA_DB_UPDATE_1_Update1()
            {
                COD_CBO = PESFIS.DCLPESSOA_FISICA.COD_CBO.ToString(),
                COD_PESSOA = PESFIS.DCLPESSOA_FISICA.COD_PESSOA.ToString(),
            };

            R0505_LER_PESSOA_FISICA_DB_UPDATE_1_Update1.Execute(r0505_LER_PESSOA_FISICA_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0505_SAIDA*/

        [StopWatch]
        /*" R0505-LER-PESSOA-FISICA-DB-UPDATE-2 */
        public void R0505_LER_PESSOA_FISICA_DB_UPDATE_2()
        {
            /*" -2239- EXEC SQL UPDATE SEGUROS.PESSOA_FISICA SET DATA_EXPEDICAO = :DCLPESSOA-FISICA.DATA-EXPEDICAO WHERE COD_PESSOA = :DCLPESSOA-FISICA.COD-PESSOA END-EXEC */

            var r0505_LER_PESSOA_FISICA_DB_UPDATE_2_Update1 = new R0505_LER_PESSOA_FISICA_DB_UPDATE_2_Update1()
            {
                DATA_EXPEDICAO = PESFIS.DCLPESSOA_FISICA.DATA_EXPEDICAO.ToString(),
                COD_PESSOA = PESFIS.DCLPESSOA_FISICA.COD_PESSOA.ToString(),
            };

            R0505_LER_PESSOA_FISICA_DB_UPDATE_2_Update1.Execute(r0505_LER_PESSOA_FISICA_DB_UPDATE_2_Update1);

        }

        [StopWatch]
        /*" R0510-LER-PESSOA-JURIDICA-SECTION */
        private void R0510_LER_PESSOA_JURIDICA_SECTION()
        {
            /*" -2262- MOVE 'R0510-LER-PESSOA-JURIDICA' TO PARAGRAFO. */
            _.Move("R0510-LER-PESSOA-JURIDICA", WABEND.FILLER_10.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2264- MOVE 'SELECT' TO COMANDO. */
            _.Move("SELECT", WABEND.FILLER_10.LOCALIZA_ABEND_2.COMANDO);

            /*" -2267- MOVE R1-CGC-CPF OF REG-CLIENTES TO CGC OF DCLPESSOA-JURIDICA. */
            _.Move(LBFPF011.REG_CLIENTES.R1_CGC_CPF, PESJUR.DCLPESSOA_JURIDICA.CGC);

            /*" -2281- PERFORM R0510_LER_PESSOA_JURIDICA_DB_SELECT_1 */

            R0510_LER_PESSOA_JURIDICA_DB_SELECT_1();

            /*" -2284- IF SQLCODE NOT EQUAL 00 AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -2285- DISPLAY 'PF0641B - FIM ANORMAL' */
                _.Display($"PF0641B - FIM ANORMAL");

                /*" -2286- DISPLAY '          ERRO NO ACESSO A PESSOA-JURIDICA' */
                _.Display($"          ERRO NO ACESSO A PESSOA-JURIDICA");

                /*" -2288- DISPLAY '          NUMERO DA PROPOSTA............  ' R1-NUM-PROPOSTA OF REG-CLIENTES */
                _.Display($"          NUMERO DA PROPOSTA............  {LBFPF011.REG_CLIENTES.R1_NUM_PROPOSTA}");

                /*" -2290- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -2291- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -2291- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R0510-LER-PESSOA-JURIDICA-DB-SELECT-1 */
        public void R0510_LER_PESSOA_JURIDICA_DB_SELECT_1()
        {
            /*" -2281- EXEC SQL SELECT COD_PESSOA, CGC, NOME_FANTASIA, COD_USUARIO, TIMESTAMP INTO :DCLPESSOA-JURIDICA.COD-PESSOA, :DCLPESSOA-JURIDICA.CGC, :DCLPESSOA-JURIDICA.NOME-FANTASIA, :DCLPESSOA-JURIDICA.COD-USUARIO, :DCLPESSOA-JURIDICA.TIMESTAMP FROM SEGUROS.PESSOA_JURIDICA WHERE CGC = :DCLPESSOA-JURIDICA.CGC WITH UR END-EXEC. */

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
            /*" -2300- MOVE 'R0515-INCLUIR-TAB-CORPORATIVAS' TO PARAGRAFO. */
            _.Move("R0515-INCLUIR-TAB-CORPORATIVAS", WABEND.FILLER_10.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2302- MOVE '      ' TO COMANDO. */
            _.Move("      ", WABEND.FILLER_10.LOCALIZA_ABEND_2.COMANDO);

            /*" -2304- PERFORM R0520-INCLUIR-TAB-PESSOA. */

            R0520_INCLUIR_TAB_PESSOA_SECTION();

            /*" -2305- IF R1-TIPO-PESSOA OF REG-CLIENTES EQUAL 1 */

            if (LBFPF011.REG_CLIENTES.R1_TIPO_PESSOA == 1)
            {

                /*" -2306- PERFORM R0525-INCLUIR-PESSOA-FISICA */

                R0525_INCLUIR_PESSOA_FISICA_SECTION();

                /*" -2307- ELSE */
            }
            else
            {


                /*" -2309- PERFORM R0530-INCLUIR-PESSOA-JURIDICA. */

                R0530_INCLUIR_PESSOA_JURIDICA_SECTION();
            }


            /*" -2309- PERFORM R0535-INCLUIR-END-EMAIL. */

            R0535_INCLUIR_END_EMAIL_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0515_SAIDA*/

        [StopWatch]
        /*" R0520-INCLUIR-TAB-PESSOA-SECTION */
        private void R0520_INCLUIR_TAB_PESSOA_SECTION()
        {
            /*" -2319- MOVE 'R0520-INCLUIR-TAB-PESSOA' TO PARAGRAFO. */
            _.Move("R0520-INCLUIR-TAB-PESSOA", WABEND.FILLER_10.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2321- MOVE '      ' TO COMANDO. */
            _.Move("      ", WABEND.FILLER_10.LOCALIZA_ABEND_2.COMANDO);

            /*" -2324- COMPUTE W-COD-PESSOA = W-COD-PESSOA + 1 */
            WAREA_AUXILIAR.W_COD_PESSOA.Value = WAREA_AUXILIAR.W_COD_PESSOA + 1;

            /*" -2327- MOVE W-COD-PESSOA TO PESSOA-COD-PESSOA OF DCLPESSOA. */
            _.Move(WAREA_AUXILIAR.W_COD_PESSOA, PESSOA.DCLPESSOA.PESSOA_COD_PESSOA);

            /*" -2330- MOVE R1-NOME-PESSOA OF REG-CLIENTES TO PESSOA-NOME-PESSOA OF DCLPESSOA. */
            _.Move(LBFPF011.REG_CLIENTES.R1_NOME_PESSOA, PESSOA.DCLPESSOA.PESSOA_NOME_PESSOA);

            /*" -2333- MOVE ' ' TO PESSOA-TIPO-PESSOA OF DCLPESSOA. */
            _.Move(" ", PESSOA.DCLPESSOA.PESSOA_TIPO_PESSOA);

            /*" -2334- IF R1-TIPO-PESSOA OF REG-CLIENTES EQUAL 1 */

            if (LBFPF011.REG_CLIENTES.R1_TIPO_PESSOA == 1)
            {

                /*" -2336- MOVE 'F' TO PESSOA-TIPO-PESSOA OF DCLPESSOA */
                _.Move("F", PESSOA.DCLPESSOA.PESSOA_TIPO_PESSOA);

                /*" -2337- ELSE */
            }
            else
            {


                /*" -2338- IF R1-TIPO-PESSOA OF REG-CLIENTES EQUAL 2 */

                if (LBFPF011.REG_CLIENTES.R1_TIPO_PESSOA == 2)
                {

                    /*" -2341- MOVE 'J' TO PESSOA-TIPO-PESSOA OF DCLPESSOA. */
                    _.Move("J", PESSOA.DCLPESSOA.PESSOA_TIPO_PESSOA);
                }

            }


            /*" -2344- MOVE 'PF0641B' TO PESSOA-COD-USUARIO OF DCLPESSOA. */
            _.Move("PF0641B", PESSOA.DCLPESSOA.PESSOA_COD_USUARIO);

            /*" -2352- PERFORM R0520_INCLUIR_TAB_PESSOA_DB_INSERT_1 */

            R0520_INCLUIR_TAB_PESSOA_DB_INSERT_1();

            /*" -2355- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -2356- DISPLAY 'PF0641B - FIM ANORMAL' */
                _.Display($"PF0641B - FIM ANORMAL");

                /*" -2357- DISPLAY '          ERRO INSERT DA TABELA PESSOA' */
                _.Display($"          ERRO INSERT DA TABELA PESSOA");

                /*" -2359- DISPLAY '          CODIGO PESSOA.................  ' PESSOA-COD-PESSOA OF DCLPESSOA */
                _.Display($"          CODIGO PESSOA.................  {PESSOA.DCLPESSOA.PESSOA_COD_PESSOA}");

                /*" -2361- DISPLAY '          NOME DA PESSOA................  ' PESSOA-NOME-PESSOA OF DCLPESSOA */
                _.Display($"          NOME DA PESSOA................  {PESSOA.DCLPESSOA.PESSOA_NOME_PESSOA}");

                /*" -2363- DISPLAY '          NUMERO PROPOSTA...............  ' R1-NUM-PROPOSTA OF REG-CLIENTES */
                _.Display($"          NUMERO PROPOSTA...............  {LBFPF011.REG_CLIENTES.R1_NUM_PROPOSTA}");

                /*" -2365- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -2366- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -2366- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R0520-INCLUIR-TAB-PESSOA-DB-INSERT-1 */
        public void R0520_INCLUIR_TAB_PESSOA_DB_INSERT_1()
        {
            /*" -2352- EXEC SQL INSERT INTO SEGUROS.PESSOA VALUES (:DCLPESSOA.PESSOA-COD-PESSOA, :DCLPESSOA.PESSOA-NOME-PESSOA, CURRENT TIMESTAMP, :DCLPESSOA.PESSOA-COD-USUARIO, :DCLPESSOA.PESSOA-TIPO-PESSOA, NULL) END-EXEC. */

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
        /*" R0525-INCLUIR-PESSOA-FISICA-SECTION */
        private void R0525_INCLUIR_PESSOA_FISICA_SECTION()
        {
            /*" -2376- MOVE 'R0525-INCLUIR-PESSOAS-FISICA' TO PARAGRAFO. */
            _.Move("R0525-INCLUIR-PESSOAS-FISICA", WABEND.FILLER_10.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2378- MOVE 'INSERT PESSOA-FISICA' TO COMANDO. */
            _.Move("INSERT PESSOA-FISICA", WABEND.FILLER_10.LOCALIZA_ABEND_2.COMANDO);

            /*" -2381- MOVE PESSOA-COD-PESSOA OF DCLPESSOA TO COD-PESSOA OF DCLPESSOA-FISICA. */
            _.Move(PESSOA.DCLPESSOA.PESSOA_COD_PESSOA, PESFIS.DCLPESSOA_FISICA.COD_PESSOA);

            /*" -2384- MOVE R1-CGC-CPF OF REG-CLIENTES TO CPF OF DCLPESSOA-FISICA. */
            _.Move(LBFPF011.REG_CLIENTES.R1_CGC_CPF, PESFIS.DCLPESSOA_FISICA.CPF);

            /*" -2387- MOVE R1-DATA-NASCIMENTO OF REG-CLIENTES TO W-DATA-NASCIMENTO. */
            _.Move(LBFPF011.REG_CLIENTES.R1_DATA_NASCIMENTO, W_DATA_NASCIMENTO);

            /*" -2390- MOVE W-DIA-NASCIMENTO TO W-DIA-SQL OF W-DATA-SQL1. */
            _.Move(W_DIA_NASCIMENTO, W_DATA_SQL1.W_DIA_SQL);

            /*" -2393- MOVE W-MES-NASCIMENTO TO W-MES-SQL OF W-DATA-SQL1. */
            _.Move(W_MES_NASCIMENTO, W_DATA_SQL1.W_MES_SQL);

            /*" -2396- MOVE W-ANO-NASCIMENTO TO W-ANO-SQL OF W-DATA-SQL1. */
            _.Move(W_ANO_NASCIMENTO, W_DATA_SQL1.W_ANO_SQL);

            /*" -2400- MOVE '-' TO W-BARRA1 OF W-DATA-SQL1, W-BARRA2 OF W-DATA-SQL1. */
            _.Move("-", W_DATA_SQL1.W_BARRA1_1);
            _.Move("-", W_DATA_SQL1.W_BARRA2_1);


            /*" -2403- MOVE W-DATA-SQL TO DATA-NASCIMENTO OF DCLPESSOA-FISICA. */
            _.Move(W_DATA_SQL, PESFIS.DCLPESSOA_FISICA.DATA_NASCIMENTO);

            /*" -2404- IF R1-IDE-SEXO OF REG-CLIENTES EQUAL 1 */

            if (LBFPF011.REG_CLIENTES.R1_IDE_SEXO == 1)
            {

                /*" -2406- MOVE 'M' TO SEXO OF DCLPESSOA-FISICA */
                _.Move("M", PESFIS.DCLPESSOA_FISICA.SEXO);

                /*" -2407- ELSE */
            }
            else
            {


                /*" -2410- MOVE 'F' TO SEXO OF DCLPESSOA-FISICA. */
                _.Move("F", PESFIS.DCLPESSOA_FISICA.SEXO);
            }


            /*" -2413- MOVE SPACES TO TIPO-IDENT-SIVPF OF DCLPESSOA-FISICA. */
            _.Move("", PESFIS.DCLPESSOA_FISICA.TIPO_IDENT_SIVPF);

            /*" -2416- MOVE R1-NUM-IDENTIDADE OF REG-CLIENTES TO NUM-IDENTIDADE OF DCLPESSOA-FISICA. */
            _.Move(LBFPF011.REG_CLIENTES.R1_NUM_IDENTIDADE, PESFIS.DCLPESSOA_FISICA.NUM_IDENTIDADE);

            /*" -2419- MOVE R1-ORGAO-EXPEDIDOR OF REG-CLIENTES TO ORGAO-EXPEDIDOR OF DCLPESSOA-FISICA. */
            _.Move(LBFPF011.REG_CLIENTES.R1_ORGAO_EXPEDIDOR, PESFIS.DCLPESSOA_FISICA.ORGAO_EXPEDIDOR);

            /*" -2422- MOVE R1-UF-EXPEDIDORA OF REG-CLIENTES TO UF-EXPEDIDORA OF DCLPESSOA-FISICA. */
            _.Move(LBFPF011.REG_CLIENTES.R1_UF_EXPEDIDORA, PESFIS.DCLPESSOA_FISICA.UF_EXPEDIDORA);

            /*" -2423- IF R1-ESTADO-CIVIL OF REG-CLIENTES EQUAL 1 */

            if (LBFPF011.REG_CLIENTES.R1_ESTADO_CIVIL == 1)
            {

                /*" -2425- MOVE 'S' TO ESTADO-CIVIL OF DCLPESSOA-FISICA */
                _.Move("S", PESFIS.DCLPESSOA_FISICA.ESTADO_CIVIL);

                /*" -2426- ELSE */
            }
            else
            {


                /*" -2427- IF R1-ESTADO-CIVIL OF REG-CLIENTES EQUAL 2 */

                if (LBFPF011.REG_CLIENTES.R1_ESTADO_CIVIL == 2)
                {

                    /*" -2429- MOVE 'C' TO ESTADO-CIVIL OF DCLPESSOA-FISICA */
                    _.Move("C", PESFIS.DCLPESSOA_FISICA.ESTADO_CIVIL);

                    /*" -2430- ELSE */
                }
                else
                {


                    /*" -2431- IF R1-ESTADO-CIVIL OF REG-CLIENTES EQUAL 3 */

                    if (LBFPF011.REG_CLIENTES.R1_ESTADO_CIVIL == 3)
                    {

                        /*" -2433- MOVE 'V' TO ESTADO-CIVIL OF DCLPESSOA-FISICA */
                        _.Move("V", PESFIS.DCLPESSOA_FISICA.ESTADO_CIVIL);

                        /*" -2434- ELSE */
                    }
                    else
                    {


                        /*" -2437- MOVE 'O' TO ESTADO-CIVIL OF DCLPESSOA-FISICA. */
                        _.Move("O", PESFIS.DCLPESSOA_FISICA.ESTADO_CIVIL);
                    }

                }

            }


            /*" -2440- MOVE R1-DATA-EXPEDICAO-RG OF REG-CLIENTES TO W-DATA-TRABALHO. */
            _.Move(LBFPF011.REG_CLIENTES.R1_DATA_EXPEDICAO_RG, WAREA_AUXILIAR.W_DATA_TRABALHO);

            /*" -2441- IF W-DATA-TRABALHO NOT NUMERIC */

            if (!WAREA_AUXILIAR.W_DATA_TRABALHO.IsNumeric())
            {

                /*" -2443- MOVE -1 TO VIND-DTEXPEDI */
                _.Move(-1, VIND_DTEXPEDI);

                /*" -2444- ELSE */
            }
            else
            {


                /*" -2446- IF W-DATA-TRABALHO EQUAL 01010001 OR W-DATA-TRABALHO EQUAL ZEROS */

                if (WAREA_AUXILIAR.W_DATA_TRABALHO == 01010001 || WAREA_AUXILIAR.W_DATA_TRABALHO == 00)
                {

                    /*" -2448- MOVE -1 TO VIND-DTEXPEDI */
                    _.Move(-1, VIND_DTEXPEDI);

                    /*" -2449- ELSE */
                }
                else
                {


                    /*" -2451- MOVE W-DIA-TRABALHO TO W-DIA-SQL OF W-DATA-SQL1 */
                    _.Move(WAREA_AUXILIAR.W_DIA_TRABALHO, W_DATA_SQL1.W_DIA_SQL);

                    /*" -2453- MOVE W-MES-TRABALHO TO W-MES-SQL OF W-DATA-SQL1 */
                    _.Move(WAREA_AUXILIAR.W_MES_TRABALHO, W_DATA_SQL1.W_MES_SQL);

                    /*" -2456- MOVE W-ANO-TRABALHO TO W-ANO-SQL OF W-DATA-SQL1 */
                    _.Move(WAREA_AUXILIAR.W_ANO_TRABALHO, W_DATA_SQL1.W_ANO_SQL);

                    /*" -2460- MOVE '-' TO W-BARRA1 OF W-DATA-SQL1, W-BARRA2 OF W-DATA-SQL1 */
                    _.Move("-", W_DATA_SQL1.W_BARRA1_1);
                    _.Move("-", W_DATA_SQL1.W_BARRA2_1);


                    /*" -2463- MOVE W-DATA-SQL TO DATA-EXPEDICAO OF DCLPESSOA-FISICA. */
                    _.Move(W_DATA_SQL, PESFIS.DCLPESSOA_FISICA.DATA_EXPEDICAO);
                }

            }


            /*" -2466- MOVE R1-COD-CBO OF REG-CLIENTES TO COD-CBO OF DCLPESSOA-FISICA. */
            _.Move(LBFPF011.REG_CLIENTES.R1_COD_CBO, PESFIS.DCLPESSOA_FISICA.COD_CBO);

            /*" -2469- MOVE 'PF0641B' TO COD-USUARIO OF DCLPESSOA-FISICA. */
            _.Move("PF0641B", PESFIS.DCLPESSOA_FISICA.COD_USUARIO);

            /*" -2484- PERFORM R0525_INCLUIR_PESSOA_FISICA_DB_INSERT_1 */

            R0525_INCLUIR_PESSOA_FISICA_DB_INSERT_1();

            /*" -2487- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -2488- DISPLAY 'PF0641B - FIM ANORMAL' */
                _.Display($"PF0641B - FIM ANORMAL");

                /*" -2489- DISPLAY '          ERRO INSERT DA TABELA PESSOA FISICA' */
                _.Display($"          ERRO INSERT DA TABELA PESSOA FISICA");

                /*" -2491- DISPLAY '          CODIGO PESSOA.................  ' COD-PESSOA OF DCLPESSOA-FISICA */
                _.Display($"          CODIGO PESSOA.................  {PESFIS.DCLPESSOA_FISICA.COD_PESSOA}");

                /*" -2493- DISPLAY '          NUMERO PROPOSTA...............  ' R1-NUM-PROPOSTA OF REG-CLIENTES */
                _.Display($"          NUMERO PROPOSTA...............  {LBFPF011.REG_CLIENTES.R1_NUM_PROPOSTA}");

                /*" -2495- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -2496- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -2496- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R0525-INCLUIR-PESSOA-FISICA-DB-INSERT-1 */
        public void R0525_INCLUIR_PESSOA_FISICA_DB_INSERT_1()
        {
            /*" -2484- EXEC SQL INSERT INTO SEGUROS.PESSOA_FISICA VALUES (:DCLPESSOA-FISICA.COD-PESSOA, :DCLPESSOA-FISICA.CPF, :DCLPESSOA-FISICA.DATA-NASCIMENTO, :DCLPESSOA-FISICA.SEXO, :DCLPESSOA-FISICA.COD-USUARIO, :DCLPESSOA-FISICA.ESTADO-CIVIL, CURRENT TIMESTAMP, :DCLPESSOA-FISICA.NUM-IDENTIDADE, :DCLPESSOA-FISICA.ORGAO-EXPEDIDOR, :DCLPESSOA-FISICA.UF-EXPEDIDORA, :DCLPESSOA-FISICA.DATA-EXPEDICAO:VIND-DTEXPEDI, :DCLPESSOA-FISICA.COD-CBO, :DCLPESSOA-FISICA.TIPO-IDENT-SIVPF) END-EXEC. */

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
        /*" R0530-INCLUIR-PESSOA-JURIDICA-SECTION */
        private void R0530_INCLUIR_PESSOA_JURIDICA_SECTION()
        {
            /*" -2505- MOVE 'R0530-INCLUIR-PESSOAS-JURIDICA' TO PARAGRAFO. */
            _.Move("R0530-INCLUIR-PESSOAS-JURIDICA", WABEND.FILLER_10.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2507- MOVE 'INSERT PESSOA-JURIDICA' TO COMANDO. */
            _.Move("INSERT PESSOA-JURIDICA", WABEND.FILLER_10.LOCALIZA_ABEND_2.COMANDO);

            /*" -2510- MOVE PESSOA-COD-PESSOA OF DCLPESSOA TO COD-PESSOA OF DCLPESSOA-JURIDICA */
            _.Move(PESSOA.DCLPESSOA.PESSOA_COD_PESSOA, PESJUR.DCLPESSOA_JURIDICA.COD_PESSOA);

            /*" -2513- MOVE R1-CGC-CPF OF REG-CLIENTES TO CGC OF DCLPESSOA-JURIDICA */
            _.Move(LBFPF011.REG_CLIENTES.R1_CGC_CPF, PESJUR.DCLPESSOA_JURIDICA.CGC);

            /*" -2516- MOVE R1-NOME-PESSOA OF REG-CLIENTES TO NOME-FANTASIA OF DCLPESSOA-JURIDICA */
            _.Move(LBFPF011.REG_CLIENTES.R1_NOME_PESSOA, PESJUR.DCLPESSOA_JURIDICA.NOME_FANTASIA);

            /*" -2519- MOVE 'PF0641B' TO COD-USUARIO OF DCLPESSOA-JURIDICA */
            _.Move("PF0641B", PESJUR.DCLPESSOA_JURIDICA.COD_USUARIO);

            /*" -2526- PERFORM R0530_INCLUIR_PESSOA_JURIDICA_DB_INSERT_1 */

            R0530_INCLUIR_PESSOA_JURIDICA_DB_INSERT_1();

            /*" -2529- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -2530- DISPLAY 'PF0641B - FIM ANORMAL' */
                _.Display($"PF0641B - FIM ANORMAL");

                /*" -2531- DISPLAY '          ERRO INSERT DA TABELA PESSOA JURIDICA' */
                _.Display($"          ERRO INSERT DA TABELA PESSOA JURIDICA");

                /*" -2533- DISPLAY '          CODIGO PESSOA.................  ' COD-PESSOA OF DCLPESSOA-JURIDICA */
                _.Display($"          CODIGO PESSOA.................  {PESJUR.DCLPESSOA_JURIDICA.COD_PESSOA}");

                /*" -2535- DISPLAY '          NUMERO PROPOSTA...............  ' R1-NUM-PROPOSTA OF REG-CLIENTES */
                _.Display($"          NUMERO PROPOSTA...............  {LBFPF011.REG_CLIENTES.R1_NUM_PROPOSTA}");

                /*" -2537- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -2538- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -2538- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R0530-INCLUIR-PESSOA-JURIDICA-DB-INSERT-1 */
        public void R0530_INCLUIR_PESSOA_JURIDICA_DB_INSERT_1()
        {
            /*" -2526- EXEC SQL INSERT INTO SEGUROS.PESSOA_JURIDICA VALUES (:DCLPESSOA-JURIDICA.COD-PESSOA, :DCLPESSOA-JURIDICA.CGC, :DCLPESSOA-JURIDICA.NOME-FANTASIA, :DCLPESSOA-JURIDICA.COD-USUARIO, CURRENT TIMESTAMP) END-EXEC. */

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
            /*" -2548- MOVE 'R0536-RELACIONA-EMAIL' TO PARAGRAFO. */
            _.Move("R0536-RELACIONA-EMAIL", WABEND.FILLER_10.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2550- MOVE 'DECLARE PESSOA-EMAIL' TO COMANDO. */
            _.Move("DECLARE PESSOA-EMAIL", WABEND.FILLER_10.LOCALIZA_ABEND_2.COMANDO);

            /*" -2553- MOVE PESSOA-COD-PESSOA OF DCLPESSOA TO COD-PESSOA OF DCLPESSOA-EMAIL. */
            _.Move(PESSOA.DCLPESSOA.PESSOA_COD_PESSOA, PESEMAIL.DCLPESSOA_EMAIL.COD_PESSOA);

            /*" -2563- PERFORM R0536_RELACIONA_EMAIL_DB_DECLARE_1 */

            R0536_RELACIONA_EMAIL_DB_DECLARE_1();

            /*" -2567- IF SQLCODE NOT EQUAL 00 AND SQLCODE NOT EQUAL 100 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != 100)
            {

                /*" -2568- DISPLAY 'PF0641B - FIM ANORMAL' */
                _.Display($"PF0641B - FIM ANORMAL");

                /*" -2569- DISPLAY '          ERRO DECLARE DA TABELA PESSOA EMAIL' */
                _.Display($"          ERRO DECLARE DA TABELA PESSOA EMAIL");

                /*" -2571- DISPLAY '          CODIGO PESSOA.................  ' COD-PESSOA OF DCLPESSOA-EMAIL */
                _.Display($"          CODIGO PESSOA.................  {PESEMAIL.DCLPESSOA_EMAIL.COD_PESSOA}");

                /*" -2573- DISPLAY '          NUMERO PROPOSTA...............  ' R1-NUM-PROPOSTA OF REG-CLIENTES */
                _.Display($"          NUMERO PROPOSTA...............  {LBFPF011.REG_CLIENTES.R1_NUM_PROPOSTA}");

                /*" -2575- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -2576- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -2576- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R0536-RELACIONA-EMAIL-DB-DECLARE-1 */
        public void R0536_RELACIONA_EMAIL_DB_DECLARE_1()
        {
            /*" -2563- EXEC SQL DECLARE EMAIL CURSOR FOR SELECT COD_PESSOA, SEQ_EMAIL, EMAIL, SITUACAO_EMAIL FROM SEGUROS.PESSOA_EMAIL WHERE COD_PESSOA = :DCLPESSOA-EMAIL.COD-PESSOA ORDER BY SEQ_EMAIL WITH UR END-EXEC. */
            EMAIL = new PF0641B_EMAIL(true);
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
            /*" -2585- MOVE 'R0535-INCLUIR-END-EMAIL' TO PARAGRAFO. */
            _.Move("R0535-INCLUIR-END-EMAIL", WABEND.FILLER_10.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2587- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.FILLER_10.LOCALIZA_ABEND_2.COMANDO);

            /*" -2589- PERFORM R0536-RELACIONA-EMAIL. */

            R0536_RELACIONA_EMAIL_SECTION();

            /*" -2591- MOVE 'OPEN CURSOR EMAIL' TO COMANDO. */
            _.Move("OPEN CURSOR EMAIL", WABEND.FILLER_10.LOCALIZA_ABEND_2.COMANDO);

            /*" -2591- PERFORM R0535_INCLUIR_END_EMAIL_DB_OPEN_1 */

            R0535_INCLUIR_END_EMAIL_DB_OPEN_1();

            /*" -2595- MOVE 'NAO' TO W-ACHOU-EMAIL. */
            _.Move("NAO", WAREA_AUXILIAR.W_ACHOU_EMAIL);

            /*" -2597- MOVE SPACES TO W-FIM-CURSOR-EMAIL. */
            _.Move("", WAREA_AUXILIAR.W_FIM_CURSOR_EMAIL);

            /*" -2599- PERFORM R0537-FETCH-EMAIL */

            R0537_FETCH_EMAIL_SECTION();

            /*" -2600- IF W-FIM-CURSOR-EMAIL EQUAL 'SIM' */

            if (WAREA_AUXILIAR.W_FIM_CURSOR_EMAIL == "SIM")
            {

                /*" -2601- IF R1-EMAIL OF REG-CLIENTES EQUAL SPACES */

                if (LBFPF011.REG_CLIENTES.R1_EMAIL.IsEmpty())
                {

                    /*" -2603- MOVE 'SIM' TO W-ACHOU-EMAIL. */
                    _.Move("SIM", WAREA_AUXILIAR.W_ACHOU_EMAIL);
                }

            }


            /*" -2606- PERFORM R0538-VERIFICA-EXISTE-EMAIL UNTIL W-FIM-CURSOR-EMAIL EQUAL 'SIM' . */

            while (!(WAREA_AUXILIAR.W_FIM_CURSOR_EMAIL == "SIM"))
            {

                R0538_VERIFICA_EXISTE_EMAIL_SECTION();
            }

            /*" -2607- IF W-ACHOU-EMAIL EQUAL 'NAO' */

            if (WAREA_AUXILIAR.W_ACHOU_EMAIL == "NAO")
            {

                /*" -2607- PERFORM R0539-INCLUIR-NOVO-EMAIL. */

                R0539_INCLUIR_NOVO_EMAIL_SECTION();
            }


        }

        [StopWatch]
        /*" R0535-INCLUIR-END-EMAIL-DB-OPEN-1 */
        public void R0535_INCLUIR_END_EMAIL_DB_OPEN_1()
        {
            /*" -2591- EXEC SQL OPEN EMAIL END-EXEC. */

            EMAIL.Open();

        }

        [StopWatch]
        /*" R0605A-RELACIONA-ENDERECO-DB-DECLARE-1 */
        public void R0605A_RELACIONA_ENDERECO_DB_DECLARE_1()
        {
            /*" -3007- EXEC SQL DECLARE ENDERECOS CURSOR FOR SELECT OCORR_ENDERECO, COD_PESSOA, ENDERECO, TIPO_ENDER, BAIRRO, CEP, CIDADE, SIGLA_UF, SITUACAO_ENDERECO FROM SEGUROS.PESSOA_ENDERECO WHERE COD_PESSOA = :DCLPESSOA-ENDERECO.COD-PESSOA ORDER BY OCORR_ENDERECO WITH UR END-EXEC. */
            ENDERECOS = new PF0641B_ENDERECOS(true);
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
            /*" -2618- MOVE 'R0537-FETCH-EMAIL' TO PARAGRAFO. */
            _.Move("R0537-FETCH-EMAIL", WABEND.FILLER_10.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2620- MOVE 'FETCH CURSOR EMAIL' TO COMANDO. */
            _.Move("FETCH CURSOR EMAIL", WABEND.FILLER_10.LOCALIZA_ABEND_2.COMANDO);

            /*" -2626- PERFORM R0537_FETCH_EMAIL_DB_FETCH_1 */

            R0537_FETCH_EMAIL_DB_FETCH_1();

            /*" -2629- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -2630- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2631- MOVE 'SIM' TO W-FIM-CURSOR-EMAIL */
                    _.Move("SIM", WAREA_AUXILIAR.W_FIM_CURSOR_EMAIL);

                    /*" -2631- PERFORM R0537_FETCH_EMAIL_DB_CLOSE_1 */

                    R0537_FETCH_EMAIL_DB_CLOSE_1();

                    /*" -2633- ELSE */
                }
                else
                {


                    /*" -2634- DISPLAY 'PF0641B - FIM ANORMAL' */
                    _.Display($"PF0641B - FIM ANORMAL");

                    /*" -2635- DISPLAY '          ERRO FETCH CURSOR EMAIL' */
                    _.Display($"          ERRO FETCH CURSOR EMAIL");

                    /*" -2637- DISPLAY '          CODIGO PESSOA.................  ' COD-PESSOA OF DCLPESSOA-EMAIL */
                    _.Display($"          CODIGO PESSOA.................  {PESEMAIL.DCLPESSOA_EMAIL.COD_PESSOA}");

                    /*" -2639- DISPLAY '          NUMERO PROPOSTA...............  ' R1-NUM-PROPOSTA OF REG-CLIENTES */
                    _.Display($"          NUMERO PROPOSTA...............  {LBFPF011.REG_CLIENTES.R1_NUM_PROPOSTA}");

                    /*" -2641- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                    _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                    /*" -2642- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -2642- PERFORM R9999-00-FINALIZAR. */

                    R9999_00_FINALIZAR_SECTION();
                }

            }


        }

        [StopWatch]
        /*" R0537-FETCH-EMAIL-DB-FETCH-1 */
        public void R0537_FETCH_EMAIL_DB_FETCH_1()
        {
            /*" -2626- EXEC SQL FETCH EMAIL INTO :DCLPESSOA-EMAIL.COD-PESSOA, :DCLPESSOA-EMAIL.SEQ-EMAIL, :DCLPESSOA-EMAIL.EMAIL, :DCLPESSOA-EMAIL.SITUACAO-EMAIL END-EXEC. */

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
            /*" -2631- EXEC SQL CLOSE EMAIL END-EXEC */

            EMAIL.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0537_SAIDA*/

        [StopWatch]
        /*" R0538-VERIFICA-EXISTE-EMAIL-SECTION */
        private void R0538_VERIFICA_EXISTE_EMAIL_SECTION()
        {
            /*" -2652- MOVE 'R0538-VERIFICA-EXISTE-EMAIL' TO PARAGRAFO. */
            _.Move("R0538-VERIFICA-EXISTE-EMAIL", WABEND.FILLER_10.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2654- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.FILLER_10.LOCALIZA_ABEND_2.COMANDO);

            /*" -2656- IF R1-EMAIL OF REG-CLIENTES EQUAL EMAIL OF DCLPESSOA-EMAIL */

            if (LBFPF011.REG_CLIENTES.R1_EMAIL == PESEMAIL.DCLPESSOA_EMAIL.EMAIL)
            {

                /*" -2658- MOVE 'SIM' TO W-ACHOU-EMAIL. */
                _.Move("SIM", WAREA_AUXILIAR.W_ACHOU_EMAIL);
            }


            /*" -2659- IF R1-EMAIL OF REG-CLIENTES EQUAL SPACES */

            if (LBFPF011.REG_CLIENTES.R1_EMAIL.IsEmpty())
            {

                /*" -2661- MOVE 'SIM' TO W-ACHOU-EMAIL. */
                _.Move("SIM", WAREA_AUXILIAR.W_ACHOU_EMAIL);
            }


            /*" -2661- PERFORM R0537-FETCH-EMAIL. */

            R0537_FETCH_EMAIL_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0538_SAIDA*/

        [StopWatch]
        /*" R0539-INCLUIR-NOVO-EMAIL-SECTION */
        private void R0539_INCLUIR_NOVO_EMAIL_SECTION()
        {
            /*" -2672- MOVE 'R0539-INCLUIR-NOVO-EMAIL' TO PARAGRAFO. */
            _.Move("R0539-INCLUIR-NOVO-EMAIL", WABEND.FILLER_10.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2681- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.FILLER_10.LOCALIZA_ABEND_2.COMANDO);

            /*" -2684- MOVE SEQ-EMAIL OF DCLPESSOA-EMAIL TO W-SEQ-EMAIL */
            _.Move(PESEMAIL.DCLPESSOA_EMAIL.SEQ_EMAIL, WAREA_AUXILIAR.W_SEQ_EMAIL);

            /*" -2686- COMPUTE W-SEQ-EMAIL = W-SEQ-EMAIL + 1. */
            WAREA_AUXILIAR.W_SEQ_EMAIL.Value = WAREA_AUXILIAR.W_SEQ_EMAIL + 1;

            /*" -2686- PERFORM R0541-INCLUIR-EMAIL. */

            R0541_INCLUIR_EMAIL_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0539_SAIDA*/

        [StopWatch]
        /*" R0540-OBTER-MAX-EMAIL-SECTION */
        private void R0540_OBTER_MAX_EMAIL_SECTION()
        {
            /*" -2696- MOVE 'R0540-OBTER-MAX-EMAIL' TO PARAGRAFO. */
            _.Move("R0540-OBTER-MAX-EMAIL", WABEND.FILLER_10.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2698- MOVE 'MAX SEGUROS.PESSOA_EMAIL' TO COMANDO. */
            _.Move("MAX SEGUROS.PESSOA_EMAIL", WABEND.FILLER_10.LOCALIZA_ABEND_2.COMANDO);

            /*" -2701- MOVE PESSOA-COD-PESSOA OF DCLPESSOA TO COD-PESSOA OF DCLPESSOA-EMAIL. */
            _.Move(PESSOA.DCLPESSOA.PESSOA_COD_PESSOA, PESEMAIL.DCLPESSOA_EMAIL.COD_PESSOA);

            /*" -2707- PERFORM R0540_OBTER_MAX_EMAIL_DB_SELECT_1 */

            R0540_OBTER_MAX_EMAIL_DB_SELECT_1();

            /*" -2710- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -2711- DISPLAY 'PF0641B - FIM ANORMAL' */
                _.Display($"PF0641B - FIM ANORMAL");

                /*" -2712- DISPLAY '          ERRO NO SELECT MAX TAB. PESSOA-EMAIL' */
                _.Display($"          ERRO NO SELECT MAX TAB. PESSOA-EMAIL");

                /*" -2714- DISPLAY '          NUMERO DA PROPOSTA............  ' R1-NUM-PROPOSTA OF REG-CLIENTES */
                _.Display($"          NUMERO DA PROPOSTA............  {LBFPF011.REG_CLIENTES.R1_NUM_PROPOSTA}");

                /*" -2716- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -2717- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -2717- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R0540-OBTER-MAX-EMAIL-DB-SELECT-1 */
        public void R0540_OBTER_MAX_EMAIL_DB_SELECT_1()
        {
            /*" -2707- EXEC SQL SELECT VALUE(MAX(SEQ_EMAIL),0) INTO :DCLPESSOA-EMAIL.SEQ-EMAIL FROM SEGUROS.PESSOA_EMAIL WHERE COD_PESSOA = :DCLPESSOA-EMAIL.COD-PESSOA WITH UR END-EXEC. */

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
            /*" -2726- MOVE 'R0541-INCLUI-EMAIL' TO PARAGRAFO. */
            _.Move("R0541-INCLUI-EMAIL", WABEND.FILLER_10.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2728- MOVE 'MAX SEGUROS.PESSOA_EMAIL' TO COMANDO. */
            _.Move("MAX SEGUROS.PESSOA_EMAIL", WABEND.FILLER_10.LOCALIZA_ABEND_2.COMANDO);

            /*" -2731- MOVE PESSOA-COD-PESSOA OF DCLPESSOA TO COD-PESSOA OF DCLPESSOA-EMAIL */
            _.Move(PESSOA.DCLPESSOA.PESSOA_COD_PESSOA, PESEMAIL.DCLPESSOA_EMAIL.COD_PESSOA);

            /*" -2734- MOVE W-SEQ-EMAIL TO SEQ-EMAIL OF DCLPESSOA-EMAIL. */
            _.Move(WAREA_AUXILIAR.W_SEQ_EMAIL, PESEMAIL.DCLPESSOA_EMAIL.SEQ_EMAIL);

            /*" -2737- MOVE R1-EMAIL OF REG-CLIENTES TO EMAIL OF DCLPESSOA-EMAIL */
            _.Move(LBFPF011.REG_CLIENTES.R1_EMAIL, PESEMAIL.DCLPESSOA_EMAIL.EMAIL);

            /*" -2740- MOVE 'A' TO SITUACAO-EMAIL OF DCLPESSOA-EMAIL */
            _.Move("A", PESEMAIL.DCLPESSOA_EMAIL.SITUACAO_EMAIL);

            /*" -2743- MOVE 'PF0641B' TO COD-USUARIO OF DCLPESSOA-EMAIL. */
            _.Move("PF0641B", PESEMAIL.DCLPESSOA_EMAIL.COD_USUARIO);

            /*" -2751- PERFORM R0541_INCLUIR_EMAIL_DB_INSERT_1 */

            R0541_INCLUIR_EMAIL_DB_INSERT_1();

            /*" -2754- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -2755- DISPLAY 'PF0641B - FIM ANORMAL' */
                _.Display($"PF0641B - FIM ANORMAL");

                /*" -2756- DISPLAY '          ERRO INSERT DA TABELA PESSOA-EMAIL' */
                _.Display($"          ERRO INSERT DA TABELA PESSOA-EMAIL");

                /*" -2758- DISPLAY '          CODIGO PESSOA.................  ' PESSOA-COD-PESSOA OF DCLPESSOA */
                _.Display($"          CODIGO PESSOA.................  {PESSOA.DCLPESSOA.PESSOA_COD_PESSOA}");

                /*" -2760- DISPLAY '          NOME DA PESSOA................  ' PESSOA-NOME-PESSOA OF DCLPESSOA */
                _.Display($"          NOME DA PESSOA................  {PESSOA.DCLPESSOA.PESSOA_NOME_PESSOA}");

                /*" -2762- DISPLAY '          NUMERO PROPOSTA...............  ' R1-NUM-PROPOSTA OF REG-CLIENTES */
                _.Display($"          NUMERO PROPOSTA...............  {LBFPF011.REG_CLIENTES.R1_NUM_PROPOSTA}");

                /*" -2764- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -2765- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -2765- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R0541-INCLUIR-EMAIL-DB-INSERT-1 */
        public void R0541_INCLUIR_EMAIL_DB_INSERT_1()
        {
            /*" -2751- EXEC SQL INSERT INTO SEGUROS.PESSOA_EMAIL VALUES (:DCLPESSOA-EMAIL.COD-PESSOA, :DCLPESSOA-EMAIL.SEQ-EMAIL, :DCLPESSOA-EMAIL.EMAIL, :DCLPESSOA-EMAIL.SITUACAO-EMAIL, :DCLPESSOA-EMAIL.COD-USUARIO, CURRENT TIMESTAMP) END-EXEC. */

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
            /*" -2775- MOVE 'R0550-LER-TAB-CORPORATIVAS' TO PARAGRAFO. */
            _.Move("R0550-LER-TAB-CORPORATIVAS", WABEND.FILLER_10.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2777- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.FILLER_10.LOCALIZA_ABEND_2.COMANDO);

            /*" -2778- IF R1-TIPO-PESSOA OF REG-CLIENTES EQUAL 1 */

            if (LBFPF011.REG_CLIENTES.R1_TIPO_PESSOA == 1)
            {

                /*" -2780- MOVE COD-PESSOA OF DCLPESSOA-FISICA TO PESSOA-COD-PESSOA OF DCLPESSOA */
                _.Move(PESFIS.DCLPESSOA_FISICA.COD_PESSOA, PESSOA.DCLPESSOA.PESSOA_COD_PESSOA);

                /*" -2781- ELSE */
            }
            else
            {


                /*" -2784- MOVE COD-PESSOA OF DCLPESSOA-JURIDICA TO PESSOA-COD-PESSOA OF DCLPESSOA. */
                _.Move(PESJUR.DCLPESSOA_JURIDICA.COD_PESSOA, PESSOA.DCLPESSOA.PESSOA_COD_PESSOA);
            }


            /*" -2786- PERFORM R0555-LER-TAB-PESSOA. */

            R0555_LER_TAB_PESSOA_SECTION();

            /*" -2786- PERFORM R0560-LER-TAB-EMAIL. */

            R0560_LER_TAB_EMAIL_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0550_SAIDA*/

        [StopWatch]
        /*" R0555-LER-TAB-PESSOA-SECTION */
        private void R0555_LER_TAB_PESSOA_SECTION()
        {
            /*" -2796- MOVE 'R0550-LER-TAB-PESSOAS' TO PARAGRAFO. */
            _.Move("R0550-LER-TAB-PESSOAS", WABEND.FILLER_10.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2798- MOVE 'SELECT SEGUROS.PESSOAS' TO COMANDO. */
            _.Move("SELECT SEGUROS.PESSOAS", WABEND.FILLER_10.LOCALIZA_ABEND_2.COMANDO);

            /*" -2812- PERFORM R0555_LER_TAB_PESSOA_DB_SELECT_1 */

            R0555_LER_TAB_PESSOA_DB_SELECT_1();

            /*" -2815- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -2816- DISPLAY 'PF0641B - FIM ANORMAL' */
                _.Display($"PF0641B - FIM ANORMAL");

                /*" -2817- DISPLAY '          ERRO ACESSO TAB. SEGUROS.PESSOA' */
                _.Display($"          ERRO ACESSO TAB. SEGUROS.PESSOA");

                /*" -2819- DISPLAY '          CODIGO PESSOA.................  ' PESSOA-COD-PESSOA OF DCLPESSOA */
                _.Display($"          CODIGO PESSOA.................  {PESSOA.DCLPESSOA.PESSOA_COD_PESSOA}");

                /*" -2821- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -2822- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -2822- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R0555-LER-TAB-PESSOA-DB-SELECT-1 */
        public void R0555_LER_TAB_PESSOA_DB_SELECT_1()
        {
            /*" -2812- EXEC SQL SELECT COD_PESSOA, NOME_PESSOA, TIPO_PESSOA, TIMESTAMP, COD_USUARIO INTO :DCLPESSOA.PESSOA-COD-PESSOA, :DCLPESSOA.PESSOA-NOME-PESSOA, :DCLPESSOA.PESSOA-TIPO-PESSOA, :DCLPESSOA.PESSOA-TIMESTAMP, :DCLPESSOA.PESSOA-COD-USUARIO FROM SEGUROS.PESSOA WHERE COD_PESSOA = :DCLPESSOA.PESSOA-COD-PESSOA WITH UR END-EXEC. */

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
            /*" -2831- MOVE 'R0560-LER-TAB-EMAIL' TO PARAGRAFO. */
            _.Move("R0560-LER-TAB-EMAIL", WABEND.FILLER_10.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2833- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.FILLER_10.LOCALIZA_ABEND_2.COMANDO);

            /*" -2835- PERFORM R0565-OBTER-MAX-EMAIL. */

            R0565_OBTER_MAX_EMAIL_SECTION();

            /*" -2835- PERFORM R0570-LER-EMAIL-ATUAL. */

            R0570_LER_EMAIL_ATUAL_SECTION();

        }

        [StopWatch]
        /*" R0565-OBTER-MAX-EMAIL-SECTION */
        private void R0565_OBTER_MAX_EMAIL_SECTION()
        {
            /*" -2844- MOVE 'R0565-OBTER-MAX-EMAIL' TO PARAGRAFO. */
            _.Move("R0565-OBTER-MAX-EMAIL", WABEND.FILLER_10.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2846- MOVE 'MAX SEGUROS.PESSOA_EMAIL' TO COMANDO. */
            _.Move("MAX SEGUROS.PESSOA_EMAIL", WABEND.FILLER_10.LOCALIZA_ABEND_2.COMANDO);

            /*" -2849- MOVE PESSOA-COD-PESSOA OF DCLPESSOA TO COD-PESSOA OF DCLPESSOA-EMAIL. */
            _.Move(PESSOA.DCLPESSOA.PESSOA_COD_PESSOA, PESEMAIL.DCLPESSOA_EMAIL.COD_PESSOA);

            /*" -2855- PERFORM R0565_OBTER_MAX_EMAIL_DB_SELECT_1 */

            R0565_OBTER_MAX_EMAIL_DB_SELECT_1();

            /*" -2858- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -2859- DISPLAY 'PF0641B - FIM ANORMAL' */
                _.Display($"PF0641B - FIM ANORMAL");

                /*" -2860- DISPLAY '          ERRO SELECT MAX TAB. PESSOA-EMAIL' */
                _.Display($"          ERRO SELECT MAX TAB. PESSOA-EMAIL");

                /*" -2862- DISPLAY '          CODIGO PESSOA.................  ' COD-PESSOA OF DCLPESSOA-EMAIL */
                _.Display($"          CODIGO PESSOA.................  {PESEMAIL.DCLPESSOA_EMAIL.COD_PESSOA}");

                /*" -2864- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -2865- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -2865- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R0565-OBTER-MAX-EMAIL-DB-SELECT-1 */
        public void R0565_OBTER_MAX_EMAIL_DB_SELECT_1()
        {
            /*" -2855- EXEC SQL SELECT VALUE(MAX(SEQ_EMAIL),0) INTO :DCLPESSOA-EMAIL.SEQ-EMAIL FROM SEGUROS.PESSOA_EMAIL WHERE COD_PESSOA = :DCLPESSOA-EMAIL.COD-PESSOA WITH UR END-EXEC. */

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
            /*" -2875- MOVE 'R0570-LER-EMAIL-ATUAL' TO PARAGRAFO. */
            _.Move("R0570-LER-EMAIL-ATUAL", WABEND.FILLER_10.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2877- MOVE 'SELECT SEGUROS.PESSOA_EMAIL' TO COMANDO. */
            _.Move("SELECT SEGUROS.PESSOA_EMAIL", WABEND.FILLER_10.LOCALIZA_ABEND_2.COMANDO);

            /*" -2880- MOVE PESSOA-COD-PESSOA OF DCLPESSOA TO COD-PESSOA OF DCLPESSOA-EMAIL. */
            _.Move(PESSOA.DCLPESSOA.PESSOA_COD_PESSOA, PESEMAIL.DCLPESSOA_EMAIL.COD_PESSOA);

            /*" -2897- PERFORM R0570_LER_EMAIL_ATUAL_DB_SELECT_1 */

            R0570_LER_EMAIL_ATUAL_DB_SELECT_1();

            /*" -2901- IF SQLCODE NOT EQUAL 00 AND SQLCODE NOT EQUAL 100 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != 100)
            {

                /*" -2902- DISPLAY 'PF0641B - FIM ANORMAL' */
                _.Display($"PF0641B - FIM ANORMAL");

                /*" -2903- DISPLAY '          ERRO SELECT TAB. PESSOA-EMAIL' */
                _.Display($"          ERRO SELECT TAB. PESSOA-EMAIL");

                /*" -2905- DISPLAY '          CODIGO PESSOA.................  ' COD-PESSOA OF DCLPESSOA-EMAIL */
                _.Display($"          CODIGO PESSOA.................  {PESEMAIL.DCLPESSOA_EMAIL.COD_PESSOA}");

                /*" -2907- DISPLAY '          SEQUENCIAEMAIL................  ' SEQ-EMAIL OF DCLPESSOA-EMAIL */
                _.Display($"          SEQUENCIAEMAIL................  {PESEMAIL.DCLPESSOA_EMAIL.SEQ_EMAIL}");

                /*" -2909- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -2910- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -2910- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R0570-LER-EMAIL-ATUAL-DB-SELECT-1 */
        public void R0570_LER_EMAIL_ATUAL_DB_SELECT_1()
        {
            /*" -2897- EXEC SQL SELECT COD_PESSOA, SEQ_EMAIL, EMAIL, SITUACAO_EMAIL, COD_USUARIO, TIMESTAMP INTO :DCLPESSOA-EMAIL.COD-PESSOA, :DCLPESSOA-EMAIL.SEQ-EMAIL, :DCLPESSOA-EMAIL.EMAIL, :DCLPESSOA-EMAIL.SITUACAO-EMAIL, :DCLPESSOA-EMAIL.COD-USUARIO, :DCLPESSOA-EMAIL.TIMESTAMP FROM SEGUROS.PESSOA_EMAIL WHERE COD_PESSOA = :DCLPESSOA-EMAIL.COD-PESSOA AND SEQ_EMAIL = :DCLPESSOA-EMAIL.SEQ-EMAIL WITH UR END-EXEC. */

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
            /*" -2920- MOVE 'R0600-TRATA-END-TEL' TO PARAGRAFO. */
            _.Move("R0600-TRATA-END-TEL", WABEND.FILLER_10.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2922- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.FILLER_10.LOCALIZA_ABEND_2.COMANDO);

            /*" -2926- PERFORM R0601-TRATA-ENDERECO VARYING W-IND-ENDER FROM 1 BY 1 UNTIL W-IND-ENDER GREATER W-IND-ENDER-N. */

            for (WAREA_AUXILIAR.W_IND_ENDER.Value = 1; !(WAREA_AUXILIAR.W_IND_ENDER > WAREA_AUXILIAR.W_IND_ENDER_N); WAREA_AUXILIAR.W_IND_ENDER.Value += 1)
            {

                R0601_TRATA_ENDERECO_SECTION();
            }

            /*" -2928- MOVE ZEROS TO W-INDEX. */
            _.Move(0, WAREA_AUXILIAR.W_INDEX);

            /*" -2928- PERFORM R0650-TRATA-TELEFONES 3 TIMES. */

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
            /*" -2941- MOVE ZEROS TO OCORR-ENDERECO OF DCLPESSOA-ENDERECO, W-OCORR-ENDERECO. */
            _.Move(0, PESENDER.DCLPESSOA_ENDERECO.OCORR_ENDERECO, WAREA_AUXILIAR.W_OCORR_ENDERECO);

            /*" -2943- PERFORM R0605-TAB-ENDERECO-NOVOS. */

            R0605_TAB_ENDERECO_NOVOS_SECTION();

            /*" -2944- MOVE 'R0601-TRATA-ENDERECO' TO PARAGRAFO. */
            _.Move("R0601-TRATA-ENDERECO", WABEND.FILLER_10.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2946- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.FILLER_10.LOCALIZA_ABEND_2.COMANDO);

            /*" -2948- MOVE W-TB-REG-ENDERECOS-N(W-IND-ENDER) TO REG-ENDERECO */
            _.Move(WAREA_AUXILIAR.W_TB_ENDERECOS_N.W_TAB_END_REG_N[WAREA_AUXILIAR.W_IND_ENDER].W_TB_REG_ENDERECOS_N, LBFPF012.REG_ENDERECO);

            /*" -2950- MOVE 'NAO' TO W-ACHOU-ENDERECO. */
            _.Move("NAO", WAREA_AUXILIAR.W_ACHOU_ENDERECO);

            /*" -2955- PERFORM R0615-VERIFICA-EXISTE-ENDERECO VARYING W-IND-ENDER1 FROM 1 BY 1 UNTIL W-IND-ENDER1 GREATER W-IND-ENDER-A OR W-ACHOU-ENDERECO EQUAL 'SIM' . */

            for (WAREA_AUXILIAR.W_IND_ENDER1.Value = 1; !(WAREA_AUXILIAR.W_IND_ENDER1 > WAREA_AUXILIAR.W_IND_ENDER_A || WAREA_AUXILIAR.W_ACHOU_ENDERECO == "SIM"); WAREA_AUXILIAR.W_IND_ENDER1.Value += 1)
            {

                R0615_VERIFICA_EXISTE_ENDERECO_SECTION();
            }

            /*" -2956- IF W-ACHOU-ENDERECO EQUAL 'NAO' */

            if (WAREA_AUXILIAR.W_ACHOU_ENDERECO == "NAO")
            {

                /*" -2956- PERFORM R0620-INCLUIR-NOVO-ENDERECO. */

                R0620_INCLUIR_NOVO_ENDERECO_SECTION();
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0601_SAIDA*/

        [StopWatch]
        /*" R0605-TAB-ENDERECO-NOVOS-SECTION */
        private void R0605_TAB_ENDERECO_NOVOS_SECTION()
        {
            /*" -2966- MOVE 'R0605-TAB-ENDERECO-NOVOS' TO PARAGRAFO. */
            _.Move("R0605-TAB-ENDERECO-NOVOS", WABEND.FILLER_10.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2968- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.FILLER_10.LOCALIZA_ABEND_2.COMANDO);

            /*" -2970- MOVE ZEROS TO W-IND-ENDER-A. */
            _.Move(0, WAREA_AUXILIAR.W_IND_ENDER_A);

            /*" -2972- MOVE 'NAO' TO W-FIM-CURSOR-ENDERECO. */
            _.Move("NAO", WAREA_AUXILIAR.W_FIM_CURSOR_ENDERECO);

            /*" -2974- PERFORM R0605A-RELACIONA-ENDERECO */

            R0605A_RELACIONA_ENDERECO_SECTION();

            /*" -2976- PERFORM R0610-FETCH-ENDERECO. */

            R0610_FETCH_ENDERECO_SECTION();

            /*" -2977- PERFORM R0605B-CARREGA-TB-ENDERECO UNTIL W-FIM-CURSOR-ENDERECO EQUAL 'SIM' . */

            while (!(WAREA_AUXILIAR.W_FIM_CURSOR_ENDERECO == "SIM"))
            {

                R0605B_CARREGA_TB_ENDERECO_SECTION();
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0605_SAIDA*/

        [StopWatch]
        /*" R0605A-RELACIONA-ENDERECO-SECTION */
        private void R0605A_RELACIONA_ENDERECO_SECTION()
        {
            /*" -2987- MOVE 'R0605A-RELACIONA-ENDERECO' TO PARAGRAFO. */
            _.Move("R0605A-RELACIONA-ENDERECO", WABEND.FILLER_10.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2989- MOVE 'DECLARE PESSOA-ENDERECO' TO COMANDO. */
            _.Move("DECLARE PESSOA-ENDERECO", WABEND.FILLER_10.LOCALIZA_ABEND_2.COMANDO);

            /*" -2992- MOVE PESSOA-COD-PESSOA OF DCLPESSOA TO COD-PESSOA OF DCLPESSOA-ENDERECO. */
            _.Move(PESSOA.DCLPESSOA.PESSOA_COD_PESSOA, PESENDER.DCLPESSOA_ENDERECO.COD_PESSOA);

            /*" -3007- PERFORM R0605A_RELACIONA_ENDERECO_DB_DECLARE_1 */

            R0605A_RELACIONA_ENDERECO_DB_DECLARE_1();

            /*" -3011- IF SQLCODE NOT EQUAL 00 AND SQLCODE NOT EQUAL 100 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != 100)
            {

                /*" -3012- DISPLAY 'PF0641B - FIM ANORMAL' */
                _.Display($"PF0641B - FIM ANORMAL");

                /*" -3013- DISPLAY '          ERRO DECLARE DA TABELA PESSOA-ENDERECO' */
                _.Display($"          ERRO DECLARE DA TABELA PESSOA-ENDERECO");

                /*" -3015- DISPLAY '          CODIGO PESSOA.................  ' COD-PESSOA OF DCLPESSOA-ENDERECO */
                _.Display($"          CODIGO PESSOA.................  {PESENDER.DCLPESSOA_ENDERECO.COD_PESSOA}");

                /*" -3017- DISPLAY '          NUMERO PROPOSTA...............  ' R2-NUM-PROPOSTA OF REG-ENDERECO */
                _.Display($"          NUMERO PROPOSTA...............  {LBFPF012.REG_ENDERECO.R2_NUM_PROPOSTA}");

                /*" -3019- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -3020- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -3022- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


            /*" -3024- MOVE 'OPEN CURSOR ENDERECOS' TO COMANDO. */
            _.Move("OPEN CURSOR ENDERECOS", WABEND.FILLER_10.LOCALIZA_ABEND_2.COMANDO);

            /*" -3024- PERFORM R0605A_RELACIONA_ENDERECO_DB_OPEN_1 */

            R0605A_RELACIONA_ENDERECO_DB_OPEN_1();

            /*" -3027- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -3028- DISPLAY 'PF0641B - FIM ANORMAL' */
                _.Display($"PF0641B - FIM ANORMAL");

                /*" -3029- DISPLAY '          ERRO OPEN TABELA PESSOA-ENDERECO' */
                _.Display($"          ERRO OPEN TABELA PESSOA-ENDERECO");

                /*" -3031- DISPLAY '          CODIGO PESSOA.................  ' COD-PESSOA OF DCLPESSOA-ENDERECO */
                _.Display($"          CODIGO PESSOA.................  {PESENDER.DCLPESSOA_ENDERECO.COD_PESSOA}");

                /*" -3033- DISPLAY '          NUMERO PROPOSTA...............  ' R2-NUM-PROPOSTA OF REG-ENDERECO */
                _.Display($"          NUMERO PROPOSTA...............  {LBFPF012.REG_ENDERECO.R2_NUM_PROPOSTA}");

                /*" -3035- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -3036- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -3036- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R0605A-RELACIONA-ENDERECO-DB-OPEN-1 */
        public void R0605A_RELACIONA_ENDERECO_DB_OPEN_1()
        {
            /*" -3024- EXEC SQL OPEN ENDERECOS END-EXEC. */

            ENDERECOS.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0605A_SAIDA*/

        [StopWatch]
        /*" R0605B-CARREGA-TB-ENDERECO-SECTION */
        private void R0605B_CARREGA_TB_ENDERECO_SECTION()
        {
            /*" -3046- MOVE 'R0605B-CARREGA-TB-ENDERECO' TO PARAGRAFO. */
            _.Move("R0605B-CARREGA-TB-ENDERECO", WABEND.FILLER_10.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3048- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.FILLER_10.LOCALIZA_ABEND_2.COMANDO);

            /*" -3050- ADD 1 TO W-IND-ENDER-A. */
            WAREA_AUXILIAR.W_IND_ENDER_A.Value = WAREA_AUXILIAR.W_IND_ENDER_A + 1;

            /*" -3053- MOVE DCLPESSOA-ENDERECO TO W-TB-REG-ENDERECOS-A(W-IND-ENDER-A) */
            _.Move(PESENDER.DCLPESSOA_ENDERECO, WAREA_AUXILIAR.W_TB_ENDERECOS_A.W_TAB_END_REG_A[WAREA_AUXILIAR.W_IND_ENDER_A].W_TB_REG_ENDERECOS_A);

            /*" -3053- PERFORM R0610-FETCH-ENDERECO. */

            R0610_FETCH_ENDERECO_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0605B_SAIDA*/

        [StopWatch]
        /*" R0610-FETCH-ENDERECO-SECTION */
        private void R0610_FETCH_ENDERECO_SECTION()
        {
            /*" -3062- MOVE 'R0610-FETCH-ENDERECO' TO PARAGRAFO. */
            _.Move("R0610-FETCH-ENDERECO", WABEND.FILLER_10.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3064- MOVE 'FETCH CURSOR ENDERECOS' TO COMANDO. */
            _.Move("FETCH CURSOR ENDERECOS", WABEND.FILLER_10.LOCALIZA_ABEND_2.COMANDO);

            /*" -3075- PERFORM R0610_FETCH_ENDERECO_DB_FETCH_1 */

            R0610_FETCH_ENDERECO_DB_FETCH_1();

            /*" -3078- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -3079- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -3080- MOVE 'SIM' TO W-FIM-CURSOR-ENDERECO */
                    _.Move("SIM", WAREA_AUXILIAR.W_FIM_CURSOR_ENDERECO);

                    /*" -3080- PERFORM R0610_FETCH_ENDERECO_DB_CLOSE_1 */

                    R0610_FETCH_ENDERECO_DB_CLOSE_1();

                    /*" -3082- ELSE */
                }
                else
                {


                    /*" -3083- DISPLAY 'PF0641B - FIM ANORMAL' */
                    _.Display($"PF0641B - FIM ANORMAL");

                    /*" -3084- DISPLAY '          ERRO FETCH CURSOR ENDERECO' */
                    _.Display($"          ERRO FETCH CURSOR ENDERECO");

                    /*" -3086- DISPLAY '          CODIGO PESSOA.................  ' COD-PESSOA OF DCLPESSOA-ENDERECO */
                    _.Display($"          CODIGO PESSOA.................  {PESENDER.DCLPESSOA_ENDERECO.COD_PESSOA}");

                    /*" -3088- DISPLAY '          NUMERO PROPOSTA...............  ' R2-NUM-PROPOSTA OF REG-ENDERECO */
                    _.Display($"          NUMERO PROPOSTA...............  {LBFPF012.REG_ENDERECO.R2_NUM_PROPOSTA}");

                    /*" -3090- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                    _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                    /*" -3091- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -3092- PERFORM R9999-00-FINALIZAR */

                    R9999_00_FINALIZAR_SECTION();

                    /*" -3093- END-IF */
                }


                /*" -3094- ELSE */
            }
            else
            {


                /*" -3095- IF W-IND-ENDER-A > 20 */

                if (WAREA_AUXILIAR.W_IND_ENDER_A > 20)
                {

                    /*" -3096- MOVE 'SIM' TO W-FIM-CURSOR-ENDERECO */
                    _.Move("SIM", WAREA_AUXILIAR.W_FIM_CURSOR_ENDERECO);

                    /*" -3096- PERFORM R0610_FETCH_ENDERECO_DB_CLOSE_2 */

                    R0610_FETCH_ENDERECO_DB_CLOSE_2();

                    /*" -3097- END-IF. */
                }

            }


        }

        [StopWatch]
        /*" R0610-FETCH-ENDERECO-DB-FETCH-1 */
        public void R0610_FETCH_ENDERECO_DB_FETCH_1()
        {
            /*" -3075- EXEC SQL FETCH ENDERECOS INTO :DCLPESSOA-ENDERECO.OCORR-ENDERECO, :DCLPESSOA-ENDERECO.COD-PESSOA, :DCLPESSOA-ENDERECO.ENDERECO, :DCLPESSOA-ENDERECO.TIPO-ENDER, :DCLPESSOA-ENDERECO.BAIRRO, :DCLPESSOA-ENDERECO.CEP, :DCLPESSOA-ENDERECO.CIDADE, :DCLPESSOA-ENDERECO.SIGLA-UF, :DCLPESSOA-ENDERECO.SITUACAO-ENDERECO END-EXEC. */

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
            /*" -3080- EXEC SQL CLOSE ENDERECOS END-EXEC */

            ENDERECOS.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0610_SAIDA*/

        [StopWatch]
        /*" R0610-FETCH-ENDERECO-DB-CLOSE-2 */
        public void R0610_FETCH_ENDERECO_DB_CLOSE_2()
        {
            /*" -3096- EXEC SQL CLOSE ENDERECOS END-EXEC */

            ENDERECOS.Close();

        }

        [StopWatch]
        /*" R0615-VERIFICA-EXISTE-ENDERECO-SECTION */
        private void R0615_VERIFICA_EXISTE_ENDERECO_SECTION()
        {
            /*" -3107- MOVE 'R0615-VERIFICA-EXISTE-ENDERECO' TO PARAGRAFO. */
            _.Move("R0615-VERIFICA-EXISTE-ENDERECO", WABEND.FILLER_10.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3109- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.FILLER_10.LOCALIZA_ABEND_2.COMANDO);

            /*" -3112- MOVE W-TB-REG-ENDERECOS-A(W-IND-ENDER1) TO DCLPESSOA-ENDERECO. */
            _.Move(WAREA_AUXILIAR.W_TB_ENDERECOS_A.W_TAB_END_REG_A[WAREA_AUXILIAR.W_IND_ENDER1].W_TB_REG_ENDERECOS_A, PESENDER.DCLPESSOA_ENDERECO);

            /*" -3124- IF R2-TIPO-ENDER OF REG-ENDERECO EQUAL TIPO-ENDER OF DCLPESSOA-ENDERECO AND R2-ENDERECO OF REG-ENDERECO EQUAL ENDERECO OF DCLPESSOA-ENDERECO AND R2-CIDADE OF REG-ENDERECO EQUAL CIDADE OF DCLPESSOA-ENDERECO AND R2-SIGLA-UF OF REG-ENDERECO EQUAL SIGLA-UF OF DCLPESSOA-ENDERECO AND R2-CEP OF REG-ENDERECO EQUAL CEP OF DCLPESSOA-ENDERECO */

            if (LBFPF012.REG_ENDERECO.R2_TIPO_ENDER == PESENDER.DCLPESSOA_ENDERECO.TIPO_ENDER && LBFPF012.REG_ENDERECO.R2_ENDERECO == PESENDER.DCLPESSOA_ENDERECO.ENDERECO && LBFPF012.REG_ENDERECO.R2_CIDADE == PESENDER.DCLPESSOA_ENDERECO.CIDADE && LBFPF012.REG_ENDERECO.R2_SIGLA_UF == PESENDER.DCLPESSOA_ENDERECO.SIGLA_UF && LBFPF012.REG_ENDERECO.R2_CEP == PESENDER.DCLPESSOA_ENDERECO.CEP)
            {

                /*" -3126- MOVE 'SIM' TO W-ACHOU-ENDERECO. */
                _.Move("SIM", WAREA_AUXILIAR.W_ACHOU_ENDERECO);
            }


            /*" -3130- IF R2-ENDERECO OF REG-ENDERECO EQUAL SPACES AND R2-BAIRRO OF REG-ENDERECO EQUAL SPACES AND R2-CIDADE OF REG-ENDERECO EQUAL SPACES AND R2-SIGLA-UF OF REG-ENDERECO EQUAL SPACES */

            if (LBFPF012.REG_ENDERECO.R2_ENDERECO.IsEmpty() && LBFPF012.REG_ENDERECO.R2_BAIRRO.IsEmpty() && LBFPF012.REG_ENDERECO.R2_CIDADE.IsEmpty() && LBFPF012.REG_ENDERECO.R2_SIGLA_UF.IsEmpty())
            {

                /*" -3130- MOVE 'SIM' TO W-ACHOU-ENDERECO. */
                _.Move("SIM", WAREA_AUXILIAR.W_ACHOU_ENDERECO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0615_SAIDA*/

        [StopWatch]
        /*" R0620-INCLUIR-NOVO-ENDERECO-SECTION */
        private void R0620_INCLUIR_NOVO_ENDERECO_SECTION()
        {
            /*" -3140- MOVE 'R0620-INCLUIR-NOVO-ENDERECO' TO PARAGRAFO. */
            _.Move("R0620-INCLUIR-NOVO-ENDERECO", WABEND.FILLER_10.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3142- MOVE 'INSERT PESSOA-ENDERECO' TO COMANDO. */
            _.Move("INSERT PESSOA-ENDERECO", WABEND.FILLER_10.LOCALIZA_ABEND_2.COMANDO);

            /*" -3144- ADD 1 TO W-QTD-MOV-MR-2 */
            WAREA_AUXILIAR.W_QTD_MOV_MR_2.Value = WAREA_AUXILIAR.W_QTD_MOV_MR_2 + 1;

            /*" -3146- INITIALIZE OCORR-ENDERECO OF DCLPESSOA-ENDERECO. */
            _.Initialize(
                PESENDER.DCLPESSOA_ENDERECO.OCORR_ENDERECO
            );

            /*" -3149- MOVE R2-TIPO-ENDER OF REG-ENDERECO TO TIPO-ENDER OF DCLPESSOA-ENDERECO. */
            _.Move(LBFPF012.REG_ENDERECO.R2_TIPO_ENDER, PESENDER.DCLPESSOA_ENDERECO.TIPO_ENDER);

            /*" -3158- PERFORM R0620_INCLUIR_NOVO_ENDERECO_DB_SELECT_1 */

            R0620_INCLUIR_NOVO_ENDERECO_DB_SELECT_1();

            /*" -3161- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -3162- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -3163- DISPLAY 'NAO ENCONTROU MAX OCORRENCIA ENDERECO' */
                    _.Display($"NAO ENCONTROU MAX OCORRENCIA ENDERECO");

                    /*" -3165- DISPLAY '          CODIGO PESSOA.................  ' COD-PESSOA OF DCLPESSOA-ENDERECO */
                    _.Display($"          CODIGO PESSOA.................  {PESENDER.DCLPESSOA_ENDERECO.COD_PESSOA}");

                    /*" -3167- DISPLAY '          NUMERO PROPOSTA...............  ' R2-NUM-PROPOSTA OF REG-ENDERECO */
                    _.Display($"          NUMERO PROPOSTA...............  {LBFPF012.REG_ENDERECO.R2_NUM_PROPOSTA}");

                    /*" -3169- DISPLAY '          TIPO ENDERECO.................  ' R2-TIPO-ENDER OF REG-ENDERECO */
                    _.Display($"          TIPO ENDERECO.................  {LBFPF012.REG_ENDERECO.R2_TIPO_ENDER}");

                    /*" -3171- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                    _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                    /*" -3172- ELSE */
                }
                else
                {


                    /*" -3173- DISPLAY 'PF0641B - FIM ANORMAL' */
                    _.Display($"PF0641B - FIM ANORMAL");

                    /*" -3174- DISPLAY 'ERRO MAX OCORR_ENDERECO ' */
                    _.Display($"ERRO MAX OCORR_ENDERECO ");

                    /*" -3176- DISPLAY '          CODIGO PESSOA.................  ' COD-PESSOA OF DCLPESSOA-ENDERECO */
                    _.Display($"          CODIGO PESSOA.................  {PESENDER.DCLPESSOA_ENDERECO.COD_PESSOA}");

                    /*" -3178- DISPLAY '          NUMERO PROPOSTA...............  ' R2-NUM-PROPOSTA OF REG-ENDERECO */
                    _.Display($"          NUMERO PROPOSTA...............  {LBFPF012.REG_ENDERECO.R2_NUM_PROPOSTA}");

                    /*" -3180- DISPLAY '          TIPO ENDERECO.................  ' R2-TIPO-ENDER OF REG-ENDERECO */
                    _.Display($"          TIPO ENDERECO.................  {LBFPF012.REG_ENDERECO.R2_TIPO_ENDER}");

                    /*" -3182- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                    _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                    /*" -3183- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -3184- PERFORM R9999-00-FINALIZAR */

                    R9999_00_FINALIZAR_SECTION();

                    /*" -3185- END-IF */
                }


                /*" -3188- MOVE OCORR-ENDERECO OF DCLPESSOA-ENDERECO TO W-OCORR-ENDERECO */
                _.Move(PESENDER.DCLPESSOA_ENDERECO.OCORR_ENDERECO, WAREA_AUXILIAR.W_OCORR_ENDERECO);

                /*" -3190- COMPUTE W-OCORR-ENDERECO = W-OCORR-ENDERECO + 1. */
                WAREA_AUXILIAR.W_OCORR_ENDERECO.Value = WAREA_AUXILIAR.W_OCORR_ENDERECO + 1;
            }


            /*" -3193- MOVE W-OCORR-ENDERECO TO OCORR-ENDERECO OF DCLPESSOA-ENDERECO. */
            _.Move(WAREA_AUXILIAR.W_OCORR_ENDERECO, PESENDER.DCLPESSOA_ENDERECO.OCORR_ENDERECO);

            /*" -3196- MOVE PESSOA-COD-PESSOA OF DCLPESSOA TO COD-PESSOA OF DCLPESSOA-ENDERECO. */
            _.Move(PESSOA.DCLPESSOA.PESSOA_COD_PESSOA, PESENDER.DCLPESSOA_ENDERECO.COD_PESSOA);

            /*" -3199- MOVE R2-ENDERECO OF REG-ENDERECO TO ENDERECO OF DCLPESSOA-ENDERECO. */
            _.Move(LBFPF012.REG_ENDERECO.R2_ENDERECO, PESENDER.DCLPESSOA_ENDERECO.ENDERECO);

            /*" -3202- MOVE R2-TIPO-ENDER OF REG-ENDERECO TO TIPO-ENDER OF DCLPESSOA-ENDERECO. */
            _.Move(LBFPF012.REG_ENDERECO.R2_TIPO_ENDER, PESENDER.DCLPESSOA_ENDERECO.TIPO_ENDER);

            /*" -3205- MOVE R2-BAIRRO OF REG-ENDERECO TO BAIRRO OF DCLPESSOA-ENDERECO. */
            _.Move(LBFPF012.REG_ENDERECO.R2_BAIRRO, PESENDER.DCLPESSOA_ENDERECO.BAIRRO);

            /*" -3208- MOVE R2-CEP OF REG-ENDERECO TO CEP OF DCLPESSOA-ENDERECO. */
            _.Move(LBFPF012.REG_ENDERECO.R2_CEP, PESENDER.DCLPESSOA_ENDERECO.CEP);

            /*" -3211- MOVE R2-CIDADE OF REG-ENDERECO TO CIDADE OF DCLPESSOA-ENDERECO. */
            _.Move(LBFPF012.REG_ENDERECO.R2_CIDADE, PESENDER.DCLPESSOA_ENDERECO.CIDADE);

            /*" -3214- MOVE R2-SIGLA-UF OF REG-ENDERECO TO SIGLA-UF OF DCLPESSOA-ENDERECO. */
            _.Move(LBFPF012.REG_ENDERECO.R2_SIGLA_UF, PESENDER.DCLPESSOA_ENDERECO.SIGLA_UF);

            /*" -3217- MOVE 'A' TO SITUACAO-ENDERECO OF DCLPESSOA-ENDERECO. */
            _.Move("A", PESENDER.DCLPESSOA_ENDERECO.SITUACAO_ENDERECO);

            /*" -3220- MOVE 'PF0641B' TO COD-USUARIO OF DCLPESSOA-ENDERECO. */
            _.Move("PF0641B", PESENDER.DCLPESSOA_ENDERECO.COD_USUARIO);

            /*" -3234- PERFORM R0620_INCLUIR_NOVO_ENDERECO_DB_INSERT_1 */

            R0620_INCLUIR_NOVO_ENDERECO_DB_INSERT_1();

            /*" -3237- IF SQLCODE = 00 OR -803 */

            if (DB.SQLCODE.In("00", "-803"))
            {

                /*" -3238- INITIALIZE SQLCODE */
                _.Initialize(
                    DB.SQLCODE
                );

                /*" -3239- ELSE */
            }
            else
            {


                /*" -3240- DISPLAY 'PF0641B - FIM ANORMAL' */
                _.Display($"PF0641B - FIM ANORMAL");

                /*" -3241- DISPLAY '          ERRO INSERT TABELA PESSOA-ENDERECO' */
                _.Display($"          ERRO INSERT TABELA PESSOA-ENDERECO");

                /*" -3243- DISPLAY '          CODIGO PESSOA.................  ' COD-PESSOA OF DCLPESSOA-ENDERECO */
                _.Display($"          CODIGO PESSOA.................  {PESENDER.DCLPESSOA_ENDERECO.COD_PESSOA}");

                /*" -3245- DISPLAY '          NUMERO DA PROPOSTA............  ' R2-NUM-PROPOSTA OF REG-ENDERECO */
                _.Display($"          NUMERO DA PROPOSTA............  {LBFPF012.REG_ENDERECO.R2_NUM_PROPOSTA}");

                /*" -3247- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -3248- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -3248- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R0620-INCLUIR-NOVO-ENDERECO-DB-SELECT-1 */
        public void R0620_INCLUIR_NOVO_ENDERECO_DB_SELECT_1()
        {
            /*" -3158- EXEC SQL SELECT VALUE(MAX(OCORR_ENDERECO),0) INTO :DCLPESSOA-ENDERECO.OCORR-ENDERECO FROM SEGUROS.PESSOA_ENDERECO WHERE COD_PESSOA = :DCLPESSOA.PESSOA-COD-PESSOA AND TIPO_ENDER = :DCLPESSOA-ENDERECO.TIPO-ENDER AND SITUACAO_ENDERECO = 'A' WITH UR END-EXEC. */

            var r0620_INCLUIR_NOVO_ENDERECO_DB_SELECT_1_Query1 = new R0620_INCLUIR_NOVO_ENDERECO_DB_SELECT_1_Query1()
            {
                TIPO_ENDER = PESENDER.DCLPESSOA_ENDERECO.TIPO_ENDER.ToString(),
                PESSOA_COD_PESSOA = PESSOA.DCLPESSOA.PESSOA_COD_PESSOA.ToString(),
            };

            var executed_1 = R0620_INCLUIR_NOVO_ENDERECO_DB_SELECT_1_Query1.Execute(r0620_INCLUIR_NOVO_ENDERECO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.OCORR_ENDERECO, PESENDER.DCLPESSOA_ENDERECO.OCORR_ENDERECO);
            }


        }

        [StopWatch]
        /*" R0620-INCLUIR-NOVO-ENDERECO-DB-INSERT-1 */
        public void R0620_INCLUIR_NOVO_ENDERECO_DB_INSERT_1()
        {
            /*" -3234- EXEC SQL INSERT INTO SEGUROS.PESSOA_ENDERECO VALUES (:DCLPESSOA-ENDERECO.COD-PESSOA, :DCLPESSOA-ENDERECO.OCORR-ENDERECO, :DCLPESSOA-ENDERECO.ENDERECO, :DCLPESSOA-ENDERECO.TIPO-ENDER, NULL, :DCLPESSOA-ENDERECO.BAIRRO, :DCLPESSOA-ENDERECO.CEP, :DCLPESSOA-ENDERECO.CIDADE, :DCLPESSOA-ENDERECO.SIGLA-UF, :DCLPESSOA-ENDERECO.SITUACAO-ENDERECO, :DCLPESSOA-ENDERECO.COD-USUARIO, CURRENT TIMESTAMP) END-EXEC. */

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
            /*" -3258- MOVE 'R0650-TRATA-TELEFONE' TO PARAGRAFO. */
            _.Move("R0650-TRATA-TELEFONE", WABEND.FILLER_10.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3260- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.FILLER_10.LOCALIZA_ABEND_2.COMANDO);

            /*" -3262- ADD 1 TO W-INDEX. */
            WAREA_AUXILIAR.W_INDEX.Value = WAREA_AUXILIAR.W_INDEX + 1;

            /*" -3264- MOVE 'NAO' TO W-ACHOU-TELEFONE. */
            _.Move("NAO", WAREA_AUXILIAR.W_ACHOU_TELEFONE);

            /*" -3265- IF R1-NUM-FONE (W-INDEX) GREATER ZEROS */

            if (LBFPF011.REG_CLIENTES.R1_TELEFONE[WAREA_AUXILIAR.W_INDEX].R1_NUM_FONE > 00)
            {

                /*" -3266- PERFORM R0655-LER-TELEFONE */

                R0655_LER_TELEFONE_SECTION();

                /*" -3267- IF W-ACHOU-TELEFONE EQUAL 'NAO' */

                if (WAREA_AUXILIAR.W_ACHOU_TELEFONE == "NAO")
                {

                    /*" -3268- PERFORM R0660-INCLUIR-NOVO-TELEFONE */

                    R0660_INCLUIR_NOVO_TELEFONE_SECTION();

                    /*" -3269- END-IF */
                }


                /*" -3269- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0650_SAIDA*/

        [StopWatch]
        /*" R0655-LER-TELEFONE-SECTION */
        private void R0655_LER_TELEFONE_SECTION()
        {
            /*" -3279- MOVE 'R0655-LER-TELEFONE' TO PARAGRAFO. */
            _.Move("R0655-LER-TELEFONE", WABEND.FILLER_10.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3281- MOVE 'SELECT PESSOA-TELEFONE' TO COMANDO. */
            _.Move("SELECT PESSOA-TELEFONE", WABEND.FILLER_10.LOCALIZA_ABEND_2.COMANDO);

            /*" -3287- MOVE PESSOA-COD-PESSOA OF DCLPESSOA TO COD-PESSOA OF DCLPESSOA-TELEFONE. */
            _.Move(PESSOA.DCLPESSOA.PESSOA_COD_PESSOA, PESFONE.DCLPESSOA_TELEFONE.COD_PESSOA);

            /*" -3293- MOVE R1-DDD (W-INDEX) TO DDD OF DCLPESSOA-TELEFONE. */
            _.Move(LBFPF011.REG_CLIENTES.R1_TELEFONE[WAREA_AUXILIAR.W_INDEX].R1_DDD, PESFONE.DCLPESSOA_TELEFONE.DDD);

            /*" -3300- MOVE R1-NUM-FONE (W-INDEX) TO NUM-FONE OF DCLPESSOA-TELEFONE. */
            _.Move(LBFPF011.REG_CLIENTES.R1_TELEFONE[WAREA_AUXILIAR.W_INDEX].R1_NUM_FONE, PESFONE.DCLPESSOA_TELEFONE.NUM_FONE);

            /*" -3303- MOVE W-INDEX TO TIPO-FONE OF DCLPESSOA-TELEFONE */
            _.Move(WAREA_AUXILIAR.W_INDEX, PESFONE.DCLPESSOA_TELEFONE.TIPO_FONE);

            /*" -3312- PERFORM R0655_LER_TELEFONE_DB_SELECT_1 */

            R0655_LER_TELEFONE_DB_SELECT_1();

            /*" -3315- IF SQLCODE EQUAL 00 */

            if (DB.SQLCODE == 00)
            {

                /*" -3316- MOVE 'SIM' TO W-ACHOU-TELEFONE */
                _.Move("SIM", WAREA_AUXILIAR.W_ACHOU_TELEFONE);

                /*" -3317- ELSE */
            }
            else
            {


                /*" -3318- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -3319- MOVE 'NAO' TO W-ACHOU-TELEFONE */
                    _.Move("NAO", WAREA_AUXILIAR.W_ACHOU_TELEFONE);

                    /*" -3320- ELSE */
                }
                else
                {


                    /*" -3321- DISPLAY 'PF0641B - FIM ANORMAL' */
                    _.Display($"PF0641B - FIM ANORMAL");

                    /*" -3322- DISPLAY '          ERRO SELECT TABELA PESSOA-TELEFONE' */
                    _.Display($"          ERRO SELECT TABELA PESSOA-TELEFONE");

                    /*" -3324- DISPLAY '          CODIGO PESSOA.................  ' COD-PESSOA OF DCLPESSOA-TELEFONE */
                    _.Display($"          CODIGO PESSOA.................  {PESFONE.DCLPESSOA_TELEFONE.COD_PESSOA}");

                    /*" -3326- DISPLAY '          NUMERO PROPOSTA...............  ' R2-NUM-PROPOSTA OF REG-ENDERECO */
                    _.Display($"          NUMERO PROPOSTA...............  {LBFPF012.REG_ENDERECO.R2_NUM_PROPOSTA}");

                    /*" -3328- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                    _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                    /*" -3329- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -3329- PERFORM R9999-00-FINALIZAR. */

                    R9999_00_FINALIZAR_SECTION();
                }

            }


        }

        [StopWatch]
        /*" R0655-LER-TELEFONE-DB-SELECT-1 */
        public void R0655_LER_TELEFONE_DB_SELECT_1()
        {
            /*" -3312- EXEC SQL SELECT SITUACAO_FONE INTO :DCLPESSOA-TELEFONE.SITUACAO-FONE FROM SEGUROS.PESSOA_TELEFONE WHERE COD_PESSOA = :DCLPESSOA-TELEFONE.COD-PESSOA AND TIPO_FONE = :DCLPESSOA-TELEFONE.TIPO-FONE AND NUM_FONE = :DCLPESSOA-TELEFONE.NUM-FONE AND DDD = :DCLPESSOA-TELEFONE.DDD WITH UR END-EXEC. */

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
            /*" -3339- MOVE 'R0660-INCLUIR-NOVO-TELEFONE' TO PARAGRAFO. */
            _.Move("R0660-INCLUIR-NOVO-TELEFONE", WABEND.FILLER_10.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3341- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.FILLER_10.LOCALIZA_ABEND_2.COMANDO);

            /*" -3343- PERFORM R0665-OBTER-MAX-TELEFONE. */

            R0665_OBTER_MAX_TELEFONE_SECTION();

            /*" -3346- MOVE SEQ-FONE OF DCLPESSOA-TELEFONE TO W-SEQ-FONE */
            _.Move(PESFONE.DCLPESSOA_TELEFONE.SEQ_FONE, WAREA_AUXILIAR.W_SEQ_FONE);

            /*" -3348- COMPUTE W-SEQ-FONE = W-SEQ-FONE + 1. */
            WAREA_AUXILIAR.W_SEQ_FONE.Value = WAREA_AUXILIAR.W_SEQ_FONE + 1;

            /*" -3348- PERFORM R0670-INCLUIR-TELEFONE. */

            R0670_INCLUIR_TELEFONE_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0660_SAIDA*/

        [StopWatch]
        /*" R0665-OBTER-MAX-TELEFONE-SECTION */
        private void R0665_OBTER_MAX_TELEFONE_SECTION()
        {
            /*" -3358- MOVE 'R0665-OBTER-MAX-TELEFONE' TO PARAGRAFO. */
            _.Move("R0665-OBTER-MAX-TELEFONE", WABEND.FILLER_10.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3360- MOVE 'MAX SEGUROS.PESSOA_TELEFONE' TO COMANDO. */
            _.Move("MAX SEGUROS.PESSOA_TELEFONE", WABEND.FILLER_10.LOCALIZA_ABEND_2.COMANDO);

            /*" -3366- PERFORM R0665_OBTER_MAX_TELEFONE_DB_SELECT_1 */

            R0665_OBTER_MAX_TELEFONE_DB_SELECT_1();

            /*" -3370- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -3371- DISPLAY 'PF0641B - FIM ANORMAL' */
                _.Display($"PF0641B - FIM ANORMAL");

                /*" -3372- DISPLAY '          ERRO SELECT MAX TAB. PESSOA-TELEFONE' */
                _.Display($"          ERRO SELECT MAX TAB. PESSOA-TELEFONE");

                /*" -3374- DISPLAY '          CODIGO PESSOA.................  ' COD-PESSOA OF DCLPESSOA-TELEFONE */
                _.Display($"          CODIGO PESSOA.................  {PESFONE.DCLPESSOA_TELEFONE.COD_PESSOA}");

                /*" -3376- DISPLAY '          NUMERO DA PROPOSTA............  ' R1-NUM-PROPOSTA OF REG-CLIENTES */
                _.Display($"          NUMERO DA PROPOSTA............  {LBFPF011.REG_CLIENTES.R1_NUM_PROPOSTA}");

                /*" -3378- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -3379- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -3379- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R0665-OBTER-MAX-TELEFONE-DB-SELECT-1 */
        public void R0665_OBTER_MAX_TELEFONE_DB_SELECT_1()
        {
            /*" -3366- EXEC SQL SELECT VALUE(MAX(SEQ_FONE),0) INTO :DCLPESSOA-TELEFONE.SEQ-FONE FROM SEGUROS.PESSOA_TELEFONE WHERE COD_PESSOA = :DCLPESSOA-TELEFONE.COD-PESSOA WITH UR END-EXEC. */

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
            /*" -3389- MOVE 'R0670-INCLUI-TELEFONE' TO PARAGRAFO. */
            _.Move("R0670-INCLUI-TELEFONE", WABEND.FILLER_10.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3391- MOVE 'INSERT PESSOA-TELEFONE' TO COMANDO. */
            _.Move("INSERT PESSOA-TELEFONE", WABEND.FILLER_10.LOCALIZA_ABEND_2.COMANDO);

            /*" -3395- MOVE PESSOA-COD-PESSOA OF DCLPESSOA TO COD-PESSOA OF DCLPESSOA-TELEFONE. */
            _.Move(PESSOA.DCLPESSOA.PESSOA_COD_PESSOA, PESFONE.DCLPESSOA_TELEFONE.COD_PESSOA);

            /*" -3398- MOVE W-INDEX TO TIPO-FONE OF DCLPESSOA-TELEFONE. */
            _.Move(WAREA_AUXILIAR.W_INDEX, PESFONE.DCLPESSOA_TELEFONE.TIPO_FONE);

            /*" -3401- MOVE W-SEQ-FONE TO SEQ-FONE OF DCLPESSOA-TELEFONE. */
            _.Move(WAREA_AUXILIAR.W_SEQ_FONE, PESFONE.DCLPESSOA_TELEFONE.SEQ_FONE);

            /*" -3404- MOVE 55 TO DDI OF DCLPESSOA-TELEFONE. */
            _.Move(55, PESFONE.DCLPESSOA_TELEFONE.DDI);

            /*" -3407- MOVE R1-DDD (W-INDEX) TO DDD OF DCLPESSOA-TELEFONE. */
            _.Move(LBFPF011.REG_CLIENTES.R1_TELEFONE[WAREA_AUXILIAR.W_INDEX].R1_DDD, PESFONE.DCLPESSOA_TELEFONE.DDD);

            /*" -3410- MOVE R1-NUM-FONE (W-INDEX) TO NUM-FONE OF DCLPESSOA-TELEFONE. */
            _.Move(LBFPF011.REG_CLIENTES.R1_TELEFONE[WAREA_AUXILIAR.W_INDEX].R1_NUM_FONE, PESFONE.DCLPESSOA_TELEFONE.NUM_FONE);

            /*" -3413- MOVE 'A' TO SITUACAO-FONE OF DCLPESSOA-TELEFONE. */
            _.Move("A", PESFONE.DCLPESSOA_TELEFONE.SITUACAO_FONE);

            /*" -3416- MOVE 'PF0641B' TO COD-USUARIO OF DCLPESSOA-TELEFONE. */
            _.Move("PF0641B", PESFONE.DCLPESSOA_TELEFONE.COD_USUARIO);

            /*" -3427- PERFORM R0670_INCLUIR_TELEFONE_DB_INSERT_1 */

            R0670_INCLUIR_TELEFONE_DB_INSERT_1();

            /*" -3430- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -3431- DISPLAY 'PF0641B - FIM ANORMAL' */
                _.Display($"PF0641B - FIM ANORMAL");

                /*" -3432- DISPLAY '          ERRO INSERT TABELA PESSOA-TELEFONE' */
                _.Display($"          ERRO INSERT TABELA PESSOA-TELEFONE");

                /*" -3434- DISPLAY '          CODIGO PESSOA.................  ' COD-PESSOA OF DCLPESSOA-TELEFONE */
                _.Display($"          CODIGO PESSOA.................  {PESFONE.DCLPESSOA_TELEFONE.COD_PESSOA}");

                /*" -3436- DISPLAY '          NUMERO DA PROPOSTA............  ' R1-NUM-PROPOSTA OF REG-CLIENTES */
                _.Display($"          NUMERO DA PROPOSTA............  {LBFPF011.REG_CLIENTES.R1_NUM_PROPOSTA}");

                /*" -3438- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -3439- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -3439- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R0670-INCLUIR-TELEFONE-DB-INSERT-1 */
        public void R0670_INCLUIR_TELEFONE_DB_INSERT_1()
        {
            /*" -3427- EXEC SQL INSERT INTO SEGUROS.PESSOA_TELEFONE VALUES (:DCLPESSOA-TELEFONE.COD-PESSOA, :DCLPESSOA-TELEFONE.TIPO-FONE, :DCLPESSOA-TELEFONE.SEQ-FONE, :DCLPESSOA-TELEFONE.DDI, :DCLPESSOA-TELEFONE.DDD, :DCLPESSOA-TELEFONE.NUM-FONE, :DCLPESSOA-TELEFONE.SITUACAO-FONE, :DCLPESSOA-TELEFONE.COD-USUARIO, CURRENT TIMESTAMP) END-EXEC. */

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
            /*" -3449- MOVE 'R0700-TRATA-PROPOSTA' TO PARAGRAFO. */
            _.Move("R0700-TRATA-PROPOSTA", WABEND.FILLER_10.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3451- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.FILLER_10.LOCALIZA_ABEND_2.COMANDO);

            /*" -3453- ADD 1 TO W-QTD-MOV-MR-3 */
            WAREA_AUXILIAR.W_QTD_MOV_MR_3.Value = WAREA_AUXILIAR.W_QTD_MOV_MR_3 + 1;

            /*" -3455- PERFORM R0710-TRATA-TAB-RELACIONAMENTO. */

            R0710_TRATA_TAB_RELACIONAMENTO_SECTION();

            /*" -3457- PERFORM R0750-TRATA-TAB-IDE-RELACIONAM. */

            R0750_TRATA_TAB_IDE_RELACIONAM_SECTION();

            /*" -3459- PERFORM R0760-TRATA-PROP-FIDELIZACAO. */

            R0760_TRATA_PROP_FIDELIZACAO_SECTION();

            /*" -3459- PERFORM R0790-GERA-HIST-FIDELIZACAO. */

            R0790_GERA_HIST_FIDELIZACAO_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0700_SAIDA*/

        [StopWatch]
        /*" R0710-TRATA-TAB-RELACIONAMENTO-SECTION */
        private void R0710_TRATA_TAB_RELACIONAMENTO_SECTION()
        {
            /*" -3469- MOVE 'R0710-TRATA-TAB-RELACIONAMENTO' TO PARAGRAFO. */
            _.Move("R0710-TRATA-TAB-RELACIONAMENTO", WABEND.FILLER_10.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3471- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.FILLER_10.LOCALIZA_ABEND_2.COMANDO);

            /*" -3473- PERFORM R0715-DETERMINA-RELACIONAMENTO */

            R0715_DETERMINA_RELACIONAMENTO_SECTION();

            /*" -3475- MOVE 'NAO' TO W-ACHOU-RELACIONAMENTO. */
            _.Move("NAO", WAREA_AUXILIAR.W_ACHOU_RELACIONAMENTO);

            /*" -3477- PERFORM R0720-VERIFICA-EXISTE-RELACION. */

            R0720_VERIFICA_EXISTE_RELACION_SECTION();

            /*" -3478- IF W-ACHOU-RELACIONAMENTO EQUAL 'NAO' */

            if (WAREA_AUXILIAR.W_ACHOU_RELACIONAMENTO == "NAO")
            {

                /*" -3478- PERFORM R0730-GERA-RELACIONAMENTO. */

                R0730_GERA_RELACIONAMENTO_SECTION();
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0710_SAIDA*/

        [StopWatch]
        /*" R0715-DETERMINA-RELACIONAMENTO-SECTION */
        private void R0715_DETERMINA_RELACIONAMENTO_SECTION()
        {
            /*" -3488- MOVE 'R0715-DETERMINA-RELACIONAMENTO' TO PARAGRAFO. */
            _.Move("R0715-DETERMINA-RELACIONAMENTO", WABEND.FILLER_10.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3490- MOVE 'SELECT PRODUTOS_SIVPF' TO COMANDO. */
            _.Move("SELECT PRODUTOS_SIVPF", WABEND.FILLER_10.LOCALIZA_ABEND_2.COMANDO);

            /*" -3493- MOVE 1 TO PRDSIVPF-COD-EMPRESA-SIVPF OF DCLPRODUTOS-SIVPF */
            _.Move(1, PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_EMPRESA_SIVPF);

            /*" -3497- MOVE R3-COD-PRODUTO OF REG-PROPOSTA-SASSE TO PRDSIVPF-COD-PRODUTO-SIVPF OF DCLPRODUTOS-SIVPF. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_COD_PRODUTO, PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_PRODUTO_SIVPF);

            /*" -3509- PERFORM R0715_DETERMINA_RELACIONAMENTO_DB_SELECT_1 */

            R0715_DETERMINA_RELACIONAMENTO_DB_SELECT_1();

            /*" -3512- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -3513- DISPLAY 'PF0641B - FIM ANORMAL' */
                _.Display($"PF0641B - FIM ANORMAL");

                /*" -3514- DISPLAY '          ERRO SELECT TAB. PRODUTOS-SIVPF' */
                _.Display($"          ERRO SELECT TAB. PRODUTOS-SIVPF");

                /*" -3516- DISPLAY '          NOME EMPRESA.................. ' RH-NOME OF REG-HEADER */
                _.Display($"          NOME EMPRESA.................. {LXFPF990.REG_HEADER.RH_NOME}");

                /*" -3518- DISPLAY '          CODIGO DO PRODUTO............. ' PRDSIVPF-COD-PRODUTO-SIVPF OF DCLPRODUTOS-SIVPF */
                _.Display($"          CODIGO DO PRODUTO............. {PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_PRODUTO_SIVPF}");

                /*" -3520- DISPLAY '       NUMERO DA PROPOSTA............  ' R3-NUM-PROPOSTA OF REG-PROPOSTA-SASSE */
                _.Display($"       NUMERO DA PROPOSTA............  {LXFCT004.REG_PROPOSTA_SASSE.R3_NUM_PROPOSTA}");

                /*" -3522- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -3523- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -3525- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


            /*" -3526- MOVE PRDSIVPF-COD-RELAC OF DCLPRODUTOS-SIVPF TO W-COD-RELACION. */
            _.Move(PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_RELAC, WAREA_AUXILIAR.W_COD_RELACION);

        }

        [StopWatch]
        /*" R0715-DETERMINA-RELACIONAMENTO-DB-SELECT-1 */
        public void R0715_DETERMINA_RELACIONAMENTO_DB_SELECT_1()
        {
            /*" -3509- EXEC SQL SELECT DISTINCT COD_PRODUTO_SIVPF, COD_RELAC INTO :DCLPRODUTOS-SIVPF.PRDSIVPF-COD-PRODUTO-SIVPF, :DCLPRODUTOS-SIVPF.PRDSIVPF-COD-RELAC FROM SEGUROS.PRODUTOS_SIVPF WHERE COD_EMPRESA_SIVPF = :DCLPRODUTOS-SIVPF.PRDSIVPF-COD-EMPRESA-SIVPF AND COD_PRODUTO_SIVPF = :DCLPRODUTOS-SIVPF.PRDSIVPF-COD-PRODUTO-SIVPF ORDER BY COD_PRODUTO_SIVPF, COD_RELAC WITH UR END-EXEC. */

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
            /*" -3536- MOVE 'R0720-VERIFICA-EXISTE-RELACION' TO PARAGRAFO. */
            _.Move("R0720-VERIFICA-EXISTE-RELACION", WABEND.FILLER_10.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3538- MOVE 'SELECT PESSOAS_TIPORELAC' TO COMANDO. */
            _.Move("SELECT PESSOAS_TIPORELAC", WABEND.FILLER_10.LOCALIZA_ABEND_2.COMANDO);

            /*" -3541- MOVE PESSOA-COD-PESSOA OF DCLPESSOA TO COD-PESSOA OF DCLR-PESSOA-TIPORELAC. */
            _.Move(PESSOA.DCLPESSOA.PESSOA_COD_PESSOA, RTPRELAC.DCLR_PESSOA_TIPORELAC.COD_PESSOA);

            /*" -3544- MOVE W-COD-RELACION TO COD-RELAC OF DCLR-PESSOA-TIPORELAC. */
            _.Move(WAREA_AUXILIAR.W_COD_RELACION, RTPRELAC.DCLR_PESSOA_TIPORELAC.COD_RELAC);

            /*" -3553- PERFORM R0720_VERIFICA_EXISTE_RELACION_DB_SELECT_1 */

            R0720_VERIFICA_EXISTE_RELACION_DB_SELECT_1();

            /*" -3556- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -3557- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -3558- MOVE 'NAO' TO W-ACHOU-RELACIONAMENTO */
                    _.Move("NAO", WAREA_AUXILIAR.W_ACHOU_RELACIONAMENTO);

                    /*" -3559- ELSE */
                }
                else
                {


                    /*" -3560- DISPLAY 'PF0641B - FIM ANORMAL' */
                    _.Display($"PF0641B - FIM ANORMAL");

                    /*" -3561- DISPLAY '          ERRO SELECT TAB. PESSOA-TIPORELAC' */
                    _.Display($"          ERRO SELECT TAB. PESSOA-TIPORELAC");

                    /*" -3563- DISPLAY '          CODIGO PESSOA.................  ' COD-PESSOA OF DCLR-PESSOA-TIPORELAC */
                    _.Display($"          CODIGO PESSOA.................  {RTPRELAC.DCLR_PESSOA_TIPORELAC.COD_PESSOA}");

                    /*" -3565- DISPLAY '          CODIGO RELACIONAMENTO.........  ' COD-RELAC OF DCLR-PESSOA-TIPORELAC */
                    _.Display($"          CODIGO RELACIONAMENTO.........  {RTPRELAC.DCLR_PESSOA_TIPORELAC.COD_RELAC}");

                    /*" -3567- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                    _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                    /*" -3568- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -3569- PERFORM R9999-00-FINALIZAR */

                    R9999_00_FINALIZAR_SECTION();

                    /*" -3570- ELSE */
                }

            }
            else
            {


                /*" -3570- MOVE 'SIM' TO W-ACHOU-RELACIONAMENTO. */
                _.Move("SIM", WAREA_AUXILIAR.W_ACHOU_RELACIONAMENTO);
            }


        }

        [StopWatch]
        /*" R0720-VERIFICA-EXISTE-RELACION-DB-SELECT-1 */
        public void R0720_VERIFICA_EXISTE_RELACION_DB_SELECT_1()
        {
            /*" -3553- EXEC SQL SELECT COD_PESSOA, COD_RELAC INTO :DCLR-PESSOA-TIPORELAC.COD-PESSOA, :DCLR-PESSOA-TIPORELAC.COD-RELAC FROM SEGUROS.R_PESSOA_TIPORELAC WHERE COD_PESSOA = :DCLR-PESSOA-TIPORELAC.COD-PESSOA AND COD_RELAC = :DCLR-PESSOA-TIPORELAC.COD-RELAC WITH UR END-EXEC. */

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
            /*" -3580- MOVE 'R0730-GERA-RELACIONAMENTO' TO PARAGRAFO */
            _.Move("R0730-GERA-RELACIONAMENTO", WABEND.FILLER_10.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3582- MOVE 'INSERT PESSOAS_TIPORELAC' TO COMANDO */
            _.Move("INSERT PESSOAS_TIPORELAC", WABEND.FILLER_10.LOCALIZA_ABEND_2.COMANDO);

            /*" -3585- MOVE PESSOA-COD-PESSOA OF DCLPESSOA TO COD-PESSOA OF DCLR-PESSOA-TIPORELAC. */
            _.Move(PESSOA.DCLPESSOA.PESSOA_COD_PESSOA, RTPRELAC.DCLR_PESSOA_TIPORELAC.COD_PESSOA);

            /*" -3588- MOVE W-COD-RELACION TO COD-RELAC OF DCLR-PESSOA-TIPORELAC. */
            _.Move(WAREA_AUXILIAR.W_COD_RELACION, RTPRELAC.DCLR_PESSOA_TIPORELAC.COD_RELAC);

            /*" -3592- PERFORM R0730_GERA_RELACIONAMENTO_DB_INSERT_1 */

            R0730_GERA_RELACIONAMENTO_DB_INSERT_1();

            /*" -3595- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -3596- DISPLAY 'PF0641B - FIM ANORMAL' */
                _.Display($"PF0641B - FIM ANORMAL");

                /*" -3597- DISPLAY '          ERRO INSERT TAB. PESSOA-TIPORELAC' */
                _.Display($"          ERRO INSERT TAB. PESSOA-TIPORELAC");

                /*" -3599- DISPLAY '          CODIGO PESSOA.................  ' COD-PESSOA OF DCLR-PESSOA-TIPORELAC */
                _.Display($"          CODIGO PESSOA.................  {RTPRELAC.DCLR_PESSOA_TIPORELAC.COD_PESSOA}");

                /*" -3601- DISPLAY '          CODIGO RELACIONAMENTO.........  ' COD-RELAC OF DCLR-PESSOA-TIPORELAC */
                _.Display($"          CODIGO RELACIONAMENTO.........  {RTPRELAC.DCLR_PESSOA_TIPORELAC.COD_RELAC}");

                /*" -3603- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -3604- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -3604- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R0730-GERA-RELACIONAMENTO-DB-INSERT-1 */
        public void R0730_GERA_RELACIONAMENTO_DB_INSERT_1()
        {
            /*" -3592- EXEC SQL INSERT INTO SEGUROS.R_PESSOA_TIPORELAC VALUES (:DCLR-PESSOA-TIPORELAC.COD-PESSOA, :DCLR-PESSOA-TIPORELAC.COD-RELAC) END-EXEC. */

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
            /*" -3615- PERFORM R0755-OBTER-MAX-ID-RELACIONAM. */

            R0755_OBTER_MAX_ID_RELACIONAM_SECTION();

            /*" -3616- MOVE 'R0750-TRATA-TAB-RELACIONAM' TO PARAGRAFO. */
            _.Move("R0750-TRATA-TAB-RELACIONAM", WABEND.FILLER_10.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3618- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.FILLER_10.LOCALIZA_ABEND_2.COMANDO);

            /*" -3621- MOVE NUM-IDENTIFICACAO OF DCLIDENTIFICA-RELAC TO W-NUM-IDENTIF. */
            _.Move(IDERELAC.DCLIDENTIFICA_RELAC.NUM_IDENTIFICACAO, WAREA_AUXILIAR.W_NUM_IDENTIF);

            /*" -3624- COMPUTE W-NUM-IDENTIF = W-NUM-IDENTIF + 1. */
            WAREA_AUXILIAR.W_NUM_IDENTIF.Value = WAREA_AUXILIAR.W_NUM_IDENTIF + 1;

            /*" -3627- MOVE W-NUM-IDENTIF TO NUM-IDENTIFICACAO OF DCLIDENTIFICA-RELAC. */
            _.Move(WAREA_AUXILIAR.W_NUM_IDENTIF, IDERELAC.DCLIDENTIFICA_RELAC.NUM_IDENTIFICACAO);

            /*" -3630- MOVE COD-PESSOA OF DCLR-PESSOA-TIPORELAC TO COD-PESSOA OF DCLIDENTIFICA-RELAC. */
            _.Move(RTPRELAC.DCLR_PESSOA_TIPORELAC.COD_PESSOA, IDERELAC.DCLIDENTIFICA_RELAC.COD_PESSOA);

            /*" -3633- MOVE COD-RELAC OF DCLR-PESSOA-TIPORELAC TO COD-RELAC OF DCLIDENTIFICA-RELAC. */
            _.Move(RTPRELAC.DCLR_PESSOA_TIPORELAC.COD_RELAC, IDERELAC.DCLIDENTIFICA_RELAC.COD_RELAC);

            /*" -3636- MOVE 'PF0641B' TO COD-USUARIO OF DCLIDENTIFICA-RELAC. */
            _.Move("PF0641B", IDERELAC.DCLIDENTIFICA_RELAC.COD_USUARIO);

            /*" -3643- PERFORM R0750_TRATA_TAB_IDE_RELACIONAM_DB_INSERT_1 */

            R0750_TRATA_TAB_IDE_RELACIONAM_DB_INSERT_1();

            /*" -3646- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -3647- DISPLAY 'PF0641B - FIM ANORMAL' */
                _.Display($"PF0641B - FIM ANORMAL");

                /*" -3648- DISPLAY '          ERRO INSERT TABELA IDENTIFICA-RELAC.' */
                _.Display($"          ERRO INSERT TABELA IDENTIFICA-RELAC.");

                /*" -3650- DISPLAY '          NUM IDENTIFICACAO.............  ' NUM-IDENTIFICACAO OF DCLIDENTIFICA-RELAC */
                _.Display($"          NUM IDENTIFICACAO.............  {IDERELAC.DCLIDENTIFICA_RELAC.NUM_IDENTIFICACAO}");

                /*" -3652- DISPLAY '          CODIGO PESSOA.................  ' COD-PESSOA OF DCLIDENTIFICA-RELAC */
                _.Display($"          CODIGO PESSOA.................  {IDERELAC.DCLIDENTIFICA_RELAC.COD_PESSOA}");

                /*" -3654- DISPLAY '          CODIGO RELACIONAMENTO.........  ' COD-RELAC OF DCLIDENTIFICA-RELAC */
                _.Display($"          CODIGO RELACIONAMENTO.........  {IDERELAC.DCLIDENTIFICA_RELAC.COD_RELAC}");

                /*" -3656- DISPLAY '          NUMERO PROPOSTA...............  ' R2-NUM-PROPOSTA OF REG-ENDERECO */
                _.Display($"          NUMERO PROPOSTA...............  {LBFPF012.REG_ENDERECO.R2_NUM_PROPOSTA}");

                /*" -3658- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -3659- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -3659- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R0750-TRATA-TAB-IDE-RELACIONAM-DB-INSERT-1 */
        public void R0750_TRATA_TAB_IDE_RELACIONAM_DB_INSERT_1()
        {
            /*" -3643- EXEC SQL INSERT INTO SEGUROS.IDENTIFICA_RELAC VALUES (:DCLIDENTIFICA-RELAC.NUM-IDENTIFICACAO, :DCLIDENTIFICA-RELAC.COD-PESSOA, :DCLIDENTIFICA-RELAC.COD-RELAC, :DCLIDENTIFICA-RELAC.COD-USUARIO, CURRENT TIMESTAMP) END-EXEC. */

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
            /*" -3669- MOVE 'R0755-OBTER-MAX-ID-RELACIONAM' TO PARAGRAFO. */
            _.Move("R0755-OBTER-MAX-ID-RELACIONAM", WABEND.FILLER_10.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3671- MOVE 'MAX IDENTIFICA_RELAC' TO COMANDO. */
            _.Move("MAX IDENTIFICA_RELAC", WABEND.FILLER_10.LOCALIZA_ABEND_2.COMANDO);

            /*" -3674- MOVE COD-PESSOA OF DCLR-PESSOA-TIPORELAC TO COD-PESSOA OF DCLIDENTIFICA-RELAC. */
            _.Move(RTPRELAC.DCLR_PESSOA_TIPORELAC.COD_PESSOA, IDERELAC.DCLIDENTIFICA_RELAC.COD_PESSOA);

            /*" -3677- MOVE COD-RELAC OF DCLR-PESSOA-TIPORELAC TO COD-RELAC OF DCLIDENTIFICA-RELAC. */
            _.Move(RTPRELAC.DCLR_PESSOA_TIPORELAC.COD_RELAC, IDERELAC.DCLIDENTIFICA_RELAC.COD_RELAC);

            /*" -3682- PERFORM R0755_OBTER_MAX_ID_RELACIONAM_DB_SELECT_1 */

            R0755_OBTER_MAX_ID_RELACIONAM_DB_SELECT_1();

            /*" -3685- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -3686- DISPLAY 'PF0641B - FIM ANORMAL' */
                _.Display($"PF0641B - FIM ANORMAL");

                /*" -3687- DISPLAY '          ERRO SELECT MAX TAB. IDENTIFICA-RELAC' */
                _.Display($"          ERRO SELECT MAX TAB. IDENTIFICA-RELAC");

                /*" -3689- DISPLAY '          CODIGO PESSOA.................  ' COD-PESSOA OF DCLIDENTIFICA-RELAC */
                _.Display($"          CODIGO PESSOA.................  {IDERELAC.DCLIDENTIFICA_RELAC.COD_PESSOA}");

                /*" -3691- DISPLAY '          CODIGO RELACIONAMENTO.........  ' COD-RELAC OF DCLIDENTIFICA-RELAC */
                _.Display($"          CODIGO RELACIONAMENTO.........  {IDERELAC.DCLIDENTIFICA_RELAC.COD_RELAC}");

                /*" -3693- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -3694- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -3694- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R0755-OBTER-MAX-ID-RELACIONAM-DB-SELECT-1 */
        public void R0755_OBTER_MAX_ID_RELACIONAM_DB_SELECT_1()
        {
            /*" -3682- EXEC SQL SELECT VALUE(MAX(NUM_IDENTIFICACAO),0) INTO :DCLIDENTIFICA-RELAC.NUM-IDENTIFICACAO FROM SEGUROS.IDENTIFICA_RELAC WITH UR END-EXEC. */

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
            /*" -3704- MOVE 'R0760-TRATA-PROP-FIDELIZACAO' TO PARAGRAFO. */
            _.Move("R0760-TRATA-PROP-FIDELIZACAO", WABEND.FILLER_10.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3706- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.FILLER_10.LOCALIZA_ABEND_2.COMANDO);

            /*" -3710- MOVE R3-NUM-PROPOSTA OF REG-PROPOSTA-SASSE TO NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ W-NUM-PROPOSTA. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_NUM_PROPOSTA, PROPFID.DCLPROPOSTA_FIDELIZ.NUM_PROPOSTA_SIVPF, WREA88.W_NUM_PROPOSTA);

            /*" -3713- MOVE R3-NUM-SICOB OF REG-PROPOSTA-SASSE TO NUM-SICOB OF DCLPROPOSTA-FIDELIZ. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_NUM_SICOB, PROPFID.DCLPROPOSTA_FIDELIZ.NUM_SICOB);

            /*" -3715- PERFORM R0761-00-OBTER-VAL-TARIFA. */

            R0761_00_OBTER_VAL_TARIFA_SECTION();

            /*" -3718- MOVE 'S' TO SITUACAO-ENVIO OF DCLPROPOSTA-FIDELIZ. */
            _.Move("S", PROPFID.DCLPROPOSTA_FIDELIZ.SITUACAO_ENVIO);

            /*" -3721- MOVE 6 TO ORIGEM-PROPOSTA OF DCLPROPOSTA-FIDELIZ. */
            _.Move(6, PROPFID.DCLPROPOSTA_FIDELIZ.ORIGEM_PROPOSTA);

            /*" -3722- IF CANAL-VENDA-PAPEL */

            if (WREA88.FILLER_19.W_CANAL_PROPOSTA["CANAL_VENDA_PAPEL"])
            {

                /*" -3724- MOVE 2 TO CANAL-PROPOSTA OF DCLPROPOSTA-FIDELIZ */
                _.Move(2, PROPFID.DCLPROPOSTA_FIDELIZ.CANAL_PROPOSTA);

                /*" -3725- ELSE */
            }
            else
            {


                /*" -3728- MOVE W-CANAL-PROPOSTA TO CANAL-PROPOSTA OF DCLPROPOSTA-FIDELIZ. */
                _.Move(WREA88.FILLER_19.W_CANAL_PROPOSTA, PROPFID.DCLPROPOSTA_FIDELIZ.CANAL_PROPOSTA);
            }


            /*" -3731- MOVE 'MAN' TO R3-SIT-PROPOSTA OF REG-PROPOSTA-SASSE. */
            _.Move("MAN", LXFCT004.REG_PROPOSTA_SASSE.R3_SIT_PROPOSTA);

            /*" -3734- MOVE 'PAG' TO R3-SIT-COBRANCA OF REG-PROPOSTA-SASSE. */
            _.Move("PAG", LXFCT004.REG_PROPOSTA_SASSE.R3_SIT_COBRANCA);

            /*" -3737- MOVE VAL-TARIFA OF DCLTARIFA-BALCAO-CEF TO R3-VAL-TARIFA OF REG-PROPOSTA-SASSE. */
            _.Move(TARIBCEF.DCLTARIFA_BALCAO_CEF.VAL_TARIFA, LXFCT004.REG_PROPOSTA_SASSE.R3_VAL_TARIFA);

            /*" -3740- MOVE ZEROS TO R3-VAL-COMISSAO OF REG-PROPOSTA-SASSE. */
            _.Move(0, LXFCT004.REG_PROPOSTA_SASSE.R3_VAL_COMISSAO);

            /*" -3743- MOVE NUM-IDENTIFICACAO OF DCLIDENTIFICA-RELAC TO NUM-IDENTIFICACAO OF DCLPROPOSTA-FIDELIZ. */
            _.Move(IDERELAC.DCLIDENTIFICA_RELAC.NUM_IDENTIFICACAO, PROPFID.DCLPROPOSTA_FIDELIZ.NUM_IDENTIFICACAO);

            /*" -3746- MOVE R3-DATA-PROPOSTA OF REG-PROPOSTA-SASSE TO W-DATA-TRABALHO. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_DATA_PROPOSTA, WAREA_AUXILIAR.W_DATA_TRABALHO);

            /*" -3748- MOVE W-DIA-TRABALHO TO W-DIA-SQL OF W-DATA-SQL1. */
            _.Move(WAREA_AUXILIAR.W_DIA_TRABALHO, W_DATA_SQL1.W_DIA_SQL);

            /*" -3750- MOVE W-MES-TRABALHO TO W-MES-SQL OF W-DATA-SQL1. */
            _.Move(WAREA_AUXILIAR.W_MES_TRABALHO, W_DATA_SQL1.W_MES_SQL);

            /*" -3753- MOVE W-ANO-TRABALHO TO W-ANO-SQL OF W-DATA-SQL1. */
            _.Move(WAREA_AUXILIAR.W_ANO_TRABALHO, W_DATA_SQL1.W_ANO_SQL);

            /*" -3757- MOVE '-' TO W-BARRA1 OF W-DATA-SQL1, W-BARRA2 OF W-DATA-SQL1. */
            _.Move("-", W_DATA_SQL1.W_BARRA1_1);
            _.Move("-", W_DATA_SQL1.W_BARRA2_1);


            /*" -3760- MOVE W-DATA-SQL TO DATA-PROPOSTA OF DCLPROPOSTA-FIDELIZ. */
            _.Move(W_DATA_SQL, PROPFID.DCLPROPOSTA_FIDELIZ.DATA_PROPOSTA);

            /*" -3763- MOVE R3-COD-PRODUTO OF REG-PROPOSTA-SASSE TO COD-PRODUTO-SIVPF OF DCLPROPOSTA-FIDELIZ. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_COD_PRODUTO, PROPFID.DCLPROPOSTA_FIDELIZ.COD_PRODUTO_SIVPF);

            /*" -3766- MOVE PRDSIVPF-COD-EMPRESA-SIVPF OF DCLPRODUTOS-SIVPF TO COD-EMPRESA-SIVPF OF DCLPROPOSTA-FIDELIZ. */
            _.Move(PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_EMPRESA_SIVPF, PROPFID.DCLPROPOSTA_FIDELIZ.COD_EMPRESA_SIVPF);

            /*" -3769- MOVE R3-AGECOBR OF REG-PROPOSTA-SASSE TO AGECOBR OF DCLPROPOSTA-FIDELIZ. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_AGECOBR, PROPFID.DCLPROPOSTA_FIDELIZ.AGECOBR);

            /*" -3772- MOVE R3-DIA-DEBITO OF REG-PROPOSTA-SASSE TO DIA-DEBITO OF DCLPROPOSTA-FIDELIZ. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_DIA_DEBITO, PROPFID.DCLPROPOSTA_FIDELIZ.DIA_DEBITO);

            /*" -3775- MOVE R3-OPCAOPAG OF REG-PROPOSTA-SASSE TO OPCAOPAG OF DCLPROPOSTA-FIDELIZ. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_OPCAOPAG, PROPFID.DCLPROPOSTA_FIDELIZ.OPCAOPAG);

            /*" -3778- MOVE R3-AGECTADEB OF REG-PROPOSTA-SASSE TO AGECTADEB OF DCLPROPOSTA-FIDELIZ. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_CONTA_DEBITO.R3_AGECTADEB, PROPFID.DCLPROPOSTA_FIDELIZ.AGECTADEB);

            /*" -3781- MOVE R3-OPRCTADEB OF REG-PROPOSTA-SASSE TO OPRCTADEB OF DCLPROPOSTA-FIDELIZ. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_CONTA_DEBITO.R3_OPRCTADEB, PROPFID.DCLPROPOSTA_FIDELIZ.OPRCTADEB);

            /*" -3784- MOVE R3-NUMCTADEB OF REG-PROPOSTA-SASSE TO NUMCTADEB OF DCLPROPOSTA-FIDELIZ. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_CONTA_DEBITO.R3_NUMCTADEB, PROPFID.DCLPROPOSTA_FIDELIZ.NUMCTADEB);

            /*" -3787- MOVE R3-DIGCTADEB OF REG-PROPOSTA-SASSE TO DIGCTADEB OF DCLPROPOSTA-FIDELIZ. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_CONTA_DEBITO.R3_DIGCTADEB, PROPFID.DCLPROPOSTA_FIDELIZ.DIGCTADEB);

            /*" -3790- MOVE R3-PCT-DESCONTO OF REG-PROPOSTA-SASSE TO PERC-DESCONTO OF DCLPROPOSTA-FIDELIZ. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_PCT_DESCONTO, PROPFID.DCLPROPOSTA_FIDELIZ.PERC_DESCONTO);

            /*" -3793- MOVE R3-NRMATRVEN OF REG-PROPOSTA-SASSE TO NRMATRVEN OF DCLPROPOSTA-FIDELIZ. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_NRMATRVEN, PROPFID.DCLPROPOSTA_FIDELIZ.NRMATRVEN);

            /*" -3799- MOVE ZEROS TO AGECTAVEN OF DCLPROPOSTA-FIDELIZ , OPRCTAVEN OF DCLPROPOSTA-FIDELIZ , NUMCTAVEN OF DCLPROPOSTA-FIDELIZ , DIGCTAVEN OF DCLPROPOSTA-FIDELIZ. */
            _.Move(0, PROPFID.DCLPROPOSTA_FIDELIZ.AGECTAVEN, PROPFID.DCLPROPOSTA_FIDELIZ.OPRCTAVEN, PROPFID.DCLPROPOSTA_FIDELIZ.NUMCTAVEN, PROPFID.DCLPROPOSTA_FIDELIZ.DIGCTAVEN);

            /*" -3802- MOVE R3-CGC-CONVENENTE OF REG-PROPOSTA-SASSE TO CGC-CONVENENTE OF DCLPROPOSTA-FIDELIZ. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_CGC_CONVENENTE, PROPFID.DCLPROPOSTA_FIDELIZ.CGC_CONVENENTE);

            /*" -3805- MOVE R3-NOME-CONVENENTE OF REG-PROPOSTA-SASSE TO NOME-CONVENENTE OF DCLPROPOSTA-FIDELIZ. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_NOME_CONVENENTE, PROPFID.DCLPROPOSTA_FIDELIZ.NOME_CONVENENTE);

            /*" -3808- MOVE ZEROS TO NRMATRCON OF DCLPROPOSTA-FIDELIZ. */
            _.Move(0, PROPFID.DCLPROPOSTA_FIDELIZ.NRMATRCON);

            /*" -3811- MOVE R3-DTQITBCO OF REG-PROPOSTA-SASSE TO W-DATA-TRABALHO. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_DTQITBCO, WAREA_AUXILIAR.W_DATA_TRABALHO);

            /*" -3813- MOVE W-DIA-TRABALHO TO W-DIA-SQL OF W-DATA-SQL1. */
            _.Move(WAREA_AUXILIAR.W_DIA_TRABALHO, W_DATA_SQL1.W_DIA_SQL);

            /*" -3815- MOVE W-MES-TRABALHO TO W-MES-SQL OF W-DATA-SQL1. */
            _.Move(WAREA_AUXILIAR.W_MES_TRABALHO, W_DATA_SQL1.W_MES_SQL);

            /*" -3818- MOVE W-ANO-TRABALHO TO W-ANO-SQL OF W-DATA-SQL1. */
            _.Move(WAREA_AUXILIAR.W_ANO_TRABALHO, W_DATA_SQL1.W_ANO_SQL);

            /*" -3822- MOVE '-' TO W-BARRA1 OF W-DATA-SQL1, W-BARRA2 OF W-DATA-SQL1. */
            _.Move("-", W_DATA_SQL1.W_BARRA1_1);
            _.Move("-", W_DATA_SQL1.W_BARRA2_1);


            /*" -3825- MOVE W-DATA-SQL TO DTQITBCO OF DCLPROPOSTA-FIDELIZ. */
            _.Move(W_DATA_SQL, PROPFID.DCLPROPOSTA_FIDELIZ.DTQITBCO);

            /*" -3828- MOVE R3-VAL-PAGO OF REG-PROPOSTA-SASSE TO VAL-PAGO OF DCLPROPOSTA-FIDELIZ. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_VAL_PAGO, PROPFID.DCLPROPOSTA_FIDELIZ.VAL_PAGO);

            /*" -3831- MOVE R3-AGEPGTO OF REG-PROPOSTA-SASSE TO AGEPGTO OF DCLPROPOSTA-FIDELIZ. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_AGEPGTO, PROPFID.DCLPROPOSTA_FIDELIZ.AGEPGTO);

            /*" -3834- MOVE R3-VAL-TARIFA OF REG-PROPOSTA-SASSE TO VAL-TARIFA OF DCLPROPOSTA-FIDELIZ. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_VAL_TARIFA, PROPFID.DCLPROPOSTA_FIDELIZ.VAL_TARIFA);

            /*" -3837- MOVE ZEROS TO VAL-IOF OF DCLPROPOSTA-FIDELIZ. */
            _.Move(0, PROPFID.DCLPROPOSTA_FIDELIZ.VAL_IOF);

            /*" -3838- IF R3-DATA-CREDITO OF REG-PROPOSTA-SASSE EQUAL SPACES */

            if (LXFCT004.REG_PROPOSTA_SASSE.R3_DATA_CREDITO.IsEmpty())
            {

                /*" -3845- MOVE 01010001 TO R3-DATA-CREDITO OF REG-PROPOSTA-SASSE. */
                _.Move(01010001, LXFCT004.REG_PROPOSTA_SASSE.R3_DATA_CREDITO);
            }


            /*" -3848- MOVE R3-DATA-CREDITO OF REG-PROPOSTA-SASSE TO W-DATA-TRABALHO. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_DATA_CREDITO, WAREA_AUXILIAR.W_DATA_TRABALHO);

            /*" -3850- MOVE W-DIA-TRABALHO TO W-DIA-SQL OF W-DATA-SQL1. */
            _.Move(WAREA_AUXILIAR.W_DIA_TRABALHO, W_DATA_SQL1.W_DIA_SQL);

            /*" -3852- MOVE W-MES-TRABALHO TO W-MES-SQL OF W-DATA-SQL1. */
            _.Move(WAREA_AUXILIAR.W_MES_TRABALHO, W_DATA_SQL1.W_MES_SQL);

            /*" -3855- MOVE W-ANO-TRABALHO TO W-ANO-SQL OF W-DATA-SQL1. */
            _.Move(WAREA_AUXILIAR.W_ANO_TRABALHO, W_DATA_SQL1.W_ANO_SQL);

            /*" -3859- MOVE '-' TO W-BARRA1 OF W-DATA-SQL1, W-BARRA2 OF W-DATA-SQL1. */
            _.Move("-", W_DATA_SQL1.W_BARRA1_1);
            _.Move("-", W_DATA_SQL1.W_BARRA2_1);


            /*" -3862- MOVE W-DATA-SQL TO DATA-CREDITO OF DCLPROPOSTA-FIDELIZ. */
            _.Move(W_DATA_SQL, PROPFID.DCLPROPOSTA_FIDELIZ.DATA_CREDITO);

            /*" -3865- MOVE R3-VAL-COMISSAO OF REG-PROPOSTA-SASSE TO VAL-COMISSAO OF DCLPROPOSTA-FIDELIZ. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_VAL_COMISSAO, PROPFID.DCLPROPOSTA_FIDELIZ.VAL_COMISSAO);

            /*" -3868- MOVE R3-SIT-PROPOSTA OF REG-PROPOSTA-SASSE TO SIT-PROPOSTA OF DCLPROPOSTA-FIDELIZ. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_SIT_PROPOSTA, PROPFID.DCLPROPOSTA_FIDELIZ.SIT_PROPOSTA);

            /*" -3871- MOVE 'PF0641B' TO COD-USUARIO OF DCLPROPOSTA-FIDELIZ. */
            _.Move("PF0641B", PROPFID.DCLPROPOSTA_FIDELIZ.COD_USUARIO);

            /*" -3874- MOVE ZEROS TO NSAS-SIVPF OF DCLPROPOSTA-FIDELIZ. */
            _.Move(0, PROPFID.DCLPROPOSTA_FIDELIZ.NSAS_SIVPF);

            /*" -3877- MOVE W-QTD-MOV-MR-3 TO NSL OF DCLPROPOSTA-FIDELIZ. */
            _.Move(WAREA_AUXILIAR.W_QTD_MOV_MR_3, PROPFID.DCLPROPOSTA_FIDELIZ.NSL);

            /*" -3880- MOVE RH-NSAS OF REG-HEADER TO NSAC-SIVPF OF DCLPROPOSTA-FIDELIZ. */
            _.Move(LXFPF990.REG_HEADER.RH_NSAS, PROPFID.DCLPROPOSTA_FIDELIZ.NSAC_SIVPF);

            /*" -3883- MOVE PESSOA-COD-PESSOA OF DCLPESSOA TO COD-PESSOA OF DCLPROPOSTA-FIDELIZ. */
            _.Move(PESSOA.DCLPESSOA.PESSOA_COD_PESSOA, PROPFID.DCLPROPOSTA_FIDELIZ.COD_PESSOA);

            /*" -3886- MOVE R3-OPCAO-COBER OF REG-PROPOSTA-SASSE TO OPCAO-COBER OF DCLPROPOSTA-FIDELIZ. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_OPCAO_COBER, PROPFID.DCLPROPOSTA_FIDELIZ.OPCAO_COBER);

            /*" -3889- MOVE R3-COD-PLANO OF REG-PROPOSTA-SASSE TO COD-PLANO OF DCLPROPOSTA-FIDELIZ. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_COD_PLANO, PROPFID.DCLPROPOSTA_FIDELIZ.COD_PLANO);

            /*" -3892- MOVE R1-NOME-CONJUGE OF REG-CLIENTES TO NOME-CONJUGE OF DCLPROPOSTA-FIDELIZ. */
            _.Move(LBFPF011.REG_CLIENTES.R1_NOME_CONJUGE, PROPFID.DCLPROPOSTA_FIDELIZ.NOME_CONJUGE);

            /*" -3895- MOVE R1-DTNASC-CONJUGE OF REG-CLIENTES TO W-DATA-TRABALHO. */
            _.Move(LBFPF011.REG_CLIENTES.R1_DTNASC_CONJUGE, WAREA_AUXILIAR.W_DATA_TRABALHO);

            /*" -3897- IF W-DATA-TRABALHO EQUAL 01010001 OR W-DATA-TRABALHO EQUAL ZEROS */

            if (WAREA_AUXILIAR.W_DATA_TRABALHO == 01010001 || WAREA_AUXILIAR.W_DATA_TRABALHO == 00)
            {

                /*" -3899- MOVE -1 TO VIND-DTNASC-ESPOSA */
                _.Move(-1, VIND_DTNASC_ESPOSA);

                /*" -3900- ELSE */
            }
            else
            {


                /*" -3902- MOVE W-DIA-TRABALHO TO W-DIA-SQL OF W-DATA-SQL1 */
                _.Move(WAREA_AUXILIAR.W_DIA_TRABALHO, W_DATA_SQL1.W_DIA_SQL);

                /*" -3904- MOVE W-MES-TRABALHO TO W-MES-SQL OF W-DATA-SQL1 */
                _.Move(WAREA_AUXILIAR.W_MES_TRABALHO, W_DATA_SQL1.W_MES_SQL);

                /*" -3907- MOVE W-ANO-TRABALHO TO W-ANO-SQL OF W-DATA-SQL1 */
                _.Move(WAREA_AUXILIAR.W_ANO_TRABALHO, W_DATA_SQL1.W_ANO_SQL);

                /*" -3911- MOVE '-' TO W-BARRA1 OF W-DATA-SQL1, W-BARRA2 OF W-DATA-SQL1 */
                _.Move("-", W_DATA_SQL1.W_BARRA1_1);
                _.Move("-", W_DATA_SQL1.W_BARRA2_1);


                /*" -3914- MOVE W-DATA-SQL TO DATA-NASC-CONJUGE OF DCLPROPOSTA-FIDELIZ. */
                _.Move(W_DATA_SQL, PROPFID.DCLPROPOSTA_FIDELIZ.DATA_NASC_CONJUGE);
            }


            /*" -3917- MOVE R1-CBO-CONJUGE OF REG-CLIENTES TO PROFISSAO-CONJUGE OF DCLPROPOSTA-FIDELIZ. */
            _.Move(LBFPF011.REG_CLIENTES.R1_CBO_CONJUGE, PROPFID.DCLPROPOSTA_FIDELIZ.PROFISSAO_CONJUGE);

            /*" -3919- MOVE 'N' TO IND-TIPO-CONTA OF DCLPROPOSTA-FIDELIZ. */
            _.Move("N", PROPFID.DCLPROPOSTA_FIDELIZ.IND_TIPO_CONTA);

            /*" -3969- PERFORM R0760_TRATA_PROP_FIDELIZACAO_DB_INSERT_1 */

            R0760_TRATA_PROP_FIDELIZACAO_DB_INSERT_1();

            /*" -3972- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -3973- DISPLAY 'PF0641B - FIM ANORMAL' */
                _.Display($"PF0641B - FIM ANORMAL");

                /*" -3974- DISPLAY '          ERRO INSERT TABELA PROPOSTA FIDELIZ' */
                _.Display($"          ERRO INSERT TABELA PROPOSTA FIDELIZ");

                /*" -3976- DISPLAY '          CODIGO PESSOA.................  ' COD-PESSOA OF DCLPROPOSTA-FIDELIZ */
                _.Display($"          CODIGO PESSOA.................  {PROPFID.DCLPROPOSTA_FIDELIZ.COD_PESSOA}");

                /*" -3978- DISPLAY '          NUMERO PROPOSTA...............  ' NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ */
                _.Display($"          NUMERO PROPOSTA...............  {PROPFID.DCLPROPOSTA_FIDELIZ.NUM_PROPOSTA_SIVPF}");

                /*" -3980- DISPLAY '          NUM SICOB.....................  ' NUM-SICOB OF DCLPROPOSTA-FIDELIZ */
                _.Display($"          NUM SICOB.....................  {PROPFID.DCLPROPOSTA_FIDELIZ.NUM_SICOB}");

                /*" -3982- DISPLAY '          COD-EMPRESA...................  ' COD-EMPRESA-SIVPF OF DCLPROPOSTA-FIDELIZ */
                _.Display($"          COD-EMPRESA...................  {PROPFID.DCLPROPOSTA_FIDELIZ.COD_EMPRESA_SIVPF}");

                /*" -3984- DISPLAY '          COD-PRODUTO-SIVPF.............  ' COD-PRODUTO-SIVPF OF DCLPROPOSTA-FIDELIZ */
                _.Display($"          COD-PRODUTO-SIVPF.............  {PROPFID.DCLPROPOSTA_FIDELIZ.COD_PRODUTO_SIVPF}");

                /*" -3986- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -3988- DISPLAY '          DATA CREDITO..................  ' DATA-CREDITO OF DCLPROPOSTA-FIDELIZ */
                _.Display($"          DATA CREDITO..................  {PROPFID.DCLPROPOSTA_FIDELIZ.DATA_CREDITO}");

                /*" -3989- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -3989- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R0760-TRATA-PROP-FIDELIZACAO-DB-INSERT-1 */
        public void R0760_TRATA_PROP_FIDELIZACAO_DB_INSERT_1()
        {
            /*" -3969- EXEC SQL INSERT INTO SEGUROS.PROPOSTA_FIDELIZ VALUES (:DCLPROPOSTA-FIDELIZ.NUM-PROPOSTA-SIVPF, :DCLPROPOSTA-FIDELIZ.NUM-IDENTIFICACAO, :DCLPROPOSTA-FIDELIZ.COD-EMPRESA-SIVPF, :DCLPROPOSTA-FIDELIZ.COD-PESSOA, :DCLPROPOSTA-FIDELIZ.NUM-SICOB, :DCLPROPOSTA-FIDELIZ.DATA-PROPOSTA, :DCLPROPOSTA-FIDELIZ.COD-PRODUTO-SIVPF, :DCLPROPOSTA-FIDELIZ.AGECOBR, :DCLPROPOSTA-FIDELIZ.DIA-DEBITO, :DCLPROPOSTA-FIDELIZ.OPCAOPAG, :DCLPROPOSTA-FIDELIZ.AGECTADEB, :DCLPROPOSTA-FIDELIZ.OPRCTADEB, :DCLPROPOSTA-FIDELIZ.NUMCTADEB, :DCLPROPOSTA-FIDELIZ.DIGCTADEB, :DCLPROPOSTA-FIDELIZ.PERC-DESCONTO, :DCLPROPOSTA-FIDELIZ.NRMATRVEN, :DCLPROPOSTA-FIDELIZ.AGECTAVEN, :DCLPROPOSTA-FIDELIZ.OPRCTAVEN, :DCLPROPOSTA-FIDELIZ.NUMCTAVEN, :DCLPROPOSTA-FIDELIZ.DIGCTAVEN, :DCLPROPOSTA-FIDELIZ.CGC-CONVENENTE, :DCLPROPOSTA-FIDELIZ.NOME-CONVENENTE, :DCLPROPOSTA-FIDELIZ.NRMATRCON, :DCLPROPOSTA-FIDELIZ.DTQITBCO, :DCLPROPOSTA-FIDELIZ.VAL-PAGO, :DCLPROPOSTA-FIDELIZ.AGEPGTO, :DCLPROPOSTA-FIDELIZ.VAL-TARIFA, :DCLPROPOSTA-FIDELIZ.VAL-IOF, :DCLPROPOSTA-FIDELIZ.DATA-CREDITO, :DCLPROPOSTA-FIDELIZ.VAL-COMISSAO, :DCLPROPOSTA-FIDELIZ.SIT-PROPOSTA, :DCLPROPOSTA-FIDELIZ.COD-USUARIO, :DCLPROPOSTA-FIDELIZ.CANAL-PROPOSTA, :DCLPROPOSTA-FIDELIZ.NSAS-SIVPF, :DCLPROPOSTA-FIDELIZ.ORIGEM-PROPOSTA, CURRENT TIMESTAMP, :DCLPROPOSTA-FIDELIZ.NSL, :DCLPROPOSTA-FIDELIZ.NSAC-SIVPF, :DCLPROPOSTA-FIDELIZ.SITUACAO-ENVIO, :DCLPROPOSTA-FIDELIZ.OPCAO-COBER, :DCLPROPOSTA-FIDELIZ.COD-PLANO, :DCLPROPOSTA-FIDELIZ.NOME-CONJUGE, :DCLPROPOSTA-FIDELIZ.DATA-NASC-CONJUGE:VIND-DTNASC-ESPOSA, :DCLPROPOSTA-FIDELIZ.PROFISSAO-CONJUGE, ' ' , ' ' , NULL, :DCLPROPOSTA-FIDELIZ.IND-TIPO-CONTA) END-EXEC. */

            var r0760_TRATA_PROP_FIDELIZACAO_DB_INSERT_1_Insert1 = new R0760_TRATA_PROP_FIDELIZACAO_DB_INSERT_1_Insert1()
            {
                NUM_PROPOSTA_SIVPF = PROPFID.DCLPROPOSTA_FIDELIZ.NUM_PROPOSTA_SIVPF.ToString(),
                NUM_IDENTIFICACAO = PROPFID.DCLPROPOSTA_FIDELIZ.NUM_IDENTIFICACAO.ToString(),
                COD_EMPRESA_SIVPF = PROPFID.DCLPROPOSTA_FIDELIZ.COD_EMPRESA_SIVPF.ToString(),
                COD_PESSOA = PROPFID.DCLPROPOSTA_FIDELIZ.COD_PESSOA.ToString(),
                NUM_SICOB = PROPFID.DCLPROPOSTA_FIDELIZ.NUM_SICOB.ToString(),
                DATA_PROPOSTA = PROPFID.DCLPROPOSTA_FIDELIZ.DATA_PROPOSTA.ToString(),
                COD_PRODUTO_SIVPF = PROPFID.DCLPROPOSTA_FIDELIZ.COD_PRODUTO_SIVPF.ToString(),
                AGECOBR = PROPFID.DCLPROPOSTA_FIDELIZ.AGECOBR.ToString(),
                DIA_DEBITO = PROPFID.DCLPROPOSTA_FIDELIZ.DIA_DEBITO.ToString(),
                OPCAOPAG = PROPFID.DCLPROPOSTA_FIDELIZ.OPCAOPAG.ToString(),
                AGECTADEB = PROPFID.DCLPROPOSTA_FIDELIZ.AGECTADEB.ToString(),
                OPRCTADEB = PROPFID.DCLPROPOSTA_FIDELIZ.OPRCTADEB.ToString(),
                NUMCTADEB = PROPFID.DCLPROPOSTA_FIDELIZ.NUMCTADEB.ToString(),
                DIGCTADEB = PROPFID.DCLPROPOSTA_FIDELIZ.DIGCTADEB.ToString(),
                PERC_DESCONTO = PROPFID.DCLPROPOSTA_FIDELIZ.PERC_DESCONTO.ToString(),
                NRMATRVEN = PROPFID.DCLPROPOSTA_FIDELIZ.NRMATRVEN.ToString(),
                AGECTAVEN = PROPFID.DCLPROPOSTA_FIDELIZ.AGECTAVEN.ToString(),
                OPRCTAVEN = PROPFID.DCLPROPOSTA_FIDELIZ.OPRCTAVEN.ToString(),
                NUMCTAVEN = PROPFID.DCLPROPOSTA_FIDELIZ.NUMCTAVEN.ToString(),
                DIGCTAVEN = PROPFID.DCLPROPOSTA_FIDELIZ.DIGCTAVEN.ToString(),
                CGC_CONVENENTE = PROPFID.DCLPROPOSTA_FIDELIZ.CGC_CONVENENTE.ToString(),
                NOME_CONVENENTE = PROPFID.DCLPROPOSTA_FIDELIZ.NOME_CONVENENTE.ToString(),
                NRMATRCON = PROPFID.DCLPROPOSTA_FIDELIZ.NRMATRCON.ToString(),
                DTQITBCO = PROPFID.DCLPROPOSTA_FIDELIZ.DTQITBCO.ToString(),
                VAL_PAGO = PROPFID.DCLPROPOSTA_FIDELIZ.VAL_PAGO.ToString(),
                AGEPGTO = PROPFID.DCLPROPOSTA_FIDELIZ.AGEPGTO.ToString(),
                VAL_TARIFA = PROPFID.DCLPROPOSTA_FIDELIZ.VAL_TARIFA.ToString(),
                VAL_IOF = PROPFID.DCLPROPOSTA_FIDELIZ.VAL_IOF.ToString(),
                DATA_CREDITO = PROPFID.DCLPROPOSTA_FIDELIZ.DATA_CREDITO.ToString(),
                VAL_COMISSAO = PROPFID.DCLPROPOSTA_FIDELIZ.VAL_COMISSAO.ToString(),
                SIT_PROPOSTA = PROPFID.DCLPROPOSTA_FIDELIZ.SIT_PROPOSTA.ToString(),
                COD_USUARIO = PROPFID.DCLPROPOSTA_FIDELIZ.COD_USUARIO.ToString(),
                CANAL_PROPOSTA = PROPFID.DCLPROPOSTA_FIDELIZ.CANAL_PROPOSTA.ToString(),
                NSAS_SIVPF = PROPFID.DCLPROPOSTA_FIDELIZ.NSAS_SIVPF.ToString(),
                ORIGEM_PROPOSTA = PROPFID.DCLPROPOSTA_FIDELIZ.ORIGEM_PROPOSTA.ToString(),
                NSL = PROPFID.DCLPROPOSTA_FIDELIZ.NSL.ToString(),
                NSAC_SIVPF = PROPFID.DCLPROPOSTA_FIDELIZ.NSAC_SIVPF.ToString(),
                SITUACAO_ENVIO = PROPFID.DCLPROPOSTA_FIDELIZ.SITUACAO_ENVIO.ToString(),
                OPCAO_COBER = PROPFID.DCLPROPOSTA_FIDELIZ.OPCAO_COBER.ToString(),
                COD_PLANO = PROPFID.DCLPROPOSTA_FIDELIZ.COD_PLANO.ToString(),
                NOME_CONJUGE = PROPFID.DCLPROPOSTA_FIDELIZ.NOME_CONJUGE.ToString(),
                DATA_NASC_CONJUGE = PROPFID.DCLPROPOSTA_FIDELIZ.DATA_NASC_CONJUGE.ToString(),
                VIND_DTNASC_ESPOSA = VIND_DTNASC_ESPOSA.ToString(),
                PROFISSAO_CONJUGE = PROPFID.DCLPROPOSTA_FIDELIZ.PROFISSAO_CONJUGE.ToString(),
                IND_TIPO_CONTA = PROPFID.DCLPROPOSTA_FIDELIZ.IND_TIPO_CONTA.ToString(),
            };

            R0760_TRATA_PROP_FIDELIZACAO_DB_INSERT_1_Insert1.Execute(r0760_TRATA_PROP_FIDELIZACAO_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0760_SAIDA*/

        [StopWatch]
        /*" R0761-00-OBTER-VAL-TARIFA-SECTION */
        private void R0761_00_OBTER_VAL_TARIFA_SECTION()
        {
            /*" -3999- MOVE 'R0761-00-OBTER-VAL-TARIFA' TO PARAGRAFO. */
            _.Move("R0761-00-OBTER-VAL-TARIFA", WABEND.FILLER_10.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4001- MOVE 'SELECT TARIFA-BALCAO-CEF' TO COMANDO. */
            _.Move("SELECT TARIFA-BALCAO-CEF", WABEND.FILLER_10.LOCALIZA_ABEND_2.COMANDO);

            /*" -4004- MOVE NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ TO NUM-CERTIFICADO OF DCLTARIFA-BALCAO-CEF. */
            _.Move(PROPFID.DCLPROPOSTA_FIDELIZ.NUM_PROPOSTA_SIVPF, TARIBCEF.DCLTARIFA_BALCAO_CEF.NUM_CERTIFICADO);

            /*" -4016- PERFORM R0761_00_OBTER_VAL_TARIFA_DB_SELECT_1 */

            R0761_00_OBTER_VAL_TARIFA_DB_SELECT_1();

            /*" -4019- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -4020- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -4021- MOVE ZEROS TO VAL-TARIFA OF DCLTARIFA-BALCAO-CEF */
                    _.Move(0, TARIBCEF.DCLTARIFA_BALCAO_CEF.VAL_TARIFA);

                    /*" -4022- ELSE */
                }
                else
                {


                    /*" -4023- DISPLAY 'PF0641B - FIM ANORMAL' */
                    _.Display($"PF0641B - FIM ANORMAL");

                    /*" -4024- DISPLAY '          ERRO SELECT TAB. TARIFA-BALCAO-CEF' */
                    _.Display($"          ERRO SELECT TAB. TARIFA-BALCAO-CEF");

                    /*" -4026- DISPLAY '          NUMERO CERTIFICADO........ ' NUM-CERTIFICADO OF DCLTARIFA-BALCAO-CEF */
                    _.Display($"          NUMERO CERTIFICADO........ {TARIBCEF.DCLTARIFA_BALCAO_CEF.NUM_CERTIFICADO}");

                    /*" -4028- DISPLAY '          SQLCODE................... ' SQLCODE */
                    _.Display($"          SQLCODE................... {DB.SQLCODE}");

                    /*" -4029- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -4029- PERFORM R9999-00-FINALIZAR. */

                    R9999_00_FINALIZAR_SECTION();
                }

            }


        }

        [StopWatch]
        /*" R0761-00-OBTER-VAL-TARIFA-DB-SELECT-1 */
        public void R0761_00_OBTER_VAL_TARIFA_DB_SELECT_1()
        {
            /*" -4016- EXEC SQL SELECT VAL_TARIFA INTO :DCLTARIFA-BALCAO-CEF.VAL-TARIFA FROM SEGUROS.TARIFA_BALCAO_CEF WHERE COD_EMPRESA = 0 AND NUM_MATRICULA = 9999999 AND TIPO_FUNCIONARIO = '5' AND NUM_CERTIFICADO = :DCLTARIFA-BALCAO-CEF.NUM-CERTIFICADO WITH UR END-EXEC. */

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
        /*" R0790-GERA-HIST-FIDELIZACAO-SECTION */
        private void R0790_GERA_HIST_FIDELIZACAO_SECTION()
        {
            /*" -4039- MOVE 'R0790-GERA-HIST-FIDELIZACAO' TO PARAGRAFO. */
            _.Move("R0790-GERA-HIST-FIDELIZACAO", WABEND.FILLER_10.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4041- MOVE 'INSERT HIST-PROP-FIDELIZ' TO COMANDO. */
            _.Move("INSERT HIST-PROP-FIDELIZ", WABEND.FILLER_10.LOCALIZA_ABEND_2.COMANDO);

            /*" -4044- MOVE NUM-IDENTIFICACAO OF DCLPROPOSTA-FIDELIZ TO PROPFIDH-NUM-IDENTIFICACAO. */
            _.Move(PROPFID.DCLPROPOSTA_FIDELIZ.NUM_IDENTIFICACAO, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NUM_IDENTIFICACAO);

            /*" -4047- MOVE DATA-PROPOSTA OF DCLPROPOSTA-FIDELIZ TO PROPFIDH-DATA-SITUACAO. */
            _.Move(PROPFID.DCLPROPOSTA_FIDELIZ.DATA_PROPOSTA, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_DATA_SITUACAO);

            /*" -4050- MOVE RH-NSAS OF REG-HEADER TO PROPFIDH-NSAS-SIVPF. */
            _.Move(LXFPF990.REG_HEADER.RH_NSAS, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NSAS_SIVPF);

            /*" -4053- MOVE W-QTD-MOV-MR-3 TO PROPFIDH-NSL. */
            _.Move(WAREA_AUXILIAR.W_QTD_MOV_MR_3, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NSL);

            /*" -4056- MOVE R3-SIT-PROPOSTA OF REG-PROPOSTA-SASSE TO PROPFIDH-SIT-PROPOSTA. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_SIT_PROPOSTA, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_PROPOSTA);

            /*" -4059- MOVE R3-SIT-COBRANCA OF REG-PROPOSTA-SASSE TO PROPFIDH-SIT-COBRANCA-SIVPF. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_SIT_COBRANCA, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_COBRANCA_SIVPF);

            /*" -4062- MOVE R3-SIT-MOTIVO OF REG-PROPOSTA-SASSE TO PROPFIDH-SIT-MOTIVO-SIVPF. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_SIT_MOTIVO, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_MOTIVO_SIVPF);

            /*" -4065- MOVE COD-EMPRESA-SIVPF OF DCLPROPOSTA-FIDELIZ TO PROPFIDH-COD-EMPRESA-SIVPF. */
            _.Move(PROPFID.DCLPROPOSTA_FIDELIZ.COD_EMPRESA_SIVPF, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_COD_EMPRESA_SIVPF);

            /*" -4068- MOVE COD-PRODUTO-SIVPF OF DCLPROPOSTA-FIDELIZ TO PROPFIDH-COD-PRODUTO-SIVPF. */
            _.Move(PROPFID.DCLPROPOSTA_FIDELIZ.COD_PRODUTO_SIVPF, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_COD_PRODUTO_SIVPF);

            /*" -4079- PERFORM R0790_GERA_HIST_FIDELIZACAO_DB_INSERT_1 */

            R0790_GERA_HIST_FIDELIZACAO_DB_INSERT_1();

            /*" -4082- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -4083- DISPLAY 'PF0641B - FIM ANORMAL' */
                _.Display($"PF0641B - FIM ANORMAL");

                /*" -4084- DISPLAY '          ERRO INSERT TABELA HIST-PROP-FIDELIZ' */
                _.Display($"          ERRO INSERT TABELA HIST-PROP-FIDELIZ");

                /*" -4086- DISPLAY '          CODIGO PESSOA.................  ' COD-PESSOA OF DCLIDENTIFICA-RELAC */
                _.Display($"          CODIGO PESSOA.................  {IDERELAC.DCLIDENTIFICA_RELAC.COD_PESSOA}");

                /*" -4088- DISPLAY '          NUMERO PROPOSTA...............  ' R3-NUM-PROPOSTA OF REG-PROPOSTA-SASSE */
                _.Display($"          NUMERO PROPOSTA...............  {LXFCT004.REG_PROPOSTA_SASSE.R3_NUM_PROPOSTA}");

                /*" -4090- DISPLAY '          NUMERO IDENTIFICACAO..........  ' PROPFIDH-NUM-IDENTIFICACAO */
                _.Display($"          NUMERO IDENTIFICACAO..........  {PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NUM_IDENTIFICACAO}");

                /*" -4092- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -4093- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -4093- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R0790-GERA-HIST-FIDELIZACAO-DB-INSERT-1 */
        public void R0790_GERA_HIST_FIDELIZACAO_DB_INSERT_1()
        {
            /*" -4079- EXEC SQL INSERT INTO SEGUROS.HIST_PROP_FIDELIZ VALUES (:PROPFIDH-NUM-IDENTIFICACAO , :PROPFIDH-DATA-SITUACAO , :PROPFIDH-NSAS-SIVPF , :PROPFIDH-NSL , :PROPFIDH-SIT-PROPOSTA , :PROPFIDH-SIT-COBRANCA-SIVPF, :PROPFIDH-SIT-MOTIVO-SIVPF , :PROPFIDH-COD-EMPRESA-SIVPF , :PROPFIDH-COD-PRODUTO-SIVPF) END-EXEC. */

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
        /*" R1500-00-GERAR-MOV-CEF-SECTION */
        private void R1500_00_GERAR_MOV_CEF_SECTION()
        {
            /*" -4103- MOVE 'R1500-00-GERAR-MOV-CEF' TO PARAGRAFO. */
            _.Move("R1500-00-GERAR-MOV-CEF", WABEND.FILLER_10.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4105- MOVE '    ' TO COMANDO. */
            _.Move("    ", WABEND.FILLER_10.LOCALIZA_ABEND_2.COMANDO);

            /*" -4107- PERFORM R1510-00-GRAVA-REG-CLIENTE */

            R1510_00_GRAVA_REG_CLIENTE_SECTION();

            /*" -4111- PERFORM R1515-00-GRAVA-REG-ENDERECO VARYING W-IND-ENDER1 FROM 1 BY 1 UNTIL W-IND-ENDER1 GREATER W-IND-ENDER-N. */

            for (WAREA_AUXILIAR.W_IND_ENDER1.Value = 1; !(WAREA_AUXILIAR.W_IND_ENDER1 > WAREA_AUXILIAR.W_IND_ENDER_N); WAREA_AUXILIAR.W_IND_ENDER1.Value += 1)
            {

                R1515_00_GRAVA_REG_ENDERECO_SECTION();
            }

            /*" -4113- PERFORM R1520-00-GRAVA-PROPOSTA */

            R1520_00_GRAVA_PROPOSTA_SECTION();

            /*" -4114- IF W-EXISTE-TP-6 EQUAL 'SIM' */

            if (WAREA_AUXILIAR.W_EXISTE_TP_6 == "SIM")
            {

                /*" -4118- PERFORM R1535-00-GRAVA-DIVERSOS VARYING W-IND-DIVERSOS FROM 1 BY 1 UNTIL W-IND-DIVERSOS GREATER W-IND-DIVERSOS-N. */

                for (WAREA_AUXILIAR.W_IND_DIVERSOS.Value = 1; !(WAREA_AUXILIAR.W_IND_DIVERSOS > WAREA_AUXILIAR.W_IND_DIVERSOS_N); WAREA_AUXILIAR.W_IND_DIVERSOS.Value += 1)
                {

                    R1535_00_GRAVA_DIVERSOS_SECTION();
                }
            }


            /*" -4119- IF W-EXISTE-TP-C EQUAL 'SIM' */

            if (WAREA_AUXILIAR.W_EXISTE_TP_C == "SIM")
            {

                /*" -4121- PERFORM R1540-00-GRAVA-CORRESP-CAIXA VARYING W-IND-SICAQ FROM 1 BY 1 UNTIL W-IND-SICAQ GREATER W-IND-SICAQ-N. */

                for (WAREA_AUXILIAR.W_IND_SICAQ.Value = 1; !(WAREA_AUXILIAR.W_IND_SICAQ > WAREA_AUXILIAR.W_IND_SICAQ_N); WAREA_AUXILIAR.W_IND_SICAQ.Value += 1)
                {

                    R1540_00_GRAVA_CORRESP_CAIXA_SECTION();
                }
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1500_SAIDA*/

        [StopWatch]
        /*" R1510-00-GRAVA-REG-CLIENTE-SECTION */
        private void R1510_00_GRAVA_REG_CLIENTE_SECTION()
        {
            /*" -4131- MOVE 'R1510-00-GRAVA-REG-CLIENTE' TO PARAGRAFO. */
            _.Move("R1510-00-GRAVA-REG-CLIENTE", WABEND.FILLER_10.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4133- MOVE 'WRITE REG-MOV-CEF' TO COMANDO. */
            _.Move("WRITE REG-MOV-CEF", WABEND.FILLER_10.LOCALIZA_ABEND_2.COMANDO);

            /*" -4135- ADD 1 TO W-QTD-MOV-CEF-1 */
            WAREA_AUXILIAR.W_QTD_MOV_CEF_1.Value = WAREA_AUXILIAR.W_QTD_MOV_CEF_1 + 1;

            /*" -4138- MOVE SPACES TO REG-MOV-CEF REG-MOV-FNAE */
            _.Move("", REG_MOV_CEF, REG_MOV_FNAE);

            /*" -4140- MOVE REG-CLIENTES TO REG-MOV-CEF REG-MOV-FNAE */
            _.Move(LBFPF011.REG_CLIENTES, REG_MOV_CEF, REG_MOV_FNAE);

            /*" -4142- WRITE REG-MOV-FNAE. */
            MOV_FNAE.Write(REG_MOV_FNAE.GetMoveValues().ToString());

            /*" -4144- IF R1-NUM-PROPOSTA > 101400000000 AND R1-NUM-PROPOSTA < 101499999999 */

            if (LBFPF011.REG_CLIENTES.R1_NUM_PROPOSTA > 101400000000 && LBFPF011.REG_CLIENTES.R1_NUM_PROPOSTA < 101499999999)
            {

                /*" -4145- MOVE R1-NUM-PROPOSTA TO WNUM-PROP-13 */
                _.Move(LBFPF011.REG_CLIENTES.R1_NUM_PROPOSTA, WAREA_AUXILIAR.FILLER_6.WNUM_PROP_13);

                /*" -4146- MOVE ZEROS TO WDIG-PROP */
                _.Move(0, WAREA_AUXILIAR.FILLER_6.WDIG_PROP);

                /*" -4147- MOVE WS-PROPOSTA TO R1-NUM-PROPOSTA */
                _.Move(WAREA_AUXILIAR.WS_PROPOSTA, LBFPF011.REG_CLIENTES.R1_NUM_PROPOSTA);

                /*" -4149- END-IF */
            }


            /*" -4151- MOVE REG-CLIENTES TO REG-MOV-CEF */
            _.Move(LBFPF011.REG_CLIENTES, REG_MOV_CEF);

            /*" -4151- WRITE REG-MOV-CEF. */
            MOV_CEF.Write(REG_MOV_CEF.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1510_SAIDA*/

        [StopWatch]
        /*" R1515-00-GRAVA-REG-ENDERECO-SECTION */
        private void R1515_00_GRAVA_REG_ENDERECO_SECTION()
        {
            /*" -4162- MOVE W-TB-REG-ENDERECOS-N(W-IND-ENDER1) TO REG-ENDERECO */
            _.Move(WAREA_AUXILIAR.W_TB_ENDERECOS_N.W_TAB_END_REG_N[WAREA_AUXILIAR.W_IND_ENDER1].W_TB_REG_ENDERECOS_N, LBFPF012.REG_ENDERECO);

            /*" -4164- ADD 1 TO W-QTD-MOV-CEF-2 */
            WAREA_AUXILIAR.W_QTD_MOV_CEF_2.Value = WAREA_AUXILIAR.W_QTD_MOV_CEF_2 + 1;

            /*" -4167- MOVE SPACES TO REG-MOV-CEF REG-MOV-FNAE */
            _.Move("", REG_MOV_CEF, REG_MOV_FNAE);

            /*" -4169- MOVE REG-ENDERECO TO REG-MOV-CEF REG-MOV-FNAE */
            _.Move(LBFPF012.REG_ENDERECO, REG_MOV_CEF, REG_MOV_FNAE);

            /*" -4171- WRITE REG-MOV-FNAE. */
            MOV_FNAE.Write(REG_MOV_FNAE.GetMoveValues().ToString());

            /*" -4173- IF R2-NUM-PROPOSTA > 101400000000 AND R2-NUM-PROPOSTA < 101499999999 */

            if (LBFPF012.REG_ENDERECO.R2_NUM_PROPOSTA > 101400000000 && LBFPF012.REG_ENDERECO.R2_NUM_PROPOSTA < 101499999999)
            {

                /*" -4174- MOVE R2-NUM-PROPOSTA TO WNUM-PROP-13 */
                _.Move(LBFPF012.REG_ENDERECO.R2_NUM_PROPOSTA, WAREA_AUXILIAR.FILLER_6.WNUM_PROP_13);

                /*" -4175- MOVE ZEROS TO WDIG-PROP */
                _.Move(0, WAREA_AUXILIAR.FILLER_6.WDIG_PROP);

                /*" -4176- MOVE WS-PROPOSTA TO R2-NUM-PROPOSTA */
                _.Move(WAREA_AUXILIAR.WS_PROPOSTA, LBFPF012.REG_ENDERECO.R2_NUM_PROPOSTA);

                /*" -4178- END-IF */
            }


            /*" -4179- MOVE REG-ENDERECO TO REG-MOV-CEF */
            _.Move(LBFPF012.REG_ENDERECO, REG_MOV_CEF);

            /*" -4179- WRITE REG-MOV-CEF. */
            MOV_CEF.Write(REG_MOV_CEF.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1515_SAIDA*/

        [StopWatch]
        /*" R1520-00-GRAVA-PROPOSTA-SECTION */
        private void R1520_00_GRAVA_PROPOSTA_SECTION()
        {
            /*" -4190- ADD 1 TO W-QTD-MOV-CEF-3 */
            WAREA_AUXILIAR.W_QTD_MOV_CEF_3.Value = WAREA_AUXILIAR.W_QTD_MOV_CEF_3 + 1;

            /*" -4193- MOVE SPACES TO REG-MOV-CEF REG-MOV-FNAE. */
            _.Move("", REG_MOV_CEF, REG_MOV_FNAE);

            /*" -4196- MOVE W-NSAS-PRP-CEF TO R3-NSAS OF REG-PROPOSTA-SASSE. */
            _.Move(WAREA_AUXILIAR.W_NSAS_PRP_CEF, LXFCT004.REG_PROPOSTA_SASSE.R3_NSAS);

            /*" -4199- MOVE W-QTD-MOV-CEF-3 TO R3-NSL OF REG-PROPOSTA-SASSE. */
            _.Move(WAREA_AUXILIAR.W_QTD_MOV_CEF_3, LXFCT004.REG_PROPOSTA_SASSE.R3_NSL);

            /*" -4201- MOVE REG-PROPOSTA-SASSE TO REG-MOV-CEF REG-MOV-FNAE. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE, REG_MOV_CEF, REG_MOV_FNAE);

            /*" -4203- WRITE REG-MOV-FNAE. */
            MOV_FNAE.Write(REG_MOV_FNAE.GetMoveValues().ToString());

            /*" -4205- IF R3-NUM-PROPOSTA > 101400000000 AND R3-NUM-PROPOSTA < 101499999999 */

            if (LXFCT004.REG_PROPOSTA_SASSE.R3_NUM_PROPOSTA > 101400000000 && LXFCT004.REG_PROPOSTA_SASSE.R3_NUM_PROPOSTA < 101499999999)
            {

                /*" -4206- MOVE R3-NUM-PROPOSTA TO WNUM-PROP-13 */
                _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_NUM_PROPOSTA, WAREA_AUXILIAR.FILLER_6.WNUM_PROP_13);

                /*" -4207- MOVE ZEROS TO WDIG-PROP */
                _.Move(0, WAREA_AUXILIAR.FILLER_6.WDIG_PROP);

                /*" -4208- MOVE WS-PROPOSTA TO R3-NUM-PROPOSTA */
                _.Move(WAREA_AUXILIAR.WS_PROPOSTA, LXFCT004.REG_PROPOSTA_SASSE.R3_NUM_PROPOSTA);

                /*" -4210- END-IF */
            }


            /*" -4211- MOVE REG-PROPOSTA-SASSE TO REG-MOV-CEF */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE, REG_MOV_CEF);

            /*" -4211- WRITE REG-MOV-CEF. */
            MOV_CEF.Write(REG_MOV_CEF.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1520_SAIDA*/

        [StopWatch]
        /*" R1535-00-GRAVA-DIVERSOS-SECTION */
        private void R1535_00_GRAVA_DIVERSOS_SECTION()
        {
            /*" -4222- MOVE W-TB-REG-DIVERSOS(W-IND-DIVERSOS) TO REG-VAL-ACESSORIOS */
            _.Move(WAREA_AUXILIAR.W_TAB_DIVERSOS.W_TAB_DIV_REG[WAREA_AUXILIAR.W_IND_DIVERSOS].W_TB_REG_DIVERSOS, LBFPF016.REG_VAL_ACESSORIOS);

            /*" -4224- ADD 1 TO W-QTD-MOV-CEF-6 */
            WAREA_AUXILIAR.W_QTD_MOV_CEF_6.Value = WAREA_AUXILIAR.W_QTD_MOV_CEF_6 + 1;

            /*" -4227- MOVE SPACES TO REG-MOV-CEF REG-MOV-FNAE. */
            _.Move("", REG_MOV_CEF, REG_MOV_FNAE);

            /*" -4229- MOVE REG-VAL-ACESSORIOS TO REG-MOV-CEF REG-MOV-FNAE. */
            _.Move(LBFPF016.REG_VAL_ACESSORIOS, REG_MOV_CEF, REG_MOV_FNAE);

            /*" -4231- WRITE REG-MOV-FNAE. */
            MOV_FNAE.Write(REG_MOV_FNAE.GetMoveValues().ToString());

            /*" -4233- IF R6-NUM-PROPOSTA > 101400000000 AND R6-NUM-PROPOSTA < 101499999999 */

            if (LBFPF016.REG_VAL_ACESSORIOS.R6_NUM_PROPOSTA > 101400000000 && LBFPF016.REG_VAL_ACESSORIOS.R6_NUM_PROPOSTA < 101499999999)
            {

                /*" -4234- MOVE R6-NUM-PROPOSTA TO WNUM-PROP-13 */
                _.Move(LBFPF016.REG_VAL_ACESSORIOS.R6_NUM_PROPOSTA, WAREA_AUXILIAR.FILLER_6.WNUM_PROP_13);

                /*" -4235- MOVE ZEROS TO WDIG-PROP */
                _.Move(0, WAREA_AUXILIAR.FILLER_6.WDIG_PROP);

                /*" -4236- MOVE WS-PROPOSTA TO R6-NUM-PROPOSTA */
                _.Move(WAREA_AUXILIAR.WS_PROPOSTA, LBFPF016.REG_VAL_ACESSORIOS.R6_NUM_PROPOSTA);

                /*" -4238- END-IF */
            }


            /*" -4239- MOVE REG-VAL-ACESSORIOS TO REG-MOV-CEF */
            _.Move(LBFPF016.REG_VAL_ACESSORIOS, REG_MOV_CEF);

            /*" -4239- WRITE REG-MOV-CEF. */
            MOV_CEF.Write(REG_MOV_CEF.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1535_SAIDA*/

        [StopWatch]
        /*" R1540-00-GRAVA-CORRESP-CAIXA-SECTION */
        private void R1540_00_GRAVA_CORRESP_CAIXA_SECTION()
        {
            /*" -4250- MOVE W-TB-REG-SICAQ (W-IND-SICAQ) TO REG-TIPO-C. */
            _.Move(WAREA_AUXILIAR.W_TAB_CORRESP_CAIXA.W_TAB_SCQ_REG[WAREA_AUXILIAR.W_IND_SICAQ].W_TB_REG_SICAQ, LBFPF026.REG_TIPO_C);

            /*" -4252- ADD 1 TO W-QTD-MOV-CEF-C. */
            WAREA_AUXILIAR.W_QTD_MOV_CEF_C.Value = WAREA_AUXILIAR.W_QTD_MOV_CEF_C + 1;

            /*" -4255- MOVE SPACES TO REG-MOV-CEF REG-MOV-FNAE. */
            _.Move("", REG_MOV_CEF, REG_MOV_FNAE);

            /*" -4257- MOVE REG-TIPO-C TO REG-MOV-CEF REG-MOV-FNAE. */
            _.Move(LBFPF026.REG_TIPO_C, REG_MOV_CEF, REG_MOV_FNAE);

            /*" -4259- WRITE REG-MOV-FNAE. */
            MOV_FNAE.Write(REG_MOV_FNAE.GetMoveValues().ToString());

            /*" -4260- MOVE REG-TIPO-C TO REG-MOV-CEF. */
            _.Move(LBFPF026.REG_TIPO_C, REG_MOV_CEF);

            /*" -4260- WRITE REG-MOV-CEF. */
            MOV_CEF.Write(REG_MOV_CEF.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1540_SAIDA*/

        [StopWatch]
        /*" R2000-00-QUEBRA-EMPRESSA-SECTION */
        private void R2000_00_QUEBRA_EMPRESSA_SECTION()
        {
            /*" -4274- IF RT-NOME-EMPRESA OF REG-TRAILLER NOT EQUAL RH-NOME OF REG-HEADER */

            if (LBFPF991.REG_TRAILLER.RT_NOME_EMPRESA != LXFPF990.REG_HEADER.RH_NOME)
            {

                /*" -4275- DISPLAY 'PF0641B - FIM ANORMAL' */
                _.Display($"PF0641B - FIM ANORMAL");

                /*" -4276- DISPLAY '          TRAILLER DIFERE DO HEADER' */
                _.Display($"          TRAILLER DIFERE DO HEADER");

                /*" -4278- DISPLAY '          EMPRESA  PROCESSADA...... ' RH-NOME OF REG-HEADER */
                _.Display($"          EMPRESA  PROCESSADA...... {LXFPF990.REG_HEADER.RH_NOME}");

                /*" -4280- DISPLAY '          ARQUIVO NUMERO........... ' RH-NSAS OF REG-HEADER */
                _.Display($"          ARQUIVO NUMERO........... {LXFPF990.REG_HEADER.RH_NSAS}");

                /*" -4282- DISPLAY '          ORIGEM DO ARQUIVO........ ' RH-SIST-ORIGEM OF REG-HEADER */
                _.Display($"          ORIGEM DO ARQUIVO........ {LXFPF990.REG_HEADER.RH_SIST_ORIGEM}");

                /*" -4284- DISPLAY '          GERADO EM................ ' RH-DATA-GERACAO OF REG-HEADER */
                _.Display($"          GERADO EM................ {LXFPF990.REG_HEADER.RH_DATA_GERACAO}");

                /*" -4285- MOVE SPACES TO W-FIM-MOVTO-MR */
                _.Move("", WAREA_AUXILIAR.W_FIM_MOVTO_MR);

                /*" -4286- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -4287- PERFORM R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION();

                /*" -4289- DISPLAY ' ' . */
                _.Display($" ");
            }


            /*" -4290- DISPLAY 'PF0641B - FIM NORMAL' */
            _.Display($"PF0641B - FIM NORMAL");

            /*" -4292- DISPLAY '          ARQUIVO PROCESSADO............ ' RH-NSAS OF REG-HEADER */
            _.Display($"          ARQUIVO PROCESSADO............ {LXFPF990.REG_HEADER.RH_NSAS}");

            /*" -4294- DISPLAY '          GERADO EM..................... ' RH-DATA-GERACAO OF REG-HEADER */
            _.Display($"          GERADO EM..................... {LXFPF990.REG_HEADER.RH_DATA_GERACAO}");

            /*" -4296- DISPLAY '          TOTAL DE REGISTROS LIDOS...... ' W-LIDO-MOVTO-SIGAT */
            _.Display($"          TOTAL DE REGISTROS LIDOS...... {WAREA_AUXILIAR.W_LIDO_MOVTO_SIGAT}");

            /*" -4298- DISPLAY '          TOTAL DE PROPOSTAS PROCESSADAS ' W-QTD-MOV-MR-3 */
            _.Display($"          TOTAL DE PROPOSTAS PROCESSADAS {WAREA_AUXILIAR.W_QTD_MOV_MR_3}");

            /*" -4300- DISPLAY '          TOTAL DE PROPOSTAS DESPREZADAS ' W-DESP-MOVTO-SIGAT */
            _.Display($"          TOTAL DE PROPOSTAS DESPREZADAS {WAREA_AUXILIAR.W_DESP_MOVTO_SIGAT}");

            /*" -4302- DISPLAY ' ' . */
            _.Display($" ");

            /*" -4313- MOVE ZEROS TO W-QTD-MOV-MR-0, W-QTD-MOV-MR-1, W-QTD-MOV-MR-2, W-QTD-MOV-MR-3, W-QTD-MOV-MR-4, W-QTD-MOV-MR-5, W-QTD-MOV-MR-6, W-QTD-MOV-MR-C, W-QTD-LH-TIPO-2, W-QTD-LH-TIPO-3. */
            _.Move(0, WAREA_AUXILIAR.W_QTD_MOV_MR_0, WAREA_AUXILIAR.W_QTD_MOV_MR_1, WAREA_AUXILIAR.W_QTD_MOV_MR_2, WAREA_AUXILIAR.W_QTD_MOV_MR_3, WAREA_AUXILIAR.W_QTD_MOV_MR_4, WAREA_AUXILIAR.W_QTD_MOV_MR_5, WAREA_AUXILIAR.W_QTD_MOV_MR_6, WAREA_AUXILIAR.W_QTD_MOV_MR_C, WAREA_AUXILIAR.W_QTD_LH_TIPO_2, WAREA_AUXILIAR.W_QTD_LH_TIPO_3);

            /*" -4313- PERFORM R0050-00-LER-MOV-MRISCO. */

            R0050_00_LER_MOV_MRISCO_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_SAIDA*/

        [StopWatch]
        /*" R2080-00-TRAILLER-FILIAIS-SECTION */
        private void R2080_00_TRAILLER_FILIAIS_SECTION()
        {
            /*" -4326- MOVE 'R2080-00-GERAR-TRAILLER' TO PARAGRAFO. */
            _.Move("R2080-00-GERAR-TRAILLER", WABEND.FILLER_10.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4328- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.FILLER_10.LOCALIZA_ABEND_2.COMANDO);

            /*" -4330- MOVE SPACES TO REG-TRAILLER. */
            _.Move("", LBFPF991.REG_TRAILLER);

            /*" -4333- MOVE 'T' TO RT-TIPO-REG OF REG-TRAILLER. */
            _.Move("T", LBFPF991.REG_TRAILLER.RT_TIPO_REG);

            /*" -4336- MOVE 'PRPSASSE' TO RT-NOME-EMPRESA OF REG-TRAILLER. */
            _.Move("PRPSASSE", LBFPF991.REG_TRAILLER.RT_NOME_EMPRESA);

            /*" -4339- MOVE W-QTD-MOV-CEF-0 TO RT-QTDE-TIPO-0 OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_MOV_CEF_0, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_0);

            /*" -4342- MOVE W-QTD-MOV-CEF-1 TO RT-QTDE-TIPO-1 OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_MOV_CEF_1, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_1);

            /*" -4345- MOVE W-QTD-MOV-CEF-2 TO RT-QTDE-TIPO-2 OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_MOV_CEF_2, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_2);

            /*" -4348- MOVE W-QTD-MOV-CEF-3 TO RT-QTDE-TIPO-3 OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_MOV_CEF_3, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_3);

            /*" -4351- MOVE W-QTD-MOV-CEF-4 TO RT-QTDE-TIPO-4 OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_MOV_CEF_4, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_4);

            /*" -4354- MOVE W-QTD-MOV-CEF-5 TO RT-QTDE-TIPO-5 OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_MOV_CEF_5, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_5);

            /*" -4357- MOVE W-QTD-MOV-CEF-6 TO RT-QTDE-TIPO-6 OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_MOV_CEF_6, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_6);

            /*" -4360- MOVE W-QTD-MOV-CEF-7 TO RT-QTDE-TIPO-7 OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_MOV_CEF_7, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_7);

            /*" -4363- MOVE W-QTD-MOV-CEF-8 TO RT-QTDE-TIPO-8 OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_MOV_CEF_8, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_8);

            /*" -4366- MOVE W-QTD-MOV-CEF-9 TO RT-QTDE-TIPO-9 OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_MOV_CEF_9, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_9);

            /*" -4369- MOVE W-QTD-MOV-CEF-A TO RT-QTDE-TIPO-A OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_MOV_CEF_A, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_A);

            /*" -4372- MOVE W-QTD-MOV-CEF-B TO RT-QTDE-TIPO-B OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_MOV_CEF_B, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_B);

            /*" -4375- MOVE W-QTD-MOV-CEF-C TO RT-QTDE-TIPO-C OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_MOV_CEF_C, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_C);

            /*" -4378- MOVE W-QTD-MOV-CEF-D TO RT-QTDE-TIPO-D OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_MOV_CEF_D, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_D);

            /*" -4381- MOVE W-QTD-MOV-CEF-E TO RT-QTDE-TIPO-E OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_MOV_CEF_E, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_E);

            /*" -4384- MOVE W-QTD-MOV-CEF-F TO RT-QTDE-TIPO-F OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_MOV_CEF_F, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_F);

            /*" -4387- MOVE W-QTD-MOV-CEF-G TO RT-QTDE-TIPO-G OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_MOV_CEF_G, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_G);

            /*" -4390- MOVE W-QTD-MOV-CEF-H TO RT-QTDE-TIPO-H OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_MOV_CEF_H, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_H);

            /*" -4393- MOVE W-QTD-MOV-CEF-I TO RT-QTDE-TIPO-I OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_MOV_CEF_I, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_I);

            /*" -4396- MOVE W-QTD-MOV-CEF-J TO RT-QTDE-TIPO-J OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_MOV_CEF_J, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_J);

            /*" -4404- COMPUTE RT-QTDE-TOTAL OF REG-TRAILLER = W-QTD-MOV-CEF-1 + W-QTD-MOV-CEF-2 + W-QTD-MOV-CEF-3 + W-QTD-MOV-CEF-4 + W-QTD-MOV-CEF-5 + W-QTD-MOV-CEF-6 + W-QTD-MOV-CEF-7 + W-QTD-MOV-CEF-8 + W-QTD-MOV-CEF-9 + W-QTD-MOV-CEF-A + W-QTD-MOV-CEF-B + W-QTD-MOV-CEF-C. */
            LBFPF991.REG_TRAILLER.RT_QTDE_TOTAL.Value = WAREA_AUXILIAR.W_QTD_MOV_CEF_1 + WAREA_AUXILIAR.W_QTD_MOV_CEF_2 + WAREA_AUXILIAR.W_QTD_MOV_CEF_3 + WAREA_AUXILIAR.W_QTD_MOV_CEF_4 + WAREA_AUXILIAR.W_QTD_MOV_CEF_5 + WAREA_AUXILIAR.W_QTD_MOV_CEF_6 + WAREA_AUXILIAR.W_QTD_MOV_CEF_7 + WAREA_AUXILIAR.W_QTD_MOV_CEF_8 + WAREA_AUXILIAR.W_QTD_MOV_CEF_9 + WAREA_AUXILIAR.W_QTD_MOV_CEF_A + WAREA_AUXILIAR.W_QTD_MOV_CEF_B + WAREA_AUXILIAR.W_QTD_MOV_CEF_C;

            /*" -4405- WRITE REG-MOV-CEF FROM REG-TRAILLER. */
            _.Move(LBFPF991.REG_TRAILLER.GetMoveValues(), REG_MOV_CEF);

            MOV_CEF.Write(REG_MOV_CEF.GetMoveValues().ToString());

            /*" -4405- WRITE REG-MOV-FNAE FROM REG-TRAILLER. */
            _.Move(LBFPF991.REG_TRAILLER.GetMoveValues(), REG_MOV_FNAE);

            MOV_FNAE.Write(REG_MOV_FNAE.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2080_SAIDA*/

        [StopWatch]
        /*" R2090-00-ATUALIZAR-ARQSIVPF-SECTION */
        private void R2090_00_ATUALIZAR_ARQSIVPF_SECTION()
        {
            /*" -4415- MOVE 'R2090-00-ATUALIZAR-ARQSIVPF' TO PARAGRAFO. */
            _.Move("R2090-00-ATUALIZAR-ARQSIVPF", WABEND.FILLER_10.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4417- MOVE 'INSERT ARQUIVOS-SIVPF' TO COMANDO. */
            _.Move("INSERT ARQUIVOS-SIVPF", WABEND.FILLER_10.LOCALIZA_ABEND_2.COMANDO);

            /*" -4420- MOVE 'PRPSASSE' TO ARQSIVPF-SIGLA-ARQUIVO OF DCLARQUIVOS-SIVPF */
            _.Move("PRPSASSE", ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SIGLA_ARQUIVO);

            /*" -4422- MOVE 4 TO ARQSIVPF-SISTEMA-ORIGEM OF DCLARQUIVOS-SIVPF */
            _.Move(4, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SISTEMA_ORIGEM);

            /*" -4425- MOVE W-NSAS-PRP-CEF TO ARQSIVPF-NSAS-SIVPF OF DCLARQUIVOS-SIVPF */
            _.Move(WAREA_AUXILIAR.W_NSAS_PRP_CEF, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF);

            /*" -4429- MOVE SISTEMAS-DATA-MOV-ABERTO OF DCLSISTEMAS TO ARQSIVPF-DATA-PROCESSAMENTO OF DCLARQUIVOS-SIVPF ARQSIVPF-DATA-GERACAO OF DCLARQUIVOS-SIVPF */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_PROCESSAMENTO, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_GERACAO);

            /*" -4432- MOVE W-QTD-MOV-CEF-3 TO ARQSIVPF-QTDE-REG-GER OF DCLARQUIVOS-SIVPF. */
            _.Move(WAREA_AUXILIAR.W_QTD_MOV_CEF_3, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_QTDE_REG_GER);

            /*" -4440- PERFORM R2090_00_ATUALIZAR_ARQSIVPF_DB_INSERT_1 */

            R2090_00_ATUALIZAR_ARQSIVPF_DB_INSERT_1();

            /*" -4443- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -4444- DISPLAY 'PF0641B - FIM ANORMAL' */
                _.Display($"PF0641B - FIM ANORMAL");

                /*" -4445- DISPLAY '          ERRO INSERT TABELA ARQUIVOS-SIVPF' */
                _.Display($"          ERRO INSERT TABELA ARQUIVOS-SIVPF");

                /*" -4447- DISPLAY '          SIGLA DO ARQIVO...............  ' ARQSIVPF-SIGLA-ARQUIVO OF DCLARQUIVOS-SIVPF */
                _.Display($"          SIGLA DO ARQIVO...............  {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SIGLA_ARQUIVO}");

                /*" -4449- DISPLAY '          NSAS SIVPF....................  ' ARQSIVPF-NSAS-SIVPF OF DCLARQUIVOS-SIVPF */
                _.Display($"          NSAS SIVPF....................  {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF}");

                /*" -4451- DISPLAY '          DATA GERACAO..................  ' ARQSIVPF-DATA-GERACAO OF DCLARQUIVOS-SIVPF */
                _.Display($"          DATA GERACAO..................  {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_GERACAO}");

                /*" -4453- DISPLAY '          QTDE. REGISTROS...............  ' ARQSIVPF-QTDE-REG-GER OF DCLARQUIVOS-SIVPF */
                _.Display($"          QTDE. REGISTROS...............  {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_QTDE_REG_GER}");

                /*" -4455- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -4456- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -4456- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R2090-00-ATUALIZAR-ARQSIVPF-DB-INSERT-1 */
        public void R2090_00_ATUALIZAR_ARQSIVPF_DB_INSERT_1()
        {
            /*" -4440- EXEC SQL INSERT INTO SEGUROS.ARQUIVOS_SIVPF VALUES (:DCLARQUIVOS-SIVPF.ARQSIVPF-SIGLA-ARQUIVO, :DCLARQUIVOS-SIVPF.ARQSIVPF-SISTEMA-ORIGEM, :DCLARQUIVOS-SIVPF.ARQSIVPF-NSAS-SIVPF, :DCLARQUIVOS-SIVPF.ARQSIVPF-DATA-GERACAO, :DCLARQUIVOS-SIVPF.ARQSIVPF-QTDE-REG-GER, :DCLARQUIVOS-SIVPF.ARQSIVPF-DATA-PROCESSAMENTO) END-EXEC. */

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
            /*" -4468- MOVE RH-SIST-ORIGEM OF REG-HEADER TO ARQSIVPF-SISTEMA-ORIGEM OF DCLARQUIVOS-SIVPF */
            _.Move(LXFPF990.REG_HEADER.RH_SIST_ORIGEM, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SISTEMA_ORIGEM);

            /*" -4471- MOVE RH-NSAS OF REG-HEADER TO ARQSIVPF-NSAS-SIVPF OF DCLARQUIVOS-SIVPF */
            _.Move(LXFPF990.REG_HEADER.RH_NSAS, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF);

            /*" -4474- MOVE SISTEMAS-DATA-MOV-ABERTO OF DCLSISTEMAS TO ARQSIVPF-DATA-PROCESSAMENTO OF DCLARQUIVOS-SIVPF */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_PROCESSAMENTO);

            /*" -4476- MOVE RH-DATA-GERACAO OF REG-HEADER TO W-DATA-TRABALHO */
            _.Move(LXFPF990.REG_HEADER.RH_DATA_GERACAO, WAREA_AUXILIAR.W_DATA_TRABALHO);

            /*" -4478- MOVE W-DIA-TRABALHO TO W-DIA-SQL OF W-DATA-SQL1 */
            _.Move(WAREA_AUXILIAR.W_DIA_TRABALHO, W_DATA_SQL1.W_DIA_SQL);

            /*" -4480- MOVE W-MES-TRABALHO TO W-MES-SQL OF W-DATA-SQL1 */
            _.Move(WAREA_AUXILIAR.W_MES_TRABALHO, W_DATA_SQL1.W_MES_SQL);

            /*" -4482- MOVE W-ANO-TRABALHO TO W-ANO-SQL OF W-DATA-SQL1 */
            _.Move(WAREA_AUXILIAR.W_ANO_TRABALHO, W_DATA_SQL1.W_ANO_SQL);

            /*" -4485- MOVE '-' TO W-BARRA1 OF W-DATA-SQL1, W-BARRA2 OF W-DATA-SQL1 */
            _.Move("-", W_DATA_SQL1.W_BARRA1_1);
            _.Move("-", W_DATA_SQL1.W_BARRA2_1);


            /*" -4488- MOVE W-DATA-SQL TO ARQSIVPF-DATA-GERACAO OF DCLARQUIVOS-SIVPF */
            _.Move(W_DATA_SQL, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_GERACAO);

            /*" -4491- MOVE W-QTD-MOV-MR-3 TO ARQSIVPF-QTDE-REG-GER OF DCLARQUIVOS-SIVPF. */
            _.Move(WAREA_AUXILIAR.W_QTD_MOV_MR_3, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_QTDE_REG_GER);

            /*" -4499- PERFORM R2100_00_TB_CONTROLE_DB_INSERT_1 */

            R2100_00_TB_CONTROLE_DB_INSERT_1();

            /*" -4502- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -4503- DISPLAY 'PF0641B - FIM ANORMAL' */
                _.Display($"PF0641B - FIM ANORMAL");

                /*" -4504- DISPLAY '          ERRO INSERT TABELA ARQUIVOS-SIVPF' */
                _.Display($"          ERRO INSERT TABELA ARQUIVOS-SIVPF");

                /*" -4506- DISPLAY '          SIGLA DO ARQIVO...............  ' ARQSIVPF-SIGLA-ARQUIVO OF DCLARQUIVOS-SIVPF */
                _.Display($"          SIGLA DO ARQIVO...............  {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SIGLA_ARQUIVO}");

                /*" -4508- DISPLAY '          NSAS SIVPF....................  ' ARQSIVPF-NSAS-SIVPF OF DCLARQUIVOS-SIVPF */
                _.Display($"          NSAS SIVPF....................  {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF}");

                /*" -4510- DISPLAY '          DATA GERACAO..................  ' ARQSIVPF-DATA-GERACAO OF DCLARQUIVOS-SIVPF */
                _.Display($"          DATA GERACAO..................  {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_GERACAO}");

                /*" -4512- DISPLAY '          QTDE. REGISTROS...............  ' ARQSIVPF-QTDE-REG-GER OF DCLARQUIVOS-SIVPF */
                _.Display($"          QTDE. REGISTROS...............  {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_QTDE_REG_GER}");

                /*" -4515- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -4516- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -4516- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R2100-00-TB-CONTROLE-DB-INSERT-1 */
        public void R2100_00_TB_CONTROLE_DB_INSERT_1()
        {
            /*" -4499- EXEC SQL INSERT INTO SEGUROS.ARQUIVOS_SIVPF VALUES (:DCLARQUIVOS-SIVPF.ARQSIVPF-SIGLA-ARQUIVO, :DCLARQUIVOS-SIVPF.ARQSIVPF-SISTEMA-ORIGEM, :DCLARQUIVOS-SIVPF.ARQSIVPF-NSAS-SIVPF, :DCLARQUIVOS-SIVPF.ARQSIVPF-DATA-GERACAO, :DCLARQUIVOS-SIVPF.ARQSIVPF-QTDE-REG-GER, :DCLARQUIVOS-SIVPF.ARQSIVPF-DATA-PROCESSAMENTO) END-EXEC. */

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
        /*" R9988-00-FECHAR-ARQUIVOS-SECTION */
        private void R9988_00_FECHAR_ARQUIVOS_SECTION()
        {
            /*" -4531- CLOSE MOV-MRISCO, MOV-CEF MOV-FNAE. */
            MOV_MRISCO.Close();
            MOV_CEF.Close();
            MOV_FNAE.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9988_SAIDA*/

        [StopWatch]
        /*" R9999-00-FINALIZAR-SECTION */
        private void R9999_00_FINALIZAR_SECTION()
        {
            /*" -4547- DISPLAY ' ' */
            _.Display($" ");

            /*" -4548- IF W-FIM-MOVTO-MR = 'FIM' */

            if (WAREA_AUXILIAR.W_FIM_MOVTO_MR == "FIM")
            {

                /*" -4549- DISPLAY 'PF0641B - FIM NORMAL' */
                _.Display($"PF0641B - FIM NORMAL");

                /*" -4550- MOVE 'COMMIT WORK' TO COMANDO */
                _.Move("COMMIT WORK", WABEND.FILLER_10.LOCALIZA_ABEND_2.COMANDO);

                /*" -4550- EXEC SQL COMMIT WORK END-EXEC */

                DatabaseConnection.Instance.CommitTransaction();

                /*" -4554- MOVE 0 TO RETURN-CODE */
                _.Move(0, RETURN_CODE);

                /*" -4555- ELSE */
            }
            else
            {


                /*" -4556- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, WABEND.FILLER_10.WSQLCODE);

                /*" -4557- MOVE SQLERRD(1) TO WSQLERRD1 */
                _.Move(DB.SQLERRD[1], WABEND.FILLER_10.WSQLERRD1);

                /*" -4559- MOVE SQLERRD(2) TO WSQLERRD2 */
                _.Move(DB.SQLERRD[2], WABEND.FILLER_10.WSQLERRD2);

                /*" -4560- DISPLAY WABEND */
                _.Display(WABEND);

                /*" -4561- DISPLAY '*** PF0641B *** ROLLBACK EM ANDAMENTO ...' */
                _.Display($"*** PF0641B *** ROLLBACK EM ANDAMENTO ...");

                /*" -4562- MOVE 'ROLLBACK WORK' TO COMANDO */
                _.Move("ROLLBACK WORK", WABEND.FILLER_10.LOCALIZA_ABEND_2.COMANDO);

                /*" -4562- EXEC SQL ROLLBACK WORK END-EXEC */

                DatabaseConnection.Instance.RollbackTransaction();

                /*" -4565- MOVE 99 TO RETURN-CODE */
                _.Move(99, RETURN_CODE);

                /*" -4567- END-IF. */
            }


            /*" -4567- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9999_SAIDA*/
    }
}