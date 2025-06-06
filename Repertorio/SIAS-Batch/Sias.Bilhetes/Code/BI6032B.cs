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
using Sias.Bilhetes.DB2.BI6032B;

namespace Code
{
    public class BI6032B
    {
        public bool IsCall { get; set; }

        public BI6032B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------                                 */
        /*"      *                                                                       */
        /*"      *                                                                       */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  COBRANCA                           *      */
        /*"      *   PROGRAMA ...............  BI6032B                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  CONSEDA                            *      */
        /*"      *   PROGRAMADOR ............  CONSEDA                            *      */
        /*"      *   DATA CODIFICACAO .......  OUTUBRO/1999                       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO .................  - GERAR FITA MOVTO P/ CREDITO EM   *      */
        /*"      *                               CONTA CORRENTE DE BILHETES COM   *      */
        /*"      *                               C/C DE DEBITO IGUAL DO INDICADOR *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                    A L T E R A C O E S                         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 17 - DEMANDA 455132                                   *      */
        /*"      *             - COLCAR OS CAMPOS NO MOMENTO DO INSERT PARA       *      */
        /*"      *               TABELA MOVTO_DEBITOCC_CEF (VIEW)                 *      */
        /*"      *                                                                *      */
        /*"      *   EM 24/02/2023 - HUSNI ALI HUSNI                              *      */
        /*"      *                                           PROCURE POR V.17     *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 16 - DEMANDA 214252                                   *      */
        /*"      *             - MUDAR A DATA DE VENCIMENTO PARA D+2 E NAO D+5.   *      */
        /*"      *                                                                *      */
        /*"      *   EM 01/11/2019 - CLAUDETE RADEL                               *      */
        /*"      *                                           PROCURE POR V.16     *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 15 - CAD 148793 - EVOLUCAO NO PROCESSO DE RESTITUICAO *      */
        /*"      *                                                                *      */
        /*"      *   EM 05/09/2017 - MARCUS VALERIO                               *      */
        /*"      *                                           PROCURE POR V.15     *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 14 -   NSGD - CADMUS 103659.                          *      */
        /*"      *               - NOVA SOLUCAO DE GESTAO DE DEPOSITOS            *      */
        /*"      *                                                                *      */
        /*"      *   AJUSTE LAYOUT ARQUIVO MOVIMENTO (MVCRCCOR)                   *      */
        /*"      *   EM 20/07/2015 - COREON                                       *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.14         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 13 -   NSGD - CADMUS 103659.                          *      */
        /*"      *               - NOVA SOLUCAO DE GESTAO DE DEPOSITOS            *      */
        /*"      *                                                                *      */
        /*"      *   EM 05/10/2014 - COREON                                       *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.13         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 12 - CAD-69.938                                       *      */
        /*"      *                                                                *      */
        /*"      *             - CUSTOMIZACAO DO PROGRAMA.                        *      */
        /*"      *                                                                *      */
        /*"      *   EM 17/05/2012 - CLOVIS                                       *      */
        /*"      *                                                                *      */
        /*"      *                                            PROCURE POR V.12    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 11 - CAD-68.235                                       *      */
        /*"      *                                                                *      */
        /*"      *             - CUSTOMIZACAO PARA O CANAL DE VENDA MAIS ESTUDO   *      */
        /*"      *               OS PROGRAMAS                                     *      */
        /*"      *                                                                *      */
        /*"      *                  . BI3600B                                     *      */
        /*"      *                  . BI3602B                                     *      */
        /*"      *                  . BI0030B                                     *      */
        /*"      *                  . BI0031B                                     *      */
        /*"      *                  . BI0422B                                     *      */
        /*"      *                  . BI0602B                                     *      */
        /*"      *                  . BI6032B                                     *      */
        /*"      *                  . BI7028B                                     *      */
        /*"      *                  . BI7029B                                     *      */
        /*"      *                                                                *      */
        /*"      *                FORAM PREPARADOS PARA TRABALHAR COM PARAMETROS  *      */
        /*"      *                DEFINIDOS NA SEGUROS.ARQUIVOS_SIVPF.                   */
        /*"      *                                                                *      */
        /*"      *   EM 14/04/2012 - TERCIO CARVALHO (FAST COMPUTER)              *      */
        /*"      *                                                                *      */
        /*"      *                                            PROCURE POR V.11    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 10 - CAD 52.124                                       *      */
        /*"      *               - REVISAO DA OPERACAO.                           *      */
        /*"      *               - AJUSTE NO CODIGO DE CONVENIO MUDANDO DAS       *      */
        /*"      *                 SEIS ULTIMAS PARA AS SEIS PRIMEIRA POSICOES    *      */
        /*"      *                 EM FUNCAO DO SAP.                              *      */
        /*"      *                                                                *      */
        /*"      *   EM 06/01/2011 - TERCIO FREITAS (FAST COMPUTER)               *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.10         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 09 - CAD 20.101                                       *      */
        /*"      *               - CORRIGE PARA GRAVAR CORRETAMENTE O ENDOSSO.    *      */
        /*"      *                                                                *      */
        /*"      *   EM 29/12/2010 - EDIVALDO GOMES (FAST COMPUTER)               *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.09         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 08 - CAD 47.775                                       *      */
        /*"      *               - PASSA A TRATAR A ORIGEM 1002 PARA OS PRODUTOS  *      */
        /*"      *                 DO GRUPO FIGUEREIDO.  - 8119                   *      */
        /*"      *                                       - 8120                   *      */
        /*"      *                                       - 8121                   *      */
        /*"      *                                       - 8122                   *      */
        /*"      *                                       - 8123                   *      */
        /*"      *                                                                *      */
        /*"      *   EM 01/10/2010 - TERCIO FREITAS (FAST COMPUTER)               *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.08         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ALTERACAO ..............  23/08/2010                         *      */
        /*"      *   CAD-45765   - MARCO PAIVA (FAST COMPUTER)                    *      */
        /*"      *                 TRATAR OS PRODUTOS (SYSTEM CRED)               *      */
        /*"      *                 - 8114 (AP VIDA TRANQUILA PREMIADO EDUCACIONAL)*      */
        /*"      *                 - 8115 (AP VIDA TRANQUILA PREMIADO SAF)        *      */
        /*"      *                 - 8116 (AP VIDA TRANQUILO PREMIADO CHECK LAR)  *      */
        /*"      *                 - 8117 (AP VIDA TRANQUILO PREMIADO HELP DESK)  *      */
        /*"      *                 - 8118 (AP VIDA TRANQUILO PREMIADO NUTRICIONAL)*      */
        /*"      *                                                                *      */
        /*"      *                                         PROCURE POR V.07       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ALTERACAO ..............  02/02/2010                         *      */
        /*"      *   CAD-36527   - MARCO PAIVA (FAST COMPUTER)                    *      */
        /*"      *                             VER V.06                           *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ALTERACAO ..............  30/04/2009       FAST COMPUTER     *      */
        /*"      *   CAD-22904                                                    *      */
        /*"      *                             VER V.05                           *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ALTERACAO ..............  29/09/2008       FAST COMPUTER     *      */
        /*"      *   CAD-13381                                                    *      */
        /*"      *                             VER V.04                           *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ALTERACOES .............  - CLOVIS 05/09/2002 VER CL0902     *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   003 - MANOEL MESSIAS - 22/04/2004 (PROCURE POR MM0404)       *      */
        /*"      *       ZERA A DATA3 TODA VEZ QUE FOR FAZER O CALL DA PROSOCU1.  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   002 - MANOEL MESSIAS - 05/11/2002 (PROCURE POR MM0511)       *      */
        /*"      *       A ROTINA DE CALCULO DE DIAS UTEIS, ESTAVA CONTANDO OS    *      */
        /*"      *  DIAS SEQUENCIALMENTE INCLUINDO FINAL DE SEMANA E FERIADOS.    *      */
        /*"      *  FOI ALTERADA, ENTAO, MOVENDO 1 DIA POR VEZ, POIS, DESTA MANEI-*      */
        /*"      *  RA A ROTINA FICA IGUAL AO PROGRAMA VA0340B QUE NAO APRESENTOU *      */
        /*"      *  NENHUM PROBLEMA.                                              *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * TABELA                              VIEW              ACESSO   *      */
        /*"      * ---------------------------------------------------------------*      */
        /*"      * SISTEMAS                            V1SISTEMA         INPUT    *      */
        /*"      *                                     V0MOVDEBCC_CEF    I-O      *      */
        /*"      *                                     V0PARAM_CONTACEF  I-O      *      */
        /*"      *                                     V1BILHETE         I-O      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        #endregion


        #region VARIABLES

        public FileBasis _MOVCREDITO_CC { get; set; } = new FileBasis(new PIC("X", "150", "X(150)"));

        public FileBasis MOVCREDITO_CC
        {
            get
            {
                _.Move(HEADER_REGISTRO, _MOVCREDITO_CC); VarBasis.RedefinePassValue(HEADER_REGISTRO, _MOVCREDITO_CC, HEADER_REGISTRO); return _MOVCREDITO_CC;
            }
        }
        public FileBasis _RBI6032B { get; set; } = new FileBasis(new PIC("X", "132", "X(132)"));

        public FileBasis RBI6032B
        {
            get
            {
                _.Move(REG_BI6032B, _RBI6032B); VarBasis.RedefinePassValue(REG_BI6032B, _RBI6032B, REG_BI6032B); return _RBI6032B;
            }
        }
        /*"01        HEADER-REGISTRO.*/
        public BI6032B_HEADER_REGISTRO HEADER_REGISTRO { get; set; } = new BI6032B_HEADER_REGISTRO();
        public class BI6032B_HEADER_REGISTRO : VarBasis
        {
            /*"  05      HEADER-CODREGISTRO  PIC  X(001).*/
            public StringBasis HEADER_CODREGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  05      HEADER-CODREMESSA   PIC  9(001).*/
            public IntBasis HEADER_CODREMESSA { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"  05      HEADER-CODCONVENIO  PIC  X(020).*/
            public StringBasis HEADER_CODCONVENIO { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
            /*"  05      HEADER-NOMEMPRESA   PIC  X(020).*/
            public StringBasis HEADER_NOMEMPRESA { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
            /*"  05      HEADER-CODBANCO     PIC  9(003).*/
            public IntBasis HEADER_CODBANCO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
            /*"  05      HEADER-NOMBANCO     PIC  X(020).*/
            public StringBasis HEADER_NOMBANCO { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
            /*"  05      HEADER-DATGERACAO   PIC  9(008).*/
            public IntBasis HEADER_DATGERACAO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"  05      HEADER-NSA          PIC  9(006).*/
            public IntBasis HEADER_NSA { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"  05      HEADER-VERSAO       PIC  9(002).*/
            public IntBasis HEADER_VERSAO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"  05      HEADER-DEBITOAUT    PIC  X(017).*/
            public StringBasis HEADER_DEBITOAUT { get; set; } = new StringBasis(new PIC("X", "17", "X(017)."), @"");
            /*"  05      HEADER-FILLER       PIC  X(044).*/
            public StringBasis HEADER_FILLER { get; set; } = new StringBasis(new PIC("X", "44", "X(044)."), @"");
            /*"  05      HEADER-NOMPROGRAMA  PIC  X(008).*/
            public StringBasis HEADER_NOMPROGRAMA { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"01        MOVCC-REGISTRO.*/
        }
        public BI6032B_MOVCC_REGISTRO MOVCC_REGISTRO { get; set; } = new BI6032B_MOVCC_REGISTRO();
        public class BI6032B_MOVCC_REGISTRO : VarBasis
        {
            /*"  05      MOVCC-CODREGISTRO  PIC  X(001).*/
            public StringBasis MOVCC_CODREGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  05      MOVCC-IDTCLIEMP    PIC  X(025).*/
            public StringBasis MOVCC_IDTCLIEMP { get; set; } = new StringBasis(new PIC("X", "25", "X(025)."), @"");
            /*"  05      MOVCC-AGECREDITO   PIC  X(004).*/
            public StringBasis MOVCC_AGECREDITO { get; set; } = new StringBasis(new PIC("X", "4", "X(004)."), @"");
            /*"  05      MOVCC-IDTCLIBAN    PIC  X(019).*/
            public StringBasis MOVCC_IDTCLIBAN { get; set; } = new StringBasis(new PIC("X", "19", "X(019)."), @"");
            /*"  05      MOVCC-DTVENCTO     PIC  9(008).*/
            public IntBasis MOVCC_DTVENCTO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"  05      MOVCC-VLRCREDITO   PIC  9(013)V99.*/
            public DoubleBasis MOVCC_VLRCREDITO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
            /*"  05      MOVCC-CODMOEDA     PIC  X(002).*/
            public StringBasis MOVCC_CODMOEDA { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
            /*"  05      MOVCC-USOEMPRESA   PIC  X(058).*/
            public StringBasis MOVCC_USOEMPRESA { get; set; } = new StringBasis(new PIC("X", "58", "X(058)."), @"");
            /*"  05      MOVCC-FILLER       PIC  X(002).*/
            public StringBasis MOVCC_FILLER { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
            /*"  05      MOVCC-NUMBILHETE   PIC  9(015).*/
            public IntBasis MOVCC_NUMBILHETE { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
            /*"  05      MOVCC-CODMOVTO     PIC  9(001).*/
            public IntBasis MOVCC_CODMOVTO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"01        TRAILL-REGISTRO.*/
        }
        public BI6032B_TRAILL_REGISTRO TRAILL_REGISTRO { get; set; } = new BI6032B_TRAILL_REGISTRO();
        public class BI6032B_TRAILL_REGISTRO : VarBasis
        {
            /*"  05      TRAILL-CODREGISTRO  PIC  X(001).*/
            public StringBasis TRAILL_CODREGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  05      TRAILL-TOTREGISTRO  PIC  9(006).*/
            public IntBasis TRAILL_TOTREGISTRO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"  05      TRAILL-VLRTOTDEB    PIC  9(015)V99.*/
            public DoubleBasis TRAILL_VLRTOTDEB { get; set; } = new DoubleBasis(new PIC("9", "15", "9(015)V99."), 2);
            /*"  05      TRAILL-VLRTOTCRE    PIC  9(015)V99.*/
            public DoubleBasis TRAILL_VLRTOTCRE { get; set; } = new DoubleBasis(new PIC("9", "15", "9(015)V99."), 2);
            /*"  05      TRAILL-FILLER       PIC  X(109).*/
            public StringBasis TRAILL_FILLER { get; set; } = new StringBasis(new PIC("X", "109", "X(109)."), @"");
            /*"01        REG-BI6032B        PIC  X(132).*/
        }
        public StringBasis REG_BI6032B { get; set; } = new StringBasis(new PIC("X", "132", "X(132)."), @"");

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77  V1SISTE-DTMOVABE             PIC X(10).*/
        public StringBasis V1SISTE_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V1SISTE-DTCURRENT            PIC X(10).*/
        public StringBasis V1SISTE_DTCURRENT { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V1EMPR-COD-EMP               PIC S9(004)     COMP.*/
        public IntBasis V1EMPR_COD_EMP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  V1EMPR-NOM-EMP               PIC  X(040).*/
        public StringBasis V1EMPR_NOM_EMP { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"77  V0MOVDE-NUM-APOLICE          PIC S9(13) COMP-3.*/
        public IntBasis V0MOVDE_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"77  V0MOVDE-SIT-COBRANCA         PIC X(1).*/
        public StringBasis V0MOVDE_SIT_COBRANCA { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"77  V0MOVDE-DTVENCTO             PIC X(10).*/
        public StringBasis V0MOVDE_DTVENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V0MOVDE-DIA-DEBITO           PIC S9(04) COMP.*/
        public IntBasis V0MOVDE_DIA_DEBITO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0MOVDE-VLR-DEBITO           PIC S9(13)V9(2) COMP-3.*/
        public DoubleBasis V0MOVDE_VLR_DEBITO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"77  V0MOVDE-COD-AGENCIA-DEB      PIC S9(04) COMP.*/
        public IntBasis V0MOVDE_COD_AGENCIA_DEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0MOVDE-OPER-CONTA-DEB       PIC S9(04) COMP.*/
        public IntBasis V0MOVDE_OPER_CONTA_DEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0MOVDE-NUM-CONTA-DEB        PIC S9(13) COMP-3.*/
        public IntBasis V0MOVDE_NUM_CONTA_DEB { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"77  V0MOVDE-DIG-CONTA-DEB        PIC S9(04) COMP.*/
        public IntBasis V0MOVDE_DIG_CONTA_DEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0MOVDE-COD-CONVENIO         PIC S9(09) COMP.*/
        public IntBasis V0MOVDE_COD_CONVENIO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77  V0MOVDE-DTMOVTO              PIC X(10).*/
        public StringBasis V0MOVDE_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V0MOVDE-DTENVIO              PIC X(10).*/
        public StringBasis V0MOVDE_DTENVIO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V0MOVDE-DTRETORNO            PIC X(10).*/
        public StringBasis V0MOVDE_DTRETORNO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V0MOVDE-COD-RETORNO-CEF      PIC S9(04) COMP.*/
        public IntBasis V0MOVDE_COD_RETORNO_CEF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0MOVDE-NSAS                 PIC S9(04) COMP.*/
        public IntBasis V0MOVDE_NSAS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0PARAMC-TIPO-MOVTOCC         PIC S9(04) COMP.*/
        public IntBasis V0PARAMC_TIPO_MOVTOCC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0PARAMC-CODPRODU             PIC S9(04) COMP.*/
        public IntBasis V0PARAMC_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0PARAMC-COD-CONVENIO         PIC S9(09) COMP.*/
        public IntBasis V0PARAMC_COD_CONVENIO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77  V0PARAMC-NSAS                 PIC S9(04) COMP.*/
        public IntBasis V0PARAMC_NSAS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0PARAMC-DIA-DEBITO           PIC S9(04) COMP.*/
        public IntBasis V0PARAMC_DIA_DEBITO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0PARAMC-SITUACAO             PIC X(1).*/
        public StringBasis V0PARAMC_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"77  V0RELAT-NRTIT                 PIC S9(13) COMP-3.*/
        public IntBasis V0RELAT_NRTIT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"77  V0RELAT-NUM-APOLICE           PIC S9(13) COMP-3.*/
        public IntBasis V0RELAT_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"77  V0RELAT-CODRELAT              PIC  X(08).*/
        public StringBasis V0RELAT_CODRELAT { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
        /*"77  V0RELAT-SITUACAO              PIC  X(01).*/
        public StringBasis V0RELAT_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"77  V0RELAT-QUANTIDADE            PIC S9(04) COMP.*/
        public IntBasis V0RELAT_QUANTIDADE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V1BILH-NUMBIL                 PIC S9(15) COMP-3.*/
        public IntBasis V1BILH_NUMBIL { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"77  V1BILH-NUM-APOL               PIC S9(13) COMP-3.*/
        public IntBasis V1BILH_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"77  V1BILH-MATR-IND               PIC S9(15) COMP-3.*/
        public IntBasis V1BILH_MATR_IND { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"77  V1BILH-SITUACAO               PIC  X(01).*/
        public StringBasis V1BILH_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"77  V1BILH-COD-CLIENTE            PIC S9(09) COMP.*/
        public IntBasis V1BILH_COD_CLIENTE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77  V1BILH-AGENCIA-DEB            PIC S9(04) COMP.*/
        public IntBasis V1BILH_AGENCIA_DEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V1BILH-OPERACAO-DEB           PIC S9(04) COMP.*/
        public IntBasis V1BILH_OPERACAO_DEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V1BILH-CONTA-DEB              PIC S9(13) COMP-3.*/
        public IntBasis V1BILH_CONTA_DEB { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"77  V1BILH-DIGITO-DEB             PIC S9(04) COMP.*/
        public IntBasis V1BILH_DIGITO_DEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V1CLIEN-COD-CLIENTE           PIC S9(09) COMP.*/
        public IntBasis V1CLIEN_COD_CLIENTE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77  V1CLIEN-NOME-RAZAO            PIC  X(40).*/
        public StringBasis V1CLIEN_NOME_RAZAO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"77  V0RCAP-NRTIT                  PIC S9(13) COMP-3.*/
        public IntBasis V0RCAP_NRTIT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"77  V0RCAP-OPERACAO               PIC S9(04) COMP.*/
        public IntBasis V0RCAP_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  W-TAB-SISTEMA-ORIGEM.*/
        public BI6032B_W_TAB_SISTEMA_ORIGEM W_TAB_SISTEMA_ORIGEM { get; set; } = new BI6032B_W_TAB_SISTEMA_ORIGEM();
        public class BI6032B_W_TAB_SISTEMA_ORIGEM : VarBasis
        {
            /*"    05  WTAB-SISTEMA-ORIGEM   OCCURS    200  TIMES                                PIC  S9(004) COMP.*/
            public ListBasis<IntBasis, Int64> WTAB_SISTEMA_ORIGEM { get; set; } = new ListBasis<IntBasis, Int64>(new PIC("S9", "4", "S9(004)"), 200);
            /*"01           AREA-DE-WORK.*/
        }
        public BI6032B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new BI6032B_AREA_DE_WORK();
        public class BI6032B_AREA_DE_WORK : VarBasis
        {
            /*"  05         WIND                 PIC S9(004) COMP VALUE +0.*/
            public IntBasis WIND { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05         WIND1                PIC S9(004) COMP VALUE +0.*/
            public IntBasis WIND1 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05         WINF                 PIC S9(004) COMP VALUE +0.*/
            public IntBasis WINF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05         WSUP                 PIC S9(004) COMP VALUE +0.*/
            public IntBasis WSUP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05         WTEM-SISTEMA-ORIGEM  PIC  X(003) VALUE SPACES.*/
            public StringBasis WTEM_SISTEMA_ORIGEM { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"  05         WS-MAX-PARCEL        PIC  X(001)    VALUE 'S'.*/
            public StringBasis WS_MAX_PARCEL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"S");
            /*"  05         WS-BILHETE           PIC  X(001)    VALUE 'S'.*/
            public StringBasis WS_BILHETE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"S");
            /*"  05         WS-VLPREMIO          PIC S9(13)V9(2) COMP-3.*/
            public DoubleBasis WS_VLPREMIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
            /*"  05         WS-PARCELA        PIC  S9(004) COMP VALUE ZEROS.*/
            public IntBasis WS_PARCELA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05         WS-ENDOSSO        PIC  S9(009) COMP VALUE ZEROS.*/
            public IntBasis WS_ENDOSSO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  05         WS-NULL-PARCEL       PIC  S9(04)  COMP.*/
            public IntBasis WS_NULL_PARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"  05         WS-NULL-ENDOSSO      PIC  S9(04)  COMP.*/
            public IntBasis WS_NULL_ENDOSSO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"  05         WS-APOLICE           PIC S9(13) COMP-3.*/
            public IntBasis WS_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
            /*"  05         WFIMV1SISTEMA        PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIMV1SISTEMA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIMV0PARAM-CONTACEF PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIMV0PARAM_CONTACEF { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIMV0MOVDEBCC-CEF   PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIMV0MOVDEBCC_CEF { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIMV0RELATORIOS     PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIMV0RELATORIOS { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-SISTEMA-ORIGEM  PIC  X(003)    VALUE SPACES.*/
            public StringBasis WFIM_SISTEMA_ORIGEM { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"  05         WPAG                 PIC  9(009)    VALUE ZEROS.*/
            public IntBasis WPAG { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05         WLIN                 PIC  9(009)    VALUE 90.*/
            public IntBasis WLIN { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"), 90);
            /*"  05         WTOTPARAMC           PIC  9(009)    VALUE ZEROS.*/
            public IntBasis WTOTPARAMC { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05         WTOTMOVCR            PIC  9(009)    VALUE ZEROS.*/
            public IntBasis WTOTMOVCR { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05         WTOTREG              PIC  9(006)    VALUE ZEROS.*/
            public IntBasis WTOTREG { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  05         WTOTCRE              PIC  9(016)V99 VALUE ZEROS.*/
            public DoubleBasis WTOTCRE { get; set; } = new DoubleBasis(new PIC("9", "16", "9(016)V99"), 2);
            /*"  05         WCOD-CONVENIO        PIC S9(004) COMP VALUE ZEROS.*/
            public IntBasis WCOD_CONVENIO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05         WDATSIS              PIC  9(008)    VALUE ZEROS.*/
            public IntBasis WDATSIS { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"  05         WNSAS                PIC  9(006)    VALUE ZEROS.*/
            public IntBasis WNSAS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  05         WIDTCLIBAN           PIC   X(019).*/
            public StringBasis WIDTCLIBAN { get; set; } = new StringBasis(new PIC("X", "19", "X(019)."), @"");
            /*"  05         FILLER        REDEFINES    WIDTCLIBAN.*/
            private _REDEF_BI6032B_FILLER_0 _filler_0 { get; set; }
            public _REDEF_BI6032B_FILLER_0 FILLER_0
            {
                get { _filler_0 = new _REDEF_BI6032B_FILLER_0(); _.Move(WIDTCLIBAN, _filler_0); VarBasis.RedefinePassValue(WIDTCLIBAN, _filler_0, WIDTCLIBAN); _filler_0.ValueChanged += () => { _.Move(_filler_0, WIDTCLIBAN); }; return _filler_0; }
                set { VarBasis.RedefinePassValue(value, _filler_0, WIDTCLIBAN); }
            }  //Redefines
            public class _REDEF_BI6032B_FILLER_0 : VarBasis
            {
                /*"     10      WOPER-CONTA          PIC   9(004).*/
                public IntBasis WOPER_CONTA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"     10      WNUM-CONTA           PIC   9(012).*/
                public IntBasis WNUM_CONTA { get; set; } = new IntBasis(new PIC("9", "12", "9(012)."));
                /*"     10      WDIG-CONTA           PIC   9(001).*/
                public IntBasis WDIG_CONTA { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"     10      WIDT-SPACES          PIC   X(002).*/
                public StringBasis WIDT_SPACES { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"  05         WIDTCLIEMP           PIC  X(025).*/

                public _REDEF_BI6032B_FILLER_0()
                {
                    WOPER_CONTA.ValueChanged += OnValueChanged;
                    WNUM_CONTA.ValueChanged += OnValueChanged;
                    WDIG_CONTA.ValueChanged += OnValueChanged;
                    WIDT_SPACES.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WIDTCLIEMP { get; set; } = new StringBasis(new PIC("X", "25", "X(025)."), @"");
            /*"  05         FILLER        REDEFINES   WIDTCLIEMP.*/
            private _REDEF_BI6032B_FILLER_1 _filler_1 { get; set; }
            public _REDEF_BI6032B_FILLER_1 FILLER_1
            {
                get { _filler_1 = new _REDEF_BI6032B_FILLER_1(); _.Move(WIDTCLIEMP, _filler_1); VarBasis.RedefinePassValue(WIDTCLIEMP, _filler_1, WIDTCLIEMP); _filler_1.ValueChanged += () => { _.Move(_filler_1, WIDTCLIEMP); }; return _filler_1; }
                set { VarBasis.RedefinePassValue(value, _filler_1, WIDTCLIEMP); }
            }  //Redefines
            public class _REDEF_BI6032B_FILLER_1 : VarBasis
            {
                /*"     10      WNUM-APOL            PIC   9(013).*/
                public IntBasis WNUM_APOL { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
                /*"     10      WNRENDOS             PIC   9(006).*/
                public IntBasis WNRENDOS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"     10      WNRPARCEL            PIC   9(002).*/
                public IntBasis WNRPARCEL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"     10      WEMP-SPACES          PIC   X(004).*/
                public StringBasis WEMP_SPACES { get; set; } = new StringBasis(new PIC("X", "4", "X(004)."), @"");
                /*"  05         WDATA-CURR        PIC  X(010)    VALUE SPACES.*/

                public _REDEF_BI6032B_FILLER_1()
                {
                    WNUM_APOL.ValueChanged += OnValueChanged;
                    WNRENDOS.ValueChanged += OnValueChanged;
                    WNRPARCEL.ValueChanged += OnValueChanged;
                    WEMP_SPACES.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WDATA_CURR { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05         FILLER            REDEFINES      WDATA-CURR.*/
            private _REDEF_BI6032B_FILLER_2 _filler_2 { get; set; }
            public _REDEF_BI6032B_FILLER_2 FILLER_2
            {
                get { _filler_2 = new _REDEF_BI6032B_FILLER_2(); _.Move(WDATA_CURR, _filler_2); VarBasis.RedefinePassValue(WDATA_CURR, _filler_2, WDATA_CURR); _filler_2.ValueChanged += () => { _.Move(_filler_2, WDATA_CURR); }; return _filler_2; }
                set { VarBasis.RedefinePassValue(value, _filler_2, WDATA_CURR); }
            }  //Redefines
            public class _REDEF_BI6032B_FILLER_2 : VarBasis
            {
                /*"    10       WDATA-AA-CURR     PIC  9(004).*/
                public IntBasis WDATA_AA_CURR { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDATA-MM-CURR     PIC  9(002).*/
                public IntBasis WDATA_MM_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDATA-DD-CURR     PIC  9(002).*/
                public IntBasis WDATA_DD_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05         WDATA-SIST        PIC  9(008)    VALUE ZEROS.*/

                public _REDEF_BI6032B_FILLER_2()
                {
                    WDATA_AA_CURR.ValueChanged += OnValueChanged;
                    FILLER_3.ValueChanged += OnValueChanged;
                    WDATA_MM_CURR.ValueChanged += OnValueChanged;
                    FILLER_4.ValueChanged += OnValueChanged;
                    WDATA_DD_CURR.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WDATA_SIST { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"  05         FILLER            REDEFINES      WDATA-SIST.*/
            private _REDEF_BI6032B_FILLER_5 _filler_5 { get; set; }
            public _REDEF_BI6032B_FILLER_5 FILLER_5
            {
                get { _filler_5 = new _REDEF_BI6032B_FILLER_5(); _.Move(WDATA_SIST, _filler_5); VarBasis.RedefinePassValue(WDATA_SIST, _filler_5, WDATA_SIST); _filler_5.ValueChanged += () => { _.Move(_filler_5, WDATA_SIST); }; return _filler_5; }
                set { VarBasis.RedefinePassValue(value, _filler_5, WDATA_SIST); }
            }  //Redefines
            public class _REDEF_BI6032B_FILLER_5 : VarBasis
            {
                /*"    10       WDATA-AA-SIST     PIC  9(004).*/
                public IntBasis WDATA_AA_SIST { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       WDATA-MM-SIST     PIC  9(002).*/
                public IntBasis WDATA_MM_SIST { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       WDATA-DD-SIST     PIC  9(002).*/
                public IntBasis WDATA_DD_SIST { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05         WHORA-CURR.*/

                public _REDEF_BI6032B_FILLER_5()
                {
                    WDATA_AA_SIST.ValueChanged += OnValueChanged;
                    WDATA_MM_SIST.ValueChanged += OnValueChanged;
                    WDATA_DD_SIST.ValueChanged += OnValueChanged;
                }

            }
            public BI6032B_WHORA_CURR WHORA_CURR { get; set; } = new BI6032B_WHORA_CURR();
            public class BI6032B_WHORA_CURR : VarBasis
            {
                /*"    10       WHORA-HH-CURR     PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WHORA_HH_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       WHORA-MM-CURR     PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WHORA_MM_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       WHORA-SS-CURR     PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WHORA_SS_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       WHORA-CC-CURR     PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WHORA_CC_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  05         WDATA-CABEC.*/
            }
            public BI6032B_WDATA_CABEC WDATA_CABEC { get; set; } = new BI6032B_WDATA_CABEC();
            public class BI6032B_WDATA_CABEC : VarBasis
            {
                /*"    10       WDATA-DD-CABEC    PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WDATA_DD_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       FILLER            PIC  X(001)    VALUE '/'.*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10       WDATA-MM-CABEC    PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WDATA_MM_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       FILLER            PIC  X(001)    VALUE '/'.*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10       WDATA-AA-CABEC    PIC  9(004)    VALUE ZEROS.*/
                public IntBasis WDATA_AA_CABEC { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"  05         WHORA-CABEC.*/
            }
            public BI6032B_WHORA_CABEC WHORA_CABEC { get; set; } = new BI6032B_WHORA_CABEC();
            public class BI6032B_WHORA_CABEC : VarBasis
            {
                /*"    10       WHORA-HH-CABEC    PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WHORA_HH_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       FILLER            PIC  X(001)    VALUE '.'.*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @".");
                /*"    10       WHORA-MM-CABEC    PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WHORA_MM_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       FILLER            PIC  X(001)    VALUE '.'.*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @".");
                /*"    10       WHORA-SS-CABEC    PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WHORA_SS_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  05         WUSOEMPRESA          PIC  X(060).*/
            }
            public StringBasis WUSOEMPRESA { get; set; } = new StringBasis(new PIC("X", "60", "X(060)."), @"");
            /*"  05         FILLER        REDEFINES   WUSOEMPRESA.*/
            private _REDEF_BI6032B_FILLER_10 _filler_10 { get; set; }
            public _REDEF_BI6032B_FILLER_10 FILLER_10
            {
                get { _filler_10 = new _REDEF_BI6032B_FILLER_10(); _.Move(WUSOEMPRESA, _filler_10); VarBasis.RedefinePassValue(WUSOEMPRESA, _filler_10, WUSOEMPRESA); _filler_10.ValueChanged += () => { _.Move(_filler_10, WUSOEMPRESA); }; return _filler_10; }
                set { VarBasis.RedefinePassValue(value, _filler_10, WUSOEMPRESA); }
            }  //Redefines
            public class _REDEF_BI6032B_FILLER_10 : VarBasis
            {
                /*"     10      WUSO-CONVENIO        PIC   9(006).*/
                public IntBasis WUSO_CONVENIO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"     10      WUSO-NSAS            PIC   9(006).*/
                public IntBasis WUSO_NSAS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"     10      WUSO-SEQFITA         PIC   9(006).*/
                public IntBasis WUSO_SEQFITA { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"     10      WUSO-SPACES          PIC   X(042).*/
                public StringBasis WUSO_SPACES { get; set; } = new StringBasis(new PIC("X", "42", "X(042)."), @"");
                /*"  05         WDATA-SQL            PIC   X(010).*/

                public _REDEF_BI6032B_FILLER_10()
                {
                    WUSO_CONVENIO.ValueChanged += OnValueChanged;
                    WUSO_NSAS.ValueChanged += OnValueChanged;
                    WUSO_SEQFITA.ValueChanged += OnValueChanged;
                    WUSO_SPACES.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WDATA_SQL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  05         FILLER        REDEFINES   WDATA-SQL.*/
            private _REDEF_BI6032B_FILLER_11 _filler_11 { get; set; }
            public _REDEF_BI6032B_FILLER_11 FILLER_11
            {
                get { _filler_11 = new _REDEF_BI6032B_FILLER_11(); _.Move(WDATA_SQL, _filler_11); VarBasis.RedefinePassValue(WDATA_SQL, _filler_11, WDATA_SQL); _filler_11.ValueChanged += () => { _.Move(_filler_11, WDATA_SQL); }; return _filler_11; }
                set { VarBasis.RedefinePassValue(value, _filler_11, WDATA_SQL); }
            }  //Redefines
            public class _REDEF_BI6032B_FILLER_11 : VarBasis
            {
                /*"     10      WANO-SQL             PIC   9(004).*/
                public IntBasis WANO_SQL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"     10      FILLER               PIC   X(001).*/
                public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"     10      WMES-SQL             PIC   9(002).*/
                public IntBasis WMES_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"     10      FILLER               PIC   X(001).*/
                public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"     10      WDIA-SQL             PIC   9(002).*/
                public IntBasis WDIA_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05         WDATATRA             PIC  9(008)    VALUE ZEROS.*/

                public _REDEF_BI6032B_FILLER_11()
                {
                    WANO_SQL.ValueChanged += OnValueChanged;
                    FILLER_12.ValueChanged += OnValueChanged;
                    WMES_SQL.ValueChanged += OnValueChanged;
                    FILLER_13.ValueChanged += OnValueChanged;
                    WDIA_SQL.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WDATATRA { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"  05         FILLER        REDEFINES   WDATATRA.*/
            private _REDEF_BI6032B_FILLER_14 _filler_14 { get; set; }
            public _REDEF_BI6032B_FILLER_14 FILLER_14
            {
                get { _filler_14 = new _REDEF_BI6032B_FILLER_14(); _.Move(WDATATRA, _filler_14); VarBasis.RedefinePassValue(WDATATRA, _filler_14, WDATATRA); _filler_14.ValueChanged += () => { _.Move(_filler_14, WDATATRA); }; return _filler_14; }
                set { VarBasis.RedefinePassValue(value, _filler_14, WDATATRA); }
            }  //Redefines
            public class _REDEF_BI6032B_FILLER_14 : VarBasis
            {
                /*"     10      WANO-TRA            PIC   9(004).*/
                public IntBasis WANO_TRA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"     10      WMES-TRA            PIC   9(002).*/
                public IntBasis WMES_TRA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"     10      WDIA-TRA            PIC   9(002).*/
                public IntBasis WDIA_TRA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05         WDATA-DISPLAY        PIC   X(010).*/

                public _REDEF_BI6032B_FILLER_14()
                {
                    WANO_TRA.ValueChanged += OnValueChanged;
                    WMES_TRA.ValueChanged += OnValueChanged;
                    WDIA_TRA.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WDATA_DISPLAY { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  05         LPARM.*/
            public BI6032B_LPARM LPARM { get; set; } = new BI6032B_LPARM();
            public class BI6032B_LPARM : VarBasis
            {
                /*"    10       DATA1.*/
                public BI6032B_DATA1 DATA1 { get; set; } = new BI6032B_DATA1();
                public class BI6032B_DATA1 : VarBasis
                {
                    /*"      15     DATA1-DD          PIC  9(002).*/
                    public IntBasis DATA1_DD { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"      15     DATA1-MM          PIC  9(002).*/
                    public IntBasis DATA1_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"      15     DATA1-AA          PIC  9(004).*/
                    public IntBasis DATA1_AA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"    10       RESPOSTA          PIC  X(001).*/
                }
                public StringBasis RESPOSTA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"  05         LPARM2.*/
            }
            public BI6032B_LPARM2 LPARM2 { get; set; } = new BI6032B_LPARM2();
            public class BI6032B_LPARM2 : VarBasis
            {
                /*"    10       DATA2.*/
                public BI6032B_DATA2 DATA2 { get; set; } = new BI6032B_DATA2();
                public class BI6032B_DATA2 : VarBasis
                {
                    /*"      15     DATA2-DD          PIC  9(002).*/
                    public IntBasis DATA2_DD { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"      15     DATA2-MM          PIC  9(002).*/
                    public IntBasis DATA2_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"      15     DATA2-AA          PIC  9(004).*/
                    public IntBasis DATA2_AA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"    10       QUANTIDA          PIC S9(005)   COMP-3.*/
                }
                public IntBasis QUANTIDA { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));
                /*"    10       DATA3.*/
                public BI6032B_DATA3 DATA3 { get; set; } = new BI6032B_DATA3();
                public class BI6032B_DATA3 : VarBasis
                {
                    /*"      15     DATA3-DD          PIC  9(002).*/
                    public IntBasis DATA3_DD { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"      15     DATA3-MM          PIC  9(002).*/
                    public IntBasis DATA3_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"      15     DATA3-AA          PIC  9(004).*/
                    public IntBasis DATA3_AA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"  05            LC01.*/
                }
            }
            public BI6032B_LC01 LC01 { get; set; } = new BI6032B_LC01();
            public class BI6032B_LC01 : VarBasis
            {
                /*"    10          LC01-RELATORIO  PIC  X(007) VALUE 'BI6032B'.*/
                public StringBasis LC01_RELATORIO { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"BI6032B");
                /*"    10          FILLER          PIC  X(036) VALUE  SPACES.*/
                public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "36", "X(036)"), @"");
                /*"    10          LC01-EMPRESA    PIC  X(040) VALUE  SPACES.*/
                public StringBasis LC01_EMPRESA { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"    10          FILLER          PIC  X(034) VALUE  SPACES.*/
                public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "34", "X(034)"), @"");
                /*"    10          FILLER          PIC  X(011) VALUE 'PAGINA'.*/
                public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"PAGINA");
                /*"    10          LC01-PAGINA     PIC  ZZZ9.*/
                public IntBasis LC01_PAGINA { get; set; } = new IntBasis(new PIC("9", "4", "ZZZ9."));
                /*"  05            LC02.*/
            }
            public BI6032B_LC02 LC02 { get; set; } = new BI6032B_LC02();
            public class BI6032B_LC02 : VarBasis
            {
                /*"    10          FILLER          PIC  X(117) VALUE  SPACES.*/
                public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "117", "X(117)"), @"");
                /*"    10          FILLER          PIC  X(005) VALUE 'DATA'.*/
                public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"DATA");
                /*"    10          LC02-DATA       PIC  X(010) VALUE  SPACES.*/
                public StringBasis LC02_DATA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"  05            LC03.*/
            }
            public BI6032B_LC03 LC03 { get; set; } = new BI6032B_LC03();
            public class BI6032B_LC03 : VarBasis
            {
                /*"    10          FILLER          PIC  X(025) VALUE  SPACES.*/
                public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"");
                /*"    10          FILLER          PIC  X(054) VALUE               'RELACAO DE DOCUMENTOS ENVIADOS PELA FITA DE CREDI               'TO - '.*/
                public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "54", "X(054)"), @"RELACAO DE DOCUMENTOS ENVIADOS PELA FITA DE CREDI               ");
                /*"    10          FILLER          PIC  X(018) VALUE 'C.E.F.'.*/
                public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "18", "X(018)"), @"C.E.F.");
                /*"    10          FILLER          PIC  X(003) VALUE 'EM'.*/
                public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"EM");
                /*"    10          LC03-DATA       PIC  X(010).*/
                public StringBasis LC03_DATA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"    10          FILLER          PIC  X(007) VALUE  SPACES.*/
                public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"");
                /*"    10          FILLER          PIC  X(007) VALUE 'HORA'.*/
                public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"HORA");
                /*"    10          LC03-HORA       PIC  X(008) VALUE  SPACES.*/
                public StringBasis LC03_HORA { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
                /*"  05            LC04.*/
            }
            public BI6032B_LC04 LC04 { get; set; } = new BI6032B_LC04();
            public class BI6032B_LC04 : VarBasis
            {
                /*"    10          FILLER          PIC  X(132) VALUE  ALL '-'.*/
                public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "132", "X(132)"), @"ALL");
                /*"  05            LC05.*/
            }
            public BI6032B_LC05 LC05 { get; set; } = new BI6032B_LC05();
            public class BI6032B_LC05 : VarBasis
            {
                /*"    10          FILLER          PIC  X(040)  VALUE      'AGENCIA       MATRICULA  DT.VENC.  DIA'.*/
                public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"AGENCIA       MATRICULA  DT.VENC.  DIA");
                /*"    10          FILLER          PIC  X(022)  VALUE      '-- C/C CREDITADA --'.*/
                public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "22", "X(022)"), @"-- C/C CREDITADA --");
                /*"    10          FILLER          PIC  X(041)  VALUE      'NOME DO SEGURADO'.*/
                public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "41", "X(041)"), @"NOME DO SEGURADO");
                /*"    10          FILLER          PIC  X(024)  VALUE      'BILHETE'.*/
                public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "24", "X(024)"), @"BILHETE");
                /*"    10          FILLER          PIC  X(005)  VALUE      'VALOR'.*/
                public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"VALOR");
                /*"  05            LC06.*/
            }
            public BI6032B_LC06 LC06 { get; set; } = new BI6032B_LC06();
            public class BI6032B_LC06 : VarBasis
            {
                /*"    10          FILLER          PIC  X(001) VALUE  SPACES.*/
                public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10          FILLER          PIC  X(011) VALUE    'FITA  NR.: '.*/
                public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"FITA  NR.: ");
                /*"    10          LC06-NRFITA     PIC  ZZZZZZZZZ9.*/
                public IntBasis LC06_NRFITA { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZZZZ9."));
                /*"  05            LC07.*/
            }
            public BI6032B_LC07 LC07 { get; set; } = new BI6032B_LC07();
            public class BI6032B_LC07 : VarBasis
            {
                /*"    10          FILLER          PIC  X(132) VALUE  ALL ' '.*/
                public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "132", "X(132)"), @"ALL");
                /*"  05            LD01.*/
            }
            public BI6032B_LD01 LD01 { get; set; } = new BI6032B_LD01();
            public class BI6032B_LD01 : VarBasis
            {
                /*"    10          FILLER          PIC  X(001) VALUE SPACES.*/
                public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10          LD01-AGENCIA    PIC  9(004).*/
                public IntBasis LD01_AGENCIA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10          FILLER          PIC  X(003) VALUE SPACES.*/
                public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
                /*"    10          LD01-MATRICULA  PIC  ZZZZZZZZZZZZZZ9.*/
                public IntBasis LD01_MATRICULA { get; set; } = new IntBasis(new PIC("9", "15", "ZZZZZZZZZZZZZZ9."));
                /*"    10          FILLER          PIC  X(001) VALUE SPACES.*/
                public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10          LD01-DTVENCTO   PIC  X(010).*/
                public StringBasis LD01_DTVENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"    10          FILLER          PIC  X(002) VALUE SPACES.*/
                public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
                /*"    10          LD01-DIA-CREDITO PIC 9(002).*/
                public IntBasis LD01_DIA_CREDITO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10          FILLER          PIC  X(002) VALUE SPACES.*/
                public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
                /*"    10          LD01-CREDITO.*/
                public BI6032B_LD01_CREDITO LD01_CREDITO { get; set; } = new BI6032B_LD01_CREDITO();
                public class BI6032B_LD01_CREDITO : VarBasis
                {
                    /*"      15        LD01-OPERACAO   PIC  9(004).*/
                    public IntBasis LD01_OPERACAO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"      15        LD01-BARRA      PIC  X(001).*/
                    public StringBasis LD01_BARRA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"      15        LD01-CONTA      PIC  9(012).*/
                    public IntBasis LD01_CONTA { get; set; } = new IntBasis(new PIC("9", "12", "9(012)."));
                    /*"      15        LD01-HIFEN1     PIC  X(001).*/
                    public StringBasis LD01_HIFEN1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"      15        LD01-DIGITO     PIC  9(001).*/
                    public IntBasis LD01_DIGITO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"    10          FILLER          PIC  X(003) VALUE SPACES.*/
                }
                public StringBasis FILLER_40 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
                /*"    10          LD01-NOME       PIC  X(040).*/
                public StringBasis LD01_NOME { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                /*"    10          FILLER          PIC  X(001) VALUE SPACES.*/
                public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10          LD01-NUMBIL     PIC  9(012).*/
                public IntBasis LD01_NUMBIL { get; set; } = new IntBasis(new PIC("9", "12", "9(012)."));
                /*"    10          FILLER          PIC  X(001) VALUE SPACES.*/
                public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10          LD01-VLCREDITO  PIC  Z.ZZZ.ZZZ.ZZ9,99.*/
                public DoubleBasis LD01_VLCREDITO { get; set; } = new DoubleBasis(new PIC("9", "10", "Z.ZZZ.ZZZ.ZZ9V99."), 2);
                /*"  05            LD02.*/
            }
            public BI6032B_LD02 LD02 { get; set; } = new BI6032B_LD02();
            public class BI6032B_LD02 : VarBasis
            {
                /*"    10          FILLER          PIC  X(048) VALUE SPACES.*/
                public StringBasis FILLER_43 { get; set; } = new StringBasis(new PIC("X", "48", "X(048)"), @"");
                /*"    10          FILLER          PIC  X(036) VALUE ALL '*'.*/
                public StringBasis FILLER_44 { get; set; } = new StringBasis(new PIC("X", "36", "X(036)"), @"ALL");
                /*"  05            LD03.*/
            }
            public BI6032B_LD03 LD03 { get; set; } = new BI6032B_LD03();
            public class BI6032B_LD03 : VarBasis
            {
                /*"    10          FILLER          PIC  X(048) VALUE SPACES.*/
                public StringBasis FILLER_45 { get; set; } = new StringBasis(new PIC("X", "48", "X(048)"), @"");
                /*"    10          FILLER          PIC  X(036) VALUE    '*  NAO HOUVE MOVIMENTO NESTA DATA  *'.*/
                public StringBasis FILLER_46 { get; set; } = new StringBasis(new PIC("X", "36", "X(036)"), @"*  NAO HOUVE MOVIMENTO NESTA DATA  *");
                /*"  05            LD04.*/
            }
            public BI6032B_LD04 LD04 { get; set; } = new BI6032B_LD04();
            public class BI6032B_LD04 : VarBasis
            {
                /*"    10          FILLER          PIC  X(048) VALUE SPACES.*/
                public StringBasis FILLER_47 { get; set; } = new StringBasis(new PIC("X", "48", "X(048)"), @"");
                /*"    10          FILLER          PIC  X(036) VALUE    '*                                  *'.*/
                public StringBasis FILLER_48 { get; set; } = new StringBasis(new PIC("X", "36", "X(036)"), @"*                                  *");
                /*"  05            LT01.*/
            }
            public BI6032B_LT01 LT01 { get; set; } = new BI6032B_LT01();
            public class BI6032B_LT01 : VarBasis
            {
                /*"    10          FILLER          PIC  X(062) VALUE SPACES.*/
                public StringBasis FILLER_49 { get; set; } = new StringBasis(new PIC("X", "62", "X(062)"), @"");
                /*"    10          FILLER          PIC  X(045) VALUE 'TOTAIS'.*/
                public StringBasis FILLER_50 { get; set; } = new StringBasis(new PIC("X", "45", "X(045)"), @"TOTAIS");
                /*"    10          LT01-QT-TOTAL   PIC  ZZZZ.ZZ9.*/
                public IntBasis LT01_QT_TOTAL { get; set; } = new IntBasis(new PIC("9", "7", "ZZZZ.ZZ9."));
                /*"    10          FILLER          PIC  X(001) VALUE SPACES.*/
                public StringBasis FILLER_51 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10          LT01-VL-TOTAL   PIC  Z.ZZZ.ZZZ.ZZ9,99.*/
                public DoubleBasis LT01_VL_TOTAL { get; set; } = new DoubleBasis(new PIC("9", "10", "Z.ZZZ.ZZZ.ZZ9V99."), 2);
                /*"  05        WABEND.*/
            }
            public BI6032B_WABEND WABEND { get; set; } = new BI6032B_WABEND();
            public class BI6032B_WABEND : VarBasis
            {
                /*"    10      FILLER              PIC  X(010) VALUE           ' BI6032B'.*/
                public StringBasis FILLER_52 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" BI6032B");
                /*"    10      FILLER              PIC  X(026) VALUE           ' *** ERRO EXEC SQL NUMERO '.*/
                public StringBasis FILLER_53 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @" *** ERRO EXEC SQL NUMERO ");
                /*"    10      WNR-EXEC-SQL        PIC  X(003) VALUE '000'.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"000");
                /*"    10      FILLER              PIC  X(013) VALUE           ' *** SQLCODE '.*/
                public StringBasis FILLER_54 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
                /*"    10      WSQLCODE            PIC  ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                /*"  05        WPARAGRAFO          PIC  X(040)    VALUE SPACES.*/
            }
            public StringBasis WPARAGRAFO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
            /*"01          LK-LINK.*/
        }
        public BI6032B_LK_LINK LK_LINK { get; set; } = new BI6032B_LK_LINK();
        public class BI6032B_LK_LINK : VarBasis
        {
            /*"  03        LK-RTCODE           PIC  S9(004)   VALUE +0   COMP.*/
            public IntBasis LK_RTCODE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  03        LK-TAMANHO          PIC  S9(004)   VALUE +40  COMP.*/
            public IntBasis LK_TAMANHO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), +40);
            /*"  03        LK-TITULO           PIC   X(132)   VALUE  SPACES.*/
            public StringBasis LK_TITULO { get; set; } = new StringBasis(new PIC("X", "132", "X(132)"), @"");
        }


        public Dclgens.PROPOFID PROPOFID { get; set; } = new Dclgens.PROPOFID();
        public Dclgens.MOVIMCOB MOVIMCOB { get; set; } = new Dclgens.MOVIMCOB();
        public Dclgens.ARQSIVPF ARQSIVPF { get; set; } = new Dclgens.ARQSIVPF();
        public BI6032B_V0RELAT V0RELAT { get; set; } = new BI6032B_V0RELAT();
        public BI6032B_V0MOVDE V0MOVDE { get; set; } = new BI6032B_V0MOVDE();
        public BI6032B_CORIGEM CORIGEM { get; set; } = new BI6032B_CORIGEM();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string MOVCREDITO_CC_FILE_NAME_P, string RBI6032B_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                MOVCREDITO_CC.SetFile(MOVCREDITO_CC_FILE_NAME_P);
                RBI6032B.SetFile(RBI6032B_FILE_NAME_P);

                /*" -597- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

                /*" -600- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

                /*" -603- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

                /*" -606- DISPLAY '-------------------------------------------' . */
                _.Display($"-------------------------------------------");

                /*" -607- DISPLAY 'PROGRAMA EM EXECUCAO: BI6032B              ' . */
                _.Display($"PROGRAMA EM EXECUCAO: BI6032B              ");

                /*" -608- DISPLAY '                         ' . */
                _.Display($"                         ");

                /*" -609- DISPLAY 'VERSAO: V.17 / DEMANDA 455132 - 24/02/2023 ' . */
                _.Display($"VERSAO: V.17 / DEMANDA 455132 - 24/02/2023 ");

                /*" -610- DISPLAY '                                           ' . */
                _.Display($"                                           ");

                /*" -612- DISPLAY '-------------------------------------------' . */
                _.Display($"-------------------------------------------");

                /*" -613- ACCEPT WHORA-CURR FROM TIME. */
                _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WHORA_CURR);

                /*" -614- MOVE WHORA-HH-CURR TO WHORA-HH-CABEC */
                _.Move(AREA_DE_WORK.WHORA_CURR.WHORA_HH_CURR, AREA_DE_WORK.WHORA_CABEC.WHORA_HH_CABEC);

                /*" -615- MOVE WHORA-MM-CURR TO WHORA-MM-CABEC */
                _.Move(AREA_DE_WORK.WHORA_CURR.WHORA_MM_CURR, AREA_DE_WORK.WHORA_CABEC.WHORA_MM_CABEC);

                /*" -616- MOVE WHORA-SS-CURR TO WHORA-SS-CABEC */
                _.Move(AREA_DE_WORK.WHORA_CURR.WHORA_SS_CURR, AREA_DE_WORK.WHORA_CABEC.WHORA_SS_CABEC);

                /*" -616- MOVE WHORA-CABEC TO LC03-HORA. */
                _.Move(AREA_DE_WORK.WHORA_CABEC, AREA_DE_WORK.LC03.LC03_HORA);

                /*" -616- FLUXCONTROL_PERFORM R0000-00-PRINCIPAL-SECTION */

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
            /*" -624- OPEN OUTPUT MOVCREDITO-CC RBI6032B */
            MOVCREDITO_CC.Open(HEADER_REGISTRO);
            RBI6032B.Open(REG_BI6032B);

            /*" -625- PERFORM R0010-00-SELECT-V1SISTEMA */

            R0010_00_SELECT_V1SISTEMA_SECTION();

            /*" -626- IF WFIMV1SISTEMA NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WFIMV1SISTEMA.IsEmpty())
            {

                /*" -628- GO TO R0000-90-FINALIZA. */

                R0000_90_FINALIZA(); //GOTO
                return;
            }


            /*" -630- PERFORM R0200-00-CARREGA-ORIGEM. */

            R0200_00_CARREGA_ORIGEM_SECTION();

            /*" -632- PERFORM R0015-00-MONTA-V1EMPRESA */

            R0015_00_MONTA_V1EMPRESA_SECTION();

            /*" -633- PERFORM R0020-00-LE-V0PARAM-CONTA */

            R0020_00_LE_V0PARAM_CONTA_SECTION();

            /*" -634- IF WFIMV0PARAM-CONTACEF EQUAL 'S' */

            if (AREA_DE_WORK.WFIMV0PARAM_CONTACEF == "S")
            {

                /*" -636- GO TO R0000-90-FINALIZA. */

                R0000_90_FINALIZA(); //GOTO
                return;
            }


            /*" -637- PERFORM R0030-00-DECLARE-V0RELATORIOS */

            R0030_00_DECLARE_V0RELATORIOS_SECTION();

            /*" -638- PERFORM R0040-00-LE-V0RELATORIOS */

            R0040_00_LE_V0RELATORIOS_SECTION();

            /*" -639- IF WFIMV0RELATORIOS EQUAL 'S' */

            if (AREA_DE_WORK.WFIMV0RELATORIOS == "S")
            {

                /*" -641- GO TO R0000-90-FINALIZA. */

                R0000_90_FINALIZA(); //GOTO
                return;
            }


            /*" -644- PERFORM R0050-00-PROCESSA-SOLIC UNTIL WFIMV0RELATORIOS EQUAL 'S' . */

            while (!(AREA_DE_WORK.WFIMV0RELATORIOS == "S"))
            {

                R0050_00_PROCESSA_SOLIC_SECTION();
            }

            /*" -645- IF WTOTMOVCR GREATER ZEROS */

            if (AREA_DE_WORK.WTOTMOVCR > 00)
            {

                /*" -646- PERFORM R0130-00-UPDATE-V0PARAM-CONTA */

                R0130_00_UPDATE_V0PARAM_CONTA_SECTION();

                /*" -647- PERFORM R0085-00-REGISTRO-TRAILLER */

                R0085_00_REGISTRO_TRAILLER_SECTION();

                /*" -647- PERFORM R0170-00-TOTALIZADOR. */

                R0170_00_TOTALIZADOR_SECTION();
            }


            /*" -0- FLUXCONTROL_PERFORM R0000_90_FINALIZA */

            R0000_90_FINALIZA();

        }

        [StopWatch]
        /*" R0000-90-FINALIZA */
        private void R0000_90_FINALIZA(bool isPerform = false)
        {
            /*" -652- IF WTOTMOVCR GREATER ZEROS */

            if (AREA_DE_WORK.WTOTMOVCR > 00)
            {

                /*" -654- DISPLAY '*** BI6032B *** DATA GERACAO DA FITA ' WDATSIS */
                _.Display($"*** BI6032B *** DATA GERACAO DA FITA {AREA_DE_WORK.WDATSIS}");

                /*" -656- DISPLAY '*** BI6032B *** DATA DO CREDITO      ' WDATA-DISPLAY */
                _.Display($"*** BI6032B *** DATA DO CREDITO      {AREA_DE_WORK.WDATA_DISPLAY}");

                /*" -658- DISPLAY '*** BI6032B *** QUANTIDADE           ' WTOTREG */
                _.Display($"*** BI6032B *** QUANTIDADE           {AREA_DE_WORK.WTOTREG}");

                /*" -660- DISPLAY '*** BI6032B *** VALOR TOTAL          ' WTOTCRE */
                _.Display($"*** BI6032B *** VALOR TOTAL          {AREA_DE_WORK.WTOTCRE}");

                /*" -662- DISPLAY '*** BI6032B *** NSA                  ' WNSAS */
                _.Display($"*** BI6032B *** NSA                  {AREA_DE_WORK.WNSAS}");

                /*" -663- DISPLAY ' ' */
                _.Display($" ");

                /*" -664- DISPLAY '*************************************' */
                _.Display($"*************************************");

                /*" -665- DISPLAY '*                                   *' */
                _.Display($"*                                   *");

                /*" -666- DISPLAY '* BI6032B - TERMINO NORMAL DE       *' */
                _.Display($"* BI6032B - TERMINO NORMAL DE       *");

                /*" -667- DISPLAY '*             PROCESSAMENTO         *' */
                _.Display($"*             PROCESSAMENTO         *");

                /*" -668- DISPLAY '*                                   *' */
                _.Display($"*                                   *");

                /*" -669- DISPLAY '*************************************' */
                _.Display($"*************************************");

                /*" -670- ELSE */
            }
            else
            {


                /*" -671- PERFORM R0160-00-CABECALHOS */

                R0160_00_CABECALHOS_SECTION();

                /*" -672- PERFORM R0180-00-RELAT-SEM-MOVTO */

                R0180_00_RELAT_SEM_MOVTO_SECTION();

                /*" -673- DISPLAY '******************************' */
                _.Display($"******************************");

                /*" -674- DISPLAY '* BI6032B - SEM MOVIMENTACAO *' */
                _.Display($"* BI6032B - SEM MOVIMENTACAO *");

                /*" -676- DISPLAY '******************************' . */
                _.Display($"******************************");
            }


            /*" -678- CLOSE MOVCREDITO-CC */
            MOVCREDITO_CC.Close();

            /*" -678- EXEC SQL COMMIT WORK END-EXEC */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -680- MOVE ZEROS TO RETURN-CODE */
            _.Move(0, RETURN_CODE);

            /*" -680- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0010-00-SELECT-V1SISTEMA-SECTION */
        private void R0010_00_SELECT_V1SISTEMA_SECTION()
        {
            /*" -690- MOVE 'R0010-00-SELECT-V1SISTEMA' TO WPARAGRAFO */
            _.Move("R0010-00-SELECT-V1SISTEMA", AREA_DE_WORK.WPARAGRAFO);

            /*" -692- MOVE '010' TO WNR-EXEC-SQL. */
            _.Move("010", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -697- PERFORM R0010_00_SELECT_V1SISTEMA_DB_SELECT_1 */

            R0010_00_SELECT_V1SISTEMA_DB_SELECT_1();

            /*" -700- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -701- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -702- DISPLAY 'BI6032B - SISTEMA (RN) NAO CADASTRADO' */
                    _.Display($"BI6032B - SISTEMA (RN) NAO CADASTRADO");

                    /*" -703- MOVE 'S' TO WFIMV1SISTEMA */
                    _.Move("S", AREA_DE_WORK.WFIMV1SISTEMA);

                    /*" -704- ELSE */
                }
                else
                {


                    /*" -705- DISPLAY 'BI6032B - ' WPARAGRAFO */
                    _.Display($"BI6032B - {AREA_DE_WORK.WPARAGRAFO}");

                    /*" -707- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -708- MOVE V1SISTE-DTCURRENT TO WDATA-CURR */
            _.Move(V1SISTE_DTCURRENT, AREA_DE_WORK.WDATA_CURR);

            /*" -709- MOVE WDATA-DD-CURR TO WDATA-DD-CABEC. */
            _.Move(AREA_DE_WORK.FILLER_2.WDATA_DD_CURR, AREA_DE_WORK.WDATA_CABEC.WDATA_DD_CABEC);

            /*" -710- MOVE WDATA-MM-CURR TO WDATA-MM-CABEC. */
            _.Move(AREA_DE_WORK.FILLER_2.WDATA_MM_CURR, AREA_DE_WORK.WDATA_CABEC.WDATA_MM_CABEC);

            /*" -711- MOVE WDATA-AA-CURR TO WDATA-AA-CABEC. */
            _.Move(AREA_DE_WORK.FILLER_2.WDATA_AA_CURR, AREA_DE_WORK.WDATA_CABEC.WDATA_AA_CABEC);

            /*" -713- MOVE WDATA-CABEC TO LC02-DATA. */
            _.Move(AREA_DE_WORK.WDATA_CABEC, AREA_DE_WORK.LC02.LC02_DATA);

            /*" -714- MOVE WDATA-DD-CURR TO WDATA-DD-SIST. */
            _.Move(AREA_DE_WORK.FILLER_2.WDATA_DD_CURR, AREA_DE_WORK.FILLER_5.WDATA_DD_SIST);

            /*" -715- MOVE WDATA-MM-CURR TO WDATA-MM-SIST. */
            _.Move(AREA_DE_WORK.FILLER_2.WDATA_MM_CURR, AREA_DE_WORK.FILLER_5.WDATA_MM_SIST);

            /*" -716- MOVE WDATA-AA-CURR TO WDATA-AA-SIST. */
            _.Move(AREA_DE_WORK.FILLER_2.WDATA_AA_CURR, AREA_DE_WORK.FILLER_5.WDATA_AA_SIST);

            /*" -716- MOVE WDATA-SIST TO WDATSIS. */
            _.Move(AREA_DE_WORK.WDATA_SIST, AREA_DE_WORK.WDATSIS);

        }

        [StopWatch]
        /*" R0010-00-SELECT-V1SISTEMA-DB-SELECT-1 */
        public void R0010_00_SELECT_V1SISTEMA_DB_SELECT_1()
        {
            /*" -697- EXEC SQL SELECT DTMOVABE, CURRENT DATE INTO :V1SISTE-DTMOVABE, :V1SISTE-DTCURRENT FROM SEGUROS.V1SISTEMA WHERE IDSISTEM = 'RN' END-EXEC. */

            var r0010_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1 = new R0010_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0010_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1.Execute(r0010_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1SISTE_DTMOVABE, V1SISTE_DTMOVABE);
                _.Move(executed_1.V1SISTE_DTCURRENT, V1SISTE_DTCURRENT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0010_99_SAIDA*/

        [StopWatch]
        /*" R0015-00-MONTA-V1EMPRESA-SECTION */
        private void R0015_00_MONTA_V1EMPRESA_SECTION()
        {
            /*" -725- MOVE 'R0015-00-MONTA-V1EMPRESA' TO WPARAGRAFO */
            _.Move("R0015-00-MONTA-V1EMPRESA", AREA_DE_WORK.WPARAGRAFO);

            /*" -727- MOVE '015' TO WNR-EXEC-SQL. */
            _.Move("015", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -731- PERFORM R0015_00_MONTA_V1EMPRESA_DB_SELECT_1 */

            R0015_00_MONTA_V1EMPRESA_DB_SELECT_1();

            /*" -734- MOVE V1EMPR-NOM-EMP TO LK-TITULO */
            _.Move(V1EMPR_NOM_EMP, LK_LINK.LK_TITULO);

            /*" -736- CALL 'PROALN01' USING LK-LINK */
            _.Call("PROALN01", LK_LINK);

            /*" -737- IF LK-RTCODE EQUAL ZEROS */

            if (LK_LINK.LK_RTCODE == 00)
            {

                /*" -738- MOVE LK-TITULO TO LC01-EMPRESA */
                _.Move(LK_LINK.LK_TITULO, AREA_DE_WORK.LC01.LC01_EMPRESA);

                /*" -739- ELSE */
            }
            else
            {


                /*" -740- DISPLAY 'PROBLEMA CALL V0EMPRESA' */
                _.Display($"PROBLEMA CALL V0EMPRESA");

                /*" -740- STOP RUN. */

                throw new GoBack();   // => STOP RUN.
            }


        }

        [StopWatch]
        /*" R0015-00-MONTA-V1EMPRESA-DB-SELECT-1 */
        public void R0015_00_MONTA_V1EMPRESA_DB_SELECT_1()
        {
            /*" -731- EXEC SQL SELECT NOME_EMPRESA INTO :V1EMPR-NOM-EMP FROM SEGUROS.V0EMPRESA WHERE COD_EMPRESA = 0 END-EXEC. */

            var r0015_00_MONTA_V1EMPRESA_DB_SELECT_1_Query1 = new R0015_00_MONTA_V1EMPRESA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0015_00_MONTA_V1EMPRESA_DB_SELECT_1_Query1.Execute(r0015_00_MONTA_V1EMPRESA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1EMPR_NOM_EMP, V1EMPR_NOM_EMP);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0015_99_SAIDA*/

        [StopWatch]
        /*" R0020-00-LE-V0PARAM-CONTA-SECTION */
        private void R0020_00_LE_V0PARAM_CONTA_SECTION()
        {
            /*" -749- MOVE 'R0020-00-LE-V0PARAM-CONTA' TO WPARAGRAFO */
            _.Move("R0020-00-LE-V0PARAM-CONTA", AREA_DE_WORK.WPARAGRAFO);

            /*" -751- MOVE '040' TO WNR-EXEC-SQL */
            _.Move("040", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -752- MOVE 'N' TO WFIMV0PARAM-CONTACEF */
            _.Move("N", AREA_DE_WORK.WFIMV0PARAM_CONTACEF);

            /*" -753- MOVE 01 TO V0PARAMC-TIPO-MOVTOCC */
            _.Move(01, V0PARAMC_TIPO_MOVTOCC);

            /*" -755- MOVE 'A' TO V0PARAMC-SITUACAO */
            _.Move("A", V0PARAMC_SITUACAO);

            /*" -769- PERFORM R0020_00_LE_V0PARAM_CONTA_DB_SELECT_1 */

            R0020_00_LE_V0PARAM_CONTA_DB_SELECT_1();

            /*" -772- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -773- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -774- MOVE 'S' TO WFIMV0PARAM-CONTACEF */
                    _.Move("S", AREA_DE_WORK.WFIMV0PARAM_CONTACEF);

                    /*" -775- GO TO R0020-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0020_99_SAIDA*/ //GOTO
                    return;

                    /*" -776- ELSE */
                }
                else
                {


                    /*" -777- DISPLAY 'BI6032B - ' WPARAGRAFO */
                    _.Display($"BI6032B - {AREA_DE_WORK.WPARAGRAFO}");

                    /*" -779- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -780- IF WCOD-CONVENIO EQUAL ZEROS */

            if (AREA_DE_WORK.WCOD_CONVENIO == 00)
            {

                /*" -781- MOVE V1SISTE-DTMOVABE TO WDATA-DISPLAY */
                _.Move(V1SISTE_DTMOVABE, AREA_DE_WORK.WDATA_DISPLAY);

                /*" -783- MOVE V0PARAMC-COD-CONVENIO TO WCOD-CONVENIO. */
                _.Move(V0PARAMC_COD_CONVENIO, AREA_DE_WORK.WCOD_CONVENIO);
            }


            /*" -784- MOVE V1SISTE-DTMOVABE TO WDATA-SQL */
            _.Move(V1SISTE_DTMOVABE, AREA_DE_WORK.WDATA_SQL);

            /*" -785- MOVE WDIA-SQL TO WDATA-DD-CABEC */
            _.Move(AREA_DE_WORK.FILLER_11.WDIA_SQL, AREA_DE_WORK.WDATA_CABEC.WDATA_DD_CABEC);

            /*" -786- MOVE WMES-SQL TO WDATA-MM-CABEC */
            _.Move(AREA_DE_WORK.FILLER_11.WMES_SQL, AREA_DE_WORK.WDATA_CABEC.WDATA_MM_CABEC);

            /*" -787- MOVE WANO-SQL TO WDATA-AA-CABEC */
            _.Move(AREA_DE_WORK.FILLER_11.WANO_SQL, AREA_DE_WORK.WDATA_CABEC.WDATA_AA_CABEC);

            /*" -789- MOVE WDATA-CABEC TO LC03-DATA */
            _.Move(AREA_DE_WORK.WDATA_CABEC, AREA_DE_WORK.LC03.LC03_DATA);

            /*" -789- COMPUTE WTOTPARAMC = WTOTPARAMC + 1. */
            AREA_DE_WORK.WTOTPARAMC.Value = AREA_DE_WORK.WTOTPARAMC + 1;

        }

        [StopWatch]
        /*" R0020-00-LE-V0PARAM-CONTA-DB-SELECT-1 */
        public void R0020_00_LE_V0PARAM_CONTA_DB_SELECT_1()
        {
            /*" -769- EXEC SQL SELECT CODPRODU, COD_CONVENIO, NSAS, DIA_DEBITO INTO :V0PARAMC-CODPRODU, :V0PARAMC-COD-CONVENIO, :V0PARAMC-NSAS, :V0PARAMC-DIA-DEBITO FROM SEGUROS.V0PARAM_CONTACEF WHERE TIPO_MOVTOCC = :V0PARAMC-TIPO-MOVTOCC AND SITUACAO = :V0PARAMC-SITUACAO AND COD_CONVENIO = 6114 AND CODPRODU = 7106 END-EXEC. */

            var r0020_00_LE_V0PARAM_CONTA_DB_SELECT_1_Query1 = new R0020_00_LE_V0PARAM_CONTA_DB_SELECT_1_Query1()
            {
                V0PARAMC_TIPO_MOVTOCC = V0PARAMC_TIPO_MOVTOCC.ToString(),
                V0PARAMC_SITUACAO = V0PARAMC_SITUACAO.ToString(),
            };

            var executed_1 = R0020_00_LE_V0PARAM_CONTA_DB_SELECT_1_Query1.Execute(r0020_00_LE_V0PARAM_CONTA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0PARAMC_CODPRODU, V0PARAMC_CODPRODU);
                _.Move(executed_1.V0PARAMC_COD_CONVENIO, V0PARAMC_COD_CONVENIO);
                _.Move(executed_1.V0PARAMC_NSAS, V0PARAMC_NSAS);
                _.Move(executed_1.V0PARAMC_DIA_DEBITO, V0PARAMC_DIA_DEBITO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0020_99_SAIDA*/

        [StopWatch]
        /*" R0030-00-DECLARE-V0RELATORIOS-SECTION */
        private void R0030_00_DECLARE_V0RELATORIOS_SECTION()
        {
            /*" -798- MOVE 'R0030-00-DECLARE-V0RELATORIOS' TO WPARAGRAFO */
            _.Move("R0030-00-DECLARE-V0RELATORIOS", AREA_DE_WORK.WPARAGRAFO);

            /*" -800- MOVE '020' TO WNR-EXEC-SQL */
            _.Move("020", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -801- MOVE 'N' TO WFIMV0RELATORIOS */
            _.Move("N", AREA_DE_WORK.WFIMV0RELATORIOS);

            /*" -803- MOVE 'BI6401B1' TO V0RELAT-CODRELAT. */
            _.Move("BI6401B1", V0RELAT_CODRELAT);

            /*" -809- PERFORM R0030_00_DECLARE_V0RELATORIOS_DB_DECLARE_1 */

            R0030_00_DECLARE_V0RELATORIOS_DB_DECLARE_1();

            /*" -811- PERFORM R0030_00_DECLARE_V0RELATORIOS_DB_OPEN_1 */

            R0030_00_DECLARE_V0RELATORIOS_DB_OPEN_1();

            /*" -814- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -815- DISPLAY 'BI6032B - ' WPARAGRAFO */
                _.Display($"BI6032B - {AREA_DE_WORK.WPARAGRAFO}");

                /*" -816- DISPLAY 'PROBLEMAS DECLARE V0RELATORIOS' */
                _.Display($"PROBLEMAS DECLARE V0RELATORIOS");

                /*" -816- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0030-00-DECLARE-V0RELATORIOS-DB-DECLARE-1 */
        public void R0030_00_DECLARE_V0RELATORIOS_DB_DECLARE_1()
        {
            /*" -809- EXEC SQL DECLARE V0RELAT CURSOR FOR SELECT NUM_APOLICE, NRTIT FROM SEGUROS.V0RELATORIOS WHERE CODRELAT = :V0RELAT-CODRELAT AND SITUACAO = '0' END-EXEC. */
            V0RELAT = new BI6032B_V0RELAT(true);
            string GetQuery_V0RELAT()
            {
                var query = @$"SELECT NUM_APOLICE
							, 
							NRTIT 
							FROM SEGUROS.V0RELATORIOS 
							WHERE CODRELAT = '{V0RELAT_CODRELAT}' 
							AND SITUACAO = '0'";

                return query;
            }
            V0RELAT.GetQueryEvent += GetQuery_V0RELAT;

        }

        [StopWatch]
        /*" R0030-00-DECLARE-V0RELATORIOS-DB-OPEN-1 */
        public void R0030_00_DECLARE_V0RELATORIOS_DB_OPEN_1()
        {
            /*" -811- EXEC SQL OPEN V0RELAT END-EXEC. */

            V0RELAT.Open();

        }

        [StopWatch]
        /*" R0060-00-DECLARE-V0MOVDEBCC-DB-DECLARE-1 */
        public void R0060_00_DECLARE_V0MOVDEBCC_DB_DECLARE_1()
        {
            /*" -923- EXEC SQL DECLARE V0MOVDE CURSOR FOR SELECT COD_CONVENIO, COD_AGENCIA_DEB, OPER_CONTA_DEB, NUM_CONTA_DEB, DIG_CONTA_DEB, DTVENCTO, VLR_DEBITO, NUM_APOLICE, DIA_DEBITO FROM SEGUROS.V0MOVDEBCC_CEF WHERE NUM_APOLICE = :V0MOVDE-NUM-APOLICE AND COD_CONVENIO = 6114 AND COD_RETORNO_CEF = 0 AND SIT_COBRANCA = '2' END-EXEC. */
            V0MOVDE = new BI6032B_V0MOVDE(true);
            string GetQuery_V0MOVDE()
            {
                var query = @$"SELECT 
							COD_CONVENIO
							, 
							COD_AGENCIA_DEB
							, 
							OPER_CONTA_DEB
							, 
							NUM_CONTA_DEB
							, 
							DIG_CONTA_DEB
							, 
							DTVENCTO
							, 
							VLR_DEBITO
							, 
							NUM_APOLICE
							, 
							DIA_DEBITO 
							FROM SEGUROS.V0MOVDEBCC_CEF 
							WHERE NUM_APOLICE = '{V0MOVDE_NUM_APOLICE}' 
							AND COD_CONVENIO = 6114 
							AND COD_RETORNO_CEF = 0 
							AND SIT_COBRANCA = '2'";

                return query;
            }
            V0MOVDE.GetQueryEvent += GetQuery_V0MOVDE;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0030_99_SAIDA*/

        [StopWatch]
        /*" R0040-00-LE-V0RELATORIOS-SECTION */
        private void R0040_00_LE_V0RELATORIOS_SECTION()
        {
            /*" -825- MOVE 'R0040-00-LE-V0RELATORIOS' TO WPARAGRAFO */
            _.Move("R0040-00-LE-V0RELATORIOS", AREA_DE_WORK.WPARAGRAFO);

            /*" -827- MOVE '025' TO WNR-EXEC-SQL */
            _.Move("025", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -830- PERFORM R0040_00_LE_V0RELATORIOS_DB_FETCH_1 */

            R0040_00_LE_V0RELATORIOS_DB_FETCH_1();

            /*" -833- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -834- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -835- MOVE 'S' TO WFIMV0RELATORIOS */
                    _.Move("S", AREA_DE_WORK.WFIMV0RELATORIOS);

                    /*" -835- PERFORM R0040_00_LE_V0RELATORIOS_DB_CLOSE_1 */

                    R0040_00_LE_V0RELATORIOS_DB_CLOSE_1();

                    /*" -837- GO TO R0040-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0040_99_SAIDA*/ //GOTO
                    return;

                    /*" -838- ELSE */
                }
                else
                {


                    /*" -839- DISPLAY 'BI6032B - ' WPARAGRAFO */
                    _.Display($"BI6032B - {AREA_DE_WORK.WPARAGRAFO}");

                    /*" -839- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R0040-00-LE-V0RELATORIOS-DB-FETCH-1 */
        public void R0040_00_LE_V0RELATORIOS_DB_FETCH_1()
        {
            /*" -830- EXEC SQL FETCH V0RELAT INTO :V0RELAT-NUM-APOLICE, :V0RELAT-NRTIT END-EXEC. */

            if (V0RELAT.Fetch())
            {
                _.Move(V0RELAT.V0RELAT_NUM_APOLICE, V0RELAT_NUM_APOLICE);
                _.Move(V0RELAT.V0RELAT_NRTIT, V0RELAT_NRTIT);
            }

        }

        [StopWatch]
        /*" R0040-00-LE-V0RELATORIOS-DB-CLOSE-1 */
        public void R0040_00_LE_V0RELATORIOS_DB_CLOSE_1()
        {
            /*" -835- EXEC SQL CLOSE V0RELAT END-EXEC */

            V0RELAT.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0040_99_SAIDA*/

        [StopWatch]
        /*" R0050-00-PROCESSA-SOLIC-SECTION */
        private void R0050_00_PROCESSA_SOLIC_SECTION()
        {
            /*" -848- MOVE 'R0050-00-PROCESSA-SOLIC' TO WPARAGRAFO */
            _.Move("R0050-00-PROCESSA-SOLIC", AREA_DE_WORK.WPARAGRAFO);

            /*" -850- MOVE '030' TO WNR-EXEC-SQL */
            _.Move("030", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -858- MOVE 'N' TO WFIMV0MOVDEBCC-CEF */
            _.Move("N", AREA_DE_WORK.WFIMV0MOVDEBCC_CEF);

            /*" -859- MOVE ZEROS TO V0RELAT-QUANTIDADE. */
            _.Move(0, V0RELAT_QUANTIDADE);

            /*" -861- MOVE '3' TO V0RELAT-SITUACAO. */
            _.Move("3", V0RELAT_SITUACAO);

            /*" -866- PERFORM R0070-00-PROCESSA-V0MOVDEBCC. */

            R0070_00_PROCESSA_V0MOVDEBCC_SECTION();

            /*" -866- PERFORM R0055-00-UPDATE-V0RELATORIOS. */

            R0055_00_UPDATE_V0RELATORIOS_SECTION();

            /*" -0- FLUXCONTROL_PERFORM R0050_10_LER */

            R0050_10_LER();

        }

        [StopWatch]
        /*" R0050-10-LER */
        private void R0050_10_LER(bool isPerform = false)
        {
            /*" -870- PERFORM R0040-00-LE-V0RELATORIOS. */

            R0040_00_LE_V0RELATORIOS_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0050_99_SAIDA*/

        [StopWatch]
        /*" R0055-00-UPDATE-V0RELATORIOS-SECTION */
        private void R0055_00_UPDATE_V0RELATORIOS_SECTION()
        {
            /*" -879- MOVE 'R0055-00-UPDATE-V0RELATORIOS ' TO WPARAGRAFO */
            _.Move("R0055-00-UPDATE-V0RELATORIOS ", AREA_DE_WORK.WPARAGRAFO);

            /*" -882- MOVE '055' TO WNR-EXEC-SQL */
            _.Move("055", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -890- PERFORM R0055_00_UPDATE_V0RELATORIOS_DB_UPDATE_1 */

            R0055_00_UPDATE_V0RELATORIOS_DB_UPDATE_1();

            /*" -893- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -894- DISPLAY 'BI6032B - ' WPARAGRAFO */
                _.Display($"BI6032B - {AREA_DE_WORK.WPARAGRAFO}");

                /*" -894- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0055-00-UPDATE-V0RELATORIOS-DB-UPDATE-1 */
        public void R0055_00_UPDATE_V0RELATORIOS_DB_UPDATE_1()
        {
            /*" -890- EXEC SQL UPDATE SEGUROS.V0RELATORIOS SET SITUACAO = :V0RELAT-SITUACAO, QUANTIDADE = :V0RELAT-QUANTIDADE WHERE CODRELAT = :V0RELAT-CODRELAT AND SITUACAO = '0' AND NRTIT = :V0RELAT-NRTIT AND NUM_APOLICE = :V0RELAT-NUM-APOLICE END-EXEC. */

            var r0055_00_UPDATE_V0RELATORIOS_DB_UPDATE_1_Update1 = new R0055_00_UPDATE_V0RELATORIOS_DB_UPDATE_1_Update1()
            {
                V0RELAT_QUANTIDADE = V0RELAT_QUANTIDADE.ToString(),
                V0RELAT_SITUACAO = V0RELAT_SITUACAO.ToString(),
                V0RELAT_NUM_APOLICE = V0RELAT_NUM_APOLICE.ToString(),
                V0RELAT_CODRELAT = V0RELAT_CODRELAT.ToString(),
                V0RELAT_NRTIT = V0RELAT_NRTIT.ToString(),
            };

            R0055_00_UPDATE_V0RELATORIOS_DB_UPDATE_1_Update1.Execute(r0055_00_UPDATE_V0RELATORIOS_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0055_99_SAIDA*/

        [StopWatch]
        /*" R0060-00-DECLARE-V0MOVDEBCC-SECTION */
        private void R0060_00_DECLARE_V0MOVDEBCC_SECTION()
        {
            /*" -903- MOVE 'R0060-00-DECLARE-V0MOVDEBCC' TO WPARAGRAFO */
            _.Move("R0060-00-DECLARE-V0MOVDEBCC", AREA_DE_WORK.WPARAGRAFO);

            /*" -905- MOVE '060' TO WNR-EXEC-SQL */
            _.Move("060", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -907- MOVE V0RELAT-NRTIT TO V0MOVDE-NUM-APOLICE */
            _.Move(V0RELAT_NRTIT, V0MOVDE_NUM_APOLICE);

            /*" -923- PERFORM R0060_00_DECLARE_V0MOVDEBCC_DB_DECLARE_1 */

            R0060_00_DECLARE_V0MOVDEBCC_DB_DECLARE_1();

            /*" -925- PERFORM R0060_00_DECLARE_V0MOVDEBCC_DB_OPEN_1 */

            R0060_00_DECLARE_V0MOVDEBCC_DB_OPEN_1();

            /*" -928- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -929- DISPLAY 'BI6032B - ' WPARAGRAFO */
                _.Display($"BI6032B - {AREA_DE_WORK.WPARAGRAFO}");

                /*" -930- DISPLAY 'PROBLEMAS OPEN V0MOVDEBCC_CEF ' */
                _.Display($"PROBLEMAS OPEN V0MOVDEBCC_CEF ");

                /*" -930- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0060-00-DECLARE-V0MOVDEBCC-DB-OPEN-1 */
        public void R0060_00_DECLARE_V0MOVDEBCC_DB_OPEN_1()
        {
            /*" -925- EXEC SQL OPEN V0MOVDE END-EXEC. */

            V0MOVDE.Open();

        }

        [StopWatch]
        /*" R0200-00-CARREGA-ORIGEM-DB-DECLARE-1 */
        public void R0200_00_CARREGA_ORIGEM_DB_DECLARE_1()
        {
            /*" -1710- EXEC SQL DECLARE CORIGEM CURSOR FOR SELECT SISTEMA_ORIGEM FROM SEGUROS.ARQUIVOS_SIVPF WHERE DATA_GERACAO = '9999-12-31' AND QTDE_REG_GER = 981 ORDER BY SISTEMA_ORIGEM END-EXEC. */
            CORIGEM = new BI6032B_CORIGEM(false);
            string GetQuery_CORIGEM()
            {
                var query = @$"SELECT SISTEMA_ORIGEM 
							FROM SEGUROS.ARQUIVOS_SIVPF 
							WHERE DATA_GERACAO = '9999-12-31' 
							AND QTDE_REG_GER = 981 
							ORDER BY SISTEMA_ORIGEM";

                return query;
            }
            CORIGEM.GetQueryEvent += GetQuery_CORIGEM;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0060_99_SAIDA*/

        [StopWatch]
        /*" R0065-00-LE-V0MOVDEBCC-CEF-SECTION */
        private void R0065_00_LE_V0MOVDEBCC_CEF_SECTION()
        {
            /*" -939- MOVE 'R0065-00-LE-V0MOVDEBCC-CEF' TO WPARAGRAFO */
            _.Move("R0065-00-LE-V0MOVDEBCC-CEF", AREA_DE_WORK.WPARAGRAFO);

            /*" -939- MOVE '065' TO WNR-EXEC-SQL. */
            _.Move("065", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -0- FLUXCONTROL_PERFORM R0065_10_LE_MOVDEBCC */

            R0065_10_LE_MOVDEBCC();

        }

        [StopWatch]
        /*" R0065-10-LE-MOVDEBCC */
        private void R0065_10_LE_MOVDEBCC(bool isPerform = false)
        {
            /*" -953- PERFORM R0065_10_LE_MOVDEBCC_DB_FETCH_1 */

            R0065_10_LE_MOVDEBCC_DB_FETCH_1();

            /*" -956- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -957- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -958- MOVE 'S' TO WFIMV0MOVDEBCC-CEF */
                    _.Move("S", AREA_DE_WORK.WFIMV0MOVDEBCC_CEF);

                    /*" -958- PERFORM R0065_10_LE_MOVDEBCC_DB_CLOSE_1 */

                    R0065_10_LE_MOVDEBCC_DB_CLOSE_1();

                    /*" -960- GO TO R0065-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0065_99_SAIDA*/ //GOTO
                    return;

                    /*" -961- ELSE */
                }
                else
                {


                    /*" -962- DISPLAY 'BI6032B - ' WPARAGRAFO */
                    _.Display($"BI6032B - {AREA_DE_WORK.WPARAGRAFO}");

                    /*" -964- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -965- IF V0MOVDE-VLR-DEBITO IS NEGATIVE */

            if (V0MOVDE_VLR_DEBITO < 0)
            {

                /*" -976- GO TO R0065-10-LE-MOVDEBCC. */
                new Task(() => R0065_10_LE_MOVDEBCC()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


            /*" -976- PERFORM R0065_10_LE_MOVDEBCC_DB_CLOSE_2 */

            R0065_10_LE_MOVDEBCC_DB_CLOSE_2();

        }

        [StopWatch]
        /*" R0065-10-LE-MOVDEBCC-DB-FETCH-1 */
        public void R0065_10_LE_MOVDEBCC_DB_FETCH_1()
        {
            /*" -953- EXEC SQL FETCH V0MOVDE INTO :V0MOVDE-COD-CONVENIO, :V0MOVDE-COD-AGENCIA-DEB, :V0MOVDE-OPER-CONTA-DEB, :V0MOVDE-NUM-CONTA-DEB, :V0MOVDE-DIG-CONTA-DEB, :V0MOVDE-DTVENCTO, :V0MOVDE-VLR-DEBITO, :V0MOVDE-NUM-APOLICE, :V0MOVDE-DIA-DEBITO END-EXEC. */

            if (V0MOVDE.Fetch())
            {
                _.Move(V0MOVDE.V0MOVDE_COD_CONVENIO, V0MOVDE_COD_CONVENIO);
                _.Move(V0MOVDE.V0MOVDE_COD_AGENCIA_DEB, V0MOVDE_COD_AGENCIA_DEB);
                _.Move(V0MOVDE.V0MOVDE_OPER_CONTA_DEB, V0MOVDE_OPER_CONTA_DEB);
                _.Move(V0MOVDE.V0MOVDE_NUM_CONTA_DEB, V0MOVDE_NUM_CONTA_DEB);
                _.Move(V0MOVDE.V0MOVDE_DIG_CONTA_DEB, V0MOVDE_DIG_CONTA_DEB);
                _.Move(V0MOVDE.V0MOVDE_DTVENCTO, V0MOVDE_DTVENCTO);
                _.Move(V0MOVDE.V0MOVDE_VLR_DEBITO, V0MOVDE_VLR_DEBITO);
                _.Move(V0MOVDE.V0MOVDE_NUM_APOLICE, V0MOVDE_NUM_APOLICE);
                _.Move(V0MOVDE.V0MOVDE_DIA_DEBITO, V0MOVDE_DIA_DEBITO);
            }

        }

        [StopWatch]
        /*" R0065-10-LE-MOVDEBCC-DB-CLOSE-1 */
        public void R0065_10_LE_MOVDEBCC_DB_CLOSE_1()
        {
            /*" -958- EXEC SQL CLOSE V0MOVDE END-EXEC */

            V0MOVDE.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0065_99_SAIDA*/

        [StopWatch]
        /*" R0065-10-LE-MOVDEBCC-DB-CLOSE-2 */
        public void R0065_10_LE_MOVDEBCC_DB_CLOSE_2()
        {
            /*" -976- EXEC SQL CLOSE V0MOVDE END-EXEC. */

            V0MOVDE.Close();

        }

        [StopWatch]
        /*" R0070-00-PROCESSA-V0MOVDEBCC-SECTION */
        private void R0070_00_PROCESSA_V0MOVDEBCC_SECTION()
        {
            /*" -986- MOVE 'R0070-00-PROCESSA-V0MOVDEBCC' TO WPARAGRAFO */
            _.Move("R0070-00-PROCESSA-V0MOVDEBCC", AREA_DE_WORK.WPARAGRAFO);

            /*" -993- MOVE '070' TO WNR-EXEC-SQL. */
            _.Move("070", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -995- PERFORM R0077-00-LE-V0RCAP. */

            R0077_00_LE_V0RCAP_SECTION();

            /*" -996- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -997- PERFORM R0078-00-LE-MOVIMCOB */

                R0078_00_LE_MOVIMCOB_SECTION();

                /*" -998- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -999- GO TO R0070-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0070_99_SAIDA*/ //GOTO
                    return;

                    /*" -1000- END-IF */
                }


                /*" -1001- ELSE */
            }
            else
            {


                /*" -1003- IF V0RCAP-OPERACAO EQUAL 210 OR 400 */

                if (V0RCAP_OPERACAO.In("210", "400"))
                {

                    /*" -1009- GO TO R0070-99-SAIDA. */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0070_99_SAIDA*/ //GOTO
                    return;
                }

            }


            /*" -1011- PERFORM R0075-00-LE-V0BILHETE. */

            R0075_00_LE_V0BILHETE_SECTION();

            /*" -1012- PERFORM R0076-00-LE-PROPOFID. */

            R0076_00_LE_PROPOFID_SECTION();

            /*" -1014- PERFORM R1010-00-VERIFICA-ORIGEM */

            R1010_00_VERIFICA_ORIGEM_SECTION();

            /*" -1018- MOVE ZEROS TO WS-ENDOSSO. */
            _.Move(0, AREA_DE_WORK.WS_ENDOSSO);

            /*" -1019- IF WTEM-SISTEMA-ORIGEM EQUAL 'SIM' */

            if (AREA_DE_WORK.WTEM_SISTEMA_ORIGEM == "SIM")
            {

                /*" -1020- PERFORM R0091-00-MAX-ENDOSSO */

                R0091_00_MAX_ENDOSSO_SECTION();

                /*" -1021- ELSE */
            }
            else
            {


                /*" -1022- PERFORM R0090-00-MAX-PARCELA */

                R0090_00_MAX_PARCELA_SECTION();

                /*" -1023- END-IF. */
            }


            /*" -1024- IF WS-MAX-PARCEL EQUAL 'N' */

            if (AREA_DE_WORK.WS_MAX_PARCEL == "N")
            {

                /*" -1025- GO TO R0070-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0070_99_SAIDA*/ //GOTO
                return;

                /*" -1027- END-IF. */
            }


            /*" -1028- IF WS-BILHETE EQUAL 'S' */

            if (AREA_DE_WORK.WS_BILHETE == "S")
            {

                /*" -1029- COMPUTE WTOTMOVCR = WTOTMOVCR + 1 */
                AREA_DE_WORK.WTOTMOVCR.Value = AREA_DE_WORK.WTOTMOVCR + 1;

                /*" -1030- COMPUTE WTOTREG = WTOTREG + 1 */
                AREA_DE_WORK.WTOTREG.Value = AREA_DE_WORK.WTOTREG + 1;

                /*" -1031- COMPUTE WTOTCRE = WTOTCRE + WS-VLPREMIO */
                AREA_DE_WORK.WTOTCRE.Value = AREA_DE_WORK.WTOTCRE + AREA_DE_WORK.WS_VLPREMIO;

                /*" -1032- ELSE */
            }
            else
            {


                /*" -1043- GO TO R0070-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0070_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1044- IF WTOTMOVCR EQUAL 1 */

            if (AREA_DE_WORK.WTOTMOVCR == 1)
            {

                /*" -1047- PERFORM R0080-00-REGISTRO-HEADER. */

                R0080_00_REGISTRO_HEADER_SECTION();
            }


            /*" -1048- PERFORM R0120-00-REGISTRO-E */

            R0120_00_REGISTRO_E_SECTION();

            /*" -1049- PERFORM R0125-00-RELATORIO */

            R0125_00_RELATORIO_SECTION();

            /*" -1055- PERFORM R0145-00-INSERT-V0MOVDEBCC-CEF. */

            R0145_00_INSERT_V0MOVDEBCC_CEF_SECTION();

            /*" -1056- MOVE V0PARAMC-NSAS TO V0RELAT-QUANTIDADE. */
            _.Move(V0PARAMC_NSAS, V0RELAT_QUANTIDADE);

            /*" -1056- MOVE '1' TO V0RELAT-SITUACAO. */
            _.Move("1", V0RELAT_SITUACAO);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0070_99_SAIDA*/

        [StopWatch]
        /*" R0075-00-LE-V0BILHETE-SECTION */
        private void R0075_00_LE_V0BILHETE_SECTION()
        {
            /*" -1070- MOVE 'R0075-00-LE-V0BILHETE' TO WPARAGRAFO */
            _.Move("R0075-00-LE-V0BILHETE", AREA_DE_WORK.WPARAGRAFO);

            /*" -1071- MOVE '075' TO WNR-EXEC-SQL. */
            _.Move("075", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1073- MOVE 'S' TO WS-BILHETE. */
            _.Move("S", AREA_DE_WORK.WS_BILHETE);

            /*" -1075- MOVE V0RELAT-NRTIT TO V1BILH-NUMBIL */
            _.Move(V0RELAT_NRTIT, V1BILH_NUMBIL);

            /*" -1096- PERFORM R0075_00_LE_V0BILHETE_DB_SELECT_1 */

            R0075_00_LE_V0BILHETE_DB_SELECT_1();

            /*" -1099- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1100- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1101- MOVE 'N' TO WS-BILHETE */
                    _.Move("N", AREA_DE_WORK.WS_BILHETE);

                    /*" -1102- ELSE */
                }
                else
                {


                    /*" -1103- DISPLAY 'BI6032B - ' WPARAGRAFO */
                    _.Display($"BI6032B - {AREA_DE_WORK.WPARAGRAFO}");

                    /*" -1104- DISPLAY 'V1BILH-NUMBIL ' V1BILH-NUMBIL */
                    _.Display($"V1BILH-NUMBIL {V1BILH_NUMBIL}");

                    /*" -1104- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R0075-00-LE-V0BILHETE-DB-SELECT-1 */
        public void R0075_00_LE_V0BILHETE_DB_SELECT_1()
        {
            /*" -1096- EXEC SQL SELECT NUMBIL, CODCLIEN, NUM_MATRICULA, NUM_APOLICE, COD_AGENCIA_DEB, OPERACAO_CONTA_DEB, NUM_CONTA_DEB, DIG_CONTA_DEB INTO :V1BILH-NUMBIL, :V1BILH-COD-CLIENTE, :V1BILH-MATR-IND, :V1BILH-NUM-APOL, :V1BILH-AGENCIA-DEB, :V1BILH-OPERACAO-DEB, :V1BILH-CONTA-DEB, :V1BILH-DIGITO-DEB FROM SEGUROS.V0BILHETE WHERE NUMBIL = :V1BILH-NUMBIL AND SITUACAO IN ( '8' , '9' ) END-EXEC. */

            var r0075_00_LE_V0BILHETE_DB_SELECT_1_Query1 = new R0075_00_LE_V0BILHETE_DB_SELECT_1_Query1()
            {
                V1BILH_NUMBIL = V1BILH_NUMBIL.ToString(),
            };

            var executed_1 = R0075_00_LE_V0BILHETE_DB_SELECT_1_Query1.Execute(r0075_00_LE_V0BILHETE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1BILH_NUMBIL, V1BILH_NUMBIL);
                _.Move(executed_1.V1BILH_COD_CLIENTE, V1BILH_COD_CLIENTE);
                _.Move(executed_1.V1BILH_MATR_IND, V1BILH_MATR_IND);
                _.Move(executed_1.V1BILH_NUM_APOL, V1BILH_NUM_APOL);
                _.Move(executed_1.V1BILH_AGENCIA_DEB, V1BILH_AGENCIA_DEB);
                _.Move(executed_1.V1BILH_OPERACAO_DEB, V1BILH_OPERACAO_DEB);
                _.Move(executed_1.V1BILH_CONTA_DEB, V1BILH_CONTA_DEB);
                _.Move(executed_1.V1BILH_DIGITO_DEB, V1BILH_DIGITO_DEB);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0075_99_SAIDA*/

        [StopWatch]
        /*" R0076-00-LE-PROPOFID-SECTION */
        private void R0076_00_LE_PROPOFID_SECTION()
        {
            /*" -1114- MOVE 'R0076-00-LE-PROPOFID' TO WPARAGRAFO */
            _.Move("R0076-00-LE-PROPOFID", AREA_DE_WORK.WPARAGRAFO);

            /*" -1116- MOVE '076' TO WNR-EXEC-SQL. */
            _.Move("076", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1118- MOVE V0RELAT-NRTIT TO PROPOFID-NUM-PROPOSTA-SIVPF. */
            _.Move(V0RELAT_NRTIT, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF);

            /*" -1123- PERFORM R0076_00_LE_PROPOFID_DB_SELECT_1 */

            R0076_00_LE_PROPOFID_DB_SELECT_1();

            /*" -1126- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1127- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1128- MOVE V0RELAT-NRTIT TO PROPOFID-NUM-SICOB */
                    _.Move(V0RELAT_NRTIT, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_SICOB);

                    /*" -1133- PERFORM R0076_00_LE_PROPOFID_DB_SELECT_2 */

                    R0076_00_LE_PROPOFID_DB_SELECT_2();

                    /*" -1135- IF SQLCODE NOT EQUAL ZEROS */

                    if (DB.SQLCODE != 00)
                    {

                        /*" -1136- IF SQLCODE EQUAL 100 */

                        if (DB.SQLCODE == 100)
                        {

                            /*" -1137- MOVE ZEROS TO PROPOFID-ORIGEM-PROPOSTA */
                            _.Move(0, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_ORIGEM_PROPOSTA);

                            /*" -1138- ELSE */
                        }
                        else
                        {


                            /*" -1139- DISPLAY 'BI6032B - ' WPARAGRAFO */
                            _.Display($"BI6032B - {AREA_DE_WORK.WPARAGRAFO}");

                            /*" -1140- DISPLAY 'V1BILH-NUMBIL ' V1BILH-NUMBIL */
                            _.Display($"V1BILH-NUMBIL {V1BILH_NUMBIL}");

                            /*" -1141- GO TO R9999-00-ROT-ERRO */

                            R9999_00_ROT_ERRO_SECTION(); //GOTO
                            return;

                            /*" -1142- END-IF */
                        }


                        /*" -1143- END-IF */
                    }


                    /*" -1144- ELSE */
                }
                else
                {


                    /*" -1145- DISPLAY 'BI6032B - ' WPARAGRAFO */
                    _.Display($"BI6032B - {AREA_DE_WORK.WPARAGRAFO}");

                    /*" -1146- DISPLAY 'V1BILH-NUMBIL ' V1BILH-NUMBIL */
                    _.Display($"V1BILH-NUMBIL {V1BILH_NUMBIL}");

                    /*" -1147- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1148- END-IF */
                }


                /*" -1149- END-IF. */
            }


        }

        [StopWatch]
        /*" R0076-00-LE-PROPOFID-DB-SELECT-1 */
        public void R0076_00_LE_PROPOFID_DB_SELECT_1()
        {
            /*" -1123- EXEC SQL SELECT ORIGEM_PROPOSTA INTO :PROPOFID-ORIGEM-PROPOSTA FROM SEGUROS.PROPOSTA_FIDELIZ WHERE NUM_PROPOSTA_SIVPF = :PROPOFID-NUM-PROPOSTA-SIVPF END-EXEC. */

            var r0076_00_LE_PROPOFID_DB_SELECT_1_Query1 = new R0076_00_LE_PROPOFID_DB_SELECT_1_Query1()
            {
                PROPOFID_NUM_PROPOSTA_SIVPF = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF.ToString(),
            };

            var executed_1 = R0076_00_LE_PROPOFID_DB_SELECT_1_Query1.Execute(r0076_00_LE_PROPOFID_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PROPOFID_ORIGEM_PROPOSTA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_ORIGEM_PROPOSTA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0076_99_SAIDA*/

        [StopWatch]
        /*" R0076-00-LE-PROPOFID-DB-SELECT-2 */
        public void R0076_00_LE_PROPOFID_DB_SELECT_2()
        {
            /*" -1133- EXEC SQL SELECT ORIGEM_PROPOSTA INTO :PROPOFID-ORIGEM-PROPOSTA FROM SEGUROS.PROPOSTA_FIDELIZ WHERE NUM_SICOB = :PROPOFID-NUM-SICOB END-EXEC */

            var r0076_00_LE_PROPOFID_DB_SELECT_2_Query1 = new R0076_00_LE_PROPOFID_DB_SELECT_2_Query1()
            {
                PROPOFID_NUM_SICOB = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_SICOB.ToString(),
            };

            var executed_1 = R0076_00_LE_PROPOFID_DB_SELECT_2_Query1.Execute(r0076_00_LE_PROPOFID_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PROPOFID_ORIGEM_PROPOSTA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_ORIGEM_PROPOSTA);
            }


        }

        [StopWatch]
        /*" R0077-00-LE-V0RCAP-SECTION */
        private void R0077_00_LE_V0RCAP_SECTION()
        {
            /*" -1158- MOVE 'R0077-00-LE-V0RCAP   ' TO WPARAGRAFO */
            _.Move("R0077-00-LE-V0RCAP   ", AREA_DE_WORK.WPARAGRAFO);

            /*" -1160- MOVE '077' TO WNR-EXEC-SQL. */
            _.Move("077", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1162- MOVE V0RELAT-NRTIT TO V0RCAP-NRTIT. */
            _.Move(V0RELAT_NRTIT, V0RCAP_NRTIT);

            /*" -1167- PERFORM R0077_00_LE_V0RCAP_DB_SELECT_1 */

            R0077_00_LE_V0RCAP_DB_SELECT_1();

        }

        [StopWatch]
        /*" R0077-00-LE-V0RCAP-DB-SELECT-1 */
        public void R0077_00_LE_V0RCAP_DB_SELECT_1()
        {
            /*" -1167- EXEC SQL SELECT OPERACAO INTO :V0RCAP-OPERACAO FROM SEGUROS.V0RCAP WHERE NRTIT = :V0RCAP-NRTIT END-EXEC. */

            var r0077_00_LE_V0RCAP_DB_SELECT_1_Query1 = new R0077_00_LE_V0RCAP_DB_SELECT_1_Query1()
            {
                V0RCAP_NRTIT = V0RCAP_NRTIT.ToString(),
            };

            var executed_1 = R0077_00_LE_V0RCAP_DB_SELECT_1_Query1.Execute(r0077_00_LE_V0RCAP_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0RCAP_OPERACAO, V0RCAP_OPERACAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0077_99_SAIDA*/

        [StopWatch]
        /*" R0078-00-LE-MOVIMCOB-SECTION */
        private void R0078_00_LE_MOVIMCOB_SECTION()
        {
            /*" -1178- MOVE 'R0077-00-LE-MOVIMCOB ' TO WPARAGRAFO */
            _.Move("R0077-00-LE-MOVIMCOB ", AREA_DE_WORK.WPARAGRAFO);

            /*" -1180- MOVE '078' TO WNR-EXEC-SQL. */
            _.Move("078", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1182- MOVE V0RELAT-NRTIT TO MOVIMCOB-NUM-TITULO */
            _.Move(V0RELAT_NRTIT, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_TITULO);

            /*" -1187- PERFORM R0078_00_LE_MOVIMCOB_DB_SELECT_1 */

            R0078_00_LE_MOVIMCOB_DB_SELECT_1();

        }

        [StopWatch]
        /*" R0078-00-LE-MOVIMCOB-DB-SELECT-1 */
        public void R0078_00_LE_MOVIMCOB_DB_SELECT_1()
        {
            /*" -1187- EXEC SQL SELECT NUM_TITULO INTO :MOVIMCOB-NUM-TITULO FROM SEGUROS.MOVIMENTO_COBRANCA WHERE NUM_TITULO = :MOVIMCOB-NUM-TITULO END-EXEC. */

            var r0078_00_LE_MOVIMCOB_DB_SELECT_1_Query1 = new R0078_00_LE_MOVIMCOB_DB_SELECT_1_Query1()
            {
                MOVIMCOB_NUM_TITULO = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_TITULO.ToString(),
            };

            var executed_1 = R0078_00_LE_MOVIMCOB_DB_SELECT_1_Query1.Execute(r0078_00_LE_MOVIMCOB_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.MOVIMCOB_NUM_TITULO, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_TITULO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0078_99_SAIDA*/

        [StopWatch]
        /*" R0080-00-REGISTRO-HEADER-SECTION */
        private void R0080_00_REGISTRO_HEADER_SECTION()
        {
            /*" -1197- MOVE 'R0080-00-REGISTRO-HEADER' TO WPARAGRAFO */
            _.Move("R0080-00-REGISTRO-HEADER", AREA_DE_WORK.WPARAGRAFO);

            /*" -1199- MOVE '080' TO WNR-EXEC-SQL. */
            _.Move("080", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1200- MOVE ALL SPACES TO HEADER-REGISTRO */
            _.MoveAll("", HEADER_REGISTRO);

            /*" -1201- MOVE 'A' TO HEADER-CODREGISTRO */
            _.Move("A", HEADER_REGISTRO.HEADER_CODREGISTRO);

            /*" -1209- MOVE 1 TO HEADER-CODREMESSA */
            _.Move(1, HEADER_REGISTRO.HEADER_CODREMESSA);

            /*" -1210- MOVE 600114 TO HEADER-CODCONVENIO */
            _.Move(600114, HEADER_REGISTRO.HEADER_CODCONVENIO);

            /*" -1211- MOVE 'CAIXA SEGURO FACIL' TO HEADER-NOMEMPRESA */
            _.Move("CAIXA SEGURO FACIL", HEADER_REGISTRO.HEADER_NOMEMPRESA);

            /*" -1212- MOVE 104 TO HEADER-CODBANCO */
            _.Move(104, HEADER_REGISTRO.HEADER_CODBANCO);

            /*" -1213- MOVE 'CEF' TO HEADER-NOMBANCO */
            _.Move("CEF", HEADER_REGISTRO.HEADER_NOMBANCO);

            /*" -1214- MOVE V1SISTE-DTCURRENT TO WDATA-SQL */
            _.Move(V1SISTE_DTCURRENT, AREA_DE_WORK.WDATA_SQL);

            /*" -1215- MOVE WANO-SQL TO WANO-TRA */
            _.Move(AREA_DE_WORK.FILLER_11.WANO_SQL, AREA_DE_WORK.FILLER_14.WANO_TRA);

            /*" -1216- MOVE WMES-SQL TO WMES-TRA */
            _.Move(AREA_DE_WORK.FILLER_11.WMES_SQL, AREA_DE_WORK.FILLER_14.WMES_TRA);

            /*" -1217- MOVE WDIA-SQL TO WDIA-TRA */
            _.Move(AREA_DE_WORK.FILLER_11.WDIA_SQL, AREA_DE_WORK.FILLER_14.WDIA_TRA);

            /*" -1219- MOVE WDATATRA TO HEADER-DATGERACAO */
            _.Move(AREA_DE_WORK.WDATATRA, HEADER_REGISTRO.HEADER_DATGERACAO);

            /*" -1220- IF WTOTMOVCR NOT EQUAL ZEROS */

            if (AREA_DE_WORK.WTOTMOVCR != 00)
            {

                /*" -1222- ADD 1 TO V0PARAMC-NSAS. */
                V0PARAMC_NSAS.Value = V0PARAMC_NSAS + 1;
            }


            /*" -1224- MOVE V0PARAMC-NSAS TO HEADER-NSA WNSAS */
            _.Move(V0PARAMC_NSAS, HEADER_REGISTRO.HEADER_NSA, AREA_DE_WORK.WNSAS);

            /*" -1225- MOVE 04 TO HEADER-VERSAO */
            _.Move(04, HEADER_REGISTRO.HEADER_VERSAO);

            /*" -1226- MOVE 'DEB/CRED AUTOMAT' TO HEADER-DEBITOAUT */
            _.Move("DEB/CRED AUTOMAT", HEADER_REGISTRO.HEADER_DEBITOAUT);

            /*" -1227- MOVE ALL SPACES TO HEADER-FILLER */
            _.MoveAll("", HEADER_REGISTRO.HEADER_FILLER);

            /*" -1229- MOVE 'BI6032B' TO HEADER-NOMPROGRAMA */
            _.Move("BI6032B", HEADER_REGISTRO.HEADER_NOMPROGRAMA);

            /*" -1229- WRITE HEADER-REGISTRO. */
            MOVCREDITO_CC.Write(HEADER_REGISTRO.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0080_99_SAIDA*/

        [StopWatch]
        /*" R0085-00-REGISTRO-TRAILLER-SECTION */
        private void R0085_00_REGISTRO_TRAILLER_SECTION()
        {
            /*" -1238- MOVE 'R0085-00-REGISTRO-TRAILLER' TO WPARAGRAFO */
            _.Move("R0085-00-REGISTRO-TRAILLER", AREA_DE_WORK.WPARAGRAFO);

            /*" -1240- MOVE '085' TO WNR-EXEC-SQL. */
            _.Move("085", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1241- MOVE ALL SPACES TO TRAILL-REGISTRO */
            _.MoveAll("", TRAILL_REGISTRO);

            /*" -1242- MOVE 'Z' TO TRAILL-CODREGISTRO */
            _.Move("Z", TRAILL_REGISTRO.TRAILL_CODREGISTRO);

            /*" -1243- COMPUTE WTOTREG = WTOTREG + 2 */
            AREA_DE_WORK.WTOTREG.Value = AREA_DE_WORK.WTOTREG + 2;

            /*" -1244- MOVE WTOTREG TO TRAILL-TOTREGISTRO */
            _.Move(AREA_DE_WORK.WTOTREG, TRAILL_REGISTRO.TRAILL_TOTREGISTRO);

            /*" -1245- MOVE ZEROS TO TRAILL-VLRTOTDEB */
            _.Move(0, TRAILL_REGISTRO.TRAILL_VLRTOTDEB);

            /*" -1246- MOVE WTOTCRE TO TRAILL-VLRTOTCRE */
            _.Move(AREA_DE_WORK.WTOTCRE, TRAILL_REGISTRO.TRAILL_VLRTOTCRE);

            /*" -1248- MOVE ALL SPACES TO TRAILL-FILLER */
            _.MoveAll("", TRAILL_REGISTRO.TRAILL_FILLER);

            /*" -1248- WRITE TRAILL-REGISTRO. */
            MOVCREDITO_CC.Write(TRAILL_REGISTRO.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0085_99_SAIDA*/

        [StopWatch]
        /*" R0090-00-MAX-PARCELA-SECTION */
        private void R0090_00_MAX_PARCELA_SECTION()
        {
            /*" -1258- MOVE '0090' TO WNR-EXEC-SQL. */
            _.Move("0090", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1260- MOVE 'S' TO WS-MAX-PARCEL. */
            _.Move("S", AREA_DE_WORK.WS_MAX_PARCEL);

            /*" -1272- PERFORM R0090_00_MAX_PARCELA_DB_SELECT_1 */

            R0090_00_MAX_PARCELA_DB_SELECT_1();

            /*" -1275- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1276- MOVE 'N' TO WS-MAX-PARCEL */
                _.Move("N", AREA_DE_WORK.WS_MAX_PARCEL);

                /*" -1277- DISPLAY 'APOLICE  ' V1BILH-NUM-APOL */
                _.Display($"APOLICE  {V1BILH_NUM_APOL}");

                /*" -1278- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, AREA_DE_WORK.WABEND.WSQLCODE);

                /*" -1279- DISPLAY 'SQLCODE  ' WABEND */
                _.Display($"SQLCODE  {AREA_DE_WORK.WABEND}");

                /*" -1281- GO TO R0090-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0090_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1282- IF WS-NULL-PARCEL < 0 */

            if (AREA_DE_WORK.WS_NULL_PARCEL < 0)
            {

                /*" -1283- MOVE 0 TO WS-PARCELA */
                _.Move(0, AREA_DE_WORK.WS_PARCELA);

                /*" -1284- MOVE 'N' TO WS-MAX-PARCEL */
                _.Move("N", AREA_DE_WORK.WS_MAX_PARCEL);

                /*" -1285- GO TO R0090-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0090_99_SAIDA*/ //GOTO
                return;

                /*" -1287- END-IF. */
            }


            /*" -1289- MOVE ZEROS TO WS-VLPREMIO. */
            _.Move(0, AREA_DE_WORK.WS_VLPREMIO);

            /*" -1296- PERFORM R0090_00_MAX_PARCELA_DB_SELECT_2 */

            R0090_00_MAX_PARCELA_DB_SELECT_2();

            /*" -1299- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1300- MOVE 'N' TO WS-MAX-PARCEL */
                _.Move("N", AREA_DE_WORK.WS_MAX_PARCEL);

                /*" -1301- DISPLAY 'APOLICE  ' V1BILH-NUM-APOL */
                _.Display($"APOLICE  {V1BILH_NUM_APOL}");

                /*" -1302- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, AREA_DE_WORK.WABEND.WSQLCODE);

                /*" -1303- DISPLAY 'SQLCODE  ' WABEND */
                _.Display($"SQLCODE  {AREA_DE_WORK.WABEND}");

                /*" -1303- GO TO R0090-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0090_99_SAIDA*/ //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0090-00-MAX-PARCELA-DB-SELECT-1 */
        public void R0090_00_MAX_PARCELA_DB_SELECT_1()
        {
            /*" -1272- EXEC SQL SELECT MAX(B.NRPARCEL) INTO :WS-PARCELA:WS-NULL-PARCEL FROM SEGUROS.V0PARCELA A, SEGUROS.V0HISTOPARC B WHERE A.NUM_APOLICE = :V1BILH-NUM-APOL AND A.NRENDOS = 0 AND B.NUM_APOLICE = A.NUM_APOLICE AND B.NRENDOS = A.NRENDOS AND B.NRPARCEL = A.NRPARCEL AND B.OCORHIST = A.OCORHIST AND B.OPERACAO BETWEEN 200 AND 299 END-EXEC. */

            var r0090_00_MAX_PARCELA_DB_SELECT_1_Query1 = new R0090_00_MAX_PARCELA_DB_SELECT_1_Query1()
            {
                V1BILH_NUM_APOL = V1BILH_NUM_APOL.ToString(),
            };

            var executed_1 = R0090_00_MAX_PARCELA_DB_SELECT_1_Query1.Execute(r0090_00_MAX_PARCELA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_PARCELA, AREA_DE_WORK.WS_PARCELA);
                _.Move(executed_1.WS_NULL_PARCEL, AREA_DE_WORK.WS_NULL_PARCEL);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0090_99_SAIDA*/

        [StopWatch]
        /*" R0090-00-MAX-PARCELA-DB-SELECT-2 */
        public void R0090_00_MAX_PARCELA_DB_SELECT_2()
        {
            /*" -1296- EXEC SQL SELECT VLPREMIO INTO :WS-VLPREMIO FROM SEGUROS.V0HISTOPARC WHERE NUM_APOLICE = :V1BILH-NUM-APOL AND NRENDOS = 0 AND NRPARCEL = :WS-PARCELA AND OPERACAO BETWEEN 200 AND 299 END-EXEC. */

            var r0090_00_MAX_PARCELA_DB_SELECT_2_Query1 = new R0090_00_MAX_PARCELA_DB_SELECT_2_Query1()
            {
                V1BILH_NUM_APOL = V1BILH_NUM_APOL.ToString(),
                WS_PARCELA = AREA_DE_WORK.WS_PARCELA.ToString(),
            };

            var executed_1 = R0090_00_MAX_PARCELA_DB_SELECT_2_Query1.Execute(r0090_00_MAX_PARCELA_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_VLPREMIO, AREA_DE_WORK.WS_VLPREMIO);
            }


        }

        [StopWatch]
        /*" R0091-00-MAX-ENDOSSO-SECTION */
        private void R0091_00_MAX_ENDOSSO_SECTION()
        {
            /*" -1314- MOVE '0091' TO WNR-EXEC-SQL. */
            _.Move("0091", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1316- MOVE 'S' TO WS-MAX-PARCEL. */
            _.Move("S", AREA_DE_WORK.WS_MAX_PARCEL);

            /*" -1330- PERFORM R0091_00_MAX_ENDOSSO_DB_SELECT_1 */

            R0091_00_MAX_ENDOSSO_DB_SELECT_1();

            /*" -1333- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1334- MOVE 'N' TO WS-MAX-PARCEL */
                _.Move("N", AREA_DE_WORK.WS_MAX_PARCEL);

                /*" -1335- DISPLAY 'APOLICE  ' V1BILH-NUM-APOL */
                _.Display($"APOLICE  {V1BILH_NUM_APOL}");

                /*" -1336- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, AREA_DE_WORK.WABEND.WSQLCODE);

                /*" -1337- DISPLAY 'SQLCODE  ' WABEND */
                _.Display($"SQLCODE  {AREA_DE_WORK.WABEND}");

                /*" -1339- GO TO R0091-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0091_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1340- IF WS-NULL-ENDOSSO < 0 */

            if (AREA_DE_WORK.WS_NULL_ENDOSSO < 0)
            {

                /*" -1341- MOVE 0 TO WS-ENDOSSO */
                _.Move(0, AREA_DE_WORK.WS_ENDOSSO);

                /*" -1342- MOVE 'N' TO WS-MAX-PARCEL */
                _.Move("N", AREA_DE_WORK.WS_MAX_PARCEL);

                /*" -1343- GO TO R0091-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0091_99_SAIDA*/ //GOTO
                return;

                /*" -1345- END-IF. */
            }


            /*" -1347- MOVE ZEROS TO WS-VLPREMIO. */
            _.Move(0, AREA_DE_WORK.WS_VLPREMIO);

            /*" -1354- PERFORM R0091_00_MAX_ENDOSSO_DB_SELECT_2 */

            R0091_00_MAX_ENDOSSO_DB_SELECT_2();

            /*" -1357- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1358- MOVE 'N' TO WS-MAX-PARCEL */
                _.Move("N", AREA_DE_WORK.WS_MAX_PARCEL);

                /*" -1359- DISPLAY 'APOLICE  ' V1BILH-NUM-APOL */
                _.Display($"APOLICE  {V1BILH_NUM_APOL}");

                /*" -1360- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, AREA_DE_WORK.WABEND.WSQLCODE);

                /*" -1361- DISPLAY 'SQLCODE  ' WABEND */
                _.Display($"SQLCODE  {AREA_DE_WORK.WABEND}");

                /*" -1361- GO TO R0091-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0091_99_SAIDA*/ //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0091-00-MAX-ENDOSSO-DB-SELECT-1 */
        public void R0091_00_MAX_ENDOSSO_DB_SELECT_1()
        {
            /*" -1330- EXEC SQL SELECT MAX(B.NRENDOS) INTO :WS-ENDOSSO:WS-NULL-ENDOSSO FROM SEGUROS.V0PARCELA A, SEGUROS.V0HISTOPARC B, SEGUROS.ENDOSSOS C WHERE A.NUM_APOLICE = :V1BILH-NUM-APOL AND B.NUM_APOLICE = A.NUM_APOLICE AND B.NRENDOS = A.NRENDOS AND B.NRPARCEL = A.NRPARCEL AND B.OCORHIST = A.OCORHIST AND B.OPERACAO BETWEEN 200 AND 299 AND B.NUM_APOLICE = C.NUM_APOLICE AND B.NRENDOS = C.NUM_ENDOSSO END-EXEC. */

            var r0091_00_MAX_ENDOSSO_DB_SELECT_1_Query1 = new R0091_00_MAX_ENDOSSO_DB_SELECT_1_Query1()
            {
                V1BILH_NUM_APOL = V1BILH_NUM_APOL.ToString(),
            };

            var executed_1 = R0091_00_MAX_ENDOSSO_DB_SELECT_1_Query1.Execute(r0091_00_MAX_ENDOSSO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_ENDOSSO, AREA_DE_WORK.WS_ENDOSSO);
                _.Move(executed_1.WS_NULL_ENDOSSO, AREA_DE_WORK.WS_NULL_ENDOSSO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0091_99_SAIDA*/

        [StopWatch]
        /*" R0091-00-MAX-ENDOSSO-DB-SELECT-2 */
        public void R0091_00_MAX_ENDOSSO_DB_SELECT_2()
        {
            /*" -1354- EXEC SQL SELECT VLPREMIO INTO :WS-VLPREMIO FROM SEGUROS.V0HISTOPARC WHERE NUM_APOLICE = :V1BILH-NUM-APOL AND NRENDOS = :WS-ENDOSSO AND NRPARCEL = 0 AND OPERACAO BETWEEN 200 AND 299 END-EXEC. */

            var r0091_00_MAX_ENDOSSO_DB_SELECT_2_Query1 = new R0091_00_MAX_ENDOSSO_DB_SELECT_2_Query1()
            {
                V1BILH_NUM_APOL = V1BILH_NUM_APOL.ToString(),
                WS_ENDOSSO = AREA_DE_WORK.WS_ENDOSSO.ToString(),
            };

            var executed_1 = R0091_00_MAX_ENDOSSO_DB_SELECT_2_Query1.Execute(r0091_00_MAX_ENDOSSO_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_VLPREMIO, AREA_DE_WORK.WS_VLPREMIO);
            }


        }

        [StopWatch]
        /*" R0120-00-REGISTRO-E-SECTION */
        private void R0120_00_REGISTRO_E_SECTION()
        {
            /*" -1370- MOVE 'R0120-00-REGISTRO-E ' TO WPARAGRAFO */
            _.Move("R0120-00-REGISTRO-E ", AREA_DE_WORK.WPARAGRAFO);

            /*" -1372- MOVE '120' TO WNR-EXEC-SQL. */
            _.Move("120", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1373- MOVE ALL SPACES TO MOVCC-REGISTRO */
            _.MoveAll("", MOVCC_REGISTRO);

            /*" -1375- MOVE 'E' TO MOVCC-CODREGISTRO */
            _.Move("E", MOVCC_REGISTRO.MOVCC_CODREGISTRO);

            /*" -1378- MOVE V1BILH-NUM-APOL TO WNUM-APOL */
            _.Move(V1BILH_NUM_APOL, AREA_DE_WORK.FILLER_1.WNUM_APOL);

            /*" -1379- MOVE WS-PARCELA TO WNRPARCEL */
            _.Move(AREA_DE_WORK.WS_PARCELA, AREA_DE_WORK.FILLER_1.WNRPARCEL);

            /*" -1381- MOVE WS-ENDOSSO TO WNRENDOS */
            _.Move(AREA_DE_WORK.WS_ENDOSSO, AREA_DE_WORK.FILLER_1.WNRENDOS);

            /*" -1382- MOVE ALL SPACES TO WEMP-SPACES */
            _.MoveAll("", AREA_DE_WORK.FILLER_1.WEMP_SPACES);

            /*" -1384- MOVE WIDTCLIEMP TO MOVCC-IDTCLIEMP */
            _.Move(AREA_DE_WORK.WIDTCLIEMP, MOVCC_REGISTRO.MOVCC_IDTCLIEMP);

            /*" -1386- MOVE V1BILH-AGENCIA-DEB TO MOVCC-AGECREDITO */
            _.Move(V1BILH_AGENCIA_DEB, MOVCC_REGISTRO.MOVCC_AGECREDITO);

            /*" -1387- MOVE V1BILH-OPERACAO-DEB TO WOPER-CONTA */
            _.Move(V1BILH_OPERACAO_DEB, AREA_DE_WORK.FILLER_0.WOPER_CONTA);

            /*" -1388- MOVE V1BILH-CONTA-DEB TO WNUM-CONTA */
            _.Move(V1BILH_CONTA_DEB, AREA_DE_WORK.FILLER_0.WNUM_CONTA);

            /*" -1396- MOVE V1BILH-DIGITO-DEB TO WDIG-CONTA */
            _.Move(V1BILH_DIGITO_DEB, AREA_DE_WORK.FILLER_0.WDIG_CONTA);

            /*" -1397- MOVE ALL SPACES TO WIDT-SPACES */
            _.MoveAll("", AREA_DE_WORK.FILLER_0.WIDT_SPACES);

            /*" -1399- MOVE WIDTCLIBAN TO MOVCC-IDTCLIBAN */
            _.Move(AREA_DE_WORK.WIDTCLIBAN, MOVCC_REGISTRO.MOVCC_IDTCLIBAN);

            /*" -1400- MOVE V1SISTE-DTMOVABE TO WDATA-SQL. */
            _.Move(V1SISTE_DTMOVABE, AREA_DE_WORK.WDATA_SQL);

            /*" -1401- MOVE WDIA-SQL TO DATA2-DD. */
            _.Move(AREA_DE_WORK.FILLER_11.WDIA_SQL, AREA_DE_WORK.LPARM2.DATA2.DATA2_DD);

            /*" -1402- MOVE WMES-SQL TO DATA2-MM. */
            _.Move(AREA_DE_WORK.FILLER_11.WMES_SQL, AREA_DE_WORK.LPARM2.DATA2.DATA2_MM);

            /*" -1404- MOVE WANO-SQL TO DATA2-AA. */
            _.Move(AREA_DE_WORK.FILLER_11.WANO_SQL, AREA_DE_WORK.LPARM2.DATA2.DATA2_AA);

            /*" -1409- PERFORM R0135-00-PROXIMO-DIAUTIL THRU R0135-99-SAIDA 2 TIMES. */

            R0135_00_PROXIMO_DIAUTIL_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R0135_99_SAIDA*/


            /*" -1410- MOVE WANO-SQL TO WANO-TRA */
            _.Move(AREA_DE_WORK.FILLER_11.WANO_SQL, AREA_DE_WORK.FILLER_14.WANO_TRA);

            /*" -1411- MOVE WMES-SQL TO WMES-TRA */
            _.Move(AREA_DE_WORK.FILLER_11.WMES_SQL, AREA_DE_WORK.FILLER_14.WMES_TRA);

            /*" -1412- MOVE WDIA-SQL TO WDIA-TRA */
            _.Move(AREA_DE_WORK.FILLER_11.WDIA_SQL, AREA_DE_WORK.FILLER_14.WDIA_TRA);

            /*" -1413- MOVE WDATATRA TO MOVCC-DTVENCTO */
            _.Move(AREA_DE_WORK.WDATATRA, MOVCC_REGISTRO.MOVCC_DTVENCTO);

            /*" -1416- MOVE WDATA-SQL TO V0MOVDE-DTVENCTO */
            _.Move(AREA_DE_WORK.WDATA_SQL, V0MOVDE_DTVENCTO);

            /*" -1417- MOVE WS-VLPREMIO TO MOVCC-VLRCREDITO */
            _.Move(AREA_DE_WORK.WS_VLPREMIO, MOVCC_REGISTRO.MOVCC_VLRCREDITO);

            /*" -1419- MOVE ZEROS TO MOVCC-CODMOEDA */
            _.Move(0, MOVCC_REGISTRO.MOVCC_CODMOEDA);

            /*" -1420- MOVE 600114 TO WUSO-CONVENIO */
            _.Move(600114, AREA_DE_WORK.FILLER_10.WUSO_CONVENIO);

            /*" -1421- MOVE V0PARAMC-NSAS TO WUSO-NSAS */
            _.Move(V0PARAMC_NSAS, AREA_DE_WORK.FILLER_10.WUSO_NSAS);

            /*" -1422- MOVE WTOTREG TO WUSO-SEQFITA */
            _.Move(AREA_DE_WORK.WTOTREG, AREA_DE_WORK.FILLER_10.WUSO_SEQFITA);

            /*" -1423- MOVE ALL SPACES TO WUSO-SPACES */
            _.MoveAll("", AREA_DE_WORK.FILLER_10.WUSO_SPACES);

            /*" -1425- MOVE WUSOEMPRESA TO MOVCC-USOEMPRESA */
            _.Move(AREA_DE_WORK.WUSOEMPRESA, MOVCC_REGISTRO.MOVCC_USOEMPRESA);

            /*" -1427- MOVE ALL SPACES TO MOVCC-FILLER */
            _.MoveAll("", MOVCC_REGISTRO.MOVCC_FILLER);

            /*" -1429- MOVE V1BILH-NUMBIL TO MOVCC-NUMBILHETE */
            _.Move(V1BILH_NUMBIL, MOVCC_REGISTRO.MOVCC_NUMBILHETE);

            /*" -1431- MOVE 2 TO MOVCC-CODMOVTO */
            _.Move(2, MOVCC_REGISTRO.MOVCC_CODMOVTO);

            /*" -1431- WRITE MOVCC-REGISTRO. */
            MOVCREDITO_CC.Write(MOVCC_REGISTRO.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0120_99_SAIDA*/

        [StopWatch]
        /*" R0125-00-RELATORIO-SECTION */
        private void R0125_00_RELATORIO_SECTION()
        {
            /*" -1440- MOVE 'R0125-00-RELATORIO ' TO WPARAGRAFO */
            _.Move("R0125-00-RELATORIO ", AREA_DE_WORK.WPARAGRAFO);

            /*" -1442- MOVE '125' TO WNR-EXEC-SQL. */
            _.Move("125", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1445- PERFORM R0126-00-LE-V1CLIENTE */

            R0126_00_LE_V1CLIENTE_SECTION();

            /*" -1446- MOVE V1BILH-NUM-APOL TO LD01-NUMBIL */
            _.Move(V1BILH_NUM_APOL, AREA_DE_WORK.LD01.LD01_NUMBIL);

            /*" -1447- MOVE V1BILH-MATR-IND TO LD01-MATRICULA */
            _.Move(V1BILH_MATR_IND, AREA_DE_WORK.LD01.LD01_MATRICULA);

            /*" -1448- MOVE V0MOVDE-DTVENCTO TO WDATA-SQL */
            _.Move(V0MOVDE_DTVENCTO, AREA_DE_WORK.WDATA_SQL);

            /*" -1449- MOVE WDIA-SQL TO WDATA-DD-CABEC */
            _.Move(AREA_DE_WORK.FILLER_11.WDIA_SQL, AREA_DE_WORK.WDATA_CABEC.WDATA_DD_CABEC);

            /*" -1450- MOVE WMES-SQL TO WDATA-MM-CABEC */
            _.Move(AREA_DE_WORK.FILLER_11.WMES_SQL, AREA_DE_WORK.WDATA_CABEC.WDATA_MM_CABEC);

            /*" -1451- MOVE WANO-SQL TO WDATA-AA-CABEC */
            _.Move(AREA_DE_WORK.FILLER_11.WANO_SQL, AREA_DE_WORK.WDATA_CABEC.WDATA_AA_CABEC);

            /*" -1452- MOVE WDATA-CABEC TO LD01-DTVENCTO */
            _.Move(AREA_DE_WORK.WDATA_CABEC, AREA_DE_WORK.LD01.LD01_DTVENCTO);

            /*" -1453- MOVE WDIA-SQL TO V0MOVDE-DIA-DEBITO */
            _.Move(AREA_DE_WORK.FILLER_11.WDIA_SQL, V0MOVDE_DIA_DEBITO);

            /*" -1454- MOVE V0MOVDE-DIA-DEBITO TO LD01-DIA-CREDITO */
            _.Move(V0MOVDE_DIA_DEBITO, AREA_DE_WORK.LD01.LD01_DIA_CREDITO);

            /*" -1455- MOVE V1BILH-AGENCIA-DEB TO LD01-AGENCIA */
            _.Move(V1BILH_AGENCIA_DEB, AREA_DE_WORK.LD01.LD01_AGENCIA);

            /*" -1456- MOVE V1BILH-OPERACAO-DEB TO LD01-OPERACAO */
            _.Move(V1BILH_OPERACAO_DEB, AREA_DE_WORK.LD01.LD01_CREDITO.LD01_OPERACAO);

            /*" -1457- MOVE '/' TO LD01-BARRA */
            _.Move("/", AREA_DE_WORK.LD01.LD01_CREDITO.LD01_BARRA);

            /*" -1458- MOVE V1BILH-CONTA-DEB TO LD01-CONTA */
            _.Move(V1BILH_CONTA_DEB, AREA_DE_WORK.LD01.LD01_CREDITO.LD01_CONTA);

            /*" -1459- MOVE '-' TO LD01-HIFEN1 */
            _.Move("-", AREA_DE_WORK.LD01.LD01_CREDITO.LD01_HIFEN1);

            /*" -1467- MOVE V1BILH-DIGITO-DEB TO LD01-DIGITO */
            _.Move(V1BILH_DIGITO_DEB, AREA_DE_WORK.LD01.LD01_CREDITO.LD01_DIGITO);

            /*" -1469- MOVE WS-VLPREMIO TO LD01-VLCREDITO */
            _.Move(AREA_DE_WORK.WS_VLPREMIO, AREA_DE_WORK.LD01.LD01_VLCREDITO);

            /*" -1471- MOVE V1CLIEN-NOME-RAZAO TO LD01-NOME */
            _.Move(V1CLIEN_NOME_RAZAO, AREA_DE_WORK.LD01.LD01_NOME);

            /*" -1472- IF WLIN GREATER 50 */

            if (AREA_DE_WORK.WLIN > 50)
            {

                /*" -1474- PERFORM R0160-00-CABECALHOS. */

                R0160_00_CABECALHOS_SECTION();
            }


            /*" -1476- WRITE REG-BI6032B FROM LD01 AFTER 1 */
            _.Move(AREA_DE_WORK.LD01.GetMoveValues(), REG_BI6032B);

            RBI6032B.Write(REG_BI6032B.GetMoveValues().ToString());

            /*" -1476- COMPUTE WLIN = WLIN + 1. */
            AREA_DE_WORK.WLIN.Value = AREA_DE_WORK.WLIN + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0125_99_SAIDA*/

        [StopWatch]
        /*" R0126-00-LE-V1CLIENTE-SECTION */
        private void R0126_00_LE_V1CLIENTE_SECTION()
        {
            /*" -1485- MOVE 'R0126-00-LE-V1CLIENTE ' TO WPARAGRAFO */
            _.Move("R0126-00-LE-V1CLIENTE ", AREA_DE_WORK.WPARAGRAFO);

            /*" -1487- MOVE '126' TO WNR-EXEC-SQL. */
            _.Move("126", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1488- MOVE V1BILH-COD-CLIENTE TO V1CLIEN-COD-CLIENTE */
            _.Move(V1BILH_COD_CLIENTE, V1CLIEN_COD_CLIENTE);

            /*" -1490- MOVE SPACES TO V1CLIEN-NOME-RAZAO. */
            _.Move("", V1CLIEN_NOME_RAZAO);

            /*" -1495- PERFORM R0126_00_LE_V1CLIENTE_DB_SELECT_1 */

            R0126_00_LE_V1CLIENTE_DB_SELECT_1();

            /*" -1498- IF SQLCODE NOT EQUAL ZEROS AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -1500- DISPLAY 'BI6032B - ' WPARAGRAFO */
                _.Display($"BI6032B - {AREA_DE_WORK.WPARAGRAFO}");

                /*" -1501- DISPLAY 'V1BILH-NUM-APOL     ' V1BILH-NUM-APOL */
                _.Display($"V1BILH-NUM-APOL     {V1BILH_NUM_APOL}");

                /*" -1502- DISPLAY 'V1CLIEN-COD-CLIENTE ' V1CLIEN-COD-CLIENTE */
                _.Display($"V1CLIEN-COD-CLIENTE {V1CLIEN_COD_CLIENTE}");

                /*" -1502- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0126-00-LE-V1CLIENTE-DB-SELECT-1 */
        public void R0126_00_LE_V1CLIENTE_DB_SELECT_1()
        {
            /*" -1495- EXEC SQL SELECT NOME_RAZAO INTO :V1CLIEN-NOME-RAZAO FROM SEGUROS.V1CLIENTE WHERE COD_CLIENTE = :V1CLIEN-COD-CLIENTE END-EXEC. */

            var r0126_00_LE_V1CLIENTE_DB_SELECT_1_Query1 = new R0126_00_LE_V1CLIENTE_DB_SELECT_1_Query1()
            {
                V1CLIEN_COD_CLIENTE = V1CLIEN_COD_CLIENTE.ToString(),
            };

            var executed_1 = R0126_00_LE_V1CLIENTE_DB_SELECT_1_Query1.Execute(r0126_00_LE_V1CLIENTE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1CLIEN_NOME_RAZAO, V1CLIEN_NOME_RAZAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0126_99_SAIDA*/

        [StopWatch]
        /*" R0130-00-UPDATE-V0PARAM-CONTA-SECTION */
        private void R0130_00_UPDATE_V0PARAM_CONTA_SECTION()
        {
            /*" -1511- MOVE 'R0130-00-UPDATE-V0PARAM-CONTA' TO WPARAGRAFO */
            _.Move("R0130-00-UPDATE-V0PARAM-CONTA", AREA_DE_WORK.WPARAGRAFO);

            /*" -1513- MOVE '130' TO WNR-EXEC-SQL */
            _.Move("130", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1520- PERFORM R0130_00_UPDATE_V0PARAM_CONTA_DB_UPDATE_1 */

            R0130_00_UPDATE_V0PARAM_CONTA_DB_UPDATE_1();

            /*" -1523- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1524- DISPLAY 'BI6032B - ' WPARAGRAFO */
                _.Display($"BI6032B - {AREA_DE_WORK.WPARAGRAFO}");

                /*" -1525- DISPLAY 'V0PARAMC-TIPO-MOVTOCC ' V0PARAMC-TIPO-MOVTOCC */
                _.Display($"V0PARAMC-TIPO-MOVTOCC {V0PARAMC_TIPO_MOVTOCC}");

                /*" -1526- DISPLAY 'V0PARAMC-CODPRODU     ' V0PARAMC-CODPRODU */
                _.Display($"V0PARAMC-CODPRODU     {V0PARAMC_CODPRODU}");

                /*" -1527- DISPLAY 'V0PARAMC-COD-CONVENIO ' V0PARAMC-COD-CONVENIO */
                _.Display($"V0PARAMC-COD-CONVENIO {V0PARAMC_COD_CONVENIO}");

                /*" -1527- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0130-00-UPDATE-V0PARAM-CONTA-DB-UPDATE-1 */
        public void R0130_00_UPDATE_V0PARAM_CONTA_DB_UPDATE_1()
        {
            /*" -1520- EXEC SQL UPDATE SEGUROS.V0PARAM_CONTACEF SET NSAS = :V0PARAMC-NSAS, TIMESTAMP = CURRENT TIMESTAMP WHERE TIPO_MOVTOCC = :V0PARAMC-TIPO-MOVTOCC AND COD_CONVENIO = :V0PARAMC-COD-CONVENIO AND SITUACAO = :V0PARAMC-SITUACAO AND CODPRODU = :V0PARAMC-CODPRODU END-EXEC. */

            var r0130_00_UPDATE_V0PARAM_CONTA_DB_UPDATE_1_Update1 = new R0130_00_UPDATE_V0PARAM_CONTA_DB_UPDATE_1_Update1()
            {
                V0PARAMC_NSAS = V0PARAMC_NSAS.ToString(),
                V0PARAMC_TIPO_MOVTOCC = V0PARAMC_TIPO_MOVTOCC.ToString(),
                V0PARAMC_COD_CONVENIO = V0PARAMC_COD_CONVENIO.ToString(),
                V0PARAMC_SITUACAO = V0PARAMC_SITUACAO.ToString(),
                V0PARAMC_CODPRODU = V0PARAMC_CODPRODU.ToString(),
            };

            R0130_00_UPDATE_V0PARAM_CONTA_DB_UPDATE_1_Update1.Execute(r0130_00_UPDATE_V0PARAM_CONTA_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0130_99_SAIDA*/

        [StopWatch]
        /*" R0135-00-PROXIMO-DIAUTIL-SECTION */
        private void R0135_00_PROXIMO_DIAUTIL_SECTION()
        {
            /*" -1536- MOVE 'R0135-00-PROXIMO-DIAUTIL' TO WPARAGRAFO */
            _.Move("R0135-00-PROXIMO-DIAUTIL", AREA_DE_WORK.WPARAGRAFO);

            /*" -1543- MOVE '135' TO WNR-EXEC-SQL. */
            _.Move("135", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1544- MOVE ZEROS TO DATA3-DD */
            _.Move(0, AREA_DE_WORK.LPARM2.DATA3.DATA3_DD);

            /*" -1545- MOVE ZEROS TO DATA3-MM */
            _.Move(0, AREA_DE_WORK.LPARM2.DATA3.DATA3_MM);

            /*" -1549- MOVE ZEROS TO DATA3-AA */
            _.Move(0, AREA_DE_WORK.LPARM2.DATA3.DATA3_AA);

            /*" -1551- MOVE +1 TO QUANTIDA */
            _.Move(+1, AREA_DE_WORK.LPARM2.QUANTIDA);

            /*" -1553- CALL 'PROSOCU1' USING LPARM2. */
            _.Call("PROSOCU1", AREA_DE_WORK.LPARM2);

            /*" -1555- MOVE DATA3 TO DATA2. */
            _.Move(AREA_DE_WORK.LPARM2.DATA3, AREA_DE_WORK.LPARM2.DATA2);

            /*" -1556- MOVE DATA3-DD TO WDIA-SQL */
            _.Move(AREA_DE_WORK.LPARM2.DATA3.DATA3_DD, AREA_DE_WORK.FILLER_11.WDIA_SQL);

            /*" -1557- MOVE DATA3-MM TO WMES-SQL */
            _.Move(AREA_DE_WORK.LPARM2.DATA3.DATA3_MM, AREA_DE_WORK.FILLER_11.WMES_SQL);

            /*" -1557- MOVE DATA3-AA TO WANO-SQL. */
            _.Move(AREA_DE_WORK.LPARM2.DATA3.DATA3_AA, AREA_DE_WORK.FILLER_11.WANO_SQL);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0135_99_SAIDA*/

        [StopWatch]
        /*" R0145-00-INSERT-V0MOVDEBCC-CEF-SECTION */
        private void R0145_00_INSERT_V0MOVDEBCC_CEF_SECTION()
        {
            /*" -1566- MOVE 'R0145-00-INSERT-V0MOVDEBCC-CEF' TO WPARAGRAFO */
            _.Move("R0145-00-INSERT-V0MOVDEBCC-CEF", AREA_DE_WORK.WPARAGRAFO);

            /*" -1569- MOVE '145' TO WNR-EXEC-SQL. */
            _.Move("145", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1632- PERFORM R0145_00_INSERT_V0MOVDEBCC_CEF_DB_INSERT_1 */

            R0145_00_INSERT_V0MOVDEBCC_CEF_DB_INSERT_1();

            /*" -1635- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1637- DISPLAY 'BI6032B - ' WPARAGRAFO */
                _.Display($"BI6032B - {AREA_DE_WORK.WPARAGRAFO}");

                /*" -1638- DISPLAY 'V1BILH-NUM-APOL      ' V1BILH-NUM-APOL */
                _.Display($"V1BILH-NUM-APOL      {V1BILH_NUM_APOL}");

                /*" -1639- DISPLAY 'V0MOVDE-SIT-COBRANCA ' V0MOVDE-SIT-COBRANCA */
                _.Display($"V0MOVDE-SIT-COBRANCA {V0MOVDE_SIT_COBRANCA}");

                /*" -1640- DISPLAY 'V0MOVDE-DTVENCTO     ' V0MOVDE-DTVENCTO */
                _.Display($"V0MOVDE-DTVENCTO     {V0MOVDE_DTVENCTO}");

                /*" -1640- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0145-00-INSERT-V0MOVDEBCC-CEF-DB-INSERT-1 */
        public void R0145_00_INSERT_V0MOVDEBCC_CEF_DB_INSERT_1()
        {
            /*" -1632- EXEC SQL INSERT INTO SEGUROS.V0MOVDEBCC_CEF ( COD_EMPRESA ,NUM_APOLICE ,NRENDOS ,NRPARCEL ,SIT_COBRANCA ,DTVENCTO ,VLR_DEBITO ,DTMOVTO ,TIMESTAMP ,DIA_DEBITO ,COD_AGENCIA_DEB ,OPER_CONTA_DEB ,NUM_CONTA_DEB ,DIG_CONTA_DEB ,COD_CONVENIO ,DTENVIO ,DTRETORNO ,COD_RETORNO_CEF ,NSAS ,COD_USUARIO ,NUM_REQUISICAO ,NUM_CARTAO ,SEQUENCIA ,NUM_LOTE ,DTCREDITO ,STATUS_CARTAO ,VLR_CREDITO ) VALUES (0 , :V1BILH-NUM-APOL , :WS-ENDOSSO, :WS-PARCELA, '1' , :V0MOVDE-DTVENCTO , :WS-VLPREMIO, :V1SISTE-DTMOVABE, CURRENT TIMESTAMP, :V0MOVDE-DIA-DEBITO , :V1BILH-AGENCIA-DEB, :V1BILH-OPERACAO-DEB, :V1BILH-CONTA-DEB, :V1BILH-DIGITO-DEB, :V0PARAMC-COD-CONVENIO, CURRENT DATE, NULL , NULL , :V0PARAMC-NSAS , 'BI6032B' , NULL , NULL , NULL , NULL , :V1SISTE-DTMOVABE, NULL , NULL) END-EXEC. */

            var r0145_00_INSERT_V0MOVDEBCC_CEF_DB_INSERT_1_Insert1 = new R0145_00_INSERT_V0MOVDEBCC_CEF_DB_INSERT_1_Insert1()
            {
                V1BILH_NUM_APOL = V1BILH_NUM_APOL.ToString(),
                WS_ENDOSSO = AREA_DE_WORK.WS_ENDOSSO.ToString(),
                WS_PARCELA = AREA_DE_WORK.WS_PARCELA.ToString(),
                V0MOVDE_DTVENCTO = V0MOVDE_DTVENCTO.ToString(),
                WS_VLPREMIO = AREA_DE_WORK.WS_VLPREMIO.ToString(),
                V1SISTE_DTMOVABE = V1SISTE_DTMOVABE.ToString(),
                V0MOVDE_DIA_DEBITO = V0MOVDE_DIA_DEBITO.ToString(),
                V1BILH_AGENCIA_DEB = V1BILH_AGENCIA_DEB.ToString(),
                V1BILH_OPERACAO_DEB = V1BILH_OPERACAO_DEB.ToString(),
                V1BILH_CONTA_DEB = V1BILH_CONTA_DEB.ToString(),
                V1BILH_DIGITO_DEB = V1BILH_DIGITO_DEB.ToString(),
                V0PARAMC_COD_CONVENIO = V0PARAMC_COD_CONVENIO.ToString(),
                V0PARAMC_NSAS = V0PARAMC_NSAS.ToString(),
            };

            R0145_00_INSERT_V0MOVDEBCC_CEF_DB_INSERT_1_Insert1.Execute(r0145_00_INSERT_V0MOVDEBCC_CEF_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0145_99_SAIDA*/

        [StopWatch]
        /*" R0160-00-CABECALHOS-SECTION */
        private void R0160_00_CABECALHOS_SECTION()
        {
            /*" -1649- MOVE 'R0160-00-CABECALHOS' TO WPARAGRAFO */
            _.Move("R0160-00-CABECALHOS", AREA_DE_WORK.WPARAGRAFO);

            /*" -1651- MOVE '160' TO WNR-EXEC-SQL. */
            _.Move("160", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1652- MOVE V0PARAMC-NSAS TO LC06-NRFITA */
            _.Move(V0PARAMC_NSAS, AREA_DE_WORK.LC06.LC06_NRFITA);

            /*" -1653- COMPUTE WPAG = WPAG + 1 */
            AREA_DE_WORK.WPAG.Value = AREA_DE_WORK.WPAG + 1;

            /*" -1655- MOVE WPAG TO LC01-PAGINA */
            _.Move(AREA_DE_WORK.WPAG, AREA_DE_WORK.LC01.LC01_PAGINA);

            /*" -1656- WRITE REG-BI6032B FROM LC01 AFTER PAGE */
            _.Move(AREA_DE_WORK.LC01.GetMoveValues(), REG_BI6032B);

            RBI6032B.Write(REG_BI6032B.GetMoveValues().ToString());

            /*" -1657- WRITE REG-BI6032B FROM LC02 AFTER 1 */
            _.Move(AREA_DE_WORK.LC02.GetMoveValues(), REG_BI6032B);

            RBI6032B.Write(REG_BI6032B.GetMoveValues().ToString());

            /*" -1658- WRITE REG-BI6032B FROM LC03 AFTER 1 */
            _.Move(AREA_DE_WORK.LC03.GetMoveValues(), REG_BI6032B);

            RBI6032B.Write(REG_BI6032B.GetMoveValues().ToString());

            /*" -1659- WRITE REG-BI6032B FROM LC07 AFTER 1 */
            _.Move(AREA_DE_WORK.LC07.GetMoveValues(), REG_BI6032B);

            RBI6032B.Write(REG_BI6032B.GetMoveValues().ToString());

            /*" -1660- WRITE REG-BI6032B FROM LC06 AFTER 1 */
            _.Move(AREA_DE_WORK.LC06.GetMoveValues(), REG_BI6032B);

            RBI6032B.Write(REG_BI6032B.GetMoveValues().ToString());

            /*" -1661- WRITE REG-BI6032B FROM LC04 AFTER 1 */
            _.Move(AREA_DE_WORK.LC04.GetMoveValues(), REG_BI6032B);

            RBI6032B.Write(REG_BI6032B.GetMoveValues().ToString());

            /*" -1662- WRITE REG-BI6032B FROM LC05 AFTER 1 */
            _.Move(AREA_DE_WORK.LC05.GetMoveValues(), REG_BI6032B);

            RBI6032B.Write(REG_BI6032B.GetMoveValues().ToString());

            /*" -1664- WRITE REG-BI6032B FROM LC04 AFTER 1 */
            _.Move(AREA_DE_WORK.LC04.GetMoveValues(), REG_BI6032B);

            RBI6032B.Write(REG_BI6032B.GetMoveValues().ToString());

            /*" -1664- MOVE 08 TO WLIN. */
            _.Move(08, AREA_DE_WORK.WLIN);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0160_99_SAIDA*/

        [StopWatch]
        /*" R0170-00-TOTALIZADOR-SECTION */
        private void R0170_00_TOTALIZADOR_SECTION()
        {
            /*" -1673- MOVE 'R0170-00-TOTALIZADOR' TO WPARAGRAFO */
            _.Move("R0170-00-TOTALIZADOR", AREA_DE_WORK.WPARAGRAFO);

            /*" -1675- MOVE '170' TO WNR-EXEC-SQL. */
            _.Move("170", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1676- COMPUTE WTOTREG = WTOTREG - 2 */
            AREA_DE_WORK.WTOTREG.Value = AREA_DE_WORK.WTOTREG - 2;

            /*" -1677- MOVE WTOTREG TO LT01-QT-TOTAL */
            _.Move(AREA_DE_WORK.WTOTREG, AREA_DE_WORK.LT01.LT01_QT_TOTAL);

            /*" -1679- MOVE WTOTCRE TO LT01-VL-TOTAL */
            _.Move(AREA_DE_WORK.WTOTCRE, AREA_DE_WORK.LT01.LT01_VL_TOTAL);

            /*" -1679- WRITE REG-BI6032B FROM LT01 AFTER 2. */
            _.Move(AREA_DE_WORK.LT01.GetMoveValues(), REG_BI6032B);

            RBI6032B.Write(REG_BI6032B.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0170_99_SAIDA*/

        [StopWatch]
        /*" R0180-00-RELAT-SEM-MOVTO-SECTION */
        private void R0180_00_RELAT_SEM_MOVTO_SECTION()
        {
            /*" -1688- MOVE 'R0180-00-RELAT-SEM-MOVTO' TO WPARAGRAFO */
            _.Move("R0180-00-RELAT-SEM-MOVTO", AREA_DE_WORK.WPARAGRAFO);

            /*" -1690- MOVE '180' TO WNR-EXEC-SQL. */
            _.Move("180", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1691- WRITE REG-BI6032B FROM LD02 AFTER 2 */
            _.Move(AREA_DE_WORK.LD02.GetMoveValues(), REG_BI6032B);

            RBI6032B.Write(REG_BI6032B.GetMoveValues().ToString());

            /*" -1692- WRITE REG-BI6032B FROM LD04 AFTER 1 */
            _.Move(AREA_DE_WORK.LD04.GetMoveValues(), REG_BI6032B);

            RBI6032B.Write(REG_BI6032B.GetMoveValues().ToString());

            /*" -1693- WRITE REG-BI6032B FROM LD03 AFTER 1 */
            _.Move(AREA_DE_WORK.LD03.GetMoveValues(), REG_BI6032B);

            RBI6032B.Write(REG_BI6032B.GetMoveValues().ToString());

            /*" -1694- WRITE REG-BI6032B FROM LD04 AFTER 1 */
            _.Move(AREA_DE_WORK.LD04.GetMoveValues(), REG_BI6032B);

            RBI6032B.Write(REG_BI6032B.GetMoveValues().ToString());

            /*" -1694- WRITE REG-BI6032B FROM LD02 AFTER 1. */
            _.Move(AREA_DE_WORK.LD02.GetMoveValues(), REG_BI6032B);

            RBI6032B.Write(REG_BI6032B.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0180_99_SAIDA*/

        [StopWatch]
        /*" R0200-00-CARREGA-ORIGEM-SECTION */
        private void R0200_00_CARREGA_ORIGEM_SECTION()
        {
            /*" -1704- MOVE 'R0200-00-CARREGA-ORIGEM ' TO WPARAGRAFO. */
            _.Move("R0200-00-CARREGA-ORIGEM ", AREA_DE_WORK.WPARAGRAFO);

            /*" -1710- PERFORM R0200_00_CARREGA_ORIGEM_DB_DECLARE_1 */

            R0200_00_CARREGA_ORIGEM_DB_DECLARE_1();

            /*" -1712- PERFORM R0200_00_CARREGA_ORIGEM_DB_OPEN_1 */

            R0200_00_CARREGA_ORIGEM_DB_OPEN_1();

            /*" -1715- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1716- DISPLAY 'PROBLEMAS NO OPEN CORIGEM ' */
                _.Display($"PROBLEMAS NO OPEN CORIGEM ");

                /*" -1718- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1721- MOVE 'R0200-10-CARREGA-ORIGEM       ' TO WPARAGRAFO. */
            _.Move("R0200-10-CARREGA-ORIGEM       ", AREA_DE_WORK.WPARAGRAFO);

            /*" -1722- PERFORM UNTIL WFIM-SISTEMA-ORIGEM EQUAL 'SIM' */

            while (!(AREA_DE_WORK.WFIM_SISTEMA_ORIGEM == "SIM"))
            {

                /*" -1724- PERFORM R0200_00_CARREGA_ORIGEM_DB_FETCH_1 */

                R0200_00_CARREGA_ORIGEM_DB_FETCH_1();

                /*" -1726- IF SQLCODE EQUAL ZEROS */

                if (DB.SQLCODE == 00)
                {

                    /*" -1727- ADD 1 TO WIND1 */
                    AREA_DE_WORK.WIND1.Value = AREA_DE_WORK.WIND1 + 1;

                    /*" -1729- MOVE ARQSIVPF-SISTEMA-ORIGEM TO WTAB-SISTEMA-ORIGEM (WIND1) */
                    _.Move(ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SISTEMA_ORIGEM, W_TAB_SISTEMA_ORIGEM.WTAB_SISTEMA_ORIGEM[AREA_DE_WORK.WIND1]);

                    /*" -1730- ELSE */
                }
                else
                {


                    /*" -1731- IF SQLCODE EQUAL 100 */

                    if (DB.SQLCODE == 100)
                    {

                        /*" -1732- MOVE 'SIM' TO WFIM-SISTEMA-ORIGEM */
                        _.Move("SIM", AREA_DE_WORK.WFIM_SISTEMA_ORIGEM);

                        /*" -1732- PERFORM R0200_00_CARREGA_ORIGEM_DB_CLOSE_1 */

                        R0200_00_CARREGA_ORIGEM_DB_CLOSE_1();

                        /*" -1734- ELSE */
                    }
                    else
                    {


                        /*" -1735- DISPLAY 'PROBLEMAS NO FETCH CORIGEM ' */
                        _.Display($"PROBLEMAS NO FETCH CORIGEM ");

                        /*" -1736- GO TO R9999-00-ROT-ERRO */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;

                        /*" -1737- END-IF */
                    }


                    /*" -1738- END-IF */
                }


                /*" -1738- END-PERFORM. */
            }

        }

        [StopWatch]
        /*" R0200-00-CARREGA-ORIGEM-DB-OPEN-1 */
        public void R0200_00_CARREGA_ORIGEM_DB_OPEN_1()
        {
            /*" -1712- EXEC SQL OPEN CORIGEM END-EXEC. */

            CORIGEM.Open();

        }

        [StopWatch]
        /*" R0200-00-CARREGA-ORIGEM-DB-FETCH-1 */
        public void R0200_00_CARREGA_ORIGEM_DB_FETCH_1()
        {
            /*" -1724- EXEC SQL FETCH CORIGEM INTO :ARQSIVPF-SISTEMA-ORIGEM END-EXEC */

            if (CORIGEM.Fetch())
            {
                _.Move(CORIGEM.ARQSIVPF_SISTEMA_ORIGEM, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SISTEMA_ORIGEM);
            }

        }

        [StopWatch]
        /*" R0200-00-CARREGA-ORIGEM-DB-CLOSE-1 */
        public void R0200_00_CARREGA_ORIGEM_DB_CLOSE_1()
        {
            /*" -1732- EXEC SQL CLOSE CORIGEM END-EXEC */

            CORIGEM.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_99_SAIDA*/

        [StopWatch]
        /*" R1010-00-VERIFICA-ORIGEM-SECTION */
        private void R1010_00_VERIFICA_ORIGEM_SECTION()
        {
            /*" -1749- MOVE '1010-00-VERIFICA-ORIGEM ' TO WPARAGRAFO. */
            _.Move("1010-00-VERIFICA-ORIGEM ", AREA_DE_WORK.WPARAGRAFO);

            /*" -1750- MOVE 1 TO WINF. */
            _.Move(1, AREA_DE_WORK.WINF);

            /*" -1751- MOVE WIND1 TO WSUP. */
            _.Move(AREA_DE_WORK.WIND1, AREA_DE_WORK.WSUP);

            /*" -1753- MOVE SPACES TO WTEM-SISTEMA-ORIGEM */
            _.Move("", AREA_DE_WORK.WTEM_SISTEMA_ORIGEM);

            /*" -1754- PERFORM UNTIL WTEM-SISTEMA-ORIGEM NOT EQUAL SPACES */

            while (!(!AREA_DE_WORK.WTEM_SISTEMA_ORIGEM.IsEmpty()))
            {

                /*" -1755- IF WINF > WSUP */

                if (AREA_DE_WORK.WINF > AREA_DE_WORK.WSUP)
                {

                    /*" -1756- MOVE 'NAO' TO WTEM-SISTEMA-ORIGEM */
                    _.Move("NAO", AREA_DE_WORK.WTEM_SISTEMA_ORIGEM);

                    /*" -1757- ELSE */
                }
                else
                {


                    /*" -1758- COMPUTE WIND = (WSUP + WINF) / 2 */
                    AREA_DE_WORK.WIND.Value = (AREA_DE_WORK.WSUP + AREA_DE_WORK.WINF) / 2;

                    /*" -1760- IF PROPOFID-ORIGEM-PROPOSTA < WTAB-SISTEMA-ORIGEM(WIND) */

                    if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_ORIGEM_PROPOSTA < W_TAB_SISTEMA_ORIGEM.WTAB_SISTEMA_ORIGEM[AREA_DE_WORK.WIND])
                    {

                        /*" -1761- COMPUTE WSUP = WIND - 1 */
                        AREA_DE_WORK.WSUP.Value = AREA_DE_WORK.WIND - 1;

                        /*" -1762- ELSE */
                    }
                    else
                    {


                        /*" -1764- IF PROPOFID-ORIGEM-PROPOSTA > WTAB-SISTEMA-ORIGEM(WIND) */

                        if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_ORIGEM_PROPOSTA > W_TAB_SISTEMA_ORIGEM.WTAB_SISTEMA_ORIGEM[AREA_DE_WORK.WIND])
                        {

                            /*" -1765- COMPUTE WINF = WIND + 1 */
                            AREA_DE_WORK.WINF.Value = AREA_DE_WORK.WIND + 1;

                            /*" -1766- ELSE */
                        }
                        else
                        {


                            /*" -1767- MOVE 'SIM' TO WTEM-SISTEMA-ORIGEM */
                            _.Move("SIM", AREA_DE_WORK.WTEM_SISTEMA_ORIGEM);

                            /*" -1768- END-IF */
                        }


                        /*" -1769- END-IF */
                    }


                    /*" -1770- END-IF */
                }


                /*" -1770- END-PERFORM. */
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1010_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -1780- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, AREA_DE_WORK.WABEND.WSQLCODE);

            /*" -1782- DISPLAY WABEND */
            _.Display(AREA_DE_WORK.WABEND);

            /*" -1782- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -1784- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -1788- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -1788- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}