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
using Sias.VidaEmGrupo.DB2.VG1650B;

namespace Code
{
    public class VG1650B
    {
        public bool IsCall { get; set; }

        public VG1650B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------  ---------                                              */
        /*"      *                                                                       */
        /*"      *                                                                       */
        /*"      ******************************************************************      */
        /*"      *   SISTEMA ................  VG - VIDA EM GRUPO (REDE SIM)      *      */
        /*"      *                                                                *      */
        /*"      *   PROGRAMA ...............  VG1650B                            *      */
        /*"      *                                                                *      */
        /*"      *   REFERENCIA .............  VG0140B / VG1613B                  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  EDIVALDO GOMES / LUIZ MARQUES      *      */
        /*"      *                                                                *      */
        /*"      *   EMPRESA ................  FAST COMPUTER                      *      */
        /*"      *                                                                *      */
        /*"      *   DATA CODIFICACAO .......  FEVEREIRO/2012 - SETEMBRO/2012     *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO .................  CADASTRO  DE  PRODUTOS DE SEGURO   *      */
        /*"      *                             AP NA ESTRUTURA DE APOLICES ESPE   *      */
        /*"      *                             CIFICAS VENDIDAS  NA  PLATAFORMA   *      */
        /*"      *                             DE VENDAS DA REDE SIM.             *      */
        /*"      *                                                                *      */
        /*"      *   CADMUS .................  72.667                             *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                    ALTERACAO                                   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.03  *  VERSAO  03 - DEMANDA 402.982                                  *      */
        /*"      *             - RETIRAR GRAVACAO DE ERROS DA PROPOSTA DA TABELA  *      */
        /*"      *               ERROS_PROP_VIDAZUL                               *      */
        /*"      *             - GRAVAR ERROS DA PROPOSTA NA NOVA TABELA          *      */
        /*"      *               VG_CRITICA_PROPOSTA PARA POSTERIOR ANALISE DO    *      */
        /*"      *               GESTOR NO ATALHO 04.23                           *      */
        /*"      *                                                                *      */
        /*"      *  EM 14/02/2023 - ELIERMES OLIVEIRA                             *      */
        /*"      *                                        PROCURE POR V.03        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 02 - CIELO - ADEQUA�AO AO CAMPO NUM_CARTAO_CREDITO    *      */
        /*"      *               O NUMERO DO CARTAO DE CREDITO FOI ALTERADO NA    *      */
        /*"      *               TABELA OPCAO_PAG_VIDAZUL PARA CHAR(16), POIS O   *      */
        /*"      *               NUMERO QUE O LEGADO RECEBE ESTA MASCARADO COM "*"*      */
        /*"      *                                                                *      */
        /*"      *   EM 06/08/2019 - DANIEL MEDINA GOMIDE - MILLENIUM             *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.02         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 01 -   NSGD - CADMUS 103659.                          *      */
        /*"      *               - NOVA SOLUCAO DE GESTAO DE DEPOSITOS            *      */
        /*"      *                                                                *      */
        /*"      *   EM 08/11/2014 - COREON                                       *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.01         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 00 - CAD 72.667                                       *      */
        /*"      *                                                                *      */
        /*"      *             - CRIACAO DO PROGRAMA                              *      */
        /*"      *                                                                *      */
        /*"      *   EM 19/09/2012 - LUIZ MARQUES   (FAST COMPUTER)               *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.00         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        #endregion


        #region VARIABLES

        public FileBasis _MOV_SIGAT { get; set; } = new FileBasis(new PIC("X", "300", "X(300)"));

        public FileBasis MOV_SIGAT
        {
            get
            {
                _.Move(REG_SIGAT, _MOV_SIGAT); VarBasis.RedefinePassValue(REG_SIGAT, _MOV_SIGAT, REG_SIGAT); return _MOV_SIGAT;
            }
        }
        /*"01   REG-SIGAT.*/
        public VG1650B_REG_SIGAT REG_SIGAT { get; set; } = new VG1650B_REG_SIGAT();
        public class VG1650B_REG_SIGAT : VarBasis
        {
            /*"     10  REG-TIPO-SIGAT                  PIC X(001).*/
            public StringBasis REG_TIPO_SIGAT { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"     10  REG-NUM-PROPOSTA                PIC 9(014).*/
            public IntBasis REG_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
            /*"     10  FILLER REDEFINES REG-NUM-PROPOSTA.*/
            private _REDEF_VG1650B_FILLER_0 _filler_0 { get; set; }
            public _REDEF_VG1650B_FILLER_0 FILLER_0
            {
                get { _filler_0 = new _REDEF_VG1650B_FILLER_0(); _.Move(REG_NUM_PROPOSTA, _filler_0); VarBasis.RedefinePassValue(REG_NUM_PROPOSTA, _filler_0, REG_NUM_PROPOSTA); _filler_0.ValueChanged += () => { _.Move(_filler_0, REG_NUM_PROPOSTA); }; return _filler_0; }
                set { VarBasis.RedefinePassValue(value, _filler_0, REG_NUM_PROPOSTA); }
            }  //Redefines
            public class _REDEF_VG1650B_FILLER_0 : VarBasis
            {
                /*"         15  REG-NOME-ARQUIVO            PIC X(008).*/
                public StringBasis REG_NOME_ARQUIVO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
                /*"         15  FILLER                      PIC X(006).*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)."), @"");
                /*"     10  FILLER                          PIC X(259).*/

                public _REDEF_VG1650B_FILLER_0()
                {
                    REG_NOME_ARQUIVO.ValueChanged += OnValueChanged;
                    FILLER_1.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "259", "X(259)."), @"");
            /*"     10  REG-ORIGEM-AIC                  PIC 9(004).*/
            public IntBasis REG_ORIGEM_AIC { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"     10  REG-ORIGEM-SIV                  REDEFINES         REG-ORIGEM-AIC.*/
            private _REDEF_VG1650B_REG_ORIGEM_SIV _reg_origem_siv { get; set; }
            public _REDEF_VG1650B_REG_ORIGEM_SIV REG_ORIGEM_SIV
            {
                get { _reg_origem_siv = new _REDEF_VG1650B_REG_ORIGEM_SIV(); _.Move(REG_ORIGEM_AIC, _reg_origem_siv); VarBasis.RedefinePassValue(REG_ORIGEM_AIC, _reg_origem_siv, REG_ORIGEM_AIC); _reg_origem_siv.ValueChanged += () => { _.Move(_reg_origem_siv, REG_ORIGEM_AIC); }; return _reg_origem_siv; }
                set { VarBasis.RedefinePassValue(value, _reg_origem_siv, REG_ORIGEM_AIC); }
            }  //Redefines
            public class _REDEF_VG1650B_REG_ORIGEM_SIV : VarBasis
            {
                /*"      15 FILLER                          PIC X(002).*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"      15 REG-ORIGEM                      PIC 9(002).*/
                public IntBasis REG_ORIGEM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"     10  FILLER                          PIC X(022).*/

                public _REDEF_VG1650B_REG_ORIGEM_SIV()
                {
                    FILLER_3.ValueChanged += OnValueChanged;
                    REG_ORIGEM.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "22", "X(022)."), @"");
        }

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77  WS-ABEND                      PIC  ---9.*/
        public IntBasis WS_ABEND { get; set; } = new IntBasis(new PIC("9", "4", "---9."));
        /*"77  WS-RESULTADO                  PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis WS_RESULTADO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WS-RESTO                      PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis WS_RESTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WS-IND1                       PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis WS_IND1 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WS-IND2                       PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis WS_IND2 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WS-IND3                       PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis WS_IND3 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WS-IND4                       PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis WS_IND4 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WHOST-PLANO-ANT               PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis WHOST_PLANO_ANT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WS-JA-TEM-CODIGO              PIC  X(001)    VALUE 'N'.*/
        public StringBasis WS_JA_TEM_CODIGO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
        /*"77  WS-ENDERECO                   PIC  X(040)    VALUE  SPACES.*/
        public StringBasis WS_ENDERECO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
        /*"77  WS-MOVTO-H-DATA-REFER         PIC  9(006)    VALUE  0.*/
        public IntBasis WS_MOVTO_H_DATA_REFER { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
        /*"77  WS-NUM-APOLICE                PIC S9(013)    VALUE +0 COMP-3*/
        public IntBasis WS_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77  WS-NUM-APOLICE-ANT            PIC S9(013)    VALUE +0 COMP-3*/
        public IntBasis WS_NUM_APOLICE_ANT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77  WS-COD-SUBGRUPO               PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis WS_COD_SUBGRUPO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WS-FLAG-APOLICE               PIC  X(001)    VALUE ' '.*/
        public StringBasis WS_FLAG_APOLICE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
        /*"77  WS-FLAG-HEADER                PIC  X(001)    VALUE ' '.*/
        public StringBasis WS_FLAG_HEADER { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
        /*"77  WS-FLAG-TRAILER               PIC  X(001)    VALUE ' '.*/
        public StringBasis WS_FLAG_TRAILER { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
        /*"77  SISTEMAS-DATA-MOV-ABERTO-1    PIC  X(010).*/
        public StringBasis SISTEMAS_DATA_MOV_ABERTO_1 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  WHOST-COD-FONTE-ANT           PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis WHOST_COD_FONTE_ANT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WHOST-OCORR-END-I             PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis WHOST_OCORR_END_I { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WHOST-ULT-PROP-AUTOMAT        PIC S9(009)    VALUE +0 COMP.*/
        public IntBasis WHOST_ULT_PROP_AUTOMAT { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77  WHOST-OCORR-END-F             PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis WHOST_OCORR_END_F { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WHOST-OCOR-HISTORICO          PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis WHOST_OCOR_HISTORICO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WHOST-SIT-PROPOVA             PIC  X(010).*/
        public StringBasis WHOST_SIT_PROPOVA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  WHOST-DATA-INIVIGENCIA        PIC  X(010).*/
        public StringBasis WHOST_DATA_INIVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  WHOST-DATA-TERVIGENCIA        PIC  X(010).*/
        public StringBasis WHOST_DATA_TERVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  WHOST-IND                     PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis WHOST_IND { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WHOST-IND-CRT                 PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis WHOST_IND_CRT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WHOST-QTDTIMES                PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis WHOST_QTDTIMES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WHOST-IMPSEG                  PIC S9(013)V99 VALUE +0 COMP-3*/
        public DoubleBasis WHOST_IMPSEG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77  WHOST-PRMVG                   PIC S9(013)V99 VALUE +0 COMP-3*/
        public DoubleBasis WHOST_PRMVG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77  WHOST-PARCELA                 PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis WHOST_PARCELA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WHOST-CONTRATO                PIC S9(009)    VALUE +0 COMP.*/
        public IntBasis WHOST_CONTRATO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77  WHOST-SIT-REGISTRO            PIC  X(001).*/
        public StringBasis WHOST_SIT_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77  WHOST-COD-USUARIO             PIC  X(008).*/
        public StringBasis WHOST_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"77  WHOST-SIT-REGISTRO1           PIC  X(001).*/
        public StringBasis WHOST_SIT_REGISTRO1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77  WHOST-COD-USUARIO1            PIC  X(008).*/
        public StringBasis WHOST_COD_USUARIO1 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"77  WHOST-NRPARCEL                PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis WHOST_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WHOST-NRPARCEL2               PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis WHOST_NRPARCEL2 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WHOST-MINPARC                 PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis WHOST_MINPARC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WHOST-OPER-INI                PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis WHOST_OPER_INI { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WHOST-OPER-FIN                PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis WHOST_OPER_FIN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WHOST-DATA-PAGTO              PIC  X(010).*/
        public StringBasis WHOST_DATA_PAGTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  WHOST-DATA-80ANOS             PIC  X(010).*/
        public StringBasis WHOST_DATA_80ANOS { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  WHOST-DATA-NASCIMENTO         PIC  X(010).*/
        public StringBasis WHOST_DATA_NASCIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  WHOST-DATA-ADESAO             PIC  9(008).*/
        public IntBasis WHOST_DATA_ADESAO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
        /*"77  WHOST-DATA-FINANCIAMENTO      PIC  X(010).*/
        public StringBasis WHOST_DATA_FINANCIAMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  WHOST-MAX-DTMOVTO             PIC  X(010).*/
        public StringBasis WHOST_MAX_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  WHOST-MAX-DTREFER             PIC  X(010).*/
        public StringBasis WHOST_MAX_DTREFER { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  WHOST-IMP-MORNATU-ATU         PIC S9(013)V99 VALUE +0 COMP-3*/
        public DoubleBasis WHOST_IMP_MORNATU_ATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77  WHOST-IMP-MORACID-ATU         PIC S9(013)V99 VALUE +0 COMP-3*/
        public DoubleBasis WHOST_IMP_MORACID_ATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77  WHOST-IMP-INVPERM-ATU         PIC S9(013)V99 VALUE +0 COMP-3*/
        public DoubleBasis WHOST_IMP_INVPERM_ATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77  WHOST-IMP-AMDS-ATU            PIC S9(013)V99 VALUE +0 COMP-3*/
        public DoubleBasis WHOST_IMP_AMDS_ATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77  WHOST-DH-ATU                  PIC S9(013)V99 VALUE +0 COMP-3*/
        public DoubleBasis WHOST_DH_ATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77  WHOST-DIT-ATU                 PIC S9(013)V99 VALUE +0 COMP-3*/
        public DoubleBasis WHOST_DIT_ATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77  WHOST-PRM-VG-ATU              PIC S9(013)V99 VALUE +0 COMP-3*/
        public DoubleBasis WHOST_PRM_VG_ATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77  WHOST-PRM-AP-ATU              PIC S9(013)V99 VALUE +0 COMP-3*/
        public DoubleBasis WHOST_PRM_AP_ATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77  WHOST-CGCCPF                  PIC S9(015)    VALUE +0 COMP-3*/
        public IntBasis WHOST_CGCCPF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77  WHOST-DATA-NASCIMENTO         PIC  X(010).*/
        public StringBasis WHOST_DATA_NASCIMENTO_0 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  WHOST-TIPO-SEGURADO           PIC  X(001).*/
        public StringBasis WHOST_TIPO_SEGURADO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77  WHOST-APOLICE                 PIC S9(013)    VALUE +0 COMP-3*/
        public IntBasis WHOST_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77  WHOST-SUBGRUPO                PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis WHOST_SUBGRUPO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WHOST-NRCERTIF-PARC           PIC S9(015)    VALUE +0 COMP-3*/
        public IntBasis WHOST_NRCERTIF_PARC { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77  WHOST-NRCERTIF                PIC S9(015)    VALUE +0 COMP-3*/
        public IntBasis WHOST_NRCERTIF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77  WHOST-NRCERTIF-PCP            PIC S9(015)    VALUE +0 COMP-3*/
        public IntBasis WHOST_NRCERTIF_PCP { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77  WHOST-NRCERTIF-MOV            PIC S9(015)    VALUE +0 COMP-3*/
        public IntBasis WHOST_NRCERTIF_MOV { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77  WHOST-NRCERTIF-PROP           PIC S9(015)    VALUE +0 COMP-3*/
        public IntBasis WHOST_NRCERTIF_PROP { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77  WHOST-NRCERTIF-ANT            PIC S9(015)    VALUE +0 COMP-3*/
        public IntBasis WHOST_NRCERTIF_ANT { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77  WHOST-QTDE                    PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis WHOST_QTDE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WHOST-QUANTIDADE              PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis WHOST_QUANTIDADE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WHOST-QTDE-SEGVG              PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis WHOST_QTDE_SEGVG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WHOST-GRUPO                   PIC S9(009)    VALUE +0 COMP.*/
        public IntBasis WHOST_GRUPO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77  WHOST-COTA                    PIC S9(009)    VALUE +0 COMP.*/
        public IntBasis WHOST_COTA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77  WHOST-PREMIO                  PIC S9(013)V99 VALUE +0 COMP-3*/
        public DoubleBasis WHOST_PREMIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77  WHOST-NUM-CERTIFICADO         PIC S9(015)    VALUE +0 COMP-3*/
        public IntBasis WHOST_NUM_CERTIFICADO { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77  WHOST-DAC-CERTIFICADO         PIC  X(001).*/
        public StringBasis WHOST_DAC_CERTIFICADO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77  VIND-LOT-EMP-SEGURADO         PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis VIND_LOT_EMP_SEGURADO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VIND-DATA-AVERBACAO           PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis VIND_DATA_AVERBACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VIND-DATA-ADMISSAO            PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis VIND_DATA_ADMISSAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VIND-DATA-INCLUSAO            PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis VIND_DATA_INCLUSAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VIND-DATA-NASCIMENTO          PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis VIND_DATA_NASCIMENTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VIND-DATA-FATURA              PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis VIND_DATA_FATURA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VIND-COD-EMPRESA              PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis VIND_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VIND-MAXDTMOVTO               PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis VIND_MAXDTMOVTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VIND-MAXDTREFER               PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis VIND_MAXDTREFER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VIND-COD-CRM                  PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis VIND_COD_CRM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VIND-SIGLA-CRM                PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis VIND_SIGLA_CRM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VIND-OPCAO-MARCADA            PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis VIND_OPCAO_MARCADA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VIND-HISCONPA-DATA-FATURA     PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis VIND_HISCONPA_DATA_FATURA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VIND-NRPARCEL-1               PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis VIND_NRPARCEL_1 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VIND-NOME-RAZAO               PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis VIND_NOME_RAZAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VIND-TIPO-PESSOA              PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis VIND_TIPO_PESSOA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VIND-IDE-SEXO                 PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis VIND_IDE_SEXO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VIND-EST-CIVIL                PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis VIND_EST_CIVIL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VIND-OCORR-END                PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis VIND_OCORR_END { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VIND-ENDERECO                 PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis VIND_ENDERECO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VIND-BAIRRO                   PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis VIND_BAIRRO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VIND-CIDADE                   PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis VIND_CIDADE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VIND-SIGLA-UF                 PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis VIND_SIGLA_UF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VIND-CEP                      PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis VIND_CEP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VIND-DDD                      PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis VIND_DDD { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VIND-TELEFONE                 PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis VIND_TELEFONE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VIND-FAX                      PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis VIND_FAX { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VIND-CGCCPF                   PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis VIND_CGCCPF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VIND-DTNASC                   PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis VIND_DTNASC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VIND-CODUSU                   PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis VIND_CODUSU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WS-PROGRAMA                   PIC  X(008)    VALUE SPACES.*/
        public StringBasis WS_PROGRAMA { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
        /*"  01        WRETORNO-REG.*/
        public VG1650B_WRETORNO_REG WRETORNO_REG { get; set; } = new VG1650B_WRETORNO_REG();
        public class VG1650B_WRETORNO_REG : VarBasis
        {
            /*"    10      WRETORNO-NOME       PIC  X(040).*/
            public StringBasis WRETORNO_NOME { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
            /*"    10      WRETORNO-CPF        PIC  9(014).*/
            public IntBasis WRETORNO_CPF { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
            /*"    10      WRETORNO-CONTRATO   PIC  9(008).*/
            public IntBasis WRETORNO_CONTRATO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"    10      WRETORNO-GRUPO      PIC  9(006).*/
            public IntBasis WRETORNO_GRUPO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"    10      WRETORNO-COTA       PIC  9(003).*/
            public IntBasis WRETORNO_COTA { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
            /*"    10      WRETORNO-MENSAGEM   PIC  X(040).*/
            public StringBasis WRETORNO_MENSAGEM { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
            /*"01          FILLER.*/
        }
        public VG1650B_FILLER_5 FILLER_5 { get; set; } = new VG1650B_FILLER_5();
        public class VG1650B_FILLER_5 : VarBasis
        {
            /*"  03        WSQLCODE3           PIC S9(009) COMP.*/
            public IntBasis WSQLCODE3 { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  03        AC-ERROS-QTDE       PIC  9(007)    VALUE ZEROS.*/
            public IntBasis AC_ERROS_QTDE { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03        AC-ERROS-VALOR      PIC  9(013)V99 VALUE ZEROS.*/
            public DoubleBasis AC_ERROS_VALOR { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
            /*"  03        AC-LIDOS-M          PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_LIDOS_M { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03        AC-LIDOS            PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_LIDOS { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03        AC-LIDOS-S          PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_LIDOS_S { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03        AC-LIDOS-PR         PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_LIDOS_PR { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03        AC-LIDOS-OP         PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_LIDOS_OP { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03        AC-I-PROPOSTAVA     PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_I_PROPOSTAVA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03        AC-I-OPCAOPAGVA     PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_I_OPCAOPAGVA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03        AC-I-COBERPROPVA    PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_I_COBERPROPVA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03        AC-U-COBERPROPVA    PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_U_COBERPROPVA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03        AC-U-OPCAOPAGVA     PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_U_OPCAOPAGVA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03        AC-I-PARCELVA       PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_I_PARCELVA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03        AC-I-HISTCOBVA      PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_I_HISTCOBVA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03        AC-I-HISTCTABI      PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_I_HISTCTABI { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03        AC-GRA-PROVA        PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_GRA_PROVA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03        AC-GRA-MVGAP        PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_GRA_MVGAP { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03        AC-GRA-PARVI        PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_GRA_PARVI { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03        AC-GRA-PAGVI        PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_GRA_PAGVI { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03        AC-GRA-HCOPR        PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_GRA_HCOPR { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03        AC-GRA-ERRPR        PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_GRA_ERRPR { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03        AC-GRA-COBVID       PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_GRA_COBVID { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03        AC-GRA-HCONPA       PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_GRA_HCONPA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03        AC-GRA-COMSIC       PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_GRA_COMSIC { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03        AC-GRA-CLIENT       PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_GRA_CLIENT { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03        AC-GRA-ENDERE       PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_GRA_ENDERE { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03        AC-GRA-ENDRIS       PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_GRA_ENDRIS { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03        AC-GRA-PESEMA       PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_GRA_PESEMA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03        AC-GRA-HCOMFD       PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_GRA_HCOMFD { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03        WS-EOF1             PIC  9(001) VALUE ZEROS.*/
            public IntBasis WS_EOF1 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*"  03        WS-EOF2             PIC  9(001) VALUE ZEROS.*/
            public IntBasis WS_EOF2 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*"  03        QTMES               PIC S9(005) COMP-3   VALUE +0.*/
            public IntBasis QTMES { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));
            /*"  03        RESTO               PIC S9(005) COMP-3   VALUE +0.*/
            public IntBasis RESTO { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));
            /*"  03        FL-ERRO             PIC  X(001).*/

            public SelectorBasis FL_ERRO { get; set; } = new SelectorBasis("001")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88      HOUVE-ERRO          VALUE '1'. */
							new SelectorItemBasis("HOUVE_ERRO", "1"),
							/*" 88      NAO-HOUVE-ERRO      VALUE '0'. */
							new SelectorItemBasis("NAO_HOUVE_ERRO", "0")
                }
            };

            /*"  03        WPRIM-VEZ           PIC  9(004)             VALUE  0*/
            public IntBasis WPRIM_VEZ { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  03        WCONTADOR           PIC  9(004)             VALUE  0*/
            public IntBasis WCONTADOR { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  03        WTAM-END            PIC  9(004)             VALUE  0*/
            public IntBasis WTAM_END { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  03        WCONTA              PIC  9(004)             VALUE  0*/
            public IntBasis WCONTA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  03        WENDERECO           PIC  X(072).*/
            public StringBasis WENDERECO { get; set; } = new StringBasis(new PIC("X", "72", "X(072)."), @"");
            /*"  03        WBAIRRO             PIC  X(072).*/
            public StringBasis WBAIRRO { get; set; } = new StringBasis(new PIC("X", "72", "X(072)."), @"");
            /*"  03        WCIDADE             PIC  X(072).*/
            public StringBasis WCIDADE { get; set; } = new StringBasis(new PIC("X", "72", "X(072)."), @"");
            /*"  03        WFIM-CAMPO          PIC  X(001).*/
            public StringBasis WFIM_CAMPO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  03        WCLIENTE-SEG        PIC  X(001).*/
            public StringBasis WCLIENTE_SEG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  03        WCLIENTE-PROP       PIC  X(001).*/
            public StringBasis WCLIENTE_PROP { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  03        WCLIENTE-MOV        PIC  X(001).*/
            public StringBasis WCLIENTE_MOV { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  03        WREG-DUPLICA        PIC  9(007)             VALUE  0*/
            public IntBasis WREG_DUPLICA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03        WFLAG               PIC  9(001)             VALUE  0*/
            public IntBasis WFLAG { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*"  03            WS-TIME         PIC  X(008).*/
            public StringBasis WS_TIME { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"  03            WS-W01DTSQL.*/
            public VG1650B_WS_W01DTSQL WS_W01DTSQL { get; set; } = new VG1650B_WS_W01DTSQL();
            public class VG1650B_WS_W01DTSQL : VarBasis
            {
                /*"    05          WS-W01SCSQL         PIC  9(002).*/
                public IntBasis WS_W01SCSQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05          WS-W01AASQL         PIC  9(002).*/
                public IntBasis WS_W01AASQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05          WS-W01T1SQL         PIC  X(001) VALUE '-'.*/
                public StringBasis WS_W01T1SQL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"    05          WS-W01MMSQL         PIC  9(002).*/
                public IntBasis WS_W01MMSQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05          WS-W01T2SQL         PIC  X(001) VALUE '-'.*/
                public StringBasis WS_W01T2SQL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"    05          WS-W01DDSQL         PIC  9(002).*/
                public IntBasis WS_W01DDSQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03            WS-W02DTSQL.*/
            }
            public VG1650B_WS_W02DTSQL WS_W02DTSQL { get; set; } = new VG1650B_WS_W02DTSQL();
            public class VG1650B_WS_W02DTSQL : VarBasis
            {
                /*"    05          WS-W02AASQL         PIC  9(004).*/
                public IntBasis WS_W02AASQL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05          WS-W02T1SQL         PIC  X(001) VALUE '-'.*/
                public StringBasis WS_W02T1SQL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"    05          WS-W02MMSQL         PIC  9(002).*/
                public IntBasis WS_W02MMSQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05          WS-W02T2SQL         PIC  X(001) VALUE '-'.*/
                public StringBasis WS_W02T2SQL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"    05          WS-W02DDSQL         PIC  9(002).*/
                public IntBasis WS_W02DDSQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03            WS-W03DTSQL.*/
            }
            public VG1650B_WS_W03DTSQL WS_W03DTSQL { get; set; } = new VG1650B_WS_W03DTSQL();
            public class VG1650B_WS_W03DTSQL : VarBasis
            {
                /*"    05          WS-W03AASQL         PIC  9(004).*/
                public IntBasis WS_W03AASQL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05          WS-W03T1SQL         PIC  X(001) VALUE '-'.*/
                public StringBasis WS_W03T1SQL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"    05          WS-W03MMSQL         PIC  9(002).*/
                public IntBasis WS_W03MMSQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05          WS-W03T2SQL         PIC  X(001) VALUE '-'.*/
                public StringBasis WS_W03T2SQL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"    05          WS-W03DDSQL         PIC  9(002).*/
                public IntBasis WS_W03DDSQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03            WS-W05DTREF.*/
            }
            public VG1650B_WS_W05DTREF WS_W05DTREF { get; set; } = new VG1650B_WS_W05DTREF();
            public class VG1650B_WS_W05DTREF : VarBasis
            {
                /*"    05          WS-W05AAREF         PIC  9(004).*/
                public IntBasis WS_W05AAREF { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05          WS-W05MMREF         PIC  9(002).*/
                public IntBasis WS_W05MMREF { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05          WS-W05DDREF         PIC  9(002).*/
                public IntBasis WS_W05DDREF { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03            WS-W02DTSQL-GERA.*/
            }
            public VG1650B_WS_W02DTSQL_GERA WS_W02DTSQL_GERA { get; set; } = new VG1650B_WS_W02DTSQL_GERA();
            public class VG1650B_WS_W02DTSQL_GERA : VarBasis
            {
                /*"    05          WS-W02AASQL-G       PIC  9(004).*/
                public IntBasis WS_W02AASQL_G { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05          WS-W02T1SQL-G       PIC  X(001) VALUE '-'.*/
                public StringBasis WS_W02T1SQL_G { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"    05          WS-W02MMSQL-G       PIC  9(002).*/
                public IntBasis WS_W02MMSQL_G { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05          WS-W02T2SQL-G       PIC  X(001) VALUE '-'.*/
                public StringBasis WS_W02T2SQL_G { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"    05          WS-W02DDSQL-G       PIC  9(002).*/
                public IntBasis WS_W02DDSQL_G { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03            WK-DATA1.*/
            }
            public VG1650B_WK_DATA1 WK_DATA1 { get; set; } = new VG1650B_WK_DATA1();
            public class VG1650B_WK_DATA1 : VarBasis
            {
                /*"    10          WS-SEC1           PIC  9(002).*/
                public IntBasis WS_SEC1 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10          WK-ANO1           PIC  9(002).*/
                public IntBasis WK_ANO1 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10          FILLER            PIC  X(001).*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10          WK-MES1           PIC  9(002).*/
                public IntBasis WK_MES1 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10          FILLER            PIC  X(001).*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10          WK-DIA1           PIC  9(002).*/
                public IntBasis WK_DIA1 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03            WS-DATA-NASC      PIC  X(008).*/
            }
            public StringBasis WS_DATA_NASC { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"  03            WS-DATA-ADESAO    PIC  9(008).*/
            public IntBasis WS_DATA_ADESAO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"  03            WS-DATA-ADESAO-R  REDEFINES                WS-DATA-ADESAO.*/
            private _REDEF_VG1650B_WS_DATA_ADESAO_R _ws_data_adesao_r { get; set; }
            public _REDEF_VG1650B_WS_DATA_ADESAO_R WS_DATA_ADESAO_R
            {
                get { _ws_data_adesao_r = new _REDEF_VG1650B_WS_DATA_ADESAO_R(); _.Move(WS_DATA_ADESAO, _ws_data_adesao_r); VarBasis.RedefinePassValue(WS_DATA_ADESAO, _ws_data_adesao_r, WS_DATA_ADESAO); _ws_data_adesao_r.ValueChanged += () => { _.Move(_ws_data_adesao_r, WS_DATA_ADESAO); }; return _ws_data_adesao_r; }
                set { VarBasis.RedefinePassValue(value, _ws_data_adesao_r, WS_DATA_ADESAO); }
            }  //Redefines
            public class _REDEF_VG1650B_WS_DATA_ADESAO_R : VarBasis
            {
                /*"    10          WS-ANO-ADESAO     PIC  9(004).*/
                public IntBasis WS_ANO_ADESAO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10          WS-MES-ADESAO     PIC  9(002).*/
                public IntBasis WS_MES_ADESAO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10          WS-DIA-ADESAO     PIC  9(002).*/
                public IntBasis WS_DIA_ADESAO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03            WS-DTH-CRITICA    PIC  9(008).*/

                public _REDEF_VG1650B_WS_DATA_ADESAO_R()
                {
                    WS_ANO_ADESAO.ValueChanged += OnValueChanged;
                    WS_MES_ADESAO.ValueChanged += OnValueChanged;
                    WS_DIA_ADESAO.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WS_DTH_CRITICA { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"  03            WS-DTH-CRITICA-R  REDEFINES                WS-DTH-CRITICA.*/
            private _REDEF_VG1650B_WS_DTH_CRITICA_R _ws_dth_critica_r { get; set; }
            public _REDEF_VG1650B_WS_DTH_CRITICA_R WS_DTH_CRITICA_R
            {
                get { _ws_dth_critica_r = new _REDEF_VG1650B_WS_DTH_CRITICA_R(); _.Move(WS_DTH_CRITICA, _ws_dth_critica_r); VarBasis.RedefinePassValue(WS_DTH_CRITICA, _ws_dth_critica_r, WS_DTH_CRITICA); _ws_dth_critica_r.ValueChanged += () => { _.Move(_ws_dth_critica_r, WS_DTH_CRITICA); }; return _ws_dth_critica_r; }
                set { VarBasis.RedefinePassValue(value, _ws_dth_critica_r, WS_DTH_CRITICA); }
            }  //Redefines
            public class _REDEF_VG1650B_WS_DTH_CRITICA_R : VarBasis
            {
                /*"    10          WS-CRITICA-ANO    PIC  9(004).*/
                public IntBasis WS_CRITICA_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10          WS-CRITICA-MES    PIC  9(002).*/
                public IntBasis WS_CRITICA_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10          WS-CRITICA-DIA    PIC  9(002).*/
                public IntBasis WS_CRITICA_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03            WS-DATA-AUX-1.*/

                public _REDEF_VG1650B_WS_DTH_CRITICA_R()
                {
                    WS_CRITICA_ANO.ValueChanged += OnValueChanged;
                    WS_CRITICA_MES.ValueChanged += OnValueChanged;
                    WS_CRITICA_DIA.ValueChanged += OnValueChanged;
                }

            }
            public VG1650B_WS_DATA_AUX_1 WS_DATA_AUX_1 { get; set; } = new VG1650B_WS_DATA_AUX_1();
            public class VG1650B_WS_DATA_AUX_1 : VarBasis
            {
                /*"    05          WS-DIA-AUX-1        PIC  9(002).*/
                public IntBasis WS_DIA_AUX_1 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05          WS-MES-AUX-1        PIC  9(002).*/
                public IntBasis WS_MES_AUX_1 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05          WS-ANO-AUX-1        PIC  9(004).*/
                public IntBasis WS_ANO_AUX_1 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"  03            WS-DATA-AUX.*/
            }
            public VG1650B_WS_DATA_AUX WS_DATA_AUX { get; set; } = new VG1650B_WS_DATA_AUX();
            public class VG1650B_WS_DATA_AUX : VarBasis
            {
                /*"    05          WS-ANO-AUX          PIC  9(004).*/
                public IntBasis WS_ANO_AUX { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05          WS-TRA1-AUX         PIC  X(001) VALUE '-'.*/
                public StringBasis WS_TRA1_AUX { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"    05          WS-MES-AUX          PIC  9(002).*/
                public IntBasis WS_MES_AUX { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05          WS-TRA2-AUX         PIC  X(001) VALUE '-'.*/
                public StringBasis WS_TRA2_AUX { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"    05          WS-DIA-AUX          PIC  9(002).*/
                public IntBasis WS_DIA_AUX { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03            WS-DATA-INICIAL.*/
            }
            public VG1650B_WS_DATA_INICIAL WS_DATA_INICIAL { get; set; } = new VG1650B_WS_DATA_INICIAL();
            public class VG1650B_WS_DATA_INICIAL : VarBasis
            {
                /*"    05          WS-ANO-INI          PIC  9(004).*/
                public IntBasis WS_ANO_INI { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05          WS-TRA1-INI         PIC  X(001) VALUE '-'.*/
                public StringBasis WS_TRA1_INI { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"    05          WS-MES-INI          PIC  9(002).*/
                public IntBasis WS_MES_INI { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05          WS-TRA2-INI         PIC  X(001) VALUE '-'.*/
                public StringBasis WS_TRA2_INI { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"    05          WS-DIA-INI          PIC  9(002).*/
                public IntBasis WS_DIA_INI { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03            WS-DATA-FINAL.*/
            }
            public VG1650B_WS_DATA_FINAL WS_DATA_FINAL { get; set; } = new VG1650B_WS_DATA_FINAL();
            public class VG1650B_WS_DATA_FINAL : VarBasis
            {
                /*"    05          WS-ANO-FIM          PIC  9(004).*/
                public IntBasis WS_ANO_FIM { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05          WS-TRA1-FIM         PIC  X(001) VALUE '-'.*/
                public StringBasis WS_TRA1_FIM { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"    05          WS-MES-FIM          PIC  9(002).*/
                public IntBasis WS_MES_FIM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05          WS-TRA2-FIM         PIC  X(001) VALUE '-'.*/
                public StringBasis WS_TRA2_FIM { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"    05          WS-DIA-FIM          PIC  9(002).*/
                public IntBasis WS_DIA_FIM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03            WS-DATA-SQL.*/
            }
            public VG1650B_WS_DATA_SQL WS_DATA_SQL { get; set; } = new VG1650B_WS_DATA_SQL();
            public class VG1650B_WS_DATA_SQL : VarBasis
            {
                /*"    05          WS-SEC-SQL          PIC  9(002) VALUE 19.*/
                public IntBasis WS_SEC_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"), 19);
                /*"    05          WS-ANO-SQL          PIC  9(002).*/
                public IntBasis WS_ANO_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05          WS-TRA1             PIC  X(001) VALUE '-'.*/
                public StringBasis WS_TRA1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"    05          WS-MES-SQL          PIC  9(002).*/
                public IntBasis WS_MES_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05          WS-TRA2             PIC  X(001) VALUE '-'.*/
                public StringBasis WS_TRA2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"    05          WS-DIA-SQL          PIC  9(002).*/
                public IntBasis WS_DIA_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03         WS-DATA.*/
            }
            public VG1650B_WS_DATA WS_DATA { get; set; } = new VG1650B_WS_DATA();
            public class VG1650B_WS_DATA : VarBasis
            {
                /*"    10       WS-SEC            PIC  9(002)    VALUE 19.*/
                public IntBasis WS_SEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"), 19);
                /*"    10       WS-ANO            PIC  9(002).*/
                public IntBasis WS_ANO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WS-MES            PIC  9(002).*/
                public IntBasis WS_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WS-DIA            PIC  9(002).*/
                public IntBasis WS_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03         W01GRUPOCOTA      PIC  9(009)    VALUE ZEROS.*/
            }
            public IntBasis W01GRUPOCOTA { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03         FILLER            REDEFINES      W01GRUPOCOTA.*/
            private _REDEF_VG1650B_FILLER_10 _filler_10 { get; set; }
            public _REDEF_VG1650B_FILLER_10 FILLER_10
            {
                get { _filler_10 = new _REDEF_VG1650B_FILLER_10(); _.Move(W01GRUPOCOTA, _filler_10); VarBasis.RedefinePassValue(W01GRUPOCOTA, _filler_10, W01GRUPOCOTA); _filler_10.ValueChanged += () => { _.Move(_filler_10, W01GRUPOCOTA); }; return _filler_10; }
                set { VarBasis.RedefinePassValue(value, _filler_10, W01GRUPOCOTA); }
            }  //Redefines
            public class _REDEF_VG1650B_FILLER_10 : VarBasis
            {
                /*"    10       W01-GRUPO         PIC  9(006).*/
                public IntBasis W01_GRUPO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"    10       W01-COTA          PIC  9(003).*/
                public IntBasis W01_COTA { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"  03         W01DTCSP          PIC  9(008)    VALUE ZEROS.*/

                public _REDEF_VG1650B_FILLER_10()
                {
                    W01_GRUPO.ValueChanged += OnValueChanged;
                    W01_COTA.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis W01DTCSP { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"  03         FILLER            REDEFINES      W01DTCSP.*/
            private _REDEF_VG1650B_FILLER_11 _filler_11 { get; set; }
            public _REDEF_VG1650B_FILLER_11 FILLER_11
            {
                get { _filler_11 = new _REDEF_VG1650B_FILLER_11(); _.Move(W01DTCSP, _filler_11); VarBasis.RedefinePassValue(W01DTCSP, _filler_11, W01DTCSP); _filler_11.ValueChanged += () => { _.Move(_filler_11, W01DTCSP); }; return _filler_11; }
                set { VarBasis.RedefinePassValue(value, _filler_11, W01DTCSP); }
            }  //Redefines
            public class _REDEF_VG1650B_FILLER_11 : VarBasis
            {
                /*"    10       W01DDCSP          PIC  9(002).*/
                public IntBasis W01DDCSP { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       W01MMCSP          PIC  9(002).*/
                public IntBasis W01MMCSP { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       W01SCCSP          PIC  9(002).*/
                public IntBasis W01SCCSP { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       W01AACSP          PIC  9(002).*/
                public IntBasis W01AACSP { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03         W02DTCSP          PIC  9(008)    VALUE ZEROS.*/

                public _REDEF_VG1650B_FILLER_11()
                {
                    W01DDCSP.ValueChanged += OnValueChanged;
                    W01MMCSP.ValueChanged += OnValueChanged;
                    W01SCCSP.ValueChanged += OnValueChanged;
                    W01AACSP.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis W02DTCSP { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"  03         FILLER            REDEFINES      W02DTCSP.*/
            private _REDEF_VG1650B_FILLER_12 _filler_12 { get; set; }
            public _REDEF_VG1650B_FILLER_12 FILLER_12
            {
                get { _filler_12 = new _REDEF_VG1650B_FILLER_12(); _.Move(W02DTCSP, _filler_12); VarBasis.RedefinePassValue(W02DTCSP, _filler_12, W02DTCSP); _filler_12.ValueChanged += () => { _.Move(_filler_12, W02DTCSP); }; return _filler_12; }
                set { VarBasis.RedefinePassValue(value, _filler_12, W02DTCSP); }
            }  //Redefines
            public class _REDEF_VG1650B_FILLER_12 : VarBasis
            {
                /*"    10       W02DDCSP          PIC  9(002).*/
                public IntBasis W02DDCSP { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       W02MMCSP          PIC  9(002).*/
                public IntBasis W02MMCSP { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       W02SCCSP          PIC  9(002).*/
                public IntBasis W02SCCSP { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       W02AACSP          PIC  9(002).*/
                public IntBasis W02AACSP { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03         WS-DTREF          PIC  9(006)    VALUE ZEROS.*/

                public _REDEF_VG1650B_FILLER_12()
                {
                    W02DDCSP.ValueChanged += OnValueChanged;
                    W02MMCSP.ValueChanged += OnValueChanged;
                    W02SCCSP.ValueChanged += OnValueChanged;
                    W02AACSP.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WS_DTREF { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  03         FILLER            REDEFINES      WS-DTREF.*/
            private _REDEF_VG1650B_FILLER_13 _filler_13 { get; set; }
            public _REDEF_VG1650B_FILLER_13 FILLER_13
            {
                get { _filler_13 = new _REDEF_VG1650B_FILLER_13(); _.Move(WS_DTREF, _filler_13); VarBasis.RedefinePassValue(WS_DTREF, _filler_13, WS_DTREF); _filler_13.ValueChanged += () => { _.Move(_filler_13, WS_DTREF); }; return _filler_13; }
                set { VarBasis.RedefinePassValue(value, _filler_13, WS_DTREF); }
            }  //Redefines
            public class _REDEF_VG1650B_FILLER_13 : VarBasis
            {
                /*"    10       WS-REF-ANO        PIC  9(004).*/
                public IntBasis WS_REF_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       WS-REF-MES        PIC  9(002).*/
                public IntBasis WS_REF_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03         WS-DTREF-SQL      PIC  X(010).*/

                public _REDEF_VG1650B_FILLER_13()
                {
                    WS_REF_ANO.ValueChanged += OnValueChanged;
                    WS_REF_MES.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WS_DTREF_SQL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  03         FILLER            REDEFINES      WS-DTREF-SQL.*/
            private _REDEF_VG1650B_FILLER_14 _filler_14 { get; set; }
            public _REDEF_VG1650B_FILLER_14 FILLER_14
            {
                get { _filler_14 = new _REDEF_VG1650B_FILLER_14(); _.Move(WS_DTREF_SQL, _filler_14); VarBasis.RedefinePassValue(WS_DTREF_SQL, _filler_14, WS_DTREF_SQL); _filler_14.ValueChanged += () => { _.Move(_filler_14, WS_DTREF_SQL); }; return _filler_14; }
                set { VarBasis.RedefinePassValue(value, _filler_14, WS_DTREF_SQL); }
            }  //Redefines
            public class _REDEF_VG1650B_FILLER_14 : VarBasis
            {
                /*"    10       WS-REF-ANO-SQL    PIC  9(004).*/
                public IntBasis WS_REF_ANO_SQL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       WS-REF-TRA1-SQL   PIC  X(001).*/
                public StringBasis WS_REF_TRA1_SQL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WS-REF-MES-SQL    PIC  9(002).*/
                public IntBasis WS_REF_MES_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       WS-REF-TRA2-SQL   PIC  X(001).*/
                public StringBasis WS_REF_TRA2_SQL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WS-REF-DIA-SQL    PIC  9(002).*/
                public IntBasis WS_REF_DIA_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03        WPRMTOT                  PIC S9(013)V99                                        VALUE +0 COMP-3.*/

                public _REDEF_VG1650B_FILLER_14()
                {
                    WS_REF_ANO_SQL.ValueChanged += OnValueChanged;
                    WS_REF_TRA1_SQL.ValueChanged += OnValueChanged;
                    WS_REF_MES_SQL.ValueChanged += OnValueChanged;
                    WS_REF_TRA2_SQL.ValueChanged += OnValueChanged;
                    WS_REF_DIA_SQL.ValueChanged += OnValueChanged;
                }

            }
            public DoubleBasis WPRMTOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  03        PARCEL-SEG               PIC  9(004) VALUE ZEROS.*/
            public IntBasis PARCEL_SEG { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  03        PARCEL-PROP              PIC  9(004) VALUE ZEROS.*/
            public IntBasis PARCEL_PROP { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  03        CPF-SEG-ANT              PIC  9(014) VALUE ZEROS.*/
            public IntBasis CPF_SEG_ANT { get; set; } = new IntBasis(new PIC("9", "14", "9(014)"));
            /*"  03        GRUPO-SEG-ANT            PIC  9(009) VALUE ZEROS.*/
            public IntBasis GRUPO_SEG_ANT { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03        COTA-SEG-ANT             PIC  9(009) VALUE ZEROS.*/
            public IntBasis COTA_SEG_ANT { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03        AC-EMITIDOS              PIC  9(007) VALUE 0.*/
            public IntBasis AC_EMITIDOS { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03        AC-SOLICITADOS           PIC  9(007) VALUE 0.*/
            public IntBasis AC_SOLICITADOS { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03        W-LIDOS                  PIC  9(007) VALUE 0.*/
            public IntBasis W_LIDOS { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03        WAC-LIDOS                PIC  9(007) VALUE 0.*/
            public IntBasis WAC_LIDOS { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03        W-GRAVADOS               PIC  9(007) VALUE 0.*/
            public IntBasis W_GRAVADOS { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"01        REG-TIPO-B.*/
        }
        public VG1650B_REG_TIPO_B REG_TIPO_B { get; set; } = new VG1650B_REG_TIPO_B();
        public class VG1650B_REG_TIPO_B : VarBasis
        {
            /*"    05    R24-TIPO-REG                 PIC  X(001).*/
            public StringBasis R24_TIPO_REG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    05    R24-NUM-PROPOSTA             PIC  9(014).*/
            public IntBasis R24_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
            /*"    05    R24-TIPO-INFORMACAO          PIC  9(002).*/
            public IntBasis R24_TIPO_INFORMACAO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"    05    R24-INFO-CORRESPONDENCIA     PIC  9(001).*/
            public IntBasis R24_INFO_CORRESPONDENCIA { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"    05    R24-IC-GRAURISCO             PIC  9(002).*/
            public IntBasis R24_IC_GRAURISCO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"    05    R24-COD-CNAE                 PIC  9(010).*/
            public IntBasis R24_COD_CNAE { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
            /*"    05    R24-DDD-TEL-FAX              PIC  9(003).*/
            public IntBasis R24_DDD_TEL_FAX { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
            /*"    05    R24-NUM-TEL-FAX              PIC  9(009).*/
            public IntBasis R24_NUM_TEL_FAX { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"    05    R24-NUM-CARTAO               PIC  9(016).*/
            public IntBasis R24_NUM_CARTAO { get; set; } = new IntBasis(new PIC("9", "16", "9(016)."));
            /*"    05    R24-AREA-ADMINIST            PIC  X(001).*/
            public StringBasis R24_AREA_ADMINIST { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    05    R24-BCOCTADEB                PIC  9(003).*/
            public IntBasis R24_BCOCTADEB { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
            /*"    05    R24-AGECTADEB                PIC  9(004).*/
            public IntBasis R24_AGECTADEB { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    05    R24-OPRCTADEB                PIC  9(004).*/
            public IntBasis R24_OPRCTADEB { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    05    R24-NUMCTADEB                PIC  9(012).*/
            public IntBasis R24_NUMCTADEB { get; set; } = new IntBasis(new PIC("9", "12", "9(012)."));
            /*"    05    R24-DIGCTADEB                PIC  X(001).*/
            public StringBasis R24_DIGCTADEB { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    05    R24-NOM-MAE                  PIC  X(040).*/
            public StringBasis R24_NOM_MAE { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
            /*"    05    R24-NUM-CART                 PIC  9(015).*/
            public IntBasis R24_NUM_CART { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
            /*"    05    R24-NUM-CERT-ANTERIOR        PIC  9(015).*/
            public IntBasis R24_NUM_CERT_ANTERIOR { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
            /*"    05    R24-NOME-EVENTO              PIC  X(040).*/
            public StringBasis R24_NOME_EVENTO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
            /*"    05    R24-NUM-PEDIDO               PIC  9(015).*/
            public IntBasis R24_NUM_PEDIDO { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
            /*"    05    R24-COD-LOCAL                PIC  9(009).*/
            public IntBasis R24_COD_LOCAL { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"    05    R24-NUM-INGRESSO             PIC  9(009).*/
            public IntBasis R24_NUM_INGRESSO { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"    05    FILLER                       PIC  X(074).*/
            public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "74", "X(074)."), @"");
            /*"01        REG-LEITURA.*/
        }
        public VG1650B_REG_LEITURA REG_LEITURA { get; set; } = new VG1650B_REG_LEITURA();
        public class VG1650B_REG_LEITURA : VarBasis
        {
            /*"   05     MV-VOUCHER           PIC  9(010).*/
            public IntBasis MV_VOUCHER { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
            /*"   05     MV-NOME-PASSAG       PIC  X(070).*/
            public StringBasis MV_NOME_PASSAG { get; set; } = new StringBasis(new PIC("X", "70", "X(070)."), @"");
            /*"   05     MV-CPF-PASSAG        PIC  9(015).*/
            public IntBasis MV_CPF_PASSAG { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
            /*"   05     MV-DTNASC-PASSAG     PIC  X(010).*/
            public StringBasis MV_DTNASC_PASSAG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"   05     MV-SEXO-PASSAG       PIC  X(001).*/
            public StringBasis MV_SEXO_PASSAG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"   05     MV-MORTE-ACIDENTAL-1 PIC  X(025).*/
            public StringBasis MV_MORTE_ACIDENTAL_1 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)."), @"");
            /*"   05     MV-INVALIDEZ-ACID-1  PIC  X(025).*/
            public StringBasis MV_INVALIDEZ_ACID_1 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)."), @"");
            /*"   05     MV-BAGAGEM-EXTRAV-1  PIC  X(025).*/
            public StringBasis MV_BAGAGEM_EXTRAV_1 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)."), @"");
            /*"   05     MV-DECESSO-1         PIC  X(025).*/
            public StringBasis MV_DECESSO_1 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)."), @"");
            /*"   05     MV-CANCEL-VIAGEM-1   PIC  X(025).*/
            public StringBasis MV_CANCEL_VIAGEM_1 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)."), @"");
            /*"   05     MV-RESP-CIVIL-1      PIC  X(025).*/
            public StringBasis MV_RESP_CIVIL_1 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)."), @"");
            /*"   05     MV-ACIDENTES-PESS-1  PIC  X(025).*/
            public StringBasis MV_ACIDENTES_PESS_1 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)."), @"");
            /*"   05     MV-PREMIO-1          PIC  X(025).*/
            public StringBasis MV_PREMIO_1 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)."), @"");
            /*"   05     MV-DATA-INIVIG       PIC  X(010).*/
            public StringBasis MV_DATA_INIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"   05     MV-DATA-TERVIG       PIC  X(010).*/
            public StringBasis MV_DATA_TERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"   05     MV-MORTE-ACIDENTAL  PIC  9(16)V9999.*/
            public DoubleBasis MV_MORTE_ACIDENTAL { get; set; } = new DoubleBasis(new PIC("9", "16", "9(16)V9999."), 4);
            /*"   05     MV-INVALIDEZ-ACID   PIC  9(16)V9999.*/
            public DoubleBasis MV_INVALIDEZ_ACID { get; set; } = new DoubleBasis(new PIC("9", "16", "9(16)V9999."), 4);
            /*"   05     MV-BAGAGEM-EXTRAV   PIC  9(16)V9999.*/
            public DoubleBasis MV_BAGAGEM_EXTRAV { get; set; } = new DoubleBasis(new PIC("9", "16", "9(16)V9999."), 4);
            /*"   05     MV-DECESSO          PIC  9(16)V9999.*/
            public DoubleBasis MV_DECESSO { get; set; } = new DoubleBasis(new PIC("9", "16", "9(16)V9999."), 4);
            /*"   05     MV-CANCEL-VIAGEM    PIC  9(16)V9999.*/
            public DoubleBasis MV_CANCEL_VIAGEM { get; set; } = new DoubleBasis(new PIC("9", "16", "9(16)V9999."), 4);
            /*"   05     MV-RESP-CIVIL       PIC  9(16)V9999.*/
            public DoubleBasis MV_RESP_CIVIL { get; set; } = new DoubleBasis(new PIC("9", "16", "9(16)V9999."), 4);
            /*"   05     MV-ACIDENTES-PESS   PIC  9(16)V9999.*/
            public DoubleBasis MV_ACIDENTES_PESS { get; set; } = new DoubleBasis(new PIC("9", "16", "9(16)V9999."), 4);
            /*"   05     MV-PREMIO           PIC  9(16)V9999.*/
            public DoubleBasis MV_PREMIO { get; set; } = new DoubleBasis(new PIC("9", "16", "9(16)V9999."), 4);
            /*"   05     WS-VALOR-E          PIC  X(25).*/
            public StringBasis WS_VALOR_E { get; set; } = new StringBasis(new PIC("X", "25", "X(25)."), @"");
            /*"   05     WS-VALOR            PIC  9(16)V9999.*/
            public DoubleBasis WS_VALOR { get; set; } = new DoubleBasis(new PIC("9", "16", "9(16)V9999."), 4);
            /*"   05     WS-NOME-E           PIC  X(80).*/
            public StringBasis WS_NOME_E { get; set; } = new StringBasis(new PIC("X", "80", "X(80)."), @"");
            /*"   05     WS-DATA-INI         PIC  X(10).*/
            public StringBasis WS_DATA_INI { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"   05     WS-DATA-FIN         PIC  X(10).*/
            public StringBasis WS_DATA_FIN { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"  03        FILLER.*/
            public VG1650B_FILLER_16 FILLER_16 { get; set; } = new VG1650B_FILLER_16();
            public class VG1650B_FILLER_16 : VarBasis
            {
                /*"    05      WFIM-V1AGENCEF           PIC  X(003) VALUE 'NAO'.*/
                public StringBasis WFIM_V1AGENCEF { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
                /*"    05      WTEM-PARCEVID            PIC  X(003) VALUE 'NAO'.*/
                public StringBasis WTEM_PARCEVID { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
                /*"    05      WTEM-ERRO-DATA           PIC  X(003) VALUE 'NAO'.*/
                public StringBasis WTEM_ERRO_DATA { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
                /*"    05      WTEM-ERRO-DEMAIS         PIC  X(003) VALUE 'NAO'.*/
                public StringBasis WTEM_ERRO_DEMAIS { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
                /*"    05      WTEM-ERRO-FATAL          PIC  X(003) VALUE 'NAO'.*/
                public StringBasis WTEM_ERRO_FATAL { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
                /*"    05      WTEM-FUNCICEF            PIC  X(003) VALUE 'NAO'.*/
                public StringBasis WTEM_FUNCICEF { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
                /*"    05      WTEM-NRPARCEL            PIC  X(003) VALUE 'NAO'.*/
                public StringBasis WTEM_NRPARCEL { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
                /*"    05      WGERA-PARCELA            PIC  X(003) VALUE 'NAO'.*/
                public StringBasis WGERA_PARCELA { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
                /*"    05      WTEM-INTERVALO           PIC  X(003) VALUE 'NAO'.*/
                public StringBasis WTEM_INTERVALO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
                /*"    05      WTEM-SEGURVGA            PIC  X(003) VALUE 'NAO'.*/
                public StringBasis WTEM_SEGURVGA { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
                /*"    05      WTEM-CLIENTES            PIC  X(003) VALUE 'NAO'.*/
                public StringBasis WTEM_CLIENTES { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
                /*"    05      WTEM-HISTCOBVA           PIC  X(003) VALUE 'NAO'.*/
                public StringBasis WTEM_HISTCOBVA { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
                /*"    05      WTEM-HISTCONTABILVA      PIC  X(003) VALUE 'NAO'.*/
                public StringBasis WTEM_HISTCONTABILVA { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
                /*"    05      WTEM-HISTCONTABILVA2     PIC  X(003) VALUE 'NAO'.*/
                public StringBasis WTEM_HISTCONTABILVA2 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
                /*"    05      WTEM-COBERPROPVA         PIC  X(003) VALUE 'NAO'.*/
                public StringBasis WTEM_COBERPROPVA { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
                /*"    05      WTEM-ERRO-IDADE          PIC  X(001) VALUE 'N'.*/
                public StringBasis WTEM_ERRO_IDADE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
                /*"    05      WTEM-SEGURADO            PIC  X(003) VALUE 'NAO'.*/
                public StringBasis WTEM_SEGURADO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
                /*"    05      WTEM-VGSEGCON            PIC  X(003) VALUE 'NAO'.*/
                public StringBasis WTEM_VGSEGCON { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
                /*"    05      WTEM-PLANO-VGAP          PIC  X(003) VALUE 'NAO'.*/
                public StringBasis WTEM_PLANO_VGAP { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
                /*"    05      WFIM-APOLICE             PIC  X(001) VALUE 'N'.*/
                public StringBasis WFIM_APOLICE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
                /*"    05      FLAG-WFIM-MOVIMENTO      PIC  9(001) VALUE 0.*/

                public SelectorBasis FLAG_WFIM_MOVIMENTO { get; set; } = new SelectorBasis("001", "0")
                {
                    Items = new List<SelectorItemBasis> {
                            /*" 88    FIM-MOVIMENTO            VALUE 1. */
							new SelectorItemBasis("FIM_MOVIMENTO", "1")
                }
                };

                /*"    05      FLAG-WFIM-SEGURADO             PIC  9(001) VALUE 0.*/

                public SelectorBasis FLAG_WFIM_SEGURADO { get; set; } = new SelectorBasis("001", "0")
                {
                    Items = new List<SelectorItemBasis> {
                            /*" 88    FIM-SEGURADO                   VALUE 1. */
							new SelectorItemBasis("FIM_SEGURADO", "1")
                }
                };

                /*"    03      WABEND.*/
                public VG1650B_WABEND WABEND { get; set; } = new VG1650B_WABEND();
                public class VG1650B_WABEND : VarBasis
                {
                    /*"      05      FILLER              PIC  X(010) VALUE             ' VG1650B'.*/
                    public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" VG1650B");
                    /*"      05      FILLER              PIC  X(028) VALUE             ' *** ERRO  EXEC SQL  NUMERO '.*/
                    public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @" *** ERRO  EXEC SQL  NUMERO ");
                    /*"      05      WNR-EXEC-SQL        PIC  X(004) VALUE '0000'.*/
                    public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"0000");
                    /*"      05      FILLER              PIC  X(017) VALUE             ' *** PARAGRAFO = '.*/
                    public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "17", "X(017)"), @" *** PARAGRAFO = ");
                    /*"      05      PARAGRAFO           PIC  X(030) VALUE SPACES.*/
                    public StringBasis PARAGRAFO { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"");
                    /*"      05      FILLER              PIC  X(014) VALUE             '    SQLCODE = '.*/
                    public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE = ");
                    /*"      05      WSQLCODE            PIC  ZZZZZZ999- VALUE ZEROS.*/
                    public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
                    /*"      05      FILLER              PIC  X(014) VALUE             '    SQLCODE1= '.*/
                    public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE1= ");
                    /*"      05      WSQLCODE1           PIC  ZZZZZZ999- VALUE ZEROS.*/
                    public IntBasis WSQLCODE1 { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
                    /*"      05      FILLER              PIC  X(014) VALUE             '    SQLCODE2= '.*/
                    public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE2= ");
                    /*"      05      WSQLCODE2           PIC  ZZZZZZ999- VALUE ZEROS.*/
                    public IntBasis WSQLCODE2 { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
                    /*"    03         WSQLERRO.*/
                }
                public VG1650B_WSQLERRO WSQLERRO { get; set; } = new VG1650B_WSQLERRO();
                public class VG1650B_WSQLERRO : VarBasis
                {
                    /*"      05         FILLER               PIC  X(014) VALUE                ' *** SQLERRMC '.*/
                    public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @" *** SQLERRMC ");
                    /*"      05         WSQLERRMC            PIC  X(070) VALUE  SPACES.*/
                    public StringBasis WSQLERRMC { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"");
                    /*"    03         LOCALIZA-ABEND-2.*/
                }
                public VG1650B_LOCALIZA_ABEND_2 LOCALIZA_ABEND_2 { get; set; } = new VG1650B_LOCALIZA_ABEND_2();
                public class VG1650B_LOCALIZA_ABEND_2 : VarBasis
                {
                    /*"      05         FILLER               PIC  X(012)   VALUE                'COMANDO   = '.*/
                    public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"COMANDO   = ");
                    /*"      05        COMANDO               PIC  X(060)   VALUE SPACES*/
                    public StringBasis COMANDO { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"");
                    /*"  03  W-NUMR-TITULO                  PIC  9(013)   VALUE ZEROS.*/
                }
            }
            public IntBasis W_NUMR_TITULO { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
            /*"  03  FILLER                         REDEFINES    W-NUMR-TITULO.*/
            private _REDEF_VG1650B_FILLER_25 _filler_25 { get; set; }
            public _REDEF_VG1650B_FILLER_25 FILLER_25
            {
                get { _filler_25 = new _REDEF_VG1650B_FILLER_25(); _.Move(W_NUMR_TITULO, _filler_25); VarBasis.RedefinePassValue(W_NUMR_TITULO, _filler_25, W_NUMR_TITULO); _filler_25.ValueChanged += () => { _.Move(_filler_25, W_NUMR_TITULO); }; return _filler_25; }
                set { VarBasis.RedefinePassValue(value, _filler_25, W_NUMR_TITULO); }
            }  //Redefines
            public class _REDEF_VG1650B_FILLER_25 : VarBasis
            {
                /*"      05    WTITL-ZEROS              PIC  9(002).*/
                public IntBasis WTITL_ZEROS { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      05    WTITL-SEQUENCIA          PIC  9(010).*/
                public IntBasis WTITL_SEQUENCIA { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
                /*"      05    WTITL-DIGITO             PIC  9(001).*/
                public IntBasis WTITL_DIGITO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"  03  DPARM01X.*/

                public _REDEF_VG1650B_FILLER_25()
                {
                    WTITL_ZEROS.ValueChanged += OnValueChanged;
                    WTITL_SEQUENCIA.ValueChanged += OnValueChanged;
                    WTITL_DIGITO.ValueChanged += OnValueChanged;
                }

            }
            public VG1650B_DPARM01X DPARM01X { get; set; } = new VG1650B_DPARM01X();
            public class VG1650B_DPARM01X : VarBasis
            {
                /*"      05            DPARM01          PIC  9(010).*/
                public IntBasis DPARM01 { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
                /*"      05            DPARM01-R        REDEFINES   DPARM01.*/
                private _REDEF_VG1650B_DPARM01_R _dparm01_r { get; set; }
                public _REDEF_VG1650B_DPARM01_R DPARM01_R
                {
                    get { _dparm01_r = new _REDEF_VG1650B_DPARM01_R(); _.Move(DPARM01, _dparm01_r); VarBasis.RedefinePassValue(DPARM01, _dparm01_r, DPARM01); _dparm01_r.ValueChanged += () => { _.Move(_dparm01_r, DPARM01); }; return _dparm01_r; }
                    set { VarBasis.RedefinePassValue(value, _dparm01_r, DPARM01); }
                }  //Redefines
                public class _REDEF_VG1650B_DPARM01_R : VarBasis
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

                    public _REDEF_VG1650B_DPARM01_R()
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
                /*"  03        FILLER.*/
            }
            public VG1650B_FILLER_26 FILLER_26 { get; set; } = new VG1650B_FILLER_26();
            public class VG1650B_FILLER_26 : VarBasis
            {
                /*"    05      AUX-MORTE-NATURAL        PIC  9(013)V99.*/
                public DoubleBasis AUX_MORTE_NATURAL { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"    05      AUX-MORTE-ACIDENTAL      PIC  9(013)V99.*/
                public DoubleBasis AUX_MORTE_ACIDENTAL { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"    05      AUX-INV-PERMANENTE       PIC  9(013)V99.*/
                public DoubleBasis AUX_INV_PERMANENTE { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"    05      AUX-AMDS                 PIC  9(013)V99.*/
                public DoubleBasis AUX_AMDS { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"    05      AUX-DIARIA-HOSP          PIC  9(013)V99.*/
                public DoubleBasis AUX_DIARIA_HOSP { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"    05      AUX-DIARIA-INT           PIC  9(013)V99.*/
                public DoubleBasis AUX_DIARIA_INT { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"    05      AUX-DESPESA-MED          PIC  9(013)V99.*/
                public DoubleBasis AUX_DESPESA_MED { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"    05      AUX-TIPO-CLIENTE         PIC  X(030).*/
                public StringBasis AUX_TIPO_CLIENTE { get; set; } = new StringBasis(new PIC("X", "30", "X(030)."), @"");
                /*"    05      AUX-TIPO-IMPORT          PIC  X(030).*/
                public StringBasis AUX_TIPO_IMPORT { get; set; } = new StringBasis(new PIC("X", "30", "X(030)."), @"");
                /*"    05      AUX-OUTROS               PIC  X(001) VALUE SPACES.*/
                public StringBasis AUX_OUTROS { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05      I                        PIC  9(002) VALUE ZEROS.*/
                public IntBasis I { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  03        WDATA-REL           PIC  X(010)  VALUE SPACES.*/
            }
            public StringBasis WDATA_REL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  03        FILLER              REDEFINES    WDATA-REL.*/
            private _REDEF_VG1650B_FILLER_27 _filler_27 { get; set; }
            public _REDEF_VG1650B_FILLER_27 FILLER_27
            {
                get { _filler_27 = new _REDEF_VG1650B_FILLER_27(); _.Move(WDATA_REL, _filler_27); VarBasis.RedefinePassValue(WDATA_REL, _filler_27, WDATA_REL); _filler_27.ValueChanged += () => { _.Move(_filler_27, WDATA_REL); }; return _filler_27; }
                set { VarBasis.RedefinePassValue(value, _filler_27, WDATA_REL); }
            }  //Redefines
            public class _REDEF_VG1650B_FILLER_27 : VarBasis
            {
                /*"    10      WDAT-REL-SEC        PIC  9(002).*/
                public IntBasis WDAT_REL_SEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10      WDAT-REL-ANO        PIC  9(002).*/
                public IntBasis WDAT_REL_ANO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10      FILLER              PIC  X(001).*/
                public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10      WDAT-REL-MES        PIC  9(002).*/
                public IntBasis WDAT_REL_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10      FILLER              PIC  X(001).*/
                public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10      WDAT-REL-DIA        PIC  9(002).*/
                public IntBasis WDAT_REL_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03        WDAT-REL-LIT.*/

                public _REDEF_VG1650B_FILLER_27()
                {
                    WDAT_REL_SEC.ValueChanged += OnValueChanged;
                    WDAT_REL_ANO.ValueChanged += OnValueChanged;
                    FILLER_28.ValueChanged += OnValueChanged;
                    WDAT_REL_MES.ValueChanged += OnValueChanged;
                    FILLER_29.ValueChanged += OnValueChanged;
                    WDAT_REL_DIA.ValueChanged += OnValueChanged;
                }

            }
            public VG1650B_WDAT_REL_LIT WDAT_REL_LIT { get; set; } = new VG1650B_WDAT_REL_LIT();
            public class VG1650B_WDAT_REL_LIT : VarBasis
            {
                /*"    10      WDAT-LIT-DIA        PIC  9(002)  VALUE ZEROS.*/
                public IntBasis WDAT_LIT_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10      FILLER              PIC  X(001)  VALUE '/'.*/
                public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10      WDAT-LIT-MES        PIC  9(002)  VALUE ZEROS.*/
                public IntBasis WDAT_LIT_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10      FILLER              PIC  X(001)  VALUE '/'.*/
                public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10      WDAT-LIT-SEC        PIC  9(002)  VALUE ZEROS.*/
                public IntBasis WDAT_LIT_SEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10      WDAT-LIT-ANO        PIC  9(002)  VALUE ZEROS.*/
                public IntBasis WDAT_LIT_ANO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  03         WDATA-ALTERACAO   PIC  X(010)    VALUE SPACES.*/
            }
            public StringBasis WDATA_ALTERACAO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  03         FILLER            REDEFINES      WDATA-ALTERACAO.*/
            private _REDEF_VG1650B_FILLER_32 _filler_32 { get; set; }
            public _REDEF_VG1650B_FILLER_32 FILLER_32
            {
                get { _filler_32 = new _REDEF_VG1650B_FILLER_32(); _.Move(WDATA_ALTERACAO, _filler_32); VarBasis.RedefinePassValue(WDATA_ALTERACAO, _filler_32, WDATA_ALTERACAO); _filler_32.ValueChanged += () => { _.Move(_filler_32, WDATA_ALTERACAO); }; return _filler_32; }
                set { VarBasis.RedefinePassValue(value, _filler_32, WDATA_ALTERACAO); }
            }  //Redefines
            public class _REDEF_VG1650B_FILLER_32 : VarBasis
            {
                /*"    10       WCOR-ANO.*/
                public VG1650B_WCOR_ANO WCOR_ANO { get; set; } = new VG1650B_WCOR_ANO();
                public class VG1650B_WCOR_ANO : VarBasis
                {
                    /*"      15     WCOR-ANOS         PIC  9(002).*/
                    public IntBasis WCOR_ANOS { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"      15     WCOR-ANOA         PIC  9(002).*/
                    public IntBasis WCOR_ANOA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"    10       WCOR-BR1          PIC  X(001).*/

                    public VG1650B_WCOR_ANO()
                    {
                        WCOR_ANOS.ValueChanged += OnValueChanged;
                        WCOR_ANOA.ValueChanged += OnValueChanged;
                    }

                }
                public StringBasis WCOR_BR1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WCOR-MES          PIC  9(002).*/
                public IntBasis WCOR_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       WCOR-BR2          PIC  X(001).*/
                public StringBasis WCOR_BR2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WCOR-DIA          PIC  9(002).*/
                public IntBasis WCOR_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03         WDATA-RETORNO     PIC  9(008)    VALUE ZEROS.*/

                public _REDEF_VG1650B_FILLER_32()
                {
                    WCOR_ANO.ValueChanged += OnValueChanged;
                    WCOR_BR1.ValueChanged += OnValueChanged;
                    WCOR_MES.ValueChanged += OnValueChanged;
                    WCOR_BR2.ValueChanged += OnValueChanged;
                    WCOR_DIA.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WDATA_RETORNO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"  03         FILLER            REDEFINES      WDATA-RETORNO.*/
            private _REDEF_VG1650B_FILLER_33 _filler_33 { get; set; }
            public _REDEF_VG1650B_FILLER_33 FILLER_33
            {
                get { _filler_33 = new _REDEF_VG1650B_FILLER_33(); _.Move(WDATA_RETORNO, _filler_33); VarBasis.RedefinePassValue(WDATA_RETORNO, _filler_33, WDATA_RETORNO); _filler_33.ValueChanged += () => { _.Move(_filler_33, WDATA_RETORNO); }; return _filler_33; }
                set { VarBasis.RedefinePassValue(value, _filler_33, WDATA_RETORNO); }
            }  //Redefines
            public class _REDEF_VG1650B_FILLER_33 : VarBasis
            {
                /*"    10       WRET-DIA          PIC  9(002).*/
                public IntBasis WRET_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       WRET-MES          PIC  9(002).*/
                public IntBasis WRET_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       WRET-SEC          PIC  9(002).*/
                public IntBasis WRET_SEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       WRET-ANO          PIC  9(002).*/
                public IntBasis WRET_ANO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03         WDATA-PARAMETRO   PIC  9(008)    VALUE ZEROS.*/

                public _REDEF_VG1650B_FILLER_33()
                {
                    WRET_DIA.ValueChanged += OnValueChanged;
                    WRET_MES.ValueChanged += OnValueChanged;
                    WRET_SEC.ValueChanged += OnValueChanged;
                    WRET_ANO.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WDATA_PARAMETRO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"  03         FILLER            REDEFINES      WDATA-PARAMETRO.*/
            private _REDEF_VG1650B_FILLER_34 _filler_34 { get; set; }
            public _REDEF_VG1650B_FILLER_34 FILLER_34
            {
                get { _filler_34 = new _REDEF_VG1650B_FILLER_34(); _.Move(WDATA_PARAMETRO, _filler_34); VarBasis.RedefinePassValue(WDATA_PARAMETRO, _filler_34, WDATA_PARAMETRO); _filler_34.ValueChanged += () => { _.Move(_filler_34, WDATA_PARAMETRO); }; return _filler_34; }
                set { VarBasis.RedefinePassValue(value, _filler_34, WDATA_PARAMETRO); }
            }  //Redefines
            public class _REDEF_VG1650B_FILLER_34 : VarBasis
            {
                /*"    10       WPAR-DIA          PIC  9(002).*/
                public IntBasis WPAR_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       WPAR-MES          PIC  9(002).*/
                public IntBasis WPAR_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       WPAR-SEC          PIC  9(002).*/
                public IntBasis WPAR_SEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       WPAR-ANO          PIC  9(002).*/
                public IntBasis WPAR_ANO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03        CHAVE-MOVIMENTO.*/

                public _REDEF_VG1650B_FILLER_34()
                {
                    WPAR_DIA.ValueChanged += OnValueChanged;
                    WPAR_MES.ValueChanged += OnValueChanged;
                    WPAR_SEC.ValueChanged += OnValueChanged;
                    WPAR_ANO.ValueChanged += OnValueChanged;
                }

            }
            public VG1650B_CHAVE_MOVIMENTO CHAVE_MOVIMENTO { get; set; } = new VG1650B_CHAVE_MOVIMENTO();
            public class VG1650B_CHAVE_MOVIMENTO : VarBasis
            {
                /*"    10      CH-MATRIC-MOV       PIC  9(015)  VALUE ZEROS.*/
                public IntBasis CH_MATRIC_MOV { get; set; } = new IntBasis(new PIC("9", "15", "9(015)"));
                /*"  03        CHAVE-SEGURADO.*/
            }
            public VG1650B_CHAVE_SEGURADO CHAVE_SEGURADO { get; set; } = new VG1650B_CHAVE_SEGURADO();
            public class VG1650B_CHAVE_SEGURADO : VarBasis
            {
                /*"    10      CH-MATRIC-SEG       PIC  9(015)  VALUE ZEROS.*/
                public IntBasis CH_MATRIC_SEG { get; set; } = new IntBasis(new PIC("9", "15", "9(015)"));
                /*"01    WS-HORAS.*/
            }
        }
        public VG1650B_WS_HORAS WS_HORAS { get; set; } = new VG1650B_WS_HORAS();
        public class VG1650B_WS_HORAS : VarBasis
        {
            /*"  03  WS-HORA-INI               PIC  X(008).*/
            public StringBasis WS_HORA_INI { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"  03  WS-HORA-INI-R REDEFINES WS-HORA-INI.*/
            private _REDEF_VG1650B_WS_HORA_INI_R _ws_hora_ini_r { get; set; }
            public _REDEF_VG1650B_WS_HORA_INI_R WS_HORA_INI_R
            {
                get { _ws_hora_ini_r = new _REDEF_VG1650B_WS_HORA_INI_R(); _.Move(WS_HORA_INI, _ws_hora_ini_r); VarBasis.RedefinePassValue(WS_HORA_INI, _ws_hora_ini_r, WS_HORA_INI); _ws_hora_ini_r.ValueChanged += () => { _.Move(_ws_hora_ini_r, WS_HORA_INI); }; return _ws_hora_ini_r; }
                set { VarBasis.RedefinePassValue(value, _ws_hora_ini_r, WS_HORA_INI); }
            }  //Redefines
            public class _REDEF_VG1650B_WS_HORA_INI_R : VarBasis
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

                public _REDEF_VG1650B_WS_HORA_INI_R()
                {
                    HI.ValueChanged += OnValueChanged;
                    MI.ValueChanged += OnValueChanged;
                    SI.ValueChanged += OnValueChanged;
                    DI.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WS_HORA_FIM { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"  03  WS-HORA-FIM-R REDEFINES WS-HORA-FIM.*/
            private _REDEF_VG1650B_WS_HORA_FIM_R _ws_hora_fim_r { get; set; }
            public _REDEF_VG1650B_WS_HORA_FIM_R WS_HORA_FIM_R
            {
                get { _ws_hora_fim_r = new _REDEF_VG1650B_WS_HORA_FIM_R(); _.Move(WS_HORA_FIM, _ws_hora_fim_r); VarBasis.RedefinePassValue(WS_HORA_FIM, _ws_hora_fim_r, WS_HORA_FIM); _ws_hora_fim_r.ValueChanged += () => { _.Move(_ws_hora_fim_r, WS_HORA_FIM); }; return _ws_hora_fim_r; }
                set { VarBasis.RedefinePassValue(value, _ws_hora_fim_r, WS_HORA_FIM); }
            }  //Redefines
            public class _REDEF_VG1650B_WS_HORA_FIM_R : VarBasis
            {
                /*"      05  HF                    PIC  9(002).*/
                public IntBasis HF { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      05  MF                    PIC  9(002).*/
                public IntBasis MF { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      05  SF                    PIC  9(002).*/
                public IntBasis SF { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      05  DF                    PIC  9(002).*/
                public IntBasis DF { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03  SIT                       PIC S9(013)V99 COMP-3 VALUE +0.*/

                public _REDEF_VG1650B_WS_HORA_FIM_R()
                {
                    HF.ValueChanged += OnValueChanged;
                    MF.ValueChanged += OnValueChanged;
                    SF.ValueChanged += OnValueChanged;
                    DF.ValueChanged += OnValueChanged;
                }

            }
            public DoubleBasis SIT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  03  SFT                       PIC S9(013)V99 COMP-3 VALUE +0.*/
            public DoubleBasis SFT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  03  SII                       PIC S9(004)    COMP   VALUE +0.*/
            public IntBasis SII { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  03  IND                       PIC S9(004)    COMP   VALUE +0.*/
            public IntBasis IND { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  03  STT-DISP                  PIC --.---.---.---.--9,99.*/
            public DoubleBasis STT_DISP { get; set; } = new DoubleBasis(new PIC("9", "14", "--.---.---.---.--9V99."), 2);
            /*"01  TOTAIS-ROT.*/
        }
        public VG1650B_TOTAIS_ROT TOTAIS_ROT { get; set; } = new VG1650B_TOTAIS_ROT();
        public class VG1650B_TOTAIS_ROT : VarBasis
        {
            /*"    03  FILLER  OCCURS 50 TIMES.*/
            public ListBasis<VG1650B_FILLER_35> FILLER_35 { get; set; } = new ListBasis<VG1650B_FILLER_35>(50);
            public class VG1650B_FILLER_35 : VarBasis
            {
                /*"        05  STT                       PIC S9(013)V99 COMP-3.*/
                public DoubleBasis STT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
                /*"        05  SQT                       PIC S9(015)    COMP-3.*/
                public IntBasis SQT { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
                /*"  01        LK-LINK.*/
                public VG1650B_LK_LINK LK_LINK { get; set; } = new VG1650B_LK_LINK();
                public class VG1650B_LK_LINK : VarBasis
                {
                    /*"      05     LK-DATA1          PIC  9(008).*/
                    public IntBasis LK_DATA1 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                    /*"      05     LK-DATA2          PIC  9(008).*/
                    public IntBasis LK_DATA2 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                    /*"      05     QTDIA             PIC S9(005)          COMP-3.*/
                    public IntBasis QTDIA { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));
                    /*"  01         WPROSOMD2.*/
                }
                public VG1650B_WPROSOMD2 WPROSOMD2 { get; set; } = new VG1650B_WPROSOMD2();
                public class VG1650B_WPROSOMD2 : VarBasis
                {
                    /*"    05       WDATA-INFORMADA   PIC  9(008).*/
                }
            }
            public IntBasis WDATA_INFORMADA { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"    05       WDATA-QTDIAS      PIC S9(005)    COMP-3.*/
            public IntBasis WDATA_QTDIAS { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));
            /*"    05       WDATA-CALCULO     PIC  9(008).*/
            public IntBasis WDATA_CALCULO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"  01        PARAMETROS.*/
            public VG1650B_PARAMETROS PARAMETROS { get; set; } = new VG1650B_PARAMETROS();
            public class VG1650B_PARAMETROS : VarBasis
            {
                /*"    10      LK710-APOLICE               PIC S9(013) COMP-3.*/
                public IntBasis LK710_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
                /*"    10      LK710-SUBGRUPO              PIC S9(004) COMP.*/
                public IntBasis LK710_SUBGRUPO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"    10      LK710-IDADE                 PIC S9(004) COMP.*/
                public IntBasis LK710_IDADE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"    10      LK710-NASCIMENTO.*/
                public VG1650B_LK710_NASCIMENTO LK710_NASCIMENTO { get; set; } = new VG1650B_LK710_NASCIMENTO();
                public class VG1650B_LK710_NASCIMENTO : VarBasis
                {
                    /*"      15 LK710-DATA-NASCIMENTO          PIC  9(008).*/
                    public IntBasis LK710_DATA_NASCIMENTO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                    /*"    10      LK710-SALARIO               PIC S9(013)V99 COMP-3.*/
                }
            }
            public DoubleBasis LK710_SALARIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    10      LK710-CO-MORTE-NATURAL      PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK710_CO_MORTE_NATURAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    10      LK710-CO-MORTE-ACIDENTAL    PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK710_CO_MORTE_ACIDENTAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    10      LK710-CO-INV-PERMANENTE     PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK710_CO_INV_PERMANENTE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    10      LK710-CO-INV-POR-ACIDENTE   PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK710_CO_INV_POR_ACIDENTE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    10      LK710-CO-ASS-MEDICA         PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK710_CO_ASS_MEDICA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    10      LK710-CO-DI-HOSPITALAR      PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK710_CO_DI_HOSPITALAR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    10      LK710-CO-DI-INTERNACAO      PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK710_CO_DI_INTERNACAO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    10      LK710-PU-MORTE-NATURAL      PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK710_PU_MORTE_NATURAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    10      LK710-PU-MORTE-ACIDENTAL    PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK710_PU_MORTE_ACIDENTAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    10      LK710-PU-INV-PERMANENTE     PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK710_PU_INV_PERMANENTE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    10      LK710-PU-ASS-MEDICA         PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK710_PU_ASS_MEDICA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    10      LK710-PU-DI-HOSPITALAR      PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK710_PU_DI_HOSPITALAR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    10      LK710-PU-DI-INTERNACAO      PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK710_PU_DI_INTERNACAO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    10      LK710-PREM-MORTE-NATURAL    PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK710_PREM_MORTE_NATURAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    10      LK710-PREM-ACIDENTES-PESSOAIS PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK710_PREM_ACIDENTES_PESSOAIS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    10      LK710-PREM-TOTAL            PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK710_PREM_TOTAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    10      LK710-RETURN-CODE           PIC S9(03) COMP-3.*/
            public IntBasis LK710_RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "3", "S9(03)"));
            /*"    10      LK710-MENSAGEM              PIC  X(77).*/
            public StringBasis LK710_MENSAGEM { get; set; } = new StringBasis(new PIC("X", "77", "X(77)."), @"");
            /*"  01        PARAMETROS-702.*/
            public VG1650B_PARAMETROS_702 PARAMETROS_702 { get; set; } = new VG1650B_PARAMETROS_702();
            public class VG1650B_PARAMETROS_702 : VarBasis
            {
                /*"    10      LK-APOLICE               PIC S9(013) COMP-3.*/
                public IntBasis LK_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
                /*"    10      LK-SUBGRUPO              PIC S9(004) COMP.*/
                public IntBasis LK_SUBGRUPO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"    10      LK-IDADE                 PIC S9(004) COMP.*/
                public IntBasis LK_IDADE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"    10      LK-NASCIMENTO.*/
                public VG1650B_LK_NASCIMENTO LK_NASCIMENTO { get; set; } = new VG1650B_LK_NASCIMENTO();
                public class VG1650B_LK_NASCIMENTO : VarBasis
                {
                    /*"      15 LK-DATA-NASCIMENTO          PIC  9(008).*/
                    public IntBasis LK_DATA_NASCIMENTO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                    /*"    10      LK-SALARIO               PIC S9(013)V99 COMP-3.*/
                }
            }
            public DoubleBasis LK_SALARIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    10      LK-CO-MORTE-NATURAL      PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_CO_MORTE_NATURAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    10      LK-CO-MORTE-ACIDENTAL    PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_CO_MORTE_ACIDENTAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    10      LK-CO-INV-PERMANENTE     PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_CO_INV_PERMANENTE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    10      LK-CO-ASS-MEDICA         PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_CO_ASS_MEDICA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    10      LK-CO-DI-HOSPITALAR      PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_CO_DI_HOSPITALAR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    10      LK-CO-DI-INTERNACAO      PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_CO_DI_INTERNACAO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    10      LK-CO-DESPESA-MEDICA     PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_CO_DESPESA_MEDICA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    10      LK-PU-MORTE-NATURAL      PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_PU_MORTE_NATURAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    10      LK-PU-MORTE-ACIDENTAL    PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_PU_MORTE_ACIDENTAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    10      LK-PU-INV-PERMANENTE     PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_PU_INV_PERMANENTE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    10      LK-PU-ASS-MEDICA         PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_PU_ASS_MEDICA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    10      LK-PU-DI-HOSPITALAR      PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_PU_DI_HOSPITALAR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    10      LK-PU-DI-INTERNACAO      PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_PU_DI_INTERNACAO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    10      LK-PU-DESPESA-MEDICA     PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_PU_DESPESA_MEDICA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    10      LK-PREM-MORTE-NATURAL    PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_PREM_MORTE_NATURAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    10      LK-PREM-ACIDENTES-PESSOAIS PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_PREM_ACIDENTES_PESSOAIS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    10      LK-PREM-TOTAL            PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_PREM_TOTAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    10      LK-RETURN-CODE           PIC S9(03) COMP.*/
            public IntBasis LK_RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "3", "S9(03)"));
            /*"    10      LK-MENSAGEM              PIC  X(77).*/
            public StringBasis LK_MENSAGEM { get; set; } = new StringBasis(new PIC("X", "77", "X(77)."), @"");
            /*"01         WS-MOVTO-CLIENTE.*/
        }
        public VG1650B_WS_MOVTO_CLIENTE WS_MOVTO_CLIENTE { get; set; } = new VG1650B_WS_MOVTO_CLIENTE();
        public class VG1650B_WS_MOVTO_CLIENTE : VarBasis
        {
            /*"  05       WWORK-COD-CLIENTE      PIC S9(009)    VALUE +0 COMP-4*/
            public IntBasis WWORK_COD_CLIENTE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  05       WWORK-TIPO-MOVIMENTO   PIC  X(001)    VALUE  SPACES.*/
            public StringBasis WWORK_TIPO_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05       WWORK-DATA-ULT-MANUTEN PIC  X(010)    VALUE  SPACES.*/
            public StringBasis WWORK_DATA_ULT_MANUTEN { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05       WWORK-NOME-RAZAO       PIC  X(040)    VALUE  SPACES.*/
            public StringBasis WWORK_NOME_RAZAO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
            /*"  05       WWORK-TIPO-PESSOA      PIC  X(001)    VALUE  SPACES.*/
            public StringBasis WWORK_TIPO_PESSOA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05       WWORK-IDE-SEXO         PIC  X(001)    VALUE  SPACES.*/
            public StringBasis WWORK_IDE_SEXO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05       WWORK-ESTADO-CIVIL     PIC  X(001)    VALUE  SPACES.*/
            public StringBasis WWORK_ESTADO_CIVIL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05       WWORK-OCORR-ENDERECO   PIC S9(004)    VALUE +0 COMP-4*/
            public IntBasis WWORK_OCORR_ENDERECO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05       WWORK-ENDERECO         PIC  X(040)    VALUE  SPACES.*/
            public StringBasis WWORK_ENDERECO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
            /*"  05       WWORK-BAIRRO           PIC  X(020)    VALUE  SPACES.*/
            public StringBasis WWORK_BAIRRO { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"");
            /*"  05       WWORK-CIDADE           PIC  X(020)    VALUE  SPACES.*/
            public StringBasis WWORK_CIDADE { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"");
            /*"  05       WWORK-SIGLA-UF         PIC  X(002)    VALUE  SPACES.*/
            public StringBasis WWORK_SIGLA_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
            /*"  05       WWORK-CEP              PIC S9(009)    VALUE +0 COMP-4*/
            public IntBasis WWORK_CEP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  05       WWORK-DDD              PIC S9(004)    VALUE +0 COMP-4*/
            public IntBasis WWORK_DDD { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05       WWORK-TELEFONE         PIC S9(009)    VALUE +0 COMP-4*/
            public IntBasis WWORK_TELEFONE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  05       WWORK-FAX              PIC S9(009)    VALUE +0 COMP-4*/
            public IntBasis WWORK_FAX { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  05       WWORK-CGCCPF           PIC S9(015)    VALUE +0 COMP-3*/
            public IntBasis WWORK_CGCCPF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
            /*"  05       WWORK-DATA-NASCIMENTO  PIC  X(010)    VALUE  SPACES.*/
            public StringBasis WWORK_DATA_NASCIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"01           VG0716S-COD-FONTE       PIC  S9(004) COMP.*/
        }
        public IntBasis VG0716S_COD_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01           VG0716S-COD-PRODUTO     PIC  S9(004) COMP.*/
        public IntBasis VG0716S_COD_PRODUTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01           VG0716S-NUM-PROPOSTA    PIC  S9(015)    COMP-3.*/
        public IntBasis VG0716S_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"01           VG0716S-VLR-MENSALIDADE PIC  S9(008)V99 COMP-3.*/
        public DoubleBasis VG0716S_VLR_MENSALIDADE { get; set; } = new DoubleBasis(new PIC("S9", "8", "S9(008)V99"), 2);
        /*"01           VG0716S-NUM-PLANO       PIC  S9(004) COMP.*/
        public IntBasis VG0716S_NUM_PLANO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01           VG0716S-NUM-SERIE       PIC  S9(004) COMP.*/
        public IntBasis VG0716S_NUM_SERIE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01           VG0716S-NUM-TITULO      PIC  S9(009) COMP.*/
        public IntBasis VG0716S_NUM_TITULO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01           VG0716S-IND-DV          PIC  S9(004) COMP.*/
        public IntBasis VG0716S_IND_DV { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01           VG0716S-DTH-INI-VIGENCIA PIC  X(010).*/
        public StringBasis VG0716S_DTH_INI_VIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01           VG0716S-DTH-FIM-VIGENCIA PIC  X(010).*/
        public StringBasis VG0716S_DTH_FIM_VIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01           VG0716S-DES-COMBINACAO  PIC   X(020).*/
        public StringBasis VG0716S_DES_COMBINACAO { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
        /*"01           VG0716S-COD-STA-TITULO  PIC   X(003).*/
        public StringBasis VG0716S_COD_STA_TITULO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
        /*"01           VG0716S-SQLCODE         PIC  S9(004) COMP.*/
        public IntBasis VG0716S_SQLCODE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01           VG0716S-COD-RETORNO     PIC  S9(004) COMP.*/
        public IntBasis VG0716S_COD_RETORNO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01           VG0716S-DES-MENSAGEM    PIC   X(070).*/
        public StringBasis VG0716S_DES_MENSAGEM { get; set; } = new StringBasis(new PIC("X", "70", "X(070)."), @"");
        /*"01              WS-PARAMETROS.*/
        public VG1650B_WS_PARAMETROS WS_PARAMETROS { get; set; } = new VG1650B_WS_PARAMETROS();
        public class VG1650B_WS_PARAMETROS : VarBasis
        {
            /*"  03            W01DIGCERT.*/
            public VG1650B_W01DIGCERT W01DIGCERT { get; set; } = new VG1650B_W01DIGCERT();
            public class VG1650B_W01DIGCERT : VarBasis
            {
                /*"    05          WCERTIFICADO    PIC  9(015)        VALUE  0.*/
                public IntBasis WCERTIFICADO { get; set; } = new IntBasis(new PIC("9", "15", "9(015)"));
                /*"    05          WNUMERO         PIC S9(004)  COMP  VALUE +15.*/
                public IntBasis WNUMERO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), +15);
                /*"    05          WDIG            PIC  X(001)  VALUE SPACES.*/
                public StringBasis WDIG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"01              LPARM01         PIC  9(011).*/
            }
        }
        public IntBasis LPARM01 { get; set; } = new IntBasis(new PIC("9", "11", "9(011)."));
        /*"01              LPARM02         PIC  9(014).*/
        public IntBasis LPARM02 { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
        /*"01              LPARM03         PIC  X(002).*/
        public StringBasis LPARM03 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");


        public Copies.LBFPF990 LBFPF990 { get; set; } = new Copies.LBFPF990();
        public Copies.LBFPF000 LBFPF000 { get; set; } = new Copies.LBFPF000();
        public Copies.LBFPF011 LBFPF011 { get; set; } = new Copies.LBFPF011();
        public Copies.LBFPF012 LBFPF012 { get; set; } = new Copies.LBFPF012();
        public Copies.LBFPF014 LBFPF014 { get; set; } = new Copies.LBFPF014();
        public Copies.LBFPF015 LBFPF015 { get; set; } = new Copies.LBFPF015();
        public Copies.LBFPF991 LBFPF991 { get; set; } = new Copies.LBFPF991();
        public Copies.LXFCT004 LXFCT004 { get; set; } = new Copies.LXFCT004();
        public Copies.SPVG001V SPVG001V { get; set; } = new Copies.SPVG001V();
        public Copies.SPVG001W SPVG001W { get; set; } = new Copies.SPVG001W();
        public Dclgens.AGENCCEF AGENCCEF { get; set; } = new Dclgens.AGENCCEF();
        public Dclgens.APOLICES APOLICES { get; set; } = new Dclgens.APOLICES();
        public Dclgens.ARQSIVPF ARQSIVPF { get; set; } = new Dclgens.ARQSIVPF();
        public Dclgens.BANCOS BANCOS { get; set; } = new Dclgens.BANCOS();
        public Dclgens.CALENDAR CALENDAR { get; set; } = new Dclgens.CALENDAR();
        public Dclgens.CLIENTES CLIENTES { get; set; } = new Dclgens.CLIENTES();
        public Dclgens.COBHISVI COBHISVI { get; set; } = new Dclgens.COBHISVI();
        public Dclgens.COMFEDCA COMFEDCA { get; set; } = new Dclgens.COMFEDCA();
        public Dclgens.CONDITEC CONDITEC { get; set; } = new Dclgens.CONDITEC();
        public Dclgens.CONMOVVG CONMOVVG { get; set; } = new Dclgens.CONMOVVG();
        public Dclgens.COVSIVPF COVSIVPF { get; set; } = new Dclgens.COVSIVPF();
        public Dclgens.ENDERECO ENDERECO { get; set; } = new Dclgens.ENDERECO();
        public Dclgens.ERRPROVI ERRPROVI { get; set; } = new Dclgens.ERRPROVI();
        public Dclgens.FAIXASAL FAIXASAL { get; set; } = new Dclgens.FAIXASAL();
        public Dclgens.FAIXAETA FAIXAETA { get; set; } = new Dclgens.FAIXAETA();
        public Dclgens.FATURCON FATURCON { get; set; } = new Dclgens.FATURCON();
        public Dclgens.FONTES FONTES { get; set; } = new Dclgens.FONTES();
        public Dclgens.FUNCICEF FUNCICEF { get; set; } = new Dclgens.FUNCICEF();
        public Dclgens.HISCOBPR HISCOBPR { get; set; } = new Dclgens.HISCOBPR();
        public Dclgens.HISCONPA HISCONPA { get; set; } = new Dclgens.HISCONPA();
        public Dclgens.MALHACEF MALHACEF { get; set; } = new Dclgens.MALHACEF();
        public Dclgens.MOEDAS MOEDAS { get; set; } = new Dclgens.MOEDAS();
        public Dclgens.MOVIMVGA MOVIMVGA { get; set; } = new Dclgens.MOVIMVGA();
        public Dclgens.OPCPAGVI OPCPAGVI { get; set; } = new Dclgens.OPCPAGVI();
        public Dclgens.NUMEROUT NUMEROUT { get; set; } = new Dclgens.NUMEROUT();
        public Dclgens.PARCEVID PARCEVID { get; set; } = new Dclgens.PARCEVID();
        public Dclgens.PESEMAIL PESEMAIL { get; set; } = new Dclgens.PESEMAIL();
        public Dclgens.PLANOVGA PLANOVGA { get; set; } = new Dclgens.PLANOVGA();
        public Dclgens.PLAVAVGA PLAVAVGA { get; set; } = new Dclgens.PLAVAVGA();
        public Dclgens.PRODUVG PRODUVG { get; set; } = new Dclgens.PRODUVG();
        public Dclgens.PROPOVA PROPOVA { get; set; } = new Dclgens.PROPOVA();
        public Dclgens.RELATORI RELATORI { get; set; } = new Dclgens.RELATORI();
        public Dclgens.SEGVGAPH SEGVGAPH { get; set; } = new Dclgens.SEGVGAPH();
        public Dclgens.SEGURVGA SEGURVGA { get; set; } = new Dclgens.SEGURVGA();
        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.SUBGVGAP SUBGVGAP { get; set; } = new Dclgens.SUBGVGAP();
        public Dclgens.VGSEGCON VGSEGCON { get; set; } = new Dclgens.VGSEGCON();
        public Dclgens.RAMOCOMP RAMOCOMP { get; set; } = new Dclgens.RAMOCOMP();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string MOV_SIGAT_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                MOV_SIGAT.SetFile(MOV_SIGAT_FILE_NAME_P);

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
            /*" -940- MOVE '0000' TO WNR-EXEC-SQL. */
            _.Move("0000", REG_LEITURA.FILLER_16.WABEND.WNR_EXEC_SQL);

            /*" -941- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -944- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -947- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -950- DISPLAY '------------------------------' */
            _.Display($"------------------------------");

            /*" -951- DISPLAY 'PROGRAMA EM EXECUCAO VG1650B  ' */
            _.Display($"PROGRAMA EM EXECUCAO VG1650B  ");

            /*" -952- DISPLAY '                              ' */
            _.Display($"                              ");

            /*" -955- DISPLAY 'VERSAO V.03 - DEMANDA 402.982' */
            _.Display($"VERSAO V.03 - DEMANDA 402.982");

            /*" -956- DISPLAY '                              ' */
            _.Display($"                              ");

            /*" -958- DISPLAY '------------------------------' . */
            _.Display($"------------------------------");

            /*" -960- OPEN INPUT MOV-SIGAT. */
            MOV_SIGAT.Open(REG_SIGAT);

            /*" -962- PERFORM R0100-00-SELECT-TSISTEMA. */

            R0100_00_SELECT_TSISTEMA_SECTION();

            /*" -964- PERFORM R0910-00-LE-MOVIMENTO. */

            R0910_00_LE_MOVIMENTO_SECTION();

            /*" -965- IF FIM-MOVIMENTO */

            if (REG_LEITURA.FILLER_16.FLAG_WFIM_MOVIMENTO["FIM_MOVIMENTO"])
            {

                /*" -966- MOVE 01 TO RETURN-CODE */
                _.Move(01, RETURN_CODE);

                /*" -967- PERFORM R9900-00-ENCERRA-SEM-MOVTO */

                R9900_00_ENCERRA_SEM_MOVTO_SECTION();

                /*" -969- GO TO R9000-00-FINALIZA. */

                R9000_00_FINALIZA_SECTION(); //GOTO
                return;
            }


            /*" -970- PERFORM R1000-00-PROCESSA UNTIL FIM-MOVIMENTO. */

            while (!(REG_LEITURA.FILLER_16.FLAG_WFIM_MOVIMENTO["FIM_MOVIMENTO"]))
            {

                R1000_00_PROCESSA_SECTION();
            }

            /*" -0- FLUXCONTROL_PERFORM R0000_10_NEXT */

            R0000_10_NEXT();

        }

        [StopWatch]
        /*" R0000-10-NEXT */
        private void R0000_10_NEXT(bool isPerform = false)
        {
            /*" -976- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -976- PERFORM R9000-00-FINALIZA. */

            R9000_00_FINALIZA_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0100-00-SELECT-TSISTEMA-SECTION */
        private void R0100_00_SELECT_TSISTEMA_SECTION()
        {
            /*" -989- MOVE 'R0100-00-SELECT-TSISTEMA' TO PARAGRAFO. */
            _.Move("R0100-00-SELECT-TSISTEMA", REG_LEITURA.FILLER_16.WABEND.PARAGRAFO);

            /*" -993- MOVE '010' TO WNR-EXEC-SQL. */
            _.Move("010", REG_LEITURA.FILLER_16.WABEND.WNR_EXEC_SQL);

            /*" -1000- PERFORM R0100_00_SELECT_TSISTEMA_DB_SELECT_1 */

            R0100_00_SELECT_TSISTEMA_DB_SELECT_1();

            /*" -1003- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1004- DISPLAY 'VG1650B - NAO CONSTA REGISTRO NA TSISTEMA' */
                _.Display($"VG1650B - NAO CONSTA REGISTRO NA TSISTEMA");

                /*" -1005- DISPLAY 'IDSISTEM =  VG ' */
                _.Display($"IDSISTEM =  VG ");

                /*" -1007- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1008- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1009- DISPLAY 'VG1650B - ERRO NA LEITURA NA SISTEMAS  ' */
                _.Display($"VG1650B - ERRO NA LEITURA NA SISTEMAS  ");

                /*" -1011- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1014- MOVE '01' TO SISTEMAS-DATA-MOV-ABERTO-1(9:2). */
            _.MoveAtPosition("01", SISTEMAS_DATA_MOV_ABERTO_1, 9, 2);

            /*" -1015- DISPLAY 'DATA MOV ABERTO ' SISTEMAS-DATA-MOV-ABERTO. */
            _.Display($"DATA MOV ABERTO {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}");

            /*" -1015- DISPLAY ' ' . */
            _.Display($" ");

        }

        [StopWatch]
        /*" R0100-00-SELECT-TSISTEMA-DB-SELECT-1 */
        public void R0100_00_SELECT_TSISTEMA_DB_SELECT_1()
        {
            /*" -1000- EXEC SQL SELECT DATA_MOV_ABERTO, DATA_MOV_ABERTO + 1 MONTH INTO :SISTEMAS-DATA-MOV-ABERTO, :SISTEMAS-DATA-MOV-ABERTO-1 FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'VG' END-EXEC. */

            var r0100_00_SELECT_TSISTEMA_DB_SELECT_1_Query1 = new R0100_00_SELECT_TSISTEMA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0100_00_SELECT_TSISTEMA_DB_SELECT_1_Query1.Execute(r0100_00_SELECT_TSISTEMA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO_1, SISTEMAS_DATA_MOV_ABERTO_1);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/

        [StopWatch]
        /*" R0910-00-LE-MOVIMENTO-SECTION */
        private void R0910_00_LE_MOVIMENTO_SECTION()
        {
            /*" -1028- MOVE 'R0910-00-LE-MOVIMENTO' TO PARAGRAFO. */
            _.Move("R0910-00-LE-MOVIMENTO", REG_LEITURA.FILLER_16.WABEND.PARAGRAFO);

            /*" -1030- MOVE '0910' TO WNR-EXEC-SQL. */
            _.Move("0910", REG_LEITURA.FILLER_16.WABEND.WNR_EXEC_SQL);

            /*" -1031- READ MOV-SIGAT AT END */
            try
            {
                MOV_SIGAT.Read(() =>
                {

                    /*" -1034- MOVE 1 TO FLAG-WFIM-MOVIMENTO */
                    _.Move(1, REG_LEITURA.FILLER_16.FLAG_WFIM_MOVIMENTO);

                    /*" -1036- GO TO R0910-99-SAIDA. */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/ //GOTO
                    return;
                });

                _.Move(MOV_SIGAT.Value, REG_SIGAT);

            }
            catch (GoToException ex)
            {
                return;
            }
            /*" -1038- IF NOT FIM-MOVIMENTO */

            if (!REG_LEITURA.FILLER_16.FLAG_WFIM_MOVIMENTO["FIM_MOVIMENTO"])
            {

                /*" -1041- ADD 1 TO AC-LIDOS AC-LIDOS-M */
                FILLER_5.AC_LIDOS.Value = FILLER_5.AC_LIDOS + 1;
                FILLER_5.AC_LIDOS_M.Value = FILLER_5.AC_LIDOS_M + 1;

                /*" -1042- IF AC-LIDOS GREATER 999 */

                if (FILLER_5.AC_LIDOS > 999)
                {

                    /*" -1043- MOVE ZEROS TO AC-LIDOS */
                    _.Move(0, FILLER_5.AC_LIDOS);

                    /*" -1044- ACCEPT WS-TIME FROM TIME */
                    _.Move(_.AcceptDate("TIME"), FILLER_5.WS_TIME);

                    /*" -1045- DISPLAY 'LIDOS MOVIMENTO   ' AC-LIDOS-M ' ' WS-TIME */

                    $"LIDOS MOVIMENTO   {FILLER_5.AC_LIDOS_M} {FILLER_5.WS_TIME}"
                    .Display();

                    /*" -1047- END-IF */
                }


                /*" -1048- IF REG-TIPO-SIGAT EQUAL 'H' */

                if (REG_SIGAT.REG_TIPO_SIGAT == "H")
                {

                    /*" -1049- MOVE REG-SIGAT TO REG-HEADER */
                    _.Move(MOV_SIGAT?.Value, LBFPF990.REG_HEADER);

                    /*" -1050- PERFORM R0915-00-VALIDAR-HEADER */

                    R0915_00_VALIDAR_HEADER_SECTION();

                    /*" -1051- GO TO R0910-00-LE-MOVIMENTO */
                    new Task(() => R0910_00_LE_MOVIMENTO_SECTION()).RunSynchronously(); //GOTO
                    return;//Recursividade detectada, cuidado...

                    /*" -1052- ELSE */
                }
                else
                {


                    /*" -1053- IF REG-TIPO-SIGAT EQUAL 'T' */

                    if (REG_SIGAT.REG_TIPO_SIGAT == "T")
                    {

                        /*" -1054- MOVE REG-SIGAT TO REG-TRAILLER */
                        _.Move(MOV_SIGAT?.Value, LBFPF991.REG_TRAILLER);

                        /*" -1055- GO TO R0910-00-LE-MOVIMENTO */
                        new Task(() => R0910_00_LE_MOVIMENTO_SECTION()).RunSynchronously(); //GOTO
                        return;//Recursividade detectada, cuidado...

                        /*" -1056- ELSE */
                    }
                    else
                    {


                        /*" -1058- IF REG-TIPO-SIGAT NOT EQUAL '1' AND '2' AND '3' AND 'B' */

                        if (!REG_SIGAT.REG_TIPO_SIGAT.In("1", "2", "3", "B"))
                        {

                            /*" -1059- DISPLAY 'VG1650B - FIM ANORMAL' */
                            _.Display($"VG1650B - FIM ANORMAL");

                            /*" -1061- DISPLAY '          TIPO ARQUIVO INVALIDO ' RH-TIPO-ARQUIVO OF REG-HEADER */
                            _.Display($"          TIPO ARQUIVO INVALIDO {LBFPF990.REG_HEADER.RH_TIPO_ARQUIVO}");

                            /*" -1061- PERFORM R9000-00-FINALIZA. */

                            R9000_00_FINALIZA_SECTION();
                        }

                    }

                }

            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/

        [StopWatch]
        /*" R0915-00-VALIDAR-HEADER-SECTION */
        private void R0915_00_VALIDAR_HEADER_SECTION()
        {
            /*" -1073- MOVE 'R0915-00-VALIDAR-HEADER' TO PARAGRAFO. */
            _.Move("R0915-00-VALIDAR-HEADER", REG_LEITURA.FILLER_16.WABEND.PARAGRAFO);

            /*" -1076- MOVE '    ' TO COMANDO. */
            _.Move("    ", REG_LEITURA.FILLER_16.LOCALIZA_ABEND_2.COMANDO);

            /*" -1077- IF RH-TIPO-REG OF REG-HEADER NOT EQUAL 'H' */

            if (LBFPF990.REG_HEADER.RH_TIPO_REG != "H")
            {

                /*" -1078- DISPLAY 'VG1650B - FIM ANORMAL' */
                _.Display($"VG1650B - FIM ANORMAL");

                /*" -1081- DISPLAY '          MOVIMENTO NAO POSSUI HEADER ' RH-NOME OF REG-HEADER '  ' RH-DATA-GERACAO OF REG-HEADER */

                $"          MOVIMENTO NAO POSSUI HEADER {LBFPF990.REG_HEADER.RH_NOME}  {LBFPF990.REG_HEADER.RH_DATA_GERACAO}"
                .Display();

                /*" -1083- PERFORM R9000-00-FINALIZA. */

                R9000_00_FINALIZA_SECTION();
            }


            /*" -1084- IF RH-NOME OF REG-HEADER NOT EQUAL 'PRPRSIM' */

            if (LBFPF990.REG_HEADER.RH_NOME != "PRPRSIM")
            {

                /*" -1085- DISPLAY 'VG1650B - FIM ANORMAL' */
                _.Display($"VG1650B - FIM ANORMAL");

                /*" -1086- DISPLAY '          HEADER INVALIDO' */
                _.Display($"          HEADER INVALIDO");

                /*" -1089- DISPLAY '          NOME DO ARQUIVO INVALIDO  ' RH-NOME OF REG-HEADER '  ' RH-DATA-GERACAO OF REG-HEADER */

                $"          NOME DO ARQUIVO INVALIDO  {LBFPF990.REG_HEADER.RH_NOME}  {LBFPF990.REG_HEADER.RH_DATA_GERACAO}"
                .Display();

                /*" -1091- PERFORM R9000-00-FINALIZA. */

                R9000_00_FINALIZA_SECTION();
            }


            /*" -1093- PERFORM R0920-00-VALIDAR-CONVENIO. */

            R0920_00_VALIDAR_CONVENIO_SECTION();

            /*" -1094- IF RH-DATA-GERACAO OF REG-HEADER NOT NUMERIC */

            if (!LBFPF990.REG_HEADER.RH_DATA_GERACAO.IsNumeric())
            {

                /*" -1095- DISPLAY 'VG1650B - FIM ANORMAL' */
                _.Display($"VG1650B - FIM ANORMAL");

                /*" -1096- DISPLAY '          HEADER INVALIDO' */
                _.Display($"          HEADER INVALIDO");

                /*" -1099- DISPLAY '          DATA DA GERACAO INVALIDA  ' RH-NOME OF REG-HEADER '  ' RH-DATA-GERACAO OF REG-HEADER */

                $"          DATA DA GERACAO INVALIDA  {LBFPF990.REG_HEADER.RH_NOME}  {LBFPF990.REG_HEADER.RH_DATA_GERACAO}"
                .Display();

                /*" -1101- PERFORM R9000-00-FINALIZA. */

                R9000_00_FINALIZA_SECTION();
            }


            /*" -1102- IF RH-DATA-GERACAO OF REG-HEADER EQUAL ZEROS */

            if (LBFPF990.REG_HEADER.RH_DATA_GERACAO == 00)
            {

                /*" -1103- DISPLAY 'VG1650B - FIM ANORMAL' */
                _.Display($"VG1650B - FIM ANORMAL");

                /*" -1104- DISPLAY '          HEADER INVALIDO' */
                _.Display($"          HEADER INVALIDO");

                /*" -1107- DISPLAY '          DATA DA GERACAO INVALIDA  ' RH-NOME OF REG-HEADER '  ' RH-DATA-GERACAO OF REG-HEADER */

                $"          DATA DA GERACAO INVALIDA  {LBFPF990.REG_HEADER.RH_NOME}  {LBFPF990.REG_HEADER.RH_DATA_GERACAO}"
                .Display();

                /*" -1109- PERFORM R9000-00-FINALIZA. */

                R9000_00_FINALIZA_SECTION();
            }


            /*" -1110- IF RH-TIPO-ARQUIVO OF REG-HEADER NOT EQUAL 1 */

            if (LBFPF990.REG_HEADER.RH_TIPO_ARQUIVO != 1)
            {

                /*" -1111- DISPLAY 'VG1650B  -  FIM ANORMAL' */
                _.Display($"VG1650B  -  FIM ANORMAL");

                /*" -1112- DISPLAY '            HEADER INVALIDO' */
                _.Display($"            HEADER INVALIDO");

                /*" -1116- DISPLAY '            TIPO DE ARQUIVO INVALIDO  ' RH-NOME OF REG-HEADER '  ' RH-DATA-GERACAO OF REG-HEADER '  ' RH-TIPO-ARQUIVO OF REG-HEADER */

                $"            TIPO DE ARQUIVO INVALIDO  {LBFPF990.REG_HEADER.RH_NOME}  {LBFPF990.REG_HEADER.RH_DATA_GERACAO}  {LBFPF990.REG_HEADER.RH_TIPO_ARQUIVO}"
                .Display();

                /*" -1118- PERFORM R9000-00-FINALIZA. */

                R9000_00_FINALIZA_SECTION();
            }


            /*" -1120- PERFORM R0925-00-VAL-ARQUIVO-SIVPF. */

            R0925_00_VAL_ARQUIVO_SIVPF_SECTION();

            /*" -1121- IF RH-NSAS OF REG-HEADER EQUAL ZEROS */

            if (LBFPF990.REG_HEADER.RH_NSAS == 00)
            {

                /*" -1122- DISPLAY 'VG1650B - FIM ANORMAL' */
                _.Display($"VG1650B - FIM ANORMAL");

                /*" -1123- DISPLAY '          HEADER INVALIDO' */
                _.Display($"          HEADER INVALIDO");

                /*" -1127- DISPLAY '          SEQUENCIAL DO ARQUIVO INVALIDO  ' RH-NOME OF REG-HEADER ' ' RH-SIST-ORIGEM OF REG-HEADER ' ' RH-DATA-GERACAO OF REG-HEADER */

                $"          SEQUENCIAL DO ARQUIVO INVALIDO  {LBFPF990.REG_HEADER.RH_NOME} {LBFPF990.REG_HEADER.RH_SIST_ORIGEM} {LBFPF990.REG_HEADER.RH_DATA_GERACAO}"
                .Display();

                /*" -1127- PERFORM R9000-00-FINALIZA. */

                R9000_00_FINALIZA_SECTION();
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0915_99_SAIDA*/

        [StopWatch]
        /*" R0920-00-VALIDAR-CONVENIO-SECTION */
        private void R0920_00_VALIDAR_CONVENIO_SECTION()
        {
            /*" -1138- MOVE 'R0920-00-VALIDAR-CONVENIO' TO PARAGRAFO. */
            _.Move("R0920-00-VALIDAR-CONVENIO", REG_LEITURA.FILLER_16.WABEND.PARAGRAFO);

            /*" -1141- MOVE 'SELECT CONVENIO_SIVPF' TO COMANDO. */
            _.Move("SELECT CONVENIO_SIVPF", REG_LEITURA.FILLER_16.LOCALIZA_ABEND_2.COMANDO);

            /*" -1144- MOVE RH-NOME OF REG-HEADER TO SIGLA-ARQUIVO OF DCLCONVENIO-SIVPF. */
            _.Move(LBFPF990.REG_HEADER.RH_NOME, COVSIVPF.DCLCONVENIO_SIVPF.SIGLA_ARQUIVO);

            /*" -1149- PERFORM R0920_00_VALIDAR_CONVENIO_DB_SELECT_1 */

            R0920_00_VALIDAR_CONVENIO_DB_SELECT_1();

            /*" -1152- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -1153- DISPLAY 'VG1650B - FIM ANORMAL' */
                _.Display($"VG1650B - FIM ANORMAL");

                /*" -1154- DISPLAY '          CONVENIO NAO CADASTRADO' */
                _.Display($"          CONVENIO NAO CADASTRADO");

                /*" -1156- DISPLAY '          NOME ARQUIVO........ ' RH-NOME OF REG-HEADER */
                _.Display($"          NOME ARQUIVO........ {LBFPF990.REG_HEADER.RH_NOME}");

                /*" -1158- DISPLAY '          DATA GERACAO........ ' RH-DATA-GERACAO OF REG-HEADER */
                _.Display($"          DATA GERACAO........ {LBFPF990.REG_HEADER.RH_DATA_GERACAO}");

                /*" -1160- DISPLAY '          SISTEMA ORIGEM...... ' RH-SIST-ORIGEM OF REG-HEADER */
                _.Display($"          SISTEMA ORIGEM...... {LBFPF990.REG_HEADER.RH_SIST_ORIGEM}");

                /*" -1162- DISPLAY '          SISTEMA DESTINO..... ' RH-SIST-DESTINO OF REG-HEADER */
                _.Display($"          SISTEMA DESTINO..... {LBFPF990.REG_HEADER.RH_SIST_DESTINO}");

                /*" -1164- DISPLAY '          NSAS................ ' RH-NSAS OF REG-HEADER */
                _.Display($"          NSAS................ {LBFPF990.REG_HEADER.RH_NSAS}");

                /*" -1164- PERFORM R9000-00-FINALIZA. */

                R9000_00_FINALIZA_SECTION();
            }


        }

        [StopWatch]
        /*" R0920-00-VALIDAR-CONVENIO-DB-SELECT-1 */
        public void R0920_00_VALIDAR_CONVENIO_DB_SELECT_1()
        {
            /*" -1149- EXEC SQL SELECT DESCR_ARQUIVO INTO :DCLCONVENIO-SIVPF.DESCR-ARQUIVO FROM SEGUROS.CONVENIO_SIVPF WHERE SIGLA_ARQUIVO = :DCLCONVENIO-SIVPF.SIGLA-ARQUIVO END-EXEC. */

            var r0920_00_VALIDAR_CONVENIO_DB_SELECT_1_Query1 = new R0920_00_VALIDAR_CONVENIO_DB_SELECT_1_Query1()
            {
                SIGLA_ARQUIVO = COVSIVPF.DCLCONVENIO_SIVPF.SIGLA_ARQUIVO.ToString(),
            };

            var executed_1 = R0920_00_VALIDAR_CONVENIO_DB_SELECT_1_Query1.Execute(r0920_00_VALIDAR_CONVENIO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.DESCR_ARQUIVO, COVSIVPF.DCLCONVENIO_SIVPF.DESCR_ARQUIVO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0920_99_SAIDA*/

        [StopWatch]
        /*" R0925-00-VAL-ARQUIVO-SIVPF-SECTION */
        private void R0925_00_VAL_ARQUIVO_SIVPF_SECTION()
        {
            /*" -1175- MOVE 'R0925-00-VAL-ARQUIVO-SIVPF' TO PARAGRAFO. */
            _.Move("R0925-00-VAL-ARQUIVO-SIVPF", REG_LEITURA.FILLER_16.WABEND.PARAGRAFO);

            /*" -1178- MOVE 'SELECT ARQUIVOS_SIVPF' TO COMANDO. */
            _.Move("SELECT ARQUIVOS_SIVPF", REG_LEITURA.FILLER_16.LOCALIZA_ABEND_2.COMANDO);

            /*" -1181- MOVE RH-NOME OF REG-HEADER TO ARQSIVPF-SIGLA-ARQUIVO OF DCLARQUIVOS-SIVPF. */
            _.Move(LBFPF990.REG_HEADER.RH_NOME, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SIGLA_ARQUIVO);

            /*" -1184- MOVE RH-SIST-ORIGEM OF REG-HEADER TO ARQSIVPF-SISTEMA-ORIGEM OF DCLARQUIVOS-SIVPF. */
            _.Move(LBFPF990.REG_HEADER.RH_SIST_ORIGEM, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SISTEMA_ORIGEM);

            /*" -1187- MOVE RH-NSAS OF REG-HEADER TO ARQSIVPF-NSAS-SIVPF OF DCLARQUIVOS-SIVPF. */
            _.Move(LBFPF990.REG_HEADER.RH_NSAS, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF);

            /*" -1197- PERFORM R0925_00_VAL_ARQUIVO_SIVPF_DB_SELECT_1 */

            R0925_00_VAL_ARQUIVO_SIVPF_DB_SELECT_1();

            /*" -1200- IF SQLCODE EQUAL 00 */

            if (DB.SQLCODE == 00)
            {

                /*" -1201- DISPLAY 'VG1650B - FIM ANORMAL' */
                _.Display($"VG1650B - FIM ANORMAL");

                /*" -1202- DISPLAY '          MOVIMENTO JAH PROCESSADO' */
                _.Display($"          MOVIMENTO JAH PROCESSADO");

                /*" -1204- DISPLAY '          NOME ARQUIVO........ ' RH-NOME OF REG-HEADER */
                _.Display($"          NOME ARQUIVO........ {LBFPF990.REG_HEADER.RH_NOME}");

                /*" -1206- DISPLAY '          DATA GERACAO........ ' RH-DATA-GERACAO OF REG-HEADER */
                _.Display($"          DATA GERACAO........ {LBFPF990.REG_HEADER.RH_DATA_GERACAO}");

                /*" -1208- DISPLAY '          SISTEMA ORIGEM...... ' RH-SIST-ORIGEM OF REG-HEADER */
                _.Display($"          SISTEMA ORIGEM...... {LBFPF990.REG_HEADER.RH_SIST_ORIGEM}");

                /*" -1210- DISPLAY '          SISTEMA DESTINO..... ' RH-SIST-DESTINO OF REG-HEADER */
                _.Display($"          SISTEMA DESTINO..... {LBFPF990.REG_HEADER.RH_SIST_DESTINO}");

                /*" -1212- DISPLAY '          NSAS................ ' RH-NSAS OF REG-HEADER */
                _.Display($"          NSAS................ {LBFPF990.REG_HEADER.RH_NSAS}");

                /*" -1214- DISPLAY '          SQLCODE............. ' SQLCODE */
                _.Display($"          SQLCODE............. {DB.SQLCODE}");

                /*" -1215- PERFORM R9000-00-FINALIZA */

                R9000_00_FINALIZA_SECTION();

                /*" -1216- ELSE */
            }
            else
            {


                /*" -1217- IF SQLCODE NOT EQUAL 100 */

                if (DB.SQLCODE != 100)
                {

                    /*" -1218- DISPLAY 'VA0600B - FIM ANORMAL' */
                    _.Display($"VA0600B - FIM ANORMAL");

                    /*" -1219- DISPLAY '          ERRO ACESSO ARQUIVOS_SIVPF' */
                    _.Display($"          ERRO ACESSO ARQUIVOS_SIVPF");

                    /*" -1221- DISPLAY '          NOME ARQUIVO........ ' RH-NOME OF REG-HEADER */
                    _.Display($"          NOME ARQUIVO........ {LBFPF990.REG_HEADER.RH_NOME}");

                    /*" -1223- DISPLAY '          DATA GERACAO........ ' RH-DATA-GERACAO OF REG-HEADER */
                    _.Display($"          DATA GERACAO........ {LBFPF990.REG_HEADER.RH_DATA_GERACAO}");

                    /*" -1225- DISPLAY '          SISTEMA ORIGEM...... ' RH-SIST-ORIGEM OF REG-HEADER */
                    _.Display($"          SISTEMA ORIGEM...... {LBFPF990.REG_HEADER.RH_SIST_ORIGEM}");

                    /*" -1227- DISPLAY '          SISTEMA DESTINO..... ' RH-SIST-DESTINO OF REG-HEADER */
                    _.Display($"          SISTEMA DESTINO..... {LBFPF990.REG_HEADER.RH_SIST_DESTINO}");

                    /*" -1229- DISPLAY '          NSAS................ ' RH-NSAS OF REG-HEADER */
                    _.Display($"          NSAS................ {LBFPF990.REG_HEADER.RH_NSAS}");

                    /*" -1231- DISPLAY '          SQLCODE............. ' SQLCODE */
                    _.Display($"          SQLCODE............. {DB.SQLCODE}");

                    /*" -1231- PERFORM R9000-00-FINALIZA. */

                    R9000_00_FINALIZA_SECTION();
                }

            }


        }

        [StopWatch]
        /*" R0925-00-VAL-ARQUIVO-SIVPF-DB-SELECT-1 */
        public void R0925_00_VAL_ARQUIVO_SIVPF_DB_SELECT_1()
        {
            /*" -1197- EXEC SQL SELECT DATA_GERACAO INTO :DCLARQUIVOS-SIVPF.ARQSIVPF-DATA-GERACAO FROM SEGUROS.ARQUIVOS_SIVPF WHERE SIGLA_ARQUIVO = :DCLARQUIVOS-SIVPF.ARQSIVPF-SIGLA-ARQUIVO AND SISTEMA_ORIGEM = :DCLARQUIVOS-SIVPF.ARQSIVPF-SISTEMA-ORIGEM AND NSAS_SIVPF = :DCLARQUIVOS-SIVPF.ARQSIVPF-NSAS-SIVPF END-EXEC. */

            var r0925_00_VAL_ARQUIVO_SIVPF_DB_SELECT_1_Query1 = new R0925_00_VAL_ARQUIVO_SIVPF_DB_SELECT_1_Query1()
            {
                ARQSIVPF_SISTEMA_ORIGEM = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SISTEMA_ORIGEM.ToString(),
                ARQSIVPF_SIGLA_ARQUIVO = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SIGLA_ARQUIVO.ToString(),
                ARQSIVPF_NSAS_SIVPF = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF.ToString(),
            };

            var executed_1 = R0925_00_VAL_ARQUIVO_SIVPF_DB_SELECT_1_Query1.Execute(r0925_00_VAL_ARQUIVO_SIVPF_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.ARQSIVPF_DATA_GERACAO, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_GERACAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0925_99_SAIDA*/

        [StopWatch]
        /*" R0950-00-SELECT-RAMOCOMP-SECTION */
        private void R0950_00_SELECT_RAMOCOMP_SECTION()
        {
            /*" -1242- MOVE 'R0950-00-SELECT-RAMOCOMP  ' TO PARAGRAFO. */
            _.Move("R0950-00-SELECT-RAMOCOMP  ", REG_LEITURA.FILLER_16.WABEND.PARAGRAFO);

            /*" -1246- MOVE '0950' TO WNR-EXEC-SQL. */
            _.Move("0950", REG_LEITURA.FILLER_16.WABEND.WNR_EXEC_SQL);

            /*" -1247- IF WS-NUM-APOLICE-ANT NOT EQUAL MOVIMVGA-NUM-APOLICE */

            if (WS_NUM_APOLICE_ANT != MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_NUM_APOLICE)
            {

                /*" -1248- MOVE MOVIMVGA-NUM-APOLICE TO WS-NUM-APOLICE-ANT */
                _.Move(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_NUM_APOLICE, WS_NUM_APOLICE_ANT);

                /*" -1249- ELSE */
            }
            else
            {


                /*" -1250- GO TO R0950-90-IOF */

                R0950_90_IOF(); //GOTO
                return;

                /*" -1252- END-IF. */
            }


            /*" -1261- PERFORM R0950_00_SELECT_RAMOCOMP_DB_SELECT_1 */

            R0950_00_SELECT_RAMOCOMP_DB_SELECT_1();

            /*" -1264- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1265- DISPLAY 'ERRO ACESSO APOLICES        ' */
                _.Display($"ERRO ACESSO APOLICES        ");

                /*" -1266- DISPLAY 'APOLICE        ' MOVIMVGA-NUM-APOLICE */
                _.Display($"APOLICE        {MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_NUM_APOLICE}");

                /*" -1266- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -0- FLUXCONTROL_PERFORM R0950_90_IOF */

            R0950_90_IOF();

        }

        [StopWatch]
        /*" R0950-00-SELECT-RAMOCOMP-DB-SELECT-1 */
        public void R0950_00_SELECT_RAMOCOMP_DB_SELECT_1()
        {
            /*" -1261- EXEC SQL SELECT RAMO_EMISSOR INTO :APOLICES-RAMO-EMISSOR FROM SEGUROS.APOLICES WHERE NUM_APOLICE = :MOVIMVGA-NUM-APOLICE END-EXEC. */

            var r0950_00_SELECT_RAMOCOMP_DB_SELECT_1_Query1 = new R0950_00_SELECT_RAMOCOMP_DB_SELECT_1_Query1()
            {
                MOVIMVGA_NUM_APOLICE = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_NUM_APOLICE.ToString(),
            };

            var executed_1 = R0950_00_SELECT_RAMOCOMP_DB_SELECT_1_Query1.Execute(r0950_00_SELECT_RAMOCOMP_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.APOLICES_RAMO_EMISSOR, APOLICES.DCLAPOLICES.APOLICES_RAMO_EMISSOR);
            }


        }

        [StopWatch]
        /*" R0950-90-IOF */
        private void R0950_90_IOF(bool isPerform = false)
        {
            /*" -1272- MOVE '095A' TO WNR-EXEC-SQL. */
            _.Move("095A", REG_LEITURA.FILLER_16.WABEND.WNR_EXEC_SQL);

            /*" -1282- PERFORM R0950_90_IOF_DB_SELECT_1 */

            R0950_90_IOF_DB_SELECT_1();

            /*" -1285- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1286- DISPLAY 'ERRO ACESSO RAMO COMPLEMENTAR   ' */
                _.Display($"ERRO ACESSO RAMO COMPLEMENTAR   ");

                /*" -1287- DISPLAY 'APOLICE        ' MOVIMVGA-NUM-APOLICE */
                _.Display($"APOLICE        {MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_NUM_APOLICE}");

                /*" -1288- DISPLAY 'RAMO_EMISSOR   ' APOLICES-RAMO-EMISSOR */
                _.Display($"RAMO_EMISSOR   {APOLICES.DCLAPOLICES.APOLICES_RAMO_EMISSOR}");

                /*" -1289- DISPLAY 'DATA           ' MOVIMVGA-DATA-MOVIMENTO */
                _.Display($"DATA           {MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_MOVIMENTO}");

                /*" -1289- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0950-90-IOF-DB-SELECT-1 */
        public void R0950_90_IOF_DB_SELECT_1()
        {
            /*" -1282- EXEC SQL SELECT PCT_IOCC_RAMO INTO :RAMOCOMP-PCT-IOCC-RAMO FROM SEGUROS.RAMO_COMPLEMENTAR WHERE RAMO_EMISSOR = :APOLICES-RAMO-EMISSOR AND DATA_INIVIGENCIA <= :MOVIMVGA-DATA-MOVIMENTO AND DATA_TERVIGENCIA >= :MOVIMVGA-DATA-MOVIMENTO END-EXEC. */

            var r0950_90_IOF_DB_SELECT_1_Query1 = new R0950_90_IOF_DB_SELECT_1_Query1()
            {
                MOVIMVGA_DATA_MOVIMENTO = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_MOVIMENTO.ToString(),
                APOLICES_RAMO_EMISSOR = APOLICES.DCLAPOLICES.APOLICES_RAMO_EMISSOR.ToString(),
            };

            var executed_1 = R0950_90_IOF_DB_SELECT_1_Query1.Execute(r0950_90_IOF_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.RAMOCOMP_PCT_IOCC_RAMO, RAMOCOMP.DCLRAMO_COMPLEMENTAR.RAMOCOMP_PCT_IOCC_RAMO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0950_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-SECTION */
        private void R1000_00_PROCESSA_SECTION()
        {
            /*" -1302- MOVE 'R1000-00-PROCESSA         ' TO PARAGRAFO. */
            _.Move("R1000-00-PROCESSA         ", REG_LEITURA.FILLER_16.WABEND.PARAGRAFO);

            /*" -1303- PERFORM R1050-00-PROCESSA-REGISTRO UNTIL FIM-MOVIMENTO. */

            while (!(REG_LEITURA.FILLER_16.FLAG_WFIM_MOVIMENTO["FIM_MOVIMENTO"]))
            {

                R1050_00_PROCESSA_REGISTRO_SECTION();
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1050-00-PROCESSA-REGISTRO-SECTION */
        private void R1050_00_PROCESSA_REGISTRO_SECTION()
        {
            /*" -1314- MOVE 'R1050-00-PROCESSA-REGISTRO' TO PARAGRAFO. */
            _.Move("R1050-00-PROCESSA-REGISTRO", REG_LEITURA.FILLER_16.WABEND.PARAGRAFO);

            /*" -1318- MOVE '1050' TO WNR-EXEC-SQL. */
            _.Move("1050", REG_LEITURA.FILLER_16.WABEND.WNR_EXEC_SQL);

            /*" -1319- EVALUATE REG-TIPO-SIGAT */
            switch (REG_SIGAT.REG_TIPO_SIGAT.Value.Trim())
            {

                /*" -1320- WHEN    '1' */
                case "1":

                    /*" -1321- PERFORM R1100-00-PROCESSA-CLIENTE */

                    R1100_00_PROCESSA_CLIENTE_SECTION();

                    /*" -1322- WHEN    '2' */
                    break;
                case "2":

                    /*" -1323- PERFORM R3020-00-INSERT-ENDERECO */

                    R3020_00_INSERT_ENDERECO_SECTION();

                    /*" -1324- WHEN    '3' */
                    break;
                case "3":

                    /*" -1325- PERFORM R1200-00-PROCESSA-PROPOSTA */

                    R1200_00_PROCESSA_PROPOSTA_SECTION();

                    /*" -1326- WHEN    'B' */
                    break;
                case "B":

                    /*" -1327- PERFORM R1300-00-PROCESSA-COMPL */

                    R1300_00_PROCESSA_COMPL_SECTION();

                    /*" -1328- WHEN    'H' */
                    break;
                case "H":

                    /*" -1329- MOVE REG-SIGAT TO REG-HEADER */
                    _.Move(MOV_SIGAT?.Value, LBFPF990.REG_HEADER);

                    /*" -1330- WHEN    'T' */
                    break;
                case "T":

                    /*" -1331- MOVE REG-SIGAT TO REG-TRAILLER */
                    _.Move(MOV_SIGAT?.Value, LBFPF991.REG_TRAILLER);

                    /*" -1332- WHEN    OTHER */
                    break;
                default:

                    /*" -1333- DISPLAY 'VG1650B - FIM ANORMAL' */
                    _.Display($"VG1650B - FIM ANORMAL");

                    /*" -1335- DISPLAY '          TIPO ARQUIVO INVALIDO ' REG-TIPO-SIGAT */
                    _.Display($"          TIPO ARQUIVO INVALIDO {REG_SIGAT.REG_TIPO_SIGAT}");

                    /*" -1336- PERFORM R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION();

                    /*" -1336- END-EVALUATE. */
                    break;
            }


            /*" -0- FLUXCONTROL_PERFORM R1050_NEXT */

            R1050_NEXT();

        }

        [StopWatch]
        /*" R1050-NEXT */
        private void R1050_NEXT(bool isPerform = false)
        {
            /*" -1342- PERFORM R0910-00-LE-MOVIMENTO. */

            R0910_00_LE_MOVIMENTO_SECTION();

            /*" -1343- IF FIM-MOVIMENTO */

            if (REG_LEITURA.FILLER_16.FLAG_WFIM_MOVIMENTO["FIM_MOVIMENTO"])
            {

                /*" -1343- PERFORM R8040-00-UPDATE-FONTES. */

                R8040_00_UPDATE_FONTES_SECTION();
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1050_99_SAIDA*/

        [StopWatch]
        /*" R1100-00-PROCESSA-CLIENTE-SECTION */
        private void R1100_00_PROCESSA_CLIENTE_SECTION()
        {
            /*" -1355- MOVE 'R1100-00-PROCESSA-CLIENTE ' TO PARAGRAFO. */
            _.Move("R1100-00-PROCESSA-CLIENTE ", REG_LEITURA.FILLER_16.WABEND.PARAGRAFO);

            /*" -1359- MOVE '1100' TO WNR-EXEC-SQL. */
            _.Move("1100", REG_LEITURA.FILLER_16.WABEND.WNR_EXEC_SQL);

            /*" -1361- INITIALIZE REG-CLIENTES. */
            _.Initialize(
                LBFPF011.REG_CLIENTES
            );

            /*" -1363- MOVE REG-SIGAT TO REG-CLIENTES. */
            _.Move(MOV_SIGAT?.Value, LBFPF011.REG_CLIENTES);

            /*" -1363- PERFORM R3000-00-GRAVA-CLIENTES. */

            R3000_00_GRAVA_CLIENTES_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/

        [StopWatch]
        /*" R1200-00-PROCESSA-PROPOSTA-SECTION */
        private void R1200_00_PROCESSA_PROPOSTA_SECTION()
        {
            /*" -1374- MOVE 'R1200-00-PROCESSA-PROPOSTA' TO PARAGRAFO. */
            _.Move("R1200-00-PROCESSA-PROPOSTA", REG_LEITURA.FILLER_16.WABEND.PARAGRAFO);

            /*" -1378- MOVE '1200' TO WNR-EXEC-SQL. */
            _.Move("1200", REG_LEITURA.FILLER_16.WABEND.WNR_EXEC_SQL);

            /*" -1380- INITIALIZE REG-PROPOSTA-SASSE. */
            _.Initialize(
                LXFCT004.REG_PROPOSTA_SASSE
            );

            /*" -1382- MOVE REG-SIGAT TO REG-PROPOSTA-SASSE. */
            _.Move(MOV_SIGAT?.Value, LXFCT004.REG_PROPOSTA_SASSE);

            /*" -1384- PERFORM R3300-00-INSERT-MOVIMVGA. */

            R3300_00_INSERT_MOVIMVGA_SECTION();

            /*" -1386- PERFORM R3400-00-INSERT-PROPOSTAVA. */

            R3400_00_INSERT_PROPOSTAVA_SECTION();

            /*" -1391- PERFORM R3600-00-INSERT-OPCAOPAGVA. */

            R3600_00_INSERT_OPCAOPAGVA_SECTION();

            /*" -1393- PERFORM R3500-00-INSERT-COBERPROPVA. */

            R3500_00_INSERT_COBERPROPVA_SECTION();

            /*" -1395- PERFORM R3700-00-INSERT-PARCELVA. */

            R3700_00_INSERT_PARCELVA_SECTION();

            /*" -1397- PERFORM R3800-00-INSERT-HISTCOBVA. */

            R3800_00_INSERT_HISTCOBVA_SECTION();

            /*" -1399- PERFORM R3900-00-INSERT-HISTCONTABILVA. */

            R3900_00_INSERT_HISTCONTABILVA_SECTION();

            /*" -1399- PERFORM R4000-00-INSERT-COMUNICFDCAPVA. */

            R4000_00_INSERT_COMUNICFDCAPVA_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/

        [StopWatch]
        /*" R1300-00-PROCESSA-COMPL-SECTION */
        private void R1300_00_PROCESSA_COMPL_SECTION()
        {
            /*" -1410- MOVE 'R1300-00-PROCESSA-COMPL   ' TO PARAGRAFO. */
            _.Move("R1300-00-PROCESSA-COMPL   ", REG_LEITURA.FILLER_16.WABEND.PARAGRAFO);

            /*" -1414- MOVE '1300' TO WNR-EXEC-SQL. */
            _.Move("1300", REG_LEITURA.FILLER_16.WABEND.WNR_EXEC_SQL);

            /*" -1416- INITIALIZE REG-TIPO-B. */
            _.Initialize(
                REG_TIPO_B
            );

            /*" -1418- MOVE REG-SIGAT TO REG-TIPO-B. */
            _.Move(MOV_SIGAT?.Value, REG_TIPO_B);

            /*" -1421- MOVE ZEROS TO WTAM-END. */
            _.Move(0, FILLER_5.WTAM_END);

            /*" -1424- MOVE 3 TO ENDERECO-COD-ENDERECO. */
            _.Move(3, ENDERECO.DCLENDERECOS.ENDERECO_COD_ENDERECO);

            /*" -1435- PERFORM R1300_00_PROCESSA_COMPL_DB_SELECT_1 */

            R1300_00_PROCESSA_COMPL_DB_SELECT_1();

            /*" -1438- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1439- DISPLAY 'ENDERECO DE RISCO NAO ATUALIZADO' */
                _.Display($"ENDERECO DE RISCO NAO ATUALIZADO");

                /*" -1440- DISPLAY 'CODIGO CLIENTE ' CLIENTES-COD-CLIENTE */
                _.Display($"CODIGO CLIENTE {CLIENTES.DCLCLIENTES.CLIENTES_COD_CLIENTE}");

                /*" -1441- DISPLAY 'PROPOSTA       ' PROPOVA-NUM-CERTIFICADO */
                _.Display($"PROPOSTA       {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                /*" -1443- GO TO R1300-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1300_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1446- MOVE 'N' TO WFIM-CAMPO. */
            _.Move("N", FILLER_5.WFIM_CAMPO);

            /*" -1449- MOVE 40 TO WCONTA. */
            _.Move(40, FILLER_5.WCONTA);

            /*" -1451- PERFORM UNTIL WFIM-CAMPO EQUAL 'S' */

            while (!(FILLER_5.WFIM_CAMPO == "S"))
            {

                /*" -1453- IF R24-NOME-EVENTO (WCONTA:1) NOT EQUAL SPACES OR WCONTA EQUAL 1 */

                if (REG_TIPO_B.R24_NOME_EVENTO.Substring(FILLER_5.WCONTA, 1) != string.Empty || FILLER_5.WCONTA == 1)
                {

                    /*" -1454- MOVE 'S' TO WFIM-CAMPO */
                    _.Move("S", FILLER_5.WFIM_CAMPO);

                    /*" -1455- ELSE */
                }
                else
                {


                    /*" -1456- COMPUTE WCONTA = WCONTA - 1 */
                    FILLER_5.WCONTA.Value = FILLER_5.WCONTA - 1;

                    /*" -1457- END-IF */
                }


                /*" -1459- END-PERFORM. */
            }

            /*" -1461- COMPUTE WTAM-END = 70 - WCONTA. */
            FILLER_5.WTAM_END.Value = 70 - FILLER_5.WCONTA;

            /*" -1466- MOVE SPACES TO WENDERECO WBAIRRO WCIDADE. */
            _.Move("", FILLER_5.WENDERECO, FILLER_5.WBAIRRO, FILLER_5.WCIDADE);

            /*" -1469- MOVE ENDERECO-ENDERECO TO WENDERECO. */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_ENDERECO, FILLER_5.WENDERECO);

            /*" -1472- MOVE ENDERECO-BAIRRO TO WBAIRRO. */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_BAIRRO, FILLER_5.WBAIRRO);

            /*" -1475- MOVE ENDERECO-CIDADE TO WCIDADE. */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_CIDADE, FILLER_5.WCIDADE);

            /*" -1483- STRING WENDERECO (1:WTAM-END) '|' DELIMITED BY SIZE R24-NOME-EVENTO (1: WCONTA) DELIMITED BY SIZE INTO ENDERECO-ENDERECO END-STRING. */
            #region STRING
            var spl1 = FILLER_5.WENDERECO.Substring(1, FILLER_5.WTAM_END).GetMoveValues();
            spl1 += "|";
            var spl2 = REG_TIPO_B.R24_NOME_EVENTO.GetMoveValues();
            var spl3 = FILLER_5.WCONTA.GetMoveValues();
            var spl4 = FILLER_5.WENDERECO.Substring(1, FILLER_5.WTAM_END).GetMoveValues();
            spl4 += "|";
            var spl5 = REG_TIPO_B.R24_NOME_EVENTO.GetMoveValues();
            var spl6 = FILLER_5.WCONTA.GetMoveValues();
            var results7 = spl1 + spl2 + spl3 + spl4 + spl5 + spl6;
            _.Move(results7, ENDERECO.DCLENDERECOS.ENDERECO_ENDERECO);
            #endregion

            /*" -1490- STRING WBAIRRO (1:56) DELIMITED BY SIZE R24-NUM-PEDIDO DELIMITED BY SIZE INTO ENDERECO-BAIRRO END-STRING. */
            #region STRING
            var spl7 = FILLER_5.WBAIRRO.Substring(1, 56).GetMoveValues();
            var spl8 = REG_TIPO_B.R24_NUM_PEDIDO.GetMoveValues();
            var spl9 = FILLER_5.WBAIRRO.Substring(1, 56).GetMoveValues();
            var spl10 = REG_TIPO_B.R24_NUM_PEDIDO.GetMoveValues();
            var results11 = spl7 + spl8 + spl9 + spl10;
            _.Move(results11, ENDERECO.DCLENDERECOS.ENDERECO_BAIRRO);
            #endregion

            /*" -1500- STRING WCIDADE (1:52) DELIMITED BY SIZE R24-COD-LOCAL DELIMITED BY SPACES ' ' DELIMITED BY SIZE R24-NUM-INGRESSO DELIMITED BY SIZE INTO ENDERECO-CIDADE END-STRING. */
            #region STRING
            var spl11 = FILLER_5.WCIDADE.Substring(1, 52).GetMoveValues();
            var spl12 = REG_TIPO_B.R24_COD_LOCAL.GetMoveValues();
            spl12 += " ";
            var spl13 = REG_TIPO_B.R24_NUM_INGRESSO.GetMoveValues();
            var spl14 = FILLER_5.WCIDADE.Substring(1, 52).GetMoveValues();
            var spl15 = REG_TIPO_B.R24_COD_LOCAL.GetMoveValues();
            spl15 += " ";
            var spl16 = REG_TIPO_B.R24_NUM_INGRESSO.GetMoveValues();
            var spl17 = FILLER_5.WCIDADE.Substring(1, 52).GetMoveValues();
            var spl18 = REG_TIPO_B.R24_COD_LOCAL.GetMoveValues();
            spl18 += " ";
            var spl19 = REG_TIPO_B.R24_NUM_INGRESSO.GetMoveValues();
            var results20 = spl11 + spl12 + spl13 + spl14 + spl15 + spl16 + spl17 + spl18 + spl19;
            _.Move(results20, ENDERECO.DCLENDERECOS.ENDERECO_CIDADE);
            #endregion

            /*" -1507- PERFORM R1300_00_PROCESSA_COMPL_DB_UPDATE_1 */

            R1300_00_PROCESSA_COMPL_DB_UPDATE_1();

            /*" -1510- IF SQLCODE NOT EQUAL ZEROS AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -1511- DISPLAY 'ERRO NO UPDATE ENDERECO DE RISCO' */
                _.Display($"ERRO NO UPDATE ENDERECO DE RISCO");

                /*" -1512- DISPLAY 'CODIGO CLIENTE ' CLIENTES-COD-CLIENTE */
                _.Display($"CODIGO CLIENTE {CLIENTES.DCLCLIENTES.CLIENTES_COD_CLIENTE}");

                /*" -1514- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1514- ADD 1 TO AC-GRA-ENDRIS. */
            FILLER_5.AC_GRA_ENDRIS.Value = FILLER_5.AC_GRA_ENDRIS + 1;

        }

        [StopWatch]
        /*" R1300-00-PROCESSA-COMPL-DB-SELECT-1 */
        public void R1300_00_PROCESSA_COMPL_DB_SELECT_1()
        {
            /*" -1435- EXEC SQL SELECT ENDERECO, BAIRRO, CIDADE INTO :ENDERECO-ENDERECO, :ENDERECO-BAIRRO, :ENDERECO-CIDADE FROM SEGUROS.ENDERECOS WHERE COD_CLIENTE = :CLIENTES-COD-CLIENTE AND COD_ENDERECO = :ENDERECO-COD-ENDERECO FETCH FIRST 1 ROW ONLY END-EXEC. */

            var r1300_00_PROCESSA_COMPL_DB_SELECT_1_Query1 = new R1300_00_PROCESSA_COMPL_DB_SELECT_1_Query1()
            {
                ENDERECO_COD_ENDERECO = ENDERECO.DCLENDERECOS.ENDERECO_COD_ENDERECO.ToString(),
                CLIENTES_COD_CLIENTE = CLIENTES.DCLCLIENTES.CLIENTES_COD_CLIENTE.ToString(),
            };

            var executed_1 = R1300_00_PROCESSA_COMPL_DB_SELECT_1_Query1.Execute(r1300_00_PROCESSA_COMPL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.ENDERECO_ENDERECO, ENDERECO.DCLENDERECOS.ENDERECO_ENDERECO);
                _.Move(executed_1.ENDERECO_BAIRRO, ENDERECO.DCLENDERECOS.ENDERECO_BAIRRO);
                _.Move(executed_1.ENDERECO_CIDADE, ENDERECO.DCLENDERECOS.ENDERECO_CIDADE);
            }


        }

        [StopWatch]
        /*" R1300-00-PROCESSA-COMPL-DB-UPDATE-1 */
        public void R1300_00_PROCESSA_COMPL_DB_UPDATE_1()
        {
            /*" -1507- EXEC SQL UPDATE SEGUROS.ENDERECOS SET ENDERECO = :ENDERECO-ENDERECO, BAIRRO = :ENDERECO-BAIRRO, CIDADE = :ENDERECO-CIDADE WHERE COD_CLIENTE = :CLIENTES-COD-CLIENTE AND COD_ENDERECO = :ENDERECO-COD-ENDERECO END-EXEC. */

            var r1300_00_PROCESSA_COMPL_DB_UPDATE_1_Update1 = new R1300_00_PROCESSA_COMPL_DB_UPDATE_1_Update1()
            {
                ENDERECO_ENDERECO = ENDERECO.DCLENDERECOS.ENDERECO_ENDERECO.ToString(),
                ENDERECO_BAIRRO = ENDERECO.DCLENDERECOS.ENDERECO_BAIRRO.ToString(),
                ENDERECO_CIDADE = ENDERECO.DCLENDERECOS.ENDERECO_CIDADE.ToString(),
                ENDERECO_COD_ENDERECO = ENDERECO.DCLENDERECOS.ENDERECO_COD_ENDERECO.ToString(),
                CLIENTES_COD_CLIENTE = CLIENTES.DCLCLIENTES.CLIENTES_COD_CLIENTE.ToString(),
            };

            R1300_00_PROCESSA_COMPL_DB_UPDATE_1_Update1.Execute(r1300_00_PROCESSA_COMPL_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1300_99_SAIDA*/

        [StopWatch]
        /*" R2300-00-SELECT-NUMEROUT-SECTION */
        private void R2300_00_SELECT_NUMEROUT_SECTION()
        {
            /*" -1527- MOVE 'R2300-00-SELECT-NUMEROUT' TO PARAGRAFO. */
            _.Move("R2300-00-SELECT-NUMEROUT", REG_LEITURA.FILLER_16.WABEND.PARAGRAFO);

            /*" -1531- MOVE '2300' TO WNR-EXEC-SQL. */
            _.Move("2300", REG_LEITURA.FILLER_16.WABEND.WNR_EXEC_SQL);

            /*" -1538- PERFORM R2300_00_SELECT_NUMEROUT_DB_SELECT_1 */

            R2300_00_SELECT_NUMEROUT_DB_SELECT_1();

            /*" -1541- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1543- DISPLAY 'VG1650B - NAO EXISTE NUM.CLIE. NUMEROS-OUTROS' */
                _.Display($"VG1650B - NAO EXISTE NUM.CLIE. NUMEROS-OUTROS");

                /*" -1543- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2300-00-SELECT-NUMEROUT-DB-SELECT-1 */
        public void R2300_00_SELECT_NUMEROUT_DB_SELECT_1()
        {
            /*" -1538- EXEC SQL SELECT NUM_CLIENTE INTO :NUMEROUT-NUM-CLIENTE FROM SEGUROS.NUMERO_OUTROS END-EXEC. */

            var r2300_00_SELECT_NUMEROUT_DB_SELECT_1_Query1 = new R2300_00_SELECT_NUMEROUT_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R2300_00_SELECT_NUMEROUT_DB_SELECT_1_Query1.Execute(r2300_00_SELECT_NUMEROUT_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.NUMEROUT_NUM_CLIENTE, NUMEROUT.DCLNUMERO_OUTROS.NUMEROUT_NUM_CLIENTE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2300_99_SAIDA*/

        [StopWatch]
        /*" R3000-00-GRAVA-CLIENTES-SECTION */
        private void R3000_00_GRAVA_CLIENTES_SECTION()
        {
            /*" -1557- MOVE 'R3000-00-GRAVA-CLIENTES ' TO PARAGRAFO. */
            _.Move("R3000-00-GRAVA-CLIENTES ", REG_LEITURA.FILLER_16.WABEND.PARAGRAFO);

            /*" -1561- MOVE '3000' TO WNR-EXEC-SQL. */
            _.Move("3000", REG_LEITURA.FILLER_16.WABEND.WNR_EXEC_SQL);

            /*" -1563- PERFORM R3010-00-MOVE-CLIENTE. */

            R3010_00_MOVE_CLIENTE_SECTION();

            /*" -1564- IF WS-JA-TEM-CODIGO EQUAL 'S' */

            if (WS_JA_TEM_CODIGO == "S")
            {

                /*" -1566- GO TO R3000-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1566- PERFORM R2300-00-SELECT-NUMEROUT. */

            R2300_00_SELECT_NUMEROUT_SECTION();

            /*" -0- FLUXCONTROL_PERFORM R3000_10_GRAVA_CLIENTES */

            R3000_10_GRAVA_CLIENTES();

        }

        [StopWatch]
        /*" R3000-10-GRAVA-CLIENTES */
        private void R3000_10_GRAVA_CLIENTES(bool isPerform = false)
        {
            /*" -1573- ADD 1 TO NUMEROUT-NUM-CLIENTE. */
            NUMEROUT.DCLNUMERO_OUTROS.NUMEROUT_NUM_CLIENTE.Value = NUMEROUT.DCLNUMERO_OUTROS.NUMEROUT_NUM_CLIENTE + 1;

            /*" -1576- MOVE NUMEROUT-NUM-CLIENTE TO CLIENTES-COD-CLIENTE. */
            _.Move(NUMEROUT.DCLNUMERO_OUTROS.NUMEROUT_NUM_CLIENTE, CLIENTES.DCLCLIENTES.CLIENTES_COD_CLIENTE);

            /*" -1612- PERFORM R3000_10_GRAVA_CLIENTES_DB_INSERT_1 */

            R3000_10_GRAVA_CLIENTES_DB_INSERT_1();

            /*" -1615- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1616- IF SQLCODE EQUAL -803 */

                if (DB.SQLCODE == -803)
                {

                    /*" -1617- GO TO R3000-10-GRAVA-CLIENTES */
                    new Task(() => R3000_10_GRAVA_CLIENTES()).RunSynchronously(); //GOTO
                    return;//Recursividade detectada, cuidado...

                    /*" -1618- ELSE */
                }
                else
                {


                    /*" -1619- DISPLAY 'ERRO NO INSERT DA TABELA CLIENTES' */
                    _.Display($"ERRO NO INSERT DA TABELA CLIENTES");

                    /*" -1620- DISPLAY 'CODIGO CLIENTE ' CLIENTES-COD-CLIENTE */
                    _.Display($"CODIGO CLIENTE {CLIENTES.DCLCLIENTES.CLIENTES_COD_CLIENTE}");

                    /*" -1622- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -1624- PERFORM R8020-00-UPDATE-NUMEROUT. */

            R8020_00_UPDATE_NUMEROUT_SECTION();

            /*" -1626- ADD 1 TO AC-GRA-CLIENT. */
            FILLER_5.AC_GRA_CLIENT.Value = FILLER_5.AC_GRA_CLIENT + 1;

            /*" -1627- IF EMAIL OF DCLPESSOA-EMAIL EQUAL SPACES */

            if (PESEMAIL.DCLPESSOA_EMAIL.EMAIL.IsEmpty())
            {

                /*" -1629- GO TO R3000-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1643- PERFORM R3000_10_GRAVA_CLIENTES_DB_INSERT_2 */

            R3000_10_GRAVA_CLIENTES_DB_INSERT_2();

            /*" -1646- IF SQLCODE NOT EQUAL ZEROS AND -803 */

            if (!DB.SQLCODE.In("00", "-803"))
            {

                /*" -1647- DISPLAY 'ERRO NO INSERT DA TABELA CLIENTES' */
                _.Display($"ERRO NO INSERT DA TABELA CLIENTES");

                /*" -1648- DISPLAY 'CODIGO CLIENTE ' CLIENTES-COD-CLIENTE */
                _.Display($"CODIGO CLIENTE {CLIENTES.DCLCLIENTES.CLIENTES_COD_CLIENTE}");

                /*" -1650- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1650- ADD 1 TO AC-GRA-PESEMA. */
            FILLER_5.AC_GRA_PESEMA.Value = FILLER_5.AC_GRA_PESEMA + 1;

        }

        [StopWatch]
        /*" R3000-10-GRAVA-CLIENTES-DB-INSERT-1 */
        public void R3000_10_GRAVA_CLIENTES_DB_INSERT_1()
        {
            /*" -1612- EXEC SQL INSERT INTO SEGUROS.CLIENTES (COD_CLIENTE , NOME_RAZAO , TIPO_PESSOA , CGCCPF , SIT_REGISTRO , DATA_NASCIMENTO , COD_EMPRESA , COD_PORTE_EMP , COD_NATUREZA_ATIV , COD_RAMO_ATIVIDADE , COD_ATIVIDADE , IDE_SEXO , ESTADO_CIVIL , COD_GRD_GRUPO_CBO , COD_SUBGRUPO_CBO , COD_GRUPO_BASE_CBO , COD_SUBGR_BASE_CBO) VALUES (:CLIENTES-COD-CLIENTE, :CLIENTES-NOME-RAZAO, :CLIENTES-TIPO-PESSOA, :CLIENTES-CGCCPF, :CLIENTES-SIT-REGISTRO, :CLIENTES-DATA-NASCIMENTO, :CLIENTES-COD-EMPRESA, NULL , NULL , NULL , NULL , :CLIENTES-IDE-SEXO , :CLIENTES-ESTADO-CIVIL , NULL , NULL , NULL , NULL) END-EXEC. */

            var r3000_10_GRAVA_CLIENTES_DB_INSERT_1_Insert1 = new R3000_10_GRAVA_CLIENTES_DB_INSERT_1_Insert1()
            {
                CLIENTES_COD_CLIENTE = CLIENTES.DCLCLIENTES.CLIENTES_COD_CLIENTE.ToString(),
                CLIENTES_NOME_RAZAO = CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO.ToString(),
                CLIENTES_TIPO_PESSOA = CLIENTES.DCLCLIENTES.CLIENTES_TIPO_PESSOA.ToString(),
                CLIENTES_CGCCPF = CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF.ToString(),
                CLIENTES_SIT_REGISTRO = CLIENTES.DCLCLIENTES.CLIENTES_SIT_REGISTRO.ToString(),
                CLIENTES_DATA_NASCIMENTO = CLIENTES.DCLCLIENTES.CLIENTES_DATA_NASCIMENTO.ToString(),
                CLIENTES_COD_EMPRESA = CLIENTES.DCLCLIENTES.CLIENTES_COD_EMPRESA.ToString(),
                CLIENTES_IDE_SEXO = CLIENTES.DCLCLIENTES.CLIENTES_IDE_SEXO.ToString(),
                CLIENTES_ESTADO_CIVIL = CLIENTES.DCLCLIENTES.CLIENTES_ESTADO_CIVIL.ToString(),
            };

            R3000_10_GRAVA_CLIENTES_DB_INSERT_1_Insert1.Execute(r3000_10_GRAVA_CLIENTES_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_99_SAIDA*/

        [StopWatch]
        /*" R3000-10-GRAVA-CLIENTES-DB-INSERT-2 */
        public void R3000_10_GRAVA_CLIENTES_DB_INSERT_2()
        {
            /*" -1643- EXEC SQL INSERT INTO SEGUROS.PESSOA_EMAIL ( COD_PESSOA, SEQ_EMAIL, EMAIL, SITUACAO_EMAIL, COD_USUARIO, TIMESTAMP) VALUES(:CLIENTES-COD-CLIENTE, 1, :DCLPESSOA-EMAIL.EMAIL, 'A' , 'VG1650B' , CURRENT TIMESTAMP) END-EXEC. */

            var r3000_10_GRAVA_CLIENTES_DB_INSERT_2_Insert1 = new R3000_10_GRAVA_CLIENTES_DB_INSERT_2_Insert1()
            {
                CLIENTES_COD_CLIENTE = CLIENTES.DCLCLIENTES.CLIENTES_COD_CLIENTE.ToString(),
                EMAIL = PESEMAIL.DCLPESSOA_EMAIL.EMAIL.ToString(),
            };

            R3000_10_GRAVA_CLIENTES_DB_INSERT_2_Insert1.Execute(r3000_10_GRAVA_CLIENTES_DB_INSERT_2_Insert1);

        }

        [StopWatch]
        /*" R3010-00-MOVE-CLIENTE-SECTION */
        private void R3010_00_MOVE_CLIENTE_SECTION()
        {
            /*" -1664- MOVE 'R3010-00-MOVE-CLIENTE   ' TO PARAGRAFO. */
            _.Move("R3010-00-MOVE-CLIENTE   ", REG_LEITURA.FILLER_16.WABEND.PARAGRAFO);

            /*" -1668- MOVE '3010' TO WNR-EXEC-SQL. */
            _.Move("3010", REG_LEITURA.FILLER_16.WABEND.WNR_EXEC_SQL);

            /*" -1671- MOVE ZEROS TO CLIENTES-COD-CLIENTE. */
            _.Move(0, CLIENTES.DCLCLIENTES.CLIENTES_COD_CLIENTE);

            /*" -1674- MOVE 'N' TO WS-JA-TEM-CODIGO. */
            _.Move("N", WS_JA_TEM_CODIGO);

            /*" -1677- MOVE R1-NOME-PESSOA TO CLIENTES-NOME-RAZAO. */
            _.Move(LBFPF011.REG_CLIENTES.R1_NOME_PESSOA, CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO);

            /*" -1678- IF R1-TIPO-PESSOA EQUAL 2 */

            if (LBFPF011.REG_CLIENTES.R1_TIPO_PESSOA == 2)
            {

                /*" -1679- MOVE 'J' TO CLIENTES-TIPO-PESSOA */
                _.Move("J", CLIENTES.DCLCLIENTES.CLIENTES_TIPO_PESSOA);

                /*" -1680- ELSE */
            }
            else
            {


                /*" -1682- MOVE 'F' TO CLIENTES-TIPO-PESSOA. */
                _.Move("F", CLIENTES.DCLCLIENTES.CLIENTES_TIPO_PESSOA);
            }


            /*" -1685- MOVE R1-CGC-CPF TO CLIENTES-CGCCPF. */
            _.Move(LBFPF011.REG_CLIENTES.R1_CGC_CPF, CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF);

            /*" -1688- MOVE '0' TO CLIENTES-SIT-REGISTRO. */
            _.Move("0", CLIENTES.DCLCLIENTES.CLIENTES_SIT_REGISTRO);

            /*" -1691- MOVE 0 TO CLIENTES-COD-EMPRESA. */
            _.Move(0, CLIENTES.DCLCLIENTES.CLIENTES_COD_EMPRESA);

            /*" -1692- IF R1-IDE-SEXO EQUAL 2 */

            if (LBFPF011.REG_CLIENTES.R1_IDE_SEXO == 2)
            {

                /*" -1693- MOVE 'F' TO CLIENTES-IDE-SEXO */
                _.Move("F", CLIENTES.DCLCLIENTES.CLIENTES_IDE_SEXO);

                /*" -1694- ELSE */
            }
            else
            {


                /*" -1696- MOVE 'M' TO CLIENTES-IDE-SEXO. */
                _.Move("M", CLIENTES.DCLCLIENTES.CLIENTES_IDE_SEXO);
            }


            /*" -1697- IF R1-ESTADO-CIVIL EQUAL 1 */

            if (LBFPF011.REG_CLIENTES.R1_ESTADO_CIVIL == 1)
            {

                /*" -1698- MOVE 'S' TO CLIENTES-ESTADO-CIVIL */
                _.Move("S", CLIENTES.DCLCLIENTES.CLIENTES_ESTADO_CIVIL);

                /*" -1699- ELSE */
            }
            else
            {


                /*" -1700- IF R1-ESTADO-CIVIL EQUAL 2 */

                if (LBFPF011.REG_CLIENTES.R1_ESTADO_CIVIL == 2)
                {

                    /*" -1701- MOVE 'C' TO CLIENTES-ESTADO-CIVIL */
                    _.Move("C", CLIENTES.DCLCLIENTES.CLIENTES_ESTADO_CIVIL);

                    /*" -1702- ELSE */
                }
                else
                {


                    /*" -1703- IF R1-ESTADO-CIVIL EQUAL 3 */

                    if (LBFPF011.REG_CLIENTES.R1_ESTADO_CIVIL == 3)
                    {

                        /*" -1704- MOVE 'V' TO CLIENTES-ESTADO-CIVIL */
                        _.Move("V", CLIENTES.DCLCLIENTES.CLIENTES_ESTADO_CIVIL);

                        /*" -1705- ELSE */
                    }
                    else
                    {


                        /*" -1707- MOVE 'O' TO CLIENTES-ESTADO-CIVIL. */
                        _.Move("O", CLIENTES.DCLCLIENTES.CLIENTES_ESTADO_CIVIL);
                    }

                }

            }


            /*" -1710- MOVE SPACES TO EMAIL OF DCLPESSOA-EMAIL. */
            _.Move("", PESEMAIL.DCLPESSOA_EMAIL.EMAIL);

            /*" -1713- MOVE R1-EMAIL (1:40) TO EMAIL OF DCLPESSOA-EMAIL. */
            _.Move(LBFPF011.REG_CLIENTES.R1_EMAIL.Substring(1, 40), PESEMAIL.DCLPESSOA_EMAIL.EMAIL);

            /*" -1716- MOVE ZEROS TO WS-DATA-AUX-1. */
            _.Move(0, FILLER_5.WS_DATA_AUX_1);

            /*" -1719- MOVE R1-DATA-NASCIMENTO TO WS-DATA-AUX-1. */
            _.Move(LBFPF011.REG_CLIENTES.R1_DATA_NASCIMENTO, FILLER_5.WS_DATA_AUX_1);

            /*" -1722- MOVE WS-DIA-AUX-1 TO WS-DIA-AUX. */
            _.Move(FILLER_5.WS_DATA_AUX_1.WS_DIA_AUX_1, FILLER_5.WS_DATA_AUX.WS_DIA_AUX);

            /*" -1725- MOVE WS-MES-AUX-1 TO WS-MES-AUX. */
            _.Move(FILLER_5.WS_DATA_AUX_1.WS_MES_AUX_1, FILLER_5.WS_DATA_AUX.WS_MES_AUX);

            /*" -1728- MOVE WS-ANO-AUX-1 TO WS-ANO-AUX. */
            _.Move(FILLER_5.WS_DATA_AUX_1.WS_ANO_AUX_1, FILLER_5.WS_DATA_AUX.WS_ANO_AUX);

            /*" -1731- MOVE WS-DATA-AUX TO CLIENTES-DATA-NASCIMENTO. */
            _.Move(FILLER_5.WS_DATA_AUX, CLIENTES.DCLCLIENTES.CLIENTES_DATA_NASCIMENTO);

            /*" -1732- IF CLIENTES-CGCCPF GREATER ZEROS */

            if (CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF > 00)
            {

                /*" -1738- PERFORM R3010_00_MOVE_CLIENTE_DB_SELECT_1 */

                R3010_00_MOVE_CLIENTE_DB_SELECT_1();

                /*" -1741- IF CLIENTES-COD-CLIENTE GREATER ZEROS */

                if (CLIENTES.DCLCLIENTES.CLIENTES_COD_CLIENTE > 00)
                {

                    /*" -1742- MOVE 'S' TO WS-JA-TEM-CODIGO */
                    _.Move("S", WS_JA_TEM_CODIGO);

                    /*" -1743- END-IF */
                }


                /*" -1743- END-IF. */
            }


        }

        [StopWatch]
        /*" R3010-00-MOVE-CLIENTE-DB-SELECT-1 */
        public void R3010_00_MOVE_CLIENTE_DB_SELECT_1()
        {
            /*" -1738- EXEC SQL SELECT VALUE(MAX(COD_CLIENTE),0) INTO :CLIENTES-COD-CLIENTE FROM SEGUROS.CLIENTES WHERE CGCCPF = :CLIENTES-CGCCPF AND DATA_NASCIMENTO = :CLIENTES-DATA-NASCIMENTO END-EXEC */

            var r3010_00_MOVE_CLIENTE_DB_SELECT_1_Query1 = new R3010_00_MOVE_CLIENTE_DB_SELECT_1_Query1()
            {
                CLIENTES_DATA_NASCIMENTO = CLIENTES.DCLCLIENTES.CLIENTES_DATA_NASCIMENTO.ToString(),
                CLIENTES_CGCCPF = CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF.ToString(),
            };

            var executed_1 = R3010_00_MOVE_CLIENTE_DB_SELECT_1_Query1.Execute(r3010_00_MOVE_CLIENTE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CLIENTES_COD_CLIENTE, CLIENTES.DCLCLIENTES.CLIENTES_COD_CLIENTE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3010_99_SAIDA*/

        [StopWatch]
        /*" R3020-00-INSERT-ENDERECO-SECTION */
        private void R3020_00_INSERT_ENDERECO_SECTION()
        {
            /*" -1756- MOVE 'R3020-00-INSERT-ENDERECO' TO PARAGRAFO. */
            _.Move("R3020-00-INSERT-ENDERECO", REG_LEITURA.FILLER_16.WABEND.PARAGRAFO);

            /*" -1760- MOVE '3020' TO WNR-EXEC-SQL. */
            _.Move("3020", REG_LEITURA.FILLER_16.WABEND.WNR_EXEC_SQL);

            /*" -1762- INITIALIZE REG-ENDERECO. */
            _.Initialize(
                LBFPF012.REG_ENDERECO
            );

            /*" -1764- MOVE REG-SIGAT TO REG-ENDERECO. */
            _.Move(MOV_SIGAT?.Value, LBFPF012.REG_ENDERECO);

            /*" -1767- MOVE R2-TIPO-ENDER TO ENDERECO-COD-ENDERECO. */
            _.Move(LBFPF012.REG_ENDERECO.R2_TIPO_ENDER, ENDERECO.DCLENDERECOS.ENDERECO_COD_ENDERECO);

            /*" -1772- PERFORM R3020_00_INSERT_ENDERECO_DB_SELECT_1 */

            R3020_00_INSERT_ENDERECO_DB_SELECT_1();

            /*" -1775- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1776- DISPLAY 'PARAGRAFO...' PARAGRAFO */
                _.Display($"PARAGRAFO...{REG_LEITURA.FILLER_16.WABEND.PARAGRAFO}");

                /*" -1777- DISPLAY 'ERRO ACESSO ENDERECOS' */
                _.Display($"ERRO ACESSO ENDERECOS");

                /*" -1779- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1782- ADD 1 TO ENDERECO-OCORR-ENDERECO. */
            ENDERECO.DCLENDERECOS.ENDERECO_OCORR_ENDERECO.Value = ENDERECO.DCLENDERECOS.ENDERECO_OCORR_ENDERECO + 1;

            /*" -1785- MOVE R2-ENDERECO TO ENDERECO-ENDERECO. */
            _.Move(LBFPF012.REG_ENDERECO.R2_ENDERECO, ENDERECO.DCLENDERECOS.ENDERECO_ENDERECO);

            /*" -1788- MOVE R2-BAIRRO TO ENDERECO-BAIRRO. */
            _.Move(LBFPF012.REG_ENDERECO.R2_BAIRRO, ENDERECO.DCLENDERECOS.ENDERECO_BAIRRO);

            /*" -1791- MOVE R2-CIDADE TO ENDERECO-CIDADE. */
            _.Move(LBFPF012.REG_ENDERECO.R2_CIDADE, ENDERECO.DCLENDERECOS.ENDERECO_CIDADE);

            /*" -1794- MOVE R2-SIGLA-UF TO ENDERECO-SIGLA-UF. */
            _.Move(LBFPF012.REG_ENDERECO.R2_SIGLA_UF, ENDERECO.DCLENDERECOS.ENDERECO_SIGLA_UF);

            /*" -1797- MOVE R2-CEP TO ENDERECO-CEP. */
            _.Move(LBFPF012.REG_ENDERECO.R2_CEP, ENDERECO.DCLENDERECOS.ENDERECO_CEP);

            /*" -1798- IF R1-DDD (1) NOT NUMERIC */

            if (!LBFPF011.REG_CLIENTES.R1_TELEFONE[1].R1_DDD.IsNumeric())
            {

                /*" -1801- MOVE ZEROS TO R1-DDD (1). */
                _.Move(0, LBFPF011.REG_CLIENTES.R1_TELEFONE[1].R1_DDD);
            }


            /*" -1804- MOVE R1-DDD (1) TO ENDERECO-DDD. */
            _.Move(LBFPF011.REG_CLIENTES.R1_TELEFONE[1].R1_DDD, ENDERECO.DCLENDERECOS.ENDERECO_DDD);

            /*" -1805- IF R1-NUM-FONE (1) NOT NUMERIC */

            if (!LBFPF011.REG_CLIENTES.R1_TELEFONE[1].R1_NUM_FONE.IsNumeric())
            {

                /*" -1808- MOVE ZEROS TO R1-NUM-FONE (1). */
                _.Move(0, LBFPF011.REG_CLIENTES.R1_TELEFONE[1].R1_NUM_FONE);
            }


            /*" -1811- MOVE R1-NUM-FONE (1) TO ENDERECO-TELEFONE. */
            _.Move(LBFPF011.REG_CLIENTES.R1_TELEFONE[1].R1_NUM_FONE, ENDERECO.DCLENDERECOS.ENDERECO_TELEFONE);

            /*" -1812- IF R1-NUM-FONE (2) NOT NUMERIC */

            if (!LBFPF011.REG_CLIENTES.R1_TELEFONE[2].R1_NUM_FONE.IsNumeric())
            {

                /*" -1815- MOVE ZEROS TO R1-NUM-FONE (2). */
                _.Move(0, LBFPF011.REG_CLIENTES.R1_TELEFONE[2].R1_NUM_FONE);
            }


            /*" -1818- MOVE R1-NUM-FONE (2) TO ENDERECO-FAX. */
            _.Move(LBFPF011.REG_CLIENTES.R1_TELEFONE[2].R1_NUM_FONE, ENDERECO.DCLENDERECOS.ENDERECO_FAX);

            /*" -1819- IF R1-NUM-FONE (3) NOT NUMERIC */

            if (!LBFPF011.REG_CLIENTES.R1_TELEFONE[3].R1_NUM_FONE.IsNumeric())
            {

                /*" -1822- MOVE ZEROS TO R1-NUM-FONE (3). */
                _.Move(0, LBFPF011.REG_CLIENTES.R1_TELEFONE[3].R1_NUM_FONE);
            }


            /*" -1825- MOVE R1-NUM-FONE (3) TO ENDERECO-TELEX. */
            _.Move(LBFPF011.REG_CLIENTES.R1_TELEFONE[3].R1_NUM_FONE, ENDERECO.DCLENDERECOS.ENDERECO_TELEX);

            /*" -1857- PERFORM R3020_00_INSERT_ENDERECO_DB_INSERT_1 */

            R3020_00_INSERT_ENDERECO_DB_INSERT_1();

            /*" -1860- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1861- DISPLAY 'ERRO NO INSERT DA TABELA ENDERECOS' */
                _.Display($"ERRO NO INSERT DA TABELA ENDERECOS");

                /*" -1862- DISPLAY 'CODIGO CLIENTE ' CLIENTES-COD-CLIENTE */
                _.Display($"CODIGO CLIENTE {CLIENTES.DCLCLIENTES.CLIENTES_COD_CLIENTE}");

                /*" -1864- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1864- ADD 1 TO AC-GRA-ENDERE. */
            FILLER_5.AC_GRA_ENDERE.Value = FILLER_5.AC_GRA_ENDERE + 1;

        }

        [StopWatch]
        /*" R3020-00-INSERT-ENDERECO-DB-SELECT-1 */
        public void R3020_00_INSERT_ENDERECO_DB_SELECT_1()
        {
            /*" -1772- EXEC SQL SELECT VALUE(MAX(OCORR_ENDERECO),0) INTO :ENDERECO-OCORR-ENDERECO FROM SEGUROS.ENDERECOS WHERE COD_CLIENTE = :CLIENTES-COD-CLIENTE END-EXEC. */

            var r3020_00_INSERT_ENDERECO_DB_SELECT_1_Query1 = new R3020_00_INSERT_ENDERECO_DB_SELECT_1_Query1()
            {
                CLIENTES_COD_CLIENTE = CLIENTES.DCLCLIENTES.CLIENTES_COD_CLIENTE.ToString(),
            };

            var executed_1 = R3020_00_INSERT_ENDERECO_DB_SELECT_1_Query1.Execute(r3020_00_INSERT_ENDERECO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.ENDERECO_OCORR_ENDERECO, ENDERECO.DCLENDERECOS.ENDERECO_OCORR_ENDERECO);
            }


        }

        [StopWatch]
        /*" R3020-00-INSERT-ENDERECO-DB-INSERT-1 */
        public void R3020_00_INSERT_ENDERECO_DB_INSERT_1()
        {
            /*" -1857- EXEC SQL INSERT INTO SEGUROS.ENDERECOS ( COD_CLIENTE , COD_ENDERECO , OCORR_ENDERECO , ENDERECO , BAIRRO , CIDADE , SIGLA_UF , CEP , DDD , TELEFONE , FAX , TELEX , SIT_REGISTRO , COD_EMPRESA , DES_COMPLEMENTO ) VALUES (:CLIENTES-COD-CLIENTE , :ENDERECO-COD-ENDERECO , :ENDERECO-OCORR-ENDERECO , :ENDERECO-ENDERECO , :ENDERECO-BAIRRO , :ENDERECO-CIDADE , :ENDERECO-SIGLA-UF , :ENDERECO-CEP , :ENDERECO-DDD , :ENDERECO-TELEFONE , :ENDERECO-FAX , :ENDERECO-TELEX , '0' , NULL , NULL ) END-EXEC. */

            var r3020_00_INSERT_ENDERECO_DB_INSERT_1_Insert1 = new R3020_00_INSERT_ENDERECO_DB_INSERT_1_Insert1()
            {
                CLIENTES_COD_CLIENTE = CLIENTES.DCLCLIENTES.CLIENTES_COD_CLIENTE.ToString(),
                ENDERECO_COD_ENDERECO = ENDERECO.DCLENDERECOS.ENDERECO_COD_ENDERECO.ToString(),
                ENDERECO_OCORR_ENDERECO = ENDERECO.DCLENDERECOS.ENDERECO_OCORR_ENDERECO.ToString(),
                ENDERECO_ENDERECO = ENDERECO.DCLENDERECOS.ENDERECO_ENDERECO.ToString(),
                ENDERECO_BAIRRO = ENDERECO.DCLENDERECOS.ENDERECO_BAIRRO.ToString(),
                ENDERECO_CIDADE = ENDERECO.DCLENDERECOS.ENDERECO_CIDADE.ToString(),
                ENDERECO_SIGLA_UF = ENDERECO.DCLENDERECOS.ENDERECO_SIGLA_UF.ToString(),
                ENDERECO_CEP = ENDERECO.DCLENDERECOS.ENDERECO_CEP.ToString(),
                ENDERECO_DDD = ENDERECO.DCLENDERECOS.ENDERECO_DDD.ToString(),
                ENDERECO_TELEFONE = ENDERECO.DCLENDERECOS.ENDERECO_TELEFONE.ToString(),
                ENDERECO_FAX = ENDERECO.DCLENDERECOS.ENDERECO_FAX.ToString(),
                ENDERECO_TELEX = ENDERECO.DCLENDERECOS.ENDERECO_TELEX.ToString(),
            };

            R3020_00_INSERT_ENDERECO_DB_INSERT_1_Insert1.Execute(r3020_00_INSERT_ENDERECO_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3020_99_SAIDA*/

        [StopWatch]
        /*" R3210-00-ACESSA-SUBGVGAP-SECTION */
        private void R3210_00_ACESSA_SUBGVGAP_SECTION()
        {
            /*" -1877- MOVE 'R3210-00-ACESSA-SUBGVGAP' TO PARAGRAFO. */
            _.Move("R3210-00-ACESSA-SUBGVGAP", REG_LEITURA.FILLER_16.WABEND.PARAGRAFO);

            /*" -1881- MOVE '3210' TO WNR-EXEC-SQL. */
            _.Move("3210", REG_LEITURA.FILLER_16.WABEND.WNR_EXEC_SQL);

            /*" -1924- PERFORM R3210_00_ACESSA_SUBGVGAP_DB_SELECT_1 */

            R3210_00_ACESSA_SUBGVGAP_DB_SELECT_1();

            /*" -1927- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1928- DISPLAY 'PARAGRAFO...' PARAGRAFO */
                _.Display($"PARAGRAFO...{REG_LEITURA.FILLER_16.WABEND.PARAGRAFO}");

                /*" -1929- DISPLAY 'APOLICE.....' SUBGVGAP-NUM-APOLICE */
                _.Display($"APOLICE.....{SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_NUM_APOLICE}");

                /*" -1930- DISPLAY 'SUBGRUPO....' SUBGVGAP-COD-SUBGRUPO */
                _.Display($"SUBGRUPO....{SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_SUBGRUPO}");

                /*" -1931- DISPLAY 'PROBLEMAS NO SELECT DE SUBGRUPOS' */
                _.Display($"PROBLEMAS NO SELECT DE SUBGRUPOS");

                /*" -1931- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R3210-00-ACESSA-SUBGVGAP-DB-SELECT-1 */
        public void R3210_00_ACESSA_SUBGVGAP_DB_SELECT_1()
        {
            /*" -1924- EXEC SQL SELECT A.COD_FONTE, A.COD_CLIENTE, A.OCORR_ENDERECO, A.AGE_COBRANCA, A.TIPO_PLANO, A.FORMA_AVERBACAO, A.TIPO_FATURAMENTO, A.PERI_FATURAMENTO, A.PERI_RENOVACAO, A.BCO_COBRANCA, A.AGE_COBRANCA, A.DAC_COBRANCA, A.PCT_CONJUGE_VG, A.PCT_CONJUGE_AP, A.IND_PLANO_ASSOCIA, A.TIPO_COBRANCA, B.COD_PRODUTO, VALUE(B.COD_RUBRICA,0) INTO :SUBGVGAP-COD-FONTE, :SUBGVGAP-COD-CLIENTE, :SUBGVGAP-OCORR-ENDERECO, :SUBGVGAP-AGE-COBRANCA, :SUBGVGAP-TIPO-PLANO, :SUBGVGAP-FORMA-AVERBACAO, :SUBGVGAP-TIPO-FATURAMENTO, :SUBGVGAP-PERI-FATURAMENTO, :SUBGVGAP-PERI-RENOVACAO, :SUBGVGAP-BCO-COBRANCA, :SUBGVGAP-AGE-COBRANCA, :SUBGVGAP-DAC-COBRANCA, :SUBGVGAP-PCT-CONJUGE-VG, :SUBGVGAP-PCT-CONJUGE-AP, :SUBGVGAP-IND-PLANO-ASSOCIA, :SUBGVGAP-TIPO-COBRANCA, :PRODUVG-COD-PRODUTO, :PRODUVG-COD-RUBRICA FROM SEGUROS.SUBGRUPOS_VGAP A, SEGUROS.PRODUTOS_VG B WHERE A.NUM_APOLICE = :SUBGVGAP-NUM-APOLICE AND A.COD_SUBGRUPO = :SUBGVGAP-COD-SUBGRUPO AND A.NUM_APOLICE = B.NUM_APOLICE AND A.COD_SUBGRUPO = B.COD_SUBGRUPO END-EXEC. */

            var r3210_00_ACESSA_SUBGVGAP_DB_SELECT_1_Query1 = new R3210_00_ACESSA_SUBGVGAP_DB_SELECT_1_Query1()
            {
                SUBGVGAP_COD_SUBGRUPO = SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_SUBGRUPO.ToString(),
                SUBGVGAP_NUM_APOLICE = SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_NUM_APOLICE.ToString(),
            };

            var executed_1 = R3210_00_ACESSA_SUBGVGAP_DB_SELECT_1_Query1.Execute(r3210_00_ACESSA_SUBGVGAP_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SUBGVGAP_COD_FONTE, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_FONTE);
                _.Move(executed_1.SUBGVGAP_COD_CLIENTE, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_CLIENTE);
                _.Move(executed_1.SUBGVGAP_OCORR_ENDERECO, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_OCORR_ENDERECO);
                _.Move(executed_1.SUBGVGAP_AGE_COBRANCA, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_AGE_COBRANCA);
                _.Move(executed_1.SUBGVGAP_TIPO_PLANO, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_TIPO_PLANO);
                _.Move(executed_1.SUBGVGAP_FORMA_AVERBACAO, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_FORMA_AVERBACAO);
                _.Move(executed_1.SUBGVGAP_TIPO_FATURAMENTO, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_TIPO_FATURAMENTO);
                _.Move(executed_1.SUBGVGAP_PERI_FATURAMENTO, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_PERI_FATURAMENTO);
                _.Move(executed_1.SUBGVGAP_PERI_RENOVACAO, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_PERI_RENOVACAO);
                _.Move(executed_1.SUBGVGAP_BCO_COBRANCA, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_BCO_COBRANCA);
                _.Move(executed_1.SUBGVGAP_DAC_COBRANCA, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_DAC_COBRANCA);
                _.Move(executed_1.SUBGVGAP_PCT_CONJUGE_VG, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_PCT_CONJUGE_VG);
                _.Move(executed_1.SUBGVGAP_PCT_CONJUGE_AP, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_PCT_CONJUGE_AP);
                _.Move(executed_1.SUBGVGAP_IND_PLANO_ASSOCIA, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_IND_PLANO_ASSOCIA);
                _.Move(executed_1.SUBGVGAP_TIPO_COBRANCA, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_TIPO_COBRANCA);
                _.Move(executed_1.PRODUVG_COD_PRODUTO, PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_PRODUTO);
                _.Move(executed_1.PRODUVG_COD_RUBRICA, PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_RUBRICA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3210_99_SAIDA*/

        [StopWatch]
        /*" R3220-00-ACESSA-CONDITEC-SECTION */
        private void R3220_00_ACESSA_CONDITEC_SECTION()
        {
            /*" -1944- MOVE 'R3220-00-ACESSA-CONDITEC' TO PARAGRAFO. */
            _.Move("R3220-00-ACESSA-CONDITEC", REG_LEITURA.FILLER_16.WABEND.PARAGRAFO);

            /*" -1948- MOVE '3220' TO WNR-EXEC-SQL. */
            _.Move("3220", REG_LEITURA.FILLER_16.WABEND.WNR_EXEC_SQL);

            /*" -1984- PERFORM R3220_00_ACESSA_CONDITEC_DB_SELECT_1 */

            R3220_00_ACESSA_CONDITEC_DB_SELECT_1();

            /*" -1987- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1988- DISPLAY 'APOLICE.....' SUBGVGAP-NUM-APOLICE */
                _.Display($"APOLICE.....{SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_NUM_APOLICE}");

                /*" -1989- DISPLAY 'SUBGRUPO....' SUBGVGAP-COD-SUBGRUPO */
                _.Display($"SUBGRUPO....{SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_SUBGRUPO}");

                /*" -1990- DISPLAY 'PROBLEMAS NO SELECT DE CONDICOES TECNICAS' */
                _.Display($"PROBLEMAS NO SELECT DE CONDICOES TECNICAS");

                /*" -1990- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R3220-00-ACESSA-CONDITEC-DB-SELECT-1 */
        public void R3220_00_ACESSA_CONDITEC_DB_SELECT_1()
        {
            /*" -1984- EXEC SQL SELECT QTD_SAL_MORNATU, QTD_SAL_MORACID, QTD_SAL_INVPERM, TAXA_AP_MORACID, TAXA_AP_INVPERM, TAXA_AP_AMDS, TAXA_AP_DH, TAXA_AP_DIT, TAXA_AP, LIM_CAP_MORNATU, LIM_CAP_MORACID, LIM_CAP_INVAPER, GARAN_ADIC_IEA, GARAN_ADIC_IPA, GARAN_ADIC_IPD, GARAN_ADIC_HD INTO :CONDITEC-QTD-SAL-MORNATU, :CONDITEC-QTD-SAL-MORACID, :CONDITEC-QTD-SAL-INVPERM, :CONDITEC-TAXA-AP-MORACID, :CONDITEC-TAXA-AP-INVPERM, :CONDITEC-TAXA-AP-AMDS, :CONDITEC-TAXA-AP-DH, :CONDITEC-TAXA-AP-DIT, :CONDITEC-TAXA-AP, :CONDITEC-LIM-CAP-MORNATU, :CONDITEC-LIM-CAP-MORACID, :CONDITEC-LIM-CAP-INVAPER, :CONDITEC-GARAN-ADIC-IEA, :CONDITEC-GARAN-ADIC-IPA, :CONDITEC-GARAN-ADIC-IPD, :CONDITEC-GARAN-ADIC-HD FROM SEGUROS.CONDICOES_TECNICAS WHERE NUM_APOLICE = :SUBGVGAP-NUM-APOLICE AND COD_SUBGRUPO = :SUBGVGAP-COD-SUBGRUPO END-EXEC. */

            var r3220_00_ACESSA_CONDITEC_DB_SELECT_1_Query1 = new R3220_00_ACESSA_CONDITEC_DB_SELECT_1_Query1()
            {
                SUBGVGAP_COD_SUBGRUPO = SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_SUBGRUPO.ToString(),
                SUBGVGAP_NUM_APOLICE = SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_NUM_APOLICE.ToString(),
            };

            var executed_1 = R3220_00_ACESSA_CONDITEC_DB_SELECT_1_Query1.Execute(r3220_00_ACESSA_CONDITEC_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CONDITEC_QTD_SAL_MORNATU, CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_QTD_SAL_MORNATU);
                _.Move(executed_1.CONDITEC_QTD_SAL_MORACID, CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_QTD_SAL_MORACID);
                _.Move(executed_1.CONDITEC_QTD_SAL_INVPERM, CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_QTD_SAL_INVPERM);
                _.Move(executed_1.CONDITEC_TAXA_AP_MORACID, CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_TAXA_AP_MORACID);
                _.Move(executed_1.CONDITEC_TAXA_AP_INVPERM, CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_TAXA_AP_INVPERM);
                _.Move(executed_1.CONDITEC_TAXA_AP_AMDS, CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_TAXA_AP_AMDS);
                _.Move(executed_1.CONDITEC_TAXA_AP_DH, CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_TAXA_AP_DH);
                _.Move(executed_1.CONDITEC_TAXA_AP_DIT, CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_TAXA_AP_DIT);
                _.Move(executed_1.CONDITEC_TAXA_AP, CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_TAXA_AP);
                _.Move(executed_1.CONDITEC_LIM_CAP_MORNATU, CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_LIM_CAP_MORNATU);
                _.Move(executed_1.CONDITEC_LIM_CAP_MORACID, CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_LIM_CAP_MORACID);
                _.Move(executed_1.CONDITEC_LIM_CAP_INVAPER, CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_LIM_CAP_INVAPER);
                _.Move(executed_1.CONDITEC_GARAN_ADIC_IEA, CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_GARAN_ADIC_IEA);
                _.Move(executed_1.CONDITEC_GARAN_ADIC_IPA, CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_GARAN_ADIC_IPA);
                _.Move(executed_1.CONDITEC_GARAN_ADIC_IPD, CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_GARAN_ADIC_IPD);
                _.Move(executed_1.CONDITEC_GARAN_ADIC_HD, CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_GARAN_ADIC_HD);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3220_99_SAIDA*/

        [StopWatch]
        /*" R3300-00-INSERT-MOVIMVGA-SECTION */
        private void R3300_00_INSERT_MOVIMVGA_SECTION()
        {
            /*" -2006- MOVE 'R3300-00-INSERT-MOVIMVGA' TO PARAGRAFO. */
            _.Move("R3300-00-INSERT-MOVIMVGA", REG_LEITURA.FILLER_16.WABEND.PARAGRAFO);

            /*" -2026- MOVE ZEROS TO MOVIMVGA-IMP-MORNATU-ANT MOVIMVGA-IMP-MORNATU-ATU MOVIMVGA-IMP-MORACID-ANT MOVIMVGA-IMP-MORACID-ATU MOVIMVGA-IMP-INVPERM-ANT MOVIMVGA-IMP-INVPERM-ATU MOVIMVGA-IMP-AMDS-ANT MOVIMVGA-IMP-AMDS-ATU MOVIMVGA-IMP-DH-ANT MOVIMVGA-IMP-DH-ATU MOVIMVGA-IMP-DIT-ANT MOVIMVGA-IMP-DIT-ATU MOVIMVGA-IMP-DH-ANT MOVIMVGA-IMP-DH-ATU MOVIMVGA-PRM-VG-ANT MOVIMVGA-PRM-VG-ATU MOVIMVGA-PRM-AP-ANT MOVIMVGA-PRM-AP-ATU. */
            _.Move(0, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_MORNATU_ANT, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_MORNATU_ATU, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_MORACID_ANT, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_MORACID_ATU, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_INVPERM_ANT, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_INVPERM_ATU, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_AMDS_ANT, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_AMDS_ATU, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_DH_ANT, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_DH_ATU, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_DIT_ANT, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_DIT_ATU, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_DH_ANT, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_DH_ATU, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PRM_VG_ANT, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PRM_VG_ATU, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PRM_AP_ANT, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PRM_AP_ATU);

            /*" -2029- MOVE CLIENTES-DATA-NASCIMENTO TO MOVIMVGA-DATA-NASCIMENTO. */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_DATA_NASCIMENTO, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_NASCIMENTO);

            /*" -2033- MOVE SISTEMAS-DATA-MOV-ABERTO-1 TO MOVIMVGA-DATA-REFERENCIA MOVIMVGA-DATA-ADMISSAO. */
            _.Move(SISTEMAS_DATA_MOV_ABERTO_1, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_REFERENCIA, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_ADMISSAO);

            /*" -2036- MOVE ZEROS TO WS-DATA-AUX-1. */
            _.Move(0, FILLER_5.WS_DATA_AUX_1);

            /*" -2039- MOVE R3-DATA-PROPOSTA TO WS-DATA-AUX-1. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_DATA_PROPOSTA, FILLER_5.WS_DATA_AUX_1);

            /*" -2042- MOVE WS-DIA-AUX-1 TO WS-DIA-AUX. */
            _.Move(FILLER_5.WS_DATA_AUX_1.WS_DIA_AUX_1, FILLER_5.WS_DATA_AUX.WS_DIA_AUX);

            /*" -2045- MOVE WS-MES-AUX-1 TO WS-MES-AUX. */
            _.Move(FILLER_5.WS_DATA_AUX_1.WS_MES_AUX_1, FILLER_5.WS_DATA_AUX.WS_MES_AUX);

            /*" -2048- MOVE WS-ANO-AUX-1 TO WS-ANO-AUX. */
            _.Move(FILLER_5.WS_DATA_AUX_1.WS_ANO_AUX_1, FILLER_5.WS_DATA_AUX.WS_ANO_AUX);

            /*" -2051- MOVE WS-DATA-AUX TO MOVIMVGA-DATA-MOVIMENTO. */
            _.Move(FILLER_5.WS_DATA_AUX, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_MOVIMENTO);

            /*" -2052- IF R3-COD-PLANO EQUAL 1 */

            if (LXFCT004.REG_PROPOSTA_SASSE.R3_COD_PLANO == 1)
            {

                /*" -2054- MOVE 0108210871143 TO SUBGVGAP-NUM-APOLICE */
                _.Move(0108210871143, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_NUM_APOLICE);

                /*" -2056- MOVE 1 TO SUBGVGAP-COD-SUBGRUPO */
                _.Move(1, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_SUBGRUPO);

                /*" -2058- END-IF. */
            }


            /*" -2059- IF R3-COD-PLANO EQUAL 2 */

            if (LXFCT004.REG_PROPOSTA_SASSE.R3_COD_PLANO == 2)
            {

                /*" -2061- MOVE 0108210871143 TO SUBGVGAP-NUM-APOLICE */
                _.Move(0108210871143, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_NUM_APOLICE);

                /*" -2063- MOVE 2 TO SUBGVGAP-COD-SUBGRUPO */
                _.Move(2, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_SUBGRUPO);

                /*" -2065- END-IF. */
            }


            /*" -2066- IF R3-COD-PLANO EQUAL 3 */

            if (LXFCT004.REG_PROPOSTA_SASSE.R3_COD_PLANO == 3)
            {

                /*" -2068- MOVE 0108210871143 TO SUBGVGAP-NUM-APOLICE */
                _.Move(0108210871143, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_NUM_APOLICE);

                /*" -2070- MOVE 3 TO SUBGVGAP-COD-SUBGRUPO */
                _.Move(3, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_SUBGRUPO);

                /*" -2072- END-IF. */
            }


            /*" -2073- IF R3-COD-PLANO EQUAL 4 */

            if (LXFCT004.REG_PROPOSTA_SASSE.R3_COD_PLANO == 4)
            {

                /*" -2075- MOVE 0108210871143 TO SUBGVGAP-NUM-APOLICE */
                _.Move(0108210871143, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_NUM_APOLICE);

                /*" -2077- MOVE 4 TO SUBGVGAP-COD-SUBGRUPO */
                _.Move(4, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_SUBGRUPO);

                /*" -2079- END-IF. */
            }


            /*" -2080- IF R3-COD-PLANO NOT EQUAL WHOST-PLANO-ANT */

            if (LXFCT004.REG_PROPOSTA_SASSE.R3_COD_PLANO != WHOST_PLANO_ANT)
            {

                /*" -2081- PERFORM R3210-00-ACESSA-SUBGVGAP */

                R3210_00_ACESSA_SUBGVGAP_SECTION();

                /*" -2082- PERFORM R3220-00-ACESSA-CONDITEC */

                R3220_00_ACESSA_CONDITEC_SECTION();

                /*" -2085- MOVE R3-COD-PLANO TO WHOST-PLANO-ANT. */
                _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_COD_PLANO, WHOST_PLANO_ANT);
            }


            /*" -2086- IF SUBGVGAP-FORMA-AVERBACAO = '2' */

            if (SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_FORMA_AVERBACAO == "2")
            {

                /*" -2088- MOVE '1' TO MOVIMVGA-SIT-REGISTRO */
                _.Move("1", MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_SIT_REGISTRO);

                /*" -2090- MOVE SISTEMAS-DATA-MOV-ABERTO TO MOVIMVGA-DATA-AVERBACAO */
                _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_AVERBACAO);

                /*" -2091- ELSE */
            }
            else
            {


                /*" -2093- MOVE ' ' TO MOVIMVGA-SIT-REGISTRO */
                _.Move(" ", MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_SIT_REGISTRO);

                /*" -2095- MOVE -1 TO VIND-DATA-AVERBACAO */
                _.Move(-1, VIND_DATA_AVERBACAO);

                /*" -2097- END-IF. */
            }


            /*" -2100- MOVE 0101 TO MOVIMVGA-COD-OPERACAO. */
            _.Move(0101, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO);

            /*" -2103- MOVE CLIENTES-COD-CLIENTE TO MOVIMVGA-COD-CLIENTE. */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_COD_CLIENTE, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_CLIENTE);

            /*" -2106- MOVE 1 TO MOVIMVGA-OCORR-ENDERECO. */
            _.Move(1, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_OCORR_ENDERECO);

            /*" -2109- MOVE ZEROS TO MOVIMVGA-OCORR-END-COBRAN. */
            _.Move(0, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_OCORR_END_COBRAN);

            /*" -2112- MOVE R3-OPCAO-COBER TO PLAVAVGA-OPCAO-COBER. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_OPCAO_COBER, PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_OPCAO_COBER);

            /*" -2115- MOVE R3-COD-PLANO TO PLAVAVGA-COD-PLANO. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_COD_PLANO, PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_COD_PLANO);

            /*" -2119- MOVE R3-NUM-PROPOSTA TO PROPOVA-NUM-CERTIFICADO MOVIMVGA-NUM-CERTIFICADO. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_NUM_PROPOSTA, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_NUM_CERTIFICADO);

            /*" -2122- MOVE MOVIMVGA-DATA-NASCIMENTO TO WS-DATA-INICIAL. */
            _.Move(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_NASCIMENTO, FILLER_5.WS_DATA_INICIAL);

            /*" -2125- MOVE MOVIMVGA-DATA-MOVIMENTO TO WS-DATA-FINAL. */
            _.Move(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_MOVIMENTO, FILLER_5.WS_DATA_FINAL);

            /*" -2128- COMPUTE PROPOVA-IDADE = WS-ANO-FIM - WS-ANO-INI. */
            PROPOVA.DCLPROPOSTAS_VA.PROPOVA_IDADE.Value = FILLER_5.WS_DATA_FINAL.WS_ANO_FIM - FILLER_5.WS_DATA_INICIAL.WS_ANO_INI;

            /*" -2129- IF WS-MES-INI GREATER WS-MES-FIM */

            if (FILLER_5.WS_DATA_INICIAL.WS_MES_INI > FILLER_5.WS_DATA_FINAL.WS_MES_FIM)
            {

                /*" -2130- SUBTRACT 1 FROM PROPOVA-IDADE */
                PROPOVA.DCLPROPOSTAS_VA.PROPOVA_IDADE.Value = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_IDADE - 1;

                /*" -2131- ELSE */
            }
            else
            {


                /*" -2132- IF WS-MES-INI EQUAL WS-MES-FIM */

                if (FILLER_5.WS_DATA_INICIAL.WS_MES_INI == FILLER_5.WS_DATA_FINAL.WS_MES_FIM)
                {

                    /*" -2133- IF WS-DIA-INI GREATER WS-DIA-FIM */

                    if (FILLER_5.WS_DATA_INICIAL.WS_DIA_INI > FILLER_5.WS_DATA_FINAL.WS_DIA_FIM)
                    {

                        /*" -2135- SUBTRACT 1 FROM PROPOVA-IDADE. */
                        PROPOVA.DCLPROPOSTAS_VA.PROPOVA_IDADE.Value = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_IDADE - 1;
                    }

                }

            }


            /*" -2137- PERFORM R3350-00-SELECT-PLANOS. */

            R3350_00_SELECT_PLANOS_SECTION();

            /*" -2138- MOVE PLAVAVGA-IMPINVPERM TO MOVIMVGA-IMP-INVPERM-ATU. */
            _.Move(PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_IMPINVPERM, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_INVPERM_ATU);

            /*" -2140- MOVE PLAVAVGA-IMPMORACID TO MOVIMVGA-IMP-MORACID-ATU. */
            _.Move(PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_IMPMORACID, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_MORACID_ATU);

            /*" -2141- MOVE PLAVAVGA-PRMVG TO MOVIMVGA-PRM-VG-ATU */
            _.Move(PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_PRMVG, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PRM_VG_ATU);

            /*" -2143- MOVE PLAVAVGA-PRMAP TO MOVIMVGA-PRM-AP-ATU */
            _.Move(PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_PRMAP, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PRM_AP_ATU);

            /*" -2144- MOVE CONDITEC-QTD-SAL-MORNATU TO MOVIMVGA-QTD-SAL-MORNATU. */
            _.Move(CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_QTD_SAL_MORNATU, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_QTD_SAL_MORNATU);

            /*" -2145- MOVE CONDITEC-QTD-SAL-MORACID TO MOVIMVGA-QTD-SAL-MORACID. */
            _.Move(CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_QTD_SAL_MORACID, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_QTD_SAL_MORACID);

            /*" -2146- MOVE CONDITEC-QTD-SAL-INVPERM TO MOVIMVGA-QTD-SAL-INVPERM. */
            _.Move(CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_QTD_SAL_INVPERM, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_QTD_SAL_INVPERM);

            /*" -2147- MOVE CONDITEC-TAXA-AP-MORACID TO MOVIMVGA-TAXA-AP-MORACID. */
            _.Move(CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_TAXA_AP_MORACID, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_TAXA_AP_MORACID);

            /*" -2148- MOVE CONDITEC-TAXA-AP-INVPERM TO MOVIMVGA-TAXA-AP-INVPERM. */
            _.Move(CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_TAXA_AP_INVPERM, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_TAXA_AP_INVPERM);

            /*" -2149- MOVE CONDITEC-TAXA-AP-AMDS TO MOVIMVGA-TAXA-AP-AMDS. */
            _.Move(CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_TAXA_AP_AMDS, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_TAXA_AP_AMDS);

            /*" -2150- MOVE CONDITEC-TAXA-AP-DH TO MOVIMVGA-TAXA-AP-DH. */
            _.Move(CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_TAXA_AP_DH, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_TAXA_AP_DH);

            /*" -2151- MOVE CONDITEC-TAXA-AP-DIT TO MOVIMVGA-TAXA-AP-DIT. */
            _.Move(CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_TAXA_AP_DIT, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_TAXA_AP_DIT);

            /*" -2152- MOVE 1 TO MOVIMVGA-FAIXA. */
            _.Move(1, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_FAIXA);

            /*" -2153- MOVE ZEROS TO MOVIMVGA-TAXA-VG. */
            _.Move(0, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_TAXA_VG);

            /*" -2154- MOVE SUBGVGAP-NUM-APOLICE TO MOVIMVGA-NUM-APOLICE. */
            _.Move(SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_NUM_APOLICE, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_NUM_APOLICE);

            /*" -2155- MOVE SUBGVGAP-COD-SUBGRUPO TO MOVIMVGA-COD-SUBGRUPO. */
            _.Move(SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_SUBGRUPO, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_SUBGRUPO);

            /*" -2157- MOVE SUBGVGAP-COD-FONTE TO MOVIMVGA-COD-FONTE. */
            _.Move(SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_FONTE, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_FONTE);

            /*" -2158- IF WHOST-COD-FONTE-ANT NOT EQUAL MOVIMVGA-COD-FONTE */

            if (WHOST_COD_FONTE_ANT != MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_FONTE)
            {

                /*" -2159- IF MOVIMVGA-COD-FONTE NOT EQUAL ZEROS */

                if (MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_FONTE != 00)
                {

                    /*" -2160- PERFORM R8040-00-UPDATE-FONTES */

                    R8040_00_UPDATE_FONTES_SECTION();

                    /*" -2161- PERFORM R8030-00-SELECT-FONTES */

                    R8030_00_SELECT_FONTES_SECTION();

                    /*" -2162- ELSE */
                }
                else
                {


                    /*" -2163- MOVE MOVIMVGA-COD-FONTE TO WHOST-COD-FONTE-ANT */
                    _.Move(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_FONTE, WHOST_COD_FONTE_ANT);

                    /*" -2164- PERFORM R8030-00-SELECT-FONTES */

                    R8030_00_SELECT_FONTES_SECTION();

                    /*" -2165- END-IF */
                }


                /*" -2167- END-IF. */
            }


            /*" -2168- MOVE '1' TO MOVIMVGA-TIPO-SEGURADO. */
            _.Move("1", MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_TIPO_SEGURADO);

            /*" -2169- MOVE '1' TO MOVIMVGA-TIPO-INCLUSAO. */
            _.Move("1", MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_TIPO_INCLUSAO);

            /*" -2170- MOVE ZEROS TO MOVIMVGA-COD-AGENCIADOR. */
            _.Move(0, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_AGENCIADOR);

            /*" -2171- MOVE 0 TO MOVIMVGA-COD-CORRETOR. */
            _.Move(0, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_CORRETOR);

            /*" -2172- MOVE 0 TO MOVIMVGA-COD-PLANOVGAP. */
            _.Move(0, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_PLANOVGAP);

            /*" -2173- MOVE 0 TO MOVIMVGA-COD-PLANOAP. */
            _.Move(0, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_PLANOAP);

            /*" -2174- MOVE 'N' TO MOVIMVGA-AUTOR-AUM-AUTOMAT. */
            _.Move("N", MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_AUTOR_AUM_AUTOMAT);

            /*" -2175- MOVE 'N' TO MOVIMVGA-TIPO-BENEFICIARIO. */
            _.Move("N", MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_TIPO_BENEFICIARIO);

            /*" -2176- MOVE SUBGVGAP-PERI-FATURAMENTO TO MOVIMVGA-PERI-PAGAMENTO. */
            _.Move(SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_PERI_FATURAMENTO, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PERI_PAGAMENTO);

            /*" -2177- MOVE SUBGVGAP-PERI-RENOVACAO TO MOVIMVGA-PERI-RENOVACAO. */
            _.Move(SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_PERI_RENOVACAO, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PERI_RENOVACAO);

            /*" -2178- MOVE ' ' TO MOVIMVGA-COD-OCUPACAO. */
            _.Move(" ", MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OCUPACAO);

            /*" -2179- MOVE ' ' TO MOVIMVGA-ESTADO-CIVIL. */
            _.Move(" ", MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_ESTADO_CIVIL);

            /*" -2180- MOVE CLIENTES-IDE-SEXO TO MOVIMVGA-IDE-SEXO. */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_IDE_SEXO, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IDE_SEXO);

            /*" -2181- MOVE 0 TO MOVIMVGA-COD-PROFISSAO. */
            _.Move(0, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_PROFISSAO);

            /*" -2182- MOVE ' ' TO MOVIMVGA-NATURALIDADE. */
            _.Move(" ", MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_NATURALIDADE);

            /*" -2183- MOVE SUBGVGAP-BCO-COBRANCA TO MOVIMVGA-BCO-COBRANCA. */
            _.Move(SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_BCO_COBRANCA, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_BCO_COBRANCA);

            /*" -2184- MOVE SUBGVGAP-AGE-COBRANCA TO MOVIMVGA-AGE-COBRANCA. */
            _.Move(SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_AGE_COBRANCA, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_AGE_COBRANCA);

            /*" -2185- MOVE SUBGVGAP-DAC-COBRANCA TO MOVIMVGA-DAC-COBRANCA. */
            _.Move(SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_DAC_COBRANCA, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DAC_COBRANCA);

            /*" -2186- MOVE ZEROS TO MOVIMVGA-NUM-MATRICULA. */
            _.Move(0, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_NUM_MATRICULA);

            /*" -2187- MOVE 0 TO MOVIMVGA-NUM-CTA-CORRENTE. */
            _.Move(0, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_NUM_CTA_CORRENTE);

            /*" -2188- MOVE 0 TO MOVIMVGA-DAC-CTA-CORRENTE. */
            _.Move(0, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DAC_CTA_CORRENTE);

            /*" -2189- MOVE 0 TO MOVIMVGA-VAL-SALARIO. */
            _.Move(0, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_VAL_SALARIO);

            /*" -2190- MOVE ' ' TO MOVIMVGA-TIPO-SALARIO. */
            _.Move(" ", MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_TIPO_SALARIO);

            /*" -2191- MOVE SUBGVGAP-TIPO-PLANO TO MOVIMVGA-TIPO-PLANO. */
            _.Move(SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_TIPO_PLANO, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_TIPO_PLANO);

            /*" -2192- MOVE SUBGVGAP-PCT-CONJUGE-VG TO MOVIMVGA-PCT-CONJUGE-VG. */
            _.Move(SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_PCT_CONJUGE_VG, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PCT_CONJUGE_VG);

            /*" -2193- MOVE SUBGVGAP-PCT-CONJUGE-AP TO MOVIMVGA-PCT-CONJUGE-AP. */
            _.Move(SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_PCT_CONJUGE_AP, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PCT_CONJUGE_AP);

            /*" -2194- MOVE 0 TO MOVIMVGA-IMP-MORNATU-ANT. */
            _.Move(0, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_MORNATU_ANT);

            /*" -2195- MOVE 0 TO MOVIMVGA-IMP-MORACID-ANT. */
            _.Move(0, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_MORACID_ANT);

            /*" -2196- MOVE 0 TO MOVIMVGA-IMP-INVPERM-ANT. */
            _.Move(0, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_INVPERM_ANT);

            /*" -2197- MOVE 0 TO MOVIMVGA-IMP-AMDS-ANT. */
            _.Move(0, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_AMDS_ANT);

            /*" -2198- MOVE 0 TO MOVIMVGA-IMP-DH-ANT. */
            _.Move(0, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_DH_ANT);

            /*" -2199- MOVE 0 TO MOVIMVGA-IMP-DIT-ANT. */
            _.Move(0, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_DIT_ANT);

            /*" -2200- MOVE 0 TO MOVIMVGA-PRM-VG-ANT. */
            _.Move(0, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PRM_VG_ANT);

            /*" -2201- MOVE 0 TO MOVIMVGA-PRM-AP-ANT. */
            _.Move(0, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PRM_AP_ANT);

            /*" -2202- MOVE SISTEMAS-DATA-MOV-ABERTO TO MOVIMVGA-DATA-OPERACAO. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_OPERACAO);

            /*" -2203- MOVE SPACES TO MOVIMVGA-DATA-INCLUSAO. */
            _.Move("", MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_INCLUSAO);

            /*" -2204- MOVE -1 TO VIND-DATA-INCLUSAO. */
            _.Move(-1, VIND_DATA_INCLUSAO);

            /*" -2205- MOVE 0 TO MOVIMVGA-COD-SUBGRUPO-TRANS. */
            _.Move(0, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_SUBGRUPO_TRANS);

            /*" -2206- MOVE '1' TO MOVIMVGA-SIT-REGISTRO. */
            _.Move("1", MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_SIT_REGISTRO);

            /*" -2208- MOVE +0 TO VIND-DATA-NASCIMENTO. */
            _.Move(+0, VIND_DATA_NASCIMENTO);

            /*" -2209- MOVE 'VG1650B' TO MOVIMVGA-COD-USUARIO. */
            _.Move("VG1650B", MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_USUARIO);

            /*" -2210- MOVE 0 TO MOVIMVGA-IMP-DH-ANT. */
            _.Move(0, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_DH_ANT);

            /*" -2212- MOVE 0 TO MOVIMVGA-IMP-DH-ATU. */
            _.Move(0, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_DH_ATU);

            /*" -2213- IF SUBGVGAP-TIPO-PLANO = '1' OR '4' */

            if (SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_TIPO_PLANO.In("1", "4"))
            {

                /*" -2215- MOVE 0 TO MOVIMVGA-TAXA-VG */
                _.Move(0, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_TAXA_VG);

                /*" -2216- ELSE */
            }
            else
            {


                /*" -2218- MOVE 0 TO MOVIMVGA-TAXA-VG */
                _.Move(0, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_TAXA_VG);

                /*" -2220- END-IF. */
            }


            /*" -2221- MOVE -1 TO VIND-COD-EMPRESA. */
            _.Move(-1, VIND_COD_EMPRESA);

            /*" -2222- MOVE 'REDE-SIM' TO MOVIMVGA-LOT-EMP-SEGURADO. */
            _.Move("REDE-SIM", MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_LOT_EMP_SEGURADO);

            /*" -2223- MOVE SPACES TO MOVIMVGA-DATA-FATURA. */
            _.Move("", MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_FATURA);

            /*" -2225- MOVE -1 TO VIND-DATA-FATURA. */
            _.Move(-1, VIND_DATA_FATURA);

            /*" -2225- MOVE '3302' TO WNR-EXEC-SQL. */
            _.Move("3302", REG_LEITURA.FILLER_16.WABEND.WNR_EXEC_SQL);

            /*" -0- FLUXCONTROL_PERFORM R3300_10_INSERT_MOVIMVGAP */

            R3300_10_INSERT_MOVIMVGAP();

        }

        [StopWatch]
        /*" R3300-10-INSERT-MOVIMVGAP */
        private void R3300_10_INSERT_MOVIMVGAP(bool isPerform = false)
        {
            /*" -2231- ADD 1 TO FONTES-ULT-PROP-AUTOMAT */
            FONTES.DCLFONTES.FONTES_ULT_PROP_AUTOMAT.Value = FONTES.DCLFONTES.FONTES_ULT_PROP_AUTOMAT + 1;

            /*" -2233- MOVE FONTES-ULT-PROP-AUTOMAT TO MOVIMVGA-NUM-PROPOSTA */
            _.Move(FONTES.DCLFONTES.FONTES_ULT_PROP_AUTOMAT, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_NUM_PROPOSTA);

            /*" -2387- PERFORM R3300_10_INSERT_MOVIMVGAP_DB_INSERT_1 */

            R3300_10_INSERT_MOVIMVGAP_DB_INSERT_1();

            /*" -2390- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -2391- IF SQLCODE EQUAL -803 */

                if (DB.SQLCODE == -803)
                {

                    /*" -2392- GO TO R3300-10-INSERT-MOVIMVGAP */
                    new Task(() => R3300_10_INSERT_MOVIMVGAP()).RunSynchronously(); //GOTO
                    return;//Recursividade detectada, cuidado...

                    /*" -2393- ELSE */
                }
                else
                {


                    /*" -2395- DISPLAY 'VG1650B - PROBLEMAS NA INCLUSAO MOVIMVGA ' MOVIMVGA-NUM-CERTIFICADO */
                    _.Display($"VG1650B - PROBLEMAS NA INCLUSAO MOVIMVGA {MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_NUM_CERTIFICADO}");

                    /*" -2396- DISPLAY 'DTAV ' MOVIMVGA-DATA-AVERBACAO */
                    _.Display($"DTAV {MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_AVERBACAO}");

                    /*" -2397- DISPLAY 'DTAD ' MOVIMVGA-DATA-ADMISSAO */
                    _.Display($"DTAD {MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_ADMISSAO}");

                    /*" -2398- DISPLAY 'DTIN ' MOVIMVGA-DATA-INCLUSAO */
                    _.Display($"DTIN {MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_INCLUSAO}");

                    /*" -2399- DISPLAY 'DTNA ' MOVIMVGA-DATA-NASCIMENTO */
                    _.Display($"DTNA {MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_NASCIMENTO}");

                    /*" -2400- DISPLAY 'DTFT ' MOVIMVGA-DATA-FATURA */
                    _.Display($"DTFT {MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_FATURA}");

                    /*" -2401- DISPLAY 'DTRF ' MOVIMVGA-DATA-REFERENCIA */
                    _.Display($"DTRF {MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_REFERENCIA}");

                    /*" -2402- DISPLAY 'DTMO ' MOVIMVGA-DATA-MOVIMENTO */
                    _.Display($"DTMO {MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_MOVIMENTO}");

                    /*" -2403- DISPLAY 'APOL ' MOVIMVGA-NUM-APOLICE */
                    _.Display($"APOL {MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_NUM_APOLICE}");

                    /*" -2404- DISPLAY 'SUBG ' MOVIMVGA-COD-SUBGRUPO */
                    _.Display($"SUBG {MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_SUBGRUPO}");

                    /*" -2405- DISPLAY 'FONT ' MOVIMVGA-COD-FONTE */
                    _.Display($"FONT {MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_FONTE}");

                    /*" -2406- DISPLAY 'PROP ' MOVIMVGA-NUM-PROPOSTA */
                    _.Display($"PROP {MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_NUM_PROPOSTA}");

                    /*" -2407- DISPLAY 'TSEG ' MOVIMVGA-TIPO-SEGURADO */
                    _.Display($"TSEG {MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_TIPO_SEGURADO}");

                    /*" -2408- DISPLAY 'CERT ' MOVIMVGA-NUM-CERTIFICADO */
                    _.Display($"CERT {MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_NUM_CERTIFICADO}");

                    /*" -2410- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -2410- ADD 1 TO AC-GRA-MVGAP. */
            FILLER_5.AC_GRA_MVGAP.Value = FILLER_5.AC_GRA_MVGAP + 1;

        }

        [StopWatch]
        /*" R3300-10-INSERT-MOVIMVGAP-DB-INSERT-1 */
        public void R3300_10_INSERT_MOVIMVGAP_DB_INSERT_1()
        {
            /*" -2387- EXEC SQL INSERT INTO SEGUROS.MOVIMENTO_VGAP ( NUM_APOLICE, COD_SUBGRUPO, COD_FONTE, NUM_PROPOSTA, TIPO_SEGURADO, NUM_CERTIFICADO, DAC_CERTIFICADO, TIPO_INCLUSAO, COD_CLIENTE, COD_AGENCIADOR, COD_CORRETOR, COD_PLANOVGAP, COD_PLANOAP, FAIXA, AUTOR_AUM_AUTOMAT, TIPO_BENEFICIARIO, PERI_PAGAMENTO, PERI_RENOVACAO, COD_OCUPACAO, ESTADO_CIVIL, IDE_SEXO, COD_PROFISSAO, NATURALIDADE, OCORR_ENDERECO, OCORR_END_COBRAN, BCO_COBRANCA, AGE_COBRANCA, DAC_COBRANCA, NUM_MATRICULA, NUM_CTA_CORRENTE, DAC_CTA_CORRENTE, VAL_SALARIO, TIPO_SALARIO, TIPO_PLANO, PCT_CONJUGE_VG, PCT_CONJUGE_AP, QTD_SAL_MORNATU, QTD_SAL_MORACID, QTD_SAL_INVPERM, TAXA_AP_MORACID, TAXA_AP_INVPERM, TAXA_AP_AMDS, TAXA_AP_DH, TAXA_AP_DIT, TAXA_VG, IMP_MORNATU_ANT, IMP_MORNATU_ATU, IMP_MORACID_ANT, IMP_MORACID_ATU, IMP_INVPERM_ANT, IMP_INVPERM_ATU, IMP_AMDS_ANT, IMP_AMDS_ATU, IMP_DH_ANT, IMP_DH_ATU, IMP_DIT_ANT, IMP_DIT_ATU, PRM_VG_ANT, PRM_VG_ATU, PRM_AP_ANT, PRM_AP_ATU, COD_OPERACAO, DATA_OPERACAO, COD_SUBGRUPO_TRANS, SIT_REGISTRO, COD_USUARIO, DATA_AVERBACAO, DATA_ADMISSAO, DATA_INCLUSAO, DATA_NASCIMENTO, DATA_FATURA, DATA_REFERENCIA, DATA_MOVIMENTO, COD_EMPRESA, LOT_EMP_SEGURADO) VALUES (:MOVIMVGA-NUM-APOLICE, :MOVIMVGA-COD-SUBGRUPO, :MOVIMVGA-COD-FONTE, :MOVIMVGA-NUM-PROPOSTA, :MOVIMVGA-TIPO-SEGURADO, :MOVIMVGA-NUM-CERTIFICADO, :MOVIMVGA-DAC-CERTIFICADO, :MOVIMVGA-TIPO-INCLUSAO, :MOVIMVGA-COD-CLIENTE, :MOVIMVGA-COD-AGENCIADOR, :MOVIMVGA-COD-CORRETOR, :MOVIMVGA-COD-PLANOVGAP, :MOVIMVGA-COD-PLANOAP, :MOVIMVGA-FAIXA, :MOVIMVGA-AUTOR-AUM-AUTOMAT, :MOVIMVGA-TIPO-BENEFICIARIO, :MOVIMVGA-PERI-PAGAMENTO, :MOVIMVGA-PERI-RENOVACAO, :MOVIMVGA-COD-OCUPACAO, :MOVIMVGA-ESTADO-CIVIL, :MOVIMVGA-IDE-SEXO, :MOVIMVGA-COD-PROFISSAO, :MOVIMVGA-NATURALIDADE, :MOVIMVGA-OCORR-ENDERECO, :MOVIMVGA-OCORR-END-COBRAN, :MOVIMVGA-BCO-COBRANCA, :MOVIMVGA-AGE-COBRANCA, :MOVIMVGA-DAC-COBRANCA, :MOVIMVGA-NUM-MATRICULA, :MOVIMVGA-NUM-CTA-CORRENTE, :MOVIMVGA-DAC-CTA-CORRENTE, :MOVIMVGA-VAL-SALARIO, :MOVIMVGA-TIPO-SALARIO, :MOVIMVGA-TIPO-PLANO, :MOVIMVGA-PCT-CONJUGE-VG, :MOVIMVGA-PCT-CONJUGE-AP, :MOVIMVGA-QTD-SAL-MORNATU, :MOVIMVGA-QTD-SAL-MORACID, :MOVIMVGA-QTD-SAL-INVPERM, :MOVIMVGA-TAXA-AP-MORACID, :MOVIMVGA-TAXA-AP-INVPERM, :MOVIMVGA-TAXA-AP-AMDS, :MOVIMVGA-TAXA-AP-DH, :MOVIMVGA-TAXA-AP-DIT, :MOVIMVGA-TAXA-VG, :MOVIMVGA-IMP-MORNATU-ANT, :MOVIMVGA-IMP-MORNATU-ATU, :MOVIMVGA-IMP-MORACID-ANT, :MOVIMVGA-IMP-MORACID-ATU, :MOVIMVGA-IMP-INVPERM-ANT, :MOVIMVGA-IMP-INVPERM-ATU, :MOVIMVGA-IMP-AMDS-ANT, :MOVIMVGA-IMP-AMDS-ATU, :MOVIMVGA-IMP-DH-ANT, :MOVIMVGA-IMP-DH-ATU, :MOVIMVGA-IMP-DIT-ANT, :MOVIMVGA-IMP-DIT-ATU, :MOVIMVGA-PRM-VG-ANT, :MOVIMVGA-PRM-VG-ATU, :MOVIMVGA-PRM-AP-ANT, :MOVIMVGA-PRM-AP-ATU, :MOVIMVGA-COD-OPERACAO, :MOVIMVGA-DATA-OPERACAO, :MOVIMVGA-COD-SUBGRUPO-TRANS, :MOVIMVGA-SIT-REGISTRO, :MOVIMVGA-COD-USUARIO, :MOVIMVGA-DATA-AVERBACAO:VIND-DATA-AVERBACAO, :MOVIMVGA-DATA-ADMISSAO:VIND-DATA-ADMISSAO, :MOVIMVGA-DATA-INCLUSAO:VIND-DATA-INCLUSAO, :MOVIMVGA-DATA-NASCIMENTO:VIND-DATA-NASCIMENTO, :MOVIMVGA-DATA-FATURA:VIND-DATA-FATURA, :MOVIMVGA-DATA-REFERENCIA, :MOVIMVGA-DATA-MOVIMENTO, :MOVIMVGA-COD-EMPRESA:VIND-COD-EMPRESA, :MOVIMVGA-LOT-EMP-SEGURADO:VIND-LOT-EMP-SEGURADO) END-EXEC. */

            var r3300_10_INSERT_MOVIMVGAP_DB_INSERT_1_Insert1 = new R3300_10_INSERT_MOVIMVGAP_DB_INSERT_1_Insert1()
            {
                MOVIMVGA_NUM_APOLICE = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_NUM_APOLICE.ToString(),
                MOVIMVGA_COD_SUBGRUPO = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_SUBGRUPO.ToString(),
                MOVIMVGA_COD_FONTE = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_FONTE.ToString(),
                MOVIMVGA_NUM_PROPOSTA = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_NUM_PROPOSTA.ToString(),
                MOVIMVGA_TIPO_SEGURADO = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_TIPO_SEGURADO.ToString(),
                MOVIMVGA_NUM_CERTIFICADO = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_NUM_CERTIFICADO.ToString(),
                MOVIMVGA_DAC_CERTIFICADO = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DAC_CERTIFICADO.ToString(),
                MOVIMVGA_TIPO_INCLUSAO = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_TIPO_INCLUSAO.ToString(),
                MOVIMVGA_COD_CLIENTE = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_CLIENTE.ToString(),
                MOVIMVGA_COD_AGENCIADOR = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_AGENCIADOR.ToString(),
                MOVIMVGA_COD_CORRETOR = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_CORRETOR.ToString(),
                MOVIMVGA_COD_PLANOVGAP = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_PLANOVGAP.ToString(),
                MOVIMVGA_COD_PLANOAP = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_PLANOAP.ToString(),
                MOVIMVGA_FAIXA = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_FAIXA.ToString(),
                MOVIMVGA_AUTOR_AUM_AUTOMAT = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_AUTOR_AUM_AUTOMAT.ToString(),
                MOVIMVGA_TIPO_BENEFICIARIO = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_TIPO_BENEFICIARIO.ToString(),
                MOVIMVGA_PERI_PAGAMENTO = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PERI_PAGAMENTO.ToString(),
                MOVIMVGA_PERI_RENOVACAO = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PERI_RENOVACAO.ToString(),
                MOVIMVGA_COD_OCUPACAO = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OCUPACAO.ToString(),
                MOVIMVGA_ESTADO_CIVIL = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_ESTADO_CIVIL.ToString(),
                MOVIMVGA_IDE_SEXO = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IDE_SEXO.ToString(),
                MOVIMVGA_COD_PROFISSAO = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_PROFISSAO.ToString(),
                MOVIMVGA_NATURALIDADE = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_NATURALIDADE.ToString(),
                MOVIMVGA_OCORR_ENDERECO = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_OCORR_ENDERECO.ToString(),
                MOVIMVGA_OCORR_END_COBRAN = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_OCORR_END_COBRAN.ToString(),
                MOVIMVGA_BCO_COBRANCA = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_BCO_COBRANCA.ToString(),
                MOVIMVGA_AGE_COBRANCA = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_AGE_COBRANCA.ToString(),
                MOVIMVGA_DAC_COBRANCA = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DAC_COBRANCA.ToString(),
                MOVIMVGA_NUM_MATRICULA = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_NUM_MATRICULA.ToString(),
                MOVIMVGA_NUM_CTA_CORRENTE = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_NUM_CTA_CORRENTE.ToString(),
                MOVIMVGA_DAC_CTA_CORRENTE = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DAC_CTA_CORRENTE.ToString(),
                MOVIMVGA_VAL_SALARIO = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_VAL_SALARIO.ToString(),
                MOVIMVGA_TIPO_SALARIO = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_TIPO_SALARIO.ToString(),
                MOVIMVGA_TIPO_PLANO = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_TIPO_PLANO.ToString(),
                MOVIMVGA_PCT_CONJUGE_VG = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PCT_CONJUGE_VG.ToString(),
                MOVIMVGA_PCT_CONJUGE_AP = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PCT_CONJUGE_AP.ToString(),
                MOVIMVGA_QTD_SAL_MORNATU = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_QTD_SAL_MORNATU.ToString(),
                MOVIMVGA_QTD_SAL_MORACID = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_QTD_SAL_MORACID.ToString(),
                MOVIMVGA_QTD_SAL_INVPERM = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_QTD_SAL_INVPERM.ToString(),
                MOVIMVGA_TAXA_AP_MORACID = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_TAXA_AP_MORACID.ToString(),
                MOVIMVGA_TAXA_AP_INVPERM = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_TAXA_AP_INVPERM.ToString(),
                MOVIMVGA_TAXA_AP_AMDS = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_TAXA_AP_AMDS.ToString(),
                MOVIMVGA_TAXA_AP_DH = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_TAXA_AP_DH.ToString(),
                MOVIMVGA_TAXA_AP_DIT = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_TAXA_AP_DIT.ToString(),
                MOVIMVGA_TAXA_VG = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_TAXA_VG.ToString(),
                MOVIMVGA_IMP_MORNATU_ANT = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_MORNATU_ANT.ToString(),
                MOVIMVGA_IMP_MORNATU_ATU = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_MORNATU_ATU.ToString(),
                MOVIMVGA_IMP_MORACID_ANT = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_MORACID_ANT.ToString(),
                MOVIMVGA_IMP_MORACID_ATU = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_MORACID_ATU.ToString(),
                MOVIMVGA_IMP_INVPERM_ANT = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_INVPERM_ANT.ToString(),
                MOVIMVGA_IMP_INVPERM_ATU = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_INVPERM_ATU.ToString(),
                MOVIMVGA_IMP_AMDS_ANT = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_AMDS_ANT.ToString(),
                MOVIMVGA_IMP_AMDS_ATU = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_AMDS_ATU.ToString(),
                MOVIMVGA_IMP_DH_ANT = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_DH_ANT.ToString(),
                MOVIMVGA_IMP_DH_ATU = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_DH_ATU.ToString(),
                MOVIMVGA_IMP_DIT_ANT = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_DIT_ANT.ToString(),
                MOVIMVGA_IMP_DIT_ATU = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_DIT_ATU.ToString(),
                MOVIMVGA_PRM_VG_ANT = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PRM_VG_ANT.ToString(),
                MOVIMVGA_PRM_VG_ATU = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PRM_VG_ATU.ToString(),
                MOVIMVGA_PRM_AP_ANT = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PRM_AP_ANT.ToString(),
                MOVIMVGA_PRM_AP_ATU = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PRM_AP_ATU.ToString(),
                MOVIMVGA_COD_OPERACAO = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO.ToString(),
                MOVIMVGA_DATA_OPERACAO = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_OPERACAO.ToString(),
                MOVIMVGA_COD_SUBGRUPO_TRANS = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_SUBGRUPO_TRANS.ToString(),
                MOVIMVGA_SIT_REGISTRO = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_SIT_REGISTRO.ToString(),
                MOVIMVGA_COD_USUARIO = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_USUARIO.ToString(),
                MOVIMVGA_DATA_AVERBACAO = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_AVERBACAO.ToString(),
                VIND_DATA_AVERBACAO = VIND_DATA_AVERBACAO.ToString(),
                MOVIMVGA_DATA_ADMISSAO = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_ADMISSAO.ToString(),
                VIND_DATA_ADMISSAO = VIND_DATA_ADMISSAO.ToString(),
                MOVIMVGA_DATA_INCLUSAO = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_INCLUSAO.ToString(),
                VIND_DATA_INCLUSAO = VIND_DATA_INCLUSAO.ToString(),
                MOVIMVGA_DATA_NASCIMENTO = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_NASCIMENTO.ToString(),
                VIND_DATA_NASCIMENTO = VIND_DATA_NASCIMENTO.ToString(),
                MOVIMVGA_DATA_FATURA = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_FATURA.ToString(),
                VIND_DATA_FATURA = VIND_DATA_FATURA.ToString(),
                MOVIMVGA_DATA_REFERENCIA = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_REFERENCIA.ToString(),
                MOVIMVGA_DATA_MOVIMENTO = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_MOVIMENTO.ToString(),
                MOVIMVGA_COD_EMPRESA = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_EMPRESA.ToString(),
                VIND_COD_EMPRESA = VIND_COD_EMPRESA.ToString(),
                MOVIMVGA_LOT_EMP_SEGURADO = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_LOT_EMP_SEGURADO.ToString(),
                VIND_LOT_EMP_SEGURADO = VIND_LOT_EMP_SEGURADO.ToString(),
            };

            R3300_10_INSERT_MOVIMVGAP_DB_INSERT_1_Insert1.Execute(r3300_10_INSERT_MOVIMVGAP_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3300_99_SAIDA*/

        [StopWatch]
        /*" R3350-00-SELECT-PLANOS-SECTION */
        private void R3350_00_SELECT_PLANOS_SECTION()
        {
            /*" -2423- MOVE 'R3350-00-SELECT-PLANOS ' TO PARAGRAFO. */
            _.Move("R3350-00-SELECT-PLANOS ", REG_LEITURA.FILLER_16.WABEND.PARAGRAFO);

            /*" -2427- MOVE '3350' TO WNR-EXEC-SQL. */
            _.Move("3350", REG_LEITURA.FILLER_16.WABEND.WNR_EXEC_SQL);

            /*" -2429- MOVE 'S' TO WTEM-PLANO-VGAP. */
            _.Move("S", REG_LEITURA.FILLER_16.WTEM_PLANO_VGAP);

            /*" -2444- MOVE ZEROS TO PLAVAVGA-IMPMORNATU PLAVAVGA-IMPMORACID PLAVAVGA-IMPINVPERM PLAVAVGA-IMPAMDS PLAVAVGA-IMPDH PLAVAVGA-IMPDIT PLAVAVGA-VLPREMIOTOT PLAVAVGA-PRMVG PLAVAVGA-PRMAP PLAVAVGA-QTTITCAP PLAVAVGA-VLTITCAP PLAVAVGA-VLCUSTCAP PLAVAVGA-IMPSEGCDG PLAVAVGA-VLCUSTCDG. */
            _.Move(0, PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_IMPMORNATU, PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_IMPMORACID, PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_IMPINVPERM, PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_IMPAMDS, PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_IMPDH, PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_IMPDIT, PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_VLPREMIOTOT, PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_PRMVG, PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_PRMAP, PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_QTTITCAP, PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_VLTITCAP, PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_VLCUSTCAP, PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_IMPSEGCDG, PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_VLCUSTCDG);

            /*" -2482- PERFORM R3350_00_SELECT_PLANOS_DB_SELECT_1 */

            R3350_00_SELECT_PLANOS_DB_SELECT_1();

            /*" -2485- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2486- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2487- DISPLAY 'NAO EXISTE PLANO - PLANOS_VA_VGAP' */
                    _.Display($"NAO EXISTE PLANO - PLANOS_VA_VGAP");

                    /*" -2488- DISPLAY 'NUM_APOLICE = ' SUBGVGAP-NUM-APOLICE */
                    _.Display($"NUM_APOLICE = {SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_NUM_APOLICE}");

                    /*" -2489- DISPLAY 'CODSUBES    = ' SUBGVGAP-COD-SUBGRUPO */
                    _.Display($"CODSUBES    = {SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_SUBGRUPO}");

                    /*" -2490- DISPLAY 'OPCAO_COBER = ' PLAVAVGA-OPCAO-COBER */
                    _.Display($"OPCAO_COBER = {PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_OPCAO_COBER}");

                    /*" -2491- DISPLAY 'IDADE       = ' PROPOVA-IDADE */
                    _.Display($"IDADE       = {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_IDADE}");

                    /*" -2492- DISPLAY 'DATA        = ' MOVIMVGA-DATA-MOVIMENTO */
                    _.Display($"DATA        = {MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_MOVIMENTO}");

                    /*" -2493- DISPLAY 'PLANO       = ' PLAVAVGA-COD-PLANO */
                    _.Display($"PLANO       = {PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_COD_PLANO}");

                    /*" -2494- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2495- ELSE */
                }
                else
                {


                    /*" -2496- DISPLAY 'ERRO NO ACESSO A PLANOS_VA_VGAP' */
                    _.Display($"ERRO NO ACESSO A PLANOS_VA_VGAP");

                    /*" -2497- DISPLAY 'APOLICE.....= ' SUBGVGAP-NUM-APOLICE */
                    _.Display($"APOLICE.....= {SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_NUM_APOLICE}");

                    /*" -2498- DISPLAY 'CODSUBES....= ' SUBGVGAP-COD-SUBGRUPO */
                    _.Display($"CODSUBES....= {SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_SUBGRUPO}");

                    /*" -2499- DISPLAY 'OPCAO_COBER = ' PLAVAVGA-OPCAO-COBER */
                    _.Display($"OPCAO_COBER = {PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_OPCAO_COBER}");

                    /*" -2500- DISPLAY 'IDADE       = ' PROPOVA-IDADE */
                    _.Display($"IDADE       = {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_IDADE}");

                    /*" -2501- DISPLAY 'DATA        = ' MOVIMVGA-DATA-MOVIMENTO */
                    _.Display($"DATA        = {MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_MOVIMENTO}");

                    /*" -2502- DISPLAY 'PLANO       = ' PLAVAVGA-COD-PLANO */
                    _.Display($"PLANO       = {PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_COD_PLANO}");

                    /*" -2502- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R3350-00-SELECT-PLANOS-DB-SELECT-1 */
        public void R3350_00_SELECT_PLANOS_DB_SELECT_1()
        {
            /*" -2482- EXEC SQL SELECT IMPMORNATU, IMPMORACID, IMPINVPERM, IMPAMDS, IMPDH, IMPDIT, VLPREMIOTOT, PRMVG, PRMAP, QTTITCAP, VLTITCAP, VLCUSTCAP, IMPSEGCDG, VLCUSTCDG INTO :PLAVAVGA-IMPMORNATU, :PLAVAVGA-IMPMORACID, :PLAVAVGA-IMPINVPERM, :PLAVAVGA-IMPAMDS, :PLAVAVGA-IMPDH, :PLAVAVGA-IMPDIT, :PLAVAVGA-VLPREMIOTOT, :PLAVAVGA-PRMVG, :PLAVAVGA-PRMAP, :PLAVAVGA-QTTITCAP, :PLAVAVGA-VLTITCAP, :PLAVAVGA-VLCUSTCAP, :PLAVAVGA-IMPSEGCDG, :PLAVAVGA-VLCUSTCDG FROM SEGUROS.PLANOS_VA_VGAP WHERE NUM_APOLICE = :SUBGVGAP-NUM-APOLICE AND CODSUBES = :SUBGVGAP-COD-SUBGRUPO AND OPCAO_COBER = :PLAVAVGA-OPCAO-COBER AND :PROPOVA-IDADE BETWEEN IDADE_INICIAL AND IDADE_FINAL AND DTINIVIG <= :MOVIMVGA-DATA-MOVIMENTO AND DTTERVIG >= :MOVIMVGA-DATA-MOVIMENTO AND COD_PLANO = :PLAVAVGA-COD-PLANO END-EXEC. */

            var r3350_00_SELECT_PLANOS_DB_SELECT_1_Query1 = new R3350_00_SELECT_PLANOS_DB_SELECT_1_Query1()
            {
                MOVIMVGA_DATA_MOVIMENTO = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_MOVIMENTO.ToString(),
                SUBGVGAP_COD_SUBGRUPO = SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_SUBGRUPO.ToString(),
                SUBGVGAP_NUM_APOLICE = SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_NUM_APOLICE.ToString(),
                PLAVAVGA_OPCAO_COBER = PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_OPCAO_COBER.ToString(),
                PLAVAVGA_COD_PLANO = PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_COD_PLANO.ToString(),
                PROPOVA_IDADE = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_IDADE.ToString(),
            };

            var executed_1 = R3350_00_SELECT_PLANOS_DB_SELECT_1_Query1.Execute(r3350_00_SELECT_PLANOS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PLAVAVGA_IMPMORNATU, PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_IMPMORNATU);
                _.Move(executed_1.PLAVAVGA_IMPMORACID, PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_IMPMORACID);
                _.Move(executed_1.PLAVAVGA_IMPINVPERM, PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_IMPINVPERM);
                _.Move(executed_1.PLAVAVGA_IMPAMDS, PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_IMPAMDS);
                _.Move(executed_1.PLAVAVGA_IMPDH, PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_IMPDH);
                _.Move(executed_1.PLAVAVGA_IMPDIT, PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_IMPDIT);
                _.Move(executed_1.PLAVAVGA_VLPREMIOTOT, PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_VLPREMIOTOT);
                _.Move(executed_1.PLAVAVGA_PRMVG, PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_PRMVG);
                _.Move(executed_1.PLAVAVGA_PRMAP, PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_PRMAP);
                _.Move(executed_1.PLAVAVGA_QTTITCAP, PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_QTTITCAP);
                _.Move(executed_1.PLAVAVGA_VLTITCAP, PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_VLTITCAP);
                _.Move(executed_1.PLAVAVGA_VLCUSTCAP, PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_VLCUSTCAP);
                _.Move(executed_1.PLAVAVGA_IMPSEGCDG, PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_IMPSEGCDG);
                _.Move(executed_1.PLAVAVGA_VLCUSTCDG, PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_VLCUSTCDG);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3350_99_SAIDA*/

        [StopWatch]
        /*" R3400-00-INSERT-PROPOSTAVA-SECTION */
        private void R3400_00_INSERT_PROPOSTAVA_SECTION()
        {
            /*" -2518- MOVE 'R3400-00-INSERT-PROPOSTAVA' TO PARAGRAFO. */
            _.Move("R3400-00-INSERT-PROPOSTAVA", REG_LEITURA.FILLER_16.WABEND.PARAGRAFO);

            /*" -2521- MOVE '3' TO PROPOVA-SIT-REGISTRO. */
            _.Move("3", PROPOVA.DCLPROPOSTAS_VA.PROPOVA_SIT_REGISTRO);

            /*" -2524- MOVE 01 TO PROPOVA-NUM-PARCELA */
            _.Move(01, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_PARCELA);

            /*" -2527- MOVE PRODUVG-COD-PRODUTO TO PROPOVA-COD-PRODUTO. */
            _.Move(PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_PRODUTO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO);

            /*" -2530- MOVE MOVIMVGA-COD-CLIENTE TO PROPOVA-COD-CLIENTE. */
            _.Move(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_CLIENTE, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_CLIENTE);

            /*" -2533- MOVE 1 TO PROPOVA-OCOREND. */
            _.Move(1, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_OCOREND);

            /*" -2536- MOVE MOVIMVGA-COD-FONTE TO PROPOVA-COD-FONTE. */
            _.Move(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_FONTE, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_FONTE);

            /*" -2539- MOVE MOVIMVGA-AGE-COBRANCA TO PROPOVA-AGE-COBRANCA. */
            _.Move(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_AGE_COBRANCA, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_AGE_COBRANCA);

            /*" -2542- MOVE PLAVAVGA-OPCAO-COBER TO PROPOVA-OPCAO-COBERTURA. */
            _.Move(PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_OPCAO_COBER, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_OPCAO_COBERTURA);

            /*" -2545- MOVE ZEROS TO PROPOVA-COD-AGE-VENDEDOR. */
            _.Move(0, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_AGE_VENDEDOR);

            /*" -2548- MOVE ZEROS TO PROPOVA-OPE-CONTA-VENDEDOR. */
            _.Move(0, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_OPE_CONTA_VENDEDOR);

            /*" -2551- MOVE ZEROS TO PROPOVA-NUM-CONTA-VENDEDOR. */
            _.Move(0, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CONTA_VENDEDOR);

            /*" -2554- MOVE ZEROS TO PROPOVA-DIG-CONTA-VENDEDOR */
            _.Move(0, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DIG_CONTA_VENDEDOR);

            /*" -2557- MOVE ZEROS TO PROPOVA-NUM-MATRI-VENDEDOR */
            _.Move(0, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_MATRI_VENDEDOR);

            /*" -2560- MOVE 101 TO PROPOVA-COD-OPERACAO. */
            _.Move(101, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_OPERACAO);

            /*" -2563- MOVE R1-DESCRICAO-PROFISSAO (1:20) TO PROPOVA-PROFISSAO */
            _.Move(LBFPF011.REG_CLIENTES.R1_DESCRICAO_PROFISSAO.Substring(1, 20), PROPOVA.DCLPROPOSTAS_VA.PROPOVA_PROFISSAO);

            /*" -2566- MOVE SISTEMAS-DATA-MOV-ABERTO TO PROPOVA-DTINCLUS. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DTINCLUS);

            /*" -2569- MOVE MOVIMVGA-DATA-MOVIMENTO TO PROPOVA-DATA-MOVIMENTO. */
            _.Move(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_MOVIMENTO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DATA_MOVIMENTO);

            /*" -2572- MOVE MOVIMVGA-NUM-APOLICE TO PROPOVA-NUM-APOLICE. */
            _.Move(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_NUM_APOLICE, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE);

            /*" -2575- MOVE MOVIMVGA-COD-SUBGRUPO TO PROPOVA-COD-SUBGRUPO. */
            _.Move(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_SUBGRUPO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_SUBGRUPO);

            /*" -2578- MOVE 01 TO PROPOVA-OCORR-HISTORICO. */
            _.Move(01, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_OCORR_HISTORICO);

            /*" -2581- MOVE ZEROS TO PROPOVA-NRPRIPARATZ. */
            _.Move(0, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NRPRIPARATZ);

            /*" -2584- MOVE ZEROS TO PROPOVA-QTDPARATZ. */
            _.Move(0, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_QTDPARATZ);

            /*" -2587- MOVE '9999-12-31' TO PROPOVA-DTPROXVEN. */
            _.Move("9999-12-31", PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DTPROXVEN);

            /*" -2591- MOVE MOVIMVGA-DATA-MOVIMENTO TO PROPOVA-DATA-QUITACAO PROPOVA-DATA-VENCIMENTO. */
            _.Move(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_MOVIMENTO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DATA_QUITACAO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DATA_VENCIMENTO);

            /*" -2594- MOVE ' ' TO PROPOVA-SIT-INTERFACE. */
            _.Move(" ", PROPOVA.DCLPROPOSTAS_VA.PROPOVA_SIT_INTERFACE);

            /*" -2597- MOVE '9999-12-31' TO PROPOVA-DTFENAE. */
            _.Move("9999-12-31", PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DTFENAE);

            /*" -2600- MOVE 'VG1650B' TO PROPOVA-COD-USUARIO. */
            _.Move("VG1650B", PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_USUARIO);

            /*" -2603- MOVE CLIENTES-IDE-SEXO TO PROPOVA-IDE-SEXO. */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_IDE_SEXO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_IDE_SEXO);

            /*" -2606- MOVE CLIENTES-ESTADO-CIVIL TO PROPOVA-ESTADO-CIVIL. */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_ESTADO_CIVIL, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_ESTADO_CIVIL);

            /*" -2609- MOVE ' ' TO PROPOVA-OPCAO-MARCADA. */
            _.Move(" ", PROPOVA.DCLPROPOSTAS_VA.PROPOVA_OPCAO_MARCADA);

            /*" -2612- MOVE 0 TO VIND-COD-CRM. */
            _.Move(0, VIND_COD_CRM);

            /*" -2615- MOVE ZEROS TO PROPOVA-COD-CRM. */
            _.Move(0, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_CRM);

            /*" -2618- MOVE R3-NRMATRVEN TO PROPOVA-NUM-MATRICULA. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_NRMATRVEN, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_MATRICULA);

            /*" -2621- MOVE MOVIMVGA-NUM-PROPOSTA TO PROPOVA-NUM-PROPOSTA. */
            _.Move(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_NUM_PROPOSTA, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_PROPOSTA);

            /*" -2624- MOVE R3-DPS-TITULAR TO PROPOVA-DPS-TITULAR. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_DPS_TITULAR, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DPS_TITULAR);

            /*" -2627- MOVE 'N' TO WTEM-ERRO-IDADE. */
            _.Move("N", REG_LEITURA.FILLER_16.WTEM_ERRO_IDADE);

            /*" -2629- MOVE '3400' TO WNR-EXEC-SQL. */
            _.Move("3400", REG_LEITURA.FILLER_16.WABEND.WNR_EXEC_SQL);

            /*" -2740- PERFORM R3400_00_INSERT_PROPOSTAVA_DB_INSERT_1 */

            R3400_00_INSERT_PROPOSTAVA_DB_INSERT_1();

            /*" -2743- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -2744- IF SQLCODE EQUAL -180 */

                if (DB.SQLCODE == -180)
                {

                    /*" -2745- DISPLAY 'DATA INVALIDA NO INSERT DA PROPOSTAVA ' */
                    _.Display($"DATA INVALIDA NO INSERT DA PROPOSTAVA ");

                    /*" -2746- DISPLAY 'CERTIF ' PROPOVA-NUM-CERTIFICADO */
                    _.Display($"CERTIF {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                    /*" -2747- DISPLAY 'DTINIV ' PROPOVA-DATA-QUITACAO */
                    _.Display($"DTINIV {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DATA_QUITACAO}");

                    /*" -2748- DISPLAY 'PROX   ' PROPOVA-DTPROXVEN */
                    _.Display($"PROX   {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DTPROXVEN}");

                    /*" -2749- DISPLAY 'VENCTO ' PROPOVA-DATA-VENCIMENTO */
                    _.Display($"VENCTO {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DATA_VENCIMENTO}");

                    /*" -2750- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2751- ELSE */
                }
                else
                {


                    /*" -2752- IF SQLCODE EQUAL -803 */

                    if (DB.SQLCODE == -803)
                    {

                        /*" -2753- DISPLAY 'PROPOSTA REPETIDA  ' */
                        _.Display($"PROPOSTA REPETIDA  ");

                        /*" -2754- DISPLAY 'CERTIF ' PROPOVA-NUM-CERTIFICADO */
                        _.Display($"CERTIF {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                        /*" -2755- GO TO R9999-00-ROT-ERRO */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;

                        /*" -2756- ELSE */
                    }
                    else
                    {


                        /*" -2758- DISPLAY 'PROBLEMA INSERT DA PROPOSTAS_VA .. ' PROPOVA-NUM-CERTIFICADO ' ' SQLCODE */

                        $"PROBLEMA INSERT DA PROPOSTAS_VA .. {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO} {DB.SQLCODE}"
                        .Display();

                        /*" -2760- GO TO R9999-00-ROT-ERRO. */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;
                    }

                }

            }


            /*" -2761- IF PROPOVA-IDADE NOT GREATER 15 */

            if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_IDADE <= 15)
            {

                /*" -2762- PERFORM R3450-00-INSERT-ERRO-PROP */

                R3450_00_INSERT_ERRO_PROP_SECTION();

                /*" -2764- MOVE '3' TO PROPOVA-SIT-REGISTRO */
                _.Move("3", PROPOVA.DCLPROPOSTAS_VA.PROPOVA_SIT_REGISTRO);

                /*" -2766- END-IF. */
            }


            /*" -2766- ADD 1 TO AC-GRA-PROVA. */
            FILLER_5.AC_GRA_PROVA.Value = FILLER_5.AC_GRA_PROVA + 1;

        }

        [StopWatch]
        /*" R3400-00-INSERT-PROPOSTAVA-DB-INSERT-1 */
        public void R3400_00_INSERT_PROPOSTAVA_DB_INSERT_1()
        {
            /*" -2740- EXEC SQL INSERT INTO SEGUROS.PROPOSTAS_VA (NUM_CERTIFICADO , COD_PRODUTO , COD_CLIENTE , OCOREND , COD_FONTE , AGE_COBRANCA , OPCAO_COBERTURA , DATA_QUITACAO , COD_AGE_VENDEDOR , OPE_CONTA_VENDEDOR, NUM_CONTA_VENDEDOR, DIG_CONTA_VENDEDOR, NUM_MATRI_VENDEDOR, COD_OPERACAO , PROFISSAO , DTINCLUS , DATA_MOVIMENTO , SIT_REGISTRO , NUM_APOLICE , COD_SUBGRUPO , OCORR_HISTORICO , NRPRIPARATZ , QTDPARATZ , DTPROXVEN , NUM_PARCELA , DATA_VENCIMENTO , SIT_INTERFACE , DTFENAE , COD_USUARIO , TIMESTAMP , IDADE , IDE_SEXO , ESTADO_CIVIL , OPCAO_MARCADA , SIGLA_CRM , COD_CRM , APOS_INVALIDEZ , ASSINATURA , ACATAMENTO , NOME_ESPOSA , DTNASC_ESPOSA , PROFIS_ESPOSA , DPS_TITULAR , DPS_ESPOSA , NUM_MATRICULA , GRAU_PARENTESCO , DATA_ADMISSAO , NUM_PROPOSTA , EM_ATIVIDADE , LOC_ATIVIDADE , INFO_COMPLEMENTAR , NRMALADIR , NRCERTIFANT , COD_CCT ) VALUES (:PROPOVA-NUM-CERTIFICADO, :PROPOVA-COD-PRODUTO, :PROPOVA-COD-CLIENTE, :PROPOVA-OCOREND, :PROPOVA-COD-FONTE, :PROPOVA-AGE-COBRANCA, :PROPOVA-OPCAO-COBERTURA, :PROPOVA-DATA-QUITACAO, :PROPOVA-COD-AGE-VENDEDOR, :PROPOVA-OPE-CONTA-VENDEDOR, :PROPOVA-NUM-CONTA-VENDEDOR, :PROPOVA-DIG-CONTA-VENDEDOR, :PROPOVA-NUM-MATRI-VENDEDOR, :PROPOVA-COD-OPERACAO, :PROPOVA-PROFISSAO, :PROPOVA-DTINCLUS, :PROPOVA-DATA-MOVIMENTO, :PROPOVA-SIT-REGISTRO, :PROPOVA-NUM-APOLICE, :PROPOVA-COD-SUBGRUPO, :PROPOVA-OCORR-HISTORICO, :PROPOVA-NRPRIPARATZ, :PROPOVA-QTDPARATZ, :PROPOVA-DTPROXVEN, :PROPOVA-NUM-PARCELA, :PROPOVA-DATA-VENCIMENTO, :PROPOVA-SIT-INTERFACE, :PROPOVA-DTFENAE, :PROPOVA-COD-USUARIO, CURRENT TIMESTAMP, :PROPOVA-IDADE, :PROPOVA-IDE-SEXO, :PROPOVA-ESTADO-CIVIL, :PROPOVA-OPCAO-MARCADA, :PROPOVA-SIGLA-CRM:VIND-SIGLA-CRM, :PROPOVA-COD-CRM:VIND-COD-CRM, NULL, NULL, NULL, NULL, NULL, NULL, :PROPOVA-DPS-TITULAR, NULL, :PROPOVA-NUM-MATRICULA, NULL, NULL, :PROPOVA-NUM-PROPOSTA, NULL, NULL, NULL, NULL, NULL, NULL) END-EXEC. */

            var r3400_00_INSERT_PROPOSTAVA_DB_INSERT_1_Insert1 = new R3400_00_INSERT_PROPOSTAVA_DB_INSERT_1_Insert1()
            {
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
                PROPOVA_COD_PRODUTO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO.ToString(),
                PROPOVA_COD_CLIENTE = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_CLIENTE.ToString(),
                PROPOVA_OCOREND = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_OCOREND.ToString(),
                PROPOVA_COD_FONTE = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_FONTE.ToString(),
                PROPOVA_AGE_COBRANCA = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_AGE_COBRANCA.ToString(),
                PROPOVA_OPCAO_COBERTURA = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_OPCAO_COBERTURA.ToString(),
                PROPOVA_DATA_QUITACAO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DATA_QUITACAO.ToString(),
                PROPOVA_COD_AGE_VENDEDOR = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_AGE_VENDEDOR.ToString(),
                PROPOVA_OPE_CONTA_VENDEDOR = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_OPE_CONTA_VENDEDOR.ToString(),
                PROPOVA_NUM_CONTA_VENDEDOR = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CONTA_VENDEDOR.ToString(),
                PROPOVA_DIG_CONTA_VENDEDOR = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DIG_CONTA_VENDEDOR.ToString(),
                PROPOVA_NUM_MATRI_VENDEDOR = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_MATRI_VENDEDOR.ToString(),
                PROPOVA_COD_OPERACAO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_OPERACAO.ToString(),
                PROPOVA_PROFISSAO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_PROFISSAO.ToString(),
                PROPOVA_DTINCLUS = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DTINCLUS.ToString(),
                PROPOVA_DATA_MOVIMENTO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DATA_MOVIMENTO.ToString(),
                PROPOVA_SIT_REGISTRO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_SIT_REGISTRO.ToString(),
                PROPOVA_NUM_APOLICE = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE.ToString(),
                PROPOVA_COD_SUBGRUPO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_SUBGRUPO.ToString(),
                PROPOVA_OCORR_HISTORICO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_OCORR_HISTORICO.ToString(),
                PROPOVA_NRPRIPARATZ = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NRPRIPARATZ.ToString(),
                PROPOVA_QTDPARATZ = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_QTDPARATZ.ToString(),
                PROPOVA_DTPROXVEN = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DTPROXVEN.ToString(),
                PROPOVA_NUM_PARCELA = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_PARCELA.ToString(),
                PROPOVA_DATA_VENCIMENTO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DATA_VENCIMENTO.ToString(),
                PROPOVA_SIT_INTERFACE = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_SIT_INTERFACE.ToString(),
                PROPOVA_DTFENAE = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DTFENAE.ToString(),
                PROPOVA_COD_USUARIO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_USUARIO.ToString(),
                PROPOVA_IDADE = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_IDADE.ToString(),
                PROPOVA_IDE_SEXO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_IDE_SEXO.ToString(),
                PROPOVA_ESTADO_CIVIL = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_ESTADO_CIVIL.ToString(),
                PROPOVA_OPCAO_MARCADA = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_OPCAO_MARCADA.ToString(),
                PROPOVA_SIGLA_CRM = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_SIGLA_CRM.ToString(),
                VIND_SIGLA_CRM = VIND_SIGLA_CRM.ToString(),
                PROPOVA_COD_CRM = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_CRM.ToString(),
                VIND_COD_CRM = VIND_COD_CRM.ToString(),
                PROPOVA_DPS_TITULAR = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DPS_TITULAR.ToString(),
                PROPOVA_NUM_MATRICULA = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_MATRICULA.ToString(),
                PROPOVA_NUM_PROPOSTA = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_PROPOSTA.ToString(),
            };

            R3400_00_INSERT_PROPOSTAVA_DB_INSERT_1_Insert1.Execute(r3400_00_INSERT_PROPOSTAVA_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3400_99_SAIDA*/

        [StopWatch]
        /*" R3450-00-INSERT-ERRO-PROP-SECTION */
        private void R3450_00_INSERT_ERRO_PROP_SECTION()
        {
            /*" -2780- MOVE 'R3450-00-INSERT-ERRO-PROP' TO PARAGRAFO. */
            _.Move("R3450-00-INSERT-ERRO-PROP", REG_LEITURA.FILLER_16.WABEND.PARAGRAFO);

            /*" -2783- MOVE 'S' TO WTEM-ERRO-IDADE. */
            _.Move("S", REG_LEITURA.FILLER_16.WTEM_ERRO_IDADE);

            /*" -2787- MOVE '3450' TO WNR-EXEC-SQL. */
            _.Move("3450", REG_LEITURA.FILLER_16.WABEND.WNR_EXEC_SQL);

            /*" -2789- INITIALIZE LK-VG001-TRACE LK-VG001-TIPO-ACAO LK-VG001-NUM-CERTIFICADO LK-VG001-SEQ-CRITICA LK-VG001-IND-TP-PROPOSTA LK-VG001-NUM-CPF-CNPJ LK-VG001-COD-MSG-CRITICA LK-VG001-COD-USUARIO LK-VG001-NOM-PROGRAMA LK-VG001-STA-CRITICA LK-VG001-DES-COMPLEMENTAR LK-VG001-S-NUM-CERTIFICADO LK-VG001-S-SEQ-CRITICA LK-VG001-S-IND-TP-PROPOSTA LK-VG001-S-COD-MSG-CRITICA LK-VG001-S-DES-MSG-CRITICA LK-VG001-S-DES-ABREV-MSG-CRIT LK-VG001-S-NUM-CPF-CNPJ LK-VG001-S-NUM-PROPOSTA LK-VG001-S-VLR-IS LK-VG001-S-VLR-PREMIO LK-VG001-S-DTA-OCORRENCIA LK-VG001-S-DTA-RCAP LK-VG001-S-STA-CRITICA LK-VG001-S-DES-STA-CRITICA LK-VG001-S-DES-COMPLEMENTAR LK-VG001-S-COD-USUARIO LK-VG001-S-NOM-PROGRAMA LK-VG001-S-DTH-CADASTRAMENTO LK-VG001-S-STA-PARA LK-VG001-IND-ERRO LK-VG001-MSG-ERRO LK-VG001-NOM-TABELA LK-VG001-SQLCODE LK-VG001-SQLERRMC */
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

            /*" -2790- MOVE 'N' TO LK-VG001-TRACE */
            _.Move("N", SPVG001W.LK_VG001_TRACE);

            /*" -2791- MOVE 02 TO LK-VG001-TIPO-ACAO */
            _.Move(02, SPVG001W.LK_VG001_TIPO_ACAO);

            /*" -2792- MOVE PROPOVA-NUM-CERTIFICADO TO LK-VG001-NUM-CERTIFICADO */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO, SPVG001W.LK_VG001_NUM_CERTIFICADO);

            /*" -2793- MOVE 1005 TO LK-VG001-COD-MSG-CRITICA */
            _.Move(1005, SPVG001W.LK_VG001_COD_MSG_CRITICA);

            /*" -2794- MOVE 0 TO LK-VG001-SEQ-CRITICA */
            _.Move(0, SPVG001W.LK_VG001_SEQ_CRITICA);

            /*" -2795- MOVE 'PJ' TO LK-VG001-IND-TP-PROPOSTA */
            _.Move("PJ", SPVG001W.LK_VG001_IND_TP_PROPOSTA);

            /*" -2796- MOVE 0 TO LK-VG001-NUM-CPF-CNPJ */
            _.Move(0, SPVG001W.LK_VG001_NUM_CPF_CNPJ);

            /*" -2797- MOVE 'BATCH' TO LK-VG001-COD-USUARIO */
            _.Move("BATCH", SPVG001W.LK_VG001_COD_USUARIO);

            /*" -2798- MOVE 'VG1650B' TO LK-VG001-NOM-PROGRAMA */
            _.Move("VG1650B", SPVG001W.LK_VG001_NOM_PROGRAMA);

            /*" -2799- MOVE 'SPBVG001' TO VG001-PROGRAMA */
            _.Move("SPBVG001", SPVG001V.VG001_PROGRAMA);

            /*" -2800- MOVE SPACES TO LK-VG001-STA-CRITICA */
            _.Move("", SPVG001W.LK_VG001_STA_CRITICA);

            /*" -2801- MOVE 50 TO LK-VG001-DES-COMPLEMENTAR-L */
            _.Move(50, SPVG001W.LK_VG001_DES_COMPLEMENTAR.LK_VG001_DES_COMPLEMENTAR_L);

            /*" -2804- MOVE 'INSERCAO DE ERRO NA EMISSAO DA PROPOSTA' TO LK-VG001-DES-COMPLEMENTAR-T */
            _.Move("INSERCAO DE ERRO NA EMISSAO DA PROPOSTA", SPVG001W.LK_VG001_DES_COMPLEMENTAR.LK_VG001_DES_COMPLEMENTAR_T);

            /*" -2806- CALL VG001-PROGRAMA USING LK-VG001-TRACE LK-VG001-TIPO-ACAO LK-VG001-NUM-CERTIFICADO LK-VG001-SEQ-CRITICA LK-VG001-IND-TP-PROPOSTA LK-VG001-NUM-CPF-CNPJ LK-VG001-COD-MSG-CRITICA LK-VG001-COD-USUARIO LK-VG001-NOM-PROGRAMA LK-VG001-STA-CRITICA LK-VG001-DES-COMPLEMENTAR LK-VG001-S-NUM-CERTIFICADO LK-VG001-S-SEQ-CRITICA LK-VG001-S-IND-TP-PROPOSTA LK-VG001-S-COD-MSG-CRITICA LK-VG001-S-DES-MSG-CRITICA LK-VG001-S-DES-ABREV-MSG-CRIT LK-VG001-S-NUM-CPF-CNPJ LK-VG001-S-NUM-PROPOSTA LK-VG001-S-VLR-IS LK-VG001-S-VLR-PREMIO LK-VG001-S-DTA-OCORRENCIA LK-VG001-S-DTA-RCAP LK-VG001-S-STA-CRITICA LK-VG001-S-DES-STA-CRITICA LK-VG001-S-DES-COMPLEMENTAR LK-VG001-S-COD-USUARIO LK-VG001-S-NOM-PROGRAMA LK-VG001-S-DTH-CADASTRAMENTO LK-VG001-S-STA-PARA LK-VG001-IND-ERRO LK-VG001-MSG-ERRO LK-VG001-NOM-TABELA LK-VG001-SQLCODE LK-VG001-SQLERRMC */
            _.Call(SPVG001V.VG001_PROGRAMA, SPVG001W);

            /*" -2807- IF LK-VG001-IND-ERRO NOT EQUAL ZEROS */

            if (SPVG001W.LK_VG001_IND_ERRO != 00)
            {

                /*" -2808- IF LK-VG001-IND-ERRO EQUAL 1 */

                if (SPVG001W.LK_VG001_IND_ERRO == 1)
                {

                    /*" -2812- DISPLAY 'ERRO JAH GRAVADO 3450 >> ' LK-VG001-NUM-CERTIFICADO ' >> ' LK-VG001-COD-MSG-CRITICA ' >> ' LK-VG001-IND-ERRO */

                    $"ERRO JAH GRAVADO 3450 >> {SPVG001W.LK_VG001_NUM_CERTIFICADO} >> {SPVG001W.LK_VG001_COD_MSG_CRITICA} >> {SPVG001W.LK_VG001_IND_ERRO}"
                    .Display();

                    /*" -2813- DISPLAY 'MSG-ERRO: ' LK-VG001-MSG-ERRO */
                    _.Display($"MSG-ERRO: {SPVG001W.LK_VG001_MSG_ERRO}");

                    /*" -2814- ELSE */
                }
                else
                {


                    /*" -2815- DISPLAY '*-------------------------------------------*' */
                    _.Display($"*-------------------------------------------*");

                    /*" -2816- DISPLAY '* 3450 -  PROBLEMAS CALL SUBROTINA SPBVG001 *' */
                    _.Display($"* 3450 -  PROBLEMAS CALL SUBROTINA SPBVG001 *");

                    /*" -2817- DISPLAY '*-------------------------------------------*' */
                    _.Display($"*-------------------------------------------*");

                    /*" -2818- DISPLAY '* NUM-CERTIF..: ' LK-VG001-NUM-CERTIFICADO */
                    _.Display($"* NUM-CERTIF..: {SPVG001W.LK_VG001_NUM_CERTIFICADO}");

                    /*" -2819- DISPLAY '* IND-ERRO....: ' LK-VG001-IND-ERRO */
                    _.Display($"* IND-ERRO....: {SPVG001W.LK_VG001_IND_ERRO}");

                    /*" -2820- DISPLAY '* MSG-ERRO....: ' LK-VG001-MSG-ERRO */
                    _.Display($"* MSG-ERRO....: {SPVG001W.LK_VG001_MSG_ERRO}");

                    /*" -2821- DISPLAY '* NOM-TABELA..: ' LK-VG001-NOM-TABELA */
                    _.Display($"* NOM-TABELA..: {SPVG001W.LK_VG001_NOM_TABELA}");

                    /*" -2822- DISPLAY '* SQLCODE.....: ' LK-VG001-SQLCODE */
                    _.Display($"* SQLCODE.....: {SPVG001W.LK_VG001_SQLCODE}");

                    /*" -2823- DISPLAY '* SQLERRMC....: ' LK-VG001-SQLERRMC */
                    _.Display($"* SQLERRMC....: {SPVG001W.LK_VG001_SQLERRMC}");

                    /*" -2825- DISPLAY '*-------------------------------------------*' */
                    _.Display($"*-------------------------------------------*");

                    /*" -2826- MOVE 999 TO SQLCODE */
                    _.Move(999, DB.SQLCODE);

                    /*" -2827- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2828- END-IF */
                }


                /*" -2829- END-IF */
            }


            /*" -2845- . */

            /*" -2845- ADD 1 TO AC-GRA-ERRPR. */
            FILLER_5.AC_GRA_ERRPR.Value = FILLER_5.AC_GRA_ERRPR + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3450_99_SAIDA*/

        [StopWatch]
        /*" R3500-00-INSERT-COBERPROPVA-SECTION */
        private void R3500_00_INSERT_COBERPROPVA_SECTION()
        {
            /*" -2861- MOVE 'R3500-00-INSERT-COBERPROPVA' TO PARAGRAFO. */
            _.Move("R3500-00-INSERT-COBERPROPVA", REG_LEITURA.FILLER_16.WABEND.PARAGRAFO);

            /*" -2865- MOVE SPACES TO HISCOBPR-DATA-INIVIGENCIA HISCOBPR-DATA-TERVIGENCIA. */
            _.Move("", HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_DATA_INIVIGENCIA, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_DATA_TERVIGENCIA);

            /*" -2890- MOVE ZEROS TO HISCOBPR-IMP-MORNATU HISCOBPR-IMPMORACID HISCOBPR-IMPINVPERM HISCOBPR-IMPAMDS HISCOBPR-IMPDH HISCOBPR-IMPDIT HISCOBPR-IMP-MORNATU HISCOBPR-IMPMORACID HISCOBPR-IMPSEGIND HISCOBPR-IMPSEGUR HISCOBPR-IMP-MORNATU HISCOBPR-IMPSEGIND HISCOBPR-IMPSEGUR HISCOBPR-QTDE-TIT-CAPITALIZ HISCOBPR-VAL-TIT-CAPITALIZ HISCOBPR-VAL-CUSTO-CAPITALI HISCOBPR-IMPSEGCDG HISCOBPR-VLCUSTCDG HISCOBPR-OCORR-HISTORICO HISCOBPR-COD-OPERACAO HISCOBPR-PRMVG HISCOBPR-PRMAP HISCOBPR-VLPREMIO. */
            _.Move(0, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMP_MORNATU, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPMORACID, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPINVPERM, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPAMDS, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPDH, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPDIT, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMP_MORNATU, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPMORACID, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPSEGIND, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPSEGUR, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMP_MORNATU, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPSEGIND, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPSEGUR, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_QTDE_TIT_CAPITALIZ, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_VAL_TIT_CAPITALIZ, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_VAL_CUSTO_CAPITALI, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPSEGCDG, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_VLCUSTCDG, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_OCORR_HISTORICO, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_COD_OPERACAO, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_PRMVG, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_PRMAP, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_VLPREMIO);

            /*" -2893- MOVE MOVIMVGA-DATA-MOVIMENTO TO HISCOBPR-DATA-INIVIGENCIA. */
            _.Move(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_MOVIMENTO, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_DATA_INIVIGENCIA);

            /*" -2896- MOVE PLAVAVGA-IMPMORNATU TO HISCOBPR-IMP-MORNATU. */
            _.Move(PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_IMPMORNATU, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMP_MORNATU);

            /*" -2899- MOVE PLAVAVGA-IMPMORACID TO HISCOBPR-IMPMORACID. */
            _.Move(PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_IMPMORACID, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPMORACID);

            /*" -2902- MOVE PLAVAVGA-IMPINVPERM TO HISCOBPR-IMPINVPERM. */
            _.Move(PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_IMPINVPERM, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPINVPERM);

            /*" -2905- MOVE PLAVAVGA-IMPAMDS TO HISCOBPR-IMPAMDS. */
            _.Move(PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_IMPAMDS, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPAMDS);

            /*" -2908- MOVE PLAVAVGA-IMPDH TO HISCOBPR-IMPDH. */
            _.Move(PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_IMPDH, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPDH);

            /*" -2911- MOVE PLAVAVGA-IMPDIT TO HISCOBPR-IMPDIT. */
            _.Move(PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_IMPDIT, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPDIT);

            /*" -2912- IF HISCOBPR-IMP-MORNATU EQUAL ZEROS */

            if (HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMP_MORNATU == 00)
            {

                /*" -2915- MOVE HISCOBPR-IMPMORACID TO HISCOBPR-IMPSEGIND HISCOBPR-IMPSEGUR */
                _.Move(HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPMORACID, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPSEGIND, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPSEGUR);

                /*" -2916- ELSE */
            }
            else
            {


                /*" -2920- MOVE HISCOBPR-IMP-MORNATU TO HISCOBPR-IMPSEGIND HISCOBPR-IMPSEGUR. */
                _.Move(HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMP_MORNATU, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPSEGIND, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPSEGUR);
            }


            /*" -2923- MOVE PLAVAVGA-QTTITCAP TO HISCOBPR-QTDE-TIT-CAPITALIZ. */
            _.Move(PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_QTTITCAP, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_QTDE_TIT_CAPITALIZ);

            /*" -2926- MOVE PLAVAVGA-VLTITCAP TO HISCOBPR-VAL-TIT-CAPITALIZ. */
            _.Move(PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_VLTITCAP, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_VAL_TIT_CAPITALIZ);

            /*" -2929- MOVE PLAVAVGA-VLCUSTCAP TO HISCOBPR-VAL-CUSTO-CAPITALI. */
            _.Move(PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_VLCUSTCAP, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_VAL_CUSTO_CAPITALI);

            /*" -2931- MOVE PLAVAVGA-IMPSEGCDG TO HISCOBPR-IMPSEGCDG. */
            _.Move(PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_IMPSEGCDG, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPSEGCDG);

            /*" -2934- MOVE PLAVAVGA-VLCUSTCDG TO HISCOBPR-VLCUSTCDG. */
            _.Move(PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_VLCUSTCDG, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_VLCUSTCDG);

            /*" -2937- MOVE 1 TO HISCOBPR-OCORR-HISTORICO. */
            _.Move(1, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_OCORR_HISTORICO);

            /*" -2940- MOVE '9999-12-31' TO HISCOBPR-DATA-TERVIGENCIA. */
            _.Move("9999-12-31", HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_DATA_TERVIGENCIA);

            /*" -2943- MOVE MOVIMVGA-COD-OPERACAO TO HISCOBPR-COD-OPERACAO. */
            _.Move(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_COD_OPERACAO);

            /*" -2946- MOVE PLAVAVGA-PRMVG TO HISCOBPR-PRMVG. */
            _.Move(PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_PRMVG, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_PRMVG);

            /*" -2949- MOVE PLAVAVGA-PRMAP TO HISCOBPR-PRMAP. */
            _.Move(PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_PRMAP, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_PRMAP);

            /*" -2952- COMPUTE HISCOBPR-VLPREMIO = HISCOBPR-PRMVG + HISCOBPR-PRMAP. */
            HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_VLPREMIO.Value = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_PRMVG + HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_PRMAP;

            /*" -2955- MOVE ZEROS TO WHOST-QTDTIMES. */
            _.Move(0, WHOST_QTDTIMES);

            /*" -2959- MOVE 0 TO WCONTADOR WPRIM-VEZ. */
            _.Move(0, FILLER_5.WCONTADOR, FILLER_5.WPRIM_VEZ);

            /*" -2961- MOVE '3500' TO WNR-EXEC-SQL. */
            _.Move("3500", REG_LEITURA.FILLER_16.WABEND.WNR_EXEC_SQL);

            /*" -3022- PERFORM R3500_00_INSERT_COBERPROPVA_DB_INSERT_1 */

            R3500_00_INSERT_COBERPROPVA_DB_INSERT_1();

            /*" -3025- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -3026- IF SQLCODE EQUAL -803 */

                if (DB.SQLCODE == -803)
                {

                    /*" -3027- MOVE 'S' TO WTEM-COBERPROPVA */
                    _.Move("S", REG_LEITURA.FILLER_16.WTEM_COBERPROPVA);

                    /*" -3028- ELSE */
                }
                else
                {


                    /*" -3032- DISPLAY 'PROBLEMA INSERT HIS_COBER_PROPOST     ..' PROPOVA-NUM-CERTIFICADO ' ' HISCOBPR-OCORR-HISTORICO ' ' HISCOBPR-DATA-INIVIGENCIA ' ' HISCOBPR-DATA-TERVIGENCIA SQLCODE */

                    $"PROBLEMA INSERT HIS_COBER_PROPOST     ..{PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO} {HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_OCORR_HISTORICO} {HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_DATA_INIVIGENCIA} {HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_DATA_TERVIGENCIA}{DB.SQLCODE}"
                    .Display();

                    /*" -3034- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -3034- ADD 1 TO AC-GRA-HCOPR. */
            FILLER_5.AC_GRA_HCOPR.Value = FILLER_5.AC_GRA_HCOPR + 1;

        }

        [StopWatch]
        /*" R3500-00-INSERT-COBERPROPVA-DB-INSERT-1 */
        public void R3500_00_INSERT_COBERPROPVA_DB_INSERT_1()
        {
            /*" -3022- EXEC SQL INSERT INTO SEGUROS.HIS_COBER_PROPOST (NUM_CERTIFICADO , OCORR_HISTORICO , DATA_INIVIGENCIA , DATA_TERVIGENCIA , IMPSEGUR , QUANT_VIDAS , IMPSEGIND , COD_OPERACAO , OPCAO_COBERTURA , IMP_MORNATU , IMPMORACID , IMPINVPERM , IMPAMDS , IMPDH , IMPDIT , VLPREMIO , PRMVG , PRMAP , QTDE_TIT_CAPITALIZ, VAL_TIT_CAPITALIZ , VAL_CUSTO_CAPITALI, IMPSEGCDG , VLCUSTCDG , COD_USUARIO , TIMESTAMP , IMPSEGAUXF , VLCUSTAUXF , PRMDIT , QTMDIT ) VALUES (:PROPOVA-NUM-CERTIFICADO, :HISCOBPR-OCORR-HISTORICO, :HISCOBPR-DATA-INIVIGENCIA, :HISCOBPR-DATA-TERVIGENCIA, :HISCOBPR-IMPSEGUR, 1, :HISCOBPR-IMPSEGIND, :HISCOBPR-COD-OPERACAO, ' ' , :HISCOBPR-IMP-MORNATU, :HISCOBPR-IMPMORACID, :HISCOBPR-IMPINVPERM, :HISCOBPR-IMPAMDS, :HISCOBPR-IMPDH, :HISCOBPR-IMPDIT, :HISCOBPR-VLPREMIO, :HISCOBPR-PRMVG, :HISCOBPR-PRMAP, :HISCOBPR-QTDE-TIT-CAPITALIZ, :HISCOBPR-VAL-TIT-CAPITALIZ, :HISCOBPR-VAL-CUSTO-CAPITALI, :HISCOBPR-IMPSEGCDG, :HISCOBPR-VLCUSTCDG, 'VG1650B' , CURRENT TIMESTAMP, NULL, NULL, NULL, NULL) END-EXEC. */

            var r3500_00_INSERT_COBERPROPVA_DB_INSERT_1_Insert1 = new R3500_00_INSERT_COBERPROPVA_DB_INSERT_1_Insert1()
            {
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
                HISCOBPR_OCORR_HISTORICO = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_OCORR_HISTORICO.ToString(),
                HISCOBPR_DATA_INIVIGENCIA = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_DATA_INIVIGENCIA.ToString(),
                HISCOBPR_DATA_TERVIGENCIA = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_DATA_TERVIGENCIA.ToString(),
                HISCOBPR_IMPSEGUR = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPSEGUR.ToString(),
                HISCOBPR_IMPSEGIND = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPSEGIND.ToString(),
                HISCOBPR_COD_OPERACAO = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_COD_OPERACAO.ToString(),
                HISCOBPR_IMP_MORNATU = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMP_MORNATU.ToString(),
                HISCOBPR_IMPMORACID = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPMORACID.ToString(),
                HISCOBPR_IMPINVPERM = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPINVPERM.ToString(),
                HISCOBPR_IMPAMDS = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPAMDS.ToString(),
                HISCOBPR_IMPDH = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPDH.ToString(),
                HISCOBPR_IMPDIT = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPDIT.ToString(),
                HISCOBPR_VLPREMIO = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_VLPREMIO.ToString(),
                HISCOBPR_PRMVG = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_PRMVG.ToString(),
                HISCOBPR_PRMAP = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_PRMAP.ToString(),
                HISCOBPR_QTDE_TIT_CAPITALIZ = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_QTDE_TIT_CAPITALIZ.ToString(),
                HISCOBPR_VAL_TIT_CAPITALIZ = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_VAL_TIT_CAPITALIZ.ToString(),
                HISCOBPR_VAL_CUSTO_CAPITALI = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_VAL_CUSTO_CAPITALI.ToString(),
                HISCOBPR_IMPSEGCDG = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPSEGCDG.ToString(),
                HISCOBPR_VLCUSTCDG = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_VLCUSTCDG.ToString(),
            };

            R3500_00_INSERT_COBERPROPVA_DB_INSERT_1_Insert1.Execute(r3500_00_INSERT_COBERPROPVA_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3500_99_SAIDA*/

        [StopWatch]
        /*" R3600-00-INSERT-OPCAOPAGVA-SECTION */
        private void R3600_00_INSERT_OPCAOPAGVA_SECTION()
        {
            /*" -3047- MOVE 'R3600-00-INSERT-OPCAOPAGVA' TO PARAGRAFO. */
            _.Move("R3600-00-INSERT-OPCAOPAGVA", REG_LEITURA.FILLER_16.WABEND.PARAGRAFO);

            /*" -3051- MOVE '3600' TO WNR-EXEC-SQL */
            _.Move("3600", REG_LEITURA.FILLER_16.WABEND.WNR_EXEC_SQL);

            /*" -3054- MOVE MOVIMVGA-DATA-MOVIMENTO TO OPCPAGVI-DATA-INIVIGENCIA. */
            _.Move(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_MOVIMENTO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_DATA_INIVIGENCIA);

            /*" -3060- MOVE -1 TO WHOST-IND. */
            _.Move(-1, WHOST_IND);

            /*" -3062- IF WHOST-IND-CRT < ZEROS OR OPCPAGVI-NUM-CARTAO-CREDITO NOT NUMERIC */

            if (WHOST_IND_CRT < 00 || !OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CARTAO_CREDITO.IsNumeric())
            {

                /*" -3063- MOVE ZEROS TO OPCPAGVI-NUM-CARTAO-CREDITO */
                _.Move(0, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CARTAO_CREDITO);

                /*" -3065- END-IF */
            }


            /*" -3068- MOVE R3-DIA-DEBITO TO OPCPAGVI-DIA-DEBITO. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_DIA_DEBITO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_DIA_DEBITO);

            /*" -3071- MOVE '9999-12-31' TO OPCPAGVI-DATA-TERVIGENCIA. */
            _.Move("9999-12-31", OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_DATA_TERVIGENCIA);

            /*" -3072- IF R3-OPCAOPAG EQUAL 1 */

            if (LXFCT004.REG_PROPOSTA_SASSE.R3_OPCAOPAG == 1)
            {

                /*" -3073- IF R3-NUM-CARTAO IS NUMERIC */

                if (LXFCT004.REG_PROPOSTA_SASSE.R3_CARTAO.R3_NUM_CARTAO.IsNumeric())
                {

                    /*" -3074- IF R3-NUM-CARTAO GREATER ZEROS */

                    if (LXFCT004.REG_PROPOSTA_SASSE.R3_CARTAO.R3_NUM_CARTAO > 00)
                    {

                        /*" -3075- IF R3-OPRCTADEB EQUAL 013 OR 022 */

                        if (LXFCT004.REG_PROPOSTA_SASSE.R3_CONTA_DEBITO.R3_OPRCTADEB.In("013", "022"))
                        {

                            /*" -3076- MOVE '2' TO OPCPAGVI-OPCAO-PAGAMENTO */
                            _.Move("2", OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPCAO_PAGAMENTO);

                            /*" -3077- ELSE */
                        }
                        else
                        {


                            /*" -3078- MOVE '1' TO OPCPAGVI-OPCAO-PAGAMENTO */
                            _.Move("1", OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPCAO_PAGAMENTO);

                            /*" -3079- END-IF */
                        }


                        /*" -3080- MOVE 0 TO WHOST-IND */
                        _.Move(0, WHOST_IND);

                        /*" -3081- MOVE R3-AGECTADEB TO OPCPAGVI-COD-AGENCIA-DEBITO */
                        _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_CONTA_DEBITO.R3_AGECTADEB, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_COD_AGENCIA_DEBITO);

                        /*" -3082- MOVE R3-OPRCTADEB TO OPCPAGVI-OPE-CONTA-DEBITO */
                        _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_CONTA_DEBITO.R3_OPRCTADEB, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPE_CONTA_DEBITO);

                        /*" -3083- MOVE R3-NUMCTADEB TO OPCPAGVI-NUM-CONTA-DEBITO */
                        _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_CONTA_DEBITO.R3_NUMCTADEB, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CONTA_DEBITO);

                        /*" -3084- MOVE R3-DIGCTADEB TO OPCPAGVI-DIG-CONTA-DEBITO */
                        _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_CONTA_DEBITO.R3_DIGCTADEB, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_DIG_CONTA_DEBITO);

                        /*" -3085- ELSE */
                    }
                    else
                    {


                        /*" -3086- MOVE -1 TO WHOST-IND */
                        _.Move(-1, WHOST_IND);

                        /*" -3091- MOVE ZEROS TO OPCPAGVI-COD-AGENCIA-DEBITO OPCPAGVI-OPE-CONTA-DEBITO OPCPAGVI-NUM-CONTA-DEBITO OPCPAGVI-DIG-CONTA-DEBITO OPCPAGVI-NUM-CARTAO-CREDITO */
                        _.Move(0, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_COD_AGENCIA_DEBITO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPE_CONTA_DEBITO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CONTA_DEBITO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_DIG_CONTA_DEBITO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CARTAO_CREDITO);

                        /*" -3092- MOVE '4' TO OPCPAGVI-OPCAO-PAGAMENTO */
                        _.Move("4", OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPCAO_PAGAMENTO);

                        /*" -3093- END-IF */
                    }


                    /*" -3094- ELSE */
                }
                else
                {


                    /*" -3095- MOVE -1 TO WHOST-IND */
                    _.Move(-1, WHOST_IND);

                    /*" -3100- MOVE ZEROS TO OPCPAGVI-COD-AGENCIA-DEBITO OPCPAGVI-OPE-CONTA-DEBITO OPCPAGVI-NUM-CONTA-DEBITO OPCPAGVI-DIG-CONTA-DEBITO OPCPAGVI-NUM-CARTAO-CREDITO */
                    _.Move(0, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_COD_AGENCIA_DEBITO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPE_CONTA_DEBITO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CONTA_DEBITO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_DIG_CONTA_DEBITO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CARTAO_CREDITO);

                    /*" -3101- MOVE '4' TO OPCPAGVI-OPCAO-PAGAMENTO */
                    _.Move("4", OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPCAO_PAGAMENTO);

                    /*" -3102- END-IF */
                }


                /*" -3104- END-IF. */
            }


            /*" -3105- IF R3-OPCAOPAG EQUAL 2 */

            if (LXFCT004.REG_PROPOSTA_SASSE.R3_OPCAOPAG == 2)
            {

                /*" -3107- MOVE -1 TO WHOST-IND */
                _.Move(-1, WHOST_IND);

                /*" -3113- MOVE ZEROS TO OPCPAGVI-COD-AGENCIA-DEBITO OPCPAGVI-OPE-CONTA-DEBITO OPCPAGVI-NUM-CONTA-DEBITO OPCPAGVI-DIG-CONTA-DEBITO OPCPAGVI-NUM-CARTAO-CREDITO */
                _.Move(0, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_COD_AGENCIA_DEBITO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPE_CONTA_DEBITO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CONTA_DEBITO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_DIG_CONTA_DEBITO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CARTAO_CREDITO);

                /*" -3115- MOVE '3' TO OPCPAGVI-OPCAO-PAGAMENTO */
                _.Move("3", OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPCAO_PAGAMENTO);

                /*" -3117- END-IF. */
            }


            /*" -3118- IF R3-OPCAOPAG EQUAL 3 */

            if (LXFCT004.REG_PROPOSTA_SASSE.R3_OPCAOPAG == 3)
            {

                /*" -3119- IF R3-NUM-CARTAO IS NUMERIC */

                if (LXFCT004.REG_PROPOSTA_SASSE.R3_CARTAO.R3_NUM_CARTAO.IsNumeric())
                {

                    /*" -3120- IF R3-NUM-CARTAO GREATER ZEROS */

                    if (LXFCT004.REG_PROPOSTA_SASSE.R3_CARTAO.R3_NUM_CARTAO > 00)
                    {

                        /*" -3121- MOVE '5' TO OPCPAGVI-OPCAO-PAGAMENTO */
                        _.Move("5", OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPCAO_PAGAMENTO);

                        /*" -3122- MOVE 0 TO WHOST-IND-CRT */
                        _.Move(0, WHOST_IND_CRT);

                        /*" -3123- MOVE R3-NUM-CARTAO TO OPCPAGVI-NUM-CARTAO-CREDITO */
                        _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_CARTAO.R3_NUM_CARTAO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CARTAO_CREDITO);

                        /*" -3127- MOVE ZEROS TO OPCPAGVI-COD-AGENCIA-DEBITO OPCPAGVI-OPE-CONTA-DEBITO OPCPAGVI-NUM-CONTA-DEBITO OPCPAGVI-DIG-CONTA-DEBITO */
                        _.Move(0, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_COD_AGENCIA_DEBITO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPE_CONTA_DEBITO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CONTA_DEBITO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_DIG_CONTA_DEBITO);

                        /*" -3128- ELSE */
                    }
                    else
                    {


                        /*" -3129- MOVE -1 TO WHOST-IND-CRT */
                        _.Move(-1, WHOST_IND_CRT);

                        /*" -3134- MOVE ZEROS TO OPCPAGVI-COD-AGENCIA-DEBITO OPCPAGVI-OPE-CONTA-DEBITO OPCPAGVI-NUM-CONTA-DEBITO OPCPAGVI-DIG-CONTA-DEBITO OPCPAGVI-NUM-CARTAO-CREDITO */
                        _.Move(0, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_COD_AGENCIA_DEBITO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPE_CONTA_DEBITO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CONTA_DEBITO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_DIG_CONTA_DEBITO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CARTAO_CREDITO);

                        /*" -3135- MOVE '4' TO OPCPAGVI-OPCAO-PAGAMENTO */
                        _.Move("4", OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPCAO_PAGAMENTO);

                        /*" -3136- END-IF */
                    }


                    /*" -3137- ELSE */
                }
                else
                {


                    /*" -3138- MOVE -1 TO WHOST-IND-CRT */
                    _.Move(-1, WHOST_IND_CRT);

                    /*" -3143- MOVE ZEROS TO OPCPAGVI-COD-AGENCIA-DEBITO OPCPAGVI-OPE-CONTA-DEBITO OPCPAGVI-NUM-CONTA-DEBITO OPCPAGVI-DIG-CONTA-DEBITO OPCPAGVI-NUM-CARTAO-CREDITO */
                    _.Move(0, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_COD_AGENCIA_DEBITO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPE_CONTA_DEBITO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CONTA_DEBITO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_DIG_CONTA_DEBITO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CARTAO_CREDITO);

                    /*" -3144- MOVE '4' TO OPCPAGVI-OPCAO-PAGAMENTO */
                    _.Move("4", OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPCAO_PAGAMENTO);

                    /*" -3145- END-IF */
                }


                /*" -3147- END-IF. */
            }


            /*" -3148- IF R3-OPCAOPAG EQUAL 4 */

            if (LXFCT004.REG_PROPOSTA_SASSE.R3_OPCAOPAG == 4)
            {

                /*" -3150- MOVE -1 TO WHOST-IND-CRT */
                _.Move(-1, WHOST_IND_CRT);

                /*" -3156- MOVE ZEROS TO OPCPAGVI-COD-AGENCIA-DEBITO OPCPAGVI-OPE-CONTA-DEBITO OPCPAGVI-NUM-CONTA-DEBITO OPCPAGVI-DIG-CONTA-DEBITO OPCPAGVI-NUM-CARTAO-CREDITO */
                _.Move(0, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_COD_AGENCIA_DEBITO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPE_CONTA_DEBITO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CONTA_DEBITO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_DIG_CONTA_DEBITO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CARTAO_CREDITO);

                /*" -3158- MOVE '4' TO OPCPAGVI-OPCAO-PAGAMENTO */
                _.Move("4", OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPCAO_PAGAMENTO);

                /*" -3160- END-IF. */
            }


            /*" -3190- PERFORM R3600_00_INSERT_OPCAOPAGVA_DB_INSERT_1 */

            R3600_00_INSERT_OPCAOPAGVA_DB_INSERT_1();

            /*" -3193- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -3195- IF SQLCODE EQUAL -803 NEXT SENTENCE */

                if (DB.SQLCODE == -803)
                {

                    /*" -3196- ELSE */
                }
                else
                {


                    /*" -3198- DISPLAY 'PROBLEMA INSERT DA OPCAOPAGVA ..' PROPOVA-NUM-CERTIFICADO ' ' SQLCODE */

                    $"PROBLEMA INSERT DA OPCAOPAGVA ..{PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO} {DB.SQLCODE}"
                    .Display();

                    /*" -3199- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -3201- END-IF. */
                }

            }


            /*" -3201- ADD 1 TO AC-GRA-PAGVI. */
            FILLER_5.AC_GRA_PAGVI.Value = FILLER_5.AC_GRA_PAGVI + 1;

        }

        [StopWatch]
        /*" R3600-00-INSERT-OPCAOPAGVA-DB-INSERT-1 */
        public void R3600_00_INSERT_OPCAOPAGVA_DB_INSERT_1()
        {
            /*" -3190- EXEC SQL INSERT INTO SEGUROS.OPCAO_PAG_VIDAZUL (NUM_CERTIFICADO, DATA_INIVIGENCIA, DATA_TERVIGENCIA, OPCAO_PAGAMENTO, PERI_PAGAMENTO, DIA_DEBITO, COD_USUARIO, TIMESTAMP, COD_AGENCIA_DEBITO, OPE_CONTA_DEBITO, NUM_CONTA_DEBITO, DIG_CONTA_DEBITO, NUM_CARTAO_CREDITO) VALUES (:PROPOVA-NUM-CERTIFICADO, :OPCPAGVI-DATA-INIVIGENCIA, :OPCPAGVI-DATA-TERVIGENCIA, :OPCPAGVI-OPCAO-PAGAMENTO, :MOVIMVGA-PERI-PAGAMENTO, :OPCPAGVI-DIA-DEBITO, 'VG1650B' , CURRENT TIMESTAMP, :OPCPAGVI-COD-AGENCIA-DEBITO:WHOST-IND, :OPCPAGVI-OPE-CONTA-DEBITO:WHOST-IND, :OPCPAGVI-NUM-CONTA-DEBITO:WHOST-IND, :OPCPAGVI-DIG-CONTA-DEBITO:WHOST-IND, :OPCPAGVI-NUM-CARTAO-CREDITO:WHOST-IND-CRT) END-EXEC. */

            var r3600_00_INSERT_OPCAOPAGVA_DB_INSERT_1_Insert1 = new R3600_00_INSERT_OPCAOPAGVA_DB_INSERT_1_Insert1()
            {
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
                OPCPAGVI_DATA_INIVIGENCIA = OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_DATA_INIVIGENCIA.ToString(),
                OPCPAGVI_DATA_TERVIGENCIA = OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_DATA_TERVIGENCIA.ToString(),
                OPCPAGVI_OPCAO_PAGAMENTO = OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPCAO_PAGAMENTO.ToString(),
                MOVIMVGA_PERI_PAGAMENTO = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PERI_PAGAMENTO.ToString(),
                OPCPAGVI_DIA_DEBITO = OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_DIA_DEBITO.ToString(),
                OPCPAGVI_COD_AGENCIA_DEBITO = OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_COD_AGENCIA_DEBITO.ToString(),
                WHOST_IND = WHOST_IND.ToString(),
                OPCPAGVI_OPE_CONTA_DEBITO = OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPE_CONTA_DEBITO.ToString(),
                OPCPAGVI_NUM_CONTA_DEBITO = OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CONTA_DEBITO.ToString(),
                OPCPAGVI_DIG_CONTA_DEBITO = OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_DIG_CONTA_DEBITO.ToString(),
                OPCPAGVI_NUM_CARTAO_CREDITO = OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CARTAO_CREDITO.ToString(),
                WHOST_IND_CRT = WHOST_IND_CRT.ToString(),
            };

            R3600_00_INSERT_OPCAOPAGVA_DB_INSERT_1_Insert1.Execute(r3600_00_INSERT_OPCAOPAGVA_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3600_99_SAIDA*/

        [StopWatch]
        /*" R3700-00-INSERT-PARCELVA-SECTION */
        private void R3700_00_INSERT_PARCELVA_SECTION()
        {
            /*" -3217- MOVE 'R3700-00-INSERT-PARCELVA' TO PARAGRAFO */
            _.Move("R3700-00-INSERT-PARCELVA", REG_LEITURA.FILLER_16.WABEND.PARAGRAFO);

            /*" -3220- MOVE MOVIMVGA-DATA-MOVIMENTO TO PARCEVID-DATA-VENCIMENTO. */
            _.Move(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_MOVIMENTO, PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_DATA_VENCIMENTO);

            /*" -3223- MOVE 01 TO PARCEVID-NUM-PARCELA. */
            _.Move(01, PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_NUM_PARCELA);

            /*" -3226- MOVE '1' TO PARCEVID-SIT-REGISTRO */
            _.Move("1", PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_SIT_REGISTRO);

            /*" -3229- MOVE OPCPAGVI-OPCAO-PAGAMENTO TO PARCEVID-OPCAO-PAGAMENTO. */
            _.Move(OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPCAO_PAGAMENTO, PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_OPCAO_PAGAMENTO);

            /*" -3232- MOVE PLAVAVGA-PRMVG TO PARCEVID-PREMIO-VG. */
            _.Move(PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_PRMVG, PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_PREMIO_VG);

            /*" -3235- MOVE PLAVAVGA-PRMAP TO PARCEVID-PREMIO-AP. */
            _.Move(PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_PRMAP, PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_PREMIO_AP);

            /*" -3238- MOVE ZEROS TO PARCEVID-OCORR-HISTORICO */
            _.Move(0, PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_OCORR_HISTORICO);

            /*" -3240- MOVE '3700' TO WNR-EXEC-SQL */
            _.Move("3700", REG_LEITURA.FILLER_16.WABEND.WNR_EXEC_SQL);

            /*" -3263- PERFORM R3700_00_INSERT_PARCELVA_DB_INSERT_1 */

            R3700_00_INSERT_PARCELVA_DB_INSERT_1();

            /*" -3266- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -3267- IF SQLCODE EQUAL -803 */

                if (DB.SQLCODE == -803)
                {

                    /*" -3268- GO TO R3700-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R3700_99_SAIDA*/ //GOTO
                    return;

                    /*" -3269- ELSE */
                }
                else
                {


                    /*" -3272- DISPLAY 'PROBLEMA INSERT DA PARCELVA ....' PROPOVA-NUM-CERTIFICADO ' ' PARCEVID-NUM-PARCELA */

                    $"PROBLEMA INSERT DA PARCELVA ....{PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO} {PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_NUM_PARCELA}"
                    .Display();

                    /*" -3273- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -3274- END-IF */
                }


                /*" -3276- END-IF */
            }


            /*" -3276- ADD 1 TO AC-GRA-PARVI. */
            FILLER_5.AC_GRA_PARVI.Value = FILLER_5.AC_GRA_PARVI + 1;

        }

        [StopWatch]
        /*" R3700-00-INSERT-PARCELVA-DB-INSERT-1 */
        public void R3700_00_INSERT_PARCELVA_DB_INSERT_1()
        {
            /*" -3263- EXEC SQL INSERT INTO SEGUROS.PARCELAS_VIDAZUL ( NUM_CERTIFICADO , NUM_PARCELA , DATA_VENCIMENTO , PREMIO_VG , PREMIO_AP , VLMULTA , OPCAO_PAGAMENTO , SIT_REGISTRO , OCORR_HISTORICO , TIMESTAMP) VALUES (:PROPOVA-NUM-CERTIFICADO, :PARCEVID-NUM-PARCELA, :PARCEVID-DATA-VENCIMENTO, :PARCEVID-PREMIO-VG, :PARCEVID-PREMIO-AP, 0.0, :PARCEVID-OPCAO-PAGAMENTO, :PARCEVID-SIT-REGISTRO, :PARCEVID-OCORR-HISTORICO, CURRENT TIMESTAMP) END-EXEC. */

            var r3700_00_INSERT_PARCELVA_DB_INSERT_1_Insert1 = new R3700_00_INSERT_PARCELVA_DB_INSERT_1_Insert1()
            {
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
                PARCEVID_NUM_PARCELA = PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_NUM_PARCELA.ToString(),
                PARCEVID_DATA_VENCIMENTO = PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_DATA_VENCIMENTO.ToString(),
                PARCEVID_PREMIO_VG = PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_PREMIO_VG.ToString(),
                PARCEVID_PREMIO_AP = PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_PREMIO_AP.ToString(),
                PARCEVID_OPCAO_PAGAMENTO = PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_OPCAO_PAGAMENTO.ToString(),
                PARCEVID_SIT_REGISTRO = PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_SIT_REGISTRO.ToString(),
                PARCEVID_OCORR_HISTORICO = PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_OCORR_HISTORICO.ToString(),
            };

            R3700_00_INSERT_PARCELVA_DB_INSERT_1_Insert1.Execute(r3700_00_INSERT_PARCELVA_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3700_99_SAIDA*/

        [StopWatch]
        /*" R3800-00-INSERT-HISTCOBVA-SECTION */
        private void R3800_00_INSERT_HISTCOBVA_SECTION()
        {
            /*" -3288- MOVE 'R3800-00-INSERT-HISTCOBVA' TO PARAGRAFO. */
            _.Move("R3800-00-INSERT-HISTCOBVA", REG_LEITURA.FILLER_16.WABEND.PARAGRAFO);

            /*" -3292- MOVE '3800' TO WNR-EXEC-SQL */
            _.Move("3800", REG_LEITURA.FILLER_16.WABEND.WNR_EXEC_SQL);

            /*" -3300- PERFORM R3800_00_INSERT_HISTCOBVA_DB_SELECT_1 */

            R3800_00_INSERT_HISTCOBVA_DB_SELECT_1();

            /*" -3303- IF SQLCODE EQUAL ZEROES */

            if (DB.SQLCODE == 00)
            {

                /*" -3304- GO TO R3800-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3800_99_SAIDA*/ //GOTO
                return;

                /*" -3306- END-IF. */
            }


            /*" -3310- COMPUTE COBHISVI-PRM-TOTAL = PARCEVID-PREMIO-VG + PARCEVID-PREMIO-AP. */
            COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_PRM_TOTAL.Value = PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_PREMIO_VG + PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_PREMIO_AP;

            /*" -3312- PERFORM R3810-00-NUM-TITULO. */

            R3810_00_NUM_TITULO_SECTION();

            /*" -3315- MOVE BANCOS-NUM-TITULO TO COBHISVI-NUM-TITULO. */
            _.Move(BANCOS.DCLBANCOS.BANCOS_NUM_TITULO, COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_NUM_TITULO);

            /*" -3318- MOVE MOVIMVGA-DATA-MOVIMENTO TO COBHISVI-DATA-VENCIMENTO. */
            _.Move(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_MOVIMENTO, COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_DATA_VENCIMENTO);

            /*" -3321- MOVE 01 TO COBHISVI-NUM-PARCELA. */
            _.Move(01, COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_NUM_PARCELA);

            /*" -3324- MOVE '1' TO COBHISVI-SIT-REGISTRO. */
            _.Move("1", COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_SIT_REGISTRO);

            /*" -3327- MOVE ZEROS TO COBHISVI-OCORR-HISTORICO. */
            _.Move(0, COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_OCORR_HISTORICO);

            /*" -3330- MOVE ZEROS TO COBHISVI-BCO-AVISO. */
            _.Move(0, COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_BCO_AVISO);

            /*" -3333- MOVE ZEROS TO COBHISVI-AGE-AVISO. */
            _.Move(0, COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_AGE_AVISO);

            /*" -3336- MOVE ZEROS TO COBHISVI-NUM-AVISO-CREDITO. */
            _.Move(0, COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_NUM_AVISO_CREDITO);

            /*" -3338- MOVE '3801' TO WNR-EXEC-SQL */
            _.Move("3801", REG_LEITURA.FILLER_16.WABEND.WNR_EXEC_SQL);

            /*" -3369- PERFORM R3800_00_INSERT_HISTCOBVA_DB_INSERT_1 */

            R3800_00_INSERT_HISTCOBVA_DB_INSERT_1();

            /*" -3372- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -3381- DISPLAY 'PROBLEMA INSERT DA HISTCOBVA ...' ' ' PROPOVA-NUM-CERTIFICADO ' ' PROPOVA-NUM-PARCELA ' ' COBHISVI-NUM-TITULO ' ' PROPOVA-DATA-VENCIMENTO ' ' COBHISVI-PRM-TOTAL ' ' PARCEVID-OPCAO-PAGAMENTO ' ' COBHISVI-SIT-REGISTRO ' ' COBHISVI-OCORR-HISTORICO */

                $"PROBLEMA INSERT DA HISTCOBVA ... {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO} {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_PARCELA} {COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_NUM_TITULO} {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DATA_VENCIMENTO} {COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_PRM_TOTAL} {PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_OPCAO_PAGAMENTO} {COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_SIT_REGISTRO} {COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_OCORR_HISTORICO}"
                .Display();

                /*" -3382- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -3384- END-IF. */
            }


            /*" -3384- ADD 1 TO AC-GRA-COBVID. */
            FILLER_5.AC_GRA_COBVID.Value = FILLER_5.AC_GRA_COBVID + 1;

        }

        [StopWatch]
        /*" R3800-00-INSERT-HISTCOBVA-DB-SELECT-1 */
        public void R3800_00_INSERT_HISTCOBVA_DB_SELECT_1()
        {
            /*" -3300- EXEC SQL SELECT NUM_CERTIFICADO, NUM_TITULO INTO :COBHISVI-NUM-CERTIFICADO, :COBHISVI-NUM-TITULO FROM SEGUROS.COBER_HIST_VIDAZUL WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO AND NUM_PARCELA = :COBHISVI-NUM-PARCELA END-EXEC. */

            var r3800_00_INSERT_HISTCOBVA_DB_SELECT_1_Query1 = new R3800_00_INSERT_HISTCOBVA_DB_SELECT_1_Query1()
            {
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
                COBHISVI_NUM_PARCELA = COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_NUM_PARCELA.ToString(),
            };

            var executed_1 = R3800_00_INSERT_HISTCOBVA_DB_SELECT_1_Query1.Execute(r3800_00_INSERT_HISTCOBVA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.COBHISVI_NUM_CERTIFICADO, COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_NUM_CERTIFICADO);
                _.Move(executed_1.COBHISVI_NUM_TITULO, COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_NUM_TITULO);
            }


        }

        [StopWatch]
        /*" R3800-00-INSERT-HISTCOBVA-DB-INSERT-1 */
        public void R3800_00_INSERT_HISTCOBVA_DB_INSERT_1()
        {
            /*" -3369- EXEC SQL INSERT INTO SEGUROS.COBER_HIST_VIDAZUL (NUM_CERTIFICADO , NUM_PARCELA , NUM_TITULO , DATA_VENCIMENTO , PRM_TOTAL , OPCAO_PAGAMENTO , SIT_REGISTRO , COD_OPERACAO , OCORR_HISTORICO , COD_DEVOLUCAO , BCO_AVISO , AGE_AVISO , NUM_AVISO_CREDITO , NUM_TITULO_COMP) VALUES (:PROPOVA-NUM-CERTIFICADO, :COBHISVI-NUM-PARCELA, :COBHISVI-NUM-TITULO, :COBHISVI-DATA-VENCIMENTO, :COBHISVI-PRM-TOTAL, :PARCEVID-OPCAO-PAGAMENTO, :COBHISVI-SIT-REGISTRO, 0, :COBHISVI-OCORR-HISTORICO, 0, :COBHISVI-BCO-AVISO , :COBHISVI-AGE-AVISO , :COBHISVI-NUM-AVISO-CREDITO, 0) END-EXEC. */

            var r3800_00_INSERT_HISTCOBVA_DB_INSERT_1_Insert1 = new R3800_00_INSERT_HISTCOBVA_DB_INSERT_1_Insert1()
            {
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
                COBHISVI_NUM_PARCELA = COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_NUM_PARCELA.ToString(),
                COBHISVI_NUM_TITULO = COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_NUM_TITULO.ToString(),
                COBHISVI_DATA_VENCIMENTO = COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_DATA_VENCIMENTO.ToString(),
                COBHISVI_PRM_TOTAL = COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_PRM_TOTAL.ToString(),
                PARCEVID_OPCAO_PAGAMENTO = PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_OPCAO_PAGAMENTO.ToString(),
                COBHISVI_SIT_REGISTRO = COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_SIT_REGISTRO.ToString(),
                COBHISVI_OCORR_HISTORICO = COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_OCORR_HISTORICO.ToString(),
                COBHISVI_BCO_AVISO = COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_BCO_AVISO.ToString(),
                COBHISVI_AGE_AVISO = COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_AGE_AVISO.ToString(),
                COBHISVI_NUM_AVISO_CREDITO = COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_NUM_AVISO_CREDITO.ToString(),
            };

            R3800_00_INSERT_HISTCOBVA_DB_INSERT_1_Insert1.Execute(r3800_00_INSERT_HISTCOBVA_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3800_99_SAIDA*/

        [StopWatch]
        /*" R3810-00-NUM-TITULO-SECTION */
        private void R3810_00_NUM_TITULO_SECTION()
        {
            /*" -3396- MOVE 'R3810-00-NUM-TITULO' TO PARAGRAFO. */
            _.Move("R3810-00-NUM-TITULO", REG_LEITURA.FILLER_16.WABEND.PARAGRAFO);

            /*" -3400- MOVE '3810' TO WNR-EXEC-SQL */
            _.Move("3810", REG_LEITURA.FILLER_16.WABEND.WNR_EXEC_SQL);

            /*" -3405- PERFORM R3810_00_NUM_TITULO_DB_SELECT_1 */

            R3810_00_NUM_TITULO_DB_SELECT_1();

            /*" -3408- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -3409- DISPLAY 'PROBLEMA SELECT BANCOS - 104 ...' */
                _.Display($"PROBLEMA SELECT BANCOS - 104 ...");

                /*" -3410- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -3412- END-IF. */
            }


            /*" -3415- MOVE BANCOS-NUM-TITULO TO W-NUMR-TITULO. */
            _.Move(BANCOS.DCLBANCOS.BANCOS_NUM_TITULO, REG_LEITURA.W_NUMR_TITULO);

            /*" -3417- ADD 1 TO WTITL-SEQUENCIA. */
            REG_LEITURA.FILLER_25.WTITL_SEQUENCIA.Value = REG_LEITURA.FILLER_25.WTITL_SEQUENCIA + 1;

            /*" -3420- MOVE WTITL-SEQUENCIA TO DPARM01. */
            _.Move(REG_LEITURA.FILLER_25.WTITL_SEQUENCIA, REG_LEITURA.DPARM01X.DPARM01);

            /*" -3422- CALL 'PROTIT01' USING DPARM01X. */
            _.Call("PROTIT01", REG_LEITURA.DPARM01X);

            /*" -3423- IF DPARM01-RC NOT EQUAL +0 */

            if (REG_LEITURA.DPARM01X.DPARM01_RC != +0)
            {

                /*" -3424- DISPLAY 'ERRO CHAMADA PROTIT01' */
                _.Display($"ERRO CHAMADA PROTIT01");

                /*" -3425- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -3427- END-IF. */
            }


            /*" -3430- MOVE DPARM01-D1 TO WTITL-DIGITO. */
            _.Move(REG_LEITURA.DPARM01X.DPARM01_D1, REG_LEITURA.FILLER_25.WTITL_DIGITO);

            /*" -3433- MOVE W-NUMR-TITULO TO BANCOS-NUM-TITULO. */
            _.Move(REG_LEITURA.W_NUMR_TITULO, BANCOS.DCLBANCOS.BANCOS_NUM_TITULO);

            /*" -3435- MOVE '3811' TO WNR-EXEC-SQL */
            _.Move("3811", REG_LEITURA.FILLER_16.WABEND.WNR_EXEC_SQL);

            /*" -3440- PERFORM R3810_00_NUM_TITULO_DB_UPDATE_1 */

            R3810_00_NUM_TITULO_DB_UPDATE_1();

            /*" -3443- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -3444- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -3444- END-IF. */
            }


        }

        [StopWatch]
        /*" R3810-00-NUM-TITULO-DB-SELECT-1 */
        public void R3810_00_NUM_TITULO_DB_SELECT_1()
        {
            /*" -3405- EXEC SQL SELECT NUM_TITULO INTO :BANCOS-NUM-TITULO FROM SEGUROS.BANCOS WHERE COD_BANCO = 104 END-EXEC. */

            var r3810_00_NUM_TITULO_DB_SELECT_1_Query1 = new R3810_00_NUM_TITULO_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R3810_00_NUM_TITULO_DB_SELECT_1_Query1.Execute(r3810_00_NUM_TITULO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.BANCOS_NUM_TITULO, BANCOS.DCLBANCOS.BANCOS_NUM_TITULO);
            }


        }

        [StopWatch]
        /*" R3810-00-NUM-TITULO-DB-UPDATE-1 */
        public void R3810_00_NUM_TITULO_DB_UPDATE_1()
        {
            /*" -3440- EXEC SQL UPDATE SEGUROS.BANCOS SET NUM_TITULO = :BANCOS-NUM-TITULO, TIMESTAMP = CURRENT TIMESTAMP WHERE COD_BANCO = 104 END-EXEC. */

            var r3810_00_NUM_TITULO_DB_UPDATE_1_Update1 = new R3810_00_NUM_TITULO_DB_UPDATE_1_Update1()
            {
                BANCOS_NUM_TITULO = BANCOS.DCLBANCOS.BANCOS_NUM_TITULO.ToString(),
            };

            R3810_00_NUM_TITULO_DB_UPDATE_1_Update1.Execute(r3810_00_NUM_TITULO_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3810_99_SAIDA*/

        [StopWatch]
        /*" R3900-00-INSERT-HISTCONTABILVA-SECTION */
        private void R3900_00_INSERT_HISTCONTABILVA_SECTION()
        {
            /*" -3457- MOVE 'R3900-00-INSERT-HISTCONTABILVA' TO PARAGRAFO */
            _.Move("R3900-00-INSERT-HISTCONTABILVA", REG_LEITURA.FILLER_16.WABEND.PARAGRAFO);

            /*" -3461- MOVE '3900' TO WNR-EXEC-SQL */
            _.Move("3900", REG_LEITURA.FILLER_16.WABEND.WNR_EXEC_SQL);

            /*" -3464- MOVE 01 TO HISCONPA-NUM-PARCELA. */
            _.Move(01, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_PARCELA);

            /*" -3467- MOVE SPACES TO HISCONPA-DTFATUR. */
            _.Move("", HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_DTFATUR);

            /*" -3470- MOVE -1 TO VIND-HISCONPA-DATA-FATURA. */
            _.Move(-1, VIND_HISCONPA_DATA_FATURA);

            /*" -3473- MOVE 0 TO HISCONPA-NUM-ENDOSSO. */
            _.Move(0, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_ENDOSSO);

            /*" -3476- MOVE '9' TO HISCONPA-SIT-REGISTRO. */
            _.Move("9", HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_SIT_REGISTRO);

            /*" -3479- MOVE PARCEVID-PREMIO-VG TO HISCONPA-PREMIO-VG. */
            _.Move(PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_PREMIO_VG, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_PREMIO_VG);

            /*" -3482- MOVE PARCEVID-PREMIO-AP TO HISCONPA-PREMIO-AP. */
            _.Move(PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_PREMIO_AP, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_PREMIO_AP);

            /*" -3485- MOVE COBHISVI-NUM-TITULO TO HISCONPA-NUM-TITULO. */
            _.Move(COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_NUM_TITULO, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_TITULO);

            /*" -3488- MOVE COBHISVI-OCORR-HISTORICO TO HISCONPA-OCORR-HISTORICO. */
            _.Move(COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_OCORR_HISTORICO, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_OCORR_HISTORICO);

            /*" -3491- MOVE 201 TO HISCONPA-COD-OPERACAO. */
            _.Move(201, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_COD_OPERACAO);

            /*" -3494- MOVE COBHISVI-DATA-VENCIMENTO TO HISCONPA-DATA-MOVIMENTO. */
            _.Move(COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_DATA_VENCIMENTO, HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_DATA_MOVIMENTO);

            /*" -3496- MOVE '3901' TO WNR-EXEC-SQL */
            _.Move("3901", REG_LEITURA.FILLER_16.WABEND.WNR_EXEC_SQL);

            /*" -3530- PERFORM R3900_00_INSERT_HISTCONTABILVA_DB_INSERT_1 */

            R3900_00_INSERT_HISTCONTABILVA_DB_INSERT_1();

            /*" -3533- IF SQLCODE NOT EQUAL ZEROS AND -803 */

            if (!DB.SQLCODE.In("00", "-803"))
            {

                /*" -3534- DISPLAY 'PROBLEMA INSERT DA HISTCONTABILVA  .' */
                _.Display($"PROBLEMA INSERT DA HISTCONTABILVA  .");

                /*" -3535- DISPLAY 'CERTIFICADO = ' PROPOVA-NUM-CERTIFICADO */
                _.Display($"CERTIFICADO = {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                /*" -3536- DISPLAY 'PARCELA     = ' PROPOVA-NUM-PARCELA */
                _.Display($"PARCELA     = {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_PARCELA}");

                /*" -3537- DISPLAY 'OCORHIST    = ' HISCONPA-OCORR-HISTORICO */
                _.Display($"OCORHIST    = {HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_OCORR_HISTORICO}");

                /*" -3538- DISPLAY 'DATA MOV.   = ' HISCONPA-DATA-MOVIMENTO */
                _.Display($"DATA MOV.   = {HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_DATA_MOVIMENTO}");

                /*" -3539- DISPLAY SQLCODE */
                _.Display(DB.SQLCODE);

                /*" -3540- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -3542- END-IF */
            }


            /*" -3542- ADD 1 TO AC-GRA-HCONPA. */
            FILLER_5.AC_GRA_HCONPA.Value = FILLER_5.AC_GRA_HCONPA + 1;

        }

        [StopWatch]
        /*" R3900-00-INSERT-HISTCONTABILVA-DB-INSERT-1 */
        public void R3900_00_INSERT_HISTCONTABILVA_DB_INSERT_1()
        {
            /*" -3530- EXEC SQL INSERT INTO SEGUROS.HIST_CONT_PARCELVA (NUM_CERTIFICADO, NUM_PARCELA , NUM_TITULO , OCORR_HISTORICO, NUM_APOLICE , COD_SUBGRUPO , COD_FONTE , NUM_ENDOSSO , PREMIO_VG , PREMIO_AP , DATA_MOVIMENTO , SIT_REGISTRO , COD_OPERACAO , TIMESTAMP , DTFATUR) VALUES (:PROPOVA-NUM-CERTIFICADO, :HISCONPA-NUM-PARCELA, :HISCONPA-NUM-TITULO, :HISCONPA-OCORR-HISTORICO, :PROPOVA-NUM-APOLICE, :PROPOVA-COD-SUBGRUPO, :PROPOVA-COD-FONTE, :HISCONPA-NUM-ENDOSSO, :HISCONPA-PREMIO-VG, :HISCONPA-PREMIO-AP, :HISCONPA-DATA-MOVIMENTO, :HISCONPA-SIT-REGISTRO, :HISCONPA-COD-OPERACAO, CURRENT TIMESTAMP, :HISCONPA-DTFATUR:VIND-HISCONPA-DATA-FATURA ) END-EXEC. */

            var r3900_00_INSERT_HISTCONTABILVA_DB_INSERT_1_Insert1 = new R3900_00_INSERT_HISTCONTABILVA_DB_INSERT_1_Insert1()
            {
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
                HISCONPA_NUM_PARCELA = HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_PARCELA.ToString(),
                HISCONPA_NUM_TITULO = HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_TITULO.ToString(),
                HISCONPA_OCORR_HISTORICO = HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_OCORR_HISTORICO.ToString(),
                PROPOVA_NUM_APOLICE = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE.ToString(),
                PROPOVA_COD_SUBGRUPO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_SUBGRUPO.ToString(),
                PROPOVA_COD_FONTE = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_FONTE.ToString(),
                HISCONPA_NUM_ENDOSSO = HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_NUM_ENDOSSO.ToString(),
                HISCONPA_PREMIO_VG = HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_PREMIO_VG.ToString(),
                HISCONPA_PREMIO_AP = HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_PREMIO_AP.ToString(),
                HISCONPA_DATA_MOVIMENTO = HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_DATA_MOVIMENTO.ToString(),
                HISCONPA_SIT_REGISTRO = HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_SIT_REGISTRO.ToString(),
                HISCONPA_COD_OPERACAO = HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_COD_OPERACAO.ToString(),
                HISCONPA_DTFATUR = HISCONPA.DCLHIST_CONT_PARCELVA.HISCONPA_DTFATUR.ToString(),
                VIND_HISCONPA_DATA_FATURA = VIND_HISCONPA_DATA_FATURA.ToString(),
            };

            R3900_00_INSERT_HISTCONTABILVA_DB_INSERT_1_Insert1.Execute(r3900_00_INSERT_HISTCONTABILVA_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3900_99_SAIDA*/

        [StopWatch]
        /*" R4000-00-INSERT-COMUNICFDCAPVA-SECTION */
        private void R4000_00_INSERT_COMUNICFDCAPVA_SECTION()
        {
            /*" -3555- MOVE 'R4000-00-INSERT-COMUNICFDCAPVA' TO PARAGRAFO. */
            _.Move("R4000-00-INSERT-COMUNICFDCAPVA", REG_LEITURA.FILLER_16.WABEND.PARAGRAFO);

            /*" -3559- MOVE '4000' TO WNR-EXEC-SQL. */
            _.Move("4000", REG_LEITURA.FILLER_16.WABEND.WNR_EXEC_SQL);

            /*" -3575- INITIALIZE VG0716S-COD-FONTE , VG0716S-COD-PRODUTO , VG0716S-NUM-PROPOSTA , VG0716S-VLR-MENSALIDADE , VG0716S-NUM-PLANO , VG0716S-NUM-SERIE , VG0716S-NUM-TITULO , VG0716S-IND-DV , VG0716S-DTH-INI-VIGENCIA , VG0716S-DTH-FIM-VIGENCIA , VG0716S-DES-COMBINACAO , VG0716S-COD-STA-TITULO , VG0716S-SQLCODE , VG0716S-COD-RETORNO , VG0716S-DES-MENSAGEM. */
            _.Initialize(
                VG0716S_COD_FONTE
                , VG0716S_COD_PRODUTO
                , VG0716S_NUM_PROPOSTA
                , VG0716S_VLR_MENSALIDADE
                , VG0716S_NUM_PLANO
                , VG0716S_NUM_SERIE
                , VG0716S_NUM_TITULO
                , VG0716S_IND_DV
                , VG0716S_DTH_INI_VIGENCIA
                , VG0716S_DTH_FIM_VIGENCIA
                , VG0716S_DES_COMBINACAO
                , VG0716S_COD_STA_TITULO
                , VG0716S_SQLCODE
                , VG0716S_COD_RETORNO
                , VG0716S_DES_MENSAGEM
            );

            /*" -3576- MOVE PROPOVA-COD-FONTE TO VG0716S-COD-FONTE */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_FONTE, VG0716S_COD_FONTE);

            /*" -3577- MOVE PRODUVG-COD-PRODUTO TO VG0716S-COD-PRODUTO */
            _.Move(PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_PRODUTO, VG0716S_COD_PRODUTO);

            /*" -3578- MOVE PRODUVG-COD-RUBRICA TO VG0716S-NUM-PLANO */
            _.Move(PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_RUBRICA, VG0716S_NUM_PLANO);

            /*" -3579- MOVE PROPOVA-NUM-CERTIFICADO TO VG0716S-NUM-PROPOSTA */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO, VG0716S_NUM_PROPOSTA);

            /*" -3582- MOVE HISCOBPR-VAL-CUSTO-CAPITALI TO VG0716S-VLR-MENSALIDADE. */
            _.Move(HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_VAL_CUSTO_CAPITALI, VG0716S_VLR_MENSALIDADE);

            /*" -3599- CALL 'VG0716S' USING VG0716S-COD-FONTE , VG0716S-COD-PRODUTO , VG0716S-NUM-PROPOSTA , VG0716S-VLR-MENSALIDADE , VG0716S-NUM-PLANO , VG0716S-NUM-SERIE , VG0716S-NUM-TITULO , VG0716S-IND-DV , VG0716S-DTH-INI-VIGENCIA , VG0716S-DTH-FIM-VIGENCIA , VG0716S-DES-COMBINACAO , VG0716S-COD-STA-TITULO , VG0716S-SQLCODE , VG0716S-COD-RETORNO , VG0716S-DES-MENSAGEM. */
            _.Call("VG0716S", VG0716S_COD_FONTE, VG0716S_COD_PRODUTO, VG0716S_NUM_PROPOSTA, VG0716S_VLR_MENSALIDADE, VG0716S_NUM_PLANO, VG0716S_NUM_SERIE, VG0716S_NUM_TITULO, VG0716S_IND_DV, VG0716S_DTH_INI_VIGENCIA, VG0716S_DTH_FIM_VIGENCIA, VG0716S_DES_COMBINACAO, VG0716S_COD_STA_TITULO, VG0716S_SQLCODE, VG0716S_COD_RETORNO, VG0716S_DES_MENSAGEM);

            /*" -3600- IF VG0716S-COD-RETORNO NOT EQUAL ZEROS */

            if (VG0716S_COD_RETORNO != 00)
            {

                /*" -3601- DISPLAY 'PROBLEMAS NO ACESSO A VG0716S ' */
                _.Display($"PROBLEMAS NO ACESSO A VG0716S ");

                /*" -3602- DISPLAY 'VG0716S-COD-FONTE        ' VG0716S-COD-FONTE */
                _.Display($"VG0716S-COD-FONTE        {VG0716S_COD_FONTE}");

                /*" -3603- DISPLAY 'VG0716S-COD-PRODUTO      ' VG0716S-COD-PRODUTO */
                _.Display($"VG0716S-COD-PRODUTO      {VG0716S_COD_PRODUTO}");

                /*" -3604- DISPLAY 'VG0716S-NUM-PROPOSTA     ' VG0716S-NUM-PROPOSTA */
                _.Display($"VG0716S-NUM-PROPOSTA     {VG0716S_NUM_PROPOSTA}");

                /*" -3605- DISPLAY 'VG0716S-VLR-MENSALIDADE  ' VG0716S-VLR-MENSALIDADE */
                _.Display($"VG0716S-VLR-MENSALIDADE  {VG0716S_VLR_MENSALIDADE}");

                /*" -3606- DISPLAY 'VG0716S-NUM-PLANO        ' VG0716S-NUM-PLANO */
                _.Display($"VG0716S-NUM-PLANO        {VG0716S_NUM_PLANO}");

                /*" -3607- DISPLAY 'VG0716S-NUM-SERIE        ' VG0716S-NUM-SERIE */
                _.Display($"VG0716S-NUM-SERIE        {VG0716S_NUM_SERIE}");

                /*" -3608- DISPLAY 'VG0716S-NUM-TITULO       ' VG0716S-NUM-TITULO */
                _.Display($"VG0716S-NUM-TITULO       {VG0716S_NUM_TITULO}");

                /*" -3609- DISPLAY 'VG0716S-IND-DV           ' VG0716S-IND-DV */
                _.Display($"VG0716S-IND-DV           {VG0716S_IND_DV}");

                /*" -3610- DISPLAY 'VG0716S-DTH-INI-VIGENCIA ' VG0716S-DTH-INI-VIGENCIA */
                _.Display($"VG0716S-DTH-INI-VIGENCIA {VG0716S_DTH_INI_VIGENCIA}");

                /*" -3611- DISPLAY 'VG0716S-DTH-FIM-VIGENCIA ' VG0716S-DTH-FIM-VIGENCIA */
                _.Display($"VG0716S-DTH-FIM-VIGENCIA {VG0716S_DTH_FIM_VIGENCIA}");

                /*" -3612- DISPLAY 'VG0716S-DES-COMBINACAO   ' VG0716S-DES-COMBINACAO */
                _.Display($"VG0716S-DES-COMBINACAO   {VG0716S_DES_COMBINACAO}");

                /*" -3613- DISPLAY 'VG0716S-COD-STA-TITULO   ' VG0716S-COD-STA-TITULO */
                _.Display($"VG0716S-COD-STA-TITULO   {VG0716S_COD_STA_TITULO}");

                /*" -3614- MOVE VG0716S-SQLCODE TO WS-ABEND */
                _.Move(VG0716S_SQLCODE, WS_ABEND);

                /*" -3615- DISPLAY 'VG0716S-SQLCODE          ' WS-ABEND */
                _.Display($"VG0716S-SQLCODE          {WS_ABEND}");

                /*" -3616- DISPLAY 'VG0716S-COD-RETORNO      ' VG0716S-COD-RETORNO */
                _.Display($"VG0716S-COD-RETORNO      {VG0716S_COD_RETORNO}");

                /*" -3617- DISPLAY 'VG0716S-DES-MENSAGEM     ' VG0716S-DES-MENSAGEM */
                _.Display($"VG0716S-DES-MENSAGEM     {VG0716S_DES_MENSAGEM}");

                /*" -3618- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -3620- END-IF. */
            }


            /*" -3622- MOVE '400A' TO WNR-EXEC-SQL. */
            _.Move("400A", REG_LEITURA.FILLER_16.WABEND.WNR_EXEC_SQL);

            /*" -3625- MOVE '1' TO COMFEDCA-SITUACAO. */
            _.Move("1", COMFEDCA.DCLCOMUNIC_FED_CAP_VA.COMFEDCA_SITUACAO);

            /*" -3627- MOVE '4001' TO WNR-EXEC-SQL. */
            _.Move("4001", REG_LEITURA.FILLER_16.WABEND.WNR_EXEC_SQL);

            /*" -3639- PERFORM R4000_00_INSERT_COMUNICFDCAPVA_DB_INSERT_1 */

            R4000_00_INSERT_COMUNICFDCAPVA_DB_INSERT_1();

            /*" -3642- IF SQLCODE NOT EQUAL ZEROS AND -803 */

            if (!DB.SQLCODE.In("00", "-803"))
            {

                /*" -3643- DISPLAY 'PROBLEMA INSERT DA COMUNICFDCAPVA  .' */
                _.Display($"PROBLEMA INSERT DA COMUNICFDCAPVA  .");

                /*" -3644- DISPLAY 'CERTIFICADO = ' PROPOVA-NUM-CERTIFICADO */
                _.Display($"CERTIFICADO = {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                /*" -3645- DISPLAY SQLCODE */
                _.Display(DB.SQLCODE);

                /*" -3646- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -3648- END-IF */
            }


            /*" -3648- ADD 1 TO AC-GRA-HCOMFD. */
            FILLER_5.AC_GRA_HCOMFD.Value = FILLER_5.AC_GRA_HCOMFD + 1;

        }

        [StopWatch]
        /*" R4000-00-INSERT-COMUNICFDCAPVA-DB-INSERT-1 */
        public void R4000_00_INSERT_COMUNICFDCAPVA_DB_INSERT_1()
        {
            /*" -3639- EXEC SQL INSERT INTO SEGUROS.COMUNIC_FED_CAP_VA (NUM_CERTIFICADO, SITUACAO, DATA_MOVIMENTO, TIMESTAMP) VALUES (:PROPOVA-NUM-CERTIFICADO, :COMFEDCA-SITUACAO, :COBHISVI-DATA-VENCIMENTO, CURRENT TIMESTAMP ) END-EXEC. */

            var r4000_00_INSERT_COMUNICFDCAPVA_DB_INSERT_1_Insert1 = new R4000_00_INSERT_COMUNICFDCAPVA_DB_INSERT_1_Insert1()
            {
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
                COMFEDCA_SITUACAO = COMFEDCA.DCLCOMUNIC_FED_CAP_VA.COMFEDCA_SITUACAO.ToString(),
                COBHISVI_DATA_VENCIMENTO = COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_DATA_VENCIMENTO.ToString(),
            };

            R4000_00_INSERT_COMUNICFDCAPVA_DB_INSERT_1_Insert1.Execute(r4000_00_INSERT_COMUNICFDCAPVA_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4000_99_SAIDA*/

        [StopWatch]
        /*" R8020-00-UPDATE-NUMEROUT-SECTION */
        private void R8020_00_UPDATE_NUMEROUT_SECTION()
        {
            /*" -3662- MOVE 'R8020-00-UPDATE-NUMEROUT' TO PARAGRAFO. */
            _.Move("R8020-00-UPDATE-NUMEROUT", REG_LEITURA.FILLER_16.WABEND.PARAGRAFO);

            /*" -3666- MOVE '8020' TO WNR-EXEC-SQL. */
            _.Move("8020", REG_LEITURA.FILLER_16.WABEND.WNR_EXEC_SQL);

            /*" -3672- PERFORM R8020_00_UPDATE_NUMEROUT_DB_UPDATE_1 */

            R8020_00_UPDATE_NUMEROUT_DB_UPDATE_1();

            /*" -3675- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -3678- DISPLAY 'VG1650B - PROBLEMAS ATUALIZACAO NUMERO-OUTROS ' NUMEROUT-NUM-CERT-VGAP */
                _.Display($"VG1650B - PROBLEMAS ATUALIZACAO NUMERO-OUTROS {NUMEROUT.DCLNUMERO_OUTROS.NUMEROUT_NUM_CERT_VGAP}");

                /*" -3679- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -3679- END-IF. */
            }


        }

        [StopWatch]
        /*" R8020-00-UPDATE-NUMEROUT-DB-UPDATE-1 */
        public void R8020_00_UPDATE_NUMEROUT_DB_UPDATE_1()
        {
            /*" -3672- EXEC SQL UPDATE SEGUROS.NUMERO_OUTROS SET NUM_CLIENTE = :NUMEROUT-NUM-CLIENTE WHERE 1 = 1 END-EXEC. */

            var r8020_00_UPDATE_NUMEROUT_DB_UPDATE_1_Update1 = new R8020_00_UPDATE_NUMEROUT_DB_UPDATE_1_Update1()
            {
                NUMEROUT_NUM_CLIENTE = NUMEROUT.DCLNUMERO_OUTROS.NUMEROUT_NUM_CLIENTE.ToString(),
            };

            R8020_00_UPDATE_NUMEROUT_DB_UPDATE_1_Update1.Execute(r8020_00_UPDATE_NUMEROUT_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8020_99_SAIDA*/

        [StopWatch]
        /*" R8030-00-SELECT-FONTES-SECTION */
        private void R8030_00_SELECT_FONTES_SECTION()
        {
            /*" -3693- MOVE 'R8030-00-SELECT-FONTES ' TO PARAGRAFO. */
            _.Move("R8030-00-SELECT-FONTES ", REG_LEITURA.FILLER_16.WABEND.PARAGRAFO);

            /*" -3695- MOVE '8030' TO WNR-EXEC-SQL. */
            _.Move("8030", REG_LEITURA.FILLER_16.WABEND.WNR_EXEC_SQL);

            /*" -3704- PERFORM R8030_00_SELECT_FONTES_DB_SELECT_1 */

            R8030_00_SELECT_FONTES_DB_SELECT_1();

            /*" -3707- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3710- DISPLAY 'VG1650B - ERRO ACESSO FONTES ' WHOST-COD-FONTE-ANT */
                _.Display($"VG1650B - ERRO ACESSO FONTES {WHOST_COD_FONTE_ANT}");

                /*" -3710- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R8030-00-SELECT-FONTES-DB-SELECT-1 */
        public void R8030_00_SELECT_FONTES_DB_SELECT_1()
        {
            /*" -3704- EXEC SQL SELECT ULT_PROP_AUTOMAT INTO :FONTES-ULT-PROP-AUTOMAT FROM SEGUROS.FONTES WHERE COD_FONTE = :WHOST-COD-FONTE-ANT END-EXEC. */

            var r8030_00_SELECT_FONTES_DB_SELECT_1_Query1 = new R8030_00_SELECT_FONTES_DB_SELECT_1_Query1()
            {
                WHOST_COD_FONTE_ANT = WHOST_COD_FONTE_ANT.ToString(),
            };

            var executed_1 = R8030_00_SELECT_FONTES_DB_SELECT_1_Query1.Execute(r8030_00_SELECT_FONTES_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.FONTES_ULT_PROP_AUTOMAT, FONTES.DCLFONTES.FONTES_ULT_PROP_AUTOMAT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8030_99_SAIDA*/

        [StopWatch]
        /*" R8040-00-UPDATE-FONTES-SECTION */
        private void R8040_00_UPDATE_FONTES_SECTION()
        {
            /*" -3724- MOVE 'R8040-00-UPDATE-FONTES  ' TO PARAGRAFO. */
            _.Move("R8040-00-UPDATE-FONTES  ", REG_LEITURA.FILLER_16.WABEND.PARAGRAFO);

            /*" -3728- MOVE '8040' TO WNR-EXEC-SQL. */
            _.Move("8040", REG_LEITURA.FILLER_16.WABEND.WNR_EXEC_SQL);

            /*" -3735- PERFORM R8040_00_UPDATE_FONTES_DB_UPDATE_1 */

            R8040_00_UPDATE_FONTES_DB_UPDATE_1();

            /*" -3738- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -3742- DISPLAY 'VG1650B - PROBLEMAS ATUALIZACAO FONTES ' WHOST-COD-FONTE-ANT ' ' FONTES-ULT-PROP-AUTOMAT */

                $"VG1650B - PROBLEMAS ATUALIZACAO FONTES {WHOST_COD_FONTE_ANT} {FONTES.DCLFONTES.FONTES_ULT_PROP_AUTOMAT}"
                .Display();

                /*" -3743- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -3745- END-IF. */
            }


            /*" -3745- MOVE MOVIMVGA-COD-FONTE TO WHOST-COD-FONTE-ANT. */
            _.Move(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_FONTE, WHOST_COD_FONTE_ANT);

        }

        [StopWatch]
        /*" R8040-00-UPDATE-FONTES-DB-UPDATE-1 */
        public void R8040_00_UPDATE_FONTES_DB_UPDATE_1()
        {
            /*" -3735- EXEC SQL UPDATE SEGUROS.FONTES SET ULT_PROP_AUTOMAT = :FONTES-ULT-PROP-AUTOMAT WHERE COD_FONTE = :WHOST-COD-FONTE-ANT END-EXEC. */

            var r8040_00_UPDATE_FONTES_DB_UPDATE_1_Update1 = new R8040_00_UPDATE_FONTES_DB_UPDATE_1_Update1()
            {
                FONTES_ULT_PROP_AUTOMAT = FONTES.DCLFONTES.FONTES_ULT_PROP_AUTOMAT.ToString(),
                WHOST_COD_FONTE_ANT = WHOST_COD_FONTE_ANT.ToString(),
            };

            R8040_00_UPDATE_FONTES_DB_UPDATE_1_Update1.Execute(r8040_00_UPDATE_FONTES_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8040_99_SAIDA*/

        [StopWatch]
        /*" R9000-00-FINALIZA-SECTION */
        private void R9000_00_FINALIZA_SECTION()
        {
            /*" -3761- MOVE 'R9000-00-FINALIZA' TO PARAGRAFO. */
            _.Move("R9000-00-FINALIZA", REG_LEITURA.FILLER_16.WABEND.PARAGRAFO);

            /*" -3763- MOVE '9000' TO WNR-EXEC-SQL. */
            _.Move("9000", REG_LEITURA.FILLER_16.WABEND.WNR_EXEC_SQL);

            /*" -3765- CLOSE MOV-SIGAT. */
            MOV_SIGAT.Close();

            /*" -3766- DISPLAY '------------------------------------- ' */
            _.Display($"------------------------------------- ");

            /*" -3767- DISPLAY 'LIDOS NO MOVIMENTO ARQUIVO EMPRESA  = ' AC-LIDOS-M */
            _.Display($"LIDOS NO MOVIMENTO ARQUIVO EMPRESA  = {FILLER_5.AC_LIDOS_M}");

            /*" -3768- DISPLAY '------------------------------------- ' */
            _.Display($"------------------------------------- ");

            /*" -3769- DISPLAY 'GRAVADOS NA CLIENTES               = ' AC-GRA-CLIENT */
            _.Display($"GRAVADOS NA CLIENTES               = {FILLER_5.AC_GRA_CLIENT}");

            /*" -3770- DISPLAY 'GRAVADOS NA PESSOA_EMAIL           = ' AC-GRA-PESEMA */
            _.Display($"GRAVADOS NA PESSOA_EMAIL           = {FILLER_5.AC_GRA_PESEMA}");

            /*" -3771- DISPLAY 'GRAVADOS NA ENDERECOS              = ' AC-GRA-ENDERE */
            _.Display($"GRAVADOS NA ENDERECOS              = {FILLER_5.AC_GRA_ENDERE}");

            /*" -3772- DISPLAY 'GRAVADOS NA PROPOSTAS_VA           = ' AC-GRA-PROVA */
            _.Display($"GRAVADOS NA PROPOSTAS_VA           = {FILLER_5.AC_GRA_PROVA}");

            /*" -3773- DISPLAY 'GRAVADOS NA MOVIMENTO_VGAP         = ' AC-GRA-MVGAP */
            _.Display($"GRAVADOS NA MOVIMENTO_VGAP         = {FILLER_5.AC_GRA_MVGAP}");

            /*" -3774- DISPLAY 'GRAVADOS NA PARCELAS_VIDAZUL       = ' AC-GRA-PARVI */
            _.Display($"GRAVADOS NA PARCELAS_VIDAZUL       = {FILLER_5.AC_GRA_PARVI}");

            /*" -3775- DISPLAY 'GRAVADOS NA OPCAO_PAG_VIDAZUL      = ' AC-GRA-PAGVI */
            _.Display($"GRAVADOS NA OPCAO_PAG_VIDAZUL      = {FILLER_5.AC_GRA_PAGVI}");

            /*" -3776- DISPLAY 'GRAVADOS NA HIS_COBER_PROPOST      = ' AC-GRA-HCOPR */
            _.Display($"GRAVADOS NA HIS_COBER_PROPOST      = {FILLER_5.AC_GRA_HCOPR}");

            /*" -3777- DISPLAY 'GRAVADOS NA COBER_HIST_VIDAZUL     = ' AC-GRA-COBVID */
            _.Display($"GRAVADOS NA COBER_HIST_VIDAZUL     = {FILLER_5.AC_GRA_COBVID}");

            /*" -3778- DISPLAY 'GRAVADOS NA HIST_CONT_PARCELVA     = ' AC-GRA-HCONPA */
            _.Display($"GRAVADOS NA HIST_CONT_PARCELVA     = {FILLER_5.AC_GRA_HCONPA}");

            /*" -3779- DISPLAY 'GRAVADOS NA COMUNIC_FED_CAP_VA     = ' AC-GRA-HCOMFD */
            _.Display($"GRAVADOS NA COMUNIC_FED_CAP_VA     = {FILLER_5.AC_GRA_HCOMFD}");

            /*" -3780- DISPLAY 'GRAVADOS NA VG_CRITICA_PROPOSTA    = ' AC-GRA-ERRPR */
            _.Display($"GRAVADOS NA VG_CRITICA_PROPOSTA    = {FILLER_5.AC_GRA_ERRPR}");

            /*" -3781- DISPLAY ' ' */
            _.Display($" ");

            /*" -3783- DISPLAY ' *** VG1650B - FIM NORMAL ' . */
            _.Display($" *** VG1650B - FIM NORMAL ");

            /*" -3783- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -3785- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9000_99_SAIDA*/

        [StopWatch]
        /*" R9900-00-ENCERRA-SEM-MOVTO-SECTION */
        private void R9900_00_ENCERRA_SEM_MOVTO_SECTION()
        {
            /*" -3797- MOVE SISTEMAS-DATA-MOV-ABERTO TO WDATA-REL */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, REG_LEITURA.WDATA_REL);

            /*" -3798- MOVE WDAT-REL-DIA TO WDAT-LIT-DIA */
            _.Move(REG_LEITURA.FILLER_27.WDAT_REL_DIA, REG_LEITURA.WDAT_REL_LIT.WDAT_LIT_DIA);

            /*" -3799- MOVE WDAT-REL-MES TO WDAT-LIT-MES */
            _.Move(REG_LEITURA.FILLER_27.WDAT_REL_MES, REG_LEITURA.WDAT_REL_LIT.WDAT_LIT_MES);

            /*" -3800- MOVE WDAT-REL-SEC TO WDAT-LIT-SEC */
            _.Move(REG_LEITURA.FILLER_27.WDAT_REL_SEC, REG_LEITURA.WDAT_REL_LIT.WDAT_LIT_SEC);

            /*" -3802- MOVE WDAT-REL-ANO TO WDAT-LIT-ANO */
            _.Move(REG_LEITURA.FILLER_27.WDAT_REL_ANO, REG_LEITURA.WDAT_REL_LIT.WDAT_LIT_ANO);

            /*" -3803- DISPLAY '*--------------------------------------------*' */
            _.Display($"*--------------------------------------------*");

            /*" -3804- DISPLAY '*                                            *' */
            _.Display($"*                                            *");

            /*" -3805- DISPLAY '*  VG1650B - CONSISTENCIA LOGICA MOVIMENTO   *' */
            _.Display($"*  VG1650B - CONSISTENCIA LOGICA MOVIMENTO   *");

            /*" -3806- DISPLAY '*  -------   ------------ ------ ---------   *' */
            _.Display($"*  -------   ------------ ------ ---------   *");

            /*" -3807- DISPLAY '*                                            *' */
            _.Display($"*                                            *");

            /*" -3808- DISPLAY '*     NAO HOUVE MOVIMENTACAO NESTA DATA      *' */
            _.Display($"*     NAO HOUVE MOVIMENTACAO NESTA DATA      *");

            /*" -3810- DISPLAY '*               ' WDAT-REL-LIT '                     *' */

            $"*               {REG_LEITURA.WDAT_REL_LIT}                     *"
            .Display();

            /*" -3811- DISPLAY '*                                            *' */
            _.Display($"*                                            *");

            /*" -3811- DISPLAY '*--------------------------------------------*' . */
            _.Display($"*--------------------------------------------*");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9900_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -3823- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3824- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, REG_LEITURA.FILLER_16.WABEND.WSQLCODE);

                /*" -3825- MOVE SQLERRD(1) TO WSQLCODE1 */
                _.Move(DB.SQLERRD[1], REG_LEITURA.FILLER_16.WABEND.WSQLCODE1);

                /*" -3826- MOVE SQLERRD(2) TO WSQLCODE2 */
                _.Move(DB.SQLERRD[2], REG_LEITURA.FILLER_16.WABEND.WSQLCODE2);

                /*" -3827- MOVE SQLCODE TO WSQLCODE3 */
                _.Move(DB.SQLCODE, FILLER_5.WSQLCODE3);

                /*" -3828- DISPLAY WABEND */
                _.Display(REG_LEITURA.FILLER_16.WABEND);

                /*" -3829- MOVE SQLERRMC TO WSQLERRMC */
                _.Move(DB.SQLERRMC, REG_LEITURA.FILLER_16.WSQLERRO.WSQLERRMC);

                /*" -3831- DISPLAY WSQLERRO. */
                _.Display(REG_LEITURA.FILLER_16.WSQLERRO);
            }


            /*" -3832- DISPLAY SPACES */
            _.Display($"");

            /*" -3833- DISPLAY REG-SIGAT */
            _.Display(REG_SIGAT);

            /*" -3834- ACCEPT WS-TIME FROM TIME */
            _.Move(_.AcceptDate("TIME"), FILLER_5.WS_TIME);

            /*" -3836- DISPLAY 'LIDOS MOVIMENTO   ' AC-LIDOS-M ' ' WS-TIME */

            $"LIDOS MOVIMENTO   {FILLER_5.AC_LIDOS_M} {FILLER_5.WS_TIME}"
            .Display();

            /*" -3838- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -3842- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -3846- MOVE 99 TO RETURN-CODE */
            _.Move(99, RETURN_CODE);

            /*" -3846- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}