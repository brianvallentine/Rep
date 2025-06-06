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
using Sias.VidaAzul.DB2.VA4002B;

namespace Code
{
    public class VA4002B
    {
        public bool IsCall { get; set; }

        public VA4002B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      ******************************************************************      */
        /*"      ******************************************************************      */
        /*"      *                                                                *      */
        /*"      *   FUNCAO .................  INTEGRAR V0PROPOSTAVA              *      */
        /*"      *                                                                *      */
        /*"      *   ANALISTA/PROGRAMADOR....  RIBAMAR MARQUES                    *      */
        /*"      *                                                                *      */
        /*"      *   PROGRAMA ...............  VA4002B                            *      */
        /*"      *                                                                *      */
        /*"      *   DATA ...................  19/12/2013                         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                     HISTORICO DE ALTERACOES                    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.19  *   VERSAO 19 - DEMANDA 402.982                                  *      */
        /*"      *             - SUBSTITUIR CONSULTA DA TABELA ERROS_PROP_VIDAZUL *      */
        /*"      *               PELA NA NOVA TABELA VG_CRITICA_PROPOSTA          *      */
        /*"      *                                                                *      */
        /*"      *   EM 14/02/2023 - ELIERMES OLIVEIRA                            *      */
        /*"      *                                        PROCURE POR V.19        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 18 - CIELO - ADEQUA�AO AO CAMPO NUM_CARTAO_CREDITO    *      */
        /*"      *               CAMPO NAO � MAIS NECESSARIO NESTE PROGRAMA .     *      */
        /*"      *               FOI RETIRADO DO CURSOR                           *      */
        /*"      *                                                                *      */
        /*"      *   EM 05/08/2019 - DANIEL MEDINA GOMIDE - MILLENIUM             *      */
        /*"      *                                                                *      */
        /*"      *                                            PROCURE POR V.18    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 17 - PROJETO CARTAO DE CREDITO CIELO                  *      */
        /*"      *             - AJUSTAR O PROGRAMA PARA EMISSAO DE SEGUROS QUE   *      */
        /*"      *               FORAM COMERCIALIZADOS NA ADESAO NO CARTAO DE     *      */
        /*"      *               CREDITO.                                         *      */
        /*"      *                                                                *      */
        /*"      *   EM 09/07/2019 - FRANK CARVALHO                               *      */
        /*"      *                                            PROCURE POR V.17    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 16 - ABEND 171.956                                    *      */
        /*"      *             - AJUSTAR O INSERT DA TABELA MOVIMENTO_VGAP PARA   *      */
        /*"      *               EVITAR ABEND'S NO PROGRAMA PF0605B.              *      */
        /*"      *                                                                *      */
        /*"      *   EM 01/02/2019 - FRANK CARVALHO                               *      */
        /*"      *                                            PROCURE POR V.16    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 15 - DEMANDA 178.460                                  *      */
        /*"      *             - AJUSTAR O TERMINO DE VIGENCIA DOS PRODUTOS PU, E *      */
        /*"      *               ADICIONADO A DATA DE QUITACAO DO SEGURO 36 MESES *      */
        /*"      *               FICA REGISTRADA NA TABELA APOLICE_COBERTURAS.    *      */
        /*"      *                                                                *      */
        /*"      *   EM 23/11/2018 - FRANK CARVALHO                               *      */
        /*"      *                                            PROCURE POR V.15    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 14 - HISTORIA 14130                                   *      */
        /*"      *             - AJUSTAR O INSERT NA TABELA DE MOVIMENTOS, POIS   *      */
        /*"      *               A PERIODICIDADE DE PAGAMENTO ESTAVA SENDO INSERI-*      */
        /*"      *               DA ERRADA.                                       *      */
        /*"      *                                                                *      */
        /*"      *   EM 14/03/2018 - CLAUDETE RADEL                               *      */
        /*"      *                                            PROCURE POR V.14    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 13 - CADMUS 154.956                                   *      */
        /*"      *             - DESCONSIDERAR MODALIDADE NA CONSULTA DE COBERTURA*      */
        /*"      *             - SELECIONAR MODALIDADE DA APOLICE A SER EMITIDA   *      */
        /*"      *               CHAMANDO SUBROTINA GE0510S.                      *      */
        /*"      *                                                                *      */
        /*"      *   EM 20/10/2017 - ELIERMES OLIVEIRA                            *      */
        /*"      *                                            PROCURE POR V.13    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 12 -          CAD 149.908                             *      */
        /*"      *                                                                *      */
        /*"      *          - INSERIR NA TABELA MOVIMENTO_VGAP PARA O PROGRAMA    *      */
        /*"      *            DE SENSIBILIZACAO CONSEGUIR GERAR O ARQUIVO COM     *      */
        /*"      *            CERTIFICADOS INTEGRADOS PELO PROGRAMA VA4002B.      *      */
        /*"      *                                                                *      */
        /*"      *      THIAGO BLAIER      V.12                                   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 11 -          CAD 136.573                             *      */
        /*"      *                                                                *      */
        /*"      *          - INTEGRAR TODOS OS CERTIFICADOS, INDEPENDENTE DO ERRO*      */
        /*"      *      QUE APRESENTAR, E GERAR UM RELATORIO PARA A BU PARA QUE   *      */
        /*"      *      ESSES CASOS SEJAM TRATADOS.                               *      */
        /*"      *                                                                *      */
        /*"      *      CLAUDETE RADEL     V.11                                   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 10 -          CAD 123.147                             *      */
        /*"      *                                                                *      */
        /*"      *          - AJUSTE NO PROGRAMA PARA NAO INTEGRAR AS PROPOSTAS   *      */
        /*"      *      COM ERROS DE DADOS CADASTRAIS. CONFORME CIRCULAR 445.     *      */
        /*"      *                                                                *      */
        /*"      *      FRANK CARVALHO     V.10                                   *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 09 -          CAD 117.464                             *      */
        /*"      *           PROPOSTAS EM CR�TICA A MAIS DE 15 DIAS - ADORMECIDAS *      */
        /*"      *                                                                *      */
        /*"      *          - AJUSTE NO PROGRAMA PARA CONSIDERAR A DATA DO SISTEMA       */
        /*"      *      E N�O CURRENT DATE PARA CALCULO DOS 15 DIAS ACEITE AUTOM�-*      */
        /*"      *      TICO DA PROPOSTA.                                         *      */
        /*"      *                                                                *      */
        /*"      *      MAURO ROCHA        V.09                                   *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 08 -          CAD 117.272                             *      */
        /*"      *               - NOVA SOLUCAO DE GESTAO DE DEPOSITOS            *      */
        /*"      *                                                                *      */
        /*"      *          - AJUSTE NO PROGRAMA PARA APOS A INTEGRACAO, ATUALIZAR*      */
        /*"      *      OS REGISTROS COM OPERACAO DE ADESAO E PENDENTES DE EXECU- *      */
        /*"      *      CAO NA TABELA MOVIMENTO_VGAP.                             *      */
        /*"      *                                                                *      */
        /*"      *      THIAGO BLAIER      V.08                                   *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 07 -   NSGD - CADMUS 103659.                          *      */
        /*"      *               - NOVA SOLUCAO DE GESTAO DE DEPOSITOS            *      */
        /*"      *                                                                *      */
        /*"      *   EM 19/11/2014 - COREON                                       *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.07         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 06                                                    *      */
        /*"      *             - CAD 98.156                                       *      */
        /*"      *               INSERIR DADOS NA V0COBERAPOL SE NAO EXISTIR      *      */
        /*"      *                                                                *      */
        /*"      *   EM 02/09/2014 - RIBAMAR MARQUES                              *      */
        /*"      *                                          PROCURE POR V.06      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 05                                                    *      */
        /*"      *             - CAD 98.156                                       *      */
        /*"      *               INSERIR SEGURADOS CASO NAO EXISTA PARA O CERTIF  *      */
        /*"      *                                                                *      */
        /*"      *   EM 12/08/2014 - ELIERMES OLIVERA                             *      */
        /*"      *                                          PROCURE POR V.05      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 04                                                    *      */
        /*"      *             - CAD 96.685                                              */
        /*"      *               SELECIONAR APENAS OS RCAPS QUE ESTEJAM C SITUACAO*      */
        /*"      *               DIFERENTE DE 210 = "DEVOLVIDA"                   *      */
        /*"      *                                                                *      */
        /*"      *   EM 22/07/2014 - ELIERMES OLIVERA                             *      */
        /*"      *                                          PROCURE POR V.04      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 03                                                    *      */
        /*"      *             - CAD 97.498                                              */
        /*"      *               CORRIGIR ABEND. O PROGRAMA INTEGROU PROPOSTAS    *      */
        /*"      *               COM CLIENTE 9999, OCASIONADO ERRO NA ROTINA      *      */
        /*"      *               MENSAL JPVAM21.                                         */
        /*"      *                                                                *      */
        /*"      *   EM 05/05/2014 - RIBAMAR MARQUES                              *      */
        /*"      *                                          PROCURE POR V.03      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 02                                                    *      */
        /*"      *             - CAD 88.560                                       *      */
        /*"      *               ALTERAR PROGRAMA PARA ATUALIZAR A DATA DO        *      */
        /*"      *               PROXIMO VENCIMENTO - DTPROXVEN                   *      */
        /*"      *                                                                *      */
        /*"      *   EM 16/04/2014 - RIBAMAR MARQUES                              *      */
        /*"      *                                          PROCURE POR V.02      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 01                                                    *      */
        /*"      *             - CAD 88.560                                       *      */
        /*"      *               ALTERACOES SOLICITADAS PELA BU:                  *      */
        /*"      *               INCLUIR AS PROPOSTAS COM SITUACAO 9 (AGUARDANDO  *      */
        /*"      *               PROPOSTA FISICA) NO FILTRO DO CURSOR PRINCIPAL.  *      */
        /*"      *                                                                *      */
        /*"      *                                                                *      */
        /*"      *   EM 08/04/2014 - RIBAMAR MARQUES                              *      */
        /*"      *                                          PROCURE POR V.01      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 00                                                    *      */
        /*"      *             - CAD 88.560                                       *      */
        /*"      *               VERSAO DO PROGRAMA VA0118B PARA INTEGRAR AS      *      */
        /*"      *               PROPOSTAS 'EM CRITICA' QUE ULTRAPASSARAM O       *      */
        /*"      *               PRAZO DE ACEITACAO - 'PROPOSTAS ADORMECIDAS'     *      */
        /*"      *                                                                *      */
        /*"      *                                                                *      */
        /*"      *   EM 19/12/2013 - RIBAMAR MARQUES                              *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        #endregion


        #region VARIABLES

        public FileBasis _ARQEMIT { get; set; } = new FileBasis(new PIC("X", "200", "X(200)"));

        public FileBasis ARQEMIT
        {
            get
            {
                _.Move(REG_ARQEMI, _ARQEMIT); VarBasis.RedefinePassValue(REG_ARQEMI, _ARQEMIT, REG_ARQEMI); return _ARQEMIT;
            }
        }
        /*"01   REG-ARQEMI          PIC X(200).*/
        public StringBasis REG_ARQEMI { get; set; } = new StringBasis(new PIC("X", "200", "X(200)."), @"");

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77  WIND                        PIC S9(04)  COMP  VALUE +0.*/
        public IntBasis WIND { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  WTEM-CLIENTES               PIC  X(01)  VALUE 'N'.*/
        public StringBasis WTEM_CLIENTES { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"N");
        /*"77  WTEM-SUBGRUPO               PIC  X(01)  VALUE 'N'.*/
        public StringBasis WTEM_SUBGRUPO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"N");
        /*"77  WTEM-SEGURADOS              PIC  X(01)  VALUE 'N'.*/
        public StringBasis WTEM_SEGURADOS { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"N");
        /*"77  WTEM-HIST-SEGURVGA          PIC  X(01)  VALUE 'N'.*/
        public StringBasis WTEM_HIST_SEGURVGA { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"N");
        /*"77  WTEM-APOLICOB               PIC  X(01)  VALUE 'N'.*/
        public StringBasis WTEM_APOLICOB { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"N");
        /*"77  WTEM-MOVIMENTO              PIC  X(01)  VALUE 'N'.*/
        public StringBasis WTEM_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"N");
        /*"77  WTEM-ERRO                   PIC  X(01)  VALUE 'N'.*/
        public StringBasis WTEM_ERRO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"N");
        /*"77  VIND-DATA-REF                PIC S9(4)    COMP.*/
        public IntBasis VIND_DATA_REF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"77  WDATA-AVERBACAO             PIC S9(004)  COMP.*/
        public IntBasis WDATA_AVERBACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WDATA-INCLUSAO              PIC S9(004)  COMP.*/
        public IntBasis WDATA_INCLUSAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WDATA-NASCIMENTO            PIC S9(004)  COMP.*/
        public IntBasis WDATA_NASCIMENTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WDATA-REFERENCIA            PIC S9(004)  COMP.*/
        public IntBasis WDATA_REFERENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  WS-AUX-ADORMECIDAS.*/
        public VA4002B_WS_AUX_ADORMECIDAS WS_AUX_ADORMECIDAS { get; set; } = new VA4002B_WS_AUX_ADORMECIDAS();
        public class VA4002B_WS_AUX_ADORMECIDAS : VarBasis
        {
            /*"    05 WS-COUNTERRO-OPC         PIC S9(009) COMP  VALUE +0.*/
            public IntBasis WS_COUNTERRO_OPC { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"    05 WS-COUNTRCAP             PIC S9(009) COMP  VALUE +0.*/
            public IntBasis WS_COUNTRCAP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"    05 WS-COUNT-HISTVGAP        PIC S9(009) COMP  VALUE +0.*/
            public IntBasis WS_COUNT_HISTVGAP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"    05 WS-COUNT-MOVIMENTO       PIC S9(009) COMP  VALUE +0.*/
            public IntBasis WS_COUNT_MOVIMENTO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"    05 WS-COUNT-APOLICOB        PIC S9(009) COMP  VALUE +0.*/
            public IntBasis WS_COUNT_APOLICOB { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"    05 WS-CANCELADO             PIC  9(009) VALUE ZEROES.*/
            public IntBasis WS_CANCELADO { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    05 WS-INTEGRADO             PIC  9(009) VALUE ZEROES.*/
            public IntBasis WS_INTEGRADO { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    05 WS-INTEGRADO-ERRO        PIC  9(009) VALUE ZEROES.*/
            public IntBasis WS_INTEGRADO_ERRO { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    05 WS-CRITICADO             PIC  9(009) VALUE ZEROES.*/
            public IntBasis WS_CRITICADO { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"01  WS-AUXILIARES.*/
        }
        public VA4002B_WS_AUXILIARES WS_AUXILIARES { get; set; } = new VA4002B_WS_AUXILIARES();
        public class VA4002B_WS_AUXILIARES : VarBasis
        {
            /*"    05 WHOST-VLPREMIO-W         PIC S9(013)V99 COMP-3 VALUE +0.*/
            public DoubleBasis WHOST_VLPREMIO_W { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 WHOST-VLPREMIO           PIC S9(013)V99 COMP-3 VALUE +0.*/
            public DoubleBasis WHOST_VLPREMIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 WHOST-NUM-ITEM           PIC S9(9)      COMP   VALUE +0.*/
            public IntBasis WHOST_NUM_ITEM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
            /*"    05 CALENDAR-DATA-CALENDARIO PIC  X(10).*/
            public StringBasis CALENDAR_DATA_CALENDARIO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"    05 WHOST-PROXIMA-DATA       PIC  X(10).*/
            public StringBasis WHOST_PROXIMA_DATA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"    05 WHOST-DATA-MOVIMENTO     PIC  X(10).*/
            public StringBasis WHOST_DATA_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"    05 WHOST-DATA-TERVIGENCIA   PIC  X(10).*/
            public StringBasis WHOST_DATA_TERVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"    05 W03-VENCIMENTO           PIC  X(10).*/
            public StringBasis W03_VENCIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"    05 CALENDAR-DIA-SEMANA      PIC  X(10).*/
            public StringBasis CALENDAR_DIA_SEMANA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"    05 CALENDAR-FERIADO         PIC  X(10).*/
            public StringBasis CALENDAR_FERIADO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"    05 WHOST-DTINIVIG           PIC  X(10).*/
            public StringBasis WHOST_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"    05 WHOST-SIT-PROP-FIDELIZ   PIC  X(03).*/
            public StringBasis WHOST_SIT_PROP_FIDELIZ { get; set; } = new StringBasis(new PIC("X", "3", "X(03)."), @"");
            /*"    05 WHOST-SITUACAO-ENVIO     PIC  X(01).*/
            public StringBasis WHOST_SITUACAO_ENVIO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    05 VIND-ANTECIP             PIC S9(4) COMP VALUE +0.*/
            public IntBasis VIND_ANTECIP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
            /*"    05 VIND-ORIGEM              PIC S9(4) COMP VALUE +0.*/
            public IntBasis VIND_ORIGEM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
            /*"    05 VIND-FAIXA-RENDA         PIC S9(4) COMP VALUE +0.*/
            public IntBasis VIND_FAIXA_RENDA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
            /*"    05 VIND-COD-CRM             PIC S9(4) COMP VALUE +0.*/
            public IntBasis VIND_COD_CRM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
            /*"    05 VIND-DTMOVTO             PIC S9(4) COMP VALUE +0.*/
            public IntBasis VIND_DTMOVTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
            /*"    05 VIND-DATSEL              PIC S9(4) COMP VALUE +0.*/
            public IntBasis VIND_DATSEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
            /*"    05 VIND-CODEMP              PIC S9(4) COMP VALUE +0.*/
            public IntBasis VIND_CODEMP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
            /*"    05 VIND-CODPRP              PIC S9(4) COMP VALUE +0.*/
            public IntBasis VIND_CODPRP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
            /*"    05 VIND-NUMBIL              PIC S9(4) COMP VALUE +0.*/
            public IntBasis VIND_NUMBIL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
            /*"    05 VIND-VLVARMON            PIC S9(4) COMP VALUE +0.*/
            public IntBasis VIND_VLVARMON { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
            /*"    05 VIND-DTQITBCO            PIC S9(4) COMP VALUE +0.*/
            public IntBasis VIND_DTQITBCO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
            /*"    05 VIND-ESTR-COBR           PIC S9(4) COMP VALUE +0.*/
            public IntBasis VIND_ESTR_COBR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
            /*"    05 VIND-ORIG-PRODU          PIC S9(4) COMP VALUE +0.*/
            public IntBasis VIND_ORIG_PRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
            /*"    05 VIND-TEM-SAF             PIC S9(4) COMP VALUE +0.*/
            public IntBasis VIND_TEM_SAF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
            /*"    05 VIND-TEM-CDG             PIC S9(4) COMP VALUE +0.*/
            public IntBasis VIND_TEM_CDG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
            /*"    05 VIND-AGENCIADOR          PIC S9(4) COMP VALUE +0.*/
            public IntBasis VIND_AGENCIADOR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
            /*"    05 VIND-CODRELAT            PIC S9(4) COMP VALUE +0.*/
            public IntBasis VIND_CODRELAT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
            /*"    05 VIND-CCCRE               PIC S9(4) COMP VALUE +0.*/
            public IntBasis VIND_CCCRE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
            /*"    05 INDAGE                   PIC S9(4) COMP.*/
            public IntBasis INDAGE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
            /*"    05 INDOPR                   PIC S9(4) COMP.*/
            public IntBasis INDOPR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
            /*"    05 INDNUM                   PIC S9(4) COMP.*/
            public IntBasis INDNUM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
            /*"    05 INDDIG                   PIC S9(4) COMP.*/
            public IntBasis INDDIG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
            /*"01  WS-AUXILIARES-HOST.*/
        }
        public VA4002B_WS_AUXILIARES_HOST WS_AUXILIARES_HOST { get; set; } = new VA4002B_WS_AUXILIARES_HOST();
        public class VA4002B_WS_AUXILIARES_HOST : VarBasis
        {
            /*"    05 WHOST-COUNT              PIC S9(4) COMP.*/
            public IntBasis WHOST_COUNT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
            /*"    05 VIND-DTENV               PIC S9(4) VALUE +0 COMP.*/
            public IntBasis VIND_DTENV { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
            /*"    05 VIND-DTRET               PIC S9(4) VALUE +0 COMP.*/
            public IntBasis VIND_DTRET { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
            /*"    05 VIND-CODRET              PIC S9(4) VALUE +0 COMP.*/
            public IntBasis VIND_CODRET { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
            /*"    05 VIND-NREQ                PIC S9(4) VALUE +0 COMP.*/
            public IntBasis VIND_NREQ { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
            /*"    05 VIND-SEQUEN              PIC S9(4) VALUE +0 COMP.*/
            public IntBasis VIND_SEQUEN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
            /*"    05 VIND-NLOTE               PIC S9(4) VALUE +0 COMP.*/
            public IntBasis VIND_NLOTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
            /*"    05 VIND-DTCRED              PIC S9(4) VALUE +0 COMP.*/
            public IntBasis VIND_DTCRED { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
            /*"    05 VIND-STATUS              PIC S9(4) VALUE +0 COMP.*/
            public IntBasis VIND_STATUS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
            /*"    05 VIND-VLCRED              PIC S9(4) VALUE +0 COMP.*/
            public IntBasis VIND_VLCRED { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
            /*"    05 DESCON-PERC              PIC S9(003)V9(04) COMP-3.*/
            public DoubleBasis DESCON_PERC { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(04)"), 4);
            /*"    05 DESCON-DTINIVIG          PIC  X(010).*/
            public StringBasis DESCON_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    05 DESCON-VLPREMIO          PIC S9(13)V99     COMP-3.*/
            public DoubleBasis DESCON_VLPREMIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"    05 DESCON-PRMVG             PIC S9(13)V99     COMP-3.*/
            public DoubleBasis DESCON_PRMVG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"    05 DESCON-PRMAP             PIC S9(13)V99     COMP-3.*/
            public DoubleBasis DESCON_PRMAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"    05 SIVPF-NR-PROPOSTA        PIC S9(15)        COMP-3.*/
            public IntBasis SIVPF_NR_PROPOSTA { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
            /*"    05 SIVPF-NR-SICOB           PIC S9(15)        COMP-3.*/
            public IntBasis SIVPF_NR_SICOB { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
            /*"    05 SIVPF-NR-IDENTIFI        PIC S9(15)        COMP-3.*/
            public IntBasis SIVPF_NR_IDENTIFI { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
            /*"    05 SIVPF-SIT-PROPOSTA       PIC  X(03).*/
            public StringBasis SIVPF_SIT_PROPOSTA { get; set; } = new StringBasis(new PIC("X", "3", "X(03)."), @"");
            /*"    05 SIVPF-DTQITBCO           PIC  X(10).*/
            public StringBasis SIVPF_DTQITBCO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"    05 SIVPF-DATA-CREDITO       PIC  X(10).*/
            public StringBasis SIVPF_DATA_CREDITO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"    05 SIVPF-VAL-PAGO           PIC S9(13)V99     COMP-3.*/
            public DoubleBasis SIVPF_VAL_PAGO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"    05 SIVPF-OPCAO-COBER        PIC  X(01).*/
            public StringBasis SIVPF_OPCAO_COBER { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    05 SIVPF-COD-PLANO          PIC S9(04)        COMP.*/
            public IntBasis SIVPF_COD_PLANO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"    05 CONVER-NUM-SICOB         PIC S9(15)        COMP-3.*/
            public IntBasis CONVER_NUM_SICOB { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
            /*"    05 CONVER-NUM-PROPOSTA      PIC S9(15)        COMP-3.*/
            public IntBasis CONVER_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
            /*"    05 V0PARC-NRCERTIF          PIC S9(15)        COMP-3.*/
            public IntBasis V0PARC_NRCERTIF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
            /*"    05 PROPVA-NRCERTIF          PIC S9(15)        COMP-3.*/
            public IntBasis PROPVA_NRCERTIF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
            /*"    05 PROPVA-NRPROPAZ          PIC S9(13)        COMP-3.*/
            public IntBasis PROPVA_NRPROPAZ { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
            /*"    05 PROPVA-CODPRODU          PIC S9(04)        COMP.*/
            public IntBasis PROPVA_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"    05 PROPVA-CODCLIEN          PIC S9(09)        COMP.*/
            public IntBasis PROPVA_CODCLIEN { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
            /*"    05 PROPVA-OCOREND           PIC S9(04)        COMP.*/
            public IntBasis PROPVA_OCOREND { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"    05 PROPVA-FONTE             PIC S9(4)         COMP.*/
            public IntBasis PROPVA_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
            /*"    05 PROPVA-AGECOBR           PIC S9(4)         COMP.*/
            public IntBasis PROPVA_AGECOBR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
            /*"    05 PROPVA-OPCAO-COBER       PIC  X(1).*/
            public StringBasis PROPVA_OPCAO_COBER { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
            /*"    05 PROPVA-DTQITBCO          PIC  X(10).*/
            public StringBasis PROPVA_DTQITBCO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"    05 PROPVA-DT365DIAS         PIC  X(10).*/
            public StringBasis PROPVA_DT365DIAS { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"    05 PROPVA-DT015DIAS         PIC  X(10).*/
            public StringBasis PROPVA_DT015DIAS { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"    05 PROPVA-DTINICDG          PIC  X(10).*/
            public StringBasis PROPVA_DTINICDG { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"    05 PROPVA-DTINISAF          PIC  X(10).*/
            public StringBasis PROPVA_DTINISAF { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"    05 PROPVA-NRMATRVEN         PIC S9(15)        COMP-3.*/
            public IntBasis PROPVA_NRMATRVEN { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
            /*"    05 PROPVA-CODOPER           PIC S9(4)         COMP.*/
            public IntBasis PROPVA_CODOPER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
            /*"    05 DIFPAR-CODOPER           PIC S9(4)         COMP.*/
            public IntBasis DIFPAR_CODOPER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
            /*"    05 PROPVA-DTINCLUS          PIC  X(10).*/
            public StringBasis PROPVA_DTINCLUS { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"    05 PROPVA-DTMOVTO           PIC  X(10).*/
            public StringBasis PROPVA_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"    05 PROPVA-DTPROXVEN         PIC  X(10).*/
            public StringBasis PROPVA_DTPROXVEN { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"    05 PROPVA-DTPROXVEN-S       PIC  X(10).*/
            public StringBasis PROPVA_DTPROXVEN_S { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"    05 PROPVA-DTVENCTO          PIC  X(10).*/
            public StringBasis PROPVA_DTVENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"    05 PROPVA-DTMINVEN          PIC  X(10).*/
            public StringBasis PROPVA_DTMINVEN { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"    05 PROPVA-SITUACAO          PIC  X(1).*/
            public StringBasis PROPVA_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
            /*"    05 PROPVA-NUM-APOLICE       PIC S9(13)        COMP-3.*/
            public IntBasis PROPVA_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
            /*"    05 PROPVA-CODSUBES          PIC S9(4)         COMP.*/
            public IntBasis PROPVA_CODSUBES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
            /*"    05 PROPVA-OCORHIST          PIC S9(4)         COMP.*/
            public IntBasis PROPVA_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
            /*"    05 PROPVA-NRPARCEL          PIC S9(4)         COMP.*/
            public IntBasis PROPVA_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
            /*"    05 PROPVA-SIT-INTERF        PIC  X(1).*/
            public StringBasis PROPVA_SIT_INTERF { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
            /*"    05 PROPVA-TIMESTAMP         PIC  X(26).*/
            public StringBasis PROPVA_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
            /*"    05 PROPVA-IDADE             PIC S9(4)         COMP.*/
            public IntBasis PROPVA_IDADE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
            /*"    05 PROPVA-SEXO              PIC  X(1).*/
            public StringBasis PROPVA_SEXO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
            /*"    05 PROPVA-EST-CIV           PIC  X(1).*/
            public StringBasis PROPVA_EST_CIV { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
            /*"    05 PROPVA-COD-CRM           PIC S9(4)         COMP.*/
            public IntBasis PROPVA_COD_CRM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
            /*"    05 PROPVA-NRMATRFUN         PIC S9(15)        COMP-3.*/
            public IntBasis PROPVA_NRMATRFUN { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
            /*"    05 PROPVA-INRMATRFUN        PIC S9(4)         COMP.*/
            public IntBasis PROPVA_INRMATRFUN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
            /*"    05 PROPVA-NRPROPOS          PIC S9(09)        COMP.*/
            public IntBasis PROPVA_NRPROPOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
            /*"    05 PROPVA-INRPROPOS         PIC S9(04)        COMP.*/
            public IntBasis PROPVA_INRPROPOS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"    05 PROPVA-DTADMIS           PIC  X(10) VALUE SPACES.*/
            public StringBasis PROPVA_DTADMIS { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
            /*"    05 PROPVA-IDTADMIS          PIC S9(04) COMP VALUE +0.*/
            public IntBasis PROPVA_IDTADMIS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"    05 WPROPVA-DTADMIS          PIC  X(10).*/
            public StringBasis WPROPVA_DTADMIS { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"    05 WPROPVA-IDTADMIS         PIC S9(04).*/
            public IntBasis WPROPVA_IDTADMIS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)."));
            /*"    05 PROPVA-CODCCT            PIC S9(15) COMP-3.*/
            public IntBasis PROPVA_CODCCT { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
            /*"    05 PROPVA-ICODCCT           PIC S9(4)  COMP.*/
            public IntBasis PROPVA_ICODCCT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
            /*"    05 PROPVA-CODUSU            PIC  X(8).*/
            public StringBasis PROPVA_CODUSU { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
            /*"    05 PROPVA-FAIXA-RENDA-IND   PIC  X(1).*/
            public StringBasis PROPVA_FAIXA_RENDA_IND { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
            /*"    05 PROPVA-DATA              PIC  X(10).*/
            public StringBasis PROPVA_DATA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"    05 PROPVA-DPS-TITULAR       PIC  X(30).*/
            public StringBasis PROPVA_DPS_TITULAR { get; set; } = new StringBasis(new PIC("X", "30", "X(30)."), @"");
            /*"    05 PROPVA-ORIGEM-PROPOSTA   PIC S9(04) COMP.*/
            public IntBasis PROPVA_ORIGEM_PROPOSTA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"    05 PROPVA-STA-ANTECIPACAO   PIC X(1).*/
            public StringBasis PROPVA_STA_ANTECIPACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
            /*"    05 PRODVG-CODPRODAZ         PIC  X(03).*/
            public StringBasis PRODVG_CODPRODAZ { get; set; } = new StringBasis(new PIC("X", "3", "X(03)."), @"");
            /*"    05 PRODVG-PERIPGTO          PIC S9(04) COMP.*/
            public IntBasis PRODVG_PERIPGTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"    05 PRODVG-ESTR-COBR         PIC  X(10).*/
            public StringBasis PRODVG_ESTR_COBR { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"    05 PRODVG-ORIG-PRODU        PIC  X(10).*/
            public StringBasis PRODVG_ORIG_PRODU { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"    05 PRODVG-AGENCIADOR        PIC S9(9)  COMP.*/
            public IntBasis PRODVG_AGENCIADOR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
            /*"    05 PRODVG-TEM-SAF           PIC  X(1).*/
            public StringBasis PRODVG_TEM_SAF { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
            /*"    05 PRODVG-TEM-CDG           PIC  X(1).*/
            public StringBasis PRODVG_TEM_CDG { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
            /*"    05 PRODVG-CODRELAT          PIC  X(8).*/
            public StringBasis PRODVG_CODRELAT { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
            /*"    05 PRODVG-RISCO             PIC  X(1).*/
            public StringBasis PRODVG_RISCO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
            /*"    05 PRODVG-COBERADIC-PREMIO  PIC  X(1).*/
            public StringBasis PRODVG_COBERADIC_PREMIO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
            /*"    05 PRODVG-DESCONTO-ADESAO   PIC S9(003)V9(05) COMP-3.*/
            public DoubleBasis PRODVG_DESCONTO_ADESAO { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(05)"), 5);
            /*"    05 PRODVG-SITPLANCEF        PIC  X(001).*/
            public StringBasis PRODVG_SITPLANCEF { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    05 PRODVG-COD-PRODUTO       PIC S9(04) COMP.*/
            public IntBasis PRODVG_COD_PRODUTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"    05 PRODVG-ARQ-FDCAP         PIC S9(04) COMP.*/
            public IntBasis PRODVG_ARQ_FDCAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"    05 WS-IND-ARQFDCAP          PIC S9(04) COMP.*/
            public IntBasis WS_IND_ARQFDCAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"    05 PRODVG-COD-RUBRICA       PIC S9(04) COMP.*/
            public IntBasis PRODVG_COD_RUBRICA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"    05 WS-IND-RUBRICA           PIC S9(04) COMP.*/
            public IntBasis WS_IND_RUBRICA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"    05 WS-ATUALIZA-OPCPAGVA     PIC X(003) VALUE SPACES.*/
            public StringBasis WS_ATUALIZA_OPCPAGVA { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"    05 PRODVG-CUSTOCAP-TOTAL    PIC  X(001).*/
            public StringBasis PRODVG_CUSTOCAP_TOTAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    05 PRODVG-CUSTOCAP-TOTAL-9  PIC  9(001).*/
            public IntBasis PRODVG_CUSTOCAP_TOTAL_9 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"    05 OPCAOP-OPCAOPAG          PIC  X(1).*/
            public StringBasis OPCAOP_OPCAOPAG { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
            /*"    05 OPCAOP-PERIPGTO          PIC S9(4) COMP.*/
            public IntBasis OPCAOP_PERIPGTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
            /*"    05 OPCAOP-DIA-DEB           PIC S9(4) COMP.*/
            public IntBasis OPCAOP_DIA_DEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
            /*"    05 OPCAOP-AGECTADEB         PIC S9(4) COMP.*/
            public IntBasis OPCAOP_AGECTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
            /*"    05 OPCAOP-OPRCTADEB         PIC S9(4) COMP.*/
            public IntBasis OPCAOP_OPRCTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
            /*"    05 OPCAOP-NUMCTADEB         PIC S9(13) COMP-3.*/
            public IntBasis OPCAOP_NUMCTADEB { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
            /*"    05 OPCAOP-DIGCTADEB         PIC S9(4) COMP.*/
            public IntBasis OPCAOP_DIGCTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
            /*"    05 V0AGCEF-COD-AGCOBR       PIC S9(4) COMP.*/
            public IntBasis V0AGCEF_COD_AGCOBR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
            /*"    05 COBERP-DTINIVIG          PIC  X(10).*/
            public StringBasis COBERP_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"    05 COBERP-DTTERVIG          PIC  X(10).*/
            public StringBasis COBERP_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"    05 COBERP-IMPMORNATU        PIC S9(13)V99 COMP-3.*/
            public DoubleBasis COBERP_IMPMORNATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"    05 COBERP-IMPMORACID        PIC S9(13)V99 COMP-3.*/
            public DoubleBasis COBERP_IMPMORACID { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"    05 COBERP-IMPINVPERM        PIC S9(13)V99 COMP-3.*/
            public DoubleBasis COBERP_IMPINVPERM { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"    05 COBERP-IMPAMDS           PIC S9(13)V99 COMP-3.*/
            public DoubleBasis COBERP_IMPAMDS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"    05 COBERP-IMPDH             PIC S9(13)V99 COMP-3.*/
            public DoubleBasis COBERP_IMPDH { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"    05 COBERP-IMPDIT            PIC S9(13)V99 COMP-3.*/
            public DoubleBasis COBERP_IMPDIT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"    05 COBERP-VLPREMIO          PIC S9(13)V99 COMP-3.*/
            public DoubleBasis COBERP_VLPREMIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"    05 COBERP-PRMVG             PIC S9(13)V99 COMP-3.*/
            public DoubleBasis COBERP_PRMVG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"    05 COBERP-PRMAP             PIC S9(13)V99 COMP-3.*/
            public DoubleBasis COBERP_PRMAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"    05 COBERP-PRMVG-DIF         PIC S9(13)V99 COMP-3.*/
            public DoubleBasis COBERP_PRMVG_DIF { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"    05 COBERP-PRMAP-DIF         PIC S9(13)V99 COMP-3.*/
            public DoubleBasis COBERP_PRMAP_DIF { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"    05 DIFPAR-PRMVG             PIC S9(13)V99 COMP-3.*/
            public DoubleBasis DIFPAR_PRMVG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"    05 COBERP-VLCUSTCAP         PIC S9(13)V99 COMP-3.*/
            public DoubleBasis COBERP_VLCUSTCAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"    05 COBERP-IMPSEGCDG         PIC S9(13)V99 COMP-3.*/
            public DoubleBasis COBERP_IMPSEGCDG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"    05 COBERP-VLCUSTCDG         PIC S9(13)V99 COMP-3.*/
            public DoubleBasis COBERP_VLCUSTCDG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"    05 COBERP-IMPSEGAUXF        PIC S9(13)V99 COMP-3.*/
            public DoubleBasis COBERP_IMPSEGAUXF { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"    05 COBERP-VLCUSTAUXF        PIC S9(13)V99 COMP-3.*/
            public DoubleBasis COBERP_VLCUSTAUXF { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"    05 COBERP-IIMPSEGAUXF       PIC S9(04)    COMP.*/
            public IntBasis COBERP_IIMPSEGAUXF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"    05 COBERP-IVLCUSTAUXF       PIC S9(04)    COMP.*/
            public IntBasis COBERP_IVLCUSTAUXF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"    05 COBERP-QTTITCAP          PIC S9(04)    COMP.*/
            public IntBasis COBERP_QTTITCAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"    05 COBERP-IQTTITCAP         PIC S9(04)    COMP.*/
            public IntBasis COBERP_IQTTITCAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"    05 V0COBER-MINOCOR          PIC S9(04)    COMP.*/
            public IntBasis V0COBER_MINOCOR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"    05 COMISI-VALADT            PIC S9(13)V99 COMP-3.*/
            public DoubleBasis COMISI_VALADT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"    05 PARCOM-TIPCOM            PIC  X(01).*/
            public StringBasis PARCOM_TIPCOM { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    05 FUNDO-PCCOMCOR           PIC S9(03)V99 COMP-3.*/
            public DoubleBasis FUNDO_PCCOMCOR { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(03)V99"), 2);
            /*"    05 V1RIND-PCIOF             PIC S9(03)V99 COMP-3.*/
            public DoubleBasis V1RIND_PCIOF { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(03)V99"), 2);
            /*"    05 V1RIND-DTINIVIG          PIC  X(10).*/
            public StringBasis V1RIND_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"    05 V1APOL-RAMO              PIC S9(04)    COMP.*/
            public IntBasis V1APOL_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"    05 FUNDO-PCCOMIND           PIC S9(03)V99 COMP-3.*/
            public DoubleBasis FUNDO_PCCOMIND { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(03)V99"), 2);
            /*"    05 FUNDO-PCCOMGER           PIC S9(03)V99 COMP-3.*/
            public DoubleBasis FUNDO_PCCOMGER { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(03)V99"), 2);
            /*"    05 FUNDO-PCCOMSUP           PIC S9(03)V99 COMP-3.*/
            public DoubleBasis FUNDO_PCCOMSUP { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(03)V99"), 2);
            /*"    05 FUNDO-PCCOMTOT           PIC S9(03)V99 COMP-3.*/
            public DoubleBasis FUNDO_PCCOMTOT { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(03)V99"), 2);
            /*"    05 FUNDO-VALBASVG           PIC S9(13)V99 COMP-3.*/
            public DoubleBasis FUNDO_VALBASVG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"    05 FUNDO-VALBASAP           PIC S9(13)V99 COMP-3.*/
            public DoubleBasis FUNDO_VALBASAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"    05 FUNDO-VLCOMISVG          PIC S9(13)V99 COMP-3.*/
            public DoubleBasis FUNDO_VLCOMISVG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"    05 FUNDO-VLCOMISAP          PIC S9(13)V99 COMP-3.*/
            public DoubleBasis FUNDO_VLCOMISAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"    05 HISCOBPR-IMP-MORNATU     PIC S9(13)V99 COMP-3.*/
            public DoubleBasis HISCOBPR_IMP_MORNATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"    05 HISCOBPR-IMPMORACID      PIC S9(13)V99 COMP-3.*/
            public DoubleBasis HISCOBPR_IMPMORACID { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"    05 HISCOBPR-IMPINVPERM      PIC S9(13)V99 COMP-3.*/
            public DoubleBasis HISCOBPR_IMPINVPERM { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"    05 HISCOBPR-IMPAMDS         PIC S9(13)V99 COMP-3.*/
            public DoubleBasis HISCOBPR_IMPAMDS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"    05 HISCOBPR-IMPDH           PIC S9(13)V99 COMP-3.*/
            public DoubleBasis HISCOBPR_IMPDH { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"    05 HISCOBPR-IMPDIT          PIC S9(13)V99 COMP-3.*/
            public DoubleBasis HISCOBPR_IMPDIT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"    05 HISCOBPR-VLPREMIO        PIC S9(13)V99 COMP-3.*/
            public DoubleBasis HISCOBPR_VLPREMIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"    05 HISCOBPR-PRMVG           PIC S9(13)V99 COMP-3.*/
            public DoubleBasis HISCOBPR_PRMVG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"    05 HISCOBPR-PRMAP           PIC S9(13)V99 COMP-3.*/
            public DoubleBasis HISCOBPR_PRMAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"    05 CLIENT-DTNASC            PIC  X(10).*/
            public StringBasis CLIENT_DTNASC { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"    05 CLIENT-DTNASC-I          PIC S9(04) COMP.*/
            public IntBasis CLIENT_DTNASC_I { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"    05 CLIENT-CGCCPF            PIC S9(15) COMP-3.*/
            public IntBasis CLIENT_CGCCPF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
            /*"    05 CDGCOB-DTINIVIG          PIC  X(010).*/
            public StringBasis CDGCOB_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    05 SAFCOB-DTINIVIG          PIC  X(010).*/
            public StringBasis SAFCOB_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    05 REPCDG-DTREF             PIC  X(010).*/
            public StringBasis REPCDG_DTREF { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    05 REPSAF-DTREF             PIC  X(010).*/
            public StringBasis REPSAF_DTREF { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"01  RELATO-CODRELAT             PIC  X(008).*/
        }
        public StringBasis RELATO_CODRELAT { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"01  RELATO-NRPARCEL             PIC S9(004) COMP VALUE +0.*/
        public IntBasis RELATO_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  RELATO-OPERACAO             PIC S9(004) COMP VALUE +0.*/
        public IntBasis RELATO_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  RELATO-NUM-APOLICE          PIC S9(13)  COMP-3.*/
        public IntBasis RELATO_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"01  RELATO-CODSUBES             PIC S9(4)   COMP.*/
        public IntBasis RELATO_CODSUBES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  CLIROT-DTMOVABE             PIC  X(010).*/
        public StringBasis CLIROT_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  FONTE-PROPAUTOM             PIC S9(009) COMP.*/
        public IntBasis FONTE_PROPAUTOM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01  APCORR-RAMO                 PIC S9(004) COMP.*/
        public IntBasis APCORR_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  APCORR-DTINIVIG             PIC  X(010).*/
        public StringBasis APCORR_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  SUBGRU-CODSUBES             PIC S9(004) COMP.*/
        public IntBasis SUBGRU_CODSUBES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  WSISTEMA-DTMOVABE           PIC  X(010).*/
        public StringBasis WSISTEMA_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  SISTEMA-DTMOVABE            PIC  X(010).*/
        public StringBasis SISTEMA_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  SISTEMA-CURRDATE            PIC  X(010).*/
        public StringBasis SISTEMA_CURRDATE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  SISTEMA-CURRDATE-RD REDEFINES SISTEMA-CURRDATE.*/
        private _REDEF_VA4002B_SISTEMA_CURRDATE_RD _sistema_currdate_rd { get; set; }
        public _REDEF_VA4002B_SISTEMA_CURRDATE_RD SISTEMA_CURRDATE_RD
        {
            get { _sistema_currdate_rd = new _REDEF_VA4002B_SISTEMA_CURRDATE_RD(); _.Move(SISTEMA_CURRDATE, _sistema_currdate_rd); VarBasis.RedefinePassValue(SISTEMA_CURRDATE, _sistema_currdate_rd, SISTEMA_CURRDATE); _sistema_currdate_rd.ValueChanged += () => { _.Move(_sistema_currdate_rd, SISTEMA_CURRDATE); }; return _sistema_currdate_rd; }
            set { VarBasis.RedefinePassValue(value, _sistema_currdate_rd, SISTEMA_CURRDATE); }
        }  //Redefines
        public class _REDEF_VA4002B_SISTEMA_CURRDATE_RD : VarBasis
        {
            /*"    05 WCURR-DATE-AA            PIC  9(004).*/
            public IntBasis WCURR_DATE_AA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    05 FILLER                   PIC  X.*/
            public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "1", "X."), @"");
            /*"    05 WCURR-DATE-MM            PIC  9(002).*/
            public IntBasis WCURR_DATE_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"    05 FILLER                   PIC  X.*/
            public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X."), @"");
            /*"    05 WCURR-DATE-DD            PIC  9(002).*/
            public IntBasis WCURR_DATE_DD { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"01  SISTEMA-CURRDATE-8          PIC  9(008).*/

            public _REDEF_VA4002B_SISTEMA_CURRDATE_RD()
            {
                WCURR_DATE_AA.ValueChanged += OnValueChanged;
                FILLER_0.ValueChanged += OnValueChanged;
                WCURR_DATE_MM.ValueChanged += OnValueChanged;
                FILLER_1.ValueChanged += OnValueChanged;
                WCURR_DATE_DD.ValueChanged += OnValueChanged;
            }

        }
        public IntBasis SISTEMA_CURRDATE_8 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
        /*"01  SISTEMA-CURRDATE8-RD REDEFINES SISTEMA-CURRDATE-8.*/
        private _REDEF_VA4002B_SISTEMA_CURRDATE8_RD _sistema_currdate8_rd { get; set; }
        public _REDEF_VA4002B_SISTEMA_CURRDATE8_RD SISTEMA_CURRDATE8_RD
        {
            get { _sistema_currdate8_rd = new _REDEF_VA4002B_SISTEMA_CURRDATE8_RD(); _.Move(SISTEMA_CURRDATE_8, _sistema_currdate8_rd); VarBasis.RedefinePassValue(SISTEMA_CURRDATE_8, _sistema_currdate8_rd, SISTEMA_CURRDATE_8); _sistema_currdate8_rd.ValueChanged += () => { _.Move(_sistema_currdate8_rd, SISTEMA_CURRDATE_8); }; return _sistema_currdate8_rd; }
            set { VarBasis.RedefinePassValue(value, _sistema_currdate8_rd, SISTEMA_CURRDATE_8); }
        }  //Redefines
        public class _REDEF_VA4002B_SISTEMA_CURRDATE8_RD : VarBasis
        {
            /*"    05 WCURR-DATE8-AA           PIC  9(004).*/
            public IntBasis WCURR_DATE8_AA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    05 WCURR-DATE8-MM           PIC  9(002).*/
            public IntBasis WCURR_DATE8_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"    05 WCURR-DATE8-DD           PIC  9(002).*/
            public IntBasis WCURR_DATE8_DD { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"01  CURRDATE-DIAS               PIC  9(009).*/

            public _REDEF_VA4002B_SISTEMA_CURRDATE8_RD()
            {
                WCURR_DATE8_AA.ValueChanged += OnValueChanged;
                WCURR_DATE8_MM.ValueChanged += OnValueChanged;
                WCURR_DATE8_DD.ValueChanged += OnValueChanged;
            }

        }
        public IntBasis CURRDATE_DIAS { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
        /*"01  SISTEMA-DTMOVABE2           PIC  X(010).*/
        public StringBasis SISTEMA_DTMOVABE2 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  SISTEMA-DTMOVABE3           PIC  X(010).*/
        public StringBasis SISTEMA_DTMOVABE3 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  SISTEMA-DTMOV015D           PIC  X(010).*/
        public StringBasis SISTEMA_DTMOV015D { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  SISTEMA-DTMOV365D           PIC  X(010).*/
        public StringBasis SISTEMA_DTMOV365D { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  QUITACAO-DATE               PIC  X(010).*/
        public StringBasis QUITACAO_DATE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  QUITACAO-DATE-RD REDEFINES QUITACAO-DATE.*/
        private _REDEF_VA4002B_QUITACAO_DATE_RD _quitacao_date_rd { get; set; }
        public _REDEF_VA4002B_QUITACAO_DATE_RD QUITACAO_DATE_RD
        {
            get { _quitacao_date_rd = new _REDEF_VA4002B_QUITACAO_DATE_RD(); _.Move(QUITACAO_DATE, _quitacao_date_rd); VarBasis.RedefinePassValue(QUITACAO_DATE, _quitacao_date_rd, QUITACAO_DATE); _quitacao_date_rd.ValueChanged += () => { _.Move(_quitacao_date_rd, QUITACAO_DATE); }; return _quitacao_date_rd; }
            set { VarBasis.RedefinePassValue(value, _quitacao_date_rd, QUITACAO_DATE); }
        }  //Redefines
        public class _REDEF_VA4002B_QUITACAO_DATE_RD : VarBasis
        {
            /*"    05 WDTQUIT-AA               PIC  9(004).*/
            public IntBasis WDTQUIT_AA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    05 FILLER                   PIC  X.*/
            public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X."), @"");
            /*"    05 WDTQUIT-MM               PIC  9(002).*/
            public IntBasis WDTQUIT_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"    05 FILLER                   PIC  X.*/
            public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X."), @"");
            /*"    05 WDTQUIT-DD               PIC  9(002).*/
            public IntBasis WDTQUIT_DD { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"01  QUITACAO-DATE-8             PIC  9(008).*/

            public _REDEF_VA4002B_QUITACAO_DATE_RD()
            {
                WDTQUIT_AA.ValueChanged += OnValueChanged;
                FILLER_2.ValueChanged += OnValueChanged;
                WDTQUIT_MM.ValueChanged += OnValueChanged;
                FILLER_3.ValueChanged += OnValueChanged;
                WDTQUIT_DD.ValueChanged += OnValueChanged;
            }

        }
        public IntBasis QUITACAO_DATE_8 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
        /*"01  QUITACAO-DATE8-RD REDEFINES QUITACAO-DATE-8.*/
        private _REDEF_VA4002B_QUITACAO_DATE8_RD _quitacao_date8_rd { get; set; }
        public _REDEF_VA4002B_QUITACAO_DATE8_RD QUITACAO_DATE8_RD
        {
            get { _quitacao_date8_rd = new _REDEF_VA4002B_QUITACAO_DATE8_RD(); _.Move(QUITACAO_DATE_8, _quitacao_date8_rd); VarBasis.RedefinePassValue(QUITACAO_DATE_8, _quitacao_date8_rd, QUITACAO_DATE_8); _quitacao_date8_rd.ValueChanged += () => { _.Move(_quitacao_date8_rd, QUITACAO_DATE_8); }; return _quitacao_date8_rd; }
            set { VarBasis.RedefinePassValue(value, _quitacao_date8_rd, QUITACAO_DATE_8); }
        }  //Redefines
        public class _REDEF_VA4002B_QUITACAO_DATE8_RD : VarBasis
        {
            /*"    05 WDTQUIT8-AA              PIC  9(004).*/
            public IntBasis WDTQUIT8_AA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    05 WDTQUIT8-MM              PIC  9(002).*/
            public IntBasis WDTQUIT8_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"    05 WDTQUIT8-DD              PIC  9(002).*/
            public IntBasis WDTQUIT8_DD { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"01  QUITACAO-DIAS               PIC  9(009).*/

            public _REDEF_VA4002B_QUITACAO_DATE8_RD()
            {
                WDTQUIT8_AA.ValueChanged += OnValueChanged;
                WDTQUIT8_MM.ValueChanged += OnValueChanged;
                WDTQUIT8_DD.ValueChanged += OnValueChanged;
            }

        }
        public IntBasis QUITACAO_DIAS { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
        /*"01  PRAZO-DIAS                  PIC  9(009).*/
        public IntBasis PRAZO_DIAS { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
        /*"01  PROXVEN-DATE                PIC  X(010).*/
        public StringBasis PROXVEN_DATE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  PROXVEN-DATE-RD REDEFINES PROXVEN-DATE.*/
        private _REDEF_VA4002B_PROXVEN_DATE_RD _proxven_date_rd { get; set; }
        public _REDEF_VA4002B_PROXVEN_DATE_RD PROXVEN_DATE_RD
        {
            get { _proxven_date_rd = new _REDEF_VA4002B_PROXVEN_DATE_RD(); _.Move(PROXVEN_DATE, _proxven_date_rd); VarBasis.RedefinePassValue(PROXVEN_DATE, _proxven_date_rd, PROXVEN_DATE); _proxven_date_rd.ValueChanged += () => { _.Move(_proxven_date_rd, PROXVEN_DATE); }; return _proxven_date_rd; }
            set { VarBasis.RedefinePassValue(value, _proxven_date_rd, PROXVEN_DATE); }
        }  //Redefines
        public class _REDEF_VA4002B_PROXVEN_DATE_RD : VarBasis
        {
            /*"    05 WPRXVEN-AA               PIC  9(004).*/
            public IntBasis WPRXVEN_AA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    05 FILLER                   PIC  X.*/
            public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "1", "X."), @"");
            /*"    05 WPRXVEN-MM               PIC  9(002).*/
            public IntBasis WPRXVEN_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"    05 FILLER                   PIC  X.*/
            public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "1", "X."), @"");
            /*"    05 WPRXVEN-DD               PIC  9(002).*/
            public IntBasis WPRXVEN_DD { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"01  PROXVEN-DATE8               PIC  9(008).*/

            public _REDEF_VA4002B_PROXVEN_DATE_RD()
            {
                WPRXVEN_AA.ValueChanged += OnValueChanged;
                FILLER_4.ValueChanged += OnValueChanged;
                WPRXVEN_MM.ValueChanged += OnValueChanged;
                FILLER_5.ValueChanged += OnValueChanged;
                WPRXVEN_DD.ValueChanged += OnValueChanged;
            }

        }
        public IntBasis PROXVEN_DATE8 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
        /*"01  PROXVEN-DATE8-RD REDEFINES PROXVEN-DATE8.*/
        private _REDEF_VA4002B_PROXVEN_DATE8_RD _proxven_date8_rd { get; set; }
        public _REDEF_VA4002B_PROXVEN_DATE8_RD PROXVEN_DATE8_RD
        {
            get { _proxven_date8_rd = new _REDEF_VA4002B_PROXVEN_DATE8_RD(); _.Move(PROXVEN_DATE8, _proxven_date8_rd); VarBasis.RedefinePassValue(PROXVEN_DATE8, _proxven_date8_rd, PROXVEN_DATE8); _proxven_date8_rd.ValueChanged += () => { _.Move(_proxven_date8_rd, PROXVEN_DATE8); }; return _proxven_date8_rd; }
            set { VarBasis.RedefinePassValue(value, _proxven_date8_rd, PROXVEN_DATE8); }
        }  //Redefines
        public class _REDEF_VA4002B_PROXVEN_DATE8_RD : VarBasis
        {
            /*"    05 WPRXVEN8-AA              PIC  9(004).*/
            public IntBasis WPRXVEN8_AA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    05 WPRXVEN8-MM              PIC  9(002).*/
            public IntBasis WPRXVEN8_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"    05 WPRXVEN8-DD              PIC  9(002).*/
            public IntBasis WPRXVEN8_DD { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"01  MIN-PROXVEN-DATE            PIC  X(010).*/

            public _REDEF_VA4002B_PROXVEN_DATE8_RD()
            {
                WPRXVEN8_AA.ValueChanged += OnValueChanged;
                WPRXVEN8_MM.ValueChanged += OnValueChanged;
                WPRXVEN8_DD.ValueChanged += OnValueChanged;
            }

        }
        public StringBasis MIN_PROXVEN_DATE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  MIN-PROXVEN-DATE-RD REDEFINES MIN-PROXVEN-DATE.*/
        private _REDEF_VA4002B_MIN_PROXVEN_DATE_RD _min_proxven_date_rd { get; set; }
        public _REDEF_VA4002B_MIN_PROXVEN_DATE_RD MIN_PROXVEN_DATE_RD
        {
            get { _min_proxven_date_rd = new _REDEF_VA4002B_MIN_PROXVEN_DATE_RD(); _.Move(MIN_PROXVEN_DATE, _min_proxven_date_rd); VarBasis.RedefinePassValue(MIN_PROXVEN_DATE, _min_proxven_date_rd, MIN_PROXVEN_DATE); _min_proxven_date_rd.ValueChanged += () => { _.Move(_min_proxven_date_rd, MIN_PROXVEN_DATE); }; return _min_proxven_date_rd; }
            set { VarBasis.RedefinePassValue(value, _min_proxven_date_rd, MIN_PROXVEN_DATE); }
        }  //Redefines
        public class _REDEF_VA4002B_MIN_PROXVEN_DATE_RD : VarBasis
        {
            /*"    05 WMIN-PRXVEN-AA               PIC  9(004).*/
            public IntBasis WMIN_PRXVEN_AA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    05 FILLER                   PIC  X.*/
            public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "1", "X."), @"");
            /*"    05 WMIN-PRXVEN-MM               PIC  9(002).*/
            public IntBasis WMIN_PRXVEN_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"    05 FILLER                   PIC  X.*/
            public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "1", "X."), @"");
            /*"    05 WMIN-PRXVEN-DD               PIC  9(002).*/
            public IntBasis WMIN_PRXVEN_DD { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"01  MIN-PROXVEN-DATE8           PIC  9(008).*/

            public _REDEF_VA4002B_MIN_PROXVEN_DATE_RD()
            {
                WMIN_PRXVEN_AA.ValueChanged += OnValueChanged;
                FILLER_6.ValueChanged += OnValueChanged;
                WMIN_PRXVEN_MM.ValueChanged += OnValueChanged;
                FILLER_7.ValueChanged += OnValueChanged;
                WMIN_PRXVEN_DD.ValueChanged += OnValueChanged;
            }

        }
        public IntBasis MIN_PROXVEN_DATE8 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
        /*"01  MIN-PROXVEN-DATE8-RD REDEFINES MIN-PROXVEN-DATE8.*/
        private _REDEF_VA4002B_MIN_PROXVEN_DATE8_RD _min_proxven_date8_rd { get; set; }
        public _REDEF_VA4002B_MIN_PROXVEN_DATE8_RD MIN_PROXVEN_DATE8_RD
        {
            get { _min_proxven_date8_rd = new _REDEF_VA4002B_MIN_PROXVEN_DATE8_RD(); _.Move(MIN_PROXVEN_DATE8, _min_proxven_date8_rd); VarBasis.RedefinePassValue(MIN_PROXVEN_DATE8, _min_proxven_date8_rd, MIN_PROXVEN_DATE8); _min_proxven_date8_rd.ValueChanged += () => { _.Move(_min_proxven_date8_rd, MIN_PROXVEN_DATE8); }; return _min_proxven_date8_rd; }
            set { VarBasis.RedefinePassValue(value, _min_proxven_date8_rd, MIN_PROXVEN_DATE8); }
        }  //Redefines
        public class _REDEF_VA4002B_MIN_PROXVEN_DATE8_RD : VarBasis
        {
            /*"    05 WMIN-PRXVEN8-AA          PIC  9(004).*/
            public IntBasis WMIN_PRXVEN8_AA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    05 WMIN-PRXVEN8-MM          PIC  9(002).*/
            public IntBasis WMIN_PRXVEN8_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"    05 WMIN-PRXVEN8-DD          PIC  9(002).*/
            public IntBasis WMIN_PRXVEN8_DD { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"01  MMFAIXA                     PIC S9(004)      COMP.*/

            public _REDEF_VA4002B_MIN_PROXVEN_DATE8_RD()
            {
                WMIN_PRXVEN8_AA.ValueChanged += OnValueChanged;
                WMIN_PRXVEN8_MM.ValueChanged += OnValueChanged;
                WMIN_PRXVEN8_DD.ValueChanged += OnValueChanged;
            }

        }
        public IntBasis MMFAIXA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  MFAIXA                      PIC S9(004)      COMP.*/
        public IntBasis MFAIXA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  MAGENCIADOR                 PIC S9(009)      COMP.*/
        public IntBasis MAGENCIADOR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01  MDTMOVTO                    PIC  X(010).*/
        public StringBasis MDTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  MMDTMOVTO                   PIC  X(010).*/
        public StringBasis MMDTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  MCODOPER                    PIC S9(004)      COMP.*/
        public IntBasis MCODOPER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  MDTREF                      PIC  X(010).*/
        public StringBasis MDTREF { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  MTPBENEF                    PIC  X(001).*/
        public StringBasis MTPBENEF { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01  MTPINCLUS                   PIC  X(001).*/
        public StringBasis MTPINCLUS { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01  MNUM-MATRICULA              PIC S9(015)      COMP-3.*/
        public IntBasis MNUM_MATRICULA { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"01  MMNUM-MATRICULA             PIC S9(015)      COMP-3.*/
        public IntBasis MMNUM_MATRICULA { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"01  MAGECOBR                    PIC S9(04)       COMP.*/
        public IntBasis MAGECOBR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  MNUM-CTA-CORRENTE           PIC S9(013)      COMP-3.*/
        public IntBasis MNUM_CTA_CORRENTE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"01  MDAC-CTA-CORRENTE           PIC  X(001).*/
        public StringBasis MDAC_CTA_CORRENTE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01  MTXAPMA                     PIC S9(003)V9(4) COMP-3.*/
        public DoubleBasis MTXAPMA { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(4)"), 4);
        /*"01  MTXAPIP                     PIC S9(003)V9(4) COMP-3.*/
        public DoubleBasis MTXAPIP { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(4)"), 4);
        /*"01  MTXVG                       PIC S9(003)V9(4) COMP-3.*/
        public DoubleBasis MTXVG { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(4)"), 4);
        /*"01  BENEF-NRBENEF               PIC S9(04)       COMP.*/
        public IntBasis BENEF_NRBENEF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  BENEF-NOMBENEF              PIC X(40).*/
        public StringBasis BENEF_NOMBENEF { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"01  BENEF-GRAUPAR               PIC X(10).*/
        public StringBasis BENEF_GRAUPAR { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  BENEF-PCTBENEF              PIC S9(03)V99    COMP-3.*/
        public DoubleBasis BENEF_PCTBENEF { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(03)V99"), 2);
        /*"01  BENEF-DTTERVIG              PIC X(10).*/
        public StringBasis BENEF_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  BENEF-DTINIVIG              PIC X(10).*/
        public StringBasis BENEF_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  BENEF-DTTERVIG-I            PIC S9(04)       COMP.*/
        public IntBasis BENEF_DTTERVIG_I { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  BANCOS-NRTIT                PIC S9(013)      COMP-3.*/
        public IntBasis BANCOS_NRTIT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"01  FATURC-DTREF                PIC  X(010).*/
        public StringBasis FATURC_DTREF { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  PARCEL-OCORHIST             PIC S9(004)      COMP.*/
        public IntBasis PARCEL_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  HOST-CODCONV                PIC S9(004)      COMP.*/
        public IntBasis HOST_CODCONV { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  CONVEN-CODCONV              PIC S9(004)      COMP.*/
        public IntBasis CONVEN_CODCONV { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  CONVEN-CARTAO               PIC S9(004)      COMP.*/
        public IntBasis CONVEN_CARTAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  HISTCB-DTVENCTO             PIC  X(010).*/
        public StringBasis HISTCB_DTVENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  HISTCB-SITUACAO             PIC  X(001).*/
        public StringBasis HISTCB_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01  HISTCB-CODOPER              PIC S9(004)      COMP.*/
        public IntBasis HISTCB_CODOPER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  V0HCOB-VLPRMTOT             PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0HCOB_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V1RCAC-FONTE                PIC S9(004) VALUE +0 COMP.*/
        public IntBasis V1RCAC_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  V1RCAC-NRRCAP               PIC S9(009) VALUE +0 COMP.*/
        public IntBasis V1RCAC_NRRCAP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01  V1RCAC-NRRCAPCO             PIC S9(009) VALUE +0 COMP.*/
        public IntBasis V1RCAC_NRRCAPCO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01  V1RCAC-OPERACAO             PIC S9(004) VALUE +0 COMP.*/
        public IntBasis V1RCAC_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  V1RCAC-HORAOPER             PIC  X(008).*/
        public StringBasis V1RCAC_HORAOPER { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"01  V1RCAC-DTMOVTO              PIC  X(010).*/
        public StringBasis V1RCAC_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  V1RCAC-SITUACAO             PIC  X(001).*/
        public StringBasis V1RCAC_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01  V1RCAC-BCOAVISO             PIC S9(004) VALUE +0 COMP.*/
        public IntBasis V1RCAC_BCOAVISO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  V1RCAC-AGEAVISO             PIC S9(004) VALUE +0 COMP.*/
        public IntBasis V1RCAC_AGEAVISO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  V1RCAC-NRAVISO              PIC S9(009) VALUE +0 COMP.*/
        public IntBasis V1RCAC_NRAVISO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01  V1RCAC-VLRCAP               PIC S9(013)V99 VALUE +0 COMP-3.*/
        public DoubleBasis V1RCAC_VLRCAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01  V1RCAC-DATARCAP             PIC  X(010).*/
        public StringBasis V1RCAC_DATARCAP { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  V1RCAC-DTCADAST             PIC  X(010).*/
        public StringBasis V1RCAC_DTCADAST { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  V1RCAC-SITCONTB             PIC  X(001).*/
        public StringBasis V1RCAC_SITCONTB { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01  V1RCAC-COD-EMPRESA          PIC S9(009) VALUE +0 COMP.*/
        public IntBasis V1RCAC_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01  V1RCAC-TIMESTAMP            PIC  X(026).*/
        public StringBasis V1RCAC_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(026)."), @"");
        /*"01  V1RCAP-VLRCAP               PIC S9(013)V99 VALUE +0 COMP-3.*/
        public DoubleBasis V1RCAP_VLRCAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01  V1RCAP-DATARCAP             PIC  X(010) VALUE  SPACES.*/
        public StringBasis V1RCAP_DATARCAP { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"01  V0RCAP-FONTE                PIC S9(004) VALUE +0 COMP.*/
        public IntBasis V0RCAP_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  V0RCAP-NRRCAP               PIC S9(009) VALUE +0 COMP.*/
        public IntBasis V0RCAP_NRRCAP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01  V0RCAP-NRTIT                PIC S9(013) VALUE +0 COMP-3.*/
        public IntBasis V0RCAP_NRTIT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"01  V0RCAP-NRPROPOS             PIC S9(009) VALUE +0 COMP.*/
        public IntBasis V0RCAP_NRPROPOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01  V0RCAP-NOME                 PIC  X(040).*/
        public StringBasis V0RCAP_NOME { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"01  V0RCAP-VLRCAP               PIC S9(013)V99 VALUE +0 COMP-3.*/
        public DoubleBasis V0RCAP_VLRCAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01  V0RCAP-VALPRI               PIC S9(013)V99 VALUE +0 COMP-3.*/
        public DoubleBasis V0RCAP_VALPRI { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01  V0RCAP-DTCADAST             PIC  X(010).*/
        public StringBasis V0RCAP_DTCADAST { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  V0RCAP-DTMOVTO              PIC  X(010).*/
        public StringBasis V0RCAP_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  V0RCAP-SITUACAO             PIC  X(001).*/
        public StringBasis V0RCAP_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01  V0RCAP-OPERACAO             PIC S9(004) VALUE +0 COMP.*/
        public IntBasis V0RCAP_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  V0RCAP-COD-EMPRESA          PIC S9(009) VALUE +0 COMP.*/
        public IntBasis V0RCAP_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01  V0RCAP-TIMESTAMP            PIC  X(026).*/
        public StringBasis V0RCAP_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(026)."), @"");
        /*"01  V0RCAP-NUM-APOL             PIC S9(013) VALUE +0 COMP-3.*/
        public IntBasis V0RCAP_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"01  V0RCAP-NRENDOS              PIC S9(009) VALUE +0 COMP.*/
        public IntBasis V0RCAP_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01  V0RCAP-NRPARCEL             PIC S9(004) VALUE +0 COMP.*/
        public IntBasis V0RCAP_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  V2RCAP-VLRCAP               PIC S9(013)V99 VALUE +0 COMP-3.*/
        public DoubleBasis V2RCAP_VLRCAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01  V0FOLH-COD-PRODUTO          PIC S9(004) COMP.*/
        public IntBasis V0FOLH_COD_PRODUTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  V0FOLH-NRCERTIF             PIC S9(015) COMP-3.*/
        public IntBasis V0FOLH_NRCERTIF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"01  V0FOLH-COD-CARTA            PIC  X(001).*/
        public StringBasis V0FOLH_COD_CARTA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01  V0FOLH-DTEMICAR             PIC  X(010).*/
        public StringBasis V0FOLH_DTEMICAR { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  V0FOLH-DTSOLICIT            PIC  X(010).*/
        public StringBasis V0FOLH_DTSOLICIT { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  V0FOLH-CODUSU               PIC  X(008).*/
        public StringBasis V0FOLH_CODUSU { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"01  V0FOLH-SITUACAO             PIC  X(001).*/
        public StringBasis V0FOLH_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01  V0FOLH-TIMESTAMP            PIC  X(026).*/
        public StringBasis V0FOLH_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(026)."), @"");
        /*"01  LD00.*/
        public VA4002B_LD00 LD00 { get; set; } = new VA4002B_LD00();
        public class VA4002B_LD00 : VarBasis
        {
            /*"    05  FILLER              PIC X(07)   VALUE 'VA4002B'.*/
            public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "7", "X(07)"), @"VA4002B");
            /*"    05  FILLER              PIC X(08)   VALUE  SPACES.*/
            public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"    05  FILLER              PIC X(54)   VALUE        'CERTIFICADOS COM ERRO EMITIDOS APOS O PRAZO DE 15 DIAS'*/
            public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "54", "X(54)"), @"CERTIFICADOS COM ERRO EMITIDOS APOS O PRAZO DE 15 DIAS");
            /*"01  LD01.*/
        }
        public VA4002B_LD01 LD01 { get; set; } = new VA4002B_LD01();
        public class VA4002B_LD01 : VarBasis
        {
            /*"    05  FILLER              PIC X(07)   VALUE 'PRODUTO'.*/
            public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "7", "X(07)"), @"PRODUTO");
            /*"    05  FILLER              PIC X(01)   VALUE ';'.*/
            public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05  FILLER              PIC X(06)   VALUE 'FILIAL'.*/
            public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "6", "X(06)"), @"FILIAL");
            /*"    05  FILLER              PIC X(01)   VALUE ';'.*/
            public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05  FILLER              PIC X(11)   VALUE 'CERTIFICADO'.*/
            public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "11", "X(11)"), @"CERTIFICADO");
            /*"    05  FILLER              PIC X(01)   VALUE ';'.*/
            public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05  FILLER              PIC X(03)   VALUE 'CPF'.*/
            public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"CPF");
            /*"    05  FILLER              PIC X(01)   VALUE ';'.*/
            public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05  FILLER              PIC X(08)   VALUE 'QUITACAO'.*/
            public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"QUITACAO");
            /*"    05  FILLER              PIC X(01)   VALUE ';'.*/
            public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05  FILLER              PIC X(07)   VALUE 'AGENCIA'.*/
            public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "7", "X(07)"), @"AGENCIA");
            /*"    05  FILLER              PIC X(01)   VALUE ';'.*/
            public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05  FILLER              PIC X(07)   VALUE 'USUARIO'.*/
            public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "7", "X(07)"), @"USUARIO");
            /*"    05  FILLER              PIC X(01)   VALUE ';'.*/
            public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05  FILLER              PIC X(04)   VALUE 'ERRO'.*/
            public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "4", "X(04)"), @"ERRO");
            /*"01  LD02.*/
        }
        public VA4002B_LD02 LD02 { get; set; } = new VA4002B_LD02();
        public class VA4002B_LD02 : VarBasis
        {
            /*"    05  ARQEMIT-COD-PRODUTO     PIC  X(004).*/
            public StringBasis ARQEMIT_COD_PRODUTO { get; set; } = new StringBasis(new PIC("X", "4", "X(004)."), @"");
            /*"    05  ARQEMIT-FIL1            PIC  X(001) VALUE ';'.*/
            public StringBasis ARQEMIT_FIL1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    05  ARQEMIT-FONTE           PIC  X(004).*/
            public StringBasis ARQEMIT_FONTE { get; set; } = new StringBasis(new PIC("X", "4", "X(004)."), @"");
            /*"    05  ARQEMIT-FIL2            PIC  X(001) VALUE ';'.*/
            public StringBasis ARQEMIT_FIL2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    05  ARQEMIT-NRCERTIF        PIC  X(015).*/
            public StringBasis ARQEMIT_NRCERTIF { get; set; } = new StringBasis(new PIC("X", "15", "X(015)."), @"");
            /*"    05  ARQEMIT-FIL3            PIC  X(001) VALUE ';'.*/
            public StringBasis ARQEMIT_FIL3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    05  ARQEMIT-CPF             PIC  X(015).*/
            public StringBasis ARQEMIT_CPF { get; set; } = new StringBasis(new PIC("X", "15", "X(015)."), @"");
            /*"    05  ARQEMIT-FIL4            PIC  X(001) VALUE ';'.*/
            public StringBasis ARQEMIT_FIL4 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    05  ARQEMIT-DT-QUITACAO     PIC  X(010).*/
            public StringBasis ARQEMIT_DT_QUITACAO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    05  ARQEMIT-FIL5            PIC  X(001) VALUE ';'.*/
            public StringBasis ARQEMIT_FIL5 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    05  ARQEMIT-AGENCIA         PIC  X(004).*/
            public StringBasis ARQEMIT_AGENCIA { get; set; } = new StringBasis(new PIC("X", "4", "X(004)."), @"");
            /*"    05  ARQEMIT-FIL6            PIC  X(001) VALUE ';'.*/
            public StringBasis ARQEMIT_FIL6 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    05  ARQEMIT-COD-USUARIO     PIC  X(008).*/
            public StringBasis ARQEMIT_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"    05  ARQEMIT-FIL7            PIC  X(001) VALUE ';'.*/
            public StringBasis ARQEMIT_FIL7 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    05  ARQEMIT-DESC-ERRO       PIC  X(060).*/
            public StringBasis ARQEMIT_DESC_ERRO { get; set; } = new StringBasis(new PIC("X", "60", "X(060)."), @"");
            /*"01  WS-TABMES.*/
        }
        public VA4002B_WS_TABMES WS_TABMES { get; set; } = new VA4002B_WS_TABMES();
        public class VA4002B_WS_TABMES : VarBasis
        {
            /*"    10 FILLER PIC X(24) VALUE '312831303130313130313031'.*/
            public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "24", "X(24)"), @"312831303130313130313031");
            /*"01  WS-TABMES-R REDEFINES WS-TABMES.*/
        }
        private _REDEF_VA4002B_WS_TABMES_R _ws_tabmes_r { get; set; }
        public _REDEF_VA4002B_WS_TABMES_R WS_TABMES_R
        {
            get { _ws_tabmes_r = new _REDEF_VA4002B_WS_TABMES_R(); _.Move(WS_TABMES, _ws_tabmes_r); VarBasis.RedefinePassValue(WS_TABMES, _ws_tabmes_r, WS_TABMES); _ws_tabmes_r.ValueChanged += () => { _.Move(_ws_tabmes_r, WS_TABMES); }; return _ws_tabmes_r; }
            set { VarBasis.RedefinePassValue(value, _ws_tabmes_r, WS_TABMES); }
        }  //Redefines
        public class _REDEF_VA4002B_WS_TABMES_R : VarBasis
        {
            /*"    10 WS-ULTDIA OCCURS 12 TIMES PIC 9(02).*/
            public ListBasis<IntBasis, Int64> WS_ULTDIA { get; set; } = new ListBasis<IntBasis, Int64>(new PIC("9", "2", "9(02)."), 12);
            /*"01  WS-WORK-AREAS.*/

            public _REDEF_VA4002B_WS_TABMES_R()
            {
                WS_ULTDIA.ValueChanged += OnValueChanged;
            }

        }
        public VA4002B_WS_WORK_AREAS WS_WORK_AREAS { get; set; } = new VA4002B_WS_WORK_AREAS();
        public class VA4002B_WS_WORK_AREAS : VarBasis
        {
            /*"    03 W-NUM-PROPOSTA               PIC 9(014).*/
            public IntBasis W_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
            /*"    03 CANAL REDEFINES W-NUM-PROPOSTA.*/
            private _REDEF_VA4002B_CANAL _canal { get; set; }
            public _REDEF_VA4002B_CANAL CANAL
            {
                get { _canal = new _REDEF_VA4002B_CANAL(); _.Move(W_NUM_PROPOSTA, _canal); VarBasis.RedefinePassValue(W_NUM_PROPOSTA, _canal, W_NUM_PROPOSTA); _canal.ValueChanged += () => { _.Move(_canal, W_NUM_PROPOSTA); }; return _canal; }
                set { VarBasis.RedefinePassValue(value, _canal, W_NUM_PROPOSTA); }
            }  //Redefines
            public class _REDEF_VA4002B_CANAL : VarBasis
            {
                /*"       07 W-CANAL-PROPOSTA          PIC 9(001).*/

                public SelectorBasis W_CANAL_PROPOSTA { get; set; } = new SelectorBasis("001")
                {
                    Items = new List<SelectorItemBasis> {
                            /*" 88 CANAL-VENDA-PAPEL                    VALUE 0. */
							new SelectorItemBasis("CANAL_VENDA_PAPEL", "0"),
							/*" 88 CANAL-VENDA-CEF                      VALUE 1. */
							new SelectorItemBasis("CANAL_VENDA_CEF", "1"),
							/*" 88 CANAL-VENDA-SASSE                    VALUE 2. */
							new SelectorItemBasis("CANAL_VENDA_SASSE", "2"),
							/*" 88 CANAL-VENDA-CORRETOR                 VALUE 3. */
							new SelectorItemBasis("CANAL_VENDA_CORRETOR", "3"),
							/*" 88 CANAL-VENDA-ATM                      VALUE 4. */
							new SelectorItemBasis("CANAL_VENDA_ATM", "4"),
							/*" 88 CANAL-VENDA-GITEL                    VALUE 5. */
							new SelectorItemBasis("CANAL_VENDA_GITEL", "5"),
							/*" 88 CANAL-VENDA-INTERNET                 VALUE 7. */
							new SelectorItemBasis("CANAL_VENDA_INTERNET", "7"),
							/*" 88 CANAL-VENDA-INTRANET                 VALUE 8. */
							new SelectorItemBasis("CANAL_VENDA_INTRANET", "8")
                }
                };

                /*"       07 FILLER                    PIC 9(013).*/
                public IntBasis FILLER_27 { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
                /*"    03 FILLER REDEFINES W-NUM-PROPOSTA.*/

                public _REDEF_VA4002B_CANAL()
                {
                    W_CANAL_PROPOSTA.ValueChanged += OnValueChanged;
                    FILLER_27.ValueChanged += OnValueChanged;
                }

            }
            private _REDEF_VA4002B_FILLER_28 _filler_28 { get; set; }
            public _REDEF_VA4002B_FILLER_28 FILLER_28
            {
                get { _filler_28 = new _REDEF_VA4002B_FILLER_28(); _.Move(W_NUM_PROPOSTA, _filler_28); VarBasis.RedefinePassValue(W_NUM_PROPOSTA, _filler_28, W_NUM_PROPOSTA); _filler_28.ValueChanged += () => { _.Move(_filler_28, W_NUM_PROPOSTA); }; return _filler_28; }
                set { VarBasis.RedefinePassValue(value, _filler_28, W_NUM_PROPOSTA); }
            }  //Redefines
            public class _REDEF_VA4002B_FILLER_28 : VarBasis
            {
                /*"       07 FILLER                    PIC X(001).*/
                public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       07 W-CANAL-PROPOSTA1         PIC 9(004).*/

                public SelectorBasis W_CANAL_PROPOSTA1 { get; set; } = new SelectorBasis("004")
                {
                    Items = new List<SelectorItemBasis> {
                            /*" 88 PROPOSTA-CACB                      VALUE 9994. */
							new SelectorItemBasis("PROPOSTA_CACB", "9994"),
							/*" 88 PROPOSTA-COPESP                    VALUE 9995. */
							new SelectorItemBasis("PROPOSTA_COPESP", "9995")
                }
                };

                /*"       07 FILLER                    PIC 9(009).*/
                public IntBasis FILLER_30 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
                /*"    03  PRODVG-CUSTOCAP-TOTAL-A     PIC  X(001).*/

                public _REDEF_VA4002B_FILLER_28()
                {
                    FILLER_29.ValueChanged += OnValueChanged;
                    W_CANAL_PROPOSTA1.ValueChanged += OnValueChanged;
                    FILLER_30.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis PRODVG_CUSTOCAP_TOTAL_A { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    03  PRODVG-CUSTOCAP-TOTAL-N     REDEFINES        PRODVG-CUSTOCAP-TOTAL-A     PIC  9(001).*/
            private _REDEF_IntBasis _prodvg_custocap_total_n { get; set; }
            public _REDEF_IntBasis PRODVG_CUSTOCAP_TOTAL_N
            {
                get { _prodvg_custocap_total_n = new _REDEF_IntBasis(new PIC("9", "001", "9(001).")); ; _.Move(PRODVG_CUSTOCAP_TOTAL_A, _prodvg_custocap_total_n); VarBasis.RedefinePassValue(PRODVG_CUSTOCAP_TOTAL_A, _prodvg_custocap_total_n, PRODVG_CUSTOCAP_TOTAL_A); _prodvg_custocap_total_n.ValueChanged += () => { _.Move(_prodvg_custocap_total_n, PRODVG_CUSTOCAP_TOTAL_A); }; return _prodvg_custocap_total_n; }
                set { VarBasis.RedefinePassValue(value, _prodvg_custocap_total_n, PRODVG_CUSTOCAP_TOTAL_A); }
            }  //Redefines
            /*"    03  WS-CHAVE.*/
            public VA4002B_WS_CHAVE WS_CHAVE { get; set; } = new VA4002B_WS_CHAVE();
            public class VA4002B_WS_CHAVE : VarBasis
            {
                /*"        05 WS-NUM-APOLICE            PIC 9(13).*/
                public IntBasis WS_NUM_APOLICE { get; set; } = new IntBasis(new PIC("9", "13", "9(13)."));
                /*"        05 WS-CODSUBES               PIC 9(04).*/
                public IntBasis WS_CODSUBES { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                /*"    03  WS-CHAVE-ANT.*/
            }
            public VA4002B_WS_CHAVE_ANT WS_CHAVE_ANT { get; set; } = new VA4002B_WS_CHAVE_ANT();
            public class VA4002B_WS_CHAVE_ANT : VarBasis
            {
                /*"        05 WS-NUM-APOLICE-ANT        PIC 9(13)      VALUE ZEROS.*/
                public IntBasis WS_NUM_APOLICE_ANT { get; set; } = new IntBasis(new PIC("9", "13", "9(13)"));
                /*"        05 WS-CODSUBES-ANT           PIC 9(04)      VALUE ZEROS.*/
                public IntBasis WS_CODSUBES_ANT { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
                /*"    03  WS-QTDE-ANOS                 PIC 9(02)      VALUE ZEROS.*/
            }
            public IntBasis WS_QTDE_ANOS { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
            /*"    03  WS-STATUS                    PIC 9(02)      VALUE ZEROS.*/
            public IntBasis WS_STATUS { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
            /*"    03  WS-COUNT                     PIC 9(02)      VALUE ZEROS.*/
            public IntBasis WS_COUNT { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
            /*"    03  WS-TAXA-VG                   PIC 9(02)V99   VALUE ZEROS.*/
            public DoubleBasis WS_TAXA_VG { get; set; } = new DoubleBasis(new PIC("9", "2", "9(02)V99"), 2);
            /*"    03  WS-TAXA-AP                   PIC 9(02)V99   VALUE ZEROS.*/
            public DoubleBasis WS_TAXA_AP { get; set; } = new DoubleBasis(new PIC("9", "2", "9(02)V99"), 2);
            /*"    03  WS-TAXA-TOT                  PIC 9(02)V99   VALUE ZEROS.*/
            public DoubleBasis WS_TAXA_TOT { get; set; } = new DoubleBasis(new PIC("9", "2", "9(02)V99"), 2);
            /*"    03  WTEM-SIVPF                   PIC 9 VALUE 0.*/
            public IntBasis WTEM_SIVPF { get; set; } = new IntBasis(new PIC("9", "1", "9"));
            /*"    03  WTEM-MOVFEDCA                PIC X(03)     VALUE SPACES.*/
            public StringBasis WTEM_MOVFEDCA { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"");
            /*"    03  WS-EOF                       PIC 9 VALUE 0.*/
            public IntBasis WS_EOF { get; set; } = new IntBasis(new PIC("9", "1", "9"));
            /*"    03  WS-EOP                       PIC 9 VALUE 0.*/
            public IntBasis WS_EOP { get; set; } = new IntBasis(new PIC("9", "1", "9"));
            /*"    03  WS-EOS                       PIC 9 VALUE 0.*/
            public IntBasis WS_EOS { get; set; } = new IntBasis(new PIC("9", "1", "9"));
            /*"    03  WS-EOF-D                     PIC 9 VALUE 0.*/
            public IntBasis WS_EOF_D { get; set; } = new IntBasis(new PIC("9", "1", "9"));
            /*"    03  WFIM-V1RCAP                  PIC X(001)  VALUE SPACES.*/
            public StringBasis WFIM_V1RCAP { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    03  WTEM-V0RCAP                  PIC X(001)  VALUE SPACES.*/
            public StringBasis WTEM_V0RCAP { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    03  WS-RATEIO                    PIC  9(003)V9(5).*/
            public DoubleBasis WS_RATEIO { get; set; } = new DoubleBasis(new PIC("9", "3", "9(003)V9(5)."), 5);
            /*"    03  WS-IND-IOF                   PIC S9(001)V9(4) COMP-3.*/
            public DoubleBasis WS_IND_IOF { get; set; } = new DoubleBasis(new PIC("S9", "1", "S9(001)V9(4)"), 4);
            /*"    03  WS-COD-CARTA                 PIC  X(001).*/
            public StringBasis WS_COD_CARTA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    03  WS-CODPRODU-ANT              PIC S9(004)  COMP  VALUE +0*/
            public IntBasis WS_CODPRODU_ANT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    03  W01A0100.*/
            public VA4002B_W01A0100 W01A0100 { get; set; } = new VA4002B_W01A0100();
            public class VA4002B_W01A0100 : VarBasis
            {
                /*"        05 W01N0100                  PIC 9(01).*/
                public IntBasis W01N0100 { get; set; } = new IntBasis(new PIC("9", "1", "9(01)."));
                /*"    03  WSQLCODE3                    PIC S9(009) COMP.*/
            }
            public IntBasis WSQLCODE3 { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"    03  WSQLCODE-PLANOS              PIC S9(009) COMP.*/
            public IntBasis WSQLCODE_PLANOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"    03 W-DTEMICAR      PIC X(010) VALUE SPACES.*/
            public StringBasis W_DTEMICAR { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"    03 FILLER  REDEFINES W-DTEMICAR.*/
            private _REDEF_VA4002B_FILLER_31 _filler_31 { get; set; }
            public _REDEF_VA4002B_FILLER_31 FILLER_31
            {
                get { _filler_31 = new _REDEF_VA4002B_FILLER_31(); _.Move(W_DTEMICAR, _filler_31); VarBasis.RedefinePassValue(W_DTEMICAR, _filler_31, W_DTEMICAR); _filler_31.ValueChanged += () => { _.Move(_filler_31, W_DTEMICAR); }; return _filler_31; }
                set { VarBasis.RedefinePassValue(value, _filler_31, W_DTEMICAR); }
            }  //Redefines
            public class _REDEF_VA4002B_FILLER_31 : VarBasis
            {
                /*"       05 W-SSEMICAR                 PIC 9(004).*/
                public IntBasis W_SSEMICAR { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"       05 FILLER                     PIC X(001).*/
                public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       05 W-MMEMICAR                 PIC 9(002).*/
                public IntBasis W_MMEMICAR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       05 FILLER                     PIC X(001).*/
                public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       05 W-DDEMICAR                 PIC 9(002).*/
                public IntBasis W_DDEMICAR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    03 WS-VIGENCIA.*/

                public _REDEF_VA4002B_FILLER_31()
                {
                    W_SSEMICAR.ValueChanged += OnValueChanged;
                    FILLER_32.ValueChanged += OnValueChanged;
                    W_MMEMICAR.ValueChanged += OnValueChanged;
                    FILLER_33.ValueChanged += OnValueChanged;
                    W_DDEMICAR.ValueChanged += OnValueChanged;
                }

            }
            public VA4002B_WS_VIGENCIA WS_VIGENCIA { get; set; } = new VA4002B_WS_VIGENCIA();
            public class VA4002B_WS_VIGENCIA : VarBasis
            {
                /*"       05  WS-VIG-ANO                PIC 9(004).*/
                public IntBasis WS_VIG_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"       05  FILLER                    PIC X(001).*/
                public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       05  WS-VIG-MES                PIC 9(002).*/
                public IntBasis WS_VIG_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       05  FILLER                    PIC X(001).*/
                public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       05  WS-VIG-DIA                PIC 9(002).*/
                public IntBasis WS_VIG_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    03 WS-VIGENCIA1.*/
            }
            public VA4002B_WS_VIGENCIA1 WS_VIGENCIA1 { get; set; } = new VA4002B_WS_VIGENCIA1();
            public class VA4002B_WS_VIGENCIA1 : VarBasis
            {
                /*"       05  WS-VIG-ANO1               PIC 9(004).*/
                public IntBasis WS_VIG_ANO1 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"       05  FILLER                    PIC X(001).*/
                public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       05  WS-VIG-MES1               PIC 9(002).*/
                public IntBasis WS_VIG_MES1 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       05  FILLER                    PIC X(001).*/
                public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       05  WS-VIG-DIA1               PIC 9(002).*/
                public IntBasis WS_VIG_DIA1 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    03 WS-DTVENCTO-AUX.*/
            }
            public VA4002B_WS_DTVENCTO_AUX WS_DTVENCTO_AUX { get; set; } = new VA4002B_WS_DTVENCTO_AUX();
            public class VA4002B_WS_DTVENCTO_AUX : VarBasis
            {
                /*"       05  WS-VENCTO-ANO             PIC 9(004).*/
                public IntBasis WS_VENCTO_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"       05  FILLER                    PIC X(001).*/
                public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       05  WS-VENCTO-MES             PIC 9(002).*/
                public IntBasis WS_VENCTO_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       05  FILLER                    PIC X(001).*/
                public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       05  WS-VENCTO-DIA             PIC 9(002).*/
                public IntBasis WS_VENCTO_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    03 W01DTSQL                      PIC X(010).*/
            }
            public StringBasis W01DTSQL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    03 W01DTSQL-R    REDEFINES W01DTSQL.*/
            private _REDEF_VA4002B_W01DTSQL_R _w01dtsql_r { get; set; }
            public _REDEF_VA4002B_W01DTSQL_R W01DTSQL_R
            {
                get { _w01dtsql_r = new _REDEF_VA4002B_W01DTSQL_R(); _.Move(W01DTSQL, _w01dtsql_r); VarBasis.RedefinePassValue(W01DTSQL, _w01dtsql_r, W01DTSQL); _w01dtsql_r.ValueChanged += () => { _.Move(_w01dtsql_r, W01DTSQL); }; return _w01dtsql_r; }
                set { VarBasis.RedefinePassValue(value, _w01dtsql_r, W01DTSQL); }
            }  //Redefines
            public class _REDEF_VA4002B_W01DTSQL_R : VarBasis
            {
                /*"       05  W01AASQL                  PIC 9(004).*/
                public IntBasis W01AASQL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"       05  W01T1SQL                  PIC X(001).*/
                public StringBasis W01T1SQL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       05  W01MMSQL                  PIC 9(002).*/
                public IntBasis W01MMSQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       05  W01T2SQL                  PIC X(001).*/
                public StringBasis W01T2SQL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       05  W01DDSQL                  PIC 9(002).*/
                public IntBasis W01DDSQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    03 W02DTSQL.*/

                public _REDEF_VA4002B_W01DTSQL_R()
                {
                    W01AASQL.ValueChanged += OnValueChanged;
                    W01T1SQL.ValueChanged += OnValueChanged;
                    W01MMSQL.ValueChanged += OnValueChanged;
                    W01T2SQL.ValueChanged += OnValueChanged;
                    W01DDSQL.ValueChanged += OnValueChanged;
                }

            }
            public VA4002B_W02DTSQL W02DTSQL { get; set; } = new VA4002B_W02DTSQL();
            public class VA4002B_W02DTSQL : VarBasis
            {
                /*"       05  W02AAMMSQL.*/
                public VA4002B_W02AAMMSQL W02AAMMSQL { get; set; } = new VA4002B_W02AAMMSQL();
                public class VA4002B_W02AAMMSQL : VarBasis
                {
                    /*"           10  W02AASQL              PIC 9(004).*/
                    public IntBasis W02AASQL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"           10  W02T1SQL              PIC X(001).*/
                    public StringBasis W02T1SQL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"           10  W02MMSQL              PIC 9(002).*/
                    public IntBasis W02MMSQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"       05  W02T2SQL                  PIC X(001).*/
                }
                public StringBasis W02T2SQL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       05  W02DDSQL                  PIC 9(002).*/
                public IntBasis W02DDSQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    03 W03DTSQL.*/
            }
            public VA4002B_W03DTSQL W03DTSQL { get; set; } = new VA4002B_W03DTSQL();
            public class VA4002B_W03DTSQL : VarBasis
            {
                /*"       05  W03AAMMSQL.*/
                public VA4002B_W03AAMMSQL W03AAMMSQL { get; set; } = new VA4002B_W03AAMMSQL();
                public class VA4002B_W03AAMMSQL : VarBasis
                {
                    /*"           10  W03AASQL              PIC 9(004).*/
                    public IntBasis W03AASQL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"           10  W03T1SQL              PIC X(001).*/
                    public StringBasis W03T1SQL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"           10  W03MMSQL              PIC 9(002).*/
                    public IntBasis W03MMSQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"       05  W03T2SQL                  PIC X(001).*/
                }
                public StringBasis W03T2SQL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       05  W03DDSQL                  PIC 9(002).*/
                public IntBasis W03DDSQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    03 W04DTSQL.*/
            }
            public VA4002B_W04DTSQL W04DTSQL { get; set; } = new VA4002B_W04DTSQL();
            public class VA4002B_W04DTSQL : VarBasis
            {
                /*"       05  W04SASQL                  PIC 9(004).*/
                public IntBasis W04SASQL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"       05  W04SASQL-R                REDEFINES           W04SASQL.*/
                private _REDEF_VA4002B_W04SASQL_R _w04sasql_r { get; set; }
                public _REDEF_VA4002B_W04SASQL_R W04SASQL_R
                {
                    get { _w04sasql_r = new _REDEF_VA4002B_W04SASQL_R(); _.Move(W04SASQL, _w04sasql_r); VarBasis.RedefinePassValue(W04SASQL, _w04sasql_r, W04SASQL); _w04sasql_r.ValueChanged += () => { _.Move(_w04sasql_r, W04SASQL); }; return _w04sasql_r; }
                    set { VarBasis.RedefinePassValue(value, _w04sasql_r, W04SASQL); }
                }  //Redefines
                public class _REDEF_VA4002B_W04SASQL_R : VarBasis
                {
                    /*"         10  W04AASQL                PIC 9(004).*/
                    public IntBasis W04AASQL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"       05  W04T1SQL                  PIC X(001).*/

                    public _REDEF_VA4002B_W04SASQL_R()
                    {
                        W04AASQL.ValueChanged += OnValueChanged;
                    }

                }
                public StringBasis W04T1SQL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       05  W04MMSQL                  PIC 9(002).*/
                public IntBasis W04MMSQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       05  W04T2SQL                  PIC X(001).*/
                public StringBasis W04T2SQL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       05  W04DDSQL                  PIC 9(002).*/
                public IntBasis W04DDSQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    03 W05DTSQL.*/
            }
            public VA4002B_W05DTSQL W05DTSQL { get; set; } = new VA4002B_W05DTSQL();
            public class VA4002B_W05DTSQL : VarBasis
            {
                /*"       05  W05AASQL                  PIC 9(004).*/
                public IntBasis W05AASQL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"       05  W05T1SQL                  PIC X(001).*/
                public StringBasis W05T1SQL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       05  W05MMSQL                  PIC 9(002).*/
                public IntBasis W05MMSQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       05  W05T2SQL                  PIC X(001).*/
                public StringBasis W05T2SQL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       05  W05DDSQL                  PIC 9(002).*/
                public IntBasis W05DDSQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    03 WS-CONT-BENEF                 PIC  9(004) VALUE 0.*/
            }
            public IntBasis WS_CONT_BENEF { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"    03 WS-CTA-CORRENTE-R.*/
            public VA4002B_WS_CTA_CORRENTE_R WS_CTA_CORRENTE_R { get; set; } = new VA4002B_WS_CTA_CORRENTE_R();
            public class VA4002B_WS_CTA_CORRENTE_R : VarBasis
            {
                /*"       05 WS-OPER-SEG                PIC  9(004).*/
                public IntBasis WS_OPER_SEG { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"       05 WS-CTA-SEG                 PIC  9(012).*/
                public IntBasis WS_CTA_SEG { get; set; } = new IntBasis(new PIC("9", "12", "9(012)."));
                /*"    03  WS-CTA-CORRENTE              REDEFINES        WS-CTA-CORRENTE-R            PIC 9(016).*/
            }
            private _REDEF_IntBasis _ws_cta_corrente { get; set; }
            public _REDEF_IntBasis WS_CTA_CORRENTE
            {
                get { _ws_cta_corrente = new _REDEF_IntBasis(new PIC("9", "016", "9(016).")); ; _.Move(WS_CTA_CORRENTE_R, _ws_cta_corrente); VarBasis.RedefinePassValue(WS_CTA_CORRENTE_R, _ws_cta_corrente, WS_CTA_CORRENTE_R); _ws_cta_corrente.ValueChanged += () => { _.Move(_ws_cta_corrente, WS_CTA_CORRENTE_R); }; return _ws_cta_corrente; }
                set { VarBasis.RedefinePassValue(value, _ws_cta_corrente, WS_CTA_CORRENTE_R); }
            }  //Redefines
            /*"    03 WS-CTA-CORRENTE-VR.*/
            public VA4002B_WS_CTA_CORRENTE_VR WS_CTA_CORRENTE_VR { get; set; } = new VA4002B_WS_CTA_CORRENTE_VR();
            public class VA4002B_WS_CTA_CORRENTE_VR : VarBasis
            {
                /*"       05 WS-OPER                    PIC  9(004).*/
                public IntBasis WS_OPER { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"       05 WS-CTA                     PIC  9(012).*/
                public IntBasis WS_CTA { get; set; } = new IntBasis(new PIC("9", "12", "9(012)."));
                /*"    03 WS-CTA-CORRENTEV              REDEFINES       WS-CTA-CORRENTE-VR            PIC 9(016).*/
            }
            private _REDEF_IntBasis _ws_cta_correntev { get; set; }
            public _REDEF_IntBasis WS_CTA_CORRENTEV
            {
                get { _ws_cta_correntev = new _REDEF_IntBasis(new PIC("9", "016", "9(016).")); ; _.Move(WS_CTA_CORRENTE_VR, _ws_cta_correntev); VarBasis.RedefinePassValue(WS_CTA_CORRENTE_VR, _ws_cta_correntev, WS_CTA_CORRENTE_VR); _ws_cta_correntev.ValueChanged += () => { _.Move(_ws_cta_correntev, WS_CTA_CORRENTE_VR); }; return _ws_cta_correntev; }
                set { VarBasis.RedefinePassValue(value, _ws_cta_correntev, WS_CTA_CORRENTE_VR); }
            }  //Redefines
            /*"    03 WS-ENCONTROU                  PIC  X(001) VALUE 'S'.*/

            public SelectorBasis WS_ENCONTROU { get; set; } = new SelectorBasis("001", "S")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 ENCONTROU                  VALUE 'S'. */
							new SelectorItemBasis("ENCONTROU", "S"),
							/*" 88 NAO-ENCONTROU              VALUE 'N'. */
							new SelectorItemBasis("NAO_ENCONTROU", "N")
                }
            };

            /*"    03 WS-LEITUA-SIVPF               PIC  X(001) VALUE 'N'.*/

            public SelectorBasis WS_LEITUA_SIVPF { get; set; } = new SelectorBasis("001", "N")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 LEU-SIVPF                  VALUE 'S'. */
							new SelectorItemBasis("LEU_SIVPF", "S"),
							/*" 88 NAO-LEU-SIVPF              VALUE 'N'. */
							new SelectorItemBasis("NAO_LEU_SIVPF", "N")
                }
            };

            /*"    03 WS-ACESSO-CLIENTE             PIC  9(001) VALUE ZERO.*/

            public SelectorBasis WS_ACESSO_CLIENTE { get; set; } = new SelectorBasis("001", "ZERO")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 ACESSO-CLIENTE-OK                       VALUE 1. */
							new SelectorItemBasis("ACESSO_CLIENTE_OK", "1"),
							/*" 88 ACESSO-CLIENTE-ER                       VALUE 2. */
							new SelectorItemBasis("ACESSO_CLIENTE_ER", "2")
                }
            };

            /*"    03  W-RCAPS                      PIC 9(001).*/

            public SelectorBasis W_RCAPS { get; set; } = new SelectorBasis("001")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 RCAP-CADASTRADO                       VALUE 01. */
							new SelectorItemBasis("RCAP_CADASTRADO", "01")
                }
            };

            /*"    03  W-RCAP-COMP                  PIC 9(001).*/

            public SelectorBasis W_RCAP_COMP { get; set; } = new SelectorBasis("001")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 RCAP-COMP-CADASTRADO                  VALUE 01. */
							new SelectorItemBasis("RCAP_COMP_CADASTRADO", "01")
                }
            };

            /*"    03 UPDATE-SIVPF-SIVPF            PIC  9(006) VALUE  0.*/
            public IntBasis UPDATE_SIVPF_SIVPF { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    03 WS-FIM-MOVTOVGAP              PIC  9      VALUE  0.*/
            public IntBasis WS_FIM_MOVTOVGAP { get; set; } = new IntBasis(new PIC("9", "1", "9"));
            /*"    03 AC-ATUA-MOVTO-VGAP            PIC  9(007) VALUE  0.*/
            public IntBasis AC_ATUA_MOVTO_VGAP { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"    03 AC-LIDOS                      PIC  9(007) VALUE  0.*/
            public IntBasis AC_LIDOS { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"    03 AC-INCLUSOES                  PIC  9(007) VALUE  0.*/
            public IntBasis AC_INCLUSOES { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"    03 AC-DESPREZADOS                PIC  9(007) VALUE  0.*/
            public IntBasis AC_DESPREZADOS { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"    03 AC-DESPR-PRODUVG              PIC  9(007) VALUE  0.*/
            public IntBasis AC_DESPR_PRODUVG { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"    03 AC-DESPR-AGENCCEF             PIC  9(007) VALUE  0.*/
            public IntBasis AC_DESPR_AGENCCEF { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"    03 AC-DESPR-CARTAO               PIC  9(007) VALUE  0.*/
            public IntBasis AC_DESPR_CARTAO { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"    03 AC-DESPR-CLIENTE              PIC  9(007) VALUE  0.*/
            public IntBasis AC_DESPR_CLIENTE { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"    03 AC-DESPR-CONTA                PIC  9(007) VALUE  0.*/
            public IntBasis AC_DESPR_CONTA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"    03 AC-DESPR-DPS-TIT              PIC  9(007) VALUE  0.*/
            public IntBasis AC_DESPR_DPS_TIT { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"    03 AC-DESPR-FONTE                PIC  9(007) VALUE  0.*/
            public IntBasis AC_DESPR_FONTE { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"    03 AC-DESPR-HISCOBPR             PIC  9(007) VALUE  0.*/
            public IntBasis AC_DESPR_HISCOBPR { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"    03 AC-DESPR-IDADE                PIC  9(007) VALUE  0.*/
            public IntBasis AC_DESPR_IDADE { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"    03 AC-DESPR-OPCAOPAG             PIC  9(007) VALUE  0.*/
            public IntBasis AC_DESPR_OPCAOPAG { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"    03 AC-DESPR-PARCELVA             PIC  9(007) VALUE  0.*/
            public IntBasis AC_DESPR_PARCELVA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"    03 AC-DESPR-PERIPGTO             PIC  9(007) VALUE  0.*/
            public IntBasis AC_DESPR_PERIPGTO { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"    03 AC-DESPR-PLAVAVGA             PIC  9(007) VALUE  0.*/
            public IntBasis AC_DESPR_PLAVAVGA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"    03 AC-FOLHETOS                   PIC  9(007) VALUE  ZEROS.*/
            public IntBasis AC_FOLHETOS { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"    03  W-NUMR-TITULO                PIC  9(013)   VALUE ZEROS.*/
            public IntBasis W_NUMR_TITULO { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
            /*"    03  FILLER                       REDEFINES    W-NUMR-TITULO.*/
            private _REDEF_VA4002B_FILLER_40 _filler_40 { get; set; }
            public _REDEF_VA4002B_FILLER_40 FILLER_40
            {
                get { _filler_40 = new _REDEF_VA4002B_FILLER_40(); _.Move(W_NUMR_TITULO, _filler_40); VarBasis.RedefinePassValue(W_NUMR_TITULO, _filler_40, W_NUMR_TITULO); _filler_40.ValueChanged += () => { _.Move(_filler_40, W_NUMR_TITULO); }; return _filler_40; }
                set { VarBasis.RedefinePassValue(value, _filler_40, W_NUMR_TITULO); }
            }  //Redefines
            public class _REDEF_VA4002B_FILLER_40 : VarBasis
            {
                /*"      05    WTITL-ZEROS              PIC  9(002).*/
                public IntBasis WTITL_ZEROS { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      05    WTITL-SEQUENCIA          PIC  9(010).*/
                public IntBasis WTITL_SEQUENCIA { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
                /*"      05    WTITL-DIGITO             PIC  9(001).*/
                public IntBasis WTITL_DIGITO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    03              DPARM01X.*/

                public _REDEF_VA4002B_FILLER_40()
                {
                    WTITL_ZEROS.ValueChanged += OnValueChanged;
                    WTITL_SEQUENCIA.ValueChanged += OnValueChanged;
                    WTITL_DIGITO.ValueChanged += OnValueChanged;
                }

            }
            public VA4002B_DPARM01X DPARM01X { get; set; } = new VA4002B_DPARM01X();
            public class VA4002B_DPARM01X : VarBasis
            {
                /*"      05            DPARM01          PIC  9(010).*/
                public IntBasis DPARM01 { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
                /*"      05            DPARM01-R        REDEFINES   DPARM01.*/
                private _REDEF_VA4002B_DPARM01_R _dparm01_r { get; set; }
                public _REDEF_VA4002B_DPARM01_R DPARM01_R
                {
                    get { _dparm01_r = new _REDEF_VA4002B_DPARM01_R(); _.Move(DPARM01, _dparm01_r); VarBasis.RedefinePassValue(DPARM01, _dparm01_r, DPARM01); _dparm01_r.ValueChanged += () => { _.Move(_dparm01_r, DPARM01); }; return _dparm01_r; }
                    set { VarBasis.RedefinePassValue(value, _dparm01_r, DPARM01); }
                }  //Redefines
                public class _REDEF_VA4002B_DPARM01_R : VarBasis
                {
                    /*"        10          DPARM01-1        PIC  9(001).*/
                    public IntBasis DPARM01_1 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        10          DPARM01-2        PIC  9(001).*/
                    public IntBasis DPARM01_2 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        10          DPARM01-3        PIC  9(001).*/
                    public IntBasis DPARM01_3 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        10          DPARM01-4        PIC  9(001).*/
                    public IntBasis DPARM01_4 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        10          DPARM01-5        PIC  9(001).*/
                    public IntBasis DPARM01_5 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        10          DPARM01-6        PIC  9(001).*/
                    public IntBasis DPARM01_6 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        10          DPARM01-7        PIC  9(001).*/
                    public IntBasis DPARM01_7 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        10          DPARM01-8        PIC  9(001).*/
                    public IntBasis DPARM01_8 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        10          DPARM01-9        PIC  9(001).*/
                    public IntBasis DPARM01_9 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        10          DPARM01-10       PIC  9(001).*/
                    public IntBasis DPARM01_10 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"      05            DPARM01-D1       PIC  9(001).*/

                    public _REDEF_VA4002B_DPARM01_R()
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
                /*"      05            DPARM01-RC       PIC S9(004) COMP VALUE +0.*/
                public IntBasis DPARM01_RC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"    03 PARM-PROSOMU1.*/
            }
            public VA4002B_PARM_PROSOMU1 PARM_PROSOMU1 { get; set; } = new VA4002B_PARM_PROSOMU1();
            public class VA4002B_PARM_PROSOMU1 : VarBasis
            {
                /*"      05 SU1-DATA1.*/
                public VA4002B_SU1_DATA1 SU1_DATA1 { get; set; } = new VA4002B_SU1_DATA1();
                public class VA4002B_SU1_DATA1 : VarBasis
                {
                    /*"        10 SU1-DD1                   PIC 99.*/
                    public IntBasis SU1_DD1 { get; set; } = new IntBasis(new PIC("9", "2", "99."));
                    /*"        10 SU1-MM1                   PIC 99.*/
                    public IntBasis SU1_MM1 { get; set; } = new IntBasis(new PIC("9", "2", "99."));
                    /*"        10 SU1-AA1                   PIC 9999.*/
                    public IntBasis SU1_AA1 { get; set; } = new IntBasis(new PIC("9", "4", "9999."));
                    /*"      05 SU1-NRDIAS                  PIC S9(5) COMP-3.*/
                }
                public IntBasis SU1_NRDIAS { get; set; } = new IntBasis(new PIC("S9", "5", "S9(5)"));
                /*"      05 SU1-DATA2.*/
                public VA4002B_SU1_DATA2 SU1_DATA2 { get; set; } = new VA4002B_SU1_DATA2();
                public class VA4002B_SU1_DATA2 : VarBasis
                {
                    /*"        10 SU1-DD2                   PIC 99.*/
                    public IntBasis SU1_DD2 { get; set; } = new IntBasis(new PIC("9", "2", "99."));
                    /*"        10 SU1-MM2                   PIC 99.*/
                    public IntBasis SU1_MM2 { get; set; } = new IntBasis(new PIC("9", "2", "99."));
                    /*"        10 SU1-AA2                   PIC 9999.*/
                    public IntBasis SU1_AA2 { get; set; } = new IntBasis(new PIC("9", "4", "9999."));
                    /*"01  WS-SQLCODE                    PIC  ---9.*/
                }
            }
        }
        public IntBasis WS_SQLCODE { get; set; } = new IntBasis(new PIC("9", "4", "---9."));
        /*"01     WS-NUM-TITULO-X.*/
        public VA4002B_WS_NUM_TITULO_X WS_NUM_TITULO_X { get; set; } = new VA4002B_WS_NUM_TITULO_X();
        public class VA4002B_WS_NUM_TITULO_X : VarBasis
        {
            /*"    05  WS-NUM-PLANO                  PIC  9(003).*/
            public IntBasis WS_NUM_PLANO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
            /*"    05  WS-NUM-SERIE                  PIC  9(003).*/
            public IntBasis WS_NUM_SERIE { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
            /*"    05  WS-NUM-TITULO                 PIC  9(006).*/
            public IntBasis WS_NUM_TITULO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"01     WS-NUM-TITULO-9               REDEFINES       WS-NUM-TITULO-X               PIC  9(012).*/
        }
        private _REDEF_IntBasis _ws_num_titulo_9 { get; set; }
        public _REDEF_IntBasis WS_NUM_TITULO_9
        {
            get { _ws_num_titulo_9 = new _REDEF_IntBasis(new PIC("9", "012", "9(012).")); ; _.Move(WS_NUM_TITULO_X, _ws_num_titulo_9); VarBasis.RedefinePassValue(WS_NUM_TITULO_X, _ws_num_titulo_9, WS_NUM_TITULO_X); _ws_num_titulo_9.ValueChanged += () => { _.Move(_ws_num_titulo_9, WS_NUM_TITULO_X); }; return _ws_num_titulo_9; }
            set { VarBasis.RedefinePassValue(value, _ws_num_titulo_9, WS_NUM_TITULO_X); }
        }  //Redefines
        /*"01     WS-COMBINACAO                 PIC  X(020).*/
        public StringBasis WS_COMBINACAO { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
        /*"01     WS-COMBINACAO-R               REDEFINES       WS-COMBINACAO.*/
        private _REDEF_VA4002B_WS_COMBINACAO_R _ws_combinacao_r { get; set; }
        public _REDEF_VA4002B_WS_COMBINACAO_R WS_COMBINACAO_R
        {
            get { _ws_combinacao_r = new _REDEF_VA4002B_WS_COMBINACAO_R(); _.Move(WS_COMBINACAO, _ws_combinacao_r); VarBasis.RedefinePassValue(WS_COMBINACAO, _ws_combinacao_r, WS_COMBINACAO); _ws_combinacao_r.ValueChanged += () => { _.Move(_ws_combinacao_r, WS_COMBINACAO); }; return _ws_combinacao_r; }
            set { VarBasis.RedefinePassValue(value, _ws_combinacao_r, WS_COMBINACAO); }
        }  //Redefines
        public class _REDEF_VA4002B_WS_COMBINACAO_R : VarBasis
        {
            /*"    05  WS-COMB OCCURS 20 TIMES       PIC  X(001).*/
            public ListBasis<StringBasis, string> WS_COMB { get; set; } = new ListBasis<StringBasis, string>(new PIC("X", "1", "X(001)."), 20);
            /*"01     WS-COMBINACAO-9               PIC  9(009).*/

            public _REDEF_VA4002B_WS_COMBINACAO_R()
            {
                WS_COMB.ValueChanged += OnValueChanged;
            }

        }
        public IntBasis WS_COMBINACAO_9 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
        /*"01  WABEND*/
        public VA4002B_WABEND WABEND { get; set; } = new VA4002B_WABEND();
        public class VA4002B_WABEND : VarBasis
        {
            /*"    05  FILLER.*/
            public VA4002B_FILLER_41 FILLER_41 { get; set; } = new VA4002B_FILLER_41();
            public class VA4002B_FILLER_41 : VarBasis
            {
                /*"      10    FILLER                   PIC  X(010) VALUE            'VA4002B  '.*/
                public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"VA4002B  ");
                /*"      10    FILLER                   PIC  X(028) VALUE            ' *** ERRO  EXEC SQL *** '.*/
                public StringBasis FILLER_43 { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @" *** ERRO  EXEC SQL *** ");
                /*"      10    FILLER                   PIC  X(014) VALUE            '    SQLCODE = '.*/
                public StringBasis FILLER_44 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE = ");
                /*"      10    WSQLCODE                 PIC  ZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
                /*"      10    FILLER                   PIC  X(014)   VALUE            '   SQLERRD1 = '.*/
                public StringBasis FILLER_45 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD1 = ");
                /*"      10    WSQLERRD1                PIC  ZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLERRD1 { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
                /*"      10    FILLER                   PIC  X(014)   VALUE            '   SQLERRD2 = '.*/
                public StringBasis FILLER_46 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD2 = ");
                /*"      10    WSQLERRD2                PIC  ZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLERRD2 { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
                /*"      10    FILLER                   PIC  X(014)   VALUE            '   SQLERRD3 = '.*/
                public StringBasis FILLER_47 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD3 = ");
                /*"      10    WSQLERRD3                PIC  ZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLERRD3 { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
                /*"      10    FILLER                   PIC  X(014)   VALUE            '   SQLERRD4 = '.*/
                public StringBasis FILLER_48 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD4 = ");
                /*"      10    WSQLERRD4                PIC  ZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLERRD4 { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
                /*"      10    FILLER                   PIC  X(014)   VALUE            '   SQLERRD5 = '.*/
                public StringBasis FILLER_49 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD5 = ");
                /*"      10    WSQLERRD5                PIC  ZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLERRD5 { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
                /*"    05      LOCALIZA-ABEND-1.*/
            }
            public VA4002B_LOCALIZA_ABEND_1 LOCALIZA_ABEND_1 { get; set; } = new VA4002B_LOCALIZA_ABEND_1();
            public class VA4002B_LOCALIZA_ABEND_1 : VarBasis
            {
                /*"      10    FILLER                   PIC  X(012)   VALUE            'PARAGRAFO = '.*/
                public StringBasis FILLER_50 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"PARAGRAFO = ");
                /*"      10    PARAGRAFO                PIC  X(040)   VALUE SPACES.*/
                public StringBasis PARAGRAFO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"    05      LOCALIZA-ABEND-2.*/
            }
            public VA4002B_LOCALIZA_ABEND_2 LOCALIZA_ABEND_2 { get; set; } = new VA4002B_LOCALIZA_ABEND_2();
            public class VA4002B_LOCALIZA_ABEND_2 : VarBasis
            {
                /*"      10    FILLER                   PIC  X(012)   VALUE            'COMANDO   = '.*/
                public StringBasis FILLER_51 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"COMANDO   = ");
                /*"      10    COMANDO                  PIC  X(060)   VALUE SPACES.*/
                public StringBasis COMANDO { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"");
                /*"01           FC0001S-LINKAGE.*/
            }
        }
        public VA4002B_FC0001S_LINKAGE FC0001S_LINKAGE { get; set; } = new VA4002B_FC0001S_LINKAGE();
        public class VA4002B_FC0001S_LINKAGE : VarBasis
        {
            /*"    05         FC0001S-NUM-PROPOSTA    PIC  S9(015)    COMP-3.*/
            public IntBasis FC0001S_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
            /*"    05         FC0001S-VLR-MENSALIDADE PIC  S9(008)V99 COMP-3.*/
            public DoubleBasis FC0001S_VLR_MENSALIDADE { get; set; } = new DoubleBasis(new PIC("S9", "8", "S9(008)V99"), 2);
            /*"    05         FC0001S-NUM-PLANO       PIC  S9(004) COMP.*/
            public IntBasis FC0001S_NUM_PLANO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05         FC0001S-NUM-SERIE       PIC  S9(004) COMP.*/
            public IntBasis FC0001S_NUM_SERIE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05         FC0001S-NUM-TITULO      PIC  S9(009) COMP.*/
            public IntBasis FC0001S_NUM_TITULO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"    05         FC0001S-IND-DV          PIC  S9(004) COMP.*/
            public IntBasis FC0001S_IND_DV { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05         FC0001S-DTH-INI-VIGENCIA PIC   X(010).*/
            public StringBasis FC0001S_DTH_INI_VIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    05         FC0001S-DTH-FIM-VIGENCIA PIC   X(010).*/
            public StringBasis FC0001S_DTH_FIM_VIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    05         FC0001S-DES-COMBINACAO  PIC   X(020).*/
            public StringBasis FC0001S_DES_COMBINACAO { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
            /*"    05         FC0001S-SQLCODE         PIC  S9(004) COMP.*/
            public IntBasis FC0001S_SQLCODE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05         FC0001S-COD-RETORNO     PIC  S9(004) COMP.*/
            public IntBasis FC0001S_COD_RETORNO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05         FC0001S-DES-MENSAGEM    PIC   X(070).*/
            public StringBasis FC0001S_DES_MENSAGEM { get; set; } = new StringBasis(new PIC("X", "70", "X(070)."), @"");
            /*"01         LK-NUM-PLANO            PIC S9(4)      USAGE COMP.*/
        }
        public IntBasis LK_NUM_PLANO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01         LK-NUM-SERIE            PIC S9(4)      USAGE COMP.*/
        public IntBasis LK_NUM_SERIE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01         LK-NUM-TITULO           PIC S9(9)      USAGE COMP.*/
        public IntBasis LK_NUM_TITULO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"01         LK-NUM-PROPOSTA         PIC S9(15)V    USAGE COMP-3.*/
        public DoubleBasis LK_NUM_PROPOSTA { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"01         LK-QTD-TITULOS          PIC S9(4)      USAGE COMP.*/
        public IntBasis LK_QTD_TITULOS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01         LK-VLR-TITULO           PIC S9(8)V9(2) USAGE COMP-3.*/
        public DoubleBasis LK_VLR_TITULO { get; set; } = new DoubleBasis(new PIC("S9", "8", "S9(8)V9(2)"), 2);
        /*"01         LK-EMP-PARCEIRA         PIC S9(4)      USAGE COMP.*/
        public IntBasis LK_EMP_PARCEIRA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01         LK-COD-RAMO             PIC S9(4)      USAGE COMP.*/
        public IntBasis LK_COD_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01         LK-TRACE                PIC X(009).*/

        public SelectorBasis LK_TRACE { get; set; } = new SelectorBasis("009")
        {
            Items = new List<SelectorItemBasis> {
                            /*" 88       LK-TRACE-ON             VALUE 'TRACE ON '. */
							new SelectorItemBasis("LK_TRACE_ON", "TRACE ON "),
							/*" 88       LK-TRACE-OFF            VALUE 'TRACE OFF'. */
							new SelectorItemBasis("LK_TRACE_OFF", "TRACE OFF")
                }
        };

        /*"01         LK-OUT-COD-RETORNO     PIC S9(004) COMP.*/
        public IntBasis LK_OUT_COD_RETORNO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         LK-OUT-SQLCODE         PIC S9(004) COMP.*/
        public IntBasis LK_OUT_SQLCODE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         LK-OUT-MENSAGEM        PIC X(070).*/
        public StringBasis LK_OUT_MENSAGEM { get; set; } = new StringBasis(new PIC("X", "70", "X(070)."), @"");
        /*"01         LK-OUT-SQLERRMC        PIC X(070).*/
        public StringBasis LK_OUT_SQLERRMC { get; set; } = new StringBasis(new PIC("X", "70", "X(070)."), @"");
        /*"01         LK-OUT-SQLSTATE        PIC X(005).*/
        public StringBasis LK_OUT_SQLSTATE { get; set; } = new StringBasis(new PIC("X", "5", "X(005)."), @"");


        public Dclgens.RCAPS RCAPS { get; set; } = new Dclgens.RCAPS();
        public Dclgens.RCAPCOMP RCAPCOMP { get; set; } = new Dclgens.RCAPCOMP();
        public Dclgens.MOVFEDCA MOVFEDCA { get; set; } = new Dclgens.MOVFEDCA();
        public Dclgens.TITFEDCA TITFEDCA { get; set; } = new Dclgens.TITFEDCA();
        public Dclgens.COMFEDCA COMFEDCA { get; set; } = new Dclgens.COMFEDCA();
        public Dclgens.PARFEDCA PARFEDCA { get; set; } = new Dclgens.PARFEDCA();
        public Dclgens.FCSERIE FCSERIE { get; set; } = new Dclgens.FCSERIE();
        public Dclgens.ERROSVID ERROSVID { get; set; } = new Dclgens.ERROSVID();
        public Dclgens.ERRPROVI ERRPROVI { get; set; } = new Dclgens.ERRPROVI();
        public Dclgens.COMISSOE COMISSOE { get; set; } = new Dclgens.COMISSOE();
        public Dclgens.MOVDEBCE MOVDEBCE { get; set; } = new Dclgens.MOVDEBCE();
        public Dclgens.PROPOVA PROPOVA { get; set; } = new Dclgens.PROPOVA();
        public Dclgens.PRODUVG PRODUVG { get; set; } = new Dclgens.PRODUVG();
        public Dclgens.PRODUTO PRODUTO { get; set; } = new Dclgens.PRODUTO();
        public Dclgens.OPCPAGVI OPCPAGVI { get; set; } = new Dclgens.OPCPAGVI();
        public Dclgens.SEGURVGA SEGURVGA { get; set; } = new Dclgens.SEGURVGA();
        public Dclgens.APOLICES APOLICES { get; set; } = new Dclgens.APOLICES();
        public Dclgens.CLIENTES CLIENTES { get; set; } = new Dclgens.CLIENTES();
        public Dclgens.SUBGVGAP SUBGVGAP { get; set; } = new Dclgens.SUBGVGAP();
        public Dclgens.PLAVAVGA PLAVAVGA { get; set; } = new Dclgens.PLAVAVGA();
        public Dclgens.MOVIMVGA MOVIMVGA { get; set; } = new Dclgens.MOVIMVGA();
        public Dclgens.CONTACOR CONTACOR { get; set; } = new Dclgens.CONTACOR();
        public Dclgens.FATURCON FATURCON { get; set; } = new Dclgens.FATURCON();
        public VA4002B_CPROPVA CPROPVA { get; set; } = new VA4002B_CPROPVA();
        public VA4002B_MOVTOVGAP MOVTOVGAP { get; set; } = new VA4002B_MOVTOVGAP();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string ARQEMIT_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                ARQEMIT.SetFile(ARQEMIT_FILE_NAME_P);

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
            /*" -1049- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -1052- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -1055- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -1058- DISPLAY '\\\\\\\\\\\\\\\\\\\\\\\\\/////////////////////////' */
            _.Display($"\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\/////////////////////////");

            /*" -1059- DISPLAY '\\                                              //' */
            _.Display($"\\\\                                              //");

            /*" -1060- DISPLAY '\\       PROGRAMA EM EXECUCAO = VA4002B         //' */
            _.Display($"\\\\       PROGRAMA EM EXECUCAO = VA4002B         //");

            /*" -1061- DISPLAY '\\                                              //' */
            _.Display($"\\\\                                              //");

            /*" -1064- DISPLAY '\\  VERSAO V.19 - DEMANDA 402.982 - 14/02/2023  //' */
            _.Display($"\\\\  VERSAO V.19 - DEMANDA 402.982 - 14/02/2023  //");

            /*" -1065- DISPLAY '\\                                              //' */
            _.Display($"\\\\                                              //");

            /*" -1067- DISPLAY '\\  COMPILACAO: ' FUNCTION WHEN-COMPILED '           //' */

            $"\\\\  COMPILACAO: FUNCTION{_.WhenCompiled()}           //"
            .Display();

            /*" -1078- DISPLAY '\\                                              //' */
            _.Display($"\\\\                                              //");

            /*" -1079- DISPLAY '\\                                              //' */
            _.Display($"\\\\                                              //");

            /*" -1081- DISPLAY '\\\\\\\\\\\\\\\\\\\\\\\\\/////////////////////////' */
            _.Display($"\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\/////////////////////////");

            /*" -1089- DISPLAY ' INICIOU PROCESSAMENTO EM ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2) */

            $" INICIOU PROCESSAMENTO EM {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
            .Display();

            /*" -1090- MOVE '0000-PRINCIPAL' TO PARAGRAFO. */
            _.Move("0000-PRINCIPAL", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1092- MOVE '0000-PRINCIPAL' TO COMANDO. */
            _.Move("0000-PRINCIPAL", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1114- PERFORM M_0000_PRINCIPAL_DB_SELECT_1 */

            M_0000_PRINCIPAL_DB_SELECT_1();

            /*" -1117- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1122- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


            /*" -1123- MOVE SISTEMA-CURRDATE TO W04DTSQL. */
            _.Move(SISTEMA_CURRDATE, WS_WORK_AREAS.W04DTSQL);

            /*" -1125- MOVE W04DDSQL TO SU1-DD1 WCURR-DATE-DD. */
            _.Move(WS_WORK_AREAS.W04DTSQL.W04DDSQL, WS_WORK_AREAS.PARM_PROSOMU1.SU1_DATA1.SU1_DD1, SISTEMA_CURRDATE_RD.WCURR_DATE_DD);

            /*" -1127- MOVE W04MMSQL TO SU1-MM1 WCURR-DATE-MM. */
            _.Move(WS_WORK_AREAS.W04DTSQL.W04MMSQL, WS_WORK_AREAS.PARM_PROSOMU1.SU1_DATA1.SU1_MM1, SISTEMA_CURRDATE_RD.WCURR_DATE_MM);

            /*" -1129- MOVE W04AASQL TO SU1-AA1 WCURR-DATE-AA. */
            _.Move(WS_WORK_AREAS.W04DTSQL.W04SASQL_R.W04AASQL, WS_WORK_AREAS.PARM_PROSOMU1.SU1_DATA1.SU1_AA1, SISTEMA_CURRDATE_RD.WCURR_DATE_AA);

            /*" -1130- MOVE ZEROES TO SU1-DATA2. */
            _.Move(0, WS_WORK_AREAS.PARM_PROSOMU1.SU1_DATA2);

            /*" -1131- PERFORM 0010-SOMA-DIAS THRU 0010-FIM 6 TIMES. */

            M_0010_SOMA_DIAS(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0010_FIM*/


            /*" -1132- MOVE SU1-DD2 TO W04DDSQL. */
            _.Move(WS_WORK_AREAS.PARM_PROSOMU1.SU1_DATA2.SU1_DD2, WS_WORK_AREAS.W04DTSQL.W04DDSQL);

            /*" -1133- MOVE SU1-MM2 TO W04MMSQL. */
            _.Move(WS_WORK_AREAS.PARM_PROSOMU1.SU1_DATA2.SU1_MM2, WS_WORK_AREAS.W04DTSQL.W04MMSQL);

            /*" -1135- MOVE SU1-AA2 TO W04AASQL. */
            _.Move(WS_WORK_AREAS.PARM_PROSOMU1.SU1_DATA2.SU1_AA2, WS_WORK_AREAS.W04DTSQL.W04SASQL_R.W04AASQL);

            /*" -1136- MOVE WCURR-DATE-AA TO WCURR-DATE8-AA. */
            _.Move(SISTEMA_CURRDATE_RD.WCURR_DATE_AA, SISTEMA_CURRDATE8_RD.WCURR_DATE8_AA);

            /*" -1137- MOVE WCURR-DATE-MM TO WCURR-DATE8-MM. */
            _.Move(SISTEMA_CURRDATE_RD.WCURR_DATE_MM, SISTEMA_CURRDATE8_RD.WCURR_DATE8_MM);

            /*" -1138- MOVE WCURR-DATE-DD TO WCURR-DATE8-DD. */
            _.Move(SISTEMA_CURRDATE_RD.WCURR_DATE_DD, SISTEMA_CURRDATE8_RD.WCURR_DATE8_DD);

            /*" -1141- COMPUTE CURRDATE-DIAS = FUNCTION INTEGER-OF-DATE(SISTEMA-CURRDATE-8) */
            CURRDATE_DIAS.Value = ((DateTime.ParseExact(SISTEMA_CURRDATE_8.ToString(), "yyyyMMdd", null) - new DateTime(1600, 12, 31)).Days);

            /*" -1151- PERFORM M_0000_PRINCIPAL_DB_SELECT_2 */

            M_0000_PRINCIPAL_DB_SELECT_2();

            /*" -1154- MOVE WMIN-PRXVEN-AA TO WMIN-PRXVEN8-AA */
            _.Move(MIN_PROXVEN_DATE_RD.WMIN_PRXVEN_AA, MIN_PROXVEN_DATE8_RD.WMIN_PRXVEN8_AA);

            /*" -1155- MOVE WMIN-PRXVEN-MM TO WMIN-PRXVEN8-MM */
            _.Move(MIN_PROXVEN_DATE_RD.WMIN_PRXVEN_MM, MIN_PROXVEN_DATE8_RD.WMIN_PRXVEN8_MM);

            /*" -1157- MOVE WMIN-PRXVEN-DD TO WMIN-PRXVEN8-DD */
            _.Move(MIN_PROXVEN_DATE_RD.WMIN_PRXVEN_DD, MIN_PROXVEN_DATE8_RD.WMIN_PRXVEN8_DD);

            /*" -1158- DISPLAY 'DATA PROCESSAMENTO.........:   ' SISTEMA-CURRDATE. */
            _.Display($"DATA PROCESSAMENTO.........:   {SISTEMA_CURRDATE}");

            /*" -1159- DISPLAY 'DATA SISTEMA VA ...........:   ' SISTEMA-DTMOVABE. */
            _.Display($"DATA SISTEMA VA ...........:   {SISTEMA_DTMOVABE}");

            /*" -1160- DISPLAY 'DATA DTMOVABE + 8   DIAS ..:   ' SISTEMA-DTMOVABE2. */
            _.Display($"DATA DTMOVABE + 8   DIAS ..:   {SISTEMA_DTMOVABE2}");

            /*" -1161- DISPLAY 'DATA DTMOVABE + 1   M�S  ..:   ' SISTEMA-DTMOVABE3. */
            _.Display($"DATA DTMOVABE + 1   M�S  ..:   {SISTEMA_DTMOVABE3}");

            /*" -1162- DISPLAY 'DATA DTMOVABE + 14  DIAS ..:   ' SISTEMA-DTMOV015D. */
            _.Display($"DATA DTMOVABE + 14  DIAS ..:   {SISTEMA_DTMOV015D}");

            /*" -1164- DISPLAY 'DATA DTMOVABE + 365 DIAS ..:   ' SISTEMA-DTMOV365D. */
            _.Display($"DATA DTMOVABE + 365 DIAS ..:   {SISTEMA_DTMOV365D}");

            /*" -1167- MOVE 'SELECT MAX V0SUBGRUPO' TO COMANDO. */
            _.Move("SELECT MAX V0SUBGRUPO", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1173- PERFORM M_0000_PRINCIPAL_DB_SELECT_3 */

            M_0000_PRINCIPAL_DB_SELECT_3();

            /*" -1176- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1178- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


            /*" -1181- MOVE 'SELECT V0BANCO' TO COMANDO. */
            _.Move("SELECT V0BANCO", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1187- PERFORM M_0000_PRINCIPAL_DB_SELECT_4 */

            M_0000_PRINCIPAL_DB_SELECT_4();

            /*" -1190- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1192- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


            /*" -1194- MOVE 'ABRINDO ARQUIVO' TO COMANDO. */
            _.Move("ABRINDO ARQUIVO", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1196- OPEN OUTPUT ARQEMIT. */
            ARQEMIT.Open(REG_ARQEMI, WS_WORK_AREAS.WS_STATUS);

            /*" -1197- IF WS-STATUS NOT EQUAL ZEROS */

            if (WS_WORK_AREAS.WS_STATUS != 00)
            {

                /*" -1198- DISPLAY 'ERRO NO OPEN OUTPUT DO ARQEMIT' */
                _.Display($"ERRO NO OPEN OUTPUT DO ARQEMIT");

                /*" -1199- DISPLAY 'STATUS - ' WS-STATUS */
                _.Display($"STATUS - {WS_WORK_AREAS.WS_STATUS}");

                /*" -1200- GO TO 9999-ERRO */

                M_9999_ERRO(); //GOTO
                return;

                /*" -1202- END-IF. */
            }


            /*" -1203- WRITE REG-ARQEMI FROM LD00. */
            _.Move(LD00.GetMoveValues(), REG_ARQEMI);

            ARQEMIT.Write(REG_ARQEMI.GetMoveValues().ToString());

            /*" -1205- WRITE REG-ARQEMI FROM LD01. */
            _.Move(LD01.GetMoveValues(), REG_ARQEMI);

            ARQEMIT.Write(REG_ARQEMI.GetMoveValues().ToString());

            /*" -1207- MOVE BANCOS-NRTIT TO W-NUMR-TITULO. */
            _.Move(BANCOS_NRTIT, WS_WORK_AREAS.W_NUMR_TITULO);

            /*" -1210- MOVE 'DECLARE CPROPVA' TO COMANDO. */
            _.Move("DECLARE CPROPVA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1272- PERFORM M_0000_PRINCIPAL_DB_DECLARE_1 */

            M_0000_PRINCIPAL_DB_DECLARE_1();

            /*" -1276- MOVE 'OPEN CPROPVA' TO COMANDO. */
            _.Move("OPEN CPROPVA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1277- DISPLAY COMANDO */
            _.Display(WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1277- PERFORM M_0000_PRINCIPAL_DB_OPEN_1 */

            M_0000_PRINCIPAL_DB_OPEN_1();

            /*" -1280- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1281- GO TO 9999-ERRO */

                M_9999_ERRO(); //GOTO
                return;

                /*" -1283- END-IF. */
            }


            /*" -1286- PERFORM 0110-FETCH THRU 0110-FIM. */

            M_0110_FETCH(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0110_FIM*/


            /*" -1289- PERFORM 0100-PROCESSA-PROPOSTA THRU 0100-FIM UNTIL WS-EOF = 1. */

            while (!(WS_WORK_AREAS.WS_EOF == 1))
            {

                M_0100_PROCESSA_PROPOSTA(true);

                M_0100_PROX(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0100_FIM*/

            }

            /*" -1292- MOVE 'UPDATE V0BANCO' TO COMANDO. */
            _.Move("UPDATE V0BANCO", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1297- PERFORM M_0000_PRINCIPAL_DB_UPDATE_1 */

            M_0000_PRINCIPAL_DB_UPDATE_1();

            /*" -1300- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -1302- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


            /*" -1304- PERFORM 9000-FINALIZA THRU 9000-FIM. */

            M_9000_FINALIZA(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_9000_FIM*/


            /*" -1306- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -1306- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" M-0000-PRINCIPAL-DB-SELECT-1 */
        public void M_0000_PRINCIPAL_DB_SELECT_1()
        {
            /*" -1114- EXEC SQL SELECT DTMOVABE, DTMOVABE , DTMOVABE + 8 DAYS, DTMOVABE + 1 MONTH, DTMOVABE + 14 DAYS, DTMOVABE + 365 DAYS INTO :SISTEMA-DTMOVABE, :SISTEMA-CURRDATE, :SISTEMA-DTMOVABE2, :SISTEMA-DTMOVABE3, :SISTEMA-DTMOV015D, :SISTEMA-DTMOV365D FROM SEGUROS.V0SISTEMA WHERE IDSISTEM = 'VA' WITH UR END-EXEC. */

            var m_0000_PRINCIPAL_DB_SELECT_1_Query1 = new M_0000_PRINCIPAL_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = M_0000_PRINCIPAL_DB_SELECT_1_Query1.Execute(m_0000_PRINCIPAL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMA_DTMOVABE, SISTEMA_DTMOVABE);
                _.Move(executed_1.SISTEMA_CURRDATE, SISTEMA_CURRDATE);
                _.Move(executed_1.SISTEMA_DTMOVABE2, SISTEMA_DTMOVABE2);
                _.Move(executed_1.SISTEMA_DTMOVABE3, SISTEMA_DTMOVABE3);
                _.Move(executed_1.SISTEMA_DTMOV015D, SISTEMA_DTMOV015D);
                _.Move(executed_1.SISTEMA_DTMOV365D, SISTEMA_DTMOV365D);
            }


        }

        [StopWatch]
        /*" M-0010-SOMA-DIAS */
        private void M_0010_SOMA_DIAS(bool isPerform = false)
        {
            /*" -1315- MOVE +1 TO SU1-NRDIAS. */
            _.Move(+1, WS_WORK_AREAS.PARM_PROSOMU1.SU1_NRDIAS);

            /*" -1316- CALL 'PROSOCU1' USING PARM-PROSOMU1. */
            _.Call("PROSOCU1", WS_WORK_AREAS.PARM_PROSOMU1);

            /*" -1316- MOVE SU1-DATA2 TO SU1-DATA1. */
            _.Move(WS_WORK_AREAS.PARM_PROSOMU1.SU1_DATA2, WS_WORK_AREAS.PARM_PROSOMU1.SU1_DATA1);

        }

        [StopWatch]
        /*" M-0000-PRINCIPAL-DB-SELECT-2 */
        public void M_0000_PRINCIPAL_DB_SELECT_2()
        {
            /*" -1151- EXEC SQL SELECT VALUE(MIN(DATA_CALENDARIO), CURRENT DATE) INTO :MIN-PROXVEN-DATE FROM SEGUROS.CALENDARIO WHERE DATA_CALENDARIO >= (SELECT CURRENT DATE + 30 DAYS FROM SYSIBM.SYSDUMMY1) AND FERIADO <> 'N' AND DIA_SEMANA NOT IN( 'S' , 'D' ) WITH UR END-EXEC */

            var m_0000_PRINCIPAL_DB_SELECT_2_Query1 = new M_0000_PRINCIPAL_DB_SELECT_2_Query1()
            {
            };

            var executed_1 = M_0000_PRINCIPAL_DB_SELECT_2_Query1.Execute(m_0000_PRINCIPAL_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.MIN_PROXVEN_DATE, MIN_PROXVEN_DATE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0010_FIM*/

        [StopWatch]
        /*" M-0000-PRINCIPAL-DB-DECLARE-1 */
        public void M_0000_PRINCIPAL_DB_DECLARE_1()
        {
            /*" -1272- EXEC SQL DECLARE CPROPVA CURSOR FOR SELECT NUM_APOLICE, CODSUBES, NRCERTIF, CODPRODU, CODCLIEN, OCOREND, FONTE, AGECOBR, OPCAO_COBER, DTQITBCO, DTQITBCO + 6 MONTHS, DTQITBCO + 1 MONTH, DTQITBCO + 365 DAYS, DTQITBCO + 15 DAYS, DTPROXVEN, DTQITBCO + 30 DAYS, NRMATRVEN, CODOPER, DTINCLUS, DTMOVTO, SITUACAO, NUM_APOLICE, CODSUBES, OCORHIST, NRPARCE, SIT_INTERFACE, TIMESTAMP, IDADE, IDE_SEXO, ESTADO_CIVIL, COD_CRM, NUM_MATRICULA, DATA_ADMISSAO, VALUE(NRPROPOS, 0), COD_CCT, CODUSU, DTVENCTO, FAIXA_RENDA_IND, DATE(TIMESTAMP), VALUE(DPS_TITULAR, '       ' ), COD_ORIGEM_PROPOSTA, VALUE(STA_ANTECIPACAO, ' ' ) FROM SEGUROS.V0PROPOSTAVA WHERE NRCERTIF > 0 AND SITUACAO IN( '1' , '9' ) AND CODPRODU NOT IN(SELECT RM.COD_PRODUTO FROM SEGUROS.PRODUTO RM WHERE RM.RAMO_EMISSOR = 77) FOR UPDATE OF CODPRODU, CODOPER, DTMOVTO, DTPROXVEN, SITUACAO, CODSUBES, NRPARCE, SIT_INTERFACE, TIMESTAMP, DTVENCTO END-EXEC. */
            CPROPVA = new VA4002B_CPROPVA(false);
            string GetQuery_CPROPVA()
            {
                var query = @$"SELECT NUM_APOLICE
							, 
							CODSUBES
							, 
							NRCERTIF
							, 
							CODPRODU
							, 
							CODCLIEN
							, 
							OCOREND
							, 
							FONTE
							, 
							AGECOBR
							, 
							OPCAO_COBER
							, 
							DTQITBCO
							, 
							DTQITBCO + 6 MONTHS
							, 
							DTQITBCO + 1 MONTH
							, 
							DTQITBCO + 365 DAYS
							, 
							DTQITBCO + 15 DAYS
							, 
							DTPROXVEN
							, 
							DTQITBCO + 30 DAYS
							, 
							NRMATRVEN
							, 
							CODOPER
							, 
							DTINCLUS
							, 
							DTMOVTO
							, 
							SITUACAO
							, 
							NUM_APOLICE
							, 
							CODSUBES
							, 
							OCORHIST
							, 
							NRPARCE
							, 
							SIT_INTERFACE
							, 
							TIMESTAMP
							, 
							IDADE
							, 
							IDE_SEXO
							, 
							ESTADO_CIVIL
							, 
							COD_CRM
							, 
							NUM_MATRICULA
							, 
							DATA_ADMISSAO
							, 
							VALUE(NRPROPOS
							, 0)
							, 
							COD_CCT
							, 
							CODUSU
							, 
							DTVENCTO
							, 
							FAIXA_RENDA_IND
							, 
							DATE(TIMESTAMP)
							, 
							VALUE(DPS_TITULAR
							, ' ' )
							, 
							COD_ORIGEM_PROPOSTA
							, 
							VALUE(STA_ANTECIPACAO
							, ' ' ) 
							FROM SEGUROS.V0PROPOSTAVA 
							WHERE 
							NRCERTIF > 0 
							AND SITUACAO IN( '1'
							, '9' ) 
							AND CODPRODU NOT IN(SELECT RM.COD_PRODUTO 
							FROM SEGUROS.PRODUTO RM 
							WHERE RM.RAMO_EMISSOR = 77)";

                return query;
            }
            CPROPVA.GetQueryEvent += GetQuery_CPROPVA;

        }

        [StopWatch]
        /*" M-0000-PRINCIPAL-DB-OPEN-1 */
        public void M_0000_PRINCIPAL_DB_OPEN_1()
        {
            /*" -1277- EXEC SQL OPEN CPROPVA END-EXEC. */

            CPROPVA.Open();

        }

        [StopWatch]
        /*" M-1400-ATUALIZA-MOVIMENTO-DB-DECLARE-1 */
        public void M_1400_ATUALIZA_MOVIMENTO_DB_DECLARE_1()
        {
            /*" -2044- EXEC SQL DECLARE MOVTOVGAP CURSOR FOR SELECT NUM_CERTIFICADO , COD_OPERACAO , DATA_AVERBACAO , DATA_INCLUSAO , DATA_NASCIMENTO , DATA_REFERENCIA IMPDIT FROM SEGUROS.MOVIMENTO_VGAP WHERE NUM_CERTIFICADO = :PROPVA-NRCERTIF AND DATA_AVERBACAO IS NOT NULL AND DATA_INCLUSAO IS NULL AND COD_OPERACAO >= 100 AND COD_OPERACAO <= 299 WITH UR END-EXEC */
            MOVTOVGAP = new VA4002B_MOVTOVGAP(true);
            string GetQuery_MOVTOVGAP()
            {
                var query = @$"SELECT NUM_CERTIFICADO
							, 
							COD_OPERACAO
							, 
							DATA_AVERBACAO
							, 
							DATA_INCLUSAO
							, 
							DATA_NASCIMENTO
							, 
							DATA_REFERENCIA 
							IMPDIT 
							FROM SEGUROS.MOVIMENTO_VGAP 
							WHERE NUM_CERTIFICADO = '{WS_AUXILIARES_HOST.PROPVA_NRCERTIF}' 
							AND DATA_AVERBACAO IS NOT NULL 
							AND DATA_INCLUSAO IS NULL 
							AND COD_OPERACAO >= 100 
							AND COD_OPERACAO <= 299";

                return query;
            }
            MOVTOVGAP.GetQueryEvent += GetQuery_MOVTOVGAP;

        }

        [StopWatch]
        /*" M-0000-PRINCIPAL-DB-UPDATE-1 */
        public void M_0000_PRINCIPAL_DB_UPDATE_1()
        {
            /*" -1297- EXEC SQL UPDATE SEGUROS.V0BANCO SET NRTIT = :BANCOS-NRTIT, TIMESTAMP = CURRENT TIMESTAMP WHERE BANCO = 104 END-EXEC. */

            var m_0000_PRINCIPAL_DB_UPDATE_1_Update1 = new M_0000_PRINCIPAL_DB_UPDATE_1_Update1()
            {
                BANCOS_NRTIT = BANCOS_NRTIT.ToString(),
            };

            M_0000_PRINCIPAL_DB_UPDATE_1_Update1.Execute(m_0000_PRINCIPAL_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" M-0000-PRINCIPAL-DB-SELECT-3 */
        public void M_0000_PRINCIPAL_DB_SELECT_3()
        {
            /*" -1173- EXEC SQL SELECT VALUE(MAX(COD_SUBGRUPO),0) INTO :SUBGRU-CODSUBES FROM SEGUROS.V0SUBGRUPO WHERE NUM_APOLICE = 0109700000024 WITH UR END-EXEC. */

            var m_0000_PRINCIPAL_DB_SELECT_3_Query1 = new M_0000_PRINCIPAL_DB_SELECT_3_Query1()
            {
            };

            var executed_1 = M_0000_PRINCIPAL_DB_SELECT_3_Query1.Execute(m_0000_PRINCIPAL_DB_SELECT_3_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SUBGRU_CODSUBES, SUBGRU_CODSUBES);
            }


        }

        [StopWatch]
        /*" M-0100-PROCESSA-PROPOSTA */
        private void M_0100_PROCESSA_PROPOSTA(bool isPerform = false)
        {
            /*" -1326- MOVE '0100-PROCESSA-PROPOSTA' TO COMANDO. */
            _.Move("0100-PROCESSA-PROPOSTA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1329- MOVE '0100-PROCESSA-PROPOSTA' TO PARAGRAFO. */
            _.Move("0100-PROCESSA-PROPOSTA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1332- ADD 1 TO AC-LIDOS. */
            WS_WORK_AREAS.AC_LIDOS.Value = WS_WORK_AREAS.AC_LIDOS + 1;

            /*" -1334- MOVE 'N' TO WS-LEITUA-SIVPF. */
            _.Move("N", WS_WORK_AREAS.WS_LEITUA_SIVPF);

            /*" -1335- MOVE PROPVA-DTQITBCO TO QUITACAO-DATE. */
            _.Move(WS_AUXILIARES_HOST.PROPVA_DTQITBCO, QUITACAO_DATE);

            /*" -1336- MOVE WDTQUIT-AA TO WDTQUIT8-AA. */
            _.Move(QUITACAO_DATE_RD.WDTQUIT_AA, QUITACAO_DATE8_RD.WDTQUIT8_AA);

            /*" -1337- MOVE WDTQUIT-MM TO WDTQUIT8-MM. */
            _.Move(QUITACAO_DATE_RD.WDTQUIT_MM, QUITACAO_DATE8_RD.WDTQUIT8_MM);

            /*" -1338- MOVE WDTQUIT-DD TO WDTQUIT8-DD. */
            _.Move(QUITACAO_DATE_RD.WDTQUIT_DD, QUITACAO_DATE8_RD.WDTQUIT8_DD);

            /*" -1340- COMPUTE QUITACAO-DIAS = FUNCTION INTEGER-OF-DATE(QUITACAO-DATE-8). */
            QUITACAO_DIAS.Value = ((DateTime.ParseExact(QUITACAO_DATE_8.ToString(), "yyyyMMdd", null) - new DateTime(1600, 12, 31)).Days);

            /*" -1343- COMPUTE PRAZO-DIAS = CURRDATE-DIAS - QUITACAO-DIAS. */
            PRAZO_DIAS.Value = CURRDATE_DIAS - QUITACAO_DIAS;

            /*" -1344- IF PRAZO-DIAS >= 15 */

            if (PRAZO_DIAS >= 15)
            {

                /*" -1345- IF PROPVA-CODCLIEN EQUAL 9999 */

                if (WS_AUXILIARES_HOST.PROPVA_CODCLIEN == 9999)
                {

                    /*" -1347- DISPLAY 'CLIENTE 9999, NAO PODE ACEITAR PROPOSTA' */
                    _.Display($"CLIENTE 9999, NAO PODE ACEITAR PROPOSTA");

                    /*" -1348- DISPLAY 'CERTIFICADO ' PROPVA-NRCERTIF */
                    _.Display($"CERTIFICADO {WS_AUXILIARES_HOST.PROPVA_NRCERTIF}");

                    /*" -1349- PERFORM 1060-UPD-PROPOSTA THRU 1060-FIM */

                    M_1060_UPD_PROPOSTA(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1060_FIM*/


                    /*" -1350- GO TO 0100-PROX */

                    M_0100_PROX(); //GOTO
                    return;

                    /*" -1351- END-IF */
                }


                /*" -1352- ELSE */
            }
            else
            {


                /*" -1353- GO TO 0100-PROX */

                M_0100_PROX(); //GOTO
                return;

                /*" -1355- END-IF. */
            }


            /*" -1359- PERFORM 2000-PESQUISA-OPCPAG THRU 2000-FIM. */

            M_2000_PESQUISA_OPCPAG(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_2000_FIM*/


            /*" -1360- IF OPCAOP-OPCAOPAG EQUAL '5' */

            if (WS_AUXILIARES_HOST.OPCAOP_OPCAOPAG == "5")
            {

                /*" -1361- MOVE 1 TO WS-COUNTRCAP */
                _.Move(1, WS_AUX_ADORMECIDAS.WS_COUNTRCAP);

                /*" -1362- ELSE */
            }
            else
            {


                /*" -1363- PERFORM 2010-VERIFICA-RCAP THRU 2010-FIM */

                M_2010_VERIFICA_RCAP(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_2010_FIM*/


                /*" -1370- END-IF */
            }


            /*" -1376- IF OPCAOP-PERIPGTO EQUAL 12 AND PRAZO-DIAS GREATER 365 */

            if (WS_AUXILIARES_HOST.OPCAOP_PERIPGTO == 12 && PRAZO_DIAS > 365)
            {

                /*" -1377- PERFORM 1200-CANCELA-PROPOSTA THRU 1200-FIM */

                M_1200_CANCELA_PROPOSTA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1200_FIM*/


                /*" -1378- GO TO 0100-PROX */

                M_0100_PROX(); //GOTO
                return;

                /*" -1385- END-IF. */
            }


            /*" -1386- IF WS-COUNTRCAP GREATER ZEROS */

            if (WS_AUX_ADORMECIDAS.WS_COUNTRCAP > 00)
            {

                /*" -1387- IF PRAZO-DIAS NOT GREATER 365 */

                if (PRAZO_DIAS <= 365)
                {

                    /*" -1390- IF PROPVA-STA-ANTECIPACAO = 'S' */

                    if (WS_AUXILIARES_HOST.PROPVA_STA_ANTECIPACAO == "S")
                    {

                        /*" -1391- PERFORM 1300-INTEGRA-PROPOSTA THRU 1300-FIM */

                        M_1300_INTEGRA_PROPOSTA(true);
                        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1300_FIM*/


                        /*" -1392- GO TO 0100-PROX */

                        M_0100_PROX(); //GOTO
                        return;

                        /*" -1393- END-IF */
                    }


                    /*" -1397- IF OPCAOP-PERIPGTO EQUAL 1 OR 12 OR 0 */

                    if (WS_AUXILIARES_HOST.OPCAOP_PERIPGTO.In("1", "12", "0"))
                    {

                        /*" -1398- PERFORM 1300-INTEGRA-PROPOSTA THRU 1300-FIM */

                        M_1300_INTEGRA_PROPOSTA(true);
                        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1300_FIM*/


                        /*" -1399- GO TO 0100-PROX */

                        M_0100_PROX(); //GOTO
                        return;

                        /*" -1400- END-IF */
                    }


                    /*" -1402- ELSE */
                }
                else
                {


                    /*" -1404- IF (OPCAOP-PERIPGTO EQUAL 12 OR 0) OR (PROPVA-STA-ANTECIPACAO = 'S' ) */

                    if ((WS_AUXILIARES_HOST.OPCAOP_PERIPGTO.In("12", "0")) || (WS_AUXILIARES_HOST.PROPVA_STA_ANTECIPACAO == "S"))
                    {

                        /*" -1407- PERFORM 1360-UPDATE-PERIPGTO THRU 1360-FIM */

                        M_1360_UPDATE_PERIPGTO(true);
                        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1360_FIM*/


                        /*" -1408- PERFORM 1300-INTEGRA-PROPOSTA THRU 1300-FIM */

                        M_1300_INTEGRA_PROPOSTA(true);
                        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1300_FIM*/


                        /*" -1409- GO TO 0100-PROX */

                        M_0100_PROX(); //GOTO
                        return;

                        /*" -1414- ELSE */
                    }
                    else
                    {


                        /*" -1415- PERFORM 1200-CANCELA-PROPOSTA THRU 1200-FIM */

                        M_1200_CANCELA_PROPOSTA(true);
                        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1200_FIM*/


                        /*" -1416- GO TO 0100-PROX */

                        M_0100_PROX(); //GOTO
                        return;

                        /*" -1417- END-IF */
                    }


                    /*" -1418- END-IF */
                }


                /*" -1423- ELSE */
            }
            else
            {


                /*" -1424- PERFORM 1200-CANCELA-PROPOSTA THRU 1200-FIM */

                M_1200_CANCELA_PROPOSTA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1200_FIM*/


                /*" -1425- GO TO 0100-PROX */

                M_0100_PROX(); //GOTO
                return;

                /*" -1427- END-IF. */
            }


            /*" -1427- PERFORM 1400-ATUALIZA-MOVIMENTO. */

            M_1400_ATUALIZA_MOVIMENTO(true);

        }

        [StopWatch]
        /*" M-0000-PRINCIPAL-DB-SELECT-4 */
        public void M_0000_PRINCIPAL_DB_SELECT_4()
        {
            /*" -1187- EXEC SQL SELECT NRTIT INTO :BANCOS-NRTIT FROM SEGUROS.V0BANCO WHERE BANCO = 104 WITH UR END-EXEC. */

            var m_0000_PRINCIPAL_DB_SELECT_4_Query1 = new M_0000_PRINCIPAL_DB_SELECT_4_Query1()
            {
            };

            var executed_1 = M_0000_PRINCIPAL_DB_SELECT_4_Query1.Execute(m_0000_PRINCIPAL_DB_SELECT_4_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.BANCOS_NRTIT, BANCOS_NRTIT);
            }


        }

        [StopWatch]
        /*" M-0100-PROX */
        private void M_0100_PROX(bool isPerform = false)
        {
            /*" -1431- PERFORM 0110-FETCH THRU 0110-FIM. */

            M_0110_FETCH(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0110_FIM*/


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0100_FIM*/

        [StopWatch]
        /*" M-0110-FETCH */
        private void M_0110_FETCH(bool isPerform = false)
        {
            /*" -1441- MOVE '0110-FETCH' TO PARAGRAFO. */
            _.Move("0110-FETCH", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1444- MOVE 'FETCH CPROPVA' TO COMANDO. */
            _.Move("FETCH CPROPVA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1488- PERFORM M_0110_FETCH_DB_FETCH_1 */

            M_0110_FETCH_DB_FETCH_1();

            /*" -1491- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1492- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1493- MOVE 1 TO WS-EOF */
                    _.Move(1, WS_WORK_AREAS.WS_EOF);

                    /*" -1494- MOVE 'CLOSE CPROPVA' TO COMANDO */
                    _.Move("CLOSE CPROPVA", WABEND.LOCALIZA_ABEND_2.COMANDO);

                    /*" -1494- PERFORM M_0110_FETCH_DB_CLOSE_1 */

                    M_0110_FETCH_DB_CLOSE_1();

                    /*" -1496- GO TO 0110-FIM */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0110_FIM*/ //GOTO
                    return;

                    /*" -1497- ELSE */
                }
                else
                {


                    /*" -1498- GO TO 9999-ERRO */

                    M_9999_ERRO(); //GOTO
                    return;

                    /*" -1499- END-IF */
                }


                /*" -1499- END-IF. */
            }


        }

        [StopWatch]
        /*" M-0110-FETCH-DB-FETCH-1 */
        public void M_0110_FETCH_DB_FETCH_1()
        {
            /*" -1488- EXEC SQL FETCH CPROPVA INTO :PROPVA-NUM-APOLICE, :PROPVA-CODSUBES, :PROPVA-NRCERTIF, :PROPVA-CODPRODU, :PROPVA-CODCLIEN, :PROPVA-OCOREND, :PROPVA-FONTE, :PROPVA-AGECOBR, :PROPVA-OPCAO-COBER, :PROPVA-DTQITBCO, :PROPVA-DTINICDG, :PROPVA-DTINISAF, :PROPVA-DT365DIAS, :PROPVA-DT015DIAS, :PROPVA-DTPROXVEN, :PROPVA-DTMINVEN, :PROPVA-NRMATRVEN, :PROPVA-CODOPER, :PROPVA-DTINCLUS, :PROPVA-DTMOVTO, :PROPVA-SITUACAO, :PROPVA-NUM-APOLICE, :PROPVA-CODSUBES, :PROPVA-OCORHIST, :PROPVA-NRPARCEL, :PROPVA-SIT-INTERF, :PROPVA-TIMESTAMP, :PROPVA-IDADE, :PROPVA-SEXO, :PROPVA-EST-CIV, :PROPVA-COD-CRM:VIND-COD-CRM, :PROPVA-NRMATRFUN:PROPVA-INRMATRFUN, :PROPVA-DTADMIS:PROPVA-IDTADMIS, :PROPVA-NRPROPOS, :PROPVA-CODCCT:PROPVA-ICODCCT, :PROPVA-CODUSU, :PROPVA-DTVENCTO, :PROPVA-FAIXA-RENDA-IND:VIND-FAIXA-RENDA, :PROPVA-DATA, :PROPVA-DPS-TITULAR, :PROPVA-ORIGEM-PROPOSTA:VIND-ORIGEM, :PROPVA-STA-ANTECIPACAO:VIND-ANTECIP END-EXEC. */

            if (CPROPVA.Fetch())
            {
                _.Move(CPROPVA.PROPVA_NUM_APOLICE, WS_AUXILIARES_HOST.PROPVA_NUM_APOLICE);
                _.Move(CPROPVA.PROPVA_CODSUBES, WS_AUXILIARES_HOST.PROPVA_CODSUBES);
                _.Move(CPROPVA.PROPVA_NRCERTIF, WS_AUXILIARES_HOST.PROPVA_NRCERTIF);
                _.Move(CPROPVA.PROPVA_CODPRODU, WS_AUXILIARES_HOST.PROPVA_CODPRODU);
                _.Move(CPROPVA.PROPVA_CODCLIEN, WS_AUXILIARES_HOST.PROPVA_CODCLIEN);
                _.Move(CPROPVA.PROPVA_OCOREND, WS_AUXILIARES_HOST.PROPVA_OCOREND);
                _.Move(CPROPVA.PROPVA_FONTE, WS_AUXILIARES_HOST.PROPVA_FONTE);
                _.Move(CPROPVA.PROPVA_AGECOBR, WS_AUXILIARES_HOST.PROPVA_AGECOBR);
                _.Move(CPROPVA.PROPVA_OPCAO_COBER, WS_AUXILIARES_HOST.PROPVA_OPCAO_COBER);
                _.Move(CPROPVA.PROPVA_DTQITBCO, WS_AUXILIARES_HOST.PROPVA_DTQITBCO);
                _.Move(CPROPVA.PROPVA_DTINICDG, WS_AUXILIARES_HOST.PROPVA_DTINICDG);
                _.Move(CPROPVA.PROPVA_DTINISAF, WS_AUXILIARES_HOST.PROPVA_DTINISAF);
                _.Move(CPROPVA.PROPVA_DT365DIAS, WS_AUXILIARES_HOST.PROPVA_DT365DIAS);
                _.Move(CPROPVA.PROPVA_DT015DIAS, WS_AUXILIARES_HOST.PROPVA_DT015DIAS);
                _.Move(CPROPVA.PROPVA_DTPROXVEN, WS_AUXILIARES_HOST.PROPVA_DTPROXVEN);
                _.Move(CPROPVA.PROPVA_DTMINVEN, WS_AUXILIARES_HOST.PROPVA_DTMINVEN);
                _.Move(CPROPVA.PROPVA_NRMATRVEN, WS_AUXILIARES_HOST.PROPVA_NRMATRVEN);
                _.Move(CPROPVA.PROPVA_CODOPER, WS_AUXILIARES_HOST.PROPVA_CODOPER);
                _.Move(CPROPVA.PROPVA_DTINCLUS, WS_AUXILIARES_HOST.PROPVA_DTINCLUS);
                _.Move(CPROPVA.PROPVA_DTMOVTO, WS_AUXILIARES_HOST.PROPVA_DTMOVTO);
                _.Move(CPROPVA.PROPVA_SITUACAO, WS_AUXILIARES_HOST.PROPVA_SITUACAO);
                _.Move(CPROPVA.PROPVA_NUM_APOLICE, WS_AUXILIARES_HOST.PROPVA_NUM_APOLICE);
                _.Move(CPROPVA.PROPVA_CODSUBES, WS_AUXILIARES_HOST.PROPVA_CODSUBES);
                _.Move(CPROPVA.PROPVA_OCORHIST, WS_AUXILIARES_HOST.PROPVA_OCORHIST);
                _.Move(CPROPVA.PROPVA_NRPARCEL, WS_AUXILIARES_HOST.PROPVA_NRPARCEL);
                _.Move(CPROPVA.PROPVA_SIT_INTERF, WS_AUXILIARES_HOST.PROPVA_SIT_INTERF);
                _.Move(CPROPVA.PROPVA_TIMESTAMP, WS_AUXILIARES_HOST.PROPVA_TIMESTAMP);
                _.Move(CPROPVA.PROPVA_IDADE, WS_AUXILIARES_HOST.PROPVA_IDADE);
                _.Move(CPROPVA.PROPVA_SEXO, WS_AUXILIARES_HOST.PROPVA_SEXO);
                _.Move(CPROPVA.PROPVA_EST_CIV, WS_AUXILIARES_HOST.PROPVA_EST_CIV);
                _.Move(CPROPVA.PROPVA_COD_CRM, WS_AUXILIARES_HOST.PROPVA_COD_CRM);
                _.Move(CPROPVA.VIND_COD_CRM, WS_AUXILIARES.VIND_COD_CRM);
                _.Move(CPROPVA.PROPVA_NRMATRFUN, WS_AUXILIARES_HOST.PROPVA_NRMATRFUN);
                _.Move(CPROPVA.PROPVA_INRMATRFUN, WS_AUXILIARES_HOST.PROPVA_INRMATRFUN);
                _.Move(CPROPVA.PROPVA_DTADMIS, WS_AUXILIARES_HOST.PROPVA_DTADMIS);
                _.Move(CPROPVA.PROPVA_IDTADMIS, WS_AUXILIARES_HOST.PROPVA_IDTADMIS);
                _.Move(CPROPVA.PROPVA_NRPROPOS, WS_AUXILIARES_HOST.PROPVA_NRPROPOS);
                _.Move(CPROPVA.PROPVA_CODCCT, WS_AUXILIARES_HOST.PROPVA_CODCCT);
                _.Move(CPROPVA.PROPVA_ICODCCT, WS_AUXILIARES_HOST.PROPVA_ICODCCT);
                _.Move(CPROPVA.PROPVA_CODUSU, WS_AUXILIARES_HOST.PROPVA_CODUSU);
                _.Move(CPROPVA.PROPVA_DTVENCTO, WS_AUXILIARES_HOST.PROPVA_DTVENCTO);
                _.Move(CPROPVA.PROPVA_FAIXA_RENDA_IND, WS_AUXILIARES_HOST.PROPVA_FAIXA_RENDA_IND);
                _.Move(CPROPVA.VIND_FAIXA_RENDA, WS_AUXILIARES.VIND_FAIXA_RENDA);
                _.Move(CPROPVA.PROPVA_DATA, WS_AUXILIARES_HOST.PROPVA_DATA);
                _.Move(CPROPVA.PROPVA_DPS_TITULAR, WS_AUXILIARES_HOST.PROPVA_DPS_TITULAR);
                _.Move(CPROPVA.PROPVA_ORIGEM_PROPOSTA, WS_AUXILIARES_HOST.PROPVA_ORIGEM_PROPOSTA);
                _.Move(CPROPVA.VIND_ORIGEM, WS_AUXILIARES.VIND_ORIGEM);
                _.Move(CPROPVA.PROPVA_STA_ANTECIPACAO, WS_AUXILIARES_HOST.PROPVA_STA_ANTECIPACAO);
                _.Move(CPROPVA.VIND_ANTECIP, WS_AUXILIARES.VIND_ANTECIP);
            }

        }

        [StopWatch]
        /*" M-0110-FETCH-DB-CLOSE-1 */
        public void M_0110_FETCH_DB_CLOSE_1()
        {
            /*" -1494- EXEC SQL CLOSE CPROPVA END-EXEC */

            CPROPVA.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0110_FIM*/

        [StopWatch]
        /*" M-1050-COUNT-ERRPROVI */
        private void M_1050_COUNT_ERRPROVI(bool isPerform = false)
        {
            /*" -1512- MOVE '1050-COUNT-ERRPROVI' TO COMANDO. */
            _.Move("1050-COUNT-ERRPROVI", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1531- MOVE 'N' TO WTEM-ERRO. */
            _.Move("N", WTEM_ERRO);

            /*" -1543- PERFORM M_1050_COUNT_ERRPROVI_DB_SELECT_1 */

            M_1050_COUNT_ERRPROVI_DB_SELECT_1();

            /*" -1546- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -1547- MOVE 'S' TO WTEM-ERRO */
                _.Move("S", WTEM_ERRO);

                /*" -1548- ELSE */
            }
            else
            {


                /*" -1550- IF SQLCODE NOT EQUAL ZEROS AND SQLCODE NOT EQUAL 100 */

                if (DB.SQLCODE != 00 && DB.SQLCODE != 100)
                {

                    /*" -1551- GO TO 9999-ERRO */

                    M_9999_ERRO(); //GOTO
                    return;

                    /*" -1552- END-IF */
                }


                /*" -1553- END-IF. */
            }


        }

        [StopWatch]
        /*" M-1050-COUNT-ERRPROVI-DB-SELECT-1 */
        public void M_1050_COUNT_ERRPROVI_DB_SELECT_1()
        {
            /*" -1543- EXEC SQL SELECT SUBSTR(VALUE(B.DES_ABREV_MSG_CRITICA, ' ' ),1,40) INTO :ERROSVID-DESCR-ERRO FROM SEGUROS.VG_CRITICA_PROPOSTA A, SEGUROS.VG_DM_MSG_CRITICA B WHERE A.NUM_CERTIFICADO = :PROPVA-NRCERTIF AND A.COD_MSG_CRITICA IN (401,402,501,1301,1811, 1872,1873,1874,1875) AND A.STA_CRITICA IN ( '0' , '1' , '2' , '4' , '5' , '8' ) AND B.COD_MSG_CRITICA = A.COD_MSG_CRITICA FETCH FIRST 1 ROW ONLY WITH UR END-EXEC. */

            var m_1050_COUNT_ERRPROVI_DB_SELECT_1_Query1 = new M_1050_COUNT_ERRPROVI_DB_SELECT_1_Query1()
            {
                PROPVA_NRCERTIF = WS_AUXILIARES_HOST.PROPVA_NRCERTIF.ToString(),
            };

            var executed_1 = M_1050_COUNT_ERRPROVI_DB_SELECT_1_Query1.Execute(m_1050_COUNT_ERRPROVI_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.ERROSVID_DESCR_ERRO, ERROSVID.DCLERROS_VIDAZUL.ERROSVID_DESCR_ERRO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1050_FIM*/

        [StopWatch]
        /*" M-1060-UPD-PROPOSTA */
        private void M_1060_UPD_PROPOSTA(bool isPerform = false)
        {
            /*" -1561- MOVE '1060-UPD-PROPOSTA' TO PARAGRAFO. */
            _.Move("1060-UPD-PROPOSTA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1567- MOVE 'UPDATE PROPOVA ' TO COMANDO. */
            _.Move("UPDATE PROPOVA ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1572- PERFORM M_1060_UPD_PROPOSTA_DB_UPDATE_1 */

            M_1060_UPD_PROPOSTA_DB_UPDATE_1();

            /*" -1575- IF SQLCODE NOT EQUAL ZEROES AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -1576- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


            /*" -1576- ADD 1 TO WS-CRITICADO. */
            WS_AUX_ADORMECIDAS.WS_CRITICADO.Value = WS_AUX_ADORMECIDAS.WS_CRITICADO + 1;

        }

        [StopWatch]
        /*" M-1060-UPD-PROPOSTA-DB-UPDATE-1 */
        public void M_1060_UPD_PROPOSTA_DB_UPDATE_1()
        {
            /*" -1572- EXEC SQL UPDATE SEGUROS.PROPOSTAS_VA SET SIT_REGISTRO = 'T' , COD_USUARIO = 'VA4002B' WHERE NUM_CERTIFICADO = :PROPVA-NRCERTIF END-EXEC. */

            var m_1060_UPD_PROPOSTA_DB_UPDATE_1_Update1 = new M_1060_UPD_PROPOSTA_DB_UPDATE_1_Update1()
            {
                PROPVA_NRCERTIF = WS_AUXILIARES_HOST.PROPVA_NRCERTIF.ToString(),
            };

            M_1060_UPD_PROPOSTA_DB_UPDATE_1_Update1.Execute(m_1060_UPD_PROPOSTA_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1060_FIM*/

        [StopWatch]
        /*" M-1200-CANCELA-PROPOSTA */
        private void M_1200_CANCELA_PROPOSTA(bool isPerform = false)
        {
            /*" -1585- MOVE '1200-CANCELA-PROPOSTA' TO PARAGRAFO. */
            _.Move("1200-CANCELA-PROPOSTA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1588- MOVE 'UPDATE PROPOVA ' TO COMANDO. */
            _.Move("UPDATE PROPOVA ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1593- PERFORM M_1200_CANCELA_PROPOSTA_DB_UPDATE_1 */

            M_1200_CANCELA_PROPOSTA_DB_UPDATE_1();

            /*" -1596- IF SQLCODE NOT EQUAL ZEROES AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -1597- GO TO 9999-ERRO */

                M_9999_ERRO(); //GOTO
                return;

                /*" -1598- ELSE */
            }
            else
            {


                /*" -1599- ADD 1 TO WS-CANCELADO */
                WS_AUX_ADORMECIDAS.WS_CANCELADO.Value = WS_AUX_ADORMECIDAS.WS_CANCELADO + 1;

                /*" -1600- END-IF. */
            }


        }

        [StopWatch]
        /*" M-1200-CANCELA-PROPOSTA-DB-UPDATE-1 */
        public void M_1200_CANCELA_PROPOSTA_DB_UPDATE_1()
        {
            /*" -1593- EXEC SQL UPDATE SEGUROS.PROPOSTAS_VA SET SIT_REGISTRO = '4' , COD_USUARIO = 'VA4002B' WHERE NUM_CERTIFICADO = :PROPVA-NRCERTIF END-EXEC. */

            var m_1200_CANCELA_PROPOSTA_DB_UPDATE_1_Update1 = new M_1200_CANCELA_PROPOSTA_DB_UPDATE_1_Update1()
            {
                PROPVA_NRCERTIF = WS_AUXILIARES_HOST.PROPVA_NRCERTIF.ToString(),
            };

            M_1200_CANCELA_PROPOSTA_DB_UPDATE_1_Update1.Execute(m_1200_CANCELA_PROPOSTA_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1200_FIM*/

        [StopWatch]
        /*" M-1300-INTEGRA-PROPOSTA */
        private void M_1300_INTEGRA_PROPOSTA(bool isPerform = false)
        {
            /*" -1608- MOVE '1300-INTEGRA-PROPOSTA' TO PARAGRAFO. */
            _.Move("1300-INTEGRA-PROPOSTA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1611- MOVE 'UPDATE PROPOVA ' TO COMANDO. */
            _.Move("UPDATE PROPOVA ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1615- IF PROPVA-NRMATRVEN < ZEROES OR PROPVA-NRMATRVEN EQUAL ZEROES */

            if (WS_AUXILIARES_HOST.PROPVA_NRMATRVEN < 00 || WS_AUXILIARES_HOST.PROPVA_NRMATRVEN == 00)
            {

                /*" -1616- MOVE 7777777 TO PROPVA-NRMATRVEN */
                _.Move(7777777, WS_AUXILIARES_HOST.PROPVA_NRMATRVEN);

                /*" -1618- END-IF */
            }


            /*" -1619- PERFORM 1330-COUNT-ERRO-OPC THRU 1330-FIM. */

            M_1330_COUNT_ERRO_OPC(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1330_FIM*/


            /*" -1623- IF WS-COUNTERRO-OPC GREATER ZEROS */

            if (WS_AUX_ADORMECIDAS.WS_COUNTERRO_OPC > 00)
            {

                /*" -1624- PERFORM 1350-UPDATE-OPCPAGVI THRU 1350-FIM */

                M_1350_UPDATE_OPCPAGVI(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1350_FIM*/


                /*" -1634- END-IF */
            }


            /*" -1635- PERFORM 1340-PESQUISA-ERRO-2005 THRU 1340-FIM. */

            M_1340_PESQUISA_ERRO_2005(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1340_FIM*/


            /*" -1639- IF WS-COUNTERRO-OPC GREATER ZEROS */

            if (WS_AUX_ADORMECIDAS.WS_COUNTERRO_OPC > 00)
            {

                /*" -1640- MOVE WDTQUIT-DD TO OPCAOP-DIA-DEB */
                _.Move(QUITACAO_DATE_RD.WDTQUIT_DD, WS_AUXILIARES_HOST.OPCAOP_DIA_DEB);

                /*" -1641- PERFORM 1355-UPDATE-DIA-DEBITO THRU 1355-FIM */

                M_1355_UPDATE_DIA_DEBITO(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1355_FIM*/


                /*" -1643- END-IF */
            }


            /*" -1645- DISPLAY 'ANTES DE INTEGRAR - CERTIF:' PROPVA-NRCERTIF ' PROXVEN: ' PROPVA-DTPROXVEN */

            $"ANTES DE INTEGRAR - CERTIF:{WS_AUXILIARES_HOST.PROPVA_NRCERTIF} PROXVEN: {WS_AUXILIARES_HOST.PROPVA_DTPROXVEN}"
            .Display();

            /*" -1646- MOVE PROPVA-DTPROXVEN TO PROXVEN-DATE */
            _.Move(WS_AUXILIARES_HOST.PROPVA_DTPROXVEN, PROXVEN_DATE);

            /*" -1647- MOVE WPRXVEN-AA TO WPRXVEN8-AA */
            _.Move(PROXVEN_DATE_RD.WPRXVEN_AA, PROXVEN_DATE8_RD.WPRXVEN8_AA);

            /*" -1648- MOVE WPRXVEN-MM TO WPRXVEN8-MM */
            _.Move(PROXVEN_DATE_RD.WPRXVEN_MM, PROXVEN_DATE8_RD.WPRXVEN8_MM);

            /*" -1649- MOVE WPRXVEN-DD TO WPRXVEN8-DD */
            _.Move(PROXVEN_DATE_RD.WPRXVEN_DD, PROXVEN_DATE8_RD.WPRXVEN8_DD);

            /*" -1652- DISPLAY 'PROXVEN - ' PROXVEN-DATE8 ' / MIN-PROXVEN - ' MIN-PROXVEN-DATE8 */

            $"PROXVEN - {PROXVEN_DATE8} / MIN-PROXVEN - {MIN_PROXVEN_DATE8}"
            .Display();

            /*" -1653- IF PROXVEN-DATE8 < MIN-PROXVEN-DATE8 */

            if (PROXVEN_DATE8 < MIN_PROXVEN_DATE8)
            {

                /*" -1654- MOVE MIN-PROXVEN-DATE TO PROPVA-DTPROXVEN */
                _.Move(MIN_PROXVEN_DATE, WS_AUXILIARES_HOST.PROPVA_DTPROXVEN);

                /*" -1655- END-IF */
            }


            /*" -1657- DISPLAY 'PROXVEN INTEGRACAO:' PROPVA-DTPROXVEN */
            _.Display($"PROXVEN INTEGRACAO:{WS_AUXILIARES_HOST.PROPVA_DTPROXVEN}");

            /*" -1666- PERFORM M_1300_INTEGRA_PROPOSTA_DB_UPDATE_1 */

            M_1300_INTEGRA_PROPOSTA_DB_UPDATE_1();

            /*" -1669- IF SQLCODE NOT EQUAL ZEROES AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -1670- GO TO 9999-ERRO */

                M_9999_ERRO(); //GOTO
                return;

                /*" -1672- END-IF. */
            }


            /*" -1673- PERFORM 1310-PESQUISA-SEGURADO-VGAP */

            M_1310_PESQUISA_SEGURADO_VGAP(true);

            /*" -1674- IF WTEM-SEGURADOS EQUAL 'N' */

            if (WTEM_SEGURADOS == "N")
            {

                /*" -1675- PERFORM 3000-INSERE-SEGURADO-VGAP */

                M_3000_INSERE_SEGURADO_VGAP(true);

                /*" -1676- PERFORM 3600-INSERT-HIST-SEGURVGA */

                M_3600_INSERT_HIST_SEGURVGA(true);

                /*" -1677- ELSE */
            }
            else
            {


                /*" -1678- PERFORM 1370-PESQUISA-HIST-SEGURVGA */

                M_1370_PESQUISA_HIST_SEGURVGA(true);

                /*" -1679- IF WTEM-HIST-SEGURVGA EQUAL 'N' */

                if (WTEM_HIST_SEGURVGA == "N")
                {

                    /*" -1680- PERFORM 3600-INSERT-HIST-SEGURVGA */

                    M_3600_INSERT_HIST_SEGURVGA(true);

                    /*" -1681- END-IF */
                }


                /*" -1683- END-IF */
            }


            /*" -1685- PERFORM 1380-PESQUISA-APOLICOB. */

            M_1380_PESQUISA_APOLICOB(true);

            /*" -1686- IF WTEM-APOLICOB EQUAL 'N' */

            if (WTEM_APOLICOB == "N")
            {

                /*" -1687- PERFORM 3700-00-INSERT-APOLICOB */

                M_3700_00_INSERT_APOLICOB(true);

                /*" -1689- END-IF */
            }


            /*" -1690- PERFORM M-1395-PESQUISA-MOVIMENTO-VGAP. */

            M_1395_PESQUISA_MOVIMENTO_VGAP(true);

            /*" -1691- IF WTEM-MOVIMENTO EQUAL 'N' */

            if (WTEM_MOVIMENTO == "N")
            {

                /*" -1692- PERFORM 3810-ACESSA-FONTE */

                M_3810_ACESSA_FONTE(true);

                /*" -1693- PERFORM 3820-ATUALIZA-FONTE */

                M_3820_ATUALIZA_FONTE(true);

                /*" -1694- PERFORM 3830-CONTA-CORRENTE */

                M_3830_CONTA_CORRENTE(true);

                /*" -1695- PERFORM 3840-DATA-REFERENCIA */

                M_3840_DATA_REFERENCIA(true);

                /*" -1696- PERFORM 3850-DATA-CLIENTE */

                M_3850_DATA_CLIENTE(true);

                /*" -1697- PERFORM 3860-HIS_COBER_PROPOST */

                M_3860_HIS_COBER_PROPOST(true);

                /*" -1698- PERFORM 3800-INSERT-MOVIMENTO */

                M_3800_INSERT_MOVIMENTO(true);

                /*" -1700- END-IF */
            }


            /*" -1703- ADD 1 TO WS-INTEGRADO. */
            WS_AUX_ADORMECIDAS.WS_INTEGRADO.Value = WS_AUX_ADORMECIDAS.WS_INTEGRADO + 1;

            /*" -1705- IF PRAZO-DIAS >= 15 */

            if (PRAZO_DIAS >= 15)
            {

                /*" -1706- PERFORM 1050-COUNT-ERRPROVI THRU 1050-FIM */

                M_1050_COUNT_ERRPROVI(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1050_FIM*/


                /*" -1714- IF WTEM-ERRO EQUAL 'S' */

                if (WTEM_ERRO == "S")
                {

                    /*" -1715- PERFORM 3300-SELECT-CLIENTES */

                    M_3300_SELECT_CLIENTES(true);

                    /*" -1716- IF (WTEM-CLIENTES EQUAL 'S' ) */

                    if ((WTEM_CLIENTES == "S"))
                    {

                        /*" -1717- MOVE CLIENTES-CGCCPF TO ARQEMIT-CPF */
                        _.Move(CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF, LD02.ARQEMIT_CPF);

                        /*" -1718- END-IF */
                    }


                    /*" -1719- MOVE PROPVA-CODPRODU TO ARQEMIT-COD-PRODUTO */
                    _.Move(WS_AUXILIARES_HOST.PROPVA_CODPRODU, LD02.ARQEMIT_COD_PRODUTO);

                    /*" -1720- MOVE PROPVA-FONTE TO ARQEMIT-FONTE */
                    _.Move(WS_AUXILIARES_HOST.PROPVA_FONTE, LD02.ARQEMIT_FONTE);

                    /*" -1721- MOVE PROPVA-NRCERTIF TO ARQEMIT-NRCERTIF */
                    _.Move(WS_AUXILIARES_HOST.PROPVA_NRCERTIF, LD02.ARQEMIT_NRCERTIF);

                    /*" -1722- MOVE PROPVA-DTQITBCO TO ARQEMIT-DT-QUITACAO */
                    _.Move(WS_AUXILIARES_HOST.PROPVA_DTQITBCO, LD02.ARQEMIT_DT_QUITACAO);

                    /*" -1723- MOVE PROPVA-AGECOBR TO ARQEMIT-AGENCIA */
                    _.Move(WS_AUXILIARES_HOST.PROPVA_AGECOBR, LD02.ARQEMIT_AGENCIA);

                    /*" -1724- MOVE PROPVA-CODUSU TO ARQEMIT-COD-USUARIO */
                    _.Move(WS_AUXILIARES_HOST.PROPVA_CODUSU, LD02.ARQEMIT_COD_USUARIO);

                    /*" -1726- MOVE ERROSVID-DESCR-ERRO TO ARQEMIT-DESC-ERRO */
                    _.Move(ERROSVID.DCLERROS_VIDAZUL.ERROSVID_DESCR_ERRO, LD02.ARQEMIT_DESC_ERRO);

                    /*" -1727- ADD 1 TO WS-INTEGRADO-ERRO */
                    WS_AUX_ADORMECIDAS.WS_INTEGRADO_ERRO.Value = WS_AUX_ADORMECIDAS.WS_INTEGRADO_ERRO + 1;

                    /*" -1728- WRITE REG-ARQEMI FROM LD02 */
                    _.Move(LD02.GetMoveValues(), REG_ARQEMI);

                    ARQEMIT.Write(REG_ARQEMI.GetMoveValues().ToString());

                    /*" -1728- END-IF. */
                }

            }


        }

        [StopWatch]
        /*" M-1300-INTEGRA-PROPOSTA-DB-UPDATE-1 */
        public void M_1300_INTEGRA_PROPOSTA_DB_UPDATE_1()
        {
            /*" -1666- EXEC SQL UPDATE SEGUROS.PROPOSTAS_VA SET SIT_REGISTRO = '3' , NRPRIPARATZ = 0, QTDPARATZ = 0, DTPROXVEN = :PROPVA-DTPROXVEN, COD_USUARIO = 'VA4002B' , NUM_MATRI_VENDEDOR = :PROPVA-NRMATRVEN WHERE NUM_CERTIFICADO = :PROPVA-NRCERTIF END-EXEC. */

            var m_1300_INTEGRA_PROPOSTA_DB_UPDATE_1_Update1 = new M_1300_INTEGRA_PROPOSTA_DB_UPDATE_1_Update1()
            {
                PROPVA_DTPROXVEN = WS_AUXILIARES_HOST.PROPVA_DTPROXVEN.ToString(),
                PROPVA_NRMATRVEN = WS_AUXILIARES_HOST.PROPVA_NRMATRVEN.ToString(),
                PROPVA_NRCERTIF = WS_AUXILIARES_HOST.PROPVA_NRCERTIF.ToString(),
            };

            M_1300_INTEGRA_PROPOSTA_DB_UPDATE_1_Update1.Execute(m_1300_INTEGRA_PROPOSTA_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1300_FIM*/

        [StopWatch]
        /*" M-1310-PESQUISA-SEGURADO-VGAP */
        private void M_1310_PESQUISA_SEGURADO_VGAP(bool isPerform = false)
        {
            /*" -1740- MOVE '1310-PESQUISA-SEGURADO-VGAP' TO COMANDO. */
            _.Move("1310-PESQUISA-SEGURADO-VGAP", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1742- MOVE 'S' TO WTEM-SEGURADOS */
            _.Move("S", WTEM_SEGURADOS);

            /*" -1755- PERFORM M_1310_PESQUISA_SEGURADO_VGAP_DB_SELECT_1 */

            M_1310_PESQUISA_SEGURADO_VGAP_DB_SELECT_1();

            /*" -1758- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1759- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1760- MOVE 'N' TO WTEM-SEGURADOS */
                    _.Move("N", WTEM_SEGURADOS);

                    /*" -1761- ELSE */
                }
                else
                {


                    /*" -1762- GO TO 9999-ERRO */

                    M_9999_ERRO(); //GOTO
                    return;

                    /*" -1763- END-IF */
                }


                /*" -1764- ELSE */
            }
            else
            {


                /*" -1765- MOVE SEGURVGA-NUM-ITEM TO WHOST-NUM-ITEM */
                _.Move(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_ITEM, WS_AUXILIARES.WHOST_NUM_ITEM);

                /*" -1765- END-IF. */
            }


        }

        [StopWatch]
        /*" M-1310-PESQUISA-SEGURADO-VGAP-DB-SELECT-1 */
        public void M_1310_PESQUISA_SEGURADO_VGAP_DB_SELECT_1()
        {
            /*" -1755- EXEC SQL SELECT OCORR_HISTORICO, NUM_ITEM, SIT_REGISTRO, VALUE(DATA_INIVIGENCIA, '0001-01-01' ) INTO :SEGURVGA-OCORR-HISTORICO, :SEGURVGA-NUM-ITEM, :SEGURVGA-SIT-REGISTRO, :SEGURVGA-DATA-ADMISSAO FROM SEGUROS.V1SEGURAVG WHERE NUM_CERTIFICADO = :PROPVA-NRCERTIF AND TIPO_SEGURADO = '1' WITH UR END-EXEC. */

            var m_1310_PESQUISA_SEGURADO_VGAP_DB_SELECT_1_Query1 = new M_1310_PESQUISA_SEGURADO_VGAP_DB_SELECT_1_Query1()
            {
                PROPVA_NRCERTIF = WS_AUXILIARES_HOST.PROPVA_NRCERTIF.ToString(),
            };

            var executed_1 = M_1310_PESQUISA_SEGURADO_VGAP_DB_SELECT_1_Query1.Execute(m_1310_PESQUISA_SEGURADO_VGAP_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SEGURVGA_OCORR_HISTORICO, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_OCORR_HISTORICO);
                _.Move(executed_1.SEGURVGA_NUM_ITEM, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_ITEM);
                _.Move(executed_1.SEGURVGA_SIT_REGISTRO, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_SIT_REGISTRO);
                _.Move(executed_1.SEGURVGA_DATA_ADMISSAO, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_DATA_ADMISSAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1310_FIM*/

        [StopWatch]
        /*" M-1330-COUNT-ERRO-OPC */
        private void M_1330_COUNT_ERRO_OPC(bool isPerform = false)
        {
            /*" -1778- MOVE '1330-COUNT-ERRO-OPC' TO COMANDO. */
            _.Move("1330-COUNT-ERRO-OPC", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1790- MOVE +0 TO WS-COUNTERRO-OPC. */
            _.Move(+0, WS_AUX_ADORMECIDAS.WS_COUNTERRO_OPC);

            /*" -1799- PERFORM M_1330_COUNT_ERRO_OPC_DB_SELECT_1 */

            M_1330_COUNT_ERRO_OPC_DB_SELECT_1();

            /*" -1803- IF SQLCODE NOT EQUAL ZEROS AND SQLCODE NOT EQUAL 100 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != 100)
            {

                /*" -1804- GO TO 9999-ERRO */

                M_9999_ERRO(); //GOTO
                return;

                /*" -1805- END-IF. */
            }


        }

        [StopWatch]
        /*" M-1330-COUNT-ERRO-OPC-DB-SELECT-1 */
        public void M_1330_COUNT_ERRO_OPC_DB_SELECT_1()
        {
            /*" -1799- EXEC SQL SELECT VALUE(COUNT(*),0) INTO :WS-COUNTERRO-OPC FROM SEGUROS.VG_CRITICA_PROPOSTA WHERE NUM_CERTIFICADO = :PROPVA-NRCERTIF AND COD_MSG_CRITICA IN (2001, 2003, 2402, 2501, 2502, 2503, 2504, 2505, 2506, 3001, 3002) AND STA_CRITICA IN ( '0' , '1' , '2' , '4' , '5' , '8' ) WITH UR END-EXEC. */

            var m_1330_COUNT_ERRO_OPC_DB_SELECT_1_Query1 = new M_1330_COUNT_ERRO_OPC_DB_SELECT_1_Query1()
            {
                PROPVA_NRCERTIF = WS_AUXILIARES_HOST.PROPVA_NRCERTIF.ToString(),
            };

            var executed_1 = M_1330_COUNT_ERRO_OPC_DB_SELECT_1_Query1.Execute(m_1330_COUNT_ERRO_OPC_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_COUNTERRO_OPC, WS_AUX_ADORMECIDAS.WS_COUNTERRO_OPC);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1330_FIM*/

        [StopWatch]
        /*" M-1340-PESQUISA-ERRO-2005 */
        private void M_1340_PESQUISA_ERRO_2005(bool isPerform = false)
        {
            /*" -1817- MOVE '1340-PESQUISA-ERRO-' TO COMANDO. */
            _.Move("1340-PESQUISA-ERRO-", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1828- MOVE +0 TO WS-COUNTERRO-OPC. */
            _.Move(+0, WS_AUX_ADORMECIDAS.WS_COUNTERRO_OPC);

            /*" -1836- PERFORM M_1340_PESQUISA_ERRO_2005_DB_SELECT_1 */

            M_1340_PESQUISA_ERRO_2005_DB_SELECT_1();

            /*" -1840- IF SQLCODE NOT EQUAL ZEROS AND SQLCODE NOT EQUAL 100 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != 100)
            {

                /*" -1841- GO TO 9999-ERRO */

                M_9999_ERRO(); //GOTO
                return;

                /*" -1841- END-IF. */
            }


        }

        [StopWatch]
        /*" M-1340-PESQUISA-ERRO-2005-DB-SELECT-1 */
        public void M_1340_PESQUISA_ERRO_2005_DB_SELECT_1()
        {
            /*" -1836- EXEC SQL SELECT VALUE(COUNT(*),0) INTO :WS-COUNTERRO-OPC FROM SEGUROS.VG_CRITICA_PROPOSTA WHERE NUM_CERTIFICADO = :PROPVA-NRCERTIF AND COD_MSG_CRITICA = 2005 AND STA_CRITICA IN ( '0' , '1' , '2' , '4' , '5' , '8' ) WITH UR END-EXEC. */

            var m_1340_PESQUISA_ERRO_2005_DB_SELECT_1_Query1 = new M_1340_PESQUISA_ERRO_2005_DB_SELECT_1_Query1()
            {
                PROPVA_NRCERTIF = WS_AUXILIARES_HOST.PROPVA_NRCERTIF.ToString(),
            };

            var executed_1 = M_1340_PESQUISA_ERRO_2005_DB_SELECT_1_Query1.Execute(m_1340_PESQUISA_ERRO_2005_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_COUNTERRO_OPC, WS_AUX_ADORMECIDAS.WS_COUNTERRO_OPC);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1340_FIM*/

        [StopWatch]
        /*" M-1350-UPDATE-OPCPAGVI */
        private void M_1350_UPDATE_OPCPAGVI(bool isPerform = false)
        {
            /*" -1850- MOVE '1350-UPDATE-OPCPAGVI' TO PARAGRAFO. */
            _.Move("1350-UPDATE-OPCPAGVI", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1853- MOVE 'UPDATE OPCPAGVI' TO COMANDO. */
            _.Move("UPDATE OPCPAGVI", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1857- PERFORM M_1350_UPDATE_OPCPAGVI_DB_UPDATE_1 */

            M_1350_UPDATE_OPCPAGVI_DB_UPDATE_1();

            /*" -1860- IF SQLCODE NOT EQUAL ZEROES AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -1860- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-1350-UPDATE-OPCPAGVI-DB-UPDATE-1 */
        public void M_1350_UPDATE_OPCPAGVI_DB_UPDATE_1()
        {
            /*" -1857- EXEC SQL UPDATE SEGUROS.OPCAO_PAG_VIDAZUL SET OPCAO_PAGAMENTO= '3' WHERE NUM_CERTIFICADO = :PROPVA-NRCERTIF END-EXEC. */

            var m_1350_UPDATE_OPCPAGVI_DB_UPDATE_1_Update1 = new M_1350_UPDATE_OPCPAGVI_DB_UPDATE_1_Update1()
            {
                PROPVA_NRCERTIF = WS_AUXILIARES_HOST.PROPVA_NRCERTIF.ToString(),
            };

            M_1350_UPDATE_OPCPAGVI_DB_UPDATE_1_Update1.Execute(m_1350_UPDATE_OPCPAGVI_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1350_FIM*/

        [StopWatch]
        /*" M-1355-UPDATE-DIA-DEBITO */
        private void M_1355_UPDATE_DIA_DEBITO(bool isPerform = false)
        {
            /*" -1869- MOVE '1355-UPDATE-DIA-DEBI' TO PARAGRAFO. */
            _.Move("1355-UPDATE-DIA-DEBI", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1872- MOVE 'UPDATE DIA-DEBI' TO COMANDO. */
            _.Move("UPDATE DIA-DEBI", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1876- PERFORM M_1355_UPDATE_DIA_DEBITO_DB_UPDATE_1 */

            M_1355_UPDATE_DIA_DEBITO_DB_UPDATE_1();

            /*" -1879- IF SQLCODE NOT EQUAL ZEROES AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -1879- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-1355-UPDATE-DIA-DEBITO-DB-UPDATE-1 */
        public void M_1355_UPDATE_DIA_DEBITO_DB_UPDATE_1()
        {
            /*" -1876- EXEC SQL UPDATE SEGUROS.OPCAO_PAG_VIDAZUL SET DIA_DEBITO = :OPCAOP-DIA-DEB WHERE NUM_CERTIFICADO = :PROPVA-NRCERTIF END-EXEC. */

            var m_1355_UPDATE_DIA_DEBITO_DB_UPDATE_1_Update1 = new M_1355_UPDATE_DIA_DEBITO_DB_UPDATE_1_Update1()
            {
                OPCAOP_DIA_DEB = WS_AUXILIARES_HOST.OPCAOP_DIA_DEB.ToString(),
                PROPVA_NRCERTIF = WS_AUXILIARES_HOST.PROPVA_NRCERTIF.ToString(),
            };

            M_1355_UPDATE_DIA_DEBITO_DB_UPDATE_1_Update1.Execute(m_1355_UPDATE_DIA_DEBITO_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1355_FIM*/

        [StopWatch]
        /*" M-1360-UPDATE-PERIPGTO */
        private void M_1360_UPDATE_PERIPGTO(bool isPerform = false)
        {
            /*" -1888- MOVE '1360-UPDATE-PERIPGTO' TO PARAGRAFO. */
            _.Move("1360-UPDATE-PERIPGTO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1890- MOVE 'UPDATE PERIPGTO' TO COMANDO. */
            _.Move("UPDATE PERIPGTO", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1894- PERFORM M_1360_UPDATE_PERIPGTO_DB_UPDATE_1 */

            M_1360_UPDATE_PERIPGTO_DB_UPDATE_1();

            /*" -1897- IF SQLCODE NOT EQUAL ZEROES AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -1897- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-1360-UPDATE-PERIPGTO-DB-UPDATE-1 */
        public void M_1360_UPDATE_PERIPGTO_DB_UPDATE_1()
        {
            /*" -1894- EXEC SQL UPDATE SEGUROS.OPCAO_PAG_VIDAZUL SET PERI_PAGAMENTO= '1' WHERE NUM_CERTIFICADO = :PROPVA-NRCERTIF END-EXEC. */

            var m_1360_UPDATE_PERIPGTO_DB_UPDATE_1_Update1 = new M_1360_UPDATE_PERIPGTO_DB_UPDATE_1_Update1()
            {
                PROPVA_NRCERTIF = WS_AUXILIARES_HOST.PROPVA_NRCERTIF.ToString(),
            };

            M_1360_UPDATE_PERIPGTO_DB_UPDATE_1_Update1.Execute(m_1360_UPDATE_PERIPGTO_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1360_FIM*/

        [StopWatch]
        /*" M-1370-PESQUISA-HIST-SEGURVGA */
        private void M_1370_PESQUISA_HIST_SEGURVGA(bool isPerform = false)
        {
            /*" -1904- MOVE '1370-PESQUISA-HIST-SEGURVGA' TO PARAGRAFO. */
            _.Move("1370-PESQUISA-HIST-SEGURVGA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1905- MOVE +0 TO WS-COUNT-HISTVGAP. */
            _.Move(+0, WS_AUX_ADORMECIDAS.WS_COUNT_HISTVGAP);

            /*" -1906- MOVE 'S' TO WTEM-HIST-SEGURVGA. */
            _.Move("S", WTEM_HIST_SEGURVGA);

            /*" -1914- PERFORM M_1370_PESQUISA_HIST_SEGURVGA_DB_SELECT_1 */

            M_1370_PESQUISA_HIST_SEGURVGA_DB_SELECT_1();

            /*" -1918- IF SQLCODE NOT EQUAL ZEROS AND SQLCODE NOT EQUAL 100 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != 100)
            {

                /*" -1919- GO TO 9999-ERRO */

                M_9999_ERRO(); //GOTO
                return;

                /*" -1921- END-IF. */
            }


            /*" -1922- IF WS-COUNT-HISTVGAP EQUAL ZEROS */

            if (WS_AUX_ADORMECIDAS.WS_COUNT_HISTVGAP == 00)
            {

                /*" -1923- MOVE 'N' TO WTEM-HIST-SEGURVGA */
                _.Move("N", WTEM_HIST_SEGURVGA);

                /*" -1924- END-IF. */
            }


        }

        [StopWatch]
        /*" M-1370-PESQUISA-HIST-SEGURVGA-DB-SELECT-1 */
        public void M_1370_PESQUISA_HIST_SEGURVGA_DB_SELECT_1()
        {
            /*" -1914- EXEC SQL SELECT VALUE(COUNT(*),0) INTO :WS-COUNT-HISTVGAP FROM SEGUROS.SEGURADOSVGAP_HIST WHERE NUM_APOLICE = :PROPVA-NUM-APOLICE AND NUM_ITEM = :WHOST-NUM-ITEM AND OCORR_HISTORICO = :SEGURVGA-OCORR-HISTORICO WITH UR END-EXEC. */

            var m_1370_PESQUISA_HIST_SEGURVGA_DB_SELECT_1_Query1 = new M_1370_PESQUISA_HIST_SEGURVGA_DB_SELECT_1_Query1()
            {
                SEGURVGA_OCORR_HISTORICO = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_OCORR_HISTORICO.ToString(),
                PROPVA_NUM_APOLICE = WS_AUXILIARES_HOST.PROPVA_NUM_APOLICE.ToString(),
                WHOST_NUM_ITEM = WS_AUXILIARES.WHOST_NUM_ITEM.ToString(),
            };

            var executed_1 = M_1370_PESQUISA_HIST_SEGURVGA_DB_SELECT_1_Query1.Execute(m_1370_PESQUISA_HIST_SEGURVGA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_COUNT_HISTVGAP, WS_AUX_ADORMECIDAS.WS_COUNT_HISTVGAP);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1370_FIM*/

        [StopWatch]
        /*" M-1380-PESQUISA-APOLICOB */
        private void M_1380_PESQUISA_APOLICOB(bool isPerform = false)
        {
            /*" -1932- MOVE '1380-PESQUISA-APOLICOB' TO PARAGRAFO. */
            _.Move("1380-PESQUISA-APOLICOB", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1933- MOVE +0 TO WS-COUNT-APOLICOB. */
            _.Move(+0, WS_AUX_ADORMECIDAS.WS_COUNT_APOLICOB);

            /*" -1934- MOVE 'S' TO WTEM-APOLICOB. */
            _.Move("S", WTEM_APOLICOB);

            /*" -1941- PERFORM M_1380_PESQUISA_APOLICOB_DB_SELECT_1 */

            M_1380_PESQUISA_APOLICOB_DB_SELECT_1();

            /*" -1945- IF SQLCODE NOT EQUAL ZEROS AND SQLCODE NOT EQUAL 100 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != 100)
            {

                /*" -1946- GO TO 9999-ERRO */

                M_9999_ERRO(); //GOTO
                return;

                /*" -1948- END-IF. */
            }


            /*" -1949- IF WS-COUNT-APOLICOB EQUAL ZEROS */

            if (WS_AUX_ADORMECIDAS.WS_COUNT_APOLICOB == 00)
            {

                /*" -1950- MOVE 'N' TO WTEM-APOLICOB */
                _.Move("N", WTEM_APOLICOB);

                /*" -1950- END-IF. */
            }


        }

        [StopWatch]
        /*" M-1380-PESQUISA-APOLICOB-DB-SELECT-1 */
        public void M_1380_PESQUISA_APOLICOB_DB_SELECT_1()
        {
            /*" -1941- EXEC SQL SELECT VALUE(COUNT(*),0) INTO :WS-COUNT-APOLICOB FROM SEGUROS.APOLICE_COBERTURAS WHERE NUM_APOLICE = :PROPVA-NUM-APOLICE AND NUM_ITEM = :WHOST-NUM-ITEM WITH UR END-EXEC. */

            var m_1380_PESQUISA_APOLICOB_DB_SELECT_1_Query1 = new M_1380_PESQUISA_APOLICOB_DB_SELECT_1_Query1()
            {
                PROPVA_NUM_APOLICE = WS_AUXILIARES_HOST.PROPVA_NUM_APOLICE.ToString(),
                WHOST_NUM_ITEM = WS_AUXILIARES.WHOST_NUM_ITEM.ToString(),
            };

            var executed_1 = M_1380_PESQUISA_APOLICOB_DB_SELECT_1_Query1.Execute(m_1380_PESQUISA_APOLICOB_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_COUNT_APOLICOB, WS_AUX_ADORMECIDAS.WS_COUNT_APOLICOB);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1380_FIM*/

        [StopWatch]
        /*" M-1390-PESQUISA-PLANOS-VAVGA */
        private void M_1390_PESQUISA_PLANOS_VAVGA(bool isPerform = false)
        {
            /*" -1957- MOVE '1390-PESQUISA-PLANOS-VAVGA' TO PARAGRAFO. */
            _.Move("1390-PESQUISA-PLANOS-VAVGA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1960- MOVE 'PESQUISA-PLANOS-VAVGA' TO COMANDO. */
            _.Move("PESQUISA-PLANOS-VAVGA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1983- PERFORM M_1390_PESQUISA_PLANOS_VAVGA_DB_SELECT_1 */

            M_1390_PESQUISA_PLANOS_VAVGA_DB_SELECT_1();

            /*" -1986- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -1987- DISPLAY 'ERRO SELECT PLANOS_VA_VGAP  SQLCODE  = ' SQLCODE */
                _.Display($"ERRO SELECT PLANOS_VA_VGAP  SQLCODE  = {DB.SQLCODE}");

                /*" -1988- DISPLAY 'NUMERO CERTIFICADO = ' PROPVA-NRCERTIF */
                _.Display($"NUMERO CERTIFICADO = {WS_AUXILIARES_HOST.PROPVA_NRCERTIF}");

                /*" -1989- DISPLAY 'NUMERO APOLICE     = ' PROPVA-NUM-APOLICE */
                _.Display($"NUMERO APOLICE     = {WS_AUXILIARES_HOST.PROPVA_NUM_APOLICE}");

                /*" -1990- DISPLAY 'CODIGO SUBGRUPO    = ' PROPVA-CODSUBES */
                _.Display($"CODIGO SUBGRUPO    = {WS_AUXILIARES_HOST.PROPVA_CODSUBES}");

                /*" -1991- DISPLAY 'OPCAO COBERTURA    = ' PROPVA-OPCAO-COBER */
                _.Display($"OPCAO COBERTURA    = {WS_AUXILIARES_HOST.PROPVA_OPCAO_COBER}");

                /*" -1992- DISPLAY 'IDADE              = ' PROPVA-IDADE */
                _.Display($"IDADE              = {WS_AUXILIARES_HOST.PROPVA_IDADE}");

                /*" -1993- GO TO 9999-ERRO */

                M_9999_ERRO(); //GOTO
                return;

                /*" -1993- END-IF. */
            }


        }

        [StopWatch]
        /*" M-1390-PESQUISA-PLANOS-VAVGA-DB-SELECT-1 */
        public void M_1390_PESQUISA_PLANOS_VAVGA_DB_SELECT_1()
        {
            /*" -1983- EXEC SQL SELECT VLPREMIOTOT, IMPMORNATU, IMPMORACID, IMPINVPERM, IMPAMDS, IMPDH, IMPDIT INTO :PLAVAVGA-VLPREMIOTOT, :PLAVAVGA-IMPMORNATU, :PLAVAVGA-IMPMORACID, :PLAVAVGA-IMPINVPERM, :PLAVAVGA-IMPAMDS, :PLAVAVGA-IMPDH, :PLAVAVGA-IMPDIT FROM SEGUROS.PLANOS_VA_VGAP WHERE NUM_APOLICE = :PROPVA-NUM-APOLICE AND CODSUBES = :PROPVA-CODSUBES AND OPCAO_COBER = :PROPVA-OPCAO-COBER AND IDADE_INICIAL <= :PROPVA-IDADE AND IDADE_FINAL >= :PROPVA-IDADE AND DTTERVIG = '9999-12-31' WITH UR END-EXEC. */

            var m_1390_PESQUISA_PLANOS_VAVGA_DB_SELECT_1_Query1 = new M_1390_PESQUISA_PLANOS_VAVGA_DB_SELECT_1_Query1()
            {
                PROPVA_NUM_APOLICE = WS_AUXILIARES_HOST.PROPVA_NUM_APOLICE.ToString(),
                PROPVA_OPCAO_COBER = WS_AUXILIARES_HOST.PROPVA_OPCAO_COBER.ToString(),
                PROPVA_CODSUBES = WS_AUXILIARES_HOST.PROPVA_CODSUBES.ToString(),
                PROPVA_IDADE = WS_AUXILIARES_HOST.PROPVA_IDADE.ToString(),
            };

            var executed_1 = M_1390_PESQUISA_PLANOS_VAVGA_DB_SELECT_1_Query1.Execute(m_1390_PESQUISA_PLANOS_VAVGA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PLAVAVGA_VLPREMIOTOT, PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_VLPREMIOTOT);
                _.Move(executed_1.PLAVAVGA_IMPMORNATU, PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_IMPMORNATU);
                _.Move(executed_1.PLAVAVGA_IMPMORACID, PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_IMPMORACID);
                _.Move(executed_1.PLAVAVGA_IMPINVPERM, PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_IMPINVPERM);
                _.Move(executed_1.PLAVAVGA_IMPAMDS, PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_IMPAMDS);
                _.Move(executed_1.PLAVAVGA_IMPDH, PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_IMPDH);
                _.Move(executed_1.PLAVAVGA_IMPDIT, PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_IMPDIT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1390_FIM*/

        [StopWatch]
        /*" M-1395-PESQUISA-MOVIMENTO-VGAP */
        private void M_1395_PESQUISA_MOVIMENTO_VGAP(bool isPerform = false)
        {
            /*" -2002- MOVE '1395-PESQUISA-MOVIMENTO-VGAP' TO PARAGRAFO. */
            _.Move("1395-PESQUISA-MOVIMENTO-VGAP", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2003- MOVE +0 TO WS-COUNT-MOVIMENTO. */
            _.Move(+0, WS_AUX_ADORMECIDAS.WS_COUNT_MOVIMENTO);

            /*" -2004- MOVE 'S' TO WTEM-MOVIMENTO. */
            _.Move("S", WTEM_MOVIMENTO);

            /*" -2010- PERFORM M_1395_PESQUISA_MOVIMENTO_VGAP_DB_SELECT_1 */

            M_1395_PESQUISA_MOVIMENTO_VGAP_DB_SELECT_1();

            /*" -2014- IF SQLCODE NOT EQUAL ZEROS AND SQLCODE NOT EQUAL 100 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != 100)
            {

                /*" -2015- GO TO 9999-ERRO */

                M_9999_ERRO(); //GOTO
                return;

                /*" -2017- END-IF. */
            }


            /*" -2018- IF WS-COUNT-MOVIMENTO EQUAL ZEROS */

            if (WS_AUX_ADORMECIDAS.WS_COUNT_MOVIMENTO == 00)
            {

                /*" -2019- MOVE 'N' TO WTEM-MOVIMENTO */
                _.Move("N", WTEM_MOVIMENTO);

                /*" -2019- END-IF. */
            }


        }

        [StopWatch]
        /*" M-1395-PESQUISA-MOVIMENTO-VGAP-DB-SELECT-1 */
        public void M_1395_PESQUISA_MOVIMENTO_VGAP_DB_SELECT_1()
        {
            /*" -2010- EXEC SQL SELECT VALUE(COUNT(*),0) INTO :WS-COUNT-MOVIMENTO FROM SEGUROS.MOVIMENTO_VGAP WHERE NUM_CERTIFICADO = :PROPVA-NRCERTIF WITH UR END-EXEC. */

            var m_1395_PESQUISA_MOVIMENTO_VGAP_DB_SELECT_1_Query1 = new M_1395_PESQUISA_MOVIMENTO_VGAP_DB_SELECT_1_Query1()
            {
                PROPVA_NRCERTIF = WS_AUXILIARES_HOST.PROPVA_NRCERTIF.ToString(),
            };

            var executed_1 = M_1395_PESQUISA_MOVIMENTO_VGAP_DB_SELECT_1_Query1.Execute(m_1395_PESQUISA_MOVIMENTO_VGAP_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_COUNT_MOVIMENTO, WS_AUX_ADORMECIDAS.WS_COUNT_MOVIMENTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1395_FIM*/

        [StopWatch]
        /*" M-1400-ATUALIZA-MOVIMENTO */
        private void M_1400_ATUALIZA_MOVIMENTO(bool isPerform = false)
        {
            /*" -2028- MOVE '1400-ATUALIZA-MOVIMENTO' TO PARAGRAFO */
            _.Move("1400-ATUALIZA-MOVIMENTO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2044- PERFORM M_1400_ATUALIZA_MOVIMENTO_DB_DECLARE_1 */

            M_1400_ATUALIZA_MOVIMENTO_DB_DECLARE_1();

            /*" -2048- MOVE 'OPEN MOVTOVGAP' TO COMANDO */
            _.Move("OPEN MOVTOVGAP", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2048- PERFORM M_1400_ATUALIZA_MOVIMENTO_DB_OPEN_1 */

            M_1400_ATUALIZA_MOVIMENTO_DB_OPEN_1();

            /*" -2051- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2052- GO TO 9999-ERRO */

                M_9999_ERRO(); //GOTO
                return;

                /*" -2054- END-IF */
            }


            /*" -2056- MOVE ZEROS TO WS-FIM-MOVTOVGAP */
            _.Move(0, WS_WORK_AREAS.WS_FIM_MOVTOVGAP);

            /*" -2058- PERFORM 1410-FETCH-MOVTOVGAP */

            M_1410_FETCH_MOVTOVGAP(true);

            /*" -2062- PERFORM 1450-PROCESSA-MOVTOVGAP THRU 1450-FIM UNTIL WS-FIM-MOVTOVGAP = 1 */

            while (!(WS_WORK_AREAS.WS_FIM_MOVTOVGAP == 1))
            {

                M_1450_PROCESSA_MOVTOVGAP(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1450_FIM*/

            }

            /*" -2062- . */

        }

        [StopWatch]
        /*" M-1400-ATUALIZA-MOVIMENTO-DB-OPEN-1 */
        public void M_1400_ATUALIZA_MOVIMENTO_DB_OPEN_1()
        {
            /*" -2048- EXEC SQL OPEN MOVTOVGAP END-EXEC */

            MOVTOVGAP.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1400_FIM*/

        [StopWatch]
        /*" M-1410-FETCH-MOVTOVGAP */
        private void M_1410_FETCH_MOVTOVGAP(bool isPerform = false)
        {
            /*" -2069- MOVE '1410-FETCH-MOVTOVGAP' TO PARAGRAFO */
            _.Move("1410-FETCH-MOVTOVGAP", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2072- MOVE 'FETCH MOVTOVGAP' TO COMANDO */
            _.Move("FETCH MOVTOVGAP", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2080- PERFORM M_1410_FETCH_MOVTOVGAP_DB_FETCH_1 */

            M_1410_FETCH_MOVTOVGAP_DB_FETCH_1();

            /*" -2083- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -2084- PERFORM 1415-VALIDA-CAMPOS */

                M_1415_VALIDA_CAMPOS(true);

                /*" -2085- ELSE */
            }
            else
            {


                /*" -2086- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2087- MOVE 1 TO WS-FIM-MOVTOVGAP */
                    _.Move(1, WS_WORK_AREAS.WS_FIM_MOVTOVGAP);

                    /*" -2088- MOVE 'CLOSE MOVTOVGAP' TO COMANDO */
                    _.Move("CLOSE MOVTOVGAP", WABEND.LOCALIZA_ABEND_2.COMANDO);

                    /*" -2088- PERFORM M_1410_FETCH_MOVTOVGAP_DB_CLOSE_1 */

                    M_1410_FETCH_MOVTOVGAP_DB_CLOSE_1();

                    /*" -2090- ELSE */
                }
                else
                {


                    /*" -2091- GO TO 9999-ERRO */

                    M_9999_ERRO(); //GOTO
                    return;

                    /*" -2092- END-IF */
                }


                /*" -2094- END-IF */
            }


            /*" -2094- . */

        }

        [StopWatch]
        /*" M-1410-FETCH-MOVTOVGAP-DB-FETCH-1 */
        public void M_1410_FETCH_MOVTOVGAP_DB_FETCH_1()
        {
            /*" -2080- EXEC SQL FETCH MOVTOVGAP INTO :MOVIMVGA-NUM-CERTIFICADO , :MOVIMVGA-COD-OPERACAO , :MOVIMVGA-DATA-AVERBACAO :WDATA-AVERBACAO , :MOVIMVGA-DATA-INCLUSAO :WDATA-INCLUSAO , :MOVIMVGA-DATA-NASCIMENTO :WDATA-NASCIMENTO , :MOVIMVGA-DATA-REFERENCIA :WDATA-REFERENCIA END-EXEC */

            if (MOVTOVGAP.Fetch())
            {
                _.Move(MOVTOVGAP.MOVIMVGA_NUM_CERTIFICADO, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_NUM_CERTIFICADO);
                _.Move(MOVTOVGAP.MOVIMVGA_COD_OPERACAO, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO);
                _.Move(MOVTOVGAP.MOVIMVGA_DATA_AVERBACAO, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_AVERBACAO);
                _.Move(MOVTOVGAP.WDATA_AVERBACAO, WDATA_AVERBACAO);
                _.Move(MOVTOVGAP.MOVIMVGA_DATA_INCLUSAO, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_INCLUSAO);
                _.Move(MOVTOVGAP.WDATA_INCLUSAO, WDATA_INCLUSAO);
                _.Move(MOVTOVGAP.MOVIMVGA_DATA_NASCIMENTO, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_NASCIMENTO);
                _.Move(MOVTOVGAP.WDATA_NASCIMENTO, WDATA_NASCIMENTO);
                _.Move(MOVTOVGAP.MOVIMVGA_DATA_REFERENCIA, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_REFERENCIA);
                _.Move(MOVTOVGAP.WDATA_REFERENCIA, WDATA_REFERENCIA);
            }

        }

        [StopWatch]
        /*" M-1410-FETCH-MOVTOVGAP-DB-CLOSE-1 */
        public void M_1410_FETCH_MOVTOVGAP_DB_CLOSE_1()
        {
            /*" -2088- EXEC SQL CLOSE MOVTOVGAP END-EXEC */

            MOVTOVGAP.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1410_FIM*/

        [StopWatch]
        /*" M-1415-VALIDA-CAMPOS */
        private void M_1415_VALIDA_CAMPOS(bool isPerform = false)
        {
            /*" -2104- MOVE '1415-VALIDA-CAMPOS' TO PARAGRAFO */
            _.Move("1415-VALIDA-CAMPOS", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2106- IF WDATA-NASCIMENTO LESS ZEROS AND WTEM-CLIENTES EQUAL 'N' */

            if (WDATA_NASCIMENTO < 00 && WTEM_CLIENTES == "N")
            {

                /*" -2107- PERFORM 3300-SELECT-CLIENTES */

                M_3300_SELECT_CLIENTES(true);

                /*" -2109- END-IF */
            }


            /*" -2110- IF WTEM-CLIENTES EQUAL 'S' */

            if (WTEM_CLIENTES == "S")
            {

                /*" -2112- MOVE CLIENTES-DATA-NASCIMENTO TO MOVIMVGA-DATA-NASCIMENTO */
                _.Move(CLIENTES.DCLCLIENTES.CLIENTES_DATA_NASCIMENTO, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_NASCIMENTO);

                /*" -2113- MOVE 1 TO WDATA-NASCIMENTO */
                _.Move(1, WDATA_NASCIMENTO);

                /*" -2115- END-IF */
            }


            /*" -2115- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1415_FIM*/

        [StopWatch]
        /*" M-1450-PROCESSA-MOVTOVGAP */
        private void M_1450_PROCESSA_MOVTOVGAP(bool isPerform = false)
        {
            /*" -2128- MOVE '1450-PROCESSA-MOVTOVGAP' TO PARAGRAFO */
            _.Move("1450-PROCESSA-MOVTOVGAP", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2140- PERFORM M_1450_PROCESSA_MOVTOVGAP_DB_UPDATE_1 */

            M_1450_PROCESSA_MOVTOVGAP_DB_UPDATE_1();

            /*" -2143- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2144- DISPLAY ' ' */
                _.Display($" ");

                /*" -2145- DISPLAY 'ERRO UPDATE MOVIMENTO_VGAP SQLCODE  = ' SQLCODE */
                _.Display($"ERRO UPDATE MOVIMENTO_VGAP SQLCODE  = {DB.SQLCODE}");

                /*" -2149- DISPLAY ' NRCERTIF : ' MOVIMVGA-NUM-CERTIFICADO ' APOLICE  : ' PROPVA-NUM-APOLICE ' SUBGRUPO : ' PROPVA-CODSUBES ' OPERACAO : ' MOVIMVGA-COD-OPERACAO */

                $" NRCERTIF : {MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_NUM_CERTIFICADO} APOLICE  : {WS_AUXILIARES_HOST.PROPVA_NUM_APOLICE} SUBGRUPO : {WS_AUXILIARES_HOST.PROPVA_CODSUBES} OPERACAO : {MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO}"
                .Display();

                /*" -2150- DISPLAY ' ' */
                _.Display($" ");

                /*" -2151- GO TO 9999-ERRO */

                M_9999_ERRO(); //GOTO
                return;

                /*" -2153- END-IF */
            }


            /*" -2154- ADD 1 TO AC-ATUA-MOVTO-VGAP */
            WS_WORK_AREAS.AC_ATUA_MOVTO_VGAP.Value = WS_WORK_AREAS.AC_ATUA_MOVTO_VGAP + 1;

            /*" -2156- PERFORM 1410-FETCH-MOVTOVGAP */

            M_1410_FETCH_MOVTOVGAP(true);

            /*" -2156- . */

        }

        [StopWatch]
        /*" M-1450-PROCESSA-MOVTOVGAP-DB-UPDATE-1 */
        public void M_1450_PROCESSA_MOVTOVGAP_DB_UPDATE_1()
        {
            /*" -2140- EXEC SQL UPDATE SEGUROS.V0MOVIMENTO SET DATA_INCLUSAO = CURRENT DATE, DATA_NASCIMENTO = :MOVIMVGA-DATA-NASCIMENTO :WDATA-NASCIMENTO, DATA_REFERENCIA = :MOVIMVGA-DATA-REFERENCIA :WDATA-REFERENCIA , COD_USUARIO = 'VA4002B' WHERE NUM_CERTIFICADO = :MOVIMVGA-NUM-CERTIFICADO AND COD_OPERACAO = :MOVIMVGA-COD-OPERACAO AND DATA_INCLUSAO IS NULL AND DATA_AVERBACAO = :MOVIMVGA-DATA-AVERBACAO END-EXEC */

            var m_1450_PROCESSA_MOVTOVGAP_DB_UPDATE_1_Update1 = new M_1450_PROCESSA_MOVTOVGAP_DB_UPDATE_1_Update1()
            {
                MOVIMVGA_DATA_NASCIMENTO = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_NASCIMENTO.ToString(),
                WDATA_NASCIMENTO = WDATA_NASCIMENTO.ToString(),
                MOVIMVGA_DATA_REFERENCIA = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_REFERENCIA.ToString(),
                WDATA_REFERENCIA = WDATA_REFERENCIA.ToString(),
                MOVIMVGA_NUM_CERTIFICADO = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_NUM_CERTIFICADO.ToString(),
                MOVIMVGA_DATA_AVERBACAO = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_AVERBACAO.ToString(),
                MOVIMVGA_COD_OPERACAO = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO.ToString(),
            };

            M_1450_PROCESSA_MOVTOVGAP_DB_UPDATE_1_Update1.Execute(m_1450_PROCESSA_MOVTOVGAP_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1450_FIM*/

        [StopWatch]
        /*" M-2000-PESQUISA-OPCPAG */
        private void M_2000_PESQUISA_OPCPAG(bool isPerform = false)
        {
            /*" -2164- MOVE '2000-PESQUISA-OPCPAG' TO PARAGRAFO. */
            _.Move("2000-PESQUISA-OPCPAG", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2167- MOVE 'SELECT V0OPCAOPAGVA ' TO COMANDO. */
            _.Move("SELECT V0OPCAOPAGVA ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2188- PERFORM M_2000_PESQUISA_OPCPAG_DB_SELECT_1 */

            M_2000_PESQUISA_OPCPAG_DB_SELECT_1();

            /*" -2191- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -2192- DISPLAY 'ERRO SELECT V0OPCAOPAGVA  SQLCODE  = ' SQLCODE */
                _.Display($"ERRO SELECT V0OPCAOPAGVA  SQLCODE  = {DB.SQLCODE}");

                /*" -2193- DISPLAY 'NRCERTIF = ' PROPVA-NRCERTIF */
                _.Display($"NRCERTIF = {WS_AUXILIARES_HOST.PROPVA_NRCERTIF}");

                /*" -2194- GO TO 9999-ERRO */

                M_9999_ERRO(); //GOTO
                return;

                /*" -2195- END-IF. */
            }


        }

        [StopWatch]
        /*" M-2000-PESQUISA-OPCPAG-DB-SELECT-1 */
        public void M_2000_PESQUISA_OPCPAG_DB_SELECT_1()
        {
            /*" -2188- EXEC SQL SELECT OPCAOPAG, PERIPGTO, DIA_DEBITO, AGECTADEB, OPRCTADEB, NUMCTADEB, DIGCTADEB NUM_CARTAO_CREDITO INTO :OPCAOP-OPCAOPAG, :OPCAOP-PERIPGTO, :OPCAOP-DIA-DEB, :OPCAOP-AGECTADEB:INDAGE, :OPCAOP-OPRCTADEB:INDOPR, :OPCAOP-NUMCTADEB:INDNUM, :OPCAOP-DIGCTADEB:INDDIG FROM SEGUROS.V0OPCAOPAGVA WHERE NRCERTIF = :PROPVA-NRCERTIF AND DTTERVIG IN ( '1999-12-31' , '9999-12-31' ) WITH UR END-EXEC. */

            var m_2000_PESQUISA_OPCPAG_DB_SELECT_1_Query1 = new M_2000_PESQUISA_OPCPAG_DB_SELECT_1_Query1()
            {
                PROPVA_NRCERTIF = WS_AUXILIARES_HOST.PROPVA_NRCERTIF.ToString(),
            };

            var executed_1 = M_2000_PESQUISA_OPCPAG_DB_SELECT_1_Query1.Execute(m_2000_PESQUISA_OPCPAG_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.OPCAOP_OPCAOPAG, WS_AUXILIARES_HOST.OPCAOP_OPCAOPAG);
                _.Move(executed_1.OPCAOP_PERIPGTO, WS_AUXILIARES_HOST.OPCAOP_PERIPGTO);
                _.Move(executed_1.OPCAOP_DIA_DEB, WS_AUXILIARES_HOST.OPCAOP_DIA_DEB);
                _.Move(executed_1.OPCAOP_AGECTADEB, WS_AUXILIARES_HOST.OPCAOP_AGECTADEB);
                _.Move(executed_1.INDAGE, WS_AUXILIARES.INDAGE);
                _.Move(executed_1.OPCAOP_OPRCTADEB, WS_AUXILIARES_HOST.OPCAOP_OPRCTADEB);
                _.Move(executed_1.INDOPR, WS_AUXILIARES.INDOPR);
                _.Move(executed_1.OPCAOP_NUMCTADEB, WS_AUXILIARES_HOST.OPCAOP_NUMCTADEB);
                _.Move(executed_1.INDNUM, WS_AUXILIARES.INDNUM);
                _.Move(executed_1.OPCAOP_DIGCTADEB, WS_AUXILIARES_HOST.OPCAOP_DIGCTADEB);
                _.Move(executed_1.INDDIG, WS_AUXILIARES.INDDIG);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_2000_FIM*/

        [StopWatch]
        /*" M-2010-VERIFICA-RCAP */
        private void M_2010_VERIFICA_RCAP(bool isPerform = false)
        {
            /*" -2205- MOVE '2010-VERIFICA-RCAP' TO PARAGRAFO */
            _.Move("2010-VERIFICA-RCAP", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2207- MOVE ZEROES TO WS-COUNTRCAP */
            _.Move(0, WS_AUX_ADORMECIDAS.WS_COUNTRCAP);

            /*" -2214- PERFORM M_2010_VERIFICA_RCAP_DB_SELECT_1 */

            M_2010_VERIFICA_RCAP_DB_SELECT_1();

            /*" -2217- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2218- DISPLAY 'PARAGRAFO: 2010-VERIFICA-RCAP' */
                _.Display($"PARAGRAFO: 2010-VERIFICA-RCAP");

                /*" -2219- DISPLAY 'PROBLEMAS NA LEITURA DA RCAP' */
                _.Display($"PROBLEMAS NA LEITURA DA RCAP");

                /*" -2220- DISPLAY 'NUM_CERTIFICADO =' PROPVA-NRCERTIF */
                _.Display($"NUM_CERTIFICADO ={WS_AUXILIARES_HOST.PROPVA_NRCERTIF}");

                /*" -2221- GO TO 9999-ERRO */

                M_9999_ERRO(); //GOTO
                return;

                /*" -2221- END-IF. */
            }


        }

        [StopWatch]
        /*" M-2010-VERIFICA-RCAP-DB-SELECT-1 */
        public void M_2010_VERIFICA_RCAP_DB_SELECT_1()
        {
            /*" -2214- EXEC SQL SELECT COUNT(*) INTO :WS-COUNTRCAP FROM SEGUROS.RCAPS WHERE NUM_CERTIFICADO =:PROPVA-NRCERTIF AND COD_OPERACAO <> 210 WITH UR END-EXEC. */

            var m_2010_VERIFICA_RCAP_DB_SELECT_1_Query1 = new M_2010_VERIFICA_RCAP_DB_SELECT_1_Query1()
            {
                PROPVA_NRCERTIF = WS_AUXILIARES_HOST.PROPVA_NRCERTIF.ToString(),
            };

            var executed_1 = M_2010_VERIFICA_RCAP_DB_SELECT_1_Query1.Execute(m_2010_VERIFICA_RCAP_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_COUNTRCAP, WS_AUX_ADORMECIDAS.WS_COUNTRCAP);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_2010_FIM*/

        [StopWatch]
        /*" M-3000-INSERE-SEGURADO-VGAP */
        private void M_3000_INSERE_SEGURADO_VGAP(bool isPerform = false)
        {
            /*" -2233- MOVE '3000-INSERE-SEGURADO-VGAP' TO PARAGRAFO */
            _.Move("3000-INSERE-SEGURADO-VGAP", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2235- PERFORM 3300-SELECT-CLIENTES. */

            M_3300_SELECT_CLIENTES(true);

            /*" -2236- IF (WTEM-CLIENTES EQUAL 'S' ) */

            if ((WTEM_CLIENTES == "S"))
            {

                /*" -2237- MOVE CLIENTES-IDE-SEXO TO SEGURVGA-IDE-SEXO */
                _.Move(CLIENTES.DCLCLIENTES.CLIENTES_IDE_SEXO, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_IDE_SEXO);

                /*" -2238- MOVE CLIENTES-DATA-NASCIMENTO TO SEGURVGA-DATA-NASCIMENTO */
                _.Move(CLIENTES.DCLCLIENTES.CLIENTES_DATA_NASCIMENTO, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_DATA_NASCIMENTO);

                /*" -2239- ELSE */
            }
            else
            {


                /*" -2240- MOVE ' ' TO SEGURVGA-IDE-SEXO */
                _.Move(" ", SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_IDE_SEXO);

                /*" -2241- MOVE '0001-01-01' TO SEGURVGA-DATA-NASCIMENTO */
                _.Move("0001-01-01", SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_DATA_NASCIMENTO);

                /*" -2243- END-IF */
            }


            /*" -2245- PERFORM 3400-SELECT-SUBGRUPOS */

            M_3400_SELECT_SUBGRUPOS(true);

            /*" -2246- IF (WTEM-SUBGRUPO EQUAL 'S' ) */

            if ((WTEM_SUBGRUPO == "S"))
            {

                /*" -2247- PERFORM 3100-SELECT-V0APOLICE */

                M_3100_SELECT_V0APOLICE(true);

                /*" -2248- PERFORM 3500-INSERT-SEGURVGA */

                M_3500_INSERT_SEGURVGA(true);

                /*" -2248- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_3000_FIM*/

        [StopWatch]
        /*" M-3100-SELECT-V0APOLICE */
        private void M_3100_SELECT_V0APOLICE(bool isPerform = false)
        {
            /*" -2259- MOVE '3100-SELECT-V0APOLICE' TO PARAGRAFO */
            _.Move("3100-SELECT-V0APOLICE", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2271- PERFORM M_3100_SELECT_V0APOLICE_DB_SELECT_1 */

            M_3100_SELECT_V0APOLICE_DB_SELECT_1();

            /*" -2274- IF (SQLCODE NOT EQUAL ZEROS AND +100) */

            if ((!DB.SQLCODE.In("00", "+100")))
            {

                /*" -2275- DISPLAY 'ERRO SELECT V0APOLICE  SQLCODE  = ' SQLCODE */
                _.Display($"ERRO SELECT V0APOLICE  SQLCODE  = {DB.SQLCODE}");

                /*" -2276- DISPLAY 'NUM-APOL = ' PROPVA-NUM-APOLICE */
                _.Display($"NUM-APOL = {WS_AUXILIARES_HOST.PROPVA_NUM_APOLICE}");

                /*" -2277- GO TO 9999-ERRO */

                M_9999_ERRO(); //GOTO
                return;

                /*" -2277- END-IF. */
            }


        }

        [StopWatch]
        /*" M-3100-SELECT-V0APOLICE-DB-SELECT-1 */
        public void M_3100_SELECT_V0APOLICE_DB_SELECT_1()
        {
            /*" -2271- EXEC SQL SELECT NUM_APOLICE, VALUE(NUM_ITEM, 0) + 1, MODALIDA, RAMO INTO :APOLICES-NUM-APOLICE, :APOLICES-NUM-ITEM, :APOLICES-COD-MODALIDADE, :APOLICES-RAMO-EMISSOR FROM SEGUROS.V0APOLICE WHERE NUM_APOLICE = :PROPVA-NUM-APOLICE WITH UR END-EXEC. */

            var m_3100_SELECT_V0APOLICE_DB_SELECT_1_Query1 = new M_3100_SELECT_V0APOLICE_DB_SELECT_1_Query1()
            {
                PROPVA_NUM_APOLICE = WS_AUXILIARES_HOST.PROPVA_NUM_APOLICE.ToString(),
            };

            var executed_1 = M_3100_SELECT_V0APOLICE_DB_SELECT_1_Query1.Execute(m_3100_SELECT_V0APOLICE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.APOLICES_NUM_APOLICE, APOLICES.DCLAPOLICES.APOLICES_NUM_APOLICE);
                _.Move(executed_1.APOLICES_NUM_ITEM, APOLICES.DCLAPOLICES.APOLICES_NUM_ITEM);
                _.Move(executed_1.APOLICES_COD_MODALIDADE, APOLICES.DCLAPOLICES.APOLICES_COD_MODALIDADE);
                _.Move(executed_1.APOLICES_RAMO_EMISSOR, APOLICES.DCLAPOLICES.APOLICES_RAMO_EMISSOR);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_3100_EXIT*/

        [StopWatch]
        /*" M-3200-UPDATE-V0APOLICE */
        private void M_3200_UPDATE_V0APOLICE(bool isPerform = false)
        {
            /*" -2288- MOVE '3200-UPDATE-V0APOLICE' TO PARAGRAFO */
            _.Move("3200-UPDATE-V0APOLICE", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2293- PERFORM M_3200_UPDATE_V0APOLICE_DB_UPDATE_1 */

            M_3200_UPDATE_V0APOLICE_DB_UPDATE_1();

            /*" -2296- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2297- DISPLAY 'ERRO UPDATE V0APOLICE ' SQLCODE */
                _.Display($"ERRO UPDATE V0APOLICE {DB.SQLCODE}");

                /*" -2298- DISPLAY 'NUM-APOL = ' PROPVA-NUM-APOLICE */
                _.Display($"NUM-APOL = {WS_AUXILIARES_HOST.PROPVA_NUM_APOLICE}");

                /*" -2299- GO TO 9999-ERRO */

                M_9999_ERRO(); //GOTO
                return;

                /*" -2299- END-IF. */
            }


        }

        [StopWatch]
        /*" M-3200-UPDATE-V0APOLICE-DB-UPDATE-1 */
        public void M_3200_UPDATE_V0APOLICE_DB_UPDATE_1()
        {
            /*" -2293- EXEC SQL UPDATE SEGUROS.V0APOLICE SET NUM_ITEM = :APOLICES-NUM-ITEM, TIMESTAMP = CURRENT TIMESTAMP WHERE NUM_APOLICE = :PROPVA-NUM-APOLICE END-EXEC. */

            var m_3200_UPDATE_V0APOLICE_DB_UPDATE_1_Update1 = new M_3200_UPDATE_V0APOLICE_DB_UPDATE_1_Update1()
            {
                APOLICES_NUM_ITEM = APOLICES.DCLAPOLICES.APOLICES_NUM_ITEM.ToString(),
                PROPVA_NUM_APOLICE = WS_AUXILIARES_HOST.PROPVA_NUM_APOLICE.ToString(),
            };

            M_3200_UPDATE_V0APOLICE_DB_UPDATE_1_Update1.Execute(m_3200_UPDATE_V0APOLICE_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_3200_EXIT*/

        [StopWatch]
        /*" M-3300-SELECT-CLIENTES */
        private void M_3300_SELECT_CLIENTES(bool isPerform = false)
        {
            /*" -2311- MOVE '3300-SELECT-CLIENTES' TO PARAGRAFO */
            _.Move("3300-SELECT-CLIENTES", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2313- MOVE 'S' TO WTEM-CLIENTES. */
            _.Move("S", WTEM_CLIENTES);

            /*" -2325- PERFORM M_3300_SELECT_CLIENTES_DB_SELECT_1 */

            M_3300_SELECT_CLIENTES_DB_SELECT_1();

            /*" -2328- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -2329- IF (SQLCODE EQUAL 100) */

                if ((DB.SQLCODE == 100))
                {

                    /*" -2330- MOVE 'N' TO WTEM-CLIENTES */
                    _.Move("N", WTEM_CLIENTES);

                    /*" -2331- ELSE */
                }
                else
                {


                    /*" -2332- DISPLAY 'ERRO SELECT CLIENTE ' SQLCODE */
                    _.Display($"ERRO SELECT CLIENTE {DB.SQLCODE}");

                    /*" -2333- DISPLAY 'COD-CLIENTE = ' PROPVA-CODCLIEN */
                    _.Display($"COD-CLIENTE = {WS_AUXILIARES_HOST.PROPVA_CODCLIEN}");

                    /*" -2334- GO TO 9999-ERRO */

                    M_9999_ERRO(); //GOTO
                    return;

                    /*" -2335- END-IF */
                }


                /*" -2335- END-IF. */
            }


        }

        [StopWatch]
        /*" M-3300-SELECT-CLIENTES-DB-SELECT-1 */
        public void M_3300_SELECT_CLIENTES_DB_SELECT_1()
        {
            /*" -2325- EXEC SQL SELECT NOME_RAZAO, CGCCPF, VALUE(IDE_SEXO, ' ' ), VALUE(DATA_NASCIMENTO, '1970-10-12' ) INTO :CLIENTES-NOME-RAZAO, :CLIENTES-CGCCPF, :CLIENTES-IDE-SEXO, :CLIENTES-DATA-NASCIMENTO FROM SEGUROS.CLIENTES WHERE COD_CLIENTE = :PROPVA-CODCLIEN WITH UR END-EXEC. */

            var m_3300_SELECT_CLIENTES_DB_SELECT_1_Query1 = new M_3300_SELECT_CLIENTES_DB_SELECT_1_Query1()
            {
                PROPVA_CODCLIEN = WS_AUXILIARES_HOST.PROPVA_CODCLIEN.ToString(),
            };

            var executed_1 = M_3300_SELECT_CLIENTES_DB_SELECT_1_Query1.Execute(m_3300_SELECT_CLIENTES_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CLIENTES_NOME_RAZAO, CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO);
                _.Move(executed_1.CLIENTES_CGCCPF, CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF);
                _.Move(executed_1.CLIENTES_IDE_SEXO, CLIENTES.DCLCLIENTES.CLIENTES_IDE_SEXO);
                _.Move(executed_1.CLIENTES_DATA_NASCIMENTO, CLIENTES.DCLCLIENTES.CLIENTES_DATA_NASCIMENTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_3300_SAIDA*/

        [StopWatch]
        /*" M-3400-SELECT-SUBGRUPOS */
        private void M_3400_SELECT_SUBGRUPOS(bool isPerform = false)
        {
            /*" -2347- MOVE '3400-SELECT-SUBGRUPOS' TO PARAGRAFO */
            _.Move("3400-SELECT-SUBGRUPOS", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2349- MOVE 'S' TO WTEM-SUBGRUPO. */
            _.Move("S", WTEM_SUBGRUPO);

            /*" -2361- PERFORM M_3400_SELECT_SUBGRUPOS_DB_SELECT_1 */

            M_3400_SELECT_SUBGRUPOS_DB_SELECT_1();

            /*" -2364- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -2365- IF (SQLCODE EQUAL 100) */

                if ((DB.SQLCODE == 100))
                {

                    /*" -2366- MOVE 'N' TO WTEM-SUBGRUPO */
                    _.Move("N", WTEM_SUBGRUPO);

                    /*" -2367- ELSE */
                }
                else
                {


                    /*" -2368- DISPLAY 'ERRO SELECT SUBGRUPO ' SQLCODE */
                    _.Display($"ERRO SELECT SUBGRUPO {DB.SQLCODE}");

                    /*" -2370- DISPLAY ' NUM-APOLICE ' PROPVA-NUM-APOLICE ' CODSUBES ' PROPVA-CODSUBES */

                    $" NUM-APOLICE {WS_AUXILIARES_HOST.PROPVA_NUM_APOLICE} CODSUBES {WS_AUXILIARES_HOST.PROPVA_CODSUBES}"
                    .Display();

                    /*" -2371- GO TO 9999-ERRO */

                    M_9999_ERRO(); //GOTO
                    return;

                    /*" -2372- END-IF */
                }


                /*" -2372- END-IF. */
            }


        }

        [StopWatch]
        /*" M-3400-SELECT-SUBGRUPOS-DB-SELECT-1 */
        public void M_3400_SELECT_SUBGRUPOS_DB_SELECT_1()
        {
            /*" -2361- EXEC SQL SELECT TIPO_PLANO, PERI_FATURAMENTO, PERI_RENOVACAO INTO :SUBGVGAP-TIPO-PLANO, :SUBGVGAP-PERI-FATURAMENTO, :SUBGVGAP-PERI-RENOVACAO FROM SEGUROS.SUBGRUPOS_VGAP WHERE NUM_APOLICE = :PROPVA-NUM-APOLICE AND COD_SUBGRUPO = :PROPVA-CODSUBES FETCH FIRST 1 ROW ONLY WITH UR END-EXEC. */

            var m_3400_SELECT_SUBGRUPOS_DB_SELECT_1_Query1 = new M_3400_SELECT_SUBGRUPOS_DB_SELECT_1_Query1()
            {
                PROPVA_NUM_APOLICE = WS_AUXILIARES_HOST.PROPVA_NUM_APOLICE.ToString(),
                PROPVA_CODSUBES = WS_AUXILIARES_HOST.PROPVA_CODSUBES.ToString(),
            };

            var executed_1 = M_3400_SELECT_SUBGRUPOS_DB_SELECT_1_Query1.Execute(m_3400_SELECT_SUBGRUPOS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SUBGVGAP_TIPO_PLANO, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_TIPO_PLANO);
                _.Move(executed_1.SUBGVGAP_PERI_FATURAMENTO, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_PERI_FATURAMENTO);
                _.Move(executed_1.SUBGVGAP_PERI_RENOVACAO, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_PERI_RENOVACAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_3400_SAIDA*/

        [StopWatch]
        /*" M-3500-INSERT-SEGURVGA */
        private void M_3500_INSERT_SEGURVGA(bool isPerform = false)
        {
            /*" -2383- MOVE '3500-INSERT-SEGURVGA' TO PARAGRAFO */
            _.Move("3500-INSERT-SEGURVGA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2384- MOVE 'S' TO WTEM-SEGURADOS */
            _.Move("S", WTEM_SEGURADOS);

            /*" -2386- MOVE 1 TO SEGURVGA-OCORR-HISTORICO */
            _.Move(1, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_OCORR_HISTORICO);

            /*" -2443- PERFORM M_3500_INSERT_SEGURVGA_DB_INSERT_1 */

            M_3500_INSERT_SEGURVGA_DB_INSERT_1();

            /*" -2446- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2447- IF SQLCODE EQUAL -803 */

                if (DB.SQLCODE == -803)
                {

                    /*" -2448- MOVE 'S' TO WTEM-SEGURADOS */
                    _.Move("S", WTEM_SEGURADOS);

                    /*" -2449- ELSE */
                }
                else
                {


                    /*" -2450- DISPLAY 'ERRO INSERT SEGURADOS ' SQLCODE */
                    _.Display($"ERRO INSERT SEGURADOS {DB.SQLCODE}");

                    /*" -2453- DISPLAY ' NUM-APOLICE ' PROPVA-NUM-APOLICE ' CODSUBES ' PROPVA-CODSUBES ' NRCERTIF ' PROPVA-NRCERTIF */

                    $" NUM-APOLICE {WS_AUXILIARES_HOST.PROPVA_NUM_APOLICE} CODSUBES {WS_AUXILIARES_HOST.PROPVA_CODSUBES} NRCERTIF {WS_AUXILIARES_HOST.PROPVA_NRCERTIF}"
                    .Display();

                    /*" -2454- GO TO 9999-ERRO */

                    M_9999_ERRO(); //GOTO
                    return;

                    /*" -2455- END-IF */
                }


                /*" -2456- ELSE */
            }
            else
            {


                /*" -2457- MOVE APOLICES-NUM-ITEM TO WHOST-NUM-ITEM */
                _.Move(APOLICES.DCLAPOLICES.APOLICES_NUM_ITEM, WS_AUXILIARES.WHOST_NUM_ITEM);

                /*" -2458- PERFORM 3200-UPDATE-V0APOLICE */

                M_3200_UPDATE_V0APOLICE(true);

                /*" -2459- END-IF. */
            }


        }

        [StopWatch]
        /*" M-3500-INSERT-SEGURVGA-DB-INSERT-1 */
        public void M_3500_INSERT_SEGURVGA_DB_INSERT_1()
        {
            /*" -2443- EXEC SQL INSERT INTO SEGUROS.SEGURADOS_VGAP VALUES (:PROPVA-NUM-APOLICE, :PROPVA-CODSUBES, :PROPVA-NRCERTIF, ' ' , '1' , :APOLICES-NUM-ITEM, '4' , :PROPVA-CODCLIEN, :PROPVA-FONTE, :PROPVA-NRPROPOS, 0, 0, 0, 0, 1, 'S' , 'S' , :SEGURVGA-OCORR-HISTORICO, :OPCAOP-PERIPGTO, :SUBGVGAP-PERI-RENOVACAO, 0, ' ' , ' ' , :SEGURVGA-IDE-SEXO, 0, ' ' , :PROPVA-OCOREND, :PROPVA-OCOREND, 0, 0, '0' , 0, 0, '0' , :SUBGVGAP-TIPO-PLANO, :PROPVA-DTQITBCO, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, '0' , CURRENT DATE, :SEGURVGA-DATA-NASCIMENTO, NULL, NULL, NULL) END-EXEC. */

            var m_3500_INSERT_SEGURVGA_DB_INSERT_1_Insert1 = new M_3500_INSERT_SEGURVGA_DB_INSERT_1_Insert1()
            {
                PROPVA_NUM_APOLICE = WS_AUXILIARES_HOST.PROPVA_NUM_APOLICE.ToString(),
                PROPVA_CODSUBES = WS_AUXILIARES_HOST.PROPVA_CODSUBES.ToString(),
                PROPVA_NRCERTIF = WS_AUXILIARES_HOST.PROPVA_NRCERTIF.ToString(),
                APOLICES_NUM_ITEM = APOLICES.DCLAPOLICES.APOLICES_NUM_ITEM.ToString(),
                PROPVA_CODCLIEN = WS_AUXILIARES_HOST.PROPVA_CODCLIEN.ToString(),
                PROPVA_FONTE = WS_AUXILIARES_HOST.PROPVA_FONTE.ToString(),
                PROPVA_NRPROPOS = WS_AUXILIARES_HOST.PROPVA_NRPROPOS.ToString(),
                SEGURVGA_OCORR_HISTORICO = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_OCORR_HISTORICO.ToString(),
                OPCAOP_PERIPGTO = WS_AUXILIARES_HOST.OPCAOP_PERIPGTO.ToString(),
                SUBGVGAP_PERI_RENOVACAO = SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_PERI_RENOVACAO.ToString(),
                SEGURVGA_IDE_SEXO = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_IDE_SEXO.ToString(),
                PROPVA_OCOREND = WS_AUXILIARES_HOST.PROPVA_OCOREND.ToString(),
                SUBGVGAP_TIPO_PLANO = SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_TIPO_PLANO.ToString(),
                PROPVA_DTQITBCO = WS_AUXILIARES_HOST.PROPVA_DTQITBCO.ToString(),
                SEGURVGA_DATA_NASCIMENTO = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_DATA_NASCIMENTO.ToString(),
            };

            M_3500_INSERT_SEGURVGA_DB_INSERT_1_Insert1.Execute(m_3500_INSERT_SEGURVGA_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_3500_SAIDA*/

        [StopWatch]
        /*" M-3600-INSERT-HIST-SEGURVGA */
        private void M_3600_INSERT_HIST_SEGURVGA(bool isPerform = false)
        {
            /*" -2470- MOVE '3600-INSERT-HIST-SEG' TO PARAGRAFO */
            _.Move("3600-INSERT-HIST-SEG", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2488- PERFORM M_3600_INSERT_HIST_SEGURVGA_DB_INSERT_1 */

            M_3600_INSERT_HIST_SEGURVGA_DB_INSERT_1();

            /*" -2491- IF SQLCODE NOT EQUAL ZEROS AND -803 */

            if (!DB.SQLCODE.In("00", "-803"))
            {

                /*" -2492- DISPLAY 'ERRO INSERT HISTSEGVG ' SQLCODE */
                _.Display($"ERRO INSERT HISTSEGVG {DB.SQLCODE}");

                /*" -2495- DISPLAY ' NUM-APOLICE ' PROPVA-NUM-APOLICE ' CODSUBES ' PROPVA-CODSUBES ' NRCERTIF ' PROPVA-NRCERTIF */

                $" NUM-APOLICE {WS_AUXILIARES_HOST.PROPVA_NUM_APOLICE} CODSUBES {WS_AUXILIARES_HOST.PROPVA_CODSUBES} NRCERTIF {WS_AUXILIARES_HOST.PROPVA_NRCERTIF}"
                .Display();

                /*" -2496- GO TO 9999-ERRO */

                M_9999_ERRO(); //GOTO
                return;

                /*" -2496- END-IF. */
            }


        }

        [StopWatch]
        /*" M-3600-INSERT-HIST-SEGURVGA-DB-INSERT-1 */
        public void M_3600_INSERT_HIST_SEGURVGA_DB_INSERT_1()
        {
            /*" -2488- EXEC SQL INSERT INTO SEGUROS.V0HISTSEGVG VALUES (:PROPVA-NUM-APOLICE, :PROPVA-CODSUBES, :WHOST-NUM-ITEM, 101, CURRENT_DATE, CURRENT_TIME, CURRENT_DATE, :SEGURVGA-OCORR-HISTORICO, 0, :PROPVA-DTQITBCO, 'VA4002B' , NULL, 1, 1) END-EXEC. */

            var m_3600_INSERT_HIST_SEGURVGA_DB_INSERT_1_Insert1 = new M_3600_INSERT_HIST_SEGURVGA_DB_INSERT_1_Insert1()
            {
                PROPVA_NUM_APOLICE = WS_AUXILIARES_HOST.PROPVA_NUM_APOLICE.ToString(),
                PROPVA_CODSUBES = WS_AUXILIARES_HOST.PROPVA_CODSUBES.ToString(),
                WHOST_NUM_ITEM = WS_AUXILIARES.WHOST_NUM_ITEM.ToString(),
                SEGURVGA_OCORR_HISTORICO = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_OCORR_HISTORICO.ToString(),
                PROPVA_DTQITBCO = WS_AUXILIARES_HOST.PROPVA_DTQITBCO.ToString(),
            };

            M_3600_INSERT_HIST_SEGURVGA_DB_INSERT_1_Insert1.Execute(m_3600_INSERT_HIST_SEGURVGA_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_3600_SAIDA*/

        [StopWatch]
        /*" M-3700-00-INSERT-APOLICOB */
        private void M_3700_00_INSERT_APOLICOB(bool isPerform = false)
        {
            /*" -2508- MOVE '3700-00-INSERT-APOLICOB' TO PARAGRAFO. */
            _.Move("3700-00-INSERT-APOLICOB", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2510- PERFORM 3100-SELECT-V0APOLICE. */

            M_3100_SELECT_V0APOLICE(true);

            /*" -2512- PERFORM 1390-PESQUISA-PLANOS-VAVGA. */

            M_1390_PESQUISA_PLANOS_VAVGA(true);

            /*" -2513- IF OPCAOP-PERIPGTO EQUAL ZEROS */

            if (WS_AUXILIARES_HOST.OPCAOP_PERIPGTO == 00)
            {

                /*" -2514- PERFORM 3750-00-GERA-TERVIG */

                M_3750_00_GERA_TERVIG(true);

                /*" -2515- ELSE */
            }
            else
            {


                /*" -2516- MOVE '9999-12-31' TO WHOST-DATA-TERVIGENCIA */
                _.Move("9999-12-31", WS_AUXILIARES.WHOST_DATA_TERVIGENCIA);

                /*" -2518- END-IF */
            }


            /*" -2540- PERFORM M_3700_00_INSERT_APOLICOB_DB_INSERT_1 */

            M_3700_00_INSERT_APOLICOB_DB_INSERT_1();

            /*" -2543- IF SQLCODE NOT EQUAL ZERO */

            if (DB.SQLCODE != 00)
            {

                /*" -2544- DISPLAY 'ERRO NO INSERT APOLICE_COBERTURAS' */
                _.Display($"ERRO NO INSERT APOLICE_COBERTURAS");

                /*" -2547- DISPLAY '*** CERTIFICADO: ' PROPVA-NRCERTIF ' APOLICE: ' PROPVA-NUM-APOLICE ' ITEM: ' WHOST-NUM-ITEM */

                $"*** CERTIFICADO: {WS_AUXILIARES_HOST.PROPVA_NRCERTIF} APOLICE: {WS_AUXILIARES_HOST.PROPVA_NUM_APOLICE} ITEM: {WS_AUXILIARES.WHOST_NUM_ITEM}"
                .Display();

                /*" -2548- GO TO 9999-ERRO */

                M_9999_ERRO(); //GOTO
                return;

                /*" -2548- END-IF. */
            }


        }

        [StopWatch]
        /*" M-3700-00-INSERT-APOLICOB-DB-INSERT-1 */
        public void M_3700_00_INSERT_APOLICOB_DB_INSERT_1()
        {
            /*" -2540- EXEC SQL INSERT INTO SEGUROS.V0COBERAPOL VALUES (:PROPVA-NUM-APOLICE, 0, :WHOST-NUM-ITEM, :SEGURVGA-OCORR-HISTORICO, :APOLICES-RAMO-EMISSOR, :APOLICES-COD-MODALIDADE, 11, :PLAVAVGA-IMPMORNATU, :PLAVAVGA-VLPREMIOTOT, :PLAVAVGA-IMPMORNATU, :PLAVAVGA-VLPREMIOTOT, 100, 1, :PROPVA-DTQITBCO, :WHOST-DATA-TERVIGENCIA, NULL, CURRENT TIMESTAMP, NULL) END-EXEC */

            var m_3700_00_INSERT_APOLICOB_DB_INSERT_1_Insert1 = new M_3700_00_INSERT_APOLICOB_DB_INSERT_1_Insert1()
            {
                PROPVA_NUM_APOLICE = WS_AUXILIARES_HOST.PROPVA_NUM_APOLICE.ToString(),
                WHOST_NUM_ITEM = WS_AUXILIARES.WHOST_NUM_ITEM.ToString(),
                SEGURVGA_OCORR_HISTORICO = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_OCORR_HISTORICO.ToString(),
                APOLICES_RAMO_EMISSOR = APOLICES.DCLAPOLICES.APOLICES_RAMO_EMISSOR.ToString(),
                APOLICES_COD_MODALIDADE = APOLICES.DCLAPOLICES.APOLICES_COD_MODALIDADE.ToString(),
                PLAVAVGA_IMPMORNATU = PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_IMPMORNATU.ToString(),
                PLAVAVGA_VLPREMIOTOT = PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_VLPREMIOTOT.ToString(),
                PROPVA_DTQITBCO = WS_AUXILIARES_HOST.PROPVA_DTQITBCO.ToString(),
                WHOST_DATA_TERVIGENCIA = WS_AUXILIARES.WHOST_DATA_TERVIGENCIA.ToString(),
            };

            M_3700_00_INSERT_APOLICOB_DB_INSERT_1_Insert1.Execute(m_3700_00_INSERT_APOLICOB_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3700_99_SAIDA*/

        [StopWatch]
        /*" M-3750-00-GERA-TERVIG */
        private void M_3750_00_GERA_TERVIG(bool isPerform = false)
        {
            /*" -2565- MOVE '3750-00-GERA-TERVIG' TO PARAGRAFO */
            _.Move("3750-00-GERA-TERVIG", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2574- PERFORM M_3750_00_GERA_TERVIG_DB_SELECT_1 */

            M_3750_00_GERA_TERVIG_DB_SELECT_1();

            /*" -2577- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2579- DISPLAY 'VA9134T1 - PROBLEMAS ACESSO A PROPOSTA_VA' ' NUM_CERTIFICADO = ' PROPVA-NRCERTIF */

                $"VA9134T1 - PROBLEMAS ACESSO A PROPOSTA_VA NUM_CERTIFICADO = {WS_AUXILIARES_HOST.PROPVA_NRCERTIF}"
                .Display();

                /*" -2580- GO TO 9999-ERRO */

                M_9999_ERRO(); //GOTO
                return;

                /*" -2582- END-IF */
            }


            /*" -2582- . */

        }

        [StopWatch]
        /*" M-3750-00-GERA-TERVIG-DB-SELECT-1 */
        public void M_3750_00_GERA_TERVIG_DB_SELECT_1()
        {
            /*" -2574- EXEC SQL SELECT A.DATA_QUITACAO + B.COD_CCT MONTHS INTO :WHOST-DATA-TERVIGENCIA FROM SEGUROS.PROPOSTAS_VA A , SEGUROS.PRODUTOS_VG B WHERE A.NUM_CERTIFICADO = :PROPVA-NRCERTIF AND A.NUM_APOLICE = B.NUM_APOLICE AND A.COD_SUBGRUPO = B.COD_SUBGRUPO WITH UR END-EXEC. */

            var m_3750_00_GERA_TERVIG_DB_SELECT_1_Query1 = new M_3750_00_GERA_TERVIG_DB_SELECT_1_Query1()
            {
                PROPVA_NRCERTIF = WS_AUXILIARES_HOST.PROPVA_NRCERTIF.ToString(),
            };

            var executed_1 = M_3750_00_GERA_TERVIG_DB_SELECT_1_Query1.Execute(m_3750_00_GERA_TERVIG_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_DATA_TERVIGENCIA, WS_AUXILIARES.WHOST_DATA_TERVIGENCIA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_3750_99_SAIDA*/

        [StopWatch]
        /*" M-3800-INSERT-MOVIMENTO */
        private void M_3800_INSERT_MOVIMENTO(bool isPerform = false)
        {
            /*" -2596- MOVE '3800-INSERT-MOVIMENTO' TO PARAGRAFO */
            _.Move("3800-INSERT-MOVIMENTO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2749- PERFORM M_3800_INSERT_MOVIMENTO_DB_INSERT_1 */

            M_3800_INSERT_MOVIMENTO_DB_INSERT_1();

            /*" -2752- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2753- IF SQLCODE EQUAL -803 */

                if (DB.SQLCODE == -803)
                {

                    /*" -2754- MOVE 'S' TO WTEM-MOVIMENTO */
                    _.Move("S", WTEM_MOVIMENTO);

                    /*" -2755- ELSE */
                }
                else
                {


                    /*" -2756- DISPLAY 'ERRO INSERT MOVIMENTO ' SQLCODE */
                    _.Display($"ERRO INSERT MOVIMENTO {DB.SQLCODE}");

                    /*" -2759- DISPLAY 'NUM-APOLICE  ' PROPVA-NUM-APOLICE 'CODSUBES     ' PROPVA-CODSUBES 'NRCERTIF     ' PROPVA-NRCERTIF */

                    $"NUM-APOLICE  {WS_AUXILIARES_HOST.PROPVA_NUM_APOLICE}CODSUBES     {WS_AUXILIARES_HOST.PROPVA_CODSUBES}NRCERTIF     {WS_AUXILIARES_HOST.PROPVA_NRCERTIF}"
                    .Display();

                    /*" -2760- GO TO 9999-ERRO */

                    M_9999_ERRO(); //GOTO
                    return;

                    /*" -2761- END-IF */
                }


                /*" -2762- END-IF. */
            }


        }

        [StopWatch]
        /*" M-3800-INSERT-MOVIMENTO-DB-INSERT-1 */
        public void M_3800_INSERT_MOVIMENTO_DB_INSERT_1()
        {
            /*" -2749- EXEC SQL INSERT INTO SEGUROS.V0MOVIMENTO ( NUM_APOLICE , COD_SUBGRUPO , COD_FONTE , NUM_PROPOSTA , TIPO_SEGURADO , NUM_CERTIFICADO , DAC_CERTIFICADO , TIPO_INCLUSAO , COD_CLIENTE , COD_AGENCIADOR , COD_CORRETOR , COD_PLANOVGAP , COD_PLANOAP , FAIXA , AUTOR_AUM_AUTOMAT , TIPO_BENEFICIARIO , PERI_PAGAMENTO , PERI_RENOVACAO , COD_OCUPACAO , ESTADO_CIVIL , IDE_SEXO , COD_PROFISSAO , NATURALIDADE , OCORR_ENDERECO , OCORR_END_COBRAN , BCO_COBRANCA , AGE_COBRANCA , DAC_COBRANCA , NUM_MATRICULA , NUM_CTA_CORRENTE , DAC_CTA_CORRENTE , VAL_SALARIO , TIPO_SALARIO , TIPO_PLANO , PCT_CONJUGE_VG , PCT_CONJUGE_AP , QTD_SAL_MORNATU , QTD_SAL_MORACID , QTD_SAL_INVPERM , TAXA_AP_MORACID , TAXA_AP_INVPERM , TAXA_AP_AMDS , TAXA_AP_DH , TAXA_AP_DIT , TAXA_VG , IMP_MORNATU_ANT , IMP_MORNATU_ATU , IMP_MORACID_ANT , IMP_MORACID_ATU , IMP_INVPERM_ANT , IMP_INVPERM_ATU , IMP_AMDS_ANT , IMP_AMDS_ATU , IMP_DH_ANT , IMP_DH_ATU , IMP_DIT_ANT , IMP_DIT_ATU , PRM_VG_ANT , PRM_VG_ATU , PRM_AP_ANT , PRM_AP_ATU , COD_OPERACAO , DATA_OPERACAO , COD_SUBGRUPO_TRANS , SIT_REGISTRO , COD_USUARIO , DATA_AVERBACAO , DATA_ADMISSAO , DATA_INCLUSAO , DATA_NASCIMENTO , DATA_FATURA , DATA_REFERENCIA , DATA_MOVIMENTO , COD_EMPRESA , LOT_EMP_SEGURADO) VALUES (:PROPVA-NUM-APOLICE, :PROPVA-CODSUBES, :PROPVA-FONTE, :FONTE-PROPAUTOM, '1' , :PROPVA-NRCERTIF, ' ' , '4' , :PROPVA-CODCLIEN, 0, 0, 0, 0, 0, 'S' , 'N' , :OPCAOP-PERIPGTO, 12, ' ' , :PROPVA-EST-CIV, :PROPVA-SEXO, 0, ' ' , 1, 1, 104, :CONTACOR-COD-AGENCIA, ' ' , 0, :CONTACOR-NUM-CTA-CORRENTE, :CONTACOR-DAC-CTA-CORRENTE, 0, ' ' , '1' , 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, :HISCOBPR-IMP_MORNATU, 0, :HISCOBPR-IMPMORACID, 0, :HISCOBPR-IMPINVPERM, 0, 0, 0, 0, :HISCOBPR-IMPDIT, :HISCOBPR-IMPDIT, :HISCOBPR-PRMVG, :HISCOBPR-PRMVG, :HISCOBPR-PRMAP, :HISCOBPR-PRMAP, 101, CURRENT DATE, 0, '1' , 'VA4002B' , CURRENT DATE, :PROPVA-DTADMIS:PROPVA-IDTADMIS, :PROPVA-DTINCLUS, :CLIENT-DTNASC, NULL, :FATURCON-DATA-REFERENCIA:VIND-DATA-REF, :PROPVA-DTQITBCO, NULL, NULL) END-EXEC. */

            var m_3800_INSERT_MOVIMENTO_DB_INSERT_1_Insert1 = new M_3800_INSERT_MOVIMENTO_DB_INSERT_1_Insert1()
            {
                PROPVA_NUM_APOLICE = WS_AUXILIARES_HOST.PROPVA_NUM_APOLICE.ToString(),
                PROPVA_CODSUBES = WS_AUXILIARES_HOST.PROPVA_CODSUBES.ToString(),
                PROPVA_FONTE = WS_AUXILIARES_HOST.PROPVA_FONTE.ToString(),
                FONTE_PROPAUTOM = FONTE_PROPAUTOM.ToString(),
                PROPVA_NRCERTIF = WS_AUXILIARES_HOST.PROPVA_NRCERTIF.ToString(),
                PROPVA_CODCLIEN = WS_AUXILIARES_HOST.PROPVA_CODCLIEN.ToString(),
                OPCAOP_PERIPGTO = WS_AUXILIARES_HOST.OPCAOP_PERIPGTO.ToString(),
                PROPVA_EST_CIV = WS_AUXILIARES_HOST.PROPVA_EST_CIV.ToString(),
                PROPVA_SEXO = WS_AUXILIARES_HOST.PROPVA_SEXO.ToString(),
                CONTACOR_COD_AGENCIA = CONTACOR.DCLCONTA_CORRENTE.CONTACOR_COD_AGENCIA.ToString(),
                CONTACOR_NUM_CTA_CORRENTE = CONTACOR.DCLCONTA_CORRENTE.CONTACOR_NUM_CTA_CORRENTE.ToString(),
                CONTACOR_DAC_CTA_CORRENTE = CONTACOR.DCLCONTA_CORRENTE.CONTACOR_DAC_CTA_CORRENTE.ToString(),
                HISCOBPR_IMP_MORNATU = WS_AUXILIARES_HOST.HISCOBPR_IMP_MORNATU.ToString(),
                HISCOBPR_IMPMORACID = WS_AUXILIARES_HOST.HISCOBPR_IMPMORACID.ToString(),
                HISCOBPR_IMPINVPERM = WS_AUXILIARES_HOST.HISCOBPR_IMPINVPERM.ToString(),
                HISCOBPR_IMPDIT = WS_AUXILIARES_HOST.HISCOBPR_IMPDIT.ToString(),
                HISCOBPR_PRMVG = WS_AUXILIARES_HOST.HISCOBPR_PRMVG.ToString(),
                HISCOBPR_PRMAP = WS_AUXILIARES_HOST.HISCOBPR_PRMAP.ToString(),
                PROPVA_DTADMIS = WS_AUXILIARES_HOST.PROPVA_DTADMIS.ToString(),
                PROPVA_IDTADMIS = WS_AUXILIARES_HOST.PROPVA_IDTADMIS.ToString(),
                PROPVA_DTINCLUS = WS_AUXILIARES_HOST.PROPVA_DTINCLUS.ToString(),
                CLIENT_DTNASC = WS_AUXILIARES_HOST.CLIENT_DTNASC.ToString(),
                FATURCON_DATA_REFERENCIA = FATURCON.DCLFATURAS_CONTROLE.FATURCON_DATA_REFERENCIA.ToString(),
                VIND_DATA_REF = VIND_DATA_REF.ToString(),
                PROPVA_DTQITBCO = WS_AUXILIARES_HOST.PROPVA_DTQITBCO.ToString(),
            };

            M_3800_INSERT_MOVIMENTO_DB_INSERT_1_Insert1.Execute(m_3800_INSERT_MOVIMENTO_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_3800_SAIDA*/

        [StopWatch]
        /*" M-3810-ACESSA-FONTE */
        private void M_3810_ACESSA_FONTE(bool isPerform = false)
        {
            /*" -2776- MOVE '3810-ACESSA-FONTE' TO PARAGRAFO. */
            _.Move("3810-ACESSA-FONTE", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2783- PERFORM M_3810_ACESSA_FONTE_DB_SELECT_1 */

            M_3810_ACESSA_FONTE_DB_SELECT_1();

            /*" -2786- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -2787- DISPLAY 'VA4002B - FONTE NAO CADASTRADA   ' */
                _.Display($"VA4002B - FONTE NAO CADASTRADA   ");

                /*" -2788- DISPLAY 'FONTE ........ ' PROPVA-FONTE */
                _.Display($"FONTE ........ {WS_AUXILIARES_HOST.PROPVA_FONTE}");

                /*" -2790- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


            /*" -2791- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2792- DISPLAY 'VA4002B - ERRO NA LEITURA DA V1FONTE  ' */
                _.Display($"VA4002B - ERRO NA LEITURA DA V1FONTE  ");

                /*" -2794- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


            /*" -2794- COMPUTE FONTE-PROPAUTOM = FONTE-PROPAUTOM + 1. */
            FONTE_PROPAUTOM.Value = FONTE_PROPAUTOM + 1;

        }

        [StopWatch]
        /*" M-3810-ACESSA-FONTE-DB-SELECT-1 */
        public void M_3810_ACESSA_FONTE_DB_SELECT_1()
        {
            /*" -2783- EXEC SQL SELECT PROPAUTOM INTO :FONTE-PROPAUTOM FROM SEGUROS.V1FONTE WHERE FONTE = :PROPVA-FONTE END-EXEC. */

            var m_3810_ACESSA_FONTE_DB_SELECT_1_Query1 = new M_3810_ACESSA_FONTE_DB_SELECT_1_Query1()
            {
                PROPVA_FONTE = WS_AUXILIARES_HOST.PROPVA_FONTE.ToString(),
            };

            var executed_1 = M_3810_ACESSA_FONTE_DB_SELECT_1_Query1.Execute(m_3810_ACESSA_FONTE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.FONTE_PROPAUTOM, FONTE_PROPAUTOM);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_3810_999_EXIT*/

        [StopWatch]
        /*" M-3820-ATUALIZA-FONTE */
        private void M_3820_ATUALIZA_FONTE(bool isPerform = false)
        {
            /*" -2808- MOVE '3820-ATUALIZA-FONTE' TO PARAGRAFO. */
            _.Move("3820-ATUALIZA-FONTE", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2813- PERFORM M_3820_ATUALIZA_FONTE_DB_UPDATE_1 */

            M_3820_ATUALIZA_FONTE_DB_UPDATE_1();

            /*" -2816- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -2817- DISPLAY 'VA4002B - FONTE NAO CADASTRADA   ' */
                _.Display($"VA4002B - FONTE NAO CADASTRADA   ");

                /*" -2818- DISPLAY 'FONTE ........ ' PROPVA-FONTE */
                _.Display($"FONTE ........ {WS_AUXILIARES_HOST.PROPVA_FONTE}");

                /*" -2820- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


            /*" -2821- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2822- DISPLAY 'VA4002B - ERRO NA ATUALIZACAO DA V0FONTE' */
                _.Display($"VA4002B - ERRO NA ATUALIZACAO DA V0FONTE");

                /*" -2822- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-3820-ATUALIZA-FONTE-DB-UPDATE-1 */
        public void M_3820_ATUALIZA_FONTE_DB_UPDATE_1()
        {
            /*" -2813- EXEC SQL UPDATE SEGUROS.V0FONTE SET PROPAUTOM = :FONTE-PROPAUTOM, TIMESTAMP = CURRENT TIMESTAMP WHERE FONTE = :PROPVA-FONTE END-EXEC. */

            var m_3820_ATUALIZA_FONTE_DB_UPDATE_1_Update1 = new M_3820_ATUALIZA_FONTE_DB_UPDATE_1_Update1()
            {
                FONTE_PROPAUTOM = FONTE_PROPAUTOM.ToString(),
                PROPVA_FONTE = WS_AUXILIARES_HOST.PROPVA_FONTE.ToString(),
            };

            M_3820_ATUALIZA_FONTE_DB_UPDATE_1_Update1.Execute(m_3820_ATUALIZA_FONTE_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_3820_999_EXIT*/

        [StopWatch]
        /*" M-3830-CONTA-CORRENTE */
        private void M_3830_CONTA_CORRENTE(bool isPerform = false)
        {
            /*" -2832- MOVE '3830-CONTA-CORRENTE' TO PARAGRAFO. */
            _.Move("3830-CONTA-CORRENTE", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2841- PERFORM M_3830_CONTA_CORRENTE_DB_SELECT_1 */

            M_3830_CONTA_CORRENTE_DB_SELECT_1();

            /*" -2844- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2845- MOVE ZEROS TO CONTACOR-COD-AGENCIA */
                _.Move(0, CONTACOR.DCLCONTA_CORRENTE.CONTACOR_COD_AGENCIA);

                /*" -2846- MOVE ZEROS TO CONTACOR-NUM-CTA-CORRENTE */
                _.Move(0, CONTACOR.DCLCONTA_CORRENTE.CONTACOR_NUM_CTA_CORRENTE);

                /*" -2847- MOVE SPACES TO CONTACOR-DAC-CTA-CORRENTE */
                _.Move("", CONTACOR.DCLCONTA_CORRENTE.CONTACOR_DAC_CTA_CORRENTE);

                /*" -2847- END-IF. */
            }


        }

        [StopWatch]
        /*" M-3830-CONTA-CORRENTE-DB-SELECT-1 */
        public void M_3830_CONTA_CORRENTE_DB_SELECT_1()
        {
            /*" -2841- EXEC SQL SELECT COD_AGENCIA, NUM_CTA_CORRENTE, DAC_CTA_CORRENTE INTO :CONTACOR-COD-AGENCIA, :CONTACOR-NUM-CTA-CORRENTE, :CONTACOR-DAC-CTA-CORRENTE FROM SEGUROS.CONTA_CORRENTE WHERE NUM_CERTIFICADO = :PROPVA-NRCERTIF END-EXEC. */

            var m_3830_CONTA_CORRENTE_DB_SELECT_1_Query1 = new M_3830_CONTA_CORRENTE_DB_SELECT_1_Query1()
            {
                PROPVA_NRCERTIF = WS_AUXILIARES_HOST.PROPVA_NRCERTIF.ToString(),
            };

            var executed_1 = M_3830_CONTA_CORRENTE_DB_SELECT_1_Query1.Execute(m_3830_CONTA_CORRENTE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CONTACOR_COD_AGENCIA, CONTACOR.DCLCONTA_CORRENTE.CONTACOR_COD_AGENCIA);
                _.Move(executed_1.CONTACOR_NUM_CTA_CORRENTE, CONTACOR.DCLCONTA_CORRENTE.CONTACOR_NUM_CTA_CORRENTE);
                _.Move(executed_1.CONTACOR_DAC_CTA_CORRENTE, CONTACOR.DCLCONTA_CORRENTE.CONTACOR_DAC_CTA_CORRENTE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_3830_999_SAIDA*/

        [StopWatch]
        /*" M-3840-DATA-REFERENCIA */
        private void M_3840_DATA_REFERENCIA(bool isPerform = false)
        {
            /*" -2858- MOVE '3840-DATA-REFERENCIA' TO PARAGRAFO. */
            _.Move("3840-DATA-REFERENCIA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2864- PERFORM M_3840_DATA_REFERENCIA_DB_SELECT_1 */

            M_3840_DATA_REFERENCIA_DB_SELECT_1();

            /*" -2867- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2874- PERFORM M_3840_DATA_REFERENCIA_DB_SELECT_2 */

                M_3840_DATA_REFERENCIA_DB_SELECT_2();

                /*" -2876- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -2878- MOVE SISTEMA-DTMOVABE TO FATURCON-DATA-REFERENCIA */
                    _.Move(SISTEMA_DTMOVABE, FATURCON.DCLFATURAS_CONTROLE.FATURCON_DATA_REFERENCIA);

                    /*" -2879- END-IF */
                }


                /*" -2879- END-IF. */
            }


        }

        [StopWatch]
        /*" M-3840-DATA-REFERENCIA-DB-SELECT-1 */
        public void M_3840_DATA_REFERENCIA_DB_SELECT_1()
        {
            /*" -2864- EXEC SQL SELECT DATA_REFERENCIA INTO :FATURCON-DATA-REFERENCIA FROM SEGUROS.FATURAS_CONTROLE WHERE NUM_APOLICE = :PROPVA-NUM-APOLICE AND COD_SUBGRUPO = :PROPVA-CODSUBES END-EXEC */

            var m_3840_DATA_REFERENCIA_DB_SELECT_1_Query1 = new M_3840_DATA_REFERENCIA_DB_SELECT_1_Query1()
            {
                PROPVA_NUM_APOLICE = WS_AUXILIARES_HOST.PROPVA_NUM_APOLICE.ToString(),
                PROPVA_CODSUBES = WS_AUXILIARES_HOST.PROPVA_CODSUBES.ToString(),
            };

            var executed_1 = M_3840_DATA_REFERENCIA_DB_SELECT_1_Query1.Execute(m_3840_DATA_REFERENCIA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.FATURCON_DATA_REFERENCIA, FATURCON.DCLFATURAS_CONTROLE.FATURCON_DATA_REFERENCIA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_3840_999_SAIDA*/

        [StopWatch]
        /*" M-3840-DATA-REFERENCIA-DB-SELECT-2 */
        public void M_3840_DATA_REFERENCIA_DB_SELECT_2()
        {
            /*" -2874- EXEC SQL SELECT DATA_REFERENCIA INTO :FATURCON-DATA-REFERENCIA FROM SEGUROS.FATURAS_CONTROLE WHERE NUM_APOLICE = :PROPVA-NUM-APOLICE AND COD_SUBGRUPO = 0 WITH UR END-EXEC */

            var m_3840_DATA_REFERENCIA_DB_SELECT_2_Query1 = new M_3840_DATA_REFERENCIA_DB_SELECT_2_Query1()
            {
                PROPVA_NUM_APOLICE = WS_AUXILIARES_HOST.PROPVA_NUM_APOLICE.ToString(),
            };

            var executed_1 = M_3840_DATA_REFERENCIA_DB_SELECT_2_Query1.Execute(m_3840_DATA_REFERENCIA_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.FATURCON_DATA_REFERENCIA, FATURCON.DCLFATURAS_CONTROLE.FATURCON_DATA_REFERENCIA);
            }


        }

        [StopWatch]
        /*" M-3850-DATA-CLIENTE */
        private void M_3850_DATA_CLIENTE(bool isPerform = false)
        {
            /*" -2887- MOVE '3840-DATA-CLIENTE' TO PARAGRAFO. */
            _.Move("3840-DATA-CLIENTE", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2889- MOVE ZERO TO WS-ACESSO-CLIENTE */
            _.Move(0, WS_WORK_AREAS.WS_ACESSO_CLIENTE);

            /*" -2895- PERFORM M_3850_DATA_CLIENTE_DB_SELECT_1 */

            M_3850_DATA_CLIENTE_DB_SELECT_1();

            /*" -2899- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2900- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2901- DISPLAY 'VA4002B - CLIENTE NAO CADASTRADO ' */
                    _.Display($"VA4002B - CLIENTE NAO CADASTRADO ");

                    /*" -2903- DISPLAY '          CERTIFICADO........... ' PROPVA-NRCERTIF */
                    _.Display($"          CERTIFICADO........... {WS_AUXILIARES_HOST.PROPVA_NRCERTIF}");

                    /*" -2905- DISPLAY '          CODIGO DO CLIENTE..... ' PROPVA-CODCLIEN */
                    _.Display($"          CODIGO DO CLIENTE..... {WS_AUXILIARES_HOST.PROPVA_CODCLIEN}");

                    /*" -2906- ELSE */
                }
                else
                {


                    /*" -2907- DISPLAY 'VA4002B - ERRO NO ACESSO CLIENTE ' */
                    _.Display($"VA4002B - ERRO NO ACESSO CLIENTE ");

                    /*" -2909- DISPLAY '          CERTIFICADO........... ' PROPVA-NRCERTIF */
                    _.Display($"          CERTIFICADO........... {WS_AUXILIARES_HOST.PROPVA_NRCERTIF}");

                    /*" -2911- DISPLAY '          CODIGO DO CLIENTE..... ' PROPVA-CODCLIEN */
                    _.Display($"          CODIGO DO CLIENTE..... {WS_AUXILIARES_HOST.PROPVA_CODCLIEN}");

                    /*" -2913- DISPLAY '          SQLCODE............... ' SQLCODE */
                    _.Display($"          SQLCODE............... {DB.SQLCODE}");

                    /*" -2914- GO TO 9999-ERRO */

                    M_9999_ERRO(); //GOTO
                    return;

                    /*" -2915- END-IF */
                }


                /*" -2915- END-IF. */
            }


        }

        [StopWatch]
        /*" M-3850-DATA-CLIENTE-DB-SELECT-1 */
        public void M_3850_DATA_CLIENTE_DB_SELECT_1()
        {
            /*" -2895- EXEC SQL SELECT DATA_NASCIMENTO INTO :CLIENT-DTNASC FROM SEGUROS.V0CLIENTE WHERE COD_CLIENTE = :PROPVA-CODCLIEN WITH UR END-EXEC */

            var m_3850_DATA_CLIENTE_DB_SELECT_1_Query1 = new M_3850_DATA_CLIENTE_DB_SELECT_1_Query1()
            {
                PROPVA_CODCLIEN = WS_AUXILIARES_HOST.PROPVA_CODCLIEN.ToString(),
            };

            var executed_1 = M_3850_DATA_CLIENTE_DB_SELECT_1_Query1.Execute(m_3850_DATA_CLIENTE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CLIENT_DTNASC, WS_AUXILIARES_HOST.CLIENT_DTNASC);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_3850_999_SAIDA*/

        [StopWatch]
        /*" M-3860-HIS-COBER-PROPOST */
        private void M_3860_HIS_COBER_PROPOST(bool isPerform = false)
        {
            /*" -2925- MOVE '3860-HIS_COBER_PROPOST' TO PARAGRAFO. */
            _.Move("3860-HIS_COBER_PROPOST", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2946- PERFORM M_3860_HIS_COBER_PROPOST_DB_SELECT_1 */

            M_3860_HIS_COBER_PROPOST_DB_SELECT_1();

            /*" -2949- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2950- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-3860-HIS-COBER-PROPOST-DB-SELECT-1 */
        public void M_3860_HIS_COBER_PROPOST_DB_SELECT_1()
        {
            /*" -2946- EXEC SQL SELECT IMP_MORNATU, IMPMORACID, IMPINVPERM, IMPAMDS, IMPDH, IMPDIT, VLPREMIO, PRMVG, PRMAP INTO :HISCOBPR-IMP_MORNATU, :HISCOBPR-IMPMORACID, :HISCOBPR-IMPINVPERM, :HISCOBPR-IMPAMDS, :HISCOBPR-IMPDH, :HISCOBPR-IMPDIT, :HISCOBPR-VLPREMIO, :HISCOBPR-PRMVG, :HISCOBPR-PRMAP FROM SEGUROS.HIS_COBER_PROPOST WHERE NUM_CERTIFICADO = :PROPVA-NRCERTIF END-EXEC. */

            var m_3860_HIS_COBER_PROPOST_DB_SELECT_1_Query1 = new M_3860_HIS_COBER_PROPOST_DB_SELECT_1_Query1()
            {
                PROPVA_NRCERTIF = WS_AUXILIARES_HOST.PROPVA_NRCERTIF.ToString(),
            };

            var executed_1 = M_3860_HIS_COBER_PROPOST_DB_SELECT_1_Query1.Execute(m_3860_HIS_COBER_PROPOST_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HISCOBPR_IMP_MORNATU, WS_AUXILIARES_HOST.HISCOBPR_IMP_MORNATU);
                _.Move(executed_1.HISCOBPR_IMPMORACID, WS_AUXILIARES_HOST.HISCOBPR_IMPMORACID);
                _.Move(executed_1.HISCOBPR_IMPINVPERM, WS_AUXILIARES_HOST.HISCOBPR_IMPINVPERM);
                _.Move(executed_1.HISCOBPR_IMPAMDS, WS_AUXILIARES_HOST.HISCOBPR_IMPAMDS);
                _.Move(executed_1.HISCOBPR_IMPDH, WS_AUXILIARES_HOST.HISCOBPR_IMPDH);
                _.Move(executed_1.HISCOBPR_IMPDIT, WS_AUXILIARES_HOST.HISCOBPR_IMPDIT);
                _.Move(executed_1.HISCOBPR_VLPREMIO, WS_AUXILIARES_HOST.HISCOBPR_VLPREMIO);
                _.Move(executed_1.HISCOBPR_PRMVG, WS_AUXILIARES_HOST.HISCOBPR_PRMVG);
                _.Move(executed_1.HISCOBPR_PRMAP, WS_AUXILIARES_HOST.HISCOBPR_PRMAP);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_3860_999_SAIDA*/

        [StopWatch]
        /*" M-9000-FINALIZA */
        private void M_9000_FINALIZA(bool isPerform = false)
        {
            /*" -2996- MOVE '9000-FINALIZA' TO PARAGRAFO. */
            _.Move("9000-FINALIZA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2998- MOVE 'COMMIT WORK' TO COMANDO. */
            _.Move("COMMIT WORK", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2998- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -3001- IF SQLCODE NOT EQUAL ZERO */

            if (DB.SQLCODE != 00)
            {

                /*" -3002- DISPLAY 'ERRO NO COMMIT FINAL' */
                _.Display($"ERRO NO COMMIT FINAL");

                /*" -3003- GO TO 9999-ERRO */

                M_9999_ERRO(); //GOTO
                return;

                /*" -3005- END-IF. */
            }


            /*" -3007- CLOSE ARQEMIT. */
            ARQEMIT.Close();

            /*" -3008- DISPLAY ' ' . */
            _.Display($" ");

            /*" -3009- DISPLAY '*** VA4002B *** TERMINO NORMAL' . */
            _.Display($"*** VA4002B *** TERMINO NORMAL");

            /*" -3010- DISPLAY ' ' . */
            _.Display($" ");

            /*" -3011- DISPLAY 'PROPOSTAS PROCESSADAS......... ' AC-LIDOS. */
            _.Display($"PROPOSTAS PROCESSADAS......... {WS_WORK_AREAS.AC_LIDOS}");

            /*" -3012- DISPLAY 'QT PROP INTEGRADAS.............' WS-INTEGRADO. */
            _.Display($"QT PROP INTEGRADAS.............{WS_AUX_ADORMECIDAS.WS_INTEGRADO}");

            /*" -3013- DISPLAY '   INTEGRADAS COM ERRO.........' WS-INTEGRADO-ERRO. */
            _.Display($"   INTEGRADAS COM ERRO.........{WS_AUX_ADORMECIDAS.WS_INTEGRADO_ERRO}");

            /*" -3014- DISPLAY 'QT PROP COM ERRO IMPEDITIVO....' WS-CRITICADO. */
            _.Display($"QT PROP COM ERRO IMPEDITIVO....{WS_AUX_ADORMECIDAS.WS_CRITICADO}");

            /*" -3015- DISPLAY 'QT PROP CANCELADA..............' WS-CANCELADO. */
            _.Display($"QT PROP CANCELADA..............{WS_AUX_ADORMECIDAS.WS_CANCELADO}");

            /*" -3015- DISPLAY 'ATUA. MOVIMENTO_VGAP...........' AC-ATUA-MOVTO-VGAP. */
            _.Display($"ATUA. MOVIMENTO_VGAP...........{WS_WORK_AREAS.AC_ATUA_MOVTO_VGAP}");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_9000_FIM*/

        [StopWatch]
        /*" M-9999-ERRO */
        private void M_9999_ERRO(bool isPerform = false)
        {
            /*" -3026- DISPLAY '***** VA4002B - ERRO DE EXECUCAO *****' */
            _.Display($"***** VA4002B - ERRO DE EXECUCAO *****");

            /*" -3027- DISPLAY ' ' */
            _.Display($" ");

            /*" -3028- DISPLAY 'PARAGRAFO ' PARAGRAFO */
            _.Display($"PARAGRAFO {WABEND.LOCALIZA_ABEND_1.PARAGRAFO}");

            /*" -3029- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, WABEND.FILLER_41.WSQLCODE);

            /*" -3030- MOVE SQLERRD(1) TO WSQLERRD1. */
            _.Move(DB.SQLERRD[1], WABEND.FILLER_41.WSQLERRD1);

            /*" -3031- MOVE SQLERRD(2) TO WSQLERRD2. */
            _.Move(DB.SQLERRD[2], WABEND.FILLER_41.WSQLERRD2);

            /*" -3032- MOVE SQLERRD(3) TO WSQLERRD3. */
            _.Move(DB.SQLERRD[3], WABEND.FILLER_41.WSQLERRD3);

            /*" -3033- MOVE SQLERRD(4) TO WSQLERRD4. */
            _.Move(DB.SQLERRD[4], WABEND.FILLER_41.WSQLERRD4);

            /*" -3034- MOVE SQLERRD(5) TO WSQLERRD5. */
            _.Move(DB.SQLERRD[5], WABEND.FILLER_41.WSQLERRD5);

            /*" -3035- MOVE SQLCODE TO WSQLCODE3. */
            _.Move(DB.SQLCODE, WS_WORK_AREAS.WSQLCODE3);

            /*" -3036- DISPLAY WABEND. */
            _.Display(WABEND);

            /*" -3037- DISPLAY ' ' */
            _.Display($" ");

            /*" -3039- DISPLAY '*** VA4002B *** ROLLBACK EM ANDAMENTO ...' . */
            _.Display($"*** VA4002B *** ROLLBACK EM ANDAMENTO ...");

            /*" -3039- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -3042- MOVE '9999-ERRO' TO PARAGRAFO. */
            _.Move("9999-ERRO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3043- MOVE 'ROLLBACK WORK' TO COMANDO. */
            _.Move("ROLLBACK WORK", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3043- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -3047- CLOSE ARQEMIT. */
            ARQEMIT.Close();

            /*" -3048- DISPLAY ' ' . */
            _.Display($" ");

            /*" -3049- DISPLAY 'LIDOS ................ ' AC-LIDOS. */
            _.Display($"LIDOS ................ {WS_WORK_AREAS.AC_LIDOS}");

            /*" -3050- DISPLAY ' ' . */
            _.Display($" ");

            /*" -3051- DISPLAY 'INCLUSOES ............ ' AC-INCLUSOES. */
            _.Display($"INCLUSOES ............ {WS_WORK_AREAS.AC_INCLUSOES}");

            /*" -3052- DISPLAY ' ' . */
            _.Display($" ");

            /*" -3053- DISPLAY 'DESPREZADOS .......... ' AC-DESPREZADOS. */
            _.Display($"DESPREZADOS .......... {WS_WORK_AREAS.AC_DESPREZADOS}");

            /*" -3055- DISPLAY ' ' */
            _.Display($" ");

            /*" -3056- DISPLAY 'CERTIFICADO... ' PROPVA-NRCERTIF. */
            _.Display($"CERTIFICADO... {WS_AUXILIARES_HOST.PROPVA_NRCERTIF}");

            /*" -3057- DISPLAY 'APOLICE....... ' PROPVA-NUM-APOLICE */
            _.Display($"APOLICE....... {WS_AUXILIARES_HOST.PROPVA_NUM_APOLICE}");

            /*" -3058- DISPLAY 'SUBGRUPO...... ' PROPVA-CODSUBES */
            _.Display($"SUBGRUPO...... {WS_AUXILIARES_HOST.PROPVA_CODSUBES}");

            /*" -3059- DISPLAY 'PROPAUTOM..... ' FONTE-PROPAUTOM. */
            _.Display($"PROPAUTOM..... {FONTE_PROPAUTOM}");

            /*" -3060- DISPLAY 'FONTE......... ' PROPVA-FONTE. */
            _.Display($"FONTE......... {WS_AUXILIARES_HOST.PROPVA_FONTE}");

            /*" -3061- DISPLAY 'TITULO........ ' BANCOS-NRTIT. */
            _.Display($"TITULO........ {BANCOS_NRTIT}");

            /*" -3062- DISPLAY ' ' */
            _.Display($" ");

            /*" -3064- DISPLAY '***** VA4002B - ERRO DE EXECUCAO *****' */
            _.Display($"***** VA4002B - ERRO DE EXECUCAO *****");

            /*" -3065- MOVE 9 TO RETURN-CODE. */
            _.Move(9, RETURN_CODE);

            /*" -3065- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}