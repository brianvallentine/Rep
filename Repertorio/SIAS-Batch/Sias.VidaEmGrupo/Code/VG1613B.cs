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
using Sias.VidaEmGrupo.DB2.VG1613B;

namespace Code
{
    public class VG1613B
    {
        public bool IsCall { get; set; }

        public VG1613B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *-------------------------                                              */
        /*"      ******************************************************************      */
        /*"      *   SISTEMA ................  VG - VIDA EM GRUPO (ESPECIFICAS    *      */
        /*"      *                                                 POR SUBGRUPO)  *      */
        /*"      *   PROGRAMA ...............  VG1613B                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA................  FAST COMPUTER                      *      */
        /*"      *                                                                *      */
        /*"      *   PROGRAMADOR ............  FAST COMPUTER                      *      */
        /*"      *                                                                *      */
        /*"      *   DATA CODIFICACAO .......  SETEMBRO/2005                      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO .................  MANUTENCAO DE SEGURADOS DE VIDA    *      */
        /*"      *                             EM GRUPO VIA INTERFACE PARA AS     *      */
        /*"      *                             APOLICES ESPECIFICAS.              *      */
        /*"      *                                  (LAY-OUT CADSEG)              *      */
        /*"      *                                                                *      */
        /*"      *     OPERACOES ->  NAO CADASTRADO NA BASE = INCLUSAO            *      */
        /*"      *                   NAO VEM NO MOVTO MENSAL= CANCELAMENTO        *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"      *   VERSAO 42 - DEMANDA 584.508                                  *      */
        /*"      *             - AJUSTA AS QUANTIDADES E VALORES GERADOS          *      */
        /*"      *               POR SUBGRUPO NO ARQUIVO DE SAIDA.                *      */
        /*"      *             - AUMENTA PARA R$0,03 A TOLERANCIA DE DIFERENCA    *      */
        /*"      *               DO VALOR DO PREMIO INFORMADO DO DO CALCULADO     *      */
        /*"      *               EM FUNCAO DE REJEICOES NAS APOLICES FRIMESA.     *      */
        /*"      *                                                                *      */
        /*"      *   EM 23/07/2024 - TERCIO CARVALHO                              *      */
        /*"      *                                        PROCURE POR V.42        *      */
        /*"      ******************************************************************      */
        /*"      *   VERSAO 41 - DEMANDA 584.508                                  *      */
        /*"      *               DEIXA DE CANCELAR O SEGURO QUANDO DAH DIFERENCA  *      */
        /*"      *               ENTRE O PREMIO CALCULADO E O PREMIO INFORMADO    *      */
        /*"      *               ALEM DE GERAR MENSAGEM DE CRITICA NO SUBGRUPO.   *      */
        /*"      *                                                                *      */
        /*"      *   EM 17/07/2024 - TERCIO CARVALHO                              *      */
        /*"      *                                        PROCURE POR V.41        *      */
        /*"      ******************************************************************      */
        /*"      *   VERSAO 40 - DEMANDA 495.544                                 *       */
        /*"      *               ACATAR O VALOR DE PREMIO INFORMADO PELO PORTAL   *      */
        /*"      *               QUANDO DER DIFERENCA DE R$0,40 PARA MAIS OU      *      */
        /*"      *               PARA MENOS EM RELACAO AO CALCULADO PELO SIAS.    *      */
        /*"      *                                                                *      */
        /*"      *   EM 15/05/2023 - TERCIO CARVALHO                              *      */
        /*"      *                                        PROCURE POR V.40        *      */
        /*"      ******************************************************************      */
        /*"      *   VERSAO 39 - DEMANDA 477.782                                  *      */
        /*"      *               DESABILITAR DEBUGGING MODE,SYSOUT MUITO GRANDE   *      */
        /*"      *                                                                *      */
        /*"      *   EM 15/03/2023 - BRICE HO                                     *      */
        /*"      *                                        PROCURE POR V.39        *      */
        /*"      ******************************************************************      */
        /*"V.38  *   VERSAO 38 - DEMANDA 402.982                                  *      */
        /*"      *             - SUBSTITUI CONSULTA DA TABELA ERROS_VIDAZUL PELA  *      */
        /*"      *               NOVA TABELA VG_DM_MSG_CRITICA                    *      */
        /*"      *                                                                *      */
        /*"      *   EM 14/02/2023 - ELIERMES OLIVEIRA                            *      */
        /*"      *                                        PROCURE POR V.38        *      */
        /*"      ******************************************************************      */
        /*"      *   VERSAO 37 - SEMPRE ATUALIZAR O SEXO NA CLIENTES CASO SEJA    *      */
        /*"      *               DIFERENTE DO INFORMADO NO CADSEG INDEPENDENTE DE *      */
        /*"      *               SER INCLUSAO DE SEGURADO.                        *      */
        /*"      *               MOTIVO: AO EMITIR A RELACAO DE VIDAS O SISTEMA   *      */
        /*"      *                       UTILIZA INFORMACOES DA CLIENTES.         *      */
        /*"      *    EM 27/06/2022 - BRICE HO                                    *      */
        /*"      *                                        PROCURE POR V.37        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 36 - ALTERACAO LAY-OUT DO CADSEG.                     *      */
        /*"      *               PASSOU A RECEBER A DATA INICIO DE VIGENCIA DO    *      */
        /*"      *               CERTIFICADO DO SEGURADO.                         *      */
        /*"      *               PASSOU A ATUALIZAR O SEXO NA CLIENTES CASO SEJA  *      */
        /*"      *               DIFERENTE DO INFORMADO NO CADSEG.                *      */
        /*"      *    EM 22/04/2022 - BRICE HO                                    *      */
        /*"      *                                        PROCURE POR V.36        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"JV.02 *   VERSAO 35 - DESFAZER JV1.  DESFAZER ALTERACAO PRODUTO 9354   *      */
        /*"=     *             - DESCONTINUADO.                                   *      */
        /*"=     *             - TAREFA: 272563.                                         */
        /*"=     *    EM 04/01/2020 - HERVAL SOUZA                                *      */
        /*"=     *                                        PROCURE POR V.35        *      */
        /*"JV.02 *----------------------------------------------------------------*      */
        /*"      *   DEMAIS HISTORICOS DE MANUTENCAO - VIDE FINAL DO PROGRAMA     *      */
        /*"      *----------------------------------------------------------------*      */
        #endregion


        #region VARIABLES

        public FileBasis _ARQUIVO_LEITURA { get; set; } = new FileBasis(new PIC("X", "300", "X(300)"));

        public FileBasis ARQUIVO_LEITURA
        {
            get
            {
                _.Move(REGISTRO_LEITURA, _ARQUIVO_LEITURA); VarBasis.RedefinePassValue(REGISTRO_LEITURA, _ARQUIVO_LEITURA, REGISTRO_LEITURA); return _ARQUIVO_LEITURA;
            }
        }
        public FileBasis _ARQUIVO_RETORNO { get; set; } = new FileBasis(new PIC("X", "300", "X(300)"));

        public FileBasis ARQUIVO_RETORNO
        {
            get
            {
                _.Move(REGISTRO_RETORNO, _ARQUIVO_RETORNO); VarBasis.RedefinePassValue(REGISTRO_RETORNO, _ARQUIVO_RETORNO, REGISTRO_RETORNO); return _ARQUIVO_RETORNO;
            }
        }
        public SortBasis<VG1613B_REGISTRO_SORT> ARQUIVO_SORT { get; set; } = new SortBasis<VG1613B_REGISTRO_SORT>(new VG1613B_REGISTRO_SORT());
        /*"01        REGISTRO-LEITURA.*/
        public VG1613B_REGISTRO_LEITURA REGISTRO_LEITURA { get; set; } = new VG1613B_REGISTRO_LEITURA();
        public class VG1613B_REGISTRO_LEITURA : VarBasis
        {
            /*"  05     REG-LEITURA         PIC  X(300).*/
            public StringBasis REG_LEITURA { get; set; } = new StringBasis(new PIC("X", "300", "X(300)."), @"");
            /*"01        REGISTRO-SORT.*/
        }
        public VG1613B_REGISTRO_SORT REGISTRO_SORT { get; set; } = new VG1613B_REGISTRO_SORT();
        public class VG1613B_REGISTRO_SORT : VarBasis
        {
            /*"    10        NOME-SOR                 PIC  X(040).*/
            public StringBasis NOME_SOR { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
            /*"    10        CPF-SOR                  PIC  9(011).*/
            public IntBasis CPF_SOR { get; set; } = new IntBasis(new PIC("9", "11", "9(011)."));
            /*"    10        DTNAS-SOR.*/
            public VG1613B_DTNAS_SOR DTNAS_SOR { get; set; } = new VG1613B_DTNAS_SOR();
            public class VG1613B_DTNAS_SOR : VarBasis
            {
                /*"      15      DTNAS-AA-SOR             PIC  X(004).*/
                public StringBasis DTNAS_AA_SOR { get; set; } = new StringBasis(new PIC("X", "4", "X(004)."), @"");
                /*"      15      DTNAS-T1-SOR             PIC  X(001).*/
                public StringBasis DTNAS_T1_SOR { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      15      DTNAS-MM-SOR             PIC  X(002).*/
                public StringBasis DTNAS_MM_SOR { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"      15      DTNAS-T2-SOR             PIC  X(001).*/
                public StringBasis DTNAS_T2_SOR { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      15      DTNAS-DD-SOR             PIC  X(002).*/
                public StringBasis DTNAS_DD_SOR { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"    10        SEXO-SOR                 PIC  X(001).*/
            }
            public StringBasis SEXO_SOR { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    10        ESTCIV-SOR               PIC  X(001).*/
            public StringBasis ESTCIV_SOR { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    10        SALARIO-SOR              PIC  9(008)V99.*/
            public DoubleBasis SALARIO_SOR { get; set; } = new DoubleBasis(new PIC("9", "8", "9(008)V99."), 2);
            /*"    10        SALARIO-SOR-R REDEFINES SALARIO-SOR                                       PIC  9(010).*/
            private _REDEF_IntBasis _salario_sor_r { get; set; }
            public _REDEF_IntBasis SALARIO_SOR_R
            {
                get { _salario_sor_r = new _REDEF_IntBasis(new PIC("9", "010", "9(010).")); ; _.Move(SALARIO_SOR, _salario_sor_r); VarBasis.RedefinePassValue(SALARIO_SOR, _salario_sor_r, SALARIO_SOR); _salario_sor_r.ValueChanged += () => { _.Move(_salario_sor_r, SALARIO_SOR); }; return _salario_sor_r; }
                set { VarBasis.RedefinePassValue(value, _salario_sor_r, SALARIO_SOR); }
            }  //Redefines
            /*"    10        QTDSAL-SOR               PIC  9(004).*/
            public IntBasis QTDSAL_SOR { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    10        IS-SOR                   PIC  9(008)V99.*/
            public DoubleBasis IS_SOR { get; set; } = new DoubleBasis(new PIC("9", "8", "9(008)V99."), 2);
            /*"    10        IS-SOR-R REDEFINES IS-SOR                                       PIC  9(010).*/
            private _REDEF_IntBasis _is_sor_r { get; set; }
            public _REDEF_IntBasis IS_SOR_R
            {
                get { _is_sor_r = new _REDEF_IntBasis(new PIC("9", "010", "9(010).")); ; _.Move(IS_SOR, _is_sor_r); VarBasis.RedefinePassValue(IS_SOR, _is_sor_r, IS_SOR); _is_sor_r.ValueChanged += () => { _.Move(_is_sor_r, IS_SOR); }; return _is_sor_r; }
                set { VarBasis.RedefinePassValue(value, _is_sor_r, IS_SOR); }
            }  //Redefines
            /*"    10        PREMIO-SOR               PIC  9(008)V99.*/
            public DoubleBasis PREMIO_SOR { get; set; } = new DoubleBasis(new PIC("9", "8", "9(008)V99."), 2);
            /*"    10        PREMIO-SOR-R REDEFINES PREMIO-SOR                                       PIC  9(010).*/
            private _REDEF_IntBasis _premio_sor_r { get; set; }
            public _REDEF_IntBasis PREMIO_SOR_R
            {
                get { _premio_sor_r = new _REDEF_IntBasis(new PIC("9", "010", "9(010).")); ; _.Move(PREMIO_SOR, _premio_sor_r); VarBasis.RedefinePassValue(PREMIO_SOR, _premio_sor_r, PREMIO_SOR); _premio_sor_r.ValueChanged += () => { _.Move(_premio_sor_r, PREMIO_SOR); }; return _premio_sor_r; }
                set { VarBasis.RedefinePassValue(value, _premio_sor_r, PREMIO_SOR); }
            }  //Redefines
            /*"    10        NUM-APOLICE-SOR          PIC  9(013).*/
            public IntBasis NUM_APOLICE_SOR { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
            /*"    10        SUBGRUPO-SOR             PIC  9(004).*/
            public IntBasis SUBGRUPO_SOR { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    10        DTVIG-SOR                PIC  X(010).*/
            public StringBasis DTVIG_SOR { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    10        COD-ERRO-SOR             PIC  9(004).*/
            public IntBasis COD_ERRO_SOR { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"01        REGISTRO-RETORNO.*/
        }
        public VG1613B_REGISTRO_RETORNO REGISTRO_RETORNO { get; set; } = new VG1613B_REGISTRO_RETORNO();
        public class VG1613B_REGISTRO_RETORNO : VarBasis
        {
            /*"  05     REG-RETORNO         PIC  X(300).*/
            public StringBasis REG_RETORNO { get; set; } = new StringBasis(new PIC("X", "300", "X(300)."), @"");
        }

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"*/
        public IntBasis SORT_RETURN { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77  WS-PRM-DIFERENCA              PIC S9(008)V99 VALUE ZEROS.*/
        public DoubleBasis WS_PRM_DIFERENCA { get; set; } = new DoubleBasis(new PIC("S9", "8", "S9(008)V99"), 2);
        /*"77  WS-NUM-APOLICE-ANT            PIC  9(013)    VALUE ZEROS.*/
        public IntBasis WS_NUM_APOLICE_ANT { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
        /*"77  WS-DATA-INIVIGENCIA-APOL      PIC  X(010)    VALUE SPACES.*/
        public StringBasis WS_DATA_INIVIGENCIA_APOL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77  WS-QTD-DIAS-VIGENCIA          PIC S9(009)    VALUE +0 COMP.*/
        public IntBasis WS_QTD_DIAS_VIGENCIA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77  WS-RAMO                       PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis WS_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WS-ERRO-CPF                   PIC  X(003)    VALUE  SPACES.*/
        public StringBasis WS_ERRO_CPF { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
        /*"77  WS-ERRO-DATA                  PIC  X(003)    VALUE  SPACES.*/
        public StringBasis WS_ERRO_DATA { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
        /*"77  WS-ERRO-SUBGRUPO              PIC  X(003)    VALUE  SPACES.*/
        public StringBasis WS_ERRO_SUBGRUPO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
        /*"77  WS-TEM-SUBGRUPO               PIC  X(003)    VALUE  SPACES.*/
        public StringBasis WS_TEM_SUBGRUPO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
        /*"77  WS-ERRO-MOVTO                 PIC  X(003)    VALUE  SPACES.*/
        public StringBasis WS_ERRO_MOVTO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
        /*"77  WS-PREMIO                     PIC S9(013)V99 VALUE +0 COMP-3*/
        public DoubleBasis WS_PREMIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77  WS-TOT-PREMIO                 PIC S9(013)V99 VALUE +0 COMP-3*/
        public DoubleBasis WS_TOT_PREMIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77  WS-TOT-CRITIC                 PIC S9(013)V99 VALUE +0 COMP-3*/
        public DoubleBasis WS_TOT_CRITIC { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77  WS-IDADE                      PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis WS_IDADE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WTOT-PREMIO                   PIC  9(013)V99 VALUE  ZEROS.*/
        public DoubleBasis WTOT_PREMIO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
        /*"77  WS-IND                        PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis WS_IND { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WINDM                         PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis WINDM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  INF                           PIC S9(009)    COMP.*/
        public IntBasis INF { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77  SUP                           PIC S9(009)    COMP.*/
        public IntBasis SUP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77  WS-QTDE-MOVTO                 PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis WS_QTDE_MOVTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WS-QTDE-CRITIC                PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis WS_QTDE_CRITIC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WS-QTDE-DUPLIC                PIC  9(007)    VALUE ZEROS.*/
        public IntBasis WS_QTDE_DUPLIC { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
        /*"77  WS-QTDE-ERRO-3027             PIC  9(007)    VALUE ZEROS.*/
        public IntBasis WS_QTDE_ERRO_3027 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
        /*"77  WS-RESULTADO                  PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis WS_RESULTADO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WS-RESTO                      PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis WS_RESTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WS-JA-TEM-CODIGO              PIC  X(001)    VALUE 'N'.*/
        public StringBasis WS_JA_TEM_CODIGO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
        /*"77  WS-MOVTO-H-DATA-REFER         PIC  9(006)    VALUE  0.*/
        public IntBasis WS_MOVTO_H_DATA_REFER { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
        /*"77  WS-FLAG-HEADER                PIC  X(001).*/
        public StringBasis WS_FLAG_HEADER { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77  WS-FLAG-TRAILER               PIC  X(001).*/
        public StringBasis WS_FLAG_TRAILER { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77  TRANSP-IS-MORNATU             PIC  9(013)V99.*/
        public DoubleBasis TRANSP_IS_MORNATU { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
        /*"77  TRANSP-IS-MORACID             PIC  9(013)V99.*/
        public DoubleBasis TRANSP_IS_MORACID { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
        /*"77  TRANSP-IS-INVPERM             PIC  9(013)V99.*/
        public DoubleBasis TRANSP_IS_INVPERM { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
        /*"77  TRANSP-IS-AMDS                PIC  9(013)V99.*/
        public DoubleBasis TRANSP_IS_AMDS { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
        /*"77  TRANSP-IS-DH                  PIC  9(013)V99.*/
        public DoubleBasis TRANSP_IS_DH { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
        /*"77  TRANSP-IS-DIT                 PIC  9(013)V99.*/
        public DoubleBasis TRANSP_IS_DIT { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
        /*"77  SISTEMAS-DATA-MOV-ABERTO-1    PIC  X(010).*/
        public StringBasis SISTEMAS_DATA_MOV_ABERTO_1 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  WHOST-OCORR-END-I             PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis WHOST_OCORR_END_I { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WHOST-COUNT                   PIC S9(009)    VALUE +0 COMP.*/
        public IntBasis WHOST_COUNT { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77  WHOST-PROP-AUTOMAT            PIC S9(009)    VALUE +0 COMP.*/
        public IntBasis WHOST_PROP_AUTOMAT { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
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
        /*"77  WHOST-QTDTIMES                PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis WHOST_QTDTIMES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WHOST-IMPSEG                  PIC S9(013)V99 VALUE +0 COMP-3*/
        public DoubleBasis WHOST_IMPSEG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77  WHOST-PRMVG                   PIC S9(013)V99 VALUE +0 COMP-3*/
        public DoubleBasis WHOST_PRMVG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77  WS-PREMIO-VGAP                PIC S9(013)V99 VALUE +0 COMP-3*/
        public DoubleBasis WS_PREMIO_VGAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
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
        /*"77  WHOST-DATA-NASCIMENTO         PIC  X(010).*/
        public StringBasis WHOST_DATA_NASCIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  WHOST-TIPO-SEGURADO           PIC  X(001).*/
        public StringBasis WHOST_TIPO_SEGURADO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
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
        /*"77  WHOST-QTDE                    PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis WHOST_QTDE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WHOST-QUANTIDADE              PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis WHOST_QUANTIDADE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WHOST-QTDE-SEGVG              PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis WHOST_QTDE_SEGVG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WHOST-QTDE-SEG                PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis WHOST_QTDE_SEG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
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
        /*"77  WHOST-COD-ENDERECO            PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis WHOST_COD_ENDERECO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WHOST-OCORR-ENDERECO          PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis WHOST_OCORR_ENDERECO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WHOST-ENDERECO                PIC  X(040)    VALUE SPACES.*/
        public StringBasis WHOST_ENDERECO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
        /*"77  WHOST-BAIRRO                  PIC  X(020)    VALUE SPACES.*/
        public StringBasis WHOST_BAIRRO { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"");
        /*"77  WHOST-CIDADE                  PIC  X(020)    VALUE SPACES.*/
        public StringBasis WHOST_CIDADE { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"");
        /*"77  WHOST-SIGLA-UF                PIC  X(002)    VALUE SPACES.*/
        public StringBasis WHOST_SIGLA_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
        /*"77  WHOST-CEP                     PIC S9(009)    VALUE +0 COMP.*/
        public IntBasis WHOST_CEP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77  WHOST-DDD                     PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis WHOST_DDD { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WHOST-TELEFONE                PIC S9(009)    VALUE +0 COMP.*/
        public IntBasis WHOST_TELEFONE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77  WHOST-RAMO-COBERTURA          PIC S9(004)    COMP   VALUE +0*/
        public IntBasis WHOST_RAMO_COBERTURA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WNL-COUNT                     PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis WNL_COUNT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WS-V0APOL-MODALIDA            PIC S9(004)    COMP.*/
        public IntBasis WS_V0APOL_MODALIDA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VIND-CODUSU                   PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis VIND_CODUSU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
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
        public IntBasis VIND_CODUSU_0 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  SUBGVGAP-COD-FONTE-ANT        PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis SUBGVGAP_COD_FONTE_ANT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  MOVIMVGA-COUNT                PIC S9(009)    VALUE +0 COMP.*/
        public IntBasis MOVIMVGA_COUNT { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77  WS-TEM-CAPITAL-PURO           PIC S9(001)    VALUE +0.*/
        public IntBasis WS_TEM_CAPITAL_PURO { get; set; } = new IntBasis(new PIC("S9", "1", "S9(001)"));
        /*"77  WS-CPF-ANT                    PIC  9(011)    VALUE ZEROS.*/
        public IntBasis WS_CPF_ANT { get; set; } = new IntBasis(new PIC("9", "11", "9(011)"));
        /*"01  FILLER.*/
        public VG1613B_FILLER_0 FILLER_0 { get; set; } = new VG1613B_FILLER_0();
        public class VG1613B_FILLER_0 : VarBasis
        {
            /*" 03 W01-I                   PIC 9(009).*/
            public IntBasis W01_I { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*" 03 W01-R-AUX REDEFINES W01-I                             PIC 9(009).*/
            private _REDEF_IntBasis _w01_r_aux { get; set; }
            public _REDEF_IntBasis W01_R_AUX
            {
                get { _w01_r_aux = new _REDEF_IntBasis(new PIC("9", "009", "9(009).")); ; _.Move(W01_I, _w01_r_aux); VarBasis.RedefinePassValue(W01_I, _w01_r_aux, W01_I); _w01_r_aux.ValueChanged += () => { _.Move(_w01_r_aux, W01_I); }; return _w01_r_aux; }
                set { VarBasis.RedefinePassValue(value, _w01_r_aux, W01_I); }
            }  //Redefines
            /*" 03 W01-INPUT-I             PIC 9(003).*/
            public IntBasis W01_INPUT_I { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
            /*" 03 W01-SEG-INPUT-ANT       PIC S9(08)V9(4).*/
            public DoubleBasis W01_SEG_INPUT_ANT { get; set; } = new DoubleBasis(new PIC("S9", "8", "S9(08)V9(4)."), 4);
            /*" 03 W01-OUTPUT-I            PIC 9(003).*/
            public IntBasis W01_OUTPUT_I { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
            /*" 03 W01-SEG-OUTPUT-ANT      PIC S9(08)V9(4).*/
            public DoubleBasis W01_SEG_OUTPUT_ANT { get; set; } = new DoubleBasis(new PIC("S9", "8", "S9(08)V9(4)."), 4);
            /*" 03 W01-SEG-INI             PIC S9(08)V9(4).*/
            public DoubleBasis W01_SEG_INI { get; set; } = new DoubleBasis(new PIC("S9", "8", "S9(08)V9(4)."), 4);
            /*" 03 W01-SEG-FIN             PIC S9(08)V9(4).*/
            public DoubleBasis W01_SEG_FIN { get; set; } = new DoubleBasis(new PIC("S9", "8", "S9(08)V9(4)."), 4);
            /*" 03 W01-QTD-ACC-OK          PIC 9(008).*/
            public IntBasis W01_QTD_ACC_OK { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*" 03 W01-QTD-ACC-NOK         PIC 9(008).*/
            public IntBasis W01_QTD_ACC_NOK { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*" 03 W01-TOT-ACC-OK-ED       PIC ZZ.ZZZ.ZZ9.*/
            public IntBasis W01_TOT_ACC_OK_ED { get; set; } = new IntBasis(new PIC("9", "8", "ZZ.ZZZ.ZZ9."));
            /*" 03 W01-TOT-ACC-NOK-ED      PIC ZZ.ZZZ.ZZ9.*/
            public IntBasis W01_TOT_ACC_NOK_ED { get; set; } = new IntBasis(new PIC("9", "8", "ZZ.ZZZ.ZZ9."));
            /*" 03 W01-TOT-TIME-ED         PIC ZZZ.ZZ9,9999-.*/
            public DoubleBasis W01_TOT_TIME_ED { get; set; } = new DoubleBasis(new PIC("9", "6", "ZZZ.ZZ9V9999-."), 5);
            /*" 03      W01-CURRENT-DATE.*/
            public VG1613B_W01_CURRENT_DATE W01_CURRENT_DATE { get; set; } = new VG1613B_W01_CURRENT_DATE();
            public class VG1613B_W01_CURRENT_DATE : VarBasis
            {
                /*"  05  W01-CDTE-ANO       PIC  9(004).*/
                public IntBasis W01_CDTE_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"  05  W01-CDTE-MES       PIC  9(002).*/
                public IntBasis W01_CDTE_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05  W01-CDTE-DIA       PIC  9(002).*/
                public IntBasis W01_CDTE_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05  W01-CDTE-HORA      PIC  9(002).*/
                public IntBasis W01_CDTE_HORA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05  W01-CDTE-MIN       PIC  9(002).*/
                public IntBasis W01_CDTE_MIN { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05  W01-CDTE-SEG       PIC  9(002).*/
                public IntBasis W01_CDTE_SEG { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05  W01-CDTE-DECSEG    PIC  9(002).*/
                public IntBasis W01_CDTE_DECSEG { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05  W01-CDTE-GREEN     PIC  X(001).*/
                public StringBasis W01_CDTE_GREEN { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"  05  W01-CDTE-GHORA     PIC  9(002).*/
                public IntBasis W01_CDTE_GHORA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05  W01-CDTE-GMIN      PIC  9(002).*/
                public IntBasis W01_CDTE_GMIN { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*" 03 W01-LIM-OCOR            PIC 9(009)      VALUE  94.*/
            }
            public IntBasis W01_LIM_OCOR { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"), 94);
            /*" 03 W01-TABELA-TOTAIS.*/
            public VG1613B_W01_TABELA_TOTAIS W01_TABELA_TOTAIS { get; set; } = new VG1613B_W01_TABELA_TOTAIS();
            public class VG1613B_W01_TABELA_TOTAIS : VarBasis
            {
                /*"  05 W01-TOT-ACC-OK       PIC 9(008)      OCCURS 94.*/
                public ListBasis<IntBasis, Int64> W01_TOT_ACC_OK { get; set; } = new ListBasis<IntBasis, Int64>(new PIC("9", "8", "9(008)"), 94);
                /*"  05 W01-TOT-ACC-NOK      PIC 9(008)      OCCURS 94.*/
                public ListBasis<IntBasis, Int64> W01_TOT_ACC_NOK { get; set; } = new ListBasis<IntBasis, Int64>(new PIC("9", "8", "9(008)"), 94);
                /*"  05 W01-TOT-TIME         PIC S9(08)V9(4) OCCURS 94.*/
                public ListBasis<DoubleBasis, double> W01_TOT_TIME { get; set; } = new ListBasis<DoubleBasis, double>(new PIC("S9", "8", "S9(08)V9(4)"), 94);
                /*" 03 W01-TABELA-TEXTO.*/
            }
            public VG1613B_W01_TABELA_TEXTO W01_TABELA_TEXTO { get; set; } = new VG1613B_W01_TABELA_TEXTO();
            public class VG1613B_W01_TABELA_TEXTO : VarBasis
            {
                /*"  05 W01-TAB-TEXTO                        OCCURS 94.*/
                public ListBasis<VG1613B_W01_TAB_TEXTO> W01_TAB_TEXTO { get; set; } = new ListBasis<VG1613B_W01_TAB_TEXTO>(94);
                public class VG1613B_W01_TAB_TEXTO : VarBasis
                {
                    /*"    10 W01-ORDEM         PIC X(002).*/
                    public StringBasis W01_ORDEM { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                    /*"    10 W01-TEXTO         PIC X(034).*/
                    public StringBasis W01_TEXTO { get; set; } = new StringBasis(new PIC("X", "34", "X(034)."), @"");
                    /*"01          WS-CHAVE-ATU.*/
                }
            }
        }
        public VG1613B_WS_CHAVE_ATU WS_CHAVE_ATU { get; set; } = new VG1613B_WS_CHAVE_ATU();
        public class VG1613B_WS_CHAVE_ATU : VarBasis
        {
            /*"    10      WS-APOLICE-ATU      PIC  9(013) VALUE ZEROS.*/
            public IntBasis WS_APOLICE_ATU { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
            /*"    10      WS-SUBGRUPO-ATU     PIC  9(004) VALUE ZEROS.*/
            public IntBasis WS_SUBGRUPO_ATU { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"01          WS-CHAVE-ANT        PIC  X(017).*/
        }
        public StringBasis WS_CHAVE_ANT { get; set; } = new StringBasis(new PIC("X", "17", "X(017)."), @"");
        /*"01          WS-CHAVE-ANT-R      REDEFINES   WS-CHAVE-ANT.*/
        private _REDEF_VG1613B_WS_CHAVE_ANT_R _ws_chave_ant_r { get; set; }
        public _REDEF_VG1613B_WS_CHAVE_ANT_R WS_CHAVE_ANT_R
        {
            get { _ws_chave_ant_r = new _REDEF_VG1613B_WS_CHAVE_ANT_R(); _.Move(WS_CHAVE_ANT, _ws_chave_ant_r); VarBasis.RedefinePassValue(WS_CHAVE_ANT, _ws_chave_ant_r, WS_CHAVE_ANT); _ws_chave_ant_r.ValueChanged += () => { _.Move(_ws_chave_ant_r, WS_CHAVE_ANT); }; return _ws_chave_ant_r; }
            set { VarBasis.RedefinePassValue(value, _ws_chave_ant_r, WS_CHAVE_ANT); }
        }  //Redefines
        public class _REDEF_VG1613B_WS_CHAVE_ANT_R : VarBasis
        {
            /*"    10      WS-APOLICE-ANT      PIC  9(013).*/
            public IntBasis WS_APOLICE_ANT { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
            /*"    10      WS-SUBGRUPO-ANT     PIC  9(004).*/
            public IntBasis WS_SUBGRUPO_ANT { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"01          WRETORNO-REG.*/

            public _REDEF_VG1613B_WS_CHAVE_ANT_R()
            {
                WS_APOLICE_ANT.ValueChanged += OnValueChanged;
                WS_SUBGRUPO_ANT.ValueChanged += OnValueChanged;
            }

        }
        public VG1613B_WRETORNO_REG WRETORNO_REG { get; set; } = new VG1613B_WRETORNO_REG();
        public class VG1613B_WRETORNO_REG : VarBasis
        {
            /*"    10      WRETORNO-NOME       PIC  X(040).*/
            public StringBasis WRETORNO_NOME { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
            /*"    10      WRETORNO-CPF        PIC  9(011).*/
            public IntBasis WRETORNO_CPF { get; set; } = new IntBasis(new PIC("9", "11", "9(011)."));
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
        public VG1613B_FILLER_1 FILLER_1 { get; set; } = new VG1613B_FILLER_1();
        public class VG1613B_FILLER_1 : VarBasis
        {
            /*" 03        WSQLCODE3           PIC S9(009) COMP.*/
            public IntBasis WSQLCODE3 { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*" 03        AC-ERROS-QTDE       PIC  9(007)    VALUE ZEROS.*/
            public IntBasis AC_ERROS_QTDE { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*" 03        AC-ERROS-VALOR      PIC  9(013)V99 VALUE ZEROS.*/
            public DoubleBasis AC_ERROS_VALOR { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
            /*" 03        AC-LIDOS-M          PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_LIDOS_M { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*" 03        AC-GRAVA-S          PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_GRAVA_S { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*" 03        AC-LIDOS            PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_LIDOS { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*" 03        AC-LIDOS-S          PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_LIDOS_S { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*" 03        AC-LIDOS-PR         PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_LIDOS_PR { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*" 03        AC-LIDOS-OP         PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_LIDOS_OP { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*" 03        AC-I-PROPOSTAVA     PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_I_PROPOSTAVA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*" 03        AC-I-OPCAOPAGVA     PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_I_OPCAOPAGVA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*" 03        AC-I-COBERPROPVA    PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_I_COBERPROPVA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*" 03        AC-U-COBERPROPVA    PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_U_COBERPROPVA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*" 03        AC-U-OPCAOPAGVA     PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_U_OPCAOPAGVA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*" 03        AC-I-PARCELVA       PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_I_PARCELVA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*" 03        AC-I-HISTCOBVA      PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_I_HISTCOBVA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*" 03        AC-I-HISTCTABI      PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_I_HISTCTABI { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*" 03        AC-GRAVA-M          PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_GRAVA_M { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*" 03        AC-GRAVA-E          PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_GRAVA_E { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*" 03        AC-GRAVA-C          PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_GRAVA_C { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*" 03        AC-GRAVA-D          PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_GRAVA_D { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*" 03        AC-GRAVA-B          PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_GRAVA_B { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*" 03        AC-GRAVA-1          PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_GRAVA_1 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*" 03        AC-GRAVA-2          PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_GRAVA_2 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*" 03        AC-GRAVA-3          PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_GRAVA_3 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*" 03        AC-GRAVA-4          PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_GRAVA_4 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*" 03        AC-GRAVA-5          PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_GRAVA_5 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*" 03        AC-GRAVA-6          PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_GRAVA_6 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*" 03        AC-GRAVA-7          PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_GRAVA_7 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*" 03        AC-GRAVA-8          PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_GRAVA_8 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*" 03        AC-GRAVA-9          PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_GRAVA_9 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*" 03        AC-GRAVA-10         PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_GRAVA_10 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*" 03        AC-GRAVA-11         PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_GRAVA_11 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*" 03        WS-EOF1             PIC  9(001) VALUE ZEROS.*/
            public IntBasis WS_EOF1 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*" 03        WS-EOF2             PIC  9(001) VALUE ZEROS.*/
            public IntBasis WS_EOF2 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*" 03        QTMES               PIC S9(005) COMP-3   VALUE +0.*/
            public IntBasis QTMES { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));
            /*" 03        RESTO               PIC S9(005) COMP-3   VALUE +0.*/
            public IntBasis RESTO { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));
            /*" 03        FL-ERRO             PIC  9(001).*/

            public SelectorBasis FL_ERRO { get; set; } = new SelectorBasis("001")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88      HOUVE-ERRO          VALUE  1. */
							new SelectorItemBasis("HOUVE_ERRO", "1"),
							/*" 88      NAO-HOUVE-ERRO      VALUE  0. */
							new SelectorItemBasis("NAO_HOUVE_ERRO", "0")
                }
            };

            /*" 03        WIMP-MORNATU-ATU    PIC S9(013)V99   COMP-3 VALUE +0.*/
            public DoubleBasis WIMP_MORNATU_ATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*" 03        WIMP-MORACID-ATU    PIC S9(013)V99   COMP-3 VALUE +0.*/
            public DoubleBasis WIMP_MORACID_ATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*" 03        WIMP-INVPERM-ATU    PIC S9(013)V99   COMP-3 VALUE +0.*/
            public DoubleBasis WIMP_INVPERM_ATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*" 03        WIMP-AMDS-ATU       PIC S9(013)V99   COMP-3 VALUE +0.*/
            public DoubleBasis WIMP_AMDS_ATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*" 03        WIMP-DH-ATU         PIC S9(013)V99   COMP-3 VALUE +0.*/
            public DoubleBasis WIMP_DH_ATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*" 03        WIMP-DIT-ATU        PIC S9(013)V99   COMP-3 VALUE +0.*/
            public DoubleBasis WIMP_DIT_ATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*" 03        WPRIM-VEZ           PIC  9(004)             VALUE  0.*/
            public IntBasis WPRIM_VEZ { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*" 03        WCONTADOR           PIC  9(004)             VALUE  0.*/
            public IntBasis WCONTADOR { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*" 03        WCLIENTE-SEG        PIC  X(001).*/
            public StringBasis WCLIENTE_SEG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*" 03        WCLIENTE-PROP       PIC  X(001).*/
            public StringBasis WCLIENTE_PROP { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*" 03        WCLIENTE-MOV        PIC  X(001).*/
            public StringBasis WCLIENTE_MOV { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*" 03        WREG-DUPLICA        PIC  9(007)             VALUE  0.*/
            public IntBasis WREG_DUPLICA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*" 03        WFLAG               PIC  9(001)             VALUE  0.*/
            public IntBasis WFLAG { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*" 03            WS-TIME         PIC  X(008).*/
            public StringBasis WS_TIME { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*" 03            WS-W01DTSQL.*/
            public VG1613B_WS_W01DTSQL WS_W01DTSQL { get; set; } = new VG1613B_WS_W01DTSQL();
            public class VG1613B_WS_W01DTSQL : VarBasis
            {
                /*"  05          WS-W01SCSQL         PIC  9(002).*/
                public IntBasis WS_W01SCSQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05          WS-W01AASQL         PIC  9(002).*/
                public IntBasis WS_W01AASQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05          WS-W01T1SQL         PIC  X(001) VALUE '-'.*/
                public StringBasis WS_W01T1SQL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"  05          WS-W01MMSQL         PIC  9(002).*/
                public IntBasis WS_W01MMSQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05          WS-W01T2SQL         PIC  X(001) VALUE '-'.*/
                public StringBasis WS_W01T2SQL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"  05          WS-W01DDSQL         PIC  9(002).*/
                public IntBasis WS_W01DDSQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*" 03            WS-W02DTSQL.*/
            }
            public VG1613B_WS_W02DTSQL WS_W02DTSQL { get; set; } = new VG1613B_WS_W02DTSQL();
            public class VG1613B_WS_W02DTSQL : VarBasis
            {
                /*"  05          WS-W02AASQL         PIC  9(004).*/
                public IntBasis WS_W02AASQL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"  05          WS-W02T1SQL         PIC  X(001) VALUE '-'.*/
                public StringBasis WS_W02T1SQL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"  05          WS-W02MMSQL         PIC  9(002).*/
                public IntBasis WS_W02MMSQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05          WS-W02T2SQL         PIC  X(001) VALUE '-'.*/
                public StringBasis WS_W02T2SQL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"  05          WS-W02DDSQL         PIC  9(002).*/
                public IntBasis WS_W02DDSQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*" 03            WS-W03DTSQL.*/
            }
            public VG1613B_WS_W03DTSQL WS_W03DTSQL { get; set; } = new VG1613B_WS_W03DTSQL();
            public class VG1613B_WS_W03DTSQL : VarBasis
            {
                /*"  05          WS-W03AASQL         PIC  9(004).*/
                public IntBasis WS_W03AASQL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"  05          WS-W03T1SQL         PIC  X(001) VALUE '-'.*/
                public StringBasis WS_W03T1SQL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"  05          WS-W03MMSQL         PIC  9(002).*/
                public IntBasis WS_W03MMSQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05          WS-W03T2SQL         PIC  X(001) VALUE '-'.*/
                public StringBasis WS_W03T2SQL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"  05          WS-W03DDSQL         PIC  9(002).*/
                public IntBasis WS_W03DDSQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*" 03            WS-W05DTREF.*/
            }
            public VG1613B_WS_W05DTREF WS_W05DTREF { get; set; } = new VG1613B_WS_W05DTREF();
            public class VG1613B_WS_W05DTREF : VarBasis
            {
                /*"   05          WS-W05AAREF         PIC  9(004).*/
                public IntBasis WS_W05AAREF { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"   05          WS-W05MMREF         PIC  9(002).*/
                public IntBasis WS_W05MMREF { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"   05          WS-W05DDREF         PIC  9(002).*/
                public IntBasis WS_W05DDREF { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*" 03            WS-W02DTSQL-GERA.*/
            }
            public VG1613B_WS_W02DTSQL_GERA WS_W02DTSQL_GERA { get; set; } = new VG1613B_WS_W02DTSQL_GERA();
            public class VG1613B_WS_W02DTSQL_GERA : VarBasis
            {
                /*"  05          WS-W02AASQL-G       PIC  9(004).*/
                public IntBasis WS_W02AASQL_G { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"  05          WS-W02T1SQL-G       PIC  X(001) VALUE '-'.*/
                public StringBasis WS_W02T1SQL_G { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"  05          WS-W02MMSQL-G       PIC  9(002).*/
                public IntBasis WS_W02MMSQL_G { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05          WS-W02T2SQL-G       PIC  X(001) VALUE '-'.*/
                public StringBasis WS_W02T2SQL_G { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"  05          WS-W02DDSQL-G       PIC  9(002).*/
                public IntBasis WS_W02DDSQL_G { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*" 03            WK-DATA1.*/
            }
            public VG1613B_WK_DATA1 WK_DATA1 { get; set; } = new VG1613B_WK_DATA1();
            public class VG1613B_WK_DATA1 : VarBasis
            {
                /*"  05          WS-SEC1           PIC  9(002).*/
                public IntBasis WS_SEC1 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05          WK-ANO1           PIC  9(002).*/
                public IntBasis WK_ANO1 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05          FILLER            PIC  X(001).*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"  05          WK-MES1           PIC  9(002).*/
                public IntBasis WK_MES1 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05          FILLER            PIC  X(001).*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"  05          WK-DIA1           PIC  9(002).*/
                public IntBasis WK_DIA1 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*" 03            WS-MES-DIA-HOJE   PIC  9(004).*/
            }
            public IntBasis WS_MES_DIA_HOJE { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*" 03            WS-MES-DIA-NASC   PIC  9(004).*/
            public IntBasis WS_MES_DIA_NASC { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*" 03            WS-DATA-HOJE      PIC  X(010).*/
            public StringBasis WS_DATA_HOJE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*" 03            WS-DATA-HOJE-R    REDEFINES WS-DATA-HOJE.*/
            private _REDEF_VG1613B_WS_DATA_HOJE_R _ws_data_hoje_r { get; set; }
            public _REDEF_VG1613B_WS_DATA_HOJE_R WS_DATA_HOJE_R
            {
                get { _ws_data_hoje_r = new _REDEF_VG1613B_WS_DATA_HOJE_R(); _.Move(WS_DATA_HOJE, _ws_data_hoje_r); VarBasis.RedefinePassValue(WS_DATA_HOJE, _ws_data_hoje_r, WS_DATA_HOJE); _ws_data_hoje_r.ValueChanged += () => { _.Move(_ws_data_hoje_r, WS_DATA_HOJE); }; return _ws_data_hoje_r; }
                set { VarBasis.RedefinePassValue(value, _ws_data_hoje_r, WS_DATA_HOJE); }
            }  //Redefines
            public class _REDEF_VG1613B_WS_DATA_HOJE_R : VarBasis
            {
                /*"  05          WS-ANO-HOJE       PIC  9(004).*/
                public IntBasis WS_ANO_HOJE { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"  05          FILLER            PIC  X(001).*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"  05          WS-MES-HOJE       PIC  9(002).*/
                public IntBasis WS_MES_HOJE { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05          FILLER            PIC  X(001).*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"  05          WS-DIA-HOJE       PIC  9(002).*/
                public IntBasis WS_DIA_HOJE { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*" 03            WS-DATA-NASC      PIC  X(010).*/

                public _REDEF_VG1613B_WS_DATA_HOJE_R()
                {
                    WS_ANO_HOJE.ValueChanged += OnValueChanged;
                    FILLER_4.ValueChanged += OnValueChanged;
                    WS_MES_HOJE.ValueChanged += OnValueChanged;
                    FILLER_5.ValueChanged += OnValueChanged;
                    WS_DIA_HOJE.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WS_DATA_NASC { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*" 03            WS-DATA-NASC-R    REDEFINES WS-DATA-NASC.*/
            private _REDEF_VG1613B_WS_DATA_NASC_R _ws_data_nasc_r { get; set; }
            public _REDEF_VG1613B_WS_DATA_NASC_R WS_DATA_NASC_R
            {
                get { _ws_data_nasc_r = new _REDEF_VG1613B_WS_DATA_NASC_R(); _.Move(WS_DATA_NASC, _ws_data_nasc_r); VarBasis.RedefinePassValue(WS_DATA_NASC, _ws_data_nasc_r, WS_DATA_NASC); _ws_data_nasc_r.ValueChanged += () => { _.Move(_ws_data_nasc_r, WS_DATA_NASC); }; return _ws_data_nasc_r; }
                set { VarBasis.RedefinePassValue(value, _ws_data_nasc_r, WS_DATA_NASC); }
            }  //Redefines
            public class _REDEF_VG1613B_WS_DATA_NASC_R : VarBasis
            {
                /*"  05          WS-ANO-NASC       PIC  9(004).*/
                public IntBasis WS_ANO_NASC { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"  05          FILLER            PIC  X(001).*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"  05          WS-MES-NASC       PIC  9(002).*/
                public IntBasis WS_MES_NASC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05          FILLER            PIC  X(001).*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"  05          WS-DIA-NASC       PIC  9(002).*/
                public IntBasis WS_DIA_NASC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*" 03            WS-DATA-ADESAO    PIC  9(008).*/

                public _REDEF_VG1613B_WS_DATA_NASC_R()
                {
                    WS_ANO_NASC.ValueChanged += OnValueChanged;
                    FILLER_6.ValueChanged += OnValueChanged;
                    WS_MES_NASC.ValueChanged += OnValueChanged;
                    FILLER_7.ValueChanged += OnValueChanged;
                    WS_DIA_NASC.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WS_DATA_ADESAO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*" 03            WS-DATA-ADESAO-R  REDEFINES               WS-DATA-ADESAO.*/
            private _REDEF_VG1613B_WS_DATA_ADESAO_R _ws_data_adesao_r { get; set; }
            public _REDEF_VG1613B_WS_DATA_ADESAO_R WS_DATA_ADESAO_R
            {
                get { _ws_data_adesao_r = new _REDEF_VG1613B_WS_DATA_ADESAO_R(); _.Move(WS_DATA_ADESAO, _ws_data_adesao_r); VarBasis.RedefinePassValue(WS_DATA_ADESAO, _ws_data_adesao_r, WS_DATA_ADESAO); _ws_data_adesao_r.ValueChanged += () => { _.Move(_ws_data_adesao_r, WS_DATA_ADESAO); }; return _ws_data_adesao_r; }
                set { VarBasis.RedefinePassValue(value, _ws_data_adesao_r, WS_DATA_ADESAO); }
            }  //Redefines
            public class _REDEF_VG1613B_WS_DATA_ADESAO_R : VarBasis
            {
                /*"  05          WS-ANO-ADESAO     PIC  9(004).*/
                public IntBasis WS_ANO_ADESAO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"  05          WS-MES-ADESAO     PIC  9(002).*/
                public IntBasis WS_MES_ADESAO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05          WS-DIA-ADESAO     PIC  9(002).*/
                public IntBasis WS_DIA_ADESAO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*" 03            WS-DATA-AUX.*/

                public _REDEF_VG1613B_WS_DATA_ADESAO_R()
                {
                    WS_ANO_ADESAO.ValueChanged += OnValueChanged;
                    WS_MES_ADESAO.ValueChanged += OnValueChanged;
                    WS_DIA_ADESAO.ValueChanged += OnValueChanged;
                }

            }
            public VG1613B_WS_DATA_AUX WS_DATA_AUX { get; set; } = new VG1613B_WS_DATA_AUX();
            public class VG1613B_WS_DATA_AUX : VarBasis
            {
                /*"  05          WS-ANO-AUX          PIC  9(004).*/
                public IntBasis WS_ANO_AUX { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"  05          WS-TRA1-AUX         PIC  X(001) VALUE '-'.*/
                public StringBasis WS_TRA1_AUX { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"  05          WS-MES-AUX          PIC  9(002).*/
                public IntBasis WS_MES_AUX { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05          WS-TRA2-AUX         PIC  X(001) VALUE '-'.*/
                public StringBasis WS_TRA2_AUX { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"  05          WS-DIA-AUX          PIC  9(002).*/
                public IntBasis WS_DIA_AUX { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*" 03            WS-DATA-INICIAL.*/
            }
            public VG1613B_WS_DATA_INICIAL WS_DATA_INICIAL { get; set; } = new VG1613B_WS_DATA_INICIAL();
            public class VG1613B_WS_DATA_INICIAL : VarBasis
            {
                /*"  05          WS-ANO-INI          PIC  9(004).*/
                public IntBasis WS_ANO_INI { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"  05          WS-TRA1-INI         PIC  X(001) VALUE '-'.*/
                public StringBasis WS_TRA1_INI { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"  05          WS-MES-INI          PIC  9(002).*/
                public IntBasis WS_MES_INI { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05          WS-TRA2-INI         PIC  X(001) VALUE '-'.*/
                public StringBasis WS_TRA2_INI { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"  05          WS-DIA-INI          PIC  9(002).*/
                public IntBasis WS_DIA_INI { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*" 03            WS-DATA-FINAL.*/
            }
            public VG1613B_WS_DATA_FINAL WS_DATA_FINAL { get; set; } = new VG1613B_WS_DATA_FINAL();
            public class VG1613B_WS_DATA_FINAL : VarBasis
            {
                /*"  05          WS-ANO-FIM          PIC  9(004).*/
                public IntBasis WS_ANO_FIM { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"  05          WS-TRA1-FIM         PIC  X(001) VALUE '-'.*/
                public StringBasis WS_TRA1_FIM { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"  05          WS-MES-FIM          PIC  9(002).*/
                public IntBasis WS_MES_FIM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05          WS-TRA2-FIM         PIC  X(001) VALUE '-'.*/
                public StringBasis WS_TRA2_FIM { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"  05          WS-DIA-FIM          PIC  9(002).*/
                public IntBasis WS_DIA_FIM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*" 03            WS-DATA-SQL.*/
            }
            public VG1613B_WS_DATA_SQL WS_DATA_SQL { get; set; } = new VG1613B_WS_DATA_SQL();
            public class VG1613B_WS_DATA_SQL : VarBasis
            {
                /*"  05          WS-SEC-SQL          PIC  9(002) VALUE 19.*/
                public IntBasis WS_SEC_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"), 19);
                /*"  05          WS-ANO-SQL          PIC  9(002).*/
                public IntBasis WS_ANO_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05          WS-TRA1             PIC  X(001) VALUE '-'.*/
                public StringBasis WS_TRA1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"  05          WS-MES-SQL          PIC  9(002).*/
                public IntBasis WS_MES_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05          WS-TRA2             PIC  X(001) VALUE '-'.*/
                public StringBasis WS_TRA2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"  05          WS-DIA-SQL          PIC  9(002).*/
                public IntBasis WS_DIA_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*" 03         WS-DATA.*/
            }
            public VG1613B_WS_DATA WS_DATA { get; set; } = new VG1613B_WS_DATA();
            public class VG1613B_WS_DATA : VarBasis
            {
                /*"  05       WS-SEC            PIC  9(002)    VALUE 19.*/
                public IntBasis WS_SEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"), 19);
                /*"  05       WS-ANO            PIC  9(002).*/
                public IntBasis WS_ANO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05       FILLER            PIC  X(001).*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"  05       WS-MES            PIC  9(002).*/
                public IntBasis WS_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05       FILLER            PIC  X(001).*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"  05       WS-DIA            PIC  9(002).*/
                public IntBasis WS_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*" 03         W01GRUPOCOTA      PIC  9(009)    VALUE ZEROS.*/
            }
            public IntBasis W01GRUPOCOTA { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*" 03         FILLER            REDEFINES      W01GRUPOCOTA.*/
            private _REDEF_VG1613B_FILLER_10 _filler_10 { get; set; }
            public _REDEF_VG1613B_FILLER_10 FILLER_10
            {
                get { _filler_10 = new _REDEF_VG1613B_FILLER_10(); _.Move(W01GRUPOCOTA, _filler_10); VarBasis.RedefinePassValue(W01GRUPOCOTA, _filler_10, W01GRUPOCOTA); _filler_10.ValueChanged += () => { _.Move(_filler_10, W01GRUPOCOTA); }; return _filler_10; }
                set { VarBasis.RedefinePassValue(value, _filler_10, W01GRUPOCOTA); }
            }  //Redefines
            public class _REDEF_VG1613B_FILLER_10 : VarBasis
            {
                /*"  05       W01-GRUPO         PIC  9(006).*/
                public IntBasis W01_GRUPO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"  05       W01-COTA          PIC  9(003).*/
                public IntBasis W01_COTA { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*" 03         W01DTCSP          PIC  9(008)    VALUE ZEROS.*/

                public _REDEF_VG1613B_FILLER_10()
                {
                    W01_GRUPO.ValueChanged += OnValueChanged;
                    W01_COTA.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis W01DTCSP { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*" 03         FILLER            REDEFINES      W01DTCSP.*/
            private _REDEF_VG1613B_FILLER_11 _filler_11 { get; set; }
            public _REDEF_VG1613B_FILLER_11 FILLER_11
            {
                get { _filler_11 = new _REDEF_VG1613B_FILLER_11(); _.Move(W01DTCSP, _filler_11); VarBasis.RedefinePassValue(W01DTCSP, _filler_11, W01DTCSP); _filler_11.ValueChanged += () => { _.Move(_filler_11, W01DTCSP); }; return _filler_11; }
                set { VarBasis.RedefinePassValue(value, _filler_11, W01DTCSP); }
            }  //Redefines
            public class _REDEF_VG1613B_FILLER_11 : VarBasis
            {
                /*"  05       W01DDCSP          PIC  9(002).*/
                public IntBasis W01DDCSP { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05       W01MMCSP          PIC  9(002).*/
                public IntBasis W01MMCSP { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05       W01SCCSP          PIC  9(002).*/
                public IntBasis W01SCCSP { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05       W01AACSP          PIC  9(002).*/
                public IntBasis W01AACSP { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*" 03         W02DTCSP          PIC  9(008)    VALUE ZEROS.*/

                public _REDEF_VG1613B_FILLER_11()
                {
                    W01DDCSP.ValueChanged += OnValueChanged;
                    W01MMCSP.ValueChanged += OnValueChanged;
                    W01SCCSP.ValueChanged += OnValueChanged;
                    W01AACSP.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis W02DTCSP { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*" 03         FILLER            REDEFINES      W02DTCSP.*/
            private _REDEF_VG1613B_FILLER_12 _filler_12 { get; set; }
            public _REDEF_VG1613B_FILLER_12 FILLER_12
            {
                get { _filler_12 = new _REDEF_VG1613B_FILLER_12(); _.Move(W02DTCSP, _filler_12); VarBasis.RedefinePassValue(W02DTCSP, _filler_12, W02DTCSP); _filler_12.ValueChanged += () => { _.Move(_filler_12, W02DTCSP); }; return _filler_12; }
                set { VarBasis.RedefinePassValue(value, _filler_12, W02DTCSP); }
            }  //Redefines
            public class _REDEF_VG1613B_FILLER_12 : VarBasis
            {
                /*"  05       W02DDCSP          PIC  9(002).*/
                public IntBasis W02DDCSP { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05       W02MMCSP          PIC  9(002).*/
                public IntBasis W02MMCSP { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05       W02SCCSP          PIC  9(002).*/
                public IntBasis W02SCCSP { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05       W02AACSP          PIC  9(002).*/
                public IntBasis W02AACSP { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*" 03         WS-DTREF          PIC  9(006)    VALUE ZEROS.*/

                public _REDEF_VG1613B_FILLER_12()
                {
                    W02DDCSP.ValueChanged += OnValueChanged;
                    W02MMCSP.ValueChanged += OnValueChanged;
                    W02SCCSP.ValueChanged += OnValueChanged;
                    W02AACSP.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WS_DTREF { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*" 03         FILLER            REDEFINES      WS-DTREF.*/
            private _REDEF_VG1613B_FILLER_13 _filler_13 { get; set; }
            public _REDEF_VG1613B_FILLER_13 FILLER_13
            {
                get { _filler_13 = new _REDEF_VG1613B_FILLER_13(); _.Move(WS_DTREF, _filler_13); VarBasis.RedefinePassValue(WS_DTREF, _filler_13, WS_DTREF); _filler_13.ValueChanged += () => { _.Move(_filler_13, WS_DTREF); }; return _filler_13; }
                set { VarBasis.RedefinePassValue(value, _filler_13, WS_DTREF); }
            }  //Redefines
            public class _REDEF_VG1613B_FILLER_13 : VarBasis
            {
                /*"  05       WS-REF-ANO        PIC  9(004).*/
                public IntBasis WS_REF_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"  05       WS-REF-MES        PIC  9(002).*/
                public IntBasis WS_REF_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*" 03         WS-DTREF-SQL      PIC  X(05).*/

                public _REDEF_VG1613B_FILLER_13()
                {
                    WS_REF_ANO.ValueChanged += OnValueChanged;
                    WS_REF_MES.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WS_DTREF_SQL { get; set; } = new StringBasis(new PIC("X", "5", "X(05)."), @"");
            /*" 03         FILLER            REDEFINES      WS-DTREF-SQL.*/
            private _REDEF_VG1613B_FILLER_14 _filler_14 { get; set; }
            public _REDEF_VG1613B_FILLER_14 FILLER_14
            {
                get { _filler_14 = new _REDEF_VG1613B_FILLER_14(); _.Move(WS_DTREF_SQL, _filler_14); VarBasis.RedefinePassValue(WS_DTREF_SQL, _filler_14, WS_DTREF_SQL); _filler_14.ValueChanged += () => { _.Move(_filler_14, WS_DTREF_SQL); }; return _filler_14; }
                set { VarBasis.RedefinePassValue(value, _filler_14, WS_DTREF_SQL); }
            }  //Redefines
            public class _REDEF_VG1613B_FILLER_14 : VarBasis
            {
                /*"  05       WS-REF-ANO-SQL    PIC  9(004).*/
                public IntBasis WS_REF_ANO_SQL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"  05       WS-REF-TRA1-SQL   PIC  X(001).*/
                public StringBasis WS_REF_TRA1_SQL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"  05       WS-REF-MES-SQL    PIC  9(002).*/
                public IntBasis WS_REF_MES_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05       WS-REF-TRA2-SQL   PIC  X(001).*/
                public StringBasis WS_REF_TRA2_SQL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"  05       WS-REF-DIA-SQL    PIC  9(002).*/
                public IntBasis WS_REF_DIA_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*" 03        WPRMTOT                  PIC S9(013)V99                                       VALUE +0 COMP-3.*/

                public _REDEF_VG1613B_FILLER_14()
                {
                    WS_REF_ANO_SQL.ValueChanged += OnValueChanged;
                    WS_REF_TRA1_SQL.ValueChanged += OnValueChanged;
                    WS_REF_MES_SQL.ValueChanged += OnValueChanged;
                    WS_REF_TRA2_SQL.ValueChanged += OnValueChanged;
                    WS_REF_DIA_SQL.ValueChanged += OnValueChanged;
                }

            }
            public DoubleBasis WPRMTOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*" 03        PARCEL-SEG               PIC  9(004) VALUE ZEROS.*/
            public IntBasis PARCEL_SEG { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*" 03        PARCEL-PROP              PIC  9(004) VALUE ZEROS.*/
            public IntBasis PARCEL_PROP { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*" 03        CPF-SEG-ANT              PIC  9(014) VALUE ZEROS.*/
            public IntBasis CPF_SEG_ANT { get; set; } = new IntBasis(new PIC("9", "14", "9(014)"));
            /*" 03        GRUPO-SEG-ANT            PIC  9(009) VALUE ZEROS.*/
            public IntBasis GRUPO_SEG_ANT { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*" 03        COTA-SEG-ANT             PIC  9(009) VALUE ZEROS.*/
            public IntBasis COTA_SEG_ANT { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*" 03        AC-EMITIDOS              PIC  9(007) VALUE 0.*/
            public IntBasis AC_EMITIDOS { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*" 03        AC-SOLICITADOS           PIC  9(007) VALUE 0.*/
            public IntBasis AC_SOLICITADOS { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*" 03        W-LIDOS                  PIC  9(007) VALUE 0.*/
            public IntBasis W_LIDOS { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*" 03        WAC-LIDOS                PIC  9(007) VALUE 0.*/
            public IntBasis WAC_LIDOS { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*" 03        W-GRAVADOS               PIC  9(007) VALUE 0.*/
            public IntBasis W_GRAVADOS { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*" 03        FILLER.*/
            public VG1613B_FILLER_15 FILLER_15 { get; set; } = new VG1613B_FILLER_15();
            public class VG1613B_FILLER_15 : VarBasis
            {
                /*"  05      WTEM-NRPARCEL            PIC  X(003) VALUE 'NAO'.*/
                public StringBasis WTEM_NRPARCEL { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
                /*"  05      WTEM-SEGURVGA            PIC  X(003) VALUE 'NAO'.*/
                public StringBasis WTEM_SEGURVGA { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
                /*"  05      WTEM-EMPRES              PIC  X(003) VALUE 'NAO'.*/
                public StringBasis WTEM_EMPRES { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
                /*"  05      WFIM-SUBGVGAP            PIC  X(003) VALUE 'NAO'.*/
                public StringBasis WFIM_SUBGVGAP { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
                /*"  05      WGERA-PARCELA            PIC  X(003) VALUE 'NAO'.*/
                public StringBasis WGERA_PARCELA { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
                /*"  05      WTEM-INTERVALO           PIC  X(003) VALUE 'NAO'.*/
                public StringBasis WTEM_INTERVALO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
                /*"  05      WTEM-HISTCOBVA           PIC  X(003) VALUE 'NAO'.*/
                public StringBasis WTEM_HISTCOBVA { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
                /*"  05      WTEM-HISTCONTABILVA      PIC  X(003) VALUE 'NAO'.*/
                public StringBasis WTEM_HISTCONTABILVA { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
                /*"  05      WTEM-HISTCONTABILVA2     PIC  X(003) VALUE 'NAO'.*/
                public StringBasis WTEM_HISTCONTABILVA2 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
                /*"  05      WTEM-COBERPROPVA         PIC  X(003) VALUE 'NAO'.*/
                public StringBasis WTEM_COBERPROPVA { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
                /*"  05      WTEM-SEGURADO            PIC  X(003) VALUE 'NAO'.*/
                public StringBasis WTEM_SEGURADO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
                /*"  05      WTEM-CLIENTE             PIC  X(003) VALUE 'NAO'.*/
                public StringBasis WTEM_CLIENTE { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
                /*"  05      WTEM-SUBGVGAP            PIC  X(003) VALUE 'NAO'.*/
                public StringBasis WTEM_SUBGVGAP { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
                /*"  05      WTEM-ENDERECO            PIC  X(003) VALUE 'NAO'.*/
                public StringBasis WTEM_ENDERECO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
                /*"  05      FIM-MOVIMENTO            PIC  X(003) VALUE 'NAO'.*/
                public StringBasis FIM_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
                /*"  05      FIM-SORT                 PIC  X(003) VALUE 'NAO'.*/
                public StringBasis FIM_SORT { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
                /*"  05      EH-ARQUIVO-VAZIO         PIC  X(003) VALUE 'NAO'.*/
                public StringBasis EH_ARQUIVO_VAZIO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
                /*"  05      FLAG-WFIM-SEGURADO             PIC  9(001) VALUE 0.*/

                public SelectorBasis FLAG_WFIM_SEGURADO { get; set; } = new SelectorBasis("001", "0")
                {
                    Items = new List<SelectorItemBasis> {
                            /*" 88    FIM-SEGURADO                   VALUE 1. */
							new SelectorItemBasis("FIM_SEGURADO", "1")
                }
                };

                /*" 03      WABEND.*/
            }
            public VG1613B_WABEND WABEND { get; set; } = new VG1613B_WABEND();
            public class VG1613B_WABEND : VarBasis
            {
                /*"  05      FILLER              PIC  X(010) VALUE         ' VG1613B'.*/
                public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" VG1613B");
                /*"  05      FILLER              PIC  X(028) VALUE         ' *** ERRO  EXEC SQL  NUMERO '.*/
                public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @" *** ERRO  EXEC SQL  NUMERO ");
                /*"  05      WNR-EXEC-SQL        PIC  X(004) VALUE '0000'.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"0000");
                /*"  05      FILLER              PIC  X(017) VALUE         ' *** PARAGRAFO = '.*/
                public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "17", "X(017)"), @" *** PARAGRAFO = ");
                /*"  05      PARAGRAFO           PIC  X(030) VALUE SPACES.*/
                public StringBasis PARAGRAFO { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"");
                /*"  05      FILLER              PIC  X(014) VALUE         '    SQLCODE = '.*/
                public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE = ");
                /*"  05      WSQLCODE            PIC  ZZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
                /*"  05      FILLER              PIC  X(014) VALUE         '    SQLCODE1= '.*/
                public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE1= ");
                /*"  05      WSQLCODE1           PIC  ZZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE1 { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
                /*"  05      FILLER              PIC  X(014) VALUE         '    SQLCODE2= '.*/
                public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE2= ");
                /*"  05      WSQLCODE2           PIC  ZZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE2 { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
                /*" 03         WSQLERRO.*/
            }
            public VG1613B_WSQLERRO WSQLERRO { get; set; } = new VG1613B_WSQLERRO();
            public class VG1613B_WSQLERRO : VarBasis
            {
                /*"  05         FILLER               PIC  X(014) VALUE            ' *** SQLERRMC '.*/
                public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @" *** SQLERRMC ");
                /*"  05         WSQLERRMC            PIC  X(070) VALUE  SPACES.*/
                public StringBasis WSQLERRMC { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"");
                /*" 03  W-NUMR-TITULO                  PIC  9(013)   VALUE ZEROS.*/
            }
            public IntBasis W_NUMR_TITULO { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
            /*" 03  FILLER                         REDEFINES    W-NUMR-TITULO.*/
            private _REDEF_VG1613B_FILLER_23 _filler_23 { get; set; }
            public _REDEF_VG1613B_FILLER_23 FILLER_23
            {
                get { _filler_23 = new _REDEF_VG1613B_FILLER_23(); _.Move(W_NUMR_TITULO, _filler_23); VarBasis.RedefinePassValue(W_NUMR_TITULO, _filler_23, W_NUMR_TITULO); _filler_23.ValueChanged += () => { _.Move(_filler_23, W_NUMR_TITULO); }; return _filler_23; }
                set { VarBasis.RedefinePassValue(value, _filler_23, W_NUMR_TITULO); }
            }  //Redefines
            public class _REDEF_VG1613B_FILLER_23 : VarBasis
            {
                /*"     05    WTITL-ZEROS              PIC  9(002).*/
                public IntBasis WTITL_ZEROS { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"     05    WTITL-SEQUENCIA          PIC  9(010).*/
                public IntBasis WTITL_SEQUENCIA { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
                /*"     05    WTITL-DIGITO             PIC  9(001).*/
                public IntBasis WTITL_DIGITO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*" 03  DPARM01X.*/

                public _REDEF_VG1613B_FILLER_23()
                {
                    WTITL_ZEROS.ValueChanged += OnValueChanged;
                    WTITL_SEQUENCIA.ValueChanged += OnValueChanged;
                    WTITL_DIGITO.ValueChanged += OnValueChanged;
                }

            }
            public VG1613B_DPARM01X DPARM01X { get; set; } = new VG1613B_DPARM01X();
            public class VG1613B_DPARM01X : VarBasis
            {
                /*"     05            DPARM01          PIC  9(010).*/
                public IntBasis DPARM01 { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
                /*"     05            DPARM01-R        REDEFINES   DPARM01.*/
                private _REDEF_VG1613B_DPARM01_R _dparm01_r { get; set; }
                public _REDEF_VG1613B_DPARM01_R DPARM01_R
                {
                    get { _dparm01_r = new _REDEF_VG1613B_DPARM01_R(); _.Move(DPARM01, _dparm01_r); VarBasis.RedefinePassValue(DPARM01, _dparm01_r, DPARM01); _dparm01_r.ValueChanged += () => { _.Move(_dparm01_r, DPARM01); }; return _dparm01_r; }
                    set { VarBasis.RedefinePassValue(value, _dparm01_r, DPARM01); }
                }  //Redefines
                public class _REDEF_VG1613B_DPARM01_R : VarBasis
                {
                    /*"       10          DPARM01-1        PIC  9(001).*/
                    public IntBasis DPARM01_1 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"       10          DPARM01-2        PIC  9(001).*/
                    public IntBasis DPARM01_2 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"       10          DPARM01-3        PIC  9(001).*/
                    public IntBasis DPARM01_3 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"       10          DPARM01-4        PIC  9(001).*/
                    public IntBasis DPARM01_4 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"       10          DPARM01-5        PIC  9(001).*/
                    public IntBasis DPARM01_5 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"       10          DPARM01-6        PIC  9(001).*/
                    public IntBasis DPARM01_6 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"       10          DPARM01-7        PIC  9(001).*/
                    public IntBasis DPARM01_7 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"       10          DPARM01-8        PIC  9(001).*/
                    public IntBasis DPARM01_8 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"       10          DPARM01-9        PIC  9(001).*/
                    public IntBasis DPARM01_9 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"       10          DPARM01-10       PIC  9(001).*/
                    public IntBasis DPARM01_10 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"     05            DPARM01-D1       PIC  9(001).*/

                    public _REDEF_VG1613B_DPARM01_R()
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
                /*"     05            DPARM01-RC       PIC S9(004) COMP VALUE +0.*/
                public IntBasis DPARM01_RC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*" 03        FILLER.*/
            }
            public VG1613B_FILLER_24 FILLER_24 { get; set; } = new VG1613B_FILLER_24();
            public class VG1613B_FILLER_24 : VarBasis
            {
                /*"   05      AUX-MORTE-NATURAL        PIC  9(013)V99.*/
                public DoubleBasis AUX_MORTE_NATURAL { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"   05      AUX-MORTE-ACIDENTAL      PIC  9(013)V99.*/
                public DoubleBasis AUX_MORTE_ACIDENTAL { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"   05      AUX-INV-PERMANENTE       PIC  9(013)V99.*/
                public DoubleBasis AUX_INV_PERMANENTE { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"   05      AUX-AMDS                 PIC  9(013)V99.*/
                public DoubleBasis AUX_AMDS { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"   05      AUX-DIARIA-HOSP          PIC  9(013)V99.*/
                public DoubleBasis AUX_DIARIA_HOSP { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"   05      AUX-DIARIA-INT           PIC  9(013)V99.*/
                public DoubleBasis AUX_DIARIA_INT { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"   05      AUX-DESPESA-MED          PIC  9(013)V99.*/
                public DoubleBasis AUX_DESPESA_MED { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"   05      AUX-TIPO-CLIENTE         PIC  X(030).*/
                public StringBasis AUX_TIPO_CLIENTE { get; set; } = new StringBasis(new PIC("X", "30", "X(030)."), @"");
                /*"   05      AUX-TIPO-IMPORT          PIC  X(030).*/
                public StringBasis AUX_TIPO_IMPORT { get; set; } = new StringBasis(new PIC("X", "30", "X(030)."), @"");
                /*"   05      AUX-OUTROS               PIC  X(001) VALUE SPACES.*/
                public StringBasis AUX_OUTROS { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"   05      I                        PIC  9(002) VALUE ZEROS.*/
                public IntBasis I { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*" 03        WDATA-REL           PIC  X(010)  VALUE SPACES.*/
            }
            public StringBasis WDATA_REL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*" 03        FILLER              REDEFINES    WDATA-REL.*/
            private _REDEF_VG1613B_FILLER_25 _filler_25 { get; set; }
            public _REDEF_VG1613B_FILLER_25 FILLER_25
            {
                get { _filler_25 = new _REDEF_VG1613B_FILLER_25(); _.Move(WDATA_REL, _filler_25); VarBasis.RedefinePassValue(WDATA_REL, _filler_25, WDATA_REL); _filler_25.ValueChanged += () => { _.Move(_filler_25, WDATA_REL); }; return _filler_25; }
                set { VarBasis.RedefinePassValue(value, _filler_25, WDATA_REL); }
            }  //Redefines
            public class _REDEF_VG1613B_FILLER_25 : VarBasis
            {
                /*"  05      WDAT-REL-SEC        PIC  9(002).*/
                public IntBasis WDAT_REL_SEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05      WDAT-REL-ANO        PIC  9(002).*/
                public IntBasis WDAT_REL_ANO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05      FILLER              PIC  X(001).*/
                public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"  05      WDAT-REL-MES        PIC  9(002).*/
                public IntBasis WDAT_REL_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05      FILLER              PIC  X(001).*/
                public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"  05      WDAT-REL-DIA        PIC  9(002).*/
                public IntBasis WDAT_REL_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*" 03        WDAT-REL-LIT.*/

                public _REDEF_VG1613B_FILLER_25()
                {
                    WDAT_REL_SEC.ValueChanged += OnValueChanged;
                    WDAT_REL_ANO.ValueChanged += OnValueChanged;
                    FILLER_26.ValueChanged += OnValueChanged;
                    WDAT_REL_MES.ValueChanged += OnValueChanged;
                    FILLER_27.ValueChanged += OnValueChanged;
                    WDAT_REL_DIA.ValueChanged += OnValueChanged;
                }

            }
            public VG1613B_WDAT_REL_LIT WDAT_REL_LIT { get; set; } = new VG1613B_WDAT_REL_LIT();
            public class VG1613B_WDAT_REL_LIT : VarBasis
            {
                /*"  05      WDAT-LIT-DIA        PIC  9(002)  VALUE ZEROS.*/
                public IntBasis WDAT_LIT_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  05      FILLER              PIC  X(001)  VALUE '/'.*/
                public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"  05      WDAT-LIT-MES        PIC  9(002)  VALUE ZEROS.*/
                public IntBasis WDAT_LIT_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  05      FILLER              PIC  X(001)  VALUE '/'.*/
                public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"  05      WDAT-LIT-SEC        PIC  9(002)  VALUE ZEROS.*/
                public IntBasis WDAT_LIT_SEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  05      WDAT-LIT-ANO        PIC  9(002)  VALUE ZEROS.*/
                public IntBasis WDAT_LIT_ANO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*" 03            WS-DTH-CRITICA    PIC  9(008).*/
            }
            public IntBasis WS_DTH_CRITICA { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*" 03            WS-DTH-CRITICA-R  REDEFINES               WS-DTH-CRITICA.*/
            private _REDEF_VG1613B_WS_DTH_CRITICA_R _ws_dth_critica_r { get; set; }
            public _REDEF_VG1613B_WS_DTH_CRITICA_R WS_DTH_CRITICA_R
            {
                get { _ws_dth_critica_r = new _REDEF_VG1613B_WS_DTH_CRITICA_R(); _.Move(WS_DTH_CRITICA, _ws_dth_critica_r); VarBasis.RedefinePassValue(WS_DTH_CRITICA, _ws_dth_critica_r, WS_DTH_CRITICA); _ws_dth_critica_r.ValueChanged += () => { _.Move(_ws_dth_critica_r, WS_DTH_CRITICA); }; return _ws_dth_critica_r; }
                set { VarBasis.RedefinePassValue(value, _ws_dth_critica_r, WS_DTH_CRITICA); }
            }  //Redefines
            public class _REDEF_VG1613B_WS_DTH_CRITICA_R : VarBasis
            {
                /*"  05          WS-CRITICA-ANO    PIC  9(004).*/
                public IntBasis WS_CRITICA_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"  05          WS-CRITICA-MES    PIC  9(002).*/
                public IntBasis WS_CRITICA_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05          WS-CRITICA-DIA    PIC  9(002).*/
                public IntBasis WS_CRITICA_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*" 03         WDATA-ALTERACAO   PIC  X(05)    VALUE SPACES.*/

                public _REDEF_VG1613B_WS_DTH_CRITICA_R()
                {
                    WS_CRITICA_ANO.ValueChanged += OnValueChanged;
                    WS_CRITICA_MES.ValueChanged += OnValueChanged;
                    WS_CRITICA_DIA.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WDATA_ALTERACAO { get; set; } = new StringBasis(new PIC("X", "5", "X(05)"), @"");
            /*" 03         FILLER            REDEFINES      WDATA-ALTERACAO.*/
            private _REDEF_VG1613B_FILLER_30 _filler_30 { get; set; }
            public _REDEF_VG1613B_FILLER_30 FILLER_30
            {
                get { _filler_30 = new _REDEF_VG1613B_FILLER_30(); _.Move(WDATA_ALTERACAO, _filler_30); VarBasis.RedefinePassValue(WDATA_ALTERACAO, _filler_30, WDATA_ALTERACAO); _filler_30.ValueChanged += () => { _.Move(_filler_30, WDATA_ALTERACAO); }; return _filler_30; }
                set { VarBasis.RedefinePassValue(value, _filler_30, WDATA_ALTERACAO); }
            }  //Redefines
            public class _REDEF_VG1613B_FILLER_30 : VarBasis
            {
                /*"  05       WCOR-ANO.*/
                public VG1613B_WCOR_ANO WCOR_ANO { get; set; } = new VG1613B_WCOR_ANO();
                public class VG1613B_WCOR_ANO : VarBasis
                {
                    /*"    10     WCOR-ANOS         PIC  9(002).*/
                    public IntBasis WCOR_ANOS { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"    10     WCOR-ANOA         PIC  9(002).*/
                    public IntBasis WCOR_ANOA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"  05       WCOR-BR1          PIC  X(001).*/

                    public VG1613B_WCOR_ANO()
                    {
                        WCOR_ANOS.ValueChanged += OnValueChanged;
                        WCOR_ANOA.ValueChanged += OnValueChanged;
                    }

                }
                public StringBasis WCOR_BR1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"  05       WCOR-MES          PIC  9(002).*/
                public IntBasis WCOR_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05       WCOR-BR2          PIC  X(001).*/
                public StringBasis WCOR_BR2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"  05       WCOR-DIA          PIC  9(002).*/
                public IntBasis WCOR_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*" 03         WDATA-RETORNO     PIC  9(008)    VALUE ZEROS.*/

                public _REDEF_VG1613B_FILLER_30()
                {
                    WCOR_ANO.ValueChanged += OnValueChanged;
                    WCOR_BR1.ValueChanged += OnValueChanged;
                    WCOR_MES.ValueChanged += OnValueChanged;
                    WCOR_BR2.ValueChanged += OnValueChanged;
                    WCOR_DIA.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WDATA_RETORNO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*" 03         FILLER            REDEFINES      WDATA-RETORNO.*/
            private _REDEF_VG1613B_FILLER_31 _filler_31 { get; set; }
            public _REDEF_VG1613B_FILLER_31 FILLER_31
            {
                get { _filler_31 = new _REDEF_VG1613B_FILLER_31(); _.Move(WDATA_RETORNO, _filler_31); VarBasis.RedefinePassValue(WDATA_RETORNO, _filler_31, WDATA_RETORNO); _filler_31.ValueChanged += () => { _.Move(_filler_31, WDATA_RETORNO); }; return _filler_31; }
                set { VarBasis.RedefinePassValue(value, _filler_31, WDATA_RETORNO); }
            }  //Redefines
            public class _REDEF_VG1613B_FILLER_31 : VarBasis
            {
                /*"  05       WRET-DIA          PIC  9(002).*/
                public IntBasis WRET_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05       WRET-MES          PIC  9(002).*/
                public IntBasis WRET_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05       WRET-SEC          PIC  9(002).*/
                public IntBasis WRET_SEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05       WRET-ANO          PIC  9(002).*/
                public IntBasis WRET_ANO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*" 03         WDATA-PARAMETRO   PIC  9(008)    VALUE ZEROS.*/

                public _REDEF_VG1613B_FILLER_31()
                {
                    WRET_DIA.ValueChanged += OnValueChanged;
                    WRET_MES.ValueChanged += OnValueChanged;
                    WRET_SEC.ValueChanged += OnValueChanged;
                    WRET_ANO.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WDATA_PARAMETRO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*" 03         FILLER            REDEFINES      WDATA-PARAMETRO.*/
            private _REDEF_VG1613B_FILLER_32 _filler_32 { get; set; }
            public _REDEF_VG1613B_FILLER_32 FILLER_32
            {
                get { _filler_32 = new _REDEF_VG1613B_FILLER_32(); _.Move(WDATA_PARAMETRO, _filler_32); VarBasis.RedefinePassValue(WDATA_PARAMETRO, _filler_32, WDATA_PARAMETRO); _filler_32.ValueChanged += () => { _.Move(_filler_32, WDATA_PARAMETRO); }; return _filler_32; }
                set { VarBasis.RedefinePassValue(value, _filler_32, WDATA_PARAMETRO); }
            }  //Redefines
            public class _REDEF_VG1613B_FILLER_32 : VarBasis
            {
                /*"  05       WPAR-DIA          PIC  9(002).*/
                public IntBasis WPAR_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05       WPAR-MES          PIC  9(002).*/
                public IntBasis WPAR_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05       WPAR-SEC          PIC  9(002).*/
                public IntBasis WPAR_SEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05       WPAR-ANO          PIC  9(002).*/
                public IntBasis WPAR_ANO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*" 03        CHAVE-MOVIMENTO.*/

                public _REDEF_VG1613B_FILLER_32()
                {
                    WPAR_DIA.ValueChanged += OnValueChanged;
                    WPAR_MES.ValueChanged += OnValueChanged;
                    WPAR_SEC.ValueChanged += OnValueChanged;
                    WPAR_ANO.ValueChanged += OnValueChanged;
                }

            }
            public VG1613B_CHAVE_MOVIMENTO CHAVE_MOVIMENTO { get; set; } = new VG1613B_CHAVE_MOVIMENTO();
            public class VG1613B_CHAVE_MOVIMENTO : VarBasis
            {
                /*"  05      CH-MATRIC-MOV       PIC  9(015)  VALUE ZEROS.*/
                public IntBasis CH_MATRIC_MOV { get; set; } = new IntBasis(new PIC("9", "15", "9(015)"));
                /*" 03        CHAVE-SEGURADO.*/
            }
            public VG1613B_CHAVE_SEGURADO CHAVE_SEGURADO { get; set; } = new VG1613B_CHAVE_SEGURADO();
            public class VG1613B_CHAVE_SEGURADO : VarBasis
            {
                /*"  05      CH-MATRIC-SEG       PIC  9(015)  VALUE ZEROS.*/
                public IntBasis CH_MATRIC_SEG { get; set; } = new IntBasis(new PIC("9", "15", "9(015)"));
                /*"01    WS-HORAS.*/
            }
        }
        public VG1613B_WS_HORAS WS_HORAS { get; set; } = new VG1613B_WS_HORAS();
        public class VG1613B_WS_HORAS : VarBasis
        {
            /*" 03  WS-HORA-INI               PIC  X(008).*/
            public StringBasis WS_HORA_INI { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*" 03  WS-HORA-INI-R REDEFINES WS-HORA-INI.*/
            private _REDEF_VG1613B_WS_HORA_INI_R _ws_hora_ini_r { get; set; }
            public _REDEF_VG1613B_WS_HORA_INI_R WS_HORA_INI_R
            {
                get { _ws_hora_ini_r = new _REDEF_VG1613B_WS_HORA_INI_R(); _.Move(WS_HORA_INI, _ws_hora_ini_r); VarBasis.RedefinePassValue(WS_HORA_INI, _ws_hora_ini_r, WS_HORA_INI); _ws_hora_ini_r.ValueChanged += () => { _.Move(_ws_hora_ini_r, WS_HORA_INI); }; return _ws_hora_ini_r; }
                set { VarBasis.RedefinePassValue(value, _ws_hora_ini_r, WS_HORA_INI); }
            }  //Redefines
            public class _REDEF_VG1613B_WS_HORA_INI_R : VarBasis
            {
                /*"  05  HI                    PIC  9(002).*/
                public IntBasis HI { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05  MI                    PIC  9(002).*/
                public IntBasis MI { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05  SI                    PIC  9(002).*/
                public IntBasis SI { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05  DI                    PIC  9(002).*/
                public IntBasis DI { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*" 03  WS-HORA-FIM               PIC  X(008).*/

                public _REDEF_VG1613B_WS_HORA_INI_R()
                {
                    HI.ValueChanged += OnValueChanged;
                    MI.ValueChanged += OnValueChanged;
                    SI.ValueChanged += OnValueChanged;
                    DI.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WS_HORA_FIM { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*" 03  WS-HORA-FIM-R REDEFINES WS-HORA-FIM.*/
            private _REDEF_VG1613B_WS_HORA_FIM_R _ws_hora_fim_r { get; set; }
            public _REDEF_VG1613B_WS_HORA_FIM_R WS_HORA_FIM_R
            {
                get { _ws_hora_fim_r = new _REDEF_VG1613B_WS_HORA_FIM_R(); _.Move(WS_HORA_FIM, _ws_hora_fim_r); VarBasis.RedefinePassValue(WS_HORA_FIM, _ws_hora_fim_r, WS_HORA_FIM); _ws_hora_fim_r.ValueChanged += () => { _.Move(_ws_hora_fim_r, WS_HORA_FIM); }; return _ws_hora_fim_r; }
                set { VarBasis.RedefinePassValue(value, _ws_hora_fim_r, WS_HORA_FIM); }
            }  //Redefines
            public class _REDEF_VG1613B_WS_HORA_FIM_R : VarBasis
            {
                /*"  05  HF                    PIC  9(002).*/
                public IntBasis HF { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05  MF                    PIC  9(002).*/
                public IntBasis MF { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05  SF                    PIC  9(002).*/
                public IntBasis SF { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05  DF                    PIC  9(002).*/
                public IntBasis DF { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*" 03  SIT                       PIC S9(013)V99 COMP-3 VALUE +0.*/

                public _REDEF_VG1613B_WS_HORA_FIM_R()
                {
                    HF.ValueChanged += OnValueChanged;
                    MF.ValueChanged += OnValueChanged;
                    SF.ValueChanged += OnValueChanged;
                    DF.ValueChanged += OnValueChanged;
                }

            }
            public DoubleBasis SIT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*" 03  SFT                       PIC S9(013)V99 COMP-3 VALUE +0.*/
            public DoubleBasis SFT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*" 03  SII                       PIC S9(004)    COMP   VALUE +0.*/
            public IntBasis SII { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*" 03  IND                       PIC S9(004)    COMP   VALUE +0.*/
            public IntBasis IND { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*" 03  STT-DISP                  PIC --.---.---.---.--9,99.*/
            public DoubleBasis STT_DISP { get; set; } = new DoubleBasis(new PIC("9", "14", "--.---.---.---.--9V99."), 2);
            /*"01  TOTAIS-ROT.*/
        }
        public VG1613B_TOTAIS_ROT TOTAIS_ROT { get; set; } = new VG1613B_TOTAIS_ROT();
        public class VG1613B_TOTAIS_ROT : VarBasis
        {
            /*" 03  FILLER  OCCURS 50 TIMES.*/
            public ListBasis<VG1613B_FILLER_33> FILLER_33 { get; set; } = new ListBasis<VG1613B_FILLER_33>(50);
            public class VG1613B_FILLER_33 : VarBasis
            {
                /*"  05  STT                       PIC S9(013)V99 COMP-3.*/
                public DoubleBasis STT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
                /*"  05  SQT                       PIC S9(015)    COMP-3.*/
                public IntBasis SQT { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
                /*"01        LK-LINK.*/
            }
        }
        public VG1613B_LK_LINK LK_LINK { get; set; } = new VG1613B_LK_LINK();
        public class VG1613B_LK_LINK : VarBasis
        {
            /*" 03     LK-DATA1          PIC  9(008).*/
            public IntBasis LK_DATA1 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*" 03     LK-DATA2          PIC  9(008).*/
            public IntBasis LK_DATA2 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*" 03     QTDIA             PIC S9(005)          COMP-3.*/
            public IntBasis QTDIA { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));
            /*"01         WPROSOMD2.*/
        }
        public VG1613B_WPROSOMD2 WPROSOMD2 { get; set; } = new VG1613B_WPROSOMD2();
        public class VG1613B_WPROSOMD2 : VarBasis
        {
            /*" 03       WDATA-INFORMADA   PIC  9(008).*/
            public IntBasis WDATA_INFORMADA { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*" 03       WDATA-QTDIAS      PIC S03)    COMP-3.*/
            public IntBasis WDATA_QTDIAS { get; set; } = new IntBasis(new PIC("9", "0", "S03)"));
            /*" 03       WDATA-CALCULO     PIC  9(008).*/
            public IntBasis WDATA_CALCULO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"01        PARAMETROS.*/
        }
        public VG1613B_PARAMETROS PARAMETROS { get; set; } = new VG1613B_PARAMETROS();
        public class VG1613B_PARAMETROS : VarBasis
        {
            /*" 03      LK710-APOLICE               PIC S9(013) COMP-3.*/
            public IntBasis LK710_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
            /*" 03      LK710-SUBGRUPO              PIC S9(004) COMP.*/
            public IntBasis LK710_SUBGRUPO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*" 03      LK710-IDADE                 PIC S9(004) COMP.*/
            public IntBasis LK710_IDADE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*" 03      LK710-NASCIMENTO.*/
            public VG1613B_LK710_NASCIMENTO LK710_NASCIMENTO { get; set; } = new VG1613B_LK710_NASCIMENTO();
            public class VG1613B_LK710_NASCIMENTO : VarBasis
            {
                /*"   05 LK710-DATA-NASCIMENTO          PIC  9(008).*/
                public IntBasis LK710_DATA_NASCIMENTO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*" 03      LK710-SALARIO               PIC S9(013)V99 COMP-3.*/
            }
            public DoubleBasis LK710_SALARIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*" 03      LK710-CO-MORTE-NATURAL      PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK710_CO_MORTE_NATURAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*" 03      LK710-CO-MORTE-ACIDENTAL    PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK710_CO_MORTE_ACIDENTAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*" 03      LK710-CO-INV-PERMANENTE     PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK710_CO_INV_PERMANENTE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*" 03      LK710-CO-INV-POR-ACIDENTE   PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK710_CO_INV_POR_ACIDENTE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*" 03      LK710-CO-ASS-MEDICA         PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK710_CO_ASS_MEDICA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*" 03      LK710-CO-DI-HOSPITALAR      PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK710_CO_DI_HOSPITALAR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*" 03      LK710-CO-DI-INTERNACAO      PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK710_CO_DI_INTERNACAO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*" 03      LK710-PU-MORTE-NATURAL      PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK710_PU_MORTE_NATURAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*" 03      LK710-PU-MORTE-ACIDENTAL    PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK710_PU_MORTE_ACIDENTAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*" 03      LK710-PU-INV-PERMANENTE     PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK710_PU_INV_PERMANENTE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*" 03      LK710-PU-ASS-MEDICA         PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK710_PU_ASS_MEDICA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*" 03      LK710-PU-DI-HOSPITALAR      PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK710_PU_DI_HOSPITALAR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*" 03      LK710-PU-DI-INTERNACAO      PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK710_PU_DI_INTERNACAO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*" 03      LK710-PREM-MORTE-NATURAL    PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK710_PREM_MORTE_NATURAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*" 03      LK710-PREM-ACIDENTES-PESSOAIS PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK710_PREM_ACIDENTES_PESSOAIS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*" 03      LK710-PREM-TOTAL            PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK710_PREM_TOTAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*" 03      LK710-RETURN-CODE           PIC S9(03) COMP-3.*/
            public IntBasis LK710_RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "3", "S9(03)"));
            /*" 03      LK710-MENSAGEM              PIC  X(77).*/
            public StringBasis LK710_MENSAGEM { get; set; } = new StringBasis(new PIC("X", "77", "X(77)."), @"");
            /*"01        PARAMETROS-702.*/
        }
        public VG1613B_PARAMETROS_702 PARAMETROS_702 { get; set; } = new VG1613B_PARAMETROS_702();
        public class VG1613B_PARAMETROS_702 : VarBasis
        {
            /*" 03      LK-APOLICE               PIC S9(013) COMP-3.*/
            public IntBasis LK_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
            /*" 03      LK-SUBGRUPO              PIC S9(004) COMP.*/
            public IntBasis LK_SUBGRUPO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*" 03      LK-IDADE                 PIC S9(004) COMP.*/
            public IntBasis LK_IDADE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*" 03      LK-NASCIMENTO.*/
            public VG1613B_LK_NASCIMENTO LK_NASCIMENTO { get; set; } = new VG1613B_LK_NASCIMENTO();
            public class VG1613B_LK_NASCIMENTO : VarBasis
            {
                /*"  05 LK-DATA-NASCIMENTO          PIC  9(008).*/
                public IntBasis LK_DATA_NASCIMENTO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*" 03      LK-SALARIO               PIC S9(013)V99 COMP-3.*/
            }
            public DoubleBasis LK_SALARIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*" 03      LK-CO-MORTE-NATURAL      PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_CO_MORTE_NATURAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*" 03      LK-CO-MORTE-ACIDENTAL    PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_CO_MORTE_ACIDENTAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*" 03      LK-CO-INV-PERMANENTE     PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_CO_INV_PERMANENTE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*" 03      LK-CO-ASS-MEDICA         PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_CO_ASS_MEDICA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*" 03      LK-CO-DI-HOSPITALAR      PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_CO_DI_HOSPITALAR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*" 03      LK-CO-DI-INTERNACAO      PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_CO_DI_INTERNACAO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*" 03      LK-CO-DESPESA-MEDICA     PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_CO_DESPESA_MEDICA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*" 03      LK-PU-MORTE-NATURAL      PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_PU_MORTE_NATURAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*" 03      LK-PU-MORTE-ACIDENTAL    PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_PU_MORTE_ACIDENTAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*" 03      LK-PU-INV-PERMANENTE     PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_PU_INV_PERMANENTE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*" 03      LK-PU-ASS-MEDICA         PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_PU_ASS_MEDICA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*" 03      LK-PU-DI-HOSPITALAR      PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_PU_DI_HOSPITALAR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*" 03      LK-PU-DI-INTERNACAO      PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_PU_DI_INTERNACAO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*" 03      LK-PU-DESPESA-MEDICA     PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_PU_DESPESA_MEDICA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*" 03      LK-PREM-MORTE-NATURAL    PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_PREM_MORTE_NATURAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*" 03      LK-PREM-ACIDENTES-PESSOAIS PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_PREM_ACIDENTES_PESSOAIS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*" 03      LK-PREM-TOTAL            PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_PREM_TOTAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*" 03      LK-RETURN-CODE           PIC S9(03) COMP.*/
            public IntBasis LK_RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "3", "S9(03)"));
            /*" 03      LK-MENSAGEM              PIC  X(77).*/
            public StringBasis LK_MENSAGEM { get; set; } = new StringBasis(new PIC("X", "77", "X(77)."), @"");
            /*"01         WS-MOVTO-CLIENTE.*/
        }
        public VG1613B_WS_MOVTO_CLIENTE WS_MOVTO_CLIENTE { get; set; } = new VG1613B_WS_MOVTO_CLIENTE();
        public class VG1613B_WS_MOVTO_CLIENTE : VarBasis
        {
            /*" 03       WWORK-COD-CLIENTE      PIC S9(009)    VALUE +0 COMP-4.*/
            public IntBasis WWORK_COD_CLIENTE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*" 03       WWORK-TIPO-MOVIMENTO   PIC  X(001)    VALUE  SPACES.*/
            public StringBasis WWORK_TIPO_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*" 03       WWORK-DATA-ULT-MANUTEN PIC  X(010)    VALUE  SPACES.*/
            public StringBasis WWORK_DATA_ULT_MANUTEN { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*" 03       WWORK-NOME-RAZAO       PIC  X(040)    VALUE  SPACES.*/
            public StringBasis WWORK_NOME_RAZAO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
            /*" 03       WWORK-TIPO-PESSOA      PIC  X(001)    VALUE  SPACES.*/
            public StringBasis WWORK_TIPO_PESSOA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*" 03       WWORK-IDE-SEXO         PIC  X(001)    VALUE  SPACES.*/
            public StringBasis WWORK_IDE_SEXO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*" 03       WWORK-ESTADO-CIVIL     PIC  X(001)    VALUE  SPACES.*/
            public StringBasis WWORK_ESTADO_CIVIL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*" 03       WWORK-OCORR-ENDERECO   PIC S9(004)    VALUE +0 COMP-4.*/
            public IntBasis WWORK_OCORR_ENDERECO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*" 03       WWORK-ENDERECO         PIC  X(040)    VALUE  SPACES.*/
            public StringBasis WWORK_ENDERECO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
            /*" 03       WWORK-BAIRRO           PIC  X(020)    VALUE  SPACES.*/
            public StringBasis WWORK_BAIRRO { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"");
            /*" 03       WWORK-CIDADE           PIC  X(020)    VALUE  SPACES.*/
            public StringBasis WWORK_CIDADE { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"");
            /*" 03       WWORK-SIGLA-UF         PIC  X(002)    VALUE  SPACES.*/
            public StringBasis WWORK_SIGLA_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
            /*" 03       WWORK-CEP              PIC S9(009)    VALUE +0 COMP-4.*/
            public IntBasis WWORK_CEP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*" 03       WWORK-DDD              PIC S9(004)    VALUE +0 COMP-4.*/
            public IntBasis WWORK_DDD { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*" 03       WWORK-TELEFONE         PIC S9(009)    VALUE +0 COMP-4.*/
            public IntBasis WWORK_TELEFONE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*" 03       WWORK-FAX              PIC S9(009)    VALUE +0 COMP-4.*/
            public IntBasis WWORK_FAX { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*" 03       WWORK-CGCCPF           PIC S9(015)    VALUE +0 COMP-3.*/
            public IntBasis WWORK_CGCCPF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
            /*" 03       WWORK-DATA-NASCIMENTO  PIC  X(010)    VALUE  SPACES.*/
            public StringBasis WWORK_DATA_NASCIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*" 03       WTEM-GECLIMOV          PIC  X(001)    VALUE  SPACES.*/
            public StringBasis WTEM_GECLIMOV { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"01              WS-PARAMETROS.*/
        }
        public VG1613B_WS_PARAMETROS WS_PARAMETROS { get; set; } = new VG1613B_WS_PARAMETROS();
        public class VG1613B_WS_PARAMETROS : VarBasis
        {
            /*" 03            W01DIGCERT.*/
            public VG1613B_W01DIGCERT W01DIGCERT { get; set; } = new VG1613B_W01DIGCERT();
            public class VG1613B_W01DIGCERT : VarBasis
            {
                /*"  05          WCERTIFICADO    PIC  9(015)        VALUE  0.*/
                public IntBasis WCERTIFICADO { get; set; } = new IntBasis(new PIC("9", "15", "9(015)"));
                /*"  05          WNUMERO         PIC S9(004)  COMP  VALUE +15.*/
                public IntBasis WNUMERO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), +15);
                /*"  05          WDIG            PIC  X(001)  VALUE SPACES.*/
                public StringBasis WDIG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"01          REGISTRO-WORK.*/
            }
        }
        public VG1613B_REGISTRO_WORK REGISTRO_WORK { get; set; } = new VG1613B_REGISTRO_WORK();
        public class VG1613B_REGISTRO_WORK : VarBasis
        {
            /*" 03        NOME-REG                 PIC  X(040).*/
            public StringBasis NOME_REG { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
            /*" 03        CPF-REG                  PIC  9(011).*/
            public IntBasis CPF_REG { get; set; } = new IntBasis(new PIC("9", "11", "9(011)."));
            /*" 03        DTNAS-REG.*/
            public VG1613B_DTNAS_REG DTNAS_REG { get; set; } = new VG1613B_DTNAS_REG();
            public class VG1613B_DTNAS_REG : VarBasis
            {
                /*"  05      DTNAS-AA-REG             PIC  X(004).*/
                public StringBasis DTNAS_AA_REG { get; set; } = new StringBasis(new PIC("X", "4", "X(004)."), @"");
                /*"  05      DTNAS-T1-REG             PIC  X(001).*/
                public StringBasis DTNAS_T1_REG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"  05      DTNAS-MM-REG             PIC  X(002).*/
                public StringBasis DTNAS_MM_REG { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"  05      DTNAS-T2-REG             PIC  X(001).*/
                public StringBasis DTNAS_T2_REG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"  05      DTNAS-DD-REG             PIC  X(002).*/
                public StringBasis DTNAS_DD_REG { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*" 03        SEXO-REG                 PIC  X(001).*/
            }
            public StringBasis SEXO_REG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*" 03        ESTCIV-REG               PIC  X(001).*/
            public StringBasis ESTCIV_REG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*" 03        SALARIO-REG              PIC  9(010).*/
            public IntBasis SALARIO_REG { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
            /*" 03        QTDSAL-REG               PIC  9(004).*/
            public IntBasis QTDSAL_REG { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*" 03        IS-REG                   PIC  9(010).*/
            public IntBasis IS_REG { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
            /*" 03        PREMIO-REG               PIC  9(010).*/
            public IntBasis PREMIO_REG { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
            /*" 03        NUM-APOLICE-REG          PIC  9(013).*/
            public IntBasis NUM_APOLICE_REG { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
            /*" 03        SUBGRUPO-REG             PIC  9(004).*/
            public IntBasis SUBGRUPO_REG { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*" 03        DTVIG-REG                PIC  X(010).*/
            public StringBasis DTVIG_REG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*" 03        LIXO1                    PIC  X(001).*/
            public StringBasis LIXO1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*" 03        FILLER                   PIC  X(001).*/
            public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*" 03        COD-ERRO-REG             PIC  9(004).*/
            public IntBasis COD_ERRO_REG { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"01          REGISTRO-SAIDA.*/
        }
        public VG1613B_REGISTRO_SAIDA REGISTRO_SAIDA { get; set; } = new VG1613B_REGISTRO_SAIDA();
        public class VG1613B_REGISTRO_SAIDA : VarBasis
        {
            /*" 03        NUM-APOLICE-SAI          PIC  9(013).*/
            public IntBasis NUM_APOLICE_SAI { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
            /*" 03        FILLER                   PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*" 03        SUBGRUPO-SAI             PIC  9(004).*/
            public IntBasis SUBGRUPO_SAI { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*" 03        FILLER                   PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*" 03        SUBES-SAI                PIC  X(040).*/
            public StringBasis SUBES_SAI { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
            /*" 03        FILLER                   PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*" 03        NOME-SAI                 PIC  X(040).*/
            public StringBasis NOME_SAI { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
            /*" 03        FILLER                   PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*" 03        CPF-SAI                  PIC  9(011).*/
            public IntBasis CPF_SAI { get; set; } = new IntBasis(new PIC("9", "11", "9(011)."));
            /*" 03        FILLER                   PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*" 03        DTNAS-SAI.*/
            public VG1613B_DTNAS_SAI DTNAS_SAI { get; set; } = new VG1613B_DTNAS_SAI();
            public class VG1613B_DTNAS_SAI : VarBasis
            {
                /*"  05      DTNAS-AA-SAI             PIC  X(004).*/
                public StringBasis DTNAS_AA_SAI { get; set; } = new StringBasis(new PIC("X", "4", "X(004)."), @"");
                /*"  05      DTNAS-T1-SAI             PIC  X(001).*/
                public StringBasis DTNAS_T1_SAI { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"  05      DTNAS-MM-SAI             PIC  X(002).*/
                public StringBasis DTNAS_MM_SAI { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"  05      DTNAS-T2-SAI             PIC  X(001).*/
                public StringBasis DTNAS_T2_SAI { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"  05      DTNAS-DD-SAI             PIC  X(002).*/
                public StringBasis DTNAS_DD_SAI { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*" 03        FILLER                   PIC  X(001) VALUE ';'.*/
            }
            public StringBasis FILLER_40 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*" 03        SEXO-SAI                 PIC  X(001).*/
            public StringBasis SEXO_SAI { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*" 03        FILLER                   PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*" 03        ESTCIV-SAI               PIC  X(001).*/
            public StringBasis ESTCIV_SAI { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*" 03        FILLER                   PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*" 03        SALARIO-SAI              PIC  99999999,99.*/
            public DoubleBasis SALARIO_SAI { get; set; } = new DoubleBasis(new PIC("9", "8", "99999999V99."), 2);
            /*" 03        FILLER                   PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_43 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*" 03        QTDSAL-SAI               PIC  9(004).*/
            public IntBasis QTDSAL_SAI { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*" 03        FILLER                   PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_44 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*" 03        IS-SAI                   PIC  99999999,99.*/
            public DoubleBasis IS_SAI { get; set; } = new DoubleBasis(new PIC("9", "8", "99999999V99."), 2);
            /*" 03        FILLER                   PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_45 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*" 03        PREMIO-INFO-SAI          PIC  99999999,99.*/
            public DoubleBasis PREMIO_INFO_SAI { get; set; } = new DoubleBasis(new PIC("9", "8", "99999999V99."), 2);
            /*" 03        FILLER                   PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_46 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*" 03        PREMIO-CALC-SAI          PIC  99999999,99.*/
            public DoubleBasis PREMIO_CALC_SAI { get; set; } = new DoubleBasis(new PIC("9", "8", "99999999V99."), 2);
            /*" 03        FILLER                   PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_47 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*" 03        PREMIO-DIFE-SAI          PIC  99999999,99.*/
            public DoubleBasis PREMIO_DIFE_SAI { get; set; } = new DoubleBasis(new PIC("9", "8", "99999999V99."), 2);
            /*" 03        FILLER                   PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_48 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*" 03        DTVIG-SAI                PIC  X(03).*/
            public StringBasis DTVIG_SAI { get; set; } = new StringBasis(new PIC("X", "3", "X(03)."), @"");
            /*" 03        FILLER                   PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_49 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*" 03        COD-ERRO-SAI             PIC  9(004).*/
            public IntBasis COD_ERRO_SAI { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*" 03        FILLER                   PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_50 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*" 03        DES-ERRO-SAI             PIC  X(060).*/
            public StringBasis DES_ERRO_SAI { get; set; } = new StringBasis(new PIC("X", "60", "X(060)."), @"");
            /*" 03        FILLER                   PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_51 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"01          REGISTRO-SAIDA1.*/
        }
        public VG1613B_REGISTRO_SAIDA1 REGISTRO_SAIDA1 { get; set; } = new VG1613B_REGISTRO_SAIDA1();
        public class VG1613B_REGISTRO_SAIDA1 : VarBasis
        {
            /*" 03        NUM-APOLICE-SAI1         PIC  9(013).*/
            public IntBasis NUM_APOLICE_SAI1 { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
            /*" 03        FILLER                   PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_52 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*" 03        SUBGRUPO-SAI1            PIC  9(004).*/
            public IntBasis SUBGRUPO_SAI1 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*" 03        FILLER                   PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_53 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*" 03        SUBES-SAI1               PIC  X(040).*/
            public StringBasis SUBES_SAI1 { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
            /*" 03        FILLER                   PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_54 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*" 03        QTDE-ATIVOS-SAI1         PIC  9(005).*/
            public IntBasis QTDE_ATIVOS_SAI1 { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
            /*" 03        FILLER                   PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_55 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*" 03        VLR-ATIVOS-SAI1          PIC  999999999,99.*/
            public DoubleBasis VLR_ATIVOS_SAI1 { get; set; } = new DoubleBasis(new PIC("9", "9", "999999999V99."), 2);
            /*" 03        FILLER                   PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_56 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*" 03        QTDE-CRITIC-SAI1         PIC  9(005).*/
            public IntBasis QTDE_CRITIC_SAI1 { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
            /*" 03        FILLER                   PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_57 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*" 03        VLR-CRITIC-SAI1          PIC  999999999,99.*/
            public DoubleBasis VLR_CRITIC_SAI1 { get; set; } = new DoubleBasis(new PIC("9", "9", "999999999V99."), 2);
            /*" 03        FILLER                   PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_58 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*" 03        QTDE-MOVTO-SAI1          PIC  9(005).*/
            public IntBasis QTDE_MOVTO_SAI1 { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
            /*" 03        FILLER                   PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_59 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*" 03        VLR-MOVTO-SAI1           PIC  999999999,99.*/
            public DoubleBasis VLR_MOVTO_SAI1 { get; set; } = new DoubleBasis(new PIC("9", "9", "999999999V99."), 2);
            /*" 03        FILLER                   PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_60 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*" 03        FILLER                   PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_61 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*" 03        FILLER                   PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_62 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*" 03        FILLER                   PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_63 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*" 03        FILLER                   PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_64 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*" 03        FILLER                   PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_65 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*" 03        FILLER                   PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_66 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*" 03        FILLER                   PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_67 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"01          REGISTRO-SAIDA2.*/
        }
        public VG1613B_REGISTRO_SAIDA2 REGISTRO_SAIDA2 { get; set; } = new VG1613B_REGISTRO_SAIDA2();
        public class VG1613B_REGISTRO_SAIDA2 : VarBasis
        {
            /*" 03        NUM-APOLICE-SAI2         PIC  9(013).*/
            public IntBasis NUM_APOLICE_SAI2 { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
            /*" 03        FILLER                   PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_68 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*" 03        SUBGRUPO-SAI2            PIC  9(004).*/
            public IntBasis SUBGRUPO_SAI2 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*" 03        FILLER                   PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_69 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*" 03        SUBES-SAI2               PIC  X(040).*/
            public StringBasis SUBES_SAI2 { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
            /*" 03        FILLER                   PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_70 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*" 03        OBSERVACAO-SAI2          PIC  X(080).*/
            public StringBasis OBSERVACAO_SAI2 { get; set; } = new StringBasis(new PIC("X", "80", "X(080)."), @"");
            /*" 03        FILLER                   PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_71 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*" 03        FILLER                   PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_72 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*" 03        FILLER                   PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_73 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*" 03        FILLER                   PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_74 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*" 03        FILLER                   PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_75 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*" 03        FILLER                   PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_76 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*" 03        FILLER                   PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_77 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*" 03        FILLER                   PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_78 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*" 03        FILLER                   PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_79 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*" 03        FILLER                   PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_80 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*" 03        FILLER                   PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_81 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"01              LPARM01         PIC  9(011).*/
        }
        public IntBasis LPARM01 { get; set; } = new IntBasis(new PIC("9", "11", "9(011)."));
        /*"01          TAB-RESUMO.*/
        public VG1613B_TAB_RESUMO TAB_RESUMO { get; set; } = new VG1613B_TAB_RESUMO();
        public class VG1613B_TAB_RESUMO : VarBasis
        {
            /*" 03        TAB-RES OCCURS 1000 TIMES.*/
            public ListBasis<VG1613B_TAB_RES> TAB_RES { get; set; } = new ListBasis<VG1613B_TAB_RES>(1000);
            public class VG1613B_TAB_RES : VarBasis
            {
                /*"  05      TAB-CHAVE                PIC  X(17).*/
                public StringBasis TAB_CHAVE { get; set; } = new StringBasis(new PIC("X", "17", "X(17)."), @"");
                /*"  05      TAB-CHAVE-R              REDEFINES  TAB-CHAVE.*/
                private _REDEF_VG1613B_TAB_CHAVE_R _tab_chave_r { get; set; }
                public _REDEF_VG1613B_TAB_CHAVE_R TAB_CHAVE_R
                {
                    get { _tab_chave_r = new _REDEF_VG1613B_TAB_CHAVE_R(); _.Move(TAB_CHAVE, _tab_chave_r); VarBasis.RedefinePassValue(TAB_CHAVE, _tab_chave_r, TAB_CHAVE); _tab_chave_r.ValueChanged += () => { _.Move(_tab_chave_r, TAB_CHAVE); }; return _tab_chave_r; }
                    set { VarBasis.RedefinePassValue(value, _tab_chave_r, TAB_CHAVE); }
                }  //Redefines
                public class _REDEF_VG1613B_TAB_CHAVE_R : VarBasis
                {
                    /*"    10    TAB-NUM-APOLICE          PIC  9(13).*/
                    public IntBasis TAB_NUM_APOLICE { get; set; } = new IntBasis(new PIC("9", "13", "9(13)."));
                    /*"    10    TAB-COD-SUBGRUPO         PIC  9(04).*/
                    public IntBasis TAB_COD_SUBGRUPO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                    /*"  05      TAB-QTDE-ATIVOS          PIC  9(05).*/

                    public _REDEF_VG1613B_TAB_CHAVE_R()
                    {
                        TAB_NUM_APOLICE.ValueChanged += OnValueChanged;
                        TAB_COD_SUBGRUPO.ValueChanged += OnValueChanged;
                    }

                }
                public IntBasis TAB_QTDE_ATIVOS { get; set; } = new IntBasis(new PIC("9", "5", "9(05)."));
                /*"  05      TAB-VLR-ATIVOS           PIC  9(05).*/
                public IntBasis TAB_VLR_ATIVOS { get; set; } = new IntBasis(new PIC("9", "5", "9(05)."));
                /*"  05      TAB-QTDE-CRITIC          PIC  9(05).*/
                public IntBasis TAB_QTDE_CRITIC { get; set; } = new IntBasis(new PIC("9", "5", "9(05)."));
                /*"  05      TAB-VLR-CRITIC           PIC  9(05).*/
                public IntBasis TAB_VLR_CRITIC { get; set; } = new IntBasis(new PIC("9", "5", "9(05)."));
                /*"  05      TAB-QTDE-MOVTO           PIC  9(05).*/
                public IntBasis TAB_QTDE_MOVTO { get; set; } = new IntBasis(new PIC("9", "5", "9(05)."));
                /*"  05      TAB-VLR-MOVTO            PIC  9(13)V99.*/
                public DoubleBasis TAB_VLR_MOVTO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(13)V99."), 2);
                /*"01  REGISTRO-LINKAGE-GE0510S.*/
            }
        }
        public VG1613B_REGISTRO_LINKAGE_GE0510S REGISTRO_LINKAGE_GE0510S { get; set; } = new VG1613B_REGISTRO_LINKAGE_GE0510S();
        public class VG1613B_REGISTRO_LINKAGE_GE0510S : VarBasis
        {
            /*" 03 LK-GE510-NUM-APOLICE       PIC S9(13)V USAGE COMP-3.*/
            public DoubleBasis LK_GE510_NUM_APOLICE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
            /*" 03 LK-GE510-COD-SUBGRUPO      PIC S9(04) USAGE COMP.*/
            public IntBasis LK_GE510_COD_SUBGRUPO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*" 03 LK-GE510-NUM-CERTIFICADO   PIC S9(15)V USAGE COMP-3.*/
            public DoubleBasis LK_GE510_NUM_CERTIFICADO { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
            /*" 03 LK-GE510-COD-MODALIDADE    PIC S9(04) USAGE COMP.*/
            public IntBasis LK_GE510_COD_MODALIDADE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*" 03 LK-GE510-COD-REJEICAO      PIC  X(10).*/
            public StringBasis LK_GE510_COD_REJEICAO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*" 03 LK-GE510-COD-RETORNO       PIC  X(01).*/
            public StringBasis LK_GE510_COD_RETORNO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*" 03 LK-GE510-MENSAGEM.*/
            public VG1613B_LK_GE510_MENSAGEM LK_GE510_MENSAGEM { get; set; } = new VG1613B_LK_GE510_MENSAGEM();
            public class VG1613B_LK_GE510_MENSAGEM : VarBasis
            {
                /*"  05 LK-GE510-SQLCODE        PIC -ZZ9.*/
                public IntBasis LK_GE510_SQLCODE { get; set; } = new IntBasis(new PIC("9", "3", "-ZZ9."));
                /*"  05 FILLER                  PIC X(01).*/
                public StringBasis FILLER_82 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"  05 LK-GE510-MSG-RETORNO    PIC X(75).*/
                public StringBasis LK_GE510_MSG_RETORNO { get; set; } = new StringBasis(new PIC("X", "75", "X(75)."), @"");
            }
        }


        public Copies.LBFVG001 LBFVG001 { get; set; } = new Copies.LBFVG001();
        public Copies.LBFVG002 LBFVG002 { get; set; } = new Copies.LBFVG002();
        public Copies.LBFVG003 LBFVG003 { get; set; } = new Copies.LBFVG003();
        public Dclgens.APOLICOB APOLICOB { get; set; } = new Dclgens.APOLICOB();
        public Dclgens.APOLICES APOLICES { get; set; } = new Dclgens.APOLICES();
        public Dclgens.BANCOS BANCOS { get; set; } = new Dclgens.BANCOS();
        public Dclgens.CALENDAR CALENDAR { get; set; } = new Dclgens.CALENDAR();
        public Dclgens.ERROSVID ERROSVID { get; set; } = new Dclgens.ERROSVID();
        public Dclgens.CLIENTES CLIENTES { get; set; } = new Dclgens.CLIENTES();
        public Dclgens.COBHISVI COBHISVI { get; set; } = new Dclgens.COBHISVI();
        public Dclgens.CONDITEC CONDITEC { get; set; } = new Dclgens.CONDITEC();
        public Dclgens.CONMOVVG CONMOVVG { get; set; } = new Dclgens.CONMOVVG();
        public Dclgens.GECLIMOV GECLIMOV { get; set; } = new Dclgens.GECLIMOV();
        public Dclgens.ENDERECO ENDERECO { get; set; } = new Dclgens.ENDERECO();
        public Dclgens.ERRPROVI ERRPROVI { get; set; } = new Dclgens.ERRPROVI();
        public Dclgens.FAIXASAL FAIXASAL { get; set; } = new Dclgens.FAIXASAL();
        public Dclgens.FAIXAETA FAIXAETA { get; set; } = new Dclgens.FAIXAETA();
        public Dclgens.PLANOFAI PLANOFAI { get; set; } = new Dclgens.PLANOFAI();
        public Dclgens.PLANFSAL PLANFSAL { get; set; } = new Dclgens.PLANFSAL();
        public Dclgens.PLANOMUL PLANOMUL { get; set; } = new Dclgens.PLANOMUL();
        public Dclgens.FATURCON FATURCON { get; set; } = new Dclgens.FATURCON();
        public Dclgens.FONTES FONTES { get; set; } = new Dclgens.FONTES();
        public Dclgens.HISCOBPR HISCOBPR { get; set; } = new Dclgens.HISCOBPR();
        public Dclgens.HISCONPA HISCONPA { get; set; } = new Dclgens.HISCONPA();
        public Dclgens.MOEDAS MOEDAS { get; set; } = new Dclgens.MOEDAS();
        public Dclgens.MOEDACOT MOEDACOT { get; set; } = new Dclgens.MOEDACOT();
        public Dclgens.MOVIMVGA MOVIMVGA { get; set; } = new Dclgens.MOVIMVGA();
        public Dclgens.OPCPAGVI OPCPAGVI { get; set; } = new Dclgens.OPCPAGVI();
        public Dclgens.NUMEROUT NUMEROUT { get; set; } = new Dclgens.NUMEROUT();
        public Dclgens.PARAMRAM PARAMRAM { get; set; } = new Dclgens.PARAMRAM();
        public Dclgens.PARCEVID PARCEVID { get; set; } = new Dclgens.PARCEVID();
        public Dclgens.PLANOVGA PLANOVGA { get; set; } = new Dclgens.PLANOVGA();
        public Dclgens.PROPOVA PROPOVA { get; set; } = new Dclgens.PROPOVA();
        public Dclgens.RELATORI RELATORI { get; set; } = new Dclgens.RELATORI();
        public Dclgens.SEGVGAPH SEGVGAPH { get; set; } = new Dclgens.SEGVGAPH();
        public Dclgens.SEGURVGA SEGURVGA { get; set; } = new Dclgens.SEGURVGA();
        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.SUBGVGAP SUBGVGAP { get; set; } = new Dclgens.SUBGVGAP();
        public Dclgens.PRODUVG PRODUVG { get; set; } = new Dclgens.PRODUVG();
        public Dclgens.VGSEGCON VGSEGCON { get; set; } = new Dclgens.VGSEGCON();
        public Dclgens.JVBKINCL JVBKINCL { get; set; } = new Dclgens.JVBKINCL();
        public VG1613B_PLANOVGA1 PLANOVGA1 { get; set; } = new VG1613B_PLANOVGA1();
        public VG1613B_SEGURVGA1 SEGURVGA1 { get; set; } = new VG1613B_SEGURVGA1();
        public VG1613B_CSUBGVGAP CSUBGVGAP { get; set; } = new VG1613B_CSUBGVGAP();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string ARQUIVO_LEITURA_FILE_NAME_P, string ARQUIVO_SORT_FILE_NAME_P, string ARQUIVO_RETORNO_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                ARQUIVO_LEITURA.SetFile(ARQUIVO_LEITURA_FILE_NAME_P);
                ARQUIVO_SORT.SetFile(ARQUIVO_SORT_FILE_NAME_P);
                ARQUIVO_RETORNO.SetFile(ARQUIVO_RETORNO_FILE_NAME_P);

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
            /*" -1105- MOVE '0000' TO WNR-EXEC-SQL. */
            _.Move("0000", FILLER_1.WABEND.WNR_EXEC_SQL);

            /*" -1105- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -1106- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -1107- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -1110- DISPLAY '------------------------------------------------' */
            _.Display($"------------------------------------------------");

            /*" -1111- DISPLAY '          PROGRAMA EM EXECUCAO VG1613B          ' */
            _.Display($"          PROGRAMA EM EXECUCAO VG1613B          ");

            /*" -1112- DISPLAY '                              ' */
            _.Display($"                              ");

            /*" -1113- DISPLAY 'VERSAO V.42: ' FUNCTION WHEN-COMPILED ' - 584.508' */

            $"VERSAO V.42: FUNCTION{_.WhenCompiled()} - 584.508"
            .Display();

            /*" -1114- DISPLAY ' ' */
            _.Display($" ");

            /*" -1121- DISPLAY 'INICIOU PROCESSAMENTO EM ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2) */

            $"INICIOU PROCESSAMENTO EM {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
            .Display();

            /*" -1122- DISPLAY '   ' */
            _.Display($"   ");

            /*" -1125- DISPLAY '------------------------------------------------' */
            _.Display($"------------------------------------------------");

            /*" -1127- INITIALIZE W01-TABELA-TOTAIS */
            _.Initialize(
                FILLER_0.W01_TABELA_TOTAIS
            );

            /*" -1131- SORT ARQUIVO-SORT ON ASCENDING KEY NUM-APOLICE-SOR SUBGRUPO-SOR CPF-SOR INPUT PROCEDURE R0010-00-INPUT OUTPUT PROCEDURE R0020-00-OUTPUT . */
            SORT_RETURN.Value = ARQUIVO_SORT.Sort("NUM-APOLICE-SOR,SUBGRUPO-SOR,CPF-SOR", () => R0010_00_INPUT_SECTION(), () => R0020_00_OUTPUT_SECTION());

            /*" -1134- IF (EH-ARQUIVO-VAZIO EQUAL 'SIM' ) */

            if ((FILLER_1.FILLER_15.EH_ARQUIVO_VAZIO == "SIM"))
            {

                /*" -1135- PERFORM R9900-00-ENCERRA-SEM-MOVTO */

                R9900_00_ENCERRA_SEM_MOVTO_SECTION();

                /*" -1136- GO TO R0000-10-NEXT */

                R0000_10_NEXT(); //GOTO
                return;

                /*" -1138- END-IF. */
            }


            /*" -1139- IF (SORT-RETURN NOT EQUAL ZEROS) */

            if ((SORT_RETURN != 00))
            {

                /*" -1140- DISPLAY 'PROBLEMAS NO SORT ' SORT-RETURN */
                _.Display($"PROBLEMAS NO SORT {SORT_RETURN}");

                /*" -1141- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1141- END-IF. */
            }


            /*" -0- FLUXCONTROL_PERFORM R0000_10_NEXT */

            R0000_10_NEXT();

        }

        [StopWatch]
        /*" R0000-10-NEXT */
        private void R0000_10_NEXT(bool isPerform = false)
        {
            /*" -1148- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -1148- GO TO R9000-00-FINALIZA. */

            R9000_00_FINALIZA_SECTION(); //GOTO
            return;

        }

        [StopWatch]
        /*" R0010-00-INPUT-SECTION */
        private void R0010_00_INPUT_SECTION()
        {
            /*" -1157- MOVE 'R0010-00-INPUT' TO PARAGRAFO */
            _.Move("R0010-00-INPUT", FILLER_1.WABEND.PARAGRAFO);

            /*" -1159- DISPLAY PARAGRAFO */
            _.Display(FILLER_1.WABEND.PARAGRAFO);

            /*" -1161- INITIALIZE TOTAIS-ROT. */
            _.Initialize(
                TOTAIS_ROT
            );

            /*" -1162- OPEN INPUT ARQUIVO-LEITURA. */
            ARQUIVO_LEITURA.Open(REGISTRO_LEITURA);

            /*" -1164- OPEN OUTPUT ARQUIVO-RETORNO. */
            ARQUIVO_RETORNO.Open(REGISTRO_RETORNO);

            /*" -1166- PERFORM R0100-00-SELECT-TSISTEMA. */

            R0100_00_SELECT_TSISTEMA_SECTION();

            /*" -1168- PERFORM R0120-00-SELECT-NUMEROUT. */

            R0120_00_SELECT_NUMEROUT_SECTION();

            /*" -1170- PERFORM R0910-00-LE-MOVIMENTO. */

            R0910_00_LE_MOVIMENTO_SECTION();

            /*" -1171- IF (FIM-MOVIMENTO EQUAL 'SIM' ) */

            if ((FILLER_1.FILLER_15.FIM_MOVIMENTO == "SIM"))
            {

                /*" -1172- MOVE 'SIM' TO EH-ARQUIVO-VAZIO */
                _.Move("SIM", FILLER_1.FILLER_15.EH_ARQUIVO_VAZIO);

                /*" -1173- GO TO R0010-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0010_99_SAIDA*/ //GOTO
                return;

                /*" -1175- END-IF. */
            }


            /*" -1177- MOVE WS-CHAVE-ATU TO WS-CHAVE-ANT. */
            _.Move(WS_CHAVE_ATU, WS_CHAVE_ANT);

            /*" -1178- PERFORM R1000-00-PROCESSA-REGISTRO UNTIL FIM-MOVIMENTO EQUAL 'SIM' . */

            while (!(FILLER_1.FILLER_15.FIM_MOVIMENTO == "SIM"))
            {

                R1000_00_PROCESSA_REGISTRO_SECTION();
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0010_99_SAIDA*/

        [StopWatch]
        /*" R0020-00-OUTPUT-SECTION */
        private void R0020_00_OUTPUT_SECTION()
        {
            /*" -1187- MOVE 'R0020-00-OUTPUT' TO PARAGRAFO */
            _.Move("R0020-00-OUTPUT", FILLER_1.WABEND.PARAGRAFO);

            /*" -1189- DISPLAY PARAGRAFO */
            _.Display(FILLER_1.WABEND.PARAGRAFO);

            /*" -1190- IF (EH-ARQUIVO-VAZIO EQUAL 'SIM' ) */

            if ((FILLER_1.FILLER_15.EH_ARQUIVO_VAZIO == "SIM"))
            {

                /*" -1191- GO TO R0020-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0020_99_SAIDA*/ //GOTO
                return;

                /*" -1193- END-IF. */
            }


            /*" -1195- PERFORM R0080-00-LER-PARAMRAMO. */

            R0080_00_LER_PARAMRAMO_SECTION();

            /*" -1197- PERFORM R1910-00-LE-SORT. */

            R1910_00_LE_SORT_SECTION();

            /*" -1200- PERFORM R2000-00-PROCESSA-APOLICE UNTIL FIM-SORT EQUAL 'SIM' . */

            while (!(FILLER_1.FILLER_15.FIM_SORT == "SIM"))
            {

                R2000_00_PROCESSA_APOLICE_SECTION();
            }

            /*" -1200- PERFORM R8200-00-UPDATE-NUMEROUT. */

            R8200_00_UPDATE_NUMEROUT_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0020_99_SAIDA*/

        [StopWatch]
        /*" R0080-00-LER-PARAMRAMO-SECTION */
        private void R0080_00_LER_PARAMRAMO_SECTION()
        {
            /*" -1209- MOVE 'R0080-00-LER-PARAMRAMO' TO PARAGRAFO. */
            _.Move("R0080-00-LER-PARAMRAMO", FILLER_1.WABEND.PARAGRAFO);

            /*" -1210- MOVE '0080' TO WNR-EXEC-SQL. */
            _.Move("0080", FILLER_1.WABEND.WNR_EXEC_SQL);

            /*" -1213- DISPLAY PARAGRAFO */
            _.Display(FILLER_1.WABEND.PARAGRAFO);

            /*" -1214- MOVE 01 TO W01-I */
            _.Move(01, FILLER_0.W01_I);

            /*" -1215- MOVE 'R0080-SELECT PARAMRAMO ' TO W01-TEXTO(W01-I) */
            _.Move("R0080-SELECT PARAMRAMO ", FILLER_0.W01_TABELA_TEXTO.W01_TAB_TEXTO[FILLER_0.W01_I].W01_TEXTO);

            /*" -1220- PERFORM R8900-TOTALIZA-INICIO THRU R8900-TOTALIZA-INICIO-EXIT */

            R8900_TOTALIZA_INICIO_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8900_TOTALIZA_INICIO_EXIT*/


            /*" -1231- PERFORM R0080_00_LER_PARAMRAMO_DB_SELECT_1 */

            R0080_00_LER_PARAMRAMO_DB_SELECT_1();

            /*" -1234- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1235- DISPLAY 'VG1613B - ERRO ACESSO PARAMETROS_RAMOS' */
                _.Display($"VG1613B - ERRO ACESSO PARAMETROS_RAMOS");

                /*" -1235- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0080-00-LER-PARAMRAMO-DB-SELECT-1 */
        public void R0080_00_LER_PARAMRAMO_DB_SELECT_1()
        {
            /*" -1231- EXEC SQL SELECT RAMO_VG, RAMO_AP, RAMO_VGAPC, NUM_RAMO_PRSTMISTA INTO :PARAMRAM-RAMO-VG, :PARAMRAM-RAMO-AP, :PARAMRAM-RAMO-VGAPC, :PARAMRAM-NUM-RAMO-PRSTMISTA FROM SEGUROS.PARAMETROS_RAMOS WITH UR END-EXEC. */

            var r0080_00_LER_PARAMRAMO_DB_SELECT_1_Query1 = new R0080_00_LER_PARAMRAMO_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0080_00_LER_PARAMRAMO_DB_SELECT_1_Query1.Execute(r0080_00_LER_PARAMRAMO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PARAMRAM_RAMO_VG, PARAMRAM.DCLPARAMETROS_RAMOS.PARAMRAM_RAMO_VG);
                _.Move(executed_1.PARAMRAM_RAMO_AP, PARAMRAM.DCLPARAMETROS_RAMOS.PARAMRAM_RAMO_AP);
                _.Move(executed_1.PARAMRAM_RAMO_VGAPC, PARAMRAM.DCLPARAMETROS_RAMOS.PARAMRAM_RAMO_VGAPC);
                _.Move(executed_1.PARAMRAM_NUM_RAMO_PRSTMISTA, PARAMRAM.DCLPARAMETROS_RAMOS.PARAMRAM_NUM_RAMO_PRSTMISTA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0080_99_EXIT*/

        [StopWatch]
        /*" R0100-00-SELECT-TSISTEMA-SECTION */
        private void R0100_00_SELECT_TSISTEMA_SECTION()
        {
            /*" -1244- MOVE 'R0100-00-SELECT-TSISTEMA' TO PARAGRAFO. */
            _.Move("R0100-00-SELECT-TSISTEMA", FILLER_1.WABEND.PARAGRAFO);

            /*" -1245- MOVE '0100' TO WNR-EXEC-SQL. */
            _.Move("0100", FILLER_1.WABEND.WNR_EXEC_SQL);

            /*" -1248- DISPLAY PARAGRAFO */
            _.Display(FILLER_1.WABEND.PARAGRAFO);

            /*" -1249- MOVE 02 TO W01-I */
            _.Move(02, FILLER_0.W01_I);

            /*" -1250- MOVE 'R0100-SELECT SISTEMAS  ' TO W01-TEXTO(W01-I) */
            _.Move("R0100-SELECT SISTEMAS  ", FILLER_0.W01_TABELA_TEXTO.W01_TAB_TEXTO[FILLER_0.W01_I].W01_TEXTO);

            /*" -1254- PERFORM R8900-TOTALIZA-INICIO THRU R8900-TOTALIZA-INICIO-EXIT */

            R8900_TOTALIZA_INICIO_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8900_TOTALIZA_INICIO_EXIT*/


            /*" -1263- PERFORM R0100_00_SELECT_TSISTEMA_DB_SELECT_1 */

            R0100_00_SELECT_TSISTEMA_DB_SELECT_1();

            /*" -1267- MOVE 1 TO W01-QTD-ACC-OK */
            _.Move(1, FILLER_0.W01_QTD_ACC_OK);

            /*" -1271- PERFORM R8910-TOTALIZA-FINAL THRU R8910-TOTALIZA-FINAL-EXIT */

            R8910_TOTALIZA_FINAL_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8910_TOTALIZA_FINAL_EXIT*/


            /*" -1272- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1273- DISPLAY 'VG1613B - NAO CONSTA REGISTRO NA SISTEMAS' */
                _.Display($"VG1613B - NAO CONSTA REGISTRO NA SISTEMAS");

                /*" -1274- DISPLAY 'IDSISTEM =  VG ' */
                _.Display($"IDSISTEM =  VG ");

                /*" -1276- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1277- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1278- DISPLAY 'VG1613B - ERRO NA LEITURA NA SISTEMAS  ' */
                _.Display($"VG1613B - ERRO NA LEITURA NA SISTEMAS  ");

                /*" -1280- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1281- MOVE '01' TO SISTEMAS-DATA-MOV-ABERTO-1(9:2). */
            _.MoveAtPosition("01", SISTEMAS_DATA_MOV_ABERTO_1, 9, 2);

        }

        [StopWatch]
        /*" R0100-00-SELECT-TSISTEMA-DB-SELECT-1 */
        public void R0100_00_SELECT_TSISTEMA_DB_SELECT_1()
        {
            /*" -1263- EXEC SQL SELECT DATA_MOV_ABERTO, DATA_MOV_ABERTO INTO :SISTEMAS-DATA-MOV-ABERTO, :SISTEMAS-DATA-MOV-ABERTO-1 FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'VG' WITH UR END-EXEC. */

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
        /*" R0120-00-SELECT-NUMEROUT-SECTION */
        private void R0120_00_SELECT_NUMEROUT_SECTION()
        {
            /*" -1290- MOVE 'R0120-00-SELECT-NUMEROUT' TO PARAGRAFO. */
            _.Move("R0120-00-SELECT-NUMEROUT", FILLER_1.WABEND.PARAGRAFO);

            /*" -1291- MOVE '0120' TO WNR-EXEC-SQL. */
            _.Move("0120", FILLER_1.WABEND.WNR_EXEC_SQL);

            /*" -1294- DISPLAY PARAGRAFO */
            _.Display(FILLER_1.WABEND.PARAGRAFO);

            /*" -1295- MOVE 03 TO W01-I */
            _.Move(03, FILLER_0.W01_I);

            /*" -1296- MOVE 'R0120-SELECT NUMEROUT  ' TO W01-TEXTO(W01-I) */
            _.Move("R0120-SELECT NUMEROUT  ", FILLER_0.W01_TABELA_TEXTO.W01_TAB_TEXTO[FILLER_0.W01_I].W01_TEXTO);

            /*" -1300- PERFORM R8900-TOTALIZA-INICIO THRU R8900-TOTALIZA-INICIO-EXIT */

            R8900_TOTALIZA_INICIO_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8900_TOTALIZA_INICIO_EXIT*/


            /*" -1309- PERFORM R0120_00_SELECT_NUMEROUT_DB_SELECT_1 */

            R0120_00_SELECT_NUMEROUT_DB_SELECT_1();

            /*" -1313- MOVE 1 TO W01-QTD-ACC-OK */
            _.Move(1, FILLER_0.W01_QTD_ACC_OK);

            /*" -1317- PERFORM R8910-TOTALIZA-FINAL THRU R8910-TOTALIZA-FINAL-EXIT */

            R8910_TOTALIZA_FINAL_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8910_TOTALIZA_FINAL_EXIT*/


            /*" -1318- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1320- DISPLAY 'VG1613B - NAO EXISTE NUM.CERT. NUMEROS-OUTROS' */
                _.Display($"VG1613B - NAO EXISTE NUM.CERT. NUMEROS-OUTROS");

                /*" -1320- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0120-00-SELECT-NUMEROUT-DB-SELECT-1 */
        public void R0120_00_SELECT_NUMEROUT_DB_SELECT_1()
        {
            /*" -1309- EXEC SQL SELECT NUM_CERT_VGAP , NUM_CLIENTE INTO :NUMEROUT-NUM-CERT-VGAP , :NUMEROUT-NUM-CLIENTE FROM SEGUROS.NUMERO_OUTROS END-EXEC. */

            var r0120_00_SELECT_NUMEROUT_DB_SELECT_1_Query1 = new R0120_00_SELECT_NUMEROUT_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0120_00_SELECT_NUMEROUT_DB_SELECT_1_Query1.Execute(r0120_00_SELECT_NUMEROUT_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.NUMEROUT_NUM_CERT_VGAP, NUMEROUT.DCLNUMERO_OUTROS.NUMEROUT_NUM_CERT_VGAP);
                _.Move(executed_1.NUMEROUT_NUM_CLIENTE, NUMEROUT.DCLNUMERO_OUTROS.NUMEROUT_NUM_CLIENTE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0120_99_SAIDA*/

        [StopWatch]
        /*" R0910-00-LE-MOVIMENTO-SECTION */
        private void R0910_00_LE_MOVIMENTO_SECTION()
        {
            /*" -1329- MOVE 'R0910-00-LE-MOVIMENTO' TO PARAGRAFO. */
            _.Move("R0910-00-LE-MOVIMENTO", FILLER_1.WABEND.PARAGRAFO);

            /*" -1330- MOVE '0910' TO WNR-EXEC-SQL. */
            _.Move("0910", FILLER_1.WABEND.WNR_EXEC_SQL);

            /*" -1332- DISPLAY PARAGRAFO */
            _.Display(FILLER_1.WABEND.PARAGRAFO);

            /*" -1333- READ ARQUIVO-LEITURA AT END */
            try
            {
                ARQUIVO_LEITURA.Read(() =>
                {

                    /*" -1336- MOVE 'SIM' TO FIM-MOVIMENTO */
                    _.Move("SIM", FILLER_1.FILLER_15.FIM_MOVIMENTO);

                    /*" -1338- GO TO R0910-99-SAIDA. */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/ //GOTO
                    return;
                });

                _.Move(ARQUIVO_LEITURA.Value, REGISTRO_LEITURA);

            }
            catch (GoToException ex)
            {
                return;
            }
            /*" -1353- UNSTRING REGISTRO-LEITURA DELIMITED BY ';' INTO NOME-REG CPF-REG DTNAS-REG SEXO-REG ESTCIV-REG SALARIO-REG QTDSAL-REG IS-REG PREMIO-REG NUM-APOLICE-REG SUBGRUPO-REG DTVIG-REG LIXO1. */
            _.Unstring(REGISTRO_LEITURA,
                [new UnstringDelimitedParameter(";")],
                [new UnstringIntoParameter(REGISTRO_WORK.NOME_REG)
                ,new UnstringIntoParameter(REGISTRO_WORK.CPF_REG)
                ,new UnstringIntoParameter(REGISTRO_WORK.DTNAS_REG)
                ,new UnstringIntoParameter(REGISTRO_WORK.SEXO_REG)
                ,new UnstringIntoParameter(REGISTRO_WORK.ESTCIV_REG)
                ,new UnstringIntoParameter(REGISTRO_WORK.SALARIO_REG)
                ,new UnstringIntoParameter(REGISTRO_WORK.QTDSAL_REG)
                ,new UnstringIntoParameter(REGISTRO_WORK.IS_REG)
                ,new UnstringIntoParameter(REGISTRO_WORK.PREMIO_REG)
                ,new UnstringIntoParameter(REGISTRO_WORK.NUM_APOLICE_REG)
                ,new UnstringIntoParameter(REGISTRO_WORK.SUBGRUPO_REG)
                ,new UnstringIntoParameter(REGISTRO_WORK.DTVIG_REG)
                ,new UnstringIntoParameter(REGISTRO_WORK.LIXO1)
            ]);

            /*" -1355- ADD 1 TO AC-LIDOS AC-LIDOS-M. */
            FILLER_1.AC_LIDOS.Value = FILLER_1.AC_LIDOS + 1;
            FILLER_1.AC_LIDOS_M.Value = FILLER_1.AC_LIDOS_M + 1;

            /*" -1357- IF (AC-LIDOS GREATER 999) */

            if ((FILLER_1.AC_LIDOS > 999))
            {

                /*" -1358- MOVE ZEROS TO AC-LIDOS */
                _.Move(0, FILLER_1.AC_LIDOS);

                /*" -1359- ACCEPT WS-TIME FROM TIME */
                _.Move(_.AcceptDate("TIME"), FILLER_1.WS_TIME);

                /*" -1360- DISPLAY 'LIDOS MOVIMENTO   ' AC-LIDOS-M ' ' WS-TIME */

                $"LIDOS MOVIMENTO   {FILLER_1.AC_LIDOS_M} {FILLER_1.WS_TIME}"
                .Display();

                /*" -1362- END-IF. */
            }


            /*" -1364- IF (NUM-APOLICE-REG EQUAL ZEROES) OR (NUM-APOLICE-REG EQUAL 0097010000889) */

            if ((REGISTRO_WORK.NUM_APOLICE_REG == 00) || (REGISTRO_WORK.NUM_APOLICE_REG == 0097010000889))
            {

                /*" -1365- GO TO R0910-00-LE-MOVIMENTO */
                new Task(() => R0910_00_LE_MOVIMENTO_SECTION()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...

                /*" -1366- ELSE */
            }
            else
            {


                /*" -1367- IF (SUBGRUPO-REG EQUAL ZEROES) */

                if ((REGISTRO_WORK.SUBGRUPO_REG == 00))
                {

                    /*" -1368- GO TO R0910-00-LE-MOVIMENTO */
                    new Task(() => R0910_00_LE_MOVIMENTO_SECTION()).RunSynchronously(); //GOTO
                    return;//Recursividade detectada, cuidado...

                    /*" -1369- END-IF */
                }


                /*" -1369- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-SECTION */
        private void R1000_00_PROCESSA_REGISTRO_SECTION()
        {
            /*" -1378- MOVE 'R1000-00-PROCESSA-REGISTRO' TO PARAGRAFO. */
            _.Move("R1000-00-PROCESSA-REGISTRO", FILLER_1.WABEND.PARAGRAFO);

            /*" -1379- MOVE '1000' TO WNR-EXEC-SQL. */
            _.Move("1000", FILLER_1.WABEND.WNR_EXEC_SQL);

            /*" -1381- DISPLAY PARAGRAFO */
            _.Display(FILLER_1.WABEND.PARAGRAFO);

            /*" -1382- MOVE FUNCTION UPPER-CASE(NOME-REG) TO NOME-SOR */
            _.Move(REGISTRO_WORK.NOME_REG.ToString().ToUpper(), REGISTRO_SORT.NOME_SOR);

            /*" -1383- MOVE CPF-REG TO CPF-SOR */
            _.Move(REGISTRO_WORK.CPF_REG, REGISTRO_SORT.CPF_SOR);

            /*" -1384- MOVE DTNAS-REG TO DTNAS-SOR */
            _.Move(REGISTRO_WORK.DTNAS_REG, REGISTRO_SORT.DTNAS_SOR);

            /*" -1385- MOVE SEXO-REG TO SEXO-SOR */
            _.Move(REGISTRO_WORK.SEXO_REG, REGISTRO_SORT.SEXO_SOR);

            /*" -1386- MOVE ESTCIV-REG TO ESTCIV-SOR */
            _.Move(REGISTRO_WORK.ESTCIV_REG, REGISTRO_SORT.ESTCIV_SOR);

            /*" -1387- MOVE SALARIO-REG TO SALARIO-SOR-R */
            _.Move(REGISTRO_WORK.SALARIO_REG, REGISTRO_SORT.SALARIO_SOR_R);

            /*" -1388- MOVE QTDSAL-REG TO QTDSAL-SOR */
            _.Move(REGISTRO_WORK.QTDSAL_REG, REGISTRO_SORT.QTDSAL_SOR);

            /*" -1389- MOVE IS-REG TO IS-SOR-R */
            _.Move(REGISTRO_WORK.IS_REG, REGISTRO_SORT.IS_SOR_R);

            /*" -1390- MOVE PREMIO-REG TO PREMIO-SOR-R */
            _.Move(REGISTRO_WORK.PREMIO_REG, REGISTRO_SORT.PREMIO_SOR_R);

            /*" -1391- MOVE NUM-APOLICE-REG TO NUM-APOLICE-SOR */
            _.Move(REGISTRO_WORK.NUM_APOLICE_REG, REGISTRO_SORT.NUM_APOLICE_SOR);

            /*" -1392- MOVE SUBGRUPO-REG TO SUBGRUPO-SOR. */
            _.Move(REGISTRO_WORK.SUBGRUPO_REG, REGISTRO_SORT.SUBGRUPO_SOR);

            /*" -1393- MOVE DTVIG-REG TO DTVIG-SOR. */
            _.Move(REGISTRO_WORK.DTVIG_REG, REGISTRO_SORT.DTVIG_SOR);

            /*" -1393- RELEASE REGISTRO-SORT. */
            ARQUIVO_SORT.Release(REGISTRO_SORT);

            /*" -0- FLUXCONTROL_PERFORM R1000_10_NEXT */

            R1000_10_NEXT();

        }

        [StopWatch]
        /*" R1000-10-NEXT */
        private void R1000_10_NEXT(bool isPerform = false)
        {
            /*" -1396- PERFORM R0910-00-LE-MOVIMENTO. */

            R0910_00_LE_MOVIMENTO_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1910-00-LE-SORT-SECTION */
        private void R1910_00_LE_SORT_SECTION()
        {
            /*" -1405- MOVE 'R1910-00-LE-SORT' TO PARAGRAFO. */
            _.Move("R1910-00-LE-SORT", FILLER_1.WABEND.PARAGRAFO);

            /*" -1406- MOVE '1910' TO WNR-EXEC-SQL. */
            _.Move("1910", FILLER_1.WABEND.WNR_EXEC_SQL);

            /*" -1408- DISPLAY PARAGRAFO */
            _.Display(FILLER_1.WABEND.PARAGRAFO);

            /*" -1410- RETURN ARQUIVO-SORT AT END */
            try
            {
                ARQUIVO_SORT.Return(REGISTRO_SORT, () =>
                {

                    /*" -1411- MOVE 'SIM' TO FIM-SORT */
                    _.Move("SIM", FILLER_1.FILLER_15.FIM_SORT);

                    /*" -1412- MOVE 9999999999999 TO WS-APOLICE-ATU */
                    _.Move(9999999999999, WS_CHAVE_ATU.WS_APOLICE_ATU);

                    /*" -1413- MOVE 9999 TO WS-SUBGRUPO-ATU */
                    _.Move(9999, WS_CHAVE_ATU.WS_SUBGRUPO_ATU);

                    /*" -1415- GO TO R1910-99-SAIDA. */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1910_99_SAIDA*/ //GOTO
                    return;

                });
            }
            catch (GoToException ex)
            {
                return;
            }
            /*" -1416- MOVE NUM-APOLICE-SOR TO WS-APOLICE-ATU */
            _.Move(REGISTRO_SORT.NUM_APOLICE_SOR, WS_CHAVE_ATU.WS_APOLICE_ATU);

            /*" -1418- MOVE SUBGRUPO-SOR TO WS-SUBGRUPO-ATU. */
            _.Move(REGISTRO_SORT.SUBGRUPO_SOR, WS_CHAVE_ATU.WS_SUBGRUPO_ATU);

            /*" -1419- IF SUBGRUPO-SOR EQUAL ZEROS */

            if (REGISTRO_SORT.SUBGRUPO_SOR == 00)
            {

                /*" -1420- PERFORM R9930-00-MOVIMVGA-SUBGRUPO */

                R9930_00_MOVIMVGA_SUBGRUPO_SECTION();

                /*" -1421- MOVE 01 TO RETURN-CODE */
                _.Move(01, RETURN_CODE);

                /*" -1423- GO TO R9000-00-FINALIZA. */

                R9000_00_FINALIZA_SECTION(); //GOTO
                return;
            }


            /*" -1423- ADD 1 TO AC-LIDOS-S. */
            FILLER_1.AC_LIDOS_S.Value = FILLER_1.AC_LIDOS_S + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1910_99_SAIDA*/

        [StopWatch]
        /*" R2000-00-PROCESSA-APOLICE-SECTION */
        private void R2000_00_PROCESSA_APOLICE_SECTION()
        {
            /*" -1432- MOVE 'R2000-00-PROCESSA-APOLICE' TO PARAGRAFO. */
            _.Move("R2000-00-PROCESSA-APOLICE", FILLER_1.WABEND.PARAGRAFO);

            /*" -1433- MOVE '2000' TO WNR-EXEC-SQL. */
            _.Move("2000", FILLER_1.WABEND.WNR_EXEC_SQL);

            /*" -1435- DISPLAY PARAGRAFO */
            _.Display(FILLER_1.WABEND.PARAGRAFO);

            /*" -1437- INITIALIZE TAB-RESUMO. */
            _.Initialize(
                TAB_RESUMO
            );

            /*" -1439- PERFORM R2160-00-SELECT-PRODUTOSVG. */

            R2160_00_SELECT_PRODUTOSVG_SECTION();

            /*" -1440- IF WTEM-EMPRES EQUAL 'SIM' */

            if (FILLER_1.FILLER_15.WTEM_EMPRES == "SIM")
            {

                /*" -1442- MOVE 'APOLICE NAO PROCESSADA - EH EMPRESARIAL' TO OBSERVACAO-SAI2 */
                _.Move("APOLICE NAO PROCESSADA - EH EMPRESARIAL", REGISTRO_SAIDA2.OBSERVACAO_SAI2);

                /*" -1444- MOVE SPACES TO SUBES-SAI2 */
                _.Move("", REGISTRO_SAIDA2.SUBES_SAI2);

                /*" -1446- MOVE WS-APOLICE-ATU TO NUM-APOLICE-SAI2 */
                _.Move(WS_CHAVE_ATU.WS_APOLICE_ATU, REGISTRO_SAIDA2.NUM_APOLICE_SAI2);

                /*" -1448- MOVE WS-SUBGRUPO-ATU TO SUBGRUPO-SAI2 */
                _.Move(WS_CHAVE_ATU.WS_SUBGRUPO_ATU, REGISTRO_SAIDA2.SUBGRUPO_SAI2);

                /*" -1450- WRITE REGISTRO-RETORNO FROM REGISTRO-SAIDA2 */
                _.Move(REGISTRO_SAIDA2.GetMoveValues(), REGISTRO_RETORNO);

                ARQUIVO_RETORNO.Write(REGISTRO_RETORNO.GetMoveValues().ToString());

                /*" -1451- MOVE WS-CHAVE-ATU TO WS-CHAVE-ANT */
                _.Move(WS_CHAVE_ATU, WS_CHAVE_ANT);

                /*" -1454- PERFORM R1910-00-LE-SORT UNTIL WS-APOLICE-ATU NOT EQUAL WS-APOLICE-ANT OR FIM-SORT EQUAL 'SIM' */

                while (!(WS_CHAVE_ATU.WS_APOLICE_ATU != WS_CHAVE_ANT_R.WS_APOLICE_ANT || FILLER_1.FILLER_15.FIM_SORT == "SIM"))
                {

                    R1910_00_LE_SORT_SECTION();
                }

                /*" -1455- GO TO R2000-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_99_SAIDA*/ //GOTO
                return;

                /*" -1457- END-IF. */
            }


            /*" -1459- PERFORM R8000-00-DECLARE-SUBGVGAP. */

            R8000_00_DECLARE_SUBGVGAP_SECTION();

            /*" -1461- PERFORM R8010-00-FETCH-SUBGVGAP. */

            R8010_00_FETCH_SUBGVGAP_SECTION();

            /*" -1464- PERFORM R8100-00-PROCESSA-SUBGVGAP UNTIL WFIM-SUBGVGAP EQUAL 'SIM' . */

            while (!(FILLER_1.FILLER_15.WFIM_SUBGVGAP == "SIM"))
            {

                R8100_00_PROCESSA_SUBGVGAP_SECTION();
            }

            /*" -1467- MOVE NUM-APOLICE-SOR TO WS-APOLICE-ANT */
            _.Move(REGISTRO_SORT.NUM_APOLICE_SOR, WS_CHAVE_ANT_R.WS_APOLICE_ANT);

            /*" -1471- PERFORM R2003-00-PROCESSA-SUBGVGAP UNTIL NUM-APOLICE-SOR NOT EQUAL WS-APOLICE-ANT OR FIM-SORT EQUAL 'SIM' . */

            while (!(REGISTRO_SORT.NUM_APOLICE_SOR != WS_CHAVE_ANT_R.WS_APOLICE_ANT || FILLER_1.FILLER_15.FIM_SORT == "SIM"))
            {

                R2003_00_PROCESSA_SUBGVGAP_SECTION();
            }

            /*" -1473- MOVE ZEROS TO WS-IND. */
            _.Move(0, WS_IND);

            /*" -1473- PERFORM R3900-00-GRAVA-RESUMO. */

            R3900_00_GRAVA_RESUMO_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_99_SAIDA*/

        [StopWatch]
        /*" R2003-00-PROCESSA-SUBGVGAP-SECTION */
        private void R2003_00_PROCESSA_SUBGVGAP_SECTION()
        {
            /*" -1482- MOVE 'R2003-00-PROCESSA-SUBGVGAP' TO PARAGRAFO. */
            _.Move("R2003-00-PROCESSA-SUBGVGAP", FILLER_1.WABEND.PARAGRAFO);

            /*" -1483- MOVE '2003' TO WNR-EXEC-SQL. */
            _.Move("2003", FILLER_1.WABEND.WNR_EXEC_SQL);

            /*" -1485- DISPLAY PARAGRAFO */
            _.Display(FILLER_1.WABEND.PARAGRAFO);

            /*" -1486- MOVE WS-CHAVE-ATU TO WS-CHAVE-ANT */
            _.Move(WS_CHAVE_ATU, WS_CHAVE_ANT);

            /*" -1487- MOVE 1 TO INF */
            _.Move(1, INF);

            /*" -1489- MOVE WINDM TO SUP */
            _.Move(WINDM, SUP);

            /*" -1491- PERFORM R8110-00-PESQUISA-SUBGVGAP */

            R8110_00_PESQUISA_SUBGVGAP_SECTION();

            /*" -1492- IF WS-TEM-SUBGRUPO = 'NAO' */

            if (WS_TEM_SUBGRUPO == "NAO")
            {

                /*" -1494- MOVE 'SUBGRUPO NAO CADASTRADO OU CANCELADO' TO OBSERVACAO-SAI2 */
                _.Move("SUBGRUPO NAO CADASTRADO OU CANCELADO", REGISTRO_SAIDA2.OBSERVACAO_SAI2);

                /*" -1496- MOVE SPACES TO SUBES-SAI2 */
                _.Move("", REGISTRO_SAIDA2.SUBES_SAI2);

                /*" -1498- MOVE WS-APOLICE-ANT TO NUM-APOLICE-SAI2 */
                _.Move(WS_CHAVE_ANT_R.WS_APOLICE_ANT, REGISTRO_SAIDA2.NUM_APOLICE_SAI2);

                /*" -1500- MOVE WS-SUBGRUPO-ANT TO SUBGRUPO-SAI2 */
                _.Move(WS_CHAVE_ANT_R.WS_SUBGRUPO_ANT, REGISTRO_SAIDA2.SUBGRUPO_SAI2);

                /*" -1502- WRITE REGISTRO-RETORNO FROM REGISTRO-SAIDA2 */
                _.Move(REGISTRO_SAIDA2.GetMoveValues(), REGISTRO_RETORNO);

                ARQUIVO_RETORNO.Write(REGISTRO_RETORNO.GetMoveValues().ToString());

                /*" -1503- MOVE WS-CHAVE-ATU TO WS-CHAVE-ANT */
                _.Move(WS_CHAVE_ATU, WS_CHAVE_ANT);

                /*" -1506- PERFORM R1910-00-LE-SORT UNTIL WS-CHAVE-ATU NOT EQUAL WS-CHAVE-ANT OR FIM-SORT EQUAL 'SIM' */

                while (!(WS_CHAVE_ATU != WS_CHAVE_ANT || FILLER_1.FILLER_15.FIM_SORT == "SIM"))
                {

                    R1910_00_LE_SORT_SECTION();
                }

                /*" -1507- GO TO R2003-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2003_99_SAIDA*/ //GOTO
                return;

                /*" -1509- END-IF. */
            }


            /*" -1511- MOVE WS-APOLICE-ATU TO SUBGVGAP-NUM-APOLICE */
            _.Move(WS_CHAVE_ATU.WS_APOLICE_ATU, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_NUM_APOLICE);

            /*" -1514- MOVE WS-SUBGRUPO-ATU TO SUBGVGAP-COD-SUBGRUPO */
            _.Move(WS_CHAVE_ATU.WS_SUBGRUPO_ATU, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_SUBGRUPO);

            /*" -1517- MOVE SPACES TO OBSERVACAO-SAI2 */
            _.Move("", REGISTRO_SAIDA2.OBSERVACAO_SAI2);

            /*" -1519- PERFORM R3200-00-SELECT-PRINCIPAL. */

            R3200_00_SELECT_PRINCIPAL_SECTION();

            /*" -1520- IF WTEM-SUBGVGAP = 'NAO' */

            if (FILLER_1.FILLER_15.WTEM_SUBGVGAP == "NAO")
            {

                /*" -1521- IF (OBSERVACAO-SAI2 EQUAL SPACES) */

                if ((REGISTRO_SAIDA2.OBSERVACAO_SAI2.IsEmpty()))
                {

                    /*" -1523- MOVE 'PROBLEMAS NO SUBGRUPO               ' TO OBSERVACAO-SAI2 */
                    _.Move("PROBLEMAS NO SUBGRUPO               ", REGISTRO_SAIDA2.OBSERVACAO_SAI2);

                    /*" -1525- END-IF */
                }


                /*" -1527- MOVE SPACES TO SUBES-SAI2 */
                _.Move("", REGISTRO_SAIDA2.SUBES_SAI2);

                /*" -1529- MOVE WS-APOLICE-ANT TO NUM-APOLICE-SAI2 */
                _.Move(WS_CHAVE_ANT_R.WS_APOLICE_ANT, REGISTRO_SAIDA2.NUM_APOLICE_SAI2);

                /*" -1531- MOVE WS-SUBGRUPO-ANT TO SUBGRUPO-SAI2 */
                _.Move(WS_CHAVE_ANT_R.WS_SUBGRUPO_ANT, REGISTRO_SAIDA2.SUBGRUPO_SAI2);

                /*" -1533- WRITE REGISTRO-RETORNO FROM REGISTRO-SAIDA2 */
                _.Move(REGISTRO_SAIDA2.GetMoveValues(), REGISTRO_RETORNO);

                ARQUIVO_RETORNO.Write(REGISTRO_RETORNO.GetMoveValues().ToString());

                /*" -1534- MOVE WS-CHAVE-ATU TO WS-CHAVE-ANT */
                _.Move(WS_CHAVE_ATU, WS_CHAVE_ANT);

                /*" -1537- PERFORM R1910-00-LE-SORT UNTIL WS-CHAVE-ATU NOT EQUAL WS-CHAVE-ANT OR FIM-SORT EQUAL 'SIM' */

                while (!(WS_CHAVE_ATU != WS_CHAVE_ANT || FILLER_1.FILLER_15.FIM_SORT == "SIM"))
                {

                    R1910_00_LE_SORT_SECTION();
                }

                /*" -1538- GO TO R2003-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2003_99_SAIDA*/ //GOTO
                return;

                /*" -1540- END-IF. */
            }


            /*" -1542- PERFORM R2500-00-SELECT-ENDERECO */

            R2500_00_SELECT_ENDERECO_SECTION();

            /*" -1544- PERFORM R2600-00-UPDATE-SEGURVGA */

            R2600_00_UPDATE_SEGURVGA_SECTION();

            /*" -1547- MOVE SUBGVGAP-COD-FONTE TO SUBGVGAP-COD-FONTE-ANT */
            _.Move(SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_FONTE, SUBGVGAP_COD_FONTE_ANT);

            /*" -1549- MOVE 'NAO' TO WS-ERRO-SUBGRUPO */
            _.Move("NAO", WS_ERRO_SUBGRUPO);

            /*" -1553- MOVE CLIENTES-NOME-RAZAO TO SUBES-SAI SUBES-SAI2. */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO, REGISTRO_SAIDA.SUBES_SAI, REGISTRO_SAIDA2.SUBES_SAI2);

            /*" -1556- MOVE SUBGRUPO-SOR TO WS-SUBGRUPO-ANT */
            _.Move(REGISTRO_SORT.SUBGRUPO_SOR, WS_CHAVE_ANT_R.WS_SUBGRUPO_ANT);

            /*" -1561- MOVE ZEROS TO WS-TOT-PREMIO WS-CPF-ANT WS-TOT-CRITIC */
            _.Move(0, WS_TOT_PREMIO, WS_CPF_ANT, WS_TOT_CRITIC);

            /*" -1566- PERFORM R2005-00-PROCESSA-REGISTRO UNTIL NUM-APOLICE-SOR NOT EQUAL WS-APOLICE-ANT OR SUBGRUPO-SOR NOT EQUAL WS-SUBGRUPO-ANT OR FIM-SORT EQUAL 'SIM' . */

            while (!(REGISTRO_SORT.NUM_APOLICE_SOR != WS_CHAVE_ANT_R.WS_APOLICE_ANT || REGISTRO_SORT.SUBGRUPO_SOR != WS_CHAVE_ANT_R.WS_SUBGRUPO_ANT || FILLER_1.FILLER_15.FIM_SORT == "SIM"))
            {

                R2005_00_PROCESSA_REGISTRO_SECTION();
            }

            /*" -1568- PERFORM R6000-00-INSERE-RELATORIO. */

            R6000_00_INSERE_RELATORIO_SECTION();

            /*" -1569- IF WS-ERRO-SUBGRUPO = 'NAO' */

            if (WS_ERRO_SUBGRUPO == "NAO")
            {

                /*" -1571- MOVE 'SUBGRUPO SEM ERROS DE CRITICA' TO OBSERVACAO-SAI2 */
                _.Move("SUBGRUPO SEM ERROS DE CRITICA", REGISTRO_SAIDA2.OBSERVACAO_SAI2);

                /*" -1573- MOVE WS-APOLICE-ANT TO NUM-APOLICE-SAI2 */
                _.Move(WS_CHAVE_ANT_R.WS_APOLICE_ANT, REGISTRO_SAIDA2.NUM_APOLICE_SAI2);

                /*" -1575- MOVE WS-SUBGRUPO-ANT TO SUBGRUPO-SAI2 */
                _.Move(WS_CHAVE_ANT_R.WS_SUBGRUPO_ANT, REGISTRO_SAIDA2.SUBGRUPO_SAI2);

                /*" -1577- WRITE REGISTRO-RETORNO FROM REGISTRO-SAIDA2 */
                _.Move(REGISTRO_SAIDA2.GetMoveValues(), REGISTRO_RETORNO);

                ARQUIVO_RETORNO.Write(REGISTRO_RETORNO.GetMoveValues().ToString());

                /*" -1578- ELSE */
            }
            else
            {


                /*" -1580- MOVE 'SUBGRUPO APRESENTA ERROS DE CRITICA' TO OBSERVACAO-SAI2 */
                _.Move("SUBGRUPO APRESENTA ERROS DE CRITICA", REGISTRO_SAIDA2.OBSERVACAO_SAI2);

                /*" -1582- MOVE WS-APOLICE-ANT TO NUM-APOLICE-SAI2 */
                _.Move(WS_CHAVE_ANT_R.WS_APOLICE_ANT, REGISTRO_SAIDA2.NUM_APOLICE_SAI2);

                /*" -1584- MOVE WS-SUBGRUPO-ANT TO SUBGRUPO-SAI2 */
                _.Move(WS_CHAVE_ANT_R.WS_SUBGRUPO_ANT, REGISTRO_SAIDA2.SUBGRUPO_SAI2);

                /*" -1586- WRITE REGISTRO-RETORNO FROM REGISTRO-SAIDA2 */
                _.Move(REGISTRO_SAIDA2.GetMoveValues(), REGISTRO_RETORNO);

                ARQUIVO_RETORNO.Write(REGISTRO_RETORNO.GetMoveValues().ToString());

                /*" -1588- END-IF */
            }


            /*" -1589- MOVE WS-QTDE-MOVTO TO TAB-QTDE-MOVTO (WS-IND) */
            _.Move(WS_QTDE_MOVTO, TAB_RESUMO.TAB_RES[WS_IND].TAB_QTDE_MOVTO);

            /*" -1590- MOVE WS-QTDE-CRITIC TO TAB-QTDE-CRITIC(WS-IND) */
            _.Move(WS_QTDE_CRITIC, TAB_RESUMO.TAB_RES[WS_IND].TAB_QTDE_CRITIC);

            /*" -1591- MOVE WS-TOT-CRITIC TO TAB-VLR-CRITIC (WS-IND) */
            _.Move(WS_TOT_CRITIC, TAB_RESUMO.TAB_RES[WS_IND].TAB_VLR_CRITIC);

            /*" -1593- MOVE WS-TOT-PREMIO TO TAB-VLR-MOVTO (WS-IND) */
            _.Move(WS_TOT_PREMIO, TAB_RESUMO.TAB_RES[WS_IND].TAB_VLR_MOVTO);

            /*" -1594- MOVE ZEROS TO WS-QTDE-MOVTO WS-QTDE-CRITIC. */
            _.Move(0, WS_QTDE_MOVTO, WS_QTDE_CRITIC);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2003_99_SAIDA*/

        [StopWatch]
        /*" R2005-00-PROCESSA-REGISTRO-SECTION */
        private void R2005_00_PROCESSA_REGISTRO_SECTION()
        {
            /*" -1603- MOVE 'R2005-00-PROCESSA-REGISTRO' TO PARAGRAFO. */
            _.Move("R2005-00-PROCESSA-REGISTRO", FILLER_1.WABEND.PARAGRAFO);

            /*" -1604- MOVE '2005' TO WNR-EXEC-SQL. */
            _.Move("2005", FILLER_1.WABEND.WNR_EXEC_SQL);

            /*" -1606- DISPLAY PARAGRAFO */
            _.Display(FILLER_1.WABEND.PARAGRAFO);

            /*" -1612- MOVE ZEROS TO COD-ERRO-SOR */
            _.Move(0, REGISTRO_SORT.COD_ERRO_SOR);

            /*" -1613- IF (CPF-SOR EQUAL WS-CPF-ANT) */

            if ((REGISTRO_SORT.CPF_SOR == WS_CPF_ANT))
            {

                /*" -1614- MOVE 4038 TO COD-ERRO-SOR */
                _.Move(4038, REGISTRO_SORT.COD_ERRO_SOR);

                /*" -1615- PERFORM R2020-00-GRAVA-RETORNO */

                R2020_00_GRAVA_RETORNO_SECTION();

                /*" -1616- MOVE 'NAO' TO WS-ERRO-MOVTO */
                _.Move("NAO", WS_ERRO_MOVTO);

                /*" -1617- MOVE 'NAO' TO WS-ERRO-SUBGRUPO */
                _.Move("NAO", WS_ERRO_SUBGRUPO);

                /*" -1619- ADD 1 TO WS-QTDE-DUPLIC WS-QTDE-CRITIC */
                WS_QTDE_DUPLIC.Value = WS_QTDE_DUPLIC + 1;
                WS_QTDE_CRITIC.Value = WS_QTDE_CRITIC + 1;

                /*" -1620- ADD PREMIO-SOR TO WS-TOT-CRITIC */
                WS_TOT_CRITIC.Value = WS_TOT_CRITIC + REGISTRO_SORT.PREMIO_SOR;

                /*" -1621- GO TO R2005-10-NEXT */

                R2005_10_NEXT(); //GOTO
                return;

                /*" -1623- END-IF. */
            }


            /*" -1627- MOVE CPF-SOR TO WS-CPF-ANT. */
            _.Move(REGISTRO_SORT.CPF_SOR, WS_CPF_ANT);

            /*" -1628- MOVE CPF-SOR TO CLIENTES-CGCCPF */
            _.Move(REGISTRO_SORT.CPF_SOR, CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF);

            /*" -1630- MOVE 'NAO' TO WS-ERRO-MOVTO WS-ERRO-CPF */
            _.Move("NAO", WS_ERRO_MOVTO, WS_ERRO_CPF);

            /*" -1634- MOVE ZEROS TO FL-ERRO */
            _.Move(0, FILLER_1.FL_ERRO);

            /*" -1637- IF CPF-SOR IS NOT NUMERIC OR CPF-SOR = ZEROS */

            if (!REGISTRO_SORT.CPF_SOR.IsNumeric() || REGISTRO_SORT.CPF_SOR == 00)
            {

                /*" -1639- MOVE 401 TO COD-ERRO-SOR */
                _.Move(401, REGISTRO_SORT.COD_ERRO_SOR);

                /*" -1640- PERFORM R2020-00-GRAVA-RETORNO */

                R2020_00_GRAVA_RETORNO_SECTION();

                /*" -1643- MOVE 'SIM' TO WS-ERRO-MOVTO WS-ERRO-CPF WS-ERRO-SUBGRUPO */
                _.Move("SIM", WS_ERRO_MOVTO, WS_ERRO_CPF, WS_ERRO_SUBGRUPO);

                /*" -1644- ELSE */
            }
            else
            {


                /*" -1648- PERFORM R2200-00-SELECT-SEGURVGA */

                R2200_00_SELECT_SEGURVGA_SECTION();

                /*" -1649- IF NOME-SOR EQUAL SPACES */

                if (REGISTRO_SORT.NOME_SOR.IsEmpty())
                {

                    /*" -1651- MOVE 301 TO COD-ERRO-SOR */
                    _.Move(301, REGISTRO_SORT.COD_ERRO_SOR);

                    /*" -1652- PERFORM R2020-00-GRAVA-RETORNO */

                    R2020_00_GRAVA_RETORNO_SECTION();

                    /*" -1654- MOVE 'SIM' TO WS-ERRO-MOVTO WS-ERRO-SUBGRUPO */
                    _.Move("SIM", WS_ERRO_MOVTO, WS_ERRO_SUBGRUPO);

                    /*" -1658- END-IF */
                }


                /*" -1660- MOVE 'NAO' TO WS-ERRO-CPF */
                _.Move("NAO", WS_ERRO_CPF);

                /*" -1663- IF CPF-SOR IS NOT NUMERIC OR CPF-SOR = ZEROS */

                if (!REGISTRO_SORT.CPF_SOR.IsNumeric() || REGISTRO_SORT.CPF_SOR == 00)
                {

                    /*" -1665- MOVE 401 TO COD-ERRO-SOR */
                    _.Move(401, REGISTRO_SORT.COD_ERRO_SOR);

                    /*" -1666- PERFORM R2020-00-GRAVA-RETORNO */

                    R2020_00_GRAVA_RETORNO_SECTION();

                    /*" -1669- MOVE 'SIM' TO WS-ERRO-MOVTO WS-ERRO-CPF WS-ERRO-SUBGRUPO */
                    _.Move("SIM", WS_ERRO_MOVTO, WS_ERRO_CPF, WS_ERRO_SUBGRUPO);

                    /*" -1670- ELSE */
                }
                else
                {


                    /*" -1693- IF CPF-SOR = 1910000000 OR 9100000000 OR 10000000000 OR 20000000000 OR 30000000000 OR 40000000000 OR 50000000000 OR 60000000000 OR 70000000000 OR 80000000000 OR 90000000000 OR 11000000000 OR 17500000000 OR 11111111111 OR 22222222222 OR 33333333333 OR 44444444444 OR 55555555555 OR 66666666666 OR 77777777777 OR 88888888888 OR 99999999999 */

                    if (REGISTRO_SORT.CPF_SOR.In("1910000000", "9100000000", "10000000000", "20000000000", "30000000000", "40000000000", "50000000000", "60000000000", "70000000000", "80000000000", "90000000000", "11000000000", "17500000000", "11111111111", "22222222222", "33333333333", "44444444444", "55555555555", "66666666666", "77777777777", "88888888888", "99999999999"))
                    {

                        /*" -1695- MOVE 402 TO COD-ERRO-SOR */
                        _.Move(402, REGISTRO_SORT.COD_ERRO_SOR);

                        /*" -1696- PERFORM R2020-00-GRAVA-RETORNO */

                        R2020_00_GRAVA_RETORNO_SECTION();

                        /*" -1699- MOVE 'SIM' TO WS-ERRO-MOVTO WS-ERRO-CPF WS-ERRO-SUBGRUPO */
                        _.Move("SIM", WS_ERRO_MOVTO, WS_ERRO_CPF, WS_ERRO_SUBGRUPO);

                        /*" -1700- ELSE */
                    }
                    else
                    {


                        /*" -1702- MOVE CPF-SOR TO LPARM01 */
                        _.Move(REGISTRO_SORT.CPF_SOR, LPARM01);

                        /*" -1703- CALL 'PROCPF01' USING LPARM01 */
                        _.Call("PROCPF01", LPARM01);

                        /*" -1706- IF LPARM01 (10:2) NOT EQUAL CPF-SOR (10:2) */

                        if (LPARM01.Substring(10, 2) != REGISTRO_SORT.CPF_SOR.Substring(10, 2))
                        {

                            /*" -1708- MOVE 402 TO COD-ERRO-SOR */
                            _.Move(402, REGISTRO_SORT.COD_ERRO_SOR);

                            /*" -1709- PERFORM R2020-00-GRAVA-RETORNO */

                            R2020_00_GRAVA_RETORNO_SECTION();

                            /*" -1711- MOVE 'SIM' TO WS-ERRO-MOVTO WS-ERRO-SUBGRUPO */
                            _.Move("SIM", WS_ERRO_MOVTO, WS_ERRO_SUBGRUPO);

                            /*" -1715- END-IF. */
                        }

                    }

                }

            }


            /*" -1721- IF ESTCIV-SOR NOT EQUAL 'S' AND ESTCIV-SOR NOT EQUAL 'C' AND ESTCIV-SOR NOT EQUAL 'V' AND ESTCIV-SOR NOT EQUAL 'D' AND ESTCIV-SOR NOT EQUAL 'O' */

            if (REGISTRO_SORT.ESTCIV_SOR != "S" && REGISTRO_SORT.ESTCIV_SOR != "C" && REGISTRO_SORT.ESTCIV_SOR != "V" && REGISTRO_SORT.ESTCIV_SOR != "D" && REGISTRO_SORT.ESTCIV_SOR != "O")
            {

                /*" -1723- MOVE 507 TO COD-ERRO-SOR */
                _.Move(507, REGISTRO_SORT.COD_ERRO_SOR);

                /*" -1724- PERFORM R2020-00-GRAVA-RETORNO */

                R2020_00_GRAVA_RETORNO_SECTION();

                /*" -1726- MOVE 'SIM' TO WS-ERRO-MOVTO WS-ERRO-SUBGRUPO */
                _.Move("SIM", WS_ERRO_MOVTO, WS_ERRO_SUBGRUPO);

                /*" -1727- MOVE 'O' TO ESTCIV-SOR */
                _.Move("O", REGISTRO_SORT.ESTCIV_SOR);

                /*" -1731- END-IF. */
            }


            /*" -1733- IF SEXO-SOR NOT EQUAL 'M' AND 'F' */

            if (!REGISTRO_SORT.SEXO_SOR.In("M", "F"))
            {

                /*" -1735- MOVE 506 TO COD-ERRO-SOR */
                _.Move(506, REGISTRO_SORT.COD_ERRO_SOR);

                /*" -1736- PERFORM R2020-00-GRAVA-RETORNO */

                R2020_00_GRAVA_RETORNO_SECTION();

                /*" -1738- MOVE 'SIM' TO WS-ERRO-MOVTO WS-ERRO-SUBGRUPO */
                _.Move("SIM", WS_ERRO_MOVTO, WS_ERRO_SUBGRUPO);

                /*" -1742- END-IF. */
            }


            /*" -1744- MOVE DTNAS-AA-SOR TO WS-CRITICA-ANO */
            _.Move(REGISTRO_SORT.DTNAS_SOR.DTNAS_AA_SOR, FILLER_1.WS_DTH_CRITICA_R.WS_CRITICA_ANO);

            /*" -1746- MOVE DTNAS-MM-SOR TO WS-CRITICA-MES */
            _.Move(REGISTRO_SORT.DTNAS_SOR.DTNAS_MM_SOR, FILLER_1.WS_DTH_CRITICA_R.WS_CRITICA_MES);

            /*" -1748- MOVE DTNAS-DD-SOR TO WS-CRITICA-DIA */
            _.Move(REGISTRO_SORT.DTNAS_SOR.DTNAS_DD_SOR, FILLER_1.WS_DTH_CRITICA_R.WS_CRITICA_DIA);

            /*" -1750- MOVE SPACES TO WS-ERRO-DATA */
            _.Move("", WS_ERRO_DATA);

            /*" -1752- PERFORM R2010-00-CONSISTE-DATA */

            R2010_00_CONSISTE_DATA_SECTION();

            /*" -1754- IF WS-ERRO-DATA EQUAL 'SIM' */

            if (WS_ERRO_DATA == "SIM")
            {

                /*" -1756- MOVE 4008 TO COD-ERRO-SOR */
                _.Move(4008, REGISTRO_SORT.COD_ERRO_SOR);

                /*" -1757- PERFORM R2020-00-GRAVA-RETORNO */

                R2020_00_GRAVA_RETORNO_SECTION();

                /*" -1758- MOVE 'SIM' TO WS-ERRO-MOVTO */
                _.Move("SIM", WS_ERRO_MOVTO);

                /*" -1759- MOVE 'SIM' TO WS-ERRO-SUBGRUPO */
                _.Move("SIM", WS_ERRO_SUBGRUPO);

                /*" -1760- ADD 1 TO WS-QTDE-CRITIC */
                WS_QTDE_CRITIC.Value = WS_QTDE_CRITIC + 1;

                /*" -1761- ADD PREMIO-SOR TO WS-TOT-CRITIC */
                WS_TOT_CRITIC.Value = WS_TOT_CRITIC + REGISTRO_SORT.PREMIO_SOR;

                /*" -1762- GO TO R2005-10-NEXT */

                R2005_10_NEXT(); //GOTO
                return;

                /*" -1764- END-IF. */
            }


            /*" -1766- MOVE DTNAS-DD-SOR TO WS-DIA-AUX */
            _.Move(REGISTRO_SORT.DTNAS_SOR.DTNAS_DD_SOR, FILLER_1.WS_DATA_AUX.WS_DIA_AUX);

            /*" -1768- MOVE '-' TO WS-TRA1-AUX */
            _.Move("-", FILLER_1.WS_DATA_AUX.WS_TRA1_AUX);

            /*" -1770- MOVE DTNAS-MM-SOR TO WS-MES-AUX */
            _.Move(REGISTRO_SORT.DTNAS_SOR.DTNAS_MM_SOR, FILLER_1.WS_DATA_AUX.WS_MES_AUX);

            /*" -1772- MOVE '-' TO WS-TRA2-AUX */
            _.Move("-", FILLER_1.WS_DATA_AUX.WS_TRA2_AUX);

            /*" -1774- MOVE DTNAS-AA-SOR TO WS-ANO-AUX */
            _.Move(REGISTRO_SORT.DTNAS_SOR.DTNAS_AA_SOR, FILLER_1.WS_DATA_AUX.WS_ANO_AUX);

            /*" -1779- MOVE WS-DATA-AUX TO WHOST-DATA-NASCIMENTO. */
            _.Move(FILLER_1.WS_DATA_AUX, WHOST_DATA_NASCIMENTO);

            /*" -1782- MOVE SISTEMAS-DATA-MOV-ABERTO(1:4) TO WS-ANO-HOJE. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(1, 4), FILLER_1.WS_DATA_HOJE_R.WS_ANO_HOJE);

            /*" -1785- MOVE SISTEMAS-DATA-MOV-ABERTO(6:2) TO WS-MES-HOJE. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(6, 2), FILLER_1.WS_DATA_HOJE_R.WS_MES_HOJE);

            /*" -1788- MOVE SISTEMAS-DATA-MOV-ABERTO(6:2) TO WS-MES-DIA-HOJE(1:2). */
            _.MoveAtPosition(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(6, 2), FILLER_1.WS_MES_DIA_HOJE, 1, 2);

            /*" -1791- MOVE SISTEMAS-DATA-MOV-ABERTO(9:2) TO WS-MES-DIA-HOJE(3:2). */
            _.MoveAtPosition(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(9, 2), FILLER_1.WS_MES_DIA_HOJE, 3, 2);

            /*" -1793- MOVE DTNAS-SOR TO WS-DATA-NASC. */
            _.Move(REGISTRO_SORT.DTNAS_SOR, FILLER_1.WS_DATA_NASC);

            /*" -1796- MOVE WS-DATA-NASC(6:2) TO WS-MES-DIA-NASC(1:2). */
            _.MoveAtPosition(FILLER_1.WS_DATA_NASC.Substring(6, 2), FILLER_1.WS_MES_DIA_NASC, 1, 2);

            /*" -1799- MOVE WS-DATA-NASC(9:2) TO WS-MES-DIA-NASC(3:2). */
            _.MoveAtPosition(FILLER_1.WS_DATA_NASC.Substring(9, 2), FILLER_1.WS_MES_DIA_NASC, 3, 2);

            /*" -1801- COMPUTE WS-IDADE = WS-ANO-HOJE - WS-ANO-NASC */
            WS_IDADE.Value = FILLER_1.WS_DATA_HOJE_R.WS_ANO_HOJE - FILLER_1.WS_DATA_NASC_R.WS_ANO_NASC;

            /*" -1802- IF WS-MES-DIA-NASC > WS-MES-DIA-HOJE */

            if (FILLER_1.WS_MES_DIA_NASC > FILLER_1.WS_MES_DIA_HOJE)
            {

                /*" -1804- COMPUTE WS-IDADE = WS-IDADE - 1. */
                WS_IDADE.Value = WS_IDADE - 1;
            }


            /*" -1809- IF (WS-IDADE < 14 AND APOLICES-RAMO-EMISSOR EQUAL PARAMRAM-RAMO-AP) OR (WS-IDADE < 14 AND APOLICES-RAMO-EMISSOR EQUAL PARAMRAM-RAMO-VG) */

            if ((WS_IDADE < 14 && APOLICES.DCLAPOLICES.APOLICES_RAMO_EMISSOR == PARAMRAM.DCLPARAMETROS_RAMOS.PARAMRAM_RAMO_AP) || (WS_IDADE < 14 && APOLICES.DCLAPOLICES.APOLICES_RAMO_EMISSOR == PARAMRAM.DCLPARAMETROS_RAMOS.PARAMRAM_RAMO_VG))
            {

                /*" -1810- IF WS-ERRO-CPF = 'NAO' */

                if (WS_ERRO_CPF == "NAO")
                {

                    /*" -1812- MOVE CPF-SOR TO CLIENTES-CGCCPF */
                    _.Move(REGISTRO_SORT.CPF_SOR, CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF);

                    /*" -1813- PERFORM R2200-00-SELECT-SEGURVGA */

                    R2200_00_SELECT_SEGURVGA_SECTION();

                    /*" -1815- IF WTEM-SEGURVGA = 'SIM' NEXT SENTENCE */

                    if (FILLER_1.FILLER_15.WTEM_SEGURVGA == "SIM")
                    {

                        /*" -1816- ELSE */
                    }
                    else
                    {


                        /*" -1818- MOVE 1005 TO COD-ERRO-SOR */
                        _.Move(1005, REGISTRO_SORT.COD_ERRO_SOR);

                        /*" -1819- PERFORM R2020-00-GRAVA-RETORNO */

                        R2020_00_GRAVA_RETORNO_SECTION();

                        /*" -1821- MOVE 'SIM' TO WS-ERRO-MOVTO WS-ERRO-SUBGRUPO */
                        _.Move("SIM", WS_ERRO_MOVTO, WS_ERRO_SUBGRUPO);

                        /*" -1822- ELSE */
                    }

                }
                else
                {


                    /*" -1824- MOVE 1005 TO COD-ERRO-SOR */
                    _.Move(1005, REGISTRO_SORT.COD_ERRO_SOR);

                    /*" -1825- PERFORM R2020-00-GRAVA-RETORNO */

                    R2020_00_GRAVA_RETORNO_SECTION();

                    /*" -1828- MOVE 'SIM' TO WS-ERRO-MOVTO WS-ERRO-SUBGRUPO. */
                    _.Move("SIM", WS_ERRO_MOVTO, WS_ERRO_SUBGRUPO);
                }

            }


            /*" -1837- IF (WS-IDADE > 99 AND APOLICES-RAMO-EMISSOR EQUAL PARAMRAM-RAMO-AP) OR (WS-IDADE > 99 AND APOLICES-RAMO-EMISSOR EQUAL PARAMRAM-RAMO-VG AND APOLICES-COD-PRODUTO NOT EQUAL 9354) */

            if ((WS_IDADE > 99 && APOLICES.DCLAPOLICES.APOLICES_RAMO_EMISSOR == PARAMRAM.DCLPARAMETROS_RAMOS.PARAMRAM_RAMO_AP) || (WS_IDADE > 99 && APOLICES.DCLAPOLICES.APOLICES_RAMO_EMISSOR == PARAMRAM.DCLPARAMETROS_RAMOS.PARAMRAM_RAMO_VG && APOLICES.DCLAPOLICES.APOLICES_COD_PRODUTO != 9354))
            {

                /*" -1838- PERFORM R2085-00-ACESSA-FAIXAETA */

                R2085_00_ACESSA_FAIXAETA_SECTION();

                /*" -1839- IF FAIXAETA-IDADE-FINAL NOT EQUAL 999 */

                if (FAIXAETA.DCLFAIXA_ETARIA.FAIXAETA_IDADE_FINAL != 999)
                {

                    /*" -1840- IF WS-ERRO-CPF = 'NAO' */

                    if (WS_ERRO_CPF == "NAO")
                    {

                        /*" -1842- MOVE CPF-SOR TO CLIENTES-CGCCPF */
                        _.Move(REGISTRO_SORT.CPF_SOR, CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF);

                        /*" -1843- PERFORM R2200-00-SELECT-SEGURVGA */

                        R2200_00_SELECT_SEGURVGA_SECTION();

                        /*" -1845- IF WTEM-SEGURVGA = 'SIM' NEXT SENTENCE */

                        if (FILLER_1.FILLER_15.WTEM_SEGURVGA == "SIM")
                        {

                            /*" -1846- ELSE */
                        }
                        else
                        {


                            /*" -1848- MOVE 1006 TO COD-ERRO-SOR */
                            _.Move(1006, REGISTRO_SORT.COD_ERRO_SOR);

                            /*" -1849- PERFORM R2020-00-GRAVA-RETORNO */

                            R2020_00_GRAVA_RETORNO_SECTION();

                            /*" -1851- MOVE 'SIM' TO WS-ERRO-MOVTO WS-ERRO-SUBGRUPO */
                            _.Move("SIM", WS_ERRO_MOVTO, WS_ERRO_SUBGRUPO);

                            /*" -1852- ELSE */
                        }

                    }
                    else
                    {


                        /*" -1854- MOVE 1006 TO COD-ERRO-SOR */
                        _.Move(1006, REGISTRO_SORT.COD_ERRO_SOR);

                        /*" -1855- PERFORM R2020-00-GRAVA-RETORNO */

                        R2020_00_GRAVA_RETORNO_SECTION();

                        /*" -1857- MOVE 'SIM' TO WS-ERRO-MOVTO. */
                        _.Move("SIM", WS_ERRO_MOVTO);
                    }

                }

            }


            /*" -1858- IF WS-ERRO-MOVTO EQUAL 'SIM' */

            if (WS_ERRO_MOVTO == "SIM")
            {

                /*" -1859- MOVE 'SIM' TO WS-ERRO-SUBGRUPO */
                _.Move("SIM", WS_ERRO_SUBGRUPO);

                /*" -1861- END-IF. */
            }


            /*" -1866- MOVE CPF-SOR TO CLIENTES-CGCCPF */
            _.Move(REGISTRO_SORT.CPF_SOR, CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF);

            /*" -1895- IF (SUBGVGAP-TIPO-PLANO EQUAL '2' ) */

            if ((SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_TIPO_PLANO == "2"))
            {

                /*" -1896- IF (IS-SOR EQUAL ZEROS) */

                if ((REGISTRO_SORT.IS_SOR == 00))
                {

                    /*" -1897- MOVE 4026 TO COD-ERRO-SOR */
                    _.Move(4026, REGISTRO_SORT.COD_ERRO_SOR);

                    /*" -1898- PERFORM R2020-00-GRAVA-RETORNO */

                    R2020_00_GRAVA_RETORNO_SECTION();

                    /*" -1900- MOVE 'SIM' TO WS-ERRO-MOVTO WS-ERRO-SUBGRUPO */
                    _.Move("SIM", WS_ERRO_MOVTO, WS_ERRO_SUBGRUPO);

                    /*" -1904- END-IF */
                }


                /*" -1905- IF (PREMIO-SOR EQUAL ZEROS) */

                if ((REGISTRO_SORT.PREMIO_SOR == 00))
                {

                    /*" -1906- MOVE 4017 TO COD-ERRO-SOR */
                    _.Move(4017, REGISTRO_SORT.COD_ERRO_SOR);

                    /*" -1907- PERFORM R2020-00-GRAVA-RETORNO */

                    R2020_00_GRAVA_RETORNO_SECTION();

                    /*" -1909- MOVE 'SIM' TO WS-ERRO-MOVTO WS-ERRO-SUBGRUPO */
                    _.Move("SIM", WS_ERRO_MOVTO, WS_ERRO_SUBGRUPO);

                    /*" -1910- END-IF */
                }


                /*" -1914- END-IF. */
            }


            /*" -1918- IF SUBGVGAP-TIPO-PLANO EQUAL '3' */

            if (SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_TIPO_PLANO == "3")
            {

                /*" -1919- IF SALARIO-SOR NOT NUMERIC */

                if (!REGISTRO_SORT.SALARIO_SOR.IsNumeric())
                {

                    /*" -1921- MOVE 4030 TO COD-ERRO-SOR */
                    _.Move(4030, REGISTRO_SORT.COD_ERRO_SOR);

                    /*" -1922- PERFORM R2020-00-GRAVA-RETORNO */

                    R2020_00_GRAVA_RETORNO_SECTION();

                    /*" -1924- MOVE 'SIM' TO WS-ERRO-MOVTO WS-ERRO-SUBGRUPO */
                    _.Move("SIM", WS_ERRO_MOVTO, WS_ERRO_SUBGRUPO);

                    /*" -1926- END-IF */
                }


                /*" -1927- IF SALARIO-SOR EQUAL ZEROS */

                if (REGISTRO_SORT.SALARIO_SOR == 00)
                {

                    /*" -1929- MOVE 4031 TO COD-ERRO-SOR */
                    _.Move(4031, REGISTRO_SORT.COD_ERRO_SOR);

                    /*" -1930- PERFORM R2020-00-GRAVA-RETORNO */

                    R2020_00_GRAVA_RETORNO_SECTION();

                    /*" -1932- MOVE 'SIM' TO WS-ERRO-MOVTO WS-ERRO-SUBGRUPO */
                    _.Move("SIM", WS_ERRO_MOVTO, WS_ERRO_SUBGRUPO);

                    /*" -1936- END-IF */
                }


                /*" -1937- IF QTDSAL-SOR NOT NUMERIC */

                if (!REGISTRO_SORT.QTDSAL_SOR.IsNumeric())
                {

                    /*" -1939- MOVE 4032 TO COD-ERRO-SOR */
                    _.Move(4032, REGISTRO_SORT.COD_ERRO_SOR);

                    /*" -1940- PERFORM R2020-00-GRAVA-RETORNO */

                    R2020_00_GRAVA_RETORNO_SECTION();

                    /*" -1942- MOVE 'SIM' TO WS-ERRO-MOVTO WS-ERRO-SUBGRUPO */
                    _.Move("SIM", WS_ERRO_MOVTO, WS_ERRO_SUBGRUPO);

                    /*" -1943- END-IF */
                }


                /*" -1945- END-IF. */
            }


            /*" -1946- IF WS-ERRO-MOVTO EQUAL 'SIM' */

            if (WS_ERRO_MOVTO == "SIM")
            {

                /*" -1947- ADD 1 TO WS-QTDE-CRITIC */
                WS_QTDE_CRITIC.Value = WS_QTDE_CRITIC + 1;

                /*" -1948- ADD PREMIO-SOR TO WS-TOT-CRITIC */
                WS_TOT_CRITIC.Value = WS_TOT_CRITIC + REGISTRO_SORT.PREMIO_SOR;

                /*" -1949- GO TO R2005-10-NEXT */

                R2005_10_NEXT(); //GOTO
                return;

                /*" -1949- END-IF. */
            }


            /*" -0- FLUXCONTROL_PERFORM R2005_05_CONTINUA */

            R2005_05_CONTINUA();

        }

        [StopWatch]
        /*" R2005-05-CONTINUA */
        private void R2005_05_CONTINUA(bool isPerform = false)
        {
            /*" -1959- ADD 1 TO WS-QTDE-MOVTO. */
            WS_QTDE_MOVTO.Value = WS_QTDE_MOVTO + 1;

            /*" -1960- IF SUBGVGAP-TIPO-PLANO EQUAL '3' */

            if (SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_TIPO_PLANO == "3")
            {

                /*" -1961- MOVE ZEROS TO IS-SOR */
                _.Move(0, REGISTRO_SORT.IS_SOR);

                /*" -1962- MOVE ZEROS TO PREMIO-SOR */
                _.Move(0, REGISTRO_SORT.PREMIO_SOR);

                /*" -1963- ELSE */
            }
            else
            {


                /*" -1964- MOVE ZEROS TO QTDSAL-SOR */
                _.Move(0, REGISTRO_SORT.QTDSAL_SOR);

                /*" -1967- END-IF. */
            }


            /*" -1968- IF (SUBGVGAP-TIPO-PLANO EQUAL '1' OR '2' OR '4' ) */

            if ((SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_TIPO_PLANO.In("1", "2", "4")))
            {

                /*" -1969- MOVE ZEROS TO SALARIO-SOR */
                _.Move(0, REGISTRO_SORT.SALARIO_SOR);

                /*" -1971- END-IF. */
            }


            /*" -1981- MOVE ZEROS TO MOVIMVGA-IMP-MORNATU-ATU MOVIMVGA-IMP-MORACID-ATU MOVIMVGA-IMP-INVPERM-ATU MOVIMVGA-IMP-AMDS-ATU MOVIMVGA-IMP-DH-ATU MOVIMVGA-IMP-DIT-ATU MOVIMVGA-PRM-VG-ATU MOVIMVGA-PRM-AP-ATU. */
            _.Move(0, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_MORNATU_ATU, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_MORACID_ATU, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_INVPERM_ATU, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_AMDS_ATU, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_DH_ATU, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_DIT_ATU, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PRM_VG_ATU, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PRM_AP_ATU);

            /*" -1983- MOVE SPACES TO WS-ERRO-MOVTO. */
            _.Move("", WS_ERRO_MOVTO);

            /*" -1985- PERFORM R3300-00-PROCESSA-IS */

            R3300_00_PROCESSA_IS_SECTION();

            /*" -1986- IF WS-ERRO-MOVTO EQUAL 'SIM' */

            if (WS_ERRO_MOVTO == "SIM")
            {

                /*" -1987- ADD 1 TO WS-QTDE-CRITIC */
                WS_QTDE_CRITIC.Value = WS_QTDE_CRITIC + 1;

                /*" -1988- ADD PREMIO-SOR TO WS-TOT-CRITIC */
                WS_TOT_CRITIC.Value = WS_TOT_CRITIC + REGISTRO_SORT.PREMIO_SOR;

                /*" -1990- GO TO R2005-10-NEXT. */

                R2005_10_NEXT(); //GOTO
                return;
            }


            /*" -1994- COMPUTE WS-TOT-PREMIO = WS-TOT-PREMIO + MOVIMVGA-PRM-VG-ATU + MOVIMVGA-PRM-AP-ATU. */
            WS_TOT_PREMIO.Value = WS_TOT_PREMIO + MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PRM_VG_ATU + MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PRM_AP_ATU;

            /*" -1995- IF (WTEM-SEGURVGA EQUAL 'SIM' ) */

            if ((FILLER_1.FILLER_15.WTEM_SEGURVGA == "SIM"))
            {

                /*" -1996- IF (SEGURVGA-SIT-REGISTRO = '0' OR '1' ) */

                if ((SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_SIT_REGISTRO.In("0", "1")))
                {

                    /*" -1998- PERFORM R2015-00-UPDATE-SEGURVGA */

                    R2015_00_UPDATE_SEGURVGA_SECTION();

                    /*" -1999- ELSE */
                }
                else
                {


                    /*" -2000- PERFORM R2016-00-UPDATE-SEGURVGA */

                    R2016_00_UPDATE_SEGURVGA_SECTION();

                    /*" -2002- PERFORM R5000-00-PROCESSA-REABILIT */

                    R5000_00_PROCESSA_REABILIT_SECTION();

                    /*" -2003- END-IF */
                }


                /*" -2004- PERFORM R2900-00-COMPARA-VALOR-IS */

                R2900_00_COMPARA_VALOR_IS_SECTION();

                /*" -2005- ELSE */
            }
            else
            {


                /*" -2006- PERFORM R4000-00-PROCESSA-INCLUSAO */

                R4000_00_PROCESSA_INCLUSAO_SECTION();

                /*" -2006- END-IF. */
            }


        }

        [StopWatch]
        /*" R2005-10-NEXT */
        private void R2005_10_NEXT(bool isPerform = false)
        {
            /*" -2010- PERFORM R1910-00-LE-SORT. */

            R1910_00_LE_SORT_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2005_99_SAIDA*/

        [StopWatch]
        /*" R2010-00-CONSISTE-DATA-SECTION */
        private void R2010_00_CONSISTE_DATA_SECTION()
        {
            /*" -2019- MOVE 'R2010-00-CONSISTE-DATA' TO PARAGRAFO. */
            _.Move("R2010-00-CONSISTE-DATA", FILLER_1.WABEND.PARAGRAFO);

            /*" -2020- MOVE '2010' TO WNR-EXEC-SQL. */
            _.Move("2010", FILLER_1.WABEND.WNR_EXEC_SQL);

            /*" -2022- DISPLAY PARAGRAFO */
            _.Display(FILLER_1.WABEND.PARAGRAFO);

            /*" -2024- MOVE 'NAO' TO WS-ERRO-DATA */
            _.Move("NAO", WS_ERRO_DATA);

            /*" -2026- DISPLAY 'WS-DTH-CRITICA..: ' WS-DTH-CRITICA */
            _.Display($"WS-DTH-CRITICA..: {FILLER_1.WS_DTH_CRITICA}");

            /*" -2028- IF WS-CRITICA-ANO LESS 1900 OR WS-CRITICA-ANO IS NOT NUMERIC */

            if (FILLER_1.WS_DTH_CRITICA_R.WS_CRITICA_ANO < 1900 || !FILLER_1.WS_DTH_CRITICA_R.WS_CRITICA_ANO.IsNumeric())
            {

                /*" -2029- MOVE 'SIM' TO WS-ERRO-DATA */
                _.Move("SIM", WS_ERRO_DATA);

                /*" -2031- GO TO R2010-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2010_99_SAIDA*/ //GOTO
                return;
            }


            /*" -2034- IF WS-CRITICA-MES EQUAL ZEROS OR WS-CRITICA-MES GREATER 12 OR WS-CRITICA-MES IS NOT NUMERIC */

            if (FILLER_1.WS_DTH_CRITICA_R.WS_CRITICA_MES == 00 || FILLER_1.WS_DTH_CRITICA_R.WS_CRITICA_MES > 12 || !FILLER_1.WS_DTH_CRITICA_R.WS_CRITICA_MES.IsNumeric())
            {

                /*" -2035- MOVE 'SIM' TO WS-ERRO-DATA */
                _.Move("SIM", WS_ERRO_DATA);

                /*" -2037- GO TO R2010-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2010_99_SAIDA*/ //GOTO
                return;
            }


            /*" -2039- IF WS-CRITICA-DIA EQUAL ZEROS OR WS-CRITICA-MES IS NOT NUMERIC */

            if (FILLER_1.WS_DTH_CRITICA_R.WS_CRITICA_DIA == 00 || !FILLER_1.WS_DTH_CRITICA_R.WS_CRITICA_MES.IsNumeric())
            {

                /*" -2040- MOVE 'SIM' TO WS-ERRO-DATA */
                _.Move("SIM", WS_ERRO_DATA);

                /*" -2042- GO TO R2010-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2010_99_SAIDA*/ //GOTO
                return;
            }


            /*" -2045- IF WS-CRITICA-MES EQUAL 01 OR 03 OR 05 OR 07 OR 08 OR 10 OR 12 */

            if (FILLER_1.WS_DTH_CRITICA_R.WS_CRITICA_MES.In("01", "03", "05", "07", "08", "10", "12"))
            {

                /*" -2046- IF WS-CRITICA-DIA GREATER 31 */

                if (FILLER_1.WS_DTH_CRITICA_R.WS_CRITICA_DIA > 31)
                {

                    /*" -2047- MOVE 'SIM' TO WS-ERRO-DATA */
                    _.Move("SIM", WS_ERRO_DATA);

                    /*" -2049- GO TO R2010-99-SAIDA. */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R2010_99_SAIDA*/ //GOTO
                    return;
                }

            }


            /*" -2051- IF WS-CRITICA-MES EQUAL 04 OR 06 OR 09 OR 11 */

            if (FILLER_1.WS_DTH_CRITICA_R.WS_CRITICA_MES.In("04", "06", "09", "11"))
            {

                /*" -2052- IF WS-CRITICA-DIA GREATER 30 */

                if (FILLER_1.WS_DTH_CRITICA_R.WS_CRITICA_DIA > 30)
                {

                    /*" -2053- MOVE 'SIM' TO WS-ERRO-DATA */
                    _.Move("SIM", WS_ERRO_DATA);

                    /*" -2055- GO TO R2010-99-SAIDA. */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R2010_99_SAIDA*/ //GOTO
                    return;
                }

            }


            /*" -2056- IF WS-CRITICA-MES EQUAL 02 */

            if (FILLER_1.WS_DTH_CRITICA_R.WS_CRITICA_MES == 02)
            {

                /*" -2059- DIVIDE WS-CRITICA-ANO BY 4 GIVING WS-RESULTADO REMAINDER WS-RESTO */
                _.Divide(FILLER_1.WS_DTH_CRITICA_R.WS_CRITICA_ANO, 4, WS_RESULTADO, WS_RESTO);

                /*" -2060- IF WS-RESTO EQUAL ZEROS */

                if (WS_RESTO == 00)
                {

                    /*" -2061- IF WS-CRITICA-DIA GREATER 29 */

                    if (FILLER_1.WS_DTH_CRITICA_R.WS_CRITICA_DIA > 29)
                    {

                        /*" -2062- MOVE 'SIM' TO WS-ERRO-DATA */
                        _.Move("SIM", WS_ERRO_DATA);

                        /*" -2063- GO TO R2010-99-SAIDA */
                        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2010_99_SAIDA*/ //GOTO
                        return;

                        /*" -2064- END-IF */
                    }


                    /*" -2065- ELSE */
                }
                else
                {


                    /*" -2066- IF WS-CRITICA-DIA GREATER 28 */

                    if (FILLER_1.WS_DTH_CRITICA_R.WS_CRITICA_DIA > 28)
                    {

                        /*" -2067- MOVE 'SIM' TO WS-ERRO-DATA */
                        _.Move("SIM", WS_ERRO_DATA);

                        /*" -2067- GO TO R2010-99-SAIDA. */
                        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2010_99_SAIDA*/ //GOTO
                        return;
                    }

                }

            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2010_99_SAIDA*/

        [StopWatch]
        /*" R2015-00-UPDATE-SEGURVGA-SECTION */
        private void R2015_00_UPDATE_SEGURVGA_SECTION()
        {
            /*" -2076- MOVE 'R2015-00-UPDATE-SEGURVGA' TO PARAGRAFO. */
            _.Move("R2015-00-UPDATE-SEGURVGA", FILLER_1.WABEND.PARAGRAFO);

            /*" -2077- MOVE '2015' TO WNR-EXEC-SQL. */
            _.Move("2015", FILLER_1.WABEND.WNR_EXEC_SQL);

            /*" -2080- DISPLAY PARAGRAFO */
            _.Display(FILLER_1.WABEND.PARAGRAFO);

            /*" -2081- MOVE 04 TO W01-I */
            _.Move(04, FILLER_0.W01_I);

            /*" -2082- MOVE 'R2015-UPDATE SEGURVGA  ' TO W01-TEXTO(W01-I) */
            _.Move("R2015-UPDATE SEGURVGA  ", FILLER_0.W01_TABELA_TEXTO.W01_TAB_TEXTO[FILLER_0.W01_I].W01_TEXTO);

            /*" -2086- PERFORM R8900-TOTALIZA-INICIO THRU R8900-TOTALIZA-INICIO-EXIT */

            R8900_TOTALIZA_INICIO_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8900_TOTALIZA_INICIO_EXIT*/


            /*" -2095- PERFORM R2015_00_UPDATE_SEGURVGA_DB_UPDATE_1 */

            R2015_00_UPDATE_SEGURVGA_DB_UPDATE_1();

            /*" -2099- MOVE 1 TO W01-QTD-ACC-OK */
            _.Move(1, FILLER_0.W01_QTD_ACC_OK);

            /*" -2103- PERFORM R8910-TOTALIZA-FINAL THRU R8910-TOTALIZA-FINAL-EXIT */

            R8910_TOTALIZA_FINAL_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8910_TOTALIZA_FINAL_EXIT*/


            /*" -2105- DISPLAY 'ALTERAR SEGURADO PARA 9999 >> ' SQLCODE */
            _.Display($"ALTERAR SEGURADO PARA 9999 >> {DB.SQLCODE}");

            /*" -2106- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -2107- DISPLAY 'PROBLEMA UPDATE DA SEGURADOS_VGAP ' */
                _.Display($"PROBLEMA UPDATE DA SEGURADOS_VGAP ");

                /*" -2108- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2110- END-IF. */
            }


            /*" -2110- PERFORM R4220-00-TRATA-SEXO-CLIENTE. */

            R4220_00_TRATA_SEXO_CLIENTE_SECTION();

        }

        [StopWatch]
        /*" R2015-00-UPDATE-SEGURVGA-DB-UPDATE-1 */
        public void R2015_00_UPDATE_SEGURVGA_DB_UPDATE_1()
        {
            /*" -2095- EXEC SQL UPDATE SEGUROS.SEGURADOS_VGAP SET COD_PROFISSAO = 9999, SIT_REGISTRO = '0' WHERE NUM_CERTIFICADO = :SEGURVGA-NUM-CERTIFICADO AND TIPO_SEGURADO = '1' END-EXEC. */

            var r2015_00_UPDATE_SEGURVGA_DB_UPDATE_1_Update1 = new R2015_00_UPDATE_SEGURVGA_DB_UPDATE_1_Update1()
            {
                SEGURVGA_NUM_CERTIFICADO = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_CERTIFICADO.ToString(),
            };

            R2015_00_UPDATE_SEGURVGA_DB_UPDATE_1_Update1.Execute(r2015_00_UPDATE_SEGURVGA_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2015_99_SAIDA*/

        [StopWatch]
        /*" R2016-00-UPDATE-SEGURVGA-SECTION */
        private void R2016_00_UPDATE_SEGURVGA_SECTION()
        {
            /*" -2119- MOVE 'R2016-00-UPDATE-SEGURVGA' TO PARAGRAFO. */
            _.Move("R2016-00-UPDATE-SEGURVGA", FILLER_1.WABEND.PARAGRAFO);

            /*" -2120- MOVE '2016' TO WNR-EXEC-SQL. */
            _.Move("2016", FILLER_1.WABEND.WNR_EXEC_SQL);

            /*" -2123- DISPLAY PARAGRAFO */
            _.Display(FILLER_1.WABEND.PARAGRAFO);

            /*" -2124- MOVE 05 TO W01-I */
            _.Move(05, FILLER_0.W01_I);

            /*" -2125- MOVE 'R2016-UPDATE SEGURVGA  ' TO W01-TEXTO(W01-I) */
            _.Move("R2016-UPDATE SEGURVGA  ", FILLER_0.W01_TABELA_TEXTO.W01_TAB_TEXTO[FILLER_0.W01_I].W01_TEXTO);

            /*" -2129- PERFORM R8900-TOTALIZA-INICIO THRU R8900-TOTALIZA-INICIO-EXIT */

            R8900_TOTALIZA_INICIO_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8900_TOTALIZA_INICIO_EXIT*/


            /*" -2137- PERFORM R2016_00_UPDATE_SEGURVGA_DB_UPDATE_1 */

            R2016_00_UPDATE_SEGURVGA_DB_UPDATE_1();

            /*" -2141- MOVE 1 TO W01-QTD-ACC-OK */
            _.Move(1, FILLER_0.W01_QTD_ACC_OK);

            /*" -2145- PERFORM R8910-TOTALIZA-FINAL THRU R8910-TOTALIZA-FINAL-EXIT */

            R8910_TOTALIZA_FINAL_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8910_TOTALIZA_FINAL_EXIT*/


            /*" -2147- DISPLAY 'ALTERAR SEGURADO PARA 9999 >> ' SQLCODE */
            _.Display($"ALTERAR SEGURADO PARA 9999 >> {DB.SQLCODE}");

            /*" -2148- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -2150- DISPLAY 'PROBLEMA UPDATE DA SEGURADOS_VGAP 1' */
                _.Display($"PROBLEMA UPDATE DA SEGURADOS_VGAP 1");

                /*" -2151- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2151- END-IF. */
            }


        }

        [StopWatch]
        /*" R2016-00-UPDATE-SEGURVGA-DB-UPDATE-1 */
        public void R2016_00_UPDATE_SEGURVGA_DB_UPDATE_1()
        {
            /*" -2137- EXEC SQL UPDATE SEGUROS.SEGURADOS_VGAP SET COD_PROFISSAO = 9999 WHERE NUM_CERTIFICADO = :SEGURVGA-NUM-CERTIFICADO AND TIPO_SEGURADO = '1' END-EXEC. */

            var r2016_00_UPDATE_SEGURVGA_DB_UPDATE_1_Update1 = new R2016_00_UPDATE_SEGURVGA_DB_UPDATE_1_Update1()
            {
                SEGURVGA_NUM_CERTIFICADO = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_CERTIFICADO.ToString(),
            };

            R2016_00_UPDATE_SEGURVGA_DB_UPDATE_1_Update1.Execute(r2016_00_UPDATE_SEGURVGA_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2016_99_SAIDA*/

        [StopWatch]
        /*" R2020-00-GRAVA-RETORNO-SECTION */
        private void R2020_00_GRAVA_RETORNO_SECTION()
        {
            /*" -2160- MOVE 'R2020-00-GRAVA-RETORNO' TO PARAGRAFO. */
            _.Move("R2020-00-GRAVA-RETORNO", FILLER_1.WABEND.PARAGRAFO);

            /*" -2161- MOVE '2020' TO WNR-EXEC-SQL. */
            _.Move("2020", FILLER_1.WABEND.WNR_EXEC_SQL);

            /*" -2163- DISPLAY PARAGRAFO */
            _.Display(FILLER_1.WABEND.PARAGRAFO);

            /*" -2164- MOVE NOME-SOR TO NOME-SAI. */
            _.Move(REGISTRO_SORT.NOME_SOR, REGISTRO_SAIDA.NOME_SAI);

            /*" -2165- MOVE CPF-SOR TO CPF-SAI. */
            _.Move(REGISTRO_SORT.CPF_SOR, REGISTRO_SAIDA.CPF_SAI);

            /*" -2166- MOVE DTNAS-SOR TO DTNAS-SAI. */
            _.Move(REGISTRO_SORT.DTNAS_SOR, REGISTRO_SAIDA.DTNAS_SAI);

            /*" -2167- MOVE SEXO-SOR TO SEXO-SAI. */
            _.Move(REGISTRO_SORT.SEXO_SOR, REGISTRO_SAIDA.SEXO_SAI);

            /*" -2168- MOVE ESTCIV-SOR TO ESTCIV-SAI. */
            _.Move(REGISTRO_SORT.ESTCIV_SOR, REGISTRO_SAIDA.ESTCIV_SAI);

            /*" -2169- MOVE SALARIO-SOR TO SALARIO-SAI. */
            _.Move(REGISTRO_SORT.SALARIO_SOR, REGISTRO_SAIDA.SALARIO_SAI);

            /*" -2170- MOVE QTDSAL-SOR TO QTDSAL-SAI. */
            _.Move(REGISTRO_SORT.QTDSAL_SOR, REGISTRO_SAIDA.QTDSAL_SAI);

            /*" -2171- MOVE IS-SOR TO IS-SAI. */
            _.Move(REGISTRO_SORT.IS_SOR, REGISTRO_SAIDA.IS_SAI);

            /*" -2172- MOVE PREMIO-SOR TO PREMIO-INFO-SAI. */
            _.Move(REGISTRO_SORT.PREMIO_SOR, REGISTRO_SAIDA.PREMIO_INFO_SAI);

            /*" -2173- MOVE NUM-APOLICE-SOR TO NUM-APOLICE-SAI. */
            _.Move(REGISTRO_SORT.NUM_APOLICE_SOR, REGISTRO_SAIDA.NUM_APOLICE_SAI);

            /*" -2174- MOVE SUBGRUPO-SOR TO SUBGRUPO-SAI. */
            _.Move(REGISTRO_SORT.SUBGRUPO_SOR, REGISTRO_SAIDA.SUBGRUPO_SAI);

            /*" -2175- MOVE DTVIG-SOR TO DTVIG-SAI. */
            _.Move(REGISTRO_SORT.DTVIG_SOR, REGISTRO_SAIDA.DTVIG_SAI);

            /*" -2177- MOVE COD-ERRO-SOR TO COD-ERRO-SAI ERROSVID-COD-ERRO. */
            _.Move(REGISTRO_SORT.COD_ERRO_SOR, REGISTRO_SAIDA.COD_ERRO_SAI, ERROSVID.DCLERROS_VIDAZUL.ERROSVID_COD_ERRO);

            /*" -2178- IF MOVIMVGA-PRM-VG-ATU GREATER ZEROS */

            if (MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PRM_VG_ATU > 00)
            {

                /*" -2179- MOVE MOVIMVGA-PRM-VG-ATU TO PREMIO-CALC-SAI */
                _.Move(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PRM_VG_ATU, REGISTRO_SAIDA.PREMIO_CALC_SAI);

                /*" -2180- ELSE */
            }
            else
            {


                /*" -2181- MOVE MOVIMVGA-PRM-AP-ATU TO PREMIO-CALC-SAI */
                _.Move(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PRM_AP_ATU, REGISTRO_SAIDA.PREMIO_CALC_SAI);

                /*" -2183- END-IF */
            }


            /*" -2185- MOVE WS-PRM-DIFERENCA TO PREMIO-DIFE-SAI */
            _.Move(WS_PRM_DIFERENCA, REGISTRO_SAIDA.PREMIO_DIFE_SAI);

            /*" -2187- PERFORM R2400-00-SELECT-ERROSVID. */

            R2400_00_SELECT_ERROSVID_SECTION();

            /*" -2190- MOVE ERROSVID-DESCR-ERRO TO DES-ERRO-SAI. */
            _.Move(ERROSVID.DCLERROS_VIDAZUL.ERROSVID_DESCR_ERRO, REGISTRO_SAIDA.DES_ERRO_SAI);

            /*" -2193- WRITE REGISTRO-RETORNO FROM REGISTRO-SAIDA. */
            _.Move(REGISTRO_SAIDA.GetMoveValues(), REGISTRO_RETORNO);

            ARQUIVO_RETORNO.Write(REGISTRO_RETORNO.GetMoveValues().ToString());

            /*" -2193- ADD 1 TO AC-GRAVA-S. */
            FILLER_1.AC_GRAVA_S.Value = FILLER_1.AC_GRAVA_S + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2020_99_SAIDA*/

        [StopWatch]
        /*" R2030-00-ACESSA-PLANOFAI-SECTION */
        private void R2030_00_ACESSA_PLANOFAI_SECTION()
        {
            /*" -2202- MOVE 'R2030-00-ACESSA-PLANOFAI' TO PARAGRAFO. */
            _.Move("R2030-00-ACESSA-PLANOFAI", FILLER_1.WABEND.PARAGRAFO);

            /*" -2203- MOVE '2030' TO WNR-EXEC-SQL. */
            _.Move("2030", FILLER_1.WABEND.WNR_EXEC_SQL);

            /*" -2205- DISPLAY PARAGRAFO */
            _.Display(FILLER_1.WABEND.PARAGRAFO);

            /*" -2208- MOVE WS-IDADE TO PLANOFAI-IDADE-INICIAL. */
            _.Move(WS_IDADE, PLANOFAI.DCLPLANOS_FAIXAETA.PLANOFAI_IDADE_INICIAL);

            /*" -2209- MOVE 06 TO W01-I */
            _.Move(06, FILLER_0.W01_I);

            /*" -2210- MOVE 'R2030-SELECT PLANOFAI  ' TO W01-TEXTO(W01-I) */
            _.Move("R2030-SELECT PLANOFAI  ", FILLER_0.W01_TABELA_TEXTO.W01_TAB_TEXTO[FILLER_0.W01_I].W01_TEXTO);

            /*" -2214- PERFORM R8900-TOTALIZA-INICIO THRU R8900-TOTALIZA-INICIO-EXIT */

            R8900_TOTALIZA_INICIO_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8900_TOTALIZA_INICIO_EXIT*/


            /*" -2233- PERFORM R2030_00_ACESSA_PLANOFAI_DB_SELECT_1 */

            R2030_00_ACESSA_PLANOFAI_DB_SELECT_1();

            /*" -2237- MOVE 1 TO W01-QTD-ACC-OK */
            _.Move(1, FILLER_0.W01_QTD_ACC_OK);

            /*" -2241- PERFORM R8910-TOTALIZA-FINAL THRU R8910-TOTALIZA-FINAL-EXIT */

            R8910_TOTALIZA_FINAL_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8910_TOTALIZA_FINAL_EXIT*/


            /*" -2242- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -2243- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2245- IF WS-IDADE EQUAL 33 */

                    if (WS_IDADE == 33)
                    {

                        /*" -2246- MOVE 4037 TO COD-ERRO-SOR */
                        _.Move(4037, REGISTRO_SORT.COD_ERRO_SOR);

                        /*" -2247- PERFORM R2020-00-GRAVA-RETORNO */

                        R2020_00_GRAVA_RETORNO_SECTION();

                        /*" -2249- MOVE 'SIM' TO WS-ERRO-MOVTO WS-ERRO-SUBGRUPO */
                        _.Move("SIM", WS_ERRO_MOVTO, WS_ERRO_SUBGRUPO);

                        /*" -2250- GO TO R2030-99-SAIDA */
                        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2030_99_SAIDA*/ //GOTO
                        return;

                        /*" -2251- ELSE */
                    }
                    else
                    {


                        /*" -2252- MOVE 33 TO WS-IDADE */
                        _.Move(33, WS_IDADE);

                        /*" -2253- GO TO R2030-00-ACESSA-PLANOFAI */
                        new Task(() => R2030_00_ACESSA_PLANOFAI_SECTION()).RunSynchronously(); //GOTO
                        return;//Recursividade detectada, cuidado...

                        /*" -2254- ELSE */
                    }

                }
                else
                {


                    /*" -2256- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -2257- COMPUTE WTOT-PREMIO = PLANOFAI-PRM-VG + PLANOFAI-PRM-AP. */
            WTOT_PREMIO.Value = PLANOFAI.DCLPLANOS_FAIXAETA.PLANOFAI_PRM_VG + PLANOFAI.DCLPLANOS_FAIXAETA.PLANOFAI_PRM_AP;

        }

        [StopWatch]
        /*" R2030-00-ACESSA-PLANOFAI-DB-SELECT-1 */
        public void R2030_00_ACESSA_PLANOFAI_DB_SELECT_1()
        {
            /*" -2233- EXEC SQL SELECT PRM_VG, PRM_AP, FAIXA INTO :PLANOFAI-PRM-VG, :PLANOFAI-PRM-AP, :PLANOFAI-FAIXA FROM SEGUROS.PLANOS_FAIXAETA WHERE NUM_APOLICE = :SUBGVGAP-NUM-APOLICE AND COD_SUBGRUPO = :SUBGVGAP-COD-SUBGRUPO AND COD_PLANO = :PLANOVGA-COD-PLANO AND IDADE_INICIAL <= :PLANOFAI-IDADE-INICIAL AND IDADE_FINAL >= :PLANOFAI-IDADE-INICIAL AND DATA_TERVIGENCIA >= :SISTEMAS-DATA-MOV-ABERTO WITH UR END-EXEC. */

            var r2030_00_ACESSA_PLANOFAI_DB_SELECT_1_Query1 = new R2030_00_ACESSA_PLANOFAI_DB_SELECT_1_Query1()
            {
                SISTEMAS_DATA_MOV_ABERTO = SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.ToString(),
                PLANOFAI_IDADE_INICIAL = PLANOFAI.DCLPLANOS_FAIXAETA.PLANOFAI_IDADE_INICIAL.ToString(),
                SUBGVGAP_COD_SUBGRUPO = SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_SUBGRUPO.ToString(),
                SUBGVGAP_NUM_APOLICE = SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_NUM_APOLICE.ToString(),
                PLANOVGA_COD_PLANO = PLANOVGA.DCLPLANOS_VGAP.PLANOVGA_COD_PLANO.ToString(),
            };

            var executed_1 = R2030_00_ACESSA_PLANOFAI_DB_SELECT_1_Query1.Execute(r2030_00_ACESSA_PLANOFAI_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PLANOFAI_PRM_VG, PLANOFAI.DCLPLANOS_FAIXAETA.PLANOFAI_PRM_VG);
                _.Move(executed_1.PLANOFAI_PRM_AP, PLANOFAI.DCLPLANOS_FAIXAETA.PLANOFAI_PRM_AP);
                _.Move(executed_1.PLANOFAI_FAIXA, PLANOFAI.DCLPLANOS_FAIXAETA.PLANOFAI_FAIXA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2030_99_SAIDA*/

        [StopWatch]
        /*" R2040-00-ACESSA-PLANFSAL-SECTION */
        private void R2040_00_ACESSA_PLANFSAL_SECTION()
        {
            /*" -2267- MOVE 'R2040-00-ACESSA-PLANFSAL' TO PARAGRAFO. */
            _.Move("R2040-00-ACESSA-PLANFSAL", FILLER_1.WABEND.PARAGRAFO);

            /*" -2268- MOVE '2040' TO WNR-EXEC-SQL. */
            _.Move("2040", FILLER_1.WABEND.WNR_EXEC_SQL);

            /*" -2270- DISPLAY PARAGRAFO */
            _.Display(FILLER_1.WABEND.PARAGRAFO);

            /*" -2273- MOVE SALARIO-SOR TO PLANFSAL-SALARIO-INICIAL. */
            _.Move(REGISTRO_SORT.SALARIO_SOR, PLANFSAL.DCLPLANOS_FAIXASAL.PLANFSAL_SALARIO_INICIAL);

            /*" -2274- MOVE 07 TO W01-I */
            _.Move(07, FILLER_0.W01_I);

            /*" -2275- MOVE 'R2040-SELECT PLANFSAL  ' TO W01-TEXTO(W01-I) */
            _.Move("R2040-SELECT PLANFSAL  ", FILLER_0.W01_TABELA_TEXTO.W01_TAB_TEXTO[FILLER_0.W01_I].W01_TEXTO);

            /*" -2279- PERFORM R8900-TOTALIZA-INICIO THRU R8900-TOTALIZA-INICIO-EXIT */

            R8900_TOTALIZA_INICIO_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8900_TOTALIZA_INICIO_EXIT*/


            /*" -2296- PERFORM R2040_00_ACESSA_PLANFSAL_DB_SELECT_1 */

            R2040_00_ACESSA_PLANFSAL_DB_SELECT_1();

            /*" -2300- MOVE 1 TO W01-QTD-ACC-OK */
            _.Move(1, FILLER_0.W01_QTD_ACC_OK);

            /*" -2304- PERFORM R8910-TOTALIZA-FINAL THRU R8910-TOTALIZA-FINAL-EXIT */

            R8910_TOTALIZA_FINAL_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8910_TOTALIZA_FINAL_EXIT*/


            /*" -2305- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -2306- IF SQLCODE NOT EQUAL 100 */

                if (DB.SQLCODE != 100)
                {

                    /*" -2307- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2308- ELSE */
                }
                else
                {


                    /*" -2309- MOVE 4036 TO COD-ERRO-SOR */
                    _.Move(4036, REGISTRO_SORT.COD_ERRO_SOR);

                    /*" -2310- PERFORM R2020-00-GRAVA-RETORNO */

                    R2020_00_GRAVA_RETORNO_SECTION();

                    /*" -2312- MOVE 'SIM' TO WS-ERRO-MOVTO WS-ERRO-SUBGRUPO */
                    _.Move("SIM", WS_ERRO_MOVTO, WS_ERRO_SUBGRUPO);

                    /*" -2314- GO TO R2040-99-SAIDA. */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R2040_99_SAIDA*/ //GOTO
                    return;
                }

            }


            /*" -2315- COMPUTE WTOT-PREMIO = PLANFSAL-PRM-VG + PLANFSAL-PRM-AP. */
            WTOT_PREMIO.Value = PLANFSAL.DCLPLANOS_FAIXASAL.PLANFSAL_PRM_VG + PLANFSAL.DCLPLANOS_FAIXASAL.PLANFSAL_PRM_AP;

        }

        [StopWatch]
        /*" R2040-00-ACESSA-PLANFSAL-DB-SELECT-1 */
        public void R2040_00_ACESSA_PLANFSAL_DB_SELECT_1()
        {
            /*" -2296- EXEC SQL SELECT PRM_VG, PRM_AP, FAIXA INTO :PLANFSAL-PRM-VG, :PLANFSAL-PRM-AP, :PLANFSAL-FAIXA FROM SEGUROS.PLANOS_FAIXASAL WHERE NUM_APOLICE = :SUBGVGAP-NUM-APOLICE AND COD_SUBGRUPO = :SUBGVGAP-COD-SUBGRUPO AND COD_PLANO = :PLANOVGA-COD-PLANO AND SALARIO_INICIAL <= :PLANFSAL-SALARIO-INICIAL AND SALARIO_FINAL >= :PLANFSAL-SALARIO-INICIAL WITH UR END-EXEC. */

            var r2040_00_ACESSA_PLANFSAL_DB_SELECT_1_Query1 = new R2040_00_ACESSA_PLANFSAL_DB_SELECT_1_Query1()
            {
                PLANFSAL_SALARIO_INICIAL = PLANFSAL.DCLPLANOS_FAIXASAL.PLANFSAL_SALARIO_INICIAL.ToString(),
                SUBGVGAP_COD_SUBGRUPO = SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_SUBGRUPO.ToString(),
                SUBGVGAP_NUM_APOLICE = SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_NUM_APOLICE.ToString(),
                PLANOVGA_COD_PLANO = PLANOVGA.DCLPLANOS_VGAP.PLANOVGA_COD_PLANO.ToString(),
            };

            var executed_1 = R2040_00_ACESSA_PLANFSAL_DB_SELECT_1_Query1.Execute(r2040_00_ACESSA_PLANFSAL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PLANFSAL_PRM_VG, PLANFSAL.DCLPLANOS_FAIXASAL.PLANFSAL_PRM_VG);
                _.Move(executed_1.PLANFSAL_PRM_AP, PLANFSAL.DCLPLANOS_FAIXASAL.PLANFSAL_PRM_AP);
                _.Move(executed_1.PLANFSAL_FAIXA, PLANFSAL.DCLPLANOS_FAIXASAL.PLANFSAL_FAIXA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2040_99_SAIDA*/

        [StopWatch]
        /*" R2050-00-ACESSA-PLANOVGA-SECTION */
        private void R2050_00_ACESSA_PLANOVGA_SECTION()
        {
            /*" -2324- MOVE 'R2050-00-ACESSA-PLANOVGA' TO PARAGRAFO. */
            _.Move("R2050-00-ACESSA-PLANOVGA", FILLER_1.WABEND.PARAGRAFO);

            /*" -2325- MOVE '2050' TO WNR-EXEC-SQL. */
            _.Move("2050", FILLER_1.WABEND.WNR_EXEC_SQL);

            /*" -2327- DISPLAY PARAGRAFO */
            _.Display(FILLER_1.WABEND.PARAGRAFO);

            /*" -2330- MOVE WS-APOLICE-ATU TO SUBGVGAP-NUM-APOLICE */
            _.Move(WS_CHAVE_ATU.WS_APOLICE_ATU, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_NUM_APOLICE);

            /*" -2333- MOVE WS-SUBGRUPO-ATU TO SUBGVGAP-COD-SUBGRUPO */
            _.Move(WS_CHAVE_ATU.WS_SUBGRUPO_ATU, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_SUBGRUPO);

            /*" -2337- MOVE 'SIM' TO WTEM-SUBGVGAP */
            _.Move("SIM", FILLER_1.FILLER_15.WTEM_SUBGVGAP);

            /*" -2338- MOVE 08 TO W01-I */
            _.Move(08, FILLER_0.W01_I);

            /*" -2339- MOVE 'R2050-SELECT PLANOVGA  ' TO W01-TEXTO(W01-I) */
            _.Move("R2050-SELECT PLANOVGA  ", FILLER_0.W01_TABELA_TEXTO.W01_TAB_TEXTO[FILLER_0.W01_I].W01_TEXTO);

            /*" -2343- PERFORM R8900-TOTALIZA-INICIO THRU R8900-TOTALIZA-INICIO-EXIT */

            R8900_TOTALIZA_INICIO_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8900_TOTALIZA_INICIO_EXIT*/


            /*" -2366- PERFORM R2050_00_ACESSA_PLANOVGA_DB_SELECT_1 */

            R2050_00_ACESSA_PLANOVGA_DB_SELECT_1();

            /*" -2370- MOVE 1 TO W01-QTD-ACC-OK */
            _.Move(1, FILLER_0.W01_QTD_ACC_OK);

            /*" -2374- PERFORM R8910-TOTALIZA-FINAL THRU R8910-TOTALIZA-FINAL-EXIT */

            R8910_TOTALIZA_FINAL_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8910_TOTALIZA_FINAL_EXIT*/


            /*" -2375- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2376- IF SQLCODE EQUAL -811 */

                if (DB.SQLCODE == -811)
                {

                    /*" -2377- PERFORM R2055-00-ACESSA-PLANOVGA */

                    R2055_00_ACESSA_PLANOVGA_SECTION();

                    /*" -2378- ELSE */
                }
                else
                {


                    /*" -2379- IF SQLCODE NOT EQUAL 100 */

                    if (DB.SQLCODE != 100)
                    {

                        /*" -2380- DISPLAY 'R2050 - ERRO ACESSO PLANOS_VGAP' */
                        _.Display($"R2050 - ERRO ACESSO PLANOS_VGAP");

                        /*" -2381- DISPLAY 'APOLICE.....' SUBGVGAP-NUM-APOLICE */
                        _.Display($"APOLICE.....{SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_NUM_APOLICE}");

                        /*" -2382- DISPLAY 'SUBGRUPO....' SUBGVGAP-COD-SUBGRUPO */
                        _.Display($"SUBGRUPO....{SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_SUBGRUPO}");

                        /*" -2383- GO TO R9999-00-ROT-ERRO */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;

                        /*" -2384- ELSE */
                    }
                    else
                    {


                        /*" -2385- MOVE 'NAO' TO WTEM-SUBGVGAP */
                        _.Move("NAO", FILLER_1.FILLER_15.WTEM_SUBGVGAP);

                        /*" -2387- MOVE 'PROBLEMAS NO SUBGRUPO - PLANO NAO CADASTRADO' TO OBSERVACAO-SAI2 */
                        _.Move("PROBLEMAS NO SUBGRUPO - PLANO NAO CADASTRADO", REGISTRO_SAIDA2.OBSERVACAO_SAI2);

                        /*" -2388- DISPLAY 'R2050 - APOLICE SEM PLANO CADASTRADO' */
                        _.Display($"R2050 - APOLICE SEM PLANO CADASTRADO");

                        /*" -2389- DISPLAY 'APOLICE.....' SUBGVGAP-NUM-APOLICE */
                        _.Display($"APOLICE.....{SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_NUM_APOLICE}");

                        /*" -2390- DISPLAY 'SUBGRUPO....' SUBGVGAP-COD-SUBGRUPO */
                        _.Display($"SUBGRUPO....{SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_SUBGRUPO}");

                        /*" -2391- END-IF */
                    }


                    /*" -2393- END-IF. */
                }

            }


            /*" -2394- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -2395- DISPLAY 'MN   ' PLANOVGA-IMP-MORNATU */
                _.Display($"MN   {PLANOVGA.DCLPLANOS_VGAP.PLANOVGA_IMP_MORNATU}");

                /*" -2396- DISPLAY 'MA   ' PLANOVGA-IMP-MORACID */
                _.Display($"MA   {PLANOVGA.DCLPLANOS_VGAP.PLANOVGA_IMP_MORACID}");

                /*" -2397- DISPLAY 'IP   ' PLANOVGA-IMP-INVPERM */
                _.Display($"IP   {PLANOVGA.DCLPLANOS_VGAP.PLANOVGA_IMP_INVPERM}");

                /*" -2398- DISPLAY 'AMDS ' PLANOVGA-IMP-AMDS */
                _.Display($"AMDS {PLANOVGA.DCLPLANOS_VGAP.PLANOVGA_IMP_AMDS}");

                /*" -2399- DISPLAY 'DH   ' PLANOVGA-IMP-DH */
                _.Display($"DH   {PLANOVGA.DCLPLANOS_VGAP.PLANOVGA_IMP_DH}");

                /*" -2399- DISPLAY 'DIT  ' PLANOVGA-IMP-DIT. */
                _.Display($"DIT  {PLANOVGA.DCLPLANOS_VGAP.PLANOVGA_IMP_DIT}");
            }


        }

        [StopWatch]
        /*" R2050-00-ACESSA-PLANOVGA-DB-SELECT-1 */
        public void R2050_00_ACESSA_PLANOVGA_DB_SELECT_1()
        {
            /*" -2366- EXEC SQL SELECT COD_PLANO, DATA_INIVIGENCIA, IMP_MORNATU, IMP_MORACID, IMP_INVPERM, IMP_AMDS, IMP_DH, IMP_DIT INTO :PLANOVGA-COD-PLANO, :PLANOVGA-DATA-INIVIGENCIA, :PLANOVGA-IMP-MORNATU, :PLANOVGA-IMP-MORACID, :PLANOVGA-IMP-INVPERM, :PLANOVGA-IMP-AMDS, :PLANOVGA-IMP-DH, :PLANOVGA-IMP-DIT FROM SEGUROS.PLANOS_VGAP WHERE NUM_APOLICE = :SUBGVGAP-NUM-APOLICE AND COD_SUBGRUPO = :SUBGVGAP-COD-SUBGRUPO AND DATA_TERVIGENCIA IN ( '1999-12-31' , '9999-12-31' ) AND SIT_REGISTRO = '0' WITH UR END-EXEC. */

            var r2050_00_ACESSA_PLANOVGA_DB_SELECT_1_Query1 = new R2050_00_ACESSA_PLANOVGA_DB_SELECT_1_Query1()
            {
                SUBGVGAP_COD_SUBGRUPO = SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_SUBGRUPO.ToString(),
                SUBGVGAP_NUM_APOLICE = SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_NUM_APOLICE.ToString(),
            };

            var executed_1 = R2050_00_ACESSA_PLANOVGA_DB_SELECT_1_Query1.Execute(r2050_00_ACESSA_PLANOVGA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PLANOVGA_COD_PLANO, PLANOVGA.DCLPLANOS_VGAP.PLANOVGA_COD_PLANO);
                _.Move(executed_1.PLANOVGA_DATA_INIVIGENCIA, PLANOVGA.DCLPLANOS_VGAP.PLANOVGA_DATA_INIVIGENCIA);
                _.Move(executed_1.PLANOVGA_IMP_MORNATU, PLANOVGA.DCLPLANOS_VGAP.PLANOVGA_IMP_MORNATU);
                _.Move(executed_1.PLANOVGA_IMP_MORACID, PLANOVGA.DCLPLANOS_VGAP.PLANOVGA_IMP_MORACID);
                _.Move(executed_1.PLANOVGA_IMP_INVPERM, PLANOVGA.DCLPLANOS_VGAP.PLANOVGA_IMP_INVPERM);
                _.Move(executed_1.PLANOVGA_IMP_AMDS, PLANOVGA.DCLPLANOS_VGAP.PLANOVGA_IMP_AMDS);
                _.Move(executed_1.PLANOVGA_IMP_DH, PLANOVGA.DCLPLANOS_VGAP.PLANOVGA_IMP_DH);
                _.Move(executed_1.PLANOVGA_IMP_DIT, PLANOVGA.DCLPLANOS_VGAP.PLANOVGA_IMP_DIT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2050_99_EXIT*/

        [StopWatch]
        /*" R2055-00-ACESSA-PLANOVGA-SECTION */
        private void R2055_00_ACESSA_PLANOVGA_SECTION()
        {
            /*" -2408- MOVE 'R2055-00-ACESSA-PLANOVGA' TO PARAGRAFO. */
            _.Move("R2055-00-ACESSA-PLANOVGA", FILLER_1.WABEND.PARAGRAFO);

            /*" -2409- MOVE '2055' TO WNR-EXEC-SQL. */
            _.Move("2055", FILLER_1.WABEND.WNR_EXEC_SQL);

            /*" -2411- DISPLAY PARAGRAFO */
            _.Display(FILLER_1.WABEND.PARAGRAFO);

            /*" -2414- MOVE WS-APOLICE-ATU TO SUBGVGAP-NUM-APOLICE */
            _.Move(WS_CHAVE_ATU.WS_APOLICE_ATU, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_NUM_APOLICE);

            /*" -2418- MOVE WS-SUBGRUPO-ATU TO SUBGVGAP-COD-SUBGRUPO */
            _.Move(WS_CHAVE_ATU.WS_SUBGRUPO_ATU, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_SUBGRUPO);

            /*" -2419- MOVE 09 TO W01-I */
            _.Move(09, FILLER_0.W01_I);

            /*" -2420- MOVE 'R2055-DECLAR PLANOVGA  ' TO W01-TEXTO(W01-I) */
            _.Move("R2055-DECLAR PLANOVGA  ", FILLER_0.W01_TABELA_TEXTO.W01_TAB_TEXTO[FILLER_0.W01_I].W01_TEXTO);

            /*" -2424- PERFORM R8900-TOTALIZA-INICIO THRU R8900-TOTALIZA-INICIO-EXIT */

            R8900_TOTALIZA_INICIO_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8900_TOTALIZA_INICIO_EXIT*/


            /*" -2441- PERFORM R2055_00_ACESSA_PLANOVGA_DB_DECLARE_1 */

            R2055_00_ACESSA_PLANOVGA_DB_DECLARE_1();

            /*" -2443- PERFORM R2055_00_ACESSA_PLANOVGA_DB_OPEN_1 */

            R2055_00_ACESSA_PLANOVGA_DB_OPEN_1();

            /*" -2447- MOVE 1 TO W01-QTD-ACC-OK */
            _.Move(1, FILLER_0.W01_QTD_ACC_OK);

            /*" -2451- PERFORM R8910-TOTALIZA-FINAL THRU R8910-TOTALIZA-FINAL-EXIT */

            R8910_TOTALIZA_FINAL_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8910_TOTALIZA_FINAL_EXIT*/


            /*" -2452- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2453- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2456- END-IF. */
            }


            /*" -2457- MOVE 10 TO W01-I */
            _.Move(10, FILLER_0.W01_I);

            /*" -2458- MOVE 'R2055-FETCH  PLANOVGA  ' TO W01-TEXTO(W01-I) */
            _.Move("R2055-FETCH  PLANOVGA  ", FILLER_0.W01_TABELA_TEXTO.W01_TAB_TEXTO[FILLER_0.W01_I].W01_TEXTO);

            /*" -2462- PERFORM R8900-TOTALIZA-INICIO THRU R8900-TOTALIZA-INICIO-EXIT */

            R8900_TOTALIZA_INICIO_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8900_TOTALIZA_INICIO_EXIT*/


            /*" -2471- PERFORM R2055_00_ACESSA_PLANOVGA_DB_FETCH_1 */

            R2055_00_ACESSA_PLANOVGA_DB_FETCH_1();

            /*" -2475- MOVE 1 TO W01-QTD-ACC-OK */
            _.Move(1, FILLER_0.W01_QTD_ACC_OK);

            /*" -2479- PERFORM R8910-TOTALIZA-FINAL THRU R8910-TOTALIZA-FINAL-EXIT */

            R8910_TOTALIZA_FINAL_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8910_TOTALIZA_FINAL_EXIT*/


            /*" -2480- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2481- DISPLAY 'APOLICE SEM PLANOVGA1' */
                _.Display($"APOLICE SEM PLANOVGA1");

                /*" -2482- DISPLAY 'APOLICE.....' SUBGVGAP-NUM-APOLICE */
                _.Display($"APOLICE.....{SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_NUM_APOLICE}");

                /*" -2483- DISPLAY 'SUBGRUPO....' SUBGVGAP-COD-SUBGRUPO */
                _.Display($"SUBGRUPO....{SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_SUBGRUPO}");

                /*" -2484- MOVE 'NAO' TO WTEM-SUBGVGAP */
                _.Move("NAO", FILLER_1.FILLER_15.WTEM_SUBGVGAP);

                /*" -2486- MOVE 'PROBLEMAS NO SUBGRUPO - PLANO NAO CADASTRADO' TO OBSERVACAO-SAI2 */
                _.Move("PROBLEMAS NO SUBGRUPO - PLANO NAO CADASTRADO", REGISTRO_SAIDA2.OBSERVACAO_SAI2);

                /*" -2487- IF SQLCODE NOT EQUAL 100 */

                if (DB.SQLCODE != 100)
                {

                    /*" -2488- DISPLAY 'ERRO FETCH PLANOVGA1' */
                    _.Display($"ERRO FETCH PLANOVGA1");

                    /*" -2490- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -2490- PERFORM R2055_00_ACESSA_PLANOVGA_DB_CLOSE_1 */

            R2055_00_ACESSA_PLANOVGA_DB_CLOSE_1();

        }

        [StopWatch]
        /*" R2055-00-ACESSA-PLANOVGA-DB-DECLARE-1 */
        public void R2055_00_ACESSA_PLANOVGA_DB_DECLARE_1()
        {
            /*" -2441- EXEC SQL DECLARE PLANOVGA1 CURSOR FOR SELECT COD_PLANO, DATA_INIVIGENCIA, IMP_MORNATU, IMP_MORACID, IMP_INVPERM, IMP_AMDS, IMP_DH, IMP_DIT FROM SEGUROS.PLANOS_VGAP WHERE NUM_APOLICE = :SUBGVGAP-NUM-APOLICE AND COD_SUBGRUPO = :SUBGVGAP-COD-SUBGRUPO AND DATA_TERVIGENCIA IN ( '1999-12-31' , '9999-12-31' ) AND SIT_REGISTRO = '0' ORDER BY DATA_INIVIGENCIA DESC WITH UR END-EXEC. */
            PLANOVGA1 = new VG1613B_PLANOVGA1(true);
            string GetQuery_PLANOVGA1()
            {
                var query = @$"SELECT 
							COD_PLANO
							, 
							DATA_INIVIGENCIA
							, 
							IMP_MORNATU
							, 
							IMP_MORACID
							, 
							IMP_INVPERM
							, 
							IMP_AMDS
							, 
							IMP_DH
							, 
							IMP_DIT 
							FROM SEGUROS.PLANOS_VGAP 
							WHERE NUM_APOLICE = '{SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_NUM_APOLICE}' 
							AND COD_SUBGRUPO = '{SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_SUBGRUPO}' 
							AND DATA_TERVIGENCIA IN ( '1999-12-31'
							, '9999-12-31' ) 
							AND SIT_REGISTRO = '0' 
							ORDER BY DATA_INIVIGENCIA DESC";

                return query;
            }
            PLANOVGA1.GetQueryEvent += GetQuery_PLANOVGA1;

        }

        [StopWatch]
        /*" R2055-00-ACESSA-PLANOVGA-DB-OPEN-1 */
        public void R2055_00_ACESSA_PLANOVGA_DB_OPEN_1()
        {
            /*" -2443- EXEC SQL OPEN PLANOVGA1 END-EXEC. */

            PLANOVGA1.Open();

        }

        [StopWatch]
        /*" R2200-00-SELECT-SEGURVGA-DB-DECLARE-1 */
        public void R2200_00_SELECT_SEGURVGA_DB_DECLARE_1()
        {
            /*" -3482- EXEC SQL DECLARE SEGURVGA1 CURSOR FOR SELECT A.COD_CLIENTE , B.NUM_APOLICE , B.NUM_ITEM , B.OCORR_HISTORICO, B.NUM_CERTIFICADO, B.TIPO_SEGURADO , B.PCT_CONJUGE_VG , B.PCT_CONJUGE_AP , B.TAXA_AP_MORACID, B.TAXA_AP_INVPERM, B.TAXA_AP_AMDS , B.TAXA_AP_DH , B.TAXA_AP_DIT , B.TAXA_AP , B.TAXA_VG , B.OCORR_ENDERECO , B.SIT_REGISTRO FROM SEGUROS.CLIENTES A, SEGUROS.SEGURADOS_VGAP B WHERE A.CGCCPF = :CLIENTES-CGCCPF AND B.COD_CLIENTE = A.COD_CLIENTE AND B.NUM_APOLICE = :SUBGVGAP-NUM-APOLICE AND B.COD_SUBGRUPO = :SUBGVGAP-COD-SUBGRUPO END-EXEC. */
            SEGURVGA1 = new VG1613B_SEGURVGA1(true);
            string GetQuery_SEGURVGA1()
            {
                var query = @$"SELECT A.COD_CLIENTE
							, 
							B.NUM_APOLICE
							, 
							B.NUM_ITEM
							, 
							B.OCORR_HISTORICO
							, 
							B.NUM_CERTIFICADO
							, 
							B.TIPO_SEGURADO
							, 
							B.PCT_CONJUGE_VG
							, 
							B.PCT_CONJUGE_AP
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
							B.TAXA_AP
							, 
							B.TAXA_VG
							, 
							B.OCORR_ENDERECO
							, 
							B.SIT_REGISTRO 
							FROM SEGUROS.CLIENTES A
							, 
							SEGUROS.SEGURADOS_VGAP B 
							WHERE A.CGCCPF = '{CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF}' 
							AND B.COD_CLIENTE = A.COD_CLIENTE 
							AND B.NUM_APOLICE = '{SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_NUM_APOLICE}' 
							AND B.COD_SUBGRUPO = '{SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_SUBGRUPO}'";

                return query;
            }
            SEGURVGA1.GetQueryEvent += GetQuery_SEGURVGA1;

        }

        [StopWatch]
        /*" R2055-00-ACESSA-PLANOVGA-DB-FETCH-1 */
        public void R2055_00_ACESSA_PLANOVGA_DB_FETCH_1()
        {
            /*" -2471- EXEC SQL FETCH PLANOVGA1 INTO :PLANOVGA-COD-PLANO, :PLANOVGA-DATA-INIVIGENCIA, :PLANOVGA-IMP-MORNATU, :PLANOVGA-IMP-MORACID, :PLANOVGA-IMP-INVPERM, :PLANOVGA-IMP-AMDS, :PLANOVGA-IMP-DH, :PLANOVGA-IMP-DIT END-EXEC. */

            if (PLANOVGA1.Fetch())
            {
                _.Move(PLANOVGA1.PLANOVGA_COD_PLANO, PLANOVGA.DCLPLANOS_VGAP.PLANOVGA_COD_PLANO);
                _.Move(PLANOVGA1.PLANOVGA_DATA_INIVIGENCIA, PLANOVGA.DCLPLANOS_VGAP.PLANOVGA_DATA_INIVIGENCIA);
                _.Move(PLANOVGA1.PLANOVGA_IMP_MORNATU, PLANOVGA.DCLPLANOS_VGAP.PLANOVGA_IMP_MORNATU);
                _.Move(PLANOVGA1.PLANOVGA_IMP_MORACID, PLANOVGA.DCLPLANOS_VGAP.PLANOVGA_IMP_MORACID);
                _.Move(PLANOVGA1.PLANOVGA_IMP_INVPERM, PLANOVGA.DCLPLANOS_VGAP.PLANOVGA_IMP_INVPERM);
                _.Move(PLANOVGA1.PLANOVGA_IMP_AMDS, PLANOVGA.DCLPLANOS_VGAP.PLANOVGA_IMP_AMDS);
                _.Move(PLANOVGA1.PLANOVGA_IMP_DH, PLANOVGA.DCLPLANOS_VGAP.PLANOVGA_IMP_DH);
                _.Move(PLANOVGA1.PLANOVGA_IMP_DIT, PLANOVGA.DCLPLANOS_VGAP.PLANOVGA_IMP_DIT);
            }

        }

        [StopWatch]
        /*" R2055-00-ACESSA-PLANOVGA-DB-CLOSE-1 */
        public void R2055_00_ACESSA_PLANOVGA_DB_CLOSE_1()
        {
            /*" -2490- EXEC SQL CLOSE PLANOVGA1 END-EXEC. */

            PLANOVGA1.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2055_99_EXIT*/

        [StopWatch]
        /*" R2060-00-ACESSA-PLANOMUL-SECTION */
        private void R2060_00_ACESSA_PLANOMUL_SECTION()
        {
            /*" -2499- MOVE 'R2060-00-ACESSA-PLANOMUL' TO PARAGRAFO. */
            _.Move("R2060-00-ACESSA-PLANOMUL", FILLER_1.WABEND.PARAGRAFO);

            /*" -2500- MOVE '2060' TO WNR-EXEC-SQL. */
            _.Move("2060", FILLER_1.WABEND.WNR_EXEC_SQL);

            /*" -2503- DISPLAY PARAGRAFO */
            _.Display(FILLER_1.WABEND.PARAGRAFO);

            /*" -2504- MOVE 11 TO W01-I */
            _.Move(11, FILLER_0.W01_I);

            /*" -2505- MOVE 'R2060-SELECT PLANOMUL  ' TO W01-TEXTO(W01-I) */
            _.Move("R2060-SELECT PLANOMUL  ", FILLER_0.W01_TABELA_TEXTO.W01_TAB_TEXTO[FILLER_0.W01_I].W01_TEXTO);

            /*" -2508- PERFORM R8900-TOTALIZA-INICIO THRU R8900-TOTALIZA-INICIO-EXIT */

            R8900_TOTALIZA_INICIO_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8900_TOTALIZA_INICIO_EXIT*/


            /*" -2526- PERFORM R2060_00_ACESSA_PLANOMUL_DB_SELECT_1 */

            R2060_00_ACESSA_PLANOMUL_DB_SELECT_1();

            /*" -2530- MOVE 1 TO W01-QTD-ACC-OK */
            _.Move(1, FILLER_0.W01_QTD_ACC_OK);

            /*" -2534- PERFORM R8910-TOTALIZA-FINAL THRU R8910-TOTALIZA-FINAL-EXIT */

            R8910_TOTALIZA_FINAL_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8910_TOTALIZA_FINAL_EXIT*/


            /*" -2535- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2536- MOVE 1 TO FL-ERRO */
                _.Move(1, FILLER_1.FL_ERRO);

                /*" -2537- IF SQLCODE NOT EQUAL 100 */

                if (DB.SQLCODE != 100)
                {

                    /*" -2538- DISPLAY 'ERRO ACESSO PLANOS_MULTISAL' */
                    _.Display($"ERRO ACESSO PLANOS_MULTISAL");

                    /*" -2539- DISPLAY 'APOLICE.....' SUBGVGAP-NUM-APOLICE */
                    _.Display($"APOLICE.....{SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_NUM_APOLICE}");

                    /*" -2540- DISPLAY 'SUBGRUPO....' SUBGVGAP-COD-SUBGRUPO */
                    _.Display($"SUBGRUPO....{SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_SUBGRUPO}");

                    /*" -2541- DISPLAY 'PLANO.......' PLANOVGA-COD-PLANO */
                    _.Display($"PLANO.......{PLANOVGA.DCLPLANOS_VGAP.PLANOVGA_COD_PLANO}");

                    /*" -2542- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2543- ELSE */
                }
                else
                {


                    /*" -2544- DISPLAY 'APOLICE SEM PLANOS_MULTISAL' */
                    _.Display($"APOLICE SEM PLANOS_MULTISAL");

                    /*" -2545- DISPLAY 'APOLICE.....' SUBGVGAP-NUM-APOLICE */
                    _.Display($"APOLICE.....{SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_NUM_APOLICE}");

                    /*" -2546- DISPLAY 'SUBGRUPO....' SUBGVGAP-COD-SUBGRUPO */
                    _.Display($"SUBGRUPO....{SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_SUBGRUPO}");

                    /*" -2547- DISPLAY 'PLANO.......' PLANOVGA-COD-PLANO */
                    _.Display($"PLANO.......{PLANOVGA.DCLPLANOS_VGAP.PLANOVGA_COD_PLANO}");

                    /*" -2548- MOVE 4035 TO COD-ERRO-SOR */
                    _.Move(4035, REGISTRO_SORT.COD_ERRO_SOR);

                    /*" -2549- PERFORM R2020-00-GRAVA-RETORNO */

                    R2020_00_GRAVA_RETORNO_SECTION();

                    /*" -2550- MOVE 'SIM' TO WS-ERRO-MOVTO WS-ERRO-SUBGRUPO. */
                    _.Move("SIM", WS_ERRO_MOVTO, WS_ERRO_SUBGRUPO);
                }

            }


        }

        [StopWatch]
        /*" R2060-00-ACESSA-PLANOMUL-DB-SELECT-1 */
        public void R2060_00_ACESSA_PLANOMUL_DB_SELECT_1()
        {
            /*" -2526- EXEC SQL SELECT QTD_SAL_MORNATU, QTD_SAL_MORACID, QTD_SAL_INVPERM, LIM_CAP_MORNATU, LIM_CAP_MORACID, LIM_CAP_INVAPER INTO :PLANOMUL-QTD-SAL-MORNATU, :PLANOMUL-QTD-SAL-MORACID, :PLANOMUL-QTD-SAL-INVPERM, :PLANOMUL-LIM-CAP-MORNATU, :PLANOMUL-LIM-CAP-MORACID, :PLANOMUL-LIM-CAP-INVAPER FROM SEGUROS.PLANOS_MULTISAL WHERE NUM_APOLICE = :SUBGVGAP-NUM-APOLICE AND COD_SUBGRUPO = :SUBGVGAP-COD-SUBGRUPO AND COD_PLANO = :PLANOVGA-COD-PLANO WITH UR END-EXEC. */

            var r2060_00_ACESSA_PLANOMUL_DB_SELECT_1_Query1 = new R2060_00_ACESSA_PLANOMUL_DB_SELECT_1_Query1()
            {
                SUBGVGAP_COD_SUBGRUPO = SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_SUBGRUPO.ToString(),
                SUBGVGAP_NUM_APOLICE = SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_NUM_APOLICE.ToString(),
                PLANOVGA_COD_PLANO = PLANOVGA.DCLPLANOS_VGAP.PLANOVGA_COD_PLANO.ToString(),
            };

            var executed_1 = R2060_00_ACESSA_PLANOMUL_DB_SELECT_1_Query1.Execute(r2060_00_ACESSA_PLANOMUL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PLANOMUL_QTD_SAL_MORNATU, PLANOMUL.DCLPLANOS_MULTISAL.PLANOMUL_QTD_SAL_MORNATU);
                _.Move(executed_1.PLANOMUL_QTD_SAL_MORACID, PLANOMUL.DCLPLANOS_MULTISAL.PLANOMUL_QTD_SAL_MORACID);
                _.Move(executed_1.PLANOMUL_QTD_SAL_INVPERM, PLANOMUL.DCLPLANOS_MULTISAL.PLANOMUL_QTD_SAL_INVPERM);
                _.Move(executed_1.PLANOMUL_LIM_CAP_MORNATU, PLANOMUL.DCLPLANOS_MULTISAL.PLANOMUL_LIM_CAP_MORNATU);
                _.Move(executed_1.PLANOMUL_LIM_CAP_MORACID, PLANOMUL.DCLPLANOS_MULTISAL.PLANOMUL_LIM_CAP_MORACID);
                _.Move(executed_1.PLANOMUL_LIM_CAP_INVAPER, PLANOMUL.DCLPLANOS_MULTISAL.PLANOMUL_LIM_CAP_INVAPER);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2060_99_EXIT*/

        [StopWatch]
        /*" R2070-00-CALCULA-IDADE-SECTION */
        private void R2070_00_CALCULA_IDADE_SECTION()
        {
            /*" -2559- MOVE 'R2070-00-CALCULA-IDADE' TO PARAGRAFO. */
            _.Move("R2070-00-CALCULA-IDADE", FILLER_1.WABEND.PARAGRAFO);

            /*" -2560- MOVE '2070' TO WNR-EXEC-SQL. */
            _.Move("2070", FILLER_1.WABEND.WNR_EXEC_SQL);

            /*" -2562- DISPLAY PARAGRAFO */
            _.Display(FILLER_1.WABEND.PARAGRAFO);

            /*" -2563- MOVE SISTEMAS-DATA-MOV-ABERTO TO WS-W01DTSQL. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, FILLER_1.WS_W01DTSQL);

            /*" -2564- MOVE WS-W01DDSQL TO W02DDCSP. */
            _.Move(FILLER_1.WS_W01DTSQL.WS_W01DDSQL, FILLER_1.FILLER_12.W02DDCSP);

            /*" -2565- MOVE WS-W01MMSQL TO W02MMCSP. */
            _.Move(FILLER_1.WS_W01DTSQL.WS_W01MMSQL, FILLER_1.FILLER_12.W02MMCSP);

            /*" -2566- MOVE WS-W01SCSQL TO W02SCCSP. */
            _.Move(FILLER_1.WS_W01DTSQL.WS_W01SCSQL, FILLER_1.FILLER_12.W02SCCSP);

            /*" -2567- MOVE WS-W01AASQL TO W02AACSP. */
            _.Move(FILLER_1.WS_W01DTSQL.WS_W01AASQL, FILLER_1.FILLER_12.W02AACSP);

            /*" -2569- MOVE W02DTCSP TO LK-DATA1 */
            _.Move(FILLER_1.W02DTCSP, LK_LINK.LK_DATA1);

            /*" -2570- MOVE DTNAS-SOR TO WS-W01DTSQL */
            _.Move(REGISTRO_SORT.DTNAS_SOR, FILLER_1.WS_W01DTSQL);

            /*" -2571- MOVE WS-W01DDSQL TO W02DDCSP. */
            _.Move(FILLER_1.WS_W01DTSQL.WS_W01DDSQL, FILLER_1.FILLER_12.W02DDCSP);

            /*" -2572- MOVE WS-W01MMSQL TO W02MMCSP. */
            _.Move(FILLER_1.WS_W01DTSQL.WS_W01MMSQL, FILLER_1.FILLER_12.W02MMCSP);

            /*" -2573- MOVE WS-W01SCSQL TO W02SCCSP. */
            _.Move(FILLER_1.WS_W01DTSQL.WS_W01SCSQL, FILLER_1.FILLER_12.W02SCCSP);

            /*" -2574- MOVE WS-W01AASQL TO W02AACSP. */
            _.Move(FILLER_1.WS_W01DTSQL.WS_W01AASQL, FILLER_1.FILLER_12.W02AACSP);

            /*" -2576- MOVE W02DTCSP TO LK-DATA2 */
            _.Move(FILLER_1.W02DTCSP, LK_LINK.LK_DATA2);

            /*" -2578- CALL 'PRODIFC1' USING LK-LINK. */
            _.Call("PRODIFC1", LK_LINK);

            /*" -2579- COMPUTE WS-IDADE = QTDIA / 365. */
            WS_IDADE.Value = LK_LINK.QTDIA / 365;

            /*" -2579- DISPLAY 'IDADE = ' FAIXAETA-IDADE-INICIAL. */
            _.Display($"IDADE = {FAIXAETA.DCLFAIXA_ETARIA.FAIXAETA_IDADE_INICIAL}");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2070_99_EXIT*/

        [StopWatch]
        /*" R2080-00-ACESSA-FAIXAETA-SECTION */
        private void R2080_00_ACESSA_FAIXAETA_SECTION()
        {
            /*" -2588- MOVE 'R2080-00-ACESSA-FAIXAETA' TO PARAGRAFO. */
            _.Move("R2080-00-ACESSA-FAIXAETA", FILLER_1.WABEND.PARAGRAFO);

            /*" -2589- MOVE '2080' TO WNR-EXEC-SQL. */
            _.Move("2080", FILLER_1.WABEND.WNR_EXEC_SQL);

            /*" -2591- DISPLAY PARAGRAFO */
            _.Display(FILLER_1.WABEND.PARAGRAFO);

            /*" -2594- MOVE WS-IDADE TO FAIXAETA-IDADE-INICIAL. */
            _.Move(WS_IDADE, FAIXAETA.DCLFAIXA_ETARIA.FAIXAETA_IDADE_INICIAL);

            /*" -2595- MOVE 12 TO W01-I */
            _.Move(12, FILLER_0.W01_I);

            /*" -2596- MOVE 'R2080-SELECT FAIXAETA  ' TO W01-TEXTO(W01-I) */
            _.Move("R2080-SELECT FAIXAETA  ", FILLER_0.W01_TABELA_TEXTO.W01_TAB_TEXTO[FILLER_0.W01_I].W01_TEXTO);

            /*" -2600- PERFORM R8900-TOTALIZA-INICIO THRU R8900-TOTALIZA-INICIO-EXIT */

            R8900_TOTALIZA_INICIO_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8900_TOTALIZA_INICIO_EXIT*/


            /*" -2612- PERFORM R2080_00_ACESSA_FAIXAETA_DB_SELECT_1 */

            R2080_00_ACESSA_FAIXAETA_DB_SELECT_1();

            /*" -2616- MOVE 1 TO W01-QTD-ACC-OK */
            _.Move(1, FILLER_0.W01_QTD_ACC_OK);

            /*" -2620- PERFORM R8910-TOTALIZA-FINAL THRU R8910-TOTALIZA-FINAL-EXIT */

            R8910_TOTALIZA_FINAL_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8910_TOTALIZA_FINAL_EXIT*/


            /*" -2621- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2622- MOVE 1 TO FL-ERRO */
                _.Move(1, FILLER_1.FL_ERRO);

                /*" -2623- IF SQLCODE NOT EQUAL 100 */

                if (DB.SQLCODE != 100)
                {

                    /*" -2624- DISPLAY 'ERRO ACESSO FAIXA_ETARIA' */
                    _.Display($"ERRO ACESSO FAIXA_ETARIA");

                    /*" -2625- DISPLAY 'APOLICE.....' SUBGVGAP-NUM-APOLICE */
                    _.Display($"APOLICE.....{SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_NUM_APOLICE}");

                    /*" -2626- DISPLAY 'SUBGRUPO....' SUBGVGAP-COD-SUBGRUPO */
                    _.Display($"SUBGRUPO....{SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_SUBGRUPO}");

                    /*" -2627- DISPLAY 'IDADE.......' WS-IDADE */
                    _.Display($"IDADE.......{WS_IDADE}");

                    /*" -2628- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2629- ELSE */
                }
                else
                {


                    /*" -2630- DISPLAY 'APOLICE SEM FAIXA_ETARIA' */
                    _.Display($"APOLICE SEM FAIXA_ETARIA");

                    /*" -2631- DISPLAY 'APOLICE.....' SUBGVGAP-NUM-APOLICE */
                    _.Display($"APOLICE.....{SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_NUM_APOLICE}");

                    /*" -2632- DISPLAY 'SUBGRUPO....' SUBGVGAP-COD-SUBGRUPO */
                    _.Display($"SUBGRUPO....{SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_SUBGRUPO}");

                    /*" -2633- DISPLAY 'IDADE.......' WS-IDADE */
                    _.Display($"IDADE.......{WS_IDADE}");

                    /*" -2634- MOVE 4034 TO COD-ERRO-SOR */
                    _.Move(4034, REGISTRO_SORT.COD_ERRO_SOR);

                    /*" -2635- PERFORM R2020-00-GRAVA-RETORNO */

                    R2020_00_GRAVA_RETORNO_SECTION();

                    /*" -2636- MOVE 'SIM' TO WS-ERRO-MOVTO WS-ERRO-SUBGRUPO. */
                    _.Move("SIM", WS_ERRO_MOVTO, WS_ERRO_SUBGRUPO);
                }

            }


        }

        [StopWatch]
        /*" R2080-00-ACESSA-FAIXAETA-DB-SELECT-1 */
        public void R2080_00_ACESSA_FAIXAETA_DB_SELECT_1()
        {
            /*" -2612- EXEC SQL SELECT FAIXA, TAXA_VG INTO :FAIXAETA-FAIXA, :FAIXAETA-TAXA-VG FROM SEGUROS.FAIXA_ETARIA WHERE NUM_APOLICE = :SUBGVGAP-NUM-APOLICE AND COD_SUBGRUPO = :SUBGVGAP-COD-SUBGRUPO AND IDADE_INICIAL <= :FAIXAETA-IDADE-INICIAL AND IDADE_FINAL >= :FAIXAETA-IDADE-INICIAL AND DATA_TERVIGENCIA IN ( '1999-12-31' , '9999-12-31' ) WITH UR END-EXEC. */

            var r2080_00_ACESSA_FAIXAETA_DB_SELECT_1_Query1 = new R2080_00_ACESSA_FAIXAETA_DB_SELECT_1_Query1()
            {
                FAIXAETA_IDADE_INICIAL = FAIXAETA.DCLFAIXA_ETARIA.FAIXAETA_IDADE_INICIAL.ToString(),
                SUBGVGAP_COD_SUBGRUPO = SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_SUBGRUPO.ToString(),
                SUBGVGAP_NUM_APOLICE = SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_NUM_APOLICE.ToString(),
            };

            var executed_1 = R2080_00_ACESSA_FAIXAETA_DB_SELECT_1_Query1.Execute(r2080_00_ACESSA_FAIXAETA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.FAIXAETA_FAIXA, FAIXAETA.DCLFAIXA_ETARIA.FAIXAETA_FAIXA);
                _.Move(executed_1.FAIXAETA_TAXA_VG, FAIXAETA.DCLFAIXA_ETARIA.FAIXAETA_TAXA_VG);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2080_99_EXIT*/

        [StopWatch]
        /*" R2085-00-ACESSA-FAIXAETA-SECTION */
        private void R2085_00_ACESSA_FAIXAETA_SECTION()
        {
            /*" -2645- MOVE 'R2085-00-ACESSA-FAIXAETA' TO PARAGRAFO. */
            _.Move("R2085-00-ACESSA-FAIXAETA", FILLER_1.WABEND.PARAGRAFO);

            /*" -2646- MOVE '2085' TO WNR-EXEC-SQL. */
            _.Move("2085", FILLER_1.WABEND.WNR_EXEC_SQL);

            /*" -2648- DISPLAY PARAGRAFO */
            _.Display(FILLER_1.WABEND.PARAGRAFO);

            /*" -2651- MOVE ZEROS TO FAIXAETA-IDADE-FINAL. */
            _.Move(0, FAIXAETA.DCLFAIXA_ETARIA.FAIXAETA_IDADE_FINAL);

            /*" -2652- MOVE 13 TO W01-I */
            _.Move(13, FILLER_0.W01_I);

            /*" -2653- MOVE 'R2085-SELECT FAIXAETA  ' TO W01-TEXTO(W01-I) */
            _.Move("R2085-SELECT FAIXAETA  ", FILLER_0.W01_TABELA_TEXTO.W01_TAB_TEXTO[FILLER_0.W01_I].W01_TEXTO);

            /*" -2656- PERFORM R8900-TOTALIZA-INICIO THRU R8900-TOTALIZA-INICIO-EXIT */

            R8900_TOTALIZA_INICIO_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8900_TOTALIZA_INICIO_EXIT*/


            /*" -2658- MOVE WS-IDADE TO FAIXAETA-IDADE-INICIAL. */
            _.Move(WS_IDADE, FAIXAETA.DCLFAIXA_ETARIA.FAIXAETA_IDADE_INICIAL);

            /*" -2668- PERFORM R2085_00_ACESSA_FAIXAETA_DB_SELECT_1 */

            R2085_00_ACESSA_FAIXAETA_DB_SELECT_1();

            /*" -2672- MOVE 1 TO W01-QTD-ACC-OK */
            _.Move(1, FILLER_0.W01_QTD_ACC_OK);

            /*" -2676- PERFORM R8910-TOTALIZA-FINAL THRU R8910-TOTALIZA-FINAL-EXIT */

            R8910_TOTALIZA_FINAL_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8910_TOTALIZA_FINAL_EXIT*/


            /*" -2677- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2678- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2679- MOVE ZEROS TO FAIXAETA-IDADE-FINAL */
                    _.Move(0, FAIXAETA.DCLFAIXA_ETARIA.FAIXAETA_IDADE_FINAL);

                    /*" -2680- ELSE */
                }
                else
                {


                    /*" -2681- DISPLAY 'ERRO ACESSO FAIXA_ETARIA' */
                    _.Display($"ERRO ACESSO FAIXA_ETARIA");

                    /*" -2682- DISPLAY 'APOLICE  = ' SUBGVGAP-NUM-APOLICE */
                    _.Display($"APOLICE  = {SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_NUM_APOLICE}");

                    /*" -2683- DISPLAY 'SUBGRUPO = ' SUBGVGAP-COD-SUBGRUPO */
                    _.Display($"SUBGRUPO = {SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_SUBGRUPO}");

                    /*" -2684- DISPLAY 'IDADE    = ' FAIXAETA-IDADE-INICIAL */
                    _.Display($"IDADE    = {FAIXAETA.DCLFAIXA_ETARIA.FAIXAETA_IDADE_INICIAL}");

                    /*" -2685- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R2085-00-ACESSA-FAIXAETA-DB-SELECT-1 */
        public void R2085_00_ACESSA_FAIXAETA_DB_SELECT_1()
        {
            /*" -2668- EXEC SQL SELECT IDADE_FINAL INTO :FAIXAETA-IDADE-FINAL FROM SEGUROS.FAIXA_ETARIA WHERE NUM_APOLICE = :SUBGVGAP-NUM-APOLICE AND COD_SUBGRUPO = :SUBGVGAP-COD-SUBGRUPO AND IDADE_INICIAL <= :FAIXAETA-IDADE-INICIAL AND IDADE_FINAL >= :FAIXAETA-IDADE-INICIAL AND DATA_TERVIGENCIA IN ( '1999-12-31' , '9999-12-31' ) WITH UR END-EXEC. */

            var r2085_00_ACESSA_FAIXAETA_DB_SELECT_1_Query1 = new R2085_00_ACESSA_FAIXAETA_DB_SELECT_1_Query1()
            {
                FAIXAETA_IDADE_INICIAL = FAIXAETA.DCLFAIXA_ETARIA.FAIXAETA_IDADE_INICIAL.ToString(),
                SUBGVGAP_COD_SUBGRUPO = SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_SUBGRUPO.ToString(),
                SUBGVGAP_NUM_APOLICE = SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_NUM_APOLICE.ToString(),
            };

            var executed_1 = R2085_00_ACESSA_FAIXAETA_DB_SELECT_1_Query1.Execute(r2085_00_ACESSA_FAIXAETA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.FAIXAETA_IDADE_FINAL, FAIXAETA.DCLFAIXA_ETARIA.FAIXAETA_IDADE_FINAL);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2085_99_EXIT*/

        [StopWatch]
        /*" R2090-00-ACESSA-FAIXASAL-SECTION */
        private void R2090_00_ACESSA_FAIXASAL_SECTION()
        {
            /*" -2693- MOVE 'R2090-00-ACESSA-FAIXASAL' TO PARAGRAFO. */
            _.Move("R2090-00-ACESSA-FAIXASAL", FILLER_1.WABEND.PARAGRAFO);

            /*" -2694- MOVE '2090' TO WNR-EXEC-SQL. */
            _.Move("2090", FILLER_1.WABEND.WNR_EXEC_SQL);

            /*" -2696- DISPLAY PARAGRAFO */
            _.Display(FILLER_1.WABEND.PARAGRAFO);

            /*" -2699- MOVE SALARIO-SOR TO FAIXASAL-SALARIO-INICIAL */
            _.Move(REGISTRO_SORT.SALARIO_SOR, FAIXASAL.DCLFAIXA_SALARIAL.FAIXASAL_SALARIO_INICIAL);

            /*" -2700- MOVE 14 TO W01-I */
            _.Move(14, FILLER_0.W01_I);

            /*" -2701- MOVE 'R2090-SELECT FAIXASAL  ' TO W01-TEXTO(W01-I) */
            _.Move("R2090-SELECT FAIXASAL  ", FILLER_0.W01_TABELA_TEXTO.W01_TAB_TEXTO[FILLER_0.W01_I].W01_TEXTO);

            /*" -2705- PERFORM R8900-TOTALIZA-INICIO THRU R8900-TOTALIZA-INICIO-EXIT */

            R8900_TOTALIZA_INICIO_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8900_TOTALIZA_INICIO_EXIT*/


            /*" -2716- PERFORM R2090_00_ACESSA_FAIXASAL_DB_SELECT_1 */

            R2090_00_ACESSA_FAIXASAL_DB_SELECT_1();

            /*" -2720- MOVE 1 TO W01-QTD-ACC-OK */
            _.Move(1, FILLER_0.W01_QTD_ACC_OK);

            /*" -2724- PERFORM R8910-TOTALIZA-FINAL THRU R8910-TOTALIZA-FINAL-EXIT */

            R8910_TOTALIZA_FINAL_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8910_TOTALIZA_FINAL_EXIT*/


            /*" -2725- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2726- MOVE 1 TO FL-ERRO */
                _.Move(1, FILLER_1.FL_ERRO);

                /*" -2727- IF SQLCODE NOT EQUAL +100 */

                if (DB.SQLCODE != +100)
                {

                    /*" -2728- DISPLAY 'ERRO ACESSO FAIXA_SALARIAL' */
                    _.Display($"ERRO ACESSO FAIXA_SALARIAL");

                    /*" -2729- DISPLAY 'APOLICE.....' SUBGVGAP-NUM-APOLICE */
                    _.Display($"APOLICE.....{SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_NUM_APOLICE}");

                    /*" -2730- DISPLAY 'SUBGRUPO....' SUBGVGAP-COD-SUBGRUPO */
                    _.Display($"SUBGRUPO....{SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_SUBGRUPO}");

                    /*" -2731- DISPLAY 'SALARIO.....' FAIXASAL-SALARIO-INICIAL */
                    _.Display($"SALARIO.....{FAIXASAL.DCLFAIXA_SALARIAL.FAIXASAL_SALARIO_INICIAL}");

                    /*" -2732- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2733- END-IF */
                }


                /*" -2733- END-IF. */
            }


        }

        [StopWatch]
        /*" R2090-00-ACESSA-FAIXASAL-DB-SELECT-1 */
        public void R2090_00_ACESSA_FAIXASAL_DB_SELECT_1()
        {
            /*" -2716- EXEC SQL SELECT VALUE(FAIXA, 0), VALUE(TAXA_VG, 0) INTO :FAIXASAL-FAIXA, :FAIXASAL-TAXA-VG FROM SEGUROS.FAIXA_SALARIAL WHERE NUM_APOLICE = :SUBGVGAP-NUM-APOLICE AND COD_SUBGRUPO = :SUBGVGAP-COD-SUBGRUPO AND SALARIO_INICIAL <= :FAIXASAL-SALARIO-INICIAL AND SALARIO_FINAL >= :FAIXASAL-SALARIO-INICIAL WITH UR END-EXEC. */

            var r2090_00_ACESSA_FAIXASAL_DB_SELECT_1_Query1 = new R2090_00_ACESSA_FAIXASAL_DB_SELECT_1_Query1()
            {
                FAIXASAL_SALARIO_INICIAL = FAIXASAL.DCLFAIXA_SALARIAL.FAIXASAL_SALARIO_INICIAL.ToString(),
                SUBGVGAP_COD_SUBGRUPO = SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_SUBGRUPO.ToString(),
                SUBGVGAP_NUM_APOLICE = SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_NUM_APOLICE.ToString(),
            };

            var executed_1 = R2090_00_ACESSA_FAIXASAL_DB_SELECT_1_Query1.Execute(r2090_00_ACESSA_FAIXASAL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.FAIXASAL_FAIXA, FAIXASAL.DCLFAIXA_SALARIAL.FAIXASAL_FAIXA);
                _.Move(executed_1.FAIXASAL_TAXA_VG, FAIXASAL.DCLFAIXA_SALARIAL.FAIXASAL_TAXA_VG);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2090_99_EXIT*/

        [StopWatch]
        /*" R2095-00-ACESSA-FAIXA-SEMSAL-SECTION */
        private void R2095_00_ACESSA_FAIXA_SEMSAL_SECTION()
        {
            /*" -2742- MOVE 'R2095-00-ACESSA-FAIXA-SEMSAL' TO PARAGRAFO. */
            _.Move("R2095-00-ACESSA-FAIXA-SEMSAL", FILLER_1.WABEND.PARAGRAFO);

            /*" -2743- MOVE '2095' TO WNR-EXEC-SQL. */
            _.Move("2095", FILLER_1.WABEND.WNR_EXEC_SQL);

            /*" -2746- DISPLAY PARAGRAFO */
            _.Display(FILLER_1.WABEND.PARAGRAFO);

            /*" -2747- MOVE 15 TO W01-I */
            _.Move(15, FILLER_0.W01_I);

            /*" -2748- MOVE 'R2095-SELECT FAIXASAL  ' TO W01-TEXTO(W01-I) */
            _.Move("R2095-SELECT FAIXASAL  ", FILLER_0.W01_TABELA_TEXTO.W01_TAB_TEXTO[FILLER_0.W01_I].W01_TEXTO);

            /*" -2752- PERFORM R8900-TOTALIZA-INICIO THRU R8900-TOTALIZA-INICIO-EXIT */

            R8900_TOTALIZA_INICIO_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8900_TOTALIZA_INICIO_EXIT*/


            /*" -2766- PERFORM R2095_00_ACESSA_FAIXA_SEMSAL_DB_SELECT_1 */

            R2095_00_ACESSA_FAIXA_SEMSAL_DB_SELECT_1();

            /*" -2770- MOVE 1 TO W01-QTD-ACC-OK */
            _.Move(1, FILLER_0.W01_QTD_ACC_OK);

            /*" -2774- PERFORM R8910-TOTALIZA-FINAL THRU R8910-TOTALIZA-FINAL-EXIT */

            R8910_TOTALIZA_FINAL_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8910_TOTALIZA_FINAL_EXIT*/


            /*" -2775- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -2776- MOVE 1 TO FL-ERRO */
                _.Move(1, FILLER_1.FL_ERRO);

                /*" -2777- IF (SQLCODE NOT EQUAL +100) */

                if ((DB.SQLCODE != +100))
                {

                    /*" -2778- DISPLAY 'R2095 - ERRO ACESSO FAIXA_SALARIAL' */
                    _.Display($"R2095 - ERRO ACESSO FAIXA_SALARIAL");

                    /*" -2779- DISPLAY 'APOLICE.....' SUBGVGAP-NUM-APOLICE */
                    _.Display($"APOLICE.....{SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_NUM_APOLICE}");

                    /*" -2780- DISPLAY 'SUBGRUPO....' SUBGVGAP-COD-SUBGRUPO */
                    _.Display($"SUBGRUPO....{SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_SUBGRUPO}");

                    /*" -2781- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2782- END-IF */
                }


                /*" -2783- END-IF. */
            }


        }

        [StopWatch]
        /*" R2095-00-ACESSA-FAIXA-SEMSAL-DB-SELECT-1 */
        public void R2095_00_ACESSA_FAIXA_SEMSAL_DB_SELECT_1()
        {
            /*" -2766- EXEC SQL SELECT VALUE(FAIXA, 0), VALUE(TAXA_VG, 0) INTO :FAIXASAL-FAIXA, :FAIXASAL-TAXA-VG FROM SEGUROS.FAIXA_SALARIAL WHERE NUM_APOLICE = :SUBGVGAP-NUM-APOLICE AND COD_SUBGRUPO = :SUBGVGAP-COD-SUBGRUPO AND FAIXA = (SELECT MIN(A.FAIXA) FROM SEGUROS.FAIXA_SALARIAL A WHERE A.NUM_APOLICE = :SUBGVGAP-NUM-APOLICE AND A.COD_SUBGRUPO = :SUBGVGAP-COD-SUBGRUPO) WITH UR END-EXEC. */

            var r2095_00_ACESSA_FAIXA_SEMSAL_DB_SELECT_1_Query1 = new R2095_00_ACESSA_FAIXA_SEMSAL_DB_SELECT_1_Query1()
            {
                SUBGVGAP_COD_SUBGRUPO = SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_SUBGRUPO.ToString(),
                SUBGVGAP_NUM_APOLICE = SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_NUM_APOLICE.ToString(),
            };

            var executed_1 = R2095_00_ACESSA_FAIXA_SEMSAL_DB_SELECT_1_Query1.Execute(r2095_00_ACESSA_FAIXA_SEMSAL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.FAIXASAL_FAIXA, FAIXASAL.DCLFAIXA_SALARIAL.FAIXASAL_FAIXA);
                _.Move(executed_1.FAIXASAL_TAXA_VG, FAIXASAL.DCLFAIXA_SALARIAL.FAIXASAL_TAXA_VG);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2095_99_EXIT*/

        [StopWatch]
        /*" R2100-00-MOVE-COBERTURAS-SECTION */
        private void R2100_00_MOVE_COBERTURAS_SECTION()
        {
            /*" -2791- MOVE 'R2100-00-MOVE-COBERTURAS' TO PARAGRAFO. */
            _.Move("R2100-00-MOVE-COBERTURAS", FILLER_1.WABEND.PARAGRAFO);

            /*" -2792- MOVE '2100' TO WNR-EXEC-SQL. */
            _.Move("2100", FILLER_1.WABEND.WNR_EXEC_SQL);

            /*" -2794- DISPLAY PARAGRAFO */
            _.Display(FILLER_1.WABEND.PARAGRAFO);

            /*" -2795- IF (SUBGVGAP-TIPO-PLANO EQUAL '1' OR '2' OR '4' ) */

            if ((SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_TIPO_PLANO.In("1", "2", "4")))
            {

                /*" -2798- MOVE 0 TO MOVIMVGA-QTD-SAL-MORNATU MOVIMVGA-QTD-SAL-MORACID MOVIMVGA-QTD-SAL-INVPERM */
                _.Move(0, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_QTD_SAL_MORNATU, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_QTD_SAL_MORACID, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_QTD_SAL_INVPERM);

                /*" -2799- PERFORM R2120-00-CONVERTE-CAPITAL */

                R2120_00_CONVERTE_CAPITAL_SECTION();

                /*" -2801- END-IF. */
            }


            /*" -2802- IF (SUBGVGAP-TIPO-PLANO EQUAL '3' ) */

            if ((SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_TIPO_PLANO == "3"))
            {

                /*" -2805- MOVE 0 TO MOVIMVGA-IMP-AMDS-ATU MOVIMVGA-IMP-DH-ATU MOVIMVGA-IMP-DIT-ATU */
                _.Move(0, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_AMDS_ATU, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_DH_ATU, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_DIT_ATU);

                /*" -2806- IF (SUBGVGAP-IND-PLANO-ASSOCIA EQUAL 'S' ) */

                if ((SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_IND_PLANO_ASSOCIA == "S"))
                {

                    /*" -2808- MOVE PLANOMUL-QTD-SAL-MORNATU TO MOVIMVGA-QTD-SAL-MORNATU */
                    _.Move(PLANOMUL.DCLPLANOS_MULTISAL.PLANOMUL_QTD_SAL_MORNATU, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_QTD_SAL_MORNATU);

                    /*" -2810- MOVE PLANOMUL-QTD-SAL-MORACID TO MOVIMVGA-QTD-SAL-MORACID */
                    _.Move(PLANOMUL.DCLPLANOS_MULTISAL.PLANOMUL_QTD_SAL_MORACID, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_QTD_SAL_MORACID);

                    /*" -2812- MOVE PLANOMUL-QTD-SAL-INVPERM TO MOVIMVGA-QTD-SAL-INVPERM */
                    _.Move(PLANOMUL.DCLPLANOS_MULTISAL.PLANOMUL_QTD_SAL_INVPERM, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_QTD_SAL_INVPERM);

                    /*" -2813- PERFORM R2140-00-MULTIPLO-SALARIAL */

                    R2140_00_MULTIPLO_SALARIAL_SECTION();

                    /*" -2814- PERFORM R2120-00-CONVERTE-CAPITAL */

                    R2120_00_CONVERTE_CAPITAL_SECTION();

                    /*" -2815- ELSE */
                }
                else
                {


                    /*" -2816- IF (QTDSAL-SOR GREATER ZEROS) */

                    if ((REGISTRO_SORT.QTDSAL_SOR > 00))
                    {

                        /*" -2820- MOVE QTDSAL-SOR TO CONDITEC-QTD-SAL-MORNATU CONDITEC-QTD-SAL-MORACID CONDITEC-QTD-SAL-INVPERM */
                        _.Move(REGISTRO_SORT.QTDSAL_SOR, CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_QTD_SAL_MORNATU, CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_QTD_SAL_MORACID, CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_QTD_SAL_INVPERM);

                        /*" -2821- END-IF */
                    }


                    /*" -2823- MOVE CONDITEC-QTD-SAL-MORNATU TO MOVIMVGA-QTD-SAL-MORNATU */
                    _.Move(CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_QTD_SAL_MORNATU, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_QTD_SAL_MORNATU);

                    /*" -2825- MOVE CONDITEC-QTD-SAL-MORACID TO MOVIMVGA-QTD-SAL-MORACID */
                    _.Move(CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_QTD_SAL_MORACID, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_QTD_SAL_MORACID);

                    /*" -2828- MOVE CONDITEC-QTD-SAL-INVPERM TO MOVIMVGA-QTD-SAL-INVPERM */
                    _.Move(CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_QTD_SAL_INVPERM, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_QTD_SAL_INVPERM);

                    /*" -2829- PERFORM R2150-00-MULTIPLO-SALARIAL */

                    R2150_00_MULTIPLO_SALARIAL_SECTION();

                    /*" -2830- PERFORM R2120-00-CONVERTE-CAPITAL */

                    R2120_00_CONVERTE_CAPITAL_SECTION();

                    /*" -2831- END-IF */
                }


                /*" -2833- END-IF. */
            }


            /*" -2835- MOVE LK-PU-MORTE-NATURAL TO MOVIMVGA-IMP-MORNATU-ATU */
            _.Move(PARAMETROS_702.LK_PU_MORTE_NATURAL, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_MORNATU_ATU);

            /*" -2838- MOVE LK-PU-MORTE-ACIDENTAL TO MOVIMVGA-IMP-MORACID-ATU */
            _.Move(PARAMETROS_702.LK_PU_MORTE_ACIDENTAL, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_MORACID_ATU);

            /*" -2840- MOVE LK-PU-INV-PERMANENTE TO MOVIMVGA-IMP-INVPERM-ATU */
            _.Move(PARAMETROS_702.LK_PU_INV_PERMANENTE, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_INVPERM_ATU);

            /*" -2842- MOVE LK-PU-ASS-MEDICA TO MOVIMVGA-IMP-AMDS-ATU */
            _.Move(PARAMETROS_702.LK_PU_ASS_MEDICA, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_AMDS_ATU);

            /*" -2844- MOVE LK-PU-DI-HOSPITALAR TO MOVIMVGA-IMP-DH-ATU */
            _.Move(PARAMETROS_702.LK_PU_DI_HOSPITALAR, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_DH_ATU);

            /*" -2845- MOVE LK-PU-DI-INTERNACAO TO MOVIMVGA-IMP-DIT-ATU. */
            _.Move(PARAMETROS_702.LK_PU_DI_INTERNACAO, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_DIT_ATU);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2100_99_EXIT*/

        [StopWatch]
        /*" R2110-00-CALCULA-PREMIOS-SECTION */
        private void R2110_00_CALCULA_PREMIOS_SECTION()
        {
            /*" -2854- MOVE 'R2110-00-CALCULA-PREMIOS' TO PARAGRAFO. */
            _.Move("R2110-00-CALCULA-PREMIOS", FILLER_1.WABEND.PARAGRAFO);

            /*" -2855- MOVE '2110' TO WNR-EXEC-SQL. */
            _.Move("2110", FILLER_1.WABEND.WNR_EXEC_SQL);

            /*" -2857- DISPLAY PARAGRAFO */
            _.Display(FILLER_1.WABEND.PARAGRAFO);

            /*" -2858- IF (SUBGVGAP-IND-PLANO-ASSOCIA EQUAL 'S' ) */

            if ((SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_IND_PLANO_ASSOCIA == "S"))
            {

                /*" -2859- IF (SUBGVGAP-TIPO-PLANO EQUAL '1' OR '4' ) */

                if ((SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_TIPO_PLANO.In("1", "4")))
                {

                    /*" -2861- MOVE PLANOFAI-PRM-VG TO MOVIMVGA-PRM-VG-ATU */
                    _.Move(PLANOFAI.DCLPLANOS_FAIXAETA.PLANOFAI_PRM_VG, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PRM_VG_ATU);

                    /*" -2863- MOVE PLANOFAI-PRM-AP TO MOVIMVGA-PRM-AP-ATU */
                    _.Move(PLANOFAI.DCLPLANOS_FAIXAETA.PLANOFAI_PRM_AP, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PRM_AP_ATU);

                    /*" -2865- MOVE PLANOFAI-FAIXA TO MOVIMVGA-FAIXA */
                    _.Move(PLANOFAI.DCLPLANOS_FAIXAETA.PLANOFAI_FAIXA, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_FAIXA);

                    /*" -2866- ELSE */
                }
                else
                {


                    /*" -2867- IF (SUBGVGAP-TIPO-PLANO EQUAL '2' ) */

                    if ((SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_TIPO_PLANO == "2"))
                    {

                        /*" -2869- MOVE PLANFSAL-PRM-VG TO MOVIMVGA-PRM-VG-ATU */
                        _.Move(PLANFSAL.DCLPLANOS_FAIXASAL.PLANFSAL_PRM_VG, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PRM_VG_ATU);

                        /*" -2871- MOVE PLANFSAL-PRM-AP TO MOVIMVGA-PRM-AP-ATU */
                        _.Move(PLANFSAL.DCLPLANOS_FAIXASAL.PLANFSAL_PRM_AP, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PRM_AP_ATU);

                        /*" -2873- MOVE PLANFSAL-FAIXA TO MOVIMVGA-FAIXA */
                        _.Move(PLANFSAL.DCLPLANOS_FAIXASAL.PLANFSAL_FAIXA, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_FAIXA);

                        /*" -2877- ELSE */
                    }
                    else
                    {


                        /*" -2883- COMPUTE MOVIMVGA-PRM-AP-ATU = (((CONDITEC-TAXA-AP-MORACID * MOVIMVGA-IMP-MORACID-ATU) + (CONDITEC-TAXA-AP-INVPERM * MOVIMVGA-IMP-INVPERM-ATU)) / 1000) */
                        MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PRM_AP_ATU.Value = (((CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_TAXA_AP_MORACID * MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_MORACID_ATU) + (CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_TAXA_AP_INVPERM * MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_INVPERM_ATU)) / 1000f);

                        /*" -2887- COMPUTE MOVIMVGA-PRM-VG-ATU = ((FAIXASAL-TAXA-VG * MOVIMVGA-IMP-MORNATU-ATU) / 1000) */
                        MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PRM_VG_ATU.Value = ((FAIXASAL.DCLFAIXA_SALARIAL.FAIXASAL_TAXA_VG * MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_MORNATU_ATU) / 1000f);

                        /*" -2888- MOVE FAIXASAL-FAIXA TO MOVIMVGA-FAIXA */
                        _.Move(FAIXASAL.DCLFAIXA_SALARIAL.FAIXASAL_FAIXA, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_FAIXA);

                        /*" -2889- END-IF */
                    }


                    /*" -2890- END-IF */
                }


                /*" -2892- END-IF. */
            }


            /*" -2893- IF (SUBGVGAP-IND-PLANO-ASSOCIA NOT EQUAL 'S' ) */

            if ((SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_IND_PLANO_ASSOCIA != "S"))
            {

                /*" -2894- IF (SUBGVGAP-TIPO-PLANO EQUAL '1' OR '4' ) */

                if ((SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_TIPO_PLANO.In("1", "4")))
                {

                    /*" -2898- COMPUTE MOVIMVGA-PRM-VG-ATU = MOVIMVGA-IMP-MORNATU-ATU * FAIXAETA-TAXA-VG / 1000 */
                    MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PRM_VG_ATU.Value = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_MORNATU_ATU * FAIXAETA.DCLFAIXA_ETARIA.FAIXAETA_TAXA_VG / 1000f;

                    /*" -2902- COMPUTE MOVIMVGA-PRM-AP-ATU = MOVIMVGA-IMP-MORACID-ATU * CONDITEC-TAXA-AP-MORACID / 1000 */
                    MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PRM_AP_ATU.Value = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_MORACID_ATU * CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_TAXA_AP_MORACID / 1000f;

                    /*" -2907- COMPUTE MOVIMVGA-PRM-AP-ATU = MOVIMVGA-PRM-AP-ATU + (MOVIMVGA-IMP-INVPERM-ATU * CONDITEC-TAXA-AP-INVPERM / 1000) */
                    MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PRM_AP_ATU.Value = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PRM_AP_ATU + (MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_INVPERM_ATU * CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_TAXA_AP_INVPERM / 1000f);

                    /*" -2912- COMPUTE MOVIMVGA-PRM-AP-ATU = MOVIMVGA-PRM-AP-ATU + (MOVIMVGA-IMP-AMDS-ATU * CONDITEC-TAXA-AP-AMDS / 1000) */
                    MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PRM_AP_ATU.Value = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PRM_AP_ATU + (MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_AMDS_ATU * CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_TAXA_AP_AMDS / 1000f);

                    /*" -2917- COMPUTE MOVIMVGA-PRM-AP-ATU = MOVIMVGA-PRM-AP-ATU + (MOVIMVGA-IMP-DH-ATU * CONDITEC-TAXA-AP-DH / 1000) */
                    MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PRM_AP_ATU.Value = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PRM_AP_ATU + (MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_DH_ATU * CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_TAXA_AP_DH / 1000f);

                    /*" -2922- COMPUTE MOVIMVGA-PRM-AP-ATU = MOVIMVGA-PRM-AP-ATU + (MOVIMVGA-IMP-DIT-ATU * CONDITEC-TAXA-AP-DIT / 1000) */
                    MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PRM_AP_ATU.Value = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PRM_AP_ATU + (MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_DIT_ATU * CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_TAXA_AP_DIT / 1000f);

                    /*" -2923- MOVE FAIXAETA-FAIXA TO MOVIMVGA-FAIXA */
                    _.Move(FAIXAETA.DCLFAIXA_ETARIA.FAIXAETA_FAIXA, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_FAIXA);

                    /*" -2924- MOVE FAIXAETA-TAXA-VG TO MOVIMVGA-TAXA-VG */
                    _.Move(FAIXAETA.DCLFAIXA_ETARIA.FAIXAETA_TAXA_VG, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_TAXA_VG);

                    /*" -2925- ELSE */
                }
                else
                {


                    /*" -2926- IF (SUBGVGAP-TIPO-PLANO EQUAL '2' ) */

                    if ((SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_TIPO_PLANO == "2"))
                    {

                        /*" -2930- COMPUTE MOVIMVGA-PRM-VG-ATU = MOVIMVGA-IMP-MORNATU-ATU * FAIXASAL-TAXA-VG / 1000 */
                        MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PRM_VG_ATU.Value = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_MORNATU_ATU * FAIXASAL.DCLFAIXA_SALARIAL.FAIXASAL_TAXA_VG / 1000f;

                        /*" -2941- COMPUTE MOVIMVGA-PRM-AP-ATU = MOVIMVGA-IMP-MORACID-ATU * CONDITEC-TAXA-AP-MORACID / 1000 */
                        MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PRM_AP_ATU.Value = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_MORACID_ATU * CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_TAXA_AP_MORACID / 1000f;

                        /*" -2946- COMPUTE MOVIMVGA-PRM-AP-ATU = MOVIMVGA-PRM-AP-ATU + (MOVIMVGA-IMP-INVPERM-ATU * CONDITEC-TAXA-AP-INVPERM / 1000) */
                        MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PRM_AP_ATU.Value = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PRM_AP_ATU + (MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_INVPERM_ATU * CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_TAXA_AP_INVPERM / 1000f);

                        /*" -2951- COMPUTE MOVIMVGA-PRM-AP-ATU = MOVIMVGA-PRM-AP-ATU + (MOVIMVGA-IMP-AMDS-ATU * CONDITEC-TAXA-AP-AMDS / 1000) */
                        MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PRM_AP_ATU.Value = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PRM_AP_ATU + (MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_AMDS_ATU * CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_TAXA_AP_AMDS / 1000f);

                        /*" -2956- COMPUTE MOVIMVGA-PRM-AP-ATU = MOVIMVGA-PRM-AP-ATU + (MOVIMVGA-IMP-DH-ATU * CONDITEC-TAXA-AP-DH / 1000) */
                        MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PRM_AP_ATU.Value = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PRM_AP_ATU + (MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_DH_ATU * CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_TAXA_AP_DH / 1000f);

                        /*" -2961- COMPUTE MOVIMVGA-PRM-AP-ATU = MOVIMVGA-PRM-AP-ATU + (MOVIMVGA-IMP-DIT-ATU * CONDITEC-TAXA-AP-DIT / 1000) */
                        MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PRM_AP_ATU.Value = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PRM_AP_ATU + (MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_DIT_ATU * CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_TAXA_AP_DIT / 1000f);

                        /*" -2962- MOVE FAIXASAL-FAIXA TO MOVIMVGA-FAIXA */
                        _.Move(FAIXASAL.DCLFAIXA_SALARIAL.FAIXASAL_FAIXA, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_FAIXA);

                        /*" -2963- MOVE FAIXASAL-TAXA-VG TO MOVIMVGA-TAXA-VG */
                        _.Move(FAIXASAL.DCLFAIXA_SALARIAL.FAIXASAL_TAXA_VG, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_TAXA_VG);

                        /*" -2964- MOVE ZEROS TO WS-PRM-DIFERENCA */
                        _.Move(0, WS_PRM_DIFERENCA);

                        /*" -2965- IF MOVIMVGA-PRM-VG-ATU GREATER ZEROS */

                        if (MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PRM_VG_ATU > 00)
                        {

                            /*" -2968- SUBTRACT MOVIMVGA-PRM-VG-ATU FROM PREMIO-SOR GIVING WS-PRM-DIFERENCA */
                            WS_PRM_DIFERENCA.Value = REGISTRO_SORT.PREMIO_SOR - MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PRM_VG_ATU;

                            /*" -2970- IF WS-PRM-DIFERENCA LESS -0,03 OR WS-PRM-DIFERENCA GREATER +0,03 */

                            if (WS_PRM_DIFERENCA < -0.03 || WS_PRM_DIFERENCA > +0.03)
                            {

                                /*" -2971- MOVE 3027 TO COD-ERRO-SOR */
                                _.Move(3027, REGISTRO_SORT.COD_ERRO_SOR);

                                /*" -2972- PERFORM R2020-00-GRAVA-RETORNO */

                                R2020_00_GRAVA_RETORNO_SECTION();

                                /*" -2973- MOVE 'NAO' TO WS-ERRO-MOVTO */
                                _.Move("NAO", WS_ERRO_MOVTO);

                                /*" -2974- MOVE 'SIM' TO WS-ERRO-SUBGRUPO */
                                _.Move("SIM", WS_ERRO_SUBGRUPO);

                                /*" -2976- ADD 1 TO WS-QTDE-ERRO-3027 WS-QTDE-CRITIC */
                                WS_QTDE_ERRO_3027.Value = WS_QTDE_ERRO_3027 + 1;
                                WS_QTDE_CRITIC.Value = WS_QTDE_CRITIC + 1;

                                /*" -2977- ADD PREMIO-SOR TO WS-TOT-CRITIC */
                                WS_TOT_CRITIC.Value = WS_TOT_CRITIC + REGISTRO_SORT.PREMIO_SOR;

                                /*" -2978- ELSE */
                            }
                            else
                            {


                                /*" -2980- MOVE PREMIO-SOR TO MOVIMVGA-PRM-VG-ATU */
                                _.Move(REGISTRO_SORT.PREMIO_SOR, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PRM_VG_ATU);

                                /*" -2981- END-IF */
                            }


                            /*" -2982- ELSE */
                        }
                        else
                        {


                            /*" -2985- SUBTRACT MOVIMVGA-PRM-AP-ATU FROM PREMIO-SOR GIVING WS-PRM-DIFERENCA */
                            WS_PRM_DIFERENCA.Value = REGISTRO_SORT.PREMIO_SOR - MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PRM_AP_ATU;

                            /*" -2987- IF WS-PRM-DIFERENCA LESS -0,03 OR WS-PRM-DIFERENCA GREATER +0,03 */

                            if (WS_PRM_DIFERENCA < -0.03 || WS_PRM_DIFERENCA > +0.03)
                            {

                                /*" -2988- MOVE 3027 TO COD-ERRO-SOR */
                                _.Move(3027, REGISTRO_SORT.COD_ERRO_SOR);

                                /*" -2989- MOVE MOVIMVGA-PRM-AP-ATU TO PREMIO-CALC-SAI */
                                _.Move(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PRM_AP_ATU, REGISTRO_SAIDA.PREMIO_CALC_SAI);

                                /*" -2990- MOVE WS-PRM-DIFERENCA TO PREMIO-DIFE-SAI */
                                _.Move(WS_PRM_DIFERENCA, REGISTRO_SAIDA.PREMIO_DIFE_SAI);

                                /*" -2991- PERFORM R2020-00-GRAVA-RETORNO */

                                R2020_00_GRAVA_RETORNO_SECTION();

                                /*" -2992- MOVE 'NAO' TO WS-ERRO-MOVTO */
                                _.Move("NAO", WS_ERRO_MOVTO);

                                /*" -2993- MOVE 'SIM' TO WS-ERRO-SUBGRUPO */
                                _.Move("SIM", WS_ERRO_SUBGRUPO);

                                /*" -2995- ADD 1 TO WS-QTDE-ERRO-3027 WS-QTDE-CRITIC */
                                WS_QTDE_ERRO_3027.Value = WS_QTDE_ERRO_3027 + 1;
                                WS_QTDE_CRITIC.Value = WS_QTDE_CRITIC + 1;

                                /*" -2996- ADD PREMIO-SOR TO WS-TOT-CRITIC */
                                WS_TOT_CRITIC.Value = WS_TOT_CRITIC + REGISTRO_SORT.PREMIO_SOR;

                                /*" -2997- ELSE */
                            }
                            else
                            {


                                /*" -2999- MOVE PREMIO-SOR TO MOVIMVGA-PRM-AP-ATU */
                                _.Move(REGISTRO_SORT.PREMIO_SOR, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PRM_AP_ATU);

                                /*" -3000- END-IF */
                            }


                            /*" -3001- END-IF */
                        }


                        /*" -3002- ELSE */
                    }
                    else
                    {


                        /*" -3003- IF (SUBGVGAP-TIPO-PLANO EQUAL '3' ) */

                        if ((SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_TIPO_PLANO == "3"))
                        {

                            /*" -3007- COMPUTE MOVIMVGA-PRM-AP-ATU = CONDITEC-TAXA-AP-MORACID * MOVIMVGA-IMP-MORACID-ATU / 1000 */
                            MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PRM_AP_ATU.Value = CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_TAXA_AP_MORACID * MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_MORACID_ATU / 1000f;

                            /*" -3012- COMPUTE MOVIMVGA-PRM-AP-ATU = MOVIMVGA-PRM-AP-ATU + (CONDITEC-TAXA-AP-INVPERM * MOVIMVGA-IMP-INVPERM-ATU / 1000) */
                            MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PRM_AP_ATU.Value = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PRM_AP_ATU + (CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_TAXA_AP_INVPERM * MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_INVPERM_ATU / 1000f);

                            /*" -3017- COMPUTE MOVIMVGA-PRM-VG-ATU = ((FAIXASAL-TAXA-VG * MOVIMVGA-IMP-MORNATU-ATU) / 1000) */
                            MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PRM_VG_ATU.Value = ((FAIXASAL.DCLFAIXA_SALARIAL.FAIXASAL_TAXA_VG * MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_MORNATU_ATU) / 1000f);

                            /*" -3018- IF (SUBGVGAP-NUM-APOLICE EQUAL 109300000567) */

                            if ((SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_NUM_APOLICE == 109300000567))
                            {

                                /*" -3019- MOVE WTOT-PREMIO TO MOVIMVGA-PRM-VG-ATU */
                                _.Move(WTOT_PREMIO, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PRM_VG_ATU);

                                /*" -3020- END-IF */
                            }


                            /*" -3021- MOVE FAIXASAL-FAIXA TO MOVIMVGA-FAIXA */
                            _.Move(FAIXASAL.DCLFAIXA_SALARIAL.FAIXASAL_FAIXA, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_FAIXA);

                            /*" -3022- MOVE FAIXASAL-TAXA-VG TO MOVIMVGA-TAXA-VG */
                            _.Move(FAIXASAL.DCLFAIXA_SALARIAL.FAIXASAL_TAXA_VG, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_TAXA_VG);

                            /*" -3023- END-IF */
                        }


                        /*" -3024- END-IF */
                    }


                    /*" -3025- END-IF */
                }


                /*" -3027- END-IF. */
            }


            /*" -3028- IF (MOVIMVGA-PRM-VG-ATU NOT GREATER ZEROS) */

            if ((MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PRM_VG_ATU <= 00))
            {

                /*" -3029- MOVE ZEROS TO MOVIMVGA-IMP-MORNATU-ATU */
                _.Move(0, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_MORNATU_ATU);

                /*" -3031- END-IF. */
            }


            /*" -3032- IF (MOVIMVGA-PRM-AP-ATU NOT GREATER ZEROS) */

            if ((MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PRM_AP_ATU <= 00))
            {

                /*" -3034- MOVE ZEROS TO MOVIMVGA-IMP-MORACID-ATU MOVIMVGA-IMP-INVPERM-ATU */
                _.Move(0, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_MORACID_ATU, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_INVPERM_ATU);

                /*" -3034- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2110_99_EXIT*/

        [StopWatch]
        /*" R2120-00-CONVERTE-CAPITAL-SECTION */
        private void R2120_00_CONVERTE_CAPITAL_SECTION()
        {
            /*" -3043- MOVE 'R2120-00-CONVERTE-CAPITAL' TO PARAGRAFO. */
            _.Move("R2120-00-CONVERTE-CAPITAL", FILLER_1.WABEND.PARAGRAFO);

            /*" -3044- MOVE '2120' TO WNR-EXEC-SQL. */
            _.Move("2120", FILLER_1.WABEND.WNR_EXEC_SQL);

            /*" -3048- DISPLAY PARAGRAFO */
            _.Display(FILLER_1.WABEND.PARAGRAFO);

            /*" -3050- INITIALIZE PARAMETROS. */
            _.Initialize(
                PARAMETROS
            );

            /*" -3052- MOVE ZEROS TO WS-TEM-CAPITAL-PURO. */
            _.Move(0, WS_TEM_CAPITAL_PURO);

            /*" -3054- MOVE SUBGVGAP-NUM-APOLICE TO LK710-APOLICE OF PARAMETROS. */
            _.Move(SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_NUM_APOLICE, PARAMETROS.LK710_APOLICE);

            /*" -3059- MOVE SUBGVGAP-COD-SUBGRUPO TO LK710-SUBGRUPO OF PARAMETROS. */
            _.Move(SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_SUBGRUPO, PARAMETROS.LK710_SUBGRUPO);

            /*" -3062- MOVE TRANSP-IS-MORNATU TO LK710-PU-MORTE-NATURAL OF PARAMETROS. */
            _.Move(TRANSP_IS_MORNATU, PARAMETROS.LK710_PU_MORTE_NATURAL);

            /*" -3063- IF TRANSP-IS-MORNATU GREATER THAN ZEROS */

            if (TRANSP_IS_MORNATU > 00)
            {

                /*" -3064- ADD 1 TO WS-TEM-CAPITAL-PURO */
                WS_TEM_CAPITAL_PURO.Value = WS_TEM_CAPITAL_PURO + 1;

                /*" -3066- END-IF. */
            }


            /*" -3068- IF APOLICES-RAMO-EMISSOR EQUAL 81 OR 82 OR 97 OR PARAMRAM-RAMO-AP */

            if (APOLICES.DCLAPOLICES.APOLICES_RAMO_EMISSOR.In("81", "82", "97", PARAMRAM.DCLPARAMETROS_RAMOS.PARAMRAM_RAMO_AP.ToString()))
            {

                /*" -3071- MOVE TRANSP-IS-MORACID TO LK710-PU-MORTE-ACIDENTAL OF PARAMETROS */
                _.Move(TRANSP_IS_MORACID, PARAMETROS.LK710_PU_MORTE_ACIDENTAL);

                /*" -3072- IF TRANSP-IS-MORACID GREATER THAN ZERO */

                if (TRANSP_IS_MORACID > 00)
                {

                    /*" -3073- ADD 1 TO WS-TEM-CAPITAL-PURO */
                    WS_TEM_CAPITAL_PURO.Value = WS_TEM_CAPITAL_PURO + 1;

                    /*" -3075- END-IF */
                }


                /*" -3078- MOVE TRANSP-IS-INVPERM TO LK710-PU-INV-PERMANENTE OF PARAMETROS */
                _.Move(TRANSP_IS_INVPERM, PARAMETROS.LK710_PU_INV_PERMANENTE);

                /*" -3079- IF TRANSP-IS-INVPERM GREATER THAN ZERO */

                if (TRANSP_IS_INVPERM > 00)
                {

                    /*" -3080- ADD 1 TO WS-TEM-CAPITAL-PURO */
                    WS_TEM_CAPITAL_PURO.Value = WS_TEM_CAPITAL_PURO + 1;

                    /*" -3082- END-IF */
                }


                /*" -3085- MOVE TRANSP-IS-AMDS TO LK710-PU-ASS-MEDICA OF PARAMETROS */
                _.Move(TRANSP_IS_AMDS, PARAMETROS.LK710_PU_ASS_MEDICA);

                /*" -3086- IF TRANSP-IS-AMDS GREATER THAN ZERO */

                if (TRANSP_IS_AMDS > 00)
                {

                    /*" -3087- ADD 1 TO WS-TEM-CAPITAL-PURO */
                    WS_TEM_CAPITAL_PURO.Value = WS_TEM_CAPITAL_PURO + 1;

                    /*" -3089- END-IF */
                }


                /*" -3092- MOVE TRANSP-IS-DH TO LK710-PU-DI-HOSPITALAR OF PARAMETROS */
                _.Move(TRANSP_IS_DH, PARAMETROS.LK710_PU_DI_HOSPITALAR);

                /*" -3093- IF TRANSP-IS-DH GREATER THAN ZERO */

                if (TRANSP_IS_DH > 00)
                {

                    /*" -3094- ADD 1 TO WS-TEM-CAPITAL-PURO */
                    WS_TEM_CAPITAL_PURO.Value = WS_TEM_CAPITAL_PURO + 1;

                    /*" -3096- END-IF */
                }


                /*" -3099- MOVE TRANSP-IS-DIT TO LK710-PU-DI-INTERNACAO OF PARAMETROS */
                _.Move(TRANSP_IS_DIT, PARAMETROS.LK710_PU_DI_INTERNACAO);

                /*" -3100- IF TRANSP-IS-DIT GREATER THAN ZERO */

                if (TRANSP_IS_DIT > 00)
                {

                    /*" -3101- ADD 1 TO WS-TEM-CAPITAL-PURO */
                    WS_TEM_CAPITAL_PURO.Value = WS_TEM_CAPITAL_PURO + 1;

                    /*" -3102- END-IF */
                }


                /*" -3118- END-IF. */
            }


            /*" -3120- CALL 'VG0710S' USING PARAMETROS. */
            _.Call("VG0710S", PARAMETROS);

            /*" -3121- IF LK710-RETURN-CODE NOT EQUAL ZEROS */

            if (PARAMETROS.LK710_RETURN_CODE != 00)
            {

                /*" -3122- DISPLAY '** PROBLEMA COM SUBROTINA VG0710S **' */
                _.Display($"** PROBLEMA COM SUBROTINA VG0710S **");

                /*" -3123- DISPLAY 'APOLICE : ' SUBGVGAP-NUM-APOLICE */
                _.Display($"APOLICE : {SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_NUM_APOLICE}");

                /*" -3124- DISPLAY 'SUBGRUPO: ' SUBGVGAP-COD-SUBGRUPO */
                _.Display($"SUBGRUPO: {SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_SUBGRUPO}");

                /*" -3125- DISPLAY 'CERTIF. : ' SEGURVGA-NUM-CERTIFICADO */
                _.Display($"CERTIF. : {SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_CERTIFICADO}");

                /*" -3126- DISPLAY 'MENSAGEM DA VG0710S -> ' LK710-MENSAGEM */
                _.Display($"MENSAGEM DA VG0710S -> {PARAMETROS.LK710_MENSAGEM}");

                /*" -3128- DISPLAY 'COD.ERRO DA VG0710S -> ' LK710-RETURN-CODE */
                _.Display($"COD.ERRO DA VG0710S -> {PARAMETROS.LK710_RETURN_CODE}");

                /*" -3130- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3132- INITIALIZE PARAMETROS-702. */
            _.Initialize(
                PARAMETROS_702
            );

            /*" -3134- MOVE SUBGVGAP-NUM-APOLICE TO LK-APOLICE. */
            _.Move(SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_NUM_APOLICE, PARAMETROS_702.LK_APOLICE);

            /*" -3137- MOVE SUBGVGAP-COD-SUBGRUPO TO LK-SUBGRUPO. */
            _.Move(SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_SUBGRUPO, PARAMETROS_702.LK_SUBGRUPO);

            /*" -3139- MOVE LK710-CO-MORTE-NATURAL TO LK-CO-MORTE-NATURAL */
            _.Move(PARAMETROS.LK710_CO_MORTE_NATURAL, PARAMETROS_702.LK_CO_MORTE_NATURAL);

            /*" -3141- MOVE LK710-CO-MORTE-ACIDENTAL TO LK-CO-MORTE-ACIDENTAL */
            _.Move(PARAMETROS.LK710_CO_MORTE_ACIDENTAL, PARAMETROS_702.LK_CO_MORTE_ACIDENTAL);

            /*" -3143- MOVE LK710-CO-INV-PERMANENTE TO LK-CO-INV-PERMANENTE */
            _.Move(PARAMETROS.LK710_CO_INV_PERMANENTE, PARAMETROS_702.LK_CO_INV_PERMANENTE);

            /*" -3145- MOVE LK710-CO-ASS-MEDICA TO LK-CO-ASS-MEDICA */
            _.Move(PARAMETROS.LK710_CO_ASS_MEDICA, PARAMETROS_702.LK_CO_ASS_MEDICA);

            /*" -3147- MOVE LK710-CO-DI-HOSPITALAR TO LK-CO-DI-HOSPITALAR */
            _.Move(PARAMETROS.LK710_CO_DI_HOSPITALAR, PARAMETROS_702.LK_CO_DI_HOSPITALAR);

            /*" -3157- MOVE LK710-CO-DI-INTERNACAO TO LK-CO-DI-INTERNACAO */
            _.Move(PARAMETROS.LK710_CO_DI_INTERNACAO, PARAMETROS_702.LK_CO_DI_INTERNACAO);

            /*" -3159- CALL 'VG0702S' USING PARAMETROS-702. */
            _.Call("VG0702S", PARAMETROS_702);

            /*" -3160- IF LK-RETURN-CODE NOT EQUAL ZEROS */

            if (PARAMETROS_702.LK_RETURN_CODE != 00)
            {

                /*" -3161- DISPLAY '** PROBLEMA COM SUBROTINA VG0702S **' */
                _.Display($"** PROBLEMA COM SUBROTINA VG0702S **");

                /*" -3162- DISPLAY 'APOLICE : ' SUBGVGAP-NUM-APOLICE */
                _.Display($"APOLICE : {SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_NUM_APOLICE}");

                /*" -3163- DISPLAY 'SUBGRUPO: ' SUBGVGAP-COD-SUBGRUPO */
                _.Display($"SUBGRUPO: {SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_SUBGRUPO}");

                /*" -3164- DISPLAY 'CERTIF. : ' SEGURVGA-NUM-CERTIFICADO */
                _.Display($"CERTIF. : {SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_CERTIFICADO}");

                /*" -3165- DISPLAY 'MENSAGEM DA VG0702S -> ' LK-MENSAGEM */
                _.Display($"MENSAGEM DA VG0702S -> {PARAMETROS_702.LK_MENSAGEM}");

                /*" -3167- DISPLAY 'COD.ERRO DA VG0702S -> ' LK-RETURN-CODE */
                _.Display($"COD.ERRO DA VG0702S -> {PARAMETROS_702.LK_RETURN_CODE}");

                /*" -3167- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2120_99_EXIT*/

        [StopWatch]
        /*" R2130-00-PROCESSA-PLANO-ZERO-SECTION */
        private void R2130_00_PROCESSA_PLANO_ZERO_SECTION()
        {
            /*" -3176- MOVE 'R2130-00-PROCESSA-PLANO-ZERO' TO PARAGRAFO. */
            _.Move("R2130-00-PROCESSA-PLANO-ZERO", FILLER_1.WABEND.PARAGRAFO);

            /*" -3177- MOVE '2130' TO WNR-EXEC-SQL. */
            _.Move("2130", FILLER_1.WABEND.WNR_EXEC_SQL);

            /*" -3181- DISPLAY PARAGRAFO */
            _.Display(FILLER_1.WABEND.PARAGRAFO);

            /*" -3182- MOVE SUBGVGAP-NUM-APOLICE TO LK710-APOLICE */
            _.Move(SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_NUM_APOLICE, PARAMETROS.LK710_APOLICE);

            /*" -3183- MOVE SUBGVGAP-COD-SUBGRUPO TO LK710-SUBGRUPO */
            _.Move(SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_SUBGRUPO, PARAMETROS.LK710_SUBGRUPO);

            /*" -3184- MOVE ZEROS TO LK710-IDADE */
            _.Move(0, PARAMETROS.LK710_IDADE);

            /*" -3185- MOVE ZEROS TO LK710-NASCIMENTO */
            _.Move(0, PARAMETROS.LK710_NASCIMENTO);

            /*" -3186- MOVE ZEROS TO LK710-SALARIO */
            _.Move(0, PARAMETROS.LK710_SALARIO);

            /*" -3187- MOVE ZEROS TO LK710-PU-MORTE-NATURAL */
            _.Move(0, PARAMETROS.LK710_PU_MORTE_NATURAL);

            /*" -3188- MOVE ZEROS TO LK710-PU-MORTE-ACIDENTAL */
            _.Move(0, PARAMETROS.LK710_PU_MORTE_ACIDENTAL);

            /*" -3189- MOVE ZEROS TO LK710-PU-INV-PERMANENTE */
            _.Move(0, PARAMETROS.LK710_PU_INV_PERMANENTE);

            /*" -3190- MOVE ZEROS TO LK710-PU-ASS-MEDICA */
            _.Move(0, PARAMETROS.LK710_PU_ASS_MEDICA);

            /*" -3191- MOVE ZEROS TO LK710-PU-DI-HOSPITALAR */
            _.Move(0, PARAMETROS.LK710_PU_DI_HOSPITALAR);

            /*" -3192- MOVE ZEROS TO LK710-PU-DI-INTERNACAO. */
            _.Move(0, PARAMETROS.LK710_PU_DI_INTERNACAO);

            /*" -3193- MOVE ZEROS TO LK710-CO-MORTE-NATURAL */
            _.Move(0, PARAMETROS.LK710_CO_MORTE_NATURAL);

            /*" -3194- MOVE ZEROS TO LK710-CO-MORTE-ACIDENTAL */
            _.Move(0, PARAMETROS.LK710_CO_MORTE_ACIDENTAL);

            /*" -3195- MOVE ZEROS TO LK710-CO-INV-PERMANENTE */
            _.Move(0, PARAMETROS.LK710_CO_INV_PERMANENTE);

            /*" -3196- MOVE ZEROS TO LK710-CO-INV-POR-ACIDENTE */
            _.Move(0, PARAMETROS.LK710_CO_INV_POR_ACIDENTE);

            /*" -3197- MOVE ZEROS TO LK710-CO-ASS-MEDICA */
            _.Move(0, PARAMETROS.LK710_CO_ASS_MEDICA);

            /*" -3198- MOVE ZEROS TO LK710-CO-DI-HOSPITALAR */
            _.Move(0, PARAMETROS.LK710_CO_DI_HOSPITALAR);

            /*" -3199- MOVE ZEROS TO LK710-CO-DI-INTERNACAO */
            _.Move(0, PARAMETROS.LK710_CO_DI_INTERNACAO);

            /*" -3200- MOVE ZEROS TO LK710-PREM-MORTE-NATURAL. */
            _.Move(0, PARAMETROS.LK710_PREM_MORTE_NATURAL);

            /*" -3201- MOVE ZEROS TO LK710-PREM-ACIDENTES-PESSOAIS. */
            _.Move(0, PARAMETROS.LK710_PREM_ACIDENTES_PESSOAIS);

            /*" -3202- MOVE ZEROS TO LK710-PREM-TOTAL. */
            _.Move(0, PARAMETROS.LK710_PREM_TOTAL);

            /*" -3203- MOVE ZEROS TO LK710-RETURN-CODE. */
            _.Move(0, PARAMETROS.LK710_RETURN_CODE);

            /*" -3205- MOVE SPACES TO LK710-MENSAGEM. */
            _.Move("", PARAMETROS.LK710_MENSAGEM);

            /*" -3206- MOVE PLANOVGA-IMP-MORNATU TO LK710-CO-MORTE-NATURAL. */
            _.Move(PLANOVGA.DCLPLANOS_VGAP.PLANOVGA_IMP_MORNATU, PARAMETROS.LK710_CO_MORTE_NATURAL);

            /*" -3207- MOVE PLANOVGA-IMP-MORACID TO LK710-CO-MORTE-ACIDENTAL. */
            _.Move(PLANOVGA.DCLPLANOS_VGAP.PLANOVGA_IMP_MORACID, PARAMETROS.LK710_CO_MORTE_ACIDENTAL);

            /*" -3208- MOVE PLANOVGA-IMP-INVPERM TO LK710-CO-INV-PERMANENTE. */
            _.Move(PLANOVGA.DCLPLANOS_VGAP.PLANOVGA_IMP_INVPERM, PARAMETROS.LK710_CO_INV_PERMANENTE);

            /*" -3209- MOVE PLANOVGA-IMP-AMDS TO LK710-CO-ASS-MEDICA. */
            _.Move(PLANOVGA.DCLPLANOS_VGAP.PLANOVGA_IMP_AMDS, PARAMETROS.LK710_CO_ASS_MEDICA);

            /*" -3210- MOVE PLANOVGA-IMP-DH TO LK710-CO-DI-HOSPITALAR. */
            _.Move(PLANOVGA.DCLPLANOS_VGAP.PLANOVGA_IMP_DH, PARAMETROS.LK710_CO_DI_HOSPITALAR);

            /*" -3221- MOVE PLANOVGA-IMP-DIT TO LK710-CO-DI-INTERNACAO. */
            _.Move(PLANOVGA.DCLPLANOS_VGAP.PLANOVGA_IMP_DIT, PARAMETROS.LK710_CO_DI_INTERNACAO);

            /*" -3223- CALL 'VG0702S' USING PARAMETROS. */
            _.Call("VG0702S", PARAMETROS);

            /*" -3224- IF LK710-RETURN-CODE NOT EQUAL ZEROS */

            if (PARAMETROS.LK710_RETURN_CODE != 00)
            {

                /*" -3225- DISPLAY 'ERRO SUBROTINA VG0702S ' */
                _.Display($"ERRO SUBROTINA VG0702S ");

                /*" -3226- DISPLAY 'MENSAGEM ' LK710-MENSAGEM */
                _.Display($"MENSAGEM {PARAMETROS.LK710_MENSAGEM}");

                /*" -3227- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -3239- END-IF */
            }


            /*" -3240- MOVE ZEROS TO LK710-CO-MORTE-NATURAL */
            _.Move(0, PARAMETROS.LK710_CO_MORTE_NATURAL);

            /*" -3241- MOVE ZEROS TO LK710-CO-MORTE-ACIDENTAL */
            _.Move(0, PARAMETROS.LK710_CO_MORTE_ACIDENTAL);

            /*" -3242- MOVE ZEROS TO LK710-CO-INV-PERMANENTE */
            _.Move(0, PARAMETROS.LK710_CO_INV_PERMANENTE);

            /*" -3243- MOVE ZEROS TO LK710-CO-INV-POR-ACIDENTE */
            _.Move(0, PARAMETROS.LK710_CO_INV_POR_ACIDENTE);

            /*" -3244- MOVE ZEROS TO LK710-CO-ASS-MEDICA */
            _.Move(0, PARAMETROS.LK710_CO_ASS_MEDICA);

            /*" -3245- MOVE ZEROS TO LK710-CO-DI-HOSPITALAR */
            _.Move(0, PARAMETROS.LK710_CO_DI_HOSPITALAR);

            /*" -3247- MOVE ZEROS TO LK710-CO-DI-INTERNACAO. */
            _.Move(0, PARAMETROS.LK710_CO_DI_INTERNACAO);

            /*" -3248- IF LK710-PU-MORTE-NATURAL GREATER ZEROS */

            if (PARAMETROS.LK710_PU_MORTE_NATURAL > 00)
            {

                /*" -3249- MOVE IS-SOR TO LK710-PU-MORTE-NATURAL */
                _.Move(REGISTRO_SORT.IS_SOR, PARAMETROS.LK710_PU_MORTE_NATURAL);

                /*" -3251- END-IF. */
            }


            /*" -3252- IF LK710-PU-MORTE-ACIDENTAL GREATER ZEROS */

            if (PARAMETROS.LK710_PU_MORTE_ACIDENTAL > 00)
            {

                /*" -3253- MOVE IS-SOR TO LK710-PU-MORTE-ACIDENTAL */
                _.Move(REGISTRO_SORT.IS_SOR, PARAMETROS.LK710_PU_MORTE_ACIDENTAL);

                /*" -3255- END-IF. */
            }


            /*" -3256- IF LK710-PU-INV-PERMANENTE GREATER ZEROS */

            if (PARAMETROS.LK710_PU_INV_PERMANENTE > 00)
            {

                /*" -3257- MOVE IS-SOR TO LK710-PU-INV-PERMANENTE */
                _.Move(REGISTRO_SORT.IS_SOR, PARAMETROS.LK710_PU_INV_PERMANENTE);

                /*" -3262- END-IF. */
            }


            /*" -3264- CALL 'VG0710S' USING PARAMETROS. */
            _.Call("VG0710S", PARAMETROS);

            /*" -3265- IF (LK710-RETURN-CODE NOT EQUAL ZEROS) */

            if ((PARAMETROS.LK710_RETURN_CODE != 00))
            {

                /*" -3266- DISPLAY 'ERRO SUBROTINA VG0710S ' */
                _.Display($"ERRO SUBROTINA VG0710S ");

                /*" -3268- DISPLAY 'LK710-RETURN-CODE (APOS SUBROT)=>' LK710-RETURN-CODE */
                _.Display($"LK710-RETURN-CODE (APOS SUBROT)=>{PARAMETROS.LK710_RETURN_CODE}");

                /*" -3269- MOVE LK710-RETURN-CODE TO SQLCODE */
                _.Move(PARAMETROS.LK710_RETURN_CODE, DB.SQLCODE);

                /*" -3270- DISPLAY 'MENSAGEM ' LK710-MENSAGEM */
                _.Display($"MENSAGEM {PARAMETROS.LK710_MENSAGEM}");

                /*" -3271- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -3274- END-IF. */
            }


            /*" -3275- MOVE LK710-CO-MORTE-NATURAL TO TRANSP-IS-MORNATU */
            _.Move(PARAMETROS.LK710_CO_MORTE_NATURAL, TRANSP_IS_MORNATU);

            /*" -3276- MOVE LK710-CO-MORTE-ACIDENTAL TO TRANSP-IS-MORACID */
            _.Move(PARAMETROS.LK710_CO_MORTE_ACIDENTAL, TRANSP_IS_MORACID);

            /*" -3277- MOVE LK710-CO-INV-PERMANENTE TO TRANSP-IS-INVPERM */
            _.Move(PARAMETROS.LK710_CO_INV_PERMANENTE, TRANSP_IS_INVPERM);

            /*" -3278- MOVE LK710-CO-ASS-MEDICA TO TRANSP-IS-AMDS */
            _.Move(PARAMETROS.LK710_CO_ASS_MEDICA, TRANSP_IS_AMDS);

            /*" -3279- MOVE LK710-CO-DI-HOSPITALAR TO TRANSP-IS-DH */
            _.Move(PARAMETROS.LK710_CO_DI_HOSPITALAR, TRANSP_IS_DH);

            /*" -3280- MOVE LK710-CO-DI-INTERNACAO TO TRANSP-IS-DIT */
            _.Move(PARAMETROS.LK710_CO_DI_INTERNACAO, TRANSP_IS_DIT);

            /*" -3280- MOVE PREMIO-SOR TO WTOT-PREMIO. */
            _.Move(REGISTRO_SORT.PREMIO_SOR, WTOT_PREMIO);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2130_99_SAIDA*/

        [StopWatch]
        /*" R2140-00-MULTIPLO-SALARIAL-SECTION */
        private void R2140_00_MULTIPLO_SALARIAL_SECTION()
        {
            /*" -3297- MOVE 'R2140-00-MULTIPLO-SALARIAL' TO PARAGRAFO. */
            _.Move("R2140-00-MULTIPLO-SALARIAL", FILLER_1.WABEND.PARAGRAFO);

            /*" -3298- MOVE '2140' TO WNR-EXEC-SQL. */
            _.Move("2140", FILLER_1.WABEND.WNR_EXEC_SQL);

            /*" -3302- DISPLAY PARAGRAFO */
            _.Display(FILLER_1.WABEND.PARAGRAFO);

            /*" -3306- COMPUTE MOVIMVGA-IMP-MORNATU-ATU = PLANOMUL-QTD-SAL-MORNATU * SALARIO-SOR. */
            MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_MORNATU_ATU.Value = PLANOMUL.DCLPLANOS_MULTISAL.PLANOMUL_QTD_SAL_MORNATU * REGISTRO_SORT.SALARIO_SOR;

            /*" -3308- IF MOVIMVGA-IMP-MORNATU-ATU > PLANOMUL-LIM-CAP-MORNATU */

            if (MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_MORNATU_ATU > PLANOMUL.DCLPLANOS_MULTISAL.PLANOMUL_LIM_CAP_MORNATU)
            {

                /*" -3311- MOVE PLANOMUL-LIM-CAP-MORNATU TO MOVIMVGA-IMP-MORNATU-ATU. */
                _.Move(PLANOMUL.DCLPLANOS_MULTISAL.PLANOMUL_LIM_CAP_MORNATU, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_MORNATU_ATU);
            }


            /*" -3313- MOVE MOVIMVGA-IMP-MORNATU-ATU TO TRANSP-IS-MORNATU. */
            _.Move(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_MORNATU_ATU, TRANSP_IS_MORNATU);

            /*" -3317- COMPUTE MOVIMVGA-IMP-MORACID-ATU = PLANOMUL-QTD-SAL-MORACID * SALARIO-SOR. */
            MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_MORACID_ATU.Value = PLANOMUL.DCLPLANOS_MULTISAL.PLANOMUL_QTD_SAL_MORACID * REGISTRO_SORT.SALARIO_SOR;

            /*" -3319- IF MOVIMVGA-IMP-MORACID-ATU > PLANOMUL-LIM-CAP-MORACID */

            if (MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_MORACID_ATU > PLANOMUL.DCLPLANOS_MULTISAL.PLANOMUL_LIM_CAP_MORACID)
            {

                /*" -3322- MOVE PLANOMUL-LIM-CAP-MORACID TO MOVIMVGA-IMP-MORACID-ATU. */
                _.Move(PLANOMUL.DCLPLANOS_MULTISAL.PLANOMUL_LIM_CAP_MORACID, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_MORACID_ATU);
            }


            /*" -3325- MOVE MOVIMVGA-IMP-MORACID-ATU TO TRANSP-IS-MORACID. */
            _.Move(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_MORACID_ATU, TRANSP_IS_MORACID);

            /*" -3329- COMPUTE MOVIMVGA-IMP-INVPERM-ATU = PLANOMUL-QTD-SAL-INVPERM * SALARIO-SOR. */
            MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_INVPERM_ATU.Value = PLANOMUL.DCLPLANOS_MULTISAL.PLANOMUL_QTD_SAL_INVPERM * REGISTRO_SORT.SALARIO_SOR;

            /*" -3331- IF MOVIMVGA-IMP-INVPERM-ATU > PLANOMUL-LIM-CAP-INVAPER */

            if (MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_INVPERM_ATU > PLANOMUL.DCLPLANOS_MULTISAL.PLANOMUL_LIM_CAP_INVAPER)
            {

                /*" -3334- MOVE PLANOMUL-LIM-CAP-INVAPER TO MOVIMVGA-IMP-INVPERM-ATU. */
                _.Move(PLANOMUL.DCLPLANOS_MULTISAL.PLANOMUL_LIM_CAP_INVAPER, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_INVPERM_ATU);
            }


            /*" -3335- MOVE MOVIMVGA-IMP-INVPERM-ATU TO TRANSP-IS-INVPERM. */
            _.Move(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_INVPERM_ATU, TRANSP_IS_INVPERM);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2140_99_EXIT*/

        [StopWatch]
        /*" R2150-00-MULTIPLO-SALARIAL-SECTION */
        private void R2150_00_MULTIPLO_SALARIAL_SECTION()
        {
            /*" -3344- MOVE 'R2150-00-MULTIPLO-SALARIAL' TO PARAGRAFO. */
            _.Move("R2150-00-MULTIPLO-SALARIAL", FILLER_1.WABEND.PARAGRAFO);

            /*" -3345- MOVE '2150' TO WNR-EXEC-SQL. */
            _.Move("2150", FILLER_1.WABEND.WNR_EXEC_SQL);

            /*" -3349- DISPLAY PARAGRAFO */
            _.Display(FILLER_1.WABEND.PARAGRAFO);

            /*" -3353- COMPUTE MOVIMVGA-IMP-MORNATU-ATU = CONDITEC-QTD-SAL-MORNATU * SALARIO-SOR. */
            MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_MORNATU_ATU.Value = CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_QTD_SAL_MORNATU * REGISTRO_SORT.SALARIO_SOR;

            /*" -3355- IF MOVIMVGA-IMP-MORNATU-ATU > CONDITEC-LIM-CAP-MORNATU */

            if (MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_MORNATU_ATU > CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_LIM_CAP_MORNATU)
            {

                /*" -3358- MOVE CONDITEC-LIM-CAP-MORNATU TO MOVIMVGA-IMP-MORNATU-ATU. */
                _.Move(CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_LIM_CAP_MORNATU, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_MORNATU_ATU);
            }


            /*" -3361- MOVE MOVIMVGA-IMP-MORNATU-ATU TO TRANSP-IS-MORNATU. */
            _.Move(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_MORNATU_ATU, TRANSP_IS_MORNATU);

            /*" -3365- COMPUTE MOVIMVGA-IMP-MORACID-ATU = CONDITEC-QTD-SAL-MORACID * SALARIO-SOR. */
            MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_MORACID_ATU.Value = CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_QTD_SAL_MORACID * REGISTRO_SORT.SALARIO_SOR;

            /*" -3367- IF MOVIMVGA-IMP-MORACID-ATU > CONDITEC-LIM-CAP-MORACID */

            if (MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_MORACID_ATU > CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_LIM_CAP_MORACID)
            {

                /*" -3370- MOVE CONDITEC-LIM-CAP-MORACID TO MOVIMVGA-IMP-MORACID-ATU. */
                _.Move(CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_LIM_CAP_MORACID, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_MORACID_ATU);
            }


            /*" -3373- MOVE MOVIMVGA-IMP-MORACID-ATU TO TRANSP-IS-MORACID. */
            _.Move(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_MORACID_ATU, TRANSP_IS_MORACID);

            /*" -3377- COMPUTE MOVIMVGA-IMP-INVPERM-ATU = CONDITEC-QTD-SAL-INVPERM * SALARIO-SOR. */
            MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_INVPERM_ATU.Value = CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_QTD_SAL_INVPERM * REGISTRO_SORT.SALARIO_SOR;

            /*" -3379- IF MOVIMVGA-IMP-INVPERM-ATU > CONDITEC-LIM-CAP-INVAPER */

            if (MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_INVPERM_ATU > CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_LIM_CAP_INVAPER)
            {

                /*" -3382- MOVE CONDITEC-LIM-CAP-INVAPER TO MOVIMVGA-IMP-INVPERM-ATU. */
                _.Move(CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_LIM_CAP_INVAPER, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_INVPERM_ATU);
            }


            /*" -3383- MOVE MOVIMVGA-IMP-INVPERM-ATU TO TRANSP-IS-INVPERM. */
            _.Move(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_INVPERM_ATU, TRANSP_IS_INVPERM);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2150_99_EXIT*/

        [StopWatch]
        /*" R2160-00-SELECT-PRODUTOSVG-SECTION */
        private void R2160_00_SELECT_PRODUTOSVG_SECTION()
        {
            /*" -3392- MOVE 'R2160-00-SELECT-PRODUTOSVG' TO PARAGRAFO. */
            _.Move("R2160-00-SELECT-PRODUTOSVG", FILLER_1.WABEND.PARAGRAFO);

            /*" -3393- MOVE '2160' TO WNR-EXEC-SQL. */
            _.Move("2160", FILLER_1.WABEND.WNR_EXEC_SQL);

            /*" -3395- DISPLAY PARAGRAFO */
            _.Display(FILLER_1.WABEND.PARAGRAFO);

            /*" -3397- MOVE WS-APOLICE-ATU TO PRODUVG-NUM-APOLICE */
            _.Move(WS_CHAVE_ATU.WS_APOLICE_ATU, PRODUVG.DCLPRODUTOS_VG.PRODUVG_NUM_APOLICE);

            /*" -3399- MOVE WS-SUBGRUPO-ATU TO PRODUVG-COD-SUBGRUPO */
            _.Move(WS_CHAVE_ATU.WS_SUBGRUPO_ATU, PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_SUBGRUPO);

            /*" -3403- MOVE 'NAO' TO WTEM-EMPRES */
            _.Move("NAO", FILLER_1.FILLER_15.WTEM_EMPRES);

            /*" -3404- MOVE 16 TO W01-I */
            _.Move(16, FILLER_0.W01_I);

            /*" -3405- MOVE 'R2160-SELECT PRODUVG   ' TO W01-TEXTO(W01-I) */
            _.Move("R2160-SELECT PRODUVG   ", FILLER_0.W01_TABELA_TEXTO.W01_TAB_TEXTO[FILLER_0.W01_I].W01_TEXTO);

            /*" -3409- PERFORM R8900-TOTALIZA-INICIO THRU R8900-TOTALIZA-INICIO-EXIT */

            R8900_TOTALIZA_INICIO_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8900_TOTALIZA_INICIO_EXIT*/


            /*" -3416- PERFORM R2160_00_SELECT_PRODUTOSVG_DB_SELECT_1 */

            R2160_00_SELECT_PRODUTOSVG_DB_SELECT_1();

            /*" -3420- MOVE 1 TO W01-QTD-ACC-OK */
            _.Move(1, FILLER_0.W01_QTD_ACC_OK);

            /*" -3424- PERFORM R8910-TOTALIZA-FINAL THRU R8910-TOTALIZA-FINAL-EXIT */

            R8910_TOTALIZA_FINAL_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8910_TOTALIZA_FINAL_EXIT*/


            /*" -3425- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3427- IF SQLCODE EQUAL 100 NEXT SENTENCE */

                if (DB.SQLCODE == 100)
                {

                    /*" -3428- ELSE */
                }
                else
                {


                    /*" -3429- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -3430- END-IF */
                }


                /*" -3431- ELSE */
            }
            else
            {


                /*" -3432- IF PRODUVG-ORIG-PRODU EQUAL 'EMPRE' OR 'GLOBAL' */

                if (PRODUVG.DCLPRODUTOS_VG.PRODUVG_ORIG_PRODU.In("EMPRE", "GLOBAL"))
                {

                    /*" -3433- MOVE 'SIM' TO WTEM-EMPRES */
                    _.Move("SIM", FILLER_1.FILLER_15.WTEM_EMPRES);

                    /*" -3434- END-IF */
                }


                /*" -3435- END-IF. */
            }


        }

        [StopWatch]
        /*" R2160-00-SELECT-PRODUTOSVG-DB-SELECT-1 */
        public void R2160_00_SELECT_PRODUTOSVG_DB_SELECT_1()
        {
            /*" -3416- EXEC SQL SELECT VALUE(ORIG_PRODU, ' ' ) INTO :PRODUVG-ORIG-PRODU FROM SEGUROS.PRODUTOS_VG WHERE NUM_APOLICE = :PRODUVG-NUM-APOLICE AND COD_SUBGRUPO = :PRODUVG-COD-SUBGRUPO WITH UR END-EXEC. */

            var r2160_00_SELECT_PRODUTOSVG_DB_SELECT_1_Query1 = new R2160_00_SELECT_PRODUTOSVG_DB_SELECT_1_Query1()
            {
                PRODUVG_COD_SUBGRUPO = PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_SUBGRUPO.ToString(),
                PRODUVG_NUM_APOLICE = PRODUVG.DCLPRODUTOS_VG.PRODUVG_NUM_APOLICE.ToString(),
            };

            var executed_1 = R2160_00_SELECT_PRODUTOSVG_DB_SELECT_1_Query1.Execute(r2160_00_SELECT_PRODUTOSVG_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PRODUVG_ORIG_PRODU, PRODUVG.DCLPRODUTOS_VG.PRODUVG_ORIG_PRODU);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2160_99_SAIDA*/

        [StopWatch]
        /*" R2200-00-SELECT-SEGURVGA-SECTION */
        private void R2200_00_SELECT_SEGURVGA_SECTION()
        {
            /*" -3443- MOVE 'R2200-00-SELECT-SEGURVGA' TO PARAGRAFO. */
            _.Move("R2200-00-SELECT-SEGURVGA", FILLER_1.WABEND.PARAGRAFO);

            /*" -3444- MOVE '2200' TO WNR-EXEC-SQL. */
            _.Move("2200", FILLER_1.WABEND.WNR_EXEC_SQL);

            /*" -3446- DISPLAY PARAGRAFO */
            _.Display(FILLER_1.WABEND.PARAGRAFO);

            /*" -3449- MOVE SUBGRUPO-SOR TO SEGURVGA-COD-SUBGRUPO. */
            _.Move(REGISTRO_SORT.SUBGRUPO_SOR, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_SUBGRUPO);

            /*" -3452- MOVE 'SIM' TO WTEM-SEGURVGA. */
            _.Move("SIM", FILLER_1.FILLER_15.WTEM_SEGURVGA);

            /*" -3453- MOVE 17 TO W01-I */
            _.Move(17, FILLER_0.W01_I);

            /*" -3454- MOVE 'R2200-DECLAR SEGURVGA  ' TO W01-TEXTO(W01-I) */
            _.Move("R2200-DECLAR SEGURVGA  ", FILLER_0.W01_TABELA_TEXTO.W01_TAB_TEXTO[FILLER_0.W01_I].W01_TEXTO);

            /*" -3458- PERFORM R8900-TOTALIZA-INICIO THRU R8900-TOTALIZA-INICIO-EXIT */

            R8900_TOTALIZA_INICIO_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8900_TOTALIZA_INICIO_EXIT*/


            /*" -3482- PERFORM R2200_00_SELECT_SEGURVGA_DB_DECLARE_1 */

            R2200_00_SELECT_SEGURVGA_DB_DECLARE_1();

            /*" -3484- PERFORM R2200_00_SELECT_SEGURVGA_DB_OPEN_1 */

            R2200_00_SELECT_SEGURVGA_DB_OPEN_1();

            /*" -3488- MOVE 1 TO W01-QTD-ACC-OK */
            _.Move(1, FILLER_0.W01_QTD_ACC_OK);

            /*" -3492- PERFORM R8910-TOTALIZA-FINAL THRU R8910-TOTALIZA-FINAL-EXIT */

            R8910_TOTALIZA_FINAL_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8910_TOTALIZA_FINAL_EXIT*/


            /*" -3493- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3494- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -3497- END-IF. */
            }


            /*" -3498- MOVE 18 TO W01-I */
            _.Move(18, FILLER_0.W01_I);

            /*" -3499- MOVE 'R2200-FETCH  SEGURVGA  ' TO W01-TEXTO(W01-I) */
            _.Move("R2200-FETCH  SEGURVGA  ", FILLER_0.W01_TABELA_TEXTO.W01_TAB_TEXTO[FILLER_0.W01_I].W01_TEXTO);

            /*" -3503- PERFORM R8900-TOTALIZA-INICIO THRU R8900-TOTALIZA-INICIO-EXIT */

            R8900_TOTALIZA_INICIO_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8900_TOTALIZA_INICIO_EXIT*/


            /*" -3521- PERFORM R2200_00_SELECT_SEGURVGA_DB_FETCH_1 */

            R2200_00_SELECT_SEGURVGA_DB_FETCH_1();

            /*" -3525- MOVE 1 TO W01-QTD-ACC-OK */
            _.Move(1, FILLER_0.W01_QTD_ACC_OK);

            /*" -3529- PERFORM R8910-TOTALIZA-FINAL THRU R8910-TOTALIZA-FINAL-EXIT */

            R8910_TOTALIZA_FINAL_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8910_TOTALIZA_FINAL_EXIT*/


            /*" -3530- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3531- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -3532- MOVE 'NAO' TO WTEM-SEGURVGA */
                    _.Move("NAO", FILLER_1.FILLER_15.WTEM_SEGURVGA);

                    /*" -3533- ELSE */
                }
                else
                {


                    /*" -3534- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -3535- END-IF */
                }


                /*" -3537- END-IF. */
            }


            /*" -3537- PERFORM R2200_00_SELECT_SEGURVGA_DB_CLOSE_1 */

            R2200_00_SELECT_SEGURVGA_DB_CLOSE_1();

        }

        [StopWatch]
        /*" R2200-00-SELECT-SEGURVGA-DB-OPEN-1 */
        public void R2200_00_SELECT_SEGURVGA_DB_OPEN_1()
        {
            /*" -3484- EXEC SQL OPEN SEGURVGA1 END-EXEC. */

            SEGURVGA1.Open();

        }

        [StopWatch]
        /*" R8000-00-DECLARE-SUBGVGAP-DB-DECLARE-1 */
        public void R8000_00_DECLARE_SUBGVGAP_DB_DECLARE_1()
        {
            /*" -5674- EXEC SQL DECLARE CSUBGVGAP CURSOR FOR SELECT NUM_APOLICE, COD_SUBGRUPO FROM SEGUROS.SUBGRUPOS_VGAP WHERE NUM_APOLICE = :SUBGVGAP-NUM-APOLICE AND SIT_REGISTRO = '0' GROUP BY NUM_APOLICE, COD_SUBGRUPO ORDER BY NUM_APOLICE, COD_SUBGRUPO WITH UR END-EXEC. */
            CSUBGVGAP = new VG1613B_CSUBGVGAP(true);
            string GetQuery_CSUBGVGAP()
            {
                var query = @$"SELECT NUM_APOLICE
							, 
							COD_SUBGRUPO 
							FROM SEGUROS.SUBGRUPOS_VGAP 
							WHERE NUM_APOLICE = '{SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_NUM_APOLICE}' 
							AND SIT_REGISTRO = '0' 
							GROUP BY NUM_APOLICE
							, COD_SUBGRUPO 
							ORDER BY NUM_APOLICE
							, COD_SUBGRUPO";

                return query;
            }
            CSUBGVGAP.GetQueryEvent += GetQuery_CSUBGVGAP;

        }

        [StopWatch]
        /*" R2200-00-SELECT-SEGURVGA-DB-FETCH-1 */
        public void R2200_00_SELECT_SEGURVGA_DB_FETCH_1()
        {
            /*" -3521- EXEC SQL FETCH SEGURVGA1 INTO :CLIENTES-COD-CLIENTE , :SEGURVGA-NUM-APOLICE , :SEGURVGA-NUM-ITEM , :SEGURVGA-OCORR-HISTORICO, :SEGURVGA-NUM-CERTIFICADO, :SEGURVGA-TIPO-SEGURADO , :SEGURVGA-PCT-CONJUGE-VG, :SEGURVGA-PCT-CONJUGE-AP, :SEGURVGA-TAXA-AP-MORACID, :SEGURVGA-TAXA-AP-INVPERM, :SEGURVGA-TAXA-AP-AMDS, :SEGURVGA-TAXA-AP-DH, :SEGURVGA-TAXA-AP-DIT, :SEGURVGA-TAXA-AP, :SEGURVGA-TAXA-VG, :ENDERECO-OCORR-ENDERECO , :SEGURVGA-SIT-REGISTRO END-EXEC. */

            if (SEGURVGA1.Fetch())
            {
                _.Move(SEGURVGA1.CLIENTES_COD_CLIENTE, CLIENTES.DCLCLIENTES.CLIENTES_COD_CLIENTE);
                _.Move(SEGURVGA1.SEGURVGA_NUM_APOLICE, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_APOLICE);
                _.Move(SEGURVGA1.SEGURVGA_NUM_ITEM, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_ITEM);
                _.Move(SEGURVGA1.SEGURVGA_OCORR_HISTORICO, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_OCORR_HISTORICO);
                _.Move(SEGURVGA1.SEGURVGA_NUM_CERTIFICADO, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_CERTIFICADO);
                _.Move(SEGURVGA1.SEGURVGA_TIPO_SEGURADO, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_TIPO_SEGURADO);
                _.Move(SEGURVGA1.SEGURVGA_PCT_CONJUGE_VG, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_PCT_CONJUGE_VG);
                _.Move(SEGURVGA1.SEGURVGA_PCT_CONJUGE_AP, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_PCT_CONJUGE_AP);
                _.Move(SEGURVGA1.SEGURVGA_TAXA_AP_MORACID, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_TAXA_AP_MORACID);
                _.Move(SEGURVGA1.SEGURVGA_TAXA_AP_INVPERM, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_TAXA_AP_INVPERM);
                _.Move(SEGURVGA1.SEGURVGA_TAXA_AP_AMDS, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_TAXA_AP_AMDS);
                _.Move(SEGURVGA1.SEGURVGA_TAXA_AP_DH, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_TAXA_AP_DH);
                _.Move(SEGURVGA1.SEGURVGA_TAXA_AP_DIT, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_TAXA_AP_DIT);
                _.Move(SEGURVGA1.SEGURVGA_TAXA_AP, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_TAXA_AP);
                _.Move(SEGURVGA1.SEGURVGA_TAXA_VG, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_TAXA_VG);
                _.Move(SEGURVGA1.ENDERECO_OCORR_ENDERECO, ENDERECO.DCLENDERECOS.ENDERECO_OCORR_ENDERECO);
                _.Move(SEGURVGA1.SEGURVGA_SIT_REGISTRO, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_SIT_REGISTRO);
            }

        }

        [StopWatch]
        /*" R2200-00-SELECT-SEGURVGA-DB-CLOSE-1 */
        public void R2200_00_SELECT_SEGURVGA_DB_CLOSE_1()
        {
            /*" -3537- EXEC SQL CLOSE SEGURVGA1 END-EXEC. */

            SEGURVGA1.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2200_99_SAIDA*/

        [StopWatch]
        /*" R2400-00-SELECT-ERROSVID-SECTION */
        private void R2400_00_SELECT_ERROSVID_SECTION()
        {
            /*" -3546- MOVE 'R2400-00-SELECT-ERROSVID' TO PARAGRAFO. */
            _.Move("R2400-00-SELECT-ERROSVID", FILLER_1.WABEND.PARAGRAFO);

            /*" -3547- MOVE '2400' TO WNR-EXEC-SQL. */
            _.Move("2400", FILLER_1.WABEND.WNR_EXEC_SQL);

            /*" -3558- DISPLAY PARAGRAFO */
            _.Display(FILLER_1.WABEND.PARAGRAFO);

            /*" -3559- MOVE 19 TO W01-I */
            _.Move(19, FILLER_0.W01_I);

            /*" -3560- MOVE 'R2400-SELECT ERROSVID  ' TO W01-TEXTO(W01-I) */
            _.Move("R2400-SELECT ERROSVID  ", FILLER_0.W01_TABELA_TEXTO.W01_TAB_TEXTO[FILLER_0.W01_I].W01_TEXTO);

            /*" -3564- PERFORM R8900-TOTALIZA-INICIO THRU R8900-TOTALIZA-INICIO-EXIT */

            R8900_TOTALIZA_INICIO_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8900_TOTALIZA_INICIO_EXIT*/


            /*" -3571- PERFORM R2400_00_SELECT_ERROSVID_DB_SELECT_1 */

            R2400_00_SELECT_ERROSVID_DB_SELECT_1();

            /*" -3575- MOVE 1 TO W01-QTD-ACC-OK */
            _.Move(1, FILLER_0.W01_QTD_ACC_OK);

            /*" -3579- PERFORM R8910-TOTALIZA-FINAL THRU R8910-TOTALIZA-FINAL-EXIT */

            R8910_TOTALIZA_FINAL_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8910_TOTALIZA_FINAL_EXIT*/


            /*" -3580- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3581- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -3582- MOVE SPACES TO ERROSVID-DESCR-ERRO */
                    _.Move("", ERROSVID.DCLERROS_VIDAZUL.ERROSVID_DESCR_ERRO);

                    /*" -3583- ELSE */
                }
                else
                {


                    /*" -3584- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -3585- END-IF */
                }


                /*" -3585- END-IF. */
            }


        }

        [StopWatch]
        /*" R2400-00-SELECT-ERROSVID-DB-SELECT-1 */
        public void R2400_00_SELECT_ERROSVID_DB_SELECT_1()
        {
            /*" -3571- EXEC SQL SELECT SUBSTR(VALUE(DES_ABREV_MSG_CRITICA, ' ' ),1,60) INTO :ERROSVID-DESCR-ERRO FROM SEGUROS.VG_DM_MSG_CRITICA WHERE COD_MSG_CRITICA = :ERROSVID-COD-ERRO WITH UR END-EXEC. */

            var r2400_00_SELECT_ERROSVID_DB_SELECT_1_Query1 = new R2400_00_SELECT_ERROSVID_DB_SELECT_1_Query1()
            {
                ERROSVID_COD_ERRO = ERROSVID.DCLERROS_VIDAZUL.ERROSVID_COD_ERRO.ToString(),
            };

            var executed_1 = R2400_00_SELECT_ERROSVID_DB_SELECT_1_Query1.Execute(r2400_00_SELECT_ERROSVID_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.ERROSVID_DESCR_ERRO, ERROSVID.DCLERROS_VIDAZUL.ERROSVID_DESCR_ERRO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2400_99_SAIDA*/

        [StopWatch]
        /*" R2500-00-SELECT-ENDERECO-SECTION */
        private void R2500_00_SELECT_ENDERECO_SECTION()
        {
            /*" -3594- MOVE 'R2500-00-SELECT-ENDERECO' TO PARAGRAFO. */
            _.Move("R2500-00-SELECT-ENDERECO", FILLER_1.WABEND.PARAGRAFO);

            /*" -3595- MOVE '2500' TO WNR-EXEC-SQL. */
            _.Move("2500", FILLER_1.WABEND.WNR_EXEC_SQL);

            /*" -3597- DISPLAY PARAGRAFO */
            _.Display(FILLER_1.WABEND.PARAGRAFO);

            /*" -3600- MOVE 'SIM' TO WTEM-ENDERECO. */
            _.Move("SIM", FILLER_1.FILLER_15.WTEM_ENDERECO);

            /*" -3601- MOVE 20 TO W01-I */
            _.Move(20, FILLER_0.W01_I);

            /*" -3602- MOVE 'R2500-SELECT ENDERECO  ' TO W01-TEXTO(W01-I) */
            _.Move("R2500-SELECT ENDERECO  ", FILLER_0.W01_TABELA_TEXTO.W01_TAB_TEXTO[FILLER_0.W01_I].W01_TEXTO);

            /*" -3606- PERFORM R8900-TOTALIZA-INICIO THRU R8900-TOTALIZA-INICIO-EXIT */

            R8900_TOTALIZA_INICIO_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8900_TOTALIZA_INICIO_EXIT*/


            /*" -3629- PERFORM R2500_00_SELECT_ENDERECO_DB_SELECT_1 */

            R2500_00_SELECT_ENDERECO_DB_SELECT_1();

            /*" -3633- MOVE 1 TO W01-QTD-ACC-OK */
            _.Move(1, FILLER_0.W01_QTD_ACC_OK);

            /*" -3637- PERFORM R8910-TOTALIZA-FINAL THRU R8910-TOTALIZA-FINAL-EXIT */

            R8910_TOTALIZA_FINAL_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8910_TOTALIZA_FINAL_EXIT*/


            /*" -3638- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3639- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -3644- DISPLAY 'ENDERECO NAO CADASTRADO ' ' ' SUBGVGAP-NUM-APOLICE ' ' SUBGVGAP-COD-SUBGRUPO ' ' SUBGVGAP-COD-CLIENTE ' ' SUBGVGAP-OCORR-ENDERECO */

                    $"ENDERECO NAO CADASTRADO  {SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_NUM_APOLICE} {SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_SUBGRUPO} {SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_CLIENTE} {SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_OCORR_ENDERECO}"
                    .Display();

                    /*" -3647- MOVE 'NAO' TO WTEM-SUBGVGAP WTEM-ENDERECO */
                    _.Move("NAO", FILLER_1.FILLER_15.WTEM_SUBGVGAP, FILLER_1.FILLER_15.WTEM_ENDERECO);

                    /*" -3648- ELSE */
                }
                else
                {


                    /*" -3649- DISPLAY 'R2500 - ERRO ACESSO ENDERECOS ' SQLCODE */
                    _.Display($"R2500 - ERRO ACESSO ENDERECOS {DB.SQLCODE}");

                    /*" -3650- DISPLAY 'COD-CLIENTE = ' SUBGVGAP-COD-CLIENTE */
                    _.Display($"COD-CLIENTE = {SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_CLIENTE}");

                    /*" -3651- DISPLAY 'OCORR_ENDER = ' SUBGVGAP-OCORR-ENDERECO */
                    _.Display($"OCORR_ENDER = {SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_OCORR_ENDERECO}");

                    /*" -3652- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -3653- END-IF */
                }


                /*" -3653- END-IF. */
            }


        }

        [StopWatch]
        /*" R2500-00-SELECT-ENDERECO-DB-SELECT-1 */
        public void R2500_00_SELECT_ENDERECO_DB_SELECT_1()
        {
            /*" -3629- EXEC SQL SELECT COD_ENDERECO, OCORR_ENDERECO, ENDERECO, BAIRRO, CIDADE, SIGLA_UF, CEP, DDD, TELEFONE INTO :WHOST-COD-ENDERECO, :WHOST-OCORR-ENDERECO, :WHOST-ENDERECO, :WHOST-BAIRRO, :WHOST-CIDADE, :WHOST-SIGLA-UF, :WHOST-CEP, :WHOST-DDD, :WHOST-TELEFONE FROM SEGUROS.ENDERECOS WHERE COD_CLIENTE = :SUBGVGAP-COD-CLIENTE AND OCORR_ENDERECO = :SUBGVGAP-OCORR-ENDERECO END-EXEC */

            var r2500_00_SELECT_ENDERECO_DB_SELECT_1_Query1 = new R2500_00_SELECT_ENDERECO_DB_SELECT_1_Query1()
            {
                SUBGVGAP_OCORR_ENDERECO = SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_OCORR_ENDERECO.ToString(),
                SUBGVGAP_COD_CLIENTE = SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_CLIENTE.ToString(),
            };

            var executed_1 = R2500_00_SELECT_ENDERECO_DB_SELECT_1_Query1.Execute(r2500_00_SELECT_ENDERECO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_COD_ENDERECO, WHOST_COD_ENDERECO);
                _.Move(executed_1.WHOST_OCORR_ENDERECO, WHOST_OCORR_ENDERECO);
                _.Move(executed_1.WHOST_ENDERECO, WHOST_ENDERECO);
                _.Move(executed_1.WHOST_BAIRRO, WHOST_BAIRRO);
                _.Move(executed_1.WHOST_CIDADE, WHOST_CIDADE);
                _.Move(executed_1.WHOST_SIGLA_UF, WHOST_SIGLA_UF);
                _.Move(executed_1.WHOST_CEP, WHOST_CEP);
                _.Move(executed_1.WHOST_DDD, WHOST_DDD);
                _.Move(executed_1.WHOST_TELEFONE, WHOST_TELEFONE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2500_99_SAIDA*/

        [StopWatch]
        /*" R2600-00-UPDATE-SEGURVGA-SECTION */
        private void R2600_00_UPDATE_SEGURVGA_SECTION()
        {
            /*" -3662- MOVE 'R2600-00-UPDATE-SEGURVGA' TO PARAGRAFO. */
            _.Move("R2600-00-UPDATE-SEGURVGA", FILLER_1.WABEND.PARAGRAFO);

            /*" -3663- MOVE '2600' TO WNR-EXEC-SQL. */
            _.Move("2600", FILLER_1.WABEND.WNR_EXEC_SQL);

            /*" -3666- DISPLAY PARAGRAFO */
            _.Display(FILLER_1.WABEND.PARAGRAFO);

            /*" -3667- MOVE 21 TO W01-I */
            _.Move(21, FILLER_0.W01_I);

            /*" -3668- MOVE 'R2600-UPDATE SEGURVGA  ' TO W01-TEXTO(W01-I) */
            _.Move("R2600-UPDATE SEGURVGA  ", FILLER_0.W01_TABELA_TEXTO.W01_TAB_TEXTO[FILLER_0.W01_I].W01_TEXTO);

            /*" -3672- PERFORM R8900-TOTALIZA-INICIO THRU R8900-TOTALIZA-INICIO-EXIT */

            R8900_TOTALIZA_INICIO_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8900_TOTALIZA_INICIO_EXIT*/


            /*" -3679- PERFORM R2600_00_UPDATE_SEGURVGA_DB_UPDATE_1 */

            R2600_00_UPDATE_SEGURVGA_DB_UPDATE_1();

            /*" -3683- MOVE 1 TO W01-QTD-ACC-OK */
            _.Move(1, FILLER_0.W01_QTD_ACC_OK);

            /*" -3687- PERFORM R8910-TOTALIZA-FINAL THRU R8910-TOTALIZA-FINAL-EXIT */

            R8910_TOTALIZA_FINAL_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8910_TOTALIZA_FINAL_EXIT*/


            /*" -3689- DISPLAY 'ALTERAR SEGURADO PARA 7777 >> ' SQLCODE */
            _.Display($"ALTERAR SEGURADO PARA 7777 >> {DB.SQLCODE}");

            /*" -3690- IF SQLCODE NOT EQUAL ZEROS AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -3691- DISPLAY 'R2600 - ERRO UPDATE SEGURVGA ' SQLCODE */
                _.Display($"R2600 - ERRO UPDATE SEGURVGA {DB.SQLCODE}");

                /*" -3692- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -3692- END-IF. */
            }


        }

        [StopWatch]
        /*" R2600-00-UPDATE-SEGURVGA-DB-UPDATE-1 */
        public void R2600_00_UPDATE_SEGURVGA_DB_UPDATE_1()
        {
            /*" -3679- EXEC SQL UPDATE SEGUROS.SEGURADOS_VGAP SET COD_PROFISSAO = 7777 WHERE NUM_APOLICE = :SUBGVGAP-NUM-APOLICE AND COD_SUBGRUPO = :SUBGVGAP-COD-SUBGRUPO AND SIT_REGISTRO = '0' END-EXEC */

            var r2600_00_UPDATE_SEGURVGA_DB_UPDATE_1_Update1 = new R2600_00_UPDATE_SEGURVGA_DB_UPDATE_1_Update1()
            {
                SUBGVGAP_COD_SUBGRUPO = SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_SUBGRUPO.ToString(),
                SUBGVGAP_NUM_APOLICE = SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_NUM_APOLICE.ToString(),
            };

            R2600_00_UPDATE_SEGURVGA_DB_UPDATE_1_Update1.Execute(r2600_00_UPDATE_SEGURVGA_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2600_99_SAIDA*/

        [StopWatch]
        /*" R2700-00-SELECT-PROPOSTA-SECTION */
        private void R2700_00_SELECT_PROPOSTA_SECTION()
        {
            /*" -3702- MOVE 'R2700-00-SELECT-PROPOSTA' TO PARAGRAFO. */
            _.Move("R2700-00-SELECT-PROPOSTA", FILLER_1.WABEND.PARAGRAFO);

            /*" -3703- MOVE '2700' TO WNR-EXEC-SQL. */
            _.Move("2700", FILLER_1.WABEND.WNR_EXEC_SQL);

            /*" -3706- DISPLAY PARAGRAFO */
            _.Display(FILLER_1.WABEND.PARAGRAFO);

            /*" -3707- MOVE 22 TO W01-I */
            _.Move(22, FILLER_0.W01_I);

            /*" -3708- MOVE 'R2700-SELECT SEGURVGA  ' TO W01-TEXTO(W01-I) */
            _.Move("R2700-SELECT SEGURVGA  ", FILLER_0.W01_TABELA_TEXTO.W01_TAB_TEXTO[FILLER_0.W01_I].W01_TEXTO);

            /*" -3712- PERFORM R8900-TOTALIZA-INICIO THRU R8900-TOTALIZA-INICIO-EXIT */

            R8900_TOTALIZA_INICIO_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8900_TOTALIZA_INICIO_EXIT*/


            /*" -3732- PERFORM R2700_00_SELECT_PROPOSTA_DB_SELECT_1 */

            R2700_00_SELECT_PROPOSTA_DB_SELECT_1();

            /*" -3736- MOVE 1 TO W01-QTD-ACC-OK */
            _.Move(1, FILLER_0.W01_QTD_ACC_OK);

            /*" -3740- PERFORM R8910-TOTALIZA-FINAL THRU R8910-TOTALIZA-FINAL-EXIT */

            R8910_TOTALIZA_FINAL_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8910_TOTALIZA_FINAL_EXIT*/


            /*" -3741- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3742- IF SQLCODE = 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -3744- MOVE 'NAO' TO WTEM-SUBGVGAP */
                    _.Move("NAO", FILLER_1.FILLER_15.WTEM_SUBGVGAP);

                    /*" -3745- GO TO R2700-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R2700_99_SAIDA*/ //GOTO
                    return;

                    /*" -3746- ELSE */
                }
                else
                {


                    /*" -3747- IF SQLCODE = -811 */

                    if (DB.SQLCODE == -811)
                    {

                        /*" -3750- DISPLAY 'DUPLICADO NAO PROPOSTAS_VA ' ' ' SUBGVGAP-NUM-APOLICE ' ' SUBGVGAP-COD-SUBGRUPO */

                        $"DUPLICADO NAO PROPOSTAS_VA  {SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_NUM_APOLICE} {SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_SUBGRUPO}"
                        .Display();

                        /*" -3751- ELSE */
                    }
                    else
                    {


                        /*" -3753- DISPLAY SUBGVGAP-NUM-APOLICE ' ' SUBGVGAP-COD-SUBGRUPO */

                        $"{SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_NUM_APOLICE} {SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_SUBGRUPO}"
                        .Display();

                        /*" -3755- GO TO R9999-00-ROT-ERRO. */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;
                    }

                }

            }


            /*" -3757- ADD 1 TO AC-LIDOS-PR. */
            FILLER_1.AC_LIDOS_PR.Value = FILLER_1.AC_LIDOS_PR + 1;

            /*" -3760- MOVE '2701' TO WNR-EXEC-SQL. */
            _.Move("2701", FILLER_1.WABEND.WNR_EXEC_SQL);

            /*" -3761- MOVE 23 TO W01-I */
            _.Move(23, FILLER_0.W01_I);

            /*" -3762- MOVE 'R2700-SELECT OPCPAGVI  ' TO W01-TEXTO(W01-I) */
            _.Move("R2700-SELECT OPCPAGVI  ", FILLER_0.W01_TABELA_TEXTO.W01_TAB_TEXTO[FILLER_0.W01_I].W01_TEXTO);

            /*" -3766- PERFORM R8900-TOTALIZA-INICIO THRU R8900-TOTALIZA-INICIO-EXIT */

            R8900_TOTALIZA_INICIO_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8900_TOTALIZA_INICIO_EXIT*/


            /*" -3777- PERFORM R2700_00_SELECT_PROPOSTA_DB_SELECT_2 */

            R2700_00_SELECT_PROPOSTA_DB_SELECT_2();

            /*" -3781- MOVE 1 TO W01-QTD-ACC-OK */
            _.Move(1, FILLER_0.W01_QTD_ACC_OK);

            /*" -3785- PERFORM R8910-TOTALIZA-FINAL THRU R8910-TOTALIZA-FINAL-EXIT */

            R8910_TOTALIZA_FINAL_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8910_TOTALIZA_FINAL_EXIT*/


            /*" -3786- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3787- DISPLAY 'CERTIFICADO = ' VGSEGCON-NUM-CERTIFICADO */
                _.Display($"CERTIFICADO = {VGSEGCON.DCLVG_SEGUR_CONSORCIO.VGSEGCON_NUM_CERTIFICADO}");

                /*" -3789- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3789- ADD 1 TO AC-LIDOS-OP. */
            FILLER_1.AC_LIDOS_OP.Value = FILLER_1.AC_LIDOS_OP + 1;

        }

        [StopWatch]
        /*" R2700-00-SELECT-PROPOSTA-DB-SELECT-1 */
        public void R2700_00_SELECT_PROPOSTA_DB_SELECT_1()
        {
            /*" -3732- EXEC SQL SELECT A.NUM_CERTIFICADO, B.DATA_INIVIGENCIA + :SUBGVGAP-PERI-FATURAMENTO MONTH, B.QUANT_VIDAS, B.VLPREMIO INTO :PROPOVA-NUM-CERTIFICADO , :HISCOBPR-DATA-INIVIGENCIA, :HISCOBPR-QUANT-VIDAS, :HISCOBPR-VLPREMIO FROM SEGUROS.PROPOSTAS_VA A, SEGUROS.HIS_COBER_PROPOST B WHERE A.NUM_APOLICE = :SUBGVGAP-NUM-APOLICE AND A.COD_SUBGRUPO = :SUBGVGAP-COD-SUBGRUPO AND B.NUM_CERTIFICADO = A.NUM_CERTIFICADO AND B.OCORR_HISTORICO = A.OCORR_HISTORICO WITH UR END-EXEC. */

            var r2700_00_SELECT_PROPOSTA_DB_SELECT_1_Query1 = new R2700_00_SELECT_PROPOSTA_DB_SELECT_1_Query1()
            {
                SUBGVGAP_PERI_FATURAMENTO = SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_PERI_FATURAMENTO.ToString(),
                SUBGVGAP_COD_SUBGRUPO = SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_SUBGRUPO.ToString(),
                SUBGVGAP_NUM_APOLICE = SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_NUM_APOLICE.ToString(),
            };

            var executed_1 = R2700_00_SELECT_PROPOSTA_DB_SELECT_1_Query1.Execute(r2700_00_SELECT_PROPOSTA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PROPOVA_NUM_CERTIFICADO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO);
                _.Move(executed_1.HISCOBPR_DATA_INIVIGENCIA, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_DATA_INIVIGENCIA);
                _.Move(executed_1.HISCOBPR_QUANT_VIDAS, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_QUANT_VIDAS);
                _.Move(executed_1.HISCOBPR_VLPREMIO, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_VLPREMIO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2700_99_SAIDA*/

        [StopWatch]
        /*" R2700-00-SELECT-PROPOSTA-DB-SELECT-2 */
        public void R2700_00_SELECT_PROPOSTA_DB_SELECT_2()
        {
            /*" -3777- EXEC SQL SELECT OPCAO_PAGAMENTO INTO :OPCPAGVI-OPCAO-PAGAMENTO FROM SEGUROS.OPCAO_PAG_VIDAZUL WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO AND DATA_TERVIGENCIA = '9999-12-31' WITH UR END-EXEC. */

            var r2700_00_SELECT_PROPOSTA_DB_SELECT_2_Query1 = new R2700_00_SELECT_PROPOSTA_DB_SELECT_2_Query1()
            {
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = R2700_00_SELECT_PROPOSTA_DB_SELECT_2_Query1.Execute(r2700_00_SELECT_PROPOSTA_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.OPCPAGVI_OPCAO_PAGAMENTO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPCAO_PAGAMENTO);
            }


        }

        [StopWatch]
        /*" R2800-00-SELECT-COBERPROPVA-SECTION */
        private void R2800_00_SELECT_COBERPROPVA_SECTION()
        {
            /*" -3798- MOVE 'R2800-00-SELECT-COBERPROPVA' TO PARAGRAFO. */
            _.Move("R2800-00-SELECT-COBERPROPVA", FILLER_1.WABEND.PARAGRAFO);

            /*" -3799- MOVE '2800' TO WNR-EXEC-SQL. */
            _.Move("2800", FILLER_1.WABEND.WNR_EXEC_SQL);

            /*" -3802- DISPLAY PARAGRAFO */
            _.Display(FILLER_1.WABEND.PARAGRAFO);

            /*" -3803- MOVE 24 TO W01-I */
            _.Move(24, FILLER_0.W01_I);

            /*" -3804- MOVE 'R2800-SELECT HISCOBPR  ' TO W01-TEXTO(W01-I) */
            _.Move("R2800-SELECT HISCOBPR  ", FILLER_0.W01_TABELA_TEXTO.W01_TAB_TEXTO[FILLER_0.W01_I].W01_TEXTO);

            /*" -3808- PERFORM R8900-TOTALIZA-INICIO THRU R8900-TOTALIZA-INICIO-EXIT */

            R8900_TOTALIZA_INICIO_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8900_TOTALIZA_INICIO_EXIT*/


            /*" -3815- PERFORM R2800_00_SELECT_COBERPROPVA_DB_SELECT_1 */

            R2800_00_SELECT_COBERPROPVA_DB_SELECT_1();

            /*" -3819- MOVE 1 TO W01-QTD-ACC-OK */
            _.Move(1, FILLER_0.W01_QTD_ACC_OK);

            /*" -3823- PERFORM R8910-TOTALIZA-FINAL THRU R8910-TOTALIZA-FINAL-EXIT */

            R8910_TOTALIZA_FINAL_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8910_TOTALIZA_FINAL_EXIT*/


            /*" -3824- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3825- IF SQLCODE = 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -3827- MOVE 'NAO' TO WTEM-SUBGVGAP */
                    _.Move("NAO", FILLER_1.FILLER_15.WTEM_SUBGVGAP);

                    /*" -3828- ELSE */
                }
                else
                {


                    /*" -3830- DISPLAY 'CERTIFICADO = ' SUBGVGAP-NUM-APOLICE ' ' SUBGVGAP-COD-SUBGRUPO */

                    $"CERTIFICADO = {SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_NUM_APOLICE} {SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_SUBGRUPO}"
                    .Display();

                    /*" -3830- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R2800-00-SELECT-COBERPROPVA-DB-SELECT-1 */
        public void R2800_00_SELECT_COBERPROPVA_DB_SELECT_1()
        {
            /*" -3815- EXEC SQL SELECT DATA_INIVIGENCIA + :SUBGVGAP-PERI-FATURAMENTO MONTH INTO :HISCOBPR-DATA-INIVIGENCIA FROM SEGUROS.HIS_COBER_PROPOST WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO AND DATA_TERVIGENCIA = '9999-12-31' WITH UR END-EXEC. */

            var r2800_00_SELECT_COBERPROPVA_DB_SELECT_1_Query1 = new R2800_00_SELECT_COBERPROPVA_DB_SELECT_1_Query1()
            {
                SUBGVGAP_PERI_FATURAMENTO = SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_PERI_FATURAMENTO.ToString(),
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = R2800_00_SELECT_COBERPROPVA_DB_SELECT_1_Query1.Execute(r2800_00_SELECT_COBERPROPVA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HISCOBPR_DATA_INIVIGENCIA, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_DATA_INIVIGENCIA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2800_99_SAIDA*/

        [StopWatch]
        /*" R2900-00-COMPARA-VALOR-IS-SECTION */
        private void R2900_00_COMPARA_VALOR_IS_SECTION()
        {
            /*" -3839- MOVE 'R2900-00-COMPARA-VALOR-IS' TO PARAGRAFO. */
            _.Move("R2900-00-COMPARA-VALOR-IS", FILLER_1.WABEND.PARAGRAFO);

            /*" -3840- MOVE '2900' TO WNR-EXEC-SQL. */
            _.Move("2900", FILLER_1.WABEND.WNR_EXEC_SQL);

            /*" -3842- DISPLAY PARAGRAFO */
            _.Display(FILLER_1.WABEND.PARAGRAFO);

            /*" -3844- INITIALIZE DCLAPOLICE-COBERTURAS */
            _.Initialize(
                APOLICOB.DCLAPOLICE_COBERTURAS
            );

            /*" -3845- IF APOLICES-RAMO-EMISSOR EQUAL PARAMRAM-RAMO-VGAPC */

            if (APOLICES.DCLAPOLICES.APOLICES_RAMO_EMISSOR == PARAMRAM.DCLPARAMETROS_RAMOS.PARAMRAM_RAMO_VGAPC)
            {

                /*" -3846- MOVE PARAMRAM-RAMO-VG TO WS-RAMO */
                _.Move(PARAMRAM.DCLPARAMETROS_RAMOS.PARAMRAM_RAMO_VG, WS_RAMO);

                /*" -3848- END-IF */
            }


            /*" -3849- IF APOLICES-RAMO-EMISSOR EQUAL PARAMRAM-RAMO-VG */

            if (APOLICES.DCLAPOLICES.APOLICES_RAMO_EMISSOR == PARAMRAM.DCLPARAMETROS_RAMOS.PARAMRAM_RAMO_VG)
            {

                /*" -3850- MOVE PARAMRAM-RAMO-VG TO WS-RAMO */
                _.Move(PARAMRAM.DCLPARAMETROS_RAMOS.PARAMRAM_RAMO_VG, WS_RAMO);

                /*" -3852- END-IF. */
            }


            /*" -3853- IF APOLICES-RAMO-EMISSOR EQUAL PARAMRAM-NUM-RAMO-PRSTMISTA */

            if (APOLICES.DCLAPOLICES.APOLICES_RAMO_EMISSOR == PARAMRAM.DCLPARAMETROS_RAMOS.PARAMRAM_NUM_RAMO_PRSTMISTA)
            {

                /*" -3854- MOVE PARAMRAM-NUM-RAMO-PRSTMISTA TO WS-RAMO */
                _.Move(PARAMRAM.DCLPARAMETROS_RAMOS.PARAMRAM_NUM_RAMO_PRSTMISTA, WS_RAMO);

                /*" -3856- END-IF. */
            }


            /*" -3857- IF APOLICES-RAMO-EMISSOR EQUAL 81 OR 82 */

            if (APOLICES.DCLAPOLICES.APOLICES_RAMO_EMISSOR.In("81", "82"))
            {

                /*" -3858- MOVE 1 TO APOLICOB-COD-COBERTURA */
                _.Move(1, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_COD_COBERTURA);

                /*" -3859- MOVE APOLICES-RAMO-EMISSOR TO WS-RAMO */
                _.Move(APOLICES.DCLAPOLICES.APOLICES_RAMO_EMISSOR, WS_RAMO);

                /*" -3860- ELSE */
            }
            else
            {


                /*" -3861- IF APOLICES-RAMO-EMISSOR EQUAL 93 OR 77 OR 97 */

                if (APOLICES.DCLAPOLICES.APOLICES_RAMO_EMISSOR.In("93", "77", "97"))
                {

                    /*" -3862- MOVE 11 TO APOLICOB-COD-COBERTURA */
                    _.Move(11, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_COD_COBERTURA);

                    /*" -3863- ELSE */
                }
                else
                {


                    /*" -3864- DISPLAY 'ERRO: RAMO EMISSOR NAO PREVISTO' */
                    _.Display($"ERRO: RAMO EMISSOR NAO PREVISTO");

                    /*" -3865- DISPLAY 'APOLICE     = ' SUBGVGAP-NUM-APOLICE */
                    _.Display($"APOLICE     = {SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_NUM_APOLICE}");

                    /*" -3866- DISPLAY 'ITEM        = ' SEGURVGA-NUM-ITEM */
                    _.Display($"ITEM        = {SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_ITEM}");

                    /*" -3867- DISPLAY 'OCORR HIST  = ' SEGURVGA-OCORR-HISTORICO */
                    _.Display($"OCORR HIST  = {SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_OCORR_HISTORICO}");

                    /*" -3868- DISPLAY 'RAMO-EMISSOR= ' APOLICES-RAMO-EMISSOR */
                    _.Display($"RAMO-EMISSOR= {APOLICES.DCLAPOLICES.APOLICES_RAMO_EMISSOR}");

                    /*" -3869- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -3870- END-IF */
                }


                /*" -3872- END-IF */
            }


            /*" -3874- PERFORM R7777-CONS-MODALIDADE-APOL */

            R7777_CONS_MODALIDADE_APOL_SECTION();

            /*" -3875- DISPLAY 'SUBGVGAP-NUM-APOLICE     > ' SUBGVGAP-NUM-APOLICE */
            _.Display($"SUBGVGAP-NUM-APOLICE     > {SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_NUM_APOLICE}");

            /*" -3876- DISPLAY 'SEGURVGA-NUM-ITEM        > ' SEGURVGA-NUM-ITEM */
            _.Display($"SEGURVGA-NUM-ITEM        > {SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_ITEM}");

            /*" -3878- DISPLAY 'SEGURVGA-OCORR-HISTORICO > ' SEGURVGA-OCORR-HISTORICO */
            _.Display($"SEGURVGA-OCORR-HISTORICO > {SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_OCORR_HISTORICO}");

            /*" -3879- DISPLAY 'WS-RAMO                  > ' WS-RAMO */
            _.Display($"WS-RAMO                  > {WS_RAMO}");

            /*" -3880- DISPLAY 'WS-V0APOL-MODALIDA       > ' WS-V0APOL-MODALIDA */
            _.Display($"WS-V0APOL-MODALIDA       > {WS_V0APOL_MODALIDA}");

            /*" -3883- DISPLAY 'APOLICOB-COD-COBERTURA   > ' APOLICOB-COD-COBERTURA */
            _.Display($"APOLICOB-COD-COBERTURA   > {APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_COD_COBERTURA}");

            /*" -3884- MOVE 25 TO W01-I */
            _.Move(25, FILLER_0.W01_I);

            /*" -3885- MOVE 'R2900-SELECT APOLICOB  ' TO W01-TEXTO(W01-I) */
            _.Move("R2900-SELECT APOLICOB  ", FILLER_0.W01_TABELA_TEXTO.W01_TAB_TEXTO[FILLER_0.W01_I].W01_TEXTO);

            /*" -3889- PERFORM R8900-TOTALIZA-INICIO THRU R8900-TOTALIZA-INICIO-EXIT */

            R8900_TOTALIZA_INICIO_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8900_TOTALIZA_INICIO_EXIT*/


            /*" -3905- PERFORM R2900_00_COMPARA_VALOR_IS_DB_SELECT_1 */

            R2900_00_COMPARA_VALOR_IS_DB_SELECT_1();

            /*" -3909- MOVE 1 TO W01-QTD-ACC-OK */
            _.Move(1, FILLER_0.W01_QTD_ACC_OK);

            /*" -3913- PERFORM R8910-TOTALIZA-FINAL THRU R8910-TOTALIZA-FINAL-EXIT */

            R8910_TOTALIZA_FINAL_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8910_TOTALIZA_FINAL_EXIT*/


            /*" -3915- DISPLAY 'APOLICOB-IMP-SEGURADA-IX > ' APOLICOB-IMP-SEGURADA-IX */
            _.Display($"APOLICOB-IMP-SEGURADA-IX > {APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_IMP_SEGURADA_IX}");

            /*" -3917- DISPLAY 'APOLICOB-PRM-TARIFARIO-IX> ' APOLICOB-PRM-TARIFARIO-IX */
            _.Display($"APOLICOB-PRM-TARIFARIO-IX> {APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_PRM_TARIFARIO_IX}");

            /*" -3919- DISPLAY 'SQLCODE > ' SQLCODE */
            _.Display($"SQLCODE > {DB.SQLCODE}");

            /*" -3920- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3921- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -3923- MOVE ZEROS TO APOLICOB-IMP-SEGURADA-IX APOLICOB-PRM-TARIFARIO-IX */
                    _.Move(0, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_IMP_SEGURADA_IX, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_PRM_TARIFARIO_IX);

                    /*" -3924- ELSE */
                }
                else
                {


                    /*" -3925- DISPLAY 'ERRO NO SELECT SEGUROS.APOLICE_COBERTURAS' */
                    _.Display($"ERRO NO SELECT SEGUROS.APOLICE_COBERTURAS");

                    /*" -3926- DISPLAY 'APOLICE     = ' SUBGVGAP-NUM-APOLICE */
                    _.Display($"APOLICE     = {SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_NUM_APOLICE}");

                    /*" -3927- DISPLAY 'ITEM        = ' SEGURVGA-NUM-ITEM */
                    _.Display($"ITEM        = {SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_ITEM}");

                    /*" -3928- DISPLAY 'OCORR HIST  = ' SEGURVGA-OCORR-HISTORICO */
                    _.Display($"OCORR HIST  = {SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_OCORR_HISTORICO}");

                    /*" -3929- DISPLAY 'RAMO        = ' WS-RAMO */
                    _.Display($"RAMO        = {WS_RAMO}");

                    /*" -3930- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -3931- END-IF */
                }


                /*" -3933- END-IF. */
            }


            /*" -3934- IF MOVIMVGA-IMP-MORNATU-ATU GREATER ZEROS */

            if (MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_MORNATU_ATU > 00)
            {

                /*" -3936- MOVE MOVIMVGA-IMP-MORNATU-ATU TO IS-SOR */
                _.Move(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_MORNATU_ATU, REGISTRO_SORT.IS_SOR);

                /*" -3937- ELSE */
            }
            else
            {


                /*" -3938- IF MOVIMVGA-IMP-MORACID-ATU GREATER ZEROS */

                if (MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_MORACID_ATU > 00)
                {

                    /*" -3940- MOVE MOVIMVGA-IMP-MORACID-ATU TO IS-SOR */
                    _.Move(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_MORACID_ATU, REGISTRO_SORT.IS_SOR);

                    /*" -3941- ELSE */
                }
                else
                {


                    /*" -3942- IF MOVIMVGA-IMP-INVPERM-ATU GREATER ZEROS */

                    if (MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_INVPERM_ATU > 00)
                    {

                        /*" -3944- MOVE MOVIMVGA-IMP-INVPERM-ATU TO IS-SOR */
                        _.Move(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_INVPERM_ATU, REGISTRO_SORT.IS_SOR);

                        /*" -3945- ELSE */
                    }
                    else
                    {


                        /*" -3946- IF MOVIMVGA-IMP-AMDS-ATU GREATER ZEROS */

                        if (MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_AMDS_ATU > 00)
                        {

                            /*" -3948- MOVE MOVIMVGA-IMP-AMDS-ATU TO IS-SOR */
                            _.Move(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_AMDS_ATU, REGISTRO_SORT.IS_SOR);

                            /*" -3949- ELSE */
                        }
                        else
                        {


                            /*" -3950- IF MOVIMVGA-IMP-DH-ATU GREATER ZEROS */

                            if (MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_DH_ATU > 00)
                            {

                                /*" -3952- MOVE MOVIMVGA-IMP-DH-ATU TO IS-SOR */
                                _.Move(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_DH_ATU, REGISTRO_SORT.IS_SOR);

                                /*" -3953- ELSE */
                            }
                            else
                            {


                                /*" -3954- IF MOVIMVGA-IMP-DIT-ATU GREATER ZEROS */

                                if (MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_DIT_ATU > 00)
                                {

                                    /*" -3956- MOVE MOVIMVGA-IMP-DIT-ATU TO IS-SOR */
                                    _.Move(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_DIT_ATU, REGISTRO_SORT.IS_SOR);

                                    /*" -3957- END-IF */
                                }


                                /*" -3958- END-IF */
                            }


                            /*" -3959- END-IF */
                        }


                        /*" -3960- END-IF */
                    }


                    /*" -3961- END-IF */
                }


                /*" -3973- END-IF */
            }


            /*" -3974- IF (IS-SOR EQUAL APOLICOB-IMP-SEGURADA-IX) */

            if ((REGISTRO_SORT.IS_SOR == APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_IMP_SEGURADA_IX))
            {

                /*" -3977- COMPUTE WS-PREMIO-VGAP = MOVIMVGA-PRM-VG-ATU + MOVIMVGA-PRM-AP-ATU */
                WS_PREMIO_VGAP.Value = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PRM_VG_ATU + MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PRM_AP_ATU;

                /*" -3978- DISPLAY 'IS-SOR > ' IS-SOR */
                _.Display($"IS-SOR > {REGISTRO_SORT.IS_SOR}");

                /*" -3979- DISPLAY 'MOVIMVGA-PRM-VG-ATU > ' MOVIMVGA-PRM-VG-ATU */
                _.Display($"MOVIMVGA-PRM-VG-ATU > {MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PRM_VG_ATU}");

                /*" -3980- DISPLAY 'MOVIMVGA-PRM-AP-ATU > ' MOVIMVGA-PRM-AP-ATU */
                _.Display($"MOVIMVGA-PRM-AP-ATU > {MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PRM_AP_ATU}");

                /*" -3981- DISPLAY 'WS-PREMIO-VGAP > ' WS-PREMIO-VGAP */
                _.Display($"WS-PREMIO-VGAP > {WS_PREMIO_VGAP}");

                /*" -3984- DISPLAY 'APOLICOB-PRM-TARIFARIO-IX > ' APOLICOB-PRM-TARIFARIO-IX */
                _.Display($"APOLICOB-PRM-TARIFARIO-IX > {APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_PRM_TARIFARIO_IX}");

                /*" -3985- IF (WS-PREMIO-VGAP EQUAL APOLICOB-PRM-TARIFARIO-IX) */

                if ((WS_PREMIO_VGAP == APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_PRM_TARIFARIO_IX))
                {

                    /*" -3986- DISPLAY 'VOU SAIR AQUI >>> ' */
                    _.Display($"VOU SAIR AQUI >>> ");

                    /*" -3987- DISPLAY ' ' */
                    _.Display($" ");

                    /*" -3988- GO TO R2900-00-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R2900_00_SAIDA*/ //GOTO
                    return;

                    /*" -3990- END-IF */
                }


                /*" -3991- IF (WS-PREMIO-VGAP > APOLICOB-PRM-TARIFARIO-IX) */

                if ((WS_PREMIO_VGAP > APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_PRM_TARIFARIO_IX))
                {

                    /*" -3992- MOVE 0801 TO MOVIMVGA-COD-OPERACAO */
                    _.Move(0801, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO);

                    /*" -3993- ELSE */
                }
                else
                {


                    /*" -3994- MOVE 0701 TO MOVIMVGA-COD-OPERACAO */
                    _.Move(0701, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO);

                    /*" -3995- END-IF */
                }


                /*" -3996- ELSE */
            }
            else
            {


                /*" -3997- IF IS-SOR GREATER THAN APOLICOB-IMP-SEGURADA-IX */

                if (REGISTRO_SORT.IS_SOR > APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_IMP_SEGURADA_IX)
                {

                    /*" -3998- MOVE 0801 TO MOVIMVGA-COD-OPERACAO */
                    _.Move(0801, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO);

                    /*" -3999- ELSE */
                }
                else
                {


                    /*" -4000- MOVE 0701 TO MOVIMVGA-COD-OPERACAO */
                    _.Move(0701, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO);

                    /*" -4001- END-IF */
                }


                /*" -4003- END-IF. */
            }


            /*" -4005- MOVE SEGURVGA-NUM-CERTIFICADO TO MOVIMVGA-NUM-CERTIFICADO */
            _.Move(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_CERTIFICADO, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_NUM_CERTIFICADO);

            /*" -4005- PERFORM R4400-00-INSERT-MOVIMVGA. */

            R4400_00_INSERT_MOVIMVGA_SECTION();

        }

        [StopWatch]
        /*" R2900-00-COMPARA-VALOR-IS-DB-SELECT-1 */
        public void R2900_00_COMPARA_VALOR_IS_DB_SELECT_1()
        {
            /*" -3905- EXEC SQL SELECT IMP_SEGURADA_IX, PRM_TARIFARIO_IX INTO :APOLICOB-IMP-SEGURADA-IX, :APOLICOB-PRM-TARIFARIO-IX FROM SEGUROS.APOLICE_COBERTURAS WHERE NUM_APOLICE = :SUBGVGAP-NUM-APOLICE AND NUM_ENDOSSO = 0 AND NUM_ITEM = :SEGURVGA-NUM-ITEM AND OCORR_HISTORICO = :SEGURVGA-OCORR-HISTORICO AND RAMO_COBERTURA = :WS-RAMO AND MODALI_COBERTURA = :WS-V0APOL-MODALIDA AND COD_COBERTURA = :APOLICOB-COD-COBERTURA WITH UR END-EXEC. */

            var r2900_00_COMPARA_VALOR_IS_DB_SELECT_1_Query1 = new R2900_00_COMPARA_VALOR_IS_DB_SELECT_1_Query1()
            {
                SEGURVGA_OCORR_HISTORICO = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_OCORR_HISTORICO.ToString(),
                APOLICOB_COD_COBERTURA = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_COD_COBERTURA.ToString(),
                SUBGVGAP_NUM_APOLICE = SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_NUM_APOLICE.ToString(),
                WS_V0APOL_MODALIDA = WS_V0APOL_MODALIDA.ToString(),
                SEGURVGA_NUM_ITEM = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_ITEM.ToString(),
                WS_RAMO = WS_RAMO.ToString(),
            };

            var executed_1 = R2900_00_COMPARA_VALOR_IS_DB_SELECT_1_Query1.Execute(r2900_00_COMPARA_VALOR_IS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.APOLICOB_IMP_SEGURADA_IX, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_IMP_SEGURADA_IX);
                _.Move(executed_1.APOLICOB_PRM_TARIFARIO_IX, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_PRM_TARIFARIO_IX);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2900_00_SAIDA*/

        [StopWatch]
        /*" R3200-00-SELECT-PRINCIPAL-SECTION */
        private void R3200_00_SELECT_PRINCIPAL_SECTION()
        {
            /*" -4014- MOVE 'R3200-00-SELECT-PRINCIPAL' TO PARAGRAFO. */
            _.Move("R3200-00-SELECT-PRINCIPAL", FILLER_1.WABEND.PARAGRAFO);

            /*" -4015- MOVE '3200' TO WNR-EXEC-SQL. */
            _.Move("3200", FILLER_1.WABEND.WNR_EXEC_SQL);

            /*" -4017- DISPLAY PARAGRAFO */
            _.Display(FILLER_1.WABEND.PARAGRAFO);

            /*" -4019- PERFORM R3205-00-SELECT-APOLICES. */

            R3205_00_SELECT_APOLICES_SECTION();

            /*" -4020- IF WTEM-SUBGVGAP EQUAL 'NAO' */

            if (FILLER_1.FILLER_15.WTEM_SUBGVGAP == "NAO")
            {

                /*" -4021- GO TO R3200-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3200_99_SAIDA*/ //GOTO
                return;

                /*" -4023- END-IF. */
            }


            /*" -4025- PERFORM R3210-00-SELECT-SUBGVGAP. */

            R3210_00_SELECT_SUBGVGAP_SECTION();

            /*" -4026- IF WTEM-SUBGVGAP EQUAL 'NAO' */

            if (FILLER_1.FILLER_15.WTEM_SUBGVGAP == "NAO")
            {

                /*" -4027- GO TO R3200-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3200_99_SAIDA*/ //GOTO
                return;

                /*" -4029- END-IF. */
            }


            /*" -4031- PERFORM R2050-00-ACESSA-PLANOVGA */

            R2050_00_ACESSA_PLANOVGA_SECTION();

            /*" -4032- IF WTEM-SUBGVGAP EQUAL 'NAO' */

            if (FILLER_1.FILLER_15.WTEM_SUBGVGAP == "NAO")
            {

                /*" -4033- GO TO R3200-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3200_99_SAIDA*/ //GOTO
                return;

                /*" -4035- END-IF. */
            }


            /*" -4037- PERFORM R3215-00-SELECT-CLIENTES. */

            R3215_00_SELECT_CLIENTES_SECTION();

            /*" -4038- IF WTEM-SUBGVGAP EQUAL 'NAO' */

            if (FILLER_1.FILLER_15.WTEM_SUBGVGAP == "NAO")
            {

                /*" -4039- GO TO R3200-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3200_99_SAIDA*/ //GOTO
                return;

                /*" -4041- END-IF. */
            }


            /*" -4043- PERFORM R3220-00-SELECT-CONDITEC. */

            R3220_00_SELECT_CONDITEC_SECTION();

            /*" -4044- IF WTEM-SUBGVGAP EQUAL 'NAO' */

            if (FILLER_1.FILLER_15.WTEM_SUBGVGAP == "NAO")
            {

                /*" -4045- GO TO R3200-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3200_99_SAIDA*/ //GOTO
                return;

                /*" -4047- END-IF. */
            }


            /*" -4049- PERFORM R3255-00-CRITICA-PLANO */

            R3255_00_CRITICA_PLANO_SECTION();

            /*" -4050- IF WTEM-SUBGVGAP EQUAL 'NAO' */

            if (FILLER_1.FILLER_15.WTEM_SUBGVGAP == "NAO")
            {

                /*" -4051- GO TO R3200-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3200_99_SAIDA*/ //GOTO
                return;

                /*" -4053- END-IF. */
            }


            /*" -4058- MOVE SUBGVGAP-COD-FONTE TO FONTES-COD-FONTE. */
            _.Move(SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_FONTE, FONTES.DCLFONTES.FONTES_COD_FONTE);

            /*" -4059- IF WTEM-SUBGVGAP EQUAL 'NAO' */

            if (FILLER_1.FILLER_15.WTEM_SUBGVGAP == "NAO")
            {

                /*" -4060- GO TO R3200-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3200_99_SAIDA*/ //GOTO
                return;

                /*" -4060- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3200_99_SAIDA*/

        [StopWatch]
        /*" R3205-00-SELECT-APOLICES-SECTION */
        private void R3205_00_SELECT_APOLICES_SECTION()
        {
            /*" -4069- MOVE 'R3205-00-SELECT-APOLICES' TO PARAGRAFO. */
            _.Move("R3205-00-SELECT-APOLICES", FILLER_1.WABEND.PARAGRAFO);

            /*" -4070- MOVE '3205' TO WNR-EXEC-SQL. */
            _.Move("3205", FILLER_1.WABEND.WNR_EXEC_SQL);

            /*" -4072- DISPLAY PARAGRAFO */
            _.Display(FILLER_1.WABEND.PARAGRAFO);

            /*" -4076- MOVE 'SIM' TO WTEM-SUBGVGAP. */
            _.Move("SIM", FILLER_1.FILLER_15.WTEM_SUBGVGAP);

            /*" -4077- MOVE 26 TO W01-I */
            _.Move(26, FILLER_0.W01_I);

            /*" -4078- MOVE 'R3205-SELECT APOLICES  ' TO W01-TEXTO(W01-I) */
            _.Move("R3205-SELECT APOLICES  ", FILLER_0.W01_TABELA_TEXTO.W01_TAB_TEXTO[FILLER_0.W01_I].W01_TEXTO);

            /*" -4082- PERFORM R8900-TOTALIZA-INICIO THRU R8900-TOTALIZA-INICIO-EXIT */

            R8900_TOTALIZA_INICIO_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8900_TOTALIZA_INICIO_EXIT*/


            /*" -4102- PERFORM R3205_00_SELECT_APOLICES_DB_SELECT_1 */

            R3205_00_SELECT_APOLICES_DB_SELECT_1();

            /*" -4106- MOVE 1 TO W01-QTD-ACC-OK */
            _.Move(1, FILLER_0.W01_QTD_ACC_OK);

            /*" -4110- PERFORM R8910-TOTALIZA-FINAL THRU R8910-TOTALIZA-FINAL-EXIT */

            R8910_TOTALIZA_FINAL_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8910_TOTALIZA_FINAL_EXIT*/


            /*" -4111- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4112- DISPLAY 'APOLICE NAO CADASTRADA ' SUBGVGAP-NUM-APOLICE */
                _.Display($"APOLICE NAO CADASTRADA {SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_NUM_APOLICE}");

                /*" -4114- MOVE 'NAO' TO WTEM-SUBGVGAP */
                _.Move("NAO", FILLER_1.FILLER_15.WTEM_SUBGVGAP);

                /*" -4116- MOVE 'PROBLEMAS NO SUBGRUPO - APOLICE NAO CADASTRADA' TO OBSERVACAO-SAI2 */
                _.Move("PROBLEMAS NO SUBGRUPO - APOLICE NAO CADASTRADA", REGISTRO_SAIDA2.OBSERVACAO_SAI2);

                /*" -4117- IF SQLCODE NOT EQUAL 100 */

                if (DB.SQLCODE != 100)
                {

                    /*" -4117- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R3205-00-SELECT-APOLICES-DB-SELECT-1 */
        public void R3205_00_SELECT_APOLICES_DB_SELECT_1()
        {
            /*" -4102- EXEC SQL SELECT COD_CLIENTE , NUM_APOLICE , COD_MODALIDADE , ORGAO_EMISSOR , RAMO_EMISSOR , COD_PRODUTO , NUM_BILHETE , TIPO_APOLICE INTO :APOLICES-COD-CLIENTE , :APOLICES-NUM-APOLICE , :APOLICES-COD-MODALIDADE , :APOLICES-ORGAO-EMISSOR , :APOLICES-RAMO-EMISSOR , :APOLICES-COD-PRODUTO , :APOLICES-NUM-BILHETE , :APOLICES-TIPO-APOLICE FROM SEGUROS.APOLICES WHERE NUM_APOLICE = :SUBGVGAP-NUM-APOLICE WITH UR END-EXEC. */

            var r3205_00_SELECT_APOLICES_DB_SELECT_1_Query1 = new R3205_00_SELECT_APOLICES_DB_SELECT_1_Query1()
            {
                SUBGVGAP_NUM_APOLICE = SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_NUM_APOLICE.ToString(),
            };

            var executed_1 = R3205_00_SELECT_APOLICES_DB_SELECT_1_Query1.Execute(r3205_00_SELECT_APOLICES_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.APOLICES_COD_CLIENTE, APOLICES.DCLAPOLICES.APOLICES_COD_CLIENTE);
                _.Move(executed_1.APOLICES_NUM_APOLICE, APOLICES.DCLAPOLICES.APOLICES_NUM_APOLICE);
                _.Move(executed_1.APOLICES_COD_MODALIDADE, APOLICES.DCLAPOLICES.APOLICES_COD_MODALIDADE);
                _.Move(executed_1.APOLICES_ORGAO_EMISSOR, APOLICES.DCLAPOLICES.APOLICES_ORGAO_EMISSOR);
                _.Move(executed_1.APOLICES_RAMO_EMISSOR, APOLICES.DCLAPOLICES.APOLICES_RAMO_EMISSOR);
                _.Move(executed_1.APOLICES_COD_PRODUTO, APOLICES.DCLAPOLICES.APOLICES_COD_PRODUTO);
                _.Move(executed_1.APOLICES_NUM_BILHETE, APOLICES.DCLAPOLICES.APOLICES_NUM_BILHETE);
                _.Move(executed_1.APOLICES_TIPO_APOLICE, APOLICES.DCLAPOLICES.APOLICES_TIPO_APOLICE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3205_99_SAIDA*/

        [StopWatch]
        /*" R3210-00-SELECT-SUBGVGAP-SECTION */
        private void R3210_00_SELECT_SUBGVGAP_SECTION()
        {
            /*" -4126- MOVE 'R3210-00-SELECT-SUBGVGAP' TO PARAGRAFO. */
            _.Move("R3210-00-SELECT-SUBGVGAP", FILLER_1.WABEND.PARAGRAFO);

            /*" -4127- MOVE '3210' TO WNR-EXEC-SQL. */
            _.Move("3210", FILLER_1.WABEND.WNR_EXEC_SQL);

            /*" -4130- DISPLAY PARAGRAFO */
            _.Display(FILLER_1.WABEND.PARAGRAFO);

            /*" -4131- MOVE 27 TO W01-I */
            _.Move(27, FILLER_0.W01_I);

            /*" -4132- MOVE 'R3210-SELECT SUBGVGAP  ' TO W01-TEXTO(W01-I) */
            _.Move("R3210-SELECT SUBGVGAP  ", FILLER_0.W01_TABELA_TEXTO.W01_TAB_TEXTO[FILLER_0.W01_I].W01_TEXTO);

            /*" -4136- PERFORM R8900-TOTALIZA-INICIO THRU R8900-TOTALIZA-INICIO-EXIT */

            R8900_TOTALIZA_INICIO_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8900_TOTALIZA_INICIO_EXIT*/


            /*" -4171- PERFORM R3210_00_SELECT_SUBGVGAP_DB_SELECT_1 */

            R3210_00_SELECT_SUBGVGAP_DB_SELECT_1();

            /*" -4175- MOVE 1 TO W01-QTD-ACC-OK */
            _.Move(1, FILLER_0.W01_QTD_ACC_OK);

            /*" -4179- PERFORM R8910-TOTALIZA-FINAL THRU R8910-TOTALIZA-FINAL-EXIT */

            R8910_TOTALIZA_FINAL_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8910_TOTALIZA_FINAL_EXIT*/


            /*" -4180- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4182- MOVE 'PROBLEMAS NO SUBGRUPO - SUBGRUPO NAO CADASTRADO' TO OBSERVACAO-SAI2 */
                _.Move("PROBLEMAS NO SUBGRUPO - SUBGRUPO NAO CADASTRADO", REGISTRO_SAIDA2.OBSERVACAO_SAI2);

                /*" -4185- DISPLAY 'SUBGRUPO NAO CADASTRADO ' ' ' SUBGVGAP-NUM-APOLICE ' ' SUBGVGAP-COD-SUBGRUPO */

                $"SUBGRUPO NAO CADASTRADO  {SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_NUM_APOLICE} {SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_SUBGRUPO}"
                .Display();

                /*" -4187- MOVE 'NAO' TO WTEM-SUBGVGAP */
                _.Move("NAO", FILLER_1.FILLER_15.WTEM_SUBGVGAP);

                /*" -4188- IF SQLCODE NOT EQUAL 100 */

                if (DB.SQLCODE != 100)
                {

                    /*" -4188- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R3210-00-SELECT-SUBGVGAP-DB-SELECT-1 */
        public void R3210_00_SELECT_SUBGVGAP_DB_SELECT_1()
        {
            /*" -4171- EXEC SQL SELECT COD_FONTE, TIPO_PLANO, FORMA_AVERBACAO, TIPO_FATURAMENTO, PERI_FATURAMENTO, PERI_RENOVACAO, BCO_COBRANCA, AGE_COBRANCA, DAC_COBRANCA, PCT_CONJUGE_VG, PCT_CONJUGE_AP, IND_PLANO_ASSOCIA, TIPO_COBRANCA, COD_CLIENTE, OCORR_ENDERECO INTO :SUBGVGAP-COD-FONTE, :SUBGVGAP-TIPO-PLANO, :SUBGVGAP-FORMA-AVERBACAO, :SUBGVGAP-TIPO-FATURAMENTO, :SUBGVGAP-PERI-FATURAMENTO, :SUBGVGAP-PERI-RENOVACAO, :SUBGVGAP-BCO-COBRANCA, :SUBGVGAP-AGE-COBRANCA, :SUBGVGAP-DAC-COBRANCA, :SUBGVGAP-PCT-CONJUGE-VG, :SUBGVGAP-PCT-CONJUGE-AP, :SUBGVGAP-IND-PLANO-ASSOCIA, :SUBGVGAP-TIPO-COBRANCA, :SUBGVGAP-COD-CLIENTE, :SUBGVGAP-OCORR-ENDERECO FROM SEGUROS.SUBGRUPOS_VGAP WHERE NUM_APOLICE = :SUBGVGAP-NUM-APOLICE AND COD_SUBGRUPO = :SUBGVGAP-COD-SUBGRUPO WITH UR END-EXEC. */

            var r3210_00_SELECT_SUBGVGAP_DB_SELECT_1_Query1 = new R3210_00_SELECT_SUBGVGAP_DB_SELECT_1_Query1()
            {
                SUBGVGAP_COD_SUBGRUPO = SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_SUBGRUPO.ToString(),
                SUBGVGAP_NUM_APOLICE = SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_NUM_APOLICE.ToString(),
            };

            var executed_1 = R3210_00_SELECT_SUBGVGAP_DB_SELECT_1_Query1.Execute(r3210_00_SELECT_SUBGVGAP_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SUBGVGAP_COD_FONTE, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_FONTE);
                _.Move(executed_1.SUBGVGAP_TIPO_PLANO, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_TIPO_PLANO);
                _.Move(executed_1.SUBGVGAP_FORMA_AVERBACAO, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_FORMA_AVERBACAO);
                _.Move(executed_1.SUBGVGAP_TIPO_FATURAMENTO, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_TIPO_FATURAMENTO);
                _.Move(executed_1.SUBGVGAP_PERI_FATURAMENTO, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_PERI_FATURAMENTO);
                _.Move(executed_1.SUBGVGAP_PERI_RENOVACAO, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_PERI_RENOVACAO);
                _.Move(executed_1.SUBGVGAP_BCO_COBRANCA, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_BCO_COBRANCA);
                _.Move(executed_1.SUBGVGAP_AGE_COBRANCA, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_AGE_COBRANCA);
                _.Move(executed_1.SUBGVGAP_DAC_COBRANCA, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_DAC_COBRANCA);
                _.Move(executed_1.SUBGVGAP_PCT_CONJUGE_VG, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_PCT_CONJUGE_VG);
                _.Move(executed_1.SUBGVGAP_PCT_CONJUGE_AP, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_PCT_CONJUGE_AP);
                _.Move(executed_1.SUBGVGAP_IND_PLANO_ASSOCIA, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_IND_PLANO_ASSOCIA);
                _.Move(executed_1.SUBGVGAP_TIPO_COBRANCA, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_TIPO_COBRANCA);
                _.Move(executed_1.SUBGVGAP_COD_CLIENTE, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_CLIENTE);
                _.Move(executed_1.SUBGVGAP_OCORR_ENDERECO, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_OCORR_ENDERECO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3210_99_SAIDA*/

        [StopWatch]
        /*" R3215-00-SELECT-CLIENTES-SECTION */
        private void R3215_00_SELECT_CLIENTES_SECTION()
        {
            /*" -4197- MOVE 'R3215-00-SELECT-CLIENTES' TO PARAGRAFO. */
            _.Move("R3215-00-SELECT-CLIENTES", FILLER_1.WABEND.PARAGRAFO);

            /*" -4198- MOVE '3215' TO WNR-EXEC-SQL. */
            _.Move("3215", FILLER_1.WABEND.WNR_EXEC_SQL);

            /*" -4201- DISPLAY PARAGRAFO */
            _.Display(FILLER_1.WABEND.PARAGRAFO);

            /*" -4202- MOVE 28 TO W01-I */
            _.Move(28, FILLER_0.W01_I);

            /*" -4203- MOVE 'R3215-SELECT CLIENTES  ' TO W01-TEXTO(W01-I) */
            _.Move("R3215-SELECT CLIENTES  ", FILLER_0.W01_TABELA_TEXTO.W01_TAB_TEXTO[FILLER_0.W01_I].W01_TEXTO);

            /*" -4207- PERFORM R8900-TOTALIZA-INICIO THRU R8900-TOTALIZA-INICIO-EXIT */

            R8900_TOTALIZA_INICIO_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8900_TOTALIZA_INICIO_EXIT*/


            /*" -4212- PERFORM R3215_00_SELECT_CLIENTES_DB_SELECT_1 */

            R3215_00_SELECT_CLIENTES_DB_SELECT_1();

            /*" -4216- MOVE 1 TO W01-QTD-ACC-OK */
            _.Move(1, FILLER_0.W01_QTD_ACC_OK);

            /*" -4220- PERFORM R8910-TOTALIZA-FINAL THRU R8910-TOTALIZA-FINAL-EXIT */

            R8910_TOTALIZA_FINAL_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8910_TOTALIZA_FINAL_EXIT*/


            /*" -4221- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4222- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -4223- MOVE SPACES TO CLIENTES-NOME-RAZAO */
                    _.Move("", CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO);

                    /*" -4224- ELSE */
                }
                else
                {


                    /*" -4225- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -4226- END-IF */
                }


                /*" -4226- END-IF. */
            }


        }

        [StopWatch]
        /*" R3215-00-SELECT-CLIENTES-DB-SELECT-1 */
        public void R3215_00_SELECT_CLIENTES_DB_SELECT_1()
        {
            /*" -4212- EXEC SQL SELECT NOME_RAZAO INTO :CLIENTES-NOME-RAZAO FROM SEGUROS.CLIENTES WHERE COD_CLIENTE = :SUBGVGAP-COD-CLIENTE END-EXEC. */

            var r3215_00_SELECT_CLIENTES_DB_SELECT_1_Query1 = new R3215_00_SELECT_CLIENTES_DB_SELECT_1_Query1()
            {
                SUBGVGAP_COD_CLIENTE = SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_CLIENTE.ToString(),
            };

            var executed_1 = R3215_00_SELECT_CLIENTES_DB_SELECT_1_Query1.Execute(r3215_00_SELECT_CLIENTES_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CLIENTES_NOME_RAZAO, CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3215_99_SAIDA*/

        [StopWatch]
        /*" R3220-00-SELECT-CONDITEC-SECTION */
        private void R3220_00_SELECT_CONDITEC_SECTION()
        {
            /*" -4235- MOVE 'R3220-00-SELECT-CONDITEC' TO PARAGRAFO. */
            _.Move("R3220-00-SELECT-CONDITEC", FILLER_1.WABEND.PARAGRAFO);

            /*" -4236- MOVE '3220' TO WNR-EXEC-SQL. */
            _.Move("3220", FILLER_1.WABEND.WNR_EXEC_SQL);

            /*" -4239- DISPLAY PARAGRAFO */
            _.Display(FILLER_1.WABEND.PARAGRAFO);

            /*" -4240- MOVE 29 TO W01-I */
            _.Move(29, FILLER_0.W01_I);

            /*" -4241- MOVE 'R3220-SELECT CONDITEC  ' TO W01-TEXTO(W01-I) */
            _.Move("R3220-SELECT CONDITEC  ", FILLER_0.W01_TABELA_TEXTO.W01_TAB_TEXTO[FILLER_0.W01_I].W01_TEXTO);

            /*" -4245- PERFORM R8900-TOTALIZA-INICIO THRU R8900-TOTALIZA-INICIO-EXIT */

            R8900_TOTALIZA_INICIO_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8900_TOTALIZA_INICIO_EXIT*/


            /*" -4282- PERFORM R3220_00_SELECT_CONDITEC_DB_SELECT_1 */

            R3220_00_SELECT_CONDITEC_DB_SELECT_1();

            /*" -4286- MOVE 1 TO W01-QTD-ACC-OK */
            _.Move(1, FILLER_0.W01_QTD_ACC_OK);

            /*" -4290- PERFORM R8910-TOTALIZA-FINAL THRU R8910-TOTALIZA-FINAL-EXIT */

            R8910_TOTALIZA_FINAL_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8910_TOTALIZA_FINAL_EXIT*/


            /*" -4291- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4293- MOVE 'PROBLEMAS NO SUBGRUPO - CONDTEC NAO CADASTRADO' TO OBSERVACAO-SAI2 */
                _.Move("PROBLEMAS NO SUBGRUPO - CONDTEC NAO CADASTRADO", REGISTRO_SAIDA2.OBSERVACAO_SAI2);

                /*" -4295- DISPLAY 'CONDTEC NAO CADASTRADA ' SUBGVGAP-NUM-APOLICE '  ' SUBGVGAP-COD-SUBGRUPO */

                $"CONDTEC NAO CADASTRADA {SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_NUM_APOLICE}  {SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_SUBGRUPO}"
                .Display();

                /*" -4297- MOVE 'NAO' TO WTEM-SUBGVGAP */
                _.Move("NAO", FILLER_1.FILLER_15.WTEM_SUBGVGAP);

                /*" -4298- IF SQLCODE NOT EQUAL 100 */

                if (DB.SQLCODE != 100)
                {

                    /*" -4298- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R3220-00-SELECT-CONDITEC-DB-SELECT-1 */
        public void R3220_00_SELECT_CONDITEC_DB_SELECT_1()
        {
            /*" -4282- EXEC SQL SELECT QTD_SAL_MORNATU, QTD_SAL_MORACID, QTD_SAL_INVPERM, TAXA_AP_MORACID, TAXA_AP_INVPERM, TAXA_AP_AMDS, TAXA_AP_DH, TAXA_AP_DIT, TAXA_AP, LIM_CAP_MORNATU, LIM_CAP_MORACID, LIM_CAP_INVAPER, GARAN_ADIC_IEA, GARAN_ADIC_IPA, GARAN_ADIC_IPD, GARAN_ADIC_HD INTO :CONDITEC-QTD-SAL-MORNATU, :CONDITEC-QTD-SAL-MORACID, :CONDITEC-QTD-SAL-INVPERM, :CONDITEC-TAXA-AP-MORACID, :CONDITEC-TAXA-AP-INVPERM, :CONDITEC-TAXA-AP-AMDS, :CONDITEC-TAXA-AP-DH, :CONDITEC-TAXA-AP-DIT, :CONDITEC-TAXA-AP, :CONDITEC-LIM-CAP-MORNATU, :CONDITEC-LIM-CAP-MORACID, :CONDITEC-LIM-CAP-INVAPER, :CONDITEC-GARAN-ADIC-IEA, :CONDITEC-GARAN-ADIC-IPA, :CONDITEC-GARAN-ADIC-IPD, :CONDITEC-GARAN-ADIC-HD FROM SEGUROS.CONDICOES_TECNICAS WHERE NUM_APOLICE = :SUBGVGAP-NUM-APOLICE AND COD_SUBGRUPO = :SUBGVGAP-COD-SUBGRUPO WITH UR END-EXEC. */

            var r3220_00_SELECT_CONDITEC_DB_SELECT_1_Query1 = new R3220_00_SELECT_CONDITEC_DB_SELECT_1_Query1()
            {
                SUBGVGAP_COD_SUBGRUPO = SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_SUBGRUPO.ToString(),
                SUBGVGAP_NUM_APOLICE = SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_NUM_APOLICE.ToString(),
            };

            var executed_1 = R3220_00_SELECT_CONDITEC_DB_SELECT_1_Query1.Execute(r3220_00_SELECT_CONDITEC_DB_SELECT_1_Query1);
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
        /*" R3230-00-SELECT-FONTE-SECTION */
        private void R3230_00_SELECT_FONTE_SECTION()
        {
            /*" -4307- MOVE 'R3230-00-SELECT-FONTE' TO PARAGRAFO. */
            _.Move("R3230-00-SELECT-FONTE", FILLER_1.WABEND.PARAGRAFO);

            /*" -4308- MOVE '3230' TO WNR-EXEC-SQL. */
            _.Move("3230", FILLER_1.WABEND.WNR_EXEC_SQL);

            /*" -4311- DISPLAY PARAGRAFO */
            _.Display(FILLER_1.WABEND.PARAGRAFO);

            /*" -4312- MOVE 30 TO W01-I */
            _.Move(30, FILLER_0.W01_I);

            /*" -4313- MOVE 'R3230-SELECT FONTE     ' TO W01-TEXTO(W01-I) */
            _.Move("R3230-SELECT FONTE     ", FILLER_0.W01_TABELA_TEXTO.W01_TAB_TEXTO[FILLER_0.W01_I].W01_TEXTO);

            /*" -4317- PERFORM R8900-TOTALIZA-INICIO THRU R8900-TOTALIZA-INICIO-EXIT */

            R8900_TOTALIZA_INICIO_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8900_TOTALIZA_INICIO_EXIT*/


            /*" -4324- PERFORM R3230_00_SELECT_FONTE_DB_SELECT_1 */

            R3230_00_SELECT_FONTE_DB_SELECT_1();

            /*" -4328- MOVE 1 TO W01-QTD-ACC-OK */
            _.Move(1, FILLER_0.W01_QTD_ACC_OK);

            /*" -4332- PERFORM R8910-TOTALIZA-FINAL THRU R8910-TOTALIZA-FINAL-EXIT */

            R8910_TOTALIZA_FINAL_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8910_TOTALIZA_FINAL_EXIT*/


            /*" -4333- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -4334- DISPLAY 'VG1613B - FONTE NAO CADASTRADA   ' */
                _.Display($"VG1613B - FONTE NAO CADASTRADA   ");

                /*" -4335- DISPLAY 'FONTE ........ ' SUBGVGAP-COD-FONTE */
                _.Display($"FONTE ........ {SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_FONTE}");

                /*" -4337- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -4338- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4340- DISPLAY 'VG1613B - ERRO NA LEITURA DA FONTES ' */
                _.Display($"VG1613B - ERRO NA LEITURA DA FONTES ");

                /*" -4342- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -4345- MOVE FONTES-ULT-PROP-AUTOMAT TO WHOST-PROP-AUTOMAT. */
            _.Move(FONTES.DCLFONTES.FONTES_ULT_PROP_AUTOMAT, WHOST_PROP_AUTOMAT);

            /*" -4346- ADD 1 TO WHOST-PROP-AUTOMAT. */
            WHOST_PROP_AUTOMAT.Value = WHOST_PROP_AUTOMAT + 1;

        }

        [StopWatch]
        /*" R3230-00-SELECT-FONTE-DB-SELECT-1 */
        public void R3230_00_SELECT_FONTE_DB_SELECT_1()
        {
            /*" -4324- EXEC SQL SELECT ULT_PROP_AUTOMAT INTO :FONTES-ULT-PROP-AUTOMAT FROM SEGUROS.FONTES WHERE COD_FONTE = :SUBGVGAP-COD-FONTE END-EXEC. */

            var r3230_00_SELECT_FONTE_DB_SELECT_1_Query1 = new R3230_00_SELECT_FONTE_DB_SELECT_1_Query1()
            {
                SUBGVGAP_COD_FONTE = SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_FONTE.ToString(),
            };

            var executed_1 = R3230_00_SELECT_FONTE_DB_SELECT_1_Query1.Execute(r3230_00_SELECT_FONTE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.FONTES_ULT_PROP_AUTOMAT, FONTES.DCLFONTES.FONTES_ULT_PROP_AUTOMAT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3230_99_SAIDA*/

        [StopWatch]
        /*" R3235-00-SELECT-ENDOSSOS-SECTION */
        private void R3235_00_SELECT_ENDOSSOS_SECTION()
        {
            /*" -4355- MOVE 'R3235-00-SELECT-ENDOSSOS' TO PARAGRAFO. */
            _.Move("R3235-00-SELECT-ENDOSSOS", FILLER_1.WABEND.PARAGRAFO);

            /*" -4356- MOVE '3235' TO WNR-EXEC-SQL. */
            _.Move("3235", FILLER_1.WABEND.WNR_EXEC_SQL);

            /*" -4359- DISPLAY PARAGRAFO */
            _.Display(FILLER_1.WABEND.PARAGRAFO);

            /*" -4360- MOVE 31 TO W01-I */
            _.Move(31, FILLER_0.W01_I);

            /*" -4361- MOVE 'R3235-SELECT ENDOSSOS  ' TO W01-TEXTO(W01-I) */
            _.Move("R3235-SELECT ENDOSSOS  ", FILLER_0.W01_TABELA_TEXTO.W01_TAB_TEXTO[FILLER_0.W01_I].W01_TEXTO);

            /*" -4365- PERFORM R8900-TOTALIZA-INICIO THRU R8900-TOTALIZA-INICIO-EXIT */

            R8900_TOTALIZA_INICIO_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8900_TOTALIZA_INICIO_EXIT*/


            /*" -4376- PERFORM R3235_00_SELECT_ENDOSSOS_DB_SELECT_1 */

            R3235_00_SELECT_ENDOSSOS_DB_SELECT_1();

            /*" -4380- MOVE 1 TO W01-QTD-ACC-OK */
            _.Move(1, FILLER_0.W01_QTD_ACC_OK);

            /*" -4384- PERFORM R8910-TOTALIZA-FINAL THRU R8910-TOTALIZA-FINAL-EXIT */

            R8910_TOTALIZA_FINAL_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8910_TOTALIZA_FINAL_EXIT*/


            /*" -4385- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -4387- DISPLAY 'ERRO - ENDOSSO 0 NAO EXISTE ' MOVIMVGA-NUM-APOLICE */
                _.Display($"ERRO - ENDOSSO 0 NAO EXISTE {MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_NUM_APOLICE}");

                /*" -4388- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -4390- END-IF. */
            }


            /*" -4392- DISPLAY 'ENDOSSO ZERO DA APOLICE = ' MOVIMVGA-NUM-APOLICE */
            _.Display($"ENDOSSO ZERO DA APOLICE = {MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_NUM_APOLICE}");

            /*" -4394- DISPLAY 'DATA-INIVIGENCIA        = ' WS-DATA-INIVIGENCIA-APOL */
            _.Display($"DATA-INIVIGENCIA        = {WS_DATA_INIVIGENCIA_APOL}");

            /*" -4396- DISPLAY 'DATA MOVIMENTO          = ' SISTEMAS-DATA-MOV-ABERTO-1 */
            _.Display($"DATA MOVIMENTO          = {SISTEMAS_DATA_MOV_ABERTO_1}");

            /*" -4397- DISPLAY 'QTDE DIAS VIGENCIA      = ' WS-QTD-DIAS-VIGENCIA . */
            _.Display($"QTDE DIAS VIGENCIA      = {WS_QTD_DIAS_VIGENCIA}");

        }

        [StopWatch]
        /*" R3235-00-SELECT-ENDOSSOS-DB-SELECT-1 */
        public void R3235_00_SELECT_ENDOSSOS_DB_SELECT_1()
        {
            /*" -4376- EXEC SQL SELECT DATA_INIVIGENCIA, DATE(:SISTEMAS-DATA-MOV-ABERTO-1) - DATA_INIVIGENCIA INTO :WS-DATA-INIVIGENCIA-APOL, :WS-QTD-DIAS-VIGENCIA FROM SEGUROS.ENDOSSOS WHERE NUM_APOLICE = :MOVIMVGA-NUM-APOLICE AND NUM_ENDOSSO = 0 END-EXEC. */

            var r3235_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1 = new R3235_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1()
            {
                SISTEMAS_DATA_MOV_ABERTO_1 = SISTEMAS_DATA_MOV_ABERTO_1.ToString(),
                MOVIMVGA_NUM_APOLICE = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_NUM_APOLICE.ToString(),
            };

            var executed_1 = R3235_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1.Execute(r3235_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_DATA_INIVIGENCIA_APOL, WS_DATA_INIVIGENCIA_APOL);
                _.Move(executed_1.WS_QTD_DIAS_VIGENCIA, WS_QTD_DIAS_VIGENCIA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3235_99_SAIDA*/

        [StopWatch]
        /*" R3240-00-UPDATE-FONTE-SECTION */
        private void R3240_00_UPDATE_FONTE_SECTION()
        {
            /*" -4406- MOVE 'R3240-00-UPDATE-FONTE' TO PARAGRAFO. */
            _.Move("R3240-00-UPDATE-FONTE", FILLER_1.WABEND.PARAGRAFO);

            /*" -4407- MOVE '3240' TO WNR-EXEC-SQL. */
            _.Move("3240", FILLER_1.WABEND.WNR_EXEC_SQL);

            /*" -4410- DISPLAY PARAGRAFO */
            _.Display(FILLER_1.WABEND.PARAGRAFO);

            /*" -4411- MOVE 32 TO W01-I */
            _.Move(32, FILLER_0.W01_I);

            /*" -4412- MOVE 'R3240-UPDATE FONTE     ' TO W01-TEXTO(W01-I) */
            _.Move("R3240-UPDATE FONTE     ", FILLER_0.W01_TABELA_TEXTO.W01_TAB_TEXTO[FILLER_0.W01_I].W01_TEXTO);

            /*" -4416- PERFORM R8900-TOTALIZA-INICIO THRU R8900-TOTALIZA-INICIO-EXIT */

            R8900_TOTALIZA_INICIO_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8900_TOTALIZA_INICIO_EXIT*/


            /*" -4421- PERFORM R3240_00_UPDATE_FONTE_DB_UPDATE_1 */

            R3240_00_UPDATE_FONTE_DB_UPDATE_1();

            /*" -4425- MOVE 1 TO W01-QTD-ACC-OK */
            _.Move(1, FILLER_0.W01_QTD_ACC_OK);

            /*" -4429- PERFORM R8910-TOTALIZA-FINAL THRU R8910-TOTALIZA-FINAL-EXIT */

            R8910_TOTALIZA_FINAL_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8910_TOTALIZA_FINAL_EXIT*/


            /*" -4430- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -4431- DISPLAY 'VG1613B - FONTE NAO CADASTRADA   ' */
                _.Display($"VG1613B - FONTE NAO CADASTRADA   ");

                /*" -4432- DISPLAY 'FONTE ........ ' SUBGVGAP-COD-FONTE */
                _.Display($"FONTE ........ {SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_FONTE}");

                /*" -4434- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -4435- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4437- DISPLAY 'VG1613B - ERRO NA ATUALIZACAO DA V0FONTE' */
                _.Display($"VG1613B - ERRO NA ATUALIZACAO DA V0FONTE");

                /*" -4437- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R3240-00-UPDATE-FONTE-DB-UPDATE-1 */
        public void R3240_00_UPDATE_FONTE_DB_UPDATE_1()
        {
            /*" -4421- EXEC SQL UPDATE SEGUROS.FONTES SET ULT_PROP_AUTOMAT = :WHOST-PROP-AUTOMAT, TIMESTAMP = CURRENT TIMESTAMP WHERE COD_FONTE = :SUBGVGAP-COD-FONTE END-EXEC. */

            var r3240_00_UPDATE_FONTE_DB_UPDATE_1_Update1 = new R3240_00_UPDATE_FONTE_DB_UPDATE_1_Update1()
            {
                WHOST_PROP_AUTOMAT = WHOST_PROP_AUTOMAT.ToString(),
                SUBGVGAP_COD_FONTE = SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_FONTE.ToString(),
            };

            R3240_00_UPDATE_FONTE_DB_UPDATE_1_Update1.Execute(r3240_00_UPDATE_FONTE_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3240_99_SAIDA*/

        [StopWatch]
        /*" R3255-00-CRITICA-PLANO-SECTION */
        private void R3255_00_CRITICA_PLANO_SECTION()
        {
            /*" -4480- MOVE 'R3255-00-CRITICA-PLANO' TO PARAGRAFO. */
            _.Move("R3255-00-CRITICA-PLANO", FILLER_1.WABEND.PARAGRAFO);

            /*" -4481- MOVE '3255' TO WNR-EXEC-SQL. */
            _.Move("3255", FILLER_1.WABEND.WNR_EXEC_SQL);

            /*" -4488- DISPLAY PARAGRAFO */
            _.Display(FILLER_1.WABEND.PARAGRAFO);

            /*" -4494- IF SUBGVGAP-TIPO-PLANO EQUAL '2' */

            if (SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_TIPO_PLANO == "2")
            {

                /*" -4495- IF IS-SOR EQUAL ZEROS */

                if (REGISTRO_SORT.IS_SOR == 00)
                {

                    /*" -4497- MOVE 'PROBLEMAS NO SUBGRUPO - IMP SEGURADA ZERADA TP2' TO OBSERVACAO-SAI2 */
                    _.Move("PROBLEMAS NO SUBGRUPO - IMP SEGURADA ZERADA TP2", REGISTRO_SAIDA2.OBSERVACAO_SAI2);

                    /*" -4498- MOVE 'NAO' TO WTEM-SUBGVGAP */
                    _.Move("NAO", FILLER_1.FILLER_15.WTEM_SUBGVGAP);

                    /*" -4499- END-IF */
                }


                /*" -4500- IF PREMIO-SOR EQUAL ZEROS */

                if (REGISTRO_SORT.PREMIO_SOR == 00)
                {

                    /*" -4502- MOVE 'PROBLEMAS NO SUBGRUPO - VL PREMIO ZERADO TP2' TO OBSERVACAO-SAI2 */
                    _.Move("PROBLEMAS NO SUBGRUPO - VL PREMIO ZERADO TP2", REGISTRO_SAIDA2.OBSERVACAO_SAI2);

                    /*" -4503- MOVE 'NAO' TO WTEM-SUBGVGAP */
                    _.Move("NAO", FILLER_1.FILLER_15.WTEM_SUBGVGAP);

                    /*" -4504- END-IF */
                }


                /*" -4506- END-IF. */
            }


            /*" -4507- IF SUBGVGAP-TIPO-PLANO EQUAL '3' */

            if (SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_TIPO_PLANO == "3")
            {

                /*" -4508- IF SALARIO-SOR EQUAL ZEROS */

                if (REGISTRO_SORT.SALARIO_SOR == 00)
                {

                    /*" -4510- MOVE 'PROBLEMAS NO SUBGRUPO - VL CAPITAL ZERADO TP3' TO OBSERVACAO-SAI2 */
                    _.Move("PROBLEMAS NO SUBGRUPO - VL CAPITAL ZERADO TP3", REGISTRO_SAIDA2.OBSERVACAO_SAI2);

                    /*" -4511- MOVE 'NAO' TO WTEM-SUBGVGAP */
                    _.Move("NAO", FILLER_1.FILLER_15.WTEM_SUBGVGAP);

                    /*" -4512- END-IF */
                }


                /*" -4513- IF QTDSAL-SOR NOT NUMERIC */

                if (!REGISTRO_SORT.QTDSAL_SOR.IsNumeric())
                {

                    /*" -4515- MOVE 'PROBLEMAS NO SUBGRUPO - QTD SALARIO ZERADO TP3' TO OBSERVACAO-SAI2 */
                    _.Move("PROBLEMAS NO SUBGRUPO - QTD SALARIO ZERADO TP3", REGISTRO_SAIDA2.OBSERVACAO_SAI2);

                    /*" -4516- MOVE 'NAO' TO WTEM-SUBGVGAP */
                    _.Move("NAO", FILLER_1.FILLER_15.WTEM_SUBGVGAP);

                    /*" -4517- END-IF */
                }


                /*" -4517- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3255_99_EXIT*/

        [StopWatch]
        /*" R3300-00-PROCESSA-IS-SECTION */
        private void R3300_00_PROCESSA_IS_SECTION()
        {
            /*" -4526- MOVE 'R3300-00-PROCESSA-IS' TO PARAGRAFO. */
            _.Move("R3300-00-PROCESSA-IS", FILLER_1.WABEND.PARAGRAFO);

            /*" -4527- MOVE '3300' TO WNR-EXEC-SQL. */
            _.Move("3300", FILLER_1.WABEND.WNR_EXEC_SQL);

            /*" -4529- DISPLAY PARAGRAFO */
            _.Display(FILLER_1.WABEND.PARAGRAFO);

            /*" -4530- IF (SUBGVGAP-TIPO-PLANO EQUAL '1' OR '4' ) */

            if ((SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_TIPO_PLANO.In("1", "4")))
            {

                /*" -4531- PERFORM R2070-00-CALCULA-IDADE */

                R2070_00_CALCULA_IDADE_SECTION();

                /*" -4532- IF (SUBGVGAP-IND-PLANO-ASSOCIA EQUAL 'S' ) */

                if ((SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_IND_PLANO_ASSOCIA == "S"))
                {

                    /*" -4533- PERFORM R2030-00-ACESSA-PLANOFAI */

                    R2030_00_ACESSA_PLANOFAI_SECTION();

                    /*" -4534- IF WS-ERRO-MOVTO EQUAL 'SIM' */

                    if (WS_ERRO_MOVTO == "SIM")
                    {

                        /*" -4535- GO TO R3300-99-SAIDA */
                        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3300_99_SAIDA*/ //GOTO
                        return;

                        /*" -4536- END-IF */
                    }


                    /*" -4537- ELSE */
                }
                else
                {


                    /*" -4538- PERFORM R2080-00-ACESSA-FAIXAETA */

                    R2080_00_ACESSA_FAIXAETA_SECTION();

                    /*" -4539- IF WS-ERRO-MOVTO EQUAL 'SIM' */

                    if (WS_ERRO_MOVTO == "SIM")
                    {

                        /*" -4540- GO TO R3300-99-SAIDA */
                        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3300_99_SAIDA*/ //GOTO
                        return;

                        /*" -4541- END-IF */
                    }


                    /*" -4542- END-IF */
                }


                /*" -4543- ELSE */
            }
            else
            {


                /*" -4544- IF (SALARIO-SOR > ZEROS) */

                if ((REGISTRO_SORT.SALARIO_SOR > 00))
                {

                    /*" -4545- PERFORM R2090-00-ACESSA-FAIXASAL */

                    R2090_00_ACESSA_FAIXASAL_SECTION();

                    /*" -4546- ELSE */
                }
                else
                {


                    /*" -4547- PERFORM R2095-00-ACESSA-FAIXA-SEMSAL */

                    R2095_00_ACESSA_FAIXA_SEMSAL_SECTION();

                    /*" -4549- END-IF */
                }


                /*" -4550- IF HOUVE-ERRO */

                if (FILLER_1.FL_ERRO["HOUVE_ERRO"])
                {

                    /*" -4553- IF (SUBGVGAP-TIPO-PLANO EQUAL '2' ) AND (SUBGVGAP-IND-PLANO-ASSOCIA EQUAL 'N' ) AND (APOLICES-RAMO-EMISSOR EQUAL 82) */

                    if ((SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_TIPO_PLANO == "2") && (SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_IND_PLANO_ASSOCIA == "N") && (APOLICES.DCLAPOLICES.APOLICES_RAMO_EMISSOR == 82))
                    {

                        /*" -4554- MOVE ZEROS TO FL-ERRO */
                        _.Move(0, FILLER_1.FL_ERRO);

                        /*" -4555- MOVE ZEROS TO FAIXASAL-FAIXA */
                        _.Move(0, FAIXASAL.DCLFAIXA_SALARIAL.FAIXASAL_FAIXA);

                        /*" -4556- MOVE ZEROS TO FAIXASAL-TAXA-VG */
                        _.Move(0, FAIXASAL.DCLFAIXA_SALARIAL.FAIXASAL_TAXA_VG);

                        /*" -4557- ELSE */
                    }
                    else
                    {


                        /*" -4558- MOVE 4033 TO COD-ERRO-SOR */
                        _.Move(4033, REGISTRO_SORT.COD_ERRO_SOR);

                        /*" -4559- PERFORM R2020-00-GRAVA-RETORNO */

                        R2020_00_GRAVA_RETORNO_SECTION();

                        /*" -4561- MOVE 'SIM' TO WS-ERRO-MOVTO WS-ERRO-SUBGRUPO */
                        _.Move("SIM", WS_ERRO_MOVTO, WS_ERRO_SUBGRUPO);

                        /*" -4562- GO TO R3300-99-SAIDA */
                        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3300_99_SAIDA*/ //GOTO
                        return;

                        /*" -4563- END-IF */
                    }


                    /*" -4565- END-IF */
                }


                /*" -4566- IF (SUBGVGAP-IND-PLANO-ASSOCIA EQUAL 'S' ) */

                if ((SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_IND_PLANO_ASSOCIA == "S"))
                {

                    /*" -4567- IF (SUBGVGAP-TIPO-PLANO EQUAL '2' ) */

                    if ((SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_TIPO_PLANO == "2"))
                    {

                        /*" -4568- PERFORM R2040-00-ACESSA-PLANFSAL */

                        R2040_00_ACESSA_PLANFSAL_SECTION();

                        /*" -4569- IF WS-ERRO-MOVTO EQUAL 'SIM' */

                        if (WS_ERRO_MOVTO == "SIM")
                        {

                            /*" -4570- GO TO R3300-99-SAIDA */
                            /*Método Suprimido por falta de linha ou apenas EXIT nome: R3300_99_SAIDA*/ //GOTO
                            return;

                            /*" -4571- END-IF */
                        }


                        /*" -4572- ELSE */
                    }
                    else
                    {


                        /*" -4573- PERFORM R2060-00-ACESSA-PLANOMUL */

                        R2060_00_ACESSA_PLANOMUL_SECTION();

                        /*" -4574- IF WS-ERRO-MOVTO EQUAL 'SIM' */

                        if (WS_ERRO_MOVTO == "SIM")
                        {

                            /*" -4575- GO TO R3300-99-SAIDA */
                            /*Método Suprimido por falta de linha ou apenas EXIT nome: R3300_99_SAIDA*/ //GOTO
                            return;

                            /*" -4576- END-IF */
                        }


                        /*" -4577- END-IF */
                    }


                    /*" -4578- END-IF */
                }


                /*" -4580- END-IF. */
            }


            /*" -4581- MOVE PLANOVGA-IMP-MORNATU TO TRANSP-IS-MORNATU */
            _.Move(PLANOVGA.DCLPLANOS_VGAP.PLANOVGA_IMP_MORNATU, TRANSP_IS_MORNATU);

            /*" -4582- MOVE PLANOVGA-IMP-MORACID TO TRANSP-IS-MORACID */
            _.Move(PLANOVGA.DCLPLANOS_VGAP.PLANOVGA_IMP_MORACID, TRANSP_IS_MORACID);

            /*" -4583- MOVE PLANOVGA-IMP-INVPERM TO TRANSP-IS-INVPERM */
            _.Move(PLANOVGA.DCLPLANOS_VGAP.PLANOVGA_IMP_INVPERM, TRANSP_IS_INVPERM);

            /*" -4584- MOVE PLANOVGA-IMP-AMDS TO TRANSP-IS-AMDS */
            _.Move(PLANOVGA.DCLPLANOS_VGAP.PLANOVGA_IMP_AMDS, TRANSP_IS_AMDS);

            /*" -4585- MOVE PLANOVGA-IMP-DH TO TRANSP-IS-DH */
            _.Move(PLANOVGA.DCLPLANOS_VGAP.PLANOVGA_IMP_DH, TRANSP_IS_DH);

            /*" -4587- MOVE PLANOVGA-IMP-DIT TO TRANSP-IS-DIT. */
            _.Move(PLANOVGA.DCLPLANOS_VGAP.PLANOVGA_IMP_DIT, TRANSP_IS_DIT);

            /*" -4589- MOVE ZEROS TO WTOT-PREMIO. */
            _.Move(0, WTOT_PREMIO);

            /*" -4590- IF (SUBGVGAP-IND-PLANO-ASSOCIA NOT EQUAL 'S' ) */

            if ((SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_IND_PLANO_ASSOCIA != "S"))
            {

                /*" -4592- IF (IS-SOR GREATER ZEROS) AND (PREMIO-SOR GREATER ZEROS) */

                if ((REGISTRO_SORT.IS_SOR > 00) && (REGISTRO_SORT.PREMIO_SOR > 00))
                {

                    /*" -4593- PERFORM R2130-00-PROCESSA-PLANO-ZERO */

                    R2130_00_PROCESSA_PLANO_ZERO_SECTION();

                    /*" -4594- END-IF */
                }


                /*" -4596- END-IF. */
            }


            /*" -4598- PERFORM R2100-00-MOVE-COBERTURAS */

            R2100_00_MOVE_COBERTURAS_SECTION();

            /*" -4598- PERFORM R2110-00-CALCULA-PREMIOS. */

            R2110_00_CALCULA_PREMIOS_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3300_99_SAIDA*/

        [StopWatch]
        /*" R3900-00-GRAVA-RESUMO-SECTION */
        private void R3900_00_GRAVA_RESUMO_SECTION()
        {
            /*" -4607- MOVE 'R3900-00-GRAVA-RESUMO' TO PARAGRAFO. */
            _.Move("R3900-00-GRAVA-RESUMO", FILLER_1.WABEND.PARAGRAFO);

            /*" -4608- MOVE '3900' TO WNR-EXEC-SQL. */
            _.Move("3900", FILLER_1.WABEND.WNR_EXEC_SQL);

            /*" -4610- DISPLAY PARAGRAFO */
            _.Display(FILLER_1.WABEND.PARAGRAFO);

            /*" -4612- ADD 1 TO WS-IND */
            WS_IND.Value = WS_IND + 1;

            /*" -4613- IF TAB-NUM-APOLICE (WS-IND) = ZEROS */

            if (TAB_RESUMO.TAB_RES[WS_IND].TAB_CHAVE_R.TAB_NUM_APOLICE == 00)
            {

                /*" -4615- GO TO R3900-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3900_99_SAIDA*/ //GOTO
                return;
            }


            /*" -4616- IF TAB-COD-SUBGRUPO (WS-IND) = ZEROS */

            if (TAB_RESUMO.TAB_RES[WS_IND].TAB_CHAVE_R.TAB_COD_SUBGRUPO == 00)
            {

                /*" -4618- GO TO R3900-00-GRAVA-RESUMO. */
                new Task(() => R3900_00_GRAVA_RESUMO_SECTION()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


            /*" -4621- MOVE TAB-NUM-APOLICE (WS-IND) TO NUM-APOLICE-SAI1 SUBGVGAP-NUM-APOLICE */
            _.Move(TAB_RESUMO.TAB_RES[WS_IND].TAB_CHAVE_R.TAB_NUM_APOLICE, REGISTRO_SAIDA1.NUM_APOLICE_SAI1, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_NUM_APOLICE);

            /*" -4624- MOVE TAB-COD-SUBGRUPO (WS-IND) TO SUBGRUPO-SAI1 SUBGVGAP-COD-SUBGRUPO */
            _.Move(TAB_RESUMO.TAB_RES[WS_IND].TAB_CHAVE_R.TAB_COD_SUBGRUPO, REGISTRO_SAIDA1.SUBGRUPO_SAI1, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_SUBGRUPO);

            /*" -4625- PERFORM R3910-00-SELECT-SUBGVGAP */

            R3910_00_SELECT_SUBGVGAP_SECTION();

            /*" -4627- MOVE CLIENTES-NOME-RAZAO TO SUBES-SAI1 */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO, REGISTRO_SAIDA1.SUBES_SAI1);

            /*" -4629- MOVE TAB-QTDE-ATIVOS (WS-IND) TO QTDE-ATIVOS-SAI1 */
            _.Move(TAB_RESUMO.TAB_RES[WS_IND].TAB_QTDE_ATIVOS, REGISTRO_SAIDA1.QTDE_ATIVOS_SAI1);

            /*" -4631- MOVE TAB-VLR-ATIVOS (WS-IND) TO VLR-ATIVOS-SAI1 */
            _.Move(TAB_RESUMO.TAB_RES[WS_IND].TAB_VLR_ATIVOS, REGISTRO_SAIDA1.VLR_ATIVOS_SAI1);

            /*" -4633- MOVE TAB-QTDE-CRITIC (WS-IND) TO QTDE-CRITIC-SAI1 */
            _.Move(TAB_RESUMO.TAB_RES[WS_IND].TAB_QTDE_CRITIC, REGISTRO_SAIDA1.QTDE_CRITIC_SAI1);

            /*" -4635- MOVE TAB-VLR-CRITIC (WS-IND) TO VLR-CRITIC-SAI1 */
            _.Move(TAB_RESUMO.TAB_RES[WS_IND].TAB_VLR_CRITIC, REGISTRO_SAIDA1.VLR_CRITIC_SAI1);

            /*" -4638- MOVE TAB-QTDE-MOVTO (WS-IND) TO QTDE-MOVTO-SAI1. */
            _.Move(TAB_RESUMO.TAB_RES[WS_IND].TAB_QTDE_MOVTO, REGISTRO_SAIDA1.QTDE_MOVTO_SAI1);

            /*" -4645- MOVE TAB-VLR-MOVTO (WS-IND) TO VLR-MOVTO-SAI1 */
            _.Move(TAB_RESUMO.TAB_RES[WS_IND].TAB_VLR_MOVTO, REGISTRO_SAIDA1.VLR_MOVTO_SAI1);

            /*" -4648- WRITE REGISTRO-RETORNO FROM REGISTRO-SAIDA1. */
            _.Move(REGISTRO_SAIDA1.GetMoveValues(), REGISTRO_RETORNO);

            ARQUIVO_RETORNO.Write(REGISTRO_RETORNO.GetMoveValues().ToString());

            /*" -4648- GO TO R3900-00-GRAVA-RESUMO. */
            new Task(() => R3900_00_GRAVA_RESUMO_SECTION()).RunSynchronously(); //GOTO
            return;//Recursividade detectada, cuidado...

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3900_99_SAIDA*/

        [StopWatch]
        /*" R3910-00-SELECT-SUBGVGAP-SECTION */
        private void R3910_00_SELECT_SUBGVGAP_SECTION()
        {
            /*" -4657- MOVE 'R3910-00-SELECT-SUBGVGAP' TO PARAGRAFO. */
            _.Move("R3910-00-SELECT-SUBGVGAP", FILLER_1.WABEND.PARAGRAFO);

            /*" -4658- MOVE '3910' TO WNR-EXEC-SQL. */
            _.Move("3910", FILLER_1.WABEND.WNR_EXEC_SQL);

            /*" -4661- DISPLAY PARAGRAFO */
            _.Display(FILLER_1.WABEND.PARAGRAFO);

            /*" -4662- MOVE 33 TO W01-I */
            _.Move(33, FILLER_0.W01_I);

            /*" -4663- MOVE 'R3910-SELECT SUBGVGAP  ' TO W01-TEXTO(W01-I) */
            _.Move("R3910-SELECT SUBGVGAP  ", FILLER_0.W01_TABELA_TEXTO.W01_TAB_TEXTO[FILLER_0.W01_I].W01_TEXTO);

            /*" -4667- PERFORM R8900-TOTALIZA-INICIO THRU R8900-TOTALIZA-INICIO-EXIT */

            R8900_TOTALIZA_INICIO_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8900_TOTALIZA_INICIO_EXIT*/


            /*" -4675- PERFORM R3910_00_SELECT_SUBGVGAP_DB_SELECT_1 */

            R3910_00_SELECT_SUBGVGAP_DB_SELECT_1();

            /*" -4679- MOVE 1 TO W01-QTD-ACC-OK */
            _.Move(1, FILLER_0.W01_QTD_ACC_OK);

            /*" -4683- PERFORM R8910-TOTALIZA-FINAL THRU R8910-TOTALIZA-FINAL-EXIT */

            R8910_TOTALIZA_FINAL_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8910_TOTALIZA_FINAL_EXIT*/


            /*" -4684- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4685- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -4686- MOVE SPACES TO CLIENTES-NOME-RAZAO */
                    _.Move("", CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO);

                    /*" -4687- ELSE */
                }
                else
                {


                    /*" -4688- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -4689- END-IF */
                }


                /*" -4689- END-IF. */
            }


        }

        [StopWatch]
        /*" R3910-00-SELECT-SUBGVGAP-DB-SELECT-1 */
        public void R3910_00_SELECT_SUBGVGAP_DB_SELECT_1()
        {
            /*" -4675- EXEC SQL SELECT B.NOME_RAZAO INTO :CLIENTES-NOME-RAZAO FROM SEGUROS.SUBGRUPOS_VGAP A, SEGUROS.CLIENTES B WHERE A.NUM_APOLICE = :SUBGVGAP-NUM-APOLICE AND A.COD_SUBGRUPO = :SUBGVGAP-COD-SUBGRUPO AND B.COD_CLIENTE = A.COD_CLIENTE END-EXEC. */

            var r3910_00_SELECT_SUBGVGAP_DB_SELECT_1_Query1 = new R3910_00_SELECT_SUBGVGAP_DB_SELECT_1_Query1()
            {
                SUBGVGAP_COD_SUBGRUPO = SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_SUBGRUPO.ToString(),
                SUBGVGAP_NUM_APOLICE = SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_NUM_APOLICE.ToString(),
            };

            var executed_1 = R3910_00_SELECT_SUBGVGAP_DB_SELECT_1_Query1.Execute(r3910_00_SELECT_SUBGVGAP_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CLIENTES_NOME_RAZAO, CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3910_99_SAIDA*/

        [StopWatch]
        /*" R4000-00-PROCESSA-INCLUSAO-SECTION */
        private void R4000_00_PROCESSA_INCLUSAO_SECTION()
        {
            /*" -4698- MOVE 'R4000-00-PROCESSA-INCLUSAO' TO PARAGRAFO. */
            _.Move("R4000-00-PROCESSA-INCLUSAO", FILLER_1.WABEND.PARAGRAFO);

            /*" -4699- MOVE '4000' TO WNR-EXEC-SQL. */
            _.Move("4000", FILLER_1.WABEND.WNR_EXEC_SQL);

            /*" -4701- DISPLAY PARAGRAFO */
            _.Display(FILLER_1.WABEND.PARAGRAFO);

            /*" -4703- PERFORM R4100-00-NUMERA-CERTIF. */

            R4100_00_NUMERA_CERTIF_SECTION();

            /*" -4705- PERFORM R4200-00-GRAVA-CLIENTES. */

            R4200_00_GRAVA_CLIENTES_SECTION();

            /*" -4706- IF WTEM-ENDERECO EQUAL 'SIM' */

            if (FILLER_1.FILLER_15.WTEM_ENDERECO == "SIM")
            {

                /*" -4707- PERFORM R4300-00-INSERT-ENDERECO */

                R4300_00_INSERT_ENDERECO_SECTION();

                /*" -4709- END-IF. */
            }


            /*" -4712- MOVE 0101 TO MOVIMVGA-COD-OPERACAO. */
            _.Move(0101, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO);

            /*" -4712- PERFORM R4400-00-INSERT-MOVIMVGA. */

            R4400_00_INSERT_MOVIMVGA_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4000_99_SAIDA*/

        [StopWatch]
        /*" R4100-00-NUMERA-CERTIF-SECTION */
        private void R4100_00_NUMERA_CERTIF_SECTION()
        {
            /*" -4721- MOVE 'R4100-00-NUMERA-CERTIF' TO PARAGRAFO. */
            _.Move("R4100-00-NUMERA-CERTIF", FILLER_1.WABEND.PARAGRAFO);

            /*" -4722- MOVE '4100' TO WNR-EXEC-SQL. */
            _.Move("4100", FILLER_1.WABEND.WNR_EXEC_SQL);

            /*" -4724- DISPLAY PARAGRAFO */
            _.Display(FILLER_1.WABEND.PARAGRAFO);

            /*" -4727- ADD 1 TO NUMEROUT-NUM-CERT-VGAP. */
            NUMEROUT.DCLNUMERO_OUTROS.NUMEROUT_NUM_CERT_VGAP.Value = NUMEROUT.DCLNUMERO_OUTROS.NUMEROUT_NUM_CERT_VGAP + 1;

            /*" -4731- MOVE NUMEROUT-NUM-CERT-VGAP TO WCERTIFICADO MOVIMVGA-NUM-CERTIFICADO. */
            _.Move(NUMEROUT.DCLNUMERO_OUTROS.NUMEROUT_NUM_CERT_VGAP, WS_PARAMETROS.W01DIGCERT.WCERTIFICADO, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_NUM_CERTIFICADO);

            /*" -4733- CALL 'PROM1101' USING W01DIGCERT. */
            _.Call("PROM1101", WS_PARAMETROS.W01DIGCERT);

            /*" -4735- MOVE WDIG TO WHOST-DAC-CERTIFICADO MOVIMVGA-DAC-CERTIFICADO. */
            _.Move(WS_PARAMETROS.W01DIGCERT.WDIG, WHOST_DAC_CERTIFICADO, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DAC_CERTIFICADO);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4100_99_SAIDA*/

        [StopWatch]
        /*" R4200-00-GRAVA-CLIENTES-SECTION */
        private void R4200_00_GRAVA_CLIENTES_SECTION()
        {
            /*" -4744- MOVE 'R4200-00-GRAVA-CLIENTES' TO PARAGRAFO. */
            _.Move("R4200-00-GRAVA-CLIENTES", FILLER_1.WABEND.PARAGRAFO);

            /*" -4745- MOVE '4200' TO WNR-EXEC-SQL. */
            _.Move("4200", FILLER_1.WABEND.WNR_EXEC_SQL);

            /*" -4747- DISPLAY PARAGRAFO */
            _.Display(FILLER_1.WABEND.PARAGRAFO);

            /*" -4749- PERFORM R4210-00-MOVE-CLIENTE. */

            R4210_00_MOVE_CLIENTE_SECTION();

            /*" -4750- IF WS-JA-TEM-CODIGO EQUAL 'S' */

            if (WS_JA_TEM_CODIGO == "S")
            {

                /*" -4751- PERFORM R4220-00-TRATA-SEXO-CLIENTE */

                R4220_00_TRATA_SEXO_CLIENTE_SECTION();

                /*" -4751- GO TO R4200-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R4200_99_SAIDA*/ //GOTO
                return;
            }


            /*" -0- FLUXCONTROL_PERFORM R4200_10_GRAVA_CLIENTES */

            R4200_10_GRAVA_CLIENTES();

        }

        [StopWatch]
        /*" R4200-10-GRAVA-CLIENTES */
        private void R4200_10_GRAVA_CLIENTES(bool isPerform = false)
        {
            /*" -4758- ADD 1 TO NUMEROUT-NUM-CLIENTE. */
            NUMEROUT.DCLNUMERO_OUTROS.NUMEROUT_NUM_CLIENTE.Value = NUMEROUT.DCLNUMERO_OUTROS.NUMEROUT_NUM_CLIENTE + 1;

            /*" -4762- MOVE NUMEROUT-NUM-CLIENTE TO CLIENTES-COD-CLIENTE. */
            _.Move(NUMEROUT.DCLNUMERO_OUTROS.NUMEROUT_NUM_CLIENTE, CLIENTES.DCLCLIENTES.CLIENTES_COD_CLIENTE);

            /*" -4763- MOVE 34 TO W01-I */
            _.Move(34, FILLER_0.W01_I);

            /*" -4764- MOVE 'R4200-INSERT CLIENTES  ' TO W01-TEXTO(W01-I) */
            _.Move("R4200-INSERT CLIENTES  ", FILLER_0.W01_TABELA_TEXTO.W01_TAB_TEXTO[FILLER_0.W01_I].W01_TEXTO);

            /*" -4768- PERFORM R8900-TOTALIZA-INICIO THRU R8900-TOTALIZA-INICIO-EXIT */

            R8900_TOTALIZA_INICIO_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8900_TOTALIZA_INICIO_EXIT*/


            /*" -4804- PERFORM R4200_10_GRAVA_CLIENTES_DB_INSERT_1 */

            R4200_10_GRAVA_CLIENTES_DB_INSERT_1();

            /*" -4808- MOVE 1 TO W01-QTD-ACC-OK */
            _.Move(1, FILLER_0.W01_QTD_ACC_OK);

            /*" -4812- PERFORM R8910-TOTALIZA-FINAL THRU R8910-TOTALIZA-FINAL-EXIT */

            R8910_TOTALIZA_FINAL_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8910_TOTALIZA_FINAL_EXIT*/


            /*" -4813- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4814- IF SQLCODE EQUAL -803 */

                if (DB.SQLCODE == -803)
                {

                    /*" -4815- GO TO R4200-10-GRAVA-CLIENTES */
                    new Task(() => R4200_10_GRAVA_CLIENTES()).RunSynchronously(); //GOTO
                    return;//Recursividade detectada, cuidado...

                    /*" -4816- ELSE */
                }
                else
                {


                    /*" -4818- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -4818- ADD 1 TO AC-GRAVA-C. */
            FILLER_1.AC_GRAVA_C.Value = FILLER_1.AC_GRAVA_C + 1;

        }

        [StopWatch]
        /*" R4200-10-GRAVA-CLIENTES-DB-INSERT-1 */
        public void R4200_10_GRAVA_CLIENTES_DB_INSERT_1()
        {
            /*" -4804- EXEC SQL INSERT INTO SEGUROS.CLIENTES (COD_CLIENTE , NOME_RAZAO , TIPO_PESSOA , CGCCPF , SIT_REGISTRO , DATA_NASCIMENTO , COD_EMPRESA , COD_PORTE_EMP , COD_NATUREZA_ATIV , COD_RAMO_ATIVIDADE , COD_ATIVIDADE , IDE_SEXO , ESTADO_CIVIL , COD_GRD_GRUPO_CBO , COD_SUBGRUPO_CBO , COD_GRUPO_BASE_CBO , COD_SUBGR_BASE_CBO) VALUES (:CLIENTES-COD-CLIENTE, :CLIENTES-NOME-RAZAO, :CLIENTES-TIPO-PESSOA, :CLIENTES-CGCCPF, :CLIENTES-SIT-REGISTRO, :CLIENTES-DATA-NASCIMENTO, :CLIENTES-COD-EMPRESA, NULL , NULL , NULL , NULL , :CLIENTES-IDE-SEXO , :CLIENTES-ESTADO-CIVIL , NULL , NULL , NULL , NULL) END-EXEC. */

            var r4200_10_GRAVA_CLIENTES_DB_INSERT_1_Insert1 = new R4200_10_GRAVA_CLIENTES_DB_INSERT_1_Insert1()
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

            R4200_10_GRAVA_CLIENTES_DB_INSERT_1_Insert1.Execute(r4200_10_GRAVA_CLIENTES_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4200_99_SAIDA*/

        [StopWatch]
        /*" R4210-00-MOVE-CLIENTE-SECTION */
        private void R4210_00_MOVE_CLIENTE_SECTION()
        {
            /*" -4827- MOVE 'R4210-00-MOVE-CLIENTE' TO PARAGRAFO. */
            _.Move("R4210-00-MOVE-CLIENTE", FILLER_1.WABEND.PARAGRAFO);

            /*" -4828- MOVE '4210' TO WNR-EXEC-SQL. */
            _.Move("4210", FILLER_1.WABEND.WNR_EXEC_SQL);

            /*" -4830- DISPLAY PARAGRAFO */
            _.Display(FILLER_1.WABEND.PARAGRAFO);

            /*" -4832- MOVE ZEROS TO CLIENTES-COD-CLIENTE. */
            _.Move(0, CLIENTES.DCLCLIENTES.CLIENTES_COD_CLIENTE);

            /*" -4835- MOVE 'N' TO WS-JA-TEM-CODIGO. */
            _.Move("N", WS_JA_TEM_CODIGO);

            /*" -4837- MOVE NOME-SOR TO CLIENTES-NOME-RAZAO */
            _.Move(REGISTRO_SORT.NOME_SOR, CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO);

            /*" -4839- MOVE 'F' TO CLIENTES-TIPO-PESSOA */
            _.Move("F", CLIENTES.DCLCLIENTES.CLIENTES_TIPO_PESSOA);

            /*" -4841- MOVE CPF-SOR TO CLIENTES-CGCCPF */
            _.Move(REGISTRO_SORT.CPF_SOR, CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF);

            /*" -4843- MOVE '0' TO CLIENTES-SIT-REGISTRO */
            _.Move("0", CLIENTES.DCLCLIENTES.CLIENTES_SIT_REGISTRO);

            /*" -4845- MOVE DTNAS-AA-SOR TO WS-W02AASQL */
            _.Move(REGISTRO_SORT.DTNAS_SOR.DTNAS_AA_SOR, FILLER_1.WS_W02DTSQL.WS_W02AASQL);

            /*" -4847- MOVE DTNAS-MM-SOR TO WS-W02MMSQL */
            _.Move(REGISTRO_SORT.DTNAS_SOR.DTNAS_MM_SOR, FILLER_1.WS_W02DTSQL.WS_W02MMSQL);

            /*" -4849- MOVE DTNAS-DD-SOR TO WS-W02DDSQL */
            _.Move(REGISTRO_SORT.DTNAS_SOR.DTNAS_DD_SOR, FILLER_1.WS_W02DTSQL.WS_W02DDSQL);

            /*" -4851- MOVE WS-W02DTSQL TO CLIENTES-DATA-NASCIMENTO. */
            _.Move(FILLER_1.WS_W02DTSQL, CLIENTES.DCLCLIENTES.CLIENTES_DATA_NASCIMENTO);

            /*" -4853- MOVE 0 TO CLIENTES-COD-EMPRESA */
            _.Move(0, CLIENTES.DCLCLIENTES.CLIENTES_COD_EMPRESA);

            /*" -4855- MOVE SEXO-SOR TO CLIENTES-IDE-SEXO */
            _.Move(REGISTRO_SORT.SEXO_SOR, CLIENTES.DCLCLIENTES.CLIENTES_IDE_SEXO);

            /*" -4859- MOVE ESTCIV-SOR TO CLIENTES-ESTADO-CIVIL. */
            _.Move(REGISTRO_SORT.ESTCIV_SOR, CLIENTES.DCLCLIENTES.CLIENTES_ESTADO_CIVIL);

            /*" -4860- MOVE 35 TO W01-I */
            _.Move(35, FILLER_0.W01_I);

            /*" -4861- MOVE 'R4210-SELECT CLIENTES  ' TO W01-TEXTO(W01-I) */
            _.Move("R4210-SELECT CLIENTES  ", FILLER_0.W01_TABELA_TEXTO.W01_TAB_TEXTO[FILLER_0.W01_I].W01_TEXTO);

            /*" -4865- PERFORM R8900-TOTALIZA-INICIO THRU R8900-TOTALIZA-INICIO-EXIT */

            R8900_TOTALIZA_INICIO_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8900_TOTALIZA_INICIO_EXIT*/


            /*" -4871- PERFORM R4210_00_MOVE_CLIENTE_DB_SELECT_1 */

            R4210_00_MOVE_CLIENTE_DB_SELECT_1();

            /*" -4875- MOVE 1 TO W01-QTD-ACC-OK */
            _.Move(1, FILLER_0.W01_QTD_ACC_OK);

            /*" -4879- PERFORM R8910-TOTALIZA-FINAL THRU R8910-TOTALIZA-FINAL-EXIT */

            R8910_TOTALIZA_FINAL_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8910_TOTALIZA_FINAL_EXIT*/


            /*" -4880- IF CLIENTES-COD-CLIENTE EQUAL ZEROS */

            if (CLIENTES.DCLCLIENTES.CLIENTES_COD_CLIENTE == 00)
            {

                /*" -4881- MOVE 'N' TO WS-JA-TEM-CODIGO */
                _.Move("N", WS_JA_TEM_CODIGO);

                /*" -4882- ELSE */
            }
            else
            {


                /*" -4883- MOVE 'S' TO WS-JA-TEM-CODIGO */
                _.Move("S", WS_JA_TEM_CODIGO);

                /*" -4883- END-IF. */
            }


        }

        [StopWatch]
        /*" R4210-00-MOVE-CLIENTE-DB-SELECT-1 */
        public void R4210_00_MOVE_CLIENTE_DB_SELECT_1()
        {
            /*" -4871- EXEC SQL SELECT VALUE(MAX(COD_CLIENTE),0) INTO :CLIENTES-COD-CLIENTE FROM SEGUROS.CLIENTES WHERE CGCCPF = :CLIENTES-CGCCPF AND DATA_NASCIMENTO = :CLIENTES-DATA-NASCIMENTO END-EXEC. */

            var r4210_00_MOVE_CLIENTE_DB_SELECT_1_Query1 = new R4210_00_MOVE_CLIENTE_DB_SELECT_1_Query1()
            {
                CLIENTES_DATA_NASCIMENTO = CLIENTES.DCLCLIENTES.CLIENTES_DATA_NASCIMENTO.ToString(),
                CLIENTES_CGCCPF = CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF.ToString(),
            };

            var executed_1 = R4210_00_MOVE_CLIENTE_DB_SELECT_1_Query1.Execute(r4210_00_MOVE_CLIENTE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CLIENTES_COD_CLIENTE, CLIENTES.DCLCLIENTES.CLIENTES_COD_CLIENTE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4210_99_SAIDA*/

        [StopWatch]
        /*" R4220-00-TRATA-SEXO-CLIENTE-SECTION */
        private void R4220_00_TRATA_SEXO_CLIENTE_SECTION()
        {
            /*" -4892- MOVE 'R4220-00-TRATA-SEXO-CLIENTE' TO PARAGRAFO. */
            _.Move("R4220-00-TRATA-SEXO-CLIENTE", FILLER_1.WABEND.PARAGRAFO);

            /*" -4893- MOVE '4220' TO WNR-EXEC-SQL. */
            _.Move("4220", FILLER_1.WABEND.WNR_EXEC_SQL);

            /*" -4896- DISPLAY PARAGRAFO */
            _.Display(FILLER_1.WABEND.PARAGRAFO);

            /*" -4897- MOVE 36 TO W01-I */
            _.Move(36, FILLER_0.W01_I);

            /*" -4898- MOVE 'R4220-SELECT CLIENTES  ' TO W01-TEXTO(W01-I) */
            _.Move("R4220-SELECT CLIENTES  ", FILLER_0.W01_TABELA_TEXTO.W01_TAB_TEXTO[FILLER_0.W01_I].W01_TEXTO);

            /*" -4902- PERFORM R8900-TOTALIZA-INICIO THRU R8900-TOTALIZA-INICIO-EXIT */

            R8900_TOTALIZA_INICIO_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8900_TOTALIZA_INICIO_EXIT*/


            /*" -4908- PERFORM R4220_00_TRATA_SEXO_CLIENTE_DB_SELECT_1 */

            R4220_00_TRATA_SEXO_CLIENTE_DB_SELECT_1();

            /*" -4912- MOVE 1 TO W01-QTD-ACC-OK */
            _.Move(1, FILLER_0.W01_QTD_ACC_OK);

            /*" -4916- PERFORM R8910-TOTALIZA-FINAL THRU R8910-TOTALIZA-FINAL-EXIT */

            R8910_TOTALIZA_FINAL_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8910_TOTALIZA_FINAL_EXIT*/


            /*" -4918- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4919- DISPLAY 'ERRO ACESSO CLIENTES' */
                _.Display($"ERRO ACESSO CLIENTES");

                /*" -4920- DISPLAY 'CLIENTE = ' CLIENTES-COD-CLIENTE */
                _.Display($"CLIENTE = {CLIENTES.DCLCLIENTES.CLIENTES_COD_CLIENTE}");

                /*" -4922- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -4923- IF CLIENTES-IDE-SEXO NOT EQUAL SEXO-SOR */

            if (CLIENTES.DCLCLIENTES.CLIENTES_IDE_SEXO != REGISTRO_SORT.SEXO_SOR)
            {

                /*" -4926- MOVE SEXO-SOR TO CLIENTES-IDE-SEXO */
                _.Move(REGISTRO_SORT.SEXO_SOR, CLIENTES.DCLCLIENTES.CLIENTES_IDE_SEXO);

                /*" -4927- MOVE 37 TO W01-I */
                _.Move(37, FILLER_0.W01_I);

                /*" -4928- MOVE 'R4220-UPDATE CLIENTES  ' TO W01-TEXTO(W01-I) */
                _.Move("R4220-UPDATE CLIENTES  ", FILLER_0.W01_TABELA_TEXTO.W01_TAB_TEXTO[FILLER_0.W01_I].W01_TEXTO);

                /*" -4931- PERFORM R8900-TOTALIZA-INICIO THRU R8900-TOTALIZA-INICIO-EXIT */

                R8900_TOTALIZA_INICIO_SECTION();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R8900_TOTALIZA_INICIO_EXIT*/


                /*" -4935- PERFORM R4220_00_TRATA_SEXO_CLIENTE_DB_UPDATE_1 */

                R4220_00_TRATA_SEXO_CLIENTE_DB_UPDATE_1();

                /*" -4939- MOVE 1 TO W01-QTD-ACC-OK */
                _.Move(1, FILLER_0.W01_QTD_ACC_OK);

                /*" -4942- PERFORM R8910-TOTALIZA-FINAL THRU R8910-TOTALIZA-FINAL-EXIT */

                R8910_TOTALIZA_FINAL_SECTION();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R8910_TOTALIZA_FINAL_EXIT*/


                /*" -4943- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -4944- DISPLAY 'ERRO UPDATE CLIENTES' */
                    _.Display($"ERRO UPDATE CLIENTES");

                    /*" -4945- DISPLAY 'CLIENTE = ' CLIENTES-COD-CLIENTE */
                    _.Display($"CLIENTE = {CLIENTES.DCLCLIENTES.CLIENTES_COD_CLIENTE}");

                    /*" -4946- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -4947- END-IF */
                }


                /*" -4947- END-IF. */
            }


        }

        [StopWatch]
        /*" R4220-00-TRATA-SEXO-CLIENTE-DB-SELECT-1 */
        public void R4220_00_TRATA_SEXO_CLIENTE_DB_SELECT_1()
        {
            /*" -4908- EXEC SQL SELECT IFNULL(IDE_SEXO, ' ' ) INTO :CLIENTES-IDE-SEXO FROM SEGUROS.CLIENTES WHERE COD_CLIENTE = :CLIENTES-COD-CLIENTE WITH UR END-EXEC. */

            var r4220_00_TRATA_SEXO_CLIENTE_DB_SELECT_1_Query1 = new R4220_00_TRATA_SEXO_CLIENTE_DB_SELECT_1_Query1()
            {
                CLIENTES_COD_CLIENTE = CLIENTES.DCLCLIENTES.CLIENTES_COD_CLIENTE.ToString(),
            };

            var executed_1 = R4220_00_TRATA_SEXO_CLIENTE_DB_SELECT_1_Query1.Execute(r4220_00_TRATA_SEXO_CLIENTE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CLIENTES_IDE_SEXO, CLIENTES.DCLCLIENTES.CLIENTES_IDE_SEXO);
            }


        }

        [StopWatch]
        /*" R4220-00-TRATA-SEXO-CLIENTE-DB-UPDATE-1 */
        public void R4220_00_TRATA_SEXO_CLIENTE_DB_UPDATE_1()
        {
            /*" -4935- EXEC SQL UPDATE SEGUROS.CLIENTES SET IDE_SEXO = :CLIENTES-IDE-SEXO WHERE COD_CLIENTE = :CLIENTES-COD-CLIENTE END-EXEC */

            var r4220_00_TRATA_SEXO_CLIENTE_DB_UPDATE_1_Update1 = new R4220_00_TRATA_SEXO_CLIENTE_DB_UPDATE_1_Update1()
            {
                CLIENTES_IDE_SEXO = CLIENTES.DCLCLIENTES.CLIENTES_IDE_SEXO.ToString(),
                CLIENTES_COD_CLIENTE = CLIENTES.DCLCLIENTES.CLIENTES_COD_CLIENTE.ToString(),
            };

            R4220_00_TRATA_SEXO_CLIENTE_DB_UPDATE_1_Update1.Execute(r4220_00_TRATA_SEXO_CLIENTE_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4220_99_SAIDA*/

        [StopWatch]
        /*" R4300-00-INSERT-ENDERECO-SECTION */
        private void R4300_00_INSERT_ENDERECO_SECTION()
        {
            /*" -4956- MOVE 'R4300-00-INSERT-ENDERECO' TO PARAGRAFO. */
            _.Move("R4300-00-INSERT-ENDERECO", FILLER_1.WABEND.PARAGRAFO);

            /*" -4957- MOVE '4300' TO WNR-EXEC-SQL. */
            _.Move("4300", FILLER_1.WABEND.WNR_EXEC_SQL);

            /*" -4959- DISPLAY PARAGRAFO */
            _.Display(FILLER_1.WABEND.PARAGRAFO);

            /*" -4962- MOVE WHOST-ENDERECO TO ENDERECO-ENDERECO */
            _.Move(WHOST_ENDERECO, ENDERECO.DCLENDERECOS.ENDERECO_ENDERECO);

            /*" -4964- MOVE WHOST-BAIRRO TO ENDERECO-BAIRRO */
            _.Move(WHOST_BAIRRO, ENDERECO.DCLENDERECOS.ENDERECO_BAIRRO);

            /*" -4966- MOVE WHOST-CIDADE TO ENDERECO-CIDADE */
            _.Move(WHOST_CIDADE, ENDERECO.DCLENDERECOS.ENDERECO_CIDADE);

            /*" -4968- MOVE WHOST-SIGLA-UF TO ENDERECO-SIGLA-UF */
            _.Move(WHOST_SIGLA_UF, ENDERECO.DCLENDERECOS.ENDERECO_SIGLA_UF);

            /*" -4972- MOVE WHOST-CEP TO ENDERECO-CEP. */
            _.Move(WHOST_CEP, ENDERECO.DCLENDERECOS.ENDERECO_CEP);

            /*" -4973- MOVE 38 TO W01-I */
            _.Move(38, FILLER_0.W01_I);

            /*" -4974- MOVE 'R4300-SELECT ENDERECOS ' TO W01-TEXTO(W01-I) */
            _.Move("R4300-SELECT ENDERECOS ", FILLER_0.W01_TABELA_TEXTO.W01_TAB_TEXTO[FILLER_0.W01_I].W01_TEXTO);

            /*" -4978- PERFORM R8900-TOTALIZA-INICIO THRU R8900-TOTALIZA-INICIO-EXIT */

            R8900_TOTALIZA_INICIO_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8900_TOTALIZA_INICIO_EXIT*/


            /*" -4983- PERFORM R4300_00_INSERT_ENDERECO_DB_SELECT_1 */

            R4300_00_INSERT_ENDERECO_DB_SELECT_1();

            /*" -4987- MOVE 1 TO W01-QTD-ACC-OK */
            _.Move(1, FILLER_0.W01_QTD_ACC_OK);

            /*" -4991- PERFORM R8910-TOTALIZA-FINAL THRU R8910-TOTALIZA-FINAL-EXIT */

            R8910_TOTALIZA_FINAL_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8910_TOTALIZA_FINAL_EXIT*/


            /*" -4992- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4993- DISPLAY 'ERRO DE ACESSO A ENDERECOS (MAX) ' */
                _.Display($"ERRO DE ACESSO A ENDERECOS (MAX) ");

                /*" -4994- DISPLAY 'CODCLI    = ' CLIENTES-COD-CLIENTE */
                _.Display($"CODCLI    = {CLIENTES.DCLCLIENTES.CLIENTES_COD_CLIENTE}");

                /*" -4996- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -4998- MOVE 1 TO ENDERECO-COD-ENDERECO. */
            _.Move(1, ENDERECO.DCLENDERECOS.ENDERECO_COD_ENDERECO);

            /*" -5000- ADD 1 TO ENDERECO-OCORR-ENDERECO. */
            ENDERECO.DCLENDERECOS.ENDERECO_OCORR_ENDERECO.Value = ENDERECO.DCLENDERECOS.ENDERECO_OCORR_ENDERECO + 1;

            /*" -5002- MOVE WHOST-DDD TO ENDERECO-DDD */
            _.Move(WHOST_DDD, ENDERECO.DCLENDERECOS.ENDERECO_DDD);

            /*" -5004- MOVE WHOST-TELEFONE TO ENDERECO-TELEFONE */
            _.Move(WHOST_TELEFONE, ENDERECO.DCLENDERECOS.ENDERECO_TELEFONE);

            /*" -5007- MOVE ZEROS TO ENDERECO-FAX ENDERECO-TELEX */
            _.Move(0, ENDERECO.DCLENDERECOS.ENDERECO_FAX, ENDERECO.DCLENDERECOS.ENDERECO_TELEX);

            /*" -5009- MOVE '0' TO ENDERECO-SIT-REGISTRO */
            _.Move("0", ENDERECO.DCLENDERECOS.ENDERECO_SIT_REGISTRO);

            /*" -5013- MOVE 0 TO ENDERECO-COD-EMPRESA. */
            _.Move(0, ENDERECO.DCLENDERECOS.ENDERECO_COD_EMPRESA);

            /*" -5014- MOVE 39 TO W01-I */
            _.Move(39, FILLER_0.W01_I);

            /*" -5015- MOVE 'R4300-INSERT ENDERECOS ' TO W01-TEXTO(W01-I) */
            _.Move("R4300-INSERT ENDERECOS ", FILLER_0.W01_TABELA_TEXTO.W01_TAB_TEXTO[FILLER_0.W01_I].W01_TEXTO);

            /*" -5019- PERFORM R8900-TOTALIZA-INICIO THRU R8900-TOTALIZA-INICIO-EXIT */

            R8900_TOTALIZA_INICIO_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8900_TOTALIZA_INICIO_EXIT*/


            /*" -5049- PERFORM R4300_00_INSERT_ENDERECO_DB_INSERT_1 */

            R4300_00_INSERT_ENDERECO_DB_INSERT_1();

            /*" -5053- MOVE 1 TO W01-QTD-ACC-OK */
            _.Move(1, FILLER_0.W01_QTD_ACC_OK);

            /*" -5057- PERFORM R8910-TOTALIZA-FINAL THRU R8910-TOTALIZA-FINAL-EXIT */

            R8910_TOTALIZA_FINAL_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8910_TOTALIZA_FINAL_EXIT*/


            /*" -5058- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5059- DISPLAY 'ERRO INSERT ENDERECOS' */
                _.Display($"ERRO INSERT ENDERECOS");

                /*" -5060- DISPLAY 'CLIENTE.....' CLIENTES-COD-CLIENTE */
                _.Display($"CLIENTE.....{CLIENTES.DCLCLIENTES.CLIENTES_COD_CLIENTE}");

                /*" -5062- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -5062- ADD 1 TO AC-GRAVA-E. */
            FILLER_1.AC_GRAVA_E.Value = FILLER_1.AC_GRAVA_E + 1;

        }

        [StopWatch]
        /*" R4300-00-INSERT-ENDERECO-DB-SELECT-1 */
        public void R4300_00_INSERT_ENDERECO_DB_SELECT_1()
        {
            /*" -4983- EXEC SQL SELECT VALUE(MAX(OCORR_ENDERECO),0) INTO :ENDERECO-OCORR-ENDERECO FROM SEGUROS.ENDERECOS WHERE COD_CLIENTE = :CLIENTES-COD-CLIENTE END-EXEC. */

            var r4300_00_INSERT_ENDERECO_DB_SELECT_1_Query1 = new R4300_00_INSERT_ENDERECO_DB_SELECT_1_Query1()
            {
                CLIENTES_COD_CLIENTE = CLIENTES.DCLCLIENTES.CLIENTES_COD_CLIENTE.ToString(),
            };

            var executed_1 = R4300_00_INSERT_ENDERECO_DB_SELECT_1_Query1.Execute(r4300_00_INSERT_ENDERECO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.ENDERECO_OCORR_ENDERECO, ENDERECO.DCLENDERECOS.ENDERECO_OCORR_ENDERECO);
            }


        }

        [StopWatch]
        /*" R4300-00-INSERT-ENDERECO-DB-INSERT-1 */
        public void R4300_00_INSERT_ENDERECO_DB_INSERT_1()
        {
            /*" -5049- EXEC SQL INSERT INTO SEGUROS.ENDERECOS (COD_CLIENTE, COD_ENDERECO, OCORR_ENDERECO, ENDERECO, BAIRRO, CIDADE, SIGLA_UF, CEP, DDD, TELEFONE, FAX, TELEX, SIT_REGISTRO, COD_EMPRESA) VALUES (:CLIENTES-COD-CLIENTE, :ENDERECO-COD-ENDERECO, :ENDERECO-OCORR-ENDERECO, :ENDERECO-ENDERECO, :ENDERECO-BAIRRO, :ENDERECO-CIDADE, :ENDERECO-SIGLA-UF, :ENDERECO-CEP, :ENDERECO-DDD, :ENDERECO-TELEFONE, :ENDERECO-FAX, :ENDERECO-TELEX, :ENDERECO-SIT-REGISTRO, :ENDERECO-COD-EMPRESA) END-EXEC. */

            var r4300_00_INSERT_ENDERECO_DB_INSERT_1_Insert1 = new R4300_00_INSERT_ENDERECO_DB_INSERT_1_Insert1()
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
                ENDERECO_SIT_REGISTRO = ENDERECO.DCLENDERECOS.ENDERECO_SIT_REGISTRO.ToString(),
                ENDERECO_COD_EMPRESA = ENDERECO.DCLENDERECOS.ENDERECO_COD_EMPRESA.ToString(),
            };

            R4300_00_INSERT_ENDERECO_DB_INSERT_1_Insert1.Execute(r4300_00_INSERT_ENDERECO_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4300_99_SAIDA*/

        [StopWatch]
        /*" R4400-00-INSERT-MOVIMVGA-SECTION */
        private void R4400_00_INSERT_MOVIMVGA_SECTION()
        {
            /*" -5071- MOVE 'R4400-00-INSERT-MOVIMVGA' TO PARAGRAFO. */
            _.Move("R4400-00-INSERT-MOVIMVGA", FILLER_1.WABEND.PARAGRAFO);

            /*" -5072- MOVE '4400' TO WNR-EXEC-SQL. */
            _.Move("4400", FILLER_1.WABEND.WNR_EXEC_SQL);

            /*" -5074- DISPLAY PARAGRAFO */
            _.Display(FILLER_1.WABEND.PARAGRAFO);

            /*" -5075- PERFORM R3230-00-SELECT-FONTE. */

            R3230_00_SELECT_FONTE_SECTION();

            /*" -5077- PERFORM R3240-00-UPDATE-FONTE. */

            R3240_00_UPDATE_FONTE_SECTION();

            /*" -5088- MOVE ZEROS TO MOVIMVGA-IMP-MORNATU-ANT MOVIMVGA-IMP-MORACID-ANT MOVIMVGA-IMP-INVPERM-ANT MOVIMVGA-IMP-AMDS-ANT MOVIMVGA-IMP-DH-ANT MOVIMVGA-IMP-DIT-ANT MOVIMVGA-IMP-DH-ANT MOVIMVGA-PRM-VG-ANT MOVIMVGA-PRM-AP-ANT */
            _.Move(0, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_MORNATU_ANT, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_MORACID_ANT, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_INVPERM_ANT, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_AMDS_ANT, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_DH_ANT, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_DIT_ANT, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_DH_ANT, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PRM_VG_ANT, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PRM_AP_ANT);

            /*" -5090- MOVE CONDITEC-QTD-SAL-MORNATU TO MOVIMVGA-QTD-SAL-MORNATU */
            _.Move(CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_QTD_SAL_MORNATU, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_QTD_SAL_MORNATU);

            /*" -5092- MOVE CONDITEC-QTD-SAL-MORACID TO MOVIMVGA-QTD-SAL-MORACID */
            _.Move(CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_QTD_SAL_MORACID, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_QTD_SAL_MORACID);

            /*" -5094- MOVE CONDITEC-QTD-SAL-INVPERM TO MOVIMVGA-QTD-SAL-INVPERM */
            _.Move(CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_QTD_SAL_INVPERM, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_QTD_SAL_INVPERM);

            /*" -5096- MOVE CONDITEC-TAXA-AP-MORACID TO MOVIMVGA-TAXA-AP-MORACID */
            _.Move(CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_TAXA_AP_MORACID, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_TAXA_AP_MORACID);

            /*" -5098- MOVE CONDITEC-TAXA-AP-INVPERM TO MOVIMVGA-TAXA-AP-INVPERM */
            _.Move(CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_TAXA_AP_INVPERM, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_TAXA_AP_INVPERM);

            /*" -5100- MOVE CONDITEC-TAXA-AP-AMDS TO MOVIMVGA-TAXA-AP-AMDS */
            _.Move(CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_TAXA_AP_AMDS, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_TAXA_AP_AMDS);

            /*" -5102- MOVE CONDITEC-TAXA-AP-DH TO MOVIMVGA-TAXA-AP-DH */
            _.Move(CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_TAXA_AP_DH, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_TAXA_AP_DH);

            /*" -5105- MOVE CONDITEC-TAXA-AP-DIT TO MOVIMVGA-TAXA-AP-DIT. */
            _.Move(CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_TAXA_AP_DIT, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_TAXA_AP_DIT);

            /*" -5107- MOVE 1 TO MOVIMVGA-FAIXA */
            _.Move(1, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_FAIXA);

            /*" -5109- MOVE ZEROS TO MOVIMVGA-TAXA-VG. */
            _.Move(0, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_TAXA_VG);

            /*" -5111- MOVE SUBGVGAP-NUM-APOLICE TO MOVIMVGA-NUM-APOLICE */
            _.Move(SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_NUM_APOLICE, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_NUM_APOLICE);

            /*" -5113- MOVE SUBGVGAP-COD-SUBGRUPO TO MOVIMVGA-COD-SUBGRUPO */
            _.Move(SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_SUBGRUPO, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_SUBGRUPO);

            /*" -5116- MOVE SUBGVGAP-COD-FONTE TO MOVIMVGA-COD-FONTE */
            _.Move(SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_FONTE, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_FONTE);

            /*" -5118- MOVE WHOST-PROP-AUTOMAT TO MOVIMVGA-NUM-PROPOSTA */
            _.Move(WHOST_PROP_AUTOMAT, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_NUM_PROPOSTA);

            /*" -5120- MOVE '1' TO MOVIMVGA-TIPO-SEGURADO */
            _.Move("1", MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_TIPO_SEGURADO);

            /*" -5122- MOVE '1' TO MOVIMVGA-TIPO-INCLUSAO */
            _.Move("1", MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_TIPO_INCLUSAO);

            /*" -5124- MOVE CLIENTES-COD-CLIENTE TO MOVIMVGA-COD-CLIENTE */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_COD_CLIENTE, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_CLIENTE);

            /*" -5126- MOVE 999105 TO MOVIMVGA-COD-AGENCIADOR */
            _.Move(999105, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_AGENCIADOR);

            /*" -5128- MOVE 0 TO MOVIMVGA-COD-CORRETOR */
            _.Move(0, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_CORRETOR);

            /*" -5130- MOVE 0 TO MOVIMVGA-COD-PLANOVGAP */
            _.Move(0, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_PLANOVGAP);

            /*" -5132- MOVE 0 TO MOVIMVGA-COD-PLANOAP */
            _.Move(0, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_PLANOAP);

            /*" -5134- MOVE 'S' TO MOVIMVGA-AUTOR-AUM-AUTOMAT */
            _.Move("S", MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_AUTOR_AUM_AUTOMAT);

            /*" -5136- MOVE 'N' TO MOVIMVGA-TIPO-BENEFICIARIO */
            _.Move("N", MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_TIPO_BENEFICIARIO);

            /*" -5138- MOVE SUBGVGAP-PERI-FATURAMENTO TO MOVIMVGA-PERI-PAGAMENTO */
            _.Move(SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_PERI_FATURAMENTO, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PERI_PAGAMENTO);

            /*" -5140- MOVE SUBGVGAP-PERI-RENOVACAO TO MOVIMVGA-PERI-RENOVACAO */
            _.Move(SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_PERI_RENOVACAO, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PERI_RENOVACAO);

            /*" -5142- MOVE ' ' TO MOVIMVGA-COD-OCUPACAO */
            _.Move(" ", MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OCUPACAO);

            /*" -5144- MOVE ESTCIV-SOR TO MOVIMVGA-ESTADO-CIVIL */
            _.Move(REGISTRO_SORT.ESTCIV_SOR, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_ESTADO_CIVIL);

            /*" -5146- MOVE SEXO-SOR TO MOVIMVGA-IDE-SEXO */
            _.Move(REGISTRO_SORT.SEXO_SOR, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IDE_SEXO);

            /*" -5150- MOVE 9999 TO MOVIMVGA-COD-PROFISSAO */
            _.Move(9999, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_PROFISSAO);

            /*" -5152- MOVE ' ' TO MOVIMVGA-NATURALIDADE */
            _.Move(" ", MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_NATURALIDADE);

            /*" -5154- MOVE ENDERECO-OCORR-ENDERECO TO MOVIMVGA-OCORR-ENDERECO */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_OCORR_ENDERECO, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_OCORR_ENDERECO);

            /*" -5156- MOVE ENDERECO-OCORR-ENDERECO TO MOVIMVGA-OCORR-END-COBRAN */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_OCORR_ENDERECO, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_OCORR_END_COBRAN);

            /*" -5158- MOVE SUBGVGAP-BCO-COBRANCA TO MOVIMVGA-BCO-COBRANCA */
            _.Move(SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_BCO_COBRANCA, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_BCO_COBRANCA);

            /*" -5160- MOVE SUBGVGAP-AGE-COBRANCA TO MOVIMVGA-AGE-COBRANCA */
            _.Move(SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_AGE_COBRANCA, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_AGE_COBRANCA);

            /*" -5164- MOVE SUBGVGAP-DAC-COBRANCA TO MOVIMVGA-DAC-COBRANCA */
            _.Move(SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_DAC_COBRANCA, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DAC_COBRANCA);

            /*" -5166- MOVE 0 TO MOVIMVGA-NUM-MATRICULA */
            _.Move(0, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_NUM_MATRICULA);

            /*" -5170- MOVE 0 TO MOVIMVGA-NUM-CTA-CORRENTE */
            _.Move(0, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_NUM_CTA_CORRENTE);

            /*" -5172- MOVE 0 TO MOVIMVGA-DAC-CTA-CORRENTE */
            _.Move(0, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DAC_CTA_CORRENTE);

            /*" -5174- MOVE 0 TO MOVIMVGA-VAL-SALARIO */
            _.Move(0, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_VAL_SALARIO);

            /*" -5176- MOVE ' ' TO MOVIMVGA-TIPO-SALARIO */
            _.Move(" ", MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_TIPO_SALARIO);

            /*" -5178- MOVE SUBGVGAP-TIPO-PLANO TO MOVIMVGA-TIPO-PLANO */
            _.Move(SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_TIPO_PLANO, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_TIPO_PLANO);

            /*" -5180- MOVE SUBGVGAP-PCT-CONJUGE-VG TO MOVIMVGA-PCT-CONJUGE-VG */
            _.Move(SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_PCT_CONJUGE_VG, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PCT_CONJUGE_VG);

            /*" -5182- MOVE SUBGVGAP-PCT-CONJUGE-AP TO MOVIMVGA-PCT-CONJUGE-AP. */
            _.Move(SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_PCT_CONJUGE_AP, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PCT_CONJUGE_AP);

            /*" -5184- MOVE 0 TO MOVIMVGA-IMP-MORNATU-ANT */
            _.Move(0, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_MORNATU_ANT);

            /*" -5186- MOVE 0 TO MOVIMVGA-IMP-MORACID-ANT */
            _.Move(0, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_MORACID_ANT);

            /*" -5188- MOVE 0 TO MOVIMVGA-IMP-INVPERM-ANT */
            _.Move(0, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_INVPERM_ANT);

            /*" -5190- MOVE 0 TO MOVIMVGA-IMP-AMDS-ANT */
            _.Move(0, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_AMDS_ANT);

            /*" -5192- MOVE 0 TO MOVIMVGA-IMP-DH-ANT */
            _.Move(0, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_DH_ANT);

            /*" -5194- MOVE 0 TO MOVIMVGA-IMP-DIT-ANT */
            _.Move(0, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_DIT_ANT);

            /*" -5196- MOVE 0 TO MOVIMVGA-PRM-VG-ANT */
            _.Move(0, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PRM_VG_ANT);

            /*" -5198- MOVE 0 TO MOVIMVGA-PRM-AP-ANT */
            _.Move(0, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PRM_AP_ANT);

            /*" -5200- MOVE SISTEMAS-DATA-MOV-ABERTO TO MOVIMVGA-DATA-OPERACAO */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_OPERACAO);

            /*" -5203- MOVE 0 TO MOVIMVGA-COD-SUBGRUPO-TRANS */
            _.Move(0, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_SUBGRUPO_TRANS);

            /*" -5204- IF (SUBGVGAP-FORMA-AVERBACAO EQUAL '2' ) */

            if ((SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_FORMA_AVERBACAO == "2"))
            {

                /*" -5205- MOVE '1' TO MOVIMVGA-SIT-REGISTRO */
                _.Move("1", MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_SIT_REGISTRO);

                /*" -5206- MOVE SISTEMAS-DATA-MOV-ABERTO TO MOVIMVGA-DATA-AVERBACAO */
                _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_AVERBACAO);

                /*" -5207- MOVE ZEROS TO VIND-DATA-AVERBACAO */
                _.Move(0, VIND_DATA_AVERBACAO);

                /*" -5208- ELSE */
            }
            else
            {


                /*" -5209- MOVE ' ' TO MOVIMVGA-SIT-REGISTRO */
                _.Move(" ", MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_SIT_REGISTRO);

                /*" -5210- MOVE -1 TO VIND-DATA-AVERBACAO */
                _.Move(-1, VIND_DATA_AVERBACAO);

                /*" -5212- END-IF. */
            }


            /*" -5214- MOVE DTNAS-AA-SOR TO WS-W02AASQL */
            _.Move(REGISTRO_SORT.DTNAS_SOR.DTNAS_AA_SOR, FILLER_1.WS_W02DTSQL.WS_W02AASQL);

            /*" -5216- MOVE DTNAS-MM-SOR TO WS-W02MMSQL */
            _.Move(REGISTRO_SORT.DTNAS_SOR.DTNAS_MM_SOR, FILLER_1.WS_W02DTSQL.WS_W02MMSQL);

            /*" -5218- MOVE DTNAS-DD-SOR TO WS-W02DDSQL */
            _.Move(REGISTRO_SORT.DTNAS_SOR.DTNAS_DD_SOR, FILLER_1.WS_W02DTSQL.WS_W02DDSQL);

            /*" -5221- MOVE WS-W02DTSQL TO MOVIMVGA-DATA-NASCIMENTO. */
            _.Move(FILLER_1.WS_W02DTSQL, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_NASCIMENTO);

            /*" -5222- IF (MOVIMVGA-NUM-APOLICE NOT EQUAL WS-NUM-APOLICE-ANT) */

            if ((MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_NUM_APOLICE != WS_NUM_APOLICE_ANT))
            {

                /*" -5223- PERFORM R3235-00-SELECT-ENDOSSOS */

                R3235_00_SELECT_ENDOSSOS_SECTION();

                /*" -5224- MOVE MOVIMVGA-NUM-APOLICE TO WS-NUM-APOLICE-ANT */
                _.Move(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_NUM_APOLICE, WS_NUM_APOLICE_ANT);

                /*" -5226- END-IF. */
            }


            /*" -5227- IF (WS-QTD-DIAS-VIGENCIA IS NEGATIVE) */

            if ((WS_QTD_DIAS_VIGENCIA < 0))
            {

                /*" -5231- MOVE WS-DATA-INIVIGENCIA-APOL TO MOVIMVGA-DATA-REFERENCIA MOVIMVGA-DATA-ADMISSAO */
                _.Move(WS_DATA_INIVIGENCIA_APOL, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_REFERENCIA, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_ADMISSAO);

                /*" -5232- ELSE */
            }
            else
            {


                /*" -5236- MOVE SISTEMAS-DATA-MOV-ABERTO-1 TO MOVIMVGA-DATA-REFERENCIA MOVIMVGA-DATA-ADMISSAO */
                _.Move(SISTEMAS_DATA_MOV_ABERTO_1, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_REFERENCIA, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_ADMISSAO);

                /*" -5239- END-IF. */
            }


            /*" -5242- MOVE DTVIG-SOR TO MOVIMVGA-DATA-MOVIMENTO. */
            _.Move(REGISTRO_SORT.DTVIG_SOR, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_MOVIMENTO);

            /*" -5243- DISPLAY 'CERTIFICADO     = ' MOVIMVGA-NUM-CERTIFICADO */
            _.Display($"CERTIFICADO     = {MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_NUM_CERTIFICADO}");

            /*" -5244- DISPLAY 'DT INI-VIGENCIA = ' MOVIMVGA-DATA-MOVIMENTO */
            _.Display($"DT INI-VIGENCIA = {MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_MOVIMENTO}");

            /*" -5246- DISPLAY 'DT FIM-VIGENCIA = ' MOVIMVGA-DATA-ADMISSAO */
            _.Display($"DT FIM-VIGENCIA = {MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_ADMISSAO}");

            /*" -5248- MOVE 'VG1613B' TO MOVIMVGA-COD-USUARIO */
            _.Move("VG1613B", MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_USUARIO);

            /*" -5250- MOVE 0 TO MOVIMVGA-TAXA-AP-DH */
            _.Move(0, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_TAXA_AP_DH);

            /*" -5252- MOVE 0 TO MOVIMVGA-IMP-DH-ANT */
            _.Move(0, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_DH_ANT);

            /*" -5255- MOVE 0 TO MOVIMVGA-IMP-DH-ATU. */
            _.Move(0, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_DH_ATU);

            /*" -5256- IF SUBGVGAP-TIPO-PLANO = '1' OR '4' */

            if (SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_TIPO_PLANO.In("1", "4"))
            {

                /*" -5258- MOVE 0 TO MOVIMVGA-TAXA-VG */
                _.Move(0, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_TAXA_VG);

                /*" -5259- ELSE */
            }
            else
            {


                /*" -5261- MOVE 0 TO MOVIMVGA-TAXA-VG */
                _.Move(0, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_TAXA_VG);

                /*" -5263- END-IF */
            }


            /*" -5265- MOVE -1 TO VIND-COD-EMPRESA */
            _.Move(-1, VIND_COD_EMPRESA);

            /*" -5268- MOVE ZEROS TO MOVIMVGA-COD-SUBGRUPO-TRANS MOVIMVGA-LOT-EMP-SEGURADO. */
            _.Move(0, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_SUBGRUPO_TRANS, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_LOT_EMP_SEGURADO);

            /*" -5273- MOVE -1 TO VIND-DATA-INCLUSAO VIND-DATA-FATURA */
            _.Move(-1, VIND_DATA_INCLUSAO, VIND_DATA_FATURA);

            /*" -5274- MOVE 40 TO W01-I */
            _.Move(40, FILLER_0.W01_I);

            /*" -5275- MOVE 'R4400-INSERT MOVIMVGA  ' TO W01-TEXTO(W01-I) */
            _.Move("R4400-INSERT MOVIMVGA  ", FILLER_0.W01_TABELA_TEXTO.W01_TAB_TEXTO[FILLER_0.W01_I].W01_TEXTO);

            /*" -5279- PERFORM R8900-TOTALIZA-INICIO THRU R8900-TOTALIZA-INICIO-EXIT */

            R8900_TOTALIZA_INICIO_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8900_TOTALIZA_INICIO_EXIT*/


            /*" -5439- PERFORM R4400_00_INSERT_MOVIMVGA_DB_INSERT_1 */

            R4400_00_INSERT_MOVIMVGA_DB_INSERT_1();

            /*" -5443- MOVE 1 TO W01-QTD-ACC-OK */
            _.Move(1, FILLER_0.W01_QTD_ACC_OK);

            /*" -5447- PERFORM R8910-TOTALIZA-FINAL THRU R8910-TOTALIZA-FINAL-EXIT */

            R8910_TOTALIZA_FINAL_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8910_TOTALIZA_FINAL_EXIT*/


            /*" -5448- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -5449- IF SQLCODE EQUAL -803 */

                if (DB.SQLCODE == -803)
                {

                    /*" -5450- GO TO R4400-00-INSERT-MOVIMVGA */
                    new Task(() => R4400_00_INSERT_MOVIMVGA_SECTION()).RunSynchronously(); //GOTO
                    return;//Recursividade detectada, cuidado...

                    /*" -5451- ELSE */
                }
                else
                {


                    /*" -5453- DISPLAY 'VG1613B - PROBLEMAS NA INCLUSAO MOVIMVGA ' MOVIMVGA-NUM-CERTIFICADO */
                    _.Display($"VG1613B - PROBLEMAS NA INCLUSAO MOVIMVGA {MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_NUM_CERTIFICADO}");

                    /*" -5454- DISPLAY 'DTAV ' MOVIMVGA-DATA-AVERBACAO */
                    _.Display($"DTAV {MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_AVERBACAO}");

                    /*" -5455- DISPLAY 'DTAD ' MOVIMVGA-DATA-ADMISSAO */
                    _.Display($"DTAD {MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_ADMISSAO}");

                    /*" -5456- DISPLAY 'DTIN ' MOVIMVGA-DATA-INCLUSAO */
                    _.Display($"DTIN {MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_INCLUSAO}");

                    /*" -5457- DISPLAY 'DTNA ' MOVIMVGA-DATA-NASCIMENTO */
                    _.Display($"DTNA {MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_NASCIMENTO}");

                    /*" -5458- DISPLAY 'DTFT ' MOVIMVGA-DATA-FATURA */
                    _.Display($"DTFT {MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_FATURA}");

                    /*" -5459- DISPLAY 'DTRF ' MOVIMVGA-DATA-REFERENCIA */
                    _.Display($"DTRF {MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_REFERENCIA}");

                    /*" -5460- DISPLAY 'DTMO ' MOVIMVGA-DATA-MOVIMENTO */
                    _.Display($"DTMO {MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_MOVIMENTO}");

                    /*" -5462- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -5462- ADD 1 TO AC-GRAVA-M. */
            FILLER_1.AC_GRAVA_M.Value = FILLER_1.AC_GRAVA_M + 1;

        }

        [StopWatch]
        /*" R4400-00-INSERT-MOVIMVGA-DB-INSERT-1 */
        public void R4400_00_INSERT_MOVIMVGA_DB_INSERT_1()
        {
            /*" -5439- EXEC SQL INSERT INTO SEGUROS.MOVIMENTO_VGAP ( NUM_APOLICE, COD_SUBGRUPO, COD_FONTE, NUM_PROPOSTA, TIPO_SEGURADO, NUM_CERTIFICADO, DAC_CERTIFICADO, TIPO_INCLUSAO, COD_CLIENTE, COD_AGENCIADOR, COD_CORRETOR, COD_PLANOVGAP, COD_PLANOAP, FAIXA, AUTOR_AUM_AUTOMAT, TIPO_BENEFICIARIO, PERI_PAGAMENTO, PERI_RENOVACAO, COD_OCUPACAO, ESTADO_CIVIL, IDE_SEXO, COD_PROFISSAO, NATURALIDADE, OCORR_ENDERECO, OCORR_END_COBRAN, BCO_COBRANCA, AGE_COBRANCA, DAC_COBRANCA, NUM_MATRICULA, NUM_CTA_CORRENTE, DAC_CTA_CORRENTE, VAL_SALARIO, TIPO_SALARIO, TIPO_PLANO, PCT_CONJUGE_VG, PCT_CONJUGE_AP, QTD_SAL_MORNATU, QTD_SAL_MORACID, QTD_SAL_INVPERM, TAXA_AP_MORACID, TAXA_AP_INVPERM, TAXA_AP_AMDS, TAXA_AP_DH, TAXA_AP_DIT, TAXA_VG, IMP_MORNATU_ANT, IMP_MORNATU_ATU, IMP_MORACID_ANT, IMP_MORACID_ATU, IMP_INVPERM_ANT, IMP_INVPERM_ATU, IMP_AMDS_ANT, IMP_AMDS_ATU, IMP_DH_ANT, IMP_DH_ATU, IMP_DIT_ANT, IMP_DIT_ATU, PRM_VG_ANT, PRM_VG_ATU, PRM_AP_ANT, PRM_AP_ATU, COD_OPERACAO, DATA_OPERACAO, COD_SUBGRUPO_TRANS, SIT_REGISTRO, COD_USUARIO, DATA_AVERBACAO, DATA_ADMISSAO, DATA_INCLUSAO, DATA_NASCIMENTO, DATA_FATURA, DATA_REFERENCIA, DATA_MOVIMENTO, COD_EMPRESA, LOT_EMP_SEGURADO) VALUES (:MOVIMVGA-NUM-APOLICE, :MOVIMVGA-COD-SUBGRUPO, :MOVIMVGA-COD-FONTE, :MOVIMVGA-NUM-PROPOSTA, :MOVIMVGA-TIPO-SEGURADO, :MOVIMVGA-NUM-CERTIFICADO, :MOVIMVGA-DAC-CERTIFICADO, :MOVIMVGA-TIPO-INCLUSAO, :MOVIMVGA-COD-CLIENTE, :MOVIMVGA-COD-AGENCIADOR, :MOVIMVGA-COD-CORRETOR, :MOVIMVGA-COD-PLANOVGAP, :MOVIMVGA-COD-PLANOAP, :MOVIMVGA-FAIXA, :MOVIMVGA-AUTOR-AUM-AUTOMAT, :MOVIMVGA-TIPO-BENEFICIARIO, :MOVIMVGA-PERI-PAGAMENTO, :MOVIMVGA-PERI-RENOVACAO, :MOVIMVGA-COD-OCUPACAO, :MOVIMVGA-ESTADO-CIVIL, :MOVIMVGA-IDE-SEXO, :MOVIMVGA-COD-PROFISSAO, :MOVIMVGA-NATURALIDADE, :MOVIMVGA-OCORR-ENDERECO, :MOVIMVGA-OCORR-END-COBRAN, :MOVIMVGA-BCO-COBRANCA, :MOVIMVGA-AGE-COBRANCA, :MOVIMVGA-DAC-COBRANCA, :MOVIMVGA-NUM-MATRICULA, :MOVIMVGA-NUM-CTA-CORRENTE, :MOVIMVGA-DAC-CTA-CORRENTE, :MOVIMVGA-VAL-SALARIO, :MOVIMVGA-TIPO-SALARIO, :MOVIMVGA-TIPO-PLANO, :MOVIMVGA-PCT-CONJUGE-VG, :MOVIMVGA-PCT-CONJUGE-AP, :MOVIMVGA-QTD-SAL-MORNATU, :MOVIMVGA-QTD-SAL-MORACID, :MOVIMVGA-QTD-SAL-INVPERM, :MOVIMVGA-TAXA-AP-MORACID, :MOVIMVGA-TAXA-AP-INVPERM, :MOVIMVGA-TAXA-AP-AMDS, :MOVIMVGA-TAXA-AP-DH, :MOVIMVGA-TAXA-AP-DIT, :MOVIMVGA-TAXA-VG, :MOVIMVGA-IMP-MORNATU-ANT, :MOVIMVGA-IMP-MORNATU-ATU, :MOVIMVGA-IMP-MORACID-ANT, :MOVIMVGA-IMP-MORACID-ATU, :MOVIMVGA-IMP-INVPERM-ANT, :MOVIMVGA-IMP-INVPERM-ATU, :MOVIMVGA-IMP-AMDS-ANT, :MOVIMVGA-IMP-AMDS-ATU, :MOVIMVGA-IMP-DH-ANT, :MOVIMVGA-IMP-DH-ATU, :MOVIMVGA-IMP-DIT-ANT, :MOVIMVGA-IMP-DIT-ATU, :MOVIMVGA-PRM-VG-ANT, :MOVIMVGA-PRM-VG-ATU, :MOVIMVGA-PRM-AP-ANT, :MOVIMVGA-PRM-AP-ATU, :MOVIMVGA-COD-OPERACAO, :MOVIMVGA-DATA-OPERACAO, :MOVIMVGA-COD-SUBGRUPO-TRANS, :MOVIMVGA-SIT-REGISTRO, :MOVIMVGA-COD-USUARIO, :MOVIMVGA-DATA-AVERBACAO :VIND-DATA-AVERBACAO, :MOVIMVGA-DATA-ADMISSAO :VIND-DATA-ADMISSAO, :MOVIMVGA-DATA-INCLUSAO :VIND-DATA-INCLUSAO, :MOVIMVGA-DATA-NASCIMENTO, :MOVIMVGA-DATA-FATURA :VIND-DATA-FATURA, :MOVIMVGA-DATA-REFERENCIA, :MOVIMVGA-DATA-MOVIMENTO, :MOVIMVGA-COD-EMPRESA :VIND-COD-EMPRESA, :MOVIMVGA-LOT-EMP-SEGURADO :VIND-LOT-EMP-SEGURADO) END-EXEC. */

            var r4400_00_INSERT_MOVIMVGA_DB_INSERT_1_Insert1 = new R4400_00_INSERT_MOVIMVGA_DB_INSERT_1_Insert1()
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
                MOVIMVGA_DATA_FATURA = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_FATURA.ToString(),
                VIND_DATA_FATURA = VIND_DATA_FATURA.ToString(),
                MOVIMVGA_DATA_REFERENCIA = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_REFERENCIA.ToString(),
                MOVIMVGA_DATA_MOVIMENTO = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_MOVIMENTO.ToString(),
                MOVIMVGA_COD_EMPRESA = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_EMPRESA.ToString(),
                VIND_COD_EMPRESA = VIND_COD_EMPRESA.ToString(),
                MOVIMVGA_LOT_EMP_SEGURADO = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_LOT_EMP_SEGURADO.ToString(),
                VIND_LOT_EMP_SEGURADO = VIND_LOT_EMP_SEGURADO.ToString(),
            };

            R4400_00_INSERT_MOVIMVGA_DB_INSERT_1_Insert1.Execute(r4400_00_INSERT_MOVIMVGA_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4400_99_SAIDA*/

        [StopWatch]
        /*" R5000-00-PROCESSA-REABILIT-SECTION */
        private void R5000_00_PROCESSA_REABILIT_SECTION()
        {
            /*" -5471- MOVE 'R5000-00-PROCESSA-REABILIT' TO PARAGRAFO. */
            _.Move("R5000-00-PROCESSA-REABILIT", FILLER_1.WABEND.PARAGRAFO);

            /*" -5472- MOVE '5000' TO WNR-EXEC-SQL. */
            _.Move("5000", FILLER_1.WABEND.WNR_EXEC_SQL);

            /*" -5474- DISPLAY PARAGRAFO */
            _.Display(FILLER_1.WABEND.PARAGRAFO);

            /*" -5477- MOVE SEGURVGA-NUM-CERTIFICADO TO MOVIMVGA-NUM-CERTIFICADO */
            _.Move(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_CERTIFICADO, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_NUM_CERTIFICADO);

            /*" -5480- MOVE 0501 TO MOVIMVGA-COD-OPERACAO. */
            _.Move(0501, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO);

            /*" -5480- PERFORM R4400-00-INSERT-MOVIMVGA. */

            R4400_00_INSERT_MOVIMVGA_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R5000_99_SAIDA*/

        [StopWatch]
        /*" R6000-00-INSERE-RELATORIO-SECTION */
        private void R6000_00_INSERE_RELATORIO_SECTION()
        {
            /*" -5489- MOVE 'R6000-00-INSERE-RELATORIO ' TO PARAGRAFO. */
            _.Move("R6000-00-INSERE-RELATORIO ", FILLER_1.WABEND.PARAGRAFO);

            /*" -5490- MOVE '6000' TO WNR-EXEC-SQL. */
            _.Move("6000", FILLER_1.WABEND.WNR_EXEC_SQL);

            /*" -5492- DISPLAY PARAGRAFO */
            _.Display(FILLER_1.WABEND.PARAGRAFO);

            /*" -5494- MOVE WS-APOLICE-ANT TO RELATORI-NUM-APOLICE. */
            _.Move(WS_CHAVE_ANT_R.WS_APOLICE_ANT, RELATORI.DCLRELATORIOS.RELATORI_NUM_APOLICE);

            /*" -5497- MOVE WS-SUBGRUPO-ANT TO RELATORI-COD-SUBGRUPO. */
            _.Move(WS_CHAVE_ANT_R.WS_SUBGRUPO_ANT, RELATORI.DCLRELATORIOS.RELATORI_COD_SUBGRUPO);

            /*" -5498- MOVE 41 TO W01-I */
            _.Move(41, FILLER_0.W01_I);

            /*" -5499- MOVE 'R6000-INSERT RELATORI  ' TO W01-TEXTO(W01-I) */
            _.Move("R6000-INSERT RELATORI  ", FILLER_0.W01_TABELA_TEXTO.W01_TAB_TEXTO[FILLER_0.W01_I].W01_TEXTO);

            /*" -5503- PERFORM R8900-TOTALIZA-INICIO THRU R8900-TOTALIZA-INICIO-EXIT */

            R8900_TOTALIZA_INICIO_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8900_TOTALIZA_INICIO_EXIT*/


            /*" -5588- PERFORM R6000_00_INSERE_RELATORIO_DB_INSERT_1 */

            R6000_00_INSERE_RELATORIO_DB_INSERT_1();

            /*" -5592- MOVE 1 TO W01-QTD-ACC-OK */
            _.Move(1, FILLER_0.W01_QTD_ACC_OK);

            /*" -5596- PERFORM R8910-TOTALIZA-FINAL THRU R8910-TOTALIZA-FINAL-EXIT */

            R8910_TOTALIZA_FINAL_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8910_TOTALIZA_FINAL_EXIT*/


            /*" -5597- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -5598- IF SQLCODE EQUAL -803 */

                if (DB.SQLCODE == -803)
                {

                    /*" -5599- GO TO R6000-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R6000_99_SAIDA*/ //GOTO
                    return;

                    /*" -5600- ELSE */
                }
                else
                {


                    /*" -5601- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -5602- END-IF */
                }


                /*" -5603- END-IF. */
            }


        }

        [StopWatch]
        /*" R6000-00-INSERE-RELATORIO-DB-INSERT-1 */
        public void R6000_00_INSERE_RELATORIO_DB_INSERT_1()
        {
            /*" -5588- EXEC SQL INSERT INTO SEGUROS.RELATORIOS (COD_USUARIO, DATA_SOLICITACAO, IDE_SISTEMA, COD_RELATORIO, NUM_COPIAS, QUANTIDADE, PERI_INICIAL, PERI_FINAL, DATA_REFERENCIA, MES_REFERENCIA, ANO_REFERENCIA, ORGAO_EMISSOR, COD_FONTE, COD_PRODUTOR, RAMO_EMISSOR, COD_MODALIDADE, COD_CONGENERE, NUM_APOLICE, NUM_ENDOSSO, NUM_PARCELA, NUM_CERTIFICADO, NUM_TITULO, COD_SUBGRUPO, COD_OPERACAO, COD_PLANO, OCORR_HISTORICO, NUM_APOL_LIDER, ENDOS_LIDER, NUM_PARC_LIDER, NUM_SINISTRO, NUM_SINI_LIDER, NUM_ORDEM, COD_MOEDA, TIPO_CORRECAO, SIT_REGISTRO, IND_PREV_DEFINIT, IND_ANAL_RESUMO, COD_EMPRESA, PERI_RENOVACAO, PCT_AUMENTO, TIMESTAMP) VALUES ( 'VG1613B' , :SISTEMAS-DATA-MOV-ABERTO , 'VA' , 'VG1626B' , 0, 0, :SISTEMAS-DATA-MOV-ABERTO, :SISTEMAS-DATA-MOV-ABERTO, :SISTEMAS-DATA-MOV-ABERTO, 0, 0, 0, 0, 0, 0, 0, 0, :RELATORI-NUM-APOLICE, 0, 0, 0, 0, :RELATORI-COD-SUBGRUPO , 0, 0, 0, ' ' , ' ' , 0, 0, ' ' , 0, 0, ' ' , '1' , ' ' , ' ' , NULL, 0, 0, CURRENT TIMESTAMP) END-EXEC. */

            var r6000_00_INSERE_RELATORIO_DB_INSERT_1_Insert1 = new R6000_00_INSERE_RELATORIO_DB_INSERT_1_Insert1()
            {
                SISTEMAS_DATA_MOV_ABERTO = SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.ToString(),
                RELATORI_NUM_APOLICE = RELATORI.DCLRELATORIOS.RELATORI_NUM_APOLICE.ToString(),
                RELATORI_COD_SUBGRUPO = RELATORI.DCLRELATORIOS.RELATORI_COD_SUBGRUPO.ToString(),
            };

            R6000_00_INSERE_RELATORIO_DB_INSERT_1_Insert1.Execute(r6000_00_INSERE_RELATORIO_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R6000_99_SAIDA*/

        [StopWatch]
        /*" R7777-CONS-MODALIDADE-APOL-SECTION */
        private void R7777_CONS_MODALIDADE_APOL_SECTION()
        {
            /*" -5611- MOVE 'R7777-CONS-MODALIDADE-APOL' TO PARAGRAFO. */
            _.Move("R7777-CONS-MODALIDADE-APOL", FILLER_1.WABEND.PARAGRAFO);

            /*" -5612- MOVE '7777' TO WNR-EXEC-SQL. */
            _.Move("7777", FILLER_1.WABEND.WNR_EXEC_SQL);

            /*" -5614- DISPLAY PARAGRAFO */
            _.Display(FILLER_1.WABEND.PARAGRAFO);

            /*" -5616- INITIALIZE REGISTRO-LINKAGE-GE0510S */
            _.Initialize(
                REGISTRO_LINKAGE_GE0510S
            );

            /*" -5617- MOVE SUBGVGAP-NUM-APOLICE TO LK-GE510-NUM-APOLICE */
            _.Move(SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_NUM_APOLICE, REGISTRO_LINKAGE_GE0510S.LK_GE510_NUM_APOLICE);

            /*" -5619- MOVE SUBGVGAP-COD-SUBGRUPO TO LK-GE510-COD-SUBGRUPO */
            _.Move(SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_SUBGRUPO, REGISTRO_LINKAGE_GE0510S.LK_GE510_COD_SUBGRUPO);

            /*" -5621- CALL 'GE0510S' USING REGISTRO-LINKAGE-GE0510S */
            _.Call("GE0510S", REGISTRO_LINKAGE_GE0510S);

            /*" -5622- IF (LK-GE510-COD-RETORNO EQUAL '0' ) */

            if ((REGISTRO_LINKAGE_GE0510S.LK_GE510_COD_RETORNO == "0"))
            {

                /*" -5623- MOVE LK-GE510-COD-MODALIDADE TO WS-V0APOL-MODALIDA */
                _.Move(REGISTRO_LINKAGE_GE0510S.LK_GE510_COD_MODALIDADE, WS_V0APOL_MODALIDA);

                /*" -5624- ELSE */
            }
            else
            {


                /*" -5625- DISPLAY ' ' */
                _.Display($" ");

                /*" -5626- DISPLAY '*****************************************' */
                _.Display($"*****************************************");

                /*" -5627- DISPLAY '*      R7777-CONS-MODALIDA-APOL         *' */
                _.Display($"*      R7777-CONS-MODALIDA-APOL         *");

                /*" -5628- DISPLAY '*  ERRO NA EXECUCAO DO CALL DA GE0510S  *' */
                _.Display($"*  ERRO NA EXECUCAO DO CALL DA GE0510S  *");

                /*" -5629- DISPLAY '*****************************************' */
                _.Display($"*****************************************");

                /*" -5630- DISPLAY '=> APOLICE........ ' LK-GE510-NUM-APOLICE */
                _.Display($"=> APOLICE........ {REGISTRO_LINKAGE_GE0510S.LK_GE510_NUM_APOLICE}");

                /*" -5631- DISPLAY '=> COD-SUBGRUPO... ' LK-GE510-COD-SUBGRUPO */
                _.Display($"=> COD-SUBGRUPO... {REGISTRO_LINKAGE_GE0510S.LK_GE510_COD_SUBGRUPO}");

                /*" -5632- DISPLAY '=> NUM-CERTIFICADO ' LK-GE510-NUM-CERTIFICADO */
                _.Display($"=> NUM-CERTIFICADO {REGISTRO_LINKAGE_GE0510S.LK_GE510_NUM_CERTIFICADO}");

                /*" -5633- DISPLAY '-----------------------------------------' */
                _.Display($"-----------------------------------------");

                /*" -5634- DISPLAY '=> LK-MENSAGEM ... ' LK-GE510-MENSAGEM */
                _.Display($"=> LK-MENSAGEM ... {REGISTRO_LINKAGE_GE0510S.LK_GE510_MENSAGEM}");

                /*" -5635- DISPLAY '=> LK-COD-RETORNO. ' LK-GE510-COD-RETORNO */
                _.Display($"=> LK-COD-RETORNO. {REGISTRO_LINKAGE_GE0510S.LK_GE510_COD_RETORNO}");

                /*" -5636- DISPLAY '=> LK-SQLCODE..... ' LK-GE510-SQLCODE */
                _.Display($"=> LK-SQLCODE..... {REGISTRO_LINKAGE_GE0510S.LK_GE510_MENSAGEM.LK_GE510_SQLCODE}");

                /*" -5637- DISPLAY '*****************************************' */
                _.Display($"*****************************************");

                /*" -5638- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -5639- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R7777_99_SAIDA*/

        [StopWatch]
        /*" R8000-00-DECLARE-SUBGVGAP-SECTION */
        private void R8000_00_DECLARE_SUBGVGAP_SECTION()
        {
            /*" -5647- MOVE 'R8000-00-DECLARE-SUBGVGAP' TO PARAGRAFO. */
            _.Move("R8000-00-DECLARE-SUBGVGAP", FILLER_1.WABEND.PARAGRAFO);

            /*" -5648- MOVE '8000' TO WNR-EXEC-SQL. */
            _.Move("8000", FILLER_1.WABEND.WNR_EXEC_SQL);

            /*" -5650- DISPLAY PARAGRAFO */
            _.Display(FILLER_1.WABEND.PARAGRAFO);

            /*" -5653- MOVE ZEROS TO WINDM */
            _.Move(0, WINDM);

            /*" -5655- MOVE WS-APOLICE-ATU TO SUBGVGAP-NUM-APOLICE */
            _.Move(WS_CHAVE_ATU.WS_APOLICE_ATU, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_NUM_APOLICE);

            /*" -5659- MOVE 'NAO' TO WFIM-SUBGVGAP */
            _.Move("NAO", FILLER_1.FILLER_15.WFIM_SUBGVGAP);

            /*" -5660- MOVE 42 TO W01-I */
            _.Move(42, FILLER_0.W01_I);

            /*" -5661- MOVE 'R8000-DECLAR SUBGVGAP  ' TO W01-TEXTO(W01-I) */
            _.Move("R8000-DECLAR SUBGVGAP  ", FILLER_0.W01_TABELA_TEXTO.W01_TAB_TEXTO[FILLER_0.W01_I].W01_TEXTO);

            /*" -5665- PERFORM R8900-TOTALIZA-INICIO THRU R8900-TOTALIZA-INICIO-EXIT */

            R8900_TOTALIZA_INICIO_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8900_TOTALIZA_INICIO_EXIT*/


            /*" -5674- PERFORM R8000_00_DECLARE_SUBGVGAP_DB_DECLARE_1 */

            R8000_00_DECLARE_SUBGVGAP_DB_DECLARE_1();

            /*" -5676- PERFORM R8000_00_DECLARE_SUBGVGAP_DB_OPEN_1 */

            R8000_00_DECLARE_SUBGVGAP_DB_OPEN_1();

            /*" -5680- MOVE 1 TO W01-QTD-ACC-OK */
            _.Move(1, FILLER_0.W01_QTD_ACC_OK);

            /*" -5684- PERFORM R8910-TOTALIZA-FINAL THRU R8910-TOTALIZA-FINAL-EXIT */

            R8910_TOTALIZA_FINAL_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8910_TOTALIZA_FINAL_EXIT*/


            /*" -5685- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5686- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -5686- END-IF. */
            }


        }

        [StopWatch]
        /*" R8000-00-DECLARE-SUBGVGAP-DB-OPEN-1 */
        public void R8000_00_DECLARE_SUBGVGAP_DB_OPEN_1()
        {
            /*" -5676- EXEC SQL OPEN CSUBGVGAP END-EXEC. */

            CSUBGVGAP.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8000_99_SAIDA*/

        [StopWatch]
        /*" R8010-00-FETCH-SUBGVGAP-SECTION */
        private void R8010_00_FETCH_SUBGVGAP_SECTION()
        {
            /*" -5695- MOVE 'R8010-00-FETCH-SUBGVGAP' TO PARAGRAFO. */
            _.Move("R8010-00-FETCH-SUBGVGAP", FILLER_1.WABEND.PARAGRAFO);

            /*" -5696- MOVE '8010' TO WNR-EXEC-SQL. */
            _.Move("8010", FILLER_1.WABEND.WNR_EXEC_SQL);

            /*" -5699- DISPLAY PARAGRAFO */
            _.Display(FILLER_1.WABEND.PARAGRAFO);

            /*" -5700- MOVE 43 TO W01-I */
            _.Move(43, FILLER_0.W01_I);

            /*" -5701- MOVE 'R8010-FETCH  SUBGVGAP  ' TO W01-TEXTO(W01-I) */
            _.Move("R8010-FETCH  SUBGVGAP  ", FILLER_0.W01_TABELA_TEXTO.W01_TAB_TEXTO[FILLER_0.W01_I].W01_TEXTO);

            /*" -5705- PERFORM R8900-TOTALIZA-INICIO THRU R8900-TOTALIZA-INICIO-EXIT */

            R8900_TOTALIZA_INICIO_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8900_TOTALIZA_INICIO_EXIT*/


            /*" -5708- PERFORM R8010_00_FETCH_SUBGVGAP_DB_FETCH_1 */

            R8010_00_FETCH_SUBGVGAP_DB_FETCH_1();

            /*" -5712- MOVE 1 TO W01-QTD-ACC-OK */
            _.Move(1, FILLER_0.W01_QTD_ACC_OK);

            /*" -5716- PERFORM R8910-TOTALIZA-FINAL THRU R8910-TOTALIZA-FINAL-EXIT */

            R8910_TOTALIZA_FINAL_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8910_TOTALIZA_FINAL_EXIT*/


            /*" -5717- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5718- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -5719- MOVE 'SIM' TO WFIM-SUBGVGAP */
                    _.Move("SIM", FILLER_1.FILLER_15.WFIM_SUBGVGAP);

                    /*" -5719- PERFORM R8010_00_FETCH_SUBGVGAP_DB_CLOSE_1 */

                    R8010_00_FETCH_SUBGVGAP_DB_CLOSE_1();

                    /*" -5721- GO TO R8010-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R8010_99_SAIDA*/ //GOTO
                    return;

                    /*" -5722- ELSE */
                }
                else
                {


                    /*" -5723- DISPLAY 'ERRO FETCH CSUBGVGAP' */
                    _.Display($"ERRO FETCH CSUBGVGAP");

                    /*" -5724- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -5725- END-IF */
                }


                /*" -5725- END-IF. */
            }


        }

        [StopWatch]
        /*" R8010-00-FETCH-SUBGVGAP-DB-FETCH-1 */
        public void R8010_00_FETCH_SUBGVGAP_DB_FETCH_1()
        {
            /*" -5708- EXEC SQL FETCH CSUBGVGAP INTO :SUBGVGAP-NUM-APOLICE, :SUBGVGAP-COD-SUBGRUPO END-EXEC. */

            if (CSUBGVGAP.Fetch())
            {
                _.Move(CSUBGVGAP.SUBGVGAP_NUM_APOLICE, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_NUM_APOLICE);
                _.Move(CSUBGVGAP.SUBGVGAP_COD_SUBGRUPO, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_SUBGRUPO);
            }

        }

        [StopWatch]
        /*" R8010-00-FETCH-SUBGVGAP-DB-CLOSE-1 */
        public void R8010_00_FETCH_SUBGVGAP_DB_CLOSE_1()
        {
            /*" -5719- EXEC SQL CLOSE CSUBGVGAP END-EXEC */

            CSUBGVGAP.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8010_99_SAIDA*/

        [StopWatch]
        /*" R8100-00-PROCESSA-SUBGVGAP-SECTION */
        private void R8100_00_PROCESSA_SUBGVGAP_SECTION()
        {
            /*" -5734- MOVE 'R8100-00-PROCESSA-SUBGVGAP' TO PARAGRAFO. */
            _.Move("R8100-00-PROCESSA-SUBGVGAP", FILLER_1.WABEND.PARAGRAFO);

            /*" -5735- MOVE '8100' TO WNR-EXEC-SQL. */
            _.Move("8100", FILLER_1.WABEND.WNR_EXEC_SQL);

            /*" -5737- DISPLAY PARAGRAFO */
            _.Display(FILLER_1.WABEND.PARAGRAFO);

            /*" -5739- ADD 1 TO WINDM. */
            WINDM.Value = WINDM + 1;

            /*" -5740- IF WINDM > 1000 */

            if (WINDM > 1000)
            {

                /*" -5741- DISPLAY 'ESTOURO DE TABELA INTERNA ' */
                _.Display($"ESTOURO DE TABELA INTERNA ");

                /*" -5756- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -5758- PERFORM R2700-00-SELECT-PROPOSTA */

            R2700_00_SELECT_PROPOSTA_SECTION();

            /*" -5760- MOVE SUBGVGAP-NUM-APOLICE TO TAB-NUM-APOLICE (WINDM) */
            _.Move(SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_NUM_APOLICE, TAB_RESUMO.TAB_RES[WINDM].TAB_CHAVE_R.TAB_NUM_APOLICE);

            /*" -5763- MOVE SUBGVGAP-COD-SUBGRUPO TO TAB-COD-SUBGRUPO(WINDM) */
            _.Move(SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_SUBGRUPO, TAB_RESUMO.TAB_RES[WINDM].TAB_CHAVE_R.TAB_COD_SUBGRUPO);

            /*" -5765- MOVE HISCOBPR-QUANT-VIDAS TO TAB-QTDE-ATIVOS(WINDM). */
            _.Move(HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_QUANT_VIDAS, TAB_RESUMO.TAB_RES[WINDM].TAB_QTDE_ATIVOS);

            /*" -5768- MOVE HISCOBPR-VLPREMIO TO TAB-VLR-ATIVOS (WINDM). */
            _.Move(HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_VLPREMIO, TAB_RESUMO.TAB_RES[WINDM].TAB_VLR_ATIVOS);

            /*" -5770- PERFORM R2600-00-UPDATE-SEGURVGA. */

            R2600_00_UPDATE_SEGURVGA_SECTION();

            /*" -5770- PERFORM R8010-00-FETCH-SUBGVGAP. */

            R8010_00_FETCH_SUBGVGAP_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8100_99_SAIDA*/

        [StopWatch]
        /*" R8110-00-PESQUISA-SUBGVGAP-SECTION */
        private void R8110_00_PESQUISA_SUBGVGAP_SECTION()
        {
            /*" -5779- MOVE 'R8110-00-PESQUISA-SUBGVGAP' TO PARAGRAFO. */
            _.Move("R8110-00-PESQUISA-SUBGVGAP", FILLER_1.WABEND.PARAGRAFO);

            /*" -5780- MOVE '8110' TO WNR-EXEC-SQL. */
            _.Move("8110", FILLER_1.WABEND.WNR_EXEC_SQL);

            /*" -5782- DISPLAY PARAGRAFO */
            _.Display(FILLER_1.WABEND.PARAGRAFO);

            /*" -5783- IF INF > SUP */

            if (INF > SUP)
            {

                /*" -5784- MOVE 'NAO' TO WS-TEM-SUBGRUPO */
                _.Move("NAO", WS_TEM_SUBGRUPO);

                /*" -5785- ELSE */
            }
            else
            {


                /*" -5786- COMPUTE WS-IND = (SUP + INF) / 2 */
                WS_IND.Value = (SUP + INF) / 2;

                /*" -5788- IF WS-CHAVE-ATU < TAB-CHAVE (WS-IND) */

                if (WS_CHAVE_ATU < TAB_RESUMO.TAB_RES[WS_IND].TAB_CHAVE)
                {

                    /*" -5789- COMPUTE SUP = WS-IND - 1 */
                    SUP.Value = WS_IND - 1;

                    /*" -5790- GO TO R8110-00-PESQUISA-SUBGVGAP */
                    new Task(() => R8110_00_PESQUISA_SUBGVGAP_SECTION()).RunSynchronously(); //GOTO
                    return;//Recursividade detectada, cuidado...

                    /*" -5791- ELSE */
                }
                else
                {


                    /*" -5793- IF WS-CHAVE-ATU > TAB-CHAVE (WS-IND) */

                    if (WS_CHAVE_ATU > TAB_RESUMO.TAB_RES[WS_IND].TAB_CHAVE)
                    {

                        /*" -5794- COMPUTE INF = WS-IND + 1 */
                        INF.Value = WS_IND + 1;

                        /*" -5795- GO TO R8110-00-PESQUISA-SUBGVGAP */
                        new Task(() => R8110_00_PESQUISA_SUBGVGAP_SECTION()).RunSynchronously(); //GOTO
                        return;//Recursividade detectada, cuidado...

                        /*" -5796- ELSE */
                    }
                    else
                    {


                        /*" -5796- MOVE 'SIM' TO WS-TEM-SUBGRUPO. */
                        _.Move("SIM", WS_TEM_SUBGRUPO);
                    }

                }

            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8110_99_SAIDA*/

        [StopWatch]
        /*" R8200-00-UPDATE-NUMEROUT-SECTION */
        private void R8200_00_UPDATE_NUMEROUT_SECTION()
        {
            /*" -5805- MOVE 'R8200-00-UPDATE-NUMEROUT' TO PARAGRAFO. */
            _.Move("R8200-00-UPDATE-NUMEROUT", FILLER_1.WABEND.PARAGRAFO);

            /*" -5806- MOVE '8200' TO WNR-EXEC-SQL. */
            _.Move("8200", FILLER_1.WABEND.WNR_EXEC_SQL);

            /*" -5809- DISPLAY PARAGRAFO */
            _.Display(FILLER_1.WABEND.PARAGRAFO);

            /*" -5810- MOVE 44 TO W01-I */
            _.Move(44, FILLER_0.W01_I);

            /*" -5811- MOVE 'R8200-UPDATE NUMEROUT  ' TO W01-TEXTO(W01-I) */
            _.Move("R8200-UPDATE NUMEROUT  ", FILLER_0.W01_TABELA_TEXTO.W01_TAB_TEXTO[FILLER_0.W01_I].W01_TEXTO);

            /*" -5815- PERFORM R8900-TOTALIZA-INICIO THRU R8900-TOTALIZA-INICIO-EXIT */

            R8900_TOTALIZA_INICIO_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8900_TOTALIZA_INICIO_EXIT*/


            /*" -5821- PERFORM R8200_00_UPDATE_NUMEROUT_DB_UPDATE_1 */

            R8200_00_UPDATE_NUMEROUT_DB_UPDATE_1();

            /*" -5825- MOVE 1 TO W01-QTD-ACC-OK */
            _.Move(1, FILLER_0.W01_QTD_ACC_OK);

            /*" -5829- PERFORM R8910-TOTALIZA-FINAL THRU R8910-TOTALIZA-FINAL-EXIT */

            R8910_TOTALIZA_FINAL_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8910_TOTALIZA_FINAL_EXIT*/


            /*" -5830- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -5833- DISPLAY 'VG1613B - PROBLEMAS UPDATE NUMERO-OUTROS ' NUMEROUT-NUM-CERT-VGAP */
                _.Display($"VG1613B - PROBLEMAS UPDATE NUMERO-OUTROS {NUMEROUT.DCLNUMERO_OUTROS.NUMEROUT_NUM_CERT_VGAP}");

                /*" -5833- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R8200-00-UPDATE-NUMEROUT-DB-UPDATE-1 */
        public void R8200_00_UPDATE_NUMEROUT_DB_UPDATE_1()
        {
            /*" -5821- EXEC SQL UPDATE SEGUROS.NUMERO_OUTROS SET NUM_CERT_VGAP = :NUMEROUT-NUM-CERT-VGAP, NUM_CLIENTE = :NUMEROUT-NUM-CLIENTE WHERE 1 = 1 END-EXEC. */

            var r8200_00_UPDATE_NUMEROUT_DB_UPDATE_1_Update1 = new R8200_00_UPDATE_NUMEROUT_DB_UPDATE_1_Update1()
            {
                NUMEROUT_NUM_CERT_VGAP = NUMEROUT.DCLNUMERO_OUTROS.NUMEROUT_NUM_CERT_VGAP.ToString(),
                NUMEROUT_NUM_CLIENTE = NUMEROUT.DCLNUMERO_OUTROS.NUMEROUT_NUM_CLIENTE.ToString(),
            };

            R8200_00_UPDATE_NUMEROUT_DB_UPDATE_1_Update1.Execute(r8200_00_UPDATE_NUMEROUT_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8200_99_SAIDA*/

        [StopWatch]
        /*" R8900-TOTALIZA-INICIO-SECTION */
        private void R8900_TOTALIZA_INICIO_SECTION()
        {
            /*" -5849- INITIALIZE W01-QTD-ACC-OK W01-QTD-ACC-NOK */
            _.Initialize(
                FILLER_0.W01_QTD_ACC_OK
                , FILLER_0.W01_QTD_ACC_NOK
            );

            /*" -5850- MOVE FUNCTION CURRENT-DATE TO W01-CURRENT-DATE */
            _.Move(_.CurrentDate(), FILLER_0.W01_CURRENT_DATE);

            /*" -5853- COMPUTE W01-SEG-INI = (W01-CDTE-HORA * 60 * 60) + (W01-CDTE-MIN * 60) + W01-CDTE-SEG + (W01-CDTE-DECSEG / 100) */
            FILLER_0.W01_SEG_INI.Value = (FILLER_0.W01_CURRENT_DATE.W01_CDTE_HORA * 60 * 60) + (FILLER_0.W01_CURRENT_DATE.W01_CDTE_MIN * 60) + FILLER_0.W01_CURRENT_DATE.W01_CDTE_SEG + (FILLER_0.W01_CURRENT_DATE.W01_CDTE_DECSEG / 100f);

            /*" -5853- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8900_TOTALIZA_INICIO_EXIT*/

        [StopWatch]
        /*" R8910-TOTALIZA-FINAL-SECTION */
        private void R8910_TOTALIZA_FINAL_SECTION()
        {
            /*" -5861- ADD W01-QTD-ACC-OK TO W01-TOT-ACC-OK(W01-I) */
            FILLER_0.W01_TABELA_TOTAIS.W01_TOT_ACC_OK[FILLER_0.W01_I].Value = FILLER_0.W01_TABELA_TOTAIS.W01_TOT_ACC_OK[FILLER_0.W01_I] + FILLER_0.W01_QTD_ACC_OK;

            /*" -5864- ADD W01-QTD-ACC-NOK TO W01-TOT-ACC-NOK(W01-I) */
            FILLER_0.W01_TABELA_TOTAIS.W01_TOT_ACC_NOK[FILLER_0.W01_I].Value = FILLER_0.W01_TABELA_TOTAIS.W01_TOT_ACC_NOK[FILLER_0.W01_I] + FILLER_0.W01_QTD_ACC_NOK;

            /*" -5865- MOVE FUNCTION CURRENT-DATE TO W01-CURRENT-DATE */
            _.Move(_.CurrentDate(), FILLER_0.W01_CURRENT_DATE);

            /*" -5868- COMPUTE W01-SEG-FIN = (W01-CDTE-HORA * 60 * 60) + (W01-CDTE-MIN * 60) + W01-CDTE-SEG + (W01-CDTE-DECSEG / 100) */
            FILLER_0.W01_SEG_FIN.Value = (FILLER_0.W01_CURRENT_DATE.W01_CDTE_HORA * 60 * 60) + (FILLER_0.W01_CURRENT_DATE.W01_CDTE_MIN * 60) + FILLER_0.W01_CURRENT_DATE.W01_CDTE_SEG + (FILLER_0.W01_CURRENT_DATE.W01_CDTE_DECSEG / 100f);

            /*" -5869- SUBTRACT W01-SEG-INI FROM W01-SEG-FIN */
            FILLER_0.W01_SEG_FIN.Value = FILLER_0.W01_SEG_FIN - FILLER_0.W01_SEG_INI;

            /*" -5870- ADD W01-SEG-FIN TO W01-TOT-TIME(W01-I) */
            FILLER_0.W01_TABELA_TOTAIS.W01_TOT_TIME[FILLER_0.W01_I].Value = FILLER_0.W01_TABELA_TOTAIS.W01_TOT_TIME[FILLER_0.W01_I] + FILLER_0.W01_SEG_FIN;

            /*" -5870- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8910_TOTALIZA_FINAL_EXIT*/

        [StopWatch]
        /*" R8920-MOSTRA-TOTALIZADORES-SECTION */
        private void R8920_MOSTRA_TOTALIZADORES_SECTION()
        {
            /*" -5881- DISPLAY ' ' */
            _.Display($" ");

            /*" -5882- DISPLAY '--> R8920-MOSTRA-TOTALIZADORES:' */
            _.Display($"--> R8920-MOSTRA-TOTALIZADORES:");

            /*" -5884- DISPLAY '==================================================' '===============================' */
            _.Display($"=================================================================================");

            /*" -5886- DISPLAY '      TOTALIZACAO                                 ' 'EXECUTADOS' */
            _.Display($"      TOTALIZACAO                                 EXECUTADOS");

            /*" -5888- DISPLAY '   TOTAIS                               QTD OK   T' 'EMPO(SEG)           OC' */
            _.Display($"   TOTAIS                               QTD OK   TEMPO(SEG)           OC");

            /*" -5890- DISPLAY '----------------------------------- ---------- ---' '----------   -----------' */
            _.Display($"----------------------------------- ---------- -------------   -----------");

            /*" -5892- DISPLAY 'XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX   00.000.000   0' '0.000.000   (000000000)' */
            _.Display($"XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX   00.000.000   00.000.000   (000000000)");

            /*" -5895- DISPLAY '==================================================' '===============================' */
            _.Display($"=================================================================================");

            /*" -5897- PERFORM VARYING W01-I FROM 1 BY 1 UNTIL W01-I > W01-LIM-OCOR */

            for (FILLER_0.W01_I.Value = 1; !(FILLER_0.W01_I > FILLER_0.W01_LIM_OCOR); FILLER_0.W01_I.Value += 1)
            {

                /*" -5898-  EVALUATE TRUE  */

                /*" -5899-  WHEN W01-TEXTO(W01-I) NOT = LOW-VALUES AND SPACES  */

                /*" -5899- IF W01-TEXTO(W01-I) NOT = LOW-VALUES AND SPACES */

                if (FILLER_0.W01_TABELA_TEXTO.W01_TAB_TEXTO[FILLER_0.W01_I].W01_TEXTO != "")
                {

                    /*" -5900- MOVE W01-TOT-ACC-OK(W01-I) TO W01-TOT-ACC-OK-ED */
                    _.Move(FILLER_0.W01_TABELA_TOTAIS.W01_TOT_ACC_OK[FILLER_0.W01_I], FILLER_0.W01_TOT_ACC_OK_ED);

                    /*" -5901- MOVE W01-TOT-TIME(W01-I) TO W01-TOT-TIME-ED */
                    _.Move(FILLER_0.W01_TABELA_TOTAIS.W01_TOT_TIME[FILLER_0.W01_I], FILLER_0.W01_TOT_TIME_ED);

                    /*" -5905- DISPLAY W01-TEXTO(W01-I) '  ' W01-TOT-ACC-OK-ED ' ' W01-TOT-TIME-ED '  (' W01-I ')' */

                    $"{FILLER_0.W01_TABELA_TEXTO.W01_TAB_TEXTO[FILLER_0.W01_I]}  {FILLER_0.W01_TOT_ACC_OK_ED} {FILLER_0.W01_TOT_TIME_ED}  ({FILLER_0.W01_I})"
                    .Display();

                    /*" -5906-  END-EVALUATE  */

                    /*" -5906- END-IF */
                }


                /*" -5908- END-PERFORM */
            }

            /*" -5910- DISPLAY '==================================================' '===============================' */
            _.Display($"=================================================================================");

            /*" -5911- DISPLAY ' ' */
            _.Display($" ");

            /*" -5911- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8920_MOSTRA_TOTALIZ_EXIT*/

        [StopWatch]
        /*" R9000-00-FINALIZA-SECTION */
        private void R9000_00_FINALIZA_SECTION()
        {
            /*" -5918- MOVE 'R9000-00-FINALIZA' TO PARAGRAFO. */
            _.Move("R9000-00-FINALIZA", FILLER_1.WABEND.PARAGRAFO);

            /*" -5919- MOVE '9000' TO WNR-EXEC-SQL. */
            _.Move("9000", FILLER_1.WABEND.WNR_EXEC_SQL);

            /*" -5921- DISPLAY PARAGRAFO */
            _.Display(FILLER_1.WABEND.PARAGRAFO);

            /*" -5922- CLOSE ARQUIVO-RETORNO. */
            ARQUIVO_RETORNO.Close();

            /*" -5924- CLOSE ARQUIVO-LEITURA. */
            ARQUIVO_LEITURA.Close();

            /*" -5925- DISPLAY '-------------------------------------------------' */
            _.Display($"-------------------------------------------------");

            /*" -5926- DISPLAY '               PROGRAMA VG1613B ' */
            _.Display($"               PROGRAMA VG1613B ");

            /*" -5927- DISPLAY '             TOTAIS PARA CONTROLE ' */
            _.Display($"             TOTAIS PARA CONTROLE ");

            /*" -5928- DISPLAY '-------------------------------------------------' */
            _.Display($"-------------------------------------------------");

            /*" -5929- DISPLAY 'LIDOS NO MOVIMENTO ARQUIVO EMPRESA  = ' AC-LIDOS-M */
            _.Display($"LIDOS NO MOVIMENTO ARQUIVO EMPRESA  = {FILLER_1.AC_LIDOS_M}");

            /*" -5930- DISPLAY 'GRAVADOS NO MOVIMENTO DE ERRO       = ' AC-GRAVA-S */
            _.Display($"GRAVADOS NO MOVIMENTO DE ERRO       = {FILLER_1.AC_GRAVA_S}");

            /*" -5931- DISPLAY '-------------------------------------------------' */
            _.Display($"-------------------------------------------------");

            /*" -5932- DISPLAY 'GRAVADOS NA MOVIMENTO_VGAP          = ' AC-GRAVA-M */
            _.Display($"GRAVADOS NA MOVIMENTO_VGAP          = {FILLER_1.AC_GRAVA_M}");

            /*" -5933- DISPLAY ' .INCLUSOES                         = ' AC-GRAVA-1 */
            _.Display($" .INCLUSOES                         = {FILLER_1.AC_GRAVA_1}");

            /*" -5934- DISPLAY 'CLIENTES INSERIDOS                  = ' AC-GRAVA-C */
            _.Display($"CLIENTES INSERIDOS                  = {FILLER_1.AC_GRAVA_C}");

            /*" -5935- DISPLAY 'ENDERECOS INSERIDOS                 = ' AC-GRAVA-E */
            _.Display($"ENDERECOS INSERIDOS                 = {FILLER_1.AC_GRAVA_E}");

            /*" -5937- DISPLAY 'CPF EM DUPLICIDADE NO MOVIMENTO     = ' WS-QTDE-DUPLIC */
            _.Display($"CPF EM DUPLICIDADE NO MOVIMENTO     = {WS_QTDE_DUPLIC}");

            /*" -5939- DISPLAY 'PREMIO CALCULADO DIFERE DO INFORMADO= ' WS-QTDE-ERRO-3027 */
            _.Display($"PREMIO CALCULADO DIFERE DO INFORMADO= {WS_QTDE_ERRO_3027}");

            /*" -5940- DISPLAY '-------------------------------------------------' */
            _.Display($"-------------------------------------------------");

            /*" -5942- DISPLAY ' ' */
            _.Display($" ");

            /*" -5943- IF RETURN-CODE EQUAL ZEROS */

            if (RETURN_CODE == 00)
            {

                /*" -5944- DISPLAY ' *** VG1613B - FIM NORMAL ' */
                _.Display($" *** VG1613B - FIM NORMAL ");

                /*" -5945- ELSE */
            }
            else
            {


                /*" -5946- DISPLAY ' *** VG1613B - FIM  ANORMAL ' */
                _.Display($" *** VG1613B - FIM  ANORMAL ");

                /*" -5949- END-IF. */
            }


            /*" -5953- PERFORM R8920-MOSTRA-TOTALIZADORES THRU R8920-MOSTRA-TOTALIZ-EXIT */

            R8920_MOSTRA_TOTALIZADORES_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8920_MOSTRA_TOTALIZ_EXIT*/


            /*" -5953- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -5955- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9000_99_SAIDA*/

        [StopWatch]
        /*" R9900-00-ENCERRA-SEM-MOVTO-SECTION */
        private void R9900_00_ENCERRA_SEM_MOVTO_SECTION()
        {
            /*" -5964- MOVE 'R9900-00-ENCERRA-SEM-MOVTO' TO PARAGRAFO. */
            _.Move("R9900-00-ENCERRA-SEM-MOVTO", FILLER_1.WABEND.PARAGRAFO);

            /*" -5966- DISPLAY PARAGRAFO */
            _.Display(FILLER_1.WABEND.PARAGRAFO);

            /*" -5967- MOVE SISTEMAS-DATA-MOV-ABERTO TO WDATA-REL */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, FILLER_1.WDATA_REL);

            /*" -5968- MOVE WDAT-REL-DIA TO WDAT-LIT-DIA */
            _.Move(FILLER_1.FILLER_25.WDAT_REL_DIA, FILLER_1.WDAT_REL_LIT.WDAT_LIT_DIA);

            /*" -5969- MOVE WDAT-REL-MES TO WDAT-LIT-MES */
            _.Move(FILLER_1.FILLER_25.WDAT_REL_MES, FILLER_1.WDAT_REL_LIT.WDAT_LIT_MES);

            /*" -5970- MOVE WDAT-REL-SEC TO WDAT-LIT-SEC */
            _.Move(FILLER_1.FILLER_25.WDAT_REL_SEC, FILLER_1.WDAT_REL_LIT.WDAT_LIT_SEC);

            /*" -5972- MOVE WDAT-REL-ANO TO WDAT-LIT-ANO */
            _.Move(FILLER_1.FILLER_25.WDAT_REL_ANO, FILLER_1.WDAT_REL_LIT.WDAT_LIT_ANO);

            /*" -5973- DISPLAY '*--------------------------------------------*' */
            _.Display($"*--------------------------------------------*");

            /*" -5974- DISPLAY '*                                            *' */
            _.Display($"*                                            *");

            /*" -5975- DISPLAY '*  VG1613B - CONSISTENCIA LOGICA MOVIMENTO   *' */
            _.Display($"*  VG1613B - CONSISTENCIA LOGICA MOVIMENTO   *");

            /*" -5976- DISPLAY '*  -------   ------------ ------ ---------   *' */
            _.Display($"*  -------   ------------ ------ ---------   *");

            /*" -5977- DISPLAY '*                                            *' */
            _.Display($"*                                            *");

            /*" -5978- DISPLAY '*     NAO HOUVE MOVIMENTACAO NESTA DATA      *' */
            _.Display($"*     NAO HOUVE MOVIMENTACAO NESTA DATA      *");

            /*" -5980- DISPLAY '*               ' WDAT-REL-LIT '                     *' */

            $"*               {FILLER_1.WDAT_REL_LIT}                     *"
            .Display();

            /*" -5981- DISPLAY '*                                            *' */
            _.Display($"*                                            *");

            /*" -5981- DISPLAY '*--------------------------------------------*' . */
            _.Display($"*--------------------------------------------*");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9900_99_SAIDA*/

        [StopWatch]
        /*" R9930-00-MOVIMVGA-SUBGRUPO-SECTION */
        private void R9930_00_MOVIMVGA_SUBGRUPO_SECTION()
        {
            /*" -6016- MOVE 'R9930-00-MOVIMVGA-SUBGRUPO' TO PARAGRAFO. */
            _.Move("R9930-00-MOVIMVGA-SUBGRUPO", FILLER_1.WABEND.PARAGRAFO);

            /*" -6018- DISPLAY PARAGRAFO */
            _.Display(FILLER_1.WABEND.PARAGRAFO);

            /*" -6019- MOVE SISTEMAS-DATA-MOV-ABERTO TO WDATA-REL */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, FILLER_1.WDATA_REL);

            /*" -6020- MOVE WDAT-REL-DIA TO WDAT-LIT-DIA */
            _.Move(FILLER_1.FILLER_25.WDAT_REL_DIA, FILLER_1.WDAT_REL_LIT.WDAT_LIT_DIA);

            /*" -6021- MOVE WDAT-REL-MES TO WDAT-LIT-MES */
            _.Move(FILLER_1.FILLER_25.WDAT_REL_MES, FILLER_1.WDAT_REL_LIT.WDAT_LIT_MES);

            /*" -6022- MOVE WDAT-REL-SEC TO WDAT-LIT-SEC */
            _.Move(FILLER_1.FILLER_25.WDAT_REL_SEC, FILLER_1.WDAT_REL_LIT.WDAT_LIT_SEC);

            /*" -6024- MOVE WDAT-REL-ANO TO WDAT-LIT-ANO */
            _.Move(FILLER_1.FILLER_25.WDAT_REL_ANO, FILLER_1.WDAT_REL_LIT.WDAT_LIT_ANO);

            /*" -6025- DISPLAY '*--------------------------------------------*' */
            _.Display($"*--------------------------------------------*");

            /*" -6026- DISPLAY '*                                            *' */
            _.Display($"*                                            *");

            /*" -6027- DISPLAY '*  VG1613B - CONSISTENCIA LOGICA MOVIMENTO   *' */
            _.Display($"*  VG1613B - CONSISTENCIA LOGICA MOVIMENTO   *");

            /*" -6028- DISPLAY '*  -------   ------------ ------ ---------   *' */
            _.Display($"*  -------   ------------ ------ ---------   *");

            /*" -6029- DISPLAY '*                                            *' */
            _.Display($"*                                            *");

            /*" -6030- DISPLAY '*     SUBGRUPO ZERADO                        *' */
            _.Display($"*     SUBGRUPO ZERADO                        *");

            /*" -6032- DISPLAY '*     ' WDAT-REL-LIT '                             *' */

            $"*     {FILLER_1.WDAT_REL_LIT}                             *"
            .Display();

            /*" -6033- DISPLAY '*                                            *' */
            _.Display($"*                                            *");

            /*" -6033- DISPLAY '*--------------------------------------------*' . */
            _.Display($"*--------------------------------------------*");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9930_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -6042- MOVE 'R9999-00-ROT-ERRO' TO PARAGRAFO. */
            _.Move("R9999-00-ROT-ERRO", FILLER_1.WABEND.PARAGRAFO);

            /*" -6044- DISPLAY PARAGRAFO */
            _.Display(FILLER_1.WABEND.PARAGRAFO);

            /*" -6045- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -6046- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, FILLER_1.WABEND.WSQLCODE);

                /*" -6047- MOVE SQLERRD(1) TO WSQLCODE1 */
                _.Move(DB.SQLERRD[1], FILLER_1.WABEND.WSQLCODE1);

                /*" -6048- MOVE SQLERRD(2) TO WSQLCODE2 */
                _.Move(DB.SQLERRD[2], FILLER_1.WABEND.WSQLCODE2);

                /*" -6049- MOVE SQLCODE TO WSQLCODE3 */
                _.Move(DB.SQLCODE, FILLER_1.WSQLCODE3);

                /*" -6050- DISPLAY WABEND */
                _.Display(FILLER_1.WABEND);

                /*" -6051- MOVE SQLERRMC TO WSQLERRMC */
                _.Move(DB.SQLERRMC, FILLER_1.WSQLERRO.WSQLERRMC);

                /*" -6052- DISPLAY WSQLERRO */
                _.Display(FILLER_1.WSQLERRO);

                /*" -6053- DISPLAY SPACES */
                _.Display($"");

                /*" -6054- DISPLAY REGISTRO-LEITURA */
                _.Display(REGISTRO_LEITURA);

                /*" -6055- DISPLAY REGISTRO-SORT */
                _.Display(REGISTRO_SORT);

                /*" -6056- ACCEPT WS-TIME FROM TIME */
                _.Move(_.AcceptDate("TIME"), FILLER_1.WS_TIME);

                /*" -6057- DISPLAY 'LIDOS MOVIMENTO   ' AC-LIDOS-M ' ' WS-TIME */

                $"LIDOS MOVIMENTO   {FILLER_1.AC_LIDOS_M} {FILLER_1.WS_TIME}"
                .Display();

                /*" -6059- DISPLAY 'LIDOS SORT        ' AC-LIDOS-S ' ' WS-TIME. */

                $"LIDOS SORT        {FILLER_1.AC_LIDOS_S} {FILLER_1.WS_TIME}"
                .Display();
            }


            /*" -6061- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -6065- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -6069- MOVE 99 TO RETURN-CODE */
            _.Move(99, RETURN_CODE);

            /*" -6069- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}