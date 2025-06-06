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
using Sias.Cosseguro.DB2.AC0017B;

namespace Code
{
    public class AC0017B
    {
        public bool IsCall { get; set; }

        public AC0017B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------                                       */
        /*"      *                                                                       */
        /*"      *                                                                       */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  ADMINISTRACAO DE COSSEGURO         *      */
        /*"      *   PROGRAMA ...............  AC0017B                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  PROCAS                             *      */
        /*"      *   PROGRAMADOR ............  VANDO                              *      */
        /*"      *   DATA CODIFICACAO .......  JANEIRO/1992                       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO .................  ATUALIZAR DB DE COSSEGURO CEDIDO   *      */
        /*"      *                             DE SINISTROS - TRATA INTEGRIDADE   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * TABELA                              VIEW              ACESSO   *      */
        /*"      * ----------------------------------- ----------------- -------- *      */
        /*"      * SISTEMAS                            V1SISTEMA           INPUT  *      */
        /*"      * MESTRE DE SINISTROS                 V1MESTSINI          INPUT  *      */
        /*"      * HISTORICO DE SINISTROS              V1HISTSINI          INPUT  *      */
        /*"      * OPERACOES DE SINISTROS              PARAMETR_OPER_SINI  INPUT  *      */
        /*"      * APOLICES                            V0APOLICE           INPUT  *      */
        /*"      * COTACAO DE MOEDAS                   V0COTACAO           INPUT  *      */
        /*"      * APOLICE COSSEGURO CEDIDO            V1APOLCOSCED        INPUT  *      */
        /*"      * PREMIOS DE COSSEGURO (SINISTRO)     V0COSSEG_SINI       I-O    *      */
        /*"      * HISTORICO DE COSSEGURO (SINISTRO)   V0COSSEG_HISTSIN    OUTPUT *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * ALTERACAO EM 01/07/2004 - CARLOS ALBERTO - PROCURAR CA0604     *      */
        /*"      * NAO CARREGAR AS OPERACOES 2010 E 3010, LIBERADAS  RESPECTIVA-  *      */
        /*"      * MENTE, PELAS OPERACOES 2017 E 3017.                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * PRODEXTER - 14/06/2005 - SUBSTITUICAO DA PARAMETR_OPER_SINI    *      */
        /*"      *                          PELA GE_OPERACAO E GE_SIS_FUNCAO_OPER *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * ALTERACAO EM 03/02/2006 - GILSON - PROCURAR GP0206             *      */
        /*"      * NAO CALCULAR MAIS OS VALORES DE COSSEGURO PARA AS OPERACOES DE *      */
        /*"      * ESTORNOS DE PAGAMENTOS DE SINISTROS, E SIM OBTER A OPERACAO DE *      */
        /*"      * PAGAMENTO DO SINISTRO CORRESPONDENTE NO CONTA CORRENTE         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * ALTERACAO EM 26/06/2006 - GILSON - PROCURAR GP0606             *      */
        /*"      * INIBIR A ALTERACAO FEITA 03/02/2006 PARA BUSCAR O VALOR PAGO   *      */
        /*"      * E LANCAR NO VALOR DO ESTORNO, EM FUNCAO DE SE PODER ESTORNAR UM*      */
        /*"      * VALOR DIFERENTE DO PAGO                                        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * ALTERACAO EM 28/06/2006 - GILSON - PROCURAR GP0606             *      */
        /*"      * DESPREZAR AS OPERACOES DE SINISTROS PARA O TIPO DE FUNCAO      *      */
        /*"      * 'PE' (150 A 153), 'PRE-REGIST' (1200/1201/1202/1210),          *      */
        /*"      * 'IN-REGIST' (1300/1301/1302), E 'EST-REGIST' (1310)            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  EM JUN/2011 POR GILSON PINTO DA SILVA - PROCURAR GP0611       *      */
        /*"      *  - ALTERACAO PARA TRATAR O NOVO CONVENIO AUTO SAS - ORGAO 110  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  EM NOV/2012 POR GILSON PINTO DA SILVA - PROCURAR C76309       *      */
        /*"      *  - ALTERACAO PARA TRATAR O SINISTRO COM RESSARCIMENTO PARA     *      */
        /*"      *    TODOS OS CONVENIOS E CIAS CONGENERES.                       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  EM AGO/2013 POR GILSON PINTO DA SILVA - PROCURAR C86341       *      */
        /*"      *  - ALTERAR O PROGRAMA PARA TRATAR OS SINISTROS CUJOS DOCUMENTOS*      */
        /*"      *    TENHAM O COSSEG CEDIDO EMITIDOS POR RAMO E CODIGO DE COBERT *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  EM JUN/2014 POR GILSON PINTO DA SILVA - PROCURAR C86341       *      */
        /*"      *  - ALTERAR O PROGRAMA PARA TRATAR O PERCENTUAL DE PARTICIPACAO *      */
        /*"      *    DE COSSEG CEDIDO A RECUPERAR DA CIA PREVISUL(5193) DEVIDO A *      */
        /*"      *    SINISTROS DA COBERTURA DIT - 95% A PARTIR DE 06/06/2014     *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  ALTERACAO - INCLUIR AS AP�LICES 109300003432 E 109300002675   *      */
        /*"      *            - PROJETO NO VERSIONA DO PROGRAMA C103181           *      */
        /*"      * 30/10/2014 - WELLINGTON VERAS (TE39902)  PROCURAR POR 103181   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  ALTERACAO - NAO PROCESSAR O SINISTRO 0109300144836            *      */
        /*"      *            - PROJETO NO VERSIONA DO PROGRAMA C106433           *      */
        /*"      * 27/11/2014 - WELLINGTON VERAS (TE39902)  PROCURAR POR 106433   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  ALTERACAO - INCLUIR A APOLICE 109300004544                    *      */
        /*"      *            - CADMUS 144831                                     *      */
        /*"      * 05/12/2016 - LUIGI CONTE (TE37374)       PROCURAR POR 144831   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  ALTERACAO - DESPREZAR OS MOVIMENTOS DAS APOLICES DE VIDA      *      */
        /*"      *              REFERENTES AOS PERIODOS PARA OS QUAIS NAO TIVERAM *      */
        /*"      *              A DISTRIBUICAO DE CEDIDO PARA A PREVISUL          *      */
        /*"      * 05/01/2017 - GILSON PINTO DA SILVA             CADMUS - 146005 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  ALTERACAO - DESPREZAR OS MOVIMENTOS DA APOLICE 109300002676   *      */
        /*"      *              REFERENTE AO PERIODO PARA O QUAL NAO HOUVE A      *      */
        /*"      *              DISTRIBUICAO DE CEDIDO PARA A PREVISUL            *      */
        /*"      * 11/05/2017 - GILSON PINTO DA SILVA             CADMUS - 146335 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  ALTERACAO - DESPREZAR OS MOVIMENTOS DA APOLICE DE VIDA        *      */
        /*"      *              109300003432 NO PERIODO PARA O QUAL NAO TEVE A    *      */
        /*"      *              DISTRIBUICAO DE CEDIDO PARA A PREVISUL            *      */
        /*"      * 13/11/2017 - GILSON PINTO DA SILVA             CADMUS - 146335 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  ALTERACAO - INCLUIR A APOLICE DE VIDA 109300002677 PARA FAZER *      */
        /*"      *              A RECUPERACAO DO PERCENTUAL DE PARTICIPACAO DA CIA*      */
        /*"      *              PREVISUL                                          *      */
        /*"      * 30/07/2018 - GILSON PINTO DA SILVA                             *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  ALTERACAO - TRATAR OS SINISTROS DO HIPOTECARIO DO SISTEMA SIAS*      */
        /*"      *              PERTENCENTES AS APOLICES/CONTRATOS DO SMART       *      */
        /*"      * 19/09/2018 - GILSON PINTO DA SILVA    JAZZ - HISTORIA - 169394 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  ALTERACAO - PREPARAR A COLUNA CODIGO DE EMPRESA PARA RECEBER  *      */
        /*"      *              A INFORMACAO DO CODIGO CORRESPONDENTE             *      */
        /*"      * 04/10/2018 - GILSON PINTO DA SILVA    JAZZ - HISTORIA - 173142 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  ALTERACAO - DESPREZAR OS REGISTROS DE SINISTROS DO SMART COM  *      */
        /*"      *              ORGAO EMISSOR 140 EM SUA FORMATACAO               *      */
        /*"      * 10/10/2018 - GILSON PINTO DA SILVA    JAZZ - HISTORIA - 175359 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  ALTERACAO - INCLUIR A APOLICE DE VIDA 109300005270 PARA FAZER *      */
        /*"      *              A RECUPERACAO DO PERCENTUAL DE PARTICIPACAO DA CIA*      */
        /*"      *              PREVISUL                                          *      */
        /*"      * 26/10/2018 - GILSON PINTO DA SILVA      JAZZ - TAREFA - 176795 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  ALTERACAO - DESPREZAR OS SINISTROS COM DATA DE AVISO A PARTIR *      */
        /*"      *              DE 01/11/2018 COM PARTICIPACAO DA SEGURADORA 5142 *      */
        /*"      *              ICATU                                             *      */
        /*"      * 30/10/2018 - GILSON PINTO DA SILVA      JAZZ - TAREFA - 177000 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  ALTERACAO - PREPARAR A ROTINA PARA TRATAR/INCLUIR O ORGAO 300 *      */
        /*"      * 22/01/2019 - GILSON PINTO DA SILVA    JAZZ - HISTORIA - 188194 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  ALTERACAO - INCLUIR AS APOLICES 108211323063, 108211323064 E  *      */
        /*"      *              109300002678 PARA FAZER A RECUPERACAO DO PCT DE   *      */
        /*"      *              PARTICIPACAO DA CIA PREVISUL                      *      */
        /*"      * 02/07/2019 - GILSON PINTO DA SILVA      JAZZ - TAREFA - 204157 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  ALTERACAO - CONVERTER AS APOLICES DO ORGAO 010 PARA ORGAO 300 *      */
        /*"      * 04/07/2019 - GILSON PINTO DA SILVA    JAZZ - HISTORIA - 190441 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  ALTERACAO - ALTERAR A ROTINA PARA DESPREZAR AS OPERACOES DE   *      */
        /*"      *              INTERFACE COM O FINANCEIRO DE DESPESA E HONORARIO *      */
        /*"      * 04/02/2022 - GILSON PINTO DA SILVA      JAZZ - TAREFA - 361534 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        #endregion


        #region VARIABLES

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77          WHOST-QTDE-REG      PIC S9(009)     VALUE +0 COMP.*/
        public IntBasis WHOST_QTDE_REG { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77          WHOST-OPERACAO      PIC S9(004)     VALUE +0 COMP.*/
        public IntBasis WHOST_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          WHOST-SITUACAO      PIC  X(001)     VALUE SPACES.*/
        public StringBasis WHOST_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"77          WHOST-DTINIMOV      PIC  X(010)     VALUE SPACES.*/
        public StringBasis WHOST_DTINIMOV { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77          WHOST-DTTERMOV      PIC  X(010)     VALUE SPACES.*/
        public StringBasis WHOST_DTTERMOV { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77          WHOST-DATA-AVS      PIC  X(010)     VALUE SPACES.*/
        public StringBasis WHOST_DATA_AVS { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77          WHOST-DTMOVTO       PIC  X(010)     VALUE SPACES.*/
        public StringBasis WHOST_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77          WHOST-VAL-OPER      PIC S9(013)V99  VALUE +0 COMP-3.*/
        public DoubleBasis WHOST_VAL_OPER { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77          VIND-SIT-LIBR       PIC S9(004)     VALUE +0 COMP.*/
        public IntBasis VIND_SIT_LIBR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          VIND-SIT-REGT       PIC S9(004)     VALUE +0 COMP.*/
        public IntBasis VIND_SIT_REGT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          VIND-TIP-SEGR       PIC S9(004)     VALUE +0 COMP.*/
        public IntBasis VIND_TIP_SEGR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V1SIST-DTMOVABE     PIC  X(010).*/
        public StringBasis V1SIST_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77          V1MSIN-NUM-SINI     PIC S9(013)              COMP-3.*/
        public IntBasis V1MSIN_NUM_SINI { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77          V1MSIN-TIPREG       PIC  X(001).*/
        public StringBasis V1MSIN_TIPREG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77          V1MSIN-FONTE        PIC S9(004)              COMP.*/
        public IntBasis V1MSIN_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V1MSIN-RAMO         PIC S9(004)              COMP.*/
        public IntBasis V1MSIN_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V1MSIN-NUM-APOL     PIC S9(013)              COMP-3.*/
        public IntBasis V1MSIN_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77          V1MSIN-NRENDOS      PIC S9(009)              COMP.*/
        public IntBasis V1MSIN_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77          V1MSIN-CODSUBES     PIC S9(004)              COMP.*/
        public IntBasis V1MSIN_CODSUBES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V1MSIN-NRCERTIF     PIC S9(015)              COMP-3.*/
        public IntBasis V1MSIN_NRCERTIF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77          V1MSIN-OCORHIST     PIC S9(004)              COMP.*/
        public IntBasis V1MSIN_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V1MSIN-CODLIDER     PIC S9(004)              COMP.*/
        public IntBasis V1MSIN_CODLIDER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V1MSIN-SINLID       PIC  X(015).*/
        public StringBasis V1MSIN_SINLID { get; set; } = new StringBasis(new PIC("X", "15", "X(015)."), @"");
        /*"77          V1MSIN-DATCMD       PIC  X(010).*/
        public StringBasis V1MSIN_DATCMD { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77          V1MSIN-DATORR       PIC  X(010).*/
        public StringBasis V1MSIN_DATORR { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77          V1MSIN-DATTEC       PIC  X(010).*/
        public StringBasis V1MSIN_DATTEC { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77          V1MSIN-CODCAU       PIC S9(004)              COMP.*/
        public IntBasis V1MSIN_CODCAU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V1MSIN-COD-MOEDA    PIC S9(004)              COMP.*/
        public IntBasis V1MSIN_COD_MOEDA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V1MSIN-SDOPAGBT     PIC S9(010)V9(5)         COMP-3.*/
        public DoubleBasis V1MSIN_SDOPAGBT { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77          V1MSIN-TOTPAGBT     PIC S9(010)V9(5)         COMP-3.*/
        public DoubleBasis V1MSIN_TOTPAGBT { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77          V1MSIN-SDORCPBT     PIC S9(010)V9(5)         COMP-3.*/
        public DoubleBasis V1MSIN_SDORCPBT { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77          V1MSIN-TOTRCPBT     PIC S9(010)V9(5)         COMP-3.*/
        public DoubleBasis V1MSIN_TOTRCPBT { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77          V1MSIN-SDORSABT     PIC S9(010)V9(5)         COMP-3.*/
        public DoubleBasis V1MSIN_SDORSABT { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77          V1MSIN-TOTRSDBT     PIC S9(010)V9(5)         COMP-3.*/
        public DoubleBasis V1MSIN_TOTRSDBT { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77          V1MSIN-TOTDSABT     PIC S9(010)V9(5)         COMP-3.*/
        public DoubleBasis V1MSIN_TOTDSABT { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77          V1MSIN-TOTHONBT     PIC S9(010)V9(5)         COMP-3.*/
        public DoubleBasis V1MSIN_TOTHONBT { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77          V1MSIN-SDOADTBT     PIC S9(010)V9(5)         COMP-3.*/
        public DoubleBasis V1MSIN_SDOADTBT { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77          V1MSIN-ADTRCPBT     PIC S9(010)V9(5)         COMP-3.*/
        public DoubleBasis V1MSIN_ADTRCPBT { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77          V1MSIN-VALSEGBT     PIC S9(010)V9(5)         COMP-3.*/
        public DoubleBasis V1MSIN_VALSEGBT { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77          V1MSIN-PCPARTIC     PIC S9(004)V9(5)         COMP-3.*/
        public DoubleBasis V1MSIN_PCPARTIC { get; set; } = new DoubleBasis(new PIC("S9", "4", "S9(004)V9(5)"), 5);
        /*"77          V1MSIN-PCTRES       PIC S9(004)V9(5)         COMP-3.*/
        public DoubleBasis V1MSIN_PCTRES { get; set; } = new DoubleBasis(new PIC("S9", "4", "S9(004)V9(5)"), 5);
        /*"77          V1MSIN-DTULTMOV     PIC  X(010).*/
        public StringBasis V1MSIN_DTULTMOV { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77          V1MSIN-SITUACAO     PIC  X(001).*/
        public StringBasis V1MSIN_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77          V1HSIN-NUM-SINI     PIC S9(013)              COMP-3.*/
        public IntBasis V1HSIN_NUM_SINI { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77          V1HSIN-TIPREG       PIC  X(001).*/
        public StringBasis V1HSIN_TIPREG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77          V1HSIN-OCORHIST     PIC S9(004)              COMP.*/
        public IntBasis V1HSIN_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V1HSIN-OPERACAO     PIC S9(004)              COMP.*/
        public IntBasis V1HSIN_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V1HSIN-DTMOVTO      PIC  X(010).*/
        public StringBasis V1HSIN_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77          V1HSIN-VAL-OPER     PIC S9(013)V99           COMP-3.*/
        public DoubleBasis V1HSIN_VAL_OPER { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77          V1HSIN-SITUACAO     PIC  X(001).*/
        public StringBasis V1HSIN_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77          V2HSIN-DTMOVTO      PIC  X(010).*/
        public StringBasis V2HSIN_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77          V2HSIN-VAL-OPER     PIC S9(013)V99           COMP-3.*/
        public DoubleBasis V2HSIN_VAL_OPER { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77          V0APOL-NUM-APOL     PIC S9(013)              COMP-3.*/
        public IntBasis V0APOL_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77          V0APOL-TIPSGU       PIC  X(001).*/
        public StringBasis V0APOL_TIPSGU { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77          V0APOL-ORGAO        PIC S9(004)              COMP.*/
        public IntBasis V0APOL_ORGAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V0APOL-RAMO         PIC S9(004)              COMP.*/
        public IntBasis V0APOL_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V0COTA-VL-VENDA     PIC S9(006)V9(9)         COMP-3.*/
        public DoubleBasis V0COTA_VL_VENDA { get; set; } = new DoubleBasis(new PIC("S9", "6", "S9(006)V9(9)"), 9);
        /*"77          V1COTA-VL-VENDA     PIC S9(006)V9(9)         COMP-3.*/
        public DoubleBasis V1COTA_VL_VENDA { get; set; } = new DoubleBasis(new PIC("S9", "6", "S9(006)V9(9)"), 9);
        /*"77          V1APCD-CODCOSS      PIC S9(004)              COMP.*/
        public IntBasis V1APCD_CODCOSS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V1APCD-PCCOMCOS     PIC S9(003)V99           COMP-3.*/
        public DoubleBasis V1APCD_PCCOMCOS { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"77          V1APCD-PCPARTIC     PIC S9(004)V9(5)         COMP-3.*/
        public DoubleBasis V1APCD_PCPARTIC { get; set; } = new DoubleBasis(new PIC("S9", "4", "S9(004)V9(5)"), 5);
        /*"77          V0CSIN-COD-EMP      PIC S9(009)              COMP.*/
        public IntBasis V0CSIN_COD_EMP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77          V0CSIN-TIPSGU       PIC  X(001).*/
        public StringBasis V0CSIN_TIPSGU { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77          V0CSIN-CONGENER     PIC S9(004)              COMP.*/
        public IntBasis V0CSIN_CONGENER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V0CSIN-NUM-SINI     PIC S9(013)              COMP-3.*/
        public IntBasis V0CSIN_NUM_SINI { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77          V0CSIN-VAL-OPER     PIC S9(010)V9(5)         COMP-3.*/
        public DoubleBasis V0CSIN_VAL_OPER { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77          V0CSIN-SITUACAO     PIC  X(001).*/
        public StringBasis V0CSIN_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77          V0CSIN-SIT-CONG     PIC  X(001).*/
        public StringBasis V0CSIN_SIT_CONG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77          V0CSIN-TIMESTAMP    PIC  X(026).*/
        public StringBasis V0CSIN_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(026)."), @"");
        /*"77          V1CSIN-TIPSGU       PIC  X(001).*/
        public StringBasis V1CSIN_TIPSGU { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77          V1CSIN-CONGENER     PIC S9(004)              COMP.*/
        public IntBasis V1CSIN_CONGENER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V1CSIN-NUM-SINI     PIC S9(013)              COMP-3.*/
        public IntBasis V1CSIN_NUM_SINI { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77          V2CSIN-COD-EMP      PIC S9(009)              COMP.*/
        public IntBasis V2CSIN_COD_EMP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77          V2CSIN-TIPSGU       PIC  X(001).*/
        public StringBasis V2CSIN_TIPSGU { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77          V2CSIN-CONGENER     PIC S9(004)              COMP.*/
        public IntBasis V2CSIN_CONGENER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V2CSIN-NUM-SINI     PIC S9(013)              COMP-3.*/
        public IntBasis V2CSIN_NUM_SINI { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77          V2CSIN-VAL-OPER     PIC S9(010)V9(5)         COMP-3.*/
        public DoubleBasis V2CSIN_VAL_OPER { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77          V2CSIN-SITUACAO     PIC  X(001).*/
        public StringBasis V2CSIN_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77          V2CSIN-SIT-CONG     PIC  X(001).*/
        public StringBasis V2CSIN_SIT_CONG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77          V2CSIN-TIMESTAMP    PIC  X(026).*/
        public StringBasis V2CSIN_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(026)."), @"");
        /*"77          V0CHSI-COD-EMP      PIC S9(009)              COMP.*/
        public IntBasis V0CHSI_COD_EMP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77          V0CHSI-CONGENER     PIC S9(004)              COMP.*/
        public IntBasis V0CHSI_CONGENER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V0CHSI-NUM-SINI     PIC S9(013)              COMP-3.*/
        public IntBasis V0CHSI_NUM_SINI { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77          V0CHSI-OCORHIST     PIC S9(004)              COMP.*/
        public IntBasis V0CHSI_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V0CHSI-OPERACAO     PIC S9(004)              COMP.*/
        public IntBasis V0CHSI_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V0CHSI-SITUACAO     PIC  X(001).*/
        public StringBasis V0CHSI_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77          V0CHSI-DTMOVTO      PIC  X(010).*/
        public StringBasis V0CHSI_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77          V0CHSI-VAL-OPER     PIC S9(013)V9(2)         COMP-3.*/
        public DoubleBasis V0CHSI_VAL_OPER { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"77          V0CHSI-TIMESTAMP    PIC  X(026).*/
        public StringBasis V0CHSI_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(026)."), @"");
        /*"77          V0CHSI-TIPSGU       PIC  X(001).*/
        public StringBasis V0CHSI_TIPSGU { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77          V0CHSI-SIT-LIBRECUP PIC  X(001).*/
        public StringBasis V0CHSI_SIT_LIBRECUP { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77          V2CHSI-COD-EMP      PIC S9(009)              COMP.*/
        public IntBasis V2CHSI_COD_EMP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77          V2CHSI-CONGENER     PIC S9(004)              COMP.*/
        public IntBasis V2CHSI_CONGENER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V2CHSI-NUM-SINI     PIC S9(013)              COMP-3.*/
        public IntBasis V2CHSI_NUM_SINI { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77          V2CHSI-OCORHIST     PIC S9(004)              COMP.*/
        public IntBasis V2CHSI_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V2CHSI-OPERACAO     PIC S9(004)              COMP.*/
        public IntBasis V2CHSI_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V2CHSI-SITUACAO     PIC  X(001).*/
        public StringBasis V2CHSI_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77          V2CHSI-DTMOVTO      PIC  X(010).*/
        public StringBasis V2CHSI_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77          V2CHSI-VAL-OPER     PIC S9(013)V9(2)         COMP-3.*/
        public DoubleBasis V2CHSI_VAL_OPER { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"77          V2CHSI-TIPSGU       PIC  X(001).*/
        public StringBasis V2CHSI_TIPSGU { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77          V2CHSI-SIT-LIBRECUP PIC  X(001).*/
        public StringBasis V2CHSI_SIT_LIBRECUP { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01          AREA-DE-WORK.*/
        public AC0017B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new AC0017B_AREA_DE_WORK();
        public class AC0017B_AREA_DE_WORK : VarBasis
        {
            /*"  05        WSL-SQLCODE         PIC  9(009)  VALUE ZEROS.*/
            public IntBasis WSL_SQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05        WMES                PIC S9(004)  VALUE +0 COMP.*/
            public IntBasis WMES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05        AC-COUNT            PIC S9(005)  VALUE +0 COMP-3.*/
            public IntBasis AC_COUNT { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));
            /*"  05        WFIM-V1MESTSINI     PIC  X(001)  VALUE SPACES.*/
            public StringBasis WFIM_V1MESTSINI { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05        WFIM-V1APOLCOSCED   PIC  X(001)  VALUE SPACES.*/
            public StringBasis WFIM_V1APOLCOSCED { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05        WTEM-V1COSSEGSINI   PIC  X(001)  VALUE SPACES.*/
            public StringBasis WTEM_V1COSSEGSINI { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05        AC-L-V1MESTSINI     PIC  9(007)  VALUE ZEROS.*/
            public IntBasis AC_L_V1MESTSINI { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05        AC-U-V0COSSEGSINI   PIC  9(007)  VALUE ZEROS.*/
            public IntBasis AC_U_V0COSSEGSINI { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05        AC-I-V0COSSEGSINI   PIC  9(007)  VALUE ZEROS.*/
            public IntBasis AC_I_V0COSSEGSINI { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05        AC-I-V0COSSEGHSIN   PIC  9(007)  VALUE ZEROS.*/
            public IntBasis AC_I_V0COSSEGHSIN { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05        WNUM-SINI-ANT       PIC S9(013)  VALUE +0 COMP-3.*/
            public IntBasis WNUM_SINI_ANT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
            /*"  05        WNUM-SINISTRO       PIC  9(013)  VALUE ZEROS.*/
            public IntBasis WNUM_SINISTRO { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
            /*"  05        WNUM-SINI-R         REDEFINES    WNUM-SINISTRO.*/
            private _REDEF_AC0017B_WNUM_SINI_R _wnum_sini_r { get; set; }
            public _REDEF_AC0017B_WNUM_SINI_R WNUM_SINI_R
            {
                get { _wnum_sini_r = new _REDEF_AC0017B_WNUM_SINI_R(); _.Move(WNUM_SINISTRO, _wnum_sini_r); VarBasis.RedefinePassValue(WNUM_SINISTRO, _wnum_sini_r, WNUM_SINISTRO); _wnum_sini_r.ValueChanged += () => { _.Move(_wnum_sini_r, WNUM_SINISTRO); }; return _wnum_sini_r; }
                set { VarBasis.RedefinePassValue(value, _wnum_sini_r, WNUM_SINISTRO); }
            }  //Redefines
            public class _REDEF_AC0017B_WNUM_SINI_R : VarBasis
            {
                /*"    10      WORG-SINI           PIC  9(003).*/
                public IntBasis WORG_SINI { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"    10      WRMO-SINI           PIC  9(002).*/
                public IntBasis WRMO_SINI { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10      WSEQ-SINI           PIC  9(008).*/
                public IntBasis WSEQ_SINI { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"  05        W0MSIN-VAL-OPER     PIC S9(013)V9(5)      COMP-3.*/

                public _REDEF_AC0017B_WNUM_SINI_R()
                {
                    WORG_SINI.ValueChanged += OnValueChanged;
                    WRMO_SINI.ValueChanged += OnValueChanged;
                    WSEQ_SINI.ValueChanged += OnValueChanged;
                }

            }
            public DoubleBasis W0MSIN_VAL_OPER { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(5)"), 5);
            /*"  05        W0HSIN-VAL-OPER     PIC S9(015)V99        COMP-3.*/
            public DoubleBasis W0HSIN_VAL_OPER { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(015)V99"), 2);
            /*"  05        W0VLR-RESSEG        PIC S9(015)V99        COMP-3.*/
            public DoubleBasis W0VLR_RESSEG { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(015)V99"), 2);
            /*"  05        W2MSIN-VAL-OPER     PIC S9(013)V9(5)      COMP-3.*/
            public DoubleBasis W2MSIN_VAL_OPER { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(5)"), 5);
            /*"  05        W2HSIN-VAL-OPER     PIC S9(015)V99        COMP-3.*/
            public DoubleBasis W2HSIN_VAL_OPER { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(015)V99"), 2);
            /*"  05        WDATA-REL           PIC  X(010)  VALUE SPACES.*/
            public StringBasis WDATA_REL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05        FILLER              REDEFINES    WDATA-REL.*/
            private _REDEF_AC0017B_FILLER_0 _filler_0 { get; set; }
            public _REDEF_AC0017B_FILLER_0 FILLER_0
            {
                get { _filler_0 = new _REDEF_AC0017B_FILLER_0(); _.Move(WDATA_REL, _filler_0); VarBasis.RedefinePassValue(WDATA_REL, _filler_0, WDATA_REL); _filler_0.ValueChanged += () => { _.Move(_filler_0, WDATA_REL); }; return _filler_0; }
                set { VarBasis.RedefinePassValue(value, _filler_0, WDATA_REL); }
            }  //Redefines
            public class _REDEF_AC0017B_FILLER_0 : VarBasis
            {
                /*"    10      WDAT-REL-ANO        PIC  9(004).*/
                public IntBasis WDAT_REL_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10      FILLER              PIC  X(001).*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10      WDAT-REL-MES        PIC  9(002).*/
                public IntBasis WDAT_REL_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10      FILLER              PIC  X(001).*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10      WDAT-REL-DIA        PIC  9(002).*/
                public IntBasis WDAT_REL_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05        WDATA-SQL           PIC  X(010)  VALUE SPACES.*/

                public _REDEF_AC0017B_FILLER_0()
                {
                    WDAT_REL_ANO.ValueChanged += OnValueChanged;
                    FILLER_1.ValueChanged += OnValueChanged;
                    WDAT_REL_MES.ValueChanged += OnValueChanged;
                    FILLER_2.ValueChanged += OnValueChanged;
                    WDAT_REL_DIA.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WDATA_SQL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05        FILLER              REDEFINES    WDATA-SQL.*/
            private _REDEF_AC0017B_FILLER_3 _filler_3 { get; set; }
            public _REDEF_AC0017B_FILLER_3 FILLER_3
            {
                get { _filler_3 = new _REDEF_AC0017B_FILLER_3(); _.Move(WDATA_SQL, _filler_3); VarBasis.RedefinePassValue(WDATA_SQL, _filler_3, WDATA_SQL); _filler_3.ValueChanged += () => { _.Move(_filler_3, WDATA_SQL); }; return _filler_3; }
                set { VarBasis.RedefinePassValue(value, _filler_3, WDATA_SQL); }
            }  //Redefines
            public class _REDEF_AC0017B_FILLER_3 : VarBasis
            {
                /*"    10      WDATA-SQL-ANO       PIC  9(004).*/
                public IntBasis WDATA_SQL_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10      FILLER              PIC  X(001).*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10      WDATA-SQL-MES       PIC  9(002).*/
                public IntBasis WDATA_SQL_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10      FILLER              PIC  X(001).*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10      WDATA-SQL-DIA       PIC  9(002).*/
                public IntBasis WDATA_SQL_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05        WDAT-REL-LIT.*/

                public _REDEF_AC0017B_FILLER_3()
                {
                    WDATA_SQL_ANO.ValueChanged += OnValueChanged;
                    FILLER_4.ValueChanged += OnValueChanged;
                    WDATA_SQL_MES.ValueChanged += OnValueChanged;
                    FILLER_5.ValueChanged += OnValueChanged;
                    WDATA_SQL_DIA.ValueChanged += OnValueChanged;
                }

            }
            public AC0017B_WDAT_REL_LIT WDAT_REL_LIT { get; set; } = new AC0017B_WDAT_REL_LIT();
            public class AC0017B_WDAT_REL_LIT : VarBasis
            {
                /*"    10      WDAT-LIT-DIA        PIC  9(002)  VALUE ZEROS.*/
                public IntBasis WDAT_LIT_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10      FILLER              PIC  X(001)  VALUE '/'.*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10      WDAT-LIT-MES        PIC  9(002)  VALUE ZEROS.*/
                public IntBasis WDAT_LIT_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10      FILLER              PIC  X(001)  VALUE '/'.*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10      WDAT-LIT-ANO        PIC  9(004)  VALUE ZEROS.*/
                public IntBasis WDAT_LIT_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"  05        WHORA-ACCEPT.*/
            }
            public AC0017B_WHORA_ACCEPT WHORA_ACCEPT { get; set; } = new AC0017B_WHORA_ACCEPT();
            public class AC0017B_WHORA_ACCEPT : VarBasis
            {
                /*"    10      WHH-ACCEPT          PIC  9(002)  VALUE  ZEROS.*/
                public IntBasis WHH_ACCEPT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10      WMM-ACCEPT          PIC  9(002)  VALUE  ZEROS.*/
                public IntBasis WMM_ACCEPT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10      WSS-ACCEPT          PIC  9(002)  VALUE  ZEROS.*/
                public IntBasis WSS_ACCEPT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10      WCC-ACCEPT          PIC  9(002)  VALUE  ZEROS.*/
                public IntBasis WCC_ACCEPT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  05        WHORA-CABEC.*/
            }
            public AC0017B_WHORA_CABEC WHORA_CABEC { get; set; } = new AC0017B_WHORA_CABEC();
            public class AC0017B_WHORA_CABEC : VarBasis
            {
                /*"    10      WHORA-HH-CABEC      PIC  9(002)  VALUE ZEROS.*/
                public IntBasis WHORA_HH_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10      FILLER              PIC  X(001)  VALUE ':'.*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @":");
                /*"    10      WHORA-MM-CABEC      PIC  9(002)  VALUE ZEROS.*/
                public IntBasis WHORA_MM_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10      FILLER              PIC  X(001)  VALUE ':'.*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @":");
                /*"    10      WHORA-SS-CABEC      PIC  9(002)  VALUE ZEROS.*/
                public IntBasis WHORA_SS_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"01          WABEND.*/
            }
        }
        public AC0017B_WABEND WABEND { get; set; } = new AC0017B_WABEND();
        public class AC0017B_WABEND : VarBasis
        {
            /*"  05        FILLER              PIC  X(010)    VALUE           ' AC0017B'.*/
            public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" AC0017B");
            /*"  05        FILLER              PIC  X(026)    VALUE           ' *** ERRO EXEC SQL NUMERO '.*/
            public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @" *** ERRO EXEC SQL NUMERO ");
            /*"  05        WNR-EXEC-SQL        PIC  X(003)    VALUE '000'.*/
            public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"000");
            /*"  05        FILLER              PIC  X(013)    VALUE           ' *** SQLCODE '.*/
            public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
            /*"  05        WSQLCODE            PIC  ZZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
        }


        public Dclgens.GEOPERAC GEOPERAC { get; set; } = new Dclgens.GEOPERAC();
        public Dclgens.GESISFUO GESISFUO { get; set; } = new Dclgens.GESISFUO();
        public Dclgens.SX010 SX010 { get; set; } = new Dclgens.SX010();
        public Dclgens.SX011 SX011 { get; set; } = new Dclgens.SX011();
        public Dclgens.SX017 SX017 { get; set; } = new Dclgens.SX017();
        public AC0017B_V1MESTSINI V1MESTSINI { get; set; } = new AC0017B_V1MESTSINI();
        public AC0017B_V1APOLCOSCED V1APOLCOSCED { get; set; } = new AC0017B_V1APOLCOSCED();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute() //PROCEDURE DIVISION 
        /**/
        {
            try
            {

                /*" -0- FLUXCONTROL_PERFORM R0000-00-PRINCIPAL-SECTION */

                R0000_00_PRINCIPAL_SECTION();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            return Result;
        }

        [StopWatch]
        /*" R0000-00-PRINCIPAL-SECTION */
        private void R0000_00_PRINCIPAL_SECTION()
        {
            /*" -435- MOVE '000' TO WNR-EXEC-SQL. */
            _.Move("000", WABEND.WNR_EXEC_SQL);

            /*" -436- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -439- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -442- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -448- PERFORM R0100-00-SELECT-V1SISTEMA. */

            R0100_00_SELECT_V1SISTEMA_SECTION();

            /*" -450- MOVE ZEROS TO WHOST-QTDE-REG. */
            _.Move(0, WHOST_QTDE_REG);

            /*" -452- PERFORM R0200-00-CHECA-EXECUCAO. */

            R0200_00_CHECA_EXECUCAO_SECTION();

            /*" -453- IF WHOST-QTDE-REG > ZEROS */

            if (WHOST_QTDE_REG > 00)
            {

                /*" -454- DISPLAY 'AC0017B - DUPLICIDADE DE PROCESSAMENTO' */
                _.Display($"AC0017B - DUPLICIDADE DE PROCESSAMENTO");

                /*" -455- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -457- END-IF. */
            }


            /*" -458- ACCEPT WHORA-ACCEPT FROM TIME. */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WHORA_ACCEPT);

            /*" -459- MOVE WHH-ACCEPT TO WHORA-HH-CABEC. */
            _.Move(AREA_DE_WORK.WHORA_ACCEPT.WHH_ACCEPT, AREA_DE_WORK.WHORA_CABEC.WHORA_HH_CABEC);

            /*" -460- MOVE WMM-ACCEPT TO WHORA-MM-CABEC. */
            _.Move(AREA_DE_WORK.WHORA_ACCEPT.WMM_ACCEPT, AREA_DE_WORK.WHORA_CABEC.WHORA_MM_CABEC);

            /*" -462- MOVE WSS-ACCEPT TO WHORA-SS-CABEC. */
            _.Move(AREA_DE_WORK.WHORA_ACCEPT.WSS_ACCEPT, AREA_DE_WORK.WHORA_CABEC.WHORA_SS_CABEC);

            /*" -464- DISPLAY 'INICIO DECLARE V1MESTSINI' WHORA-CABEC. */
            _.Display($"INICIO DECLARE V1MESTSINI{AREA_DE_WORK.WHORA_CABEC}");

            /*" -466- PERFORM R0400-00-DECLARE-V1MESTSINI. */

            R0400_00_DECLARE_V1MESTSINI_SECTION();

            /*" -467- ACCEPT WHORA-ACCEPT FROM TIME. */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WHORA_ACCEPT);

            /*" -468- MOVE WHH-ACCEPT TO WHORA-HH-CABEC. */
            _.Move(AREA_DE_WORK.WHORA_ACCEPT.WHH_ACCEPT, AREA_DE_WORK.WHORA_CABEC.WHORA_HH_CABEC);

            /*" -469- MOVE WMM-ACCEPT TO WHORA-MM-CABEC. */
            _.Move(AREA_DE_WORK.WHORA_ACCEPT.WMM_ACCEPT, AREA_DE_WORK.WHORA_CABEC.WHORA_MM_CABEC);

            /*" -471- MOVE WSS-ACCEPT TO WHORA-SS-CABEC. */
            _.Move(AREA_DE_WORK.WHORA_ACCEPT.WSS_ACCEPT, AREA_DE_WORK.WHORA_CABEC.WHORA_SS_CABEC);

            /*" -473- DISPLAY 'FINAL  DECLARE V1MESTSINI' WHORA-CABEC. */
            _.Display($"FINAL  DECLARE V1MESTSINI{AREA_DE_WORK.WHORA_CABEC}");

            /*" -475- PERFORM R0500-00-FETCH-V1MESTSINI. */

            R0500_00_FETCH_V1MESTSINI_SECTION();

            /*" -476- IF WFIM-V1MESTSINI NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WFIM_V1MESTSINI.IsEmpty())
            {

                /*" -477- PERFORM R9900-00-ENCERRA-SEM-MOVTO */

                R9900_00_ENCERRA_SEM_MOVTO_SECTION();

                /*" -478- ELSE */
            }
            else
            {


                /*" -480- PERFORM R0800-00-PROCESSA-REGISTRO UNTIL WFIM-V1MESTSINI NOT EQUAL SPACES */

                while (!(!AREA_DE_WORK.WFIM_V1MESTSINI.IsEmpty()))
                {

                    R0800_00_PROCESSA_REGISTRO_SECTION();
                }

                /*" -480- END-IF. */
            }


            /*" -0- FLUXCONTROL_PERFORM R0000_90_FINALIZA */

            R0000_90_FINALIZA();

        }

        [StopWatch]
        /*" R0000-90-FINALIZA */
        private void R0000_90_FINALIZA(bool isPerform = false)
        {
            /*" -485- DISPLAY 'SINISTROS LIDOS           - ' AC-L-V1MESTSINI. */
            _.Display($"SINISTROS LIDOS           - {AREA_DE_WORK.AC_L_V1MESTSINI}");

            /*" -486- DISPLAY 'SINISTROS COSSEG GRAVADOS - ' AC-I-V0COSSEGSINI. */
            _.Display($"SINISTROS COSSEG GRAVADOS - {AREA_DE_WORK.AC_I_V0COSSEGSINI}");

            /*" -487- DISPLAY 'SINISTROS COSSEG ATUALIZ. - ' AC-U-V0COSSEGSINI. */
            _.Display($"SINISTROS COSSEG ATUALIZ. - {AREA_DE_WORK.AC_U_V0COSSEGSINI}");

            /*" -489- DISPLAY 'HIST SINI COSSEG GRAVADOS - ' AC-I-V0COSSEGHSIN. */
            _.Display($"HIST SINI COSSEG GRAVADOS - {AREA_DE_WORK.AC_I_V0COSSEGHSIN}");

            /*" -489- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -493- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -493- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0100-00-SELECT-V1SISTEMA-SECTION */
        private void R0100_00_SELECT_V1SISTEMA_SECTION()
        {
            /*" -506- MOVE '010' TO WNR-EXEC-SQL. */
            _.Move("010", WABEND.WNR_EXEC_SQL);

            /*" -511- PERFORM R0100_00_SELECT_V1SISTEMA_DB_SELECT_1 */

            R0100_00_SELECT_V1SISTEMA_DB_SELECT_1();

            /*" -514- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -515- DISPLAY 'R0100 - ERRO NO SELECT DA V1SISTEMA' */
                _.Display($"R0100 - ERRO NO SELECT DA V1SISTEMA");

                /*" -516- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -517- ELSE */
            }
            else
            {


                /*" -518- DISPLAY 'DATA DO SISTEMA AC - ' V1SIST-DTMOVABE */
                _.Display($"DATA DO SISTEMA AC - {V1SIST_DTMOVABE}");

                /*" -518- END-IF. */
            }


        }

        [StopWatch]
        /*" R0100-00-SELECT-V1SISTEMA-DB-SELECT-1 */
        public void R0100_00_SELECT_V1SISTEMA_DB_SELECT_1()
        {
            /*" -511- EXEC SQL SELECT DTMOVABE INTO :V1SIST-DTMOVABE FROM SEGUROS.V1SISTEMA WHERE IDSISTEM = 'AC' END-EXEC. */

            var r0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1 = new R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1.Execute(r0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1SIST_DTMOVABE, V1SIST_DTMOVABE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/

        [StopWatch]
        /*" R0200-00-CHECA-EXECUCAO-SECTION */
        private void R0200_00_CHECA_EXECUCAO_SECTION()
        {
            /*" -531- MOVE '020' TO WNR-EXEC-SQL. */
            _.Move("020", WABEND.WNR_EXEC_SQL);

            /*" -540- PERFORM R0200_00_CHECA_EXECUCAO_DB_SELECT_1 */

            R0200_00_CHECA_EXECUCAO_DB_SELECT_1();

            /*" -543- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -544- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -545- MOVE ZEROS TO WHOST-QTDE-REG */
                    _.Move(0, WHOST_QTDE_REG);

                    /*" -546- ELSE */
                }
                else
                {


                    /*" -547- DISPLAY 'R0200 - ERRO NO SELECT DA V1COSSEG-HISTSIN' */
                    _.Display($"R0200 - ERRO NO SELECT DA V1COSSEG-HISTSIN");

                    /*" -548- DISPLAY 'DATA MOVTO - ' V1SIST-DTMOVABE */
                    _.Display($"DATA MOVTO - {V1SIST_DTMOVABE}");

                    /*" -549- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -550- END-IF */
                }


                /*" -550- END-IF. */
            }


        }

        [StopWatch]
        /*" R0200-00-CHECA-EXECUCAO-DB-SELECT-1 */
        public void R0200_00_CHECA_EXECUCAO_DB_SELECT_1()
        {
            /*" -540- EXEC SQL SELECT VALUE(COUNT(*),+0) INTO :WHOST-QTDE-REG FROM SEGUROS.V1COSSEG_HISTSIN A, SEGUROS.GE_OPERACAO B WHERE A.DTMOVTO = :V1SIST-DTMOVABE AND A.TIPSGU = '1' AND B.COD_OPERACAO = A.OPERACAO AND B.IDE_SISTEMA = 'SI' END-EXEC. */

            var r0200_00_CHECA_EXECUCAO_DB_SELECT_1_Query1 = new R0200_00_CHECA_EXECUCAO_DB_SELECT_1_Query1()
            {
                V1SIST_DTMOVABE = V1SIST_DTMOVABE.ToString(),
            };

            var executed_1 = R0200_00_CHECA_EXECUCAO_DB_SELECT_1_Query1.Execute(r0200_00_CHECA_EXECUCAO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_QTDE_REG, WHOST_QTDE_REG);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_99_SAIDA*/

        [StopWatch]
        /*" R0400-00-DECLARE-V1MESTSINI-SECTION */
        private void R0400_00_DECLARE_V1MESTSINI_SECTION()
        {
            /*" -563- MOVE '040' TO WNR-EXEC-SQL. */
            _.Move("040", WABEND.WNR_EXEC_SQL);

            /*" -593- PERFORM R0400_00_DECLARE_V1MESTSINI_DB_DECLARE_1 */

            R0400_00_DECLARE_V1MESTSINI_DB_DECLARE_1();

            /*" -595- PERFORM R0400_00_DECLARE_V1MESTSINI_DB_OPEN_1 */

            R0400_00_DECLARE_V1MESTSINI_DB_OPEN_1();

            /*" -598- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -599- DISPLAY 'R0400 - ERRO NO DECLARE DA V1MESTSINI' */
                _.Display($"R0400 - ERRO NO DECLARE DA V1MESTSINI");

                /*" -600- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -601- ELSE */
            }
            else
            {


                /*" -602- MOVE ZEROS TO WNUM-SINI-ANT */
                _.Move(0, AREA_DE_WORK.WNUM_SINI_ANT);

                /*" -603- MOVE SPACES TO WFIM-V1MESTSINI */
                _.Move("", AREA_DE_WORK.WFIM_V1MESTSINI);

                /*" -603- END-IF. */
            }


        }

        [StopWatch]
        /*" R0400-00-DECLARE-V1MESTSINI-DB-DECLARE-1 */
        public void R0400_00_DECLARE_V1MESTSINI_DB_DECLARE_1()
        {
            /*" -593- EXEC SQL DECLARE V1MESTSINI CURSOR FOR SELECT A.NUM_APOL_SINISTRO, A.NUM_APOLICE, A.NRENDOS, A.COD_MOEDA_SINI, A.TIPREG, A.RAMO, A.CODCAU, A.DATORR, A.PCTRES, B.OCORHIST, B.OPERACAO, B.DTMOVTO, B.VAL_OPERACAO, B.TIPREG, B.SITUACAO, C.FUNCAO_OPERACAO, C.IND_TIPO_FUNCAO FROM SEGUROS.V1MESTSINI A, SEGUROS.V1HISTSINI B, SEGUROS.GE_OPERACAO C WHERE B.DTMOVTO = :V1SIST-DTMOVABE AND B.TIPREG = '1' AND A.NUM_APOL_SINISTRO = B.NUM_APOL_SINISTRO AND C.IDE_SISTEMA = 'SI' AND C.COD_OPERACAO = B.OPERACAO ORDER BY A.NUM_APOL_SINISTRO, B.OCORHIST, B.OPERACAO END-EXEC. */
            V1MESTSINI = new AC0017B_V1MESTSINI(true);
            string GetQuery_V1MESTSINI()
            {
                var query = @$"SELECT A.NUM_APOL_SINISTRO
							, 
							A.NUM_APOLICE
							, 
							A.NRENDOS
							, 
							A.COD_MOEDA_SINI
							, 
							A.TIPREG
							, 
							A.RAMO
							, 
							A.CODCAU
							, 
							A.DATORR
							, 
							A.PCTRES
							, 
							B.OCORHIST
							, 
							B.OPERACAO
							, 
							B.DTMOVTO
							, 
							B.VAL_OPERACAO
							, 
							B.TIPREG
							, 
							B.SITUACAO
							, 
							C.FUNCAO_OPERACAO
							, 
							C.IND_TIPO_FUNCAO 
							FROM SEGUROS.V1MESTSINI A
							, 
							SEGUROS.V1HISTSINI B
							, 
							SEGUROS.GE_OPERACAO C 
							WHERE B.DTMOVTO = '{V1SIST_DTMOVABE}' 
							AND B.TIPREG = '1' 
							AND A.NUM_APOL_SINISTRO = B.NUM_APOL_SINISTRO 
							AND C.IDE_SISTEMA = 'SI' 
							AND C.COD_OPERACAO = B.OPERACAO 
							ORDER BY 
							A.NUM_APOL_SINISTRO
							, 
							B.OCORHIST
							, 
							B.OPERACAO";

                return query;
            }
            V1MESTSINI.GetQueryEvent += GetQuery_V1MESTSINI;

        }

        [StopWatch]
        /*" R0400-00-DECLARE-V1MESTSINI-DB-OPEN-1 */
        public void R0400_00_DECLARE_V1MESTSINI_DB_OPEN_1()
        {
            /*" -595- EXEC SQL OPEN V1MESTSINI END-EXEC. */

            V1MESTSINI.Open();

        }

        [StopWatch]
        /*" R1400-00-DECLARE-V1APOLCOSCED-DB-DECLARE-1 */
        public void R1400_00_DECLARE_V1APOLCOSCED_DB_DECLARE_1()
        {
            /*" -1121- EXEC SQL DECLARE V1APOLCOSCED CURSOR FOR SELECT CODCOSS , PCPARTIC , PCCOMCOS FROM SEGUROS.V1APOLCOSCED WHERE NUM_APOLICE = :V1MSIN-NUM-APOL AND DTINIVIG <= :V1MSIN-DATORR AND DTTERVIG >= :V1MSIN-DATORR AND PCPARTIC >= 0 ORDER BY CODCOSS END-EXEC. */
            V1APOLCOSCED = new AC0017B_V1APOLCOSCED(true);
            string GetQuery_V1APOLCOSCED()
            {
                var query = @$"SELECT CODCOSS
							, 
							PCPARTIC
							, 
							PCCOMCOS 
							FROM SEGUROS.V1APOLCOSCED 
							WHERE NUM_APOLICE = '{V1MSIN_NUM_APOL}' 
							AND DTINIVIG <= '{V1MSIN_DATORR}' 
							AND DTTERVIG >= '{V1MSIN_DATORR}' 
							AND PCPARTIC >= 0 
							ORDER BY 
							CODCOSS";

                return query;
            }
            V1APOLCOSCED.GetQueryEvent += GetQuery_V1APOLCOSCED;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0400_99_SAIDA*/

        [StopWatch]
        /*" R0500-00-FETCH-V1MESTSINI-SECTION */
        private void R0500_00_FETCH_V1MESTSINI_SECTION()
        {
            /*" -614- MOVE '050' TO WNR-EXEC-SQL. */
            _.Move("050", WABEND.WNR_EXEC_SQL);

            /*" -0- FLUXCONTROL_PERFORM R0500_10_LER_V1MESTSINI */

            R0500_10_LER_V1MESTSINI();

        }

        [StopWatch]
        /*" R0500-10-LER-V1MESTSINI */
        private void R0500_10_LER_V1MESTSINI(bool isPerform = false)
        {
            /*" -636- PERFORM R0500_10_LER_V1MESTSINI_DB_FETCH_1 */

            R0500_10_LER_V1MESTSINI_DB_FETCH_1();

            /*" -639- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -640- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -641- MOVE 'S' TO WFIM-V1MESTSINI */
                    _.Move("S", AREA_DE_WORK.WFIM_V1MESTSINI);

                    /*" -641- PERFORM R0500_10_LER_V1MESTSINI_DB_CLOSE_1 */

                    R0500_10_LER_V1MESTSINI_DB_CLOSE_1();

                    /*" -643- GO TO R0500-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0500_99_SAIDA*/ //GOTO
                    return;

                    /*" -644- ELSE */
                }
                else
                {


                    /*" -645- DISPLAY 'R0500 - ERRO NO FETCH DA V1MESTSINI' */
                    _.Display($"R0500 - ERRO NO FETCH DA V1MESTSINI");

                    /*" -646- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -647- END-IF */
                }


                /*" -648- ELSE */
            }
            else
            {


                /*" -649- IF GEOPERAC-FUNCAO-OPERACAO = 'FINAN' */

                if (GEOPERAC.DCLGE_OPERACAO.GEOPERAC_FUNCAO_OPERACAO == "FINAN")
                {

                    /*" -650- GO TO R0500-10-LER-V1MESTSINI */
                    new Task(() => R0500_10_LER_V1MESTSINI()).RunSynchronously(); //GOTO
                    return;//Recursividade detectada, cuidado...

                    /*" -651- ELSE */
                }
                else
                {


                    /*" -656- IF GEOPERAC-IND-TIPO-FUNCAO = 'PE' OR 'R1' OR GEOPERAC-IND-TIPO-FUNCAO = 'IN-REGIST' OR GEOPERAC-IND-TIPO-FUNCAO = 'EST-REGIST' OR GEOPERAC-IND-TIPO-FUNCAO = 'PRE-REGIST' OR GEOPERAC-IND-TIPO-FUNCAO = 'JUR-DEP' OR 'JUR-FINAL' */

                    if (GEOPERAC.DCLGE_OPERACAO.GEOPERAC_IND_TIPO_FUNCAO.In("PE", "R1") || GEOPERAC.DCLGE_OPERACAO.GEOPERAC_IND_TIPO_FUNCAO == "IN-REGIST" || GEOPERAC.DCLGE_OPERACAO.GEOPERAC_IND_TIPO_FUNCAO == "EST-REGIST" || GEOPERAC.DCLGE_OPERACAO.GEOPERAC_IND_TIPO_FUNCAO == "PRE-REGIST" || GEOPERAC.DCLGE_OPERACAO.GEOPERAC_IND_TIPO_FUNCAO.In("JUR-DEP", "JUR-FINAL"))
                    {

                        /*" -657- GO TO R0500-10-LER-V1MESTSINI */
                        new Task(() => R0500_10_LER_V1MESTSINI()).RunSynchronously(); //GOTO
                        return;//Recursividade detectada, cuidado...

                        /*" -658- END-IF */
                    }


                    /*" -659- END-IF */
                }


                /*" -661- END-IF. */
            }


            /*" -662- IF V1MSIN-NUM-SINI = 0109300144836 */

            if (V1MSIN_NUM_SINI == 0109300144836)
            {

                /*" -663- GO TO R0500-10-LER-V1MESTSINI */
                new Task(() => R0500_10_LER_V1MESTSINI()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...

                /*" -664- ELSE */
            }
            else
            {


                /*" -665- MOVE V1MSIN-NUM-SINI TO WNUM-SINISTRO */
                _.Move(V1MSIN_NUM_SINI, AREA_DE_WORK.WNUM_SINISTRO);

                /*" -666- IF WORG-SINI = 140 */

                if (AREA_DE_WORK.WNUM_SINI_R.WORG_SINI == 140)
                {

                    /*" -667- GO TO R0500-10-LER-V1MESTSINI */
                    new Task(() => R0500_10_LER_V1MESTSINI()).RunSynchronously(); //GOTO
                    return;//Recursividade detectada, cuidado...

                    /*" -668- END-IF */
                }


                /*" -672- END-IF. */
            }


            /*" -673- IF V1MSIN-RAMO = 93 */

            if (V1MSIN_RAMO == 93)
            {

                /*" -675- IF V1MSIN-CODCAU = 17 OR 19 OR 20 OR 21 OR 22 OR V1MSIN-CODCAU = 23 OR 24 OR 25 OR 26 OR 27 */

                if (V1MSIN_CODCAU.In("17", "19", "20", "21", "22") || V1MSIN_CODCAU.In("23", "24", "25", "26", "27"))
                {

                    /*" -676- GO TO R0500-10-LER-V1MESTSINI */
                    new Task(() => R0500_10_LER_V1MESTSINI()).RunSynchronously(); //GOTO
                    return;//Recursividade detectada, cuidado...

                    /*" -678- ELSE NEXT SENTENCE */
                }
                else
                {


                    /*" -679- END-IF */
                }


                /*" -680- ELSE */
            }
            else
            {


                /*" -682- IF V1MSIN-RAMO = 81 AND V1MSIN-CODCAU = 22 */

                if (V1MSIN_RAMO == 81 && V1MSIN_CODCAU == 22)
                {

                    /*" -683- GO TO R0500-10-LER-V1MESTSINI */
                    new Task(() => R0500_10_LER_V1MESTSINI()).RunSynchronously(); //GOTO
                    return;//Recursividade detectada, cuidado...

                    /*" -684- END-IF */
                }


                /*" -688- END-IF. */
            }


            /*" -689- IF V1MSIN-RAMO = 66 */

            if (V1MSIN_RAMO == 66)
            {

                /*" -690- IF V1HSIN-OPERACAO = 2017 OR 3017 */

                if (V1HSIN_OPERACAO.In("2017", "3017"))
                {

                    /*" -691- GO TO R0500-10-LER-V1MESTSINI */
                    new Task(() => R0500_10_LER_V1MESTSINI()).RunSynchronously(); //GOTO
                    return;//Recursividade detectada, cuidado...

                    /*" -692- ELSE */
                }
                else
                {


                    /*" -693- IF V1HSIN-OPERACAO = 2010 OR 3010 */

                    if (V1HSIN_OPERACAO.In("2010", "3010"))
                    {

                        /*" -694- MOVE ZEROS TO WHOST-OPERACAO */
                        _.Move(0, WHOST_OPERACAO);

                        /*" -695- PERFORM R0600-00-SELECT-2017-3017 */

                        R0600_00_SELECT_2017_3017_SECTION();

                        /*" -696- IF WHOST-OPERACAO = 2017 OR 3017 */

                        if (WHOST_OPERACAO.In("2017", "3017"))
                        {

                            /*" -697- GO TO R0500-10-LER-V1MESTSINI */
                            new Task(() => R0500_10_LER_V1MESTSINI()).RunSynchronously(); //GOTO
                            return;//Recursividade detectada, cuidado...

                            /*" -699- ELSE NEXT SENTENCE */
                        }
                        else
                        {


                            /*" -700- END-IF */
                        }


                        /*" -702- ELSE NEXT SENTENCE */
                    }
                    else
                    {


                        /*" -703- END-IF */
                    }


                    /*" -704- END-IF */
                }


                /*" -705- ELSE */
            }
            else
            {


                /*" -706- IF V1MSIN-RAMO = 31 */

                if (V1MSIN_RAMO == 31)
                {

                    /*" -707- IF V1HSIN-OPERACAO = 3035 */

                    if (V1HSIN_OPERACAO == 3035)
                    {

                        /*" -708- GO TO R0500-10-LER-V1MESTSINI */
                        new Task(() => R0500_10_LER_V1MESTSINI()).RunSynchronously(); //GOTO
                        return;//Recursividade detectada, cuidado...

                        /*" -709- ELSE */
                    }
                    else
                    {


                        /*" -710- IF V1HSIN-OPERACAO = 3010 */

                        if (V1HSIN_OPERACAO == 3010)
                        {

                            /*" -711- MOVE ZEROS TO WHOST-OPERACAO */
                            _.Move(0, WHOST_OPERACAO);

                            /*" -712- PERFORM R0700-00-SELECT-OPER-3035 */

                            R0700_00_SELECT_OPER_3035_SECTION();

                            /*" -713- IF WHOST-OPERACAO = 3035 */

                            if (WHOST_OPERACAO == 3035)
                            {

                                /*" -714- GO TO R0500-10-LER-V1MESTSINI */
                                new Task(() => R0500_10_LER_V1MESTSINI()).RunSynchronously(); //GOTO
                                return;//Recursividade detectada, cuidado...

                                /*" -715- END-IF */
                            }


                            /*" -716- END-IF */
                        }


                        /*" -717- END-IF */
                    }


                    /*" -718- END-IF */
                }


                /*" -722- END-IF. */
            }


            /*" -727- ADD 1 TO AC-COUNT AC-L-V1MESTSINI. */
            AREA_DE_WORK.AC_COUNT.Value = AREA_DE_WORK.AC_COUNT + 1;
            AREA_DE_WORK.AC_L_V1MESTSINI.Value = AREA_DE_WORK.AC_L_V1MESTSINI + 1;

            /*" -728- IF AC-COUNT = 5000 */

            if (AREA_DE_WORK.AC_COUNT == 5000)
            {

                /*" -729- MOVE +0 TO AC-COUNT */
                _.Move(+0, AREA_DE_WORK.AC_COUNT);

                /*" -730- ACCEPT WHORA-ACCEPT FROM TIME */
                _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WHORA_ACCEPT);

                /*" -731- MOVE WHH-ACCEPT TO WHORA-HH-CABEC */
                _.Move(AREA_DE_WORK.WHORA_ACCEPT.WHH_ACCEPT, AREA_DE_WORK.WHORA_CABEC.WHORA_HH_CABEC);

                /*" -732- MOVE WMM-ACCEPT TO WHORA-MM-CABEC */
                _.Move(AREA_DE_WORK.WHORA_ACCEPT.WMM_ACCEPT, AREA_DE_WORK.WHORA_CABEC.WHORA_MM_CABEC);

                /*" -733- MOVE WSS-ACCEPT TO WHORA-SS-CABEC */
                _.Move(AREA_DE_WORK.WHORA_ACCEPT.WSS_ACCEPT, AREA_DE_WORK.WHORA_CABEC.WHORA_SS_CABEC);

                /*" -735- DISPLAY AC-L-V1MESTSINI ' LIDOS NA V1MESTSINI ' WHORA-CABEC */

                $"{AREA_DE_WORK.AC_L_V1MESTSINI} LIDOS NA V1MESTSINI {AREA_DE_WORK.WHORA_CABEC}"
                .Display();

                /*" -735- END-IF. */
            }


        }

        [StopWatch]
        /*" R0500-10-LER-V1MESTSINI-DB-FETCH-1 */
        public void R0500_10_LER_V1MESTSINI_DB_FETCH_1()
        {
            /*" -636- EXEC SQL FETCH V1MESTSINI INTO :V1MSIN-NUM-SINI , :V1MSIN-NUM-APOL , :V1MSIN-NRENDOS , :V1MSIN-COD-MOEDA , :V1MSIN-TIPREG , :V1MSIN-RAMO , :V1MSIN-CODCAU , :V1MSIN-DATORR , :V1MSIN-PCTRES , :V1HSIN-OCORHIST , :V1HSIN-OPERACAO , :V1HSIN-DTMOVTO , :V1HSIN-VAL-OPER , :V1HSIN-TIPREG , :V1HSIN-SITUACAO , :GEOPERAC-FUNCAO-OPERACAO, :GEOPERAC-IND-TIPO-FUNCAO END-EXEC. */

            if (V1MESTSINI.Fetch())
            {
                _.Move(V1MESTSINI.V1MSIN_NUM_SINI, V1MSIN_NUM_SINI);
                _.Move(V1MESTSINI.V1MSIN_NUM_APOL, V1MSIN_NUM_APOL);
                _.Move(V1MESTSINI.V1MSIN_NRENDOS, V1MSIN_NRENDOS);
                _.Move(V1MESTSINI.V1MSIN_COD_MOEDA, V1MSIN_COD_MOEDA);
                _.Move(V1MESTSINI.V1MSIN_TIPREG, V1MSIN_TIPREG);
                _.Move(V1MESTSINI.V1MSIN_RAMO, V1MSIN_RAMO);
                _.Move(V1MESTSINI.V1MSIN_CODCAU, V1MSIN_CODCAU);
                _.Move(V1MESTSINI.V1MSIN_DATORR, V1MSIN_DATORR);
                _.Move(V1MESTSINI.V1MSIN_PCTRES, V1MSIN_PCTRES);
                _.Move(V1MESTSINI.V1HSIN_OCORHIST, V1HSIN_OCORHIST);
                _.Move(V1MESTSINI.V1HSIN_OPERACAO, V1HSIN_OPERACAO);
                _.Move(V1MESTSINI.V1HSIN_DTMOVTO, V1HSIN_DTMOVTO);
                _.Move(V1MESTSINI.V1HSIN_VAL_OPER, V1HSIN_VAL_OPER);
                _.Move(V1MESTSINI.V1HSIN_TIPREG, V1HSIN_TIPREG);
                _.Move(V1MESTSINI.V1HSIN_SITUACAO, V1HSIN_SITUACAO);
                _.Move(V1MESTSINI.GEOPERAC_FUNCAO_OPERACAO, GEOPERAC.DCLGE_OPERACAO.GEOPERAC_FUNCAO_OPERACAO);
                _.Move(V1MESTSINI.GEOPERAC_IND_TIPO_FUNCAO, GEOPERAC.DCLGE_OPERACAO.GEOPERAC_IND_TIPO_FUNCAO);
            }

        }

        [StopWatch]
        /*" R0500-10-LER-V1MESTSINI-DB-CLOSE-1 */
        public void R0500_10_LER_V1MESTSINI_DB_CLOSE_1()
        {
            /*" -641- EXEC SQL CLOSE V1MESTSINI END-EXEC */

            V1MESTSINI.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0500_99_SAIDA*/

        [StopWatch]
        /*" R0600-00-SELECT-2017-3017-SECTION */
        private void R0600_00_SELECT_2017_3017_SECTION()
        {
            /*" -748- MOVE '060' TO WNR-EXEC-SQL. */
            _.Move("060", WABEND.WNR_EXEC_SQL);

            /*" -755- PERFORM R0600_00_SELECT_2017_3017_DB_SELECT_1 */

            R0600_00_SELECT_2017_3017_DB_SELECT_1();

            /*" -758- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -759- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -760- MOVE ZEROS TO WHOST-OPERACAO */
                    _.Move(0, WHOST_OPERACAO);

                    /*" -761- ELSE */
                }
                else
                {


                    /*" -762- DISPLAY 'R0600 - ERRO NO SELECT DA V0HISTSINI' */
                    _.Display($"R0600 - ERRO NO SELECT DA V0HISTSINI");

                    /*" -763- DISPLAY 'SINISTRO - ' V1MSIN-NUM-SINI */
                    _.Display($"SINISTRO - {V1MSIN_NUM_SINI}");

                    /*" -764- DISPLAY 'OC. HIST - ' V1HSIN-OCORHIST */
                    _.Display($"OC. HIST - {V1HSIN_OCORHIST}");

                    /*" -765- DISPLAY 'OPERACAO - ' V1HSIN-OPERACAO */
                    _.Display($"OPERACAO - {V1HSIN_OPERACAO}");

                    /*" -766- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -767- END-IF */
                }


                /*" -767- END-IF. */
            }


        }

        [StopWatch]
        /*" R0600-00-SELECT-2017-3017-DB-SELECT-1 */
        public void R0600_00_SELECT_2017_3017_DB_SELECT_1()
        {
            /*" -755- EXEC SQL SELECT OPERACAO INTO :WHOST-OPERACAO FROM SEGUROS.V0HISTSINI WHERE NUM_APOL_SINISTRO = :V1MSIN-NUM-SINI AND OCORHIST = :V1HSIN-OCORHIST AND OPERACAO IN (2017,3017) END-EXEC. */

            var r0600_00_SELECT_2017_3017_DB_SELECT_1_Query1 = new R0600_00_SELECT_2017_3017_DB_SELECT_1_Query1()
            {
                V1MSIN_NUM_SINI = V1MSIN_NUM_SINI.ToString(),
                V1HSIN_OCORHIST = V1HSIN_OCORHIST.ToString(),
            };

            var executed_1 = R0600_00_SELECT_2017_3017_DB_SELECT_1_Query1.Execute(r0600_00_SELECT_2017_3017_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_OPERACAO, WHOST_OPERACAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0600_99_SAIDA*/

        [StopWatch]
        /*" R0700-00-SELECT-OPER-3035-SECTION */
        private void R0700_00_SELECT_OPER_3035_SECTION()
        {
            /*" -780- MOVE '070' TO WNR-EXEC-SQL. */
            _.Move("070", WABEND.WNR_EXEC_SQL);

            /*" -787- PERFORM R0700_00_SELECT_OPER_3035_DB_SELECT_1 */

            R0700_00_SELECT_OPER_3035_DB_SELECT_1();

            /*" -790- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -791- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -792- MOVE ZEROS TO WHOST-OPERACAO */
                    _.Move(0, WHOST_OPERACAO);

                    /*" -793- ELSE */
                }
                else
                {


                    /*" -794- DISPLAY 'R0700 - ERRO NO SELECT DA V0HISTSINI' */
                    _.Display($"R0700 - ERRO NO SELECT DA V0HISTSINI");

                    /*" -795- DISPLAY 'SINISTRO - ' V1MSIN-NUM-SINI */
                    _.Display($"SINISTRO - {V1MSIN_NUM_SINI}");

                    /*" -796- DISPLAY 'OC. HIST - ' V1HSIN-OCORHIST */
                    _.Display($"OC. HIST - {V1HSIN_OCORHIST}");

                    /*" -797- DISPLAY 'OPERACAO - ' V1HSIN-OPERACAO */
                    _.Display($"OPERACAO - {V1HSIN_OPERACAO}");

                    /*" -798- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -799- END-IF */
                }


                /*" -799- END-IF. */
            }


        }

        [StopWatch]
        /*" R0700-00-SELECT-OPER-3035-DB-SELECT-1 */
        public void R0700_00_SELECT_OPER_3035_DB_SELECT_1()
        {
            /*" -787- EXEC SQL SELECT OPERACAO INTO :WHOST-OPERACAO FROM SEGUROS.V0HISTSINI WHERE NUM_APOL_SINISTRO = :V1MSIN-NUM-SINI AND OCORHIST = :V1HSIN-OCORHIST AND OPERACAO = 3035 END-EXEC. */

            var r0700_00_SELECT_OPER_3035_DB_SELECT_1_Query1 = new R0700_00_SELECT_OPER_3035_DB_SELECT_1_Query1()
            {
                V1MSIN_NUM_SINI = V1MSIN_NUM_SINI.ToString(),
                V1HSIN_OCORHIST = V1HSIN_OCORHIST.ToString(),
            };

            var executed_1 = R0700_00_SELECT_OPER_3035_DB_SELECT_1_Query1.Execute(r0700_00_SELECT_OPER_3035_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_OPERACAO, WHOST_OPERACAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0700_99_SAIDA*/

        [StopWatch]
        /*" R0800-00-PROCESSA-REGISTRO-SECTION */
        private void R0800_00_PROCESSA_REGISTRO_SECTION()
        {
            /*" -825- MOVE '080' TO WNR-EXEC-SQL. */
            _.Move("080", WABEND.WNR_EXEC_SQL);

            /*" -831- PERFORM R1000-00-SELECT-GESISFUO. */

            R1000_00_SELECT_GESISFUO_SECTION();

            /*" -832- IF V1MSIN-RAMO = 66 */

            if (V1MSIN_RAMO == 66)
            {

                /*" -833- IF GESISFUO-NUM-FATOR = -1 */

                if (GESISFUO.DCLGE_SIS_FUNCAO_OPER.GESISFUO_NUM_FATOR == -1)
                {

                    /*" -834- PERFORM R1050-00-SELECT-V0HISTSINI */

                    R1050_00_SELECT_V0HISTSINI_SECTION();

                    /*" -835- MOVE WHOST-DTMOVTO TO WDATA-SQL */
                    _.Move(WHOST_DTMOVTO, AREA_DE_WORK.WDATA_SQL);

                    /*" -836- ELSE */
                }
                else
                {


                    /*" -837- MOVE V1HSIN-DTMOVTO TO WDATA-SQL */
                    _.Move(V1HSIN_DTMOVTO, AREA_DE_WORK.WDATA_SQL);

                    /*" -838- END-IF */
                }


                /*" -839- PERFORM R1100-00-CALCULA-DATORR */

                R1100_00_CALCULA_DATORR_SECTION();

                /*" -840- MOVE WDATA-SQL TO V1MSIN-DATORR */
                _.Move(AREA_DE_WORK.WDATA_SQL, V1MSIN_DATORR);

                /*" -844- END-IF. */
            }


            /*" -846- PERFORM R1200-00-SELECT-V0APOLICE. */

            R1200_00_SELECT_V0APOLICE_SECTION();

            /*" -847- IF GEOPERAC-IND-TIPO-FUNCAO = 'DS' OR 'HS' */

            if (GEOPERAC.DCLGE_OPERACAO.GEOPERAC_IND_TIPO_FUNCAO.In("DS", "HS"))
            {

                /*" -849- IF V0APOL-RAMO = 31 OR 53 NEXT SENTENCE */

                if (V0APOL_RAMO.In("31", "53"))
                {

                    /*" -850- ELSE */
                }
                else
                {


                    /*" -851- GO TO R0800-90-LER-REGISTRO */

                    R0800_90_LER_REGISTRO(); //GOTO
                    return;

                    /*" -852- END-IF */
                }


                /*" -854- END-IF. */
            }


            /*" -856- IF V0APOL-TIPSGU = '1' AND (V0APOL-ORGAO = 10 OR 100 OR 110 OR 300) */

            if (V0APOL_TIPSGU == "1" && (V0APOL_ORGAO.In("10", "100", "110", "300")))
            {

                /*" -857- PERFORM R1400-00-DECLARE-V1APOLCOSCED */

                R1400_00_DECLARE_V1APOLCOSCED_SECTION();

                /*" -858- PERFORM R1450-00-FETCH-V1APOLCOSCED */

                R1450_00_FETCH_V1APOLCOSCED_SECTION();

                /*" -859- IF WFIM-V1APOLCOSCED = SPACES */

                if (AREA_DE_WORK.WFIM_V1APOLCOSCED.IsEmpty())
                {

                    /*" -860- PERFORM R1500-00-SELECT-V0COTACAO */

                    R1500_00_SELECT_V0COTACAO_SECTION();

                    /*" -862- PERFORM R1600-00-GRAVA-REGISTRO UNTIL WFIM-V1APOLCOSCED NOT EQUAL SPACES */

                    while (!(!AREA_DE_WORK.WFIM_V1APOLCOSCED.IsEmpty()))
                    {

                        R1600_00_GRAVA_REGISTRO_SECTION();
                    }

                    /*" -863- END-IF */
                }


                /*" -863- END-IF. */
            }


            /*" -0- FLUXCONTROL_PERFORM R0800_90_LER_REGISTRO */

            R0800_90_LER_REGISTRO();

        }

        [StopWatch]
        /*" R0800-90-LER-REGISTRO */
        private void R0800_90_LER_REGISTRO(bool isPerform = false)
        {
            /*" -869- PERFORM R0500-00-FETCH-V1MESTSINI. */

            R0500_00_FETCH_V1MESTSINI_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0800_99_SAIDA*/

        [StopWatch]
        /*" R0900-00-SELECT-DATA-AVISO-SECTION */
        private void R0900_00_SELECT_DATA_AVISO_SECTION()
        {
            /*" -882- MOVE '090' TO WNR-EXEC-SQL. */
            _.Move("090", WABEND.WNR_EXEC_SQL);

            /*" -889- PERFORM R0900_00_SELECT_DATA_AVISO_DB_SELECT_1 */

            R0900_00_SELECT_DATA_AVISO_DB_SELECT_1();

            /*" -892- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -893- DISPLAY 'R0900 - ERRO NO SELECT DA V0HISTSINI' */
                _.Display($"R0900 - ERRO NO SELECT DA V0HISTSINI");

                /*" -894- DISPLAY 'SINISTRO - ' V1MSIN-NUM-SINI */
                _.Display($"SINISTRO - {V1MSIN_NUM_SINI}");

                /*" -895- DISPLAY 'OC. HIST - 01' */
                _.Display($"OC. HIST - 01");

                /*" -896- DISPLAY 'OPERACAO - 0101' */
                _.Display($"OPERACAO - 0101");

                /*" -897- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -897- END-IF. */
            }


        }

        [StopWatch]
        /*" R0900-00-SELECT-DATA-AVISO-DB-SELECT-1 */
        public void R0900_00_SELECT_DATA_AVISO_DB_SELECT_1()
        {
            /*" -889- EXEC SQL SELECT DTMOVTO INTO :WHOST-DATA-AVS FROM SEGUROS.V0HISTSINI WHERE NUM_APOL_SINISTRO = :V1MSIN-NUM-SINI AND OCORHIST = 01 AND OPERACAO = 0101 END-EXEC. */

            var r0900_00_SELECT_DATA_AVISO_DB_SELECT_1_Query1 = new R0900_00_SELECT_DATA_AVISO_DB_SELECT_1_Query1()
            {
                V1MSIN_NUM_SINI = V1MSIN_NUM_SINI.ToString(),
            };

            var executed_1 = R0900_00_SELECT_DATA_AVISO_DB_SELECT_1_Query1.Execute(r0900_00_SELECT_DATA_AVISO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_DATA_AVS, WHOST_DATA_AVS);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0900_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-SELECT-GESISFUO-SECTION */
        private void R1000_00_SELECT_GESISFUO_SECTION()
        {
            /*" -910- MOVE '100' TO WNR-EXEC-SQL. */
            _.Move("100", WABEND.WNR_EXEC_SQL);

            /*" -945- PERFORM R1000_00_SELECT_GESISFUO_DB_SELECT_1 */

            R1000_00_SELECT_GESISFUO_DB_SELECT_1();

            /*" -948- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -949- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -950- MOVE ZEROS TO GESISFUO-NUM-FATOR */
                    _.Move(0, GESISFUO.DCLGE_SIS_FUNCAO_OPER.GESISFUO_NUM_FATOR);

                    /*" -951- MOVE ZEROS TO GESISFUO-COD-FUNCAO */
                    _.Move(0, GESISFUO.DCLGE_SIS_FUNCAO_OPER.GESISFUO_COD_FUNCAO);

                    /*" -952- MOVE SPACES TO GESISFUO-IDE-SISTEMA */
                    _.Move("", GESISFUO.DCLGE_SIS_FUNCAO_OPER.GESISFUO_IDE_SISTEMA);

                    /*" -953- MOVE SPACES TO GESISFUO-IDE-SISTEMA-OPER */
                    _.Move("", GESISFUO.DCLGE_SIS_FUNCAO_OPER.GESISFUO_IDE_SISTEMA_OPER);

                    /*" -954- ELSE */
                }
                else
                {


                    /*" -955- DISPLAY 'R1000 - ERRO NO SELECT DA GE-SIS-FUNCAO-OPER' */
                    _.Display($"R1000 - ERRO NO SELECT DA GE-SIS-FUNCAO-OPER");

                    /*" -956- DISPLAY 'SINISTRO - ' V1MSIN-NUM-SINI */
                    _.Display($"SINISTRO - {V1MSIN_NUM_SINI}");

                    /*" -957- DISPLAY 'OC. HIST - ' V1HSIN-OCORHIST */
                    _.Display($"OC. HIST - {V1HSIN_OCORHIST}");

                    /*" -958- DISPLAY 'DT. MOVT - ' V1HSIN-DTMOVTO */
                    _.Display($"DT. MOVT - {V1HSIN_DTMOVTO}");

                    /*" -959- DISPLAY 'OPERACAO - ' V1HSIN-OPERACAO */
                    _.Display($"OPERACAO - {V1HSIN_OPERACAO}");

                    /*" -960- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -961- END-IF */
                }


                /*" -961- END-IF. */
            }


        }

        [StopWatch]
        /*" R1000-00-SELECT-GESISFUO-DB-SELECT-1 */
        public void R1000_00_SELECT_GESISFUO_DB_SELECT_1()
        {
            /*" -945- EXEC SQL SELECT IDE_SISTEMA, COD_FUNCAO, IDE_SISTEMA_OPER, NUM_FATOR INTO :GESISFUO-IDE-SISTEMA, :GESISFUO-COD-FUNCAO, :GESISFUO-IDE-SISTEMA-OPER, :GESISFUO-NUM-FATOR FROM SEGUROS.GE_SIS_FUNCAO_OPER WHERE IDE_SISTEMA = 'SI' AND COD_FUNCAO IN (02,05,06,08,12,15, 16,17,18,20,21,22, 24,25,26,34) AND IDE_SISTEMA_OPER = IDE_SISTEMA AND COD_OPERACAO = :V1HSIN-OPERACAO END-EXEC. */

            var r1000_00_SELECT_GESISFUO_DB_SELECT_1_Query1 = new R1000_00_SELECT_GESISFUO_DB_SELECT_1_Query1()
            {
                V1HSIN_OPERACAO = V1HSIN_OPERACAO.ToString(),
            };

            var executed_1 = R1000_00_SELECT_GESISFUO_DB_SELECT_1_Query1.Execute(r1000_00_SELECT_GESISFUO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.GESISFUO_IDE_SISTEMA, GESISFUO.DCLGE_SIS_FUNCAO_OPER.GESISFUO_IDE_SISTEMA);
                _.Move(executed_1.GESISFUO_COD_FUNCAO, GESISFUO.DCLGE_SIS_FUNCAO_OPER.GESISFUO_COD_FUNCAO);
                _.Move(executed_1.GESISFUO_IDE_SISTEMA_OPER, GESISFUO.DCLGE_SIS_FUNCAO_OPER.GESISFUO_IDE_SISTEMA_OPER);
                _.Move(executed_1.GESISFUO_NUM_FATOR, GESISFUO.DCLGE_SIS_FUNCAO_OPER.GESISFUO_NUM_FATOR);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1050-00-SELECT-V0HISTSINI-SECTION */
        private void R1050_00_SELECT_V0HISTSINI_SECTION()
        {
            /*" -974- MOVE '105' TO WNR-EXEC-SQL. */
            _.Move("105", WABEND.WNR_EXEC_SQL);

            /*" -986- PERFORM R1050_00_SELECT_V0HISTSINI_DB_SELECT_1 */

            R1050_00_SELECT_V0HISTSINI_DB_SELECT_1();

            /*" -989- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -990- DISPLAY 'R1050 - ERRO NO SELECT DA V0HISTSINI' */
                _.Display($"R1050 - ERRO NO SELECT DA V0HISTSINI");

                /*" -991- DISPLAY 'SINISTRO - ' V1MSIN-NUM-SINI */
                _.Display($"SINISTRO - {V1MSIN_NUM_SINI}");

                /*" -992- DISPLAY 'OC. HIST - ' V1HSIN-OCORHIST */
                _.Display($"OC. HIST - {V1HSIN_OCORHIST}");

                /*" -993- DISPLAY 'OPERACAO - ' V1HSIN-OPERACAO */
                _.Display($"OPERACAO - {V1HSIN_OPERACAO}");

                /*" -994- DISPLAY 'DT. MOVT - ' V1HSIN-DTMOVTO */
                _.Display($"DT. MOVT - {V1HSIN_DTMOVTO}");

                /*" -995- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -995- END-IF. */
            }


        }

        [StopWatch]
        /*" R1050-00-SELECT-V0HISTSINI-DB-SELECT-1 */
        public void R1050_00_SELECT_V0HISTSINI_DB_SELECT_1()
        {
            /*" -986- EXEC SQL SELECT A.DTMOVTO INTO :WHOST-DTMOVTO FROM SEGUROS.V0HISTSINI A, SEGUROS.GE_SIS_FUNCAO_OPER B WHERE A.NUM_APOL_SINISTRO = :V1MSIN-NUM-SINI AND A.OCORHIST = :V1HSIN-OCORHIST AND B.IDE_SISTEMA = :GESISFUO-IDE-SISTEMA AND B.COD_FUNCAO = :GESISFUO-COD-FUNCAO AND B.IDE_SISTEMA_OPER = :GESISFUO-IDE-SISTEMA-OPER AND B.COD_OPERACAO = A.OPERACAO AND B.NUM_FATOR = 1 END-EXEC. */

            var r1050_00_SELECT_V0HISTSINI_DB_SELECT_1_Query1 = new R1050_00_SELECT_V0HISTSINI_DB_SELECT_1_Query1()
            {
                GESISFUO_IDE_SISTEMA_OPER = GESISFUO.DCLGE_SIS_FUNCAO_OPER.GESISFUO_IDE_SISTEMA_OPER.ToString(),
                GESISFUO_IDE_SISTEMA = GESISFUO.DCLGE_SIS_FUNCAO_OPER.GESISFUO_IDE_SISTEMA.ToString(),
                GESISFUO_COD_FUNCAO = GESISFUO.DCLGE_SIS_FUNCAO_OPER.GESISFUO_COD_FUNCAO.ToString(),
                V1MSIN_NUM_SINI = V1MSIN_NUM_SINI.ToString(),
                V1HSIN_OCORHIST = V1HSIN_OCORHIST.ToString(),
            };

            var executed_1 = R1050_00_SELECT_V0HISTSINI_DB_SELECT_1_Query1.Execute(r1050_00_SELECT_V0HISTSINI_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_DTMOVTO, WHOST_DTMOVTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1050_99_SAIDA*/

        [StopWatch]
        /*" R1100-00-CALCULA-DATORR-SECTION */
        private void R1100_00_CALCULA_DATORR_SECTION()
        {
            /*" -1008- MOVE '110' TO WNR-EXEC-SQL. */
            _.Move("110", WABEND.WNR_EXEC_SQL);

            /*" -1010- SUBTRACT 2 FROM WDATA-SQL-MES GIVING WMES. */
            AREA_DE_WORK.WMES.Value = AREA_DE_WORK.FILLER_3.WDATA_SQL_MES - 2;

            /*" -1011- IF WMES < 1 */

            if (AREA_DE_WORK.WMES < 1)
            {

                /*" -1012- ADD 12 TO WMES */
                AREA_DE_WORK.WMES.Value = AREA_DE_WORK.WMES + 12;

                /*" -1013- SUBTRACT 1 FROM WDATA-SQL-ANO */
                AREA_DE_WORK.FILLER_3.WDATA_SQL_ANO.Value = AREA_DE_WORK.FILLER_3.WDATA_SQL_ANO - 1;

                /*" -1015- END-IF. */
            }


            /*" -1016- MOVE WMES TO WDATA-SQL-MES. */
            _.Move(AREA_DE_WORK.WMES, AREA_DE_WORK.FILLER_3.WDATA_SQL_MES);

            /*" -1016- MOVE 01 TO WDATA-SQL-DIA. */
            _.Move(01, AREA_DE_WORK.FILLER_3.WDATA_SQL_DIA);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/

        [StopWatch]
        /*" R1200-00-SELECT-V0APOLICE-SECTION */
        private void R1200_00_SELECT_V0APOLICE_SECTION()
        {
            /*" -1029- MOVE '120' TO WNR-EXEC-SQL. */
            _.Move("120", WABEND.WNR_EXEC_SQL);

            /*" -1040- PERFORM R1200_00_SELECT_V0APOLICE_DB_SELECT_1 */

            R1200_00_SELECT_V0APOLICE_DB_SELECT_1();

            /*" -1043- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1044- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1045- PERFORM R1300-00-SELECT-SX010 */

                    R1300_00_SELECT_SX010_SECTION();

                    /*" -1046- ELSE */
                }
                else
                {


                    /*" -1047- DISPLAY 'R1200 - ERRO NO SELECT DA V0APOLICE' */
                    _.Display($"R1200 - ERRO NO SELECT DA V0APOLICE");

                    /*" -1048- DISPLAY 'SINISTRO - ' V1MSIN-NUM-SINI */
                    _.Display($"SINISTRO - {V1MSIN_NUM_SINI}");

                    /*" -1049- DISPLAY 'APOLICE  - ' V1MSIN-NUM-APOL */
                    _.Display($"APOLICE  - {V1MSIN_NUM_APOL}");

                    /*" -1050- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1051- END-IF */
                }


                /*" -1051- END-IF. */
            }


        }

        [StopWatch]
        /*" R1200-00-SELECT-V0APOLICE-DB-SELECT-1 */
        public void R1200_00_SELECT_V0APOLICE_DB_SELECT_1()
        {
            /*" -1040- EXEC SQL SELECT NUM_APOLICE, TIPSGU, ORGAO, RAMO INTO :V0APOL-NUM-APOL, :V0APOL-TIPSGU, :V0APOL-ORGAO, :V0APOL-RAMO FROM SEGUROS.V0APOLICE WHERE NUM_APOLICE = :V1MSIN-NUM-APOL END-EXEC. */

            var r1200_00_SELECT_V0APOLICE_DB_SELECT_1_Query1 = new R1200_00_SELECT_V0APOLICE_DB_SELECT_1_Query1()
            {
                V1MSIN_NUM_APOL = V1MSIN_NUM_APOL.ToString(),
            };

            var executed_1 = R1200_00_SELECT_V0APOLICE_DB_SELECT_1_Query1.Execute(r1200_00_SELECT_V0APOLICE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0APOL_NUM_APOL, V0APOL_NUM_APOL);
                _.Move(executed_1.V0APOL_TIPSGU, V0APOL_TIPSGU);
                _.Move(executed_1.V0APOL_ORGAO, V0APOL_ORGAO);
                _.Move(executed_1.V0APOL_RAMO, V0APOL_RAMO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/

        [StopWatch]
        /*" R1300-00-SELECT-SX010-SECTION */
        private void R1300_00_SELECT_SX010_SECTION()
        {
            /*" -1064- MOVE '1300' TO WNR-EXEC-SQL. */
            _.Move("1300", WABEND.WNR_EXEC_SQL);

            /*" -1085- PERFORM R1300_00_SELECT_SX010_DB_SELECT_1 */

            R1300_00_SELECT_SX010_DB_SELECT_1();

            /*" -1088- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1089- DISPLAY 'R1300 - ERRO NO SELECT DA SX_APOLICE' */
                _.Display($"R1300 - ERRO NO SELECT DA SX_APOLICE");

                /*" -1090- DISPLAY 'SINISTRO - ' V1MSIN-NUM-SINI */
                _.Display($"SINISTRO - {V1MSIN_NUM_SINI}");

                /*" -1091- DISPLAY 'APOLICE  - ' V1MSIN-NUM-APOL */
                _.Display($"APOLICE  - {V1MSIN_NUM_APOL}");

                /*" -1092- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1093- ELSE */
            }
            else
            {


                /*" -1094- MOVE SX010-NUM-APOLICE TO V0APOL-NUM-APOL */
                _.Move(SX010.DCLSX_APOLICE.SX010_NUM_APOLICE, V0APOL_NUM_APOL);

                /*" -1095- MOVE SX017-NUM-RAMO TO V0APOL-RAMO */
                _.Move(SX017.DCLSX_PRODUTO.SX017_NUM_RAMO, V0APOL_RAMO);

                /*" -1096- MOVE 010 TO V0APOL-ORGAO */
                _.Move(010, V0APOL_ORGAO);

                /*" -1097- MOVE '1' TO V0APOL-TIPSGU */
                _.Move("1", V0APOL_TIPSGU);

                /*" -1097- END-IF. */
            }


        }

        [StopWatch]
        /*" R1300-00-SELECT-SX010-DB-SELECT-1 */
        public void R1300_00_SELECT_SX010_DB_SELECT_1()
        {
            /*" -1085- EXEC SQL SELECT DISTINCT VALUE (A.NUM_APOLICE,+0), A.DTA_APOLICE, A.COD_FONTE, C.NUM_RAMO, C.COD_PRODUTO INTO :SX010-NUM-APOLICE, :SX010-DTA-APOLICE, :SX010-COD-FONTE, :SX017-NUM-RAMO, :SX017-COD-PRODUTO FROM SEGUROS.SX_APOLICE A, SEGUROS.SX_ORIGEM_CONTRATO B, SEGUROS.SX_PRODUTO C WHERE A.NUM_APOLICE = :V1MSIN-NUM-APOL AND A.STA_APOLICE = 'A' AND B.SEQ_APOLICE = A.SEQ_PROP_APOL AND B.STA_ORIGEM_CONTRATO = 'A' AND C.COD_PRODUTO = B.COD_PRODUTO WITH UR END-EXEC. */

            var r1300_00_SELECT_SX010_DB_SELECT_1_Query1 = new R1300_00_SELECT_SX010_DB_SELECT_1_Query1()
            {
                V1MSIN_NUM_APOL = V1MSIN_NUM_APOL.ToString(),
            };

            var executed_1 = R1300_00_SELECT_SX010_DB_SELECT_1_Query1.Execute(r1300_00_SELECT_SX010_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SX010_NUM_APOLICE, SX010.DCLSX_APOLICE.SX010_NUM_APOLICE);
                _.Move(executed_1.SX010_DTA_APOLICE, SX010.DCLSX_APOLICE.SX010_DTA_APOLICE);
                _.Move(executed_1.SX010_COD_FONTE, SX010.DCLSX_APOLICE.SX010_COD_FONTE);
                _.Move(executed_1.SX017_NUM_RAMO, SX017.DCLSX_PRODUTO.SX017_NUM_RAMO);
                _.Move(executed_1.SX017_COD_PRODUTO, SX017.DCLSX_PRODUTO.SX017_COD_PRODUTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1300_99_SAIDA*/

        [StopWatch]
        /*" R1400-00-DECLARE-V1APOLCOSCED-SECTION */
        private void R1400_00_DECLARE_V1APOLCOSCED_SECTION()
        {
            /*" -1110- MOVE '140' TO WNR-EXEC-SQL. */
            _.Move("140", WABEND.WNR_EXEC_SQL);

            /*" -1121- PERFORM R1400_00_DECLARE_V1APOLCOSCED_DB_DECLARE_1 */

            R1400_00_DECLARE_V1APOLCOSCED_DB_DECLARE_1();

            /*" -1123- PERFORM R1400_00_DECLARE_V1APOLCOSCED_DB_OPEN_1 */

            R1400_00_DECLARE_V1APOLCOSCED_DB_OPEN_1();

            /*" -1126- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1127- DISPLAY 'R1400 - ERRO NO DECLARE DA V1APOLCOSCED' */
                _.Display($"R1400 - ERRO NO DECLARE DA V1APOLCOSCED");

                /*" -1128- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1129- ELSE */
            }
            else
            {


                /*" -1130- MOVE SPACES TO WFIM-V1APOLCOSCED */
                _.Move("", AREA_DE_WORK.WFIM_V1APOLCOSCED);

                /*" -1130- END-IF. */
            }


        }

        [StopWatch]
        /*" R1400-00-DECLARE-V1APOLCOSCED-DB-OPEN-1 */
        public void R1400_00_DECLARE_V1APOLCOSCED_DB_OPEN_1()
        {
            /*" -1123- EXEC SQL OPEN V1APOLCOSCED END-EXEC. */

            V1APOLCOSCED.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1400_99_SAIDA*/

        [StopWatch]
        /*" R1450-00-FETCH-V1APOLCOSCED-SECTION */
        private void R1450_00_FETCH_V1APOLCOSCED_SECTION()
        {
            /*" -1141- MOVE '145' TO WNR-EXEC-SQL. */
            _.Move("145", WABEND.WNR_EXEC_SQL);

            /*" -0- FLUXCONTROL_PERFORM R1450_10_LER_V1APOLCOSCED */

            R1450_10_LER_V1APOLCOSCED();

        }

        [StopWatch]
        /*" R1450-10-LER-V1APOLCOSCED */
        private void R1450_10_LER_V1APOLCOSCED(bool isPerform = false)
        {
            /*" -1149- PERFORM R1450_10_LER_V1APOLCOSCED_DB_FETCH_1 */

            R1450_10_LER_V1APOLCOSCED_DB_FETCH_1();

            /*" -1152- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1153- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1154- MOVE 'S' TO WFIM-V1APOLCOSCED */
                    _.Move("S", AREA_DE_WORK.WFIM_V1APOLCOSCED);

                    /*" -1154- PERFORM R1450_10_LER_V1APOLCOSCED_DB_CLOSE_1 */

                    R1450_10_LER_V1APOLCOSCED_DB_CLOSE_1();

                    /*" -1156- GO TO R1450-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1450_99_SAIDA*/ //GOTO
                    return;

                    /*" -1157- ELSE */
                }
                else
                {


                    /*" -1158- DISPLAY 'R1450 - ERRO NO FETCH DA V1APOLCOSCED' */
                    _.Display($"R1450 - ERRO NO FETCH DA V1APOLCOSCED");

                    /*" -1159- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1165- END-IF */
                }


                /*" -1167- END-IF. */
            }


            /*" -1168- IF V1APCD-PCPARTIC = ZEROS */

            if (V1APCD_PCPARTIC == 00)
            {

                /*" -1178- IF (V1MSIN-NUM-APOL = 108208874329 OR 108210933403 OR V1MSIN-NUM-APOL = 109300000959 OR 109300001670 OR V1MSIN-NUM-APOL = 109300001819 OR 109300002142 OR V1MSIN-NUM-APOL = 109300002585 OR 109300002606 OR V1MSIN-NUM-APOL = 108211323063 OR 108211323064) OR (V1MSIN-NUM-APOL = 3008208874329 OR 3008210933403 OR V1MSIN-NUM-APOL = 3009300000959 OR 3009300001670 OR V1MSIN-NUM-APOL = 3009300001819 OR 3009300002142 OR V1MSIN-NUM-APOL = 3009300002585 OR 3009300002606 OR V1MSIN-NUM-APOL = 3008211323063 OR 3008211323064) */

                if ((V1MSIN_NUM_APOL.In("108208874329", "108210933403") || V1MSIN_NUM_APOL.In("109300000959", "109300001670") || V1MSIN_NUM_APOL.In("109300001819", "109300002142") || V1MSIN_NUM_APOL.In("109300002585", "109300002606") || V1MSIN_NUM_APOL.In("108211323063", "108211323064")) || (V1MSIN_NUM_APOL.In("3008208874329", "3008210933403") || V1MSIN_NUM_APOL.In("3009300000959", "3009300001670") || V1MSIN_NUM_APOL.In("3009300001819", "3009300002142") || V1MSIN_NUM_APOL.In("3009300002585", "3009300002606") || V1MSIN_NUM_APOL.In("3008211323063", "3008211323064")))
                {

                    /*" -1181- IF V1APCD-CODCOSS = 5193 AND V1MSIN-RAMO = 90 AND V1MSIN-CODCAU = 01 */

                    if (V1APCD_CODCOSS == 5193 && V1MSIN_RAMO == 90 && V1MSIN_CODCAU == 01)
                    {

                        /*" -1182- IF V1MSIN-DATORR < '2014-06-06' */

                        if (V1MSIN_DATORR < "2014-06-06")
                        {

                            /*" -1183- MOVE 100,00 TO V1APCD-PCPARTIC */
                            _.Move(100.00, V1APCD_PCPARTIC);

                            /*" -1184- ELSE */
                        }
                        else
                        {


                            /*" -1186- IF (V1MSIN-DATORR > '2016-10-31' AND V1MSIN-DATORR < '2017-01-05' ) */

                            if ((V1MSIN_DATORR > "2016-10-31" && V1MSIN_DATORR < "2017-01-05"))
                            {

                                /*" -1187- GO TO R1450-10-LER-V1APOLCOSCED */
                                new Task(() => R1450_10_LER_V1APOLCOSCED()).RunSynchronously(); //GOTO
                                return;//Recursividade detectada, cuidado...

                                /*" -1188- ELSE */
                            }
                            else
                            {


                                /*" -1189- MOVE 95,00 TO V1APCD-PCPARTIC */
                                _.Move(95.00, V1APCD_PCPARTIC);

                                /*" -1190- END-IF */
                            }


                            /*" -1191- END-IF */
                        }


                        /*" -1192- ELSE */
                    }
                    else
                    {


                        /*" -1193- GO TO R1450-10-LER-V1APOLCOSCED */
                        new Task(() => R1450_10_LER_V1APOLCOSCED()).RunSynchronously(); //GOTO
                        return;//Recursividade detectada, cuidado...

                        /*" -1194- END-IF */
                    }


                    /*" -1195- ELSE */
                }
                else
                {


                    /*" -1197- IF (V1MSIN-NUM-APOL = 109300002675 OR V1MSIN-NUM-APOL = 3009300002675) */

                    if ((V1MSIN_NUM_APOL == 109300002675 || V1MSIN_NUM_APOL == 3009300002675))
                    {

                        /*" -1200- IF V1APCD-CODCOSS = 5193 AND V1MSIN-RAMO = 90 AND V1MSIN-CODCAU = 01 */

                        if (V1APCD_CODCOSS == 5193 && V1MSIN_RAMO == 90 && V1MSIN_CODCAU == 01)
                        {

                            /*" -1202- IF (V1MSIN-DATORR > '2016-05-31' AND V1MSIN-DATORR < '2017-01-05' ) */

                            if ((V1MSIN_DATORR > "2016-05-31" && V1MSIN_DATORR < "2017-01-05"))
                            {

                                /*" -1203- GO TO R1450-10-LER-V1APOLCOSCED */
                                new Task(() => R1450_10_LER_V1APOLCOSCED()).RunSynchronously(); //GOTO
                                return;//Recursividade detectada, cuidado...

                                /*" -1204- ELSE */
                            }
                            else
                            {


                                /*" -1205- MOVE 95,00 TO V1APCD-PCPARTIC */
                                _.Move(95.00, V1APCD_PCPARTIC);

                                /*" -1206- END-IF */
                            }


                            /*" -1207- ELSE */
                        }
                        else
                        {


                            /*" -1208- GO TO R1450-10-LER-V1APOLCOSCED */
                            new Task(() => R1450_10_LER_V1APOLCOSCED()).RunSynchronously(); //GOTO
                            return;//Recursividade detectada, cuidado...

                            /*" -1209- END-IF */
                        }


                        /*" -1210- ELSE */
                    }
                    else
                    {


                        /*" -1212- IF (V1MSIN-NUM-APOL = 109300002676 OR V1MSIN-NUM-APOL = 3009300002676) */

                        if ((V1MSIN_NUM_APOL == 109300002676 || V1MSIN_NUM_APOL == 3009300002676))
                        {

                            /*" -1215- IF V1APCD-CODCOSS = 5193 AND V1MSIN-RAMO = 90 AND V1MSIN-CODCAU = 01 */

                            if (V1APCD_CODCOSS == 5193 && V1MSIN_RAMO == 90 && V1MSIN_CODCAU == 01)
                            {

                                /*" -1216- IF V1MSIN-DATORR < '2017-05-01' */

                                if (V1MSIN_DATORR < "2017-05-01")
                                {

                                    /*" -1217- GO TO R1450-10-LER-V1APOLCOSCED */
                                    new Task(() => R1450_10_LER_V1APOLCOSCED()).RunSynchronously(); //GOTO
                                    return;//Recursividade detectada, cuidado...

                                    /*" -1218- ELSE */
                                }
                                else
                                {


                                    /*" -1219- MOVE 95,00 TO V1APCD-PCPARTIC */
                                    _.Move(95.00, V1APCD_PCPARTIC);

                                    /*" -1220- END-IF */
                                }


                                /*" -1221- ELSE */
                            }
                            else
                            {


                                /*" -1222- GO TO R1450-10-LER-V1APOLCOSCED */
                                new Task(() => R1450_10_LER_V1APOLCOSCED()).RunSynchronously(); //GOTO
                                return;//Recursividade detectada, cuidado...

                                /*" -1223- END-IF */
                            }


                            /*" -1224- ELSE */
                        }
                        else
                        {


                            /*" -1226- IF (V1MSIN-NUM-APOL = 109300003432 OR V1MSIN-NUM-APOL = 3009300003432) */

                            if ((V1MSIN_NUM_APOL == 109300003432 || V1MSIN_NUM_APOL == 3009300003432))
                            {

                                /*" -1229- IF V1APCD-CODCOSS = 5193 AND V1MSIN-RAMO = 90 AND V1MSIN-CODCAU = 01 */

                                if (V1APCD_CODCOSS == 5193 && V1MSIN_RAMO == 90 && V1MSIN_CODCAU == 01)
                                {

                                    /*" -1233- IF (V1MSIN-DATORR > '2015-08-31' AND V1MSIN-DATORR < '2017-01-05' ) OR (V1MSIN-DATORR > '2017-08-31' AND V1MSIN-DATORR < '2017-11-06' ) */

                                    if ((V1MSIN_DATORR > "2015-08-31" && V1MSIN_DATORR < "2017-01-05") || (V1MSIN_DATORR > "2017-08-31" && V1MSIN_DATORR < "2017-11-06"))
                                    {

                                        /*" -1234- GO TO R1450-10-LER-V1APOLCOSCED */
                                        new Task(() => R1450_10_LER_V1APOLCOSCED()).RunSynchronously(); //GOTO
                                        return;//Recursividade detectada, cuidado...

                                        /*" -1235- ELSE */
                                    }
                                    else
                                    {


                                        /*" -1236- MOVE 95,00 TO V1APCD-PCPARTIC */
                                        _.Move(95.00, V1APCD_PCPARTIC);

                                        /*" -1237- END-IF */
                                    }


                                    /*" -1238- ELSE */
                                }
                                else
                                {


                                    /*" -1239- GO TO R1450-10-LER-V1APOLCOSCED */
                                    new Task(() => R1450_10_LER_V1APOLCOSCED()).RunSynchronously(); //GOTO
                                    return;//Recursividade detectada, cuidado...

                                    /*" -1240- END-IF */
                                }


                                /*" -1241- ELSE */
                            }
                            else
                            {


                                /*" -1250- IF (V1MSIN-NUM-APOL = 109300002677 OR V1MSIN-NUM-APOL = 109300002678 OR V1MSIN-NUM-APOL = 109300004543 OR V1MSIN-NUM-APOL = 109300004544 OR V1MSIN-NUM-APOL = 109300005270) OR (V1MSIN-NUM-APOL = 3009300002677 OR V1MSIN-NUM-APOL = 3009300002678 OR V1MSIN-NUM-APOL = 3009300004544 OR V1MSIN-NUM-APOL = 3009300005270) */

                                if ((V1MSIN_NUM_APOL == 109300002677 || V1MSIN_NUM_APOL == 109300002678 || V1MSIN_NUM_APOL == 109300004543 || V1MSIN_NUM_APOL == 109300004544 || V1MSIN_NUM_APOL == 109300005270) || (V1MSIN_NUM_APOL == 3009300002677 || V1MSIN_NUM_APOL == 3009300002678 || V1MSIN_NUM_APOL == 3009300004544 || V1MSIN_NUM_APOL == 3009300005270))
                                {

                                    /*" -1253- IF V1APCD-CODCOSS = 5193 AND V1MSIN-RAMO = 90 AND V1MSIN-CODCAU = 01 */

                                    if (V1APCD_CODCOSS == 5193 && V1MSIN_RAMO == 90 && V1MSIN_CODCAU == 01)
                                    {

                                        /*" -1254- MOVE 95,00 TO V1APCD-PCPARTIC */
                                        _.Move(95.00, V1APCD_PCPARTIC);

                                        /*" -1255- ELSE */
                                    }
                                    else
                                    {


                                        /*" -1256- GO TO R1450-10-LER-V1APOLCOSCED */
                                        new Task(() => R1450_10_LER_V1APOLCOSCED()).RunSynchronously(); //GOTO
                                        return;//Recursividade detectada, cuidado...

                                        /*" -1257- END-IF */
                                    }


                                    /*" -1258- ELSE */
                                }
                                else
                                {


                                    /*" -1259- GO TO R1450-10-LER-V1APOLCOSCED */
                                    new Task(() => R1450_10_LER_V1APOLCOSCED()).RunSynchronously(); //GOTO
                                    return;//Recursividade detectada, cuidado...

                                    /*" -1260- END-IF */
                                }


                                /*" -1261- END-IF */
                            }


                            /*" -1262- END-IF */
                        }


                        /*" -1263- END-IF */
                    }


                    /*" -1264- END-IF */
                }


                /*" -1265- ELSE */
            }
            else
            {


                /*" -1269- IF V1MSIN-NUM-APOL = 109700000025 AND V1APCD-CODCOSS = 5142 AND V1MSIN-RAMO = 81 AND V1MSIN-CODCAU = 15 */

                if (V1MSIN_NUM_APOL == 109700000025 && V1APCD_CODCOSS == 5142 && V1MSIN_RAMO == 81 && V1MSIN_CODCAU == 15)
                {

                    /*" -1275- MOVE 100,00 TO V1APCD-PCPARTIC */
                    _.Move(100.00, V1APCD_PCPARTIC);

                    /*" -1276- END-IF */
                }


                /*" -1276- END-IF. */
            }


        }

        [StopWatch]
        /*" R1450-10-LER-V1APOLCOSCED-DB-FETCH-1 */
        public void R1450_10_LER_V1APOLCOSCED_DB_FETCH_1()
        {
            /*" -1149- EXEC SQL FETCH V1APOLCOSCED INTO :V1APCD-CODCOSS , :V1APCD-PCPARTIC , :V1APCD-PCCOMCOS END-EXEC. */

            if (V1APOLCOSCED.Fetch())
            {
                _.Move(V1APOLCOSCED.V1APCD_CODCOSS, V1APCD_CODCOSS);
                _.Move(V1APOLCOSCED.V1APCD_PCPARTIC, V1APCD_PCPARTIC);
                _.Move(V1APOLCOSCED.V1APCD_PCCOMCOS, V1APCD_PCCOMCOS);
            }

        }

        [StopWatch]
        /*" R1450-10-LER-V1APOLCOSCED-DB-CLOSE-1 */
        public void R1450_10_LER_V1APOLCOSCED_DB_CLOSE_1()
        {
            /*" -1154- EXEC SQL CLOSE V1APOLCOSCED END-EXEC */

            V1APOLCOSCED.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1450_99_SAIDA*/

        [StopWatch]
        /*" R1500-00-SELECT-V0COTACAO-SECTION */
        private void R1500_00_SELECT_V0COTACAO_SECTION()
        {
            /*" -1289- MOVE '150' TO WNR-EXEC-SQL. */
            _.Move("150", WABEND.WNR_EXEC_SQL);

            /*" -1296- PERFORM R1500_00_SELECT_V0COTACAO_DB_SELECT_1 */

            R1500_00_SELECT_V0COTACAO_DB_SELECT_1();

            /*" -1299- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1300- DISPLAY 'R1500 - ERRO NO SELECT DA V0COTACAO' */
                _.Display($"R1500 - ERRO NO SELECT DA V0COTACAO");

                /*" -1301- DISPLAY 'SINISTRO - ' V1MSIN-NUM-SINI */
                _.Display($"SINISTRO - {V1MSIN_NUM_SINI}");

                /*" -1302- DISPLAY 'MOEDA    - ' V1MSIN-COD-MOEDA */
                _.Display($"MOEDA    - {V1MSIN_COD_MOEDA}");

                /*" -1303- DISPLAY 'OC. HIST - ' V1HSIN-OCORHIST */
                _.Display($"OC. HIST - {V1HSIN_OCORHIST}");

                /*" -1304- DISPLAY 'OPERACAO - ' V1HSIN-OPERACAO */
                _.Display($"OPERACAO - {V1HSIN_OPERACAO}");

                /*" -1305- DISPLAY 'DT MOVTO - ' V1HSIN-DTMOVTO */
                _.Display($"DT MOVTO - {V1HSIN_DTMOVTO}");

                /*" -1306- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1306- END-IF. */
            }


        }

        [StopWatch]
        /*" R1500-00-SELECT-V0COTACAO-DB-SELECT-1 */
        public void R1500_00_SELECT_V0COTACAO_DB_SELECT_1()
        {
            /*" -1296- EXEC SQL SELECT VAL_VENDA INTO :V0COTA-VL-VENDA FROM SEGUROS.V0COTACAO WHERE CODUNIMO = :V1MSIN-COD-MOEDA AND DTINIVIG <= :V1HSIN-DTMOVTO AND DTTERVIG >= :V1HSIN-DTMOVTO END-EXEC. */

            var r1500_00_SELECT_V0COTACAO_DB_SELECT_1_Query1 = new R1500_00_SELECT_V0COTACAO_DB_SELECT_1_Query1()
            {
                V1MSIN_COD_MOEDA = V1MSIN_COD_MOEDA.ToString(),
                V1HSIN_DTMOVTO = V1HSIN_DTMOVTO.ToString(),
            };

            var executed_1 = R1500_00_SELECT_V0COTACAO_DB_SELECT_1_Query1.Execute(r1500_00_SELECT_V0COTACAO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0COTA_VL_VENDA, V0COTA_VL_VENDA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1500_99_SAIDA*/

        [StopWatch]
        /*" R1600-00-GRAVA-REGISTRO-SECTION */
        private void R1600_00_GRAVA_REGISTRO_SECTION()
        {
            /*" -1319- MOVE '160' TO WNR-EXEC-SQL. */
            _.Move("160", WABEND.WNR_EXEC_SQL);

            /*" -1335- MOVE ZEROS TO WHOST-VAL-OPER W0MSIN-VAL-OPER W0HSIN-VAL-OPER. */
            _.Move(0, WHOST_VAL_OPER, AREA_DE_WORK.W0MSIN_VAL_OPER, AREA_DE_WORK.W0HSIN_VAL_OPER);

            /*" -1337- PERFORM R1800-00-CALCULA-VALORES. */

            R1800_00_CALCULA_VALORES_SECTION();

            /*" -1338- IF V1HSIN-OPERACAO = 0101 */

            if (V1HSIN_OPERACAO == 0101)
            {

                /*" -1339- PERFORM R2100-00-MONTA-V0COSSEG-SINI */

                R2100_00_MONTA_V0COSSEG_SINI_SECTION();

                /*" -1340- PERFORM R2200-00-INSERT-V0COSSEG-SINI */

                R2200_00_INSERT_V0COSSEG_SINI_SECTION();

                /*" -1341- PERFORM R2300-00-MONTA-V0COSSEG-HSIN */

                R2300_00_MONTA_V0COSSEG_HSIN_SECTION();

                /*" -1342- PERFORM R2400-00-INSERT-V0COSSEG-HSIN */

                R2400_00_INSERT_V0COSSEG_HSIN_SECTION();

                /*" -1343- ELSE */
            }
            else
            {


                /*" -1346- IF V1HSIN-OPERACAO = 0104 OR 0114 OR 0107 OR 0117 OR 0108 OR 0118 */

                if (V1HSIN_OPERACAO.In("0104", "0114", "0107", "0117", "0108", "0118"))
                {

                    /*" -1347- PERFORM R1900-00-VERIFICA-SITUACAO */

                    R1900_00_VERIFICA_SITUACAO_SECTION();

                    /*" -1348- IF WTEM-V1COSSEGSINI = 'S' */

                    if (AREA_DE_WORK.WTEM_V1COSSEGSINI == "S")
                    {

                        /*" -1349- PERFORM R3100-00-UPDATE-V0COSSEG-SINI */

                        R3100_00_UPDATE_V0COSSEG_SINI_SECTION();

                        /*" -1350- PERFORM R2300-00-MONTA-V0COSSEG-HSIN */

                        R2300_00_MONTA_V0COSSEG_HSIN_SECTION();

                        /*" -1351- PERFORM R2400-00-INSERT-V0COSSEG-HSIN */

                        R2400_00_INSERT_V0COSSEG_HSIN_SECTION();

                        /*" -1352- ELSE */
                    }
                    else
                    {


                        /*" -1353- PERFORM R2300-00-MONTA-V0COSSEG-HSIN */

                        R2300_00_MONTA_V0COSSEG_HSIN_SECTION();

                        /*" -1354- PERFORM R2400-00-INSERT-V0COSSEG-HSIN */

                        R2400_00_INSERT_V0COSSEG_HSIN_SECTION();

                        /*" -1355- END-IF */
                    }


                    /*" -1356- ELSE */
                }
                else
                {


                    /*" -1357- PERFORM R2300-00-MONTA-V0COSSEG-HSIN */

                    R2300_00_MONTA_V0COSSEG_HSIN_SECTION();

                    /*" -1358- PERFORM R2400-00-INSERT-V0COSSEG-HSIN */

                    R2400_00_INSERT_V0COSSEG_HSIN_SECTION();

                    /*" -1359- END-IF */
                }


                /*" -1361- END-IF. */
            }


            /*" -1361- PERFORM R1450-00-FETCH-V1APOLCOSCED. */

            R1450_00_FETCH_V1APOLCOSCED_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1600_99_SAIDA*/

        [StopWatch]
        /*" R1700-00-SELECT-VALOR-PAGTO-SECTION */
        private void R1700_00_SELECT_VALOR_PAGTO_SECTION()
        {
            /*" -1374- MOVE '170' TO WNR-EXEC-SQL. */
            _.Move("170", WABEND.WNR_EXEC_SQL);

            /*" -1388- PERFORM R1700_00_SELECT_VALOR_PAGTO_DB_SELECT_1 */

            R1700_00_SELECT_VALOR_PAGTO_DB_SELECT_1();

            /*" -1391- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1392- DISPLAY 'R1700 - ERRO NO SELECT DA V1COSSEG-HISTSIN' */
                _.Display($"R1700 - ERRO NO SELECT DA V1COSSEG-HISTSIN");

                /*" -1393- DISPLAY 'CONGENER - ' V1APCD-CODCOSS */
                _.Display($"CONGENER - {V1APCD_CODCOSS}");

                /*" -1394- DISPLAY 'SINISTRO - ' V1MSIN-NUM-SINI */
                _.Display($"SINISTRO - {V1MSIN_NUM_SINI}");

                /*" -1395- DISPLAY 'OC. HIST - ' V1HSIN-OCORHIST */
                _.Display($"OC. HIST - {V1HSIN_OCORHIST}");

                /*" -1396- DISPLAY 'OPERACAO - ' V1HSIN-OPERACAO */
                _.Display($"OPERACAO - {V1HSIN_OPERACAO}");

                /*" -1397- DISPLAY 'DT MOVTO - ' V1HSIN-DTMOVTO */
                _.Display($"DT MOVTO - {V1HSIN_DTMOVTO}");

                /*" -1398- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1399- ELSE */
            }
            else
            {


                /*" -1400- MOVE WHOST-VAL-OPER TO W0HSIN-VAL-OPER */
                _.Move(WHOST_VAL_OPER, AREA_DE_WORK.W0HSIN_VAL_OPER);

                /*" -1400- END-IF. */
            }


        }

        [StopWatch]
        /*" R1700-00-SELECT-VALOR-PAGTO-DB-SELECT-1 */
        public void R1700_00_SELECT_VALOR_PAGTO_DB_SELECT_1()
        {
            /*" -1388- EXEC SQL SELECT A.VAL_OPERACAO INTO :WHOST-VAL-OPER FROM SEGUROS.V1COSSEG_HISTSIN A, SEGUROS.GE_SIS_FUNCAO_OPER B WHERE A.CONGENER = :V1APCD-CODCOSS AND A.NUM_SINISTRO = :V1MSIN-NUM-SINI AND A.OCORHIST = :V1HSIN-OCORHIST AND A.TIPSGU = :V0APOL-TIPSGU AND B.IDE_SISTEMA = :GESISFUO-IDE-SISTEMA AND B.COD_FUNCAO = :GESISFUO-COD-FUNCAO AND B.IDE_SISTEMA_OPER = :GESISFUO-IDE-SISTEMA-OPER AND B.COD_OPERACAO = A.OPERACAO AND B.NUM_FATOR = 1 END-EXEC. */

            var r1700_00_SELECT_VALOR_PAGTO_DB_SELECT_1_Query1 = new R1700_00_SELECT_VALOR_PAGTO_DB_SELECT_1_Query1()
            {
                GESISFUO_IDE_SISTEMA_OPER = GESISFUO.DCLGE_SIS_FUNCAO_OPER.GESISFUO_IDE_SISTEMA_OPER.ToString(),
                GESISFUO_IDE_SISTEMA = GESISFUO.DCLGE_SIS_FUNCAO_OPER.GESISFUO_IDE_SISTEMA.ToString(),
                GESISFUO_COD_FUNCAO = GESISFUO.DCLGE_SIS_FUNCAO_OPER.GESISFUO_COD_FUNCAO.ToString(),
                V1MSIN_NUM_SINI = V1MSIN_NUM_SINI.ToString(),
                V1HSIN_OCORHIST = V1HSIN_OCORHIST.ToString(),
                V1APCD_CODCOSS = V1APCD_CODCOSS.ToString(),
                V0APOL_TIPSGU = V0APOL_TIPSGU.ToString(),
            };

            var executed_1 = R1700_00_SELECT_VALOR_PAGTO_DB_SELECT_1_Query1.Execute(r1700_00_SELECT_VALOR_PAGTO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_VAL_OPER, WHOST_VAL_OPER);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1700_99_SAIDA*/

        [StopWatch]
        /*" R1800-00-CALCULA-VALORES-SECTION */
        private void R1800_00_CALCULA_VALORES_SECTION()
        {
            /*" -1413- MOVE '180' TO WNR-EXEC-SQL. */
            _.Move("180", WABEND.WNR_EXEC_SQL);

            /*" -1415- IF V1MSIN-RAMO = 68 AND V1MSIN-NUM-APOL = 6501000001 */

            if (V1MSIN_RAMO == 68 && V1MSIN_NUM_APOL == 6501000001)
            {

                /*" -1418- COMPUTE W0VLR-RESSEG ROUNDED = V1HSIN-VAL-OPER * V1MSIN-PCTRES / 100 */
                AREA_DE_WORK.W0VLR_RESSEG.Value = V1HSIN_VAL_OPER * V1MSIN_PCTRES / 100f;

                /*" -1419- ELSE */
            }
            else
            {


                /*" -1420- MOVE ZEROS TO W0VLR-RESSEG */
                _.Move(0, AREA_DE_WORK.W0VLR_RESSEG);

                /*" -1422- END-IF. */
            }


            /*" -1427- COMPUTE W0HSIN-VAL-OPER ROUNDED = (V1HSIN-VAL-OPER - W0VLR-RESSEG) * V1APCD-PCPARTIC / 100. */
            AREA_DE_WORK.W0HSIN_VAL_OPER.Value = (V1HSIN_VAL_OPER - AREA_DE_WORK.W0VLR_RESSEG) * V1APCD_PCPARTIC / 100f;

            /*" -1428- COMPUTE W0MSIN-VAL-OPER ROUNDED = W0HSIN-VAL-OPER / V0COTA-VL-VENDA. */
            AREA_DE_WORK.W0MSIN_VAL_OPER.Value = AREA_DE_WORK.W0HSIN_VAL_OPER / V0COTA_VL_VENDA;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1800_99_SAIDA*/

        [StopWatch]
        /*" R1900-00-VERIFICA-SITUACAO-SECTION */
        private void R1900_00_VERIFICA_SITUACAO_SECTION()
        {
            /*" -1441- MOVE '190' TO WNR-EXEC-SQL. */
            _.Move("190", WABEND.WNR_EXEC_SQL);

            /*" -1442- IF V1HSIN-OPERACAO EQUAL 0104 OR 0114 */

            if (V1HSIN_OPERACAO.In("0104", "0114"))
            {

                /*" -1443- MOVE '0' TO WHOST-SITUACAO */
                _.Move("0", WHOST_SITUACAO);

                /*" -1444- ELSE */
            }
            else
            {


                /*" -1446- IF V1HSIN-OPERACAO EQUAL 0107 OR 0117 OR 0108 OR 0118 */

                if (V1HSIN_OPERACAO.In("0107", "0117", "0108", "0118"))
                {

                    /*" -1447- MOVE '2' TO WHOST-SITUACAO */
                    _.Move("2", WHOST_SITUACAO);

                    /*" -1448- ELSE */
                }
                else
                {


                    /*" -1449- DISPLAY 'R1900 - OPERACAO NAO PREVISTA' */
                    _.Display($"R1900 - OPERACAO NAO PREVISTA");

                    /*" -1450- DISPLAY 'CONGENERE - ' V1APCD-CODCOSS */
                    _.Display($"CONGENERE - {V1APCD_CODCOSS}");

                    /*" -1451- DISPLAY 'SINISTRO  - ' V1MSIN-NUM-SINI */
                    _.Display($"SINISTRO  - {V1MSIN_NUM_SINI}");

                    /*" -1452- DISPLAY 'OCOR HIST - ' V1HSIN-OCORHIST */
                    _.Display($"OCOR HIST - {V1HSIN_OCORHIST}");

                    /*" -1453- DISPLAY 'OPERACAO  - ' V1HSIN-OPERACAO */
                    _.Display($"OPERACAO  - {V1HSIN_OPERACAO}");

                    /*" -1454- DISPLAY 'DT MOVTO  - ' V1HSIN-DTMOVTO */
                    _.Display($"DT MOVTO  - {V1HSIN_DTMOVTO}");

                    /*" -1455- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1456- END-IF */
                }


                /*" -1458- END-IF. */
            }


            /*" -1458- PERFORM R2000-00-SELECT-V1COSSEG-SINI. */

            R2000_00_SELECT_V1COSSEG_SINI_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1900_99_SAIDA*/

        [StopWatch]
        /*" R2000-00-SELECT-V1COSSEG-SINI-SECTION */
        private void R2000_00_SELECT_V1COSSEG_SINI_SECTION()
        {
            /*" -1471- MOVE '200' TO WNR-EXEC-SQL. */
            _.Move("200", WABEND.WNR_EXEC_SQL);

            /*" -1482- PERFORM R2000_00_SELECT_V1COSSEG_SINI_DB_SELECT_1 */

            R2000_00_SELECT_V1COSSEG_SINI_DB_SELECT_1();

            /*" -1485- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1486- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1487- MOVE 'N' TO WTEM-V1COSSEGSINI */
                    _.Move("N", AREA_DE_WORK.WTEM_V1COSSEGSINI);

                    /*" -1488- ELSE */
                }
                else
                {


                    /*" -1489- DISPLAY 'R2000 - ERRO NO SELECT V1COSSEG-SINI' */
                    _.Display($"R2000 - ERRO NO SELECT V1COSSEG-SINI");

                    /*" -1490- DISPLAY 'TIP SEGUR - ' V1CSIN-TIPSGU */
                    _.Display($"TIP SEGUR - {V1CSIN_TIPSGU}");

                    /*" -1491- DISPLAY 'CONGENERE - ' V1APCD-CODCOSS */
                    _.Display($"CONGENERE - {V1APCD_CODCOSS}");

                    /*" -1492- DISPLAY 'SINISTRO  - ' V1MSIN-NUM-SINI */
                    _.Display($"SINISTRO  - {V1MSIN_NUM_SINI}");

                    /*" -1493- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1494- END-IF */
                }


                /*" -1495- ELSE */
            }
            else
            {


                /*" -1496- MOVE 'S' TO WTEM-V1COSSEGSINI */
                _.Move("S", AREA_DE_WORK.WTEM_V1COSSEGSINI);

                /*" -1496- END-IF. */
            }


        }

        [StopWatch]
        /*" R2000-00-SELECT-V1COSSEG-SINI-DB-SELECT-1 */
        public void R2000_00_SELECT_V1COSSEG_SINI_DB_SELECT_1()
        {
            /*" -1482- EXEC SQL SELECT CONGENER, NUM_SINISTRO, TIPSGU INTO :V1CSIN-CONGENER, :V1CSIN-NUM-SINI, :V1CSIN-TIPSGU FROM SEGUROS.V1COSSEG_SINI WHERE CONGENER = :V1APCD-CODCOSS AND NUM_SINISTRO = :V1MSIN-NUM-SINI AND TIPSGU = :V0APOL-TIPSGU END-EXEC. */

            var r2000_00_SELECT_V1COSSEG_SINI_DB_SELECT_1_Query1 = new R2000_00_SELECT_V1COSSEG_SINI_DB_SELECT_1_Query1()
            {
                V1MSIN_NUM_SINI = V1MSIN_NUM_SINI.ToString(),
                V1APCD_CODCOSS = V1APCD_CODCOSS.ToString(),
                V0APOL_TIPSGU = V0APOL_TIPSGU.ToString(),
            };

            var executed_1 = R2000_00_SELECT_V1COSSEG_SINI_DB_SELECT_1_Query1.Execute(r2000_00_SELECT_V1COSSEG_SINI_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1CSIN_CONGENER, V1CSIN_CONGENER);
                _.Move(executed_1.V1CSIN_NUM_SINI, V1CSIN_NUM_SINI);
                _.Move(executed_1.V1CSIN_TIPSGU, V1CSIN_TIPSGU);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_99_SAIDA*/

        [StopWatch]
        /*" R2100-00-MONTA-V0COSSEG-SINI-SECTION */
        private void R2100_00_MONTA_V0COSSEG_SINI_SECTION()
        {
            /*" -1509- MOVE '210' TO WNR-EXEC-SQL. */
            _.Move("210", WABEND.WNR_EXEC_SQL);

            /*" -1510- MOVE ZEROS TO V0CSIN-COD-EMP. */
            _.Move(0, V0CSIN_COD_EMP);

            /*" -1511- MOVE '1' TO V0CSIN-TIPSGU. */
            _.Move("1", V0CSIN_TIPSGU);

            /*" -1512- MOVE V1APCD-CODCOSS TO V0CSIN-CONGENER. */
            _.Move(V1APCD_CODCOSS, V0CSIN_CONGENER);

            /*" -1513- MOVE V1MSIN-NUM-SINI TO V0CSIN-NUM-SINI. */
            _.Move(V1MSIN_NUM_SINI, V0CSIN_NUM_SINI);

            /*" -1514- MOVE W0MSIN-VAL-OPER TO V0CSIN-VAL-OPER. */
            _.Move(AREA_DE_WORK.W0MSIN_VAL_OPER, V0CSIN_VAL_OPER);

            /*" -1515- MOVE '0' TO V0CSIN-SITUACAO. */
            _.Move("0", V0CSIN_SITUACAO);

            /*" -1515- MOVE '0' TO V0CSIN-SIT-CONG. */
            _.Move("0", V0CSIN_SIT_CONG);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2100_99_SAIDA*/

        [StopWatch]
        /*" R2200-00-INSERT-V0COSSEG-SINI-SECTION */
        private void R2200_00_INSERT_V0COSSEG_SINI_SECTION()
        {
            /*" -1528- MOVE '220' TO WNR-EXEC-SQL. */
            _.Move("220", WABEND.WNR_EXEC_SQL);

            /*" -1538- PERFORM R2200_00_INSERT_V0COSSEG_SINI_DB_INSERT_1 */

            R2200_00_INSERT_V0COSSEG_SINI_DB_INSERT_1();

            /*" -1541- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1542- IF SQLCODE EQUAL -803 */

                if (DB.SQLCODE == -803)
                {

                    /*" -1543- DISPLAY 'R2200 - REGISTRO DUPLICADO NA V0COSSEG-SINI' */
                    _.Display($"R2200 - REGISTRO DUPLICADO NA V0COSSEG-SINI");

                    /*" -1544- DISPLAY 'TIP SEGUR - ' V0CSIN-TIPSGU */
                    _.Display($"TIP SEGUR - {V0CSIN_TIPSGU}");

                    /*" -1545- DISPLAY 'CONGENERE - ' V0CSIN-CONGENER */
                    _.Display($"CONGENERE - {V0CSIN_CONGENER}");

                    /*" -1546- DISPLAY 'SINISTRO  - ' V0CSIN-NUM-SINI */
                    _.Display($"SINISTRO  - {V0CSIN_NUM_SINI}");

                    /*" -1547- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1548- ELSE */
                }
                else
                {


                    /*" -1549- DISPLAY 'R2200 - ERRO NO INSERT DA V0COSSEG-SINI' */
                    _.Display($"R2200 - ERRO NO INSERT DA V0COSSEG-SINI");

                    /*" -1550- DISPLAY 'TIP SEGUR - ' V0CSIN-TIPSGU */
                    _.Display($"TIP SEGUR - {V0CSIN_TIPSGU}");

                    /*" -1551- DISPLAY 'CONGENERE - ' V0CSIN-CONGENER */
                    _.Display($"CONGENERE - {V0CSIN_CONGENER}");

                    /*" -1552- DISPLAY 'SINISTRO  - ' V0CSIN-NUM-SINI */
                    _.Display($"SINISTRO  - {V0CSIN_NUM_SINI}");

                    /*" -1553- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1554- END-IF */
                }


                /*" -1555- ELSE */
            }
            else
            {


                /*" -1556- ADD +1 TO AC-I-V0COSSEGSINI */
                AREA_DE_WORK.AC_I_V0COSSEGSINI.Value = AREA_DE_WORK.AC_I_V0COSSEGSINI + +1;

                /*" -1556- END-IF. */
            }


        }

        [StopWatch]
        /*" R2200-00-INSERT-V0COSSEG-SINI-DB-INSERT-1 */
        public void R2200_00_INSERT_V0COSSEG_SINI_DB_INSERT_1()
        {
            /*" -1538- EXEC SQL INSERT INTO SEGUROS.V0COSSEG_SINI VALUES (:V0CSIN-COD-EMP, :V0CSIN-TIPSGU, :V0CSIN-CONGENER, :V0CSIN-NUM-SINI, :V0CSIN-VAL-OPER, :V0CSIN-SITUACAO, :V0CSIN-SIT-CONG, CURRENT TIMESTAMP) END-EXEC. */

            var r2200_00_INSERT_V0COSSEG_SINI_DB_INSERT_1_Insert1 = new R2200_00_INSERT_V0COSSEG_SINI_DB_INSERT_1_Insert1()
            {
                V0CSIN_COD_EMP = V0CSIN_COD_EMP.ToString(),
                V0CSIN_TIPSGU = V0CSIN_TIPSGU.ToString(),
                V0CSIN_CONGENER = V0CSIN_CONGENER.ToString(),
                V0CSIN_NUM_SINI = V0CSIN_NUM_SINI.ToString(),
                V0CSIN_VAL_OPER = V0CSIN_VAL_OPER.ToString(),
                V0CSIN_SITUACAO = V0CSIN_SITUACAO.ToString(),
                V0CSIN_SIT_CONG = V0CSIN_SIT_CONG.ToString(),
            };

            R2200_00_INSERT_V0COSSEG_SINI_DB_INSERT_1_Insert1.Execute(r2200_00_INSERT_V0COSSEG_SINI_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2200_99_SAIDA*/

        [StopWatch]
        /*" R2300-00-MONTA-V0COSSEG-HSIN-SECTION */
        private void R2300_00_MONTA_V0COSSEG_HSIN_SECTION()
        {
            /*" -1569- MOVE '230' TO WNR-EXEC-SQL. */
            _.Move("230", WABEND.WNR_EXEC_SQL);

            /*" -1570- MOVE ZEROS TO V0CHSI-COD-EMP. */
            _.Move(0, V0CHSI_COD_EMP);

            /*" -1571- MOVE V1APCD-CODCOSS TO V0CHSI-CONGENER. */
            _.Move(V1APCD_CODCOSS, V0CHSI_CONGENER);

            /*" -1572- MOVE V1MSIN-NUM-SINI TO V0CHSI-NUM-SINI. */
            _.Move(V1MSIN_NUM_SINI, V0CHSI_NUM_SINI);

            /*" -1573- MOVE V1HSIN-OCORHIST TO V0CHSI-OCORHIST. */
            _.Move(V1HSIN_OCORHIST, V0CHSI_OCORHIST);

            /*" -1574- MOVE V1HSIN-OPERACAO TO V0CHSI-OPERACAO. */
            _.Move(V1HSIN_OPERACAO, V0CHSI_OPERACAO);

            /*" -1575- MOVE V1HSIN-DTMOVTO TO V0CHSI-DTMOVTO. */
            _.Move(V1HSIN_DTMOVTO, V0CHSI_DTMOVTO);

            /*" -1577- MOVE W0HSIN-VAL-OPER TO V0CHSI-VAL-OPER. */
            _.Move(AREA_DE_WORK.W0HSIN_VAL_OPER, V0CHSI_VAL_OPER);

            /*" -1578- MOVE '0' TO V0CHSI-SITUACAO. */
            _.Move("0", V0CHSI_SITUACAO);

            /*" -1580- MOVE +1 TO VIND-SIT-REGT. */
            _.Move(+1, VIND_SIT_REGT);

            /*" -1581- MOVE '1' TO V0CHSI-TIPSGU. */
            _.Move("1", V0CHSI_TIPSGU);

            /*" -1583- MOVE +1 TO VIND-TIP-SEGR. */
            _.Move(+1, VIND_TIP_SEGR);

            /*" -1584- MOVE '0' TO V0CHSI-SIT-LIBRECUP. */
            _.Move("0", V0CHSI_SIT_LIBRECUP);

            /*" -1584- MOVE +1 TO VIND-SIT-LIBR. */
            _.Move(+1, VIND_SIT_LIBR);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2300_99_SAIDA*/

        [StopWatch]
        /*" R2400-00-INSERT-V0COSSEG-HSIN-SECTION */
        private void R2400_00_INSERT_V0COSSEG_HSIN_SECTION()
        {
            /*" -1595- MOVE '240' TO WNR-EXEC-SQL. */
            _.Move("240", WABEND.WNR_EXEC_SQL);

            /*" -0- FLUXCONTROL_PERFORM R2400_10_INSERE_V0COSSEG_HSIN */

            R2400_10_INSERE_V0COSSEG_HSIN();

        }

        [StopWatch]
        /*" R2400-10-INSERE-V0COSSEG-HSIN */
        private void R2400_10_INSERE_V0COSSEG_HSIN(bool isPerform = false)
        {
            /*" -1612- PERFORM R2400_10_INSERE_V0COSSEG_HSIN_DB_INSERT_1 */

            R2400_10_INSERE_V0COSSEG_HSIN_DB_INSERT_1();

            /*" -1615- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1616- DISPLAY 'R2400 - ERRO NO INSERT DA V0COSSEG-HS' */
                _.Display($"R2400 - ERRO NO INSERT DA V0COSSEG-HS");

                /*" -1617- DISPLAY 'TIP SEGUR - ' V0CHSI-TIPSGU */
                _.Display($"TIP SEGUR - {V0CHSI_TIPSGU}");

                /*" -1618- DISPLAY 'CONGENERE - ' V0CHSI-CONGENER */
                _.Display($"CONGENERE - {V0CHSI_CONGENER}");

                /*" -1619- DISPLAY 'SINISTRO  - ' V0CHSI-NUM-SINI */
                _.Display($"SINISTRO  - {V0CHSI_NUM_SINI}");

                /*" -1620- DISPLAY 'DAT MOVTO - ' V0CHSI-DTMOVTO */
                _.Display($"DAT MOVTO - {V0CHSI_DTMOVTO}");

                /*" -1621- DISPLAY 'OCOR HIST - ' V0CHSI-OCORHIST */
                _.Display($"OCOR HIST - {V0CHSI_OCORHIST}");

                /*" -1622- DISPLAY 'OPERACAO  - ' V0CHSI-OPERACAO */
                _.Display($"OPERACAO  - {V0CHSI_OPERACAO}");

                /*" -1623- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1624- ELSE */
            }
            else
            {


                /*" -1625- ADD +1 TO AC-I-V0COSSEGHSIN */
                AREA_DE_WORK.AC_I_V0COSSEGHSIN.Value = AREA_DE_WORK.AC_I_V0COSSEGHSIN + +1;

                /*" -1625- END-IF. */
            }


        }

        [StopWatch]
        /*" R2400-10-INSERE-V0COSSEG-HSIN-DB-INSERT-1 */
        public void R2400_10_INSERE_V0COSSEG_HSIN_DB_INSERT_1()
        {
            /*" -1612- EXEC SQL INSERT INTO SEGUROS.V0COSSEG_HISTSIN VALUES (:V0CHSI-COD-EMP, :V0CHSI-CONGENER, :V0CHSI-NUM-SINI, :V0CHSI-OCORHIST, :V0CHSI-OPERACAO, :V0CHSI-DTMOVTO, :V0CHSI-VAL-OPER, CURRENT TIMESTAMP, :V0CHSI-SITUACAO:VIND-SIT-REGT, :V0CHSI-TIPSGU:VIND-TIP-SEGR, :V0CHSI-SIT-LIBRECUP:VIND-SIT-LIBR) END-EXEC. */

            var r2400_10_INSERE_V0COSSEG_HSIN_DB_INSERT_1_Insert1 = new R2400_10_INSERE_V0COSSEG_HSIN_DB_INSERT_1_Insert1()
            {
                V0CHSI_COD_EMP = V0CHSI_COD_EMP.ToString(),
                V0CHSI_CONGENER = V0CHSI_CONGENER.ToString(),
                V0CHSI_NUM_SINI = V0CHSI_NUM_SINI.ToString(),
                V0CHSI_OCORHIST = V0CHSI_OCORHIST.ToString(),
                V0CHSI_OPERACAO = V0CHSI_OPERACAO.ToString(),
                V0CHSI_DTMOVTO = V0CHSI_DTMOVTO.ToString(),
                V0CHSI_VAL_OPER = V0CHSI_VAL_OPER.ToString(),
                V0CHSI_SITUACAO = V0CHSI_SITUACAO.ToString(),
                VIND_SIT_REGT = VIND_SIT_REGT.ToString(),
                V0CHSI_TIPSGU = V0CHSI_TIPSGU.ToString(),
                VIND_TIP_SEGR = VIND_TIP_SEGR.ToString(),
                V0CHSI_SIT_LIBRECUP = V0CHSI_SIT_LIBRECUP.ToString(),
                VIND_SIT_LIBR = VIND_SIT_LIBR.ToString(),
            };

            R2400_10_INSERE_V0COSSEG_HSIN_DB_INSERT_1_Insert1.Execute(r2400_10_INSERE_V0COSSEG_HSIN_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2400_99_SAIDA*/

        [StopWatch]
        /*" R3100-00-UPDATE-V0COSSEG-SINI-SECTION */
        private void R3100_00_UPDATE_V0COSSEG_SINI_SECTION()
        {
            /*" -1638- MOVE '310' TO WNR-EXEC-SQL. */
            _.Move("310", WABEND.WNR_EXEC_SQL);

            /*" -1645- PERFORM R3100_00_UPDATE_V0COSSEG_SINI_DB_UPDATE_1 */

            R3100_00_UPDATE_V0COSSEG_SINI_DB_UPDATE_1();

            /*" -1648- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1649- DISPLAY 'R3100 - ERRO NO UPDATE DA V0COSSEG-SINI' */
                _.Display($"R3100 - ERRO NO UPDATE DA V0COSSEG-SINI");

                /*" -1650- DISPLAY 'TIP SEGUR - ' V1CSIN-TIPSGU */
                _.Display($"TIP SEGUR - {V1CSIN_TIPSGU}");

                /*" -1651- DISPLAY 'CONGENERE - ' V1CSIN-CONGENER */
                _.Display($"CONGENERE - {V1CSIN_CONGENER}");

                /*" -1652- DISPLAY 'SINISTRO  - ' V1CSIN-NUM-SINI */
                _.Display($"SINISTRO  - {V1CSIN_NUM_SINI}");

                /*" -1653- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1654- ELSE */
            }
            else
            {


                /*" -1655- ADD +1 TO AC-U-V0COSSEGSINI */
                AREA_DE_WORK.AC_U_V0COSSEGSINI.Value = AREA_DE_WORK.AC_U_V0COSSEGSINI + +1;

                /*" -1655- END-IF. */
            }


        }

        [StopWatch]
        /*" R3100-00-UPDATE-V0COSSEG-SINI-DB-UPDATE-1 */
        public void R3100_00_UPDATE_V0COSSEG_SINI_DB_UPDATE_1()
        {
            /*" -1645- EXEC SQL UPDATE SEGUROS.V0COSSEG_SINI SET SITUACAO = :WHOST-SITUACAO, TIMESTAMP = CURRENT TIMESTAMP WHERE TIPSGU = :V1CSIN-TIPSGU AND CONGENER = :V1CSIN-CONGENER AND NUM_SINISTRO = :V1CSIN-NUM-SINI END-EXEC. */

            var r3100_00_UPDATE_V0COSSEG_SINI_DB_UPDATE_1_Update1 = new R3100_00_UPDATE_V0COSSEG_SINI_DB_UPDATE_1_Update1()
            {
                WHOST_SITUACAO = WHOST_SITUACAO.ToString(),
                V1CSIN_CONGENER = V1CSIN_CONGENER.ToString(),
                V1CSIN_NUM_SINI = V1CSIN_NUM_SINI.ToString(),
                V1CSIN_TIPSGU = V1CSIN_TIPSGU.ToString(),
            };

            R3100_00_UPDATE_V0COSSEG_SINI_DB_UPDATE_1_Update1.Execute(r3100_00_UPDATE_V0COSSEG_SINI_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3100_99_SAIDA*/

        [StopWatch]
        /*" R4000-00-TRATA-INTEGRIDADE-SECTION */
        private void R4000_00_TRATA_INTEGRIDADE_SECTION()
        {
            /*" -1668- MOVE '400' TO WNR-EXEC-SQL. */
            _.Move("400", WABEND.WNR_EXEC_SQL);

            /*" -1670- PERFORM R4100-00-SELECT-V1HISTSINI-101. */

            R4100_00_SELECT_V1HISTSINI_101_SECTION();

            /*" -1672- PERFORM R4200-00-SELECT-V1COTACAO. */

            R4200_00_SELECT_V1COTACAO_SECTION();

            /*" -1674- IF V1MSIN-RAMO = 68 AND V1MSIN-NUM-APOL = 6501000001 */

            if (V1MSIN_RAMO == 68 && V1MSIN_NUM_APOL == 6501000001)
            {

                /*" -1677- COMPUTE W0VLR-RESSEG ROUNDED = V2HSIN-VAL-OPER * V1MSIN-PCTRES / 100 */
                AREA_DE_WORK.W0VLR_RESSEG.Value = V2HSIN_VAL_OPER * V1MSIN_PCTRES / 100f;

                /*" -1678- ELSE */
            }
            else
            {


                /*" -1679- MOVE ZEROS TO W0VLR-RESSEG */
                _.Move(0, AREA_DE_WORK.W0VLR_RESSEG);

                /*" -1681- END-IF. */
            }


            /*" -1686- COMPUTE W2HSIN-VAL-OPER ROUNDED = (V2HSIN-VAL-OPER - W0VLR-RESSEG) * V1APCD-PCPARTIC / 100. */
            AREA_DE_WORK.W2HSIN_VAL_OPER.Value = (V2HSIN_VAL_OPER - AREA_DE_WORK.W0VLR_RESSEG) * V1APCD_PCPARTIC / 100f;

            /*" -1689- COMPUTE W2MSIN-VAL-OPER ROUNDED = W2HSIN-VAL-OPER / V1COTA-VL-VENDA. */
            AREA_DE_WORK.W2MSIN_VAL_OPER.Value = AREA_DE_WORK.W2HSIN_VAL_OPER / V1COTA_VL_VENDA;

            /*" -1690- MOVE ZEROS TO V2CSIN-COD-EMP. */
            _.Move(0, V2CSIN_COD_EMP);

            /*" -1691- MOVE '1' TO V2CSIN-TIPSGU. */
            _.Move("1", V2CSIN_TIPSGU);

            /*" -1692- MOVE V1APCD-CODCOSS TO V2CSIN-CONGENER. */
            _.Move(V1APCD_CODCOSS, V2CSIN_CONGENER);

            /*" -1693- MOVE V1MSIN-NUM-SINI TO V2CSIN-NUM-SINI. */
            _.Move(V1MSIN_NUM_SINI, V2CSIN_NUM_SINI);

            /*" -1694- MOVE W2MSIN-VAL-OPER TO V2CSIN-VAL-OPER. */
            _.Move(AREA_DE_WORK.W2MSIN_VAL_OPER, V2CSIN_VAL_OPER);

            /*" -1695- MOVE '0' TO V2CSIN-SITUACAO. */
            _.Move("0", V2CSIN_SITUACAO);

            /*" -1697- MOVE '0' TO V2CSIN-SIT-CONG. */
            _.Move("0", V2CSIN_SIT_CONG);

            /*" -1699- PERFORM R4300-00-INSERT-V0COSSEG-SINI. */

            R4300_00_INSERT_V0COSSEG_SINI_SECTION();

            /*" -1700- MOVE ZEROS TO V2CHSI-COD-EMP. */
            _.Move(0, V2CHSI_COD_EMP);

            /*" -1701- MOVE V1APCD-CODCOSS TO V2CHSI-CONGENER. */
            _.Move(V1APCD_CODCOSS, V2CHSI_CONGENER);

            /*" -1703- MOVE V1MSIN-NUM-SINI TO V2CHSI-NUM-SINI. */
            _.Move(V1MSIN_NUM_SINI, V2CHSI_NUM_SINI);

            /*" -1704- MOVE 01 TO V2CHSI-OCORHIST. */
            _.Move(01, V2CHSI_OCORHIST);

            /*" -1705- MOVE 0101 TO V2CHSI-OPERACAO. */
            _.Move(0101, V2CHSI_OPERACAO);

            /*" -1706- MOVE V2HSIN-DTMOVTO TO V2CHSI-DTMOVTO. */
            _.Move(V2HSIN_DTMOVTO, V2CHSI_DTMOVTO);

            /*" -1708- MOVE W2HSIN-VAL-OPER TO V2CHSI-VAL-OPER. */
            _.Move(AREA_DE_WORK.W2HSIN_VAL_OPER, V2CHSI_VAL_OPER);

            /*" -1709- MOVE '0' TO V2CHSI-SITUACAO. */
            _.Move("0", V2CHSI_SITUACAO);

            /*" -1711- MOVE +1 TO VIND-SIT-REGT. */
            _.Move(+1, VIND_SIT_REGT);

            /*" -1712- MOVE '1' TO V2CHSI-TIPSGU. */
            _.Move("1", V2CHSI_TIPSGU);

            /*" -1714- MOVE +1 TO VIND-TIP-SEGR. */
            _.Move(+1, VIND_TIP_SEGR);

            /*" -1715- MOVE '0' TO V2CHSI-SIT-LIBRECUP. */
            _.Move("0", V2CHSI_SIT_LIBRECUP);

            /*" -1717- MOVE +1 TO VIND-SIT-LIBR. */
            _.Move(+1, VIND_SIT_LIBR);

            /*" -1717- PERFORM R4400-00-INSERT-V0COSSEG-HSIN. */

            R4400_00_INSERT_V0COSSEG_HSIN_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4000_99_SAIDA*/

        [StopWatch]
        /*" R4100-00-SELECT-V1HISTSINI-101-SECTION */
        private void R4100_00_SELECT_V1HISTSINI_101_SECTION()
        {
            /*" -1730- MOVE '410' TO WNR-EXEC-SQL. */
            _.Move("410", WABEND.WNR_EXEC_SQL);

            /*" -1740- PERFORM R4100_00_SELECT_V1HISTSINI_101_DB_SELECT_1 */

            R4100_00_SELECT_V1HISTSINI_101_DB_SELECT_1();

            /*" -1743- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1744- DISPLAY 'R4100 - ERRO NO SELECT DA V1HISTSINI - 101' */
                _.Display($"R4100 - ERRO NO SELECT DA V1HISTSINI - 101");

                /*" -1745- DISPLAY 'SINISTRO - ' V1MSIN-NUM-SINI */
                _.Display($"SINISTRO - {V1MSIN_NUM_SINI}");

                /*" -1746- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1746- END-IF. */
            }


        }

        [StopWatch]
        /*" R4100-00-SELECT-V1HISTSINI-101-DB-SELECT-1 */
        public void R4100_00_SELECT_V1HISTSINI_101_DB_SELECT_1()
        {
            /*" -1740- EXEC SQL SELECT VAL_OPERACAO, DTMOVTO INTO :V2HSIN-VAL-OPER, :V2HSIN-DTMOVTO FROM SEGUROS.V1HISTSINI WHERE NUM_APOL_SINISTRO = :V1MSIN-NUM-SINI AND OPERACAO = 0101 AND OCORHIST = 01 AND TIPREG = '1' END-EXEC. */

            var r4100_00_SELECT_V1HISTSINI_101_DB_SELECT_1_Query1 = new R4100_00_SELECT_V1HISTSINI_101_DB_SELECT_1_Query1()
            {
                V1MSIN_NUM_SINI = V1MSIN_NUM_SINI.ToString(),
            };

            var executed_1 = R4100_00_SELECT_V1HISTSINI_101_DB_SELECT_1_Query1.Execute(r4100_00_SELECT_V1HISTSINI_101_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V2HSIN_VAL_OPER, V2HSIN_VAL_OPER);
                _.Move(executed_1.V2HSIN_DTMOVTO, V2HSIN_DTMOVTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4100_99_SAIDA*/

        [StopWatch]
        /*" R4200-00-SELECT-V1COTACAO-SECTION */
        private void R4200_00_SELECT_V1COTACAO_SECTION()
        {
            /*" -1759- MOVE '420' TO WNR-EXEC-SQL. */
            _.Move("420", WABEND.WNR_EXEC_SQL);

            /*" -1766- PERFORM R4200_00_SELECT_V1COTACAO_DB_SELECT_1 */

            R4200_00_SELECT_V1COTACAO_DB_SELECT_1();

            /*" -1769- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1770- DISPLAY 'R4200 - ERRO NO SELECT DA V1COTACAO' */
                _.Display($"R4200 - ERRO NO SELECT DA V1COTACAO");

                /*" -1771- DISPLAY 'SINISTRO - ' V1MSIN-NUM-SINI */
                _.Display($"SINISTRO - {V1MSIN_NUM_SINI}");

                /*" -1772- DISPLAY 'MOEDA    - ' V1MSIN-COD-MOEDA */
                _.Display($"MOEDA    - {V1MSIN_COD_MOEDA}");

                /*" -1773- DISPLAY 'DT MOVTO - ' V2HSIN-DTMOVTO */
                _.Display($"DT MOVTO - {V2HSIN_DTMOVTO}");

                /*" -1774- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1774- END-IF. */
            }


        }

        [StopWatch]
        /*" R4200-00-SELECT-V1COTACAO-DB-SELECT-1 */
        public void R4200_00_SELECT_V1COTACAO_DB_SELECT_1()
        {
            /*" -1766- EXEC SQL SELECT VAL_VENDA INTO :V1COTA-VL-VENDA FROM SEGUROS.V1COTACAO WHERE CODUNIMO = :V1MSIN-COD-MOEDA AND DTINIVIG <= :V2HSIN-DTMOVTO AND DTTERVIG >= :V2HSIN-DTMOVTO END-EXEC. */

            var r4200_00_SELECT_V1COTACAO_DB_SELECT_1_Query1 = new R4200_00_SELECT_V1COTACAO_DB_SELECT_1_Query1()
            {
                V1MSIN_COD_MOEDA = V1MSIN_COD_MOEDA.ToString(),
                V2HSIN_DTMOVTO = V2HSIN_DTMOVTO.ToString(),
            };

            var executed_1 = R4200_00_SELECT_V1COTACAO_DB_SELECT_1_Query1.Execute(r4200_00_SELECT_V1COTACAO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1COTA_VL_VENDA, V1COTA_VL_VENDA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4200_99_SAIDA*/

        [StopWatch]
        /*" R4300-00-INSERT-V0COSSEG-SINI-SECTION */
        private void R4300_00_INSERT_V0COSSEG_SINI_SECTION()
        {
            /*" -1787- MOVE '430' TO WNR-EXEC-SQL. */
            _.Move("430", WABEND.WNR_EXEC_SQL);

            /*" -1797- PERFORM R4300_00_INSERT_V0COSSEG_SINI_DB_INSERT_1 */

            R4300_00_INSERT_V0COSSEG_SINI_DB_INSERT_1();

            /*" -1800- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1801- IF SQLCODE EQUAL -803 */

                if (DB.SQLCODE == -803)
                {

                    /*" -1802- DISPLAY 'R4300 - REGISTRO DUPLICADO NA V0COSSEG-SINI' */
                    _.Display($"R4300 - REGISTRO DUPLICADO NA V0COSSEG-SINI");

                    /*" -1803- DISPLAY 'TIP SEGUR - ' V2CSIN-TIPSGU */
                    _.Display($"TIP SEGUR - {V2CSIN_TIPSGU}");

                    /*" -1804- DISPLAY 'CONGENERE - ' V2CSIN-CONGENER */
                    _.Display($"CONGENERE - {V2CSIN_CONGENER}");

                    /*" -1805- DISPLAY 'SINISTRO  - ' V2CSIN-NUM-SINI */
                    _.Display($"SINISTRO  - {V2CSIN_NUM_SINI}");

                    /*" -1806- ELSE */
                }
                else
                {


                    /*" -1807- DISPLAY 'R4300 - ERRO NO INSERT DA V0COSSEG-SINI' */
                    _.Display($"R4300 - ERRO NO INSERT DA V0COSSEG-SINI");

                    /*" -1808- DISPLAY 'TIP SEGUR - ' V2CSIN-TIPSGU */
                    _.Display($"TIP SEGUR - {V2CSIN_TIPSGU}");

                    /*" -1809- DISPLAY 'CONGENERE - ' V2CSIN-CONGENER */
                    _.Display($"CONGENERE - {V2CSIN_CONGENER}");

                    /*" -1810- DISPLAY 'SINISTRO  - ' V2CSIN-NUM-SINI */
                    _.Display($"SINISTRO  - {V2CSIN_NUM_SINI}");

                    /*" -1811- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1812- END-IF */
                }


                /*" -1812- END-IF. */
            }


        }

        [StopWatch]
        /*" R4300-00-INSERT-V0COSSEG-SINI-DB-INSERT-1 */
        public void R4300_00_INSERT_V0COSSEG_SINI_DB_INSERT_1()
        {
            /*" -1797- EXEC SQL INSERT INTO SEGUROS.V0COSSEG_SINI VALUES (:V2CSIN-COD-EMP, :V2CSIN-TIPSGU, :V2CSIN-CONGENER, :V2CSIN-NUM-SINI, :V2CSIN-VAL-OPER, :V2CSIN-SITUACAO, :V2CSIN-SIT-CONG, CURRENT TIMESTAMP) END-EXEC. */

            var r4300_00_INSERT_V0COSSEG_SINI_DB_INSERT_1_Insert1 = new R4300_00_INSERT_V0COSSEG_SINI_DB_INSERT_1_Insert1()
            {
                V2CSIN_COD_EMP = V2CSIN_COD_EMP.ToString(),
                V2CSIN_TIPSGU = V2CSIN_TIPSGU.ToString(),
                V2CSIN_CONGENER = V2CSIN_CONGENER.ToString(),
                V2CSIN_NUM_SINI = V2CSIN_NUM_SINI.ToString(),
                V2CSIN_VAL_OPER = V2CSIN_VAL_OPER.ToString(),
                V2CSIN_SITUACAO = V2CSIN_SITUACAO.ToString(),
                V2CSIN_SIT_CONG = V2CSIN_SIT_CONG.ToString(),
            };

            R4300_00_INSERT_V0COSSEG_SINI_DB_INSERT_1_Insert1.Execute(r4300_00_INSERT_V0COSSEG_SINI_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4300_99_SAIDA*/

        [StopWatch]
        /*" R4400-00-INSERT-V0COSSEG-HSIN-SECTION */
        private void R4400_00_INSERT_V0COSSEG_HSIN_SECTION()
        {
            /*" -1825- MOVE '440' TO WNR-EXEC-SQL. */
            _.Move("440", WABEND.WNR_EXEC_SQL);

            /*" -1838- PERFORM R4400_00_INSERT_V0COSSEG_HSIN_DB_INSERT_1 */

            R4400_00_INSERT_V0COSSEG_HSIN_DB_INSERT_1();

            /*" -1841- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1842- IF SQLCODE EQUAL -803 */

                if (DB.SQLCODE == -803)
                {

                    /*" -1843- DISPLAY 'R4400 - REGISTRO DUPLICADO NA V0COSSEG-HSIN' */
                    _.Display($"R4400 - REGISTRO DUPLICADO NA V0COSSEG-HSIN");

                    /*" -1844- DISPLAY 'TIP SEGUR - ' V2CHSI-TIPSGU */
                    _.Display($"TIP SEGUR - {V2CHSI_TIPSGU}");

                    /*" -1845- DISPLAY 'CONGENERE - ' V2CHSI-CONGENER */
                    _.Display($"CONGENERE - {V2CHSI_CONGENER}");

                    /*" -1846- DISPLAY 'SINISTRO  - ' V2CHSI-NUM-SINI */
                    _.Display($"SINISTRO  - {V2CHSI_NUM_SINI}");

                    /*" -1847- DISPLAY 'OCOR HIST - ' V2CHSI-OCORHIST */
                    _.Display($"OCOR HIST - {V2CHSI_OCORHIST}");

                    /*" -1848- DISPLAY 'OPERACAO  - ' V2CHSI-OPERACAO */
                    _.Display($"OPERACAO  - {V2CHSI_OPERACAO}");

                    /*" -1849- ELSE */
                }
                else
                {


                    /*" -1850- DISPLAY 'R4400 - ERRO NO INSERT DA V0COSSEG-HISTSIN' */
                    _.Display($"R4400 - ERRO NO INSERT DA V0COSSEG-HISTSIN");

                    /*" -1851- DISPLAY 'TIP SEGUR - ' V2CHSI-TIPSGU */
                    _.Display($"TIP SEGUR - {V2CHSI_TIPSGU}");

                    /*" -1852- DISPLAY 'CONGENERE - ' V2CHSI-CONGENER */
                    _.Display($"CONGENERE - {V2CHSI_CONGENER}");

                    /*" -1853- DISPLAY 'SINISTRO  - ' V2CHSI-NUM-SINI */
                    _.Display($"SINISTRO  - {V2CHSI_NUM_SINI}");

                    /*" -1854- DISPLAY 'OCOR HIST - ' V2CHSI-OCORHIST */
                    _.Display($"OCOR HIST - {V2CHSI_OCORHIST}");

                    /*" -1855- DISPLAY 'OPERACAO  - ' V2CHSI-OPERACAO */
                    _.Display($"OPERACAO  - {V2CHSI_OPERACAO}");

                    /*" -1856- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1857- END-IF */
                }


                /*" -1857- END-IF. */
            }


        }

        [StopWatch]
        /*" R4400-00-INSERT-V0COSSEG-HSIN-DB-INSERT-1 */
        public void R4400_00_INSERT_V0COSSEG_HSIN_DB_INSERT_1()
        {
            /*" -1838- EXEC SQL INSERT INTO SEGUROS.V0COSSEG_HISTSIN VALUES (:V2CHSI-COD-EMP, :V2CHSI-CONGENER, :V2CHSI-NUM-SINI, :V2CHSI-OCORHIST, :V2CHSI-OPERACAO, :V2CHSI-DTMOVTO, :V2CHSI-VAL-OPER, CURRENT TIMESTAMP, :V2CHSI-SITUACAO:VIND-SIT-REGT, :V2CHSI-TIPSGU:VIND-TIP-SEGR, :V2CHSI-SIT-LIBRECUP:VIND-SIT-LIBR) END-EXEC. */

            var r4400_00_INSERT_V0COSSEG_HSIN_DB_INSERT_1_Insert1 = new R4400_00_INSERT_V0COSSEG_HSIN_DB_INSERT_1_Insert1()
            {
                V2CHSI_COD_EMP = V2CHSI_COD_EMP.ToString(),
                V2CHSI_CONGENER = V2CHSI_CONGENER.ToString(),
                V2CHSI_NUM_SINI = V2CHSI_NUM_SINI.ToString(),
                V2CHSI_OCORHIST = V2CHSI_OCORHIST.ToString(),
                V2CHSI_OPERACAO = V2CHSI_OPERACAO.ToString(),
                V2CHSI_DTMOVTO = V2CHSI_DTMOVTO.ToString(),
                V2CHSI_VAL_OPER = V2CHSI_VAL_OPER.ToString(),
                V2CHSI_SITUACAO = V2CHSI_SITUACAO.ToString(),
                VIND_SIT_REGT = VIND_SIT_REGT.ToString(),
                V2CHSI_TIPSGU = V2CHSI_TIPSGU.ToString(),
                VIND_TIP_SEGR = VIND_TIP_SEGR.ToString(),
                V2CHSI_SIT_LIBRECUP = V2CHSI_SIT_LIBRECUP.ToString(),
                VIND_SIT_LIBR = VIND_SIT_LIBR.ToString(),
            };

            R4400_00_INSERT_V0COSSEG_HSIN_DB_INSERT_1_Insert1.Execute(r4400_00_INSERT_V0COSSEG_HSIN_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4400_99_SAIDA*/

        [StopWatch]
        /*" R9900-00-ENCERRA-SEM-MOVTO-SECTION */
        private void R9900_00_ENCERRA_SEM_MOVTO_SECTION()
        {
            /*" -1873- MOVE V1SIST-DTMOVABE TO WDATA-REL. */
            _.Move(V1SIST_DTMOVABE, AREA_DE_WORK.WDATA_REL);

            /*" -1874- MOVE WDAT-REL-DIA TO WDAT-LIT-DIA. */
            _.Move(AREA_DE_WORK.FILLER_0.WDAT_REL_DIA, AREA_DE_WORK.WDAT_REL_LIT.WDAT_LIT_DIA);

            /*" -1875- MOVE WDAT-REL-MES TO WDAT-LIT-MES. */
            _.Move(AREA_DE_WORK.FILLER_0.WDAT_REL_MES, AREA_DE_WORK.WDAT_REL_LIT.WDAT_LIT_MES);

            /*" -1877- MOVE WDAT-REL-ANO TO WDAT-LIT-ANO. */
            _.Move(AREA_DE_WORK.FILLER_0.WDAT_REL_ANO, AREA_DE_WORK.WDAT_REL_LIT.WDAT_LIT_ANO);

            /*" -1878- DISPLAY '*------------------------------------------*' . */
            _.Display($"*------------------------------------------*");

            /*" -1879- DISPLAY '*                                          *' . */
            _.Display($"*                                          *");

            /*" -1880- DISPLAY '*   AC0017B - ATUALIZACAO DB DE COSSEGURO  *' . */
            _.Display($"*   AC0017B - ATUALIZACAO DB DE COSSEGURO  *");

            /*" -1881- DISPLAY '*   -------   ----------- -- -- ---------  *' . */
            _.Display($"*   -------   ----------- -- -- ---------  *");

            /*" -1882- DISPLAY '*               S I N I S T R O S          *' . */
            _.Display($"*               S I N I S T R O S          *");

            /*" -1883- DISPLAY '*               ----------------           *' . */
            _.Display($"*               ----------------           *");

            /*" -1884- DISPLAY '*                                          *' . */
            _.Display($"*                                          *");

            /*" -1885- DISPLAY '*     NAO HOUVE MOVIMENTACAO NESTA DATA    *' . */
            _.Display($"*     NAO HOUVE MOVIMENTACAO NESTA DATA    *");

            /*" -1887- DISPLAY '*              ' WDAT-REL-LIT '                    *' . */

            $"*              {AREA_DE_WORK.WDAT_REL_LIT}                    *"
            .Display();

            /*" -1888- DISPLAY '*                                          *' . */
            _.Display($"*                                          *");

            /*" -1888- DISPLAY '*------------------------------------------*' . */
            _.Display($"*------------------------------------------*");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9900_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -1903- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, WABEND.WSQLCODE);

            /*" -1905- DISPLAY WABEND. */
            _.Display(WABEND);

            /*" -1905- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -1909- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -1909- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}