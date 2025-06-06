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
using Sias.PessoaFisica.DB2.PF0648B;

namespace Code
{
    public class PF0648B
    {
        public bool IsCall { get; set; }

        public PF0648B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      ******************************************************************      */
        /*"      ******************************************************************      */
        /*"      *   ANALISTA..............  LUIZ CARLOS                          *      */
        /*"      *   REVISAO PROGRAMACAO...  REGINALDO SILVA                      *      */
        /*"      *   PROGRAMA .............  PF0648B                              *      */
        /*"      *   DATA .................  01/07/2009.                          *      */
        /*"      *                                                                *      */
        /*"      *   FUNCAO ...............  GERA ARQUIVO PARA O SIGPF ATUALIZAR  *      */
        /*"      *                           OS DADOS DAS PROPOSTAS COMERCIALIZA  *      */
        /*"      *                           DAS NA GITEL COM SENSIBILIZA��O MA-  *      */
        /*"      *                           NUAL.     O ARQUIVO E CONCATENADO E  *      */
        /*"      *                           ENVIADO PARA A CAIXA - JPPFD03.      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 13             ALTERACOES NOS REGISTROS TIPO 3 E TIPO A *      */
        /*"      * ATENDE CADMUS 97713   CAMPOS :  OPERACAO E NUMERO DE CONTA     *      */
        /*"      *                                                                *      */
        /*"      * PROCURE NSGD          REGINALDO SILVA                          *      */
        /*"      *                       01/10/2014                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 12                                                      *      */
        /*"      * ATENDE CADMUS 102620  ALTERAR PROGRAMA PARA ATUALIZAR A SITUA- *      */
        /*"      *                       CAO NA TABELA RELATORIOS QUANDO REGISTRO *      */
        /*"      *                       NAO PROCESSADO POR FALTA DE CERTIFICADO  *      */
        /*"      *                       E A SOLICITACAO TIVER MAIS QUE 6 MESES.  *      */
        /*"      *                                                                *      */
        /*"      * PROCURE V.12          SERGIO LORETO/REGINALDO SILVA            *      */
        /*"      *                       12/09/2014                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 11                                                      *      */
        /*"      * ATENDE CADMUS 93600       AJUSTE PERIODICIDADE DE PAGAMENTO    *      */
        /*"      *                           CAMPOS PERI-PAGAMENTO R3-PERIPGTO    *      */
        /*"      *                                                                *      */
        /*"      * PROCURE V.11          REGINALDO SILVA                          *      */
        /*"      *                       10/04/2014                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 10                                                      *      */
        /*"      * ATENDE CADMUS 84809        DB2.V10  SELECTS                    *      */
        /*"      *                            AJUSTE SELECTS V10-V8               *      */
        /*"      *                                                                *      */
        /*"      * PROCURE DB2           REGINALDO SILVA                          *      */
        /*"      *                       10/09/2013                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 09 -  ATENDE CADMUS 39143 - CORRECAO DE ERRO          *      */
        /*"      *                                                                *      */
        /*"      *   DATA ...:  18/03/2010 - WELLINGTON FRC VERAS                 *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 08 -  ATENDE CADMUS 38825 - CORRECAO DE ERRO          *      */
        /*"      *                                                                *      */
        /*"      *   DATA ...:  15/03/2010 - WELLINGTON FRC VERAS                 *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 07 -  ATENDE CADMUS 38604 - CORRECAO DE ERRO          *      */
        /*"      *                                                                *      */
        /*"      *   DATA ...:  08/03/2010 - WELLINGTON FRC VERAS                 *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 06 -  ATENDE CADMUS 35403 - ABEND                     *      */
        /*"      *                                                                *      */
        /*"      *   DATA ...:  12/01/2010 - EDILANA CERQUEIRA                    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 05 -  ATENDE CADMUS 34043 - ABEND                     *      */
        /*"      *                                                                *      */
        /*"      *   DATA ...:  09/12/2009 - EDILANA CERQUEIRA                    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 04 -  ATENDE CADMUS 27380 -ALTERA CURSOR HIST_LANC_CTA*      */
        /*"      *                                                                *      */
        /*"      *   DATA ...:  23/07/2009 - EDILANA CERQUEIRA                    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 03 -  RETIRA CL�USULA SIT-REGISTRO = '3' NA ROTINA    *      */
        /*"      *                R0250-00-LER-PROPOSTAVA                         *      */
        /*"      *   DATA ...:  20/07/2009 - EDILANA CERQUEIRA                    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 02 -  ALTERA CURSOR HIST_LANC_CTA ANTEDE CADMUS 27134 *      */
        /*"      *                                                                *      */
        /*"      *   DATA ...:  17/07/2009 - PROCURE POR V.02 - EDILANA CERQUEIRA *      */
        /*"      *                                                                *      */
        /*"1     ******************************************************************      */
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
        /*"01   REG-PRP-SASSE                      PIC X(300).*/
        public StringBasis REG_PRP_SASSE { get; set; } = new StringBasis(new PIC("X", "300", "X(300)."), @"");

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"01  WS-CTA-LIDOS                      PIC S9(4)  COMP VALUE +0.*/
        public IntBasis WS_CTA_LIDOS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  WS-SQLCODE-R0711                  PIC S9(4)  COMP VALUE +0.*/
        public IntBasis WS_SQLCODE_R0711 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  WS-SQLCODE-R0720                  PIC S9(4)  COMP VALUE +0.*/
        public IntBasis WS_SQLCODE_R0720 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
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
        public PF0648B_WAREA_AUXILIAR WAREA_AUXILIAR { get; set; } = new PF0648B_WAREA_AUXILIAR();
        public class PF0648B_WAREA_AUXILIAR : VarBasis
        {
            /*"    05  W-FIM-MOVTO-VGAP              PIC X(003)  VALUE SPACES.*/
            public StringBasis W_FIM_MOVTO_VGAP { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"    05  W-FIM-OBTER-DATA           PIC X(003)  VALUE SPACES.*/
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
            /*"    05  W-TIME                        PIC X(08).*/
            public StringBasis W_TIME { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
            /*"    05  W-TIME-EDIT                   PIC 99.99.99.99.*/
            public IntBasis W_TIME_EDIT { get; set; } = new IntBasis(new PIC("9", "8", "99.99.99.99."));
            /*"    05  W-DESPREZADO                  PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_DESPREZADO { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-RELATORIO                   PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_RELATORIO { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-R0711                       PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_R0711 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-R0720                       PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_R0720 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
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
            private _REDEF_PF0648B_FILLER_0 _filler_0 { get; set; }
            public _REDEF_PF0648B_FILLER_0 FILLER_0
            {
                get { _filler_0 = new _REDEF_PF0648B_FILLER_0(); _.Move(W_PRAZO_PERCEPCAO, _filler_0); VarBasis.RedefinePassValue(W_PRAZO_PERCEPCAO, _filler_0, W_PRAZO_PERCEPCAO); _filler_0.ValueChanged += () => { _.Move(_filler_0, W_PRAZO_PERCEPCAO); }; return _filler_0; }
                set { VarBasis.RedefinePassValue(value, _filler_0, W_PRAZO_PERCEPCAO); }
            }  //Redefines
            public class _REDEF_PF0648B_FILLER_0 : VarBasis
            {
                /*"        07  W-PERCEPCAO               PIC X(002).*/
                public StringBasis W_PERCEPCAO { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"    05  W-NR-IDENTIDADE               PIC 9(008)  VALUE ZEROS.*/

                public _REDEF_PF0648B_FILLER_0()
                {
                    W_PERCEPCAO.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis W_NR_IDENTIDADE { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05  FILLER REDEFINES W-NR-IDENTIDADE.*/
            private _REDEF_PF0648B_FILLER_1 _filler_1 { get; set; }
            public _REDEF_PF0648B_FILLER_1 FILLER_1
            {
                get { _filler_1 = new _REDEF_PF0648B_FILLER_1(); _.Move(W_NR_IDENTIDADE, _filler_1); VarBasis.RedefinePassValue(W_NR_IDENTIDADE, _filler_1, W_NR_IDENTIDADE); _filler_1.ValueChanged += () => { _.Move(_filler_1, W_NR_IDENTIDADE); }; return _filler_1; }
                set { VarBasis.RedefinePassValue(value, _filler_1, W_NR_IDENTIDADE); }
            }  //Redefines
            public class _REDEF_PF0648B_FILLER_1 : VarBasis
            {
                /*"        07  W-NR-RG                   PIC X(008).*/
                public StringBasis W_NR_RG { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
                /*"    05  W-NSAS                        PIC 9(006).*/

                public _REDEF_PF0648B_FILLER_1()
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
            private _REDEF_PF0648B_FILLER_2 _filler_2 { get; set; }
            public _REDEF_PF0648B_FILLER_2 FILLER_2
            {
                get { _filler_2 = new _REDEF_PF0648B_FILLER_2(); _.Move(W_DATA_TRABALHO, _filler_2); VarBasis.RedefinePassValue(W_DATA_TRABALHO, _filler_2, W_DATA_TRABALHO); _filler_2.ValueChanged += () => { _.Move(_filler_2, W_DATA_TRABALHO); }; return _filler_2; }
                set { VarBasis.RedefinePassValue(value, _filler_2, W_DATA_TRABALHO); }
            }  //Redefines
            public class _REDEF_PF0648B_FILLER_2 : VarBasis
            {
                /*"        07  W-DIA-TRABALHO            PIC 9(002).*/
                public IntBasis W_DIA_TRABALHO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"        07  W-MES-TRABALHO            PIC 9(002).*/
                public IntBasis W_MES_TRABALHO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"        07  W-ANO-TRABALHO            PIC 9(004).*/
                public IntBasis W_ANO_TRABALHO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05  W-DATA-NASCIMENTO             PIC 9(008)  VALUE ZEROS.*/

                public _REDEF_PF0648B_FILLER_2()
                {
                    W_DIA_TRABALHO.ValueChanged += OnValueChanged;
                    W_MES_TRABALHO.ValueChanged += OnValueChanged;
                    W_ANO_TRABALHO.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis W_DATA_NASCIMENTO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05  FILLER REDEFINES W-DATA-NASCIMENTO.*/
            private _REDEF_PF0648B_FILLER_3 _filler_3 { get; set; }
            public _REDEF_PF0648B_FILLER_3 FILLER_3
            {
                get { _filler_3 = new _REDEF_PF0648B_FILLER_3(); _.Move(W_DATA_NASCIMENTO, _filler_3); VarBasis.RedefinePassValue(W_DATA_NASCIMENTO, _filler_3, W_DATA_NASCIMENTO); _filler_3.ValueChanged += () => { _.Move(_filler_3, W_DATA_NASCIMENTO); }; return _filler_3; }
                set { VarBasis.RedefinePassValue(value, _filler_3, W_DATA_NASCIMENTO); }
            }  //Redefines
            public class _REDEF_PF0648B_FILLER_3 : VarBasis
            {
                /*"        07  W-DIA-NASCIMENTO          PIC 9(002).*/
                public IntBasis W_DIA_NASCIMENTO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"        07  W-MES-NASCIMENTO          PIC 9(002).*/
                public IntBasis W_MES_NASCIMENTO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"        07  W-ANO-NASCIMENTO          PIC 9(004).*/
                public IntBasis W_ANO_NASCIMENTO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05  HOST-DT-TERVIG1               PIC X(010)  VALUE        '1999-12-31'.*/

                public _REDEF_PF0648B_FILLER_3()
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
            private _REDEF_PF0648B_W_DTMOVABE1 _w_dtmovabe1 { get; set; }
            public _REDEF_PF0648B_W_DTMOVABE1 W_DTMOVABE1
            {
                get { _w_dtmovabe1 = new _REDEF_PF0648B_W_DTMOVABE1(); _.Move(W_DTMOVABE, _w_dtmovabe1); VarBasis.RedefinePassValue(W_DTMOVABE, _w_dtmovabe1, W_DTMOVABE); _w_dtmovabe1.ValueChanged += () => { _.Move(_w_dtmovabe1, W_DTMOVABE); }; return _w_dtmovabe1; }
                set { VarBasis.RedefinePassValue(value, _w_dtmovabe1, W_DTMOVABE); }
            }  //Redefines
            public class _REDEF_PF0648B_W_DTMOVABE1 : VarBasis
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

                public _REDEF_PF0648B_W_DTMOVABE1()
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
            private _REDEF_PF0648B_W_DTMOVABE_I1 _w_dtmovabe_i1 { get; set; }
            public _REDEF_PF0648B_W_DTMOVABE_I1 W_DTMOVABE_I1
            {
                get { _w_dtmovabe_i1 = new _REDEF_PF0648B_W_DTMOVABE_I1(); _.Move(W_DTMOVABE_I, _w_dtmovabe_i1); VarBasis.RedefinePassValue(W_DTMOVABE_I, _w_dtmovabe_i1, W_DTMOVABE_I); _w_dtmovabe_i1.ValueChanged += () => { _.Move(_w_dtmovabe_i1, W_DTMOVABE_I); }; return _w_dtmovabe_i1; }
                set { VarBasis.RedefinePassValue(value, _w_dtmovabe_i1, W_DTMOVABE_I); }
            }  //Redefines
            public class _REDEF_PF0648B_W_DTMOVABE_I1 : VarBasis
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
                /*"    05  W-DT-ATUAL-MENOS-6MESES       PIC X(010).*/

                public _REDEF_PF0648B_W_DTMOVABE_I1()
                {
                    W_DIA_MOVABE_0.ValueChanged += OnValueChanged;
                    W_BARRA1_0.ValueChanged += OnValueChanged;
                    W_MES_MOVABE_0.ValueChanged += OnValueChanged;
                    W_BARRA2_0.ValueChanged += OnValueChanged;
                    W_ANO_MOVABE_0.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis W_DT_ATUAL_MENOS_6MESES { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    05  W-DATA-SQL                    PIC X(010).*/
            public StringBasis W_DATA_SQL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    05  W-DATA-SQL1 REDEFINES W-DATA-SQL.*/
            private _REDEF_PF0648B_W_DATA_SQL1 _w_data_sql1 { get; set; }
            public _REDEF_PF0648B_W_DATA_SQL1 W_DATA_SQL1
            {
                get { _w_data_sql1 = new _REDEF_PF0648B_W_DATA_SQL1(); _.Move(W_DATA_SQL, _w_data_sql1); VarBasis.RedefinePassValue(W_DATA_SQL, _w_data_sql1, W_DATA_SQL); _w_data_sql1.ValueChanged += () => { _.Move(_w_data_sql1, W_DATA_SQL); }; return _w_data_sql1; }
                set { VarBasis.RedefinePassValue(value, _w_data_sql1, W_DATA_SQL); }
            }  //Redefines
            public class _REDEF_PF0648B_W_DATA_SQL1 : VarBasis
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

                public _REDEF_PF0648B_W_DATA_SQL1()
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
            private _REDEF_PF0648B_FILLER_4 _filler_4 { get; set; }
            public _REDEF_PF0648B_FILLER_4 FILLER_4
            {
                get { _filler_4 = new _REDEF_PF0648B_FILLER_4(); _.Move(W_NR_SICOB, _filler_4); VarBasis.RedefinePassValue(W_NR_SICOB, _filler_4, W_NR_SICOB); _filler_4.ValueChanged += () => { _.Move(_filler_4, W_NR_SICOB); }; return _filler_4; }
                set { VarBasis.RedefinePassValue(value, _filler_4, W_NR_SICOB); }
            }  //Redefines
            public class _REDEF_PF0648B_FILLER_4 : VarBasis
            {
                /*"        07  W-NR-PROD-SICOB           PIC 9(003).*/
                public IntBasis W_NR_PROD_SICOB { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"        07  W-NR-NSAC-SICOB           PIC 9(006).*/
                public IntBasis W_NR_NSAC_SICOB { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"        07  W-NR-NSL-SICOB            PIC 9(006).*/
                public IntBasis W_NR_NSL_SICOB { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"    05  W-NOM-ORGAO-EXP               PIC X(030).*/

                public _REDEF_PF0648B_FILLER_4()
                {
                    W_NR_PROD_SICOB.ValueChanged += OnValueChanged;
                    W_NR_NSAC_SICOB.ValueChanged += OnValueChanged;
                    W_NR_NSL_SICOB.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis W_NOM_ORGAO_EXP { get; set; } = new StringBasis(new PIC("X", "30", "X(030)."), @"");
            /*"    05  FILLER REDEFINES W-NOM-ORGAO-EXP.*/
            private _REDEF_PF0648B_FILLER_5 _filler_5 { get; set; }
            public _REDEF_PF0648B_FILLER_5 FILLER_5
            {
                get { _filler_5 = new _REDEF_PF0648B_FILLER_5(); _.Move(W_NOM_ORGAO_EXP, _filler_5); VarBasis.RedefinePassValue(W_NOM_ORGAO_EXP, _filler_5, W_NOM_ORGAO_EXP); _filler_5.ValueChanged += () => { _.Move(_filler_5, W_NOM_ORGAO_EXP); }; return _filler_5; }
                set { VarBasis.RedefinePassValue(value, _filler_5, W_NOM_ORGAO_EXP); }
            }  //Redefines
            public class _REDEF_PF0648B_FILLER_5 : VarBasis
            {
                /*"        07  W-ORGAO-EXPEDIDOR         PIC X(005).*/
                public StringBasis W_ORGAO_EXPEDIDOR { get; set; } = new StringBasis(new PIC("X", "5", "X(005)."), @"");
                /*"        07  FILLER                    PIC X(025).*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)."), @"");
                /*"    05 W-OBTER-DADOS-RG               PIC  9(001) VALUE ZERO.*/

                public _REDEF_PF0648B_FILLER_5()
                {
                    W_ORGAO_EXPEDIDOR.ValueChanged += OnValueChanged;
                    FILLER_6.ValueChanged += OnValueChanged;
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
            private _REDEF_PF0648B_FILLER_7 _filler_7 { get; set; }
            public _REDEF_PF0648B_FILLER_7 FILLER_7
            {
                get { _filler_7 = new _REDEF_PF0648B_FILLER_7(); _.Move(W_NUM_PROPOSTA_NOVA, _filler_7); VarBasis.RedefinePassValue(W_NUM_PROPOSTA_NOVA, _filler_7, W_NUM_PROPOSTA_NOVA); _filler_7.ValueChanged += () => { _.Move(_filler_7, W_NUM_PROPOSTA_NOVA); }; return _filler_7; }
                set { VarBasis.RedefinePassValue(value, _filler_7, W_NUM_PROPOSTA_NOVA); }
            }  //Redefines
            public class _REDEF_PF0648B_FILLER_7 : VarBasis
            {
                /*"        07  W-NUM-PROPOSTA-ATUAL      PIC 9(013).*/
                public IntBasis W_NUM_PROPOSTA_ATUAL { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
                /*"        07  W-DV-PROPOSTA-NOVA        PIC 9(001).*/
                public IntBasis W_DV_PROPOSTA_NOVA { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    05  W-NUM-PROPOSTA                PIC 9(014).*/

                public _REDEF_PF0648B_FILLER_7()
                {
                    W_NUM_PROPOSTA_ATUAL.ValueChanged += OnValueChanged;
                    W_DV_PROPOSTA_NOVA.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis W_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
            /*"    05  CANAL  REDEFINES W-NUM-PROPOSTA.*/
            private _REDEF_PF0648B_CANAL _canal { get; set; }
            public _REDEF_PF0648B_CANAL CANAL
            {
                get { _canal = new _REDEF_PF0648B_CANAL(); _.Move(W_NUM_PROPOSTA, _canal); VarBasis.RedefinePassValue(W_NUM_PROPOSTA, _canal, W_NUM_PROPOSTA); _canal.ValueChanged += () => { _.Move(_canal, W_NUM_PROPOSTA); }; return _canal; }
                set { VarBasis.RedefinePassValue(value, _canal, W_NUM_PROPOSTA); }
            }  //Redefines
            public class _REDEF_PF0648B_CANAL : VarBasis
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
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)."), @"");
                /*"    05  FAIXAS  REDEFINES W-NUM-PROPOSTA.*/

                public _REDEF_PF0648B_CANAL()
                {
                    W_CANAL_PROPOSTA.ValueChanged += OnValueChanged;
                    FILLER_8.ValueChanged += OnValueChanged;
                }

            }
            private _REDEF_PF0648B_FAIXAS _faixas { get; set; }
            public _REDEF_PF0648B_FAIXAS FAIXAS
            {
                get { _faixas = new _REDEF_PF0648B_FAIXAS(); _.Move(W_NUM_PROPOSTA, _faixas); VarBasis.RedefinePassValue(W_NUM_PROPOSTA, _faixas, W_NUM_PROPOSTA); _faixas.ValueChanged += () => { _.Move(_faixas, W_NUM_PROPOSTA); }; return _faixas; }
                set { VarBasis.RedefinePassValue(value, _faixas, W_NUM_PROPOSTA); }
            }  //Redefines
            public class _REDEF_PF0648B_FAIXAS : VarBasis
            {
                /*"        07  FILLER                    PIC 9(003).*/
                public IntBasis FILLER_9 { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
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
                public IntBasis FILLER_10 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"    05  W-NUMR-TITULO               PIC  9(013)   VALUE ZEROS.*/

                public _REDEF_PF0648B_FAIXAS()
                {
                    FILLER_9.ValueChanged += OnValueChanged;
                    FAIXA_NUMERACAO.ValueChanged += OnValueChanged;
                    FILLER_10.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis W_NUMR_TITULO { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
            /*"    05  FILLER                      REDEFINES    W-NUMR-TITULO.*/
            private _REDEF_PF0648B_FILLER_11 _filler_11 { get; set; }
            public _REDEF_PF0648B_FILLER_11 FILLER_11
            {
                get { _filler_11 = new _REDEF_PF0648B_FILLER_11(); _.Move(W_NUMR_TITULO, _filler_11); VarBasis.RedefinePassValue(W_NUMR_TITULO, _filler_11, W_NUMR_TITULO); _filler_11.ValueChanged += () => { _.Move(_filler_11, W_NUMR_TITULO); }; return _filler_11; }
                set { VarBasis.RedefinePassValue(value, _filler_11, W_NUMR_TITULO); }
            }  //Redefines
            public class _REDEF_PF0648B_FILLER_11 : VarBasis
            {
                /*"      10    WTITL-ZEROS             PIC  9(002).*/
                public IntBasis WTITL_ZEROS { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10    WTITL-SEQUENCIA         PIC  9(010).*/
                public IntBasis WTITL_SEQUENCIA { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
                /*"      10    WTITL-DIGITO            PIC  9(001).*/
                public IntBasis WTITL_DIGITO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    05              DPARM01X.*/

                public _REDEF_PF0648B_FILLER_11()
                {
                    WTITL_ZEROS.ValueChanged += OnValueChanged;
                    WTITL_SEQUENCIA.ValueChanged += OnValueChanged;
                    WTITL_DIGITO.ValueChanged += OnValueChanged;
                }

            }
            public PF0648B_DPARM01X DPARM01X { get; set; } = new PF0648B_DPARM01X();
            public class PF0648B_DPARM01X : VarBasis
            {
                /*"      07            DPARM01           PIC  9(010).*/
                public IntBasis DPARM01 { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
                /*"      07            DPARM01-R         REDEFINES   DPARM01.*/
                private _REDEF_PF0648B_DPARM01_R _dparm01_r { get; set; }
                public _REDEF_PF0648B_DPARM01_R DPARM01_R
                {
                    get { _dparm01_r = new _REDEF_PF0648B_DPARM01_R(); _.Move(DPARM01, _dparm01_r); VarBasis.RedefinePassValue(DPARM01, _dparm01_r, DPARM01); _dparm01_r.ValueChanged += () => { _.Move(_dparm01_r, DPARM01); }; return _dparm01_r; }
                    set { VarBasis.RedefinePassValue(value, _dparm01_r, DPARM01); }
                }  //Redefines
                public class _REDEF_PF0648B_DPARM01_R : VarBasis
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

                    public _REDEF_PF0648B_DPARM01_R()
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

            /*"01  WABEND*/
        }
        public PF0648B_WABEND WABEND { get; set; } = new PF0648B_WABEND();
        public class PF0648B_WABEND : VarBasis
        {
            /*"    05 FILLER.*/
            public PF0648B_FILLER_12 FILLER_12 { get; set; } = new PF0648B_FILLER_12();
            public class PF0648B_FILLER_12 : VarBasis
            {
                /*"      10    FILLER                   PIC  X(010) VALUE            'PF0648B  '.*/
                public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"PF0648B  ");
                /*"      10    FILLER                   PIC  X(028) VALUE            ' *** ERRO  EXEC SQL *** '.*/
                public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @" *** ERRO  EXEC SQL *** ");
                /*"      10    FILLER                   PIC  X(014) VALUE            '    SQLCODE = '.*/
                public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE = ");
                /*"      10    WSQLCODE                 PIC  ZZZZ999  VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "7", "ZZZZ999"));
                /*"      10    FILLER                   PIC  X(014)   VALUE            '   SQLERRD1 = '.*/
                public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD1 = ");
                /*"      10    WSQLERRD1                PIC  ZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLERRD1 { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
                /*"      10    FILLER                   PIC  X(014)   VALUE            '   SQLERRD2 = '.*/
                public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD2 = ");
                /*"      10    WSQLERRD2                PIC  ZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLERRD2 { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
                /*"      10    FILLER                   PIC  X(014)   VALUE            '   SQLERRD2 = '.*/
                public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD2 = ");
                /*"    05      LOCALIZA-ABEND-1.*/
            }
            public PF0648B_LOCALIZA_ABEND_1 LOCALIZA_ABEND_1 { get; set; } = new PF0648B_LOCALIZA_ABEND_1();
            public class PF0648B_LOCALIZA_ABEND_1 : VarBasis
            {
                /*"      10    FILLER                   PIC  X(012)   VALUE            'PARAGRAFO = '.*/
                public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"PARAGRAFO = ");
                /*"      10    PARAGRAFO                PIC  X(040)   VALUE SPACES.*/
                public StringBasis PARAGRAFO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"    05      LOCALIZA-ABEND-2.*/
            }
            public PF0648B_LOCALIZA_ABEND_2 LOCALIZA_ABEND_2 { get; set; } = new PF0648B_LOCALIZA_ABEND_2();
            public class PF0648B_LOCALIZA_ABEND_2 : VarBasis
            {
                /*"      10    FILLER                   PIC  X(012)   VALUE            'COMANDO   = '.*/
                public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"COMANDO   = ");
                /*"      10    COMANDO                  PIC  X(060)   VALUE SPACES.*/
                public StringBasis COMANDO { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"");
                /*"01    WS-HORAS.*/
            }
        }
        public PF0648B_WS_HORAS WS_HORAS { get; set; } = new PF0648B_WS_HORAS();
        public class PF0648B_WS_HORAS : VarBasis
        {
            /*"  03  WS-HORA-INI               PIC  X(008).*/
            public StringBasis WS_HORA_INI { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"  03  WS-HORA-INI-R REDEFINES WS-HORA-INI.*/
            private _REDEF_PF0648B_WS_HORA_INI_R _ws_hora_ini_r { get; set; }
            public _REDEF_PF0648B_WS_HORA_INI_R WS_HORA_INI_R
            {
                get { _ws_hora_ini_r = new _REDEF_PF0648B_WS_HORA_INI_R(); _.Move(WS_HORA_INI, _ws_hora_ini_r); VarBasis.RedefinePassValue(WS_HORA_INI, _ws_hora_ini_r, WS_HORA_INI); _ws_hora_ini_r.ValueChanged += () => { _.Move(_ws_hora_ini_r, WS_HORA_INI); }; return _ws_hora_ini_r; }
                set { VarBasis.RedefinePassValue(value, _ws_hora_ini_r, WS_HORA_INI); }
            }  //Redefines
            public class _REDEF_PF0648B_WS_HORA_INI_R : VarBasis
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

                public _REDEF_PF0648B_WS_HORA_INI_R()
                {
                    HI.ValueChanged += OnValueChanged;
                    MI.ValueChanged += OnValueChanged;
                    SI.ValueChanged += OnValueChanged;
                    DI.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WS_HORA_FIM { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"  03  WS-HORA-FIM-R REDEFINES WS-HORA-FIM.*/
            private _REDEF_PF0648B_WS_HORA_FIM_R _ws_hora_fim_r { get; set; }
            public _REDEF_PF0648B_WS_HORA_FIM_R WS_HORA_FIM_R
            {
                get { _ws_hora_fim_r = new _REDEF_PF0648B_WS_HORA_FIM_R(); _.Move(WS_HORA_FIM, _ws_hora_fim_r); VarBasis.RedefinePassValue(WS_HORA_FIM, _ws_hora_fim_r, WS_HORA_FIM); _ws_hora_fim_r.ValueChanged += () => { _.Move(_ws_hora_fim_r, WS_HORA_FIM); }; return _ws_hora_fim_r; }
                set { VarBasis.RedefinePassValue(value, _ws_hora_fim_r, WS_HORA_FIM); }
            }  //Redefines
            public class _REDEF_PF0648B_WS_HORA_FIM_R : VarBasis
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

                public _REDEF_PF0648B_WS_HORA_FIM_R()
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
        public PF0648B_TOTAIS_ROT TOTAIS_ROT { get; set; } = new PF0648B_TOTAIS_ROT();
        public class PF0648B_TOTAIS_ROT : VarBasis
        {
            /*"    03  FILLER  OCCURS 70 TIMES.*/
            public ListBasis<PF0648B_FILLER_21> FILLER_21 { get; set; } = new ListBasis<PF0648B_FILLER_21>(70);
            public class PF0648B_FILLER_21 : VarBasis
            {
                /*"        05  STT                       PIC S9(013)V99 COMP-3.*/
                public DoubleBasis STT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
                /*"        05  SQT                       PIC S9(015)    COMP-3.*/
                public IntBasis SQT { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
            }
        }


        public Copies.LXFPF990 LXFPF990 { get; set; } = new Copies.LXFPF990();
        public Copies.LBFPF011 LBFPF011 { get; set; } = new Copies.LBFPF011();
        public Copies.LBFPF012 LBFPF012 { get; set; } = new Copies.LBFPF012();
        public Copies.LBFPF014 LBFPF014 { get; set; } = new Copies.LBFPF014();
        public Copies.LBFPF991 LBFPF991 { get; set; } = new Copies.LBFPF991();
        public Copies.LXFCT004 LXFCT004 { get; set; } = new Copies.LXFCT004();
        public Copies.LBWPF002 LBWPF002 { get; set; } = new Copies.LBWPF002();
        public Dclgens.TARIBCEF TARIBCEF { get; set; } = new Dclgens.TARIBCEF();
        public Dclgens.SEGVGAP SEGVGAP { get; set; } = new Dclgens.SEGVGAP();
        public Dclgens.HISCONPA HISCONPA { get; set; } = new Dclgens.HISCONPA();
        public Dclgens.HISLANCT HISLANCT { get; set; } = new Dclgens.HISLANCT();
        public Dclgens.PROPSSVD PROPSSVD { get; set; } = new Dclgens.PROPSSVD();
        public Dclgens.COVSIVPF COVSIVPF { get; set; } = new Dclgens.COVSIVPF();
        public Dclgens.MALHACEF MALHACEF { get; set; } = new Dclgens.MALHACEF();
        public Dclgens.ESCNEG ESCNEG { get; set; } = new Dclgens.ESCNEG();
        public Dclgens.AGENCEF AGENCEF { get; set; } = new Dclgens.AGENCEF();
        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.PRDSIVPF PRDSIVPF { get; set; } = new Dclgens.PRDSIVPF();
        public Dclgens.FDCOMVA FDCOMVA { get; set; } = new Dclgens.FDCOMVA();
        public Dclgens.PRODVG PRODVG { get; set; } = new Dclgens.PRODVG();
        public Dclgens.PROPFID PROPFID { get; set; } = new Dclgens.PROPFID();
        public Dclgens.CLIENTE CLIENTE { get; set; } = new Dclgens.CLIENTE();
        public Dclgens.CBO CBO { get; set; } = new Dclgens.CBO();
        public Dclgens.ENDERECO ENDERECO { get; set; } = new Dclgens.ENDERECO();
        public Dclgens.MOVVGAP MOVVGAP { get; set; } = new Dclgens.MOVVGAP();
        public Dclgens.OPPAGVA OPPAGVA { get; set; } = new Dclgens.OPPAGVA();
        public Dclgens.RELATORI RELATORI { get; set; } = new Dclgens.RELATORI();
        public Dclgens.GEDOCCLI GEDOCCLI { get; set; } = new Dclgens.GEDOCCLI();
        public Dclgens.PROPVA PROPVA { get; set; } = new Dclgens.PROPVA();
        public Dclgens.COBPRPVA COBPRPVA { get; set; } = new Dclgens.COBPRPVA();
        public Dclgens.ARQSIVPF ARQSIVPF { get; set; } = new Dclgens.ARQSIVPF();
        public PF0648B_MOVIMENTO_VGAP MOVIMENTO_VGAP { get; set; } = new PF0648B_MOVIMENTO_VGAP();
        public PF0648B_FUNDOCOMISVA FUNDOCOMISVA { get; set; } = new PF0648B_FUNDOCOMISVA();
        public PF0648B_OBTER_DATA_CREDITO OBTER_DATA_CREDITO { get; set; } = new PF0648B_OBTER_DATA_CREDITO();
        public PF0648B_DADOS_LANC DADOS_LANC { get; set; } = new PF0648B_DADOS_LANC();
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
            /*" -584- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -585- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -586- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -589- DISPLAY '************************************************' . */
            _.Display($"************************************************");

            /*" -590- DISPLAY '*               PROGRAMA PF0648B               *' . */
            _.Display($"*               PROGRAMA PF0648B               *");

            /*" -591- DISPLAY '*  GERAR ARQ PROPOSTAS VIDA COMERC. NA GITTEL  *' . */
            _.Display($"*  GERAR ARQ PROPOSTAS VIDA COMERC. NA GITTEL  *");

            /*" -592- DISPLAY '*        VERSAO:  13 - 18/06/2015 - NSGD       *' . */
            _.Display($"*        VERSAO:  13 - 18/06/2015 - NSGD       *");

            /*" -593- DISPLAY '************************************************' . */
            _.Display($"************************************************");

            /*" -601- DISPLAY '*  PF0648B - INICIO  EM ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2) ' *' . */

            $"*  PF0648B - INICIO  EM {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss} *"
            .Display();

            /*" -604- DISPLAY '************************************************' . */
            _.Display($"************************************************");

            /*" -606- INITIALIZE TOTAIS-ROT. */
            _.Initialize(
                TOTAIS_ROT
            );

            /*" -608- PERFORM R0005-00-OBTER-DATA-DIA. */

            R0005_00_OBTER_DATA_DIA_SECTION();

            /*" -610- PERFORM R0010-00-ABRIR-ARQUIVOS. */

            R0010_00_ABRIR_ARQUIVOS_SECTION();

            /*" -612- PERFORM R0020-00-OBTER-MAX-NSAS. */

            R0020_00_OBTER_MAX_NSAS_SECTION();

            /*" -614- MOVE 1 TO W-CURSOR. */
            _.Move(1, WAREA_AUXILIAR.W_CURSOR);

            /*" -616- PERFORM R0050-00-SELECIONA-MOVTO. */

            R0050_00_SELECIONA_MOVTO_SECTION();

            /*" -618- PERFORM R0070-00-LER-MOVTO. */

            R0070_00_LER_MOVTO_SECTION();

            /*" -620- PERFORM R0080-00-GERAR-HEADER. */

            R0080_00_GERAR_HEADER_SECTION();

            /*" -623- PERFORM R0150-00-PROCESSAR-MOVIMENTO UNTIL W-FIM-MOVTO-VGAP EQUAL 'FIM' . */

            while (!(WAREA_AUXILIAR.W_FIM_MOVTO_VGAP == "FIM"))
            {

                R0150_00_PROCESSAR_MOVIMENTO_SECTION();
            }

            /*" -625- PERFORM R1000-00-GERAR-TRAILLER. */

            R1000_00_GERAR_TRAILLER_SECTION();

            /*" -627- PERFORM R1050-00-CONTROLAR-ARQ-ENVIADO. */

            R1050_00_CONTROLAR_ARQ_ENVIADO_SECTION();

            /*" -629- PERFORM R1100-00-GERAR-TOTAIS. */

            R1100_00_GERAR_TOTAIS_SECTION();

            /*" -631- PERFORM R9988-00-FECHAR-ARQUIVOS. */

            R9988_00_FECHAR_ARQUIVOS_SECTION();

            /*" -633- PERFORM R9999-00-FINALIZAR. */

            R9999_00_FINALIZAR_SECTION();

            /*" -633- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

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
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, WAREA_AUXILIAR.W_DTMOVABE);

            /*" -658- MOVE W-DIA-MOVABE OF W-DTMOVABE1 TO W-DIA-MOVABE OF W-DTMOVABE-I1. */
            _.Move(WAREA_AUXILIAR.W_DTMOVABE1.W_DIA_MOVABE, WAREA_AUXILIAR.W_DTMOVABE_I1.W_DIA_MOVABE_0);

            /*" -660- MOVE W-MES-MOVABE OF W-DTMOVABE1 TO W-MES-MOVABE OF W-DTMOVABE-I1. */
            _.Move(WAREA_AUXILIAR.W_DTMOVABE1.W_MES_MOVABE, WAREA_AUXILIAR.W_DTMOVABE_I1.W_MES_MOVABE_0);

            /*" -663- MOVE W-ANO-MOVABE OF W-DTMOVABE1 TO W-ANO-MOVABE OF W-DTMOVABE-I1. */
            _.Move(WAREA_AUXILIAR.W_DTMOVABE1.W_ANO_MOVABE, WAREA_AUXILIAR.W_DTMOVABE_I1.W_ANO_MOVABE_0);

            /*" -669- MOVE '-' TO W-BARRA1 OF W-DTMOVABE-I1, W-BARRA2 OF W-DTMOVABE-I1. */
            _.Move("-", WAREA_AUXILIAR.W_DTMOVABE_I1.W_BARRA1_0);
            _.Move("-", WAREA_AUXILIAR.W_DTMOVABE_I1.W_BARRA2_0);


            /*" -674- PERFORM R0005_00_OBTER_DATA_DIA_DB_SELECT_2 */

            R0005_00_OBTER_DATA_DIA_DB_SELECT_2();

            /*" -677- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -678- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, WABEND.FILLER_12.WSQLCODE);

                /*" -679- DISPLAY 'PF0648B - FIM ANORMAL' */
                _.Display($"PF0648B - FIM ANORMAL");

                /*" -680- DISPLAY '          ERRO SELECT SYSDUMMY1 DATA' */
                _.Display($"          ERRO SELECT SYSDUMMY1 DATA");

                /*" -682- DISPLAY '          SQLCODE........................ ' SQLCODE */
                _.Display($"          SQLCODE........................ {DB.SQLCODE}");

                /*" -683- DISPLAY 'ERRO SELECT SYSDUMMY1 ' */
                _.Display($"ERRO SELECT SYSDUMMY1 ");

                /*" -684- PERFORM R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION();

                /*" -684- END-IF. */
            }


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
        /*" R0005-00-OBTER-DATA-DIA-DB-SELECT-2 */
        public void R0005_00_OBTER_DATA_DIA_DB_SELECT_2()
        {
            /*" -674- EXEC SQL SELECT CURRENT DATE - 6 MONTH INTO :W-DT-ATUAL-MENOS-6MESES FROM SYSIBM.SYSDUMMY1 WITH UR END-EXEC */

            /*-- linha suprimida por comandos abaixo EXEC SQL
            /*--SELECT CURRENT DATE - 6 MONTH
            /*--INTO :W-DT-ATUAL-MENOS-6MESES
            /*--FROM SYSIBM.SYSDUMMY1
            /*--WITH UR
            /*--END-EXEC
            /*-- */

            _.Move(_.CurrentDate(), WAREA_AUXILIAR.W_DT_ATUAL_MENOS_6MESES);

        }

        [StopWatch]
        /*" R0010-00-ABRIR-ARQUIVOS-SECTION */
        private void R0010_00_ABRIR_ARQUIVOS_SECTION()
        {
            /*" -695- MOVE 'R0010-00-ABRIR-ARQUIVOS' TO PARAGRAFO. */
            _.Move("R0010-00-ABRIR-ARQUIVOS", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -697- MOVE 'OPEN' TO COMANDO. */
            _.Move("OPEN", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -697- OPEN OUTPUT MOVTO-PRP-SASSE. */
            MOVTO_PRP_SASSE.Open(REG_PRP_SASSE);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0010_SAIDA*/

        [StopWatch]
        /*" R0020-00-OBTER-MAX-NSAS-SECTION */
        private void R0020_00_OBTER_MAX_NSAS_SECTION()
        {
            /*" -707- MOVE 'R0020-00-OBTER-MAX-NSAS' TO PARAGRAFO. */
            _.Move("R0020-00-OBTER-MAX-NSAS", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -709- MOVE 'SELECT MAX ARQUIVOS-SIVPF' TO COMANDO. */
            _.Move("SELECT MAX ARQUIVOS-SIVPF", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -716- PERFORM R0020_00_OBTER_MAX_NSAS_DB_SELECT_1 */

            R0020_00_OBTER_MAX_NSAS_DB_SELECT_1();

            /*" -719- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -720- DISPLAY 'PF0648B - FIM ANORMAL' */
                _.Display($"PF0648B - FIM ANORMAL");

                /*" -721- DISPLAY '          ERRO SELECT MAX ARQUIVOS-SIVPF' */
                _.Display($"          ERRO SELECT MAX ARQUIVOS-SIVPF");

                /*" -723- DISPLAY '          SQLCODE........................ ' SQLCODE */
                _.Display($"          SQLCODE........................ {DB.SQLCODE}");

                /*" -724- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -726- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


            /*" -729- MOVE ARQSIVPF-NSAS-SIVPF OF DCLARQUIVOS-SIVPF TO W-NSAS. */
            _.Move(ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF, WAREA_AUXILIAR.W_NSAS);

            /*" -731- ADD 1 TO W-NSAS. */
            WAREA_AUXILIAR.W_NSAS.Value = WAREA_AUXILIAR.W_NSAS + 1;

            /*" -731- MOVE W-NSAS TO ARQSIVPF-NSAS-SIVPF OF DCLARQUIVOS-SIVPF. */
            _.Move(WAREA_AUXILIAR.W_NSAS, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF);

        }

        [StopWatch]
        /*" R0020-00-OBTER-MAX-NSAS-DB-SELECT-1 */
        public void R0020_00_OBTER_MAX_NSAS_DB_SELECT_1()
        {
            /*" -716- EXEC SQL SELECT VALUE(MAX(NSAS_SIVPF),0) INTO :DCLARQUIVOS-SIVPF.ARQSIVPF-NSAS-SIVPF FROM SEGUROS.ARQUIVOS_SIVPF WHERE SIGLA_ARQUIVO = 'PRPSASSE' AND SISTEMA_ORIGEM = 4 WITH UR END-EXEC. */

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
            /*" -741- MOVE 'R0050-00-SELECIONA-MOVTO' TO PARAGRAFO. */
            _.Move("R0050-00-SELECIONA-MOVTO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -753- MOVE 'DECLARE MOVIMENTO' TO COMANDO. */
            _.Move("DECLARE MOVIMENTO", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -835- PERFORM R0050_00_SELECIONA_MOVTO_DB_DECLARE_1 */

            R0050_00_SELECIONA_MOVTO_DB_DECLARE_1();

            /*" -837- PERFORM R0050_00_SELECIONA_MOVTO_DB_OPEN_1 */

            R0050_00_SELECIONA_MOVTO_DB_OPEN_1();

            /*" -840- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -841- MOVE 2 TO W-CURSOR */
                _.Move(2, WAREA_AUXILIAR.W_CURSOR);

                /*" -841- END-IF. */
            }


        }

        [StopWatch]
        /*" R0050-00-SELECIONA-MOVTO-DB-DECLARE-1 */
        public void R0050_00_SELECIONA_MOVTO_DB_DECLARE_1()
        {
            /*" -835- EXEC SQL DECLARE MOVIMENTO-VGAP CURSOR FOR SELECT B.NUM_APOLICE , B.COD_SUBGRUPO , B.COD_FONTE , B.NUM_PROPOSTA , B.TIPO_SEGURADO , B.NUM_CERTIFICADO , B.DAC_CERTIFICADO , B.TIPO_INCLUSAO , B.COD_CLIENTE , B.COD_AGENCIADOR , B.COD_CORRETOR , B.COD_PLANOVGAP , B.COD_PLANOAP , B.FAIXA , B.AUTOR_AUM_AUTOMAT , B.TIPO_BENEFICIARIO , B.PERI_PAGAMENTO , B.PERI_RENOVACAO , B.COD_OCUPACAO , B.ESTADO_CIVIL , B.IDE_SEXO , B.COD_PROFISSAO , B.NATURALIDADE , B.OCORR_ENDERECO , B.OCORR_END_COBRAN , B.BCO_COBRANCA , B.AGE_COBRANCA , B.DAC_COBRANCA , B.NUM_MATRICULA , B.NUM_CTA_CORRENTE , B.DAC_CTA_CORRENTE , B.VAL_SALARIO , B.TIPO_SALARIO , B.TIPO_PLANO , B.PCT_CONJUGE_VG , B.PCT_CONJUGE_AP , B.QTD_SAL_MORNATU , B.QTD_SAL_MORACID , B.QTD_SAL_INVPERM , B.TAXA_AP_MORACID , B.TAXA_AP_INVPERM , B.TAXA_AP_AMDS , B.TAXA_AP_DH , B.TAXA_AP_DIT , B.TAXA_VG , B.IMP_MORNATU_ANT , B.IMP_MORNATU_ATU , B.IMP_MORACID_ANT , B.IMP_MORACID_ATU , B.IMP_INVPERM_ANT , B.IMP_INVPERM_ATU , B.IMP_AMDS_ANT , B.IMP_AMDS_ATU , B.IMP_DH_ANT , B.IMP_DH_ATU , B.IMP_DIT_ANT , B.IMP_DIT_ATU , B.PRM_VG_ANT , B.PRM_VG_ATU , B.PRM_AP_ANT , B.PRM_AP_ATU , B.COD_OPERACAO , B.DATA_AVERBACAO , B.DATA_INCLUSAO , B.COD_SUBGRUPO_TRANS , B.SIT_REGISTRO , B.COD_USUARIO , A.COD_PRODUTO , C.PERI_FINAL FROM SEGUROS.PRODUTOS_VG A, SEGUROS.MOVIMENTO_VGAP B, SEGUROS.RELATORIOS C WHERE C.COD_RELATORIO = 'PF0648B' AND C.SIT_REGISTRO = '0' AND B.NUM_CERTIFICADO = C.NUM_CERTIFICADO AND B.NUM_APOLICE = A.NUM_APOLICE AND B.COD_SUBGRUPO = A.COD_SUBGRUPO AND B.COD_OPERACAO BETWEEN 100 AND 199 WITH UR END-EXEC. */
            MOVIMENTO_VGAP = new PF0648B_MOVIMENTO_VGAP(false);
            string GetQuery_MOVIMENTO_VGAP()
            {
                var query = @$"SELECT B.NUM_APOLICE
							, 
							B.COD_SUBGRUPO
							, 
							B.COD_FONTE
							, 
							B.NUM_PROPOSTA
							, 
							B.TIPO_SEGURADO
							, 
							B.NUM_CERTIFICADO
							, 
							B.DAC_CERTIFICADO
							, 
							B.TIPO_INCLUSAO
							, 
							B.COD_CLIENTE
							, 
							B.COD_AGENCIADOR
							, 
							B.COD_CORRETOR
							, 
							B.COD_PLANOVGAP
							, 
							B.COD_PLANOAP
							, 
							B.FAIXA
							, 
							B.AUTOR_AUM_AUTOMAT
							, 
							B.TIPO_BENEFICIARIO
							, 
							B.PERI_PAGAMENTO
							, 
							B.PERI_RENOVACAO
							, 
							B.COD_OCUPACAO
							, 
							B.ESTADO_CIVIL
							, 
							B.IDE_SEXO
							, 
							B.COD_PROFISSAO
							, 
							B.NATURALIDADE
							, 
							B.OCORR_ENDERECO
							, 
							B.OCORR_END_COBRAN
							, 
							B.BCO_COBRANCA
							, 
							B.AGE_COBRANCA
							, 
							B.DAC_COBRANCA
							, 
							B.NUM_MATRICULA
							, 
							B.NUM_CTA_CORRENTE
							, 
							B.DAC_CTA_CORRENTE
							, 
							B.VAL_SALARIO
							, 
							B.TIPO_SALARIO
							, 
							B.TIPO_PLANO
							, 
							B.PCT_CONJUGE_VG
							, 
							B.PCT_CONJUGE_AP
							, 
							B.QTD_SAL_MORNATU
							, 
							B.QTD_SAL_MORACID
							, 
							B.QTD_SAL_INVPERM
							, 
							B.TAXA_AP_MORACID
							, 
							B.TAXA_AP_INVPERM
							, 
							B.TAXA_AP_AMDS
							, 
							B.TAXA_AP_DH
							, 
							B.TAXA_AP_DIT
							, 
							B.TAXA_VG
							, 
							B.IMP_MORNATU_ANT
							, 
							B.IMP_MORNATU_ATU
							, 
							B.IMP_MORACID_ANT
							, 
							B.IMP_MORACID_ATU
							, 
							B.IMP_INVPERM_ANT
							, 
							B.IMP_INVPERM_ATU
							, 
							B.IMP_AMDS_ANT
							, 
							B.IMP_AMDS_ATU
							, 
							B.IMP_DH_ANT
							, 
							B.IMP_DH_ATU
							, 
							B.IMP_DIT_ANT
							, 
							B.IMP_DIT_ATU
							, 
							B.PRM_VG_ANT
							, 
							B.PRM_VG_ATU
							, 
							B.PRM_AP_ANT
							, 
							B.PRM_AP_ATU
							, 
							B.COD_OPERACAO
							, 
							B.DATA_AVERBACAO
							, 
							B.DATA_INCLUSAO
							, 
							B.COD_SUBGRUPO_TRANS
							, 
							B.SIT_REGISTRO
							, 
							B.COD_USUARIO
							, 
							A.COD_PRODUTO
							, 
							C.PERI_FINAL 
							FROM SEGUROS.PRODUTOS_VG A
							, 
							SEGUROS.MOVIMENTO_VGAP B
							, 
							SEGUROS.RELATORIOS C 
							WHERE C.COD_RELATORIO = 'PF0648B' 
							AND C.SIT_REGISTRO = '0' 
							AND B.NUM_CERTIFICADO = C.NUM_CERTIFICADO 
							AND B.NUM_APOLICE = A.NUM_APOLICE 
							AND B.COD_SUBGRUPO = A.COD_SUBGRUPO 
							AND B.COD_OPERACAO BETWEEN 100 AND 199";

                return query;
            }
            MOVIMENTO_VGAP.GetQueryEvent += GetQuery_MOVIMENTO_VGAP;

        }

        [StopWatch]
        /*" R0050-00-SELECIONA-MOVTO-DB-OPEN-1 */
        public void R0050_00_SELECIONA_MOVTO_DB_OPEN_1()
        {
            /*" -837- EXEC SQL OPEN MOVIMENTO-VGAP END-EXEC. */

            MOVIMENTO_VGAP.Open();

        }

        [StopWatch]
        /*" R0570-00-LER-COMISSAO-DB-DECLARE-1 */
        public void R0570_00_LER_COMISSAO_DB_DECLARE_1()
        {
            /*" -1619- EXEC SQL DECLARE FUNDOCOMISVA CURSOR FOR SELECT NUM_CERTIFICADO , VAL_COMISSAO_VG , VAL_COMISSAO_AP FROM SEGUROS.FUNDO_COMISSAO_VA WHERE NUM_CERTIFICADO = :DCLFUNDO-COMISSAO-VA.NUM-CERTIFICADO AND COD_OPERACAO = :DCLFUNDO-COMISSAO-VA.COD-OPERACAO WITH UR END-EXEC. */
            FUNDOCOMISVA = new PF0648B_FUNDOCOMISVA(true);
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
            /*" -862- MOVE 'R0070-00-LER-MOVTO' TO PARAGRAFO. */
            _.Move("R0070-00-LER-MOVTO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -864- MOVE 'FETCH MOVIMENTO-VGAP' TO COMANDO. */
            _.Move("FETCH MOVIMENTO-VGAP", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -935- PERFORM R0070_00_LER_MOVTO_DB_FETCH_1 */

            R0070_00_LER_MOVTO_DB_FETCH_1();

            /*" -938- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -939- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -940- MOVE 'FIM' TO W-FIM-MOVTO-VGAP */
                    _.Move("FIM", WAREA_AUXILIAR.W_FIM_MOVTO_VGAP);

                    /*" -940- PERFORM R0070_00_LER_MOVTO_DB_CLOSE_1 */

                    R0070_00_LER_MOVTO_DB_CLOSE_1();

                    /*" -942- ELSE */
                }
                else
                {


                    /*" -943- DISPLAY 'PF0648B - FIM ANORMAL' */
                    _.Display($"PF0648B - FIM ANORMAL");

                    /*" -945- DISPLAY '          ERRO FETCH CURSOR V0MOVIMENTO  ' SQLCODE */
                    _.Display($"          ERRO FETCH CURSOR V0MOVIMENTO  {DB.SQLCODE}");

                    /*" -946- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -947- PERFORM R9999-00-FINALIZAR */

                    R9999_00_FINALIZAR_SECTION();

                    /*" -948- END-IF */
                }


                /*" -954- ELSE */
            }
            else
            {


                /*" -956- ADD 1 TO W-NSL, W-CONTROLE */
                WAREA_AUXILIAR.W_NSL.Value = WAREA_AUXILIAR.W_NSL + 1;
                WAREA_AUXILIAR.W_CONTROLE.Value = WAREA_AUXILIAR.W_CONTROLE + 1;

                /*" -968- COMPUTE W-TOT-PROCESSADO = W-QTD-LD-TIPO-1 + W-QTD-LD-TIPO-2 + W-QTD-LD-TIPO-3 + W-QTD-LD-TIPO-4 + W-QTD-LD-TIPO-5 + W-QTD-LD-TIPO-6 + W-QTD-LD-TIPO-7 + W-QTD-LD-TIPO-8 + W-QTD-LD-TIPO-9 + W-QTD-LD-TIPO-A + W-QTD-LD-TIPO-B + W-QTD-LD-TIPO-C + W-QTD-LD-TIPO-D + W-QTD-LD-TIPO-E + W-QTD-LD-TIPO-F + W-QTD-LD-TIPO-G + W-QTD-LD-TIPO-H + W-QTD-LD-TIPO-I + W-QTD-LD-TIPO-J */
                WAREA_AUXILIAR.W_TOT_PROCESSADO.Value = WAREA_AUXILIAR.W_QTD_LD_TIPO_1 + WAREA_AUXILIAR.W_QTD_LD_TIPO_2 + WAREA_AUXILIAR.W_QTD_LD_TIPO_3 + WAREA_AUXILIAR.W_QTD_LD_TIPO_4 + WAREA_AUXILIAR.W_QTD_LD_TIPO_5 + WAREA_AUXILIAR.W_QTD_LD_TIPO_6 + WAREA_AUXILIAR.W_QTD_LD_TIPO_7 + WAREA_AUXILIAR.W_QTD_LD_TIPO_8 + WAREA_AUXILIAR.W_QTD_LD_TIPO_9 + WAREA_AUXILIAR.W_QTD_LD_TIPO_A + WAREA_AUXILIAR.W_QTD_LD_TIPO_B + WAREA_AUXILIAR.W_QTD_LD_TIPO_C + WAREA_AUXILIAR.W_QTD_LD_TIPO_D + WAREA_AUXILIAR.W_QTD_LD_TIPO_E + WAREA_AUXILIAR.W_QTD_LD_TIPO_F + WAREA_AUXILIAR.W_QTD_LD_TIPO_G + WAREA_AUXILIAR.W_QTD_LD_TIPO_H + WAREA_AUXILIAR.W_QTD_LD_TIPO_I + WAREA_AUXILIAR.W_QTD_LD_TIPO_J;

                /*" -969- IF W-CONTROLE > 999 */

                if (WAREA_AUXILIAR.W_CONTROLE > 999)
                {

                    /*" -973- DISPLAY '** PF0648B ** TOTAL LIDOS....' W-NSL '   ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2) */

                    $"** PF0648B ** TOTAL LIDOS....{WAREA_AUXILIAR.W_NSL}   {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
                    .Display();

                    /*" -974- MOVE ZEROS TO W-CONTROLE */
                    _.Move(0, WAREA_AUXILIAR.W_CONTROLE);

                    /*" -975- END-IF */
                }


                /*" -975- END-IF. */
            }


        }

        [StopWatch]
        /*" R0070-00-LER-MOVTO-DB-FETCH-1 */
        public void R0070_00_LER_MOVTO_DB_FETCH_1()
        {
            /*" -935- EXEC SQL FETCH MOVIMENTO-VGAP INTO :MOVVGAP-NUM-APOLICE , :MOVVGAP-COD-SUBGRUPO , :MOVVGAP-COD-FONTE , :MOVVGAP-NUM-PROPOSTA , :MOVVGAP-TIPO-SEGURADO , :MOVVGAP-NUM-CERTIFICADO , :MOVVGAP-DAC-CERTIFICADO , :MOVVGAP-TIPO-INCLUSAO , :MOVVGAP-COD-CLIENTE , :MOVVGAP-COD-AGENCIADOR , :MOVVGAP-COD-CORRETOR , :MOVVGAP-COD-PLANOVGAP , :MOVVGAP-COD-PLANOAP , :MOVVGAP-FAIXA , :MOVVGAP-AUTOR-AUM-AUTOMAT , :MOVVGAP-TIPO-BENEFICIARIO , :MOVVGAP-PERI-PAGAMENTO , :MOVVGAP-PERI-RENOVACAO , :MOVVGAP-COD-OCUPACAO , :MOVVGAP-ESTADO-CIVIL , :MOVVGAP-IDE-SEXO , :MOVVGAP-COD-PROFISSAO , :MOVVGAP-NATURALIDADE , :MOVVGAP-OCORR-ENDERECO , :MOVVGAP-OCORR-END-COBRAN , :MOVVGAP-BCO-COBRANCA , :MOVVGAP-AGE-COBRANCA , :MOVVGAP-DAC-COBRANCA , :MOVVGAP-NUM-MATRICULA , :MOVVGAP-NUM-CTA-CORRENTE , :MOVVGAP-DAC-CTA-CORRENTE , :MOVVGAP-VAL-SALARIO , :MOVVGAP-TIPO-SALARIO , :MOVVGAP-TIPO-PLANO , :MOVVGAP-PCT-CONJUGE-VG , :MOVVGAP-PCT-CONJUGE-AP , :MOVVGAP-QTD-SAL-MORNATU , :MOVVGAP-QTD-SAL-MORACID , :MOVVGAP-QTD-SAL-INVPERM , :MOVVGAP-TAXA-AP-MORACID , :MOVVGAP-TAXA-AP-INVPERM , :MOVVGAP-TAXA-AP-AMDS , :MOVVGAP-TAXA-AP-DH , :MOVVGAP-TAXA-AP-DIT , :MOVVGAP-TAXA-VG , :MOVVGAP-IMP-MORNATU-ANT , :MOVVGAP-IMP-MORNATU-ATU , :MOVVGAP-IMP-MORACID-ANT , :MOVVGAP-IMP-MORACID-ATU , :MOVVGAP-IMP-INVPERM-ANT , :MOVVGAP-IMP-INVPERM-ATU , :MOVVGAP-IMP-AMDS-ANT , :MOVVGAP-IMP-AMDS-ATU , :MOVVGAP-IMP-DH-ANT , :MOVVGAP-IMP-DH-ATU , :MOVVGAP-IMP-DIT-ANT , :MOVVGAP-IMP-DIT-ATU , :MOVVGAP-PRM-VG-ANT , :MOVVGAP-PRM-VG-ATU , :MOVVGAP-PRM-AP-ANT , :MOVVGAP-PRM-AP-ATU , :MOVVGAP-COD-OPERACAO , :MOVVGAP-DATA-AVERBACAO , :MOVVGAP-DATA-INCLUSAO , :MOVVGAP-COD-SUBGRUPO-TRANS , :MOVVGAP-SIT-REGISTRO , :MOVVGAP-COD-USUARIO , :DCLPRODUTOS-VG.COD-PRODUTO , :RELATORI-PERI-FINAL END-EXEC. */

            if (MOVIMENTO_VGAP.Fetch())
            {
                _.Move(MOVIMENTO_VGAP.MOVVGAP_NUM_APOLICE, MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_NUM_APOLICE);
                _.Move(MOVIMENTO_VGAP.MOVVGAP_COD_SUBGRUPO, MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_COD_SUBGRUPO);
                _.Move(MOVIMENTO_VGAP.MOVVGAP_COD_FONTE, MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_COD_FONTE);
                _.Move(MOVIMENTO_VGAP.MOVVGAP_NUM_PROPOSTA, MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_NUM_PROPOSTA);
                _.Move(MOVIMENTO_VGAP.MOVVGAP_TIPO_SEGURADO, MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_TIPO_SEGURADO);
                _.Move(MOVIMENTO_VGAP.MOVVGAP_NUM_CERTIFICADO, MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_NUM_CERTIFICADO);
                _.Move(MOVIMENTO_VGAP.MOVVGAP_DAC_CERTIFICADO, MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_DAC_CERTIFICADO);
                _.Move(MOVIMENTO_VGAP.MOVVGAP_TIPO_INCLUSAO, MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_TIPO_INCLUSAO);
                _.Move(MOVIMENTO_VGAP.MOVVGAP_COD_CLIENTE, MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_COD_CLIENTE);
                _.Move(MOVIMENTO_VGAP.MOVVGAP_COD_AGENCIADOR, MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_COD_AGENCIADOR);
                _.Move(MOVIMENTO_VGAP.MOVVGAP_COD_CORRETOR, MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_COD_CORRETOR);
                _.Move(MOVIMENTO_VGAP.MOVVGAP_COD_PLANOVGAP, MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_COD_PLANOVGAP);
                _.Move(MOVIMENTO_VGAP.MOVVGAP_COD_PLANOAP, MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_COD_PLANOAP);
                _.Move(MOVIMENTO_VGAP.MOVVGAP_FAIXA, MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_FAIXA);
                _.Move(MOVIMENTO_VGAP.MOVVGAP_AUTOR_AUM_AUTOMAT, MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_AUTOR_AUM_AUTOMAT);
                _.Move(MOVIMENTO_VGAP.MOVVGAP_TIPO_BENEFICIARIO, MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_TIPO_BENEFICIARIO);
                _.Move(MOVIMENTO_VGAP.MOVVGAP_PERI_PAGAMENTO, MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_PERI_PAGAMENTO);
                _.Move(MOVIMENTO_VGAP.MOVVGAP_PERI_RENOVACAO, MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_PERI_RENOVACAO);
                _.Move(MOVIMENTO_VGAP.MOVVGAP_COD_OCUPACAO, MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_COD_OCUPACAO);
                _.Move(MOVIMENTO_VGAP.MOVVGAP_ESTADO_CIVIL, MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_ESTADO_CIVIL);
                _.Move(MOVIMENTO_VGAP.MOVVGAP_IDE_SEXO, MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_IDE_SEXO);
                _.Move(MOVIMENTO_VGAP.MOVVGAP_COD_PROFISSAO, MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_COD_PROFISSAO);
                _.Move(MOVIMENTO_VGAP.MOVVGAP_NATURALIDADE, MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_NATURALIDADE);
                _.Move(MOVIMENTO_VGAP.MOVVGAP_OCORR_ENDERECO, MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_OCORR_ENDERECO);
                _.Move(MOVIMENTO_VGAP.MOVVGAP_OCORR_END_COBRAN, MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_OCORR_END_COBRAN);
                _.Move(MOVIMENTO_VGAP.MOVVGAP_BCO_COBRANCA, MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_BCO_COBRANCA);
                _.Move(MOVIMENTO_VGAP.MOVVGAP_AGE_COBRANCA, MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_AGE_COBRANCA);
                _.Move(MOVIMENTO_VGAP.MOVVGAP_DAC_COBRANCA, MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_DAC_COBRANCA);
                _.Move(MOVIMENTO_VGAP.MOVVGAP_NUM_MATRICULA, MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_NUM_MATRICULA);
                _.Move(MOVIMENTO_VGAP.MOVVGAP_NUM_CTA_CORRENTE, MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_NUM_CTA_CORRENTE);
                _.Move(MOVIMENTO_VGAP.MOVVGAP_DAC_CTA_CORRENTE, MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_DAC_CTA_CORRENTE);
                _.Move(MOVIMENTO_VGAP.MOVVGAP_VAL_SALARIO, MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_VAL_SALARIO);
                _.Move(MOVIMENTO_VGAP.MOVVGAP_TIPO_SALARIO, MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_TIPO_SALARIO);
                _.Move(MOVIMENTO_VGAP.MOVVGAP_TIPO_PLANO, MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_TIPO_PLANO);
                _.Move(MOVIMENTO_VGAP.MOVVGAP_PCT_CONJUGE_VG, MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_PCT_CONJUGE_VG);
                _.Move(MOVIMENTO_VGAP.MOVVGAP_PCT_CONJUGE_AP, MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_PCT_CONJUGE_AP);
                _.Move(MOVIMENTO_VGAP.MOVVGAP_QTD_SAL_MORNATU, MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_QTD_SAL_MORNATU);
                _.Move(MOVIMENTO_VGAP.MOVVGAP_QTD_SAL_MORACID, MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_QTD_SAL_MORACID);
                _.Move(MOVIMENTO_VGAP.MOVVGAP_QTD_SAL_INVPERM, MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_QTD_SAL_INVPERM);
                _.Move(MOVIMENTO_VGAP.MOVVGAP_TAXA_AP_MORACID, MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_TAXA_AP_MORACID);
                _.Move(MOVIMENTO_VGAP.MOVVGAP_TAXA_AP_INVPERM, MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_TAXA_AP_INVPERM);
                _.Move(MOVIMENTO_VGAP.MOVVGAP_TAXA_AP_AMDS, MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_TAXA_AP_AMDS);
                _.Move(MOVIMENTO_VGAP.MOVVGAP_TAXA_AP_DH, MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_TAXA_AP_DH);
                _.Move(MOVIMENTO_VGAP.MOVVGAP_TAXA_AP_DIT, MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_TAXA_AP_DIT);
                _.Move(MOVIMENTO_VGAP.MOVVGAP_TAXA_VG, MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_TAXA_VG);
                _.Move(MOVIMENTO_VGAP.MOVVGAP_IMP_MORNATU_ANT, MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_IMP_MORNATU_ANT);
                _.Move(MOVIMENTO_VGAP.MOVVGAP_IMP_MORNATU_ATU, MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_IMP_MORNATU_ATU);
                _.Move(MOVIMENTO_VGAP.MOVVGAP_IMP_MORACID_ANT, MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_IMP_MORACID_ANT);
                _.Move(MOVIMENTO_VGAP.MOVVGAP_IMP_MORACID_ATU, MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_IMP_MORACID_ATU);
                _.Move(MOVIMENTO_VGAP.MOVVGAP_IMP_INVPERM_ANT, MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_IMP_INVPERM_ANT);
                _.Move(MOVIMENTO_VGAP.MOVVGAP_IMP_INVPERM_ATU, MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_IMP_INVPERM_ATU);
                _.Move(MOVIMENTO_VGAP.MOVVGAP_IMP_AMDS_ANT, MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_IMP_AMDS_ANT);
                _.Move(MOVIMENTO_VGAP.MOVVGAP_IMP_AMDS_ATU, MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_IMP_AMDS_ATU);
                _.Move(MOVIMENTO_VGAP.MOVVGAP_IMP_DH_ANT, MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_IMP_DH_ANT);
                _.Move(MOVIMENTO_VGAP.MOVVGAP_IMP_DH_ATU, MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_IMP_DH_ATU);
                _.Move(MOVIMENTO_VGAP.MOVVGAP_IMP_DIT_ANT, MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_IMP_DIT_ANT);
                _.Move(MOVIMENTO_VGAP.MOVVGAP_IMP_DIT_ATU, MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_IMP_DIT_ATU);
                _.Move(MOVIMENTO_VGAP.MOVVGAP_PRM_VG_ANT, MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_PRM_VG_ANT);
                _.Move(MOVIMENTO_VGAP.MOVVGAP_PRM_VG_ATU, MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_PRM_VG_ATU);
                _.Move(MOVIMENTO_VGAP.MOVVGAP_PRM_AP_ANT, MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_PRM_AP_ANT);
                _.Move(MOVIMENTO_VGAP.MOVVGAP_PRM_AP_ATU, MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_PRM_AP_ATU);
                _.Move(MOVIMENTO_VGAP.MOVVGAP_COD_OPERACAO, MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_COD_OPERACAO);
                _.Move(MOVIMENTO_VGAP.MOVVGAP_DATA_AVERBACAO, MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_DATA_AVERBACAO);
                _.Move(MOVIMENTO_VGAP.MOVVGAP_DATA_INCLUSAO, MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_DATA_INCLUSAO);
                _.Move(MOVIMENTO_VGAP.MOVVGAP_COD_SUBGRUPO_TRANS, MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_COD_SUBGRUPO_TRANS);
                _.Move(MOVIMENTO_VGAP.MOVVGAP_SIT_REGISTRO, MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_SIT_REGISTRO);
                _.Move(MOVIMENTO_VGAP.MOVVGAP_COD_USUARIO, MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_COD_USUARIO);
                _.Move(MOVIMENTO_VGAP.DCLPRODUTOS_VG_COD_PRODUTO, PRODVG.DCLPRODUTOS_VG.COD_PRODUTO);
                _.Move(MOVIMENTO_VGAP.RELATORI_PERI_FINAL, RELATORI.DCLRELATORIOS.RELATORI_PERI_FINAL);
            }

        }

        [StopWatch]
        /*" R0070-00-LER-MOVTO-DB-CLOSE-1 */
        public void R0070_00_LER_MOVTO_DB_CLOSE_1()
        {
            /*" -940- EXEC SQL CLOSE MOVIMENTO-VGAP END-EXEC */

            MOVIMENTO_VGAP.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0070_SAIDA*/

        [StopWatch]
        /*" R0080-00-GERAR-HEADER-SECTION */
        private void R0080_00_GERAR_HEADER_SECTION()
        {
            /*" -985- MOVE 'R0080-00-GERAR-HEADER' TO PARAGRAFO. */
            _.Move("R0080-00-GERAR-HEADER", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -987- MOVE 'WRITE REG-HEADER' TO COMANDO. */
            _.Move("WRITE REG-HEADER", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -989- MOVE SPACES TO REG-HEADER. */
            _.Move("", LXFPF990.REG_HEADER);

            /*" -992- MOVE 'H' TO RH-TIPO-REG OF REG-HEADER */
            _.Move("H", LXFPF990.REG_HEADER.RH_TIPO_REG);

            /*" -995- MOVE 'PRPSASSE' TO RH-NOME OF REG-HEADER */
            _.Move("PRPSASSE", LXFPF990.REG_HEADER.RH_NOME);

            /*" -996- MOVE W-DIA-MOVABE OF W-DTMOVABE1 TO W-DIA-TRABALHO */
            _.Move(WAREA_AUXILIAR.W_DTMOVABE1.W_DIA_MOVABE, WAREA_AUXILIAR.FILLER_2.W_DIA_TRABALHO);

            /*" -997- MOVE W-MES-MOVABE OF W-DTMOVABE1 TO W-MES-TRABALHO */
            _.Move(WAREA_AUXILIAR.W_DTMOVABE1.W_MES_MOVABE, WAREA_AUXILIAR.FILLER_2.W_MES_TRABALHO);

            /*" -999- MOVE W-ANO-MOVABE OF W-DTMOVABE1 TO W-ANO-TRABALHO */
            _.Move(WAREA_AUXILIAR.W_DTMOVABE1.W_ANO_MOVABE, WAREA_AUXILIAR.FILLER_2.W_ANO_TRABALHO);

            /*" -1002- MOVE W-DATA-TRABALHO TO RH-DATA-GERACAO OF REG-HEADER */
            _.Move(WAREA_AUXILIAR.W_DATA_TRABALHO, LXFPF990.REG_HEADER.RH_DATA_GERACAO);

            /*" -1005- MOVE 4 TO RH-SIST-ORIGEM OF REG-HEADER */
            _.Move(4, LXFPF990.REG_HEADER.RH_SIST_ORIGEM);

            /*" -1008- MOVE 1 TO RH-SIST-DESTINO OF REG-HEADER */
            _.Move(1, LXFPF990.REG_HEADER.RH_SIST_DESTINO);

            /*" -1011- MOVE ARQSIVPF-NSAS-SIVPF OF DCLARQUIVOS-SIVPF TO RH-NSAS OF REG-HEADER */
            _.Move(ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF, LXFPF990.REG_HEADER.RH_NSAS);

            /*" -1013- MOVE 1 TO RH-TIPO-ARQUIVO OF REG-HEADER. */
            _.Move(1, LXFPF990.REG_HEADER.RH_TIPO_ARQUIVO);

            /*" -1013- WRITE REG-PRP-SASSE FROM REG-HEADER. */
            _.Move(LXFPF990.REG_HEADER.GetMoveValues(), REG_PRP_SASSE);

            MOVTO_PRP_SASSE.Write(REG_PRP_SASSE.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0080_SAIDA*/

        [StopWatch]
        /*" R0150-00-PROCESSAR-MOVIMENTO-SECTION */
        private void R0150_00_PROCESSAR_MOVIMENTO_SECTION()
        {
            /*" -1023- MOVE 'R0150-00-PROCESSA-MOVIMENTO' TO PARAGRAFO. */
            _.Move("R0150-00-PROCESSA-MOVIMENTO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1025- MOVE '    ' TO COMANDO. */
            _.Move("    ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1027- MOVE SPACES TO REG-CLIENTES. */
            _.Move("", LBFPF011.REG_CLIENTES);

            /*" -1031- IF MOVVGAP-NUM-CERTIFICADO NOT LESS 10000000000 AND MOVVGAP-NUM-CERTIFICADO NOT GREATER 19999999999 */

            if (MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_NUM_CERTIFICADO >= 10000000000 && MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_NUM_CERTIFICADO <= 19999999999)
            {

                /*" -1033- MOVE MOVVGAP-NUM-CERTIFICADO TO W-NUM-PROPOSTA-ATUAL */
                _.Move(MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_NUM_CERTIFICADO, WAREA_AUXILIAR.FILLER_7.W_NUM_PROPOSTA_ATUAL);

                /*" -1035- MOVE MOVVGAP-DAC-CERTIFICADO TO W-DV-PROPOSTA-NOVA */
                _.Move(MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_DAC_CERTIFICADO, WAREA_AUXILIAR.FILLER_7.W_DV_PROPOSTA_NOVA);

                /*" -1036- ELSE */
            }
            else
            {


                /*" -1041- MOVE MOVVGAP-NUM-CERTIFICADO TO W-NUM-PROPOSTA-NOVA. */
                _.Move(MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_NUM_CERTIFICADO, WAREA_AUXILIAR.W_NUM_PROPOSTA_NOVA);
            }


            /*" -1042- MOVE 'NAO' TO W-EXISTE-FIDELIZ. */
            _.Move("NAO", WAREA_AUXILIAR.W_EXISTE_FIDELIZ);

            /*" -1045- MOVE ZEROS TO WS-SQLCODE-R0711 WS-SQLCODE-R0720 */
            _.Move(0, WS_SQLCODE_R0711, WS_SQLCODE_R0720);

            /*" -1046- PERFORM R0710-00-OBTER-DATA-CREDITO. */

            R0710_00_OBTER_DATA_CREDITO_SECTION();

            /*" -1048- PERFORM R0711-00-FETCH-DATA-CREDITO. */

            R0711_00_FETCH_DATA_CREDITO_SECTION();

            /*" -1052- IF WS-SQLCODE-R0711 EQUAL 100 */

            if (WS_SQLCODE_R0711 == 100)
            {

                /*" -1053- MOVE MOVVGAP-NUM-CERTIFICADO TO NUM-PROPOSTA-SIVPF */
                _.Move(MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_NUM_CERTIFICADO, PROPFID.DCLPROPOSTA_FIDELIZ.NUM_PROPOSTA_SIVPF);

                /*" -1054- IF RELATORI-PERI-FINAL < W-DT-ATUAL-MENOS-6MESES */

                if (RELATORI.DCLRELATORIOS.RELATORI_PERI_FINAL < WAREA_AUXILIAR.W_DT_ATUAL_MENOS_6MESES)
                {

                    /*" -1055- ADD 1 TO W-R0711 */
                    WAREA_AUXILIAR.W_R0711.Value = WAREA_AUXILIAR.W_R0711 + 1;

                    /*" -1056- PERFORM R0740-00-UPDATE-RELATORIOS */

                    R0740_00_UPDATE_RELATORIOS_SECTION();

                    /*" -1057- END-IF */
                }


                /*" -1059- GO TO R0150-LEITURA. */

                R0150_LEITURA(); //GOTO
                return;
            }


            /*" -1061- PERFORM R0200-00-LER-PROP-FIDELIZ. */

            R0200_00_LER_PROP_FIDELIZ_SECTION();

            /*" -1063- PERFORM R0250-00-LER-PROPOSTAVA. */

            R0250_00_LER_PROPOSTAVA_SECTION();

            /*" -1064- IF VIND-FAIXA-RENDA-IND LESS 0 */

            if (VIND_FAIXA_RENDA_IND < 0)
            {

                /*" -1066- MOVE SPACE TO R1-RENDA-INDIVIDUAL. */
                _.Move("", LBFPF011.REG_CLIENTES.R1_RENDA_INDIVIDUAL);
            }


            /*" -1067- IF SQLCODE NOT EQUAL 100 */

            if (DB.SQLCODE != 100)
            {

                /*" -1072- PERFORM R0300-00-LER-CLIENTE */

                R0300_00_LER_CLIENTE_SECTION();

                /*" -1074- IF VIND-DTNASCI LESS ZEROS AND CGCCPF OF DCLCLIENTES EQUAL ZEROS */

                if (VIND_DTNASCI < 00 && CLIENTE.DCLCLIENTES.CGCCPF == 00)
                {

                    /*" -1075- DISPLAY 'PF0648B - SEGURO NAO ENVIADO A CEF' */
                    _.Display($"PF0648B - SEGURO NAO ENVIADO A CEF");

                    /*" -1078- DISPLAY '          CPF/DT.NASCIMENTO ZEROS   ' NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ '  ' COD-CLIENTE OF DCLCLIENTES */

                    $"          CPF/DT.NASCIMENTO ZEROS   {PROPFID.DCLPROPOSTA_FIDELIZ.NUM_PROPOSTA_SIVPF}  {CLIENTE.DCLCLIENTES.COD_CLIENTE}"
                    .Display();

                    /*" -1079- ADD 1 TO W-DESPREZADO */
                    WAREA_AUXILIAR.W_DESPREZADO.Value = WAREA_AUXILIAR.W_DESPREZADO + 1;

                    /*" -1080- ELSE */
                }
                else
                {


                    /*" -1081- PERFORM R0350-00-LER-ENDERECO */

                    R0350_00_LER_ENDERECO_SECTION();

                    /*" -1082- PERFORM R0400-00-LER-PROFISSAO */

                    R0400_00_LER_PROFISSAO_SECTION();

                    /*" -1084- PERFORM R0720-00-OBTER-DADOS-LANC */

                    R0720_00_OBTER_DADOS_LANC_SECTION();

                    /*" -1088- IF WS-SQLCODE-R0720 NOT EQUAL 00 */

                    if (WS_SQLCODE_R0720 != 00)
                    {

                        /*" -1089- MOVE MOVVGAP-NUM-CERTIFICADO TO NUM-PROPOSTA-SIVPF */
                        _.Move(MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_NUM_CERTIFICADO, PROPFID.DCLPROPOSTA_FIDELIZ.NUM_PROPOSTA_SIVPF);

                        /*" -1090- IF RELATORI-PERI-FINAL < W-DT-ATUAL-MENOS-6MESES */

                        if (RELATORI.DCLRELATORIOS.RELATORI_PERI_FINAL < WAREA_AUXILIAR.W_DT_ATUAL_MENOS_6MESES)
                        {

                            /*" -1091- ADD 1 TO W-R0720 */
                            WAREA_AUXILIAR.W_R0720.Value = WAREA_AUXILIAR.W_R0720 + 1;

                            /*" -1092- PERFORM R0740-00-UPDATE-RELATORIOS */

                            R0740_00_UPDATE_RELATORIOS_SECTION();

                            /*" -1093- END-IF */
                        }


                        /*" -1094- GO TO R0150-LEITURA */

                        R0150_LEITURA(); //GOTO
                        return;

                        /*" -1096- END-IF */
                    }


                    /*" -1097- PERFORM R0550-00-LER-OPCAOPAGVA */

                    R0550_00_LER_OPCAOPAGVA_SECTION();

                    /*" -1098- PERFORM R0570-00-LER-COMISSAO */

                    R0570_00_LER_COMISSAO_SECTION();

                    /*" -1099- PERFORM R0580-00-OBTER-VAL-TARIFA */

                    R0580_00_OBTER_VAL_TARIFA_SECTION();

                    /*" -1100- PERFORM R0600-00-GERAR-REGISTRO-TP1 */

                    R0600_00_GERAR_REGISTRO_TP1_SECTION();

                    /*" -1103- PERFORM R0650-00-GERAR-REGISTRO-TP2 */

                    R0650_00_GERAR_REGISTRO_TP2_SECTION();

                    /*" -1104- PERFORM R0700-00-GERAR-REGISTRO-TP3 */

                    R0700_00_GERAR_REGISTRO_TP3_SECTION();

                    /*" -1105- PERFORM R0730-ATUALIZA-FIDELIZACAO */

                    R0730_ATUALIZA_FIDELIZACAO_SECTION();

                    /*" -1105- PERFORM R0740-00-UPDATE-RELATORIOS. */

                    R0740_00_UPDATE_RELATORIOS_SECTION();
                }

            }


            /*" -0- FLUXCONTROL_PERFORM R0150_LEITURA */

            R0150_LEITURA();

        }

        [StopWatch]
        /*" R0150-LEITURA */
        private void R0150_LEITURA(bool isPerform = false)
        {
            /*" -1110- IF W-FIM-MOVTO-VGAP NOT EQUAL 'FIM' */

            if (WAREA_AUXILIAR.W_FIM_MOVTO_VGAP != "FIM")
            {

                /*" -1110- PERFORM R0070-00-LER-MOVTO. */

                R0070_00_LER_MOVTO_SECTION();
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0150_SAIDA*/

        [StopWatch]
        /*" R0200-00-LER-PROP-FIDELIZ-SECTION */
        private void R0200_00_LER_PROP_FIDELIZ_SECTION()
        {
            /*" -1120- MOVE 'R0200-00-LER-PROP-FIDELIZ' TO PARAGRAFO. */
            _.Move("R0200-00-LER-PROP-FIDELIZ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1122- MOVE 'SELECT PROPOSTA-FIDELIZ' TO COMANDO. */
            _.Move("SELECT PROPOSTA-FIDELIZ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1125- MOVE MOVVGAP-NUM-CERTIFICADO TO NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ. */
            _.Move(MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_NUM_CERTIFICADO, PROPFID.DCLPROPOSTA_FIDELIZ.NUM_PROPOSTA_SIVPF);

            /*" -1152- PERFORM R0200_00_LER_PROP_FIDELIZ_DB_SELECT_1 */

            R0200_00_LER_PROP_FIDELIZ_DB_SELECT_1();

            /*" -1155- IF SQLCODE EQUAL 00 */

            if (DB.SQLCODE == 00)
            {

                /*" -1156- MOVE 'SIM' TO W-EXISTE-FIDELIZ */
                _.Move("SIM", WAREA_AUXILIAR.W_EXISTE_FIDELIZ);

                /*" -1157- ELSE */
            }
            else
            {


                /*" -1158- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1159- MOVE 'NAO' TO W-EXISTE-FIDELIZ */
                    _.Move("NAO", WAREA_AUXILIAR.W_EXISTE_FIDELIZ);

                    /*" -1160- ELSE */
                }
                else
                {


                    /*" -1161- DISPLAY 'PF0648B - FIM ANORMAL' */
                    _.Display($"PF0648B - FIM ANORMAL");

                    /*" -1162- DISPLAY '          ERRO SELECT PROPOSTA-FIDELIZ' */
                    _.Display($"          ERRO SELECT PROPOSTA-FIDELIZ");

                    /*" -1164- DISPLAY '          NUMERO DA PROPOSTA......... ' NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ */
                    _.Display($"          NUMERO DA PROPOSTA......... {PROPFID.DCLPROPOSTA_FIDELIZ.NUM_PROPOSTA_SIVPF}");

                    /*" -1166- DISPLAY '          SQLCODE.................... ' SQLCODE */
                    _.Display($"          SQLCODE.................... {DB.SQLCODE}");

                    /*" -1167- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -1167- PERFORM R9999-00-FINALIZAR. */

                    R9999_00_FINALIZAR_SECTION();
                }

            }


        }

        [StopWatch]
        /*" R0200-00-LER-PROP-FIDELIZ-DB-SELECT-1 */
        public void R0200_00_LER_PROP_FIDELIZ_DB_SELECT_1()
        {
            /*" -1152- EXEC SQL SELECT COD_PRODUTO_SIVPF, SIT_PROPOSTA, NUM_SICOB, DATA_PROPOSTA, AGECOBR, NOME_CONVENENTE, NRMATRCON, CGC_CONVENENTE, PERC_DESCONTO, COD_PLANO, ORIGEM_PROPOSTA INTO :DCLPROPOSTA-FIDELIZ.COD-PRODUTO-SIVPF, :DCLPROPOSTA-FIDELIZ.SIT-PROPOSTA, :DCLPROPOSTA-FIDELIZ.NUM-SICOB, :DCLPROPOSTA-FIDELIZ.DATA-PROPOSTA, :DCLPROPOSTA-FIDELIZ.AGECOBR, :DCLPROPOSTA-FIDELIZ.NOME-CONVENENTE, :DCLPROPOSTA-FIDELIZ.NRMATRCON, :DCLPROPOSTA-FIDELIZ.CGC-CONVENENTE, :DCLPROPOSTA-FIDELIZ.PERC-DESCONTO, :DCLPROPOSTA-FIDELIZ.COD-PLANO, :DCLPROPOSTA-FIDELIZ.ORIGEM-PROPOSTA FROM SEGUROS.PROPOSTA_FIDELIZ WHERE NUM_PROPOSTA_SIVPF = :DCLPROPOSTA-FIDELIZ.NUM-PROPOSTA-SIVPF WITH UR END-EXEC. */

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
        /*" R0210-00-LER-SICOB-SECTION */
        private void R0210_00_LER_SICOB_SECTION()
        {
            /*" -1177- MOVE 'R0210-00-LER-SICOB' TO PARAGRAFO. */
            _.Move("R0210-00-LER-SICOB", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1179- MOVE 'SELECT PROPOSTA-FIDELIZ' TO COMANDO. */
            _.Move("SELECT PROPOSTA-FIDELIZ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1188- PERFORM R0210_00_LER_SICOB_DB_SELECT_1 */

            R0210_00_LER_SICOB_DB_SELECT_1();

            /*" -1191- IF SQLCODE EQUAL 00 */

            if (DB.SQLCODE == 00)
            {

                /*" -1192- MOVE 'SIM' TO W-EXISTE-FIDELIZ */
                _.Move("SIM", WAREA_AUXILIAR.W_EXISTE_FIDELIZ);

                /*" -1193- ELSE */
            }
            else
            {


                /*" -1194- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1195- MOVE 'NAO' TO W-EXISTE-FIDELIZ */
                    _.Move("NAO", WAREA_AUXILIAR.W_EXISTE_FIDELIZ);

                    /*" -1196- ELSE */
                }
                else
                {


                    /*" -1197- DISPLAY 'PF0648B - FIM ANORMAL' */
                    _.Display($"PF0648B - FIM ANORMAL");

                    /*" -1198- DISPLAY '          ERRO SELECT PROPOSTA-FIDELIZ' */
                    _.Display($"          ERRO SELECT PROPOSTA-FIDELIZ");

                    /*" -1200- DISPLAY '          NUMERO DO SICOB............ ' NUM-SICOB OF DCLPROPOSTA-FIDELIZ */
                    _.Display($"          NUMERO DO SICOB............ {PROPFID.DCLPROPOSTA_FIDELIZ.NUM_SICOB}");

                    /*" -1202- DISPLAY '          SQLCODE.................... ' SQLCODE */
                    _.Display($"          SQLCODE.................... {DB.SQLCODE}");

                    /*" -1203- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -1203- PERFORM R9999-00-FINALIZAR. */

                    R9999_00_FINALIZAR_SECTION();
                }

            }


        }

        [StopWatch]
        /*" R0210-00-LER-SICOB-DB-SELECT-1 */
        public void R0210_00_LER_SICOB_DB_SELECT_1()
        {
            /*" -1188- EXEC SQL SELECT SIT_PROPOSTA, NUM_PROPOSTA_SIVPF INTO :DCLPROPOSTA-FIDELIZ.SIT-PROPOSTA, :DCLPROPOSTA-FIDELIZ.NUM-PROPOSTA-SIVPF FROM SEGUROS.PROPOSTA_FIDELIZ WHERE NUM_SICOB = :DCLPROPOSTA-FIDELIZ.NUM-SICOB WITH UR END-EXEC. */

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
        /*" R0250-00-LER-PROPOSTAVA-SECTION */
        private void R0250_00_LER_PROPOSTAVA_SECTION()
        {
            /*" -1213- MOVE 'R0250-00-LER-PROPOSTAVA' TO PARAGRAFO. */
            _.Move("R0250-00-LER-PROPOSTAVA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1215- MOVE 'SELECT PROPOSTA-VA' TO COMANDO. */
            _.Move("SELECT PROPOSTA-VA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1218- MOVE MOVVGAP-NUM-CERTIFICADO TO NUM-CERTIFICADO OF DCLPROPOSTAS-VA. */
            _.Move(MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_NUM_CERTIFICADO, PROPVA.DCLPROPOSTAS_VA.NUM_CERTIFICADO);

            /*" -1311- PERFORM R0250_00_LER_PROPOSTAVA_DB_SELECT_1 */

            R0250_00_LER_PROPOSTAVA_DB_SELECT_1();

            /*" -1314- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -1315- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1316- ADD 1 TO W-DESPREZADO */
                    WAREA_AUXILIAR.W_DESPREZADO.Value = WAREA_AUXILIAR.W_DESPREZADO + 1;

                    /*" -1319- DISPLAY 'PF0648B - CERTIFICADO NAO EXISTE PROPOSTAVA   ' NUM-CERTIFICADO OF DCLPROPOSTAS-VA '   SITUACAO ' SIT-REGISTRO OF DCLPROPOSTAS-VA */

                    $"PF0648B - CERTIFICADO NAO EXISTE PROPOSTAVA   {PROPVA.DCLPROPOSTAS_VA.NUM_CERTIFICADO}   SITUACAO {PROPVA.DCLPROPOSTAS_VA.SIT_REGISTRO}"
                    .Display();

                    /*" -1320- ELSE */
                }
                else
                {


                    /*" -1321- DISPLAY 'PF0648B - FIM ANORMAL' */
                    _.Display($"PF0648B - FIM ANORMAL");

                    /*" -1322- DISPLAY '          ERRO SELECT PROPOSTA-VA' */
                    _.Display($"          ERRO SELECT PROPOSTA-VA");

                    /*" -1324- DISPLAY '          NUMERO CERTIFICADO..... ' NUM-CERTIFICADO OF DCLPROPOSTAS-VA */
                    _.Display($"          NUMERO CERTIFICADO..... {PROPVA.DCLPROPOSTAS_VA.NUM_CERTIFICADO}");

                    /*" -1326- DISPLAY '          SQLCODE................ ' SQLCODE */
                    _.Display($"          SQLCODE................ {DB.SQLCODE}");

                    /*" -1327- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -1327- PERFORM R9999-00-FINALIZAR. */

                    R9999_00_FINALIZAR_SECTION();
                }

            }


        }

        [StopWatch]
        /*" R0250-00-LER-PROPOSTAVA-DB-SELECT-1 */
        public void R0250_00_LER_PROPOSTAVA_DB_SELECT_1()
        {
            /*" -1311- EXEC SQL SELECT NUM_CERTIFICADO , COD_PRODUTO , COD_CLIENTE , OCOREND , COD_FONTE , AGE_COBRANCA , OPCAO_COBERTURA , DATA_QUITACAO , COD_AGE_VENDEDOR , OPE_CONTA_VENDEDOR , NUM_CONTA_VENDEDOR , DIG_CONTA_VENDEDOR , NUM_MATRI_VENDEDOR , COD_OPERACAO , PROFISSAO , DTINCLUS , DATA_MOVIMENTO , SIT_REGISTRO , NUM_APOLICE , COD_SUBGRUPO , OCORR_HISTORICO , NRPRIPARATZ , QTDPARATZ , DTPROXVEN , NUM_PARCELA , DATA_VENCIMENTO , SIT_INTERFACE , DTFENAE , COD_USUARIO , TIMESTAMP , IDADE , IDE_SEXO , ESTADO_CIVIL , APOS_INVALIDEZ , NOME_ESPOSA , DTNASC_ESPOSA , PROFIS_ESPOSA , DPS_TITULAR , DPS_ESPOSA , INFO_COMPLEMENTAR , COD_CCT, FAIXA_RENDA_IND, FAIXA_RENDA_FAM INTO :DCLPROPOSTAS-VA.NUM-CERTIFICADO , :DCLPROPOSTAS-VA.COD-PRODUTO , :DCLPROPOSTAS-VA.COD-CLIENTE , :DCLPROPOSTAS-VA.OCOREND , :DCLPROPOSTAS-VA.COD-FONTE , :DCLPROPOSTAS-VA.AGE-COBRANCA , :DCLPROPOSTAS-VA.OPCAO-COBERTURA , :DCLPROPOSTAS-VA.DATA-QUITACAO , :DCLPROPOSTAS-VA.COD-AGE-VENDEDOR , :DCLPROPOSTAS-VA.OPE-CONTA-VENDEDOR , :DCLPROPOSTAS-VA.NUM-CONTA-VENDEDOR , :DCLPROPOSTAS-VA.DIG-CONTA-VENDEDOR , :DCLPROPOSTAS-VA.NUM-MATRI-VENDEDOR , :DCLPROPOSTAS-VA.COD-OPERACAO , :DCLPROPOSTAS-VA.PROFISSAO , :DCLPROPOSTAS-VA.DTINCLUS , :DCLPROPOSTAS-VA.DATA-MOVIMENTO , :DCLPROPOSTAS-VA.SIT-REGISTRO , :DCLPROPOSTAS-VA.NUM-APOLICE , :DCLPROPOSTAS-VA.COD-SUBGRUPO , :DCLPROPOSTAS-VA.OCORR-HISTORICO , :DCLPROPOSTAS-VA.NRPRIPARATZ , :DCLPROPOSTAS-VA.QTDPARATZ , :DCLPROPOSTAS-VA.DTPROXVEN , :DCLPROPOSTAS-VA.NUM-PARCELA , :DCLPROPOSTAS-VA.DATA-VENCIMENTO , :DCLPROPOSTAS-VA.SIT-INTERFACE , :DCLPROPOSTAS-VA.DTFENAE , :DCLPROPOSTAS-VA.COD-USUARIO , :DCLPROPOSTAS-VA.TIMESTAMP , :DCLPROPOSTAS-VA.IDADE , :DCLPROPOSTAS-VA.IDE-SEXO , :DCLPROPOSTAS-VA.ESTADO-CIVIL , :DCLPROPOSTAS-VA.APOS-INVALIDEZ:VIND-APOS-INVALIDEZ, :DCLPROPOSTAS-VA.NOME-ESPOSA:VIND-NOME-ESPOSA, :DCLPROPOSTAS-VA.DTNASC-ESPOSA:VIND-DTNASC-ESPOSA, :DCLPROPOSTAS-VA.PROFIS-ESPOSA:VIND-PROFIS-ESPOSA, :DCLPROPOSTAS-VA.DPS-TITULAR:VIND-DPS-TITULAR, :DCLPROPOSTAS-VA.DPS-ESPOSA:VIND-DPS-ESPOSA, :DCLPROPOSTAS-VA.INFO-COMPLEMENTAR:VIND-INFO-COMP, :DCLPROPOSTAS-VA.COD-CCT:VIND-COD-CCT, :DCLPROPOSTAS-VA.FAIXA-RENDA-IND:VIND-FAIXA-RENDA-IND, :DCLPROPOSTAS-VA.FAIXA-RENDA-FAM:VIND-FAIXA-RENDA-FAM FROM SEGUROS.PROPOSTAS_VA WHERE NUM_CERTIFICADO = :DCLPROPOSTAS-VA.NUM-CERTIFICADO WITH UR END-EXEC. */

            var r0250_00_LER_PROPOSTAVA_DB_SELECT_1_Query1 = new R0250_00_LER_PROPOSTAVA_DB_SELECT_1_Query1()
            {
                NUM_CERTIFICADO = PROPVA.DCLPROPOSTAS_VA.NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = R0250_00_LER_PROPOSTAVA_DB_SELECT_1_Query1.Execute(r0250_00_LER_PROPOSTAVA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.NUM_CERTIFICADO, PROPVA.DCLPROPOSTAS_VA.NUM_CERTIFICADO);
                _.Move(executed_1.COD_PRODUTO, PROPVA.DCLPROPOSTAS_VA.COD_PRODUTO);
                _.Move(executed_1.COD_CLIENTE, PROPVA.DCLPROPOSTAS_VA.COD_CLIENTE);
                _.Move(executed_1.OCOREND, PROPVA.DCLPROPOSTAS_VA.OCOREND);
                _.Move(executed_1.COD_FONTE, PROPVA.DCLPROPOSTAS_VA.COD_FONTE);
                _.Move(executed_1.AGE_COBRANCA, PROPVA.DCLPROPOSTAS_VA.AGE_COBRANCA);
                _.Move(executed_1.OPCAO_COBERTURA, PROPVA.DCLPROPOSTAS_VA.OPCAO_COBERTURA);
                _.Move(executed_1.DATA_QUITACAO, PROPVA.DCLPROPOSTAS_VA.DATA_QUITACAO);
                _.Move(executed_1.COD_AGE_VENDEDOR, PROPVA.DCLPROPOSTAS_VA.COD_AGE_VENDEDOR);
                _.Move(executed_1.OPE_CONTA_VENDEDOR, PROPVA.DCLPROPOSTAS_VA.OPE_CONTA_VENDEDOR);
                _.Move(executed_1.NUM_CONTA_VENDEDOR, PROPVA.DCLPROPOSTAS_VA.NUM_CONTA_VENDEDOR);
                _.Move(executed_1.DIG_CONTA_VENDEDOR, PROPVA.DCLPROPOSTAS_VA.DIG_CONTA_VENDEDOR);
                _.Move(executed_1.NUM_MATRI_VENDEDOR, PROPVA.DCLPROPOSTAS_VA.NUM_MATRI_VENDEDOR);
                _.Move(executed_1.COD_OPERACAO, PROPVA.DCLPROPOSTAS_VA.COD_OPERACAO);
                _.Move(executed_1.PROFISSAO, PROPVA.DCLPROPOSTAS_VA.PROFISSAO);
                _.Move(executed_1.DTINCLUS, PROPVA.DCLPROPOSTAS_VA.DTINCLUS);
                _.Move(executed_1.DATA_MOVIMENTO, PROPVA.DCLPROPOSTAS_VA.DATA_MOVIMENTO);
                _.Move(executed_1.SIT_REGISTRO, PROPVA.DCLPROPOSTAS_VA.SIT_REGISTRO);
                _.Move(executed_1.NUM_APOLICE, PROPVA.DCLPROPOSTAS_VA.NUM_APOLICE);
                _.Move(executed_1.COD_SUBGRUPO, PROPVA.DCLPROPOSTAS_VA.COD_SUBGRUPO);
                _.Move(executed_1.OCORR_HISTORICO, PROPVA.DCLPROPOSTAS_VA.OCORR_HISTORICO);
                _.Move(executed_1.NRPRIPARATZ, PROPVA.DCLPROPOSTAS_VA.NRPRIPARATZ);
                _.Move(executed_1.QTDPARATZ, PROPVA.DCLPROPOSTAS_VA.QTDPARATZ);
                _.Move(executed_1.DTPROXVEN, PROPVA.DCLPROPOSTAS_VA.DTPROXVEN);
                _.Move(executed_1.NUM_PARCELA, PROPVA.DCLPROPOSTAS_VA.NUM_PARCELA);
                _.Move(executed_1.DATA_VENCIMENTO, PROPVA.DCLPROPOSTAS_VA.DATA_VENCIMENTO);
                _.Move(executed_1.SIT_INTERFACE, PROPVA.DCLPROPOSTAS_VA.SIT_INTERFACE);
                _.Move(executed_1.DTFENAE, PROPVA.DCLPROPOSTAS_VA.DTFENAE);
                _.Move(executed_1.COD_USUARIO, PROPVA.DCLPROPOSTAS_VA.COD_USUARIO);
                _.Move(executed_1.TIMESTAMP, PROPVA.DCLPROPOSTAS_VA.TIMESTAMP);
                _.Move(executed_1.IDADE, PROPVA.DCLPROPOSTAS_VA.IDADE);
                _.Move(executed_1.IDE_SEXO, PROPVA.DCLPROPOSTAS_VA.IDE_SEXO);
                _.Move(executed_1.ESTADO_CIVIL, PROPVA.DCLPROPOSTAS_VA.ESTADO_CIVIL);
                _.Move(executed_1.APOS_INVALIDEZ, PROPVA.DCLPROPOSTAS_VA.APOS_INVALIDEZ);
                _.Move(executed_1.VIND_APOS_INVALIDEZ, VIND_APOS_INVALIDEZ);
                _.Move(executed_1.NOME_ESPOSA, PROPVA.DCLPROPOSTAS_VA.NOME_ESPOSA);
                _.Move(executed_1.VIND_NOME_ESPOSA, VIND_NOME_ESPOSA);
                _.Move(executed_1.DTNASC_ESPOSA, PROPVA.DCLPROPOSTAS_VA.DTNASC_ESPOSA);
                _.Move(executed_1.VIND_DTNASC_ESPOSA, VIND_DTNASC_ESPOSA);
                _.Move(executed_1.PROFIS_ESPOSA, PROPVA.DCLPROPOSTAS_VA.PROFIS_ESPOSA);
                _.Move(executed_1.VIND_PROFIS_ESPOSA, VIND_PROFIS_ESPOSA);
                _.Move(executed_1.DPS_TITULAR, PROPVA.DCLPROPOSTAS_VA.DPS_TITULAR);
                _.Move(executed_1.VIND_DPS_TITULAR, VIND_DPS_TITULAR);
                _.Move(executed_1.DPS_ESPOSA, PROPVA.DCLPROPOSTAS_VA.DPS_ESPOSA);
                _.Move(executed_1.VIND_DPS_ESPOSA, VIND_DPS_ESPOSA);
                _.Move(executed_1.INFO_COMPLEMENTAR, PROPVA.DCLPROPOSTAS_VA.INFO_COMPLEMENTAR);
                _.Move(executed_1.VIND_INFO_COMP, VIND_INFO_COMP);
                _.Move(executed_1.COD_CCT, PROPVA.DCLPROPOSTAS_VA.COD_CCT);
                _.Move(executed_1.VIND_COD_CCT, VIND_COD_CCT);
                _.Move(executed_1.FAIXA_RENDA_IND, PROPVA.DCLPROPOSTAS_VA.FAIXA_RENDA_IND);
                _.Move(executed_1.VIND_FAIXA_RENDA_IND, VIND_FAIXA_RENDA_IND);
                _.Move(executed_1.FAIXA_RENDA_FAM, PROPVA.DCLPROPOSTAS_VA.FAIXA_RENDA_FAM);
                _.Move(executed_1.VIND_FAIXA_RENDA_FAM, VIND_FAIXA_RENDA_FAM);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0250_SAIDA*/

        [StopWatch]
        /*" R0300-00-LER-CLIENTE-SECTION */
        private void R0300_00_LER_CLIENTE_SECTION()
        {
            /*" -1337- MOVE 'R0300-00-LER-CLIENTES' TO PARAGRAFO. */
            _.Move("R0300-00-LER-CLIENTES", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1339- MOVE 'SELECT CLIENTES' TO COMANDO. */
            _.Move("SELECT CLIENTES", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1342- MOVE MOVVGAP-COD-CLIENTE TO COD-CLIENTE OF DCLCLIENTES. */
            _.Move(MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_COD_CLIENTE, CLIENTE.DCLCLIENTES.COD_CLIENTE);

            /*" -1360- PERFORM R0300_00_LER_CLIENTE_DB_SELECT_1 */

            R0300_00_LER_CLIENTE_DB_SELECT_1();

            /*" -1363- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -1364- DISPLAY 'PF0648B - FIM ANORMAL' */
                _.Display($"PF0648B - FIM ANORMAL");

                /*" -1365- DISPLAY '          ERRO SELECT TABELA CLIENTES' */
                _.Display($"          ERRO SELECT TABELA CLIENTES");

                /*" -1367- DISPLAY '          NUMERO CERTIFICADO......... ' NUM-CERTIFICADO OF DCLPROPOSTAS-VA */
                _.Display($"          NUMERO CERTIFICADO......... {PROPVA.DCLPROPOSTAS_VA.NUM_CERTIFICADO}");

                /*" -1369- DISPLAY '          CODIGO DO CLIENTE.......... ' COD-CLIENTE OF DCLCLIENTES */
                _.Display($"          CODIGO DO CLIENTE.......... {CLIENTE.DCLCLIENTES.COD_CLIENTE}");

                /*" -1371- DISPLAY '          SQLCODE.................... ' SQLCODE */
                _.Display($"          SQLCODE.................... {DB.SQLCODE}");

                /*" -1372- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -1372- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R0300-00-LER-CLIENTE-DB-SELECT-1 */
        public void R0300_00_LER_CLIENTE_DB_SELECT_1()
        {
            /*" -1360- EXEC SQL SELECT COD_CLIENTE , NOME_RAZAO , TIPO_PESSOA , CGCCPF , SIT_REGISTRO , DATA_NASCIMENTO INTO :DCLCLIENTES.COD-CLIENTE , :DCLCLIENTES.NOME-RAZAO , :DCLCLIENTES.TIPO-PESSOA , :DCLCLIENTES.CGCCPF , :DCLCLIENTES.SIT-REGISTRO , :DCLCLIENTES.DATA-NASCIMENTO:VIND-DTNASCI FROM SEGUROS.CLIENTES WHERE COD_CLIENTE = :DCLCLIENTES.COD-CLIENTE WITH UR END-EXEC. */

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
        /*" R0350-00-LER-ENDERECO-SECTION */
        private void R0350_00_LER_ENDERECO_SECTION()
        {
            /*" -1382- MOVE 'R0350-00-LER-ENDERECO' TO PARAGRAFO. */
            _.Move("R0350-00-LER-ENDERECO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1384- MOVE 'SELECT ENDERECOS' TO COMANDO. */
            _.Move("SELECT ENDERECOS", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1387- MOVE MOVVGAP-COD-CLIENTE TO ENDERECO-COD-CLIENTE OF DCLENDERECOS. */
            _.Move(MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_COD_CLIENTE, ENDERECO.DCLENDERECOS.ENDERECO_COD_CLIENTE);

            /*" -1424- PERFORM R0350_00_LER_ENDERECO_DB_SELECT_1 */

            R0350_00_LER_ENDERECO_DB_SELECT_1();

            /*" -1427- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -1428- DISPLAY 'PF0648B - FIM ANORMAL' */
                _.Display($"PF0648B - FIM ANORMAL");

                /*" -1429- DISPLAY '          ERRO SELECT TABELA ENDERECOS' */
                _.Display($"          ERRO SELECT TABELA ENDERECOS");

                /*" -1431- DISPLAY '          NUMERO CERTIFICADO.......... ' NUM-CERTIFICADO OF DCLPROPOSTAS-VA */
                _.Display($"          NUMERO CERTIFICADO.......... {PROPVA.DCLPROPOSTAS_VA.NUM_CERTIFICADO}");

                /*" -1433- DISPLAY '          CODIGO DO CLIENTE........... ' ENDERECO-COD-CLIENTE OF DCLENDERECOS */
                _.Display($"          CODIGO DO CLIENTE........... {ENDERECO.DCLENDERECOS.ENDERECO_COD_CLIENTE}");

                /*" -1435- DISPLAY '          SQLCODE..................... ' SQLCODE */
                _.Display($"          SQLCODE..................... {DB.SQLCODE}");

                /*" -1436- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -1436- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R0350-00-LER-ENDERECO-DB-SELECT-1 */
        public void R0350_00_LER_ENDERECO_DB_SELECT_1()
        {
            /*" -1424- EXEC SQL SELECT COD_CLIENTE , COD_ENDERECO , OCORR_ENDERECO , ENDERECO , BAIRRO , CIDADE , SIGLA_UF , CEP , DDD , TELEFONE , FAX , TELEX , SIT_REGISTRO INTO :DCLENDERECOS.ENDERECO-COD-CLIENTE , :DCLENDERECOS.ENDERECO-COD-ENDERECO , :DCLENDERECOS.ENDERECO-OCORR-ENDERECO , :DCLENDERECOS.ENDERECO-ENDERECO , :DCLENDERECOS.ENDERECO-BAIRRO , :DCLENDERECOS.ENDERECO-CIDADE , :DCLENDERECOS.ENDERECO-SIGLA-UF , :DCLENDERECOS.ENDERECO-CEP , :DCLENDERECOS.ENDERECO-DDD , :DCLENDERECOS.ENDERECO-TELEFONE , :DCLENDERECOS.ENDERECO-FAX , :DCLENDERECOS.ENDERECO-TELEX , :DCLENDERECOS.ENDERECO-SIT-REGISTRO FROM SEGUROS.ENDERECOS A WHERE A.COD_CLIENTE = :DCLENDERECOS.ENDERECO-COD-CLIENTE AND A.OCORR_ENDERECO = (SELECT MAX (B.OCORR_ENDERECO) FROM SEGUROS.ENDERECOS B WHERE B.COD_CLIENTE = A.COD_CLIENTE) WITH UR END-EXEC. */

            var r0350_00_LER_ENDERECO_DB_SELECT_1_Query1 = new R0350_00_LER_ENDERECO_DB_SELECT_1_Query1()
            {
                ENDERECO_COD_CLIENTE = ENDERECO.DCLENDERECOS.ENDERECO_COD_CLIENTE.ToString(),
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
            /*" -1449- MOVE 'R0400-00-LER-PROFISSAO' TO PARAGRAFO. */
            _.Move("R0400-00-LER-PROFISSAO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1451- IF PROFISSAO OF DCLPROPOSTAS-VA NOT EQUAL SPACES */

            if (!PROPVA.DCLPROPOSTAS_VA.PROFISSAO.IsEmpty())
            {

                /*" -1453- IF PROFISSAO OF DCLPROPOSTAS-VA NOT EQUAL 'OUTROS' */

                if (PROPVA.DCLPROPOSTAS_VA.PROFISSAO != "OUTROS")
                {

                    /*" -1457- MOVE PROFISSAO OF DCLPROPOSTAS-VA TO CBO-DESCR-CBO OF DCLCBO R1-DESCRICAO-PROFISSAO */
                    _.Move(PROPVA.DCLPROPOSTAS_VA.PROFISSAO, CBO.DCLCBO.CBO_DESCR_CBO, LBFPF011.REG_CLIENTES.R1_DESCRICAO_PROFISSAO);

                    /*" -1459- PERFORM R0410-00-LER-CBO */

                    R0410_00_LER_CBO_SECTION();

                    /*" -1460- IF SQLCODE EQUAL 00 */

                    if (DB.SQLCODE == 00)
                    {

                        /*" -1462- MOVE CBO-COD-CBO OF DCLCBO TO COD-CBO-TIT */
                        _.Move(CBO.DCLCBO.CBO_COD_CBO, COD_CBO_TIT);

                        /*" -1463- ELSE */
                    }
                    else
                    {


                        /*" -1464- MOVE ZEROS TO COD-CBO-TIT */
                        _.Move(0, COD_CBO_TIT);

                        /*" -1465- ELSE */
                    }

                }
                else
                {


                    /*" -1466- MOVE ZEROS TO COD-CBO-TIT */
                    _.Move(0, COD_CBO_TIT);

                    /*" -1468- MOVE PROFISSAO OF DCLPROPOSTAS-VA TO R1-DESCRICAO-PROFISSAO */
                    _.Move(PROPVA.DCLPROPOSTAS_VA.PROFISSAO, LBFPF011.REG_CLIENTES.R1_DESCRICAO_PROFISSAO);

                    /*" -1469- ELSE */
                }

            }
            else
            {


                /*" -1470- MOVE 'OUTROS' TO R1-DESCRICAO-PROFISSAO */
                _.Move("OUTROS", LBFPF011.REG_CLIENTES.R1_DESCRICAO_PROFISSAO);

                /*" -1474- MOVE ZEROS TO COD-CBO-TIT. */
                _.Move(0, COD_CBO_TIT);
            }


            /*" -1475- IF VIND-PROFIS-ESPOSA LESS ZEROS */

            if (VIND_PROFIS_ESPOSA < 00)
            {

                /*" -1476- MOVE ZEROS TO COD-CBO-CONJ */
                _.Move(0, COD_CBO_CONJ);

                /*" -1477- ELSE */
            }
            else
            {


                /*" -1479- IF PROFIS-ESPOSA OF DCLPROPOSTAS-VA NOT EQUAL SPACES */

                if (!PROPVA.DCLPROPOSTAS_VA.PROFIS_ESPOSA.IsEmpty())
                {

                    /*" -1481- IF PROFIS-ESPOSA OF DCLPROPOSTAS-VA NOT EQUAL 'OUTROS' */

                    if (PROPVA.DCLPROPOSTAS_VA.PROFIS_ESPOSA != "OUTROS")
                    {

                        /*" -1484- MOVE PROFIS-ESPOSA OF DCLPROPOSTAS-VA TO CBO-DESCR-CBO OF DCLCBO */
                        _.Move(PROPVA.DCLPROPOSTAS_VA.PROFIS_ESPOSA, CBO.DCLCBO.CBO_DESCR_CBO);

                        /*" -1486- PERFORM R0410-00-LER-CBO */

                        R0410_00_LER_CBO_SECTION();

                        /*" -1487- IF SQLCODE EQUAL 00 */

                        if (DB.SQLCODE == 00)
                        {

                            /*" -1489- MOVE CBO-COD-CBO OF DCLCBO TO COD-CBO-CONJ */
                            _.Move(CBO.DCLCBO.CBO_COD_CBO, COD_CBO_CONJ);

                            /*" -1490- ELSE */
                        }
                        else
                        {


                            /*" -1491- MOVE ZEROS TO COD-CBO-CONJ */
                            _.Move(0, COD_CBO_CONJ);

                            /*" -1492- ELSE */
                        }

                    }
                    else
                    {


                        /*" -1493- MOVE ZEROS TO COD-CBO-CONJ */
                        _.Move(0, COD_CBO_CONJ);

                        /*" -1494- ELSE */
                    }

                }
                else
                {


                    /*" -1494- MOVE ZEROS TO COD-CBO-CONJ. */
                    _.Move(0, COD_CBO_CONJ);
                }

            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0400_SAIDA*/

        [StopWatch]
        /*" R0410-00-LER-CBO-SECTION */
        private void R0410_00_LER_CBO_SECTION()
        {
            /*" -1504- MOVE 'R0400-00-LER-CBO' TO PARAGRAFO. */
            _.Move("R0400-00-LER-CBO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1506- MOVE 'SELECT CBO' TO COMANDO. */
            _.Move("SELECT CBO", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1520- PERFORM R0410_00_LER_CBO_DB_SELECT_1 */

            R0410_00_LER_CBO_DB_SELECT_1();

            /*" -1523- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -1525- IF SQLCODE EQUAL 811 OR -811 NEXT SENTENCE */

                if (DB.SQLCODE.In("811", "-811"))
                {

                    /*" -1526- ELSE */
                }
                else
                {


                    /*" -1527- IF SQLCODE NOT EQUAL 100 */

                    if (DB.SQLCODE != 100)
                    {

                        /*" -1528- DISPLAY 'PF0648B - FIM ANORMAL' */
                        _.Display($"PF0648B - FIM ANORMAL");

                        /*" -1529- DISPLAY '          ERRO SELECT TABELA CBO' */
                        _.Display($"          ERRO SELECT TABELA CBO");

                        /*" -1531- DISPLAY '          NUMERO CERTIFICADO...... ' NUM-CERTIFICADO OF DCLPROPOSTAS-VA */
                        _.Display($"          NUMERO CERTIFICADO...... {PROPVA.DCLPROPOSTAS_VA.NUM_CERTIFICADO}");

                        /*" -1533- DISPLAY '          DESCRICAO DA PROFISSAO.. ' CBO-DESCR-CBO OF DCLCBO */
                        _.Display($"          DESCRICAO DA PROFISSAO.. {CBO.DCLCBO.CBO_DESCR_CBO}");

                        /*" -1535- DISPLAY '          SQLCODE................. ' SQLCODE */
                        _.Display($"          SQLCODE................. {DB.SQLCODE}");

                        /*" -1536- PERFORM R9988-00-FECHAR-ARQUIVOS */

                        R9988_00_FECHAR_ARQUIVOS_SECTION();

                        /*" -1536- PERFORM R9999-00-FINALIZAR. */

                        R9999_00_FINALIZAR_SECTION();
                    }

                }

            }


        }

        [StopWatch]
        /*" R0410-00-LER-CBO-DB-SELECT-1 */
        public void R0410_00_LER_CBO_DB_SELECT_1()
        {
            /*" -1520- EXEC SQL SELECT DISTINCT COD_CBO , DESCR_CBO INTO :DCLCBO.CBO-COD-CBO , :DCLCBO.CBO-DESCR-CBO FROM SEGUROS.CBO WHERE DESCR_CBO = :DCLCBO.CBO-DESCR-CBO AND COD_CBO < 1000 ORDER BY COD_CBO , DESCR_CBO WITH UR END-EXEC. */

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
            /*" -1546- MOVE 'R0550-00-LER-OPCAOPAGVA' TO PARAGRAFO. */
            _.Move("R0550-00-LER-OPCAOPAGVA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1548- MOVE 'SELECT OPCAOPAGVA' TO COMANDO. */
            _.Move("SELECT OPCAOPAGVA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1551- MOVE MOVVGAP-NUM-CERTIFICADO TO OPPAGVA-NUM-CERTIFICADO. */
            _.Move(MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_NUM_CERTIFICADO, OPPAGVA.DCLOPCAO_PAG_VIDAZUL.OPPAGVA_NUM_CERTIFICADO);

            /*" -1580- PERFORM R0550_00_LER_OPCAOPAGVA_DB_SELECT_1 */

            R0550_00_LER_OPCAOPAGVA_DB_SELECT_1();

            /*" -1583- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -1584- DISPLAY 'PF0648B - FIM ANORMAL' */
                _.Display($"PF0648B - FIM ANORMAL");

                /*" -1585- DISPLAY '          ERRO SELECT OPCAOPAGVA' */
                _.Display($"          ERRO SELECT OPCAOPAGVA");

                /*" -1587- DISPLAY '          NUMERO CERTIFICADO.....' OPPAGVA-NUM-CERTIFICADO */
                _.Display($"          NUMERO CERTIFICADO.....{OPPAGVA.DCLOPCAO_PAG_VIDAZUL.OPPAGVA_NUM_CERTIFICADO}");

                /*" -1589- DISPLAY '          SQLCODE................ ' SQLCODE */
                _.Display($"          SQLCODE................ {DB.SQLCODE}");

                /*" -1590- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -1590- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R0550-00-LER-OPCAOPAGVA-DB-SELECT-1 */
        public void R0550_00_LER_OPCAOPAGVA_DB_SELECT_1()
        {
            /*" -1580- EXEC SQL SELECT NUM_CERTIFICADO , DATA_INIVIGENCIA , DATA_TERVIGENCIA , OPCAO_PAGAMENTO , PERI_PAGAMENTO , DIA_DEBITO , COD_AGENCIA_DEBITO , OPE_CONTA_DEBITO , NUM_CONTA_DEBITO , DIG_CONTA_DEBITO INTO :OPPAGVA-NUM-CERTIFICADO , :OPPAGVA-DATA-INIVIGENCIA , :OPPAGVA-DATA-TERVIGENCIA , :OPPAGVA-OPCAO-PAGAMENTO , :OPPAGVA-PERI-PAGAMENTO , :OPPAGVA-DIA-DEBITO , :OPPAGVA-COD-AGENCIA-DEBITO:VIND-AGEDEB, :OPPAGVA-OPE-CONTA-DEBITO:VIND-OPRCTADEB, :OPPAGVA-NUM-CONTA-DEBITO:VIND-NUMCTADEB, :OPPAGVA-DIG-CONTA-DEBITO:VIND-DIGCTADEB FROM SEGUROS.OPCAO_PAG_VIDAZUL WHERE NUM_CERTIFICADO = :OPPAGVA-NUM-CERTIFICADO AND DATA_TERVIGENCIA IN (:HOST-DT-TERVIG1, :HOST-DT-TERVIG2) WITH UR END-EXEC. */

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
                _.Move(executed_1.OPPAGVA_PERI_PAGAMENTO, OPPAGVA.DCLOPCAO_PAG_VIDAZUL.OPPAGVA_PERI_PAGAMENTO);
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
            /*" -1600- MOVE 'R0570-00-LER-COMISSAO' TO PARAGRAFO. */
            _.Move("R0570-00-LER-COMISSAO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1602- MOVE 'SELECT FUNDOCOMISVA' TO COMANDO. */
            _.Move("SELECT FUNDOCOMISVA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1605- MOVE MOVVGAP-NUM-CERTIFICADO TO NUM-CERTIFICADO OF DCLFUNDO-COMISSAO-VA */
            _.Move(MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_NUM_CERTIFICADO, FDCOMVA.DCLFUNDO_COMISSAO_VA.NUM_CERTIFICADO);

            /*" -1608- MOVE 1101 TO COD-OPERACAO OF DCLFUNDO-COMISSAO-VA */
            _.Move(1101, FDCOMVA.DCLFUNDO_COMISSAO_VA.COD_OPERACAO);

            /*" -1619- PERFORM R0570_00_LER_COMISSAO_DB_DECLARE_1 */

            R0570_00_LER_COMISSAO_DB_DECLARE_1();

            /*" -1622- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -1623- DISPLAY 'PF0648B - FIM ANORMAL' */
                _.Display($"PF0648B - FIM ANORMAL");

                /*" -1624- DISPLAY '          ERRO DECLARE CURSOR FUNDOCOMISVA' */
                _.Display($"          ERRO DECLARE CURSOR FUNDOCOMISVA");

                /*" -1626- DISPLAY '          NUMERO CERTIFICADO.............. ' NUM-CERTIFICADO OF DCLFUNDO-COMISSAO-VA */
                _.Display($"          NUMERO CERTIFICADO.............. {FDCOMVA.DCLFUNDO_COMISSAO_VA.NUM_CERTIFICADO}");

                /*" -1628- DISPLAY '          SQLCODE......................... ' SQLCODE */
                _.Display($"          SQLCODE......................... {DB.SQLCODE}");

                /*" -1629- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -1631- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


            /*" -1631- PERFORM R0570_00_LER_COMISSAO_DB_OPEN_1 */

            R0570_00_LER_COMISSAO_DB_OPEN_1();

            /*" -1634- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -1635- DISPLAY 'PF0648B - FIM ANORMAL' */
                _.Display($"PF0648B - FIM ANORMAL");

                /*" -1636- DISPLAY '          ERRO OPEN CURSOR FUNDOCOMISVA' */
                _.Display($"          ERRO OPEN CURSOR FUNDOCOMISVA");

                /*" -1638- DISPLAY '          NUMERO CERTIFICADO........... ' NUM-CERTIFICADO OF DCLFUNDO-COMISSAO-VA */
                _.Display($"          NUMERO CERTIFICADO........... {FDCOMVA.DCLFUNDO_COMISSAO_VA.NUM_CERTIFICADO}");

                /*" -1640- DISPLAY '          SQLCODE...................... ' SQLCODE */
                _.Display($"          SQLCODE...................... {DB.SQLCODE}");

                /*" -1641- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -1643- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


            /*" -1649- PERFORM R0570_00_LER_COMISSAO_DB_FETCH_1 */

            R0570_00_LER_COMISSAO_DB_FETCH_1();

            /*" -1652- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -1653- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1656- MOVE ZEROS TO VAL-COMISSAO-VG OF DCLFUNDO-COMISSAO-VA, VAL-COMISSAO-AP OF DCLFUNDO-COMISSAO-VA */
                    _.Move(0, FDCOMVA.DCLFUNDO_COMISSAO_VA.VAL_COMISSAO_VG, FDCOMVA.DCLFUNDO_COMISSAO_VA.VAL_COMISSAO_AP);

                    /*" -1657- ELSE */
                }
                else
                {


                    /*" -1658- DISPLAY 'PF0648B - FIM ANORMAL' */
                    _.Display($"PF0648B - FIM ANORMAL");

                    /*" -1659- DISPLAY '          ERRO SELECT CURSOR FUNDOCOMISVA' */
                    _.Display($"          ERRO SELECT CURSOR FUNDOCOMISVA");

                    /*" -1661- DISPLAY '          NUMERO CERTIFICADO............. ' NUM-CERTIFICADO OF DCLFUNDO-COMISSAO-VA */
                    _.Display($"          NUMERO CERTIFICADO............. {FDCOMVA.DCLFUNDO_COMISSAO_VA.NUM_CERTIFICADO}");

                    /*" -1663- DISPLAY '          SQLCODE........................ ' SQLCODE */
                    _.Display($"          SQLCODE........................ {DB.SQLCODE}");

                    /*" -1664- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -1666- PERFORM R9999-00-FINALIZAR. */

                    R9999_00_FINALIZAR_SECTION();
                }

            }


            /*" -1666- PERFORM R0570_00_LER_COMISSAO_DB_CLOSE_1 */

            R0570_00_LER_COMISSAO_DB_CLOSE_1();

            /*" -1669- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -1670- DISPLAY 'PF0648B - FIM ANORMAL' */
                _.Display($"PF0648B - FIM ANORMAL");

                /*" -1671- DISPLAY '          ERRO CLOSE CURSOR FUNDOCOMISVA' */
                _.Display($"          ERRO CLOSE CURSOR FUNDOCOMISVA");

                /*" -1673- DISPLAY '          NUMERO CERTIFICADO............ ' NUM-CERTIFICADO OF DCLFUNDO-COMISSAO-VA */
                _.Display($"          NUMERO CERTIFICADO............ {FDCOMVA.DCLFUNDO_COMISSAO_VA.NUM_CERTIFICADO}");

                /*" -1675- DISPLAY '          SQLCODE....................... ' SQLCODE */
                _.Display($"          SQLCODE....................... {DB.SQLCODE}");

                /*" -1676- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -1676- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R0570-00-LER-COMISSAO-DB-OPEN-1 */
        public void R0570_00_LER_COMISSAO_DB_OPEN_1()
        {
            /*" -1631- EXEC SQL OPEN FUNDOCOMISVA END-EXEC. */

            FUNDOCOMISVA.Open();

        }

        [StopWatch]
        /*" R0710-00-OBTER-DATA-CREDITO-DB-DECLARE-1 */
        public void R0710_00_OBTER_DATA_CREDITO_DB_DECLARE_1()
        {
            /*" -2222- EXEC SQL DECLARE OBTER-DATA-CREDITO CURSOR FOR SELECT DATA_MOVIMENTO FROM SEGUROS.HIST_CONT_PARCELVA WHERE NUM_CERTIFICADO = :MOVVGAP-NUM-CERTIFICADO AND NUM_PARCELA = 1 AND COD_OPERACAO >= 200 AND COD_OPERACAO <= 299 ORDER BY OCORR_HISTORICO DESC WITH UR END-EXEC. */
            OBTER_DATA_CREDITO = new PF0648B_OBTER_DATA_CREDITO(true);
            string GetQuery_OBTER_DATA_CREDITO()
            {
                var query = @$"SELECT DATA_MOVIMENTO 
							FROM SEGUROS.HIST_CONT_PARCELVA 
							WHERE NUM_CERTIFICADO = '{MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_NUM_CERTIFICADO}' 
							AND NUM_PARCELA = 1 
							AND COD_OPERACAO >= 200 
							AND COD_OPERACAO <= 299 
							ORDER BY OCORR_HISTORICO DESC";

                return query;
            }
            OBTER_DATA_CREDITO.GetQueryEvent += GetQuery_OBTER_DATA_CREDITO;

        }

        [StopWatch]
        /*" R0570-00-LER-COMISSAO-DB-FETCH-1 */
        public void R0570_00_LER_COMISSAO_DB_FETCH_1()
        {
            /*" -1649- EXEC SQL FETCH FUNDOCOMISVA INTO :DCLFUNDO-COMISSAO-VA.NUM-CERTIFICADO , :DCLFUNDO-COMISSAO-VA.VAL-COMISSAO-VG , :DCLFUNDO-COMISSAO-VA.VAL-COMISSAO-AP END-EXEC. */

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
            /*" -1666- EXEC SQL CLOSE FUNDOCOMISVA END-EXEC. */

            FUNDOCOMISVA.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0570_SAIDA*/

        [StopWatch]
        /*" R0580-00-OBTER-VAL-TARIFA-SECTION */
        private void R0580_00_OBTER_VAL_TARIFA_SECTION()
        {
            /*" -1686- MOVE 'R0580-00-OBTER-VAL-TARIFA' TO PARAGRAFO. */
            _.Move("R0580-00-OBTER-VAL-TARIFA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1688- MOVE 'SELECT TARIFA-BALCAO-CEF' TO COMANDO. */
            _.Move("SELECT TARIFA-BALCAO-CEF", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1691- MOVE MOVVGAP-NUM-CERTIFICADO TO NUM-CERTIFICADO OF DCLTARIFA-BALCAO-CEF. */
            _.Move(MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_NUM_CERTIFICADO, TARIBCEF.DCLTARIFA_BALCAO_CEF.NUM_CERTIFICADO);

            /*" -1703- PERFORM R0580_00_OBTER_VAL_TARIFA_DB_SELECT_1 */

            R0580_00_OBTER_VAL_TARIFA_DB_SELECT_1();

            /*" -1706- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -1707- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1708- MOVE ZEROS TO VAL-TARIFA OF DCLTARIFA-BALCAO-CEF */
                    _.Move(0, TARIBCEF.DCLTARIFA_BALCAO_CEF.VAL_TARIFA);

                    /*" -1709- ELSE */
                }
                else
                {


                    /*" -1710- DISPLAY 'PF0648B - FIM ANORMAL' */
                    _.Display($"PF0648B - FIM ANORMAL");

                    /*" -1711- DISPLAY '          ERRO SELECT TAB. TARIFA-BALCAO-CEF' */
                    _.Display($"          ERRO SELECT TAB. TARIFA-BALCAO-CEF");

                    /*" -1713- DISPLAY '          NUMERO CERTIFICADO........ ' NUM-CERTIFICADO OF DCLTARIFA-BALCAO-CEF */
                    _.Display($"          NUMERO CERTIFICADO........ {TARIBCEF.DCLTARIFA_BALCAO_CEF.NUM_CERTIFICADO}");

                    /*" -1715- DISPLAY '          SQLCODE................... ' SQLCODE */
                    _.Display($"          SQLCODE................... {DB.SQLCODE}");

                    /*" -1716- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -1716- PERFORM R9999-00-FINALIZAR. */

                    R9999_00_FINALIZAR_SECTION();
                }

            }


        }

        [StopWatch]
        /*" R0580-00-OBTER-VAL-TARIFA-DB-SELECT-1 */
        public void R0580_00_OBTER_VAL_TARIFA_DB_SELECT_1()
        {
            /*" -1703- EXEC SQL SELECT VAL_TARIFA INTO :DCLTARIFA-BALCAO-CEF.VAL-TARIFA FROM SEGUROS.TARIFA_BALCAO_CEF WHERE COD_EMPRESA = 0 AND NUM_MATRICULA = 9999999 AND TIPO_FUNCIONARIO = '5' AND NUM_CERTIFICADO = :DCLTARIFA-BALCAO-CEF.NUM-CERTIFICADO WITH UR END-EXEC. */

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
            /*" -1727- MOVE 'R0600-00-GERAR-REGISTRO-TP1' TO PARAGRAFO. */
            _.Move("R0600-00-GERAR-REGISTRO-TP1", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1729- MOVE SPACES TO REG-PRP-SASSE. */
            _.Move("", REG_PRP_SASSE);

            /*" -1732- MOVE '1' TO R1-TIPO-REG OF REG-CLIENTES. */
            _.Move("1", LBFPF011.REG_CLIENTES.R1_TIPO_REG);

            /*" -1736- MOVE W-NUM-PROPOSTA-NOVA TO R1-NUM-PROPOSTA OF REG-CLIENTES. */
            _.Move(WAREA_AUXILIAR.W_NUM_PROPOSTA_NOVA, LBFPF011.REG_CLIENTES.R1_NUM_PROPOSTA);

            /*" -1739- MOVE CGCCPF OF DCLCLIENTES TO R1-CGC-CPF OF REG-CLIENTES. */
            _.Move(CLIENTE.DCLCLIENTES.CGCCPF, LBFPF011.REG_CLIENTES.R1_CGC_CPF);

            /*" -1740- IF VIND-DTNASCI LESS ZEROS */

            if (VIND_DTNASCI < 00)
            {

                /*" -1743- MOVE MOVVGAP-NUM-CERTIFICADO TO SEGVGAP-NUM-CERTIFICADO */
                _.Move(MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_NUM_CERTIFICADO, SEGVGAP.DCLSEGURADOS_VGAP.SEGVGAP_NUM_CERTIFICADO);

                /*" -1746- MOVE MOVVGAP-TIPO-SEGURADO TO SEGVGAP-TIPO-SEGURADO */
                _.Move(MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_TIPO_SEGURADO, SEGVGAP.DCLSEGURADOS_VGAP.SEGVGAP_TIPO_SEGURADO);

                /*" -1748- PERFORM R0610-00-SEGURAVG */

                R0610_00_SEGURAVG_SECTION();

                /*" -1749- IF SQLCODE EQUAL ZEROS */

                if (DB.SQLCODE == 00)
                {

                    /*" -1751- MOVE SEGVGAP-DATA-NASCIMENTO TO W-DATA-SQL */
                    _.Move(SEGVGAP.DCLSEGURADOS_VGAP.SEGVGAP_DATA_NASCIMENTO, WAREA_AUXILIAR.W_DATA_SQL);

                    /*" -1752- MOVE W-DIA-SQL TO W-DIA-TRABALHO */
                    _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_DIA_SQL, WAREA_AUXILIAR.FILLER_2.W_DIA_TRABALHO);

                    /*" -1753- MOVE W-MES-SQL TO W-MES-TRABALHO */
                    _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_MES_SQL, WAREA_AUXILIAR.FILLER_2.W_MES_TRABALHO);

                    /*" -1754- MOVE W-ANO-SQL TO W-ANO-TRABALHO */
                    _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_ANO_SQL, WAREA_AUXILIAR.FILLER_2.W_ANO_TRABALHO);

                    /*" -1756- MOVE W-DATA-TRABALHO TO R1-DATA-NASCIMENTO OF REG-CLIENTES */
                    _.Move(WAREA_AUXILIAR.W_DATA_TRABALHO, LBFPF011.REG_CLIENTES.R1_DATA_NASCIMENTO);

                    /*" -1757- ELSE */
                }
                else
                {


                    /*" -1759- MOVE ZEROS TO R1-DATA-NASCIMENTO OF REG-CLIENTES */
                    _.Move(0, LBFPF011.REG_CLIENTES.R1_DATA_NASCIMENTO);

                    /*" -1760- ELSE */
                }

            }
            else
            {


                /*" -1762- MOVE DATA-NASCIMENTO OF DCLCLIENTES TO W-DATA-SQL */
                _.Move(CLIENTE.DCLCLIENTES.DATA_NASCIMENTO, WAREA_AUXILIAR.W_DATA_SQL);

                /*" -1763- MOVE W-DIA-SQL TO W-DIA-TRABALHO */
                _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_DIA_SQL, WAREA_AUXILIAR.FILLER_2.W_DIA_TRABALHO);

                /*" -1764- MOVE W-MES-SQL TO W-MES-TRABALHO */
                _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_MES_SQL, WAREA_AUXILIAR.FILLER_2.W_MES_TRABALHO);

                /*" -1765- MOVE W-ANO-SQL TO W-ANO-TRABALHO */
                _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_ANO_SQL, WAREA_AUXILIAR.FILLER_2.W_ANO_TRABALHO);

                /*" -1768- MOVE W-DATA-TRABALHO TO R1-DATA-NASCIMENTO OF REG-CLIENTES. */
                _.Move(WAREA_AUXILIAR.W_DATA_TRABALHO, LBFPF011.REG_CLIENTES.R1_DATA_NASCIMENTO);
            }


            /*" -1771- MOVE NOME-RAZAO OF DCLCLIENTES TO R1-NOME-PESSOA OF REG-CLIENTES. */
            _.Move(CLIENTE.DCLCLIENTES.NOME_RAZAO, LBFPF011.REG_CLIENTES.R1_NOME_PESSOA);

            /*" -1772- IF TIPO-PESSOA OF DCLCLIENTES EQUAL 'F' */

            if (CLIENTE.DCLCLIENTES.TIPO_PESSOA == "F")
            {

                /*" -1773- MOVE 1 TO R1-TIPO-PESSOA OF REG-CLIENTES */
                _.Move(1, LBFPF011.REG_CLIENTES.R1_TIPO_PESSOA);

                /*" -1774- ELSE */
            }
            else
            {


                /*" -1776- MOVE 2 TO R1-TIPO-PESSOA OF REG-CLIENTES. */
                _.Move(2, LBFPF011.REG_CLIENTES.R1_TIPO_PESSOA);
            }


            /*" -1781- MOVE SPACES TO R1-UF-EXPEDIDORA OF REG-CLIENTES R1-CODIGO-SEGMENTO OF REG-CLIENTES R1-ORGAO-EXPEDIDOR OF REG-CLIENTES. */
            _.Move("", LBFPF011.REG_CLIENTES.R1_UF_EXPEDIDORA, LBFPF011.REG_CLIENTES.R1_CODIGO_SEGMENTO, LBFPF011.REG_CLIENTES.R1_ORGAO_EXPEDIDOR);

            /*" -1785- MOVE ZEROS TO R1-NUM-IDENTIDADE OF REG-CLIENTES R1-DATA-EXPEDICAO-RG OF REG-CLIENTES. */
            _.Move(0, LBFPF011.REG_CLIENTES.R1_NUM_IDENTIDADE, LBFPF011.REG_CLIENTES.R1_DATA_EXPEDICAO_RG);

            /*" -1787- MOVE ZERO TO W-OBTER-DADOS-RG. */
            _.Move(0, WAREA_AUXILIAR.W_OBTER_DADOS_RG);

            /*" -1789- PERFORM R0620-00-DADOS-RG. */

            R0620_00_DADOS_RG_SECTION();

            /*" -1790- IF OBTEVE-DADOS-RG */

            if (WAREA_AUXILIAR.W_OBTER_DADOS_RG["OBTEVE_DADOS_RG"])
            {

                /*" -1793- MOVE GEDOCCLI-COD-IDENTIFICACAO TO R1-NUM-IDENTIDADE OF REG-CLIENTES */
                _.Move(GEDOCCLI.DCLGE_DOC_CLIENTE.GEDOCCLI_COD_IDENTIFICACAO, LBFPF011.REG_CLIENTES.R1_NUM_IDENTIDADE);

                /*" -1796- MOVE GEDOCCLI-NOM-ORGAO-EXP TO W-NOM-ORGAO-EXP */
                _.Move(GEDOCCLI.DCLGE_DOC_CLIENTE.GEDOCCLI_NOM_ORGAO_EXP, WAREA_AUXILIAR.W_NOM_ORGAO_EXP);

                /*" -1799- MOVE W-ORGAO-EXPEDIDOR TO R1-ORGAO-EXPEDIDOR OF REG-CLIENTES */
                _.Move(WAREA_AUXILIAR.FILLER_5.W_ORGAO_EXPEDIDOR, LBFPF011.REG_CLIENTES.R1_ORGAO_EXPEDIDOR);

                /*" -1801- MOVE GEDOCCLI-DTH-EXPEDICAO TO W-DATA-SQL */
                _.Move(GEDOCCLI.DCLGE_DOC_CLIENTE.GEDOCCLI_DTH_EXPEDICAO, WAREA_AUXILIAR.W_DATA_SQL);

                /*" -1802- MOVE W-DIA-SQL TO W-DIA-TRABALHO */
                _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_DIA_SQL, WAREA_AUXILIAR.FILLER_2.W_DIA_TRABALHO);

                /*" -1803- MOVE W-MES-SQL TO W-MES-TRABALHO */
                _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_MES_SQL, WAREA_AUXILIAR.FILLER_2.W_MES_TRABALHO);

                /*" -1804- MOVE W-ANO-SQL TO W-ANO-TRABALHO */
                _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_ANO_SQL, WAREA_AUXILIAR.FILLER_2.W_ANO_TRABALHO);

                /*" -1807- MOVE W-DATA-TRABALHO TO R1-DATA-EXPEDICAO-RG OF REG-CLIENTES */
                _.Move(WAREA_AUXILIAR.W_DATA_TRABALHO, LBFPF011.REG_CLIENTES.R1_DATA_EXPEDICAO_RG);

                /*" -1810- MOVE GEDOCCLI-COD-UF TO R1-UF-EXPEDIDORA OF REG-CLIENTES. */
                _.Move(GEDOCCLI.DCLGE_DOC_CLIENTE.GEDOCCLI_COD_UF, LBFPF011.REG_CLIENTES.R1_UF_EXPEDIDORA);
            }


            /*" -1811- IF MOVVGAP-ESTADO-CIVIL EQUAL 'S' */

            if (MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_ESTADO_CIVIL == "S")
            {

                /*" -1812- MOVE 1 TO R1-ESTADO-CIVIL OF REG-CLIENTES */
                _.Move(1, LBFPF011.REG_CLIENTES.R1_ESTADO_CIVIL);

                /*" -1813- ELSE */
            }
            else
            {


                /*" -1814- IF MOVVGAP-ESTADO-CIVIL EQUAL 'C' */

                if (MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_ESTADO_CIVIL == "C")
                {

                    /*" -1815- MOVE 2 TO R1-ESTADO-CIVIL OF REG-CLIENTES */
                    _.Move(2, LBFPF011.REG_CLIENTES.R1_ESTADO_CIVIL);

                    /*" -1816- ELSE */
                }
                else
                {


                    /*" -1817- IF MOVVGAP-ESTADO-CIVIL EQUAL 'V' */

                    if (MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_ESTADO_CIVIL == "V")
                    {

                        /*" -1818- MOVE 3 TO R1-ESTADO-CIVIL OF REG-CLIENTES */
                        _.Move(3, LBFPF011.REG_CLIENTES.R1_ESTADO_CIVIL);

                        /*" -1819- ELSE */
                    }
                    else
                    {


                        /*" -1821- MOVE 4 TO R1-ESTADO-CIVIL OF REG-CLIENTES. */
                        _.Move(4, LBFPF011.REG_CLIENTES.R1_ESTADO_CIVIL);
                    }

                }

            }


            /*" -1822- IF MOVVGAP-IDE-SEXO EQUAL 'M' */

            if (MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_IDE_SEXO == "M")
            {

                /*" -1823- MOVE 1 TO R1-IDE-SEXO OF REG-CLIENTES */
                _.Move(1, LBFPF011.REG_CLIENTES.R1_IDE_SEXO);

                /*" -1824- ELSE */
            }
            else
            {


                /*" -1826- MOVE 2 TO R1-IDE-SEXO OF REG-CLIENTES. */
                _.Move(2, LBFPF011.REG_CLIENTES.R1_IDE_SEXO);
            }


            /*" -1829- MOVE COD-CBO-TIT TO R1-COD-CBO OF REG-CLIENTES. */
            _.Move(COD_CBO_TIT, LBFPF011.REG_CLIENTES.R1_COD_CBO);

            /*" -1832- MOVE ENDERECO-DDD OF DCLENDERECOS TO R1-DDD(1). */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_DDD, LBFPF011.REG_CLIENTES.R1_TELEFONE[1].R1_DDD);

            /*" -1835- MOVE ENDERECO-TELEFONE OF DCLENDERECOS TO R1-NUM-FONE(1). */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_TELEFONE, LBFPF011.REG_CLIENTES.R1_TELEFONE[1].R1_NUM_FONE);

            /*" -1839- MOVE ZEROS TO R1-DDD(2) R1-DDD(3). */
            _.Move(0, LBFPF011.REG_CLIENTES.R1_TELEFONE[2].R1_DDD, LBFPF011.REG_CLIENTES.R1_TELEFONE[3].R1_DDD);

            /*" -1843- MOVE ZEROS TO R1-NUM-FONE(2) R1-NUM-FONE(3). */
            _.Move(0, LBFPF011.REG_CLIENTES.R1_TELEFONE[2].R1_NUM_FONE, LBFPF011.REG_CLIENTES.R1_TELEFONE[3].R1_NUM_FONE);

            /*" -1844- IF VIND-NOME-ESPOSA LESS ZEROS */

            if (VIND_NOME_ESPOSA < 00)
            {

                /*" -1846- MOVE SPACES TO R1-NOME-CONJUGE OF REG-CLIENTES */
                _.Move("", LBFPF011.REG_CLIENTES.R1_NOME_CONJUGE);

                /*" -1847- ELSE */
            }
            else
            {


                /*" -1850- MOVE NOME-ESPOSA OF DCLPROPOSTAS-VA TO R1-NOME-CONJUGE OF REG-CLIENTES. */
                _.Move(PROPVA.DCLPROPOSTAS_VA.NOME_ESPOSA, LBFPF011.REG_CLIENTES.R1_NOME_CONJUGE);
            }


            /*" -1851- IF VIND-DTNASC-ESPOSA LESS ZEROS */

            if (VIND_DTNASC_ESPOSA < 00)
            {

                /*" -1853- MOVE ZEROS TO R1-DTNASC-CONJUGE OF REG-CLIENTES */
                _.Move(0, LBFPF011.REG_CLIENTES.R1_DTNASC_CONJUGE);

                /*" -1855- MOVE -1 TO VIND-DTNASC-ESPOSA */
                _.Move(-1, VIND_DTNASC_ESPOSA);

                /*" -1856- ELSE */
            }
            else
            {


                /*" -1859- MOVE DTNASC-ESPOSA OF DCLPROPOSTAS-VA TO W-DATA-SQL */
                _.Move(PROPVA.DCLPROPOSTAS_VA.DTNASC_ESPOSA, WAREA_AUXILIAR.W_DATA_SQL);

                /*" -1860- MOVE W-DIA-SQL TO W-DIA-TRABALHO */
                _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_DIA_SQL, WAREA_AUXILIAR.FILLER_2.W_DIA_TRABALHO);

                /*" -1861- MOVE W-MES-SQL TO W-MES-TRABALHO */
                _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_MES_SQL, WAREA_AUXILIAR.FILLER_2.W_MES_TRABALHO);

                /*" -1862- MOVE W-ANO-SQL TO W-ANO-TRABALHO */
                _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_ANO_SQL, WAREA_AUXILIAR.FILLER_2.W_ANO_TRABALHO);

                /*" -1865- MOVE W-DATA-TRABALHO TO R1-DTNASC-CONJUGE OF REG-CLIENTES. */
                _.Move(WAREA_AUXILIAR.W_DATA_TRABALHO, LBFPF011.REG_CLIENTES.R1_DTNASC_CONJUGE);
            }


            /*" -1868- MOVE COD-CBO-CONJ TO R1-CBO-CONJUGE OF REG-CLIENTES. */
            _.Move(COD_CBO_CONJ, LBFPF011.REG_CLIENTES.R1_CBO_CONJUGE);

            /*" -1871- MOVE SPACES TO R1-EMAIL OF REG-CLIENTES. */
            _.Move("", LBFPF011.REG_CLIENTES.R1_EMAIL);

            /*" -1873- WRITE REG-PRP-SASSE FROM REG-CLIENTES. */
            _.Move(LBFPF011.REG_CLIENTES.GetMoveValues(), REG_PRP_SASSE);

            MOVTO_PRP_SASSE.Write(REG_PRP_SASSE.GetMoveValues().ToString());

            /*" -1875- ADD 1 TO W-QTD-LD-TIPO-1. */
            WAREA_AUXILIAR.W_QTD_LD_TIPO_1.Value = WAREA_AUXILIAR.W_QTD_LD_TIPO_1 + 1;

            /*" -1876- MOVE MOVVGAP-NUM-CERTIFICADO TO R1-NUM-PROPOSTA OF REG-CLIENTES. */
            _.Move(MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_NUM_CERTIFICADO, LBFPF011.REG_CLIENTES.R1_NUM_PROPOSTA);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0600_SAIDA*/

        [StopWatch]
        /*" R0610-00-SEGURAVG-SECTION */
        private void R0610_00_SEGURAVG_SECTION()
        {
            /*" -1886- MOVE 'R0610-00-SEGURAVG' TO PARAGRAFO. */
            _.Move("R0610-00-SEGURAVG", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1888- MOVE 'SELECT SEGURADOS-VGAP' TO COMANDO. */
            _.Move("SELECT SEGURADOS-VGAP", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1897- PERFORM R0610_00_SEGURAVG_DB_SELECT_1 */

            R0610_00_SEGURAVG_DB_SELECT_1();

            /*" -1900- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -1902- IF SQLCODE EQUAL -305 NEXT SENTENCE */

                if (DB.SQLCODE == -305)
                {

                    /*" -1903- ELSE */
                }
                else
                {


                    /*" -1904- DISPLAY 'PF0648B - FIM ANORMAL' */
                    _.Display($"PF0648B - FIM ANORMAL");

                    /*" -1905- DISPLAY '          ERRO SELECT TAB. SEGURADOS-VGAP' */
                    _.Display($"          ERRO SELECT TAB. SEGURADOS-VGAP");

                    /*" -1907- DISPLAY '          NUMERO CERTIFICADO........ ' SEGVGAP-NUM-CERTIFICADO */
                    _.Display($"          NUMERO CERTIFICADO........ {SEGVGAP.DCLSEGURADOS_VGAP.SEGVGAP_NUM_CERTIFICADO}");

                    /*" -1909- DISPLAY '          SQLCODE................... ' SQLCODE */
                    _.Display($"          SQLCODE................... {DB.SQLCODE}");

                    /*" -1910- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -1910- PERFORM R9999-00-FINALIZAR. */

                    R9999_00_FINALIZAR_SECTION();
                }

            }


        }

        [StopWatch]
        /*" R0610-00-SEGURAVG-DB-SELECT-1 */
        public void R0610_00_SEGURAVG_DB_SELECT_1()
        {
            /*" -1897- EXEC SQL SELECT DATA_NASCIMENTO INTO :SEGVGAP-DATA-NASCIMENTO FROM SEGUROS.SEGURADOS_VGAP WHERE NUM_CERTIFICADO = :SEGVGAP-NUM-CERTIFICADO AND TIPO_SEGURADO = :SEGVGAP-TIPO-SEGURADO WITH UR END-EXEC. */

            var r0610_00_SEGURAVG_DB_SELECT_1_Query1 = new R0610_00_SEGURAVG_DB_SELECT_1_Query1()
            {
                SEGVGAP_NUM_CERTIFICADO = SEGVGAP.DCLSEGURADOS_VGAP.SEGVGAP_NUM_CERTIFICADO.ToString(),
                SEGVGAP_TIPO_SEGURADO = SEGVGAP.DCLSEGURADOS_VGAP.SEGVGAP_TIPO_SEGURADO.ToString(),
            };

            var executed_1 = R0610_00_SEGURAVG_DB_SELECT_1_Query1.Execute(r0610_00_SEGURAVG_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SEGVGAP_DATA_NASCIMENTO, SEGVGAP.DCLSEGURADOS_VGAP.SEGVGAP_DATA_NASCIMENTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0610_SAIDA*/

        [StopWatch]
        /*" R0620-00-DADOS-RG-SECTION */
        private void R0620_00_DADOS_RG_SECTION()
        {
            /*" -1920- MOVE 'R0620-00-DADOS-RG' TO PARAGRAFO. */
            _.Move("R0620-00-DADOS-RG", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1922- MOVE 'SELECT GE_DOC_CLIENTES' TO COMANDO. */
            _.Move("SELECT GE_DOC_CLIENTES", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1925- MOVE COD-CLIENTE OF DCLCLIENTES TO GEDOCCLI-COD-CLIENTE. */
            _.Move(CLIENTE.DCLCLIENTES.COD_CLIENTE, GEDOCCLI.DCLGE_DOC_CLIENTE.GEDOCCLI_COD_CLIENTE);

            /*" -1941- PERFORM R0620_00_DADOS_RG_DB_SELECT_1 */

            R0620_00_DADOS_RG_DB_SELECT_1();

            /*" -1944- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -1946- IF SQLCODE EQUAL 100 NEXT SENTENCE */

                if (DB.SQLCODE == 100)
                {

                    /*" -1947- ELSE */
                }
                else
                {


                    /*" -1948- DISPLAY 'PF0648B - FIM ANORMAL' */
                    _.Display($"PF0648B - FIM ANORMAL");

                    /*" -1949- DISPLAY '          ERRO SELECT TAB. GE_DOC_CLIENTES' */
                    _.Display($"          ERRO SELECT TAB. GE_DOC_CLIENTES");

                    /*" -1951- DISPLAY '          NUMERO CERTIFICADO.............. ' SEGVGAP-NUM-CERTIFICADO */
                    _.Display($"          NUMERO CERTIFICADO.............. {SEGVGAP.DCLSEGURADOS_VGAP.SEGVGAP_NUM_CERTIFICADO}");

                    /*" -1953- DISPLAY '          CODIGO DO CLIENTE............... ' GEDOCCLI-COD-CLIENTE */
                    _.Display($"          CODIGO DO CLIENTE............... {GEDOCCLI.DCLGE_DOC_CLIENTE.GEDOCCLI_COD_CLIENTE}");

                    /*" -1955- DISPLAY '          SQLCODE......................... ' SQLCODE */
                    _.Display($"          SQLCODE......................... {DB.SQLCODE}");

                    /*" -1956- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -1957- PERFORM R9999-00-FINALIZAR */

                    R9999_00_FINALIZAR_SECTION();

                    /*" -1958- ELSE */
                }

            }
            else
            {


                /*" -1959- IF VIND-COD-UF LESS ZEROS */

                if (VIND_COD_UF < 00)
                {

                    /*" -1960- MOVE SPACES TO GEDOCCLI-COD-UF */
                    _.Move("", GEDOCCLI.DCLGE_DOC_CLIENTE.GEDOCCLI_COD_UF);

                    /*" -1961- END-IF */
                }


                /*" -1961- MOVE 1 TO W-OBTER-DADOS-RG. */
                _.Move(1, WAREA_AUXILIAR.W_OBTER_DADOS_RG);
            }


        }

        [StopWatch]
        /*" R0620-00-DADOS-RG-DB-SELECT-1 */
        public void R0620_00_DADOS_RG_DB_SELECT_1()
        {
            /*" -1941- EXEC SQL SELECT COD_CLIENTE , COD_IDENTIFICACAO , NOM_ORGAO_EXP , DTH_EXPEDICAO , COD_UF INTO :GEDOCCLI-COD-CLIENTE , :GEDOCCLI-COD-IDENTIFICACAO, :GEDOCCLI-NOM-ORGAO-EXP , :GEDOCCLI-DTH-EXPEDICAO , :GEDOCCLI-COD-UF :VIND-COD-UF FROM SEGUROS.GE_DOC_CLIENTE WHERE COD_CLIENTE = :GEDOCCLI-COD-CLIENTE WITH UR END-EXEC. */

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
            /*" -1972- MOVE 'R0650-00-GERAR-REGISTRO-TP2' TO PARAGRAFO. */
            _.Move("R0650-00-GERAR-REGISTRO-TP2", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1975- MOVE SPACES TO REG-ENDERECO, REG-PRP-SASSE. */
            _.Move("", LBFPF012.REG_ENDERECO, REG_PRP_SASSE);

            /*" -1978- MOVE '2' TO R2-TIPO-REG OF REG-ENDERECO. */
            _.Move("2", LBFPF012.REG_ENDERECO.R2_TIPO_REG);

            /*" -1982- MOVE W-NUM-PROPOSTA-NOVA TO R2-NUM-PROPOSTA OF REG-ENDERECO. */
            _.Move(WAREA_AUXILIAR.W_NUM_PROPOSTA_NOVA, LBFPF012.REG_ENDERECO.R2_NUM_PROPOSTA);

            /*" -1985- MOVE '2' TO R2-TIPO-ENDER OF REG-ENDERECO. */
            _.Move("2", LBFPF012.REG_ENDERECO.R2_TIPO_ENDER);

            /*" -1988- MOVE ENDERECO-ENDERECO OF DCLENDERECOS TO R2-ENDERECO OF REG-ENDERECO. */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_ENDERECO, LBFPF012.REG_ENDERECO.R2_ENDERECO);

            /*" -1991- MOVE ENDERECO-BAIRRO OF DCLENDERECOS TO R2-BAIRRO OF REG-ENDERECO. */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_BAIRRO, LBFPF012.REG_ENDERECO.R2_BAIRRO);

            /*" -1994- MOVE ENDERECO-CIDADE OF DCLENDERECOS TO R2-CIDADE OF REG-ENDERECO. */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_CIDADE, LBFPF012.REG_ENDERECO.R2_CIDADE);

            /*" -1997- MOVE ENDERECO-SIGLA-UF OF DCLENDERECOS TO R2-SIGLA-UF OF REG-ENDERECO. */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_SIGLA_UF, LBFPF012.REG_ENDERECO.R2_SIGLA_UF);

            /*" -2000- MOVE ENDERECO-CEP OF DCLENDERECOS TO R2-CEP OF REG-ENDERECO. */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_CEP, LBFPF012.REG_ENDERECO.R2_CEP);

            /*" -2002- WRITE REG-PRP-SASSE FROM REG-ENDERECO. */
            _.Move(LBFPF012.REG_ENDERECO.GetMoveValues(), REG_PRP_SASSE);

            MOVTO_PRP_SASSE.Write(REG_PRP_SASSE.GetMoveValues().ToString());

            /*" -2004- ADD 1 TO W-QTD-LD-TIPO-2. */
            WAREA_AUXILIAR.W_QTD_LD_TIPO_2.Value = WAREA_AUXILIAR.W_QTD_LD_TIPO_2 + 1;

            /*" -2005- MOVE MOVVGAP-NUM-CERTIFICADO TO R2-NUM-PROPOSTA OF REG-ENDERECO. */
            _.Move(MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_NUM_CERTIFICADO, LBFPF012.REG_ENDERECO.R2_NUM_PROPOSTA);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0650_SAIDA*/

        [StopWatch]
        /*" R0700-00-GERAR-REGISTRO-TP3-SECTION */
        private void R0700_00_GERAR_REGISTRO_TP3_SECTION()
        {
            /*" -2016- MOVE 'R0700-00-GERAR-REGISTRO-TP3' TO PARAGRAFO. */
            _.Move("R0700-00-GERAR-REGISTRO-TP3", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2019- MOVE SPACES TO REG-PROPOSTA-SASSE REG-PRP-SASSE. */
            _.Move("", LXFCT004.REG_PROPOSTA_SASSE, REG_PRP_SASSE);

            /*" -2022- MOVE '3' TO R3-TIPO-REG OF REG-PROPOSTA-SASSE */
            _.Move("3", LXFCT004.REG_PROPOSTA_SASSE.R3_TIPO_REG);

            /*" -2026- MOVE W-NUM-PROPOSTA-NOVA TO R3-NUM-PROPOSTA OF REG-PROPOSTA-SASSE */
            _.Move(WAREA_AUXILIAR.W_NUM_PROPOSTA_NOVA, LXFCT004.REG_PROPOSTA_SASSE.R3_NUM_PROPOSTA);

            /*" -2029- MOVE COD-PRODUTO-SIVPF OF DCLPROPOSTA-FIDELIZ TO R3-COD-PRODUTO OF REG-PROPOSTA-SASSE */
            _.Move(PROPFID.DCLPROPOSTA_FIDELIZ.COD_PRODUTO_SIVPF, LXFCT004.REG_PROPOSTA_SASSE.R3_COD_PRODUTO);

            /*" -2032- MOVE AGECOBR OF DCLPROPOSTA-FIDELIZ TO R3-AGECOBR OF REG-PROPOSTA-SASSE */
            _.Move(PROPFID.DCLPROPOSTA_FIDELIZ.AGECOBR, LXFCT004.REG_PROPOSTA_SASSE.R3_AGECOBR);

            /*" -2034- MOVE DATA-PROPOSTA OF DCLPROPOSTA-FIDELIZ TO W-DATA-SQL */
            _.Move(PROPFID.DCLPROPOSTA_FIDELIZ.DATA_PROPOSTA, WAREA_AUXILIAR.W_DATA_SQL);

            /*" -2035- MOVE W-DIA-SQL TO W-DIA-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_DIA_SQL, WAREA_AUXILIAR.FILLER_2.W_DIA_TRABALHO);

            /*" -2036- MOVE W-MES-SQL TO W-MES-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_MES_SQL, WAREA_AUXILIAR.FILLER_2.W_MES_TRABALHO);

            /*" -2037- MOVE W-ANO-SQL TO W-ANO-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_ANO_SQL, WAREA_AUXILIAR.FILLER_2.W_ANO_TRABALHO);

            /*" -2040- MOVE W-DATA-TRABALHO TO R3-DATA-PROPOSTA OF REG-PROPOSTA-SASSE */
            _.Move(WAREA_AUXILIAR.W_DATA_TRABALHO, LXFCT004.REG_PROPOSTA_SASSE.R3_DATA_PROPOSTA);

            /*" -2043- MOVE OPPAGVA-OPCAO-PAGAMENTO TO R3-OPCAOPAG OF REG-PROPOSTA-SASSE */
            _.Move(OPPAGVA.DCLOPCAO_PAG_VIDAZUL.OPPAGVA_OPCAO_PAGAMENTO, LXFCT004.REG_PROPOSTA_SASSE.R3_OPCAOPAG);

            /*" -2044- IF R3-OPCAOPAG OF REG-PROPOSTA-SASSE = 1 OR 2 */

            if (LXFCT004.REG_PROPOSTA_SASSE.R3_OPCAOPAG.In("1", "2"))
            {

                /*" -2047- MOVE 1 TO R3-OPCAOPAG OF REG-PROPOSTA-SASSE. */
                _.Move(1, LXFCT004.REG_PROPOSTA_SASSE.R3_OPCAOPAG);
            }


            /*" -2048- IF R3-OPCAOPAG OF REG-PROPOSTA-SASSE = 3 */

            if (LXFCT004.REG_PROPOSTA_SASSE.R3_OPCAOPAG == 3)
            {

                /*" -2051- MOVE 2 TO R3-OPCAOPAG OF REG-PROPOSTA-SASSE. */
                _.Move(2, LXFCT004.REG_PROPOSTA_SASSE.R3_OPCAOPAG);
            }


            /*" -2052- IF R3-OPCAOPAG OF REG-PROPOSTA-SASSE = 5 */

            if (LXFCT004.REG_PROPOSTA_SASSE.R3_OPCAOPAG == 5)
            {

                /*" -2055- MOVE 3 TO R3-OPCAOPAG OF REG-PROPOSTA-SASSE. */
                _.Move(3, LXFCT004.REG_PROPOSTA_SASSE.R3_OPCAOPAG);
            }


            /*" -2056- IF VIND-AGEDEB LESS ZEROS */

            if (VIND_AGEDEB < 00)
            {

                /*" -2058- MOVE ZEROS TO R3-AGECTADEB OF REG-PROPOSTA-SASSE */
                _.Move(0, LXFCT004.REG_PROPOSTA_SASSE.R3_CONTA_DEBITO.R3_AGECTADEB);

                /*" -2059- ELSE */
            }
            else
            {


                /*" -2062- MOVE OPPAGVA-COD-AGENCIA-DEBITO TO R3-AGECTADEB OF REG-PROPOSTA-SASSE */
                _.Move(OPPAGVA.DCLOPCAO_PAG_VIDAZUL.OPPAGVA_COD_AGENCIA_DEBITO, LXFCT004.REG_PROPOSTA_SASSE.R3_CONTA_DEBITO.R3_AGECTADEB);

                /*" -2063- IF VIND-OPRCTADEB LESS ZEROS */

                if (VIND_OPRCTADEB < 00)
                {

                    /*" -2065- MOVE ZEROS TO R3-OPRCTADEB OF REG-PROPOSTA-SASSE */
                    _.Move(0, LXFCT004.REG_PROPOSTA_SASSE.R3_CONTA_DEBITO.R3_OPRCTADEB);

                    /*" -2066- ELSE */
                }
                else
                {


                    /*" -2069- MOVE OPPAGVA-OPE-CONTA-DEBITO TO R3-OPRCTADEB OF REG-PROPOSTA-SASSE. */
                    _.Move(OPPAGVA.DCLOPCAO_PAG_VIDAZUL.OPPAGVA_OPE_CONTA_DEBITO, LXFCT004.REG_PROPOSTA_SASSE.R3_CONTA_DEBITO.R3_OPRCTADEB);
                }

            }


            /*" -2070- IF VIND-NUMCTADEB LESS ZEROS */

            if (VIND_NUMCTADEB < 00)
            {

                /*" -2072- MOVE ZEROS TO R3-NUMCTADEB OF REG-PROPOSTA-SASSE */
                _.Move(0, LXFCT004.REG_PROPOSTA_SASSE.R3_CONTA_DEBITO.R3_NUMCTADEB);

                /*" -2073- ELSE */
            }
            else
            {


                /*" -2076- MOVE OPPAGVA-NUM-CONTA-DEBITO TO R3-NUMCTADEB OF REG-PROPOSTA-SASSE. */
                _.Move(OPPAGVA.DCLOPCAO_PAG_VIDAZUL.OPPAGVA_NUM_CONTA_DEBITO, LXFCT004.REG_PROPOSTA_SASSE.R3_CONTA_DEBITO.R3_NUMCTADEB);
            }


            /*" -2077- IF VIND-DIGCTADEB LESS ZEROS */

            if (VIND_DIGCTADEB < 00)
            {

                /*" -2079- MOVE ZEROS TO R3-DIGCTADEB OF REG-PROPOSTA-SASSE */
                _.Move(0, LXFCT004.REG_PROPOSTA_SASSE.R3_CONTA_DEBITO.R3_DIGCTADEB);

                /*" -2080- ELSE */
            }
            else
            {


                /*" -2083- MOVE OPPAGVA-DIG-CONTA-DEBITO TO R3-DIGCTADEB OF REG-PROPOSTA-SASSE. */
                _.Move(OPPAGVA.DCLOPCAO_PAG_VIDAZUL.OPPAGVA_DIG_CONTA_DEBITO, LXFCT004.REG_PROPOSTA_SASSE.R3_CONTA_DEBITO.R3_DIGCTADEB);
            }


            /*" -2084- IF VIND-DPS-TITULAR LESS ZEROS */

            if (VIND_DPS_TITULAR < 00)
            {

                /*" -2086- MOVE SPACES TO R3-DPS-TITULAR OF REG-PROPOSTA-SASSE */
                _.Move("", LXFCT004.REG_PROPOSTA_SASSE.R3_DPS_TITULAR);

                /*" -2087- ELSE */
            }
            else
            {


                /*" -2090- MOVE DPS-TITULAR OF DCLPROPOSTAS-VA TO R3-DPS-TITULAR OF REG-PROPOSTA-SASSE. */
                _.Move(PROPVA.DCLPROPOSTAS_VA.DPS_TITULAR, LXFCT004.REG_PROPOSTA_SASSE.R3_DPS_TITULAR);
            }


            /*" -2091- IF VIND-DPS-ESPOSA LESS ZEROS */

            if (VIND_DPS_ESPOSA < 00)
            {

                /*" -2093- MOVE SPACES TO R3-DPS-CONJUGE OF REG-PROPOSTA-SASSE */
                _.Move("", LXFCT004.REG_PROPOSTA_SASSE.R3_DPS_CONJUGE);

                /*" -2094- ELSE */
            }
            else
            {


                /*" -2097- MOVE DPS-ESPOSA OF DCLPROPOSTAS-VA TO R3-DPS-CONJUGE OF REG-PROPOSTA-SASSE. */
                _.Move(PROPVA.DCLPROPOSTAS_VA.DPS_ESPOSA, LXFCT004.REG_PROPOSTA_SASSE.R3_DPS_CONJUGE);
            }


            /*" -2098- IF R3-COD-PRODUTO OF REG-PROPOSTA-SASSE = 46 */

            if (LXFCT004.REG_PROPOSTA_SASSE.R3_COD_PRODUTO == 46)
            {

                /*" -2102- MOVE SPACES TO R3-DPS-TITULAR OF REG-PROPOSTA-SASSE R3-DPS-CONJUGE OF REG-PROPOSTA-SASSE. */
                _.Move("", LXFCT004.REG_PROPOSTA_SASSE.R3_DPS_TITULAR, LXFCT004.REG_PROPOSTA_SASSE.R3_DPS_CONJUGE);
            }


            /*" -2105- MOVE NUM-MATRI-VENDEDOR OF DCLPROPOSTAS-VA TO R3-NRMATRVEN OF REG-PROPOSTA-SASSE */
            _.Move(PROPVA.DCLPROPOSTAS_VA.NUM_MATRI_VENDEDOR, LXFCT004.REG_PROPOSTA_SASSE.R3_NRMATRVEN);

            /*" -2106- IF VIND-APOS-INVALIDEZ LESS 0 */

            if (VIND_APOS_INVALIDEZ < 0)
            {

                /*" -2108- MOVE SPACES TO R3-APOS-INVALIDEZ OF REG-PROPOSTA-SASSE */
                _.Move("", LXFCT004.REG_PROPOSTA_SASSE.R3_APOS_INVALIDEZ);

                /*" -2109- ELSE */
            }
            else
            {


                /*" -2112- MOVE APOS-INVALIDEZ OF DCLPROPOSTAS-VA TO R3-APOS-INVALIDEZ OF REG-PROPOSTA-SASSE. */
                _.Move(PROPVA.DCLPROPOSTAS_VA.APOS_INVALIDEZ, LXFCT004.REG_PROPOSTA_SASSE.R3_APOS_INVALIDEZ);
            }


            /*" -2115- MOVE SPACES TO R3-RENOVACAO-AUTOM OF REG-PROPOSTA-SASSE */
            _.Move("", LXFCT004.REG_PROPOSTA_SASSE.R3_RENOVACAO_AUTOM);

            /*" -2121- MOVE OPPAGVA-DIA-DEBITO TO R3-DIA-DEBITO OF REG-PROPOSTA-SASSE */
            _.Move(OPPAGVA.DCLOPCAO_PAG_VIDAZUL.OPPAGVA_DIA_DEBITO, LXFCT004.REG_PROPOSTA_SASSE.R3_DIA_DEBITO);

            /*" -2127- MOVE OPPAGVA-PERI-PAGAMENTO TO R3-PERIPGTO OF REG-PROPOSTA-SASSE. */
            _.Move(OPPAGVA.DCLOPCAO_PAG_VIDAZUL.OPPAGVA_PERI_PAGAMENTO, LXFCT004.REG_PROPOSTA_SASSE.R3_PERIPGTO);

            /*" -2130- MOVE PERC-DESCONTO OF DCLPROPOSTA-FIDELIZ TO R3-PCT-DESCONTO OF REG-PROPOSTA-SASSE */
            _.Move(PROPFID.DCLPROPOSTA_FIDELIZ.PERC_DESCONTO, LXFCT004.REG_PROPOSTA_SASSE.R3_PCT_DESCONTO);

            /*" -2133- MOVE CGC-CONVENENTE OF DCLPROPOSTA-FIDELIZ TO R3-CGC-CONVENENTE OF REG-PROPOSTA-SASSE */
            _.Move(PROPFID.DCLPROPOSTA_FIDELIZ.CGC_CONVENENTE, LXFCT004.REG_PROPOSTA_SASSE.R3_CGC_CONVENENTE);

            /*" -2136- MOVE NOME-CONVENENTE OF DCLPROPOSTA-FIDELIZ TO R3-NOME-CONVENENTE OF REG-PROPOSTA-SASSE */
            _.Move(PROPFID.DCLPROPOSTA_FIDELIZ.NOME_CONVENENTE, LXFCT004.REG_PROPOSTA_SASSE.R3_NOME_CONVENENTE);

            /*" -2142- MOVE ORIGEM-PROPOSTA OF DCLPROPOSTA-FIDELIZ TO R3-ORIGEM-PROPOSTA OF REG-PROPOSTA-SASSE. */
            _.Move(PROPFID.DCLPROPOSTA_FIDELIZ.ORIGEM_PROPOSTA, LXFCT004.REG_PROPOSTA_SASSE.R3_ORIGEM_PROPOSTA_AIC);

            /*" -2145- MOVE 'EMT' TO R3-SIT-PROPOSTA OF REG-PROPOSTA-SASSE. */
            _.Move("EMT", LXFCT004.REG_PROPOSTA_SASSE.R3_SIT_PROPOSTA);

            /*" -2148- MOVE 'PAG' TO R3-SIT-COBRANCA OF REG-PROPOSTA-SASSE. */
            _.Move("PAG", LXFCT004.REG_PROPOSTA_SASSE.R3_SIT_COBRANCA);

            /*" -2151- MOVE 228 TO R3-SIT-MOTIVO OF REG-PROPOSTA-SASSE. */
            _.Move(228, LXFCT004.REG_PROPOSTA_SASSE.R3_SIT_MOTIVO);

            /*" -2154- MOVE OPCAO-COBERTURA OF DCLPROPOSTAS-VA TO R3-OPCAO-COBER OF REG-PROPOSTA-SASSE. */
            _.Move(PROPVA.DCLPROPOSTAS_VA.OPCAO_COBERTURA, LXFCT004.REG_PROPOSTA_SASSE.R3_OPCAO_COBER);

            /*" -2157- MOVE COD-PLANO OF DCLPROPOSTA-FIDELIZ TO R3-COD-PLANO OF REG-PROPOSTA-SASSE. */
            _.Move(PROPFID.DCLPROPOSTA_FIDELIZ.COD_PLANO, LXFCT004.REG_PROPOSTA_SASSE.R3_COD_PLANO);

            /*" -2160- MOVE HISLANCT-DATA-VENCIMENTO TO W-DATA-SQL */
            _.Move(HISLANCT.DCLHIST_LANC_CTA.HISLANCT_DATA_VENCIMENTO, WAREA_AUXILIAR.W_DATA_SQL);

            /*" -2161- MOVE W-DIA-SQL TO W-DIA-TRABALHO */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_DIA_SQL, WAREA_AUXILIAR.FILLER_2.W_DIA_TRABALHO);

            /*" -2162- MOVE W-MES-SQL TO W-MES-TRABALHO */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_MES_SQL, WAREA_AUXILIAR.FILLER_2.W_MES_TRABALHO);

            /*" -2163- MOVE W-ANO-SQL TO W-ANO-TRABALHO */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_ANO_SQL, WAREA_AUXILIAR.FILLER_2.W_ANO_TRABALHO);

            /*" -2166- MOVE W-DATA-TRABALHO TO R3-DTQITBCO OF REG-PROPOSTA-SASSE. */
            _.Move(WAREA_AUXILIAR.W_DATA_TRABALHO, LXFCT004.REG_PROPOSTA_SASSE.R3_DTQITBCO);

            /*" -2169- MOVE HISLANCT-PRM-TOTAL TO R3-VAL-PAGO OF REG-PROPOSTA-SASSE. */
            _.Move(HISLANCT.DCLHIST_LANC_CTA.HISLANCT_PRM_TOTAL, LXFCT004.REG_PROPOSTA_SASSE.R3_VAL_PAGO);

            /*" -2172- MOVE HISLANCT-COD-AGENCIA-DEBITO TO R3-AGEPGTO OF REG-PROPOSTA-SASSE. */
            _.Move(HISLANCT.DCLHIST_LANC_CTA.HISLANCT_COD_AGENCIA_DEBITO, LXFCT004.REG_PROPOSTA_SASSE.R3_AGEPGTO);

            /*" -2175- MOVE VAL-TARIFA OF DCLTARIFA-BALCAO-CEF TO R3-VAL-TARIFA OF REG-PROPOSTA-SASSE. */
            _.Move(TARIBCEF.DCLTARIFA_BALCAO_CEF.VAL_TARIFA, LXFCT004.REG_PROPOSTA_SASSE.R3_VAL_TARIFA);

            /*" -2177- MOVE HISCONPA-DATA-MOVIMENTO TO W-DATA-SQL */
            _.Move(HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_DATA_MOVIMENTO, WAREA_AUXILIAR.W_DATA_SQL);

            /*" -2178- MOVE W-DIA-SQL TO W-DIA-TRABALHO */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_DIA_SQL, WAREA_AUXILIAR.FILLER_2.W_DIA_TRABALHO);

            /*" -2179- MOVE W-MES-SQL TO W-MES-TRABALHO */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_MES_SQL, WAREA_AUXILIAR.FILLER_2.W_MES_TRABALHO);

            /*" -2180- MOVE W-ANO-SQL TO W-ANO-TRABALHO */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_ANO_SQL, WAREA_AUXILIAR.FILLER_2.W_ANO_TRABALHO);

            /*" -2183- MOVE W-DATA-TRABALHO TO R3-DATA-CREDITO OF REG-PROPOSTA-SASSE. */
            _.Move(WAREA_AUXILIAR.W_DATA_TRABALHO, LXFCT004.REG_PROPOSTA_SASSE.R3_DATA_CREDITO);

            /*" -2187- COMPUTE R3-VAL-COMISSAO OF REG-PROPOSTA-SASSE = VAL-COMISSAO-VG OF DCLFUNDO-COMISSAO-VA + VAL-COMISSAO-AP OF DCLFUNDO-COMISSAO-VA. */
            LXFCT004.REG_PROPOSTA_SASSE.R3_VAL_COMISSAO.Value = FDCOMVA.DCLFUNDO_COMISSAO_VA.VAL_COMISSAO_VG + FDCOMVA.DCLFUNDO_COMISSAO_VA.VAL_COMISSAO_AP;

            /*" -2190- MOVE ARQSIVPF-NSAS-SIVPF OF DCLARQUIVOS-SIVPF TO R3-NSAS OF REG-PROPOSTA-SASSE. */
            _.Move(ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF, LXFCT004.REG_PROPOSTA_SASSE.R3_NSAS);

            /*" -2192- ADD 1 TO W-QTD-LD-TIPO-3. */
            WAREA_AUXILIAR.W_QTD_LD_TIPO_3.Value = WAREA_AUXILIAR.W_QTD_LD_TIPO_3 + 1;

            /*" -2195- MOVE W-QTD-LD-TIPO-3 TO R3-NSL OF REG-PROPOSTA-SASSE. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_3, LXFCT004.REG_PROPOSTA_SASSE.R3_NSL);

            /*" -2197- WRITE REG-PRP-SASSE FROM REG-PROPOSTA-SASSE. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.GetMoveValues(), REG_PRP_SASSE);

            MOVTO_PRP_SASSE.Write(REG_PRP_SASSE.GetMoveValues().ToString());

            /*" -2198- MOVE MOVVGAP-NUM-CERTIFICADO TO R3-NUM-PROPOSTA OF REG-PROPOSTA-SASSE. */
            _.Move(MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_NUM_CERTIFICADO, LXFCT004.REG_PROPOSTA_SASSE.R3_NUM_PROPOSTA);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0700_SAIDA*/

        [StopWatch]
        /*" R0710-00-OBTER-DATA-CREDITO-SECTION */
        private void R0710_00_OBTER_DATA_CREDITO_SECTION()
        {
            /*" -2212- MOVE 'R0710-00-OBTER-DATA-CREDITO' TO PARAGRAFO. */
            _.Move("R0710-00-OBTER-DATA-CREDITO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2222- PERFORM R0710_00_OBTER_DATA_CREDITO_DB_DECLARE_1 */

            R0710_00_OBTER_DATA_CREDITO_DB_DECLARE_1();

            /*" -2224- PERFORM R0710_00_OBTER_DATA_CREDITO_DB_OPEN_1 */

            R0710_00_OBTER_DATA_CREDITO_DB_OPEN_1();

            /*" -2227- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -2227- MOVE 2 TO W-CURSOR. */
                _.Move(2, WAREA_AUXILIAR.W_CURSOR);
            }


        }

        [StopWatch]
        /*" R0710-00-OBTER-DATA-CREDITO-DB-OPEN-1 */
        public void R0710_00_OBTER_DATA_CREDITO_DB_OPEN_1()
        {
            /*" -2224- EXEC SQL OPEN OBTER-DATA-CREDITO END-EXEC. */

            OBTER_DATA_CREDITO.Open();

        }

        [StopWatch]
        /*" R0750-00-OBTER-DADOS-LANC-DB-DECLARE-1 */
        public void R0750_00_OBTER_DADOS_LANC_DB_DECLARE_1()
        {
            /*" -2669- EXEC SQL DECLARE DADOS-LANC CURSOR FOR SELECT PRM_TOTAL, DATA_VENCIMENTO , COD_AGENCIA_DEBITO FROM SEGUROS.HIST_LANC_CTA WHERE NUM_CERTIFICADO = :MOVVGAP-NUM-CERTIFICADO AND NUM_PARCELA = 1 ORDER BY DATA_VENCIMENTO DESC WITH UR END-EXEC */
            DADOS_LANC = new PF0648B_DADOS_LANC(true);
            string GetQuery_DADOS_LANC()
            {
                var query = @$"SELECT PRM_TOTAL
							, 
							DATA_VENCIMENTO
							, 
							COD_AGENCIA_DEBITO 
							FROM SEGUROS.HIST_LANC_CTA 
							WHERE NUM_CERTIFICADO = '{MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_NUM_CERTIFICADO}' 
							AND NUM_PARCELA = 1 
							ORDER BY 
							DATA_VENCIMENTO DESC";

                return query;
            }
            DADOS_LANC.GetQueryEvent += GetQuery_DADOS_LANC;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0710_SAIDA*/

        [StopWatch]
        /*" R0711-00-FETCH-DATA-CREDITO-SECTION */
        private void R0711_00_FETCH_DATA_CREDITO_SECTION()
        {
            /*" -2238- MOVE 'R0711-00-FETCH-DATA-CREDITO' TO PARAGRAFO. */
            _.Move("R0711-00-FETCH-DATA-CREDITO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2240- MOVE 'FETCH OBTER-DATA-CREDITO' TO COMANDO. */
            _.Move("FETCH OBTER-DATA-CREDITO", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2243- PERFORM R0711_00_FETCH_DATA_CREDITO_DB_FETCH_1 */

            R0711_00_FETCH_DATA_CREDITO_DB_FETCH_1();

            /*" -2247- MOVE SQLCODE TO WS-SQLCODE-R0711 */
            _.Move(DB.SQLCODE, WS_SQLCODE_R0711);

            /*" -2248- IF SQLCODE NOT EQUAL 00 AND NOT EQUAL 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -2249- DISPLAY 'PF0648B - FIM ANORMAL' */
                _.Display($"PF0648B - FIM ANORMAL");

                /*" -2250- DISPLAY '          ERRO SELECT HIST-CONT-PARCELVA  ' */
                _.Display($"          ERRO SELECT HIST-CONT-PARCELVA  ");

                /*" -2252- DISPLAY '          NUMERO CERTIFICADO.............. ' MOVVGAP-NUM-CERTIFICADO */
                _.Display($"          NUMERO CERTIFICADO.............. {MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_NUM_CERTIFICADO}");

                /*" -2254- DISPLAY '          SQLCODE......................... ' SQLCODE */
                _.Display($"          SQLCODE......................... {DB.SQLCODE}");

                /*" -2255- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -2257- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


            /*" -2259- PERFORM R0711_00_FETCH_DATA_CREDITO_DB_CLOSE_1 */

            R0711_00_FETCH_DATA_CREDITO_DB_CLOSE_1();

        }

        [StopWatch]
        /*" R0711-00-FETCH-DATA-CREDITO-DB-FETCH-1 */
        public void R0711_00_FETCH_DATA_CREDITO_DB_FETCH_1()
        {
            /*" -2243- EXEC SQL FETCH OBTER-DATA-CREDITO INTO :HISCONPA-DATA-MOVIMENTO END-EXEC. */

            if (OBTER_DATA_CREDITO.Fetch())
            {
                _.Move(OBTER_DATA_CREDITO.HISCONPA_DATA_MOVIMENTO, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_DATA_MOVIMENTO);
            }

        }

        [StopWatch]
        /*" R0711-00-FETCH-DATA-CREDITO-DB-CLOSE-1 */
        public void R0711_00_FETCH_DATA_CREDITO_DB_CLOSE_1()
        {
            /*" -2259- EXEC SQL CLOSE OBTER-DATA-CREDITO END-EXEC. */

            OBTER_DATA_CREDITO.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0711_SAIDA*/

        [StopWatch]
        /*" R0720-00-OBTER-DADOS-LANC-SECTION */
        private void R0720_00_OBTER_DADOS_LANC_SECTION()
        {
            /*" -2270- MOVE 'R0720-00-OBTER-DADOS-LANC ' TO PARAGRAFO. */
            _.Move("R0720-00-OBTER-DADOS-LANC ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2284- PERFORM R0720_00_OBTER_DADOS_LANC_DB_SELECT_1 */

            R0720_00_OBTER_DADOS_LANC_DB_SELECT_1();

            /*" -2288- MOVE SQLCODE TO WS-SQLCODE-R0720 */
            _.Move(DB.SQLCODE, WS_SQLCODE_R0720);

            /*" -2291- IF SQLCODE NOT EQUAL 00 AND NOT EQUAL 100 AND NOT EQUAL 811 */

            if (!DB.SQLCODE.In("00", "100", "811"))
            {

                /*" -2292- DISPLAY 'PF0648B - FIM ANORMAL' */
                _.Display($"PF0648B - FIM ANORMAL");

                /*" -2293- DISPLAY '          ERRO SELECT (1) HIST_LANC_CTA    ' */
                _.Display($"          ERRO SELECT (1) HIST_LANC_CTA    ");

                /*" -2295- DISPLAY '          NUMERO CERTIFICADO.............. ' MOVVGAP-NUM-CERTIFICADO */
                _.Display($"          NUMERO CERTIFICADO.............. {MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_NUM_CERTIFICADO}");

                /*" -2297- DISPLAY '          SQLCODE......................... ' SQLCODE */
                _.Display($"          SQLCODE......................... {DB.SQLCODE}");

                /*" -2298- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -2300- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


            /*" -2302- IF SQLCODE EQUAL 100 OR SQLCODE EQUAL 811 */

            if (DB.SQLCODE == 100 || DB.SQLCODE == 811)
            {

                /*" -2303- PERFORM R0750-00-OBTER-DADOS-LANC */

                R0750_00_OBTER_DADOS_LANC_SECTION();

                /*" -2305- END-IF. R0720-SAIDA. EXIT. */
            }


        }

        [StopWatch]
        /*" R0720-00-OBTER-DADOS-LANC-DB-SELECT-1 */
        public void R0720_00_OBTER_DADOS_LANC_DB_SELECT_1()
        {
            /*" -2284- EXEC SQL SELECT PRM_TOTAL, DATA_VENCIMENTO , COD_AGENCIA_DEBITO INTO :HISLANCT-PRM-TOTAL, :HISLANCT-DATA-VENCIMENTO , :HISLANCT-COD-AGENCIA-DEBITO FROM SEGUROS.HIST_LANC_CTA WHERE NUM_CERTIFICADO = :MOVVGAP-NUM-CERTIFICADO AND NUM_PARCELA = 1 AND SIT_REGISTRO = '1' AND TIPLANC = '1' WITH UR END-EXEC. */

            var r0720_00_OBTER_DADOS_LANC_DB_SELECT_1_Query1 = new R0720_00_OBTER_DADOS_LANC_DB_SELECT_1_Query1()
            {
                MOVVGAP_NUM_CERTIFICADO = MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = R0720_00_OBTER_DADOS_LANC_DB_SELECT_1_Query1.Execute(r0720_00_OBTER_DADOS_LANC_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HISLANCT_PRM_TOTAL, HISLANCT.DCLHIST_LANC_CTA.HISLANCT_PRM_TOTAL);
                _.Move(executed_1.HISLANCT_DATA_VENCIMENTO, HISLANCT.DCLHIST_LANC_CTA.HISLANCT_DATA_VENCIMENTO);
                _.Move(executed_1.HISLANCT_COD_AGENCIA_DEBITO, HISLANCT.DCLHIST_LANC_CTA.HISLANCT_COD_AGENCIA_DEBITO);
            }


        }

        [StopWatch]
        /*" R1000-00-GERAR-TRAILLER-SECTION */
        private void R1000_00_GERAR_TRAILLER_SECTION()
        {
            /*" -2312- MOVE 'R1000-00-GERAR-TRAILLER' TO PARAGRAFO. */
            _.Move("R1000-00-GERAR-TRAILLER", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2314- MOVE 'WRITE REG-TRAILLER' TO COMANDO. */
            _.Move("WRITE REG-TRAILLER", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2317- MOVE SPACES TO REG-TRAILLER, REG-PRP-SASSE */
            _.Move("", LBFPF991.REG_TRAILLER, REG_PRP_SASSE);

            /*" -2320- MOVE 'T' TO RT-TIPO-REG OF REG-TRAILLER. */
            _.Move("T", LBFPF991.REG_TRAILLER.RT_TIPO_REG);

            /*" -2323- MOVE 'PRPSASSE' TO RT-NOME-EMPRESA OF REG-TRAILLER. */
            _.Move("PRPSASSE", LBFPF991.REG_TRAILLER.RT_NOME_EMPRESA);

            /*" -2326- MOVE W-QTD-LD-TIPO-0 TO RT-QTDE-TIPO-0 OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_0, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_0);

            /*" -2329- MOVE W-QTD-LD-TIPO-1 TO RT-QTDE-TIPO-1 OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_1, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_1);

            /*" -2332- MOVE W-QTD-LD-TIPO-2 TO RT-QTDE-TIPO-2 OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_2, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_2);

            /*" -2335- MOVE W-QTD-LD-TIPO-3 TO RT-QTDE-TIPO-3 OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_3, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_3);

            /*" -2338- MOVE W-QTD-LD-TIPO-4 TO RT-QTDE-TIPO-4 OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_4, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_4);

            /*" -2341- MOVE W-QTD-LD-TIPO-5 TO RT-QTDE-TIPO-5 OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_5, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_5);

            /*" -2344- MOVE W-QTD-LD-TIPO-6 TO RT-QTDE-TIPO-6 OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_6, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_6);

            /*" -2347- MOVE W-QTD-LD-TIPO-7 TO RT-QTDE-TIPO-7 OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_7, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_7);

            /*" -2350- MOVE W-QTD-LD-TIPO-8 TO RT-QTDE-TIPO-8 OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_8, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_8);

            /*" -2353- MOVE W-QTD-LD-TIPO-9 TO RT-QTDE-TIPO-9 OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_9, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_9);

            /*" -2356- MOVE W-QTD-LD-TIPO-A TO RT-QTDE-TIPO-A OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_A, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_A);

            /*" -2359- MOVE W-QTD-LD-TIPO-B TO RT-QTDE-TIPO-B OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_B, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_B);

            /*" -2362- MOVE W-QTD-LD-TIPO-C TO RT-QTDE-TIPO-C OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_C, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_C);

            /*" -2365- MOVE W-QTD-LD-TIPO-D TO RT-QTDE-TIPO-D OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_D, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_D);

            /*" -2368- MOVE W-QTD-LD-TIPO-E TO RT-QTDE-TIPO-E OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_E, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_E);

            /*" -2371- MOVE W-QTD-LD-TIPO-F TO RT-QTDE-TIPO-F OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_F, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_F);

            /*" -2374- MOVE W-QTD-LD-TIPO-G TO RT-QTDE-TIPO-G OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_G, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_G);

            /*" -2377- MOVE W-QTD-LD-TIPO-H TO RT-QTDE-TIPO-H OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_H, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_H);

            /*" -2380- MOVE W-QTD-LD-TIPO-I TO RT-QTDE-TIPO-I OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_I, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_I);

            /*" -2383- MOVE W-QTD-LD-TIPO-J TO RT-QTDE-TIPO-J OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_J, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_J);

            /*" -2405- COMPUTE RT-QTDE-TOTAL OF REG-TRAILLER = RT-QTDE-TIPO-0 + RT-QTDE-TIPO-1 + RT-QTDE-TIPO-2 + RT-QTDE-TIPO-3 + RT-QTDE-TIPO-4 + RT-QTDE-TIPO-5 + RT-QTDE-TIPO-6 + RT-QTDE-TIPO-7 + RT-QTDE-TIPO-8 + RT-QTDE-TIPO-9 + RT-QTDE-TIPO-A + RT-QTDE-TIPO-B + RT-QTDE-TIPO-C + RT-QTDE-TIPO-D + RT-QTDE-TIPO-E + RT-QTDE-TIPO-F + RT-QTDE-TIPO-G + RT-QTDE-TIPO-H + RT-QTDE-TIPO-I + RT-QTDE-TIPO-J */
            LBFPF991.REG_TRAILLER.RT_QTDE_TOTAL.Value = LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_0 + LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_1 + LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_2 + LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_3 + LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_4 + LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_5 + LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_6 + LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_7 + LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_8 + LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_9 + LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_A + LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_B + LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_C + LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_D + LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_E + LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_F + LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_G + LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_H + LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_I + LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_J;

            /*" -2405- WRITE REG-PRP-SASSE FROM REG-TRAILLER. */
            _.Move(LBFPF991.REG_TRAILLER.GetMoveValues(), REG_PRP_SASSE);

            MOVTO_PRP_SASSE.Write(REG_PRP_SASSE.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_SAIDA*/

        [StopWatch]
        /*" R1050-00-CONTROLAR-ARQ-ENVIADO-SECTION */
        private void R1050_00_CONTROLAR_ARQ_ENVIADO_SECTION()
        {
            /*" -2418- MOVE 'R1050-00-CONTROLAR-ARQ-ENVIADO' TO PARAGRAFO. */
            _.Move("R1050-00-CONTROLAR-ARQ-ENVIADO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2420- MOVE 'INSERT ARQUIVOS-SIVPF' TO COMANDO. */
            _.Move("INSERT ARQUIVOS-SIVPF", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2423- MOVE 'PRPSASSE' TO ARQSIVPF-SIGLA-ARQUIVO OF DCLARQUIVOS-SIVPF. */
            _.Move("PRPSASSE", ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SIGLA_ARQUIVO);

            /*" -2426- MOVE 4 TO ARQSIVPF-SISTEMA-ORIGEM OF DCLARQUIVOS-SIVPF. */
            _.Move(4, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SISTEMA_ORIGEM);

            /*" -2430- MOVE SISTEMAS-DATA-MOV-ABERTO OF DCLSISTEMAS TO ARQSIVPF-DATA-GERACAO OF DCLARQUIVOS-SIVPF, ARQSIVPF-DATA-PROCESSAMENTO OF DCLARQUIVOS-SIVPF. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_GERACAO, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_PROCESSAMENTO);

            /*" -2433- MOVE RT-QTDE-TIPO-3 OF REG-TRAILLER TO ARQSIVPF-QTDE-REG-GER OF DCLARQUIVOS-SIVPF. */
            _.Move(LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_3, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_QTDE_REG_GER);

            /*" -2441- PERFORM R1050_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1 */

            R1050_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1();

            /*" -2444- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -2445- DISPLAY 'PF0648B - FIM ANORMAL' */
                _.Display($"PF0648B - FIM ANORMAL");

                /*" -2446- DISPLAY '          ERRO INSERT TABELA ARQUIVOS-SIVPF' */
                _.Display($"          ERRO INSERT TABELA ARQUIVOS-SIVPF");

                /*" -2448- DISPLAY '          SIGLA DO ARQIVO..................  ' ARQSIVPF-SIGLA-ARQUIVO OF DCLARQUIVOS-SIVPF */
                _.Display($"          SIGLA DO ARQIVO..................  {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SIGLA_ARQUIVO}");

                /*" -2450- DISPLAY '          NSAS SIVPF.......................  ' ARQSIVPF-NSAS-SIVPF OF DCLARQUIVOS-SIVPF */
                _.Display($"          NSAS SIVPF.......................  {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF}");

                /*" -2452- DISPLAY '          DATA GERACAO.....................  ' ARQSIVPF-DATA-GERACAO OF DCLARQUIVOS-SIVPF */
                _.Display($"          DATA GERACAO.....................  {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_GERACAO}");

                /*" -2454- DISPLAY '          QTDE. REGISTROS..................  ' ARQSIVPF-QTDE-REG-GER OF DCLARQUIVOS-SIVPF */
                _.Display($"          QTDE. REGISTROS..................  {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_QTDE_REG_GER}");

                /*" -2456- DISPLAY '          SQLCODE..........................  ' SQLCODE */
                _.Display($"          SQLCODE..........................  {DB.SQLCODE}");

                /*" -2457- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -2457- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R1050-00-CONTROLAR-ARQ-ENVIADO-DB-INSERT-1 */
        public void R1050_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1()
        {
            /*" -2441- EXEC SQL INSERT INTO SEGUROS.ARQUIVOS_SIVPF VALUES (:DCLARQUIVOS-SIVPF.ARQSIVPF-SIGLA-ARQUIVO, :DCLARQUIVOS-SIVPF.ARQSIVPF-SISTEMA-ORIGEM, :DCLARQUIVOS-SIVPF.ARQSIVPF-NSAS-SIVPF, :DCLARQUIVOS-SIVPF.ARQSIVPF-DATA-GERACAO, :DCLARQUIVOS-SIVPF.ARQSIVPF-QTDE-REG-GER, :DCLARQUIVOS-SIVPF.ARQSIVPF-DATA-PROCESSAMENTO) END-EXEC. */

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
            /*" -2468- MOVE 'R1100-00-GERAR-TOTIAS' TO PARAGRAFO. */
            _.Move("R1100-00-GERAR-TOTIAS", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2470- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2490- COMPUTE W-TOT-GERADO-PRP = W-QTD-LD-TIPO-1 + W-QTD-LD-TIPO-2 + W-QTD-LD-TIPO-3 + W-QTD-LD-TIPO-4 + W-QTD-LD-TIPO-5 + W-QTD-LD-TIPO-6 + W-QTD-LD-TIPO-7 + W-QTD-LD-TIPO-8 + W-QTD-LD-TIPO-9 + W-QTD-LD-TIPO-A + W-QTD-LD-TIPO-B + W-QTD-LD-TIPO-C + W-QTD-LD-TIPO-D + W-QTD-LD-TIPO-E + W-QTD-LD-TIPO-F + W-QTD-LD-TIPO-G + W-QTD-LD-TIPO-H + W-QTD-LD-TIPO-I + W-QTD-LD-TIPO-J. */
            WAREA_AUXILIAR.W_TOT_GERADO_PRP.Value = WAREA_AUXILIAR.W_QTD_LD_TIPO_1 + WAREA_AUXILIAR.W_QTD_LD_TIPO_2 + WAREA_AUXILIAR.W_QTD_LD_TIPO_3 + WAREA_AUXILIAR.W_QTD_LD_TIPO_4 + WAREA_AUXILIAR.W_QTD_LD_TIPO_5 + WAREA_AUXILIAR.W_QTD_LD_TIPO_6 + WAREA_AUXILIAR.W_QTD_LD_TIPO_7 + WAREA_AUXILIAR.W_QTD_LD_TIPO_8 + WAREA_AUXILIAR.W_QTD_LD_TIPO_9 + WAREA_AUXILIAR.W_QTD_LD_TIPO_A + WAREA_AUXILIAR.W_QTD_LD_TIPO_B + WAREA_AUXILIAR.W_QTD_LD_TIPO_C + WAREA_AUXILIAR.W_QTD_LD_TIPO_D + WAREA_AUXILIAR.W_QTD_LD_TIPO_E + WAREA_AUXILIAR.W_QTD_LD_TIPO_F + WAREA_AUXILIAR.W_QTD_LD_TIPO_G + WAREA_AUXILIAR.W_QTD_LD_TIPO_H + WAREA_AUXILIAR.W_QTD_LD_TIPO_I + WAREA_AUXILIAR.W_QTD_LD_TIPO_J;

            /*" -2491- DISPLAY ' ' */
            _.Display($" ");

            /*" -2492- DISPLAY 'PF0648B - TOTAIS DO PROCESSAMENTO' */
            _.Display($"PF0648B - TOTAIS DO PROCESSAMENTO");

            /*" -2493- DISPLAY '          TOTAL  REGISTROS LIDOS........... ' W-NSL */
            _.Display($"          TOTAL  REGISTROS LIDOS........... {WAREA_AUXILIAR.W_NSL}");

            /*" -2495- DISPLAY '          TOTAL  PROCESSADO................ ' W-QTD-LD-TIPO-1 */
            _.Display($"          TOTAL  PROCESSADO................ {WAREA_AUXILIAR.W_QTD_LD_TIPO_1}");

            /*" -2497- DISPLAY '          TOTAL  NAO PROCESSADO............ ' W-DESPREZADO */
            _.Display($"          TOTAL  NAO PROCESSADO............ {WAREA_AUXILIAR.W_DESPREZADO}");

            /*" -2499- DISPLAY '          TOTAL  ATUALIZADO NA RELATORIOS.. ' W-RELATORIO */
            _.Display($"          TOTAL  ATUALIZADO NA RELATORIOS.. {WAREA_AUXILIAR.W_RELATORIO}");

            /*" -2501- DISPLAY '                               R0711....... ' W-R0711 */
            _.Display($"                               R0711....... {WAREA_AUXILIAR.W_R0711}");

            /*" -2503- DISPLAY '                               R0720....... ' W-R0720 */
            _.Display($"                               R0720....... {WAREA_AUXILIAR.W_R0720}");

            /*" -2504- DISPLAY '          TOTAL  REGISTROS GERADOS PRPSASSE' */
            _.Display($"          TOTAL  REGISTROS GERADOS PRPSASSE");

            /*" -2506- DISPLAY '          TOTAL  REGISTROS TP-1............ ' W-QTD-LD-TIPO-1 */
            _.Display($"          TOTAL  REGISTROS TP-1............ {WAREA_AUXILIAR.W_QTD_LD_TIPO_1}");

            /*" -2508- DISPLAY '          TOTAL  REGISTROS TP-2............ ' W-QTD-LD-TIPO-2 */
            _.Display($"          TOTAL  REGISTROS TP-2............ {WAREA_AUXILIAR.W_QTD_LD_TIPO_2}");

            /*" -2510- DISPLAY '          TOTAL  REGISTROS TP-3............ ' W-QTD-LD-TIPO-3 */
            _.Display($"          TOTAL  REGISTROS TP-3............ {WAREA_AUXILIAR.W_QTD_LD_TIPO_3}");

            /*" -2512- DISPLAY '          TOTAL  REGISTROS TP-4............ ' W-QTD-LD-TIPO-4 */
            _.Display($"          TOTAL  REGISTROS TP-4............ {WAREA_AUXILIAR.W_QTD_LD_TIPO_4}");

            /*" -2513- DISPLAY '          TOTAL  GERAL..................... ' W-TOT-GERADO-PRP. */
            _.Display($"          TOTAL  GERAL..................... {WAREA_AUXILIAR.W_TOT_GERADO_PRP}");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_SAIDA*/

        [StopWatch]
        /*" R0740-00-UPDATE-RELATORIOS-SECTION */
        private void R0740_00_UPDATE_RELATORIOS_SECTION()
        {
            /*" -2522- MOVE 'R0740-00-UPDATE-RELATORIOS' TO PARAGRAFO. */
            _.Move("R0740-00-UPDATE-RELATORIOS", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2524- MOVE 'UPDATE RELATORIOS' TO COMANDO. */
            _.Move("UPDATE RELATORIOS", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2534- PERFORM R0740_00_UPDATE_RELATORIOS_DB_UPDATE_1 */

            R0740_00_UPDATE_RELATORIOS_DB_UPDATE_1();

            /*" -2537- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -2538- DISPLAY 'PF0648B - FIM ANORMAL' */
                _.Display($"PF0648B - FIM ANORMAL");

                /*" -2539- DISPLAY '          ERRO UPDATE RELATORIOS' */
                _.Display($"          ERRO UPDATE RELATORIOS");

                /*" -2541- DISPLAY '          SQLCODE........................ ' SQLCODE */
                _.Display($"          SQLCODE........................ {DB.SQLCODE}");

                /*" -2542- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -2543- PERFORM R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION();

                /*" -2544- ELSE */
            }
            else
            {


                /*" -2545- ADD 1 TO W-RELATORIO */
                WAREA_AUXILIAR.W_RELATORIO.Value = WAREA_AUXILIAR.W_RELATORIO + 1;

                /*" -2545- END-IF. */
            }


        }

        [StopWatch]
        /*" R0740-00-UPDATE-RELATORIOS-DB-UPDATE-1 */
        public void R0740_00_UPDATE_RELATORIOS_DB_UPDATE_1()
        {
            /*" -2534- EXEC SQL UPDATE SEGUROS.RELATORIOS SET SIT_REGISTRO = '1' , TIMESTAMP = CURRENT TIMESTAMP WHERE IDE_SISTEMA = 'PF' AND COD_RELATORIO = 'PF0648B' AND NUM_CERTIFICADO = :DCLPROPOSTA-FIDELIZ.NUM-PROPOSTA-SIVPF AND SIT_REGISTRO = '0' END-EXEC. */

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
            /*" -2555- MOVE 'R0730-ATUALIZA-FIDELIZACAO' TO PARAGRAFO. */
            _.Move("R0730-ATUALIZA-FIDELIZACAO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2558- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2561- MOVE R3-DTQITBCO OF REG-PROPOSTA-SASSE TO W-DATA-TRABALHO. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_DTQITBCO, WAREA_AUXILIAR.W_DATA_TRABALHO);

            /*" -2563- MOVE W-DIA-TRABALHO TO W-DIA-SQL OF W-DATA-SQL1. */
            _.Move(WAREA_AUXILIAR.FILLER_2.W_DIA_TRABALHO, WAREA_AUXILIAR.W_DATA_SQL1.W_DIA_SQL);

            /*" -2565- MOVE W-MES-TRABALHO TO W-MES-SQL OF W-DATA-SQL1. */
            _.Move(WAREA_AUXILIAR.FILLER_2.W_MES_TRABALHO, WAREA_AUXILIAR.W_DATA_SQL1.W_MES_SQL);

            /*" -2568- MOVE W-ANO-TRABALHO TO W-ANO-SQL OF W-DATA-SQL1. */
            _.Move(WAREA_AUXILIAR.FILLER_2.W_ANO_TRABALHO, WAREA_AUXILIAR.W_DATA_SQL1.W_ANO_SQL);

            /*" -2572- MOVE '-' TO W-BARRA1 OF W-DATA-SQL1, W-BARRA2 OF W-DATA-SQL1. */
            _.Move("-", WAREA_AUXILIAR.W_DATA_SQL1.W_BARRA1_1);
            _.Move("-", WAREA_AUXILIAR.W_DATA_SQL1.W_BARRA2_1);


            /*" -2575- MOVE W-DATA-SQL TO DTQITBCO OF DCLPROPOSTA-FIDELIZ. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL, PROPFID.DCLPROPOSTA_FIDELIZ.DTQITBCO);

            /*" -2578- MOVE R3-VAL-PAGO OF REG-PROPOSTA-SASSE TO VAL-PAGO OF DCLPROPOSTA-FIDELIZ. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_VAL_PAGO, PROPFID.DCLPROPOSTA_FIDELIZ.VAL_PAGO);

            /*" -2581- MOVE R3-AGEPGTO OF REG-PROPOSTA-SASSE TO AGEPGTO OF DCLPROPOSTA-FIDELIZ. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_AGEPGTO, PROPFID.DCLPROPOSTA_FIDELIZ.AGEPGTO);

            /*" -2584- MOVE R3-VAL-TARIFA OF REG-PROPOSTA-SASSE TO VAL-TARIFA OF DCLPROPOSTA-FIDELIZ. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_VAL_TARIFA, PROPFID.DCLPROPOSTA_FIDELIZ.VAL_TARIFA);

            /*" -2587- MOVE R3-DATA-CREDITO OF REG-PROPOSTA-SASSE TO W-DATA-TRABALHO. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_DATA_CREDITO, WAREA_AUXILIAR.W_DATA_TRABALHO);

            /*" -2589- MOVE W-DIA-TRABALHO TO W-DIA-SQL OF W-DATA-SQL1. */
            _.Move(WAREA_AUXILIAR.FILLER_2.W_DIA_TRABALHO, WAREA_AUXILIAR.W_DATA_SQL1.W_DIA_SQL);

            /*" -2591- MOVE W-MES-TRABALHO TO W-MES-SQL OF W-DATA-SQL1. */
            _.Move(WAREA_AUXILIAR.FILLER_2.W_MES_TRABALHO, WAREA_AUXILIAR.W_DATA_SQL1.W_MES_SQL);

            /*" -2594- MOVE W-ANO-TRABALHO TO W-ANO-SQL OF W-DATA-SQL1. */
            _.Move(WAREA_AUXILIAR.FILLER_2.W_ANO_TRABALHO, WAREA_AUXILIAR.W_DATA_SQL1.W_ANO_SQL);

            /*" -2598- MOVE '-' TO W-BARRA1 OF W-DATA-SQL1, W-BARRA2 OF W-DATA-SQL1. */
            _.Move("-", WAREA_AUXILIAR.W_DATA_SQL1.W_BARRA1_1);
            _.Move("-", WAREA_AUXILIAR.W_DATA_SQL1.W_BARRA2_1);


            /*" -2601- MOVE W-DATA-SQL TO DATA-CREDITO OF DCLPROPOSTA-FIDELIZ. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL, PROPFID.DCLPROPOSTA_FIDELIZ.DATA_CREDITO);

            /*" -2604- MOVE R3-VAL-COMISSAO OF REG-PROPOSTA-SASSE TO VAL-COMISSAO OF DCLPROPOSTA-FIDELIZ. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_VAL_COMISSAO, PROPFID.DCLPROPOSTA_FIDELIZ.VAL_COMISSAO);

            /*" -2607- MOVE 'PF0648B' TO COD-USUARIO OF DCLPROPOSTA-FIDELIZ. */
            _.Move("PF0648B", PROPFID.DCLPROPOSTA_FIDELIZ.COD_USUARIO);

            /*" -2610- MOVE ZEROS TO NSAS-SIVPF OF DCLPROPOSTA-FIDELIZ. */
            _.Move(0, PROPFID.DCLPROPOSTA_FIDELIZ.NSAS_SIVPF);

            /*" -2613- MOVE RH-NSAS OF REG-HEADER TO NSAC-SIVPF OF DCLPROPOSTA-FIDELIZ. */
            _.Move(LXFPF990.REG_HEADER.RH_NSAS, PROPFID.DCLPROPOSTA_FIDELIZ.NSAC_SIVPF);

            /*" -2617- MOVE W-QTD-LD-TIPO-3 TO NSL OF DCLPROPOSTA-FIDELIZ. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_3, PROPFID.DCLPROPOSTA_FIDELIZ.NSL);

            /*" -2635- PERFORM R0730_ATUALIZA_FIDELIZACAO_DB_UPDATE_1 */

            R0730_ATUALIZA_FIDELIZACAO_DB_UPDATE_1();

            /*" -2638- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -2639- DISPLAY 'PF0648B - FIM ANORMAL' */
                _.Display($"PF0648B - FIM ANORMAL");

                /*" -2640- DISPLAY '          ERRO UPDATE TABELA PROPOSTA FIDELIZ' */
                _.Display($"          ERRO UPDATE TABELA PROPOSTA FIDELIZ");

                /*" -2642- DISPLAY '          NUMERO PROPOSTA...............  ' NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ */
                _.Display($"          NUMERO PROPOSTA...............  {PROPFID.DCLPROPOSTA_FIDELIZ.NUM_PROPOSTA_SIVPF}");

                /*" -2644- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -2645- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -2645- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R0730-ATUALIZA-FIDELIZACAO-DB-UPDATE-1 */
        public void R0730_ATUALIZA_FIDELIZACAO_DB_UPDATE_1()
        {
            /*" -2635- EXEC SQL UPDATE SEGUROS.PROPOSTA_FIDELIZ SET DTQITBCO =:DCLPROPOSTA-FIDELIZ.DTQITBCO, VAL_PAGO =:DCLPROPOSTA-FIDELIZ.VAL-PAGO, AGEPGTO =:DCLPROPOSTA-FIDELIZ.AGEPGTO, VAL_TARIFA =:DCLPROPOSTA-FIDELIZ.VAL-TARIFA, DATA_CREDITO =:DCLPROPOSTA-FIDELIZ.DATA-CREDITO, VAL_COMISSAO =:DCLPROPOSTA-FIDELIZ.VAL-COMISSAO, COD_USUARIO =:DCLPROPOSTA-FIDELIZ.COD-USUARIO, NSAS_SIVPF =:DCLPROPOSTA-FIDELIZ.NSAS-SIVPF, NSAC_SIVPF =:DCLPROPOSTA-FIDELIZ.NSAC-SIVPF, NSL =:DCLPROPOSTA-FIDELIZ.NSL WHERE NUM_PROPOSTA_SIVPF = :DCLPROPOSTA-FIDELIZ.NUM-PROPOSTA-SIVPF END-EXEC. */

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
        /*" R0750-00-OBTER-DADOS-LANC-SECTION */
        private void R0750_00_OBTER_DADOS_LANC_SECTION()
        {
            /*" -2656- MOVE 'R0750-00-OBTER-DADOS-LANC ' TO PARAGRAFO. */
            _.Move("R0750-00-OBTER-DADOS-LANC ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2658- MOVE ZEROS TO SQLCODE */
            _.Move(0, DB.SQLCODE);

            /*" -2669- PERFORM R0750_00_OBTER_DADOS_LANC_DB_DECLARE_1 */

            R0750_00_OBTER_DADOS_LANC_DB_DECLARE_1();

            /*" -2673- MOVE SQLCODE TO WS-SQLCODE-R0720 */
            _.Move(DB.SQLCODE, WS_SQLCODE_R0720);

            /*" -2674- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -2675- GO TO R0750-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0750_SAIDA*/ //GOTO
                return;

                /*" -2677- END-IF. */
            }


            /*" -2679- MOVE ZEROS TO SQLCODE */
            _.Move(0, DB.SQLCODE);

            /*" -2681- PERFORM R0750_00_OBTER_DADOS_LANC_DB_OPEN_1 */

            R0750_00_OBTER_DADOS_LANC_DB_OPEN_1();

            /*" -2685- MOVE SQLCODE TO WS-SQLCODE-R0720 */
            _.Move(DB.SQLCODE, WS_SQLCODE_R0720);

            /*" -2686- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -2687- GO TO R0750-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0750_SAIDA*/ //GOTO
                return;

                /*" -2689- END-IF. */
            }


            /*" -2691- MOVE ZEROS TO SQLCODE */
            _.Move(0, DB.SQLCODE);

            /*" -2697- PERFORM R0750_00_OBTER_DADOS_LANC_DB_FETCH_1 */

            R0750_00_OBTER_DADOS_LANC_DB_FETCH_1();

            /*" -2701- MOVE SQLCODE TO WS-SQLCODE-R0720 */
            _.Move(DB.SQLCODE, WS_SQLCODE_R0720);

            /*" -2703- IF SQLCODE NOT EQUAL 00 AND SQLCODE NOT EQUAL 100 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != 100)
            {

                /*" -2704- DISPLAY 'PF0648B - FIM ANORMAL' */
                _.Display($"PF0648B - FIM ANORMAL");

                /*" -2706- DISPLAY '      ERRO FETCH CURSOR V0MOVIMENTO  ' SQLCODE */
                _.Display($"      ERRO FETCH CURSOR V0MOVIMENTO  {DB.SQLCODE}");

                /*" -2707- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -2708- PERFORM R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION();

                /*" -2710- END-IF */
            }


            /*" -2712- MOVE ZEROS TO SQLCODE */
            _.Move(0, DB.SQLCODE);

            /*" -2714- PERFORM R0750_00_OBTER_DADOS_LANC_DB_CLOSE_1 */

            R0750_00_OBTER_DADOS_LANC_DB_CLOSE_1();

            /*" -2717- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -2718- DISPLAY 'PF0648B - FIM ANORMAL' */
                _.Display($"PF0648B - FIM ANORMAL");

                /*" -2720- DISPLAY '      ERRO CLOSE CURSOR DADOS-LANC   ' SQLCODE */
                _.Display($"      ERRO CLOSE CURSOR DADOS-LANC   {DB.SQLCODE}");

                /*" -2721- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -2722- PERFORM R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION();

                /*" -2722- END-IF. */
            }


        }

        [StopWatch]
        /*" R0750-00-OBTER-DADOS-LANC-DB-OPEN-1 */
        public void R0750_00_OBTER_DADOS_LANC_DB_OPEN_1()
        {
            /*" -2681- EXEC SQL OPEN DADOS-LANC END-EXEC */

            DADOS_LANC.Open();

        }

        [StopWatch]
        /*" R0750-00-OBTER-DADOS-LANC-DB-FETCH-1 */
        public void R0750_00_OBTER_DADOS_LANC_DB_FETCH_1()
        {
            /*" -2697- EXEC SQL FETCH DADOS-LANC INTO :HISLANCT-PRM-TOTAL, :HISLANCT-DATA-VENCIMENTO , :HISLANCT-COD-AGENCIA-DEBITO END-EXEC. */

            if (DADOS_LANC.Fetch())
            {
                _.Move(DADOS_LANC.HISLANCT_PRM_TOTAL, HISLANCT.DCLHIST_LANC_CTA.HISLANCT_PRM_TOTAL);
                _.Move(DADOS_LANC.HISLANCT_DATA_VENCIMENTO, HISLANCT.DCLHIST_LANC_CTA.HISLANCT_DATA_VENCIMENTO);
                _.Move(DADOS_LANC.HISLANCT_COD_AGENCIA_DEBITO, HISLANCT.DCLHIST_LANC_CTA.HISLANCT_COD_AGENCIA_DEBITO);
            }

        }

        [StopWatch]
        /*" R0750-00-OBTER-DADOS-LANC-DB-CLOSE-1 */
        public void R0750_00_OBTER_DADOS_LANC_DB_CLOSE_1()
        {
            /*" -2714- EXEC SQL CLOSE DADOS-LANC END-EXEC. */

            DADOS_LANC.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0750_SAIDA*/

        [StopWatch]
        /*" R9988-00-FECHAR-ARQUIVOS-SECTION */
        private void R9988_00_FECHAR_ARQUIVOS_SECTION()
        {
            /*" -2731- CLOSE MOVTO-PRP-SASSE. */
            MOVTO_PRP_SASSE.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9988_SAIDA*/

        [StopWatch]
        /*" R9999-00-FINALIZAR-SECTION */
        private void R9999_00_FINALIZAR_SECTION()
        {
            /*" -2743- DISPLAY ' ' */
            _.Display($" ");

            /*" -2744- IF W-FIM-MOVTO-VGAP = 'FIM' */

            if (WAREA_AUXILIAR.W_FIM_MOVTO_VGAP == "FIM")
            {

                /*" -2747- MOVE 0 TO RETURN-CODE */
                _.Move(0, RETURN_CODE);

                /*" -2748- MOVE 'COMMIT WORK' TO COMANDO */
                _.Move("COMMIT WORK", WABEND.LOCALIZA_ABEND_2.COMANDO);

                /*" -2748- EXEC SQL COMMIT WORK END-EXEC */

                DatabaseConnection.Instance.CommitTransaction();

                /*" -2750- DISPLAY '*' */
                _.Display($"*");

                /*" -2751- DISPLAY '************************************************' */
                _.Display($"************************************************");

                /*" -2752- DISPLAY '*                                              *' */
                _.Display($"*                                              *");

                /*" -2753- DISPLAY '*            PF0648B - TERMINO NORMAL          *' */
                _.Display($"*            PF0648B - TERMINO NORMAL          *");

                /*" -2754- DISPLAY '*                                              *' */
                _.Display($"*                                              *");

                /*" -2755- DISPLAY '************************************************' */
                _.Display($"************************************************");

                /*" -2756- ELSE */
            }
            else
            {


                /*" -2757- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, WABEND.FILLER_12.WSQLCODE);

                /*" -2758- MOVE SQLERRD(1) TO WSQLERRD1 */
                _.Move(DB.SQLERRD[1], WABEND.FILLER_12.WSQLERRD1);

                /*" -2759- MOVE SQLERRD(2) TO WSQLERRD2 */
                _.Move(DB.SQLERRD[2], WABEND.FILLER_12.WSQLERRD2);

                /*" -2760- MOVE 'ROLLBACK WORK' TO COMANDO */
                _.Move("ROLLBACK WORK", WABEND.LOCALIZA_ABEND_2.COMANDO);

                /*" -2760- EXEC SQL ROLLBACK WORK END-EXEC */

                DatabaseConnection.Instance.RollbackTransaction();

                /*" -2762- DISPLAY '*' */
                _.Display($"*");

                /*" -2763- DISPLAY '************************************************' */
                _.Display($"************************************************");

                /*" -2764- DISPLAY '*                                              *' */
                _.Display($"*                                              *");

                /*" -2765- DISPLAY '*          PF0648B - TERMINO  ANORMAL          *' */
                _.Display($"*          PF0648B - TERMINO  ANORMAL          *");

                /*" -2766- DISPLAY '*             ROLLBACK EM ANDAMENTO            *' */
                _.Display($"*             ROLLBACK EM ANDAMENTO            *");

                /*" -2767- DISPLAY '*                                              *' */
                _.Display($"*                                              *");

                /*" -2768- DISPLAY '************************************************' */
                _.Display($"************************************************");

                /*" -2769- DISPLAY '*' WABEND */
                _.Display($"*{WABEND}");

                /*" -2770- MOVE 99 TO RETURN-CODE */
                _.Move(99, RETURN_CODE);

                /*" -2771- END-IF. */
            }


            /*" -2778- DISPLAY '*  PF0648B - FINAL   EM ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2) ' *' . */

            $"*  PF0648B - FINAL   EM {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss} *"
            .Display();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9999_SAIDA*/
    }
}