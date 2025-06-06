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
using Sias.Emissao.DB2.EM8024B;

namespace Code
{
    public class EM8024B
    {
        public bool IsCall { get; set; }

        public EM8024B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  COBRANCA                           *      */
        /*"      *   PROGRAMA ...............  EM8024B                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  PROJETO CARTAO DE CREDITO CIELO.                              *      */
        /*"      *                                                                *      */
        /*"      *   PROGRAMADOR ............  DANIEL MEDINA GOMIDE - MILLENIUM   *      */
        /*"      *   DATA CODIFICACAO .......  13/05/2019                         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO .................  PROCESSA ARQUIVO DE SAIDA CIELO-17 *      */
        /*"      *                             GERADO NO PROGRAMA EM8006B.        *      */
        /*"      *                             RECEBER OS REGISTROS DE COBRANCA   *      */
        /*"      *                             DE CARTAO DE CREDITO E ARMAZENAR   *      */
        /*"      *                             NA BASE DO SIAS E GERAR ARQUIVOS   *      */
        /*"      *                             DISTINTOS PARA ADESAO E DEMAIS     *      */
        /*"      *                             PARCELAS.                          *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                    A L T E R A C O E S                         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  VERSAO...: V.19                                               *      */
        /*"      *  JAZZ.....: 496.862             PROGRAMADOR: ELIERMES OLIVEIRA *      */
        /*"      *  DATA ....: 27/12/2023                                         *      */
        /*"      *  DESCRICAO: PROCESSAR RETORNO DE CANCELAMENTO PARCIAL DE DEMAIS*      */
        /*"      *             PARCELAS, CANCELAMENTO INSUCESSO E COMANDO DE      *      */
        /*"      *             CHARGEBACK ENVIADO PELO SAP, GERANDO ARQUIVO PARA  *      */
        /*"      *             TRATAMENTO PELO CB0124B.                           *      */
        /*"      *                                       PROCURE POR V.19         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  VERSAO...: V.18                                               *      */
        /*"      *  JAZZ.....: 406.260             PROGRAMADOR: BRICE HO.         *      */
        /*"      *  DATA ....: 12/07/2022                                         *      */
        /*"      *  DESCRICAO: PASSAR A DESPREZAR MOVIMENTOS COM                  *      */
        /*"      *             CIELO-NUM-PROPOSTA(8:2) = ZEROS , NA ROTINA        *      */
        /*"      *             R0403-00-VERIFICA-PROPOSTA                         *      */
        /*"      *                                          PROCURE POR V.18      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  VERSAO...: V.17                                               *      */
        /*"      *  JAZZ.....: 381.655             PROGRAMADOR: BRICE HO.         *      */
        /*"      *  DATA ....: 13/04/2022                                         *      */
        /*"      *  DESCRICAO: AJUSTES ABEND GERADO PELO MOVIMENTO:               *      */
        /*"      *             CIELO-TP-MOVIMENTO  = D0                           *      */
        /*"      *             CIELO-COD-MOVIMENTO = 04                           *      */
        /*"      *             CIELO-COD-RETORNO   = 28                           *      */
        /*"      *             NESSA SITUACAO NAO ATUALIZAR MOVTO_DEBITOCC_CEF    *      */
        /*"      *             PARA PARCELA DE ADESAO.                            *      */
        /*"      *                                          PROCURE POR V.17      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  VERSAO...: V.16                                               *      */
        /*"      *  JAZZ.....: 346.440             PROGRAMADOR: FRANK CARVALHO    *      */
        /*"      *  DATA ....: 14/12/2021                                         *      */
        /*"      *  DESCRICAO: INCLUIR NOVOS CODIGOS DE PRODUTOS DA CAP PARA DES- *      */
        /*"      *             PREZAR.                                            *      */
        /*"      *                                          PROCURE POR V.16      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  VERSAO...: V.15                                               *      */
        /*"      *  JAZZ.....: 332.104             PROGRAMADOR: FRANK CARVALHO    *      */
        /*"      *  DATA ....: 29/10/2021                                         *      */
        /*"      *  DESCRICAO: PASSSAR A INSERIR OS CODIGOS DE RETORNO QUE NAO    *      */
        /*"      *             EXISTIREM NO SIAS, PARA EVITAR NOVOS ABEND'S.      *      */
        /*"      *           - IMPORTANTE BUSCAR A DESCRICAO NO SAP/CIELO PARA QUE*      */
        /*"      *             A OPERACAO(GEFEA E GEMCO) ENXERGUEM A DESCRICAO    *      */
        /*"      *             CORRETA NO SIAS ONLINE.                            *      */
        /*"      *                                          PROCURE POR V.15      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * DEMAIS HISTORICOS DE MANUTENCAO VIDE FINAL DO PROGRAMA         *      */
        /*"      *----------------------------------------------------------------*      */
        #endregion


        #region VARIABLES

        public FileBasis _MOVCIELO { get; set; } = new FileBasis(new PIC("X", "350", "X(350)"));

        public FileBasis MOVCIELO
        {
            get
            {
                _.Move(REG_MOVCIELO, _MOVCIELO); VarBasis.RedefinePassValue(REG_MOVCIELO, _MOVCIELO, REG_MOVCIELO); return _MOVCIELO;
            }
        }
        public FileBasis _CCADESAO { get; set; } = new FileBasis(new PIC("X", "150", "X(150)"));

        public FileBasis CCADESAO
        {
            get
            {
                _.Move(REG_CCADESAO, _CCADESAO); VarBasis.RedefinePassValue(REG_CCADESAO, _CCADESAO, REG_CCADESAO); return _CCADESAO;
            }
        }
        public FileBasis _CCDEMAIS { get; set; } = new FileBasis(new PIC("X", "150", "X(150)"));

        public FileBasis CCDEMAIS
        {
            get
            {
                _.Move(REG_CCDEMAIS, _CCDEMAIS); VarBasis.RedefinePassValue(REG_CCDEMAIS, _CCDEMAIS, REG_CCDEMAIS); return _CCDEMAIS;
            }
        }
        /*"01        REG-MOVCIELO             PIC  X(350).*/
        public StringBasis REG_MOVCIELO { get; set; } = new StringBasis(new PIC("X", "350", "X(350)."), @"");
        /*"01        REG-CCADESAO             PIC  X(150).*/
        public StringBasis REG_CCADESAO { get; set; } = new StringBasis(new PIC("X", "150", "X(150)."), @"");
        /*"01        REG-CCDEMAIS             PIC  X(150).*/
        public StringBasis REG_CCDEMAIS { get; set; } = new StringBasis(new PIC("X", "150", "X(150)."), @"");

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"01  WS-CONTADORES.*/
        public EM8024B_WS_CONTADORES WS_CONTADORES { get; set; } = new EM8024B_WS_CONTADORES();
        public class EM8024B_WS_CONTADORES : VarBasis
        {
            /*"  03  WS-CONT-LIDOS               PIC  9(005) VALUE ZEROS.*/
            public IntBasis WS_CONT_LIDOS { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  03  WS-AC-GRAV-ADESAO           PIC  9(005) VALUE ZEROS.*/
            public IntBasis WS_AC_GRAV_ADESAO { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  03  WS-AC-GRAV-DEMAIS           PIC  9(005) VALUE ZEROS.*/
            public IntBasis WS_AC_GRAV_DEMAIS { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  03  WS-PARC-ATRASADA            PIC  9(005) VALUE ZEROS.*/
            public IntBasis WS_PARC_ATRASADA { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  03  WS-INS-MOVTO-SAP            PIC  9(005) VALUE ZEROS.*/
            public IntBasis WS_INS_MOVTO_SAP { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  03  WS-INS-INTERF-SAP           PIC  9(005) VALUE ZEROS.*/
            public IntBasis WS_INS_INTERF_SAP { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  03  WS-INS-CONTR-ARQH           PIC  9(005) VALUE ZEROS.*/
            public IntBasis WS_INS_CONTR_ARQH { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  03  WS-INS-CONTR-CIELO          PIC  9(005) VALUE ZEROS.*/
            public IntBasis WS_INS_CONTR_CIELO { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  03  WS-INS-DES-RETORNO          PIC  9(005) VALUE ZEROS.*/
            public IntBasis WS_INS_DES_RETORNO { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  03  WS-UPT-CONTR-CIELO          PIC  9(005) VALUE ZEROS.*/
            public IntBasis WS_UPT_CONTR_CIELO { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  03  WS-INS-RETORNO-CIELO        PIC  9(005) VALUE ZEROS.*/
            public IntBasis WS_INS_RETORNO_CIELO { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  03  WS-UPT-MOVTO-DEBITO         PIC  9(005) VALUE ZEROS.*/
            public IntBasis WS_UPT_MOVTO_DEBITO { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  03  WS-DESP-PRODUTO             PIC  9(005) VALUE ZEROS.*/
            public IntBasis WS_DESP_PRODUTO { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  03  WS-DESP-PRODUTO-CAP         PIC  9(005) VALUE ZEROS.*/
            public IntBasis WS_DESP_PRODUTO_CAP { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  03  WS-DESP-CHARGEBACK          PIC  9(005) VALUE ZEROS.*/
            public IntBasis WS_DESP_CHARGEBACK { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  03  WS-CANCEL-VENDA             PIC  9(005) VALUE ZEROS.*/
            public IntBasis WS_CANCEL_VENDA { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"01  WS-CONSTANTES.*/
        }
        public EM8024B_WS_CONSTANTES WS_CONSTANTES { get; set; } = new EM8024B_WS_CONSTANTES();
        public class EM8024B_WS_CONSTANTES : VarBasis
        {
            /*"  03 WS-TXT-COD-RETORNO           PIC  X(072) VALUE    'RETORNO SEM DESCRICAO. ATUALIZAR DESCRICAO COM SAP/CIELO'.*/
            public StringBasis WS_TXT_COD_RETORNO { get; set; } = new StringBasis(new PIC("X", "72", "X(072)"), @"RETORNO SEM DESCRICAO. ATUALIZAR DESCRICAO COM SAP/CIELO");
            /*"01  WS-TRABALHO.*/
        }
        public EM8024B_WS_TRABALHO WS_TRABALHO { get; set; } = new EM8024B_WS_TRABALHO();
        public class EM8024B_WS_TRABALHO : VarBasis
        {
            /*"  03  WS-ACHOU-CTRL-CIELO         PIC  X(001).*/
            public StringBasis WS_ACHOU_CTRL_CIELO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  03  WS-ACHOU-PROPOSTAVA         PIC  X(001).*/
            public StringBasis WS_ACHOU_PROPOSTAVA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  03  WS-HOST-PROX-OCORR          PIC S9(018)V   COMP-3 VALUE 0.*/
            public DoubleBasis WS_HOST_PROX_OCORR { get; set; } = new DoubleBasis(new PIC("S9", "18", "S9(018)V"), 0);
            /*"  03  WS-HOST-PROX-SEQ-HIST       PIC S9(004) USAGE COMP.*/
            public IntBasis WS_HOST_PROX_SEQ_HIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  03  WS-HOST-PROX-SEQ-CARTAO     PIC S9(004) USAGE COMP.*/
            public IntBasis WS_HOST_PROX_SEQ_CARTAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  03  WS-HOST-PROX-SEQ-ARQH       PIC S9(004) USAGE COMP.*/
            public IntBasis WS_HOST_PROX_SEQ_ARQH { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  03  WS-FIM-MOVIMENTO            PIC  X(001) VALUE SPACES.*/
            public StringBasis WS_FIM_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  03  WS-TP-PAGAMENTO             PIC  X(002) VALUE SPACES.*/
            public StringBasis WS_TP_PAGAMENTO { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
            /*"  03  WS-NUM-PARCELA              PIC  9(004)    COMP-3 VALUE 0.*/
            public IntBasis WS_NUM_PARCELA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  03  WS-COD-IDLG-ADESAO.*/
            public EM8024B_WS_COD_IDLG_ADESAO WS_COD_IDLG_ADESAO { get; set; } = new EM8024B_WS_COD_IDLG_ADESAO();
            public class EM8024B_WS_COD_IDLG_ADESAO : VarBasis
            {
                /*"    10 WS-COD-EMPRESA             PIC  X(004) VALUE SPACES.*/
                public StringBasis WS_COD_EMPRESA { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                /*"    10 WS-IDENTIFICACAO           PIC  X(011) VALUE SPACES.*/
                public StringBasis WS_IDENTIFICACAO { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"");
                /*"    10 WS-NUM-PROPOSTA            PIC  X(014) VALUE SPACES.*/
                public StringBasis WS_NUM_PROPOSTA { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"");
                /*"    10 FILLER                     PIC  X(011) VALUE SPACES.*/
                public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"");
                /*"  03  WS-COD-IDLG-DEMAIS          PIC  X(040).*/
            }
            public StringBasis WS_COD_IDLG_DEMAIS { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
            /*"  03   FILLER REDEFINES    WS-COD-IDLG-DEMAIS.*/
            private _REDEF_EM8024B_FILLER_1 _filler_1 { get; set; }
            public _REDEF_EM8024B_FILLER_1 FILLER_1
            {
                get { _filler_1 = new _REDEF_EM8024B_FILLER_1(); _.Move(WS_COD_IDLG_DEMAIS, _filler_1); VarBasis.RedefinePassValue(WS_COD_IDLG_DEMAIS, _filler_1, WS_COD_IDLG_DEMAIS); _filler_1.ValueChanged += () => { _.Move(_filler_1, WS_COD_IDLG_DEMAIS); }; return _filler_1; }
                set { VarBasis.RedefinePassValue(value, _filler_1, WS_COD_IDLG_DEMAIS); }
            }  //Redefines
            public class _REDEF_EM8024B_FILLER_1 : VarBasis
            {
                /*"    10 WS-IDLG-CONVENIO           PIC  9(006).*/
                public IntBasis WS_IDLG_CONVENIO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"    10 WS-IDLG-NSA                PIC  9(006).*/
                public IntBasis WS_IDLG_NSA { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"    10 WS-IDLG-NRSEQ              PIC  9(009).*/
                public IntBasis WS_IDLG_NRSEQ { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
                /*"    10 FILLER                     PIC  X(019).*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "19", "X(019)."), @"");
                /*"  03 WS-NUM-PROPOSTA-CIELO        PIC  9(014) VALUE ZEROS.*/

                public _REDEF_EM8024B_FILLER_1()
                {
                    WS_IDLG_CONVENIO.ValueChanged += OnValueChanged;
                    WS_IDLG_NSA.ValueChanged += OnValueChanged;
                    WS_IDLG_NRSEQ.ValueChanged += OnValueChanged;
                    FILLER_2.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WS_NUM_PROPOSTA_CIELO { get; set; } = new IntBasis(new PIC("9", "14", "9(014)"));
            /*"  03 WS-TIPO-MOVIMENTO            PIC  X(006) VALUE SPACES.*/

            public SelectorBasis WS_TIPO_MOVIMENTO { get; set; } = new SelectorBasis("006", "SPACES")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 WS-MOVTO-ADESAO                        VALUE 'ADESAO'. */
							new SelectorItemBasis("WS_MOVTO_ADESAO", "ADESAO"),
							/*" 88 WS-MOVTO-DEMAIS                        VALUE 'DEMAIS'. */
							new SelectorItemBasis("WS_MOVTO_DEMAIS", "DEMAIS"),
							/*" 88 WS-MOVTO-DEVOLU                        VALUE 'DEVOLU'. */
							new SelectorItemBasis("WS_MOVTO_DEVOLU", "DEVOLU"),
							/*" 88 WS-MOVTO-RESTIT                        VALUE 'RESTIT'. */
							new SelectorItemBasis("WS_MOVTO_RESTIT", "RESTIT")
                }
            };

            /*"  03 WS-SOMA-VLR-ADESAO           PIC  9(015)V99 COMP-3 VALUE 0.*/
            public DoubleBasis WS_SOMA_VLR_ADESAO { get; set; } = new DoubleBasis(new PIC("9", "15", "9(015)V99"), 2);
            /*"  03 WS-SOMA-VLR-DEMAIS           PIC  9(015)V99 COMP-3 VALUE 0.*/
            public DoubleBasis WS_SOMA_VLR_DEMAIS { get; set; } = new DoubleBasis(new PIC("9", "15", "9(015)V99"), 2);
            /*"  03 WS-INSERIR-RET               PIC  X(001) VALUE 'N'.*/

            public SelectorBasis WS_INSERIR_RET { get; set; } = new SelectorBasis("001", "N")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 WS-SIM-INSERIR                         VALUE 'S'. */
							new SelectorItemBasis("WS_SIM_INSERIR", "S"),
							/*" 88 WS-NAO-INSERIR                         VALUE 'N'. */
							new SelectorItemBasis("WS_NAO_INSERIR", "N")
                }
            };

            /*"  03  WS-DT-MOV-CIELO.*/
            public EM8024B_WS_DT_MOV_CIELO WS_DT_MOV_CIELO { get; set; } = new EM8024B_WS_DT_MOV_CIELO();
            public class EM8024B_WS_DT_MOV_CIELO : VarBasis
            {
                /*"    10  WS-DT-ANO-MOV             PIC  9(004).*/
                public IntBasis WS_DT_ANO_MOV { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10  FILLER                    PIC  X(001) VALUE '-'.*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"    10  WS-DT-MES-MOV             PIC  9(002).*/
                public IntBasis WS_DT_MES_MOV { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10  FILLER                    PIC  X(001) VALUE '-'.*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"    10  WS-DT-DIA-MOV             PIC  9(002).*/
                public IntBasis WS_DT_DIA_MOV { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03  WS-DT-VENCIMENTO.*/
            }
            public EM8024B_WS_DT_VENCIMENTO WS_DT_VENCIMENTO { get; set; } = new EM8024B_WS_DT_VENCIMENTO();
            public class EM8024B_WS_DT_VENCIMENTO : VarBasis
            {
                /*"    10  WS-DT-ANO-VEN             PIC  9(004).*/
                public IntBasis WS_DT_ANO_VEN { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10  FILLER                    PIC  X(001) VALUE '-'.*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"    10  WS-DT-MES-VEN             PIC  9(002).*/
                public IntBasis WS_DT_MES_VEN { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10  FILLER                    PIC  X(001) VALUE '-'.*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"    10  WS-DT-DIA-VEN             PIC  9(002).*/
                public IntBasis WS_DT_DIA_VEN { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03  WS-DT-CREDITO.*/
            }
            public EM8024B_WS_DT_CREDITO WS_DT_CREDITO { get; set; } = new EM8024B_WS_DT_CREDITO();
            public class EM8024B_WS_DT_CREDITO : VarBasis
            {
                /*"    10  WS-DT-ANO-CRE             PIC  9(004).*/
                public IntBasis WS_DT_ANO_CRE { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10  FILLER                    PIC  X(001) VALUE '-'.*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"    10  WS-DT-MES-CRE             PIC  9(002).*/
                public IntBasis WS_DT_MES_CRE { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10  FILLER                    PIC  X(001) VALUE '-'.*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"    10  WS-DT-DIA-CRE             PIC  9(002).*/
                public IntBasis WS_DT_DIA_CRE { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03  WS-DT-TARIFA.*/
            }
            public EM8024B_WS_DT_TARIFA WS_DT_TARIFA { get; set; } = new EM8024B_WS_DT_TARIFA();
            public class EM8024B_WS_DT_TARIFA : VarBasis
            {
                /*"    10  WS-DT-ANO-TAR             PIC  9(004).*/
                public IntBasis WS_DT_ANO_TAR { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10  FILLER                    PIC  X(001) VALUE '-'.*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"    10  WS-DT-MES-TAR             PIC  9(002).*/
                public IntBasis WS_DT_MES_TAR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10  FILLER                    PIC  X(001) VALUE '-'.*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"    10  WS-DT-DIA-TAR             PIC  9(002).*/
                public IntBasis WS_DT_DIA_TAR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03  WS-DT-CAPTURA.*/
            }
            public EM8024B_WS_DT_CAPTURA WS_DT_CAPTURA { get; set; } = new EM8024B_WS_DT_CAPTURA();
            public class EM8024B_WS_DT_CAPTURA : VarBasis
            {
                /*"    10  WS-DT-ANO-CAP             PIC  9(004).*/
                public IntBasis WS_DT_ANO_CAP { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10  FILLER                    PIC  X(001) VALUE '-'.*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"    10  WS-DT-MES-CAP             PIC  9(002).*/
                public IntBasis WS_DT_MES_CAP { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10  FILLER                    PIC  X(001) VALUE '-'.*/
                public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"    10  WS-DT-DIA-CAP             PIC  9(002).*/
                public IntBasis WS_DT_DIA_CAP { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03    WS0-NRAVISO               PIC  9(009) VALUE ZEROS.*/
            }
            public IntBasis WS0_NRAVISO { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03    FILLER               REDEFINES WS0-NRAVISO.*/
            private _REDEF_EM8024B_FILLER_13 _filler_13 { get; set; }
            public _REDEF_EM8024B_FILLER_13 FILLER_13
            {
                get { _filler_13 = new _REDEF_EM8024B_FILLER_13(); _.Move(WS0_NRAVISO, _filler_13); VarBasis.RedefinePassValue(WS0_NRAVISO, _filler_13, WS0_NRAVISO); _filler_13.ValueChanged += () => { _.Move(_filler_13, WS0_NRAVISO); }; return _filler_13; }
                set { VarBasis.RedefinePassValue(value, _filler_13, WS0_NRAVISO); }
            }  //Redefines
            public class _REDEF_EM8024B_FILLER_13 : VarBasis
            {
                /*"    10  WS0-PRE-AVISO             PIC  9(004).*/
                public IntBasis WS0_PRE_AVISO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10  WS0-NRO-MOV               PIC  9(001).*/
                public IntBasis WS0_NRO_MOV { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    10  WS0-NRO-NSAC              PIC  9(004).*/
                public IntBasis WS0_NRO_NSAC { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"  03  WSHOST-NRAVISO1             PIC S9(009) VALUE +0 COMP.*/

                public _REDEF_EM8024B_FILLER_13()
                {
                    WS0_PRE_AVISO.ValueChanged += OnValueChanged;
                    WS0_NRO_MOV.ValueChanged += OnValueChanged;
                    WS0_NRO_NSAC.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WSHOST_NRAVISO1 { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  03  WSHOST-NRAVISO2             PIC S9(009) VALUE +0 COMP.*/
            public IntBasis WSHOST_NRAVISO2 { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  03  WS-DTMOVABE                 PIC X(010).*/
            public StringBasis WS_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  03  WS-DTMOVABE1 REDEFINES WS-DTMOVABE.*/
            private _REDEF_EM8024B_WS_DTMOVABE1 _ws_dtmovabe1 { get; set; }
            public _REDEF_EM8024B_WS_DTMOVABE1 WS_DTMOVABE1
            {
                get { _ws_dtmovabe1 = new _REDEF_EM8024B_WS_DTMOVABE1(); _.Move(WS_DTMOVABE, _ws_dtmovabe1); VarBasis.RedefinePassValue(WS_DTMOVABE, _ws_dtmovabe1, WS_DTMOVABE); _ws_dtmovabe1.ValueChanged += () => { _.Move(_ws_dtmovabe1, WS_DTMOVABE); }; return _ws_dtmovabe1; }
                set { VarBasis.RedefinePassValue(value, _ws_dtmovabe1, WS_DTMOVABE); }
            }  //Redefines
            public class _REDEF_EM8024B_WS_DTMOVABE1 : VarBasis
            {
                /*"    10  WS-ANO-MOVABE             PIC 9(004).*/
                public IntBasis WS_ANO_MOVABE { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10  WS-BARRA1                 PIC X(001).*/
                public StringBasis WS_BARRA1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10  WS-MES-MOVABE             PIC 9(002).*/
                public IntBasis WS_MES_MOVABE { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10  WS-BARRA2                 PIC X(001).*/
                public StringBasis WS_BARRA2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10  WS-DIA-MOVABE             PIC 9(002).*/
                public IntBasis WS_DIA_MOVABE { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03  WS-DTMOVABE-I               PIC X(010).*/

                public _REDEF_EM8024B_WS_DTMOVABE1()
                {
                    WS_ANO_MOVABE.ValueChanged += OnValueChanged;
                    WS_BARRA1.ValueChanged += OnValueChanged;
                    WS_MES_MOVABE.ValueChanged += OnValueChanged;
                    WS_BARRA2.ValueChanged += OnValueChanged;
                    WS_DIA_MOVABE.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WS_DTMOVABE_I { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  03  WS-DTMOVABE-I1 REDEFINES WS-DTMOVABE-I.*/
            private _REDEF_EM8024B_WS_DTMOVABE_I1 _ws_dtmovabe_i1 { get; set; }
            public _REDEF_EM8024B_WS_DTMOVABE_I1 WS_DTMOVABE_I1
            {
                get { _ws_dtmovabe_i1 = new _REDEF_EM8024B_WS_DTMOVABE_I1(); _.Move(WS_DTMOVABE_I, _ws_dtmovabe_i1); VarBasis.RedefinePassValue(WS_DTMOVABE_I, _ws_dtmovabe_i1, WS_DTMOVABE_I); _ws_dtmovabe_i1.ValueChanged += () => { _.Move(_ws_dtmovabe_i1, WS_DTMOVABE_I); }; return _ws_dtmovabe_i1; }
                set { VarBasis.RedefinePassValue(value, _ws_dtmovabe_i1, WS_DTMOVABE_I); }
            }  //Redefines
            public class _REDEF_EM8024B_WS_DTMOVABE_I1 : VarBasis
            {
                /*"    10  WS-DIA-MOVABE             PIC 9(002).*/
                public IntBasis WS_DIA_MOVABE_0 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10  WS-BARRA1                 PIC X(001).*/
                public StringBasis WS_BARRA1_0 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10  WS-MES-MOVABE             PIC 9(002).*/
                public IntBasis WS_MES_MOVABE_0 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10  WS-BARRA2                 PIC X(001).*/
                public StringBasis WS_BARRA2_0 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10  WS-ANO-MOVABE             PIC 9(004).*/
                public IntBasis WS_ANO_MOVABE_0 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"01  WS-GRAVOU-HEADER              PIC  X(001) VALUE 'N'.*/

                public _REDEF_EM8024B_WS_DTMOVABE_I1()
                {
                    WS_DIA_MOVABE_0.ValueChanged += OnValueChanged;
                    WS_BARRA1_0.ValueChanged += OnValueChanged;
                    WS_MES_MOVABE_0.ValueChanged += OnValueChanged;
                    WS_BARRA2_0.ValueChanged += OnValueChanged;
                    WS_ANO_MOVABE_0.ValueChanged += OnValueChanged;
                }

            }
        }

        public SelectorBasis WS_GRAVOU_HEADER { get; set; } = new SelectorBasis("001", "N")
        {
            Items = new List<SelectorItemBasis> {
                            /*" 88 WS-S-GRAVOU-HEADER                     VALUE 'S'. */
							new SelectorItemBasis("WS_S_GRAVOU_HEADER", "S"),
							/*" 88 WS-N-GRAVOU-HEADER                     VALUE 'N'. */
							new SelectorItemBasis("WS_N_GRAVOU_HEADER", "N")
                }
        };

        /*"77  VIND-DTCREDITO                PIC S9(004)    COMP.*/
        public IntBasis VIND_DTCREDITO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VIND-PROC-ADVERT              PIC S9(004)    COMP.*/
        public IntBasis VIND_PROC_ADVERT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VIND-NIVE-ADVERT              PIC S9(004)    COMP.*/
        public IntBasis VIND_NIVE_ADVERT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  WABEND.*/
        public EM8024B_WABEND WABEND { get; set; } = new EM8024B_WABEND();
        public class EM8024B_WABEND : VarBasis
        {
            /*"      10    FILLER                   PIC  X(010) VALUE            'EM8024B  '.*/
            public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"EM8024B  ");
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
            /*"      10    FILLER                   PIC  X(012)   VALUE            'PARAGRAFO = '.*/
            public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"PARAGRAFO = ");
            /*"      10    PARAGRAFO                PIC  X(040)   VALUE SPACES.*/
            public StringBasis PARAGRAFO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
            /*"      10    FILLER                   PIC  X(012)   VALUE            'COMANDO   = '.*/
            public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"COMANDO   = ");
            /*"      10    COMANDO                  PIC  X(060)   VALUE SPACES.*/
            public StringBasis COMANDO { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"");
            /*"      10       FILLER                PIC  X(014) VALUE            ' *** SQLERRMC '.*/
            public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @" *** SQLERRMC ");
            /*"      10    WSQLERRMC                PIC  X(070) VALUE  SPACES.*/
            public StringBasis WSQLERRMC { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"");
            /*"01  REG-CIELO.*/
        }
        public EM8024B_REG_CIELO REG_CIELO { get; set; } = new EM8024B_REG_CIELO();
        public class EM8024B_REG_CIELO : VarBasis
        {
            /*"   05  CIELO-TP-REGISTRO          PIC  9(002).*/
            public IntBasis CIELO_TP_REGISTRO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"   05  CIELO-TP-MOVIMENTO         PIC  X(002).*/
            public StringBasis CIELO_TP_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
            /*"   05  CIELO-IDLG                 PIC  X(040).*/
            public StringBasis CIELO_IDLG { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
            /*"   05  CIELO-STA-COMPENSACAO      PIC  X(001).*/
            public StringBasis CIELO_STA_COMPENSACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"   05  CIELO-MOTIVO-COMPENSACAO   PIC  9(002).*/
            public IntBasis CIELO_MOTIVO_COMPENSACAO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"   05  CIELO-NSA-SAP              PIC  9(009).*/
            public IntBasis CIELO_NSA_SAP { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"   05  CIELO-NUM-FATURA           PIC  X(012).*/
            public StringBasis CIELO_NUM_FATURA { get; set; } = new StringBasis(new PIC("X", "12", "X(012)."), @"");
            /*"   05  CIELO-NUM-ITEM-FATURA      PIC  9(004).*/
            public IntBasis CIELO_NUM_ITEM_FATURA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"   05  CIELO-NSA-BANCO            PIC  9(006).*/
            public IntBasis CIELO_NSA_BANCO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"   05  CIELO-DTA-MOV.*/
            public EM8024B_CIELO_DTA_MOV CIELO_DTA_MOV { get; set; } = new EM8024B_CIELO_DTA_MOV();
            public class EM8024B_CIELO_DTA_MOV : VarBasis
            {
                /*"    10  CIE-DIA-MOVTO             PIC  9(002).*/
                public IntBasis CIE_DIA_MOVTO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10  CIE-MES-MOVTO             PIC  9(002).*/
                public IntBasis CIE_MES_MOVTO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10  CIE-ANO-MOVTO             PIC  9(004).*/
                public IntBasis CIE_ANO_MOVTO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"   05  CIELO-NUM-PROPOSTA         PIC  9(016).*/
            }
            public IntBasis CIELO_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "16", "9(016)."));
            /*"   05  CIELO-NUM-COM-CIELO        PIC  9(010).*/
            public IntBasis CIELO_NUM_COM_CIELO { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
            /*"   05  CIELO-COD-BCO-CRED         PIC  9(003).*/
            public IntBasis CIELO_COD_BCO_CRED { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
            /*"   05  CIELO-COD-AGE-CRED         PIC  9(005).*/
            public IntBasis CIELO_COD_AGE_CRED { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
            /*"   05  CIELO-NUM-CTA-CRED         PIC  9(012).*/
            public IntBasis CIELO_NUM_CTA_CRED { get; set; } = new IntBasis(new PIC("9", "12", "9(012)."));
            /*"   05  CIELO-DIG-CTA-CRED         PIC  9(001).*/
            public IntBasis CIELO_DIG_CTA_CRED { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"   05  CIELO-COD-CART-BANDEIRA    PIC  9(004).*/
            public IntBasis CIELO_COD_CART_BANDEIRA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"   05  CIELO-NUM-CARTAO           PIC  X(025).*/
            public StringBasis CIELO_NUM_CARTAO { get; set; } = new StringBasis(new PIC("X", "25", "X(025)."), @"");
            /*"   05  CIELO-COD-TOKEN-CARTAO     PIC  X(040).*/
            public StringBasis CIELO_COD_TOKEN_CARTAO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
            /*"   05  CIELO-STA-CART-PADRAO      PIC  X(001).*/
            public StringBasis CIELO_STA_CART_PADRAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"   05  CIELO-COD-TID-CIELO        PIC  X(020).*/
            public StringBasis CIELO_COD_TID_CIELO { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
            /*"   05  CIELO-VLR-COBRANCA         PIC  9(013)V99.*/
            public DoubleBasis CIELO_VLR_COBRANCA { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
            /*"   05  CIELO-VLR-LIQUIDO          PIC  9(013)V99.*/
            public DoubleBasis CIELO_VLR_LIQUIDO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
            /*"   05  CIELO-VLR-TAX-ADM          PIC  9(013)V99.*/
            public DoubleBasis CIELO_VLR_TAX_ADM { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
            /*"   05  CIELO-DTA-VENCIMENTO.*/
            public EM8024B_CIELO_DTA_VENCIMENTO CIELO_DTA_VENCIMENTO { get; set; } = new EM8024B_CIELO_DTA_VENCIMENTO();
            public class EM8024B_CIELO_DTA_VENCIMENTO : VarBasis
            {
                /*"    10  CIE-DIA-VENCIMENTO        PIC  9(002).*/
                public IntBasis CIE_DIA_VENCIMENTO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10  CIE-MES-VENCIMENTO        PIC  9(002).*/
                public IntBasis CIE_MES_VENCIMENTO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10  CIE-ANO-VENCIMENTO        PIC  9(004).*/
                public IntBasis CIE_ANO_VENCIMENTO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"   05  CIELO-DTA-CREDITO.*/
            }
            public EM8024B_CIELO_DTA_CREDITO CIELO_DTA_CREDITO { get; set; } = new EM8024B_CIELO_DTA_CREDITO();
            public class EM8024B_CIELO_DTA_CREDITO : VarBasis
            {
                /*"    10  CIE-DIA-CREDITO           PIC  9(002).*/
                public IntBasis CIE_DIA_CREDITO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10  CIE-MES-CREDITO           PIC  9(002).*/
                public IntBasis CIE_MES_CREDITO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10  CIE-ANO-CREDITO           PIC  9(004).*/
                public IntBasis CIE_ANO_CREDITO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"   05  CIELO-DTA-DEB-TARIFA.*/
            }
            public EM8024B_CIELO_DTA_DEB_TARIFA CIELO_DTA_DEB_TARIFA { get; set; } = new EM8024B_CIELO_DTA_DEB_TARIFA();
            public class EM8024B_CIELO_DTA_DEB_TARIFA : VarBasis
            {
                /*"    10  CIE-DIA-TARIFA            PIC  9(002).*/
                public IntBasis CIE_DIA_TARIFA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10  CIE-MES-TARIFA            PIC  9(002).*/
                public IntBasis CIE_MES_TARIFA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10  CIE-ANO-TARIFA            PIC  9(004).*/
                public IntBasis CIE_ANO_TARIFA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"   05  CIELO-DTA-AJU-CAPTURA.*/
            }
            public EM8024B_CIELO_DTA_AJU_CAPTURA CIELO_DTA_AJU_CAPTURA { get; set; } = new EM8024B_CIELO_DTA_AJU_CAPTURA();
            public class EM8024B_CIELO_DTA_AJU_CAPTURA : VarBasis
            {
                /*"    10  CIE-DIA-CAPTURA           PIC  9(002).*/
                public IntBasis CIE_DIA_CAPTURA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10  CIE-MES-CAPTURA           PIC  9(002).*/
                public IntBasis CIE_MES_CAPTURA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10  CIE-ANO-CAPTURA           PIC  9(004).*/
                public IntBasis CIE_ANO_CAPTURA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"   05  CIELO-COD-MOVIMENTO        PIC  X(002).*/
            }
            public StringBasis CIELO_COD_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
            /*"   05  CIELO-COD-RETORNO          PIC  X(003).*/
            public StringBasis CIELO_COD_RETORNO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
            /*"   05  CIELO-PROC-ADVERT          PIC  X(002).*/
            public StringBasis CIELO_PROC_ADVERT { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
            /*"   05  CIELO-NIVE-ADVERT          PIC  X(002).*/
            public StringBasis CIELO_NIVE_ADVERT { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
            /*"   05  FILLER                     PIC  X(041).*/
            public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "41", "X(041)."), @"");
            /*"01     HEAD01-REGISTRO.*/
        }
        public EM8024B_HEAD01_REGISTRO HEAD01_REGISTRO { get; set; } = new EM8024B_HEAD01_REGISTRO();
        public class EM8024B_HEAD01_REGISTRO : VarBasis
        {
            /*"  05   HEAD01-TIPO-REGISTRO       PIC  9(003).*/
            public IntBasis HEAD01_TIPO_REGISTRO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
            /*"  05   HEAD01-TIPO-ARQUIVO        PIC  9(003).*/
            public IntBasis HEAD01_TIPO_ARQUIVO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
            /*"  05   HEAD01-DATA-GERACAO.*/
            public EM8024B_HEAD01_DATA_GERACAO HEAD01_DATA_GERACAO { get; set; } = new EM8024B_HEAD01_DATA_GERACAO();
            public class EM8024B_HEAD01_DATA_GERACAO : VarBasis
            {
                /*"    10 HEAD01-ANO                 PIC  9(004).*/
                public IntBasis HEAD01_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10 HEAD01-MES                 PIC  9(002).*/
                public IntBasis HEAD01_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10 HEAD01-DIA                 PIC  9(002).*/
                public IntBasis HEAD01_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05   HEAD01-COD-CONVENIO        PIC  9(004).*/
            }
            public IntBasis HEAD01_COD_CONVENIO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05   HEAD01-NSAS                PIC  9(006).*/
            public IntBasis HEAD01_NSAS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"  05   FILLER                     PIC  X(126).*/
            public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "126", "X(126)."), @"");
            /*"01     DETAL01-REGISTRO.*/
        }
        public EM8024B_DETAL01_REGISTRO DETAL01_REGISTRO { get; set; } = new EM8024B_DETAL01_REGISTRO();
        public class EM8024B_DETAL01_REGISTRO : VarBasis
        {
            /*"  05   DETAL01-TIPO-REGISTRO      PIC  9(003).*/
            public IntBasis DETAL01_TIPO_REGISTRO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
            /*"  05   DETAL01-NUM-PROPOSTA       PIC  9(016).*/
            public IntBasis DETAL01_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "16", "9(016)."));
            /*"  05   DETAL01-NUM-PARCELA        PIC  9(003).*/
            public IntBasis DETAL01_NUM_PARCELA { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
            /*"  05   DETAL01-COD-IDLG           PIC  X(040).*/
            public StringBasis DETAL01_COD_IDLG { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
            /*"  05   DETAL01-DATA-VENCIMENTO    PIC  X(010).*/
            public StringBasis DETAL01_DATA_VENCIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  05   DETAL01-DATA-CAPTURA       PIC  X(010).*/
            public StringBasis DETAL01_DATA_CAPTURA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  05   DETAL01-DATA-CREDITO       PIC  X(010).*/
            public StringBasis DETAL01_DATA_CREDITO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  05   DETAL01-VLR-COBRANCA       PIC  9(013)V99.*/
            public DoubleBasis DETAL01_VLR_COBRANCA { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
            /*"  05   DETAL01-VLR-LIQUIDO        PIC  9(013)V99.*/
            public DoubleBasis DETAL01_VLR_LIQUIDO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
            /*"  05   DETAL01-VLR-TAX-ADM        PIC  9(013)V99.*/
            public DoubleBasis DETAL01_VLR_TAX_ADM { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
            /*"  05   DETAL01-COD-MOVIMENTO      PIC  X(002).*/
            public StringBasis DETAL01_COD_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
            /*"  05   DETAL01-COD-RETORNO        PIC  X(003).*/
            public StringBasis DETAL01_COD_RETORNO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
            /*"  05   DETAL01-PROC-ADVERT        PIC  X(002).*/
            public StringBasis DETAL01_PROC_ADVERT { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
            /*"  05   DETAL01-NIVE-ADVERT        PIC  X(002).*/
            public StringBasis DETAL01_NIVE_ADVERT { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
            /*"  05   DETAL01-MOTI-COMPEN        PIC  9(002).*/
            public IntBasis DETAL01_MOTI_COMPEN { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"  05   FILLER                     PIC  X(008).*/
            public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"01      TRAIL01-REGISTRO.*/
        }
        public EM8024B_TRAIL01_REGISTRO TRAIL01_REGISTRO { get; set; } = new EM8024B_TRAIL01_REGISTRO();
        public class EM8024B_TRAIL01_REGISTRO : VarBasis
        {
            /*"  05    TRAIL01-TIPO-REGISTRO     PIC  9(003).*/
            public IntBasis TRAIL01_TIPO_REGISTRO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
            /*"  05    TRAIL01-DATA-MOVIMENTO.*/
            public EM8024B_TRAIL01_DATA_MOVIMENTO TRAIL01_DATA_MOVIMENTO { get; set; } = new EM8024B_TRAIL01_DATA_MOVIMENTO();
            public class EM8024B_TRAIL01_DATA_MOVIMENTO : VarBasis
            {
                /*"    10  TRAIL01-ANO               PIC  9(004).*/
                public IntBasis TRAIL01_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10  TRAIL01-MES               PIC  9(002).*/
                public IntBasis TRAIL01_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10  TRAIL01-DIA               PIC  9(002).*/
                public IntBasis TRAIL01_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05    TRAIL01-COD-CONVENIO      PIC  9(004).*/
            }
            public IntBasis TRAIL01_COD_CONVENIO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05    TRAIL01-NSAS              PIC  9(005).*/
            public IntBasis TRAIL01_NSAS { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
            /*"  05    TRAIL01-QTD-TOTAL         PIC  9(009).*/
            public IntBasis TRAIL01_QTD_TOTAL { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"  05    TRAIL01-VLR-TOTAL         PIC  9(015)V99.*/
            public DoubleBasis TRAIL01_VLR_TOTAL { get; set; } = new DoubleBasis(new PIC("9", "15", "9(015)V99."), 2);
            /*"  05    FILLER                    PIC  X(074).*/
            public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "74", "X(074)."), @"");
            /*"01            AUX-RELATORIO.*/
        }
        public EM8024B_AUX_RELATORIO AUX_RELATORIO { get; set; } = new EM8024B_AUX_RELATORIO();
        public class EM8024B_AUX_RELATORIO : VarBasis
        {
            /*"  03          LC01.*/
            public EM8024B_LC01 LC01 { get; set; } = new EM8024B_LC01();
            public class EM8024B_LC01 : VarBasis
            {
                /*"    10        FILLER              PIC  X(007)  VALUE             'EM8024B'.*/
                public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"EM8024B");
                /*"    10        FILLER              PIC  X(033)  VALUE SPACES.*/
                public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "33", "X(033)"), @"");
                /*"    10        LC01-EMPRESA        PIC  X(040).*/
                public StringBasis LC01_EMPRESA { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                /*"    10        FILLER              PIC  X(032)  VALUE SPACES.*/
                public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "32", "X(032)"), @"");
                /*"    10        FILLER              PIC  X(010)  VALUE             'PAGINA: '.*/
                public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"PAGINA: ");
                /*"    10        FILLER              PIC  X(005)  VALUE SPACES.*/
                public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
                /*"    10        LC01-PAGINA         PIC  ZZZZ9.*/
                public IntBasis LC01_PAGINA { get; set; } = new IntBasis(new PIC("9", "5", "ZZZZ9."));
                /*"  03          LC02.*/
            }
            public EM8024B_LC02 LC02 { get; set; } = new EM8024B_LC02();
            public class EM8024B_LC02 : VarBasis
            {
                /*"    10        FILLER              PIC  X(112)  VALUE SPACES.*/
                public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "112", "X(112)"), @"");
                /*"    10        FILLER              PIC  X(010)  VALUE             'DATA  : '.*/
                public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"DATA  : ");
                /*"    10        LC02-DATA           PIC  X(010).*/
                public StringBasis LC02_DATA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"  03          LC03.*/
            }
            public EM8024B_LC03 LC03 { get; set; } = new EM8024B_LC03();
            public class EM8024B_LC03 : VarBasis
            {
                /*"    10        FILLER              PIC  X(035)  VALUE SPACES.*/
                public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "35", "X(035)"), @"");
                /*"    10        FILLER              PIC  X(038)  VALUE             'CONTROLE DE DOCUMENTOS PROCESSADOS EM '.*/
                public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "38", "X(038)"), @"CONTROLE DE DOCUMENTOS PROCESSADOS EM ");
                /*"    10        LC03-DTMOVTO        PIC  X(010).*/
                public StringBasis LC03_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"    10        FILLER              PIC  X(029)  VALUE SPACES.*/
                public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "29", "X(029)"), @"");
                /*"    10        FILLER              PIC  X(010)  VALUE             'HORA  : '.*/
                public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"HORA  : ");
                /*"    10        FILLER              PIC  X(002)  VALUE SPACES.*/
                public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
                /*"    10        LC03-HORA           PIC  X(008).*/
                public StringBasis LC03_HORA { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
                /*"  03          LC04.*/
            }
            public EM8024B_LC04 LC04 { get; set; } = new EM8024B_LC04();
            public class EM8024B_LC04 : VarBasis
            {
                /*"    10        FILLER              PIC  X(132)  VALUE             'CONVENIO: 9020 - CARTAO DE CREDITO (CIELO)'.*/
                public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "132", "X(132)"), @"CONVENIO: 9020 - CARTAO DE CREDITO (CIELO)");
                /*"  03          LC05.*/
            }
            public EM8024B_LC05 LC05 { get; set; } = new EM8024B_LC05();
            public class EM8024B_LC05 : VarBasis
            {
                /*"    10        FILLER              PIC  X(132)  VALUE ALL '-'.*/
                public StringBasis FILLER_40 { get; set; } = new StringBasis(new PIC("X", "132", "X(132)"), @"ALL");
                /*"  03          LC06.*/
            }
            public EM8024B_LC06 LC06 { get; set; } = new EM8024B_LC06();
            public class EM8024B_LC06 : VarBasis
            {
                /*"    10        FILLER              PIC  X(010)  VALUE SPACES.*/
                public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"    10        FILLER              PIC  X(007)  VALUE             'CARTAO'.*/
                public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"CARTAO");
                /*"    10        FILLER              PIC  X(015)  VALUE             'TITULO/APOLICE'.*/
                public StringBasis FILLER_43 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"TITULO/APOLICE");
                /*"    10        FILLER              PIC  X(010)  VALUE             'ENDOSSO'.*/
                public StringBasis FILLER_44 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"ENDOSSO");
                /*"    10        FILLER              PIC  X(009)  VALUE             'PARC'.*/
                public StringBasis FILLER_45 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"PARC");
                /*"    10        FILLER              PIC  X(016)  VALUE             'CERTIFICADO'.*/
                public StringBasis FILLER_46 { get; set; } = new StringBasis(new PIC("X", "16", "X(016)"), @"CERTIFICADO");
                /*"    10        FILLER              PIC  X(015)  VALUE             'VENCTO'.*/
                public StringBasis FILLER_47 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"VENCTO");
                /*"    10        FILLER              PIC  X(006)  VALUE             'VALOR'.*/
                public StringBasis FILLER_48 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"VALOR");
                /*"    10        FILLER              PIC  X(005)  VALUE             'PROD'.*/
                public StringBasis FILLER_49 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"PROD");
                /*"    10        FILLER              PIC  X(005)  VALUE             'TIPO'.*/
                public StringBasis FILLER_50 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"TIPO");
                /*"    10        FILLER              PIC  X(034)  VALUE             'MENSAGEM'.*/
                public StringBasis FILLER_51 { get; set; } = new StringBasis(new PIC("X", "34", "X(034)"), @"MENSAGEM");
                /*"  03          LC08.*/
            }
            public EM8024B_LC08 LC08 { get; set; } = new EM8024B_LC08();
            public class EM8024B_LC08 : VarBasis
            {
                /*"    10        FILLER              PIC  X(132)  VALUE SPACES.*/
                public StringBasis FILLER_52 { get; set; } = new StringBasis(new PIC("X", "132", "X(132)"), @"");
                /*"  03          LD01.*/
            }
            public EM8024B_LD01 LD01 { get; set; } = new EM8024B_LD01();
            public class EM8024B_LD01 : VarBasis
            {
                /*"    10        LD01-CARTAO         PIC  ZZZZZZZZZZZZZZZ9.*/
                public IntBasis LD01_CARTAO { get; set; } = new IntBasis(new PIC("9", "16", "ZZZZZZZZZZZZZZZ9."));
                /*"    10        FILLER              PIC  X(001)  VALUE SPACES.*/
                public StringBasis FILLER_53 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10        LD01-TITULO         PIC  ZZZZZZZZZZZZZ9.*/
                public IntBasis LD01_TITULO { get; set; } = new IntBasis(new PIC("9", "14", "ZZZZZZZZZZZZZ9."));
                /*"    10        FILLER              PIC  X(001)  VALUE SPACES.*/
                public StringBasis FILLER_54 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10        LD01-ENDOSSO        PIC  ZZZZZZ9.*/
                public IntBasis LD01_ENDOSSO { get; set; } = new IntBasis(new PIC("9", "7", "ZZZZZZ9."));
                /*"    10        FILLER              PIC  X(003)  VALUE SPACES.*/
                public StringBasis FILLER_55 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
                /*"    10        LD01-PARCELA        PIC  ZZZ9.*/
                public IntBasis LD01_PARCELA { get; set; } = new IntBasis(new PIC("9", "4", "ZZZ9."));
                /*"    10        FILLER              PIC  X(001)  VALUE SPACES.*/
                public StringBasis FILLER_56 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10        LD01-NRCERTIF       PIC  ZZZZZZZZZZZZZZ9.*/
                public IntBasis LD01_NRCERTIF { get; set; } = new IntBasis(new PIC("9", "15", "ZZZZZZZZZZZZZZ9."));
                /*"    10        FILLER              PIC  X(001)  VALUE SPACES.*/
                public StringBasis FILLER_57 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10        LD01-DTVENCTO       PIC  X(010).*/
                public StringBasis LD01_DTVENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"    10        FILLER              PIC  X(001)  VALUE SPACES.*/
                public StringBasis FILLER_58 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10        LD01-VALOR          PIC  ZZ.ZZZ.ZZ9,99.*/
                public DoubleBasis LD01_VALOR { get; set; } = new DoubleBasis(new PIC("9", "8", "ZZ.ZZZ.ZZ9V99."), 2);
                /*"    10        FILLER              PIC  X(001)  VALUE SPACES.*/
                public StringBasis FILLER_59 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10        LD01-CODPRODU       PIC  9(004).*/
                public IntBasis LD01_CODPRODU { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10        FILLER              PIC  X(001)  VALUE SPACES.*/
                public StringBasis FILLER_60 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10        LD01-CODTRANS       PIC  9(004).*/
                public IntBasis LD01_CODTRANS { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10        FILLER              PIC  X(001)  VALUE SPACES.*/
                public StringBasis FILLER_61 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10        LD01-MENSAGEM       PIC  X(034).*/
                public StringBasis LD01_MENSAGEM { get; set; } = new StringBasis(new PIC("X", "34", "X(034)."), @"");
            }
        }


        public Copies.LBWPF002 LBWPF002 { get; set; } = new Copies.LBWPF002();
        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.GE099 GE099 { get; set; } = new Dclgens.GE099();
        public Dclgens.GE100 GE100 { get; set; } = new Dclgens.GE100();
        public Dclgens.GE105 GE105 { get; set; } = new Dclgens.GE105();
        public Dclgens.GE407 GE407 { get; set; } = new Dclgens.GE407();
        public Dclgens.GE408 GE408 { get; set; } = new Dclgens.GE408();
        public Dclgens.GE409 GE409 { get; set; } = new Dclgens.GE409();
        public Dclgens.GE410 GE410 { get; set; } = new Dclgens.GE410();
        public Dclgens.GE411 GE411 { get; set; } = new Dclgens.GE411();
        public Dclgens.MOVDEBCE MOVDEBCE { get; set; } = new Dclgens.MOVDEBCE();
        public Dclgens.MOVIMCOB MOVIMCOB { get; set; } = new Dclgens.MOVIMCOB();
        public Dclgens.PROPOVA PROPOVA { get; set; } = new Dclgens.PROPOVA();
        public Dclgens.PROPOFID PROPOFID { get; set; } = new Dclgens.PROPOFID();
        public Dclgens.PARCEVID PARCEVID { get; set; } = new Dclgens.PARCEVID();
        public Dclgens.COBHISVI COBHISVI { get; set; } = new Dclgens.COBHISVI();
        public Dclgens.HISLANCT HISLANCT { get; set; } = new Dclgens.HISLANCT();
        public Dclgens.AVISOCRE AVISOCRE { get; set; } = new Dclgens.AVISOCRE();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string MOVCIELO_FILE_NAME_P, string CCADESAO_FILE_NAME_P, string CCDEMAIS_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                MOVCIELO.SetFile(MOVCIELO_FILE_NAME_P);
                CCADESAO.SetFile(CCADESAO_FILE_NAME_P);
                CCDEMAIS.SetFile(CCDEMAIS_FILE_NAME_P);

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
            /*" -523- DISPLAY '--------------------------------------------------' */
            _.Display($"--------------------------------------------------");

            /*" -524- DISPLAY ' EM8024B - PROCESSA <ARQ_H> CONVENIO 09020 - CIELO' */
            _.Display($" EM8024B - PROCESSA <ARQ_H> CONVENIO 09020 - CIELO");

            /*" -525- DISPLAY '                                                  ' */
            _.Display($"                                                  ");

            /*" -527- DISPLAY 'VERSAO V.19 : ' FUNCTION WHEN-COMPILED ' - 496.862' */

            $"VERSAO V.19 : FUNCTION{_.WhenCompiled()} - 496.862"
            .Display();

            /*" -528- DISPLAY '                                                  ' */
            _.Display($"                                                  ");

            /*" -535- DISPLAY 'INICIOU PROCESSAMENTO EM ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2) */

            $"INICIOU PROCESSAMENTO EM {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
            .Display();

            /*" -536- DISPLAY '                                                  ' */
            _.Display($"                                                  ");

            /*" -538- DISPLAY '--------------------------------------------------' */
            _.Display($"--------------------------------------------------");

            /*" -540- PERFORM R0050-00-INICIO */

            R0050_00_INICIO_SECTION();

            /*" -543- PERFORM R0400-00-PROCESSA-MOVIMENTO UNTIL WS-FIM-MOVIMENTO = 'S' */

            while (!(WS_TRABALHO.WS_FIM_MOVIMENTO == "S"))
            {

                R0400_00_PROCESSA_MOVIMENTO_SECTION();
            }

            /*" -543- . */

            /*" -0- FLUXCONTROL_PERFORM R0000_99_FINALIZA */

            R0000_99_FINALIZA();

        }

        [StopWatch]
        /*" R0000-99-FINALIZA */
        private void R0000_99_FINALIZA(bool isPerform = false)
        {
            /*" -549- MOVE 'R0000-99-FINALIZA' TO PARAGRAFO */
            _.Move("R0000-99-FINALIZA", WABEND.PARAGRAFO);

            /*" -550- MOVE 'FINALIZA PROCESSAMENTO' TO COMANDO */
            _.Move("FINALIZA PROCESSAMENTO", WABEND.COMANDO);

            /*" -552- DISPLAY PARAGRAFO */
            _.Display(WABEND.PARAGRAFO);

            /*" -553- IF WS-S-GRAVOU-HEADER */

            if (WS_GRAVOU_HEADER["WS_S_GRAVOU_HEADER"])
            {

                /*" -554- PERFORM R0409-00-GRAVA-TRAILER-CIELO */

                R0409_00_GRAVA_TRAILER_CIELO_SECTION();

                /*" -555- END-IF */
            }


            /*" -557- PERFORM R9988-00-MONTAR-CONTROLES */

            R9988_00_MONTAR_CONTROLES_SECTION();

            /*" -557- EXEC SQL COMMIT WORK END-EXEC */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -559- DISPLAY 'EM8024B - PROCESSADO COM COMMIT' */
            _.Display($"EM8024B - PROCESSADO COM COMMIT");

            /*" -561- DISPLAY 'EM8024B - PROCESSADO COM COMMIT' */
            _.Display($"EM8024B - PROCESSADO COM COMMIT");

            /*" -565- CLOSE MOVCIELO CCADESAO CCDEMAIS */
            MOVCIELO.Close();
            CCADESAO.Close();
            CCDEMAIS.Close();

            /*" -567- MOVE ZEROS TO RETURN-CODE */
            _.Move(0, RETURN_CODE);

            /*" -567- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" R0050-00-INICIO-SECTION */
        private void R0050_00_INICIO_SECTION()
        {
            /*" -573- MOVE 'R0050-00-INICIO' TO PARAGRAFO */
            _.Move("R0050-00-INICIO", WABEND.PARAGRAFO);

            /*" -574- MOVE 'INICIALIZA PROGRAMA' TO COMANDO */
            _.Move("INICIALIZA PROGRAMA", WABEND.COMANDO);

            /*" -576- DISPLAY PARAGRAFO */
            _.Display(WABEND.PARAGRAFO);

            /*" -578- OPEN INPUT MOVCIELO */
            MOVCIELO.Open(REG_MOVCIELO);

            /*" -581- OPEN OUTPUT CCADESAO CCDEMAIS */
            CCADESAO.Open(REG_CCADESAO);
            CCDEMAIS.Open(REG_CCDEMAIS);

            /*" -583- INITIALIZE WS-CONTADORES, WS-TRABALHO */
            _.Initialize(
                WS_CONTADORES
                , WS_TRABALHO
            );

            /*" -585- PERFORM R0100-00-SELECT-V0SISTEMA */

            R0100_00_SELECT_V0SISTEMA_SECTION();

            /*" -589- MOVE SPACES TO WS-FIM-MOVIMENTO */
            _.Move("", WS_TRABALHO.WS_FIM_MOVIMENTO);

            /*" -591- PERFORM R0200-00-LER-MOVIMENTO */

            R0200_00_LER_MOVIMENTO_SECTION();

            /*" -591- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0050_99_SAIDA*/

        [StopWatch]
        /*" R0100-00-SELECT-V0SISTEMA-SECTION */
        private void R0100_00_SELECT_V0SISTEMA_SECTION()
        {
            /*" -599- MOVE 'R0100-00-SELECT-V0SISTEMA' TO PARAGRAFO */
            _.Move("R0100-00-SELECT-V0SISTEMA", WABEND.PARAGRAFO);

            /*" -600- MOVE 'SELECT SISTEMAS' TO COMANDO */
            _.Move("SELECT SISTEMAS", WABEND.COMANDO);

            /*" -602- DISPLAY PARAGRAFO */
            _.Display(WABEND.PARAGRAFO);

            /*" -608- PERFORM R0100_00_SELECT_V0SISTEMA_DB_SELECT_1 */

            R0100_00_SELECT_V0SISTEMA_DB_SELECT_1();

            /*" -611-  EVALUATE SQLCODE  */

            /*" -612-  WHEN ZEROS  */

            /*" -612- IF   SQLCODE EQUALS  ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -613- DISPLAY 'DATA DO MOVIMENTO: ' SISTEMAS-DATA-MOV-ABERTO */
                _.Display($"DATA DO MOVIMENTO: {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}");

                /*" -614-  WHEN +100  */

                /*" -614- ELSE IF   SQLCODE EQUALS  +100 */
            }
            else

            if (DB.SQLCODE == +100)
            {

                /*" -615- DISPLAY 'R0100-00-SISTEMA NAO ENCONTRADO ' */
                _.Display($"R0100-00-SISTEMA NAO ENCONTRADO ");

                /*" -616- DISPLAY 'IDE-SISTEMA = EM' */
                _.Display($"IDE-SISTEMA = EM");

                /*" -617- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -618-  WHEN OTHER  */

                /*" -618- ELSE */
            }
            else
            {


                /*" -619- DISPLAY 'R0100-00-ERRO NO SELECT SISTEMAS' */
                _.Display($"R0100-00-ERRO NO SELECT SISTEMAS");

                /*" -620- DISPLAY 'IDE-SISTEMA = EM' */
                _.Display($"IDE-SISTEMA = EM");

                /*" -621- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -623-  END-EVALUATE  */

                /*" -623- END-IF */
            }


            /*" -625- MOVE SISTEMAS-DATA-MOV-ABERTO TO WS-DTMOVABE */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, WS_TRABALHO.WS_DTMOVABE);

            /*" -627- MOVE WS-DIA-MOVABE OF WS-DTMOVABE1 TO WS-DIA-MOVABE OF WS-DTMOVABE-I1 */
            _.Move(WS_TRABALHO.WS_DTMOVABE1.WS_DIA_MOVABE, WS_TRABALHO.WS_DTMOVABE_I1.WS_DIA_MOVABE_0);

            /*" -629- MOVE WS-MES-MOVABE OF WS-DTMOVABE1 TO WS-MES-MOVABE OF WS-DTMOVABE-I1 */
            _.Move(WS_TRABALHO.WS_DTMOVABE1.WS_MES_MOVABE, WS_TRABALHO.WS_DTMOVABE_I1.WS_MES_MOVABE_0);

            /*" -632- MOVE WS-ANO-MOVABE OF WS-DTMOVABE1 TO WS-ANO-MOVABE OF WS-DTMOVABE-I1 */
            _.Move(WS_TRABALHO.WS_DTMOVABE1.WS_ANO_MOVABE, WS_TRABALHO.WS_DTMOVABE_I1.WS_ANO_MOVABE_0);

            /*" -636- MOVE '/' TO WS-BARRA1 OF WS-DTMOVABE-I1 WS-BARRA2 OF WS-DTMOVABE-I1 */
            _.Move("/", WS_TRABALHO.WS_DTMOVABE_I1.WS_BARRA1_0);
            _.Move("/", WS_TRABALHO.WS_DTMOVABE_I1.WS_BARRA2_0);


            /*" -636- . */

        }

        [StopWatch]
        /*" R0100-00-SELECT-V0SISTEMA-DB-SELECT-1 */
        public void R0100_00_SELECT_V0SISTEMA_DB_SELECT_1()
        {
            /*" -608- EXEC SQL SELECT DATA_MOV_ABERTO INTO :SISTEMAS-DATA-MOV-ABERTO FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'EM' WITH UR END-EXEC */

            var r0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1 = new R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1.Execute(r0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/

        [StopWatch]
        /*" R0200-00-LER-MOVIMENTO-SECTION */
        private void R0200_00_LER_MOVIMENTO_SECTION()
        {
            /*" -644- MOVE 'R0200-00-LER-MOVIMENTO' TO PARAGRAFO */
            _.Move("R0200-00-LER-MOVIMENTO", WABEND.PARAGRAFO);

            /*" -645- MOVE 'LER PROXIMO REGISTRO' TO COMANDO */
            _.Move("LER PROXIMO REGISTRO", WABEND.COMANDO);

            /*" -647- DISPLAY PARAGRAFO */
            _.Display(WABEND.PARAGRAFO);

            /*" -648- READ MOVCIELO AT END */
            try
            {
                MOVCIELO.Read(() =>
                {

                    /*" -650- MOVE 'S' TO WS-FIM-MOVIMENTO */
                    _.Move("S", WS_TRABALHO.WS_FIM_MOVIMENTO);

                    /*" -651- GO TO R0200-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_99_SAIDA*/ //GOTO
                    return;

                    /*" -652- END-READ */
                });

                _.Move(MOVCIELO.Value, REG_MOVCIELO);

            }
            catch (GoToException ex)
            {
                return;
            }
            /*" -654- ADD 1 TO WS-CONT-LIDOS */
            WS_CONTADORES.WS_CONT_LIDOS.Value = WS_CONTADORES.WS_CONT_LIDOS + 1;

            /*" -656- MOVE REG-MOVCIELO TO REG-CIELO */
            _.Move(MOVCIELO?.Value, REG_CIELO);

            /*" -657- IF CIELO-DTA-MOV EQUAL ZEROS */

            if (REG_CIELO.CIELO_DTA_MOV == 00)
            {

                /*" -658- DISPLAY 'R0200-00-LER-MOVIMENTO' */
                _.Display($"R0200-00-LER-MOVIMENTO");

                /*" -659- DISPLAY 'DATA DO MOVIMENTO NO ARQUIVO INVALIDA' */
                _.Display($"DATA DO MOVIMENTO NO ARQUIVO INVALIDA");

                /*" -660- DISPLAY 'CIELO-IDLG = ' CIELO-IDLG */
                _.Display($"CIELO-IDLG = {REG_CIELO.CIELO_IDLG}");

                /*" -661- DISPLAY 'CIELO-DTA-MOV = ' CIELO-DTA-MOV */
                _.Display($"CIELO-DTA-MOV = {REG_CIELO.CIELO_DTA_MOV}");

                /*" -662- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -664- END-IF */
            }


            /*" -665- IF CIELO-DTA-VENCIMENTO EQUAL ZEROS */

            if (REG_CIELO.CIELO_DTA_VENCIMENTO == 00)
            {

                /*" -666- MOVE 01010001 TO CIELO-DTA-VENCIMENTO */
                _.Move(01010001, REG_CIELO.CIELO_DTA_VENCIMENTO);

                /*" -668- END-IF */
            }


            /*" -669- IF CIELO-DTA-CREDITO EQUAL ZEROS */

            if (REG_CIELO.CIELO_DTA_CREDITO == 00)
            {

                /*" -670- MOVE 01010001 TO CIELO-DTA-CREDITO */
                _.Move(01010001, REG_CIELO.CIELO_DTA_CREDITO);

                /*" -672- END-IF */
            }


            /*" -673- IF CIELO-DTA-DEB-TARIFA EQUAL ZEROS */

            if (REG_CIELO.CIELO_DTA_DEB_TARIFA == 00)
            {

                /*" -674- MOVE 01010001 TO CIELO-DTA-DEB-TARIFA */
                _.Move(01010001, REG_CIELO.CIELO_DTA_DEB_TARIFA);

                /*" -676- END-IF */
            }


            /*" -677- IF CIELO-DTA-AJU-CAPTURA EQUAL ZEROS */

            if (REG_CIELO.CIELO_DTA_AJU_CAPTURA == 00)
            {

                /*" -678- MOVE 01010001 TO CIELO-DTA-AJU-CAPTURA */
                _.Move(01010001, REG_CIELO.CIELO_DTA_AJU_CAPTURA);

                /*" -680- END-IF */
            }


            /*" -681- MOVE CIE-DIA-MOVTO TO WS-DT-DIA-MOV */
            _.Move(REG_CIELO.CIELO_DTA_MOV.CIE_DIA_MOVTO, WS_TRABALHO.WS_DT_MOV_CIELO.WS_DT_DIA_MOV);

            /*" -682- MOVE CIE-MES-MOVTO TO WS-DT-MES-MOV */
            _.Move(REG_CIELO.CIELO_DTA_MOV.CIE_MES_MOVTO, WS_TRABALHO.WS_DT_MOV_CIELO.WS_DT_MES_MOV);

            /*" -684- MOVE CIE-ANO-MOVTO TO WS-DT-ANO-MOV */
            _.Move(REG_CIELO.CIELO_DTA_MOV.CIE_ANO_MOVTO, WS_TRABALHO.WS_DT_MOV_CIELO.WS_DT_ANO_MOV);

            /*" -685- MOVE CIE-DIA-VENCIMENTO TO WS-DT-DIA-VEN */
            _.Move(REG_CIELO.CIELO_DTA_VENCIMENTO.CIE_DIA_VENCIMENTO, WS_TRABALHO.WS_DT_VENCIMENTO.WS_DT_DIA_VEN);

            /*" -686- MOVE CIE-MES-VENCIMENTO TO WS-DT-MES-VEN */
            _.Move(REG_CIELO.CIELO_DTA_VENCIMENTO.CIE_MES_VENCIMENTO, WS_TRABALHO.WS_DT_VENCIMENTO.WS_DT_MES_VEN);

            /*" -688- MOVE CIE-ANO-VENCIMENTO TO WS-DT-ANO-VEN */
            _.Move(REG_CIELO.CIELO_DTA_VENCIMENTO.CIE_ANO_VENCIMENTO, WS_TRABALHO.WS_DT_VENCIMENTO.WS_DT_ANO_VEN);

            /*" -689- MOVE CIE-DIA-CREDITO TO WS-DT-DIA-CRE */
            _.Move(REG_CIELO.CIELO_DTA_CREDITO.CIE_DIA_CREDITO, WS_TRABALHO.WS_DT_CREDITO.WS_DT_DIA_CRE);

            /*" -690- MOVE CIE-MES-CREDITO TO WS-DT-MES-CRE */
            _.Move(REG_CIELO.CIELO_DTA_CREDITO.CIE_MES_CREDITO, WS_TRABALHO.WS_DT_CREDITO.WS_DT_MES_CRE);

            /*" -692- MOVE CIE-ANO-CREDITO TO WS-DT-ANO-CRE */
            _.Move(REG_CIELO.CIELO_DTA_CREDITO.CIE_ANO_CREDITO, WS_TRABALHO.WS_DT_CREDITO.WS_DT_ANO_CRE);

            /*" -693- MOVE CIE-DIA-TARIFA TO WS-DT-DIA-TAR */
            _.Move(REG_CIELO.CIELO_DTA_DEB_TARIFA.CIE_DIA_TARIFA, WS_TRABALHO.WS_DT_TARIFA.WS_DT_DIA_TAR);

            /*" -694- MOVE CIE-MES-TARIFA TO WS-DT-MES-TAR */
            _.Move(REG_CIELO.CIELO_DTA_DEB_TARIFA.CIE_MES_TARIFA, WS_TRABALHO.WS_DT_TARIFA.WS_DT_MES_TAR);

            /*" -696- MOVE CIE-ANO-TARIFA TO WS-DT-ANO-TAR */
            _.Move(REG_CIELO.CIELO_DTA_DEB_TARIFA.CIE_ANO_TARIFA, WS_TRABALHO.WS_DT_TARIFA.WS_DT_ANO_TAR);

            /*" -697- MOVE CIE-DIA-CAPTURA TO WS-DT-DIA-CAP */
            _.Move(REG_CIELO.CIELO_DTA_AJU_CAPTURA.CIE_DIA_CAPTURA, WS_TRABALHO.WS_DT_CAPTURA.WS_DT_DIA_CAP);

            /*" -698- MOVE CIE-MES-CAPTURA TO WS-DT-MES-CAP */
            _.Move(REG_CIELO.CIELO_DTA_AJU_CAPTURA.CIE_MES_CAPTURA, WS_TRABALHO.WS_DT_CAPTURA.WS_DT_MES_CAP);

            /*" -700- MOVE CIE-ANO-CAPTURA TO WS-DT-ANO-CAP */
            _.Move(REG_CIELO.CIELO_DTA_AJU_CAPTURA.CIE_ANO_CAPTURA, WS_TRABALHO.WS_DT_CAPTURA.WS_DT_ANO_CAP);

            /*" -700- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_99_SAIDA*/

        [StopWatch]
        /*" R0400-00-PROCESSA-MOVIMENTO-SECTION */
        private void R0400_00_PROCESSA_MOVIMENTO_SECTION()
        {
            /*" -708- MOVE 'R0400-00-PROCESSA-MOVIMENTO' TO PARAGRAFO */
            _.Move("R0400-00-PROCESSA-MOVIMENTO", WABEND.PARAGRAFO);

            /*" -709- MOVE 'PROCESSO PRINCIPAL' TO COMANDO */
            _.Move("PROCESSO PRINCIPAL", WABEND.COMANDO);

            /*" -710- DISPLAY PARAGRAFO */
            _.Display(WABEND.PARAGRAFO);

            /*" -713- DISPLAY 'CIELO-NUM-PROPOSTA = ' CIELO-NUM-PROPOSTA */
            _.Display($"CIELO-NUM-PROPOSTA = {REG_CIELO.CIELO_NUM_PROPOSTA}");

            /*" -726- PERFORM R0403-00-VERIFICA-PROPOSTA */

            R0403_00_VERIFICA_PROPOSTA_SECTION();

            /*" -727- IF PRODUTOS-VIDA */

            if (LBWPF002.W_PRODUTO["PRODUTOS_VIDA"])
            {

                /*" -732- IF WS-N-GRAVOU-HEADER */

                if (WS_GRAVOU_HEADER["WS_N_GRAVOU_HEADER"])
                {

                    /*" -733- MOVE 902000000 TO WSHOST-NRAVISO1 */
                    _.Move(902000000, WS_TRABALHO.WSHOST_NRAVISO1);

                    /*" -735- MOVE 902099999 TO WSHOST-NRAVISO2 */
                    _.Move(902099999, WS_TRABALHO.WSHOST_NRAVISO2);

                    /*" -736- PERFORM R0405-00-TRATA-NSAC */

                    R0405_00_TRATA_NSAC_SECTION();

                    /*" -737- PERFORM R0408-00-GRAVA-HEADER-CIELO */

                    R0408_00_GRAVA_HEADER_CIELO_SECTION();

                    /*" -738- END-IF */
                }


                /*" -739- ELSE */
            }
            else
            {


                /*" -745- IF FEDERALCAP OR FEDERALCAP-CX-TRAB OR FEDERALCAP-MULTIBENS OR FEDPREV-PGTO-UNICO OR SUPERCOPACAP-EMPRESARIAL OR ATENASCAP OR CAPMAIS OR (W-PRODUTO EQUAL 61 OR 65 OR 68 OR 70 OR 73 OR 89 OR 90 OR 91 OR 92 OR 94 ) */

                if (LBWPF002.W_PRODUTO["FEDERALCAP"] || LBWPF002.W_PRODUTO["FEDERALCAP_CX_TRAB"] || LBWPF002.W_PRODUTO["FEDERALCAP_MULTIBENS"] || LBWPF002.W_PRODUTO["FEDPREV_PGTO_UNICO"] || LBWPF002.W_PRODUTO["SUPERCOPACAP_EMPRESARIAL"] || LBWPF002.W_PRODUTO["ATENASCAP"] || LBWPF002.W_PRODUTO["CAPMAIS"] || (LBWPF002.W_PRODUTO.In("61", "65", "68", "70", "73", "89", "90", "91", "92", "94")))
                {

                    /*" -746- ADD 1 TO WS-DESP-PRODUTO-CAP */
                    WS_CONTADORES.WS_DESP_PRODUTO_CAP.Value = WS_CONTADORES.WS_DESP_PRODUTO_CAP + 1;

                    /*" -747- GO TO R0400-10-LER-PROXIMO */

                    R0400_10_LER_PROXIMO(); //GOTO
                    return;

                    /*" -748- ELSE */
                }
                else
                {


                    /*" -749- ADD 1 TO WS-DESP-PRODUTO */
                    WS_CONTADORES.WS_DESP_PRODUTO.Value = WS_CONTADORES.WS_DESP_PRODUTO + 1;

                    /*" -750- END-IF */
                }


                /*" -752- END-IF */
            }


            /*" -753- MOVE 'N' TO WS-ACHOU-PROPOSTAVA */
            _.Move("N", WS_TRABALHO.WS_ACHOU_PROPOSTAVA);

            /*" -758- PERFORM R0510-00-CONSULTA-PROPOSTASVA */

            R0510_00_CONSULTA_PROPOSTASVA_SECTION();

            /*" -759- MOVE 'N' TO WS-ACHOU-CTRL-CIELO */
            _.Move("N", WS_TRABALHO.WS_ACHOU_CTRL_CIELO);

            /*" -761- PERFORM R0410-00-CONTROLE-CARTAO-CIELO */

            R0410_00_CONTROLE_CARTAO_CIELO_SECTION();

            /*" -763- MOVE SPACES TO WS-TIPO-MOVIMENTO */
            _.Move("", WS_TRABALHO.WS_TIPO_MOVIMENTO);

            /*" -764- IF CIELO-TP-MOVIMENTO EQUAL 'D0' */

            if (REG_CIELO.CIELO_TP_MOVIMENTO == "D0")
            {

                /*" -765- SET WS-MOVTO-ADESAO TO TRUE */
                WS_TRABALHO.WS_TIPO_MOVIMENTO["WS_MOVTO_ADESAO"] = true;

                /*" -766- MOVE 1 TO WS-NUM-PARCELA */
                _.Move(1, WS_TRABALHO.WS_NUM_PARCELA);

                /*" -768- END-IF */
            }


            /*" -770- IF CIELO-TP-MOVIMENTO EQUAL 'D0' AND WS-ACHOU-CTRL-CIELO EQUAL 'N' */

            if (REG_CIELO.CIELO_TP_MOVIMENTO == "D0" && WS_TRABALHO.WS_ACHOU_CTRL_CIELO == "N")
            {

                /*" -771- MOVE CIELO-IDLG TO WS-COD-IDLG-ADESAO */
                _.Move(REG_CIELO.CIELO_IDLG, WS_TRABALHO.WS_COD_IDLG_ADESAO);

                /*" -772- PERFORM R0401-00-VERIFICA-IDLG-ADESAO */

                R0401_00_VERIFICA_IDLG_ADESAO_SECTION();

                /*" -773- MOVE '01' TO WS-TP-PAGAMENTO */
                _.Move("01", WS_TRABALHO.WS_TP_PAGAMENTO);

                /*" -774- ELSE */
            }
            else
            {


                /*" -776- EVALUATE GE407-COD-TP-PAGAMENTO */
                switch (GE407.DCLGE_CONTROLE_CARTAO_CIELO.GE407_COD_TP_PAGAMENTO.Value.Trim())
                {

                    /*" -777- WHEN '01' */
                    case "01":

                        /*" -780- MOVE GE407-COD-TP-PAGAMENTO TO WS-TP-PAGAMENTO */
                        _.Move(GE407.DCLGE_CONTROLE_CARTAO_CIELO.GE407_COD_TP_PAGAMENTO, WS_TRABALHO.WS_TP_PAGAMENTO);

                        /*" -781- WHEN '02' */
                        break;
                    case "02":

                        /*" -782- SET WS-MOVTO-DEMAIS TO TRUE */
                        WS_TRABALHO.WS_TIPO_MOVIMENTO["WS_MOVTO_DEMAIS"] = true;

                        /*" -784- MOVE GE407-COD-TP-PAGAMENTO TO WS-TP-PAGAMENTO */
                        _.Move(GE407.DCLGE_CONTROLE_CARTAO_CIELO.GE407_COD_TP_PAGAMENTO, WS_TRABALHO.WS_TP_PAGAMENTO);

                        /*" -785- MOVE CIELO-IDLG TO WS-COD-IDLG-DEMAIS */
                        _.Move(REG_CIELO.CIELO_IDLG, WS_TRABALHO.WS_COD_IDLG_DEMAIS);

                        /*" -786- MOVE WS-IDLG-CONVENIO TO MOVDEBCE-COD-CONVENIO */
                        _.Move(WS_TRABALHO.FILLER_1.WS_IDLG_CONVENIO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO);

                        /*" -787- MOVE WS-IDLG-NSA TO MOVDEBCE-NSAS */
                        _.Move(WS_TRABALHO.FILLER_1.WS_IDLG_NSA, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NSAS);

                        /*" -789- MOVE WS-IDLG-NRSEQ TO MOVDEBCE-NUM-REQUISICAO MOVDEBCE-NUM-ENDOSSO */
                        _.Move(WS_TRABALHO.FILLER_1.WS_IDLG_NRSEQ, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_REQUISICAO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO);

                        /*" -790- PERFORM R0610-00-VERIFICA-IDLG-DEMAIS */

                        R0610_00_VERIFICA_IDLG_DEMAIS_SECTION();

                        /*" -793- MOVE MOVDEBCE-NUM-PARCELA TO WS-NUM-PARCELA */
                        _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA, WS_TRABALHO.WS_NUM_PARCELA);

                        /*" -794- WHEN '03' */
                        break;
                    case "03":

                    /*" -795- WHEN '04' */
                    case "04":

                        /*" -797- SET WS-MOVTO-DEVOLU TO TRUE */
                        WS_TRABALHO.WS_TIPO_MOVIMENTO["WS_MOVTO_DEVOLU"] = true;

                        /*" -798- MOVE GE407-COD-TP-PAGAMENTO TO WS-TP-PAGAMENTO */
                        _.Move(GE407.DCLGE_CONTROLE_CARTAO_CIELO.GE407_COD_TP_PAGAMENTO, WS_TRABALHO.WS_TP_PAGAMENTO);

                        /*" -799- MOVE CIELO-IDLG TO WS-COD-IDLG-DEMAIS */
                        _.Move(REG_CIELO.CIELO_IDLG, WS_TRABALHO.WS_COD_IDLG_DEMAIS);

                        /*" -800- MOVE WS-IDLG-CONVENIO TO MOVDEBCE-COD-CONVENIO */
                        _.Move(WS_TRABALHO.FILLER_1.WS_IDLG_CONVENIO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO);

                        /*" -801- MOVE WS-IDLG-NSA TO MOVDEBCE-NSAS */
                        _.Move(WS_TRABALHO.FILLER_1.WS_IDLG_NSA, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NSAS);

                        /*" -803- MOVE WS-IDLG-NRSEQ TO MOVDEBCE-NUM-ENDOSSO MOVDEBCE-NUM-REQUISICAO */
                        _.Move(WS_TRABALHO.FILLER_1.WS_IDLG_NRSEQ, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_REQUISICAO);

                        /*" -804- PERFORM R0620-00-VERIFICA-IDLG-DEVOLU */

                        R0620_00_VERIFICA_IDLG_DEVOLU_SECTION();

                        /*" -805- MOVE MOVDEBCE-NUM-PARCELA TO WS-NUM-PARCELA */
                        _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA, WS_TRABALHO.WS_NUM_PARCELA);

                        /*" -806- WHEN OTHER */
                        break;
                    default:

                        /*" -807- DISPLAY 'VERIFICAR, TIPO DE PAGAMENTO NAO IDENTIFICADO' */
                        _.Display($"VERIFICAR, TIPO DE PAGAMENTO NAO IDENTIFICADO");

                        /*" -808- DISPLAY 'COD-TP-PAGAMENTO    = ' GE407-COD-TP-PAGAMENTO */
                        _.Display($"COD-TP-PAGAMENTO    = {GE407.DCLGE_CONTROLE_CARTAO_CIELO.GE407_COD_TP_PAGAMENTO}");

                        /*" -809- DISPLAY 'CIELO-IDLG          = ' CIELO-IDLG */
                        _.Display($"CIELO-IDLG          = {REG_CIELO.CIELO_IDLG}");

                        /*" -810- DISPLAY 'CIELO-COD-MOVIMENTO = ' CIELO-COD-MOVIMENTO */
                        _.Display($"CIELO-COD-MOVIMENTO = {REG_CIELO.CIELO_COD_MOVIMENTO}");

                        /*" -811- DISPLAY 'CIELO-COD-RETORNO   = ' CIELO-COD-RETORNO */
                        _.Display($"CIELO-COD-RETORNO   = {REG_CIELO.CIELO_COD_RETORNO}");

                        /*" -812- GO TO R9999-00-ROT-ERRO */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;

                        /*" -813- END-EVALUATE */
                        break;
                }


                /*" -815- END-IF */
            }


            /*" -816- IF WS-ACHOU-CTRL-CIELO EQUAL 'N' */

            if (WS_TRABALHO.WS_ACHOU_CTRL_CIELO == "N")
            {

                /*" -817- PERFORM R0420-00-GERA-NUM-OCORR-MOVTO */

                R0420_00_GERA_NUM_OCORR_MOVTO_SECTION();

                /*" -821- MOVE WS-HOST-PROX-OCORR TO GE407-NUM-OCORR-MOVTO */
                _.Move(WS_TRABALHO.WS_HOST_PROX_OCORR, GE407.DCLGE_CONTROLE_CARTAO_CIELO.GE407_NUM_OCORR_MOVTO);

                /*" -822- ADD 1 TO GE407-SEQ-CONTROL-CARTAO */
                GE407.DCLGE_CONTROLE_CARTAO_CIELO.GE407_SEQ_CONTROL_CARTAO.Value = GE407.DCLGE_CONTROLE_CARTAO_CIELO.GE407_SEQ_CONTROL_CARTAO + 1;

                /*" -825- END-IF */
            }


            /*" -828- PERFORM R0450-00-MAX-RETORNO-ARQH */

            R0450_00_MAX_RETORNO_ARQH_SECTION();

            /*" -830- PERFORM R0460-00-INS-CONTROLE-ARQH */

            R0460_00_INS_CONTROLE_ARQH_SECTION();

            /*" -831- MOVE 'R0400-00-PROCESSA-MOVIMENTO' TO PARAGRAFO */
            _.Move("R0400-00-PROCESSA-MOVIMENTO", WABEND.PARAGRAFO);

            /*" -832- MOVE 'PROCESSO PRINCIPAL' TO COMANDO */
            _.Move("PROCESSO PRINCIPAL", WABEND.COMANDO);

            /*" -834- DISPLAY PARAGRAFO */
            _.Display(WABEND.PARAGRAFO);

            /*" -835- IF CIELO-PROC-ADVERT EQUAL LOW-VALUES */

            if (REG_CIELO.CIELO_PROC_ADVERT.IsLowValues())
            {

                /*" -836- MOVE SPACES TO CIELO-PROC-ADVERT */
                _.Move("", REG_CIELO.CIELO_PROC_ADVERT);

                /*" -838- END-IF */
            }


            /*" -839- IF CIELO-NIVE-ADVERT EQUAL LOW-VALUES */

            if (REG_CIELO.CIELO_NIVE_ADVERT.IsLowValues())
            {

                /*" -840- MOVE SPACES TO CIELO-NIVE-ADVERT */
                _.Move("", REG_CIELO.CIELO_NIVE_ADVERT);

                /*" -844- END-IF */
            }


            /*" -846- EVALUATE CIELO-COD-MOVIMENTO */
            switch (REG_CIELO.CIELO_COD_MOVIMENTO.Value.Trim())
            {

                /*" -847- WHEN '03' */
                case "03":

                    /*" -849- EVALUATE CIELO-COD-RETORNO */
                    switch (REG_CIELO.CIELO_COD_RETORNO.Value.Trim())
                    {

                        /*" -850- WHEN ' CC' */
                        case " CC":

                            /*" -854- IF PROPOVA-SIT-REGISTRO EQUAL '2' */

                            if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_SIT_REGISTRO == "2")
                            {

                                /*" -855- MOVE 'L' TO GE407-STA-REGISTRO */
                                _.Move("L", GE407.DCLGE_CONTROLE_CARTAO_CIELO.GE407_STA_REGISTRO);

                                /*" -857- ELSE */
                            }
                            else
                            {


                                /*" -858- MOVE 'A' TO GE407-STA-REGISTRO */
                                _.Move("A", GE407.DCLGE_CONTROLE_CARTAO_CIELO.GE407_STA_REGISTRO);

                                /*" -859- END-IF */
                            }


                            /*" -860- IF WS-MOVTO-ADESAO */

                            if (WS_TRABALHO.WS_TIPO_MOVIMENTO["WS_MOVTO_ADESAO"])
                            {

                                /*" -862- MOVE SPACES TO DETAL01-REGISTRO */
                                _.Move("", DETAL01_REGISTRO);

                                /*" -863- PERFORM R0800-00-MONTA-ARQ-SAIDA */

                                R0800_00_MONTA_ARQ_SAIDA_SECTION();

                                /*" -864- WRITE REG-CCADESAO FROM DETAL01-REGISTRO */
                                _.Move(DETAL01_REGISTRO.GetMoveValues(), REG_CCADESAO);

                                CCADESAO.Write(REG_CCADESAO.GetMoveValues().ToString());

                                /*" -866- ADD 1 TO WS-AC-GRAV-ADESAO */
                                WS_CONTADORES.WS_AC_GRAV_ADESAO.Value = WS_CONTADORES.WS_AC_GRAV_ADESAO + 1;

                                /*" -868- ADD CIELO-VLR-COBRANCA TO WS-SOMA-VLR-ADESAO */
                                WS_TRABALHO.WS_SOMA_VLR_ADESAO.Value = WS_TRABALHO.WS_SOMA_VLR_ADESAO + REG_CIELO.CIELO_VLR_COBRANCA;

                                /*" -869- ELSE */
                            }
                            else
                            {


                                /*" -870- MOVE '1' TO MOVDEBCE-SITUACAO-COBRANCA */
                                _.Move("1", MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_SITUACAO_COBRANCA);

                                /*" -873- MOVE SISTEMAS-DATA-MOV-ABERTO TO MOVDEBCE-DATA-RETORNO MOVDEBCE-DATA-MOVIMENTO */
                                _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_RETORNO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_MOVIMENTO);

                                /*" -874- MOVE ZEROS TO MOVDEBCE-COD-RETORNO-CEF */
                                _.Move(0, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_RETORNO_CEF);

                                /*" -875- MOVE 'EM8024B' TO MOVDEBCE-COD-USUARIO */
                                _.Move("EM8024B", MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_USUARIO);

                                /*" -876- MOVE WS-DT-CREDITO TO MOVDEBCE-DTCREDITO */
                                _.Move(WS_TRABALHO.WS_DT_CREDITO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DTCREDITO);

                                /*" -879- MOVE ZEROS TO VIND-DTCREDITO */
                                _.Move(0, VIND_DTCREDITO);

                                /*" -881- PERFORM R0710-00-ATUALIZA-MOVDEBCE */

                                R0710_00_ATUALIZA_MOVDEBCE_SECTION();

                                /*" -883- MOVE SPACES TO DETAL01-REGISTRO */
                                _.Move("", DETAL01_REGISTRO);

                                /*" -884- PERFORM R0800-00-MONTA-ARQ-SAIDA */

                                R0800_00_MONTA_ARQ_SAIDA_SECTION();

                                /*" -885- WRITE REG-CCDEMAIS FROM DETAL01-REGISTRO */
                                _.Move(DETAL01_REGISTRO.GetMoveValues(), REG_CCDEMAIS);

                                CCDEMAIS.Write(REG_CCDEMAIS.GetMoveValues().ToString());

                                /*" -886- ADD 1 TO WS-AC-GRAV-DEMAIS */
                                WS_CONTADORES.WS_AC_GRAV_DEMAIS.Value = WS_CONTADORES.WS_AC_GRAV_DEMAIS + 1;

                                /*" -887- ADD CIELO-VLR-COBRANCA TO WS-SOMA-VLR-DEMAIS */
                                WS_TRABALHO.WS_SOMA_VLR_DEMAIS.Value = WS_TRABALHO.WS_SOMA_VLR_DEMAIS + REG_CIELO.CIELO_VLR_COBRANCA;

                                /*" -888- END-IF */
                            }


                            /*" -889- WHEN OTHER */
                            break;
                        default:

                            /*" -890- DISPLAY 'VERIFICAR, CONFIRMACAO DE CAPTURA COM ERRO.' */
                            _.Display($"VERIFICAR, CONFIRMACAO DE CAPTURA COM ERRO.");

                            /*" -891- DISPLAY 'CIELO-COD-MOVIMENTO = ' CIELO-COD-MOVIMENTO */
                            _.Display($"CIELO-COD-MOVIMENTO = {REG_CIELO.CIELO_COD_MOVIMENTO}");

                            /*" -892- DISPLAY 'CIELO-COD-RETORNO   = ' CIELO-COD-RETORNO */
                            _.Display($"CIELO-COD-RETORNO   = {REG_CIELO.CIELO_COD_RETORNO}");

                            /*" -893- DISPLAY 'CIELO-IDLG          = ' CIELO-IDLG */
                            _.Display($"CIELO-IDLG          = {REG_CIELO.CIELO_IDLG}");

                            /*" -894- GO TO R9999-00-ROT-ERRO */

                            R9999_00_ROT_ERRO_SECTION(); //GOTO
                            return;

                            /*" -896- END-EVALUATE */
                            break;
                    }


                    /*" -897- WHEN '04' */
                    break;
                case "04":

                    /*" -899- EVALUATE CIELO-COD-RETORNO */
                    switch (REG_CIELO.CIELO_COD_RETORNO.Value.Trim())
                    {

                        /*" -900- WHEN ' 00' */
                        case " 00":

                            /*" -901- IF WS-MOVTO-ADESAO OR WS-MOVTO-DEMAIS */

                            if (WS_TRABALHO.WS_TIPO_MOVIMENTO["WS_MOVTO_ADESAO"] || WS_TRABALHO.WS_TIPO_MOVIMENTO["WS_MOVTO_DEMAIS"])
                            {

                                /*" -903- IF PROPOVA-SIT-REGISTRO EQUAL '2' */

                                if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_SIT_REGISTRO == "2")
                                {

                                    /*" -904- MOVE 'L' TO GE407-STA-REGISTRO */
                                    _.Move("L", GE407.DCLGE_CONTROLE_CARTAO_CIELO.GE407_STA_REGISTRO);

                                    /*" -906- ELSE */
                                }
                                else
                                {


                                    /*" -907- MOVE 'P' TO GE407-STA-REGISTRO */
                                    _.Move("P", GE407.DCLGE_CONTROLE_CARTAO_CIELO.GE407_STA_REGISTRO);

                                    /*" -908- END-IF */
                                }


                                /*" -910- ELSE */
                            }
                            else
                            {


                                /*" -911- MOVE 'G' TO GE407-STA-REGISTRO */
                                _.Move("G", GE407.DCLGE_CONTROLE_CARTAO_CIELO.GE407_STA_REGISTRO);

                                /*" -912- END-IF */
                            }


                            /*" -913- IF WS-MOVTO-ADESAO */

                            if (WS_TRABALHO.WS_TIPO_MOVIMENTO["WS_MOVTO_ADESAO"])
                            {

                                /*" -915- MOVE SPACES TO DETAL01-REGISTRO */
                                _.Move("", DETAL01_REGISTRO);

                                /*" -916- PERFORM R0800-00-MONTA-ARQ-SAIDA */

                                R0800_00_MONTA_ARQ_SAIDA_SECTION();

                                /*" -917- WRITE REG-CCADESAO FROM DETAL01-REGISTRO */
                                _.Move(DETAL01_REGISTRO.GetMoveValues(), REG_CCADESAO);

                                CCADESAO.Write(REG_CCADESAO.GetMoveValues().ToString());

                                /*" -918- ADD 1 TO WS-AC-GRAV-ADESAO */
                                WS_CONTADORES.WS_AC_GRAV_ADESAO.Value = WS_CONTADORES.WS_AC_GRAV_ADESAO + 1;

                                /*" -919- ADD CIELO-VLR-COBRANCA TO WS-SOMA-VLR-ADESAO */
                                WS_TRABALHO.WS_SOMA_VLR_ADESAO.Value = WS_TRABALHO.WS_SOMA_VLR_ADESAO + REG_CIELO.CIELO_VLR_COBRANCA;

                                /*" -920- ELSE */
                            }
                            else
                            {


                                /*" -921- MOVE '2' TO MOVDEBCE-SITUACAO-COBRANCA */
                                _.Move("2", MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_SITUACAO_COBRANCA);

                                /*" -924- MOVE SISTEMAS-DATA-MOV-ABERTO TO MOVDEBCE-DATA-RETORNO MOVDEBCE-DATA-MOVIMENTO */
                                _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_RETORNO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_MOVIMENTO);

                                /*" -925- MOVE ZEROS TO MOVDEBCE-COD-RETORNO-CEF */
                                _.Move(0, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_RETORNO_CEF);

                                /*" -928- MOVE 'EM8024B' TO MOVDEBCE-COD-USUARIO */
                                _.Move("EM8024B", MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_USUARIO);

                                /*" -930- PERFORM R0710-00-ATUALIZA-MOVDEBCE */

                                R0710_00_ATUALIZA_MOVDEBCE_SECTION();

                                /*" -932- MOVE SPACES TO DETAL01-REGISTRO */
                                _.Move("", DETAL01_REGISTRO);

                                /*" -933- PERFORM R0800-00-MONTA-ARQ-SAIDA */

                                R0800_00_MONTA_ARQ_SAIDA_SECTION();

                                /*" -934- WRITE REG-CCDEMAIS FROM DETAL01-REGISTRO */
                                _.Move(DETAL01_REGISTRO.GetMoveValues(), REG_CCDEMAIS);

                                CCDEMAIS.Write(REG_CCDEMAIS.GetMoveValues().ToString());

                                /*" -935- ADD 1 TO WS-AC-GRAV-DEMAIS */
                                WS_CONTADORES.WS_AC_GRAV_DEMAIS.Value = WS_CONTADORES.WS_AC_GRAV_DEMAIS + 1;

                                /*" -936- ADD CIELO-VLR-COBRANCA TO WS-SOMA-VLR-DEMAIS */
                                WS_TRABALHO.WS_SOMA_VLR_DEMAIS.Value = WS_TRABALHO.WS_SOMA_VLR_DEMAIS + REG_CIELO.CIELO_VLR_COBRANCA;

                                /*" -938- END-IF */
                            }


                            /*" -939- WHEN ' 17' */
                            break;
                        case " 17":

                            /*" -941- IF WS-MOVTO-DEVOLU OR WS-MOVTO-RESTIT */

                            if (WS_TRABALHO.WS_TIPO_MOVIMENTO["WS_MOVTO_DEVOLU"] || WS_TRABALHO.WS_TIPO_MOVIMENTO["WS_MOVTO_RESTIT"])
                            {

                                /*" -942- MOVE 'G' TO GE407-STA-REGISTRO */
                                _.Move("G", GE407.DCLGE_CONTROLE_CARTAO_CIELO.GE407_STA_REGISTRO);

                                /*" -943- MOVE '2' TO MOVDEBCE-SITUACAO-COBRANCA */
                                _.Move("2", MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_SITUACAO_COBRANCA);

                                /*" -946- MOVE SISTEMAS-DATA-MOV-ABERTO TO MOVDEBCE-DATA-RETORNO MOVDEBCE-DATA-MOVIMENTO */
                                _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_RETORNO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_MOVIMENTO);

                                /*" -947- MOVE ZEROS TO MOVDEBCE-COD-RETORNO-CEF */
                                _.Move(0, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_RETORNO_CEF);

                                /*" -950- MOVE 'EM8024B' TO MOVDEBCE-COD-USUARIO */
                                _.Move("EM8024B", MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_USUARIO);

                                /*" -952- PERFORM R0710-00-ATUALIZA-MOVDEBCE */

                                R0710_00_ATUALIZA_MOVDEBCE_SECTION();

                                /*" -954- MOVE SPACES TO DETAL01-REGISTRO */
                                _.Move("", DETAL01_REGISTRO);

                                /*" -955- PERFORM R0800-00-MONTA-ARQ-SAIDA */

                                R0800_00_MONTA_ARQ_SAIDA_SECTION();

                                /*" -956- WRITE REG-CCDEMAIS FROM DETAL01-REGISTRO */
                                _.Move(DETAL01_REGISTRO.GetMoveValues(), REG_CCDEMAIS);

                                CCDEMAIS.Write(REG_CCDEMAIS.GetMoveValues().ToString());

                                /*" -957- ADD 1 TO WS-AC-GRAV-DEMAIS */
                                WS_CONTADORES.WS_AC_GRAV_DEMAIS.Value = WS_CONTADORES.WS_AC_GRAV_DEMAIS + 1;

                                /*" -958- ADD CIELO-VLR-COBRANCA TO WS-SOMA-VLR-DEMAIS */
                                WS_TRABALHO.WS_SOMA_VLR_DEMAIS.Value = WS_TRABALHO.WS_SOMA_VLR_DEMAIS + REG_CIELO.CIELO_VLR_COBRANCA;

                                /*" -961- ELSE */
                            }
                            else
                            {


                                /*" -963- DISPLAY 'CODIGO DE ERRO RETORNADO PARA CASO QUE NAO '' E DEVOLUCAO/RESTITUICAO, VERIFICAR' */
                                _.Display($"CODIGO DE ERRO RETORNADO PARA CASO QUE NAO  E DEVOLUCAO/RESTITUICAO, VERIFICAR");

                                /*" -964- DISPLAY 'CIELO-IDLG         = ' CIELO-IDLG */
                                _.Display($"CIELO-IDLG         = {REG_CIELO.CIELO_IDLG}");

                                /*" -965- DISPLAY 'NUM-TITULO         = ' MOVDEBCE-NUM-APOLICE */
                                _.Display($"NUM-TITULO         = {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE}");

                                /*" -966- DISPLAY 'CIELO-COD-MOVIMENTO= ' CIELO-COD-MOVIMENTO */
                                _.Display($"CIELO-COD-MOVIMENTO= {REG_CIELO.CIELO_COD_MOVIMENTO}");

                                /*" -967- DISPLAY 'CIELO-COD-RETORNO  = ' CIELO-COD-RETORNO */
                                _.Display($"CIELO-COD-RETORNO  = {REG_CIELO.CIELO_COD_RETORNO}");

                                /*" -968- GO TO R9999-00-ROT-ERRO */

                                R9999_00_ROT_ERRO_SECTION(); //GOTO
                                return;

                                /*" -989- END-IF. */
                            }


                            /*" -990- WHEN ' 28' */
                            break;
                        case " 28":

                        /*" -991- WHEN ' 29' */
                        case " 29":

                            /*" -992- WHEN ' 30' */
                            break;
                        case " 30":

                        /*" -993- WHEN ' 31' */
                        case " 31":

                            /*" -994- WHEN ' 32' */
                            break;
                        case " 32":

                        /*" -995- WHEN ' 33' */
                        case " 33":

                            /*" -996- WHEN ' 34' */
                            break;
                        case " 34":

                        /*" -997- WHEN ' 35' */
                        case " 35":

                            /*" -998- WHEN ' 36' */
                            break;
                        case " 36":

                        /*" -999- WHEN ' 37' */
                        case " 37":

                            /*" -1000- WHEN ' 38' */
                            break;
                        case " 38":

                        /*" -1001- WHEN ' 39' */
                        case " 39":

                            /*" -1002- WHEN ' 40' */
                            break;
                        case " 40":

                        /*" -1003- WHEN ' 52' */
                        case " 52":

                            /*" -1004- WHEN ' 53' */
                            break;
                        case " 53":

                        /*" -1005- WHEN ' 54' */
                        case " 54":

                            /*" -1006- WHEN ' 55' */
                            break;
                        case " 55":

                        /*" -1007- WHEN ' 56' */
                        case " 56":

                            /*" -1008- WHEN ' 57' */
                            break;
                        case " 57":

                        /*" -1009- WHEN ' 58' */
                        case " 58":

                            /*" -1010- WHEN ' 59' */
                            break;
                        case " 59":

                        /*" -1011- WHEN ' 60' */
                        case " 60":

                            /*" -1012- WHEN ' 61' */
                            break;
                        case " 61":

                        /*" -1013- WHEN ' 62' */
                        case " 62":

                            /*" -1014- WHEN ' 63' */
                            break;
                        case " 63":

                        /*" -1015- WHEN ' 64' */
                        case " 64":

                            /*" -1016- WHEN ' 65' */
                            break;
                        case " 65":

                        /*" -1017- WHEN ' 66' */
                        case " 66":

                            /*" -1018- WHEN ' 67' */
                            break;
                        case " 67":

                        /*" -1019- WHEN ' 68' */
                        case " 68":

                            /*" -1020- WHEN ' 69' */
                            break;
                        case " 69":

                        /*" -1021- WHEN ' 70' */
                        case " 70":

                            /*" -1022- WHEN ' 71' */
                            break;
                        case " 71":

                        /*" -1023- WHEN ' 72' */
                        case " 72":

                            /*" -1024- WHEN ' 73' */
                            break;
                        case " 73":

                        /*" -1025- WHEN ' 74' */
                        case " 74":

                            /*" -1026- WHEN ' 75' */
                            break;
                        case " 75":

                        /*" -1030- WHEN ' 76' */
                        case " 76":

                            /*" -1031- IF GE407-COD-TP-PAGAMENTO EQUAL '02' */

                            if (GE407.DCLGE_CONTROLE_CARTAO_CIELO.GE407_COD_TP_PAGAMENTO == "02")
                            {

                                /*" -1032- MOVE '6' TO MOVDEBCE-SITUACAO-COBRANCA */
                                _.Move("6", MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_SITUACAO_COBRANCA);

                                /*" -1035- MOVE SISTEMAS-DATA-MOV-ABERTO TO MOVDEBCE-DATA-RETORNO MOVDEBCE-DATA-MOVIMENTO */
                                _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_RETORNO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_MOVIMENTO);

                                /*" -1036- MOVE 8888 TO MOVDEBCE-COD-RETORNO-CEF */
                                _.Move(8888, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_RETORNO_CEF);

                                /*" -1038- MOVE 'EM8024B' TO MOVDEBCE-COD-USUARIO */
                                _.Move("EM8024B", MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_USUARIO);

                                /*" -1039- PERFORM R0710-00-ATUALIZA-MOVDEBCE */

                                R0710_00_ATUALIZA_MOVDEBCE_SECTION();

                                /*" -1042- END-IF */
                            }


                            /*" -1043- MOVE 'E' TO GE407-STA-REGISTRO */
                            _.Move("E", GE407.DCLGE_CONTROLE_CARTAO_CIELO.GE407_STA_REGISTRO);

                            /*" -1045- MOVE SPACES TO DETAL01-REGISTRO */
                            _.Move("", DETAL01_REGISTRO);

                            /*" -1046- PERFORM R0800-00-MONTA-ARQ-SAIDA */

                            R0800_00_MONTA_ARQ_SAIDA_SECTION();

                            /*" -1047- WRITE REG-CCDEMAIS FROM DETAL01-REGISTRO */
                            _.Move(DETAL01_REGISTRO.GetMoveValues(), REG_CCDEMAIS);

                            CCDEMAIS.Write(REG_CCDEMAIS.GetMoveValues().ToString());

                            /*" -1048- ADD 1 TO WS-AC-GRAV-DEMAIS */
                            WS_CONTADORES.WS_AC_GRAV_DEMAIS.Value = WS_CONTADORES.WS_AC_GRAV_DEMAIS + 1;

                            /*" -1050- ADD CIELO-VLR-COBRANCA TO WS-SOMA-VLR-DEMAIS */
                            WS_TRABALHO.WS_SOMA_VLR_DEMAIS.Value = WS_TRABALHO.WS_SOMA_VLR_DEMAIS + REG_CIELO.CIELO_VLR_COBRANCA;

                            /*" -1051- ADD 1 TO WS-DESP-CHARGEBACK */
                            WS_CONTADORES.WS_DESP_CHARGEBACK.Value = WS_CONTADORES.WS_DESP_CHARGEBACK + 1;

                            /*" -1052- WHEN OTHER */
                            break;
                        default:

                            /*" -1053- DISPLAY 'VERIFICAR, MOVIMENTO FINANCEIRO COM ERRO.' */
                            _.Display($"VERIFICAR, MOVIMENTO FINANCEIRO COM ERRO.");

                            /*" -1054- DISPLAY 'CIELO-COD-MOVIMENTO = ' CIELO-COD-MOVIMENTO */
                            _.Display($"CIELO-COD-MOVIMENTO = {REG_CIELO.CIELO_COD_MOVIMENTO}");

                            /*" -1055- DISPLAY 'CIELO-COD-RETORNO   = ' CIELO-COD-RETORNO */
                            _.Display($"CIELO-COD-RETORNO   = {REG_CIELO.CIELO_COD_RETORNO}");

                            /*" -1056- DISPLAY 'CIELO-IDLG          = ' CIELO-IDLG */
                            _.Display($"CIELO-IDLG          = {REG_CIELO.CIELO_IDLG}");

                            /*" -1057- GO TO R9999-00-ROT-ERRO */

                            R9999_00_ROT_ERRO_SECTION(); //GOTO
                            return;

                            /*" -1060- END-EVALUATE */
                            break;
                    }


                    /*" -1062- WHEN 'CI' */
                    break;
                case "CI":

                    /*" -1064- MOVE 'M' TO GE407-STA-REGISTRO */
                    _.Move("M", GE407.DCLGE_CONTROLE_CARTAO_CIELO.GE407_STA_REGISTRO);

                    /*" -1066- MOVE SPACES TO DETAL01-REGISTRO */
                    _.Move("", DETAL01_REGISTRO);

                    /*" -1067- PERFORM R0800-00-MONTA-ARQ-SAIDA */

                    R0800_00_MONTA_ARQ_SAIDA_SECTION();

                    /*" -1068- WRITE REG-CCDEMAIS FROM DETAL01-REGISTRO */
                    _.Move(DETAL01_REGISTRO.GetMoveValues(), REG_CCDEMAIS);

                    CCDEMAIS.Write(REG_CCDEMAIS.GetMoveValues().ToString());

                    /*" -1069- ADD 1 TO WS-AC-GRAV-DEMAIS */
                    WS_CONTADORES.WS_AC_GRAV_DEMAIS.Value = WS_CONTADORES.WS_AC_GRAV_DEMAIS + 1;

                    /*" -1072- ADD CIELO-VLR-COBRANCA TO WS-SOMA-VLR-DEMAIS */
                    WS_TRABALHO.WS_SOMA_VLR_DEMAIS.Value = WS_TRABALHO.WS_SOMA_VLR_DEMAIS + REG_CIELO.CIELO_VLR_COBRANCA;

                    /*" -1073- MOVE '3' TO MOVDEBCE-SITUACAO-COBRANCA */
                    _.Move("3", MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_SITUACAO_COBRANCA);

                    /*" -1076- PERFORM R0700-00-ATUALIZA-INADIMPLENTE */

                    R0700_00_ATUALIZA_INADIMPLENTE_SECTION();

                    /*" -1078- WHEN 'RC' */
                    break;
                case "RC":

                    /*" -1080- MOVE 'I' TO GE407-STA-REGISTRO */
                    _.Move("I", GE407.DCLGE_CONTROLE_CARTAO_CIELO.GE407_STA_REGISTRO);

                    /*" -1082- MOVE SPACES TO DETAL01-REGISTRO */
                    _.Move("", DETAL01_REGISTRO);

                    /*" -1083- PERFORM R0800-00-MONTA-ARQ-SAIDA */

                    R0800_00_MONTA_ARQ_SAIDA_SECTION();

                    /*" -1084- WRITE REG-CCDEMAIS FROM DETAL01-REGISTRO */
                    _.Move(DETAL01_REGISTRO.GetMoveValues(), REG_CCDEMAIS);

                    CCDEMAIS.Write(REG_CCDEMAIS.GetMoveValues().ToString());

                    /*" -1085- ADD 1 TO WS-AC-GRAV-DEMAIS */
                    WS_CONTADORES.WS_AC_GRAV_DEMAIS.Value = WS_CONTADORES.WS_AC_GRAV_DEMAIS + 1;

                    /*" -1087- ADD CIELO-VLR-COBRANCA TO WS-SOMA-VLR-DEMAIS */
                    WS_TRABALHO.WS_SOMA_VLR_DEMAIS.Value = WS_TRABALHO.WS_SOMA_VLR_DEMAIS + REG_CIELO.CIELO_VLR_COBRANCA;

                    /*" -1089- IF CIELO-MOTIVO-COMPENSACAO EQUAL 05 */

                    if (REG_CIELO.CIELO_MOTIVO_COMPENSACAO == 05)
                    {

                        /*" -1090- MOVE '3' TO MOVDEBCE-SITUACAO-COBRANCA */
                        _.Move("3", MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_SITUACAO_COBRANCA);

                        /*" -1091- PERFORM R0700-00-ATUALIZA-INADIMPLENTE */

                        R0700_00_ATUALIZA_INADIMPLENTE_SECTION();

                        /*" -1093- ELSE */
                    }
                    else
                    {


                        /*" -1094- MOVE 'R' TO MOVDEBCE-SITUACAO-COBRANCA */
                        _.Move("R", MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_SITUACAO_COBRANCA);

                        /*" -1095- PERFORM R0700-00-ATUALIZA-INADIMPLENTE */

                        R0700_00_ATUALIZA_INADIMPLENTE_SECTION();

                        /*" -1098- END-IF */
                    }


                    /*" -1099- WHEN 'PA' */
                    break;
                case "PA":

                    /*" -1100- EVALUATE CIELO-COD-RETORNO */
                    switch (REG_CIELO.CIELO_COD_RETORNO.Value.Trim())
                    {

                        /*" -1102- WHEN ' 17' */
                        case " 17":

                            /*" -1104- MOVE 'F' TO GE407-STA-REGISTRO */
                            _.Move("F", GE407.DCLGE_CONTROLE_CARTAO_CIELO.GE407_STA_REGISTRO);

                            /*" -1106- IF WS-MOVTO-ADESAO AND WS-ACHOU-PROPOSTAVA EQUAL 'N' */

                            if (WS_TRABALHO.WS_TIPO_MOVIMENTO["WS_MOVTO_ADESAO"] && WS_TRABALHO.WS_ACHOU_PROPOSTAVA == "N")
                            {

                                /*" -1107- ADD 1 TO WS-CANCEL-VENDA */
                                WS_CONTADORES.WS_CANCEL_VENDA.Value = WS_CONTADORES.WS_CANCEL_VENDA + 1;

                                /*" -1108- ELSE */
                            }
                            else
                            {


                                /*" -1110- MOVE SPACES TO DETAL01-REGISTRO */
                                _.Move("", DETAL01_REGISTRO);

                                /*" -1111- PERFORM R0800-00-MONTA-ARQ-SAIDA */

                                R0800_00_MONTA_ARQ_SAIDA_SECTION();

                                /*" -1112- WRITE REG-CCDEMAIS FROM DETAL01-REGISTRO */
                                _.Move(DETAL01_REGISTRO.GetMoveValues(), REG_CCDEMAIS);

                                CCDEMAIS.Write(REG_CCDEMAIS.GetMoveValues().ToString());

                                /*" -1113- ADD 1 TO WS-AC-GRAV-DEMAIS */
                                WS_CONTADORES.WS_AC_GRAV_DEMAIS.Value = WS_CONTADORES.WS_AC_GRAV_DEMAIS + 1;

                                /*" -1114- ADD CIELO-VLR-COBRANCA TO WS-SOMA-VLR-DEMAIS */
                                WS_TRABALHO.WS_SOMA_VLR_DEMAIS.Value = WS_TRABALHO.WS_SOMA_VLR_DEMAIS + REG_CIELO.CIELO_VLR_COBRANCA;

                                /*" -1116- END-IF */
                            }


                            /*" -1117- WHEN ' 28' */
                            break;
                        case " 28":

                        /*" -1118- WHEN ' 29' */
                        case " 29":

                            /*" -1119- WHEN ' 30' */
                            break;
                        case " 30":

                        /*" -1120- WHEN ' 31' */
                        case " 31":

                            /*" -1121- WHEN ' 32' */
                            break;
                        case " 32":

                        /*" -1122- WHEN ' 33' */
                        case " 33":

                            /*" -1123- WHEN ' 34' */
                            break;
                        case " 34":

                        /*" -1124- WHEN ' 35' */
                        case " 35":

                            /*" -1125- WHEN ' 36' */
                            break;
                        case " 36":

                        /*" -1126- WHEN ' 37' */
                        case " 37":

                            /*" -1127- WHEN ' 38' */
                            break;
                        case " 38":

                        /*" -1128- WHEN ' 39' */
                        case " 39":

                            /*" -1129- WHEN ' 40' */
                            break;
                        case " 40":

                        /*" -1130- WHEN ' 52' */
                        case " 52":

                            /*" -1131- WHEN ' 53' */
                            break;
                        case " 53":

                        /*" -1132- WHEN ' 54' */
                        case " 54":

                            /*" -1133- WHEN ' 55' */
                            break;
                        case " 55":

                        /*" -1134- WHEN ' 56' */
                        case " 56":

                            /*" -1135- WHEN ' 57' */
                            break;
                        case " 57":

                        /*" -1136- WHEN ' 58' */
                        case " 58":

                            /*" -1137- WHEN ' 59' */
                            break;
                        case " 59":

                        /*" -1138- WHEN ' 60' */
                        case " 60":

                            /*" -1139- WHEN ' 61' */
                            break;
                        case " 61":

                        /*" -1140- WHEN ' 62' */
                        case " 62":

                            /*" -1141- WHEN ' 63' */
                            break;
                        case " 63":

                        /*" -1142- WHEN ' 64' */
                        case " 64":

                            /*" -1143- WHEN ' 65' */
                            break;
                        case " 65":

                        /*" -1144- WHEN ' 66' */
                        case " 66":

                            /*" -1145- WHEN ' 67' */
                            break;
                        case " 67":

                        /*" -1146- WHEN ' 68' */
                        case " 68":

                            /*" -1147- WHEN ' 69' */
                            break;
                        case " 69":

                        /*" -1148- WHEN ' 70' */
                        case " 70":

                            /*" -1149- WHEN ' 71' */
                            break;
                        case " 71":

                        /*" -1150- WHEN ' 72' */
                        case " 72":

                            /*" -1151- WHEN ' 73' */
                            break;
                        case " 73":

                        /*" -1152- WHEN ' 74' */
                        case " 74":

                            /*" -1153- WHEN ' 75' */
                            break;
                        case " 75":

                        /*" -1156- WHEN ' 76' */
                        case " 76":

                            /*" -1157- IF GE407-COD-TP-PAGAMENTO EQUAL '02' */

                            if (GE407.DCLGE_CONTROLE_CARTAO_CIELO.GE407_COD_TP_PAGAMENTO == "02")
                            {

                                /*" -1158- MOVE '6' TO MOVDEBCE-SITUACAO-COBRANCA */
                                _.Move("6", MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_SITUACAO_COBRANCA);

                                /*" -1161- MOVE SISTEMAS-DATA-MOV-ABERTO TO MOVDEBCE-DATA-RETORNO MOVDEBCE-DATA-MOVIMENTO */
                                _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_RETORNO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_MOVIMENTO);

                                /*" -1162- MOVE 8888 TO MOVDEBCE-COD-RETORNO-CEF */
                                _.Move(8888, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_RETORNO_CEF);

                                /*" -1164- MOVE 'EM8024B' TO MOVDEBCE-COD-USUARIO */
                                _.Move("EM8024B", MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_USUARIO);

                                /*" -1165- PERFORM R0710-00-ATUALIZA-MOVDEBCE */

                                R0710_00_ATUALIZA_MOVDEBCE_SECTION();

                                /*" -1167- END-IF */
                            }


                            /*" -1170- MOVE 'C' TO GE407-STA-REGISTRO */
                            _.Move("C", GE407.DCLGE_CONTROLE_CARTAO_CIELO.GE407_STA_REGISTRO);

                            /*" -1172- PERFORM R0710-00-ATUALIZA-MOVDEBCE */

                            R0710_00_ATUALIZA_MOVDEBCE_SECTION();

                            /*" -1174- MOVE SPACES TO DETAL01-REGISTRO */
                            _.Move("", DETAL01_REGISTRO);

                            /*" -1175- PERFORM R0800-00-MONTA-ARQ-SAIDA */

                            R0800_00_MONTA_ARQ_SAIDA_SECTION();

                            /*" -1176- WRITE REG-CCDEMAIS FROM DETAL01-REGISTRO */
                            _.Move(DETAL01_REGISTRO.GetMoveValues(), REG_CCDEMAIS);

                            CCDEMAIS.Write(REG_CCDEMAIS.GetMoveValues().ToString());

                            /*" -1177- ADD 1 TO WS-AC-GRAV-DEMAIS */
                            WS_CONTADORES.WS_AC_GRAV_DEMAIS.Value = WS_CONTADORES.WS_AC_GRAV_DEMAIS + 1;

                            /*" -1179- ADD CIELO-VLR-COBRANCA TO WS-SOMA-VLR-DEMAIS */
                            WS_TRABALHO.WS_SOMA_VLR_DEMAIS.Value = WS_TRABALHO.WS_SOMA_VLR_DEMAIS + REG_CIELO.CIELO_VLR_COBRANCA;

                            /*" -1180- ADD 1 TO WS-DESP-CHARGEBACK */
                            WS_CONTADORES.WS_DESP_CHARGEBACK.Value = WS_CONTADORES.WS_DESP_CHARGEBACK + 1;

                            /*" -1181- WHEN OTHER */
                            break;
                        default:

                            /*" -1182- DISPLAY 'VERIFICAR, PROVISAO DE AJUSTE SOLICITADA.' */
                            _.Display($"VERIFICAR, PROVISAO DE AJUSTE SOLICITADA.");

                            /*" -1184- DISPLAY 'DEFINIR REGRA COM A BU DE COMO O SIAS IRA SE ' 'COMPORTAR NESTE CENARIO.' */
                            _.Display($"DEFINIR REGRA COM A BU DE COMO O SIAS IRA SE COMPORTAR NESTE CENARIO.");

                            /*" -1185- DISPLAY 'WS-COD-IDLG-DEMAIS  = ' WS-COD-IDLG-DEMAIS */
                            _.Display($"WS-COD-IDLG-DEMAIS  = {WS_TRABALHO.WS_COD_IDLG_DEMAIS}");

                            /*" -1186- DISPLAY 'NUM-TITULO          = ' MOVDEBCE-NUM-APOLICE */
                            _.Display($"NUM-TITULO          = {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE}");

                            /*" -1187- DISPLAY 'CIELO-COD-MOVIMENTO = ' CIELO-COD-MOVIMENTO */
                            _.Display($"CIELO-COD-MOVIMENTO = {REG_CIELO.CIELO_COD_MOVIMENTO}");

                            /*" -1188- DISPLAY 'CIELO-COD-RETORNO   = ' CIELO-COD-RETORNO */
                            _.Display($"CIELO-COD-RETORNO   = {REG_CIELO.CIELO_COD_RETORNO}");

                            /*" -1189- GO TO R9999-00-ROT-ERRO */

                            R9999_00_ROT_ERRO_SECTION(); //GOTO
                            return;

                            /*" -1191- END-EVALUATE */
                            break;
                    }


                    /*" -1192- WHEN OTHER */
                    break;
                default:

                    /*" -1193- DISPLAY 'MOVIMENTO NAO ESPERADO ATE O MOMENTO.' */
                    _.Display($"MOVIMENTO NAO ESPERADO ATE O MOMENTO.");

                    /*" -1194- DISPLAY 'CIELO-COD-MOVIMENTO = ' CIELO-COD-MOVIMENTO */
                    _.Display($"CIELO-COD-MOVIMENTO = {REG_CIELO.CIELO_COD_MOVIMENTO}");

                    /*" -1195- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1197- END-EVALUATE */
                    break;
            }


            /*" -1198- IF WS-ACHOU-CTRL-CIELO EQUAL 'N' */

            if (WS_TRABALHO.WS_ACHOU_CTRL_CIELO == "N")
            {

                /*" -1201- PERFORM R0500-00-INSERE-CONTROLE-CIELO */

                R0500_00_INSERE_CONTROLE_CIELO_SECTION();

                /*" -1203- MOVE 1 TO WS-HOST-PROX-SEQ-HIST */
                _.Move(1, WS_TRABALHO.WS_HOST_PROX_SEQ_HIST);

                /*" -1204- PERFORM R0550-00-INS-RETORNO-CA-CIELO */

                R0550_00_INS_RETORNO_CA_CIELO_SECTION();

                /*" -1205- ELSE */
            }
            else
            {


                /*" -1206- PERFORM R0470-00-MAX-HIS-RET-CA-CIELO */

                R0470_00_MAX_HIS_RET_CA_CIELO_SECTION();

                /*" -1207- PERFORM R0550-00-INS-RETORNO-CA-CIELO */

                R0550_00_INS_RETORNO_CA_CIELO_SECTION();

                /*" -1208- PERFORM R0520-00-UPDATE-CONTROLE-CIELO */

                R0520_00_UPDATE_CONTROLE_CIELO_SECTION();

                /*" -1208- END-IF. */
            }


            /*" -0- FLUXCONTROL_PERFORM R0400_10_LER_PROXIMO */

            R0400_10_LER_PROXIMO();

        }

        [StopWatch]
        /*" R0400-10-LER-PROXIMO */
        private void R0400_10_LER_PROXIMO(bool isPerform = false)
        {
            /*" -1212- PERFORM R0200-00-LER-MOVIMENTO. */

            R0200_00_LER_MOVIMENTO_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0400_99_SAIDA*/

        [StopWatch]
        /*" R0401-00-VERIFICA-IDLG-ADESAO-SECTION */
        private void R0401_00_VERIFICA_IDLG_ADESAO_SECTION()
        {
            /*" -1220- MOVE 'R0401-00-VERIFICA-IDLG-ADESAO' TO PARAGRAFO */
            _.Move("R0401-00-VERIFICA-IDLG-ADESAO", WABEND.PARAGRAFO);

            /*" -1221- MOVE 'VALIDA IDLG DE ADESAO' TO COMANDO */
            _.Move("VALIDA IDLG DE ADESAO", WABEND.COMANDO);

            /*" -1224- DISPLAY PARAGRAFO */
            _.Display(WABEND.PARAGRAFO);

            /*" -1226- MOVE CIELO-NUM-PROPOSTA TO WS-NUM-PROPOSTA-CIELO */
            _.Move(REG_CIELO.CIELO_NUM_PROPOSTA, WS_TRABALHO.WS_NUM_PROPOSTA_CIELO);

            /*" -1227- IF WS-NUM-PROPOSTA-CIELO EQUAL WS-NUM-PROPOSTA */

            if (WS_TRABALHO.WS_NUM_PROPOSTA_CIELO == WS_TRABALHO.WS_COD_IDLG_ADESAO.WS_NUM_PROPOSTA)
            {

                /*" -1228- CONTINUE */

                /*" -1231- ELSE */
            }
            else
            {


                /*" -1233- DISPLAY 'PROPOSTA DO IDLG NAO CORRESPONDE A PROPOSTA DO AR 'QUIVO.' */
                _.Display($"PROPOSTA DO IDLG NAO CORRESPONDE A PROPOSTA DO AR QUIVO.");

                /*" -1235- DISPLAY 'NUMERO DA PROPOSTA DO ARQUIVO = ' WS-NUM-PROPOSTA-CIELO */
                _.Display($"NUMERO DA PROPOSTA DO ARQUIVO = {WS_TRABALHO.WS_NUM_PROPOSTA_CIELO}");

                /*" -1237- DISPLAY 'NUMERO DA PROPOSTA DO IDLG    = ' WS-NUM-PROPOSTA */
                _.Display($"NUMERO DA PROPOSTA DO IDLG    = {WS_TRABALHO.WS_COD_IDLG_ADESAO.WS_NUM_PROPOSTA}");

                /*" -1238- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1240- END-IF */
            }


            /*" -1240- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0401_99_SAIDA*/

        [StopWatch]
        /*" R0403-00-VERIFICA-PROPOSTA-SECTION */
        private void R0403_00_VERIFICA_PROPOSTA_SECTION()
        {
            /*" -1248- MOVE 'R0403-00-VERIFICA-PROPOSTA' TO PARAGRAFO */
            _.Move("R0403-00-VERIFICA-PROPOSTA", WABEND.PARAGRAFO);

            /*" -1249- MOVE 'CONSULTA PROPOSTA FIDELIZ' TO COMANDO */
            _.Move("CONSULTA PROPOSTA FIDELIZ", WABEND.COMANDO);

            /*" -1251- DISPLAY PARAGRAFO */
            _.Display(WABEND.PARAGRAFO);

            /*" -1253- MOVE CIELO-NUM-PROPOSTA TO PROPOFID-NUM-PROPOSTA-SIVPF */
            _.Move(REG_CIELO.CIELO_NUM_PROPOSTA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF);

            /*" -1256- MOVE ZEROS TO W-PRODUTO */
            _.Move(0, LBWPF002.W_PRODUTO);

            /*" -1262- PERFORM R0403_00_VERIFICA_PROPOSTA_DB_SELECT_1 */

            R0403_00_VERIFICA_PROPOSTA_DB_SELECT_1();

            /*" -1265-  EVALUATE SQLCODE  */

            /*" -1266-  WHEN ZEROS  */

            /*" -1266- IF   SQLCODE EQUALS  ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -1268- MOVE PROPOFID-COD-PRODUTO-SIVPF TO W-PRODUTO */
                _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF, LBWPF002.W_PRODUTO);

                /*" -1269-  WHEN +100  */

                /*" -1269- ELSE IF   SQLCODE EQUALS  +100 */
            }
            else

            if (DB.SQLCODE == +100)
            {

                /*" -1275- IF CIELO-NUM-PROPOSTA(8:2) EQUAL 60 OR 61 OR 62 OR 65 OR 66 OR 68 OR 70 OR 73 OR 80 OR 81 OR 85 OR 88 OR 89 OR 90 OR 91 OR 92 OR 94 OR 00 */

                if (REG_CIELO.CIELO_NUM_PROPOSTA.Substring(8, 2).In("60", "61", "62", "65", "66", "68", "70", "73", "80", "81", "85", "88", "89", "90", "91", "92", "94", "00"))
                {

                    /*" -1276- MOVE 61 TO W-PRODUTO */
                    _.Move(61, LBWPF002.W_PRODUTO);

                    /*" -1277- ELSE */
                }
                else
                {


                    /*" -1278- MOVE 99 TO W-PRODUTO */
                    _.Move(99, LBWPF002.W_PRODUTO);

                    /*" -1279- END-IF */
                }


                /*" -1280-  WHEN OTHER  */

                /*" -1280- ELSE */
            }
            else
            {


                /*" -1281- DISPLAY 'R0030-00-ERRO SELECT PROPOSTA_FIDELIZ' */
                _.Display($"R0030-00-ERRO SELECT PROPOSTA_FIDELIZ");

                /*" -1282- DISPLAY 'NUM_CERTIFICADO = ' PROPOFID-NUM-PROPOSTA-SIVPF */
                _.Display($"NUM_CERTIFICADO = {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}");

                /*" -1283- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1283-  END-EVALUATE.  */

                /*" -1283- END-IF. */
            }


        }

        [StopWatch]
        /*" R0403-00-VERIFICA-PROPOSTA-DB-SELECT-1 */
        public void R0403_00_VERIFICA_PROPOSTA_DB_SELECT_1()
        {
            /*" -1262- EXEC SQL SELECT COD_PRODUTO_SIVPF INTO :PROPOFID-COD-PRODUTO-SIVPF FROM SEGUROS.PROPOSTA_FIDELIZ WHERE NUM_PROPOSTA_SIVPF = :PROPOFID-NUM-PROPOSTA-SIVPF WITH UR END-EXEC */

            var r0403_00_VERIFICA_PROPOSTA_DB_SELECT_1_Query1 = new R0403_00_VERIFICA_PROPOSTA_DB_SELECT_1_Query1()
            {
                PROPOFID_NUM_PROPOSTA_SIVPF = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF.ToString(),
            };

            var executed_1 = R0403_00_VERIFICA_PROPOSTA_DB_SELECT_1_Query1.Execute(r0403_00_VERIFICA_PROPOSTA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PROPOFID_COD_PRODUTO_SIVPF, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0403_99_SAIDA*/

        [StopWatch]
        /*" R0405-00-TRATA-NSAC-SECTION */
        private void R0405_00_TRATA_NSAC_SECTION()
        {
            /*" -1291- MOVE 'R0405-00-TRATA-NSAC' TO PARAGRAFO */
            _.Move("R0405-00-TRATA-NSAC", WABEND.PARAGRAFO);

            /*" -1292- MOVE 'TRATAR SEQUENCIAL RETORNO' TO COMANDO */
            _.Move("TRATAR SEQUENCIAL RETORNO", WABEND.COMANDO);

            /*" -1296- DISPLAY PARAGRAFO */
            _.Display(WABEND.PARAGRAFO);

            /*" -1298- PERFORM R0407-00-SELECT-AVISOCRE */

            R0407_00_SELECT_AVISOCRE_SECTION();

            /*" -1300- MOVE AVISOCRE-NUM-AVISO-CREDITO TO WS0-NRAVISO */
            _.Move(AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_NUM_AVISO_CREDITO, WS_TRABALHO.WS0_NRAVISO);

            /*" -1300- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0405_99_SAIDA*/

        [StopWatch]
        /*" R0407-00-SELECT-AVISOCRE-SECTION */
        private void R0407_00_SELECT_AVISOCRE_SECTION()
        {
            /*" -1308- MOVE 'R0407-00-SELECT-AVISOCRE' TO PARAGRAFO */
            _.Move("R0407-00-SELECT-AVISOCRE", WABEND.PARAGRAFO);

            /*" -1309- MOVE 'SELECT AVISO CREDITO' TO COMANDO */
            _.Move("SELECT AVISO CREDITO", WABEND.COMANDO);

            /*" -1311- DISPLAY PARAGRAFO */
            _.Display(WABEND.PARAGRAFO);

            /*" -1318- PERFORM R0407_00_SELECT_AVISOCRE_DB_SELECT_1 */

            R0407_00_SELECT_AVISOCRE_DB_SELECT_1();

            /*" -1321- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1322- DISPLAY 'R0407-00 - PROBLEMAS NO SELECT AVISO_CREDITO' */
                _.Display($"R0407-00 - PROBLEMAS NO SELECT AVISO_CREDITO");

                /*" -1323- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1325- END-IF */
            }


            /*" -1326- IF AVISOCRE-NUM-AVISO-CREDITO EQUAL ZEROS */

            if (AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_NUM_AVISO_CREDITO == 00)
            {

                /*" -1327- MOVE 902000001 TO AVISOCRE-NUM-AVISO-CREDITO */
                _.Move(902000001, AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_NUM_AVISO_CREDITO);

                /*" -1328- ELSE */
            }
            else
            {


                /*" -1329- ADD 1 TO AVISOCRE-NUM-AVISO-CREDITO */
                AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_NUM_AVISO_CREDITO.Value = AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_NUM_AVISO_CREDITO + 1;

                /*" -1331- END-IF */
            }


            /*" -1331- . */

        }

        [StopWatch]
        /*" R0407-00-SELECT-AVISOCRE-DB-SELECT-1 */
        public void R0407_00_SELECT_AVISOCRE_DB_SELECT_1()
        {
            /*" -1318- EXEC SQL SELECT VALUE(MAX(NUM_AVISO_CREDITO),0) INTO :AVISOCRE-NUM-AVISO-CREDITO FROM SEGUROS.AVISO_CREDITO WHERE NUM_AVISO_CREDITO BETWEEN :WSHOST-NRAVISO1 AND :WSHOST-NRAVISO2 WITH UR END-EXEC */

            var r0407_00_SELECT_AVISOCRE_DB_SELECT_1_Query1 = new R0407_00_SELECT_AVISOCRE_DB_SELECT_1_Query1()
            {
                WSHOST_NRAVISO1 = WS_TRABALHO.WSHOST_NRAVISO1.ToString(),
                WSHOST_NRAVISO2 = WS_TRABALHO.WSHOST_NRAVISO2.ToString(),
            };

            var executed_1 = R0407_00_SELECT_AVISOCRE_DB_SELECT_1_Query1.Execute(r0407_00_SELECT_AVISOCRE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.AVISOCRE_NUM_AVISO_CREDITO, AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_NUM_AVISO_CREDITO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0407_99_SAIDA*/

        [StopWatch]
        /*" R0408-00-GRAVA-HEADER-CIELO-SECTION */
        private void R0408_00_GRAVA_HEADER_CIELO_SECTION()
        {
            /*" -1339- MOVE 'R0408-00-GRAVA-HEADER-CIELO' TO PARAGRAFO */
            _.Move("R0408-00-GRAVA-HEADER-CIELO", WABEND.PARAGRAFO);

            /*" -1340- MOVE 'GRAVAR HEADER ADESAO' TO COMANDO */
            _.Move("GRAVAR HEADER ADESAO", WABEND.COMANDO);

            /*" -1343- DISPLAY PARAGRAFO */
            _.Display(WABEND.PARAGRAFO);

            /*" -1344- MOVE SPACES TO HEAD01-REGISTRO */
            _.Move("", HEAD01_REGISTRO);

            /*" -1346- MOVE 000 TO HEAD01-TIPO-REGISTRO */
            _.Move(000, HEAD01_REGISTRO.HEAD01_TIPO_REGISTRO);

            /*" -1348- MOVE 001 TO HEAD01-TIPO-ARQUIVO */
            _.Move(001, HEAD01_REGISTRO.HEAD01_TIPO_ARQUIVO);

            /*" -1350- MOVE WS-DIA-MOVABE OF WS-DTMOVABE1 TO HEAD01-DIA */
            _.Move(WS_TRABALHO.WS_DTMOVABE1.WS_DIA_MOVABE, HEAD01_REGISTRO.HEAD01_DATA_GERACAO.HEAD01_DIA);

            /*" -1352- MOVE WS-MES-MOVABE OF WS-DTMOVABE1 TO HEAD01-MES */
            _.Move(WS_TRABALHO.WS_DTMOVABE1.WS_MES_MOVABE, HEAD01_REGISTRO.HEAD01_DATA_GERACAO.HEAD01_MES);

            /*" -1354- MOVE WS-ANO-MOVABE OF WS-DTMOVABE1 TO HEAD01-ANO */
            _.Move(WS_TRABALHO.WS_DTMOVABE1.WS_ANO_MOVABE, HEAD01_REGISTRO.HEAD01_DATA_GERACAO.HEAD01_ANO);

            /*" -1355- MOVE 9020 TO HEAD01-COD-CONVENIO */
            _.Move(9020, HEAD01_REGISTRO.HEAD01_COD_CONVENIO);

            /*" -1357- MOVE WS0-NRO-NSAC TO HEAD01-NSAS */
            _.Move(WS_TRABALHO.FILLER_13.WS0_NRO_NSAC, HEAD01_REGISTRO.HEAD01_NSAS);

            /*" -1359- WRITE REG-CCADESAO FROM HEAD01-REGISTRO */
            _.Move(HEAD01_REGISTRO.GetMoveValues(), REG_CCADESAO);

            CCADESAO.Write(REG_CCADESAO.GetMoveValues().ToString());

            /*" -1362- MOVE 'GRAVAR HEADER DEMAIS PARCELAS' TO COMANDO */
            _.Move("GRAVAR HEADER DEMAIS PARCELAS", WABEND.COMANDO);

            /*" -1363- MOVE SPACES TO HEAD01-REGISTRO */
            _.Move("", HEAD01_REGISTRO);

            /*" -1365- MOVE 000 TO HEAD01-TIPO-REGISTRO */
            _.Move(000, HEAD01_REGISTRO.HEAD01_TIPO_REGISTRO);

            /*" -1367- MOVE 002 TO HEAD01-TIPO-ARQUIVO */
            _.Move(002, HEAD01_REGISTRO.HEAD01_TIPO_ARQUIVO);

            /*" -1369- MOVE WS-DIA-MOVABE OF WS-DTMOVABE1 TO HEAD01-DIA */
            _.Move(WS_TRABALHO.WS_DTMOVABE1.WS_DIA_MOVABE, HEAD01_REGISTRO.HEAD01_DATA_GERACAO.HEAD01_DIA);

            /*" -1371- MOVE WS-MES-MOVABE OF WS-DTMOVABE1 TO HEAD01-MES */
            _.Move(WS_TRABALHO.WS_DTMOVABE1.WS_MES_MOVABE, HEAD01_REGISTRO.HEAD01_DATA_GERACAO.HEAD01_MES);

            /*" -1373- MOVE WS-ANO-MOVABE OF WS-DTMOVABE1 TO HEAD01-ANO */
            _.Move(WS_TRABALHO.WS_DTMOVABE1.WS_ANO_MOVABE, HEAD01_REGISTRO.HEAD01_DATA_GERACAO.HEAD01_ANO);

            /*" -1374- MOVE 9020 TO HEAD01-COD-CONVENIO */
            _.Move(9020, HEAD01_REGISTRO.HEAD01_COD_CONVENIO);

            /*" -1376- MOVE WS0-NRO-NSAC TO HEAD01-NSAS */
            _.Move(WS_TRABALHO.FILLER_13.WS0_NRO_NSAC, HEAD01_REGISTRO.HEAD01_NSAS);

            /*" -1377- WRITE REG-CCDEMAIS FROM HEAD01-REGISTRO */
            _.Move(HEAD01_REGISTRO.GetMoveValues(), REG_CCDEMAIS);

            CCDEMAIS.Write(REG_CCDEMAIS.GetMoveValues().ToString());

            /*" -1379- SET WS-S-GRAVOU-HEADER TO TRUE */
            WS_GRAVOU_HEADER["WS_S_GRAVOU_HEADER"] = true;

            /*" -1379- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0408_99_SAIDA*/

        [StopWatch]
        /*" R0409-00-GRAVA-TRAILER-CIELO-SECTION */
        private void R0409_00_GRAVA_TRAILER_CIELO_SECTION()
        {
            /*" -1387- MOVE 'R0409-00-GRAVA-TRAILER-CIELO' TO PARAGRAFO */
            _.Move("R0409-00-GRAVA-TRAILER-CIELO", WABEND.PARAGRAFO);

            /*" -1388- MOVE 'GRAVAR TRAILER ADESAO' TO COMANDO */
            _.Move("GRAVAR TRAILER ADESAO", WABEND.COMANDO);

            /*" -1391- DISPLAY PARAGRAFO */
            _.Display(WABEND.PARAGRAFO);

            /*" -1392- MOVE SPACES TO TRAIL01-REGISTRO */
            _.Move("", TRAIL01_REGISTRO);

            /*" -1393- MOVE 999 TO TRAIL01-TIPO-REGISTRO */
            _.Move(999, TRAIL01_REGISTRO.TRAIL01_TIPO_REGISTRO);

            /*" -1395- MOVE SISTEMAS-DATA-MOV-ABERTO TO TRAIL01-DATA-MOVIMENTO */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, TRAIL01_REGISTRO.TRAIL01_DATA_MOVIMENTO);

            /*" -1397- MOVE WS-DIA-MOVABE OF WS-DTMOVABE1 TO TRAIL01-DIA */
            _.Move(WS_TRABALHO.WS_DTMOVABE1.WS_DIA_MOVABE, TRAIL01_REGISTRO.TRAIL01_DATA_MOVIMENTO.TRAIL01_DIA);

            /*" -1399- MOVE WS-MES-MOVABE OF WS-DTMOVABE1 TO TRAIL01-MES */
            _.Move(WS_TRABALHO.WS_DTMOVABE1.WS_MES_MOVABE, TRAIL01_REGISTRO.TRAIL01_DATA_MOVIMENTO.TRAIL01_MES);

            /*" -1401- MOVE WS-ANO-MOVABE OF WS-DTMOVABE1 TO TRAIL01-ANO */
            _.Move(WS_TRABALHO.WS_DTMOVABE1.WS_ANO_MOVABE, TRAIL01_REGISTRO.TRAIL01_DATA_MOVIMENTO.TRAIL01_ANO);

            /*" -1402- MOVE 9020 TO TRAIL01-COD-CONVENIO */
            _.Move(9020, TRAIL01_REGISTRO.TRAIL01_COD_CONVENIO);

            /*" -1403- MOVE WS0-NRO-NSAC TO TRAIL01-NSAS */
            _.Move(WS_TRABALHO.FILLER_13.WS0_NRO_NSAC, TRAIL01_REGISTRO.TRAIL01_NSAS);

            /*" -1404- MOVE WS-SOMA-VLR-ADESAO TO TRAIL01-VLR-TOTAL */
            _.Move(WS_TRABALHO.WS_SOMA_VLR_ADESAO, TRAIL01_REGISTRO.TRAIL01_VLR_TOTAL);

            /*" -1406- MOVE WS-AC-GRAV-ADESAO TO TRAIL01-QTD-TOTAL */
            _.Move(WS_CONTADORES.WS_AC_GRAV_ADESAO, TRAIL01_REGISTRO.TRAIL01_QTD_TOTAL);

            /*" -1408- WRITE REG-CCADESAO FROM TRAIL01-REGISTRO */
            _.Move(TRAIL01_REGISTRO.GetMoveValues(), REG_CCADESAO);

            CCADESAO.Write(REG_CCADESAO.GetMoveValues().ToString());

            /*" -1410- MOVE 'GRAVAR TRAILER DEMAIS PARCELAS' TO COMANDO */
            _.Move("GRAVAR TRAILER DEMAIS PARCELAS", WABEND.COMANDO);

            /*" -1411- MOVE WS-SOMA-VLR-DEMAIS TO TRAIL01-VLR-TOTAL */
            _.Move(WS_TRABALHO.WS_SOMA_VLR_DEMAIS, TRAIL01_REGISTRO.TRAIL01_VLR_TOTAL);

            /*" -1413- MOVE WS-AC-GRAV-DEMAIS TO TRAIL01-QTD-TOTAL */
            _.Move(WS_CONTADORES.WS_AC_GRAV_DEMAIS, TRAIL01_REGISTRO.TRAIL01_QTD_TOTAL);

            /*" -1415- WRITE REG-CCDEMAIS FROM TRAIL01-REGISTRO */
            _.Move(TRAIL01_REGISTRO.GetMoveValues(), REG_CCDEMAIS);

            CCDEMAIS.Write(REG_CCDEMAIS.GetMoveValues().ToString());

            /*" -1415- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0409_99_SAIDA*/

        [StopWatch]
        /*" R0410-00-CONTROLE-CARTAO-CIELO-SECTION */
        private void R0410_00_CONTROLE_CARTAO_CIELO_SECTION()
        {
            /*" -1423- MOVE 'R0410-00-CONTROLE-CARTAO-CIELO' TO PARAGRAFO */
            _.Move("R0410-00-CONTROLE-CARTAO-CIELO", WABEND.PARAGRAFO);

            /*" -1424- MOVE 'SELECT CONTROLE CARTAO CIELO' TO COMANDO */
            _.Move("SELECT CONTROLE CARTAO CIELO", WABEND.COMANDO);

            /*" -1426- DISPLAY PARAGRAFO */
            _.Display(WABEND.PARAGRAFO);

            /*" -1428- INITIALIZE DCLGE-CONTROLE-CARTAO-CIELO */
            _.Initialize(
                GE407.DCLGE_CONTROLE_CARTAO_CIELO
            );

            /*" -1429- MOVE ZEROS TO GE407-NUM-PROPOSTA */
            _.Move(0, GE407.DCLGE_CONTROLE_CARTAO_CIELO.GE407_NUM_PROPOSTA);

            /*" -1430- MOVE CIELO-NUM-PROPOSTA TO GE407-NUM-CERTIFICADO */
            _.Move(REG_CIELO.CIELO_NUM_PROPOSTA, GE407.DCLGE_CONTROLE_CARTAO_CIELO.GE407_NUM_CERTIFICADO);

            /*" -1433- MOVE CIELO-IDLG TO GE407-COD-IDLG */
            _.Move(REG_CIELO.CIELO_IDLG, GE407.DCLGE_CONTROLE_CARTAO_CIELO.GE407_COD_IDLG);

            /*" -1448- PERFORM R0410_00_CONTROLE_CARTAO_CIELO_DB_SELECT_1 */

            R0410_00_CONTROLE_CARTAO_CIELO_DB_SELECT_1();

            /*" -1451-  EVALUATE SQLCODE  */

            /*" -1452-  WHEN ZEROS  */

            /*" -1452- IF   SQLCODE EQUALS  ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -1453- MOVE 'S' TO WS-ACHOU-CTRL-CIELO */
                _.Move("S", WS_TRABALHO.WS_ACHOU_CTRL_CIELO);

                /*" -1454-  WHEN +100  */

                /*" -1454- ELSE IF   SQLCODE EQUALS  +100 */
            }
            else

            if (DB.SQLCODE == +100)
            {

                /*" -1455- MOVE 'N' TO WS-ACHOU-CTRL-CIELO */
                _.Move("N", WS_TRABALHO.WS_ACHOU_CTRL_CIELO);

                /*" -1457- MOVE ZEROS TO GE407-NUM-OCORR-MOVTO GE407-SEQ-CONTROL-CARTAO */
                _.Move(0, GE407.DCLGE_CONTROLE_CARTAO_CIELO.GE407_NUM_OCORR_MOVTO, GE407.DCLGE_CONTROLE_CARTAO_CIELO.GE407_SEQ_CONTROL_CARTAO);

                /*" -1458- MOVE SPACES TO GE407-COD-TP-PAGAMENTO */
                _.Move("", GE407.DCLGE_CONTROLE_CARTAO_CIELO.GE407_COD_TP_PAGAMENTO);

                /*" -1459-  WHEN -811  */

                /*" -1459- ELSE IF   SQLCODE EQUALS  -811 */
            }
            else

            if (DB.SQLCODE == -811)
            {

                /*" -1460- DISPLAY 'R0410-00-MAIS DE UM REGISTRO PENDENTE DE RETORNO' */
                _.Display($"R0410-00-MAIS DE UM REGISTRO PENDENTE DE RETORNO");

                /*" -1461- DISPLAY 'NUM_CERTIFICADO = ' GE407-NUM-CERTIFICADO */
                _.Display($"NUM_CERTIFICADO = {GE407.DCLGE_CONTROLE_CARTAO_CIELO.GE407_NUM_CERTIFICADO}");

                /*" -1462- DISPLAY 'COD_IDLG        = ' GE407-COD-IDLG */
                _.Display($"COD_IDLG        = {GE407.DCLGE_CONTROLE_CARTAO_CIELO.GE407_COD_IDLG}");

                /*" -1463- DISPLAY 'NUM_PARCELA     = ' GE407-NUM-PARCELA */
                _.Display($"NUM_PARCELA     = {GE407.DCLGE_CONTROLE_CARTAO_CIELO.GE407_NUM_PARCELA}");

                /*" -1464- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1465-  WHEN OTHER  */

                /*" -1465- ELSE */
            }
            else
            {


                /*" -1466- DISPLAY 'R0410-00-ERRO SELECT GE_CONTROLE_CARTAO_CIELO' */
                _.Display($"R0410-00-ERRO SELECT GE_CONTROLE_CARTAO_CIELO");

                /*" -1467- DISPLAY 'NUM_CERTIFICADO = ' GE407-NUM-CERTIFICADO */
                _.Display($"NUM_CERTIFICADO = {GE407.DCLGE_CONTROLE_CARTAO_CIELO.GE407_NUM_CERTIFICADO}");

                /*" -1468- DISPLAY 'COD_IDLG        = ' GE407-COD-IDLG */
                _.Display($"COD_IDLG        = {GE407.DCLGE_CONTROLE_CARTAO_CIELO.GE407_COD_IDLG}");

                /*" -1469- DISPLAY 'NUM_PARCELA     = ' GE407-NUM-PARCELA */
                _.Display($"NUM_PARCELA     = {GE407.DCLGE_CONTROLE_CARTAO_CIELO.GE407_NUM_PARCELA}");

                /*" -1470- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1470-  END-EVALUATE.  */

                /*" -1470- END-IF. */
            }


        }

        [StopWatch]
        /*" R0410-00-CONTROLE-CARTAO-CIELO-DB-SELECT-1 */
        public void R0410_00_CONTROLE_CARTAO_CIELO_DB_SELECT_1()
        {
            /*" -1448- EXEC SQL SELECT NUM_OCORR_MOVTO , SEQ_CONTROL_CARTAO , COD_TP_PAGAMENTO , NUM_PARCELA INTO :GE407-NUM-OCORR-MOVTO , :GE407-SEQ-CONTROL-CARTAO , :GE407-COD-TP-PAGAMENTO , :GE407-NUM-PARCELA FROM SEGUROS.GE_CONTROLE_CARTAO_CIELO WHERE NUM_CERTIFICADO = :GE407-NUM-CERTIFICADO AND COD_IDLG = :GE407-COD-IDLG WITH UR END-EXEC */

            var r0410_00_CONTROLE_CARTAO_CIELO_DB_SELECT_1_Query1 = new R0410_00_CONTROLE_CARTAO_CIELO_DB_SELECT_1_Query1()
            {
                GE407_NUM_CERTIFICADO = GE407.DCLGE_CONTROLE_CARTAO_CIELO.GE407_NUM_CERTIFICADO.ToString(),
                GE407_COD_IDLG = GE407.DCLGE_CONTROLE_CARTAO_CIELO.GE407_COD_IDLG.ToString(),
            };

            var executed_1 = R0410_00_CONTROLE_CARTAO_CIELO_DB_SELECT_1_Query1.Execute(r0410_00_CONTROLE_CARTAO_CIELO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.GE407_NUM_OCORR_MOVTO, GE407.DCLGE_CONTROLE_CARTAO_CIELO.GE407_NUM_OCORR_MOVTO);
                _.Move(executed_1.GE407_SEQ_CONTROL_CARTAO, GE407.DCLGE_CONTROLE_CARTAO_CIELO.GE407_SEQ_CONTROL_CARTAO);
                _.Move(executed_1.GE407_COD_TP_PAGAMENTO, GE407.DCLGE_CONTROLE_CARTAO_CIELO.GE407_COD_TP_PAGAMENTO);
                _.Move(executed_1.GE407_NUM_PARCELA, GE407.DCLGE_CONTROLE_CARTAO_CIELO.GE407_NUM_PARCELA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0410_99_SAIDA*/

        [StopWatch]
        /*" R0420-00-GERA-NUM-OCORR-MOVTO-SECTION */
        private void R0420_00_GERA_NUM_OCORR_MOVTO_SECTION()
        {
            /*" -1478- MOVE 'R0420-00-GERA-NUM-OCORR-MOVTO' TO PARAGRAFO */
            _.Move("R0420-00-GERA-NUM-OCORR-MOVTO", WABEND.PARAGRAFO);

            /*" -1479- MOVE 'GERAR NOVA OCORRENCIA DE MOVIMENTO' TO COMANDO */
            _.Move("GERAR NOVA OCORRENCIA DE MOVIMENTO", WABEND.COMANDO);

            /*" -1482- DISPLAY PARAGRAFO */
            _.Display(WABEND.PARAGRAFO);

            /*" -1485- PERFORM R0430-00-BUSCA-MAX-OCORR-SAP */

            R0430_00_BUSCA_MAX_OCORR_SAP_SECTION();

            /*" -1488- PERFORM R0435-00-INS-MOVIMENTO-SAP */

            R0435_00_INS_MOVIMENTO_SAP_SECTION();

            /*" -1490- PERFORM R0440-00-INS-CTRL-INT-SAP */

            R0440_00_INS_CTRL_INT_SAP_SECTION();

            /*" -1490- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0420_99_SAIDA*/

        [StopWatch]
        /*" R0430-00-BUSCA-MAX-OCORR-SAP-SECTION */
        private void R0430_00_BUSCA_MAX_OCORR_SAP_SECTION()
        {
            /*" -1498- MOVE 'R0430-00-BUSCA-MAX-OCORR-SAP' TO PARAGRAFO */
            _.Move("R0430-00-BUSCA-MAX-OCORR-SAP", WABEND.PARAGRAFO);

            /*" -1499- MOVE 'BUSCA ULTIMA OCORRECIA' TO COMANDO */
            _.Move("BUSCA ULTIMA OCORRECIA", WABEND.COMANDO);

            /*" -1501- DISPLAY PARAGRAFO */
            _.Display(WABEND.PARAGRAFO);

            /*" -1506- PERFORM R0430_00_BUSCA_MAX_OCORR_SAP_DB_SELECT_1 */

            R0430_00_BUSCA_MAX_OCORR_SAP_DB_SELECT_1();

            /*" -1509-  EVALUATE SQLCODE  */

            /*" -1510-  WHEN ZEROS  */

            /*" -1510- IF   SQLCODE EQUALS  ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -1511- CONTINUE */

                /*" -1512-  WHEN OTHER  */

                /*" -1512- ELSE */
            }
            else
            {


                /*" -1513- DISPLAY 'R01010-ERRO NO SELECT MAX GE_MOVIMENTO_SAP' */
                _.Display($"R01010-ERRO NO SELECT MAX GE_MOVIMENTO_SAP");

                /*" -1514- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1514-  END-EVALUATE.  */

                /*" -1514- END-IF. */
            }


        }

        [StopWatch]
        /*" R0430-00-BUSCA-MAX-OCORR-SAP-DB-SELECT-1 */
        public void R0430_00_BUSCA_MAX_OCORR_SAP_DB_SELECT_1()
        {
            /*" -1506- EXEC SQL SELECT VALUE(MAX(NUM_OCORR_MOVTO),0) + 1 INTO :WS-HOST-PROX-OCORR FROM SEGUROS.GE_MOVIMENTO_SAP WITH UR END-EXEC */

            var r0430_00_BUSCA_MAX_OCORR_SAP_DB_SELECT_1_Query1 = new R0430_00_BUSCA_MAX_OCORR_SAP_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0430_00_BUSCA_MAX_OCORR_SAP_DB_SELECT_1_Query1.Execute(r0430_00_BUSCA_MAX_OCORR_SAP_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_HOST_PROX_OCORR, WS_TRABALHO.WS_HOST_PROX_OCORR);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0430_99_SAIDA*/

        [StopWatch]
        /*" R0435-00-INS-MOVIMENTO-SAP-SECTION */
        private void R0435_00_INS_MOVIMENTO_SAP_SECTION()
        {
            /*" -1522- MOVE 'R0435-00-INS-MOVIMENTO-SAP' TO PARAGRAFO */
            _.Move("R0435-00-INS-MOVIMENTO-SAP", WABEND.PARAGRAFO);

            /*" -1523- MOVE 'INSERE MOVIMENTO SAP' TO COMANDO */
            _.Move("INSERE MOVIMENTO SAP", WABEND.COMANDO);

            /*" -1525- DISPLAY PARAGRAFO */
            _.Display(WABEND.PARAGRAFO);

            /*" -1526- MOVE SISTEMAS-DATA-MOV-ABERTO TO GE099-DTH-MOVIMENTO */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, GE099.DCLGE_MOVIMENTO_SAP.GE099_DTH_MOVIMENTO);

            /*" -1527- MOVE WS-HOST-PROX-OCORR TO GE099-NUM-OCORR-MOVTO */
            _.Move(WS_TRABALHO.WS_HOST_PROX_OCORR, GE099.DCLGE_MOVIMENTO_SAP.GE099_NUM_OCORR_MOVTO);

            /*" -1529- MOVE 'EM8024B' TO GE099-NOM-PROGRAMA */
            _.Move("EM8024B", GE099.DCLGE_MOVIMENTO_SAP.GE099_NOM_PROGRAMA);

            /*" -1543- PERFORM R0435_00_INS_MOVIMENTO_SAP_DB_INSERT_1 */

            R0435_00_INS_MOVIMENTO_SAP_DB_INSERT_1();

            /*" -1546-  EVALUATE SQLCODE  */

            /*" -1547-  WHEN ZEROS  */

            /*" -1547- IF   SQLCODE EQUALS  ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -1548- ADD 1 TO WS-INS-MOVTO-SAP */
                WS_CONTADORES.WS_INS_MOVTO_SAP.Value = WS_CONTADORES.WS_INS_MOVTO_SAP + 1;

                /*" -1549-  WHEN OTHER  */

                /*" -1549- ELSE */
            }
            else
            {


                /*" -1550- DISPLAY 'R0100-00-ERRO GE_MOVIMENTO_SAP' */
                _.Display($"R0100-00-ERRO GE_MOVIMENTO_SAP");

                /*" -1551- DISPLAY 'NUM-OCORR-MOVTO = ' GE099-NUM-OCORR-MOVTO */
                _.Display($"NUM-OCORR-MOVTO = {GE099.DCLGE_MOVIMENTO_SAP.GE099_NUM_OCORR_MOVTO}");

                /*" -1552- DISPLAY 'DTH-MOVIMENTO   = ' GE099-DTH-MOVIMENTO */
                _.Display($"DTH-MOVIMENTO   = {GE099.DCLGE_MOVIMENTO_SAP.GE099_DTH_MOVIMENTO}");

                /*" -1553- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1553-  END-EVALUATE.  */

                /*" -1553- END-IF. */
            }


        }

        [StopWatch]
        /*" R0435-00-INS-MOVIMENTO-SAP-DB-INSERT-1 */
        public void R0435_00_INS_MOVIMENTO_SAP_DB_INSERT_1()
        {
            /*" -1543- EXEC SQL INSERT INTO SEGUROS.GE_MOVIMENTO_SAP ( NUM_OCORR_MOVTO , DTH_MOVIMENTO , NOM_PROGRAMA , DTH_CADASTRAMENTO ) VALUES ( :GE099-NUM-OCORR-MOVTO , :GE099-DTH-MOVIMENTO , :GE099-NOM-PROGRAMA , CURRENT TIMESTAMP ) END-EXEC */

            var r0435_00_INS_MOVIMENTO_SAP_DB_INSERT_1_Insert1 = new R0435_00_INS_MOVIMENTO_SAP_DB_INSERT_1_Insert1()
            {
                GE099_NUM_OCORR_MOVTO = GE099.DCLGE_MOVIMENTO_SAP.GE099_NUM_OCORR_MOVTO.ToString(),
                GE099_DTH_MOVIMENTO = GE099.DCLGE_MOVIMENTO_SAP.GE099_DTH_MOVIMENTO.ToString(),
                GE099_NOM_PROGRAMA = GE099.DCLGE_MOVIMENTO_SAP.GE099_NOM_PROGRAMA.ToString(),
            };

            R0435_00_INS_MOVIMENTO_SAP_DB_INSERT_1_Insert1.Execute(r0435_00_INS_MOVIMENTO_SAP_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0435_99_SAIDA*/

        [StopWatch]
        /*" R0440-00-INS-CTRL-INT-SAP-SECTION */
        private void R0440_00_INS_CTRL_INT_SAP_SECTION()
        {
            /*" -1561- MOVE 'R0440-00-INS-CTRL-INT-SAP' TO PARAGRAFO */
            _.Move("R0440-00-INS-CTRL-INT-SAP", WABEND.PARAGRAFO);

            /*" -1562- MOVE 'INSERE CONTROLE INTERFACE SAP' TO COMANDO */
            _.Move("INSERE CONTROLE INTERFACE SAP", WABEND.COMANDO);

            /*" -1564- DISPLAY PARAGRAFO */
            _.Display(WABEND.PARAGRAFO);

            /*" -1565- MOVE GE099-NUM-OCORR-MOVTO TO GE100-NUM-OCORR-MOVTO */
            _.Move(GE099.DCLGE_MOVIMENTO_SAP.GE099_NUM_OCORR_MOVTO, GE100.DCLGE_CONTROLE_INTERF_SAP.GE100_NUM_OCORR_MOVTO);

            /*" -1566- MOVE CIELO-IDLG TO GE100-COD-IDLG */
            _.Move(REG_CIELO.CIELO_IDLG, GE100.DCLGE_CONTROLE_INTERF_SAP.GE100_COD_IDLG);

            /*" -1567- MOVE SISTEMAS-DATA-MOV-ABERTO TO GE100-DTA-MOVIMENTO-LEGADO */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, GE100.DCLGE_CONTROLE_INTERF_SAP.GE100_DTA_MOVIMENTO_LEGADO);

            /*" -1569- MOVE WS-DT-MOV-CIELO TO GE100-DTA-MOVIMENTO-ARQH */
            _.Move(WS_TRABALHO.WS_DT_MOV_CIELO, GE100.DCLGE_CONTROLE_INTERF_SAP.GE100_DTA_MOVIMENTO_ARQH);

            /*" -1592- PERFORM R0440_00_INS_CTRL_INT_SAP_DB_INSERT_1 */

            R0440_00_INS_CTRL_INT_SAP_DB_INSERT_1();

            /*" -1595-  EVALUATE SQLCODE  */

            /*" -1596-  WHEN ZEROS  */

            /*" -1596- IF   SQLCODE EQUALS  ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -1597- ADD 1 TO WS-INS-INTERF-SAP */
                WS_CONTADORES.WS_INS_INTERF_SAP.Value = WS_CONTADORES.WS_INS_INTERF_SAP + 1;

                /*" -1598-  WHEN OTHER  */

                /*" -1598- ELSE */
            }
            else
            {


                /*" -1599- DISPLAY 'R0438-00-FALHA AO INCLUIR GE-CONTROLE-INTERF-SAP' */
                _.Display($"R0438-00-FALHA AO INCLUIR GE-CONTROLE-INTERF-SAP");

                /*" -1600- DISPLAY 'NUM-OCORR-MOVTO = ' GE100-NUM-OCORR-MOVTO */
                _.Display($"NUM-OCORR-MOVTO = {GE100.DCLGE_CONTROLE_INTERF_SAP.GE100_NUM_OCORR_MOVTO}");

                /*" -1601- DISPLAY 'COD-IDLG        = ' GE100-COD-IDLG */
                _.Display($"COD-IDLG        = {GE100.DCLGE_CONTROLE_INTERF_SAP.GE100_COD_IDLG}");

                /*" -1603- DISPLAY 'DTA-MOVIMENTO-LEGADO = ' GE100-DTA-MOVIMENTO-LEGADO */
                _.Display($"DTA-MOVIMENTO-LEGADO = {GE100.DCLGE_CONTROLE_INTERF_SAP.GE100_DTA_MOVIMENTO_LEGADO}");

                /*" -1604- DISPLAY 'DTA-MOVIMENTO-ARQH   = ' GE100-DTA-MOVIMENTO-ARQH */
                _.Display($"DTA-MOVIMENTO-ARQH   = {GE100.DCLGE_CONTROLE_INTERF_SAP.GE100_DTA_MOVIMENTO_ARQH}");

                /*" -1605- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1605-  END-EVALUATE.  */

                /*" -1605- END-IF. */
            }


        }

        [StopWatch]
        /*" R0440-00-INS-CTRL-INT-SAP-DB-INSERT-1 */
        public void R0440_00_INS_CTRL_INT_SAP_DB_INSERT_1()
        {
            /*" -1592- EXEC SQL INSERT INTO SEGUROS.GE_CONTROLE_INTERF_SAP ( NUM_OCORR_MOVTO , COD_IDLG , DTA_MOVIMENTO_LEGADO , DTH_GERACAO_LEGADO , DTH_GERACAO_ARQA , COD_IDE_PAGTO_SAP , COD_IDE_RECEBE_SAP , DTH_PROCESSA_ARQG , IND_ACEITE_SAP , DTA_MOVIMENTO_ARQH ) VALUES ( :GE100-NUM-OCORR-MOVTO , :GE100-COD-IDLG , :GE100-DTA-MOVIMENTO-LEGADO , CURRENT TIMESTAMP , NULL , NULL , NULL , NULL , NULL , :GE100-DTA-MOVIMENTO-ARQH) END-EXEC. */

            var r0440_00_INS_CTRL_INT_SAP_DB_INSERT_1_Insert1 = new R0440_00_INS_CTRL_INT_SAP_DB_INSERT_1_Insert1()
            {
                GE100_NUM_OCORR_MOVTO = GE100.DCLGE_CONTROLE_INTERF_SAP.GE100_NUM_OCORR_MOVTO.ToString(),
                GE100_COD_IDLG = GE100.DCLGE_CONTROLE_INTERF_SAP.GE100_COD_IDLG.ToString(),
                GE100_DTA_MOVIMENTO_LEGADO = GE100.DCLGE_CONTROLE_INTERF_SAP.GE100_DTA_MOVIMENTO_LEGADO.ToString(),
                GE100_DTA_MOVIMENTO_ARQH = GE100.DCLGE_CONTROLE_INTERF_SAP.GE100_DTA_MOVIMENTO_ARQH.ToString(),
            };

            R0440_00_INS_CTRL_INT_SAP_DB_INSERT_1_Insert1.Execute(r0440_00_INS_CTRL_INT_SAP_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0440_99_SAIDA*/

        [StopWatch]
        /*" R0450-00-MAX-RETORNO-ARQH-SECTION */
        private void R0450_00_MAX_RETORNO_ARQH_SECTION()
        {
            /*" -1646- MOVE 'R0450-00-MAX-RETORNO-ARQH' TO PARAGRAFO */
            _.Move("R0450-00-MAX-RETORNO-ARQH", WABEND.PARAGRAFO);

            /*" -1647- MOVE 'RECUPERAR SEQUENCIAL DE CONTROLE' TO COMANDO */
            _.Move("RECUPERAR SEQUENCIAL DE CONTROLE", WABEND.COMANDO);

            /*" -1649- DISPLAY PARAGRAFO */
            _.Display(WABEND.PARAGRAFO);

            /*" -1651- MOVE GE407-NUM-OCORR-MOVTO TO GE105-NUM-OCORR-MOVTO */
            _.Move(GE407.DCLGE_CONTROLE_CARTAO_CIELO.GE407_NUM_OCORR_MOVTO, GE105.DCLGE_CONTROLE_ARQH.GE105_NUM_OCORR_MOVTO);

            /*" -1657- PERFORM R0450_00_MAX_RETORNO_ARQH_DB_SELECT_1 */

            R0450_00_MAX_RETORNO_ARQH_DB_SELECT_1();

            /*" -1660- EVALUATE SQLCODE */
            switch (DB.SQLCODE.Value)
            {

                /*" -1661- WHEN  0 */
                case 0:

                    /*" -1662- CONTINUE */

                    /*" -1663- WHEN OTHER */
                    break;
                default:

                    /*" -1664- DISPLAY 'R0444-ERRO SELECT SEQUEN MAX GE_CONTROLE_ARQH' */
                    _.Display($"R0444-ERRO SELECT SEQUEN MAX GE_CONTROLE_ARQH");

                    /*" -1665- DISPLAY 'NUM_OCORR_MOVTO = ' GE105-NUM-OCORR-MOVTO */
                    _.Display($"NUM_OCORR_MOVTO = {GE105.DCLGE_CONTROLE_ARQH.GE105_NUM_OCORR_MOVTO}");

                    /*" -1666- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1666- END-EVALUATE. */
                    break;
            }


        }

        [StopWatch]
        /*" R0450-00-MAX-RETORNO-ARQH-DB-SELECT-1 */
        public void R0450_00_MAX_RETORNO_ARQH_DB_SELECT_1()
        {
            /*" -1657- EXEC SQL SELECT VALUE(MAX(SEQ_RETORNO_MOVIMENTO),0) + 1 INTO :WS-HOST-PROX-SEQ-ARQH FROM SEGUROS.GE_CONTROLE_ARQH WHERE NUM_OCORR_MOVTO = :GE105-NUM-OCORR-MOVTO WITH UR END-EXEC. */

            var r0450_00_MAX_RETORNO_ARQH_DB_SELECT_1_Query1 = new R0450_00_MAX_RETORNO_ARQH_DB_SELECT_1_Query1()
            {
                GE105_NUM_OCORR_MOVTO = GE105.DCLGE_CONTROLE_ARQH.GE105_NUM_OCORR_MOVTO.ToString(),
            };

            var executed_1 = R0450_00_MAX_RETORNO_ARQH_DB_SELECT_1_Query1.Execute(r0450_00_MAX_RETORNO_ARQH_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_HOST_PROX_SEQ_ARQH, WS_TRABALHO.WS_HOST_PROX_SEQ_ARQH);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0450_99_SAIDA*/

        [StopWatch]
        /*" R0460-00-INS-CONTROLE-ARQH-SECTION */
        private void R0460_00_INS_CONTROLE_ARQH_SECTION()
        {
            /*" -1674- MOVE 'R0460-00-INS-CONTROLE-ARQH' TO PARAGRAFO */
            _.Move("R0460-00-INS-CONTROLE-ARQH", WABEND.PARAGRAFO);

            /*" -1675- MOVE 'INSERE CONTROLE ARQ-H' TO COMANDO */
            _.Move("INSERE CONTROLE ARQ-H", WABEND.COMANDO);

            /*" -1677- DISPLAY PARAGRAFO */
            _.Display(WABEND.PARAGRAFO);

            /*" -1678- MOVE GE407-NUM-OCORR-MOVTO TO GE105-NUM-OCORR-MOVTO */
            _.Move(GE407.DCLGE_CONTROLE_CARTAO_CIELO.GE407_NUM_OCORR_MOVTO, GE105.DCLGE_CONTROLE_ARQH.GE105_NUM_OCORR_MOVTO);

            /*" -1680- MOVE WS-HOST-PROX-SEQ-ARQH TO GE105-SEQ-RETORNO-MOVIMENTO */
            _.Move(WS_TRABALHO.WS_HOST_PROX_SEQ_ARQH, GE105.DCLGE_CONTROLE_ARQH.GE105_SEQ_RETORNO_MOVIMENTO);

            /*" -1684- MOVE SISTEMAS-DATA-MOV-ABERTO TO GE105-DTA-MOVIMENTO */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, GE105.DCLGE_CONTROLE_ARQH.GE105_DTA_MOVIMENTO);

            /*" -1687- MOVE CIELO-TP-REGISTRO TO GE105-NUM-ESTRUTURA-ARQH */
            _.Move(REG_CIELO.CIELO_TP_REGISTRO, GE105.DCLGE_CONTROLE_ARQH.GE105_NUM_ESTRUTURA_ARQH);

            /*" -1688- MOVE CIELO-STA-COMPENSACAO TO GE105-STA-COMPENSACAO */
            _.Move(REG_CIELO.CIELO_STA_COMPENSACAO, GE105.DCLGE_CONTROLE_ARQH.GE105_STA_COMPENSACAO);

            /*" -1692- MOVE CIELO-NSA-SAP TO GE105-NUM-NSAS-ARQH */
            _.Move(REG_CIELO.CIELO_NSA_SAP, GE105.DCLGE_CONTROLE_ARQH.GE105_NUM_NSAS_ARQH);

            /*" -1694- MOVE CIELO-MOTIVO-COMPENSACAO TO GE105-IND-MOTIVO-COMPENSACAO */
            _.Move(REG_CIELO.CIELO_MOTIVO_COMPENSACAO, GE105.DCLGE_CONTROLE_ARQH.GE105_IND_MOTIVO_COMPENSACAO);

            /*" -1695- MOVE CIELO-NUM-FATURA TO GE105-COD-FATURA-SAP */
            _.Move(REG_CIELO.CIELO_NUM_FATURA, GE105.DCLGE_CONTROLE_ARQH.GE105_COD_FATURA_SAP);

            /*" -1696- MOVE CIELO-NUM-ITEM-FATURA TO GE105-NUM-ITEM-FATURA */
            _.Move(REG_CIELO.CIELO_NUM_ITEM_FATURA, GE105.DCLGE_CONTROLE_ARQH.GE105_NUM_ITEM_FATURA);

            /*" -1698- MOVE CIELO-NSA-BANCO TO GE105-NUM-NSAS-BANCO */
            _.Move(REG_CIELO.CIELO_NSA_BANCO, GE105.DCLGE_CONTROLE_ARQH.GE105_NUM_NSAS_BANCO);

            /*" -1724- PERFORM R0460_00_INS_CONTROLE_ARQH_DB_INSERT_1 */

            R0460_00_INS_CONTROLE_ARQH_DB_INSERT_1();

            /*" -1727-  EVALUATE SQLCODE  */

            /*" -1728-  WHEN ZEROS  */

            /*" -1728- IF   SQLCODE EQUALS  ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -1729- ADD 1 TO WS-INS-CONTR-ARQH */
                WS_CONTADORES.WS_INS_CONTR_ARQH.Value = WS_CONTADORES.WS_INS_CONTR_ARQH + 1;

                /*" -1730-  WHEN OTHER  */

                /*" -1730- ELSE */
            }
            else
            {


                /*" -1731- DISPLAY 'R0440-ERRO INSERT GE_CONTROLE_ARQH' */
                _.Display($"R0440-ERRO INSERT GE_CONTROLE_ARQH");

                /*" -1732- DISPLAY 'NUM-OCORR-MOVTO = ' GE105-NUM-OCORR-MOVTO */
                _.Display($"NUM-OCORR-MOVTO = {GE105.DCLGE_CONTROLE_ARQH.GE105_NUM_OCORR_MOVTO}");

                /*" -1733- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1733-  END-EVALUATE.  */

                /*" -1733- END-IF. */
            }


        }

        [StopWatch]
        /*" R0460-00-INS-CONTROLE-ARQH-DB-INSERT-1 */
        public void R0460_00_INS_CONTROLE_ARQH_DB_INSERT_1()
        {
            /*" -1724- EXEC SQL INSERT INTO SEGUROS.GE_CONTROLE_ARQH ( NUM_OCORR_MOVTO , SEQ_RETORNO_MOVIMENTO , DTA_MOVIMENTO , NUM_ESTRUTURA_ARQH , STA_COMPENSACAO , NUM_NSAS_ARQH , IND_MOTIVO_COMPENSACAO , COD_FATURA_SAP , NUM_ITEM_FATURA , NUM_NSAS_BANCO , DTH_CADASTRAMENTO ) VALUES ( :GE105-NUM-OCORR-MOVTO , :GE105-SEQ-RETORNO-MOVIMENTO , :GE105-DTA-MOVIMENTO , :GE105-NUM-ESTRUTURA-ARQH , :GE105-STA-COMPENSACAO , :GE105-NUM-NSAS-ARQH , :GE105-IND-MOTIVO-COMPENSACAO , :GE105-COD-FATURA-SAP , :GE105-NUM-ITEM-FATURA , :GE105-NUM-NSAS-BANCO , CURRENT TIMESTAMP ) END-EXEC */

            var r0460_00_INS_CONTROLE_ARQH_DB_INSERT_1_Insert1 = new R0460_00_INS_CONTROLE_ARQH_DB_INSERT_1_Insert1()
            {
                GE105_NUM_OCORR_MOVTO = GE105.DCLGE_CONTROLE_ARQH.GE105_NUM_OCORR_MOVTO.ToString(),
                GE105_SEQ_RETORNO_MOVIMENTO = GE105.DCLGE_CONTROLE_ARQH.GE105_SEQ_RETORNO_MOVIMENTO.ToString(),
                GE105_DTA_MOVIMENTO = GE105.DCLGE_CONTROLE_ARQH.GE105_DTA_MOVIMENTO.ToString(),
                GE105_NUM_ESTRUTURA_ARQH = GE105.DCLGE_CONTROLE_ARQH.GE105_NUM_ESTRUTURA_ARQH.ToString(),
                GE105_STA_COMPENSACAO = GE105.DCLGE_CONTROLE_ARQH.GE105_STA_COMPENSACAO.ToString(),
                GE105_NUM_NSAS_ARQH = GE105.DCLGE_CONTROLE_ARQH.GE105_NUM_NSAS_ARQH.ToString(),
                GE105_IND_MOTIVO_COMPENSACAO = GE105.DCLGE_CONTROLE_ARQH.GE105_IND_MOTIVO_COMPENSACAO.ToString(),
                GE105_COD_FATURA_SAP = GE105.DCLGE_CONTROLE_ARQH.GE105_COD_FATURA_SAP.ToString(),
                GE105_NUM_ITEM_FATURA = GE105.DCLGE_CONTROLE_ARQH.GE105_NUM_ITEM_FATURA.ToString(),
                GE105_NUM_NSAS_BANCO = GE105.DCLGE_CONTROLE_ARQH.GE105_NUM_NSAS_BANCO.ToString(),
            };

            R0460_00_INS_CONTROLE_ARQH_DB_INSERT_1_Insert1.Execute(r0460_00_INS_CONTROLE_ARQH_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0460_99_SAIDA*/

        [StopWatch]
        /*" R0470-00-MAX-HIS-RET-CA-CIELO-SECTION */
        private void R0470_00_MAX_HIS_RET_CA_CIELO_SECTION()
        {
            /*" -1741- MOVE 'R0470-00-MAX-HIS-RET-CA-CIELO' TO PARAGRAFO */
            _.Move("R0470-00-MAX-HIS-RET-CA-CIELO", WABEND.PARAGRAFO);

            /*" -1742- MOVE 'RECUPERAR SEQUENCIAL DE HISTORICO' TO COMANDO */
            _.Move("RECUPERAR SEQUENCIAL DE HISTORICO", WABEND.COMANDO);

            /*" -1744- DISPLAY PARAGRAFO */
            _.Display(WABEND.PARAGRAFO);

            /*" -1745- MOVE GE407-NUM-CERTIFICADO TO GE408-NUM-CERTIFICADO */
            _.Move(GE407.DCLGE_CONTROLE_CARTAO_CIELO.GE407_NUM_CERTIFICADO, GE408.DCLGE_RETORNO_CA_CIELO.GE408_NUM_CERTIFICADO);

            /*" -1746- MOVE GE407-NUM-PARCELA TO GE408-NUM-PARCELA */
            _.Move(GE407.DCLGE_CONTROLE_CARTAO_CIELO.GE407_NUM_PARCELA, GE408.DCLGE_RETORNO_CA_CIELO.GE408_NUM_PARCELA);

            /*" -1748- MOVE GE407-SEQ-CONTROL-CARTAO TO GE408-SEQ-CONTROL-CARTAO */
            _.Move(GE407.DCLGE_CONTROLE_CARTAO_CIELO.GE407_SEQ_CONTROL_CARTAO, GE408.DCLGE_RETORNO_CA_CIELO.GE408_SEQ_CONTROL_CARTAO);

            /*" -1756- PERFORM R0470_00_MAX_HIS_RET_CA_CIELO_DB_SELECT_1 */

            R0470_00_MAX_HIS_RET_CA_CIELO_DB_SELECT_1();

            /*" -1759- EVALUATE SQLCODE */
            switch (DB.SQLCODE.Value)
            {

                /*" -1760- WHEN  0 */
                case 0:

                    /*" -1761- CONTINUE */

                    /*" -1762- WHEN OTHER */
                    break;
                default:

                    /*" -1763- DISPLAY 'R0470-00-ERRO SELECT MAX GE_RETORNO_CA_CIELO' */
                    _.Display($"R0470-00-ERRO SELECT MAX GE_RETORNO_CA_CIELO");

                    /*" -1764- DISPLAY 'NUM-CERTIFICADO    = ' GE408-NUM-CERTIFICADO */
                    _.Display($"NUM-CERTIFICADO    = {GE408.DCLGE_RETORNO_CA_CIELO.GE408_NUM_CERTIFICADO}");

                    /*" -1765- DISPLAY 'NUM-PARCELA        = ' GE408-NUM-PARCELA */
                    _.Display($"NUM-PARCELA        = {GE408.DCLGE_RETORNO_CA_CIELO.GE408_NUM_PARCELA}");

                    /*" -1766- DISPLAY 'SEQ-CONTROL-CARTAO = ' GE408-SEQ-CONTROL-CARTAO */
                    _.Display($"SEQ-CONTROL-CARTAO = {GE408.DCLGE_RETORNO_CA_CIELO.GE408_SEQ_CONTROL_CARTAO}");

                    /*" -1767- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1769- END-EVALUATE */
                    break;
            }


            /*" -1769- . */

        }

        [StopWatch]
        /*" R0470-00-MAX-HIS-RET-CA-CIELO-DB-SELECT-1 */
        public void R0470_00_MAX_HIS_RET_CA_CIELO_DB_SELECT_1()
        {
            /*" -1756- EXEC SQL SELECT VALUE(MAX(SEQ_RET_CONTROL_HIST),0) + 1 INTO :WS-HOST-PROX-SEQ-HIST FROM SEGUROS.GE_RETORNO_CA_CIELO WHERE NUM_CERTIFICADO = :GE408-NUM-CERTIFICADO AND NUM_PARCELA = :GE408-NUM-PARCELA AND SEQ_CONTROL_CARTAO = :GE408-SEQ-CONTROL-CARTAO WITH UR END-EXEC. */

            var r0470_00_MAX_HIS_RET_CA_CIELO_DB_SELECT_1_Query1 = new R0470_00_MAX_HIS_RET_CA_CIELO_DB_SELECT_1_Query1()
            {
                GE408_SEQ_CONTROL_CARTAO = GE408.DCLGE_RETORNO_CA_CIELO.GE408_SEQ_CONTROL_CARTAO.ToString(),
                GE408_NUM_CERTIFICADO = GE408.DCLGE_RETORNO_CA_CIELO.GE408_NUM_CERTIFICADO.ToString(),
                GE408_NUM_PARCELA = GE408.DCLGE_RETORNO_CA_CIELO.GE408_NUM_PARCELA.ToString(),
            };

            var executed_1 = R0470_00_MAX_HIS_RET_CA_CIELO_DB_SELECT_1_Query1.Execute(r0470_00_MAX_HIS_RET_CA_CIELO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_HOST_PROX_SEQ_HIST, WS_TRABALHO.WS_HOST_PROX_SEQ_HIST);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0470_99_SAIDA*/

        [StopWatch]
        /*" R0500-00-INSERE-CONTROLE-CIELO-SECTION */
        private void R0500_00_INSERE_CONTROLE_CIELO_SECTION()
        {
            /*" -1777- MOVE 'R0500-00-INSERE-CONTROLE-CIELO' TO PARAGRAFO */
            _.Move("R0500-00-INSERE-CONTROLE-CIELO", WABEND.PARAGRAFO);

            /*" -1778- MOVE 'INSERE CONTROLE CARTAO CIELO' TO COMANDO */
            _.Move("INSERE CONTROLE CARTAO CIELO", WABEND.COMANDO);

            /*" -1780- DISPLAY PARAGRAFO */
            _.Display(WABEND.PARAGRAFO);

            /*" -1781- MOVE ZEROS TO GE407-NUM-PROPOSTA */
            _.Move(0, GE407.DCLGE_CONTROLE_CARTAO_CIELO.GE407_NUM_PROPOSTA);

            /*" -1782- MOVE ZEROS TO GE407-NUM-APOLICE */
            _.Move(0, GE407.DCLGE_CONTROLE_CARTAO_CIELO.GE407_NUM_APOLICE);

            /*" -1783- MOVE ZEROS TO GE407-NUM-ENDOSSO */
            _.Move(0, GE407.DCLGE_CONTROLE_CARTAO_CIELO.GE407_NUM_ENDOSSO);

            /*" -1784- MOVE WS-TP-PAGAMENTO TO GE407-COD-TP-PAGAMENTO */
            _.Move(WS_TRABALHO.WS_TP_PAGAMENTO, GE407.DCLGE_CONTROLE_CARTAO_CIELO.GE407_COD_TP_PAGAMENTO);

            /*" -1786- MOVE WS-NUM-PARCELA TO GE407-NUM-PARCELA */
            _.Move(WS_TRABALHO.WS_NUM_PARCELA, GE407.DCLGE_CONTROLE_CARTAO_CIELO.GE407_NUM_PARCELA);

            /*" -1788- MOVE PROPOVA-COD-PRODUTO TO GE407-COD-PRODUTO */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO, GE407.DCLGE_CONTROLE_CARTAO_CIELO.GE407_COD_PRODUTO);

            /*" -1789- MOVE WS-DT-VENCIMENTO TO GE407-DTA-VENCIMENTO */
            _.Move(WS_TRABALHO.WS_DT_VENCIMENTO, GE407.DCLGE_CONTROLE_CARTAO_CIELO.GE407_DTA_VENCIMENTO);

            /*" -1790- MOVE SISTEMAS-DATA-MOV-ABERTO TO GE407-DTA-MOVIMENTO */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, GE407.DCLGE_CONTROLE_CARTAO_CIELO.GE407_DTA_MOVIMENTO);

            /*" -1791- MOVE CIELO-VLR-COBRANCA TO GE407-VLR-TOT-PREMIO */
            _.Move(REG_CIELO.CIELO_VLR_COBRANCA, GE407.DCLGE_CONTROLE_CARTAO_CIELO.GE407_VLR_TOT_PREMIO);

            /*" -1792- MOVE 'VA' TO GE407-COD-SISTEMA */
            _.Move("VA", GE407.DCLGE_CONTROLE_CARTAO_CIELO.GE407_COD_SISTEMA);

            /*" -1794- MOVE 'EM8024B' TO GE407-COD-USUARIO */
            _.Move("EM8024B", GE407.DCLGE_CONTROLE_CARTAO_CIELO.GE407_COD_USUARIO);

            /*" -1832- PERFORM R0500_00_INSERE_CONTROLE_CIELO_DB_INSERT_1 */

            R0500_00_INSERE_CONTROLE_CIELO_DB_INSERT_1();

            /*" -1835-  EVALUATE SQLCODE  */

            /*" -1836-  WHEN ZEROS  */

            /*" -1836- IF   SQLCODE EQUALS  ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -1837- ADD 1 TO WS-INS-CONTR-CIELO */
                WS_CONTADORES.WS_INS_CONTR_CIELO.Value = WS_CONTADORES.WS_INS_CONTR_CIELO + 1;

                /*" -1838-  WHEN OTHER  */

                /*" -1838- ELSE */
            }
            else
            {


                /*" -1839- DISPLAY 'R0500-ERRO INSERT GE_CONTROLE_CARTAO_CIELO' */
                _.Display($"R0500-ERRO INSERT GE_CONTROLE_CARTAO_CIELO");

                /*" -1840- DISPLAY 'NUM-CERTIFICADO    = ' GE407-NUM-CERTIFICADO */
                _.Display($"NUM-CERTIFICADO    = {GE407.DCLGE_CONTROLE_CARTAO_CIELO.GE407_NUM_CERTIFICADO}");

                /*" -1841- DISPLAY 'NUM-PARCELA        = ' GE407-NUM-PARCELA */
                _.Display($"NUM-PARCELA        = {GE407.DCLGE_CONTROLE_CARTAO_CIELO.GE407_NUM_PARCELA}");

                /*" -1842- DISPLAY 'SEQ-CONTROL-CARTAO = ' GE407-SEQ-CONTROL-CARTAO */
                _.Display($"SEQ-CONTROL-CARTAO = {GE407.DCLGE_CONTROLE_CARTAO_CIELO.GE407_SEQ_CONTROL_CARTAO}");

                /*" -1843- DISPLAY 'NUM-PROPOSTA       = ' GE407-NUM-PROPOSTA */
                _.Display($"NUM-PROPOSTA       = {GE407.DCLGE_CONTROLE_CARTAO_CIELO.GE407_NUM_PROPOSTA}");

                /*" -1844- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1844-  END-EVALUATE.  */

                /*" -1844- END-IF. */
            }


        }

        [StopWatch]
        /*" R0500-00-INSERE-CONTROLE-CIELO-DB-INSERT-1 */
        public void R0500_00_INSERE_CONTROLE_CIELO_DB_INSERT_1()
        {
            /*" -1832- EXEC SQL INSERT INTO SEGUROS.GE_CONTROLE_CARTAO_CIELO ( NUM_PROPOSTA , NUM_CERTIFICADO , NUM_PARCELA , NUM_APOLICE , NUM_ENDOSSO , SEQ_CONTROL_CARTAO , COD_TP_PAGAMENTO , COD_IDLG , NUM_OCORR_MOVTO , COD_PRODUTO , DTA_VENCIMENTO , DTA_MOVIMENTO , VLR_TOT_PREMIO , COD_SISTEMA , COD_USUARIO , STA_REGISTRO , DTH_PROCESSAMENTO ) VALUES ( :GE407-NUM-PROPOSTA , :GE407-NUM-CERTIFICADO , :GE407-NUM-PARCELA , :GE407-NUM-APOLICE , :GE407-NUM-ENDOSSO , :GE407-SEQ-CONTROL-CARTAO , :GE407-COD-TP-PAGAMENTO , :GE407-COD-IDLG , :GE407-NUM-OCORR-MOVTO , :GE407-COD-PRODUTO , :GE407-DTA-VENCIMENTO , :GE407-DTA-MOVIMENTO , :GE407-VLR-TOT-PREMIO , :GE407-COD-SISTEMA , :GE407-COD-USUARIO , :GE407-STA-REGISTRO , CURRENT TIMESTAMP ) END-EXEC */

            var r0500_00_INSERE_CONTROLE_CIELO_DB_INSERT_1_Insert1 = new R0500_00_INSERE_CONTROLE_CIELO_DB_INSERT_1_Insert1()
            {
                GE407_NUM_PROPOSTA = GE407.DCLGE_CONTROLE_CARTAO_CIELO.GE407_NUM_PROPOSTA.ToString(),
                GE407_NUM_CERTIFICADO = GE407.DCLGE_CONTROLE_CARTAO_CIELO.GE407_NUM_CERTIFICADO.ToString(),
                GE407_NUM_PARCELA = GE407.DCLGE_CONTROLE_CARTAO_CIELO.GE407_NUM_PARCELA.ToString(),
                GE407_NUM_APOLICE = GE407.DCLGE_CONTROLE_CARTAO_CIELO.GE407_NUM_APOLICE.ToString(),
                GE407_NUM_ENDOSSO = GE407.DCLGE_CONTROLE_CARTAO_CIELO.GE407_NUM_ENDOSSO.ToString(),
                GE407_SEQ_CONTROL_CARTAO = GE407.DCLGE_CONTROLE_CARTAO_CIELO.GE407_SEQ_CONTROL_CARTAO.ToString(),
                GE407_COD_TP_PAGAMENTO = GE407.DCLGE_CONTROLE_CARTAO_CIELO.GE407_COD_TP_PAGAMENTO.ToString(),
                GE407_COD_IDLG = GE407.DCLGE_CONTROLE_CARTAO_CIELO.GE407_COD_IDLG.ToString(),
                GE407_NUM_OCORR_MOVTO = GE407.DCLGE_CONTROLE_CARTAO_CIELO.GE407_NUM_OCORR_MOVTO.ToString(),
                GE407_COD_PRODUTO = GE407.DCLGE_CONTROLE_CARTAO_CIELO.GE407_COD_PRODUTO.ToString(),
                GE407_DTA_VENCIMENTO = GE407.DCLGE_CONTROLE_CARTAO_CIELO.GE407_DTA_VENCIMENTO.ToString(),
                GE407_DTA_MOVIMENTO = GE407.DCLGE_CONTROLE_CARTAO_CIELO.GE407_DTA_MOVIMENTO.ToString(),
                GE407_VLR_TOT_PREMIO = GE407.DCLGE_CONTROLE_CARTAO_CIELO.GE407_VLR_TOT_PREMIO.ToString(),
                GE407_COD_SISTEMA = GE407.DCLGE_CONTROLE_CARTAO_CIELO.GE407_COD_SISTEMA.ToString(),
                GE407_COD_USUARIO = GE407.DCLGE_CONTROLE_CARTAO_CIELO.GE407_COD_USUARIO.ToString(),
                GE407_STA_REGISTRO = GE407.DCLGE_CONTROLE_CARTAO_CIELO.GE407_STA_REGISTRO.ToString(),
            };

            R0500_00_INSERE_CONTROLE_CIELO_DB_INSERT_1_Insert1.Execute(r0500_00_INSERE_CONTROLE_CIELO_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0500_99_SAIDA*/

        [StopWatch]
        /*" R0510-00-CONSULTA-PROPOSTASVA-SECTION */
        private void R0510_00_CONSULTA_PROPOSTASVA_SECTION()
        {
            /*" -1852- MOVE 'R0510-00-CONSULTA-PROPOSTASVA' TO PARAGRAFO */
            _.Move("R0510-00-CONSULTA-PROPOSTASVA", WABEND.PARAGRAFO);

            /*" -1853- MOVE 'CONSULTA SITUACAO SEGURO' TO COMANDO */
            _.Move("CONSULTA SITUACAO SEGURO", WABEND.COMANDO);

            /*" -1855- DISPLAY PARAGRAFO */
            _.Display(WABEND.PARAGRAFO);

            /*" -1857- MOVE CIELO-NUM-PROPOSTA TO PROPOVA-NUM-CERTIFICADO */
            _.Move(REG_CIELO.CIELO_NUM_PROPOSTA, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO);

            /*" -1865- PERFORM R0510_00_CONSULTA_PROPOSTASVA_DB_SELECT_1 */

            R0510_00_CONSULTA_PROPOSTASVA_DB_SELECT_1();

            /*" -1868- EVALUATE SQLCODE */
            switch (DB.SQLCODE.Value)
            {

                /*" -1869- WHEN 0 */
                case 0:

                    /*" -1870- MOVE 'S' TO WS-ACHOU-PROPOSTAVA */
                    _.Move("S", WS_TRABALHO.WS_ACHOU_PROPOSTAVA);

                    /*" -1871- WHEN +100 */
                    break;
                case +100:

                    /*" -1873- IF CIELO-COD-MOVIMENTO EQUAL 'PA' AND CIELO-COD-RETORNO EQUAL ' 17' */

                    if (REG_CIELO.CIELO_COD_MOVIMENTO == "PA" && REG_CIELO.CIELO_COD_RETORNO == " 17")
                    {

                        /*" -1874- MOVE 'N' TO WS-ACHOU-PROPOSTAVA */
                        _.Move("N", WS_TRABALHO.WS_ACHOU_PROPOSTAVA);

                        /*" -1875- ELSE */
                    }
                    else
                    {


                        /*" -1876- DISPLAY 'R0510-00-CODIGO PRODUTO NAO ENCONTRADO ' */
                        _.Display($"R0510-00-CODIGO PRODUTO NAO ENCONTRADO ");

                        /*" -1877- DISPLAY 'NUM_CERTIFICADO = ' PROPOVA-NUM-CERTIFICADO */
                        _.Display($"NUM_CERTIFICADO = {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                        /*" -1878- GO TO R9999-00-ROT-ERRO */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;

                        /*" -1879- END-IF */
                    }


                    /*" -1880- WHEN OTHER */
                    break;
                default:

                    /*" -1881- DISPLAY 'R0510-00 - FALHA AO ACESSAR A PROPOSTAS_VA' */
                    _.Display($"R0510-00 - FALHA AO ACESSAR A PROPOSTAS_VA");

                    /*" -1882- DISPLAY 'NUM_CERTIFICADO = ' PROPOVA-NUM-CERTIFICADO */
                    _.Display($"NUM_CERTIFICADO = {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                    /*" -1883- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1885- END-EVALUATE */
                    break;
            }


            /*" -1885- . */

        }

        [StopWatch]
        /*" R0510-00-CONSULTA-PROPOSTASVA-DB-SELECT-1 */
        public void R0510_00_CONSULTA_PROPOSTASVA_DB_SELECT_1()
        {
            /*" -1865- EXEC SQL SELECT A.COD_PRODUTO , A.SIT_REGISTRO INTO :PROPOVA-COD-PRODUTO , :PROPOVA-SIT-REGISTRO FROM SEGUROS.PROPOSTAS_VA A WHERE A.NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO WITH UR END-EXEC */

            var r0510_00_CONSULTA_PROPOSTASVA_DB_SELECT_1_Query1 = new R0510_00_CONSULTA_PROPOSTASVA_DB_SELECT_1_Query1()
            {
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = R0510_00_CONSULTA_PROPOSTASVA_DB_SELECT_1_Query1.Execute(r0510_00_CONSULTA_PROPOSTASVA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PROPOVA_COD_PRODUTO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO);
                _.Move(executed_1.PROPOVA_SIT_REGISTRO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_SIT_REGISTRO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0510_99_SAIDA*/

        [StopWatch]
        /*" R0520-00-UPDATE-CONTROLE-CIELO-SECTION */
        private void R0520_00_UPDATE_CONTROLE_CIELO_SECTION()
        {
            /*" -1893- MOVE 'R0520-00-UPDATE-CONTROLE-CIELO' TO PARAGRAFO */
            _.Move("R0520-00-UPDATE-CONTROLE-CIELO", WABEND.PARAGRAFO);

            /*" -1894- MOVE 'ATUALIZA CONTROLE CARTAO CIELO' TO COMANDO */
            _.Move("ATUALIZA CONTROLE CARTAO CIELO", WABEND.COMANDO);

            /*" -1896- DISPLAY PARAGRAFO */
            _.Display(WABEND.PARAGRAFO);

            /*" -1898- MOVE SISTEMAS-DATA-MOV-ABERTO TO GE407-DTA-MOVIMENTO */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, GE407.DCLGE_CONTROLE_CARTAO_CIELO.GE407_DTA_MOVIMENTO);

            /*" -1908- PERFORM R0520_00_UPDATE_CONTROLE_CIELO_DB_UPDATE_1 */

            R0520_00_UPDATE_CONTROLE_CIELO_DB_UPDATE_1();

            /*" -1911-  EVALUATE SQLCODE  */

            /*" -1912-  WHEN ZEROS  */

            /*" -1912- IF   SQLCODE EQUALS  ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -1913- ADD 1 TO WS-UPT-CONTR-CIELO */
                WS_CONTADORES.WS_UPT_CONTR_CIELO.Value = WS_CONTADORES.WS_UPT_CONTR_CIELO + 1;

                /*" -1914-  WHEN OTHER  */

                /*" -1914- ELSE */
            }
            else
            {


                /*" -1915- DISPLAY 'R0500-ERRO INSERT GE_CONTROLE_CARTAO_CIELO' */
                _.Display($"R0500-ERRO INSERT GE_CONTROLE_CARTAO_CIELO");

                /*" -1916- DISPLAY 'NUM-CERTIFICADO    = ' GE407-NUM-CERTIFICADO */
                _.Display($"NUM-CERTIFICADO    = {GE407.DCLGE_CONTROLE_CARTAO_CIELO.GE407_NUM_CERTIFICADO}");

                /*" -1917- DISPLAY 'NUM-PARCELA        = ' GE407-NUM-PARCELA */
                _.Display($"NUM-PARCELA        = {GE407.DCLGE_CONTROLE_CARTAO_CIELO.GE407_NUM_PARCELA}");

                /*" -1918- DISPLAY 'NUM-PROPOSTA       = ' GE407-NUM-PROPOSTA */
                _.Display($"NUM-PROPOSTA       = {GE407.DCLGE_CONTROLE_CARTAO_CIELO.GE407_NUM_PROPOSTA}");

                /*" -1919- DISPLAY 'SEQ-CONTROL-CARTAO = ' GE407-SEQ-CONTROL-CARTAO */
                _.Display($"SEQ-CONTROL-CARTAO = {GE407.DCLGE_CONTROLE_CARTAO_CIELO.GE407_SEQ_CONTROL_CARTAO}");

                /*" -1920- DISPLAY 'NUM-OCORR-MOVTO    = ' GE407-NUM-OCORR-MOVTO */
                _.Display($"NUM-OCORR-MOVTO    = {GE407.DCLGE_CONTROLE_CARTAO_CIELO.GE407_NUM_OCORR_MOVTO}");

                /*" -1921- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1921-  END-EVALUATE.  */

                /*" -1921- END-IF. */
            }


        }

        [StopWatch]
        /*" R0520-00-UPDATE-CONTROLE-CIELO-DB-UPDATE-1 */
        public void R0520_00_UPDATE_CONTROLE_CIELO_DB_UPDATE_1()
        {
            /*" -1908- EXEC SQL UPDATE SEGUROS.GE_CONTROLE_CARTAO_CIELO SET STA_REGISTRO = :GE407-STA-REGISTRO , DTA_MOVIMENTO = :GE407-DTA-MOVIMENTO , DTH_PROCESSAMENTO = CURRENT TIMESTAMP WHERE NUM_CERTIFICADO = :GE407-NUM-CERTIFICADO AND NUM_PARCELA = :GE407-NUM-PARCELA AND NUM_PROPOSTA = :GE407-NUM-PROPOSTA AND SEQ_CONTROL_CARTAO = :GE407-SEQ-CONTROL-CARTAO AND NUM_OCORR_MOVTO = :GE407-NUM-OCORR-MOVTO END-EXEC */

            var r0520_00_UPDATE_CONTROLE_CIELO_DB_UPDATE_1_Update1 = new R0520_00_UPDATE_CONTROLE_CIELO_DB_UPDATE_1_Update1()
            {
                GE407_DTA_MOVIMENTO = GE407.DCLGE_CONTROLE_CARTAO_CIELO.GE407_DTA_MOVIMENTO.ToString(),
                GE407_STA_REGISTRO = GE407.DCLGE_CONTROLE_CARTAO_CIELO.GE407_STA_REGISTRO.ToString(),
                GE407_SEQ_CONTROL_CARTAO = GE407.DCLGE_CONTROLE_CARTAO_CIELO.GE407_SEQ_CONTROL_CARTAO.ToString(),
                GE407_NUM_CERTIFICADO = GE407.DCLGE_CONTROLE_CARTAO_CIELO.GE407_NUM_CERTIFICADO.ToString(),
                GE407_NUM_OCORR_MOVTO = GE407.DCLGE_CONTROLE_CARTAO_CIELO.GE407_NUM_OCORR_MOVTO.ToString(),
                GE407_NUM_PROPOSTA = GE407.DCLGE_CONTROLE_CARTAO_CIELO.GE407_NUM_PROPOSTA.ToString(),
                GE407_NUM_PARCELA = GE407.DCLGE_CONTROLE_CARTAO_CIELO.GE407_NUM_PARCELA.ToString(),
            };

            R0520_00_UPDATE_CONTROLE_CIELO_DB_UPDATE_1_Update1.Execute(r0520_00_UPDATE_CONTROLE_CIELO_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0520_99_SAIDA*/

        [StopWatch]
        /*" R0550-00-INS-RETORNO-CA-CIELO-SECTION */
        private void R0550_00_INS_RETORNO_CA_CIELO_SECTION()
        {
            /*" -1929- MOVE 'R0550-00-INS-RETORNO-CA-CIELO' TO PARAGRAFO */
            _.Move("R0550-00-INS-RETORNO-CA-CIELO", WABEND.PARAGRAFO);

            /*" -1930- MOVE 'INSERE RETORNO_CA_CIELO' TO COMANDO */
            _.Move("INSERE RETORNO_CA_CIELO", WABEND.COMANDO);

            /*" -1932- DISPLAY PARAGRAFO */
            _.Display(WABEND.PARAGRAFO);

            /*" -1933- MOVE GE407-NUM-CERTIFICADO TO GE408-NUM-CERTIFICADO */
            _.Move(GE407.DCLGE_CONTROLE_CARTAO_CIELO.GE407_NUM_CERTIFICADO, GE408.DCLGE_RETORNO_CA_CIELO.GE408_NUM_CERTIFICADO);

            /*" -1934- MOVE GE407-NUM-PARCELA TO GE408-NUM-PARCELA */
            _.Move(GE407.DCLGE_CONTROLE_CARTAO_CIELO.GE407_NUM_PARCELA, GE408.DCLGE_RETORNO_CA_CIELO.GE408_NUM_PARCELA);

            /*" -1937- MOVE ZEROS TO GE408-NUM-APOLICE GE408-NUM-ENDOSSO GE408-NUM-PROPOSTA */
            _.Move(0, GE408.DCLGE_RETORNO_CA_CIELO.GE408_NUM_APOLICE, GE408.DCLGE_RETORNO_CA_CIELO.GE408_NUM_ENDOSSO, GE408.DCLGE_RETORNO_CA_CIELO.GE408_NUM_PROPOSTA);

            /*" -1938- MOVE GE407-SEQ-CONTROL-CARTAO TO GE408-SEQ-CONTROL-CARTAO */
            _.Move(GE407.DCLGE_CONTROLE_CARTAO_CIELO.GE407_SEQ_CONTROL_CARTAO, GE408.DCLGE_RETORNO_CA_CIELO.GE408_SEQ_CONTROL_CARTAO);

            /*" -1939- MOVE WS-HOST-PROX-SEQ-HIST TO GE408-SEQ-RET-CONTROL-HIST */
            _.Move(WS_TRABALHO.WS_HOST_PROX_SEQ_HIST, GE408.DCLGE_RETORNO_CA_CIELO.GE408_SEQ_RET_CONTROL_HIST);

            /*" -1940- MOVE SISTEMAS-DATA-MOV-ABERTO TO GE408-DTA-MOVIMENTO */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, GE408.DCLGE_RETORNO_CA_CIELO.GE408_DTA_MOVIMENTO);

            /*" -1941- MOVE CIELO-NUM-COM-CIELO TO GE408-NUM-COM-CIELO */
            _.Move(REG_CIELO.CIELO_NUM_COM_CIELO, GE408.DCLGE_RETORNO_CA_CIELO.GE408_NUM_COM_CIELO);

            /*" -1942- MOVE CIELO-COD-BCO-CRED TO GE408-COD-BCO-CRED */
            _.Move(REG_CIELO.CIELO_COD_BCO_CRED, GE408.DCLGE_RETORNO_CA_CIELO.GE408_COD_BCO_CRED);

            /*" -1943- MOVE CIELO-COD-AGE-CRED TO GE408-NUM-AGE-CRED */
            _.Move(REG_CIELO.CIELO_COD_AGE_CRED, GE408.DCLGE_RETORNO_CA_CIELO.GE408_NUM_AGE_CRED);

            /*" -1944- MOVE CIELO-NUM-CTA-CRED TO GE408-NUM-CTA-CRED */
            _.Move(REG_CIELO.CIELO_NUM_CTA_CRED, GE408.DCLGE_RETORNO_CA_CIELO.GE408_NUM_CTA_CRED);

            /*" -1945- MOVE CIELO-DIG-CTA-CRED TO GE408-NUM-DIG-CTA-CRED */
            _.Move(REG_CIELO.CIELO_DIG_CTA_CRED, GE408.DCLGE_RETORNO_CA_CIELO.GE408_NUM_DIG_CTA_CRED);

            /*" -1946- MOVE CIELO-COD-CART-BANDEIRA TO GE408-COD-CART-BANDEIRA */
            _.Move(REG_CIELO.CIELO_COD_CART_BANDEIRA, GE408.DCLGE_RETORNO_CA_CIELO.GE408_COD_CART_BANDEIRA);

            /*" -1947- MOVE CIELO-NUM-CARTAO TO GE408-NUM-CARTAO */
            _.Move(REG_CIELO.CIELO_NUM_CARTAO, GE408.DCLGE_RETORNO_CA_CIELO.GE408_NUM_CARTAO);

            /*" -1948- MOVE CIELO-COD-TOKEN-CARTAO TO GE408-COD-TOKEN-CARTAO */
            _.Move(REG_CIELO.CIELO_COD_TOKEN_CARTAO, GE408.DCLGE_RETORNO_CA_CIELO.GE408_COD_TOKEN_CARTAO);

            /*" -1949- MOVE CIELO-STA-CART-PADRAO TO GE408-STA-CART-PADRAO-SAP */
            _.Move(REG_CIELO.CIELO_STA_CART_PADRAO, GE408.DCLGE_RETORNO_CA_CIELO.GE408_STA_CART_PADRAO_SAP);

            /*" -1950- MOVE CIELO-COD-TID-CIELO TO GE408-COD-TID-CIELO */
            _.Move(REG_CIELO.CIELO_COD_TID_CIELO, GE408.DCLGE_RETORNO_CA_CIELO.GE408_COD_TID_CIELO);

            /*" -1951- MOVE CIELO-VLR-COBRANCA TO GE408-VLR-COBRANCA */
            _.Move(REG_CIELO.CIELO_VLR_COBRANCA, GE408.DCLGE_RETORNO_CA_CIELO.GE408_VLR_COBRANCA);

            /*" -1952- MOVE CIELO-VLR-LIQUIDO TO GE408-VLR-LIQUIDO */
            _.Move(REG_CIELO.CIELO_VLR_LIQUIDO, GE408.DCLGE_RETORNO_CA_CIELO.GE408_VLR_LIQUIDO);

            /*" -1953- MOVE CIELO-VLR-TAX-ADM TO GE408-VLR-TAX-ADM */
            _.Move(REG_CIELO.CIELO_VLR_TAX_ADM, GE408.DCLGE_RETORNO_CA_CIELO.GE408_VLR_TAX_ADM);

            /*" -1954- MOVE WS-DT-VENCIMENTO TO GE408-DTA-VENCIMENTO */
            _.Move(WS_TRABALHO.WS_DT_VENCIMENTO, GE408.DCLGE_RETORNO_CA_CIELO.GE408_DTA_VENCIMENTO);

            /*" -1955- MOVE WS-DT-CREDITO TO GE408-DTA-CREDITO */
            _.Move(WS_TRABALHO.WS_DT_CREDITO, GE408.DCLGE_RETORNO_CA_CIELO.GE408_DTA_CREDITO);

            /*" -1956- MOVE WS-DT-TARIFA TO GE408-DTA-DEB-TARIFA-ADM */
            _.Move(WS_TRABALHO.WS_DT_TARIFA, GE408.DCLGE_RETORNO_CA_CIELO.GE408_DTA_DEB_TARIFA_ADM);

            /*" -1957- MOVE WS-DT-CAPTURA TO GE408-DTA-AJU-CAPTURA */
            _.Move(WS_TRABALHO.WS_DT_CAPTURA, GE408.DCLGE_RETORNO_CA_CIELO.GE408_DTA_AJU_CAPTURA);

            /*" -1958- MOVE CIELO-COD-MOVIMENTO TO GE408-COD-MOVIMENTO */
            _.Move(REG_CIELO.CIELO_COD_MOVIMENTO, GE408.DCLGE_RETORNO_CA_CIELO.GE408_COD_MOVIMENTO);

            /*" -1959- MOVE CIELO-COD-RETORNO TO GE408-COD-RETORNO */
            _.Move(REG_CIELO.CIELO_COD_RETORNO, GE408.DCLGE_RETORNO_CA_CIELO.GE408_COD_RETORNO);

            /*" -1961- MOVE 'EM8024B' TO GE408-COD-USUARIO */
            _.Move("EM8024B", GE408.DCLGE_RETORNO_CA_CIELO.GE408_COD_USUARIO);

            /*" -1962- IF CIELO-PROC-ADVERT EQUAL SPACES */

            if (REG_CIELO.CIELO_PROC_ADVERT.IsEmpty())
            {

                /*" -1963- MOVE -1 TO VIND-PROC-ADVERT */
                _.Move(-1, VIND_PROC_ADVERT);

                /*" -1964- ELSE */
            }
            else
            {


                /*" -1965- MOVE ZEROS TO VIND-PROC-ADVERT */
                _.Move(0, VIND_PROC_ADVERT);

                /*" -1966- END-IF */
            }


            /*" -1967- IF CIELO-NIVE-ADVERT EQUAL SPACES */

            if (REG_CIELO.CIELO_NIVE_ADVERT.IsEmpty())
            {

                /*" -1968- MOVE -1 TO VIND-NIVE-ADVERT */
                _.Move(-1, VIND_NIVE_ADVERT);

                /*" -1969- ELSE */
            }
            else
            {


                /*" -1970- MOVE ZEROS TO VIND-NIVE-ADVERT */
                _.Move(0, VIND_NIVE_ADVERT);

                /*" -1972- END-IF */
            }


            /*" -1974- MOVE CIELO-PROC-ADVERT TO GE408-COD-PROCE-ADVERTENCIA */
            _.Move(REG_CIELO.CIELO_PROC_ADVERT, GE408.DCLGE_RETORNO_CA_CIELO.GE408_COD_PROCE_ADVERTENCIA);

            /*" -1977- MOVE CIELO-NIVE-ADVERT TO GE408-COD-NIVEL-ADVERTENCIA */
            _.Move(REG_CIELO.CIELO_NIVE_ADVERT, GE408.DCLGE_RETORNO_CA_CIELO.GE408_COD_NIVEL_ADVERTENCIA);

            /*" -2043- PERFORM R0550_00_INS_RETORNO_CA_CIELO_DB_INSERT_1 */

            R0550_00_INS_RETORNO_CA_CIELO_DB_INSERT_1();

            /*" -2046-  EVALUATE SQLCODE  */

            /*" -2047-  WHEN ZEROS  */

            /*" -2047- IF   SQLCODE EQUALS  ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -2048- ADD 1 TO WS-INS-RETORNO-CIELO */
                WS_CONTADORES.WS_INS_RETORNO_CIELO.Value = WS_CONTADORES.WS_INS_RETORNO_CIELO + 1;

                /*" -2052-  WHEN -530  */

                /*" -2052- ELSE IF   SQLCODE EQUALS  -530 */
            }
            else

            if (DB.SQLCODE == -530)
            {

                /*" -2053- PERFORM R0560-00-TRATAR-NOVO-COD-RET */

                R0560_00_TRATAR_NOVO_COD_RET_SECTION();

                /*" -2054- GO TO R0550-00-INS-RETORNO-CA-CIELO */
                new Task(() => R0550_00_INS_RETORNO_CA_CIELO_SECTION()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...

                /*" -2055-  WHEN OTHER  */

                /*" -2055- ELSE */
            }
            else
            {


                /*" -2056- DISPLAY 'R0550-ERRO INSERT GE_RETORNO_CA_CIELO' */
                _.Display($"R0550-ERRO INSERT GE_RETORNO_CA_CIELO");

                /*" -2057- DISPLAY 'NUM-CERTIFICADO      = ' GE408-NUM-CERTIFICADO */
                _.Display($"NUM-CERTIFICADO      = {GE408.DCLGE_RETORNO_CA_CIELO.GE408_NUM_CERTIFICADO}");

                /*" -2058- DISPLAY 'NUM-PARCELA          = ' GE408-NUM-PARCELA */
                _.Display($"NUM-PARCELA          = {GE408.DCLGE_RETORNO_CA_CIELO.GE408_NUM_PARCELA}");

                /*" -2059- DISPLAY 'SEQ-CONTROL-CARTAO   = ' GE408-SEQ-CONTROL-CARTAO */
                _.Display($"SEQ-CONTROL-CARTAO   = {GE408.DCLGE_RETORNO_CA_CIELO.GE408_SEQ_CONTROL_CARTAO}");

                /*" -2060- DISPLAY 'NUM-PROPOSTA         = ' GE408-NUM-PROPOSTA */
                _.Display($"NUM-PROPOSTA         = {GE408.DCLGE_RETORNO_CA_CIELO.GE408_NUM_PROPOSTA}");

                /*" -2062- DISPLAY 'SEQ-RET-CONTROL-HIST = ' GE408-SEQ-RET-CONTROL-HIST */
                _.Display($"SEQ-RET-CONTROL-HIST = {GE408.DCLGE_RETORNO_CA_CIELO.GE408_SEQ_RET_CONTROL_HIST}");

                /*" -2063- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2063-  END-EVALUATE.  */

                /*" -2063- END-IF. */
            }


        }

        [StopWatch]
        /*" R0550-00-INS-RETORNO-CA-CIELO-DB-INSERT-1 */
        public void R0550_00_INS_RETORNO_CA_CIELO_DB_INSERT_1()
        {
            /*" -2043- EXEC SQL INSERT INTO SEGUROS.GE_RETORNO_CA_CIELO ( NUM_PROPOSTA , NUM_CERTIFICADO , NUM_PARCELA , NUM_APOLICE , NUM_ENDOSSO , SEQ_CONTROL_CARTAO , SEQ_RET_CONTROL_HIST , DTA_MOVIMENTO , NUM_COM_CIELO , COD_BCO_CRED , NUM_AGE_CRED , NUM_CTA_CRED , NUM_DIG_CTA_CRED , COD_CART_BANDEIRA , NUM_CARTAO , COD_TOKEN_CARTAO , STA_CART_PADRAO_SAP , COD_TID_CIELO , VLR_COBRANCA , VLR_LIQUIDO , VLR_TAX_ADM , DTA_VENCIMENTO , DTA_CREDITO , DTA_DEB_TARIFA_ADM , DTA_AJU_CAPTURA , COD_MOVIMENTO , COD_RETORNO , COD_USUARIO , DTH_PROCESSAMENTO , COD_PROCE_ADVERTENCIA , COD_NIVEL_ADVERTENCIA ) VALUES ( :GE408-NUM-PROPOSTA , :GE408-NUM-CERTIFICADO , :GE408-NUM-PARCELA , :GE408-NUM-APOLICE , :GE408-NUM-ENDOSSO , :GE408-SEQ-CONTROL-CARTAO , :GE408-SEQ-RET-CONTROL-HIST , :GE408-DTA-MOVIMENTO , :GE408-NUM-COM-CIELO , :GE408-COD-BCO-CRED , :GE408-NUM-AGE-CRED , :GE408-NUM-CTA-CRED , :GE408-NUM-DIG-CTA-CRED , :GE408-COD-CART-BANDEIRA , :GE408-NUM-CARTAO , :GE408-COD-TOKEN-CARTAO , :GE408-STA-CART-PADRAO-SAP , :GE408-COD-TID-CIELO , :GE408-VLR-COBRANCA , :GE408-VLR-LIQUIDO , :GE408-VLR-TAX-ADM , :GE408-DTA-VENCIMENTO , :GE408-DTA-CREDITO , :GE408-DTA-DEB-TARIFA-ADM , :GE408-DTA-AJU-CAPTURA , :GE408-COD-MOVIMENTO , :GE408-COD-RETORNO , :GE408-COD-USUARIO , CURRENT TIMESTAMP , :GE408-COD-PROCE-ADVERTENCIA:VIND-PROC-ADVERT , :GE408-COD-NIVEL-ADVERTENCIA:VIND-NIVE-ADVERT ) END-EXEC */

            var r0550_00_INS_RETORNO_CA_CIELO_DB_INSERT_1_Insert1 = new R0550_00_INS_RETORNO_CA_CIELO_DB_INSERT_1_Insert1()
            {
                GE408_NUM_PROPOSTA = GE408.DCLGE_RETORNO_CA_CIELO.GE408_NUM_PROPOSTA.ToString(),
                GE408_NUM_CERTIFICADO = GE408.DCLGE_RETORNO_CA_CIELO.GE408_NUM_CERTIFICADO.ToString(),
                GE408_NUM_PARCELA = GE408.DCLGE_RETORNO_CA_CIELO.GE408_NUM_PARCELA.ToString(),
                GE408_NUM_APOLICE = GE408.DCLGE_RETORNO_CA_CIELO.GE408_NUM_APOLICE.ToString(),
                GE408_NUM_ENDOSSO = GE408.DCLGE_RETORNO_CA_CIELO.GE408_NUM_ENDOSSO.ToString(),
                GE408_SEQ_CONTROL_CARTAO = GE408.DCLGE_RETORNO_CA_CIELO.GE408_SEQ_CONTROL_CARTAO.ToString(),
                GE408_SEQ_RET_CONTROL_HIST = GE408.DCLGE_RETORNO_CA_CIELO.GE408_SEQ_RET_CONTROL_HIST.ToString(),
                GE408_DTA_MOVIMENTO = GE408.DCLGE_RETORNO_CA_CIELO.GE408_DTA_MOVIMENTO.ToString(),
                GE408_NUM_COM_CIELO = GE408.DCLGE_RETORNO_CA_CIELO.GE408_NUM_COM_CIELO.ToString(),
                GE408_COD_BCO_CRED = GE408.DCLGE_RETORNO_CA_CIELO.GE408_COD_BCO_CRED.ToString(),
                GE408_NUM_AGE_CRED = GE408.DCLGE_RETORNO_CA_CIELO.GE408_NUM_AGE_CRED.ToString(),
                GE408_NUM_CTA_CRED = GE408.DCLGE_RETORNO_CA_CIELO.GE408_NUM_CTA_CRED.ToString(),
                GE408_NUM_DIG_CTA_CRED = GE408.DCLGE_RETORNO_CA_CIELO.GE408_NUM_DIG_CTA_CRED.ToString(),
                GE408_COD_CART_BANDEIRA = GE408.DCLGE_RETORNO_CA_CIELO.GE408_COD_CART_BANDEIRA.ToString(),
                GE408_NUM_CARTAO = GE408.DCLGE_RETORNO_CA_CIELO.GE408_NUM_CARTAO.ToString(),
                GE408_COD_TOKEN_CARTAO = GE408.DCLGE_RETORNO_CA_CIELO.GE408_COD_TOKEN_CARTAO.ToString(),
                GE408_STA_CART_PADRAO_SAP = GE408.DCLGE_RETORNO_CA_CIELO.GE408_STA_CART_PADRAO_SAP.ToString(),
                GE408_COD_TID_CIELO = GE408.DCLGE_RETORNO_CA_CIELO.GE408_COD_TID_CIELO.ToString(),
                GE408_VLR_COBRANCA = GE408.DCLGE_RETORNO_CA_CIELO.GE408_VLR_COBRANCA.ToString(),
                GE408_VLR_LIQUIDO = GE408.DCLGE_RETORNO_CA_CIELO.GE408_VLR_LIQUIDO.ToString(),
                GE408_VLR_TAX_ADM = GE408.DCLGE_RETORNO_CA_CIELO.GE408_VLR_TAX_ADM.ToString(),
                GE408_DTA_VENCIMENTO = GE408.DCLGE_RETORNO_CA_CIELO.GE408_DTA_VENCIMENTO.ToString(),
                GE408_DTA_CREDITO = GE408.DCLGE_RETORNO_CA_CIELO.GE408_DTA_CREDITO.ToString(),
                GE408_DTA_DEB_TARIFA_ADM = GE408.DCLGE_RETORNO_CA_CIELO.GE408_DTA_DEB_TARIFA_ADM.ToString(),
                GE408_DTA_AJU_CAPTURA = GE408.DCLGE_RETORNO_CA_CIELO.GE408_DTA_AJU_CAPTURA.ToString(),
                GE408_COD_MOVIMENTO = GE408.DCLGE_RETORNO_CA_CIELO.GE408_COD_MOVIMENTO.ToString(),
                GE408_COD_RETORNO = GE408.DCLGE_RETORNO_CA_CIELO.GE408_COD_RETORNO.ToString(),
                GE408_COD_USUARIO = GE408.DCLGE_RETORNO_CA_CIELO.GE408_COD_USUARIO.ToString(),
                GE408_COD_PROCE_ADVERTENCIA = GE408.DCLGE_RETORNO_CA_CIELO.GE408_COD_PROCE_ADVERTENCIA.ToString(),
                VIND_PROC_ADVERT = VIND_PROC_ADVERT.ToString(),
                GE408_COD_NIVEL_ADVERTENCIA = GE408.DCLGE_RETORNO_CA_CIELO.GE408_COD_NIVEL_ADVERTENCIA.ToString(),
                VIND_NIVE_ADVERT = VIND_NIVE_ADVERT.ToString(),
            };

            R0550_00_INS_RETORNO_CA_CIELO_DB_INSERT_1_Insert1.Execute(r0550_00_INS_RETORNO_CA_CIELO_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0550_99_SAIDA*/

        [StopWatch]
        /*" R0560-00-TRATAR-NOVO-COD-RET-SECTION */
        private void R0560_00_TRATAR_NOVO_COD_RET_SECTION()
        {
            /*" -2071- MOVE 'R0560-00-TRATAR-NOVO-COD-RET' TO PARAGRAFO */
            _.Move("R0560-00-TRATAR-NOVO-COD-RET", WABEND.PARAGRAFO);

            /*" -2072- MOVE 'TRATAR NOVOS CODIGOS DE RETORNO' TO COMANDO */
            _.Move("TRATAR NOVOS CODIGOS DE RETORNO", WABEND.COMANDO);

            /*" -2074- DISPLAY PARAGRAFO */
            _.Display(WABEND.PARAGRAFO);

            /*" -2076- PERFORM R0570-00-VERIFICA-COD-RET */

            R0570_00_VERIFICA_COD_RET_SECTION();

            /*" -2077- IF WS-SIM-INSERIR */

            if (WS_TRABALHO.WS_INSERIR_RET["WS_SIM_INSERIR"])
            {

                /*" -2078- PERFORM R0580-00-INSERIR-COD-RET */

                R0580_00_INSERIR_COD_RET_SECTION();

                /*" -2080- END-IF */
            }


            /*" -2083- ADD 1 TO WS-INS-DES-RETORNO */
            WS_CONTADORES.WS_INS_DES_RETORNO.Value = WS_CONTADORES.WS_INS_DES_RETORNO + 1;

            /*" -2083- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0560_99_SAIDA*/

        [StopWatch]
        /*" R0570-00-VERIFICA-COD-RET-SECTION */
        private void R0570_00_VERIFICA_COD_RET_SECTION()
        {
            /*" -2091- MOVE 'R0570-00-VERIFICA-COD-RET' TO PARAGRAFO */
            _.Move("R0570-00-VERIFICA-COD-RET", WABEND.PARAGRAFO);

            /*" -2092- MOVE 'VERIFICAR SE EXISTE O COD. RETORNO' TO COMANDO */
            _.Move("VERIFICAR SE EXISTE O COD. RETORNO", WABEND.COMANDO);

            /*" -2094- DISPLAY PARAGRAFO */
            _.Display(WABEND.PARAGRAFO);

            /*" -2095- SET WS-NAO-INSERIR TO TRUE */
            WS_TRABALHO.WS_INSERIR_RET["WS_NAO_INSERIR"] = true;

            /*" -2096- MOVE CIELO-COD-MOVIMENTO TO GE409-COD-MOVIMENTO */
            _.Move(REG_CIELO.CIELO_COD_MOVIMENTO, GE409.DCLGE_DES_RETORNO_CIELO.GE409_COD_MOVIMENTO);

            /*" -2098- MOVE CIELO-COD-RETORNO TO GE409-COD-RETORNO */
            _.Move(REG_CIELO.CIELO_COD_RETORNO, GE409.DCLGE_DES_RETORNO_CIELO.GE409_COD_RETORNO);

            /*" -2107- PERFORM R0570_00_VERIFICA_COD_RET_DB_SELECT_1 */

            R0570_00_VERIFICA_COD_RET_DB_SELECT_1();

            /*" -2110-  EVALUATE SQLCODE  */

            /*" -2111-  WHEN ZEROS  */

            /*" -2111- IF   SQLCODE EQUALS  ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -2112- DISPLAY 'R0570-ERRO SELECT GE_DES_RETORNO_CIELO' */
                _.Display($"R0570-ERRO SELECT GE_DES_RETORNO_CIELO");

                /*" -2113- DISPLAY 'NUM-CERTIFICADO      = ' GE408-NUM-CERTIFICADO */
                _.Display($"NUM-CERTIFICADO      = {GE408.DCLGE_RETORNO_CA_CIELO.GE408_NUM_CERTIFICADO}");

                /*" -2114- DISPLAY 'NUM-PARCELA          = ' GE408-NUM-PARCELA */
                _.Display($"NUM-PARCELA          = {GE408.DCLGE_RETORNO_CA_CIELO.GE408_NUM_PARCELA}");

                /*" -2115- DISPLAY 'SEQ-CONTROL-CARTAO   = ' GE408-SEQ-CONTROL-CARTAO */
                _.Display($"SEQ-CONTROL-CARTAO   = {GE408.DCLGE_RETORNO_CA_CIELO.GE408_SEQ_CONTROL_CARTAO}");

                /*" -2116- DISPLAY 'NUM-PROPOSTA         = ' GE408-NUM-PROPOSTA */
                _.Display($"NUM-PROPOSTA         = {GE408.DCLGE_RETORNO_CA_CIELO.GE408_NUM_PROPOSTA}");

                /*" -2118- DISPLAY 'SEQ-RET-CONTROL-HIST = ' GE408-SEQ-RET-CONTROL-HIST */
                _.Display($"SEQ-RET-CONTROL-HIST = {GE408.DCLGE_RETORNO_CA_CIELO.GE408_SEQ_RET_CONTROL_HIST}");

                /*" -2119- DISPLAY 'COD-MOVIMENTO        = ' GE409-COD-MOVIMENTO */
                _.Display($"COD-MOVIMENTO        = {GE409.DCLGE_DES_RETORNO_CIELO.GE409_COD_MOVIMENTO}");

                /*" -2120- DISPLAY 'COD-RETORNO          = ' GE409-COD-RETORNO */
                _.Display($"COD-RETORNO          = {GE409.DCLGE_DES_RETORNO_CIELO.GE409_COD_RETORNO}");

                /*" -2121- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2122-  WHEN +100  */

                /*" -2122- ELSE IF   SQLCODE EQUALS  +100 */
            }
            else

            if (DB.SQLCODE == +100)
            {

                /*" -2123- SET WS-SIM-INSERIR TO TRUE */
                WS_TRABALHO.WS_INSERIR_RET["WS_SIM_INSERIR"] = true;

                /*" -2124-  WHEN OTHER  */

                /*" -2124- ELSE */
            }
            else
            {


                /*" -2125- DISPLAY 'R0570 - PROBLEMAS SELECT GE_DES_RETORNO_CIELO' */
                _.Display($"R0570 - PROBLEMAS SELECT GE_DES_RETORNO_CIELO");

                /*" -2126- DISPLAY 'COD-MOVIMENTO  = ' GE409-COD-MOVIMENTO */
                _.Display($"COD-MOVIMENTO  = {GE409.DCLGE_DES_RETORNO_CIELO.GE409_COD_MOVIMENTO}");

                /*" -2127- DISPLAY 'COD-RETORNO    = ' GE409-COD-RETORNO */
                _.Display($"COD-RETORNO    = {GE409.DCLGE_DES_RETORNO_CIELO.GE409_COD_RETORNO}");

                /*" -2128- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2130-  END-EVALUATE  */

                /*" -2130- END-IF */
            }


            /*" -2130- . */

        }

        [StopWatch]
        /*" R0570-00-VERIFICA-COD-RET-DB-SELECT-1 */
        public void R0570_00_VERIFICA_COD_RET_DB_SELECT_1()
        {
            /*" -2107- EXEC SQL SELECT COD_MOVIMENTO , COD_RETORNO INTO :GE409-COD-MOVIMENTO , :GE409-COD-RETORNO FROM SEGUROS.GE_DES_RETORNO_CIELO WHERE COD_MOVIMENTO = :GE409-COD-MOVIMENTO AND COD_RETORNO = :GE409-COD-RETORNO WITH UR END-EXEC */

            var r0570_00_VERIFICA_COD_RET_DB_SELECT_1_Query1 = new R0570_00_VERIFICA_COD_RET_DB_SELECT_1_Query1()
            {
                GE409_COD_MOVIMENTO = GE409.DCLGE_DES_RETORNO_CIELO.GE409_COD_MOVIMENTO.ToString(),
                GE409_COD_RETORNO = GE409.DCLGE_DES_RETORNO_CIELO.GE409_COD_RETORNO.ToString(),
            };

            var executed_1 = R0570_00_VERIFICA_COD_RET_DB_SELECT_1_Query1.Execute(r0570_00_VERIFICA_COD_RET_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.GE409_COD_MOVIMENTO, GE409.DCLGE_DES_RETORNO_CIELO.GE409_COD_MOVIMENTO);
                _.Move(executed_1.GE409_COD_RETORNO, GE409.DCLGE_DES_RETORNO_CIELO.GE409_COD_RETORNO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0570_99_SAIDA*/

        [StopWatch]
        /*" R0580-00-INSERIR-COD-RET-SECTION */
        private void R0580_00_INSERIR_COD_RET_SECTION()
        {
            /*" -2138- MOVE 'R0580-00-INSERIR-COD-RET' TO PARAGRAFO */
            _.Move("R0580-00-INSERIR-COD-RET", WABEND.PARAGRAFO);

            /*" -2139- MOVE 'INSERIR NOVO CODIGO DE RETORNO' TO COMANDO */
            _.Move("INSERIR NOVO CODIGO DE RETORNO", WABEND.COMANDO);

            /*" -2141- DISPLAY PARAGRAFO */
            _.Display(WABEND.PARAGRAFO);

            /*" -2142- MOVE WS-TXT-COD-RETORNO TO GE409-DES-COD-RETORNO-TEXT */
            _.Move(WS_CONSTANTES.WS_TXT_COD_RETORNO, GE409.DCLGE_DES_RETORNO_CIELO.GE409_DES_COD_RETORNO.GE409_DES_COD_RETORNO_TEXT);

            /*" -2144- MOVE 57 TO GE409-DES-COD-RETORNO-LEN */
            _.Move(57, GE409.DCLGE_DES_RETORNO_CIELO.GE409_DES_COD_RETORNO.GE409_DES_COD_RETORNO_LEN);

            /*" -2157- PERFORM R0580_00_INSERIR_COD_RET_DB_INSERT_1 */

            R0580_00_INSERIR_COD_RET_DB_INSERT_1();

            /*" -2160- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -2161- DISPLAY 'R0580 - CODIGO DE RETORNO INSERIDO' */
                _.Display($"R0580 - CODIGO DE RETORNO INSERIDO");

                /*" -2162- DISPLAY 'COD-MOVIMENTO  = ' GE409-COD-MOVIMENTO */
                _.Display($"COD-MOVIMENTO  = {GE409.DCLGE_DES_RETORNO_CIELO.GE409_COD_MOVIMENTO}");

                /*" -2163- DISPLAY 'COD-RETORNO    = ' GE409-COD-RETORNO */
                _.Display($"COD-RETORNO    = {GE409.DCLGE_DES_RETORNO_CIELO.GE409_COD_RETORNO}");

                /*" -2164- ELSE */
            }
            else
            {


                /*" -2165- DISPLAY 'R0580 - PROBLEMAS INSERT GE_DES_RETORNO_CIELO' */
                _.Display($"R0580 - PROBLEMAS INSERT GE_DES_RETORNO_CIELO");

                /*" -2166- DISPLAY 'COD.MOVIMENTO     = ' GE409-COD-MOVIMENTO */
                _.Display($"COD.MOVIMENTO     = {GE409.DCLGE_DES_RETORNO_CIELO.GE409_COD_MOVIMENTO}");

                /*" -2167- DISPLAY 'COD.RETORNO       = ' GE409-COD-RETORNO */
                _.Display($"COD.RETORNO       = {GE409.DCLGE_DES_RETORNO_CIELO.GE409_COD_RETORNO}");

                /*" -2168- DISPLAY 'SQLCODE           = ' SQLCODE */
                _.Display($"SQLCODE           = {DB.SQLCODE}");

                /*" -2169- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2171- END-IF */
            }


            /*" -2171- . */

        }

        [StopWatch]
        /*" R0580-00-INSERIR-COD-RET-DB-INSERT-1 */
        public void R0580_00_INSERIR_COD_RET_DB_INSERT_1()
        {
            /*" -2157- EXEC SQL INSERT INTO SEGUROS.GE_DES_RETORNO_CIELO ( COD_MOVIMENTO , COD_RETORNO , DES_COD_RETORNO ) VALUES ( :GE409-COD-MOVIMENTO , :GE409-COD-RETORNO , :GE409-DES-COD-RETORNO ) END-EXEC */

            var r0580_00_INSERIR_COD_RET_DB_INSERT_1_Insert1 = new R0580_00_INSERIR_COD_RET_DB_INSERT_1_Insert1()
            {
                GE409_COD_MOVIMENTO = GE409.DCLGE_DES_RETORNO_CIELO.GE409_COD_MOVIMENTO.ToString(),
                GE409_COD_RETORNO = GE409.DCLGE_DES_RETORNO_CIELO.GE409_COD_RETORNO.ToString(),
                GE409_DES_COD_RETORNO = GE409.DCLGE_DES_RETORNO_CIELO.GE409_DES_COD_RETORNO.ToString(),
            };

            R0580_00_INSERIR_COD_RET_DB_INSERT_1_Insert1.Execute(r0580_00_INSERIR_COD_RET_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0580_99_SAIDA*/

        [StopWatch]
        /*" R0610-00-VERIFICA-IDLG-DEMAIS-SECTION */
        private void R0610_00_VERIFICA_IDLG_DEMAIS_SECTION()
        {
            /*" -2179- MOVE 'R0610-00-VERIFICA-IDLG-DEMAIS' TO PARAGRAFO */
            _.Move("R0610-00-VERIFICA-IDLG-DEMAIS", WABEND.PARAGRAFO);

            /*" -2180- MOVE 'VERIFICA IDLG DEMAIS PARCELAS' TO COMANDO */
            _.Move("VERIFICA IDLG DEMAIS PARCELAS", WABEND.COMANDO);

            /*" -2182- DISPLAY PARAGRAFO */
            _.Display(WABEND.PARAGRAFO);

            /*" -2200- PERFORM R0610_00_VERIFICA_IDLG_DEMAIS_DB_SELECT_1 */

            R0610_00_VERIFICA_IDLG_DEMAIS_DB_SELECT_1();

            /*" -2203-  EVALUATE SQLCODE  */

            /*" -2204-  WHEN ZEROS  */

            /*" -2204- IF   SQLCODE EQUALS  ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -2205- CONTINUE */

                /*" -2206-  WHEN +100  */

                /*" -2206- ELSE IF   SQLCODE EQUALS  +100 */
            }
            else

            if (DB.SQLCODE == +100)
            {

                /*" -2208- MOVE ZEROS TO MOVDEBCE-NUM-APOLICE MOVDEBCE-NUM-ENDOSSO */
                _.Move(0, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO);

                /*" -2209- DISPLAY 'R0610 - IDLG NAO CADASTRADO NO SIAS' */
                _.Display($"R0610 - IDLG NAO CADASTRADO NO SIAS");

                /*" -2210- DISPLAY 'COD-CONVENIO   = ' MOVDEBCE-COD-CONVENIO */
                _.Display($"COD-CONVENIO   = {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO}");

                /*" -2211- DISPLAY 'NSAS           = ' MOVDEBCE-NSAS */
                _.Display($"NSAS           = {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NSAS}");

                /*" -2212- DISPLAY 'NUM-REQUISICAO = ' MOVDEBCE-NUM-REQUISICAO */
                _.Display($"NUM-REQUISICAO = {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_REQUISICAO}");

                /*" -2213- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2214-  WHEN OTHER  */

                /*" -2214- ELSE */
            }
            else
            {


                /*" -2215- DISPLAY 'R0610 - PROBLEMAS SELECT MOVDEBCE ' */
                _.Display($"R0610 - PROBLEMAS SELECT MOVDEBCE ");

                /*" -2216- DISPLAY 'COD-CONVENIO   = ' MOVDEBCE-COD-CONVENIO */
                _.Display($"COD-CONVENIO   = {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO}");

                /*" -2217- DISPLAY 'NSAS           = ' MOVDEBCE-NSAS */
                _.Display($"NSAS           = {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NSAS}");

                /*" -2218- DISPLAY 'NUM-REQUISICAO = ' MOVDEBCE-NUM-REQUISICAO */
                _.Display($"NUM-REQUISICAO = {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_REQUISICAO}");

                /*" -2219- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2221-  END-EVALUATE  */

                /*" -2221- END-IF */
            }


            /*" -2221- . */

        }

        [StopWatch]
        /*" R0610-00-VERIFICA-IDLG-DEMAIS-DB-SELECT-1 */
        public void R0610_00_VERIFICA_IDLG_DEMAIS_DB_SELECT_1()
        {
            /*" -2200- EXEC SQL SELECT NUM_APOLICE , NUM_ENDOSSO , NUM_PARCELA , DATA_VENCIMENTO , VALOR_DEBITO , DTCREDITO INTO :MOVDEBCE-NUM-APOLICE , :MOVDEBCE-NUM-ENDOSSO , :MOVDEBCE-NUM-PARCELA , :MOVDEBCE-DATA-VENCIMENTO , :MOVDEBCE-VALOR-DEBITO , :MOVDEBCE-DTCREDITO:VIND-DTCREDITO FROM SEGUROS.MOVTO_DEBITOCC_CEF WHERE COD_CONVENIO = :MOVDEBCE-COD-CONVENIO AND NSAS = :MOVDEBCE-NSAS AND NUM_REQUISICAO = :MOVDEBCE-NUM-REQUISICAO WITH UR END-EXEC */

            var r0610_00_VERIFICA_IDLG_DEMAIS_DB_SELECT_1_Query1 = new R0610_00_VERIFICA_IDLG_DEMAIS_DB_SELECT_1_Query1()
            {
                MOVDEBCE_NUM_REQUISICAO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_REQUISICAO.ToString(),
                MOVDEBCE_COD_CONVENIO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO.ToString(),
                MOVDEBCE_NSAS = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NSAS.ToString(),
            };

            var executed_1 = R0610_00_VERIFICA_IDLG_DEMAIS_DB_SELECT_1_Query1.Execute(r0610_00_VERIFICA_IDLG_DEMAIS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.MOVDEBCE_NUM_APOLICE, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE);
                _.Move(executed_1.MOVDEBCE_NUM_ENDOSSO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO);
                _.Move(executed_1.MOVDEBCE_NUM_PARCELA, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA);
                _.Move(executed_1.MOVDEBCE_DATA_VENCIMENTO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_VENCIMENTO);
                _.Move(executed_1.MOVDEBCE_VALOR_DEBITO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_VALOR_DEBITO);
                _.Move(executed_1.MOVDEBCE_DTCREDITO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DTCREDITO);
                _.Move(executed_1.VIND_DTCREDITO, VIND_DTCREDITO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0610_99_SAIDA*/

        [StopWatch]
        /*" R0620-00-VERIFICA-IDLG-DEVOLU-SECTION */
        private void R0620_00_VERIFICA_IDLG_DEVOLU_SECTION()
        {
            /*" -2229- MOVE 'R0620-00-VERIFICA-IDLG-DEVOLU' TO PARAGRAFO */
            _.Move("R0620-00-VERIFICA-IDLG-DEVOLU", WABEND.PARAGRAFO);

            /*" -2230- MOVE 'VERIFICA IDLG DEVOLUCAO DE PREMIO' TO COMANDO */
            _.Move("VERIFICA IDLG DEVOLUCAO DE PREMIO", WABEND.COMANDO);

            /*" -2232- DISPLAY PARAGRAFO */
            _.Display(WABEND.PARAGRAFO);

            /*" -2252- PERFORM R0620_00_VERIFICA_IDLG_DEVOLU_DB_SELECT_1 */

            R0620_00_VERIFICA_IDLG_DEVOLU_DB_SELECT_1();

            /*" -2255-  EVALUATE SQLCODE  */

            /*" -2256-  WHEN ZEROS  */

            /*" -2256- IF   SQLCODE EQUALS  ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -2257- CONTINUE */

                /*" -2258-  WHEN +100  */

                /*" -2258- ELSE IF   SQLCODE EQUALS  +100 */
            }
            else

            if (DB.SQLCODE == +100)
            {

                /*" -2260- MOVE ZEROS TO MOVDEBCE-NUM-APOLICE MOVDEBCE-NUM-ENDOSSO */
                _.Move(0, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO);

                /*" -2261- DISPLAY 'R0620 - IDLG NAO CADASTRADO NO SIAS' */
                _.Display($"R0620 - IDLG NAO CADASTRADO NO SIAS");

                /*" -2262- DISPLAY 'COD-CONVENIO   = ' MOVDEBCE-COD-CONVENIO */
                _.Display($"COD-CONVENIO   = {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO}");

                /*" -2263- DISPLAY 'NSAS           = ' MOVDEBCE-NSAS */
                _.Display($"NSAS           = {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NSAS}");

                /*" -2264- DISPLAY 'NUM-ENDOSSO    = ' MOVDEBCE-NUM-ENDOSSO */
                _.Display($"NUM-ENDOSSO    = {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO}");

                /*" -2265- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2266-  WHEN OTHER  */

                /*" -2266- ELSE */
            }
            else
            {


                /*" -2267- DISPLAY 'R0620 - PROBLEMAS SELECT MOVDEBCE ' */
                _.Display($"R0620 - PROBLEMAS SELECT MOVDEBCE ");

                /*" -2268- DISPLAY 'COD-CONVENIO   = ' MOVDEBCE-COD-CONVENIO */
                _.Display($"COD-CONVENIO   = {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO}");

                /*" -2269- DISPLAY 'NSAS           = ' MOVDEBCE-NSAS */
                _.Display($"NSAS           = {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NSAS}");

                /*" -2270- DISPLAY 'NUM-ENDOSSO    = ' MOVDEBCE-NUM-ENDOSSO */
                _.Display($"NUM-ENDOSSO    = {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO}");

                /*" -2271- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2273-  END-EVALUATE  */

                /*" -2273- END-IF */
            }


            /*" -2273- . */

        }

        [StopWatch]
        /*" R0620-00-VERIFICA-IDLG-DEVOLU-DB-SELECT-1 */
        public void R0620_00_VERIFICA_IDLG_DEVOLU_DB_SELECT_1()
        {
            /*" -2252- EXEC SQL SELECT NUM_APOLICE , NUM_ENDOSSO , NUM_PARCELA , DATA_VENCIMENTO , VALOR_DEBITO , DTCREDITO , VALUE(NUM_REQUISICAO,0) INTO :MOVDEBCE-NUM-APOLICE , :MOVDEBCE-NUM-ENDOSSO , :MOVDEBCE-NUM-PARCELA , :MOVDEBCE-DATA-VENCIMENTO , :MOVDEBCE-VALOR-DEBITO , :MOVDEBCE-DTCREDITO:VIND-DTCREDITO , :MOVDEBCE-NUM-REQUISICAO FROM SEGUROS.MOVTO_DEBITOCC_CEF WHERE COD_CONVENIO = :MOVDEBCE-COD-CONVENIO AND NSAS = :MOVDEBCE-NSAS AND NUM_ENDOSSO = :MOVDEBCE-NUM-ENDOSSO WITH UR END-EXEC */

            var r0620_00_VERIFICA_IDLG_DEVOLU_DB_SELECT_1_Query1 = new R0620_00_VERIFICA_IDLG_DEVOLU_DB_SELECT_1_Query1()
            {
                MOVDEBCE_COD_CONVENIO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO.ToString(),
                MOVDEBCE_NUM_ENDOSSO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO.ToString(),
                MOVDEBCE_NSAS = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NSAS.ToString(),
            };

            var executed_1 = R0620_00_VERIFICA_IDLG_DEVOLU_DB_SELECT_1_Query1.Execute(r0620_00_VERIFICA_IDLG_DEVOLU_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.MOVDEBCE_NUM_APOLICE, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE);
                _.Move(executed_1.MOVDEBCE_NUM_ENDOSSO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO);
                _.Move(executed_1.MOVDEBCE_NUM_PARCELA, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA);
                _.Move(executed_1.MOVDEBCE_DATA_VENCIMENTO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_VENCIMENTO);
                _.Move(executed_1.MOVDEBCE_VALOR_DEBITO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_VALOR_DEBITO);
                _.Move(executed_1.MOVDEBCE_DTCREDITO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DTCREDITO);
                _.Move(executed_1.VIND_DTCREDITO, VIND_DTCREDITO);
                _.Move(executed_1.MOVDEBCE_NUM_REQUISICAO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_REQUISICAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0620_99_SAIDA*/

        [StopWatch]
        /*" R0700-00-ATUALIZA-INADIMPLENTE-SECTION */
        private void R0700_00_ATUALIZA_INADIMPLENTE_SECTION()
        {
            /*" -2281- MOVE 'R0700-00-ATUALIZA-INADIMPLENTE' TO PARAGRAFO */
            _.Move("R0700-00-ATUALIZA-INADIMPLENTE", WABEND.PARAGRAFO);

            /*" -2282- MOVE 'ATUALIZAR SITUACAO DA PARCELA' TO COMANDO */
            _.Move("ATUALIZAR SITUACAO DA PARCELA", WABEND.COMANDO);

            /*" -2284- DISPLAY PARAGRAFO */
            _.Display(WABEND.PARAGRAFO);

            /*" -2286- MOVE SISTEMAS-DATA-MOV-ABERTO TO MOVDEBCE-DATA-RETORNO MOVDEBCE-DATA-MOVIMENTO */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_RETORNO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_MOVIMENTO);

            /*" -2287- MOVE 9999 TO MOVDEBCE-COD-RETORNO-CEF */
            _.Move(9999, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_RETORNO_CEF);

            /*" -2288- MOVE 'EM8024B' TO MOVDEBCE-COD-USUARIO */
            _.Move("EM8024B", MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_USUARIO);

            /*" -2291- MOVE -1 TO VIND-DTCREDITO */
            _.Move(-1, VIND_DTCREDITO);

            /*" -2293- PERFORM R0710-00-ATUALIZA-MOVDEBCE */

            R0710_00_ATUALIZA_MOVDEBCE_SECTION();

            /*" -2295- ADD 1 TO WS-PARC-ATRASADA */
            WS_CONTADORES.WS_PARC_ATRASADA.Value = WS_CONTADORES.WS_PARC_ATRASADA + 1;

            /*" -2295- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0700_99_SAIDA*/

        [StopWatch]
        /*" R0710-00-ATUALIZA-MOVDEBCE-SECTION */
        private void R0710_00_ATUALIZA_MOVDEBCE_SECTION()
        {
            /*" -2303- MOVE 'R0710-00-ATUALIZA-MOVDEBCE' TO PARAGRAFO */
            _.Move("R0710-00-ATUALIZA-MOVDEBCE", WABEND.PARAGRAFO);

            /*" -2304- MOVE 'ATUALIZA MOVTO DEBITOCC CEF' TO COMANDO */
            _.Move("ATUALIZA MOVTO DEBITOCC CEF", WABEND.COMANDO);

            /*" -2306- DISPLAY PARAGRAFO */
            _.Display(WABEND.PARAGRAFO);

            /*" -2319- PERFORM R0710_00_ATUALIZA_MOVDEBCE_DB_UPDATE_1 */

            R0710_00_ATUALIZA_MOVDEBCE_DB_UPDATE_1();

            /*" -2322-  EVALUATE SQLCODE  */

            /*" -2323-  WHEN ZEROS  */

            /*" -2323- IF   SQLCODE EQUALS  ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -2324- CONTINUE */

                /*" -2325-  WHEN OTHER  */

                /*" -2325- ELSE */
            }
            else
            {


                /*" -2326- DISPLAY 'R0710 - PROBLEMAS AO ATUALIZAR MOVDEBCE' */
                _.Display($"R0710 - PROBLEMAS AO ATUALIZAR MOVDEBCE");

                /*" -2327- DISPLAY 'COD-CONVENIO   = ' MOVDEBCE-COD-CONVENIO */
                _.Display($"COD-CONVENIO   = {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO}");

                /*" -2328- DISPLAY 'NSAS           = ' MOVDEBCE-NSAS */
                _.Display($"NSAS           = {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NSAS}");

                /*" -2329- DISPLAY 'NUM-REQUISICAO = ' MOVDEBCE-NUM-REQUISICAO */
                _.Display($"NUM-REQUISICAO = {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_REQUISICAO}");

                /*" -2330- DISPLAY 'NUM-ENDOSSO    = ' MOVDEBCE-NUM-ENDOSSO */
                _.Display($"NUM-ENDOSSO    = {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO}");

                /*" -2331- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2333-  END-EVALUATE  */

                /*" -2333- END-IF */
            }


            /*" -2335- PERFORM R0720-00-ATUALIZA-MOVDEBCE */

            R0720_00_ATUALIZA_MOVDEBCE_SECTION();

            /*" -2337- ADD 1 TO WS-UPT-MOVTO-DEBITO */
            WS_CONTADORES.WS_UPT_MOVTO_DEBITO.Value = WS_CONTADORES.WS_UPT_MOVTO_DEBITO + 1;

            /*" -2337- . */

        }

        [StopWatch]
        /*" R0710-00-ATUALIZA-MOVDEBCE-DB-UPDATE-1 */
        public void R0710_00_ATUALIZA_MOVDEBCE_DB_UPDATE_1()
        {
            /*" -2319- EXEC SQL UPDATE SEGUROS.MOVTO_DEBITOCC_CEF SET SITUACAO_COBRANCA = :MOVDEBCE-SITUACAO-COBRANCA , DATA_MOVIMENTO = :MOVDEBCE-DATA-MOVIMENTO , DATA_RETORNO = :MOVDEBCE-DATA-RETORNO , COD_RETORNO_CEF = :MOVDEBCE-COD-RETORNO-CEF , COD_USUARIO = :MOVDEBCE-COD-USUARIO , DTCREDITO = :MOVDEBCE-DTCREDITO :VIND-DTCREDITO WHERE COD_CONVENIO = :MOVDEBCE-COD-CONVENIO AND NSAS = :MOVDEBCE-NSAS AND (NUM_REQUISICAO = :MOVDEBCE-NUM-REQUISICAO OR NUM_ENDOSSO = :MOVDEBCE-NUM-ENDOSSO) END-EXEC */

            var r0710_00_ATUALIZA_MOVDEBCE_DB_UPDATE_1_Update1 = new R0710_00_ATUALIZA_MOVDEBCE_DB_UPDATE_1_Update1()
            {
                MOVDEBCE_DTCREDITO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DTCREDITO.ToString(),
                VIND_DTCREDITO = VIND_DTCREDITO.ToString(),
                MOVDEBCE_SITUACAO_COBRANCA = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_SITUACAO_COBRANCA.ToString(),
                MOVDEBCE_COD_RETORNO_CEF = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_RETORNO_CEF.ToString(),
                MOVDEBCE_DATA_MOVIMENTO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_MOVIMENTO.ToString(),
                MOVDEBCE_DATA_RETORNO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_RETORNO.ToString(),
                MOVDEBCE_COD_USUARIO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_USUARIO.ToString(),
                MOVDEBCE_NUM_REQUISICAO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_REQUISICAO.ToString(),
                MOVDEBCE_COD_CONVENIO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO.ToString(),
                MOVDEBCE_NUM_ENDOSSO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO.ToString(),
                MOVDEBCE_NSAS = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NSAS.ToString(),
            };

            R0710_00_ATUALIZA_MOVDEBCE_DB_UPDATE_1_Update1.Execute(r0710_00_ATUALIZA_MOVDEBCE_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0710_99_SAIDA*/

        [StopWatch]
        /*" R0720-00-ATUALIZA-MOVDEBCE-SECTION */
        private void R0720_00_ATUALIZA_MOVDEBCE_SECTION()
        {
            /*" -2345- MOVE 'R0720-00-ATUALIZA-MOVDEBCE' TO PARAGRAFO */
            _.Move("R0720-00-ATUALIZA-MOVDEBCE", WABEND.PARAGRAFO);

            /*" -2346- MOVE 'ATUALIZA MOVTO DEBITOCC CEF' TO COMANDO */
            _.Move("ATUALIZA MOVTO DEBITOCC CEF", WABEND.COMANDO);

            /*" -2348- DISPLAY PARAGRAFO */
            _.Display(WABEND.PARAGRAFO);

            /*" -2361- PERFORM R0720_00_ATUALIZA_MOVDEBCE_DB_UPDATE_1 */

            R0720_00_ATUALIZA_MOVDEBCE_DB_UPDATE_1();

            /*" -2364-  EVALUATE SQLCODE  */

            /*" -2365-  WHEN ZEROS  */

            /*" -2365- IF   SQLCODE EQUALS  ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -2366- CONTINUE */

                /*" -2367-  WHEN OTHER  */

                /*" -2367- ELSE */
            }
            else
            {


                /*" -2368- DISPLAY 'R0710 - PROBLEMAS AO ATUALIZAR MOVDEBCE' */
                _.Display($"R0710 - PROBLEMAS AO ATUALIZAR MOVDEBCE");

                /*" -2369- DISPLAY 'COD-CONVENIO   = ' MOVDEBCE-COD-CONVENIO */
                _.Display($"COD-CONVENIO   = {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO}");

                /*" -2370- DISPLAY 'NSAS           = ' MOVDEBCE-NSAS */
                _.Display($"NSAS           = {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NSAS}");

                /*" -2371- DISPLAY 'NUM-REQUISICAO = ' MOVDEBCE-NUM-REQUISICAO */
                _.Display($"NUM-REQUISICAO = {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_REQUISICAO}");

                /*" -2372- DISPLAY 'NUM-ENDOSSO    = ' MOVDEBCE-NUM-ENDOSSO */
                _.Display($"NUM-ENDOSSO    = {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO}");

                /*" -2373- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2375-  END-EVALUATE  */

                /*" -2375- END-IF */
            }


            /*" -2377- ADD 1 TO WS-UPT-MOVTO-DEBITO */
            WS_CONTADORES.WS_UPT_MOVTO_DEBITO.Value = WS_CONTADORES.WS_UPT_MOVTO_DEBITO + 1;

            /*" -2377- . */

        }

        [StopWatch]
        /*" R0720-00-ATUALIZA-MOVDEBCE-DB-UPDATE-1 */
        public void R0720_00_ATUALIZA_MOVDEBCE_DB_UPDATE_1()
        {
            /*" -2361- EXEC SQL UPDATE SEGUROS.MOVTO_DEBITOCC_CEF SET SITUACAO_COBRANCA = :MOVDEBCE-SITUACAO-COBRANCA , DATA_MOVIMENTO = :MOVDEBCE-DATA-MOVIMENTO , DATA_RETORNO = :MOVDEBCE-DATA-RETORNO , COD_RETORNO_CEF = :MOVDEBCE-COD-RETORNO-CEF , COD_USUARIO = :MOVDEBCE-COD-USUARIO , DTCREDITO = :MOVDEBCE-DTCREDITO :VIND-DTCREDITO WHERE COD_CONVENIO = :MOVDEBCE-COD-CONVENIO AND NSAS = :MOVDEBCE-NSAS AND (NUM_REQUISICAO = :MOVDEBCE-NUM-REQUISICAO OR NUM_ENDOSSO = :MOVDEBCE-NUM-ENDOSSO) END-EXEC */

            var r0720_00_ATUALIZA_MOVDEBCE_DB_UPDATE_1_Update1 = new R0720_00_ATUALIZA_MOVDEBCE_DB_UPDATE_1_Update1()
            {
                MOVDEBCE_DTCREDITO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DTCREDITO.ToString(),
                VIND_DTCREDITO = VIND_DTCREDITO.ToString(),
                MOVDEBCE_SITUACAO_COBRANCA = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_SITUACAO_COBRANCA.ToString(),
                MOVDEBCE_COD_RETORNO_CEF = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_RETORNO_CEF.ToString(),
                MOVDEBCE_DATA_MOVIMENTO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_MOVIMENTO.ToString(),
                MOVDEBCE_DATA_RETORNO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_RETORNO.ToString(),
                MOVDEBCE_COD_USUARIO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_USUARIO.ToString(),
                MOVDEBCE_NUM_REQUISICAO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_REQUISICAO.ToString(),
                MOVDEBCE_COD_CONVENIO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO.ToString(),
                MOVDEBCE_NUM_ENDOSSO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO.ToString(),
                MOVDEBCE_NSAS = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NSAS.ToString(),
            };

            R0720_00_ATUALIZA_MOVDEBCE_DB_UPDATE_1_Update1.Execute(r0720_00_ATUALIZA_MOVDEBCE_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0710_99_SAIDA*/

        [StopWatch]
        /*" R0800-00-MONTA-ARQ-SAIDA-SECTION */
        private void R0800_00_MONTA_ARQ_SAIDA_SECTION()
        {
            /*" -2385- MOVE 'R0800-00-MONTA-ARQ-SAIDA' TO PARAGRAFO */
            _.Move("R0800-00-MONTA-ARQ-SAIDA", WABEND.PARAGRAFO);

            /*" -2386- MOVE 'MONTAR ARQUIVO DE SAIDA' TO COMANDO */
            _.Move("MONTAR ARQUIVO DE SAIDA", WABEND.COMANDO);

            /*" -2388- DISPLAY PARAGRAFO */
            _.Display(WABEND.PARAGRAFO);

            /*" -2389- MOVE 001 TO DETAL01-TIPO-REGISTRO */
            _.Move(001, DETAL01_REGISTRO.DETAL01_TIPO_REGISTRO);

            /*" -2390- MOVE CIELO-NUM-PROPOSTA TO DETAL01-NUM-PROPOSTA */
            _.Move(REG_CIELO.CIELO_NUM_PROPOSTA, DETAL01_REGISTRO.DETAL01_NUM_PROPOSTA);

            /*" -2391- MOVE WS-NUM-PARCELA TO DETAL01-NUM-PARCELA */
            _.Move(WS_TRABALHO.WS_NUM_PARCELA, DETAL01_REGISTRO.DETAL01_NUM_PARCELA);

            /*" -2392- MOVE CIELO-IDLG TO DETAL01-COD-IDLG */
            _.Move(REG_CIELO.CIELO_IDLG, DETAL01_REGISTRO.DETAL01_COD_IDLG);

            /*" -2393- MOVE WS-DT-VENCIMENTO TO DETAL01-DATA-VENCIMENTO */
            _.Move(WS_TRABALHO.WS_DT_VENCIMENTO, DETAL01_REGISTRO.DETAL01_DATA_VENCIMENTO);

            /*" -2394- MOVE WS-DT-CAPTURA TO DETAL01-DATA-CAPTURA */
            _.Move(WS_TRABALHO.WS_DT_CAPTURA, DETAL01_REGISTRO.DETAL01_DATA_CAPTURA);

            /*" -2395- MOVE WS-DT-CREDITO TO DETAL01-DATA-CREDITO */
            _.Move(WS_TRABALHO.WS_DT_CREDITO, DETAL01_REGISTRO.DETAL01_DATA_CREDITO);

            /*" -2396- MOVE CIELO-VLR-COBRANCA TO DETAL01-VLR-COBRANCA */
            _.Move(REG_CIELO.CIELO_VLR_COBRANCA, DETAL01_REGISTRO.DETAL01_VLR_COBRANCA);

            /*" -2397- MOVE CIELO-VLR-LIQUIDO TO DETAL01-VLR-LIQUIDO */
            _.Move(REG_CIELO.CIELO_VLR_LIQUIDO, DETAL01_REGISTRO.DETAL01_VLR_LIQUIDO);

            /*" -2398- MOVE CIELO-VLR-TAX-ADM TO DETAL01-VLR-TAX-ADM */
            _.Move(REG_CIELO.CIELO_VLR_TAX_ADM, DETAL01_REGISTRO.DETAL01_VLR_TAX_ADM);

            /*" -2399- MOVE CIELO-COD-MOVIMENTO TO DETAL01-COD-MOVIMENTO */
            _.Move(REG_CIELO.CIELO_COD_MOVIMENTO, DETAL01_REGISTRO.DETAL01_COD_MOVIMENTO);

            /*" -2400- MOVE CIELO-COD-RETORNO TO DETAL01-COD-RETORNO */
            _.Move(REG_CIELO.CIELO_COD_RETORNO, DETAL01_REGISTRO.DETAL01_COD_RETORNO);

            /*" -2401- MOVE CIELO-PROC-ADVERT TO DETAL01-PROC-ADVERT */
            _.Move(REG_CIELO.CIELO_PROC_ADVERT, DETAL01_REGISTRO.DETAL01_PROC_ADVERT);

            /*" -2402- MOVE CIELO-NIVE-ADVERT TO DETAL01-NIVE-ADVERT */
            _.Move(REG_CIELO.CIELO_NIVE_ADVERT, DETAL01_REGISTRO.DETAL01_NIVE_ADVERT);

            /*" -2404- MOVE CIELO-MOTIVO-COMPENSACAO TO DETAL01-MOTI-COMPEN */
            _.Move(REG_CIELO.CIELO_MOTIVO_COMPENSACAO, DETAL01_REGISTRO.DETAL01_MOTI_COMPEN);

            /*" -2404- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0800_99_SAIDA*/

        [StopWatch]
        /*" R9988-00-MONTAR-CONTROLES-SECTION */
        private void R9988_00_MONTAR_CONTROLES_SECTION()
        {
            /*" -2415- MOVE 'R9988-00-MONTAR-CONTROLES' TO PARAGRAFO */
            _.Move("R9988-00-MONTAR-CONTROLES", WABEND.PARAGRAFO);

            /*" -2416- MOVE 'MONTAR CONTROLES DE PROCESSAMENTO' TO COMANDO */
            _.Move("MONTAR CONTROLES DE PROCESSAMENTO", WABEND.COMANDO);

            /*" -2418- DISPLAY PARAGRAFO */
            _.Display(WABEND.PARAGRAFO);

            /*" -2420- DISPLAY '+------------------------------------------------ '-----------------+' */
            _.Display($"+------------------------------------------------ -----------------+");

            /*" -2422- DISPLAY 'I PAGAMENTOS CARTAO DE CREDITO '                 I' */
            _.Display($"I PAGAMENTOS CARTAO DE CREDITO I");

            /*" -2424- DISPLAY 'I '                 I' */
            _.Display($"I I");

            /*" -2426- DISPLAY 'I                 TOTAIS DE CONTROLE EM ' WS-DTMOVABE-I '                I' */

            $"I                 TOTAIS DE CONTROLE EM {WS_TRABALHO.WS_DTMOVABE_I}                I"
            .Display();

            /*" -2429- DISPLAY '+------------------------------------------------ '-----------------+' . */
            _.Display($"+------------------------------------------------ -----------------+");

            /*" -2431- DISPLAY 'I T A B E L A S A T U A L I Z A D A '' S I'. */
            _.Display($"I T A B E L A S A T U A L I Z A D A  S I");

            /*" -2433- DISPLAY '+--------------------------------------------+--- '-------+---------+' . */
            _.Display($"+--------------------------------------------+--- -------+---------+");

            /*" -2435- DISPLAY 'I NOME DA TABELA I IN 'SERT   I UPDATE  I' */

            $"I NOME DA TABELA I IN SERTIUPDATEI"
            .Display();

            /*" -2437- DISPLAY '+--------------------------------------------+--- '-------+---------+' . */
            _.Display($"+--------------------------------------------+--- -------+---------+");

            /*" -2440- DISPLAY 'I GE_MOVIMENTO_SAP                           I  ' WS-INS-MOVTO-SAP '   I  ' '     ' '  I' */

            $"I GE_MOVIMENTO_SAP                           I  {WS_CONTADORES.WS_INS_MOVTO_SAP}   I         I"
            .Display();

            /*" -2443- DISPLAY 'I GE_CONTROLE_INTERF_SAP                     I  ' WS-INS-INTERF-SAP '   I  ' '     ' '  I' */

            $"I GE_CONTROLE_INTERF_SAP                     I  {WS_CONTADORES.WS_INS_INTERF_SAP}   I         I"
            .Display();

            /*" -2446- DISPLAY 'I GE_CONTROLE_ARQH                           I  ' WS-INS-CONTR-ARQH '   I  ' '     ' '  I' */

            $"I GE_CONTROLE_ARQH                           I  {WS_CONTADORES.WS_INS_CONTR_ARQH}   I         I"
            .Display();

            /*" -2449- DISPLAY 'I GE_CONTROLE_CARTAO_CIELO                   I  ' WS-INS-CONTR-CIELO '   I  ' WS-UPT-CONTR-CIELO '  I' */

            $"I GE_CONTROLE_CARTAO_CIELO                   I  {WS_CONTADORES.WS_INS_CONTR_CIELO}   I  {WS_CONTADORES.WS_UPT_CONTR_CIELO}  I"
            .Display();

            /*" -2453- DISPLAY 'I GE_RETORNO_CA_CIELO                        I  ' WS-INS-RETORNO-CIELO '   I  ' '     ' '  I' */

            $"I GE_RETORNO_CA_CIELO                        I  {WS_CONTADORES.WS_INS_RETORNO_CIELO}   I         I"
            .Display();

            /*" -2456- DISPLAY 'I MOVTO_DEBITOCC_CEF                         I  ' '     ' '   I  ' WS-UPT-MOVTO-DEBITO '  I' */

            $"I MOVTO_DEBITOCC_CEF                         I          I  {WS_CONTADORES.WS_UPT_MOVTO_DEBITO}  I"
            .Display();

            /*" -2459- DISPLAY 'I GE_DES_RETORNO_CIELO                       I  ' WS-INS-DES-RETORNO '   I  ' '     ' '  I' */

            $"I GE_DES_RETORNO_CIELO                       I  {WS_CONTADORES.WS_INS_DES_RETORNO}   I         I"
            .Display();

            /*" -2461- DISPLAY '+--------------------------------------------+--- '-------+---------+' . */
            _.Display($"+--------------------------------------------+--- -------+---------+");

            /*" -2463- DISPLAY 'I QUANTIDADE DE PROPOSTAS LIDAS              I  ' WS-CONT-LIDOS '   I         I' */

            $"I QUANTIDADE DE PROPOSTAS LIDAS              I  {WS_CONTADORES.WS_CONT_LIDOS}   I         I"
            .Display();

            /*" -2465- DISPLAY 'I QUANTIDADE DE PAGAMENTOS DE ADESAO         I  ' WS-AC-GRAV-ADESAO '   I         I' */

            $"I QUANTIDADE DE PAGAMENTOS DE ADESAO         I  {WS_CONTADORES.WS_AC_GRAV_ADESAO}   I         I"
            .Display();

            /*" -2467- DISPLAY 'I QUANTIDADE DE PAGAMENTOS DE DEMAIS PARCELASI  ' WS-AC-GRAV-DEMAIS '   I         I' */

            $"I QUANTIDADE DE PAGAMENTOS DE DEMAIS PARCELASI  {WS_CONTADORES.WS_AC_GRAV_DEMAIS}   I         I"
            .Display();

            /*" -2469- DISPLAY 'I QUANT. DE PARCELAS QUE NAO HOUVERAM PAGTOS I  ' WS-PARC-ATRASADA '   I         I' */

            $"I QUANT. DE PARCELAS QUE NAO HOUVERAM PAGTOS I  {WS_CONTADORES.WS_PARC_ATRASADA}   I         I"
            .Display();

            /*" -2471- DISPLAY 'I REGISTRO DE VENDAS CANCELADAS CARTAO       I  ' WS-CANCEL-VENDA '   I         I' */

            $"I REGISTRO DE VENDAS CANCELADAS CARTAO       I  {WS_CONTADORES.WS_CANCEL_VENDA}   I         I"
            .Display();

            /*" -2473- DISPLAY 'I REG. DE VENDAS CANCELADOS POR CHARGEBACK   I  ' WS-DESP-CHARGEBACK '   I         I' */

            $"I REG. DE VENDAS CANCELADOS POR CHARGEBACK   I  {WS_CONTADORES.WS_DESP_CHARGEBACK}   I         I"
            .Display();

            /*" -2475- DISPLAY 'I DESPREZADOS POR SER PRODUTO CAPITALIZACAO  I  ' WS-DESP-PRODUTO-CAP '   I         I' */

            $"I DESPREZADOS POR SER PRODUTO CAPITALIZACAO  I  {WS_CONTADORES.WS_DESP_PRODUTO_CAP}   I         I"
            .Display();

            /*" -2477- DISPLAY 'I DESPREZADOS OUTROS PRODUTOS                I  ' WS-DESP-PRODUTO '   I         I' */

            $"I DESPREZADOS OUTROS PRODUTOS                I  {WS_CONTADORES.WS_DESP_PRODUTO}   I         I"
            .Display();

            /*" -2479- DISPLAY '+--------------------------------------------+--- '-------+---------+' . */
            _.Display($"+--------------------------------------------+--- -------+---------+");

            /*" -2481- DISPLAY 'I E M 8 0 2 4 B - F I M N O R M A L '                 I' . */
            _.Display($"I E M 8 0 2 4 B - F I M N O R M A L I");

            /*" -2482- DISPLAY '+--------------------------------------------+--- '-------+---------+' . */
            _.Display($"+--------------------------------------------+--- -------+---------+");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9988_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -2490- MOVE SQLCODE TO WSQLCODE */
            _.Move(DB.SQLCODE, WABEND.WSQLCODE);

            /*" -2491- MOVE SQLERRD(1) TO WSQLERRD1 */
            _.Move(DB.SQLERRD[1], WABEND.WSQLERRD1);

            /*" -2492- MOVE SQLERRD(2) TO WSQLERRD2 */
            _.Move(DB.SQLERRD[2], WABEND.WSQLERRD2);

            /*" -2493- MOVE SQLERRMC TO WSQLERRMC */
            _.Move(DB.SQLERRMC, WABEND.WSQLERRMC);

            /*" -2495- DISPLAY WABEND */
            _.Display(WABEND);

            /*" -2498- DISPLAY '*** EM8024B *** ULTIMO MOVIMENTO LIDO ...' WS-CONT-LIDOS */
            _.Display($"*** EM8024B *** ULTIMO MOVIMENTO LIDO ...{WS_CONTADORES.WS_CONT_LIDOS}");

            /*" -2499- DISPLAY '*** EM8024B *** ROLLBACK EM ANDAMENTO ...' */
            _.Display($"*** EM8024B *** ROLLBACK EM ANDAMENTO ...");

            /*" -2500- MOVE 'ROLLBACK WORK' TO COMANDO */
            _.Move("ROLLBACK WORK", WABEND.COMANDO);

            /*" -2500- EXEC SQL ROLLBACK WORK END-EXEC */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -2503- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -2507- CLOSE MOVCIELO CCADESAO CCDEMAIS */
            MOVCIELO.Close();
            CCADESAO.Close();
            CCDEMAIS.Close();

            /*" -2509- MOVE 99 TO RETURN-CODE */
            _.Move(99, RETURN_CODE);

            /*" -2509- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}