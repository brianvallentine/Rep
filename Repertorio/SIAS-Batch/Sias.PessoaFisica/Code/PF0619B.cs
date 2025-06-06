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
using Sias.PessoaFisica.DB2.PF0619B;

namespace Code
{
    public class PF0619B
    {
        public bool IsCall { get; set; }

        public PF0619B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      ******************************************************************      */
        /*"      ******************************************************************      */
        /*"      *   SISTEMA ..............  PF - PRODUTOS DE FIDELIZACAO         *      */
        /*"      *   PROGRAMA .............  PF0619B                              *      */
        /*"      *   DATA .................  08/11/2000                           *      */
        /*"      *   ANALISE/PROGRAMACAO...  LUIZ CARLOS                          *      */
        /*"      *                                                                *      */
        /*"      *   FUNCAO ...............  TRATA PROPOSTAS VIDA REJEITADAS,     *      */
        /*"      *                           GERA TABELAS P.F.                    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.18  *  VERSAO 18  - DEMANDA 496381 - ALTERAR SITUACAO DA TABELA             */
        /*"      *               PROPOSTA_FIDELIZ PARA 'REJ' QUANDO SITUACAO DO   *      */
        /*"      *               BILHETE FOR 'R' (REJEITADO) E MARCAR P/ ENVIAR AO*      */
        /*"      *               SIGPF                                            *      */
        /*"      *                                                                *      */
        /*"      *   EM 10/10/2023 - ELIERMES OLIVEIRA   PROCURE POR V.18         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.17  *  VERSAO 17  - DEMANDA 474630 - BILHETES SEM NOME E PROFISSAO   *      */
        /*"      *                                                                *      */
        /*"      *   EM 04/03/2023 - CANETTA             PROCURE POR V.17         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 16             IMPACTO DA INCLUSAO DO CAMPO             *      */
        /*"      *                       IND_TP_CONTA NA TABELA PROPOSTA_FIDELIZ. *      */
        /*"      * ATENDE DEMANDA 175.167                                         *      */
        /*"      *                                                                *      */
        /*"      * PROCURE V.16          MARCUS VALERIO                           *      */
        /*"      *                       05/02/2018                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 15             IMPACTO DA INCLUSAO DO CAMPO             *      */
        /*"      * ATENDE CADMUS 140.553 IND_TP_PROPOSTA NA TABELA                *      */
        /*"      *                       PROPOSTA_FIDELIZ.                        *      */
        /*"      * PROCURE V.15          FRANK CARVALHO                           *      */
        /*"      *                       05/08/2016                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 14             ALTERACOES NOS REGISTROS TIPO 3 E TIPO A *      */
        /*"      * ATENDE CADMUS 97713   CAMPOS :  OPERACAO E NUMERO DE CONTA     *      */
        /*"      *                                                                *      */
        /*"      * PROCURE NSGD          REGINALDO SILVA                          *      */
        /*"      *                       23/10/2014                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 13             AJUSTE INSERT PROPOSTA_FIDELIZ DE PROP   *      */
        /*"      * ATENDE CADMUS 88764   JA EXISTENTE NA TABELA                   *      */
        /*"      *                                                                *      */
        /*"      * PROCURE V.13          REGINALDO SILVA                          *      */
        /*"      *                       03/06/2015                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 12             AJUSTE INSERT HIST_PROP_FIDELIZ          *      */
        /*"      * ATENDE CADMUS 88764   COD-EMPRESA    E   COD-PRODUTO           *      */
        /*"      *                                                                *      */
        /*"      * PROCURE IHP           REGINALDO SILVA / SERGIO LORETO          *      */
        /*"      *                       11/11/2013                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 11             AJUSTE NOS SELECTS V10                   *      */
        /*"      * ATENDE CADMUS 84809   DB2.V10  SELECTS                         *      */
        /*"      *                                                                *      */
        /*"      *                       REGINALDO DA SILVA                       *      */
        /*"      *                       10/09/2013                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 10-    ATENDE CADMUS 75904 - PROJETO MONITORAMENTO      *      */
        /*"      *               AJUSTE NO CAMPO ORIGEM PROPOSTA NO ARQ DE SAIDA  *      */
        /*"      * DATA     -    23/11/2012                                       *      */
        /*"      * ELABORADO-    REGINALDO DA SILVA    PROCURE POR V.10           *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO  9-    ATENDE CADMUS 43172                              *      */
        /*"      * 31/05/2010 PROCURE POR V.09 - EDSON MARQUES    .               *      */
        /*"      * OBJETIVO - REJEITAR PROPOSTAS DE VENDAS NA CENTRAL GCS         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO  8-    ATENDE CADMUS                                    *      */
        /*"      * 10/04/2010 PROCURE POR V.08 - EDSON MARQUES    .               *      */
        /*"      * OBJETIVO - IDENTIFICAR, PROCESSAR E ENVIAR A MOVIMENTACAO DOS  *      */
        /*"      *            SEGURADOS DE VIDA A CAIXA E A FENAE CORRETORA.      *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 7 - ATENDE CADMUS32886                                  *      */
        /*"      *                                                                *      */
        /*"      * 18/11/2009 PROCURE POR V.07 - EDILANA CERQUEIRA.               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 6 - RETIRA LIMITACAO DE REGISTROS E ATUALIZA DCLGEN     *      */
        /*"      *                                                                *      */
        /*"      * 21/07/2009 PROCURE POR V.06 - EDILANA CERQUEIRA.               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 5 - DESPREZAR COD_PRODUTO_SIVPF IGUAL A 48. TRATA-SE DA *      */
        /*"      *            INTERNALIZACAO DE APOLICE ESPECIFICA DE VIDA.       *      */
        /*"      *                                                                *      */
        /*"      * 27/11/2007 PROCURE POR V.05 - MAURICIO LINKE.                  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 4 - NO SEGURO VIDA MULHER NAO SERA GERADO O REGISTRO '6'*      */
        /*"      *            A DPS SERA GERADA EM BRANCO. CONFORME ORIENTACAO  DO*      */
        /*"      *            SR. MARCELO GABRIEL.                                *      */
        /*"      *                                                                *      */
        /*"      * 02/03/2005 PROCURE POR V.04 - LUIZ CARLOS.                     *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 3 - PASSOU A GERAR A HIST_PROP_FIDELIZ, COM MOTIVO 229  *      */
        /*"      *            INDICANDO PROPOSTA REJEITADA ANTES DA EMISSAO.      *      */
        /*"      *            O ARQIVO GERADO A CEF CONTINUA COM MOTIVO 209.      *      */
        /*"      *                                                                *      */
        /*"      * 11/06/2003 PROCURE POR V.03 - LUIZ CARLOS.                     *      */
        /*"      ******************************************************************      */
        /*"      * VERSAO 2 - 06/05/2003 PASSOU A OBTER A DATA DE EXPEDICAO DO RG,*      */
        /*"      *            ADEQUANDO-SE   A CIRCULAR 200 SUSEP.                *      */
        /*"      *                                                                *      */
        /*"      *            PROCURE POR V.02 - LUIZ CARLOS.                     *      */
        /*"      ******************************************************************      */
        /*"      * VERSAO 1 - PASSOU A DESPREZAR MOVIMENTO DO PRODUTO 9313.       *      */
        /*"      *            'CAIXA CONS RCIO PRESTAMISTA'.                      *      */
        /*"      *                                                                *      */
        /*"      * 28/03/2003 - PROCURE POR V.01.                                 *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"      * ALTERACAO NO ACESSO A TABELA PRODUTOS_SIVPF EM FUNCAO DE       *      */
        /*"      * HAVER MAIS DE UMA LINHA PARA O MESMO COD_PRODUTO_SIVPF         *      */
        /*"      * (VIDA DA GENTE E MULTIPREMIADO SUPER)                          *      */
        /*"      * (PROCURAR POR 240703) - CHICON (PRODEXTER)            JUL/2003 *      */
        /*"      ******************************************************************      */
        /*"      ******************************************************************      */
        /*"      ******************************************************************      */
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
        /*"01  VIND-NUM-PROPOSTA                 PIC S9(4)  COMP VALUE +0.*/
        public IntBasis VIND_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-FAIXA-RENDA-IND              PIC S9(4)  COMP VALUE +0.*/
        public IntBasis VIND_FAIXA_RENDA_IND { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-FAIXA-RENDA-FAM              PIC S9(4)  COMP VALUE +0.*/
        public IntBasis VIND_FAIXA_RENDA_FAM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-APOS-INVALIDEZ               PIC S9(4)  COMP VALUE +0.*/
        public IntBasis VIND_APOS_INVALIDEZ { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-COD-ORIGEM-PROP              PIC S9(4)  COMP VALUE +0.*/
        public IntBasis VIND_COD_ORIGEM_PROP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
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
        /*"01  VIND-GRAU-PAREN                   PIC S9(4) COMP VALUE +0.*/
        public IntBasis VIND_GRAU_PAREN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-COD-UF                       PIC S9(4) COMP VALUE +0.*/
        public IntBasis VIND_COD_UF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
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
        /*"01  COD-CBO-TIT                       PIC S9(9)  COMP.*/
        public IntBasis COD_CBO_TIT { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"01  COD-CBO-CONJ                      PIC S9(9)  COMP.*/
        public IntBasis COD_CBO_CONJ { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"01             W01DIGCERT.*/
        public PF0619B_W01DIGCERT W01DIGCERT { get; set; } = new PF0619B_W01DIGCERT();
        public class PF0619B_W01DIGCERT : VarBasis
        {
            /*"    05         WCERTIFICADO    PIC  9(015)        VALUE  0.*/
            public IntBasis WCERTIFICADO { get; set; } = new IntBasis(new PIC("9", "15", "9(015)"));
            /*"    05         WNUMERO         PIC S9(004)  COMP  VALUE +15.*/
            public IntBasis WNUMERO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), +15);
            /*"    05         WDIG            PIC  X(001)  VALUE SPACES.*/
            public StringBasis WDIG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"01  WAREA-AUXILIAR.*/
        }
        public PF0619B_WAREA_AUXILIAR WAREA_AUXILIAR { get; set; } = new PF0619B_WAREA_AUXILIAR();
        public class PF0619B_WAREA_AUXILIAR : VarBasis
        {
            /*"    05  W-FIM-MOVTO-VGAP              PIC X(003)  VALUE SPACES.*/
            public StringBasis W_FIM_MOVTO_VGAP { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
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
            /*"    05  W-FIM-CURSOR-BILHETE          PIC X(003)  VALUE SPACES.*/
            public StringBasis W_FIM_CURSOR_BILHETE { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"    05  W-AC-CONTROLE                 PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_AC_CONTROLE { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  WS-QTD-BILHETE                PIC  9(08)  VALUE ZEROS.*/
            public IntBasis WS_QTD_BILHETE { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
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
            /*"    05  W-TOT-ATU-PRP                 PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_TOT_ATU_PRP { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
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
            /*"    05  W-ACHOU-SICOB                 PIC X(003)  VALUE 'NAO'.*/
            public StringBasis W_ACHOU_SICOB { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
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
            /*"    05  W-ACHOU-PGTO                  PIC X(003)  VALUE 'NAO'.*/
            public StringBasis W_ACHOU_PGTO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
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
            private _REDEF_PF0619B_FILLER_0 _filler_0 { get; set; }
            public _REDEF_PF0619B_FILLER_0 FILLER_0
            {
                get { _filler_0 = new _REDEF_PF0619B_FILLER_0(); _.Move(W_PRAZO_PERCEPCAO, _filler_0); VarBasis.RedefinePassValue(W_PRAZO_PERCEPCAO, _filler_0, W_PRAZO_PERCEPCAO); _filler_0.ValueChanged += () => { _.Move(_filler_0, W_PRAZO_PERCEPCAO); }; return _filler_0; }
                set { VarBasis.RedefinePassValue(value, _filler_0, W_PRAZO_PERCEPCAO); }
            }  //Redefines
            public class _REDEF_PF0619B_FILLER_0 : VarBasis
            {
                /*"        07  W-PERCEPCAO               PIC X(002).*/
                public StringBasis W_PERCEPCAO { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"    05  W-NR-IDENTIDADE               PIC 9(008)  VALUE ZEROS.*/

                public _REDEF_PF0619B_FILLER_0()
                {
                    W_PERCEPCAO.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis W_NR_IDENTIDADE { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05  FILLER REDEFINES W-NR-IDENTIDADE.*/
            private _REDEF_PF0619B_FILLER_1 _filler_1 { get; set; }
            public _REDEF_PF0619B_FILLER_1 FILLER_1
            {
                get { _filler_1 = new _REDEF_PF0619B_FILLER_1(); _.Move(W_NR_IDENTIDADE, _filler_1); VarBasis.RedefinePassValue(W_NR_IDENTIDADE, _filler_1, W_NR_IDENTIDADE); _filler_1.ValueChanged += () => { _.Move(_filler_1, W_NR_IDENTIDADE); }; return _filler_1; }
                set { VarBasis.RedefinePassValue(value, _filler_1, W_NR_IDENTIDADE); }
            }  //Redefines
            public class _REDEF_PF0619B_FILLER_1 : VarBasis
            {
                /*"        07  W-NR-RG                   PIC X(008).*/
                public StringBasis W_NR_RG { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
                /*"    05  W-NUM-PROPOSTA-NOVA           PIC  9(014).*/

                public _REDEF_PF0619B_FILLER_1()
                {
                    W_NR_RG.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis W_NUM_PROPOSTA_NOVA { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
            /*"    05  CANAL  REDEFINES W-NUM-PROPOSTA-NOVA.*/
            private _REDEF_PF0619B_CANAL _canal { get; set; }
            public _REDEF_PF0619B_CANAL CANAL
            {
                get { _canal = new _REDEF_PF0619B_CANAL(); _.Move(W_NUM_PROPOSTA_NOVA, _canal); VarBasis.RedefinePassValue(W_NUM_PROPOSTA_NOVA, _canal, W_NUM_PROPOSTA_NOVA); _canal.ValueChanged += () => { _.Move(_canal, W_NUM_PROPOSTA_NOVA); }; return _canal; }
                set { VarBasis.RedefinePassValue(value, _canal, W_NUM_PROPOSTA_NOVA); }
            }  //Redefines
            public class _REDEF_PF0619B_CANAL : VarBasis
            {
                /*"        07  W-NUM-PROPOSTA-ATUAL      PIC  9(013).*/
                public IntBasis W_NUM_PROPOSTA_ATUAL { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
                /*"        07  W-DV-PROPOSTA-NOVA        PIC  9(001).*/
                public IntBasis W_DV_PROPOSTA_NOVA { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    05  W-NSAS                        PIC 9(006).*/

                public _REDEF_PF0619B_CANAL()
                {
                    W_NUM_PROPOSTA_ATUAL.ValueChanged += OnValueChanged;
                    W_DV_PROPOSTA_NOVA.ValueChanged += OnValueChanged;
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
            private _REDEF_PF0619B_FILLER_2 _filler_2 { get; set; }
            public _REDEF_PF0619B_FILLER_2 FILLER_2
            {
                get { _filler_2 = new _REDEF_PF0619B_FILLER_2(); _.Move(W_DATA_TRABALHO, _filler_2); VarBasis.RedefinePassValue(W_DATA_TRABALHO, _filler_2, W_DATA_TRABALHO); _filler_2.ValueChanged += () => { _.Move(_filler_2, W_DATA_TRABALHO); }; return _filler_2; }
                set { VarBasis.RedefinePassValue(value, _filler_2, W_DATA_TRABALHO); }
            }  //Redefines
            public class _REDEF_PF0619B_FILLER_2 : VarBasis
            {
                /*"        07  W-DIA-TRABALHO            PIC 9(002).*/
                public IntBasis W_DIA_TRABALHO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"        07  W-MES-TRABALHO            PIC 9(002).*/
                public IntBasis W_MES_TRABALHO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"        07  W-ANO-TRABALHO            PIC 9(004).*/
                public IntBasis W_ANO_TRABALHO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05  W-DATA-NASCIMENTO             PIC 9(008)  VALUE ZEROS.*/

                public _REDEF_PF0619B_FILLER_2()
                {
                    W_DIA_TRABALHO.ValueChanged += OnValueChanged;
                    W_MES_TRABALHO.ValueChanged += OnValueChanged;
                    W_ANO_TRABALHO.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis W_DATA_NASCIMENTO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05  FILLER REDEFINES W-DATA-NASCIMENTO.*/
            private _REDEF_PF0619B_FILLER_3 _filler_3 { get; set; }
            public _REDEF_PF0619B_FILLER_3 FILLER_3
            {
                get { _filler_3 = new _REDEF_PF0619B_FILLER_3(); _.Move(W_DATA_NASCIMENTO, _filler_3); VarBasis.RedefinePassValue(W_DATA_NASCIMENTO, _filler_3, W_DATA_NASCIMENTO); _filler_3.ValueChanged += () => { _.Move(_filler_3, W_DATA_NASCIMENTO); }; return _filler_3; }
                set { VarBasis.RedefinePassValue(value, _filler_3, W_DATA_NASCIMENTO); }
            }  //Redefines
            public class _REDEF_PF0619B_FILLER_3 : VarBasis
            {
                /*"        07  W-DIA-NASCIMENTO          PIC 9(002).*/
                public IntBasis W_DIA_NASCIMENTO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"        07  W-MES-NASCIMENTO          PIC 9(002).*/
                public IntBasis W_MES_NASCIMENTO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"        07  W-ANO-NASCIMENTO          PIC 9(004).*/
                public IntBasis W_ANO_NASCIMENTO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05  WHOST-SIT-PROPOSTA            PIC  X(003).*/

                public _REDEF_PF0619B_FILLER_3()
                {
                    W_DIA_NASCIMENTO.ValueChanged += OnValueChanged;
                    W_MES_NASCIMENTO.ValueChanged += OnValueChanged;
                    W_ANO_NASCIMENTO.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WHOST_SIT_PROPOSTA { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
            /*"    05  WHOST-SIT-ENVIO               PIC  X(001).*/
            public StringBasis WHOST_SIT_ENVIO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    05  HOST-DT-TERVIG1               PIC X(010)  VALUE        '1999-12-31'.*/
            public StringBasis HOST_DT_TERVIG1 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"1999-12-31");
            /*"    05  HOST-DT-TERVIG2               PIC X(010)  VALUE        '9999-12-31'.*/
            public StringBasis HOST_DT_TERVIG2 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"9999-12-31");
            /*"    05  W-DTMOVABE                    PIC X(010).*/
            public StringBasis W_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    05  W-DTMOVABE1 REDEFINES W-DTMOVABE.*/
            private _REDEF_PF0619B_W_DTMOVABE1 _w_dtmovabe1 { get; set; }
            public _REDEF_PF0619B_W_DTMOVABE1 W_DTMOVABE1
            {
                get { _w_dtmovabe1 = new _REDEF_PF0619B_W_DTMOVABE1(); _.Move(W_DTMOVABE, _w_dtmovabe1); VarBasis.RedefinePassValue(W_DTMOVABE, _w_dtmovabe1, W_DTMOVABE); _w_dtmovabe1.ValueChanged += () => { _.Move(_w_dtmovabe1, W_DTMOVABE); }; return _w_dtmovabe1; }
                set { VarBasis.RedefinePassValue(value, _w_dtmovabe1, W_DTMOVABE); }
            }  //Redefines
            public class _REDEF_PF0619B_W_DTMOVABE1 : VarBasis
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

                public _REDEF_PF0619B_W_DTMOVABE1()
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
            private _REDEF_PF0619B_W_DTMOVABE_I1 _w_dtmovabe_i1 { get; set; }
            public _REDEF_PF0619B_W_DTMOVABE_I1 W_DTMOVABE_I1
            {
                get { _w_dtmovabe_i1 = new _REDEF_PF0619B_W_DTMOVABE_I1(); _.Move(W_DTMOVABE_I, _w_dtmovabe_i1); VarBasis.RedefinePassValue(W_DTMOVABE_I, _w_dtmovabe_i1, W_DTMOVABE_I); _w_dtmovabe_i1.ValueChanged += () => { _.Move(_w_dtmovabe_i1, W_DTMOVABE_I); }; return _w_dtmovabe_i1; }
                set { VarBasis.RedefinePassValue(value, _w_dtmovabe_i1, W_DTMOVABE_I); }
            }  //Redefines
            public class _REDEF_PF0619B_W_DTMOVABE_I1 : VarBasis
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

                public _REDEF_PF0619B_W_DTMOVABE_I1()
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
            private _REDEF_PF0619B_W_DATA_SQL1 _w_data_sql1 { get; set; }
            public _REDEF_PF0619B_W_DATA_SQL1 W_DATA_SQL1
            {
                get { _w_data_sql1 = new _REDEF_PF0619B_W_DATA_SQL1(); _.Move(W_DATA_SQL, _w_data_sql1); VarBasis.RedefinePassValue(W_DATA_SQL, _w_data_sql1, W_DATA_SQL); _w_data_sql1.ValueChanged += () => { _.Move(_w_data_sql1, W_DATA_SQL); }; return _w_data_sql1; }
                set { VarBasis.RedefinePassValue(value, _w_data_sql1, W_DATA_SQL); }
            }  //Redefines
            public class _REDEF_PF0619B_W_DATA_SQL1 : VarBasis
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

                public _REDEF_PF0619B_W_DATA_SQL1()
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
            private _REDEF_PF0619B_FILLER_4 _filler_4 { get; set; }
            public _REDEF_PF0619B_FILLER_4 FILLER_4
            {
                get { _filler_4 = new _REDEF_PF0619B_FILLER_4(); _.Move(W_NR_SICOB, _filler_4); VarBasis.RedefinePassValue(W_NR_SICOB, _filler_4, W_NR_SICOB); _filler_4.ValueChanged += () => { _.Move(_filler_4, W_NR_SICOB); }; return _filler_4; }
                set { VarBasis.RedefinePassValue(value, _filler_4, W_NR_SICOB); }
            }  //Redefines
            public class _REDEF_PF0619B_FILLER_4 : VarBasis
            {
                /*"        07  W-NR-PROD-SICOB           PIC 9(003).*/
                public IntBasis W_NR_PROD_SICOB { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"        07  W-NR-NSAC-SICOB           PIC 9(006).*/
                public IntBasis W_NR_NSAC_SICOB { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"        07  W-NR-NSL-SICOB            PIC 9(006).*/
                public IntBasis W_NR_NSL_SICOB { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"    05  W-TEM-TABPROPFID              PIC 9(001)  VALUE ZERO.*/

                public _REDEF_PF0619B_FILLER_4()
                {
                    W_NR_PROD_SICOB.ValueChanged += OnValueChanged;
                    W_NR_NSAC_SICOB.ValueChanged += OnValueChanged;
                    W_NR_NSL_SICOB.ValueChanged += OnValueChanged;
                }

            }

            public SelectorBasis W_TEM_TABPROPFID { get; set; } = new SelectorBasis("001", "ZERO")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88     TEM-TABPROPFID                 VALUE 1. */
							new SelectorItemBasis("TEM_TABPROPFID", "1"),
							/*" 88 NAO-TEM-TABPROPFID                 VALUE 2. */
							new SelectorItemBasis("NAO_TEM_TABPROPFID", "2")
                }
            };

            /*"    05  W-NUM-PROPOSTA                PIC 9(014).*/
            public IntBasis W_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
            /*"    05  CANAL  REDEFINES W-NUM-PROPOSTA.*/
            private _REDEF_PF0619B_CANAL_0 _canal_0 { get; set; }
            public _REDEF_PF0619B_CANAL_0 CANAL_0
            {
                get { _canal_0 = new _REDEF_PF0619B_CANAL_0(); _.Move(W_NUM_PROPOSTA, _canal_0); VarBasis.RedefinePassValue(W_NUM_PROPOSTA, _canal_0, W_NUM_PROPOSTA); _canal_0.ValueChanged += () => { _.Move(_canal_0, W_NUM_PROPOSTA); }; return _canal_0; }
                set { VarBasis.RedefinePassValue(value, _canal_0, W_NUM_PROPOSTA); }
            }  //Redefines
            public class _REDEF_PF0619B_CANAL_0 : VarBasis
            {
                /*"        07  W-CANAL-PROPOSTA          PIC 9(001).*/

                public SelectorBasis W_CANAL_PROPOSTA { get; set; } = new SelectorBasis("001")
                {
                    Items = new List<SelectorItemBasis> {
                            /*" 88 CANAL-VENDA-PAPEL                  VALUE 0. */
							new SelectorItemBasis("CANAL_VENDA_PAPEL", "0"),
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
							new SelectorItemBasis("CANAL_INTERNET", "7")
                }
                };

                /*"        07  FILLER                    PIC X(013).*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)."), @"");
                /*"    05  FAIXAS  REDEFINES W-NUM-PROPOSTA.*/

                public _REDEF_PF0619B_CANAL_0()
                {
                    W_CANAL_PROPOSTA.ValueChanged += OnValueChanged;
                    FILLER_5.ValueChanged += OnValueChanged;
                }

            }
            private _REDEF_PF0619B_FAIXAS _faixas { get; set; }
            public _REDEF_PF0619B_FAIXAS FAIXAS
            {
                get { _faixas = new _REDEF_PF0619B_FAIXAS(); _.Move(W_NUM_PROPOSTA, _faixas); VarBasis.RedefinePassValue(W_NUM_PROPOSTA, _faixas, W_NUM_PROPOSTA); _faixas.ValueChanged += () => { _.Move(_faixas, W_NUM_PROPOSTA); }; return _faixas; }
                set { VarBasis.RedefinePassValue(value, _faixas, W_NUM_PROPOSTA); }
            }  //Redefines
            public class _REDEF_PF0619B_FAIXAS : VarBasis
            {
                /*"        07  FILLER                    PIC 9(003).*/
                public IntBasis FILLER_6 { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
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
                public IntBasis FILLER_7 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"    05 W-CURSOR                       PIC  9(001) VALUE ZERO.*/

                public _REDEF_PF0619B_FAIXAS()
                {
                    FILLER_6.ValueChanged += OnValueChanged;
                    FAIXA_NUMERACAO.ValueChanged += OnValueChanged;
                    FILLER_7.ValueChanged += OnValueChanged;
                }

            }

            public SelectorBasis W_CURSOR { get; set; } = new SelectorBasis("001", "ZERO")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 CURSOR-MONTADO                          VALUE 1. */
							new SelectorItemBasis("CURSOR_MONTADO", "1"),
							/*" 88 CURSOR-N-MONTADO                        VALUE 2. */
							new SelectorItemBasis("CURSOR_N_MONTADO", "2")
                }
            };

            /*"    05  W-NUMR-TITULO               PIC  9(013)   VALUE ZEROS.*/
            public IntBasis W_NUMR_TITULO { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
            /*"    05  FILLER                      REDEFINES    W-NUMR-TITULO.*/
            private _REDEF_PF0619B_FILLER_8 _filler_8 { get; set; }
            public _REDEF_PF0619B_FILLER_8 FILLER_8
            {
                get { _filler_8 = new _REDEF_PF0619B_FILLER_8(); _.Move(W_NUMR_TITULO, _filler_8); VarBasis.RedefinePassValue(W_NUMR_TITULO, _filler_8, W_NUMR_TITULO); _filler_8.ValueChanged += () => { _.Move(_filler_8, W_NUMR_TITULO); }; return _filler_8; }
                set { VarBasis.RedefinePassValue(value, _filler_8, W_NUMR_TITULO); }
            }  //Redefines
            public class _REDEF_PF0619B_FILLER_8 : VarBasis
            {
                /*"      10    WTITL-ZEROS             PIC  9(002).*/
                public IntBasis WTITL_ZEROS { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10    WTITL-SEQUENCIA         PIC  9(010).*/
                public IntBasis WTITL_SEQUENCIA { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
                /*"      10    WTITL-DIGITO            PIC  9(001).*/
                public IntBasis WTITL_DIGITO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    05              DPARM01X.*/

                public _REDEF_PF0619B_FILLER_8()
                {
                    WTITL_ZEROS.ValueChanged += OnValueChanged;
                    WTITL_SEQUENCIA.ValueChanged += OnValueChanged;
                    WTITL_DIGITO.ValueChanged += OnValueChanged;
                }

            }
            public PF0619B_DPARM01X DPARM01X { get; set; } = new PF0619B_DPARM01X();
            public class PF0619B_DPARM01X : VarBasis
            {
                /*"      07            DPARM01           PIC  9(010).*/
                public IntBasis DPARM01 { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
                /*"      07            DPARM01-R         REDEFINES   DPARM01.*/
                private _REDEF_PF0619B_DPARM01_R _dparm01_r { get; set; }
                public _REDEF_PF0619B_DPARM01_R DPARM01_R
                {
                    get { _dparm01_r = new _REDEF_PF0619B_DPARM01_R(); _.Move(DPARM01, _dparm01_r); VarBasis.RedefinePassValue(DPARM01, _dparm01_r, DPARM01); _dparm01_r.ValueChanged += () => { _.Move(_dparm01_r, DPARM01); }; return _dparm01_r; }
                    set { VarBasis.RedefinePassValue(value, _dparm01_r, DPARM01); }
                }  //Redefines
                public class _REDEF_PF0619B_DPARM01_R : VarBasis
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

                    public _REDEF_PF0619B_DPARM01_R()
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
                /*"    05  W-NOM-ORGAO-EXP               PIC X(030).*/
            }
            public StringBasis W_NOM_ORGAO_EXP { get; set; } = new StringBasis(new PIC("X", "30", "X(030)."), @"");
            /*"    05  FILLER REDEFINES W-NOM-ORGAO-EXP.*/
            private _REDEF_PF0619B_FILLER_9 _filler_9 { get; set; }
            public _REDEF_PF0619B_FILLER_9 FILLER_9
            {
                get { _filler_9 = new _REDEF_PF0619B_FILLER_9(); _.Move(W_NOM_ORGAO_EXP, _filler_9); VarBasis.RedefinePassValue(W_NOM_ORGAO_EXP, _filler_9, W_NOM_ORGAO_EXP); _filler_9.ValueChanged += () => { _.Move(_filler_9, W_NOM_ORGAO_EXP); }; return _filler_9; }
                set { VarBasis.RedefinePassValue(value, _filler_9, W_NOM_ORGAO_EXP); }
            }  //Redefines
            public class _REDEF_PF0619B_FILLER_9 : VarBasis
            {
                /*"        07  W-ORGAO-EXPEDIDOR         PIC X(005).*/
                public StringBasis W_ORGAO_EXPEDIDOR { get; set; } = new StringBasis(new PIC("X", "5", "X(005)."), @"");
                /*"        07  FILLER                    PIC X(025).*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)."), @"");
                /*"    05 W-COD-EMPRESA                  PIC  9(001) VALUE ZERO.*/

                public _REDEF_PF0619B_FILLER_9()
                {
                    W_ORGAO_EXPEDIDOR.ValueChanged += OnValueChanged;
                    FILLER_10.ValueChanged += OnValueChanged;
                }

            }

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

            /*"    05 W-INF-COMPLEMENTAR             PIC  9(001) VALUE ZERO.*/

            public SelectorBasis W_INF_COMPLEMENTAR { get; set; } = new SelectorBasis("001", "ZERO")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 EXISTE-INF-COMPLEMENTAR                 VALUE 1. */
							new SelectorItemBasis("EXISTE_INF_COMPLEMENTAR", "1")
                }
            };

            /*"    05 W-LER-CLIENTE                  PIC  9(001) VALUE ZERO.*/

            public SelectorBasis W_LER_CLIENTE { get; set; } = new SelectorBasis("001", "ZERO")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 EXISTE-CLIENTE                          VALUE 1. */
							new SelectorItemBasis("EXISTE_CLIENTE", "1")
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
							new SelectorItemBasis("BILHETE", "4")
                }
            };

            /*"    05 W-PRODUTO                      PIC  9(002) VALUE ZEROS.*/

            public SelectorBasis W_PRODUTO { get; set; } = new SelectorBasis("002", "ZEROS")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 MULTIPREMIADO                           VALUE 01. */
							new SelectorItemBasis("MULTIPREMIADO", "01"),
							/*" 88 FEDPREV                                 VALUE 02. */
							new SelectorItemBasis("FEDPREV", "02"),
							/*" 88 FEDECAP                                 VALUE 03. */
							new SelectorItemBasis("FEDECAP", "03"),
							/*" 88 EXECUTIVO                               VALUE 04. */
							new SelectorItemBasis("EXECUTIVO", "04"),
							/*" 88 FEDPREV-CRESCER                         VALUE 05. */
							new SelectorItemBasis("FEDPREV_CRESCER", "05"),
							/*" 88 FEDPREV-PGTO-UNICO                      VALUE 06. */
							new SelectorItemBasis("FEDPREV_PGTO_UNICO", "06"),
							/*" 88 SENIOR                                  VALUE 07. */
							new SelectorItemBasis("SENIOR", "07"),
							/*" 88 FEDPREV-ECONOMIARIO                     VALUE 08. */
							new SelectorItemBasis("FEDPREV_ECONOMIARIO", "08"),
							/*" 88 BILHETE-AP                              VALUE 09. */
							new SelectorItemBasis("BILHETE_AP", "09"),
							/*" 88 BILHETE-RD                              VALUE 10. */
							new SelectorItemBasis("BILHETE_RD", "10"),
							/*" 88 VIDA-DA-GENTE                           VALUE 11. */
							new SelectorItemBasis("VIDA_DA_GENTE", "11"),
							/*" 88 MULTIPREMIADO-SUPER                     VALUE 13. */
							new SelectorItemBasis("MULTIPREMIADO_SUPER", "13")
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

            /*"    05 W-OBTER-DADOS-RG               PIC  9(001) VALUE ZERO.*/

            public SelectorBasis W_OBTER_DADOS_RG { get; set; } = new SelectorBasis("001", "ZERO")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 OBTEVE-DADOS-RG                         VALUE 1. */
							new SelectorItemBasis("OBTEVE_DADOS_RG", "1")
                }
            };

            /*"01  WABEND*/
        }
        public PF0619B_WABEND WABEND { get; set; } = new PF0619B_WABEND();
        public class PF0619B_WABEND : VarBasis
        {
            /*"    05 FILLER.*/
            public PF0619B_FILLER_11 FILLER_11 { get; set; } = new PF0619B_FILLER_11();
            public class PF0619B_FILLER_11 : VarBasis
            {
                /*"      10    FILLER                   PIC  X(010) VALUE            'PF0619B  '.*/
                public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"PF0619B  ");
                /*"      10    FILLER                   PIC  X(028) VALUE            ' *** ERRO  EXEC SQL *** '.*/
                public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @" *** ERRO  EXEC SQL *** ");
                /*"      10    FILLER                   PIC  X(014) VALUE            '    SQLCODE = '.*/
                public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE = ");
                /*"      10    WSQLCODE                 PIC  ZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
                /*"      10    FILLER                   PIC  X(014)   VALUE            '   SQLERRD1 = '.*/
                public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD1 = ");
                /*"      10    WSQLERRD1                PIC  ZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLERRD1 { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
                /*"      10    FILLER                   PIC  X(014)   VALUE            '   SQLERRD2 = '.*/
                public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD2 = ");
                /*"      10    WSQLERRD2                PIC  ZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLERRD2 { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
                /*"      10    FILLER                   PIC  X(014)   VALUE            '   SQLERRD2 = '.*/
                public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD2 = ");
                /*"    05      LOCALIZA-ABEND-1.*/
            }
            public PF0619B_LOCALIZA_ABEND_1 LOCALIZA_ABEND_1 { get; set; } = new PF0619B_LOCALIZA_ABEND_1();
            public class PF0619B_LOCALIZA_ABEND_1 : VarBasis
            {
                /*"      10    FILLER                   PIC  X(012)   VALUE            'PARAGRAFO = '.*/
                public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"PARAGRAFO = ");
                /*"      10    PARAGRAFO                PIC  X(040)   VALUE SPACES.*/
                public StringBasis PARAGRAFO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"    05      LOCALIZA-ABEND-2.*/
            }
            public PF0619B_LOCALIZA_ABEND_2 LOCALIZA_ABEND_2 { get; set; } = new PF0619B_LOCALIZA_ABEND_2();
            public class PF0619B_LOCALIZA_ABEND_2 : VarBasis
            {
                /*"      10    FILLER                   PIC  X(012)   VALUE            'COMANDO   = '.*/
                public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"COMANDO   = ");
                /*"      10    COMANDO                  PIC  X(060)   VALUE SPACES.*/
                public StringBasis COMANDO { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"");
                /*"01    WS-HORAS.*/
            }
        }
        public PF0619B_WS_HORAS WS_HORAS { get; set; } = new PF0619B_WS_HORAS();
        public class PF0619B_WS_HORAS : VarBasis
        {
            /*"    03  WS-HORA-INI               PIC  X(008).*/
            public StringBasis WS_HORA_INI { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"    03  WS-HORA-INI-R REDEFINES WS-HORA-INI.*/
            private _REDEF_PF0619B_WS_HORA_INI_R _ws_hora_ini_r { get; set; }
            public _REDEF_PF0619B_WS_HORA_INI_R WS_HORA_INI_R
            {
                get { _ws_hora_ini_r = new _REDEF_PF0619B_WS_HORA_INI_R(); _.Move(WS_HORA_INI, _ws_hora_ini_r); VarBasis.RedefinePassValue(WS_HORA_INI, _ws_hora_ini_r, WS_HORA_INI); _ws_hora_ini_r.ValueChanged += () => { _.Move(_ws_hora_ini_r, WS_HORA_INI); }; return _ws_hora_ini_r; }
                set { VarBasis.RedefinePassValue(value, _ws_hora_ini_r, WS_HORA_INI); }
            }  //Redefines
            public class _REDEF_PF0619B_WS_HORA_INI_R : VarBasis
            {
                /*"        05  HI                    PIC  9(002).*/
                public IntBasis HI { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"        05  MI                    PIC  9(002).*/
                public IntBasis MI { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"        05  SI                    PIC  9(002).*/
                public IntBasis SI { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"        05  DI                    PIC  9(002).*/
                public IntBasis DI { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    03  WS-HORA-FIM               PIC  X(008).*/

                public _REDEF_PF0619B_WS_HORA_INI_R()
                {
                    HI.ValueChanged += OnValueChanged;
                    MI.ValueChanged += OnValueChanged;
                    SI.ValueChanged += OnValueChanged;
                    DI.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WS_HORA_FIM { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"    03  WS-HORA-FIM-R REDEFINES WS-HORA-FIM.*/
            private _REDEF_PF0619B_WS_HORA_FIM_R _ws_hora_fim_r { get; set; }
            public _REDEF_PF0619B_WS_HORA_FIM_R WS_HORA_FIM_R
            {
                get { _ws_hora_fim_r = new _REDEF_PF0619B_WS_HORA_FIM_R(); _.Move(WS_HORA_FIM, _ws_hora_fim_r); VarBasis.RedefinePassValue(WS_HORA_FIM, _ws_hora_fim_r, WS_HORA_FIM); _ws_hora_fim_r.ValueChanged += () => { _.Move(_ws_hora_fim_r, WS_HORA_FIM); }; return _ws_hora_fim_r; }
                set { VarBasis.RedefinePassValue(value, _ws_hora_fim_r, WS_HORA_FIM); }
            }  //Redefines
            public class _REDEF_PF0619B_WS_HORA_FIM_R : VarBasis
            {
                /*"        05  HF                    PIC  9(002).*/
                public IntBasis HF { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"        05  MF                    PIC  9(002).*/
                public IntBasis MF { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"        05  SF                    PIC  9(002).*/
                public IntBasis SF { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"        05  DF                    PIC  9(002).*/
                public IntBasis DF { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    03  SIT                       PIC S9(013)V99 COMP-3.*/

                public _REDEF_PF0619B_WS_HORA_FIM_R()
                {
                    HF.ValueChanged += OnValueChanged;
                    MF.ValueChanged += OnValueChanged;
                    SF.ValueChanged += OnValueChanged;
                    DF.ValueChanged += OnValueChanged;
                }

            }
            public DoubleBasis SIT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    03  SFT                       PIC S9(013)V99 COMP-3.*/
            public DoubleBasis SFT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    03  SII                       PIC S9(004)    COMP.*/
            public IntBasis SII { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    03  STT-DISP                  PIC --.---.---.---.--9,99.*/
            public DoubleBasis STT_DISP { get; set; } = new DoubleBasis(new PIC("9", "14", "--.---.---.---.--9V99."), 2);
            /*"01  TOTAIS-ROT.*/
        }
        public PF0619B_TOTAIS_ROT TOTAIS_ROT { get; set; } = new PF0619B_TOTAIS_ROT();
        public class PF0619B_TOTAIS_ROT : VarBasis
        {
            /*"    03  FILLER  OCCURS 70 TIMES.*/
            public ListBasis<PF0619B_FILLER_20> FILLER_20 { get; set; } = new ListBasis<PF0619B_FILLER_20>(70);
            public class PF0619B_FILLER_20 : VarBasis
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
        public Dclgens.TARIBCEF TARIBCEF { get; set; } = new Dclgens.TARIBCEF();
        public Dclgens.GEDOCCLI GEDOCCLI { get; set; } = new Dclgens.GEDOCCLI();
        public Dclgens.RELATORI RELATORI { get; set; } = new Dclgens.RELATORI();
        public Dclgens.CEDENTE CEDENTE { get; set; } = new Dclgens.CEDENTE();
        public Dclgens.PESEMAIL PESEMAIL { get; set; } = new Dclgens.PESEMAIL();
        public Dclgens.BENEFPRO BENEFPRO { get; set; } = new Dclgens.BENEFPRO();
        public Dclgens.BENPROPZ BENPROPZ { get; set; } = new Dclgens.BENPROPZ();
        public Dclgens.PESFIS PESFIS { get; set; } = new Dclgens.PESFIS();
        public Dclgens.PESJUR PESJUR { get; set; } = new Dclgens.PESJUR();
        public Dclgens.PESSOA PESSOA { get; set; } = new Dclgens.PESSOA();
        public Dclgens.TPENDER TPENDER { get; set; } = new Dclgens.TPENDER();
        public Dclgens.PESENDER PESENDER { get; set; } = new Dclgens.PESENDER();
        public Dclgens.RTPRELAC RTPRELAC { get; set; } = new Dclgens.RTPRELAC();
        public Dclgens.IDERELAC IDERELAC { get; set; } = new Dclgens.IDERELAC();
        public Dclgens.PESFONE PESFONE { get; set; } = new Dclgens.PESFONE();
        public Dclgens.PROPSSVD PROPSSVD { get; set; } = new Dclgens.PROPSSVD();
        public Dclgens.COVSICOB COVSICOB { get; set; } = new Dclgens.COVSICOB();
        public Dclgens.COVSIVPF COVSIVPF { get; set; } = new Dclgens.COVSIVPF();
        public Dclgens.MALHACEF MALHACEF { get; set; } = new Dclgens.MALHACEF();
        public Dclgens.ESCNEG ESCNEG { get; set; } = new Dclgens.ESCNEG();
        public Dclgens.AGENCEF AGENCEF { get; set; } = new Dclgens.AGENCEF();
        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.PRDSIVPF PRDSIVPF { get; set; } = new Dclgens.PRDSIVPF();
        public Dclgens.FDCOMVA FDCOMVA { get; set; } = new Dclgens.FDCOMVA();
        public Dclgens.PRODVG PRODVG { get; set; } = new Dclgens.PRODVG();
        public Dclgens.PROPFIDH PROPFIDH { get; set; } = new Dclgens.PROPFIDH();
        public Dclgens.PROPFID PROPFID { get; set; } = new Dclgens.PROPFID();
        public Dclgens.CLIENTE CLIENTE { get; set; } = new Dclgens.CLIENTE();
        public Dclgens.CBO CBO { get; set; } = new Dclgens.CBO();
        public Dclgens.ENDERECO ENDERECO { get; set; } = new Dclgens.ENDERECO();
        public Dclgens.RCAPS RCAPS { get; set; } = new Dclgens.RCAPS();
        public Dclgens.MOVVGAP MOVVGAP { get; set; } = new Dclgens.MOVVGAP();
        public Dclgens.OPPAGVA OPPAGVA { get; set; } = new Dclgens.OPPAGVA();
        public Dclgens.PROPVA PROPVA { get; set; } = new Dclgens.PROPVA();
        public Dclgens.COBPRPVA COBPRPVA { get; set; } = new Dclgens.COBPRPVA();
        public Dclgens.ARQSIVPF ARQSIVPF { get; set; } = new Dclgens.ARQSIVPF();
        public Dclgens.HTCTBPVA HTCTBPVA { get; set; } = new Dclgens.HTCTBPVA();
        public PF0619B_PROPOSTAS_VA PROPOSTAS_VA { get; set; } = new PF0619B_PROPOSTAS_VA();
        public PF0619B_C01_CBO C01_CBO { get; set; } = new PF0619B_C01_CBO();
        public PF0619B_CUR_PARCELVA CUR_PARCELVA { get; set; } = new PF0619B_CUR_PARCELVA();
        public PF0619B_FUNDOCOMISVA FUNDOCOMISVA { get; set; } = new PF0619B_FUNDOCOMISVA();
        public PF0619B_BENEFICIARIOS BENEFICIARIOS { get; set; } = new PF0619B_BENEFICIARIOS();
        public PF0619B_EMAIL EMAIL { get; set; } = new PF0619B_EMAIL();
        public PF0619B_ENDERECOS ENDERECOS { get; set; } = new PF0619B_ENDERECOS();
        public PF0619B_CRS_BILHETE CRS_BILHETE { get; set; } = new PF0619B_CRS_BILHETE();
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
            /*" -701- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -702- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -703- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -706- DISPLAY '************************************************' . */
            _.Display($"************************************************");

            /*" -707- DISPLAY '*               PROGRAMA PF0619B               *' . */
            _.Display($"*               PROGRAMA PF0619B               *");

            /*" -708- DISPLAY '*      TRATA PROPOSTAS DE VIDA REJEITADAS      *' . */
            _.Display($"*      TRATA PROPOSTAS DE VIDA REJEITADAS      *");

            /*" -711- DISPLAY '*      VERSAO:  18 - 05/10/2023                *' . */
            _.Display($"*      VERSAO:  18 - 05/10/2023                *");

            /*" -713- DISPLAY '*      COMPILACAO: ' FUNCTION WHEN-COMPILED '       *' . */

            $"*      COMPILACAO: FUNCTION{_.WhenCompiled()}       *"
            .Display();

            /*" -714- DISPLAY '************************************************' . */
            _.Display($"************************************************");

            /*" -722- DISPLAY '*  PF0619B - INICIO  EM ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2). */

            $"*  PF0619B - INICIO  EM {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
            .Display();

            /*" -723- DISPLAY '************************************************' . */
            _.Display($"************************************************");

            /*" -724- DISPLAY ' ' */
            _.Display($" ");

            /*" -726- DISPLAY ' ' */
            _.Display($" ");

            /*" -728- INITIALIZE TOTAIS-ROT. */
            _.Initialize(
                TOTAIS_ROT
            );

            /*" -730- PERFORM R0005-00-OBTER-DATA-DIA. */

            R0005_00_OBTER_DATA_DIA_SECTION();

            /*" -732- PERFORM R0007-00-OBTER-DT-PROCE. */

            R0007_00_OBTER_DT_PROCE_SECTION();

            /*" -734- PERFORM R0010-00-ABRIR-ARQUIVOS. */

            R0010_00_ABRIR_ARQUIVOS_SECTION();

            /*" -736- PERFORM R0020-00-OBTER-MAX-NSAS. */

            R0020_00_OBTER_MAX_NSAS_SECTION();

            /*" -738- MOVE 1 TO W-CURSOR. */
            _.Move(1, WAREA_AUXILIAR.W_CURSOR);

            /*" -750- PERFORM R0050-00-SELECIONA-MOVTO */

            R0050_00_SELECIONA_MOVTO_SECTION();

            /*" -752- PERFORM R0070-00-LER-MOVTO */

            R0070_00_LER_MOVTO_SECTION();

            /*" -753- IF W-FIM-MOVTO-VGAP EQUAL 'FIM' */

            if (WAREA_AUXILIAR.W_FIM_MOVTO_VGAP == "FIM")
            {

                /*" -754- DISPLAY '*--------------------------------------------*' */
                _.Display($"*--------------------------------------------*");

                /*" -755- DISPLAY '*  PF0619B - FIM NORMAL, NAO HOUVE MOVIMENTO *' */
                _.Display($"*  PF0619B - FIM NORMAL, NAO HOUVE MOVIMENTO *");

                /*" -756- DISPLAY '*--------------------------------------------*' */
                _.Display($"*--------------------------------------------*");

                /*" -759- GO TO M-0000-CONTINUA-PRINCIPAL */

                M_0000_CONTINUA_PRINCIPAL(); //GOTO
                return;

                /*" -761- END-IF. */
            }


            /*" -763- PERFORM R0080-00-GERAR-HEADER */

            R0080_00_GERAR_HEADER_SECTION();

            /*" -766- PERFORM R0150-00-PROCESSAR-MOVIMENTO UNTIL W-FIM-MOVTO-VGAP EQUAL 'FIM' . */

            while (!(WAREA_AUXILIAR.W_FIM_MOVTO_VGAP == "FIM"))
            {

                R0150_00_PROCESSAR_MOVIMENTO_SECTION();
            }

            /*" -768- PERFORM R1000-00-GERAR-TRAILLER. */

            R1000_00_GERAR_TRAILLER_SECTION();

            /*" -770- PERFORM R1050-00-CONTROLAR-ARQ-ENVIADO */

            R1050_00_CONTROLAR_ARQ_ENVIADO_SECTION();

            /*" -770- PERFORM R0880-00-UPDATE-RELATORIOS. */

            R0880_00_UPDATE_RELATORIOS_SECTION();

        }

        [StopWatch]
        /*" M-0000-CONTINUA-PRINCIPAL */
        private void M_0000_CONTINUA_PRINCIPAL(bool isPerform = false)
        {
            /*" -776- PERFORM R5050-00-SELECIONA-BILHETE */

            R5050_00_SELECIONA_BILHETE_SECTION();

            /*" -778- PERFORM R5070-00-LER-BILHETE */

            R5070_00_LER_BILHETE_SECTION();

            /*" -781- PERFORM R5150-00-PROCESSAR-BILHETE UNTIL W-FIM-CURSOR-BILHETE EQUAL 'FIM' . */

            while (!(WAREA_AUXILIAR.W_FIM_CURSOR_BILHETE == "FIM"))
            {

                R5150_00_PROCESSAR_BILHETE_SECTION();
            }

            /*" -785- PERFORM R9988-00-FECHAR-ARQUIVOS. */

            R9988_00_FECHAR_ARQUIVOS_SECTION();

            /*" -787- PERFORM R1100-00-GERAR-TOTAIS. */

            R1100_00_GERAR_TOTAIS_SECTION();

            /*" -787- PERFORM R9999-00-FINALIZAR. */

            R9999_00_FINALIZAR_SECTION();

        }

        [StopWatch]
        /*" R0005-00-OBTER-DATA-DIA-SECTION */
        private void R0005_00_OBTER_DATA_DIA_SECTION()
        {
            /*" -795- MOVE 'R0005-00-OBTER-DATA-DIA' TO PARAGRAFO. */
            _.Move("R0005-00-OBTER-DATA-DIA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -797- MOVE 'SELECT SEGUROS.SISTEMAS' TO COMANDO. */
            _.Move("SELECT SEGUROS.SISTEMAS", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -801- MOVE 'VA' TO SISTEMAS-IDE-SISTEMA OF DCLSISTEMAS. */
            _.Move("VA", SISTEMAS.DCLSISTEMAS.SISTEMAS_IDE_SISTEMA);

            /*" -802- ACCEPT WS-HORA-INI FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_INI);

            /*" -805- COMPUTE SIT = (HI * 60 * 60) + (MI * 60) + SI + (DI / 100) */
            WS_HORAS.SIT.Value = (WS_HORAS.WS_HORA_INI_R.HI * 60 * 60) + (WS_HORAS.WS_HORA_INI_R.MI * 60) + WS_HORAS.WS_HORA_INI_R.SI + (WS_HORAS.WS_HORA_INI_R.DI / 100f);

            /*" -811- PERFORM R0005_00_OBTER_DATA_DIA_DB_SELECT_1 */

            R0005_00_OBTER_DATA_DIA_DB_SELECT_1();

            /*" -815- ACCEPT WS-HORA-FIM FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_FIM);

            /*" -816- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF + (DF / 100) */
            WS_HORAS.SFT.Value = (WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (WS_HORAS.WS_HORA_FIM_R.MF * 60) + WS_HORAS.WS_HORA_FIM_R.SF + (WS_HORAS.WS_HORA_FIM_R.DF / 100f);

            /*" -817- SUBTRACT SIT FROM SFT */
            WS_HORAS.SFT.Value = WS_HORAS.SFT - WS_HORAS.SIT;

            /*" -818- ADD SFT TO STT(01) */
            TOTAIS_ROT.FILLER_20[01].STT.Value = TOTAIS_ROT.FILLER_20[01].STT + WS_HORAS.SFT;

            /*" -821- ADD 1 TO SQT(01) */
            TOTAIS_ROT.FILLER_20[01].SQT.Value = TOTAIS_ROT.FILLER_20[01].SQT + 1;

            /*" -824- MOVE SISTEMAS-DATA-MOV-ABERTO OF DCLSISTEMAS TO W-DTMOVABE. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, WAREA_AUXILIAR.W_DTMOVABE);

            /*" -826- MOVE W-DIA-MOVABE OF W-DTMOVABE1 TO W-DIA-MOVABE OF W-DTMOVABE-I1. */
            _.Move(WAREA_AUXILIAR.W_DTMOVABE1.W_DIA_MOVABE, WAREA_AUXILIAR.W_DTMOVABE_I1.W_DIA_MOVABE_0);

            /*" -828- MOVE W-MES-MOVABE OF W-DTMOVABE1 TO W-MES-MOVABE OF W-DTMOVABE-I1. */
            _.Move(WAREA_AUXILIAR.W_DTMOVABE1.W_MES_MOVABE, WAREA_AUXILIAR.W_DTMOVABE_I1.W_MES_MOVABE_0);

            /*" -831- MOVE W-ANO-MOVABE OF W-DTMOVABE1 TO W-ANO-MOVABE OF W-DTMOVABE-I1. */
            _.Move(WAREA_AUXILIAR.W_DTMOVABE1.W_ANO_MOVABE, WAREA_AUXILIAR.W_DTMOVABE_I1.W_ANO_MOVABE_0);

            /*" -833- MOVE '-' TO W-BARRA1 OF W-DTMOVABE-I1, W-BARRA2 OF W-DTMOVABE-I1. */
            _.Move("-", WAREA_AUXILIAR.W_DTMOVABE_I1.W_BARRA1_0);
            _.Move("-", WAREA_AUXILIAR.W_DTMOVABE_I1.W_BARRA2_0);


        }

        [StopWatch]
        /*" R0005-00-OBTER-DATA-DIA-DB-SELECT-1 */
        public void R0005_00_OBTER_DATA_DIA_DB_SELECT_1()
        {
            /*" -811- EXEC SQL SELECT DATA_MOV_ABERTO INTO :DCLSISTEMAS.SISTEMAS-DATA-MOV-ABERTO FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = :DCLSISTEMAS.SISTEMAS-IDE-SISTEMA WITH UR END-EXEC. */

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
        /*" R0007-00-OBTER-DT-PROCE-SECTION */
        private void R0007_00_OBTER_DT_PROCE_SECTION()
        {
            /*" -843- MOVE 'R0007-00-OBTER-DT-PROCE' TO PARAGRAFO. */
            _.Move("R0007-00-OBTER-DT-PROCE", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -845- MOVE 'SELECT SEGUROS.RELATORIOS' TO COMANDO. */
            _.Move("SELECT SEGUROS.RELATORIOS", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -848- MOVE 'PF0619B' TO RELATORI-COD-RELATORIO OF DCLRELATORIOS. */
            _.Move("PF0619B", RELATORI.DCLRELATORIOS.RELATORI_COD_RELATORIO);

            /*" -852- MOVE 'PF' TO RELATORI-IDE-SISTEMA OF DCLRELATORIOS. */
            _.Move("PF", RELATORI.DCLRELATORIOS.RELATORI_IDE_SISTEMA);

            /*" -853- ACCEPT WS-HORA-INI FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_INI);

            /*" -856- COMPUTE SIT = (HI * 60 * 60) + (MI * 60) + SI + (DI / 100) */
            WS_HORAS.SIT.Value = (WS_HORAS.WS_HORA_INI_R.HI * 60 * 60) + (WS_HORAS.WS_HORA_INI_R.MI * 60) + WS_HORAS.WS_HORA_INI_R.SI + (WS_HORAS.WS_HORA_INI_R.DI / 100f);

            /*" -865- PERFORM R0007_00_OBTER_DT_PROCE_DB_SELECT_1 */

            R0007_00_OBTER_DT_PROCE_DB_SELECT_1();

            /*" -869- ACCEPT WS-HORA-FIM FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_FIM);

            /*" -870- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF + (DF / 100) */
            WS_HORAS.SFT.Value = (WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (WS_HORAS.WS_HORA_FIM_R.MF * 60) + WS_HORAS.WS_HORA_FIM_R.SF + (WS_HORAS.WS_HORA_FIM_R.DF / 100f);

            /*" -871- SUBTRACT SIT FROM SFT */
            WS_HORAS.SFT.Value = WS_HORAS.SFT - WS_HORAS.SIT;

            /*" -872- ADD SFT TO STT(02) */
            TOTAIS_ROT.FILLER_20[02].STT.Value = TOTAIS_ROT.FILLER_20[02].STT + WS_HORAS.SFT;

            /*" -875- ADD 1 TO SQT(02) */
            TOTAIS_ROT.FILLER_20[02].SQT.Value = TOTAIS_ROT.FILLER_20[02].SQT + 1;

            /*" -876- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -877- DISPLAY 'PF0619B - FIM ANORMAL' */
                _.Display($"PF0619B - FIM ANORMAL");

                /*" -878- DISPLAY '          ERRO SELECT RELATORIOS' */
                _.Display($"          ERRO SELECT RELATORIOS");

                /*" -880- DISPLAY '          SQLCODE........................ ' SQLCODE */
                _.Display($"          SQLCODE........................ {DB.SQLCODE}");

                /*" -880- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R0007-00-OBTER-DT-PROCE-DB-SELECT-1 */
        public void R0007_00_OBTER_DT_PROCE_DB_SELECT_1()
        {
            /*" -865- EXEC SQL SELECT DATA_REFERENCIA INTO :DCLRELATORIOS.RELATORI-DATA-REFERENCIA FROM SEGUROS.RELATORIOS WHERE IDE_SISTEMA = :DCLRELATORIOS.RELATORI-IDE-SISTEMA AND COD_RELATORIO = :DCLRELATORIOS.RELATORI-COD-RELATORIO WITH UR END-EXEC. */

            var r0007_00_OBTER_DT_PROCE_DB_SELECT_1_Query1 = new R0007_00_OBTER_DT_PROCE_DB_SELECT_1_Query1()
            {
                RELATORI_COD_RELATORIO = RELATORI.DCLRELATORIOS.RELATORI_COD_RELATORIO.ToString(),
                RELATORI_IDE_SISTEMA = RELATORI.DCLRELATORIOS.RELATORI_IDE_SISTEMA.ToString(),
            };

            var executed_1 = R0007_00_OBTER_DT_PROCE_DB_SELECT_1_Query1.Execute(r0007_00_OBTER_DT_PROCE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.RELATORI_DATA_REFERENCIA, RELATORI.DCLRELATORIOS.RELATORI_DATA_REFERENCIA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0007_SAIDA*/

        [StopWatch]
        /*" R0010-00-ABRIR-ARQUIVOS-SECTION */
        private void R0010_00_ABRIR_ARQUIVOS_SECTION()
        {
            /*" -890- MOVE 'R0010-00-ABRIR-ARQUIVOS' TO PARAGRAFO. */
            _.Move("R0010-00-ABRIR-ARQUIVOS", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -892- MOVE 'OPEN' TO COMANDO. */
            _.Move("OPEN", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -892- OPEN OUTPUT MOVTO-PRP-SASSE. */
            MOVTO_PRP_SASSE.Open(REG_PRP_SASSE);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0010_SAIDA*/

        [StopWatch]
        /*" R0020-00-OBTER-MAX-NSAS-SECTION */
        private void R0020_00_OBTER_MAX_NSAS_SECTION()
        {
            /*" -902- MOVE 'R0020-00-OBTER-MAX-NSAS' TO PARAGRAFO. */
            _.Move("R0020-00-OBTER-MAX-NSAS", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -905- MOVE 'SELECT MAX ARQUIVOS-SIVPF' TO COMANDO. */
            _.Move("SELECT MAX ARQUIVOS-SIVPF", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -906- ACCEPT WS-HORA-INI FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_INI);

            /*" -909- COMPUTE SIT = (HI * 60 * 60) + (MI * 60) + SI + (DI / 100) */
            WS_HORAS.SIT.Value = (WS_HORAS.WS_HORA_INI_R.HI * 60 * 60) + (WS_HORAS.WS_HORA_INI_R.MI * 60) + WS_HORAS.WS_HORA_INI_R.SI + (WS_HORAS.WS_HORA_INI_R.DI / 100f);

            /*" -916- PERFORM R0020_00_OBTER_MAX_NSAS_DB_SELECT_1 */

            R0020_00_OBTER_MAX_NSAS_DB_SELECT_1();

            /*" -920- ACCEPT WS-HORA-FIM FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_FIM);

            /*" -921- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF + (DF / 100) */
            WS_HORAS.SFT.Value = (WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (WS_HORAS.WS_HORA_FIM_R.MF * 60) + WS_HORAS.WS_HORA_FIM_R.SF + (WS_HORAS.WS_HORA_FIM_R.DF / 100f);

            /*" -922- SUBTRACT SIT FROM SFT */
            WS_HORAS.SFT.Value = WS_HORAS.SFT - WS_HORAS.SIT;

            /*" -923- ADD SFT TO STT(02) */
            TOTAIS_ROT.FILLER_20[02].STT.Value = TOTAIS_ROT.FILLER_20[02].STT + WS_HORAS.SFT;

            /*" -926- ADD 1 TO SQT(02) */
            TOTAIS_ROT.FILLER_20[02].SQT.Value = TOTAIS_ROT.FILLER_20[02].SQT + 1;

            /*" -927- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -928- DISPLAY 'PF0619B - FIM ANORMAL' */
                _.Display($"PF0619B - FIM ANORMAL");

                /*" -929- DISPLAY '          ERRO SELECT MAX ARQUIVOS-SIVPF' */
                _.Display($"          ERRO SELECT MAX ARQUIVOS-SIVPF");

                /*" -931- DISPLAY '          SQLCODE........................ ' SQLCODE */
                _.Display($"          SQLCODE........................ {DB.SQLCODE}");

                /*" -932- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -934- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


            /*" -937- MOVE ARQSIVPF-NSAS-SIVPF OF DCLARQUIVOS-SIVPF TO W-NSAS. */
            _.Move(ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF, WAREA_AUXILIAR.W_NSAS);

            /*" -939- ADD 1 TO W-NSAS. */
            WAREA_AUXILIAR.W_NSAS.Value = WAREA_AUXILIAR.W_NSAS + 1;

            /*" -939- MOVE W-NSAS TO ARQSIVPF-NSAS-SIVPF OF DCLARQUIVOS-SIVPF. */
            _.Move(WAREA_AUXILIAR.W_NSAS, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF);

        }

        [StopWatch]
        /*" R0020-00-OBTER-MAX-NSAS-DB-SELECT-1 */
        public void R0020_00_OBTER_MAX_NSAS_DB_SELECT_1()
        {
            /*" -916- EXEC SQL SELECT VALUE(MAX(NSAS_SIVPF),0) INTO :DCLARQUIVOS-SIVPF.ARQSIVPF-NSAS-SIVPF FROM SEGUROS.ARQUIVOS_SIVPF WHERE SIGLA_ARQUIVO = 'PRPSASSE' AND SISTEMA_ORIGEM = 4 WITH UR END-EXEC. */

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
            /*" -949- MOVE 'R0050-00-SELECIONA-MOVTO' TO PARAGRAFO. */
            _.Move("R0050-00-SELECIONA-MOVTO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -951- MOVE 'DECLARE MOVIMENTO' TO COMANDO. */
            _.Move("DECLARE MOVIMENTO", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -952- ACCEPT W-TIME FROM TIME. */
            _.Move(_.AcceptDate("TIME"), WAREA_AUXILIAR.W_TIME);

            /*" -954- MOVE W-TIME TO W-TIME-EDIT. */
            _.Move(WAREA_AUXILIAR.W_TIME, WAREA_AUXILIAR.W_TIME_EDIT);

            /*" -955- DISPLAY '************************************************' . */
            _.Display($"************************************************");

            /*" -959- DISPLAY '** PF0619B ** INICIO DECLARE V0PROPOSTAVA..  ' W-TIME-EDIT. */
            _.Display($"** PF0619B ** INICIO DECLARE V0PROPOSTAVA..  {WAREA_AUXILIAR.W_TIME_EDIT}");

            /*" -960- ACCEPT WS-HORA-INI FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_INI);

            /*" -963- COMPUTE SIT = (HI * 60 * 60) + (MI * 60) + SI + (DI / 100) */
            WS_HORAS.SIT.Value = (WS_HORAS.WS_HORA_INI_R.HI * 60 * 60) + (WS_HORAS.WS_HORA_INI_R.MI * 60) + WS_HORAS.WS_HORA_INI_R.SI + (WS_HORAS.WS_HORA_INI_R.DI / 100f);

            /*" -1028- PERFORM R0050_00_SELECIONA_MOVTO_DB_DECLARE_1 */

            R0050_00_SELECIONA_MOVTO_DB_DECLARE_1();

            /*" -1032- ACCEPT WS-HORA-FIM FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_FIM);

            /*" -1033- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF + (DF / 100) */
            WS_HORAS.SFT.Value = (WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (WS_HORAS.WS_HORA_FIM_R.MF * 60) + WS_HORAS.WS_HORA_FIM_R.SF + (WS_HORAS.WS_HORA_FIM_R.DF / 100f);

            /*" -1034- SUBTRACT SIT FROM SFT */
            WS_HORAS.SFT.Value = WS_HORAS.SFT - WS_HORAS.SIT;

            /*" -1035- ADD SFT TO STT(03) */
            TOTAIS_ROT.FILLER_20[03].STT.Value = TOTAIS_ROT.FILLER_20[03].STT + WS_HORAS.SFT;

            /*" -1039- ADD 1 TO SQT(03) */
            TOTAIS_ROT.FILLER_20[03].SQT.Value = TOTAIS_ROT.FILLER_20[03].SQT + 1;

            /*" -1040- ACCEPT WS-HORA-INI FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_INI);

            /*" -1043- COMPUTE SIT = (HI * 60 * 60) + (MI * 60) + SI + (DI / 100) */
            WS_HORAS.SIT.Value = (WS_HORAS.WS_HORA_INI_R.HI * 60 * 60) + (WS_HORAS.WS_HORA_INI_R.MI * 60) + WS_HORAS.WS_HORA_INI_R.SI + (WS_HORAS.WS_HORA_INI_R.DI / 100f);

            /*" -1043- PERFORM R0050_00_SELECIONA_MOVTO_DB_OPEN_1 */

            R0050_00_SELECIONA_MOVTO_DB_OPEN_1();

            /*" -1047- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -1051- MOVE 2 TO W-CURSOR. */
                _.Move(2, WAREA_AUXILIAR.W_CURSOR);
            }


            /*" -1052- ACCEPT WS-HORA-FIM FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_FIM);

            /*" -1053- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF + (DF / 100) */
            WS_HORAS.SFT.Value = (WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (WS_HORAS.WS_HORA_FIM_R.MF * 60) + WS_HORAS.WS_HORA_FIM_R.SF + (WS_HORAS.WS_HORA_FIM_R.DF / 100f);

            /*" -1054- SUBTRACT SIT FROM SFT */
            WS_HORAS.SFT.Value = WS_HORAS.SFT - WS_HORAS.SIT;

            /*" -1055- ADD SFT TO STT(04) */
            TOTAIS_ROT.FILLER_20[04].STT.Value = TOTAIS_ROT.FILLER_20[04].STT + WS_HORAS.SFT;

            /*" -1058- ADD 1 TO SQT(04) */
            TOTAIS_ROT.FILLER_20[04].SQT.Value = TOTAIS_ROT.FILLER_20[04].SQT + 1;

            /*" -1059- ACCEPT W-TIME FROM TIME. */
            _.Move(_.AcceptDate("TIME"), WAREA_AUXILIAR.W_TIME);

            /*" -1061- MOVE W-TIME TO W-TIME-EDIT. */
            _.Move(WAREA_AUXILIAR.W_TIME, WAREA_AUXILIAR.W_TIME_EDIT);

            /*" -1063- DISPLAY '** PF0619B ** FIM    DECLARE V0PROPOSTAVA..  ' W-TIME-EDIT */
            _.Display($"** PF0619B ** FIM    DECLARE V0PROPOSTAVA..  {WAREA_AUXILIAR.W_TIME_EDIT}");

            /*" -1064- DISPLAY '************************************************' . */
            _.Display($"************************************************");

            /*" -1064- DISPLAY ' ' . */
            _.Display($" ");

        }

        [StopWatch]
        /*" R0050-00-SELECIONA-MOVTO-DB-DECLARE-1 */
        public void R0050_00_SELECIONA_MOVTO_DB_DECLARE_1()
        {
            /*" -1028- EXEC SQL DECLARE PROPOSTAS-VA CURSOR FOR SELECT B.NUM_CERTIFICADO , B.COD_PRODUTO , B.COD_CLIENTE , B.OCOREND , B.COD_FONTE , B.AGE_COBRANCA , B.OPCAO_COBERTURA , B.DATA_QUITACAO , B.COD_AGE_VENDEDOR , B.OPE_CONTA_VENDEDOR, B.NUM_CONTA_VENDEDOR, B.DIG_CONTA_VENDEDOR, B.NUM_MATRI_VENDEDOR, B.COD_OPERACAO , B.PROFISSAO , B.DTINCLUS , B.DATA_MOVIMENTO , B.SIT_REGISTRO , B.NUM_APOLICE , B.COD_SUBGRUPO , B.OCORR_HISTORICO , B.NRPRIPARATZ , B.QTDPARATZ , B.DTPROXVEN , B.NUM_PARCELA , B.DATA_VENCIMENTO , B.SIT_INTERFACE , B.DTFENAE , B.COD_USUARIO , B.IDADE , B.IDE_SEXO , B.ESTADO_CIVIL , B.APOS_INVALIDEZ , B.NOME_ESPOSA , B.DTNASC_ESPOSA , B.PROFIS_ESPOSA , B.DPS_TITULAR , B.DPS_ESPOSA , B.GRAU_PARENTESCO , B.NUM_PROPOSTA , B.INFO_COMPLEMENTAR , B.COD_CCT , B.FAIXA_RENDA_IND , B.FAIXA_RENDA_FAM , B.COD_ORIGEM_PROPOSTA FROM SEGUROS.PRODUTOS_VG A, SEGUROS.PROPOSTAS_VA B WHERE B.NUM_APOLICE = A.NUM_APOLICE AND B.COD_SUBGRUPO = A.COD_SUBGRUPO AND A.COD_PRODUTO NOT IN (9913, 7708, 9341, 9350, 9348) AND A.ESTR_EMISS = 'MULT' AND A.ORIG_PRODU IN ( 'MULT' , 'VIDAZUL' , 'CAMP' ) AND B.DATA_MOVIMENTO >= :DCLRELATORIOS.RELATORI-DATA-REFERENCIA AND B.DATA_MOVIMENTO <= :DCLSISTEMAS.SISTEMAS-DATA-MOV-ABERTO AND B.SIT_REGISTRO = '2' ORDER BY B.DATA_MOVIMENTO WITH UR END-EXEC. */
            PROPOSTAS_VA = new PF0619B_PROPOSTAS_VA(true);
            string GetQuery_PROPOSTAS_VA()
            {
                var query = @$"SELECT B.NUM_CERTIFICADO
							, 
							B.COD_PRODUTO
							, 
							B.COD_CLIENTE
							, 
							B.OCOREND
							, 
							B.COD_FONTE
							, 
							B.AGE_COBRANCA
							, 
							B.OPCAO_COBERTURA
							, 
							B.DATA_QUITACAO
							, 
							B.COD_AGE_VENDEDOR
							, 
							B.OPE_CONTA_VENDEDOR
							, 
							B.NUM_CONTA_VENDEDOR
							, 
							B.DIG_CONTA_VENDEDOR
							, 
							B.NUM_MATRI_VENDEDOR
							, 
							B.COD_OPERACAO
							, 
							B.PROFISSAO
							, 
							B.DTINCLUS
							, 
							B.DATA_MOVIMENTO
							, 
							B.SIT_REGISTRO
							, 
							B.NUM_APOLICE
							, 
							B.COD_SUBGRUPO
							, 
							B.OCORR_HISTORICO
							, 
							B.NRPRIPARATZ
							, 
							B.QTDPARATZ
							, 
							B.DTPROXVEN
							, 
							B.NUM_PARCELA
							, 
							B.DATA_VENCIMENTO
							, 
							B.SIT_INTERFACE
							, 
							B.DTFENAE
							, 
							B.COD_USUARIO
							, 
							B.IDADE
							, 
							B.IDE_SEXO
							, 
							B.ESTADO_CIVIL
							, 
							B.APOS_INVALIDEZ
							, 
							B.NOME_ESPOSA
							, 
							B.DTNASC_ESPOSA
							, 
							B.PROFIS_ESPOSA
							, 
							B.DPS_TITULAR
							, 
							B.DPS_ESPOSA
							, 
							B.GRAU_PARENTESCO
							, 
							B.NUM_PROPOSTA
							, 
							B.INFO_COMPLEMENTAR
							, 
							B.COD_CCT
							, 
							B.FAIXA_RENDA_IND
							, 
							B.FAIXA_RENDA_FAM
							, 
							B.COD_ORIGEM_PROPOSTA 
							FROM SEGUROS.PRODUTOS_VG A
							, 
							SEGUROS.PROPOSTAS_VA B 
							WHERE B.NUM_APOLICE = A.NUM_APOLICE 
							AND B.COD_SUBGRUPO = A.COD_SUBGRUPO 
							AND A.COD_PRODUTO NOT IN 
							(9913
							, 7708
							, 9341
							, 9350
							, 9348) 
							AND A.ESTR_EMISS = 'MULT' 
							AND A.ORIG_PRODU IN 
							( 'MULT'
							, 'VIDAZUL'
							, 'CAMP' ) 
							AND B.DATA_MOVIMENTO >= 
							'{RELATORI.DCLRELATORIOS.RELATORI_DATA_REFERENCIA}' 
							AND B.DATA_MOVIMENTO <= 
							'{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}' 
							AND B.SIT_REGISTRO = '2' 
							ORDER BY B.DATA_MOVIMENTO";

                return query;
            }
            PROPOSTAS_VA.GetQueryEvent += GetQuery_PROPOSTAS_VA;

        }

        [StopWatch]
        /*" R0050-00-SELECIONA-MOVTO-DB-OPEN-1 */
        public void R0050_00_SELECIONA_MOVTO_DB_OPEN_1()
        {
            /*" -1043- EXEC SQL OPEN PROPOSTAS-VA END-EXEC. */

            PROPOSTAS_VA.Open();

        }

        [StopWatch]
        /*" R0410-00-LER-CBO-DB-DECLARE-1 */
        public void R0410_00_LER_CBO_DB_DECLARE_1()
        {
            /*" -1681- EXEC SQL DECLARE C01_CBO CURSOR FOR SELECT COD_CBO, DESCR_CBO FROM SEGUROS.CBO WHERE DESCR_CBO = :DCLCBO.CBO-DESCR-CBO ORDER BY COD_CBO WITH UR END-EXEC */
            C01_CBO = new PF0619B_C01_CBO(true);
            string GetQuery_C01_CBO()
            {
                var query = @$"SELECT COD_CBO
							, 
							DESCR_CBO 
							FROM SEGUROS.CBO 
							WHERE DESCR_CBO = '{CBO.DCLCBO.CBO_DESCR_CBO}' 
							ORDER BY COD_CBO";

                return query;
            }
            C01_CBO.GetQueryEvent += GetQuery_C01_CBO;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0050_SAIDA*/

        [StopWatch]
        /*" R0070-00-LER-MOVTO-SECTION */
        private void R0070_00_LER_MOVTO_SECTION()
        {
            /*" -1074- MOVE 'R0070-00-LER-MOVTO' TO PARAGRAFO. */
            _.Move("R0070-00-LER-MOVTO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1077- MOVE 'FETCH PROPOSTAS-VA' TO COMANDO. */
            _.Move("FETCH PROPOSTAS-VA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1078- ACCEPT WS-HORA-INI FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_INI);

            /*" -1081- COMPUTE SIT = (HI * 60 * 60) + (MI * 60) + SI + (DI / 100) */
            WS_HORAS.SIT.Value = (WS_HORAS.WS_HORA_INI_R.HI * 60 * 60) + (WS_HORAS.WS_HORA_INI_R.MI * 60) + WS_HORAS.WS_HORA_INI_R.SI + (WS_HORAS.WS_HORA_INI_R.DI / 100f);

            /*" -1131- PERFORM R0070_00_LER_MOVTO_DB_FETCH_1 */

            R0070_00_LER_MOVTO_DB_FETCH_1();

            /*" -1135- ACCEPT WS-HORA-FIM FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_FIM);

            /*" -1136- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF + (DF / 100) */
            WS_HORAS.SFT.Value = (WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (WS_HORAS.WS_HORA_FIM_R.MF * 60) + WS_HORAS.WS_HORA_FIM_R.SF + (WS_HORAS.WS_HORA_FIM_R.DF / 100f);

            /*" -1137- SUBTRACT SIT FROM SFT */
            WS_HORAS.SFT.Value = WS_HORAS.SFT - WS_HORAS.SIT;

            /*" -1138- ADD SFT TO STT(05) */
            TOTAIS_ROT.FILLER_20[05].STT.Value = TOTAIS_ROT.FILLER_20[05].STT + WS_HORAS.SFT;

            /*" -1141- ADD 1 TO SQT(05) */
            TOTAIS_ROT.FILLER_20[05].SQT.Value = TOTAIS_ROT.FILLER_20[05].SQT + 1;

            /*" -1142- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -1143- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1144- MOVE 'FIM' TO W-FIM-MOVTO-VGAP */
                    _.Move("FIM", WAREA_AUXILIAR.W_FIM_MOVTO_VGAP);

                    /*" -1144- PERFORM R0070_00_LER_MOVTO_DB_CLOSE_1 */

                    R0070_00_LER_MOVTO_DB_CLOSE_1();

                    /*" -1146- ELSE */
                }
                else
                {


                    /*" -1147- DISPLAY 'PF0619B - FIM ANORMAL' */
                    _.Display($"PF0619B - FIM ANORMAL");

                    /*" -1149- DISPLAY '          ERRO FETCH CURSOR PROPOSTAS-VA  ' SQLCODE */
                    _.Display($"          ERRO FETCH CURSOR PROPOSTAS-VA  {DB.SQLCODE}");

                    /*" -1150- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -1151- PERFORM R9999-00-FINALIZAR */

                    R9999_00_FINALIZAR_SECTION();

                    /*" -1152- ELSE */
                }

            }
            else
            {


                /*" -1155- ADD 1 TO W-NSL, W-CONTROLE */
                WAREA_AUXILIAR.W_NSL.Value = WAREA_AUXILIAR.W_NSL + 1;
                WAREA_AUXILIAR.W_CONTROLE.Value = WAREA_AUXILIAR.W_CONTROLE + 1;

                /*" -1156- IF VIND-INFO-COMP LESS ZEROS */

                if (VIND_INFO_COMP < 00)
                {

                    /*" -1157- MOVE 0 TO W-INF-COMPLEMENTAR */
                    _.Move(0, WAREA_AUXILIAR.W_INF_COMPLEMENTAR);

                    /*" -1158- ELSE */
                }
                else
                {


                    /*" -1159- MOVE 1 TO W-INF-COMPLEMENTAR */
                    _.Move(1, WAREA_AUXILIAR.W_INF_COMPLEMENTAR);

                    /*" -1161- END-IF */
                }


                /*" -1162- IF W-CONTROLE > 999 */

                if (WAREA_AUXILIAR.W_CONTROLE > 999)
                {

                    /*" -1163- ACCEPT W-TIME FROM TIME */
                    _.Move(_.AcceptDate("TIME"), WAREA_AUXILIAR.W_TIME);

                    /*" -1164- MOVE W-TIME TO W-TIME-EDIT */
                    _.Move(WAREA_AUXILIAR.W_TIME, WAREA_AUXILIAR.W_TIME_EDIT);

                    /*" -1165- MOVE ZEROS TO W-CONTROLE */
                    _.Move(0, WAREA_AUXILIAR.W_CONTROLE);

                    /*" -1166- DISPLAY ' ' */
                    _.Display($" ");

                    /*" -1167- DISPLAY '** PF0619B ** TOTAL LIDO ..  ' W-NSL */
                    _.Display($"** PF0619B ** TOTAL LIDO ..  {WAREA_AUXILIAR.W_NSL}");

                    /*" -1168- DISPLAY '** PF0619B ** HORA.........  ' W-TIME-EDIT */
                    _.Display($"** PF0619B ** HORA.........  {WAREA_AUXILIAR.W_TIME_EDIT}");

                    /*" -1169- DISPLAY ' ' */
                    _.Display($" ");

                    /*" -1171- END-IF */
                }


                /*" -1174- COMPUTE RT-QTDE-TOTAL OF REG-TRAILLER = W-QTD-LD-TIPO-1 + W-QTD-LD-TIPO-2 + W-QTD-LD-TIPO-3 + W-QTD-LD-TIPO-4 + W-QTD-LD-TIPO-5. */
                LBFPF991.REG_TRAILLER.RT_QTDE_TOTAL.Value = WAREA_AUXILIAR.W_QTD_LD_TIPO_1 + WAREA_AUXILIAR.W_QTD_LD_TIPO_2 + WAREA_AUXILIAR.W_QTD_LD_TIPO_3 + WAREA_AUXILIAR.W_QTD_LD_TIPO_4 + WAREA_AUXILIAR.W_QTD_LD_TIPO_5;
            }


        }

        [StopWatch]
        /*" R0070-00-LER-MOVTO-DB-FETCH-1 */
        public void R0070_00_LER_MOVTO_DB_FETCH_1()
        {
            /*" -1131- EXEC SQL FETCH PROPOSTAS-VA INTO :DCLPROPOSTAS-VA.NUM-CERTIFICADO , :DCLPROPOSTAS-VA.COD-PRODUTO , :DCLPROPOSTAS-VA.COD-CLIENTE , :DCLPROPOSTAS-VA.OCOREND , :DCLPROPOSTAS-VA.COD-FONTE , :DCLPROPOSTAS-VA.AGE-COBRANCA , :DCLPROPOSTAS-VA.OPCAO-COBERTURA , :DCLPROPOSTAS-VA.DATA-QUITACAO , :DCLPROPOSTAS-VA.COD-AGE-VENDEDOR , :DCLPROPOSTAS-VA.OPE-CONTA-VENDEDOR, :DCLPROPOSTAS-VA.NUM-CONTA-VENDEDOR, :DCLPROPOSTAS-VA.DIG-CONTA-VENDEDOR, :DCLPROPOSTAS-VA.NUM-MATRI-VENDEDOR, :DCLPROPOSTAS-VA.COD-OPERACAO , :DCLPROPOSTAS-VA.PROFISSAO , :DCLPROPOSTAS-VA.DTINCLUS , :DCLPROPOSTAS-VA.DATA-MOVIMENTO , :DCLPROPOSTAS-VA.SIT-REGISTRO , :DCLPROPOSTAS-VA.NUM-APOLICE , :DCLPROPOSTAS-VA.COD-SUBGRUPO , :DCLPROPOSTAS-VA.OCORR-HISTORICO , :DCLPROPOSTAS-VA.NRPRIPARATZ , :DCLPROPOSTAS-VA.QTDPARATZ , :DCLPROPOSTAS-VA.DTPROXVEN , :DCLPROPOSTAS-VA.NUM-PARCELA , :DCLPROPOSTAS-VA.DATA-VENCIMENTO , :DCLPROPOSTAS-VA.SIT-INTERFACE , :DCLPROPOSTAS-VA.DTFENAE , :DCLPROPOSTAS-VA.COD-USUARIO , :DCLPROPOSTAS-VA.IDADE , :DCLPROPOSTAS-VA.IDE-SEXO , :DCLPROPOSTAS-VA.ESTADO-CIVIL , :DCLPROPOSTAS-VA.APOS-INVALIDEZ:VIND-APOS-INVALIDEZ, :DCLPROPOSTAS-VA.NOME-ESPOSA:VIND-NOME-ESPOSA, :DCLPROPOSTAS-VA.DTNASC-ESPOSA:VIND-DTNASC-ESPOSA, :DCLPROPOSTAS-VA.PROFIS-ESPOSA:VIND-PROFIS-ESPOSA, :DCLPROPOSTAS-VA.DPS-TITULAR:VIND-DPS-TITULAR, :DCLPROPOSTAS-VA.DPS-ESPOSA:VIND-DPS-ESPOSA, :DCLPROPOSTAS-VA.GRAU-PARENTESCO:VIND-GRAU-PAREN, :DCLPROPOSTAS-VA.NUM-PROPOSTA:VIND-NUM-PROPOSTA, :DCLPROPOSTAS-VA.INFO-COMPLEMENTAR:VIND-INFO-COMP, :DCLPROPOSTAS-VA.COD-CCT:VIND-COD-CCT, :DCLPROPOSTAS-VA.FAIXA-RENDA-IND :VIND-FAIXA-RENDA-IND, :DCLPROPOSTAS-VA.FAIXA-RENDA-FAM :VIND-FAIXA-RENDA-FAM, :DCLPROPOSTAS-VA.COD-ORIGEM-PROPOSTA :VIND-COD-ORIGEM-PROP END-EXEC. */

            if (PROPOSTAS_VA.Fetch())
            {
                _.Move(PROPOSTAS_VA.DCLPROPOSTAS_VA_NUM_CERTIFICADO, PROPVA.DCLPROPOSTAS_VA.NUM_CERTIFICADO);
                _.Move(PROPOSTAS_VA.DCLPROPOSTAS_VA_COD_PRODUTO, PROPVA.DCLPROPOSTAS_VA.COD_PRODUTO);
                _.Move(PROPOSTAS_VA.DCLPROPOSTAS_VA_COD_CLIENTE, PROPVA.DCLPROPOSTAS_VA.COD_CLIENTE);
                _.Move(PROPOSTAS_VA.DCLPROPOSTAS_VA_OCOREND, PROPVA.DCLPROPOSTAS_VA.OCOREND);
                _.Move(PROPOSTAS_VA.DCLPROPOSTAS_VA_COD_FONTE, PROPVA.DCLPROPOSTAS_VA.COD_FONTE);
                _.Move(PROPOSTAS_VA.DCLPROPOSTAS_VA_AGE_COBRANCA, PROPVA.DCLPROPOSTAS_VA.AGE_COBRANCA);
                _.Move(PROPOSTAS_VA.DCLPROPOSTAS_VA_OPCAO_COBERTURA, PROPVA.DCLPROPOSTAS_VA.OPCAO_COBERTURA);
                _.Move(PROPOSTAS_VA.DCLPROPOSTAS_VA_DATA_QUITACAO, PROPVA.DCLPROPOSTAS_VA.DATA_QUITACAO);
                _.Move(PROPOSTAS_VA.DCLPROPOSTAS_VA_COD_AGE_VENDEDOR, PROPVA.DCLPROPOSTAS_VA.COD_AGE_VENDEDOR);
                _.Move(PROPOSTAS_VA.DCLPROPOSTAS_VA_OPE_CONTA_VENDEDOR, PROPVA.DCLPROPOSTAS_VA.OPE_CONTA_VENDEDOR);
                _.Move(PROPOSTAS_VA.DCLPROPOSTAS_VA_NUM_CONTA_VENDEDOR, PROPVA.DCLPROPOSTAS_VA.NUM_CONTA_VENDEDOR);
                _.Move(PROPOSTAS_VA.DCLPROPOSTAS_VA_DIG_CONTA_VENDEDOR, PROPVA.DCLPROPOSTAS_VA.DIG_CONTA_VENDEDOR);
                _.Move(PROPOSTAS_VA.DCLPROPOSTAS_VA_NUM_MATRI_VENDEDOR, PROPVA.DCLPROPOSTAS_VA.NUM_MATRI_VENDEDOR);
                _.Move(PROPOSTAS_VA.DCLPROPOSTAS_VA_COD_OPERACAO, PROPVA.DCLPROPOSTAS_VA.COD_OPERACAO);
                _.Move(PROPOSTAS_VA.DCLPROPOSTAS_VA_PROFISSAO, PROPVA.DCLPROPOSTAS_VA.PROFISSAO);
                _.Move(PROPOSTAS_VA.DCLPROPOSTAS_VA_DTINCLUS, PROPVA.DCLPROPOSTAS_VA.DTINCLUS);
                _.Move(PROPOSTAS_VA.DCLPROPOSTAS_VA_DATA_MOVIMENTO, PROPVA.DCLPROPOSTAS_VA.DATA_MOVIMENTO);
                _.Move(PROPOSTAS_VA.DCLPROPOSTAS_VA_SIT_REGISTRO, PROPVA.DCLPROPOSTAS_VA.SIT_REGISTRO);
                _.Move(PROPOSTAS_VA.DCLPROPOSTAS_VA_NUM_APOLICE, PROPVA.DCLPROPOSTAS_VA.NUM_APOLICE);
                _.Move(PROPOSTAS_VA.DCLPROPOSTAS_VA_COD_SUBGRUPO, PROPVA.DCLPROPOSTAS_VA.COD_SUBGRUPO);
                _.Move(PROPOSTAS_VA.DCLPROPOSTAS_VA_OCORR_HISTORICO, PROPVA.DCLPROPOSTAS_VA.OCORR_HISTORICO);
                _.Move(PROPOSTAS_VA.DCLPROPOSTAS_VA_NRPRIPARATZ, PROPVA.DCLPROPOSTAS_VA.NRPRIPARATZ);
                _.Move(PROPOSTAS_VA.DCLPROPOSTAS_VA_QTDPARATZ, PROPVA.DCLPROPOSTAS_VA.QTDPARATZ);
                _.Move(PROPOSTAS_VA.DCLPROPOSTAS_VA_DTPROXVEN, PROPVA.DCLPROPOSTAS_VA.DTPROXVEN);
                _.Move(PROPOSTAS_VA.DCLPROPOSTAS_VA_NUM_PARCELA, PROPVA.DCLPROPOSTAS_VA.NUM_PARCELA);
                _.Move(PROPOSTAS_VA.DCLPROPOSTAS_VA_DATA_VENCIMENTO, PROPVA.DCLPROPOSTAS_VA.DATA_VENCIMENTO);
                _.Move(PROPOSTAS_VA.DCLPROPOSTAS_VA_SIT_INTERFACE, PROPVA.DCLPROPOSTAS_VA.SIT_INTERFACE);
                _.Move(PROPOSTAS_VA.DCLPROPOSTAS_VA_DTFENAE, PROPVA.DCLPROPOSTAS_VA.DTFENAE);
                _.Move(PROPOSTAS_VA.DCLPROPOSTAS_VA_COD_USUARIO, PROPVA.DCLPROPOSTAS_VA.COD_USUARIO);
                _.Move(PROPOSTAS_VA.DCLPROPOSTAS_VA_IDADE, PROPVA.DCLPROPOSTAS_VA.IDADE);
                _.Move(PROPOSTAS_VA.DCLPROPOSTAS_VA_IDE_SEXO, PROPVA.DCLPROPOSTAS_VA.IDE_SEXO);
                _.Move(PROPOSTAS_VA.DCLPROPOSTAS_VA_ESTADO_CIVIL, PROPVA.DCLPROPOSTAS_VA.ESTADO_CIVIL);
                _.Move(PROPOSTAS_VA.DCLPROPOSTAS_VA_APOS_INVALIDEZ, PROPVA.DCLPROPOSTAS_VA.APOS_INVALIDEZ);
                _.Move(PROPOSTAS_VA.VIND_APOS_INVALIDEZ, VIND_APOS_INVALIDEZ);
                _.Move(PROPOSTAS_VA.DCLPROPOSTAS_VA_NOME_ESPOSA, PROPVA.DCLPROPOSTAS_VA.NOME_ESPOSA);
                _.Move(PROPOSTAS_VA.VIND_NOME_ESPOSA, VIND_NOME_ESPOSA);
                _.Move(PROPOSTAS_VA.DCLPROPOSTAS_VA_DTNASC_ESPOSA, PROPVA.DCLPROPOSTAS_VA.DTNASC_ESPOSA);
                _.Move(PROPOSTAS_VA.VIND_DTNASC_ESPOSA, VIND_DTNASC_ESPOSA);
                _.Move(PROPOSTAS_VA.DCLPROPOSTAS_VA_PROFIS_ESPOSA, PROPVA.DCLPROPOSTAS_VA.PROFIS_ESPOSA);
                _.Move(PROPOSTAS_VA.VIND_PROFIS_ESPOSA, VIND_PROFIS_ESPOSA);
                _.Move(PROPOSTAS_VA.DCLPROPOSTAS_VA_DPS_TITULAR, PROPVA.DCLPROPOSTAS_VA.DPS_TITULAR);
                _.Move(PROPOSTAS_VA.VIND_DPS_TITULAR, VIND_DPS_TITULAR);
                _.Move(PROPOSTAS_VA.DCLPROPOSTAS_VA_DPS_ESPOSA, PROPVA.DCLPROPOSTAS_VA.DPS_ESPOSA);
                _.Move(PROPOSTAS_VA.VIND_DPS_ESPOSA, VIND_DPS_ESPOSA);
                _.Move(PROPOSTAS_VA.DCLPROPOSTAS_VA_GRAU_PARENTESCO, PROPVA.DCLPROPOSTAS_VA.GRAU_PARENTESCO);
                _.Move(PROPOSTAS_VA.VIND_GRAU_PAREN, VIND_GRAU_PAREN);
                _.Move(PROPOSTAS_VA.DCLPROPOSTAS_VA_NUM_PROPOSTA, PROPVA.DCLPROPOSTAS_VA.NUM_PROPOSTA);
                _.Move(PROPOSTAS_VA.VIND_NUM_PROPOSTA, VIND_NUM_PROPOSTA);
                _.Move(PROPOSTAS_VA.DCLPROPOSTAS_VA_INFO_COMPLEMENTAR, PROPVA.DCLPROPOSTAS_VA.INFO_COMPLEMENTAR);
                _.Move(PROPOSTAS_VA.VIND_INFO_COMP, VIND_INFO_COMP);
                _.Move(PROPOSTAS_VA.DCLPROPOSTAS_VA_COD_CCT, PRODVG.DCLPRODUTOS_VG.COD_CCT);
                _.Move(PROPOSTAS_VA.VIND_COD_CCT, VIND_COD_CCT);
                _.Move(PROPOSTAS_VA.DCLPROPOSTAS_VA_FAIXA_RENDA_IND, PROPVA.DCLPROPOSTAS_VA.FAIXA_RENDA_IND);
                _.Move(PROPOSTAS_VA.VIND_FAIXA_RENDA_IND, VIND_FAIXA_RENDA_IND);
                _.Move(PROPOSTAS_VA.DCLPROPOSTAS_VA_FAIXA_RENDA_FAM, PROPVA.DCLPROPOSTAS_VA.FAIXA_RENDA_FAM);
                _.Move(PROPOSTAS_VA.VIND_FAIXA_RENDA_FAM, VIND_FAIXA_RENDA_FAM);
                _.Move(PROPOSTAS_VA.DCLPROPOSTAS_VA_COD_ORIGEM_PROPOSTA, PROPVA.DCLPROPOSTAS_VA.COD_ORIGEM_PROPOSTA);
                _.Move(PROPOSTAS_VA.VIND_COD_ORIGEM_PROP, VIND_COD_ORIGEM_PROP);
            }

        }

        [StopWatch]
        /*" R0070-00-LER-MOVTO-DB-CLOSE-1 */
        public void R0070_00_LER_MOVTO_DB_CLOSE_1()
        {
            /*" -1144- EXEC SQL CLOSE PROPOSTAS-VA END-EXEC */

            PROPOSTAS_VA.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0070_SAIDA*/

        [StopWatch]
        /*" R0080-00-GERAR-HEADER-SECTION */
        private void R0080_00_GERAR_HEADER_SECTION()
        {
            /*" -1189- MOVE 'R0080-00-GERAR-HEADER' TO PARAGRAFO. */
            _.Move("R0080-00-GERAR-HEADER", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1191- MOVE 'WRITE REG-HEADER' TO COMANDO. */
            _.Move("WRITE REG-HEADER", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1193- MOVE SPACES TO REG-HEADER. */
            _.Move("", LXFPF990.REG_HEADER);

            /*" -1196- MOVE 'H' TO RH-TIPO-REG OF REG-HEADER */
            _.Move("H", LXFPF990.REG_HEADER.RH_TIPO_REG);

            /*" -1199- MOVE 'PRPSASSE' TO RH-NOME OF REG-HEADER */
            _.Move("PRPSASSE", LXFPF990.REG_HEADER.RH_NOME);

            /*" -1200- MOVE W-DIA-MOVABE OF W-DTMOVABE1 TO W-DIA-TRABALHO */
            _.Move(WAREA_AUXILIAR.W_DTMOVABE1.W_DIA_MOVABE, WAREA_AUXILIAR.FILLER_2.W_DIA_TRABALHO);

            /*" -1201- MOVE W-MES-MOVABE OF W-DTMOVABE1 TO W-MES-TRABALHO */
            _.Move(WAREA_AUXILIAR.W_DTMOVABE1.W_MES_MOVABE, WAREA_AUXILIAR.FILLER_2.W_MES_TRABALHO);

            /*" -1203- MOVE W-ANO-MOVABE OF W-DTMOVABE1 TO W-ANO-TRABALHO */
            _.Move(WAREA_AUXILIAR.W_DTMOVABE1.W_ANO_MOVABE, WAREA_AUXILIAR.FILLER_2.W_ANO_TRABALHO);

            /*" -1206- MOVE W-DATA-TRABALHO TO RH-DATA-GERACAO OF REG-HEADER */
            _.Move(WAREA_AUXILIAR.W_DATA_TRABALHO, LXFPF990.REG_HEADER.RH_DATA_GERACAO);

            /*" -1209- MOVE 4 TO RH-SIST-ORIGEM OF REG-HEADER */
            _.Move(4, LXFPF990.REG_HEADER.RH_SIST_ORIGEM);

            /*" -1212- MOVE 1 TO RH-SIST-DESTINO OF REG-HEADER */
            _.Move(1, LXFPF990.REG_HEADER.RH_SIST_DESTINO);

            /*" -1215- MOVE ARQSIVPF-NSAS-SIVPF OF DCLARQUIVOS-SIVPF TO RH-NSAS OF REG-HEADER */
            _.Move(ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF, LXFPF990.REG_HEADER.RH_NSAS);

            /*" -1217- MOVE 1 TO RH-TIPO-ARQUIVO OF REG-HEADER. */
            _.Move(1, LXFPF990.REG_HEADER.RH_TIPO_ARQUIVO);

            /*" -1217- WRITE REG-PRP-SASSE FROM REG-HEADER. */
            _.Move(LXFPF990.REG_HEADER.GetMoveValues(), REG_PRP_SASSE);

            MOVTO_PRP_SASSE.Write(REG_PRP_SASSE.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0080_SAIDA*/

        [StopWatch]
        /*" R0150-00-PROCESSAR-MOVIMENTO-SECTION */
        private void R0150_00_PROCESSAR_MOVIMENTO_SECTION()
        {
            /*" -1227- MOVE 'R0150-00-PROCESSA-MOVIMENTO' TO PARAGRAFO. */
            _.Move("R0150-00-PROCESSA-MOVIMENTO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1229- MOVE '    ' TO COMANDO. */
            _.Move("    ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1231- MOVE 'NAO' TO W-EXISTE-FIDELIZ. */
            _.Move("NAO", WAREA_AUXILIAR.W_EXISTE_FIDELIZ);

            /*" -1232- IF VIND-COD-ORIGEM-PROP LESS ZEROS */

            if (VIND_COD_ORIGEM_PROP < 00)
            {

                /*" -1236- MOVE ZEROS TO COD-ORIGEM-PROPOSTA OF DCLPROPOSTAS-VA. */
                _.Move(0, PROPVA.DCLPROPOSTAS_VA.COD_ORIGEM_PROPOSTA);
            }


            /*" -1237- IF VIND-COD-ORIGEM-PROP = 12 */

            if (VIND_COD_ORIGEM_PROP == 12)
            {

                /*" -1240- GO TO R0150-LEITURA. */

                R0150_LEITURA(); //GOTO
                return;
            }


            /*" -1244- PERFORM R0200-00-LER-PROP-FIDELIZ. */

            R0200_00_LER_PROP_FIDELIZ_SECTION();

            /*" -1245- IF COD-PRODUTO-SIVPF OF DCLPROPOSTA-FIDELIZ = 48 */

            if (PROPFID.DCLPROPOSTA_FIDELIZ.COD_PRODUTO_SIVPF == 48)
            {

                /*" -1251- GO TO R0150-LEITURA. */

                R0150_LEITURA(); //GOTO
                return;
            }


            /*" -1252- IF W-EXISTE-FIDELIZ EQUAL 'SIM' */

            if (WAREA_AUXILIAR.W_EXISTE_FIDELIZ == "SIM")
            {

                /*" -1255- MOVE NUM-CERTIFICADO OF DCLPROPOSTAS-VA TO NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ */
                _.Move(PROPVA.DCLPROPOSTAS_VA.NUM_CERTIFICADO, PROPFID.DCLPROPOSTA_FIDELIZ.NUM_PROPOSTA_SIVPF);

                /*" -1256- PERFORM R0250-00-UPDATE-FIDELIZ */

                R0250_00_UPDATE_FIDELIZ_SECTION();

                /*" -1257- GO TO R0150-LEITURA */

                R0150_LEITURA(); //GOTO
                return;

                /*" -1259- END-IF. */
            }


            /*" -1263- IF NUM-CERTIFICADO OF DCLPROPOSTAS-VA NOT LESS 10000000000 AND NUM-CERTIFICADO OF DCLPROPOSTAS-VA NOT GREATER 19999999999 */

            if (PROPVA.DCLPROPOSTAS_VA.NUM_CERTIFICADO >= 10000000000 && PROPVA.DCLPROPOSTAS_VA.NUM_CERTIFICADO <= 19999999999)
            {

                /*" -1267- MOVE NUM-CERTIFICADO OF DCLPROPOSTAS-VA TO WCERTIFICADO W-NUM-PROPOSTA-ATUAL */
                _.Move(PROPVA.DCLPROPOSTAS_VA.NUM_CERTIFICADO, W01DIGCERT.WCERTIFICADO, WAREA_AUXILIAR.CANAL.W_NUM_PROPOSTA_ATUAL);

                /*" -1269- PERFORM R0270-000-ROTINA-DIGITO */

                R0270_000_ROTINA_DIGITO_SECTION();

                /*" -1270- MOVE WDIG TO W-DV-PROPOSTA-NOVA */
                _.Move(W01DIGCERT.WDIG, WAREA_AUXILIAR.CANAL.W_DV_PROPOSTA_NOVA);

                /*" -1271- ELSE */
            }
            else
            {


                /*" -1274- MOVE NUM-CERTIFICADO OF DCLPROPOSTAS-VA TO W-NUM-PROPOSTA-NOVA. */
                _.Move(PROPVA.DCLPROPOSTAS_VA.NUM_CERTIFICADO, WAREA_AUXILIAR.W_NUM_PROPOSTA_NOVA);
            }


            /*" -1277- MOVE DATA-MOVIMENTO OF DCLPROPOSTAS-VA TO RELATORI-DATA-REFERENCIA OF DCLRELATORIOS */
            _.Move(PROPVA.DCLPROPOSTAS_VA.DATA_MOVIMENTO, RELATORI.DCLRELATORIOS.RELATORI_DATA_REFERENCIA);

            /*" -1278- PERFORM R0300-00-LER-CLIENTE */

            R0300_00_LER_CLIENTE_SECTION();

            /*" -1279- PERFORM R0350-00-LER-ENDERECO */

            R0350_00_LER_ENDERECO_SECTION();

            /*" -1280- PERFORM R0400-00-LER-PROFISSAO */

            R0400_00_LER_PROFISSAO_SECTION();

            /*" -1287- PERFORM R0450-00-LER-PRODUTOS-SIVPF */

            R0450_00_LER_PRODUTOS_SIVPF_SECTION();

            /*" -1288- IF COD-ORIGEM-PROPOSTA OF DCLPROPOSTAS-VA = 12 */

            if (PROPVA.DCLPROPOSTAS_VA.COD_ORIGEM_PROPOSTA == 12)
            {

                /*" -1289- PERFORM R0520-00-LER-PARCELVA */

                R0520_00_LER_PARCELVA_SECTION();

                /*" -1290- IF W-ACHOU-PGTO = 'NAO' */

                if (WAREA_AUXILIAR.W_ACHOU_PGTO == "NAO")
                {

                    /*" -1293- MOVE ZEROS TO PREMIO-VG OF DCLHIST-CONT-PARCELVA PREMIO-AP OF DCLHIST-CONT-PARCELVA */
                    _.Move(0, HTCTBPVA.DCLHIST_CONT_PARCELVA.PREMIO_VG, HTCTBPVA.DCLHIST_CONT_PARCELVA.PREMIO_AP);

                    /*" -1295- MOVE '0001-01-01' TO DATA-MOVIMENTO OF DCLHIST-CONT-PARCELVA */
                    _.Move("0001-01-01", HTCTBPVA.DCLHIST_CONT_PARCELVA.DATA_MOVIMENTO);

                    /*" -1297- ELSE NEXT SENTENCE */
                }
                else
                {


                    /*" -1298- ELSE */
                }

            }
            else
            {


                /*" -1299- PERFORM R0500-00-LER-RCAP */

                R0500_00_LER_RCAP_SECTION();

                /*" -1301- IF SQLCODE = 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1309- MOVE ZEROS TO RCAPS-COD-FONTE, RCAPS-NUM-RCAP, RCAPS-NUM-PROPOSTA, RCAPS-VAL-RCAP, RCAPS-VAL-RCAP-PRINCIPAL, RCAPS-SIT-REGISTRO, RCAPS-COD-OPERACAO, RCAPS-NUM-TITULO */
                    _.Move(0, RCAPS.DCLRCAPS.RCAPS_COD_FONTE, RCAPS.DCLRCAPS.RCAPS_NUM_RCAP, RCAPS.DCLRCAPS.RCAPS_NUM_PROPOSTA, RCAPS.DCLRCAPS.RCAPS_VAL_RCAP, RCAPS.DCLRCAPS.RCAPS_VAL_RCAP_PRINCIPAL, RCAPS.DCLRCAPS.RCAPS_SIT_REGISTRO, RCAPS.DCLRCAPS.RCAPS_COD_OPERACAO, RCAPS.DCLRCAPS.RCAPS_NUM_TITULO);

                    /*" -1315- MOVE '0001-01-01' TO RCAPS-DATA-CADASTRAMENTO, RCAPS-DATA-MOVIMENTO. */
                    _.Move("0001-01-01", RCAPS.DCLRCAPS.RCAPS_DATA_CADASTRAMENTO, RCAPS.DCLRCAPS.RCAPS_DATA_MOVIMENTO);
                }

            }


            /*" -1316- PERFORM R0550-00-LER-OPCAOPAGVA */

            R0550_00_LER_OPCAOPAGVA_SECTION();

            /*" -1317- PERFORM R0570-00-LER-COMISSAO */

            R0570_00_LER_COMISSAO_SECTION();

            /*" -1318- PERFORM R0580-00-OBTER-VAL-TARIFA */

            R0580_00_OBTER_VAL_TARIFA_SECTION();

            /*" -1319- PERFORM R0600-00-GERAR-REGISTRO-TP1 */

            R0600_00_GERAR_REGISTRO_TP1_SECTION();

            /*" -1320- PERFORM R0650-00-GERAR-REGISTRO-TP2 */

            R0650_00_GERAR_REGISTRO_TP2_SECTION();

            /*" -1321- PERFORM R0700-00-GERAR-REGISTRO-TP3 */

            R0700_00_GERAR_REGISTRO_TP3_SECTION();

            /*" -1322- PERFORM R0750-PROCESSAR-BENEFICIARIOS */

            R0750_PROCESSAR_BENEFICIARIOS_SECTION();

            /*" -1322- PERFORM R3000-GERAR-TB-CORPORATIVAS. */

            R3000_GERAR_TB_CORPORATIVAS_SECTION();

            /*" -0- FLUXCONTROL_PERFORM R0150_LEITURA */

            R0150_LEITURA();

        }

        [StopWatch]
        /*" R0150-LEITURA */
        private void R0150_LEITURA(bool isPerform = false)
        {
            /*" -1327- IF W-FIM-MOVTO-VGAP NOT EQUAL 'FIM' */

            if (WAREA_AUXILIAR.W_FIM_MOVTO_VGAP != "FIM")
            {

                /*" -1327- PERFORM R0070-00-LER-MOVTO. */

                R0070_00_LER_MOVTO_SECTION();
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0150_SAIDA*/

        [StopWatch]
        /*" R0200-00-LER-PROP-FIDELIZ-SECTION */
        private void R0200_00_LER_PROP_FIDELIZ_SECTION()
        {
            /*" -1337- MOVE 'R0200-00-LER-PROP-FIDELIZ' TO PARAGRAFO. */
            _.Move("R0200-00-LER-PROP-FIDELIZ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1339- MOVE 'SELECT PROPOSTA-FIDELIZ' TO COMANDO. */
            _.Move("SELECT PROPOSTA-FIDELIZ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1343- MOVE NUM-CERTIFICADO OF DCLPROPOSTAS-VA TO NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ. */
            _.Move(PROPVA.DCLPROPOSTAS_VA.NUM_CERTIFICADO, PROPFID.DCLPROPOSTA_FIDELIZ.NUM_PROPOSTA_SIVPF);

            /*" -1344- ACCEPT WS-HORA-INI FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_INI);

            /*" -1347- COMPUTE SIT = (HI * 60 * 60) + (MI * 60) + SI + (DI / 100) */
            WS_HORAS.SIT.Value = (WS_HORAS.WS_HORA_INI_R.HI * 60 * 60) + (WS_HORAS.WS_HORA_INI_R.MI * 60) + WS_HORAS.WS_HORA_INI_R.SI + (WS_HORAS.WS_HORA_INI_R.DI / 100f);

            /*" -1360- PERFORM R0200_00_LER_PROP_FIDELIZ_DB_SELECT_1 */

            R0200_00_LER_PROP_FIDELIZ_DB_SELECT_1();

            /*" -1364- ACCEPT WS-HORA-FIM FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_FIM);

            /*" -1365- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF + (DF / 100) */
            WS_HORAS.SFT.Value = (WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (WS_HORAS.WS_HORA_FIM_R.MF * 60) + WS_HORAS.WS_HORA_FIM_R.SF + (WS_HORAS.WS_HORA_FIM_R.DF / 100f);

            /*" -1366- SUBTRACT SIT FROM SFT */
            WS_HORAS.SFT.Value = WS_HORAS.SFT - WS_HORAS.SIT;

            /*" -1367- ADD SFT TO STT(06) */
            TOTAIS_ROT.FILLER_20[06].STT.Value = TOTAIS_ROT.FILLER_20[06].STT + WS_HORAS.SFT;

            /*" -1370- ADD 1 TO SQT(06) */
            TOTAIS_ROT.FILLER_20[06].SQT.Value = TOTAIS_ROT.FILLER_20[06].SQT + 1;

            /*" -1371- IF SQLCODE EQUAL 00 */

            if (DB.SQLCODE == 00)
            {

                /*" -1372- MOVE 'SIM' TO W-EXISTE-FIDELIZ */
                _.Move("SIM", WAREA_AUXILIAR.W_EXISTE_FIDELIZ);

                /*" -1373- ELSE */
            }
            else
            {


                /*" -1374- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1375- MOVE 'NAO' TO W-EXISTE-FIDELIZ */
                    _.Move("NAO", WAREA_AUXILIAR.W_EXISTE_FIDELIZ);

                    /*" -1376- ELSE */
                }
                else
                {


                    /*" -1377- DISPLAY 'PF0619B - FIM ANORMAL' */
                    _.Display($"PF0619B - FIM ANORMAL");

                    /*" -1378- DISPLAY '          ERRO SELECT PROPOSTA-FIDELIZ' */
                    _.Display($"          ERRO SELECT PROPOSTA-FIDELIZ");

                    /*" -1380- DISPLAY '          NUMERO DA PROPOSTA......... ' NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ */
                    _.Display($"          NUMERO DA PROPOSTA......... {PROPFID.DCLPROPOSTA_FIDELIZ.NUM_PROPOSTA_SIVPF}");

                    /*" -1382- DISPLAY '          SQLCODE.................... ' SQLCODE */
                    _.Display($"          SQLCODE.................... {DB.SQLCODE}");

                    /*" -1383- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -1383- PERFORM R9999-00-FINALIZAR. */

                    R9999_00_FINALIZAR_SECTION();
                }

            }


        }

        [StopWatch]
        /*" R0200-00-LER-PROP-FIDELIZ-DB-SELECT-1 */
        public void R0200_00_LER_PROP_FIDELIZ_DB_SELECT_1()
        {
            /*" -1360- EXEC SQL SELECT SIT_PROPOSTA , NUM_SICOB , COD_PRODUTO_SIVPF , COD_EMPRESA_SIVPF INTO :DCLPROPOSTA-FIDELIZ.SIT-PROPOSTA , :DCLPROPOSTA-FIDELIZ.NUM-SICOB , :DCLPROPOSTA-FIDELIZ.COD-PRODUTO-SIVPF , :DCLPROPOSTA-FIDELIZ.COD-EMPRESA-SIVPF FROM SEGUROS.PROPOSTA_FIDELIZ WHERE NUM_PROPOSTA_SIVPF = :DCLPROPOSTA-FIDELIZ.NUM-PROPOSTA-SIVPF WITH UR END-EXEC. */

            var r0200_00_LER_PROP_FIDELIZ_DB_SELECT_1_Query1 = new R0200_00_LER_PROP_FIDELIZ_DB_SELECT_1_Query1()
            {
                NUM_PROPOSTA_SIVPF = PROPFID.DCLPROPOSTA_FIDELIZ.NUM_PROPOSTA_SIVPF.ToString(),
            };

            var executed_1 = R0200_00_LER_PROP_FIDELIZ_DB_SELECT_1_Query1.Execute(r0200_00_LER_PROP_FIDELIZ_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SIT_PROPOSTA, PROPFID.DCLPROPOSTA_FIDELIZ.SIT_PROPOSTA);
                _.Move(executed_1.NUM_SICOB, PROPFID.DCLPROPOSTA_FIDELIZ.NUM_SICOB);
                _.Move(executed_1.COD_PRODUTO_SIVPF, PROPFID.DCLPROPOSTA_FIDELIZ.COD_PRODUTO_SIVPF);
                _.Move(executed_1.COD_EMPRESA_SIVPF, PROPFID.DCLPROPOSTA_FIDELIZ.COD_EMPRESA_SIVPF);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_SAIDA*/

        [StopWatch]
        /*" R0250-00-UPDATE-FIDELIZ-SECTION */
        private void R0250_00_UPDATE_FIDELIZ_SECTION()
        {
            /*" -1393- MOVE 'R0250-00-UPDATE-FIDELIZ' TO PARAGRAFO. */
            _.Move("R0250-00-UPDATE-FIDELIZ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1398- MOVE 'UPDATE PROPOSTA FIDELIZ' TO COMANDO. */
            _.Move("UPDATE PROPOSTA FIDELIZ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1399- MOVE 'S' TO WHOST-SIT-ENVIO. */
            _.Move("S", WAREA_AUXILIAR.WHOST_SIT_ENVIO);

            /*" -1401- MOVE 'REJ' TO WHOST-SIT-PROPOSTA. */
            _.Move("REJ", WAREA_AUXILIAR.WHOST_SIT_PROPOSTA);

            /*" -1410- PERFORM R0250_00_UPDATE_FIDELIZ_DB_UPDATE_1 */

            R0250_00_UPDATE_FIDELIZ_DB_UPDATE_1();

            /*" -1419- ACCEPT WS-HORA-FIM FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_FIM);

            /*" -1420- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF + (DF / 100) */
            WS_HORAS.SFT.Value = (WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (WS_HORAS.WS_HORA_FIM_R.MF * 60) + WS_HORAS.WS_HORA_FIM_R.SF + (WS_HORAS.WS_HORA_FIM_R.DF / 100f);

            /*" -1421- SUBTRACT SIT FROM SFT */
            WS_HORAS.SFT.Value = WS_HORAS.SFT - WS_HORAS.SIT;

            /*" -1422- ADD SFT TO STT(08) */
            TOTAIS_ROT.FILLER_20[08].STT.Value = TOTAIS_ROT.FILLER_20[08].STT + WS_HORAS.SFT;

            /*" -1425- ADD 1 TO SQT(08) */
            TOTAIS_ROT.FILLER_20[08].SQT.Value = TOTAIS_ROT.FILLER_20[08].SQT + 1;

            /*" -1426- IF SQLCODE EQUAL 00 */

            if (DB.SQLCODE == 00)
            {

                /*" -1427- ADD 1 TO W-TOT-ATU-PRP */
                WAREA_AUXILIAR.W_TOT_ATU_PRP.Value = WAREA_AUXILIAR.W_TOT_ATU_PRP + 1;

                /*" -1428- ELSE */
            }
            else
            {


                /*" -1429- IF SQLCODE NOT EQUAL 100 */

                if (DB.SQLCODE != 100)
                {

                    /*" -1430- DISPLAY 'PF0619B - FIM ANORMAL' */
                    _.Display($"PF0619B - FIM ANORMAL");

                    /*" -1431- DISPLAY '          ERRO UPDATE PROPOSTA-FIDELIZ' */
                    _.Display($"          ERRO UPDATE PROPOSTA-FIDELIZ");

                    /*" -1433- DISPLAY '          NUMERO PROPOSTA............ ' NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ */
                    _.Display($"          NUMERO PROPOSTA............ {PROPFID.DCLPROPOSTA_FIDELIZ.NUM_PROPOSTA_SIVPF}");

                    /*" -1435- DISPLAY '          SQLCODE.................... ' SQLCODE */
                    _.Display($"          SQLCODE.................... {DB.SQLCODE}");

                    /*" -1436- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -1436- PERFORM R9999-00-FINALIZAR. */

                    R9999_00_FINALIZAR_SECTION();
                }

            }


        }

        [StopWatch]
        /*" R0250-00-UPDATE-FIDELIZ-DB-UPDATE-1 */
        public void R0250_00_UPDATE_FIDELIZ_DB_UPDATE_1()
        {
            /*" -1410- EXEC SQL UPDATE SEGUROS.PROPOSTA_FIDELIZ SET SIT_PROPOSTA = :WHOST-SIT-PROPOSTA, SITUACAO_ENVIO = :WHOST-SIT-ENVIO , COD_USUARIO = 'PF0619B' , TIMESTAMP = CURRENT TIMESTAMP WHERE NUM_PROPOSTA_SIVPF = :DCLPROPOSTA-FIDELIZ.NUM-PROPOSTA-SIVPF AND SIT_PROPOSTA NOT IN ( 'MAN' , 'EMT' , 'CAN' , 'REJ' ) END-EXEC. */

            var r0250_00_UPDATE_FIDELIZ_DB_UPDATE_1_Update1 = new R0250_00_UPDATE_FIDELIZ_DB_UPDATE_1_Update1()
            {
                WHOST_SIT_PROPOSTA = WAREA_AUXILIAR.WHOST_SIT_PROPOSTA.ToString(),
                WHOST_SIT_ENVIO = WAREA_AUXILIAR.WHOST_SIT_ENVIO.ToString(),
                NUM_PROPOSTA_SIVPF = PROPFID.DCLPROPOSTA_FIDELIZ.NUM_PROPOSTA_SIVPF.ToString(),
            };

            R0250_00_UPDATE_FIDELIZ_DB_UPDATE_1_Update1.Execute(r0250_00_UPDATE_FIDELIZ_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0250_SAIDA*/

        [StopWatch]
        /*" R0270-000-ROTINA-DIGITO-SECTION */
        private void R0270_000_ROTINA_DIGITO_SECTION()
        {
            /*" -1450- MOVE '270-000-ROTINA-DIGITO' TO PARAGRAFO. */
            _.Move("270-000-ROTINA-DIGITO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1452- MOVE 'CALL PROM1101' TO COMANDO. */
            _.Move("CALL PROM1101", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1452- CALL 'PROM1101' USING W01DIGCERT. */
            _.Call("PROM1101", W01DIGCERT);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0270_999_EXIT*/

        [StopWatch]
        /*" R0300-00-LER-CLIENTE-SECTION */
        private void R0300_00_LER_CLIENTE_SECTION()
        {
            /*" -1465- MOVE 'R0300-00-LER-CLIENTES' TO PARAGRAFO. */
            _.Move("R0300-00-LER-CLIENTES", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1467- MOVE 'SELECT CLIENTES' TO COMANDO. */
            _.Move("SELECT CLIENTES", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1471- MOVE COD-CLIENTE OF DCLPROPOSTAS-VA TO COD-CLIENTE OF DCLCLIENTES. */
            _.Move(PROPVA.DCLPROPOSTAS_VA.COD_CLIENTE, CLIENTE.DCLCLIENTES.COD_CLIENTE);

            /*" -1472- ACCEPT WS-HORA-INI FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_INI);

            /*" -1475- COMPUTE SIT = (HI * 60 * 60) + (MI * 60) + SI + (DI / 100) */
            WS_HORAS.SIT.Value = (WS_HORAS.WS_HORA_INI_R.HI * 60 * 60) + (WS_HORAS.WS_HORA_INI_R.MI * 60) + WS_HORAS.WS_HORA_INI_R.SI + (WS_HORAS.WS_HORA_INI_R.DI / 100f);

            /*" -1493- PERFORM R0300_00_LER_CLIENTE_DB_SELECT_1 */

            R0300_00_LER_CLIENTE_DB_SELECT_1();

            /*" -1497- ACCEPT WS-HORA-FIM FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_FIM);

            /*" -1498- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF + (DF / 100) */
            WS_HORAS.SFT.Value = (WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (WS_HORAS.WS_HORA_FIM_R.MF * 60) + WS_HORAS.WS_HORA_FIM_R.SF + (WS_HORAS.WS_HORA_FIM_R.DF / 100f);

            /*" -1499- SUBTRACT SIT FROM SFT */
            WS_HORAS.SFT.Value = WS_HORAS.SFT - WS_HORAS.SIT;

            /*" -1500- ADD SFT TO STT(08) */
            TOTAIS_ROT.FILLER_20[08].STT.Value = TOTAIS_ROT.FILLER_20[08].STT + WS_HORAS.SFT;

            /*" -1503- ADD 1 TO SQT(08) */
            TOTAIS_ROT.FILLER_20[08].SQT.Value = TOTAIS_ROT.FILLER_20[08].SQT + 1;

            /*" -1504- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -1505- DISPLAY 'PF0619B - FIM ANORMAL' */
                _.Display($"PF0619B - FIM ANORMAL");

                /*" -1506- DISPLAY '          ERRO SELECT TABELA CLIENTES' */
                _.Display($"          ERRO SELECT TABELA CLIENTES");

                /*" -1508- DISPLAY '          NUMERO CERTIFICADO......... ' NUM-CERTIFICADO OF DCLPROPOSTAS-VA */
                _.Display($"          NUMERO CERTIFICADO......... {PROPVA.DCLPROPOSTAS_VA.NUM_CERTIFICADO}");

                /*" -1510- DISPLAY '          CODIGO DO CLIENTE.......... ' COD-CLIENTE OF DCLCLIENTES */
                _.Display($"          CODIGO DO CLIENTE.......... {CLIENTE.DCLCLIENTES.COD_CLIENTE}");

                /*" -1512- DISPLAY '          SQLCODE.................... ' SQLCODE */
                _.Display($"          SQLCODE.................... {DB.SQLCODE}");

                /*" -1513- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -1513- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R0300-00-LER-CLIENTE-DB-SELECT-1 */
        public void R0300_00_LER_CLIENTE_DB_SELECT_1()
        {
            /*" -1493- EXEC SQL SELECT COD_CLIENTE , NOME_RAZAO , TIPO_PESSOA , CGCCPF , SIT_REGISTRO , DATA_NASCIMENTO INTO :DCLCLIENTES.COD-CLIENTE , :DCLCLIENTES.NOME-RAZAO , :DCLCLIENTES.TIPO-PESSOA , :DCLCLIENTES.CGCCPF , :DCLCLIENTES.SIT-REGISTRO , :DCLCLIENTES.DATA-NASCIMENTO:VIND-DTNASCI FROM SEGUROS.CLIENTES WHERE COD_CLIENTE = :DCLCLIENTES.COD-CLIENTE WITH UR END-EXEC. */

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
            /*" -1523- MOVE 'R0350-00-LER-ENDERECO' TO PARAGRAFO. */
            _.Move("R0350-00-LER-ENDERECO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1525- MOVE 'SELECT ENDERECOS' TO COMANDO. */
            _.Move("SELECT ENDERECOS", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1529- MOVE COD-CLIENTE OF DCLPROPOSTAS-VA TO ENDERECO-COD-CLIENTE OF DCLENDERECOS. */
            _.Move(PROPVA.DCLPROPOSTAS_VA.COD_CLIENTE, ENDERECO.DCLENDERECOS.ENDERECO_COD_CLIENTE);

            /*" -1530- ACCEPT WS-HORA-INI FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_INI);

            /*" -1533- COMPUTE SIT = (HI * 60 * 60) + (MI * 60) + SI + (DI / 100) */
            WS_HORAS.SIT.Value = (WS_HORAS.WS_HORA_INI_R.HI * 60 * 60) + (WS_HORAS.WS_HORA_INI_R.MI * 60) + WS_HORAS.WS_HORA_INI_R.SI + (WS_HORAS.WS_HORA_INI_R.DI / 100f);

            /*" -1567- PERFORM R0350_00_LER_ENDERECO_DB_SELECT_1 */

            R0350_00_LER_ENDERECO_DB_SELECT_1();

            /*" -1571- ACCEPT WS-HORA-FIM FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_FIM);

            /*" -1572- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF + (DF / 100) */
            WS_HORAS.SFT.Value = (WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (WS_HORAS.WS_HORA_FIM_R.MF * 60) + WS_HORAS.WS_HORA_FIM_R.SF + (WS_HORAS.WS_HORA_FIM_R.DF / 100f);

            /*" -1573- SUBTRACT SIT FROM SFT */
            WS_HORAS.SFT.Value = WS_HORAS.SFT - WS_HORAS.SIT;

            /*" -1574- ADD SFT TO STT(09) */
            TOTAIS_ROT.FILLER_20[09].STT.Value = TOTAIS_ROT.FILLER_20[09].STT + WS_HORAS.SFT;

            /*" -1577- ADD 1 TO SQT(09) */
            TOTAIS_ROT.FILLER_20[09].SQT.Value = TOTAIS_ROT.FILLER_20[09].SQT + 1;

            /*" -1578- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -1579- DISPLAY 'PF0619B - FIM ANORMAL' */
                _.Display($"PF0619B - FIM ANORMAL");

                /*" -1580- DISPLAY '          ERRO SELECT TABELA ENDERECOS' */
                _.Display($"          ERRO SELECT TABELA ENDERECOS");

                /*" -1582- DISPLAY '          NUMERO CERTIFICADO.......... ' NUM-CERTIFICADO OF DCLPROPOSTAS-VA */
                _.Display($"          NUMERO CERTIFICADO.......... {PROPVA.DCLPROPOSTAS_VA.NUM_CERTIFICADO}");

                /*" -1584- DISPLAY '          CODIGO DO CLIENTE........... ' ENDERECO-COD-CLIENTE OF DCLENDERECOS */
                _.Display($"          CODIGO DO CLIENTE........... {ENDERECO.DCLENDERECOS.ENDERECO_COD_CLIENTE}");

                /*" -1586- DISPLAY '          SQLCODE..................... ' SQLCODE */
                _.Display($"          SQLCODE..................... {DB.SQLCODE}");

                /*" -1587- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -1587- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R0350-00-LER-ENDERECO-DB-SELECT-1 */
        public void R0350_00_LER_ENDERECO_DB_SELECT_1()
        {
            /*" -1567- EXEC SQL SELECT COD_CLIENTE , COD_ENDERECO , OCORR_ENDERECO , ENDERECO , BAIRRO , CIDADE , SIGLA_UF , CEP , DDD , TELEFONE , FAX , TELEX , SIT_REGISTRO INTO :DCLENDERECOS.ENDERECO-COD-CLIENTE , :DCLENDERECOS.ENDERECO-COD-ENDERECO , :DCLENDERECOS.ENDERECO-OCORR-ENDERECO , :DCLENDERECOS.ENDERECO-ENDERECO , :DCLENDERECOS.ENDERECO-BAIRRO , :DCLENDERECOS.ENDERECO-CIDADE , :DCLENDERECOS.ENDERECO-SIGLA-UF , :DCLENDERECOS.ENDERECO-CEP , :DCLENDERECOS.ENDERECO-DDD , :DCLENDERECOS.ENDERECO-TELEFONE , :DCLENDERECOS.ENDERECO-FAX , :DCLENDERECOS.ENDERECO-TELEX , :DCLENDERECOS.ENDERECO-SIT-REGISTRO FROM SEGUROS.ENDERECOS WHERE COD_CLIENTE = :DCLENDERECOS.ENDERECO-COD-CLIENTE AND OCORR_ENDERECO = 1 WITH UR END-EXEC. */

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
            /*" -1600- MOVE 'R0400-00-LER-PROFISSAO' TO PARAGRAFO. */
            _.Move("R0400-00-LER-PROFISSAO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1602- IF PROFISSAO OF DCLPROPOSTAS-VA NOT EQUAL SPACES */

            if (!PROPVA.DCLPROPOSTAS_VA.PROFISSAO.IsEmpty())
            {

                /*" -1605- MOVE PROFISSAO OF DCLPROPOSTAS-VA TO CBO-DESCR-CBO OF DCLCBO */
                _.Move(PROPVA.DCLPROPOSTAS_VA.PROFISSAO, CBO.DCLCBO.CBO_DESCR_CBO);

                /*" -1607- PERFORM R0410-00-LER-CBO */

                R0410_00_LER_CBO_SECTION();

                /*" -1608- IF SQLCODE EQUAL 00 */

                if (DB.SQLCODE == 00)
                {

                    /*" -1610- MOVE CBO-COD-CBO OF DCLCBO TO COD-CBO-TIT */
                    _.Move(CBO.DCLCBO.CBO_COD_CBO, COD_CBO_TIT);

                    /*" -1611- ELSE */
                }
                else
                {


                    /*" -1612- MOVE ZEROS TO COD-CBO-TIT */
                    _.Move(0, COD_CBO_TIT);

                    /*" -1613- ELSE */
                }

            }
            else
            {


                /*" -1617- MOVE ZEROS TO COD-CBO-TIT. */
                _.Move(0, COD_CBO_TIT);
            }


            /*" -1618- IF VIND-PROFIS-ESPOSA LESS ZEROS */

            if (VIND_PROFIS_ESPOSA < 00)
            {

                /*" -1619- MOVE ZEROS TO COD-CBO-CONJ */
                _.Move(0, COD_CBO_CONJ);

                /*" -1620- ELSE */
            }
            else
            {


                /*" -1622- IF PROFIS-ESPOSA OF DCLPROPOSTAS-VA NOT EQUAL SPACES */

                if (!PROPVA.DCLPROPOSTAS_VA.PROFIS_ESPOSA.IsEmpty())
                {

                    /*" -1625- MOVE PROFIS-ESPOSA OF DCLPROPOSTAS-VA TO CBO-DESCR-CBO OF DCLCBO */
                    _.Move(PROPVA.DCLPROPOSTAS_VA.PROFIS_ESPOSA, CBO.DCLCBO.CBO_DESCR_CBO);

                    /*" -1627- PERFORM R0410-00-LER-CBO */

                    R0410_00_LER_CBO_SECTION();

                    /*" -1628- IF SQLCODE EQUAL 00 */

                    if (DB.SQLCODE == 00)
                    {

                        /*" -1630- MOVE CBO-COD-CBO OF DCLCBO TO COD-CBO-CONJ */
                        _.Move(CBO.DCLCBO.CBO_COD_CBO, COD_CBO_CONJ);

                        /*" -1631- ELSE */
                    }
                    else
                    {


                        /*" -1632- MOVE ZEROS TO COD-CBO-CONJ */
                        _.Move(0, COD_CBO_CONJ);

                        /*" -1633- ELSE */
                    }

                }
                else
                {


                    /*" -1633- MOVE ZEROS TO COD-CBO-CONJ. */
                    _.Move(0, COD_CBO_CONJ);
                }

            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0400_SAIDA*/

        [StopWatch]
        /*" R0410-00-LER-CBO-SECTION */
        private void R0410_00_LER_CBO_SECTION()
        {
            /*" -1643- MOVE 'R0400-00-LER-CBO' TO PARAGRAFO. */
            _.Move("R0400-00-LER-CBO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1647- MOVE 'SELECT CBO' TO COMANDO. */
            _.Move("SELECT CBO", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1648- ACCEPT WS-HORA-INI FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_INI);

            /*" -1651- COMPUTE SIT = (HI * 60 * 60) + (MI * 60) + SI + (DI / 100) */
            WS_HORAS.SIT.Value = (WS_HORAS.WS_HORA_INI_R.HI * 60 * 60) + (WS_HORAS.WS_HORA_INI_R.MI * 60) + WS_HORAS.WS_HORA_INI_R.SI + (WS_HORAS.WS_HORA_INI_R.DI / 100f);

            /*" -1661- PERFORM R0410_00_LER_CBO_DB_SELECT_1 */

            R0410_00_LER_CBO_DB_SELECT_1();

            /*" -1665- ACCEPT WS-HORA-FIM FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_FIM);

            /*" -1666- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF + (DF / 100) */
            WS_HORAS.SFT.Value = (WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (WS_HORAS.WS_HORA_FIM_R.MF * 60) + WS_HORAS.WS_HORA_FIM_R.SF + (WS_HORAS.WS_HORA_FIM_R.DF / 100f);

            /*" -1667- SUBTRACT SIT FROM SFT */
            WS_HORAS.SFT.Value = WS_HORAS.SFT - WS_HORAS.SIT;

            /*" -1668- ADD SFT TO STT(10) */
            TOTAIS_ROT.FILLER_20[10].STT.Value = TOTAIS_ROT.FILLER_20[10].STT + WS_HORAS.SFT;

            /*" -1671- ADD 1 TO SQT(10) */
            TOTAIS_ROT.FILLER_20[10].SQT.Value = TOTAIS_ROT.FILLER_20[10].SQT + 1;

            /*" -1672- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -1673- IF SQLCODE EQUAL -811 */

                if (DB.SQLCODE == -811)
                {

                    /*" -1681- PERFORM R0410_00_LER_CBO_DB_DECLARE_1 */

                    R0410_00_LER_CBO_DB_DECLARE_1();

                    /*" -1683- PERFORM R0410_00_LER_CBO_DB_OPEN_1 */

                    R0410_00_LER_CBO_DB_OPEN_1();

                    /*" -1686- IF SQLCODE EQUAL 00 */

                    if (DB.SQLCODE == 00)
                    {

                        /*" -1689- PERFORM R0410_00_LER_CBO_DB_FETCH_1 */

                        R0410_00_LER_CBO_DB_FETCH_1();

                        /*" -1691- PERFORM R0410_00_LER_CBO_DB_CLOSE_1 */

                        R0410_00_LER_CBO_DB_CLOSE_1();

                        /*" -1694- ELSE NEXT SENTENCE */
                    }
                    else
                    {


                        /*" -1695- ELSE */
                    }

                }
                else
                {


                    /*" -1696- IF SQLCODE NOT EQUAL 100 */

                    if (DB.SQLCODE != 100)
                    {

                        /*" -1697- DISPLAY 'PF0619B - FIM ANORMAL' */
                        _.Display($"PF0619B - FIM ANORMAL");

                        /*" -1698- DISPLAY '          ERRO SELECT TABELA CBO' */
                        _.Display($"          ERRO SELECT TABELA CBO");

                        /*" -1700- DISPLAY '          NUMERO CERTIFICADO....' NUM-CERTIFICADO OF DCLPROPOSTAS-VA */
                        _.Display($"          NUMERO CERTIFICADO....{PROPVA.DCLPROPOSTAS_VA.NUM_CERTIFICADO}");

                        /*" -1702- DISPLAY '          SQLCODE............... ' SQLCODE */
                        _.Display($"          SQLCODE............... {DB.SQLCODE}");

                        /*" -1703- PERFORM R9988-00-FECHAR-ARQUIVOS */

                        R9988_00_FECHAR_ARQUIVOS_SECTION();

                        /*" -1703- PERFORM R9999-00-FINALIZAR. */

                        R9999_00_FINALIZAR_SECTION();
                    }

                }

            }


        }

        [StopWatch]
        /*" R0410-00-LER-CBO-DB-SELECT-1 */
        public void R0410_00_LER_CBO_DB_SELECT_1()
        {
            /*" -1661- EXEC SQL SELECT COD_CBO , DESCR_CBO INTO :DCLCBO.CBO-COD-CBO , :DCLCBO.CBO-DESCR-CBO FROM SEGUROS.CBO WHERE DESCR_CBO = :DCLCBO.CBO-DESCR-CBO WITH UR END-EXEC. */

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
            /*" -1683- EXEC SQL OPEN C01_CBO END-EXEC */

            C01_CBO.Open();

        }

        [StopWatch]
        /*" R0520-00-LER-PARCELVA-DB-DECLARE-1 */
        public void R0520_00_LER_PARCELVA_DB_DECLARE_1()
        {
            /*" -1854- EXEC SQL DECLARE CUR-PARCELVA CURSOR FOR SELECT PREMIO_VG, PREMIO_AP, DATA_MOVIMENTO FROM SEGUROS.HIST_CONT_PARCELVA WHERE NUM_CERTIFICADO = :DCLHIST-CONT-PARCELVA.NUM-CERTIFICADO AND NUM_PARCELA = 1 AND COD_OPERACAO BETWEEN 199 AND 300 ORDER BY NUM_CERTIFICADO,OCORR_HISTORICO WITH UR END-EXEC. */
            CUR_PARCELVA = new PF0619B_CUR_PARCELVA(true);
            string GetQuery_CUR_PARCELVA()
            {
                var query = @$"SELECT PREMIO_VG
							, 
							PREMIO_AP
							, 
							DATA_MOVIMENTO 
							FROM SEGUROS.HIST_CONT_PARCELVA 
							WHERE 
							NUM_CERTIFICADO = 
							'{HTCTBPVA.DCLHIST_CONT_PARCELVA.NUM_CERTIFICADO}' 
							AND NUM_PARCELA = 1 
							AND COD_OPERACAO BETWEEN 199 AND 300 
							ORDER BY NUM_CERTIFICADO
							,OCORR_HISTORICO";

                return query;
            }
            CUR_PARCELVA.GetQueryEvent += GetQuery_CUR_PARCELVA;

        }

        [StopWatch]
        /*" R0410-00-LER-CBO-DB-FETCH-1 */
        public void R0410_00_LER_CBO_DB_FETCH_1()
        {
            /*" -1689- EXEC SQL FETCH C01_CBO INTO :DCLCBO.CBO-COD-CBO , :DCLCBO.CBO-DESCR-CBO END-EXEC */

            if (C01_CBO.Fetch())
            {
                _.Move(C01_CBO.DCLCBO_CBO_COD_CBO, CBO.DCLCBO.CBO_COD_CBO);
                _.Move(C01_CBO.DCLCBO_CBO_DESCR_CBO, CBO.DCLCBO.CBO_DESCR_CBO);
            }

        }

        [StopWatch]
        /*" R0410-00-LER-CBO-DB-CLOSE-1 */
        public void R0410_00_LER_CBO_DB_CLOSE_1()
        {
            /*" -1691- EXEC SQL CLOSE C01_CBO END-EXEC */

            C01_CBO.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0410_SAIDA*/

        [StopWatch]
        /*" R0450-00-LER-PRODUTOS-SIVPF-SECTION */
        private void R0450_00_LER_PRODUTOS_SIVPF_SECTION()
        {
            /*" -1713- MOVE 'R0450-00-LER-PRODUTOS-SIVPF' TO PARAGRAFO. */
            _.Move("R0450-00-LER-PRODUTOS-SIVPF", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1715- MOVE 'SELECT PRODUTOS-SIVPF' TO COMANDO. */
            _.Move("SELECT PRODUTOS-SIVPF", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1719- MOVE COD-PRODUTO OF DCLPROPOSTAS-VA TO PRDSIVPF-COD-PRODUTO OF DCLPRODUTOS-SIVPF. */
            _.Move(PROPVA.DCLPROPOSTAS_VA.COD_PRODUTO, PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_PRODUTO);

            /*" -1720- ACCEPT WS-HORA-INI FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_INI);

            /*" -1723- COMPUTE SIT = (HI * 60 * 60) + (MI * 60) + SI + (DI / 100) */
            WS_HORAS.SIT.Value = (WS_HORAS.WS_HORA_INI_R.HI * 60 * 60) + (WS_HORAS.WS_HORA_INI_R.MI * 60) + WS_HORAS.WS_HORA_INI_R.SI + (WS_HORAS.WS_HORA_INI_R.DI / 100f);

            /*" -1739- PERFORM R0450_00_LER_PRODUTOS_SIVPF_DB_SELECT_1 */

            R0450_00_LER_PRODUTOS_SIVPF_DB_SELECT_1();

            /*" -1743- ACCEPT WS-HORA-FIM FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_FIM);

            /*" -1744- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF + (DF / 100) */
            WS_HORAS.SFT.Value = (WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (WS_HORAS.WS_HORA_FIM_R.MF * 60) + WS_HORAS.WS_HORA_FIM_R.SF + (WS_HORAS.WS_HORA_FIM_R.DF / 100f);

            /*" -1745- SUBTRACT SIT FROM SFT */
            WS_HORAS.SFT.Value = WS_HORAS.SFT - WS_HORAS.SIT;

            /*" -1746- ADD SFT TO STT(11) */
            TOTAIS_ROT.FILLER_20[11].STT.Value = TOTAIS_ROT.FILLER_20[11].STT + WS_HORAS.SFT;

            /*" -1749- ADD 1 TO SQT(11) */
            TOTAIS_ROT.FILLER_20[11].SQT.Value = TOTAIS_ROT.FILLER_20[11].SQT + 1;

            /*" -1750- IF SQLCODE NOT EQUAL 00 AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -1751- DISPLAY 'PF0619B - FIM ANORMAL' */
                _.Display($"PF0619B - FIM ANORMAL");

                /*" -1752- DISPLAY '          ERRO SELECT PRODUTOS-SIVPF' */
                _.Display($"          ERRO SELECT PRODUTOS-SIVPF");

                /*" -1754- DISPLAY '          NUMERO CERTIFICADO........' NUM-CERTIFICADO OF DCLPROPOSTAS-VA */
                _.Display($"          NUMERO CERTIFICADO........{PROPVA.DCLPROPOSTAS_VA.NUM_CERTIFICADO}");

                /*" -1756- DISPLAY '          CODIGO PRODUTO............' PRDSIVPF-COD-PRODUTO OF DCLPRODUTOS-SIVPF */
                _.Display($"          CODIGO PRODUTO............{PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_PRODUTO}");

                /*" -1758- DISPLAY '          SQLCODE................... ' SQLCODE */
                _.Display($"          SQLCODE................... {DB.SQLCODE}");

                /*" -1759- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -1759- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R0450-00-LER-PRODUTOS-SIVPF-DB-SELECT-1 */
        public void R0450_00_LER_PRODUTOS_SIVPF_DB_SELECT_1()
        {
            /*" -1739- EXEC SQL SELECT COD_EMPRESA_SIVPF , COD_PRODUTO_SIVPF , COD_PRODUTO , COD_RELAC INTO :DCLPRODUTOS-SIVPF.PRDSIVPF-COD-EMPRESA-SIVPF , :DCLPRODUTOS-SIVPF.PRDSIVPF-COD-PRODUTO-SIVPF , :DCLPRODUTOS-SIVPF.PRDSIVPF-COD-PRODUTO , :DCLPRODUTOS-SIVPF.PRDSIVPF-COD-RELAC FROM SEGUROS.PRODUTOS_SIVPF WHERE COD_EMPRESA_SIVPF = 1 AND COD_PRODUTO = :DCLPRODUTOS-SIVPF.PRDSIVPF-COD-PRODUTO WITH UR END-EXEC. */

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
        /*" R0500-00-LER-RCAP-SECTION */
        private void R0500_00_LER_RCAP_SECTION()
        {
            /*" -1769- MOVE 'R0500-00-LER-RCAP' TO PARAGRAFO. */
            _.Move("R0500-00-LER-RCAP", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1771- MOVE 'SELECT RCAP' TO COMANDO. */
            _.Move("SELECT RCAP", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1775- MOVE NUM-CERTIFICADO OF DCLPROPOSTAS-VA TO RCAPS-NUM-CERTIFICADO OF DCLRCAPS. */
            _.Move(PROPVA.DCLPROPOSTAS_VA.NUM_CERTIFICADO, RCAPS.DCLRCAPS.RCAPS_NUM_CERTIFICADO);

            /*" -1776- ACCEPT WS-HORA-INI FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_INI);

            /*" -1779- COMPUTE SIT = (HI * 60 * 60) + (MI * 60) + SI + (DI / 100) */
            WS_HORAS.SIT.Value = (WS_HORAS.WS_HORA_INI_R.HI * 60 * 60) + (WS_HORAS.WS_HORA_INI_R.MI * 60) + WS_HORAS.WS_HORA_INI_R.SI + (WS_HORAS.WS_HORA_INI_R.DI / 100f);

            /*" -1805- PERFORM R0500_00_LER_RCAP_DB_SELECT_1 */

            R0500_00_LER_RCAP_DB_SELECT_1();

            /*" -1809- ACCEPT WS-HORA-FIM FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_FIM);

            /*" -1810- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF + (DF / 100) */
            WS_HORAS.SFT.Value = (WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (WS_HORAS.WS_HORA_FIM_R.MF * 60) + WS_HORAS.WS_HORA_FIM_R.SF + (WS_HORAS.WS_HORA_FIM_R.DF / 100f);

            /*" -1811- SUBTRACT SIT FROM SFT */
            WS_HORAS.SFT.Value = WS_HORAS.SFT - WS_HORAS.SIT;

            /*" -1812- ADD SFT TO STT(12) */
            TOTAIS_ROT.FILLER_20[12].STT.Value = TOTAIS_ROT.FILLER_20[12].STT + WS_HORAS.SFT;

            /*" -1815- ADD 1 TO SQT(12) */
            TOTAIS_ROT.FILLER_20[12].SQT.Value = TOTAIS_ROT.FILLER_20[12].SQT + 1;

            /*" -1816- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -1817- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1819- DISPLAY 'PF0619B - RCAP NAO CADASTRADO... ' RCAPS-NUM-CERTIFICADO OF DCLRCAPS */
                    _.Display($"PF0619B - RCAP NAO CADASTRADO... {RCAPS.DCLRCAPS.RCAPS_NUM_CERTIFICADO}");

                    /*" -1820- ELSE */
                }
                else
                {


                    /*" -1821- DISPLAY 'PF0619B - FIM ANORMAL            ' SQLCODE */
                    _.Display($"PF0619B - FIM ANORMAL            {DB.SQLCODE}");

                    /*" -1822- DISPLAY '          ERRO SELECT TABELA RCAP' */
                    _.Display($"          ERRO SELECT TABELA RCAP");

                    /*" -1824- DISPLAY '          NUMERO DO TITULO....... ' RCAPS-NUM-CERTIFICADO OF DCLRCAPS */
                    _.Display($"          NUMERO DO TITULO....... {RCAPS.DCLRCAPS.RCAPS_NUM_CERTIFICADO}");

                    /*" -1825- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -1825- PERFORM R9999-00-FINALIZAR. */

                    R9999_00_FINALIZAR_SECTION();
                }

            }


        }

        [StopWatch]
        /*" R0500-00-LER-RCAP-DB-SELECT-1 */
        public void R0500_00_LER_RCAP_DB_SELECT_1()
        {
            /*" -1805- EXEC SQL SELECT COD_FONTE, NUM_RCAP, NUM_PROPOSTA, VAL_RCAP, VAL_RCAP_PRINCIPAL, DATA_CADASTRAMENTO, DATA_MOVIMENTO, SIT_REGISTRO, COD_OPERACAO, NUM_TITULO INTO :DCLRCAPS.RCAPS-COD-FONTE, :DCLRCAPS.RCAPS-NUM-RCAP, :DCLRCAPS.RCAPS-NUM-PROPOSTA, :DCLRCAPS.RCAPS-VAL-RCAP, :DCLRCAPS.RCAPS-VAL-RCAP-PRINCIPAL, :DCLRCAPS.RCAPS-DATA-CADASTRAMENTO, :DCLRCAPS.RCAPS-DATA-MOVIMENTO, :DCLRCAPS.RCAPS-SIT-REGISTRO, :DCLRCAPS.RCAPS-COD-OPERACAO, :DCLRCAPS.RCAPS-NUM-TITULO FROM SEGUROS.RCAPS WHERE NUM_CERTIFICADO = :DCLRCAPS.RCAPS-NUM-CERTIFICADO WITH UR END-EXEC. */

            var r0500_00_LER_RCAP_DB_SELECT_1_Query1 = new R0500_00_LER_RCAP_DB_SELECT_1_Query1()
            {
                RCAPS_NUM_CERTIFICADO = RCAPS.DCLRCAPS.RCAPS_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = R0500_00_LER_RCAP_DB_SELECT_1_Query1.Execute(r0500_00_LER_RCAP_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.RCAPS_COD_FONTE, RCAPS.DCLRCAPS.RCAPS_COD_FONTE);
                _.Move(executed_1.RCAPS_NUM_RCAP, RCAPS.DCLRCAPS.RCAPS_NUM_RCAP);
                _.Move(executed_1.RCAPS_NUM_PROPOSTA, RCAPS.DCLRCAPS.RCAPS_NUM_PROPOSTA);
                _.Move(executed_1.RCAPS_VAL_RCAP, RCAPS.DCLRCAPS.RCAPS_VAL_RCAP);
                _.Move(executed_1.RCAPS_VAL_RCAP_PRINCIPAL, RCAPS.DCLRCAPS.RCAPS_VAL_RCAP_PRINCIPAL);
                _.Move(executed_1.RCAPS_DATA_CADASTRAMENTO, RCAPS.DCLRCAPS.RCAPS_DATA_CADASTRAMENTO);
                _.Move(executed_1.RCAPS_DATA_MOVIMENTO, RCAPS.DCLRCAPS.RCAPS_DATA_MOVIMENTO);
                _.Move(executed_1.RCAPS_SIT_REGISTRO, RCAPS.DCLRCAPS.RCAPS_SIT_REGISTRO);
                _.Move(executed_1.RCAPS_COD_OPERACAO, RCAPS.DCLRCAPS.RCAPS_COD_OPERACAO);
                _.Move(executed_1.RCAPS_NUM_TITULO, RCAPS.DCLRCAPS.RCAPS_NUM_TITULO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0500_SAIDA*/

        [StopWatch]
        /*" R0520-00-LER-PARCELVA-SECTION */
        private void R0520_00_LER_PARCELVA_SECTION()
        {
            /*" -1835- MOVE 'R0520-00-LER-PARCELVA' TO PARAGRAFO. */
            _.Move("R0520-00-LER-PARCELVA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1836- MOVE 'SELECT PARCELVA' TO COMANDO. */
            _.Move("SELECT PARCELVA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1837- MOVE 'SIM' TO W-ACHOU-PGTO. */
            _.Move("SIM", WAREA_AUXILIAR.W_ACHOU_PGTO);

            /*" -1840- MOVE NUM-CERTIFICADO OF DCLPROPOSTAS-VA TO NUM-CERTIFICADO OF DCLHIST-CONT-PARCELVA */
            _.Move(PROPVA.DCLPROPOSTAS_VA.NUM_CERTIFICADO, HTCTBPVA.DCLHIST_CONT_PARCELVA.NUM_CERTIFICADO);

            /*" -1854- PERFORM R0520_00_LER_PARCELVA_DB_DECLARE_1 */

            R0520_00_LER_PARCELVA_DB_DECLARE_1();

            /*" -1857- PERFORM R0520_00_LER_PARCELVA_DB_OPEN_1 */

            R0520_00_LER_PARCELVA_DB_OPEN_1();

            /*" -1860- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -1861- DISPLAY '          PF0619B -  FIM ANORMAL' */
                _.Display($"          PF0619B -  FIM ANORMAL");

                /*" -1862- DISPLAY '          ERRO OPEN CURSOR CUR-PARCELVA' */
                _.Display($"          ERRO OPEN CURSOR CUR-PARCELVA");

                /*" -1864- DISPLAY '          NUMERO CERTIFICADO........... ' NUM-CERTIFICADO OF DCLHIST-CONT-PARCELVA */
                _.Display($"          NUMERO CERTIFICADO........... {HTCTBPVA.DCLHIST_CONT_PARCELVA.NUM_CERTIFICADO}");

                /*" -1866- DISPLAY '          SQLCODE...................... ' SQLCODE */
                _.Display($"          SQLCODE...................... {DB.SQLCODE}");

                /*" -1867- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -1869- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


            /*" -1875- PERFORM R0520_00_LER_PARCELVA_DB_FETCH_1 */

            R0520_00_LER_PARCELVA_DB_FETCH_1();

            /*" -1878- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -1879- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1880- MOVE 'NAO' TO W-ACHOU-PGTO */
                    _.Move("NAO", WAREA_AUXILIAR.W_ACHOU_PGTO);

                    /*" -1881- PERFORM R0521-00-TRATA-COBER-PROPST */

                    R0521_00_TRATA_COBER_PROPST_SECTION();

                    /*" -1882- ELSE */
                }
                else
                {


                    /*" -1883- DISPLAY '          PF0619B - FIM ANORMAL' */
                    _.Display($"          PF0619B - FIM ANORMAL");

                    /*" -1884- DISPLAY '          ERRO FETCHT CURSOR CUR-PARCELVA' */
                    _.Display($"          ERRO FETCHT CURSOR CUR-PARCELVA");

                    /*" -1886- DISPLAY '          NUMERO CERTIFICADO............. ' NUM-CERTIFICADO OF DCLHIST-CONT-PARCELVA */
                    _.Display($"          NUMERO CERTIFICADO............. {HTCTBPVA.DCLHIST_CONT_PARCELVA.NUM_CERTIFICADO}");

                    /*" -1888- DISPLAY '          SQLCODE........................ ' SQLCODE */
                    _.Display($"          SQLCODE........................ {DB.SQLCODE}");

                    /*" -1889- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -1891- PERFORM R9999-00-FINALIZAR. */

                    R9999_00_FINALIZAR_SECTION();
                }

            }


            /*" -1891- PERFORM R0520_00_LER_PARCELVA_DB_CLOSE_1 */

            R0520_00_LER_PARCELVA_DB_CLOSE_1();

            /*" -1894- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -1895- DISPLAY '          PF0619B - FIM ANORMAL' */
                _.Display($"          PF0619B - FIM ANORMAL");

                /*" -1896- DISPLAY '          ERRO CLOSE CURSOR CUR-PARCELVA' */
                _.Display($"          ERRO CLOSE CURSOR CUR-PARCELVA");

                /*" -1898- DISPLAY '          NUMERO CERTIFICADO............ ' NUM-CERTIFICADO OF DCLHIST-CONT-PARCELVA */
                _.Display($"          NUMERO CERTIFICADO............ {HTCTBPVA.DCLHIST_CONT_PARCELVA.NUM_CERTIFICADO}");

                /*" -1900- DISPLAY '          SQLCODE....................... ' SQLCODE */
                _.Display($"          SQLCODE....................... {DB.SQLCODE}");

                /*" -1901- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -1901- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R0520-00-LER-PARCELVA-DB-OPEN-1 */
        public void R0520_00_LER_PARCELVA_DB_OPEN_1()
        {
            /*" -1857- EXEC SQL OPEN CUR-PARCELVA END-EXEC. */

            CUR_PARCELVA.Open();

        }

        [StopWatch]
        /*" R0570-00-LER-COMISSAO-DB-DECLARE-1 */
        public void R0570_00_LER_COMISSAO_DB_DECLARE_1()
        {
            /*" -2044- EXEC SQL DECLARE FUNDOCOMISVA CURSOR FOR SELECT NUM_CERTIFICADO , VAL_COMISSAO_VG , VAL_COMISSAO_AP FROM SEGUROS.FUNDO_COMISSAO_VA WHERE NUM_CERTIFICADO = :DCLFUNDO-COMISSAO-VA.NUM-CERTIFICADO AND COD_OPERACAO = :DCLFUNDO-COMISSAO-VA.COD-OPERACAO WITH UR END-EXEC. */
            FUNDOCOMISVA = new PF0619B_FUNDOCOMISVA(true);
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

        [StopWatch]
        /*" R0520-00-LER-PARCELVA-DB-FETCH-1 */
        public void R0520_00_LER_PARCELVA_DB_FETCH_1()
        {
            /*" -1875- EXEC SQL FETCH CUR-PARCELVA INTO :DCLHIST-CONT-PARCELVA.PREMIO-VG, :DCLHIST-CONT-PARCELVA.PREMIO-AP, :DCLHIST-CONT-PARCELVA.DATA-MOVIMENTO END-EXEC. */

            if (CUR_PARCELVA.Fetch())
            {
                _.Move(CUR_PARCELVA.DCLHIST_CONT_PARCELVA_PREMIO_VG, HTCTBPVA.DCLHIST_CONT_PARCELVA.PREMIO_VG);
                _.Move(CUR_PARCELVA.DCLHIST_CONT_PARCELVA_PREMIO_AP, HTCTBPVA.DCLHIST_CONT_PARCELVA.PREMIO_AP);
                _.Move(CUR_PARCELVA.DCLHIST_CONT_PARCELVA_DATA_MOVIMENTO, HTCTBPVA.DCLHIST_CONT_PARCELVA.DATA_MOVIMENTO);
            }

        }

        [StopWatch]
        /*" R0520-00-LER-PARCELVA-DB-CLOSE-1 */
        public void R0520_00_LER_PARCELVA_DB_CLOSE_1()
        {
            /*" -1891- EXEC SQL CLOSE CUR-PARCELVA END-EXEC. */

            CUR_PARCELVA.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0520_SAIDA*/

        [StopWatch]
        /*" R0521-00-TRATA-COBER-PROPST-SECTION */
        private void R0521_00_TRATA_COBER_PROPST_SECTION()
        {
            /*" -1911- MOVE 'R0521-00-TRATA-COBER-PROPST' TO PARAGRAFO. */
            _.Move("R0521-00-TRATA-COBER-PROPST", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1912- MOVE 'SELECT HIS_COBER_PROPOST' TO COMANDO. */
            _.Move("SELECT HIS_COBER_PROPOST", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1914- MOVE 'SIM' TO W-ACHOU-PGTO. */
            _.Move("SIM", WAREA_AUXILIAR.W_ACHOU_PGTO);

            /*" -1924- PERFORM R0521_00_TRATA_COBER_PROPST_DB_SELECT_1 */

            R0521_00_TRATA_COBER_PROPST_DB_SELECT_1();

            /*" -1928- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -1929- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1930- MOVE 'NAO' TO W-ACHOU-PGTO */
                    _.Move("NAO", WAREA_AUXILIAR.W_ACHOU_PGTO);

                    /*" -1931- ELSE */
                }
                else
                {


                    /*" -1932- DISPLAY '          PF0612B - FIM ANORMAL' */
                    _.Display($"          PF0612B - FIM ANORMAL");

                    /*" -1933- DISPLAY '          ERRO SELECT HIS_COBER_PROPOST' */
                    _.Display($"          ERRO SELECT HIS_COBER_PROPOST");

                    /*" -1935- DISPLAY '          NUMERO CERTIFICADO............ ' NUM-CERTIFICADO OF DCLHIST-CONT-PARCELVA */
                    _.Display($"          NUMERO CERTIFICADO............ {HTCTBPVA.DCLHIST_CONT_PARCELVA.NUM_CERTIFICADO}");

                    /*" -1937- DISPLAY '          SQLCODE....................... ' SQLCODE */
                    _.Display($"          SQLCODE....................... {DB.SQLCODE}");

                    /*" -1938- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -1939- PERFORM R9999-00-FINALIZAR */

                    R9999_00_FINALIZAR_SECTION();

                    /*" -1940- ELSE */
                }

            }
            else
            {


                /*" -1943- MOVE ZEROS TO PREMIO-VG OF DCLHIST-CONT-PARCELVA PREMIO-AP OF DCLHIST-CONT-PARCELVA */
                _.Move(0, HTCTBPVA.DCLHIST_CONT_PARCELVA.PREMIO_VG, HTCTBPVA.DCLHIST_CONT_PARCELVA.PREMIO_AP);

                /*" -1945- MOVE VLPREMIO OF DCLHIS-COBER-PROPOST TO PREMIO-VG OF DCLHIST-CONT-PARCELVA */
                _.Move(COBPRPVA.DCLHIS_COBER_PROPOST.VLPREMIO, HTCTBPVA.DCLHIST_CONT_PARCELVA.PREMIO_VG);

                /*" -1946- MOVE DATA-QUITACAO OF DCLPROPOSTAS-VA TO DATA-MOVIMENTO OF DCLHIST-CONT-PARCELVA. */
                _.Move(PROPVA.DCLPROPOSTAS_VA.DATA_QUITACAO, HTCTBPVA.DCLHIST_CONT_PARCELVA.DATA_MOVIMENTO);
            }


        }

        [StopWatch]
        /*" R0521-00-TRATA-COBER-PROPST-DB-SELECT-1 */
        public void R0521_00_TRATA_COBER_PROPST_DB_SELECT_1()
        {
            /*" -1924- EXEC SQL SELECT VLPREMIO INTO :DCLHIS-COBER-PROPOST.VLPREMIO FROM SEGUROS.HIS_COBER_PROPOST WHERE NUM_CERTIFICADO = :DCLHIST-CONT-PARCELVA.NUM-CERTIFICADO AND OCORR_HISTORICO = 1 AND COD_OPERACAO BETWEEN 200 AND 299 WITH UR END-EXEC. */

            var r0521_00_TRATA_COBER_PROPST_DB_SELECT_1_Query1 = new R0521_00_TRATA_COBER_PROPST_DB_SELECT_1_Query1()
            {
                NUM_CERTIFICADO = HTCTBPVA.DCLHIST_CONT_PARCELVA.NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = R0521_00_TRATA_COBER_PROPST_DB_SELECT_1_Query1.Execute(r0521_00_TRATA_COBER_PROPST_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.VLPREMIO, COBPRPVA.DCLHIS_COBER_PROPOST.VLPREMIO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0521_SAIDA*/

        [StopWatch]
        /*" R0550-00-LER-OPCAOPAGVA-SECTION */
        private void R0550_00_LER_OPCAOPAGVA_SECTION()
        {
            /*" -1955- MOVE 'R0550-00-LER-OPCAOPAGVA' TO PARAGRAFO. */
            _.Move("R0550-00-LER-OPCAOPAGVA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1957- MOVE 'SELECT OPCAOPAGVA' TO COMANDO. */
            _.Move("SELECT OPCAOPAGVA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1961- MOVE NUM-CERTIFICADO OF DCLPROPOSTAS-VA TO OPPAGVA-NUM-CERTIFICADO. */
            _.Move(PROPVA.DCLPROPOSTAS_VA.NUM_CERTIFICADO, OPPAGVA.DCLOPCAO_PAG_VIDAZUL.OPPAGVA_NUM_CERTIFICADO);

            /*" -1962- ACCEPT WS-HORA-INI FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_INI);

            /*" -1965- COMPUTE SIT = (HI * 60 * 60) + (MI * 60) + SI + (DI / 100) */
            WS_HORAS.SIT.Value = (WS_HORAS.WS_HORA_INI_R.HI * 60 * 60) + (WS_HORAS.WS_HORA_INI_R.MI * 60) + WS_HORAS.WS_HORA_INI_R.SI + (WS_HORAS.WS_HORA_INI_R.DI / 100f);

            /*" -1992- PERFORM R0550_00_LER_OPCAOPAGVA_DB_SELECT_1 */

            R0550_00_LER_OPCAOPAGVA_DB_SELECT_1();

            /*" -1996- ACCEPT WS-HORA-FIM FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_FIM);

            /*" -1997- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF + (DF / 100) */
            WS_HORAS.SFT.Value = (WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (WS_HORAS.WS_HORA_FIM_R.MF * 60) + WS_HORAS.WS_HORA_FIM_R.SF + (WS_HORAS.WS_HORA_FIM_R.DF / 100f);

            /*" -1998- SUBTRACT SIT FROM SFT */
            WS_HORAS.SFT.Value = WS_HORAS.SFT - WS_HORAS.SIT;

            /*" -1999- ADD SFT TO STT(13) */
            TOTAIS_ROT.FILLER_20[13].STT.Value = TOTAIS_ROT.FILLER_20[13].STT + WS_HORAS.SFT;

            /*" -2002- ADD 1 TO SQT(13) */
            TOTAIS_ROT.FILLER_20[13].SQT.Value = TOTAIS_ROT.FILLER_20[13].SQT + 1;

            /*" -2003- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -2004- DISPLAY 'PF0619B - FIM ANORMAL' */
                _.Display($"PF0619B - FIM ANORMAL");

                /*" -2005- DISPLAY '          ERRO SELECT OPCAOPAGVA' */
                _.Display($"          ERRO SELECT OPCAOPAGVA");

                /*" -2007- DISPLAY '          NUMERO CERTIFICADO.....' OPPAGVA-NUM-CERTIFICADO */
                _.Display($"          NUMERO CERTIFICADO.....{OPPAGVA.DCLOPCAO_PAG_VIDAZUL.OPPAGVA_NUM_CERTIFICADO}");

                /*" -2009- DISPLAY '          SQLCODE................ ' SQLCODE */
                _.Display($"          SQLCODE................ {DB.SQLCODE}");

                /*" -2010- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -2010- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R0550-00-LER-OPCAOPAGVA-DB-SELECT-1 */
        public void R0550_00_LER_OPCAOPAGVA_DB_SELECT_1()
        {
            /*" -1992- EXEC SQL SELECT NUM_CERTIFICADO , DATA_INIVIGENCIA , DATA_TERVIGENCIA , OPCAO_PAGAMENTO , DIA_DEBITO , COD_AGENCIA_DEBITO , OPE_CONTA_DEBITO , NUM_CONTA_DEBITO , DIG_CONTA_DEBITO INTO :OPPAGVA-NUM-CERTIFICADO , :OPPAGVA-DATA-INIVIGENCIA , :OPPAGVA-DATA-TERVIGENCIA , :OPPAGVA-OPCAO-PAGAMENTO , :OPPAGVA-DIA-DEBITO , :OPPAGVA-COD-AGENCIA-DEBITO:VIND-AGEDEB, :OPPAGVA-OPE-CONTA-DEBITO:VIND-OPRCTADEB, :OPPAGVA-NUM-CONTA-DEBITO:VIND-NUMCTADEB, :OPPAGVA-DIG-CONTA-DEBITO:VIND-DIGCTADEB FROM SEGUROS.OPCAO_PAG_VIDAZUL WHERE NUM_CERTIFICADO = :OPPAGVA-NUM-CERTIFICADO AND DATA_TERVIGENCIA IN (:HOST-DT-TERVIG1, :HOST-DT-TERVIG2) WITH UR END-EXEC. */

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
            /*" -2020- MOVE 'R0570-00-LER-COMISSAO' TO PARAGRAFO. */
            _.Move("R0570-00-LER-COMISSAO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2022- MOVE 'SELECT FUNDOCOMISVA' TO COMANDO. */
            _.Move("SELECT FUNDOCOMISVA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2025- MOVE NUM-CERTIFICADO OF DCLPROPOSTAS-VA TO NUM-CERTIFICADO OF DCLFUNDO-COMISSAO-VA */
            _.Move(PROPVA.DCLPROPOSTAS_VA.NUM_CERTIFICADO, FDCOMVA.DCLFUNDO_COMISSAO_VA.NUM_CERTIFICADO);

            /*" -2029- MOVE 1101 TO COD-OPERACAO OF DCLFUNDO-COMISSAO-VA */
            _.Move(1101, FDCOMVA.DCLFUNDO_COMISSAO_VA.COD_OPERACAO);

            /*" -2030- ACCEPT WS-HORA-INI FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_INI);

            /*" -2033- COMPUTE SIT = (HI * 60 * 60) + (MI * 60) + SI + (DI / 100) */
            WS_HORAS.SIT.Value = (WS_HORAS.WS_HORA_INI_R.HI * 60 * 60) + (WS_HORAS.WS_HORA_INI_R.MI * 60) + WS_HORAS.WS_HORA_INI_R.SI + (WS_HORAS.WS_HORA_INI_R.DI / 100f);

            /*" -2044- PERFORM R0570_00_LER_COMISSAO_DB_DECLARE_1 */

            R0570_00_LER_COMISSAO_DB_DECLARE_1();

            /*" -2048- ACCEPT WS-HORA-FIM FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_FIM);

            /*" -2049- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF + (DF / 100) */
            WS_HORAS.SFT.Value = (WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (WS_HORAS.WS_HORA_FIM_R.MF * 60) + WS_HORAS.WS_HORA_FIM_R.SF + (WS_HORAS.WS_HORA_FIM_R.DF / 100f);

            /*" -2050- SUBTRACT SIT FROM SFT */
            WS_HORAS.SFT.Value = WS_HORAS.SFT - WS_HORAS.SIT;

            /*" -2051- ADD SFT TO STT(14) */
            TOTAIS_ROT.FILLER_20[14].STT.Value = TOTAIS_ROT.FILLER_20[14].STT + WS_HORAS.SFT;

            /*" -2054- ADD 1 TO SQT(14) */
            TOTAIS_ROT.FILLER_20[14].SQT.Value = TOTAIS_ROT.FILLER_20[14].SQT + 1;

            /*" -2055- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -2056- DISPLAY 'PF0619B - FIM ANORMAL' */
                _.Display($"PF0619B - FIM ANORMAL");

                /*" -2057- DISPLAY '          ERRO DECLARE CURSOR FUNDOCOMISVA' */
                _.Display($"          ERRO DECLARE CURSOR FUNDOCOMISVA");

                /*" -2059- DISPLAY '          NUMERO CERTIFICADO.............. ' NUM-CERTIFICADO OF DCLFUNDO-COMISSAO-VA */
                _.Display($"          NUMERO CERTIFICADO.............. {FDCOMVA.DCLFUNDO_COMISSAO_VA.NUM_CERTIFICADO}");

                /*" -2061- DISPLAY '          SQLCODE......................... ' SQLCODE */
                _.Display($"          SQLCODE......................... {DB.SQLCODE}");

                /*" -2062- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -2065- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


            /*" -2066- ACCEPT WS-HORA-INI FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_INI);

            /*" -2069- COMPUTE SIT = (HI * 60 * 60) + (MI * 60) + SI + (DI / 100) */
            WS_HORAS.SIT.Value = (WS_HORAS.WS_HORA_INI_R.HI * 60 * 60) + (WS_HORAS.WS_HORA_INI_R.MI * 60) + WS_HORAS.WS_HORA_INI_R.SI + (WS_HORAS.WS_HORA_INI_R.DI / 100f);

            /*" -2069- PERFORM R0570_00_LER_COMISSAO_DB_OPEN_1 */

            R0570_00_LER_COMISSAO_DB_OPEN_1();

            /*" -2073- ACCEPT WS-HORA-FIM FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_FIM);

            /*" -2074- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF + (DF / 100) */
            WS_HORAS.SFT.Value = (WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (WS_HORAS.WS_HORA_FIM_R.MF * 60) + WS_HORAS.WS_HORA_FIM_R.SF + (WS_HORAS.WS_HORA_FIM_R.DF / 100f);

            /*" -2075- SUBTRACT SIT FROM SFT */
            WS_HORAS.SFT.Value = WS_HORAS.SFT - WS_HORAS.SIT;

            /*" -2076- ADD SFT TO STT(15) */
            TOTAIS_ROT.FILLER_20[15].STT.Value = TOTAIS_ROT.FILLER_20[15].STT + WS_HORAS.SFT;

            /*" -2079- ADD 1 TO SQT(15) */
            TOTAIS_ROT.FILLER_20[15].SQT.Value = TOTAIS_ROT.FILLER_20[15].SQT + 1;

            /*" -2080- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -2081- DISPLAY 'PF0619B - FIM ANORMAL' */
                _.Display($"PF0619B - FIM ANORMAL");

                /*" -2082- DISPLAY '          ERRO OPEN CURSOR FUNDOCOMISVA' */
                _.Display($"          ERRO OPEN CURSOR FUNDOCOMISVA");

                /*" -2084- DISPLAY '          NUMERO CERTIFICADO........... ' NUM-CERTIFICADO OF DCLFUNDO-COMISSAO-VA */
                _.Display($"          NUMERO CERTIFICADO........... {FDCOMVA.DCLFUNDO_COMISSAO_VA.NUM_CERTIFICADO}");

                /*" -2086- DISPLAY '          SQLCODE...................... ' SQLCODE */
                _.Display($"          SQLCODE...................... {DB.SQLCODE}");

                /*" -2087- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -2090- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


            /*" -2091- ACCEPT WS-HORA-INI FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_INI);

            /*" -2094- COMPUTE SIT = (HI * 60 * 60) + (MI * 60) + SI + (DI / 100) */
            WS_HORAS.SIT.Value = (WS_HORAS.WS_HORA_INI_R.HI * 60 * 60) + (WS_HORAS.WS_HORA_INI_R.MI * 60) + WS_HORAS.WS_HORA_INI_R.SI + (WS_HORAS.WS_HORA_INI_R.DI / 100f);

            /*" -2100- PERFORM R0570_00_LER_COMISSAO_DB_FETCH_1 */

            R0570_00_LER_COMISSAO_DB_FETCH_1();

            /*" -2104- ACCEPT WS-HORA-FIM FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_FIM);

            /*" -2105- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF + (DF / 100) */
            WS_HORAS.SFT.Value = (WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (WS_HORAS.WS_HORA_FIM_R.MF * 60) + WS_HORAS.WS_HORA_FIM_R.SF + (WS_HORAS.WS_HORA_FIM_R.DF / 100f);

            /*" -2106- SUBTRACT SIT FROM SFT */
            WS_HORAS.SFT.Value = WS_HORAS.SFT - WS_HORAS.SIT;

            /*" -2107- ADD SFT TO STT(16) */
            TOTAIS_ROT.FILLER_20[16].STT.Value = TOTAIS_ROT.FILLER_20[16].STT + WS_HORAS.SFT;

            /*" -2110- ADD 1 TO SQT(16) */
            TOTAIS_ROT.FILLER_20[16].SQT.Value = TOTAIS_ROT.FILLER_20[16].SQT + 1;

            /*" -2111- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -2112- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2115- MOVE ZEROS TO VAL-COMISSAO-VG OF DCLFUNDO-COMISSAO-VA, VAL-COMISSAO-AP OF DCLFUNDO-COMISSAO-VA */
                    _.Move(0, FDCOMVA.DCLFUNDO_COMISSAO_VA.VAL_COMISSAO_VG, FDCOMVA.DCLFUNDO_COMISSAO_VA.VAL_COMISSAO_AP);

                    /*" -2116- ELSE */
                }
                else
                {


                    /*" -2117- DISPLAY 'PF0619B - FIM ANORMAL' */
                    _.Display($"PF0619B - FIM ANORMAL");

                    /*" -2118- DISPLAY '          ERRO SELECT CURSOR FUNDOCOMISVA' */
                    _.Display($"          ERRO SELECT CURSOR FUNDOCOMISVA");

                    /*" -2120- DISPLAY '          NUMERO CERTIFICADO............. ' NUM-CERTIFICADO OF DCLFUNDO-COMISSAO-VA */
                    _.Display($"          NUMERO CERTIFICADO............. {FDCOMVA.DCLFUNDO_COMISSAO_VA.NUM_CERTIFICADO}");

                    /*" -2122- DISPLAY '          SQLCODE........................ ' SQLCODE */
                    _.Display($"          SQLCODE........................ {DB.SQLCODE}");

                    /*" -2123- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -2126- PERFORM R9999-00-FINALIZAR. */

                    R9999_00_FINALIZAR_SECTION();
                }

            }


            /*" -2127- ACCEPT WS-HORA-INI FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_INI);

            /*" -2130- COMPUTE SIT = (HI * 60 * 60) + (MI * 60) + SI + (DI / 100) */
            WS_HORAS.SIT.Value = (WS_HORAS.WS_HORA_INI_R.HI * 60 * 60) + (WS_HORAS.WS_HORA_INI_R.MI * 60) + WS_HORAS.WS_HORA_INI_R.SI + (WS_HORAS.WS_HORA_INI_R.DI / 100f);

            /*" -2130- PERFORM R0570_00_LER_COMISSAO_DB_CLOSE_1 */

            R0570_00_LER_COMISSAO_DB_CLOSE_1();

            /*" -2134- ACCEPT WS-HORA-FIM FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_FIM);

            /*" -2135- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF + (DF / 100) */
            WS_HORAS.SFT.Value = (WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (WS_HORAS.WS_HORA_FIM_R.MF * 60) + WS_HORAS.WS_HORA_FIM_R.SF + (WS_HORAS.WS_HORA_FIM_R.DF / 100f);

            /*" -2136- SUBTRACT SIT FROM SFT */
            WS_HORAS.SFT.Value = WS_HORAS.SFT - WS_HORAS.SIT;

            /*" -2137- ADD SFT TO STT(17) */
            TOTAIS_ROT.FILLER_20[17].STT.Value = TOTAIS_ROT.FILLER_20[17].STT + WS_HORAS.SFT;

            /*" -2140- ADD 1 TO SQT(17) */
            TOTAIS_ROT.FILLER_20[17].SQT.Value = TOTAIS_ROT.FILLER_20[17].SQT + 1;

            /*" -2141- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -2142- DISPLAY 'PF0619B - FIM ANORMAL' */
                _.Display($"PF0619B - FIM ANORMAL");

                /*" -2143- DISPLAY '          ERRO CLOSE CURSOR FUNDOCOMISVA' */
                _.Display($"          ERRO CLOSE CURSOR FUNDOCOMISVA");

                /*" -2145- DISPLAY '          NUMERO CERTIFICADO............ ' NUM-CERTIFICADO OF DCLFUNDO-COMISSAO-VA */
                _.Display($"          NUMERO CERTIFICADO............ {FDCOMVA.DCLFUNDO_COMISSAO_VA.NUM_CERTIFICADO}");

                /*" -2147- DISPLAY '          SQLCODE....................... ' SQLCODE */
                _.Display($"          SQLCODE....................... {DB.SQLCODE}");

                /*" -2148- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -2148- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R0570-00-LER-COMISSAO-DB-OPEN-1 */
        public void R0570_00_LER_COMISSAO_DB_OPEN_1()
        {
            /*" -2069- EXEC SQL OPEN FUNDOCOMISVA END-EXEC. */

            FUNDOCOMISVA.Open();

        }

        [StopWatch]
        /*" R0800-00-CURSOR-BENEFICIARIOS-DB-DECLARE-1 */
        public void R0800_00_CURSOR_BENEFICIARIOS_DB_DECLARE_1()
        {
            /*" -2752- EXEC SQL DECLARE BENEFICIARIOS CURSOR FOR SELECT NUM_APOLICE , COD_SUBGRUPO , COD_FONTE , NUM_PROPOSTA , NUM_BENEFICIARIO , NOME_BENEFICIARIO , GRAU_PARENTESCO , PCT_PART_BENEFICIA FROM SEGUROS.BENEFICIARIOS_PROP WHERE NUM_APOLICE = :BENEFPRO-NUM-APOLICE AND COD_SUBGRUPO = :BENEFPRO-COD-SUBGRUPO AND COD_FONTE = :BENEFPRO-COD-FONTE AND NUM_PROPOSTA = :BENEFPRO-NUM-PROPOSTA WITH UR END-EXEC. */
            BENEFICIARIOS = new PF0619B_BENEFICIARIOS(true);
            string GetQuery_BENEFICIARIOS()
            {
                var query = @$"SELECT NUM_APOLICE
							, 
							COD_SUBGRUPO
							, 
							COD_FONTE
							, 
							NUM_PROPOSTA
							, 
							NUM_BENEFICIARIO
							, 
							NOME_BENEFICIARIO
							, 
							GRAU_PARENTESCO
							, 
							PCT_PART_BENEFICIA 
							FROM SEGUROS.BENEFICIARIOS_PROP 
							WHERE NUM_APOLICE = 
							'{BENEFPRO.DCLBENEFICIARIOS_PROP.BENEFPRO_NUM_APOLICE}' 
							AND COD_SUBGRUPO = 
							'{BENEFPRO.DCLBENEFICIARIOS_PROP.BENEFPRO_COD_SUBGRUPO}' 
							AND COD_FONTE = 
							'{BENEFPRO.DCLBENEFICIARIOS_PROP.BENEFPRO_COD_FONTE}' 
							AND NUM_PROPOSTA = 
							'{BENEFPRO.DCLBENEFICIARIOS_PROP.BENEFPRO_NUM_PROPOSTA}'";

                return query;
            }
            BENEFICIARIOS.GetQueryEvent += GetQuery_BENEFICIARIOS;

        }

        [StopWatch]
        /*" R0570-00-LER-COMISSAO-DB-FETCH-1 */
        public void R0570_00_LER_COMISSAO_DB_FETCH_1()
        {
            /*" -2100- EXEC SQL FETCH FUNDOCOMISVA INTO :DCLFUNDO-COMISSAO-VA.NUM-CERTIFICADO , :DCLFUNDO-COMISSAO-VA.VAL-COMISSAO-VG , :DCLFUNDO-COMISSAO-VA.VAL-COMISSAO-AP END-EXEC. */

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
            /*" -2130- EXEC SQL CLOSE FUNDOCOMISVA END-EXEC. */

            FUNDOCOMISVA.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0570_SAIDA*/

        [StopWatch]
        /*" R0580-00-OBTER-VAL-TARIFA-SECTION */
        private void R0580_00_OBTER_VAL_TARIFA_SECTION()
        {
            /*" -2158- MOVE 'R0580-00-OBTER-VAL-TARIFA' TO PARAGRAFO. */
            _.Move("R0580-00-OBTER-VAL-TARIFA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2160- MOVE 'SELECT TARIFA-BALCAO-CEF' TO COMANDO. */
            _.Move("SELECT TARIFA-BALCAO-CEF", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2164- MOVE NUM-CERTIFICADO OF DCLPROPOSTAS-VA TO NUM-CERTIFICADO OF DCLTARIFA-BALCAO-CEF. */
            _.Move(PROPVA.DCLPROPOSTAS_VA.NUM_CERTIFICADO, TARIBCEF.DCLTARIFA_BALCAO_CEF.NUM_CERTIFICADO);

            /*" -2165- ACCEPT WS-HORA-INI FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_INI);

            /*" -2168- COMPUTE SIT = (HI * 60 * 60) + (MI * 60) + SI + (DI / 100) */
            WS_HORAS.SIT.Value = (WS_HORAS.WS_HORA_INI_R.HI * 60 * 60) + (WS_HORAS.WS_HORA_INI_R.MI * 60) + WS_HORAS.WS_HORA_INI_R.SI + (WS_HORAS.WS_HORA_INI_R.DI / 100f);

            /*" -2180- PERFORM R0580_00_OBTER_VAL_TARIFA_DB_SELECT_1 */

            R0580_00_OBTER_VAL_TARIFA_DB_SELECT_1();

            /*" -2184- ACCEPT WS-HORA-FIM FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_FIM);

            /*" -2185- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF + (DF / 100) */
            WS_HORAS.SFT.Value = (WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (WS_HORAS.WS_HORA_FIM_R.MF * 60) + WS_HORAS.WS_HORA_FIM_R.SF + (WS_HORAS.WS_HORA_FIM_R.DF / 100f);

            /*" -2186- SUBTRACT SIT FROM SFT */
            WS_HORAS.SFT.Value = WS_HORAS.SFT - WS_HORAS.SIT;

            /*" -2187- ADD SFT TO STT(18) */
            TOTAIS_ROT.FILLER_20[18].STT.Value = TOTAIS_ROT.FILLER_20[18].STT + WS_HORAS.SFT;

            /*" -2190- ADD 1 TO SQT(18) */
            TOTAIS_ROT.FILLER_20[18].SQT.Value = TOTAIS_ROT.FILLER_20[18].SQT + 1;

            /*" -2191- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -2192- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2193- MOVE ZEROS TO VAL-TARIFA OF DCLTARIFA-BALCAO-CEF */
                    _.Move(0, TARIBCEF.DCLTARIFA_BALCAO_CEF.VAL_TARIFA);

                    /*" -2194- ELSE */
                }
                else
                {


                    /*" -2195- DISPLAY 'PF0619B - FIM ANORMAL' */
                    _.Display($"PF0619B - FIM ANORMAL");

                    /*" -2196- DISPLAY '          ERRO SELECT TAB. TARIFA-BALCAO-CEF' */
                    _.Display($"          ERRO SELECT TAB. TARIFA-BALCAO-CEF");

                    /*" -2198- DISPLAY '          NUMERO CERTIFICADO........ ' NUM-CERTIFICADO OF DCLTARIFA-BALCAO-CEF */
                    _.Display($"          NUMERO CERTIFICADO........ {TARIBCEF.DCLTARIFA_BALCAO_CEF.NUM_CERTIFICADO}");

                    /*" -2200- DISPLAY '          SQLCODE................... ' SQLCODE */
                    _.Display($"          SQLCODE................... {DB.SQLCODE}");

                    /*" -2201- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -2201- PERFORM R9999-00-FINALIZAR. */

                    R9999_00_FINALIZAR_SECTION();
                }

            }


        }

        [StopWatch]
        /*" R0580-00-OBTER-VAL-TARIFA-DB-SELECT-1 */
        public void R0580_00_OBTER_VAL_TARIFA_DB_SELECT_1()
        {
            /*" -2180- EXEC SQL SELECT VAL_TARIFA INTO :DCLTARIFA-BALCAO-CEF.VAL-TARIFA FROM SEGUROS.TARIFA_BALCAO_CEF WHERE COD_EMPRESA = 0 AND NUM_MATRICULA = 9999999 AND TIPO_FUNCIONARIO = '5' AND NUM_CERTIFICADO = :DCLTARIFA-BALCAO-CEF.NUM-CERTIFICADO WITH UR END-EXEC. */

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
            /*" -2212- MOVE 'R0600-00-GERAR-REGISTRO-TP1' TO PARAGRAFO. */
            _.Move("R0600-00-GERAR-REGISTRO-TP1", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2215- MOVE SPACES TO REG-CLIENTES, REG-PRP-SASSE. */
            _.Move("", LBFPF011.REG_CLIENTES, REG_PRP_SASSE);

            /*" -2218- MOVE '1' TO R1-TIPO-REG OF REG-CLIENTES. */
            _.Move("1", LBFPF011.REG_CLIENTES.R1_TIPO_REG);

            /*" -2222- MOVE W-NUM-PROPOSTA-NOVA TO R1-NUM-PROPOSTA OF REG-CLIENTES. */
            _.Move(WAREA_AUXILIAR.W_NUM_PROPOSTA_NOVA, LBFPF011.REG_CLIENTES.R1_NUM_PROPOSTA);

            /*" -2225- MOVE CGCCPF OF DCLCLIENTES TO R1-CGC-CPF OF REG-CLIENTES. */
            _.Move(CLIENTE.DCLCLIENTES.CGCCPF, LBFPF011.REG_CLIENTES.R1_CGC_CPF);

            /*" -2226- IF VIND-DTNASCI LESS ZEROS */

            if (VIND_DTNASCI < 00)
            {

                /*" -2228- MOVE ZEROS TO R1-DATA-NASCIMENTO OF REG-CLIENTES */
                _.Move(0, LBFPF011.REG_CLIENTES.R1_DATA_NASCIMENTO);

                /*" -2229- ELSE */
            }
            else
            {


                /*" -2232- MOVE DATA-NASCIMENTO OF DCLCLIENTES TO W-DATA-SQL */
                _.Move(CLIENTE.DCLCLIENTES.DATA_NASCIMENTO, WAREA_AUXILIAR.W_DATA_SQL);

                /*" -2233- MOVE W-DIA-SQL TO W-DIA-TRABALHO */
                _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_DIA_SQL, WAREA_AUXILIAR.FILLER_2.W_DIA_TRABALHO);

                /*" -2234- MOVE W-MES-SQL TO W-MES-TRABALHO */
                _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_MES_SQL, WAREA_AUXILIAR.FILLER_2.W_MES_TRABALHO);

                /*" -2235- MOVE W-ANO-SQL TO W-ANO-TRABALHO */
                _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_ANO_SQL, WAREA_AUXILIAR.FILLER_2.W_ANO_TRABALHO);

                /*" -2238- MOVE W-DATA-TRABALHO TO R1-DATA-NASCIMENTO OF REG-CLIENTES. */
                _.Move(WAREA_AUXILIAR.W_DATA_TRABALHO, LBFPF011.REG_CLIENTES.R1_DATA_NASCIMENTO);
            }


            /*" -2241- MOVE NOME-RAZAO OF DCLCLIENTES TO R1-NOME-PESSOA OF REG-CLIENTES. */
            _.Move(CLIENTE.DCLCLIENTES.NOME_RAZAO, LBFPF011.REG_CLIENTES.R1_NOME_PESSOA);

            /*" -2242- IF TIPO-PESSOA OF DCLCLIENTES EQUAL 'F' */

            if (CLIENTE.DCLCLIENTES.TIPO_PESSOA == "F")
            {

                /*" -2243- MOVE 1 TO R1-TIPO-PESSOA OF REG-CLIENTES */
                _.Move(1, LBFPF011.REG_CLIENTES.R1_TIPO_PESSOA);

                /*" -2244- ELSE */
            }
            else
            {


                /*" -2246- MOVE 2 TO R1-TIPO-PESSOA OF REG-CLIENTES. */
                _.Move(2, LBFPF011.REG_CLIENTES.R1_TIPO_PESSOA);
            }


            /*" -2251- MOVE SPACES TO R1-UF-EXPEDIDORA OF REG-CLIENTES R1-CODIGO-SEGMENTO OF REG-CLIENTES R1-ORGAO-EXPEDIDOR OF REG-CLIENTES. */
            _.Move("", LBFPF011.REG_CLIENTES.R1_UF_EXPEDIDORA, LBFPF011.REG_CLIENTES.R1_CODIGO_SEGMENTO, LBFPF011.REG_CLIENTES.R1_ORGAO_EXPEDIDOR);

            /*" -2255- MOVE ZEROS TO R1-NUM-IDENTIDADE OF REG-CLIENTES R1-DATA-EXPEDICAO-RG OF REG-CLIENTES. */
            _.Move(0, LBFPF011.REG_CLIENTES.R1_NUM_IDENTIDADE, LBFPF011.REG_CLIENTES.R1_DATA_EXPEDICAO_RG);

            /*" -2257- MOVE ZERO TO W-OBTER-DADOS-RG. */
            _.Move(0, WAREA_AUXILIAR.W_OBTER_DADOS_RG);

            /*" -2259- PERFORM R0620-00-DADOS-RG. */

            R0620_00_DADOS_RG_SECTION();

            /*" -2260- IF OBTEVE-DADOS-RG */

            if (WAREA_AUXILIAR.W_OBTER_DADOS_RG["OBTEVE_DADOS_RG"])
            {

                /*" -2263- MOVE GEDOCCLI-COD-IDENTIFICACAO TO R1-NUM-IDENTIDADE OF REG-CLIENTES */
                _.Move(GEDOCCLI.DCLGE_DOC_CLIENTE.GEDOCCLI_COD_IDENTIFICACAO, LBFPF011.REG_CLIENTES.R1_NUM_IDENTIDADE);

                /*" -2266- MOVE GEDOCCLI-NOM-ORGAO-EXP TO W-NOM-ORGAO-EXP */
                _.Move(GEDOCCLI.DCLGE_DOC_CLIENTE.GEDOCCLI_NOM_ORGAO_EXP, WAREA_AUXILIAR.W_NOM_ORGAO_EXP);

                /*" -2269- MOVE W-ORGAO-EXPEDIDOR TO R1-ORGAO-EXPEDIDOR OF REG-CLIENTES */
                _.Move(WAREA_AUXILIAR.FILLER_9.W_ORGAO_EXPEDIDOR, LBFPF011.REG_CLIENTES.R1_ORGAO_EXPEDIDOR);

                /*" -2271- MOVE GEDOCCLI-DTH-EXPEDICAO TO W-DATA-SQL */
                _.Move(GEDOCCLI.DCLGE_DOC_CLIENTE.GEDOCCLI_DTH_EXPEDICAO, WAREA_AUXILIAR.W_DATA_SQL);

                /*" -2272- MOVE W-DIA-SQL TO W-DIA-TRABALHO */
                _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_DIA_SQL, WAREA_AUXILIAR.FILLER_2.W_DIA_TRABALHO);

                /*" -2273- MOVE W-MES-SQL TO W-MES-TRABALHO */
                _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_MES_SQL, WAREA_AUXILIAR.FILLER_2.W_MES_TRABALHO);

                /*" -2274- MOVE W-ANO-SQL TO W-ANO-TRABALHO */
                _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_ANO_SQL, WAREA_AUXILIAR.FILLER_2.W_ANO_TRABALHO);

                /*" -2277- MOVE W-DATA-TRABALHO TO R1-DATA-EXPEDICAO-RG OF REG-CLIENTES */
                _.Move(WAREA_AUXILIAR.W_DATA_TRABALHO, LBFPF011.REG_CLIENTES.R1_DATA_EXPEDICAO_RG);

                /*" -2278- IF VIND-COD-UF LESS ZERO */

                if (VIND_COD_UF < 00)
                {

                    /*" -2280- MOVE SPACES TO R1-UF-EXPEDIDORA OF REG-CLIENTES */
                    _.Move("", LBFPF011.REG_CLIENTES.R1_UF_EXPEDIDORA);

                    /*" -2281- ELSE */
                }
                else
                {


                    /*" -2284- MOVE GEDOCCLI-COD-UF TO R1-UF-EXPEDIDORA OF REG-CLIENTES. */
                    _.Move(GEDOCCLI.DCLGE_DOC_CLIENTE.GEDOCCLI_COD_UF, LBFPF011.REG_CLIENTES.R1_UF_EXPEDIDORA);
                }

            }


            /*" -2285- IF ESTADO-CIVIL OF DCLPROPOSTAS-VA EQUAL 'S' */

            if (PROPVA.DCLPROPOSTAS_VA.ESTADO_CIVIL == "S")
            {

                /*" -2286- MOVE 1 TO R1-ESTADO-CIVIL OF REG-CLIENTES */
                _.Move(1, LBFPF011.REG_CLIENTES.R1_ESTADO_CIVIL);

                /*" -2287- ELSE */
            }
            else
            {


                /*" -2288- IF ESTADO-CIVIL OF DCLPROPOSTAS-VA EQUAL 'C' */

                if (PROPVA.DCLPROPOSTAS_VA.ESTADO_CIVIL == "C")
                {

                    /*" -2289- MOVE 2 TO R1-ESTADO-CIVIL OF REG-CLIENTES */
                    _.Move(2, LBFPF011.REG_CLIENTES.R1_ESTADO_CIVIL);

                    /*" -2290- ELSE */
                }
                else
                {


                    /*" -2291- IF ESTADO-CIVIL OF DCLPROPOSTAS-VA EQUAL 'V' */

                    if (PROPVA.DCLPROPOSTAS_VA.ESTADO_CIVIL == "V")
                    {

                        /*" -2292- MOVE 3 TO R1-ESTADO-CIVIL OF REG-CLIENTES */
                        _.Move(3, LBFPF011.REG_CLIENTES.R1_ESTADO_CIVIL);

                        /*" -2293- ELSE */
                    }
                    else
                    {


                        /*" -2295- MOVE 4 TO R1-ESTADO-CIVIL OF REG-CLIENTES. */
                        _.Move(4, LBFPF011.REG_CLIENTES.R1_ESTADO_CIVIL);
                    }

                }

            }


            /*" -2296- IF IDE-SEXO OF DCLPROPOSTAS-VA EQUAL 'M' */

            if (PROPVA.DCLPROPOSTAS_VA.IDE_SEXO == "M")
            {

                /*" -2297- MOVE 1 TO R1-IDE-SEXO OF REG-CLIENTES */
                _.Move(1, LBFPF011.REG_CLIENTES.R1_IDE_SEXO);

                /*" -2298- ELSE */
            }
            else
            {


                /*" -2300- MOVE 2 TO R1-IDE-SEXO OF REG-CLIENTES. */
                _.Move(2, LBFPF011.REG_CLIENTES.R1_IDE_SEXO);
            }


            /*" -2303- MOVE COD-CBO-TIT TO R1-COD-CBO OF REG-CLIENTES. */
            _.Move(COD_CBO_TIT, LBFPF011.REG_CLIENTES.R1_COD_CBO);

            /*" -2306- MOVE ENDERECO-DDD OF DCLENDERECOS TO R1-DDD(1). */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_DDD, LBFPF011.REG_CLIENTES.R1_TELEFONE[1].R1_DDD);

            /*" -2309- MOVE ENDERECO-TELEFONE OF DCLENDERECOS TO R1-NUM-FONE(1). */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_TELEFONE, LBFPF011.REG_CLIENTES.R1_TELEFONE[1].R1_NUM_FONE);

            /*" -2313- MOVE ZEROS TO R1-DDD(2) R1-DDD(3). */
            _.Move(0, LBFPF011.REG_CLIENTES.R1_TELEFONE[2].R1_DDD, LBFPF011.REG_CLIENTES.R1_TELEFONE[3].R1_DDD);

            /*" -2317- MOVE ZEROS TO R1-NUM-FONE(2) R1-NUM-FONE(3). */
            _.Move(0, LBFPF011.REG_CLIENTES.R1_TELEFONE[2].R1_NUM_FONE, LBFPF011.REG_CLIENTES.R1_TELEFONE[3].R1_NUM_FONE);

            /*" -2318- IF VIND-NOME-ESPOSA LESS ZEROS */

            if (VIND_NOME_ESPOSA < 00)
            {

                /*" -2320- MOVE SPACES TO R1-NOME-CONJUGE OF REG-CLIENTES */
                _.Move("", LBFPF011.REG_CLIENTES.R1_NOME_CONJUGE);

                /*" -2321- ELSE */
            }
            else
            {


                /*" -2324- MOVE NOME-ESPOSA OF DCLPROPOSTAS-VA TO R1-NOME-CONJUGE OF REG-CLIENTES. */
                _.Move(PROPVA.DCLPROPOSTAS_VA.NOME_ESPOSA, LBFPF011.REG_CLIENTES.R1_NOME_CONJUGE);
            }


            /*" -2325- IF VIND-DTNASC-ESPOSA LESS ZEROS */

            if (VIND_DTNASC_ESPOSA < 00)
            {

                /*" -2327- MOVE ZEROS TO R1-DTNASC-CONJUGE OF REG-CLIENTES */
                _.Move(0, LBFPF011.REG_CLIENTES.R1_DTNASC_CONJUGE);

                /*" -2329- MOVE -1 TO VIND-DTNASC-ESPOSA */
                _.Move(-1, VIND_DTNASC_ESPOSA);

                /*" -2330- ELSE */
            }
            else
            {


                /*" -2333- MOVE DTNASC-ESPOSA OF DCLPROPOSTAS-VA TO W-DATA-SQL */
                _.Move(PROPVA.DCLPROPOSTAS_VA.DTNASC_ESPOSA, WAREA_AUXILIAR.W_DATA_SQL);

                /*" -2334- MOVE W-DIA-SQL TO W-DIA-TRABALHO */
                _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_DIA_SQL, WAREA_AUXILIAR.FILLER_2.W_DIA_TRABALHO);

                /*" -2335- MOVE W-MES-SQL TO W-MES-TRABALHO */
                _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_MES_SQL, WAREA_AUXILIAR.FILLER_2.W_MES_TRABALHO);

                /*" -2336- MOVE W-ANO-SQL TO W-ANO-TRABALHO */
                _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_ANO_SQL, WAREA_AUXILIAR.FILLER_2.W_ANO_TRABALHO);

                /*" -2339- MOVE W-DATA-TRABALHO TO R1-DTNASC-CONJUGE OF REG-CLIENTES. */
                _.Move(WAREA_AUXILIAR.W_DATA_TRABALHO, LBFPF011.REG_CLIENTES.R1_DTNASC_CONJUGE);
            }


            /*" -2342- MOVE COD-CBO-CONJ TO R1-CBO-CONJUGE OF REG-CLIENTES. */
            _.Move(COD_CBO_CONJ, LBFPF011.REG_CLIENTES.R1_CBO_CONJUGE);

            /*" -2345- MOVE SPACES TO R1-EMAIL OF REG-CLIENTES. */
            _.Move("", LBFPF011.REG_CLIENTES.R1_EMAIL);

            /*" -2348- MOVE PROFIS-ESPOSA OF DCLPROPOSTAS-VA TO R1-DESCRICAO-PROFISSAO OF REG-CLIENTES. */
            _.Move(PROPVA.DCLPROPOSTAS_VA.PROFIS_ESPOSA, LBFPF011.REG_CLIENTES.R1_DESCRICAO_PROFISSAO);

            /*" -2350- WRITE REG-PRP-SASSE FROM REG-CLIENTES. */
            _.Move(LBFPF011.REG_CLIENTES.GetMoveValues(), REG_PRP_SASSE);

            MOVTO_PRP_SASSE.Write(REG_PRP_SASSE.GetMoveValues().ToString());

            /*" -2350- ADD 1 TO W-QTD-LD-TIPO-1. */
            WAREA_AUXILIAR.W_QTD_LD_TIPO_1.Value = WAREA_AUXILIAR.W_QTD_LD_TIPO_1 + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0600_SAIDA*/

        [StopWatch]
        /*" R0620-00-DADOS-RG-SECTION */
        private void R0620_00_DADOS_RG_SECTION()
        {
            /*" -2360- MOVE 'R0620-00-DADOS-RG' TO PARAGRAFO. */
            _.Move("R0620-00-DADOS-RG", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2362- MOVE 'SELECT GE_DOC_CLIENTES' TO COMANDO. */
            _.Move("SELECT GE_DOC_CLIENTES", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2365- MOVE COD-CLIENTE OF DCLCLIENTES TO GEDOCCLI-COD-CLIENTE. */
            _.Move(CLIENTE.DCLCLIENTES.COD_CLIENTE, GEDOCCLI.DCLGE_DOC_CLIENTE.GEDOCCLI_COD_CLIENTE);

            /*" -2381- PERFORM R0620_00_DADOS_RG_DB_SELECT_1 */

            R0620_00_DADOS_RG_DB_SELECT_1();

            /*" -2384- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -2386- IF SQLCODE EQUAL 100 NEXT SENTENCE */

                if (DB.SQLCODE == 100)
                {

                    /*" -2387- ELSE */
                }
                else
                {


                    /*" -2388- DISPLAY 'PF0612B - FIM ANORMAL' */
                    _.Display($"PF0612B - FIM ANORMAL");

                    /*" -2389- DISPLAY '          ERRO SELECT TAB. GE_DOC_CLIENTE' */
                    _.Display($"          ERRO SELECT TAB. GE_DOC_CLIENTE");

                    /*" -2391- DISPLAY '          NUMERO CERTIFICADO............. ' NUM-CERTIFICADO OF DCLPROPOSTAS-VA */
                    _.Display($"          NUMERO CERTIFICADO............. {PROPVA.DCLPROPOSTAS_VA.NUM_CERTIFICADO}");

                    /*" -2393- DISPLAY '          CODIGO DO CLIENTE.............. ' GEDOCCLI-COD-CLIENTE */
                    _.Display($"          CODIGO DO CLIENTE.............. {GEDOCCLI.DCLGE_DOC_CLIENTE.GEDOCCLI_COD_CLIENTE}");

                    /*" -2395- DISPLAY '          SQLCODE........................ ' SQLCODE */
                    _.Display($"          SQLCODE........................ {DB.SQLCODE}");

                    /*" -2396- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -2397- PERFORM R9999-00-FINALIZAR */

                    R9999_00_FINALIZAR_SECTION();

                    /*" -2398- ELSE */
                }

            }
            else
            {


                /*" -2398- MOVE 1 TO W-OBTER-DADOS-RG. */
                _.Move(1, WAREA_AUXILIAR.W_OBTER_DADOS_RG);
            }


        }

        [StopWatch]
        /*" R0620-00-DADOS-RG-DB-SELECT-1 */
        public void R0620_00_DADOS_RG_DB_SELECT_1()
        {
            /*" -2381- EXEC SQL SELECT COD_CLIENTE , COD_IDENTIFICACAO , NOM_ORGAO_EXP , DTH_EXPEDICAO , COD_UF INTO :GEDOCCLI-COD-CLIENTE , :GEDOCCLI-COD-IDENTIFICACAO , :GEDOCCLI-NOM-ORGAO-EXP , :GEDOCCLI-DTH-EXPEDICAO , :GEDOCCLI-COD-UF:VIND-COD-UF FROM SEGUROS.GE_DOC_CLIENTE WHERE COD_CLIENTE = :GEDOCCLI-COD-CLIENTE WITH UR END-EXEC. */

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
            /*" -2409- MOVE 'R0650-00-GERAR-REGISTRO-TP2' TO PARAGRAFO. */
            _.Move("R0650-00-GERAR-REGISTRO-TP2", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2412- MOVE SPACES TO REG-ENDERECO, REG-PRP-SASSE. */
            _.Move("", LBFPF012.REG_ENDERECO, REG_PRP_SASSE);

            /*" -2415- MOVE '2' TO R2-TIPO-REG OF REG-ENDERECO. */
            _.Move("2", LBFPF012.REG_ENDERECO.R2_TIPO_REG);

            /*" -2419- MOVE W-NUM-PROPOSTA-NOVA TO R2-NUM-PROPOSTA OF REG-ENDERECO. */
            _.Move(WAREA_AUXILIAR.W_NUM_PROPOSTA_NOVA, LBFPF012.REG_ENDERECO.R2_NUM_PROPOSTA);

            /*" -2422- MOVE '2' TO R2-TIPO-ENDER OF REG-ENDERECO. */
            _.Move("2", LBFPF012.REG_ENDERECO.R2_TIPO_ENDER);

            /*" -2425- MOVE ENDERECO-ENDERECO OF DCLENDERECOS TO R2-ENDERECO OF REG-ENDERECO. */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_ENDERECO, LBFPF012.REG_ENDERECO.R2_ENDERECO);

            /*" -2428- MOVE ENDERECO-BAIRRO OF DCLENDERECOS TO R2-BAIRRO OF REG-ENDERECO. */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_BAIRRO, LBFPF012.REG_ENDERECO.R2_BAIRRO);

            /*" -2431- MOVE ENDERECO-CIDADE OF DCLENDERECOS TO R2-CIDADE OF REG-ENDERECO. */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_CIDADE, LBFPF012.REG_ENDERECO.R2_CIDADE);

            /*" -2434- MOVE ENDERECO-SIGLA-UF OF DCLENDERECOS TO R2-SIGLA-UF OF REG-ENDERECO. */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_SIGLA_UF, LBFPF012.REG_ENDERECO.R2_SIGLA_UF);

            /*" -2437- MOVE ENDERECO-CEP OF DCLENDERECOS TO R2-CEP OF REG-ENDERECO. */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_CEP, LBFPF012.REG_ENDERECO.R2_CEP);

            /*" -2439- WRITE REG-PRP-SASSE FROM REG-ENDERECO. */
            _.Move(LBFPF012.REG_ENDERECO.GetMoveValues(), REG_PRP_SASSE);

            MOVTO_PRP_SASSE.Write(REG_PRP_SASSE.GetMoveValues().ToString());

            /*" -2439- ADD 1 TO W-QTD-LD-TIPO-2. */
            WAREA_AUXILIAR.W_QTD_LD_TIPO_2.Value = WAREA_AUXILIAR.W_QTD_LD_TIPO_2 + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0650_SAIDA*/

        [StopWatch]
        /*" R0700-00-GERAR-REGISTRO-TP3-SECTION */
        private void R0700_00_GERAR_REGISTRO_TP3_SECTION()
        {
            /*" -2450- MOVE 'R0700-00-GERAR-REGISTRO-TP3' TO PARAGRAFO. */
            _.Move("R0700-00-GERAR-REGISTRO-TP3", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2453- MOVE SPACES TO REG-PROPOSTA-SASSE REG-PRP-SASSE. */
            _.Move("", LXFCT004.REG_PROPOSTA_SASSE, REG_PRP_SASSE);

            /*" -2456- MOVE '3' TO R3-TIPO-REG OF REG-PROPOSTA-SASSE */
            _.Move("3", LXFCT004.REG_PROPOSTA_SASSE.R3_TIPO_REG);

            /*" -2460- MOVE W-NUM-PROPOSTA-NOVA TO R3-NUM-PROPOSTA OF REG-PROPOSTA-SASSE */
            _.Move(WAREA_AUXILIAR.W_NUM_PROPOSTA_NOVA, LXFCT004.REG_PROPOSTA_SASSE.R3_NUM_PROPOSTA);

            /*" -2463- MOVE PRDSIVPF-COD-PRODUTO-SIVPF OF DCLPRODUTOS-SIVPF TO R3-COD-PRODUTO OF REG-PROPOSTA-SASSE */
            _.Move(PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_PRODUTO_SIVPF, LXFCT004.REG_PROPOSTA_SASSE.R3_COD_PRODUTO);

            /*" -2466- MOVE AGE-COBRANCA OF DCLPROPOSTAS-VA TO R3-AGECOBR OF REG-PROPOSTA-SASSE */
            _.Move(PROPVA.DCLPROPOSTAS_VA.AGE_COBRANCA, LXFCT004.REG_PROPOSTA_SASSE.R3_AGECOBR);

            /*" -2468- MOVE DATA-QUITACAO OF DCLPROPOSTAS-VA TO W-DATA-SQL */
            _.Move(PROPVA.DCLPROPOSTAS_VA.DATA_QUITACAO, WAREA_AUXILIAR.W_DATA_SQL);

            /*" -2469- MOVE W-DIA-SQL TO W-DIA-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_DIA_SQL, WAREA_AUXILIAR.FILLER_2.W_DIA_TRABALHO);

            /*" -2470- MOVE W-MES-SQL TO W-MES-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_MES_SQL, WAREA_AUXILIAR.FILLER_2.W_MES_TRABALHO);

            /*" -2471- MOVE W-ANO-SQL TO W-ANO-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_ANO_SQL, WAREA_AUXILIAR.FILLER_2.W_ANO_TRABALHO);

            /*" -2474- MOVE W-DATA-TRABALHO TO R3-DATA-PROPOSTA OF REG-PROPOSTA-SASSE */
            _.Move(WAREA_AUXILIAR.W_DATA_TRABALHO, LXFCT004.REG_PROPOSTA_SASSE.R3_DATA_PROPOSTA);

            /*" -2477- MOVE OPPAGVA-OPCAO-PAGAMENTO TO R3-OPCAOPAG OF REG-PROPOSTA-SASSE. */
            _.Move(OPPAGVA.DCLOPCAO_PAG_VIDAZUL.OPPAGVA_OPCAO_PAGAMENTO, LXFCT004.REG_PROPOSTA_SASSE.R3_OPCAOPAG);

            /*" -2478- IF OPPAGVA-OPCAO-PAGAMENTO EQUAL 1 OR 2 */

            if (OPPAGVA.DCLOPCAO_PAG_VIDAZUL.OPPAGVA_OPCAO_PAGAMENTO.In("1", "2"))
            {

                /*" -2480- MOVE 1 TO R3-OPCAOPAG OF REG-PROPOSTA-SASSE. */
                _.Move(1, LXFCT004.REG_PROPOSTA_SASSE.R3_OPCAOPAG);
            }


            /*" -2481- IF OPPAGVA-OPCAO-PAGAMENTO EQUAL 3 */

            if (OPPAGVA.DCLOPCAO_PAG_VIDAZUL.OPPAGVA_OPCAO_PAGAMENTO == 3)
            {

                /*" -2483- MOVE 2 TO R3-OPCAOPAG OF REG-PROPOSTA-SASSE. */
                _.Move(2, LXFCT004.REG_PROPOSTA_SASSE.R3_OPCAOPAG);
            }


            /*" -2484- IF OPPAGVA-OPCAO-PAGAMENTO EQUAL 4 */

            if (OPPAGVA.DCLOPCAO_PAG_VIDAZUL.OPPAGVA_OPCAO_PAGAMENTO == 4)
            {

                /*" -2486- MOVE 4 TO R3-OPCAOPAG OF REG-PROPOSTA-SASSE. */
                _.Move(4, LXFCT004.REG_PROPOSTA_SASSE.R3_OPCAOPAG);
            }


            /*" -2487- IF OPPAGVA-OPCAO-PAGAMENTO EQUAL 5 */

            if (OPPAGVA.DCLOPCAO_PAG_VIDAZUL.OPPAGVA_OPCAO_PAGAMENTO == 5)
            {

                /*" -2489- MOVE 3 TO R3-OPCAOPAG OF REG-PROPOSTA-SASSE. */
                _.Move(3, LXFCT004.REG_PROPOSTA_SASSE.R3_OPCAOPAG);
            }


            /*" -2490- IF VIND-AGEDEB LESS ZEROS */

            if (VIND_AGEDEB < 00)
            {

                /*" -2492- MOVE ZEROS TO R3-AGECTADEB OF REG-PROPOSTA-SASSE */
                _.Move(0, LXFCT004.REG_PROPOSTA_SASSE.R3_CONTA_DEBITO.R3_AGECTADEB);

                /*" -2493- ELSE */
            }
            else
            {


                /*" -2496- MOVE OPPAGVA-COD-AGENCIA-DEBITO TO R3-AGECTADEB OF REG-PROPOSTA-SASSE */
                _.Move(OPPAGVA.DCLOPCAO_PAG_VIDAZUL.OPPAGVA_COD_AGENCIA_DEBITO, LXFCT004.REG_PROPOSTA_SASSE.R3_CONTA_DEBITO.R3_AGECTADEB);

                /*" -2497- IF VIND-OPRCTADEB LESS ZEROS */

                if (VIND_OPRCTADEB < 00)
                {

                    /*" -2499- MOVE ZEROS TO R3-OPRCTADEB OF REG-PROPOSTA-SASSE */
                    _.Move(0, LXFCT004.REG_PROPOSTA_SASSE.R3_CONTA_DEBITO.R3_OPRCTADEB);

                    /*" -2500- ELSE */
                }
                else
                {


                    /*" -2503- MOVE OPPAGVA-OPE-CONTA-DEBITO TO R3-OPRCTADEB OF REG-PROPOSTA-SASSE. */
                    _.Move(OPPAGVA.DCLOPCAO_PAG_VIDAZUL.OPPAGVA_OPE_CONTA_DEBITO, LXFCT004.REG_PROPOSTA_SASSE.R3_CONTA_DEBITO.R3_OPRCTADEB);
                }

            }


            /*" -2504- IF VIND-NUMCTADEB LESS ZEROS */

            if (VIND_NUMCTADEB < 00)
            {

                /*" -2506- MOVE ZEROS TO R3-NUMCTADEB OF REG-PROPOSTA-SASSE */
                _.Move(0, LXFCT004.REG_PROPOSTA_SASSE.R3_CONTA_DEBITO.R3_NUMCTADEB);

                /*" -2507- ELSE */
            }
            else
            {


                /*" -2510- MOVE OPPAGVA-NUM-CONTA-DEBITO TO R3-NUMCTADEB OF REG-PROPOSTA-SASSE. */
                _.Move(OPPAGVA.DCLOPCAO_PAG_VIDAZUL.OPPAGVA_NUM_CONTA_DEBITO, LXFCT004.REG_PROPOSTA_SASSE.R3_CONTA_DEBITO.R3_NUMCTADEB);
            }


            /*" -2511- IF VIND-DIGCTADEB LESS ZEROS */

            if (VIND_DIGCTADEB < 00)
            {

                /*" -2513- MOVE ZEROS TO R3-DIGCTADEB OF REG-PROPOSTA-SASSE */
                _.Move(0, LXFCT004.REG_PROPOSTA_SASSE.R3_CONTA_DEBITO.R3_DIGCTADEB);

                /*" -2514- ELSE */
            }
            else
            {


                /*" -2517- MOVE OPPAGVA-DIG-CONTA-DEBITO TO R3-DIGCTADEB OF REG-PROPOSTA-SASSE. */
                _.Move(OPPAGVA.DCLOPCAO_PAG_VIDAZUL.OPPAGVA_DIG_CONTA_DEBITO, LXFCT004.REG_PROPOSTA_SASSE.R3_CONTA_DEBITO.R3_DIGCTADEB);
            }


            /*" -2518- IF VIND-DPS-TITULAR LESS ZEROS */

            if (VIND_DPS_TITULAR < 00)
            {

                /*" -2520- MOVE SPACES TO R3-DPS-TITULAR OF REG-PROPOSTA-SASSE */
                _.Move("", LXFCT004.REG_PROPOSTA_SASSE.R3_DPS_TITULAR);

                /*" -2521- ELSE */
            }
            else
            {


                /*" -2524- MOVE DPS-TITULAR OF DCLPROPOSTAS-VA TO R3-DPS-TITULAR OF REG-PROPOSTA-SASSE. */
                _.Move(PROPVA.DCLPROPOSTAS_VA.DPS_TITULAR, LXFCT004.REG_PROPOSTA_SASSE.R3_DPS_TITULAR);
            }


            /*" -2525- IF VIND-DPS-ESPOSA LESS ZEROS */

            if (VIND_DPS_ESPOSA < 00)
            {

                /*" -2527- MOVE SPACES TO R3-DPS-CONJUGE OF REG-PROPOSTA-SASSE */
                _.Move("", LXFCT004.REG_PROPOSTA_SASSE.R3_DPS_CONJUGE);

                /*" -2528- ELSE */
            }
            else
            {


                /*" -2531- MOVE DPS-ESPOSA OF DCLPROPOSTAS-VA TO R3-DPS-CONJUGE OF REG-PROPOSTA-SASSE. */
                _.Move(PROPVA.DCLPROPOSTAS_VA.DPS_ESPOSA, LXFCT004.REG_PROPOSTA_SASSE.R3_DPS_CONJUGE);
            }


            /*" -2532- IF R3-COD-PRODUTO OF REG-PROPOSTA-SASSE = 46 */

            if (LXFCT004.REG_PROPOSTA_SASSE.R3_COD_PRODUTO == 46)
            {

                /*" -2536- MOVE SPACES TO R3-DPS-TITULAR OF REG-PROPOSTA-SASSE R3-DPS-CONJUGE OF REG-PROPOSTA-SASSE. */
                _.Move("", LXFCT004.REG_PROPOSTA_SASSE.R3_DPS_TITULAR, LXFCT004.REG_PROPOSTA_SASSE.R3_DPS_CONJUGE);
            }


            /*" -2539- MOVE NUM-MATRI-VENDEDOR OF DCLPROPOSTAS-VA TO R3-NRMATRVEN OF REG-PROPOSTA-SASSE */
            _.Move(PROPVA.DCLPROPOSTAS_VA.NUM_MATRI_VENDEDOR, LXFCT004.REG_PROPOSTA_SASSE.R3_NRMATRVEN);

            /*" -2540- IF VIND-APOS-INVALIDEZ LESS 0 */

            if (VIND_APOS_INVALIDEZ < 0)
            {

                /*" -2542- MOVE SPACES TO R3-APOS-INVALIDEZ OF REG-PROPOSTA-SASSE */
                _.Move("", LXFCT004.REG_PROPOSTA_SASSE.R3_APOS_INVALIDEZ);

                /*" -2543- ELSE */
            }
            else
            {


                /*" -2546- MOVE APOS-INVALIDEZ OF DCLPROPOSTAS-VA TO R3-APOS-INVALIDEZ OF REG-PROPOSTA-SASSE. */
                _.Move(PROPVA.DCLPROPOSTAS_VA.APOS_INVALIDEZ, LXFCT004.REG_PROPOSTA_SASSE.R3_APOS_INVALIDEZ);
            }


            /*" -2549- MOVE SPACES TO R3-RENOVACAO-AUTOM OF REG-PROPOSTA-SASSE */
            _.Move("", LXFCT004.REG_PROPOSTA_SASSE.R3_RENOVACAO_AUTOM);

            /*" -2552- MOVE OPPAGVA-DIA-DEBITO TO R3-DIA-DEBITO OF REG-PROPOSTA-SASSE */
            _.Move(OPPAGVA.DCLOPCAO_PAG_VIDAZUL.OPPAGVA_DIA_DEBITO, LXFCT004.REG_PROPOSTA_SASSE.R3_DIA_DEBITO);

            /*" -2553- IF VIND-COD-CCT NOT LESS ZEROS */

            if (VIND_COD_CCT >= 00)
            {

                /*" -2555- IF COD-CCT OF DCLPROPOSTAS-VA GREATER ZEROS */

                if (PROPVA.DCLPROPOSTAS_VA.COD_CCT > 00)
                {

                    /*" -2557- MOVE 50,00 TO R3-PCT-DESCONTO OF REG-PROPOSTA-SASSE */
                    _.Move(50.00, LXFCT004.REG_PROPOSTA_SASSE.R3_PCT_DESCONTO);

                    /*" -2559- MOVE COD-CCT OF DCLPROPOSTAS-VA TO R3-CGC-CONVENENTE OF REG-PROPOSTA-SASSE */
                    _.Move(PROPVA.DCLPROPOSTAS_VA.COD_CCT, LXFCT004.REG_PROPOSTA_SASSE.R3_CGC_CONVENENTE);

                    /*" -2560- ELSE */
                }
                else
                {


                    /*" -2563- MOVE ZEROS TO R3-PCT-DESCONTO OF REG-PROPOSTA-SASSE R3-CGC-CONVENENTE OF REG-PROPOSTA-SASSE */
                    _.Move(0, LXFCT004.REG_PROPOSTA_SASSE.R3_PCT_DESCONTO, LXFCT004.REG_PROPOSTA_SASSE.R3_CGC_CONVENENTE);

                    /*" -2564- ELSE */
                }

            }
            else
            {


                /*" -2568- MOVE ZEROS TO R3-PCT-DESCONTO OF REG-PROPOSTA-SASSE R3-CGC-CONVENENTE OF REG-PROPOSTA-SASSE. */
                _.Move(0, LXFCT004.REG_PROPOSTA_SASSE.R3_PCT_DESCONTO, LXFCT004.REG_PROPOSTA_SASSE.R3_CGC_CONVENENTE);
            }


            /*" -2574- MOVE SPACES TO R3-NOME-CONVENENTE OF REG-PROPOSTA-SASSE */
            _.Move("", LXFCT004.REG_PROPOSTA_SASSE.R3_NOME_CONVENENTE);

            /*" -2577- MOVE 'MAN' TO R3-SIT-PROPOSTA OF REG-PROPOSTA-SASSE. */
            _.Move("MAN", LXFCT004.REG_PROPOSTA_SASSE.R3_SIT_PROPOSTA);

            /*" -2580- MOVE 06 TO R3-ORIGEM-PROPOSTA OF REG-PROPOSTA-SASSE. */
            _.Move(06, LXFCT004.REG_PROPOSTA_SASSE.R3_ORIGEM_PROPOSTA_AIC);

            /*" -2583- MOVE 'SUS' TO R3-SIT-COBRANCA OF REG-PROPOSTA-SASSE. */
            _.Move("SUS", LXFCT004.REG_PROPOSTA_SASSE.R3_SIT_COBRANCA);

            /*" -2586- MOVE 209 TO R3-SIT-MOTIVO OF REG-PROPOSTA-SASSE. */
            _.Move(209, LXFCT004.REG_PROPOSTA_SASSE.R3_SIT_MOTIVO);

            /*" -2589- MOVE OPCAO-COBERTURA OF DCLPROPOSTAS-VA TO R3-OPCAO-COBER OF REG-PROPOSTA-SASSE. */
            _.Move(PROPVA.DCLPROPOSTAS_VA.OPCAO_COBERTURA, LXFCT004.REG_PROPOSTA_SASSE.R3_OPCAO_COBER);

            /*" -2592- MOVE ZEROS TO R3-COD-PLANO OF REG-PROPOSTA-SASSE. */
            _.Move(0, LXFCT004.REG_PROPOSTA_SASSE.R3_COD_PLANO);

            /*" -2595- MOVE DATA-QUITACAO OF DCLPROPOSTAS-VA TO W-DATA-SQL */
            _.Move(PROPVA.DCLPROPOSTAS_VA.DATA_QUITACAO, WAREA_AUXILIAR.W_DATA_SQL);

            /*" -2596- MOVE W-DIA-SQL TO W-DIA-TRABALHO */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_DIA_SQL, WAREA_AUXILIAR.FILLER_2.W_DIA_TRABALHO);

            /*" -2597- MOVE W-MES-SQL TO W-MES-TRABALHO */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_MES_SQL, WAREA_AUXILIAR.FILLER_2.W_MES_TRABALHO);

            /*" -2598- MOVE W-ANO-SQL TO W-ANO-TRABALHO */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_ANO_SQL, WAREA_AUXILIAR.FILLER_2.W_ANO_TRABALHO);

            /*" -2604- MOVE W-DATA-TRABALHO TO R3-DTQITBCO OF REG-PROPOSTA-SASSE. */
            _.Move(WAREA_AUXILIAR.W_DATA_TRABALHO, LXFCT004.REG_PROPOSTA_SASSE.R3_DTQITBCO);

            /*" -2607- MOVE AGE-COBRANCA OF DCLPROPOSTAS-VA TO R3-AGEPGTO OF REG-PROPOSTA-SASSE. */
            _.Move(PROPVA.DCLPROPOSTAS_VA.AGE_COBRANCA, LXFCT004.REG_PROPOSTA_SASSE.R3_AGEPGTO);

            /*" -2618- MOVE VAL-TARIFA OF DCLTARIFA-BALCAO-CEF TO R3-VAL-TARIFA OF REG-PROPOSTA-SASSE. */
            _.Move(TARIBCEF.DCLTARIFA_BALCAO_CEF.VAL_TARIFA, LXFCT004.REG_PROPOSTA_SASSE.R3_VAL_TARIFA);

            /*" -2619- MOVE ZEROS TO R3-VAL-PAGO OF REG-PROPOSTA-SASSE. */
            _.Move(0, LXFCT004.REG_PROPOSTA_SASSE.R3_VAL_PAGO);

            /*" -2621- MOVE ZEROS TO R3-DATA-CREDITO OF REG-PROPOSTA-SASSE. */
            _.Move(0, LXFCT004.REG_PROPOSTA_SASSE.R3_DATA_CREDITO);

            /*" -2623- IF COD-ORIGEM-PROPOSTA OF DCLPROPOSTAS-VA = 12 */

            if (PROPVA.DCLPROPOSTAS_VA.COD_ORIGEM_PROPOSTA == 12)
            {

                /*" -2627- COMPUTE R3-VAL-PAGO OF REG-PROPOSTA-SASSE = PREMIO-VG OF DCLHIST-CONT-PARCELVA + PREMIO-AP OF DCLHIST-CONT-PARCELVA */
                LXFCT004.REG_PROPOSTA_SASSE.R3_VAL_PAGO.Value = HTCTBPVA.DCLHIST_CONT_PARCELVA.PREMIO_VG + HTCTBPVA.DCLHIST_CONT_PARCELVA.PREMIO_AP;

                /*" -2630- MOVE DATA-MOVIMENTO OF DCLHIST-CONT-PARCELVA TO W-DATA-SQL */
                _.Move(HTCTBPVA.DCLHIST_CONT_PARCELVA.DATA_MOVIMENTO, WAREA_AUXILIAR.W_DATA_SQL);

                /*" -2631- MOVE W-DIA-SQL TO W-DIA-TRABALHO */
                _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_DIA_SQL, WAREA_AUXILIAR.FILLER_2.W_DIA_TRABALHO);

                /*" -2632- MOVE W-MES-SQL TO W-MES-TRABALHO */
                _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_MES_SQL, WAREA_AUXILIAR.FILLER_2.W_MES_TRABALHO);

                /*" -2634- MOVE W-ANO-SQL TO W-ANO-TRABALHO */
                _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_ANO_SQL, WAREA_AUXILIAR.FILLER_2.W_ANO_TRABALHO);

                /*" -2636- MOVE W-DATA-TRABALHO TO R3-DATA-CREDITO OF REG-PROPOSTA-SASSE */
                _.Move(WAREA_AUXILIAR.W_DATA_TRABALHO, LXFCT004.REG_PROPOSTA_SASSE.R3_DATA_CREDITO);

                /*" -2638- ELSE */
            }
            else
            {


                /*" -2640- MOVE RCAPS-DATA-MOVIMENTO OF DCLRCAPS TO W-DATA-SQL */
                _.Move(RCAPS.DCLRCAPS.RCAPS_DATA_MOVIMENTO, WAREA_AUXILIAR.W_DATA_SQL);

                /*" -2641- MOVE W-DIA-SQL TO W-DIA-TRABALHO */
                _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_DIA_SQL, WAREA_AUXILIAR.FILLER_2.W_DIA_TRABALHO);

                /*" -2642- MOVE W-MES-SQL TO W-MES-TRABALHO */
                _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_MES_SQL, WAREA_AUXILIAR.FILLER_2.W_MES_TRABALHO);

                /*" -2643- MOVE W-ANO-SQL TO W-ANO-TRABALHO */
                _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_ANO_SQL, WAREA_AUXILIAR.FILLER_2.W_ANO_TRABALHO);

                /*" -2646- MOVE W-DATA-TRABALHO TO R3-DATA-CREDITO OF REG-PROPOSTA-SASSE */
                _.Move(WAREA_AUXILIAR.W_DATA_TRABALHO, LXFCT004.REG_PROPOSTA_SASSE.R3_DATA_CREDITO);

                /*" -2650- MOVE RCAPS-VAL-RCAP OF DCLRCAPS TO R3-VAL-PAGO OF REG-PROPOSTA-SASSE. */
                _.Move(RCAPS.DCLRCAPS.RCAPS_VAL_RCAP, LXFCT004.REG_PROPOSTA_SASSE.R3_VAL_PAGO);
            }


            /*" -2654- COMPUTE R3-VAL-COMISSAO OF REG-PROPOSTA-SASSE = VAL-COMISSAO-VG OF DCLFUNDO-COMISSAO-VA + VAL-COMISSAO-AP OF DCLFUNDO-COMISSAO-VA . */
            LXFCT004.REG_PROPOSTA_SASSE.R3_VAL_COMISSAO.Value = FDCOMVA.DCLFUNDO_COMISSAO_VA.VAL_COMISSAO_VG + FDCOMVA.DCLFUNDO_COMISSAO_VA.VAL_COMISSAO_AP;

            /*" -2657- MOVE ARQSIVPF-NSAS-SIVPF OF DCLARQUIVOS-SIVPF TO R3-NSAS OF REG-PROPOSTA-SASSE. */
            _.Move(ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF, LXFCT004.REG_PROPOSTA_SASSE.R3_NSAS);

            /*" -2659- ADD 1 TO W-QTD-LD-TIPO-3. */
            WAREA_AUXILIAR.W_QTD_LD_TIPO_3.Value = WAREA_AUXILIAR.W_QTD_LD_TIPO_3 + 1;

            /*" -2662- MOVE W-QTD-LD-TIPO-3 TO R3-NSL OF REG-PROPOSTA-SASSE. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_3, LXFCT004.REG_PROPOSTA_SASSE.R3_NSL);

            /*" -2664- WRITE REG-PRP-SASSE FROM REG-PROPOSTA-SASSE. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.GetMoveValues(), REG_PRP_SASSE);

            MOVTO_PRP_SASSE.Write(REG_PRP_SASSE.GetMoveValues().ToString());

            /*" -2665- MOVE NUM-CERTIFICADO OF DCLPROPOSTAS-VA TO R3-NUM-PROPOSTA OF REG-PROPOSTA-SASSE. */
            _.Move(PROPVA.DCLPROPOSTAS_VA.NUM_CERTIFICADO, LXFCT004.REG_PROPOSTA_SASSE.R3_NUM_PROPOSTA);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0700_SAIDA*/

        [StopWatch]
        /*" R0750-PROCESSAR-BENEFICIARIOS-SECTION */
        private void R0750_PROCESSAR_BENEFICIARIOS_SECTION()
        {
            /*" -2676- MOVE 'R0750-PROCESSAR-BENEFICIARIOS' TO PARAGRAFO. */
            _.Move("R0750-PROCESSAR-BENEFICIARIOS", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2679- MOVE SPACES TO REG-BENEFIC, REG-PRP-SASSE. */
            _.Move("", LBFPF014.REG_BENEFIC, REG_PRP_SASSE);

            /*" -2682- MOVE '4' TO R4-TIPO-REG OF REG-BENEFIC. */
            _.Move("4", LBFPF014.REG_BENEFIC.R4_TIPO_REG);

            /*" -2686- MOVE W-NUM-PROPOSTA-NOVA TO R4-NUM-PROPOSTA OF REG-BENEFIC. */
            _.Move(WAREA_AUXILIAR.W_NUM_PROPOSTA_NOVA, LBFPF014.REG_BENEFIC.R4_NUM_PROPOSTA);

            /*" -2696- MOVE ZEROS TO R4-DATA-NASCIMENTO OF REG-BENEFIC, R4-CGC-CPF OF REG-BENEFIC, R4-SEXO OF REG-BENEFIC, R4-ESTADO-CIVIL OF REG-BENEFIC, R4-PCT-FGB OF REG-BENEFIC, R4-PCT-PECULIO OF REG-BENEFIC, R4-PCT-PENSAO OF REG-BENEFIC, R4-QTDE-TITULOS OF REG-BENEFIC. */
            _.Move(0, LBFPF014.REG_BENEFIC.R4_DATA_NASCIMENTO, LBFPF014.REG_BENEFIC.R4_CGC_CPF, LBFPF014.REG_BENEFIC.R4_SEXO, LBFPF014.REG_BENEFIC.R4_ESTADO_CIVIL, LBFPF014.REG_BENEFIC.R4_PCT_FGB, LBFPF014.REG_BENEFIC.R4_PCT_PECULIO, LBFPF014.REG_BENEFIC.R4_PCT_PENSAO, LBFPF014.REG_BENEFIC.R4_QTDE_TITULOS);

            /*" -2699- MOVE SPACES TO W-FIM-BENEFICIARIOS. */
            _.Move("", WAREA_AUXILIAR.W_FIM_BENEFICIARIOS);

            /*" -2701- PERFORM R0800-00-CURSOR-BENEFICIARIOS. */

            R0800_00_CURSOR_BENEFICIARIOS_SECTION();

            /*" -2703- PERFORM R0850-00-LER-BENEFICIARIOS. */

            R0850_00_LER_BENEFICIARIOS_SECTION();

            /*" -2704- PERFORM R0900-00-GERAR-REGISTRO-TP4 UNTIL W-FIM-BENEFICIARIOS EQUAL 'FIM' . */

            while (!(WAREA_AUXILIAR.W_FIM_BENEFICIARIOS == "FIM"))
            {

                R0900_00_GERAR_REGISTRO_TP4_SECTION();
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0750_SAIDA*/

        [StopWatch]
        /*" R0800-00-CURSOR-BENEFICIARIOS-SECTION */
        private void R0800_00_CURSOR_BENEFICIARIOS_SECTION()
        {
            /*" -2715- MOVE 'R0800-00-CURSOR-BENEFICIARIOS' TO PARAGRAFO. */
            _.Move("R0800-00-CURSOR-BENEFICIARIOS", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2718- MOVE NUM-APOLICE OF DCLPROPOSTAS-VA TO BENEFPRO-NUM-APOLICE. */
            _.Move(PROPVA.DCLPROPOSTAS_VA.NUM_APOLICE, BENEFPRO.DCLBENEFICIARIOS_PROP.BENEFPRO_NUM_APOLICE);

            /*" -2721- MOVE COD-SUBGRUPO OF DCLPROPOSTAS-VA TO BENEFPRO-COD-SUBGRUPO. */
            _.Move(PROPVA.DCLPROPOSTAS_VA.COD_SUBGRUPO, BENEFPRO.DCLBENEFICIARIOS_PROP.BENEFPRO_COD_SUBGRUPO);

            /*" -2724- MOVE COD-FONTE OF DCLPROPOSTAS-VA TO BENEFPRO-COD-FONTE. */
            _.Move(PROPVA.DCLPROPOSTAS_VA.COD_FONTE, BENEFPRO.DCLBENEFICIARIOS_PROP.BENEFPRO_COD_FONTE);

            /*" -2728- MOVE NUM-PROPOSTA OF DCLPROPOSTAS-VA TO BENEFPRO-NUM-PROPOSTA. */
            _.Move(PROPVA.DCLPROPOSTAS_VA.NUM_PROPOSTA, BENEFPRO.DCLBENEFICIARIOS_PROP.BENEFPRO_NUM_PROPOSTA);

            /*" -2729- ACCEPT WS-HORA-INI FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_INI);

            /*" -2732- COMPUTE SIT = (HI * 60 * 60) + (MI * 60) + SI + (DI / 100) */
            WS_HORAS.SIT.Value = (WS_HORAS.WS_HORA_INI_R.HI * 60 * 60) + (WS_HORAS.WS_HORA_INI_R.MI * 60) + WS_HORAS.WS_HORA_INI_R.SI + (WS_HORAS.WS_HORA_INI_R.DI / 100f);

            /*" -2752- PERFORM R0800_00_CURSOR_BENEFICIARIOS_DB_DECLARE_1 */

            R0800_00_CURSOR_BENEFICIARIOS_DB_DECLARE_1();

            /*" -2756- ACCEPT WS-HORA-FIM FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_FIM);

            /*" -2757- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF + (DF / 100) */
            WS_HORAS.SFT.Value = (WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (WS_HORAS.WS_HORA_FIM_R.MF * 60) + WS_HORAS.WS_HORA_FIM_R.SF + (WS_HORAS.WS_HORA_FIM_R.DF / 100f);

            /*" -2758- SUBTRACT SIT FROM SFT */
            WS_HORAS.SFT.Value = WS_HORAS.SFT - WS_HORAS.SIT;

            /*" -2759- ADD SFT TO STT(20) */
            TOTAIS_ROT.FILLER_20[20].STT.Value = TOTAIS_ROT.FILLER_20[20].STT + WS_HORAS.SFT;

            /*" -2763- ADD 1 TO SQT(20) */
            TOTAIS_ROT.FILLER_20[20].SQT.Value = TOTAIS_ROT.FILLER_20[20].SQT + 1;

            /*" -2764- ACCEPT WS-HORA-INI FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_INI);

            /*" -2767- COMPUTE SIT = (HI * 60 * 60) + (MI * 60) + SI + (DI / 100) */
            WS_HORAS.SIT.Value = (WS_HORAS.WS_HORA_INI_R.HI * 60 * 60) + (WS_HORAS.WS_HORA_INI_R.MI * 60) + WS_HORAS.WS_HORA_INI_R.SI + (WS_HORAS.WS_HORA_INI_R.DI / 100f);

            /*" -2767- PERFORM R0800_00_CURSOR_BENEFICIARIOS_DB_OPEN_1 */

            R0800_00_CURSOR_BENEFICIARIOS_DB_OPEN_1();

            /*" -2771- ACCEPT WS-HORA-FIM FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_FIM);

            /*" -2772- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF + (DF / 100) */
            WS_HORAS.SFT.Value = (WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (WS_HORAS.WS_HORA_FIM_R.MF * 60) + WS_HORAS.WS_HORA_FIM_R.SF + (WS_HORAS.WS_HORA_FIM_R.DF / 100f);

            /*" -2773- SUBTRACT SIT FROM SFT */
            WS_HORAS.SFT.Value = WS_HORAS.SFT - WS_HORAS.SIT;

            /*" -2774- ADD SFT TO STT(21) */
            TOTAIS_ROT.FILLER_20[21].STT.Value = TOTAIS_ROT.FILLER_20[21].STT + WS_HORAS.SFT;

            /*" -2774- ADD 1 TO SQT(21). */
            TOTAIS_ROT.FILLER_20[21].SQT.Value = TOTAIS_ROT.FILLER_20[21].SQT + 1;

        }

        [StopWatch]
        /*" R0800-00-CURSOR-BENEFICIARIOS-DB-OPEN-1 */
        public void R0800_00_CURSOR_BENEFICIARIOS_DB_OPEN_1()
        {
            /*" -2767- EXEC SQL OPEN BENEFICIARIOS END-EXEC. */

            BENEFICIARIOS.Open();

        }

        [StopWatch]
        /*" R3136-RELACIONA-EMAIL-DB-DECLARE-1 */
        public void R3136_RELACIONA_EMAIL_DB_DECLARE_1()
        {
            /*" -3665- EXEC SQL DECLARE EMAIL CURSOR FOR SELECT COD_PESSOA, SEQ_EMAIL, EMAIL, SITUACAO_EMAIL FROM SEGUROS.PESSOA_EMAIL WHERE COD_PESSOA = :DCLPESSOA-EMAIL.COD-PESSOA ORDER BY SEQ_EMAIL WITH UR END-EXEC. */
            EMAIL = new PF0619B_EMAIL(true);
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
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0800_SAIDA*/

        [StopWatch]
        /*" R0850-00-LER-BENEFICIARIOS-SECTION */
        private void R0850_00_LER_BENEFICIARIOS_SECTION()
        {
            /*" -2788- MOVE 'R0850-00-LER-BENEFICIARIOS' TO PARAGRAFO. */
            _.Move("R0850-00-LER-BENEFICIARIOS", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2789- ACCEPT WS-HORA-INI FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_INI);

            /*" -2792- COMPUTE SIT = (HI * 60 * 60) + (MI * 60) + SI + (DI / 100) */
            WS_HORAS.SIT.Value = (WS_HORAS.WS_HORA_INI_R.HI * 60 * 60) + (WS_HORAS.WS_HORA_INI_R.MI * 60) + WS_HORAS.WS_HORA_INI_R.SI + (WS_HORAS.WS_HORA_INI_R.DI / 100f);

            /*" -2802- PERFORM R0850_00_LER_BENEFICIARIOS_DB_FETCH_1 */

            R0850_00_LER_BENEFICIARIOS_DB_FETCH_1();

            /*" -2806- ACCEPT WS-HORA-FIM FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_FIM);

            /*" -2807- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF + (DF / 100) */
            WS_HORAS.SFT.Value = (WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (WS_HORAS.WS_HORA_FIM_R.MF * 60) + WS_HORAS.WS_HORA_FIM_R.SF + (WS_HORAS.WS_HORA_FIM_R.DF / 100f);

            /*" -2808- SUBTRACT SIT FROM SFT */
            WS_HORAS.SFT.Value = WS_HORAS.SFT - WS_HORAS.SIT;

            /*" -2809- ADD SFT TO STT(22) */
            TOTAIS_ROT.FILLER_20[22].STT.Value = TOTAIS_ROT.FILLER_20[22].STT + WS_HORAS.SFT;

            /*" -2812- ADD 1 TO SQT(22) */
            TOTAIS_ROT.FILLER_20[22].SQT.Value = TOTAIS_ROT.FILLER_20[22].SQT + 1;

            /*" -2813- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -2814- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2815- MOVE 'FIM' TO W-FIM-BENEFICIARIOS */
                    _.Move("FIM", WAREA_AUXILIAR.W_FIM_BENEFICIARIOS);

                    /*" -2815- PERFORM R0850_00_LER_BENEFICIARIOS_DB_CLOSE_1 */

                    R0850_00_LER_BENEFICIARIOS_DB_CLOSE_1();

                    /*" -2817- ELSE */
                }
                else
                {


                    /*" -2818- DISPLAY 'PF0619B - FIM ANORMAL' */
                    _.Display($"PF0619B - FIM ANORMAL");

                    /*" -2820- DISPLAY '          ERRO FETCH BENEFICIARIOS ' SQLCODE */
                    _.Display($"          ERRO FETCH BENEFICIARIOS {DB.SQLCODE}");

                    /*" -2821- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -2821- PERFORM R9999-00-FINALIZAR. */

                    R9999_00_FINALIZAR_SECTION();
                }

            }


        }

        [StopWatch]
        /*" R0850-00-LER-BENEFICIARIOS-DB-FETCH-1 */
        public void R0850_00_LER_BENEFICIARIOS_DB_FETCH_1()
        {
            /*" -2802- EXEC SQL FETCH BENEFICIARIOS INTO :BENEFPRO-NUM-APOLICE , :BENEFPRO-COD-SUBGRUPO , :BENEFPRO-COD-FONTE , :BENEFPRO-NUM-PROPOSTA , :BENEFPRO-NUM-BENEFICIARIO , :BENEFPRO-NOME-BENEFICIARIO , :BENEFPRO-GRAU-PARENTESCO , :BENEFPRO-PCT-PART-BENEFICIA END-EXEC. */

            if (BENEFICIARIOS.Fetch())
            {
                _.Move(BENEFICIARIOS.BENEFPRO_NUM_APOLICE, BENEFPRO.DCLBENEFICIARIOS_PROP.BENEFPRO_NUM_APOLICE);
                _.Move(BENEFICIARIOS.BENEFPRO_COD_SUBGRUPO, BENEFPRO.DCLBENEFICIARIOS_PROP.BENEFPRO_COD_SUBGRUPO);
                _.Move(BENEFICIARIOS.BENEFPRO_COD_FONTE, BENEFPRO.DCLBENEFICIARIOS_PROP.BENEFPRO_COD_FONTE);
                _.Move(BENEFICIARIOS.BENEFPRO_NUM_PROPOSTA, BENEFPRO.DCLBENEFICIARIOS_PROP.BENEFPRO_NUM_PROPOSTA);
                _.Move(BENEFICIARIOS.BENEFPRO_NUM_BENEFICIARIO, BENEFPRO.DCLBENEFICIARIOS_PROP.BENEFPRO_NUM_BENEFICIARIO);
                _.Move(BENEFICIARIOS.BENEFPRO_NOME_BENEFICIARIO, BENEFPRO.DCLBENEFICIARIOS_PROP.BENEFPRO_NOME_BENEFICIARIO);
                _.Move(BENEFICIARIOS.BENEFPRO_GRAU_PARENTESCO, BENEFPRO.DCLBENEFICIARIOS_PROP.BENEFPRO_GRAU_PARENTESCO);
                _.Move(BENEFICIARIOS.BENEFPRO_PCT_PART_BENEFICIA, BENEFPRO.DCLBENEFICIARIOS_PROP.BENEFPRO_PCT_PART_BENEFICIA);
            }

        }

        [StopWatch]
        /*" R0850-00-LER-BENEFICIARIOS-DB-CLOSE-1 */
        public void R0850_00_LER_BENEFICIARIOS_DB_CLOSE_1()
        {
            /*" -2815- EXEC SQL CLOSE BENEFICIARIOS END-EXEC */

            BENEFICIARIOS.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0850_SAIDA*/

        [StopWatch]
        /*" R0880-00-UPDATE-RELATORIOS-SECTION */
        private void R0880_00_UPDATE_RELATORIOS_SECTION()
        {
            /*" -2831- MOVE 'R0880-00-UPDATE-RELATORIOS' TO PARAGRAFO. */
            _.Move("R0880-00-UPDATE-RELATORIOS", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2834- MOVE 'UPDATE RELATORIOS' TO COMANDO. */
            _.Move("UPDATE RELATORIOS", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2835- ACCEPT WS-HORA-INI FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_INI);

            /*" -2838- COMPUTE SIT = (HI * 60 * 60) + (MI * 60) + SI + (DI / 100) */
            WS_HORAS.SIT.Value = (WS_HORAS.WS_HORA_INI_R.HI * 60 * 60) + (WS_HORAS.WS_HORA_INI_R.MI * 60) + WS_HORAS.WS_HORA_INI_R.SI + (WS_HORAS.WS_HORA_INI_R.DI / 100f);

            /*" -2845- PERFORM R0880_00_UPDATE_RELATORIOS_DB_UPDATE_1 */

            R0880_00_UPDATE_RELATORIOS_DB_UPDATE_1();

            /*" -2849- ACCEPT WS-HORA-FIM FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_FIM);

            /*" -2850- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF + (DF / 100) */
            WS_HORAS.SFT.Value = (WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (WS_HORAS.WS_HORA_FIM_R.MF * 60) + WS_HORAS.WS_HORA_FIM_R.SF + (WS_HORAS.WS_HORA_FIM_R.DF / 100f);

            /*" -2851- SUBTRACT SIT FROM SFT */
            WS_HORAS.SFT.Value = WS_HORAS.SFT - WS_HORAS.SIT;

            /*" -2852- ADD SFT TO STT(19) */
            TOTAIS_ROT.FILLER_20[19].STT.Value = TOTAIS_ROT.FILLER_20[19].STT + WS_HORAS.SFT;

            /*" -2855- ADD 1 TO SQT(19) */
            TOTAIS_ROT.FILLER_20[19].SQT.Value = TOTAIS_ROT.FILLER_20[19].SQT + 1;

            /*" -2856- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -2857- DISPLAY 'PF0619B - FIM ANORMAL' */
                _.Display($"PF0619B - FIM ANORMAL");

                /*" -2858- DISPLAY '          ERRO UPDATE RELATORIOS' */
                _.Display($"          ERRO UPDATE RELATORIOS");

                /*" -2860- DISPLAY '          SQLCODE........................ ' SQLCODE */
                _.Display($"          SQLCODE........................ {DB.SQLCODE}");

                /*" -2861- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -2861- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R0880-00-UPDATE-RELATORIOS-DB-UPDATE-1 */
        public void R0880_00_UPDATE_RELATORIOS_DB_UPDATE_1()
        {
            /*" -2845- EXEC SQL UPDATE SEGUROS.RELATORIOS SET DATA_REFERENCIA = :DCLRELATORIOS.RELATORI-DATA-REFERENCIA, TIMESTAMP = CURRENT TIMESTAMP WHERE IDE_SISTEMA = 'PF' AND COD_RELATORIO = 'PF0619B' END-EXEC. */

            var r0880_00_UPDATE_RELATORIOS_DB_UPDATE_1_Update1 = new R0880_00_UPDATE_RELATORIOS_DB_UPDATE_1_Update1()
            {
                RELATORI_DATA_REFERENCIA = RELATORI.DCLRELATORIOS.RELATORI_DATA_REFERENCIA.ToString(),
            };

            R0880_00_UPDATE_RELATORIOS_DB_UPDATE_1_Update1.Execute(r0880_00_UPDATE_RELATORIOS_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0880_SAIDA*/

        [StopWatch]
        /*" R0900-00-GERAR-REGISTRO-TP4-SECTION */
        private void R0900_00_GERAR_REGISTRO_TP4_SECTION()
        {
            /*" -2871- MOVE 'R0900-00-GERA-REGISTRO-TP4' TO PARAGRAFO. */
            _.Move("R0900-00-GERA-REGISTRO-TP4", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2874- MOVE BENEFPRO-NOME-BENEFICIARIO TO R4-NOME OF REG-BENEFIC. */
            _.Move(BENEFPRO.DCLBENEFICIARIOS_PROP.BENEFPRO_NOME_BENEFICIARIO, LBFPF014.REG_BENEFIC.R4_NOME);

            /*" -2877- IF BENEFPRO-GRAU-PARENTESCO EQUAL 'CONJUGE' OR 'MARIDO' OR 'MULHER' OR 'ESPOSA' OR 'ESPOSO' */

            if (BENEFPRO.DCLBENEFICIARIOS_PROP.BENEFPRO_GRAU_PARENTESCO.In("CONJUGE", "MARIDO", "MULHER", "ESPOSA", "ESPOSO"))
            {

                /*" -2879- MOVE 1 TO R4-GRAU-PARENTESCO OF REG-BENEFIC */
                _.Move(1, LBFPF014.REG_BENEFIC.R4_GRAU_PARENTESCO);

                /*" -2880- ELSE */
            }
            else
            {


                /*" -2882- IF BENEFPRO-GRAU-PARENTESCO EQUAL 'COMPANHEIRO(A)' */

                if (BENEFPRO.DCLBENEFICIARIOS_PROP.BENEFPRO_GRAU_PARENTESCO == "COMPANHEIRO(A)")
                {

                    /*" -2884- MOVE 2 TO R4-GRAU-PARENTESCO OF REG-BENEFIC */
                    _.Move(2, LBFPF014.REG_BENEFIC.R4_GRAU_PARENTESCO);

                    /*" -2885- ELSE */
                }
                else
                {


                    /*" -2887- IF BENEFPRO-GRAU-PARENTESCO EQUAL 'FILHOS' OR 'FILHO' OR 'FILHA' */

                    if (BENEFPRO.DCLBENEFICIARIOS_PROP.BENEFPRO_GRAU_PARENTESCO.In("FILHOS", "FILHO", "FILHA"))
                    {

                        /*" -2889- MOVE 3 TO R4-GRAU-PARENTESCO OF REG-BENEFIC */
                        _.Move(3, LBFPF014.REG_BENEFIC.R4_GRAU_PARENTESCO);

                        /*" -2890- ELSE */
                    }
                    else
                    {


                        /*" -2892- IF BENEFPRO-GRAU-PARENTESCO EQUAL 'PAIS' OR 'PAI' OR 'MAE' */

                        if (BENEFPRO.DCLBENEFICIARIOS_PROP.BENEFPRO_GRAU_PARENTESCO.In("PAIS", "PAI", "MAE"))
                        {

                            /*" -2894- MOVE 4 TO R4-GRAU-PARENTESCO OF REG-BENEFIC */
                            _.Move(4, LBFPF014.REG_BENEFIC.R4_GRAU_PARENTESCO);

                            /*" -2895- ELSE */
                        }
                        else
                        {


                            /*" -2897- IF BENEFPRO-GRAU-PARENTESCO EQUAL 'IRMAOS' OR 'IRMAO' OR 'IRMA' */

                            if (BENEFPRO.DCLBENEFICIARIOS_PROP.BENEFPRO_GRAU_PARENTESCO.In("IRMAOS", "IRMAO", "IRMA"))
                            {

                                /*" -2899- MOVE 5 TO R4-GRAU-PARENTESCO OF REG-BENEFIC */
                                _.Move(5, LBFPF014.REG_BENEFIC.R4_GRAU_PARENTESCO);

                                /*" -2900- ELSE */
                            }
                            else
                            {


                                /*" -2903- MOVE 6 TO R4-GRAU-PARENTESCO OF REG-BENEFIC. */
                                _.Move(6, LBFPF014.REG_BENEFIC.R4_GRAU_PARENTESCO);
                            }

                        }

                    }

                }

            }


            /*" -2906- MOVE BENEFPRO-PCT-PART-BENEFICIA TO R4-PCT-PARTICIP OF REG-BENEFIC. */
            _.Move(BENEFPRO.DCLBENEFICIARIOS_PROP.BENEFPRO_PCT_PART_BENEFICIA, LBFPF014.REG_BENEFIC.R4_PCT_PARTICIP);

            /*" -2908- WRITE REG-PRP-SASSE FROM REG-BENEFIC. */
            _.Move(LBFPF014.REG_BENEFIC.GetMoveValues(), REG_PRP_SASSE);

            MOVTO_PRP_SASSE.Write(REG_PRP_SASSE.GetMoveValues().ToString());

            /*" -2910- ADD 1 TO W-QTD-LD-TIPO-4. */
            WAREA_AUXILIAR.W_QTD_LD_TIPO_4.Value = WAREA_AUXILIAR.W_QTD_LD_TIPO_4 + 1;

            /*" -2910- PERFORM R0850-00-LER-BENEFICIARIOS. */

            R0850_00_LER_BENEFICIARIOS_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0900_SAIDA*/

        [StopWatch]
        /*" R1000-00-GERAR-TRAILLER-SECTION */
        private void R1000_00_GERAR_TRAILLER_SECTION()
        {
            /*" -2920- MOVE 'R1000-00-GERAR-TRAILLER' TO PARAGRAFO. */
            _.Move("R1000-00-GERAR-TRAILLER", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2922- MOVE 'WRITE REG-TRAILLER' TO COMANDO. */
            _.Move("WRITE REG-TRAILLER", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2925- MOVE SPACES TO REG-TRAILLER, REG-PRP-SASSE */
            _.Move("", LBFPF991.REG_TRAILLER, REG_PRP_SASSE);

            /*" -2928- MOVE 'T' TO RT-TIPO-REG OF REG-TRAILLER. */
            _.Move("T", LBFPF991.REG_TRAILLER.RT_TIPO_REG);

            /*" -2931- MOVE 'PRPSASSE' TO RT-NOME-EMPRESA OF REG-TRAILLER. */
            _.Move("PRPSASSE", LBFPF991.REG_TRAILLER.RT_NOME_EMPRESA);

            /*" -2934- MOVE W-QTD-LD-TIPO-1 TO RT-QTDE-TIPO-1 OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_1, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_1);

            /*" -2937- MOVE W-QTD-LD-TIPO-2 TO RT-QTDE-TIPO-2 OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_2, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_2);

            /*" -2940- MOVE W-QTD-LD-TIPO-3 TO RT-QTDE-TIPO-3 OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_3, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_3);

            /*" -2943- MOVE W-QTD-LD-TIPO-4 TO RT-QTDE-TIPO-4 OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_4, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_4);

            /*" -2946- MOVE W-QTD-LD-TIPO-5 TO RT-QTDE-TIPO-5 OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_5, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_5);

            /*" -2950- MOVE ZEROS TO RT-QTDE-TIPO-0 OF REG-TRAILLER, RT-QTDE-TIPO-6 OF REG-TRAILLER. */
            _.Move(0, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_0, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_6);

            /*" -2959- COMPUTE RT-QTDE-TOTAL OF REG-TRAILLER = RT-QTDE-TIPO-0 + RT-QTDE-TIPO-1 + RT-QTDE-TIPO-2 + RT-QTDE-TIPO-3 + RT-QTDE-TIPO-4 + RT-QTDE-TIPO-5 + RT-QTDE-TIPO-6. */
            LBFPF991.REG_TRAILLER.RT_QTDE_TOTAL.Value = LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_0 + LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_1 + LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_2 + LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_3 + LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_4 + LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_5 + LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_6;

            /*" -2959- WRITE REG-PRP-SASSE FROM REG-TRAILLER. */
            _.Move(LBFPF991.REG_TRAILLER.GetMoveValues(), REG_PRP_SASSE);

            MOVTO_PRP_SASSE.Write(REG_PRP_SASSE.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_SAIDA*/

        [StopWatch]
        /*" R1050-00-CONTROLAR-ARQ-ENVIADO-SECTION */
        private void R1050_00_CONTROLAR_ARQ_ENVIADO_SECTION()
        {
            /*" -2972- MOVE 'R1050-00-CONTROLAR-ARQ-ENVIADO' TO PARAGRAFO. */
            _.Move("R1050-00-CONTROLAR-ARQ-ENVIADO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2974- MOVE 'INSERT ARQUIVOS-SIVPF' TO COMANDO. */
            _.Move("INSERT ARQUIVOS-SIVPF", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2977- MOVE 'PRPSASSE' TO ARQSIVPF-SIGLA-ARQUIVO OF DCLARQUIVOS-SIVPF. */
            _.Move("PRPSASSE", ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SIGLA_ARQUIVO);

            /*" -2980- MOVE 4 TO ARQSIVPF-SISTEMA-ORIGEM OF DCLARQUIVOS-SIVPF. */
            _.Move(4, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SISTEMA_ORIGEM);

            /*" -2984- MOVE SISTEMAS-DATA-MOV-ABERTO OF DCLSISTEMAS TO ARQSIVPF-DATA-GERACAO OF DCLARQUIVOS-SIVPF, ARQSIVPF-DATA-PROCESSAMENTO OF DCLARQUIVOS-SIVPF. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_GERACAO, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_PROCESSAMENTO);

            /*" -2989- MOVE RT-QTDE-TIPO-3 OF REG-TRAILLER TO ARQSIVPF-QTDE-REG-GER OF DCLARQUIVOS-SIVPF. */
            _.Move(LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_3, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_QTDE_REG_GER);

            /*" -2990- ACCEPT WS-HORA-INI FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_INI);

            /*" -2993- COMPUTE SIT = (HI * 60 * 60) + (MI * 60) + SI + (DI / 100) */
            WS_HORAS.SIT.Value = (WS_HORAS.WS_HORA_INI_R.HI * 60 * 60) + (WS_HORAS.WS_HORA_INI_R.MI * 60) + WS_HORAS.WS_HORA_INI_R.SI + (WS_HORAS.WS_HORA_INI_R.DI / 100f);

            /*" -3001- PERFORM R1050_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1 */

            R1050_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1();

            /*" -3005- ACCEPT WS-HORA-FIM FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_FIM);

            /*" -3006- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF + (DF / 100) */
            WS_HORAS.SFT.Value = (WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (WS_HORAS.WS_HORA_FIM_R.MF * 60) + WS_HORAS.WS_HORA_FIM_R.SF + (WS_HORAS.WS_HORA_FIM_R.DF / 100f);

            /*" -3007- SUBTRACT SIT FROM SFT */
            WS_HORAS.SFT.Value = WS_HORAS.SFT - WS_HORAS.SIT;

            /*" -3008- ADD SFT TO STT(23) */
            TOTAIS_ROT.FILLER_20[23].STT.Value = TOTAIS_ROT.FILLER_20[23].STT + WS_HORAS.SFT;

            /*" -3011- ADD 1 TO SQT(23) */
            TOTAIS_ROT.FILLER_20[23].SQT.Value = TOTAIS_ROT.FILLER_20[23].SQT + 1;

            /*" -3012- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -3013- DISPLAY 'PF0619B - FIM ANORMAL' */
                _.Display($"PF0619B - FIM ANORMAL");

                /*" -3014- DISPLAY '          ERRO INSERT TABELA ARQUIVOS-SIVPF' */
                _.Display($"          ERRO INSERT TABELA ARQUIVOS-SIVPF");

                /*" -3016- DISPLAY '          SIGLA DO ARQIVO..................  ' ARQSIVPF-SIGLA-ARQUIVO OF DCLARQUIVOS-SIVPF */
                _.Display($"          SIGLA DO ARQIVO..................  {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SIGLA_ARQUIVO}");

                /*" -3018- DISPLAY '          NSAS SIVPF.......................  ' ARQSIVPF-NSAS-SIVPF OF DCLARQUIVOS-SIVPF */
                _.Display($"          NSAS SIVPF.......................  {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF}");

                /*" -3020- DISPLAY '          DATA GERACAO.....................  ' ARQSIVPF-DATA-GERACAO OF DCLARQUIVOS-SIVPF */
                _.Display($"          DATA GERACAO.....................  {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_GERACAO}");

                /*" -3022- DISPLAY '          QTDE. REGISTROS..................  ' ARQSIVPF-QTDE-REG-GER OF DCLARQUIVOS-SIVPF */
                _.Display($"          QTDE. REGISTROS..................  {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_QTDE_REG_GER}");

                /*" -3024- DISPLAY '          SQLCODE..........................  ' SQLCODE */
                _.Display($"          SQLCODE..........................  {DB.SQLCODE}");

                /*" -3025- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -3025- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R1050-00-CONTROLAR-ARQ-ENVIADO-DB-INSERT-1 */
        public void R1050_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1()
        {
            /*" -3001- EXEC SQL INSERT INTO SEGUROS.ARQUIVOS_SIVPF VALUES (:DCLARQUIVOS-SIVPF.ARQSIVPF-SIGLA-ARQUIVO, :DCLARQUIVOS-SIVPF.ARQSIVPF-SISTEMA-ORIGEM, :DCLARQUIVOS-SIVPF.ARQSIVPF-NSAS-SIVPF, :DCLARQUIVOS-SIVPF.ARQSIVPF-DATA-GERACAO, :DCLARQUIVOS-SIVPF.ARQSIVPF-QTDE-REG-GER, :DCLARQUIVOS-SIVPF.ARQSIVPF-DATA-PROCESSAMENTO) END-EXEC. */

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
            /*" -3036- MOVE 'R1100-00-GERAR-TOTIAS' TO PARAGRAFO. */
            _.Move("R1100-00-GERAR-TOTIAS", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3038- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3043- COMPUTE W-TOT-GERADO-PRP = W-QTD-LD-TIPO-1 + W-QTD-LD-TIPO-2 + W-QTD-LD-TIPO-3 + W-QTD-LD-TIPO-4. */
            WAREA_AUXILIAR.W_TOT_GERADO_PRP.Value = WAREA_AUXILIAR.W_QTD_LD_TIPO_1 + WAREA_AUXILIAR.W_QTD_LD_TIPO_2 + WAREA_AUXILIAR.W_QTD_LD_TIPO_3 + WAREA_AUXILIAR.W_QTD_LD_TIPO_4;

            /*" -3044- DISPLAY '===================================================' */
            _.Display($"===================================================");

            /*" -3045- DISPLAY 'PF0619B - TOTAIS DO PROCESSAMENTO DE PROPOSTAS PF' */
            _.Display($"PF0619B - TOTAIS DO PROCESSAMENTO DE PROPOSTAS PF");

            /*" -3046- DISPLAY '          TOTAL  REGISTROS LIDOS........... ' W-NSL */
            _.Display($"          TOTAL  REGISTROS LIDOS........... {WAREA_AUXILIAR.W_NSL}");

            /*" -3048- DISPLAY '          TOTAL  PROPOSTAS ATUALIZADAS..... ' W-TOT-ATU-PRP */
            _.Display($"          TOTAL  PROPOSTAS ATUALIZADAS..... {WAREA_AUXILIAR.W_TOT_ATU_PRP}");

            /*" -3049- DISPLAY '          TOTAL  REGISTROS GERADOS PRPSASSE' */
            _.Display($"          TOTAL  REGISTROS GERADOS PRPSASSE");

            /*" -3051- DISPLAY '          TOTAL  REGISTROS TP-1............ ' W-QTD-LD-TIPO-1 */
            _.Display($"          TOTAL  REGISTROS TP-1............ {WAREA_AUXILIAR.W_QTD_LD_TIPO_1}");

            /*" -3053- DISPLAY '          TOTAL  REGISTROS TP-2............ ' W-QTD-LD-TIPO-2 */
            _.Display($"          TOTAL  REGISTROS TP-2............ {WAREA_AUXILIAR.W_QTD_LD_TIPO_2}");

            /*" -3055- DISPLAY '          TOTAL  REGISTROS TP-3............ ' W-QTD-LD-TIPO-3 */
            _.Display($"          TOTAL  REGISTROS TP-3............ {WAREA_AUXILIAR.W_QTD_LD_TIPO_3}");

            /*" -3057- DISPLAY '          TOTAL  REGISTROS TP-4............ ' W-QTD-LD-TIPO-4 */
            _.Display($"          TOTAL  REGISTROS TP-4............ {WAREA_AUXILIAR.W_QTD_LD_TIPO_4}");

            /*" -3059- DISPLAY '          TOTAL  GERAL..................... ' W-TOT-GERADO-PRP. */
            _.Display($"          TOTAL  GERAL..................... {WAREA_AUXILIAR.W_TOT_GERADO_PRP}");

            /*" -3060- DISPLAY '---------------------------------------------------' */
            _.Display($"---------------------------------------------------");

            /*" -3061- DISPLAY 'PF0619B - TOTAIS DO PROCESSAMENTO DE BILHETES' */
            _.Display($"PF0619B - TOTAIS DO PROCESSAMENTO DE BILHETES");

            /*" -3062- DISPLAY '          TOTAL  REGISTROS LIDOS........... ' W-NSL */
            _.Display($"          TOTAL  REGISTROS LIDOS........... {WAREA_AUXILIAR.W_NSL}");

            /*" -3064- DISPLAY '          TOTAL  PROPOSTAS ATUALIZADAS..... ' W-TOT-ATU-PRP */
            _.Display($"          TOTAL  PROPOSTAS ATUALIZADAS..... {WAREA_AUXILIAR.W_TOT_ATU_PRP}");

            /*" -3065- DISPLAY '===================================================' */
            _.Display($"===================================================");

            /*" -3065- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_SAIDA*/

        [StopWatch]
        /*" R3000-GERAR-TB-CORPORATIVAS-SECTION */
        private void R3000_GERAR_TB_CORPORATIVAS_SECTION()
        {
            /*" -3074- PERFORM R3100-TRATA-CLIENTE. */

            R3100_TRATA_CLIENTE_SECTION();

            /*" -3075- IF EXISTE-CLIENTE */

            if (WAREA_AUXILIAR.W_LER_CLIENTE["EXISTE_CLIENTE"])
            {

                /*" -3076- PERFORM R3200-TRATA-END-TEL */

                R3200_TRATA_END_TEL_SECTION();

                /*" -3076- PERFORM R3300-TRATA-PROPOSTA. */

                R3300_TRATA_PROPOSTA_SECTION();
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_SAIDA*/

        [StopWatch]
        /*" R3100-TRATA-CLIENTE-SECTION */
        private void R3100_TRATA_CLIENTE_SECTION()
        {
            /*" -3086- MOVE 'R3100-TRATA-CLIENTE' TO PARAGRAFO. */
            _.Move("R3100-TRATA-CLIENTE", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3096- MOVE '    ' TO COMANDO. */
            _.Move("    ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3097- IF R1-TIPO-PESSOA OF REG-CLIENTES EQUAL 1 */

            if (LBFPF011.REG_CLIENTES.R1_TIPO_PESSOA == 1)
            {

                /*" -3098- PERFORM R3105-LER-PESSOA-FISICA */

                R3105_LER_PESSOA_FISICA_SECTION();

                /*" -3100- IF EXISTE-CLIENTE NEXT SENTENCE */

                if (WAREA_AUXILIAR.W_LER_CLIENTE["EXISTE_CLIENTE"])
                {

                    /*" -3101- ELSE */
                }
                else
                {


                    /*" -3102- GO TO R3100-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R3100_SAIDA*/ //GOTO
                    return;

                    /*" -3103- ELSE */
                }

            }
            else
            {


                /*" -3105- PERFORM R3110-LER-PESSOA-JURIDICA. */

                R3110_LER_PESSOA_JURIDICA_SECTION();
            }


            /*" -3106- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -3107- PERFORM R3115-INCLUIR-TAB-CORPORATIVAS */

                R3115_INCLUIR_TAB_CORPORATIVAS_SECTION();

                /*" -3108- ELSE */
            }
            else
            {


                /*" -3109- IF SQLCODE EQUAL 00 */

                if (DB.SQLCODE == 00)
                {

                    /*" -3112- PERFORM R3150-LER-TAB-CORPORATIVAS */

                    R3150_LER_TAB_CORPORATIVAS_SECTION();

                    /*" -3112- PERFORM R3135-INCLUIR-END-EMAIL. */

                    R3135_INCLUIR_END_EMAIL_SECTION();
                }

            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3100_SAIDA*/

        [StopWatch]
        /*" R3105-LER-PESSOA-FISICA-SECTION */
        private void R3105_LER_PESSOA_FISICA_SECTION()
        {
            /*" -3122- MOVE 'R3105-LER-PESSOA-FISICA' TO PARAGRAFO. */
            _.Move("R3105-LER-PESSOA-FISICA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3124- MOVE 'SELECT PESSOA_FISICA' TO COMANDO. */
            _.Move("SELECT PESSOA_FISICA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3127- MOVE R1-CGC-CPF OF REG-CLIENTES TO CPF OF DCLPESSOA-FISICA. */
            _.Move(LBFPF011.REG_CLIENTES.R1_CGC_CPF, PESFIS.DCLPESSOA_FISICA.CPF);

            /*" -3129- MOVE R1-DATA-NASCIMENTO OF REG-CLIENTES TO W-DATA-NASCIMENTO. */
            _.Move(LBFPF011.REG_CLIENTES.R1_DATA_NASCIMENTO, WAREA_AUXILIAR.W_DATA_NASCIMENTO);

            /*" -3131- MOVE W-DIA-NASCIMENTO TO W-DIA-SQL OF W-DATA-SQL1. */
            _.Move(WAREA_AUXILIAR.FILLER_3.W_DIA_NASCIMENTO, WAREA_AUXILIAR.W_DATA_SQL1.W_DIA_SQL);

            /*" -3133- MOVE W-MES-NASCIMENTO TO W-MES-SQL OF W-DATA-SQL1. */
            _.Move(WAREA_AUXILIAR.FILLER_3.W_MES_NASCIMENTO, WAREA_AUXILIAR.W_DATA_SQL1.W_MES_SQL);

            /*" -3136- MOVE W-ANO-NASCIMENTO TO W-ANO-SQL OF W-DATA-SQL1. */
            _.Move(WAREA_AUXILIAR.FILLER_3.W_ANO_NASCIMENTO, WAREA_AUXILIAR.W_DATA_SQL1.W_ANO_SQL);

            /*" -3140- MOVE '-' TO W-BARRA1 OF W-DATA-SQL1, W-BARRA2 OF W-DATA-SQL1. */
            _.Move("-", WAREA_AUXILIAR.W_DATA_SQL1.W_BARRA1_1);
            _.Move("-", WAREA_AUXILIAR.W_DATA_SQL1.W_BARRA2_1);


            /*" -3143- MOVE W-DATA-SQL TO DATA-NASCIMENTO OF DCLPESSOA-FISICA. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL, PESFIS.DCLPESSOA_FISICA.DATA_NASCIMENTO);

            /*" -3144- IF R1-IDE-SEXO OF REG-CLIENTES EQUAL 1 */

            if (LBFPF011.REG_CLIENTES.R1_IDE_SEXO == 1)
            {

                /*" -3146- MOVE 'M' TO SEXO OF DCLPESSOA-FISICA */
                _.Move("M", PESFIS.DCLPESSOA_FISICA.SEXO);

                /*" -3147- ELSE */
            }
            else
            {


                /*" -3152- MOVE 'F' TO SEXO OF DCLPESSOA-FISICA. */
                _.Move("F", PESFIS.DCLPESSOA_FISICA.SEXO);
            }


            /*" -3153- ACCEPT WS-HORA-INI FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_INI);

            /*" -3156- COMPUTE SIT = (HI * 60 * 60) + (MI * 60) + SI + (DI / 100) */
            WS_HORAS.SIT.Value = (WS_HORAS.WS_HORA_INI_R.HI * 60 * 60) + (WS_HORAS.WS_HORA_INI_R.MI * 60) + WS_HORAS.WS_HORA_INI_R.SI + (WS_HORAS.WS_HORA_INI_R.DI / 100f);

            /*" -3188- PERFORM R3105_LER_PESSOA_FISICA_DB_SELECT_1 */

            R3105_LER_PESSOA_FISICA_DB_SELECT_1();

            /*" -3192- ACCEPT WS-HORA-FIM FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_FIM);

            /*" -3193- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF + (DF / 100) */
            WS_HORAS.SFT.Value = (WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (WS_HORAS.WS_HORA_FIM_R.MF * 60) + WS_HORAS.WS_HORA_FIM_R.SF + (WS_HORAS.WS_HORA_FIM_R.DF / 100f);

            /*" -3194- SUBTRACT SIT FROM SFT */
            WS_HORAS.SFT.Value = WS_HORAS.SFT - WS_HORAS.SIT;

            /*" -3195- ADD SFT TO STT(24) */
            TOTAIS_ROT.FILLER_20[24].STT.Value = TOTAIS_ROT.FILLER_20[24].STT + WS_HORAS.SFT;

            /*" -3198- ADD 1 TO SQT(24) */
            TOTAIS_ROT.FILLER_20[24].SQT.Value = TOTAIS_ROT.FILLER_20[24].SQT + 1;

            /*" -3200- MOVE 1 TO W-LER-CLIENTE. */
            _.Move(1, WAREA_AUXILIAR.W_LER_CLIENTE);

            /*" -3201- IF SQLCODE NOT EQUAL 00 AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -3202- IF SQLCODE EQUAL -305 OR -180 OR -181 */

                if (DB.SQLCODE.In("-305", "-180", "-181"))
                {

                    /*" -3203- MOVE 0 TO W-LER-CLIENTE */
                    _.Move(0, WAREA_AUXILIAR.W_LER_CLIENTE);

                    /*" -3204- DISPLAY 'PF0612B - DADO INVALIDO PESSOA-FISICA  ' */
                    _.Display($"PF0612B - DADO INVALIDO PESSOA-FISICA  ");

                    /*" -3206- DISPLAY '          NUMERO DA PROPOSTA............  ' R1-NUM-PROPOSTA OF REG-CLIENTES */
                    _.Display($"          NUMERO DA PROPOSTA............  {LBFPF011.REG_CLIENTES.R1_NUM_PROPOSTA}");

                    /*" -3208- DISPLAY '          DATA NASCIMENTO...............  ' DATA-NASCIMENTO OF DCLPESSOA-FISICA */
                    _.Display($"          DATA NASCIMENTO...............  {PESFIS.DCLPESSOA_FISICA.DATA_NASCIMENTO}");

                    /*" -3210- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                    _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                    /*" -3211- ELSE */
                }
                else
                {


                    /*" -3212- DISPLAY 'PF0612B - FIM ANORMAL' */
                    _.Display($"PF0612B - FIM ANORMAL");

                    /*" -3213- DISPLAY '          ERRO NO ACESSO A PESSOA-FISICA  ' */
                    _.Display($"          ERRO NO ACESSO A PESSOA-FISICA  ");

                    /*" -3215- DISPLAY '          NUMERO DA PROPOSTA............  ' R1-NUM-PROPOSTA OF REG-CLIENTES */
                    _.Display($"          NUMERO DA PROPOSTA............  {LBFPF011.REG_CLIENTES.R1_NUM_PROPOSTA}");

                    /*" -3217- DISPLAY '          CPF...........................  ' CPF OF DCLPESSOA-FISICA */
                    _.Display($"          CPF...........................  {PESFIS.DCLPESSOA_FISICA.CPF}");

                    /*" -3219- DISPLAY '          DATA NASCIMENTO...............  ' DATA-NASCIMENTO OF DCLPESSOA-FISICA */
                    _.Display($"          DATA NASCIMENTO...............  {PESFIS.DCLPESSOA_FISICA.DATA_NASCIMENTO}");

                    /*" -3221- DISPLAY '          SEXO..........................  ' SEXO OF DCLPESSOA-FISICA */
                    _.Display($"          SEXO..........................  {PESFIS.DCLPESSOA_FISICA.SEXO}");

                    /*" -3223- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                    _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                    /*" -3224- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -3224- PERFORM R9999-00-FINALIZAR. */

                    R9999_00_FINALIZAR_SECTION();
                }

            }


        }

        [StopWatch]
        /*" R3105-LER-PESSOA-FISICA-DB-SELECT-1 */
        public void R3105_LER_PESSOA_FISICA_DB_SELECT_1()
        {
            /*" -3188- EXEC SQL SELECT COD_PESSOA, CPF, DATA_NASCIMENTO, SEXO, TIPO_IDENT_SIVPF, NUM_IDENTIDADE, ORGAO_EXPEDIDOR, UF_EXPEDIDORA, DATA_EXPEDICAO, COD_CBO, COD_USUARIO, ESTADO_CIVIL, TIMESTAMP INTO :DCLPESSOA-FISICA.COD-PESSOA:VIND-COD-PESSOA, :DCLPESSOA-FISICA.CPF:VIND-CPF, :DCLPESSOA-FISICA.DATA-NASCIMENTO:VIND-DTNASCI, :DCLPESSOA-FISICA.SEXO:VIND-SEXO, :DCLPESSOA-FISICA.TIPO-IDENT-SIVPF:VIND-TP-IDENT, :DCLPESSOA-FISICA.NUM-IDENTIDADE:VIND-NUM-IDENT, :DCLPESSOA-FISICA.ORGAO-EXPEDIDOR:VIND-ORGAO-EXP, :DCLPESSOA-FISICA.UF-EXPEDIDORA:VIND-UF-EXP, :DCLPESSOA-FISICA.DATA-EXPEDICAO:VIND-DTEXPEDI, :DCLPESSOA-FISICA.COD-CBO:VIND-COD-CBO, :DCLPESSOA-FISICA.COD-USUARIO:VIND-COD-USUR, :DCLPESSOA-FISICA.ESTADO-CIVIL, :DCLPESSOA-FISICA.TIMESTAMP:VIND-TIMESTAMP FROM SEGUROS.PESSOA_FISICA WHERE CPF = :DCLPESSOA-FISICA.CPF AND DATA_NASCIMENTO = :DCLPESSOA-FISICA.DATA-NASCIMENTO AND SEXO = :DCLPESSOA-FISICA.SEXO WITH UR END-EXEC. */

            var r3105_LER_PESSOA_FISICA_DB_SELECT_1_Query1 = new R3105_LER_PESSOA_FISICA_DB_SELECT_1_Query1()
            {
                DATA_NASCIMENTO = PESFIS.DCLPESSOA_FISICA.DATA_NASCIMENTO.ToString(),
                SEXO = PESFIS.DCLPESSOA_FISICA.SEXO.ToString(),
                CPF = PESFIS.DCLPESSOA_FISICA.CPF.ToString(),
            };

            var executed_1 = R3105_LER_PESSOA_FISICA_DB_SELECT_1_Query1.Execute(r3105_LER_PESSOA_FISICA_DB_SELECT_1_Query1);
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
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3105_SAIDA*/

        [StopWatch]
        /*" R3110-LER-PESSOA-JURIDICA-SECTION */
        private void R3110_LER_PESSOA_JURIDICA_SECTION()
        {
            /*" -3234- MOVE 'R3110-LER-PESSOA-JURIDICA' TO PARAGRAFO. */
            _.Move("R3110-LER-PESSOA-JURIDICA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3236- MOVE 'SELECT' TO COMANDO. */
            _.Move("SELECT", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3240- MOVE R1-CGC-CPF OF REG-CLIENTES TO CGC OF DCLPESSOA-JURIDICA. */
            _.Move(LBFPF011.REG_CLIENTES.R1_CGC_CPF, PESJUR.DCLPESSOA_JURIDICA.CGC);

            /*" -3241- ACCEPT WS-HORA-INI FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_INI);

            /*" -3244- COMPUTE SIT = (HI * 60 * 60) + (MI * 60) + SI + (DI / 100) */
            WS_HORAS.SIT.Value = (WS_HORAS.WS_HORA_INI_R.HI * 60 * 60) + (WS_HORAS.WS_HORA_INI_R.MI * 60) + WS_HORAS.WS_HORA_INI_R.SI + (WS_HORAS.WS_HORA_INI_R.DI / 100f);

            /*" -3258- PERFORM R3110_LER_PESSOA_JURIDICA_DB_SELECT_1 */

            R3110_LER_PESSOA_JURIDICA_DB_SELECT_1();

            /*" -3262- ACCEPT WS-HORA-FIM FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_FIM);

            /*" -3263- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF + (DF / 100) */
            WS_HORAS.SFT.Value = (WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (WS_HORAS.WS_HORA_FIM_R.MF * 60) + WS_HORAS.WS_HORA_FIM_R.SF + (WS_HORAS.WS_HORA_FIM_R.DF / 100f);

            /*" -3264- SUBTRACT SIT FROM SFT */
            WS_HORAS.SFT.Value = WS_HORAS.SFT - WS_HORAS.SIT;

            /*" -3265- ADD SFT TO STT(25) */
            TOTAIS_ROT.FILLER_20[25].STT.Value = TOTAIS_ROT.FILLER_20[25].STT + WS_HORAS.SFT;

            /*" -3268- ADD 1 TO SQT(25) */
            TOTAIS_ROT.FILLER_20[25].SQT.Value = TOTAIS_ROT.FILLER_20[25].SQT + 1;

            /*" -3269- IF SQLCODE NOT EQUAL 00 AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -3270- DISPLAY 'PF0619B - FIM ANORMAL' */
                _.Display($"PF0619B - FIM ANORMAL");

                /*" -3271- DISPLAY '          ERRO NO ACESSO A PESSOA-JURIDICA' */
                _.Display($"          ERRO NO ACESSO A PESSOA-JURIDICA");

                /*" -3273- DISPLAY '          NUMERO DA PROPOSTA............  ' R1-NUM-PROPOSTA OF REG-CLIENTES */
                _.Display($"          NUMERO DA PROPOSTA............  {LBFPF011.REG_CLIENTES.R1_NUM_PROPOSTA}");

                /*" -3275- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -3276- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -3276- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R3110-LER-PESSOA-JURIDICA-DB-SELECT-1 */
        public void R3110_LER_PESSOA_JURIDICA_DB_SELECT_1()
        {
            /*" -3258- EXEC SQL SELECT COD_PESSOA, CGC, NOME_FANTASIA, COD_USUARIO, TIMESTAMP INTO :DCLPESSOA-JURIDICA.COD-PESSOA, :DCLPESSOA-JURIDICA.CGC, :DCLPESSOA-JURIDICA.NOME-FANTASIA, :DCLPESSOA-JURIDICA.COD-USUARIO, :DCLPESSOA-JURIDICA.TIMESTAMP FROM SEGUROS.PESSOA_JURIDICA WHERE CGC = :DCLPESSOA-JURIDICA.CGC WITH UR END-EXEC. */

            var r3110_LER_PESSOA_JURIDICA_DB_SELECT_1_Query1 = new R3110_LER_PESSOA_JURIDICA_DB_SELECT_1_Query1()
            {
                CGC = PESJUR.DCLPESSOA_JURIDICA.CGC.ToString(),
            };

            var executed_1 = R3110_LER_PESSOA_JURIDICA_DB_SELECT_1_Query1.Execute(r3110_LER_PESSOA_JURIDICA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.COD_PESSOA, PESJUR.DCLPESSOA_JURIDICA.COD_PESSOA);
                _.Move(executed_1.CGC, PESJUR.DCLPESSOA_JURIDICA.CGC);
                _.Move(executed_1.NOME_FANTASIA, PESJUR.DCLPESSOA_JURIDICA.NOME_FANTASIA);
                _.Move(executed_1.COD_USUARIO, PESJUR.DCLPESSOA_JURIDICA.COD_USUARIO);
                _.Move(executed_1.TIMESTAMP, PESJUR.DCLPESSOA_JURIDICA.TIMESTAMP);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3110_SAIDA*/

        [StopWatch]
        /*" R3115-INCLUIR-TAB-CORPORATIVAS-SECTION */
        private void R3115_INCLUIR_TAB_CORPORATIVAS_SECTION()
        {
            /*" -3285- MOVE 'R3115-INCLUIR-TAB-CORPORATIVAS' TO PARAGRAFO. */
            _.Move("R3115-INCLUIR-TAB-CORPORATIVAS", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3287- MOVE '      ' TO COMANDO. */
            _.Move("      ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3289- PERFORM R3120-INCLUIR-TAB-PESSOA. */

            R3120_INCLUIR_TAB_PESSOA_SECTION();

            /*" -3290- IF R1-TIPO-PESSOA OF REG-CLIENTES EQUAL 1 */

            if (LBFPF011.REG_CLIENTES.R1_TIPO_PESSOA == 1)
            {

                /*" -3291- PERFORM R3125-INCLUIR-PESSOA-FISICA */

                R3125_INCLUIR_PESSOA_FISICA_SECTION();

                /*" -3292- ELSE */
            }
            else
            {


                /*" -3294- PERFORM R3130-INCLUIR-PESSOA-JURIDICA. */

                R3130_INCLUIR_PESSOA_JURIDICA_SECTION();
            }


            /*" -3294- PERFORM R3135-INCLUIR-END-EMAIL. */

            R3135_INCLUIR_END_EMAIL_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3115_SAIDA*/

        [StopWatch]
        /*" R3120-INCLUIR-TAB-PESSOA-SECTION */
        private void R3120_INCLUIR_TAB_PESSOA_SECTION()
        {
            /*" -3304- MOVE 'R3120-INCLUIR-TAB-PESSOA' TO PARAGRAFO. */
            _.Move("R3120-INCLUIR-TAB-PESSOA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3306- MOVE '      ' TO COMANDO. */
            _.Move("      ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3307- IF W-OBTER-MAX-PESSOA EQUAL 'NAO' */

            if (WAREA_AUXILIAR.W_OBTER_MAX_PESSOA == "NAO")
            {

                /*" -3308- MOVE 'SIM' TO W-OBTER-MAX-PESSOA */
                _.Move("SIM", WAREA_AUXILIAR.W_OBTER_MAX_PESSOA);

                /*" -3310- PERFORM R3121-OBTER-MAX-COD-PESSOA. */

                R3121_OBTER_MAX_COD_PESSOA_SECTION();
            }


            /*" -3313- COMPUTE W-COD-PESSOA = W-COD-PESSOA + 1 */
            WAREA_AUXILIAR.W_COD_PESSOA.Value = WAREA_AUXILIAR.W_COD_PESSOA + 1;

            /*" -3316- MOVE W-COD-PESSOA TO PESSOA-COD-PESSOA OF DCLPESSOA. */
            _.Move(WAREA_AUXILIAR.W_COD_PESSOA, PESSOA.DCLPESSOA.PESSOA_COD_PESSOA);

            /*" -3319- MOVE R1-NOME-PESSOA OF REG-CLIENTES TO PESSOA-NOME-PESSOA OF DCLPESSOA. */
            _.Move(LBFPF011.REG_CLIENTES.R1_NOME_PESSOA, PESSOA.DCLPESSOA.PESSOA_NOME_PESSOA);

            /*" -3322- MOVE ' ' TO PESSOA-TIPO-PESSOA OF DCLPESSOA. */
            _.Move(" ", PESSOA.DCLPESSOA.PESSOA_TIPO_PESSOA);

            /*" -3323- IF R1-TIPO-PESSOA OF REG-CLIENTES EQUAL 1 */

            if (LBFPF011.REG_CLIENTES.R1_TIPO_PESSOA == 1)
            {

                /*" -3325- MOVE 'F' TO PESSOA-TIPO-PESSOA OF DCLPESSOA */
                _.Move("F", PESSOA.DCLPESSOA.PESSOA_TIPO_PESSOA);

                /*" -3326- ELSE */
            }
            else
            {


                /*" -3327- IF R1-TIPO-PESSOA OF REG-CLIENTES EQUAL 2 */

                if (LBFPF011.REG_CLIENTES.R1_TIPO_PESSOA == 2)
                {

                    /*" -3330- MOVE 'J' TO PESSOA-TIPO-PESSOA OF DCLPESSOA. */
                    _.Move("J", PESSOA.DCLPESSOA.PESSOA_TIPO_PESSOA);
                }

            }


            /*" -3334- MOVE 'PF0619B' TO PESSOA-COD-USUARIO OF DCLPESSOA. */
            _.Move("PF0619B", PESSOA.DCLPESSOA.PESSOA_COD_USUARIO);

            /*" -3335- ACCEPT WS-HORA-INI FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_INI);

            /*" -3338- COMPUTE SIT = (HI * 60 * 60) + (MI * 60) + SI + (DI / 100) */
            WS_HORAS.SIT.Value = (WS_HORAS.WS_HORA_INI_R.HI * 60 * 60) + (WS_HORAS.WS_HORA_INI_R.MI * 60) + WS_HORAS.WS_HORA_INI_R.SI + (WS_HORAS.WS_HORA_INI_R.DI / 100f);

            /*" -3346- PERFORM R3120_INCLUIR_TAB_PESSOA_DB_INSERT_1 */

            R3120_INCLUIR_TAB_PESSOA_DB_INSERT_1();

            /*" -3350- ACCEPT WS-HORA-FIM FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_FIM);

            /*" -3351- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF + (DF / 100) */
            WS_HORAS.SFT.Value = (WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (WS_HORAS.WS_HORA_FIM_R.MF * 60) + WS_HORAS.WS_HORA_FIM_R.SF + (WS_HORAS.WS_HORA_FIM_R.DF / 100f);

            /*" -3352- SUBTRACT SIT FROM SFT */
            WS_HORAS.SFT.Value = WS_HORAS.SFT - WS_HORAS.SIT;

            /*" -3353- ADD SFT TO STT(26) */
            TOTAIS_ROT.FILLER_20[26].STT.Value = TOTAIS_ROT.FILLER_20[26].STT + WS_HORAS.SFT;

            /*" -3356- ADD 1 TO SQT(26) */
            TOTAIS_ROT.FILLER_20[26].SQT.Value = TOTAIS_ROT.FILLER_20[26].SQT + 1;

            /*" -3358- IF (SQLCODE NOT EQUAL ZEROS) OR (PESSOA-NOME-PESSOA OF DCLPESSOA EQUAL SPACES) */

            if ((DB.SQLCODE != 00) || (PESSOA.DCLPESSOA.PESSOA_NOME_PESSOA.IsEmpty()))
            {

                /*" -3359- DISPLAY 'PF0619B - FIM ANORMAL' */
                _.Display($"PF0619B - FIM ANORMAL");

                /*" -3360- DISPLAY '          ERRO INSERT DA TABELA PESSOA' */
                _.Display($"          ERRO INSERT DA TABELA PESSOA");

                /*" -3362- DISPLAY '          CODIGO PESSOA.................  ' PESSOA-COD-PESSOA OF DCLPESSOA */
                _.Display($"          CODIGO PESSOA.................  {PESSOA.DCLPESSOA.PESSOA_COD_PESSOA}");

                /*" -3364- DISPLAY '          NOME DA PESSOA................  ' PESSOA-NOME-PESSOA OF DCLPESSOA */
                _.Display($"          NOME DA PESSOA................  {PESSOA.DCLPESSOA.PESSOA_NOME_PESSOA}");

                /*" -3366- DISPLAY '          NUMERO PROPOSTA...............  ' R1-NUM-PROPOSTA OF REG-CLIENTES */
                _.Display($"          NUMERO PROPOSTA...............  {LBFPF011.REG_CLIENTES.R1_NUM_PROPOSTA}");

                /*" -3368- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -3369- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -3369- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R3120-INCLUIR-TAB-PESSOA-DB-INSERT-1 */
        public void R3120_INCLUIR_TAB_PESSOA_DB_INSERT_1()
        {
            /*" -3346- EXEC SQL INSERT INTO SEGUROS.PESSOA VALUES (:DCLPESSOA.PESSOA-COD-PESSOA, :DCLPESSOA.PESSOA-NOME-PESSOA, CURRENT TIMESTAMP, :DCLPESSOA.PESSOA-COD-USUARIO, :DCLPESSOA.PESSOA-TIPO-PESSOA, NULL) END-EXEC. */

            var r3120_INCLUIR_TAB_PESSOA_DB_INSERT_1_Insert1 = new R3120_INCLUIR_TAB_PESSOA_DB_INSERT_1_Insert1()
            {
                PESSOA_COD_PESSOA = PESSOA.DCLPESSOA.PESSOA_COD_PESSOA.ToString(),
                PESSOA_NOME_PESSOA = PESSOA.DCLPESSOA.PESSOA_NOME_PESSOA.ToString(),
                PESSOA_COD_USUARIO = PESSOA.DCLPESSOA.PESSOA_COD_USUARIO.ToString(),
                PESSOA_TIPO_PESSOA = PESSOA.DCLPESSOA.PESSOA_TIPO_PESSOA.ToString(),
            };

            R3120_INCLUIR_TAB_PESSOA_DB_INSERT_1_Insert1.Execute(r3120_INCLUIR_TAB_PESSOA_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3120_SAIDA*/

        [StopWatch]
        /*" R3121-OBTER-MAX-COD-PESSOA-SECTION */
        private void R3121_OBTER_MAX_COD_PESSOA_SECTION()
        {
            /*" -3379- MOVE 'R3121-OBTER-MAX-COD-PESSOA' TO PARAGRAFO. */
            _.Move("R3121-OBTER-MAX-COD-PESSOA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3382- MOVE 'MAX SEGUROS.PESSOA' TO COMANDO. */
            _.Move("MAX SEGUROS.PESSOA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3383- ACCEPT WS-HORA-INI FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_INI);

            /*" -3386- COMPUTE SIT = (HI * 60 * 60) + (MI * 60) + SI + (DI / 100) */
            WS_HORAS.SIT.Value = (WS_HORAS.WS_HORA_INI_R.HI * 60 * 60) + (WS_HORAS.WS_HORA_INI_R.MI * 60) + WS_HORAS.WS_HORA_INI_R.SI + (WS_HORAS.WS_HORA_INI_R.DI / 100f);

            /*" -3391- PERFORM R3121_OBTER_MAX_COD_PESSOA_DB_SELECT_1 */

            R3121_OBTER_MAX_COD_PESSOA_DB_SELECT_1();

            /*" -3395- ACCEPT WS-HORA-FIM FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_FIM);

            /*" -3396- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF + (DF / 100) */
            WS_HORAS.SFT.Value = (WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (WS_HORAS.WS_HORA_FIM_R.MF * 60) + WS_HORAS.WS_HORA_FIM_R.SF + (WS_HORAS.WS_HORA_FIM_R.DF / 100f);

            /*" -3397- SUBTRACT SIT FROM SFT */
            WS_HORAS.SFT.Value = WS_HORAS.SFT - WS_HORAS.SIT;

            /*" -3398- ADD SFT TO STT(27) */
            TOTAIS_ROT.FILLER_20[27].STT.Value = TOTAIS_ROT.FILLER_20[27].STT + WS_HORAS.SFT;

            /*" -3401- ADD 1 TO SQT(27) */
            TOTAIS_ROT.FILLER_20[27].SQT.Value = TOTAIS_ROT.FILLER_20[27].SQT + 1;

            /*" -3402- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -3403- DISPLAY 'PF0619B - FIM ANORMAL' */
                _.Display($"PF0619B - FIM ANORMAL");

                /*" -3404- DISPLAY '          ERRO NO SELECT MAX TAB. PESSOA' */
                _.Display($"          ERRO NO SELECT MAX TAB. PESSOA");

                /*" -3406- DISPLAY '          NUMERO DA PROPOSTA............  ' R1-NUM-PROPOSTA OF REG-CLIENTES */
                _.Display($"          NUMERO DA PROPOSTA............  {LBFPF011.REG_CLIENTES.R1_NUM_PROPOSTA}");

                /*" -3408- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -3409- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -3411- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


            /*" -3412- MOVE PESSOA-COD-PESSOA OF DCLPESSOA TO W-COD-PESSOA. */
            _.Move(PESSOA.DCLPESSOA.PESSOA_COD_PESSOA, WAREA_AUXILIAR.W_COD_PESSOA);

        }

        [StopWatch]
        /*" R3121-OBTER-MAX-COD-PESSOA-DB-SELECT-1 */
        public void R3121_OBTER_MAX_COD_PESSOA_DB_SELECT_1()
        {
            /*" -3391- EXEC SQL SELECT VALUE(MAX(COD_PESSOA),0) INTO :DCLPESSOA.PESSOA-COD-PESSOA FROM SEGUROS.PESSOA WITH UR END-EXEC. */

            var r3121_OBTER_MAX_COD_PESSOA_DB_SELECT_1_Query1 = new R3121_OBTER_MAX_COD_PESSOA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R3121_OBTER_MAX_COD_PESSOA_DB_SELECT_1_Query1.Execute(r3121_OBTER_MAX_COD_PESSOA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PESSOA_COD_PESSOA, PESSOA.DCLPESSOA.PESSOA_COD_PESSOA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3121_SAIDA*/

        [StopWatch]
        /*" R3125-INCLUIR-PESSOA-FISICA-SECTION */
        private void R3125_INCLUIR_PESSOA_FISICA_SECTION()
        {
            /*" -3422- MOVE 'R3125-INCLUIR-PESSOAS-FISICA' TO PARAGRAFO. */
            _.Move("R3125-INCLUIR-PESSOAS-FISICA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3424- MOVE 'INSERT PESSOA-FISICA' TO COMANDO. */
            _.Move("INSERT PESSOA-FISICA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3427- MOVE PESSOA-COD-PESSOA OF DCLPESSOA TO COD-PESSOA OF DCLPESSOA-FISICA. */
            _.Move(PESSOA.DCLPESSOA.PESSOA_COD_PESSOA, PESFIS.DCLPESSOA_FISICA.COD_PESSOA);

            /*" -3430- MOVE R1-CGC-CPF OF REG-CLIENTES TO CPF OF DCLPESSOA-FISICA. */
            _.Move(LBFPF011.REG_CLIENTES.R1_CGC_CPF, PESFIS.DCLPESSOA_FISICA.CPF);

            /*" -3432- MOVE R1-DATA-NASCIMENTO OF REG-CLIENTES TO W-DATA-NASCIMENTO. */
            _.Move(LBFPF011.REG_CLIENTES.R1_DATA_NASCIMENTO, WAREA_AUXILIAR.W_DATA_NASCIMENTO);

            /*" -3434- MOVE W-DIA-NASCIMENTO TO W-DIA-SQL OF W-DATA-SQL1. */
            _.Move(WAREA_AUXILIAR.FILLER_3.W_DIA_NASCIMENTO, WAREA_AUXILIAR.W_DATA_SQL1.W_DIA_SQL);

            /*" -3436- MOVE W-MES-NASCIMENTO TO W-MES-SQL OF W-DATA-SQL1. */
            _.Move(WAREA_AUXILIAR.FILLER_3.W_MES_NASCIMENTO, WAREA_AUXILIAR.W_DATA_SQL1.W_MES_SQL);

            /*" -3439- MOVE W-ANO-NASCIMENTO TO W-ANO-SQL OF W-DATA-SQL1. */
            _.Move(WAREA_AUXILIAR.FILLER_3.W_ANO_NASCIMENTO, WAREA_AUXILIAR.W_DATA_SQL1.W_ANO_SQL);

            /*" -3443- MOVE '-' TO W-BARRA1 OF W-DATA-SQL1, W-BARRA2 OF W-DATA-SQL1. */
            _.Move("-", WAREA_AUXILIAR.W_DATA_SQL1.W_BARRA1_1);
            _.Move("-", WAREA_AUXILIAR.W_DATA_SQL1.W_BARRA2_1);


            /*" -3446- MOVE W-DATA-SQL TO DATA-NASCIMENTO OF DCLPESSOA-FISICA. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL, PESFIS.DCLPESSOA_FISICA.DATA_NASCIMENTO);

            /*" -3447- IF R1-IDE-SEXO OF REG-CLIENTES EQUAL 1 */

            if (LBFPF011.REG_CLIENTES.R1_IDE_SEXO == 1)
            {

                /*" -3449- MOVE 'M' TO SEXO OF DCLPESSOA-FISICA */
                _.Move("M", PESFIS.DCLPESSOA_FISICA.SEXO);

                /*" -3450- ELSE */
            }
            else
            {


                /*" -3453- MOVE 'F' TO SEXO OF DCLPESSOA-FISICA. */
                _.Move("F", PESFIS.DCLPESSOA_FISICA.SEXO);
            }


            /*" -3456- MOVE SPACES TO TIPO-IDENT-SIVPF OF DCLPESSOA-FISICA. */
            _.Move("", PESFIS.DCLPESSOA_FISICA.TIPO_IDENT_SIVPF);

            /*" -3459- MOVE R1-NUM-IDENTIDADE OF REG-CLIENTES TO NUM-IDENTIDADE OF DCLPESSOA-FISICA. */
            _.Move(LBFPF011.REG_CLIENTES.R1_NUM_IDENTIDADE, PESFIS.DCLPESSOA_FISICA.NUM_IDENTIDADE);

            /*" -3462- MOVE R1-ORGAO-EXPEDIDOR OF REG-CLIENTES TO ORGAO-EXPEDIDOR OF DCLPESSOA-FISICA. */
            _.Move(LBFPF011.REG_CLIENTES.R1_ORGAO_EXPEDIDOR, PESFIS.DCLPESSOA_FISICA.ORGAO_EXPEDIDOR);

            /*" -3465- MOVE R1-UF-EXPEDIDORA OF REG-CLIENTES TO UF-EXPEDIDORA OF DCLPESSOA-FISICA. */
            _.Move(LBFPF011.REG_CLIENTES.R1_UF_EXPEDIDORA, PESFIS.DCLPESSOA_FISICA.UF_EXPEDIDORA);

            /*" -3466- IF R1-ESTADO-CIVIL OF REG-CLIENTES EQUAL 1 */

            if (LBFPF011.REG_CLIENTES.R1_ESTADO_CIVIL == 1)
            {

                /*" -3468- MOVE 'S' TO ESTADO-CIVIL OF DCLPESSOA-FISICA */
                _.Move("S", PESFIS.DCLPESSOA_FISICA.ESTADO_CIVIL);

                /*" -3469- ELSE */
            }
            else
            {


                /*" -3470- IF R1-ESTADO-CIVIL OF REG-CLIENTES EQUAL 2 */

                if (LBFPF011.REG_CLIENTES.R1_ESTADO_CIVIL == 2)
                {

                    /*" -3472- MOVE 'C' TO ESTADO-CIVIL OF DCLPESSOA-FISICA */
                    _.Move("C", PESFIS.DCLPESSOA_FISICA.ESTADO_CIVIL);

                    /*" -3473- ELSE */
                }
                else
                {


                    /*" -3474- IF R1-ESTADO-CIVIL OF REG-CLIENTES EQUAL 3 */

                    if (LBFPF011.REG_CLIENTES.R1_ESTADO_CIVIL == 3)
                    {

                        /*" -3476- MOVE 'V' TO ESTADO-CIVIL OF DCLPESSOA-FISICA */
                        _.Move("V", PESFIS.DCLPESSOA_FISICA.ESTADO_CIVIL);

                        /*" -3477- ELSE */
                    }
                    else
                    {


                        /*" -3480- MOVE 'O' TO ESTADO-CIVIL OF DCLPESSOA-FISICA. */
                        _.Move("O", PESFIS.DCLPESSOA_FISICA.ESTADO_CIVIL);
                    }

                }

            }


            /*" -3481- IF R1-DATA-EXPEDICAO-RG OF REG-CLIENTES GREATER ZEROS */

            if (LBFPF011.REG_CLIENTES.R1_DATA_EXPEDICAO_RG > 00)
            {

                /*" -3484- MOVE R1-DATA-EXPEDICAO-RG OF REG-CLIENTES TO W-DATA-TRABALHO */
                _.Move(LBFPF011.REG_CLIENTES.R1_DATA_EXPEDICAO_RG, WAREA_AUXILIAR.W_DATA_TRABALHO);

                /*" -3486- MOVE W-DIA-TRABALHO TO W-DIA-SQL OF W-DATA-SQL1 */
                _.Move(WAREA_AUXILIAR.FILLER_2.W_DIA_TRABALHO, WAREA_AUXILIAR.W_DATA_SQL1.W_DIA_SQL);

                /*" -3488- MOVE W-MES-TRABALHO TO W-MES-SQL OF W-DATA-SQL1 */
                _.Move(WAREA_AUXILIAR.FILLER_2.W_MES_TRABALHO, WAREA_AUXILIAR.W_DATA_SQL1.W_MES_SQL);

                /*" -3491- MOVE W-ANO-TRABALHO TO W-ANO-SQL OF W-DATA-SQL1 */
                _.Move(WAREA_AUXILIAR.FILLER_2.W_ANO_TRABALHO, WAREA_AUXILIAR.W_DATA_SQL1.W_ANO_SQL);

                /*" -3495- MOVE '-' TO W-BARRA1 OF W-DATA-SQL1 W-BARRA2 OF W-DATA-SQL1 */
                _.Move("-", WAREA_AUXILIAR.W_DATA_SQL1.W_BARRA1_1);
                _.Move("-", WAREA_AUXILIAR.W_DATA_SQL1.W_BARRA2_1);


                /*" -3497- MOVE W-DATA-SQL TO DATA-EXPEDICAO OF DCLPESSOA-FISICA */
                _.Move(WAREA_AUXILIAR.W_DATA_SQL, PESFIS.DCLPESSOA_FISICA.DATA_EXPEDICAO);

                /*" -3498- ELSE */
            }
            else
            {


                /*" -3500- MOVE -1 TO VIND-DTEXPEDI. */
                _.Move(-1, VIND_DTEXPEDI);
            }


            /*" -3503- MOVE R1-COD-CBO OF REG-CLIENTES TO COD-CBO OF DCLPESSOA-FISICA. */
            _.Move(LBFPF011.REG_CLIENTES.R1_COD_CBO, PESFIS.DCLPESSOA_FISICA.COD_CBO);

            /*" -3508- MOVE 'PF0619B' TO COD-USUARIO OF DCLPESSOA-FISICA. */
            _.Move("PF0619B", PESFIS.DCLPESSOA_FISICA.COD_USUARIO);

            /*" -3509- ACCEPT WS-HORA-INI FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_INI);

            /*" -3512- COMPUTE SIT = (HI * 60 * 60) + (MI * 60) + SI + (DI / 100) */
            WS_HORAS.SIT.Value = (WS_HORAS.WS_HORA_INI_R.HI * 60 * 60) + (WS_HORAS.WS_HORA_INI_R.MI * 60) + WS_HORAS.WS_HORA_INI_R.SI + (WS_HORAS.WS_HORA_INI_R.DI / 100f);

            /*" -3527- PERFORM R3125_INCLUIR_PESSOA_FISICA_DB_INSERT_1 */

            R3125_INCLUIR_PESSOA_FISICA_DB_INSERT_1();

            /*" -3531- ACCEPT WS-HORA-FIM FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_FIM);

            /*" -3532- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF + (DF / 100) */
            WS_HORAS.SFT.Value = (WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (WS_HORAS.WS_HORA_FIM_R.MF * 60) + WS_HORAS.WS_HORA_FIM_R.SF + (WS_HORAS.WS_HORA_FIM_R.DF / 100f);

            /*" -3533- SUBTRACT SIT FROM SFT */
            WS_HORAS.SFT.Value = WS_HORAS.SFT - WS_HORAS.SIT;

            /*" -3534- ADD SFT TO STT(28) */
            TOTAIS_ROT.FILLER_20[28].STT.Value = TOTAIS_ROT.FILLER_20[28].STT + WS_HORAS.SFT;

            /*" -3537- ADD 1 TO SQT(28) */
            TOTAIS_ROT.FILLER_20[28].SQT.Value = TOTAIS_ROT.FILLER_20[28].SQT + 1;

            /*" -3539- IF SQLCODE NOT EQUAL 00 AND SQLCODE NOT EQUAL -530 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != -530)
            {

                /*" -3540- DISPLAY 'PF0619B - FIM ANORMAL' */
                _.Display($"PF0619B - FIM ANORMAL");

                /*" -3541- DISPLAY '          ERRO INSERT DA TABELA PESSOA FISICA 1' */
                _.Display($"          ERRO INSERT DA TABELA PESSOA FISICA 1");

                /*" -3543- DISPLAY '          CODIGO PESSOA.................  ' COD-PESSOA OF DCLPESSOA-FISICA */
                _.Display($"          CODIGO PESSOA.................  {PESFIS.DCLPESSOA_FISICA.COD_PESSOA}");

                /*" -3545- DISPLAY '          NUMERO PROPOSTA...............  ' R1-NUM-PROPOSTA OF REG-CLIENTES */
                _.Display($"          NUMERO PROPOSTA...............  {LBFPF011.REG_CLIENTES.R1_NUM_PROPOSTA}");

                /*" -3547- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -3548- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -3549- PERFORM R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION();

                /*" -3550- ELSE */
            }
            else
            {


                /*" -3551- IF SQLCODE EQUAL -530 */

                if (DB.SQLCODE == -530)
                {

                    /*" -3553- MOVE ZEROS TO COD-CBO OF DCLPESSOA-FISICA */
                    _.Move(0, PESFIS.DCLPESSOA_FISICA.COD_CBO);

                    /*" -3568- PERFORM R3125_INCLUIR_PESSOA_FISICA_DB_INSERT_2 */

                    R3125_INCLUIR_PESSOA_FISICA_DB_INSERT_2();

                    /*" -3570- IF SQLCODE NOT EQUAL 00 */

                    if (DB.SQLCODE != 00)
                    {

                        /*" -3571- DISPLAY 'PF0619B - FIM ANORMAL' */
                        _.Display($"PF0619B - FIM ANORMAL");

                        /*" -3572- DISPLAY '          ERRO INSERT DA TABELA PESSOA FISICA 2' */
                        _.Display($"          ERRO INSERT DA TABELA PESSOA FISICA 2");

                        /*" -3574- DISPLAY '          CODIGO PESSOA.................  ' COD-PESSOA OF DCLPESSOA-FISICA */
                        _.Display($"          CODIGO PESSOA.................  {PESFIS.DCLPESSOA_FISICA.COD_PESSOA}");

                        /*" -3576- DISPLAY '          NUMERO PROPOSTA...............  ' R1-NUM-PROPOSTA OF REG-CLIENTES */
                        _.Display($"          NUMERO PROPOSTA...............  {LBFPF011.REG_CLIENTES.R1_NUM_PROPOSTA}");

                        /*" -3578- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                        _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                        /*" -3579- PERFORM R9988-00-FECHAR-ARQUIVOS */

                        R9988_00_FECHAR_ARQUIVOS_SECTION();

                        /*" -3579- PERFORM R9999-00-FINALIZAR. */

                        R9999_00_FINALIZAR_SECTION();
                    }

                }

            }


        }

        [StopWatch]
        /*" R3125-INCLUIR-PESSOA-FISICA-DB-INSERT-1 */
        public void R3125_INCLUIR_PESSOA_FISICA_DB_INSERT_1()
        {
            /*" -3527- EXEC SQL INSERT INTO SEGUROS.PESSOA_FISICA VALUES (:DCLPESSOA-FISICA.COD-PESSOA, :DCLPESSOA-FISICA.CPF, :DCLPESSOA-FISICA.DATA-NASCIMENTO, :DCLPESSOA-FISICA.SEXO, :DCLPESSOA-FISICA.COD-USUARIO, :DCLPESSOA-FISICA.ESTADO-CIVIL, CURRENT TIMESTAMP, :DCLPESSOA-FISICA.NUM-IDENTIDADE, :DCLPESSOA-FISICA.ORGAO-EXPEDIDOR, :DCLPESSOA-FISICA.UF-EXPEDIDORA, :DCLPESSOA-FISICA.DATA-EXPEDICAO:VIND-DTEXPEDI, :DCLPESSOA-FISICA.COD-CBO, :DCLPESSOA-FISICA.TIPO-IDENT-SIVPF) END-EXEC. */

            var r3125_INCLUIR_PESSOA_FISICA_DB_INSERT_1_Insert1 = new R3125_INCLUIR_PESSOA_FISICA_DB_INSERT_1_Insert1()
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

            R3125_INCLUIR_PESSOA_FISICA_DB_INSERT_1_Insert1.Execute(r3125_INCLUIR_PESSOA_FISICA_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3125_SAIDA*/

        [StopWatch]
        /*" R3125-INCLUIR-PESSOA-FISICA-DB-INSERT-2 */
        public void R3125_INCLUIR_PESSOA_FISICA_DB_INSERT_2()
        {
            /*" -3568- EXEC SQL INSERT INTO SEGUROS.PESSOA_FISICA VALUES (:DCLPESSOA-FISICA.COD-PESSOA, :DCLPESSOA-FISICA.CPF, :DCLPESSOA-FISICA.DATA-NASCIMENTO, :DCLPESSOA-FISICA.SEXO, :DCLPESSOA-FISICA.COD-USUARIO, :DCLPESSOA-FISICA.ESTADO-CIVIL, CURRENT TIMESTAMP, :DCLPESSOA-FISICA.NUM-IDENTIDADE, :DCLPESSOA-FISICA.ORGAO-EXPEDIDOR, :DCLPESSOA-FISICA.UF-EXPEDIDORA, :DCLPESSOA-FISICA.DATA-EXPEDICAO:VIND-DTEXPEDI, :DCLPESSOA-FISICA.COD-CBO, :DCLPESSOA-FISICA.TIPO-IDENT-SIVPF) END-EXEC */

            var r3125_INCLUIR_PESSOA_FISICA_DB_INSERT_2_Insert1 = new R3125_INCLUIR_PESSOA_FISICA_DB_INSERT_2_Insert1()
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

            R3125_INCLUIR_PESSOA_FISICA_DB_INSERT_2_Insert1.Execute(r3125_INCLUIR_PESSOA_FISICA_DB_INSERT_2_Insert1);

        }

        [StopWatch]
        /*" R3130-INCLUIR-PESSOA-JURIDICA-SECTION */
        private void R3130_INCLUIR_PESSOA_JURIDICA_SECTION()
        {
            /*" -3588- MOVE 'R3130-INCLUIR-PESSOAS-JURIDICA' TO PARAGRAFO. */
            _.Move("R3130-INCLUIR-PESSOAS-JURIDICA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3590- MOVE 'INSERT PESSOA-JURIDICA' TO COMANDO. */
            _.Move("INSERT PESSOA-JURIDICA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3593- MOVE PESSOA-COD-PESSOA OF DCLPESSOA TO COD-PESSOA OF DCLPESSOA-JURIDICA */
            _.Move(PESSOA.DCLPESSOA.PESSOA_COD_PESSOA, PESJUR.DCLPESSOA_JURIDICA.COD_PESSOA);

            /*" -3596- MOVE R1-CGC-CPF OF REG-CLIENTES TO CGC OF DCLPESSOA-JURIDICA */
            _.Move(LBFPF011.REG_CLIENTES.R1_CGC_CPF, PESJUR.DCLPESSOA_JURIDICA.CGC);

            /*" -3599- MOVE R1-NOME-PESSOA OF REG-CLIENTES TO NOME-FANTASIA OF DCLPESSOA-JURIDICA */
            _.Move(LBFPF011.REG_CLIENTES.R1_NOME_PESSOA, PESJUR.DCLPESSOA_JURIDICA.NOME_FANTASIA);

            /*" -3604- MOVE 'PF0619B' TO COD-USUARIO OF DCLPESSOA-JURIDICA */
            _.Move("PF0619B", PESJUR.DCLPESSOA_JURIDICA.COD_USUARIO);

            /*" -3605- ACCEPT WS-HORA-INI FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_INI);

            /*" -3608- COMPUTE SIT = (HI * 60 * 60) + (MI * 60) + SI + (DI / 100) */
            WS_HORAS.SIT.Value = (WS_HORAS.WS_HORA_INI_R.HI * 60 * 60) + (WS_HORAS.WS_HORA_INI_R.MI * 60) + WS_HORAS.WS_HORA_INI_R.SI + (WS_HORAS.WS_HORA_INI_R.DI / 100f);

            /*" -3615- PERFORM R3130_INCLUIR_PESSOA_JURIDICA_DB_INSERT_1 */

            R3130_INCLUIR_PESSOA_JURIDICA_DB_INSERT_1();

            /*" -3619- ACCEPT WS-HORA-FIM FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_FIM);

            /*" -3620- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF + (DF / 100) */
            WS_HORAS.SFT.Value = (WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (WS_HORAS.WS_HORA_FIM_R.MF * 60) + WS_HORAS.WS_HORA_FIM_R.SF + (WS_HORAS.WS_HORA_FIM_R.DF / 100f);

            /*" -3621- SUBTRACT SIT FROM SFT */
            WS_HORAS.SFT.Value = WS_HORAS.SFT - WS_HORAS.SIT;

            /*" -3622- ADD SFT TO STT(29) */
            TOTAIS_ROT.FILLER_20[29].STT.Value = TOTAIS_ROT.FILLER_20[29].STT + WS_HORAS.SFT;

            /*" -3625- ADD 1 TO SQT(29) */
            TOTAIS_ROT.FILLER_20[29].SQT.Value = TOTAIS_ROT.FILLER_20[29].SQT + 1;

            /*" -3626- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -3627- DISPLAY 'PF0619B - FIM ANORMAL' */
                _.Display($"PF0619B - FIM ANORMAL");

                /*" -3628- DISPLAY '          ERRO INSERT DA TABELA PESSOA JURIDICA' */
                _.Display($"          ERRO INSERT DA TABELA PESSOA JURIDICA");

                /*" -3630- DISPLAY '          CODIGO PESSOA.................  ' COD-PESSOA OF DCLPESSOA-JURIDICA */
                _.Display($"          CODIGO PESSOA.................  {PESJUR.DCLPESSOA_JURIDICA.COD_PESSOA}");

                /*" -3632- DISPLAY '          NUMERO PROPOSTA...............  ' R1-NUM-PROPOSTA OF REG-CLIENTES */
                _.Display($"          NUMERO PROPOSTA...............  {LBFPF011.REG_CLIENTES.R1_NUM_PROPOSTA}");

                /*" -3634- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -3635- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -3635- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R3130-INCLUIR-PESSOA-JURIDICA-DB-INSERT-1 */
        public void R3130_INCLUIR_PESSOA_JURIDICA_DB_INSERT_1()
        {
            /*" -3615- EXEC SQL INSERT INTO SEGUROS.PESSOA_JURIDICA VALUES (:DCLPESSOA-JURIDICA.COD-PESSOA, :DCLPESSOA-JURIDICA.CGC, :DCLPESSOA-JURIDICA.NOME-FANTASIA, :DCLPESSOA-JURIDICA.COD-USUARIO, CURRENT TIMESTAMP) END-EXEC. */

            var r3130_INCLUIR_PESSOA_JURIDICA_DB_INSERT_1_Insert1 = new R3130_INCLUIR_PESSOA_JURIDICA_DB_INSERT_1_Insert1()
            {
                COD_PESSOA = PESJUR.DCLPESSOA_JURIDICA.COD_PESSOA.ToString(),
                CGC = PESJUR.DCLPESSOA_JURIDICA.CGC.ToString(),
                NOME_FANTASIA = PESJUR.DCLPESSOA_JURIDICA.NOME_FANTASIA.ToString(),
                COD_USUARIO = PESJUR.DCLPESSOA_JURIDICA.COD_USUARIO.ToString(),
            };

            R3130_INCLUIR_PESSOA_JURIDICA_DB_INSERT_1_Insert1.Execute(r3130_INCLUIR_PESSOA_JURIDICA_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3130_SAIDA*/

        [StopWatch]
        /*" R3136-RELACIONA-EMAIL-SECTION */
        private void R3136_RELACIONA_EMAIL_SECTION()
        {
            /*" -3645- MOVE 'R3136-RELACIONA-EMAIL' TO PARAGRAFO. */
            _.Move("R3136-RELACIONA-EMAIL", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3647- MOVE 'DECLARE PESSOA-EMAIL' TO COMANDO. */
            _.Move("DECLARE PESSOA-EMAIL", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3651- MOVE PESSOA-COD-PESSOA OF DCLPESSOA TO COD-PESSOA OF DCLPESSOA-EMAIL. */
            _.Move(PESSOA.DCLPESSOA.PESSOA_COD_PESSOA, PESEMAIL.DCLPESSOA_EMAIL.COD_PESSOA);

            /*" -3652- ACCEPT WS-HORA-INI FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_INI);

            /*" -3655- COMPUTE SIT = (HI * 60 * 60) + (MI * 60) + SI + (DI / 100) */
            WS_HORAS.SIT.Value = (WS_HORAS.WS_HORA_INI_R.HI * 60 * 60) + (WS_HORAS.WS_HORA_INI_R.MI * 60) + WS_HORAS.WS_HORA_INI_R.SI + (WS_HORAS.WS_HORA_INI_R.DI / 100f);

            /*" -3665- PERFORM R3136_RELACIONA_EMAIL_DB_DECLARE_1 */

            R3136_RELACIONA_EMAIL_DB_DECLARE_1();

            /*" -3669- ACCEPT WS-HORA-FIM FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_FIM);

            /*" -3670- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF + (DF / 100) */
            WS_HORAS.SFT.Value = (WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (WS_HORAS.WS_HORA_FIM_R.MF * 60) + WS_HORAS.WS_HORA_FIM_R.SF + (WS_HORAS.WS_HORA_FIM_R.DF / 100f);

            /*" -3671- SUBTRACT SIT FROM SFT */
            WS_HORAS.SFT.Value = WS_HORAS.SFT - WS_HORAS.SIT;

            /*" -3672- ADD SFT TO STT(30) */
            TOTAIS_ROT.FILLER_20[30].STT.Value = TOTAIS_ROT.FILLER_20[30].STT + WS_HORAS.SFT;

            /*" -3675- ADD 1 TO SQT(30) */
            TOTAIS_ROT.FILLER_20[30].SQT.Value = TOTAIS_ROT.FILLER_20[30].SQT + 1;

            /*" -3677- IF SQLCODE NOT EQUAL 00 AND SQLCODE NOT EQUAL 100 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != 100)
            {

                /*" -3678- DISPLAY 'PF0619B - FIM ANORMAL' */
                _.Display($"PF0619B - FIM ANORMAL");

                /*" -3679- DISPLAY '          ERRO DECLARE DA TABELA PESSOA EMAIL' */
                _.Display($"          ERRO DECLARE DA TABELA PESSOA EMAIL");

                /*" -3681- DISPLAY '          CODIGO PESSOA.................  ' COD-PESSOA OF DCLPESSOA-EMAIL */
                _.Display($"          CODIGO PESSOA.................  {PESEMAIL.DCLPESSOA_EMAIL.COD_PESSOA}");

                /*" -3683- DISPLAY '          NUMERO PROPOSTA...............  ' R1-NUM-PROPOSTA OF REG-CLIENTES */
                _.Display($"          NUMERO PROPOSTA...............  {LBFPF011.REG_CLIENTES.R1_NUM_PROPOSTA}");

                /*" -3685- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -3686- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -3686- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3136_SAIDA*/

        [StopWatch]
        /*" R3135-INCLUIR-END-EMAIL-SECTION */
        private void R3135_INCLUIR_END_EMAIL_SECTION()
        {
            /*" -3695- MOVE 'R3135-INCLUIR-END-EMAIL' TO PARAGRAFO. */
            _.Move("R3135-INCLUIR-END-EMAIL", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3697- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3699- PERFORM R3136-RELACIONA-EMAIL. */

            R3136_RELACIONA_EMAIL_SECTION();

            /*" -3701- MOVE 'OPEN CURSOR EMAIL' TO COMANDO. */
            _.Move("OPEN CURSOR EMAIL", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3701- PERFORM R3135_INCLUIR_END_EMAIL_DB_OPEN_1 */

            R3135_INCLUIR_END_EMAIL_DB_OPEN_1();

            /*" -3705- MOVE 'NAO' TO W-ACHOU-EMAIL. */
            _.Move("NAO", WAREA_AUXILIAR.W_ACHOU_EMAIL);

            /*" -3707- MOVE SPACES TO W-FIM-CURSOR-EMAIL. */
            _.Move("", WAREA_AUXILIAR.W_FIM_CURSOR_EMAIL);

            /*" -3709- PERFORM R3137-FETCH-EMAIL */

            R3137_FETCH_EMAIL_SECTION();

            /*" -3710- IF W-FIM-CURSOR-EMAIL EQUAL 'SIM' */

            if (WAREA_AUXILIAR.W_FIM_CURSOR_EMAIL == "SIM")
            {

                /*" -3711- IF R1-EMAIL OF REG-CLIENTES EQUAL SPACES */

                if (LBFPF011.REG_CLIENTES.R1_EMAIL.IsEmpty())
                {

                    /*" -3713- MOVE 'SIM' TO W-ACHOU-EMAIL. */
                    _.Move("SIM", WAREA_AUXILIAR.W_ACHOU_EMAIL);
                }

            }


            /*" -3716- PERFORM R3138-VERIFICA-EXISTE-EMAIL UNTIL W-FIM-CURSOR-EMAIL EQUAL 'SIM' . */

            while (!(WAREA_AUXILIAR.W_FIM_CURSOR_EMAIL == "SIM"))
            {

                R3138_VERIFICA_EXISTE_EMAIL_SECTION();
            }

            /*" -3717- IF W-ACHOU-EMAIL EQUAL 'NAO' */

            if (WAREA_AUXILIAR.W_ACHOU_EMAIL == "NAO")
            {

                /*" -3717- PERFORM R3139-INCLUIR-NOVO-EMAIL. */

                R3139_INCLUIR_NOVO_EMAIL_SECTION();
            }


        }

        [StopWatch]
        /*" R3135-INCLUIR-END-EMAIL-DB-OPEN-1 */
        public void R3135_INCLUIR_END_EMAIL_DB_OPEN_1()
        {
            /*" -3701- EXEC SQL OPEN EMAIL END-EXEC. */

            EMAIL.Open();

        }

        [StopWatch]
        /*" R3205-RELACIONA-ENDERECO-DB-DECLARE-1 */
        public void R3205_RELACIONA_ENDERECO_DB_DECLARE_1()
        {
            /*" -4195- EXEC SQL DECLARE ENDERECOS CURSOR FOR SELECT OCORR_ENDERECO, COD_PESSOA, ENDERECO, TIPO_ENDER, BAIRRO, CEP, CIDADE, SIGLA_UF, SITUACAO_ENDERECO FROM SEGUROS.PESSOA_ENDERECO WHERE COD_PESSOA = :DCLPESSOA-ENDERECO.COD-PESSOA ORDER BY OCORR_ENDERECO WITH UR END-EXEC. */
            ENDERECOS = new PF0619B_ENDERECOS(true);
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
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3135_SAIDA*/

        [StopWatch]
        /*" R3137-FETCH-EMAIL-SECTION */
        private void R3137_FETCH_EMAIL_SECTION()
        {
            /*" -3727- MOVE 'R3137-FETCH-EMAIL' TO PARAGRAFO. */
            _.Move("R3137-FETCH-EMAIL", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3730- MOVE 'FETCH CURSOR EMAIL' TO COMANDO. */
            _.Move("FETCH CURSOR EMAIL", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3731- ACCEPT WS-HORA-INI FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_INI);

            /*" -3734- COMPUTE SIT = (HI * 60 * 60) + (MI * 60) + SI + (DI / 100) */
            WS_HORAS.SIT.Value = (WS_HORAS.WS_HORA_INI_R.HI * 60 * 60) + (WS_HORAS.WS_HORA_INI_R.MI * 60) + WS_HORAS.WS_HORA_INI_R.SI + (WS_HORAS.WS_HORA_INI_R.DI / 100f);

            /*" -3740- PERFORM R3137_FETCH_EMAIL_DB_FETCH_1 */

            R3137_FETCH_EMAIL_DB_FETCH_1();

            /*" -3744- ACCEPT WS-HORA-FIM FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_FIM);

            /*" -3745- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF + (DF / 100) */
            WS_HORAS.SFT.Value = (WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (WS_HORAS.WS_HORA_FIM_R.MF * 60) + WS_HORAS.WS_HORA_FIM_R.SF + (WS_HORAS.WS_HORA_FIM_R.DF / 100f);

            /*" -3746- SUBTRACT SIT FROM SFT */
            WS_HORAS.SFT.Value = WS_HORAS.SFT - WS_HORAS.SIT;

            /*" -3747- ADD SFT TO STT(31) */
            TOTAIS_ROT.FILLER_20[31].STT.Value = TOTAIS_ROT.FILLER_20[31].STT + WS_HORAS.SFT;

            /*" -3750- ADD 1 TO SQT(31) */
            TOTAIS_ROT.FILLER_20[31].SQT.Value = TOTAIS_ROT.FILLER_20[31].SQT + 1;

            /*" -3751- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -3752- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -3753- MOVE 'SIM' TO W-FIM-CURSOR-EMAIL */
                    _.Move("SIM", WAREA_AUXILIAR.W_FIM_CURSOR_EMAIL);

                    /*" -3753- PERFORM R3137_FETCH_EMAIL_DB_CLOSE_1 */

                    R3137_FETCH_EMAIL_DB_CLOSE_1();

                    /*" -3755- ELSE */
                }
                else
                {


                    /*" -3756- DISPLAY 'PF0619B - FIM ANORMAL' */
                    _.Display($"PF0619B - FIM ANORMAL");

                    /*" -3757- DISPLAY '          ERRO FETCH CURSOR EMAIL' */
                    _.Display($"          ERRO FETCH CURSOR EMAIL");

                    /*" -3759- DISPLAY '          CODIGO PESSOA.................  ' COD-PESSOA OF DCLPESSOA-EMAIL */
                    _.Display($"          CODIGO PESSOA.................  {PESEMAIL.DCLPESSOA_EMAIL.COD_PESSOA}");

                    /*" -3761- DISPLAY '          NUMERO PROPOSTA...............  ' R1-NUM-PROPOSTA OF REG-CLIENTES */
                    _.Display($"          NUMERO PROPOSTA...............  {LBFPF011.REG_CLIENTES.R1_NUM_PROPOSTA}");

                    /*" -3763- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                    _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                    /*" -3764- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -3764- PERFORM R9999-00-FINALIZAR. */

                    R9999_00_FINALIZAR_SECTION();
                }

            }


        }

        [StopWatch]
        /*" R3137-FETCH-EMAIL-DB-FETCH-1 */
        public void R3137_FETCH_EMAIL_DB_FETCH_1()
        {
            /*" -3740- EXEC SQL FETCH EMAIL INTO :DCLPESSOA-EMAIL.COD-PESSOA, :DCLPESSOA-EMAIL.SEQ-EMAIL, :DCLPESSOA-EMAIL.EMAIL, :DCLPESSOA-EMAIL.SITUACAO-EMAIL END-EXEC. */

            if (EMAIL.Fetch())
            {
                _.Move(EMAIL.DCLPESSOA_EMAIL_COD_PESSOA, PESEMAIL.DCLPESSOA_EMAIL.COD_PESSOA);
                _.Move(EMAIL.DCLPESSOA_EMAIL_SEQ_EMAIL, PESEMAIL.DCLPESSOA_EMAIL.SEQ_EMAIL);
                _.Move(EMAIL.DCLPESSOA_EMAIL_EMAIL, PESEMAIL.DCLPESSOA_EMAIL.EMAIL);
                _.Move(EMAIL.DCLPESSOA_EMAIL_SITUACAO_EMAIL, PESEMAIL.DCLPESSOA_EMAIL.SITUACAO_EMAIL);
            }

        }

        [StopWatch]
        /*" R3137-FETCH-EMAIL-DB-CLOSE-1 */
        public void R3137_FETCH_EMAIL_DB_CLOSE_1()
        {
            /*" -3753- EXEC SQL CLOSE EMAIL END-EXEC */

            EMAIL.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3137_SAIDA*/

        [StopWatch]
        /*" R3138-VERIFICA-EXISTE-EMAIL-SECTION */
        private void R3138_VERIFICA_EXISTE_EMAIL_SECTION()
        {
            /*" -3774- MOVE 'R3138-VERIFICA-EXISTE-EMAIL' TO PARAGRAFO. */
            _.Move("R3138-VERIFICA-EXISTE-EMAIL", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3776- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3778- IF R1-EMAIL OF REG-CLIENTES EQUAL EMAIL OF DCLPESSOA-EMAIL */

            if (LBFPF011.REG_CLIENTES.R1_EMAIL == PESEMAIL.DCLPESSOA_EMAIL.EMAIL)
            {

                /*" -3780- MOVE 'SIM' TO W-ACHOU-EMAIL. */
                _.Move("SIM", WAREA_AUXILIAR.W_ACHOU_EMAIL);
            }


            /*" -3781- IF R1-EMAIL OF REG-CLIENTES EQUAL SPACES */

            if (LBFPF011.REG_CLIENTES.R1_EMAIL.IsEmpty())
            {

                /*" -3783- MOVE 'SIM' TO W-ACHOU-EMAIL. */
                _.Move("SIM", WAREA_AUXILIAR.W_ACHOU_EMAIL);
            }


            /*" -3783- PERFORM R3137-FETCH-EMAIL. */

            R3137_FETCH_EMAIL_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3138_SAIDA*/

        [StopWatch]
        /*" R3139-INCLUIR-NOVO-EMAIL-SECTION */
        private void R3139_INCLUIR_NOVO_EMAIL_SECTION()
        {
            /*" -3793- MOVE 'R3139-INCLUIR-NOVO-EMAIL' TO PARAGRAFO. */
            _.Move("R3139-INCLUIR-NOVO-EMAIL", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3802- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3805- MOVE SEQ-EMAIL OF DCLPESSOA-EMAIL TO W-SEQ-EMAIL */
            _.Move(PESEMAIL.DCLPESSOA_EMAIL.SEQ_EMAIL, WAREA_AUXILIAR.W_SEQ_EMAIL);

            /*" -3807- COMPUTE W-SEQ-EMAIL = W-SEQ-EMAIL + 1. */
            WAREA_AUXILIAR.W_SEQ_EMAIL.Value = WAREA_AUXILIAR.W_SEQ_EMAIL + 1;

            /*" -3807- PERFORM R3141-INCLUIR-EMAIL. */

            R3141_INCLUIR_EMAIL_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3139_SAIDA*/

        [StopWatch]
        /*" R3140-OBTER-MAX-EMAIL-SECTION */
        private void R3140_OBTER_MAX_EMAIL_SECTION()
        {
            /*" -3817- MOVE 'R3140-OBTER-MAX-EMAIL' TO PARAGRAFO. */
            _.Move("R3140-OBTER-MAX-EMAIL", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3819- MOVE 'MAX SEGUROS.PESSOA_EMAIL' TO COMANDO. */
            _.Move("MAX SEGUROS.PESSOA_EMAIL", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3823- MOVE PESSOA-COD-PESSOA OF DCLPESSOA TO COD-PESSOA OF DCLPESSOA-EMAIL. */
            _.Move(PESSOA.DCLPESSOA.PESSOA_COD_PESSOA, PESEMAIL.DCLPESSOA_EMAIL.COD_PESSOA);

            /*" -3824- ACCEPT WS-HORA-INI FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_INI);

            /*" -3827- COMPUTE SIT = (HI * 60 * 60) + (MI * 60) + SI + (DI / 100) */
            WS_HORAS.SIT.Value = (WS_HORAS.WS_HORA_INI_R.HI * 60 * 60) + (WS_HORAS.WS_HORA_INI_R.MI * 60) + WS_HORAS.WS_HORA_INI_R.SI + (WS_HORAS.WS_HORA_INI_R.DI / 100f);

            /*" -3833- PERFORM R3140_OBTER_MAX_EMAIL_DB_SELECT_1 */

            R3140_OBTER_MAX_EMAIL_DB_SELECT_1();

            /*" -3837- ACCEPT WS-HORA-FIM FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_FIM);

            /*" -3838- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF + (DF / 100) */
            WS_HORAS.SFT.Value = (WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (WS_HORAS.WS_HORA_FIM_R.MF * 60) + WS_HORAS.WS_HORA_FIM_R.SF + (WS_HORAS.WS_HORA_FIM_R.DF / 100f);

            /*" -3839- SUBTRACT SIT FROM SFT */
            WS_HORAS.SFT.Value = WS_HORAS.SFT - WS_HORAS.SIT;

            /*" -3840- ADD SFT TO STT(32) */
            TOTAIS_ROT.FILLER_20[32].STT.Value = TOTAIS_ROT.FILLER_20[32].STT + WS_HORAS.SFT;

            /*" -3843- ADD 1 TO SQT(32) */
            TOTAIS_ROT.FILLER_20[32].SQT.Value = TOTAIS_ROT.FILLER_20[32].SQT + 1;

            /*" -3844- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -3845- DISPLAY 'PF0619B - FIM ANORMAL' */
                _.Display($"PF0619B - FIM ANORMAL");

                /*" -3846- DISPLAY '          ERRO NO SELECT MAX TAB. PESSOA-EMAIL' */
                _.Display($"          ERRO NO SELECT MAX TAB. PESSOA-EMAIL");

                /*" -3848- DISPLAY '          NUMERO DA PROPOSTA............  ' R1-NUM-PROPOSTA OF REG-CLIENTES */
                _.Display($"          NUMERO DA PROPOSTA............  {LBFPF011.REG_CLIENTES.R1_NUM_PROPOSTA}");

                /*" -3850- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -3851- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -3851- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R3140-OBTER-MAX-EMAIL-DB-SELECT-1 */
        public void R3140_OBTER_MAX_EMAIL_DB_SELECT_1()
        {
            /*" -3833- EXEC SQL SELECT VALUE(MAX(SEQ_EMAIL),0) INTO :DCLPESSOA-EMAIL.SEQ-EMAIL FROM SEGUROS.PESSOA_EMAIL WHERE COD_PESSOA = :DCLPESSOA-EMAIL.COD-PESSOA WITH UR END-EXEC. */

            var r3140_OBTER_MAX_EMAIL_DB_SELECT_1_Query1 = new R3140_OBTER_MAX_EMAIL_DB_SELECT_1_Query1()
            {
                COD_PESSOA = PESEMAIL.DCLPESSOA_EMAIL.COD_PESSOA.ToString(),
            };

            var executed_1 = R3140_OBTER_MAX_EMAIL_DB_SELECT_1_Query1.Execute(r3140_OBTER_MAX_EMAIL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SEQ_EMAIL, PESEMAIL.DCLPESSOA_EMAIL.SEQ_EMAIL);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3140_SAIDA*/

        [StopWatch]
        /*" R3141-INCLUIR-EMAIL-SECTION */
        private void R3141_INCLUIR_EMAIL_SECTION()
        {
            /*" -3860- MOVE 'R3141-INCLUI-EMAIL' TO PARAGRAFO. */
            _.Move("R3141-INCLUI-EMAIL", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3862- MOVE 'MAX SEGUROS.PESSOA_EMAIL' TO COMANDO. */
            _.Move("MAX SEGUROS.PESSOA_EMAIL", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3865- MOVE PESSOA-COD-PESSOA OF DCLPESSOA TO COD-PESSOA OF DCLPESSOA-EMAIL */
            _.Move(PESSOA.DCLPESSOA.PESSOA_COD_PESSOA, PESEMAIL.DCLPESSOA_EMAIL.COD_PESSOA);

            /*" -3868- MOVE W-SEQ-EMAIL TO SEQ-EMAIL OF DCLPESSOA-EMAIL. */
            _.Move(WAREA_AUXILIAR.W_SEQ_EMAIL, PESEMAIL.DCLPESSOA_EMAIL.SEQ_EMAIL);

            /*" -3871- MOVE R1-EMAIL OF REG-CLIENTES TO EMAIL OF DCLPESSOA-EMAIL */
            _.Move(LBFPF011.REG_CLIENTES.R1_EMAIL, PESEMAIL.DCLPESSOA_EMAIL.EMAIL);

            /*" -3874- MOVE 'A' TO SITUACAO-EMAIL OF DCLPESSOA-EMAIL */
            _.Move("A", PESEMAIL.DCLPESSOA_EMAIL.SITUACAO_EMAIL);

            /*" -3879- MOVE 'PF0619B' TO COD-USUARIO OF DCLPESSOA-EMAIL. */
            _.Move("PF0619B", PESEMAIL.DCLPESSOA_EMAIL.COD_USUARIO);

            /*" -3880- ACCEPT WS-HORA-INI FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_INI);

            /*" -3883- COMPUTE SIT = (HI * 60 * 60) + (MI * 60) + SI + (DI / 100) */
            WS_HORAS.SIT.Value = (WS_HORAS.WS_HORA_INI_R.HI * 60 * 60) + (WS_HORAS.WS_HORA_INI_R.MI * 60) + WS_HORAS.WS_HORA_INI_R.SI + (WS_HORAS.WS_HORA_INI_R.DI / 100f);

            /*" -3891- PERFORM R3141_INCLUIR_EMAIL_DB_INSERT_1 */

            R3141_INCLUIR_EMAIL_DB_INSERT_1();

            /*" -3895- ACCEPT WS-HORA-FIM FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_FIM);

            /*" -3896- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF + (DF / 100) */
            WS_HORAS.SFT.Value = (WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (WS_HORAS.WS_HORA_FIM_R.MF * 60) + WS_HORAS.WS_HORA_FIM_R.SF + (WS_HORAS.WS_HORA_FIM_R.DF / 100f);

            /*" -3897- SUBTRACT SIT FROM SFT */
            WS_HORAS.SFT.Value = WS_HORAS.SFT - WS_HORAS.SIT;

            /*" -3898- ADD SFT TO STT(33) */
            TOTAIS_ROT.FILLER_20[33].STT.Value = TOTAIS_ROT.FILLER_20[33].STT + WS_HORAS.SFT;

            /*" -3901- ADD 1 TO SQT(33) */
            TOTAIS_ROT.FILLER_20[33].SQT.Value = TOTAIS_ROT.FILLER_20[33].SQT + 1;

            /*" -3902- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -3903- DISPLAY 'PF0619B - FIM ANORMAL' */
                _.Display($"PF0619B - FIM ANORMAL");

                /*" -3904- DISPLAY '          ERRO INSERT DA TABELA PESSOA-EMAIL' */
                _.Display($"          ERRO INSERT DA TABELA PESSOA-EMAIL");

                /*" -3906- DISPLAY '          CODIGO PESSOA.................  ' PESSOA-COD-PESSOA OF DCLPESSOA */
                _.Display($"          CODIGO PESSOA.................  {PESSOA.DCLPESSOA.PESSOA_COD_PESSOA}");

                /*" -3908- DISPLAY '          NOME DA PESSOA................  ' PESSOA-NOME-PESSOA OF DCLPESSOA */
                _.Display($"          NOME DA PESSOA................  {PESSOA.DCLPESSOA.PESSOA_NOME_PESSOA}");

                /*" -3910- DISPLAY '          NUMERO PROPOSTA...............  ' R1-NUM-PROPOSTA OF REG-CLIENTES */
                _.Display($"          NUMERO PROPOSTA...............  {LBFPF011.REG_CLIENTES.R1_NUM_PROPOSTA}");

                /*" -3912- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -3913- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -3913- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R3141-INCLUIR-EMAIL-DB-INSERT-1 */
        public void R3141_INCLUIR_EMAIL_DB_INSERT_1()
        {
            /*" -3891- EXEC SQL INSERT INTO SEGUROS.PESSOA_EMAIL VALUES (:DCLPESSOA-EMAIL.COD-PESSOA, :DCLPESSOA-EMAIL.SEQ-EMAIL, :DCLPESSOA-EMAIL.EMAIL, :DCLPESSOA-EMAIL.SITUACAO-EMAIL, :DCLPESSOA-EMAIL.COD-USUARIO, CURRENT TIMESTAMP) END-EXEC. */

            var r3141_INCLUIR_EMAIL_DB_INSERT_1_Insert1 = new R3141_INCLUIR_EMAIL_DB_INSERT_1_Insert1()
            {
                COD_PESSOA = PESEMAIL.DCLPESSOA_EMAIL.COD_PESSOA.ToString(),
                SEQ_EMAIL = PESEMAIL.DCLPESSOA_EMAIL.SEQ_EMAIL.ToString(),
                EMAIL = PESEMAIL.DCLPESSOA_EMAIL.EMAIL.ToString(),
                SITUACAO_EMAIL = PESEMAIL.DCLPESSOA_EMAIL.SITUACAO_EMAIL.ToString(),
                COD_USUARIO = PESEMAIL.DCLPESSOA_EMAIL.COD_USUARIO.ToString(),
            };

            R3141_INCLUIR_EMAIL_DB_INSERT_1_Insert1.Execute(r3141_INCLUIR_EMAIL_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3141_SAIDA*/

        [StopWatch]
        /*" R3150-LER-TAB-CORPORATIVAS-SECTION */
        private void R3150_LER_TAB_CORPORATIVAS_SECTION()
        {
            /*" -3923- MOVE 'R3150-LER-TAB-CORPORATIVAS' TO PARAGRAFO. */
            _.Move("R3150-LER-TAB-CORPORATIVAS", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3925- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3926- IF R1-TIPO-PESSOA OF REG-CLIENTES EQUAL 1 */

            if (LBFPF011.REG_CLIENTES.R1_TIPO_PESSOA == 1)
            {

                /*" -3928- MOVE COD-PESSOA OF DCLPESSOA-FISICA TO PESSOA-COD-PESSOA OF DCLPESSOA */
                _.Move(PESFIS.DCLPESSOA_FISICA.COD_PESSOA, PESSOA.DCLPESSOA.PESSOA_COD_PESSOA);

                /*" -3929- ELSE */
            }
            else
            {


                /*" -3932- MOVE COD-PESSOA OF DCLPESSOA-JURIDICA TO PESSOA-COD-PESSOA OF DCLPESSOA. */
                _.Move(PESJUR.DCLPESSOA_JURIDICA.COD_PESSOA, PESSOA.DCLPESSOA.PESSOA_COD_PESSOA);
            }


            /*" -3934- PERFORM R3155-LER-TAB-PESSOA. */

            R3155_LER_TAB_PESSOA_SECTION();

            /*" -3934- PERFORM R3160-LER-TAB-EMAIL. */

            R3160_LER_TAB_EMAIL_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3150_SAIDA*/

        [StopWatch]
        /*" R3155-LER-TAB-PESSOA-SECTION */
        private void R3155_LER_TAB_PESSOA_SECTION()
        {
            /*" -3944- MOVE 'R3150-LER-TAB-PESSOAS' TO PARAGRAFO. */
            _.Move("R3150-LER-TAB-PESSOAS", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3948- MOVE 'SELECT SEGUROS.PESSOAS' TO COMANDO. */
            _.Move("SELECT SEGUROS.PESSOAS", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3949- ACCEPT WS-HORA-INI FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_INI);

            /*" -3952- COMPUTE SIT = (HI * 60 * 60) + (MI * 60) + SI + (DI / 100) */
            WS_HORAS.SIT.Value = (WS_HORAS.WS_HORA_INI_R.HI * 60 * 60) + (WS_HORAS.WS_HORA_INI_R.MI * 60) + WS_HORAS.WS_HORA_INI_R.SI + (WS_HORAS.WS_HORA_INI_R.DI / 100f);

            /*" -3966- PERFORM R3155_LER_TAB_PESSOA_DB_SELECT_1 */

            R3155_LER_TAB_PESSOA_DB_SELECT_1();

            /*" -3970- ACCEPT WS-HORA-FIM FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_FIM);

            /*" -3971- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF + (DF / 100) */
            WS_HORAS.SFT.Value = (WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (WS_HORAS.WS_HORA_FIM_R.MF * 60) + WS_HORAS.WS_HORA_FIM_R.SF + (WS_HORAS.WS_HORA_FIM_R.DF / 100f);

            /*" -3972- SUBTRACT SIT FROM SFT */
            WS_HORAS.SFT.Value = WS_HORAS.SFT - WS_HORAS.SIT;

            /*" -3973- ADD SFT TO STT(34) */
            TOTAIS_ROT.FILLER_20[34].STT.Value = TOTAIS_ROT.FILLER_20[34].STT + WS_HORAS.SFT;

            /*" -3976- ADD 1 TO SQT(34) */
            TOTAIS_ROT.FILLER_20[34].SQT.Value = TOTAIS_ROT.FILLER_20[34].SQT + 1;

            /*" -3977- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -3978- DISPLAY 'PF0619B - FIM ANORMAL' */
                _.Display($"PF0619B - FIM ANORMAL");

                /*" -3979- DISPLAY '          ERRO ACESSO TAB. SEGUROS.PESSOA' */
                _.Display($"          ERRO ACESSO TAB. SEGUROS.PESSOA");

                /*" -3981- DISPLAY '          CODIGO PESSOA.................  ' PESSOA-COD-PESSOA OF DCLPESSOA */
                _.Display($"          CODIGO PESSOA.................  {PESSOA.DCLPESSOA.PESSOA_COD_PESSOA}");

                /*" -3983- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -3984- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -3986- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


            /*" -3988- IF PESSOA-NOME-PESSOA EQUAL SPACES OR PESSOA-NOME-PESSOA EQUAL LOW-VALUES */

            if (PESSOA.DCLPESSOA.PESSOA_NOME_PESSOA.IsEmpty() || PESSOA.DCLPESSOA.PESSOA_NOME_PESSOA.IsLowValues())
            {

                /*" -3989- PERFORM R31551-CORRIGE-PESSOA */

                R31551_CORRIGE_PESSOA_SECTION();

                /*" -3991- END-IF */
            }


            /*" -3991- . */

        }

        [StopWatch]
        /*" R3155-LER-TAB-PESSOA-DB-SELECT-1 */
        public void R3155_LER_TAB_PESSOA_DB_SELECT_1()
        {
            /*" -3966- EXEC SQL SELECT COD_PESSOA, NOME_PESSOA, TIPO_PESSOA, TIMESTAMP, COD_USUARIO INTO :DCLPESSOA.PESSOA-COD-PESSOA, :DCLPESSOA.PESSOA-NOME-PESSOA, :DCLPESSOA.PESSOA-TIPO-PESSOA, :DCLPESSOA.PESSOA-TIMESTAMP, :DCLPESSOA.PESSOA-COD-USUARIO FROM SEGUROS.PESSOA WHERE COD_PESSOA = :DCLPESSOA.PESSOA-COD-PESSOA WITH UR END-EXEC. */

            var r3155_LER_TAB_PESSOA_DB_SELECT_1_Query1 = new R3155_LER_TAB_PESSOA_DB_SELECT_1_Query1()
            {
                PESSOA_COD_PESSOA = PESSOA.DCLPESSOA.PESSOA_COD_PESSOA.ToString(),
            };

            var executed_1 = R3155_LER_TAB_PESSOA_DB_SELECT_1_Query1.Execute(r3155_LER_TAB_PESSOA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PESSOA_COD_PESSOA, PESSOA.DCLPESSOA.PESSOA_COD_PESSOA);
                _.Move(executed_1.PESSOA_NOME_PESSOA, PESSOA.DCLPESSOA.PESSOA_NOME_PESSOA);
                _.Move(executed_1.PESSOA_TIPO_PESSOA, PESSOA.DCLPESSOA.PESSOA_TIPO_PESSOA);
                _.Move(executed_1.PESSOA_TIMESTAMP, PESSOA.DCLPESSOA.PESSOA_TIMESTAMP);
                _.Move(executed_1.PESSOA_COD_USUARIO, PESSOA.DCLPESSOA.PESSOA_COD_USUARIO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3155_SAIDA*/

        [StopWatch]
        /*" R31551-CORRIGE-PESSOA-SECTION */
        private void R31551_CORRIGE_PESSOA_SECTION()
        {
            /*" -4001- MOVE 'R31551-CORRIGE-PESSOA' TO PARAGRAFO. */
            _.Move("R31551-CORRIGE-PESSOA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4002- MOVE 'SELECT SEGUROS.PESSOAS' TO COMANDO. */
            _.Move("SELECT SEGUROS.PESSOAS", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4004- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4007- MOVE R1-NOME-PESSOA OF REG-CLIENTES TO PESSOA-NOME-PESSOA OF DCLPESSOA */
            _.Move(LBFPF011.REG_CLIENTES.R1_NOME_PESSOA, PESSOA.DCLPESSOA.PESSOA_NOME_PESSOA);

            /*" -4011- PERFORM R31551_CORRIGE_PESSOA_DB_UPDATE_1 */

            R31551_CORRIGE_PESSOA_DB_UPDATE_1();

            /*" -4015- IF SQLCODE NOT EQUAL ZEROS OR PESSOA-NOME-PESSOA OF DCLPESSOA EQUAL SPACES */

            if (DB.SQLCODE != 00 || PESSOA.DCLPESSOA.PESSOA_NOME_PESSOA.IsEmpty())
            {

                /*" -4016- DISPLAY 'PF0619B FIM ANORMAL' */
                _.Display($"PF0619B FIM ANORMAL");

                /*" -4017- DISPLAY '        ERRO UPDATE TAB. PESSOA' */
                _.Display($"        ERRO UPDATE TAB. PESSOA");

                /*" -4019- DISPLAY '        CODIGO PESSOA....... ' PESSOA-COD-PESSOA OF DCLPESSOA */
                _.Display($"        CODIGO PESSOA....... {PESSOA.DCLPESSOA.PESSOA_COD_PESSOA}");

                /*" -4021- DISPLAY '        NUMERO DA PROPOSTA.. ' R1-NUM-PROPOSTA OF REG-CLIENTES */
                _.Display($"        NUMERO DA PROPOSTA.. {LBFPF011.REG_CLIENTES.R1_NUM_PROPOSTA}");

                /*" -4022- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -4023- PERFORM R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION();

                /*" -4024- END-IF */
            }


            /*" -4024- . */

        }

        [StopWatch]
        /*" R31551-CORRIGE-PESSOA-DB-UPDATE-1 */
        public void R31551_CORRIGE_PESSOA_DB_UPDATE_1()
        {
            /*" -4011- EXEC SQL UPDATE SEGUROS.PESSOA SET NOME_PESSOA = :DCLPESSOA.PESSOA-NOME-PESSOA WHERE COD_PESSOA = :DCLPESSOA.PESSOA-COD-PESSOA END-EXEC. */

            var r31551_CORRIGE_PESSOA_DB_UPDATE_1_Update1 = new R31551_CORRIGE_PESSOA_DB_UPDATE_1_Update1()
            {
                PESSOA_NOME_PESSOA = PESSOA.DCLPESSOA.PESSOA_NOME_PESSOA.ToString(),
                PESSOA_COD_PESSOA = PESSOA.DCLPESSOA.PESSOA_COD_PESSOA.ToString(),
            };

            R31551_CORRIGE_PESSOA_DB_UPDATE_1_Update1.Execute(r31551_CORRIGE_PESSOA_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R31551_SAIDA*/

        [StopWatch]
        /*" R3160-LER-TAB-EMAIL-SECTION */
        private void R3160_LER_TAB_EMAIL_SECTION()
        {
            /*" -4035- MOVE 'R3160-LER-TAB-EMAIL' TO PARAGRAFO. */
            _.Move("R3160-LER-TAB-EMAIL", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4037- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4039- PERFORM R3165-OBTER-MAX-EMAIL. */

            R3165_OBTER_MAX_EMAIL_SECTION();

            /*" -4039- PERFORM R3170-LER-EMAIL-ATUAL. */

            R3170_LER_EMAIL_ATUAL_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3160_SAIDA*/

        [StopWatch]
        /*" R3165-OBTER-MAX-EMAIL-SECTION */
        private void R3165_OBTER_MAX_EMAIL_SECTION()
        {
            /*" -4049- MOVE 'R3165-OBTER-MAX-EMAIL' TO PARAGRAFO. */
            _.Move("R3165-OBTER-MAX-EMAIL", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4051- MOVE 'MAX SEGUROS.PESSOA_EMAIL' TO COMANDO. */
            _.Move("MAX SEGUROS.PESSOA_EMAIL", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4055- MOVE PESSOA-COD-PESSOA OF DCLPESSOA TO COD-PESSOA OF DCLPESSOA-EMAIL. */
            _.Move(PESSOA.DCLPESSOA.PESSOA_COD_PESSOA, PESEMAIL.DCLPESSOA_EMAIL.COD_PESSOA);

            /*" -4056- ACCEPT WS-HORA-FIM FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_FIM);

            /*" -4057- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF + (DF / 100) */
            WS_HORAS.SFT.Value = (WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (WS_HORAS.WS_HORA_FIM_R.MF * 60) + WS_HORAS.WS_HORA_FIM_R.SF + (WS_HORAS.WS_HORA_FIM_R.DF / 100f);

            /*" -4058- SUBTRACT SIT FROM SFT */
            WS_HORAS.SFT.Value = WS_HORAS.SFT - WS_HORAS.SIT;

            /*" -4059- ADD SFT TO STT(35) */
            TOTAIS_ROT.FILLER_20[35].STT.Value = TOTAIS_ROT.FILLER_20[35].STT + WS_HORAS.SFT;

            /*" -4062- ADD 1 TO SQT(35) */
            TOTAIS_ROT.FILLER_20[35].SQT.Value = TOTAIS_ROT.FILLER_20[35].SQT + 1;

            /*" -4068- PERFORM R3165_OBTER_MAX_EMAIL_DB_SELECT_1 */

            R3165_OBTER_MAX_EMAIL_DB_SELECT_1();

            /*" -4072- ACCEPT WS-HORA-FIM FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_FIM);

            /*" -4073- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF + (DF / 100) */
            WS_HORAS.SFT.Value = (WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (WS_HORAS.WS_HORA_FIM_R.MF * 60) + WS_HORAS.WS_HORA_FIM_R.SF + (WS_HORAS.WS_HORA_FIM_R.DF / 100f);

            /*" -4074- SUBTRACT SIT FROM SFT */
            WS_HORAS.SFT.Value = WS_HORAS.SFT - WS_HORAS.SIT;

            /*" -4075- ADD SFT TO STT(36) */
            TOTAIS_ROT.FILLER_20[36].STT.Value = TOTAIS_ROT.FILLER_20[36].STT + WS_HORAS.SFT;

            /*" -4078- ADD 1 TO SQT(36) */
            TOTAIS_ROT.FILLER_20[36].SQT.Value = TOTAIS_ROT.FILLER_20[36].SQT + 1;

            /*" -4079- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -4080- DISPLAY 'PF0619B - FIM ANORMAL' */
                _.Display($"PF0619B - FIM ANORMAL");

                /*" -4081- DISPLAY '          ERRO SELECT MAX TAB. PESSOA-EMAIL' */
                _.Display($"          ERRO SELECT MAX TAB. PESSOA-EMAIL");

                /*" -4083- DISPLAY '          CODIGO PESSOA.................  ' COD-PESSOA OF DCLPESSOA-EMAIL */
                _.Display($"          CODIGO PESSOA.................  {PESEMAIL.DCLPESSOA_EMAIL.COD_PESSOA}");

                /*" -4085- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -4086- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -4086- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R3165-OBTER-MAX-EMAIL-DB-SELECT-1 */
        public void R3165_OBTER_MAX_EMAIL_DB_SELECT_1()
        {
            /*" -4068- EXEC SQL SELECT VALUE(MAX(SEQ_EMAIL),0) INTO :DCLPESSOA-EMAIL.SEQ-EMAIL FROM SEGUROS.PESSOA_EMAIL WHERE COD_PESSOA = :DCLPESSOA-EMAIL.COD-PESSOA WITH UR END-EXEC. */

            var r3165_OBTER_MAX_EMAIL_DB_SELECT_1_Query1 = new R3165_OBTER_MAX_EMAIL_DB_SELECT_1_Query1()
            {
                COD_PESSOA = PESEMAIL.DCLPESSOA_EMAIL.COD_PESSOA.ToString(),
            };

            var executed_1 = R3165_OBTER_MAX_EMAIL_DB_SELECT_1_Query1.Execute(r3165_OBTER_MAX_EMAIL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SEQ_EMAIL, PESEMAIL.DCLPESSOA_EMAIL.SEQ_EMAIL);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3165_SAIDA*/

        [StopWatch]
        /*" R3170-LER-EMAIL-ATUAL-SECTION */
        private void R3170_LER_EMAIL_ATUAL_SECTION()
        {
            /*" -4096- MOVE 'R3170-LER-EMAIL-ATUAL' TO PARAGRAFO. */
            _.Move("R3170-LER-EMAIL-ATUAL", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4098- MOVE 'SELECT SEGUROS.PESSOA_EMAIL' TO COMANDO. */
            _.Move("SELECT SEGUROS.PESSOA_EMAIL", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4102- MOVE PESSOA-COD-PESSOA OF DCLPESSOA TO COD-PESSOA OF DCLPESSOA-EMAIL. */
            _.Move(PESSOA.DCLPESSOA.PESSOA_COD_PESSOA, PESEMAIL.DCLPESSOA_EMAIL.COD_PESSOA);

            /*" -4103- ACCEPT WS-HORA-INI FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_INI);

            /*" -4106- COMPUTE SIT = (HI * 60 * 60) + (MI * 60) + SI + (DI / 100) */
            WS_HORAS.SIT.Value = (WS_HORAS.WS_HORA_INI_R.HI * 60 * 60) + (WS_HORAS.WS_HORA_INI_R.MI * 60) + WS_HORAS.WS_HORA_INI_R.SI + (WS_HORAS.WS_HORA_INI_R.DI / 100f);

            /*" -4123- PERFORM R3170_LER_EMAIL_ATUAL_DB_SELECT_1 */

            R3170_LER_EMAIL_ATUAL_DB_SELECT_1();

            /*" -4127- ACCEPT WS-HORA-FIM FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_FIM);

            /*" -4128- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF + (DF / 100) */
            WS_HORAS.SFT.Value = (WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (WS_HORAS.WS_HORA_FIM_R.MF * 60) + WS_HORAS.WS_HORA_FIM_R.SF + (WS_HORAS.WS_HORA_FIM_R.DF / 100f);

            /*" -4129- SUBTRACT SIT FROM SFT */
            WS_HORAS.SFT.Value = WS_HORAS.SFT - WS_HORAS.SIT;

            /*" -4130- ADD SFT TO STT(37) */
            TOTAIS_ROT.FILLER_20[37].STT.Value = TOTAIS_ROT.FILLER_20[37].STT + WS_HORAS.SFT;

            /*" -4133- ADD 1 TO SQT(37) */
            TOTAIS_ROT.FILLER_20[37].SQT.Value = TOTAIS_ROT.FILLER_20[37].SQT + 1;

            /*" -4135- IF SQLCODE NOT EQUAL 00 AND SQLCODE NOT EQUAL 100 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != 100)
            {

                /*" -4136- DISPLAY 'PF0619B - FIM ANORMAL' */
                _.Display($"PF0619B - FIM ANORMAL");

                /*" -4137- DISPLAY '          ERRO SELECT TAB. PESSOA-EMAIL' */
                _.Display($"          ERRO SELECT TAB. PESSOA-EMAIL");

                /*" -4139- DISPLAY '          CODIGO PESSOA.................  ' COD-PESSOA OF DCLPESSOA-EMAIL */
                _.Display($"          CODIGO PESSOA.................  {PESEMAIL.DCLPESSOA_EMAIL.COD_PESSOA}");

                /*" -4141- DISPLAY '          SEQUENCIAEMAIL................  ' SEQ-EMAIL OF DCLPESSOA-EMAIL */
                _.Display($"          SEQUENCIAEMAIL................  {PESEMAIL.DCLPESSOA_EMAIL.SEQ_EMAIL}");

                /*" -4143- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -4144- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -4144- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R3170-LER-EMAIL-ATUAL-DB-SELECT-1 */
        public void R3170_LER_EMAIL_ATUAL_DB_SELECT_1()
        {
            /*" -4123- EXEC SQL SELECT COD_PESSOA, SEQ_EMAIL, EMAIL, SITUACAO_EMAIL, COD_USUARIO, TIMESTAMP INTO :DCLPESSOA-EMAIL.COD-PESSOA, :DCLPESSOA-EMAIL.SEQ-EMAIL, :DCLPESSOA-EMAIL.EMAIL, :DCLPESSOA-EMAIL.SITUACAO-EMAIL, :DCLPESSOA-EMAIL.COD-USUARIO, :DCLPESSOA-EMAIL.TIMESTAMP FROM SEGUROS.PESSOA_EMAIL WHERE COD_PESSOA = :DCLPESSOA-EMAIL.COD-PESSOA AND SEQ_EMAIL = :DCLPESSOA-EMAIL.SEQ-EMAIL WITH UR END-EXEC. */

            var r3170_LER_EMAIL_ATUAL_DB_SELECT_1_Query1 = new R3170_LER_EMAIL_ATUAL_DB_SELECT_1_Query1()
            {
                COD_PESSOA = PESEMAIL.DCLPESSOA_EMAIL.COD_PESSOA.ToString(),
                SEQ_EMAIL = PESEMAIL.DCLPESSOA_EMAIL.SEQ_EMAIL.ToString(),
            };

            var executed_1 = R3170_LER_EMAIL_ATUAL_DB_SELECT_1_Query1.Execute(r3170_LER_EMAIL_ATUAL_DB_SELECT_1_Query1);
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
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3170_SAIDA*/

        [StopWatch]
        /*" R3200-TRATA-END-TEL-SECTION */
        private void R3200_TRATA_END_TEL_SECTION()
        {
            /*" -4154- MOVE 'R3200-TRATA-END-TEL' TO PARAGRAFO. */
            _.Move("R3200-TRATA-END-TEL", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4156- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4158- PERFORM R3201-TRATA-ENDERECO. */

            R3201_TRATA_ENDERECO_SECTION();

            /*" -4160- MOVE ZEROS TO W-INDEX. */
            _.Move(0, WAREA_AUXILIAR.W_INDEX);

            /*" -4160- PERFORM R3250-TRATA-TELEFONES 4 TIMES. */

            for (int i = 0; i < 4; i++)
            {

                R3250_TRATA_TELEFONES_SECTION();

            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3200_SAIDA*/

        [StopWatch]
        /*" R3205-RELACIONA-ENDERECO-SECTION */
        private void R3205_RELACIONA_ENDERECO_SECTION()
        {
            /*" -4170- MOVE 'R3205-RELACIONA-ENDERECO' TO PARAGRAFO. */
            _.Move("R3205-RELACIONA-ENDERECO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4172- MOVE 'DECLARE PESSOA-ENDERECO' TO COMANDO. */
            _.Move("DECLARE PESSOA-ENDERECO", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4176- MOVE PESSOA-COD-PESSOA OF DCLPESSOA TO COD-PESSOA OF DCLPESSOA-ENDERECO. */
            _.Move(PESSOA.DCLPESSOA.PESSOA_COD_PESSOA, PESENDER.DCLPESSOA_ENDERECO.COD_PESSOA);

            /*" -4177- ACCEPT WS-HORA-INI FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_INI);

            /*" -4180- COMPUTE SIT = (HI * 60 * 60) + (MI * 60) + SI + (DI / 100) */
            WS_HORAS.SIT.Value = (WS_HORAS.WS_HORA_INI_R.HI * 60 * 60) + (WS_HORAS.WS_HORA_INI_R.MI * 60) + WS_HORAS.WS_HORA_INI_R.SI + (WS_HORAS.WS_HORA_INI_R.DI / 100f);

            /*" -4195- PERFORM R3205_RELACIONA_ENDERECO_DB_DECLARE_1 */

            R3205_RELACIONA_ENDERECO_DB_DECLARE_1();

            /*" -4199- ACCEPT WS-HORA-FIM FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_FIM);

            /*" -4200- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF + (DF / 100) */
            WS_HORAS.SFT.Value = (WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (WS_HORAS.WS_HORA_FIM_R.MF * 60) + WS_HORAS.WS_HORA_FIM_R.SF + (WS_HORAS.WS_HORA_FIM_R.DF / 100f);

            /*" -4201- SUBTRACT SIT FROM SFT */
            WS_HORAS.SFT.Value = WS_HORAS.SFT - WS_HORAS.SIT;

            /*" -4202- ADD SFT TO STT(38) */
            TOTAIS_ROT.FILLER_20[38].STT.Value = TOTAIS_ROT.FILLER_20[38].STT + WS_HORAS.SFT;

            /*" -4205- ADD 1 TO SQT(38) */
            TOTAIS_ROT.FILLER_20[38].SQT.Value = TOTAIS_ROT.FILLER_20[38].SQT + 1;

            /*" -4207- IF SQLCODE NOT EQUAL 00 AND SQLCODE NOT EQUAL 100 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != 100)
            {

                /*" -4208- DISPLAY 'PF0619B - FIM ANORMAL' */
                _.Display($"PF0619B - FIM ANORMAL");

                /*" -4209- DISPLAY '          ERRO DECLARE DA TABELA PESSOA-ENDERECO' */
                _.Display($"          ERRO DECLARE DA TABELA PESSOA-ENDERECO");

                /*" -4211- DISPLAY '          CODIGO PESSOA.................  ' COD-PESSOA OF DCLPESSOA-ENDERECO */
                _.Display($"          CODIGO PESSOA.................  {PESENDER.DCLPESSOA_ENDERECO.COD_PESSOA}");

                /*" -4213- DISPLAY '          NUMERO PROPOSTA...............  ' R2-NUM-PROPOSTA OF REG-ENDERECO */
                _.Display($"          NUMERO PROPOSTA...............  {LBFPF012.REG_ENDERECO.R2_NUM_PROPOSTA}");

                /*" -4215- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -4216- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -4216- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3205_SAIDA*/

        [StopWatch]
        /*" R3201-TRATA-ENDERECO-SECTION */
        private void R3201_TRATA_ENDERECO_SECTION()
        {
            /*" -4226- MOVE 'R3201-TRATA-ENDERECO' TO PARAGRAFO. */
            _.Move("R3201-TRATA-ENDERECO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4228- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4232- MOVE ZEROS TO OCORR-ENDERECO OF DCLPESSOA-ENDERECO, W-OCORR-ENDERECO. */
            _.Move(0, PESENDER.DCLPESSOA_ENDERECO.OCORR_ENDERECO, WAREA_AUXILIAR.W_OCORR_ENDERECO);

            /*" -4234- PERFORM R3205-RELACIONA-ENDERECO. */

            R3205_RELACIONA_ENDERECO_SECTION();

            /*" -4236- MOVE 'OPEN CURSOR ENDERECOS' TO COMANDO. */
            _.Move("OPEN CURSOR ENDERECOS", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4236- PERFORM R3201_TRATA_ENDERECO_DB_OPEN_1 */

            R3201_TRATA_ENDERECO_DB_OPEN_1();

            /*" -4240- MOVE 'NAO' TO W-ACHOU-ENDERECO. */
            _.Move("NAO", WAREA_AUXILIAR.W_ACHOU_ENDERECO);

            /*" -4242- MOVE SPACES TO W-FIM-CURSOR-ENDERECO. */
            _.Move("", WAREA_AUXILIAR.W_FIM_CURSOR_ENDERECO);

            /*" -4244- PERFORM R3210-FETCH-ENDERECO. */

            R3210_FETCH_ENDERECO_SECTION();

            /*" -4245- IF W-FIM-CURSOR-ENDERECO EQUAL 'SIM' */

            if (WAREA_AUXILIAR.W_FIM_CURSOR_ENDERECO == "SIM")
            {

                /*" -4249- IF R2-ENDERECO OF REG-ENDERECO EQUAL SPACES AND R2-BAIRRO OF REG-ENDERECO EQUAL SPACES AND R2-CIDADE OF REG-ENDERECO EQUAL SPACES AND R2-SIGLA-UF OF REG-ENDERECO EQUAL SPACES */

                if (LBFPF012.REG_ENDERECO.R2_ENDERECO.IsEmpty() && LBFPF012.REG_ENDERECO.R2_BAIRRO.IsEmpty() && LBFPF012.REG_ENDERECO.R2_CIDADE.IsEmpty() && LBFPF012.REG_ENDERECO.R2_SIGLA_UF.IsEmpty())
                {

                    /*" -4251- MOVE 'SIM' TO W-ACHOU-ENDERECO. */
                    _.Move("SIM", WAREA_AUXILIAR.W_ACHOU_ENDERECO);
                }

            }


            /*" -4254- PERFORM R3215-VERIFICA-EXISTE-ENDERECO UNTIL W-FIM-CURSOR-ENDERECO EQUAL 'SIM' . */

            while (!(WAREA_AUXILIAR.W_FIM_CURSOR_ENDERECO == "SIM"))
            {

                R3215_VERIFICA_EXISTE_ENDERECO_SECTION();
            }

            /*" -4255- IF W-ACHOU-ENDERECO EQUAL 'NAO' */

            if (WAREA_AUXILIAR.W_ACHOU_ENDERECO == "NAO")
            {

                /*" -4255- PERFORM R3220-INCLUIR-NOVO-ENDERECO. */

                R3220_INCLUIR_NOVO_ENDERECO_SECTION();
            }


        }

        [StopWatch]
        /*" R3201-TRATA-ENDERECO-DB-OPEN-1 */
        public void R3201_TRATA_ENDERECO_DB_OPEN_1()
        {
            /*" -4236- EXEC SQL OPEN ENDERECOS END-EXEC. */

            ENDERECOS.Open();

        }

        [StopWatch]
        /*" R5050-00-SELECIONA-BILHETE-DB-DECLARE-1 */
        public void R5050_00_SELECIONA_BILHETE_DB_DECLARE_1()
        {
            /*" -5990- EXEC SQL DECLARE CRS-BILHETE CURSOR FOR SELECT B.NUM_PROPOSTA_SIVPF, A.NUM_BILHETE FROM SEGUROS.BILHETE A, SEGUROS.PROPOSTA_FIDELIZ B WHERE A.SITUACAO = 'R' AND A.DATA_QUITACAO > :RELATORI-DATA-REFERENCIA AND A.DATA_QUITACAO <= :SISTEMAS-DATA-MOV-ABERTO AND B.NUM_SICOB = A.NUM_BILHETE AND B.SIT_PROPOSTA = 'PEN' ORDER BY A.DATA_QUITACAO, A.NUM_BILHETE WITH UR END-EXEC. */
            CRS_BILHETE = new PF0619B_CRS_BILHETE(true);
            string GetQuery_CRS_BILHETE()
            {
                var query = @$"SELECT B.NUM_PROPOSTA_SIVPF
							, 
							A.NUM_BILHETE 
							FROM SEGUROS.BILHETE A
							, 
							SEGUROS.PROPOSTA_FIDELIZ B 
							WHERE A.SITUACAO = 'R' 
							AND A.DATA_QUITACAO > '{RELATORI.DCLRELATORIOS.RELATORI_DATA_REFERENCIA}' 
							AND A.DATA_QUITACAO <= '{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}' 
							AND B.NUM_SICOB = A.NUM_BILHETE 
							AND B.SIT_PROPOSTA = 'PEN' 
							ORDER BY A.DATA_QUITACAO
							, 
							A.NUM_BILHETE";

                return query;
            }
            CRS_BILHETE.GetQueryEvent += GetQuery_CRS_BILHETE;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3201_SAIDA*/

        [StopWatch]
        /*" R3210-FETCH-ENDERECO-SECTION */
        private void R3210_FETCH_ENDERECO_SECTION()
        {
            /*" -4265- MOVE 'R3210-FETCH-ENDERECO' TO PARAGRAFO. */
            _.Move("R3210-FETCH-ENDERECO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4268- MOVE 'FETCH CURSOR ENDERECOS' TO COMANDO. */
            _.Move("FETCH CURSOR ENDERECOS", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4269- ACCEPT WS-HORA-INI FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_INI);

            /*" -4272- COMPUTE SIT = (HI * 60 * 60) + (MI * 60) + SI + (DI / 100) */
            WS_HORAS.SIT.Value = (WS_HORAS.WS_HORA_INI_R.HI * 60 * 60) + (WS_HORAS.WS_HORA_INI_R.MI * 60) + WS_HORAS.WS_HORA_INI_R.SI + (WS_HORAS.WS_HORA_INI_R.DI / 100f);

            /*" -4283- PERFORM R3210_FETCH_ENDERECO_DB_FETCH_1 */

            R3210_FETCH_ENDERECO_DB_FETCH_1();

            /*" -4287- ACCEPT WS-HORA-FIM FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_FIM);

            /*" -4288- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF + (DF / 100) */
            WS_HORAS.SFT.Value = (WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (WS_HORAS.WS_HORA_FIM_R.MF * 60) + WS_HORAS.WS_HORA_FIM_R.SF + (WS_HORAS.WS_HORA_FIM_R.DF / 100f);

            /*" -4289- SUBTRACT SIT FROM SFT */
            WS_HORAS.SFT.Value = WS_HORAS.SFT - WS_HORAS.SIT;

            /*" -4290- ADD SFT TO STT(39) */
            TOTAIS_ROT.FILLER_20[39].STT.Value = TOTAIS_ROT.FILLER_20[39].STT + WS_HORAS.SFT;

            /*" -4293- ADD 1 TO SQT(39) */
            TOTAIS_ROT.FILLER_20[39].SQT.Value = TOTAIS_ROT.FILLER_20[39].SQT + 1;

            /*" -4294- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -4295- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -4296- MOVE 'SIM' TO W-FIM-CURSOR-ENDERECO */
                    _.Move("SIM", WAREA_AUXILIAR.W_FIM_CURSOR_ENDERECO);

                    /*" -4296- PERFORM R3210_FETCH_ENDERECO_DB_CLOSE_1 */

                    R3210_FETCH_ENDERECO_DB_CLOSE_1();

                    /*" -4298- ELSE */
                }
                else
                {


                    /*" -4299- DISPLAY 'PF0619B - FIM ANORMAL' */
                    _.Display($"PF0619B - FIM ANORMAL");

                    /*" -4300- DISPLAY '          ERRO FETCH CURSOR ENDERECO' */
                    _.Display($"          ERRO FETCH CURSOR ENDERECO");

                    /*" -4302- DISPLAY '          CODIGO PESSOA.................  ' COD-PESSOA OF DCLPESSOA-ENDERECO */
                    _.Display($"          CODIGO PESSOA.................  {PESENDER.DCLPESSOA_ENDERECO.COD_PESSOA}");

                    /*" -4304- DISPLAY '          NUMERO PROPOSTA...............  ' R2-NUM-PROPOSTA OF REG-ENDERECO */
                    _.Display($"          NUMERO PROPOSTA...............  {LBFPF012.REG_ENDERECO.R2_NUM_PROPOSTA}");

                    /*" -4306- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                    _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                    /*" -4307- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -4307- PERFORM R9999-00-FINALIZAR. */

                    R9999_00_FINALIZAR_SECTION();
                }

            }


        }

        [StopWatch]
        /*" R3210-FETCH-ENDERECO-DB-FETCH-1 */
        public void R3210_FETCH_ENDERECO_DB_FETCH_1()
        {
            /*" -4283- EXEC SQL FETCH ENDERECOS INTO :DCLPESSOA-ENDERECO.OCORR-ENDERECO, :DCLPESSOA-ENDERECO.COD-PESSOA, :DCLPESSOA-ENDERECO.ENDERECO, :DCLPESSOA-ENDERECO.TIPO-ENDER, :DCLPESSOA-ENDERECO.BAIRRO, :DCLPESSOA-ENDERECO.CEP, :DCLPESSOA-ENDERECO.CIDADE, :DCLPESSOA-ENDERECO.SIGLA-UF, :DCLPESSOA-ENDERECO.SITUACAO-ENDERECO END-EXEC. */

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
        /*" R3210-FETCH-ENDERECO-DB-CLOSE-1 */
        public void R3210_FETCH_ENDERECO_DB_CLOSE_1()
        {
            /*" -4296- EXEC SQL CLOSE ENDERECOS END-EXEC */

            ENDERECOS.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3210_SAIDA*/

        [StopWatch]
        /*" R3215-VERIFICA-EXISTE-ENDERECO-SECTION */
        private void R3215_VERIFICA_EXISTE_ENDERECO_SECTION()
        {
            /*" -4317- MOVE 'R3215-VERIFICA-EXISTE-ENDERECO' TO PARAGRAFO. */
            _.Move("R3215-VERIFICA-EXISTE-ENDERECO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4319- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4331- IF R2-TIPO-ENDER OF REG-ENDERECO EQUAL TIPO-ENDER OF DCLPESSOA-ENDERECO AND R2-ENDERECO OF REG-ENDERECO EQUAL ENDERECO OF DCLPESSOA-ENDERECO AND R2-BAIRRO OF REG-ENDERECO EQUAL BAIRRO OF DCLPESSOA-ENDERECO AND R2-CIDADE OF REG-ENDERECO EQUAL CIDADE OF DCLPESSOA-ENDERECO AND R2-SIGLA-UF OF REG-ENDERECO EQUAL SIGLA-UF OF DCLPESSOA-ENDERECO AND R2-CEP OF REG-ENDERECO EQUAL CEP OF DCLPESSOA-ENDERECO */

            if (LBFPF012.REG_ENDERECO.R2_TIPO_ENDER == PESENDER.DCLPESSOA_ENDERECO.TIPO_ENDER && LBFPF012.REG_ENDERECO.R2_ENDERECO == PESENDER.DCLPESSOA_ENDERECO.ENDERECO && LBFPF012.REG_ENDERECO.R2_BAIRRO == PESENDER.DCLPESSOA_ENDERECO.BAIRRO && LBFPF012.REG_ENDERECO.R2_CIDADE == PESENDER.DCLPESSOA_ENDERECO.CIDADE && LBFPF012.REG_ENDERECO.R2_SIGLA_UF == PESENDER.DCLPESSOA_ENDERECO.SIGLA_UF && LBFPF012.REG_ENDERECO.R2_CEP == PESENDER.DCLPESSOA_ENDERECO.CEP)
            {

                /*" -4333- MOVE 'SIM' TO W-ACHOU-ENDERECO. */
                _.Move("SIM", WAREA_AUXILIAR.W_ACHOU_ENDERECO);
            }


            /*" -4337- IF R2-ENDERECO OF REG-ENDERECO EQUAL SPACES AND R2-BAIRRO OF REG-ENDERECO EQUAL SPACES AND R2-CIDADE OF REG-ENDERECO EQUAL SPACES AND R2-SIGLA-UF OF REG-ENDERECO EQUAL SPACES */

            if (LBFPF012.REG_ENDERECO.R2_ENDERECO.IsEmpty() && LBFPF012.REG_ENDERECO.R2_BAIRRO.IsEmpty() && LBFPF012.REG_ENDERECO.R2_CIDADE.IsEmpty() && LBFPF012.REG_ENDERECO.R2_SIGLA_UF.IsEmpty())
            {

                /*" -4339- MOVE 'SIM' TO W-ACHOU-ENDERECO. */
                _.Move("SIM", WAREA_AUXILIAR.W_ACHOU_ENDERECO);
            }


            /*" -4339- PERFORM R3210-FETCH-ENDERECO. */

            R3210_FETCH_ENDERECO_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3215_SAIDA*/

        [StopWatch]
        /*" R3220-INCLUIR-NOVO-ENDERECO-SECTION */
        private void R3220_INCLUIR_NOVO_ENDERECO_SECTION()
        {
            /*" -4349- MOVE 'R3220-INCLUIR-NOVO-ENDERECO' TO PARAGRAFO. */
            _.Move("R3220-INCLUIR-NOVO-ENDERECO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4358- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4361- MOVE OCORR-ENDERECO OF DCLPESSOA-ENDERECO TO W-OCORR-ENDERECO */
            _.Move(PESENDER.DCLPESSOA_ENDERECO.OCORR_ENDERECO, WAREA_AUXILIAR.W_OCORR_ENDERECO);

            /*" -4363- COMPUTE W-OCORR-ENDERECO = W-OCORR-ENDERECO + 1. */
            WAREA_AUXILIAR.W_OCORR_ENDERECO.Value = WAREA_AUXILIAR.W_OCORR_ENDERECO + 1;

            /*" -4363- PERFORM R3230-INCLUIR-ENDERECO. */

            R3230_INCLUIR_ENDERECO_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3220_SAIDA*/

        [StopWatch]
        /*" R3225-OBTER-MAX-ENDERECO-SECTION */
        private void R3225_OBTER_MAX_ENDERECO_SECTION()
        {
            /*" -4373- MOVE 'R3225-OBTER-MAX-ENDERECO' TO PARAGRAFO. */
            _.Move("R3225-OBTER-MAX-ENDERECO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4375- MOVE 'MAX SEGUROS.PESSOA_ENDERECO' TO COMANDO. */
            _.Move("MAX SEGUROS.PESSOA_ENDERECO", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4379- MOVE PESSOA-COD-PESSOA OF DCLPESSOA TO COD-PESSOA OF DCLPESSOA-ENDERECO. */
            _.Move(PESSOA.DCLPESSOA.PESSOA_COD_PESSOA, PESENDER.DCLPESSOA_ENDERECO.COD_PESSOA);

            /*" -4380- ACCEPT WS-HORA-INI FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_INI);

            /*" -4383- COMPUTE SIT = (HI * 60 * 60) + (MI * 60) + SI + (DI / 100) */
            WS_HORAS.SIT.Value = (WS_HORAS.WS_HORA_INI_R.HI * 60 * 60) + (WS_HORAS.WS_HORA_INI_R.MI * 60) + WS_HORAS.WS_HORA_INI_R.SI + (WS_HORAS.WS_HORA_INI_R.DI / 100f);

            /*" -4389- PERFORM R3225_OBTER_MAX_ENDERECO_DB_SELECT_1 */

            R3225_OBTER_MAX_ENDERECO_DB_SELECT_1();

            /*" -4393- ACCEPT WS-HORA-FIM FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_FIM);

            /*" -4394- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF + (DF / 100) */
            WS_HORAS.SFT.Value = (WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (WS_HORAS.WS_HORA_FIM_R.MF * 60) + WS_HORAS.WS_HORA_FIM_R.SF + (WS_HORAS.WS_HORA_FIM_R.DF / 100f);

            /*" -4395- SUBTRACT SIT FROM SFT */
            WS_HORAS.SFT.Value = WS_HORAS.SFT - WS_HORAS.SIT;

            /*" -4396- ADD SFT TO STT(40) */
            TOTAIS_ROT.FILLER_20[40].STT.Value = TOTAIS_ROT.FILLER_20[40].STT + WS_HORAS.SFT;

            /*" -4399- ADD 1 TO SQT(40) */
            TOTAIS_ROT.FILLER_20[40].SQT.Value = TOTAIS_ROT.FILLER_20[40].SQT + 1;

            /*" -4400- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -4401- DISPLAY 'PF0619B - FIM ANORMAL' */
                _.Display($"PF0619B - FIM ANORMAL");

                /*" -4402- DISPLAY '          ERRO SELECT MAX TAB. PESSOA-ENDERECO' */
                _.Display($"          ERRO SELECT MAX TAB. PESSOA-ENDERECO");

                /*" -4404- DISPLAY '          CODIGO PESSOA.................  ' COD-PESSOA OF DCLPESSOA-ENDERECO */
                _.Display($"          CODIGO PESSOA.................  {PESENDER.DCLPESSOA_ENDERECO.COD_PESSOA}");

                /*" -4406- DISPLAY '          NUMERO DA PROPOSTA............  ' R2-NUM-PROPOSTA OF REG-ENDERECO */
                _.Display($"          NUMERO DA PROPOSTA............  {LBFPF012.REG_ENDERECO.R2_NUM_PROPOSTA}");

                /*" -4408- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -4409- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -4409- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R3225-OBTER-MAX-ENDERECO-DB-SELECT-1 */
        public void R3225_OBTER_MAX_ENDERECO_DB_SELECT_1()
        {
            /*" -4389- EXEC SQL SELECT VALUE(MAX(OCORR_ENDERECO),0) INTO :DCLPESSOA-ENDERECO.OCORR-ENDERECO FROM SEGUROS.PESSOA_ENDERECO WHERE COD_PESSOA = :DCLPESSOA-ENDERECO.COD-PESSOA WITH UR END-EXEC. */

            var r3225_OBTER_MAX_ENDERECO_DB_SELECT_1_Query1 = new R3225_OBTER_MAX_ENDERECO_DB_SELECT_1_Query1()
            {
                COD_PESSOA = PESENDER.DCLPESSOA_ENDERECO.COD_PESSOA.ToString(),
            };

            var executed_1 = R3225_OBTER_MAX_ENDERECO_DB_SELECT_1_Query1.Execute(r3225_OBTER_MAX_ENDERECO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.OCORR_ENDERECO, PESENDER.DCLPESSOA_ENDERECO.OCORR_ENDERECO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3225_SAIDA*/

        [StopWatch]
        /*" R3230-INCLUIR-ENDERECO-SECTION */
        private void R3230_INCLUIR_ENDERECO_SECTION()
        {
            /*" -4419- MOVE 'R3230-INCLUI-ENDERECO' TO PARAGRAFO. */
            _.Move("R3230-INCLUI-ENDERECO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4421- MOVE 'INSERT PESSOA-ENDERECO' TO COMANDO. */
            _.Move("INSERT PESSOA-ENDERECO", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4424- MOVE W-OCORR-ENDERECO TO OCORR-ENDERECO OF DCLPESSOA-ENDERECO. */
            _.Move(WAREA_AUXILIAR.W_OCORR_ENDERECO, PESENDER.DCLPESSOA_ENDERECO.OCORR_ENDERECO);

            /*" -4427- MOVE PESSOA-COD-PESSOA OF DCLPESSOA TO COD-PESSOA OF DCLPESSOA-ENDERECO. */
            _.Move(PESSOA.DCLPESSOA.PESSOA_COD_PESSOA, PESENDER.DCLPESSOA_ENDERECO.COD_PESSOA);

            /*" -4430- MOVE R2-ENDERECO OF REG-ENDERECO TO ENDERECO OF DCLPESSOA-ENDERECO. */
            _.Move(LBFPF012.REG_ENDERECO.R2_ENDERECO, PESENDER.DCLPESSOA_ENDERECO.ENDERECO);

            /*" -4433- MOVE R2-TIPO-ENDER OF REG-ENDERECO TO TIPO-ENDER OF DCLPESSOA-ENDERECO. */
            _.Move(LBFPF012.REG_ENDERECO.R2_TIPO_ENDER, PESENDER.DCLPESSOA_ENDERECO.TIPO_ENDER);

            /*" -4436- MOVE R2-BAIRRO OF REG-ENDERECO TO BAIRRO OF DCLPESSOA-ENDERECO. */
            _.Move(LBFPF012.REG_ENDERECO.R2_BAIRRO, PESENDER.DCLPESSOA_ENDERECO.BAIRRO);

            /*" -4439- MOVE R2-CEP OF REG-ENDERECO TO CEP OF DCLPESSOA-ENDERECO. */
            _.Move(LBFPF012.REG_ENDERECO.R2_CEP, PESENDER.DCLPESSOA_ENDERECO.CEP);

            /*" -4442- MOVE R2-CIDADE OF REG-ENDERECO TO CIDADE OF DCLPESSOA-ENDERECO. */
            _.Move(LBFPF012.REG_ENDERECO.R2_CIDADE, PESENDER.DCLPESSOA_ENDERECO.CIDADE);

            /*" -4445- MOVE R2-SIGLA-UF OF REG-ENDERECO TO SIGLA-UF OF DCLPESSOA-ENDERECO. */
            _.Move(LBFPF012.REG_ENDERECO.R2_SIGLA_UF, PESENDER.DCLPESSOA_ENDERECO.SIGLA_UF);

            /*" -4448- MOVE 'A' TO SITUACAO-ENDERECO OF DCLPESSOA-ENDERECO. */
            _.Move("A", PESENDER.DCLPESSOA_ENDERECO.SITUACAO_ENDERECO);

            /*" -4452- MOVE 'PF0619B' TO COD-USUARIO OF DCLPESSOA-ENDERECO. */
            _.Move("PF0619B", PESENDER.DCLPESSOA_ENDERECO.COD_USUARIO);

            /*" -4453- ACCEPT WS-HORA-INI FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_INI);

            /*" -4456- COMPUTE SIT = (HI * 60 * 60) + (MI * 60) + SI + (DI / 100) */
            WS_HORAS.SIT.Value = (WS_HORAS.WS_HORA_INI_R.HI * 60 * 60) + (WS_HORAS.WS_HORA_INI_R.MI * 60) + WS_HORAS.WS_HORA_INI_R.SI + (WS_HORAS.WS_HORA_INI_R.DI / 100f);

            /*" -4470- PERFORM R3230_INCLUIR_ENDERECO_DB_INSERT_1 */

            R3230_INCLUIR_ENDERECO_DB_INSERT_1();

            /*" -4474- ACCEPT WS-HORA-FIM FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_FIM);

            /*" -4475- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF + (DF / 100) */
            WS_HORAS.SFT.Value = (WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (WS_HORAS.WS_HORA_FIM_R.MF * 60) + WS_HORAS.WS_HORA_FIM_R.SF + (WS_HORAS.WS_HORA_FIM_R.DF / 100f);

            /*" -4476- SUBTRACT SIT FROM SFT */
            WS_HORAS.SFT.Value = WS_HORAS.SFT - WS_HORAS.SIT;

            /*" -4477- ADD SFT TO STT(41) */
            TOTAIS_ROT.FILLER_20[41].STT.Value = TOTAIS_ROT.FILLER_20[41].STT + WS_HORAS.SFT;

            /*" -4480- ADD 1 TO SQT(41) */
            TOTAIS_ROT.FILLER_20[41].SQT.Value = TOTAIS_ROT.FILLER_20[41].SQT + 1;

            /*" -4481- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -4482- DISPLAY 'PF0619B - FIM ANORMAL' */
                _.Display($"PF0619B - FIM ANORMAL");

                /*" -4483- DISPLAY '          ERRO INSERT TABELA PESSOA-ENDERECO' */
                _.Display($"          ERRO INSERT TABELA PESSOA-ENDERECO");

                /*" -4485- DISPLAY '          CODIGO PESSOA.................  ' COD-PESSOA OF DCLPESSOA-ENDERECO */
                _.Display($"          CODIGO PESSOA.................  {PESENDER.DCLPESSOA_ENDERECO.COD_PESSOA}");

                /*" -4487- DISPLAY '          NUMERO DA PROPOSTA............  ' R2-NUM-PROPOSTA OF REG-ENDERECO */
                _.Display($"          NUMERO DA PROPOSTA............  {LBFPF012.REG_ENDERECO.R2_NUM_PROPOSTA}");

                /*" -4489- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -4490- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -4490- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R3230-INCLUIR-ENDERECO-DB-INSERT-1 */
        public void R3230_INCLUIR_ENDERECO_DB_INSERT_1()
        {
            /*" -4470- EXEC SQL INSERT INTO SEGUROS.PESSOA_ENDERECO VALUES (:DCLPESSOA-ENDERECO.COD-PESSOA, :DCLPESSOA-ENDERECO.OCORR-ENDERECO, :DCLPESSOA-ENDERECO.ENDERECO, :DCLPESSOA-ENDERECO.TIPO-ENDER, NULL, :DCLPESSOA-ENDERECO.BAIRRO, :DCLPESSOA-ENDERECO.CEP, :DCLPESSOA-ENDERECO.CIDADE, :DCLPESSOA-ENDERECO.SIGLA-UF, :DCLPESSOA-ENDERECO.SITUACAO-ENDERECO, :DCLPESSOA-ENDERECO.COD-USUARIO, CURRENT TIMESTAMP) END-EXEC. */

            var r3230_INCLUIR_ENDERECO_DB_INSERT_1_Insert1 = new R3230_INCLUIR_ENDERECO_DB_INSERT_1_Insert1()
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

            R3230_INCLUIR_ENDERECO_DB_INSERT_1_Insert1.Execute(r3230_INCLUIR_ENDERECO_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3230_SAIDA*/

        [StopWatch]
        /*" R3250-TRATA-TELEFONES-SECTION */
        private void R3250_TRATA_TELEFONES_SECTION()
        {
            /*" -4500- MOVE 'R3250-TRATA-TELEFONE' TO PARAGRAFO. */
            _.Move("R3250-TRATA-TELEFONE", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4502- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4504- ADD 1 TO W-INDEX. */
            WAREA_AUXILIAR.W_INDEX.Value = WAREA_AUXILIAR.W_INDEX + 1;

            /*" -4506- MOVE 'NAO' TO W-ACHOU-TELEFONE. */
            _.Move("NAO", WAREA_AUXILIAR.W_ACHOU_TELEFONE);

            /*" -4507- IF R1-NUM-FONE (W-INDEX) GREATER ZEROS */

            if (LBFPF011.REG_CLIENTES.R1_TELEFONE[WAREA_AUXILIAR.W_INDEX].R1_NUM_FONE > 00)
            {

                /*" -4508- PERFORM R3255-LER-TELEFONE */

                R3255_LER_TELEFONE_SECTION();

                /*" -4509- IF W-ACHOU-TELEFONE EQUAL 'NAO' */

                if (WAREA_AUXILIAR.W_ACHOU_TELEFONE == "NAO")
                {

                    /*" -4509- PERFORM R3260-INCLUIR-NOVO-TELEFONE. */

                    R3260_INCLUIR_NOVO_TELEFONE_SECTION();
                }

            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3250_SAIDA*/

        [StopWatch]
        /*" R3255-LER-TELEFONE-SECTION */
        private void R3255_LER_TELEFONE_SECTION()
        {
            /*" -4519- MOVE 'R3255-LER-TELEFONE' TO PARAGRAFO. */
            _.Move("R3255-LER-TELEFONE", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4521- MOVE 'SELECT PESSOA-TELEFONE' TO COMANDO. */
            _.Move("SELECT PESSOA-TELEFONE", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4527- MOVE PESSOA-COD-PESSOA OF DCLPESSOA TO COD-PESSOA OF DCLPESSOA-TELEFONE. */
            _.Move(PESSOA.DCLPESSOA.PESSOA_COD_PESSOA, PESFONE.DCLPESSOA_TELEFONE.COD_PESSOA);

            /*" -4533- MOVE R1-DDD (W-INDEX) TO DDD OF DCLPESSOA-TELEFONE. */
            _.Move(LBFPF011.REG_CLIENTES.R1_TELEFONE[WAREA_AUXILIAR.W_INDEX].R1_DDD, PESFONE.DCLPESSOA_TELEFONE.DDD);

            /*" -4541- MOVE R1-NUM-FONE (W-INDEX) TO NUM-FONE OF DCLPESSOA-TELEFONE. */
            _.Move(LBFPF011.REG_CLIENTES.R1_TELEFONE[WAREA_AUXILIAR.W_INDEX].R1_NUM_FONE, PESFONE.DCLPESSOA_TELEFONE.NUM_FONE);

            /*" -4546- MOVE W-INDEX TO TIPO-FONE OF DCLPESSOA-TELEFONE */
            _.Move(WAREA_AUXILIAR.W_INDEX, PESFONE.DCLPESSOA_TELEFONE.TIPO_FONE);

            /*" -4547- ACCEPT WS-HORA-INI FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_INI);

            /*" -4550- COMPUTE SIT = (HI * 60 * 60) + (MI * 60) + SI + (DI / 100) */
            WS_HORAS.SIT.Value = (WS_HORAS.WS_HORA_INI_R.HI * 60 * 60) + (WS_HORAS.WS_HORA_INI_R.MI * 60) + WS_HORAS.WS_HORA_INI_R.SI + (WS_HORAS.WS_HORA_INI_R.DI / 100f);

            /*" -4559- PERFORM R3255_LER_TELEFONE_DB_SELECT_1 */

            R3255_LER_TELEFONE_DB_SELECT_1();

            /*" -4563- ACCEPT WS-HORA-FIM FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_FIM);

            /*" -4564- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF + (DF / 100) */
            WS_HORAS.SFT.Value = (WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (WS_HORAS.WS_HORA_FIM_R.MF * 60) + WS_HORAS.WS_HORA_FIM_R.SF + (WS_HORAS.WS_HORA_FIM_R.DF / 100f);

            /*" -4565- SUBTRACT SIT FROM SFT */
            WS_HORAS.SFT.Value = WS_HORAS.SFT - WS_HORAS.SIT;

            /*" -4566- ADD SFT TO STT(42) */
            TOTAIS_ROT.FILLER_20[42].STT.Value = TOTAIS_ROT.FILLER_20[42].STT + WS_HORAS.SFT;

            /*" -4569- ADD 1 TO SQT(42) */
            TOTAIS_ROT.FILLER_20[42].SQT.Value = TOTAIS_ROT.FILLER_20[42].SQT + 1;

            /*" -4570- IF SQLCODE EQUAL 00 */

            if (DB.SQLCODE == 00)
            {

                /*" -4571- MOVE 'SIM' TO W-ACHOU-TELEFONE */
                _.Move("SIM", WAREA_AUXILIAR.W_ACHOU_TELEFONE);

                /*" -4572- ELSE */
            }
            else
            {


                /*" -4573- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -4574- MOVE 'NAO' TO W-ACHOU-TELEFONE */
                    _.Move("NAO", WAREA_AUXILIAR.W_ACHOU_TELEFONE);

                    /*" -4575- ELSE */
                }
                else
                {


                    /*" -4576- DISPLAY 'PF0619B - FIM ANORMAL' */
                    _.Display($"PF0619B - FIM ANORMAL");

                    /*" -4577- DISPLAY '          ERRO SELECT TABELA PESSOA-TELEFONE' */
                    _.Display($"          ERRO SELECT TABELA PESSOA-TELEFONE");

                    /*" -4579- DISPLAY '          CODIGO PESSOA.................  ' COD-PESSOA OF DCLPESSOA-TELEFONE */
                    _.Display($"          CODIGO PESSOA.................  {PESFONE.DCLPESSOA_TELEFONE.COD_PESSOA}");

                    /*" -4581- DISPLAY '          NUMERO PROPOSTA...............  ' R2-NUM-PROPOSTA OF REG-ENDERECO */
                    _.Display($"          NUMERO PROPOSTA...............  {LBFPF012.REG_ENDERECO.R2_NUM_PROPOSTA}");

                    /*" -4583- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                    _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                    /*" -4584- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -4584- PERFORM R9999-00-FINALIZAR. */

                    R9999_00_FINALIZAR_SECTION();
                }

            }


        }

        [StopWatch]
        /*" R3255-LER-TELEFONE-DB-SELECT-1 */
        public void R3255_LER_TELEFONE_DB_SELECT_1()
        {
            /*" -4559- EXEC SQL SELECT SITUACAO_FONE INTO :DCLPESSOA-TELEFONE.SITUACAO-FONE FROM SEGUROS.PESSOA_TELEFONE WHERE COD_PESSOA = :DCLPESSOA-TELEFONE.COD-PESSOA AND TIPO_FONE = :DCLPESSOA-TELEFONE.TIPO-FONE AND NUM_FONE = :DCLPESSOA-TELEFONE.NUM-FONE AND DDD = :DCLPESSOA-TELEFONE.DDD WITH UR END-EXEC. */

            var r3255_LER_TELEFONE_DB_SELECT_1_Query1 = new R3255_LER_TELEFONE_DB_SELECT_1_Query1()
            {
                COD_PESSOA = PESFONE.DCLPESSOA_TELEFONE.COD_PESSOA.ToString(),
                TIPO_FONE = PESFONE.DCLPESSOA_TELEFONE.TIPO_FONE.ToString(),
                NUM_FONE = PESFONE.DCLPESSOA_TELEFONE.NUM_FONE.ToString(),
                DDD = PESFONE.DCLPESSOA_TELEFONE.DDD.ToString(),
            };

            var executed_1 = R3255_LER_TELEFONE_DB_SELECT_1_Query1.Execute(r3255_LER_TELEFONE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SITUACAO_FONE, PESFONE.DCLPESSOA_TELEFONE.SITUACAO_FONE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3255_SAIDA*/

        [StopWatch]
        /*" R3260-INCLUIR-NOVO-TELEFONE-SECTION */
        private void R3260_INCLUIR_NOVO_TELEFONE_SECTION()
        {
            /*" -4594- MOVE 'R3260-INCLUIR-NOVO-TELEFONE' TO PARAGRAFO. */
            _.Move("R3260-INCLUIR-NOVO-TELEFONE", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4596- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4598- PERFORM R3265-OBTER-MAX-TELEFONE. */

            R3265_OBTER_MAX_TELEFONE_SECTION();

            /*" -4601- MOVE SEQ-FONE OF DCLPESSOA-TELEFONE TO W-SEQ-FONE */
            _.Move(PESFONE.DCLPESSOA_TELEFONE.SEQ_FONE, WAREA_AUXILIAR.W_SEQ_FONE);

            /*" -4603- COMPUTE W-SEQ-FONE = W-SEQ-FONE + 1. */
            WAREA_AUXILIAR.W_SEQ_FONE.Value = WAREA_AUXILIAR.W_SEQ_FONE + 1;

            /*" -4603- PERFORM R3270-INCLUIR-TELEFONE. */

            R3270_INCLUIR_TELEFONE_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3260_SAIDA*/

        [StopWatch]
        /*" R3265-OBTER-MAX-TELEFONE-SECTION */
        private void R3265_OBTER_MAX_TELEFONE_SECTION()
        {
            /*" -4613- MOVE 'R3265-OBTER-MAX-TELEFONE' TO PARAGRAFO. */
            _.Move("R3265-OBTER-MAX-TELEFONE", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4616- MOVE 'MAX SEGUROS.PESSOA_TELEFONE' TO COMANDO. */
            _.Move("MAX SEGUROS.PESSOA_TELEFONE", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4617- ACCEPT WS-HORA-INI FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_INI);

            /*" -4620- COMPUTE SIT = (HI * 60 * 60) + (MI * 60) + SI + (DI / 100) */
            WS_HORAS.SIT.Value = (WS_HORAS.WS_HORA_INI_R.HI * 60 * 60) + (WS_HORAS.WS_HORA_INI_R.MI * 60) + WS_HORAS.WS_HORA_INI_R.SI + (WS_HORAS.WS_HORA_INI_R.DI / 100f);

            /*" -4626- PERFORM R3265_OBTER_MAX_TELEFONE_DB_SELECT_1 */

            R3265_OBTER_MAX_TELEFONE_DB_SELECT_1();

            /*" -4630- ACCEPT WS-HORA-FIM FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_FIM);

            /*" -4631- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF + (DF / 100) */
            WS_HORAS.SFT.Value = (WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (WS_HORAS.WS_HORA_FIM_R.MF * 60) + WS_HORAS.WS_HORA_FIM_R.SF + (WS_HORAS.WS_HORA_FIM_R.DF / 100f);

            /*" -4632- SUBTRACT SIT FROM SFT */
            WS_HORAS.SFT.Value = WS_HORAS.SFT - WS_HORAS.SIT;

            /*" -4633- ADD SFT TO STT(43) */
            TOTAIS_ROT.FILLER_20[43].STT.Value = TOTAIS_ROT.FILLER_20[43].STT + WS_HORAS.SFT;

            /*" -4636- ADD 1 TO SQT(43) */
            TOTAIS_ROT.FILLER_20[43].SQT.Value = TOTAIS_ROT.FILLER_20[43].SQT + 1;

            /*" -4637- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -4638- DISPLAY 'PF0619B - FIM ANORMAL' */
                _.Display($"PF0619B - FIM ANORMAL");

                /*" -4639- DISPLAY '          ERRO SELECT MAX TAB. PESSOA-TELEFONE' */
                _.Display($"          ERRO SELECT MAX TAB. PESSOA-TELEFONE");

                /*" -4641- DISPLAY '          CODIGO PESSOA.................  ' COD-PESSOA OF DCLPESSOA-TELEFONE */
                _.Display($"          CODIGO PESSOA.................  {PESFONE.DCLPESSOA_TELEFONE.COD_PESSOA}");

                /*" -4643- DISPLAY '          NUMERO DA PROPOSTA............  ' R1-NUM-PROPOSTA OF REG-CLIENTES */
                _.Display($"          NUMERO DA PROPOSTA............  {LBFPF011.REG_CLIENTES.R1_NUM_PROPOSTA}");

                /*" -4645- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -4646- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -4646- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R3265-OBTER-MAX-TELEFONE-DB-SELECT-1 */
        public void R3265_OBTER_MAX_TELEFONE_DB_SELECT_1()
        {
            /*" -4626- EXEC SQL SELECT VALUE(MAX(SEQ_FONE),0) INTO :DCLPESSOA-TELEFONE.SEQ-FONE FROM SEGUROS.PESSOA_TELEFONE WHERE COD_PESSOA = :DCLPESSOA-TELEFONE.COD-PESSOA WITH UR END-EXEC. */

            var r3265_OBTER_MAX_TELEFONE_DB_SELECT_1_Query1 = new R3265_OBTER_MAX_TELEFONE_DB_SELECT_1_Query1()
            {
                COD_PESSOA = PESFONE.DCLPESSOA_TELEFONE.COD_PESSOA.ToString(),
            };

            var executed_1 = R3265_OBTER_MAX_TELEFONE_DB_SELECT_1_Query1.Execute(r3265_OBTER_MAX_TELEFONE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SEQ_FONE, PESFONE.DCLPESSOA_TELEFONE.SEQ_FONE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3265_SAIDA*/

        [StopWatch]
        /*" R3270-INCLUIR-TELEFONE-SECTION */
        private void R3270_INCLUIR_TELEFONE_SECTION()
        {
            /*" -4656- MOVE 'R3270-INCLUI-TELEFONE' TO PARAGRAFO. */
            _.Move("R3270-INCLUI-TELEFONE", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4658- MOVE 'INSERT PESSOA-TELEFONE' TO COMANDO. */
            _.Move("INSERT PESSOA-TELEFONE", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4662- MOVE PESSOA-COD-PESSOA OF DCLPESSOA TO COD-PESSOA OF DCLPESSOA-TELEFONE. */
            _.Move(PESSOA.DCLPESSOA.PESSOA_COD_PESSOA, PESFONE.DCLPESSOA_TELEFONE.COD_PESSOA);

            /*" -4665- MOVE W-INDEX TO TIPO-FONE OF DCLPESSOA-TELEFONE. */
            _.Move(WAREA_AUXILIAR.W_INDEX, PESFONE.DCLPESSOA_TELEFONE.TIPO_FONE);

            /*" -4668- MOVE W-SEQ-FONE TO SEQ-FONE OF DCLPESSOA-TELEFONE. */
            _.Move(WAREA_AUXILIAR.W_SEQ_FONE, PESFONE.DCLPESSOA_TELEFONE.SEQ_FONE);

            /*" -4671- MOVE 55 TO DDI OF DCLPESSOA-TELEFONE. */
            _.Move(55, PESFONE.DCLPESSOA_TELEFONE.DDI);

            /*" -4674- MOVE R1-DDD (W-INDEX) TO DDD OF DCLPESSOA-TELEFONE. */
            _.Move(LBFPF011.REG_CLIENTES.R1_TELEFONE[WAREA_AUXILIAR.W_INDEX].R1_DDD, PESFONE.DCLPESSOA_TELEFONE.DDD);

            /*" -4677- MOVE R1-NUM-FONE (W-INDEX) TO NUM-FONE OF DCLPESSOA-TELEFONE. */
            _.Move(LBFPF011.REG_CLIENTES.R1_TELEFONE[WAREA_AUXILIAR.W_INDEX].R1_NUM_FONE, PESFONE.DCLPESSOA_TELEFONE.NUM_FONE);

            /*" -4680- MOVE 'A' TO SITUACAO-FONE OF DCLPESSOA-TELEFONE. */
            _.Move("A", PESFONE.DCLPESSOA_TELEFONE.SITUACAO_FONE);

            /*" -4685- MOVE 'PF0619B' TO COD-USUARIO OF DCLPESSOA-TELEFONE. */
            _.Move("PF0619B", PESFONE.DCLPESSOA_TELEFONE.COD_USUARIO);

            /*" -4686- ACCEPT WS-HORA-INI FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_INI);

            /*" -4689- COMPUTE SIT = (HI * 60 * 60) + (MI * 60) + SI + (DI / 100) */
            WS_HORAS.SIT.Value = (WS_HORAS.WS_HORA_INI_R.HI * 60 * 60) + (WS_HORAS.WS_HORA_INI_R.MI * 60) + WS_HORAS.WS_HORA_INI_R.SI + (WS_HORAS.WS_HORA_INI_R.DI / 100f);

            /*" -4700- PERFORM R3270_INCLUIR_TELEFONE_DB_INSERT_1 */

            R3270_INCLUIR_TELEFONE_DB_INSERT_1();

            /*" -4704- ACCEPT WS-HORA-FIM FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_FIM);

            /*" -4705- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF + (DF / 100) */
            WS_HORAS.SFT.Value = (WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (WS_HORAS.WS_HORA_FIM_R.MF * 60) + WS_HORAS.WS_HORA_FIM_R.SF + (WS_HORAS.WS_HORA_FIM_R.DF / 100f);

            /*" -4706- SUBTRACT SIT FROM SFT */
            WS_HORAS.SFT.Value = WS_HORAS.SFT - WS_HORAS.SIT;

            /*" -4707- ADD SFT TO STT(44) */
            TOTAIS_ROT.FILLER_20[44].STT.Value = TOTAIS_ROT.FILLER_20[44].STT + WS_HORAS.SFT;

            /*" -4710- ADD 1 TO SQT(44) */
            TOTAIS_ROT.FILLER_20[44].SQT.Value = TOTAIS_ROT.FILLER_20[44].SQT + 1;

            /*" -4711- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -4712- DISPLAY 'PF0619B - FIM ANORMAL' */
                _.Display($"PF0619B - FIM ANORMAL");

                /*" -4713- DISPLAY '          ERRO INSERT TABELA PESSOA-TELEFONE' */
                _.Display($"          ERRO INSERT TABELA PESSOA-TELEFONE");

                /*" -4715- DISPLAY '          CODIGO PESSOA.................  ' COD-PESSOA OF DCLPESSOA-TELEFONE */
                _.Display($"          CODIGO PESSOA.................  {PESFONE.DCLPESSOA_TELEFONE.COD_PESSOA}");

                /*" -4717- DISPLAY '          NUMERO DA PROPOSTA............  ' R1-NUM-PROPOSTA OF REG-CLIENTES */
                _.Display($"          NUMERO DA PROPOSTA............  {LBFPF011.REG_CLIENTES.R1_NUM_PROPOSTA}");

                /*" -4719- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -4720- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -4720- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R3270-INCLUIR-TELEFONE-DB-INSERT-1 */
        public void R3270_INCLUIR_TELEFONE_DB_INSERT_1()
        {
            /*" -4700- EXEC SQL INSERT INTO SEGUROS.PESSOA_TELEFONE VALUES (:DCLPESSOA-TELEFONE.COD-PESSOA, :DCLPESSOA-TELEFONE.TIPO-FONE, :DCLPESSOA-TELEFONE.SEQ-FONE, :DCLPESSOA-TELEFONE.DDI, :DCLPESSOA-TELEFONE.DDD, :DCLPESSOA-TELEFONE.NUM-FONE, :DCLPESSOA-TELEFONE.SITUACAO-FONE, :DCLPESSOA-TELEFONE.COD-USUARIO, CURRENT TIMESTAMP) END-EXEC. */

            var r3270_INCLUIR_TELEFONE_DB_INSERT_1_Insert1 = new R3270_INCLUIR_TELEFONE_DB_INSERT_1_Insert1()
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

            R3270_INCLUIR_TELEFONE_DB_INSERT_1_Insert1.Execute(r3270_INCLUIR_TELEFONE_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3270_SAIDA*/

        [StopWatch]
        /*" R3300-TRATA-PROPOSTA-SECTION */
        private void R3300_TRATA_PROPOSTA_SECTION()
        {
            /*" -4730- MOVE 'R3300-TRATA-PROPOSTA' TO PARAGRAFO. */
            _.Move("R3300-TRATA-PROPOSTA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4732- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4734- MOVE ZERO TO W-TEM-TABPROPFID */
            _.Move(0, WAREA_AUXILIAR.W_TEM_TABPROPFID);

            /*" -4736- PERFORM R3310-TRATA-TAB-RELACIONAMENTO. */

            R3310_TRATA_TAB_RELACIONAMENTO_SECTION();

            /*" -4738- PERFORM R3350-TRATA-TAB-IDE-RELACIONAM. */

            R3350_TRATA_TAB_IDE_RELACIONAM_SECTION();

            /*" -4739- PERFORM R3360-TRATA-PROP-FIDELIZACAO. */

            R3360_TRATA_PROP_FIDELIZACAO_SECTION();

            /*" -4740- IF TEM-TABPROPFID */

            if (WAREA_AUXILIAR.W_TEM_TABPROPFID["TEM_TABPROPFID"])
            {

                /*" -4742- GO TO R3300-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3300_SAIDA*/ //GOTO
                return;
            }


            /*" -4744- PERFORM R3365-TRATA-PROP-ESPECIFICA. */

            R3365_TRATA_PROP_ESPECIFICA_SECTION();

            /*" -4744- PERFORM R3390-GERA-HIST-FIDELIZACAO. */

            R3390_GERA_HIST_FIDELIZACAO_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3300_SAIDA*/

        [StopWatch]
        /*" R3310-TRATA-TAB-RELACIONAMENTO-SECTION */
        private void R3310_TRATA_TAB_RELACIONAMENTO_SECTION()
        {
            /*" -4754- MOVE 'R3310-TRATA-TAB-RELACIONAMENTO' TO PARAGRAFO. */
            _.Move("R3310-TRATA-TAB-RELACIONAMENTO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4756- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4758- PERFORM R3315-DETERMINA-RELACIONAMENTO */

            R3315_DETERMINA_RELACIONAMENTO_SECTION();

            /*" -4760- MOVE 'NAO' TO W-ACHOU-RELACIONAMENTO. */
            _.Move("NAO", WAREA_AUXILIAR.W_ACHOU_RELACIONAMENTO);

            /*" -4762- PERFORM R3320-VERIFICA-EXISTE-RELACION. */

            R3320_VERIFICA_EXISTE_RELACION_SECTION();

            /*" -4763- IF W-ACHOU-RELACIONAMENTO EQUAL 'NAO' */

            if (WAREA_AUXILIAR.W_ACHOU_RELACIONAMENTO == "NAO")
            {

                /*" -4763- PERFORM R3330-GERA-RELACIONAMENTO. */

                R3330_GERA_RELACIONAMENTO_SECTION();
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3310_SAIDA*/

        [StopWatch]
        /*" R3315-DETERMINA-RELACIONAMENTO-SECTION */
        private void R3315_DETERMINA_RELACIONAMENTO_SECTION()
        {
            /*" -4773- MOVE 'R3315-DETERMINA-RELACIONAMENTO' TO PARAGRAFO. */
            _.Move("R3315-DETERMINA-RELACIONAMENTO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4775- MOVE 'SELECT PRODUTOS_SIVPF' TO COMANDO. */
            _.Move("SELECT PRODUTOS_SIVPF", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4778- MOVE 1 TO PRDSIVPF-COD-EMPRESA-SIVPF OF DCLPRODUTOS-SIVPF */
            _.Move(1, PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_EMPRESA_SIVPF);

            /*" -4781- MOVE R3-COD-PRODUTO OF REG-PROPOSTA-SASSE TO PRDSIVPF-COD-PRODUTO-SIVPF OF DCLPRODUTOS-SIVPF. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_COD_PRODUTO, PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_PRODUTO_SIVPF);

            /*" -4785- MOVE PRDSIVPF-COD-EMPRESA-SIVPF OF DCLPRODUTOS-SIVPF TO W-COD-EMPRESA. */
            _.Move(PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_EMPRESA_SIVPF, WAREA_AUXILIAR.W_COD_EMPRESA);

            /*" -4786- ACCEPT WS-HORA-INI FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_INI);

            /*" -4789- COMPUTE SIT = (HI * 60 * 60) + (MI * 60) + SI + (DI / 100) */
            WS_HORAS.SIT.Value = (WS_HORAS.WS_HORA_INI_R.HI * 60 * 60) + (WS_HORAS.WS_HORA_INI_R.MI * 60) + WS_HORAS.WS_HORA_INI_R.SI + (WS_HORAS.WS_HORA_INI_R.DI / 100f);

            /*" -4803- PERFORM R3315_DETERMINA_RELACIONAMENTO_DB_SELECT_1 */

            R3315_DETERMINA_RELACIONAMENTO_DB_SELECT_1();

            /*" -4807- ACCEPT WS-HORA-FIM FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_FIM);

            /*" -4808- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF + (DF / 100) */
            WS_HORAS.SFT.Value = (WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (WS_HORAS.WS_HORA_FIM_R.MF * 60) + WS_HORAS.WS_HORA_FIM_R.SF + (WS_HORAS.WS_HORA_FIM_R.DF / 100f);

            /*" -4809- SUBTRACT SIT FROM SFT */
            WS_HORAS.SFT.Value = WS_HORAS.SFT - WS_HORAS.SIT;

            /*" -4810- ADD SFT TO STT(45) */
            TOTAIS_ROT.FILLER_20[45].STT.Value = TOTAIS_ROT.FILLER_20[45].STT + WS_HORAS.SFT;

            /*" -4813- ADD 1 TO SQT(45) */
            TOTAIS_ROT.FILLER_20[45].SQT.Value = TOTAIS_ROT.FILLER_20[45].SQT + 1;

            /*" -4814- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -4815- DISPLAY 'PF0619B - FIM ANORMAL' */
                _.Display($"PF0619B - FIM ANORMAL");

                /*" -4816- DISPLAY '          ERRO SELECT TAB. PRODUTOS-SIVPF' */
                _.Display($"          ERRO SELECT TAB. PRODUTOS-SIVPF");

                /*" -4818- DISPLAY '          NOME EMPRESA.................. ' RH-NOME OF REG-HEADER */
                _.Display($"          NOME EMPRESA.................. {LXFPF990.REG_HEADER.RH_NOME}");

                /*" -4820- DISPLAY '          CODIGO DO PRODUTO............. ' PRDSIVPF-COD-PRODUTO-SIVPF OF DCLPRODUTOS-SIVPF */
                _.Display($"          CODIGO DO PRODUTO............. {PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_PRODUTO_SIVPF}");

                /*" -4822- DISPLAY '          NUMERO DA PROPOSTA............  ' R3-NUM-PROPOSTA OF REG-PROPOSTA-SASSE */
                _.Display($"          NUMERO DA PROPOSTA............  {LXFCT004.REG_PROPOSTA_SASSE.R3_NUM_PROPOSTA}");

                /*" -4824- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -4825- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -4827- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


            /*" -4831- MOVE PRDSIVPF-COD-RELAC OF DCLPRODUTOS-SIVPF TO W-COD-RELACION, W-RELACIONAMENTO. */
            _.Move(PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_RELAC, WAREA_AUXILIAR.W_COD_RELACION, WAREA_AUXILIAR.W_RELACIONAMENTO);

            /*" -4832- MOVE PRDSIVPF-COD-PRODUTO-SIVPF OF DCLPRODUTOS-SIVPF TO W-PRODUTO. */
            _.Move(PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_PRODUTO_SIVPF, WAREA_AUXILIAR.W_PRODUTO);

        }

        [StopWatch]
        /*" R3315-DETERMINA-RELACIONAMENTO-DB-SELECT-1 */
        public void R3315_DETERMINA_RELACIONAMENTO_DB_SELECT_1()
        {
            /*" -4803- EXEC SQL SELECT DISTINCT COD_PRODUTO_SIVPF, COD_RELAC INTO :DCLPRODUTOS-SIVPF.PRDSIVPF-COD-PRODUTO-SIVPF, :DCLPRODUTOS-SIVPF.PRDSIVPF-COD-RELAC FROM SEGUROS.PRODUTOS_SIVPF WHERE COD_EMPRESA_SIVPF = :DCLPRODUTOS-SIVPF.PRDSIVPF-COD-EMPRESA-SIVPF AND COD_PRODUTO_SIVPF = :DCLPRODUTOS-SIVPF.PRDSIVPF-COD-PRODUTO-SIVPF ORDER BY COD_PRODUTO_SIVPF, COD_RELAC WITH UR END-EXEC. */

            var r3315_DETERMINA_RELACIONAMENTO_DB_SELECT_1_Query1 = new R3315_DETERMINA_RELACIONAMENTO_DB_SELECT_1_Query1()
            {
                PRDSIVPF_COD_EMPRESA_SIVPF = PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_EMPRESA_SIVPF.ToString(),
                PRDSIVPF_COD_PRODUTO_SIVPF = PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_PRODUTO_SIVPF.ToString(),
            };

            var executed_1 = R3315_DETERMINA_RELACIONAMENTO_DB_SELECT_1_Query1.Execute(r3315_DETERMINA_RELACIONAMENTO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PRDSIVPF_COD_PRODUTO_SIVPF, PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_PRODUTO_SIVPF);
                _.Move(executed_1.PRDSIVPF_COD_RELAC, PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_RELAC);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3315_SAIDA*/

        [StopWatch]
        /*" R3320-VERIFICA-EXISTE-RELACION-SECTION */
        private void R3320_VERIFICA_EXISTE_RELACION_SECTION()
        {
            /*" -4842- MOVE 'R3320-VERIFICA-EXISTE-RELACION' TO PARAGRAFO. */
            _.Move("R3320-VERIFICA-EXISTE-RELACION", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4844- MOVE 'SELECT PESSOAS_TIPORELAC' TO COMANDO. */
            _.Move("SELECT PESSOAS_TIPORELAC", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4847- MOVE PESSOA-COD-PESSOA OF DCLPESSOA TO COD-PESSOA OF DCLR-PESSOA-TIPORELAC. */
            _.Move(PESSOA.DCLPESSOA.PESSOA_COD_PESSOA, RTPRELAC.DCLR_PESSOA_TIPORELAC.COD_PESSOA);

            /*" -4852- MOVE W-COD-RELACION TO COD-RELAC OF DCLR-PESSOA-TIPORELAC. */
            _.Move(WAREA_AUXILIAR.W_COD_RELACION, RTPRELAC.DCLR_PESSOA_TIPORELAC.COD_RELAC);

            /*" -4853- ACCEPT WS-HORA-INI FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_INI);

            /*" -4856- COMPUTE SIT = (HI * 60 * 60) + (MI * 60) + SI + (DI / 100) */
            WS_HORAS.SIT.Value = (WS_HORAS.WS_HORA_INI_R.HI * 60 * 60) + (WS_HORAS.WS_HORA_INI_R.MI * 60) + WS_HORAS.WS_HORA_INI_R.SI + (WS_HORAS.WS_HORA_INI_R.DI / 100f);

            /*" -4865- PERFORM R3320_VERIFICA_EXISTE_RELACION_DB_SELECT_1 */

            R3320_VERIFICA_EXISTE_RELACION_DB_SELECT_1();

            /*" -4869- ACCEPT WS-HORA-FIM FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_FIM);

            /*" -4870- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF + (DF / 100) */
            WS_HORAS.SFT.Value = (WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (WS_HORAS.WS_HORA_FIM_R.MF * 60) + WS_HORAS.WS_HORA_FIM_R.SF + (WS_HORAS.WS_HORA_FIM_R.DF / 100f);

            /*" -4871- SUBTRACT SIT FROM SFT */
            WS_HORAS.SFT.Value = WS_HORAS.SFT - WS_HORAS.SIT;

            /*" -4872- ADD SFT TO STT(46) */
            TOTAIS_ROT.FILLER_20[46].STT.Value = TOTAIS_ROT.FILLER_20[46].STT + WS_HORAS.SFT;

            /*" -4875- ADD 1 TO SQT(46) */
            TOTAIS_ROT.FILLER_20[46].SQT.Value = TOTAIS_ROT.FILLER_20[46].SQT + 1;

            /*" -4876- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -4877- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -4878- MOVE 'NAO' TO W-ACHOU-RELACIONAMENTO */
                    _.Move("NAO", WAREA_AUXILIAR.W_ACHOU_RELACIONAMENTO);

                    /*" -4879- ELSE */
                }
                else
                {


                    /*" -4880- DISPLAY 'PF0619B - FIM ANORMAL' */
                    _.Display($"PF0619B - FIM ANORMAL");

                    /*" -4881- DISPLAY '          ERRO SELECT TAB. PESSOA-TIPORELAC' */
                    _.Display($"          ERRO SELECT TAB. PESSOA-TIPORELAC");

                    /*" -4883- DISPLAY '          CODIGO PESSOA.................  ' COD-PESSOA OF DCLR-PESSOA-TIPORELAC */
                    _.Display($"          CODIGO PESSOA.................  {RTPRELAC.DCLR_PESSOA_TIPORELAC.COD_PESSOA}");

                    /*" -4885- DISPLAY '          CODIGO RELACIONAMENTO.........  ' COD-RELAC OF DCLR-PESSOA-TIPORELAC */
                    _.Display($"          CODIGO RELACIONAMENTO.........  {RTPRELAC.DCLR_PESSOA_TIPORELAC.COD_RELAC}");

                    /*" -4887- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                    _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                    /*" -4888- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -4889- PERFORM R9999-00-FINALIZAR */

                    R9999_00_FINALIZAR_SECTION();

                    /*" -4890- ELSE */
                }

            }
            else
            {


                /*" -4890- MOVE 'SIM' TO W-ACHOU-RELACIONAMENTO. */
                _.Move("SIM", WAREA_AUXILIAR.W_ACHOU_RELACIONAMENTO);
            }


        }

        [StopWatch]
        /*" R3320-VERIFICA-EXISTE-RELACION-DB-SELECT-1 */
        public void R3320_VERIFICA_EXISTE_RELACION_DB_SELECT_1()
        {
            /*" -4865- EXEC SQL SELECT COD_PESSOA, COD_RELAC INTO :DCLR-PESSOA-TIPORELAC.COD-PESSOA, :DCLR-PESSOA-TIPORELAC.COD-RELAC FROM SEGUROS.R_PESSOA_TIPORELAC WHERE COD_PESSOA = :DCLR-PESSOA-TIPORELAC.COD-PESSOA AND COD_RELAC = :DCLR-PESSOA-TIPORELAC.COD-RELAC WITH UR END-EXEC. */

            var r3320_VERIFICA_EXISTE_RELACION_DB_SELECT_1_Query1 = new R3320_VERIFICA_EXISTE_RELACION_DB_SELECT_1_Query1()
            {
                COD_PESSOA = RTPRELAC.DCLR_PESSOA_TIPORELAC.COD_PESSOA.ToString(),
                COD_RELAC = RTPRELAC.DCLR_PESSOA_TIPORELAC.COD_RELAC.ToString(),
            };

            var executed_1 = R3320_VERIFICA_EXISTE_RELACION_DB_SELECT_1_Query1.Execute(r3320_VERIFICA_EXISTE_RELACION_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.COD_PESSOA, RTPRELAC.DCLR_PESSOA_TIPORELAC.COD_PESSOA);
                _.Move(executed_1.COD_RELAC, RTPRELAC.DCLR_PESSOA_TIPORELAC.COD_RELAC);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3320_SAIDA*/

        [StopWatch]
        /*" R3330-GERA-RELACIONAMENTO-SECTION */
        private void R3330_GERA_RELACIONAMENTO_SECTION()
        {
            /*" -4900- MOVE 'R3330-GERA-RELACIONAMENTO' TO PARAGRAFO. */
            _.Move("R3330-GERA-RELACIONAMENTO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4902- MOVE 'INSERT PESSOAS_TIPORELAC' TO COMANDO. */
            _.Move("INSERT PESSOAS_TIPORELAC", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4905- MOVE PESSOA-COD-PESSOA OF DCLPESSOA TO COD-PESSOA OF DCLR-PESSOA-TIPORELAC. */
            _.Move(PESSOA.DCLPESSOA.PESSOA_COD_PESSOA, RTPRELAC.DCLR_PESSOA_TIPORELAC.COD_PESSOA);

            /*" -4910- MOVE W-COD-RELACION TO COD-RELAC OF DCLR-PESSOA-TIPORELAC. */
            _.Move(WAREA_AUXILIAR.W_COD_RELACION, RTPRELAC.DCLR_PESSOA_TIPORELAC.COD_RELAC);

            /*" -4911- ACCEPT WS-HORA-INI FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_INI);

            /*" -4914- COMPUTE SIT = (HI * 60 * 60) + (MI * 60) + SI + (DI / 100) */
            WS_HORAS.SIT.Value = (WS_HORAS.WS_HORA_INI_R.HI * 60 * 60) + (WS_HORAS.WS_HORA_INI_R.MI * 60) + WS_HORAS.WS_HORA_INI_R.SI + (WS_HORAS.WS_HORA_INI_R.DI / 100f);

            /*" -4918- PERFORM R3330_GERA_RELACIONAMENTO_DB_INSERT_1 */

            R3330_GERA_RELACIONAMENTO_DB_INSERT_1();

            /*" -4922- ACCEPT WS-HORA-FIM FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_FIM);

            /*" -4923- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF + (DF / 100) */
            WS_HORAS.SFT.Value = (WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (WS_HORAS.WS_HORA_FIM_R.MF * 60) + WS_HORAS.WS_HORA_FIM_R.SF + (WS_HORAS.WS_HORA_FIM_R.DF / 100f);

            /*" -4924- SUBTRACT SIT FROM SFT */
            WS_HORAS.SFT.Value = WS_HORAS.SFT - WS_HORAS.SIT;

            /*" -4925- ADD SFT TO STT(47) */
            TOTAIS_ROT.FILLER_20[47].STT.Value = TOTAIS_ROT.FILLER_20[47].STT + WS_HORAS.SFT;

            /*" -4928- ADD 1 TO SQT(47) */
            TOTAIS_ROT.FILLER_20[47].SQT.Value = TOTAIS_ROT.FILLER_20[47].SQT + 1;

            /*" -4929- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -4930- DISPLAY 'PF0619B - FIM ANORMAL' */
                _.Display($"PF0619B - FIM ANORMAL");

                /*" -4931- DISPLAY '          ERRO INSERT TAB. PESSOA-TIPORELAC' */
                _.Display($"          ERRO INSERT TAB. PESSOA-TIPORELAC");

                /*" -4933- DISPLAY '          CODIGO PESSOA.................  ' COD-PESSOA OF DCLR-PESSOA-TIPORELAC */
                _.Display($"          CODIGO PESSOA.................  {RTPRELAC.DCLR_PESSOA_TIPORELAC.COD_PESSOA}");

                /*" -4935- DISPLAY '          CODIGO RELACIONAMENTO.........  ' COD-RELAC OF DCLR-PESSOA-TIPORELAC */
                _.Display($"          CODIGO RELACIONAMENTO.........  {RTPRELAC.DCLR_PESSOA_TIPORELAC.COD_RELAC}");

                /*" -4937- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -4938- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -4938- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R3330-GERA-RELACIONAMENTO-DB-INSERT-1 */
        public void R3330_GERA_RELACIONAMENTO_DB_INSERT_1()
        {
            /*" -4918- EXEC SQL INSERT INTO SEGUROS.R_PESSOA_TIPORELAC VALUES (:DCLR-PESSOA-TIPORELAC.COD-PESSOA, :DCLR-PESSOA-TIPORELAC.COD-RELAC) END-EXEC. */

            var r3330_GERA_RELACIONAMENTO_DB_INSERT_1_Insert1 = new R3330_GERA_RELACIONAMENTO_DB_INSERT_1_Insert1()
            {
                COD_PESSOA = RTPRELAC.DCLR_PESSOA_TIPORELAC.COD_PESSOA.ToString(),
                COD_RELAC = RTPRELAC.DCLR_PESSOA_TIPORELAC.COD_RELAC.ToString(),
            };

            R3330_GERA_RELACIONAMENTO_DB_INSERT_1_Insert1.Execute(r3330_GERA_RELACIONAMENTO_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3330_SAIDA*/

        [StopWatch]
        /*" R3350-TRATA-TAB-IDE-RELACIONAM-SECTION */
        private void R3350_TRATA_TAB_IDE_RELACIONAM_SECTION()
        {
            /*" -4948- IF W-OBTER-MAX-RELAC EQUAL 'NAO' */

            if (WAREA_AUXILIAR.W_OBTER_MAX_RELAC == "NAO")
            {

                /*" -4949- MOVE 'SIM' TO W-OBTER-MAX-RELAC */
                _.Move("SIM", WAREA_AUXILIAR.W_OBTER_MAX_RELAC);

                /*" -4951- PERFORM R3355-OBTER-MAX-ID-RELACIONAM. */

                R3355_OBTER_MAX_ID_RELACIONAM_SECTION();
            }


            /*" -4952- MOVE 'R3350-TRATA-TAB-RELACIONAM' TO PARAGRAFO. */
            _.Move("R3350-TRATA-TAB-RELACIONAM", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4954- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4957- MOVE NUM-IDENTIFICACAO OF DCLIDENTIFICA-RELAC TO W-NUM-IDENTIF. */
            _.Move(IDERELAC.DCLIDENTIFICA_RELAC.NUM_IDENTIFICACAO, WAREA_AUXILIAR.W_NUM_IDENTIF);

            /*" -4960- COMPUTE W-NUM-IDENTIF = W-NUM-IDENTIF + 1. */
            WAREA_AUXILIAR.W_NUM_IDENTIF.Value = WAREA_AUXILIAR.W_NUM_IDENTIF + 1;

            /*" -4963- MOVE W-NUM-IDENTIF TO NUM-IDENTIFICACAO OF DCLIDENTIFICA-RELAC. */
            _.Move(WAREA_AUXILIAR.W_NUM_IDENTIF, IDERELAC.DCLIDENTIFICA_RELAC.NUM_IDENTIFICACAO);

            /*" -4966- MOVE COD-PESSOA OF DCLR-PESSOA-TIPORELAC TO COD-PESSOA OF DCLIDENTIFICA-RELAC. */
            _.Move(RTPRELAC.DCLR_PESSOA_TIPORELAC.COD_PESSOA, IDERELAC.DCLIDENTIFICA_RELAC.COD_PESSOA);

            /*" -4969- MOVE COD-RELAC OF DCLR-PESSOA-TIPORELAC TO COD-RELAC OF DCLIDENTIFICA-RELAC. */
            _.Move(RTPRELAC.DCLR_PESSOA_TIPORELAC.COD_RELAC, IDERELAC.DCLIDENTIFICA_RELAC.COD_RELAC);

            /*" -4974- MOVE 'PF0619B' TO COD-USUARIO OF DCLIDENTIFICA-RELAC. */
            _.Move("PF0619B", IDERELAC.DCLIDENTIFICA_RELAC.COD_USUARIO);

            /*" -4975- ACCEPT WS-HORA-INI FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_INI);

            /*" -4978- COMPUTE SIT = (HI * 60 * 60) + (MI * 60) + SI + (DI / 100) */
            WS_HORAS.SIT.Value = (WS_HORAS.WS_HORA_INI_R.HI * 60 * 60) + (WS_HORAS.WS_HORA_INI_R.MI * 60) + WS_HORAS.WS_HORA_INI_R.SI + (WS_HORAS.WS_HORA_INI_R.DI / 100f);

            /*" -4985- PERFORM R3350_TRATA_TAB_IDE_RELACIONAM_DB_INSERT_1 */

            R3350_TRATA_TAB_IDE_RELACIONAM_DB_INSERT_1();

            /*" -4989- ACCEPT WS-HORA-FIM FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_FIM);

            /*" -4990- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF + (DF / 100) */
            WS_HORAS.SFT.Value = (WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (WS_HORAS.WS_HORA_FIM_R.MF * 60) + WS_HORAS.WS_HORA_FIM_R.SF + (WS_HORAS.WS_HORA_FIM_R.DF / 100f);

            /*" -4991- SUBTRACT SIT FROM SFT */
            WS_HORAS.SFT.Value = WS_HORAS.SFT - WS_HORAS.SIT;

            /*" -4992- ADD SFT TO STT(48) */
            TOTAIS_ROT.FILLER_20[48].STT.Value = TOTAIS_ROT.FILLER_20[48].STT + WS_HORAS.SFT;

            /*" -4995- ADD 1 TO SQT(48) */
            TOTAIS_ROT.FILLER_20[48].SQT.Value = TOTAIS_ROT.FILLER_20[48].SQT + 1;

            /*" -4996- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -4997- DISPLAY 'PF0619B - FIM ANORMAL' */
                _.Display($"PF0619B - FIM ANORMAL");

                /*" -4998- DISPLAY '          ERRO INSERT TABELA IDENTIFICA-RELAC.' */
                _.Display($"          ERRO INSERT TABELA IDENTIFICA-RELAC.");

                /*" -5000- DISPLAY '          NUM IDENTIFICACAO.............  ' NUM-IDENTIFICACAO OF DCLIDENTIFICA-RELAC */
                _.Display($"          NUM IDENTIFICACAO.............  {IDERELAC.DCLIDENTIFICA_RELAC.NUM_IDENTIFICACAO}");

                /*" -5002- DISPLAY '          CODIGO PESSOA.................  ' COD-PESSOA OF DCLIDENTIFICA-RELAC */
                _.Display($"          CODIGO PESSOA.................  {IDERELAC.DCLIDENTIFICA_RELAC.COD_PESSOA}");

                /*" -5004- DISPLAY '          CODIGO RELACIONAMENTO.........  ' COD-RELAC OF DCLIDENTIFICA-RELAC */
                _.Display($"          CODIGO RELACIONAMENTO.........  {IDERELAC.DCLIDENTIFICA_RELAC.COD_RELAC}");

                /*" -5006- DISPLAY '          NUMERO PROPOSTA...............  ' R2-NUM-PROPOSTA OF REG-ENDERECO */
                _.Display($"          NUMERO PROPOSTA...............  {LBFPF012.REG_ENDERECO.R2_NUM_PROPOSTA}");

                /*" -5008- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -5009- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -5009- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R3350-TRATA-TAB-IDE-RELACIONAM-DB-INSERT-1 */
        public void R3350_TRATA_TAB_IDE_RELACIONAM_DB_INSERT_1()
        {
            /*" -4985- EXEC SQL INSERT INTO SEGUROS.IDENTIFICA_RELAC VALUES (:DCLIDENTIFICA-RELAC.NUM-IDENTIFICACAO, :DCLIDENTIFICA-RELAC.COD-PESSOA, :DCLIDENTIFICA-RELAC.COD-RELAC, :DCLIDENTIFICA-RELAC.COD-USUARIO, CURRENT TIMESTAMP) END-EXEC. */

            var r3350_TRATA_TAB_IDE_RELACIONAM_DB_INSERT_1_Insert1 = new R3350_TRATA_TAB_IDE_RELACIONAM_DB_INSERT_1_Insert1()
            {
                NUM_IDENTIFICACAO = IDERELAC.DCLIDENTIFICA_RELAC.NUM_IDENTIFICACAO.ToString(),
                COD_PESSOA = IDERELAC.DCLIDENTIFICA_RELAC.COD_PESSOA.ToString(),
                COD_RELAC = IDERELAC.DCLIDENTIFICA_RELAC.COD_RELAC.ToString(),
                COD_USUARIO = IDERELAC.DCLIDENTIFICA_RELAC.COD_USUARIO.ToString(),
            };

            R3350_TRATA_TAB_IDE_RELACIONAM_DB_INSERT_1_Insert1.Execute(r3350_TRATA_TAB_IDE_RELACIONAM_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3350_SAIDA*/

        [StopWatch]
        /*" R3355-OBTER-MAX-ID-RELACIONAM-SECTION */
        private void R3355_OBTER_MAX_ID_RELACIONAM_SECTION()
        {
            /*" -5019- MOVE 'R3355-OBTER-MAX-ID-RELACIONAM' TO PARAGRAFO. */
            _.Move("R3355-OBTER-MAX-ID-RELACIONAM", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5021- MOVE 'MAX IDENTIFICA_RELAC' TO COMANDO. */
            _.Move("MAX IDENTIFICA_RELAC", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5024- MOVE COD-PESSOA OF DCLR-PESSOA-TIPORELAC TO COD-PESSOA OF DCLIDENTIFICA-RELAC. */
            _.Move(RTPRELAC.DCLR_PESSOA_TIPORELAC.COD_PESSOA, IDERELAC.DCLIDENTIFICA_RELAC.COD_PESSOA);

            /*" -5028- MOVE COD-RELAC OF DCLR-PESSOA-TIPORELAC TO COD-RELAC OF DCLIDENTIFICA-RELAC. */
            _.Move(RTPRELAC.DCLR_PESSOA_TIPORELAC.COD_RELAC, IDERELAC.DCLIDENTIFICA_RELAC.COD_RELAC);

            /*" -5029- ACCEPT WS-HORA-INI FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_INI);

            /*" -5032- COMPUTE SIT = (HI * 60 * 60) + (MI * 60) + SI + (DI / 100) */
            WS_HORAS.SIT.Value = (WS_HORAS.WS_HORA_INI_R.HI * 60 * 60) + (WS_HORAS.WS_HORA_INI_R.MI * 60) + WS_HORAS.WS_HORA_INI_R.SI + (WS_HORAS.WS_HORA_INI_R.DI / 100f);

            /*" -5039- PERFORM R3355_OBTER_MAX_ID_RELACIONAM_DB_SELECT_1 */

            R3355_OBTER_MAX_ID_RELACIONAM_DB_SELECT_1();

            /*" -5043- ACCEPT WS-HORA-FIM FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_FIM);

            /*" -5044- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF + (DF / 100) */
            WS_HORAS.SFT.Value = (WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (WS_HORAS.WS_HORA_FIM_R.MF * 60) + WS_HORAS.WS_HORA_FIM_R.SF + (WS_HORAS.WS_HORA_FIM_R.DF / 100f);

            /*" -5045- SUBTRACT SIT FROM SFT */
            WS_HORAS.SFT.Value = WS_HORAS.SFT - WS_HORAS.SIT;

            /*" -5046- ADD SFT TO STT(49) */
            TOTAIS_ROT.FILLER_20[49].STT.Value = TOTAIS_ROT.FILLER_20[49].STT + WS_HORAS.SFT;

            /*" -5049- ADD 1 TO SQT(49) */
            TOTAIS_ROT.FILLER_20[49].SQT.Value = TOTAIS_ROT.FILLER_20[49].SQT + 1;

            /*" -5050- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -5051- DISPLAY 'PF0619B - FIM ANORMAL' */
                _.Display($"PF0619B - FIM ANORMAL");

                /*" -5052- DISPLAY '          ERRO SELECT MAX TAB. IDENTIFICA-RELAC' */
                _.Display($"          ERRO SELECT MAX TAB. IDENTIFICA-RELAC");

                /*" -5054- DISPLAY '          CODIGO PESSOA.................  ' COD-PESSOA OF DCLIDENTIFICA-RELAC */
                _.Display($"          CODIGO PESSOA.................  {IDERELAC.DCLIDENTIFICA_RELAC.COD_PESSOA}");

                /*" -5056- DISPLAY '          CODIGO RELACIONAMENTO.........  ' COD-RELAC OF DCLIDENTIFICA-RELAC */
                _.Display($"          CODIGO RELACIONAMENTO.........  {IDERELAC.DCLIDENTIFICA_RELAC.COD_RELAC}");

                /*" -5058- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -5059- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -5059- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R3355-OBTER-MAX-ID-RELACIONAM-DB-SELECT-1 */
        public void R3355_OBTER_MAX_ID_RELACIONAM_DB_SELECT_1()
        {
            /*" -5039- EXEC SQL SELECT VALUE(MAX(NUM_IDENTIFICACAO),0) INTO :DCLIDENTIFICA-RELAC.NUM-IDENTIFICACAO FROM SEGUROS.IDENTIFICA_RELAC WITH UR END-EXEC. */

            var r3355_OBTER_MAX_ID_RELACIONAM_DB_SELECT_1_Query1 = new R3355_OBTER_MAX_ID_RELACIONAM_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R3355_OBTER_MAX_ID_RELACIONAM_DB_SELECT_1_Query1.Execute(r3355_OBTER_MAX_ID_RELACIONAM_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.NUM_IDENTIFICACAO, IDERELAC.DCLIDENTIFICA_RELAC.NUM_IDENTIFICACAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3355_SAIDA*/

        [StopWatch]
        /*" R3360-TRATA-PROP-FIDELIZACAO-SECTION */
        private void R3360_TRATA_PROP_FIDELIZACAO_SECTION()
        {
            /*" -5069- MOVE 'R3360-TRATA-PROP-FIDELIZACAO' TO PARAGRAFO. */
            _.Move("R3360-TRATA-PROP-FIDELIZACAO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5071- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5072- IF W-CONTROLE-TP-0 GREATER ZERO */

            if (WAREA_AUXILIAR.W_CONTROLE_TP_0 > 00)
            {

                /*" -5073- MOVE 1 TO W-TP-MOVIMENTO */
                _.Move(1, WAREA_AUXILIAR.W_TP_MOVIMENTO);

                /*" -5074- ELSE */
            }
            else
            {


                /*" -5078- MOVE 2 TO W-TP-MOVIMENTO. */
                _.Move(2, WAREA_AUXILIAR.W_TP_MOVIMENTO);
            }


            /*" -5081- MOVE R3-NUM-PROPOSTA OF REG-PROPOSTA-SASSE TO NUM-SICOB OF DCLPROPOSTA-FIDELIZ. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_NUM_PROPOSTA, PROPFID.DCLPROPOSTA_FIDELIZ.NUM_SICOB);

            /*" -5085- MOVE R3-NUM-PROPOSTA OF REG-PROPOSTA-SASSE TO NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ, W-NUM-PROPOSTA. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_NUM_PROPOSTA, PROPFID.DCLPROPOSTA_FIDELIZ.NUM_PROPOSTA_SIVPF, WAREA_AUXILIAR.W_NUM_PROPOSTA);

            /*" -5089- MOVE NUM-IDENTIFICACAO OF DCLIDENTIFICA-RELAC TO NUM-IDENTIFICACAO OF DCLPROPOSTA-FIDELIZ. */
            _.Move(IDERELAC.DCLIDENTIFICA_RELAC.NUM_IDENTIFICACAO, PROPFID.DCLPROPOSTA_FIDELIZ.NUM_IDENTIFICACAO);

            /*" -5092- MOVE R3-DATA-PROPOSTA OF REG-PROPOSTA-SASSE TO W-DATA-TRABALHO. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_DATA_PROPOSTA, WAREA_AUXILIAR.W_DATA_TRABALHO);

            /*" -5094- MOVE W-DIA-TRABALHO TO W-DIA-SQL OF W-DATA-SQL1. */
            _.Move(WAREA_AUXILIAR.FILLER_2.W_DIA_TRABALHO, WAREA_AUXILIAR.W_DATA_SQL1.W_DIA_SQL);

            /*" -5096- MOVE W-MES-TRABALHO TO W-MES-SQL OF W-DATA-SQL1. */
            _.Move(WAREA_AUXILIAR.FILLER_2.W_MES_TRABALHO, WAREA_AUXILIAR.W_DATA_SQL1.W_MES_SQL);

            /*" -5099- MOVE W-ANO-TRABALHO TO W-ANO-SQL OF W-DATA-SQL1. */
            _.Move(WAREA_AUXILIAR.FILLER_2.W_ANO_TRABALHO, WAREA_AUXILIAR.W_DATA_SQL1.W_ANO_SQL);

            /*" -5103- MOVE '-' TO W-BARRA1 OF W-DATA-SQL1, W-BARRA2 OF W-DATA-SQL1. */
            _.Move("-", WAREA_AUXILIAR.W_DATA_SQL1.W_BARRA1_1);
            _.Move("-", WAREA_AUXILIAR.W_DATA_SQL1.W_BARRA2_1);


            /*" -5106- MOVE W-DATA-SQL TO DATA-PROPOSTA OF DCLPROPOSTA-FIDELIZ. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL, PROPFID.DCLPROPOSTA_FIDELIZ.DATA_PROPOSTA);

            /*" -5109- MOVE R3-COD-PRODUTO OF REG-PROPOSTA-SASSE TO COD-PRODUTO-SIVPF OF DCLPROPOSTA-FIDELIZ. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_COD_PRODUTO, PROPFID.DCLPROPOSTA_FIDELIZ.COD_PRODUTO_SIVPF);

            /*" -5112- MOVE PRDSIVPF-COD-EMPRESA-SIVPF OF DCLPRODUTOS-SIVPF TO COD-EMPRESA-SIVPF OF DCLPROPOSTA-FIDELIZ. */
            _.Move(PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_EMPRESA_SIVPF, PROPFID.DCLPROPOSTA_FIDELIZ.COD_EMPRESA_SIVPF);

            /*" -5115- MOVE R3-AGECOBR OF REG-PROPOSTA-SASSE TO AGECOBR OF DCLPROPOSTA-FIDELIZ. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_AGECOBR, PROPFID.DCLPROPOSTA_FIDELIZ.AGECOBR);

            /*" -5118- MOVE R3-DIA-DEBITO OF REG-PROPOSTA-SASSE TO DIA-DEBITO OF DCLPROPOSTA-FIDELIZ. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_DIA_DEBITO, PROPFID.DCLPROPOSTA_FIDELIZ.DIA_DEBITO);

            /*" -5121- MOVE R3-OPCAOPAG OF REG-PROPOSTA-SASSE TO OPCAOPAG OF DCLPROPOSTA-FIDELIZ. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_OPCAOPAG, PROPFID.DCLPROPOSTA_FIDELIZ.OPCAOPAG);

            /*" -5124- MOVE R3-AGECTADEB OF REG-PROPOSTA-SASSE TO AGECTADEB OF DCLPROPOSTA-FIDELIZ. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_CONTA_DEBITO.R3_AGECTADEB, PROPFID.DCLPROPOSTA_FIDELIZ.AGECTADEB);

            /*" -5127- MOVE R3-OPRCTADEB OF REG-PROPOSTA-SASSE TO OPRCTADEB OF DCLPROPOSTA-FIDELIZ. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_CONTA_DEBITO.R3_OPRCTADEB, PROPFID.DCLPROPOSTA_FIDELIZ.OPRCTADEB);

            /*" -5130- MOVE R3-NUMCTADEB OF REG-PROPOSTA-SASSE TO NUMCTADEB OF DCLPROPOSTA-FIDELIZ. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_CONTA_DEBITO.R3_NUMCTADEB, PROPFID.DCLPROPOSTA_FIDELIZ.NUMCTADEB);

            /*" -5133- MOVE R3-DIGCTADEB OF REG-PROPOSTA-SASSE TO DIGCTADEB OF DCLPROPOSTA-FIDELIZ. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_CONTA_DEBITO.R3_DIGCTADEB, PROPFID.DCLPROPOSTA_FIDELIZ.DIGCTADEB);

            /*" -5136- MOVE R3-PCT-DESCONTO OF REG-PROPOSTA-SASSE TO PERC-DESCONTO OF DCLPROPOSTA-FIDELIZ. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_PCT_DESCONTO, PROPFID.DCLPROPOSTA_FIDELIZ.PERC_DESCONTO);

            /*" -5139- MOVE R3-NRMATRVEN OF REG-PROPOSTA-SASSE TO NRMATRVEN OF DCLPROPOSTA-FIDELIZ. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_NRMATRVEN, PROPFID.DCLPROPOSTA_FIDELIZ.NRMATRVEN);

            /*" -5145- MOVE ZEROS TO AGECTAVEN OF DCLPROPOSTA-FIDELIZ OPRCTAVEN OF DCLPROPOSTA-FIDELIZ NUMCTAVEN OF DCLPROPOSTA-FIDELIZ DIGCTAVEN OF DCLPROPOSTA-FIDELIZ. */
            _.Move(0, PROPFID.DCLPROPOSTA_FIDELIZ.AGECTAVEN, PROPFID.DCLPROPOSTA_FIDELIZ.OPRCTAVEN, PROPFID.DCLPROPOSTA_FIDELIZ.NUMCTAVEN, PROPFID.DCLPROPOSTA_FIDELIZ.DIGCTAVEN);

            /*" -5148- MOVE R3-CGC-CONVENENTE OF REG-PROPOSTA-SASSE TO CGC-CONVENENTE OF DCLPROPOSTA-FIDELIZ. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_CGC_CONVENENTE, PROPFID.DCLPROPOSTA_FIDELIZ.CGC_CONVENENTE);

            /*" -5151- MOVE R3-NOME-CONVENENTE OF REG-PROPOSTA-SASSE TO NOME-CONVENENTE OF DCLPROPOSTA-FIDELIZ. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_NOME_CONVENENTE, PROPFID.DCLPROPOSTA_FIDELIZ.NOME_CONVENENTE);

            /*" -5154- MOVE ZEROS TO NRMATRCON OF DCLPROPOSTA-FIDELIZ. */
            _.Move(0, PROPFID.DCLPROPOSTA_FIDELIZ.NRMATRCON);

            /*" -5157- MOVE R3-DTQITBCO OF REG-PROPOSTA-SASSE TO W-DATA-TRABALHO. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_DTQITBCO, WAREA_AUXILIAR.W_DATA_TRABALHO);

            /*" -5159- MOVE W-DIA-TRABALHO TO W-DIA-SQL OF W-DATA-SQL1. */
            _.Move(WAREA_AUXILIAR.FILLER_2.W_DIA_TRABALHO, WAREA_AUXILIAR.W_DATA_SQL1.W_DIA_SQL);

            /*" -5161- MOVE W-MES-TRABALHO TO W-MES-SQL OF W-DATA-SQL1. */
            _.Move(WAREA_AUXILIAR.FILLER_2.W_MES_TRABALHO, WAREA_AUXILIAR.W_DATA_SQL1.W_MES_SQL);

            /*" -5164- MOVE W-ANO-TRABALHO TO W-ANO-SQL OF W-DATA-SQL1. */
            _.Move(WAREA_AUXILIAR.FILLER_2.W_ANO_TRABALHO, WAREA_AUXILIAR.W_DATA_SQL1.W_ANO_SQL);

            /*" -5168- MOVE '-' TO W-BARRA1 OF W-DATA-SQL1, W-BARRA2 OF W-DATA-SQL1. */
            _.Move("-", WAREA_AUXILIAR.W_DATA_SQL1.W_BARRA1_1);
            _.Move("-", WAREA_AUXILIAR.W_DATA_SQL1.W_BARRA2_1);


            /*" -5171- MOVE W-DATA-SQL TO DTQITBCO OF DCLPROPOSTA-FIDELIZ. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL, PROPFID.DCLPROPOSTA_FIDELIZ.DTQITBCO);

            /*" -5174- MOVE R3-VAL-PAGO OF REG-PROPOSTA-SASSE TO VAL-PAGO OF DCLPROPOSTA-FIDELIZ. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_VAL_PAGO, PROPFID.DCLPROPOSTA_FIDELIZ.VAL_PAGO);

            /*" -5177- MOVE R3-AGEPGTO OF REG-PROPOSTA-SASSE TO AGEPGTO OF DCLPROPOSTA-FIDELIZ. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_AGEPGTO, PROPFID.DCLPROPOSTA_FIDELIZ.AGEPGTO);

            /*" -5180- MOVE R3-VAL-TARIFA OF REG-PROPOSTA-SASSE TO VAL-TARIFA OF DCLPROPOSTA-FIDELIZ. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_VAL_TARIFA, PROPFID.DCLPROPOSTA_FIDELIZ.VAL_TARIFA);

            /*" -5184- MOVE ZEROS TO VAL-IOF OF DCLPROPOSTA-FIDELIZ. */
            _.Move(0, PROPFID.DCLPROPOSTA_FIDELIZ.VAL_IOF);

            /*" -5187- MOVE R3-DATA-CREDITO OF REG-PROPOSTA-SASSE TO W-DATA-TRABALHO. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_DATA_CREDITO, WAREA_AUXILIAR.W_DATA_TRABALHO);

            /*" -5189- MOVE W-DIA-TRABALHO TO W-DIA-SQL OF W-DATA-SQL1. */
            _.Move(WAREA_AUXILIAR.FILLER_2.W_DIA_TRABALHO, WAREA_AUXILIAR.W_DATA_SQL1.W_DIA_SQL);

            /*" -5191- MOVE W-MES-TRABALHO TO W-MES-SQL OF W-DATA-SQL1. */
            _.Move(WAREA_AUXILIAR.FILLER_2.W_MES_TRABALHO, WAREA_AUXILIAR.W_DATA_SQL1.W_MES_SQL);

            /*" -5194- MOVE W-ANO-TRABALHO TO W-ANO-SQL OF W-DATA-SQL1. */
            _.Move(WAREA_AUXILIAR.FILLER_2.W_ANO_TRABALHO, WAREA_AUXILIAR.W_DATA_SQL1.W_ANO_SQL);

            /*" -5198- MOVE '-' TO W-BARRA1 OF W-DATA-SQL1, W-BARRA2 OF W-DATA-SQL1. */
            _.Move("-", WAREA_AUXILIAR.W_DATA_SQL1.W_BARRA1_1);
            _.Move("-", WAREA_AUXILIAR.W_DATA_SQL1.W_BARRA2_1);


            /*" -5201- MOVE W-DATA-SQL TO DATA-CREDITO OF DCLPROPOSTA-FIDELIZ. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL, PROPFID.DCLPROPOSTA_FIDELIZ.DATA_CREDITO);

            /*" -5204- MOVE R3-VAL-COMISSAO OF REG-PROPOSTA-SASSE TO VAL-COMISSAO OF DCLPROPOSTA-FIDELIZ. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_VAL_COMISSAO, PROPFID.DCLPROPOSTA_FIDELIZ.VAL_COMISSAO);

            /*" -5207- MOVE 'REJ' TO SIT-PROPOSTA OF DCLPROPOSTA-FIDELIZ. */
            _.Move("REJ", PROPFID.DCLPROPOSTA_FIDELIZ.SIT_PROPOSTA);

            /*" -5210- MOVE 'PF0619B' TO COD-USUARIO OF DCLPROPOSTA-FIDELIZ. */
            _.Move("PF0619B", PROPFID.DCLPROPOSTA_FIDELIZ.COD_USUARIO);

            /*" -5214- MOVE RH-NSAS OF REG-HEADER TO NSAS-SIVPF OF DCLPROPOSTA-FIDELIZ, NSAC-SIVPF OF DCLPROPOSTA-FIDELIZ. */
            _.Move(LXFPF990.REG_HEADER.RH_NSAS, PROPFID.DCLPROPOSTA_FIDELIZ.NSAS_SIVPF, PROPFID.DCLPROPOSTA_FIDELIZ.NSAC_SIVPF);

            /*" -5217- MOVE W-QTD-LD-TIPO-3 TO NSL OF DCLPROPOSTA-FIDELIZ. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_3, PROPFID.DCLPROPOSTA_FIDELIZ.NSL);

            /*" -5218- IF CANAL-VENDA-PAPEL */

            if (WAREA_AUXILIAR.CANAL_0.W_CANAL_PROPOSTA["CANAL_VENDA_PAPEL"])
            {

                /*" -5220- MOVE 2 TO CANAL-PROPOSTA OF DCLPROPOSTA-FIDELIZ */
                _.Move(2, PROPFID.DCLPROPOSTA_FIDELIZ.CANAL_PROPOSTA);

                /*" -5221- ELSE */
            }
            else
            {


                /*" -5227- MOVE W-CANAL-PROPOSTA TO CANAL-PROPOSTA OF DCLPROPOSTA-FIDELIZ. */
                _.Move(WAREA_AUXILIAR.CANAL_0.W_CANAL_PROPOSTA, PROPFID.DCLPROPOSTA_FIDELIZ.CANAL_PROPOSTA);
            }


            /*" -5228- IF COD-ORIGEM-PROPOSTA OF DCLPROPOSTAS-VA = 12 */

            if (PROPVA.DCLPROPOSTAS_VA.COD_ORIGEM_PROPOSTA == 12)
            {

                /*" -5230- MOVE 12 TO ORIGEM-PROPOSTA OF DCLPROPOSTA-FIDELIZ */
                _.Move(12, PROPFID.DCLPROPOSTA_FIDELIZ.ORIGEM_PROPOSTA);

                /*" -5231- ELSE */
            }
            else
            {


                /*" -5234- MOVE 6 TO ORIGEM-PROPOSTA OF DCLPROPOSTA-FIDELIZ. */
                _.Move(6, PROPFID.DCLPROPOSTA_FIDELIZ.ORIGEM_PROPOSTA);
            }


            /*" -5237- MOVE 'S' TO SITUACAO-ENVIO OF DCLPROPOSTA-FIDELIZ. */
            _.Move("S", PROPFID.DCLPROPOSTA_FIDELIZ.SITUACAO_ENVIO);

            /*" -5240- MOVE PESSOA-COD-PESSOA OF DCLPESSOA TO COD-PESSOA OF DCLPROPOSTA-FIDELIZ. */
            _.Move(PESSOA.DCLPESSOA.PESSOA_COD_PESSOA, PROPFID.DCLPROPOSTA_FIDELIZ.COD_PESSOA);

            /*" -5243- MOVE R3-OPCAO-COBER OF REG-PROPOSTA-SASSE TO OPCAO-COBER OF DCLPROPOSTA-FIDELIZ. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_OPCAO_COBER, PROPFID.DCLPROPOSTA_FIDELIZ.OPCAO_COBER);

            /*" -5247- MOVE R3-COD-PLANO OF REG-PROPOSTA-SASSE TO COD-PLANO OF DCLPROPOSTA-FIDELIZ. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_COD_PLANO, PROPFID.DCLPROPOSTA_FIDELIZ.COD_PLANO);

            /*" -5251- MOVE R1-NOME-CONJUGE OF REG-CLIENTES TO NOME-CONJUGE OF DCLPROPOSTA-FIDELIZ. */
            _.Move(LBFPF011.REG_CLIENTES.R1_NOME_CONJUGE, PROPFID.DCLPROPOSTA_FIDELIZ.NOME_CONJUGE);

            /*" -5254- MOVE R1-DTNASC-CONJUGE OF REG-CLIENTES TO W-DATA-TRABALHO. */
            _.Move(LBFPF011.REG_CLIENTES.R1_DTNASC_CONJUGE, WAREA_AUXILIAR.W_DATA_TRABALHO);

            /*" -5256- MOVE W-DIA-TRABALHO TO W-DIA-SQL OF W-DATA-SQL1. */
            _.Move(WAREA_AUXILIAR.FILLER_2.W_DIA_TRABALHO, WAREA_AUXILIAR.W_DATA_SQL1.W_DIA_SQL);

            /*" -5258- MOVE W-MES-TRABALHO TO W-MES-SQL OF W-DATA-SQL1. */
            _.Move(WAREA_AUXILIAR.FILLER_2.W_MES_TRABALHO, WAREA_AUXILIAR.W_DATA_SQL1.W_MES_SQL);

            /*" -5261- MOVE W-ANO-TRABALHO TO W-ANO-SQL OF W-DATA-SQL1. */
            _.Move(WAREA_AUXILIAR.FILLER_2.W_ANO_TRABALHO, WAREA_AUXILIAR.W_DATA_SQL1.W_ANO_SQL);

            /*" -5265- MOVE '-' TO W-BARRA1 OF W-DATA-SQL1, W-BARRA2 OF W-DATA-SQL1. */
            _.Move("-", WAREA_AUXILIAR.W_DATA_SQL1.W_BARRA1_1);
            _.Move("-", WAREA_AUXILIAR.W_DATA_SQL1.W_BARRA2_1);


            /*" -5268- MOVE W-DATA-SQL TO DATA-NASC-CONJUGE OF DCLPROPOSTA-FIDELIZ. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL, PROPFID.DCLPROPOSTA_FIDELIZ.DATA_NASC_CONJUGE);

            /*" -5271- MOVE R1-CBO-CONJUGE OF REG-CLIENTES TO PROFISSAO-CONJUGE OF DCLPROPOSTA-FIDELIZ. */
            _.Move(LBFPF011.REG_CLIENTES.R1_CBO_CONJUGE, PROPFID.DCLPROPOSTA_FIDELIZ.PROFISSAO_CONJUGE);

            /*" -5274- MOVE 'N' TO IND-TIPO-CONTA OF DCLPROPOSTA-FIDELIZ. */
            _.Move("N", PROPFID.DCLPROPOSTA_FIDELIZ.IND_TIPO_CONTA);

            /*" -5275- ACCEPT WS-HORA-INI FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_INI);

            /*" -5278- COMPUTE SIT = (HI * 60 * 60) + (MI * 60) + SI + (DI / 100) */
            WS_HORAS.SIT.Value = (WS_HORAS.WS_HORA_INI_R.HI * 60 * 60) + (WS_HORAS.WS_HORA_INI_R.MI * 60) + WS_HORAS.WS_HORA_INI_R.SI + (WS_HORAS.WS_HORA_INI_R.DI / 100f);

            /*" -5380- PERFORM R3360_TRATA_PROP_FIDELIZACAO_DB_INSERT_1 */

            R3360_TRATA_PROP_FIDELIZACAO_DB_INSERT_1();

            /*" -5384- ACCEPT WS-HORA-FIM FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_FIM);

            /*" -5385- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF + (DF / 100) */
            WS_HORAS.SFT.Value = (WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (WS_HORAS.WS_HORA_FIM_R.MF * 60) + WS_HORAS.WS_HORA_FIM_R.SF + (WS_HORAS.WS_HORA_FIM_R.DF / 100f);

            /*" -5386- SUBTRACT SIT FROM SFT */
            WS_HORAS.SFT.Value = WS_HORAS.SFT - WS_HORAS.SIT;

            /*" -5387- ADD SFT TO STT(50) */
            TOTAIS_ROT.FILLER_20[50].STT.Value = TOTAIS_ROT.FILLER_20[50].STT + WS_HORAS.SFT;

            /*" -5391- ADD 1 TO SQT(50) */
            TOTAIS_ROT.FILLER_20[50].SQT.Value = TOTAIS_ROT.FILLER_20[50].SQT + 1;

            /*" -5392- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -5393- IF SQLCODE EQUAL -803 */

                if (DB.SQLCODE == -803)
                {

                    /*" -5394- MOVE 1 TO W-TEM-TABPROPFID */
                    _.Move(1, WAREA_AUXILIAR.W_TEM_TABPROPFID);

                    /*" -5396- DISPLAY 'PF0619B  PROPOSTA JA EXISTE PROPFID... ' NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ */
                    _.Display($"PF0619B  PROPOSTA JA EXISTE PROPFID... {PROPFID.DCLPROPOSTA_FIDELIZ.NUM_PROPOSTA_SIVPF}");

                    /*" -5397- ELSE */
                }
                else
                {


                    /*" -5398- DISPLAY 'PF0619B - FIM ANORMAL' */
                    _.Display($"PF0619B - FIM ANORMAL");

                    /*" -5399- DISPLAY '          ERRO INSERT TABELA PROPOSTA FIDELIZ' */
                    _.Display($"          ERRO INSERT TABELA PROPOSTA FIDELIZ");

                    /*" -5401- DISPLAY '          CODIGO PESSOA.................  ' COD-PESSOA OF DCLPROPOSTA-FIDELIZ */
                    _.Display($"          CODIGO PESSOA.................  {PROPFID.DCLPROPOSTA_FIDELIZ.COD_PESSOA}");

                    /*" -5403- DISPLAY '          NUMERO PROPOSTA...............  ' NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ */
                    _.Display($"          NUMERO PROPOSTA...............  {PROPFID.DCLPROPOSTA_FIDELIZ.NUM_PROPOSTA_SIVPF}");

                    /*" -5405- DISPLAY '          COD-EMPRESA...................  ' COD-EMPRESA-SIVPF OF DCLPROPOSTA-FIDELIZ */
                    _.Display($"          COD-EMPRESA...................  {PROPFID.DCLPROPOSTA_FIDELIZ.COD_EMPRESA_SIVPF}");

                    /*" -5407- DISPLAY '          COD-PRODUTO-SIVPF.............  ' COD-PRODUTO-SIVPF OF DCLPROPOSTA-FIDELIZ */
                    _.Display($"          COD-PRODUTO-SIVPF.............  {PROPFID.DCLPROPOSTA_FIDELIZ.COD_PRODUTO_SIVPF}");

                    /*" -5409- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                    _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                    /*" -5410- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -5410- PERFORM R9999-00-FINALIZAR. */

                    R9999_00_FINALIZAR_SECTION();
                }

            }


        }

        [StopWatch]
        /*" R3360-TRATA-PROP-FIDELIZACAO-DB-INSERT-1 */
        public void R3360_TRATA_PROP_FIDELIZACAO_DB_INSERT_1()
        {
            /*" -5380- EXEC SQL INSERT INTO SEGUROS.PROPOSTA_FIDELIZ ( NUM_PROPOSTA_SIVPF ,NUM_IDENTIFICACAO ,COD_EMPRESA_SIVPF ,COD_PESSOA ,NUM_SICOB ,DATA_PROPOSTA ,COD_PRODUTO_SIVPF ,AGECOBR ,DIA_DEBITO ,OPCAOPAG ,AGECTADEB ,OPRCTADEB ,NUMCTADEB ,DIGCTADEB ,PERC_DESCONTO ,NRMATRVEN ,AGECTAVEN ,OPRCTAVEN ,NUMCTAVEN ,DIGCTAVEN ,CGC_CONVENENTE ,NOME_CONVENENTE ,NRMATRCON ,DTQITBCO ,VAL_PAGO ,AGEPGTO ,VAL_TARIFA ,VAL_IOF ,DATA_CREDITO ,VAL_COMISSAO ,SIT_PROPOSTA ,COD_USUARIO ,CANAL_PROPOSTA ,NSAS_SIVPF ,ORIGEM_PROPOSTA ,TIMESTAMP ,NSL ,NSAC_SIVPF ,SITUACAO_ENVIO ,OPCAO_COBER ,COD_PLANO ,NOME_CONJUGE ,DATA_NASC_CONJUGE ,PROFISSAO_CONJUGE ,FAIXA_RENDA_IND ,FAIXA_RENDA_FAM ,IND_TP_PROPOSTA ,IND_TIPO_CONTA ) VALUES (:DCLPROPOSTA-FIDELIZ.NUM-PROPOSTA-SIVPF, :DCLPROPOSTA-FIDELIZ.NUM-IDENTIFICACAO, :DCLPROPOSTA-FIDELIZ.COD-EMPRESA-SIVPF, :DCLPROPOSTA-FIDELIZ.COD-PESSOA, :DCLPROPOSTA-FIDELIZ.NUM-SICOB, :DCLPROPOSTA-FIDELIZ.DATA-PROPOSTA, :DCLPROPOSTA-FIDELIZ.COD-PRODUTO-SIVPF, :DCLPROPOSTA-FIDELIZ.AGECOBR, :DCLPROPOSTA-FIDELIZ.DIA-DEBITO, :DCLPROPOSTA-FIDELIZ.OPCAOPAG, :DCLPROPOSTA-FIDELIZ.AGECTADEB, :DCLPROPOSTA-FIDELIZ.OPRCTADEB, :DCLPROPOSTA-FIDELIZ.NUMCTADEB, :DCLPROPOSTA-FIDELIZ.DIGCTADEB, :DCLPROPOSTA-FIDELIZ.PERC-DESCONTO, :DCLPROPOSTA-FIDELIZ.NRMATRVEN, :DCLPROPOSTA-FIDELIZ.AGECTAVEN, :DCLPROPOSTA-FIDELIZ.OPRCTAVEN, :DCLPROPOSTA-FIDELIZ.NUMCTAVEN, :DCLPROPOSTA-FIDELIZ.DIGCTAVEN, :DCLPROPOSTA-FIDELIZ.CGC-CONVENENTE, :DCLPROPOSTA-FIDELIZ.NOME-CONVENENTE, :DCLPROPOSTA-FIDELIZ.NRMATRCON, :DCLPROPOSTA-FIDELIZ.DTQITBCO, :DCLPROPOSTA-FIDELIZ.VAL-PAGO, :DCLPROPOSTA-FIDELIZ.AGEPGTO, :DCLPROPOSTA-FIDELIZ.VAL-TARIFA, :DCLPROPOSTA-FIDELIZ.VAL-IOF, :DCLPROPOSTA-FIDELIZ.DATA-CREDITO, :DCLPROPOSTA-FIDELIZ.VAL-COMISSAO, :DCLPROPOSTA-FIDELIZ.SIT-PROPOSTA, :DCLPROPOSTA-FIDELIZ.COD-USUARIO, :DCLPROPOSTA-FIDELIZ.CANAL-PROPOSTA, :DCLPROPOSTA-FIDELIZ.NSAS-SIVPF, :DCLPROPOSTA-FIDELIZ.ORIGEM-PROPOSTA, CURRENT TIMESTAMP, :DCLPROPOSTA-FIDELIZ.NSL, :DCLPROPOSTA-FIDELIZ.NSAC-SIVPF, :DCLPROPOSTA-FIDELIZ.SITUACAO-ENVIO, :DCLPROPOSTA-FIDELIZ.OPCAO-COBER, :DCLPROPOSTA-FIDELIZ.COD-PLANO, :DCLPROPOSTA-FIDELIZ.NOME-CONJUGE, :DCLPROPOSTA-FIDELIZ.DATA-NASC-CONJUGE:VIND-DTNASC-ESPOSA, :DCLPROPOSTA-FIDELIZ.PROFISSAO-CONJUGE, :DCLPROPOSTAS-VA.FAIXA-RENDA-IND :VIND-FAIXA-RENDA-IND, :DCLPROPOSTAS-VA.FAIXA-RENDA-FAM :VIND-FAIXA-RENDA-FAM, NULL, :DCLPROPOSTA-FIDELIZ.IND-TIPO-CONTA) END-EXEC. */

            var r3360_TRATA_PROP_FIDELIZACAO_DB_INSERT_1_Insert1 = new R3360_TRATA_PROP_FIDELIZACAO_DB_INSERT_1_Insert1()
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
                FAIXA_RENDA_IND = PROPVA.DCLPROPOSTAS_VA.FAIXA_RENDA_IND.ToString(),
                VIND_FAIXA_RENDA_IND = VIND_FAIXA_RENDA_IND.ToString(),
                FAIXA_RENDA_FAM = PROPVA.DCLPROPOSTAS_VA.FAIXA_RENDA_FAM.ToString(),
                VIND_FAIXA_RENDA_FAM = VIND_FAIXA_RENDA_FAM.ToString(),
                IND_TIPO_CONTA = PROPFID.DCLPROPOSTA_FIDELIZ.IND_TIPO_CONTA.ToString(),
            };

            R3360_TRATA_PROP_FIDELIZACAO_DB_INSERT_1_Insert1.Execute(r3360_TRATA_PROP_FIDELIZACAO_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3360_SAIDA*/

        [StopWatch]
        /*" R3365-TRATA-PROP-ESPECIFICA-SECTION */
        private void R3365_TRATA_PROP_ESPECIFICA_SECTION()
        {
            /*" -5419- MOVE 'R3365-TRATA-PROP-ESPECIFICA' TO PARAGRAFO. */
            _.Move("R3365-TRATA-PROP-ESPECIFICA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5422- MOVE W-COD-RELACION TO W-RELACIONAMENTO. */
            _.Move(WAREA_AUXILIAR.W_COD_RELACION, WAREA_AUXILIAR.W_RELACIONAMENTO);

            /*" -5424- MOVE 'INSERT PROPOSTA-SASSE' TO COMANDO. */
            _.Move("INSERT PROPOSTA-SASSE", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5427- MOVE NUM-IDENTIFICACAO OF DCLPROPOSTA-FIDELIZ TO PROPSSVD-NUM-IDENTIFICACAO OF DCLPROP-SASSE-VIDA. */
            _.Move(PROPFID.DCLPROPOSTA_FIDELIZ.NUM_IDENTIFICACAO, PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_IDENTIFICACAO);

            /*" -5430- MOVE R3-DPS-TITULAR OF REG-PROPOSTA-SASSE TO PROPSSVD-DPS-TITULAR OF DCLPROP-SASSE-VIDA. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_DPS_TITULAR, PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_DPS_TITULAR);

            /*" -5433- MOVE R3-DPS-CONJUGE OF REG-PROPOSTA-SASSE TO PROPSSVD-DPS-CONJUGE OF DCLPROP-SASSE-VIDA. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_DPS_CONJUGE, PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_DPS_CONJUGE);

            /*" -5436- MOVE R3-APOS-INVALIDEZ OF REG-PROPOSTA-SASSE TO PROPSSVD-APOS-INVALIDEZ OF DCLPROP-SASSE-VIDA. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_APOS_INVALIDEZ, PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_APOS_INVALIDEZ);

            /*" -5441- MOVE 'PF0619B' TO PROPSSVD-COD-USUARIO OF DCLPROP-SASSE-VIDA. */
            _.Move("PF0619B", PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_COD_USUARIO);

            /*" -5445- MOVE NUM-APOLICE OF DCLPROPOSTAS-VA TO PROPSSVD-NUM-APOLICE OF DCLPROP-SASSE-VIDA NUM-APOLICE OF DCLPRODUTOS-VG */
            _.Move(PROPVA.DCLPROPOSTAS_VA.NUM_APOLICE, PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_APOLICE, PRODVG.DCLPRODUTOS_VG.NUM_APOLICE);

            /*" -5450- MOVE COD-SUBGRUPO OF DCLPROPOSTAS-VA TO PROPSSVD-COD-SUBGRUPO OF DCLPROP-SASSE-VIDA COD-SUBGRUPO OF DCLPRODUTOS-VG. */
            _.Move(PROPVA.DCLPROPOSTAS_VA.COD_SUBGRUPO, PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_COD_SUBGRUPO, PRODVG.DCLPRODUTOS_VG.COD_SUBGRUPO);

            /*" -5451- ACCEPT WS-HORA-INI FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_INI);

            /*" -5454- COMPUTE SIT = (HI * 60 * 60) + (MI * 60) + SI + (DI / 100) */
            WS_HORAS.SIT.Value = (WS_HORAS.WS_HORA_INI_R.HI * 60 * 60) + (WS_HORAS.WS_HORA_INI_R.MI * 60) + WS_HORAS.WS_HORA_INI_R.SI + (WS_HORAS.WS_HORA_INI_R.DI / 100f);

            /*" -5468- PERFORM R3365_TRATA_PROP_ESPECIFICA_DB_INSERT_1 */

            R3365_TRATA_PROP_ESPECIFICA_DB_INSERT_1();

            /*" -5472- ACCEPT WS-HORA-FIM FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_FIM);

            /*" -5473- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF + (DF / 100) */
            WS_HORAS.SFT.Value = (WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (WS_HORAS.WS_HORA_FIM_R.MF * 60) + WS_HORAS.WS_HORA_FIM_R.SF + (WS_HORAS.WS_HORA_FIM_R.DF / 100f);

            /*" -5474- SUBTRACT SIT FROM SFT */
            WS_HORAS.SFT.Value = WS_HORAS.SFT - WS_HORAS.SIT;

            /*" -5475- ADD SFT TO STT(51) */
            TOTAIS_ROT.FILLER_20[51].STT.Value = TOTAIS_ROT.FILLER_20[51].STT + WS_HORAS.SFT;

            /*" -5478- ADD 1 TO SQT(51) */
            TOTAIS_ROT.FILLER_20[51].SQT.Value = TOTAIS_ROT.FILLER_20[51].SQT + 1;

            /*" -5480- IF SQLCODE NOT EQUAL 00 AND SQLCODE NOT EQUAL -803 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != -803)
            {

                /*" -5481- DISPLAY 'PF0619B - FIM ANORMAL' */
                _.Display($"PF0619B - FIM ANORMAL");

                /*" -5482- DISPLAY '          ERRO INSERT TAB. PROPOSTA SASSE VIDA' */
                _.Display($"          ERRO INSERT TAB. PROPOSTA SASSE VIDA");

                /*" -5484- DISPLAY '          CODIGO PESSOA.................  ' COD-PESSOA OF DCLIDENTIFICA-RELAC */
                _.Display($"          CODIGO PESSOA.................  {IDERELAC.DCLIDENTIFICA_RELAC.COD_PESSOA}");

                /*" -5486- DISPLAY '          NUMERO PROPOSTA...............  ' NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ */
                _.Display($"          NUMERO PROPOSTA...............  {PROPFID.DCLPROPOSTA_FIDELIZ.NUM_PROPOSTA_SIVPF}");

                /*" -5488- DISPLAY '          NUMERO IDENTIFICACAO..........  ' PROPSSVD-NUM-IDENTIFICACAO OF DCLPROP-SASSE-VIDA */
                _.Display($"          NUMERO IDENTIFICACAO..........  {PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_IDENTIFICACAO}");

                /*" -5490- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -5491- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -5491- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R3365-TRATA-PROP-ESPECIFICA-DB-INSERT-1 */
        public void R3365_TRATA_PROP_ESPECIFICA_DB_INSERT_1()
        {
            /*" -5468- EXEC SQL INSERT INTO SEGUROS.PROP_SASSE_VIDA VALUES (:DCLPROP-SASSE-VIDA.PROPSSVD-NUM-IDENTIFICACAO, :DCLPROP-SASSE-VIDA.PROPSSVD-DPS-TITULAR, :DCLPROP-SASSE-VIDA.PROPSSVD-DPS-CONJUGE, :DCLPROP-SASSE-VIDA.PROPSSVD-APOS-INVALIDEZ, :DCLPROP-SASSE-VIDA.PROPSSVD-COD-USUARIO, :DCLPROP-SASSE-VIDA.PROPSSVD-NUM-APOLICE, :DCLPROP-SASSE-VIDA.PROPSSVD-COD-SUBGRUPO, CURRENT TIMESTAMP, NULL, NULL, NULL, NULL) END-EXEC. */

            var r3365_TRATA_PROP_ESPECIFICA_DB_INSERT_1_Insert1 = new R3365_TRATA_PROP_ESPECIFICA_DB_INSERT_1_Insert1()
            {
                PROPSSVD_NUM_IDENTIFICACAO = PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_IDENTIFICACAO.ToString(),
                PROPSSVD_DPS_TITULAR = PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_DPS_TITULAR.ToString(),
                PROPSSVD_DPS_CONJUGE = PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_DPS_CONJUGE.ToString(),
                PROPSSVD_APOS_INVALIDEZ = PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_APOS_INVALIDEZ.ToString(),
                PROPSSVD_COD_USUARIO = PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_COD_USUARIO.ToString(),
                PROPSSVD_NUM_APOLICE = PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_APOLICE.ToString(),
                PROPSSVD_COD_SUBGRUPO = PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_COD_SUBGRUPO.ToString(),
            };

            R3365_TRATA_PROP_ESPECIFICA_DB_INSERT_1_Insert1.Execute(r3365_TRATA_PROP_ESPECIFICA_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3365_SAIDA*/

        [StopWatch]
        /*" R3390-GERA-HIST-FIDELIZACAO-SECTION */
        private void R3390_GERA_HIST_FIDELIZACAO_SECTION()
        {
            /*" -5600- MOVE 'R3390-GERA-HIST-FIDELIZACAO' TO PARAGRAFO. */
            _.Move("R3390-GERA-HIST-FIDELIZACAO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5602- MOVE 'INSERT HIST-PROP-FIDELIZ' TO COMANDO. */
            _.Move("INSERT HIST-PROP-FIDELIZ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5605- MOVE NUM-IDENTIFICACAO OF DCLPROPOSTA-FIDELIZ TO PROPFIDH-NUM-IDENTIFICACAO */
            _.Move(PROPFID.DCLPROPOSTA_FIDELIZ.NUM_IDENTIFICACAO, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NUM_IDENTIFICACAO);

            /*" -5608- MOVE DTQITBCO OF DCLPROPOSTA-FIDELIZ TO PROPFIDH-DATA-SITUACAO. */
            _.Move(PROPFID.DCLPROPOSTA_FIDELIZ.DTQITBCO, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_DATA_SITUACAO);

            /*" -5611- MOVE RH-NSAS OF REG-HEADER TO PROPFIDH-NSAS-SIVPF. */
            _.Move(LXFPF990.REG_HEADER.RH_NSAS, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NSAS_SIVPF);

            /*" -5614- MOVE W-QTD-LD-TIPO-3 TO PROPFIDH-NSL. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_3, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NSL);

            /*" -5617- MOVE 'MAN' TO PROPFIDH-SIT-PROPOSTA */
            _.Move("MAN", PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_PROPOSTA);

            /*" -5620- MOVE R3-SIT-COBRANCA OF REG-PROPOSTA-SASSE TO PROPFIDH-SIT-COBRANCA-SIVPF */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_SIT_COBRANCA, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_COBRANCA_SIVPF);

            /*" -5622- MOVE 229 TO PROPFIDH-SIT-MOTIVO-SIVPF. */
            _.Move(229, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_MOTIVO_SIVPF);

            /*" -5625- MOVE COD-EMPRESA-SIVPF OF DCLPROPOSTA-FIDELIZ TO PROPFIDH-COD-EMPRESA-SIVPF. */
            _.Move(PROPFID.DCLPROPOSTA_FIDELIZ.COD_EMPRESA_SIVPF, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_COD_EMPRESA_SIVPF);

            /*" -5629- MOVE COD-PRODUTO-SIVPF OF DCLPROPOSTA-FIDELIZ TO PROPFIDH-COD-PRODUTO-SIVPF. */
            _.Move(PROPFID.DCLPROPOSTA_FIDELIZ.COD_PRODUTO_SIVPF, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_COD_PRODUTO_SIVPF);

            /*" -5630- ACCEPT WS-HORA-INI FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_INI);

            /*" -5633- COMPUTE SIT = (HI * 60 * 60) + (MI * 60) + SI + (DI / 100) */
            WS_HORAS.SIT.Value = (WS_HORAS.WS_HORA_INI_R.HI * 60 * 60) + (WS_HORAS.WS_HORA_INI_R.MI * 60) + WS_HORAS.WS_HORA_INI_R.SI + (WS_HORAS.WS_HORA_INI_R.DI / 100f);

            /*" -5644- PERFORM R3390_GERA_HIST_FIDELIZACAO_DB_INSERT_1 */

            R3390_GERA_HIST_FIDELIZACAO_DB_INSERT_1();

            /*" -5648- ACCEPT WS-HORA-FIM FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_FIM);

            /*" -5649- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF + (DF / 100) */
            WS_HORAS.SFT.Value = (WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (WS_HORAS.WS_HORA_FIM_R.MF * 60) + WS_HORAS.WS_HORA_FIM_R.SF + (WS_HORAS.WS_HORA_FIM_R.DF / 100f);

            /*" -5650- SUBTRACT SIT FROM SFT */
            WS_HORAS.SFT.Value = WS_HORAS.SFT - WS_HORAS.SIT;

            /*" -5651- ADD SFT TO STT(53) */
            TOTAIS_ROT.FILLER_20[53].STT.Value = TOTAIS_ROT.FILLER_20[53].STT + WS_HORAS.SFT;

            /*" -5654- ADD 1 TO SQT(53) */
            TOTAIS_ROT.FILLER_20[53].SQT.Value = TOTAIS_ROT.FILLER_20[53].SQT + 1;

            /*" -5656- IF SQLCODE NOT EQUAL 00 AND SQLCODE NOT EQUAL -803 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != -803)
            {

                /*" -5657- DISPLAY 'PF0619B - FIM ANORMAL' */
                _.Display($"PF0619B - FIM ANORMAL");

                /*" -5658- DISPLAY '          ERRO INSERT TABELA HIST-PROP-FIDELIZ' */
                _.Display($"          ERRO INSERT TABELA HIST-PROP-FIDELIZ");

                /*" -5660- DISPLAY '          CODIGO PESSOA.................  ' COD-PESSOA OF DCLIDENTIFICA-RELAC */
                _.Display($"          CODIGO PESSOA.................  {IDERELAC.DCLIDENTIFICA_RELAC.COD_PESSOA}");

                /*" -5662- DISPLAY '          NUMERO PROPOSTA...............  ' R3-NUM-PROPOSTA OF REG-PROPOSTA-SASSE */
                _.Display($"          NUMERO PROPOSTA...............  {LXFCT004.REG_PROPOSTA_SASSE.R3_NUM_PROPOSTA}");

                /*" -5664- DISPLAY '          NUMERO IDENTIFICACAO..........  ' PROPSSVD-NUM-IDENTIFICACAO OF DCLPROP-SASSE-VIDA */
                _.Display($"          NUMERO IDENTIFICACAO..........  {PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_IDENTIFICACAO}");

                /*" -5666- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -5667- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -5667- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R3390-GERA-HIST-FIDELIZACAO-DB-INSERT-1 */
        public void R3390_GERA_HIST_FIDELIZACAO_DB_INSERT_1()
        {
            /*" -5644- EXEC SQL INSERT INTO SEGUROS.HIST_PROP_FIDELIZ VALUES ( :PROPFIDH-NUM-IDENTIFICACAO , :PROPFIDH-DATA-SITUACAO , :PROPFIDH-NSAS-SIVPF , :PROPFIDH-NSL , :PROPFIDH-SIT-PROPOSTA , :PROPFIDH-SIT-COBRANCA-SIVPF , :PROPFIDH-SIT-MOTIVO-SIVPF , :PROPFIDH-COD-EMPRESA-SIVPF , :PROPFIDH-COD-PRODUTO-SIVPF) END-EXEC. */

            var r3390_GERA_HIST_FIDELIZACAO_DB_INSERT_1_Insert1 = new R3390_GERA_HIST_FIDELIZACAO_DB_INSERT_1_Insert1()
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

            R3390_GERA_HIST_FIDELIZACAO_DB_INSERT_1_Insert1.Execute(r3390_GERA_HIST_FIDELIZACAO_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3390_SAIDA*/

        [StopWatch]
        /*" R3391-OBTER-NUM-SICOB-SECTION */
        private void R3391_OBTER_NUM_SICOB_SECTION()
        {
            /*" -5677- MOVE 'R3391-OBTER-NUM-SICOB' TO PARAGRAFO. */
            _.Move("R3391-OBTER-NUM-SICOB", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5679- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5681- MOVE SPACES TO W-ACHOU-SICOB. */
            _.Move("", WAREA_AUXILIAR.W_ACHOU_SICOB);

            /*" -5684- MOVE R3-NUM-PROPOSTA OF REG-PROPOSTA-SASSE TO NUM-PROPOSTA-SIVPF OF DCLCONVERSAO-SICOB. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_NUM_PROPOSTA, COVSICOB.DCLCONVERSAO_SICOB.NUM_PROPOSTA_SIVPF);

            /*" -5686- PERFORM R3392-ACESSAR-CONVERSAO-SICOB. */

            R3392_ACESSAR_CONVERSAO_SICOB_SECTION();

            /*" -5687- IF W-ACHOU-SICOB EQUAL 'SIM' */

            if (WAREA_AUXILIAR.W_ACHOU_SICOB == "SIM")
            {

                /*" -5689- MOVE NUM-SICOB OF DCLCONVERSAO-SICOB TO NUM-SICOB OF DCLPROPOSTA-FIDELIZ */
                _.Move(COVSICOB.DCLCONVERSAO_SICOB.NUM_SICOB, PROPFID.DCLPROPOSTA_FIDELIZ.NUM_SICOB);

                /*" -5690- ELSE */
            }
            else
            {


                /*" -5691- IF SASSE */

                if (WAREA_AUXILIAR.W_COD_EMPRESA["SASSE"])
                {

                    /*" -5692- DISPLAY '******************************************' */
                    _.Display($"******************************************");

                    /*" -5693- DISPLAY '* PROPOSTA SASSE NAO NUMERADA.            ' */
                    _.Display($"* PROPOSTA SASSE NAO NUMERADA.            ");

                    /*" -5695- DISPLAY '* PROPOSTA :  ' NUM-PROPOSTA-SIVPF OF DCLCONVERSAO-SICOB */
                    _.Display($"* PROPOSTA :  {COVSICOB.DCLCONVERSAO_SICOB.NUM_PROPOSTA_SIVPF}");

                    /*" -5696- DISPLAY '******************************************' */
                    _.Display($"******************************************");

                    /*" -5697- GO TO R9999-00-FINALIZAR */

                    R9999_00_FINALIZAR_SECTION(); //GOTO
                    return;

                    /*" -5698- ELSE */
                }
                else
                {


                    /*" -5699- PERFORM R3393-NUMERAR-SICOB */

                    R3393_NUMERAR_SICOB_SECTION();

                    /*" -5700- PERFORM R3394-GERA-DE-PARA-NR-SICOB */

                    R3394_GERA_DE_PARA_NR_SICOB_SECTION();

                    /*" -5701- MOVE NUM-SICOB OF DCLCONVERSAO-SICOB TO NUM-SICOB OF DCLPROPOSTA-FIDELIZ. */
                    _.Move(COVSICOB.DCLCONVERSAO_SICOB.NUM_SICOB, PROPFID.DCLPROPOSTA_FIDELIZ.NUM_SICOB);
                }

            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3391_SAIDA*/

        [StopWatch]
        /*" R3392-ACESSAR-CONVERSAO-SICOB-SECTION */
        private void R3392_ACESSAR_CONVERSAO_SICOB_SECTION()
        {
            /*" -5711- MOVE 'R3392-ACESSAR-CONVERSAO-SICOB' TO PARAGRAFO. */
            _.Move("R3392-ACESSAR-CONVERSAO-SICOB", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5714- MOVE 'SELECT CONVERSAO-SICOB' TO COMANDO. */
            _.Move("SELECT CONVERSAO-SICOB", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5715- ACCEPT WS-HORA-INI FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_INI);

            /*" -5718- COMPUTE SIT = (HI * 60 * 60) + (MI * 60) + SI + (DI / 100) */
            WS_HORAS.SIT.Value = (WS_HORAS.WS_HORA_INI_R.HI * 60 * 60) + (WS_HORAS.WS_HORA_INI_R.MI * 60) + WS_HORAS.WS_HORA_INI_R.SI + (WS_HORAS.WS_HORA_INI_R.DI / 100f);

            /*" -5725- PERFORM R3392_ACESSAR_CONVERSAO_SICOB_DB_SELECT_1 */

            R3392_ACESSAR_CONVERSAO_SICOB_DB_SELECT_1();

            /*" -5729- ACCEPT WS-HORA-FIM FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_FIM);

            /*" -5730- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF + (DF / 100) */
            WS_HORAS.SFT.Value = (WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (WS_HORAS.WS_HORA_FIM_R.MF * 60) + WS_HORAS.WS_HORA_FIM_R.SF + (WS_HORAS.WS_HORA_FIM_R.DF / 100f);

            /*" -5731- SUBTRACT SIT FROM SFT */
            WS_HORAS.SFT.Value = WS_HORAS.SFT - WS_HORAS.SIT;

            /*" -5732- ADD SFT TO STT(54) */
            TOTAIS_ROT.FILLER_20[54].STT.Value = TOTAIS_ROT.FILLER_20[54].STT + WS_HORAS.SFT;

            /*" -5735- ADD 1 TO SQT(54) */
            TOTAIS_ROT.FILLER_20[54].SQT.Value = TOTAIS_ROT.FILLER_20[54].SQT + 1;

            /*" -5736- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -5737- IF SQLCODE NOT EQUAL 100 */

                if (DB.SQLCODE != 100)
                {

                    /*" -5738- DISPLAY 'PF0619B FIM ANORMAL' */
                    _.Display($"PF0619B FIM ANORMAL");

                    /*" -5739- DISPLAY '        ERRO SELECT TAB. CONVERSAO-SICOB' */
                    _.Display($"        ERRO SELECT TAB. CONVERSAO-SICOB");

                    /*" -5741- DISPLAY '        NUM DA PROPOSTA .... ' NUM-PROPOSTA-SIVPF OF DCLCONVERSAO-SICOB */
                    _.Display($"        NUM DA PROPOSTA .... {COVSICOB.DCLCONVERSAO_SICOB.NUM_PROPOSTA_SIVPF}");

                    /*" -5742- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -5744- PERFORM R9999-00-FINALIZAR. */

                    R9999_00_FINALIZAR_SECTION();
                }

            }


            /*" -5745- IF SQLCODE EQUAL 00 */

            if (DB.SQLCODE == 00)
            {

                /*" -5746- MOVE 'SIM' TO W-ACHOU-SICOB */
                _.Move("SIM", WAREA_AUXILIAR.W_ACHOU_SICOB);

                /*" -5747- ELSE */
            }
            else
            {


                /*" -5747- MOVE 'NAO' TO W-ACHOU-SICOB. */
                _.Move("NAO", WAREA_AUXILIAR.W_ACHOU_SICOB);
            }


        }

        [StopWatch]
        /*" R3392-ACESSAR-CONVERSAO-SICOB-DB-SELECT-1 */
        public void R3392_ACESSAR_CONVERSAO_SICOB_DB_SELECT_1()
        {
            /*" -5725- EXEC SQL SELECT NUM_SICOB INTO :DCLCONVERSAO-SICOB.NUM-SICOB FROM SEGUROS.CONVERSAO_SICOB WHERE NUM_PROPOSTA_SIVPF = :DCLCONVERSAO-SICOB.NUM-PROPOSTA-SIVPF WITH UR END-EXEC. */

            var r3392_ACESSAR_CONVERSAO_SICOB_DB_SELECT_1_Query1 = new R3392_ACESSAR_CONVERSAO_SICOB_DB_SELECT_1_Query1()
            {
                NUM_PROPOSTA_SIVPF = COVSICOB.DCLCONVERSAO_SICOB.NUM_PROPOSTA_SIVPF.ToString(),
            };

            var executed_1 = R3392_ACESSAR_CONVERSAO_SICOB_DB_SELECT_1_Query1.Execute(r3392_ACESSAR_CONVERSAO_SICOB_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.NUM_SICOB, COVSICOB.DCLCONVERSAO_SICOB.NUM_SICOB);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3392_SAIDA*/

        [StopWatch]
        /*" R3393-NUMERAR-SICOB-SECTION */
        private void R3393_NUMERAR_SICOB_SECTION()
        {
            /*" -5757- MOVE 'R3393-NUMERAR-SICOB' TO PARAGRAFO. */
            _.Move("R3393-NUMERAR-SICOB", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5759- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5762- MOVE 26 TO CEDENTE-COD-CEDENTE OF DCLCEDENTE. */
            _.Move(26, CEDENTE.DCLCEDENTE.CEDENTE_COD_CEDENTE);

            /*" -5763- ACCEPT WS-HORA-INI FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_INI);

            /*" -5766- COMPUTE SIT = (HI * 60 * 60) + (MI * 60) + SI + (DI / 100) */
            WS_HORAS.SIT.Value = (WS_HORAS.WS_HORA_INI_R.HI * 60 * 60) + (WS_HORAS.WS_HORA_INI_R.MI * 60) + WS_HORAS.WS_HORA_INI_R.SI + (WS_HORAS.WS_HORA_INI_R.DI / 100f);

            /*" -5774- PERFORM R3393_NUMERAR_SICOB_DB_SELECT_1 */

            R3393_NUMERAR_SICOB_DB_SELECT_1();

            /*" -5778- ACCEPT WS-HORA-FIM FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_FIM);

            /*" -5779- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF + (DF / 100) */
            WS_HORAS.SFT.Value = (WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (WS_HORAS.WS_HORA_FIM_R.MF * 60) + WS_HORAS.WS_HORA_FIM_R.SF + (WS_HORAS.WS_HORA_FIM_R.DF / 100f);

            /*" -5780- SUBTRACT SIT FROM SFT */
            WS_HORAS.SFT.Value = WS_HORAS.SFT - WS_HORAS.SIT;

            /*" -5781- ADD SFT TO STT(55) */
            TOTAIS_ROT.FILLER_20[55].STT.Value = TOTAIS_ROT.FILLER_20[55].STT + WS_HORAS.SFT;

            /*" -5784- ADD 1 TO SQT(55) */
            TOTAIS_ROT.FILLER_20[55].SQT.Value = TOTAIS_ROT.FILLER_20[55].SQT + 1;

            /*" -5785- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -5786- DISPLAY 'PF0619B FIM ANORMAL' */
                _.Display($"PF0619B FIM ANORMAL");

                /*" -5787- DISPLAY '        ERRO SELECT TAB. CEDENTE' */
                _.Display($"        ERRO SELECT TAB. CEDENTE");

                /*" -5789- DISPLAY '        CODIGO CEDENTE...... ' CEDENTE-COD-CEDENTE OF DCLCEDENTE */
                _.Display($"        CODIGO CEDENTE...... {CEDENTE.DCLCEDENTE.CEDENTE_COD_CEDENTE}");

                /*" -5790- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -5792- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


            /*" -5796- MOVE CEDENTE-NUM-TITULO OF DCLCEDENTE TO W-NUMR-TITULO. */
            _.Move(CEDENTE.DCLCEDENTE.CEDENTE_NUM_TITULO, WAREA_AUXILIAR.W_NUMR_TITULO);

            /*" -5798- ADD 1 TO WTITL-SEQUENCIA. */
            WAREA_AUXILIAR.FILLER_8.WTITL_SEQUENCIA.Value = WAREA_AUXILIAR.FILLER_8.WTITL_SEQUENCIA + 1;

            /*" -5800- MOVE WTITL-SEQUENCIA TO DPARM01. */
            _.Move(WAREA_AUXILIAR.FILLER_8.WTITL_SEQUENCIA, WAREA_AUXILIAR.DPARM01X.DPARM01);

            /*" -5802- CALL 'PROTIT01' USING DPARM01X. */
            _.Call("PROTIT01", WAREA_AUXILIAR.DPARM01X);

            /*" -5803- IF DPARM01-RC NOT EQUAL +0 */

            if (WAREA_AUXILIAR.DPARM01X.DPARM01_RC != +0)
            {

                /*" -5804- DISPLAY 'PF0619B FIM ANORMAL' */
                _.Display($"PF0619B FIM ANORMAL");

                /*" -5806- DISPLAY '        ERRO CHAMADA PROTIT01  ' DPARM01-RC */
                _.Display($"        ERRO CHAMADA PROTIT01  {WAREA_AUXILIAR.DPARM01X.DPARM01_RC}");

                /*" -5808- DISPLAY '        CODIGO CEDENTE........ ' CEDENTE-COD-CEDENTE OF DCLCEDENTE */
                _.Display($"        CODIGO CEDENTE........ {CEDENTE.DCLCEDENTE.CEDENTE_COD_CEDENTE}");

                /*" -5809- DISPLAY '        AREA DE PARM.......... ' DPARM01X */
                _.Display($"        AREA DE PARM.......... {WAREA_AUXILIAR.DPARM01X}");

                /*" -5810- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -5812- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


            /*" -5814- MOVE DPARM01-D1 TO WTITL-DIGITO. */
            _.Move(WAREA_AUXILIAR.DPARM01X.DPARM01_D1, WAREA_AUXILIAR.FILLER_8.WTITL_DIGITO);

            /*" -5816- MOVE W-NUMR-TITULO TO CEDENTE-NUM-TITULO OF DCLCEDENTE. */
            _.Move(WAREA_AUXILIAR.W_NUMR_TITULO, CEDENTE.DCLCEDENTE.CEDENTE_NUM_TITULO);

            /*" -5818- IF CEDENTE-NUM-TITULO OF DCLCEDENTE NOT LESS CEDENTE-NUM-TITULO-MAX OF DCLCEDENTE */

            if (CEDENTE.DCLCEDENTE.CEDENTE_NUM_TITULO >= CEDENTE.DCLCEDENTE.CEDENTE_NUM_TITULO_MAX)
            {

                /*" -5819- DISPLAY 'PF0619B FIM ANORMAL' */
                _.Display($"PF0619B FIM ANORMAL");

                /*" -5820- DISPLAY '        NUM. SICOB CALCULADO EXCEDE SICOB MAXIMO' */
                _.Display($"        NUM. SICOB CALCULADO EXCEDE SICOB MAXIMO");

                /*" -5822- DISPLAY '        CODIGO CEDENTE...... ' CEDENTE-COD-CEDENTE OF DCLCEDENTE */
                _.Display($"        CODIGO CEDENTE...... {CEDENTE.DCLCEDENTE.CEDENTE_COD_CEDENTE}");

                /*" -5824- DISPLAY '        SICOB CALCULADO..... ' CEDENTE-NUM-TITULO OF DCLCEDENTE */
                _.Display($"        SICOB CALCULADO..... {CEDENTE.DCLCEDENTE.CEDENTE_NUM_TITULO}");

                /*" -5826- DISPLAY '        SICOB MAXIMO........ ' CEDENTE-NUM-TITULO-MAX OF DCLCEDENTE */
                _.Display($"        SICOB MAXIMO........ {CEDENTE.DCLCEDENTE.CEDENTE_NUM_TITULO_MAX}");

                /*" -5827- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -5832- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


            /*" -5833- ACCEPT WS-HORA-INI FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_INI);

            /*" -5836- COMPUTE SIT = (HI * 60 * 60) + (MI * 60) + SI + (DI / 100) */
            WS_HORAS.SIT.Value = (WS_HORAS.WS_HORA_INI_R.HI * 60 * 60) + (WS_HORAS.WS_HORA_INI_R.MI * 60) + WS_HORAS.WS_HORA_INI_R.SI + (WS_HORAS.WS_HORA_INI_R.DI / 100f);

            /*" -5840- PERFORM R3393_NUMERAR_SICOB_DB_UPDATE_1 */

            R3393_NUMERAR_SICOB_DB_UPDATE_1();

            /*" -5844- ACCEPT WS-HORA-FIM FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_FIM);

            /*" -5845- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF + (DF / 100) */
            WS_HORAS.SFT.Value = (WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (WS_HORAS.WS_HORA_FIM_R.MF * 60) + WS_HORAS.WS_HORA_FIM_R.SF + (WS_HORAS.WS_HORA_FIM_R.DF / 100f);

            /*" -5846- SUBTRACT SIT FROM SFT */
            WS_HORAS.SFT.Value = WS_HORAS.SFT - WS_HORAS.SIT;

            /*" -5847- ADD SFT TO STT(56) */
            TOTAIS_ROT.FILLER_20[56].STT.Value = TOTAIS_ROT.FILLER_20[56].STT + WS_HORAS.SFT;

            /*" -5850- ADD 1 TO SQT(56) */
            TOTAIS_ROT.FILLER_20[56].SQT.Value = TOTAIS_ROT.FILLER_20[56].SQT + 1;

            /*" -5851- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -5852- DISPLAY 'PF0619B FIM ANORMAL' */
                _.Display($"PF0619B FIM ANORMAL");

                /*" -5853- DISPLAY '        ERRO UPDATE TAB. CEDENTE' */
                _.Display($"        ERRO UPDATE TAB. CEDENTE");

                /*" -5855- DISPLAY '        CODIGO CEDENTE...... ' CEDENTE-COD-CEDENTE OF DCLCEDENTE */
                _.Display($"        CODIGO CEDENTE...... {CEDENTE.DCLCEDENTE.CEDENTE_COD_CEDENTE}");

                /*" -5856- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -5856- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R3393-NUMERAR-SICOB-DB-SELECT-1 */
        public void R3393_NUMERAR_SICOB_DB_SELECT_1()
        {
            /*" -5774- EXEC SQL SELECT NUM_TITULO, NUM_TITULO_MAX INTO :DCLCEDENTE.CEDENTE-NUM-TITULO, :DCLCEDENTE.CEDENTE-NUM-TITULO-MAX FROM SEGUROS.CEDENTE WHERE COD_CEDENTE = :DCLCEDENTE.CEDENTE-COD-CEDENTE WITH UR END-EXEC. */

            var r3393_NUMERAR_SICOB_DB_SELECT_1_Query1 = new R3393_NUMERAR_SICOB_DB_SELECT_1_Query1()
            {
                CEDENTE_COD_CEDENTE = CEDENTE.DCLCEDENTE.CEDENTE_COD_CEDENTE.ToString(),
            };

            var executed_1 = R3393_NUMERAR_SICOB_DB_SELECT_1_Query1.Execute(r3393_NUMERAR_SICOB_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CEDENTE_NUM_TITULO, CEDENTE.DCLCEDENTE.CEDENTE_NUM_TITULO);
                _.Move(executed_1.CEDENTE_NUM_TITULO_MAX, CEDENTE.DCLCEDENTE.CEDENTE_NUM_TITULO_MAX);
            }


        }

        [StopWatch]
        /*" R3393-NUMERAR-SICOB-DB-UPDATE-1 */
        public void R3393_NUMERAR_SICOB_DB_UPDATE_1()
        {
            /*" -5840- EXEC SQL UPDATE SEGUROS.CEDENTE SET NUM_TITULO = :DCLCEDENTE.CEDENTE-NUM-TITULO WHERE COD_CEDENTE = :DCLCEDENTE.CEDENTE-COD-CEDENTE END-EXEC. */

            var r3393_NUMERAR_SICOB_DB_UPDATE_1_Update1 = new R3393_NUMERAR_SICOB_DB_UPDATE_1_Update1()
            {
                CEDENTE_NUM_TITULO = CEDENTE.DCLCEDENTE.CEDENTE_NUM_TITULO.ToString(),
                CEDENTE_COD_CEDENTE = CEDENTE.DCLCEDENTE.CEDENTE_COD_CEDENTE.ToString(),
            };

            R3393_NUMERAR_SICOB_DB_UPDATE_1_Update1.Execute(r3393_NUMERAR_SICOB_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3393_SAIDA*/

        [StopWatch]
        /*" R3394-GERA-DE-PARA-NR-SICOB-SECTION */
        private void R3394_GERA_DE_PARA_NR_SICOB_SECTION()
        {
            /*" -5866- MOVE 'R3394-GERA-DE-PARA-NR-SICOB' TO PARAGRAFO. */
            _.Move("R3394-GERA-DE-PARA-NR-SICOB", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5868- MOVE 'INSERT CONVERSAO-SICOB' TO COMANDO. */
            _.Move("INSERT CONVERSAO-SICOB", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5871- MOVE R3-NUM-PROPOSTA OF REG-PROPOSTA-SASSE TO NUM-PROPOSTA-SIVPF OF DCLCONVERSAO-SICOB */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_NUM_PROPOSTA, COVSICOB.DCLCONVERSAO_SICOB.NUM_PROPOSTA_SIVPF);

            /*" -5874- MOVE R3-COD-PRODUTO OF REG-PROPOSTA-SASSE TO PRODUTO-SIVPF OF DCLCONVERSAO-SICOB */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_COD_PRODUTO, COVSICOB.DCLCONVERSAO_SICOB.PRODUTO_SIVPF);

            /*" -5877- MOVE R3-DTQITBCO OF REG-PROPOSTA-SASSE TO W-DATA-TRABALHO */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_DTQITBCO, WAREA_AUXILIAR.W_DATA_TRABALHO);

            /*" -5879- MOVE W-DIA-TRABALHO TO W-DIA-SQL OF W-DATA-SQL1 */
            _.Move(WAREA_AUXILIAR.FILLER_2.W_DIA_TRABALHO, WAREA_AUXILIAR.W_DATA_SQL1.W_DIA_SQL);

            /*" -5881- MOVE W-MES-TRABALHO TO W-MES-SQL OF W-DATA-SQL1 */
            _.Move(WAREA_AUXILIAR.FILLER_2.W_MES_TRABALHO, WAREA_AUXILIAR.W_DATA_SQL1.W_MES_SQL);

            /*" -5884- MOVE W-ANO-TRABALHO TO W-ANO-SQL OF W-DATA-SQL1 */
            _.Move(WAREA_AUXILIAR.FILLER_2.W_ANO_TRABALHO, WAREA_AUXILIAR.W_DATA_SQL1.W_ANO_SQL);

            /*" -5888- MOVE '-' TO W-BARRA1 OF W-DATA-SQL1, W-BARRA2 OF W-DATA-SQL1 */
            _.Move("-", WAREA_AUXILIAR.W_DATA_SQL1.W_BARRA1_1);
            _.Move("-", WAREA_AUXILIAR.W_DATA_SQL1.W_BARRA2_1);


            /*" -5891- MOVE W-DATA-SQL TO DATA-QUITACAO OF DCLCONVERSAO-SICOB */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL, COVSICOB.DCLCONVERSAO_SICOB.DATA_QUITACAO);

            /*" -5894- MOVE R3-AGEPGTO OF REG-PROPOSTA-SASSE TO AGEPGTO OF DCLCONVERSAO-SICOB */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_AGEPGTO, COVSICOB.DCLCONVERSAO_SICOB.AGEPGTO);

            /*" -5897- MOVE R3-VAL-PAGO OF REG-PROPOSTA-SASSE TO VAL-RCAP OF DCLCONVERSAO-SICOB */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_VAL_PAGO, COVSICOB.DCLCONVERSAO_SICOB.VAL_RCAP);

            /*" -5900- MOVE PRDSIVPF-COD-EMPRESA-SIVPF OF DCLPRODUTOS-SIVPF TO COD-EMPRESA-SIVPF OF DCLCONVERSAO-SICOB */
            _.Move(PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_EMPRESA_SIVPF, COVSICOB.DCLCONVERSAO_SICOB.COD_EMPRESA_SIVPF);

            /*" -5903- MOVE SISTEMAS-DATA-MOV-ABERTO OF DCLSISTEMAS TO DATA-OPERACAO OF DCLCONVERSAO-SICOB */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, COVSICOB.DCLCONVERSAO_SICOB.DATA_OPERACAO);

            /*" -5906- MOVE 'PF0619B' TO COD-USUARIO OF DCLCONVERSAO-SICOB. */
            _.Move("PF0619B", COVSICOB.DCLCONVERSAO_SICOB.COD_USUARIO);

            /*" -5910- MOVE CEDENTE-NUM-TITULO OF DCLCEDENTE TO NUM-SICOB OF DCLCONVERSAO-SICOB. */
            _.Move(CEDENTE.DCLCEDENTE.CEDENTE_NUM_TITULO, COVSICOB.DCLCONVERSAO_SICOB.NUM_SICOB);

            /*" -5911- ACCEPT WS-HORA-INI FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_INI);

            /*" -5914- COMPUTE SIT = (HI * 60 * 60) + (MI * 60) + SI + (DI / 100) */
            WS_HORAS.SIT.Value = (WS_HORAS.WS_HORA_INI_R.HI * 60 * 60) + (WS_HORAS.WS_HORA_INI_R.MI * 60) + WS_HORAS.WS_HORA_INI_R.SI + (WS_HORAS.WS_HORA_INI_R.DI / 100f);

            /*" -5926- PERFORM R3394_GERA_DE_PARA_NR_SICOB_DB_INSERT_1 */

            R3394_GERA_DE_PARA_NR_SICOB_DB_INSERT_1();

            /*" -5930- ACCEPT WS-HORA-FIM FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_FIM);

            /*" -5931- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF + (DF / 100) */
            WS_HORAS.SFT.Value = (WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (WS_HORAS.WS_HORA_FIM_R.MF * 60) + WS_HORAS.WS_HORA_FIM_R.SF + (WS_HORAS.WS_HORA_FIM_R.DF / 100f);

            /*" -5932- SUBTRACT SIT FROM SFT */
            WS_HORAS.SFT.Value = WS_HORAS.SFT - WS_HORAS.SIT;

            /*" -5933- ADD SFT TO STT(57) */
            TOTAIS_ROT.FILLER_20[57].STT.Value = TOTAIS_ROT.FILLER_20[57].STT + WS_HORAS.SFT;

            /*" -5936- ADD 1 TO SQT(57) */
            TOTAIS_ROT.FILLER_20[57].SQT.Value = TOTAIS_ROT.FILLER_20[57].SQT + 1;

            /*" -5937- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -5938- DISPLAY 'PF0619B - FIM ANORMAL' */
                _.Display($"PF0619B - FIM ANORMAL");

                /*" -5939- DISPLAY '          ERRO INSERT DA TAB. CONVERSAO-SICOB' */
                _.Display($"          ERRO INSERT DA TAB. CONVERSAO-SICOB");

                /*" -5941- DISPLAY '          CODIGO PESSOA.................  ' PESSOA-COD-PESSOA OF DCLPESSOA */
                _.Display($"          CODIGO PESSOA.................  {PESSOA.DCLPESSOA.PESSOA_COD_PESSOA}");

                /*" -5943- DISPLAY '          NUMERO PROPOSTA...............  ' NUM-PROPOSTA-SIVPF OF DCLCONVERSAO-SICOB */
                _.Display($"          NUMERO PROPOSTA...............  {COVSICOB.DCLCONVERSAO_SICOB.NUM_PROPOSTA_SIVPF}");

                /*" -5945- DISPLAY '          NUMERO SICOB..................  ' NUM-SICOB OF DCLCONVERSAO-SICOB */
                _.Display($"          NUMERO SICOB..................  {COVSICOB.DCLCONVERSAO_SICOB.NUM_SICOB}");

                /*" -5947- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -5948- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -5948- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R3394-GERA-DE-PARA-NR-SICOB-DB-INSERT-1 */
        public void R3394_GERA_DE_PARA_NR_SICOB_DB_INSERT_1()
        {
            /*" -5926- EXEC SQL INSERT INTO SEGUROS.CONVERSAO_SICOB VALUES (:DCLCONVERSAO-SICOB.NUM-PROPOSTA-SIVPF, :DCLCONVERSAO-SICOB.NUM-SICOB, :DCLCONVERSAO-SICOB.COD-EMPRESA-SIVPF, :DCLCONVERSAO-SICOB.PRODUTO-SIVPF, :DCLCONVERSAO-SICOB.AGEPGTO, :DCLCONVERSAO-SICOB.DATA-OPERACAO, :DCLCONVERSAO-SICOB.DATA-QUITACAO, :DCLCONVERSAO-SICOB.VAL-RCAP, :DCLCONVERSAO-SICOB.COD-USUARIO, CURRENT TIMESTAMP) END-EXEC. */

            var r3394_GERA_DE_PARA_NR_SICOB_DB_INSERT_1_Insert1 = new R3394_GERA_DE_PARA_NR_SICOB_DB_INSERT_1_Insert1()
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

            R3394_GERA_DE_PARA_NR_SICOB_DB_INSERT_1_Insert1.Execute(r3394_GERA_DE_PARA_NR_SICOB_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3394_SAIDA*/

        [StopWatch]
        /*" R5050-00-SELECIONA-BILHETE-SECTION */
        private void R5050_00_SELECIONA_BILHETE_SECTION()
        {
            /*" -5958- MOVE 'R0050-00-SELECIONA-BILHETE' TO PARAGRAFO. */
            _.Move("R0050-00-SELECIONA-BILHETE", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5960- MOVE 'DECLARE BILHETE' TO COMANDO. */
            _.Move("DECLARE BILHETE", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5961- MOVE 'NAO' TO W-FIM-CURSOR-BILHETE */
            _.Move("NAO", WAREA_AUXILIAR.W_FIM_CURSOR_BILHETE);

            /*" -5962- MOVE ZEROS TO W-NSL */
            _.Move(0, WAREA_AUXILIAR.W_NSL);

            /*" -5963- ACCEPT W-TIME FROM TIME. */
            _.Move(_.AcceptDate("TIME"), WAREA_AUXILIAR.W_TIME);

            /*" -5965- MOVE W-TIME TO W-TIME-EDIT. */
            _.Move(WAREA_AUXILIAR.W_TIME, WAREA_AUXILIAR.W_TIME_EDIT);

            /*" -5966- DISPLAY ' ' */
            _.Display($" ");

            /*" -5967- DISPLAY ' ' */
            _.Display($" ");

            /*" -5968- DISPLAY '************************************************' . */
            _.Display($"************************************************");

            /*" -5972- DISPLAY '** PF0619B ** INICIO DECLARE CRS-BILHETE...  ' W-TIME-EDIT. */
            _.Display($"** PF0619B ** INICIO DECLARE CRS-BILHETE...  {WAREA_AUXILIAR.W_TIME_EDIT}");

            /*" -5973- ACCEPT WS-HORA-INI FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_INI);

            /*" -5976- COMPUTE SIT = (HI * 60 * 60) + (MI * 60) + SI + (DI / 100) */
            WS_HORAS.SIT.Value = (WS_HORAS.WS_HORA_INI_R.HI * 60 * 60) + (WS_HORAS.WS_HORA_INI_R.MI * 60) + WS_HORAS.WS_HORA_INI_R.SI + (WS_HORAS.WS_HORA_INI_R.DI / 100f);

            /*" -5990- PERFORM R5050_00_SELECIONA_BILHETE_DB_DECLARE_1 */

            R5050_00_SELECIONA_BILHETE_DB_DECLARE_1();

            /*" -5994- ACCEPT WS-HORA-FIM FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_FIM);

            /*" -5995- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF + (DF / 100) */
            WS_HORAS.SFT.Value = (WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (WS_HORAS.WS_HORA_FIM_R.MF * 60) + WS_HORAS.WS_HORA_FIM_R.SF + (WS_HORAS.WS_HORA_FIM_R.DF / 100f);

            /*" -5996- SUBTRACT SIT FROM SFT */
            WS_HORAS.SFT.Value = WS_HORAS.SFT - WS_HORAS.SIT;

            /*" -5997- ADD SFT TO STT(03) */
            TOTAIS_ROT.FILLER_20[03].STT.Value = TOTAIS_ROT.FILLER_20[03].STT + WS_HORAS.SFT;

            /*" -6001- ADD 1 TO SQT(03) */
            TOTAIS_ROT.FILLER_20[03].SQT.Value = TOTAIS_ROT.FILLER_20[03].SQT + 1;

            /*" -6002- ACCEPT WS-HORA-INI FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_INI);

            /*" -6005- COMPUTE SIT = (HI * 60 * 60) + (MI * 60) + SI + (DI / 100) */
            WS_HORAS.SIT.Value = (WS_HORAS.WS_HORA_INI_R.HI * 60 * 60) + (WS_HORAS.WS_HORA_INI_R.MI * 60) + WS_HORAS.WS_HORA_INI_R.SI + (WS_HORAS.WS_HORA_INI_R.DI / 100f);

            /*" -6005- PERFORM R5050_00_SELECIONA_BILHETE_DB_OPEN_1 */

            R5050_00_SELECIONA_BILHETE_DB_OPEN_1();

            /*" -6009- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -6010- DISPLAY 'PF0619B - FIM ANORMAL' */
                _.Display($"PF0619B - FIM ANORMAL");

                /*" -6012- DISPLAY '          ERRO OPEN CURSOR CRS-BILHETE  ' SQLCODE */
                _.Display($"          ERRO OPEN CURSOR CRS-BILHETE  {DB.SQLCODE}");

                /*" -6013- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -6014- PERFORM R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION();

                /*" -6018- END-IF. */
            }


            /*" -6019- ACCEPT WS-HORA-FIM FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_FIM);

            /*" -6020- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF + (DF / 100) */
            WS_HORAS.SFT.Value = (WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (WS_HORAS.WS_HORA_FIM_R.MF * 60) + WS_HORAS.WS_HORA_FIM_R.SF + (WS_HORAS.WS_HORA_FIM_R.DF / 100f);

            /*" -6021- SUBTRACT SIT FROM SFT */
            WS_HORAS.SFT.Value = WS_HORAS.SFT - WS_HORAS.SIT;

            /*" -6022- ADD SFT TO STT(04) */
            TOTAIS_ROT.FILLER_20[04].STT.Value = TOTAIS_ROT.FILLER_20[04].STT + WS_HORAS.SFT;

            /*" -6025- ADD 1 TO SQT(04) */
            TOTAIS_ROT.FILLER_20[04].SQT.Value = TOTAIS_ROT.FILLER_20[04].SQT + 1;

            /*" -6026- ACCEPT W-TIME FROM TIME. */
            _.Move(_.AcceptDate("TIME"), WAREA_AUXILIAR.W_TIME);

            /*" -6028- MOVE W-TIME TO W-TIME-EDIT. */
            _.Move(WAREA_AUXILIAR.W_TIME, WAREA_AUXILIAR.W_TIME_EDIT);

            /*" -6030- DISPLAY '** PF0619B ** FIM    DECLARE CRS-BILHETE...  ' W-TIME-EDIT */
            _.Display($"** PF0619B ** FIM    DECLARE CRS-BILHETE...  {WAREA_AUXILIAR.W_TIME_EDIT}");

            /*" -6031- DISPLAY '************************************************' . */
            _.Display($"************************************************");

            /*" -6031- DISPLAY ' ' . */
            _.Display($" ");

        }

        [StopWatch]
        /*" R5050-00-SELECIONA-BILHETE-DB-OPEN-1 */
        public void R5050_00_SELECIONA_BILHETE_DB_OPEN_1()
        {
            /*" -6005- EXEC SQL OPEN CRS-BILHETE END-EXEC. */

            CRS_BILHETE.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R5050_SAIDA*/

        [StopWatch]
        /*" R5070-00-LER-BILHETE-SECTION */
        private void R5070_00_LER_BILHETE_SECTION()
        {
            /*" -6041- MOVE 'R5070-00-LER-BILHETE' TO PARAGRAFO. */
            _.Move("R5070-00-LER-BILHETE", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -6044- MOVE 'FETCH BILHETE       ' TO COMANDO. */
            _.Move("FETCH BILHETE       ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -6045- ACCEPT WS-HORA-INI FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_INI);

            /*" -6048- COMPUTE SIT = (HI * 60 * 60) + (MI * 60) + SI + (DI / 100) */
            WS_HORAS.SIT.Value = (WS_HORAS.WS_HORA_INI_R.HI * 60 * 60) + (WS_HORAS.WS_HORA_INI_R.MI * 60) + WS_HORAS.WS_HORA_INI_R.SI + (WS_HORAS.WS_HORA_INI_R.DI / 100f);

            /*" -6052- PERFORM R5070_00_LER_BILHETE_DB_FETCH_1 */

            R5070_00_LER_BILHETE_DB_FETCH_1();

            /*" -6056- ACCEPT WS-HORA-FIM FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_FIM);

            /*" -6057- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF + (DF / 100) */
            WS_HORAS.SFT.Value = (WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (WS_HORAS.WS_HORA_FIM_R.MF * 60) + WS_HORAS.WS_HORA_FIM_R.SF + (WS_HORAS.WS_HORA_FIM_R.DF / 100f);

            /*" -6058- SUBTRACT SIT FROM SFT */
            WS_HORAS.SFT.Value = WS_HORAS.SFT - WS_HORAS.SIT;

            /*" -6059- ADD SFT TO STT(05) */
            TOTAIS_ROT.FILLER_20[05].STT.Value = TOTAIS_ROT.FILLER_20[05].STT + WS_HORAS.SFT;

            /*" -6062- ADD 1 TO SQT(05) */
            TOTAIS_ROT.FILLER_20[05].SQT.Value = TOTAIS_ROT.FILLER_20[05].SQT + 1;

            /*" -6063- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -6064- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -6065- MOVE 'FIM' TO W-FIM-CURSOR-BILHETE */
                    _.Move("FIM", WAREA_AUXILIAR.W_FIM_CURSOR_BILHETE);

                    /*" -6065- PERFORM R5070_00_LER_BILHETE_DB_CLOSE_1 */

                    R5070_00_LER_BILHETE_DB_CLOSE_1();

                    /*" -6067- ELSE */
                }
                else
                {


                    /*" -6068- DISPLAY 'PF0619B - FIM ANORMAL' */
                    _.Display($"PF0619B - FIM ANORMAL");

                    /*" -6070- DISPLAY '          ERRO FETCH CURSOR CRS-BILHETE  ' SQLCODE */
                    _.Display($"          ERRO FETCH CURSOR CRS-BILHETE  {DB.SQLCODE}");

                    /*" -6071- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -6072- PERFORM R9999-00-FINALIZAR */

                    R9999_00_FINALIZAR_SECTION();

                    /*" -6073- END-IF */
                }


                /*" -6074- ELSE */
            }
            else
            {


                /*" -6077- ADD 1 TO W-NSL, W-CONTROLE */
                WAREA_AUXILIAR.W_NSL.Value = WAREA_AUXILIAR.W_NSL + 1;
                WAREA_AUXILIAR.W_CONTROLE.Value = WAREA_AUXILIAR.W_CONTROLE + 1;

                /*" -6078- IF W-CONTROLE > 999 */

                if (WAREA_AUXILIAR.W_CONTROLE > 999)
                {

                    /*" -6079- ACCEPT W-TIME FROM TIME */
                    _.Move(_.AcceptDate("TIME"), WAREA_AUXILIAR.W_TIME);

                    /*" -6080- MOVE W-TIME TO W-TIME-EDIT */
                    _.Move(WAREA_AUXILIAR.W_TIME, WAREA_AUXILIAR.W_TIME_EDIT);

                    /*" -6081- MOVE ZEROS TO W-CONTROLE */
                    _.Move(0, WAREA_AUXILIAR.W_CONTROLE);

                    /*" -6082- DISPLAY ' ' */
                    _.Display($" ");

                    /*" -6083- DISPLAY '** PF0619B ** BILHETE LIDO... ' W-NSL */
                    _.Display($"** PF0619B ** BILHETE LIDO... {WAREA_AUXILIAR.W_NSL}");

                    /*" -6084- DISPLAY '** PF0619B ** HORA........... ' W-TIME-EDIT */
                    _.Display($"** PF0619B ** HORA........... {WAREA_AUXILIAR.W_TIME_EDIT}");

                    /*" -6085- DISPLAY ' ' */
                    _.Display($" ");

                    /*" -6086- END-IF */
                }


                /*" -6087- END-IF */
            }


            /*" -6087- . */

        }

        [StopWatch]
        /*" R5070-00-LER-BILHETE-DB-FETCH-1 */
        public void R5070_00_LER_BILHETE_DB_FETCH_1()
        {
            /*" -6052- EXEC SQL FETCH CRS-BILHETE INTO :DCLPROPOSTA-FIDELIZ.NUM-PROPOSTA-SIVPF, :DCLPROPOSTA-FIDELIZ.NUM-SICOB END-EXEC. */

            if (CRS_BILHETE.Fetch())
            {
                _.Move(CRS_BILHETE.DCLPROPOSTA_FIDELIZ_NUM_PROPOSTA_SIVPF, PROPFID.DCLPROPOSTA_FIDELIZ.NUM_PROPOSTA_SIVPF);
                _.Move(CRS_BILHETE.DCLPROPOSTA_FIDELIZ_NUM_SICOB, PROPFID.DCLPROPOSTA_FIDELIZ.NUM_SICOB);
            }

        }

        [StopWatch]
        /*" R5070-00-LER-BILHETE-DB-CLOSE-1 */
        public void R5070_00_LER_BILHETE_DB_CLOSE_1()
        {
            /*" -6065- EXEC SQL CLOSE CRS-BILHETE END-EXEC */

            CRS_BILHETE.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R5070_SAIDA*/

        [StopWatch]
        /*" R5150-00-PROCESSAR-BILHETE-SECTION */
        private void R5150_00_PROCESSAR_BILHETE_SECTION()
        {
            /*" -6095- MOVE 'R5150-00-PROCESSAR-BILHETE' TO PARAGRAFO. */
            _.Move("R5150-00-PROCESSAR-BILHETE", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -6097- MOVE 'PROCESSAR BILHETE REJEITADO' TO COMANDO. */
            _.Move("PROCESSAR BILHETE REJEITADO", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -6099- PERFORM R0250-00-UPDATE-FIDELIZ */

            R0250_00_UPDATE_FIDELIZ_SECTION();

            /*" -6101- ADD 1 TO WS-QTD-BILHETE */
            WAREA_AUXILIAR.WS_QTD_BILHETE.Value = WAREA_AUXILIAR.WS_QTD_BILHETE + 1;

            /*" -6102- PERFORM R5070-00-LER-BILHETE */

            R5070_00_LER_BILHETE_SECTION();

            /*" -6102- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R5150_SAIDA*/

        [StopWatch]
        /*" R9988-00-FECHAR-ARQUIVOS-SECTION */
        private void R9988_00_FECHAR_ARQUIVOS_SECTION()
        {
            /*" -6111- CLOSE MOVTO-PRP-SASSE. */
            MOVTO_PRP_SASSE.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9988_SAIDA*/

        [StopWatch]
        /*" R9998-00-MONITOR-SECTION */
        private void R9998_00_MONITOR_SECTION()
        {
            /*" -6118- DISPLAY ' ' . */
            _.Display($" ");

            /*" -6118- MOVE ZEROS TO SII. */
            _.Move(0, WS_HORAS.SII);

            /*" -0- FLUXCONTROL_PERFORM M_1100_MOSTRA_TOTAIS */

            M_1100_MOSTRA_TOTAIS();

        }

        [StopWatch]
        /*" M-1100-MOSTRA-TOTAIS */
        private void M_1100_MOSTRA_TOTAIS(bool isPerform = false)
        {
            /*" -6121- ADD 1 TO SII. */
            WS_HORAS.SII.Value = WS_HORAS.SII + 1;

            /*" -6122- IF SII < 58 */

            if (WS_HORAS.SII < 58)
            {

                /*" -6123- MOVE STT(SII) TO STT-DISP */
                _.Move(TOTAIS_ROT.FILLER_20[WS_HORAS.SII].STT, WS_HORAS.STT_DISP);

                /*" -6125- DISPLAY 'PARAGRAFO:' SII ' TOTAL= ' STT-DISP ' QTDE= ' SQT(SII) */

                $"PARAGRAFO:{WS_HORAS.SII} TOTAL= {WS_HORAS.STT_DISP} QTDE= {TOTAIS_ROT.FILLER_20[WS_HORAS.SII]}"
                .Display();

                /*" -6126- GO TO 1100-MOSTRA-TOTAIS. */
                new Task(() => M_1100_MOSTRA_TOTAIS()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


            /*" -6126- DISPLAY ' ' . */
            _.Display($" ");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9998_SAIDA*/

        [StopWatch]
        /*" R9999-00-FINALIZAR-SECTION */
        private void R9999_00_FINALIZAR_SECTION()
        {
            /*" -6136- DISPLAY ' ' */
            _.Display($" ");

            /*" -6137- DISPLAY '---------------------------------------------- ' */
            _.Display($"---------------------------------------------- ");

            /*" -6138- DISPLAY 'QUANT. BILHETES REJEITADOS... ' WS-QTD-BILHETE */
            _.Display($"QUANT. BILHETES REJEITADOS... {WAREA_AUXILIAR.WS_QTD_BILHETE}");

            /*" -6139- DISPLAY '---------------------------------------------- ' */
            _.Display($"---------------------------------------------- ");

            /*" -6140- DISPLAY ' ' */
            _.Display($" ");

            /*" -6142- DISPLAY ' ' */
            _.Display($" ");

            /*" -6143- IF W-FIM-MOVTO-VGAP = 'FIM' */

            if (WAREA_AUXILIAR.W_FIM_MOVTO_VGAP == "FIM")
            {

                /*" -6144- DISPLAY 'PF0619B - FIM NORMAL' */
                _.Display($"PF0619B - FIM NORMAL");

                /*" -6145- MOVE 0 TO RETURN-CODE */
                _.Move(0, RETURN_CODE);

                /*" -6146- MOVE 'COMMIT WORK' TO COMANDO */
                _.Move("COMMIT WORK", WABEND.LOCALIZA_ABEND_2.COMANDO);

                /*" -6146- EXEC SQL COMMIT WORK END-EXEC */

                DatabaseConnection.Instance.CommitTransaction();

                /*" -6148- ELSE */
            }
            else
            {


                /*" -6149- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, WABEND.FILLER_11.WSQLCODE);

                /*" -6150- MOVE SQLERRD(1) TO WSQLERRD1 */
                _.Move(DB.SQLERRD[1], WABEND.FILLER_11.WSQLERRD1);

                /*" -6151- MOVE SQLERRD(2) TO WSQLERRD2 */
                _.Move(DB.SQLERRD[2], WABEND.FILLER_11.WSQLERRD2);

                /*" -6152- DISPLAY WABEND */
                _.Display(WABEND);

                /*" -6153- DISPLAY '*** PF0619B *** ROLLBACK EM ANDAMENTO ...' */
                _.Display($"*** PF0619B *** ROLLBACK EM ANDAMENTO ...");

                /*" -6154- MOVE 'ROLLBACK WORK' TO COMANDO */
                _.Move("ROLLBACK WORK", WABEND.LOCALIZA_ABEND_2.COMANDO);

                /*" -6154- EXEC SQL ROLLBACK WORK END-EXEC */

                DatabaseConnection.Instance.RollbackTransaction();

                /*" -6156- MOVE 99 TO RETURN-CODE */
                _.Move(99, RETURN_CODE);

                /*" -6158- END-IF. */
            }


            /*" -6158- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9999_SAIDA*/
    }
}