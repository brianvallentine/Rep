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
using Sias.PessoaFisica.DB2.PF0612B;

namespace Code
{
    public class PF0612B
    {
        public bool IsCall { get; set; }

        public PF0612B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      ******************************************************************      */
        /*"      *   SISTEMA .............. PF - PRODUTOS DE FIDELIZACAO          *      */
        /*"      *   PROGRAMA ............. PF0612B                               *      */
        /*"      *   DATA ................. 11/02/2000                            *      */
        /*"      *   ANALISTA RESPONSAVEL.. LUIZ CARLOS                           *      */
        /*"      *   REVISAO PROGRAMACAO... REGINALDO SILVA                       *      */
        /*"      *                                                                *      */
        /*"      *   FUNCAO ............... GERA ARQUIVO PARA O SIGPF, DO ESTOQUE *      */
        /*"      *                          DAS PROPOSTAS EMITIDAS NO DIA - SIAS, *      */
        /*"      *                          BEM COMO ATUALIZA TODAS  AS  TABELAS  *      */
        /*"      *                          CORPORATIVAS DO SISPF.                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 33             GERAR ARQUIVO TIPO-D PARA O NOME SOCIAL  *      */
        /*"      *                                                                *      */
        /*"      * ATENDE DEMANDA 577.291                                         *      */
        /*"      *                                                                *      */
        /*"      * PROCURE V.33          ROGER PIRES DOS SANTOS                   *      */
        /*"      *                       25/04/2024                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 32             ENVIAR AS PROPOSTAS COMERCIALIZADAS NO   *      */
        /*"      *                       AUTO COMPRA DE VIDA, ORIGENS 1009 E 1010.*      */
        /*"      * OBS.: FORAM ADICIONADOS OS ENVIOS DOS CAMPOS R3-PRAZO-VIGENCIA *      */
        /*"      *       E R3-VALOR-PREMIO-TOTAL A PEDIDO DA SEGURIDADE.          *      */
        /*"      * ATENDE DEMANDA 244.137                                         *      */
        /*"      *                                                                *      */
        /*"      * PROCURE V.32          FRANK CARVALHO                           *      */
        /*"      *                       09/11/2020                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 31             ENVIAR PARA O SIGPF A INFORMACAO         *      */
        /*"      *                       DE ASSINATURA ELETRONICA CAMPO DA TABELA *      */
        /*"      *                       PROPOSTA_FIDELIZ - IND_TP_PROPOSTA       *      */
        /*"      * ATENDE DEMANDA 236722                                          *      */
        /*"      *                                                                *      */
        /*"      * PROCURE V.31          THIAGO BLAIER                            *      */
        /*"      *                       30/03/2020                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 30             IMPACTO DA INCLUSAO DO CAMPO             *      */
        /*"      *                       IND_TP_CONTA NA TABELA PROPOSTA_FIDELIZ. *      */
        /*"      * ATENDE DEMANDA 175.167                                         *      */
        /*"      *                                                                *      */
        /*"      * PROCURE V.30          MARCUS VALERIO                           *      */
        /*"      *                       25/02/2019                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 29             TRATAR CODIGO CBO PELO NOME ABREVIADO    *      */
        /*"      * ATENDE CADMUS 146512                                           *      */
        /*"      *                                                                *      */
        /*"      * PROCURE V.29          THIAGO BLAIER                            *      */
        /*"      *                       06/03/2017                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 28             IMPACTO DA INCLUSAO DO CAMPO             *      */
        /*"      * ATENDE CADMUS 140.553 IND_TP_PROPOSTA NA TABELA                *      */
        /*"      *                       PROPOSTA_FIDELIZ.                        *      */
        /*"      * PROCURE V.28          FRANK CARVALHO                           *      */
        /*"      *                       04/08/2016                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 27             ALTERACOES NOS REGISTROS TIPO 3 E TIPO A *      */
        /*"      * ATENDE CADMUS 97713   CAMPOS :  OPERACAO E NUMERO DE CONTA     *      */
        /*"      *                                                                *      */
        /*"      * PROCURE NSGD          REGINALDO SILVA                          *      */
        /*"      *                       16/06/2015                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 26             AJUSTE PERIODICIDADE DE PAGAMENTO        *      */
        /*"      * ATENDE CADMUS 93600   PERI-PAGAMENTO E R3-PERIPGTO             *      */
        /*"      *                                                                *      */
        /*"      * PROCURE V.26          REGINALDO SILVA                          *      */
        /*"      *                       10/04/2014                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 25             AJUSTE INSERT HIST_PROP_FIDELIZ          *      */
        /*"      * ATENDE CADMUS 88764   COD-EMPRESA    E   COD-PRODUTO           *      */
        /*"      *                                                                *      */
        /*"      * PROCURE IHP           REGINALDO SILVA / SERGIO LORETO          *      */
        /*"      *                       11/11/2013                               *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 24             AJUSTE NOS SELECTS - V10                 *      */
        /*"      * ATENDE CADMUS 84809   DB2.V10  SELECTS                         *      */
        /*"      *                                                                *      */
        /*"      *                       REGINALDO SILVA                          *      */
        /*"      *                       10/09/2013                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 23             PROJETO MONITORAMENTO                    *      */
        /*"      * ATENDE CADMUS 75904   CAMPO ORIGEM PROPOSTA NO ARQ DE SAIDA    *      */
        /*"      *                                                                *      */
        /*"      *                       REGINALDO SILVA                          *      */
        /*"      *                       23/11/2012                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 22-    ATENDE CADMUS 68192                              *      */
        /*"      *                                                                *      */
        /*"      * 02/05/2012 PROCURE POR V.22 - MARCUS ANDRE DIAS (GESIN)        *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"      ******************************************************************      */
        /*"      * VERSAO 21-    ATENDE CADMUS 201123                             *      */
        /*"      *                                                                *      */
        /*"      * 12/07/2011 PROCURE POR V.21 - ALESSANDRO RAMOS (FAST COMPUTER) *      */
        /*"      ******************************************************************      */
        /*"      * VERSAO 20-    ATENDE CADMUS 201114                             *      */
        /*"      *                                                                *      */
        /*"      * 29/06/2011 PROCURE POR V.20 - EDIVALDO GOMES  (FAST COMPUTER)  *      */
        /*"      ******************************************************************      */
        /*"      * VERSAO 19-          - ATENDE CADMUS 42951                      *      */
        /*"      *                                                                *      */
        /*"      * 25/05/2010 PROCURE POR V.19 - EDSON MARQUES   .                *      */
        /*"      ******************************************************************      */
        /*"      * VERSAO 18-          - ATENDE CADMUS 40632                      *      */
        /*"      *                                                                *      */
        /*"      * 09/04/2010 PROCURE POR V.18 - EDSON MARQUES   .                *      */
        /*"      ******************************************************************      */
        /*"      * VERSAO 17-          - ATENDE CADMUS 32886                      *      */
        /*"      *                                                                *      */
        /*"      * 19/11/2009 PROCURE POR V.17 - EDILANA CERQUEIRA.               *      */
        /*"      ******************************************************************      */
        /*"      * VERSAO 16-          - ATENDE CADMUS 32997                      *      */
        /*"      *                                                                *      */
        /*"      * 18/11/2009 PROCURE POR V.16 - EDILANA CERQUEIRA.               *      */
        /*"      ******************************************************************      */
        /*"      * VERSAO 15- SSI32240 - ATENDE CADMUS 32240                      *      */
        /*"      *                                                                *      */
        /*"      * 06/11/2009 PROCURE POR V.15 - EDILANA CERQUEIRA.               *      */
        /*"      ******************************************************************      */
        /*"      * VERSAO 14- SSI23602 - ALTERACAO NO SELECT DA TABELA ENDERECOS  *      */
        /*"      *            EM FUNCAO DE SQLCODE 100 POR NAO TER ENCONTRADO A   *      */
        /*"      *            OCORR_ENDERECO = 1. ALTERADO PARA BUSCAR O MAX DA   *      */
        /*"      *            OCORR_ENDERECO.                                     *      */
        /*"      *                                                                *      */
        /*"      * 01/10/2008 PROCURE POR V.14 - MAURICIO LINKE.                  *      */
        /*"      ******************************************************************      */
        /*"      * VERSAO 13- DESPREZAR COD_PRODUTO_SIVPF IGUAL A 48. TRATA-SE DA *      */
        /*"      *            INTERNALIZACAO DE APOLICE ESPECIFICA DE VIDA.       *      */
        /*"      *                                                                *      */
        /*"      * 27/11/2007 PROCURE POR V.13 - MAURICIO LINKE.                  *      */
        /*"      ******************************************************************      */
        /*"      *   VERSAO - 12                                                  *      */
        /*"      *   EM 26-07-2006: CORRIGE TESTE DE SQLCODE 811 PARA -811        *      */
        /*"      *                                                                *      */
        /*"      *   PROCURE POR V.12       LUCIA VIEIRA                          *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"      *   VERSAO - 11                                                  *      */
        /*"      *   EM 02-03-2005: NO SEGURO VIDA MULHER, NAO SERA GERADO O REGIS*      */
        /*"      *                  TRO '6'. A DPS SERA GERADA EM BRANCO. CONFORME*      */
        /*"      *                  ORIENTACAO DO SR. MARCELO GABRIEL.            *      */
        /*"      *                                                                *      */
        /*"      *   PROCURE POR V.11                                             *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"      *   VERSAO - 10                                                  *      */
        /*"      *   EM 05-03-2004: PASSOU A TRATAR AS TABELAS DE VIDA NA FAIXA DE*      */
        /*"      *                  NUMERACAO 10000000000 E  19999999999, PASSANDO*      */
        /*"      *                  A INCLUIR O DV PARA ENVIO A CEF.              *      */
        /*"      *                                                                *      */
        /*"      *   PROCURE POR V.10                                             *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"      *   VERSOES.                                                     *      */
        /*"      *   09 -  24/07/2003 FOI ACERTADO O ACESSO A TABELA              *      */
        /*"      *                    PRODUTO_SIVPF            PROCURE 240703.    *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"      *   VERSOES.                                                     *      */
        /*"      *   08 -  23/07/2003 FOI INCLUIDO NO DECLARE PRINCIPAL A TABELA  *      */
        /*"      *                    PRODUTO_SIVPF            PROCURE 230703.    *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"      *   VERSOES.                                                     *      */
        /*"      *   07 -  22/07/2003 PASSOU A DESCONSIDERAR O PRODUTO 9318       *      */
        /*"      *                    (VIDA DA GENTE)          PROCURE 220703.    *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"      *   VERSOES.                                                     *      */
        /*"      *   05 -  18/07/2003 PASSOU A TRATAR COD_UF (GE_DOC_CLIENTE)     *      */
        /*"      *                    COM CONTE DO NULO        PROCURE 180703.    *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"      *   VERSOES.                                                     *      */
        /*"      *   04 -  06/05/2003 PASSOU A OBTER A DATA DE EXPEDICAO DO RG,   *      */
        /*"      *                    ADEQUANDO-SE   A CIRCULAR 200 SUSEP.        *      */
        /*"      *                                                                *      */
        /*"      *         PROCURE POR V04 - LUIZ CARLOS.                         *      */
        /*"      ******************************************************************      */
        /*"      *   VERSOES.                                                     *      */
        /*"      *   03 -  28/03/2003 PASSOU A DESPREZAR MOVIMENTO DO PRODUTO 9313*      */
        /*"      *                    'CAIXA CONSORCIO PRESTAMISTA'.              *      */
        /*"      *                                                                *      */
        /*"      *         PROCURE POR V03 - LUIZ CARLOS.                         *      */
        /*"      ******************************************************************      */
        /*"      *   VERSOES.                                                     *      */
        /*"      *   02 -  13/12/2002 FOI RETIRADO O ACESSO A TABELA PRODUTOS_VG, *      */
        /*"      *                    PARA OBTER A APOLICE/SUBGRUPO  PASSOU A MO- *      */
        /*"      *                    VER DIRETO DO CURSOR DA MOVIMENTO_VGAP.     *      */
        /*"      *                                                                *      */
        /*"      *         PROCURE POR V02 - LUIZ CARLOS.                         *      */
        /*"      ******************************************************************      */
        /*"      *   VERSOES.                                                     *      */
        /*"      *   01 -  19/06/2002 PASSOU A IDENTIFICAR PROPOSTA ELETRONICA    *      */
        /*"      *                    SIVPF DIGITADAS NO SIAS. PROCURE 190602.    *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
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
        /*"01  VIND-COD-ORIGEM-PROP              PIC S9(4) COMP VALUE +0.*/
        public IntBasis VIND_COD_ORIGEM_PROP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  CONTPARCELVA                      PIC  X(1) VALUE SPACES .*/
        public StringBasis CONTPARCELVA { get; set; } = new StringBasis(new PIC("X", "1", "X(1)"), @"");
        /*"01  COD-CBO-TIT                       PIC S9(9)  COMP.*/
        public IntBasis COD_CBO_TIT { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"01  COD-CBO-CONJ                      PIC S9(9)  COMP.*/
        public IntBasis COD_CBO_CONJ { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"01  VIND-COD-UF                       PIC S9(4)  COMP.*/
        public IntBasis VIND_COD_UF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  WAREA-AUXILIAR.*/
        public PF0612B_WAREA_AUXILIAR WAREA_AUXILIAR { get; set; } = new PF0612B_WAREA_AUXILIAR();
        public class PF0612B_WAREA_AUXILIAR : VarBasis
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
            /*"    05  VIND-NULL                     PIC S9(4) COMP VALUE -1.*/
            public IntBasis VIND_NULL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"), -1);
            /*"    05  W-PRAZO-PERCEPCAO             PIC 9(002)  VALUE ZEROS.*/
            public IntBasis W_PRAZO_PERCEPCAO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"    05  FILLER REDEFINES W-PRAZO-PERCEPCAO.*/
            private _REDEF_PF0612B_FILLER_0 _filler_0 { get; set; }
            public _REDEF_PF0612B_FILLER_0 FILLER_0
            {
                get { _filler_0 = new _REDEF_PF0612B_FILLER_0(); _.Move(W_PRAZO_PERCEPCAO, _filler_0); VarBasis.RedefinePassValue(W_PRAZO_PERCEPCAO, _filler_0, W_PRAZO_PERCEPCAO); _filler_0.ValueChanged += () => { _.Move(_filler_0, W_PRAZO_PERCEPCAO); }; return _filler_0; }
                set { VarBasis.RedefinePassValue(value, _filler_0, W_PRAZO_PERCEPCAO); }
            }  //Redefines
            public class _REDEF_PF0612B_FILLER_0 : VarBasis
            {
                /*"        07  W-PERCEPCAO               PIC X(002).*/
                public StringBasis W_PERCEPCAO { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"    05  W-NR-IDENTIDADE               PIC 9(008)  VALUE ZEROS.*/

                public _REDEF_PF0612B_FILLER_0()
                {
                    W_PERCEPCAO.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis W_NR_IDENTIDADE { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05  FILLER REDEFINES W-NR-IDENTIDADE.*/
            private _REDEF_PF0612B_FILLER_1 _filler_1 { get; set; }
            public _REDEF_PF0612B_FILLER_1 FILLER_1
            {
                get { _filler_1 = new _REDEF_PF0612B_FILLER_1(); _.Move(W_NR_IDENTIDADE, _filler_1); VarBasis.RedefinePassValue(W_NR_IDENTIDADE, _filler_1, W_NR_IDENTIDADE); _filler_1.ValueChanged += () => { _.Move(_filler_1, W_NR_IDENTIDADE); }; return _filler_1; }
                set { VarBasis.RedefinePassValue(value, _filler_1, W_NR_IDENTIDADE); }
            }  //Redefines
            public class _REDEF_PF0612B_FILLER_1 : VarBasis
            {
                /*"        07  W-NR-RG                   PIC X(008).*/
                public StringBasis W_NR_RG { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
                /*"    05  W-NSAS                        PIC 9(006).*/

                public _REDEF_PF0612B_FILLER_1()
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
            private _REDEF_PF0612B_FILLER_2 _filler_2 { get; set; }
            public _REDEF_PF0612B_FILLER_2 FILLER_2
            {
                get { _filler_2 = new _REDEF_PF0612B_FILLER_2(); _.Move(W_DATA_TRABALHO, _filler_2); VarBasis.RedefinePassValue(W_DATA_TRABALHO, _filler_2, W_DATA_TRABALHO); _filler_2.ValueChanged += () => { _.Move(_filler_2, W_DATA_TRABALHO); }; return _filler_2; }
                set { VarBasis.RedefinePassValue(value, _filler_2, W_DATA_TRABALHO); }
            }  //Redefines
            public class _REDEF_PF0612B_FILLER_2 : VarBasis
            {
                /*"        07  W-DIA-TRABALHO            PIC 9(002).*/
                public IntBasis W_DIA_TRABALHO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"        07  W-MES-TRABALHO            PIC 9(002).*/
                public IntBasis W_MES_TRABALHO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"        07  W-ANO-TRABALHO            PIC 9(004).*/
                public IntBasis W_ANO_TRABALHO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05  W-DATA-NASCIMENTO             PIC 9(008)  VALUE ZEROS.*/

                public _REDEF_PF0612B_FILLER_2()
                {
                    W_DIA_TRABALHO.ValueChanged += OnValueChanged;
                    W_MES_TRABALHO.ValueChanged += OnValueChanged;
                    W_ANO_TRABALHO.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis W_DATA_NASCIMENTO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05  FILLER REDEFINES W-DATA-NASCIMENTO.*/
            private _REDEF_PF0612B_FILLER_3 _filler_3 { get; set; }
            public _REDEF_PF0612B_FILLER_3 FILLER_3
            {
                get { _filler_3 = new _REDEF_PF0612B_FILLER_3(); _.Move(W_DATA_NASCIMENTO, _filler_3); VarBasis.RedefinePassValue(W_DATA_NASCIMENTO, _filler_3, W_DATA_NASCIMENTO); _filler_3.ValueChanged += () => { _.Move(_filler_3, W_DATA_NASCIMENTO); }; return _filler_3; }
                set { VarBasis.RedefinePassValue(value, _filler_3, W_DATA_NASCIMENTO); }
            }  //Redefines
            public class _REDEF_PF0612B_FILLER_3 : VarBasis
            {
                /*"        07  W-DIA-NASCIMENTO          PIC 9(002).*/
                public IntBasis W_DIA_NASCIMENTO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"        07  W-MES-NASCIMENTO          PIC 9(002).*/
                public IntBasis W_MES_NASCIMENTO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"        07  W-ANO-NASCIMENTO          PIC 9(004).*/
                public IntBasis W_ANO_NASCIMENTO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05  HOST-DT-TERVIG1               PIC X(010)  VALUE        '1999-12-31'.*/

                public _REDEF_PF0612B_FILLER_3()
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
            private _REDEF_PF0612B_W_DTMOVABE1 _w_dtmovabe1 { get; set; }
            public _REDEF_PF0612B_W_DTMOVABE1 W_DTMOVABE1
            {
                get { _w_dtmovabe1 = new _REDEF_PF0612B_W_DTMOVABE1(); _.Move(W_DTMOVABE, _w_dtmovabe1); VarBasis.RedefinePassValue(W_DTMOVABE, _w_dtmovabe1, W_DTMOVABE); _w_dtmovabe1.ValueChanged += () => { _.Move(_w_dtmovabe1, W_DTMOVABE); }; return _w_dtmovabe1; }
                set { VarBasis.RedefinePassValue(value, _w_dtmovabe1, W_DTMOVABE); }
            }  //Redefines
            public class _REDEF_PF0612B_W_DTMOVABE1 : VarBasis
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

                public _REDEF_PF0612B_W_DTMOVABE1()
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
            private _REDEF_PF0612B_W_DTMOVABE_I1 _w_dtmovabe_i1 { get; set; }
            public _REDEF_PF0612B_W_DTMOVABE_I1 W_DTMOVABE_I1
            {
                get { _w_dtmovabe_i1 = new _REDEF_PF0612B_W_DTMOVABE_I1(); _.Move(W_DTMOVABE_I, _w_dtmovabe_i1); VarBasis.RedefinePassValue(W_DTMOVABE_I, _w_dtmovabe_i1, W_DTMOVABE_I); _w_dtmovabe_i1.ValueChanged += () => { _.Move(_w_dtmovabe_i1, W_DTMOVABE_I); }; return _w_dtmovabe_i1; }
                set { VarBasis.RedefinePassValue(value, _w_dtmovabe_i1, W_DTMOVABE_I); }
            }  //Redefines
            public class _REDEF_PF0612B_W_DTMOVABE_I1 : VarBasis
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

                public _REDEF_PF0612B_W_DTMOVABE_I1()
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
            private _REDEF_PF0612B_W_DATA_SQL1 _w_data_sql1 { get; set; }
            public _REDEF_PF0612B_W_DATA_SQL1 W_DATA_SQL1
            {
                get { _w_data_sql1 = new _REDEF_PF0612B_W_DATA_SQL1(); _.Move(W_DATA_SQL, _w_data_sql1); VarBasis.RedefinePassValue(W_DATA_SQL, _w_data_sql1, W_DATA_SQL); _w_data_sql1.ValueChanged += () => { _.Move(_w_data_sql1, W_DATA_SQL); }; return _w_data_sql1; }
                set { VarBasis.RedefinePassValue(value, _w_data_sql1, W_DATA_SQL); }
            }  //Redefines
            public class _REDEF_PF0612B_W_DATA_SQL1 : VarBasis
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

                public _REDEF_PF0612B_W_DATA_SQL1()
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
            private _REDEF_PF0612B_FILLER_4 _filler_4 { get; set; }
            public _REDEF_PF0612B_FILLER_4 FILLER_4
            {
                get { _filler_4 = new _REDEF_PF0612B_FILLER_4(); _.Move(W_NR_SICOB, _filler_4); VarBasis.RedefinePassValue(W_NR_SICOB, _filler_4, W_NR_SICOB); _filler_4.ValueChanged += () => { _.Move(_filler_4, W_NR_SICOB); }; return _filler_4; }
                set { VarBasis.RedefinePassValue(value, _filler_4, W_NR_SICOB); }
            }  //Redefines
            public class _REDEF_PF0612B_FILLER_4 : VarBasis
            {
                /*"        07  W-NR-PROD-SICOB           PIC 9(003).*/
                public IntBasis W_NR_PROD_SICOB { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"        07  W-NR-NSAC-SICOB           PIC 9(006).*/
                public IntBasis W_NR_NSAC_SICOB { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"        07  W-NR-NSL-SICOB            PIC 9(006).*/
                public IntBasis W_NR_NSL_SICOB { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"    05  W-NOM-ORGAO-EXP               PIC X(030).*/

                public _REDEF_PF0612B_FILLER_4()
                {
                    W_NR_PROD_SICOB.ValueChanged += OnValueChanged;
                    W_NR_NSAC_SICOB.ValueChanged += OnValueChanged;
                    W_NR_NSL_SICOB.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis W_NOM_ORGAO_EXP { get; set; } = new StringBasis(new PIC("X", "30", "X(030)."), @"");
            /*"    05  FILLER REDEFINES W-NOM-ORGAO-EXP.*/
            private _REDEF_PF0612B_FILLER_5 _filler_5 { get; set; }
            public _REDEF_PF0612B_FILLER_5 FILLER_5
            {
                get { _filler_5 = new _REDEF_PF0612B_FILLER_5(); _.Move(W_NOM_ORGAO_EXP, _filler_5); VarBasis.RedefinePassValue(W_NOM_ORGAO_EXP, _filler_5, W_NOM_ORGAO_EXP); _filler_5.ValueChanged += () => { _.Move(_filler_5, W_NOM_ORGAO_EXP); }; return _filler_5; }
                set { VarBasis.RedefinePassValue(value, _filler_5, W_NOM_ORGAO_EXP); }
            }  //Redefines
            public class _REDEF_PF0612B_FILLER_5 : VarBasis
            {
                /*"        07  W-ORGAO-EXPEDIDOR         PIC X(005).*/
                public StringBasis W_ORGAO_EXPEDIDOR { get; set; } = new StringBasis(new PIC("X", "5", "X(005)."), @"");
                /*"        07  FILLER                    PIC X(025).*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)."), @"");
                /*"    05 W-OBTER-DADOS-RG               PIC  9(001) VALUE ZERO.*/

                public _REDEF_PF0612B_FILLER_5()
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
            private _REDEF_PF0612B_FILLER_7 _filler_7 { get; set; }
            public _REDEF_PF0612B_FILLER_7 FILLER_7
            {
                get { _filler_7 = new _REDEF_PF0612B_FILLER_7(); _.Move(W_NUM_PROPOSTA_NOVA, _filler_7); VarBasis.RedefinePassValue(W_NUM_PROPOSTA_NOVA, _filler_7, W_NUM_PROPOSTA_NOVA); _filler_7.ValueChanged += () => { _.Move(_filler_7, W_NUM_PROPOSTA_NOVA); }; return _filler_7; }
                set { VarBasis.RedefinePassValue(value, _filler_7, W_NUM_PROPOSTA_NOVA); }
            }  //Redefines
            public class _REDEF_PF0612B_FILLER_7 : VarBasis
            {
                /*"        07  W-NUM-PROPOSTA-ATUAL      PIC 9(013).*/
                public IntBasis W_NUM_PROPOSTA_ATUAL { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
                /*"        07  W-DV-PROPOSTA-NOVA        PIC 9(001).*/
                public IntBasis W_DV_PROPOSTA_NOVA { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    05  W-NUM-PROPOSTA                PIC 9(014).*/

                public _REDEF_PF0612B_FILLER_7()
                {
                    W_NUM_PROPOSTA_ATUAL.ValueChanged += OnValueChanged;
                    W_DV_PROPOSTA_NOVA.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis W_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
            /*"    05  CANAL  REDEFINES W-NUM-PROPOSTA.*/
            private _REDEF_PF0612B_CANAL _canal { get; set; }
            public _REDEF_PF0612B_CANAL CANAL
            {
                get { _canal = new _REDEF_PF0612B_CANAL(); _.Move(W_NUM_PROPOSTA, _canal); VarBasis.RedefinePassValue(W_NUM_PROPOSTA, _canal, W_NUM_PROPOSTA); _canal.ValueChanged += () => { _.Move(_canal, W_NUM_PROPOSTA); }; return _canal; }
                set { VarBasis.RedefinePassValue(value, _canal, W_NUM_PROPOSTA); }
            }  //Redefines
            public class _REDEF_PF0612B_CANAL : VarBasis
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

                public _REDEF_PF0612B_CANAL()
                {
                    W_CANAL_PROPOSTA.ValueChanged += OnValueChanged;
                    FILLER_8.ValueChanged += OnValueChanged;
                }

            }
            private _REDEF_PF0612B_FAIXAS _faixas { get; set; }
            public _REDEF_PF0612B_FAIXAS FAIXAS
            {
                get { _faixas = new _REDEF_PF0612B_FAIXAS(); _.Move(W_NUM_PROPOSTA, _faixas); VarBasis.RedefinePassValue(W_NUM_PROPOSTA, _faixas, W_NUM_PROPOSTA); _faixas.ValueChanged += () => { _.Move(_faixas, W_NUM_PROPOSTA); }; return _faixas; }
                set { VarBasis.RedefinePassValue(value, _faixas, W_NUM_PROPOSTA); }
            }  //Redefines
            public class _REDEF_PF0612B_FAIXAS : VarBasis
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

                public _REDEF_PF0612B_FAIXAS()
                {
                    FILLER_9.ValueChanged += OnValueChanged;
                    FAIXA_NUMERACAO.ValueChanged += OnValueChanged;
                    FILLER_10.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis W_NUMR_TITULO { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
            /*"    05  FILLER                      REDEFINES    W-NUMR-TITULO.*/
            private _REDEF_PF0612B_FILLER_11 _filler_11 { get; set; }
            public _REDEF_PF0612B_FILLER_11 FILLER_11
            {
                get { _filler_11 = new _REDEF_PF0612B_FILLER_11(); _.Move(W_NUMR_TITULO, _filler_11); VarBasis.RedefinePassValue(W_NUMR_TITULO, _filler_11, W_NUMR_TITULO); _filler_11.ValueChanged += () => { _.Move(_filler_11, W_NUMR_TITULO); }; return _filler_11; }
                set { VarBasis.RedefinePassValue(value, _filler_11, W_NUMR_TITULO); }
            }  //Redefines
            public class _REDEF_PF0612B_FILLER_11 : VarBasis
            {
                /*"      10    WTITL-ZEROS             PIC  9(002).*/
                public IntBasis WTITL_ZEROS { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10    WTITL-SEQUENCIA         PIC  9(010).*/
                public IntBasis WTITL_SEQUENCIA { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
                /*"      10    WTITL-DIGITO            PIC  9(001).*/
                public IntBasis WTITL_DIGITO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    05              DPARM01X.*/

                public _REDEF_PF0612B_FILLER_11()
                {
                    WTITL_ZEROS.ValueChanged += OnValueChanged;
                    WTITL_SEQUENCIA.ValueChanged += OnValueChanged;
                    WTITL_DIGITO.ValueChanged += OnValueChanged;
                }

            }
            public PF0612B_DPARM01X DPARM01X { get; set; } = new PF0612B_DPARM01X();
            public class PF0612B_DPARM01X : VarBasis
            {
                /*"      07            DPARM01           PIC  9(010).*/
                public IntBasis DPARM01 { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
                /*"      07            DPARM01-R         REDEFINES   DPARM01.*/
                private _REDEF_PF0612B_DPARM01_R _dparm01_r { get; set; }
                public _REDEF_PF0612B_DPARM01_R DPARM01_R
                {
                    get { _dparm01_r = new _REDEF_PF0612B_DPARM01_R(); _.Move(DPARM01, _dparm01_r); VarBasis.RedefinePassValue(DPARM01, _dparm01_r, DPARM01); _dparm01_r.ValueChanged += () => { _.Move(_dparm01_r, DPARM01); }; return _dparm01_r; }
                    set { VarBasis.RedefinePassValue(value, _dparm01_r, DPARM01); }
                }  //Redefines
                public class _REDEF_PF0612B_DPARM01_R : VarBasis
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

                    public _REDEF_PF0612B_DPARM01_R()
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

            /*"01  WSQLERRO.*/
        }
        public PF0612B_WSQLERRO WSQLERRO { get; set; } = new PF0612B_WSQLERRO();
        public class PF0612B_WSQLERRO : VarBasis
        {
            /*"      03   FILLER          PIC  X(014)    VALUE ' *** SQLERRMC '*/
            public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @" *** SQLERRMC ");
            /*"      03   WSQLERRMC       PIC  X(070)    VALUE SPACES.*/
            public StringBasis WSQLERRMC { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"");
            /*"01  WABEND*/
        }
        public PF0612B_WABEND WABEND { get; set; } = new PF0612B_WABEND();
        public class PF0612B_WABEND : VarBasis
        {
            /*"    05 FILLER.*/
            public PF0612B_FILLER_13 FILLER_13 { get; set; } = new PF0612B_FILLER_13();
            public class PF0612B_FILLER_13 : VarBasis
            {
                /*"      10    FILLER                   PIC  X(010) VALUE            'PF0612B  '.*/
                public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"PF0612B  ");
                /*"      10    FILLER                   PIC  X(028) VALUE            ' *** ERRO  EXEC SQL *** '.*/
                public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @" *** ERRO  EXEC SQL *** ");
                /*"      10    FILLER                   PIC  X(014) VALUE            '    SQLCODE = '.*/
                public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE = ");
                /*"      10    WSQLCODE                 PIC  ZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
                /*"      10    FILLER                   PIC  X(014)   VALUE            '   SQLERRD1 = '.*/
                public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD1 = ");
                /*"      10    WSQLERRD1                PIC  ZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLERRD1 { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
                /*"      10    FILLER                   PIC  X(014)   VALUE            '   SQLERRD2 = '.*/
                public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD2 = ");
                /*"      10    WSQLERRD2                PIC  ZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLERRD2 { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
                /*"      10    FILLER                   PIC  X(014)   VALUE            '   SQLERRD2 = '.*/
                public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD2 = ");
                /*"    05      LOCALIZA-ABEND-1.*/
            }
            public PF0612B_LOCALIZA_ABEND_1 LOCALIZA_ABEND_1 { get; set; } = new PF0612B_LOCALIZA_ABEND_1();
            public class PF0612B_LOCALIZA_ABEND_1 : VarBasis
            {
                /*"      10    FILLER                   PIC  X(012)   VALUE            'PARAGRAFO = '.*/
                public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"PARAGRAFO = ");
                /*"      10    PARAGRAFO                PIC  X(040)   VALUE SPACES.*/
                public StringBasis PARAGRAFO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"    05      LOCALIZA-ABEND-2.*/
            }
            public PF0612B_LOCALIZA_ABEND_2 LOCALIZA_ABEND_2 { get; set; } = new PF0612B_LOCALIZA_ABEND_2();
            public class PF0612B_LOCALIZA_ABEND_2 : VarBasis
            {
                /*"      10    FILLER                   PIC  X(012)   VALUE            'COMANDO   = '.*/
                public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"COMANDO   = ");
                /*"      10    COMANDO                  PIC  X(060)   VALUE SPACES.*/
                public StringBasis COMANDO { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"");
                /*"01    WS-HORAS.*/
            }
        }
        public PF0612B_WS_HORAS WS_HORAS { get; set; } = new PF0612B_WS_HORAS();
        public class PF0612B_WS_HORAS : VarBasis
        {
            /*"  03  WS-HORA-INI               PIC  X(008).*/
            public StringBasis WS_HORA_INI { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"  03  WS-HORA-INI-R REDEFINES WS-HORA-INI.*/
            private _REDEF_PF0612B_WS_HORA_INI_R _ws_hora_ini_r { get; set; }
            public _REDEF_PF0612B_WS_HORA_INI_R WS_HORA_INI_R
            {
                get { _ws_hora_ini_r = new _REDEF_PF0612B_WS_HORA_INI_R(); _.Move(WS_HORA_INI, _ws_hora_ini_r); VarBasis.RedefinePassValue(WS_HORA_INI, _ws_hora_ini_r, WS_HORA_INI); _ws_hora_ini_r.ValueChanged += () => { _.Move(_ws_hora_ini_r, WS_HORA_INI); }; return _ws_hora_ini_r; }
                set { VarBasis.RedefinePassValue(value, _ws_hora_ini_r, WS_HORA_INI); }
            }  //Redefines
            public class _REDEF_PF0612B_WS_HORA_INI_R : VarBasis
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

                public _REDEF_PF0612B_WS_HORA_INI_R()
                {
                    HI.ValueChanged += OnValueChanged;
                    MI.ValueChanged += OnValueChanged;
                    SI.ValueChanged += OnValueChanged;
                    DI.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WS_HORA_FIM { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"  03  WS-HORA-FIM-R REDEFINES WS-HORA-FIM.*/
            private _REDEF_PF0612B_WS_HORA_FIM_R _ws_hora_fim_r { get; set; }
            public _REDEF_PF0612B_WS_HORA_FIM_R WS_HORA_FIM_R
            {
                get { _ws_hora_fim_r = new _REDEF_PF0612B_WS_HORA_FIM_R(); _.Move(WS_HORA_FIM, _ws_hora_fim_r); VarBasis.RedefinePassValue(WS_HORA_FIM, _ws_hora_fim_r, WS_HORA_FIM); _ws_hora_fim_r.ValueChanged += () => { _.Move(_ws_hora_fim_r, WS_HORA_FIM); }; return _ws_hora_fim_r; }
                set { VarBasis.RedefinePassValue(value, _ws_hora_fim_r, WS_HORA_FIM); }
            }  //Redefines
            public class _REDEF_PF0612B_WS_HORA_FIM_R : VarBasis
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

                public _REDEF_PF0612B_WS_HORA_FIM_R()
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
        public PF0612B_TOTAIS_ROT TOTAIS_ROT { get; set; } = new PF0612B_TOTAIS_ROT();
        public class PF0612B_TOTAIS_ROT : VarBasis
        {
            /*"    03  FILLER  OCCURS 70 TIMES.*/
            public ListBasis<PF0612B_FILLER_22> FILLER_22 { get; set; } = new ListBasis<PF0612B_FILLER_22>(70);
            public class PF0612B_FILLER_22 : VarBasis
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
        public Copies.LXFPF028 LXFPF028 { get; set; } = new Copies.LXFPF028();
        public Copies.SPGE053W SPGE053W { get; set; } = new Copies.SPGE053W();
        public Copies.LXFCT004 LXFCT004 { get; set; } = new Copies.LXFCT004();
        public Copies.LBWPF002 LBWPF002 { get; set; } = new Copies.LBWPF002();
        public Dclgens.TARIBCEF TARIBCEF { get; set; } = new Dclgens.TARIBCEF();
        public Dclgens.SEGVGAP SEGVGAP { get; set; } = new Dclgens.SEGVGAP();
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
        public Dclgens.RELATORI RELATORI { get; set; } = new Dclgens.RELATORI();
        public Dclgens.GEDOCCLI GEDOCCLI { get; set; } = new Dclgens.GEDOCCLI();
        public Dclgens.PROPVA PROPVA { get; set; } = new Dclgens.PROPVA();
        public Dclgens.COBPRPVA COBPRPVA { get; set; } = new Dclgens.COBPRPVA();
        public Dclgens.ARQSIVPF ARQSIVPF { get; set; } = new Dclgens.ARQSIVPF();
        public Dclgens.HTCTBPVA HTCTBPVA { get; set; } = new Dclgens.HTCTBPVA();
        public PF0612B_MOVIMENTO_VGAP MOVIMENTO_VGAP { get; set; } = new PF0612B_MOVIMENTO_VGAP();
        public PF0612B_CUR_PARCELVA CUR_PARCELVA { get; set; } = new PF0612B_CUR_PARCELVA();
        public PF0612B_FUNDOCOMISVA FUNDOCOMISVA { get; set; } = new PF0612B_FUNDOCOMISVA();
        public PF0612B_BENEFICIARIOS BENEFICIARIOS { get; set; } = new PF0612B_BENEFICIARIOS();
        public PF0612B_EMAIL EMAIL { get; set; } = new PF0612B_EMAIL();
        public PF0612B_ENDERECOS ENDERECOS { get; set; } = new PF0612B_ENDERECOS();
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
            /*" -773- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -774- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -775- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -778- DISPLAY '************************************************' . */
            _.Display($"************************************************");

            /*" -779- DISPLAY '*               PROGRAMA PF0612B               *' . */
            _.Display($"*               PROGRAMA PF0612B               *");

            /*" -780- DISPLAY '* GERA ARQ DAS PROPOSTAS VIDA  EMITIDAS NO DIA *' . */
            _.Display($"* GERA ARQ DAS PROPOSTAS VIDA  EMITIDAS NO DIA *");

            /*" -781- DISPLAY '*           VERSAO: 33 - 25/04/2024            *' . */
            _.Display($"*           VERSAO: 33 - 25/04/2024            *");

            /*" -782- DISPLAY '************************************************' . */
            _.Display($"************************************************");

            /*" -791- DISPLAY '*  PF0612B - INICIO  EM ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2). */

            $"*  PF0612B - INICIO  EM {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
            .Display();

            /*" -793- INITIALIZE TOTAIS-ROT. */
            _.Initialize(
                TOTAIS_ROT
            );

            /*" -795- PERFORM R0005-00-OBTER-DATA-DIA. */

            R0005_00_OBTER_DATA_DIA_SECTION();

            /*" -797- PERFORM R0007-00-OBTER-DT-PROCE. */

            R0007_00_OBTER_DT_PROCE_SECTION();

            /*" -799- PERFORM R0010-00-ABRIR-ARQUIVOS. */

            R0010_00_ABRIR_ARQUIVOS_SECTION();

            /*" -801- PERFORM R0020-00-OBTER-MAX-NSAS. */

            R0020_00_OBTER_MAX_NSAS_SECTION();

            /*" -803- MOVE 1 TO W-CURSOR. */
            _.Move(1, WAREA_AUXILIAR.W_CURSOR);

            /*" -805- PERFORM R0050-00-SELECIONA-MOVTO */

            R0050_00_SELECIONA_MOVTO_SECTION();

            /*" -807- PERFORM R0070-00-LER-MOVTO */

            R0070_00_LER_MOVTO_SECTION();

            /*" -809- PERFORM R0080-00-GERAR-HEADER */

            R0080_00_GERAR_HEADER_SECTION();

            /*" -812- PERFORM R0150-00-PROCESSAR-MOVIMENTO UNTIL W-FIM-MOVTO-VGAP EQUAL 'FIM' . */

            while (!(WAREA_AUXILIAR.W_FIM_MOVTO_VGAP == "FIM"))
            {

                R0150_00_PROCESSAR_MOVIMENTO_SECTION();
            }

            /*" -814- PERFORM R1000-00-GERAR-TRAILLER. */

            R1000_00_GERAR_TRAILLER_SECTION();

            /*" -816- PERFORM R1050-00-CONTROLAR-ARQ-ENVIADO */

            R1050_00_CONTROLAR_ARQ_ENVIADO_SECTION();

            /*" -818- PERFORM R1100-00-GERAR-TOTAIS. */

            R1100_00_GERAR_TOTAIS_SECTION();

            /*" -820- PERFORM R1110-00-UPDATE-RELATORIOS. */

            R1110_00_UPDATE_RELATORIOS_SECTION();

            /*" -824- PERFORM R9988-00-FECHAR-ARQUIVOS. */

            R9988_00_FECHAR_ARQUIVOS_SECTION();

            /*" -824- PERFORM R9999-00-FINALIZAR. */

            R9999_00_FINALIZAR_SECTION();

        }

        [StopWatch]
        /*" R0005-00-OBTER-DATA-DIA-SECTION */
        private void R0005_00_OBTER_DATA_DIA_SECTION()
        {
            /*" -832- MOVE 'R0005-00-OBTER-DATA-DIA' TO PARAGRAFO. */
            _.Move("R0005-00-OBTER-DATA-DIA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -834- MOVE 'SELECT SEGUROS.SISTEMAS' TO COMANDO. */
            _.Move("SELECT SEGUROS.SISTEMAS", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -836- MOVE 'PF' TO SISTEMAS-IDE-SISTEMA OF DCLSISTEMAS. */
            _.Move("PF", SISTEMAS.DCLSISTEMAS.SISTEMAS_IDE_SISTEMA);

            /*" -842- PERFORM R0005_00_OBTER_DATA_DIA_DB_SELECT_1 */

            R0005_00_OBTER_DATA_DIA_DB_SELECT_1();

            /*" -847- MOVE SISTEMAS-DATA-MOV-ABERTO OF DCLSISTEMAS TO W-DTMOVABE. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, WAREA_AUXILIAR.W_DTMOVABE);

            /*" -849- MOVE W-DIA-MOVABE OF W-DTMOVABE1 TO W-DIA-MOVABE OF W-DTMOVABE-I1. */
            _.Move(WAREA_AUXILIAR.W_DTMOVABE1.W_DIA_MOVABE, WAREA_AUXILIAR.W_DTMOVABE_I1.W_DIA_MOVABE_0);

            /*" -851- MOVE W-MES-MOVABE OF W-DTMOVABE1 TO W-MES-MOVABE OF W-DTMOVABE-I1. */
            _.Move(WAREA_AUXILIAR.W_DTMOVABE1.W_MES_MOVABE, WAREA_AUXILIAR.W_DTMOVABE_I1.W_MES_MOVABE_0);

            /*" -854- MOVE W-ANO-MOVABE OF W-DTMOVABE1 TO W-ANO-MOVABE OF W-DTMOVABE-I1. */
            _.Move(WAREA_AUXILIAR.W_DTMOVABE1.W_ANO_MOVABE, WAREA_AUXILIAR.W_DTMOVABE_I1.W_ANO_MOVABE_0);

            /*" -856- MOVE '-' TO W-BARRA1 OF W-DTMOVABE-I1, W-BARRA2 OF W-DTMOVABE-I1. */
            _.Move("-", WAREA_AUXILIAR.W_DTMOVABE_I1.W_BARRA1_0);
            _.Move("-", WAREA_AUXILIAR.W_DTMOVABE_I1.W_BARRA2_0);


        }

        [StopWatch]
        /*" R0005-00-OBTER-DATA-DIA-DB-SELECT-1 */
        public void R0005_00_OBTER_DATA_DIA_DB_SELECT_1()
        {
            /*" -842- EXEC SQL SELECT DATA_MOV_ABERTO INTO :DCLSISTEMAS.SISTEMAS-DATA-MOV-ABERTO FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = :DCLSISTEMAS.SISTEMAS-IDE-SISTEMA WITH UR END-EXEC. */

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
            /*" -866- MOVE 'R0007-00-OBTER-DT-PROCE' TO PARAGRAFO. */
            _.Move("R0007-00-OBTER-DT-PROCE", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -868- MOVE 'SELECT SEGUROS.RELATORIOS' TO COMANDO. */
            _.Move("SELECT SEGUROS.RELATORIOS", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -875- PERFORM R0007_00_OBTER_DT_PROCE_DB_SELECT_1 */

            R0007_00_OBTER_DT_PROCE_DB_SELECT_1();

            /*" -878- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -879- DISPLAY 'PF0612B - FIM ANORMAL' */
                _.Display($"PF0612B - FIM ANORMAL");

                /*" -880- DISPLAY '          ERRO SELECT RELATORIOS' */
                _.Display($"          ERRO SELECT RELATORIOS");

                /*" -882- DISPLAY '          SQLCODE........................ ' SQLCODE */
                _.Display($"          SQLCODE........................ {DB.SQLCODE}");

                /*" -884- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


            /*" -885- DISPLAY '** PF0612B - REFERENCIA DO PROCESSAMENTO =>  ' RELATORI-DATA-REFERENCIA OF DCLRELATORIOS. */
            _.Display($"** PF0612B - REFERENCIA DO PROCESSAMENTO =>  {RELATORI.DCLRELATORIOS.RELATORI_DATA_REFERENCIA}");

        }

        [StopWatch]
        /*" R0007-00-OBTER-DT-PROCE-DB-SELECT-1 */
        public void R0007_00_OBTER_DT_PROCE_DB_SELECT_1()
        {
            /*" -875- EXEC SQL SELECT DATA_REFERENCIA INTO :DCLRELATORIOS.RELATORI-DATA-REFERENCIA FROM SEGUROS.RELATORIOS WHERE IDE_SISTEMA = 'PF' AND COD_RELATORIO = 'PF0612B' WITH UR END-EXEC. */

            var r0007_00_OBTER_DT_PROCE_DB_SELECT_1_Query1 = new R0007_00_OBTER_DT_PROCE_DB_SELECT_1_Query1()
            {
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
            /*" -895- MOVE 'R0010-00-ABRIR-ARQUIVOS' TO PARAGRAFO. */
            _.Move("R0010-00-ABRIR-ARQUIVOS", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -897- MOVE 'OPEN' TO COMANDO. */
            _.Move("OPEN", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -897- OPEN OUTPUT MOVTO-PRP-SASSE. */
            MOVTO_PRP_SASSE.Open(REG_PRP_SASSE);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0010_SAIDA*/

        [StopWatch]
        /*" R0020-00-OBTER-MAX-NSAS-SECTION */
        private void R0020_00_OBTER_MAX_NSAS_SECTION()
        {
            /*" -907- MOVE 'R0020-00-OBTER-MAX-NSAS' TO PARAGRAFO. */
            _.Move("R0020-00-OBTER-MAX-NSAS", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -909- MOVE 'SELECT MAX ARQUIVOS-SIVPF' TO COMANDO. */
            _.Move("SELECT MAX ARQUIVOS-SIVPF", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -916- PERFORM R0020_00_OBTER_MAX_NSAS_DB_SELECT_1 */

            R0020_00_OBTER_MAX_NSAS_DB_SELECT_1();

            /*" -919- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -920- DISPLAY 'PF0612B - FIM ANORMAL' */
                _.Display($"PF0612B - FIM ANORMAL");

                /*" -921- DISPLAY '          ERRO SELECT MAX ARQUIVOS-SIVPF' */
                _.Display($"          ERRO SELECT MAX ARQUIVOS-SIVPF");

                /*" -923- DISPLAY '          SQLCODE........................ ' SQLCODE */
                _.Display($"          SQLCODE........................ {DB.SQLCODE}");

                /*" -924- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -926- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


            /*" -929- MOVE ARQSIVPF-NSAS-SIVPF OF DCLARQUIVOS-SIVPF TO W-NSAS. */
            _.Move(ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF, WAREA_AUXILIAR.W_NSAS);

            /*" -931- ADD 1 TO W-NSAS. */
            WAREA_AUXILIAR.W_NSAS.Value = WAREA_AUXILIAR.W_NSAS + 1;

            /*" -931- MOVE W-NSAS TO ARQSIVPF-NSAS-SIVPF OF DCLARQUIVOS-SIVPF. */
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
            /*" -941- MOVE 'R0050-00-SELECIONA-MOVTO' TO PARAGRAFO. */
            _.Move("R0050-00-SELECIONA-MOVTO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -943- MOVE 'DECLER MOVIMENTO' TO COMANDO. */
            _.Move("DECLER MOVIMENTO", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -944- ACCEPT W-TIME FROM TIME. */
            _.Move(_.AcceptDate("TIME"), WAREA_AUXILIAR.W_TIME);

            /*" -946- MOVE W-TIME TO W-TIME-EDIT. */
            _.Move(WAREA_AUXILIAR.W_TIME, WAREA_AUXILIAR.W_TIME_EDIT);

            /*" -949- DISPLAY '** PF0612B ** INICIO DECLARE V0MOVIMENTO...  ' W-TIME-EDIT. */
            _.Display($"** PF0612B ** INICIO DECLARE V0MOVIMENTO...  {WAREA_AUXILIAR.W_TIME_EDIT}");

            /*" -1048- PERFORM R0050_00_SELECIONA_MOVTO_DB_DECLARE_1 */

            R0050_00_SELECIONA_MOVTO_DB_DECLARE_1();

            /*" -1050- PERFORM R0050_00_SELECIONA_MOVTO_DB_OPEN_1 */

            R0050_00_SELECIONA_MOVTO_DB_OPEN_1();

            /*" -1054- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -1057- MOVE 2 TO W-CURSOR. */
                _.Move(2, WAREA_AUXILIAR.W_CURSOR);
            }


            /*" -1058- ACCEPT W-TIME FROM TIME. */
            _.Move(_.AcceptDate("TIME"), WAREA_AUXILIAR.W_TIME);

            /*" -1060- MOVE W-TIME TO W-TIME-EDIT. */
            _.Move(WAREA_AUXILIAR.W_TIME, WAREA_AUXILIAR.W_TIME_EDIT);

            /*" -1062- DISPLAY '** PF0612B ** FIM    DECLARE V0MOVIMENTO...  ' W-TIME-EDIT */
            _.Display($"** PF0612B ** FIM    DECLARE V0MOVIMENTO...  {WAREA_AUXILIAR.W_TIME_EDIT}");

            /*" -1062- DISPLAY ' ' . */
            _.Display($" ");

        }

        [StopWatch]
        /*" R0050-00-SELECIONA-MOVTO-DB-DECLARE-1 */
        public void R0050_00_SELECIONA_MOVTO_DB_DECLARE_1()
        {
            /*" -1048- EXEC SQL DECLARE MOVIMENTO-VGAP CURSOR FOR SELECT B.NUM_APOLICE , B.COD_SUBGRUPO , B.COD_FONTE , B.NUM_PROPOSTA , B.TIPO_SEGURADO , B.NUM_CERTIFICADO , B.DAC_CERTIFICADO , B.TIPO_INCLUSAO , B.COD_CLIENTE , B.COD_AGENCIADOR , B.COD_CORRETOR , B.COD_PLANOVGAP , B.COD_PLANOAP , B.FAIXA , B.AUTOR_AUM_AUTOMAT , B.TIPO_BENEFICIARIO , B.PERI_PAGAMENTO , B.PERI_RENOVACAO , B.COD_OCUPACAO , B.ESTADO_CIVIL , B.IDE_SEXO , B.COD_PROFISSAO , B.NATURALIDADE , B.OCORR_ENDERECO , B.OCORR_END_COBRAN , B.BCO_COBRANCA , B.AGE_COBRANCA , B.DAC_COBRANCA , B.NUM_MATRICULA , B.NUM_CTA_CORRENTE , B.DAC_CTA_CORRENTE , B.VAL_SALARIO , B.TIPO_SALARIO , B.TIPO_PLANO , B.PCT_CONJUGE_VG , B.PCT_CONJUGE_AP , B.QTD_SAL_MORNATU , B.QTD_SAL_MORACID , B.QTD_SAL_INVPERM , B.TAXA_AP_MORACID , B.TAXA_AP_INVPERM , B.TAXA_AP_AMDS , B.TAXA_AP_DH , B.TAXA_AP_DIT , B.TAXA_VG , B.IMP_MORNATU_ANT , B.IMP_MORNATU_ATU , B.IMP_MORACID_ANT , B.IMP_MORACID_ATU , B.IMP_INVPERM_ANT , B.IMP_INVPERM_ATU , B.IMP_AMDS_ANT , B.IMP_AMDS_ATU , B.IMP_DH_ANT , B.IMP_DH_ATU , B.IMP_DIT_ANT , B.IMP_DIT_ATU , B.PRM_VG_ANT , B.PRM_VG_ATU , B.PRM_AP_ANT , B.PRM_AP_ATU , B.COD_OPERACAO , B.DATA_AVERBACAO , B.DATA_INCLUSAO , B.COD_SUBGRUPO_TRANS , B.SIT_REGISTRO , B.COD_USUARIO , A.COD_PRODUTO FROM SEGUROS.PRODUTOS_VG A, SEGUROS.MOVIMENTO_VGAP B, SEGUROS.PRODUTOS_SIVPF C WHERE B.NUM_APOLICE = A.NUM_APOLICE AND B.COD_SUBGRUPO = A.COD_SUBGRUPO AND A.COD_PRODUTO = C.COD_PRODUTO AND C.COD_EMPRESA_SIVPF = 1 AND A.COD_PRODUTO NOT IN (7708, 9341, 9350, 9348) AND A.ESTR_EMISS = 'MULT' AND A.ORIG_PRODU IN ( 'MULT' , 'VIDAZUL' , 'CAMP' ) AND B.DATA_INCLUSAO >= :DCLRELATORIOS.RELATORI-DATA-REFERENCIA AND B.DATA_INCLUSAO <= :DCLSISTEMAS.SISTEMAS-DATA-MOV-ABERTO AND B.COD_OPERACAO BETWEEN 100 AND 199 ORDER BY B.DATA_INCLUSAO WITH UR END-EXEC. */
            MOVIMENTO_VGAP = new PF0612B_MOVIMENTO_VGAP(true);
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
							FROM SEGUROS.PRODUTOS_VG A
							, 
							SEGUROS.MOVIMENTO_VGAP B
							, 
							SEGUROS.PRODUTOS_SIVPF C 
							WHERE B.NUM_APOLICE = A.NUM_APOLICE 
							AND B.COD_SUBGRUPO = A.COD_SUBGRUPO 
							AND A.COD_PRODUTO = C.COD_PRODUTO 
							AND C.COD_EMPRESA_SIVPF = 1 
							AND A.COD_PRODUTO NOT IN 
							(7708
							, 9341
							, 9350
							, 9348) 
							AND A.ESTR_EMISS = 'MULT' 
							AND A.ORIG_PRODU IN 
							( 'MULT'
							, 'VIDAZUL'
							, 'CAMP' ) 
							AND B.DATA_INCLUSAO >= 
							'{RELATORI.DCLRELATORIOS.RELATORI_DATA_REFERENCIA}' 
							AND B.DATA_INCLUSAO <= 
							'{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}' 
							AND B.COD_OPERACAO BETWEEN 100 AND 199 
							ORDER BY B.DATA_INCLUSAO";

                return query;
            }
            MOVIMENTO_VGAP.GetQueryEvent += GetQuery_MOVIMENTO_VGAP;

        }

        [StopWatch]
        /*" R0050-00-SELECIONA-MOVTO-DB-OPEN-1 */
        public void R0050_00_SELECIONA_MOVTO_DB_OPEN_1()
        {
            /*" -1050- EXEC SQL OPEN MOVIMENTO-VGAP END-EXEC. */

            MOVIMENTO_VGAP.Open();

        }

        [StopWatch]
        /*" R0215-00-LER-PARCELVA-DB-DECLARE-1 */
        public void R0215_00_LER_PARCELVA_DB_DECLARE_1()
        {
            /*" -1525- EXEC SQL DECLARE CUR-PARCELVA CURSOR FOR SELECT PREMIO_VG, PREMIO_AP, DATA_MOVIMENTO FROM SEGUROS.HIST_CONT_PARCELVA WHERE NUM_CERTIFICADO =: MOVVGAP-NUM-CERTIFICADO AND NUM_PARCELA = 1 AND COD_OPERACAO BETWEEN 199 AND 300 ORDER BY NUM_CERTIFICADO,OCORR_HISTORICO WITH UR END-EXEC. */
            CUR_PARCELVA = new PF0612B_CUR_PARCELVA(true);
            string GetQuery_CUR_PARCELVA()
            {
                var query = @$"SELECT PREMIO_VG
							, 
							PREMIO_AP
							, 
							DATA_MOVIMENTO 
							FROM SEGUROS.HIST_CONT_PARCELVA 
							WHERE 
							NUM_CERTIFICADO ='{MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_NUM_CERTIFICADO}' 
							AND NUM_PARCELA = 1 
							AND COD_OPERACAO BETWEEN 199 AND 300 
							ORDER BY NUM_CERTIFICADO
							,OCORR_HISTORICO";

                return query;
            }
            CUR_PARCELVA.GetQueryEvent += GetQuery_CUR_PARCELVA;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0050_SAIDA*/

        [StopWatch]
        /*" R0070-00-LER-MOVTO-SECTION */
        private void R0070_00_LER_MOVTO_SECTION()
        {
            /*" -1072- MOVE 'R0070-00-LER-MOVTO' TO PARAGRAFO. */
            _.Move("R0070-00-LER-MOVTO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1074- MOVE 'FETCH MOVIMENTO-VGAP' TO COMANDO. */
            _.Move("FETCH MOVIMENTO-VGAP", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1144- PERFORM R0070_00_LER_MOVTO_DB_FETCH_1 */

            R0070_00_LER_MOVTO_DB_FETCH_1();

            /*" -1147- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -1148- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1149- MOVE 'FIM' TO W-FIM-MOVTO-VGAP */
                    _.Move("FIM", WAREA_AUXILIAR.W_FIM_MOVTO_VGAP);

                    /*" -1149- PERFORM R0070_00_LER_MOVTO_DB_CLOSE_1 */

                    R0070_00_LER_MOVTO_DB_CLOSE_1();

                    /*" -1151- ELSE */
                }
                else
                {


                    /*" -1152- DISPLAY 'PF0612B - FIM ANORMAL' */
                    _.Display($"PF0612B - FIM ANORMAL");

                    /*" -1154- DISPLAY '          ERRO FETCH CURSOR V0MOVIMENTO  ' SQLCODE */
                    _.Display($"          ERRO FETCH CURSOR V0MOVIMENTO  {DB.SQLCODE}");

                    /*" -1155- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -1156- PERFORM R9999-00-FINALIZAR */

                    R9999_00_FINALIZAR_SECTION();

                    /*" -1157- END-IF */
                }


                /*" -1158- ELSE */
            }
            else
            {


                /*" -1161- ADD 1 TO W-NSL, W-CONTROLE */
                WAREA_AUXILIAR.W_NSL.Value = WAREA_AUXILIAR.W_NSL + 1;
                WAREA_AUXILIAR.W_CONTROLE.Value = WAREA_AUXILIAR.W_CONTROLE + 1;

                /*" -1173- COMPUTE W-TOT-PROCESSADO = W-QTD-LD-TIPO-1 + W-QTD-LD-TIPO-2 + W-QTD-LD-TIPO-3 + W-QTD-LD-TIPO-4 + W-QTD-LD-TIPO-5 + W-QTD-LD-TIPO-6 + W-QTD-LD-TIPO-7 + W-QTD-LD-TIPO-8 + W-QTD-LD-TIPO-9 + W-QTD-LD-TIPO-A + W-QTD-LD-TIPO-B + W-QTD-LD-TIPO-C + W-QTD-LD-TIPO-D + W-QTD-LD-TIPO-E + W-QTD-LD-TIPO-F + W-QTD-LD-TIPO-G + W-QTD-LD-TIPO-H + W-QTD-LD-TIPO-I + W-QTD-LD-TIPO-J */
                WAREA_AUXILIAR.W_TOT_PROCESSADO.Value = WAREA_AUXILIAR.W_QTD_LD_TIPO_1 + WAREA_AUXILIAR.W_QTD_LD_TIPO_2 + WAREA_AUXILIAR.W_QTD_LD_TIPO_3 + WAREA_AUXILIAR.W_QTD_LD_TIPO_4 + WAREA_AUXILIAR.W_QTD_LD_TIPO_5 + WAREA_AUXILIAR.W_QTD_LD_TIPO_6 + WAREA_AUXILIAR.W_QTD_LD_TIPO_7 + WAREA_AUXILIAR.W_QTD_LD_TIPO_8 + WAREA_AUXILIAR.W_QTD_LD_TIPO_9 + WAREA_AUXILIAR.W_QTD_LD_TIPO_A + WAREA_AUXILIAR.W_QTD_LD_TIPO_B + WAREA_AUXILIAR.W_QTD_LD_TIPO_C + WAREA_AUXILIAR.W_QTD_LD_TIPO_D + WAREA_AUXILIAR.W_QTD_LD_TIPO_E + WAREA_AUXILIAR.W_QTD_LD_TIPO_F + WAREA_AUXILIAR.W_QTD_LD_TIPO_G + WAREA_AUXILIAR.W_QTD_LD_TIPO_H + WAREA_AUXILIAR.W_QTD_LD_TIPO_I + WAREA_AUXILIAR.W_QTD_LD_TIPO_J;

                /*" -1174- IF W-CONTROLE > 999 */

                if (WAREA_AUXILIAR.W_CONTROLE > 999)
                {

                    /*" -1175- ACCEPT W-TIME FROM TIME */
                    _.Move(_.AcceptDate("TIME"), WAREA_AUXILIAR.W_TIME);

                    /*" -1176- MOVE W-TIME TO W-TIME-EDIT */
                    _.Move(WAREA_AUXILIAR.W_TIME, WAREA_AUXILIAR.W_TIME_EDIT);

                    /*" -1178- MOVE ZEROS TO W-CONTROLE */
                    _.Move(0, WAREA_AUXILIAR.W_CONTROLE);

                    /*" -1181- DISPLAY '** PF0612B ** TOTAL LIDO ..  ' W-NSL ' ' W-TIME-EDIT */

                    $"** PF0612B ** TOTAL LIDO ..  {WAREA_AUXILIAR.W_NSL} {WAREA_AUXILIAR.W_TIME_EDIT}"
                    .Display();

                    /*" -1182- END-IF */
                }


                /*" -1184- END-IF. */
            }


            /*" -1187- DISPLAY '- TRATANDO A PROPOSTA ' MOVVGAP-NUM-PROPOSTA '  - NUM CERTIFICADO ' MOVVGAP-NUM-CERTIFICADO. */

            $"- TRATANDO A PROPOSTA {MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_NUM_PROPOSTA}  - NUM CERTIFICADO {MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_NUM_CERTIFICADO}"
            .Display();

            /*" -1188- IF W-TOT-PROCESSADO GREATER 99999 */

            if (WAREA_AUXILIAR.W_TOT_PROCESSADO > 99999)
            {

                /*" -1189- IF W-FIM-MOVTO-VGAP NOT EQUAL 'FIM' */

                if (WAREA_AUXILIAR.W_FIM_MOVTO_VGAP != "FIM")
                {

                    /*" -1190- MOVE 'FIM' TO W-FIM-MOVTO-VGAP */
                    _.Move("FIM", WAREA_AUXILIAR.W_FIM_MOVTO_VGAP);

                    /*" -1190- PERFORM R0070_00_LER_MOVTO_DB_CLOSE_2 */

                    R0070_00_LER_MOVTO_DB_CLOSE_2();

                    /*" -1192- END-IF */
                }


                /*" -1192- END-IF. */
            }


        }

        [StopWatch]
        /*" R0070-00-LER-MOVTO-DB-FETCH-1 */
        public void R0070_00_LER_MOVTO_DB_FETCH_1()
        {
            /*" -1144- EXEC SQL FETCH MOVIMENTO-VGAP INTO :MOVVGAP-NUM-APOLICE , :MOVVGAP-COD-SUBGRUPO , :MOVVGAP-COD-FONTE , :MOVVGAP-NUM-PROPOSTA , :MOVVGAP-TIPO-SEGURADO , :MOVVGAP-NUM-CERTIFICADO , :MOVVGAP-DAC-CERTIFICADO , :MOVVGAP-TIPO-INCLUSAO , :MOVVGAP-COD-CLIENTE , :MOVVGAP-COD-AGENCIADOR , :MOVVGAP-COD-CORRETOR , :MOVVGAP-COD-PLANOVGAP , :MOVVGAP-COD-PLANOAP , :MOVVGAP-FAIXA , :MOVVGAP-AUTOR-AUM-AUTOMAT , :MOVVGAP-TIPO-BENEFICIARIO , :MOVVGAP-PERI-PAGAMENTO , :MOVVGAP-PERI-RENOVACAO , :MOVVGAP-COD-OCUPACAO , :MOVVGAP-ESTADO-CIVIL , :MOVVGAP-IDE-SEXO , :MOVVGAP-COD-PROFISSAO , :MOVVGAP-NATURALIDADE , :MOVVGAP-OCORR-ENDERECO , :MOVVGAP-OCORR-END-COBRAN , :MOVVGAP-BCO-COBRANCA , :MOVVGAP-AGE-COBRANCA , :MOVVGAP-DAC-COBRANCA , :MOVVGAP-NUM-MATRICULA , :MOVVGAP-NUM-CTA-CORRENTE , :MOVVGAP-DAC-CTA-CORRENTE , :MOVVGAP-VAL-SALARIO , :MOVVGAP-TIPO-SALARIO , :MOVVGAP-TIPO-PLANO , :MOVVGAP-PCT-CONJUGE-VG , :MOVVGAP-PCT-CONJUGE-AP , :MOVVGAP-QTD-SAL-MORNATU , :MOVVGAP-QTD-SAL-MORACID , :MOVVGAP-QTD-SAL-INVPERM , :MOVVGAP-TAXA-AP-MORACID , :MOVVGAP-TAXA-AP-INVPERM , :MOVVGAP-TAXA-AP-AMDS , :MOVVGAP-TAXA-AP-DH , :MOVVGAP-TAXA-AP-DIT , :MOVVGAP-TAXA-VG , :MOVVGAP-IMP-MORNATU-ANT , :MOVVGAP-IMP-MORNATU-ATU , :MOVVGAP-IMP-MORACID-ANT , :MOVVGAP-IMP-MORACID-ATU , :MOVVGAP-IMP-INVPERM-ANT , :MOVVGAP-IMP-INVPERM-ATU , :MOVVGAP-IMP-AMDS-ANT , :MOVVGAP-IMP-AMDS-ATU , :MOVVGAP-IMP-DH-ANT , :MOVVGAP-IMP-DH-ATU , :MOVVGAP-IMP-DIT-ANT , :MOVVGAP-IMP-DIT-ATU , :MOVVGAP-PRM-VG-ANT , :MOVVGAP-PRM-VG-ATU , :MOVVGAP-PRM-AP-ANT , :MOVVGAP-PRM-AP-ATU , :MOVVGAP-COD-OPERACAO , :MOVVGAP-DATA-AVERBACAO , :MOVVGAP-DATA-INCLUSAO , :MOVVGAP-COD-SUBGRUPO-TRANS , :MOVVGAP-SIT-REGISTRO , :MOVVGAP-COD-USUARIO , :DCLPRODUTOS-VG.COD-PRODUTO END-EXEC. */

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
            }

        }

        [StopWatch]
        /*" R0070-00-LER-MOVTO-DB-CLOSE-1 */
        public void R0070_00_LER_MOVTO_DB_CLOSE_1()
        {
            /*" -1149- EXEC SQL CLOSE MOVIMENTO-VGAP END-EXEC */

            MOVIMENTO_VGAP.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0070_SAIDA*/

        [StopWatch]
        /*" R0070-00-LER-MOVTO-DB-CLOSE-2 */
        public void R0070_00_LER_MOVTO_DB_CLOSE_2()
        {
            /*" -1190- EXEC SQL CLOSE MOVIMENTO-VGAP END-EXEC */

            MOVIMENTO_VGAP.Close();

        }

        [StopWatch]
        /*" R0080-00-GERAR-HEADER-SECTION */
        private void R0080_00_GERAR_HEADER_SECTION()
        {
            /*" -1202- MOVE 'R0080-00-GERAR-HEADER' TO PARAGRAFO. */
            _.Move("R0080-00-GERAR-HEADER", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1204- MOVE 'WRITE REG-HEADER' TO COMANDO. */
            _.Move("WRITE REG-HEADER", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1206- MOVE SPACES TO REG-HEADER. */
            _.Move("", LXFPF990.REG_HEADER);

            /*" -1209- MOVE 'H' TO RH-TIPO-REG OF REG-HEADER */
            _.Move("H", LXFPF990.REG_HEADER.RH_TIPO_REG);

            /*" -1212- MOVE 'PRPSASSE' TO RH-NOME OF REG-HEADER */
            _.Move("PRPSASSE", LXFPF990.REG_HEADER.RH_NOME);

            /*" -1213- MOVE W-DIA-MOVABE OF W-DTMOVABE1 TO W-DIA-TRABALHO */
            _.Move(WAREA_AUXILIAR.W_DTMOVABE1.W_DIA_MOVABE, WAREA_AUXILIAR.FILLER_2.W_DIA_TRABALHO);

            /*" -1214- MOVE W-MES-MOVABE OF W-DTMOVABE1 TO W-MES-TRABALHO */
            _.Move(WAREA_AUXILIAR.W_DTMOVABE1.W_MES_MOVABE, WAREA_AUXILIAR.FILLER_2.W_MES_TRABALHO);

            /*" -1216- MOVE W-ANO-MOVABE OF W-DTMOVABE1 TO W-ANO-TRABALHO */
            _.Move(WAREA_AUXILIAR.W_DTMOVABE1.W_ANO_MOVABE, WAREA_AUXILIAR.FILLER_2.W_ANO_TRABALHO);

            /*" -1219- MOVE W-DATA-TRABALHO TO RH-DATA-GERACAO OF REG-HEADER */
            _.Move(WAREA_AUXILIAR.W_DATA_TRABALHO, LXFPF990.REG_HEADER.RH_DATA_GERACAO);

            /*" -1222- MOVE 4 TO RH-SIST-ORIGEM OF REG-HEADER */
            _.Move(4, LXFPF990.REG_HEADER.RH_SIST_ORIGEM);

            /*" -1225- MOVE 1 TO RH-SIST-DESTINO OF REG-HEADER */
            _.Move(1, LXFPF990.REG_HEADER.RH_SIST_DESTINO);

            /*" -1228- MOVE ARQSIVPF-NSAS-SIVPF OF DCLARQUIVOS-SIVPF TO RH-NSAS OF REG-HEADER */
            _.Move(ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF, LXFPF990.REG_HEADER.RH_NSAS);

            /*" -1230- MOVE 1 TO RH-TIPO-ARQUIVO OF REG-HEADER. */
            _.Move(1, LXFPF990.REG_HEADER.RH_TIPO_ARQUIVO);

            /*" -1230- WRITE REG-PRP-SASSE FROM REG-HEADER. */
            _.Move(LXFPF990.REG_HEADER.GetMoveValues(), REG_PRP_SASSE);

            MOVTO_PRP_SASSE.Write(REG_PRP_SASSE.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0080_SAIDA*/

        [StopWatch]
        /*" R0150-00-PROCESSAR-MOVIMENTO-SECTION */
        private void R0150_00_PROCESSAR_MOVIMENTO_SECTION()
        {
            /*" -1240- MOVE 'R0150-00-PROCESSA-MOVIMENTO' TO PARAGRAFO. */
            _.Move("R0150-00-PROCESSA-MOVIMENTO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1242- MOVE '    ' TO COMANDO. */
            _.Move("    ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1244- MOVE SPACES TO REG-CLIENTES. */
            _.Move("", LBFPF011.REG_CLIENTES);

            /*" -1248- IF MOVVGAP-NUM-CERTIFICADO NOT LESS 10000000000 AND MOVVGAP-NUM-CERTIFICADO NOT GREATER 19999999999 */

            if (MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_NUM_CERTIFICADO >= 10000000000 && MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_NUM_CERTIFICADO <= 19999999999)
            {

                /*" -1250- MOVE MOVVGAP-NUM-CERTIFICADO TO W-NUM-PROPOSTA-ATUAL */
                _.Move(MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_NUM_CERTIFICADO, WAREA_AUXILIAR.FILLER_7.W_NUM_PROPOSTA_ATUAL);

                /*" -1252- MOVE MOVVGAP-DAC-CERTIFICADO TO W-DV-PROPOSTA-NOVA */
                _.Move(MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_DAC_CERTIFICADO, WAREA_AUXILIAR.FILLER_7.W_DV_PROPOSTA_NOVA);

                /*" -1253- ELSE */
            }
            else
            {


                /*" -1258- MOVE MOVVGAP-NUM-CERTIFICADO TO W-NUM-PROPOSTA-NOVA. */
                _.Move(MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_NUM_CERTIFICADO, WAREA_AUXILIAR.W_NUM_PROPOSTA_NOVA);
            }


            /*" -1260- MOVE 'NAO' TO W-EXISTE-FIDELIZ. */
            _.Move("NAO", WAREA_AUXILIAR.W_EXISTE_FIDELIZ);

            /*" -1262- PERFORM R0200-00-LER-PROP-FIDELIZ. */

            R0200_00_LER_PROP_FIDELIZ_SECTION();

            /*" -1265- IF ORIGEM-PROPOSTA OF DCLPROPOSTA-FIDELIZ NOT EQUAL 1005 AND 1009 AND 1010 */

            if (!PROPFID.DCLPROPOSTA_FIDELIZ.ORIGEM_PROPOSTA.In("1005", "1009", "1010"))
            {

                /*" -1266- IF W-EXISTE-FIDELIZ EQUAL 'SIM' */

                if (WAREA_AUXILIAR.W_EXISTE_FIDELIZ == "SIM")
                {

                    /*" -1267- ADD 1 TO W-DESPREZADO */
                    WAREA_AUXILIAR.W_DESPREZADO.Value = WAREA_AUXILIAR.W_DESPREZADO + 1;

                    /*" -1268- IF W-FIM-MOVTO-VGAP NOT EQUAL 'FIM' */

                    if (WAREA_AUXILIAR.W_FIM_MOVTO_VGAP != "FIM")
                    {

                        /*" -1269- GO TO R0150-LEITURA */

                        R0150_LEITURA(); //GOTO
                        return;

                        /*" -1270- ELSE */
                    }
                    else
                    {


                        /*" -1271- GO TO R0150-SAIDA */
                        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0150_SAIDA*/ //GOTO
                        return;

                        /*" -1272- END-IF */
                    }


                    /*" -1273- END-IF */
                }


                /*" -1280- END-IF */
            }


            /*" -1283- MOVE MOVVGAP-NUM-CERTIFICADO TO NUM-PROPOSTA-SIVPF OF DCLCONVERSAO-SICOB */
            _.Move(MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_NUM_CERTIFICADO, COVSICOB.DCLCONVERSAO_SICOB.NUM_PROPOSTA_SIVPF);

            /*" -1285- MOVE 2 TO W-CONVERSAO */
            _.Move(2, WAREA_AUXILIAR.W_CONVERSAO);

            /*" -1287- PERFORM R0205-ACESSAR-CONVERSAO-SICOB. */

            R0205_ACESSAR_CONVERSAO_SICOB_SECTION();

            /*" -1288- IF CONVERSAO-CADASTRADA */

            if (WAREA_AUXILIAR.W_CONVERSAO["CONVERSAO_CADASTRADA"])
            {

                /*" -1290- MOVE NUM-SICOB OF DCLCONVERSAO-SICOB TO NUM-SICOB OF DCLPROPOSTA-FIDELIZ */
                _.Move(COVSICOB.DCLCONVERSAO_SICOB.NUM_SICOB, PROPFID.DCLPROPOSTA_FIDELIZ.NUM_SICOB);

                /*" -1291- ELSE */
            }
            else
            {


                /*" -1298- MOVE MOVVGAP-NUM-CERTIFICADO TO NUM-SICOB OF DCLPROPOSTA-FIDELIZ. */
                _.Move(MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_NUM_CERTIFICADO, PROPFID.DCLPROPOSTA_FIDELIZ.NUM_SICOB);
            }


            /*" -1300- MOVE 'NAO' TO W-EXISTE-FIDELIZ. */
            _.Move("NAO", WAREA_AUXILIAR.W_EXISTE_FIDELIZ);

            /*" -1302- PERFORM R0210-00-LER-SICOB. */

            R0210_00_LER_SICOB_SECTION();

            /*" -1305- IF ORIGEM-PROPOSTA OF DCLPROPOSTA-FIDELIZ NOT EQUAL 1005 AND 1009 AND 1010 */

            if (!PROPFID.DCLPROPOSTA_FIDELIZ.ORIGEM_PROPOSTA.In("1005", "1009", "1010"))
            {

                /*" -1306- IF W-EXISTE-FIDELIZ EQUAL 'SIM' */

                if (WAREA_AUXILIAR.W_EXISTE_FIDELIZ == "SIM")
                {

                    /*" -1307- ADD 1 TO W-DESPREZADO */
                    WAREA_AUXILIAR.W_DESPREZADO.Value = WAREA_AUXILIAR.W_DESPREZADO + 1;

                    /*" -1308- IF W-FIM-MOVTO-VGAP NOT EQUAL 'FIM' */

                    if (WAREA_AUXILIAR.W_FIM_MOVTO_VGAP != "FIM")
                    {

                        /*" -1309- GO TO R0150-LEITURA */

                        R0150_LEITURA(); //GOTO
                        return;

                        /*" -1310- ELSE */
                    }
                    else
                    {


                        /*" -1311- GO TO R0150-SAIDA */
                        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0150_SAIDA*/ //GOTO
                        return;

                        /*" -1312- END-IF */
                    }


                    /*" -1313- END-IF */
                }


                /*" -1316- END-IF */
            }


            /*" -1321- PERFORM R0250-00-LER-PROPOSTAVA. */

            R0250_00_LER_PROPOSTAVA_SECTION();

            /*" -1322- IF SQLCODE NOT EQUAL 100 */

            if (DB.SQLCODE != 100)
            {

                /*" -1323- IF MOVVGAP-DATA-INCLUSAO = '9999-12-31' */

                if (MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_DATA_INCLUSAO == "9999-12-31")
                {

                    /*" -1325- MOVE MOVVGAP-DATA-AVERBACAO TO RELATORI-DATA-REFERENCIA OF DCLRELATORIOS */
                    _.Move(MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_DATA_AVERBACAO, RELATORI.DCLRELATORIOS.RELATORI_DATA_REFERENCIA);

                    /*" -1326- ELSE */
                }
                else
                {


                    /*" -1328- MOVE MOVVGAP-DATA-INCLUSAO TO RELATORI-DATA-REFERENCIA OF DCLRELATORIOS */
                    _.Move(MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_DATA_INCLUSAO, RELATORI.DCLRELATORIOS.RELATORI_DATA_REFERENCIA);

                    /*" -1330- END-IF. */
                }

            }


            /*" -1331- IF VIND-COD-ORIGEM-PROP LESS ZEROS */

            if (VIND_COD_ORIGEM_PROP < 00)
            {

                /*" -1334- MOVE ZEROS TO COD-ORIGEM-PROPOSTA OF DCLPROPOSTAS-VA. */
                _.Move(0, PROPVA.DCLPROPOSTAS_VA.COD_ORIGEM_PROPOSTA);
            }


            /*" -1336- IF COD-ORIGEM-PROPOSTA OF DCLPROPOSTAS-VA = 12 OR 1005 OR 1009 OR 1010 */

            if (PROPVA.DCLPROPOSTAS_VA.COD_ORIGEM_PROPOSTA.In("12", "1005", "1009", "1010"))
            {

                /*" -1337- PERFORM R0215-00-LER-PARCELVA */

                R0215_00_LER_PARCELVA_SECTION();

                /*" -1338- ELSE */
            }
            else
            {


                /*" -1339- PERFORM R0500-00-LER-RCAP */

                R0500_00_LER_RCAP_SECTION();

                /*" -1341- END-IF */
            }


            /*" -1342- IF VIND-FAIXA-RENDA-IND LESS 0 */

            if (VIND_FAIXA_RENDA_IND < 0)
            {

                /*" -1344- MOVE SPACE TO R1-RENDA-INDIVIDUAL. */
                _.Move("", LBFPF011.REG_CLIENTES.R1_RENDA_INDIVIDUAL);
            }


            /*" -1345- IF SQLCODE NOT EQUAL 100 */

            if (DB.SQLCODE != 100)
            {

                /*" -1350- PERFORM R0300-00-LER-CLIENTE */

                R0300_00_LER_CLIENTE_SECTION();

                /*" -1352- IF VIND-DTNASCI LESS ZEROS AND CGCCPF OF DCLCLIENTES EQUAL ZEROS */

                if (VIND_DTNASCI < 00 && CLIENTE.DCLCLIENTES.CGCCPF == 00)
                {

                    /*" -1353- DISPLAY 'PF0612B - SEGURO NAO ENVIADO A CEF' */
                    _.Display($"PF0612B - SEGURO NAO ENVIADO A CEF");

                    /*" -1356- DISPLAY '          CPF/DT.NASCIMENTO ZEROS   ' NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ '  ' COD-CLIENTE OF DCLCLIENTES */

                    $"          CPF/DT.NASCIMENTO ZEROS   {PROPFID.DCLPROPOSTA_FIDELIZ.NUM_PROPOSTA_SIVPF}  {CLIENTE.DCLCLIENTES.COD_CLIENTE}"
                    .Display();

                    /*" -1357- ADD 1 TO W-DESPREZADO */
                    WAREA_AUXILIAR.W_DESPREZADO.Value = WAREA_AUXILIAR.W_DESPREZADO + 1;

                    /*" -1358- ELSE */
                }
                else
                {


                    /*" -1359- PERFORM R0350-00-LER-ENDERECO */

                    R0350_00_LER_ENDERECO_SECTION();

                    /*" -1360- PERFORM R0400-00-LER-PROFISSAO */

                    R0400_00_LER_PROFISSAO_SECTION();

                    /*" -1372- PERFORM R0450-00-LER-PRODUTOS-SIVPF */

                    R0450_00_LER_PRODUTOS_SIVPF_SECTION();

                    /*" -1373- PERFORM R0550-00-LER-OPCAOPAGVA */

                    R0550_00_LER_OPCAOPAGVA_SECTION();

                    /*" -1374- PERFORM R0570-00-LER-COMISSAO */

                    R0570_00_LER_COMISSAO_SECTION();

                    /*" -1375- PERFORM R0580-00-OBTER-VAL-TARIFA */

                    R0580_00_OBTER_VAL_TARIFA_SECTION();

                    /*" -1376- PERFORM R0600-00-GERAR-REGISTRO-TP1 */

                    R0600_00_GERAR_REGISTRO_TP1_SECTION();

                    /*" -1377- PERFORM R0650-00-GERAR-REGISTRO-TP2 */

                    R0650_00_GERAR_REGISTRO_TP2_SECTION();

                    /*" -1378- PERFORM R0700-00-GERAR-REGISTRO-TP3 */

                    R0700_00_GERAR_REGISTRO_TP3_SECTION();

                    /*" -1379- PERFORM R0750-PROCESSAR-BENEFICIARIOS */

                    R0750_PROCESSAR_BENEFICIARIOS_SECTION();

                    /*" -1381- IF ORIGEM-PROPOSTA OF DCLPROPOSTA-FIDELIZ NOT EQUAL 1005 AND 1009 AND 1010 */

                    if (!PROPFID.DCLPROPOSTA_FIDELIZ.ORIGEM_PROPOSTA.In("1005", "1009", "1010"))
                    {

                        /*" -1382- PERFORM R3000-GERAR-TB-CORPORATIVAS */

                        R3000_GERAR_TB_CORPORATIVAS_SECTION();

                        /*" -1383- END-IF. */
                    }

                }

            }


            /*" -1383- PERFORM R0950-00-GERAR-REGISTRO-TPD. */

            R0950_00_GERAR_REGISTRO_TPD_SECTION();

            /*" -0- FLUXCONTROL_PERFORM R0150_LEITURA */

            R0150_LEITURA();

        }

        [StopWatch]
        /*" R0150-LEITURA */
        private void R0150_LEITURA(bool isPerform = false)
        {
            /*" -1388- IF W-FIM-MOVTO-VGAP NOT EQUAL 'FIM' */

            if (WAREA_AUXILIAR.W_FIM_MOVTO_VGAP != "FIM")
            {

                /*" -1388- PERFORM R0070-00-LER-MOVTO. */

                R0070_00_LER_MOVTO_SECTION();
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0150_SAIDA*/

        [StopWatch]
        /*" R0200-00-LER-PROP-FIDELIZ-SECTION */
        private void R0200_00_LER_PROP_FIDELIZ_SECTION()
        {
            /*" -1398- MOVE 'R0200-00-LER-PROP-FIDELIZ' TO PARAGRAFO. */
            _.Move("R0200-00-LER-PROP-FIDELIZ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1400- MOVE 'SELECT PROPOSTA-FIDELIZ' TO COMANDO. */
            _.Move("SELECT PROPOSTA-FIDELIZ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1403- MOVE MOVVGAP-NUM-CERTIFICADO TO NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ. */
            _.Move(MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_NUM_CERTIFICADO, PROPFID.DCLPROPOSTA_FIDELIZ.NUM_PROPOSTA_SIVPF);

            /*" -1417- PERFORM R0200_00_LER_PROP_FIDELIZ_DB_SELECT_1 */

            R0200_00_LER_PROP_FIDELIZ_DB_SELECT_1();

            /*" -1420- IF SQLCODE EQUAL 00 */

            if (DB.SQLCODE == 00)
            {

                /*" -1421- MOVE 'SIM' TO W-EXISTE-FIDELIZ */
                _.Move("SIM", WAREA_AUXILIAR.W_EXISTE_FIDELIZ);

                /*" -1422- ELSE */
            }
            else
            {


                /*" -1423- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1424- MOVE 'NAO' TO W-EXISTE-FIDELIZ */
                    _.Move("NAO", WAREA_AUXILIAR.W_EXISTE_FIDELIZ);

                    /*" -1425- ELSE */
                }
                else
                {


                    /*" -1426- DISPLAY 'PF0612B - FIM ANORMAL' */
                    _.Display($"PF0612B - FIM ANORMAL");

                    /*" -1427- DISPLAY '          ERRO SELECT PROPOSTA-FIDELIZ' */
                    _.Display($"          ERRO SELECT PROPOSTA-FIDELIZ");

                    /*" -1429- DISPLAY '          NUMERO DA PROPOSTA......... ' NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ */
                    _.Display($"          NUMERO DA PROPOSTA......... {PROPFID.DCLPROPOSTA_FIDELIZ.NUM_PROPOSTA_SIVPF}");

                    /*" -1431- DISPLAY '          SQLCODE.................... ' SQLCODE */
                    _.Display($"          SQLCODE.................... {DB.SQLCODE}");

                    /*" -1432- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -1432- PERFORM R9999-00-FINALIZAR. */

                    R9999_00_FINALIZAR_SECTION();
                }

            }


        }

        [StopWatch]
        /*" R0200-00-LER-PROP-FIDELIZ-DB-SELECT-1 */
        public void R0200_00_LER_PROP_FIDELIZ_DB_SELECT_1()
        {
            /*" -1417- EXEC SQL SELECT SIT_PROPOSTA, NUM_SICOB, ORIGEM_PROPOSTA, IND_TP_PROPOSTA INTO :DCLPROPOSTA-FIDELIZ.SIT-PROPOSTA, :DCLPROPOSTA-FIDELIZ.NUM-SICOB , :DCLPROPOSTA-FIDELIZ.ORIGEM-PROPOSTA, :DCLPROPOSTA-FIDELIZ.IND-TP-PROPOSTA :VIND-NULL FROM SEGUROS.PROPOSTA_FIDELIZ WHERE NUM_PROPOSTA_SIVPF = :DCLPROPOSTA-FIDELIZ.NUM-PROPOSTA-SIVPF AND COD_PRODUTO_SIVPF <> 48 WITH UR END-EXEC. */

            var r0200_00_LER_PROP_FIDELIZ_DB_SELECT_1_Query1 = new R0200_00_LER_PROP_FIDELIZ_DB_SELECT_1_Query1()
            {
                NUM_PROPOSTA_SIVPF = PROPFID.DCLPROPOSTA_FIDELIZ.NUM_PROPOSTA_SIVPF.ToString(),
            };

            var executed_1 = R0200_00_LER_PROP_FIDELIZ_DB_SELECT_1_Query1.Execute(r0200_00_LER_PROP_FIDELIZ_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SIT_PROPOSTA, PROPFID.DCLPROPOSTA_FIDELIZ.SIT_PROPOSTA);
                _.Move(executed_1.NUM_SICOB, PROPFID.DCLPROPOSTA_FIDELIZ.NUM_SICOB);
                _.Move(executed_1.ORIGEM_PROPOSTA, PROPFID.DCLPROPOSTA_FIDELIZ.ORIGEM_PROPOSTA);
                _.Move(executed_1.IND_TP_PROPOSTA, PROPFID.DCLPROPOSTA_FIDELIZ.IND_TP_PROPOSTA);
                _.Move(executed_1.VIND_NULL, WAREA_AUXILIAR.VIND_NULL);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_SAIDA*/

        [StopWatch]
        /*" R0205-ACESSAR-CONVERSAO-SICOB-SECTION */
        private void R0205_ACESSAR_CONVERSAO_SICOB_SECTION()
        {
            /*" -1442- MOVE 'R0205-ACESSAR-CONVERSAO-SICOB' TO PARAGRAFO. */
            _.Move("R0205-ACESSAR-CONVERSAO-SICOB", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1444- MOVE 'SELECT CONVERSAO-SICOB' TO COMANDO. */
            _.Move("SELECT CONVERSAO-SICOB", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1451- PERFORM R0205_ACESSAR_CONVERSAO_SICOB_DB_SELECT_1 */

            R0205_ACESSAR_CONVERSAO_SICOB_DB_SELECT_1();

            /*" -1454- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -1455- IF SQLCODE NOT EQUAL 100 */

                if (DB.SQLCODE != 100)
                {

                    /*" -1456- DISPLAY 'PF0612B FIM ANORMAL' */
                    _.Display($"PF0612B FIM ANORMAL");

                    /*" -1457- DISPLAY '        ERRO SELECT TAB. CONVERSAO-SICOB' */
                    _.Display($"        ERRO SELECT TAB. CONVERSAO-SICOB");

                    /*" -1459- DISPLAY '        NUM DA PROPOSTA .... ' NUM-PROPOSTA-SIVPF OF DCLCONVERSAO-SICOB */
                    _.Display($"        NUM DA PROPOSTA .... {COVSICOB.DCLCONVERSAO_SICOB.NUM_PROPOSTA_SIVPF}");

                    /*" -1460- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -1462- PERFORM R9999-00-FINALIZAR. */

                    R9999_00_FINALIZAR_SECTION();
                }

            }


            /*" -1463- IF SQLCODE EQUAL 00 */

            if (DB.SQLCODE == 00)
            {

                /*" -1463- MOVE 1 TO W-CONVERSAO. */
                _.Move(1, WAREA_AUXILIAR.W_CONVERSAO);
            }


        }

        [StopWatch]
        /*" R0205-ACESSAR-CONVERSAO-SICOB-DB-SELECT-1 */
        public void R0205_ACESSAR_CONVERSAO_SICOB_DB_SELECT_1()
        {
            /*" -1451- EXEC SQL SELECT NUM_SICOB INTO :DCLCONVERSAO-SICOB.NUM-SICOB FROM SEGUROS.CONVERSAO_SICOB WHERE NUM_PROPOSTA_SIVPF = :DCLCONVERSAO-SICOB.NUM-PROPOSTA-SIVPF WITH UR END-EXEC. */

            var r0205_ACESSAR_CONVERSAO_SICOB_DB_SELECT_1_Query1 = new R0205_ACESSAR_CONVERSAO_SICOB_DB_SELECT_1_Query1()
            {
                NUM_PROPOSTA_SIVPF = COVSICOB.DCLCONVERSAO_SICOB.NUM_PROPOSTA_SIVPF.ToString(),
            };

            var executed_1 = R0205_ACESSAR_CONVERSAO_SICOB_DB_SELECT_1_Query1.Execute(r0205_ACESSAR_CONVERSAO_SICOB_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.NUM_SICOB, COVSICOB.DCLCONVERSAO_SICOB.NUM_SICOB);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0205_SAIDA*/

        [StopWatch]
        /*" R0210-00-LER-SICOB-SECTION */
        private void R0210_00_LER_SICOB_SECTION()
        {
            /*" -1473- MOVE 'R0210-00-LER-SICOB' TO PARAGRAFO. */
            _.Move("R0210-00-LER-SICOB", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1475- MOVE 'SELECT PROPOSTA-FIDELIZ' TO COMANDO. */
            _.Move("SELECT PROPOSTA-FIDELIZ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1484- PERFORM R0210_00_LER_SICOB_DB_SELECT_1 */

            R0210_00_LER_SICOB_DB_SELECT_1();

            /*" -1487- IF SQLCODE EQUAL 00 */

            if (DB.SQLCODE == 00)
            {

                /*" -1488- MOVE 'SIM' TO W-EXISTE-FIDELIZ */
                _.Move("SIM", WAREA_AUXILIAR.W_EXISTE_FIDELIZ);

                /*" -1489- ELSE */
            }
            else
            {


                /*" -1490- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1491- MOVE 'NAO' TO W-EXISTE-FIDELIZ */
                    _.Move("NAO", WAREA_AUXILIAR.W_EXISTE_FIDELIZ);

                    /*" -1492- ELSE */
                }
                else
                {


                    /*" -1493- DISPLAY 'PF0612B - FIM ANORMAL' */
                    _.Display($"PF0612B - FIM ANORMAL");

                    /*" -1494- DISPLAY '          ERRO SELECT PROPOSTA-FIDELIZ' */
                    _.Display($"          ERRO SELECT PROPOSTA-FIDELIZ");

                    /*" -1496- DISPLAY '          NUMERO DO SICOB............ ' NUM-SICOB OF DCLPROPOSTA-FIDELIZ */
                    _.Display($"          NUMERO DO SICOB............ {PROPFID.DCLPROPOSTA_FIDELIZ.NUM_SICOB}");

                    /*" -1498- DISPLAY '          SQLCODE.................... ' SQLCODE */
                    _.Display($"          SQLCODE.................... {DB.SQLCODE}");

                    /*" -1499- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -1499- PERFORM R9999-00-FINALIZAR. */

                    R9999_00_FINALIZAR_SECTION();
                }

            }


        }

        [StopWatch]
        /*" R0210-00-LER-SICOB-DB-SELECT-1 */
        public void R0210_00_LER_SICOB_DB_SELECT_1()
        {
            /*" -1484- EXEC SQL SELECT SIT_PROPOSTA, NUM_PROPOSTA_SIVPF INTO :DCLPROPOSTA-FIDELIZ.SIT-PROPOSTA, :DCLPROPOSTA-FIDELIZ.NUM-PROPOSTA-SIVPF FROM SEGUROS.PROPOSTA_FIDELIZ WHERE NUM_SICOB = :DCLPROPOSTA-FIDELIZ.NUM-SICOB WITH UR END-EXEC. */

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
        /*" R0215-00-LER-PARCELVA-SECTION */
        private void R0215_00_LER_PARCELVA_SECTION()
        {
            /*" -1509- MOVE 'R0215-00-LER-PARCELVA' TO PARAGRAFO. */
            _.Move("R0215-00-LER-PARCELVA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1510- MOVE 'SELECT PARCELVA' TO COMANDO. */
            _.Move("SELECT PARCELVA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1512- MOVE 'N' TO CONTPARCELVA. */
            _.Move("N", CONTPARCELVA);

            /*" -1525- PERFORM R0215_00_LER_PARCELVA_DB_DECLARE_1 */

            R0215_00_LER_PARCELVA_DB_DECLARE_1();

            /*" -1528- PERFORM R0215_00_LER_PARCELVA_DB_OPEN_1 */

            R0215_00_LER_PARCELVA_DB_OPEN_1();

            /*" -1531- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -1532- DISPLAY '          PF0612B -  FIM ANORMAL' */
                _.Display($"          PF0612B -  FIM ANORMAL");

                /*" -1533- DISPLAY '          ERRO OPEN CURSOR CUR-PARCELVA' */
                _.Display($"          ERRO OPEN CURSOR CUR-PARCELVA");

                /*" -1535- DISPLAY '          NUMERO CERTIFICADO........... ' MOVVGAP-NUM-CERTIFICADO */
                _.Display($"          NUMERO CERTIFICADO........... {MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_NUM_CERTIFICADO}");

                /*" -1537- DISPLAY '          SQLCODE...................... ' SQLCODE */
                _.Display($"          SQLCODE...................... {DB.SQLCODE}");

                /*" -1538- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -1540- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


            /*" -1546- PERFORM R0215_00_LER_PARCELVA_DB_FETCH_1 */

            R0215_00_LER_PARCELVA_DB_FETCH_1();

            /*" -1549- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -1551- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1552- PERFORM R0216-00-TRATA-COBER-PROPST */

                    R0216_00_TRATA_COBER_PROPST_SECTION();

                    /*" -1553- ELSE */
                }
                else
                {


                    /*" -1554- DISPLAY '          PF0612B - FIM ANORMAL' */
                    _.Display($"          PF0612B - FIM ANORMAL");

                    /*" -1555- DISPLAY '          ERRO FETCHT CURSOR CUR-PARCELVA' */
                    _.Display($"          ERRO FETCHT CURSOR CUR-PARCELVA");

                    /*" -1557- DISPLAY '          NUMERO CERTIFICADO............. ' MOVVGAP-NUM-CERTIFICADO */
                    _.Display($"          NUMERO CERTIFICADO............. {MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_NUM_CERTIFICADO}");

                    /*" -1559- DISPLAY '          SQLCODE........................ ' SQLCODE */
                    _.Display($"          SQLCODE........................ {DB.SQLCODE}");

                    /*" -1560- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -1561- PERFORM R9999-00-FINALIZAR */

                    R9999_00_FINALIZAR_SECTION();

                    /*" -1562- ELSE */
                }

            }
            else
            {


                /*" -1564- MOVE 'S' TO CONTPARCELVA. */
                _.Move("S", CONTPARCELVA);
            }


            /*" -1564- PERFORM R0215_00_LER_PARCELVA_DB_CLOSE_1 */

            R0215_00_LER_PARCELVA_DB_CLOSE_1();

            /*" -1567- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -1568- DISPLAY '          PF0612B - FIM ANORMAL' */
                _.Display($"          PF0612B - FIM ANORMAL");

                /*" -1569- DISPLAY '          ERRO CLOSE CURSOR CUR-PARCELVA' */
                _.Display($"          ERRO CLOSE CURSOR CUR-PARCELVA");

                /*" -1571- DISPLAY '          NUMERO CERTIFICADO............ ' MOVVGAP-NUM-CERTIFICADO */
                _.Display($"          NUMERO CERTIFICADO............ {MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_NUM_CERTIFICADO}");

                /*" -1573- DISPLAY '          SQLCODE....................... ' SQLCODE */
                _.Display($"          SQLCODE....................... {DB.SQLCODE}");

                /*" -1574- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -1574- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R0215-00-LER-PARCELVA-DB-OPEN-1 */
        public void R0215_00_LER_PARCELVA_DB_OPEN_1()
        {
            /*" -1528- EXEC SQL OPEN CUR-PARCELVA END-EXEC. */

            CUR_PARCELVA.Open();

        }

        [StopWatch]
        /*" R0570-00-LER-COMISSAO-DB-DECLARE-1 */
        public void R0570_00_LER_COMISSAO_DB_DECLARE_1()
        {
            /*" -2170- EXEC SQL DECLARE FUNDOCOMISVA CURSOR FOR SELECT NUM_CERTIFICADO , VAL_COMISSAO_VG , VAL_COMISSAO_AP FROM SEGUROS.FUNDO_COMISSAO_VA WHERE NUM_CERTIFICADO = :DCLFUNDO-COMISSAO-VA.NUM-CERTIFICADO AND COD_OPERACAO = :DCLFUNDO-COMISSAO-VA.COD-OPERACAO WITH UR END-EXEC. */
            FUNDOCOMISVA = new PF0612B_FUNDOCOMISVA(true);
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
        /*" R0215-00-LER-PARCELVA-DB-FETCH-1 */
        public void R0215_00_LER_PARCELVA_DB_FETCH_1()
        {
            /*" -1546- EXEC SQL FETCH CUR-PARCELVA INTO :DCLHIST-CONT-PARCELVA.PREMIO-VG, :DCLHIST-CONT-PARCELVA.PREMIO-AP, :DCLHIST-CONT-PARCELVA.DATA-MOVIMENTO END-EXEC. */

            if (CUR_PARCELVA.Fetch())
            {
                _.Move(CUR_PARCELVA.DCLHIST_CONT_PARCELVA_PREMIO_VG, HTCTBPVA.DCLHIST_CONT_PARCELVA.PREMIO_VG);
                _.Move(CUR_PARCELVA.DCLHIST_CONT_PARCELVA_PREMIO_AP, HTCTBPVA.DCLHIST_CONT_PARCELVA.PREMIO_AP);
                _.Move(CUR_PARCELVA.DCLHIST_CONT_PARCELVA_DATA_MOVIMENTO, HTCTBPVA.DCLHIST_CONT_PARCELVA.DATA_MOVIMENTO);
            }

        }

        [StopWatch]
        /*" R0215-00-LER-PARCELVA-DB-CLOSE-1 */
        public void R0215_00_LER_PARCELVA_DB_CLOSE_1()
        {
            /*" -1564- EXEC SQL CLOSE CUR-PARCELVA END-EXEC. */

            CUR_PARCELVA.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0215_SAIDA*/

        [StopWatch]
        /*" R0216-00-TRATA-COBER-PROPST-SECTION */
        private void R0216_00_TRATA_COBER_PROPST_SECTION()
        {
            /*" -1584- MOVE 'R0216-00-TRATA-COBER-PROPST' TO PARAGRAFO. */
            _.Move("R0216-00-TRATA-COBER-PROPST", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1586- MOVE 'SELECT HIS_COBER_PROPOST' TO COMANDO. */
            _.Move("SELECT HIS_COBER_PROPOST", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1596- PERFORM R0216_00_TRATA_COBER_PROPST_DB_SELECT_1 */

            R0216_00_TRATA_COBER_PROPST_DB_SELECT_1();

            /*" -1600- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -1601- DISPLAY '          PF0612B - FIM ANORMAL' */
                _.Display($"          PF0612B - FIM ANORMAL");

                /*" -1602- DISPLAY '          ERRO SELECT HIS_COBER_PROPOST' */
                _.Display($"          ERRO SELECT HIS_COBER_PROPOST");

                /*" -1604- DISPLAY '          NUMERO CERTIFICADO............ ' MOVVGAP-NUM-CERTIFICADO */
                _.Display($"          NUMERO CERTIFICADO............ {MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_NUM_CERTIFICADO}");

                /*" -1606- DISPLAY '          SQLCODE....................... ' SQLCODE */
                _.Display($"          SQLCODE....................... {DB.SQLCODE}");

                /*" -1607- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -1607- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R0216-00-TRATA-COBER-PROPST-DB-SELECT-1 */
        public void R0216_00_TRATA_COBER_PROPST_DB_SELECT_1()
        {
            /*" -1596- EXEC SQL SELECT VLPREMIO INTO :DCLHIS-COBER-PROPOST.VLPREMIO FROM SEGUROS.HIS_COBER_PROPOST WHERE NUM_CERTIFICADO = :MOVVGAP-NUM-CERTIFICADO AND OCORR_HISTORICO = 1 AND COD_OPERACAO BETWEEN 200 AND 299 WITH UR END-EXEC. */

            var r0216_00_TRATA_COBER_PROPST_DB_SELECT_1_Query1 = new R0216_00_TRATA_COBER_PROPST_DB_SELECT_1_Query1()
            {
                MOVVGAP_NUM_CERTIFICADO = MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = R0216_00_TRATA_COBER_PROPST_DB_SELECT_1_Query1.Execute(r0216_00_TRATA_COBER_PROPST_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.VLPREMIO, COBPRPVA.DCLHIS_COBER_PROPOST.VLPREMIO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0216_SAIDA*/

        [StopWatch]
        /*" R0250-00-LER-PROPOSTAVA-SECTION */
        private void R0250_00_LER_PROPOSTAVA_SECTION()
        {
            /*" -1616- MOVE 'R0250-00-LER-PROPOSTAVA' TO PARAGRAFO. */
            _.Move("R0250-00-LER-PROPOSTAVA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1618- MOVE 'SELECT PROPOSTA-VA' TO COMANDO. */
            _.Move("SELECT PROPOSTA-VA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1621- MOVE MOVVGAP-NUM-CERTIFICADO TO NUM-CERTIFICADO OF DCLPROPOSTAS-VA. */
            _.Move(MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_NUM_CERTIFICADO, PROPVA.DCLPROPOSTAS_VA.NUM_CERTIFICADO);

            /*" -1718- PERFORM R0250_00_LER_PROPOSTAVA_DB_SELECT_1 */

            R0250_00_LER_PROPOSTAVA_DB_SELECT_1();

            /*" -1721- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -1722- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1723- ADD 1 TO W-DESPREZADO */
                    WAREA_AUXILIAR.W_DESPREZADO.Value = WAREA_AUXILIAR.W_DESPREZADO + 1;

                    /*" -1726- DISPLAY 'PF0612B - CERTIFICADO NAO EXISTE PROPOSTAVA ' NUM-CERTIFICADO OF DCLPROPOSTAS-VA '  SITUACAO ' SIT-REGISTRO OF DCLPROPOSTAS-VA */

                    $"PF0612B - CERTIFICADO NAO EXISTE PROPOSTAVA {PROPVA.DCLPROPOSTAS_VA.NUM_CERTIFICADO}  SITUACAO {PROPVA.DCLPROPOSTAS_VA.SIT_REGISTRO}"
                    .Display();

                    /*" -1727- ELSE */
                }
                else
                {


                    /*" -1728- DISPLAY 'PF0612B - FIM ANORMAL' */
                    _.Display($"PF0612B - FIM ANORMAL");

                    /*" -1729- DISPLAY '          ERRO SELECT PROPOSTA-VA' */
                    _.Display($"          ERRO SELECT PROPOSTA-VA");

                    /*" -1731- DISPLAY '          NUMERO CERTIFICADO..... ' NUM-CERTIFICADO OF DCLPROPOSTAS-VA */
                    _.Display($"          NUMERO CERTIFICADO..... {PROPVA.DCLPROPOSTAS_VA.NUM_CERTIFICADO}");

                    /*" -1733- DISPLAY '          SQLCODE................ ' SQLCODE */
                    _.Display($"          SQLCODE................ {DB.SQLCODE}");

                    /*" -1734- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -1734- PERFORM R9999-00-FINALIZAR. */

                    R9999_00_FINALIZAR_SECTION();
                }

            }


        }

        [StopWatch]
        /*" R0250-00-LER-PROPOSTAVA-DB-SELECT-1 */
        public void R0250_00_LER_PROPOSTAVA_DB_SELECT_1()
        {
            /*" -1718- EXEC SQL SELECT NUM_CERTIFICADO , COD_PRODUTO , COD_CLIENTE , OCOREND , COD_FONTE , AGE_COBRANCA , OPCAO_COBERTURA , DATA_QUITACAO , COD_AGE_VENDEDOR , OPE_CONTA_VENDEDOR , NUM_CONTA_VENDEDOR , DIG_CONTA_VENDEDOR , NUM_MATRI_VENDEDOR , COD_OPERACAO , PROFISSAO , DTINCLUS , DATA_MOVIMENTO , SIT_REGISTRO , NUM_APOLICE , COD_SUBGRUPO , OCORR_HISTORICO , NRPRIPARATZ , QTDPARATZ , DTPROXVEN , NUM_PARCELA , DATA_VENCIMENTO , SIT_INTERFACE , DTFENAE , COD_USUARIO , TIMESTAMP , IDADE , IDE_SEXO , ESTADO_CIVIL , APOS_INVALIDEZ , NOME_ESPOSA , DTNASC_ESPOSA , PROFIS_ESPOSA , DPS_TITULAR , DPS_ESPOSA , INFO_COMPLEMENTAR , COD_CCT , FAIXA_RENDA_IND , FAIXA_RENDA_FAM , COD_ORIGEM_PROPOSTA INTO :DCLPROPOSTAS-VA.NUM-CERTIFICADO , :DCLPROPOSTAS-VA.COD-PRODUTO , :DCLPROPOSTAS-VA.COD-CLIENTE , :DCLPROPOSTAS-VA.OCOREND , :DCLPROPOSTAS-VA.COD-FONTE , :DCLPROPOSTAS-VA.AGE-COBRANCA , :DCLPROPOSTAS-VA.OPCAO-COBERTURA , :DCLPROPOSTAS-VA.DATA-QUITACAO , :DCLPROPOSTAS-VA.COD-AGE-VENDEDOR , :DCLPROPOSTAS-VA.OPE-CONTA-VENDEDOR , :DCLPROPOSTAS-VA.NUM-CONTA-VENDEDOR , :DCLPROPOSTAS-VA.DIG-CONTA-VENDEDOR , :DCLPROPOSTAS-VA.NUM-MATRI-VENDEDOR , :DCLPROPOSTAS-VA.COD-OPERACAO , :DCLPROPOSTAS-VA.PROFISSAO , :DCLPROPOSTAS-VA.DTINCLUS , :DCLPROPOSTAS-VA.DATA-MOVIMENTO , :DCLPROPOSTAS-VA.SIT-REGISTRO , :DCLPROPOSTAS-VA.NUM-APOLICE , :DCLPROPOSTAS-VA.COD-SUBGRUPO , :DCLPROPOSTAS-VA.OCORR-HISTORICO , :DCLPROPOSTAS-VA.NRPRIPARATZ , :DCLPROPOSTAS-VA.QTDPARATZ , :DCLPROPOSTAS-VA.DTPROXVEN , :DCLPROPOSTAS-VA.NUM-PARCELA , :DCLPROPOSTAS-VA.DATA-VENCIMENTO , :DCLPROPOSTAS-VA.SIT-INTERFACE , :DCLPROPOSTAS-VA.DTFENAE , :DCLPROPOSTAS-VA.COD-USUARIO , :DCLPROPOSTAS-VA.TIMESTAMP , :DCLPROPOSTAS-VA.IDADE , :DCLPROPOSTAS-VA.IDE-SEXO , :DCLPROPOSTAS-VA.ESTADO-CIVIL , :DCLPROPOSTAS-VA.APOS-INVALIDEZ:VIND-APOS-INVALIDEZ, :DCLPROPOSTAS-VA.NOME-ESPOSA:VIND-NOME-ESPOSA, :DCLPROPOSTAS-VA.DTNASC-ESPOSA:VIND-DTNASC-ESPOSA, :DCLPROPOSTAS-VA.PROFIS-ESPOSA:VIND-PROFIS-ESPOSA, :DCLPROPOSTAS-VA.DPS-TITULAR:VIND-DPS-TITULAR, :DCLPROPOSTAS-VA.DPS-ESPOSA:VIND-DPS-ESPOSA, :DCLPROPOSTAS-VA.INFO-COMPLEMENTAR:VIND-INFO-COMP, :DCLPROPOSTAS-VA.COD-CCT:VIND-COD-CCT, :DCLPROPOSTAS-VA.FAIXA-RENDA-IND:VIND-FAIXA-RENDA-IND, :DCLPROPOSTAS-VA.FAIXA-RENDA-FAM:VIND-FAIXA-RENDA-FAM, :DCLPROPOSTAS-VA.COD-ORIGEM-PROPOSTA :VIND-COD-ORIGEM-PROP FROM SEGUROS.PROPOSTAS_VA WHERE NUM_CERTIFICADO = :DCLPROPOSTAS-VA.NUM-CERTIFICADO AND SIT_REGISTRO = '3' WITH UR END-EXEC. */

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
                _.Move(executed_1.COD_ORIGEM_PROPOSTA, PROPVA.DCLPROPOSTAS_VA.COD_ORIGEM_PROPOSTA);
                _.Move(executed_1.VIND_COD_ORIGEM_PROP, VIND_COD_ORIGEM_PROP);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0250_SAIDA*/

        [StopWatch]
        /*" R0300-00-LER-CLIENTE-SECTION */
        private void R0300_00_LER_CLIENTE_SECTION()
        {
            /*" -1744- MOVE 'R0300-00-LER-CLIENTES' TO PARAGRAFO. */
            _.Move("R0300-00-LER-CLIENTES", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1746- MOVE 'SELECT CLIENTES' TO COMANDO. */
            _.Move("SELECT CLIENTES", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1749- MOVE MOVVGAP-COD-CLIENTE TO COD-CLIENTE OF DCLCLIENTES. */
            _.Move(MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_COD_CLIENTE, CLIENTE.DCLCLIENTES.COD_CLIENTE);

            /*" -1767- PERFORM R0300_00_LER_CLIENTE_DB_SELECT_1 */

            R0300_00_LER_CLIENTE_DB_SELECT_1();

            /*" -1770- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -1771- DISPLAY 'PF0612B - FIM ANORMAL' */
                _.Display($"PF0612B - FIM ANORMAL");

                /*" -1772- DISPLAY '          ERRO SELECT TABELA CLIENTES' */
                _.Display($"          ERRO SELECT TABELA CLIENTES");

                /*" -1774- DISPLAY '          NUMERO CERTIFICADO......... ' NUM-CERTIFICADO OF DCLPROPOSTAS-VA */
                _.Display($"          NUMERO CERTIFICADO......... {PROPVA.DCLPROPOSTAS_VA.NUM_CERTIFICADO}");

                /*" -1776- DISPLAY '          CODIGO DO CLIENTE.......... ' COD-CLIENTE OF DCLCLIENTES */
                _.Display($"          CODIGO DO CLIENTE.......... {CLIENTE.DCLCLIENTES.COD_CLIENTE}");

                /*" -1778- DISPLAY '          SQLCODE.................... ' SQLCODE */
                _.Display($"          SQLCODE.................... {DB.SQLCODE}");

                /*" -1779- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -1779- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R0300-00-LER-CLIENTE-DB-SELECT-1 */
        public void R0300_00_LER_CLIENTE_DB_SELECT_1()
        {
            /*" -1767- EXEC SQL SELECT COD_CLIENTE , NOME_RAZAO , TIPO_PESSOA , CGCCPF , SIT_REGISTRO , DATA_NASCIMENTO INTO :DCLCLIENTES.COD-CLIENTE , :DCLCLIENTES.NOME-RAZAO , :DCLCLIENTES.TIPO-PESSOA , :DCLCLIENTES.CGCCPF , :DCLCLIENTES.SIT-REGISTRO , :DCLCLIENTES.DATA-NASCIMENTO:VIND-DTNASCI FROM SEGUROS.CLIENTES WHERE COD_CLIENTE = :DCLCLIENTES.COD-CLIENTE WITH UR END-EXEC. */

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
            /*" -1789- MOVE 'R0350-00-LER-ENDERECO' TO PARAGRAFO. */
            _.Move("R0350-00-LER-ENDERECO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1791- MOVE 'SELECT ENDERECOS' TO COMANDO. */
            _.Move("SELECT ENDERECOS", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1794- MOVE MOVVGAP-COD-CLIENTE TO ENDERECO-COD-CLIENTE OF DCLENDERECOS. */
            _.Move(MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_COD_CLIENTE, ENDERECO.DCLENDERECOS.ENDERECO_COD_CLIENTE);

            /*" -1832- PERFORM R0350_00_LER_ENDERECO_DB_SELECT_1 */

            R0350_00_LER_ENDERECO_DB_SELECT_1();

            /*" -1835- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -1836- DISPLAY 'PF0612B - FIM ANORMAL' */
                _.Display($"PF0612B - FIM ANORMAL");

                /*" -1837- DISPLAY '          ERRO SELECT TABELA ENDERECOS' */
                _.Display($"          ERRO SELECT TABELA ENDERECOS");

                /*" -1839- DISPLAY '          NUMERO CERTIFICADO.......... ' NUM-CERTIFICADO OF DCLPROPOSTAS-VA */
                _.Display($"          NUMERO CERTIFICADO.......... {PROPVA.DCLPROPOSTAS_VA.NUM_CERTIFICADO}");

                /*" -1841- DISPLAY '          CODIGO DO CLIENTE........... ' ENDERECO-COD-CLIENTE OF DCLENDERECOS */
                _.Display($"          CODIGO DO CLIENTE........... {ENDERECO.DCLENDERECOS.ENDERECO_COD_CLIENTE}");

                /*" -1843- DISPLAY '          SQLCODE..................... ' SQLCODE */
                _.Display($"          SQLCODE..................... {DB.SQLCODE}");

                /*" -1844- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -1844- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R0350-00-LER-ENDERECO-DB-SELECT-1 */
        public void R0350_00_LER_ENDERECO_DB_SELECT_1()
        {
            /*" -1832- EXEC SQL SELECT COD_CLIENTE , COD_ENDERECO , OCORR_ENDERECO , ENDERECO , BAIRRO , CIDADE , SIGLA_UF , CEP , DDD , TELEFONE , FAX , TELEX , SIT_REGISTRO INTO :DCLENDERECOS.ENDERECO-COD-CLIENTE , :DCLENDERECOS.ENDERECO-COD-ENDERECO , :DCLENDERECOS.ENDERECO-OCORR-ENDERECO , :DCLENDERECOS.ENDERECO-ENDERECO , :DCLENDERECOS.ENDERECO-BAIRRO , :DCLENDERECOS.ENDERECO-CIDADE , :DCLENDERECOS.ENDERECO-SIGLA-UF , :DCLENDERECOS.ENDERECO-CEP , :DCLENDERECOS.ENDERECO-DDD , :DCLENDERECOS.ENDERECO-TELEFONE , :DCLENDERECOS.ENDERECO-FAX , :DCLENDERECOS.ENDERECO-TELEX , :DCLENDERECOS.ENDERECO-SIT-REGISTRO FROM SEGUROS.ENDERECOS A WHERE A.COD_CLIENTE = :DCLENDERECOS.ENDERECO-COD-CLIENTE AND A.OCORR_ENDERECO = (SELECT MAX(B.OCORR_ENDERECO) FROM SEGUROS.ENDERECOS B WHERE B.COD_CLIENTE = A.COD_CLIENTE) WITH UR END-EXEC. */

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
            /*" -1857- MOVE 'R0400-00-LER-PROFISSAO' TO PARAGRAFO. */
            _.Move("R0400-00-LER-PROFISSAO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1859- IF PROFISSAO OF DCLPROPOSTAS-VA NOT EQUAL SPACES */

            if (!PROPVA.DCLPROPOSTAS_VA.PROFISSAO.IsEmpty())
            {

                /*" -1861- IF PROFISSAO OF DCLPROPOSTAS-VA NOT EQUAL 'OUTROS' */

                if (PROPVA.DCLPROPOSTAS_VA.PROFISSAO != "OUTROS")
                {

                    /*" -1865- MOVE PROFISSAO OF DCLPROPOSTAS-VA TO CBO-DESCR-CBO OF DCLCBO R1-DESCRICAO-PROFISSAO */
                    _.Move(PROPVA.DCLPROPOSTAS_VA.PROFISSAO, CBO.DCLCBO.CBO_DESCR_CBO, LBFPF011.REG_CLIENTES.R1_DESCRICAO_PROFISSAO);

                    /*" -1867- PERFORM R0410-00-LER-CBO */

                    R0410_00_LER_CBO_SECTION();

                    /*" -1868- IF SQLCODE EQUAL 00 */

                    if (DB.SQLCODE == 00)
                    {

                        /*" -1870- MOVE CBO-COD-CBO OF DCLCBO TO COD-CBO-TIT */
                        _.Move(CBO.DCLCBO.CBO_COD_CBO, COD_CBO_TIT);

                        /*" -1871- ELSE */
                    }
                    else
                    {


                        /*" -1872- MOVE ZEROS TO COD-CBO-TIT */
                        _.Move(0, COD_CBO_TIT);

                        /*" -1873- ELSE */
                    }

                }
                else
                {


                    /*" -1874- MOVE ZEROS TO COD-CBO-TIT */
                    _.Move(0, COD_CBO_TIT);

                    /*" -1876- MOVE PROFISSAO OF DCLPROPOSTAS-VA TO R1-DESCRICAO-PROFISSAO */
                    _.Move(PROPVA.DCLPROPOSTAS_VA.PROFISSAO, LBFPF011.REG_CLIENTES.R1_DESCRICAO_PROFISSAO);

                    /*" -1877- ELSE */
                }

            }
            else
            {


                /*" -1878- MOVE 'OUTROS' TO R1-DESCRICAO-PROFISSAO */
                _.Move("OUTROS", LBFPF011.REG_CLIENTES.R1_DESCRICAO_PROFISSAO);

                /*" -1882- MOVE ZEROS TO COD-CBO-TIT. */
                _.Move(0, COD_CBO_TIT);
            }


            /*" -1883- IF VIND-PROFIS-ESPOSA LESS ZEROS */

            if (VIND_PROFIS_ESPOSA < 00)
            {

                /*" -1884- MOVE ZEROS TO COD-CBO-CONJ */
                _.Move(0, COD_CBO_CONJ);

                /*" -1885- ELSE */
            }
            else
            {


                /*" -1887- IF PROFIS-ESPOSA OF DCLPROPOSTAS-VA NOT EQUAL SPACES */

                if (!PROPVA.DCLPROPOSTAS_VA.PROFIS_ESPOSA.IsEmpty())
                {

                    /*" -1889- IF PROFIS-ESPOSA OF DCLPROPOSTAS-VA NOT EQUAL 'OUTROS' */

                    if (PROPVA.DCLPROPOSTAS_VA.PROFIS_ESPOSA != "OUTROS")
                    {

                        /*" -1892- MOVE PROFIS-ESPOSA OF DCLPROPOSTAS-VA TO CBO-DESCR-CBO OF DCLCBO */
                        _.Move(PROPVA.DCLPROPOSTAS_VA.PROFIS_ESPOSA, CBO.DCLCBO.CBO_DESCR_CBO);

                        /*" -1894- PERFORM R0410-00-LER-CBO */

                        R0410_00_LER_CBO_SECTION();

                        /*" -1895- IF SQLCODE EQUAL 00 */

                        if (DB.SQLCODE == 00)
                        {

                            /*" -1897- MOVE CBO-COD-CBO OF DCLCBO TO COD-CBO-CONJ */
                            _.Move(CBO.DCLCBO.CBO_COD_CBO, COD_CBO_CONJ);

                            /*" -1898- ELSE */
                        }
                        else
                        {


                            /*" -1899- MOVE ZEROS TO COD-CBO-CONJ */
                            _.Move(0, COD_CBO_CONJ);

                            /*" -1900- ELSE */
                        }

                    }
                    else
                    {


                        /*" -1901- MOVE ZEROS TO COD-CBO-CONJ */
                        _.Move(0, COD_CBO_CONJ);

                        /*" -1902- ELSE */
                    }

                }
                else
                {


                    /*" -1902- MOVE ZEROS TO COD-CBO-CONJ. */
                    _.Move(0, COD_CBO_CONJ);
                }

            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0400_SAIDA*/

        [StopWatch]
        /*" R0410-00-LER-CBO-SECTION */
        private void R0410_00_LER_CBO_SECTION()
        {
            /*" -1912- MOVE 'R0400-00-LER-CBO' TO PARAGRAFO. */
            _.Move("R0400-00-LER-CBO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1914- MOVE 'SELECT CBO' TO COMANDO. */
            _.Move("SELECT CBO", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1927- PERFORM R0410_00_LER_CBO_DB_SELECT_1 */

            R0410_00_LER_CBO_DB_SELECT_1();

            /*" -1930- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -1932- IF SQLCODE EQUAL 811 OR -811 NEXT SENTENCE */

                if (DB.SQLCODE.In("811", "-811"))
                {

                    /*" -1933- ELSE */
                }
                else
                {


                    /*" -1934- IF SQLCODE NOT EQUAL 100 */

                    if (DB.SQLCODE != 100)
                    {

                        /*" -1935- DISPLAY 'PF0612B - FIM ANORMAL' */
                        _.Display($"PF0612B - FIM ANORMAL");

                        /*" -1936- DISPLAY '          ERRO SELECT TABELA CBO' */
                        _.Display($"          ERRO SELECT TABELA CBO");

                        /*" -1938- DISPLAY '          NUMERO CERTIFICADO...... ' NUM-CERTIFICADO OF DCLPROPOSTAS-VA */
                        _.Display($"          NUMERO CERTIFICADO...... {PROPVA.DCLPROPOSTAS_VA.NUM_CERTIFICADO}");

                        /*" -1940- DISPLAY '          DESCRICAO DA PROFISSAO.. ' CBO-DESCR-CBO OF DCLCBO */
                        _.Display($"          DESCRICAO DA PROFISSAO.. {CBO.DCLCBO.CBO_DESCR_CBO}");

                        /*" -1942- DISPLAY '          SQLCODE................. ' SQLCODE */
                        _.Display($"          SQLCODE................. {DB.SQLCODE}");

                        /*" -1943- PERFORM R9988-00-FECHAR-ARQUIVOS */

                        R9988_00_FECHAR_ARQUIVOS_SECTION();

                        /*" -1943- PERFORM R9999-00-FINALIZAR. */

                        R9999_00_FINALIZAR_SECTION();
                    }

                }

            }


        }

        [StopWatch]
        /*" R0410-00-LER-CBO-DB-SELECT-1 */
        public void R0410_00_LER_CBO_DB_SELECT_1()
        {
            /*" -1927- EXEC SQL SELECT DISTINCT COD_CBO , DESCR_CBO INTO :DCLCBO.CBO-COD-CBO , :DCLCBO.CBO-DESCR-CBO FROM SEGUROS.CBO WHERE ABREV_CBO = :DCLCBO.CBO-DESCR-CBO AND COD_CBO < 1000 ORDER BY COD_CBO, DESCR_CBO WITH UR END-EXEC. */

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
        /*" R0450-00-LER-PRODUTOS-SIVPF-SECTION */
        private void R0450_00_LER_PRODUTOS_SIVPF_SECTION()
        {
            /*" -1953- MOVE 'R0450-00-LER-PRODUTOS-SIVPF' TO PARAGRAFO. */
            _.Move("R0450-00-LER-PRODUTOS-SIVPF", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1955- MOVE 'SELECT PRODUTOS-SIVPF' TO COMANDO. */
            _.Move("SELECT PRODUTOS-SIVPF", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1958- MOVE COD-PRODUTO OF DCLPRODUTOS-VG TO PRDSIVPF-COD-PRODUTO OF DCLPRODUTOS-SIVPF. */
            _.Move(PRODVG.DCLPRODUTOS_VG.COD_PRODUTO, PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_PRODUTO);

            /*" -1974- PERFORM R0450_00_LER_PRODUTOS_SIVPF_DB_SELECT_1 */

            R0450_00_LER_PRODUTOS_SIVPF_DB_SELECT_1();

            /*" -1977- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -1978- DISPLAY 'PF0612B - FIM ANORMAL' */
                _.Display($"PF0612B - FIM ANORMAL");

                /*" -1979- DISPLAY '          ERRO SELECT PRODUTOS-SIVPF' */
                _.Display($"          ERRO SELECT PRODUTOS-SIVPF");

                /*" -1981- DISPLAY '          NUMERO CERTIFICADO........' NUM-CERTIFICADO OF DCLPROPOSTAS-VA */
                _.Display($"          NUMERO CERTIFICADO........{PROPVA.DCLPROPOSTAS_VA.NUM_CERTIFICADO}");

                /*" -1983- DISPLAY '          CODIGO PRODUTO............' PRDSIVPF-COD-PRODUTO OF DCLPRODUTOS-SIVPF */
                _.Display($"          CODIGO PRODUTO............{PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_PRODUTO}");

                /*" -1985- DISPLAY '          SQLCODE................... ' SQLCODE */
                _.Display($"          SQLCODE................... {DB.SQLCODE}");

                /*" -1986- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -1986- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R0450-00-LER-PRODUTOS-SIVPF-DB-SELECT-1 */
        public void R0450_00_LER_PRODUTOS_SIVPF_DB_SELECT_1()
        {
            /*" -1974- EXEC SQL SELECT COD_EMPRESA_SIVPF , COD_PRODUTO_SIVPF , COD_PRODUTO , COD_RELAC INTO :DCLPRODUTOS-SIVPF.PRDSIVPF-COD-EMPRESA-SIVPF , :DCLPRODUTOS-SIVPF.PRDSIVPF-COD-PRODUTO-SIVPF , :DCLPRODUTOS-SIVPF.PRDSIVPF-COD-PRODUTO , :DCLPRODUTOS-SIVPF.PRDSIVPF-COD-RELAC FROM SEGUROS.PRODUTOS_SIVPF WHERE COD_EMPRESA_SIVPF = 1 AND COD_PRODUTO = :DCLPRODUTOS-SIVPF.PRDSIVPF-COD-PRODUTO WITH UR END-EXEC. */

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
            /*" -1996- MOVE 'R0500-00-LER-RCAP' TO PARAGRAFO. */
            _.Move("R0500-00-LER-RCAP", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1999- MOVE 'SELECT RCAP' TO COMANDO. */
            _.Move("SELECT RCAP", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2003- MOVE MOVVGAP-NUM-CERTIFICADO TO RCAPS-NUM-TITULO OF DCLRCAPS. */
            _.Move(MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_NUM_CERTIFICADO, RCAPS.DCLRCAPS.RCAPS_NUM_TITULO);

            /*" -2031- PERFORM R0500_00_LER_RCAP_DB_SELECT_1 */

            R0500_00_LER_RCAP_DB_SELECT_1();

            /*" -2035- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -2036- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2039- MOVE MOVVGAP-NUM-CERTIFICADO TO RCAPS-NUM-CERTIFICADO OF DCLRCAPS */
                    _.Move(MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_NUM_CERTIFICADO, RCAPS.DCLRCAPS.RCAPS_NUM_CERTIFICADO);

                    /*" -2043- DISPLAY 'DCLRCAPS.RCAPS-NUM-CERTIFICADO ' RCAPS-NUM-CERTIFICADO OF DCLRCAPS */
                    _.Display($"DCLRCAPS.RCAPS-NUM-CERTIFICADO {RCAPS.DCLRCAPS.RCAPS_NUM_CERTIFICADO}");

                    /*" -2070- PERFORM R0500_00_LER_RCAP_DB_SELECT_2 */

                    R0500_00_LER_RCAP_DB_SELECT_2();

                    /*" -2074- IF SQLCODE NOT EQUAL 00 */

                    if (DB.SQLCODE != 00)
                    {

                        /*" -2077- DISPLAY 'PF0612B - RCAP NAO CADASTRADO... ' RCAPS-NUM-CERTIFICADO OF DCLRCAPS '   SQLCODE ' SQLCODE */

                        $"PF0612B - RCAP NAO CADASTRADO... {RCAPS.DCLRCAPS.RCAPS_NUM_CERTIFICADO}   SQLCODE {DB.SQLCODE}"
                        .Display();

                        /*" -2078- ADD 1 TO W-DESPREZADO */
                        WAREA_AUXILIAR.W_DESPREZADO.Value = WAREA_AUXILIAR.W_DESPREZADO + 1;

                        /*" -2080- ELSE NEXT SENTENCE */
                    }
                    else
                    {


                        /*" -2081- ELSE */
                    }

                }
                else
                {


                    /*" -2082- DISPLAY 'PF0612B - FIM ANORMAL' */
                    _.Display($"PF0612B - FIM ANORMAL");

                    /*" -2083- DISPLAY '          ERRO SELECT TABELA RCAP' */
                    _.Display($"          ERRO SELECT TABELA RCAP");

                    /*" -2085- DISPLAY '          NUMERO DO TITULO....... ' RCAPS-NUM-TITULO OF DCLRCAPS */
                    _.Display($"          NUMERO DO TITULO....... {RCAPS.DCLRCAPS.RCAPS_NUM_TITULO}");

                    /*" -2087- DISPLAY '          SQLCODE................ ' SQLCODE */
                    _.Display($"          SQLCODE................ {DB.SQLCODE}");

                    /*" -2088- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -2088- PERFORM R9999-00-FINALIZAR. */

                    R9999_00_FINALIZAR_SECTION();
                }

            }


        }

        [StopWatch]
        /*" R0500-00-LER-RCAP-DB-SELECT-1 */
        public void R0500_00_LER_RCAP_DB_SELECT_1()
        {
            /*" -2031- EXEC SQL SELECT COD_FONTE , NUM_RCAP , NUM_PROPOSTA , VAL_RCAP , VAL_RCAP_PRINCIPAL , DATA_CADASTRAMENTO , DATA_MOVIMENTO , SIT_REGISTRO , COD_OPERACAO , NUM_TITULO , NUM_CERTIFICADO INTO :DCLRCAPS.RCAPS-COD-FONTE , :DCLRCAPS.RCAPS-NUM-RCAP , :DCLRCAPS.RCAPS-NUM-PROPOSTA , :DCLRCAPS.RCAPS-VAL-RCAP , :DCLRCAPS.RCAPS-VAL-RCAP-PRINCIPAL, :DCLRCAPS.RCAPS-DATA-CADASTRAMENTO, :DCLRCAPS.RCAPS-DATA-MOVIMENTO , :DCLRCAPS.RCAPS-SIT-REGISTRO , :DCLRCAPS.RCAPS-COD-OPERACAO , :DCLRCAPS.RCAPS-NUM-TITULO , :DCLRCAPS.RCAPS-NUM-CERTIFICADO:VIND-NRCERTIF FROM SEGUROS.RCAPS WHERE NUM_TITULO = :DCLRCAPS.RCAPS-NUM-TITULO WITH UR END-EXEC. */

            var r0500_00_LER_RCAP_DB_SELECT_1_Query1 = new R0500_00_LER_RCAP_DB_SELECT_1_Query1()
            {
                RCAPS_NUM_TITULO = RCAPS.DCLRCAPS.RCAPS_NUM_TITULO.ToString(),
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
                _.Move(executed_1.RCAPS_NUM_CERTIFICADO, RCAPS.DCLRCAPS.RCAPS_NUM_CERTIFICADO);
                _.Move(executed_1.VIND_NRCERTIF, VIND_NRCERTIF);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0500_SAIDA*/

        [StopWatch]
        /*" R0500-00-LER-RCAP-DB-SELECT-2 */
        public void R0500_00_LER_RCAP_DB_SELECT_2()
        {
            /*" -2070- EXEC SQL SELECT COD_FONTE, NUM_RCAP, NUM_PROPOSTA, VAL_RCAP, VAL_RCAP_PRINCIPAL, DATA_CADASTRAMENTO, DATA_MOVIMENTO, SIT_REGISTRO, COD_OPERACAO, NUM_TITULO INTO :DCLRCAPS.RCAPS-COD-FONTE, :DCLRCAPS.RCAPS-NUM-RCAP, :DCLRCAPS.RCAPS-NUM-PROPOSTA, :DCLRCAPS.RCAPS-VAL-RCAP, :DCLRCAPS.RCAPS-VAL-RCAP-PRINCIPAL, :DCLRCAPS.RCAPS-DATA-CADASTRAMENTO, :DCLRCAPS.RCAPS-DATA-MOVIMENTO, :DCLRCAPS.RCAPS-SIT-REGISTRO, :DCLRCAPS.RCAPS-COD-OPERACAO, :DCLRCAPS.RCAPS-NUM-TITULO FROM SEGUROS.RCAPS WHERE NUM_CERTIFICADO = :DCLRCAPS.RCAPS-NUM-CERTIFICADO WITH UR END-EXEC */

            var r0500_00_LER_RCAP_DB_SELECT_2_Query1 = new R0500_00_LER_RCAP_DB_SELECT_2_Query1()
            {
                RCAPS_NUM_CERTIFICADO = RCAPS.DCLRCAPS.RCAPS_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = R0500_00_LER_RCAP_DB_SELECT_2_Query1.Execute(r0500_00_LER_RCAP_DB_SELECT_2_Query1);
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

        [StopWatch]
        /*" R0550-00-LER-OPCAOPAGVA-SECTION */
        private void R0550_00_LER_OPCAOPAGVA_SECTION()
        {
            /*" -2098- MOVE 'R0550-00-LER-OPCAOPAGVA' TO PARAGRAFO. */
            _.Move("R0550-00-LER-OPCAOPAGVA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2100- MOVE 'SELECT OPCAOPAGVA' TO COMANDO. */
            _.Move("SELECT OPCAOPAGVA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2103- MOVE MOVVGAP-NUM-CERTIFICADO TO OPPAGVA-NUM-CERTIFICADO. */
            _.Move(MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_NUM_CERTIFICADO, OPPAGVA.DCLOPCAO_PAG_VIDAZUL.OPPAGVA_NUM_CERTIFICADO);

            /*" -2131- PERFORM R0550_00_LER_OPCAOPAGVA_DB_SELECT_1 */

            R0550_00_LER_OPCAOPAGVA_DB_SELECT_1();

            /*" -2134- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -2135- DISPLAY 'PF0612B - FIM ANORMAL' */
                _.Display($"PF0612B - FIM ANORMAL");

                /*" -2136- DISPLAY '          ERRO SELECT OPCAOPAGVA' */
                _.Display($"          ERRO SELECT OPCAOPAGVA");

                /*" -2138- DISPLAY '          NUMERO CERTIFICADO.....' OPPAGVA-NUM-CERTIFICADO */
                _.Display($"          NUMERO CERTIFICADO.....{OPPAGVA.DCLOPCAO_PAG_VIDAZUL.OPPAGVA_NUM_CERTIFICADO}");

                /*" -2140- DISPLAY '          SQLCODE................ ' SQLCODE */
                _.Display($"          SQLCODE................ {DB.SQLCODE}");

                /*" -2141- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -2141- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R0550-00-LER-OPCAOPAGVA-DB-SELECT-1 */
        public void R0550_00_LER_OPCAOPAGVA_DB_SELECT_1()
        {
            /*" -2131- EXEC SQL SELECT NUM_CERTIFICADO , DATA_INIVIGENCIA , DATA_TERVIGENCIA , OPCAO_PAGAMENTO , PERI_PAGAMENTO , DIA_DEBITO , COD_AGENCIA_DEBITO , OPE_CONTA_DEBITO , NUM_CONTA_DEBITO , DIG_CONTA_DEBITO INTO :OPPAGVA-NUM-CERTIFICADO , :OPPAGVA-DATA-INIVIGENCIA , :OPPAGVA-DATA-TERVIGENCIA , :OPPAGVA-OPCAO-PAGAMENTO , :OPPAGVA-PERI-PAGAMENTO , :OPPAGVA-DIA-DEBITO , :OPPAGVA-COD-AGENCIA-DEBITO:VIND-AGEDEB, :OPPAGVA-OPE-CONTA-DEBITO:VIND-OPRCTADEB, :OPPAGVA-NUM-CONTA-DEBITO:VIND-NUMCTADEB, :OPPAGVA-DIG-CONTA-DEBITO:VIND-DIGCTADEB FROM SEGUROS.OPCAO_PAG_VIDAZUL WHERE NUM_CERTIFICADO = :OPPAGVA-NUM-CERTIFICADO AND DATA_TERVIGENCIA IN (:HOST-DT-TERVIG1, :HOST-DT-TERVIG2) WITH UR END-EXEC. */

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
            /*" -2151- MOVE 'R0570-00-LER-COMISSAO' TO PARAGRAFO. */
            _.Move("R0570-00-LER-COMISSAO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2153- MOVE 'SELECT FUNDOCOMISVA' TO COMANDO. */
            _.Move("SELECT FUNDOCOMISVA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2156- MOVE MOVVGAP-NUM-CERTIFICADO TO NUM-CERTIFICADO OF DCLFUNDO-COMISSAO-VA */
            _.Move(MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_NUM_CERTIFICADO, FDCOMVA.DCLFUNDO_COMISSAO_VA.NUM_CERTIFICADO);

            /*" -2159- MOVE 1101 TO COD-OPERACAO OF DCLFUNDO-COMISSAO-VA */
            _.Move(1101, FDCOMVA.DCLFUNDO_COMISSAO_VA.COD_OPERACAO);

            /*" -2170- PERFORM R0570_00_LER_COMISSAO_DB_DECLARE_1 */

            R0570_00_LER_COMISSAO_DB_DECLARE_1();

            /*" -2173- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -2174- DISPLAY 'PF0612B - FIM ANORMAL' */
                _.Display($"PF0612B - FIM ANORMAL");

                /*" -2175- DISPLAY '          ERRO DECLARE CURSOR FUNDOCOMISVA' */
                _.Display($"          ERRO DECLARE CURSOR FUNDOCOMISVA");

                /*" -2177- DISPLAY '          NUMERO CERTIFICADO.............. ' NUM-CERTIFICADO OF DCLFUNDO-COMISSAO-VA */
                _.Display($"          NUMERO CERTIFICADO.............. {FDCOMVA.DCLFUNDO_COMISSAO_VA.NUM_CERTIFICADO}");

                /*" -2179- DISPLAY '          SQLCODE......................... ' SQLCODE */
                _.Display($"          SQLCODE......................... {DB.SQLCODE}");

                /*" -2180- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -2182- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


            /*" -2182- PERFORM R0570_00_LER_COMISSAO_DB_OPEN_1 */

            R0570_00_LER_COMISSAO_DB_OPEN_1();

            /*" -2185- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -2186- DISPLAY 'PF0612B - FIM ANORMAL' */
                _.Display($"PF0612B - FIM ANORMAL");

                /*" -2187- DISPLAY '          ERRO OPEN CURSOR FUNDOCOMISVA' */
                _.Display($"          ERRO OPEN CURSOR FUNDOCOMISVA");

                /*" -2189- DISPLAY '          NUMERO CERTIFICADO........... ' NUM-CERTIFICADO OF DCLFUNDO-COMISSAO-VA */
                _.Display($"          NUMERO CERTIFICADO........... {FDCOMVA.DCLFUNDO_COMISSAO_VA.NUM_CERTIFICADO}");

                /*" -2191- DISPLAY '          SQLCODE...................... ' SQLCODE */
                _.Display($"          SQLCODE...................... {DB.SQLCODE}");

                /*" -2192- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -2194- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


            /*" -2200- PERFORM R0570_00_LER_COMISSAO_DB_FETCH_1 */

            R0570_00_LER_COMISSAO_DB_FETCH_1();

            /*" -2203- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -2204- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2207- MOVE ZEROS TO VAL-COMISSAO-VG OF DCLFUNDO-COMISSAO-VA, VAL-COMISSAO-AP OF DCLFUNDO-COMISSAO-VA */
                    _.Move(0, FDCOMVA.DCLFUNDO_COMISSAO_VA.VAL_COMISSAO_VG, FDCOMVA.DCLFUNDO_COMISSAO_VA.VAL_COMISSAO_AP);

                    /*" -2208- ELSE */
                }
                else
                {


                    /*" -2209- DISPLAY 'PF0612B - FIM ANORMAL' */
                    _.Display($"PF0612B - FIM ANORMAL");

                    /*" -2210- DISPLAY '          ERRO SELECT CURSOR FUNDOCOMISVA' */
                    _.Display($"          ERRO SELECT CURSOR FUNDOCOMISVA");

                    /*" -2212- DISPLAY '          NUMERO CERTIFICADO............. ' NUM-CERTIFICADO OF DCLFUNDO-COMISSAO-VA */
                    _.Display($"          NUMERO CERTIFICADO............. {FDCOMVA.DCLFUNDO_COMISSAO_VA.NUM_CERTIFICADO}");

                    /*" -2214- DISPLAY '          SQLCODE........................ ' SQLCODE */
                    _.Display($"          SQLCODE........................ {DB.SQLCODE}");

                    /*" -2215- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -2217- PERFORM R9999-00-FINALIZAR. */

                    R9999_00_FINALIZAR_SECTION();
                }

            }


            /*" -2217- PERFORM R0570_00_LER_COMISSAO_DB_CLOSE_1 */

            R0570_00_LER_COMISSAO_DB_CLOSE_1();

            /*" -2220- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -2221- DISPLAY 'PF0612B - FIM ANORMAL' */
                _.Display($"PF0612B - FIM ANORMAL");

                /*" -2222- DISPLAY '          ERRO CLOSE CURSOR FUNDOCOMISVA' */
                _.Display($"          ERRO CLOSE CURSOR FUNDOCOMISVA");

                /*" -2224- DISPLAY '          NUMERO CERTIFICADO............ ' NUM-CERTIFICADO OF DCLFUNDO-COMISSAO-VA */
                _.Display($"          NUMERO CERTIFICADO............ {FDCOMVA.DCLFUNDO_COMISSAO_VA.NUM_CERTIFICADO}");

                /*" -2226- DISPLAY '          SQLCODE....................... ' SQLCODE */
                _.Display($"          SQLCODE....................... {DB.SQLCODE}");

                /*" -2227- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -2227- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R0570-00-LER-COMISSAO-DB-OPEN-1 */
        public void R0570_00_LER_COMISSAO_DB_OPEN_1()
        {
            /*" -2182- EXEC SQL OPEN FUNDOCOMISVA END-EXEC. */

            FUNDOCOMISVA.Open();

        }

        [StopWatch]
        /*" R0800-00-CURSOR-BENEFICIARIOS-DB-DECLARE-1 */
        public void R0800_00_CURSOR_BENEFICIARIOS_DB_DECLARE_1()
        {
            /*" -2926- EXEC SQL DECLARE BENEFICIARIOS CURSOR FOR SELECT NUM_APOLICE , COD_SUBGRUPO , COD_FONTE , NUM_PROPOSTA , NUM_BENEFICIARIO , NOME_BENEFICIARIO , GRAU_PARENTESCO , PCT_PART_BENEFICIA FROM SEGUROS.BENEFICIARIOS_PROP WHERE NUM_APOLICE = :BENEFPRO-NUM-APOLICE AND COD_SUBGRUPO = :BENEFPRO-COD-SUBGRUPO AND COD_FONTE = :BENEFPRO-COD-FONTE AND NUM_PROPOSTA = :BENEFPRO-NUM-PROPOSTA WITH UR END-EXEC. */
            BENEFICIARIOS = new PF0612B_BENEFICIARIOS(true);
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
            /*" -2200- EXEC SQL FETCH FUNDOCOMISVA INTO :DCLFUNDO-COMISSAO-VA.NUM-CERTIFICADO , :DCLFUNDO-COMISSAO-VA.VAL-COMISSAO-VG , :DCLFUNDO-COMISSAO-VA.VAL-COMISSAO-AP END-EXEC. */

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
            /*" -2217- EXEC SQL CLOSE FUNDOCOMISVA END-EXEC. */

            FUNDOCOMISVA.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0570_SAIDA*/

        [StopWatch]
        /*" R0580-00-OBTER-VAL-TARIFA-SECTION */
        private void R0580_00_OBTER_VAL_TARIFA_SECTION()
        {
            /*" -2237- MOVE 'R0580-00-OBTER-VAL-TARIFA' TO PARAGRAFO. */
            _.Move("R0580-00-OBTER-VAL-TARIFA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2239- MOVE 'SELECT TARIFA-BALCAO-CEF' TO COMANDO. */
            _.Move("SELECT TARIFA-BALCAO-CEF", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2242- MOVE MOVVGAP-NUM-CERTIFICADO TO NUM-CERTIFICADO OF DCLTARIFA-BALCAO-CEF. */
            _.Move(MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_NUM_CERTIFICADO, TARIBCEF.DCLTARIFA_BALCAO_CEF.NUM_CERTIFICADO);

            /*" -2254- PERFORM R0580_00_OBTER_VAL_TARIFA_DB_SELECT_1 */

            R0580_00_OBTER_VAL_TARIFA_DB_SELECT_1();

            /*" -2257- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -2258- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2259- MOVE ZEROS TO VAL-TARIFA OF DCLTARIFA-BALCAO-CEF */
                    _.Move(0, TARIBCEF.DCLTARIFA_BALCAO_CEF.VAL_TARIFA);

                    /*" -2260- ELSE */
                }
                else
                {


                    /*" -2261- DISPLAY 'PF0612B - FIM ANORMAL' */
                    _.Display($"PF0612B - FIM ANORMAL");

                    /*" -2262- DISPLAY '          ERRO SELECT TAB. TARIFA-BALCAO-CEF' */
                    _.Display($"          ERRO SELECT TAB. TARIFA-BALCAO-CEF");

                    /*" -2264- DISPLAY '          NUMERO CERTIFICADO........ ' NUM-CERTIFICADO OF DCLTARIFA-BALCAO-CEF */
                    _.Display($"          NUMERO CERTIFICADO........ {TARIBCEF.DCLTARIFA_BALCAO_CEF.NUM_CERTIFICADO}");

                    /*" -2266- DISPLAY '          SQLCODE................... ' SQLCODE */
                    _.Display($"          SQLCODE................... {DB.SQLCODE}");

                    /*" -2267- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -2267- PERFORM R9999-00-FINALIZAR. */

                    R9999_00_FINALIZAR_SECTION();
                }

            }


        }

        [StopWatch]
        /*" R0580-00-OBTER-VAL-TARIFA-DB-SELECT-1 */
        public void R0580_00_OBTER_VAL_TARIFA_DB_SELECT_1()
        {
            /*" -2254- EXEC SQL SELECT VAL_TARIFA INTO :DCLTARIFA-BALCAO-CEF.VAL-TARIFA FROM SEGUROS.TARIFA_BALCAO_CEF WHERE COD_EMPRESA = 0 AND NUM_MATRICULA = 9999999 AND TIPO_FUNCIONARIO = '5' AND NUM_CERTIFICADO = :DCLTARIFA-BALCAO-CEF.NUM-CERTIFICADO WITH UR END-EXEC. */

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
            /*" -2278- MOVE 'R0600-00-GERAR-REGISTRO-TP1' TO PARAGRAFO. */
            _.Move("R0600-00-GERAR-REGISTRO-TP1", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2280- MOVE SPACES TO REG-PRP-SASSE. */
            _.Move("", REG_PRP_SASSE);

            /*" -2283- MOVE '1' TO R1-TIPO-REG OF REG-CLIENTES. */
            _.Move("1", LBFPF011.REG_CLIENTES.R1_TIPO_REG);

            /*" -2287- MOVE W-NUM-PROPOSTA-NOVA TO R1-NUM-PROPOSTA OF REG-CLIENTES. */
            _.Move(WAREA_AUXILIAR.W_NUM_PROPOSTA_NOVA, LBFPF011.REG_CLIENTES.R1_NUM_PROPOSTA);

            /*" -2290- MOVE CGCCPF OF DCLCLIENTES TO R1-CGC-CPF OF REG-CLIENTES. */
            _.Move(CLIENTE.DCLCLIENTES.CGCCPF, LBFPF011.REG_CLIENTES.R1_CGC_CPF);

            /*" -2291- IF VIND-DTNASCI LESS ZEROS */

            if (VIND_DTNASCI < 00)
            {

                /*" -2294- MOVE MOVVGAP-NUM-CERTIFICADO TO SEGVGAP-NUM-CERTIFICADO */
                _.Move(MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_NUM_CERTIFICADO, SEGVGAP.DCLSEGURADOS_VGAP.SEGVGAP_NUM_CERTIFICADO);

                /*" -2297- MOVE MOVVGAP-TIPO-SEGURADO TO SEGVGAP-TIPO-SEGURADO */
                _.Move(MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_TIPO_SEGURADO, SEGVGAP.DCLSEGURADOS_VGAP.SEGVGAP_TIPO_SEGURADO);

                /*" -2299- PERFORM R0610-00-SEGURAVG */

                R0610_00_SEGURAVG_SECTION();

                /*" -2300- IF SQLCODE EQUAL ZEROS */

                if (DB.SQLCODE == 00)
                {

                    /*" -2302- MOVE SEGVGAP-DATA-NASCIMENTO TO W-DATA-SQL */
                    _.Move(SEGVGAP.DCLSEGURADOS_VGAP.SEGVGAP_DATA_NASCIMENTO, WAREA_AUXILIAR.W_DATA_SQL);

                    /*" -2303- MOVE W-DIA-SQL TO W-DIA-TRABALHO */
                    _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_DIA_SQL, WAREA_AUXILIAR.FILLER_2.W_DIA_TRABALHO);

                    /*" -2304- MOVE W-MES-SQL TO W-MES-TRABALHO */
                    _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_MES_SQL, WAREA_AUXILIAR.FILLER_2.W_MES_TRABALHO);

                    /*" -2305- MOVE W-ANO-SQL TO W-ANO-TRABALHO */
                    _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_ANO_SQL, WAREA_AUXILIAR.FILLER_2.W_ANO_TRABALHO);

                    /*" -2307- MOVE W-DATA-TRABALHO TO R1-DATA-NASCIMENTO OF REG-CLIENTES */
                    _.Move(WAREA_AUXILIAR.W_DATA_TRABALHO, LBFPF011.REG_CLIENTES.R1_DATA_NASCIMENTO);

                    /*" -2308- ELSE */
                }
                else
                {


                    /*" -2310- MOVE ZEROS TO R1-DATA-NASCIMENTO OF REG-CLIENTES */
                    _.Move(0, LBFPF011.REG_CLIENTES.R1_DATA_NASCIMENTO);

                    /*" -2311- ELSE */
                }

            }
            else
            {


                /*" -2313- MOVE DATA-NASCIMENTO OF DCLCLIENTES TO W-DATA-SQL */
                _.Move(CLIENTE.DCLCLIENTES.DATA_NASCIMENTO, WAREA_AUXILIAR.W_DATA_SQL);

                /*" -2314- MOVE W-DIA-SQL TO W-DIA-TRABALHO */
                _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_DIA_SQL, WAREA_AUXILIAR.FILLER_2.W_DIA_TRABALHO);

                /*" -2315- MOVE W-MES-SQL TO W-MES-TRABALHO */
                _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_MES_SQL, WAREA_AUXILIAR.FILLER_2.W_MES_TRABALHO);

                /*" -2316- MOVE W-ANO-SQL TO W-ANO-TRABALHO */
                _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_ANO_SQL, WAREA_AUXILIAR.FILLER_2.W_ANO_TRABALHO);

                /*" -2319- MOVE W-DATA-TRABALHO TO R1-DATA-NASCIMENTO OF REG-CLIENTES. */
                _.Move(WAREA_AUXILIAR.W_DATA_TRABALHO, LBFPF011.REG_CLIENTES.R1_DATA_NASCIMENTO);
            }


            /*" -2322- MOVE NOME-RAZAO OF DCLCLIENTES TO R1-NOME-PESSOA OF REG-CLIENTES. */
            _.Move(CLIENTE.DCLCLIENTES.NOME_RAZAO, LBFPF011.REG_CLIENTES.R1_NOME_PESSOA);

            /*" -2323- IF TIPO-PESSOA OF DCLCLIENTES EQUAL 'F' */

            if (CLIENTE.DCLCLIENTES.TIPO_PESSOA == "F")
            {

                /*" -2324- MOVE 1 TO R1-TIPO-PESSOA OF REG-CLIENTES */
                _.Move(1, LBFPF011.REG_CLIENTES.R1_TIPO_PESSOA);

                /*" -2325- ELSE */
            }
            else
            {


                /*" -2327- MOVE 2 TO R1-TIPO-PESSOA OF REG-CLIENTES. */
                _.Move(2, LBFPF011.REG_CLIENTES.R1_TIPO_PESSOA);
            }


            /*" -2332- MOVE SPACES TO R1-UF-EXPEDIDORA OF REG-CLIENTES R1-CODIGO-SEGMENTO OF REG-CLIENTES R1-ORGAO-EXPEDIDOR OF REG-CLIENTES. */
            _.Move("", LBFPF011.REG_CLIENTES.R1_UF_EXPEDIDORA, LBFPF011.REG_CLIENTES.R1_CODIGO_SEGMENTO, LBFPF011.REG_CLIENTES.R1_ORGAO_EXPEDIDOR);

            /*" -2336- MOVE ZEROS TO R1-NUM-IDENTIDADE OF REG-CLIENTES R1-DATA-EXPEDICAO-RG OF REG-CLIENTES. */
            _.Move(0, LBFPF011.REG_CLIENTES.R1_NUM_IDENTIDADE, LBFPF011.REG_CLIENTES.R1_DATA_EXPEDICAO_RG);

            /*" -2338- MOVE ZERO TO W-OBTER-DADOS-RG. */
            _.Move(0, WAREA_AUXILIAR.W_OBTER_DADOS_RG);

            /*" -2340- PERFORM R0620-00-DADOS-RG. */

            R0620_00_DADOS_RG_SECTION();

            /*" -2341- IF OBTEVE-DADOS-RG */

            if (WAREA_AUXILIAR.W_OBTER_DADOS_RG["OBTEVE_DADOS_RG"])
            {

                /*" -2344- MOVE GEDOCCLI-COD-IDENTIFICACAO TO R1-NUM-IDENTIDADE OF REG-CLIENTES */
                _.Move(GEDOCCLI.DCLGE_DOC_CLIENTE.GEDOCCLI_COD_IDENTIFICACAO, LBFPF011.REG_CLIENTES.R1_NUM_IDENTIDADE);

                /*" -2347- MOVE GEDOCCLI-NOM-ORGAO-EXP TO W-NOM-ORGAO-EXP */
                _.Move(GEDOCCLI.DCLGE_DOC_CLIENTE.GEDOCCLI_NOM_ORGAO_EXP, WAREA_AUXILIAR.W_NOM_ORGAO_EXP);

                /*" -2350- MOVE W-ORGAO-EXPEDIDOR TO R1-ORGAO-EXPEDIDOR OF REG-CLIENTES */
                _.Move(WAREA_AUXILIAR.FILLER_5.W_ORGAO_EXPEDIDOR, LBFPF011.REG_CLIENTES.R1_ORGAO_EXPEDIDOR);

                /*" -2352- MOVE GEDOCCLI-DTH-EXPEDICAO TO W-DATA-SQL */
                _.Move(GEDOCCLI.DCLGE_DOC_CLIENTE.GEDOCCLI_DTH_EXPEDICAO, WAREA_AUXILIAR.W_DATA_SQL);

                /*" -2353- MOVE W-DIA-SQL TO W-DIA-TRABALHO */
                _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_DIA_SQL, WAREA_AUXILIAR.FILLER_2.W_DIA_TRABALHO);

                /*" -2354- MOVE W-MES-SQL TO W-MES-TRABALHO */
                _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_MES_SQL, WAREA_AUXILIAR.FILLER_2.W_MES_TRABALHO);

                /*" -2355- MOVE W-ANO-SQL TO W-ANO-TRABALHO */
                _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_ANO_SQL, WAREA_AUXILIAR.FILLER_2.W_ANO_TRABALHO);

                /*" -2358- MOVE W-DATA-TRABALHO TO R1-DATA-EXPEDICAO-RG OF REG-CLIENTES */
                _.Move(WAREA_AUXILIAR.W_DATA_TRABALHO, LBFPF011.REG_CLIENTES.R1_DATA_EXPEDICAO_RG);

                /*" -2361- MOVE GEDOCCLI-COD-UF TO R1-UF-EXPEDIDORA OF REG-CLIENTES. */
                _.Move(GEDOCCLI.DCLGE_DOC_CLIENTE.GEDOCCLI_COD_UF, LBFPF011.REG_CLIENTES.R1_UF_EXPEDIDORA);
            }


            /*" -2362- IF MOVVGAP-ESTADO-CIVIL EQUAL 'S' */

            if (MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_ESTADO_CIVIL == "S")
            {

                /*" -2363- MOVE 1 TO R1-ESTADO-CIVIL OF REG-CLIENTES */
                _.Move(1, LBFPF011.REG_CLIENTES.R1_ESTADO_CIVIL);

                /*" -2364- ELSE */
            }
            else
            {


                /*" -2365- IF MOVVGAP-ESTADO-CIVIL EQUAL 'C' */

                if (MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_ESTADO_CIVIL == "C")
                {

                    /*" -2366- MOVE 2 TO R1-ESTADO-CIVIL OF REG-CLIENTES */
                    _.Move(2, LBFPF011.REG_CLIENTES.R1_ESTADO_CIVIL);

                    /*" -2367- ELSE */
                }
                else
                {


                    /*" -2368- IF MOVVGAP-ESTADO-CIVIL EQUAL 'V' */

                    if (MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_ESTADO_CIVIL == "V")
                    {

                        /*" -2369- MOVE 3 TO R1-ESTADO-CIVIL OF REG-CLIENTES */
                        _.Move(3, LBFPF011.REG_CLIENTES.R1_ESTADO_CIVIL);

                        /*" -2370- ELSE */
                    }
                    else
                    {


                        /*" -2372- MOVE 4 TO R1-ESTADO-CIVIL OF REG-CLIENTES. */
                        _.Move(4, LBFPF011.REG_CLIENTES.R1_ESTADO_CIVIL);
                    }

                }

            }


            /*" -2373- IF MOVVGAP-IDE-SEXO EQUAL 'M' */

            if (MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_IDE_SEXO == "M")
            {

                /*" -2374- MOVE 1 TO R1-IDE-SEXO OF REG-CLIENTES */
                _.Move(1, LBFPF011.REG_CLIENTES.R1_IDE_SEXO);

                /*" -2375- ELSE */
            }
            else
            {


                /*" -2377- MOVE 2 TO R1-IDE-SEXO OF REG-CLIENTES. */
                _.Move(2, LBFPF011.REG_CLIENTES.R1_IDE_SEXO);
            }


            /*" -2380- MOVE COD-CBO-TIT TO R1-COD-CBO OF REG-CLIENTES. */
            _.Move(COD_CBO_TIT, LBFPF011.REG_CLIENTES.R1_COD_CBO);

            /*" -2383- MOVE ENDERECO-DDD OF DCLENDERECOS TO R1-DDD(1). */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_DDD, LBFPF011.REG_CLIENTES.R1_TELEFONE[1].R1_DDD);

            /*" -2386- MOVE ENDERECO-TELEFONE OF DCLENDERECOS TO R1-NUM-FONE(1). */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_TELEFONE, LBFPF011.REG_CLIENTES.R1_TELEFONE[1].R1_NUM_FONE);

            /*" -2390- MOVE ZEROS TO R1-DDD(2) R1-DDD(3). */
            _.Move(0, LBFPF011.REG_CLIENTES.R1_TELEFONE[2].R1_DDD, LBFPF011.REG_CLIENTES.R1_TELEFONE[3].R1_DDD);

            /*" -2394- MOVE ZEROS TO R1-NUM-FONE(2) R1-NUM-FONE(3). */
            _.Move(0, LBFPF011.REG_CLIENTES.R1_TELEFONE[2].R1_NUM_FONE, LBFPF011.REG_CLIENTES.R1_TELEFONE[3].R1_NUM_FONE);

            /*" -2395- IF VIND-NOME-ESPOSA LESS ZEROS */

            if (VIND_NOME_ESPOSA < 00)
            {

                /*" -2397- MOVE SPACES TO R1-NOME-CONJUGE OF REG-CLIENTES */
                _.Move("", LBFPF011.REG_CLIENTES.R1_NOME_CONJUGE);

                /*" -2398- ELSE */
            }
            else
            {


                /*" -2401- MOVE NOME-ESPOSA OF DCLPROPOSTAS-VA TO R1-NOME-CONJUGE OF REG-CLIENTES. */
                _.Move(PROPVA.DCLPROPOSTAS_VA.NOME_ESPOSA, LBFPF011.REG_CLIENTES.R1_NOME_CONJUGE);
            }


            /*" -2402- IF VIND-DTNASC-ESPOSA LESS ZEROS */

            if (VIND_DTNASC_ESPOSA < 00)
            {

                /*" -2404- MOVE ZEROS TO R1-DTNASC-CONJUGE OF REG-CLIENTES */
                _.Move(0, LBFPF011.REG_CLIENTES.R1_DTNASC_CONJUGE);

                /*" -2406- MOVE -1 TO VIND-DTNASC-ESPOSA */
                _.Move(-1, VIND_DTNASC_ESPOSA);

                /*" -2407- ELSE */
            }
            else
            {


                /*" -2410- MOVE DTNASC-ESPOSA OF DCLPROPOSTAS-VA TO W-DATA-SQL */
                _.Move(PROPVA.DCLPROPOSTAS_VA.DTNASC_ESPOSA, WAREA_AUXILIAR.W_DATA_SQL);

                /*" -2411- MOVE W-DIA-SQL TO W-DIA-TRABALHO */
                _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_DIA_SQL, WAREA_AUXILIAR.FILLER_2.W_DIA_TRABALHO);

                /*" -2412- MOVE W-MES-SQL TO W-MES-TRABALHO */
                _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_MES_SQL, WAREA_AUXILIAR.FILLER_2.W_MES_TRABALHO);

                /*" -2413- MOVE W-ANO-SQL TO W-ANO-TRABALHO */
                _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_ANO_SQL, WAREA_AUXILIAR.FILLER_2.W_ANO_TRABALHO);

                /*" -2416- MOVE W-DATA-TRABALHO TO R1-DTNASC-CONJUGE OF REG-CLIENTES. */
                _.Move(WAREA_AUXILIAR.W_DATA_TRABALHO, LBFPF011.REG_CLIENTES.R1_DTNASC_CONJUGE);
            }


            /*" -2419- MOVE COD-CBO-CONJ TO R1-CBO-CONJUGE OF REG-CLIENTES. */
            _.Move(COD_CBO_CONJ, LBFPF011.REG_CLIENTES.R1_CBO_CONJUGE);

            /*" -2422- MOVE SPACES TO R1-EMAIL OF REG-CLIENTES. */
            _.Move("", LBFPF011.REG_CLIENTES.R1_EMAIL);

            /*" -2424- WRITE REG-PRP-SASSE FROM REG-CLIENTES. */
            _.Move(LBFPF011.REG_CLIENTES.GetMoveValues(), REG_PRP_SASSE);

            MOVTO_PRP_SASSE.Write(REG_PRP_SASSE.GetMoveValues().ToString());

            /*" -2426- ADD 1 TO W-QTD-LD-TIPO-1. */
            WAREA_AUXILIAR.W_QTD_LD_TIPO_1.Value = WAREA_AUXILIAR.W_QTD_LD_TIPO_1 + 1;

            /*" -2427- MOVE MOVVGAP-NUM-CERTIFICADO TO R1-NUM-PROPOSTA OF REG-CLIENTES. */
            _.Move(MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_NUM_CERTIFICADO, LBFPF011.REG_CLIENTES.R1_NUM_PROPOSTA);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0600_SAIDA*/

        [StopWatch]
        /*" R0610-00-SEGURAVG-SECTION */
        private void R0610_00_SEGURAVG_SECTION()
        {
            /*" -2437- MOVE 'R0610-00-SEGURAVG' TO PARAGRAFO. */
            _.Move("R0610-00-SEGURAVG", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2439- MOVE 'SELECT SEGURADOS-VGAP' TO COMANDO. */
            _.Move("SELECT SEGURADOS-VGAP", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2450- PERFORM R0610_00_SEGURAVG_DB_SELECT_1 */

            R0610_00_SEGURAVG_DB_SELECT_1();

            /*" -2453- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -2455- IF SQLCODE EQUAL -305 NEXT SENTENCE */

                if (DB.SQLCODE == -305)
                {

                    /*" -2456- ELSE */
                }
                else
                {


                    /*" -2457- DISPLAY 'PF0612B - FIM ANORMAL' */
                    _.Display($"PF0612B - FIM ANORMAL");

                    /*" -2458- DISPLAY '          ERRO SELECT TAB. SEGURADOS-VGAP' */
                    _.Display($"          ERRO SELECT TAB. SEGURADOS-VGAP");

                    /*" -2460- DISPLAY '          NUMERO CERTIFICADO........ ' SEGVGAP-NUM-CERTIFICADO */
                    _.Display($"          NUMERO CERTIFICADO........ {SEGVGAP.DCLSEGURADOS_VGAP.SEGVGAP_NUM_CERTIFICADO}");

                    /*" -2462- DISPLAY '          SQLCODE................... ' SQLCODE */
                    _.Display($"          SQLCODE................... {DB.SQLCODE}");

                    /*" -2463- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -2463- PERFORM R9999-00-FINALIZAR. */

                    R9999_00_FINALIZAR_SECTION();
                }

            }


        }

        [StopWatch]
        /*" R0610-00-SEGURAVG-DB-SELECT-1 */
        public void R0610_00_SEGURAVG_DB_SELECT_1()
        {
            /*" -2450- EXEC SQL SELECT DATA_NASCIMENTO INTO :SEGVGAP-DATA-NASCIMENTO FROM SEGUROS.SEGURADOS_VGAP WHERE NUM_CERTIFICADO = :SEGVGAP-NUM-CERTIFICADO AND TIPO_SEGURADO = :SEGVGAP-TIPO-SEGURADO WITH UR END-EXEC. */

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
            /*" -2473- MOVE 'R0620-00-DADOS-RG' TO PARAGRAFO. */
            _.Move("R0620-00-DADOS-RG", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2475- MOVE 'SELECT GE_DOC_CLIENTES' TO COMANDO. */
            _.Move("SELECT GE_DOC_CLIENTES", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2478- MOVE COD-CLIENTE OF DCLCLIENTES TO GEDOCCLI-COD-CLIENTE. */
            _.Move(CLIENTE.DCLCLIENTES.COD_CLIENTE, GEDOCCLI.DCLGE_DOC_CLIENTE.GEDOCCLI_COD_CLIENTE);

            /*" -2494- PERFORM R0620_00_DADOS_RG_DB_SELECT_1 */

            R0620_00_DADOS_RG_DB_SELECT_1();

            /*" -2497- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -2499- IF SQLCODE EQUAL 100 NEXT SENTENCE */

                if (DB.SQLCODE == 100)
                {

                    /*" -2500- ELSE */
                }
                else
                {


                    /*" -2501- DISPLAY 'PF0612B - FIM ANORMAL' */
                    _.Display($"PF0612B - FIM ANORMAL");

                    /*" -2502- DISPLAY '          ERRO SELECT TAB. GE_DOC_CLIENTES' */
                    _.Display($"          ERRO SELECT TAB. GE_DOC_CLIENTES");

                    /*" -2504- DISPLAY '          NUMERO CERTIFICADO.............. ' SEGVGAP-NUM-CERTIFICADO */
                    _.Display($"          NUMERO CERTIFICADO.............. {SEGVGAP.DCLSEGURADOS_VGAP.SEGVGAP_NUM_CERTIFICADO}");

                    /*" -2506- DISPLAY '          CODIGO DO CLIENTE............... ' GEDOCCLI-COD-CLIENTE */
                    _.Display($"          CODIGO DO CLIENTE............... {GEDOCCLI.DCLGE_DOC_CLIENTE.GEDOCCLI_COD_CLIENTE}");

                    /*" -2508- DISPLAY '          SQLCODE......................... ' SQLCODE */
                    _.Display($"          SQLCODE......................... {DB.SQLCODE}");

                    /*" -2509- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -2510- PERFORM R9999-00-FINALIZAR */

                    R9999_00_FINALIZAR_SECTION();

                    /*" -2511- ELSE */
                }

            }
            else
            {


                /*" -2512- IF VIND-COD-UF LESS ZEROS */

                if (VIND_COD_UF < 00)
                {

                    /*" -2513- MOVE SPACES TO GEDOCCLI-COD-UF */
                    _.Move("", GEDOCCLI.DCLGE_DOC_CLIENTE.GEDOCCLI_COD_UF);

                    /*" -2514- END-IF */
                }


                /*" -2514- MOVE 1 TO W-OBTER-DADOS-RG. */
                _.Move(1, WAREA_AUXILIAR.W_OBTER_DADOS_RG);
            }


        }

        [StopWatch]
        /*" R0620-00-DADOS-RG-DB-SELECT-1 */
        public void R0620_00_DADOS_RG_DB_SELECT_1()
        {
            /*" -2494- EXEC SQL SELECT COD_CLIENTE , COD_IDENTIFICACAO , NOM_ORGAO_EXP , DTH_EXPEDICAO , COD_UF INTO :GEDOCCLI-COD-CLIENTE , :GEDOCCLI-COD-IDENTIFICACAO, :GEDOCCLI-NOM-ORGAO-EXP , :GEDOCCLI-DTH-EXPEDICAO , :GEDOCCLI-COD-UF :VIND-COD-UF FROM SEGUROS.GE_DOC_CLIENTE WHERE COD_CLIENTE = :GEDOCCLI-COD-CLIENTE WITH UR END-EXEC. */

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
            /*" -2525- MOVE 'R0650-00-GERAR-REGISTRO-TP2' TO PARAGRAFO. */
            _.Move("R0650-00-GERAR-REGISTRO-TP2", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2528- MOVE SPACES TO REG-ENDERECO, REG-PRP-SASSE. */
            _.Move("", LBFPF012.REG_ENDERECO, REG_PRP_SASSE);

            /*" -2531- MOVE '2' TO R2-TIPO-REG OF REG-ENDERECO. */
            _.Move("2", LBFPF012.REG_ENDERECO.R2_TIPO_REG);

            /*" -2535- MOVE W-NUM-PROPOSTA-NOVA TO R2-NUM-PROPOSTA OF REG-ENDERECO. */
            _.Move(WAREA_AUXILIAR.W_NUM_PROPOSTA_NOVA, LBFPF012.REG_ENDERECO.R2_NUM_PROPOSTA);

            /*" -2538- MOVE '2' TO R2-TIPO-ENDER OF REG-ENDERECO. */
            _.Move("2", LBFPF012.REG_ENDERECO.R2_TIPO_ENDER);

            /*" -2541- MOVE ENDERECO-ENDERECO OF DCLENDERECOS TO R2-ENDERECO OF REG-ENDERECO. */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_ENDERECO, LBFPF012.REG_ENDERECO.R2_ENDERECO);

            /*" -2544- MOVE ENDERECO-BAIRRO OF DCLENDERECOS TO R2-BAIRRO OF REG-ENDERECO. */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_BAIRRO, LBFPF012.REG_ENDERECO.R2_BAIRRO);

            /*" -2547- MOVE ENDERECO-CIDADE OF DCLENDERECOS TO R2-CIDADE OF REG-ENDERECO. */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_CIDADE, LBFPF012.REG_ENDERECO.R2_CIDADE);

            /*" -2550- MOVE ENDERECO-SIGLA-UF OF DCLENDERECOS TO R2-SIGLA-UF OF REG-ENDERECO. */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_SIGLA_UF, LBFPF012.REG_ENDERECO.R2_SIGLA_UF);

            /*" -2553- MOVE ENDERECO-CEP OF DCLENDERECOS TO R2-CEP OF REG-ENDERECO. */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_CEP, LBFPF012.REG_ENDERECO.R2_CEP);

            /*" -2555- WRITE REG-PRP-SASSE FROM REG-ENDERECO. */
            _.Move(LBFPF012.REG_ENDERECO.GetMoveValues(), REG_PRP_SASSE);

            MOVTO_PRP_SASSE.Write(REG_PRP_SASSE.GetMoveValues().ToString());

            /*" -2557- ADD 1 TO W-QTD-LD-TIPO-2. */
            WAREA_AUXILIAR.W_QTD_LD_TIPO_2.Value = WAREA_AUXILIAR.W_QTD_LD_TIPO_2 + 1;

            /*" -2558- MOVE MOVVGAP-NUM-CERTIFICADO TO R2-NUM-PROPOSTA OF REG-ENDERECO. */
            _.Move(MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_NUM_CERTIFICADO, LBFPF012.REG_ENDERECO.R2_NUM_PROPOSTA);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0650_SAIDA*/

        [StopWatch]
        /*" R0700-00-GERAR-REGISTRO-TP3-SECTION */
        private void R0700_00_GERAR_REGISTRO_TP3_SECTION()
        {
            /*" -2569- MOVE 'R0700-00-GERAR-REGISTRO-TP3' TO PARAGRAFO. */
            _.Move("R0700-00-GERAR-REGISTRO-TP3", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2572- MOVE SPACES TO REG-PROPOSTA-SASSE REG-PRP-SASSE. */
            _.Move("", LXFCT004.REG_PROPOSTA_SASSE, REG_PRP_SASSE);

            /*" -2575- MOVE '3' TO R3-TIPO-REG OF REG-PROPOSTA-SASSE */
            _.Move("3", LXFCT004.REG_PROPOSTA_SASSE.R3_TIPO_REG);

            /*" -2579- MOVE W-NUM-PROPOSTA-NOVA TO R3-NUM-PROPOSTA OF REG-PROPOSTA-SASSE */
            _.Move(WAREA_AUXILIAR.W_NUM_PROPOSTA_NOVA, LXFCT004.REG_PROPOSTA_SASSE.R3_NUM_PROPOSTA);

            /*" -2582- MOVE PRDSIVPF-COD-PRODUTO-SIVPF OF DCLPRODUTOS-SIVPF TO R3-COD-PRODUTO OF REG-PROPOSTA-SASSE */
            _.Move(PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_PRODUTO_SIVPF, LXFCT004.REG_PROPOSTA_SASSE.R3_COD_PRODUTO);

            /*" -2585- MOVE AGE-COBRANCA OF DCLPROPOSTAS-VA TO R3-AGECOBR OF REG-PROPOSTA-SASSE */
            _.Move(PROPVA.DCLPROPOSTAS_VA.AGE_COBRANCA, LXFCT004.REG_PROPOSTA_SASSE.R3_AGECOBR);

            /*" -2587- MOVE DATA-QUITACAO OF DCLPROPOSTAS-VA TO W-DATA-SQL */
            _.Move(PROPVA.DCLPROPOSTAS_VA.DATA_QUITACAO, WAREA_AUXILIAR.W_DATA_SQL);

            /*" -2588- MOVE W-DIA-SQL TO W-DIA-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_DIA_SQL, WAREA_AUXILIAR.FILLER_2.W_DIA_TRABALHO);

            /*" -2589- MOVE W-MES-SQL TO W-MES-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_MES_SQL, WAREA_AUXILIAR.FILLER_2.W_MES_TRABALHO);

            /*" -2590- MOVE W-ANO-SQL TO W-ANO-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_ANO_SQL, WAREA_AUXILIAR.FILLER_2.W_ANO_TRABALHO);

            /*" -2593- MOVE W-DATA-TRABALHO TO R3-DATA-PROPOSTA OF REG-PROPOSTA-SASSE */
            _.Move(WAREA_AUXILIAR.W_DATA_TRABALHO, LXFCT004.REG_PROPOSTA_SASSE.R3_DATA_PROPOSTA);

            /*" -2596- MOVE OPPAGVA-OPCAO-PAGAMENTO TO R3-OPCAOPAG OF REG-PROPOSTA-SASSE */
            _.Move(OPPAGVA.DCLOPCAO_PAG_VIDAZUL.OPPAGVA_OPCAO_PAGAMENTO, LXFCT004.REG_PROPOSTA_SASSE.R3_OPCAOPAG);

            /*" -2597- IF R3-OPCAOPAG OF REG-PROPOSTA-SASSE = 1 OR 2 */

            if (LXFCT004.REG_PROPOSTA_SASSE.R3_OPCAOPAG.In("1", "2"))
            {

                /*" -2600- MOVE 1 TO R3-OPCAOPAG OF REG-PROPOSTA-SASSE. */
                _.Move(1, LXFCT004.REG_PROPOSTA_SASSE.R3_OPCAOPAG);
            }


            /*" -2601- IF R3-OPCAOPAG OF REG-PROPOSTA-SASSE = 3 */

            if (LXFCT004.REG_PROPOSTA_SASSE.R3_OPCAOPAG == 3)
            {

                /*" -2604- MOVE 2 TO R3-OPCAOPAG OF REG-PROPOSTA-SASSE. */
                _.Move(2, LXFCT004.REG_PROPOSTA_SASSE.R3_OPCAOPAG);
            }


            /*" -2605- IF R3-OPCAOPAG OF REG-PROPOSTA-SASSE = 5 */

            if (LXFCT004.REG_PROPOSTA_SASSE.R3_OPCAOPAG == 5)
            {

                /*" -2608- MOVE 3 TO R3-OPCAOPAG OF REG-PROPOSTA-SASSE. */
                _.Move(3, LXFCT004.REG_PROPOSTA_SASSE.R3_OPCAOPAG);
            }


            /*" -2609- IF VIND-AGEDEB LESS ZEROS */

            if (VIND_AGEDEB < 00)
            {

                /*" -2611- MOVE ZEROS TO R3-AGECTADEB OF REG-PROPOSTA-SASSE */
                _.Move(0, LXFCT004.REG_PROPOSTA_SASSE.R3_CONTA_DEBITO.R3_AGECTADEB);

                /*" -2612- ELSE */
            }
            else
            {


                /*" -2615- MOVE OPPAGVA-COD-AGENCIA-DEBITO TO R3-AGECTADEB OF REG-PROPOSTA-SASSE */
                _.Move(OPPAGVA.DCLOPCAO_PAG_VIDAZUL.OPPAGVA_COD_AGENCIA_DEBITO, LXFCT004.REG_PROPOSTA_SASSE.R3_CONTA_DEBITO.R3_AGECTADEB);

                /*" -2616- IF VIND-OPRCTADEB LESS ZEROS */

                if (VIND_OPRCTADEB < 00)
                {

                    /*" -2618- MOVE ZEROS TO R3-OPRCTADEB OF REG-PROPOSTA-SASSE */
                    _.Move(0, LXFCT004.REG_PROPOSTA_SASSE.R3_CONTA_DEBITO.R3_OPRCTADEB);

                    /*" -2619- ELSE */
                }
                else
                {


                    /*" -2622- MOVE OPPAGVA-OPE-CONTA-DEBITO TO R3-OPRCTADEB OF REG-PROPOSTA-SASSE. */
                    _.Move(OPPAGVA.DCLOPCAO_PAG_VIDAZUL.OPPAGVA_OPE_CONTA_DEBITO, LXFCT004.REG_PROPOSTA_SASSE.R3_CONTA_DEBITO.R3_OPRCTADEB);
                }

            }


            /*" -2623- IF VIND-NUMCTADEB LESS ZEROS */

            if (VIND_NUMCTADEB < 00)
            {

                /*" -2625- MOVE ZEROS TO R3-NUMCTADEB OF REG-PROPOSTA-SASSE */
                _.Move(0, LXFCT004.REG_PROPOSTA_SASSE.R3_CONTA_DEBITO.R3_NUMCTADEB);

                /*" -2626- ELSE */
            }
            else
            {


                /*" -2629- MOVE OPPAGVA-NUM-CONTA-DEBITO TO R3-NUMCTADEB OF REG-PROPOSTA-SASSE. */
                _.Move(OPPAGVA.DCLOPCAO_PAG_VIDAZUL.OPPAGVA_NUM_CONTA_DEBITO, LXFCT004.REG_PROPOSTA_SASSE.R3_CONTA_DEBITO.R3_NUMCTADEB);
            }


            /*" -2630- IF VIND-DIGCTADEB LESS ZEROS */

            if (VIND_DIGCTADEB < 00)
            {

                /*" -2632- MOVE ZEROS TO R3-DIGCTADEB OF REG-PROPOSTA-SASSE */
                _.Move(0, LXFCT004.REG_PROPOSTA_SASSE.R3_CONTA_DEBITO.R3_DIGCTADEB);

                /*" -2633- ELSE */
            }
            else
            {


                /*" -2636- MOVE OPPAGVA-DIG-CONTA-DEBITO TO R3-DIGCTADEB OF REG-PROPOSTA-SASSE. */
                _.Move(OPPAGVA.DCLOPCAO_PAG_VIDAZUL.OPPAGVA_DIG_CONTA_DEBITO, LXFCT004.REG_PROPOSTA_SASSE.R3_CONTA_DEBITO.R3_DIGCTADEB);
            }


            /*" -2637- IF VIND-DPS-TITULAR LESS ZEROS */

            if (VIND_DPS_TITULAR < 00)
            {

                /*" -2639- MOVE SPACES TO R3-DPS-TITULAR OF REG-PROPOSTA-SASSE */
                _.Move("", LXFCT004.REG_PROPOSTA_SASSE.R3_DPS_TITULAR);

                /*" -2640- ELSE */
            }
            else
            {


                /*" -2643- MOVE DPS-TITULAR OF DCLPROPOSTAS-VA TO R3-DPS-TITULAR OF REG-PROPOSTA-SASSE. */
                _.Move(PROPVA.DCLPROPOSTAS_VA.DPS_TITULAR, LXFCT004.REG_PROPOSTA_SASSE.R3_DPS_TITULAR);
            }


            /*" -2644- IF VIND-DPS-ESPOSA LESS ZEROS */

            if (VIND_DPS_ESPOSA < 00)
            {

                /*" -2646- MOVE SPACES TO R3-DPS-CONJUGE OF REG-PROPOSTA-SASSE */
                _.Move("", LXFCT004.REG_PROPOSTA_SASSE.R3_DPS_CONJUGE);

                /*" -2647- ELSE */
            }
            else
            {


                /*" -2650- MOVE DPS-ESPOSA OF DCLPROPOSTAS-VA TO R3-DPS-CONJUGE OF REG-PROPOSTA-SASSE. */
                _.Move(PROPVA.DCLPROPOSTAS_VA.DPS_ESPOSA, LXFCT004.REG_PROPOSTA_SASSE.R3_DPS_CONJUGE);
            }


            /*" -2651- IF R3-COD-PRODUTO OF REG-PROPOSTA-SASSE = 46 */

            if (LXFCT004.REG_PROPOSTA_SASSE.R3_COD_PRODUTO == 46)
            {

                /*" -2655- MOVE SPACES TO R3-DPS-TITULAR OF REG-PROPOSTA-SASSE R3-DPS-CONJUGE OF REG-PROPOSTA-SASSE. */
                _.Move("", LXFCT004.REG_PROPOSTA_SASSE.R3_DPS_TITULAR, LXFCT004.REG_PROPOSTA_SASSE.R3_DPS_CONJUGE);
            }


            /*" -2658- MOVE NUM-MATRI-VENDEDOR OF DCLPROPOSTAS-VA TO R3-NRMATRVEN OF REG-PROPOSTA-SASSE */
            _.Move(PROPVA.DCLPROPOSTAS_VA.NUM_MATRI_VENDEDOR, LXFCT004.REG_PROPOSTA_SASSE.R3_NRMATRVEN);

            /*" -2659- IF VIND-APOS-INVALIDEZ LESS 0 */

            if (VIND_APOS_INVALIDEZ < 0)
            {

                /*" -2661- MOVE SPACES TO R3-APOS-INVALIDEZ OF REG-PROPOSTA-SASSE */
                _.Move("", LXFCT004.REG_PROPOSTA_SASSE.R3_APOS_INVALIDEZ);

                /*" -2662- ELSE */
            }
            else
            {


                /*" -2665- MOVE APOS-INVALIDEZ OF DCLPROPOSTAS-VA TO R3-APOS-INVALIDEZ OF REG-PROPOSTA-SASSE. */
                _.Move(PROPVA.DCLPROPOSTAS_VA.APOS_INVALIDEZ, LXFCT004.REG_PROPOSTA_SASSE.R3_APOS_INVALIDEZ);
            }


            /*" -2668- MOVE SPACES TO R3-RENOVACAO-AUTOM OF REG-PROPOSTA-SASSE. */
            _.Move("", LXFCT004.REG_PROPOSTA_SASSE.R3_RENOVACAO_AUTOM);

            /*" -2673- MOVE OPPAGVA-DIA-DEBITO TO R3-DIA-DEBITO OF REG-PROPOSTA-SASSE. */
            _.Move(OPPAGVA.DCLOPCAO_PAG_VIDAZUL.OPPAGVA_DIA_DEBITO, LXFCT004.REG_PROPOSTA_SASSE.R3_DIA_DEBITO);

            /*" -2678- MOVE OPPAGVA-PERI-PAGAMENTO TO R3-PERIPGTO OF REG-PROPOSTA-SASSE. */
            _.Move(OPPAGVA.DCLOPCAO_PAG_VIDAZUL.OPPAGVA_PERI_PAGAMENTO, LXFCT004.REG_PROPOSTA_SASSE.R3_PERIPGTO);

            /*" -2679- IF OPPAGVA-PERI-PAGAMENTO EQUAL ZEROS */

            if (OPPAGVA.DCLOPCAO_PAG_VIDAZUL.OPPAGVA_PERI_PAGAMENTO == 00)
            {

                /*" -2681- MOVE 36 TO R3-PRAZO-VIGENCIA OF REG-PROPOSTA-SASSE */
                _.Move(36, LXFCT004.REG_PROPOSTA_SASSE.R3_PRAZO_VIGENCIA);

                /*" -2682- ELSE */
            }
            else
            {


                /*" -2684- MOVE 12 TO R3-PRAZO-VIGENCIA OF REG-PROPOSTA-SASSE */
                _.Move(12, LXFCT004.REG_PROPOSTA_SASSE.R3_PRAZO_VIGENCIA);

                /*" -2686- END-IF */
            }


            /*" -2687- IF VIND-COD-CCT NOT LESS ZEROS */

            if (VIND_COD_CCT >= 00)
            {

                /*" -2689- IF COD-CCT OF DCLPROPOSTAS-VA GREATER ZEROS */

                if (PROPVA.DCLPROPOSTAS_VA.COD_CCT > 00)
                {

                    /*" -2691- MOVE 50,00 TO R3-PCT-DESCONTO OF REG-PROPOSTA-SASSE */
                    _.Move(50.00, LXFCT004.REG_PROPOSTA_SASSE.R3_PCT_DESCONTO);

                    /*" -2693- MOVE COD-CCT OF DCLPROPOSTAS-VA TO R3-CGC-CONVENENTE OF REG-PROPOSTA-SASSE */
                    _.Move(PROPVA.DCLPROPOSTAS_VA.COD_CCT, LXFCT004.REG_PROPOSTA_SASSE.R3_CGC_CONVENENTE);

                    /*" -2694- ELSE */
                }
                else
                {


                    /*" -2697- MOVE ZEROS TO R3-PCT-DESCONTO OF REG-PROPOSTA-SASSE R3-CGC-CONVENENTE OF REG-PROPOSTA-SASSE */
                    _.Move(0, LXFCT004.REG_PROPOSTA_SASSE.R3_PCT_DESCONTO, LXFCT004.REG_PROPOSTA_SASSE.R3_CGC_CONVENENTE);

                    /*" -2698- ELSE */
                }

            }
            else
            {


                /*" -2702- MOVE ZEROS TO R3-PCT-DESCONTO OF REG-PROPOSTA-SASSE R3-CGC-CONVENENTE OF REG-PROPOSTA-SASSE. */
                _.Move(0, LXFCT004.REG_PROPOSTA_SASSE.R3_PCT_DESCONTO, LXFCT004.REG_PROPOSTA_SASSE.R3_CGC_CONVENENTE);
            }


            /*" -2708- MOVE SPACES TO R3-NOME-CONVENENTE OF REG-PROPOSTA-SASSE. */
            _.Move("", LXFCT004.REG_PROPOSTA_SASSE.R3_NOME_CONVENENTE);

            /*" -2711- MOVE 'MAN' TO R3-SIT-PROPOSTA OF REG-PROPOSTA-SASSE. */
            _.Move("MAN", LXFCT004.REG_PROPOSTA_SASSE.R3_SIT_PROPOSTA);

            /*" -2714- MOVE 'PAG' TO R3-SIT-COBRANCA OF REG-PROPOSTA-SASSE. */
            _.Move("PAG", LXFCT004.REG_PROPOSTA_SASSE.R3_SIT_COBRANCA);

            /*" -2715- IF COD-ORIGEM-PROPOSTA EQUAL 1009 */

            if (PROPVA.DCLPROPOSTAS_VA.COD_ORIGEM_PROPOSTA == 1009)
            {

                /*" -2717- MOVE 09 TO R3-ORIGEM-PROPOSTA OF REG-PROPOSTA-SASSE */
                _.Move(09, LXFCT004.REG_PROPOSTA_SASSE.R3_ORIGEM_PROPOSTA_AIC);

                /*" -2718- ELSE */
            }
            else
            {


                /*" -2719- IF COD-ORIGEM-PROPOSTA EQUAL 1010 */

                if (PROPVA.DCLPROPOSTAS_VA.COD_ORIGEM_PROPOSTA == 1010)
                {

                    /*" -2721- MOVE 10 TO R3-ORIGEM-PROPOSTA OF REG-PROPOSTA-SASSE */
                    _.Move(10, LXFCT004.REG_PROPOSTA_SASSE.R3_ORIGEM_PROPOSTA_AIC);

                    /*" -2722- ELSE */
                }
                else
                {


                    /*" -2724- MOVE 06 TO R3-ORIGEM-PROPOSTA OF REG-PROPOSTA-SASSE */
                    _.Move(06, LXFCT004.REG_PROPOSTA_SASSE.R3_ORIGEM_PROPOSTA_AIC);

                    /*" -2725- END-IF */
                }


                /*" -2727- END-IF */
            }


            /*" -2730- MOVE ZEROS TO R3-SIT-MOTIVO OF REG-PROPOSTA-SASSE. */
            _.Move(0, LXFCT004.REG_PROPOSTA_SASSE.R3_SIT_MOTIVO);

            /*" -2733- MOVE IND-TP-PROPOSTA OF DCLPROPOSTA-FIDELIZ TO R3-INDIC-TIPO-PROPOSTA OF REG-PROPOSTA-SASSE. */
            _.Move(PROPFID.DCLPROPOSTA_FIDELIZ.IND_TP_PROPOSTA, LXFCT004.REG_PROPOSTA_SASSE.R3_INDIC_TIPO_PROPOSTA);

            /*" -2736- MOVE OPCAO-COBERTURA OF DCLPROPOSTAS-VA TO R3-OPCAO-COBER OF REG-PROPOSTA-SASSE. */
            _.Move(PROPVA.DCLPROPOSTAS_VA.OPCAO_COBERTURA, LXFCT004.REG_PROPOSTA_SASSE.R3_OPCAO_COBER);

            /*" -2739- MOVE ZEROS TO R3-COD-PLANO OF REG-PROPOSTA-SASSE. */
            _.Move(0, LXFCT004.REG_PROPOSTA_SASSE.R3_COD_PLANO);

            /*" -2742- MOVE DATA-QUITACAO OF DCLPROPOSTAS-VA TO W-DATA-SQL. */
            _.Move(PROPVA.DCLPROPOSTAS_VA.DATA_QUITACAO, WAREA_AUXILIAR.W_DATA_SQL);

            /*" -2743- MOVE W-DIA-SQL TO W-DIA-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_DIA_SQL, WAREA_AUXILIAR.FILLER_2.W_DIA_TRABALHO);

            /*" -2744- MOVE W-MES-SQL TO W-MES-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_MES_SQL, WAREA_AUXILIAR.FILLER_2.W_MES_TRABALHO);

            /*" -2745- MOVE W-ANO-SQL TO W-ANO-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_ANO_SQL, WAREA_AUXILIAR.FILLER_2.W_ANO_TRABALHO);

            /*" -2751- MOVE W-DATA-TRABALHO TO R3-DTQITBCO OF REG-PROPOSTA-SASSE. */
            _.Move(WAREA_AUXILIAR.W_DATA_TRABALHO, LXFCT004.REG_PROPOSTA_SASSE.R3_DTQITBCO);

            /*" -2754- MOVE AGE-COBRANCA OF DCLPROPOSTAS-VA TO R3-AGEPGTO OF REG-PROPOSTA-SASSE. */
            _.Move(PROPVA.DCLPROPOSTAS_VA.AGE_COBRANCA, LXFCT004.REG_PROPOSTA_SASSE.R3_AGEPGTO);

            /*" -2765- MOVE VAL-TARIFA OF DCLTARIFA-BALCAO-CEF TO R3-VAL-TARIFA OF REG-PROPOSTA-SASSE. */
            _.Move(TARIBCEF.DCLTARIFA_BALCAO_CEF.VAL_TARIFA, LXFCT004.REG_PROPOSTA_SASSE.R3_VAL_TARIFA);

            /*" -2766- IF COD-ORIGEM-PROPOSTA OF DCLPROPOSTAS-VA = 12 */

            if (PROPVA.DCLPROPOSTAS_VA.COD_ORIGEM_PROPOSTA == 12)
            {

                /*" -2767- MOVE ZEROS TO R3-VAL-PAGO OF REG-PROPOSTA-SASSE */
                _.Move(0, LXFCT004.REG_PROPOSTA_SASSE.R3_VAL_PAGO);

                /*" -2768- MOVE ZEROS TO R3-DATA-CREDITO OF REG-PROPOSTA-SASSE */
                _.Move(0, LXFCT004.REG_PROPOSTA_SASSE.R3_DATA_CREDITO);

                /*" -2770- IF CONTPARCELVA = 'S' */

                if (CONTPARCELVA == "S")
                {

                    /*" -2774- COMPUTE R3-VAL-PAGO OF REG-PROPOSTA-SASSE = PREMIO-VG OF DCLHIST-CONT-PARCELVA + PREMIO-AP OF DCLHIST-CONT-PARCELVA */
                    LXFCT004.REG_PROPOSTA_SASSE.R3_VAL_PAGO.Value = HTCTBPVA.DCLHIST_CONT_PARCELVA.PREMIO_VG + HTCTBPVA.DCLHIST_CONT_PARCELVA.PREMIO_AP;

                    /*" -2777- MOVE DATA-MOVIMENTO OF DCLHIST-CONT-PARCELVA TO W-DATA-SQL */
                    _.Move(HTCTBPVA.DCLHIST_CONT_PARCELVA.DATA_MOVIMENTO, WAREA_AUXILIAR.W_DATA_SQL);

                    /*" -2778- MOVE W-DIA-SQL TO W-DIA-TRABALHO */
                    _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_DIA_SQL, WAREA_AUXILIAR.FILLER_2.W_DIA_TRABALHO);

                    /*" -2779- MOVE W-MES-SQL TO W-MES-TRABALHO */
                    _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_MES_SQL, WAREA_AUXILIAR.FILLER_2.W_MES_TRABALHO);

                    /*" -2780- MOVE W-ANO-SQL TO W-ANO-TRABALHO */
                    _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_ANO_SQL, WAREA_AUXILIAR.FILLER_2.W_ANO_TRABALHO);

                    /*" -2782- MOVE W-DATA-TRABALHO TO R3-DATA-CREDITO */
                    _.Move(WAREA_AUXILIAR.W_DATA_TRABALHO, LXFCT004.REG_PROPOSTA_SASSE.R3_DATA_CREDITO);

                    /*" -2783- ELSE */
                }
                else
                {


                    /*" -2786- MOVE VLPREMIO OF DCLHIS-COBER-PROPOST TO R3-VAL-PAGO OF REG-PROPOSTA-SASSE */
                    _.Move(COBPRPVA.DCLHIS_COBER_PROPOST.VLPREMIO, LXFCT004.REG_PROPOSTA_SASSE.R3_VAL_PAGO);

                    /*" -2789- MOVE DATA-QUITACAO OF DCLPROPOSTAS-VA TO W-DATA-SQL */
                    _.Move(PROPVA.DCLPROPOSTAS_VA.DATA_QUITACAO, WAREA_AUXILIAR.W_DATA_SQL);

                    /*" -2790- MOVE W-DIA-SQL TO W-DIA-TRABALHO */
                    _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_DIA_SQL, WAREA_AUXILIAR.FILLER_2.W_DIA_TRABALHO);

                    /*" -2791- MOVE W-MES-SQL TO W-MES-TRABALHO */
                    _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_MES_SQL, WAREA_AUXILIAR.FILLER_2.W_MES_TRABALHO);

                    /*" -2792- MOVE W-ANO-SQL TO W-ANO-TRABALHO */
                    _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_ANO_SQL, WAREA_AUXILIAR.FILLER_2.W_ANO_TRABALHO);

                    /*" -2793- MOVE W-DATA-TRABALHO TO R3-DATA-CREDITO */
                    _.Move(WAREA_AUXILIAR.W_DATA_TRABALHO, LXFCT004.REG_PROPOSTA_SASSE.R3_DATA_CREDITO);

                    /*" -2794- END-IF */
                }


                /*" -2795- ELSE */
            }
            else
            {


                /*" -2798- IF COD-ORIGEM-PROPOSTA OF DCLPROPOSTAS-VA = 1005 OR 1009 OR 1010 */

                if (PROPVA.DCLPROPOSTAS_VA.COD_ORIGEM_PROPOSTA.In("1005", "1009", "1010"))
                {

                    /*" -2801- COMPUTE R3-VAL-PAGO OF REG-PROPOSTA-SASSE = PREMIO-VG OF DCLHIST-CONT-PARCELVA + PREMIO-AP OF DCLHIST-CONT-PARCELVA */
                    LXFCT004.REG_PROPOSTA_SASSE.R3_VAL_PAGO.Value = HTCTBPVA.DCLHIST_CONT_PARCELVA.PREMIO_VG + HTCTBPVA.DCLHIST_CONT_PARCELVA.PREMIO_AP;

                    /*" -2803- MOVE DATA-MOVIMENTO OF DCLHIST-CONT-PARCELVA TO W-DATA-SQL */
                    _.Move(HTCTBPVA.DCLHIST_CONT_PARCELVA.DATA_MOVIMENTO, WAREA_AUXILIAR.W_DATA_SQL);

                    /*" -2804- ELSE */
                }
                else
                {


                    /*" -2807- MOVE RCAPS-VAL-RCAP OF DCLRCAPS TO R3-VAL-PAGO OF REG-PROPOSTA-SASSE */
                    _.Move(RCAPS.DCLRCAPS.RCAPS_VAL_RCAP, LXFCT004.REG_PROPOSTA_SASSE.R3_VAL_PAGO);

                    /*" -2809- MOVE RCAPS-DATA-MOVIMENTO OF DCLRCAPS TO W-DATA-SQL */
                    _.Move(RCAPS.DCLRCAPS.RCAPS_DATA_MOVIMENTO, WAREA_AUXILIAR.W_DATA_SQL);

                    /*" -2811- END-IF */
                }


                /*" -2812- MOVE W-DIA-SQL TO W-DIA-TRABALHO */
                _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_DIA_SQL, WAREA_AUXILIAR.FILLER_2.W_DIA_TRABALHO);

                /*" -2813- MOVE W-MES-SQL TO W-MES-TRABALHO */
                _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_MES_SQL, WAREA_AUXILIAR.FILLER_2.W_MES_TRABALHO);

                /*" -2814- MOVE W-ANO-SQL TO W-ANO-TRABALHO */
                _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_ANO_SQL, WAREA_AUXILIAR.FILLER_2.W_ANO_TRABALHO);

                /*" -2816- MOVE W-DATA-TRABALHO TO R3-DATA-CREDITO OF REG-PROPOSTA-SASSE */
                _.Move(WAREA_AUXILIAR.W_DATA_TRABALHO, LXFCT004.REG_PROPOSTA_SASSE.R3_DATA_CREDITO);

                /*" -2819- END-IF */
            }


            /*" -2823- COMPUTE R3-VAL-COMISSAO OF REG-PROPOSTA-SASSE = VAL-COMISSAO-VG OF DCLFUNDO-COMISSAO-VA + VAL-COMISSAO-AP OF DCLFUNDO-COMISSAO-VA */
            LXFCT004.REG_PROPOSTA_SASSE.R3_VAL_COMISSAO.Value = FDCOMVA.DCLFUNDO_COMISSAO_VA.VAL_COMISSAO_VG + FDCOMVA.DCLFUNDO_COMISSAO_VA.VAL_COMISSAO_AP;

            /*" -2824- IF OPPAGVA-PERI-PAGAMENTO EQUAL 1 */

            if (OPPAGVA.DCLOPCAO_PAG_VIDAZUL.OPPAGVA_PERI_PAGAMENTO == 1)
            {

                /*" -2826- COMPUTE R3-VALOR-PREMIO-TOTAL OF REG-PROPOSTA-SASSE = R3-VAL-PAGO OF REG-PROPOSTA-SASSE * 12 */
                LXFCT004.REG_PROPOSTA_SASSE.R3_VALOR_PREMIO_TOTAL.Value = LXFCT004.REG_PROPOSTA_SASSE.R3_VAL_PAGO * 12;

                /*" -2827- ELSE */
            }
            else
            {


                /*" -2829- MOVE R3-VAL-PAGO OF REG-PROPOSTA-SASSE TO R3-VALOR-PREMIO-TOTAL OF REG-PROPOSTA-SASSE */
                _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_VAL_PAGO, LXFCT004.REG_PROPOSTA_SASSE.R3_VALOR_PREMIO_TOTAL);

                /*" -2831- END-IF */
            }


            /*" -2834- MOVE ARQSIVPF-NSAS-SIVPF OF DCLARQUIVOS-SIVPF TO R3-NSAS OF REG-PROPOSTA-SASSE. */
            _.Move(ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF, LXFCT004.REG_PROPOSTA_SASSE.R3_NSAS);

            /*" -2836- ADD 1 TO W-QTD-LD-TIPO-3. */
            WAREA_AUXILIAR.W_QTD_LD_TIPO_3.Value = WAREA_AUXILIAR.W_QTD_LD_TIPO_3 + 1;

            /*" -2839- MOVE W-QTD-LD-TIPO-3 TO R3-NSL OF REG-PROPOSTA-SASSE. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_3, LXFCT004.REG_PROPOSTA_SASSE.R3_NSL);

            /*" -2841- WRITE REG-PRP-SASSE FROM REG-PROPOSTA-SASSE. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.GetMoveValues(), REG_PRP_SASSE);

            MOVTO_PRP_SASSE.Write(REG_PRP_SASSE.GetMoveValues().ToString());

            /*" -2842- MOVE MOVVGAP-NUM-CERTIFICADO TO R3-NUM-PROPOSTA OF REG-PROPOSTA-SASSE. */
            _.Move(MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_NUM_CERTIFICADO, LXFCT004.REG_PROPOSTA_SASSE.R3_NUM_PROPOSTA);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0700_SAIDA*/

        [StopWatch]
        /*" R0750-PROCESSAR-BENEFICIARIOS-SECTION */
        private void R0750_PROCESSAR_BENEFICIARIOS_SECTION()
        {
            /*" -2855- MOVE 'R0750-PROCESSAR-BENEFICIARIOS' TO PARAGRAFO. */
            _.Move("R0750-PROCESSAR-BENEFICIARIOS", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2858- MOVE SPACES TO REG-BENEFIC, REG-PRP-SASSE. */
            _.Move("", LBFPF014.REG_BENEFIC, REG_PRP_SASSE);

            /*" -2861- MOVE '4' TO R4-TIPO-REG OF REG-BENEFIC. */
            _.Move("4", LBFPF014.REG_BENEFIC.R4_TIPO_REG);

            /*" -2865- MOVE W-NUM-PROPOSTA-NOVA TO R4-NUM-PROPOSTA OF REG-BENEFIC. */
            _.Move(WAREA_AUXILIAR.W_NUM_PROPOSTA_NOVA, LBFPF014.REG_BENEFIC.R4_NUM_PROPOSTA);

            /*" -2875- MOVE ZEROS TO R4-DATA-NASCIMENTO OF REG-BENEFIC, R4-CGC-CPF OF REG-BENEFIC, R4-SEXO OF REG-BENEFIC, R4-ESTADO-CIVIL OF REG-BENEFIC, R4-PCT-FGB OF REG-BENEFIC, R4-PCT-PECULIO OF REG-BENEFIC, R4-PCT-PENSAO OF REG-BENEFIC, R4-QTDE-TITULOS OF REG-BENEFIC. */
            _.Move(0, LBFPF014.REG_BENEFIC.R4_DATA_NASCIMENTO, LBFPF014.REG_BENEFIC.R4_CGC_CPF, LBFPF014.REG_BENEFIC.R4_SEXO, LBFPF014.REG_BENEFIC.R4_ESTADO_CIVIL, LBFPF014.REG_BENEFIC.R4_PCT_FGB, LBFPF014.REG_BENEFIC.R4_PCT_PECULIO, LBFPF014.REG_BENEFIC.R4_PCT_PENSAO, LBFPF014.REG_BENEFIC.R4_QTDE_TITULOS);

            /*" -2878- MOVE SPACES TO W-FIM-BENEFICIARIOS. */
            _.Move("", WAREA_AUXILIAR.W_FIM_BENEFICIARIOS);

            /*" -2880- PERFORM R0800-00-CURSOR-BENEFICIARIOS. */

            R0800_00_CURSOR_BENEFICIARIOS_SECTION();

            /*" -2882- PERFORM R0850-00-LER-BENEFICIARIOS. */

            R0850_00_LER_BENEFICIARIOS_SECTION();

            /*" -2883- PERFORM R0900-00-GERAR-REGISTRO-TP4 UNTIL W-FIM-BENEFICIARIOS EQUAL 'FIM' . */

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
            /*" -2894- MOVE 'R0800-00-CURSOR-BENEFICIARIOS' TO PARAGRAFO. */
            _.Move("R0800-00-CURSOR-BENEFICIARIOS", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2897- MOVE MOVVGAP-NUM-APOLICE TO BENEFPRO-NUM-APOLICE */
            _.Move(MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_NUM_APOLICE, BENEFPRO.DCLBENEFICIARIOS_PROP.BENEFPRO_NUM_APOLICE);

            /*" -2900- MOVE MOVVGAP-COD-SUBGRUPO TO BENEFPRO-COD-SUBGRUPO */
            _.Move(MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_COD_SUBGRUPO, BENEFPRO.DCLBENEFICIARIOS_PROP.BENEFPRO_COD_SUBGRUPO);

            /*" -2903- MOVE MOVVGAP-COD-FONTE TO BENEFPRO-COD-FONTE */
            _.Move(MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_COD_FONTE, BENEFPRO.DCLBENEFICIARIOS_PROP.BENEFPRO_COD_FONTE);

            /*" -2906- MOVE MOVVGAP-NUM-PROPOSTA TO BENEFPRO-NUM-PROPOSTA */
            _.Move(MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_NUM_PROPOSTA, BENEFPRO.DCLBENEFICIARIOS_PROP.BENEFPRO_NUM_PROPOSTA);

            /*" -2926- PERFORM R0800_00_CURSOR_BENEFICIARIOS_DB_DECLARE_1 */

            R0800_00_CURSOR_BENEFICIARIOS_DB_DECLARE_1();

            /*" -2928- PERFORM R0800_00_CURSOR_BENEFICIARIOS_DB_OPEN_1 */

            R0800_00_CURSOR_BENEFICIARIOS_DB_OPEN_1();

        }

        [StopWatch]
        /*" R0800-00-CURSOR-BENEFICIARIOS-DB-OPEN-1 */
        public void R0800_00_CURSOR_BENEFICIARIOS_DB_OPEN_1()
        {
            /*" -2928- EXEC SQL OPEN BENEFICIARIOS END-EXEC. */

            BENEFICIARIOS.Open();

        }

        [StopWatch]
        /*" R3136-RELACIONA-EMAIL-DB-DECLARE-1 */
        public void R3136_RELACIONA_EMAIL_DB_DECLARE_1()
        {
            /*" -3798- EXEC SQL DECLARE EMAIL CURSOR FOR SELECT COD_PESSOA, SEQ_EMAIL, EMAIL, SITUACAO_EMAIL FROM SEGUROS.PESSOA_EMAIL WHERE COD_PESSOA = :DCLPESSOA-EMAIL.COD-PESSOA ORDER BY SEQ_EMAIL WITH UR END-EXEC. */
            EMAIL = new PF0612B_EMAIL(true);
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
            /*" -2939- MOVE 'R0850-00-LER-BENEFICIARIOS' TO PARAGRAFO. */
            _.Move("R0850-00-LER-BENEFICIARIOS", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2949- PERFORM R0850_00_LER_BENEFICIARIOS_DB_FETCH_1 */

            R0850_00_LER_BENEFICIARIOS_DB_FETCH_1();

            /*" -2952- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -2953- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2954- MOVE 'FIM' TO W-FIM-BENEFICIARIOS */
                    _.Move("FIM", WAREA_AUXILIAR.W_FIM_BENEFICIARIOS);

                    /*" -2954- PERFORM R0850_00_LER_BENEFICIARIOS_DB_CLOSE_1 */

                    R0850_00_LER_BENEFICIARIOS_DB_CLOSE_1();

                    /*" -2956- ELSE */
                }
                else
                {


                    /*" -2957- DISPLAY 'PF0612B - FIM ANORMAL' */
                    _.Display($"PF0612B - FIM ANORMAL");

                    /*" -2959- DISPLAY '          ERRO FETCH BENEFICIARIOS ' SQLCODE */
                    _.Display($"          ERRO FETCH BENEFICIARIOS {DB.SQLCODE}");

                    /*" -2960- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -2960- PERFORM R9999-00-FINALIZAR. */

                    R9999_00_FINALIZAR_SECTION();
                }

            }


        }

        [StopWatch]
        /*" R0850-00-LER-BENEFICIARIOS-DB-FETCH-1 */
        public void R0850_00_LER_BENEFICIARIOS_DB_FETCH_1()
        {
            /*" -2949- EXEC SQL FETCH BENEFICIARIOS INTO :BENEFPRO-NUM-APOLICE , :BENEFPRO-COD-SUBGRUPO , :BENEFPRO-COD-FONTE , :BENEFPRO-NUM-PROPOSTA , :BENEFPRO-NUM-BENEFICIARIO , :BENEFPRO-NOME-BENEFICIARIO , :BENEFPRO-GRAU-PARENTESCO , :BENEFPRO-PCT-PART-BENEFICIA END-EXEC. */

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
            /*" -2954- EXEC SQL CLOSE BENEFICIARIOS END-EXEC */

            BENEFICIARIOS.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0850_SAIDA*/

        [StopWatch]
        /*" R0900-00-GERAR-REGISTRO-TP4-SECTION */
        private void R0900_00_GERAR_REGISTRO_TP4_SECTION()
        {
            /*" -2971- MOVE 'R0900-00-GERA-REGISTRO-TP4' TO PARAGRAFO. */
            _.Move("R0900-00-GERA-REGISTRO-TP4", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2974- MOVE BENEFPRO-NOME-BENEFICIARIO TO R4-NOME OF REG-BENEFIC. */
            _.Move(BENEFPRO.DCLBENEFICIARIOS_PROP.BENEFPRO_NOME_BENEFICIARIO, LBFPF014.REG_BENEFIC.R4_NOME);

            /*" -2977- IF BENEFPRO-GRAU-PARENTESCO EQUAL 'CONJUGE' OR 'MARIDO' OR 'MULHER' OR 'ESPOSA' OR 'ESPOSO' */

            if (BENEFPRO.DCLBENEFICIARIOS_PROP.BENEFPRO_GRAU_PARENTESCO.In("CONJUGE", "MARIDO", "MULHER", "ESPOSA", "ESPOSO"))
            {

                /*" -2979- MOVE 1 TO R4-GRAU-PARENTESCO OF REG-BENEFIC */
                _.Move(1, LBFPF014.REG_BENEFIC.R4_GRAU_PARENTESCO);

                /*" -2980- ELSE */
            }
            else
            {


                /*" -2982- IF BENEFPRO-GRAU-PARENTESCO EQUAL 'COMPANHEIRO(A)' */

                if (BENEFPRO.DCLBENEFICIARIOS_PROP.BENEFPRO_GRAU_PARENTESCO == "COMPANHEIRO(A)")
                {

                    /*" -2984- MOVE 2 TO R4-GRAU-PARENTESCO OF REG-BENEFIC */
                    _.Move(2, LBFPF014.REG_BENEFIC.R4_GRAU_PARENTESCO);

                    /*" -2985- ELSE */
                }
                else
                {


                    /*" -2987- IF BENEFPRO-GRAU-PARENTESCO EQUAL 'FILHOS' OR 'FILHO' OR 'FILHA' */

                    if (BENEFPRO.DCLBENEFICIARIOS_PROP.BENEFPRO_GRAU_PARENTESCO.In("FILHOS", "FILHO", "FILHA"))
                    {

                        /*" -2989- MOVE 3 TO R4-GRAU-PARENTESCO OF REG-BENEFIC */
                        _.Move(3, LBFPF014.REG_BENEFIC.R4_GRAU_PARENTESCO);

                        /*" -2990- ELSE */
                    }
                    else
                    {


                        /*" -2992- IF BENEFPRO-GRAU-PARENTESCO EQUAL 'PAIS' OR 'PAI' OR 'MAE' */

                        if (BENEFPRO.DCLBENEFICIARIOS_PROP.BENEFPRO_GRAU_PARENTESCO.In("PAIS", "PAI", "MAE"))
                        {

                            /*" -2994- MOVE 4 TO R4-GRAU-PARENTESCO OF REG-BENEFIC */
                            _.Move(4, LBFPF014.REG_BENEFIC.R4_GRAU_PARENTESCO);

                            /*" -2995- ELSE */
                        }
                        else
                        {


                            /*" -2997- IF BENEFPRO-GRAU-PARENTESCO EQUAL 'IRMAOS' OR 'IRMAO' OR 'IRMA' */

                            if (BENEFPRO.DCLBENEFICIARIOS_PROP.BENEFPRO_GRAU_PARENTESCO.In("IRMAOS", "IRMAO", "IRMA"))
                            {

                                /*" -2999- MOVE 5 TO R4-GRAU-PARENTESCO OF REG-BENEFIC */
                                _.Move(5, LBFPF014.REG_BENEFIC.R4_GRAU_PARENTESCO);

                                /*" -3000- ELSE */
                            }
                            else
                            {


                                /*" -3003- MOVE 6 TO R4-GRAU-PARENTESCO OF REG-BENEFIC. */
                                _.Move(6, LBFPF014.REG_BENEFIC.R4_GRAU_PARENTESCO);
                            }

                        }

                    }

                }

            }


            /*" -3006- MOVE BENEFPRO-PCT-PART-BENEFICIA TO R4-PCT-PARTICIP OF REG-BENEFIC. */
            _.Move(BENEFPRO.DCLBENEFICIARIOS_PROP.BENEFPRO_PCT_PART_BENEFICIA, LBFPF014.REG_BENEFIC.R4_PCT_PARTICIP);

            /*" -3008- WRITE REG-PRP-SASSE FROM REG-BENEFIC. */
            _.Move(LBFPF014.REG_BENEFIC.GetMoveValues(), REG_PRP_SASSE);

            MOVTO_PRP_SASSE.Write(REG_PRP_SASSE.GetMoveValues().ToString());

            /*" -3010- ADD 1 TO W-QTD-LD-TIPO-4. */
            WAREA_AUXILIAR.W_QTD_LD_TIPO_4.Value = WAREA_AUXILIAR.W_QTD_LD_TIPO_4 + 1;

            /*" -3010- PERFORM R0850-00-LER-BENEFICIARIOS. */

            R0850_00_LER_BENEFICIARIOS_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0900_SAIDA*/

        [StopWatch]
        /*" R0950-00-GERAR-REGISTRO-TPD-SECTION */
        private void R0950_00_GERAR_REGISTRO_TPD_SECTION()
        {
            /*" -3022- MOVE '*' TO LK-GE053-E-TRACE */
            _.Move("*", SPGE053W.LK_GE053_E_TRACE);

            /*" -3023- MOVE 'PF' TO LK-GE053-E-IDE-SISTEMA */
            _.Move("PF", SPGE053W.LK_GE053_E_IDE_SISTEMA);

            /*" -3026- MOVE 2 TO LK-GE053-E-IND-OPERACAO */
            _.Move(2, SPGE053W.LK_GE053_E_IND_OPERACAO);

            /*" -3027- MOVE CGCCPF OF DCLCLIENTES TO LK-GE053-I-NUM-CPF. */
            _.Move(CLIENTE.DCLCLIENTES.CGCCPF, SPGE053W.LK_GE053_I_NUM_CPF);

            /*" -3029- MOVE '0001-01-01-00.00.00.000000' TO LK-GE053-I-DTH-OPERACAO. */
            _.Move("0001-01-01-00.00.00.000000", SPGE053W.LK_GE053_I_DTH_OPERACAO);

            /*" -3030- MOVE SPACES TO LK-GE053-I-NOM-SOCIAL. */
            _.Move("", SPGE053W.LK_GE053_I_NOM_SOCIAL);

            /*" -3031- MOVE SPACES TO LK-GE053-I-IND-TIPO-ACAO. */
            _.Move("", SPGE053W.LK_GE053_I_IND_TIPO_ACAO);

            /*" -3032- MOVE SPACES TO LK-GE053-I-IND-USA-NOME-SOCIAL. */
            _.Move("", SPGE053W.LK_GE053_I_IND_USA_NOME_SOCIAL);

            /*" -3033- MOVE 0 TO LK-GE053-I-COD-TP-PES-NEGOCIO. */
            _.Move(0, SPGE053W.LK_GE053_I_COD_TP_PES_NEGOCIO);

            /*" -3034- MOVE 0 TO LK-GE053-I-NUM-PROPOSTA. */
            _.Move(0, SPGE053W.LK_GE053_I_NUM_PROPOSTA);

            /*" -3035- MOVE SPACES TO LK-GE053-I-COD-CANAL-ORIGEM. */
            _.Move("", SPGE053W.LK_GE053_I_COD_CANAL_ORIGEM);

            /*" -3036- MOVE SPACES TO LK-GE053-I-NUM-MATRICULA. */
            _.Move("", SPGE053W.LK_GE053_I_NUM_MATRICULA);

            /*" -3037- MOVE SPACES TO LK-GE053-I-NOM-PROGRAMA. */
            _.Move("", SPGE053W.LK_GE053_I_NOM_PROGRAMA);

            /*" -3040- MOVE '0001-01-01-00.00.00.000000' TO LK-GE053-I-DTH-CADASTRAMENTO. */
            _.Move("0001-01-01-00.00.00.000000", SPGE053W.LK_GE053_I_DTH_CADASTRAMENTO);

            /*" -3062- CALL 'SPBGE053' USING LK-GE053-E-TRACE LK-GE053-E-IDE-SISTEMA LK-GE053-E-IND-OPERACAO LK-GE053-I-NUM-CPF LK-GE053-I-DTH-OPERACAO LK-GE053-I-NOM-SOCIAL LK-GE053-I-IND-TIPO-ACAO LK-GE053-I-IND-USA-NOME-SOCIAL LK-GE053-I-COD-TP-PES-NEGOCIO LK-GE053-I-NUM-PROPOSTA LK-GE053-I-COD-CANAL-ORIGEM LK-GE053-I-NUM-MATRICULA LK-GE053-I-NOM-PROGRAMA LK-GE053-I-DTH-CADASTRAMENTO LK-GE053-IND-ERRO LK-GE053-ID-ERRO LK-GE053-MENSAGEM LK-GE053-NOM-TABELA LK-GE053-SQLCODE LK-GE053-SQLERRMC LK-GE053-SQLSTATE. */
            _.Call("SPBGE053", SPGE053W);

            /*" -3063- IF LK-GE053-IND-ERRO NOT EQUAL ZERO */

            if (SPGE053W.LK_GE053_IND_ERRO != 00)
            {

                /*" -3064- DISPLAY 'ERRO NO PROCESSAMENTO DO NOME SOCIAL' */
                _.Display($"ERRO NO PROCESSAMENTO DO NOME SOCIAL");

                /*" -3065- DISPLAY 'LK-GE053-IND-ERRO   ' LK-GE053-IND-ERRO */
                _.Display($"LK-GE053-IND-ERRO   {SPGE053W.LK_GE053_IND_ERRO}");

                /*" -3066- DISPLAY 'LK-GE053-ID-ERRO    ' LK-GE053-ID-ERRO */
                _.Display($"LK-GE053-ID-ERRO    {SPGE053W.LK_GE053_ID_ERRO}");

                /*" -3067- DISPLAY 'LK-GE053-MENSAGEM   ' LK-GE053-MENSAGEM */
                _.Display($"LK-GE053-MENSAGEM   {SPGE053W.LK_GE053_MENSAGEM}");

                /*" -3068- IF LK-GE053-SQLCODE NOT EQUAL ZERO */

                if (SPGE053W.LK_GE053_SQLCODE != 00)
                {

                    /*" -3069- DISPLAY 'LK-GE053-NOM-TABELA ' LK-GE053-NOM-TABELA */
                    _.Display($"LK-GE053-NOM-TABELA {SPGE053W.LK_GE053_NOM_TABELA}");

                    /*" -3070- DISPLAY 'LK-GE053-SQLCODE    ' LK-GE053-SQLCODE */
                    _.Display($"LK-GE053-SQLCODE    {SPGE053W.LK_GE053_SQLCODE}");

                    /*" -3071- DISPLAY 'LK-GE053-SQLERRMC   ' LK-GE053-SQLERRMC */
                    _.Display($"LK-GE053-SQLERRMC   {SPGE053W.LK_GE053_SQLERRMC}");

                    /*" -3072- DISPLAY 'LK-GE053-SQLSTATE   ' LK-GE053-SQLSTATE */
                    _.Display($"LK-GE053-SQLSTATE   {SPGE053W.LK_GE053_SQLSTATE}");

                    /*" -3073- END-IF */
                }


                /*" -3074- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -3075- PERFORM R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION();

                /*" -3077- END-IF. */
            }


            /*" -3078- IF LK-GE053-I-NUM-PROPOSTA NOT EQUAL ZERO */

            if (SPGE053W.LK_GE053_I_NUM_PROPOSTA != 00)
            {

                /*" -3079- MOVE 'D' TO RSD-TIPO-REG */
                _.Move("D", LXFPF028.REG_TIPO_D.RSD_TIPO_REG);

                /*" -3080- MOVE LK-GE053-I-NUM-PROPOSTA TO RSD-NUM-PROPOSTA */
                _.Move(SPGE053W.LK_GE053_I_NUM_PROPOSTA, LXFPF028.REG_TIPO_D.RSD_NUM_PROPOSTA);

                /*" -3081- MOVE LK-GE053-I-NOM-SOCIAL TO RSD-NOME-SOCIAL */
                _.Move(SPGE053W.LK_GE053_I_NOM_SOCIAL, LXFPF028.REG_TIPO_D.RSD_NOME_SOCIAL);

                /*" -3082- MOVE SPACES TO RSD-FILLER */
                _.Move("", LXFPF028.REG_TIPO_D.RSD_FILLER);

                /*" -3083- WRITE REG-PRP-SASSE FROM REG-TIPO-D */
                _.Move(LXFPF028.REG_TIPO_D.GetMoveValues(), REG_PRP_SASSE);

                MOVTO_PRP_SASSE.Write(REG_PRP_SASSE.GetMoveValues().ToString());

                /*" -3083- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0950_SAIDA*/

        [StopWatch]
        /*" R1000-00-GERAR-TRAILLER-SECTION */
        private void R1000_00_GERAR_TRAILLER_SECTION()
        {
            /*" -3093- MOVE 'R1000-00-GERAR-TRAILLER' TO PARAGRAFO. */
            _.Move("R1000-00-GERAR-TRAILLER", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3095- MOVE 'WRITE REG-TRAILLER' TO COMANDO. */
            _.Move("WRITE REG-TRAILLER", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3098- MOVE SPACES TO REG-TRAILLER, REG-PRP-SASSE */
            _.Move("", LBFPF991.REG_TRAILLER, REG_PRP_SASSE);

            /*" -3101- MOVE 'T' TO RT-TIPO-REG OF REG-TRAILLER. */
            _.Move("T", LBFPF991.REG_TRAILLER.RT_TIPO_REG);

            /*" -3104- MOVE 'PRPSASSE' TO RT-NOME-EMPRESA OF REG-TRAILLER. */
            _.Move("PRPSASSE", LBFPF991.REG_TRAILLER.RT_NOME_EMPRESA);

            /*" -3107- MOVE W-QTD-LD-TIPO-0 TO RT-QTDE-TIPO-0 OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_0, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_0);

            /*" -3110- MOVE W-QTD-LD-TIPO-1 TO RT-QTDE-TIPO-1 OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_1, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_1);

            /*" -3113- MOVE W-QTD-LD-TIPO-2 TO RT-QTDE-TIPO-2 OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_2, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_2);

            /*" -3116- MOVE W-QTD-LD-TIPO-3 TO RT-QTDE-TIPO-3 OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_3, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_3);

            /*" -3119- MOVE W-QTD-LD-TIPO-4 TO RT-QTDE-TIPO-4 OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_4, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_4);

            /*" -3122- MOVE W-QTD-LD-TIPO-5 TO RT-QTDE-TIPO-5 OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_5, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_5);

            /*" -3125- MOVE W-QTD-LD-TIPO-6 TO RT-QTDE-TIPO-6 OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_6, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_6);

            /*" -3128- MOVE W-QTD-LD-TIPO-7 TO RT-QTDE-TIPO-7 OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_7, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_7);

            /*" -3131- MOVE W-QTD-LD-TIPO-8 TO RT-QTDE-TIPO-8 OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_8, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_8);

            /*" -3134- MOVE W-QTD-LD-TIPO-9 TO RT-QTDE-TIPO-9 OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_9, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_9);

            /*" -3137- MOVE W-QTD-LD-TIPO-A TO RT-QTDE-TIPO-A OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_A, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_A);

            /*" -3140- MOVE W-QTD-LD-TIPO-B TO RT-QTDE-TIPO-B OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_B, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_B);

            /*" -3143- MOVE W-QTD-LD-TIPO-C TO RT-QTDE-TIPO-C OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_C, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_C);

            /*" -3146- MOVE W-QTD-LD-TIPO-D TO RT-QTDE-TIPO-D OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_D, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_D);

            /*" -3149- MOVE W-QTD-LD-TIPO-E TO RT-QTDE-TIPO-E OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_E, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_E);

            /*" -3152- MOVE W-QTD-LD-TIPO-F TO RT-QTDE-TIPO-F OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_F, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_F);

            /*" -3155- MOVE W-QTD-LD-TIPO-G TO RT-QTDE-TIPO-G OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_G, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_G);

            /*" -3158- MOVE W-QTD-LD-TIPO-H TO RT-QTDE-TIPO-H OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_H, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_H);

            /*" -3161- MOVE W-QTD-LD-TIPO-I TO RT-QTDE-TIPO-I OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_I, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_I);

            /*" -3164- MOVE W-QTD-LD-TIPO-J TO RT-QTDE-TIPO-J OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_J, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_J);

            /*" -3186- COMPUTE RT-QTDE-TOTAL OF REG-TRAILLER = RT-QTDE-TIPO-0 + RT-QTDE-TIPO-1 + RT-QTDE-TIPO-2 + RT-QTDE-TIPO-3 + RT-QTDE-TIPO-4 + RT-QTDE-TIPO-5 + RT-QTDE-TIPO-6 + RT-QTDE-TIPO-7 + RT-QTDE-TIPO-8 + RT-QTDE-TIPO-9 + RT-QTDE-TIPO-A + RT-QTDE-TIPO-B + RT-QTDE-TIPO-C + RT-QTDE-TIPO-D + RT-QTDE-TIPO-E + RT-QTDE-TIPO-F + RT-QTDE-TIPO-G + RT-QTDE-TIPO-H + RT-QTDE-TIPO-I + RT-QTDE-TIPO-J */
            LBFPF991.REG_TRAILLER.RT_QTDE_TOTAL.Value = LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_0 + LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_1 + LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_2 + LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_3 + LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_4 + LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_5 + LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_6 + LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_7 + LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_8 + LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_9 + LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_A + LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_B + LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_C + LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_D + LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_E + LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_F + LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_G + LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_H + LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_I + LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_J;

            /*" -3186- WRITE REG-PRP-SASSE FROM REG-TRAILLER. */
            _.Move(LBFPF991.REG_TRAILLER.GetMoveValues(), REG_PRP_SASSE);

            MOVTO_PRP_SASSE.Write(REG_PRP_SASSE.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_SAIDA*/

        [StopWatch]
        /*" R1050-00-CONTROLAR-ARQ-ENVIADO-SECTION */
        private void R1050_00_CONTROLAR_ARQ_ENVIADO_SECTION()
        {
            /*" -3199- MOVE 'R1050-00-CONTROLAR-ARQ-ENVIADO' TO PARAGRAFO. */
            _.Move("R1050-00-CONTROLAR-ARQ-ENVIADO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3201- MOVE 'INSERT ARQUIVOS-SIVPF' TO COMANDO. */
            _.Move("INSERT ARQUIVOS-SIVPF", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3204- MOVE 'PRPSASSE' TO ARQSIVPF-SIGLA-ARQUIVO OF DCLARQUIVOS-SIVPF. */
            _.Move("PRPSASSE", ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SIGLA_ARQUIVO);

            /*" -3207- MOVE 4 TO ARQSIVPF-SISTEMA-ORIGEM OF DCLARQUIVOS-SIVPF. */
            _.Move(4, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SISTEMA_ORIGEM);

            /*" -3211- MOVE SISTEMAS-DATA-MOV-ABERTO OF DCLSISTEMAS TO ARQSIVPF-DATA-GERACAO OF DCLARQUIVOS-SIVPF, ARQSIVPF-DATA-PROCESSAMENTO OF DCLARQUIVOS-SIVPF. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_GERACAO, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_PROCESSAMENTO);

            /*" -3214- MOVE RT-QTDE-TIPO-3 OF REG-TRAILLER TO ARQSIVPF-QTDE-REG-GER OF DCLARQUIVOS-SIVPF. */
            _.Move(LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_3, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_QTDE_REG_GER);

            /*" -3222- PERFORM R1050_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1 */

            R1050_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1();

            /*" -3225- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -3226- DISPLAY 'PF0612B - FIM ANORMAL' */
                _.Display($"PF0612B - FIM ANORMAL");

                /*" -3227- DISPLAY '          ERRO INSERT TABELA ARQUIVOS-SIVPF' */
                _.Display($"          ERRO INSERT TABELA ARQUIVOS-SIVPF");

                /*" -3229- DISPLAY '          SIGLA DO ARQIVO..................  ' ARQSIVPF-SIGLA-ARQUIVO OF DCLARQUIVOS-SIVPF */
                _.Display($"          SIGLA DO ARQIVO..................  {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SIGLA_ARQUIVO}");

                /*" -3231- DISPLAY '          NSAS SIVPF.......................  ' ARQSIVPF-NSAS-SIVPF OF DCLARQUIVOS-SIVPF */
                _.Display($"          NSAS SIVPF.......................  {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF}");

                /*" -3233- DISPLAY '          DATA GERACAO.....................  ' ARQSIVPF-DATA-GERACAO OF DCLARQUIVOS-SIVPF */
                _.Display($"          DATA GERACAO.....................  {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_GERACAO}");

                /*" -3235- DISPLAY '          QTDE. REGISTROS..................  ' ARQSIVPF-QTDE-REG-GER OF DCLARQUIVOS-SIVPF */
                _.Display($"          QTDE. REGISTROS..................  {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_QTDE_REG_GER}");

                /*" -3237- DISPLAY '          SQLCODE..........................  ' SQLCODE */
                _.Display($"          SQLCODE..........................  {DB.SQLCODE}");

                /*" -3238- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -3238- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R1050-00-CONTROLAR-ARQ-ENVIADO-DB-INSERT-1 */
        public void R1050_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1()
        {
            /*" -3222- EXEC SQL INSERT INTO SEGUROS.ARQUIVOS_SIVPF VALUES (:DCLARQUIVOS-SIVPF.ARQSIVPF-SIGLA-ARQUIVO, :DCLARQUIVOS-SIVPF.ARQSIVPF-SISTEMA-ORIGEM, :DCLARQUIVOS-SIVPF.ARQSIVPF-NSAS-SIVPF, :DCLARQUIVOS-SIVPF.ARQSIVPF-DATA-GERACAO, :DCLARQUIVOS-SIVPF.ARQSIVPF-QTDE-REG-GER, :DCLARQUIVOS-SIVPF.ARQSIVPF-DATA-PROCESSAMENTO) END-EXEC. */

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
            /*" -3249- MOVE 'R1100-00-GERAR-TOTIAS' TO PARAGRAFO. */
            _.Move("R1100-00-GERAR-TOTIAS", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3251- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3271- COMPUTE W-TOT-GERADO-PRP = W-QTD-LD-TIPO-1 + W-QTD-LD-TIPO-2 + W-QTD-LD-TIPO-3 + W-QTD-LD-TIPO-4 + W-QTD-LD-TIPO-5 + W-QTD-LD-TIPO-6 + W-QTD-LD-TIPO-7 + W-QTD-LD-TIPO-8 + W-QTD-LD-TIPO-9 + W-QTD-LD-TIPO-A + W-QTD-LD-TIPO-B + W-QTD-LD-TIPO-C + W-QTD-LD-TIPO-D + W-QTD-LD-TIPO-E + W-QTD-LD-TIPO-F + W-QTD-LD-TIPO-G + W-QTD-LD-TIPO-H + W-QTD-LD-TIPO-I + W-QTD-LD-TIPO-J. */
            WAREA_AUXILIAR.W_TOT_GERADO_PRP.Value = WAREA_AUXILIAR.W_QTD_LD_TIPO_1 + WAREA_AUXILIAR.W_QTD_LD_TIPO_2 + WAREA_AUXILIAR.W_QTD_LD_TIPO_3 + WAREA_AUXILIAR.W_QTD_LD_TIPO_4 + WAREA_AUXILIAR.W_QTD_LD_TIPO_5 + WAREA_AUXILIAR.W_QTD_LD_TIPO_6 + WAREA_AUXILIAR.W_QTD_LD_TIPO_7 + WAREA_AUXILIAR.W_QTD_LD_TIPO_8 + WAREA_AUXILIAR.W_QTD_LD_TIPO_9 + WAREA_AUXILIAR.W_QTD_LD_TIPO_A + WAREA_AUXILIAR.W_QTD_LD_TIPO_B + WAREA_AUXILIAR.W_QTD_LD_TIPO_C + WAREA_AUXILIAR.W_QTD_LD_TIPO_D + WAREA_AUXILIAR.W_QTD_LD_TIPO_E + WAREA_AUXILIAR.W_QTD_LD_TIPO_F + WAREA_AUXILIAR.W_QTD_LD_TIPO_G + WAREA_AUXILIAR.W_QTD_LD_TIPO_H + WAREA_AUXILIAR.W_QTD_LD_TIPO_I + WAREA_AUXILIAR.W_QTD_LD_TIPO_J;

            /*" -3272- DISPLAY ' ' . */
            _.Display($" ");

            /*" -3273- DISPLAY 'PF0612B - TOTAIS DO PROCESSAMENTO' . */
            _.Display($"PF0612B - TOTAIS DO PROCESSAMENTO");

            /*" -3275- DISPLAY '          TOTAL  REGISTROS LIDOS...........   ' W-NSL. */
            _.Display($"          TOTAL  REGISTROS LIDOS...........   {WAREA_AUXILIAR.W_NSL}");

            /*" -3277- DISPLAY '          TOTAL  PROCESSADO................ ' W-QTD-LD-TIPO-1. */
            _.Display($"          TOTAL  PROCESSADO................ {WAREA_AUXILIAR.W_QTD_LD_TIPO_1}");

            /*" -3279- DISPLAY '          TOTAL  NAO PROCESSADO............ ' W-DESPREZADO. */
            _.Display($"          TOTAL  NAO PROCESSADO............ {WAREA_AUXILIAR.W_DESPREZADO}");

            /*" -3280- DISPLAY ' ' . */
            _.Display($" ");

            /*" -3281- DISPLAY '          TOTAL  REGISTROS GERADOS PRPSASSE' . */
            _.Display($"          TOTAL  REGISTROS GERADOS PRPSASSE");

            /*" -3283- DISPLAY '          TOTAL  REGISTROS TP-1............ ' W-QTD-LD-TIPO-1. */
            _.Display($"          TOTAL  REGISTROS TP-1............ {WAREA_AUXILIAR.W_QTD_LD_TIPO_1}");

            /*" -3285- DISPLAY '          TOTAL  REGISTROS TP-2............ ' W-QTD-LD-TIPO-2. */
            _.Display($"          TOTAL  REGISTROS TP-2............ {WAREA_AUXILIAR.W_QTD_LD_TIPO_2}");

            /*" -3287- DISPLAY '          TOTAL  REGISTROS TP-3............ ' W-QTD-LD-TIPO-3. */
            _.Display($"          TOTAL  REGISTROS TP-3............ {WAREA_AUXILIAR.W_QTD_LD_TIPO_3}");

            /*" -3289- DISPLAY '          TOTAL  REGISTROS TP-4............ ' W-QTD-LD-TIPO-4. */
            _.Display($"          TOTAL  REGISTROS TP-4............ {WAREA_AUXILIAR.W_QTD_LD_TIPO_4}");

            /*" -3290- DISPLAY '          TOTAL  GERAL..................... ' W-TOT-GERADO-PRP. */
            _.Display($"          TOTAL  GERAL..................... {WAREA_AUXILIAR.W_TOT_GERADO_PRP}");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_SAIDA*/

        [StopWatch]
        /*" R1110-00-UPDATE-RELATORIOS-SECTION */
        private void R1110_00_UPDATE_RELATORIOS_SECTION()
        {
            /*" -3299- MOVE 'R1110-00-UPDATE-RELATORIOS' TO PARAGRAFO. */
            _.Move("R1110-00-UPDATE-RELATORIOS", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3301- MOVE 'UPDATE RELATORIOS' TO COMANDO. */
            _.Move("UPDATE RELATORIOS", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3308- PERFORM R1110_00_UPDATE_RELATORIOS_DB_UPDATE_1 */

            R1110_00_UPDATE_RELATORIOS_DB_UPDATE_1();

            /*" -3311- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -3312- DISPLAY 'PF0612B - FIM ANORMAL' */
                _.Display($"PF0612B - FIM ANORMAL");

                /*" -3313- DISPLAY '          ERRO UPDATE RELATORIOS' */
                _.Display($"          ERRO UPDATE RELATORIOS");

                /*" -3315- DISPLAY '          SQLCODE........................ ' SQLCODE */
                _.Display($"          SQLCODE........................ {DB.SQLCODE}");

                /*" -3316- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -3316- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R1110-00-UPDATE-RELATORIOS-DB-UPDATE-1 */
        public void R1110_00_UPDATE_RELATORIOS_DB_UPDATE_1()
        {
            /*" -3308- EXEC SQL UPDATE SEGUROS.RELATORIOS SET DATA_REFERENCIA = :DCLRELATORIOS.RELATORI-DATA-REFERENCIA, TIMESTAMP = CURRENT TIMESTAMP WHERE IDE_SISTEMA = 'PF' AND COD_RELATORIO = 'PF0612B' END-EXEC. */

            var r1110_00_UPDATE_RELATORIOS_DB_UPDATE_1_Update1 = new R1110_00_UPDATE_RELATORIOS_DB_UPDATE_1_Update1()
            {
                RELATORI_DATA_REFERENCIA = RELATORI.DCLRELATORIOS.RELATORI_DATA_REFERENCIA.ToString(),
            };

            R1110_00_UPDATE_RELATORIOS_DB_UPDATE_1_Update1.Execute(r1110_00_UPDATE_RELATORIOS_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1110_SAIDA*/

        [StopWatch]
        /*" R3000-GERAR-TB-CORPORATIVAS-SECTION */
        private void R3000_GERAR_TB_CORPORATIVAS_SECTION()
        {
            /*" -3326- PERFORM R3100-TRATA-CLIENTE. */

            R3100_TRATA_CLIENTE_SECTION();

            /*" -3327- IF EXISTE-CLIENTE */

            if (WAREA_AUXILIAR.W_LER_CLIENTE["EXISTE_CLIENTE"])
            {

                /*" -3328- PERFORM R3200-TRATA-END-TEL */

                R3200_TRATA_END_TEL_SECTION();

                /*" -3328- PERFORM R3300-TRATA-PROPOSTA. */

                R3300_TRATA_PROPOSTA_SECTION();
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_SAIDA*/

        [StopWatch]
        /*" R3100-TRATA-CLIENTE-SECTION */
        private void R3100_TRATA_CLIENTE_SECTION()
        {
            /*" -3338- MOVE 'R3100-TRATA-CLIENTE' TO PARAGRAFO. */
            _.Move("R3100-TRATA-CLIENTE", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3348- MOVE '    ' TO COMANDO. */
            _.Move("    ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3349- IF R1-TIPO-PESSOA OF REG-CLIENTES EQUAL 1 */

            if (LBFPF011.REG_CLIENTES.R1_TIPO_PESSOA == 1)
            {

                /*" -3350- PERFORM R3105-LER-PESSOA-FISICA */

                R3105_LER_PESSOA_FISICA_SECTION();

                /*" -3352- IF EXISTE-CLIENTE NEXT SENTENCE */

                if (WAREA_AUXILIAR.W_LER_CLIENTE["EXISTE_CLIENTE"])
                {

                    /*" -3353- ELSE */
                }
                else
                {


                    /*" -3354- GO TO R3100-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R3100_SAIDA*/ //GOTO
                    return;

                    /*" -3355- ELSE */
                }

            }
            else
            {


                /*" -3357- PERFORM R3110-LER-PESSOA-JURIDICA. */

                R3110_LER_PESSOA_JURIDICA_SECTION();
            }


            /*" -3358- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -3359- PERFORM R3115-INCLUIR-TAB-CORPORATIVAS */

                R3115_INCLUIR_TAB_CORPORATIVAS_SECTION();

                /*" -3360- ELSE */
            }
            else
            {


                /*" -3361- IF SQLCODE EQUAL 00 */

                if (DB.SQLCODE == 00)
                {

                    /*" -3364- PERFORM R3150-LER-TAB-CORPORATIVAS */

                    R3150_LER_TAB_CORPORATIVAS_SECTION();

                    /*" -3364- PERFORM R3135-INCLUIR-END-EMAIL. */

                    R3135_INCLUIR_END_EMAIL_SECTION();
                }

            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3100_SAIDA*/

        [StopWatch]
        /*" R3105-LER-PESSOA-FISICA-SECTION */
        private void R3105_LER_PESSOA_FISICA_SECTION()
        {
            /*" -3374- MOVE 'R3105-LER-PESSOA-FISICA' TO PARAGRAFO. */
            _.Move("R3105-LER-PESSOA-FISICA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3376- MOVE 'SELECT PESSOA_FISICA' TO COMANDO. */
            _.Move("SELECT PESSOA_FISICA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3379- MOVE R1-CGC-CPF OF REG-CLIENTES TO CPF OF DCLPESSOA-FISICA. */
            _.Move(LBFPF011.REG_CLIENTES.R1_CGC_CPF, PESFIS.DCLPESSOA_FISICA.CPF);

            /*" -3381- MOVE R1-DATA-NASCIMENTO OF REG-CLIENTES TO W-DATA-NASCIMENTO. */
            _.Move(LBFPF011.REG_CLIENTES.R1_DATA_NASCIMENTO, WAREA_AUXILIAR.W_DATA_NASCIMENTO);

            /*" -3383- MOVE W-DIA-NASCIMENTO TO W-DIA-SQL OF W-DATA-SQL1. */
            _.Move(WAREA_AUXILIAR.FILLER_3.W_DIA_NASCIMENTO, WAREA_AUXILIAR.W_DATA_SQL1.W_DIA_SQL);

            /*" -3385- MOVE W-MES-NASCIMENTO TO W-MES-SQL OF W-DATA-SQL1. */
            _.Move(WAREA_AUXILIAR.FILLER_3.W_MES_NASCIMENTO, WAREA_AUXILIAR.W_DATA_SQL1.W_MES_SQL);

            /*" -3388- MOVE W-ANO-NASCIMENTO TO W-ANO-SQL OF W-DATA-SQL1. */
            _.Move(WAREA_AUXILIAR.FILLER_3.W_ANO_NASCIMENTO, WAREA_AUXILIAR.W_DATA_SQL1.W_ANO_SQL);

            /*" -3392- MOVE '-' TO W-BARRA1 OF W-DATA-SQL1, W-BARRA2 OF W-DATA-SQL1. */
            _.Move("-", WAREA_AUXILIAR.W_DATA_SQL1.W_BARRA1_1);
            _.Move("-", WAREA_AUXILIAR.W_DATA_SQL1.W_BARRA2_1);


            /*" -3395- MOVE W-DATA-SQL TO DATA-NASCIMENTO OF DCLPESSOA-FISICA. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL, PESFIS.DCLPESSOA_FISICA.DATA_NASCIMENTO);

            /*" -3396- IF R1-IDE-SEXO OF REG-CLIENTES EQUAL 1 */

            if (LBFPF011.REG_CLIENTES.R1_IDE_SEXO == 1)
            {

                /*" -3398- MOVE 'M' TO SEXO OF DCLPESSOA-FISICA */
                _.Move("M", PESFIS.DCLPESSOA_FISICA.SEXO);

                /*" -3399- ELSE */
            }
            else
            {


                /*" -3402- MOVE 'F' TO SEXO OF DCLPESSOA-FISICA. */
                _.Move("F", PESFIS.DCLPESSOA_FISICA.SEXO);
            }


            /*" -3434- PERFORM R3105_LER_PESSOA_FISICA_DB_SELECT_1 */

            R3105_LER_PESSOA_FISICA_DB_SELECT_1();

            /*" -3438- MOVE 1 TO W-LER-CLIENTE. */
            _.Move(1, WAREA_AUXILIAR.W_LER_CLIENTE);

            /*" -3439- IF SQLCODE NOT EQUAL 00 AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -3440- IF SQLCODE EQUAL -305 OR -180 OR -181 */

                if (DB.SQLCODE.In("-305", "-180", "-181"))
                {

                    /*" -3441- MOVE 0 TO W-LER-CLIENTE */
                    _.Move(0, WAREA_AUXILIAR.W_LER_CLIENTE);

                    /*" -3442- DISPLAY 'PF0612B - DATO INVALIDO PESSOA-FISICA  ' */
                    _.Display($"PF0612B - DATO INVALIDO PESSOA-FISICA  ");

                    /*" -3444- DISPLAY '          NUMERO DA PROPOSTA............  ' R1-NUM-PROPOSTA OF REG-CLIENTES */
                    _.Display($"          NUMERO DA PROPOSTA............  {LBFPF011.REG_CLIENTES.R1_NUM_PROPOSTA}");

                    /*" -3446- DISPLAY '          DATA NASCIMENTO...............  ' DATA-NASCIMENTO OF DCLPESSOA-FISICA */
                    _.Display($"          DATA NASCIMENTO...............  {PESFIS.DCLPESSOA_FISICA.DATA_NASCIMENTO}");

                    /*" -3448- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                    _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                    /*" -3449- ELSE */
                }
                else
                {


                    /*" -3450- DISPLAY 'PF0612B - FIM ANORMAL' */
                    _.Display($"PF0612B - FIM ANORMAL");

                    /*" -3451- DISPLAY '          ERRO NO ACESSO A PESSOA-FISICA  ' */
                    _.Display($"          ERRO NO ACESSO A PESSOA-FISICA  ");

                    /*" -3453- DISPLAY '          NUMERO DA PROPOSTA............  ' R1-NUM-PROPOSTA OF REG-CLIENTES */
                    _.Display($"          NUMERO DA PROPOSTA............  {LBFPF011.REG_CLIENTES.R1_NUM_PROPOSTA}");

                    /*" -3455- DISPLAY '          CPF...........................  ' CPF OF DCLPESSOA-FISICA */
                    _.Display($"          CPF...........................  {PESFIS.DCLPESSOA_FISICA.CPF}");

                    /*" -3457- DISPLAY '          DATA NASCIMENTO...............  ' DATA-NASCIMENTO OF DCLPESSOA-FISICA */
                    _.Display($"          DATA NASCIMENTO...............  {PESFIS.DCLPESSOA_FISICA.DATA_NASCIMENTO}");

                    /*" -3459- DISPLAY '          SEXO..........................  ' SEXO OF DCLPESSOA-FISICA */
                    _.Display($"          SEXO..........................  {PESFIS.DCLPESSOA_FISICA.SEXO}");

                    /*" -3461- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                    _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                    /*" -3462- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -3462- PERFORM R9999-00-FINALIZAR. */

                    R9999_00_FINALIZAR_SECTION();
                }

            }


        }

        [StopWatch]
        /*" R3105-LER-PESSOA-FISICA-DB-SELECT-1 */
        public void R3105_LER_PESSOA_FISICA_DB_SELECT_1()
        {
            /*" -3434- EXEC SQL SELECT COD_PESSOA, CPF, DATA_NASCIMENTO, SEXO, TIPO_IDENT_SIVPF, NUM_IDENTIDADE, ORGAO_EXPEDIDOR, UF_EXPEDIDORA, DATA_EXPEDICAO, COD_CBO, COD_USUARIO, ESTADO_CIVIL, TIMESTAMP INTO :DCLPESSOA-FISICA.COD-PESSOA:VIND-COD-PESSOA, :DCLPESSOA-FISICA.CPF:VIND-CPF, :DCLPESSOA-FISICA.DATA-NASCIMENTO:VIND-DTNASCI, :DCLPESSOA-FISICA.SEXO:VIND-SEXO, :DCLPESSOA-FISICA.TIPO-IDENT-SIVPF:VIND-TP-IDENT, :DCLPESSOA-FISICA.NUM-IDENTIDADE:VIND-NUM-IDENT, :DCLPESSOA-FISICA.ORGAO-EXPEDIDOR:VIND-ORGAO-EXP, :DCLPESSOA-FISICA.UF-EXPEDIDORA:VIND-UF-EXP, :DCLPESSOA-FISICA.DATA-EXPEDICAO:VIND-DTEXPEDI, :DCLPESSOA-FISICA.COD-CBO:VIND-COD-CBO, :DCLPESSOA-FISICA.COD-USUARIO:VIND-COD-USUR, :DCLPESSOA-FISICA.ESTADO-CIVIL, :DCLPESSOA-FISICA.TIMESTAMP:VIND-TIMESTAMP FROM SEGUROS.PESSOA_FISICA WHERE CPF = :DCLPESSOA-FISICA.CPF AND DATA_NASCIMENTO = :DCLPESSOA-FISICA.DATA-NASCIMENTO AND SEXO = :DCLPESSOA-FISICA.SEXO WITH UR END-EXEC. */

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
            /*" -3472- MOVE 'R3110-LER-PESSOA-JURIDICA' TO PARAGRAFO. */
            _.Move("R3110-LER-PESSOA-JURIDICA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3474- MOVE 'SELECT' TO COMANDO. */
            _.Move("SELECT", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3477- MOVE R1-CGC-CPF OF REG-CLIENTES TO CGC OF DCLPESSOA-JURIDICA. */
            _.Move(LBFPF011.REG_CLIENTES.R1_CGC_CPF, PESJUR.DCLPESSOA_JURIDICA.CGC);

            /*" -3491- PERFORM R3110_LER_PESSOA_JURIDICA_DB_SELECT_1 */

            R3110_LER_PESSOA_JURIDICA_DB_SELECT_1();

            /*" -3494- IF SQLCODE NOT EQUAL 00 AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -3495- DISPLAY 'PF0612B - FIM ANORMAL' */
                _.Display($"PF0612B - FIM ANORMAL");

                /*" -3496- DISPLAY '          ERRO NO ACESSO A PESSOA-JURIDICA' */
                _.Display($"          ERRO NO ACESSO A PESSOA-JURIDICA");

                /*" -3498- DISPLAY '          NUMERO DA PROPOSTA............  ' R1-NUM-PROPOSTA OF REG-CLIENTES */
                _.Display($"          NUMERO DA PROPOSTA............  {LBFPF011.REG_CLIENTES.R1_NUM_PROPOSTA}");

                /*" -3500- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -3501- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -3501- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R3110-LER-PESSOA-JURIDICA-DB-SELECT-1 */
        public void R3110_LER_PESSOA_JURIDICA_DB_SELECT_1()
        {
            /*" -3491- EXEC SQL SELECT COD_PESSOA, CGC, NOME_FANTASIA, COD_USUARIO, TIMESTAMP INTO :DCLPESSOA-JURIDICA.COD-PESSOA, :DCLPESSOA-JURIDICA.CGC, :DCLPESSOA-JURIDICA.NOME-FANTASIA, :DCLPESSOA-JURIDICA.COD-USUARIO, :DCLPESSOA-JURIDICA.TIMESTAMP FROM SEGUROS.PESSOA_JURIDICA WHERE CGC = :DCLPESSOA-JURIDICA.CGC WITH UR END-EXEC. */

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
            /*" -3510- MOVE 'R3115-INCLUIR-TAB-CORPORATIVAS' TO PARAGRAFO. */
            _.Move("R3115-INCLUIR-TAB-CORPORATIVAS", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3512- MOVE '      ' TO COMANDO. */
            _.Move("      ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3514- PERFORM R3120-INCLUIR-TAB-PESSOA. */

            R3120_INCLUIR_TAB_PESSOA_SECTION();

            /*" -3515- IF R1-TIPO-PESSOA OF REG-CLIENTES EQUAL 1 */

            if (LBFPF011.REG_CLIENTES.R1_TIPO_PESSOA == 1)
            {

                /*" -3516- PERFORM R3125-INCLUIR-PESSOA-FISICA */

                R3125_INCLUIR_PESSOA_FISICA_SECTION();

                /*" -3517- ELSE */
            }
            else
            {


                /*" -3519- PERFORM R3130-INCLUIR-PESSOA-JURIDICA. */

                R3130_INCLUIR_PESSOA_JURIDICA_SECTION();
            }


            /*" -3519- PERFORM R3135-INCLUIR-END-EMAIL. */

            R3135_INCLUIR_END_EMAIL_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3115_SAIDA*/

        [StopWatch]
        /*" R3120-INCLUIR-TAB-PESSOA-SECTION */
        private void R3120_INCLUIR_TAB_PESSOA_SECTION()
        {
            /*" -3529- MOVE 'R3120-INCLUIR-TAB-PESSOA' TO PARAGRAFO. */
            _.Move("R3120-INCLUIR-TAB-PESSOA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3531- MOVE '      ' TO COMANDO. */
            _.Move("      ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3532- IF W-OBTER-MAX-PESSOA EQUAL 'NAO' */

            if (WAREA_AUXILIAR.W_OBTER_MAX_PESSOA == "NAO")
            {

                /*" -3533- MOVE 'SIM' TO W-OBTER-MAX-PESSOA */
                _.Move("SIM", WAREA_AUXILIAR.W_OBTER_MAX_PESSOA);

                /*" -3535- PERFORM R3121-OBTER-MAX-COD-PESSOA. */

                R3121_OBTER_MAX_COD_PESSOA_SECTION();
            }


            /*" -3538- COMPUTE W-COD-PESSOA = W-COD-PESSOA + 1 */
            WAREA_AUXILIAR.W_COD_PESSOA.Value = WAREA_AUXILIAR.W_COD_PESSOA + 1;

            /*" -3541- MOVE W-COD-PESSOA TO PESSOA-COD-PESSOA OF DCLPESSOA. */
            _.Move(WAREA_AUXILIAR.W_COD_PESSOA, PESSOA.DCLPESSOA.PESSOA_COD_PESSOA);

            /*" -3544- MOVE R1-NOME-PESSOA OF REG-CLIENTES TO PESSOA-NOME-PESSOA OF DCLPESSOA. */
            _.Move(LBFPF011.REG_CLIENTES.R1_NOME_PESSOA, PESSOA.DCLPESSOA.PESSOA_NOME_PESSOA);

            /*" -3547- MOVE ' ' TO PESSOA-TIPO-PESSOA OF DCLPESSOA. */
            _.Move(" ", PESSOA.DCLPESSOA.PESSOA_TIPO_PESSOA);

            /*" -3548- IF R1-TIPO-PESSOA OF REG-CLIENTES EQUAL 1 */

            if (LBFPF011.REG_CLIENTES.R1_TIPO_PESSOA == 1)
            {

                /*" -3550- MOVE 'F' TO PESSOA-TIPO-PESSOA OF DCLPESSOA */
                _.Move("F", PESSOA.DCLPESSOA.PESSOA_TIPO_PESSOA);

                /*" -3551- ELSE */
            }
            else
            {


                /*" -3552- IF R1-TIPO-PESSOA OF REG-CLIENTES EQUAL 2 */

                if (LBFPF011.REG_CLIENTES.R1_TIPO_PESSOA == 2)
                {

                    /*" -3555- MOVE 'J' TO PESSOA-TIPO-PESSOA OF DCLPESSOA. */
                    _.Move("J", PESSOA.DCLPESSOA.PESSOA_TIPO_PESSOA);
                }

            }


            /*" -3558- MOVE 'PF0612B' TO PESSOA-COD-USUARIO OF DCLPESSOA. */
            _.Move("PF0612B", PESSOA.DCLPESSOA.PESSOA_COD_USUARIO);

            /*" -3566- PERFORM R3120_INCLUIR_TAB_PESSOA_DB_INSERT_1 */

            R3120_INCLUIR_TAB_PESSOA_DB_INSERT_1();

            /*" -3569- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -3570- DISPLAY 'PF0612B - FIM ANORMAL' */
                _.Display($"PF0612B - FIM ANORMAL");

                /*" -3571- DISPLAY '          ERRO INSERT DA TABELA PESSOA' */
                _.Display($"          ERRO INSERT DA TABELA PESSOA");

                /*" -3573- DISPLAY '          CODIGO PESSOA.................  ' PESSOA-COD-PESSOA OF DCLPESSOA */
                _.Display($"          CODIGO PESSOA.................  {PESSOA.DCLPESSOA.PESSOA_COD_PESSOA}");

                /*" -3575- DISPLAY '          NOME DA PESSOA................  ' PESSOA-NOME-PESSOA OF DCLPESSOA */
                _.Display($"          NOME DA PESSOA................  {PESSOA.DCLPESSOA.PESSOA_NOME_PESSOA}");

                /*" -3577- DISPLAY '          NUMERO PROPOSTA...............  ' R1-NUM-PROPOSTA OF REG-CLIENTES */
                _.Display($"          NUMERO PROPOSTA...............  {LBFPF011.REG_CLIENTES.R1_NUM_PROPOSTA}");

                /*" -3579- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -3580- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -3580- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R3120-INCLUIR-TAB-PESSOA-DB-INSERT-1 */
        public void R3120_INCLUIR_TAB_PESSOA_DB_INSERT_1()
        {
            /*" -3566- EXEC SQL INSERT INTO SEGUROS.PESSOA VALUES (:DCLPESSOA.PESSOA-COD-PESSOA, :DCLPESSOA.PESSOA-NOME-PESSOA, CURRENT TIMESTAMP, :DCLPESSOA.PESSOA-COD-USUARIO, :DCLPESSOA.PESSOA-TIPO-PESSOA, NULL) END-EXEC. */

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
            /*" -3590- MOVE 'R3121-OBTER-MAX-COD-PESSOA' TO PARAGRAFO. */
            _.Move("R3121-OBTER-MAX-COD-PESSOA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3592- MOVE 'MAX SEGUROS.PESSOA' TO COMANDO. */
            _.Move("MAX SEGUROS.PESSOA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3597- PERFORM R3121_OBTER_MAX_COD_PESSOA_DB_SELECT_1 */

            R3121_OBTER_MAX_COD_PESSOA_DB_SELECT_1();

            /*" -3600- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -3601- DISPLAY 'PF0612B - FIM ANORMAL' */
                _.Display($"PF0612B - FIM ANORMAL");

                /*" -3602- DISPLAY '          ERRO NO SELECT MAX TAB. PESSOA' */
                _.Display($"          ERRO NO SELECT MAX TAB. PESSOA");

                /*" -3604- DISPLAY '          NUMERO DA PROPOSTA............  ' R1-NUM-PROPOSTA OF REG-CLIENTES */
                _.Display($"          NUMERO DA PROPOSTA............  {LBFPF011.REG_CLIENTES.R1_NUM_PROPOSTA}");

                /*" -3606- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -3607- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -3609- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


            /*" -3610- MOVE PESSOA-COD-PESSOA OF DCLPESSOA TO W-COD-PESSOA. */
            _.Move(PESSOA.DCLPESSOA.PESSOA_COD_PESSOA, WAREA_AUXILIAR.W_COD_PESSOA);

        }

        [StopWatch]
        /*" R3121-OBTER-MAX-COD-PESSOA-DB-SELECT-1 */
        public void R3121_OBTER_MAX_COD_PESSOA_DB_SELECT_1()
        {
            /*" -3597- EXEC SQL SELECT VALUE(MAX(COD_PESSOA),0) INTO :DCLPESSOA.PESSOA-COD-PESSOA FROM SEGUROS.PESSOA WITH UR END-EXEC. */

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
            /*" -3620- MOVE 'R3125-INCLUIR-PESSOAS-FISICA' TO PARAGRAFO. */
            _.Move("R3125-INCLUIR-PESSOAS-FISICA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3622- MOVE 'INSERT PESSOA-FISICA' TO COMANDO. */
            _.Move("INSERT PESSOA-FISICA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3625- MOVE PESSOA-COD-PESSOA OF DCLPESSOA TO COD-PESSOA OF DCLPESSOA-FISICA. */
            _.Move(PESSOA.DCLPESSOA.PESSOA_COD_PESSOA, PESFIS.DCLPESSOA_FISICA.COD_PESSOA);

            /*" -3628- MOVE R1-CGC-CPF OF REG-CLIENTES TO CPF OF DCLPESSOA-FISICA. */
            _.Move(LBFPF011.REG_CLIENTES.R1_CGC_CPF, PESFIS.DCLPESSOA_FISICA.CPF);

            /*" -3630- MOVE R1-DATA-NASCIMENTO OF REG-CLIENTES TO W-DATA-NASCIMENTO. */
            _.Move(LBFPF011.REG_CLIENTES.R1_DATA_NASCIMENTO, WAREA_AUXILIAR.W_DATA_NASCIMENTO);

            /*" -3632- MOVE W-DIA-NASCIMENTO TO W-DIA-SQL OF W-DATA-SQL1. */
            _.Move(WAREA_AUXILIAR.FILLER_3.W_DIA_NASCIMENTO, WAREA_AUXILIAR.W_DATA_SQL1.W_DIA_SQL);

            /*" -3634- MOVE W-MES-NASCIMENTO TO W-MES-SQL OF W-DATA-SQL1. */
            _.Move(WAREA_AUXILIAR.FILLER_3.W_MES_NASCIMENTO, WAREA_AUXILIAR.W_DATA_SQL1.W_MES_SQL);

            /*" -3637- MOVE W-ANO-NASCIMENTO TO W-ANO-SQL OF W-DATA-SQL1. */
            _.Move(WAREA_AUXILIAR.FILLER_3.W_ANO_NASCIMENTO, WAREA_AUXILIAR.W_DATA_SQL1.W_ANO_SQL);

            /*" -3641- MOVE '-' TO W-BARRA1 OF W-DATA-SQL1, W-BARRA2 OF W-DATA-SQL1. */
            _.Move("-", WAREA_AUXILIAR.W_DATA_SQL1.W_BARRA1_1);
            _.Move("-", WAREA_AUXILIAR.W_DATA_SQL1.W_BARRA2_1);


            /*" -3644- MOVE W-DATA-SQL TO DATA-NASCIMENTO OF DCLPESSOA-FISICA. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL, PESFIS.DCLPESSOA_FISICA.DATA_NASCIMENTO);

            /*" -3645- IF R1-IDE-SEXO OF REG-CLIENTES EQUAL 1 */

            if (LBFPF011.REG_CLIENTES.R1_IDE_SEXO == 1)
            {

                /*" -3647- MOVE 'M' TO SEXO OF DCLPESSOA-FISICA */
                _.Move("M", PESFIS.DCLPESSOA_FISICA.SEXO);

                /*" -3648- ELSE */
            }
            else
            {


                /*" -3651- MOVE 'F' TO SEXO OF DCLPESSOA-FISICA. */
                _.Move("F", PESFIS.DCLPESSOA_FISICA.SEXO);
            }


            /*" -3654- MOVE SPACES TO TIPO-IDENT-SIVPF OF DCLPESSOA-FISICA. */
            _.Move("", PESFIS.DCLPESSOA_FISICA.TIPO_IDENT_SIVPF);

            /*" -3657- MOVE R1-NUM-IDENTIDADE OF REG-CLIENTES TO NUM-IDENTIDADE OF DCLPESSOA-FISICA. */
            _.Move(LBFPF011.REG_CLIENTES.R1_NUM_IDENTIDADE, PESFIS.DCLPESSOA_FISICA.NUM_IDENTIDADE);

            /*" -3660- MOVE R1-ORGAO-EXPEDIDOR OF REG-CLIENTES TO ORGAO-EXPEDIDOR OF DCLPESSOA-FISICA. */
            _.Move(LBFPF011.REG_CLIENTES.R1_ORGAO_EXPEDIDOR, PESFIS.DCLPESSOA_FISICA.ORGAO_EXPEDIDOR);

            /*" -3663- MOVE R1-UF-EXPEDIDORA OF REG-CLIENTES TO UF-EXPEDIDORA OF DCLPESSOA-FISICA. */
            _.Move(LBFPF011.REG_CLIENTES.R1_UF_EXPEDIDORA, PESFIS.DCLPESSOA_FISICA.UF_EXPEDIDORA);

            /*" -3664- IF R1-ESTADO-CIVIL OF REG-CLIENTES EQUAL 1 */

            if (LBFPF011.REG_CLIENTES.R1_ESTADO_CIVIL == 1)
            {

                /*" -3666- MOVE 'S' TO ESTADO-CIVIL OF DCLPESSOA-FISICA */
                _.Move("S", PESFIS.DCLPESSOA_FISICA.ESTADO_CIVIL);

                /*" -3667- ELSE */
            }
            else
            {


                /*" -3668- IF R1-ESTADO-CIVIL OF REG-CLIENTES EQUAL 2 */

                if (LBFPF011.REG_CLIENTES.R1_ESTADO_CIVIL == 2)
                {

                    /*" -3670- MOVE 'C' TO ESTADO-CIVIL OF DCLPESSOA-FISICA */
                    _.Move("C", PESFIS.DCLPESSOA_FISICA.ESTADO_CIVIL);

                    /*" -3671- ELSE */
                }
                else
                {


                    /*" -3672- IF R1-ESTADO-CIVIL OF REG-CLIENTES EQUAL 3 */

                    if (LBFPF011.REG_CLIENTES.R1_ESTADO_CIVIL == 3)
                    {

                        /*" -3674- MOVE 'V' TO ESTADO-CIVIL OF DCLPESSOA-FISICA */
                        _.Move("V", PESFIS.DCLPESSOA_FISICA.ESTADO_CIVIL);

                        /*" -3675- ELSE */
                    }
                    else
                    {


                        /*" -3678- MOVE 'O' TO ESTADO-CIVIL OF DCLPESSOA-FISICA. */
                        _.Move("O", PESFIS.DCLPESSOA_FISICA.ESTADO_CIVIL);
                    }

                }

            }


            /*" -3679- IF R1-DATA-EXPEDICAO-RG OF REG-CLIENTES GREATER ZEROS */

            if (LBFPF011.REG_CLIENTES.R1_DATA_EXPEDICAO_RG > 00)
            {

                /*" -3682- MOVE R1-DATA-EXPEDICAO-RG OF REG-CLIENTES TO W-DATA-TRABALHO */
                _.Move(LBFPF011.REG_CLIENTES.R1_DATA_EXPEDICAO_RG, WAREA_AUXILIAR.W_DATA_TRABALHO);

                /*" -3684- MOVE W-DIA-TRABALHO TO W-DIA-SQL OF W-DATA-SQL1 */
                _.Move(WAREA_AUXILIAR.FILLER_2.W_DIA_TRABALHO, WAREA_AUXILIAR.W_DATA_SQL1.W_DIA_SQL);

                /*" -3686- MOVE W-MES-TRABALHO TO W-MES-SQL OF W-DATA-SQL1 */
                _.Move(WAREA_AUXILIAR.FILLER_2.W_MES_TRABALHO, WAREA_AUXILIAR.W_DATA_SQL1.W_MES_SQL);

                /*" -3689- MOVE W-ANO-TRABALHO TO W-ANO-SQL OF W-DATA-SQL1 */
                _.Move(WAREA_AUXILIAR.FILLER_2.W_ANO_TRABALHO, WAREA_AUXILIAR.W_DATA_SQL1.W_ANO_SQL);

                /*" -3693- MOVE '-' TO W-BARRA1 OF W-DATA-SQL1 W-BARRA2 OF W-DATA-SQL1 */
                _.Move("-", WAREA_AUXILIAR.W_DATA_SQL1.W_BARRA1_1);
                _.Move("-", WAREA_AUXILIAR.W_DATA_SQL1.W_BARRA2_1);


                /*" -3695- MOVE W-DATA-SQL TO DATA-EXPEDICAO OF DCLPESSOA-FISICA */
                _.Move(WAREA_AUXILIAR.W_DATA_SQL, PESFIS.DCLPESSOA_FISICA.DATA_EXPEDICAO);

                /*" -3696- ELSE */
            }
            else
            {


                /*" -3698- MOVE -1 TO VIND-DTEXPEDI. */
                _.Move(-1, VIND_DTEXPEDI);
            }


            /*" -3701- MOVE R1-COD-CBO OF REG-CLIENTES TO COD-CBO OF DCLPESSOA-FISICA. */
            _.Move(LBFPF011.REG_CLIENTES.R1_COD_CBO, PESFIS.DCLPESSOA_FISICA.COD_CBO);

            /*" -3704- MOVE 'PF0612B' TO COD-USUARIO OF DCLPESSOA-FISICA. */
            _.Move("PF0612B", PESFIS.DCLPESSOA_FISICA.COD_USUARIO);

            /*" -3719- PERFORM R3125_INCLUIR_PESSOA_FISICA_DB_INSERT_1 */

            R3125_INCLUIR_PESSOA_FISICA_DB_INSERT_1();

            /*" -3722- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -3723- DISPLAY 'PF0612B - FIM ANORMAL' */
                _.Display($"PF0612B - FIM ANORMAL");

                /*" -3724- DISPLAY '          ERRO INSERT DA TABELA PESSOA FISICA' */
                _.Display($"          ERRO INSERT DA TABELA PESSOA FISICA");

                /*" -3726- DISPLAY '          CODIGO PESSOA.................  ' COD-PESSOA OF DCLPESSOA-FISICA */
                _.Display($"          CODIGO PESSOA.................  {PESFIS.DCLPESSOA_FISICA.COD_PESSOA}");

                /*" -3728- DISPLAY '          NUMERO PROPOSTA...............  ' R1-NUM-PROPOSTA OF REG-CLIENTES */
                _.Display($"          NUMERO PROPOSTA...............  {LBFPF011.REG_CLIENTES.R1_NUM_PROPOSTA}");

                /*" -3730- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -3731- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -3731- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R3125-INCLUIR-PESSOA-FISICA-DB-INSERT-1 */
        public void R3125_INCLUIR_PESSOA_FISICA_DB_INSERT_1()
        {
            /*" -3719- EXEC SQL INSERT INTO SEGUROS.PESSOA_FISICA VALUES (:DCLPESSOA-FISICA.COD-PESSOA, :DCLPESSOA-FISICA.CPF, :DCLPESSOA-FISICA.DATA-NASCIMENTO, :DCLPESSOA-FISICA.SEXO, :DCLPESSOA-FISICA.COD-USUARIO, :DCLPESSOA-FISICA.ESTADO-CIVIL, CURRENT TIMESTAMP, :DCLPESSOA-FISICA.NUM-IDENTIDADE, :DCLPESSOA-FISICA.ORGAO-EXPEDIDOR, :DCLPESSOA-FISICA.UF-EXPEDIDORA, :DCLPESSOA-FISICA.DATA-EXPEDICAO:VIND-DTEXPEDI, :DCLPESSOA-FISICA.COD-CBO, :DCLPESSOA-FISICA.TIPO-IDENT-SIVPF) END-EXEC. */

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
        /*" R3130-INCLUIR-PESSOA-JURIDICA-SECTION */
        private void R3130_INCLUIR_PESSOA_JURIDICA_SECTION()
        {
            /*" -3740- MOVE 'R3130-INCLUIR-PESSOAS-JURIDICA' TO PARAGRAFO. */
            _.Move("R3130-INCLUIR-PESSOAS-JURIDICA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3742- MOVE 'INSERT PESSOA-JURIDICA' TO COMANDO. */
            _.Move("INSERT PESSOA-JURIDICA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3745- MOVE PESSOA-COD-PESSOA OF DCLPESSOA TO COD-PESSOA OF DCLPESSOA-JURIDICA */
            _.Move(PESSOA.DCLPESSOA.PESSOA_COD_PESSOA, PESJUR.DCLPESSOA_JURIDICA.COD_PESSOA);

            /*" -3748- MOVE R1-CGC-CPF OF REG-CLIENTES TO CGC OF DCLPESSOA-JURIDICA */
            _.Move(LBFPF011.REG_CLIENTES.R1_CGC_CPF, PESJUR.DCLPESSOA_JURIDICA.CGC);

            /*" -3751- MOVE R1-NOME-PESSOA OF REG-CLIENTES TO NOME-FANTASIA OF DCLPESSOA-JURIDICA */
            _.Move(LBFPF011.REG_CLIENTES.R1_NOME_PESSOA, PESJUR.DCLPESSOA_JURIDICA.NOME_FANTASIA);

            /*" -3754- MOVE 'PF0612B' TO COD-USUARIO OF DCLPESSOA-JURIDICA */
            _.Move("PF0612B", PESJUR.DCLPESSOA_JURIDICA.COD_USUARIO);

            /*" -3761- PERFORM R3130_INCLUIR_PESSOA_JURIDICA_DB_INSERT_1 */

            R3130_INCLUIR_PESSOA_JURIDICA_DB_INSERT_1();

            /*" -3764- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -3765- DISPLAY 'PF0612B - FIM ANORMAL' */
                _.Display($"PF0612B - FIM ANORMAL");

                /*" -3766- DISPLAY '          ERRO INSERT DA TABELA PESSOA JURIDICA' */
                _.Display($"          ERRO INSERT DA TABELA PESSOA JURIDICA");

                /*" -3768- DISPLAY '          CODIGO PESSOA.................  ' COD-PESSOA OF DCLPESSOA-JURIDICA */
                _.Display($"          CODIGO PESSOA.................  {PESJUR.DCLPESSOA_JURIDICA.COD_PESSOA}");

                /*" -3770- DISPLAY '          NUMERO PROPOSTA...............  ' R1-NUM-PROPOSTA OF REG-CLIENTES */
                _.Display($"          NUMERO PROPOSTA...............  {LBFPF011.REG_CLIENTES.R1_NUM_PROPOSTA}");

                /*" -3772- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -3773- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -3773- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R3130-INCLUIR-PESSOA-JURIDICA-DB-INSERT-1 */
        public void R3130_INCLUIR_PESSOA_JURIDICA_DB_INSERT_1()
        {
            /*" -3761- EXEC SQL INSERT INTO SEGUROS.PESSOA_JURIDICA VALUES (:DCLPESSOA-JURIDICA.COD-PESSOA, :DCLPESSOA-JURIDICA.CGC, :DCLPESSOA-JURIDICA.NOME-FANTASIA, :DCLPESSOA-JURIDICA.COD-USUARIO, CURRENT TIMESTAMP) END-EXEC. */

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
            /*" -3783- MOVE 'R3136-RELACIONA-EMAIL' TO PARAGRAFO. */
            _.Move("R3136-RELACIONA-EMAIL", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3785- MOVE 'DECLARE PESSOA-EMAIL' TO COMANDO. */
            _.Move("DECLARE PESSOA-EMAIL", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3788- MOVE PESSOA-COD-PESSOA OF DCLPESSOA TO COD-PESSOA OF DCLPESSOA-EMAIL. */
            _.Move(PESSOA.DCLPESSOA.PESSOA_COD_PESSOA, PESEMAIL.DCLPESSOA_EMAIL.COD_PESSOA);

            /*" -3798- PERFORM R3136_RELACIONA_EMAIL_DB_DECLARE_1 */

            R3136_RELACIONA_EMAIL_DB_DECLARE_1();

            /*" -3802- IF SQLCODE NOT EQUAL 00 AND SQLCODE NOT EQUAL 100 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != 100)
            {

                /*" -3803- DISPLAY 'PF0612B - FIM ANORMAL' */
                _.Display($"PF0612B - FIM ANORMAL");

                /*" -3804- DISPLAY '          ERRO DECLARE DA TABELA PESSOA EMAIL' */
                _.Display($"          ERRO DECLARE DA TABELA PESSOA EMAIL");

                /*" -3806- DISPLAY '          CODIGO PESSOA.................  ' COD-PESSOA OF DCLPESSOA-EMAIL */
                _.Display($"          CODIGO PESSOA.................  {PESEMAIL.DCLPESSOA_EMAIL.COD_PESSOA}");

                /*" -3808- DISPLAY '          NUMERO PROPOSTA...............  ' R1-NUM-PROPOSTA OF REG-CLIENTES */
                _.Display($"          NUMERO PROPOSTA...............  {LBFPF011.REG_CLIENTES.R1_NUM_PROPOSTA}");

                /*" -3810- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -3811- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -3811- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3136_SAIDA*/

        [StopWatch]
        /*" R3135-INCLUIR-END-EMAIL-SECTION */
        private void R3135_INCLUIR_END_EMAIL_SECTION()
        {
            /*" -3820- MOVE 'R3135-INCLUIR-END-EMAIL' TO PARAGRAFO. */
            _.Move("R3135-INCLUIR-END-EMAIL", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3822- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3824- PERFORM R3136-RELACIONA-EMAIL. */

            R3136_RELACIONA_EMAIL_SECTION();

            /*" -3826- MOVE 'OPEN CURSOR EMAIL' TO COMANDO. */
            _.Move("OPEN CURSOR EMAIL", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3826- PERFORM R3135_INCLUIR_END_EMAIL_DB_OPEN_1 */

            R3135_INCLUIR_END_EMAIL_DB_OPEN_1();

            /*" -3830- MOVE 'NAO' TO W-ACHOU-EMAIL. */
            _.Move("NAO", WAREA_AUXILIAR.W_ACHOU_EMAIL);

            /*" -3832- MOVE SPACES TO W-FIM-CURSOR-EMAIL. */
            _.Move("", WAREA_AUXILIAR.W_FIM_CURSOR_EMAIL);

            /*" -3834- PERFORM R3137-FETCH-EMAIL */

            R3137_FETCH_EMAIL_SECTION();

            /*" -3835- IF W-FIM-CURSOR-EMAIL EQUAL 'SIM' */

            if (WAREA_AUXILIAR.W_FIM_CURSOR_EMAIL == "SIM")
            {

                /*" -3836- IF R1-EMAIL OF REG-CLIENTES EQUAL SPACES */

                if (LBFPF011.REG_CLIENTES.R1_EMAIL.IsEmpty())
                {

                    /*" -3838- MOVE 'SIM' TO W-ACHOU-EMAIL. */
                    _.Move("SIM", WAREA_AUXILIAR.W_ACHOU_EMAIL);
                }

            }


            /*" -3841- PERFORM R3138-VERIFICA-EXISTE-EMAIL UNTIL W-FIM-CURSOR-EMAIL EQUAL 'SIM' . */

            while (!(WAREA_AUXILIAR.W_FIM_CURSOR_EMAIL == "SIM"))
            {

                R3138_VERIFICA_EXISTE_EMAIL_SECTION();
            }

            /*" -3842- IF W-ACHOU-EMAIL EQUAL 'NAO' */

            if (WAREA_AUXILIAR.W_ACHOU_EMAIL == "NAO")
            {

                /*" -3842- PERFORM R3139-INCLUIR-NOVO-EMAIL. */

                R3139_INCLUIR_NOVO_EMAIL_SECTION();
            }


        }

        [StopWatch]
        /*" R3135-INCLUIR-END-EMAIL-DB-OPEN-1 */
        public void R3135_INCLUIR_END_EMAIL_DB_OPEN_1()
        {
            /*" -3826- EXEC SQL OPEN EMAIL END-EXEC. */

            EMAIL.Open();

        }

        [StopWatch]
        /*" R3205-RELACIONA-ENDERECO-DB-DECLARE-1 */
        public void R3205_RELACIONA_ENDERECO_DB_DECLARE_1()
        {
            /*" -4191- EXEC SQL DECLARE ENDERECOS CURSOR FOR SELECT OCORR_ENDERECO, COD_PESSOA, ENDERECO, TIPO_ENDER, BAIRRO, CEP, CIDADE, SIGLA_UF, SITUACAO_ENDERECO FROM SEGUROS.PESSOA_ENDERECO WHERE COD_PESSOA = :DCLPESSOA-ENDERECO.COD-PESSOA ORDER BY OCORR_ENDERECO WITH UR END-EXEC. */
            ENDERECOS = new PF0612B_ENDERECOS(true);
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
            /*" -3852- MOVE 'R3137-FETCH-EMAIL' TO PARAGRAFO. */
            _.Move("R3137-FETCH-EMAIL", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3854- MOVE 'FETCH CURSOR EMAIL' TO COMANDO. */
            _.Move("FETCH CURSOR EMAIL", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3860- PERFORM R3137_FETCH_EMAIL_DB_FETCH_1 */

            R3137_FETCH_EMAIL_DB_FETCH_1();

            /*" -3863- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -3864- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -3865- MOVE 'SIM' TO W-FIM-CURSOR-EMAIL */
                    _.Move("SIM", WAREA_AUXILIAR.W_FIM_CURSOR_EMAIL);

                    /*" -3865- PERFORM R3137_FETCH_EMAIL_DB_CLOSE_1 */

                    R3137_FETCH_EMAIL_DB_CLOSE_1();

                    /*" -3867- ELSE */
                }
                else
                {


                    /*" -3868- DISPLAY 'PF0612B - FIM ANORMAL' */
                    _.Display($"PF0612B - FIM ANORMAL");

                    /*" -3869- DISPLAY '          ERRO FETCH CURSOR EMAIL' */
                    _.Display($"          ERRO FETCH CURSOR EMAIL");

                    /*" -3871- DISPLAY '          CODIGO PESSOA.................  ' COD-PESSOA OF DCLPESSOA-EMAIL */
                    _.Display($"          CODIGO PESSOA.................  {PESEMAIL.DCLPESSOA_EMAIL.COD_PESSOA}");

                    /*" -3873- DISPLAY '          NUMERO PROPOSTA...............  ' R1-NUM-PROPOSTA OF REG-CLIENTES */
                    _.Display($"          NUMERO PROPOSTA...............  {LBFPF011.REG_CLIENTES.R1_NUM_PROPOSTA}");

                    /*" -3875- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                    _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                    /*" -3876- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -3876- PERFORM R9999-00-FINALIZAR. */

                    R9999_00_FINALIZAR_SECTION();
                }

            }


        }

        [StopWatch]
        /*" R3137-FETCH-EMAIL-DB-FETCH-1 */
        public void R3137_FETCH_EMAIL_DB_FETCH_1()
        {
            /*" -3860- EXEC SQL FETCH EMAIL INTO :DCLPESSOA-EMAIL.COD-PESSOA, :DCLPESSOA-EMAIL.SEQ-EMAIL, :DCLPESSOA-EMAIL.EMAIL, :DCLPESSOA-EMAIL.SITUACAO-EMAIL END-EXEC. */

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
            /*" -3865- EXEC SQL CLOSE EMAIL END-EXEC */

            EMAIL.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3137_SAIDA*/

        [StopWatch]
        /*" R3138-VERIFICA-EXISTE-EMAIL-SECTION */
        private void R3138_VERIFICA_EXISTE_EMAIL_SECTION()
        {
            /*" -3886- MOVE 'R3138-VERIFICA-EXISTE-EMAIL' TO PARAGRAFO. */
            _.Move("R3138-VERIFICA-EXISTE-EMAIL", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3888- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3890- IF R1-EMAIL OF REG-CLIENTES EQUAL EMAIL OF DCLPESSOA-EMAIL */

            if (LBFPF011.REG_CLIENTES.R1_EMAIL == PESEMAIL.DCLPESSOA_EMAIL.EMAIL)
            {

                /*" -3892- MOVE 'SIM' TO W-ACHOU-EMAIL. */
                _.Move("SIM", WAREA_AUXILIAR.W_ACHOU_EMAIL);
            }


            /*" -3893- IF R1-EMAIL OF REG-CLIENTES EQUAL SPACES */

            if (LBFPF011.REG_CLIENTES.R1_EMAIL.IsEmpty())
            {

                /*" -3895- MOVE 'SIM' TO W-ACHOU-EMAIL. */
                _.Move("SIM", WAREA_AUXILIAR.W_ACHOU_EMAIL);
            }


            /*" -3895- PERFORM R3137-FETCH-EMAIL. */

            R3137_FETCH_EMAIL_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3138_SAIDA*/

        [StopWatch]
        /*" R3139-INCLUIR-NOVO-EMAIL-SECTION */
        private void R3139_INCLUIR_NOVO_EMAIL_SECTION()
        {
            /*" -3905- MOVE 'R3139-INCLUIR-NOVO-EMAIL' TO PARAGRAFO. */
            _.Move("R3139-INCLUIR-NOVO-EMAIL", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3914- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3917- MOVE SEQ-EMAIL OF DCLPESSOA-EMAIL TO W-SEQ-EMAIL */
            _.Move(PESEMAIL.DCLPESSOA_EMAIL.SEQ_EMAIL, WAREA_AUXILIAR.W_SEQ_EMAIL);

            /*" -3919- COMPUTE W-SEQ-EMAIL = W-SEQ-EMAIL + 1. */
            WAREA_AUXILIAR.W_SEQ_EMAIL.Value = WAREA_AUXILIAR.W_SEQ_EMAIL + 1;

            /*" -3919- PERFORM R3141-INCLUIR-EMAIL. */

            R3141_INCLUIR_EMAIL_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3139_SAIDA*/

        [StopWatch]
        /*" R3140-OBTER-MAX-EMAIL-SECTION */
        private void R3140_OBTER_MAX_EMAIL_SECTION()
        {
            /*" -3929- MOVE 'R3140-OBTER-MAX-EMAIL' TO PARAGRAFO. */
            _.Move("R3140-OBTER-MAX-EMAIL", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3931- MOVE 'MAX SEGUROS.PESSOA_EMAIL' TO COMANDO. */
            _.Move("MAX SEGUROS.PESSOA_EMAIL", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3934- MOVE PESSOA-COD-PESSOA OF DCLPESSOA TO COD-PESSOA OF DCLPESSOA-EMAIL. */
            _.Move(PESSOA.DCLPESSOA.PESSOA_COD_PESSOA, PESEMAIL.DCLPESSOA_EMAIL.COD_PESSOA);

            /*" -3940- PERFORM R3140_OBTER_MAX_EMAIL_DB_SELECT_1 */

            R3140_OBTER_MAX_EMAIL_DB_SELECT_1();

            /*" -3943- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -3944- DISPLAY 'PF0612B - FIM ANORMAL' */
                _.Display($"PF0612B - FIM ANORMAL");

                /*" -3945- DISPLAY '          ERRO NO SELECT MAX TAB. PESSOA-EMAIL' */
                _.Display($"          ERRO NO SELECT MAX TAB. PESSOA-EMAIL");

                /*" -3947- DISPLAY '          NUMERO DA PROPOSTA............  ' R1-NUM-PROPOSTA OF REG-CLIENTES */
                _.Display($"          NUMERO DA PROPOSTA............  {LBFPF011.REG_CLIENTES.R1_NUM_PROPOSTA}");

                /*" -3949- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -3950- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -3950- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R3140-OBTER-MAX-EMAIL-DB-SELECT-1 */
        public void R3140_OBTER_MAX_EMAIL_DB_SELECT_1()
        {
            /*" -3940- EXEC SQL SELECT VALUE(MAX(SEQ_EMAIL),0) INTO :DCLPESSOA-EMAIL.SEQ-EMAIL FROM SEGUROS.PESSOA_EMAIL WHERE COD_PESSOA = :DCLPESSOA-EMAIL.COD-PESSOA WITH UR END-EXEC. */

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
            /*" -3959- MOVE 'R3141-INCLUI-EMAIL' TO PARAGRAFO. */
            _.Move("R3141-INCLUI-EMAIL", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3961- MOVE 'MAX SEGUROS.PESSOA_EMAIL' TO COMANDO. */
            _.Move("MAX SEGUROS.PESSOA_EMAIL", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3964- MOVE PESSOA-COD-PESSOA OF DCLPESSOA TO COD-PESSOA OF DCLPESSOA-EMAIL */
            _.Move(PESSOA.DCLPESSOA.PESSOA_COD_PESSOA, PESEMAIL.DCLPESSOA_EMAIL.COD_PESSOA);

            /*" -3967- MOVE W-SEQ-EMAIL TO SEQ-EMAIL OF DCLPESSOA-EMAIL. */
            _.Move(WAREA_AUXILIAR.W_SEQ_EMAIL, PESEMAIL.DCLPESSOA_EMAIL.SEQ_EMAIL);

            /*" -3970- MOVE R1-EMAIL OF REG-CLIENTES TO EMAIL OF DCLPESSOA-EMAIL */
            _.Move(LBFPF011.REG_CLIENTES.R1_EMAIL, PESEMAIL.DCLPESSOA_EMAIL.EMAIL);

            /*" -3973- MOVE 'A' TO SITUACAO-EMAIL OF DCLPESSOA-EMAIL */
            _.Move("A", PESEMAIL.DCLPESSOA_EMAIL.SITUACAO_EMAIL);

            /*" -3977- MOVE 'PF0612B' TO COD-USUARIO OF DCLPESSOA-EMAIL. */
            _.Move("PF0612B", PESEMAIL.DCLPESSOA_EMAIL.COD_USUARIO);

            /*" -3985- PERFORM R3141_INCLUIR_EMAIL_DB_INSERT_1 */

            R3141_INCLUIR_EMAIL_DB_INSERT_1();

            /*" -3988- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -3989- DISPLAY 'PF0612B - FIM ANORMAL' */
                _.Display($"PF0612B - FIM ANORMAL");

                /*" -3990- DISPLAY '          ERRO INSERT DA TABELA PESSOA-EMAIL' */
                _.Display($"          ERRO INSERT DA TABELA PESSOA-EMAIL");

                /*" -3992- DISPLAY '          CODIGO PESSOA.................  ' PESSOA-COD-PESSOA OF DCLPESSOA */
                _.Display($"          CODIGO PESSOA.................  {PESSOA.DCLPESSOA.PESSOA_COD_PESSOA}");

                /*" -3994- DISPLAY '          NOME DA PESSOA................  ' PESSOA-NOME-PESSOA OF DCLPESSOA */
                _.Display($"          NOME DA PESSOA................  {PESSOA.DCLPESSOA.PESSOA_NOME_PESSOA}");

                /*" -3996- DISPLAY '          NUMERO PROPOSTA...............  ' R1-NUM-PROPOSTA OF REG-CLIENTES */
                _.Display($"          NUMERO PROPOSTA...............  {LBFPF011.REG_CLIENTES.R1_NUM_PROPOSTA}");

                /*" -3998- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -3999- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -3999- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R3141-INCLUIR-EMAIL-DB-INSERT-1 */
        public void R3141_INCLUIR_EMAIL_DB_INSERT_1()
        {
            /*" -3985- EXEC SQL INSERT INTO SEGUROS.PESSOA_EMAIL VALUES (:DCLPESSOA-EMAIL.COD-PESSOA, :DCLPESSOA-EMAIL.SEQ-EMAIL, :DCLPESSOA-EMAIL.EMAIL, :DCLPESSOA-EMAIL.SITUACAO-EMAIL, :DCLPESSOA-EMAIL.COD-USUARIO, CURRENT TIMESTAMP) END-EXEC. */

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
            /*" -4009- MOVE 'R3150-LER-TAB-CORPORATIVAS' TO PARAGRAFO. */
            _.Move("R3150-LER-TAB-CORPORATIVAS", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4011- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4012- IF R1-TIPO-PESSOA OF REG-CLIENTES EQUAL 1 */

            if (LBFPF011.REG_CLIENTES.R1_TIPO_PESSOA == 1)
            {

                /*" -4014- MOVE COD-PESSOA OF DCLPESSOA-FISICA TO PESSOA-COD-PESSOA OF DCLPESSOA */
                _.Move(PESFIS.DCLPESSOA_FISICA.COD_PESSOA, PESSOA.DCLPESSOA.PESSOA_COD_PESSOA);

                /*" -4015- ELSE */
            }
            else
            {


                /*" -4018- MOVE COD-PESSOA OF DCLPESSOA-JURIDICA TO PESSOA-COD-PESSOA OF DCLPESSOA. */
                _.Move(PESJUR.DCLPESSOA_JURIDICA.COD_PESSOA, PESSOA.DCLPESSOA.PESSOA_COD_PESSOA);
            }


            /*" -4020- PERFORM R3155-LER-TAB-PESSOA. */

            R3155_LER_TAB_PESSOA_SECTION();

            /*" -4020- PERFORM R3160-LER-TAB-EMAIL. */

            R3160_LER_TAB_EMAIL_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3150_SAIDA*/

        [StopWatch]
        /*" R3155-LER-TAB-PESSOA-SECTION */
        private void R3155_LER_TAB_PESSOA_SECTION()
        {
            /*" -4030- MOVE 'R3150-LER-TAB-PESSOAS' TO PARAGRAFO. */
            _.Move("R3150-LER-TAB-PESSOAS", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4032- MOVE 'SELECT SEGUROS.PESSOAS' TO COMANDO. */
            _.Move("SELECT SEGUROS.PESSOAS", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4046- PERFORM R3155_LER_TAB_PESSOA_DB_SELECT_1 */

            R3155_LER_TAB_PESSOA_DB_SELECT_1();

            /*" -4049- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -4050- DISPLAY 'PF0612B - FIM ANORMAL' */
                _.Display($"PF0612B - FIM ANORMAL");

                /*" -4051- DISPLAY '          ERRO ACESSO TAB. SEGUROS.PESSOA' */
                _.Display($"          ERRO ACESSO TAB. SEGUROS.PESSOA");

                /*" -4053- DISPLAY '          CODIGO PESSOA.................  ' PESSOA-COD-PESSOA OF DCLPESSOA */
                _.Display($"          CODIGO PESSOA.................  {PESSOA.DCLPESSOA.PESSOA_COD_PESSOA}");

                /*" -4055- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -4056- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -4056- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R3155-LER-TAB-PESSOA-DB-SELECT-1 */
        public void R3155_LER_TAB_PESSOA_DB_SELECT_1()
        {
            /*" -4046- EXEC SQL SELECT COD_PESSOA, NOME_PESSOA, TIPO_PESSOA, TIMESTAMP, COD_USUARIO INTO :DCLPESSOA.PESSOA-COD-PESSOA, :DCLPESSOA.PESSOA-NOME-PESSOA, :DCLPESSOA.PESSOA-TIPO-PESSOA, :DCLPESSOA.PESSOA-TIMESTAMP, :DCLPESSOA.PESSOA-COD-USUARIO FROM SEGUROS.PESSOA WHERE COD_PESSOA = :DCLPESSOA.PESSOA-COD-PESSOA WITH UR END-EXEC. */

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
        /*" R3160-LER-TAB-EMAIL-SECTION */
        private void R3160_LER_TAB_EMAIL_SECTION()
        {
            /*" -4065- MOVE 'R3160-LER-TAB-EMAIL' TO PARAGRAFO. */
            _.Move("R3160-LER-TAB-EMAIL", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4067- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4069- PERFORM R3165-OBTER-MAX-EMAIL. */

            R3165_OBTER_MAX_EMAIL_SECTION();

            /*" -4069- PERFORM R3170-LER-EMAIL-ATUAL. */

            R3170_LER_EMAIL_ATUAL_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3160_SAIDA*/

        [StopWatch]
        /*" R3165-OBTER-MAX-EMAIL-SECTION */
        private void R3165_OBTER_MAX_EMAIL_SECTION()
        {
            /*" -4079- MOVE 'R3165-OBTER-MAX-EMAIL' TO PARAGRAFO. */
            _.Move("R3165-OBTER-MAX-EMAIL", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4081- MOVE 'MAX SEGUROS.PESSOA_EMAIL' TO COMANDO. */
            _.Move("MAX SEGUROS.PESSOA_EMAIL", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4084- MOVE PESSOA-COD-PESSOA OF DCLPESSOA TO COD-PESSOA OF DCLPESSOA-EMAIL. */
            _.Move(PESSOA.DCLPESSOA.PESSOA_COD_PESSOA, PESEMAIL.DCLPESSOA_EMAIL.COD_PESSOA);

            /*" -4090- PERFORM R3165_OBTER_MAX_EMAIL_DB_SELECT_1 */

            R3165_OBTER_MAX_EMAIL_DB_SELECT_1();

            /*" -4093- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -4094- DISPLAY 'PF0612B - FIM ANORMAL' */
                _.Display($"PF0612B - FIM ANORMAL");

                /*" -4095- DISPLAY '          ERRO SELECT MAX TAB. PESSOA-EMAIL' */
                _.Display($"          ERRO SELECT MAX TAB. PESSOA-EMAIL");

                /*" -4097- DISPLAY '          CODIGO PESSOA.................  ' COD-PESSOA OF DCLPESSOA-EMAIL */
                _.Display($"          CODIGO PESSOA.................  {PESEMAIL.DCLPESSOA_EMAIL.COD_PESSOA}");

                /*" -4099- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -4100- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -4100- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R3165-OBTER-MAX-EMAIL-DB-SELECT-1 */
        public void R3165_OBTER_MAX_EMAIL_DB_SELECT_1()
        {
            /*" -4090- EXEC SQL SELECT VALUE(MAX(SEQ_EMAIL),0) INTO :DCLPESSOA-EMAIL.SEQ-EMAIL FROM SEGUROS.PESSOA_EMAIL WHERE COD_PESSOA = :DCLPESSOA-EMAIL.COD-PESSOA WITH UR END-EXEC. */

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
            /*" -4110- MOVE 'R3170-LER-EMAIL-ATUAL' TO PARAGRAFO. */
            _.Move("R3170-LER-EMAIL-ATUAL", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4112- MOVE 'SELECT SEGUROS.PESSOA_EMAIL' TO COMANDO. */
            _.Move("SELECT SEGUROS.PESSOA_EMAIL", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4115- MOVE PESSOA-COD-PESSOA OF DCLPESSOA TO COD-PESSOA OF DCLPESSOA-EMAIL. */
            _.Move(PESSOA.DCLPESSOA.PESSOA_COD_PESSOA, PESEMAIL.DCLPESSOA_EMAIL.COD_PESSOA);

            /*" -4132- PERFORM R3170_LER_EMAIL_ATUAL_DB_SELECT_1 */

            R3170_LER_EMAIL_ATUAL_DB_SELECT_1();

            /*" -4136- IF SQLCODE NOT EQUAL 00 AND SQLCODE NOT EQUAL 100 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != 100)
            {

                /*" -4137- DISPLAY 'PF0612B - FIM ANORMAL' */
                _.Display($"PF0612B - FIM ANORMAL");

                /*" -4138- DISPLAY '          ERRO SELECT TAB. PESSOA-EMAIL' */
                _.Display($"          ERRO SELECT TAB. PESSOA-EMAIL");

                /*" -4140- DISPLAY '          CODIGO PESSOA.................  ' COD-PESSOA OF DCLPESSOA-EMAIL */
                _.Display($"          CODIGO PESSOA.................  {PESEMAIL.DCLPESSOA_EMAIL.COD_PESSOA}");

                /*" -4142- DISPLAY '          SEQUENCIAEMAIL................  ' SEQ-EMAIL OF DCLPESSOA-EMAIL */
                _.Display($"          SEQUENCIAEMAIL................  {PESEMAIL.DCLPESSOA_EMAIL.SEQ_EMAIL}");

                /*" -4144- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -4145- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -4145- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R3170-LER-EMAIL-ATUAL-DB-SELECT-1 */
        public void R3170_LER_EMAIL_ATUAL_DB_SELECT_1()
        {
            /*" -4132- EXEC SQL SELECT COD_PESSOA, SEQ_EMAIL, EMAIL, SITUACAO_EMAIL, COD_USUARIO, TIMESTAMP INTO :DCLPESSOA-EMAIL.COD-PESSOA, :DCLPESSOA-EMAIL.SEQ-EMAIL, :DCLPESSOA-EMAIL.EMAIL, :DCLPESSOA-EMAIL.SITUACAO-EMAIL, :DCLPESSOA-EMAIL.COD-USUARIO, :DCLPESSOA-EMAIL.TIMESTAMP FROM SEGUROS.PESSOA_EMAIL WHERE COD_PESSOA = :DCLPESSOA-EMAIL.COD-PESSOA AND SEQ_EMAIL = :DCLPESSOA-EMAIL.SEQ-EMAIL WITH UR END-EXEC. */

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
            /*" -4155- MOVE 'R3200-TRATA-END-TEL' TO PARAGRAFO. */
            _.Move("R3200-TRATA-END-TEL", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4157- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4159- PERFORM R3201-TRATA-ENDERECO. */

            R3201_TRATA_ENDERECO_SECTION();

            /*" -4161- MOVE ZEROS TO W-INDEX. */
            _.Move(0, WAREA_AUXILIAR.W_INDEX);

            /*" -4161- PERFORM R3250-TRATA-TELEFONES 3 TIMES. */

            for (int i = 0; i < 3; i++)
            {

                R3250_TRATA_TELEFONES_SECTION();

            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3200_SAIDA*/

        [StopWatch]
        /*" R3205-RELACIONA-ENDERECO-SECTION */
        private void R3205_RELACIONA_ENDERECO_SECTION()
        {
            /*" -4171- MOVE 'R3205-RELACIONA-ENDERECO' TO PARAGRAFO. */
            _.Move("R3205-RELACIONA-ENDERECO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4173- MOVE 'DECLARE PESSOA-ENDERECO' TO COMANDO. */
            _.Move("DECLARE PESSOA-ENDERECO", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4176- MOVE PESSOA-COD-PESSOA OF DCLPESSOA TO COD-PESSOA OF DCLPESSOA-ENDERECO. */
            _.Move(PESSOA.DCLPESSOA.PESSOA_COD_PESSOA, PESENDER.DCLPESSOA_ENDERECO.COD_PESSOA);

            /*" -4191- PERFORM R3205_RELACIONA_ENDERECO_DB_DECLARE_1 */

            R3205_RELACIONA_ENDERECO_DB_DECLARE_1();

            /*" -4195- IF SQLCODE NOT EQUAL 00 AND SQLCODE NOT EQUAL 100 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != 100)
            {

                /*" -4196- DISPLAY 'PF0612B - FIM ANORMAL' */
                _.Display($"PF0612B - FIM ANORMAL");

                /*" -4197- DISPLAY '          ERRO DECLARE DA TABELA PESSOA-ENDERECO' */
                _.Display($"          ERRO DECLARE DA TABELA PESSOA-ENDERECO");

                /*" -4199- DISPLAY '          CODIGO PESSOA.................  ' COD-PESSOA OF DCLPESSOA-ENDERECO */
                _.Display($"          CODIGO PESSOA.................  {PESENDER.DCLPESSOA_ENDERECO.COD_PESSOA}");

                /*" -4201- DISPLAY '          NUMERO PROPOSTA...............  ' R2-NUM-PROPOSTA OF REG-ENDERECO */
                _.Display($"          NUMERO PROPOSTA...............  {LBFPF012.REG_ENDERECO.R2_NUM_PROPOSTA}");

                /*" -4203- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -4204- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -4204- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3205_SAIDA*/

        [StopWatch]
        /*" R3201-TRATA-ENDERECO-SECTION */
        private void R3201_TRATA_ENDERECO_SECTION()
        {
            /*" -4214- MOVE 'R3201-TRATA-ENDERECO' TO PARAGRAFO. */
            _.Move("R3201-TRATA-ENDERECO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4216- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4220- MOVE ZEROS TO OCORR-ENDERECO OF DCLPESSOA-ENDERECO, W-OCORR-ENDERECO. */
            _.Move(0, PESENDER.DCLPESSOA_ENDERECO.OCORR_ENDERECO, WAREA_AUXILIAR.W_OCORR_ENDERECO);

            /*" -4222- PERFORM R3205-RELACIONA-ENDERECO. */

            R3205_RELACIONA_ENDERECO_SECTION();

            /*" -4224- MOVE 'OPEN CURSOR ENDERECOS' TO COMANDO. */
            _.Move("OPEN CURSOR ENDERECOS", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4224- PERFORM R3201_TRATA_ENDERECO_DB_OPEN_1 */

            R3201_TRATA_ENDERECO_DB_OPEN_1();

            /*" -4228- MOVE 'NAO' TO W-ACHOU-ENDERECO. */
            _.Move("NAO", WAREA_AUXILIAR.W_ACHOU_ENDERECO);

            /*" -4230- MOVE SPACES TO W-FIM-CURSOR-ENDERECO. */
            _.Move("", WAREA_AUXILIAR.W_FIM_CURSOR_ENDERECO);

            /*" -4232- PERFORM R3210-FETCH-ENDERECO. */

            R3210_FETCH_ENDERECO_SECTION();

            /*" -4233- IF W-FIM-CURSOR-ENDERECO EQUAL 'SIM' */

            if (WAREA_AUXILIAR.W_FIM_CURSOR_ENDERECO == "SIM")
            {

                /*" -4237- IF R2-ENDERECO OF REG-ENDERECO EQUAL SPACES AND R2-BAIRRO OF REG-ENDERECO EQUAL SPACES AND R2-CIDADE OF REG-ENDERECO EQUAL SPACES AND R2-SIGLA-UF OF REG-ENDERECO EQUAL SPACES */

                if (LBFPF012.REG_ENDERECO.R2_ENDERECO.IsEmpty() && LBFPF012.REG_ENDERECO.R2_BAIRRO.IsEmpty() && LBFPF012.REG_ENDERECO.R2_CIDADE.IsEmpty() && LBFPF012.REG_ENDERECO.R2_SIGLA_UF.IsEmpty())
                {

                    /*" -4239- MOVE 'SIM' TO W-ACHOU-ENDERECO. */
                    _.Move("SIM", WAREA_AUXILIAR.W_ACHOU_ENDERECO);
                }

            }


            /*" -4242- PERFORM R3215-VERIFICA-EXISTE-ENDERECO UNTIL W-FIM-CURSOR-ENDERECO EQUAL 'SIM' . */

            while (!(WAREA_AUXILIAR.W_FIM_CURSOR_ENDERECO == "SIM"))
            {

                R3215_VERIFICA_EXISTE_ENDERECO_SECTION();
            }

            /*" -4243- IF W-ACHOU-ENDERECO EQUAL 'NAO' */

            if (WAREA_AUXILIAR.W_ACHOU_ENDERECO == "NAO")
            {

                /*" -4243- PERFORM R3220-INCLUIR-NOVO-ENDERECO. */

                R3220_INCLUIR_NOVO_ENDERECO_SECTION();
            }


        }

        [StopWatch]
        /*" R3201-TRATA-ENDERECO-DB-OPEN-1 */
        public void R3201_TRATA_ENDERECO_DB_OPEN_1()
        {
            /*" -4224- EXEC SQL OPEN ENDERECOS END-EXEC. */

            ENDERECOS.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3201_SAIDA*/

        [StopWatch]
        /*" R3210-FETCH-ENDERECO-SECTION */
        private void R3210_FETCH_ENDERECO_SECTION()
        {
            /*" -4253- MOVE 'R3210-FETCH-ENDERECO' TO PARAGRAFO. */
            _.Move("R3210-FETCH-ENDERECO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4255- MOVE 'FETCH CURSOR ENDERECOS' TO COMANDO. */
            _.Move("FETCH CURSOR ENDERECOS", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4266- PERFORM R3210_FETCH_ENDERECO_DB_FETCH_1 */

            R3210_FETCH_ENDERECO_DB_FETCH_1();

            /*" -4269- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -4270- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -4271- MOVE 'SIM' TO W-FIM-CURSOR-ENDERECO */
                    _.Move("SIM", WAREA_AUXILIAR.W_FIM_CURSOR_ENDERECO);

                    /*" -4271- PERFORM R3210_FETCH_ENDERECO_DB_CLOSE_1 */

                    R3210_FETCH_ENDERECO_DB_CLOSE_1();

                    /*" -4273- ELSE */
                }
                else
                {


                    /*" -4274- DISPLAY 'PF0612B - FIM ANORMAL' */
                    _.Display($"PF0612B - FIM ANORMAL");

                    /*" -4275- DISPLAY '          ERRO FETCH CURSOR ENDERECO' */
                    _.Display($"          ERRO FETCH CURSOR ENDERECO");

                    /*" -4277- DISPLAY '          CODIGO PESSOA.................  ' COD-PESSOA OF DCLPESSOA-ENDERECO */
                    _.Display($"          CODIGO PESSOA.................  {PESENDER.DCLPESSOA_ENDERECO.COD_PESSOA}");

                    /*" -4279- DISPLAY '          NUMERO PROPOSTA...............  ' R2-NUM-PROPOSTA OF REG-ENDERECO */
                    _.Display($"          NUMERO PROPOSTA...............  {LBFPF012.REG_ENDERECO.R2_NUM_PROPOSTA}");

                    /*" -4281- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                    _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                    /*" -4282- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -4282- PERFORM R9999-00-FINALIZAR. */

                    R9999_00_FINALIZAR_SECTION();
                }

            }


        }

        [StopWatch]
        /*" R3210-FETCH-ENDERECO-DB-FETCH-1 */
        public void R3210_FETCH_ENDERECO_DB_FETCH_1()
        {
            /*" -4266- EXEC SQL FETCH ENDERECOS INTO :DCLPESSOA-ENDERECO.OCORR-ENDERECO, :DCLPESSOA-ENDERECO.COD-PESSOA, :DCLPESSOA-ENDERECO.ENDERECO, :DCLPESSOA-ENDERECO.TIPO-ENDER, :DCLPESSOA-ENDERECO.BAIRRO, :DCLPESSOA-ENDERECO.CEP, :DCLPESSOA-ENDERECO.CIDADE, :DCLPESSOA-ENDERECO.SIGLA-UF, :DCLPESSOA-ENDERECO.SITUACAO-ENDERECO END-EXEC. */

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
            /*" -4271- EXEC SQL CLOSE ENDERECOS END-EXEC */

            ENDERECOS.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3210_SAIDA*/

        [StopWatch]
        /*" R3215-VERIFICA-EXISTE-ENDERECO-SECTION */
        private void R3215_VERIFICA_EXISTE_ENDERECO_SECTION()
        {
            /*" -4292- MOVE 'R3215-VERIFICA-EXISTE-ENDERECO' TO PARAGRAFO. */
            _.Move("R3215-VERIFICA-EXISTE-ENDERECO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4294- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4306- IF R2-TIPO-ENDER OF REG-ENDERECO EQUAL TIPO-ENDER OF DCLPESSOA-ENDERECO AND R2-ENDERECO OF REG-ENDERECO EQUAL ENDERECO OF DCLPESSOA-ENDERECO AND R2-BAIRRO OF REG-ENDERECO EQUAL BAIRRO OF DCLPESSOA-ENDERECO AND R2-CIDADE OF REG-ENDERECO EQUAL CIDADE OF DCLPESSOA-ENDERECO AND R2-SIGLA-UF OF REG-ENDERECO EQUAL SIGLA-UF OF DCLPESSOA-ENDERECO AND R2-CEP OF REG-ENDERECO EQUAL CEP OF DCLPESSOA-ENDERECO */

            if (LBFPF012.REG_ENDERECO.R2_TIPO_ENDER == PESENDER.DCLPESSOA_ENDERECO.TIPO_ENDER && LBFPF012.REG_ENDERECO.R2_ENDERECO == PESENDER.DCLPESSOA_ENDERECO.ENDERECO && LBFPF012.REG_ENDERECO.R2_BAIRRO == PESENDER.DCLPESSOA_ENDERECO.BAIRRO && LBFPF012.REG_ENDERECO.R2_CIDADE == PESENDER.DCLPESSOA_ENDERECO.CIDADE && LBFPF012.REG_ENDERECO.R2_SIGLA_UF == PESENDER.DCLPESSOA_ENDERECO.SIGLA_UF && LBFPF012.REG_ENDERECO.R2_CEP == PESENDER.DCLPESSOA_ENDERECO.CEP)
            {

                /*" -4308- MOVE 'SIM' TO W-ACHOU-ENDERECO. */
                _.Move("SIM", WAREA_AUXILIAR.W_ACHOU_ENDERECO);
            }


            /*" -4312- IF R2-ENDERECO OF REG-ENDERECO EQUAL SPACES AND R2-BAIRRO OF REG-ENDERECO EQUAL SPACES AND R2-CIDADE OF REG-ENDERECO EQUAL SPACES AND R2-SIGLA-UF OF REG-ENDERECO EQUAL SPACES */

            if (LBFPF012.REG_ENDERECO.R2_ENDERECO.IsEmpty() && LBFPF012.REG_ENDERECO.R2_BAIRRO.IsEmpty() && LBFPF012.REG_ENDERECO.R2_CIDADE.IsEmpty() && LBFPF012.REG_ENDERECO.R2_SIGLA_UF.IsEmpty())
            {

                /*" -4314- MOVE 'SIM' TO W-ACHOU-ENDERECO. */
                _.Move("SIM", WAREA_AUXILIAR.W_ACHOU_ENDERECO);
            }


            /*" -4314- PERFORM R3210-FETCH-ENDERECO. */

            R3210_FETCH_ENDERECO_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3215_SAIDA*/

        [StopWatch]
        /*" R3220-INCLUIR-NOVO-ENDERECO-SECTION */
        private void R3220_INCLUIR_NOVO_ENDERECO_SECTION()
        {
            /*" -4324- MOVE 'R3220-INCLUIR-NOVO-ENDERECO' TO PARAGRAFO. */
            _.Move("R3220-INCLUIR-NOVO-ENDERECO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4333- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4336- MOVE OCORR-ENDERECO OF DCLPESSOA-ENDERECO TO W-OCORR-ENDERECO */
            _.Move(PESENDER.DCLPESSOA_ENDERECO.OCORR_ENDERECO, WAREA_AUXILIAR.W_OCORR_ENDERECO);

            /*" -4338- COMPUTE W-OCORR-ENDERECO = W-OCORR-ENDERECO + 1. */
            WAREA_AUXILIAR.W_OCORR_ENDERECO.Value = WAREA_AUXILIAR.W_OCORR_ENDERECO + 1;

            /*" -4338- PERFORM R3230-INCLUIR-ENDERECO. */

            R3230_INCLUIR_ENDERECO_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3220_SAIDA*/

        [StopWatch]
        /*" R3225-OBTER-MAX-ENDERECO-SECTION */
        private void R3225_OBTER_MAX_ENDERECO_SECTION()
        {
            /*" -4348- MOVE 'R3225-OBTER-MAX-ENDERECO' TO PARAGRAFO. */
            _.Move("R3225-OBTER-MAX-ENDERECO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4350- MOVE 'MAX SEGUROS.PESSOA_ENDERECO' TO COMANDO. */
            _.Move("MAX SEGUROS.PESSOA_ENDERECO", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4353- MOVE PESSOA-COD-PESSOA OF DCLPESSOA TO COD-PESSOA OF DCLPESSOA-ENDERECO. */
            _.Move(PESSOA.DCLPESSOA.PESSOA_COD_PESSOA, PESENDER.DCLPESSOA_ENDERECO.COD_PESSOA);

            /*" -4359- PERFORM R3225_OBTER_MAX_ENDERECO_DB_SELECT_1 */

            R3225_OBTER_MAX_ENDERECO_DB_SELECT_1();

            /*" -4362- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -4363- DISPLAY 'PF0612B - FIM ANORMAL' */
                _.Display($"PF0612B - FIM ANORMAL");

                /*" -4364- DISPLAY '          ERRO SELECT MAX TAB. PESSOA-ENDERECO' */
                _.Display($"          ERRO SELECT MAX TAB. PESSOA-ENDERECO");

                /*" -4366- DISPLAY '          CODIGO PESSOA.................  ' COD-PESSOA OF DCLPESSOA-ENDERECO */
                _.Display($"          CODIGO PESSOA.................  {PESENDER.DCLPESSOA_ENDERECO.COD_PESSOA}");

                /*" -4368- DISPLAY '          NUMERO DA PROPOSTA............  ' R2-NUM-PROPOSTA OF REG-ENDERECO */
                _.Display($"          NUMERO DA PROPOSTA............  {LBFPF012.REG_ENDERECO.R2_NUM_PROPOSTA}");

                /*" -4370- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -4371- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -4371- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R3225-OBTER-MAX-ENDERECO-DB-SELECT-1 */
        public void R3225_OBTER_MAX_ENDERECO_DB_SELECT_1()
        {
            /*" -4359- EXEC SQL SELECT VALUE(MAX(OCORR_ENDERECO),0) INTO :DCLPESSOA-ENDERECO.OCORR-ENDERECO FROM SEGUROS.PESSOA_ENDERECO WHERE COD_PESSOA = :DCLPESSOA-ENDERECO.COD-PESSOA WITH UR END-EXEC. */

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
            /*" -4381- MOVE 'R3230-INCLUI-ENDERECO' TO PARAGRAFO. */
            _.Move("R3230-INCLUI-ENDERECO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4383- MOVE 'INSERT PESSOA-ENDERECO' TO COMANDO. */
            _.Move("INSERT PESSOA-ENDERECO", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4386- MOVE W-OCORR-ENDERECO TO OCORR-ENDERECO OF DCLPESSOA-ENDERECO. */
            _.Move(WAREA_AUXILIAR.W_OCORR_ENDERECO, PESENDER.DCLPESSOA_ENDERECO.OCORR_ENDERECO);

            /*" -4389- MOVE PESSOA-COD-PESSOA OF DCLPESSOA TO COD-PESSOA OF DCLPESSOA-ENDERECO. */
            _.Move(PESSOA.DCLPESSOA.PESSOA_COD_PESSOA, PESENDER.DCLPESSOA_ENDERECO.COD_PESSOA);

            /*" -4392- MOVE R2-ENDERECO OF REG-ENDERECO TO ENDERECO OF DCLPESSOA-ENDERECO. */
            _.Move(LBFPF012.REG_ENDERECO.R2_ENDERECO, PESENDER.DCLPESSOA_ENDERECO.ENDERECO);

            /*" -4395- MOVE R2-TIPO-ENDER OF REG-ENDERECO TO TIPO-ENDER OF DCLPESSOA-ENDERECO. */
            _.Move(LBFPF012.REG_ENDERECO.R2_TIPO_ENDER, PESENDER.DCLPESSOA_ENDERECO.TIPO_ENDER);

            /*" -4398- MOVE R2-BAIRRO OF REG-ENDERECO TO BAIRRO OF DCLPESSOA-ENDERECO. */
            _.Move(LBFPF012.REG_ENDERECO.R2_BAIRRO, PESENDER.DCLPESSOA_ENDERECO.BAIRRO);

            /*" -4401- MOVE R2-CEP OF REG-ENDERECO TO CEP OF DCLPESSOA-ENDERECO. */
            _.Move(LBFPF012.REG_ENDERECO.R2_CEP, PESENDER.DCLPESSOA_ENDERECO.CEP);

            /*" -4404- MOVE R2-CIDADE OF REG-ENDERECO TO CIDADE OF DCLPESSOA-ENDERECO. */
            _.Move(LBFPF012.REG_ENDERECO.R2_CIDADE, PESENDER.DCLPESSOA_ENDERECO.CIDADE);

            /*" -4407- MOVE R2-SIGLA-UF OF REG-ENDERECO TO SIGLA-UF OF DCLPESSOA-ENDERECO. */
            _.Move(LBFPF012.REG_ENDERECO.R2_SIGLA_UF, PESENDER.DCLPESSOA_ENDERECO.SIGLA_UF);

            /*" -4410- MOVE 'A' TO SITUACAO-ENDERECO OF DCLPESSOA-ENDERECO. */
            _.Move("A", PESENDER.DCLPESSOA_ENDERECO.SITUACAO_ENDERECO);

            /*" -4413- MOVE 'PF0612B' TO COD-USUARIO OF DCLPESSOA-ENDERECO. */
            _.Move("PF0612B", PESENDER.DCLPESSOA_ENDERECO.COD_USUARIO);

            /*" -4427- PERFORM R3230_INCLUIR_ENDERECO_DB_INSERT_1 */

            R3230_INCLUIR_ENDERECO_DB_INSERT_1();

            /*" -4430- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -4431- DISPLAY 'PF0612B - FIM ANORMAL' */
                _.Display($"PF0612B - FIM ANORMAL");

                /*" -4432- DISPLAY '          ERRO INSERT TABELA PESSOA-ENDERECO' */
                _.Display($"          ERRO INSERT TABELA PESSOA-ENDERECO");

                /*" -4434- DISPLAY '          CODIGO PESSOA.................  ' COD-PESSOA OF DCLPESSOA-ENDERECO */
                _.Display($"          CODIGO PESSOA.................  {PESENDER.DCLPESSOA_ENDERECO.COD_PESSOA}");

                /*" -4436- DISPLAY '          NUMERO DA PROPOSTA............  ' R2-NUM-PROPOSTA OF REG-ENDERECO */
                _.Display($"          NUMERO DA PROPOSTA............  {LBFPF012.REG_ENDERECO.R2_NUM_PROPOSTA}");

                /*" -4438- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -4439- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -4439- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R3230-INCLUIR-ENDERECO-DB-INSERT-1 */
        public void R3230_INCLUIR_ENDERECO_DB_INSERT_1()
        {
            /*" -4427- EXEC SQL INSERT INTO SEGUROS.PESSOA_ENDERECO VALUES (:DCLPESSOA-ENDERECO.COD-PESSOA, :DCLPESSOA-ENDERECO.OCORR-ENDERECO, :DCLPESSOA-ENDERECO.ENDERECO, :DCLPESSOA-ENDERECO.TIPO-ENDER, NULL, :DCLPESSOA-ENDERECO.BAIRRO, :DCLPESSOA-ENDERECO.CEP, :DCLPESSOA-ENDERECO.CIDADE, :DCLPESSOA-ENDERECO.SIGLA-UF, :DCLPESSOA-ENDERECO.SITUACAO-ENDERECO, :DCLPESSOA-ENDERECO.COD-USUARIO, CURRENT TIMESTAMP) END-EXEC. */

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
            /*" -4449- MOVE 'R3250-TRATA-TELEFONE' TO PARAGRAFO. */
            _.Move("R3250-TRATA-TELEFONE", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4451- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4453- ADD 1 TO W-INDEX. */
            WAREA_AUXILIAR.W_INDEX.Value = WAREA_AUXILIAR.W_INDEX + 1;

            /*" -4455- MOVE 'NAO' TO W-ACHOU-TELEFONE. */
            _.Move("NAO", WAREA_AUXILIAR.W_ACHOU_TELEFONE);

            /*" -4456- IF R1-NUM-FONE (W-INDEX) GREATER ZEROS */

            if (LBFPF011.REG_CLIENTES.R1_TELEFONE[WAREA_AUXILIAR.W_INDEX].R1_NUM_FONE > 00)
            {

                /*" -4457- PERFORM R3255-LER-TELEFONE */

                R3255_LER_TELEFONE_SECTION();

                /*" -4458- IF W-ACHOU-TELEFONE EQUAL 'NAO' */

                if (WAREA_AUXILIAR.W_ACHOU_TELEFONE == "NAO")
                {

                    /*" -4458- PERFORM R3260-INCLUIR-NOVO-TELEFONE. */

                    R3260_INCLUIR_NOVO_TELEFONE_SECTION();
                }

            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3250_SAIDA*/

        [StopWatch]
        /*" R3255-LER-TELEFONE-SECTION */
        private void R3255_LER_TELEFONE_SECTION()
        {
            /*" -4468- MOVE 'R3255-LER-TELEFONE' TO PARAGRAFO. */
            _.Move("R3255-LER-TELEFONE", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4470- MOVE 'SELECT PESSOA-TELEFONE' TO COMANDO. */
            _.Move("SELECT PESSOA-TELEFONE", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4476- MOVE PESSOA-COD-PESSOA OF DCLPESSOA TO COD-PESSOA OF DCLPESSOA-TELEFONE. */
            _.Move(PESSOA.DCLPESSOA.PESSOA_COD_PESSOA, PESFONE.DCLPESSOA_TELEFONE.COD_PESSOA);

            /*" -4482- MOVE R1-DDD (W-INDEX) TO DDD OF DCLPESSOA-TELEFONE. */
            _.Move(LBFPF011.REG_CLIENTES.R1_TELEFONE[WAREA_AUXILIAR.W_INDEX].R1_DDD, PESFONE.DCLPESSOA_TELEFONE.DDD);

            /*" -4489- MOVE R1-NUM-FONE (W-INDEX) TO NUM-FONE OF DCLPESSOA-TELEFONE. */
            _.Move(LBFPF011.REG_CLIENTES.R1_TELEFONE[WAREA_AUXILIAR.W_INDEX].R1_NUM_FONE, PESFONE.DCLPESSOA_TELEFONE.NUM_FONE);

            /*" -4492- MOVE W-INDEX TO TIPO-FONE OF DCLPESSOA-TELEFONE */
            _.Move(WAREA_AUXILIAR.W_INDEX, PESFONE.DCLPESSOA_TELEFONE.TIPO_FONE);

            /*" -4501- PERFORM R3255_LER_TELEFONE_DB_SELECT_1 */

            R3255_LER_TELEFONE_DB_SELECT_1();

            /*" -4504- IF SQLCODE EQUAL 00 */

            if (DB.SQLCODE == 00)
            {

                /*" -4505- MOVE 'SIM' TO W-ACHOU-TELEFONE */
                _.Move("SIM", WAREA_AUXILIAR.W_ACHOU_TELEFONE);

                /*" -4506- ELSE */
            }
            else
            {


                /*" -4507- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -4508- MOVE 'NAO' TO W-ACHOU-TELEFONE */
                    _.Move("NAO", WAREA_AUXILIAR.W_ACHOU_TELEFONE);

                    /*" -4509- ELSE */
                }
                else
                {


                    /*" -4510- DISPLAY 'PF0612B - FIM ANORMAL' */
                    _.Display($"PF0612B - FIM ANORMAL");

                    /*" -4511- DISPLAY '          ERRO SELECT TABELA PESSOA-TELEFONE' */
                    _.Display($"          ERRO SELECT TABELA PESSOA-TELEFONE");

                    /*" -4513- DISPLAY '          CODIGO PESSOA.................  ' COD-PESSOA OF DCLPESSOA-TELEFONE */
                    _.Display($"          CODIGO PESSOA.................  {PESFONE.DCLPESSOA_TELEFONE.COD_PESSOA}");

                    /*" -4515- DISPLAY '          NUMERO PROPOSTA...............  ' R2-NUM-PROPOSTA OF REG-ENDERECO */
                    _.Display($"          NUMERO PROPOSTA...............  {LBFPF012.REG_ENDERECO.R2_NUM_PROPOSTA}");

                    /*" -4517- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                    _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                    /*" -4518- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -4518- PERFORM R9999-00-FINALIZAR. */

                    R9999_00_FINALIZAR_SECTION();
                }

            }


        }

        [StopWatch]
        /*" R3255-LER-TELEFONE-DB-SELECT-1 */
        public void R3255_LER_TELEFONE_DB_SELECT_1()
        {
            /*" -4501- EXEC SQL SELECT SITUACAO_FONE INTO :DCLPESSOA-TELEFONE.SITUACAO-FONE FROM SEGUROS.PESSOA_TELEFONE WHERE COD_PESSOA = :DCLPESSOA-TELEFONE.COD-PESSOA AND TIPO_FONE = :DCLPESSOA-TELEFONE.TIPO-FONE AND NUM_FONE = :DCLPESSOA-TELEFONE.NUM-FONE AND DDD = :DCLPESSOA-TELEFONE.DDD WITH UR END-EXEC. */

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
            /*" -4528- MOVE 'R3260-INCLUIR-NOVO-TELEFONE' TO PARAGRAFO. */
            _.Move("R3260-INCLUIR-NOVO-TELEFONE", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4530- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4532- PERFORM R3265-OBTER-MAX-TELEFONE. */

            R3265_OBTER_MAX_TELEFONE_SECTION();

            /*" -4535- MOVE SEQ-FONE OF DCLPESSOA-TELEFONE TO W-SEQ-FONE */
            _.Move(PESFONE.DCLPESSOA_TELEFONE.SEQ_FONE, WAREA_AUXILIAR.W_SEQ_FONE);

            /*" -4537- COMPUTE W-SEQ-FONE = W-SEQ-FONE + 1. */
            WAREA_AUXILIAR.W_SEQ_FONE.Value = WAREA_AUXILIAR.W_SEQ_FONE + 1;

            /*" -4537- PERFORM R3270-INCLUIR-TELEFONE. */

            R3270_INCLUIR_TELEFONE_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3260_SAIDA*/

        [StopWatch]
        /*" R3265-OBTER-MAX-TELEFONE-SECTION */
        private void R3265_OBTER_MAX_TELEFONE_SECTION()
        {
            /*" -4547- MOVE 'R3265-OBTER-MAX-TELEFONE' TO PARAGRAFO. */
            _.Move("R3265-OBTER-MAX-TELEFONE", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4549- MOVE 'MAX SEGUROS.PESSOA_TELEFONE' TO COMANDO. */
            _.Move("MAX SEGUROS.PESSOA_TELEFONE", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4555- PERFORM R3265_OBTER_MAX_TELEFONE_DB_SELECT_1 */

            R3265_OBTER_MAX_TELEFONE_DB_SELECT_1();

            /*" -4558- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -4559- DISPLAY 'PF0612B - FIM ANORMAL' */
                _.Display($"PF0612B - FIM ANORMAL");

                /*" -4560- DISPLAY '          ERRO SELECT MAX TAB. PESSOA-TELEFONE' */
                _.Display($"          ERRO SELECT MAX TAB. PESSOA-TELEFONE");

                /*" -4562- DISPLAY '          CODIGO PESSOA.................  ' COD-PESSOA OF DCLPESSOA-TELEFONE */
                _.Display($"          CODIGO PESSOA.................  {PESFONE.DCLPESSOA_TELEFONE.COD_PESSOA}");

                /*" -4564- DISPLAY '          NUMERO DA PROPOSTA............  ' R1-NUM-PROPOSTA OF REG-CLIENTES */
                _.Display($"          NUMERO DA PROPOSTA............  {LBFPF011.REG_CLIENTES.R1_NUM_PROPOSTA}");

                /*" -4566- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -4567- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -4567- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R3265-OBTER-MAX-TELEFONE-DB-SELECT-1 */
        public void R3265_OBTER_MAX_TELEFONE_DB_SELECT_1()
        {
            /*" -4555- EXEC SQL SELECT VALUE(MAX(SEQ_FONE),0) INTO :DCLPESSOA-TELEFONE.SEQ-FONE FROM SEGUROS.PESSOA_TELEFONE WHERE COD_PESSOA = :DCLPESSOA-TELEFONE.COD-PESSOA WITH UR END-EXEC. */

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
            /*" -4577- MOVE 'R3270-INCLUI-TELEFONE' TO PARAGRAFO. */
            _.Move("R3270-INCLUI-TELEFONE", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4579- MOVE 'INSERT PESSOA-TELEFONE' TO COMANDO. */
            _.Move("INSERT PESSOA-TELEFONE", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4583- MOVE PESSOA-COD-PESSOA OF DCLPESSOA TO COD-PESSOA OF DCLPESSOA-TELEFONE. */
            _.Move(PESSOA.DCLPESSOA.PESSOA_COD_PESSOA, PESFONE.DCLPESSOA_TELEFONE.COD_PESSOA);

            /*" -4586- MOVE W-INDEX TO TIPO-FONE OF DCLPESSOA-TELEFONE. */
            _.Move(WAREA_AUXILIAR.W_INDEX, PESFONE.DCLPESSOA_TELEFONE.TIPO_FONE);

            /*" -4589- MOVE W-SEQ-FONE TO SEQ-FONE OF DCLPESSOA-TELEFONE. */
            _.Move(WAREA_AUXILIAR.W_SEQ_FONE, PESFONE.DCLPESSOA_TELEFONE.SEQ_FONE);

            /*" -4592- MOVE 55 TO DDI OF DCLPESSOA-TELEFONE. */
            _.Move(55, PESFONE.DCLPESSOA_TELEFONE.DDI);

            /*" -4595- MOVE R1-DDD (W-INDEX) TO DDD OF DCLPESSOA-TELEFONE. */
            _.Move(LBFPF011.REG_CLIENTES.R1_TELEFONE[WAREA_AUXILIAR.W_INDEX].R1_DDD, PESFONE.DCLPESSOA_TELEFONE.DDD);

            /*" -4598- MOVE R1-NUM-FONE (W-INDEX) TO NUM-FONE OF DCLPESSOA-TELEFONE. */
            _.Move(LBFPF011.REG_CLIENTES.R1_TELEFONE[WAREA_AUXILIAR.W_INDEX].R1_NUM_FONE, PESFONE.DCLPESSOA_TELEFONE.NUM_FONE);

            /*" -4601- MOVE 'A' TO SITUACAO-FONE OF DCLPESSOA-TELEFONE. */
            _.Move("A", PESFONE.DCLPESSOA_TELEFONE.SITUACAO_FONE);

            /*" -4605- MOVE 'PF0612B' TO COD-USUARIO OF DCLPESSOA-TELEFONE. */
            _.Move("PF0612B", PESFONE.DCLPESSOA_TELEFONE.COD_USUARIO);

            /*" -4616- PERFORM R3270_INCLUIR_TELEFONE_DB_INSERT_1 */

            R3270_INCLUIR_TELEFONE_DB_INSERT_1();

            /*" -4619- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -4620- DISPLAY 'PF0612B - FIM ANORMAL' */
                _.Display($"PF0612B - FIM ANORMAL");

                /*" -4621- DISPLAY '          ERRO INSERT TABELA PESSOA-TELEFONE' */
                _.Display($"          ERRO INSERT TABELA PESSOA-TELEFONE");

                /*" -4623- DISPLAY '          CODIGO PESSOA.................  ' COD-PESSOA OF DCLPESSOA-TELEFONE */
                _.Display($"          CODIGO PESSOA.................  {PESFONE.DCLPESSOA_TELEFONE.COD_PESSOA}");

                /*" -4625- DISPLAY '          NUMERO DA PROPOSTA............  ' R1-NUM-PROPOSTA OF REG-CLIENTES */
                _.Display($"          NUMERO DA PROPOSTA............  {LBFPF011.REG_CLIENTES.R1_NUM_PROPOSTA}");

                /*" -4627- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -4628- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -4628- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R3270-INCLUIR-TELEFONE-DB-INSERT-1 */
        public void R3270_INCLUIR_TELEFONE_DB_INSERT_1()
        {
            /*" -4616- EXEC SQL INSERT INTO SEGUROS.PESSOA_TELEFONE VALUES (:DCLPESSOA-TELEFONE.COD-PESSOA, :DCLPESSOA-TELEFONE.TIPO-FONE, :DCLPESSOA-TELEFONE.SEQ-FONE, :DCLPESSOA-TELEFONE.DDI, :DCLPESSOA-TELEFONE.DDD, :DCLPESSOA-TELEFONE.NUM-FONE, :DCLPESSOA-TELEFONE.SITUACAO-FONE, :DCLPESSOA-TELEFONE.COD-USUARIO, CURRENT TIMESTAMP) END-EXEC. */

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
            /*" -4638- MOVE 'R3300-TRATA-PROPOSTA' TO PARAGRAFO. */
            _.Move("R3300-TRATA-PROPOSTA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4640- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4642- PERFORM R3310-TRATA-TAB-RELACIONAMENTO. */

            R3310_TRATA_TAB_RELACIONAMENTO_SECTION();

            /*" -4644- PERFORM R3350-TRATA-TAB-IDE-RELACIONAM. */

            R3350_TRATA_TAB_IDE_RELACIONAM_SECTION();

            /*" -4646- PERFORM R3360-TRATA-PROP-FIDELIZACAO. */

            R3360_TRATA_PROP_FIDELIZACAO_SECTION();

            /*" -4646- PERFORM R3365-TRATA-PROP-ESPECIFICA. */

            R3365_TRATA_PROP_ESPECIFICA_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3300_SAIDA*/

        [StopWatch]
        /*" R3310-TRATA-TAB-RELACIONAMENTO-SECTION */
        private void R3310_TRATA_TAB_RELACIONAMENTO_SECTION()
        {
            /*" -4658- MOVE 'R3310-TRATA-TAB-RELACIONAMENTO' TO PARAGRAFO. */
            _.Move("R3310-TRATA-TAB-RELACIONAMENTO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4660- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4662- PERFORM R3315-DETERMINA-RELACIONAMENTO */

            R3315_DETERMINA_RELACIONAMENTO_SECTION();

            /*" -4664- MOVE 'NAO' TO W-ACHOU-RELACIONAMENTO. */
            _.Move("NAO", WAREA_AUXILIAR.W_ACHOU_RELACIONAMENTO);

            /*" -4666- PERFORM R3320-VERIFICA-EXISTE-RELACION. */

            R3320_VERIFICA_EXISTE_RELACION_SECTION();

            /*" -4667- IF W-ACHOU-RELACIONAMENTO EQUAL 'NAO' */

            if (WAREA_AUXILIAR.W_ACHOU_RELACIONAMENTO == "NAO")
            {

                /*" -4667- PERFORM R3330-GERA-RELACIONAMENTO. */

                R3330_GERA_RELACIONAMENTO_SECTION();
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3310_SAIDA*/

        [StopWatch]
        /*" R3315-DETERMINA-RELACIONAMENTO-SECTION */
        private void R3315_DETERMINA_RELACIONAMENTO_SECTION()
        {
            /*" -4677- MOVE 'R3315-DETERMINA-RELACIONAMENTO' TO PARAGRAFO. */
            _.Move("R3315-DETERMINA-RELACIONAMENTO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4679- MOVE 'SELECT PRODUTOS_SIVPF' TO COMANDO. */
            _.Move("SELECT PRODUTOS_SIVPF", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4682- MOVE 1 TO PRDSIVPF-COD-EMPRESA-SIVPF OF DCLPRODUTOS-SIVPF */
            _.Move(1, PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_EMPRESA_SIVPF);

            /*" -4685- MOVE R3-COD-PRODUTO OF REG-PROPOSTA-SASSE TO PRDSIVPF-COD-PRODUTO-SIVPF OF DCLPRODUTOS-SIVPF. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_COD_PRODUTO, PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_PRODUTO_SIVPF);

            /*" -4688- MOVE COD-PRODUTO OF DCLPRODUTOS-VG TO PRDSIVPF-COD-PRODUTO OF DCLPRODUTOS-SIVPF. */
            _.Move(PRODVG.DCLPRODUTOS_VG.COD_PRODUTO, PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_PRODUTO);

            /*" -4691- MOVE PRDSIVPF-COD-EMPRESA-SIVPF OF DCLPRODUTOS-SIVPF TO W-COD-EMPRESA. */
            _.Move(PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_EMPRESA_SIVPF, WAREA_AUXILIAR.W_COD_EMPRESA);

            /*" -4706- PERFORM R3315_DETERMINA_RELACIONAMENTO_DB_SELECT_1 */

            R3315_DETERMINA_RELACIONAMENTO_DB_SELECT_1();

            /*" -4709- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -4710- DISPLAY 'PF0612B - FIM ANORMAL' */
                _.Display($"PF0612B - FIM ANORMAL");

                /*" -4711- DISPLAY '          ERRO SELECT TAB. PRODUTOS-SIVPF' */
                _.Display($"          ERRO SELECT TAB. PRODUTOS-SIVPF");

                /*" -4713- DISPLAY '          NOME EMPRESA.................. ' RH-NOME OF REG-HEADER */
                _.Display($"          NOME EMPRESA.................. {LXFPF990.REG_HEADER.RH_NOME}");

                /*" -4715- DISPLAY '          CODIGO DO PRODUTO............. ' PRDSIVPF-COD-PRODUTO-SIVPF OF DCLPRODUTOS-SIVPF */
                _.Display($"          CODIGO DO PRODUTO............. {PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_PRODUTO_SIVPF}");

                /*" -4717- DISPLAY '          NUMERO DA PROPOSTA............  ' R3-NUM-PROPOSTA OF REG-PROPOSTA-SASSE */
                _.Display($"          NUMERO DA PROPOSTA............  {LXFCT004.REG_PROPOSTA_SASSE.R3_NUM_PROPOSTA}");

                /*" -4719- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -4720- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -4722- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


            /*" -4726- MOVE PRDSIVPF-COD-RELAC OF DCLPRODUTOS-SIVPF TO W-COD-RELACION, W-RELACIONAMENTO. */
            _.Move(PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_RELAC, WAREA_AUXILIAR.W_COD_RELACION, WAREA_AUXILIAR.W_RELACIONAMENTO);

            /*" -4727- MOVE PRDSIVPF-COD-PRODUTO-SIVPF OF DCLPRODUTOS-SIVPF TO W-PRODUTO. */
            _.Move(PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_PRODUTO_SIVPF, LBWPF002.W_PRODUTO);

        }

        [StopWatch]
        /*" R3315-DETERMINA-RELACIONAMENTO-DB-SELECT-1 */
        public void R3315_DETERMINA_RELACIONAMENTO_DB_SELECT_1()
        {
            /*" -4706- EXEC SQL SELECT COD_PRODUTO_SIVPF, COD_PRODUTO, COD_RELAC INTO :DCLPRODUTOS-SIVPF.PRDSIVPF-COD-PRODUTO-SIVPF, :DCLPRODUTOS-SIVPF.PRDSIVPF-COD-PRODUTO, :DCLPRODUTOS-SIVPF.PRDSIVPF-COD-RELAC FROM SEGUROS.PRODUTOS_SIVPF WHERE COD_EMPRESA_SIVPF = :DCLPRODUTOS-SIVPF.PRDSIVPF-COD-EMPRESA-SIVPF AND COD_PRODUTO_SIVPF = :DCLPRODUTOS-SIVPF.PRDSIVPF-COD-PRODUTO-SIVPF AND COD_PRODUTO = :DCLPRODUTOS-SIVPF.PRDSIVPF-COD-PRODUTO WITH UR END-EXEC. */

            var r3315_DETERMINA_RELACIONAMENTO_DB_SELECT_1_Query1 = new R3315_DETERMINA_RELACIONAMENTO_DB_SELECT_1_Query1()
            {
                PRDSIVPF_COD_EMPRESA_SIVPF = PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_EMPRESA_SIVPF.ToString(),
                PRDSIVPF_COD_PRODUTO_SIVPF = PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_PRODUTO_SIVPF.ToString(),
                PRDSIVPF_COD_PRODUTO = PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_PRODUTO.ToString(),
            };

            var executed_1 = R3315_DETERMINA_RELACIONAMENTO_DB_SELECT_1_Query1.Execute(r3315_DETERMINA_RELACIONAMENTO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PRDSIVPF_COD_PRODUTO_SIVPF, PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_PRODUTO_SIVPF);
                _.Move(executed_1.PRDSIVPF_COD_PRODUTO, PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_PRODUTO);
                _.Move(executed_1.PRDSIVPF_COD_RELAC, PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_RELAC);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3315_SAIDA*/

        [StopWatch]
        /*" R3320-VERIFICA-EXISTE-RELACION-SECTION */
        private void R3320_VERIFICA_EXISTE_RELACION_SECTION()
        {
            /*" -4737- MOVE 'R3320-VERIFICA-EXISTE-RELACION' TO PARAGRAFO. */
            _.Move("R3320-VERIFICA-EXISTE-RELACION", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4739- MOVE 'SELECT PESSOAS_TIPORELAC' TO COMANDO. */
            _.Move("SELECT PESSOAS_TIPORELAC", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4742- MOVE PESSOA-COD-PESSOA OF DCLPESSOA TO COD-PESSOA OF DCLR-PESSOA-TIPORELAC. */
            _.Move(PESSOA.DCLPESSOA.PESSOA_COD_PESSOA, RTPRELAC.DCLR_PESSOA_TIPORELAC.COD_PESSOA);

            /*" -4746- MOVE W-COD-RELACION TO COD-RELAC OF DCLR-PESSOA-TIPORELAC. */
            _.Move(WAREA_AUXILIAR.W_COD_RELACION, RTPRELAC.DCLR_PESSOA_TIPORELAC.COD_RELAC);

            /*" -4755- PERFORM R3320_VERIFICA_EXISTE_RELACION_DB_SELECT_1 */

            R3320_VERIFICA_EXISTE_RELACION_DB_SELECT_1();

            /*" -4758- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -4759- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -4760- MOVE 'NAO' TO W-ACHOU-RELACIONAMENTO */
                    _.Move("NAO", WAREA_AUXILIAR.W_ACHOU_RELACIONAMENTO);

                    /*" -4761- ELSE */
                }
                else
                {


                    /*" -4762- DISPLAY 'PF0612B - FIM ANORMAL' */
                    _.Display($"PF0612B - FIM ANORMAL");

                    /*" -4763- DISPLAY '          ERRO SELECT TAB. PESSOA-TIPORELAC' */
                    _.Display($"          ERRO SELECT TAB. PESSOA-TIPORELAC");

                    /*" -4765- DISPLAY '          CODIGO PESSOA.................  ' COD-PESSOA OF DCLR-PESSOA-TIPORELAC */
                    _.Display($"          CODIGO PESSOA.................  {RTPRELAC.DCLR_PESSOA_TIPORELAC.COD_PESSOA}");

                    /*" -4767- DISPLAY '          CODIGO RELACIONAMENTO.........  ' COD-RELAC OF DCLR-PESSOA-TIPORELAC */
                    _.Display($"          CODIGO RELACIONAMENTO.........  {RTPRELAC.DCLR_PESSOA_TIPORELAC.COD_RELAC}");

                    /*" -4769- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                    _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                    /*" -4770- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -4771- PERFORM R9999-00-FINALIZAR */

                    R9999_00_FINALIZAR_SECTION();

                    /*" -4772- ELSE */
                }

            }
            else
            {


                /*" -4772- MOVE 'SIM' TO W-ACHOU-RELACIONAMENTO. */
                _.Move("SIM", WAREA_AUXILIAR.W_ACHOU_RELACIONAMENTO);
            }


        }

        [StopWatch]
        /*" R3320-VERIFICA-EXISTE-RELACION-DB-SELECT-1 */
        public void R3320_VERIFICA_EXISTE_RELACION_DB_SELECT_1()
        {
            /*" -4755- EXEC SQL SELECT COD_PESSOA, COD_RELAC INTO :DCLR-PESSOA-TIPORELAC.COD-PESSOA, :DCLR-PESSOA-TIPORELAC.COD-RELAC FROM SEGUROS.R_PESSOA_TIPORELAC WHERE COD_PESSOA = :DCLR-PESSOA-TIPORELAC.COD-PESSOA AND COD_RELAC = :DCLR-PESSOA-TIPORELAC.COD-RELAC WITH UR END-EXEC. */

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
            /*" -4782- MOVE 'R3330-GERA-RELACIONAMENTO' TO PARAGRAFO. */
            _.Move("R3330-GERA-RELACIONAMENTO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4784- MOVE 'INSERT PESSOAS_TIPORELAC' TO COMANDO. */
            _.Move("INSERT PESSOAS_TIPORELAC", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4787- MOVE PESSOA-COD-PESSOA OF DCLPESSOA TO COD-PESSOA OF DCLR-PESSOA-TIPORELAC. */
            _.Move(PESSOA.DCLPESSOA.PESSOA_COD_PESSOA, RTPRELAC.DCLR_PESSOA_TIPORELAC.COD_PESSOA);

            /*" -4790- MOVE W-COD-RELACION TO COD-RELAC OF DCLR-PESSOA-TIPORELAC. */
            _.Move(WAREA_AUXILIAR.W_COD_RELACION, RTPRELAC.DCLR_PESSOA_TIPORELAC.COD_RELAC);

            /*" -4794- PERFORM R3330_GERA_RELACIONAMENTO_DB_INSERT_1 */

            R3330_GERA_RELACIONAMENTO_DB_INSERT_1();

            /*" -4797- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -4798- DISPLAY 'PF0612B - FIM ANORMAL' */
                _.Display($"PF0612B - FIM ANORMAL");

                /*" -4799- DISPLAY '          ERRO INSERT TAB. PESSOA-TIPORELAC' */
                _.Display($"          ERRO INSERT TAB. PESSOA-TIPORELAC");

                /*" -4801- DISPLAY '          CODIGO PESSOA.................  ' COD-PESSOA OF DCLR-PESSOA-TIPORELAC */
                _.Display($"          CODIGO PESSOA.................  {RTPRELAC.DCLR_PESSOA_TIPORELAC.COD_PESSOA}");

                /*" -4803- DISPLAY '          CODIGO RELACIONAMENTO.........  ' COD-RELAC OF DCLR-PESSOA-TIPORELAC */
                _.Display($"          CODIGO RELACIONAMENTO.........  {RTPRELAC.DCLR_PESSOA_TIPORELAC.COD_RELAC}");

                /*" -4805- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -4806- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -4806- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R3330-GERA-RELACIONAMENTO-DB-INSERT-1 */
        public void R3330_GERA_RELACIONAMENTO_DB_INSERT_1()
        {
            /*" -4794- EXEC SQL INSERT INTO SEGUROS.R_PESSOA_TIPORELAC VALUES (:DCLR-PESSOA-TIPORELAC.COD-PESSOA, :DCLR-PESSOA-TIPORELAC.COD-RELAC) END-EXEC. */

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
            /*" -4816- IF W-OBTER-MAX-RELAC EQUAL 'NAO' */

            if (WAREA_AUXILIAR.W_OBTER_MAX_RELAC == "NAO")
            {

                /*" -4817- MOVE 'SIM' TO W-OBTER-MAX-RELAC */
                _.Move("SIM", WAREA_AUXILIAR.W_OBTER_MAX_RELAC);

                /*" -4819- PERFORM R3355-OBTER-MAX-ID-RELACIONAM. */

                R3355_OBTER_MAX_ID_RELACIONAM_SECTION();
            }


            /*" -4820- MOVE 'R3350-TRATA-TAB-RELACIONAM' TO PARAGRAFO. */
            _.Move("R3350-TRATA-TAB-RELACIONAM", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4822- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4825- MOVE NUM-IDENTIFICACAO OF DCLIDENTIFICA-RELAC TO W-NUM-IDENTIF. */
            _.Move(IDERELAC.DCLIDENTIFICA_RELAC.NUM_IDENTIFICACAO, WAREA_AUXILIAR.W_NUM_IDENTIF);

            /*" -4828- COMPUTE W-NUM-IDENTIF = W-NUM-IDENTIF + 1. */
            WAREA_AUXILIAR.W_NUM_IDENTIF.Value = WAREA_AUXILIAR.W_NUM_IDENTIF + 1;

            /*" -4831- MOVE W-NUM-IDENTIF TO NUM-IDENTIFICACAO OF DCLIDENTIFICA-RELAC. */
            _.Move(WAREA_AUXILIAR.W_NUM_IDENTIF, IDERELAC.DCLIDENTIFICA_RELAC.NUM_IDENTIFICACAO);

            /*" -4834- MOVE COD-PESSOA OF DCLR-PESSOA-TIPORELAC TO COD-PESSOA OF DCLIDENTIFICA-RELAC. */
            _.Move(RTPRELAC.DCLR_PESSOA_TIPORELAC.COD_PESSOA, IDERELAC.DCLIDENTIFICA_RELAC.COD_PESSOA);

            /*" -4837- MOVE COD-RELAC OF DCLR-PESSOA-TIPORELAC TO COD-RELAC OF DCLIDENTIFICA-RELAC. */
            _.Move(RTPRELAC.DCLR_PESSOA_TIPORELAC.COD_RELAC, IDERELAC.DCLIDENTIFICA_RELAC.COD_RELAC);

            /*" -4840- MOVE 'PF0612B' TO COD-USUARIO OF DCLIDENTIFICA-RELAC. */
            _.Move("PF0612B", IDERELAC.DCLIDENTIFICA_RELAC.COD_USUARIO);

            /*" -4847- PERFORM R3350_TRATA_TAB_IDE_RELACIONAM_DB_INSERT_1 */

            R3350_TRATA_TAB_IDE_RELACIONAM_DB_INSERT_1();

            /*" -4850- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -4851- DISPLAY 'PF0612B - FIM ANORMAL' */
                _.Display($"PF0612B - FIM ANORMAL");

                /*" -4852- DISPLAY '          ERRO INSERT TABELA IDENTIFICA-RELAC.' */
                _.Display($"          ERRO INSERT TABELA IDENTIFICA-RELAC.");

                /*" -4854- DISPLAY '          NUM IDENTIFICACAO.............  ' NUM-IDENTIFICACAO OF DCLIDENTIFICA-RELAC */
                _.Display($"          NUM IDENTIFICACAO.............  {IDERELAC.DCLIDENTIFICA_RELAC.NUM_IDENTIFICACAO}");

                /*" -4856- DISPLAY '          CODIGO PESSOA.................  ' COD-PESSOA OF DCLIDENTIFICA-RELAC */
                _.Display($"          CODIGO PESSOA.................  {IDERELAC.DCLIDENTIFICA_RELAC.COD_PESSOA}");

                /*" -4858- DISPLAY '          CODIGO RELACIONAMENTO.........  ' COD-RELAC OF DCLIDENTIFICA-RELAC */
                _.Display($"          CODIGO RELACIONAMENTO.........  {IDERELAC.DCLIDENTIFICA_RELAC.COD_RELAC}");

                /*" -4860- DISPLAY '          NUMERO PROPOSTA...............  ' R2-NUM-PROPOSTA OF REG-ENDERECO */
                _.Display($"          NUMERO PROPOSTA...............  {LBFPF012.REG_ENDERECO.R2_NUM_PROPOSTA}");

                /*" -4862- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -4863- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -4863- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R3350-TRATA-TAB-IDE-RELACIONAM-DB-INSERT-1 */
        public void R3350_TRATA_TAB_IDE_RELACIONAM_DB_INSERT_1()
        {
            /*" -4847- EXEC SQL INSERT INTO SEGUROS.IDENTIFICA_RELAC VALUES (:DCLIDENTIFICA-RELAC.NUM-IDENTIFICACAO, :DCLIDENTIFICA-RELAC.COD-PESSOA, :DCLIDENTIFICA-RELAC.COD-RELAC, :DCLIDENTIFICA-RELAC.COD-USUARIO, CURRENT TIMESTAMP) END-EXEC. */

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
            /*" -4873- MOVE 'R3355-OBTER-MAX-ID-RELACIONAM' TO PARAGRAFO. */
            _.Move("R3355-OBTER-MAX-ID-RELACIONAM", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4875- MOVE 'MAX IDENTIFICA_RELAC' TO COMANDO. */
            _.Move("MAX IDENTIFICA_RELAC", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4878- MOVE COD-PESSOA OF DCLR-PESSOA-TIPORELAC TO COD-PESSOA OF DCLIDENTIFICA-RELAC. */
            _.Move(RTPRELAC.DCLR_PESSOA_TIPORELAC.COD_PESSOA, IDERELAC.DCLIDENTIFICA_RELAC.COD_PESSOA);

            /*" -4881- MOVE COD-RELAC OF DCLR-PESSOA-TIPORELAC TO COD-RELAC OF DCLIDENTIFICA-RELAC. */
            _.Move(RTPRELAC.DCLR_PESSOA_TIPORELAC.COD_RELAC, IDERELAC.DCLIDENTIFICA_RELAC.COD_RELAC);

            /*" -4888- PERFORM R3355_OBTER_MAX_ID_RELACIONAM_DB_SELECT_1 */

            R3355_OBTER_MAX_ID_RELACIONAM_DB_SELECT_1();

            /*" -4891- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -4892- DISPLAY 'PF0612B - FIM ANORMAL' */
                _.Display($"PF0612B - FIM ANORMAL");

                /*" -4893- DISPLAY '          ERRO SELECT MAX TAB. IDENTIFICA-RELAC' */
                _.Display($"          ERRO SELECT MAX TAB. IDENTIFICA-RELAC");

                /*" -4895- DISPLAY '          CODIGO PESSOA.................  ' COD-PESSOA OF DCLIDENTIFICA-RELAC */
                _.Display($"          CODIGO PESSOA.................  {IDERELAC.DCLIDENTIFICA_RELAC.COD_PESSOA}");

                /*" -4897- DISPLAY '          CODIGO RELACIONAMENTO.........  ' COD-RELAC OF DCLIDENTIFICA-RELAC */
                _.Display($"          CODIGO RELACIONAMENTO.........  {IDERELAC.DCLIDENTIFICA_RELAC.COD_RELAC}");

                /*" -4899- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -4900- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -4900- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R3355-OBTER-MAX-ID-RELACIONAM-DB-SELECT-1 */
        public void R3355_OBTER_MAX_ID_RELACIONAM_DB_SELECT_1()
        {
            /*" -4888- EXEC SQL SELECT VALUE(MAX(NUM_IDENTIFICACAO),0) INTO :DCLIDENTIFICA-RELAC.NUM-IDENTIFICACAO FROM SEGUROS.IDENTIFICA_RELAC WITH UR END-EXEC. */

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
            /*" -4911- MOVE 'R3360-TRATA-PROP-FIDELIZACAO' TO PARAGRAFO. */
            _.Move("R3360-TRATA-PROP-FIDELIZACAO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4913- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4914- IF W-CONTROLE-TP-0 GREATER ZERO */

            if (WAREA_AUXILIAR.W_CONTROLE_TP_0 > 00)
            {

                /*" -4915- MOVE 1 TO W-TP-MOVIMENTO */
                _.Move(1, WAREA_AUXILIAR.W_TP_MOVIMENTO);

                /*" -4916- ELSE */
            }
            else
            {


                /*" -4920- MOVE 2 TO W-TP-MOVIMENTO. */
                _.Move(2, WAREA_AUXILIAR.W_TP_MOVIMENTO);
            }


            /*" -4927- MOVE R3-NUM-PROPOSTA OF REG-PROPOSTA-SASSE TO NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_NUM_PROPOSTA, PROPFID.DCLPROPOSTA_FIDELIZ.NUM_PROPOSTA_SIVPF);

            /*" -4928- IF COD-ORIGEM-PROPOSTA OF DCLPROPOSTAS-VA NOT EQUAL 12 */

            if (PROPVA.DCLPROPOSTAS_VA.COD_ORIGEM_PROPOSTA != 12)
            {

                /*" -4931- MOVE RCAPS-NUM-TITULO OF DCLRCAPS TO NUM-SICOB OF DCLPROPOSTA-FIDELIZ . */
                _.Move(RCAPS.DCLRCAPS.RCAPS_NUM_TITULO, PROPFID.DCLPROPOSTA_FIDELIZ.NUM_SICOB);
            }


            /*" -4932- IF COD-ORIGEM-PROPOSTA OF DCLPROPOSTAS-VA EQUAL 12 */

            if (PROPVA.DCLPROPOSTAS_VA.COD_ORIGEM_PROPOSTA == 12)
            {

                /*" -4934- MOVE 12 TO ORIGEM-PROPOSTA OF DCLPROPOSTA-FIDELIZ */
                _.Move(12, PROPFID.DCLPROPOSTA_FIDELIZ.ORIGEM_PROPOSTA);

                /*" -4936- MOVE R3-NUM-PROPOSTA OF REG-PROPOSTA-SASSE TO NUM-SICOB OF DCLPROPOSTA-FIDELIZ */
                _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_NUM_PROPOSTA, PROPFID.DCLPROPOSTA_FIDELIZ.NUM_SICOB);

                /*" -4937- ELSE */
            }
            else
            {


                /*" -4939- MOVE RCAPS-NUM-TITULO OF DCLRCAPS TO NUM-SICOB OF DCLPROPOSTA-FIDELIZ */
                _.Move(RCAPS.DCLRCAPS.RCAPS_NUM_TITULO, PROPFID.DCLPROPOSTA_FIDELIZ.NUM_SICOB);

                /*" -4943- MOVE 6 TO ORIGEM-PROPOSTA OF DCLPROPOSTA-FIDELIZ. */
                _.Move(6, PROPFID.DCLPROPOSTA_FIDELIZ.ORIGEM_PROPOSTA);
            }


            /*" -4946- MOVE NUM-IDENTIFICACAO OF DCLIDENTIFICA-RELAC TO NUM-IDENTIFICACAO OF DCLPROPOSTA-FIDELIZ. */
            _.Move(IDERELAC.DCLIDENTIFICA_RELAC.NUM_IDENTIFICACAO, PROPFID.DCLPROPOSTA_FIDELIZ.NUM_IDENTIFICACAO);

            /*" -4949- MOVE R3-DATA-PROPOSTA OF REG-PROPOSTA-SASSE TO W-DATA-TRABALHO. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_DATA_PROPOSTA, WAREA_AUXILIAR.W_DATA_TRABALHO);

            /*" -4951- MOVE W-DIA-TRABALHO TO W-DIA-SQL OF W-DATA-SQL1. */
            _.Move(WAREA_AUXILIAR.FILLER_2.W_DIA_TRABALHO, WAREA_AUXILIAR.W_DATA_SQL1.W_DIA_SQL);

            /*" -4953- MOVE W-MES-TRABALHO TO W-MES-SQL OF W-DATA-SQL1. */
            _.Move(WAREA_AUXILIAR.FILLER_2.W_MES_TRABALHO, WAREA_AUXILIAR.W_DATA_SQL1.W_MES_SQL);

            /*" -4956- MOVE W-ANO-TRABALHO TO W-ANO-SQL OF W-DATA-SQL1. */
            _.Move(WAREA_AUXILIAR.FILLER_2.W_ANO_TRABALHO, WAREA_AUXILIAR.W_DATA_SQL1.W_ANO_SQL);

            /*" -4960- MOVE '-' TO W-BARRA1 OF W-DATA-SQL1, W-BARRA2 OF W-DATA-SQL1. */
            _.Move("-", WAREA_AUXILIAR.W_DATA_SQL1.W_BARRA1_1);
            _.Move("-", WAREA_AUXILIAR.W_DATA_SQL1.W_BARRA2_1);


            /*" -4963- MOVE W-DATA-SQL TO DATA-PROPOSTA OF DCLPROPOSTA-FIDELIZ. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL, PROPFID.DCLPROPOSTA_FIDELIZ.DATA_PROPOSTA);

            /*" -4966- MOVE R3-COD-PRODUTO OF REG-PROPOSTA-SASSE TO COD-PRODUTO-SIVPF OF DCLPROPOSTA-FIDELIZ. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_COD_PRODUTO, PROPFID.DCLPROPOSTA_FIDELIZ.COD_PRODUTO_SIVPF);

            /*" -4969- MOVE PRDSIVPF-COD-EMPRESA-SIVPF OF DCLPRODUTOS-SIVPF TO COD-EMPRESA-SIVPF OF DCLPROPOSTA-FIDELIZ. */
            _.Move(PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_EMPRESA_SIVPF, PROPFID.DCLPROPOSTA_FIDELIZ.COD_EMPRESA_SIVPF);

            /*" -4972- MOVE R3-AGECOBR OF REG-PROPOSTA-SASSE TO AGECOBR OF DCLPROPOSTA-FIDELIZ. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_AGECOBR, PROPFID.DCLPROPOSTA_FIDELIZ.AGECOBR);

            /*" -4975- MOVE R3-DIA-DEBITO OF REG-PROPOSTA-SASSE TO DIA-DEBITO OF DCLPROPOSTA-FIDELIZ. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_DIA_DEBITO, PROPFID.DCLPROPOSTA_FIDELIZ.DIA_DEBITO);

            /*" -4978- MOVE R3-OPCAOPAG OF REG-PROPOSTA-SASSE TO OPCAOPAG OF DCLPROPOSTA-FIDELIZ. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_OPCAOPAG, PROPFID.DCLPROPOSTA_FIDELIZ.OPCAOPAG);

            /*" -4981- MOVE R3-AGECTADEB OF REG-PROPOSTA-SASSE TO AGECTADEB OF DCLPROPOSTA-FIDELIZ. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_CONTA_DEBITO.R3_AGECTADEB, PROPFID.DCLPROPOSTA_FIDELIZ.AGECTADEB);

            /*" -4984- MOVE R3-OPRCTADEB OF REG-PROPOSTA-SASSE TO OPRCTADEB OF DCLPROPOSTA-FIDELIZ. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_CONTA_DEBITO.R3_OPRCTADEB, PROPFID.DCLPROPOSTA_FIDELIZ.OPRCTADEB);

            /*" -4987- MOVE R3-NUMCTADEB OF REG-PROPOSTA-SASSE TO NUMCTADEB OF DCLPROPOSTA-FIDELIZ. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_CONTA_DEBITO.R3_NUMCTADEB, PROPFID.DCLPROPOSTA_FIDELIZ.NUMCTADEB);

            /*" -4990- MOVE R3-DIGCTADEB OF REG-PROPOSTA-SASSE TO DIGCTADEB OF DCLPROPOSTA-FIDELIZ. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_CONTA_DEBITO.R3_DIGCTADEB, PROPFID.DCLPROPOSTA_FIDELIZ.DIGCTADEB);

            /*" -4993- MOVE R3-PCT-DESCONTO OF REG-PROPOSTA-SASSE TO PERC-DESCONTO OF DCLPROPOSTA-FIDELIZ. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_PCT_DESCONTO, PROPFID.DCLPROPOSTA_FIDELIZ.PERC_DESCONTO);

            /*" -4996- MOVE R3-NRMATRVEN OF REG-PROPOSTA-SASSE TO NRMATRVEN OF DCLPROPOSTA-FIDELIZ. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_NRMATRVEN, PROPFID.DCLPROPOSTA_FIDELIZ.NRMATRVEN);

            /*" -5002- MOVE ZEROS TO AGECTAVEN OF DCLPROPOSTA-FIDELIZ OPRCTAVEN OF DCLPROPOSTA-FIDELIZ NUMCTAVEN OF DCLPROPOSTA-FIDELIZ DIGCTAVEN OF DCLPROPOSTA-FIDELIZ. */
            _.Move(0, PROPFID.DCLPROPOSTA_FIDELIZ.AGECTAVEN, PROPFID.DCLPROPOSTA_FIDELIZ.OPRCTAVEN, PROPFID.DCLPROPOSTA_FIDELIZ.NUMCTAVEN, PROPFID.DCLPROPOSTA_FIDELIZ.DIGCTAVEN);

            /*" -5005- MOVE R3-CGC-CONVENENTE OF REG-PROPOSTA-SASSE TO CGC-CONVENENTE OF DCLPROPOSTA-FIDELIZ. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_CGC_CONVENENTE, PROPFID.DCLPROPOSTA_FIDELIZ.CGC_CONVENENTE);

            /*" -5008- MOVE R3-NOME-CONVENENTE OF REG-PROPOSTA-SASSE TO NOME-CONVENENTE OF DCLPROPOSTA-FIDELIZ. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_NOME_CONVENENTE, PROPFID.DCLPROPOSTA_FIDELIZ.NOME_CONVENENTE);

            /*" -5011- MOVE ZEROS TO NRMATRCON OF DCLPROPOSTA-FIDELIZ. */
            _.Move(0, PROPFID.DCLPROPOSTA_FIDELIZ.NRMATRCON);

            /*" -5014- MOVE R3-DTQITBCO OF REG-PROPOSTA-SASSE TO W-DATA-TRABALHO. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_DTQITBCO, WAREA_AUXILIAR.W_DATA_TRABALHO);

            /*" -5016- MOVE W-DIA-TRABALHO TO W-DIA-SQL OF W-DATA-SQL1. */
            _.Move(WAREA_AUXILIAR.FILLER_2.W_DIA_TRABALHO, WAREA_AUXILIAR.W_DATA_SQL1.W_DIA_SQL);

            /*" -5018- MOVE W-MES-TRABALHO TO W-MES-SQL OF W-DATA-SQL1. */
            _.Move(WAREA_AUXILIAR.FILLER_2.W_MES_TRABALHO, WAREA_AUXILIAR.W_DATA_SQL1.W_MES_SQL);

            /*" -5021- MOVE W-ANO-TRABALHO TO W-ANO-SQL OF W-DATA-SQL1. */
            _.Move(WAREA_AUXILIAR.FILLER_2.W_ANO_TRABALHO, WAREA_AUXILIAR.W_DATA_SQL1.W_ANO_SQL);

            /*" -5025- MOVE '-' TO W-BARRA1 OF W-DATA-SQL1, W-BARRA2 OF W-DATA-SQL1. */
            _.Move("-", WAREA_AUXILIAR.W_DATA_SQL1.W_BARRA1_1);
            _.Move("-", WAREA_AUXILIAR.W_DATA_SQL1.W_BARRA2_1);


            /*" -5028- MOVE W-DATA-SQL TO DTQITBCO OF DCLPROPOSTA-FIDELIZ. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL, PROPFID.DCLPROPOSTA_FIDELIZ.DTQITBCO);

            /*" -5031- MOVE R3-VAL-PAGO OF REG-PROPOSTA-SASSE TO VAL-PAGO OF DCLPROPOSTA-FIDELIZ. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_VAL_PAGO, PROPFID.DCLPROPOSTA_FIDELIZ.VAL_PAGO);

            /*" -5034- MOVE R3-AGEPGTO OF REG-PROPOSTA-SASSE TO AGEPGTO OF DCLPROPOSTA-FIDELIZ. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_AGEPGTO, PROPFID.DCLPROPOSTA_FIDELIZ.AGEPGTO);

            /*" -5037- MOVE R3-VAL-TARIFA OF REG-PROPOSTA-SASSE TO VAL-TARIFA OF DCLPROPOSTA-FIDELIZ. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_VAL_TARIFA, PROPFID.DCLPROPOSTA_FIDELIZ.VAL_TARIFA);

            /*" -5040- MOVE ZEROS TO VAL-IOF OF DCLPROPOSTA-FIDELIZ. */
            _.Move(0, PROPFID.DCLPROPOSTA_FIDELIZ.VAL_IOF);

            /*" -5043- MOVE R3-DATA-CREDITO OF REG-PROPOSTA-SASSE TO W-DATA-TRABALHO. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_DATA_CREDITO, WAREA_AUXILIAR.W_DATA_TRABALHO);

            /*" -5045- MOVE W-DIA-TRABALHO TO W-DIA-SQL OF W-DATA-SQL1. */
            _.Move(WAREA_AUXILIAR.FILLER_2.W_DIA_TRABALHO, WAREA_AUXILIAR.W_DATA_SQL1.W_DIA_SQL);

            /*" -5047- MOVE W-MES-TRABALHO TO W-MES-SQL OF W-DATA-SQL1. */
            _.Move(WAREA_AUXILIAR.FILLER_2.W_MES_TRABALHO, WAREA_AUXILIAR.W_DATA_SQL1.W_MES_SQL);

            /*" -5050- MOVE W-ANO-TRABALHO TO W-ANO-SQL OF W-DATA-SQL1. */
            _.Move(WAREA_AUXILIAR.FILLER_2.W_ANO_TRABALHO, WAREA_AUXILIAR.W_DATA_SQL1.W_ANO_SQL);

            /*" -5054- MOVE '-' TO W-BARRA1 OF W-DATA-SQL1, W-BARRA2 OF W-DATA-SQL1. */
            _.Move("-", WAREA_AUXILIAR.W_DATA_SQL1.W_BARRA1_1);
            _.Move("-", WAREA_AUXILIAR.W_DATA_SQL1.W_BARRA2_1);


            /*" -5057- MOVE W-DATA-SQL TO DATA-CREDITO OF DCLPROPOSTA-FIDELIZ. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL, PROPFID.DCLPROPOSTA_FIDELIZ.DATA_CREDITO);

            /*" -5060- MOVE R3-VAL-COMISSAO OF REG-PROPOSTA-SASSE TO VAL-COMISSAO OF DCLPROPOSTA-FIDELIZ. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_VAL_COMISSAO, PROPFID.DCLPROPOSTA_FIDELIZ.VAL_COMISSAO);

            /*" -5063- MOVE R3-SIT-PROPOSTA OF REG-PROPOSTA-SASSE TO SIT-PROPOSTA OF DCLPROPOSTA-FIDELIZ. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_SIT_PROPOSTA, PROPFID.DCLPROPOSTA_FIDELIZ.SIT_PROPOSTA);

            /*" -5066- MOVE 'PF0612B' TO COD-USUARIO OF DCLPROPOSTA-FIDELIZ. */
            _.Move("PF0612B", PROPFID.DCLPROPOSTA_FIDELIZ.COD_USUARIO);

            /*" -5069- MOVE ZEROS TO NSAS-SIVPF OF DCLPROPOSTA-FIDELIZ. */
            _.Move(0, PROPFID.DCLPROPOSTA_FIDELIZ.NSAS_SIVPF);

            /*" -5072- MOVE RH-NSAS OF REG-HEADER TO NSAC-SIVPF OF DCLPROPOSTA-FIDELIZ. */
            _.Move(LXFPF990.REG_HEADER.RH_NSAS, PROPFID.DCLPROPOSTA_FIDELIZ.NSAC_SIVPF);

            /*" -5075- MOVE W-QTD-LD-TIPO-3 TO NSL OF DCLPROPOSTA-FIDELIZ. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_3, PROPFID.DCLPROPOSTA_FIDELIZ.NSL);

            /*" -5076- IF CANAL-VENDA-PAPEL */

            if (WAREA_AUXILIAR.CANAL.W_CANAL_PROPOSTA["CANAL_VENDA_PAPEL"])
            {

                /*" -5078- MOVE 2 TO CANAL-PROPOSTA OF DCLPROPOSTA-FIDELIZ */
                _.Move(2, PROPFID.DCLPROPOSTA_FIDELIZ.CANAL_PROPOSTA);

                /*" -5079- ELSE */
            }
            else
            {


                /*" -5085- MOVE W-CANAL-PROPOSTA TO CANAL-PROPOSTA OF DCLPROPOSTA-FIDELIZ. */
                _.Move(WAREA_AUXILIAR.CANAL.W_CANAL_PROPOSTA, PROPFID.DCLPROPOSTA_FIDELIZ.CANAL_PROPOSTA);
            }


            /*" -5088- MOVE 'S' TO SITUACAO-ENVIO OF DCLPROPOSTA-FIDELIZ. */
            _.Move("S", PROPFID.DCLPROPOSTA_FIDELIZ.SITUACAO_ENVIO);

            /*" -5091- MOVE PESSOA-COD-PESSOA OF DCLPESSOA TO COD-PESSOA OF DCLPROPOSTA-FIDELIZ. */
            _.Move(PESSOA.DCLPESSOA.PESSOA_COD_PESSOA, PROPFID.DCLPROPOSTA_FIDELIZ.COD_PESSOA);

            /*" -5094- MOVE R3-OPCAO-COBER OF REG-PROPOSTA-SASSE TO OPCAO-COBER OF DCLPROPOSTA-FIDELIZ. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_OPCAO_COBER, PROPFID.DCLPROPOSTA_FIDELIZ.OPCAO_COBER);

            /*" -5098- MOVE R3-COD-PLANO OF REG-PROPOSTA-SASSE TO COD-PLANO OF DCLPROPOSTA-FIDELIZ. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_COD_PLANO, PROPFID.DCLPROPOSTA_FIDELIZ.COD_PLANO);

            /*" -5101- MOVE R1-NOME-CONJUGE OF REG-CLIENTES TO NOME-CONJUGE OF DCLPROPOSTA-FIDELIZ. */
            _.Move(LBFPF011.REG_CLIENTES.R1_NOME_CONJUGE, PROPFID.DCLPROPOSTA_FIDELIZ.NOME_CONJUGE);

            /*" -5104- MOVE R1-DTNASC-CONJUGE OF REG-CLIENTES TO W-DATA-TRABALHO. */
            _.Move(LBFPF011.REG_CLIENTES.R1_DTNASC_CONJUGE, WAREA_AUXILIAR.W_DATA_TRABALHO);

            /*" -5106- MOVE W-DIA-TRABALHO TO W-DIA-SQL OF W-DATA-SQL1. */
            _.Move(WAREA_AUXILIAR.FILLER_2.W_DIA_TRABALHO, WAREA_AUXILIAR.W_DATA_SQL1.W_DIA_SQL);

            /*" -5108- MOVE W-MES-TRABALHO TO W-MES-SQL OF W-DATA-SQL1. */
            _.Move(WAREA_AUXILIAR.FILLER_2.W_MES_TRABALHO, WAREA_AUXILIAR.W_DATA_SQL1.W_MES_SQL);

            /*" -5111- MOVE W-ANO-TRABALHO TO W-ANO-SQL OF W-DATA-SQL1. */
            _.Move(WAREA_AUXILIAR.FILLER_2.W_ANO_TRABALHO, WAREA_AUXILIAR.W_DATA_SQL1.W_ANO_SQL);

            /*" -5115- MOVE '-' TO W-BARRA1 OF W-DATA-SQL1, W-BARRA2 OF W-DATA-SQL1. */
            _.Move("-", WAREA_AUXILIAR.W_DATA_SQL1.W_BARRA1_1);
            _.Move("-", WAREA_AUXILIAR.W_DATA_SQL1.W_BARRA2_1);


            /*" -5118- MOVE W-DATA-SQL TO DATA-NASC-CONJUGE OF DCLPROPOSTA-FIDELIZ. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL, PROPFID.DCLPROPOSTA_FIDELIZ.DATA_NASC_CONJUGE);

            /*" -5121- MOVE R1-CBO-CONJUGE OF REG-CLIENTES TO PROFISSAO-CONJUGE OF DCLPROPOSTA-FIDELIZ. */
            _.Move(LBFPF011.REG_CLIENTES.R1_CBO_CONJUGE, PROPFID.DCLPROPOSTA_FIDELIZ.PROFISSAO_CONJUGE);

            /*" -5123- MOVE 'N' TO IND-TIPO-CONTA OF DCLPROPOSTA-FIDELIZ. */
            _.Move("N", PROPFID.DCLPROPOSTA_FIDELIZ.IND_TIPO_CONTA);

            /*" -5226- PERFORM R3360_TRATA_PROP_FIDELIZACAO_DB_INSERT_1 */

            R3360_TRATA_PROP_FIDELIZACAO_DB_INSERT_1();

            /*" -5229- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -5230- DISPLAY 'PF0612B - FIM ANORMAL' */
                _.Display($"PF0612B - FIM ANORMAL");

                /*" -5231- DISPLAY '          ERRO INSERT TABELA PROPOSTA FIDELIZ' */
                _.Display($"          ERRO INSERT TABELA PROPOSTA FIDELIZ");

                /*" -5233- DISPLAY '          CODIGO PESSOA.................  ' COD-PESSOA OF DCLPROPOSTA-FIDELIZ */
                _.Display($"          CODIGO PESSOA.................  {PROPFID.DCLPROPOSTA_FIDELIZ.COD_PESSOA}");

                /*" -5235- DISPLAY '          NUMERO PROPOSTA...............  ' NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ */
                _.Display($"          NUMERO PROPOSTA...............  {PROPFID.DCLPROPOSTA_FIDELIZ.NUM_PROPOSTA_SIVPF}");

                /*" -5237- DISPLAY '          COD-EMPRESA...................  ' COD-EMPRESA-SIVPF OF DCLPROPOSTA-FIDELIZ */
                _.Display($"          COD-EMPRESA...................  {PROPFID.DCLPROPOSTA_FIDELIZ.COD_EMPRESA_SIVPF}");

                /*" -5239- DISPLAY '          COD-PRODUTO-SIVPF.............  ' COD-PRODUTO-SIVPF OF DCLPROPOSTA-FIDELIZ */
                _.Display($"          COD-PRODUTO-SIVPF.............  {PROPFID.DCLPROPOSTA_FIDELIZ.COD_PRODUTO_SIVPF}");

                /*" -5241- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -5242- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -5242- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R3360-TRATA-PROP-FIDELIZACAO-DB-INSERT-1 */
        public void R3360_TRATA_PROP_FIDELIZACAO_DB_INSERT_1()
        {
            /*" -5226- EXEC SQL INSERT INTO SEGUROS.PROPOSTA_FIDELIZ ( NUM_PROPOSTA_SIVPF , NUM_IDENTIFICACAO , COD_EMPRESA_SIVPF , COD_PESSOA , NUM_SICOB , DATA_PROPOSTA , COD_PRODUTO_SIVPF , AGECOBR , DIA_DEBITO , OPCAOPAG , AGECTADEB , OPRCTADEB , NUMCTADEB , DIGCTADEB , PERC_DESCONTO , NRMATRVEN , AGECTAVEN , OPRCTAVEN , NUMCTAVEN , DIGCTAVEN , CGC_CONVENENTE , NOME_CONVENENTE , NRMATRCON , DTQITBCO , VAL_PAGO , AGEPGTO , VAL_TARIFA , VAL_IOF , DATA_CREDITO , VAL_COMISSAO , SIT_PROPOSTA , COD_USUARIO , CANAL_PROPOSTA , NSAS_SIVPF , ORIGEM_PROPOSTA , TIMESTAMP , NSL , NSAC_SIVPF , SITUACAO_ENVIO , OPCAO_COBER , COD_PLANO , NOME_CONJUGE , DATA_NASC_CONJUGE , PROFISSAO_CONJUGE , FAIXA_RENDA_IND , FAIXA_RENDA_FAM , IND_TP_PROPOSTA , IND_TIPO_CONTA ) VALUES (:DCLPROPOSTA-FIDELIZ.NUM-PROPOSTA-SIVPF, :DCLPROPOSTA-FIDELIZ.NUM-IDENTIFICACAO, :DCLPROPOSTA-FIDELIZ.COD-EMPRESA-SIVPF, :DCLPROPOSTA-FIDELIZ.COD-PESSOA, :DCLPROPOSTA-FIDELIZ.NUM-SICOB, :DCLPROPOSTA-FIDELIZ.DATA-PROPOSTA, :DCLPROPOSTA-FIDELIZ.COD-PRODUTO-SIVPF, :DCLPROPOSTA-FIDELIZ.AGECOBR, :DCLPROPOSTA-FIDELIZ.DIA-DEBITO, :DCLPROPOSTA-FIDELIZ.OPCAOPAG, :DCLPROPOSTA-FIDELIZ.AGECTADEB, :DCLPROPOSTA-FIDELIZ.OPRCTADEB, :DCLPROPOSTA-FIDELIZ.NUMCTADEB, :DCLPROPOSTA-FIDELIZ.DIGCTADEB, :DCLPROPOSTA-FIDELIZ.PERC-DESCONTO, :DCLPROPOSTA-FIDELIZ.NRMATRVEN, :DCLPROPOSTA-FIDELIZ.AGECTAVEN, :DCLPROPOSTA-FIDELIZ.OPRCTAVEN, :DCLPROPOSTA-FIDELIZ.NUMCTAVEN, :DCLPROPOSTA-FIDELIZ.DIGCTAVEN, :DCLPROPOSTA-FIDELIZ.CGC-CONVENENTE, :DCLPROPOSTA-FIDELIZ.NOME-CONVENENTE, :DCLPROPOSTA-FIDELIZ.NRMATRCON, :DCLPROPOSTA-FIDELIZ.DTQITBCO, :DCLPROPOSTA-FIDELIZ.VAL-PAGO, :DCLPROPOSTA-FIDELIZ.AGEPGTO, :DCLPROPOSTA-FIDELIZ.VAL-TARIFA, :DCLPROPOSTA-FIDELIZ.VAL-IOF, :DCLPROPOSTA-FIDELIZ.DATA-CREDITO, :DCLPROPOSTA-FIDELIZ.VAL-COMISSAO, :DCLPROPOSTA-FIDELIZ.SIT-PROPOSTA, :DCLPROPOSTA-FIDELIZ.COD-USUARIO, :DCLPROPOSTA-FIDELIZ.CANAL-PROPOSTA, :DCLPROPOSTA-FIDELIZ.NSAS-SIVPF, :DCLPROPOSTA-FIDELIZ.ORIGEM-PROPOSTA, CURRENT TIMESTAMP, :DCLPROPOSTA-FIDELIZ.NSL, :DCLPROPOSTA-FIDELIZ.NSAC-SIVPF, :DCLPROPOSTA-FIDELIZ.SITUACAO-ENVIO, :DCLPROPOSTA-FIDELIZ.OPCAO-COBER, :DCLPROPOSTA-FIDELIZ.COD-PLANO, :DCLPROPOSTA-FIDELIZ.NOME-CONJUGE, :DCLPROPOSTA-FIDELIZ.DATA-NASC-CONJUGE:VIND-DTNASC-ESPOSA, :DCLPROPOSTA-FIDELIZ.PROFISSAO-CONJUGE, :DCLPROPOSTAS-VA.FAIXA-RENDA-IND:VIND-FAIXA-RENDA-IND, :DCLPROPOSTAS-VA.FAIXA-RENDA-FAM:VIND-FAIXA-RENDA-FAM, :DCLPROPOSTA-FIDELIZ.IND-TP-PROPOSTA, :DCLPROPOSTA-FIDELIZ.IND-TIPO-CONTA ) END-EXEC. */

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
                IND_TP_PROPOSTA = PROPFID.DCLPROPOSTA_FIDELIZ.IND_TP_PROPOSTA.ToString(),
                IND_TIPO_CONTA = PROPFID.DCLPROPOSTA_FIDELIZ.IND_TIPO_CONTA.ToString(),
            };

            R3360_TRATA_PROP_FIDELIZACAO_DB_INSERT_1_Insert1.Execute(r3360_TRATA_PROP_FIDELIZACAO_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3360_SAIDA*/

        [StopWatch]
        /*" R3365-TRATA-PROP-ESPECIFICA-SECTION */
        private void R3365_TRATA_PROP_ESPECIFICA_SECTION()
        {
            /*" -5251- MOVE 'R3365-TRATA-PROP-ESPECIFICA' TO PARAGRAFO. */
            _.Move("R3365-TRATA-PROP-ESPECIFICA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5254- MOVE W-COD-RELACION TO W-RELACIONAMENTO. */
            _.Move(WAREA_AUXILIAR.W_COD_RELACION, WAREA_AUXILIAR.W_RELACIONAMENTO);

            /*" -5256- MOVE 'INSERT PROPOSTA-SASSE' TO COMANDO. */
            _.Move("INSERT PROPOSTA-SASSE", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5259- MOVE NUM-IDENTIFICACAO OF DCLPROPOSTA-FIDELIZ TO PROPSSVD-NUM-IDENTIFICACAO OF DCLPROP-SASSE-VIDA. */
            _.Move(PROPFID.DCLPROPOSTA_FIDELIZ.NUM_IDENTIFICACAO, PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_IDENTIFICACAO);

            /*" -5262- MOVE R3-DPS-TITULAR OF REG-PROPOSTA-SASSE TO PROPSSVD-DPS-TITULAR OF DCLPROP-SASSE-VIDA. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_DPS_TITULAR, PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_DPS_TITULAR);

            /*" -5265- MOVE R3-DPS-CONJUGE OF REG-PROPOSTA-SASSE TO PROPSSVD-DPS-CONJUGE OF DCLPROP-SASSE-VIDA. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_DPS_CONJUGE, PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_DPS_CONJUGE);

            /*" -5268- MOVE R3-APOS-INVALIDEZ OF REG-PROPOSTA-SASSE TO PROPSSVD-APOS-INVALIDEZ OF DCLPROP-SASSE-VIDA. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_APOS_INVALIDEZ, PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_APOS_INVALIDEZ);

            /*" -5273- MOVE 'PF0612B' TO PROPSSVD-COD-USUARIO OF DCLPROP-SASSE-VIDA. */
            _.Move("PF0612B", PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_COD_USUARIO);

            /*" -5277- MOVE MOVVGAP-NUM-APOLICE TO PROPSSVD-NUM-APOLICE OF DCLPROP-SASSE-VIDA NUM-APOLICE OF DCLPRODUTOS-VG. */
            _.Move(MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_NUM_APOLICE, PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_APOLICE, PRODVG.DCLPRODUTOS_VG.NUM_APOLICE);

            /*" -5281- MOVE MOVVGAP-COD-SUBGRUPO TO PROPSSVD-COD-SUBGRUPO OF DCLPROP-SASSE-VIDA COD-SUBGRUPO OF DCLPRODUTOS-VG. */
            _.Move(MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_COD_SUBGRUPO, PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_COD_SUBGRUPO, PRODVG.DCLPRODUTOS_VG.COD_SUBGRUPO);

            /*" -5295- PERFORM R3365_TRATA_PROP_ESPECIFICA_DB_INSERT_1 */

            R3365_TRATA_PROP_ESPECIFICA_DB_INSERT_1();

            /*" -5298- MOVE SQLERRMC TO WSQLERRMC. */
            _.Move(DB.SQLERRMC, WSQLERRO.WSQLERRMC);

            /*" -5300- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -5301- DISPLAY 'PF0612B - FIM ANORMAL' */
                _.Display($"PF0612B - FIM ANORMAL");

                /*" -5302- DISPLAY '          ERRO INSERT TAB. PROPOSTA SASSE VIDA' */
                _.Display($"          ERRO INSERT TAB. PROPOSTA SASSE VIDA");

                /*" -5304- DISPLAY '          CODIGO PESSOA.................  ' COD-PESSOA OF DCLIDENTIFICA-RELAC */
                _.Display($"          CODIGO PESSOA.................  {IDERELAC.DCLIDENTIFICA_RELAC.COD_PESSOA}");

                /*" -5306- DISPLAY '          NUMERO PROPOSTA...............  ' NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ */
                _.Display($"          NUMERO PROPOSTA...............  {PROPFID.DCLPROPOSTA_FIDELIZ.NUM_PROPOSTA_SIVPF}");

                /*" -5308- DISPLAY '          NUMERO IDENTIFICACAO..........  ' PROPSSVD-NUM-IDENTIFICACAO OF DCLPROP-SASSE-VIDA */
                _.Display($"          NUMERO IDENTIFICACAO..........  {PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_IDENTIFICACAO}");

                /*" -5310- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -5311- DISPLAY 'CONTEUDO DO WSQLERRMC : ' WSQLERRMC */
                _.Display($"CONTEUDO DO WSQLERRMC : {WSQLERRO.WSQLERRMC}");

                /*" -5312- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -5312- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R3365-TRATA-PROP-ESPECIFICA-DB-INSERT-1 */
        public void R3365_TRATA_PROP_ESPECIFICA_DB_INSERT_1()
        {
            /*" -5295- EXEC SQL INSERT INTO SEGUROS.PROP_SASSE_VIDA VALUES (:DCLPROP-SASSE-VIDA.PROPSSVD-NUM-IDENTIFICACAO, :DCLPROP-SASSE-VIDA.PROPSSVD-DPS-TITULAR, :DCLPROP-SASSE-VIDA.PROPSSVD-DPS-CONJUGE, :DCLPROP-SASSE-VIDA.PROPSSVD-APOS-INVALIDEZ, :DCLPROP-SASSE-VIDA.PROPSSVD-COD-USUARIO, :DCLPROP-SASSE-VIDA.PROPSSVD-NUM-APOLICE, :DCLPROP-SASSE-VIDA.PROPSSVD-COD-SUBGRUPO, CURRENT TIMESTAMP, NULL, NULL, NULL, NULL ) END-EXEC. */

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
            /*" -5408- MOVE 'R3390-GERA-HIST-FIDELIZACAO' TO PARAGRAFO. */
            _.Move("R3390-GERA-HIST-FIDELIZACAO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5410- MOVE 'INSERT HIST-PROP-FIDELIZ' TO COMANDO. */
            _.Move("INSERT HIST-PROP-FIDELIZ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5413- MOVE NUM-IDENTIFICACAO OF DCLPROPOSTA-FIDELIZ TO PROPFIDH-NUM-IDENTIFICACAO */
            _.Move(PROPFID.DCLPROPOSTA_FIDELIZ.NUM_IDENTIFICACAO, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NUM_IDENTIFICACAO);

            /*" -5416- MOVE SISTEMAS-DATA-MOV-ABERTO OF DCLSISTEMAS TO PROPFIDH-DATA-SITUACAO */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_DATA_SITUACAO);

            /*" -5419- MOVE RH-NSAS OF REG-HEADER TO PROPFIDH-NSAS-SIVPF */
            _.Move(LXFPF990.REG_HEADER.RH_NSAS, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NSAS_SIVPF);

            /*" -5422- MOVE W-QTD-LD-TIPO-3 TO PROPFIDH-NSL */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_3, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NSL);

            /*" -5425- MOVE R3-SIT-PROPOSTA OF REG-PROPOSTA-SASSE TO PROPFIDH-SIT-PROPOSTA. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_SIT_PROPOSTA, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_PROPOSTA);

            /*" -5428- MOVE R3-SIT-COBRANCA OF REG-PROPOSTA-SASSE TO PROPFIDH-SIT-COBRANCA-SIVPF. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_SIT_COBRANCA, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_COBRANCA_SIVPF);

            /*" -5431- MOVE R3-SIT-MOTIVO OF REG-PROPOSTA-SASSE TO PROPFIDH-SIT-MOTIVO-SIVPF. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_SIT_MOTIVO, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_MOTIVO_SIVPF);

            /*" -5434- MOVE COD-EMPRESA-SIVPF OF DCLPROPOSTA-FIDELIZ TO PROPFIDH-COD-EMPRESA-SIVPF. */
            _.Move(PROPFID.DCLPROPOSTA_FIDELIZ.COD_EMPRESA_SIVPF, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_COD_EMPRESA_SIVPF);

            /*" -5437- MOVE COD-PRODUTO-SIVPF OF DCLPROPOSTA-FIDELIZ TO PROPFIDH-COD-PRODUTO-SIVPF. */
            _.Move(PROPFID.DCLPROPOSTA_FIDELIZ.COD_PRODUTO_SIVPF, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_COD_PRODUTO_SIVPF);

            /*" -5448- PERFORM R3390_GERA_HIST_FIDELIZACAO_DB_INSERT_1 */

            R3390_GERA_HIST_FIDELIZACAO_DB_INSERT_1();

            /*" -5451- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -5452- DISPLAY 'PF0612B - FIM ANORMAL' */
                _.Display($"PF0612B - FIM ANORMAL");

                /*" -5453- DISPLAY '          ERRO INSERT TABELA HIST-PROP-FIDELIZ' */
                _.Display($"          ERRO INSERT TABELA HIST-PROP-FIDELIZ");

                /*" -5455- DISPLAY '          CODIGO PESSOA.................  ' COD-PESSOA OF DCLIDENTIFICA-RELAC */
                _.Display($"          CODIGO PESSOA.................  {IDERELAC.DCLIDENTIFICA_RELAC.COD_PESSOA}");

                /*" -5457- DISPLAY '          NUMERO PROPOSTA...............  ' R3-NUM-PROPOSTA OF REG-PROPOSTA-SASSE */
                _.Display($"          NUMERO PROPOSTA...............  {LXFCT004.REG_PROPOSTA_SASSE.R3_NUM_PROPOSTA}");

                /*" -5459- DISPLAY '          NUMERO IDENTIFICACAO..........  ' PROPSSVD-NUM-IDENTIFICACAO OF DCLPROP-SASSE-VIDA */
                _.Display($"          NUMERO IDENTIFICACAO..........  {PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_IDENTIFICACAO}");

                /*" -5461- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -5462- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -5463- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


            /*" -5463- PERFORM R3391-OBTER-NUM-SICOB */

            R3391_OBTER_NUM_SICOB_SECTION();

        }

        [StopWatch]
        /*" R3390-GERA-HIST-FIDELIZACAO-DB-INSERT-1 */
        public void R3390_GERA_HIST_FIDELIZACAO_DB_INSERT_1()
        {
            /*" -5448- EXEC SQL INSERT INTO SEGUROS.HIST_PROP_FIDELIZ VALUES (:PROPFIDH-NUM-IDENTIFICACAO , :PROPFIDH-DATA-SITUACAO , :PROPFIDH-NSAS-SIVPF , :PROPFIDH-NSL , :PROPFIDH-SIT-PROPOSTA , :PROPFIDH-SIT-COBRANCA-SIVPF, :PROPFIDH-SIT-MOTIVO-SIVPF , :PROPFIDH-COD-EMPRESA-SIVPF , :PROPFIDH-COD-PRODUTO-SIVPF) END-EXEC. */

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
            /*" -5472- MOVE 'R3391-OBTER-NUM-SICOB' TO PARAGRAFO. */
            _.Move("R3391-OBTER-NUM-SICOB", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5476- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5479- MOVE R3-NUM-PROPOSTA OF REG-PROPOSTA-SASSE TO NUM-PROPOSTA-SIVPF OF DCLCONVERSAO-SICOB. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_NUM_PROPOSTA, COVSICOB.DCLCONVERSAO_SICOB.NUM_PROPOSTA_SIVPF);

            /*" -5497- PERFORM R0205-ACESSAR-CONVERSAO-SICOB. */

            R0205_ACESSAR_CONVERSAO_SICOB_SECTION();

            /*" -5497- PERFORM R3393-NUMERAR-SICOB. */

            R3393_NUMERAR_SICOB_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3391_SAIDA*/

        [StopWatch]
        /*" R3393-NUMERAR-SICOB-SECTION */
        private void R3393_NUMERAR_SICOB_SECTION()
        {
            /*" -5506- MOVE 'R3393-NUMERAR-SICOB' TO PARAGRAFO. */
            _.Move("R3393-NUMERAR-SICOB", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5508- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5510- MOVE 26 TO CEDENTE-COD-CEDENTE OF DCLCEDENTE. */
            _.Move(26, CEDENTE.DCLCEDENTE.CEDENTE_COD_CEDENTE);

            /*" -5518- PERFORM R3393_NUMERAR_SICOB_DB_SELECT_1 */

            R3393_NUMERAR_SICOB_DB_SELECT_1();

            /*" -5521- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -5522- DISPLAY 'PF0612B FIM ANORMAL' */
                _.Display($"PF0612B FIM ANORMAL");

                /*" -5523- DISPLAY '        ERRO SELECT TAB. CEDENTE' */
                _.Display($"        ERRO SELECT TAB. CEDENTE");

                /*" -5525- DISPLAY '        CODIGO CEDENTE...... ' CEDENTE-COD-CEDENTE OF DCLCEDENTE */
                _.Display($"        CODIGO CEDENTE...... {CEDENTE.DCLCEDENTE.CEDENTE_COD_CEDENTE}");

                /*" -5526- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -5528- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


            /*" -5532- MOVE CEDENTE-NUM-TITULO OF DCLCEDENTE TO W-NUMR-TITULO. */
            _.Move(CEDENTE.DCLCEDENTE.CEDENTE_NUM_TITULO, WAREA_AUXILIAR.W_NUMR_TITULO);

            /*" -5534- ADD 1 TO WTITL-SEQUENCIA. */
            WAREA_AUXILIAR.FILLER_11.WTITL_SEQUENCIA.Value = WAREA_AUXILIAR.FILLER_11.WTITL_SEQUENCIA + 1;

            /*" -5536- MOVE WTITL-SEQUENCIA TO DPARM01. */
            _.Move(WAREA_AUXILIAR.FILLER_11.WTITL_SEQUENCIA, WAREA_AUXILIAR.DPARM01X.DPARM01);

            /*" -5538- CALL 'PROTIT01' USING DPARM01X. */
            _.Call("PROTIT01", WAREA_AUXILIAR.DPARM01X);

            /*" -5539- IF DPARM01-RC NOT EQUAL +0 */

            if (WAREA_AUXILIAR.DPARM01X.DPARM01_RC != +0)
            {

                /*" -5540- DISPLAY 'PF0612B FIM ANORMAL' */
                _.Display($"PF0612B FIM ANORMAL");

                /*" -5542- DISPLAY '        ERRO CHAMADA PROTIT01  ' DPARM01-RC */
                _.Display($"        ERRO CHAMADA PROTIT01  {WAREA_AUXILIAR.DPARM01X.DPARM01_RC}");

                /*" -5544- DISPLAY '        CODIGO CEDENTE........ ' CEDENTE-COD-CEDENTE OF DCLCEDENTE */
                _.Display($"        CODIGO CEDENTE........ {CEDENTE.DCLCEDENTE.CEDENTE_COD_CEDENTE}");

                /*" -5545- DISPLAY '        AREA DE PARM.......... ' DPARM01X */
                _.Display($"        AREA DE PARM.......... {WAREA_AUXILIAR.DPARM01X}");

                /*" -5546- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -5548- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


            /*" -5550- MOVE DPARM01-D1 TO WTITL-DIGITO. */
            _.Move(WAREA_AUXILIAR.DPARM01X.DPARM01_D1, WAREA_AUXILIAR.FILLER_11.WTITL_DIGITO);

            /*" -5552- MOVE W-NUMR-TITULO TO CEDENTE-NUM-TITULO OF DCLCEDENTE. */
            _.Move(WAREA_AUXILIAR.W_NUMR_TITULO, CEDENTE.DCLCEDENTE.CEDENTE_NUM_TITULO);

            /*" -5554- IF CEDENTE-NUM-TITULO OF DCLCEDENTE NOT LESS CEDENTE-NUM-TITULO-MAX OF DCLCEDENTE */

            if (CEDENTE.DCLCEDENTE.CEDENTE_NUM_TITULO >= CEDENTE.DCLCEDENTE.CEDENTE_NUM_TITULO_MAX)
            {

                /*" -5555- DISPLAY 'PF0612B FIM ANORMAL' */
                _.Display($"PF0612B FIM ANORMAL");

                /*" -5556- DISPLAY '        NUM. SICOB CALCULADO EXCEDE SICOB MAXIMO' */
                _.Display($"        NUM. SICOB CALCULADO EXCEDE SICOB MAXIMO");

                /*" -5558- DISPLAY '        CODIGO CEDENTE...... ' CEDENTE-COD-CEDENTE OF DCLCEDENTE */
                _.Display($"        CODIGO CEDENTE...... {CEDENTE.DCLCEDENTE.CEDENTE_COD_CEDENTE}");

                /*" -5560- DISPLAY '        SICOB CALCULADO..... ' CEDENTE-NUM-TITULO OF DCLCEDENTE */
                _.Display($"        SICOB CALCULADO..... {CEDENTE.DCLCEDENTE.CEDENTE_NUM_TITULO}");

                /*" -5562- DISPLAY '        SICOB MAXIMO........ ' CEDENTE-NUM-TITULO-MAX OF DCLCEDENTE */
                _.Display($"        SICOB MAXIMO........ {CEDENTE.DCLCEDENTE.CEDENTE_NUM_TITULO_MAX}");

                /*" -5563- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -5567- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


            /*" -5571- PERFORM R3393_NUMERAR_SICOB_DB_UPDATE_1 */

            R3393_NUMERAR_SICOB_DB_UPDATE_1();

            /*" -5574- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -5575- DISPLAY 'PF0612B FIM ANORMAL' */
                _.Display($"PF0612B FIM ANORMAL");

                /*" -5576- DISPLAY '        ERRO UPDATE TAB. CEDENTE' */
                _.Display($"        ERRO UPDATE TAB. CEDENTE");

                /*" -5578- DISPLAY '        CODIGO CEDENTE...... ' CEDENTE-COD-CEDENTE OF DCLCEDENTE */
                _.Display($"        CODIGO CEDENTE...... {CEDENTE.DCLCEDENTE.CEDENTE_COD_CEDENTE}");

                /*" -5579- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -5580- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


            /*" -5580- PERFORM R3394-GERA-DE-PARA-NR-SICOB */

            R3394_GERA_DE_PARA_NR_SICOB_SECTION();

        }

        [StopWatch]
        /*" R3393-NUMERAR-SICOB-DB-SELECT-1 */
        public void R3393_NUMERAR_SICOB_DB_SELECT_1()
        {
            /*" -5518- EXEC SQL SELECT NUM_TITULO, NUM_TITULO_MAX INTO :DCLCEDENTE.CEDENTE-NUM-TITULO, :DCLCEDENTE.CEDENTE-NUM-TITULO-MAX FROM SEGUROS.CEDENTE WHERE COD_CEDENTE = :DCLCEDENTE.CEDENTE-COD-CEDENTE WITH UR END-EXEC. */

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
            /*" -5571- EXEC SQL UPDATE SEGUROS.CEDENTE SET NUM_TITULO = :DCLCEDENTE.CEDENTE-NUM-TITULO WHERE COD_CEDENTE = :DCLCEDENTE.CEDENTE-COD-CEDENTE END-EXEC. */

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
            /*" -5589- MOVE 'R3394-GERA-DE-PARA-NR-SICOB' TO PARAGRAFO. */
            _.Move("R3394-GERA-DE-PARA-NR-SICOB", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5591- MOVE 'INSERT CONVERSAO-SICOB' TO COMANDO. */
            _.Move("INSERT CONVERSAO-SICOB", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5594- MOVE R3-NUM-PROPOSTA OF REG-PROPOSTA-SASSE TO NUM-PROPOSTA-SIVPF OF DCLCONVERSAO-SICOB */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_NUM_PROPOSTA, COVSICOB.DCLCONVERSAO_SICOB.NUM_PROPOSTA_SIVPF);

            /*" -5597- MOVE R3-COD-PRODUTO OF REG-PROPOSTA-SASSE TO PRODUTO-SIVPF OF DCLCONVERSAO-SICOB */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_COD_PRODUTO, COVSICOB.DCLCONVERSAO_SICOB.PRODUTO_SIVPF);

            /*" -5600- MOVE R3-DTQITBCO OF REG-PROPOSTA-SASSE TO W-DATA-TRABALHO */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_DTQITBCO, WAREA_AUXILIAR.W_DATA_TRABALHO);

            /*" -5602- MOVE W-DIA-TRABALHO TO W-DIA-SQL OF W-DATA-SQL1 */
            _.Move(WAREA_AUXILIAR.FILLER_2.W_DIA_TRABALHO, WAREA_AUXILIAR.W_DATA_SQL1.W_DIA_SQL);

            /*" -5604- MOVE W-MES-TRABALHO TO W-MES-SQL OF W-DATA-SQL1 */
            _.Move(WAREA_AUXILIAR.FILLER_2.W_MES_TRABALHO, WAREA_AUXILIAR.W_DATA_SQL1.W_MES_SQL);

            /*" -5607- MOVE W-ANO-TRABALHO TO W-ANO-SQL OF W-DATA-SQL1 */
            _.Move(WAREA_AUXILIAR.FILLER_2.W_ANO_TRABALHO, WAREA_AUXILIAR.W_DATA_SQL1.W_ANO_SQL);

            /*" -5611- MOVE '-' TO W-BARRA1 OF W-DATA-SQL1, W-BARRA2 OF W-DATA-SQL1 */
            _.Move("-", WAREA_AUXILIAR.W_DATA_SQL1.W_BARRA1_1);
            _.Move("-", WAREA_AUXILIAR.W_DATA_SQL1.W_BARRA2_1);


            /*" -5614- MOVE W-DATA-SQL TO DATA-QUITACAO OF DCLCONVERSAO-SICOB */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL, COVSICOB.DCLCONVERSAO_SICOB.DATA_QUITACAO);

            /*" -5617- MOVE R3-AGEPGTO OF REG-PROPOSTA-SASSE TO AGEPGTO OF DCLCONVERSAO-SICOB */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_AGEPGTO, COVSICOB.DCLCONVERSAO_SICOB.AGEPGTO);

            /*" -5620- MOVE R3-VAL-PAGO OF REG-PROPOSTA-SASSE TO VAL-RCAP OF DCLCONVERSAO-SICOB */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_VAL_PAGO, COVSICOB.DCLCONVERSAO_SICOB.VAL_RCAP);

            /*" -5623- MOVE PRDSIVPF-COD-EMPRESA-SIVPF OF DCLPRODUTOS-SIVPF TO COD-EMPRESA-SIVPF OF DCLCONVERSAO-SICOB */
            _.Move(PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_EMPRESA_SIVPF, COVSICOB.DCLCONVERSAO_SICOB.COD_EMPRESA_SIVPF);

            /*" -5626- MOVE SISTEMAS-DATA-MOV-ABERTO OF DCLSISTEMAS TO DATA-OPERACAO OF DCLCONVERSAO-SICOB */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, COVSICOB.DCLCONVERSAO_SICOB.DATA_OPERACAO);

            /*" -5629- MOVE 'PF0612B' TO COD-USUARIO OF DCLCONVERSAO-SICOB. */
            _.Move("PF0612B", COVSICOB.DCLCONVERSAO_SICOB.COD_USUARIO);

            /*" -5632- MOVE CEDENTE-NUM-TITULO OF DCLCEDENTE TO NUM-SICOB OF DCLCONVERSAO-SICOB. */
            _.Move(CEDENTE.DCLCEDENTE.CEDENTE_NUM_TITULO, COVSICOB.DCLCONVERSAO_SICOB.NUM_SICOB);

            /*" -5644- PERFORM R3394_GERA_DE_PARA_NR_SICOB_DB_INSERT_1 */

            R3394_GERA_DE_PARA_NR_SICOB_DB_INSERT_1();

            /*" -5647- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -5648- DISPLAY 'PF0612B - FIM ANORMAL' */
                _.Display($"PF0612B - FIM ANORMAL");

                /*" -5649- DISPLAY '          ERRO INSERT DA TAB. CONVERSAO-SICOB' */
                _.Display($"          ERRO INSERT DA TAB. CONVERSAO-SICOB");

                /*" -5651- DISPLAY '          CODIGO PESSOA.................  ' PESSOA-COD-PESSOA OF DCLPESSOA */
                _.Display($"          CODIGO PESSOA.................  {PESSOA.DCLPESSOA.PESSOA_COD_PESSOA}");

                /*" -5653- DISPLAY '          NUMERO PROPOSTA...............  ' NUM-PROPOSTA-SIVPF OF DCLCONVERSAO-SICOB */
                _.Display($"          NUMERO PROPOSTA...............  {COVSICOB.DCLCONVERSAO_SICOB.NUM_PROPOSTA_SIVPF}");

                /*" -5655- DISPLAY '          NUMERO SICOB..................  ' NUM-SICOB OF DCLCONVERSAO-SICOB */
                _.Display($"          NUMERO SICOB..................  {COVSICOB.DCLCONVERSAO_SICOB.NUM_SICOB}");

                /*" -5657- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -5658- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -5659- PERFORM R9998-00-MONITOR. */

                R9998_00_MONITOR_SECTION();
            }


            /*" -5659- PERFORM R9999-00-FINALIZAR. */

            R9999_00_FINALIZAR_SECTION();

        }

        [StopWatch]
        /*" R3394-GERA-DE-PARA-NR-SICOB-DB-INSERT-1 */
        public void R3394_GERA_DE_PARA_NR_SICOB_DB_INSERT_1()
        {
            /*" -5644- EXEC SQL INSERT INTO SEGUROS.CONVERSAO_SICOB VALUES (:DCLCONVERSAO-SICOB.NUM-PROPOSTA-SIVPF, :DCLCONVERSAO-SICOB.NUM-SICOB, :DCLCONVERSAO-SICOB.COD-EMPRESA-SIVPF, :DCLCONVERSAO-SICOB.PRODUTO-SIVPF, :DCLCONVERSAO-SICOB.AGEPGTO, :DCLCONVERSAO-SICOB.DATA-OPERACAO, :DCLCONVERSAO-SICOB.DATA-QUITACAO, :DCLCONVERSAO-SICOB.VAL-RCAP, :DCLCONVERSAO-SICOB.COD-USUARIO, CURRENT TIMESTAMP) END-EXEC. */

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
        /*" R9988-00-FECHAR-ARQUIVOS-SECTION */
        private void R9988_00_FECHAR_ARQUIVOS_SECTION()
        {
            /*" -5668- CLOSE MOVTO-PRP-SASSE. */
            MOVTO_PRP_SASSE.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9988_SAIDA*/

        [StopWatch]
        /*" R9998-00-MONITOR-SECTION */
        private void R9998_00_MONITOR_SECTION()
        {
            /*" -5675- DISPLAY ' ' . */
            _.Display($" ");

            /*" -5675- MOVE ZEROS TO SII. */
            _.Move(0, WS_HORAS.SII);

            /*" -0- FLUXCONTROL_PERFORM M_1100_MOSTRA_TOTAIS */

            M_1100_MOSTRA_TOTAIS();

        }

        [StopWatch]
        /*" M-1100-MOSTRA-TOTAIS */
        private void M_1100_MOSTRA_TOTAIS(bool isPerform = false)
        {
            /*" -5678- ADD 1 TO SII. */
            WS_HORAS.SII.Value = WS_HORAS.SII + 1;

            /*" -5679- IF SII < 60 */

            if (WS_HORAS.SII < 60)
            {

                /*" -5680- MOVE STT(SII) TO STT-DISP */
                _.Move(TOTAIS_ROT.FILLER_22[WS_HORAS.SII].STT, WS_HORAS.STT_DISP);

                /*" -5682- DISPLAY 'PARAGRAFO:' SII ' TOTAL= ' STT-DISP ' QTDE= ' SQT(SII) */

                $"PARAGRAFO:{WS_HORAS.SII} TOTAL= {WS_HORAS.STT_DISP} QTDE= {TOTAIS_ROT.FILLER_22[WS_HORAS.SII]}"
                .Display();

                /*" -5683- GO TO M-1100-MOSTRA-TOTAIS. */
                new Task(() => M_1100_MOSTRA_TOTAIS()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


            /*" -5683- DISPLAY ' ' . */
            _.Display($" ");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9998_SAIDA*/

        [StopWatch]
        /*" R9999-00-FINALIZAR-SECTION */
        private void R9999_00_FINALIZAR_SECTION()
        {
            /*" -5694- DISPLAY ' ' */
            _.Display($" ");

            /*" -5695- IF W-FIM-MOVTO-VGAP = 'FIM' */

            if (WAREA_AUXILIAR.W_FIM_MOVTO_VGAP == "FIM")
            {

                /*" -5696- DISPLAY 'PF0612B - FIM NORMAL' */
                _.Display($"PF0612B - FIM NORMAL");

                /*" -5699- MOVE 0 TO RETURN-CODE */
                _.Move(0, RETURN_CODE);

                /*" -5700- MOVE 'COMMIT WORK' TO COMANDO */
                _.Move("COMMIT WORK", WABEND.LOCALIZA_ABEND_2.COMANDO);

                /*" -5700- EXEC SQL COMMIT WORK END-EXEC */

                DatabaseConnection.Instance.CommitTransaction();

                /*" -5702- ELSE */
            }
            else
            {


                /*" -5703- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, WABEND.FILLER_13.WSQLCODE);

                /*" -5704- MOVE SQLERRD(1) TO WSQLERRD1 */
                _.Move(DB.SQLERRD[1], WABEND.FILLER_13.WSQLERRD1);

                /*" -5705- MOVE SQLERRD(2) TO WSQLERRD2 */
                _.Move(DB.SQLERRD[2], WABEND.FILLER_13.WSQLERRD2);

                /*" -5706- DISPLAY WABEND */
                _.Display(WABEND);

                /*" -5707- DISPLAY '*** PF0612B *** ROLLBACK EM ANDAMENTO ...' */
                _.Display($"*** PF0612B *** ROLLBACK EM ANDAMENTO ...");

                /*" -5708- MOVE 'ROLLBACK WORK' TO COMANDO */
                _.Move("ROLLBACK WORK", WABEND.LOCALIZA_ABEND_2.COMANDO);

                /*" -5708- EXEC SQL ROLLBACK WORK END-EXEC */

                DatabaseConnection.Instance.RollbackTransaction();

                /*" -5711- MOVE 99 TO RETURN-CODE. */
                _.Move(99, RETURN_CODE);
            }


            /*" -5711- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9999_SAIDA*/
    }
}