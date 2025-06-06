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
using Sias.VidaAzul.DB2.VA0055B;

namespace Code
{
    public class VA0055B
    {
        public bool IsCall { get; set; }

        public VA0055B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      ******************************************************************      */
        /*"      *   SISTEMA ................  VA - VIDA                          *      */
        /*"      *                                                                *      */
        /*"      *   PROGRAMA ...............  VA0055B                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA................  FAST COMPUTER                      *      */
        /*"      *                                                                *      */
        /*"      *   PROGRAMADOR ............  FAST COMPUTER                      *      */
        /*"      *                                                                *      */
        /*"      *   DATA CODIFICACAO .......  SETEMBRO/2005                      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO .................  PROCESSA RETORNO CRIVO             *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.25  *  VERSAO  25 - SOLICITACAO RITM0000@#@                          *      */
        /*"      *             - CORRIGIR LAYOUT DA CRIVO (DATA-REG APOS USUARIO) *      */
        /*"      *   EM 19/11/2024 - KINKAS               PROCURE POR V.25        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.24  *  VERSAO  24 - SOLICITACAO RITM0000172                          *      */
        /*"      *             - GRAVAR MENSAGEM DE RETORNO NA VG_CRITICA_PROPOSTA*      */
        /*"      *             - NAO GRAVAR ERRO SERASA E ACSP FORA DO AR         *      */
        /*"      *   EM 20/08/2024 - ELIERMES             PROCURE POR V.24        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.23  *   VERSAO 23 - DEMANDA 548.221                                  *      */
        /*"      *             - CORRIGIR LAYOUT DA CRIVO                         *      */
        /*"      *   EM 04/06/2024 - KINKAS               PROCURE POR V.23        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 22 - DEMANDA 402.982                                  *      */
        /*"      *             - DEIXAR CURSOR VG_CRITICA_PROPOSTA DEVOLVER O     *      */
        /*"      *               SEQ_CRITICA PARA PODER EXECUTAR A DELECAO LOGICA *      */
        /*"      *                                                                *      */
        /*"      *   EM 06/03/2023 - HUNSI ALI HUSNI                              *      */
        /*"      *                                        PROCURE POR V.22        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 21 - DEMANDA 402.982                                  *      */
        /*"      *             - RETIRAR GRAVACAO DE ERROS DA PROPOSTA DA TABELA  *      */
        /*"      *               ERROS_PROP_VIDAZUL                               *      */
        /*"      *             - GRAVAR ERROS DA PROPOSTA NA NOVA TABELA          *      */
        /*"      *               VG_CRITICA_PROPOSTA PARA POSTERIOR ANALISE DO    *      */
        /*"      *               GESTOR NO ATALHO 04.23                           *      */
        /*"      *                                                                *      */
        /*"      *   EM 14/02/2023 - ELIERMES OLIVEIRA                            *      */
        /*"      *                                        PROCURE POR V.21        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 20 - DEMANDA 387.459                                  *      */
        /*"      *             - A VERSAO 19 GEROU IMPACTO NO AUTO COMPRA DE VIDA *      */
        /*"      *               E OS PROGRAMAS DE RETORNO DO CRIVO, DEVEM ENVIAR *      */
        /*"      *               ESTAS PROPOSTAS PARA SITUACAO '7' PARA GERAR A   *      */
        /*"      *               1A PARCELA.                                      *      */
        /*"      *                                                                *      */
        /*"      *   EM 19/09/2022 - FRANK CARVALHO       PROCURE POR V.20        *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 19 - DEMANDA 387.459                                  *      */
        /*"      *             - ALTERACAO PARA EMISSAO AUTOMATICA INDEPENDENTE   *      */
        /*"      *               DA MANEIRA QUE O CLIENTE ASSINOU, PARA PROPOSTAS *      */
        /*"      *               COM IS ATE 200 MIL REAIS.                        *      */
        /*"      *                                                                *      */
        /*"      *   EM 25/05/2022 - FRANK CARVALHO                               *      */
        /*"      *                                        PROCURE POR V.19        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 18 - DEMANDA 382.935                                  *      */
        /*"      *               ADEQUACAO PARA NOVO LAYOUT DO CRIVO              *      */
        /*"      *                                                                *      */
        /*"      *   EM 22/04/2022 - FRANK CARVALHO                               *      */
        /*"      *                                         PROCURE POR V.18       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 17 - DEMANDA 333511 TAREFA 335051                     *      */
        /*"      *               ADEQUACAO PARA NOVO LAYOUT DO CRIVO              *      */
        /*"      *                                                                *      */
        /*"      *   EM 08/11/2021 - HUSNI ALI HUSNI                              *      */
        /*"      *                                         PROCURE POR V.17       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 16 - HIST.  272.172                                   *      */
        /*"      *               ALTERACAO DA REGRA DE ACEITACAO.                 *      */
        /*"      *               PROPOSTAS ELETRONICAS SEM ERRO DEVEM SER LIBERA- *      */
        /*"      *               DAS P/INTEGRACAO INDEPENDENTE DO VALOR SEGURADO  *      */
        /*"      *               E CANAL DE VENDA.                                *      */
        /*"      *               PROPOSTAS MANUAIS INDEPENDENTE DO VALOR SEGURADO *      */
        /*"      *               E CANAL DE VENDA DEVEM AGUARDAR PROPOSTA FISICA. *      */
        /*"      *               AJUSTES NA LEITURA DO ARQUIVO.                   *      */
        /*"      *                                                                *      */
        /*"      *   EM 28/04/2021 - BRICE HO                                     *      */
        /*"      *                                         PROCURE POR V.16       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 15 - HIST.   15.616                                   *      */
        /*"      *             - CORRIGIR CONTADOR DE ERROS POIS ESTAO EMITINDO   *      */
        /*"      *   PROPOSTAS COM ERROS QUE DEVERIAM CAIR PARA O OPERACIONAL.    *      */
        /*"      *                                                                *      */
        /*"      *   EM 30/04/2018 - FRANK CARVALHO                               *      */
        /*"      *                                         PROCURE POR V.15       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 14 - HIST.   13.055                                   *      */
        /*"      *               TRATAR ERRO 1803 E 1804 - ERRO DPS.              *      */
        /*"      *                                                                *      */
        /*"      *   EM 26/03/2018 - HERVAL SOUZA                                 *      */
        /*"      *                                         PROCURE POR V.14       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 13 - CAD 154.368                                      *      */
        /*"      *               TRATAR NOVO METODO DE VALIDACAO DA CRIVO DENOMINA*      */
        /*"      *               DO "DIRVI - Caixa - Restrições na Diretrix".            */
        /*"      *                                                                *      */
        /*"      *   EM 17/10/2017 - ELIERMES OLIVEIRA                            *      */
        /*"      *                                         PROCURE POR V.13       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 12 - CAD 149.441                                      *      */
        /*"      *               AJUSTE NA EXCLUSAO DA VG_ANDAMENTO_PROP.         *      */
        /*"      *                                                                *      */
        /*"      *   EM 18/09/2017 - FRANK CARVALHO                               *      */
        /*"      *                                         PROCURE POR V.12       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 11 - CAD 153.255                                      *      */
        /*"      *               AJUSTE NAS MENSAGENS DE RETORNO DA CRIVO.        *      */
        /*"      *                                                                *      */
        /*"      *   EM 15/08/2017 - CLAUDETE RADEL                               *      */
        /*"      *                                         PROCURE POR V.11       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 10 - CAD 152.475                                      *      */
        /*"      *               REALIZAR CORRECAO PARA QUE AS COMUNICACOES COM   *      */
        /*"      *               RETORNO DE ERRO NO CRIVO SEJA ENVIADAS NOVAMENTE *      */
        /*"      *               GRAVANDO ERRO NAS TABELAS DE CONTROLE.           *      */
        /*"      *                                                                *      */
        /*"      *   EM 20/07/2017 - ELIERMES OLIVEIRA                            *      */
        /*"      *                                         PROCURE POR V.10       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 09 - CAD 150.426                                      *      */
        /*"      *               INCLUIR NO LAYOUT CAMPO INSERIDO NO ARQUIVO DO   *      */
        /*"      *               CRIVO PARA REPOSICIONAR OS CAMPOS.               *      */
        /*"      *                                                                *      */
        /*"      *   EM 28/04/2017 - FRANK CARVALHO                               *      */
        /*"      *                                         PROCURE POR V.09       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 08 - CAD 148.531                                      *      */
        /*"      *               ALTERAR O COD_USUARIO DA PROPOSTAS_VA APENAS NOS *      */
        /*"      *               CASOS EM QUE O ACEITE DEVE SER DE FORMA MANUAL   *      */
        /*"      *                                                                *      */
        /*"      *   EM 17/04/2017 - ELIERMES OLIVEIRA                            *      */
        /*"      *                                         PROCURE POR V.08       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 07 - CAD 145.335                                      *      */
        /*"      *               EMISSãO VIDA GENTE - CCA                         *      */
        /*"      *                1 - DEVEM ENTRAR EM CRíTICA E SEREM ACEITAS     *      */
        /*"      *                    EXCLUSIVAMENTE DE FORMA MANUAL;             *      */
        /*"      *                2 - DEVEM APRESENTAR A CRíTICA "1800 - AGUARDAR *      */
        /*"      *                    PROPOSTA FíSICA "                           *      */
        /*"      *   EM 27/12/2016 - MAURO ROCHA DA CRUZ                          *      */
        /*"      *                                                                *      */
        /*"      *                                         PROCURE POR V.07       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 06 - CAD 142.087 - ABEND                              *      */
        /*"      *               PERMITIR O TRATAMENTO PARA OS CANAIS DE VENDA    *      */
        /*"      *               2 E 3.                                           *      */
        /*"      *                                                                *      */
        /*"      *   EM 27/05/2013 - TERCIO FREITAS                               *      */
        /*"      *                                                                *      */
        /*"      *                                   PROCURE POR V.06             *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 05 - CAD  76.398                                      *      */
        /*"      *               AJUSTE NO PROGRAMA PARA TRATAR O NOVO LAYOUT DO  *      */
        /*"      *               ARQUIVO DE RETORNO DO CRIVO 4.0                  *      */
        /*"      *                                                                *      */
        /*"      *   EM 27/05/2013 - TERCIO FREITAS                               *      */
        /*"      *                                                                *      */
        /*"      *                                   PROCURE POR V.05             *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 04 - CAD  67.646                                      *      */
        /*"      *               AJUSTE NO PROGRAMA PARA TRATAR AS NOVAS APOLICES *      */
        /*"      *               PARA OS PRODUTOS VIDA MULHER E MULTIPREMIADO     *      */
        /*"      *               SUPER DA LINHA TOTAL.                            *      */
        /*"      *                                                                *      */
        /*"      *   EM 05/07/2012 - EDIVALDO GOMES (FAST COMPUTER)               *      */
        /*"      *                                                                *      */
        /*"      *                                   PROCURE POR V.04             *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * PROJETO FGV (ALTERACOES)     (WELLINGTON VERAS (POLITEC))      *      */
        /*"      *                                                                *      */
        /*"      * 13/10/2008 - INCLUIR CLAUSULA WITH UR NO SELECT     - WV1008   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 03 - CAD 17439                                        *      */
        /*"      *               PASSA A TRATAR A SITUACAO DA TABELA              *      */
        /*"      *               SEGUROS.PROPOSTAS_VA.                            *      */
        /*"      *                                                                *      */
        /*"      *   EM 20/11/2008 - FAST COMPUTER            PROCURE POR V.03    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 02 - CAD 13762                                        *      */
        /*"      *               REVISAO DE PRODUTOS PU                           *      */
        /*"      *                                                                *      */
        /*"      *   EM 05/09/2008 - FAST COMPUTER            PROCURE POR V.02    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 01 - CAD 12617                                        *      */
        /*"      *               RETIRA O DECLINIO AUTOMATICO QUANDO CPF          *      */
        /*"      *               INATIVO                                          *      */
        /*"      *   EM 29/07/2008 - FAST COMPUTER            PROCURE POR V.01    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      ******************************************************************      */
        #endregion


        #region VARIABLES

        public FileBasis _MOV_CRIVO { get; set; } = new FileBasis(new PIC("X", "2000", "X(2000)"));

        public FileBasis MOV_CRIVO
        {
            get
            {
                _.Move(REG_MOV_CRIVO, _MOV_CRIVO); VarBasis.RedefinePassValue(REG_MOV_CRIVO, _MOV_CRIVO, REG_MOV_CRIVO); return _MOV_CRIVO;
            }
        }
        /*"01       REG-MOV-CRIVO            PIC X(2000).*/
        public StringBasis REG_MOV_CRIVO { get; set; } = new StringBasis(new PIC("X", "2000", "X(2000)."), @"");

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77  WHOST-COUNT                   PIC S9(009)    VALUE +0 COMP.*/
        public IntBasis WHOST_COUNT { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77  WHOST-COUNT-1800              PIC S9(009)    VALUE +0 COMP.*/
        public IntBasis WHOST_COUNT_1800 { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77  WHOST-COUNT-1803-1804         PIC S9(009)    VALUE +0 COMP.*/
        public IntBasis WHOST_COUNT_1803_1804 { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01          WS-AUXILIARES.*/
        public VA0055B_WS_AUXILIARES WS_AUXILIARES { get; set; } = new VA0055B_WS_AUXILIARES();
        public class VA0055B_WS_AUXILIARES : VarBasis
        {
            /*"    05      WS-DATA-REG-AUX     PIC  X(020) VALUE SPACES.*/
            public StringBasis WS_DATA_REG_AUX { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"");
            /*"    05      WS-TALLYING         PIC  9(005) VALUE 0.*/
            public IntBasis WS_TALLYING { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"    05      WS-CGCCPF-ATU       PIC  9(015) VALUE ZEROS.*/
            public IntBasis WS_CGCCPF_ATU { get; set; } = new IntBasis(new PIC("9", "15", "9(015)"));
            /*"    05      WS-CGCCPF-ANT       PIC  9(015) VALUE ZEROS.*/
            public IntBasis WS_CGCCPF_ANT { get; set; } = new IntBasis(new PIC("9", "15", "9(015)"));
            /*"    05      WS-CERTIFICADO-ATU  PIC  9(015) VALUE ZEROS.*/
            public IntBasis WS_CERTIFICADO_ATU { get; set; } = new IntBasis(new PIC("9", "15", "9(015)"));
            /*"    05      WS-CERTIFICADO-ANT  PIC  9(015) VALUE ZEROS.*/
            public IntBasis WS_CERTIFICADO_ANT { get; set; } = new IntBasis(new PIC("9", "15", "9(015)"));
            /*"    05  W-NUM-PROPOSTA                PIC 9(014).*/
            public IntBasis W_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
            /*"    05  FAIXAS  REDEFINES W-NUM-PROPOSTA.*/
            private _REDEF_VA0055B_FAIXAS _faixas { get; set; }
            public _REDEF_VA0055B_FAIXAS FAIXAS
            {
                get { _faixas = new _REDEF_VA0055B_FAIXAS(); _.Move(W_NUM_PROPOSTA, _faixas); VarBasis.RedefinePassValue(W_NUM_PROPOSTA, _faixas, W_NUM_PROPOSTA); _faixas.ValueChanged += () => { _.Move(_faixas, W_NUM_PROPOSTA); }; return _faixas; }
                set { VarBasis.RedefinePassValue(value, _faixas, W_NUM_PROPOSTA); }
            }  //Redefines
            public class _REDEF_VA0055B_FAIXAS : VarBasis
            {
                /*"        07  FILLER                    PIC 9(003).*/
                public IntBasis FILLER_0 { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"        07  FAIXA-NUMERACAO           PIC 9(003).*/

                public SelectorBasis FAIXA_NUMERACAO { get; set; } = new SelectorBasis("003")
                {
                    Items = new List<SelectorItemBasis> {
                            /*" 88 FAIXA-NUMERACAO-MULT       VALUE               848, 850, 845, 846. */
							new SelectorItemBasis("FAIXA_NUMERACAO_MULT", "848,850,845,846"),
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

                /*"        07  W-FILLER                  PIC 9(008).*/
                public IntBasis W_FILLER { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"    05      CANAL  REDEFINES W-NUM-PROPOSTA.*/

                public _REDEF_VA0055B_FAIXAS()
                {
                    FILLER_0.ValueChanged += OnValueChanged;
                    FAIXA_NUMERACAO.ValueChanged += OnValueChanged;
                    W_FILLER.ValueChanged += OnValueChanged;
                }

            }
            private _REDEF_VA0055B_CANAL _canal { get; set; }
            public _REDEF_VA0055B_CANAL CANAL
            {
                get { _canal = new _REDEF_VA0055B_CANAL(); _.Move(W_NUM_PROPOSTA, _canal); VarBasis.RedefinePassValue(W_NUM_PROPOSTA, _canal, W_NUM_PROPOSTA); _canal.ValueChanged += () => { _.Move(_canal, W_NUM_PROPOSTA); }; return _canal; }
                set { VarBasis.RedefinePassValue(value, _canal, W_NUM_PROPOSTA); }
            }  //Redefines
            public class _REDEF_VA0055B_CANAL : VarBasis
            {
                /*"        07  W-CANAL-PROPOSTA          PIC 9(001).*/

                public SelectorBasis W_CANAL_PROPOSTA { get; set; } = new SelectorBasis("001")
                {
                    Items = new List<SelectorItemBasis> {
                            /*" 88 CANAL-VENDA-PAPEL                    VALUE 0. */
							new SelectorItemBasis("CANAL_VENDA_PAPEL", "0"),
							/*" 88 CANAL-VENDA-CEF                      VALUE 1. */
							new SelectorItemBasis("CANAL_VENDA_CEF", "1"),
							/*" 88 CANAL-SASSE-FILIAL                   VALUE 2. */
							new SelectorItemBasis("CANAL_SASSE_FILIAL", "2"),
							/*" 88 CANAL-CORRETOR                       VALUE 3. */
							new SelectorItemBasis("CANAL_CORRETOR", "3"),
							/*" 88 CANAL-CORREIO                        VALUE 4. */
							new SelectorItemBasis("CANAL_CORREIO", "4"),
							/*" 88 CANAL-GITEL                          VALUE 5. */
							new SelectorItemBasis("CANAL_GITEL", "5"),
							/*" 88 CANAL-INTERNET                       VALUE 7. */
							new SelectorItemBasis("CANAL_INTERNET", "7"),
							/*" 88 CANAL-VENDA-AIC                      VALUE 8. */
							new SelectorItemBasis("CANAL_VENDA_AIC", "8")
                }
                };

                /*"        07  FILLER                    PIC 9(013).*/
                public IntBasis FILLER_1 { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
                /*"01          FILLER.*/

                public _REDEF_VA0055B_CANAL()
                {
                    W_CANAL_PROPOSTA.ValueChanged += OnValueChanged;
                    FILLER_1.ValueChanged += OnValueChanged;
                }

            }
        }
        public VA0055B_FILLER_2 FILLER_2 { get; set; } = new VA0055B_FILLER_2();
        public class VA0055B_FILLER_2 : VarBasis
        {
            /*"  03        WSQLCODE3           PIC S9(009) COMP.*/
            public IntBasis WSQLCODE3 { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  03        W-TOT-LID-MOVCRIVO  PIC  9(007) VALUE ZEROS.*/
            public IntBasis W_TOT_LID_MOVCRIVO { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03        W-TOT-INS-VGANDPROP PIC  9(007) VALUE ZEROS.*/
            public IntBasis W_TOT_INS_VGANDPROP { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03        W-TOT-INS-VGCRITPRO PIC  9(007) VALUE ZEROS.*/
            public IntBasis W_TOT_INS_VGCRITPRO { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03        W-TOT-UPD-PROPVA    PIC  9(007) VALUE ZEROS.*/
            public IntBasis W_TOT_UPD_PROPVA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03        W-TOT-UPD-RELATO    PIC  9(007) VALUE ZEROS.*/
            public IntBasis W_TOT_UPD_RELATO { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03        W-TOT-DEL-VGANDPROP PIC  9(007) VALUE ZEROS.*/
            public IntBasis W_TOT_DEL_VGANDPROP { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03        W-DIS-LID-MOVCRIVO  PIC  9(007) VALUE ZEROS.*/
            public IntBasis W_DIS_LID_MOVCRIVO { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03        W-TOT-INS-RELATO    PIC  9(007) VALUE ZEROS.*/
            public IntBasis W_TOT_INS_RELATO { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03        W-TOT-FORA-AR       PIC  9(007) VALUE ZEROS.*/
            public IntBasis W_TOT_FORA_AR { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03        WS-FLAG-APROVADO    PIC  9(001)             VALUE  0*/
            public IntBasis WS_FLAG_APROVADO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*"  03        FILLER.*/
            public VA0055B_FILLER_3 FILLER_3 { get; set; } = new VA0055B_FILLER_3();
            public class VA0055B_FILLER_3 : VarBasis
            {
                /*"    05      FIM-MOVIMENTO            PIC  X(003) VALUE 'NAO'.*/
                public StringBasis FIM_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
                /*"    03      WABEND.*/
                public VA0055B_WABEND WABEND { get; set; } = new VA0055B_WABEND();
                public class VA0055B_WABEND : VarBasis
                {
                    /*"      05      FILLER              PIC  X(010) VALUE             ' VA0055B'.*/
                    public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" VA0055B");
                    /*"      05      FILLER              PIC  X(028) VALUE             ' *** ERRO  EXEC SQL  NUMERO '.*/
                    public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @" *** ERRO  EXEC SQL  NUMERO ");
                    /*"      05      WNR-EXEC-SQL        PIC  X(004) VALUE '0000'.*/
                    public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"0000");
                    /*"      05      FILLER              PIC  X(017) VALUE             ' *** PARAGRAFO = '.*/
                    public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "17", "X(017)"), @" *** PARAGRAFO = ");
                    /*"      05      PARAGRAFO           PIC  X(030) VALUE SPACES.*/
                    public StringBasis PARAGRAFO { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"");
                    /*"      05      FILLER              PIC  X(014) VALUE             '    SQLCODE = '.*/
                    public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE = ");
                    /*"      05      WSQLCODE            PIC  ZZZZZZ999- VALUE ZEROS.*/
                    public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
                    /*"      05      FILLER              PIC  X(014) VALUE             '    SQLCODE1= '.*/
                    public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE1= ");
                    /*"      05      WSQLCODE1           PIC  ZZZZZZ999- VALUE ZEROS.*/
                    public IntBasis WSQLCODE1 { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
                    /*"      05      FILLER              PIC  X(014) VALUE             '    SQLCODE2= '.*/
                    public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE2= ");
                    /*"      05      WSQLCODE2           PIC  ZZZZZZ999- VALUE ZEROS.*/
                    public IntBasis WSQLCODE2 { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
                    /*"    03         WSQLERRO.*/
                }
                public VA0055B_WSQLERRO WSQLERRO { get; set; } = new VA0055B_WSQLERRO();
                public class VA0055B_WSQLERRO : VarBasis
                {
                    /*"      05         FILLER               PIC  X(014) VALUE                ' *** SQLERRMC '.*/
                    public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @" *** SQLERRMC ");
                    /*"      05         WSQLERRMC            PIC  X(070) VALUE  SPACES.*/
                    public StringBasis WSQLERRMC { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"");
                    /*"01          REGISTRO-WORK.*/
                }
            }
        }
        public VA0055B_REGISTRO_WORK REGISTRO_WORK { get; set; } = new VA0055B_REGISTRO_WORK();
        public class VA0055B_REGISTRO_WORK : VarBasis
        {
            /*"  10        LIMITE-REG               PIC  X(010).*/
            public StringBasis LIMITE_REG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  10        PONTOS-REG               PIC  X(005).*/
            public StringBasis PONTOS_REG { get; set; } = new StringBasis(new PIC("X", "5", "X(005)."), @"");
            /*"  10        SISTEMA-REG              PIC  X(010).*/
            public StringBasis SISTEMA_REG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  10        RESULTADO-REG            PIC  X(050).*/
            public StringBasis RESULTADO_REG { get; set; } = new StringBasis(new PIC("X", "50", "X(050)."), @"");
            /*"  10        CRITERIO-REG             PIC  X(050).*/
            public StringBasis CRITERIO_REG { get; set; } = new StringBasis(new PIC("X", "50", "X(050)."), @"");
            /*"  10        RESPOSTA-FINAL-REG       PIC  X(001).*/
            public StringBasis RESPOSTA_FINAL_REG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  10        VAL-ANALISE-REG          PIC  9(013).*/
            public IntBasis VAL_ANALISE_REG { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
            /*"  10        DRIVER08-REG             PIC  X(001).*/
            public StringBasis DRIVER08_REG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  10        DRIVER09-REG             PIC  X(001).*/
            public StringBasis DRIVER09_REG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  10        DRIVER10-REG             PIC  X(001).*/
            public StringBasis DRIVER10_REG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  10        DRIVER11-REG             PIC  X(001).*/
            public StringBasis DRIVER11_REG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  10        DRIVER12-REG             PIC  X(001).*/
            public StringBasis DRIVER12_REG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  10        DRIVER13-REG             PIC  X(001).*/
            public StringBasis DRIVER13_REG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  10        DRIVER14-REG             PIC  X(001).*/
            public StringBasis DRIVER14_REG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  10        DRIVER15-REG             PIC  X(001).*/
            public StringBasis DRIVER15_REG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  10        DRIVER16-REG             PIC  X(001).*/
            public StringBasis DRIVER16_REG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  10        DRIVER17-REG             PIC  X(001).*/
            public StringBasis DRIVER17_REG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  10        DRIVER18-REG             PIC  X(001).*/
            public StringBasis DRIVER18_REG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  10        DRIVER19-REG             PIC  X(001).*/
            public StringBasis DRIVER19_REG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  10        DRIVER20-REG             PIC  X(001).*/
            public StringBasis DRIVER20_REG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  10        DRIVER21-REG             PIC  X(001).*/
            public StringBasis DRIVER21_REG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  10        NOME-RAZAO-REG           PIC  X(072).*/
            public StringBasis NOME_RAZAO_REG { get; set; } = new StringBasis(new PIC("X", "72", "X(072)."), @"");
            /*"  10        MODALIDADE-REG           PIC  X(002).*/
            public StringBasis MODALIDADE_REG { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
            /*"  10        DRIVER24-REG             PIC  X(001).*/
            public StringBasis DRIVER24_REG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  10        DRIVER25-REG             PIC  X(001).*/
            public StringBasis DRIVER25_REG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  10        DRIVER26-REG             PIC  X(001).*/
            public StringBasis DRIVER26_REG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  10        DRIVER27-REG             PIC  X(001).*/
            public StringBasis DRIVER27_REG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  10        DRIVER28-REG             PIC  X(001).*/
            public StringBasis DRIVER28_REG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  10        DRIVER29-REG             PIC  X(001).*/
            public StringBasis DRIVER29_REG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  10        DRIVER30-REG             PIC  X(001).*/
            public StringBasis DRIVER30_REG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  10        DRIVER31-REG             PIC  X(001).*/
            public StringBasis DRIVER31_REG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  10        CGCCPF-REG               PIC  9(015).*/
            public IntBasis CGCCPF_REG { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
            /*"  10        DRIVER33-REG             PIC  X(001).*/
            public StringBasis DRIVER33_REG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  10        DRIVER34-REG             PIC  X(001).*/
            public StringBasis DRIVER34_REG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  10        DRIVER35-REG             PIC  X(001).*/
            public StringBasis DRIVER35_REG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  10        DRIVER36-REG             PIC  X(001).*/
            public StringBasis DRIVER36_REG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  10        CERTIFICADO-REG          PIC  9(015).*/
            public IntBasis CERTIFICADO_REG { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
            /*"  10        DRIVER38-REG             PIC  X(001).*/
            public StringBasis DRIVER38_REG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  10        DRIVER39-REG             PIC  X(001).*/
            public StringBasis DRIVER39_REG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  10        DRIVER40-REG             PIC  X(001).*/
            public StringBasis DRIVER40_REG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  10        DRIVER41-REG             PIC  X(001).*/
            public StringBasis DRIVER41_REG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  10        OPERACAO-REG             PIC  X(010).*/
            public StringBasis OPERACAO_REG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  10        TIPO-PESSOA-REG          PIC  X(001).*/
            public StringBasis TIPO_PESSOA_REG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  10        USUARIO-REG              PIC  X(020).*/
            public StringBasis USUARIO_REG { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
            /*"  10        DATA-REG                 PIC  X(020).*/
            public StringBasis DATA_REG { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
            /*"  10        DRIVER46-REG             PIC  X(001).*/
            public StringBasis DRIVER46_REG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  10        WS-SISTEMA               PIC  X(010).*/
            public StringBasis WS_SISTEMA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  10        WS-RESULTADO             PIC  X(040).*/
            public StringBasis WS_RESULTADO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
            /*"01          REGISTRO-SAIDA.*/
        }
        public VA0055B_REGISTRO_SAIDA REGISTRO_SAIDA { get; set; } = new VA0055B_REGISTRO_SAIDA();
        public class VA0055B_REGISTRO_SAIDA : VarBasis
        {
            /*"  10        NUM-APOLICE-SAI          PIC  9(013).*/
            public IntBasis NUM_APOLICE_SAI { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
            /*"  10        FILLER                   PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  10        SUBGRUPO-SAI             PIC  9(004).*/
            public IntBasis SUBGRUPO_SAI { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  10        FILLER                   PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  10        SUBES-SAI                PIC  X(040).*/
            public StringBasis SUBES_SAI { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
            /*"  10        FILLER                   PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  10        NOME-SAI                 PIC  X(040).*/
            public StringBasis NOME_SAI { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
            /*"  10        FILLER                   PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  10        CPF-SAI                  PIC  9(011).*/
            public IntBasis CPF_SAI { get; set; } = new IntBasis(new PIC("9", "11", "9(011)."));
            /*"  10        FILLER                   PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  10        DTNAS-SAI.*/
            public VA0055B_DTNAS_SAI DTNAS_SAI { get; set; } = new VA0055B_DTNAS_SAI();
            public class VA0055B_DTNAS_SAI : VarBasis
            {
                /*"    15      DTNAS-AA-SAI             PIC  X(004).*/
                public StringBasis DTNAS_AA_SAI { get; set; } = new StringBasis(new PIC("X", "4", "X(004)."), @"");
                /*"    15      DTNAS-T1-SAI             PIC  X(001).*/
                public StringBasis DTNAS_T1_SAI { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    15      DTNAS-MM-SAI             PIC  X(002).*/
                public StringBasis DTNAS_MM_SAI { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"    15      DTNAS-T2-SAI             PIC  X(001).*/
                public StringBasis DTNAS_T2_SAI { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    15      DTNAS-DD-SAI             PIC  X(002).*/
                public StringBasis DTNAS_DD_SAI { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"  10        FILLER                   PIC  X(001) VALUE ';'.*/
            }
            public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  10        SEXO-SAI                 PIC  X(001).*/
            public StringBasis SEXO_SAI { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  10        FILLER                   PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  10        ESTCIV-SAI               PIC  X(001).*/
            public StringBasis ESTCIV_SAI { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  10        FILLER                   PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  10        SALARIO-SAI              PIC  99999999,99.*/
            public DoubleBasis SALARIO_SAI { get; set; } = new DoubleBasis(new PIC("9", "8", "99999999V99."), 2);
            /*"  10        FILLER                   PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  10        QTDSAL-SAI               PIC  9(004).*/
            public IntBasis QTDSAL_SAI { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  10        FILLER                   PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  10        IS-SAI                   PIC  99999999,99.*/
            public DoubleBasis IS_SAI { get; set; } = new DoubleBasis(new PIC("9", "8", "99999999V99."), 2);
            /*"  10        FILLER                   PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  10        PREMIO-SAI               PIC  99999999,99.*/
            public DoubleBasis PREMIO_SAI { get; set; } = new DoubleBasis(new PIC("9", "8", "99999999V99."), 2);
            /*"  10        FILLER                   PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  10        COD-ERRO-SAI             PIC  9(004).*/
            public IntBasis COD_ERRO_SAI { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  10        FILLER                   PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  10        DES-ERRO-SAI             PIC  X(060).*/
            public StringBasis DES_ERRO_SAI { get; set; } = new StringBasis(new PIC("X", "60", "X(060)."), @"");
            /*"  10        FILLER                   PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"01          REGISTRO-SAIDA1.*/
        }
        public VA0055B_REGISTRO_SAIDA1 REGISTRO_SAIDA1 { get; set; } = new VA0055B_REGISTRO_SAIDA1();
        public class VA0055B_REGISTRO_SAIDA1 : VarBasis
        {
            /*"  10        NUM-APOLICE-SAI1         PIC  9(013).*/
            public IntBasis NUM_APOLICE_SAI1 { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
            /*"  10        FILLER                   PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  10        SUBGRUPO-SAI1            PIC  9(004).*/
            public IntBasis SUBGRUPO_SAI1 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  10        FILLER                   PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  10        SUBES-SAI1               PIC  X(040).*/
            public StringBasis SUBES_SAI1 { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
            /*"  10        FILLER                   PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  10        QTDE-ATIVOS-SAI1         PIC  9(005).*/
            public IntBasis QTDE_ATIVOS_SAI1 { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
            /*"  10        FILLER                   PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  10        VLR-ATIVOS-SAI1          PIC  999999999,99.*/
            public DoubleBasis VLR_ATIVOS_SAI1 { get; set; } = new DoubleBasis(new PIC("9", "9", "999999999V99."), 2);
            /*"  10        FILLER                   PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  10        QTDE-CRITIC-SAI1         PIC  9(005).*/
            public IntBasis QTDE_CRITIC_SAI1 { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
            /*"  10        FILLER                   PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  10        VLR-CRITIC-SAI1          PIC  999999999,99.*/
            public DoubleBasis VLR_CRITIC_SAI1 { get; set; } = new DoubleBasis(new PIC("9", "9", "999999999V99."), 2);
            /*"  10        FILLER                   PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  10        QTDE-MOVTO-SAI1          PIC  9(005).*/
            public IntBasis QTDE_MOVTO_SAI1 { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
            /*"  10        FILLER                   PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  10        VLR-MOVTO-SAI1           PIC  999999999,99.*/
            public DoubleBasis VLR_MOVTO_SAI1 { get; set; } = new DoubleBasis(new PIC("9", "9", "999999999V99."), 2);
            /*"  10        FILLER                   PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  10        FILLER                   PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  10        FILLER                   PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  10        FILLER                   PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  10        FILLER                   PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  10        FILLER                   PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  10        FILLER                   PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  10        FILLER                   PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_40 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"01          REGISTRO-SAIDA2.*/
        }
        public VA0055B_REGISTRO_SAIDA2 REGISTRO_SAIDA2 { get; set; } = new VA0055B_REGISTRO_SAIDA2();
        public class VA0055B_REGISTRO_SAIDA2 : VarBasis
        {
            /*"  10        NUM-APOLICE-SAI2         PIC  9(013).*/
            public IntBasis NUM_APOLICE_SAI2 { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
            /*"  10        FILLER                   PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  10        SUBGRUPO-SAI2            PIC  9(004).*/
            public IntBasis SUBGRUPO_SAI2 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  10        FILLER                   PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  10        SUBES-SAI2               PIC  X(040).*/
            public StringBasis SUBES_SAI2 { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
            /*"  10        FILLER                   PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_43 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  10        OBSERVACAO-SAI2          PIC  X(040).*/
            public StringBasis OBSERVACAO_SAI2 { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
            /*"  10        FILLER                   PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_44 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  10        FILLER                   PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_45 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  10        FILLER                   PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_46 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  10        FILLER                   PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_47 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  10        FILLER                   PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_48 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  10        FILLER                   PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_49 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  10        FILLER                   PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_50 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  10        FILLER                   PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_51 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  10        FILLER                   PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_52 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  10        FILLER                   PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_53 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  10        FILLER                   PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_54 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"01          REGISTRO-WORK-SAL        PIC  X(120).*/
        }
        public StringBasis REGISTRO_WORK_SAL { get; set; } = new StringBasis(new PIC("X", "120", "X(120)."), @"");
        /*"01              LPARM01         PIC  9(011).*/
        public IntBasis LPARM01 { get; set; } = new IntBasis(new PIC("9", "11", "9(011)."));
        /*"01          TAB-RESUMO.*/
        public VA0055B_TAB_RESUMO TAB_RESUMO { get; set; } = new VA0055B_TAB_RESUMO();
        public class VA0055B_TAB_RESUMO : VarBasis
        {
            /*"  10        TAB-RES OCCURS 1000 TIMES.*/
            public ListBasis<VA0055B_TAB_RES> TAB_RES { get; set; } = new ListBasis<VA0055B_TAB_RES>(1000);
            public class VA0055B_TAB_RES : VarBasis
            {
                /*"    15      TAB-CHAVE                PIC  X(17).*/
                public StringBasis TAB_CHAVE { get; set; } = new StringBasis(new PIC("X", "17", "X(17)."), @"");
                /*"    15      TAB-CHAVE-R              REDEFINES  TAB-CHAVE.*/
                private _REDEF_VA0055B_TAB_CHAVE_R _tab_chave_r { get; set; }
                public _REDEF_VA0055B_TAB_CHAVE_R TAB_CHAVE_R
                {
                    get { _tab_chave_r = new _REDEF_VA0055B_TAB_CHAVE_R(); _.Move(TAB_CHAVE, _tab_chave_r); VarBasis.RedefinePassValue(TAB_CHAVE, _tab_chave_r, TAB_CHAVE); _tab_chave_r.ValueChanged += () => { _.Move(_tab_chave_r, TAB_CHAVE); }; return _tab_chave_r; }
                    set { VarBasis.RedefinePassValue(value, _tab_chave_r, TAB_CHAVE); }
                }  //Redefines
                public class _REDEF_VA0055B_TAB_CHAVE_R : VarBasis
                {
                    /*"      20    TAB-NUM-APOLICE          PIC  9(13).*/
                    public IntBasis TAB_NUM_APOLICE { get; set; } = new IntBasis(new PIC("9", "13", "9(13)."));
                    /*"      20    TAB-COD-SUBGRUPO         PIC  9(04).*/
                    public IntBasis TAB_COD_SUBGRUPO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                    /*"    15      TAB-QTDE-ATIVOS          PIC  9(05).*/

                    public _REDEF_VA0055B_TAB_CHAVE_R()
                    {
                        TAB_NUM_APOLICE.ValueChanged += OnValueChanged;
                        TAB_COD_SUBGRUPO.ValueChanged += OnValueChanged;
                    }

                }
                public IntBasis TAB_QTDE_ATIVOS { get; set; } = new IntBasis(new PIC("9", "5", "9(05)."));
                /*"    15      TAB-QTDE-CRITIC          PIC  9(05).*/
                public IntBasis TAB_QTDE_CRITIC { get; set; } = new IntBasis(new PIC("9", "5", "9(05)."));
                /*"    15      TAB-QTDE-MOVTO           PIC  9(05).*/
                public IntBasis TAB_QTDE_MOVTO { get; set; } = new IntBasis(new PIC("9", "5", "9(05)."));
            }
        }


        public Copies.SPVG001V SPVG001V { get; set; } = new Copies.SPVG001V();
        public Copies.SPVG001W SPVG001W { get; set; } = new Copies.SPVG001W();
        public Dclgens.CLIENTES CLIENTES { get; set; } = new Dclgens.CLIENTES();
        public Dclgens.ERRPROVI ERRPROVI { get; set; } = new Dclgens.ERRPROVI();
        public Dclgens.HISCOBPR HISCOBPR { get; set; } = new Dclgens.HISCOBPR();
        public Dclgens.HISCONPA HISCONPA { get; set; } = new Dclgens.HISCONPA();
        public Dclgens.PROPOVA PROPOVA { get; set; } = new Dclgens.PROPOVA();
        public Dclgens.RELATORI RELATORI { get; set; } = new Dclgens.RELATORI();
        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.VG078 VG078 { get; set; } = new Dclgens.VG078();
        public Dclgens.PROPOFID PROPOFID { get; set; } = new Dclgens.PROPOFID();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string MOV_CRIVO_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                MOV_CRIVO.SetFile(MOV_CRIVO_FILE_NAME_P);

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
            /*" -522- MOVE '0000' TO WNR-EXEC-SQL. */
            _.Move("0000", FILLER_2.FILLER_3.WABEND.WNR_EXEC_SQL);

            /*" -523- DISPLAY ' ' */
            _.Display($" ");

            /*" -524- DISPLAY '-------------------------------------------------' */
            _.Display($"-------------------------------------------------");

            /*" -525- DISPLAY '          PROGRAMA EM EXECUCAO VA0055B           ' */
            _.Display($"          PROGRAMA EM EXECUCAO VA0055B           ");

            /*" -526- DISPLAY '                              ' */
            _.Display($"                              ");

            /*" -529- DISPLAY 'VERSAO V.25:' FUNCTION WHEN-COMPILED '- RITM0000@#@' */

            $"VERSAO V.25:FUNCTION{_.WhenCompiled()}- RITM0000@#@"
            .Display();

            /*" -530- DISPLAY '-------------------------------------------------' */
            _.Display($"-------------------------------------------------");

            /*" -531- DISPLAY ' ' */
            _.Display($" ");

            /*" -538- DISPLAY 'INICIOU PROCESSAMENTO EM ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2) */

            $"INICIOU PROCESSAMENTO EM {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
            .Display();

            /*" -542- DISPLAY '   ' */
            _.Display($"   ");

            /*" -544- OPEN INPUT MOV-CRIVO. */
            MOV_CRIVO.Open(REG_MOV_CRIVO);

            /*" -546- PERFORM R0100-00-SELECT-TSISTEMA. */

            R0100_00_SELECT_TSISTEMA_SECTION();

            /*" -548- PERFORM R0190-00-LE-MOV-CRIVO. */

            R0190_00_LE_MOV_CRIVO_SECTION();

            /*" -549- IF FIM-MOVIMENTO EQUAL 'SIM' */

            if (FILLER_2.FILLER_3.FIM_MOVIMENTO == "SIM")
            {

                /*" -550- DISPLAY 'ARQUIVO MOVIMENTO VAZIO' */
                _.Display($"ARQUIVO MOVIMENTO VAZIO");

                /*" -551- MOVE 01 TO RETURN-CODE */
                _.Move(01, RETURN_CODE);

                /*" -552- PERFORM R9900-00-ENCERRA-SEM-MOVTO */

                R9900_00_ENCERRA_SEM_MOVTO_SECTION();

                /*" -553- GO TO R9000-00-FINALIZA */

                R9000_00_FINALIZA_SECTION(); //GOTO
                return;

                /*" -556- END-IF. */
            }


            /*" -558- IF LIMITE-REG EQUAL 'LIMITE' */

            if (REGISTRO_WORK.LIMITE_REG == "LIMITE")
            {

                /*" -559- PERFORM R0190-00-LE-MOV-CRIVO */

                R0190_00_LE_MOV_CRIVO_SECTION();

                /*" -560- IF FIM-MOVIMENTO EQUAL 'SIM' */

                if (FILLER_2.FILLER_3.FIM_MOVIMENTO == "SIM")
                {

                    /*" -561- DISPLAY 'ARQUIVO MOVIMENTO SOMENTE COM CABECALHO' */
                    _.Display($"ARQUIVO MOVIMENTO SOMENTE COM CABECALHO");

                    /*" -562- MOVE 01 TO RETURN-CODE */
                    _.Move(01, RETURN_CODE);

                    /*" -563- PERFORM R9900-00-ENCERRA-SEM-MOVTO */

                    R9900_00_ENCERRA_SEM_MOVTO_SECTION();

                    /*" -564- GO TO R9000-00-FINALIZA */

                    R9000_00_FINALIZA_SECTION(); //GOTO
                    return;

                    /*" -565- END-IF */
                }


                /*" -567- END-IF. */
            }


            /*" -570- PERFORM R1000-00-PROCESSA-CGCCPF UNTIL FIM-MOVIMENTO EQUAL 'SIM' */

            while (!(FILLER_2.FILLER_3.FIM_MOVIMENTO == "SIM"))
            {

                R1000_00_PROCESSA_CGCCPF_SECTION();
            }

            /*" -571- MOVE ZEROS TO RETURN-CODE */
            _.Move(0, RETURN_CODE);

            /*" -571- GO TO R9000-00-FINALIZA. */

            R9000_00_FINALIZA_SECTION(); //GOTO
            return;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0100-00-SELECT-TSISTEMA-SECTION */
        private void R0100_00_SELECT_TSISTEMA_SECTION()
        {
            /*" -581- MOVE 'R0100-00-SELECT-TSISTEMA' TO PARAGRAFO. */
            _.Move("R0100-00-SELECT-TSISTEMA", FILLER_2.FILLER_3.WABEND.PARAGRAFO);

            /*" -585- MOVE '0100' TO WNR-EXEC-SQL. */
            _.Move("0100", FILLER_2.FILLER_3.WABEND.WNR_EXEC_SQL);

            /*" -591- PERFORM R0100_00_SELECT_TSISTEMA_DB_SELECT_1 */

            R0100_00_SELECT_TSISTEMA_DB_SELECT_1();

            /*" -594- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -595- DISPLAY 'VA0055B - NAO CONSTA REGISTRO NA TSISTEMA' */
                _.Display($"VA0055B - NAO CONSTA REGISTRO NA TSISTEMA");

                /*" -596- DISPLAY 'IDSISTEM =  VG ' */
                _.Display($"IDSISTEM =  VG ");

                /*" -597- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -599- END-IF. */
            }


            /*" -600- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -601- DISPLAY 'VA0055B - ERRO NA LEITURA NA SISTEMAS  ' */
                _.Display($"VA0055B - ERRO NA LEITURA NA SISTEMAS  ");

                /*" -602- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -602- END-IF. */
            }


        }

        [StopWatch]
        /*" R0100-00-SELECT-TSISTEMA-DB-SELECT-1 */
        public void R0100_00_SELECT_TSISTEMA_DB_SELECT_1()
        {
            /*" -591- EXEC SQL SELECT DATA_MOV_ABERTO INTO :SISTEMAS-DATA-MOV-ABERTO FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'VG' WITH UR END-EXEC. */

            var r0100_00_SELECT_TSISTEMA_DB_SELECT_1_Query1 = new R0100_00_SELECT_TSISTEMA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0100_00_SELECT_TSISTEMA_DB_SELECT_1_Query1.Execute(r0100_00_SELECT_TSISTEMA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/

        [StopWatch]
        /*" R0190-00-LE-MOV-CRIVO-SECTION */
        private void R0190_00_LE_MOV_CRIVO_SECTION()
        {
            /*" -613- MOVE 'R0190-00-LE-MOV-CRIVO' TO PARAGRAFO. */
            _.Move("R0190-00-LE-MOV-CRIVO", FILLER_2.FILLER_3.WABEND.PARAGRAFO);

            /*" -615- MOVE '0910' TO WNR-EXEC-SQL. */
            _.Move("0910", FILLER_2.FILLER_3.WABEND.WNR_EXEC_SQL);

            /*" -616- READ MOV-CRIVO AT END */
            try
            {
                MOV_CRIVO.Read(() =>
                {

                    /*" -618- MOVE 'SIM' TO FIM-MOVIMENTO */
                    _.Move("SIM", FILLER_2.FILLER_3.FIM_MOVIMENTO);

                    /*" -621- GO TO R0910-99-SAIDA. */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/ //GOTO
                    return;
                });

                _.Move(MOV_CRIVO.Value, REG_MOV_CRIVO);

            }
            catch (GoToException ex)
            {
                return;
            }
            /*" -676- UNSTRING REG-MOV-CRIVO DELIMITED BY ';' INTO LIMITE-REG PONTOS-REG SISTEMA-REG RESULTADO-REG CRITERIO-REG RESPOSTA-FINAL-REG VAL-ANALISE-REG DRIVER08-REG DRIVER09-REG DRIVER10-REG DRIVER11-REG DRIVER12-REG DRIVER13-REG DRIVER14-REG DRIVER15-REG DRIVER16-REG DRIVER17-REG DRIVER18-REG DRIVER19-REG DRIVER20-REG DRIVER21-REG NOME-RAZAO-REG MODALIDADE-REG DRIVER24-REG DRIVER25-REG DRIVER26-REG DRIVER27-REG DRIVER28-REG DRIVER29-REG DRIVER30-REG DRIVER31-REG CGCCPF-REG DRIVER33-REG DRIVER34-REG DRIVER35-REG DRIVER36-REG CERTIFICADO-REG DRIVER38-REG DRIVER39-REG DRIVER40-REG DRIVER41-REG OPERACAO-REG TIPO-PESSOA-REG USUARIO-REG DATA-REG DRIVER46-REG */
            _.Unstring(REG_MOV_CRIVO,
                [new UnstringDelimitedParameter(";")],
                [new UnstringIntoParameter(REGISTRO_WORK.LIMITE_REG)
                ,new UnstringIntoParameter(REGISTRO_WORK.PONTOS_REG)
                ,new UnstringIntoParameter(REGISTRO_WORK.SISTEMA_REG)
                ,new UnstringIntoParameter(REGISTRO_WORK.RESULTADO_REG)
                ,new UnstringIntoParameter(REGISTRO_WORK.CRITERIO_REG)
                ,new UnstringIntoParameter(REGISTRO_WORK.RESPOSTA_FINAL_REG)
                ,new UnstringIntoParameter(REGISTRO_WORK.VAL_ANALISE_REG)
                ,new UnstringIntoParameter(REGISTRO_WORK.DRIVER08_REG)
                ,new UnstringIntoParameter(REGISTRO_WORK.DRIVER09_REG)
                ,new UnstringIntoParameter(REGISTRO_WORK.DRIVER10_REG)
                ,new UnstringIntoParameter(REGISTRO_WORK.DRIVER11_REG)
                ,new UnstringIntoParameter(REGISTRO_WORK.DRIVER12_REG)
                ,new UnstringIntoParameter(REGISTRO_WORK.DRIVER13_REG)
                ,new UnstringIntoParameter(REGISTRO_WORK.DRIVER14_REG)
                ,new UnstringIntoParameter(REGISTRO_WORK.DRIVER15_REG)
                ,new UnstringIntoParameter(REGISTRO_WORK.DRIVER16_REG)
                ,new UnstringIntoParameter(REGISTRO_WORK.DRIVER17_REG)
                ,new UnstringIntoParameter(REGISTRO_WORK.DRIVER18_REG)
                ,new UnstringIntoParameter(REGISTRO_WORK.DRIVER19_REG)
                ,new UnstringIntoParameter(REGISTRO_WORK.DRIVER20_REG)
                ,new UnstringIntoParameter(REGISTRO_WORK.DRIVER21_REG)
                ,new UnstringIntoParameter(REGISTRO_WORK.NOME_RAZAO_REG)
                ,new UnstringIntoParameter(REGISTRO_WORK.MODALIDADE_REG)
                ,new UnstringIntoParameter(REGISTRO_WORK.DRIVER24_REG)
                ,new UnstringIntoParameter(REGISTRO_WORK.DRIVER25_REG)
                ,new UnstringIntoParameter(REGISTRO_WORK.DRIVER26_REG)
                ,new UnstringIntoParameter(REGISTRO_WORK.DRIVER27_REG)
                ,new UnstringIntoParameter(REGISTRO_WORK.DRIVER28_REG)
                ,new UnstringIntoParameter(REGISTRO_WORK.DRIVER29_REG)
                ,new UnstringIntoParameter(REGISTRO_WORK.DRIVER30_REG)
                ,new UnstringIntoParameter(REGISTRO_WORK.DRIVER31_REG)
                ,new UnstringIntoParameter(REGISTRO_WORK.CGCCPF_REG)
                ,new UnstringIntoParameter(REGISTRO_WORK.DRIVER33_REG)
                ,new UnstringIntoParameter(REGISTRO_WORK.DRIVER34_REG)
                ,new UnstringIntoParameter(REGISTRO_WORK.DRIVER35_REG)
                ,new UnstringIntoParameter(REGISTRO_WORK.DRIVER36_REG)
                ,new UnstringIntoParameter(REGISTRO_WORK.CERTIFICADO_REG)
                ,new UnstringIntoParameter(REGISTRO_WORK.DRIVER38_REG)
                ,new UnstringIntoParameter(REGISTRO_WORK.DRIVER39_REG)
                ,new UnstringIntoParameter(REGISTRO_WORK.DRIVER40_REG)
                ,new UnstringIntoParameter(REGISTRO_WORK.DRIVER41_REG)
                ,new UnstringIntoParameter(REGISTRO_WORK.OPERACAO_REG)
                ,new UnstringIntoParameter(REGISTRO_WORK.TIPO_PESSOA_REG)
                ,new UnstringIntoParameter(REGISTRO_WORK.USUARIO_REG)
                ,new UnstringIntoParameter(REGISTRO_WORK.DATA_REG)
                ,new UnstringIntoParameter(REGISTRO_WORK.DRIVER46_REG)
            ]);

            /*" -677- INITIALIZE WS-TALLYING */
            _.Initialize(
                WS_AUXILIARES.WS_TALLYING
            );

            /*" -679- INSPECT USUARIO-REG TALLYING WS-TALLYING FOR ALL '/' */
            WS_AUXILIARES.WS_TALLYING.Value = REGISTRO_WORK.USUARIO_REG.ToString().TakeWhile(x => x == '/').Count();

            /*" -680- IF WS-TALLYING > 1 */

            if (WS_AUXILIARES.WS_TALLYING > 1)
            {

                /*" -681- MOVE DATA-REG TO WS-DATA-REG-AUX */
                _.Move(REGISTRO_WORK.DATA_REG, WS_AUXILIARES.WS_DATA_REG_AUX);

                /*" -682- MOVE USUARIO-REG TO DATA-REG */
                _.Move(REGISTRO_WORK.USUARIO_REG, REGISTRO_WORK.DATA_REG);

                /*" -683- MOVE WS-DATA-REG-AUX TO USUARIO-REG */
                _.Move(WS_AUXILIARES.WS_DATA_REG_AUX, REGISTRO_WORK.USUARIO_REG);

                /*" -686- END-IF */
            }


            /*" -688- ADD 1 TO W-TOT-LID-MOVCRIVO */
            FILLER_2.W_TOT_LID_MOVCRIVO.Value = FILLER_2.W_TOT_LID_MOVCRIVO + 1;

            /*" -691- DISPLAY '<' CERTIFICADO-REG '><' CRITERIO-REG '>' '<' RESULTADO-REG '><' SISTEMA-REG '>' */

            $"<{REGISTRO_WORK.CERTIFICADO_REG}><{REGISTRO_WORK.CRITERIO_REG}><{REGISTRO_WORK.RESULTADO_REG}><{REGISTRO_WORK.SISTEMA_REG}>"
            .Display();

            /*" -692- ADD 1 TO W-DIS-LID-MOVCRIVO */
            FILLER_2.W_DIS_LID_MOVCRIVO.Value = FILLER_2.W_DIS_LID_MOVCRIVO + 1;

            /*" -694- IF W-DIS-LID-MOVCRIVO GREATER 999 */

            if (FILLER_2.W_DIS_LID_MOVCRIVO > 999)
            {

                /*" -696- MOVE ZEROS TO W-DIS-LID-MOVCRIVO */
                _.Move(0, FILLER_2.W_DIS_LID_MOVCRIVO);

                /*" -701- DISPLAY 'LIDOS MOVIMENTO   ' W-TOT-LID-MOVCRIVO ' ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2) */

                $"LIDOS MOVIMENTO   {FILLER_2.W_TOT_LID_MOVCRIVO} {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
                .Display();

                /*" -701- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-CGCCPF-SECTION */
        private void R1000_00_PROCESSA_CGCCPF_SECTION()
        {
            /*" -712- MOVE 'R1000-00-PROCESSA-CGCCPF' TO PARAGRAFO. */
            _.Move("R1000-00-PROCESSA-CGCCPF", FILLER_2.FILLER_3.WABEND.PARAGRAFO);

            /*" -714- MOVE '1000' TO WNR-EXEC-SQL. */
            _.Move("1000", FILLER_2.FILLER_3.WABEND.WNR_EXEC_SQL);

            /*" -720- DISPLAY 'R1000 01 <' CERTIFICADO-REG '>' '<' CGCCPF-REG '>' '<' CRITERIO-REG '>' '<' RESULTADO-REG '>' '<' SISTEMA-REG '>' */

            $"R1000 01 <{REGISTRO_WORK.CERTIFICADO_REG}><{REGISTRO_WORK.CGCCPF_REG}><{REGISTRO_WORK.CRITERIO_REG}><{REGISTRO_WORK.RESULTADO_REG}><{REGISTRO_WORK.SISTEMA_REG}>"
            .Display();

            /*" -723- MOVE CERTIFICADO-REG TO WS-CERTIFICADO-ATU PROPOVA-NUM-CERTIFICADO. */
            _.Move(REGISTRO_WORK.CERTIFICADO_REG, WS_AUXILIARES.WS_CERTIFICADO_ATU, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO);

            /*" -737- PERFORM R1000_00_PROCESSA_CGCCPF_DB_SELECT_1 */

            R1000_00_PROCESSA_CGCCPF_DB_SELECT_1();

            /*" -740- IF SQLCODE NOT EQUAL ZEROS AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -742- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -743- MOVE CGCCPF-REG TO WS-CGCCPF-ANT */
            _.Move(REGISTRO_WORK.CGCCPF_REG, WS_AUXILIARES.WS_CGCCPF_ANT);

            /*" -745- MOVE CERTIFICADO-REG TO WS-CERTIFICADO-ANT */
            _.Move(REGISTRO_WORK.CERTIFICADO_REG, WS_AUXILIARES.WS_CERTIFICADO_ANT);

            /*" -746- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -749- DISPLAY 'CERTIF. NAO ENCONTRADO ' PROPOVA-NUM-CERTIFICADO */
                _.Display($"CERTIF. NAO ENCONTRADO {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                /*" -750- PERFORM R1200-00-LER-CERTIFICADO */

                R1200_00_LER_CERTIFICADO_SECTION();

                /*" -751- GO TO R1000-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/ //GOTO
                return;

                /*" -753- END-IF. */
            }


            /*" -754- MOVE FUNCTION UPPER-CASE(SISTEMA-REG) TO WS-SISTEMA */
            _.Move(REGISTRO_WORK.SISTEMA_REG.ToString().ToUpper(), REGISTRO_WORK.WS_SISTEMA);

            /*" -755- MOVE FUNCTION UPPER-CASE(RESULTADO-REG) TO WS-RESULTADO */
            _.Move(REGISTRO_WORK.RESULTADO_REG.ToString().ToUpper(), REGISTRO_WORK.WS_RESULTADO);

            /*" -757- MOVE ZEROS TO WS-FLAG-APROVADO */
            _.Move(0, FILLER_2.WS_FLAG_APROVADO);

            /*" -761- DISPLAY 'R1000 02 <' CERTIFICADO-REG '>' '<' SISTEMA-REG '>' '<' RESULTADO-REG '>' */

            $"R1000 02 <{REGISTRO_WORK.CERTIFICADO_REG}><{REGISTRO_WORK.SISTEMA_REG}><{REGISTRO_WORK.RESULTADO_REG}>"
            .Display();

            /*" -762- IF (WS-SISTEMA EQUAL 'ERRO' ) */

            if ((REGISTRO_WORK.WS_SISTEMA == "ERRO"))
            {

                /*" -764- DISPLAY 'R1000 03 <' CERTIFICADO-REG '>' '<ENTRE NO ERRO>' */

                $"R1000 03 <{REGISTRO_WORK.CERTIFICADO_REG}><ENTRE NO ERRO>"
                .Display();

                /*" -765- IF (RESULTADO-REG EQUAL 'Registro não encontrado' ) */

                if ((REGISTRO_WORK.RESULTADO_REG == "Registro não encontrado"))
                {

                    /*" -766- MOVE 1879 TO ERRPROVI-COD-ERRO */
                    _.Move(1879, ERRPROVI.DCLERROS_PROP_VIDAZUL.ERRPROVI_COD_ERRO);

                    /*" -767- ELSE */
                }
                else
                {


                    /*" -768- MOVE 1876 TO ERRPROVI-COD-ERRO */
                    _.Move(1876, ERRPROVI.DCLERROS_PROP_VIDAZUL.ERRPROVI_COD_ERRO);

                    /*" -769- ADD 1 TO W-TOT-FORA-AR */
                    FILLER_2.W_TOT_FORA_AR.Value = FILLER_2.W_TOT_FORA_AR + 1;

                    /*" -770- END-IF */
                }


                /*" -771- PERFORM R2200-00-INSERT-VGCRITICA */

                R2200_00_INSERT_VGCRITICA_SECTION();

                /*" -772- PERFORM R2400-00-INSERT-ANDAMENTO */

                R2400_00_INSERT_ANDAMENTO_SECTION();

                /*" -773- PERFORM R1100-00-PROCESSA-APROVADO */

                R1100_00_PROCESSA_APROVADO_SECTION();

                /*" -774- PERFORM R1200-00-LER-CERTIFICADO */

                R1200_00_LER_CERTIFICADO_SECTION();

                /*" -775- ELSE */
            }
            else
            {


                /*" -776- MOVE 1876 TO ERRPROVI-COD-ERRO */
                _.Move(1876, ERRPROVI.DCLERROS_PROP_VIDAZUL.ERRPROVI_COD_ERRO);

                /*" -777- PERFORM R2250-00-CONSULTA-VGCRITICA */

                R2250_00_CONSULTA_VGCRITICA_SECTION();

                /*" -778- PERFORM R2500-00-DELETE-ANDAMENTO */

                R2500_00_DELETE_ANDAMENTO_SECTION();

                /*" -780- MOVE ZEROS TO ERRPROVI-COD-ERRO */
                _.Move(0, ERRPROVI.DCLERROS_PROP_VIDAZUL.ERRPROVI_COD_ERRO);

                /*" -782- DISPLAY 'R1000 03 <' CERTIFICADO-REG '>' '<ENTRE NO NAO ERRO>' */

                $"R1000 03 <{REGISTRO_WORK.CERTIFICADO_REG}><ENTRE NO NAO ERRO>"
                .Display();

                /*" -783- EVALUATE WS-RESULTADO */
                switch (REGISTRO_WORK.WS_RESULTADO.Value.Trim())
                {

                    /*" -784- WHEN 'APROVADO' */
                    case "APROVADO":

                        /*" -785- DISPLAY 'R1000 04 <' CERTIFICADO-REG '>' */

                        $"R1000 04 <{REGISTRO_WORK.CERTIFICADO_REG}>"
                        .Display();

                        /*" -786- PERFORM R1100-00-PROCESSA-APROVADO */

                        R1100_00_PROCESSA_APROVADO_SECTION();

                        /*" -791- PERFORM R1300-00-PROCESSA-CRITICA UNTIL CGCCPF-REG NOT EQUAL WS-CGCCPF-ANT OR CERTIFICADO-REG NOT EQUAL WS-CERTIFICADO-ANT OR FIM-MOVIMENTO EQUAL 'SIM' */

                        while (!(REGISTRO_WORK.CGCCPF_REG != WS_AUXILIARES.WS_CGCCPF_ANT || REGISTRO_WORK.CERTIFICADO_REG != WS_AUXILIARES.WS_CERTIFICADO_ANT || FILLER_2.FILLER_3.FIM_MOVIMENTO == "SIM"))
                        {

                            R1300_00_PROCESSA_CRITICA_SECTION();
                        }

                        /*" -792- WHEN 'RECEITA FEDERAL FORA DO AR' */
                        break;
                    case "RECEITA FEDERAL FORA DO AR":

                    /*" -793- WHEN 'DIRETRIX FORA DO AR' */
                    case "DIRETRIX FORA DO AR":

                        /*" -794- DISPLAY 'R1000 05 <' CERTIFICADO-REG '>' */

                        $"R1000 05 <{REGISTRO_WORK.CERTIFICADO_REG}>"
                        .Display();

                        /*" -795- MOVE 1876 TO ERRPROVI-COD-ERRO */
                        _.Move(1876, ERRPROVI.DCLERROS_PROP_VIDAZUL.ERRPROVI_COD_ERRO);

                        /*" -796- PERFORM R2200-00-INSERT-VGCRITICA */

                        R2200_00_INSERT_VGCRITICA_SECTION();

                        /*" -797- PERFORM R2400-00-INSERT-ANDAMENTO */

                        R2400_00_INSERT_ANDAMENTO_SECTION();

                        /*" -798- PERFORM R1100-00-PROCESSA-APROVADO */

                        R1100_00_PROCESSA_APROVADO_SECTION();

                        /*" -800- PERFORM R1200-00-LER-CERTIFICADO */

                        R1200_00_LER_CERTIFICADO_SECTION();

                        /*" -801- WHEN OTHER */
                        break;
                    default:

                        /*" -802- DISPLAY 'R1000 06 <' CERTIFICADO-REG '>' */

                        $"R1000 06 <{REGISTRO_WORK.CERTIFICADO_REG}>"
                        .Display();

                        /*" -806- PERFORM R1300-00-PROCESSA-CRITICA UNTIL CGCCPF-REG NOT EQUAL WS-CGCCPF-ANT OR CERTIFICADO-REG NOT EQUAL WS-CERTIFICADO-ANT OR FIM-MOVIMENTO EQUAL 'SIM' */

                        while (!(REGISTRO_WORK.CGCCPF_REG != WS_AUXILIARES.WS_CGCCPF_ANT || REGISTRO_WORK.CERTIFICADO_REG != WS_AUXILIARES.WS_CERTIFICADO_ANT || FILLER_2.FILLER_3.FIM_MOVIMENTO == "SIM"))
                        {

                            R1300_00_PROCESSA_CRITICA_SECTION();
                        }

                        /*" -807- END-EVALUATE */
                        break;
                }


                /*" -807- END-IF. */
            }


        }

        [StopWatch]
        /*" R1000-00-PROCESSA-CGCCPF-DB-SELECT-1 */
        public void R1000_00_PROCESSA_CGCCPF_DB_SELECT_1()
        {
            /*" -737- EXEC SQL SELECT A.NUM_APOLICE , A.COD_SUBGRUPO, VALUE(A.COD_USUARIO, 'VA0601B' ) INTO :PROPOVA-NUM-APOLICE , :PROPOVA-COD-SUBGRUPO, :PROPOVA-COD-USUARIO FROM SEGUROS.PROPOSTAS_VA A, SEGUROS.HIS_COBER_PROPOST B WHERE A.NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO AND A.SIT_REGISTRO IN ( 'E' , '9' ) AND B.NUM_CERTIFICADO = A.NUM_CERTIFICADO AND B.DATA_TERVIGENCIA = '9999-12-31' WITH UR END-EXEC. */

            var r1000_00_PROCESSA_CGCCPF_DB_SELECT_1_Query1 = new R1000_00_PROCESSA_CGCCPF_DB_SELECT_1_Query1()
            {
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = R1000_00_PROCESSA_CGCCPF_DB_SELECT_1_Query1.Execute(r1000_00_PROCESSA_CGCCPF_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PROPOVA_NUM_APOLICE, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE);
                _.Move(executed_1.PROPOVA_COD_SUBGRUPO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_SUBGRUPO);
                _.Move(executed_1.PROPOVA_COD_USUARIO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_USUARIO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1100-00-PROCESSA-APROVADO-SECTION */
        private void R1100_00_PROCESSA_APROVADO_SECTION()
        {
            /*" -817- MOVE 'R1100-00-PROCESSA-APROVADO' TO PARAGRAFO */
            _.Move("R1100-00-PROCESSA-APROVADO", FILLER_2.FILLER_3.WABEND.PARAGRAFO);

            /*" -819- MOVE '1100' TO WNR-EXEC-SQL */
            _.Move("1100", FILLER_2.FILLER_3.WABEND.WNR_EXEC_SQL);

            /*" -823- DISPLAY 'R1100 01 <WHOST-COUNT=' WHOST-COUNT '>' '<WHOST-COUNT-1800=' WHOST-COUNT-1800 '>' */

            $"R1100 01 <WHOST-COUNT={WHOST_COUNT}><WHOST-COUNT-1800={WHOST_COUNT_1800}>"
            .Display();

            /*" -825- PERFORM R1110-00-COUNT-VGCRITICA */

            R1110_00_COUNT_VGCRITICA_SECTION();

            /*" -872- PERFORM R1120-00-SELECT-HISCOBPR */

            R1120_00_SELECT_HISCOBPR_SECTION();

            /*" -875- DISPLAY 'R1100 02 <WHOST-COUNT=' WHOST-COUNT '>' '<WHOST-COUNT-1800=' WHOST-COUNT-1800 '>' */

            $"R1100 02 <WHOST-COUNT={WHOST_COUNT}><WHOST-COUNT-1800={WHOST_COUNT_1800}>"
            .Display();

            /*" -878- IF WHOST-COUNT EQUAL ZEROS AND WHOST-COUNT-1800 EQUAL ZEROS */

            if (WHOST_COUNT == 00 && WHOST_COUNT_1800 == 00)
            {

                /*" -879- PERFORM R1400-00-LE-PROPOFID */

                R1400_00_LE_PROPOFID_SECTION();

                /*" -881- IF PROPOFID-ORIGEM-PROPOSTA EQUAL 1009 OR 1010 */

                if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_ORIGEM_PROPOSTA.In("1009", "1010"))
                {

                    /*" -882- MOVE '7' TO PROPOVA-SIT-REGISTRO */
                    _.Move("7", PROPOVA.DCLPROPOSTAS_VA.PROPOVA_SIT_REGISTRO);

                    /*" -883- ELSE */
                }
                else
                {


                    /*" -889- IF PROPOFID-IND-TP-PROPOSTA EQUAL 'C' OR 'D' OR 'E' OR 'S' OR 'V' */

                    if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_IND_TP_PROPOSTA.In("C", "D", "E", "S", "V"))
                    {

                        /*" -890- MOVE '0' TO PROPOVA-SIT-REGISTRO */
                        _.Move("0", PROPOVA.DCLPROPOSTAS_VA.PROPOVA_SIT_REGISTRO);

                        /*" -891- ELSE */
                    }
                    else
                    {


                        /*" -892- IF HISCOBPR-IMP-MORNATU LESS 200000,00 */

                        if (HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMP_MORNATU < 200000.00)
                        {

                            /*" -893- MOVE '0' TO PROPOVA-SIT-REGISTRO */
                            _.Move("0", PROPOVA.DCLPROPOSTAS_VA.PROPOVA_SIT_REGISTRO);

                            /*" -894- ELSE */
                        }
                        else
                        {


                            /*" -895- MOVE '9' TO PROPOVA-SIT-REGISTRO */
                            _.Move("9", PROPOVA.DCLPROPOSTAS_VA.PROPOVA_SIT_REGISTRO);

                            /*" -896- END-IF */
                        }


                        /*" -897- END-IF */
                    }


                    /*" -903- DISPLAY 'R1100 05 <NUM-CERTIFICADO=' PROPOVA-NUM-CERTIFICADO '>' '<IND-TP-PROPOSTA=' PROPOFID-IND-TP-PROPOSTA '>' '<SIT-REGISTRO=' PROPOVA-SIT-REGISTRO '>' */

                    $"R1100 05 <NUM-CERTIFICADO={PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}><IND-TP-PROPOSTA={PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_IND_TP_PROPOSTA}><SIT-REGISTRO={PROPOVA.DCLPROPOSTAS_VA.PROPOVA_SIT_REGISTRO}>"
                    .Display();

                    /*" -904- ELSE */
                }

            }
            else
            {


                /*" -905- MOVE '9' TO PROPOVA-SIT-REGISTRO */
                _.Move("9", PROPOVA.DCLPROPOSTAS_VA.PROPOVA_SIT_REGISTRO);

                /*" -911- DISPLAY 'R1100 06 <NUM-CERTIFICADO=' PROPOVA-NUM-CERTIFICADO '>' '<IND-TP-PROPOSTA=' PROPOFID-IND-TP-PROPOSTA '>' '<SIT-REGISTRO=' PROPOVA-SIT-REGISTRO '>' */

                $"R1100 06 <NUM-CERTIFICADO={PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}><IND-TP-PROPOSTA={PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_IND_TP_PROPOSTA}><SIT-REGISTRO={PROPOVA.DCLPROPOSTAS_VA.PROPOVA_SIT_REGISTRO}>"
                .Display();

                /*" -916- END-IF. */
            }


            /*" -917- PERFORM R2000-00-UPDATE-PROPOVA */

            R2000_00_UPDATE_PROPOVA_SECTION();

            /*" -919- MOVE 1 TO WS-FLAG-APROVADO */
            _.Move(1, FILLER_2.WS_FLAG_APROVADO);

            /*" -919- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/

        [StopWatch]
        /*" R1110-00-COUNT-VGCRITICA-SECTION */
        private void R1110_00_COUNT_VGCRITICA_SECTION()
        {
            /*" -1004- MOVE 'R1110-00-COUNT-VGCRITICA  ' TO PARAGRAFO. */
            _.Move("R1110-00-COUNT-VGCRITICA  ", FILLER_2.FILLER_3.WABEND.PARAGRAFO);

            /*" -1029- MOVE '1110' TO WNR-EXEC-SQL */
            _.Move("1110", FILLER_2.FILLER_3.WABEND.WNR_EXEC_SQL);

            /*" -1040- PERFORM R1110_00_COUNT_VGCRITICA_DB_SELECT_1 */

            R1110_00_COUNT_VGCRITICA_DB_SELECT_1();

            /*" -1043- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1044- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1045- MOVE ZEROS TO WHOST-COUNT */
                    _.Move(0, WHOST_COUNT);

                    /*" -1046- ELSE */
                }
                else
                {


                    /*" -1047- DISPLAY 'FALHA NA CONSULTA TABELA VG_CRITICA_PROPOSTA' */
                    _.Display($"FALHA NA CONSULTA TABELA VG_CRITICA_PROPOSTA");

                    /*" -1048- DISPLAY ' - NUM_CERTIFICADO = ' PROPOVA-NUM-CERTIFICADO */
                    _.Display($" - NUM_CERTIFICADO = {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                    /*" -1049- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1050- END-IF */
                }


                /*" -1052- END-IF */
            }


            /*" -1068- PERFORM R1110_00_COUNT_VGCRITICA_DB_SELECT_2 */

            R1110_00_COUNT_VGCRITICA_DB_SELECT_2();

            /*" -1071- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1072- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1073- MOVE ZEROS TO WHOST-COUNT-1800 */
                    _.Move(0, WHOST_COUNT_1800);

                    /*" -1074- ELSE */
                }
                else
                {


                    /*" -1075- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1076- END-IF */
                }


                /*" -1077- END-IF */
            }


            /*" -1077- . */

        }

        [StopWatch]
        /*" R1110-00-COUNT-VGCRITICA-DB-SELECT-1 */
        public void R1110_00_COUNT_VGCRITICA_DB_SELECT_1()
        {
            /*" -1040- EXEC SQL SELECT COUNT(*) INTO :WHOST-COUNT FROM SEGUROS.VG_CRITICA_PROPOSTA A, SEGUROS.VG_DM_MSG_CRITICA B WHERE A.NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO AND A.COD_MSG_CRITICA <> 1800 AND A.STA_CRITICA IN ( '0' , '1' , '2' , '4' , '5' , '8' ) AND A.COD_MSG_CRITICA = B.COD_MSG_CRITICA AND B.COD_TP_MSG_CRITICA <> '3' WITH UR END-EXEC */

            var r1110_00_COUNT_VGCRITICA_DB_SELECT_1_Query1 = new R1110_00_COUNT_VGCRITICA_DB_SELECT_1_Query1()
            {
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = R1110_00_COUNT_VGCRITICA_DB_SELECT_1_Query1.Execute(r1110_00_COUNT_VGCRITICA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_COUNT, WHOST_COUNT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1110_99_SAIDA*/

        [StopWatch]
        /*" R1110-00-COUNT-VGCRITICA-DB-SELECT-2 */
        public void R1110_00_COUNT_VGCRITICA_DB_SELECT_2()
        {
            /*" -1068- EXEC SQL SELECT COUNT(*) INTO :WHOST-COUNT-1800 FROM SEGUROS.VG_CRITICA_PROPOSTA B, SEGUROS.PROPOSTA_FIDELIZ D WHERE B.NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO AND SUBSTR(B.NUM_CERTIFICADO,1,1) = 3 AND B.COD_MSG_CRITICA = 1800 AND B.STA_CRITICA IN ( '0' , '1' , '2' , '4' , '5' , '8' ) AND B.NUM_CERTIFICADO = D.NUM_PROPOSTA_SIVPF AND D.COD_PRODUTO_SIVPF = 11 AND B.NUM_CERTIFICADO = (SELECT C.NUM_CERTIFICADO FROM SEGUROS.VG_COMPL_SICAQWEB C WHERE C.NUM_CERTIFICADO = B.NUM_CERTIFICADO) WITH UR END-EXEC */

            var r1110_00_COUNT_VGCRITICA_DB_SELECT_2_Query1 = new R1110_00_COUNT_VGCRITICA_DB_SELECT_2_Query1()
            {
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = R1110_00_COUNT_VGCRITICA_DB_SELECT_2_Query1.Execute(r1110_00_COUNT_VGCRITICA_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_COUNT_1800, WHOST_COUNT_1800);
            }


        }

        [StopWatch]
        /*" R1120-00-SELECT-HISCOBPR-SECTION */
        private void R1120_00_SELECT_HISCOBPR_SECTION()
        {
            /*" -1087- MOVE 'R1120-00-SELECT-HISCOBPR  ' TO PARAGRAFO. */
            _.Move("R1120-00-SELECT-HISCOBPR  ", FILLER_2.FILLER_3.WABEND.PARAGRAFO);

            /*" -1089- MOVE '1120' TO WNR-EXEC-SQL. */
            _.Move("1120", FILLER_2.FILLER_3.WABEND.WNR_EXEC_SQL);

            /*" -1096- PERFORM R1120_00_SELECT_HISCOBPR_DB_SELECT_1 */

            R1120_00_SELECT_HISCOBPR_DB_SELECT_1();

            /*" -1099- IF SQLCODE NOT EQUAL ZEROS AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -1100- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1100- END-IF. */
            }


        }

        [StopWatch]
        /*" R1120-00-SELECT-HISCOBPR-DB-SELECT-1 */
        public void R1120_00_SELECT_HISCOBPR_DB_SELECT_1()
        {
            /*" -1096- EXEC SQL SELECT IMP_MORNATU INTO :HISCOBPR-IMP-MORNATU FROM SEGUROS.HIS_COBER_PROPOST WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO AND DATA_TERVIGENCIA = '9999-12-31' WITH UR END-EXEC. */

            var r1120_00_SELECT_HISCOBPR_DB_SELECT_1_Query1 = new R1120_00_SELECT_HISCOBPR_DB_SELECT_1_Query1()
            {
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = R1120_00_SELECT_HISCOBPR_DB_SELECT_1_Query1.Execute(r1120_00_SELECT_HISCOBPR_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HISCOBPR_IMP_MORNATU, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMP_MORNATU);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1120_99_SAIDA*/

        [StopWatch]
        /*" R1200-00-LER-CERTIFICADO-SECTION */
        private void R1200_00_LER_CERTIFICADO_SECTION()
        {
            /*" -1110- MOVE 'R1200-00-LER-CERTIFICADO  ' TO PARAGRAFO. */
            _.Move("R1200-00-LER-CERTIFICADO  ", FILLER_2.FILLER_3.WABEND.PARAGRAFO);

            /*" -1112- MOVE '1200' TO WNR-EXEC-SQL. */
            _.Move("1200", FILLER_2.FILLER_3.WABEND.WNR_EXEC_SQL);

            /*" -1115- PERFORM R0190-00-LE-MOV-CRIVO UNTIL CGCCPF-REG NOT EQUAL WS-CGCCPF-ANT OR CERTIFICADO-REG NOT EQUAL WS-CERTIFICADO-ANT OR FIM-MOVIMENTO EQUAL 'SIM' . */

            while (!(REGISTRO_WORK.CGCCPF_REG != WS_AUXILIARES.WS_CGCCPF_ANT || REGISTRO_WORK.CERTIFICADO_REG != WS_AUXILIARES.WS_CERTIFICADO_ANT || FILLER_2.FILLER_3.FIM_MOVIMENTO == "SIM"))
            {

                R0190_00_LE_MOV_CRIVO_SECTION();
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/

        [StopWatch]
        /*" R1300-00-PROCESSA-CRITICA-SECTION */
        private void R1300_00_PROCESSA_CRITICA_SECTION()
        {
            /*" -1125- MOVE 'R1300-00-PROCESSA-CRITICA ' TO PARAGRAFO. */
            _.Move("R1300-00-PROCESSA-CRITICA ", FILLER_2.FILLER_3.WABEND.PARAGRAFO);

            /*" -1127- MOVE '1300' TO WNR-EXEC-SQL. */
            _.Move("1300", FILLER_2.FILLER_3.WABEND.WNR_EXEC_SQL);

            /*" -1128- MOVE CERTIFICADO-REG TO PROPOVA-NUM-CERTIFICADO */
            _.Move(REGISTRO_WORK.CERTIFICADO_REG, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO);

            /*" -1129- MOVE '9' TO PROPOVA-SIT-REGISTRO */
            _.Move("9", PROPOVA.DCLPROPOSTAS_VA.PROPOVA_SIT_REGISTRO);

            /*" -1130- MOVE ZEROS TO ERRPROVI-COD-ERRO */
            _.Move(0, ERRPROVI.DCLERROS_PROP_VIDAZUL.ERRPROVI_COD_ERRO);

            /*" -1131- MOVE FUNCTION UPPER-CASE(SISTEMA-REG) TO WS-SISTEMA */
            _.Move(REGISTRO_WORK.SISTEMA_REG.ToString().ToUpper(), REGISTRO_WORK.WS_SISTEMA);

            /*" -1133- MOVE FUNCTION UPPER-CASE(RESULTADO-REG) TO WS-RESULTADO */
            _.Move(REGISTRO_WORK.RESULTADO_REG.ToString().ToUpper(), REGISTRO_WORK.WS_RESULTADO);

            /*" -1135- DISPLAY 'R1300 <' CRITERIO-REG '>' */

            $"R1300 <{REGISTRO_WORK.CRITERIO_REG}>"
            .Display();

            /*" -1137- EVALUATE CRITERIO-REG */
            switch (REGISTRO_WORK.CRITERIO_REG.Value.Trim())
            {

                /*" -1138- WHEN 'Status CPF' */
                case "Status CPF":

                    /*" -1139- WHEN 'Caixa - Status CPF' */
                    break;
                case "Caixa - Status CPF":

                /*" -1140- WHEN 'DIRVI - Status CPF - DIRETRIX' */
                case "DIRVI - Status CPF - DIRETRIX":

                    /*" -1141- WHEN 'CAIXA - Status CPF' */
                    break;
                case "CAIXA - Status CPF":

                /*" -1142- WHEN 'DIRVI - Caixa - Status CPF' */
                case "DIRVI - Caixa - Status CPF":

                    /*" -1143- IF (WS-RESULTADO NOT EQUAL 'CPF ATIVO' ) */

                    if ((REGISTRO_WORK.WS_RESULTADO != "CPF ATIVO"))
                    {

                        /*" -1144- MOVE 1862 TO ERRPROVI-COD-ERRO */
                        _.Move(1862, ERRPROVI.DCLERROS_PROP_VIDAZUL.ERRPROVI_COD_ERRO);

                        /*" -1146- PERFORM R2200-00-INSERT-VGCRITICA */

                        R2200_00_INSERT_VGCRITICA_SECTION();

                        /*" -1147- MOVE 1 TO WS-FLAG-APROVADO */
                        _.Move(1, FILLER_2.WS_FLAG_APROVADO);

                        /*" -1148- ELSE */
                    }
                    else
                    {


                        /*" -1149- PERFORM R1100-00-PROCESSA-APROVADO */

                        R1100_00_PROCESSA_APROVADO_SECTION();

                        /*" -1150- END-IF */
                    }


                    /*" -1151- WHEN 'SERASA - Restrições' */
                    break;
                case "SERASA - Restrições":

                /*" -1152- WHEN 'Caixa - Restrições no Serasa' */
                case "Caixa - Restrições no Serasa":

                    /*" -1153- WHEN 'DIRVI - Caixa - Restrições no Serasa' */
                    break;
                case "DIRVI - Caixa - Restrições no Serasa":

                    /*" -1154- EVALUATE RESULTADO-REG */
                    switch (REGISTRO_WORK.RESULTADO_REG.Value.Trim())
                    {

                        /*" -1155- WHEN 'Possui pendência de pagamento' */
                        case "Possui pendência de pagamento":

                            /*" -1156- MOVE 1856 TO ERRPROVI-COD-ERRO */
                            _.Move(1856, ERRPROVI.DCLERROS_PROP_VIDAZUL.ERRPROVI_COD_ERRO);

                            /*" -1157- WHEN 'Possui ação judicial' */
                            break;
                        case "Possui ação judicial":

                            /*" -1158- MOVE 1857 TO ERRPROVI-COD-ERRO */
                            _.Move(1857, ERRPROVI.DCLERROS_PROP_VIDAZUL.ERRPROVI_COD_ERRO);

                            /*" -1159- WHEN 'Possui cheque sem fundo' */
                            break;
                        case "Possui cheque sem fundo":

                            /*" -1160- MOVE 1858 TO ERRPROVI-COD-ERRO */
                            _.Move(1858, ERRPROVI.DCLERROS_PROP_VIDAZUL.ERRPROVI_COD_ERRO);

                            /*" -1161- WHEN 'Possui dívidas originárias PEFIN' */
                            break;
                        case "Possui dívidas originárias PEFIN":

                            /*" -1162- MOVE 1859 TO ERRPROVI-COD-ERRO */
                            _.Move(1859, ERRPROVI.DCLERROS_PROP_VIDAZUL.ERRPROVI_COD_ERRO);

                            /*" -1163- WHEN 'Possui participação em falência' */
                            break;
                        case "Possui participação em falência":

                            /*" -1164- MOVE 1860 TO ERRPROVI-COD-ERRO */
                            _.Move(1860, ERRPROVI.DCLERROS_PROP_VIDAZUL.ERRPROVI_COD_ERRO);

                            /*" -1165- WHEN 'Possui protesto' */
                            break;
                        case "Possui protesto":

                            /*" -1166- MOVE 1861 TO ERRPROVI-COD-ERRO */
                            _.Move(1861, ERRPROVI.DCLERROS_PROP_VIDAZUL.ERRPROVI_COD_ERRO);

                            /*" -1167- WHEN 'Seguro de vida PEFIN' */
                            break;
                        case "Seguro de vida PEFIN":

                            /*" -1168- MOVE 1863 TO ERRPROVI-COD-ERRO */
                            _.Move(1863, ERRPROVI.DCLERROS_PROP_VIDAZUL.ERRPROVI_COD_ERRO);

                            /*" -1170- END-EVALUATE */
                            break;
                    }


                    /*" -1171- IF (ERRPROVI-COD-ERRO > ZEROS) */

                    if ((ERRPROVI.DCLERROS_PROP_VIDAZUL.ERRPROVI_COD_ERRO > 00))
                    {

                        /*" -1173- PERFORM R2200-00-INSERT-VGCRITICA */

                        R2200_00_INSERT_VGCRITICA_SECTION();

                        /*" -1175- END-IF */
                    }


                    /*" -1176- WHEN 'DIRVI - Caixa - Restrições na Diretrix' */
                    break;
                case "DIRVI - Caixa - Restrições na Diretrix":

                    /*" -1177- EVALUATE RESULTADO-REG */
                    switch (REGISTRO_WORK.RESULTADO_REG.Value.Trim())
                    {

                        /*" -1178- WHEN 'Registro não encontrado' */
                        case "Registro não encontrado":

                            /*" -1179- MOVE 1879 TO ERRPROVI-COD-ERRO */
                            _.Move(1879, ERRPROVI.DCLERROS_PROP_VIDAZUL.ERRPROVI_COD_ERRO);

                            /*" -1180- WHEN 'Devoluções por cheque sem fundo' */
                            break;
                        case "Devoluções por cheque sem fundo":

                            /*" -1181- MOVE 1880 TO ERRPROVI-COD-ERRO */
                            _.Move(1880, ERRPROVI.DCLERROS_PROP_VIDAZUL.ERRPROVI_COD_ERRO);

                            /*" -1182- WHEN 'Sustados ou Devolvidos por cheque sem fundo' */
                            break;
                        case "Sustados ou Devolvidos por cheque sem fundo":

                            /*" -1183- MOVE 1881 TO ERRPROVI-COD-ERRO */
                            _.Move(1881, ERRPROVI.DCLERROS_PROP_VIDAZUL.ERRPROVI_COD_ERRO);

                            /*" -1184- WHEN 'Registro no SPC' */
                            break;
                        case "Registro no SPC":

                            /*" -1185- MOVE 1882 TO ERRPROVI-COD-ERRO */
                            _.Move(1882, ERRPROVI.DCLERROS_PROP_VIDAZUL.ERRPROVI_COD_ERRO);

                            /*" -1186- WHEN 'Informações no poder Judiciario' */
                            break;
                        case "Informações no poder Judiciario":

                            /*" -1187- MOVE 1883 TO ERRPROVI-COD-ERRO */
                            _.Move(1883, ERRPROVI.DCLERROS_PROP_VIDAZUL.ERRPROVI_COD_ERRO);

                            /*" -1189- END-EVALUATE */
                            break;
                    }


                    /*" -1190- IF (ERRPROVI-COD-ERRO > ZEROS) */

                    if ((ERRPROVI.DCLERROS_PROP_VIDAZUL.ERRPROVI_COD_ERRO > 00))
                    {

                        /*" -1192- PERFORM R2200-00-INSERT-VGCRITICA */

                        R2200_00_INSERT_VGCRITICA_SECTION();

                        /*" -1193- END-IF */
                    }


                    /*" -1195- END-EVALUATE */
                    break;
            }


            /*" -1196- IF (WS-FLAG-APROVADO EQUAL ZEROS) */

            if ((FILLER_2.WS_FLAG_APROVADO == 00))
            {

                /*" -1197- PERFORM R2000-00-UPDATE-PROPOVA */

                R2000_00_UPDATE_PROPOVA_SECTION();

                /*" -1199- END-IF */
            }


            /*" -1199- PERFORM R0190-00-LE-MOV-CRIVO. */

            R0190_00_LE_MOV_CRIVO_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1300_99_SAIDA*/

        [StopWatch]
        /*" R1400-00-LE-PROPOFID-SECTION */
        private void R1400_00_LE_PROPOFID_SECTION()
        {
            /*" -1209- MOVE 'R1400-00-LE-PROPOFID      ' TO PARAGRAFO. */
            _.Move("R1400-00-LE-PROPOFID      ", FILLER_2.FILLER_3.WABEND.PARAGRAFO);

            /*" -1211- MOVE '1400' TO WNR-EXEC-SQL. */
            _.Move("1400", FILLER_2.FILLER_3.WABEND.WNR_EXEC_SQL);

            /*" -1218- PERFORM R1400_00_LE_PROPOFID_DB_SELECT_1 */

            R1400_00_LE_PROPOFID_DB_SELECT_1();

            /*" -1221- IF SQLCODE NOT EQUAL ZEROS AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -1222- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1223- ELSE */
            }
            else
            {


                /*" -1224- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1225- MOVE ' ' TO PROPOFID-IND-TP-PROPOSTA */
                    _.Move(" ", PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_IND_TP_PROPOSTA);

                    /*" -1226- END-IF */
                }


                /*" -1226- END-IF. */
            }


        }

        [StopWatch]
        /*" R1400-00-LE-PROPOFID-DB-SELECT-1 */
        public void R1400_00_LE_PROPOFID_DB_SELECT_1()
        {
            /*" -1218- EXEC SQL SELECT IFNULL(IND_TP_PROPOSTA, ' ' ) , ORIGEM_PROPOSTA INTO :PROPOFID-IND-TP-PROPOSTA , :PROPOFID-ORIGEM-PROPOSTA FROM SEGUROS.PROPOSTA_FIDELIZ WHERE NUM_PROPOSTA_SIVPF = :PROPOVA-NUM-CERTIFICADO END-EXEC. */

            var r1400_00_LE_PROPOFID_DB_SELECT_1_Query1 = new R1400_00_LE_PROPOFID_DB_SELECT_1_Query1()
            {
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = R1400_00_LE_PROPOFID_DB_SELECT_1_Query1.Execute(r1400_00_LE_PROPOFID_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PROPOFID_IND_TP_PROPOSTA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_IND_TP_PROPOSTA);
                _.Move(executed_1.PROPOFID_ORIGEM_PROPOSTA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_ORIGEM_PROPOSTA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1400_99_SAIDA*/

        [StopWatch]
        /*" R2000-00-UPDATE-PROPOVA-SECTION */
        private void R2000_00_UPDATE_PROPOVA_SECTION()
        {
            /*" -1236- MOVE 'R2000-00-UPDATE-PROPOVA   ' TO PARAGRAFO. */
            _.Move("R2000-00-UPDATE-PROPOVA   ", FILLER_2.FILLER_3.WABEND.PARAGRAFO);

            /*" -1238- MOVE '2000' TO WNR-EXEC-SQL */
            _.Move("2000", FILLER_2.FILLER_3.WABEND.WNR_EXEC_SQL);

            /*" -1243- STRING OPERACAO-REG DATA-REG DELIMITED BY ' ' INTO PROPOVA-LOC-ATIVIDADE. */
            #region STRING
            var spl1 = REGISTRO_WORK.OPERACAO_REG.GetMoveValues().Split(" ").FirstOrDefault();
            var spl2 = REGISTRO_WORK.DATA_REG.GetMoveValues().Split(" ").FirstOrDefault();
            var results3 = spl1 + spl2;
            _.Move(results3, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_LOC_ATIVIDADE);
            #endregion

            /*" -1244- IF (PROPOVA-SIT-REGISTRO EQUAL '9' ) */

            if ((PROPOVA.DCLPROPOSTAS_VA.PROPOVA_SIT_REGISTRO == "9"))
            {

                /*" -1245- MOVE 'VA0055B' TO PROPOVA-COD-USUARIO */
                _.Move("VA0055B", PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_USUARIO);

                /*" -1247- END-IF */
            }


            /*" -1255- PERFORM R2000_00_UPDATE_PROPOVA_DB_UPDATE_1 */

            R2000_00_UPDATE_PROPOVA_DB_UPDATE_1();

            /*" -1258- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1259- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1261- END-IF. */
            }


            /*" -1262- ADD 1 TO W-TOT-UPD-PROPVA */
            FILLER_2.W_TOT_UPD_PROPVA.Value = FILLER_2.W_TOT_UPD_PROPVA + 1;

            /*" -1262- . */

        }

        [StopWatch]
        /*" R2000-00-UPDATE-PROPOVA-DB-UPDATE-1 */
        public void R2000_00_UPDATE_PROPOVA_DB_UPDATE_1()
        {
            /*" -1255- EXEC SQL UPDATE SEGUROS.PROPOSTAS_VA SET SIT_REGISTRO = :PROPOVA-SIT-REGISTRO , LOC_ATIVIDADE = :PROPOVA-LOC-ATIVIDADE , COD_USUARIO = :PROPOVA-COD-USUARIO , TIMESTAMP = CURRENT TIMESTAMP WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO END-EXEC. */

            var r2000_00_UPDATE_PROPOVA_DB_UPDATE_1_Update1 = new R2000_00_UPDATE_PROPOVA_DB_UPDATE_1_Update1()
            {
                PROPOVA_LOC_ATIVIDADE = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_LOC_ATIVIDADE.ToString(),
                PROPOVA_SIT_REGISTRO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_SIT_REGISTRO.ToString(),
                PROPOVA_COD_USUARIO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_USUARIO.ToString(),
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
            };

            R2000_00_UPDATE_PROPOVA_DB_UPDATE_1_Update1.Execute(r2000_00_UPDATE_PROPOVA_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_99_SAIDA*/

        [StopWatch]
        /*" R2100-00-INSERT-RELATORI-SECTION */
        private void R2100_00_INSERT_RELATORI_SECTION()
        {
            /*" -1271- MOVE 'R2100-00-INSERT-RELATORI  ' TO PARAGRAFO. */
            _.Move("R2100-00-INSERT-RELATORI  ", FILLER_2.FILLER_3.WABEND.PARAGRAFO);

            /*" -1273- MOVE '2100' TO WNR-EXEC-SQL */
            _.Move("2100", FILLER_2.FILLER_3.WABEND.WNR_EXEC_SQL);

            /*" -1281- PERFORM R2100_00_INSERT_RELATORI_DB_SELECT_1 */

            R2100_00_INSERT_RELATORI_DB_SELECT_1();

            /*" -1284- IF SQLCODE NOT EQUAL ZEROES AND 100 AND -811 */

            if (!DB.SQLCODE.In("00", "100", "-811"))
            {

                /*" -1285- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1287- END-IF. */
            }


            /*" -1288- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -1289- GO TO R2100-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2100_99_SAIDA*/ //GOTO
                return;

                /*" -1290- ELSE */
            }
            else
            {


                /*" -1292- IF SQLCODE EQUAL 100 NEXT SENTENCE */

                if (DB.SQLCODE == 100)
                {

                    /*" -1293- ELSE */
                }
                else
                {


                    /*" -1294- IF SQLCODE EQUAL -811 */

                    if (DB.SQLCODE == -811)
                    {

                        /*" -1295- MOVE '2101' TO WNR-EXEC-SQL */
                        _.Move("2101", FILLER_2.FILLER_3.WABEND.WNR_EXEC_SQL);

                        /*" -1302- PERFORM R2100_00_INSERT_RELATORI_DB_UPDATE_1 */

                        R2100_00_INSERT_RELATORI_DB_UPDATE_1();

                        /*" -1305- IF SQLCODE NOT EQUAL ZEROES */

                        if (DB.SQLCODE != 00)
                        {

                            /*" -1306- GO TO R9999-00-ROT-ERRO */

                            R9999_00_ROT_ERRO_SECTION(); //GOTO
                            return;

                            /*" -1308- END-IF */
                        }


                        /*" -1309- ADD 1 TO W-TOT-UPD-RELATO */
                        FILLER_2.W_TOT_UPD_RELATO.Value = FILLER_2.W_TOT_UPD_RELATO + 1;

                        /*" -1310- END-IF */
                    }


                    /*" -1311- END-IF */
                }


                /*" -1313- END-IF. */
            }


            /*" -1315- MOVE '2102' TO WNR-EXEC-SQL */
            _.Move("2102", FILLER_2.FILLER_3.WABEND.WNR_EXEC_SQL);

            /*" -1358- PERFORM R2100_00_INSERT_RELATORI_DB_INSERT_1 */

            R2100_00_INSERT_RELATORI_DB_INSERT_1();

            /*" -1361- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -1362- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1364- END-IF. */
            }


            /*" -1365- ADD 1 TO W-TOT-INS-RELATO */
            FILLER_2.W_TOT_INS_RELATO.Value = FILLER_2.W_TOT_INS_RELATO + 1;

            /*" -1365- . */

        }

        [StopWatch]
        /*" R2100-00-INSERT-RELATORI-DB-SELECT-1 */
        public void R2100_00_INSERT_RELATORI_DB_SELECT_1()
        {
            /*" -1281- EXEC SQL SELECT COD_USUARIO INTO :RELATORI-COD-USUARIO FROM SEGUROS.RELATORIOS WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO AND COD_RELATORIO = 'VA0469B' AND SIT_REGISTRO = '0' WITH UR END-EXEC */

            var r2100_00_INSERT_RELATORI_DB_SELECT_1_Query1 = new R2100_00_INSERT_RELATORI_DB_SELECT_1_Query1()
            {
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = R2100_00_INSERT_RELATORI_DB_SELECT_1_Query1.Execute(r2100_00_INSERT_RELATORI_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.RELATORI_COD_USUARIO, RELATORI.DCLRELATORIOS.RELATORI_COD_USUARIO);
            }


        }

        [StopWatch]
        /*" R2100-00-INSERT-RELATORI-DB-UPDATE-1 */
        public void R2100_00_INSERT_RELATORI_DB_UPDATE_1()
        {
            /*" -1302- EXEC SQL UPDATE SEGUROS.RELATORIOS SET SIT_REGISTRO = '1' WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO AND COD_RELATORIO = 'VA0469B' AND SIT_REGISTRO = '0' END-EXEC */

            var r2100_00_INSERT_RELATORI_DB_UPDATE_1_Update1 = new R2100_00_INSERT_RELATORI_DB_UPDATE_1_Update1()
            {
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
            };

            R2100_00_INSERT_RELATORI_DB_UPDATE_1_Update1.Execute(r2100_00_INSERT_RELATORI_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" R2100-00-INSERT-RELATORI-DB-INSERT-1 */
        public void R2100_00_INSERT_RELATORI_DB_INSERT_1()
        {
            /*" -1358- EXEC SQL INSERT INTO SEGUROS.RELATORIOS VALUES ( 'VA0055B' , :SISTEMAS-DATA-MOV-ABERTO, 'VA' , 'VA0469B' , 0, 0, :SISTEMAS-DATA-MOV-ABERTO, :SISTEMAS-DATA-MOV-ABERTO, :SISTEMAS-DATA-MOV-ABERTO, 0, 0, 0, 0, 0, 0, 0, 0, :PROPOVA-NUM-APOLICE, 0, 1, :PROPOVA-NUM-CERTIFICADO, 0, :PROPOVA-COD-SUBGRUPO, 16, 0, 0, ' ' , ' ' , 0, 0, ' ' , 0, 0, ' ' , '0' , ' ' , ' ' , NULL, 0, 0, CURRENT TIMESTAMP) END-EXEC. */

            var r2100_00_INSERT_RELATORI_DB_INSERT_1_Insert1 = new R2100_00_INSERT_RELATORI_DB_INSERT_1_Insert1()
            {
                SISTEMAS_DATA_MOV_ABERTO = SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.ToString(),
                PROPOVA_NUM_APOLICE = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE.ToString(),
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
                PROPOVA_COD_SUBGRUPO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_SUBGRUPO.ToString(),
            };

            R2100_00_INSERT_RELATORI_DB_INSERT_1_Insert1.Execute(r2100_00_INSERT_RELATORI_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2100_99_SAIDA*/

        [StopWatch]
        /*" R2200-00-INSERT-VGCRITICA-SECTION */
        private void R2200_00_INSERT_VGCRITICA_SECTION()
        {
            /*" -1377- MOVE 'R2200-00-INSERT-VGCRITICA  ' TO PARAGRAFO. */
            _.Move("R2200-00-INSERT-VGCRITICA  ", FILLER_2.FILLER_3.WABEND.PARAGRAFO);

            /*" -1379- INITIALIZE LK-VG001-TRACE LK-VG001-TIPO-ACAO LK-VG001-NUM-CERTIFICADO LK-VG001-SEQ-CRITICA LK-VG001-IND-TP-PROPOSTA LK-VG001-NUM-CPF-CNPJ LK-VG001-COD-MSG-CRITICA LK-VG001-COD-USUARIO LK-VG001-NOM-PROGRAMA LK-VG001-STA-CRITICA LK-VG001-DES-COMPLEMENTAR LK-VG001-S-NUM-CERTIFICADO LK-VG001-S-SEQ-CRITICA LK-VG001-S-IND-TP-PROPOSTA LK-VG001-S-COD-MSG-CRITICA LK-VG001-S-DES-MSG-CRITICA LK-VG001-S-DES-ABREV-MSG-CRIT LK-VG001-S-NUM-CPF-CNPJ LK-VG001-S-NUM-PROPOSTA LK-VG001-S-VLR-IS LK-VG001-S-VLR-PREMIO LK-VG001-S-DTA-OCORRENCIA LK-VG001-S-DTA-RCAP LK-VG001-S-STA-CRITICA LK-VG001-S-DES-STA-CRITICA LK-VG001-S-DES-COMPLEMENTAR LK-VG001-S-COD-USUARIO LK-VG001-S-NOM-PROGRAMA LK-VG001-S-DTH-CADASTRAMENTO LK-VG001-S-STA-PARA LK-VG001-IND-ERRO LK-VG001-MSG-ERRO LK-VG001-NOM-TABELA LK-VG001-SQLCODE LK-VG001-SQLERRMC */
            _.Initialize(
                SPVG001W.LK_VG001_TRACE
                , SPVG001W.LK_VG001_TIPO_ACAO
                , SPVG001W.LK_VG001_NUM_CERTIFICADO
                , SPVG001W.LK_VG001_SEQ_CRITICA
                , SPVG001W.LK_VG001_IND_TP_PROPOSTA
                , SPVG001W.LK_VG001_NUM_CPF_CNPJ
                , SPVG001W.LK_VG001_COD_MSG_CRITICA
                , SPVG001W.LK_VG001_COD_USUARIO
                , SPVG001W.LK_VG001_NOM_PROGRAMA
                , SPVG001W.LK_VG001_STA_CRITICA
                , SPVG001W.LK_VG001_DES_COMPLEMENTAR
                , SPVG001W.LK_VG001_S_NUM_CERTIFICADO
                , SPVG001W.LK_VG001_S_SEQ_CRITICA
                , SPVG001W.LK_VG001_S_IND_TP_PROPOSTA
                , SPVG001W.LK_VG001_S_COD_MSG_CRITICA
                , SPVG001W.LK_VG001_S_DES_MSG_CRITICA
                , SPVG001W.LK_VG001_S_DES_ABREV_MSG_CRIT
                , SPVG001W.LK_VG001_S_NUM_CPF_CNPJ
                , SPVG001W.LK_VG001_S_NUM_PROPOSTA
                , SPVG001W.LK_VG001_S_VLR_IS
                , SPVG001W.LK_VG001_S_VLR_PREMIO
                , SPVG001W.LK_VG001_S_DTA_OCORRENCIA
                , SPVG001W.LK_VG001_S_DTA_RCAP
                , SPVG001W.LK_VG001_S_STA_CRITICA
                , SPVG001W.LK_VG001_S_DES_STA_CRITICA
                , SPVG001W.LK_VG001_S_DES_COMPLEMENTAR
                , SPVG001W.LK_VG001_S_COD_USUARIO
                , SPVG001W.LK_VG001_S_NOM_PROGRAMA
                , SPVG001W.LK_VG001_S_DTH_CADASTRAMENTO
                , SPVG001W.LK_VG001_S_STA_PARA
                , SPVG001W.LK_VG001_IND_ERRO
                , SPVG001W.LK_VG001_MSG_ERRO
                , SPVG001W.LK_VG001_NOM_TABELA
                , SPVG001W.LK_VG001_SQLCODE
                , SPVG001W.LK_VG001_SQLERRMC
            );

            /*" -1388- STRING 'CONSULTA CRIVO NÃO RETORNOU RESULTADO : ' CRITERIO-REG(1:30) ' (' RESULTADO-REG ')' DELIMITED BY SIZE INTO VG078-DES-ANDAMENTO-TEXT END-STRING. */
            #region STRING
            var spl3 = "CONSULTA CRIVO NÃO RETORNOU RESULTADO : " + REGISTRO_WORK.CRITERIO_REG.Substring(1, 30).GetMoveValues();
            spl3 += "(";
            var spl4 = REGISTRO_WORK.RESULTADO_REG.GetMoveValues();
            spl4 += ")";
            var results5 = spl3 + spl4;
            _.Move(results5, VG078.DCLVG_ANDAMENTO_PROP.VG078_DES_ANDAMENTO.VG078_DES_ANDAMENTO_TEXT);
            #endregion

            /*" -1389- MOVE 'N' TO LK-VG001-TRACE */
            _.Move("N", SPVG001W.LK_VG001_TRACE);

            /*" -1390- MOVE 02 TO LK-VG001-TIPO-ACAO */
            _.Move(02, SPVG001W.LK_VG001_TIPO_ACAO);

            /*" -1391- MOVE PROPOVA-NUM-CERTIFICADO TO LK-VG001-NUM-CERTIFICADO */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO, SPVG001W.LK_VG001_NUM_CERTIFICADO);

            /*" -1392- MOVE 0 TO LK-VG001-SEQ-CRITICA */
            _.Move(0, SPVG001W.LK_VG001_SEQ_CRITICA);

            /*" -1393- MOVE 'PF' TO LK-VG001-IND-TP-PROPOSTA */
            _.Move("PF", SPVG001W.LK_VG001_IND_TP_PROPOSTA);

            /*" -1394- MOVE 0 TO LK-VG001-NUM-CPF-CNPJ */
            _.Move(0, SPVG001W.LK_VG001_NUM_CPF_CNPJ);

            /*" -1395- MOVE 'BATCH' TO LK-VG001-COD-USUARIO */
            _.Move("BATCH", SPVG001W.LK_VG001_COD_USUARIO);

            /*" -1396- MOVE 'VA0055B' TO LK-VG001-NOM-PROGRAMA */
            _.Move("VA0055B", SPVG001W.LK_VG001_NOM_PROGRAMA);

            /*" -1397- MOVE 'SPBVG001' TO VG001-PROGRAMA */
            _.Move("SPBVG001", SPVG001V.VG001_PROGRAMA);

            /*" -1398- MOVE SPACES TO LK-VG001-STA-CRITICA */
            _.Move("", SPVG001W.LK_VG001_STA_CRITICA);

            /*" -1399- MOVE 130 TO LK-VG001-DES-COMPLEMENTAR-L */
            _.Move(130, SPVG001W.LK_VG001_DES_COMPLEMENTAR.LK_VG001_DES_COMPLEMENTAR_L);

            /*" -1400- MOVE ERRPROVI-COD-ERRO TO LK-VG001-COD-MSG-CRITICA */
            _.Move(ERRPROVI.DCLERROS_PROP_VIDAZUL.ERRPROVI_COD_ERRO, SPVG001W.LK_VG001_COD_MSG_CRITICA);

            /*" -1402- MOVE VG078-DES-ANDAMENTO-TEXT TO LK-VG001-DES-COMPLEMENTAR-T */
            _.Move(VG078.DCLVG_ANDAMENTO_PROP.VG078_DES_ANDAMENTO.VG078_DES_ANDAMENTO_TEXT, SPVG001W.LK_VG001_DES_COMPLEMENTAR.LK_VG001_DES_COMPLEMENTAR_T);

            /*" -1404- CALL VG001-PROGRAMA USING LK-VG001-TRACE LK-VG001-TIPO-ACAO LK-VG001-NUM-CERTIFICADO LK-VG001-SEQ-CRITICA LK-VG001-IND-TP-PROPOSTA LK-VG001-NUM-CPF-CNPJ LK-VG001-COD-MSG-CRITICA LK-VG001-COD-USUARIO LK-VG001-NOM-PROGRAMA LK-VG001-STA-CRITICA LK-VG001-DES-COMPLEMENTAR LK-VG001-S-NUM-CERTIFICADO LK-VG001-S-SEQ-CRITICA LK-VG001-S-IND-TP-PROPOSTA LK-VG001-S-COD-MSG-CRITICA LK-VG001-S-DES-MSG-CRITICA LK-VG001-S-DES-ABREV-MSG-CRIT LK-VG001-S-NUM-CPF-CNPJ LK-VG001-S-NUM-PROPOSTA LK-VG001-S-VLR-IS LK-VG001-S-VLR-PREMIO LK-VG001-S-DTA-OCORRENCIA LK-VG001-S-DTA-RCAP LK-VG001-S-STA-CRITICA LK-VG001-S-DES-STA-CRITICA LK-VG001-S-DES-COMPLEMENTAR LK-VG001-S-COD-USUARIO LK-VG001-S-NOM-PROGRAMA LK-VG001-S-DTH-CADASTRAMENTO LK-VG001-S-STA-PARA LK-VG001-IND-ERRO LK-VG001-MSG-ERRO LK-VG001-NOM-TABELA LK-VG001-SQLCODE LK-VG001-SQLERRMC */
            _.Call(SPVG001V.VG001_PROGRAMA, SPVG001W);

            /*" -1405- IF LK-VG001-IND-ERRO NOT EQUAL ZEROS */

            if (SPVG001W.LK_VG001_IND_ERRO != 00)
            {

                /*" -1406- IF LK-VG001-IND-ERRO EQUAL 1 */

                if (SPVG001W.LK_VG001_IND_ERRO == 1)
                {

                    /*" -1410- DISPLAY 'ERRO JAH GRAVADO 2200 >> ' LK-VG001-NUM-CERTIFICADO ' >> ' LK-VG001-COD-MSG-CRITICA ' >> ' LK-VG001-IND-ERRO */

                    $"ERRO JAH GRAVADO 2200 >> {SPVG001W.LK_VG001_NUM_CERTIFICADO} >> {SPVG001W.LK_VG001_COD_MSG_CRITICA} >> {SPVG001W.LK_VG001_IND_ERRO}"
                    .Display();

                    /*" -1411- DISPLAY 'MSG-ERRO: ' LK-VG001-MSG-ERRO */
                    _.Display($"MSG-ERRO: {SPVG001W.LK_VG001_MSG_ERRO}");

                    /*" -1412- ELSE */
                }
                else
                {


                    /*" -1413- DISPLAY '*-------------------------------------------*' */
                    _.Display($"*-------------------------------------------*");

                    /*" -1414- DISPLAY '* 2200 -  PROBLEMAS CALL SUBROTINA SPBVG001 *' */
                    _.Display($"* 2200 -  PROBLEMAS CALL SUBROTINA SPBVG001 *");

                    /*" -1415- DISPLAY '*-------------------------------------------*' */
                    _.Display($"*-------------------------------------------*");

                    /*" -1416- DISPLAY '* NUM-CERTIF..: ' LK-VG001-NUM-CERTIFICADO */
                    _.Display($"* NUM-CERTIF..: {SPVG001W.LK_VG001_NUM_CERTIFICADO}");

                    /*" -1417- DISPLAY '* IND-ERRO....: ' LK-VG001-IND-ERRO */
                    _.Display($"* IND-ERRO....: {SPVG001W.LK_VG001_IND_ERRO}");

                    /*" -1418- DISPLAY '* MSG-ERRO....: ' LK-VG001-MSG-ERRO */
                    _.Display($"* MSG-ERRO....: {SPVG001W.LK_VG001_MSG_ERRO}");

                    /*" -1419- DISPLAY '* NOM-TABELA..: ' LK-VG001-NOM-TABELA */
                    _.Display($"* NOM-TABELA..: {SPVG001W.LK_VG001_NOM_TABELA}");

                    /*" -1420- DISPLAY '* SQLCODE.....: ' LK-VG001-SQLCODE */
                    _.Display($"* SQLCODE.....: {SPVG001W.LK_VG001_SQLCODE}");

                    /*" -1421- DISPLAY '* SQLERRMC....: ' LK-VG001-SQLERRMC */
                    _.Display($"* SQLERRMC....: {SPVG001W.LK_VG001_SQLERRMC}");

                    /*" -1423- DISPLAY '*-------------------------------------------*' */
                    _.Display($"*-------------------------------------------*");

                    /*" -1424- MOVE 999 TO SQLCODE */
                    _.Move(999, DB.SQLCODE);

                    /*" -1425- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1426- END-IF */
                }


                /*" -1428- END-IF */
            }


            /*" -1429- ADD 1 TO W-TOT-INS-VGCRITPRO */
            FILLER_2.W_TOT_INS_VGCRITPRO.Value = FILLER_2.W_TOT_INS_VGCRITPRO + 1;

            /*" -1429- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2200_99_SAIDA*/

        [StopWatch]
        /*" R2250-00-CONSULTA-VGCRITICA-SECTION */
        private void R2250_00_CONSULTA_VGCRITICA_SECTION()
        {
            /*" -1470- MOVE 'R2250-00-CONSULTA-VGCRITICA  ' TO PARAGRAFO. */
            _.Move("R2250-00-CONSULTA-VGCRITICA  ", FILLER_2.FILLER_3.WABEND.PARAGRAFO);

            /*" -1472- INITIALIZE LK-VG001-TRACE LK-VG001-TIPO-ACAO LK-VG001-NUM-CERTIFICADO LK-VG001-SEQ-CRITICA LK-VG001-IND-TP-PROPOSTA LK-VG001-NUM-CPF-CNPJ LK-VG001-COD-MSG-CRITICA LK-VG001-COD-USUARIO LK-VG001-NOM-PROGRAMA LK-VG001-STA-CRITICA LK-VG001-DES-COMPLEMENTAR LK-VG001-S-NUM-CERTIFICADO LK-VG001-S-SEQ-CRITICA LK-VG001-S-IND-TP-PROPOSTA LK-VG001-S-COD-MSG-CRITICA LK-VG001-S-DES-MSG-CRITICA LK-VG001-S-DES-ABREV-MSG-CRIT LK-VG001-S-NUM-CPF-CNPJ LK-VG001-S-NUM-PROPOSTA LK-VG001-S-VLR-IS LK-VG001-S-VLR-PREMIO LK-VG001-S-DTA-OCORRENCIA LK-VG001-S-DTA-RCAP LK-VG001-S-STA-CRITICA LK-VG001-S-DES-STA-CRITICA LK-VG001-S-DES-COMPLEMENTAR LK-VG001-S-COD-USUARIO LK-VG001-S-NOM-PROGRAMA LK-VG001-S-DTH-CADASTRAMENTO LK-VG001-S-STA-PARA LK-VG001-IND-ERRO LK-VG001-MSG-ERRO LK-VG001-NOM-TABELA LK-VG001-SQLCODE LK-VG001-SQLERRMC */
            _.Initialize(
                SPVG001W.LK_VG001_TRACE
                , SPVG001W.LK_VG001_TIPO_ACAO
                , SPVG001W.LK_VG001_NUM_CERTIFICADO
                , SPVG001W.LK_VG001_SEQ_CRITICA
                , SPVG001W.LK_VG001_IND_TP_PROPOSTA
                , SPVG001W.LK_VG001_NUM_CPF_CNPJ
                , SPVG001W.LK_VG001_COD_MSG_CRITICA
                , SPVG001W.LK_VG001_COD_USUARIO
                , SPVG001W.LK_VG001_NOM_PROGRAMA
                , SPVG001W.LK_VG001_STA_CRITICA
                , SPVG001W.LK_VG001_DES_COMPLEMENTAR
                , SPVG001W.LK_VG001_S_NUM_CERTIFICADO
                , SPVG001W.LK_VG001_S_SEQ_CRITICA
                , SPVG001W.LK_VG001_S_IND_TP_PROPOSTA
                , SPVG001W.LK_VG001_S_COD_MSG_CRITICA
                , SPVG001W.LK_VG001_S_DES_MSG_CRITICA
                , SPVG001W.LK_VG001_S_DES_ABREV_MSG_CRIT
                , SPVG001W.LK_VG001_S_NUM_CPF_CNPJ
                , SPVG001W.LK_VG001_S_NUM_PROPOSTA
                , SPVG001W.LK_VG001_S_VLR_IS
                , SPVG001W.LK_VG001_S_VLR_PREMIO
                , SPVG001W.LK_VG001_S_DTA_OCORRENCIA
                , SPVG001W.LK_VG001_S_DTA_RCAP
                , SPVG001W.LK_VG001_S_STA_CRITICA
                , SPVG001W.LK_VG001_S_DES_STA_CRITICA
                , SPVG001W.LK_VG001_S_DES_COMPLEMENTAR
                , SPVG001W.LK_VG001_S_COD_USUARIO
                , SPVG001W.LK_VG001_S_NOM_PROGRAMA
                , SPVG001W.LK_VG001_S_DTH_CADASTRAMENTO
                , SPVG001W.LK_VG001_S_STA_PARA
                , SPVG001W.LK_VG001_IND_ERRO
                , SPVG001W.LK_VG001_MSG_ERRO
                , SPVG001W.LK_VG001_NOM_TABELA
                , SPVG001W.LK_VG001_SQLCODE
                , SPVG001W.LK_VG001_SQLERRMC
            );

            /*" -1473- MOVE 'N' TO LK-VG001-TRACE */
            _.Move("N", SPVG001W.LK_VG001_TRACE);

            /*" -1474- MOVE 07 TO LK-VG001-TIPO-ACAO */
            _.Move(07, SPVG001W.LK_VG001_TIPO_ACAO);

            /*" -1475- MOVE PROPOVA-NUM-CERTIFICADO TO LK-VG001-NUM-CERTIFICADO */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO, SPVG001W.LK_VG001_NUM_CERTIFICADO);

            /*" -1476- MOVE ERRPROVI-COD-ERRO TO LK-VG001-COD-MSG-CRITICA */
            _.Move(ERRPROVI.DCLERROS_PROP_VIDAZUL.ERRPROVI_COD_ERRO, SPVG001W.LK_VG001_COD_MSG_CRITICA);

            /*" -1477- MOVE 0 TO LK-VG001-SEQ-CRITICA */
            _.Move(0, SPVG001W.LK_VG001_SEQ_CRITICA);

            /*" -1478- MOVE 'PF' TO LK-VG001-IND-TP-PROPOSTA */
            _.Move("PF", SPVG001W.LK_VG001_IND_TP_PROPOSTA);

            /*" -1479- MOVE 0 TO LK-VG001-NUM-CPF-CNPJ */
            _.Move(0, SPVG001W.LK_VG001_NUM_CPF_CNPJ);

            /*" -1480- MOVE 'BATCH' TO LK-VG001-COD-USUARIO */
            _.Move("BATCH", SPVG001W.LK_VG001_COD_USUARIO);

            /*" -1481- MOVE 'VA0055B' TO LK-VG001-NOM-PROGRAMA */
            _.Move("VA0055B", SPVG001W.LK_VG001_NOM_PROGRAMA);

            /*" -1482- MOVE 'SPBVG001' TO VG001-PROGRAMA */
            _.Move("SPBVG001", SPVG001V.VG001_PROGRAMA);

            /*" -1484- MOVE SPACES TO LK-VG001-STA-CRITICA */
            _.Move("", SPVG001W.LK_VG001_STA_CRITICA);

            /*" -1486- CALL VG001-PROGRAMA USING LK-VG001-TRACE LK-VG001-TIPO-ACAO LK-VG001-NUM-CERTIFICADO LK-VG001-SEQ-CRITICA LK-VG001-IND-TP-PROPOSTA LK-VG001-NUM-CPF-CNPJ LK-VG001-COD-MSG-CRITICA LK-VG001-COD-USUARIO LK-VG001-NOM-PROGRAMA LK-VG001-STA-CRITICA LK-VG001-DES-COMPLEMENTAR LK-VG001-S-NUM-CERTIFICADO LK-VG001-S-SEQ-CRITICA LK-VG001-S-IND-TP-PROPOSTA LK-VG001-S-COD-MSG-CRITICA LK-VG001-S-DES-MSG-CRITICA LK-VG001-S-DES-ABREV-MSG-CRIT LK-VG001-S-NUM-CPF-CNPJ LK-VG001-S-NUM-PROPOSTA LK-VG001-S-VLR-IS LK-VG001-S-VLR-PREMIO LK-VG001-S-DTA-OCORRENCIA LK-VG001-S-DTA-RCAP LK-VG001-S-STA-CRITICA LK-VG001-S-DES-STA-CRITICA LK-VG001-S-DES-COMPLEMENTAR LK-VG001-S-COD-USUARIO LK-VG001-S-NOM-PROGRAMA LK-VG001-S-DTH-CADASTRAMENTO LK-VG001-S-STA-PARA LK-VG001-IND-ERRO LK-VG001-MSG-ERRO LK-VG001-NOM-TABELA LK-VG001-SQLCODE LK-VG001-SQLERRMC */
            _.Call(SPVG001V.VG001_PROGRAMA, SPVG001W);

            /*" -1487- IF LK-VG001-IND-ERRO = 0 */

            if (SPVG001W.LK_VG001_IND_ERRO == 0)
            {

                /*" -1488- IF LK-VG001-S-NUM-CERTIFICADO > 0 */

                if (SPVG001W.LK_VG001_S_NUM_CERTIFICADO > 0)
                {

                    /*" -1489- PERFORM R2300-00-DELETE-VGCRITICA */

                    R2300_00_DELETE_VGCRITICA_SECTION();

                    /*" -1490- END-IF */
                }


                /*" -1491- ELSE */
            }
            else
            {


                /*" -1492- DISPLAY '*---------------------------------------------*' */
                _.Display($"*---------------------------------------------*");

                /*" -1493- DISPLAY '* R2200 -  PROBLEMAS CALL SUBROTINA SPBVG001  *' */
                _.Display($"* R2200 -  PROBLEMAS CALL SUBROTINA SPBVG001  *");

                /*" -1494- DISPLAY '*---------------------------------------------*' */
                _.Display($"*---------------------------------------------*");

                /*" -1495- DISPLAY '* NUM-CERTIF..: ' LK-VG001-NUM-CERTIFICADO */
                _.Display($"* NUM-CERTIF..: {SPVG001W.LK_VG001_NUM_CERTIFICADO}");

                /*" -1496- DISPLAY '* IND-ERRO....: ' LK-VG001-IND-ERRO */
                _.Display($"* IND-ERRO....: {SPVG001W.LK_VG001_IND_ERRO}");

                /*" -1497- DISPLAY '* MSG-ERRO....: ' LK-VG001-MSG-ERRO */
                _.Display($"* MSG-ERRO....: {SPVG001W.LK_VG001_MSG_ERRO}");

                /*" -1498- DISPLAY '* NOM-TABELA..: ' LK-VG001-NOM-TABELA */
                _.Display($"* NOM-TABELA..: {SPVG001W.LK_VG001_NOM_TABELA}");

                /*" -1499- DISPLAY '* SQLCODE.....: ' LK-VG001-SQLCODE */
                _.Display($"* SQLCODE.....: {SPVG001W.LK_VG001_SQLCODE}");

                /*" -1500- DISPLAY '* SQLERRMC....: ' LK-VG001-SQLERRMC */
                _.Display($"* SQLERRMC....: {SPVG001W.LK_VG001_SQLERRMC}");

                /*" -1502- DISPLAY '*---------------------------------------------*' */
                _.Display($"*---------------------------------------------*");

                /*" -1503- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1504- END-IF */
            }


            /*" -1504- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2250_99_SAIDA*/

        [StopWatch]
        /*" R2300-00-DELETE-VGCRITICA-SECTION */
        private void R2300_00_DELETE_VGCRITICA_SECTION()
        {
            /*" -1516- MOVE 'R2300-00-DELETE-VGCRITICA  ' TO PARAGRAFO. */
            _.Move("R2300-00-DELETE-VGCRITICA  ", FILLER_2.FILLER_3.WABEND.PARAGRAFO);

            /*" -1517- MOVE 'N' TO LK-VG001-TRACE */
            _.Move("N", SPVG001W.LK_VG001_TRACE);

            /*" -1518- MOVE 03 TO LK-VG001-TIPO-ACAO */
            _.Move(03, SPVG001W.LK_VG001_TIPO_ACAO);

            /*" -1519- MOVE LK-VG001-S-SEQ-CRITICA TO LK-VG001-SEQ-CRITICA */
            _.Move(SPVG001W.LK_VG001_S_SEQ_CRITICA, SPVG001W.LK_VG001_SEQ_CRITICA);

            /*" -1520- MOVE 'PF' TO LK-VG001-IND-TP-PROPOSTA */
            _.Move("PF", SPVG001W.LK_VG001_IND_TP_PROPOSTA);

            /*" -1521- MOVE 'BATCH' TO LK-VG001-COD-USUARIO */
            _.Move("BATCH", SPVG001W.LK_VG001_COD_USUARIO);

            /*" -1522- MOVE 'VA0055B' TO LK-VG001-NOM-PROGRAMA */
            _.Move("VA0055B", SPVG001W.LK_VG001_NOM_PROGRAMA);

            /*" -1523- MOVE 'SPBVG001' TO VG001-PROGRAMA */
            _.Move("SPBVG001", SPVG001V.VG001_PROGRAMA);

            /*" -1524- MOVE 'B' TO LK-VG001-STA-CRITICA */
            _.Move("B", SPVG001W.LK_VG001_STA_CRITICA);

            /*" -1525- MOVE 50 TO LK-VG001-DES-COMPLEMENTAR-L */
            _.Move(50, SPVG001W.LK_VG001_DES_COMPLEMENTAR.LK_VG001_DES_COMPLEMENTAR_L);

            /*" -1528- MOVE 'EXCLUSAO LOGICA DE ERRO DA PROPOSTA ' TO LK-VG001-DES-COMPLEMENTAR-T */
            _.Move("EXCLUSAO LOGICA DE ERRO DA PROPOSTA ", SPVG001W.LK_VG001_DES_COMPLEMENTAR.LK_VG001_DES_COMPLEMENTAR_T);

            /*" -1530- CALL VG001-PROGRAMA USING LK-VG001-TRACE LK-VG001-TIPO-ACAO LK-VG001-NUM-CERTIFICADO LK-VG001-SEQ-CRITICA LK-VG001-IND-TP-PROPOSTA LK-VG001-NUM-CPF-CNPJ LK-VG001-COD-MSG-CRITICA LK-VG001-COD-USUARIO LK-VG001-NOM-PROGRAMA LK-VG001-STA-CRITICA LK-VG001-DES-COMPLEMENTAR LK-VG001-S-NUM-CERTIFICADO LK-VG001-S-SEQ-CRITICA LK-VG001-S-IND-TP-PROPOSTA LK-VG001-S-COD-MSG-CRITICA LK-VG001-S-DES-MSG-CRITICA LK-VG001-S-DES-ABREV-MSG-CRIT LK-VG001-S-NUM-CPF-CNPJ LK-VG001-S-NUM-PROPOSTA LK-VG001-S-VLR-IS LK-VG001-S-VLR-PREMIO LK-VG001-S-DTA-OCORRENCIA LK-VG001-S-DTA-RCAP LK-VG001-S-STA-CRITICA LK-VG001-S-DES-STA-CRITICA LK-VG001-S-DES-COMPLEMENTAR LK-VG001-S-COD-USUARIO LK-VG001-S-NOM-PROGRAMA LK-VG001-S-DTH-CADASTRAMENTO LK-VG001-S-STA-PARA LK-VG001-IND-ERRO LK-VG001-MSG-ERRO LK-VG001-NOM-TABELA LK-VG001-SQLCODE LK-VG001-SQLERRMC */
            _.Call(SPVG001V.VG001_PROGRAMA, SPVG001W);

            /*" -1531- IF LK-VG001-IND-ERRO NOT EQUAL ZEROS */

            if (SPVG001W.LK_VG001_IND_ERRO != 00)
            {

                /*" -1532- DISPLAY '*---------------------------------------------*' */
                _.Display($"*---------------------------------------------*");

                /*" -1533- DISPLAY '* R2300 -  PROBLEMAS CALL SUBROTINA SPBVG001  *' */
                _.Display($"* R2300 -  PROBLEMAS CALL SUBROTINA SPBVG001  *");

                /*" -1534- DISPLAY '*---------------------------------------------*' */
                _.Display($"*---------------------------------------------*");

                /*" -1535- DISPLAY '* NUM-CERTIF..: ' LK-VG001-NUM-CERTIFICADO */
                _.Display($"* NUM-CERTIF..: {SPVG001W.LK_VG001_NUM_CERTIFICADO}");

                /*" -1536- DISPLAY '* IND-ERRO....: ' LK-VG001-IND-ERRO */
                _.Display($"* IND-ERRO....: {SPVG001W.LK_VG001_IND_ERRO}");

                /*" -1537- DISPLAY '* MSG-ERRO....: ' LK-VG001-MSG-ERRO */
                _.Display($"* MSG-ERRO....: {SPVG001W.LK_VG001_MSG_ERRO}");

                /*" -1538- DISPLAY '* NOM-TABELA..: ' LK-VG001-NOM-TABELA */
                _.Display($"* NOM-TABELA..: {SPVG001W.LK_VG001_NOM_TABELA}");

                /*" -1539- DISPLAY '* SQLCODE.....: ' LK-VG001-SQLCODE */
                _.Display($"* SQLCODE.....: {SPVG001W.LK_VG001_SQLCODE}");

                /*" -1540- DISPLAY '* SQLERRMC....: ' LK-VG001-SQLERRMC */
                _.Display($"* SQLERRMC....: {SPVG001W.LK_VG001_SQLERRMC}");

                /*" -1542- DISPLAY '*---------------------------------------------*' */
                _.Display($"*---------------------------------------------*");

                /*" -1543- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1544- END-IF */
            }


            /*" -1544- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2300_99_SAIDA*/

        [StopWatch]
        /*" R2400-00-INSERT-ANDAMENTO-SECTION */
        private void R2400_00_INSERT_ANDAMENTO_SECTION()
        {
            /*" -1576- MOVE 'R2400-00-INSERT-ANDAMENTO ' TO PARAGRAFO. */
            _.Move("R2400-00-INSERT-ANDAMENTO ", FILLER_2.FILLER_3.WABEND.PARAGRAFO);

            /*" -1578- MOVE '2400' TO WNR-EXEC-SQL */
            _.Move("2400", FILLER_2.FILLER_3.WABEND.WNR_EXEC_SQL);

            /*" -1587- STRING 'CONSULTA CRIVO NÃO RETORNOU RESULTADO : ' CRITERIO-REG(1:30) ' (' RESULTADO-REG ')' DELIMITED BY SIZE INTO VG078-DES-ANDAMENTO-TEXT END-STRING. */
            #region STRING
            var spl5 = "CONSULTA CRIVO NÃO RETORNOU RESULTADO : " + REGISTRO_WORK.CRITERIO_REG.Substring(1, 30).GetMoveValues();
            spl5 += "(";
            var spl6 = REGISTRO_WORK.RESULTADO_REG.GetMoveValues();
            spl6 += ")";
            var results7 = spl5 + spl6;
            _.Move(results7, VG078.DCLVG_ANDAMENTO_PROP.VG078_DES_ANDAMENTO.VG078_DES_ANDAMENTO_TEXT);
            #endregion

            /*" -1589- MOVE 130 TO VG078-DES-ANDAMENTO-LEN */
            _.Move(130, VG078.DCLVG_ANDAMENTO_PROP.VG078_DES_ANDAMENTO.VG078_DES_ANDAMENTO_LEN);

            /*" -1599- PERFORM R2400_00_INSERT_ANDAMENTO_DB_INSERT_1 */

            R2400_00_INSERT_ANDAMENTO_DB_INSERT_1();

            /*" -1602- IF (SQLCODE NOT EQUAL ZEROS AND -803) */

            if ((!DB.SQLCODE.In("00", "-803")))
            {

                /*" -1603- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1605- END-IF. */
            }


            /*" -1606- ADD 1 TO W-TOT-INS-VGANDPROP */
            FILLER_2.W_TOT_INS_VGANDPROP.Value = FILLER_2.W_TOT_INS_VGANDPROP + 1;

            /*" -1606- . */

        }

        [StopWatch]
        /*" R2400-00-INSERT-ANDAMENTO-DB-INSERT-1 */
        public void R2400_00_INSERT_ANDAMENTO_DB_INSERT_1()
        {
            /*" -1599- EXEC SQL INSERT INTO SEGUROS.VG_ANDAMENTO_PROP (NUM_CERTIFICADO, DTH_CADASTRAMENTO, DES_ANDAMENTO, COD_USUARIO) VALUES (:PROPOVA-NUM-CERTIFICADO, CURRENT_TIMESTAMP, :VG078-DES-ANDAMENTO, 'VA0055B' ) END-EXEC. */

            var r2400_00_INSERT_ANDAMENTO_DB_INSERT_1_Insert1 = new R2400_00_INSERT_ANDAMENTO_DB_INSERT_1_Insert1()
            {
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
                VG078_DES_ANDAMENTO = VG078.DCLVG_ANDAMENTO_PROP.VG078_DES_ANDAMENTO.ToString(),
            };

            R2400_00_INSERT_ANDAMENTO_DB_INSERT_1_Insert1.Execute(r2400_00_INSERT_ANDAMENTO_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2400_99_SAIDA*/

        [StopWatch]
        /*" R2500-00-DELETE-ANDAMENTO-SECTION */
        private void R2500_00_DELETE_ANDAMENTO_SECTION()
        {
            /*" -1615- MOVE 'R2500-00-DELETE-ANDAMENTO ' TO PARAGRAFO. */
            _.Move("R2500-00-DELETE-ANDAMENTO ", FILLER_2.FILLER_3.WABEND.PARAGRAFO);

            /*" -1617- MOVE '2500' TO WNR-EXEC-SQL */
            _.Move("2500", FILLER_2.FILLER_3.WABEND.WNR_EXEC_SQL);

            /*" -1622- PERFORM R2500_00_DELETE_ANDAMENTO_DB_DELETE_1 */

            R2500_00_DELETE_ANDAMENTO_DB_DELETE_1();

            /*" -1625- IF (SQLCODE NOT EQUAL ZEROS AND +100) */

            if ((!DB.SQLCODE.In("00", "+100")))
            {

                /*" -1626- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1628- END-IF. */
            }


            /*" -1629- ADD 1 TO W-TOT-DEL-VGANDPROP */
            FILLER_2.W_TOT_DEL_VGANDPROP.Value = FILLER_2.W_TOT_DEL_VGANDPROP + 1;

            /*" -1629- . */

        }

        [StopWatch]
        /*" R2500-00-DELETE-ANDAMENTO-DB-DELETE-1 */
        public void R2500_00_DELETE_ANDAMENTO_DB_DELETE_1()
        {
            /*" -1622- EXEC SQL DELETE FROM SEGUROS.VG_ANDAMENTO_PROP WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO AND COD_USUARIO = 'VA0055B' END-EXEC. */

            var r2500_00_DELETE_ANDAMENTO_DB_DELETE_1_Delete1 = new R2500_00_DELETE_ANDAMENTO_DB_DELETE_1_Delete1()
            {
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
            };

            R2500_00_DELETE_ANDAMENTO_DB_DELETE_1_Delete1.Execute(r2500_00_DELETE_ANDAMENTO_DB_DELETE_1_Delete1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2500_99_SAIDA*/

        [StopWatch]
        /*" R9000-00-FINALIZA-SECTION */
        private void R9000_00_FINALIZA_SECTION()
        {
            /*" -1639- MOVE 'R9000-00-FINALIZA' TO PARAGRAFO. */
            _.Move("R9000-00-FINALIZA", FILLER_2.FILLER_3.WABEND.PARAGRAFO);

            /*" -1641- MOVE '9000' TO WNR-EXEC-SQL. */
            _.Move("9000", FILLER_2.FILLER_3.WABEND.WNR_EXEC_SQL);

            /*" -1643- CLOSE MOV-CRIVO. */
            MOV_CRIVO.Close();

            /*" -1644- DISPLAY '-------------------------------------------------' */
            _.Display($"-------------------------------------------------");

            /*" -1645- DISPLAY '                 PROGRAMA VA0055B ' */
            _.Display($"                 PROGRAMA VA0055B ");

            /*" -1646- DISPLAY '               TOTAIS PARA CONTROLE ' */
            _.Display($"               TOTAIS PARA CONTROLE ");

            /*" -1647- DISPLAY '-------------------------------------------------' */
            _.Display($"-------------------------------------------------");

            /*" -1649- DISPLAY 'LIDOS ARQUIVO DO CRIVO............... ' W-TOT-LID-MOVCRIVO */
            _.Display($"LIDOS ARQUIVO DO CRIVO............... {FILLER_2.W_TOT_LID_MOVCRIVO}");

            /*" -1651- DISPLAY 'GRAVADOS NO MOVIMENTO DE ERRO........ ' W-TOT-INS-VGCRITPRO */
            _.Display($"GRAVADOS NO MOVIMENTO DE ERRO........ {FILLER_2.W_TOT_INS_VGCRITPRO}");

            /*" -1653- DISPLAY 'GRAVADOS ERRO NO ANDAMENTO PROP...... ' W-TOT-INS-VGANDPROP */
            _.Display($"GRAVADOS ERRO NO ANDAMENTO PROP...... {FILLER_2.W_TOT_INS_VGANDPROP}");

            /*" -1655- DISPLAY 'EXCLUIDO ERRO 1876 DO ANDAMENTO...... ' W-TOT-DEL-VGANDPROP */
            _.Display($"EXCLUIDO ERRO 1876 DO ANDAMENTO...... {FILLER_2.W_TOT_DEL_VGANDPROP}");

            /*" -1657- DISPLAY 'ALTERADOS PROPOSTA_VA................ ' W-TOT-UPD-PROPVA */
            _.Display($"ALTERADOS PROPOSTA_VA................ {FILLER_2.W_TOT_UPD_PROPVA}");

            /*" -1659- DISPLAY 'ALTERADOS RELATORIO.................. ' W-TOT-UPD-RELATO */
            _.Display($"ALTERADOS RELATORIO.................. {FILLER_2.W_TOT_UPD_RELATO}");

            /*" -1661- DISPLAY 'NAO INCLUIDOS - ERRO FORA DO AR...... ' W-TOT-FORA-AR */
            _.Display($"NAO INCLUIDOS - ERRO FORA DO AR...... {FILLER_2.W_TOT_FORA_AR}");

            /*" -1662- DISPLAY '-------------------------------------------------' */
            _.Display($"-------------------------------------------------");

            /*" -1664- DISPLAY 'GRAVADOS NA RELATORIOS............... ' W-TOT-INS-RELATO */
            _.Display($"GRAVADOS NA RELATORIOS............... {FILLER_2.W_TOT_INS_RELATO}");

            /*" -1665- DISPLAY '-------------------------------------------------' */
            _.Display($"-------------------------------------------------");

            /*" -1667- DISPLAY ' ' */
            _.Display($" ");

            /*" -1668- IF RETURN-CODE EQUAL ZEROS */

            if (RETURN_CODE == 00)
            {

                /*" -1669- DISPLAY ' *** VA0055B - FIM NORMAL ' */
                _.Display($" *** VA0055B - FIM NORMAL ");

                /*" -1670- ELSE */
            }
            else
            {


                /*" -1671- DISPLAY ' *** VA0055B - FIM  ANORMAL ' */
                _.Display($" *** VA0055B - FIM  ANORMAL ");

                /*" -1673- END-IF. */
            }


            /*" -1673- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -1675- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9000_99_SAIDA*/

        [StopWatch]
        /*" R9900-00-ENCERRA-SEM-MOVTO-SECTION */
        private void R9900_00_ENCERRA_SEM_MOVTO_SECTION()
        {
            /*" -1691- DISPLAY '*--------------------------------------------*' */
            _.Display($"*--------------------------------------------*");

            /*" -1692- DISPLAY '*                                            *' */
            _.Display($"*                                            *");

            /*" -1693- DISPLAY '*  VA0055B - CONSISTENCIA LOGICA MOVIMENTO   *' */
            _.Display($"*  VA0055B - CONSISTENCIA LOGICA MOVIMENTO   *");

            /*" -1694- DISPLAY '*  -------   ------------ ------ ---------   *' */
            _.Display($"*  -------   ------------ ------ ---------   *");

            /*" -1695- DISPLAY '*                                            *' */
            _.Display($"*                                            *");

            /*" -1697- DISPLAY '*     NAO HOUVE MOVIMENTACAO NESTA DATA      *' */
            _.Display($"*     NAO HOUVE MOVIMENTACAO NESTA DATA      *");

            /*" -1702- DISPLAY '*               ' SISTEMAS-DATA-MOV-ABERTO(9:2) '/' SISTEMAS-DATA-MOV-ABERTO(6:2) '/' SISTEMAS-DATA-MOV-ABERTO(1:4) '                     *' */

            $"*               {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(9, 2)}/{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(6, 2)}/{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(1, 4)}                     *"
            .Display();

            /*" -1703- DISPLAY '*                                            *' */
            _.Display($"*                                            *");

            /*" -1703- DISPLAY '*--------------------------------------------*' . */
            _.Display($"*--------------------------------------------*");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9900_99_SAIDA*/

        [StopWatch]
        /*" R9920-00-MOVIMVGA-EXISTENTE-SECTION */
        private void R9920_00_MOVIMVGA_EXISTENTE_SECTION()
        {
            /*" -1719- DISPLAY '*--------------------------------------------*' */
            _.Display($"*--------------------------------------------*");

            /*" -1720- DISPLAY '*                                            *' */
            _.Display($"*                                            *");

            /*" -1721- DISPLAY '*  VA0055B - CONSISTENCIA LOGICA MOVIMENTO   *' */
            _.Display($"*  VA0055B - CONSISTENCIA LOGICA MOVIMENTO   *");

            /*" -1722- DISPLAY '*  -------   ------------ ------ ---------   *' */
            _.Display($"*  -------   ------------ ------ ---------   *");

            /*" -1723- DISPLAY '*                                            *' */
            _.Display($"*                                            *");

            /*" -1725- DISPLAY '*     EXISTE MOVIMENTO A PROCESSAR           *' */
            _.Display($"*     EXISTE MOVIMENTO A PROCESSAR           *");

            /*" -1730- DISPLAY '*     ' SISTEMAS-DATA-MOV-ABERTO(9:2) '/' SISTEMAS-DATA-MOV-ABERTO(6:2) '/' SISTEMAS-DATA-MOV-ABERTO(1:4) '                             *' */

            $"*     {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(9, 2)}/{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(6, 2)}/{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(1, 4)}                             *"
            .Display();

            /*" -1731- DISPLAY '*                                            *' */
            _.Display($"*                                            *");

            /*" -1731- DISPLAY '*--------------------------------------------*' . */
            _.Display($"*--------------------------------------------*");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9920_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -1741- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1742- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, FILLER_2.FILLER_3.WABEND.WSQLCODE);

                /*" -1743- MOVE SQLERRD(1) TO WSQLCODE1 */
                _.Move(DB.SQLERRD[1], FILLER_2.FILLER_3.WABEND.WSQLCODE1);

                /*" -1744- MOVE SQLERRD(2) TO WSQLCODE2 */
                _.Move(DB.SQLERRD[2], FILLER_2.FILLER_3.WABEND.WSQLCODE2);

                /*" -1745- MOVE SQLCODE TO WSQLCODE3 */
                _.Move(DB.SQLCODE, FILLER_2.WSQLCODE3);

                /*" -1746- DISPLAY WABEND */
                _.Display(FILLER_2.FILLER_3.WABEND);

                /*" -1747- MOVE SQLERRMC TO WSQLERRMC */
                _.Move(DB.SQLERRMC, FILLER_2.FILLER_3.WSQLERRO.WSQLERRMC);

                /*" -1748- DISPLAY WSQLERRO */
                _.Display(FILLER_2.FILLER_3.WSQLERRO);

                /*" -1749- DISPLAY SPACES */
                _.Display($"");

                /*" -1751- DISPLAY REG-MOV-CRIVO */
                _.Display(REG_MOV_CRIVO);

                /*" -1757- DISPLAY 'LIDOS MOVIMENTO   ' W-TOT-LID-MOVCRIVO ' ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2). */

                $"LIDOS MOVIMENTO   {FILLER_2.W_TOT_LID_MOVCRIVO} {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
                .Display();
            }


            /*" -1759- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -1763- MOVE 99 TO RETURN-CODE */
            _.Move(99, RETURN_CODE);

            /*" -1763- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}