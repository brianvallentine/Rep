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
using Sias.VidaEmGrupo.DB2.VG1626B;

namespace Code
{
    public class VG1626B
    {
        public bool IsCall { get; set; }

        public VG1626B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------  ---------                                              */
        /*"      ******************************************************************      */
        /*"      *   SISTEMA ................  VG - VIDA EM GRUPO (ESPECIFICAS).  *      */
        /*"      *                                                                *      */
        /*"      *   PROGRAMA ...............  VG1626B                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA................  TERCIO CARVALHO                    *      */
        /*"      *                                                                *      */
        /*"      *   PROGRAMADOR ............  TERCIO CARVALHO                    *      */
        /*"      *                                                                *      */
        /*"      *   DATA CODIFICACAO .......  SETEMBRO/2005                      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO .................  PREPARAR A COBERPROPVA COM OS DA-  *      */
        /*"      *                             DOS PARA O FATURAMENTO DOS SUBGRU- *      */
        /*"      *                             POS. PARA AS APOLICES ESPECIFICAS. *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.25  * VERSAO 25 JAZZ - 279194 - ARQUIVO FINANCEIRO - CAP             *      */
        /*"      *                                                                *      */
        /*"      *   17/03/2021 - CANETTA                 PROCURE POR  - V.25     *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.24  * VERSAO 24 JAZZ - 279194 - CORRECAO NA GERACAO DO ARQUIVO       *      */
        /*"      *                                                                *      */
        /*"      *   25/02/2021 - CANETTA                 PROCURE POR  - V.24     *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.23  * VERSAO 23 JAZZ - 216728 - ERRO DE NAO GERACAO DO ARQUIVO       *      */
        /*"      *                                                                *      */
        /*"      *   07/11/2019 - CANETTA                 PROCURE POR  - V.23     *      */
        /*"      *                                                                *      */
        /*"      * LOCALIZAR LITERAL 'V.0000'                                     *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.22  * VERSAO 22 JAZZ - 198909 - PRODUTO CAP/PM (8234)                *      */
        /*"      *              - CONTROLE DE EMISSAO DO ARQUIVO DA CAP           *      */
        /*"      *                                                                *      */
        /*"      *   27/04/2019 - CANETTA                 PROCURE POR  - V.22     *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.21  * VERSAO 21 JAZZ - 198909 - PRODUTO CAP/PM (8234)                *      */
        /*"      *              - INCLUSAO DO CAMPO TITULO NO ARQUIVO DA CAP      *      */
        /*"      *                                                                *      */
        /*"      *   27/04/2019 - CANETTA                 PROCURE POR  - V.21     *      */
        /*"      *-----------------------------------------------------------------      */
        /*"      * VERSAO 20 JAZZ - 198909 - PRODUTO CAP/PM (8234)                *      */
        /*"      *              - GERACAO DE ARQUIVO DE SEGURADOS QUE COMPOEM A   *      */
        /*"      *                FATURA PARA A APOLICE 108211311837              *      */
        /*"      *                                                                *      */
        /*"      *   22/04/2019 - CANETTA                 PROCURE POR  - V.20     *      */
        /*"      *-----------------------------------------------------------------      */
        /*"      * VERSAO 19 CAD 157.341                                                 */
        /*"      *              - INCLUIR VALORES ANTERIORES PARA COMPRA DE TITULOS      */
        /*"      *                DE CAPITALIZA��O NA HIS_COBER_PROPOST                  */
        /*"      *                                                                       */
        /*"      *   08/01/2018 - ELIERMES OLIVEIRA       PROCURE POR  - V.19            */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 18 - ATENDIMENTO A ABEND                                *      */
        /*"      *             ERRO -305 NO PARAGRAFO R2140-00-SELECT-APOLICOB    *      */
        /*"      *                                                                *      */
        /*"      *    CADMUS - 123.441 DATA: 01/10/2015   PROCURE POR  - V.18     *      */
        /*"      *                                                                *      */
        /*"      *           ELIERMES OLIVEIRA  - MILLENIUM                       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 17 - ATENDIMENTO A ABEND                                *      */
        /*"      *             GEROU DATA INVALIDA '2014-12-30'                   *      */
        /*"      *                                                                *      */
        /*"      *    CADMUS - 107.605 DATA: 30/12/2014   PROCURE POR  - V.17     *      */
        /*"      *                                                                *      */
        /*"      *           FRANK CARVALHO     - INDRA (POLITEC)                 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 16 - CORRECAO PARA CONSIDERAR COMO DATA LIMITE PARA     *      */
        /*"      *             ALTERAR HIS_COBER_PROPOST, PARCELAS_VIDAZUL,       *      */
        /*"      *             COBER_HIST_VIDAZUL E HIST_LANC_CTA A DATA_VENCIMENT*      */
        /*"      *             DA PARCELA > DATA-MOV-ABERTO + 15 DIAS             *      */
        /*"      *                                                                *      */
        /*"      *    CADMUS - 100.000 DATA: 11/09/2014   PROCURE POR  - V.16     *      */
        /*"      *                                                                *      */
        /*"      *           ELIERMES OLIVEIRA       - GESIN - VIDA               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 15 - CORRECAO DA DATA_TERVIGENCIA E DATA_INIVIGENCIA    *      */
        /*"      *             DA NOVA LINHA DA HIS_COBER_PROPOST                 *      */
        /*"      *                                                                *      */
        /*"      *    CADMUS - 95.566  DATA: 07/04/2014   PROCURE POR  - V.15     *      */
        /*"      *                                                                *      */
        /*"      *           ELIERMES OLIVEIRA       - GESIN - VIDA               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 14 - CORRECAO DO UPDATE NO DATA_TERVIGENCIA DA TABELA   *      */
        /*"      *             HIS_COBER_PROPOST                                  *      */
        /*"      *                                                                *      */
        /*"      *    CADMUS - 90.653  DATA: 25/02/2014   PROCURE POR  - V.14     *      */
        /*"      *                                                                *      */
        /*"      *           ELIERMES OLIVEIRA       - GESIN - VIDA               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 13 - CORRECAO DO CALCULO DE TERMINO VIGENCIA QUANDO DA  *      */
        /*"      *             CRIACAO DE UMA NOVA VIGENCIA NA HIS_COBER_PROPOST  *      */
        /*"      *             QUE ESTA OCASIONANDO ERRO NA COBRAN�A DE PARCELAS  *      */
        /*"      *                                                                *      */
        /*"      *    CADMUS - 90.653  DATA: 24/01/2014   PROCURE POR  - V.13     *      */
        /*"      *                                                                *      */
        /*"      *           ELIERMES OLIVEIRA       - GESIN - VIDA               *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      * VERSAO 12 - ALTERA VIGENCIA DE FATURAMENTO INFORMADO PELA BU   *      */
        /*"      *             POR INTERFACE ONLINE NA TABELA VG_VIGENCIA_FATURA  *      */
        /*"      *                                                                *      */
        /*"      *    CADMUS - 85.484  DATA: 31/07/2013   PROCURE POR  - V.12     *      */
        /*"      *                                                                *      */
        /*"      *           ELIERMES OLIVEIRA       - GESIN - VIDA               *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      * VERSAO 11 - TRATAR VIGENCIA DE FATURAMENTO INFORMADO PELA BU   *      */
        /*"      *             POR INTERFACE ONLINE.                              *      */
        /*"      *             (VG_VIGENCIA_FATURA)                               *      */
        /*"      *                                                                *      */
        /*"      *    CADMUS - 84.322  DATA: 03/07/2013   PROCURE POR  - V.11     *      */
        /*"      *                                                                *      */
        /*"      *           ELIERMES OLIVEIRA       - GESIN - VIDA               *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      * VERSAO 10 - PASSA A USAR A DATA DE OPERACAO PARA TESTAR A      *      */
        /*"      *             NECESSIDADE DE GERACAO DE NOVO RESUMO DE VIDAS.    *      */
        /*"      *             (V0COBERPROPVA).                                   *      */
        /*"      *                                                                *      */
        /*"      *    CADMUS - 82.717  DATA: 22/05/2013   PROCURE POR  - V.10     *      */
        /*"      *                                                                *      */
        /*"      *           EDIVALDO GOMES               FAST COMPUTER           *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      * VERSAO 09 - PASSA A PROCESSAR TODAS AS VIDAS DE UMA APOLICE    *      */
        /*"      *             ESPECIFICA.                                        *      */
        /*"      *                                                                *      */
        /*"      *    CADMUS - 78.502  DATA: 17/01/2013   PROCURE POR  - V.09     *      */
        /*"      *                                                                *      */
        /*"      *           LUIZ MARQUES                 FAST COMPUTER           *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      * VERSAO 08 - PASSA A GERAR LINHA NA COBERPROPVA COM NOVO        *      */
        /*"      *             RESUMO DE VIDAS   SOMENTE QUNDO FOR PROCESSADO     *      */
        /*"      *             ARQUIVO DE VIDAS PELO PROGRAMA VG1613B.            *      */
        /*"      *                                                                *      */
        /*"      *    CADMUS - 75.978  DATA: 21/11/2012   PROCURE POR  - V.08     *      */
        /*"      *                                                                *      */
        /*"      *           EDIVALDO GOMES               FAST COMPUTER           *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      * VERSAO 07 - NAO PROCESSAR O TIPO DE FATURAMENTO = '3' - POR    *      */
        /*"      *             SUBGRUPO COM RESUMO E APOLICE 108210871143 (SIM)   *      */
        /*"      *                                                                *      */
        /*"      *    CADMUS - 72.667  DATA: 25/09/2012   PROCURE POR  - V.07     *      */
        /*"      *                                                                *      */
        /*"      *           LUIZ EDUARDO MARQUES         FAST COMPUTER           *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      * VERSAO 06 - NAO PROCESSAR FATURAMENTO MANUAL E N�O ATUALIZAR   *      */
        /*"      *             O NUMERO DA PARCELA NA PROPOSTAS_VA.               *      */
        /*"      *                                                                *      */
        /*"      *    CADMUS - 68.997  DATA: 19/07/2012   PROCURE POR  - V.06     *      */
        /*"      *                                                                *      */
        /*"      *           LUIZ EDUARDO MARQUES         FAST COMPUTER           *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      * VERSAO 05 - ACERTO NA GRAVACAO DA SEGUROS.HIST_LANC_CTA        *      */
        /*"      *                                                                *      */
        /*"      *    CADMUS - 64.504  DATA: 21/12/2011   PROCURE POR  - V.05     *      */
        /*"      *                                                                *      */
        /*"      *           CLAUDIO FREITAS              FAST COMPUTER           *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      * VERSAO 04 - ACERTO NA GRAVACAO DA SEGUROS.HIS_COBER_PROPOST.   *      */
        /*"      *                                                                *      */
        /*"      *    CADMUS - 25.102  DATA: 05/06/2009   PROCURE POR  - V.04     *      */
        /*"      *                                                                *      */
        /*"      *                                        FAST COMPUTER           *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      * VERSAO 03 - PROGRAMA ALTERADO PARA NAO TRATAR AS APOLICES      *      */
        /*"      *             109300000635 E 107700000007.                       *      */
        /*"      *                                                                *      */
        /*"      *    CADMUS - 20.643  DATA: 09/02/2009   PROCURE POR  - V.03     *      */
        /*"      *                                                                *      */
        /*"      * FAST COMPUTER - ANDERSON DE OLIVEIRA                           *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   CAD-14.632/15132       DATA: 25/09/2008 - FAST COMPUTER      *      */
        /*"      *   VERSAO 02 - PASSA A NAO ABENDAR NA TABELA:                   *      */
        /*"      *                                  SEGUROS.COBER_HIST_VIDAZUL    *      */
        /*"      *                                            PROCURE POR V.02    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 01 - PASSA A TRATAR PARCELA JA GERADA                 *      */
        /*"      *                                                                *      */
        /*"      *   EM 22/03/2006 - FAST COMPUTER - TERCIO   PROCURE POR 8M01    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * PROJETO FGV (ALTERACOES)     (WELLINGTON VERAS (POLITEC))      *      */
        /*"      *                                                                *      */
        /*"      * 03/10/2008 - INCLUIR CLAUSULA WITH UR NO SELECT     - WV1008   *      */
        /*"      * 29/07/2008   INIBIR O COMANDO DISPLAY               - WV0708   *      */
        /*"      *----------------------------------------------------------------*      */
        #endregion


        #region VARIABLES

        public FileBasis _VG1626BO { get; set; } = new FileBasis(new PIC("X", "100", "X(100)"));

        public FileBasis VG1626BO
        {
            get
            {
                _.Move(VG1626BO_HEADER, _VG1626BO); VarBasis.RedefinePassValue(VG1626BO_HEADER, _VG1626BO, VG1626BO_HEADER); return _VG1626BO;
            }
        }
        public FileBasis _VG1626BD { get; set; } = new FileBasis(new PIC("X", "100", "X(100)"));

        public FileBasis VG1626BD
        {
            get
            {
                _.Move(VG1626BD_REGISTRO, _VG1626BD); VarBasis.RedefinePassValue(VG1626BD_REGISTRO, _VG1626BD, VG1626BD_REGISTRO); return _VG1626BD;
            }
        }
        /*"01           VG1626BO-HEADER.*/
        public VG1626B_VG1626BO_HEADER VG1626BO_HEADER { get; set; } = new VG1626B_VG1626BO_HEADER();
        public class VG1626B_VG1626BO_HEADER : VarBasis
        {
            /*"  03         VG1626BO-H-TIP-REG PIC  9(001).*/
            public IntBasis VG1626BO_H_TIP_REG { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"  03         VG1626BO-H-SEQ-REG PIC  9(009).*/
            public IntBasis VG1626BO_H_SEQ_REG { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"  03         VG1626BO-H-DAT-COR PIC  X(010).*/
            public StringBasis VG1626BO_H_DAT_COR { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  03         VG1626BO-H-NUM-APO PIC  9(013).*/
            public IntBasis VG1626BO_H_NUM_APO { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
            /*"  03         VG1626BO-H-NUM-PAR PIC  9(005).*/
            public IntBasis VG1626BO_H_NUM_PAR { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
            /*"  03         VG1626BO-H-DAT-VCT PIC  X(010).*/
            public StringBasis VG1626BO_H_DAT_VCT { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  03         FILLER             PIC  X(052).*/
            public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "52", "X(052)."), @"");
            /*"01           VG1626BO-DETALHE.*/
        }
        public VG1626B_VG1626BO_DETALHE VG1626BO_DETALHE { get; set; } = new VG1626B_VG1626BO_DETALHE();
        public class VG1626B_VG1626BO_DETALHE : VarBasis
        {
            /*"  03         VG1626BO-D-TIP-REG PIC  9(001).*/
            public IntBasis VG1626BO_D_TIP_REG { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"  03         VG1626BO-D-SEQ-REG PIC  9(009).*/
            public IntBasis VG1626BO_D_SEQ_REG { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"  03         VG1626BO-D-NUM-CER PIC  9(015).*/
            public IntBasis VG1626BO_D_NUM_CER { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
            /*"  03         VG1626BO-D-SUB-GRU PIC  9(004).*/
            public IntBasis VG1626BO_D_SUB_GRU { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  03         VG1626BO-D-NOM-CLI PIC  X(040).*/
            public StringBasis VG1626BO_D_NOM_CLI { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
            /*"  03         VG1626BO-D-NUM-CPF PIC  9(011).*/
            public IntBasis VG1626BO_D_NUM_CPF { get; set; } = new IntBasis(new PIC("9", "11", "9(011)."));
            /*"  03         VG1626BO-D-VLR-PRE PIC  9(004)V99.*/
            public DoubleBasis VG1626BO_D_VLR_PRE { get; set; } = new DoubleBasis(new PIC("9", "4", "9(004)V99."), 2);
            /*"  03         VG1626BO-D-COD-PLA PIC  9(003).*/
            public IntBasis VG1626BO_D_COD_PLA { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
            /*"  03         VG1626BO-D-SER     PIC  9(003).*/
            public IntBasis VG1626BO_D_SER { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
            /*"  03         VG1626BO-D-NUM-TIT PIC  9(007).*/
            public IntBasis VG1626BO_D_NUM_TIT { get; set; } = new IntBasis(new PIC("9", "7", "9(007)."));
            /*"  03         FILLER             PIC  X(001).*/
            public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"01           VG1626BO-TRAILLER.*/
        }
        public VG1626B_VG1626BO_TRAILLER VG1626BO_TRAILLER { get; set; } = new VG1626B_VG1626BO_TRAILLER();
        public class VG1626B_VG1626BO_TRAILLER : VarBasis
        {
            /*"  03         VG1626BO-T-TIP-REG PIC  9(001).*/
            public IntBasis VG1626BO_T_TIP_REG { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"  03         VG1626BO-T-SEQ-REG PIC  9(009).*/
            public IntBasis VG1626BO_T_SEQ_REG { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"  03         VG1626BO-T-QTD-CER PIC  9(009).*/
            public IntBasis VG1626BO_T_QTD_CER { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"  03         VG1626BO-T-TOT-CER PIC  9(013)V99.*/
            public DoubleBasis VG1626BO_T_TOT_CER { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
            /*"  03         FILLER             PIC  X(066).*/
            public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "66", "X(066)."), @"");
            /*"01           VG1626BD-REGISTRO  PIC  X(100).*/
        }
        public StringBasis VG1626BD_REGISTRO { get; set; } = new StringBasis(new PIC("X", "100", "X(100)."), @"");
        /*"01           VG1626BD-TRAILLER.*/
        public VG1626B_VG1626BD_TRAILLER VG1626BD_TRAILLER { get; set; } = new VG1626B_VG1626BD_TRAILLER();
        public class VG1626B_VG1626BD_TRAILLER : VarBasis
        {
            /*"  03         VG1626BD-T-TIP-REG PIC  9(001).*/
            public IntBasis VG1626BD_T_TIP_REG { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"  03         VG1626BD-T-SEQ-REG PIC  9(009).*/
            public IntBasis VG1626BD_T_SEQ_REG { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"  03         VG1626BD-T-QTD-CER PIC  9(009).*/
            public IntBasis VG1626BD_T_QTD_CER { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"  03         VG1626BD-T-TOT-CER PIC  9(013)V99.*/
            public DoubleBasis VG1626BD_T_TOT_CER { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
            /*"  03         FILLER             PIC  X(066).*/
            public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "66", "X(066)."), @"");
        }

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77  WS-IND-2                      PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis WS_IND_2 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WS-JA-TEM-CODIGO              PIC  X(001)    VALUE 'N'.*/
        public StringBasis WS_JA_TEM_CODIGO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
        /*"77  WS-MOVTO-H-DATA-REFER         PIC  9(006)    VALUE  0.*/
        public IntBasis WS_MOVTO_H_DATA_REFER { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
        /*"77  WS-NUM-APOLICE                PIC S9(013)    VALUE +0 COMP-3*/
        public IntBasis WS_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77  WS-COD-SUBGRUPO               PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis WS_COD_SUBGRUPO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WS-FLAG-HEADER                PIC  X(001).*/
        public StringBasis WS_FLAG_HEADER { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77  WS-FLAG-TRAILER               PIC  X(001).*/
        public StringBasis WS_FLAG_TRAILER { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77  WS-COBERPROPVA                PIC  X(001)    VALUE  'S'.*/
        public StringBasis WS_COBERPROPVA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"S");
        /*"77  WHOST-COD-SUBGRUPO            PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis WHOST_COD_SUBGRUPO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WHOST-COD-SUBGRUPO-I          PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis WHOST_COD_SUBGRUPO_I { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WHOST-COD-SUBGRUPO-F          PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis WHOST_COD_SUBGRUPO_F { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WHOST-QTDSEG                  PIC S9(009)    VALUE +0 COMP.*/
        public IntBasis WHOST_QTDSEG { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77  WHOST-OCORR-END-I             PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis WHOST_OCORR_END_I { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WHOST-OCORR-END-F             PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis WHOST_OCORR_END_F { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WHOST-OCOR-HISTORICO          PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis WHOST_OCOR_HISTORICO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WHOST-SIT-PROPOVA             PIC  X(010).*/
        public StringBasis WHOST_SIT_PROPOVA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  WHOST-DIA-INIVIGENCIA-1       PIC  9(002).*/
        public IntBasis WHOST_DIA_INIVIGENCIA_1 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
        /*"77  WHOST-DATA-INIVIGENCIA-1      PIC  X(010).*/
        public StringBasis WHOST_DATA_INIVIGENCIA_1 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  WHOST-DATA-INIVIGENCIA        PIC  X(010).*/
        public StringBasis WHOST_DATA_INIVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  WHOST-PROX-DATA-INIVIG        PIC  X(010).*/
        public StringBasis WHOST_PROX_DATA_INIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  WHOST-DATA-TERVIGENCIA        PIC  X(010).*/
        public StringBasis WHOST_DATA_TERVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  WHOST-DATA-HISCOBPR           PIC  X(010).*/
        public StringBasis WHOST_DATA_HISCOBPR { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  WHOST-DATA-MOVIMVGA           PIC  X(010).*/
        public StringBasis WHOST_DATA_MOVIMVGA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  WHOST-IND                     PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis WHOST_IND { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WHOST-QTDTIMES                PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis WHOST_QTDTIMES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WHOST-IMPSEG                  PIC S9(013)V99 VALUE +0 COMP-3*/
        public DoubleBasis WHOST_IMPSEG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77  WHOST-PRMVG                   PIC S9(013)V99 VALUE +0 COMP-3*/
        public DoubleBasis WHOST_PRMVG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77  WHOST-PREMIO-VG               PIC S9(013)V99 VALUE +0 COMP-3*/
        public DoubleBasis WHOST_PREMIO_VG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77  WHOST-PREMIO-AP               PIC S9(013)V99 VALUE +0 COMP-3*/
        public DoubleBasis WHOST_PREMIO_AP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
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
        /*"77  V1SIST-DTVENFIM-CN            PIC  X(010).*/
        public StringBasis V1SIST_DTVENFIM_CN { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  WHOST-MIN-DTPROXVEN           PIC  X(010).*/
        public StringBasis WHOST_MIN_DTPROXVEN { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  WHOST-DATA-VENCIMENTO         PIC  X(010).*/
        public StringBasis WHOST_DATA_VENCIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  WHOST-NUM-PARCELA             PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis WHOST_NUM_PARCELA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WHOST-NUM-PARCELA-DEL         PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis WHOST_NUM_PARCELA_DEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WHOST-SIT-PARCELA             PIC  X(001).*/
        public StringBasis WHOST_SIT_PARCELA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77  WHOST-DT-VENCIMENTO-PARC      PIC  X(010) VALUE SPACES.*/
        public StringBasis WHOST_DT_VENCIMENTO_PARC { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
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
        /*"01           WS-NIVEIS-88.*/
        public VG1626B_WS_NIVEIS_88 WS_NIVEIS_88 { get; set; } = new VG1626B_WS_NIVEIS_88();
        public class VG1626B_WS_NIVEIS_88 : VarBasis
        {
            /*"  03         N88-VG1626BO-STATUS  PIC  9(002)  VALUE     ZEROS.*/

            public SelectorBasis N88_VG1626BO_STATUS { get; set; } = new SelectorBasis("002", "ZEROS")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88       VG1626BO-NORMAL                   VALUE     ZEROS. */
							new SelectorItemBasis("VG1626BO_NORMAL", "ZEROS"),
							/*" 88       VG1626BO-ERRO                     VALUE 01 THRU 99. */
							new SelectorItemBasis("VG1626BO_ERRO", "01 THRU 99"),
							/*" 88       VG1626BO-ENDFILE                  VALUE     10. */
							new SelectorItemBasis("VG1626BO_ENDFILE", "10")
                }
            };

            /*"  03         N88-VG1626BD-STATUS  PIC  9(002)  VALUE     ZEROS.*/

            public SelectorBasis N88_VG1626BD_STATUS { get; set; } = new SelectorBasis("002", "ZEROS")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88       VG1626BD-NORMAL                   VALUE     ZEROS. */
							new SelectorItemBasis("VG1626BD_NORMAL", "ZEROS"),
							/*" 88       VG1626BD-ERRO                     VALUE 01 THRU 99. */
							new SelectorItemBasis("VG1626BD_ERRO", "01 THRU 99"),
							/*" 88       VG1626BD-ENDFILE                  VALUE     10. */
							new SelectorItemBasis("VG1626BD_ENDFILE", "10")
                }
            };

            /*" 01       WRETORNO-REG.*/
            public VG1626B_WRETORNO_REG WRETORNO_REG { get; set; } = new VG1626B_WRETORNO_REG();
            public class VG1626B_WRETORNO_REG : VarBasis
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
                /*"01  TABELA-ULTIMOS-DIAS.*/
            }
        }
        public VG1626B_TABELA_ULTIMOS_DIAS TABELA_ULTIMOS_DIAS { get; set; } = new VG1626B_TABELA_ULTIMOS_DIAS();
        public class VG1626B_TABELA_ULTIMOS_DIAS : VarBasis
        {
            /*"    05 FILLER                   PIC  X(024)  VALUE                                '312831303130313130313031'.*/
            public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "24", "X(024)"), @"312831303130313130313031");
            /*"01  TAB-ULTIMOS-DIAS            REDEFINES                                TABELA-ULTIMOS-DIAS.*/
        }
        private _REDEF_VG1626B_TAB_ULTIMOS_DIAS _tab_ultimos_dias { get; set; }
        public _REDEF_VG1626B_TAB_ULTIMOS_DIAS TAB_ULTIMOS_DIAS
        {
            get { _tab_ultimos_dias = new _REDEF_VG1626B_TAB_ULTIMOS_DIAS(); _.Move(TABELA_ULTIMOS_DIAS, _tab_ultimos_dias); VarBasis.RedefinePassValue(TABELA_ULTIMOS_DIAS, _tab_ultimos_dias, TABELA_ULTIMOS_DIAS); _tab_ultimos_dias.ValueChanged += () => { _.Move(_tab_ultimos_dias, TABELA_ULTIMOS_DIAS); }; return _tab_ultimos_dias; }
            set { VarBasis.RedefinePassValue(value, _tab_ultimos_dias, TABELA_ULTIMOS_DIAS); }
        }  //Redefines
        public class _REDEF_VG1626B_TAB_ULTIMOS_DIAS : VarBasis
        {
            /*"    05 TAB-DIA-MESES            OCCURS 12.*/
            public ListBasis<VG1626B_TAB_DIA_MESES> TAB_DIA_MESES { get; set; } = new ListBasis<VG1626B_TAB_DIA_MESES>(12);
            public class VG1626B_TAB_DIA_MESES : VarBasis
            {
                /*"      07 TAB-DIA-MES            PIC  9(002).*/
                public IntBasis TAB_DIA_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"01           PROXIMO-VENCIMENTO.*/

                public VG1626B_TAB_DIA_MESES()
                {
                    TAB_DIA_MES.ValueChanged += OnValueChanged;
                }

            }

            public _REDEF_VG1626B_TAB_ULTIMOS_DIAS()
            {
                TAB_DIA_MESES.ValueChanged += OnValueChanged;
            }

        }
        public VG1626B_PROXIMO_VENCIMENTO PROXIMO_VENCIMENTO { get; set; } = new VG1626B_PROXIMO_VENCIMENTO();
        public class VG1626B_PROXIMO_VENCIMENTO : VarBasis
        {
            /*"   05        WDATA-VIGENCIA.*/
            public VG1626B_WDATA_VIGENCIA WDATA_VIGENCIA { get; set; } = new VG1626B_WDATA_VIGENCIA();
            public class VG1626B_WDATA_VIGENCIA : VarBasis
            {
                /*"    10       WDATA-VIG-ANO     PIC  9(004).*/
                public IntBasis WDATA_VIG_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDATA-VIG-MES     PIC  9(002).*/
                public IntBasis WDATA_VIG_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDATA-VIG-DIA     PIC  9(002).*/
                public IntBasis WDATA_VIG_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"01           AREAS-ARQUIVO-CAP.*/
            }
        }
        public VG1626B_AREAS_ARQUIVO_CAP AREAS_ARQUIVO_CAP { get; set; } = new VG1626B_AREAS_ARQUIVO_CAP();
        public class VG1626B_AREAS_ARQUIVO_CAP : VarBasis
        {
            /*"  03         WS-AUXILIARES.*/
            public VG1626B_WS_AUXILIARES WS_AUXILIARES { get; set; } = new VG1626B_WS_AUXILIARES();
            public class VG1626B_WS_AUXILIARES : VarBasis
            {
                /*"    05       WS-SQLCODE         PIC   ---9.*/
                public IntBasis WS_SQLCODE { get; set; } = new IntBasis(new PIC("9", "4", "---9."));
                /*"    05       WS-NUM-CERTIFICADO PIC S9(015)    VALUE +0  COMP-3.*/
                public IntBasis WS_NUM_CERTIFICADO { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
                /*"    05       WS-APOLICE-CAP     PIC S9(013)    VALUE +0  COMP-3.*/
                public IntBasis WS_APOLICE_CAP { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
                /*"    05       N88-IGNORA-ARQUIVO PIC  X(001)    VALUE     '*'.*/

                public SelectorBasis N88_IGNORA_ARQUIVO { get; set; } = new SelectorBasis("001", "*")
                {
                    Items = new List<SelectorItemBasis> {
                            /*" 88     IGNORA-ARQUIVO                    VALUE     'S'. */
							new SelectorItemBasis("IGNORA_ARQUIVO", "S")
                }
                };

                /*"    05       WS-DATA-GER-VA     PIC  X(010)  VALUE  SPACES.*/
                public StringBasis WS_DATA_GER_VA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"    05       FILLER  REDEFINES  WS-DATA-GER-VA.*/
                private _REDEF_VG1626B_FILLER_7 _filler_7 { get; set; }
                public _REDEF_VG1626B_FILLER_7 FILLER_7
                {
                    get { _filler_7 = new _REDEF_VG1626B_FILLER_7(); _.Move(WS_DATA_GER_VA, _filler_7); VarBasis.RedefinePassValue(WS_DATA_GER_VA, _filler_7, WS_DATA_GER_VA); _filler_7.ValueChanged += () => { _.Move(_filler_7, WS_DATA_GER_VA); }; return _filler_7; }
                    set { VarBasis.RedefinePassValue(value, _filler_7, WS_DATA_GER_VA); }
                }  //Redefines
                public class _REDEF_VG1626B_FILLER_7 : VarBasis
                {
                    /*"      07     WS-ANO-GER-VA      PIC  9(004).*/
                    public IntBasis WS_ANO_GER_VA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"      07     FILLER             PIC  X(001).*/
                    public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"      07     WS-MES-GER-VA      PIC  9(002).*/
                    public IntBasis WS_MES_GER_VA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"      07     FILLER             PIC  X(001).*/
                    public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"      07     WS-DIA-GER-VA      PIC  9(002).*/
                    public IntBasis WS_DIA_GER_VA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"    05       WS-DATA-FATUR      PIC  X(010)  VALUE  'XXXX-XX-XX'*/

                    public _REDEF_VG1626B_FILLER_7()
                    {
                        WS_ANO_GER_VA.ValueChanged += OnValueChanged;
                        FILLER_8.ValueChanged += OnValueChanged;
                        WS_MES_GER_VA.ValueChanged += OnValueChanged;
                        FILLER_9.ValueChanged += OnValueChanged;
                        WS_DIA_GER_VA.ValueChanged += OnValueChanged;
                    }

                }
                public StringBasis WS_DATA_FATUR { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"XXXX-XX-XX");
                /*"    05       FILLER  REDEFINES  WS-DATA-FATUR.*/
                private _REDEF_VG1626B_FILLER_10 _filler_10 { get; set; }
                public _REDEF_VG1626B_FILLER_10 FILLER_10
                {
                    get { _filler_10 = new _REDEF_VG1626B_FILLER_10(); _.Move(WS_DATA_FATUR, _filler_10); VarBasis.RedefinePassValue(WS_DATA_FATUR, _filler_10, WS_DATA_FATUR); _filler_10.ValueChanged += () => { _.Move(_filler_10, WS_DATA_FATUR); }; return _filler_10; }
                    set { VarBasis.RedefinePassValue(value, _filler_10, WS_DATA_FATUR); }
                }  //Redefines
                public class _REDEF_VG1626B_FILLER_10 : VarBasis
                {
                    /*"      07     WS-ANO-FATUR       PIC  9(004).*/
                    public IntBasis WS_ANO_FATUR { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"      07     FILLER             PIC  X(001).*/
                    public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"      07     WS-MES-FATUR       PIC  9(002).*/
                    public IntBasis WS_MES_FATUR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"      07     FILLER             PIC  X(001).*/
                    public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"      07     WS-DIA-FATUR       PIC  9(002).*/
                    public IntBasis WS_DIA_FATUR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"    05       WS-DATA-VCTO       PIC  X(010)  VALUE  SPACES.*/

                    public _REDEF_VG1626B_FILLER_10()
                    {
                        WS_ANO_FATUR.ValueChanged += OnValueChanged;
                        FILLER_11.ValueChanged += OnValueChanged;
                        WS_MES_FATUR.ValueChanged += OnValueChanged;
                        FILLER_12.ValueChanged += OnValueChanged;
                        WS_DIA_FATUR.ValueChanged += OnValueChanged;
                    }

                }
                public StringBasis WS_DATA_VCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"    05       FILLER  REDEFINES  WS-DATA-VCTO.*/
                private _REDEF_VG1626B_FILLER_13 _filler_13 { get; set; }
                public _REDEF_VG1626B_FILLER_13 FILLER_13
                {
                    get { _filler_13 = new _REDEF_VG1626B_FILLER_13(); _.Move(WS_DATA_VCTO, _filler_13); VarBasis.RedefinePassValue(WS_DATA_VCTO, _filler_13, WS_DATA_VCTO); _filler_13.ValueChanged += () => { _.Move(_filler_13, WS_DATA_VCTO); }; return _filler_13; }
                    set { VarBasis.RedefinePassValue(value, _filler_13, WS_DATA_VCTO); }
                }  //Redefines
                public class _REDEF_VG1626B_FILLER_13 : VarBasis
                {
                    /*"      07     WS-ANO-VCTO        PIC  9(004).*/
                    public IntBasis WS_ANO_VCTO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"      07     FILLER             PIC  X(001).*/
                    public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"      07     WS-MES-VCTO        PIC  9(002).*/
                    public IntBasis WS_MES_VCTO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"      07     FILLER             PIC  X(001).*/
                    public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"      07     WS-DIA-VCTO        PIC  9(002).*/
                    public IntBasis WS_DIA_VCTO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"    05       WS-DATA-PRO-VCTO   PIC  X(010)  VALUE  SPACES.*/

                    public _REDEF_VG1626B_FILLER_13()
                    {
                        WS_ANO_VCTO.ValueChanged += OnValueChanged;
                        FILLER_14.ValueChanged += OnValueChanged;
                        WS_MES_VCTO.ValueChanged += OnValueChanged;
                        FILLER_15.ValueChanged += OnValueChanged;
                        WS_DIA_VCTO.ValueChanged += OnValueChanged;
                    }

                }
                public StringBasis WS_DATA_PRO_VCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"    05       FILLER  REDEFINES  WS-DATA-PRO-VCTO.*/
                private _REDEF_VG1626B_FILLER_16 _filler_16 { get; set; }
                public _REDEF_VG1626B_FILLER_16 FILLER_16
                {
                    get { _filler_16 = new _REDEF_VG1626B_FILLER_16(); _.Move(WS_DATA_PRO_VCTO, _filler_16); VarBasis.RedefinePassValue(WS_DATA_PRO_VCTO, _filler_16, WS_DATA_PRO_VCTO); _filler_16.ValueChanged += () => { _.Move(_filler_16, WS_DATA_PRO_VCTO); }; return _filler_16; }
                    set { VarBasis.RedefinePassValue(value, _filler_16, WS_DATA_PRO_VCTO); }
                }  //Redefines
                public class _REDEF_VG1626B_FILLER_16 : VarBasis
                {
                    /*"      07     WS-ANO-PRO-VCTO    PIC  9(004).*/
                    public IntBasis WS_ANO_PRO_VCTO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"      07     FILLER             PIC  X(001).*/
                    public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"      07     WS-MES-PRO-VCTO    PIC  9(002).*/
                    public IntBasis WS_MES_PRO_VCTO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"      07     FILLER             PIC  X(001).*/
                    public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"      07     WS-DIA-PRO-VCTO    PIC  9(002).*/
                    public IntBasis WS_DIA_PRO_VCTO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"    05       WS-DATA-PRO-VCTO-15 PIC X(010)  VALUE  SPACES.*/

                    public _REDEF_VG1626B_FILLER_16()
                    {
                        WS_ANO_PRO_VCTO.ValueChanged += OnValueChanged;
                        FILLER_17.ValueChanged += OnValueChanged;
                        WS_MES_PRO_VCTO.ValueChanged += OnValueChanged;
                        FILLER_18.ValueChanged += OnValueChanged;
                        WS_DIA_PRO_VCTO.ValueChanged += OnValueChanged;
                    }

                }
                public StringBasis WS_DATA_PRO_VCTO_15 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"    05       FILLER  REDEFINES  WS-DATA-PRO-VCTO-15.*/
                private _REDEF_VG1626B_FILLER_19 _filler_19 { get; set; }
                public _REDEF_VG1626B_FILLER_19 FILLER_19
                {
                    get { _filler_19 = new _REDEF_VG1626B_FILLER_19(); _.Move(WS_DATA_PRO_VCTO_15, _filler_19); VarBasis.RedefinePassValue(WS_DATA_PRO_VCTO_15, _filler_19, WS_DATA_PRO_VCTO_15); _filler_19.ValueChanged += () => { _.Move(_filler_19, WS_DATA_PRO_VCTO_15); }; return _filler_19; }
                    set { VarBasis.RedefinePassValue(value, _filler_19, WS_DATA_PRO_VCTO_15); }
                }  //Redefines
                public class _REDEF_VG1626B_FILLER_19 : VarBasis
                {
                    /*"      07     WS-ANO-PRO-VCTO-15 PIC  9(004).*/
                    public IntBasis WS_ANO_PRO_VCTO_15 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"      07     FILLER             PIC  X(001).*/
                    public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"      07     WS-MES-PRO-VCTO-15 PIC  9(002).*/
                    public IntBasis WS_MES_PRO_VCTO_15 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"      07     FILLER             PIC  X(001).*/
                    public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"      07     WS-DIA-PRO-VCTO-15 PIC  9(002).*/
                    public IntBasis WS_DIA_PRO_VCTO_15 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"    05       WS-DATA-CURR-MA-15  PIC X(010)  VALUE  SPACES.*/

                    public _REDEF_VG1626B_FILLER_19()
                    {
                        WS_ANO_PRO_VCTO_15.ValueChanged += OnValueChanged;
                        FILLER_20.ValueChanged += OnValueChanged;
                        WS_MES_PRO_VCTO_15.ValueChanged += OnValueChanged;
                        FILLER_21.ValueChanged += OnValueChanged;
                        WS_DIA_PRO_VCTO_15.ValueChanged += OnValueChanged;
                    }

                }
                public StringBasis WS_DATA_CURR_MA_15 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"    05       FILLER  REDEFINES  WS-DATA-CURR-MA-15.*/
                private _REDEF_VG1626B_FILLER_22 _filler_22 { get; set; }
                public _REDEF_VG1626B_FILLER_22 FILLER_22
                {
                    get { _filler_22 = new _REDEF_VG1626B_FILLER_22(); _.Move(WS_DATA_CURR_MA_15, _filler_22); VarBasis.RedefinePassValue(WS_DATA_CURR_MA_15, _filler_22, WS_DATA_CURR_MA_15); _filler_22.ValueChanged += () => { _.Move(_filler_22, WS_DATA_CURR_MA_15); }; return _filler_22; }
                    set { VarBasis.RedefinePassValue(value, _filler_22, WS_DATA_CURR_MA_15); }
                }  //Redefines
                public class _REDEF_VG1626B_FILLER_22 : VarBasis
                {
                    /*"      07     WS-ANO-CURR-MA-15  PIC  9(004).*/
                    public IntBasis WS_ANO_CURR_MA_15 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"      07     FILLER             PIC  X(001).*/
                    public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"      07     WS-MES-CURR-MA-15  PIC  9(002).*/
                    public IntBasis WS_MES_CURR_MA_15 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"      07     FILLER             PIC  X(001).*/
                    public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"      07     WS-DIA-CURR-MA-15  PIC  9(002).*/
                    public IntBasis WS_DIA_CURR_MA_15 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"    05       WS-DATA-PROC       PIC  X(010)  VALUE  SPACES.*/

                    public _REDEF_VG1626B_FILLER_22()
                    {
                        WS_ANO_CURR_MA_15.ValueChanged += OnValueChanged;
                        FILLER_23.ValueChanged += OnValueChanged;
                        WS_MES_CURR_MA_15.ValueChanged += OnValueChanged;
                        FILLER_24.ValueChanged += OnValueChanged;
                        WS_DIA_CURR_MA_15.ValueChanged += OnValueChanged;
                    }

                }
                public StringBasis WS_DATA_PROC { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"    05       FILLER  REDEFINES  WS-DATA-PROC.*/
                private _REDEF_VG1626B_FILLER_25 _filler_25 { get; set; }
                public _REDEF_VG1626B_FILLER_25 FILLER_25
                {
                    get { _filler_25 = new _REDEF_VG1626B_FILLER_25(); _.Move(WS_DATA_PROC, _filler_25); VarBasis.RedefinePassValue(WS_DATA_PROC, _filler_25, WS_DATA_PROC); _filler_25.ValueChanged += () => { _.Move(_filler_25, WS_DATA_PROC); }; return _filler_25; }
                    set { VarBasis.RedefinePassValue(value, _filler_25, WS_DATA_PROC); }
                }  //Redefines
                public class _REDEF_VG1626B_FILLER_25 : VarBasis
                {
                    /*"      07     WS-ANO-PROC        PIC  9(004).*/
                    public IntBasis WS_ANO_PROC { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"      07     FILLER             PIC  X(001).*/
                    public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"      07     WS-MES-PROC        PIC  9(002).*/
                    public IntBasis WS_MES_PROC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"      07     FILLER             PIC  X(001).*/
                    public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"      07     WS-DIA-PROC        PIC  9(002).*/
                    public IntBasis WS_DIA_PROC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"  03         WS-SUBROTINAS.*/

                    public _REDEF_VG1626B_FILLER_25()
                    {
                        WS_ANO_PROC.ValueChanged += OnValueChanged;
                        FILLER_26.ValueChanged += OnValueChanged;
                        WS_MES_PROC.ValueChanged += OnValueChanged;
                        FILLER_27.ValueChanged += OnValueChanged;
                        WS_DIA_PROC.ValueChanged += OnValueChanged;
                    }

                }
            }
            public VG1626B_WS_SUBROTINAS WS_SUBROTINAS { get; set; } = new VG1626B_WS_SUBROTINAS();
            public class VG1626B_WS_SUBROTINAS : VarBasis
            {
                /*"    05       PROSOCU-LINKAGE.*/
                public VG1626B_PROSOCU_LINKAGE PROSOCU_LINKAGE { get; set; } = new VG1626B_PROSOCU_LINKAGE();
                public class VG1626B_PROSOCU_LINKAGE : VarBasis
                {
                    /*"      07     PROSOCU-DATA-ENTRA PIC  9(008).*/
                    public IntBasis PROSOCU_DATA_ENTRA { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                    /*"      07     FILLER             REDEFINES PROSOCU-DATA-ENTRA.*/
                    private _REDEF_VG1626B_FILLER_28 _filler_28 { get; set; }
                    public _REDEF_VG1626B_FILLER_28 FILLER_28
                    {
                        get { _filler_28 = new _REDEF_VG1626B_FILLER_28(); _.Move(PROSOCU_DATA_ENTRA, _filler_28); VarBasis.RedefinePassValue(PROSOCU_DATA_ENTRA, _filler_28, PROSOCU_DATA_ENTRA); _filler_28.ValueChanged += () => { _.Move(_filler_28, PROSOCU_DATA_ENTRA); }; return _filler_28; }
                        set { VarBasis.RedefinePassValue(value, _filler_28, PROSOCU_DATA_ENTRA); }
                    }  //Redefines
                    public class _REDEF_VG1626B_FILLER_28 : VarBasis
                    {
                        /*"        09   PROSOCU-DIA-ENTRA  PIC  9(002).*/
                        public IntBasis PROSOCU_DIA_ENTRA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                        /*"        09   PROSOCU-MES-ENTRA  PIC  9(002).*/
                        public IntBasis PROSOCU_MES_ENTRA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                        /*"        09   PROSOCU-ANO-ENTRA  PIC  9(004).*/
                        public IntBasis PROSOCU_ANO_ENTRA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                        /*"      07     PROSOCU-QTDIAS     PIC S9(005)     VALUE +1  COMP-3*/

                        public _REDEF_VG1626B_FILLER_28()
                        {
                            PROSOCU_DIA_ENTRA.ValueChanged += OnValueChanged;
                            PROSOCU_MES_ENTRA.ValueChanged += OnValueChanged;
                            PROSOCU_ANO_ENTRA.ValueChanged += OnValueChanged;
                        }

                    }
                    public IntBasis PROSOCU_QTDIAS { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"), +1);
                    /*"      07     PROSOCU-DATA-SAIDA PIC  9(008).*/
                    public IntBasis PROSOCU_DATA_SAIDA { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                    /*"      07     FILLER             REDEFINES PROSOCU-DATA-SAIDA.*/
                    private _REDEF_VG1626B_FILLER_29 _filler_29 { get; set; }
                    public _REDEF_VG1626B_FILLER_29 FILLER_29
                    {
                        get { _filler_29 = new _REDEF_VG1626B_FILLER_29(); _.Move(PROSOCU_DATA_SAIDA, _filler_29); VarBasis.RedefinePassValue(PROSOCU_DATA_SAIDA, _filler_29, PROSOCU_DATA_SAIDA); _filler_29.ValueChanged += () => { _.Move(_filler_29, PROSOCU_DATA_SAIDA); }; return _filler_29; }
                        set { VarBasis.RedefinePassValue(value, _filler_29, PROSOCU_DATA_SAIDA); }
                    }  //Redefines
                    public class _REDEF_VG1626B_FILLER_29 : VarBasis
                    {
                        /*"        09   PROSOCU-DIA-SAIDA  PIC  9(002).*/
                        public IntBasis PROSOCU_DIA_SAIDA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                        /*"        09   PROSOCU-MES-SAIDA  PIC  9(002).*/
                        public IntBasis PROSOCU_MES_SAIDA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                        /*"        09   PROSOCU-ANO-SAIDA  PIC  9(004).*/
                        public IntBasis PROSOCU_ANO_SAIDA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                        /*"01          FILLER.*/

                        public _REDEF_VG1626B_FILLER_29()
                        {
                            PROSOCU_DIA_SAIDA.ValueChanged += OnValueChanged;
                            PROSOCU_MES_SAIDA.ValueChanged += OnValueChanged;
                            PROSOCU_ANO_SAIDA.ValueChanged += OnValueChanged;
                        }

                    }
                }
            }
        }
        public VG1626B_FILLER_30 FILLER_30 { get; set; } = new VG1626B_FILLER_30();
        public class VG1626B_FILLER_30 : VarBasis
        {
            /*"  03        WSQLCODE3           PIC S9(009) COMP.*/
            public IntBasis WSQLCODE3 { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  03        AC-SEQ-REG-ARQ      PIC  9(009)    VALUE ZEROS.*/
            public IntBasis AC_SEQ_REG_ARQ { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03        AC-VG1626BO-GRV     PIC  9(007)    VALUE ZEROS.*/
            public IntBasis AC_VG1626BO_GRV { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03        AC-VG1626BD-GRV     PIC  9(007)    VALUE ZEROS.*/
            public IntBasis AC_VG1626BD_GRV { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03        AC-PAGOS            PIC  9(007)    VALUE ZEROS.*/
            public IntBasis AC_PAGOS { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03        AC-PREMIO-IGUAL     PIC  9(007)    VALUE ZEROS.*/
            public IntBasis AC_PREMIO_IGUAL { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03        AC-JAH-PROCESSADO   PIC  9(007)    VALUE ZEROS.*/
            public IntBasis AC_JAH_PROCESSADO { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03        AC-PREMIO-AJUSTADO  PIC  9(007)    VALUE ZEROS.*/
            public IntBasis AC_PREMIO_AJUSTADO { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03        AC-ERROS-QTDE       PIC  9(007)    VALUE ZEROS.*/
            public IntBasis AC_ERROS_QTDE { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03        AC-ERROS-VALOR      PIC  9(013)V99 VALUE ZEROS.*/
            public DoubleBasis AC_ERROS_VALOR { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
            /*"  03        AC-TOT-CER-O        PIC  9(013)V99 VALUE ZEROS.*/
            public DoubleBasis AC_TOT_CER_O { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
            /*"  03        AC-TOT-CER-D        PIC  9(013)V99 VALUE ZEROS.*/
            public DoubleBasis AC_TOT_CER_D { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
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
            /*"  03        AC-U-PARCELVA       PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_U_PARCELVA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03        AC-U-HISTCOBVA      PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_U_HISTCOBVA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03        AC-U-HISTLANCTA     PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_U_HISTLANCTA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03        AC-I-PARCELVA       PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_I_PARCELVA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03        AC-I-HISTCOBVA      PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_I_HISTCOBVA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03        AC-I-HISTCTABI      PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_I_HISTCTABI { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03        AC-DESPREZ-VIG      PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_DESPREZ_VIG { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03        AC-DESPREZ-FAT-MANU PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_DESPREZ_FAT_MANU { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03        AC-DESPREZ-FAT-RESU PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_DESPREZ_FAT_RESU { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03        AC-DESPREZ-DT-VIGEN PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_DESPREZ_DT_VIGEN { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03        AC-GRAVA-ERRO       PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_GRAVA_ERRO { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03        AC-GRAVA-M          PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_GRAVA_M { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03        AC-GRAVA-E          PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_GRAVA_E { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03        AC-GRAVA-C          PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_GRAVA_C { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03        AC-GRAVA-D          PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_GRAVA_D { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03        AC-GRAVA-B          PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_GRAVA_B { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03        AC-GRAVA-1          PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_GRAVA_1 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03        AC-GRAVA-2          PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_GRAVA_2 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03        AC-GRAVA-3          PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_GRAVA_3 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03        AC-GRAVA-4          PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_GRAVA_4 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03        AC-GRAVA-5          PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_GRAVA_5 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03        AC-GRAVA-6          PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_GRAVA_6 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03        AC-GRAVA-7          PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_GRAVA_7 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03        AC-GRAVA-8          PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_GRAVA_8 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03        AC-GRAVA-9          PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_GRAVA_9 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03        AC-GRAVA-10         PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_GRAVA_10 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03        AC-GRAVA-11         PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_GRAVA_11 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
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
            public VG1626B_WS_W01DTSQL WS_W01DTSQL { get; set; } = new VG1626B_WS_W01DTSQL();
            public class VG1626B_WS_W01DTSQL : VarBasis
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
            public VG1626B_WS_W02DTSQL WS_W02DTSQL { get; set; } = new VG1626B_WS_W02DTSQL();
            public class VG1626B_WS_W02DTSQL : VarBasis
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
            public VG1626B_WS_W03DTSQL WS_W03DTSQL { get; set; } = new VG1626B_WS_W03DTSQL();
            public class VG1626B_WS_W03DTSQL : VarBasis
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
            public VG1626B_WS_W05DTREF WS_W05DTREF { get; set; } = new VG1626B_WS_W05DTREF();
            public class VG1626B_WS_W05DTREF : VarBasis
            {
                /*"    05          WS-W05AAREF         PIC  9(004).*/
                public IntBasis WS_W05AAREF { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05          WS-W05MMREF         PIC  9(002).*/
                public IntBasis WS_W05MMREF { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05          WS-W05DDREF         PIC  9(002).*/
                public IntBasis WS_W05DDREF { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03            WS-W02DTSQL-GERA.*/
            }
            public VG1626B_WS_W02DTSQL_GERA WS_W02DTSQL_GERA { get; set; } = new VG1626B_WS_W02DTSQL_GERA();
            public class VG1626B_WS_W02DTSQL_GERA : VarBasis
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
            public VG1626B_WK_DATA1 WK_DATA1 { get; set; } = new VG1626B_WK_DATA1();
            public class VG1626B_WK_DATA1 : VarBasis
            {
                /*"    10          WS-SEC1           PIC  9(002).*/
                public IntBasis WS_SEC1 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10          WK-ANO1           PIC  9(002).*/
                public IntBasis WK_ANO1 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10          FILLER            PIC  X(001).*/
                public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10          WK-MES1           PIC  9(002).*/
                public IntBasis WK_MES1 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10          FILLER            PIC  X(001).*/
                public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10          WK-DIA1           PIC  9(002).*/
                public IntBasis WK_DIA1 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03            WS-DATA-NASC      PIC  X(008).*/
            }
            public StringBasis WS_DATA_NASC { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"  03            WS-DATA-ADESAO    PIC  9(008).*/
            public IntBasis WS_DATA_ADESAO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"  03            WS-DATA-ADESAO-R  REDEFINES                WS-DATA-ADESAO.*/
            private _REDEF_VG1626B_WS_DATA_ADESAO_R _ws_data_adesao_r { get; set; }
            public _REDEF_VG1626B_WS_DATA_ADESAO_R WS_DATA_ADESAO_R
            {
                get { _ws_data_adesao_r = new _REDEF_VG1626B_WS_DATA_ADESAO_R(); _.Move(WS_DATA_ADESAO, _ws_data_adesao_r); VarBasis.RedefinePassValue(WS_DATA_ADESAO, _ws_data_adesao_r, WS_DATA_ADESAO); _ws_data_adesao_r.ValueChanged += () => { _.Move(_ws_data_adesao_r, WS_DATA_ADESAO); }; return _ws_data_adesao_r; }
                set { VarBasis.RedefinePassValue(value, _ws_data_adesao_r, WS_DATA_ADESAO); }
            }  //Redefines
            public class _REDEF_VG1626B_WS_DATA_ADESAO_R : VarBasis
            {
                /*"    10          WS-ANO-ADESAO     PIC  9(004).*/
                public IntBasis WS_ANO_ADESAO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10          WS-MES-ADESAO     PIC  9(002).*/
                public IntBasis WS_MES_ADESAO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10          WS-DIA-ADESAO     PIC  9(002).*/
                public IntBasis WS_DIA_ADESAO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03            WS-DATA-AUX.*/

                public _REDEF_VG1626B_WS_DATA_ADESAO_R()
                {
                    WS_ANO_ADESAO.ValueChanged += OnValueChanged;
                    WS_MES_ADESAO.ValueChanged += OnValueChanged;
                    WS_DIA_ADESAO.ValueChanged += OnValueChanged;
                }

            }
            public VG1626B_WS_DATA_AUX WS_DATA_AUX { get; set; } = new VG1626B_WS_DATA_AUX();
            public class VG1626B_WS_DATA_AUX : VarBasis
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
            public VG1626B_WS_DATA_INICIAL WS_DATA_INICIAL { get; set; } = new VG1626B_WS_DATA_INICIAL();
            public class VG1626B_WS_DATA_INICIAL : VarBasis
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
            public VG1626B_WS_DATA_FINAL WS_DATA_FINAL { get; set; } = new VG1626B_WS_DATA_FINAL();
            public class VG1626B_WS_DATA_FINAL : VarBasis
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
            public VG1626B_WS_DATA_SQL WS_DATA_SQL { get; set; } = new VG1626B_WS_DATA_SQL();
            public class VG1626B_WS_DATA_SQL : VarBasis
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
            public VG1626B_WS_DATA WS_DATA { get; set; } = new VG1626B_WS_DATA();
            public class VG1626B_WS_DATA : VarBasis
            {
                /*"    10       WS-SEC            PIC  9(002)    VALUE 19.*/
                public IntBasis WS_SEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"), 19);
                /*"    10       WS-ANO            PIC  9(002).*/
                public IntBasis WS_ANO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WS-MES            PIC  9(002).*/
                public IntBasis WS_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WS-DIA            PIC  9(002).*/
                public IntBasis WS_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03         W01GRUPOCOTA      PIC  9(009)    VALUE ZEROS.*/
            }
            public IntBasis W01GRUPOCOTA { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03         FILLER            REDEFINES      W01GRUPOCOTA.*/
            private _REDEF_VG1626B_FILLER_35 _filler_35 { get; set; }
            public _REDEF_VG1626B_FILLER_35 FILLER_35
            {
                get { _filler_35 = new _REDEF_VG1626B_FILLER_35(); _.Move(W01GRUPOCOTA, _filler_35); VarBasis.RedefinePassValue(W01GRUPOCOTA, _filler_35, W01GRUPOCOTA); _filler_35.ValueChanged += () => { _.Move(_filler_35, W01GRUPOCOTA); }; return _filler_35; }
                set { VarBasis.RedefinePassValue(value, _filler_35, W01GRUPOCOTA); }
            }  //Redefines
            public class _REDEF_VG1626B_FILLER_35 : VarBasis
            {
                /*"    10       W01-GRUPO         PIC  9(006).*/
                public IntBasis W01_GRUPO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"    10       W01-COTA          PIC  9(003).*/
                public IntBasis W01_COTA { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"  03         W01DTCSP          PIC  9(008)    VALUE ZEROS.*/

                public _REDEF_VG1626B_FILLER_35()
                {
                    W01_GRUPO.ValueChanged += OnValueChanged;
                    W01_COTA.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis W01DTCSP { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"  03         FILLER            REDEFINES      W01DTCSP.*/
            private _REDEF_VG1626B_FILLER_36 _filler_36 { get; set; }
            public _REDEF_VG1626B_FILLER_36 FILLER_36
            {
                get { _filler_36 = new _REDEF_VG1626B_FILLER_36(); _.Move(W01DTCSP, _filler_36); VarBasis.RedefinePassValue(W01DTCSP, _filler_36, W01DTCSP); _filler_36.ValueChanged += () => { _.Move(_filler_36, W01DTCSP); }; return _filler_36; }
                set { VarBasis.RedefinePassValue(value, _filler_36, W01DTCSP); }
            }  //Redefines
            public class _REDEF_VG1626B_FILLER_36 : VarBasis
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

                public _REDEF_VG1626B_FILLER_36()
                {
                    W01DDCSP.ValueChanged += OnValueChanged;
                    W01MMCSP.ValueChanged += OnValueChanged;
                    W01SCCSP.ValueChanged += OnValueChanged;
                    W01AACSP.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis W02DTCSP { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"  03         FILLER            REDEFINES      W02DTCSP.*/
            private _REDEF_VG1626B_FILLER_37 _filler_37 { get; set; }
            public _REDEF_VG1626B_FILLER_37 FILLER_37
            {
                get { _filler_37 = new _REDEF_VG1626B_FILLER_37(); _.Move(W02DTCSP, _filler_37); VarBasis.RedefinePassValue(W02DTCSP, _filler_37, W02DTCSP); _filler_37.ValueChanged += () => { _.Move(_filler_37, W02DTCSP); }; return _filler_37; }
                set { VarBasis.RedefinePassValue(value, _filler_37, W02DTCSP); }
            }  //Redefines
            public class _REDEF_VG1626B_FILLER_37 : VarBasis
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

                public _REDEF_VG1626B_FILLER_37()
                {
                    W02DDCSP.ValueChanged += OnValueChanged;
                    W02MMCSP.ValueChanged += OnValueChanged;
                    W02SCCSP.ValueChanged += OnValueChanged;
                    W02AACSP.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WS_DTREF { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  03         FILLER            REDEFINES      WS-DTREF.*/
            private _REDEF_VG1626B_FILLER_38 _filler_38 { get; set; }
            public _REDEF_VG1626B_FILLER_38 FILLER_38
            {
                get { _filler_38 = new _REDEF_VG1626B_FILLER_38(); _.Move(WS_DTREF, _filler_38); VarBasis.RedefinePassValue(WS_DTREF, _filler_38, WS_DTREF); _filler_38.ValueChanged += () => { _.Move(_filler_38, WS_DTREF); }; return _filler_38; }
                set { VarBasis.RedefinePassValue(value, _filler_38, WS_DTREF); }
            }  //Redefines
            public class _REDEF_VG1626B_FILLER_38 : VarBasis
            {
                /*"    10       WS-REF-ANO        PIC  9(004).*/
                public IntBasis WS_REF_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       WS-REF-MES        PIC  9(002).*/
                public IntBasis WS_REF_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03         WS-DTREF-SQL      PIC  X(010).*/

                public _REDEF_VG1626B_FILLER_38()
                {
                    WS_REF_ANO.ValueChanged += OnValueChanged;
                    WS_REF_MES.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WS_DTREF_SQL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  03         FILLER            REDEFINES      WS-DTREF-SQL.*/
            private _REDEF_VG1626B_FILLER_39 _filler_39 { get; set; }
            public _REDEF_VG1626B_FILLER_39 FILLER_39
            {
                get { _filler_39 = new _REDEF_VG1626B_FILLER_39(); _.Move(WS_DTREF_SQL, _filler_39); VarBasis.RedefinePassValue(WS_DTREF_SQL, _filler_39, WS_DTREF_SQL); _filler_39.ValueChanged += () => { _.Move(_filler_39, WS_DTREF_SQL); }; return _filler_39; }
                set { VarBasis.RedefinePassValue(value, _filler_39, WS_DTREF_SQL); }
            }  //Redefines
            public class _REDEF_VG1626B_FILLER_39 : VarBasis
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

                public _REDEF_VG1626B_FILLER_39()
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
            /*"  03        WS-NUM-APOLICE-ANT       PIC  9(013) VALUE ZEROS.*/
            public IntBasis WS_NUM_APOLICE_ANT { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
            /*"  03        AC-SOLICITADOS           PIC  9(007) VALUE 0.*/
            public IntBasis AC_SOLICITADOS { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03        W-LIDOS                  PIC  9(007) VALUE 0.*/
            public IntBasis W_LIDOS { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03        WAC-LIDOS                PIC  9(007) VALUE 0.*/
            public IntBasis WAC_LIDOS { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03        W-GRAVADOS               PIC  9(007) VALUE 0.*/
            public IntBasis W_GRAVADOS { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03        FILLER.*/
            public VG1626B_FILLER_40 FILLER_40 { get; set; } = new VG1626B_FILLER_40();
            public class VG1626B_FILLER_40 : VarBasis
            {
                /*"    05      WS-FIM-VALIDA-DATA       PIC  X(003) VALUE 'NAO'.*/
                public StringBasis WS_FIM_VALIDA_DATA { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
                /*"    05      WTEM-VIGENCFAT           PIC  X(003) VALUE 'NAO'.*/
                public StringBasis WTEM_VIGENCFAT { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
                /*"    05      WTEM-PARCEVID            PIC  X(003) VALUE 'NAO'.*/
                public StringBasis WTEM_PARCEVID { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
                /*"    05      WTEM-NRPARCEL            PIC  X(003) VALUE 'NAO'.*/
                public StringBasis WTEM_NRPARCEL { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
                /*"    05      WTEM-RELATORIO           PIC  X(003) VALUE 'NAO'.*/
                public StringBasis WTEM_RELATORIO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
                /*"    05      WGERA-PARCELA            PIC  X(003) VALUE 'NAO'.*/
                public StringBasis WGERA_PARCELA { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
                /*"    05      WTEM-INTERVALO           PIC  X(003) VALUE 'NAO'.*/
                public StringBasis WTEM_INTERVALO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
                /*"    05      WTEM-HISTCOBVA           PIC  X(003) VALUE 'NAO'.*/
                public StringBasis WTEM_HISTCOBVA { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
                /*"    05      WTEM-HISTCONTABILVA      PIC  X(003) VALUE 'NAO'.*/
                public StringBasis WTEM_HISTCONTABILVA { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
                /*"    05      WTEM-HISTCONTABILVA2     PIC  X(003) VALUE 'NAO'.*/
                public StringBasis WTEM_HISTCONTABILVA2 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
                /*"    05      WTEM-COBERPROPVA         PIC  X(003) VALUE 'NAO'.*/
                public StringBasis WTEM_COBERPROPVA { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
                /*"    05      WTEM-SEGURVGA            PIC  X(003) VALUE 'NAO'.*/
                public StringBasis WTEM_SEGURVGA { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
                /*"    05      WTEM-CLIENTE             PIC  X(003) VALUE 'NAO'.*/
                public StringBasis WTEM_CLIENTE { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
                /*"    05      WTEM-SUBGVGAP            PIC  X(003) VALUE 'NAO'.*/
                public StringBasis WTEM_SUBGVGAP { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
                /*"    05      WFIM-MOVIMENTO           PIC  X(003) VALUE 'NAO'.*/
                public StringBasis WFIM_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
                /*"    05      WFIM-SEGURVGA            PIC  X(003) VALUE 'NAO'.*/
                public StringBasis WFIM_SEGURVGA { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
                /*"    05      WPROCESSA                PIC  X(003) VALUE 'NAO'.*/
                public StringBasis WPROCESSA { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
                /*"    05      FLAG-WFIM-SEGURADO             PIC  9(001) VALUE 0.*/

                public SelectorBasis FLAG_WFIM_SEGURADO { get; set; } = new SelectorBasis("001", "0")
                {
                    Items = new List<SelectorItemBasis> {
                            /*" 88    FIM-SEGURADO                   VALUE 1. */
							new SelectorItemBasis("FIM_SEGURADO", "1")
                }
                };

                /*"    03      WABEND.*/
                public VG1626B_WABEND WABEND { get; set; } = new VG1626B_WABEND();
                public class VG1626B_WABEND : VarBasis
                {
                    /*"      05      FILLER              PIC  X(010) VALUE             ' VG1626B'.*/
                    public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" VG1626B");
                    /*"      05      FILLER              PIC  X(028) VALUE             ' *** ERRO  EXEC SQL  NUMERO '.*/
                    public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @" *** ERRO  EXEC SQL  NUMERO ");
                    /*"      05      WNR-EXEC-SQL        PIC  X(004) VALUE '0000'.*/
                    public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"0000");
                    /*"      05      FILLER              PIC  X(017) VALUE             ' *** PARAGRAFO = '.*/
                    public StringBasis FILLER_43 { get; set; } = new StringBasis(new PIC("X", "17", "X(017)"), @" *** PARAGRAFO = ");
                    /*"      05      PARAGRAFO           PIC  X(030) VALUE SPACES.*/
                    public StringBasis PARAGRAFO { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"");
                    /*"      05      FILLER              PIC  X(014) VALUE             '    SQLCODE = '.*/
                    public StringBasis FILLER_44 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE = ");
                    /*"      05      WSQLCODE            PIC  ZZZZZZ999- VALUE ZEROS.*/
                    public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
                    /*"      05      FILLER              PIC  X(014) VALUE             '    SQLCODE1= '.*/
                    public StringBasis FILLER_45 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE1= ");
                    /*"      05      WSQLCODE1           PIC  ZZZZZZ999- VALUE ZEROS.*/
                    public IntBasis WSQLCODE1 { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
                    /*"      05      FILLER              PIC  X(014) VALUE             '    SQLCODE2= '.*/
                    public StringBasis FILLER_46 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE2= ");
                    /*"      05      WSQLCODE2           PIC  ZZZZZZ999- VALUE ZEROS.*/
                    public IntBasis WSQLCODE2 { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
                    /*"    03         WSQLERRO.*/
                }
                public VG1626B_WSQLERRO WSQLERRO { get; set; } = new VG1626B_WSQLERRO();
                public class VG1626B_WSQLERRO : VarBasis
                {
                    /*"      05         FILLER               PIC  X(014) VALUE                ' *** SQLERRMC '.*/
                    public StringBasis FILLER_47 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @" *** SQLERRMC ");
                    /*"      05         WSQLERRMC            PIC  X(070) VALUE  SPACES.*/
                    public StringBasis WSQLERRMC { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"");
                    /*"  03  W-NUMR-TITULO                  PIC  9(013)   VALUE ZEROS.*/
                }
            }
            public IntBasis W_NUMR_TITULO { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
            /*"  03  FILLER                         REDEFINES    W-NUMR-TITULO.*/
            private _REDEF_VG1626B_FILLER_48 _filler_48 { get; set; }
            public _REDEF_VG1626B_FILLER_48 FILLER_48
            {
                get { _filler_48 = new _REDEF_VG1626B_FILLER_48(); _.Move(W_NUMR_TITULO, _filler_48); VarBasis.RedefinePassValue(W_NUMR_TITULO, _filler_48, W_NUMR_TITULO); _filler_48.ValueChanged += () => { _.Move(_filler_48, W_NUMR_TITULO); }; return _filler_48; }
                set { VarBasis.RedefinePassValue(value, _filler_48, W_NUMR_TITULO); }
            }  //Redefines
            public class _REDEF_VG1626B_FILLER_48 : VarBasis
            {
                /*"      05    WTITL-ZEROS              PIC  9(002).*/
                public IntBasis WTITL_ZEROS { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      05    WTITL-SEQUENCIA          PIC  9(010).*/
                public IntBasis WTITL_SEQUENCIA { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
                /*"      05    WTITL-DIGITO             PIC  9(001).*/
                public IntBasis WTITL_DIGITO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"  03  DPARM01X.*/

                public _REDEF_VG1626B_FILLER_48()
                {
                    WTITL_ZEROS.ValueChanged += OnValueChanged;
                    WTITL_SEQUENCIA.ValueChanged += OnValueChanged;
                    WTITL_DIGITO.ValueChanged += OnValueChanged;
                }

            }
            public VG1626B_DPARM01X DPARM01X { get; set; } = new VG1626B_DPARM01X();
            public class VG1626B_DPARM01X : VarBasis
            {
                /*"      05            DPARM01          PIC  9(010).*/
                public IntBasis DPARM01 { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
                /*"      05            DPARM01-R        REDEFINES   DPARM01.*/
                private _REDEF_VG1626B_DPARM01_R _dparm01_r { get; set; }
                public _REDEF_VG1626B_DPARM01_R DPARM01_R
                {
                    get { _dparm01_r = new _REDEF_VG1626B_DPARM01_R(); _.Move(DPARM01, _dparm01_r); VarBasis.RedefinePassValue(DPARM01, _dparm01_r, DPARM01); _dparm01_r.ValueChanged += () => { _.Move(_dparm01_r, DPARM01); }; return _dparm01_r; }
                    set { VarBasis.RedefinePassValue(value, _dparm01_r, DPARM01); }
                }  //Redefines
                public class _REDEF_VG1626B_DPARM01_R : VarBasis
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

                    public _REDEF_VG1626B_DPARM01_R()
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
            public VG1626B_FILLER_49 FILLER_49 { get; set; } = new VG1626B_FILLER_49();
            public class VG1626B_FILLER_49 : VarBasis
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
            private _REDEF_VG1626B_FILLER_50 _filler_50 { get; set; }
            public _REDEF_VG1626B_FILLER_50 FILLER_50
            {
                get { _filler_50 = new _REDEF_VG1626B_FILLER_50(); _.Move(WDATA_REL, _filler_50); VarBasis.RedefinePassValue(WDATA_REL, _filler_50, WDATA_REL); _filler_50.ValueChanged += () => { _.Move(_filler_50, WDATA_REL); }; return _filler_50; }
                set { VarBasis.RedefinePassValue(value, _filler_50, WDATA_REL); }
            }  //Redefines
            public class _REDEF_VG1626B_FILLER_50 : VarBasis
            {
                /*"    10      WDAT-REL-SEC        PIC  9(002).*/
                public IntBasis WDAT_REL_SEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10      WDAT-REL-ANO        PIC  9(002).*/
                public IntBasis WDAT_REL_ANO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10      FILLER              PIC  X(001).*/
                public StringBasis FILLER_51 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10      WDAT-REL-MES        PIC  9(002).*/
                public IntBasis WDAT_REL_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10      FILLER              PIC  X(001).*/
                public StringBasis FILLER_52 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10      WDAT-REL-DIA        PIC  9(002).*/
                public IntBasis WDAT_REL_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03        WDAT-REL-LIT.*/

                public _REDEF_VG1626B_FILLER_50()
                {
                    WDAT_REL_SEC.ValueChanged += OnValueChanged;
                    WDAT_REL_ANO.ValueChanged += OnValueChanged;
                    FILLER_51.ValueChanged += OnValueChanged;
                    WDAT_REL_MES.ValueChanged += OnValueChanged;
                    FILLER_52.ValueChanged += OnValueChanged;
                    WDAT_REL_DIA.ValueChanged += OnValueChanged;
                }

            }
            public VG1626B_WDAT_REL_LIT WDAT_REL_LIT { get; set; } = new VG1626B_WDAT_REL_LIT();
            public class VG1626B_WDAT_REL_LIT : VarBasis
            {
                /*"    10      WDAT-LIT-DIA        PIC  9(002)  VALUE ZEROS.*/
                public IntBasis WDAT_LIT_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10      FILLER              PIC  X(001)  VALUE '/'.*/
                public StringBasis FILLER_53 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10      WDAT-LIT-MES        PIC  9(002)  VALUE ZEROS.*/
                public IntBasis WDAT_LIT_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10      FILLER              PIC  X(001)  VALUE '/'.*/
                public StringBasis FILLER_54 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10      WDAT-LIT-SEC        PIC  9(002)  VALUE ZEROS.*/
                public IntBasis WDAT_LIT_SEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10      WDAT-LIT-ANO        PIC  9(002)  VALUE ZEROS.*/
                public IntBasis WDAT_LIT_ANO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  03         WDATA-ALTERACAO   PIC  X(010)    VALUE SPACES.*/
            }
            public StringBasis WDATA_ALTERACAO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  03         FILLER            REDEFINES      WDATA-ALTERACAO.*/
            private _REDEF_VG1626B_FILLER_55 _filler_55 { get; set; }
            public _REDEF_VG1626B_FILLER_55 FILLER_55
            {
                get { _filler_55 = new _REDEF_VG1626B_FILLER_55(); _.Move(WDATA_ALTERACAO, _filler_55); VarBasis.RedefinePassValue(WDATA_ALTERACAO, _filler_55, WDATA_ALTERACAO); _filler_55.ValueChanged += () => { _.Move(_filler_55, WDATA_ALTERACAO); }; return _filler_55; }
                set { VarBasis.RedefinePassValue(value, _filler_55, WDATA_ALTERACAO); }
            }  //Redefines
            public class _REDEF_VG1626B_FILLER_55 : VarBasis
            {
                /*"    10       WCOR-ANO.*/
                public VG1626B_WCOR_ANO WCOR_ANO { get; set; } = new VG1626B_WCOR_ANO();
                public class VG1626B_WCOR_ANO : VarBasis
                {
                    /*"      15     WCOR-ANOS         PIC  9(002).*/
                    public IntBasis WCOR_ANOS { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"      15     WCOR-ANOA         PIC  9(002).*/
                    public IntBasis WCOR_ANOA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"    10       WCOR-BR1          PIC  X(001).*/

                    public VG1626B_WCOR_ANO()
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

                public _REDEF_VG1626B_FILLER_55()
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
            private _REDEF_VG1626B_FILLER_56 _filler_56 { get; set; }
            public _REDEF_VG1626B_FILLER_56 FILLER_56
            {
                get { _filler_56 = new _REDEF_VG1626B_FILLER_56(); _.Move(WDATA_RETORNO, _filler_56); VarBasis.RedefinePassValue(WDATA_RETORNO, _filler_56, WDATA_RETORNO); _filler_56.ValueChanged += () => { _.Move(_filler_56, WDATA_RETORNO); }; return _filler_56; }
                set { VarBasis.RedefinePassValue(value, _filler_56, WDATA_RETORNO); }
            }  //Redefines
            public class _REDEF_VG1626B_FILLER_56 : VarBasis
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

                public _REDEF_VG1626B_FILLER_56()
                {
                    WRET_DIA.ValueChanged += OnValueChanged;
                    WRET_MES.ValueChanged += OnValueChanged;
                    WRET_SEC.ValueChanged += OnValueChanged;
                    WRET_ANO.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WDATA_PARAMETRO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"  03         FILLER            REDEFINES      WDATA-PARAMETRO.*/
            private _REDEF_VG1626B_FILLER_57 _filler_57 { get; set; }
            public _REDEF_VG1626B_FILLER_57 FILLER_57
            {
                get { _filler_57 = new _REDEF_VG1626B_FILLER_57(); _.Move(WDATA_PARAMETRO, _filler_57); VarBasis.RedefinePassValue(WDATA_PARAMETRO, _filler_57, WDATA_PARAMETRO); _filler_57.ValueChanged += () => { _.Move(_filler_57, WDATA_PARAMETRO); }; return _filler_57; }
                set { VarBasis.RedefinePassValue(value, _filler_57, WDATA_PARAMETRO); }
            }  //Redefines
            public class _REDEF_VG1626B_FILLER_57 : VarBasis
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

                public _REDEF_VG1626B_FILLER_57()
                {
                    WPAR_DIA.ValueChanged += OnValueChanged;
                    WPAR_MES.ValueChanged += OnValueChanged;
                    WPAR_SEC.ValueChanged += OnValueChanged;
                    WPAR_ANO.ValueChanged += OnValueChanged;
                }

            }
            public VG1626B_CHAVE_MOVIMENTO CHAVE_MOVIMENTO { get; set; } = new VG1626B_CHAVE_MOVIMENTO();
            public class VG1626B_CHAVE_MOVIMENTO : VarBasis
            {
                /*"    10      CH-MATRIC-MOV       PIC  9(015)  VALUE ZEROS.*/
                public IntBasis CH_MATRIC_MOV { get; set; } = new IntBasis(new PIC("9", "15", "9(015)"));
                /*"  03        CHAVE-SEGURADO.*/
            }
            public VG1626B_CHAVE_SEGURADO CHAVE_SEGURADO { get; set; } = new VG1626B_CHAVE_SEGURADO();
            public class VG1626B_CHAVE_SEGURADO : VarBasis
            {
                /*"    10      CH-MATRIC-SEG       PIC  9(015)  VALUE ZEROS.*/
                public IntBasis CH_MATRIC_SEG { get; set; } = new IntBasis(new PIC("9", "15", "9(015)"));
                /*"01    WS-HORAS.*/
            }
        }
        public VG1626B_WS_HORAS WS_HORAS { get; set; } = new VG1626B_WS_HORAS();
        public class VG1626B_WS_HORAS : VarBasis
        {
            /*"  03  WS-HORA-INI               PIC  X(008).*/
            public StringBasis WS_HORA_INI { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"  03  WS-HORA-INI-R REDEFINES WS-HORA-INI.*/
            private _REDEF_VG1626B_WS_HORA_INI_R _ws_hora_ini_r { get; set; }
            public _REDEF_VG1626B_WS_HORA_INI_R WS_HORA_INI_R
            {
                get { _ws_hora_ini_r = new _REDEF_VG1626B_WS_HORA_INI_R(); _.Move(WS_HORA_INI, _ws_hora_ini_r); VarBasis.RedefinePassValue(WS_HORA_INI, _ws_hora_ini_r, WS_HORA_INI); _ws_hora_ini_r.ValueChanged += () => { _.Move(_ws_hora_ini_r, WS_HORA_INI); }; return _ws_hora_ini_r; }
                set { VarBasis.RedefinePassValue(value, _ws_hora_ini_r, WS_HORA_INI); }
            }  //Redefines
            public class _REDEF_VG1626B_WS_HORA_INI_R : VarBasis
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

                public _REDEF_VG1626B_WS_HORA_INI_R()
                {
                    HI.ValueChanged += OnValueChanged;
                    MI.ValueChanged += OnValueChanged;
                    SI.ValueChanged += OnValueChanged;
                    DI.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WS_HORA_FIM { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"  03  WS-HORA-FIM-R REDEFINES WS-HORA-FIM.*/
            private _REDEF_VG1626B_WS_HORA_FIM_R _ws_hora_fim_r { get; set; }
            public _REDEF_VG1626B_WS_HORA_FIM_R WS_HORA_FIM_R
            {
                get { _ws_hora_fim_r = new _REDEF_VG1626B_WS_HORA_FIM_R(); _.Move(WS_HORA_FIM, _ws_hora_fim_r); VarBasis.RedefinePassValue(WS_HORA_FIM, _ws_hora_fim_r, WS_HORA_FIM); _ws_hora_fim_r.ValueChanged += () => { _.Move(_ws_hora_fim_r, WS_HORA_FIM); }; return _ws_hora_fim_r; }
                set { VarBasis.RedefinePassValue(value, _ws_hora_fim_r, WS_HORA_FIM); }
            }  //Redefines
            public class _REDEF_VG1626B_WS_HORA_FIM_R : VarBasis
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

                public _REDEF_VG1626B_WS_HORA_FIM_R()
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
        public VG1626B_TOTAIS_ROT TOTAIS_ROT { get; set; } = new VG1626B_TOTAIS_ROT();
        public class VG1626B_TOTAIS_ROT : VarBasis
        {
            /*"    03  FILLER  OCCURS 50 TIMES.*/
            public ListBasis<VG1626B_FILLER_58> FILLER_58 { get; set; } = new ListBasis<VG1626B_FILLER_58>(50);
            public class VG1626B_FILLER_58 : VarBasis
            {
                /*"        05  STT                       PIC S9(013)V99 COMP-3.*/
                public DoubleBasis STT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
                /*"        05  SQT                       PIC S9(015)    COMP-3.*/
                public IntBasis SQT { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
                /*"01        LK-LINK.*/
            }
        }
        public VG1626B_LK_LINK LK_LINK { get; set; } = new VG1626B_LK_LINK();
        public class VG1626B_LK_LINK : VarBasis
        {
            /*"      05     LK-DATA1          PIC  9(008).*/
            public IntBasis LK_DATA1 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"      05     LK-DATA2          PIC  9(008).*/
            public IntBasis LK_DATA2 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"      05     QTDIA             PIC S9(005)          COMP-3.*/
            public IntBasis QTDIA { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));
            /*"01         WPROSOMD2.*/
        }
        public VG1626B_WPROSOMD2 WPROSOMD2 { get; set; } = new VG1626B_WPROSOMD2();
        public class VG1626B_WPROSOMD2 : VarBasis
        {
            /*"    05       WDATA-INFORMADA   PIC  9(008).*/
            public IntBasis WDATA_INFORMADA { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"    05       WDATA-QTDIAS      PIC S9(005)    COMP-3.*/
            public IntBasis WDATA_QTDIAS { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));
            /*"    05       WDATA-CALCULO     PIC  9(008).*/
            public IntBasis WDATA_CALCULO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"01        PARAMETROS.*/
        }
        public VG1626B_PARAMETROS PARAMETROS { get; set; } = new VG1626B_PARAMETROS();
        public class VG1626B_PARAMETROS : VarBasis
        {
            /*"    10      LK710-APOLICE               PIC S9(013) COMP-3.*/
            public IntBasis LK710_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
            /*"    10      LK710-SUBGRUPO              PIC S9(004) COMP.*/
            public IntBasis LK710_SUBGRUPO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    10      LK710-IDADE                 PIC S9(004) COMP.*/
            public IntBasis LK710_IDADE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    10      LK710-NASCIMENTO.*/
            public VG1626B_LK710_NASCIMENTO LK710_NASCIMENTO { get; set; } = new VG1626B_LK710_NASCIMENTO();
            public class VG1626B_LK710_NASCIMENTO : VarBasis
            {
                /*"      15 LK710-DATA-NASCIMENTO          PIC  9(008).*/
                public IntBasis LK710_DATA_NASCIMENTO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"    10      LK710-SALARIO               PIC S9(013)V99 COMP-3.*/
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
            /*"01        PARAMETROS-702.*/
        }
        public VG1626B_PARAMETROS_702 PARAMETROS_702 { get; set; } = new VG1626B_PARAMETROS_702();
        public class VG1626B_PARAMETROS_702 : VarBasis
        {
            /*"    10      LK-APOLICE               PIC S9(013) COMP-3.*/
            public IntBasis LK_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
            /*"    10      LK-SUBGRUPO              PIC S9(004) COMP.*/
            public IntBasis LK_SUBGRUPO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    10      LK-IDADE                 PIC S9(004) COMP.*/
            public IntBasis LK_IDADE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    10      LK-NASCIMENTO.*/
            public VG1626B_LK_NASCIMENTO LK_NASCIMENTO { get; set; } = new VG1626B_LK_NASCIMENTO();
            public class VG1626B_LK_NASCIMENTO : VarBasis
            {
                /*"      15 LK-DATA-NASCIMENTO          PIC  9(008).*/
                public IntBasis LK_DATA_NASCIMENTO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"    10      LK-SALARIO               PIC S9(013)V99 COMP-3.*/
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
        public VG1626B_WS_MOVTO_CLIENTE WS_MOVTO_CLIENTE { get; set; } = new VG1626B_WS_MOVTO_CLIENTE();
        public class VG1626B_WS_MOVTO_CLIENTE : VarBasis
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
            /*"  05       WTEM-GECLIMOV          PIC  X(001)    VALUE  SPACES.*/
            public StringBasis WTEM_GECLIMOV { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"01              WS-PARAMETROS.*/
        }
        public VG1626B_WS_PARAMETROS WS_PARAMETROS { get; set; } = new VG1626B_WS_PARAMETROS();
        public class VG1626B_WS_PARAMETROS : VarBasis
        {
            /*"  03            W01DIGCERT.*/
            public VG1626B_W01DIGCERT W01DIGCERT { get; set; } = new VG1626B_W01DIGCERT();
            public class VG1626B_W01DIGCERT : VarBasis
            {
                /*"    05          WCERTIFICADO    PIC  9(015)        VALUE  0.*/
                public IntBasis WCERTIFICADO { get; set; } = new IntBasis(new PIC("9", "15", "9(015)"));
                /*"    05          WNUMERO         PIC S9(004)  COMP  VALUE +15.*/
                public IntBasis WNUMERO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), +15);
                /*"    05          WDIG            PIC  X(001)  VALUE SPACES.*/
                public StringBasis WDIG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            }
        }


        public Copies.LBFVG001 LBFVG001 { get; set; } = new Copies.LBFVG001();
        public Copies.LBFVG002 LBFVG002 { get; set; } = new Copies.LBFVG002();
        public Copies.LBFVG003 LBFVG003 { get; set; } = new Copies.LBFVG003();
        public Dclgens.APOLICES APOLICES { get; set; } = new Dclgens.APOLICES();
        public Dclgens.BANCOS BANCOS { get; set; } = new Dclgens.BANCOS();
        public Dclgens.CALENDAR CALENDAR { get; set; } = new Dclgens.CALENDAR();
        public Dclgens.CLIENTES CLIENTES { get; set; } = new Dclgens.CLIENTES();
        public Dclgens.COBHISVI COBHISVI { get; set; } = new Dclgens.COBHISVI();
        public Dclgens.CONDITEC CONDITEC { get; set; } = new Dclgens.CONDITEC();
        public Dclgens.CONMOVVG CONMOVVG { get; set; } = new Dclgens.CONMOVVG();
        public Dclgens.GECLIMOV GECLIMOV { get; set; } = new Dclgens.GECLIMOV();
        public Dclgens.ENDERECO ENDERECO { get; set; } = new Dclgens.ENDERECO();
        public Dclgens.ERRPROVI ERRPROVI { get; set; } = new Dclgens.ERRPROVI();
        public Dclgens.FAIXASAL FAIXASAL { get; set; } = new Dclgens.FAIXASAL();
        public Dclgens.FAIXAETA FAIXAETA { get; set; } = new Dclgens.FAIXAETA();
        public Dclgens.FATURCON FATURCON { get; set; } = new Dclgens.FATURCON();
        public Dclgens.FONTES FONTES { get; set; } = new Dclgens.FONTES();
        public Dclgens.HISCOBPR HISCOBPR { get; set; } = new Dclgens.HISCOBPR();
        public Dclgens.HISCONPA HISCONPA { get; set; } = new Dclgens.HISCONPA();
        public Dclgens.MOEDAS MOEDAS { get; set; } = new Dclgens.MOEDAS();
        public Dclgens.MOVIMVGA MOVIMVGA { get; set; } = new Dclgens.MOVIMVGA();
        public Dclgens.OPCPAGVI OPCPAGVI { get; set; } = new Dclgens.OPCPAGVI();
        public Dclgens.NUMEROUT NUMEROUT { get; set; } = new Dclgens.NUMEROUT();
        public Dclgens.PARAMRAM PARAMRAM { get; set; } = new Dclgens.PARAMRAM();
        public Dclgens.PLANOVGA PLANOVGA { get; set; } = new Dclgens.PLANOVGA();
        public Dclgens.PROPOVA PROPOVA { get; set; } = new Dclgens.PROPOVA();
        public Dclgens.PARCEVID PARCEVID { get; set; } = new Dclgens.PARCEVID();
        public Dclgens.RELATORI RELATORI { get; set; } = new Dclgens.RELATORI();
        public Dclgens.SEGVGAPH SEGVGAPH { get; set; } = new Dclgens.SEGVGAPH();
        public Dclgens.SEGURVGA SEGURVGA { get; set; } = new Dclgens.SEGURVGA();
        public Dclgens.APOLICOB APOLICOB { get; set; } = new Dclgens.APOLICOB();
        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.SUBGVGAP SUBGVGAP { get; set; } = new Dclgens.SUBGVGAP();
        public Dclgens.VGSEGCON VGSEGCON { get; set; } = new Dclgens.VGSEGCON();
        public Dclgens.VG083 VG083 { get; set; } = new Dclgens.VG083();
        public Dclgens.VG098 VG098 { get; set; } = new Dclgens.VG098();
        public VG1626B_CPROPOVA CPROPOVA { get; set; } = new VG1626B_CPROPOVA();
        public VG1626B_SEGURVGA1 SEGURVGA1 { get; set; } = new VG1626B_SEGURVGA1();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string VG1626BO_FILE_NAME_P, string VG1626BD_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                VG1626BO.SetFile(VG1626BO_FILE_NAME_P);
                VG1626BD.SetFile(VG1626BD_FILE_NAME_P);

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
            /*" -1115- MOVE '0000' TO WNR-EXEC-SQL. */
            _.Move("0000", FILLER_30.FILLER_40.WABEND.WNR_EXEC_SQL);

            /*" -1115- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC */

            /*" -1116- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC */

            /*" -1117- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC */

            /*" -1121- INITIALIZE TOTAIS-ROT. */
            _.Initialize(
                TOTAIS_ROT
            );

            /*" -1122- DISPLAY '------------------------------------------------' */
            _.Display($"------------------------------------------------");

            /*" -1123- DISPLAY '          PROGRAMA EM EXECUCAO VG1626B          ' */
            _.Display($"          PROGRAMA EM EXECUCAO VG1626B          ");

            /*" -1124- DISPLAY ' ' */
            _.Display($" ");

            /*" -1125- DISPLAY ' CALCULO DE VALORES DE FATURAMENTO DE APOL. ESP.' */
            _.Display($" CALCULO DE VALORES DE FATURAMENTO DE APOL. ESP.");

            /*" -1126- DISPLAY 'VERSAO V.25: ' FUNCTION WHEN-COMPILED ' - 279194' */

            $"VERSAO V.25: FUNCTION{_.WhenCompiled()} - 279194"
            .Display();

            /*" -1127- DISPLAY ' ' */
            _.Display($" ");

            /*" -1134- DISPLAY 'INICIOU PROCESSAMENTO EM ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2) */

            $"INICIOU PROCESSAMENTO EM {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
            .Display();

            /*" -1135- DISPLAY '                              ' */
            _.Display($"                              ");

            /*" -1152- DISPLAY '------------------------------------------------' */
            _.Display($"------------------------------------------------");

            /*" -1154- PERFORM R0100-00-SELECT-TSISTEMA. */

            R0100_00_SELECT_TSISTEMA_SECTION();

            /*" -1155- DISPLAY ' DATA-MOV-ABERTO ' SISTEMAS-DATA-MOV-ABERTO */
            _.Display($" DATA-MOV-ABERTO {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}");

            /*" -1157- DISPLAY '------------------------------------------------' */
            _.Display($"------------------------------------------------");

            /*" -1159- PERFORM R0150-00-VERIFICA-FATUR-CAP */

            R0150_00_VERIFICA_FATUR_CAP_SECTION();

            /*" -1161- PERFORM R0200-00-OPEN-HEADER. */

            R0200_00_OPEN_HEADER_SECTION();

            /*" -1163- PERFORM R0900-00-DECLA-PROPOVA. */

            R0900_00_DECLA_PROPOVA_SECTION();

            /*" -1165- PERFORM R0910-00-FETCH-PROPOVA. */

            R0910_00_FETCH_PROPOVA_SECTION();

            /*" -1166- IF (WFIM-MOVIMENTO EQUAL 'SIM' ) */

            if ((FILLER_30.FILLER_40.WFIM_MOVIMENTO == "SIM"))
            {

                /*" -1167- MOVE 01 TO RETURN-CODE */
                _.Move(01, RETURN_CODE);

                /*" -1168- PERFORM R9900-00-ENCERRA-SEM-MOVTO */

                R9900_00_ENCERRA_SEM_MOVTO_SECTION();

                /*" -1169- GO TO R9000-00-FINALIZA */

                R9000_00_FINALIZA_SECTION(); //GOTO
                return;

                /*" -1171- END-IF. */
            }


            /*" -1174- PERFORM R1000-00-PROCESSA-REGISTRO UNTIL WFIM-MOVIMENTO EQUAL 'SIM' . */

            while (!(FILLER_30.FILLER_40.WFIM_MOVIMENTO == "SIM"))
            {

                R1000_00_PROCESSA_REGISTRO_SECTION();
            }

            /*" -1176- PERFORM R8000-00-CLOSE-TRAILLER. */

            R8000_00_CLOSE_TRAILLER_SECTION();

            /*" -1178- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -1180- PERFORM R9000-00-FINALIZA. */

            R9000_00_FINALIZA_SECTION();

            /*" -1180- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0100-00-SELECT-TSISTEMA-SECTION */
        private void R0100_00_SELECT_TSISTEMA_SECTION()
        {
            /*" -1191- MOVE '010' TO WNR-EXEC-SQL. */
            _.Move("010", FILLER_30.FILLER_40.WABEND.WNR_EXEC_SQL);

            /*" -1199- PERFORM R0100_00_SELECT_TSISTEMA_DB_SELECT_1 */

            R0100_00_SELECT_TSISTEMA_DB_SELECT_1();

            /*" -1202- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1203- DISPLAY 'VG1626B - NAO CONSTA REGISTRO NA TSISTEMA' */
                _.Display($"VG1626B - NAO CONSTA REGISTRO NA TSISTEMA");

                /*" -1204- DISPLAY 'IDSISTEM =  VG ' */
                _.Display($"IDSISTEM =  VG ");

                /*" -1206- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1207- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1208- DISPLAY 'VG1626B - ERRO NA LEITURA NA SISTEMAS  ' */
                _.Display($"VG1626B - ERRO NA LEITURA NA SISTEMAS  ");

                /*" -1210- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1212- MOVE V1SIST-DTVENFIM-CN TO WS-DATA-CURR-MA-15 */
            _.Move(V1SIST_DTVENFIM_CN, AREAS_ARQUIVO_CAP.WS_AUXILIARES.WS_DATA_CURR_MA_15);

            /*" -1212- . */

        }

        [StopWatch]
        /*" R0100-00-SELECT-TSISTEMA-DB-SELECT-1 */
        public void R0100_00_SELECT_TSISTEMA_DB_SELECT_1()
        {
            /*" -1199- EXEC SQL SELECT DATA_MOV_ABERTO, CURRENT DATE + 15 DAYS INTO :SISTEMAS-DATA-MOV-ABERTO, :V1SIST-DTVENFIM-CN FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'VG' WITH UR END-EXEC. */

            var r0100_00_SELECT_TSISTEMA_DB_SELECT_1_Query1 = new R0100_00_SELECT_TSISTEMA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0100_00_SELECT_TSISTEMA_DB_SELECT_1_Query1.Execute(r0100_00_SELECT_TSISTEMA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);
                _.Move(executed_1.V1SIST_DTVENFIM_CN, V1SIST_DTVENFIM_CN);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/

        [StopWatch]
        /*" R0150-00-VERIFICA-FATUR-CAP-SECTION */
        private void R0150_00_VERIFICA_FATUR_CAP_SECTION()
        {
            /*" -1221- INITIALIZE DCLPROPOSTAS-VA */
            _.Initialize(
                PROPOVA.DCLPROPOSTAS_VA
            );

            /*" -1224- MOVE 108211311837 TO WS-APOLICE-CAP */
            _.Move(108211311837, AREAS_ARQUIVO_CAP.WS_AUXILIARES.WS_APOLICE_CAP);

            /*" -1236- PERFORM R0150_00_VERIFICA_FATUR_CAP_DB_SELECT_1 */

            R0150_00_VERIFICA_FATUR_CAP_DB_SELECT_1();

            /*" -1239- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -1240- MOVE 'S' TO N88-IGNORA-ARQUIVO */
                _.Move("S", AREAS_ARQUIVO_CAP.WS_AUXILIARES.N88_IGNORA_ARQUIVO);

                /*" -1244- DISPLAY ' DATA PROXIMO VCTO ...... ' WS-DIA-PRO-VCTO '/' WS-MES-PRO-VCTO '/' WS-ANO-PRO-VCTO ' (CAP)' */

                $" DATA PROXIMO VCTO ...... {AREAS_ARQUIVO_CAP.WS_AUXILIARES.FILLER_16.WS_DIA_PRO_VCTO}/{AREAS_ARQUIVO_CAP.WS_AUXILIARES.FILLER_16.WS_MES_PRO_VCTO}/{AREAS_ARQUIVO_CAP.WS_AUXILIARES.FILLER_16.WS_ANO_PRO_VCTO} (CAP)"
                .Display();

                /*" -1248- DISPLAY ' DATA PROX. VCTO - 15 D . ' WS-DIA-PRO-VCTO-15 '/' WS-MES-PRO-VCTO-15 '/' WS-ANO-PRO-VCTO-15 ' (CAP)' */

                $" DATA PROX. VCTO - 15 D . {AREAS_ARQUIVO_CAP.WS_AUXILIARES.FILLER_19.WS_DIA_PRO_VCTO_15}/{AREAS_ARQUIVO_CAP.WS_AUXILIARES.FILLER_19.WS_MES_PRO_VCTO_15}/{AREAS_ARQUIVO_CAP.WS_AUXILIARES.FILLER_19.WS_ANO_PRO_VCTO_15} (CAP)"
                .Display();

                /*" -1252- DISPLAY ' DT. CURRENT + 15 D ..... ' WS-DIA-CURR-MA-15 '/' WS-MES-CURR-MA-15 '/' WS-ANO-CURR-MA-15 ' (CAP)' */

                $" DT. CURRENT + 15 D ..... {AREAS_ARQUIVO_CAP.WS_AUXILIARES.FILLER_22.WS_DIA_CURR_MA_15}/{AREAS_ARQUIVO_CAP.WS_AUXILIARES.FILLER_22.WS_MES_CURR_MA_15}/{AREAS_ARQUIVO_CAP.WS_AUXILIARES.FILLER_22.WS_ANO_CURR_MA_15} (CAP)"
                .Display();

                /*" -1256- DISPLAY ' DT. GERACAO PROP_VA .... ' WS-DIA-GER-VA '/' WS-MES-GER-VA '/' WS-ANO-GER-VA ' (CAP)' */

                $" DT. GERACAO PROP_VA .... {AREAS_ARQUIVO_CAP.WS_AUXILIARES.FILLER_7.WS_DIA_GER_VA}/{AREAS_ARQUIVO_CAP.WS_AUXILIARES.FILLER_7.WS_MES_GER_VA}/{AREAS_ARQUIVO_CAP.WS_AUXILIARES.FILLER_7.WS_ANO_GER_VA} (CAP)"
                .Display();

                /*" -1257- ELSE */
            }
            else
            {


                /*" -1258- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, AREAS_ARQUIVO_CAP.WS_AUXILIARES.WS_SQLCODE);

                /*" -1259- DISPLAY '***' */
                _.Display($"***");

                /*" -1260- DISPLAY ' R0150-00-VERIFICA-FATUR-CAP ' */
                _.Display($" R0150-00-VERIFICA-FATUR-CAP ");

                /*" -1261- DISPLAY ' ERRO SEL PROPOSTAS_VA' WS-SQLCODE ')' */

                $" ERRO SEL PROPOSTAS_VA{AREAS_ARQUIVO_CAP.WS_AUXILIARES.WS_SQLCODE})"
                .Display();

                /*" -1262- DISPLAY '***' */
                _.Display($"***");

                /*" -1263- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1265- END-IF */
            }


            /*" -1266- MOVE WS-DIA-PRO-VCTO-15 TO PROSOCU-DIA-ENTRA */
            _.Move(AREAS_ARQUIVO_CAP.WS_AUXILIARES.FILLER_19.WS_DIA_PRO_VCTO_15, AREAS_ARQUIVO_CAP.WS_SUBROTINAS.PROSOCU_LINKAGE.FILLER_28.PROSOCU_DIA_ENTRA);

            /*" -1267- MOVE WS-MES-PRO-VCTO-15 TO PROSOCU-MES-ENTRA */
            _.Move(AREAS_ARQUIVO_CAP.WS_AUXILIARES.FILLER_19.WS_MES_PRO_VCTO_15, AREAS_ARQUIVO_CAP.WS_SUBROTINAS.PROSOCU_LINKAGE.FILLER_28.PROSOCU_MES_ENTRA);

            /*" -1268- MOVE WS-ANO-PRO-VCTO-15 TO PROSOCU-ANO-ENTRA */
            _.Move(AREAS_ARQUIVO_CAP.WS_AUXILIARES.FILLER_19.WS_ANO_PRO_VCTO_15, AREAS_ARQUIVO_CAP.WS_SUBROTINAS.PROSOCU_LINKAGE.FILLER_28.PROSOCU_ANO_ENTRA);

            /*" -1270- MOVE 'N' TO CALENDAR-FERIADO */
            _.Move("N", CALENDAR.DCLCALENDARIO.CALENDAR_FERIADO);

            /*" -1273- PERFORM R0151-00-DATA-FATURAMENTO THRU R0151-99-SAIDA UNTIL CALENDAR-FERIADO NOT EQUAL 'N' */

            while (!(CALENDAR.DCLCALENDARIO.CALENDAR_FERIADO != "N"))
            {

                R0151_00_DATA_FATURAMENTO_SECTION();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0151_99_SAIDA*/

            }

            /*" -1274- IF WS-DATA-FATUR EQUAL SISTEMAS-DATA-MOV-ABERTO */

            if (AREAS_ARQUIVO_CAP.WS_AUXILIARES.WS_DATA_FATUR == SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO)
            {

                /*" -1275- MOVE 'N' TO N88-IGNORA-ARQUIVO */
                _.Move("N", AREAS_ARQUIVO_CAP.WS_AUXILIARES.N88_IGNORA_ARQUIVO);

                /*" -1276- DISPLAY ' GERAR ARQUIVO CAP ' */
                _.Display($" GERAR ARQUIVO CAP ");

                /*" -1278- END-IF */
            }


            /*" -1278- . */

        }

        [StopWatch]
        /*" R0150-00-VERIFICA-FATUR-CAP-DB-SELECT-1 */
        public void R0150_00_VERIFICA_FATUR_CAP_DB_SELECT_1()
        {
            /*" -1236- EXEC SQL SELECT DTPROXVEN , DATA_VENCIMENTO , DTPROXVEN - 16 DAYS , DATE(TIMESTAMP) INTO :WS-DATA-PRO-VCTO , :WS-DATA-VCTO , :WS-DATA-PRO-VCTO-15 , :WS-DATA-GER-VA FROM SEGUROS.PROPOSTAS_VA WHERE NUM_APOLICE = :WS-APOLICE-CAP WITH UR END-EXEC */

            var r0150_00_VERIFICA_FATUR_CAP_DB_SELECT_1_Query1 = new R0150_00_VERIFICA_FATUR_CAP_DB_SELECT_1_Query1()
            {
                WS_APOLICE_CAP = AREAS_ARQUIVO_CAP.WS_AUXILIARES.WS_APOLICE_CAP.ToString(),
            };

            var executed_1 = R0150_00_VERIFICA_FATUR_CAP_DB_SELECT_1_Query1.Execute(r0150_00_VERIFICA_FATUR_CAP_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_DATA_PRO_VCTO, AREAS_ARQUIVO_CAP.WS_AUXILIARES.WS_DATA_PRO_VCTO);
                _.Move(executed_1.WS_DATA_VCTO, AREAS_ARQUIVO_CAP.WS_AUXILIARES.WS_DATA_VCTO);
                _.Move(executed_1.WS_DATA_PRO_VCTO_15, AREAS_ARQUIVO_CAP.WS_AUXILIARES.WS_DATA_PRO_VCTO_15);
                _.Move(executed_1.WS_DATA_GER_VA, AREAS_ARQUIVO_CAP.WS_AUXILIARES.WS_DATA_GER_VA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0150_99_SAIDA*/

        [StopWatch]
        /*" R0151-00-DATA-FATURAMENTO-SECTION */
        private void R0151_00_DATA_FATURAMENTO_SECTION()
        {
            /*" -1289- MOVE PROSOCU-DATA-ENTRA TO PROSOCU-DATA-SAIDA */
            _.Move(AREAS_ARQUIVO_CAP.WS_SUBROTINAS.PROSOCU_LINKAGE.PROSOCU_DATA_ENTRA, AREAS_ARQUIVO_CAP.WS_SUBROTINAS.PROSOCU_LINKAGE.PROSOCU_DATA_SAIDA);

            /*" -1291- CALL 'PROSOCU1' USING PROSOCU-LINKAGE */
            _.Call("PROSOCU1", AREAS_ARQUIVO_CAP.WS_SUBROTINAS.PROSOCU_LINKAGE);

            /*" -1292- MOVE PROSOCU-DIA-SAIDA TO WS-DIA-FATUR */
            _.Move(AREAS_ARQUIVO_CAP.WS_SUBROTINAS.PROSOCU_LINKAGE.FILLER_29.PROSOCU_DIA_SAIDA, AREAS_ARQUIVO_CAP.WS_AUXILIARES.FILLER_10.WS_DIA_FATUR);

            /*" -1293- MOVE PROSOCU-MES-SAIDA TO WS-MES-FATUR */
            _.Move(AREAS_ARQUIVO_CAP.WS_SUBROTINAS.PROSOCU_LINKAGE.FILLER_29.PROSOCU_MES_SAIDA, AREAS_ARQUIVO_CAP.WS_AUXILIARES.FILLER_10.WS_MES_FATUR);

            /*" -1295- MOVE PROSOCU-ANO-SAIDA TO WS-ANO-FATUR */
            _.Move(AREAS_ARQUIVO_CAP.WS_SUBROTINAS.PROSOCU_LINKAGE.FILLER_29.PROSOCU_ANO_SAIDA, AREAS_ARQUIVO_CAP.WS_AUXILIARES.FILLER_10.WS_ANO_FATUR);

            /*" -1296- INITIALIZE DCLCALENDARIO */
            _.Initialize(
                CALENDAR.DCLCALENDARIO
            );

            /*" -1304- PERFORM R0151_00_DATA_FATURAMENTO_DB_SELECT_1 */

            R0151_00_DATA_FATURAMENTO_DB_SELECT_1();

            /*" -1307- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -1308- IF CALENDAR-FERIADO EQUAL 'N' */

                if (CALENDAR.DCLCALENDARIO.CALENDAR_FERIADO == "N")
                {

                    /*" -1312- DISPLAY ' DATA RECUSADA (N UTIL).. ' WS-DATA-FATUR '/' CALENDAR-DIA-SEMANA '/' CALENDAR-FERIADO ' (CAP)' */

                    $" DATA RECUSADA (N UTIL).. {AREAS_ARQUIVO_CAP.WS_AUXILIARES.WS_DATA_FATUR}/{CALENDAR.DCLCALENDARIO.CALENDAR_DIA_SEMANA}/{CALENDAR.DCLCALENDARIO.CALENDAR_FERIADO} (CAP)"
                    .Display();

                    /*" -1313- MOVE PROSOCU-DATA-SAIDA TO PROSOCU-DATA-ENTRA */
                    _.Move(AREAS_ARQUIVO_CAP.WS_SUBROTINAS.PROSOCU_LINKAGE.PROSOCU_DATA_SAIDA, AREAS_ARQUIVO_CAP.WS_SUBROTINAS.PROSOCU_LINKAGE.PROSOCU_DATA_ENTRA);

                    /*" -1314- ELSE */
                }
                else
                {


                    /*" -1316- DISPLAY ' DATA DE FATURAMENTO .... ' WS-DATA-FATUR ' (CAP)' */

                    $" DATA DE FATURAMENTO .... {AREAS_ARQUIVO_CAP.WS_AUXILIARES.WS_DATA_FATUR} (CAP)"
                    .Display();

                    /*" -1317- END-IF */
                }


                /*" -1318- ELSE */
            }
            else
            {


                /*" -1319- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, AREAS_ARQUIVO_CAP.WS_AUXILIARES.WS_SQLCODE);

                /*" -1320- DISPLAY '***' */
                _.Display($"***");

                /*" -1321- DISPLAY ' R0151-00-DATA-FATURAMENTO  ' */
                _.Display($" R0151-00-DATA-FATURAMENTO  ");

                /*" -1322- DISPLAY ' ERRO SEL CALENDARIO  ' WS-SQLCODE ')' */

                $" ERRO SEL CALENDARIO  {AREAS_ARQUIVO_CAP.WS_AUXILIARES.WS_SQLCODE})"
                .Display();

                /*" -1323- DISPLAY '***' */
                _.Display($"***");

                /*" -1324- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1326- END-IF */
            }


            /*" -1326- . */

        }

        [StopWatch]
        /*" R0151-00-DATA-FATURAMENTO-DB-SELECT-1 */
        public void R0151_00_DATA_FATURAMENTO_DB_SELECT_1()
        {
            /*" -1304- EXEC SQL SELECT DIA_SEMANA , FERIADO INTO :CALENDAR-DIA-SEMANA , :CALENDAR-FERIADO FROM SEGUROS.CALENDARIO WHERE DATA_CALENDARIO = :WS-DATA-FATUR WITH UR END-EXEC */

            var r0151_00_DATA_FATURAMENTO_DB_SELECT_1_Query1 = new R0151_00_DATA_FATURAMENTO_DB_SELECT_1_Query1()
            {
                WS_DATA_FATUR = AREAS_ARQUIVO_CAP.WS_AUXILIARES.WS_DATA_FATUR.ToString(),
            };

            var executed_1 = R0151_00_DATA_FATURAMENTO_DB_SELECT_1_Query1.Execute(r0151_00_DATA_FATURAMENTO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CALENDAR_DIA_SEMANA, CALENDAR.DCLCALENDARIO.CALENDAR_DIA_SEMANA);
                _.Move(executed_1.CALENDAR_FERIADO, CALENDAR.DCLCALENDARIO.CALENDAR_FERIADO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0151_99_SAIDA*/

        [StopWatch]
        /*" R0200-00-OPEN-HEADER-SECTION */
        private void R0200_00_OPEN_HEADER_SECTION()
        {
            /*" -1336- OPEN OUTPUT VG1626BO VG1626BD */
            VG1626BO.Open(VG1626BO_HEADER, WS_NIVEIS_88.N88_VG1626BO_STATUS);
            VG1626BD.Open(VG1626BD_REGISTRO, WS_NIVEIS_88.N88_VG1626BD_STATUS);

            /*" -1337- MOVE SPACES TO VG1626BO-HEADER */
            _.Move("", VG1626BO_HEADER);

            /*" -1338- MOVE 001 TO VG1626BO-H-TIP-REG */
            _.Move(001, VG1626BO_HEADER.VG1626BO_H_TIP_REG);

            /*" -1339- ADD 001 TO AC-SEQ-REG-ARQ */
            FILLER_30.AC_SEQ_REG_ARQ.Value = FILLER_30.AC_SEQ_REG_ARQ + 001;

            /*" -1340- MOVE AC-SEQ-REG-ARQ TO VG1626BO-H-SEQ-REG */
            _.Move(FILLER_30.AC_SEQ_REG_ARQ, VG1626BO_HEADER.VG1626BO_H_SEQ_REG);

            /*" -1341- MOVE SISTEMAS-DATA-MOV-ABERTO TO VG1626BO-H-DAT-COR */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, VG1626BO_HEADER.VG1626BO_H_DAT_COR);

            /*" -1342- MOVE 108211311837 TO VG1626BO-H-NUM-APO */
            _.Move(108211311837, VG1626BO_HEADER.VG1626BO_H_NUM_APO);

            /*" -1343- MOVE ZEROS TO VG1626BO-H-NUM-PAR */
            _.Move(0, VG1626BO_HEADER.VG1626BO_H_NUM_PAR);

            /*" -1344- MOVE '0000-00-00' TO VG1626BO-H-DAT-VCT */
            _.Move("0000-00-00", VG1626BO_HEADER.VG1626BO_H_DAT_VCT);

            /*" -1346- MOVE VG1626BO-HEADER TO VG1626BD-REGISTRO */
            _.Move(VG1626BO?.Value, VG1626BD_REGISTRO);

            /*" -1348- WRITE VG1626BO-HEADER */
            VG1626BO.Write(VG1626BO_HEADER.GetMoveValues().ToString());

            /*" -1349- IF VG1626BO-NORMAL */

            if (WS_NIVEIS_88.N88_VG1626BO_STATUS["VG1626BO_NORMAL"])
            {

                /*" -1350- ADD 001 TO AC-VG1626BO-GRV */
                FILLER_30.AC_VG1626BO_GRV.Value = FILLER_30.AC_VG1626BO_GRV + 001;

                /*" -1351- ELSE */
            }
            else
            {


                /*" -1352- DISPLAY '***' */
                _.Display($"***");

                /*" -1353- DISPLAY ' R0200-00-OPEN-HEADER   ' */
                _.Display($" R0200-00-OPEN-HEADER   ");

                /*" -1354- DISPLAY ' ERRO WRITE VG1626BO ST = ' N88-VG1626BO-STATUS */
                _.Display($" ERRO WRITE VG1626BO ST = {WS_NIVEIS_88.N88_VG1626BO_STATUS}");

                /*" -1355- DISPLAY '***' */
                _.Display($"***");

                /*" -1356- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1358- END-IF */
            }


            /*" -1360- WRITE VG1626BD-REGISTRO */
            VG1626BD.Write(VG1626BD_REGISTRO.GetMoveValues().ToString());

            /*" -1361- IF VG1626BD-NORMAL */

            if (WS_NIVEIS_88.N88_VG1626BD_STATUS["VG1626BD_NORMAL"])
            {

                /*" -1362- ADD 001 TO AC-VG1626BD-GRV */
                FILLER_30.AC_VG1626BD_GRV.Value = FILLER_30.AC_VG1626BD_GRV + 001;

                /*" -1363- ELSE */
            }
            else
            {


                /*" -1364- DISPLAY '***' */
                _.Display($"***");

                /*" -1365- DISPLAY ' R0200-00-OPEN-HEADER   ' */
                _.Display($" R0200-00-OPEN-HEADER   ");

                /*" -1366- DISPLAY ' ERRO WRITE VG1626BD ST = ' N88-VG1626BD-STATUS */
                _.Display($" ERRO WRITE VG1626BD ST = {WS_NIVEIS_88.N88_VG1626BD_STATUS}");

                /*" -1367- DISPLAY '***' */
                _.Display($"***");

                /*" -1368- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1370- END-IF */
            }


            /*" -1370- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_99_SAIDA*/

        [StopWatch]
        /*" R0900-00-DECLA-PROPOVA-SECTION */
        private void R0900_00_DECLA_PROPOVA_SECTION()
        {
            /*" -1381- MOVE 'R0900-00-DECLA-PROPOVA ' TO PARAGRAFO. */
            _.Move("R0900-00-DECLA-PROPOVA ", FILLER_30.FILLER_40.WABEND.PARAGRAFO);

            /*" -1383- MOVE 'A003' TO WNR-EXEC-SQL. */
            _.Move("A003", FILLER_30.FILLER_40.WABEND.WNR_EXEC_SQL);

            /*" -1388- PERFORM R0900_00_DECLA_PROPOVA_DB_SELECT_1 */

            R0900_00_DECLA_PROPOVA_DB_SELECT_1();

            /*" -1391- MOVE '0900' TO WNR-EXEC-SQL. */
            _.Move("0900", FILLER_30.FILLER_40.WABEND.WNR_EXEC_SQL);

            /*" -1411- PERFORM R0900_00_DECLA_PROPOVA_DB_DECLARE_1 */

            R0900_00_DECLA_PROPOVA_DB_DECLARE_1();

            /*" -1415- DISPLAY '*** VG1626B *** ABRINDO CURSOR ...' . */
            _.Display($"*** VG1626B *** ABRINDO CURSOR ...");

            /*" -1415- PERFORM R0900_00_DECLA_PROPOVA_DB_OPEN_1 */

            R0900_00_DECLA_PROPOVA_DB_OPEN_1();

            /*" -1420- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1421- DISPLAY 'PROBLEMAS NO OPEN (CPROPOVA) ... ' */
                _.Display($"PROBLEMAS NO OPEN (CPROPOVA) ... ");

                /*" -1421- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0900-00-DECLA-PROPOVA-DB-SELECT-1 */
        public void R0900_00_DECLA_PROPOVA_DB_SELECT_1()
        {
            /*" -1388- EXEC SQL SELECT VALUE(MIN(DTPROXVEN),DATE( '1999-12-31' )) INTO :WHOST-MIN-DTPROXVEN FROM SEGUROS.V0PROPOSTAVA WHERE SITUACAO IN ( '3' , '6' ) END-EXEC. */

            var r0900_00_DECLA_PROPOVA_DB_SELECT_1_Query1 = new R0900_00_DECLA_PROPOVA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0900_00_DECLA_PROPOVA_DB_SELECT_1_Query1.Execute(r0900_00_DECLA_PROPOVA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_MIN_DTPROXVEN, WHOST_MIN_DTPROXVEN);
            }


        }

        [StopWatch]
        /*" R0900-00-DECLA-PROPOVA-DB-DECLARE-1 */
        public void R0900_00_DECLA_PROPOVA_DB_DECLARE_1()
        {
            /*" -1411- EXEC SQL DECLARE CPROPOVA CURSOR WITH HOLD FOR SELECT A.NUM_CERTIFICADO , A.NUM_APOLICE, A.COD_SUBGRUPO, A.NUM_PARCELA, A.OCORR_HISTORICO, A.DTPROXVEN FROM SEGUROS.PROPOSTAS_VA A, SEGUROS.PRODUTOS_VG B WHERE B.ORIG_PRODU = 'ESPEC' AND A.NUM_APOLICE = B.NUM_APOLICE AND A.NUM_APOLICE NOT IN (109300000635, 107700000007, 108210871143) AND A.COD_SUBGRUPO = B.COD_SUBGRUPO AND A.SIT_REGISTRO IN ( '3' , '6' ) AND A.DTPROXVEN <> '9999-12-31' ORDER BY A.NUM_APOLICE, A.COD_SUBGRUPO, A.NUM_CERTIFICADO END-EXEC. */
            CPROPOVA = new VG1626B_CPROPOVA(false);
            string GetQuery_CPROPOVA()
            {
                var query = @$"SELECT A.NUM_CERTIFICADO
							, 
							A.NUM_APOLICE
							, 
							A.COD_SUBGRUPO
							, 
							A.NUM_PARCELA
							, 
							A.OCORR_HISTORICO
							, 
							A.DTPROXVEN 
							FROM SEGUROS.PROPOSTAS_VA A
							, 
							SEGUROS.PRODUTOS_VG B 
							WHERE B.ORIG_PRODU = 'ESPEC' 
							AND A.NUM_APOLICE = B.NUM_APOLICE 
							AND A.NUM_APOLICE NOT IN (109300000635
							, 
							107700000007
							, 
							108210871143) 
							AND A.COD_SUBGRUPO = B.COD_SUBGRUPO 
							AND A.SIT_REGISTRO IN ( '3'
							, '6' ) 
							AND A.DTPROXVEN <> '9999-12-31' 
							ORDER BY A.NUM_APOLICE
							, A.COD_SUBGRUPO
							, 
							A.NUM_CERTIFICADO";

                return query;
            }
            CPROPOVA.GetQueryEvent += GetQuery_CPROPOVA;

        }

        [StopWatch]
        /*" R0900-00-DECLA-PROPOVA-DB-OPEN-1 */
        public void R0900_00_DECLA_PROPOVA_DB_OPEN_1()
        {
            /*" -1415- EXEC SQL OPEN CPROPOVA END-EXEC. */

            CPROPOVA.Open();

        }

        [StopWatch]
        /*" R2100-00-DECLARE-SEGURVGA-DB-DECLARE-1 */
        public void R2100_00_DECLARE_SEGURVGA_DB_DECLARE_1()
        {
            /*" -1925- EXEC SQL DECLARE SEGURVGA1 CURSOR FOR SELECT NUM_CERTIFICADO , COD_SUBGRUPO , NUM_ITEM , COD_CLIENTE , OCORR_HISTORICO FROM SEGUROS.SEGURADOS_VGAP WHERE NUM_APOLICE = :PROPOVA-NUM-APOLICE AND COD_SUBGRUPO BETWEEN :WHOST-COD-SUBGRUPO-I AND :WHOST-COD-SUBGRUPO-F AND SIT_REGISTRO IN ( '0' , '1' ) AND COD_PROFISSAO = 9999 WITH UR END-EXEC. */
            SEGURVGA1 = new VG1626B_SEGURVGA1(true);
            string GetQuery_SEGURVGA1()
            {
                var query = @$"SELECT NUM_CERTIFICADO
							, 
							COD_SUBGRUPO
							, 
							NUM_ITEM
							, 
							COD_CLIENTE
							, 
							OCORR_HISTORICO 
							FROM SEGUROS.SEGURADOS_VGAP 
							WHERE NUM_APOLICE = '{PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE}' 
							AND COD_SUBGRUPO BETWEEN '{WHOST_COD_SUBGRUPO_I}' 
							AND '{WHOST_COD_SUBGRUPO_F}' 
							AND SIT_REGISTRO IN ( '0'
							, '1' ) 
							AND COD_PROFISSAO = 9999";

                return query;
            }
            SEGURVGA1.GetQueryEvent += GetQuery_SEGURVGA1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0900_99_SAIDA*/

        [StopWatch]
        /*" R0910-00-FETCH-PROPOVA-SECTION */
        private void R0910_00_FETCH_PROPOVA_SECTION()
        {
            /*" -1431- MOVE 'R0910-00-FETCH-PROPOVA' TO PARAGRAFO. */
            _.Move("R0910-00-FETCH-PROPOVA", FILLER_30.FILLER_40.WABEND.PARAGRAFO);

            /*" -1433- MOVE '0910' TO WNR-EXEC-SQL. */
            _.Move("0910", FILLER_30.FILLER_40.WABEND.WNR_EXEC_SQL);

            /*" -1440- PERFORM R0910_00_FETCH_PROPOVA_DB_FETCH_1 */

            R0910_00_FETCH_PROPOVA_DB_FETCH_1();

            /*" -1443- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1444- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1444- PERFORM R0910_00_FETCH_PROPOVA_DB_CLOSE_1 */

                    R0910_00_FETCH_PROPOVA_DB_CLOSE_1();

                    /*" -1446- MOVE 'SIM' TO WFIM-MOVIMENTO */
                    _.Move("SIM", FILLER_30.FILLER_40.WFIM_MOVIMENTO);

                    /*" -1447- GO TO R0910-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/ //GOTO
                    return;

                    /*" -1448- ELSE */
                }
                else
                {


                    /*" -1449- DISPLAY 'R0910-00 (ERRO -  FETCH CPROPOVA).. ' */
                    _.Display($"R0910-00 (ERRO -  FETCH CPROPOVA).. ");

                    /*" -1451- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -1454- ADD 1 TO AC-LIDOS AC-LIDOS-M. */
            FILLER_30.AC_LIDOS.Value = FILLER_30.AC_LIDOS + 1;
            FILLER_30.AC_LIDOS_M.Value = FILLER_30.AC_LIDOS_M + 1;

            /*" -1455- IF (AC-LIDOS GREATER 99) */

            if ((FILLER_30.AC_LIDOS > 99))
            {

                /*" -1456- MOVE ZEROS TO AC-LIDOS */
                _.Move(0, FILLER_30.AC_LIDOS);

                /*" -1458- ACCEPT WS-TIME FROM TIME */
                _.Move(_.AcceptDate("TIME"), FILLER_30.WS_TIME);

                /*" -1462- DISPLAY 'LIDOS MOVIMENTO ' AC-LIDOS-M ' ' WS-TIME ' --> ' PROPOVA-NUM-APOLICE ' - ' WHOST-COD-SUBGRUPO ' - ' PROPOVA-NUM-CERTIFICADO */

                $"LIDOS MOVIMENTO {FILLER_30.AC_LIDOS_M} {FILLER_30.WS_TIME} --> {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE} - {WHOST_COD_SUBGRUPO} - {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}"
                .Display();

                /*" -1462- EXEC SQL COMMIT WORK END-EXEC */

                DatabaseConnection.Instance.CommitTransaction();

                /*" -1463- END-IF. */
            }


        }

        [StopWatch]
        /*" R0910-00-FETCH-PROPOVA-DB-FETCH-1 */
        public void R0910_00_FETCH_PROPOVA_DB_FETCH_1()
        {
            /*" -1440- EXEC SQL FETCH CPROPOVA INTO :PROPOVA-NUM-CERTIFICADO, :PROPOVA-NUM-APOLICE, :PROPOVA-COD-SUBGRUPO, :PROPOVA-NUM-PARCELA, :PROPOVA-OCORR-HISTORICO, :PROPOVA-DTPROXVEN END-EXEC. */

            if (CPROPOVA.Fetch())
            {
                _.Move(CPROPOVA.PROPOVA_NUM_CERTIFICADO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO);
                _.Move(CPROPOVA.PROPOVA_NUM_APOLICE, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE);
                _.Move(CPROPOVA.PROPOVA_COD_SUBGRUPO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_SUBGRUPO);
                _.Move(CPROPOVA.PROPOVA_NUM_PARCELA, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_PARCELA);
                _.Move(CPROPOVA.PROPOVA_OCORR_HISTORICO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_OCORR_HISTORICO);
                _.Move(CPROPOVA.PROPOVA_DTPROXVEN, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DTPROXVEN);
            }

        }

        [StopWatch]
        /*" R0910-00-FETCH-PROPOVA-DB-CLOSE-1 */
        public void R0910_00_FETCH_PROPOVA_DB_CLOSE_1()
        {
            /*" -1444- EXEC SQL CLOSE CPROPOVA END-EXEC */

            CPROPOVA.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-SECTION */
        private void R1000_00_PROCESSA_REGISTRO_SECTION()
        {
            /*" -1472- MOVE 'R1000-00-PROCESSA-REGISTRO' TO PARAGRAFO. */
            _.Move("R1000-00-PROCESSA-REGISTRO", FILLER_30.FILLER_40.WABEND.PARAGRAFO);

            /*" -1474- MOVE '1000' TO WNR-EXEC-SQL. */
            _.Move("1000", FILLER_30.FILLER_40.WABEND.WNR_EXEC_SQL);

            /*" -1485- PERFORM R2200-00-SELECT-SUBGVGAP. */

            R2200_00_SELECT_SUBGVGAP_SECTION();

            /*" -1486- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -1487- IF SUBGVGAP-FORMA-FATURAMENTO EQUAL '1' */

                if (SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_FORMA_FATURAMENTO == "1")
                {

                    /*" -1488- ADD 1 TO AC-DESPREZ-FAT-MANU */
                    FILLER_30.AC_DESPREZ_FAT_MANU.Value = FILLER_30.AC_DESPREZ_FAT_MANU + 1;

                    /*" -1489- GO TO R1000-10-NEXT */

                    R1000_10_NEXT(); //GOTO
                    return;

                    /*" -1490- END-IF */
                }


                /*" -1492- END-IF. */
            }


            /*" -1493- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -1494- IF SUBGVGAP-TIPO-FATURAMENTO EQUAL '3' */

                if (SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_TIPO_FATURAMENTO == "3")
                {

                    /*" -1495- ADD 1 TO AC-DESPREZ-FAT-RESU */
                    FILLER_30.AC_DESPREZ_FAT_RESU.Value = FILLER_30.AC_DESPREZ_FAT_RESU + 1;

                    /*" -1496- GO TO R1000-10-NEXT */

                    R1000_10_NEXT(); //GOTO
                    return;

                    /*" -1497- END-IF */
                }


                /*" -1499- END-IF. */
            }


            /*" -1500- IF (PROPOVA-COD-SUBGRUPO EQUAL 0) */

            if ((PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_SUBGRUPO == 0))
            {

                /*" -1502- MOVE 1 TO WHOST-COD-SUBGRUPO WHOST-COD-SUBGRUPO-I */
                _.Move(1, WHOST_COD_SUBGRUPO, WHOST_COD_SUBGRUPO_I);

                /*" -1503- MOVE 32767 TO WHOST-COD-SUBGRUPO-F */
                _.Move(32767, WHOST_COD_SUBGRUPO_F);

                /*" -1504- ELSE */
            }
            else
            {


                /*" -1507- MOVE PROPOVA-COD-SUBGRUPO TO WHOST-COD-SUBGRUPO WHOST-COD-SUBGRUPO-I WHOST-COD-SUBGRUPO-F */
                _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_SUBGRUPO, WHOST_COD_SUBGRUPO, WHOST_COD_SUBGRUPO_I, WHOST_COD_SUBGRUPO_F);

                /*" -1510- END-IF. */
            }


            /*" -1520- PERFORM R1000_00_PROCESSA_REGISTRO_DB_SELECT_1 */

            R1000_00_PROCESSA_REGISTRO_DB_SELECT_1();

            /*" -1523- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1524- GO TO R1000-10-NEXT */

                R1000_10_NEXT(); //GOTO
                return;

                /*" -1526- END-IF. */
            }


            /*" -1527- IF PROPOVA-NUM-APOLICE NOT EQUAL WS-NUM-APOLICE-ANT */

            if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE != FILLER_30.WS_NUM_APOLICE_ANT)
            {

                /*" -1528- PERFORM R2150-00-SELECT-APOLICES */

                R2150_00_SELECT_APOLICES_SECTION();

                /*" -1530- END-IF. */
            }


            /*" -1532- MOVE '1010' TO WNR-EXEC-SQL. */
            _.Move("1010", FILLER_30.FILLER_40.WABEND.WNR_EXEC_SQL);

            /*" -1548- PERFORM R1000_00_PROCESSA_REGISTRO_DB_SELECT_2 */

            R1000_00_PROCESSA_REGISTRO_DB_SELECT_2();

            /*" -1551- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1552- GO TO R1000-10-NEXT */

                R1000_10_NEXT(); //GOTO
                return;

                /*" -1576- END-IF. */
            }


            /*" -1578- MOVE '1020' TO WNR-EXEC-SQL. */
            _.Move("1020", FILLER_30.FILLER_40.WABEND.WNR_EXEC_SQL);

            /*" -1596- PERFORM R1000_00_PROCESSA_REGISTRO_DB_SELECT_3 */

            R1000_00_PROCESSA_REGISTRO_DB_SELECT_3();

            /*" -1599- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1600- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1601- MOVE '102A' TO WNR-EXEC-SQL */
                    _.Move("102A", FILLER_30.FILLER_40.WABEND.WNR_EXEC_SQL);

                    /*" -1613- PERFORM R1000_00_PROCESSA_REGISTRO_DB_SELECT_4 */

                    R1000_00_PROCESSA_REGISTRO_DB_SELECT_4();

                    /*" -1615- IF SQLCODE NOT EQUAL ZEROS */

                    if (DB.SQLCODE != 00)
                    {

                        /*" -1616- GO TO R1000-10-NEXT */

                        R1000_10_NEXT(); //GOTO
                        return;

                        /*" -1617- ELSE */
                    }
                    else
                    {


                        /*" -1618- IF PROPOVA-OCORR-HISTORICO EQUAL ZEROS */

                        if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_OCORR_HISTORICO == 00)
                        {

                            /*" -1619- GO TO R1000-10-NEXT */

                            R1000_10_NEXT(); //GOTO
                            return;

                            /*" -1620- ELSE */
                        }
                        else
                        {


                            /*" -1621- GO TO R1000-05-DELETE */

                            R1000_05_DELETE(); //GOTO
                            return;

                            /*" -1622- END-IF */
                        }


                        /*" -1623- END-IF */
                    }


                    /*" -1624- ELSE */
                }
                else
                {


                    /*" -1625- GO TO R1000-10-NEXT */

                    R1000_10_NEXT(); //GOTO
                    return;

                    /*" -1626- END-IF */
                }


                /*" -1649- END-IF. */
            }


            /*" -1650- IF (WHOST-DATA-HISCOBPR GREATER WHOST-DATA-MOVIMVGA) */

            if ((WHOST_DATA_HISCOBPR > WHOST_DATA_MOVIMVGA))
            {

                /*" -1651- ADD 1 TO AC-JAH-PROCESSADO */
                FILLER_30.AC_JAH_PROCESSADO.Value = FILLER_30.AC_JAH_PROCESSADO + 1;

                /*" -1652- GO TO R1000-10-NEXT */

                R1000_10_NEXT(); //GOTO
                return;

                /*" -1652- END-IF. */
            }


            /*" -0- FLUXCONTROL_PERFORM R1000_05_DELETE */

            R1000_05_DELETE();

        }

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-DB-SELECT-1 */
        public void R1000_00_PROCESSA_REGISTRO_DB_SELECT_1()
        {
            /*" -1520- EXEC SQL SELECT VALUE(MAX(DATA_OPERACAO),DATE( '0001-12-31' )) INTO :WHOST-DATA-MOVIMVGA FROM SEGUROS.MOVIMENTO_VGAP WHERE NUM_APOLICE = :PROPOVA-NUM-APOLICE AND COD_SUBGRUPO BETWEEN :WHOST-COD-SUBGRUPO-I AND :WHOST-COD-SUBGRUPO-F END-EXEC. */

            var r1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1 = new R1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1()
            {
                WHOST_COD_SUBGRUPO_I = WHOST_COD_SUBGRUPO_I.ToString(),
                WHOST_COD_SUBGRUPO_F = WHOST_COD_SUBGRUPO_F.ToString(),
                PROPOVA_NUM_APOLICE = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE.ToString(),
            };

            var executed_1 = R1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1.Execute(r1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_DATA_MOVIMVGA, WHOST_DATA_MOVIMVGA);
            }


        }

        [StopWatch]
        /*" R1000-05-DELETE */
        private void R1000_05_DELETE(bool isPerform = false)
        {
            /*" -1659- MOVE '1021' TO WNR-EXEC-SQL. */
            _.Move("1021", FILLER_30.FILLER_40.WABEND.WNR_EXEC_SQL);

            /*" -1664- PERFORM R1000_05_DELETE_DB_DELETE_1 */

            R1000_05_DELETE_DB_DELETE_1();

            /*" -1669- IF SQLCODE EQUAL ZEROS OR SQLCODE EQUAL -811 NEXT SENTENCE */

            if (DB.SQLCODE == 00 || DB.SQLCODE == -811)
            {

                /*" -1670- ELSE */
            }
            else
            {


                /*" -1672- IF SQLCODE EQUAL 100 NEXT SENTENCE */

                if (DB.SQLCODE == 100)
                {

                    /*" -1673- ELSE */
                }
                else
                {


                    /*" -1675- DISPLAY 'ERRO  DELETE DA HIS_COBER_PROPOST ' ' ' PROPOVA-NUM-CERTIFICADO ' ' WHOST-NUM-PARCELA-DEL */

                    $"ERRO  DELETE DA HIS_COBER_PROPOST  {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO} {WHOST_NUM_PARCELA_DEL}"
                    .Display();

                    /*" -1676- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1677- END-IF */
                }


                /*" -1679- END-IF. */
            }


            /*" -1681- MOVE '1022' TO WNR-EXEC-SQL. */
            _.Move("1022", FILLER_30.FILLER_40.WABEND.WNR_EXEC_SQL);

            /*" -1686- PERFORM R1000_05_DELETE_DB_UPDATE_1 */

            R1000_05_DELETE_DB_UPDATE_1();

            /*" -1690- IF SQLCODE EQUAL ZEROS NEXT SENTENCE */

            if (DB.SQLCODE == 00)
            {

                /*" -1691- ELSE */
            }
            else
            {


                /*" -1693- DISPLAY 'ERRO  UPDATE   NA HIS_COBER_PROPOST ' ' ' PROPOVA-NUM-CERTIFICADO ' ' PROPOVA-OCORR-HISTORICO */

                $"ERRO  UPDATE   NA HIS_COBER_PROPOST  {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO} {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_OCORR_HISTORICO}"
                .Display();

                /*" -1694- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1696- END-IF. */
            }


            /*" -1703- PERFORM R1000_05_DELETE_DB_UPDATE_2 */

            R1000_05_DELETE_DB_UPDATE_2();

            /*" -1706- MOVE '120A' TO WNR-EXEC-SQL. */
            _.Move("120A", FILLER_30.FILLER_40.WABEND.WNR_EXEC_SQL);

            /*" -1707- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1709- DISPLAY 'ERRO  DE ACESSO A PROPOSTAS_VA ' PROPOVA-NUM-CERTIFICADO */
                _.Display($"ERRO  DE ACESSO A PROPOSTAS_VA {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                /*" -1712- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1715- IF (PROPOVA-DTPROXVEN NOT LESS WHOST-MIN-DTPROXVEN) NEXT SENTENCE */

            if ((PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DTPROXVEN >= WHOST_MIN_DTPROXVEN))
            {

                /*" -1716- ELSE */
            }
            else
            {


                /*" -1717- GO TO R1000-10-NEXT */

                R1000_10_NEXT(); //GOTO
                return;

                /*" -1719- END-IF. */
            }


            /*" -1721- PERFORM R2200-00-SELECT-SUBGVGAP. */

            R2200_00_SELECT_SUBGVGAP_SECTION();

            /*" -1723- PERFORM R2210-00-SELECT-VIGENCFAT. */

            R2210_00_SELECT_VIGENCFAT_SECTION();

            /*" -1724- MOVE 'NAO' TO WTEM-RELATORIO. */
            _.Move("NAO", FILLER_30.FILLER_40.WTEM_RELATORIO);

            /*" -1726- PERFORM R2300-00-SELECT-COBERPROPVA. */

            R2300_00_SELECT_COBERPROPVA_SECTION();

            /*" -1727- IF (WS-COBERPROPVA EQUAL 'N' ) */

            if ((WS_COBERPROPVA == "N"))
            {

                /*" -1728- GO TO R1000-10-NEXT */

                R1000_10_NEXT(); //GOTO
                return;

                /*" -1748- END-IF. */
            }


            /*" -1749- PERFORM R2100-00-DECLARE-SEGURVGA */

            R2100_00_DECLARE_SEGURVGA_SECTION();

            /*" -1751- PERFORM R2120-00-FETCH-SEGURVGA */

            R2120_00_FETCH_SEGURVGA_SECTION();

            /*" -1754- MOVE ZEROS TO WHOST-PRMVG WHOST-IMPSEG WHOST-QTDSEG */
            _.Move(0, WHOST_PRMVG, WHOST_IMPSEG, WHOST_QTDSEG);

            /*" -1755- IF (WFIM-SEGURVGA EQUAL 'NAO' ) */

            if ((FILLER_30.FILLER_40.WFIM_SEGURVGA == "NAO"))
            {

                /*" -1757- PERFORM R2130-00-ACUMULA-IS UNTIL WFIM-SEGURVGA EQUAL 'SIM' */

                while (!(FILLER_30.FILLER_40.WFIM_SEGURVGA == "SIM"))
                {

                    R2130_00_ACUMULA_IS_SECTION();
                }

                /*" -1758- ELSE */
            }
            else
            {


                /*" -1759- GO TO R1000-10-NEXT */

                R1000_10_NEXT(); //GOTO
                return;

                /*" -1761- END-IF. */
            }


            /*" -1762- IF (WTEM-VIGENCFAT EQUAL 'NAO' ) */

            if ((FILLER_30.FILLER_40.WTEM_VIGENCFAT == "NAO"))
            {

                /*" -1763- IF (HISCOBPR-VLPREMIO EQUAL WHOST-PRMVG) */

                if ((HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_VLPREMIO == WHOST_PRMVG))
                {

                    /*" -1764- ADD 1 TO AC-PREMIO-IGUAL */
                    FILLER_30.AC_PREMIO_IGUAL.Value = FILLER_30.AC_PREMIO_IGUAL + 1;

                    /*" -1765- GO TO R1000-10-NEXT */

                    R1000_10_NEXT(); //GOTO
                    return;

                    /*" -1772- END-IF */
                }


                /*" -1783- IF (WHOST-DATA-INIVIGENCIA(1:7) >= HISCOBPR-DATA-INIVIGENCIA(1:7)) */

                if ((WHOST_DATA_INIVIGENCIA.Substring(1, 7) >= HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_DATA_INIVIGENCIA.Substring(1, 7)))
                {

                    /*" -1785- IF (WHOST-DATA-VENCIMENTO(1:7) >= HISCOBPR-DATA-INIVIGENCIA(1:7)) */

                    if ((WHOST_DATA_VENCIMENTO.Substring(1, 7) >= HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_DATA_INIVIGENCIA.Substring(1, 7)))
                    {

                        /*" -1787- MOVE PROPOVA-DTPROXVEN TO WHOST-DATA-INIVIGENCIA-1 */
                        _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DTPROXVEN, WHOST_DATA_INIVIGENCIA_1);

                        /*" -1791- MOVE HISCOBPR-DATA-INIVIGENCIA(9:2) TO WHOST-DATA-INIVIGENCIA-1(9:2) WHOST-DIA-INIVIGENCIA-1 */
                        _.MoveAtPosition(HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_DATA_INIVIGENCIA.Substring(9, 2), WHOST_DATA_INIVIGENCIA_1, 9, 2, WHOST_DIA_INIVIGENCIA_1);

                        /*" -1792- IF (WHOST-DIA-INIVIGENCIA-1 > 28) */

                        if ((WHOST_DIA_INIVIGENCIA_1 > 28))
                        {

                            /*" -1794- MOVE 'NAO' TO WS-FIM-VALIDA-DATA */
                            _.Move("NAO", FILLER_30.FILLER_40.WS_FIM_VALIDA_DATA);

                            /*" -1796- PERFORM R2310-VALIDA-DT-INIVIGENCIA UNTIL WS-FIM-VALIDA-DATA EQUAL 'SIM' */

                            while (!(FILLER_30.FILLER_40.WS_FIM_VALIDA_DATA == "SIM"))
                            {

                                R2310_VALIDA_DT_INIVIGENCIA_SECTION();
                            }

                            /*" -1797- ELSE */
                        }
                        else
                        {


                            /*" -1799- MOVE WHOST-DATA-INIVIGENCIA-1 TO WHOST-DATA-INIVIGENCIA */
                            _.Move(WHOST_DATA_INIVIGENCIA_1, WHOST_DATA_INIVIGENCIA);

                            /*" -1800- END-IF */
                        }


                        /*" -1801- ELSE */
                    }
                    else
                    {


                        /*" -1803- IF (WHOST-DATA-INIVIGENCIA(1:7) EQUAL HISCOBPR-DATA-INIVIGENCIA(1:7)) */

                        if ((WHOST_DATA_INIVIGENCIA.Substring(1, 7) == HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_DATA_INIVIGENCIA.Substring(1, 7)))
                        {

                            /*" -1804- ADD 1 TO AC-PREMIO-AJUSTADO */
                            FILLER_30.AC_PREMIO_AJUSTADO.Value = FILLER_30.AC_PREMIO_AJUSTADO + 1;

                            /*" -1805- PERFORM R3100-00-UPDATE-COBERPROPVA */

                            R3100_00_UPDATE_COBERPROPVA_SECTION();

                            /*" -1806- GO TO R1000-10-NEXT */

                            R1000_10_NEXT(); //GOTO
                            return;

                            /*" -1807- END-IF */
                        }


                        /*" -1808- END-IF */
                    }


                    /*" -1809- ELSE */
                }
                else
                {


                    /*" -1811- MOVE HISCOBPR-DATA-INIVIGENCIA(1:7) TO WHOST-DATA-INIVIGENCIA(1:7) */
                    _.MoveAtPosition(HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_DATA_INIVIGENCIA.Substring(1, 7), WHOST_DATA_INIVIGENCIA, 1, 7);

                    /*" -1812- END-IF */
                }


                /*" -1813- ELSE */
            }
            else
            {


                /*" -1814- MOVE '1999-01-01' TO WHOST-DT-VENCIMENTO-PARC */
                _.Move("1999-01-01", WHOST_DT_VENCIMENTO_PARC);

                /*" -1816- PERFORM R2250-00-SELECT-PARCEVID */

                R2250_00_SELECT_PARCEVID_SECTION();

                /*" -1817- IF (PARCEVID-PREMIO-VG EQUAL WHOST-PRMVG) */

                if ((PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_PREMIO_VG == WHOST_PRMVG))
                {

                    /*" -1818- ADD 1 TO AC-PREMIO-IGUAL */
                    FILLER_30.AC_PREMIO_IGUAL.Value = FILLER_30.AC_PREMIO_IGUAL + 1;

                    /*" -1819- GO TO R1000-10-NEXT */

                    R1000_10_NEXT(); //GOTO
                    return;

                    /*" -1820- ELSE */
                }
                else
                {


                    /*" -1821- MOVE VG083-DTA-FIM-FATURA TO WHOST-DT-VENCIMENTO-PARC */
                    _.Move(VG083.DCLVG_VIGENCIA_FATURA.VG083_DTA_FIM_FATURA, WHOST_DT_VENCIMENTO_PARC);

                    /*" -1823- PERFORM R2250-00-SELECT-PARCEVID */

                    R2250_00_SELECT_PARCEVID_SECTION();

                    /*" -1825- IF (VG083-DTA-INI-FATURA(1:7) EQUAL HISCOBPR-DATA-INIVIGENCIA(1:7)) */

                    if ((VG083.DCLVG_VIGENCIA_FATURA.VG083_DTA_INI_FATURA.Substring(1, 7) == HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_DATA_INIVIGENCIA.Substring(1, 7)))
                    {

                        /*" -1827- ADD 1 TO AC-PREMIO-AJUSTADO */
                        FILLER_30.AC_PREMIO_AJUSTADO.Value = FILLER_30.AC_PREMIO_AJUSTADO + 1;

                        /*" -1828- IF (WTEM-PARCEVID EQUAL 'SIM' ) */

                        if ((FILLER_30.FILLER_40.WTEM_PARCEVID == "SIM"))
                        {

                            /*" -1829- PERFORM R3000-00-AJUSTA-COBRANCA */

                            R3000_00_AJUSTA_COBRANCA_SECTION();

                            /*" -1830- ELSE */
                        }
                        else
                        {


                            /*" -1831- PERFORM R3100-00-UPDATE-COBERPROPVA */

                            R3100_00_UPDATE_COBERPROPVA_SECTION();

                            /*" -1833- END-IF */
                        }


                        /*" -1834- GO TO R1000-10-NEXT */

                        R1000_10_NEXT(); //GOTO
                        return;

                        /*" -1835- ELSE */
                    }
                    else
                    {


                        /*" -1836- IF (WTEM-PARCEVID EQUAL 'SIM' ) */

                        if ((FILLER_30.FILLER_40.WTEM_PARCEVID == "SIM"))
                        {

                            /*" -1837- PERFORM R3200-00-UPDATE-PARCELVA */

                            R3200_00_UPDATE_PARCELVA_SECTION();

                            /*" -1838- PERFORM R3300-00-UPDATE-HISTCOBVA */

                            R3300_00_UPDATE_HISTCOBVA_SECTION();

                            /*" -1839- PERFORM R3400-00-UPDATE-HISTLANCTA */

                            R3400_00_UPDATE_HISTLANCTA_SECTION();

                            /*" -1841- END-IF */
                        }


                        /*" -1842- MOVE VG083-DTA-INI-FATURA TO WHOST-DATA-INIVIGENCIA */
                        _.Move(VG083.DCLVG_VIGENCIA_FATURA.VG083_DTA_INI_FATURA, WHOST_DATA_INIVIGENCIA);

                        /*" -1843- END-IF */
                    }


                    /*" -1844- END-IF */
                }


                /*" -1856- END-IF. */
            }


            /*" -1857- IF (WS-COBERPROPVA EQUAL 'N' ) */

            if ((WS_COBERPROPVA == "N"))
            {

                /*" -1858- GO TO R1000-10-NEXT */

                R1000_10_NEXT(); //GOTO
                return;

                /*" -1860- END-IF. */
            }


            /*" -1861- IF HISCOBPR-IMP-MORNATU GREATER ZEROES */

            if (HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMP_MORNATU > 00)
            {

                /*" -1862- IF WHOST-IMPSEG EQUAL HISCOBPR-IMP-MORNATU */

                if (WHOST_IMPSEG == HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMP_MORNATU)
                {

                    /*" -1864- MOVE 0 TO HISCOBPR-COD-OPERACAO */
                    _.Move(0, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_COD_OPERACAO);

                    /*" -1865- ELSE */
                }
                else
                {


                    /*" -1866- IF WHOST-IMPSEG LESS HISCOBPR-IMP-MORNATU */

                    if (WHOST_IMPSEG < HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMP_MORNATU)
                    {

                        /*" -1868- MOVE 701 TO HISCOBPR-COD-OPERACAO */
                        _.Move(701, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_COD_OPERACAO);

                        /*" -1869- ELSE */
                    }
                    else
                    {


                        /*" -1871- MOVE 801 TO HISCOBPR-COD-OPERACAO */
                        _.Move(801, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_COD_OPERACAO);

                        /*" -1872- END-IF */
                    }


                    /*" -1873- END-IF */
                }


                /*" -1874- ELSE */
            }
            else
            {


                /*" -1875- IF WHOST-IMPSEG EQUAL HISCOBPR-IMPMORACID */

                if (WHOST_IMPSEG == HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPMORACID)
                {

                    /*" -1877- MOVE 0 TO HISCOBPR-COD-OPERACAO */
                    _.Move(0, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_COD_OPERACAO);

                    /*" -1878- ELSE */
                }
                else
                {


                    /*" -1879- IF WHOST-IMPSEG LESS HISCOBPR-IMPMORACID */

                    if (WHOST_IMPSEG < HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPMORACID)
                    {

                        /*" -1881- MOVE 701 TO HISCOBPR-COD-OPERACAO */
                        _.Move(701, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_COD_OPERACAO);

                        /*" -1882- ELSE */
                    }
                    else
                    {


                        /*" -1884- MOVE 801 TO HISCOBPR-COD-OPERACAO */
                        _.Move(801, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_COD_OPERACAO);

                        /*" -1885- END-IF */
                    }


                    /*" -1886- END-IF */
                }


                /*" -1888- END-IF. */
            }


            /*" -1890- PERFORM R2900-00-INSERT-COBERPROPVA. */

            R2900_00_INSERT_COBERPROPVA_SECTION();

            /*" -1892- PERFORM R2910-00-UPDATE-COBERPROPVA. */

            R2910_00_UPDATE_COBERPROPVA_SECTION();

            /*" -1892- PERFORM R2920-00-UPDATE-PROPOSTAVA. */

            R2920_00_UPDATE_PROPOSTAVA_SECTION();

        }

        [StopWatch]
        /*" R1000-05-DELETE-DB-DELETE-1 */
        public void R1000_05_DELETE_DB_DELETE_1()
        {
            /*" -1664- EXEC SQL DELETE FROM SEGUROS.HIS_COBER_PROPOST WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO AND OCORR_HISTORICO > :PROPOVA-OCORR-HISTORICO END-EXEC. */

            var r1000_05_DELETE_DB_DELETE_1_Delete1 = new R1000_05_DELETE_DB_DELETE_1_Delete1()
            {
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
                PROPOVA_OCORR_HISTORICO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_OCORR_HISTORICO.ToString(),
            };

            R1000_05_DELETE_DB_DELETE_1_Delete1.Execute(r1000_05_DELETE_DB_DELETE_1_Delete1);

        }

        [StopWatch]
        /*" R1000-05-DELETE-DB-UPDATE-1 */
        public void R1000_05_DELETE_DB_UPDATE_1()
        {
            /*" -1686- EXEC SQL UPDATE SEGUROS.HIS_COBER_PROPOST SET DATA_TERVIGENCIA = '9999-12-31' WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO AND OCORR_HISTORICO = :PROPOVA-OCORR-HISTORICO END-EXEC. */

            var r1000_05_DELETE_DB_UPDATE_1_Update1 = new R1000_05_DELETE_DB_UPDATE_1_Update1()
            {
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
                PROPOVA_OCORR_HISTORICO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_OCORR_HISTORICO.ToString(),
            };

            R1000_05_DELETE_DB_UPDATE_1_Update1.Execute(r1000_05_DELETE_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-DB-SELECT-2 */
        public void R1000_00_PROCESSA_REGISTRO_DB_SELECT_2()
        {
            /*" -1548- EXEC SQL SELECT DATA_VENCIMENTO , NUM_PARCELA, SIT_REGISTRO, PREMIO_VG + PREMIO_AP, DATE(DATA_VENCIMENTO) + :SUBGVGAP-PERI-FATURAMENTO MONTHS INTO :WHOST-DATA-VENCIMENTO , :WHOST-NUM-PARCELA, :WHOST-SIT-PARCELA, :PARCEVID-PREMIO-VG, :PROPOVA-DTPROXVEN FROM SEGUROS.PARCELAS_VIDAZUL WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO ORDER BY NUM_PARCELA DESC FETCH FIRST 1 ROW ONLY END-EXEC. */

            var r1000_00_PROCESSA_REGISTRO_DB_SELECT_2_Query1 = new R1000_00_PROCESSA_REGISTRO_DB_SELECT_2_Query1()
            {
                SUBGVGAP_PERI_FATURAMENTO = SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_PERI_FATURAMENTO.ToString(),
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = R1000_00_PROCESSA_REGISTRO_DB_SELECT_2_Query1.Execute(r1000_00_PROCESSA_REGISTRO_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_DATA_VENCIMENTO, WHOST_DATA_VENCIMENTO);
                _.Move(executed_1.WHOST_NUM_PARCELA, WHOST_NUM_PARCELA);
                _.Move(executed_1.WHOST_SIT_PARCELA, WHOST_SIT_PARCELA);
                _.Move(executed_1.PARCEVID_PREMIO_VG, PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_PREMIO_VG);
                _.Move(executed_1.PROPOVA_DTPROXVEN, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DTPROXVEN);
            }


        }

        [StopWatch]
        /*" R1000-05-DELETE-DB-UPDATE-2 */
        public void R1000_05_DELETE_DB_UPDATE_2()
        {
            /*" -1703- EXEC SQL UPDATE SEGUROS.PROPOSTAS_VA SET OCORR_HISTORICO = :PROPOVA-OCORR-HISTORICO, NUM_PARCELA = :WHOST-NUM-PARCELA, DATA_VENCIMENTO = :WHOST-DATA-VENCIMENTO, DTPROXVEN = :PROPOVA-DTPROXVEN WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO END-EXEC. */

            var r1000_05_DELETE_DB_UPDATE_2_Update1 = new R1000_05_DELETE_DB_UPDATE_2_Update1()
            {
                PROPOVA_OCORR_HISTORICO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_OCORR_HISTORICO.ToString(),
                WHOST_DATA_VENCIMENTO = WHOST_DATA_VENCIMENTO.ToString(),
                WHOST_NUM_PARCELA = WHOST_NUM_PARCELA.ToString(),
                PROPOVA_DTPROXVEN = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DTPROXVEN.ToString(),
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
            };

            R1000_05_DELETE_DB_UPDATE_2_Update1.Execute(r1000_05_DELETE_DB_UPDATE_2_Update1);

        }

        [StopWatch]
        /*" R1000-10-NEXT */
        private void R1000_10_NEXT(bool isPerform = false)
        {
            /*" -1896- PERFORM R0910-00-FETCH-PROPOVA. */

            R0910_00_FETCH_PROPOVA_SECTION();

        }

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-DB-SELECT-3 */
        public void R1000_00_PROCESSA_REGISTRO_DB_SELECT_3()
        {
            /*" -1596- EXEC SQL SELECT OCORR_HISTORICO, DATE(TIMESTAMP), COD_USUARIO, DATA_INIVIGENCIA + :SUBGVGAP-PERI-FATURAMENTO MONTHS INTO :PROPOVA-OCORR-HISTORICO, :WHOST-DATA-HISCOBPR, :WHOST-COD-USUARIO, :WHOST-PROX-DATA-INIVIG FROM SEGUROS.HIS_COBER_PROPOST WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO AND DATA_INIVIGENCIA <= :WHOST-DATA-VENCIMENTO AND DATA_TERVIGENCIA >= :WHOST-DATA-VENCIMENTO ORDER BY OCORR_HISTORICO DESC FETCH FIRST 1 ROW ONLY END-EXEC. */

            var r1000_00_PROCESSA_REGISTRO_DB_SELECT_3_Query1 = new R1000_00_PROCESSA_REGISTRO_DB_SELECT_3_Query1()
            {
                SUBGVGAP_PERI_FATURAMENTO = SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_PERI_FATURAMENTO.ToString(),
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
                WHOST_DATA_VENCIMENTO = WHOST_DATA_VENCIMENTO.ToString(),
            };

            var executed_1 = R1000_00_PROCESSA_REGISTRO_DB_SELECT_3_Query1.Execute(r1000_00_PROCESSA_REGISTRO_DB_SELECT_3_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PROPOVA_OCORR_HISTORICO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_OCORR_HISTORICO);
                _.Move(executed_1.WHOST_DATA_HISCOBPR, WHOST_DATA_HISCOBPR);
                _.Move(executed_1.WHOST_COD_USUARIO, WHOST_COD_USUARIO);
                _.Move(executed_1.WHOST_PROX_DATA_INIVIG, WHOST_PROX_DATA_INIVIG);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-DB-SELECT-4 */
        public void R1000_00_PROCESSA_REGISTRO_DB_SELECT_4()
        {
            /*" -1613- EXEC SQL SELECT VALUE(OCORR_HISTORICO,0), DATE(TIMESTAMP) INTO :PROPOVA-OCORR-HISTORICO, :WHOST-DATA-HISCOBPR FROM SEGUROS.HIS_COBER_PROPOST WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO AND OCORR_HISTORICO = (SELECT MAX(T1.OCORR_HISTORICO) FROM SEGUROS.HIS_COBER_PROPOST T1 WHERE T1.NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO) END-EXEC */

            var r1000_00_PROCESSA_REGISTRO_DB_SELECT_4_Query1 = new R1000_00_PROCESSA_REGISTRO_DB_SELECT_4_Query1()
            {
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = R1000_00_PROCESSA_REGISTRO_DB_SELECT_4_Query1.Execute(r1000_00_PROCESSA_REGISTRO_DB_SELECT_4_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PROPOVA_OCORR_HISTORICO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_OCORR_HISTORICO);
                _.Move(executed_1.WHOST_DATA_HISCOBPR, WHOST_DATA_HISCOBPR);
            }


        }

        [StopWatch]
        /*" R2100-00-DECLARE-SEGURVGA-SECTION */
        private void R2100_00_DECLARE_SEGURVGA_SECTION()
        {
            /*" -1906- MOVE 'R2100-00-DECLARE-SEGURVGA' TO PARAGRAFO. */
            _.Move("R2100-00-DECLARE-SEGURVGA", FILLER_30.FILLER_40.WABEND.PARAGRAFO);

            /*" -1908- MOVE '2100' TO WNR-EXEC-SQL. */
            _.Move("2100", FILLER_30.FILLER_40.WABEND.WNR_EXEC_SQL);

            /*" -1911- MOVE 'NAO' TO WFIM-SEGURVGA. */
            _.Move("NAO", FILLER_30.FILLER_40.WFIM_SEGURVGA);

            /*" -1925- PERFORM R2100_00_DECLARE_SEGURVGA_DB_DECLARE_1 */

            R2100_00_DECLARE_SEGURVGA_DB_DECLARE_1();

            /*" -1927- PERFORM R2100_00_DECLARE_SEGURVGA_DB_OPEN_1 */

            R2100_00_DECLARE_SEGURVGA_DB_OPEN_1();

            /*" -1930- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1932- DISPLAY 'APOLICE = ' PROPOVA-NUM-APOLICE ' ' WHOST-COD-SUBGRUPO */

                $"APOLICE = {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE} {WHOST_COD_SUBGRUPO}"
                .Display();

                /*" -1933- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1933- END-IF. */
            }


        }

        [StopWatch]
        /*" R2100-00-DECLARE-SEGURVGA-DB-OPEN-1 */
        public void R2100_00_DECLARE_SEGURVGA_DB_OPEN_1()
        {
            /*" -1927- EXEC SQL OPEN SEGURVGA1 END-EXEC. */

            SEGURVGA1.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2100_99_SAIDA*/

        [StopWatch]
        /*" R2120-00-FETCH-SEGURVGA-SECTION */
        private void R2120_00_FETCH_SEGURVGA_SECTION()
        {
            /*" -1944- MOVE 'R2120-00-FETCH-SEGURVGA' TO PARAGRAFO. */
            _.Move("R2120-00-FETCH-SEGURVGA", FILLER_30.FILLER_40.WABEND.PARAGRAFO);

            /*" -1948- MOVE '2120' TO WNR-EXEC-SQL. */
            _.Move("2120", FILLER_30.FILLER_40.WABEND.WNR_EXEC_SQL);

            /*" -1954- PERFORM R2120_00_FETCH_SEGURVGA_DB_FETCH_1 */

            R2120_00_FETCH_SEGURVGA_DB_FETCH_1();

            /*" -1957- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1958- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1959- MOVE 'SIM' TO WFIM-SEGURVGA */
                    _.Move("SIM", FILLER_30.FILLER_40.WFIM_SEGURVGA);

                    /*" -1959- PERFORM R2120_00_FETCH_SEGURVGA_DB_CLOSE_1 */

                    R2120_00_FETCH_SEGURVGA_DB_CLOSE_1();

                    /*" -1961- ELSE */
                }
                else
                {


                    /*" -1962- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1963- END-IF */
                }


                /*" -1963- END-IF. */
            }


        }

        [StopWatch]
        /*" R2120-00-FETCH-SEGURVGA-DB-FETCH-1 */
        public void R2120_00_FETCH_SEGURVGA_DB_FETCH_1()
        {
            /*" -1954- EXEC SQL FETCH SEGURVGA1 INTO :SEGURVGA-NUM-CERTIFICADO , :SEGURVGA-COD-SUBGRUPO , :SEGURVGA-NUM-ITEM , :SEGURVGA-COD-CLIENTE , :SEGURVGA-OCORR-HISTORICO END-EXEC. */

            if (SEGURVGA1.Fetch())
            {
                _.Move(SEGURVGA1.SEGURVGA_NUM_CERTIFICADO, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_CERTIFICADO);
                _.Move(SEGURVGA1.SEGURVGA_COD_SUBGRUPO, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_SUBGRUPO);
                _.Move(SEGURVGA1.SEGURVGA_NUM_ITEM, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_ITEM);
                _.Move(SEGURVGA1.SEGURVGA_COD_CLIENTE, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_CLIENTE);
                _.Move(SEGURVGA1.SEGURVGA_OCORR_HISTORICO, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_OCORR_HISTORICO);
            }

        }

        [StopWatch]
        /*" R2120-00-FETCH-SEGURVGA-DB-CLOSE-1 */
        public void R2120_00_FETCH_SEGURVGA_DB_CLOSE_1()
        {
            /*" -1959- EXEC SQL CLOSE SEGURVGA1 END-EXEC */

            SEGURVGA1.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2120_99_SAIDA*/

        [StopWatch]
        /*" R2130-00-ACUMULA-IS-SECTION */
        private void R2130_00_ACUMULA_IS_SECTION()
        {
            /*" -1973- MOVE 'R2130-00-ACUMULA-IS' TO PARAGRAFO. */
            _.Move("R2130-00-ACUMULA-IS", FILLER_30.FILLER_40.WABEND.PARAGRAFO);

            /*" -1977- MOVE '2130' TO WNR-EXEC-SQL. */
            _.Move("2130", FILLER_30.FILLER_40.WABEND.WNR_EXEC_SQL);

            /*" -1979- PERFORM R2140-00-SELECT-APOLICOB. */

            R2140_00_SELECT_APOLICOB_SECTION();

            /*" -1982- COMPUTE WHOST-QTDSEG = WHOST-QTDSEG + 1 */
            WHOST_QTDSEG.Value = WHOST_QTDSEG + 1;

            /*" -1985- COMPUTE WHOST-PRMVG = WHOST-PRMVG + APOLICOB-PRM-TARIFARIO-IX */
            WHOST_PRMVG.Value = WHOST_PRMVG + APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_PRM_TARIFARIO_IX;

            /*" -1988- COMPUTE WHOST-IMPSEG = WHOST-IMPSEG + APOLICOB-IMP-SEGURADA-IX. */
            WHOST_IMPSEG.Value = WHOST_IMPSEG + APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_IMP_SEGURADA_IX;

            /*" -1989- IF PROPOVA-NUM-APOLICE EQUAL WS-APOLICE-CAP */

            if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE == AREAS_ARQUIVO_CAP.WS_AUXILIARES.WS_APOLICE_CAP)
            {

                /*" -1990- PERFORM R2160-00-ARQUIVO-FATURADOS */

                R2160_00_ARQUIVO_FATURADOS_SECTION();

                /*" -1992- END-IF */
            }


            /*" -1992- PERFORM R2120-00-FETCH-SEGURVGA. */

            R2120_00_FETCH_SEGURVGA_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2130_99_SAIDA*/

        [StopWatch]
        /*" R2140-00-SELECT-APOLICOB-SECTION */
        private void R2140_00_SELECT_APOLICOB_SECTION()
        {
            /*" -2004- MOVE 'R2140-00-SELECT-APOLICOB' TO PARAGRAFO. */
            _.Move("R2140-00-SELECT-APOLICOB", FILLER_30.FILLER_40.WABEND.PARAGRAFO);

            /*" -2006- MOVE '2140' TO WNR-EXEC-SQL. */
            _.Move("2140", FILLER_30.FILLER_40.WABEND.WNR_EXEC_SQL);

            /*" -2015- PERFORM R2140_00_SELECT_APOLICOB_DB_SELECT_1 */

            R2140_00_SELECT_APOLICOB_DB_SELECT_1();

            /*" -2018- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2019- DISPLAY 'ERRO NO SELECT SEGUROS.APOLICE_COBERTURAS' */
                _.Display($"ERRO NO SELECT SEGUROS.APOLICE_COBERTURAS");

                /*" -2020- DISPLAY 'APOLICE     = ' PROPOVA-NUM-APOLICE */
                _.Display($"APOLICE     = {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE}");

                /*" -2021- DISPLAY 'ITEM        = ' SEGURVGA-NUM-ITEM */
                _.Display($"ITEM        = {SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_ITEM}");

                /*" -2022- DISPLAY 'OCORR HIST  = ' SEGURVGA-OCORR-HISTORICO */
                _.Display($"OCORR HIST  = {SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_OCORR_HISTORICO}");

                /*" -2023- DISPLAY 'RAMO COBER  = ' APOLICES-RAMO-EMISSOR */
                _.Display($"RAMO COBER  = {APOLICES.DCLAPOLICES.APOLICES_RAMO_EMISSOR}");

                /*" -2024- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2026- END-IF. */
            }


            /*" -2030- MOVE '2141' TO WNR-EXEC-SQL. */
            _.Move("2141", FILLER_30.FILLER_40.WABEND.WNR_EXEC_SQL);

            /*" -2040- PERFORM R2140_00_SELECT_APOLICOB_DB_SELECT_2 */

            R2140_00_SELECT_APOLICOB_DB_SELECT_2();

            /*" -2043- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2044- DISPLAY 'ERRO NO SELECT SEGUROS.APOLICE_COBERTURAS 1' */
                _.Display($"ERRO NO SELECT SEGUROS.APOLICE_COBERTURAS 1");

                /*" -2045- DISPLAY 'APOLICE     = ' PROPOVA-NUM-APOLICE */
                _.Display($"APOLICE     = {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE}");

                /*" -2046- DISPLAY 'ITEM        = ' SEGURVGA-NUM-ITEM */
                _.Display($"ITEM        = {SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_ITEM}");

                /*" -2047- DISPLAY 'OCORR HIST  = ' SEGURVGA-OCORR-HISTORICO */
                _.Display($"OCORR HIST  = {SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_OCORR_HISTORICO}");

                /*" -2048- DISPLAY 'RAMO COBER  = ' APOLICES-RAMO-EMISSOR */
                _.Display($"RAMO COBER  = {APOLICES.DCLAPOLICES.APOLICES_RAMO_EMISSOR}");

                /*" -2049- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2049- END-IF. */
            }


        }

        [StopWatch]
        /*" R2140-00-SELECT-APOLICOB-DB-SELECT-1 */
        public void R2140_00_SELECT_APOLICOB_DB_SELECT_1()
        {
            /*" -2015- EXEC SQL SELECT VALUE(MAX(IMP_SEGURADA_IX), 0) INTO :APOLICOB-IMP-SEGURADA-IX FROM SEGUROS.APOLICE_COBERTURAS WHERE NUM_APOLICE = :PROPOVA-NUM-APOLICE AND NUM_ITEM = :SEGURVGA-NUM-ITEM AND OCORR_HISTORICO = :SEGURVGA-OCORR-HISTORICO AND RAMO_COBERTURA = :APOLICES-RAMO-EMISSOR WITH UR END-EXEC. */

            var r2140_00_SELECT_APOLICOB_DB_SELECT_1_Query1 = new R2140_00_SELECT_APOLICOB_DB_SELECT_1_Query1()
            {
                SEGURVGA_OCORR_HISTORICO = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_OCORR_HISTORICO.ToString(),
                APOLICES_RAMO_EMISSOR = APOLICES.DCLAPOLICES.APOLICES_RAMO_EMISSOR.ToString(),
                PROPOVA_NUM_APOLICE = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE.ToString(),
                SEGURVGA_NUM_ITEM = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_ITEM.ToString(),
            };

            var executed_1 = R2140_00_SELECT_APOLICOB_DB_SELECT_1_Query1.Execute(r2140_00_SELECT_APOLICOB_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.APOLICOB_IMP_SEGURADA_IX, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_IMP_SEGURADA_IX);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2140_99_SAIDA*/

        [StopWatch]
        /*" R2140-00-SELECT-APOLICOB-DB-SELECT-2 */
        public void R2140_00_SELECT_APOLICOB_DB_SELECT_2()
        {
            /*" -2040- EXEC SQL SELECT VALUE(SUM(PRM_TARIFARIO_IX), 0) INTO :APOLICOB-PRM-TARIFARIO-IX FROM SEGUROS.APOLICE_COBERTURAS WHERE NUM_APOLICE = :PROPOVA-NUM-APOLICE AND NUM_ITEM = :SEGURVGA-NUM-ITEM AND OCORR_HISTORICO = :SEGURVGA-OCORR-HISTORICO AND RAMO_COBERTURA = :APOLICES-RAMO-EMISSOR WITH UR END-EXEC. */

            var r2140_00_SELECT_APOLICOB_DB_SELECT_2_Query1 = new R2140_00_SELECT_APOLICOB_DB_SELECT_2_Query1()
            {
                SEGURVGA_OCORR_HISTORICO = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_OCORR_HISTORICO.ToString(),
                APOLICES_RAMO_EMISSOR = APOLICES.DCLAPOLICES.APOLICES_RAMO_EMISSOR.ToString(),
                PROPOVA_NUM_APOLICE = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE.ToString(),
                SEGURVGA_NUM_ITEM = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_ITEM.ToString(),
            };

            var executed_1 = R2140_00_SELECT_APOLICOB_DB_SELECT_2_Query1.Execute(r2140_00_SELECT_APOLICOB_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.APOLICOB_PRM_TARIFARIO_IX, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_PRM_TARIFARIO_IX);
            }


        }

        [StopWatch]
        /*" R2150-00-SELECT-APOLICES-SECTION */
        private void R2150_00_SELECT_APOLICES_SECTION()
        {
            /*" -2060- MOVE 'R2150-00-SELECT-APOLICES' TO PARAGRAFO. */
            _.Move("R2150-00-SELECT-APOLICES", FILLER_30.FILLER_40.WABEND.PARAGRAFO);

            /*" -2064- MOVE '2150' TO WNR-EXEC-SQL. */
            _.Move("2150", FILLER_30.FILLER_40.WABEND.WNR_EXEC_SQL);

            /*" -2067- MOVE PROPOVA-NUM-APOLICE TO WS-NUM-APOLICE-ANT. */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE, FILLER_30.WS_NUM_APOLICE_ANT);

            /*" -2073- PERFORM R2150_00_SELECT_APOLICES_DB_SELECT_1 */

            R2150_00_SELECT_APOLICES_DB_SELECT_1();

        }

        [StopWatch]
        /*" R2150-00-SELECT-APOLICES-DB-SELECT-1 */
        public void R2150_00_SELECT_APOLICES_DB_SELECT_1()
        {
            /*" -2073- EXEC SQL SELECT RAMO_EMISSOR INTO :APOLICES-RAMO-EMISSOR FROM SEGUROS.APOLICES WHERE NUM_APOLICE = :PROPOVA-NUM-APOLICE WITH UR END-EXEC. */

            var r2150_00_SELECT_APOLICES_DB_SELECT_1_Query1 = new R2150_00_SELECT_APOLICES_DB_SELECT_1_Query1()
            {
                PROPOVA_NUM_APOLICE = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE.ToString(),
            };

            var executed_1 = R2150_00_SELECT_APOLICES_DB_SELECT_1_Query1.Execute(r2150_00_SELECT_APOLICES_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.APOLICES_RAMO_EMISSOR, APOLICES.DCLAPOLICES.APOLICES_RAMO_EMISSOR);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2150_99_SAIDA*/

        [StopWatch]
        /*" R2160-00-ARQUIVO-FATURADOS-SECTION */
        private void R2160_00_ARQUIVO_FATURADOS_SECTION()
        {
            /*" -2083- MOVE SPACES TO VG1626BO-DETALHE */
            _.Move("", VG1626BO_DETALHE);

            /*" -2084- MOVE 002 TO VG1626BO-D-TIP-REG */
            _.Move(002, VG1626BO_DETALHE.VG1626BO_D_TIP_REG);

            /*" -2085- ADD 001 TO AC-SEQ-REG-ARQ */
            FILLER_30.AC_SEQ_REG_ARQ.Value = FILLER_30.AC_SEQ_REG_ARQ + 001;

            /*" -2086- MOVE AC-SEQ-REG-ARQ TO VG1626BO-D-SEQ-REG */
            _.Move(FILLER_30.AC_SEQ_REG_ARQ, VG1626BO_DETALHE.VG1626BO_D_SEQ_REG);

            /*" -2087- MOVE SEGURVGA-NUM-CERTIFICADO TO VG1626BO-D-NUM-CER */
            _.Move(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_CERTIFICADO, VG1626BO_DETALHE.VG1626BO_D_NUM_CER);

            /*" -2089- MOVE SEGURVGA-COD-SUBGRUPO TO VG1626BO-D-SUB-GRU */
            _.Move(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_SUBGRUPO, VG1626BO_DETALHE.VG1626BO_D_SUB_GRU);

            /*" -2091- PERFORM R2161-00-CLIENTE-FATURADO */

            R2161_00_CLIENTE_FATURADO_SECTION();

            /*" -2092- MOVE CLIENTES-NOME-RAZAO TO VG1626BO-D-NOM-CLI */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO, VG1626BO_DETALHE.VG1626BO_D_NOM_CLI);

            /*" -2093- MOVE CLIENTES-CGCCPF TO VG1626BO-D-NUM-CPF */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF, VG1626BO_DETALHE.VG1626BO_D_NUM_CPF);

            /*" -2095- MOVE APOLICOB-PRM-TARIFARIO-IX TO VG1626BO-D-VLR-PRE */
            _.Move(APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_PRM_TARIFARIO_IX, VG1626BO_DETALHE.VG1626BO_D_VLR_PRE);

            /*" -2097- PERFORM R2163-00-TITULO-VINCULADO */

            R2163_00_TITULO_VINCULADO_SECTION();

            /*" -2098- MOVE VG098-NUM-TITULO TO VG1626BO-D-NUM-TIT */
            _.Move(VG098.DCLVG_CERTIFICADO_TITULO.VG098_NUM_TITULO, VG1626BO_DETALHE.VG1626BO_D_NUM_TIT);

            /*" -2099- MOVE VG098-NUM-SERIE TO VG1626BO-D-SER */
            _.Move(VG098.DCLVG_CERTIFICADO_TITULO.VG098_NUM_SERIE, VG1626BO_DETALHE.VG1626BO_D_SER);

            /*" -2100- MOVE VG098-NUM-PLANO TO VG1626BO-D-COD-PLA */
            _.Move(VG098.DCLVG_CERTIFICADO_TITULO.VG098_NUM_PLANO, VG1626BO_DETALHE.VG1626BO_D_COD_PLA);

            /*" -2102- MOVE VG1626BO-DETALHE TO VG1626BD-REGISTRO */
            _.Move(VG1626BO?.Value, VG1626BD_REGISTRO);

            /*" -2103- IF NOT IGNORA-ARQUIVO */

            if (!AREAS_ARQUIVO_CAP.WS_AUXILIARES.N88_IGNORA_ARQUIVO["IGNORA_ARQUIVO"])
            {

                /*" -2104- ADD APOLICOB-PRM-TARIFARIO-IX TO AC-TOT-CER-O */
                FILLER_30.AC_TOT_CER_O.Value = FILLER_30.AC_TOT_CER_O + APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_PRM_TARIFARIO_IX;

                /*" -2105- WRITE VG1626BO-DETALHE */
                VG1626BO.Write(VG1626BO_DETALHE.GetMoveValues().ToString());

                /*" -2106- IF VG1626BO-NORMAL */

                if (WS_NIVEIS_88.N88_VG1626BO_STATUS["VG1626BO_NORMAL"])
                {

                    /*" -2107- ADD 001 TO AC-VG1626BO-GRV */
                    FILLER_30.AC_VG1626BO_GRV.Value = FILLER_30.AC_VG1626BO_GRV + 001;

                    /*" -2108- ELSE */
                }
                else
                {


                    /*" -2109- DISPLAY '***' */
                    _.Display($"***");

                    /*" -2110- DISPLAY ' R2160-00-ARQUIVO-FATURADOS ' */
                    _.Display($" R2160-00-ARQUIVO-FATURADOS ");

                    /*" -2112- DISPLAY ' ERRO WRITE VG1626BO ST = ' N88-VG1626BO-STATUS */
                    _.Display($" ERRO WRITE VG1626BO ST = {WS_NIVEIS_88.N88_VG1626BO_STATUS}");

                    /*" -2113- DISPLAY '***' */
                    _.Display($"***");

                    /*" -2114- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2115- END-IF */
                }


                /*" -2118- END-IF */
            }


            /*" -2120- ADD APOLICOB-PRM-TARIFARIO-IX TO AC-TOT-CER-D */
            FILLER_30.AC_TOT_CER_D.Value = FILLER_30.AC_TOT_CER_D + APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_PRM_TARIFARIO_IX;

            /*" -2122- WRITE VG1626BD-REGISTRO */
            VG1626BD.Write(VG1626BD_REGISTRO.GetMoveValues().ToString());

            /*" -2123- IF VG1626BD-NORMAL */

            if (WS_NIVEIS_88.N88_VG1626BD_STATUS["VG1626BD_NORMAL"])
            {

                /*" -2124- ADD 001 TO AC-VG1626BD-GRV */
                FILLER_30.AC_VG1626BD_GRV.Value = FILLER_30.AC_VG1626BD_GRV + 001;

                /*" -2125- ELSE */
            }
            else
            {


                /*" -2126- DISPLAY '***' */
                _.Display($"***");

                /*" -2127- DISPLAY ' R2160-00-ARQUIVO-FATURADOS ' */
                _.Display($" R2160-00-ARQUIVO-FATURADOS ");

                /*" -2128- DISPLAY ' ERRO WRITE VG1626BD ST = ' N88-VG1626BD-STATUS */
                _.Display($" ERRO WRITE VG1626BD ST = {WS_NIVEIS_88.N88_VG1626BD_STATUS}");

                /*" -2129- DISPLAY '***' */
                _.Display($"***");

                /*" -2130- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2132- END-IF */
            }


            /*" -2132- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2160_99_SAIDA*/

        [StopWatch]
        /*" R2161-00-CLIENTE-FATURADO-SECTION */
        private void R2161_00_CLIENTE_FATURADO_SECTION()
        {
            /*" -2141- INITIALIZE DCLCLIENTES */
            _.Initialize(
                CLIENTES.DCLCLIENTES
            );

            /*" -2143- MOVE SEGURVGA-COD-CLIENTE TO CLIENTES-COD-CLIENTE */
            _.Move(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_CLIENTE, CLIENTES.DCLCLIENTES.CLIENTES_COD_CLIENTE);

            /*" -2150- PERFORM R2161_00_CLIENTE_FATURADO_DB_SELECT_1 */

            R2161_00_CLIENTE_FATURADO_DB_SELECT_1();

            /*" -2153- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2154- MOVE 'NAO CADASTRADO' TO CLIENTES-NOME-RAZAO */
                _.Move("NAO CADASTRADO", CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO);

                /*" -2156- END-IF */
            }


            /*" -2156- . */

        }

        [StopWatch]
        /*" R2161-00-CLIENTE-FATURADO-DB-SELECT-1 */
        public void R2161_00_CLIENTE_FATURADO_DB_SELECT_1()
        {
            /*" -2150- EXEC SQL SELECT NOME_RAZAO , CGCCPF INTO :CLIENTES-NOME-RAZAO , :CLIENTES-CGCCPF FROM SEGUROS.CLIENTES WHERE COD_CLIENTE = :CLIENTES-COD-CLIENTE END-EXEC */

            var r2161_00_CLIENTE_FATURADO_DB_SELECT_1_Query1 = new R2161_00_CLIENTE_FATURADO_DB_SELECT_1_Query1()
            {
                CLIENTES_COD_CLIENTE = CLIENTES.DCLCLIENTES.CLIENTES_COD_CLIENTE.ToString(),
            };

            var executed_1 = R2161_00_CLIENTE_FATURADO_DB_SELECT_1_Query1.Execute(r2161_00_CLIENTE_FATURADO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CLIENTES_NOME_RAZAO, CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO);
                _.Move(executed_1.CLIENTES_CGCCPF, CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2161_99_SAIDA*/

        [StopWatch]
        /*" R2163-00-TITULO-VINCULADO-SECTION */
        private void R2163_00_TITULO_VINCULADO_SECTION()
        {
            /*" -2165- INITIALIZE DCLVG-CERTIFICADO-TITULO */
            _.Initialize(
                VG098.DCLVG_CERTIFICADO_TITULO
            );

            /*" -2167- MOVE SEGURVGA-NUM-CERTIFICADO TO VG098-NUM-CERTIFICADO */
            _.Move(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_CERTIFICADO, VG098.DCLVG_CERTIFICADO_TITULO.VG098_NUM_CERTIFICADO);

            /*" -2176- PERFORM R2163_00_TITULO_VINCULADO_DB_SELECT_1 */

            R2163_00_TITULO_VINCULADO_DB_SELECT_1();

            /*" -2179- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2182- MOVE ZEROS TO VG098-NUM-TITULO VG098-NUM-SERIE VG098-NUM-PLANO */
                _.Move(0, VG098.DCLVG_CERTIFICADO_TITULO.VG098_NUM_TITULO, VG098.DCLVG_CERTIFICADO_TITULO.VG098_NUM_SERIE, VG098.DCLVG_CERTIFICADO_TITULO.VG098_NUM_PLANO);

                /*" -2184- END-IF */
            }


            /*" -2184- . */

        }

        [StopWatch]
        /*" R2163-00-TITULO-VINCULADO-DB-SELECT-1 */
        public void R2163_00_TITULO_VINCULADO_DB_SELECT_1()
        {
            /*" -2176- EXEC SQL SELECT NUM_TITULO , NUM_SERIE , NUM_PLANO INTO :VG098-NUM-TITULO , :VG098-NUM-SERIE , :VG098-NUM-PLANO FROM SEGUROS.VG_CERTIFICADO_TITULO WHERE NUM_CERTIFICADO = :VG098-NUM-CERTIFICADO END-EXEC */

            var r2163_00_TITULO_VINCULADO_DB_SELECT_1_Query1 = new R2163_00_TITULO_VINCULADO_DB_SELECT_1_Query1()
            {
                VG098_NUM_CERTIFICADO = VG098.DCLVG_CERTIFICADO_TITULO.VG098_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = R2163_00_TITULO_VINCULADO_DB_SELECT_1_Query1.Execute(r2163_00_TITULO_VINCULADO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.VG098_NUM_TITULO, VG098.DCLVG_CERTIFICADO_TITULO.VG098_NUM_TITULO);
                _.Move(executed_1.VG098_NUM_SERIE, VG098.DCLVG_CERTIFICADO_TITULO.VG098_NUM_SERIE);
                _.Move(executed_1.VG098_NUM_PLANO, VG098.DCLVG_CERTIFICADO_TITULO.VG098_NUM_PLANO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2163_99_SAIDA*/

        [StopWatch]
        /*" R2200-00-SELECT-SUBGVGAP-SECTION */
        private void R2200_00_SELECT_SUBGVGAP_SECTION()
        {
            /*" -2193- MOVE 'R2200-00-ACESSA-SUBGVGAP' TO PARAGRAFO. */
            _.Move("R2200-00-ACESSA-SUBGVGAP", FILLER_30.FILLER_40.WABEND.PARAGRAFO);

            /*" -2197- MOVE '2200' TO WNR-EXEC-SQL. */
            _.Move("2200", FILLER_30.FILLER_40.WABEND.WNR_EXEC_SQL);

            /*" -2208- PERFORM R2200_00_SELECT_SUBGVGAP_DB_SELECT_1 */

            R2200_00_SELECT_SUBGVGAP_DB_SELECT_1();

            /*" -2211- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2212- DISPLAY 'PARAGRAFO...' PARAGRAFO */
                _.Display($"PARAGRAFO...{FILLER_30.FILLER_40.WABEND.PARAGRAFO}");

                /*" -2213- DISPLAY 'APOLICE.....' PROPOVA-NUM-APOLICE */
                _.Display($"APOLICE.....{PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE}");

                /*" -2214- DISPLAY 'SUBGRUPO....' PROPOVA-COD-SUBGRUPO */
                _.Display($"SUBGRUPO....{PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_SUBGRUPO}");

                /*" -2214- END-IF. */
            }


        }

        [StopWatch]
        /*" R2200-00-SELECT-SUBGVGAP-DB-SELECT-1 */
        public void R2200_00_SELECT_SUBGVGAP_DB_SELECT_1()
        {
            /*" -2208- EXEC SQL SELECT PERI_FATURAMENTO, FORMA_FATURAMENTO, TIPO_FATURAMENTO INTO :SUBGVGAP-PERI-FATURAMENTO, :SUBGVGAP-FORMA-FATURAMENTO, :SUBGVGAP-TIPO-FATURAMENTO FROM SEGUROS.SUBGRUPOS_VGAP WHERE NUM_APOLICE = :PROPOVA-NUM-APOLICE AND COD_SUBGRUPO = :PROPOVA-COD-SUBGRUPO WITH UR END-EXEC. */

            var r2200_00_SELECT_SUBGVGAP_DB_SELECT_1_Query1 = new R2200_00_SELECT_SUBGVGAP_DB_SELECT_1_Query1()
            {
                PROPOVA_COD_SUBGRUPO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_SUBGRUPO.ToString(),
                PROPOVA_NUM_APOLICE = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE.ToString(),
            };

            var executed_1 = R2200_00_SELECT_SUBGVGAP_DB_SELECT_1_Query1.Execute(r2200_00_SELECT_SUBGVGAP_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SUBGVGAP_PERI_FATURAMENTO, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_PERI_FATURAMENTO);
                _.Move(executed_1.SUBGVGAP_FORMA_FATURAMENTO, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_FORMA_FATURAMENTO);
                _.Move(executed_1.SUBGVGAP_TIPO_FATURAMENTO, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_TIPO_FATURAMENTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2200_99_SAIDA*/

        [StopWatch]
        /*" R2210-00-SELECT-VIGENCFAT-SECTION */
        private void R2210_00_SELECT_VIGENCFAT_SECTION()
        {
            /*" -2225- MOVE 'R2210-00-SELECT-VIGENCFAT   ' TO PARAGRAFO. */
            _.Move("R2210-00-SELECT-VIGENCFAT   ", FILLER_30.FILLER_40.WABEND.PARAGRAFO);

            /*" -2232- MOVE '2210' TO WNR-EXEC-SQL. */
            _.Move("2210", FILLER_30.FILLER_40.WABEND.WNR_EXEC_SQL);

            /*" -2247- PERFORM R2210_00_SELECT_VIGENCFAT_DB_SELECT_1 */

            R2210_00_SELECT_VIGENCFAT_DB_SELECT_1();

            /*" -2250- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2251- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2252- MOVE 'NAO' TO WTEM-VIGENCFAT */
                    _.Move("NAO", FILLER_30.FILLER_40.WTEM_VIGENCFAT);

                    /*" -2253- ELSE */
                }
                else
                {


                    /*" -2255- DISPLAY 'ERRO  DE ACESSO A VIGENCIA FATURA   ' ' ' PROPOVA-NUM-CERTIFICADO ' ' PROPOVA-OCORR-HISTORICO */

                    $"ERRO  DE ACESSO A VIGENCIA FATURA    {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO} {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_OCORR_HISTORICO}"
                    .Display();

                    /*" -2256- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2257- END-IF */
                }


                /*" -2258- ELSE */
            }
            else
            {


                /*" -2259- IF (VG083-IND-PROCESSAMENTO EQUAL 'FP' ) */

                if ((VG083.DCLVG_VIGENCIA_FATURA.VG083_IND_PROCESSAMENTO == "FP"))
                {

                    /*" -2260- MOVE 'NAO' TO WTEM-VIGENCFAT */
                    _.Move("NAO", FILLER_30.FILLER_40.WTEM_VIGENCFAT);

                    /*" -2261- ELSE */
                }
                else
                {


                    /*" -2262- MOVE 'SIM' TO WTEM-VIGENCFAT */
                    _.Move("SIM", FILLER_30.FILLER_40.WTEM_VIGENCFAT);

                    /*" -2263- END-IF */
                }


                /*" -2263- END-IF. */
            }


        }

        [StopWatch]
        /*" R2210-00-SELECT-VIGENCFAT-DB-SELECT-1 */
        public void R2210_00_SELECT_VIGENCFAT_DB_SELECT_1()
        {
            /*" -2247- EXEC SQL SELECT DTA_INI_FATURA, DTA_FIM_FATURA, IND_PROCESSAMENTO INTO :VG083-DTA-INI-FATURA, :VG083-DTA-FIM-FATURA, :VG083-IND-PROCESSAMENTO FROM SEGUROS.VG_VIGENCIA_FATURA WHERE NUM_APOLICE = :PROPOVA-NUM-APOLICE AND COD_SUBGRUPO = 0 AND SEQ_FATURAMENTO = (SELECT MAX(T1.SEQ_FATURAMENTO) FROM SEGUROS.VG_VIGENCIA_FATURA T1 WHERE T1.NUM_APOLICE = :PROPOVA-NUM-APOLICE AND T1.COD_SUBGRUPO = 0) END-EXEC. */

            var r2210_00_SELECT_VIGENCFAT_DB_SELECT_1_Query1 = new R2210_00_SELECT_VIGENCFAT_DB_SELECT_1_Query1()
            {
                PROPOVA_NUM_APOLICE = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE.ToString(),
            };

            var executed_1 = R2210_00_SELECT_VIGENCFAT_DB_SELECT_1_Query1.Execute(r2210_00_SELECT_VIGENCFAT_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.VG083_DTA_INI_FATURA, VG083.DCLVG_VIGENCIA_FATURA.VG083_DTA_INI_FATURA);
                _.Move(executed_1.VG083_DTA_FIM_FATURA, VG083.DCLVG_VIGENCIA_FATURA.VG083_DTA_FIM_FATURA);
                _.Move(executed_1.VG083_IND_PROCESSAMENTO, VG083.DCLVG_VIGENCIA_FATURA.VG083_IND_PROCESSAMENTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2210_99_SAIDA*/

        [StopWatch]
        /*" R2250-00-SELECT-PARCEVID-SECTION */
        private void R2250_00_SELECT_PARCEVID_SECTION()
        {
            /*" -2274- MOVE 'R2250-00-SELECT-PARCEVID    ' TO PARAGRAFO. */
            _.Move("R2250-00-SELECT-PARCEVID    ", FILLER_30.FILLER_40.WABEND.PARAGRAFO);

            /*" -2276- MOVE '2250' TO WNR-EXEC-SQL. */
            _.Move("2250", FILLER_30.FILLER_40.WABEND.WNR_EXEC_SQL);

            /*" -2278- MOVE 'SIM' TO WTEM-PARCEVID */
            _.Move("SIM", FILLER_30.FILLER_40.WTEM_PARCEVID);

            /*" -2290- PERFORM R2250_00_SELECT_PARCEVID_DB_SELECT_1 */

            R2250_00_SELECT_PARCEVID_DB_SELECT_1();

            /*" -2293- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2294- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2295- MOVE 'NAO' TO WTEM-PARCEVID */
                    _.Move("NAO", FILLER_30.FILLER_40.WTEM_PARCEVID);

                    /*" -2296- MOVE ZEROS TO PARCEVID-PREMIO-VG */
                    _.Move(0, PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_PREMIO_VG);

                    /*" -2297- ELSE */
                }
                else
                {


                    /*" -2299- DISPLAY 'ERRO  DE ACESSO A PARCELAS_VIDAZUL  ' ' ' PROPOVA-NUM-CERTIFICADO ' ' PROPOVA-OCORR-HISTORICO */

                    $"ERRO  DE ACESSO A PARCELAS_VIDAZUL   {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO} {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_OCORR_HISTORICO}"
                    .Display();

                    /*" -2300- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2301- END-IF */
                }


                /*" -2301- END-IF. */
            }


        }

        [StopWatch]
        /*" R2250-00-SELECT-PARCEVID-DB-SELECT-1 */
        public void R2250_00_SELECT_PARCEVID_DB_SELECT_1()
        {
            /*" -2290- EXEC SQL SELECT DATA_VENCIMENTO , PREMIO_VG , SIT_REGISTRO INTO :PARCEVID-DATA-VENCIMENTO , :PARCEVID-PREMIO-VG , :PARCEVID-SIT-REGISTRO FROM SEGUROS.PARCELAS_VIDAZUL WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO AND NUM_PARCELA = :PROPOVA-NUM-PARCELA AND DATA_VENCIMENTO > :WHOST-DT-VENCIMENTO-PARC WITH UR END-EXEC. */

            var r2250_00_SELECT_PARCEVID_DB_SELECT_1_Query1 = new R2250_00_SELECT_PARCEVID_DB_SELECT_1_Query1()
            {
                WHOST_DT_VENCIMENTO_PARC = WHOST_DT_VENCIMENTO_PARC.ToString(),
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
                PROPOVA_NUM_PARCELA = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_PARCELA.ToString(),
            };

            var executed_1 = R2250_00_SELECT_PARCEVID_DB_SELECT_1_Query1.Execute(r2250_00_SELECT_PARCEVID_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PARCEVID_DATA_VENCIMENTO, PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_DATA_VENCIMENTO);
                _.Move(executed_1.PARCEVID_PREMIO_VG, PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_PREMIO_VG);
                _.Move(executed_1.PARCEVID_SIT_REGISTRO, PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_SIT_REGISTRO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2250_99_SAIDA*/

        [StopWatch]
        /*" R2300-00-SELECT-COBERPROPVA-SECTION */
        private void R2300_00_SELECT_COBERPROPVA_SECTION()
        {
            /*" -2310- MOVE 'R2300-00-SELECT-COBERPROPVA ' TO PARAGRAFO. */
            _.Move("R2300-00-SELECT-COBERPROPVA ", FILLER_30.FILLER_40.WABEND.PARAGRAFO);

            /*" -2312- MOVE '2300' TO WNR-EXEC-SQL. */
            _.Move("2300", FILLER_30.FILLER_40.WABEND.WNR_EXEC_SQL);

            /*" -2313- MOVE 'S' TO WS-COBERPROPVA. */
            _.Move("S", WS_COBERPROPVA);

            /*" -2315- MOVE 'SIM' TO WPROCESSA. */
            _.Move("SIM", FILLER_30.FILLER_40.WPROCESSA);

            /*" -2374- PERFORM R2300_00_SELECT_COBERPROPVA_DB_SELECT_1 */

            R2300_00_SELECT_COBERPROPVA_DB_SELECT_1();

            /*" -2377- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2378- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2379- MOVE 'N' TO WS-COBERPROPVA */
                    _.Move("N", WS_COBERPROPVA);

                    /*" -2382- DISPLAY 'NAO ENCONTRADO HIS-COBER-PROPOST -> ' 'NUM_CERTIF : ' PROPOVA-NUM-CERTIFICADO ' ' PROPOVA-OCORR-HISTORICO */

                    $"NAO ENCONTRADO HIS-COBER-PROPOST -> NUM_CERTIF : {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO} {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_OCORR_HISTORICO}"
                    .Display();

                    /*" -2383- GO TO R2300-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R2300_99_SAIDA*/ //GOTO
                    return;

                    /*" -2384- ELSE */
                }
                else
                {


                    /*" -2386- DISPLAY 'ERRO  DE ACESSO A HIS_COBER_PROPOST ' ' ' PROPOVA-NUM-CERTIFICADO ' ' PROPOVA-OCORR-HISTORICO */

                    $"ERRO  DE ACESSO A HIS_COBER_PROPOST  {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO} {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_OCORR_HISTORICO}"
                    .Display();

                    /*" -2387- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2388- END-IF */
                }


                /*" -2394- END-IF. */
            }


            /*" -2396- MOVE HISCOBPR-DATA-INIVIGENCIA TO WHOST-DATA-INIVIGENCIA-1 */
            _.Move(HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_DATA_INIVIGENCIA, WHOST_DATA_INIVIGENCIA_1);

            /*" -2399- MOVE SISTEMAS-DATA-MOV-ABERTO(1:7) TO WHOST-DATA-INIVIGENCIA-1(1:7) */
            _.MoveAtPosition(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(1, 7), WHOST_DATA_INIVIGENCIA_1, 1, 7);

            /*" -2402- MOVE WHOST-DATA-INIVIGENCIA-1(9:2) TO WHOST-DIA-INIVIGENCIA-1 */
            _.Move(WHOST_DATA_INIVIGENCIA_1.Substring(9, 2), WHOST_DIA_INIVIGENCIA_1);

            /*" -2403- IF (WHOST-DIA-INIVIGENCIA-1 > 28) */

            if ((WHOST_DIA_INIVIGENCIA_1 > 28))
            {

                /*" -2405- MOVE 'NAO' TO WS-FIM-VALIDA-DATA */
                _.Move("NAO", FILLER_30.FILLER_40.WS_FIM_VALIDA_DATA);

                /*" -2407- PERFORM R2310-VALIDA-DT-INIVIGENCIA UNTIL WS-FIM-VALIDA-DATA EQUAL 'SIM' */

                while (!(FILLER_30.FILLER_40.WS_FIM_VALIDA_DATA == "SIM"))
                {

                    R2310_VALIDA_DT_INIVIGENCIA_SECTION();
                }

                /*" -2408- ELSE */
            }
            else
            {


                /*" -2409- MOVE WHOST-DATA-INIVIGENCIA-1 TO WHOST-DATA-INIVIGENCIA */
                _.Move(WHOST_DATA_INIVIGENCIA_1, WHOST_DATA_INIVIGENCIA);

                /*" -2409- END-IF. */
            }


        }

        [StopWatch]
        /*" R2300-00-SELECT-COBERPROPVA-DB-SELECT-1 */
        public void R2300_00_SELECT_COBERPROPVA_DB_SELECT_1()
        {
            /*" -2374- EXEC SQL SELECT NUM_CERTIFICADO , OCORR_HISTORICO , DATA_INIVIGENCIA, DATA_TERVIGENCIA, IMPSEGUR , QUANT_VIDAS , IMPSEGIND , COD_OPERACAO, OPCAO_COBERTURA, IMP_MORNATU , IMPMORACID , IMPINVPERM , IMPAMDS , IMPDH , IMPDIT , VLPREMIO , PRMVG , PRMAP , QTDE_TIT_CAPITALIZ , VAL_TIT_CAPITALIZ , VAL_CUSTO_CAPITALI , IMPSEGCDG , VLCUSTCDG , COD_USUARIO INTO :HISCOBPR-NUM-CERTIFICADO , :HISCOBPR-OCORR-HISTORICO , :HISCOBPR-DATA-INIVIGENCIA , :HISCOBPR-DATA-TERVIGENCIA , :HISCOBPR-IMPSEGUR , :HISCOBPR-QUANT-VIDAS , :HISCOBPR-IMPSEGIND , :HISCOBPR-COD-OPERACAO, :HISCOBPR-OPCAO-COBERTURA, :HISCOBPR-IMP-MORNATU , :HISCOBPR-IMPMORACID , :HISCOBPR-IMPINVPERM , :HISCOBPR-IMPAMDS , :HISCOBPR-IMPDH , :HISCOBPR-IMPDIT , :HISCOBPR-VLPREMIO , :HISCOBPR-PRMVG , :HISCOBPR-PRMAP , :HISCOBPR-QTDE-TIT-CAPITALIZ, :HISCOBPR-VAL-TIT-CAPITALIZ, :HISCOBPR-VAL-CUSTO-CAPITALI, :HISCOBPR-IMPSEGCDG , :HISCOBPR-VLCUSTCDG , :HISCOBPR-COD-USUARIO FROM SEGUROS.HIS_COBER_PROPOST WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO AND OCORR_HISTORICO = :PROPOVA-OCORR-HISTORICO WITH UR END-EXEC. */

            var r2300_00_SELECT_COBERPROPVA_DB_SELECT_1_Query1 = new R2300_00_SELECT_COBERPROPVA_DB_SELECT_1_Query1()
            {
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
                PROPOVA_OCORR_HISTORICO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_OCORR_HISTORICO.ToString(),
            };

            var executed_1 = R2300_00_SELECT_COBERPROPVA_DB_SELECT_1_Query1.Execute(r2300_00_SELECT_COBERPROPVA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HISCOBPR_NUM_CERTIFICADO, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_NUM_CERTIFICADO);
                _.Move(executed_1.HISCOBPR_OCORR_HISTORICO, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_OCORR_HISTORICO);
                _.Move(executed_1.HISCOBPR_DATA_INIVIGENCIA, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_DATA_INIVIGENCIA);
                _.Move(executed_1.HISCOBPR_DATA_TERVIGENCIA, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_DATA_TERVIGENCIA);
                _.Move(executed_1.HISCOBPR_IMPSEGUR, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPSEGUR);
                _.Move(executed_1.HISCOBPR_QUANT_VIDAS, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_QUANT_VIDAS);
                _.Move(executed_1.HISCOBPR_IMPSEGIND, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPSEGIND);
                _.Move(executed_1.HISCOBPR_COD_OPERACAO, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_COD_OPERACAO);
                _.Move(executed_1.HISCOBPR_OPCAO_COBERTURA, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_OPCAO_COBERTURA);
                _.Move(executed_1.HISCOBPR_IMP_MORNATU, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMP_MORNATU);
                _.Move(executed_1.HISCOBPR_IMPMORACID, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPMORACID);
                _.Move(executed_1.HISCOBPR_IMPINVPERM, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPINVPERM);
                _.Move(executed_1.HISCOBPR_IMPAMDS, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPAMDS);
                _.Move(executed_1.HISCOBPR_IMPDH, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPDH);
                _.Move(executed_1.HISCOBPR_IMPDIT, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPDIT);
                _.Move(executed_1.HISCOBPR_VLPREMIO, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_VLPREMIO);
                _.Move(executed_1.HISCOBPR_PRMVG, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_PRMVG);
                _.Move(executed_1.HISCOBPR_PRMAP, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_PRMAP);
                _.Move(executed_1.HISCOBPR_QTDE_TIT_CAPITALIZ, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_QTDE_TIT_CAPITALIZ);
                _.Move(executed_1.HISCOBPR_VAL_TIT_CAPITALIZ, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_VAL_TIT_CAPITALIZ);
                _.Move(executed_1.HISCOBPR_VAL_CUSTO_CAPITALI, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_VAL_CUSTO_CAPITALI);
                _.Move(executed_1.HISCOBPR_IMPSEGCDG, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPSEGCDG);
                _.Move(executed_1.HISCOBPR_VLCUSTCDG, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_VLCUSTCDG);
                _.Move(executed_1.HISCOBPR_COD_USUARIO, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_COD_USUARIO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2300_99_SAIDA*/

        [StopWatch]
        /*" R2310-VALIDA-DT-INIVIGENCIA-SECTION */
        private void R2310_VALIDA_DT_INIVIGENCIA_SECTION()
        {
            /*" -2448- MOVE 'R2310-VALIDA-DT-INIVIGENCIA ' TO PARAGRAFO. */
            _.Move("R2310-VALIDA-DT-INIVIGENCIA ", FILLER_30.FILLER_40.WABEND.PARAGRAFO);

            /*" -2450- MOVE '2310' TO WNR-EXEC-SQL. */
            _.Move("2310", FILLER_30.FILLER_40.WABEND.WNR_EXEC_SQL);

            /*" -2455- PERFORM R2310_VALIDA_DT_INIVIGENCIA_DB_SELECT_1 */

            R2310_VALIDA_DT_INIVIGENCIA_DB_SELECT_1();

            /*" -2458- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2459- MOVE 'NAO' TO WS-FIM-VALIDA-DATA */
                _.Move("NAO", FILLER_30.FILLER_40.WS_FIM_VALIDA_DATA);

                /*" -2462- COMPUTE WHOST-DIA-INIVIGENCIA-1 = WHOST-DIA-INIVIGENCIA-1 - 1 */
                WHOST_DIA_INIVIGENCIA_1.Value = WHOST_DIA_INIVIGENCIA_1 - 1;

                /*" -2464- MOVE WHOST-DIA-INIVIGENCIA-1 TO WHOST-DATA-INIVIGENCIA-1(9:2) */
                _.MoveAtPosition(WHOST_DIA_INIVIGENCIA_1, WHOST_DATA_INIVIGENCIA_1, 9, 2);

                /*" -2465- ELSE */
            }
            else
            {


                /*" -2466- MOVE 'SIM' TO WS-FIM-VALIDA-DATA */
                _.Move("SIM", FILLER_30.FILLER_40.WS_FIM_VALIDA_DATA);

                /*" -2467- END-IF. */
            }


        }

        [StopWatch]
        /*" R2310-VALIDA-DT-INIVIGENCIA-DB-SELECT-1 */
        public void R2310_VALIDA_DT_INIVIGENCIA_DB_SELECT_1()
        {
            /*" -2455- EXEC SQL SELECT DATE(:WHOST-DATA-INIVIGENCIA-1) INTO :WHOST-DATA-INIVIGENCIA FROM SYSIBM.SYSDUMMY1 WITH UR END-EXEC. */

            /*-- linha suprimida por comandos abaixo EXEC SQL
            /*--SELECT DATE(:WHOST-DATA-INIVIGENCIA-1)
            /*--INTO :WHOST-DATA-INIVIGENCIA
            /*--FROM SYSIBM.SYSDUMMY1
            /*--WITH UR
            /*--END-EXEC.
            /*-- */

            _.Move(WHOST_DATA_INIVIGENCIA_1.ToDateTime().ToString(_.CurrentDateFormat), WHOST_DATA_INIVIGENCIA);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2310_99_SAIDA*/

        [StopWatch]
        /*" R2400-00-ACESSA-RELATORIO-SECTION */
        private void R2400_00_ACESSA_RELATORIO_SECTION()
        {
            /*" -2477- MOVE PROPOVA-COD-SUBGRUPO TO WS-COD-SUBGRUPO. */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_SUBGRUPO, WS_COD_SUBGRUPO);

            /*" -2478- IF WS-COD-SUBGRUPO EQUAL ZEROS */

            if (WS_COD_SUBGRUPO == 00)
            {

                /*" -2479- MOVE 1 TO WS-COD-SUBGRUPO */
                _.Move(1, WS_COD_SUBGRUPO);

                /*" -2481- END-IF. */
            }


            /*" -2484- MOVE 'SIM' TO WPROCESSA WTEM-RELATORIO */
            _.Move("SIM", FILLER_30.FILLER_40.WPROCESSA, FILLER_30.FILLER_40.WTEM_RELATORIO);

            /*" -2491- PERFORM R2400_00_ACESSA_RELATORIO_DB_UPDATE_1 */

            R2400_00_ACESSA_RELATORIO_DB_UPDATE_1();

            /*" -2495- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2496- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2498- MOVE 'NAO' TO WPROCESSA WTEM-RELATORIO */
                    _.Move("NAO", FILLER_30.FILLER_40.WPROCESSA, FILLER_30.FILLER_40.WTEM_RELATORIO);

                    /*" -2499- ADD 1 TO AC-DESPREZ-VIG */
                    FILLER_30.AC_DESPREZ_VIG.Value = FILLER_30.AC_DESPREZ_VIG + 1;

                    /*" -2500- ELSE */
                }
                else
                {


                    /*" -2501- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2502- END-IF */
                }


                /*" -2503- END-IF. */
            }


        }

        [StopWatch]
        /*" R2400-00-ACESSA-RELATORIO-DB-UPDATE-1 */
        public void R2400_00_ACESSA_RELATORIO_DB_UPDATE_1()
        {
            /*" -2491- EXEC SQL UPDATE SEGUROS.RELATORIOS SET SIT_REGISTRO = '1' WHERE COD_RELATORIO = 'VG1626B' AND NUM_APOLICE = :PROPOVA-NUM-APOLICE AND COD_SUBGRUPO = :WS-COD-SUBGRUPO AND SIT_REGISTRO = '0' END-EXEC. */

            var r2400_00_ACESSA_RELATORIO_DB_UPDATE_1_Update1 = new R2400_00_ACESSA_RELATORIO_DB_UPDATE_1_Update1()
            {
                PROPOVA_NUM_APOLICE = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE.ToString(),
                WS_COD_SUBGRUPO = WS_COD_SUBGRUPO.ToString(),
            };

            R2400_00_ACESSA_RELATORIO_DB_UPDATE_1_Update1.Execute(r2400_00_ACESSA_RELATORIO_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2400_99_SAIDA*/

        [StopWatch]
        /*" R2900-00-INSERT-COBERPROPVA-SECTION */
        private void R2900_00_INSERT_COBERPROPVA_SECTION()
        {
            /*" -2515- MOVE 'R2900-00-INSERT-COBERPROPVA' TO PARAGRAFO */
            _.Move("R2900-00-INSERT-COBERPROPVA", FILLER_30.FILLER_40.WABEND.PARAGRAFO);

            /*" -2517- INITIALIZE PARAMETROS. */
            _.Initialize(
                PARAMETROS
            );

            /*" -2518- MOVE PROPOVA-NUM-APOLICE TO LK710-APOLICE OF PARAMETROS. */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE, PARAMETROS.LK710_APOLICE);

            /*" -2522- MOVE WHOST-COD-SUBGRUPO TO LK710-SUBGRUPO OF PARAMETROS. */
            _.Move(WHOST_COD_SUBGRUPO, PARAMETROS.LK710_SUBGRUPO);

            /*" -2523- MOVE WHOST-IMPSEG TO LK710-PU-MORTE-NATURAL OF PARAMETROS. */
            _.Move(WHOST_IMPSEG, PARAMETROS.LK710_PU_MORTE_NATURAL);

            /*" -2525- MOVE ZEROS TO LK710-PU-MORTE-ACIDENTAL OF PARAMETROS. */
            _.Move(0, PARAMETROS.LK710_PU_MORTE_ACIDENTAL);

            /*" -2527- CALL 'VG0710S' USING PARAMETROS. */
            _.Call("VG0710S", PARAMETROS);

            /*" -2528- IF (LK710-RETURN-CODE NOT EQUAL ZEROS) */

            if ((PARAMETROS.LK710_RETURN_CODE != 00))
            {

                /*" -2529- DISPLAY '** PROBLEMA COM SUBROTINA VG0710S **' */
                _.Display($"** PROBLEMA COM SUBROTINA VG0710S **");

                /*" -2530- DISPLAY 'CERTIF. : ' PROPOVA-NUM-CERTIFICADO */
                _.Display($"CERTIF. : {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                /*" -2531- DISPLAY 'MENSAGEM DA VG0710S -> ' LK710-MENSAGEM */
                _.Display($"MENSAGEM DA VG0710S -> {PARAMETROS.LK710_MENSAGEM}");

                /*" -2532- DISPLAY 'COD.ERRO DA VG0710S -> ' LK710-RETURN-CODE */
                _.Display($"COD.ERRO DA VG0710S -> {PARAMETROS.LK710_RETURN_CODE}");

                /*" -2533- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2535- END-IF. */
            }


            /*" -2536- MOVE LK710-CO-MORTE-NATURAL TO HISCOBPR-IMP-MORNATU. */
            _.Move(PARAMETROS.LK710_CO_MORTE_NATURAL, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMP_MORNATU);

            /*" -2537- MOVE LK710-CO-MORTE-NATURAL TO HISCOBPR-IMPSEGIND. */
            _.Move(PARAMETROS.LK710_CO_MORTE_NATURAL, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPSEGIND);

            /*" -2538- MOVE LK710-CO-MORTE-NATURAL TO HISCOBPR-IMPSEGUR. */
            _.Move(PARAMETROS.LK710_CO_MORTE_NATURAL, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPSEGUR);

            /*" -2539- MOVE LK710-CO-MORTE-ACIDENTAL TO HISCOBPR-IMPMORACID. */
            _.Move(PARAMETROS.LK710_CO_MORTE_ACIDENTAL, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPMORACID);

            /*" -2540- MOVE LK710-CO-INV-PERMANENTE TO HISCOBPR-IMPINVPERM. */
            _.Move(PARAMETROS.LK710_CO_INV_PERMANENTE, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPINVPERM);

            /*" -2541- MOVE LK710-CO-ASS-MEDICA TO HISCOBPR-IMPAMDS. */
            _.Move(PARAMETROS.LK710_CO_ASS_MEDICA, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPAMDS);

            /*" -2542- MOVE LK710-CO-DI-HOSPITALAR TO HISCOBPR-IMPDH. */
            _.Move(PARAMETROS.LK710_CO_DI_HOSPITALAR, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPDH);

            /*" -2544- MOVE LK710-CO-DI-INTERNACAO TO HISCOBPR-IMPDIT. */
            _.Move(PARAMETROS.LK710_CO_DI_INTERNACAO, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPDIT);

            /*" -2545- IF (HISCOBPR-IMP-MORNATU EQUAL ZEROS) */

            if ((HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMP_MORNATU == 00))
            {

                /*" -2547- MOVE HISCOBPR-IMPMORACID TO HISCOBPR-IMPSEGIND HISCOBPR-IMPSEGUR */
                _.Move(HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPMORACID, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPSEGIND, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPSEGUR);

                /*" -2548- ELSE */
            }
            else
            {


                /*" -2550- MOVE HISCOBPR-IMP-MORNATU TO HISCOBPR-IMPSEGIND HISCOBPR-IMPSEGUR */
                _.Move(HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMP_MORNATU, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPSEGIND, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPSEGUR);

                /*" -2556- END-IF. */
            }


            /*" -2559- MOVE ZEROS TO HISCOBPR-IMPSEGCDG HISCOBPR-VLCUSTCDG. */
            _.Move(0, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPSEGCDG, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_VLCUSTCDG);

            /*" -2560- MOVE WHOST-DATA-INIVIGENCIA TO HISCOBPR-DATA-INIVIGENCIA. */
            _.Move(WHOST_DATA_INIVIGENCIA, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_DATA_INIVIGENCIA);

            /*" -2562- MOVE '9999-12-31' TO HISCOBPR-DATA-TERVIGENCIA. */
            _.Move("9999-12-31", HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_DATA_TERVIGENCIA);

            /*" -2573- COMPUTE HISCOBPR-OCORR-HISTORICO = PROPOVA-OCORR-HISTORICO + 1 */
            HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_OCORR_HISTORICO.Value = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_OCORR_HISTORICO + 1;

            /*" -2574- IF (APOLICES-RAMO-EMISSOR EQUAL 82) */

            if ((APOLICES.DCLAPOLICES.APOLICES_RAMO_EMISSOR == 82))
            {

                /*" -2575- MOVE 0 TO HISCOBPR-PRMVG */
                _.Move(0, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_PRMVG);

                /*" -2576- MOVE WHOST-PRMVG TO HISCOBPR-PRMAP */
                _.Move(WHOST_PRMVG, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_PRMAP);

                /*" -2577- ELSE */
            }
            else
            {


                /*" -2578- MOVE 0 TO HISCOBPR-PRMAP */
                _.Move(0, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_PRMAP);

                /*" -2579- MOVE WHOST-PRMVG TO HISCOBPR-PRMVG */
                _.Move(WHOST_PRMVG, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_PRMVG);

                /*" -2581- END-IF. */
            }


            /*" -2583- MOVE WHOST-QTDSEG TO HISCOBPR-QUANT-VIDAS. */
            _.Move(WHOST_QTDSEG, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_QUANT_VIDAS);

            /*" -2585- COMPUTE HISCOBPR-VLPREMIO = HISCOBPR-PRMVG + HISCOBPR-PRMAP. */
            HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_VLPREMIO.Value = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_PRMVG + HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_PRMAP;

            /*" -2587- MOVE 'VG1626B ' TO HISCOBPR-COD-USUARIO. */
            _.Move("VG1626B ", HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_COD_USUARIO);

            /*" -2589- MOVE '2900' TO WNR-EXEC-SQL. */
            _.Move("2900", FILLER_30.FILLER_40.WABEND.WNR_EXEC_SQL);

            /*" -2650- PERFORM R2900_00_INSERT_COBERPROPVA_DB_INSERT_1 */

            R2900_00_INSERT_COBERPROPVA_DB_INSERT_1();

            /*" -2653- IF (SQLCODE NOT EQUAL ZEROES) */

            if ((DB.SQLCODE != 00))
            {

                /*" -2654- IF (SQLCODE EQUAL -803) */

                if ((DB.SQLCODE == -803))
                {

                    /*" -2655- MOVE 'S' TO WTEM-COBERPROPVA */
                    _.Move("S", FILLER_30.FILLER_40.WTEM_COBERPROPVA);

                    /*" -2658- DISPLAY 'JA EXISTE NA HIS_COBER_PROPOST        ..' PROPOVA-NUM-CERTIFICADO ' ' HISCOBPR-OCORR-HISTORICO ' ' HISCOBPR-DATA-INIVIGENCIA ' ' SQLCODE */

                    $"JA EXISTE NA HIS_COBER_PROPOST        ..{PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO} {HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_OCORR_HISTORICO} {HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_DATA_INIVIGENCIA} {DB.SQLCODE}"
                    .Display();

                    /*" -2659- ELSE */
                }
                else
                {


                    /*" -2662- DISPLAY 'PROBLEMA INSERT HIS_COBER_PROPOST     ..' PROPOVA-NUM-CERTIFICADO ' ' HISCOBPR-OCORR-HISTORICO ' ' HISCOBPR-DATA-INIVIGENCIA ' ' SQLCODE */

                    $"PROBLEMA INSERT HIS_COBER_PROPOST     ..{PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO} {HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_OCORR_HISTORICO} {HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_DATA_INIVIGENCIA} {DB.SQLCODE}"
                    .Display();

                    /*" -2663- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2664- END-IF */
                }


                /*" -2665- ELSE */
            }
            else
            {


                /*" -2666- MOVE 'N' TO WTEM-COBERPROPVA */
                _.Move("N", FILLER_30.FILLER_40.WTEM_COBERPROPVA);

                /*" -2668- END-IF. */
            }


            /*" -2668- ADD 1 TO AC-I-COBERPROPVA. */
            FILLER_30.AC_I_COBERPROPVA.Value = FILLER_30.AC_I_COBERPROPVA + 1;

        }

        [StopWatch]
        /*" R2900-00-INSERT-COBERPROPVA-DB-INSERT-1 */
        public void R2900_00_INSERT_COBERPROPVA_DB_INSERT_1()
        {
            /*" -2650- EXEC SQL INSERT INTO SEGUROS.HIS_COBER_PROPOST (NUM_CERTIFICADO , OCORR_HISTORICO , DATA_INIVIGENCIA , DATA_TERVIGENCIA , IMPSEGUR , QUANT_VIDAS , IMPSEGIND , COD_OPERACAO , OPCAO_COBERTURA , IMP_MORNATU , IMPMORACID , IMPINVPERM , IMPAMDS , IMPDH , IMPDIT , VLPREMIO , PRMVG , PRMAP , QTDE_TIT_CAPITALIZ, VAL_TIT_CAPITALIZ , VAL_CUSTO_CAPITALI, IMPSEGCDG , VLCUSTCDG , COD_USUARIO , TIMESTAMP , IMPSEGAUXF , VLCUSTAUXF , PRMDIT , QTMDIT ) VALUES (:PROPOVA-NUM-CERTIFICADO, :HISCOBPR-OCORR-HISTORICO, :HISCOBPR-DATA-INIVIGENCIA, :HISCOBPR-DATA-TERVIGENCIA, :HISCOBPR-IMPSEGUR, :HISCOBPR-QUANT-VIDAS, :HISCOBPR-IMPSEGIND, :HISCOBPR-COD-OPERACAO, ' ' , :HISCOBPR-IMP-MORNATU, :HISCOBPR-IMPMORACID, :HISCOBPR-IMPINVPERM, :HISCOBPR-IMPAMDS, :HISCOBPR-IMPDH, :HISCOBPR-IMPDIT, :HISCOBPR-VLPREMIO, :HISCOBPR-PRMVG, :HISCOBPR-PRMAP, :HISCOBPR-QTDE-TIT-CAPITALIZ, :HISCOBPR-VAL-TIT-CAPITALIZ, :HISCOBPR-VAL-CUSTO-CAPITALI, :HISCOBPR-IMPSEGCDG, :HISCOBPR-VLCUSTCDG, 'VG1626B' , CURRENT TIMESTAMP, NULL, NULL, NULL, NULL) END-EXEC. */

            var r2900_00_INSERT_COBERPROPVA_DB_INSERT_1_Insert1 = new R2900_00_INSERT_COBERPROPVA_DB_INSERT_1_Insert1()
            {
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
                HISCOBPR_OCORR_HISTORICO = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_OCORR_HISTORICO.ToString(),
                HISCOBPR_DATA_INIVIGENCIA = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_DATA_INIVIGENCIA.ToString(),
                HISCOBPR_DATA_TERVIGENCIA = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_DATA_TERVIGENCIA.ToString(),
                HISCOBPR_IMPSEGUR = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPSEGUR.ToString(),
                HISCOBPR_QUANT_VIDAS = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_QUANT_VIDAS.ToString(),
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

            R2900_00_INSERT_COBERPROPVA_DB_INSERT_1_Insert1.Execute(r2900_00_INSERT_COBERPROPVA_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2900_99_SAIDA*/

        [StopWatch]
        /*" R2910-00-UPDATE-COBERPROPVA-SECTION */
        private void R2910_00_UPDATE_COBERPROPVA_SECTION()
        {
            /*" -2677- MOVE 'R2910-00-UPDATE-COBERPROPVA' TO PARAGRAFO. */
            _.Move("R2910-00-UPDATE-COBERPROPVA", FILLER_30.FILLER_40.WABEND.PARAGRAFO);

            /*" -2678- MOVE '2910' TO WNR-EXEC-SQL. */
            _.Move("2910", FILLER_30.FILLER_40.WABEND.WNR_EXEC_SQL);

            /*" -2691- MOVE 'S' TO WS-COBERPROPVA. */
            _.Move("S", WS_COBERPROPVA);

            /*" -2697- PERFORM R2910_00_UPDATE_COBERPROPVA_DB_UPDATE_1 */

            R2910_00_UPDATE_COBERPROPVA_DB_UPDATE_1();

            /*" -2701- MOVE '4100' TO WNR-EXEC-SQL. */
            _.Move("4100", FILLER_30.FILLER_40.WABEND.WNR_EXEC_SQL);

            /*" -2702- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2703- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2704- MOVE 'N' TO WS-COBERPROPVA */
                    _.Move("N", WS_COBERPROPVA);

                    /*" -2706- DISPLAY '(R2910) NUM_CERTIFICADO : ' ' ' PROPOVA-NUM-CERTIFICADO ' ' PROPOVA-OCORR-HISTORICO */

                    $"(R2910) NUM_CERTIFICADO :  {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO} {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_OCORR_HISTORICO}"
                    .Display();

                    /*" -2707- GO TO R2910-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R2910_99_SAIDA*/ //GOTO
                    return;

                    /*" -2708- ELSE */
                }
                else
                {


                    /*" -2710- DISPLAY 'ERRO  DE ACESSO A HIS_COBER_PROPOST ' PROPOVA-NUM-CERTIFICADO */
                    _.Display($"ERRO  DE ACESSO A HIS_COBER_PROPOST {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                    /*" -2711- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2712- END-IF */
                }


                /*" -2714- END-IF. */
            }


            /*" -2715- MOVE HISCOBPR-OCORR-HISTORICO TO PROPOVA-OCORR-HISTORICO. */
            _.Move(HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_OCORR_HISTORICO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_OCORR_HISTORICO);

        }

        [StopWatch]
        /*" R2910-00-UPDATE-COBERPROPVA-DB-UPDATE-1 */
        public void R2910_00_UPDATE_COBERPROPVA_DB_UPDATE_1()
        {
            /*" -2697- EXEC SQL UPDATE SEGUROS.HIS_COBER_PROPOST SET DATA_TERVIGENCIA = DATE(:HISCOBPR-DATA-INIVIGENCIA) - 1 DAY WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO AND OCORR_HISTORICO = :PROPOVA-OCORR-HISTORICO END-EXEC. */

            var r2910_00_UPDATE_COBERPROPVA_DB_UPDATE_1_Update1 = new R2910_00_UPDATE_COBERPROPVA_DB_UPDATE_1_Update1()
            {
                HISCOBPR_DATA_INIVIGENCIA = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_DATA_INIVIGENCIA.ToString(),
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
                PROPOVA_OCORR_HISTORICO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_OCORR_HISTORICO.ToString(),
            };

            R2910_00_UPDATE_COBERPROPVA_DB_UPDATE_1_Update1.Execute(r2910_00_UPDATE_COBERPROPVA_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2910_99_SAIDA*/

        [StopWatch]
        /*" R2920-00-UPDATE-PROPOSTAVA-SECTION */
        private void R2920_00_UPDATE_PROPOSTAVA_SECTION()
        {
            /*" -2726- MOVE 'R2920-00-UPDATE-PROPOSTAVA ' TO PARAGRAFO. */
            _.Move("R2920-00-UPDATE-PROPOSTAVA ", FILLER_30.FILLER_40.WABEND.PARAGRAFO);

            /*" -2738- MOVE '4200' TO WNR-EXEC-SQL. */
            _.Move("4200", FILLER_30.FILLER_40.WABEND.WNR_EXEC_SQL);

            /*" -2742- PERFORM R2920_00_UPDATE_PROPOSTAVA_DB_UPDATE_1 */

            R2920_00_UPDATE_PROPOSTAVA_DB_UPDATE_1();

            /*" -2745- MOVE '4200' TO WNR-EXEC-SQL. */
            _.Move("4200", FILLER_30.FILLER_40.WABEND.WNR_EXEC_SQL);

            /*" -2746- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2748- DISPLAY 'ERRO  DE ACESSO A PROPOSTAS_VA ' PROPOVA-NUM-CERTIFICADO */
                _.Display($"ERRO  DE ACESSO A PROPOSTAS_VA {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                /*" -2748- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2920-00-UPDATE-PROPOSTAVA-DB-UPDATE-1 */
        public void R2920_00_UPDATE_PROPOSTAVA_DB_UPDATE_1()
        {
            /*" -2742- EXEC SQL UPDATE SEGUROS.PROPOSTAS_VA SET OCORR_HISTORICO = :HISCOBPR-OCORR-HISTORICO WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO END-EXEC. */

            var r2920_00_UPDATE_PROPOSTAVA_DB_UPDATE_1_Update1 = new R2920_00_UPDATE_PROPOSTAVA_DB_UPDATE_1_Update1()
            {
                HISCOBPR_OCORR_HISTORICO = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_OCORR_HISTORICO.ToString(),
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
            };

            R2920_00_UPDATE_PROPOSTAVA_DB_UPDATE_1_Update1.Execute(r2920_00_UPDATE_PROPOSTAVA_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2920_99_SAIDA*/

        [StopWatch]
        /*" R3000-00-AJUSTA-COBRANCA-SECTION */
        private void R3000_00_AJUSTA_COBRANCA_SECTION()
        {
            /*" -2758- MOVE 'R3000-00-PROCESSA-REGISTRO' TO PARAGRAFO. */
            _.Move("R3000-00-PROCESSA-REGISTRO", FILLER_30.FILLER_40.WABEND.PARAGRAFO);

            /*" -2762- MOVE '3000' TO WNR-EXEC-SQL. */
            _.Move("3000", FILLER_30.FILLER_40.WABEND.WNR_EXEC_SQL);

            /*" -2764- PERFORM R3100-00-UPDATE-COBERPROPVA. */

            R3100_00_UPDATE_COBERPROPVA_SECTION();

            /*" -2766- PERFORM R3200-00-UPDATE-PARCELVA. */

            R3200_00_UPDATE_PARCELVA_SECTION();

            /*" -2768- PERFORM R3300-00-UPDATE-HISTCOBVA. */

            R3300_00_UPDATE_HISTCOBVA_SECTION();

            /*" -2768- PERFORM R3400-00-UPDATE-HISTLANCTA. */

            R3400_00_UPDATE_HISTLANCTA_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_99_SAIDA*/

        [StopWatch]
        /*" R3100-00-UPDATE-COBERPROPVA-SECTION */
        private void R3100_00_UPDATE_COBERPROPVA_SECTION()
        {
            /*" -2779- MOVE 'R3100-00-UPDATE-COBERPROPVA' TO PARAGRAFO. */
            _.Move("R3100-00-UPDATE-COBERPROPVA", FILLER_30.FILLER_40.WABEND.PARAGRAFO);

            /*" -2789- MOVE '3100' TO WNR-EXEC-SQL. */
            _.Move("3100", FILLER_30.FILLER_40.WABEND.WNR_EXEC_SQL);

            /*" -2790- IF APOLICES-RAMO-EMISSOR EQUAL 82 */

            if (APOLICES.DCLAPOLICES.APOLICES_RAMO_EMISSOR == 82)
            {

                /*" -2792- MOVE 0 TO HISCOBPR-PRMVG */
                _.Move(0, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_PRMVG);

                /*" -2794- MOVE WHOST-PRMVG TO HISCOBPR-PRMAP */
                _.Move(WHOST_PRMVG, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_PRMAP);

                /*" -2795- ELSE */
            }
            else
            {


                /*" -2797- MOVE 0 TO HISCOBPR-PRMAP */
                _.Move(0, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_PRMAP);

                /*" -2799- MOVE WHOST-PRMVG TO HISCOBPR-PRMVG */
                _.Move(WHOST_PRMVG, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_PRMVG);

                /*" -2802- END-IF. */
            }


            /*" -2815- PERFORM R3100_00_UPDATE_COBERPROPVA_DB_UPDATE_1 */

            R3100_00_UPDATE_COBERPROPVA_DB_UPDATE_1();

            /*" -2818- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2819- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2821- DISPLAY '(R3100) CERTIFICADO :' ' ' PROPOVA-NUM-CERTIFICADO ' ' PROPOVA-OCORR-HISTORICO */

                    $"(R3100) CERTIFICADO : {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO} {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_OCORR_HISTORICO}"
                    .Display();

                    /*" -2822- GO TO R3100-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R3100_99_SAIDA*/ //GOTO
                    return;

                    /*" -2823- ELSE */
                }
                else
                {


                    /*" -2825- DISPLAY 'ERRO  DE ACESSO A HIS_COBER_PROPOST ' PROPOVA-NUM-CERTIFICADO */
                    _.Display($"ERRO  DE ACESSO A HIS_COBER_PROPOST {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                    /*" -2835- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -2835- ADD 1 TO AC-U-COBERPROPVA. */
            FILLER_30.AC_U_COBERPROPVA.Value = FILLER_30.AC_U_COBERPROPVA + 1;

        }

        [StopWatch]
        /*" R3100-00-UPDATE-COBERPROPVA-DB-UPDATE-1 */
        public void R3100_00_UPDATE_COBERPROPVA_DB_UPDATE_1()
        {
            /*" -2815- EXEC SQL UPDATE SEGUROS.HIS_COBER_PROPOST SET IMPSEGUR = :WHOST-IMPSEG, IMPSEGIND = :WHOST-IMPSEG, IMP_MORNATU = :WHOST-IMPSEG, QUANT_VIDAS = :WHOST-QTDSEG, VLPREMIO = :WHOST-PRMVG, PRMVG = :HISCOBPR-PRMVG, PRMAP = :HISCOBPR-PRMAP, COD_USUARIO = 'VG1626B' WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO AND OCORR_HISTORICO = :PROPOVA-OCORR-HISTORICO END-EXEC. */

            var r3100_00_UPDATE_COBERPROPVA_DB_UPDATE_1_Update1 = new R3100_00_UPDATE_COBERPROPVA_DB_UPDATE_1_Update1()
            {
                HISCOBPR_PRMVG = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_PRMVG.ToString(),
                HISCOBPR_PRMAP = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_PRMAP.ToString(),
                WHOST_IMPSEG = WHOST_IMPSEG.ToString(),
                WHOST_QTDSEG = WHOST_QTDSEG.ToString(),
                WHOST_PRMVG = WHOST_PRMVG.ToString(),
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
                PROPOVA_OCORR_HISTORICO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_OCORR_HISTORICO.ToString(),
            };

            R3100_00_UPDATE_COBERPROPVA_DB_UPDATE_1_Update1.Execute(r3100_00_UPDATE_COBERPROPVA_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3100_99_SAIDA*/

        [StopWatch]
        /*" R3200-00-UPDATE-PARCELVA-SECTION */
        private void R3200_00_UPDATE_PARCELVA_SECTION()
        {
            /*" -2846- MOVE 'R3200-00-UPDATE-PARCELVA   ' TO PARAGRAFO. */
            _.Move("R3200-00-UPDATE-PARCELVA   ", FILLER_30.FILLER_40.WABEND.PARAGRAFO);

            /*" -2850- MOVE '3200' TO WNR-EXEC-SQL. */
            _.Move("3200", FILLER_30.FILLER_40.WABEND.WNR_EXEC_SQL);

            /*" -2851- IF APOLICES-RAMO-EMISSOR EQUAL 82 */

            if (APOLICES.DCLAPOLICES.APOLICES_RAMO_EMISSOR == 82)
            {

                /*" -2853- MOVE 0 TO WHOST-PREMIO-VG */
                _.Move(0, WHOST_PREMIO_VG);

                /*" -2855- MOVE WHOST-PRMVG TO WHOST-PREMIO-AP */
                _.Move(WHOST_PRMVG, WHOST_PREMIO_AP);

                /*" -2856- ELSE */
            }
            else
            {


                /*" -2858- MOVE 0 TO WHOST-PREMIO-AP */
                _.Move(0, WHOST_PREMIO_AP);

                /*" -2860- MOVE WHOST-PRMVG TO WHOST-PREMIO-VG */
                _.Move(WHOST_PRMVG, WHOST_PREMIO_VG);

                /*" -2862- END-IF. */
            }


            /*" -2869- PERFORM R3200_00_UPDATE_PARCELVA_DB_UPDATE_1 */

            R3200_00_UPDATE_PARCELVA_DB_UPDATE_1();

            /*" -2872- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2873- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2875- DISPLAY '(R3200) CERTIFICADO :' ' ' PROPOVA-NUM-CERTIFICADO ' ' PROPOVA-OCORR-HISTORICO */

                    $"(R3200) CERTIFICADO : {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO} {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_OCORR_HISTORICO}"
                    .Display();

                    /*" -2876- GO TO R3200-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R3200_99_SAIDA*/ //GOTO
                    return;

                    /*" -2877- ELSE */
                }
                else
                {


                    /*" -2879- DISPLAY 'ERRO  DE ACESSO A PARCELAS_VIDAZUL  ' PROPOVA-NUM-CERTIFICADO */
                    _.Display($"ERRO  DE ACESSO A PARCELAS_VIDAZUL  {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                    /*" -2881- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -2881- ADD 1 TO AC-U-PARCELVA. */
            FILLER_30.AC_U_PARCELVA.Value = FILLER_30.AC_U_PARCELVA + 1;

        }

        [StopWatch]
        /*" R3200-00-UPDATE-PARCELVA-DB-UPDATE-1 */
        public void R3200_00_UPDATE_PARCELVA_DB_UPDATE_1()
        {
            /*" -2869- EXEC SQL UPDATE SEGUROS.PARCELAS_VIDAZUL SET PREMIO_VG = :WHOST-PREMIO-VG, PREMIO_AP = :WHOST-PREMIO-AP WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO AND NUM_PARCELA = :PROPOVA-NUM-PARCELA END-EXEC. */

            var r3200_00_UPDATE_PARCELVA_DB_UPDATE_1_Update1 = new R3200_00_UPDATE_PARCELVA_DB_UPDATE_1_Update1()
            {
                WHOST_PREMIO_VG = WHOST_PREMIO_VG.ToString(),
                WHOST_PREMIO_AP = WHOST_PREMIO_AP.ToString(),
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
                PROPOVA_NUM_PARCELA = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_PARCELA.ToString(),
            };

            R3200_00_UPDATE_PARCELVA_DB_UPDATE_1_Update1.Execute(r3200_00_UPDATE_PARCELVA_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3200_99_SAIDA*/

        [StopWatch]
        /*" R3300-00-UPDATE-HISTCOBVA-SECTION */
        private void R3300_00_UPDATE_HISTCOBVA_SECTION()
        {
            /*" -2892- MOVE 'R3300-00-UPDATE-HISTCOBVA  ' TO PARAGRAFO. */
            _.Move("R3300-00-UPDATE-HISTCOBVA  ", FILLER_30.FILLER_40.WABEND.PARAGRAFO);

            /*" -2896- MOVE '3300' TO WNR-EXEC-SQL. */
            _.Move("3300", FILLER_30.FILLER_40.WABEND.WNR_EXEC_SQL);

            /*" -2902- PERFORM R3300_00_UPDATE_HISTCOBVA_DB_UPDATE_1 */

            R3300_00_UPDATE_HISTCOBVA_DB_UPDATE_1();

            /*" -2905- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2906- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2908- DISPLAY '(R3300) CERTIFICADO :' ' ' PROPOVA-NUM-CERTIFICADO ' ' PROPOVA-OCORR-HISTORICO */

                    $"(R3300) CERTIFICADO : {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO} {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_OCORR_HISTORICO}"
                    .Display();

                    /*" -2909- GO TO R3300-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R3300_99_SAIDA*/ //GOTO
                    return;

                    /*" -2910- ELSE */
                }
                else
                {


                    /*" -2912- DISPLAY 'ERRO  DE ACESSO A COBER_HIST_VIDAZUL' PROPOVA-NUM-CERTIFICADO */
                    _.Display($"ERRO  DE ACESSO A COBER_HIST_VIDAZUL{PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                    /*" -2913- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2914- END-IF */
                }


                /*" -2916- END-IF. */
            }


            /*" -2916- ADD 1 TO AC-U-HISTCOBVA. */
            FILLER_30.AC_U_HISTCOBVA.Value = FILLER_30.AC_U_HISTCOBVA + 1;

        }

        [StopWatch]
        /*" R3300-00-UPDATE-HISTCOBVA-DB-UPDATE-1 */
        public void R3300_00_UPDATE_HISTCOBVA_DB_UPDATE_1()
        {
            /*" -2902- EXEC SQL UPDATE SEGUROS.COBER_HIST_VIDAZUL SET PRM_TOTAL = :WHOST-PRMVG, SIT_REGISTRO = '5' WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO AND NUM_PARCELA = :PROPOVA-NUM-PARCELA END-EXEC. */

            var r3300_00_UPDATE_HISTCOBVA_DB_UPDATE_1_Update1 = new R3300_00_UPDATE_HISTCOBVA_DB_UPDATE_1_Update1()
            {
                WHOST_PRMVG = WHOST_PRMVG.ToString(),
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
                PROPOVA_NUM_PARCELA = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_PARCELA.ToString(),
            };

            R3300_00_UPDATE_HISTCOBVA_DB_UPDATE_1_Update1.Execute(r3300_00_UPDATE_HISTCOBVA_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3300_99_SAIDA*/

        [StopWatch]
        /*" R3400-00-UPDATE-HISTLANCTA-SECTION */
        private void R3400_00_UPDATE_HISTLANCTA_SECTION()
        {
            /*" -2927- MOVE 'R3400-00-UPDATE-HISTLANCTA ' TO PARAGRAFO. */
            _.Move("R3400-00-UPDATE-HISTLANCTA ", FILLER_30.FILLER_40.WABEND.PARAGRAFO);

            /*" -2931- MOVE '3400' TO WNR-EXEC-SQL. */
            _.Move("3400", FILLER_30.FILLER_40.WABEND.WNR_EXEC_SQL);

            /*" -2937- PERFORM R3400_00_UPDATE_HISTLANCTA_DB_UPDATE_1 */

            R3400_00_UPDATE_HISTLANCTA_DB_UPDATE_1();

            /*" -2940- IF SQLCODE NOT EQUAL ZEROS AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -2942- DISPLAY 'ERRO  DE UPDATE NA HIST_LANC_CTA ' PROPOVA-NUM-CERTIFICADO */
                _.Display($"ERRO  DE UPDATE NA HIST_LANC_CTA {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                /*" -2943- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2945- END-IF. */
            }


            /*" -2945- ADD 1 TO AC-U-HISTLANCTA. */
            FILLER_30.AC_U_HISTLANCTA.Value = FILLER_30.AC_U_HISTLANCTA + 1;

        }

        [StopWatch]
        /*" R3400-00-UPDATE-HISTLANCTA-DB-UPDATE-1 */
        public void R3400_00_UPDATE_HISTLANCTA_DB_UPDATE_1()
        {
            /*" -2937- EXEC SQL UPDATE SEGUROS.HIST_LANC_CTA SET PRM_TOTAL = :WHOST-PRMVG WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO AND NUM_PARCELA = :PROPOVA-OCORR-HISTORICO AND SIT_REGISTRO IN ( '0' , ' ' ) END-EXEC. */

            var r3400_00_UPDATE_HISTLANCTA_DB_UPDATE_1_Update1 = new R3400_00_UPDATE_HISTLANCTA_DB_UPDATE_1_Update1()
            {
                WHOST_PRMVG = WHOST_PRMVG.ToString(),
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
                PROPOVA_OCORR_HISTORICO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_OCORR_HISTORICO.ToString(),
            };

            R3400_00_UPDATE_HISTLANCTA_DB_UPDATE_1_Update1.Execute(r3400_00_UPDATE_HISTLANCTA_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3400_99_SAIDA*/

        [StopWatch]
        /*" R8000-00-CLOSE-TRAILLER-SECTION */
        private void R8000_00_CLOSE_TRAILLER_SECTION()
        {
            /*" -2956- MOVE SPACES TO VG1626BO-TRAILLER */
            _.Move("", VG1626BO_TRAILLER);

            /*" -2957- MOVE 003 TO VG1626BO-H-TIP-REG */
            _.Move(003, VG1626BO_HEADER.VG1626BO_H_TIP_REG);

            /*" -2958- ADD 001 TO AC-SEQ-REG-ARQ */
            FILLER_30.AC_SEQ_REG_ARQ.Value = FILLER_30.AC_SEQ_REG_ARQ + 001;

            /*" -2959- MOVE AC-SEQ-REG-ARQ TO VG1626BO-T-SEQ-REG */
            _.Move(FILLER_30.AC_SEQ_REG_ARQ, VG1626BO_TRAILLER.VG1626BO_T_SEQ_REG);

            /*" -2960- COMPUTE VG1626BO-T-QTD-CER = AC-VG1626BO-GRV - 001 */
            VG1626BO_TRAILLER.VG1626BO_T_QTD_CER.Value = FILLER_30.AC_VG1626BO_GRV - 001;

            /*" -2961- MOVE AC-TOT-CER-O TO VG1626BO-T-TOT-CER */
            _.Move(FILLER_30.AC_TOT_CER_O, VG1626BO_TRAILLER.VG1626BO_T_TOT_CER);

            /*" -2963- MOVE VG1626BO-TRAILLER TO VG1626BD-TRAILLER */
            _.Move(VG1626BO?.Value, VG1626BD_TRAILLER);

            /*" -2965- WRITE VG1626BO-TRAILLER */
            VG1626BO.Write(VG1626BO_TRAILLER.GetMoveValues().ToString());

            /*" -2966- IF VG1626BO-NORMAL */

            if (WS_NIVEIS_88.N88_VG1626BO_STATUS["VG1626BO_NORMAL"])
            {

                /*" -2967- ADD 001 TO AC-VG1626BO-GRV */
                FILLER_30.AC_VG1626BO_GRV.Value = FILLER_30.AC_VG1626BO_GRV + 001;

                /*" -2968- ELSE */
            }
            else
            {


                /*" -2969- DISPLAY '***' */
                _.Display($"***");

                /*" -2970- DISPLAY ' R8000-00-CLOSE-TRAILLER  ' */
                _.Display($" R8000-00-CLOSE-TRAILLER  ");

                /*" -2971- DISPLAY ' ERRO WRITE VG1626BO ST = ' N88-VG1626BO-STATUS */
                _.Display($" ERRO WRITE VG1626BO ST = {WS_NIVEIS_88.N88_VG1626BO_STATUS}");

                /*" -2972- DISPLAY '***' */
                _.Display($"***");

                /*" -2973- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2975- END-IF */
            }


            /*" -2976- COMPUTE VG1626BD-T-QTD-CER = AC-VG1626BD-GRV - 001 */
            VG1626BD_TRAILLER.VG1626BD_T_QTD_CER.Value = FILLER_30.AC_VG1626BD_GRV - 001;

            /*" -2978- MOVE AC-TOT-CER-D TO VG1626BD-T-TOT-CER */
            _.Move(FILLER_30.AC_TOT_CER_D, VG1626BD_TRAILLER.VG1626BD_T_TOT_CER);

            /*" -2980- WRITE VG1626BD-TRAILLER */
            VG1626BD.Write(VG1626BD_TRAILLER.GetMoveValues().ToString());

            /*" -2981- IF VG1626BD-NORMAL */

            if (WS_NIVEIS_88.N88_VG1626BD_STATUS["VG1626BD_NORMAL"])
            {

                /*" -2982- ADD 001 TO AC-VG1626BD-GRV */
                FILLER_30.AC_VG1626BD_GRV.Value = FILLER_30.AC_VG1626BD_GRV + 001;

                /*" -2983- CLOSE VG1626BO VG1626BD */
                VG1626BO.Close();
                VG1626BD.Close();

                /*" -2984- ELSE */
            }
            else
            {


                /*" -2985- DISPLAY '***' */
                _.Display($"***");

                /*" -2986- DISPLAY ' R8000-00-CLOSE-TRAILLER  ' */
                _.Display($" R8000-00-CLOSE-TRAILLER  ");

                /*" -2987- DISPLAY ' ERRO WRITE VG1626BD ST = ' N88-VG1626BD-STATUS */
                _.Display($" ERRO WRITE VG1626BD ST = {WS_NIVEIS_88.N88_VG1626BD_STATUS}");

                /*" -2988- DISPLAY '***' */
                _.Display($"***");

                /*" -2989- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2991- END-IF */
            }


            /*" -2991- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8000_99_SAIDA*/

        [StopWatch]
        /*" R9000-00-FINALIZA-SECTION */
        private void R9000_00_FINALIZA_SECTION()
        {
            /*" -3001- MOVE 'R9000-00-FINALIZA' TO PARAGRAFO. */
            _.Move("R9000-00-FINALIZA", FILLER_30.FILLER_40.WABEND.PARAGRAFO);

            /*" -3005- MOVE '8100' TO WNR-EXEC-SQL */
            _.Move("8100", FILLER_30.FILLER_40.WABEND.WNR_EXEC_SQL);

            /*" -3007- MOVE '9000' TO WNR-EXEC-SQL. */
            _.Move("9000", FILLER_30.FILLER_40.WABEND.WNR_EXEC_SQL);

            /*" -3008- DISPLAY '-------------------------------------------------' */
            _.Display($"-------------------------------------------------");

            /*" -3009- DISPLAY 'PROGRAMA VG1626B ' */
            _.Display($"PROGRAMA VG1626B ");

            /*" -3010- DISPLAY 'TOTAIS PARA CONTROLE ' */
            _.Display($"TOTAIS PARA CONTROLE ");

            /*" -3011- DISPLAY '------------------------------------- ' */
            _.Display($"------------------------------------- ");

            /*" -3012- DISPLAY 'LIDOS DA PROPOSTAVA                 = ' AC-LIDOS-M */
            _.Display($"LIDOS DA PROPOSTAVA                 = {FILLER_30.AC_LIDOS_M}");

            /*" -3013- DISPLAY '------------------------------------- ' */
            _.Display($"------------------------------------- ");

            /*" -3014- DISPLAY ' .INCLUSOES                           ' */
            _.Display($" .INCLUSOES                           ");

            /*" -3016- DISPLAY '   COBERPROPVA                      = ' AC-I-COBERPROPVA. */
            _.Display($"   COBERPROPVA                      = {FILLER_30.AC_I_COBERPROPVA}");

            /*" -3017- DISPLAY '------------------------------------- ' */
            _.Display($"------------------------------------- ");

            /*" -3018- DISPLAY ' .ATUALIZACOES                        ' */
            _.Display($" .ATUALIZACOES                        ");

            /*" -3020- DISPLAY '   COBERPROPVA                      = ' AC-U-COBERPROPVA. */
            _.Display($"   COBERPROPVA                      = {FILLER_30.AC_U_COBERPROPVA}");

            /*" -3022- DISPLAY '   PARCELVA                         = ' AC-U-PARCELVA. */
            _.Display($"   PARCELVA                         = {FILLER_30.AC_U_PARCELVA}");

            /*" -3024- DISPLAY '   HISTCOBVA                        = ' AC-U-HISTCOBVA. */
            _.Display($"   HISTCOBVA                        = {FILLER_30.AC_U_HISTCOBVA}");

            /*" -3026- DISPLAY '   HISTLANCTA                       = ' AC-U-HISTLANCTA. */
            _.Display($"   HISTLANCTA                       = {FILLER_30.AC_U_HISTLANCTA}");

            /*" -3027- DISPLAY '------------------------------------- ' */
            _.Display($"------------------------------------- ");

            /*" -3028- DISPLAY ' .ESTATISTICAS                        ' */
            _.Display($" .ESTATISTICAS                        ");

            /*" -3029- DISPLAY '   PARCELAS JA PAGAS                = ' AC-PAGOS */
            _.Display($"   PARCELAS JA PAGAS                = {FILLER_30.AC_PAGOS}");

            /*" -3031- DISPLAY '   PARCELAS COM PREMIO IGUAL        = ' AC-PREMIO-IGUAL */
            _.Display($"   PARCELAS COM PREMIO IGUAL        = {FILLER_30.AC_PREMIO_IGUAL}");

            /*" -3033- DISPLAY '   PARCELAS COM PREMIO AJUSTADO     = ' AC-PREMIO-AJUSTADO */
            _.Display($"   PARCELAS COM PREMIO AJUSTADO     = {FILLER_30.AC_PREMIO_AJUSTADO}");

            /*" -3035- DISPLAY '   DESPREZADOS VIGENCIA             = ' AC-DESPREZ-VIG */
            _.Display($"   DESPREZADOS VIGENCIA             = {FILLER_30.AC_DESPREZ_VIG}");

            /*" -3037- DISPLAY '   DESPREZADOS FATURAMENTO MANUAL   = ' AC-DESPREZ-FAT-MANU */
            _.Display($"   DESPREZADOS FATURAMENTO MANUAL   = {FILLER_30.AC_DESPREZ_FAT_MANU}");

            /*" -3039- DISPLAY '   DESPREZADOS TIPO FATURAMENTO = 3 = ' AC-DESPREZ-FAT-RESU */
            _.Display($"   DESPREZADOS TIPO FATURAMENTO = 3 = {FILLER_30.AC_DESPREZ_FAT_RESU}");

            /*" -3041- DISPLAY '   DESPREZADOS DATA INIVIGENCIA     = ' AC-DESPREZ-DT-VIGEN */
            _.Display($"   DESPREZADOS DATA INIVIGENCIA     = {FILLER_30.AC_DESPREZ_DT_VIGEN}");

            /*" -3043- DISPLAY '   CERTIFICADO JAH PROCESSADO       = ' AC-JAH-PROCESSADO */
            _.Display($"   CERTIFICADO JAH PROCESSADO       = {FILLER_30.AC_JAH_PROCESSADO}");

            /*" -3045- DISPLAY '   VG1626BO GRAVADOS                = ' AC-VG1626BO-GRV */
            _.Display($"   VG1626BO GRAVADOS                = {FILLER_30.AC_VG1626BO_GRV}");

            /*" -3048- DISPLAY '   VG1626BD GRAVADOS                = ' AC-VG1626BD-GRV */
            _.Display($"   VG1626BD GRAVADOS                = {FILLER_30.AC_VG1626BD_GRV}");

            /*" -3049- DISPLAY '-------------------------------------' */
            _.Display($"-------------------------------------");

            /*" -3050- DISPLAY ' ' */
            _.Display($" ");

            /*" -3052- DISPLAY ' *** VG1626B - FIM NORMAL ' . */
            _.Display($" *** VG1626B - FIM NORMAL ");

            /*" -3052- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -3054- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9000_99_SAIDA*/

        [StopWatch]
        /*" R9900-00-ENCERRA-SEM-MOVTO-SECTION */
        private void R9900_00_ENCERRA_SEM_MOVTO_SECTION()
        {
            /*" -3063- MOVE SISTEMAS-DATA-MOV-ABERTO TO WDATA-REL */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, FILLER_30.WDATA_REL);

            /*" -3064- MOVE WDAT-REL-DIA TO WDAT-LIT-DIA */
            _.Move(FILLER_30.FILLER_50.WDAT_REL_DIA, FILLER_30.WDAT_REL_LIT.WDAT_LIT_DIA);

            /*" -3065- MOVE WDAT-REL-MES TO WDAT-LIT-MES */
            _.Move(FILLER_30.FILLER_50.WDAT_REL_MES, FILLER_30.WDAT_REL_LIT.WDAT_LIT_MES);

            /*" -3066- MOVE WDAT-REL-SEC TO WDAT-LIT-SEC */
            _.Move(FILLER_30.FILLER_50.WDAT_REL_SEC, FILLER_30.WDAT_REL_LIT.WDAT_LIT_SEC);

            /*" -3068- MOVE WDAT-REL-ANO TO WDAT-LIT-ANO */
            _.Move(FILLER_30.FILLER_50.WDAT_REL_ANO, FILLER_30.WDAT_REL_LIT.WDAT_LIT_ANO);

            /*" -3069- DISPLAY '*--------------------------------------------*' */
            _.Display($"*--------------------------------------------*");

            /*" -3070- DISPLAY '*                                            *' */
            _.Display($"*                                            *");

            /*" -3071- DISPLAY '*  VG1626B - CONSISTENCIA LOGICA MOVIMENTO   *' */
            _.Display($"*  VG1626B - CONSISTENCIA LOGICA MOVIMENTO   *");

            /*" -3072- DISPLAY '*  -------   ------------ ------ ---------   *' */
            _.Display($"*  -------   ------------ ------ ---------   *");

            /*" -3073- DISPLAY '*                                            *' */
            _.Display($"*                                            *");

            /*" -3074- DISPLAY '*     NAO HOUVE MOVIMENTACAO NESTA DATA      *' */
            _.Display($"*     NAO HOUVE MOVIMENTACAO NESTA DATA      *");

            /*" -3076- DISPLAY '*               ' WDAT-REL-LIT '            *' '*                                            *' */

            $"*               {FILLER_30.WDAT_REL_LIT}            **                                            *"
            .Display();

            /*" -3077- DISPLAY '*                                            *' */
            _.Display($"*                                            *");

            /*" -3077- DISPLAY '*--------------------------------------------*' . */
            _.Display($"*--------------------------------------------*");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9900_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -3086- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3087- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, FILLER_30.FILLER_40.WABEND.WSQLCODE);

                /*" -3088- MOVE SQLERRD(1) TO WSQLCODE1 */
                _.Move(DB.SQLERRD[1], FILLER_30.FILLER_40.WABEND.WSQLCODE1);

                /*" -3089- MOVE SQLERRD(2) TO WSQLCODE2 */
                _.Move(DB.SQLERRD[2], FILLER_30.FILLER_40.WABEND.WSQLCODE2);

                /*" -3090- MOVE SQLCODE TO WSQLCODE3 */
                _.Move(DB.SQLCODE, FILLER_30.WSQLCODE3);

                /*" -3091- DISPLAY WABEND */
                _.Display(FILLER_30.FILLER_40.WABEND);

                /*" -3092- MOVE SQLERRMC TO WSQLERRMC */
                _.Move(DB.SQLERRMC, FILLER_30.FILLER_40.WSQLERRO.WSQLERRMC);

                /*" -3093- DISPLAY WSQLERRO */
                _.Display(FILLER_30.FILLER_40.WSQLERRO);

                /*" -3094- DISPLAY SPACES */
                _.Display($"");

                /*" -3095- ACCEPT WS-TIME FROM TIME */
                _.Move(_.AcceptDate("TIME"), FILLER_30.WS_TIME);

                /*" -3097- DISPLAY 'LIDOS MOVIMENTO   ' AC-LIDOS-M ' ' WS-TIME. */

                $"LIDOS MOVIMENTO   {FILLER_30.AC_LIDOS_M} {FILLER_30.WS_TIME}"
                .Display();
            }


            /*" -3099- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -3103- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -3107- MOVE 99 TO RETURN-CODE */
            _.Move(99, RETURN_CODE);

            /*" -3107- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}