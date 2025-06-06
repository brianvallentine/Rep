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
using Sias.Sinistro.DB2.SI0133B;

namespace Code
{
    public class SI0133B
    {
        public bool IsCall { get; set; }

        public SI0133B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------( MPS - HABITACIONAL )---------------------------------*       */
        /*"      *   SISTEMA              =    SINISTRO.                         *       */
        /*"      *   PROGRAMA             =    SI0133B.                          *       */
        /*"      *   OBJETIVO             =    EMISSAO DE MPS HABITACIONAL       *       */
        /*"      *   PRODUTOS SELECIONADOS (CARTEIRA HABITACIONAL)               *       */
        /*"      *                                                               *       */
        /*"      *   HEIDER - 07/08/2001 - ALTERACAO DE SELECAO DOS PRODUTOS     *       */
        /*"      *  PROGRAMA ==>  SI0016B                                        *       */
        /*"      *     TODOS V0MESTSINI.RAMO = 48 AND M.CODPRODU <> 4800 (C.I.)  *       */
        /*"      *     4804 - CAIXA CONDOMINIO.......................(SI7AA)     *       */
        /*"      *     4811 - CIBRASEC ..............................(SI7AA)     *       */
        /*"      *            OS DEMAIS PRODUTOS ESTARAO SENDO GERADOS PELO      *       */
        /*"      *            PROGRAMA SI0133B                                   *       */
        /*"      *  PROGRAMA ==>  SI0133B                                        *       */
        /*"      *     6800 - CARTEIRA HIPOTECARIA...................(SI1AA)     *       */
        /*"      *     6801 - NOVACAO DE DIVIDA......................(SI05A - RD)*       */
        /*"      *     6802 - FUNCEF.................................(SI0AA)     *       */
        /*"      *     6803 - CARTA DE CREDITO.......................(SI7AA)     *       */
        /*"      *     6804 - POUP. CREDITO IMOBILIARIO - PCI........(SI7AA)     *       */
        /*"      *     6805 - SFH - LIVRE............................(SI7AA)     *       */
        /*"      *     6806 - SFI - SISTEMA FINANCEIRO IMOBILIARIO...(SI7AA)     *       */
        /*"      *     6807 - PROJETO PAR ...........................(SI7AA)     *       */
        /*"      *     6808 - ARRENDAMENTO ESPECIAL .................(SI7AA)     *       */
        /*"      *     6600 - RAMO 66 - CEF (APOL. 0106600000001) ...(SI05A)     *       */
        /*"      *     6600 - RAMO 66 - EXTRA-CEF (APOL. 66001000001).(SI05A)    *       */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO  : 024                                                  *      */
        /*"      * MOTIVO  : ABEND NA ROTINA JPSID03 0C7 MOTIVO ESTOURO DA TABELA *      */
        /*"      *           INTERNA  DETALHE-OCC DIA 22/03/2017                 *       */
        /*"      * CADMUS  : 149294                                               *      */
        /*"      * DATA    : 23/03/2017                                           *      */
        /*"      * NOME    : DIOGO MATHEUS                                        *      */
        /*"      * MARCADOR: V.24                                                 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO  : 023                                                  *      */
        /*"      * MOTIVO  : ABEND NA ROTINA JPSID03 0C7 MOTIVO ESTOURO DA TABELA *      */
        /*"      *           INTERNA  DETALHE-OCC                                *       */
        /*"      * CADMUS  : 139896                                               *      */
        /*"      * DATA    : 14/02/2017                                           *      */
        /*"      * NOME    : DIOGO MATHEUS                                        *      */
        /*"      * MARCADOR: V.23                                                 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                               *       */
        /*"      *   ANALISTA/PROGRAMADOR =    PROCAS/PROCAS.                    *       */
        /*"      *   DATA / CRIACAO       =    JULHO / 91 .                      *       */
        /*"      *                             MARCO/92   -   FREDERICO          *       */
        /*"      *   DATA / ALTERACAO     =    AGOSTO/ 93 -   LUZIA (SASSE)      *       */
        /*"      *  -------------------------------------------------------------*       */
        /*"      *   ALTERADO PARA PEGAR TIPREG DIFERENTE DE ZERO.               *       */
        /*"      *   NOSSA LIDERENCA.                                            *       */
        /*"      *   PAULINHO  19/09/94.                                         *       */
        /*"      *  -------------------------------------------------------------*       */
        /*"      *   ALTERADO PARA IMPRIMIR + DEZ LINHAS ANTES DA CAB26.         *       */
        /*"      *   BARAN     27/04/95.                                         *       */
        /*"      *  -------------------------------------------------------------*       */
        /*"      *   ALTERADO PARA IMPRIMIR SOMENTE RAMO HABITACIONAL            *       */
        /*"      *   HEIDER    24/06/96.                                         *       */
        /*"      *  -------------------------------------------------------------*       */
        /*"      *   ALTERADO PARA DESCONSIDERAR OPERACOES ENTRE 4000 AMD 5999   *       */
        /*"      *   (SALVADO E RESSARC) NO DECLARE PRINCIPAL E PARAGRAFO 187-00.*       */
        /*"      *   BARAN     14/04/97.                                         *       */
        /*"      *  -------------------------------------------------------------*       */
        /*"      *   ALTERADO PARA IMPRIMIR A AGENCIA DO CONTRATO E AGENCIA CEN- *       */
        /*"      *            TRALIZADORA.                                       *       */
        /*"      *   RILDO SICO 06/04/2000. PROCURAR RS001.                      *       */
        /*"      *  -------------------------------------------------------------*       */
        /*"      *   ALTERADO PARA IMPRIMIR FOLHA DE ROSTO(AZUL) DIZENDO PARA    *       */
        /*"      *   ONDE SERAO ENVIADAS AS MPS.                                 *       */
        /*"      *   LINHA-ASACODE = '+' ==> CHAMA OUTRO FORMULARIO              *       */
        /*"      *   LINHA-ASACODE = '1' ==> PULA FOLHA/PAGINA                   *       */
        /*"      *   LINHA-ASACODE = ' ' ==> IMPRESSAO NORMAL DE LINHA           *       */
        /*"      *   RILDO SICO 06/04/2000. PROCURAR RS002.                      *       */
        /*"      *  -------------------------------------------------------------*       */
        /*"      *ALTERADO POR JEFFERSON PARA UTILIZAR AS NOVAS TABELAS DO HABITA*       */
        /*"      *CIONAL - 23/05/2000                                            *       */
        /*"      *---------------------------------------------------------------*       */
        /*"      *   ALTERADO O CURSOR V1RELATSINI PARA NAO IMPRIMIR AS MPS DAS  *       */
        /*"      *            OPERACOES 1001,1002,1003,1004,1009 E 1050.         *       */
        /*"      *            PROCURAR RS003. RILDO SICO - 25/07/2000.           *       */
        /*"      *---------------------------------------------------------------*       */
        /*"      *   ALTERADO - RILDO SICO - 17/08/2000. INCLUSAO DA TABELA      *       */
        /*"      *            PARAMETR_OPER_SINI, ONDE ESTA DEPOSITADO A DESCRICA*       */
        /*"      *            DAS OPERACOES. PROCURAR RS004.                     *       */
        /*"      *---------------------------------------------------------------*       */
        /*"      *   ALTERADO - RILDO SICO - 26/03/2001. INCLUSAO DO PRODUTO 4811*       */
        /*"      *            PROCURAR. RS005. *                                         */
        /*"      *---------------------------------------------------------------*       */
        /*"      *   ALTERADO - RILDO SICO - 25/04/2001. INCLUSAO DO PRODUTO 6806*       */
        /*"      *            PROCURAR. RS006.                                   *       */
        /*"      *---------------------------------------------------------------*       */
        /*"      *   ALTERADO - RILDO SICO - 02/07/2001. INCLUSAO DO PRODUTO 6807*       */
        /*"      *            E 6808. PROCURAR RS006                             *       */
        /*"      *---------------------------------------------------------------*       */
        /*"      *   SANDRA - 19/09/2003                                         *       */
        /*"      *   INCLUS O DO NUMERO DA CONTA QUANDO O COD. DO FORNECEDOR=9256*       */
        /*"      *   E A GRUPO-CAUSAS = M.I.P.                                   *       */
        /*"      *                                                               *       */
        /*"      * CONVERSAO ANO 2000              CONSEDA4              03/1998 *       */
        /*"      *                                                               *       */
        /*"      * REVISAO - ANO 2000              CONSEDA4           06/06/1998 *       */
        /*"      * *                                                                     */
        /*"      * IMPRESSAO VIA SAM               PRODEXTER(VANDO)   AGOSTO/2002*       */
        /*"      * *                                                                     */
        /*"      * 27/04/2005 - PRODEXTER                                        *       */
        /*"      * (1) SUBSTITUICAO DA TABELA PARAMETR_OPER_SINI PELA GE_OPERACAO *      */
        /*"      * (2) SUBSTITUICAO DOS CALCULOS DE VALORES ATRAVES DE ACESSO A   *      */
        /*"      *     SINISTRO_HISTORICO PELA CHAMADAS AS SUB-ROTINAS DE CALCULO *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * 11/07/08 - BRSEG - CAD.12115 - SAC.237                         *      */
        /*"      *            ELIMINAR CARACTERES ESPECIAIS DE CONTROLE DE IMPRES-*      */
        /*"      *            SAO NOS ARQUIVOS.   -   PROCURE: BR.V01             *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   patricia - 25/11/2008                                        *      */
        /*"      *   alterado o tamanho do campo MPS de 6 posicoes para 9.        *      */
        /*"      *   cadmus 17727.                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   Amaraline - (APV) - 10/12/2008                               *      */
        /*"      *   Agrupar as MPS pelo codigo do usuario e ordenar pelo codigo  *      */
        /*"      *   do usu�rio, sinistro e produto. - Cadmus 18558               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   Amaraline - (APV) - 19/12/2008                               *      */
        /*"      *   Impressao de folha separadora somente se mudar o c�digo do   *      */
        /*"      *   usu�rio. - Cadmus 18558                                      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  16/10/2010 - CAD 47494/2010 - CIRCULAR 395:                   *      */
        /*"      *               SUPORTAR O NOVO RAMO DE COMERCIALIZA��O DO       *      */
        /*"      *               HABITACIONAL, FORA DO SFH; SUPORTAR O NOVO       *      */
        /*"      *               RAMO DE COMERCIALIZA��O DO SEGURO GARANTIA       *      */
        /*"      *               CONSTRUTOR - SETOR P�BLICO E PRIVADO E SU-       *      */
        /*"      *               PORTAR NOVOS PRODUTOS QUE SER�O CRIADOS NO       *      */
        /*"      *               RAMO 48 DOS CONTRATOS DO CONS�RCIO.              *      */
        /*"      *                                                                *      */
        /*"      *               MARCELO NEVES (TE41729)   PROCURAR: C395         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO: 20  - CADMUS 59629 - DIOGO MATHEUS - 26/07/2011        *      */
        /*"      * Abend (System Completion Code=0C4). Estoro de ocorrencias na   *      */
        /*"      * tabela interna DETALHE-OCC. Solu��o aumento no OCCURS para 500 *      */
        /*"      *                                         PROCURAR: V.20         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.21  * SAC 0001                                                       *      */
        /*"      * 14/05/2013 -  CASSIANO   CADMUS 77561                          *      */
        /*"      *     SIAS X SCPJUD.                                             *      */
        /*"      *     ADEQUACAO PARA TRATAR OS MOVIMENTOS JUDICIAIS DE SINISTRO  *      */
        /*"      *     E ARMAZENAR O NUMERO DO PROCESSO SCPJUD NAS OPERACOES      *      */
        /*"      *     JUDICIAIS.                                                 *      */
        /*"      *                                                  PROCURE V.21  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 22 -   NSGD - CADMUS 103659.                          *      */
        /*"      *               - NOVA SOLUCAO DE GESTAO DE DEPOSITOS            *      */
        /*"      *                                                                *      */
        /*"      *   EM 06/11/2014 - COREON                                       *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.22         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        #endregion


        #region VARIABLES

        public FileBasis _SI0133M1 { get; set; } = new FileBasis(new PIC("X", "0", "X(0)"));

        public FileBasis SI0133M1
        {
            get
            {
                _.Move(REG_SI0133M1, _SI0133M1); VarBasis.RedefinePassValue(REG_SI0133M1, _SI0133M1, REG_SI0133M1); return _SI0133M1;
            }
        }
        /*"01  REG-SI0133M1.*/
        public SI0133B_REG_SI0133M1 REG_SI0133M1 { get; set; } = new SI0133B_REG_SI0133M1();
        public class SI0133B_REG_SI0133M1 : VarBasis
        {
            /*"    05 LINHA-ASACODE               PIC X(001).*/

            public SelectorBasis LINHA_ASACODE { get; set; } = new SelectorBasis("001")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 OUTRO-FORMULARIO         VALUE '+'. */
							new SelectorItemBasis("OUTRO_FORMULARIO", "+"),
							/*" 88 NOVA-PAGINA              VALUE '1'. */
							new SelectorItemBasis("NOVA_PAGINA", "1"),
							/*" 88 LINHA-NORMAL             VALUE ' '. */
							new SelectorItemBasis("LINHA_NORMAL", " "),
							/*" 88 PULA-LINHA               VALUE '0'. */
							new SelectorItemBasis("PULA_LINHA", "0")
                }
            };

            /*"    05 LINHA                       PIC X(132).*/
            public StringBasis LINHA { get; set; } = new StringBasis(new PIC("X", "132", "X(132)."), @"");
        }

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"*/
        public IntBasis I01 { get; set; } = new IntBasis(new PIC("9", "4", "9(4)"));
        /*"*/
        public IntBasis I02 { get; set; } = new IntBasis(new PIC("9", "4", "9(4)"));
        /*"*/
        public IntBasis I03 { get; set; } = new IntBasis(new PIC("9", "4", "9(4)"));
        /*"*/
        public IntBasis I04 { get; set; } = new IntBasis(new PIC("9", "4", "9(4)"));
        /*"77  V1EMPRESA-COD-EMP                PIC S9(04) COMP VALUE +0.*/
        public IntBasis V1EMPRESA_COD_EMP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V1EMPRESA-NOM-EMP                PIC X(40).*/
        public StringBasis V1EMPRESA_NOM_EMP { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"77  RAMO-VGAPC                       PIC S9(04) COMP VALUE +0.*/
        public IntBasis RAMO_VGAPC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  RAMO-VG                          PIC S9(04) COMP VALUE +0.*/
        public IntBasis RAMO_VG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  RAMO-AP                          PIC S9(04) COMP VALUE +0.*/
        public IntBasis RAMO_AP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  RAMO-SAUDE                       PIC S9(04) COMP VALUE +0.*/
        public IntBasis RAMO_SAUDE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  RAMO-EDUCACAO                    PIC S9(04) COMP VALUE +0.*/
        public IntBasis RAMO_EDUCACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  SEGV-CLIENTE                     PIC S9(09) COMP VALUE +0.*/
        public IntBasis SEGV_CLIENTE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77  CLIE-NOME-RAZAO        PIC X(40).*/
        public StringBasis CLIE_NOME_RAZAO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"77  MEST-FONTE                       PIC S9(04) COMP VALUE +0.*/
        public IntBasis MEST_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  MEST-PROTSINI                    PIC S9(09) COMP VALUE +0.*/
        public IntBasis MEST_PROTSINI { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77  MEST-DAC                         PIC X(01).*/
        public StringBasis MEST_DAC { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"77  MEST-TIPREG                      PIC X(01).*/
        public StringBasis MEST_TIPREG { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"77  MEST-APOL-SINI                   PIC S9(13) COMP-3 VALUE +0.*/
        public IntBasis MEST_APOL_SINI { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"77  MEST-NUM-APOL                    PIC S9(13) COMP-3 VALUE +0.*/
        public IntBasis MEST_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"77  MEST-NRENDOS                     PIC S9(09) COMP VALUE +0.*/
        public IntBasis MEST_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77  MEST-DATCMD                      PIC X(10).*/
        public StringBasis MEST_DATCMD { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  MEST-DATORR                      PIC X(10).*/
        public StringBasis MEST_DATORR { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  MEST-NUMIRB                      PIC S9(13) COMP-3 VALUE +0.*/
        public IntBasis MEST_NUMIRB { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"77  MEST-PCPARTIC                PIC S9(04)V9(5) COMP-3 VALUE +0*/
        public DoubleBasis MEST_PCPARTIC { get; set; } = new DoubleBasis(new PIC("S9", "4", "S9(04)V9(5)"), 5);
        /*"77  MEST-PCTCED                  PIC S9(04)V9(5) COMP-3 VALUE +0*/
        public DoubleBasis MEST_PCTCED { get; set; } = new DoubleBasis(new PIC("S9", "4", "S9(04)V9(5)"), 5);
        /*"77  MEST-PCTRES                  PIC S9(04)V9(5) COMP-3 VALUE +0*/
        public DoubleBasis MEST_PCTRES { get; set; } = new DoubleBasis(new PIC("S9", "4", "S9(04)V9(5)"), 5);
        /*"77  MEST-TOTPAGBT                PIC S9(10)V9(5) COMP-3 VALUE +0*/
        public DoubleBasis MEST_TOTPAGBT { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(5)"), 5);
        /*"77  MEST-TOTDSABT                PIC S9(10)V9(5) COMP-3 VALUE +0*/
        public DoubleBasis MEST_TOTDSABT { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(5)"), 5);
        /*"77  MEST-TOTHONBT                PIC S9(10)V9(5) COMP-3 VALUE +0*/
        public DoubleBasis MEST_TOTHONBT { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(5)"), 5);
        /*"77  MEST-TOTRSDBT                PIC S9(10)V9(5) COMP-3 VALUE +0*/
        public DoubleBasis MEST_TOTRSDBT { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(5)"), 5);
        /*"77  MEST-SDORCPBT                PIC S9(10)V9(5) COMP-3 VALUE +0*/
        public DoubleBasis MEST_SDORCPBT { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(5)"), 5);
        /*"77  MEST-SDOADTBT                PIC S9(10)V9(5) COMP-3 VALUE +0*/
        public DoubleBasis MEST_SDOADTBT { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(5)"), 5);
        /*"77  MEST-TOTPAG                  PIC S9(13)V9(2) COMP-3 VALUE +0*/
        public DoubleBasis MEST_TOTPAG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"77  MEST-TOTDSA                  PIC S9(13)V9(2) COMP-3 VALUE +0*/
        public DoubleBasis MEST_TOTDSA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"77  MEST-TOTHON                  PIC S9(13)V9(2) COMP-3 VALUE +0*/
        public DoubleBasis MEST_TOTHON { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"77  MEST-TOTRSD                  PIC S9(13)V9(2) COMP-3 VALUE +0*/
        public DoubleBasis MEST_TOTRSD { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"77  MEST-SDORCP                  PIC S9(13)V9(2) COMP-3 VALUE +0*/
        public DoubleBasis MEST_SDORCP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"77  MEST-SDOADT                  PIC S9(13)V9(2) COMP-3 VALUE +0*/
        public DoubleBasis MEST_SDOADT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"77  MEST-NRCERTIF                PIC S9(15) COMP-3 VALUE +0.*/
        public IntBasis MEST_NRCERTIF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"77  MEST-DIGCERT                     PIC X(01).*/
        public StringBasis MEST_DIGCERT { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"77  MEST-IDTPSEGU                    PIC X(01).*/
        public StringBasis MEST_IDTPSEGU { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"77  MEST-CODCAU                      PIC S9(04) COMP VALUE +0.*/
        public IntBasis MEST_CODCAU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  MEST-CODSUBES                    PIC S9(04) COMP VALUE +0.*/
        public IntBasis MEST_CODSUBES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  MEST-DATTEC                      PIC X(10).*/
        public StringBasis MEST_DATTEC { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  MEST-OCORHIST                    PIC S9(04) COMP VALUE +0.*/
        public IntBasis MEST_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  MEST-QUANT-SINI                  PIC S9(09) COMP VALUE +0.*/
        public IntBasis MEST_QUANT_SINI { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77  MEST-COD-MOEDA-SIN               PIC S9(04) COMP VALUE +0.*/
        public IntBasis MEST_COD_MOEDA_SIN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  MEST-RAMO                        PIC S9(04) COMP VALUE +0.*/
        public IntBasis MEST_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  MEST-CODPRODU                    PIC S9(04) COMP VALUE +0.*/
        public IntBasis MEST_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  THIST-APOL-SINI        PIC S9(13) COMP-3 VALUE +0.*/
        public IntBasis THIST_APOL_SINI { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"77  THIST-FONPAG           PIC S9(04) COMP VALUE +0.*/
        public IntBasis THIST_FONPAG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  THIST-DTMOVTO          PIC X(10).*/
        public StringBasis THIST_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  THIST-DTMOVTO1         PIC X(10).*/
        public StringBasis THIST_DTMOVTO1 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  THIST-DTMOVTO2         PIC X(10).*/
        public StringBasis THIST_DTMOVTO2 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  THIST-DTMOVTO3         PIC X(10).*/
        public StringBasis THIST_DTMOVTO3 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  THIST-LIMCRR           PIC X(10).*/
        public StringBasis THIST_LIMCRR { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  THIST-VALPRI           PIC S9(13)V99 COMP-3 VALUE +0.*/
        public DoubleBasis THIST_VALPRI { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77  THIST-VALPRI2          PIC S9(13)V99 COMP-3 VALUE +0.*/
        public DoubleBasis THIST_VALPRI2 { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77  THIST-VALPRI4          PIC S9(13)V99 COMP-3 VALUE +0.*/
        public DoubleBasis THIST_VALPRI4 { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77  THIST-NOMFAV3          PIC X(40).*/
        public StringBasis THIST_NOMFAV3 { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"77  THIST-CRRMON           PIC S9(13)V99 COMP-3 VALUE +0.*/
        public DoubleBasis THIST_CRRMON { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77  THIST-SITUACAO         PIC X(01).*/
        public StringBasis THIST_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"77  THIST-OPERACAO         PIC S9(04) COMP VALUE +0.*/
        public IntBasis THIST_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  THIST-OPERACAO2        PIC S9(04) COMP VALUE +0.*/
        public IntBasis THIST_OPERACAO2 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  THIST-OPERACAO3        PIC S9(04) COMP VALUE +0.*/
        public IntBasis THIST_OPERACAO3 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  THIST-VALPRI1          PIC S9(13)V99 COMP-3 VALUE +0.*/
        public DoubleBasis THIST_VALPRI1 { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77  THIST-OPERACAO1        PIC S9(04) COMP VALUE +0.*/
        public IntBasis THIST_OPERACAO1 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  THIST-VALPRI3          PIC S9(13)V99 COMP-3 VALUE +0.*/
        public DoubleBasis THIST_VALPRI3 { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77  THIST-OCORHIST         PIC S9(04) COMP VALUE +0.*/
        public IntBasis THIST_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  THIST-OCORHIST2        PIC S9(04) COMP VALUE +0.*/
        public IntBasis THIST_OCORHIST2 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  THIST-OCORHIST3        PIC S9(04) COMP VALUE +0.*/
        public IntBasis THIST_OCORHIST3 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  THIST-HORAOPER3        PIC X(26).*/
        public StringBasis THIST_HORAOPER3 { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"77  THIST-MOVPCS           PIC S9(09) COMP VALUE +0.*/
        public IntBasis THIST_MOVPCS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77  THIST-NUMOPG           PIC S9(09) COMP VALUE +0.*/
        public IntBasis THIST_NUMOPG { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77  THIST-CODPSVI          PIC S9(09) COMP VALUE +0.*/
        public IntBasis THIST_CODPSVI { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77  THIST-NOMFAV           PIC X(40).*/
        public StringBasis THIST_NOMFAV { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"77  THIST-TIPFAV           PIC X(01).*/
        public StringBasis THIST_TIPFAV { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"77  THIST-TIMESTAMP        PIC X(26).*/
        public StringBasis THIST_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"77  RELSIN-DTMOVTO         PIC X(10).*/
        public StringBasis RELSIN_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  RELSIN-MOVPCS          PIC S9(09) COMP VALUE +0.*/
        public IntBasis RELSIN_MOVPCS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77  RELSIN-APOL-SINI       PIC S9(13) COMP-3 VALUE +0.*/
        public IntBasis RELSIN_APOL_SINI { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"77  RELSIN-OPERACAO        PIC S9(04) COMP VALUE +0.*/
        public IntBasis RELSIN_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  RELSIN-OCORHIST        PIC S9(04) COMP VALUE +0.*/
        public IntBasis RELSIN_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  RELSIN-CODUSU          PIC X(08).*/
        public StringBasis RELSIN_CODUSU { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
        /*"77  RELSIN-CODRELAT        PIC X(02).*/
        public StringBasis RELSIN_CODRELAT { get; set; } = new StringBasis(new PIC("X", "2", "X(02)."), @"");
        /*"77  RELSIN-CODPSI          PIC S9(06) COMP VALUE +0.*/
        public IntBasis RELSIN_CODPSI { get; set; } = new IntBasis(new PIC("S9", "6", "S9(06)"));
        /*"77  COSS-PCPARTIC          PIC S9(04)V9(5) COMP-3 VALUE +0.*/
        public DoubleBasis COSS_PCPARTIC { get; set; } = new DoubleBasis(new PIC("S9", "4", "S9(04)V9(5)"), 5);
        /*"77  WVARIAV-IND            PIC S9(04) COMP VALUE +0.*/
        public IntBasis WVARIAV_IND { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  WPCPARTIC-IND          PIC S9(04) COMP VALUE +0.*/
        public IntBasis WPCPARTIC_IND { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  TBENEF-NOME-BENEFIC     PIC X(40).*/
        public StringBasis TBENEF_NOME_BENEFIC { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"77  TBENEF-GRAU-PARENT      PIC X(10).*/
        public StringBasis TBENEF_GRAU_PARENT { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  TBENEF-PCT-PART-BENEF   PIC S9(04)V9(5) COMP-3 VALUE +0.*/
        public DoubleBasis TBENEF_PCT_PART_BENEF { get; set; } = new DoubleBasis(new PIC("S9", "4", "S9(04)V9(5)"), 5);
        /*"77  SIST-DTMOVABE          PIC X(10).*/
        public StringBasis SIST_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  SIST-DTCURRENT         PIC X(10).*/
        public StringBasis SIST_DTCURRENT { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  APDCORR-CODCORR        PIC S9(09) COMP VALUE +0.*/
        public IntBasis APDCORR_CODCORR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77  APDCORR-NUM-APOL       PIC S9(13) COMP-3 VALUE +0.*/
        public IntBasis APDCORR_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"77  PROD-CODPDT            PIC S9(09) COMP VALUE +0.*/
        public IntBasis PROD_CODPDT { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77  PROD-NOMPDT            PIC X(40).*/
        public StringBasis PROD_NOMPDT { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"77  APOL-CORRECAO          PIC X(01).*/
        public StringBasis APOL_CORRECAO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"77  APOL-PCTCED            PIC S9(04)V9(5) COMP-3 VALUE +0.*/
        public DoubleBasis APOL_PCTCED { get; set; } = new DoubleBasis(new PIC("S9", "4", "S9(04)V9(5)"), 5);
        /*"77  APOL-NOME              PIC X(40).*/
        public StringBasis APOL_NOME { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"77  PARCEL-NUM-APOL        PIC S9(13) COMP-3 VALUE +0.*/
        public IntBasis PARCEL_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"77  PARCEL-NRENDOS         PIC S9(09) COMP VALUE +0.*/
        public IntBasis PARCEL_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77  PARCEL-NRPARCEL        PIC S9(04) COMP VALUE +0.*/
        public IntBasis PARCEL_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  PARCEL-SITUACAO        PIC X(01).*/
        public StringBasis PARCEL_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"77  PARCEL-OCORHIST        PIC S9(04) COMP VALUE +0.*/
        public IntBasis PARCEL_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  THISTPAR-DTMOVTO       PIC X(10).*/
        public StringBasis THISTPAR_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  THISTPAR-DTVENCTO      PIC X(10).*/
        public StringBasis THISTPAR_DTVENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  ENDOS-DTINIVIG         PIC X(10).*/
        public StringBasis ENDOS_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  ENDOS-DTTERVIG         PIC X(10).*/
        public StringBasis ENDOS_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  ENDOS-QTPARCEL         PIC S9(04) COMP VALUE +0.*/
        public IntBasis ENDOS_QTPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  ENDOS-SITUACAO         PIC X(01).*/
        public StringBasis ENDOS_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"77  ENDOS-FONTE            PIC S9(04) COMP VALUE +0.*/
        public IntBasis ENDOS_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  CAUSA-DESCAU           PIC X(40).*/
        public StringBasis CAUSA_DESCAU { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"77  CAUSA-GRUPO-CAUSAS     PIC X(20).*/
        public StringBasis CAUSA_GRUPO_CAUSAS { get; set; } = new StringBasis(new PIC("X", "20", "X(20)."), @"");
        /*"77  FONTE-NOMEFTE          PIC X(30).*/
        public StringBasis FONTE_NOMEFTE { get; set; } = new StringBasis(new PIC("X", "30", "X(30)."), @"");
        /*"77  GERAMO-NOMERAMO        PIC X(30).*/
        public StringBasis GERAMO_NOMERAMO { get; set; } = new StringBasis(new PIC("X", "30", "X(30)."), @"");
        /*"77  GEUNIMO-VLCRUZAD       PIC S9(06)V9(9) COMP-3 VALUE +0.*/
        public DoubleBasis GEUNIMO_VLCRUZAD { get; set; } = new DoubleBasis(new PIC("S9", "6", "S9(06)V9(9)"), 9);
        /*"77  GEUNIMO-SIGLUNIM       PIC X(06).*/
        public StringBasis GEUNIMO_SIGLUNIM { get; set; } = new StringBasis(new PIC("X", "6", "X(06)."), @"");
        /*"77  WGEUNIMO-DTTERVIG      PIC X(10).*/
        public StringBasis WGEUNIMO_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  WGEUNIMO-DTINIVIG      PIC X(10).*/
        public StringBasis WGEUNIMO_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V0AG-AGE-CENTRAL-PROD01    PIC S9(04) USAGE COMP.*/
        public IntBasis V0AG_AGE_CENTRAL_PROD01 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0AG-COD-AGENCIA           PIC S9(04) USAGE COMP.*/
        public IntBasis V0AG_COD_AGENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0AG-NOME-AGENCIA          PIC  X(40) VALUE SPACES.*/
        public StringBasis V0AG_NOME_AGENCIA { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
        /*"77  V0AG-NOME-AGENCIA-CENTR    PIC  X(40) VALUE SPACES.*/
        public StringBasis V0AG_NOME_AGENCIA_CENTR { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
        /*"77  V0HABIT01-OPERACAO           PIC S9(04) COMP VALUE +0.*/
        public IntBasis V0HABIT01_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0HABIT01-PONTO-VENDA        PIC S9(04) COMP VALUE +0.*/
        public IntBasis V0HABIT01_PONTO_VENDA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0HABIT01-NUM-CONTRATO       PIC S9(09) COMP VALUE +0.*/
        public IntBasis V0HABIT01_NUM_CONTRATO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77  V0HABIT01-CGCCPF             PIC S9(15) COMP-3 VALUE +0.*/
        public IntBasis V0HABIT01_CGCCPF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"77  V0HABIT01-NOME-SEGURADO      PIC  X(40) VALUE SPACES.*/
        public StringBasis V0HABIT01_NOME_SEGURADO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
        /*"77  V0PROD-CODPRODU              PIC S9(04) COMP VALUE +0.*/
        public IntBasis V0PROD_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0PROD-DESCRPROD             PIC X(40) VALUE SPACES.*/
        public StringBasis V0PROD_DESCRPROD { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
        /*"77  WMOEDA          PIC S9(04) COMP  VALUE +0.*/
        public IntBasis WMOEDA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  SI1024S         PIC X(07) VALUE 'SI1024S'.*/
        public StringBasis SI1024S { get; set; } = new StringBasis(new PIC("X", "7", "X(07)"), @"SI1024S");
        /*"77  SI1002S         PIC X(07) VALUE 'SI1002S'.*/
        public StringBasis SI1002S { get; set; } = new StringBasis(new PIC("X", "7", "X(07)"), @"SI1002S");
        /*"77  SI1005S         PIC X(07) VALUE 'SI1005S'.*/
        public StringBasis SI1005S { get; set; } = new StringBasis(new PIC("X", "7", "X(07)"), @"SI1005S");
        /*"77  SI1006S         PIC X(07) VALUE 'SI1006S'.*/
        public StringBasis SI1006S { get; set; } = new StringBasis(new PIC("X", "7", "X(07)"), @"SI1006S");
        /*"77  SI1023S         PIC X(07) VALUE 'SI1023S'.*/
        public StringBasis SI1023S { get; set; } = new StringBasis(new PIC("X", "7", "X(07)"), @"SI1023S");
        /*"77  SI1025S         PIC X(07) VALUE 'SI1025S'.*/
        public StringBasis SI1025S { get; set; } = new StringBasis(new PIC("X", "7", "X(07)"), @"SI1025S");
        /*"77  PROALN01        PIC X(08) VALUE 'PROALN01'.*/
        public StringBasis PROALN01 { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"PROALN01");
        /*"77     IND                 PIC 9(01) VALUE ZEROS.*/
        public IntBasis IND { get; set; } = new IntBasis(new PIC("9", "1", "9(01)"));
        /*" 01     W-OPER-CONTA        PIC 9(16) VALUE ZEROS.*/
        public IntBasis W_OPER_CONTA { get; set; } = new IntBasis(new PIC("9", "16", "9(16)"));
        /*" 01     FILLER REDEFINES W-OPER-CONTA.*/
        private _REDEF_SI0133B_FILLER_0 _filler_0 { get; set; }
        public _REDEF_SI0133B_FILLER_0 FILLER_0
        {
            get { _filler_0 = new _REDEF_SI0133B_FILLER_0(); _.Move(W_OPER_CONTA, _filler_0); VarBasis.RedefinePassValue(W_OPER_CONTA, _filler_0, W_OPER_CONTA); _filler_0.ValueChanged += () => { _.Move(_filler_0, W_OPER_CONTA); }; return _filler_0; }
            set { VarBasis.RedefinePassValue(value, _filler_0, W_OPER_CONTA); }
        }  //Redefines
        public class _REDEF_SI0133B_FILLER_0 : VarBasis
        {
            /*"        03 W-OPER           PIC 9(04).*/
            public IntBasis W_OPER { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
            /*"        03 W-CONTA          PIC 9(12).*/
            public IntBasis W_CONTA { get; set; } = new IntBasis(new PIC("9", "12", "9(12)."));
            /*" 01     W-LIDO-FORNECEDORES PIC X(01) VALUE 'N'.*/

            public _REDEF_SI0133B_FILLER_0()
            {
                W_OPER.ValueChanged += OnValueChanged;
                W_CONTA.ValueChanged += OnValueChanged;
            }

        }
        public StringBasis W_LIDO_FORNECEDORES { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"N");
        /*" 01     W-LINHA             PIC 9(03) VALUE ZEROS.*/
        public IntBasis W_LINHA { get; set; } = new IntBasis(new PIC("9", "3", "9(03)"));
        /*"01  REG-SI0133FS.*/
        public SI0133B_REG_SI0133FS REG_SI0133FS { get; set; } = new SI0133B_REG_SI0133FS();
        public class SI0133B_REG_SI0133FS : VarBasis
        {
            /*"    05          LINHA-ASACODE      PIC  X(001).*/
            public StringBasis LINHA_ASACODE_0 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    05          LINHA-FS           PIC  X(132).*/
            public StringBasis LINHA_FS { get; set; } = new StringBasis(new PIC("X", "132", "X(132)."), @"");
            /*"01              W.*/
        }
        public SI0133B_W W { get; set; } = new SI0133B_W();
        public class SI0133B_W : VarBasis
        {
            /*"  03            CAB01.*/
            public SI0133B_CAB01 CAB01 { get; set; } = new SI0133B_CAB01();
            public class SI0133B_CAB01 : VarBasis
            {
                /*"    05          LC01-RELATORIO PIC X(09) VALUE 'SI0133B.1'.*/
                public StringBasis LC01_RELATORIO { get; set; } = new StringBasis(new PIC("X", "9", "X(09)"), @"SI0133B.1");
                /*"    05          FILLER              PIC X(34) VALUE  SPACES.*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "34", "X(34)"), @"");
                /*"    05          LC01-EMPRESA        PIC X(40) VALUE  SPACES.*/
                public StringBasis LC01_EMPRESA { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
                /*"    05          FILLER              PIC X(34) VALUE  SPACES.*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "34", "X(34)"), @"");
                /*"    05          FILLER              PIC X(11) VALUE 'PAGINA'.*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "11", "X(11)"), @"PAGINA");
                /*"    05          PAG-C01             PIC ZZZ9.*/
                public IntBasis PAG_C01 { get; set; } = new IntBasis(new PIC("9", "4", "ZZZ9."));
                /*"  03            CAB02.*/
            }
            public SI0133B_CAB02 CAB02 { get; set; } = new SI0133B_CAB02();
            public class SI0133B_CAB02 : VarBasis
            {
                /*"    05          FILLER              PIC X(40) VALUE  SPACES.*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
                /*"    05          FILLER              PIC X(02) VALUE  SPACES.*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "2", "X(02)"), @"");
                /*"    05          FILLER              PIC X(35) VALUE               'MOVIMENTACAO DE PROCESSO   -   N.'.*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "35", "X(35)"), @"MOVIMENTACAO DE PROCESSO   -   N.");
                /*"    05          MOVPCS-C02          PIC 9(09) VALUE  ZEROS.*/
                public IntBasis MOVPCS_C02 { get; set; } = new IntBasis(new PIC("9", "9", "9(09)"));
                /*"    05          FILLER              PIC X(31) VALUE  SPACES.*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "31", "X(31)"), @"");
                /*"    05          FILLER              PIC X(05) VALUE 'DATA'.*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "5", "X(05)"), @"DATA");
                /*"    05          LC02-DATA           PIC X(10) VALUE  SPACES.*/
                public StringBasis LC02_DATA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
                /*"  03            CAB02B.*/
            }
            public SI0133B_CAB02B CAB02B { get; set; } = new SI0133B_CAB02B();
            public class SI0133B_CAB02B : VarBasis
            {
                /*"    05          FILLER              PIC X(117) VALUE SPACES.*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "117", "X(117)"), @"");
                /*"    05          FILLER              PIC X(07) VALUE 'HORA'.*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "7", "X(07)"), @"HORA");
                /*"    05          LC03-HORA           PIC X(08) VALUE  SPACES.*/
                public StringBasis LC03_HORA { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
                /*"  03            CAB03.*/
            }
            public SI0133B_CAB03 CAB03 { get; set; } = new SI0133B_CAB03();
            public class SI0133B_CAB03 : VarBasis
            {
                /*"    05          FILLER              PIC X(11) VALUE               'FONTE    : '.*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "11", "X(11)"), @"FONTE    : ");
                /*"    05          NOMEFTE-C03         PIC X(30) VALUE  SPACES.*/
                public StringBasis NOMEFTE_C03 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"");
                /*"    05          FILLER              PIC X(27) VALUE               '           OCORRENCIA    : '.*/
                public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "27", "X(27)"), @"           OCORRENCIA    : ");
                /*"    05          DATORR-C03          PIC X(10) VALUE  SPACES.*/
                public StringBasis DATORR_C03 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
                /*"    05          FILLER              PIC X(14) VALUE               '    CORRECAO: '.*/
                public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "14", "X(14)"), @"    CORRECAO: ");
                /*"    05          CORRECAO-C05        PIC X(15) VALUE  SPACES.*/
                public StringBasis CORRECAO_C05 { get; set; } = new StringBasis(new PIC("X", "15", "X(15)"), @"");
                /*"    05          FILLER              PIC X(12) VALUE               ' SINISTRO : '.*/
                public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @" SINISTRO : ");
                /*"    05          SINISTRO-C03        PIC 9(13)  VALUE ZEROS.*/
                public IntBasis SINISTRO_C03 { get; set; } = new IntBasis(new PIC("9", "13", "9(13)"));
                /*"    05          FILLER REDEFINES  SINISTRO-C03.*/
                private _REDEF_SI0133B_FILLER_15 _filler_15 { get; set; }
                public _REDEF_SI0133B_FILLER_15 FILLER_15
                {
                    get { _filler_15 = new _REDEF_SI0133B_FILLER_15(); _.Move(SINISTRO_C03, _filler_15); VarBasis.RedefinePassValue(SINISTRO_C03, _filler_15, SINISTRO_C03); _filler_15.ValueChanged += () => { _.Move(_filler_15, SINISTRO_C03); }; return _filler_15; }
                    set { VarBasis.RedefinePassValue(value, _filler_15, SINISTRO_C03); }
                }  //Redefines
                public class _REDEF_SI0133B_FILLER_15 : VarBasis
                {
                    /*"      07        ORGSIN-C03          PIC 9(03).*/
                    public IntBasis ORGSIN_C03 { get; set; } = new IntBasis(new PIC("9", "3", "9(03)."));
                    /*"      07        RMOSIN-C03          PIC 9(02).*/
                    public IntBasis RMOSIN_C03 { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                    /*"      07        NUMSIN-C03          PIC 9(08).*/
                    public IntBasis NUMSIN_C03 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)."));
                    /*"  03            CAB04.*/

                    public _REDEF_SI0133B_FILLER_15()
                    {
                        ORGSIN_C03.ValueChanged += OnValueChanged;
                        RMOSIN_C03.ValueChanged += OnValueChanged;
                        NUMSIN_C03.ValueChanged += OnValueChanged;
                    }

                }
            }
            public SI0133B_CAB04 CAB04 { get; set; } = new SI0133B_CAB04();
            public class SI0133B_CAB04 : VarBasis
            {
                /*"    05          FILLER              PIC X(11) VALUE               'RAMO     : '.*/
                public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "11", "X(11)"), @"RAMO     : ");
                /*"    05          NOMERAMO-C04        PIC X(40) VALUE  SPACES.*/
                public StringBasis NOMERAMO_C04 { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
                /*"    05          FILLER              PIC X(17) VALUE               ' COMUNICACAO   : '.*/
                public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "17", "X(17)"), @" COMUNICACAO   : ");
                /*"    05          DTCOMUN-C04         PIC X(10) VALUE  SPACES.*/
                public StringBasis DTCOMUN_C04 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
                /*"    05          FILLER              PIC X(14) VALUE               '    SITUACAO: '.*/
                public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "14", "X(14)"), @"    SITUACAO: ");
                /*"    05          SITUACAO-C04        PIC X(15) VALUE  SPACES.*/
                public StringBasis SITUACAO_C04 { get; set; } = new StringBasis(new PIC("X", "15", "X(15)"), @"");
                /*"    05          FILLER              PIC X(12) VALUE               ' PROTOCOLO: '.*/
                public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @" PROTOCOLO: ");
                /*"    05          FONTE-C04           PIC 9(03) VALUE  ZEROS.*/
                public IntBasis FONTE_C04 { get; set; } = new IntBasis(new PIC("9", "3", "9(03)"));
                /*"    05          FILLER              PIC X(01) VALUE  SPACES.*/
                public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
                /*"    05          PROTSINI-C04        PIC 9(06) VALUE  ZEROS.*/
                public IntBasis PROTSINI_C04 { get; set; } = new IntBasis(new PIC("9", "6", "9(06)"));
                /*"    05          FILLER              PIC X(01) VALUE  SPACES.*/
                public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
                /*"    05          DAC-C04             PIC 9(01) VALUE  ZEROS.*/
                public IntBasis DAC_C04 { get; set; } = new IntBasis(new PIC("9", "1", "9(01)"));
                /*"    05          FILLER              PIC X(02) VALUE  SPACES.*/
                public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "2", "X(02)"), @"");
                /*"  03 CAB04A.*/
            }
            public SI0133B_CAB04A CAB04A { get; set; } = new SI0133B_CAB04A();
            public class SI0133B_CAB04A : VarBasis
            {
                /*"     05 FILLER                       PIC X(11) VALUE        'PRODUTO  : '.*/
                public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "11", "X(11)"), @"PRODUTO  : ");
                /*"     05 CODPRODU-C04                 PIC 9(4) VALUE  ZEROS.*/
                public IntBasis CODPRODU_C04 { get; set; } = new IntBasis(new PIC("9", "4", "9(4)"));
                /*"     05 FILLER                       PIC X(3) VALUE ' - '.*/
                public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "3", "X(3)"), @" - ");
                /*"     05 NOME-CODPRODU-C04            PIC X(40) VALUE  ZEROS.*/
                public StringBasis NOME_CODPRODU_C04 { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
                /*"  03 CAB05.*/
            }
            public SI0133B_CAB05 CAB05 { get; set; } = new SI0133B_CAB05();
            public class SI0133B_CAB05 : VarBasis
            {
                /*"     05 FILLER                       PIC X(11) VALUE        'APOLICE  : '.*/
                public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "11", "X(11)"), @"APOLICE  : ");
                /*"     05 APOLICE-C05                  PIC 9(13) VALUE  ZEROS.*/
                public IntBasis APOLICE_C05 { get; set; } = new IntBasis(new PIC("9", "13", "9(13)"));
                /*"     05 FILLER                       PIC X(3) VALUE  ' - '.*/
                public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "3", "X(3)"), @" - ");
                /*"     05 NOME-APOLICE                 PIC X(40) VALUE  SPACES.*/
                public StringBasis NOME_APOLICE { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
                /*"     05 FILLER                       PIC X(10) VALUE  SPACES.*/
                public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
                /*"     05 FILLER                       PIC X(10) VALUE        'CAUSA    :'.*/
                public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"CAUSA    :");
                /*"     05 FILLER                       PIC X(1) VALUE  SPACES.*/
                public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "1", "X(1)"), @"");
                /*"     05 CODCAU-C05                   PIC 9(2) VALUE  ZEROS.*/
                public IntBasis CODCAU_C05 { get; set; } = new IntBasis(new PIC("9", "2", "9(2)"));
                /*"     05 FILLER                       PIC X(1) VALUE  SPACES.*/
                public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "1", "X(1)"), @"");
                /*"     05 DESCAU-C05                   PIC X(40) VALUE  SPACES.*/
                public StringBasis DESCAU_C05 { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
                /*"  03 CAB07.*/
            }
            public SI0133B_CAB07 CAB07 { get; set; } = new SI0133B_CAB07();
            public class SI0133B_CAB07 : VarBasis
            {
                /*"     05 FILLER                       PIC X(11) VALUE        'CONTRATO : '.*/
                public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "11", "X(11)"), @"CONTRATO : ");
                /*"     05 OPERACAO-C07                 PIC 999.*/
                public IntBasis OPERACAO_C07 { get; set; } = new IntBasis(new PIC("9", "3", "999."));
                /*"     05 FILLER                       PIC X(1) VALUE  '-'.*/
                public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "1", "X(1)"), @"-");
                /*"     05 PONTO-VENDA-C07              PIC 9999.*/
                public IntBasis PONTO_VENDA_C07 { get; set; } = new IntBasis(new PIC("9", "4", "9999."));
                /*"     05 FILLER                       PIC X(1) VALUE  '-'.*/
                public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "1", "X(1)"), @"-");
                /*"     05 NUM-CONTRATO-C07             PIC 999.999.999.*/
                public IntBasis NUM_CONTRATO_C07 { get; set; } = new IntBasis(new PIC("9", "9", "999.999.999."));
                /*"     05 FILLER                       PIC X(02) VALUE  SPACES.*/
                public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "2", "X(02)"), @"");
                /*"     05 FILLER                       PIC X(44) VALUE  SPACES.*/
                public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "44", "X(44)"), @"");
                /*"     05 FILLER                       PIC X(11) VALUE        'NUM. IRB : '.*/
                public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "11", "X(11)"), @"NUM. IRB : ");
                /*"     05 NUMIRB-C07                   PIC ZZ.ZZZ.ZZZ.ZZ9.*/
                public IntBasis NUMIRB_C07 { get; set; } = new IntBasis(new PIC("9", "11", "ZZ.ZZZ.ZZZ.ZZ9."));
                /*"  03 CAB07A.*/
            }
            public SI0133B_CAB07A CAB07A { get; set; } = new SI0133B_CAB07A();
            public class SI0133B_CAB07A : VarBasis
            {
                /*"     05 FILLER                       PIC X(11) VALUE        'AG CENTR : '.*/
                public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "11", "X(11)"), @"AG CENTR : ");
                /*"     05 NUM-AG-CENT-C07A             PIC 9(004) VALUE ZEROS.*/
                public IntBasis NUM_AG_CENT_C07A { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"     05 FILLER                       PIC X(001) VALUE SPACES.*/
                public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"     05 AG-CENTR-C07A                PIC X(040) VALUE SPACES.*/
                public StringBasis AG_CENTR_C07A { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"     05 FILLER                       PIC X(002) VALUE SPACES.*/
                public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
                /*"     05 FILLER                       PIC X(019) VALUE SPACES.*/
                public StringBasis FILLER_40 { get; set; } = new StringBasis(new PIC("X", "19", "X(019)"), @"");
                /*"     05 FILLER                       PIC X(011) VALUE        'AG CTRT. : '.*/
                public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"AG CTRT. : ");
                /*"     05 NUM-AG-CTRT-C07A             PIC 9(004) VALUE ZEROS.*/
                public IntBasis NUM_AG_CTRT_C07A { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"     05 FILLER                       PIC X(001) VALUE SPACES.*/
                public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"     05 AG-CTRT-C07A                 PIC X(040) VALUE SPACES.*/
                public StringBasis AG_CTRT_C07A { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"  03 CAB08.*/
            }
            public SI0133B_CAB08 CAB08 { get; set; } = new SI0133B_CAB08();
            public class SI0133B_CAB08 : VarBasis
            {
                /*"     05 FILLER                       PIC X(11) VALUE        'SEGURADO : '.*/
                public StringBasis FILLER_43 { get; set; } = new StringBasis(new PIC("X", "11", "X(11)"), @"SEGURADO : ");
                /*"     05 NOME-SEGURADO-C08            PIC X(40) VALUE  SPACES.*/
                public StringBasis NOME_SEGURADO_C08 { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
                /*"     05 FILLER                       PIC X(01) VALUE  SPACES.*/
                public StringBasis FILLER_44 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
                /*"     05 FILLER                       PIC X(25) VALUE  SPACES.*/
                public StringBasis FILLER_45 { get; set; } = new StringBasis(new PIC("X", "25", "X(25)"), @"");
                /*"     05 FILLER                       PIC X(11) VALUE        'CPF/CGC  : '.*/
                public StringBasis FILLER_46 { get; set; } = new StringBasis(new PIC("X", "11", "X(11)"), @"CPF/CGC  : ");
                /*"     05  NUM-CGCCPF-C08              PIC X(16) VALUE  SPACES.*/
                public StringBasis NUM_CGCCPF_C08 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"");
                /*"     05  FILLER                      PIC X(52) VALUE  SPACES.*/
                public StringBasis FILLER_47 { get; set; } = new StringBasis(new PIC("X", "52", "X(52)"), @"");
                /*"  03 CAB10.*/
            }
            public SI0133B_CAB10 CAB10 { get; set; } = new SI0133B_CAB10();
            public class SI0133B_CAB10 : VarBasis
            {
                /*"     05 FILLER                       PIC X(99) VALUE SPACES.*/
                public StringBasis FILLER_48 { get; set; } = new StringBasis(new PIC("X", "99", "X(99)"), @"");
                /*"     05 FILLER                       PIC X(23) VALUE        'PERCENTUAL DE RESSEGURO'.*/
                public StringBasis FILLER_49 { get; set; } = new StringBasis(new PIC("X", "23", "X(23)"), @"PERCENTUAL DE RESSEGURO");
                /*"     05 PCTRES-C11                   PIC ZZZ9,99999 VALUE ZEROS.*/
                public DoubleBasis PCTRES_C11 { get; set; } = new DoubleBasis(new PIC("9", "4", "ZZZ9V99999"), 5);
                /*"  03 CAB11.*/
            }
            public SI0133B_CAB11 CAB11 { get; set; } = new SI0133B_CAB11();
            public class SI0133B_CAB11 : VarBasis
            {
                /*"     05 FILLER                       PIC X(11) VALUE        'CORRETOR : '.*/
                public StringBasis FILLER_50 { get; set; } = new StringBasis(new PIC("X", "11", "X(11)"), @"CORRETOR : ");
                /*"     05 NOMPDT-C10                   PIC X(40) VALUE  ZEROS.*/
                public StringBasis NOMPDT_C10 { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
                /*"     05 FILLER                       PIC X(48) VALUE  SPACES.*/
                public StringBasis FILLER_51 { get; set; } = new StringBasis(new PIC("X", "48", "X(48)"), @"");
                /*"     05 FILLER                       PIC X(23) VALUE        'PERCENTUAL DE COSSEGURO'.*/
                public StringBasis FILLER_52 { get; set; } = new StringBasis(new PIC("X", "23", "X(23)"), @"PERCENTUAL DE COSSEGURO");
                /*"     05 PCPARTIC-C11                 PIC ZZZ9,99999 VALUE ZEROS.*/
                public DoubleBasis PCPARTIC_C11 { get; set; } = new DoubleBasis(new PIC("9", "4", "ZZZ9V99999"), 5);
                /*"  03            CAB12.*/
            }
            public SI0133B_CAB12 CAB12 { get; set; } = new SI0133B_CAB12();
            public class SI0133B_CAB12 : VarBasis
            {
                /*"    05          FILLER              PIC X(26) VALUE                'MOVIMENTACOES NO PROCESSO:'.*/
                public StringBasis FILLER_53 { get; set; } = new StringBasis(new PIC("X", "26", "X(26)"), @"MOVIMENTACOES NO PROCESSO:");
                /*"    05          FILLER              PIC X(43) VALUE  SPACES.*/
                public StringBasis FILLER_54 { get; set; } = new StringBasis(new PIC("X", "43", "X(43)"), @"");
                /*"    05          BENEF-TIT1-CAB12    PIC X(14) VALUE  SPACES.*/
                public StringBasis BENEF_TIT1_CAB12 { get; set; } = new StringBasis(new PIC("X", "14", "X(14)"), @"");
                /*"    05          FILLER              PIC X(26) VALUE  SPACES.*/
                public StringBasis FILLER_55 { get; set; } = new StringBasis(new PIC("X", "26", "X(26)"), @"");
                /*"    05          BENEF-TIT2-CAB12    PIC X(21) VALUE  SPACES.*/
                public StringBasis BENEF_TIT2_CAB12 { get; set; } = new StringBasis(new PIC("X", "21", "X(21)"), @"");
                /*"  03     CAB-MOV.*/
            }
            public SI0133B_CAB_MOV CAB_MOV { get; set; } = new SI0133B_CAB_MOV();
            public class SI0133B_CAB_MOV : VarBasis
            {
                /*"    05   DESC-MOVIM-C13  PIC X(46)     VALUE SPACES.*/
                public StringBasis DESC_MOVIM_C13 { get; set; } = new StringBasis(new PIC("X", "46", "X(46)"), @"");
                /*"    05   VALOR-MOVIM-C13 PIC Z.ZZZ.ZZZ.ZZZ.ZZ9,99 VALUE ZEROS.*/
                public DoubleBasis VALOR_MOVIM_C13 { get; set; } = new DoubleBasis(new PIC("9", "13", "Z.ZZZ.ZZZ.ZZZ.ZZ9V99"), 2);
                /*"    05   FILLER  REDEFINES  VALOR-MOVIM-C13.*/
                private _REDEF_SI0133B_FILLER_56 _filler_56 { get; set; }
                public _REDEF_SI0133B_FILLER_56 FILLER_56
                {
                    get { _filler_56 = new _REDEF_SI0133B_FILLER_56(); _.Move(VALOR_MOVIM_C13, _filler_56); VarBasis.RedefinePassValue(VALOR_MOVIM_C13, _filler_56, VALOR_MOVIM_C13); _filler_56.ValueChanged += () => { _.Move(_filler_56, VALOR_MOVIM_C13); }; return _filler_56; }
                    set { VarBasis.RedefinePassValue(value, _filler_56, VALOR_MOVIM_C13); }
                }  //Redefines
                public class _REDEF_SI0133B_FILLER_56 : VarBasis
                {
                    /*"      07 VALOR-LIN-BENEF PIC X(20).*/
                    public StringBasis VALOR_LIN_BENEF { get; set; } = new StringBasis(new PIC("X", "20", "X(20)."), @"");
                    /*"    05   FILLER          PIC X(03)     VALUE SPACES.*/

                    public _REDEF_SI0133B_FILLER_56()
                    {
                        VALOR_LIN_BENEF.ValueChanged += OnValueChanged;
                    }

                }
                public StringBasis FILLER_57 { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"");
                /*"    05   NOME-BENEF-C13  PIC X(40)     VALUE SPACES.*/
                public StringBasis NOME_BENEF_C13 { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
                /*"    05   FILLER          PIC X(03)     VALUE SPACES.*/
                public StringBasis FILLER_58 { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"");
                /*"    05   PERC-BENEF-C13  PIC ZZZ,ZZ  VALUE ZEROS.*/
                public StringBasis PERC_BENEF_C13 { get; set; } = new StringBasis(new PIC("X", "0", "ZZZVZZ"), @"");
                /*"    05   FILLER          PIC X(04)     VALUE SPACES.*/
                public StringBasis FILLER_59 { get; set; } = new StringBasis(new PIC("X", "4", "X(04)"), @"");
                /*"    05   PTESCO-BNF-C13  PIC X(07)     VALUE SPACES.*/
                public StringBasis PTESCO_BNF_C13 { get; set; } = new StringBasis(new PIC("X", "7", "X(07)"), @"");
                /*"  03            CAB19.*/
            }
            public SI0133B_CAB19 CAB19 { get; set; } = new SI0133B_CAB19();
            public class SI0133B_CAB19 : VarBasis
            {
                /*"    05          FILLER              PIC X(69) VALUE               'ALTERACAO DE CAUSA'.*/
                public StringBasis FILLER_60 { get; set; } = new StringBasis(new PIC("X", "69", "X(69)"), @"ALTERACAO DE CAUSA");
                /*"    05          FILLER              PIC X(27) VALUE               'I   CODIGO VISTORIADOR'.*/
                public StringBasis FILLER_61 { get; set; } = new StringBasis(new PIC("X", "27", "X(27)"), @"I   CODIGO VISTORIADOR");
                /*"    05          VISTORIADOR-C19.*/
                public SI0133B_VISTORIADOR_C19 VISTORIADOR_C19 { get; set; } = new SI0133B_VISTORIADOR_C19();
                public class SI0133B_VISTORIADOR_C19 : VarBasis
                {
                    /*"      07        TAB-VIST-C19        OCCURS      4      TIMES.*/
                    public ListBasis<SI0133B_TAB_VIST_C19> TAB_VIST_C19 { get; set; } = new ListBasis<SI0133B_TAB_VIST_C19>(4);
                    public class SI0133B_TAB_VIST_C19 : VarBasis
                    {
                        /*"        09      CODPSVI-C19         PIC 999999.*/
                        public IntBasis CODPSVI_C19 { get; set; } = new IntBasis(new PIC("9", "6", "999999."));
                        /*"        09      FILLER              PIC X(03).*/
                        public StringBasis FILLER_62 { get; set; } = new StringBasis(new PIC("X", "3", "X(03)."), @"");
                        /*"  03            CAB20.*/
                    }
                }
            }
            public SI0133B_CAB20 CAB20 { get; set; } = new SI0133B_CAB20();
            public class SI0133B_CAB20 : VarBasis
            {
                /*"    05          FILLER              PIC X(01) VALUE  SPACES.*/
                public StringBasis FILLER_63 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
                /*"    05          FILLER              PIC X(21) VALUE                'ULTIMA MOVIMENTACAO: '.*/
                public StringBasis FILLER_64 { get; set; } = new StringBasis(new PIC("X", "21", "X(21)"), @"ULTIMA MOVIMENTACAO: ");
                /*"    05          CAB21-DIA           PIC 9(02) VALUE ZERO.*/
                public IntBasis CAB21_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"    05          FILLER              PIC X(01) VALUE '/'.*/
                public StringBasis FILLER_65 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"/");
                /*"    05          CAB21-MES           PIC 9(02) VALUE ZERO.*/
                public IntBasis CAB21_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"    05          FILLER              PIC X(01) VALUE '/'.*/
                public StringBasis FILLER_66 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"/");
                /*"    05          CAB21-ANO           PIC 9(04) VALUE ZERO.*/
                public IntBasis CAB21_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
                /*"    05          FILLER              PIC X(01) VALUE SPACES.*/
                public StringBasis FILLER_67 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
                /*"    05          CAB21-MOVIMEN       PIC X(35) VALUE ZERO.*/
                public StringBasis CAB21_MOVIMEN { get; set; } = new StringBasis(new PIC("X", "35", "X(35)"), @"");
                /*"    05          FILLER              PIC X(04) VALUE SPACES.*/
                public StringBasis FILLER_68 { get; set; } = new StringBasis(new PIC("X", "4", "X(04)"), @"");
                /*"    05          FILLER              PIC X(08) VALUE                ' VALOR: '.*/
                public StringBasis FILLER_69 { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @" VALOR: ");
                /*"    05          CAB21-VALOR         PIC ZZZ.ZZZ.ZZZ.ZZ9,99                                    VALUE ZEROS.*/
                public DoubleBasis CAB21_VALOR { get; set; } = new DoubleBasis(new PIC("9", "12", "ZZZ.ZZZ.ZZZ.ZZ9V99"), 2);
                /*"    05          FILLER              PIC X(12) VALUE SPACES.*/
                public StringBasis FILLER_70 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"");
                /*"    05          FILLER              PIC X(11) VALUE                ' ANALISTA: '.*/
                public StringBasis FILLER_71 { get; set; } = new StringBasis(new PIC("X", "11", "X(11)"), @" ANALISTA: ");
                /*"    05          CAB21-COD-USU       PIC X(08) VALUE SPACES.*/
                public StringBasis CAB21_COD_USU { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
                /*"    05          FILLER              PIC X(01) VALUE SPACES.*/
                public StringBasis FILLER_72 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
                /*"  03            CAB23.*/
            }
            public SI0133B_CAB23 CAB23 { get; set; } = new SI0133B_CAB23();
            public class SI0133B_CAB23 : VarBasis
            {
                /*"    05          FILLER              PIC X(41) VALUE                ' NOME DO FAVORECIDO'.*/
                public StringBasis FILLER_73 { get; set; } = new StringBasis(new PIC("X", "41", "X(41)"), @" NOME DO FAVORECIDO");
                /*"    05          FILLER              PIC X(44) VALUE                'TIPO FAVORECIDO     VALOR PAGTO  TIPO PAGTO '.*/
                public StringBasis FILLER_74 { get; set; } = new StringBasis(new PIC("X", "44", "X(44)"), @"TIPO FAVORECIDO     VALOR PAGTO  TIPO PAGTO ");
                /*"    05          FILLER              PIC X(46) VALUE                '   DATA PAGTO  FONTE PAGADORA  PROCESSO SCPJUD'*/
                public StringBasis FILLER_75 { get; set; } = new StringBasis(new PIC("X", "46", "X(46)"), @"   DATA PAGTO  FONTE PAGADORA  PROCESSO SCPJUD");
                /*"  03            DETALHE.*/
            }
            public SI0133B_DETALHE DETALHE { get; set; } = new SI0133B_DETALHE();
            public class SI0133B_DETALHE : VarBasis
            {
                /*"    05          FILLER              PIC X(01) VALUE SPACES.*/
                public StringBasis FILLER_76 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
                /*"    05          NOMFAV-DET          PIC X(40) VALUE SPACES.*/
                public StringBasis NOMFAV_DET { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
                /*"    05          FILLER              PIC X(03) VALUE SPACES.*/
                public StringBasis FILLER_77 { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"");
                /*"    05          TIPFAV-DET          PIC X(09) VALUE SPACES.*/
                public StringBasis TIPFAV_DET { get; set; } = new StringBasis(new PIC("X", "9", "X(09)"), @"");
                /*"    05          FILLER              PIC X(03) VALUE SPACES.*/
                public StringBasis FILLER_78 { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"");
                /*"    05          VAL-OP-DET          PIC Z.ZZZ.ZZZ.ZZZ,ZZ                                                VALUE ZEROS.*/
                public StringBasis VAL_OP_DET { get; set; } = new StringBasis(new PIC("X", "0", "Z.ZZZ.ZZZ.ZZZVZZ"), @"");
                /*"    05          FILLER              PIC X(02) VALUE SPACES.*/
                public StringBasis FILLER_79 { get; set; } = new StringBasis(new PIC("X", "2", "X(02)"), @"");
                /*"    05          TIPPAG-DET          PIC X(12) VALUE SPACES.*/
                public StringBasis TIPPAG_DET { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"");
                /*"    05          FILLER              PIC X(02) VALUE SPACES.*/
                public StringBasis FILLER_80 { get; set; } = new StringBasis(new PIC("X", "2", "X(02)"), @"");
                /*"    05          VENCTO-DET.*/
                public SI0133B_VENCTO_DET VENCTO_DET { get; set; } = new SI0133B_VENCTO_DET();
                public class SI0133B_VENCTO_DET : VarBasis
                {
                    /*"        10      VENCDD-DET          PIC X(02) VALUE SPACES.*/
                    public StringBasis VENCDD_DET { get; set; } = new StringBasis(new PIC("X", "2", "X(02)"), @"");
                    /*"        10      VENCB1-DET          PIC X(01) VALUE SPACES.*/
                    public StringBasis VENCB1_DET { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
                    /*"        10      VENCMM-DET          PIC X(02) VALUE SPACES.*/
                    public StringBasis VENCMM_DET { get; set; } = new StringBasis(new PIC("X", "2", "X(02)"), @"");
                    /*"        10      VENCB2-DET          PIC X(01) VALUE SPACES.*/
                    public StringBasis VENCB2_DET { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
                    /*"        10      VENCAA-DET          PIC X(04) VALUE SPACES.*/
                    public StringBasis VENCAA_DET { get; set; } = new StringBasis(new PIC("X", "4", "X(04)"), @"");
                    /*"    05          FILLER              PIC X(02) VALUE SPACES.*/
                }
                public StringBasis FILLER_81 { get; set; } = new StringBasis(new PIC("X", "2", "X(02)"), @"");
                /*"    05          FONPAG-DET          PIC X(15) VALUE SPACES.*/
                public StringBasis FONPAG_DET { get; set; } = new StringBasis(new PIC("X", "15", "X(15)"), @"");
                /*"    05          FILLER              PIC X(02) VALUE SPACES.*/
                public StringBasis FILLER_82 { get; set; } = new StringBasis(new PIC("X", "2", "X(02)"), @"");
                /*"    05          COD-PROC-JUR-DET    PIC X(15) VALUE SPACES.*/
                public StringBasis COD_PROC_JUR_DET { get; set; } = new StringBasis(new PIC("X", "15", "X(15)"), @"");
                /*"  03            CAB26.*/
            }
            public SI0133B_CAB26 CAB26 { get; set; } = new SI0133B_CAB26();
            public class SI0133B_CAB26 : VarBasis
            {
                /*"    05          FILLER              PIC X(30) VALUE                '------------------------'.*/
                public StringBasis FILLER_83 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"------------------------");
                /*"    05          FILLER              PIC X(30) VALUE                '---------------------------'.*/
                public StringBasis FILLER_84 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"---------------------------");
                /*"    05          FILLER              PIC X(30) VALUE                '------------------'.*/
                public StringBasis FILLER_85 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"------------------");
                /*"    05          FILLER              PIC X(30) VALUE                '------------------'.*/
                public StringBasis FILLER_86 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"------------------");
                /*"  03            CAB27.*/
            }
            public SI0133B_CAB27 CAB27 { get; set; } = new SI0133B_CAB27();
            public class SI0133B_CAB27 : VarBasis
            {
                /*"    05          FILLER              PIC X(30) VALUE                '    TESOURARIA '.*/
                public StringBasis FILLER_87 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"    TESOURARIA ");
                /*"    05          FILLER              PIC X(30) VALUE                '         SINISTRO     '.*/
                public StringBasis FILLER_88 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"         SINISTRO     ");
                /*"    05          FILLER              PIC X(30) VALUE                '     GERENCIA'.*/
                public StringBasis FILLER_89 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"     GERENCIA");
                /*"    05          FILLER              PIC X(30) VALUE                '     DIRETORIA'.*/
                public StringBasis FILLER_90 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"     DIRETORIA");
                /*"  03            CAB28.*/
            }
            public SI0133B_CAB28 CAB28 { get; set; } = new SI0133B_CAB28();
            public class SI0133B_CAB28 : VarBasis
            {
                /*"    05          FILLER              PIC X(05) VALUE SPACES.*/
                public StringBasis FILLER_91 { get; set; } = new StringBasis(new PIC("X", "5", "X(05)"), @"");
                /*"    05          FILLER              PIC X(36) VALUE                'FUNCEF DEPOSITO EM CONTA - BANCO -'.*/
                public StringBasis FILLER_92 { get; set; } = new StringBasis(new PIC("X", "36", "X(36)"), @"FUNCEF DEPOSITO EM CONTA - BANCO -");
                /*"    05          BANCO-DET           PIC 9(03).*/
                public IntBasis BANCO_DET { get; set; } = new IntBasis(new PIC("9", "3", "9(03)."));
                /*"    05          FILLER              PIC X(12) VALUE                ' AGENCIA -'.*/
                public StringBasis FILLER_93 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @" AGENCIA -");
                /*"    05          COD-AGENCIA-DET     PIC 9(05).*/
                public IntBasis COD_AGENCIA_DET { get; set; } = new IntBasis(new PIC("9", "5", "9(05)."));
                /*"    05          FILLER              PIC X(03) VALUE SPACES.*/
                public StringBasis FILLER_94 { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"");
                /*"    05          FILLER              PIC X(08) VALUE                ' OPR -'.*/
                public StringBasis FILLER_95 { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @" OPR -");
                /*"    05          OPERACAO-DET        PIC 9(04).*/
                public IntBasis OPERACAO_DET { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                /*"    05          FILLER              PIC X(10) VALUE      ' CONTA -'.*/
                public StringBasis FILLER_96 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @" CONTA -");
                /*"    05          CONTA-DET           PIC ----------9999.*/
                public IntBasis CONTA_DET { get; set; } = new IntBasis(new PIC("9", "14", "----------9999."));
                /*"  03            CAB30.*/
            }
            public SI0133B_CAB30 CAB30 { get; set; } = new SI0133B_CAB30();
            public class SI0133B_CAB30 : VarBasis
            {
                /*"    05          FILLER              PIC X(26) VALUE  SPACES.*/
                public StringBasis FILLER_97 { get; set; } = new StringBasis(new PIC("X", "26", "X(26)"), @"");
                /*"    05          FILLER              PIC X(27) VALUE               '** SITUACAO DA APOLICE **'.*/
                public StringBasis FILLER_98 { get; set; } = new StringBasis(new PIC("X", "27", "X(27)"), @"** SITUACAO DA APOLICE **");
                /*"    05          FILLER              PIC X(79) VALUE  SPACES.*/
                public StringBasis FILLER_99 { get; set; } = new StringBasis(new PIC("X", "79", "X(79)"), @"");
                /*"  03            CAB31.*/
            }
            public SI0133B_CAB31 CAB31 { get; set; } = new SI0133B_CAB31();
            public class SI0133B_CAB31 : VarBasis
            {
                /*"    05          FILLER              PIC X(05) VALUE  SPACES.*/
                public StringBasis FILLER_100 { get; set; } = new StringBasis(new PIC("X", "5", "X(05)"), @"");
                /*"    05          FILLER              PIC X(19) VALUE 'PARCELA'.*/
                public StringBasis FILLER_101 { get; set; } = new StringBasis(new PIC("X", "19", "X(19)"), @"PARCELA");
                /*"    05          FILLER              PIC X(19) VALUE 'SITUACAO'.*/
                public StringBasis FILLER_102 { get; set; } = new StringBasis(new PIC("X", "19", "X(19)"), @"SITUACAO");
                /*"    05          FILLER              PIC X(19) VALUE               'DATA VENCTO'.*/
                public StringBasis FILLER_103 { get; set; } = new StringBasis(new PIC("X", "19", "X(19)"), @"DATA VENCTO");
                /*"    05          FILLER              PIC X(10) VALUE               'DATA MOVTO'.*/
                public StringBasis FILLER_104 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"DATA MOVTO");
                /*"  03            CAB32.*/
            }
            public SI0133B_CAB32 CAB32 { get; set; } = new SI0133B_CAB32();
            public class SI0133B_CAB32 : VarBasis
            {
                /*"    05          FILLER              PIC X(06) VALUE  SPACES.*/
                public StringBasis FILLER_105 { get; set; } = new StringBasis(new PIC("X", "6", "X(06)"), @"");
                /*"    05          NRPARCEL-C32        PIC 9(02) VALUE  ZEROS.*/
                public IntBasis NRPARCEL_C32 { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"    05          FILLER              PIC X(01) VALUE '/'.*/
                public StringBasis FILLER_106 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"/");
                /*"    05          QTPARCEL-C32        PIC 9(02) VALUE  ZEROS.*/
                public IntBasis QTPARCEL_C32 { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"    05          FILLER              PIC X(13) VALUE  SPACES.*/
                public StringBasis FILLER_107 { get; set; } = new StringBasis(new PIC("X", "13", "X(13)"), @"");
                /*"    05          SITUACAO-C32        PIC X(09) VALUE  SPACES.*/
                public StringBasis SITUACAO_C32 { get; set; } = new StringBasis(new PIC("X", "9", "X(09)"), @"");
                /*"    05          FILLER              PIC X(12) VALUE  SPACES.*/
                public StringBasis FILLER_108 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"");
                /*"    05          DTVENCTO-C32        PIC X(10) VALUE  SPACES.*/
                public StringBasis DTVENCTO_C32 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
                /*"    05          FILLER              PIC X(07) VALUE  SPACES.*/
                public StringBasis FILLER_109 { get; set; } = new StringBasis(new PIC("X", "7", "X(07)"), @"");
                /*"    05          DTMOVTO-C32         PIC X(10) VALUE  SPACES.*/
                public StringBasis DTMOVTO_C32 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
                /*"  03            CONTINUA.*/
            }
            public SI0133B_CONTINUA CONTINUA { get; set; } = new SI0133B_CONTINUA();
            public class SI0133B_CONTINUA : VarBasis
            {
                /*"    05          FILLER              PIC X(66) VALUE  SPACES.*/
                public StringBasis FILLER_110 { get; set; } = new StringBasis(new PIC("X", "66", "X(66)"), @"");
                /*"    05          FILLER              PIC X(15) VALUE               'CONTINUA'.*/
                public StringBasis FILLER_111 { get; set; } = new StringBasis(new PIC("X", "15", "X(15)"), @"CONTINUA");
                /*"  03            TRACO.*/
            }
            public SI0133B_TRACO TRACO { get; set; } = new SI0133B_TRACO();
            public class SI0133B_TRACO : VarBasis
            {
                /*"    05          FILLER              PIC X(132) VALUE  ALL '-'.*/
                public StringBasis FILLER_112 { get; set; } = new StringBasis(new PIC("X", "132", "X(132)"), @"ALL");
                /*"  03            BRANCO.*/
            }
            public SI0133B_BRANCO BRANCO { get; set; } = new SI0133B_BRANCO();
            public class SI0133B_BRANCO : VarBasis
            {
                /*"    05          FILLER              PIC X(132) VALUE  SPACES.*/
                public StringBasis FILLER_113 { get; set; } = new StringBasis(new PIC("X", "132", "X(132)"), @"");
                /*"  03            SEP01.*/
            }
            public SI0133B_SEP01 SEP01 { get; set; } = new SI0133B_SEP01();
            public class SI0133B_SEP01 : VarBasis
            {
                /*"    05          FILLER              PIC  X(131) VALUE    ' $DJDE$ JDE=1VZ6,JDL=DFAULT,FEED=GAV2,END;'.*/
                public StringBasis FILLER_114 { get; set; } = new StringBasis(new PIC("X", "131", "X(131)"), @" $DJDE$ JDE=1VZ6,JDL=DFAULT,FEED=GAV2,END;");
                /*"  03            SEP02.*/
            }
            public SI0133B_SEP02 SEP02 { get; set; } = new SI0133B_SEP02();
            public class SI0133B_SEP02 : VarBasis
            {
                /*"    05          FILLER              PIC  X(001) VALUE ALL ' '.*/
                public StringBasis FILLER_115 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"ALL");
                /*"    05          FILLER              PIC  X(130) VALUE ALL '*'.*/
                public StringBasis FILLER_116 { get; set; } = new StringBasis(new PIC("X", "130", "X(130)"), @"ALL");
                /*"  03            SEP03.*/
            }
            public SI0133B_SEP03 SEP03 { get; set; } = new SI0133B_SEP03();
            public class SI0133B_SEP03 : VarBasis
            {
                /*"    05          FILLER              PIC  X(002) VALUE ' *'.*/
                public StringBasis FILLER_117 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @" *");
                /*"    05          FILLER              PIC  X(128) VALUE SPACES.*/
                public StringBasis FILLER_118 { get; set; } = new StringBasis(new PIC("X", "128", "X(128)"), @"");
                /*"    05          FILLER              PIC  X(001) VALUE '*'.*/
                public StringBasis FILLER_119 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"*");
                /*"  03            SEP04.*/
            }
            public SI0133B_SEP04 SEP04 { get; set; } = new SI0133B_SEP04();
            public class SI0133B_SEP04 : VarBasis
            {
                /*"    05          FILLER              PIC  X(002) VALUE ' *'.*/
                public StringBasis FILLER_120 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @" *");
                /*"    05          FILLER              PIC  X(009) VALUE SPACES.*/
                public StringBasis FILLER_121 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"");
                /*"    05          FILLER              PIC  X(037) VALUE                '*****   ATENCAO: ENVIAR OS RELATORIOS'.*/
                public StringBasis FILLER_122 { get; set; } = new StringBasis(new PIC("X", "37", "X(037)"), @"*****   ATENCAO: ENVIAR OS RELATORIOS");
                /*"    05          FILLER              PIC  X(042) VALUE                ' IMPRESSOS A SEGUIR PARA O SEGUINTE LOCAL:'.*/
                public StringBasis FILLER_123 { get; set; } = new StringBasis(new PIC("X", "42", "X(042)"), @" IMPRESSOS A SEGUIR PARA O SEGUINTE LOCAL:");
                /*"    05          FILLER              PIC  X(040) VALUE SPACES.*/
                public StringBasis FILLER_124 { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"    05          FILLER              PIC  X(001) VALUE '*'.*/
                public StringBasis FILLER_125 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"*");
                /*"  03            SEP05.*/
            }
            public SI0133B_SEP05 SEP05 { get; set; } = new SI0133B_SEP05();
            public class SI0133B_SEP05 : VarBasis
            {
                /*"    05          FILLER              PIC  X(002) VALUE ' *'.*/
                public StringBasis FILLER_126 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @" *");
                /*"    05          FILLER              PIC  X(009) VALUE SPACES.*/
                public StringBasis FILLER_127 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"");
                /*"    05          FILLER              PIC  X(020) VALUE                'ANALISTA..........: '.*/
                public StringBasis FILLER_128 { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"ANALISTA..........: ");
                /*"    05          COD-ANAL-SEP05      PIC  X(008) VALUE SPACES.*/
                public StringBasis COD_ANAL_SEP05 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
                /*"    05          FILLER              PIC  X(003) VALUE ' - '.*/
                public StringBasis FILLER_129 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" - ");
                /*"    05          NOME-ANAL-SEP05     PIC  X(035) VALUE SPACES.*/
                public StringBasis NOME_ANAL_SEP05 { get; set; } = new StringBasis(new PIC("X", "35", "X(035)"), @"");
                /*"    05          FILLER              PIC  X(053) VALUE SPACES.*/
                public StringBasis FILLER_130 { get; set; } = new StringBasis(new PIC("X", "53", "X(053)"), @"");
                /*"    05          FILLER              PIC  X(001) VALUE '*'.*/
                public StringBasis FILLER_131 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"*");
                /*"  03            SEP07.*/
            }
            public SI0133B_SEP07 SEP07 { get; set; } = new SI0133B_SEP07();
            public class SI0133B_SEP07 : VarBasis
            {
                /*"    05          FILLER              PIC  X(002) VALUE ' *'.*/
                public StringBasis FILLER_132 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @" *");
                /*"    05          FILLER              PIC  X(009) VALUE SPACES.*/
                public StringBasis FILLER_133 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"");
                /*"    05          FILLER              PIC  X(020) VALUE                'UNIDADE DE DESTINO: '.*/
                public StringBasis FILLER_134 { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"UNIDADE DE DESTINO: ");
                /*"    05          LOTACAO-SEP07       PIC  X(010) VALUE SPACES.*/
                public StringBasis LOTACAO_SEP07 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"    05          FILLER              PIC  X(003) VALUE SPACES.*/
                public StringBasis FILLER_135 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
                /*"    05          FILLER              PIC  X(086) VALUE SPACES.*/
                public StringBasis FILLER_136 { get; set; } = new StringBasis(new PIC("X", "86", "X(086)"), @"");
                /*"    05          FILLER              PIC  X(001) VALUE '*'.*/
                public StringBasis FILLER_137 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"*");
                /*"  03            SEP08.*/
            }
            public SI0133B_SEP08 SEP08 { get; set; } = new SI0133B_SEP08();
            public class SI0133B_SEP08 : VarBasis
            {
                /*"    05          FILLER              PIC  X(002) VALUE ' *'.*/
                public StringBasis FILLER_138 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @" *");
                /*"    05          FILLER              PIC  X(112) VALUE SPACES.*/
                public StringBasis FILLER_139 { get; set; } = new StringBasis(new PIC("X", "112", "X(112)"), @"");
                /*"    05          TP-OPERACAO-SEP08   PIC  X(016) VALUE SPACES.*/
                public StringBasis TP_OPERACAO_SEP08 { get; set; } = new StringBasis(new PIC("X", "16", "X(016)"), @"");
                /*"    05          FILLER              PIC  X(001) VALUE '*'.*/
                public StringBasis FILLER_140 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"*");
                /*"  03            SEP09.*/
            }
            public SI0133B_SEP09 SEP09 { get; set; } = new SI0133B_SEP09();
            public class SI0133B_SEP09 : VarBasis
            {
                /*"    05          FILLER              PIC  X(130) VALUE    ' $DJDE$ JDE=1VZ6,JDL=DFAULT,FEED=GAV1,END;'.*/
                public StringBasis FILLER_141 { get; set; } = new StringBasis(new PIC("X", "130", "X(130)"), @" $DJDE$ JDE=1VZ6,JDL=DFAULT,FEED=GAV1,END;");
                /*"  03  I                             PIC  9(04).*/
            }
            public IntBasis I { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
            /*"  03            WSQLCODE3           PIC S9(09) COMP.*/
            public IntBasis WSQLCODE3 { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
            /*"  03            WDATA.*/
            public SI0133B_WDATA WDATA { get; set; } = new SI0133B_WDATA();
            public class SI0133B_WDATA : VarBasis
            {
                /*"    05          WDATA-AA            PIC 9(04).*/
                public IntBasis WDATA_AA { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                /*"    05          FILLER              PIC X(01) VALUE '-'.*/
                public StringBasis FILLER_142 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
                /*"    05          WDATA-MM            PIC 9(02).*/
                public IntBasis WDATA_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"    05          FILLER              PIC X(01) VALUE '-'.*/
                public StringBasis FILLER_143 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
                /*"    05          WDATA-DD            PIC 9(02).*/
                public IntBasis WDATA_DD { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"  03            WDATA-R             REDEFINES WDATA                                    PIC X(10).*/
            }
            private _REDEF_StringBasis _wdata_r { get; set; }
            public _REDEF_StringBasis WDATA_R
            {
                get { _wdata_r = new _REDEF_StringBasis(new PIC("X", "10", "X(10).")); ; _.Move(WDATA, _wdata_r); VarBasis.RedefinePassValue(WDATA, _wdata_r, WDATA); _wdata_r.ValueChanged += () => { _.Move(_wdata_r, WDATA); }; return _wdata_r; }
                set { VarBasis.RedefinePassValue(value, _wdata_r, WDATA); }
            }  //Redefines
            /*"  03            WDATA-IMP.*/
            public SI0133B_WDATA_IMP WDATA_IMP { get; set; } = new SI0133B_WDATA_IMP();
            public class SI0133B_WDATA_IMP : VarBasis
            {
                /*"    05          WDIA-IMP            PIC 9(02).*/
                public IntBasis WDIA_IMP { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"    05          FILLER              PIC X(01)   VALUE '/'.*/
                public StringBasis FILLER_144 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"/");
                /*"    05          WMES-IMP            PIC 9(02).*/
                public IntBasis WMES_IMP { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"    05          FILLER              PIC X(01)   VALUE '/'.*/
                public StringBasis FILLER_145 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"/");
                /*"    05          WANO-IMP            PIC 9(04).*/
                public IntBasis WANO_IMP { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                /*"  03            WDATA1.*/
            }
            public SI0133B_WDATA1 WDATA1 { get; set; } = new SI0133B_WDATA1();
            public class SI0133B_WDATA1 : VarBasis
            {
                /*"    05          WDATA1-AA           PIC 9(04).*/
                public IntBasis WDATA1_AA { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                /*"    05          FILLER              PIC X(01) VALUE '-'.*/
                public StringBasis FILLER_146 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
                /*"    05          WDATA1-MM           PIC 9(02).*/
                public IntBasis WDATA1_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"    05          FILLER              PIC X(01) VALUE '-'.*/
                public StringBasis FILLER_147 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
                /*"    05          WDATA1-DD           PIC 9(02).*/
                public IntBasis WDATA1_DD { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"  03            WDATA1-R            REDEFINES WDATA1                                    PIC X(10).*/
            }
            private _REDEF_StringBasis _wdata1_r { get; set; }
            public _REDEF_StringBasis WDATA1_R
            {
                get { _wdata1_r = new _REDEF_StringBasis(new PIC("X", "10", "X(10).")); ; _.Move(WDATA1, _wdata1_r); VarBasis.RedefinePassValue(WDATA1, _wdata1_r, WDATA1); _wdata1_r.ValueChanged += () => { _.Move(_wdata1_r, WDATA1); }; return _wdata1_r; }
                set { VarBasis.RedefinePassValue(value, _wdata1_r, WDATA1); }
            }  //Redefines
            /*"  03 W-CHAVE-ACHOU-APOLCORRET  PIC X(03) VALUE 'NAO'.*/
            public StringBasis W_CHAVE_ACHOU_APOLCORRET { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"NAO");
            /*"  03            WS-DTCONV.*/
            public SI0133B_WS_DTCONV WS_DTCONV { get; set; } = new SI0133B_WS_DTCONV();
            public class SI0133B_WS_DTCONV : VarBasis
            {
                /*"    05          WS-A2CONV           PIC 9(04).*/
                public IntBasis WS_A2CONV { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                /*"    05          FILLER              PIC X(01) VALUE '-'.*/
                public StringBasis FILLER_148 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
                /*"    05          WS-MMCONV           PIC 9(02).*/
                public IntBasis WS_MMCONV { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"    05          FILLER              PIC X(01) VALUE '-'.*/
                public StringBasis FILLER_149 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
                /*"    05          WS-DDCONV           PIC 9(02).*/
                public IntBasis WS_DDCONV { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"  03            WHORA-CURR.*/
            }
            public SI0133B_WHORA_CURR WHORA_CURR { get; set; } = new SI0133B_WHORA_CURR();
            public class SI0133B_WHORA_CURR : VarBasis
            {
                /*"    05          WHORA-HH-CURR       PIC 9(02) VALUE ZEROS.*/
                public IntBasis WHORA_HH_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"    05          WHORA-MM-CURR       PIC 9(02) VALUE ZEROS.*/
                public IntBasis WHORA_MM_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"    05          WHORA-SS-CURR       PIC 9(02) VALUE ZEROS.*/
                public IntBasis WHORA_SS_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"  03         WDATA-CURR        PIC X(10)    VALUE SPACES.*/
            }
            public StringBasis WDATA_CURR { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
            /*"  03         FILLER            REDEFINES      WDATA-CURR.*/
            private _REDEF_SI0133B_FILLER_150 _filler_150 { get; set; }
            public _REDEF_SI0133B_FILLER_150 FILLER_150
            {
                get { _filler_150 = new _REDEF_SI0133B_FILLER_150(); _.Move(WDATA_CURR, _filler_150); VarBasis.RedefinePassValue(WDATA_CURR, _filler_150, WDATA_CURR); _filler_150.ValueChanged += () => { _.Move(_filler_150, WDATA_CURR); }; return _filler_150; }
                set { VarBasis.RedefinePassValue(value, _filler_150, WDATA_CURR); }
            }  //Redefines
            public class _REDEF_SI0133B_FILLER_150 : VarBasis
            {
                /*"    05       WDATA-AA-CURR     PIC 9(04).*/
                public IntBasis WDATA_AA_CURR { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                /*"    05       FILLER            PIC X(01).*/
                public StringBasis FILLER_151 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"    05       WDATA-MM-CURR     PIC 9(02).*/
                public IntBasis WDATA_MM_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"    05       FILLER            PIC X(01).*/
                public StringBasis FILLER_152 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"    05       WDATA-DD-CURR     PIC 9(02).*/
                public IntBasis WDATA_DD_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"  03            WDATA-CABEC.*/

                public _REDEF_SI0133B_FILLER_150()
                {
                    WDATA_AA_CURR.ValueChanged += OnValueChanged;
                    FILLER_151.ValueChanged += OnValueChanged;
                    WDATA_MM_CURR.ValueChanged += OnValueChanged;
                    FILLER_152.ValueChanged += OnValueChanged;
                    WDATA_DD_CURR.ValueChanged += OnValueChanged;
                }

            }
            public SI0133B_WDATA_CABEC WDATA_CABEC { get; set; } = new SI0133B_WDATA_CABEC();
            public class SI0133B_WDATA_CABEC : VarBasis
            {
                /*"    05          WDATA-DD-CABEC      PIC 9(02) VALUE ZEROS.*/
                public IntBasis WDATA_DD_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"    05          FILLER              PIC X(01) VALUE '/'.*/
                public StringBasis FILLER_153 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"/");
                /*"    05          WDATA-MM-CABEC      PIC 9(02) VALUE ZEROS.*/
                public IntBasis WDATA_MM_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"    05          FILLER              PIC X(01) VALUE '/'.*/
                public StringBasis FILLER_154 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"/");
                /*"    05          WDATA-AA-CABEC      PIC 9(04) VALUE ZEROS.*/
                public IntBasis WDATA_AA_CABEC { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
                /*"  03            WHORA-CABEC.*/
            }
            public SI0133B_WHORA_CABEC WHORA_CABEC { get; set; } = new SI0133B_WHORA_CABEC();
            public class SI0133B_WHORA_CABEC : VarBasis
            {
                /*"    05          WHORA-HH-CABEC      PIC 9(02) VALUE ZEROS.*/
                public IntBasis WHORA_HH_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"    05          FILLER              PIC X(01) VALUE ':'.*/
                public StringBasis FILLER_155 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @":");
                /*"    05          WHORA-MM-CABEC      PIC 9(02) VALUE ZEROS.*/
                public IntBasis WHORA_MM_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"    05          FILLER              PIC X(01) VALUE ':'.*/
                public StringBasis FILLER_156 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @":");
                /*"    05          WHORA-SS-CABEC      PIC 9(02) VALUE ZEROS.*/
                public IntBasis WHORA_SS_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"  03            WZEROS              PIC 9(03) VALUE 0.*/
            }
            public IntBasis WZEROS { get; set; } = new IntBasis(new PIC("9", "3", "9(03)"));
            /*"  03            WHUM                PIC 9(03) VALUE 1.*/
            public IntBasis WHUM { get; set; } = new IntBasis(new PIC("9", "3", "9(03)"), 1);
            /*"  03            WPARCELAS.*/
            public SI0133B_WPARCELAS WPARCELAS { get; set; } = new SI0133B_WPARCELAS();
            public class SI0133B_WPARCELAS : VarBasis
            {
                /*"   05           WNRPARCEL           PIC 9(02).*/
                public IntBasis WNRPARCEL { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"   05           FILLER              PIC X(01).*/
                public StringBasis FILLER_157 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"   05           WQTPARCEL           PIC 9(02).*/
                public IntBasis WQTPARCEL { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"   05           FILLER              PIC 9(02).*/
                public IntBasis FILLER_158 { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"  03            WTEM-PARCELA        PIC X(01) VALUE 'N'.*/
            }
            public StringBasis WTEM_PARCELA { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"N");
            /*"  03 WETAPA                         PIC X(01) VALUE 'N'.*/
            public StringBasis WETAPA { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"N");
            /*"  03            WS-VALPRI-AUX       PIC S9(15)V99 VALUE ZEROS.*/
            public DoubleBasis WS_VALPRI_AUX { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V99"), 2);
            /*"  03 WAUMENTO-RESERVA           PIC S9(15)V99 COMP-3 VALUE +0.*/
            public DoubleBasis WAUMENTO_RESERVA { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V99"), 2);
            /*"  03 WREDUCAO-RESERVA           PIC S9(15)V99 COMP-3 VALUE +0.*/
            public DoubleBasis WREDUCAO_RESERVA { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V99"), 2);
            /*"  03 WCALC-DIF-RESERVA          PIC S9(15)V99 COMP-3 VALUE +0.*/
            public DoubleBasis WCALC_DIF_RESERVA { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V99"), 2);
            /*"  03 WS-QUEBRA.*/
            public SI0133B_WS_QUEBRA WS_QUEBRA { get; set; } = new SI0133B_WS_QUEBRA();
            public class SI0133B_WS_QUEBRA : VarBasis
            {
                /*"     05 WS-PRODUTO-ANT          PIC 9(04) VALUE ZEROS.*/
                public IntBasis WS_PRODUTO_ANT { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
                /*"  03 VALPRI-C13                 PIC S9(15)V99 COMP-3 VALUE +0.*/
            }
            public DoubleBasis VALPRI_C13 { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V99"), 2);
            /*"  03 RESSARC-C13                PIC S9(15)V99 COMP-3 VALUE +0.*/
            public DoubleBasis RESSARC_C13 { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V99"), 2);
            /*"  03 TOTPAG-C14                 PIC S9(15)V99 COMP-3 VALUE +0.*/
            public DoubleBasis TOTPAG_C14 { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V99"), 2);
            /*"  03 SALVADOS-C14               PIC S9(15)V99 COMP-3 VALUE +0.*/
            public DoubleBasis SALVADOS_C14 { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V99"), 2);
            /*"  03 SDOADT-C15                 PIC S9(15)V99 COMP-3 VALUE +0.*/
            public DoubleBasis SDOADT_C15 { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V99"), 2);
            /*"  03 CANCELAMENTO-C15           PIC S9(15)V99 COMP-3 VALUE +0.*/
            public DoubleBasis CANCELAMENTO_C15 { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V99"), 2);
            /*"  03 DESPHON-C16                PIC S9(15)V99 COMP-3 VALUE +0.*/
            public DoubleBasis DESPHON_C16 { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V99"), 2);
            /*"  03 REATIVACAO-C16             PIC S9(15)V99 COMP-3 VALUE +0.*/
            public DoubleBasis REATIVACAO_C16 { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V99"), 2);
            /*"  03 SDORCP-C17                 PIC S9(15)V99 COMP-3 VALUE +0.*/
            public DoubleBasis SDORCP_C17 { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V99"), 2);
            /*"  03 RESERVA-C17                PIC S9(15)V99 COMP-3 VALUE +0.*/
            public DoubleBasis RESERVA_C17 { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V99"), 2);
            /*"  03 DESPREC-C18                PIC S9(15)V99 COMP-3 VALUE +0.*/
            public DoubleBasis DESPREC_C18 { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V99"), 2);
            /*"  03 PREMIO-IOF                 PIC S9(15)V99 COMP-3 VALUE +0.*/
            public DoubleBasis PREMIO_IOF { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V99"), 2);
            /*"  03 VALPRI-LIQ                 PIC S9(15)V99 COMP-3 VALUE +0.*/
            public DoubleBasis VALPRI_LIQ { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V99"), 2);
            /*"  03    OCORHIST-PREMIO  PIC S9(04)     VALUE  ZEROS COMP.*/
            public IntBasis OCORHIST_PREMIO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"  03    WS-FONTE-C04     PIC 9(03) VALUE  ZEROS.*/
            public IntBasis WS_FONTE_C04 { get; set; } = new IntBasis(new PIC("9", "3", "9(03)"));
            /*"  03    WS-PROTSINI-C04  PIC 9(06) VALUE  ZEROS.*/
            public IntBasis WS_PROTSINI_C04 { get; set; } = new IntBasis(new PIC("9", "6", "9(06)"));
            /*"  03    WS-DAC-C04       PIC 9(01) VALUE  ZEROS.*/
            public IntBasis WS_DAC_C04 { get; set; } = new IntBasis(new PIC("9", "1", "9(01)"));
            /*"  03      CAB-MOV-OCC    OCCURS  15 TIMES.*/
            public ListBasis<SI0133B_CAB_MOV_OCC> CAB_MOV_OCC { get; set; } = new ListBasis<SI0133B_CAB_MOV_OCC>(15);
            public class SI0133B_CAB_MOV_OCC : VarBasis
            {
                /*"    05    NOME-BENEF-OCC  PIC X(40).*/
                public StringBasis NOME_BENEF_OCC { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
                /*"    05 PERC-BENEF-OCC           PIC S9(04)V9(05) COMP-3 VALUE +0*/
                public DoubleBasis PERC_BENEF_OCC { get; set; } = new DoubleBasis(new PIC("S9", "4", "S9(04)V9(05)"), 5);
                /*"    05    PTESCO-BNF-OCC  PIC X(07).*/
                public StringBasis PTESCO_BNF_OCC { get; set; } = new StringBasis(new PIC("X", "7", "X(07)."), @"");
                /*"  03            WACHOU-THISTSIN     PIC X(01) VALUE 'N'.*/
            }
            public StringBasis WACHOU_THISTSIN { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"N");
            /*"  03            WS-CONT-LINHA       PIC 9(03) VALUE ZEROS.*/
            public IntBasis WS_CONT_LINHA { get; set; } = new IntBasis(new PIC("9", "3", "9(03)"));
            /*"  03            WS-CONT-PAGINA      PIC 9(03) VALUE ZEROS.*/
            public IntBasis WS_CONT_PAGINA { get; set; } = new IntBasis(new PIC("9", "3", "9(03)"));
            /*"  03            DETALHE-OCC      OCCURS  100000 TIMES.*/
            public ListBasis<SI0133B_DETALHE_OCC> DETALHE_OCC { get; set; } = new ListBasis<SI0133B_DETALHE_OCC>(100000);
            public class SI0133B_DETALHE_OCC : VarBasis
            {
                /*"    05          NOMFAV-OCC          PIC X(40).*/
                public StringBasis NOMFAV_OCC { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
                /*"    05          TIPFAV-OCC          PIC X(09).*/
                public StringBasis TIPFAV_OCC { get; set; } = new StringBasis(new PIC("X", "9", "X(09)."), @"");
                /*"    05          CODFAV-OCC          PIC S9(06).*/
                public IntBasis CODFAV_OCC { get; set; } = new IntBasis(new PIC("S9", "6", "S9(06)."));
                /*"    05 VAL-OP-OCC               PIC S9(15)V9(02) COMP-3 VALUE +0*/
                public DoubleBasis VAL_OP_OCC { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V9(02)"), 2);
                /*"    05          TIPPAG-OCC          PIC X(12).*/
                public StringBasis TIPPAG_OCC { get; set; } = new StringBasis(new PIC("X", "12", "X(12)."), @"");
                /*"    05          VENCTO-OCC.*/
                public SI0133B_VENCTO_OCC VENCTO_OCC { get; set; } = new SI0133B_VENCTO_OCC();
                public class SI0133B_VENCTO_OCC : VarBasis
                {
                    /*"        10      VENCDD-OCC          PIC X(02).*/
                    public StringBasis VENCDD_OCC { get; set; } = new StringBasis(new PIC("X", "2", "X(02)."), @"");
                    /*"        10      VENCB1-OCC          PIC X(01).*/
                    public StringBasis VENCB1_OCC { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                    /*"        10      VENCMM-OCC          PIC X(02).*/
                    public StringBasis VENCMM_OCC { get; set; } = new StringBasis(new PIC("X", "2", "X(02)."), @"");
                    /*"        10      VENCB2-OCC          PIC X(01).*/
                    public StringBasis VENCB2_OCC { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                    /*"        10      VENCAA-OCC          PIC X(04).*/
                    public StringBasis VENCAA_OCC { get; set; } = new StringBasis(new PIC("X", "4", "X(04)."), @"");
                    /*"    05          FONPAG-OCC          PIC X(15).*/
                }
                public StringBasis FONPAG_OCC { get; set; } = new StringBasis(new PIC("X", "15", "X(15)."), @"");
                /*"    05          JURID-OCC           PIC X(15).*/
                public StringBasis JURID_OCC { get; set; } = new StringBasis(new PIC("X", "15", "X(15)."), @"");
                /*"  03            WLIDOS-E            PIC 9(09) VALUE 0.*/
            }
            public IntBasis WLIDOS_E { get; set; } = new IntBasis(new PIC("9", "9", "9(09)"));
            /*"  03            WDUPLICADOS-E       PIC 9(09) VALUE 0.*/
            public IntBasis WDUPLICADOS_E { get; set; } = new IntBasis(new PIC("9", "9", "9(09)"));
            /*"  03            WDESPREZADOS-E      PIC 9(09) VALUE 0.*/
            public IntBasis WDESPREZADOS_E { get; set; } = new IntBasis(new PIC("9", "9", "9(09)"));
            /*"  03            WIMPRES-E           PIC 9(09) VALUE 0.*/
            public IntBasis WIMPRES_E { get; set; } = new IntBasis(new PIC("9", "9", "9(09)"));
            /*"  03            WLIDOS-R            PIC 9(09) VALUE 0.*/
            public IntBasis WLIDOS_R { get; set; } = new IntBasis(new PIC("9", "9", "9(09)"));
            /*"  03            WDUPLICADOS-R       PIC 9(09) VALUE 0.*/
            public IntBasis WDUPLICADOS_R { get; set; } = new IntBasis(new PIC("9", "9", "9(09)"));
            /*"  03            WDESPREZADOS-R      PIC 9(09) VALUE 0.*/
            public IntBasis WDESPREZADOS_R { get; set; } = new IntBasis(new PIC("9", "9", "9(09)"));
            /*"  03            WIMPRES-R           PIC 9(09) VALUE 0.*/
            public IntBasis WIMPRES_R { get; set; } = new IntBasis(new PIC("9", "9", "9(09)"));
            /*"  03            WFIM-TRELSIN        PIC X(01) VALUE 'N'.*/
            public StringBasis WFIM_TRELSIN { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"N");
            /*"  03            WFIM-TRELSIN1       PIC X(01) VALUE 'N'.*/
            public StringBasis WFIM_TRELSIN1 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"N");
            /*"  03            WFIM-THISTSIN       PIC X(01) VALUE 'N'.*/
            public StringBasis WFIM_THISTSIN { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"N");
            /*"  03            WFIM-TPARCELA       PIC X(01) VALUE 'N'.*/
            public StringBasis WFIM_TPARCELA { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"N");
            /*"  03            WFIM-SINISTRO       PIC X(01) VALUE 'N'.*/
            public StringBasis WFIM_SINISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"N");
            /*"  03            WFIM-RESERVA        PIC X(01) VALUE 'N'.*/
            public StringBasis WFIM_RESERVA { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"N");
            /*"  03            WFIM-BENEFIC        PIC X(01) VALUE 'N'.*/
            public StringBasis WFIM_BENEFIC { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"N");
            /*"  03            WFIM-THISTFAV       PIC X(01) VALUE 'N'.*/
            public StringBasis WFIM_THISTFAV { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"N");
            /*"  03            WS-IND-USU          PIC 9(01) VALUE ZERO.*/
            public IntBasis WS_IND_USU { get; set; } = new IntBasis(new PIC("9", "1", "9(01)"));
            /*"  03            WS-IND1             PIC 9(06) VALUE ZEROS.*/
            public IntBasis WS_IND1 { get; set; } = new IntBasis(new PIC("9", "6", "9(06)"));
            /*"  03            WS-IND2             PIC 9(06) VALUE ZEROS.*/
            public IntBasis WS_IND2 { get; set; } = new IntBasis(new PIC("9", "6", "9(06)"));
            /*"  03            WS-INDMAX1          PIC 9(03) VALUE ZEROS.*/
            public IntBasis WS_INDMAX1 { get; set; } = new IntBasis(new PIC("9", "3", "9(03)"));
            /*"  03            WS-INDMAX2          PIC 9(03) VALUE ZEROS.*/
            public IntBasis WS_INDMAX2 { get; set; } = new IntBasis(new PIC("9", "3", "9(03)"));
            /*"  03            WS-GD-CODUSU        PIC X(08) VALUE SPACES.*/
            public StringBasis WS_GD_CODUSU { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"  03            WSINISTRO-ANT       PIC 9(13) VALUE ZEROS.*/
            public IntBasis WSINISTRO_ANT { get; set; } = new IntBasis(new PIC("9", "13", "9(13)"));
            /*"  03            FILLER              REDEFINES  WSINISTRO-ANT.*/
            private _REDEF_SI0133B_FILLER_159 _filler_159 { get; set; }
            public _REDEF_SI0133B_FILLER_159 FILLER_159
            {
                get { _filler_159 = new _REDEF_SI0133B_FILLER_159(); _.Move(WSINISTRO_ANT, _filler_159); VarBasis.RedefinePassValue(WSINISTRO_ANT, _filler_159, WSINISTRO_ANT); _filler_159.ValueChanged += () => { _.Move(_filler_159, WSINISTRO_ANT); }; return _filler_159; }
                set { VarBasis.RedefinePassValue(value, _filler_159, WSINISTRO_ANT); }
            }  //Redefines
            public class _REDEF_SI0133B_FILLER_159 : VarBasis
            {
                /*"    05          WORGSIN-ANT         PIC 9(03).*/
                public IntBasis WORGSIN_ANT { get; set; } = new IntBasis(new PIC("9", "3", "9(03)."));
                /*"    05          WRMOSIN-ANT         PIC 9(02).*/
                public IntBasis WRMOSIN_ANT { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"    05          WNUMSIN-ANT         PIC 9(08).*/
                public IntBasis WNUMSIN_ANT { get; set; } = new IntBasis(new PIC("9", "8", "9(08)."));
                /*"  03            WMOVPCS-ANT         PIC S9(09) COMP VALUE +0.*/

                public _REDEF_SI0133B_FILLER_159()
                {
                    WORGSIN_ANT.ValueChanged += OnValueChanged;
                    WRMOSIN_ANT.ValueChanged += OnValueChanged;
                    WNUMSIN_ANT.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WMOVPCS_ANT { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
            /*"  03 W-APOL-SINI                     PIC S9(13) COMP-3 VALUE +0.*/
            public IntBasis W_APOL_SINI { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
            /*"  03            WSINI-AUX           PIC 9(13) VALUE ZEROS.*/
            public IntBasis WSINI_AUX { get; set; } = new IntBasis(new PIC("9", "13", "9(13)"));
            /*"  03            FILLER              REDEFINES  WSINI-AUX.*/
            private _REDEF_SI0133B_FILLER_160 _filler_160 { get; set; }
            public _REDEF_SI0133B_FILLER_160 FILLER_160
            {
                get { _filler_160 = new _REDEF_SI0133B_FILLER_160(); _.Move(WSINI_AUX, _filler_160); VarBasis.RedefinePassValue(WSINI_AUX, _filler_160, WSINI_AUX); _filler_160.ValueChanged += () => { _.Move(_filler_160, WSINI_AUX); }; return _filler_160; }
                set { VarBasis.RedefinePassValue(value, _filler_160, WSINI_AUX); }
            }  //Redefines
            public class _REDEF_SI0133B_FILLER_160 : VarBasis
            {
                /*"    05          WORGSIN-AUX         PIC 9(03).*/
                public IntBasis WORGSIN_AUX { get; set; } = new IntBasis(new PIC("9", "3", "9(03)."));
                /*"    05          WRMOSIN-AUX         PIC 9(02).*/
                public IntBasis WRMOSIN_AUX { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"    05          WNUMSIN-AUX         PIC 9(08).*/
                public IntBasis WNUMSIN_AUX { get; set; } = new IntBasis(new PIC("9", "8", "9(08)."));
                /*"  03         MEST-ORGSIN            PIC S9(04) COMP.*/

                public _REDEF_SI0133B_FILLER_160()
                {
                    WORGSIN_AUX.ValueChanged += OnValueChanged;
                    WRMOSIN_AUX.ValueChanged += OnValueChanged;
                    WNUMSIN_AUX.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis MEST_ORGSIN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"  03         RELSIN-ORGSIN          PIC S9(04) COMP.*/
            public IntBasis RELSIN_ORGSIN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"  03            WTABG-FONTES.*/
            public SI0133B_WTABG_FONTES WTABG_FONTES { get; set; } = new SI0133B_WTABG_FONTES();
            public class SI0133B_WTABG_FONTES : VarBasis
            {
                /*"    05          WTABG-FONTE-ZERA.*/
                public SI0133B_WTABG_FONTE_ZERA WTABG_FONTE_ZERA { get; set; } = new SI0133B_WTABG_FONTE_ZERA();
                public class SI0133B_WTABG_FONTE_ZERA : VarBasis
                {
                    /*"      07        FILLER              PIC S9(04) COMP VALUE +0.*/
                    public IntBasis FILLER_161 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
                    /*"      07        FILLER              PIC X(30) VALUE SPACES.*/
                    public StringBasis FILLER_162 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"");
                    /*"      07        WTABG-FONTEGRUPO.*/
                    public SI0133B_WTABG_FONTEGRUPO WTABG_FONTEGRUPO { get; set; } = new SI0133B_WTABG_FONTEGRUPO();
                    public class SI0133B_WTABG_FONTEGRUPO : VarBasis
                    {
                        /*"        09      WTABG-OCORREFONTE   OCCURS  100   TIMES                                    INDEXED  BY   I01.*/
                        public ListBasis<SI0133B_WTABG_OCORREFONTE> WTABG_OCORREFONTE { get; set; } = new ListBasis<SI0133B_WTABG_OCORREFONTE>(100);
                        public class SI0133B_WTABG_OCORREFONTE : VarBasis
                        {
                            /*"          11    WTABG-FONTE         PIC S9(04) COMP.*/
                            public IntBasis WTABG_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
                            /*"          11    WTABG-NOMEFTE       PIC X(30).*/
                            public StringBasis WTABG_NOMEFTE { get; set; } = new StringBasis(new PIC("X", "30", "X(30)."), @"");
                            /*"  03            WTABG-RAMOS.*/
                        }
                    }
                }
            }
            public SI0133B_WTABG_RAMOS WTABG_RAMOS { get; set; } = new SI0133B_WTABG_RAMOS();
            public class SI0133B_WTABG_RAMOS : VarBasis
            {
                /*"    05          WTABG-RAMO-ZERA.*/
                public SI0133B_WTABG_RAMO_ZERA WTABG_RAMO_ZERA { get; set; } = new SI0133B_WTABG_RAMO_ZERA();
                public class SI0133B_WTABG_RAMO_ZERA : VarBasis
                {
                    /*"      07        FILLER              PIC S9(04) COMP VALUE +0.*/
                    public IntBasis FILLER_163 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
                    /*"      07        FILLER              PIC X(40) VALUE SPACES.*/
                    public StringBasis FILLER_164 { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
                    /*"      07        WTABG-RAMOGRUPO.*/
                    public SI0133B_WTABG_RAMOGRUPO WTABG_RAMOGRUPO { get; set; } = new SI0133B_WTABG_RAMOGRUPO();
                    public class SI0133B_WTABG_RAMOGRUPO : VarBasis
                    {
                        /*"        09      WTABG-OCORRERAMO    OCCURS  200   TIMES                                    INDEXED  BY   I02.*/
                        public ListBasis<SI0133B_WTABG_OCORRERAMO> WTABG_OCORRERAMO { get; set; } = new ListBasis<SI0133B_WTABG_OCORRERAMO>(200);
                        public class SI0133B_WTABG_OCORRERAMO : VarBasis
                        {
                            /*"          11    WTABG-RAMO          PIC S9(04) COMP.*/
                            public IntBasis WTABG_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
                            /*"          11    WTABG-NOMERAMO      PIC X(40).*/
                            public StringBasis WTABG_NOMERAMO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
                            /*"  03            WTABG-CORRETORES.*/
                        }
                    }
                }
            }
            public SI0133B_WTABG_CORRETORES WTABG_CORRETORES { get; set; } = new SI0133B_WTABG_CORRETORES();
            public class SI0133B_WTABG_CORRETORES : VarBasis
            {
                /*"    05          WTABG-CORRET-ZERA.*/
                public SI0133B_WTABG_CORRET_ZERA WTABG_CORRET_ZERA { get; set; } = new SI0133B_WTABG_CORRET_ZERA();
                public class SI0133B_WTABG_CORRET_ZERA : VarBasis
                {
                    /*"      07        FILLER              PIC S9(04) COMP VALUE +0.*/
                    public IntBasis FILLER_165 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
                    /*"      07        FILLER              PIC S9(09) COMP VALUE +0.*/
                    public IntBasis FILLER_166 { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
                    /*"      07        FILLER              PIC X(40) VALUE SPACES.*/
                    public StringBasis FILLER_167 { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
                    /*"      07        WTABG-CORRETGRUPO.*/
                    public SI0133B_WTABG_CORRETGRUPO WTABG_CORRETGRUPO { get; set; } = new SI0133B_WTABG_CORRETGRUPO();
                    public class SI0133B_WTABG_CORRETGRUPO : VarBasis
                    {
                        /*"        09      WTABG-OCORRECORRET  OCCURS  400   TIMES                                    INDEXED  BY   I03.*/
                        public ListBasis<SI0133B_WTABG_OCORRECORRET> WTABG_OCORRECORRET { get; set; } = new ListBasis<SI0133B_WTABG_OCORRECORRET>(400);
                        public class SI0133B_WTABG_OCORRECORRET : VarBasis
                        {
                            /*"          11    WTABG-FONTE1        PIC S9(04) COMP.*/
                            public IntBasis WTABG_FONTE1 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
                            /*"          11    WTABG-CODPDT        PIC S9(09) COMP.*/
                            public IntBasis WTABG_CODPDT { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
                            /*"          11    WTABG-NOMPDT        PIC X(40).*/
                            public StringBasis WTABG_NOMPDT { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
                            /*"  03            WTABG-CAUSAS.*/
                        }
                    }
                }
            }
            public SI0133B_WTABG_CAUSAS WTABG_CAUSAS { get; set; } = new SI0133B_WTABG_CAUSAS();
            public class SI0133B_WTABG_CAUSAS : VarBasis
            {
                /*"    05          WTABG-CAUSA-ZERA.*/
                public SI0133B_WTABG_CAUSA_ZERA WTABG_CAUSA_ZERA { get; set; } = new SI0133B_WTABG_CAUSA_ZERA();
                public class SI0133B_WTABG_CAUSA_ZERA : VarBasis
                {
                    /*"      07        FILLER              PIC S9(04) COMP VALUE +0.*/
                    public IntBasis FILLER_168 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
                    /*"      07        FILLER              PIC S9(04) COMP VALUE +0.*/
                    public IntBasis FILLER_169 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
                    /*"      07        FILLER              PIC X(40) VALUE SPACES.*/
                    public StringBasis FILLER_170 { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
                    /*"      07        WTABG-CAUSAGRUPO.*/
                    public SI0133B_WTABG_CAUSAGRUPO WTABG_CAUSAGRUPO { get; set; } = new SI0133B_WTABG_CAUSAGRUPO();
                    public class SI0133B_WTABG_CAUSAGRUPO : VarBasis
                    {
                        /*"        09      WTABG-OCORRECAUSA   OCCURS  100   TIMES                                    INDEXED  BY   I04.*/
                        public ListBasis<SI0133B_WTABG_OCORRECAUSA> WTABG_OCORRECAUSA { get; set; } = new ListBasis<SI0133B_WTABG_OCORRECAUSA>(100);
                        public class SI0133B_WTABG_OCORRECAUSA : VarBasis
                        {
                            /*"          11    WTABG-RAMO-CAUSA    PIC S9(04) COMP.*/
                            public IntBasis WTABG_RAMO_CAUSA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
                            /*"          11    WTABG-CODCAU        PIC S9(04) COMP.*/
                            public IntBasis WTABG_CODCAU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
                            /*"          11    WTABG-DESCAU        PIC X(40).*/
                            public StringBasis WTABG_DESCAU { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
                            /*"  03            WQTD-MOEDA      PIC 9(13)V9(4)   VALUE ZEROS.*/
                        }
                    }
                }
            }
            public DoubleBasis WQTD_MOEDA { get; set; } = new DoubleBasis(new PIC("9", "13", "9(13)V9(4)"), 4);
            /*"  03 WC-VALOR                   PIC S9(13)V9(02) COMP-3 VALUE +0*/
            public DoubleBasis WC_VALOR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(02)"), 2);
            /*"  03             CH1-ON1           PIC 9(01)     VALUE ZEROS.*/
            public IntBasis CH1_ON1 { get; set; } = new IntBasis(new PIC("9", "1", "9(01)"));
            /*"  03             CH2-ON1           PIC 9(01)     VALUE ZEROS.*/
            public IntBasis CH2_ON1 { get; set; } = new IntBasis(new PIC("9", "1", "9(01)"));
            /*"  03             CH3-ON1           PIC 9(01)     VALUE ZEROS.*/
            public IntBasis CH3_ON1 { get; set; } = new IntBasis(new PIC("9", "1", "9(01)"));
            /*"03            WGEUNIMO-CODUNIMO  PIC 9(04).*/
        }
        public IntBasis WGEUNIMO_CODUNIMO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
        /*"  03        WABEND.*/
        public SI0133B_WABEND WABEND { get; set; } = new SI0133B_WABEND();
        public class SI0133B_WABEND : VarBasis
        {
            /*"    05      FILLER              PIC X(10) VALUE           ' SI0133B'.*/
            public StringBasis FILLER_171 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @" SI0133B");
            /*"    05      FILLER              PIC X(28) VALUE           ' *** ERRO  EXEC SQL  NUMERO '.*/
            public StringBasis FILLER_172 { get; set; } = new StringBasis(new PIC("X", "28", "X(28)"), @" *** ERRO  EXEC SQL  NUMERO ");
            /*"    05      WNR-EXEC-SQL        PIC X(03) VALUE '000'.*/
            public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"000");
            /*"    05      FILLER              PIC X(17) VALUE           ' *** PARAGRAFO = '.*/
            public StringBasis FILLER_173 { get; set; } = new StringBasis(new PIC("X", "17", "X(17)"), @" *** PARAGRAFO = ");
            /*"    05      PARAGRAFO           PIC X(30) VALUE SPACES.*/
            public StringBasis PARAGRAFO { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"");
            /*"    05      FILLER              PIC X(14) VALUE           '    SQLCODE = '.*/
            public StringBasis FILLER_174 { get; set; } = new StringBasis(new PIC("X", "14", "X(14)"), @"    SQLCODE = ");
            /*"    05      WSQLCODE            PIC ZZZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
            /*"    05      FILLER              PIC X(14) VALUE           '    SQLCODE1= '.*/
            public StringBasis FILLER_175 { get; set; } = new StringBasis(new PIC("X", "14", "X(14)"), @"    SQLCODE1= ");
            /*"    05      WSQLCODE1           PIC ZZZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLCODE1 { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
            /*"    05      FILLER              PIC X(14) VALUE           '    SQLCODE2= '.*/
            public StringBasis FILLER_176 { get; set; } = new StringBasis(new PIC("X", "14", "X(14)"), @"    SQLCODE2= ");
            /*"    05      WSQLCODE2           PIC ZZZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLCODE2 { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
            /*"01          LK-LINK.*/
        }
        public SI0133B_LK_LINK LK_LINK { get; set; } = new SI0133B_LK_LINK();
        public class SI0133B_LK_LINK : VarBasis
        {
            /*"  03        LK-RTCODE           PIC S9(04)   COMP VALUE +0.*/
            public IntBasis LK_RTCODE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"  03        LK-TAMANHO          PIC S9(04)   VALUE +40 COMP.*/
            public IntBasis LK_TAMANHO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"), +40);
            /*"  03        LK-TITULO           PIC  X(132)   VALUE  SPACES.*/
            public StringBasis LK_TITULO { get; set; } = new StringBasis(new PIC("X", "132", "X(132)"), @"");
        }


        public Copies.LBSI1001 LBSI1001 { get; set; } = new Copies.LBSI1001();
        public Dclgens.PRODUTO PRODUTO { get; set; } = new Dclgens.PRODUTO();
        public Dclgens.FORNECED FORNECED { get; set; } = new Dclgens.FORNECED();
        public Dclgens.BANCOS BANCOS { get; set; } = new Dclgens.BANCOS();
        public Dclgens.AGENCIAS AGENCIAS { get; set; } = new Dclgens.AGENCIAS();
        public Dclgens.GEOPERAC GEOPERAC { get; set; } = new Dclgens.GEOPERAC();
        public Dclgens.USUARIOS USUARIOS { get; set; } = new Dclgens.USUARIOS();
        public Dclgens.SI042 SI042 { get; set; } = new Dclgens.SI042();
        public SI0133B_V1RELATSINI V1RELATSINI { get; set; } = new SI0133B_V1RELATSINI();
        public SI0133B_V1BENEF V1BENEF { get; set; } = new SI0133B_V1BENEF();
        public SI0133B_V1HISTSINI V1HISTSINI { get; set; } = new SI0133B_V1HISTSINI();
        public SI0133B_V1HISTFAV V1HISTFAV { get; set; } = new SI0133B_V1HISTFAV();
        public SI0133B_V1HISTSIN2 V1HISTSIN2 { get; set; } = new SI0133B_V1HISTSIN2();
        public SI0133B_V1APOLCORRET V1APOLCORRET { get; set; } = new SI0133B_V1APOLCORRET();
        public SI0133B_RESERVA RESERVA { get; set; } = new SI0133B_RESERVA();
        public SI0133B_V1PARCELA V1PARCELA { get; set; } = new SI0133B_V1PARCELA();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string SI0133M1_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                SI0133M1.SetFile(SI0133M1_FILE_NAME_P);

                /*" -0- FLUXCONTROL_PERFORM M-000-000-PRINCIPAL-SECTION */

                M_000_000_PRINCIPAL_SECTION();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { CodigoRetorno = RETURN_CODE.Value };
            return Result;
        }

        [StopWatch]
        /*" M-000-000-PRINCIPAL-SECTION */
        private void M_000_000_PRINCIPAL_SECTION()
        {
            /*" -1470- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -1471- EXEC SQL WHENEVER SQLERROR GO TO 999-999-ROT-ERRO END-EXEC. */

            /*" -1472- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -1481- DISPLAY 'SI0133B VERSAO  024 - INICIOU PROCESSAMENTO EM ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2) ' ' */

            $"SI0133B VERSAO  024 - INICIOU PROCESSAMENTO EM {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss} "
            .Display();

            /*" -1483- DISPLAY '--------------------------------------------------' */
            _.Display($"--------------------------------------------------");

            /*" -1484- PERFORM 030-000-INICIO. */

            M_030_000_INICIO_SECTION();

            /*" -1485- PERFORM 060-000-LER-TSISTEMA. */

            M_060_000_LER_TSISTEMA_SECTION();

            /*" -1487- PERFORM 015-000-CABECALHOS. */

            M_015_000_CABECALHOS_SECTION();

            /*" -1489- PERFORM 090-000-CURSOR-TRELSIN-JOIN-E. */

            M_090_000_CURSOR_TRELSIN_JOIN_E_SECTION();

            /*" -1490- MOVE 'N' TO WFIM-TRELSIN. */
            _.Move("N", W.WFIM_TRELSIN);

            /*" -1491- PERFORM 095-000-LER-TRELSIN-JOIN-E. */

            M_095_000_LER_TRELSIN_JOIN_E_SECTION();

            /*" -1493- MOVE ZEROS TO WS-PRODUTO-ANT */
            _.Move(0, W.WS_QUEBRA.WS_PRODUTO_ANT);

            /*" -1494- IF WFIM-TRELSIN EQUAL 'S' */

            if (W.WFIM_TRELSIN == "S")
            {

                /*" -1495- DISPLAY 'SI0133B - NAO HOUVE SOLICITACAO P/ EMISSAO' */
                _.Display($"SI0133B - NAO HOUVE SOLICITACAO P/ EMISSAO");

                /*" -1502- GO TO 000-900-FIM. */

                M_000_900_FIM(); //GOTO
                return;
            }


            /*" -1503- PERFORM 120-000-PROCESSA UNTIL WFIM-TRELSIN EQUAL 'S' . */

            while (!(W.WFIM_TRELSIN == "S"))
            {

                M_120_000_PROCESSA_SECTION();
            }

            /*" -0- FLUXCONTROL_PERFORM M_000_900_FIM */

            M_000_900_FIM();

        }

        [StopWatch]
        /*" M-000-900-FIM */
        private void M_000_900_FIM(bool isPerform = false)
        {
            /*" -1511- PERFORM 900-000-FINALIZA. */

            M_900_000_FINALIZA_SECTION();

            /*" -1511- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_000_999_EXIT*/

        [StopWatch]
        /*" M-015-000-CABECALHOS-SECTION */
        private void M_015_000_CABECALHOS_SECTION()
        {
            /*" -1518- MOVE SIST-DTCURRENT TO WDATA-CURR */
            _.Move(SIST_DTCURRENT, W.WDATA_CURR);

            /*" -1519- ACCEPT WHORA-CURR FROM TIME */
            _.Move(_.AcceptDate("TIME"), W.WHORA_CURR);

            /*" -1520- MOVE WDATA-DD-CURR TO WDATA-DD-CABEC */
            _.Move(W.FILLER_150.WDATA_DD_CURR, W.WDATA_CABEC.WDATA_DD_CABEC);

            /*" -1521- MOVE WDATA-MM-CURR TO WDATA-MM-CABEC */
            _.Move(W.FILLER_150.WDATA_MM_CURR, W.WDATA_CABEC.WDATA_MM_CABEC);

            /*" -1522- MOVE WDATA-AA-CURR TO WDATA-AA-CABEC */
            _.Move(W.FILLER_150.WDATA_AA_CURR, W.WDATA_CABEC.WDATA_AA_CABEC);

            /*" -1523- MOVE WDATA-CABEC TO LC02-DATA */
            _.Move(W.WDATA_CABEC, W.CAB02.LC02_DATA);

            /*" -1524- MOVE WHORA-HH-CURR TO WHORA-HH-CABEC */
            _.Move(W.WHORA_CURR.WHORA_HH_CURR, W.WHORA_CABEC.WHORA_HH_CABEC);

            /*" -1525- MOVE WHORA-MM-CURR TO WHORA-MM-CABEC */
            _.Move(W.WHORA_CURR.WHORA_MM_CURR, W.WHORA_CABEC.WHORA_MM_CABEC);

            /*" -1526- MOVE WHORA-SS-CURR TO WHORA-SS-CABEC */
            _.Move(W.WHORA_CURR.WHORA_SS_CURR, W.WHORA_CABEC.WHORA_SS_CABEC);

            /*" -1527- MOVE WHORA-CABEC TO LC03-HORA */
            _.Move(W.WHORA_CABEC, W.CAB02B.LC03_HORA);

            /*" -1532- PERFORM M_015_000_CABECALHOS_DB_SELECT_1 */

            M_015_000_CABECALHOS_DB_SELECT_1();

            /*" -1534- MOVE V1EMPRESA-NOM-EMP TO LK-TITULO */
            _.Move(V1EMPRESA_NOM_EMP, LK_LINK.LK_TITULO);

            /*" -1536- CALL PROALN01 USING LK-LINK */
            _.Call(PROALN01, LK_LINK);

            /*" -1537- IF LK-RTCODE EQUAL ZEROS */

            if (LK_LINK.LK_RTCODE == 00)
            {

                /*" -1538- MOVE LK-TITULO TO LC01-EMPRESA */
                _.Move(LK_LINK.LK_TITULO, W.CAB01.LC01_EMPRESA);

                /*" -1539- ELSE */
            }
            else
            {


                /*" -1540- DISPLAY 'PROBLEMA CALL V1EMPRESA' */
                _.Display($"PROBLEMA CALL V1EMPRESA");

                /*" -1544- STOP RUN. */

                throw new GoBack();   // => STOP RUN.
            }


            /*" -1546- MOVE 1 TO PAG-C01. */
            _.Move(1, W.CAB01.PAG_C01);

            /*" -1546- MOVE 11 TO WS-INDMAX1. */
            _.Move(11, W.WS_INDMAX1);

        }

        [StopWatch]
        /*" M-015-000-CABECALHOS-DB-SELECT-1 */
        public void M_015_000_CABECALHOS_DB_SELECT_1()
        {
            /*" -1532- EXEC SQL SELECT NOME_EMPRESA INTO :V1EMPRESA-NOM-EMP FROM SEGUROS.V1EMPRESA WHERE COD_EMPRESA = 0 END-EXEC. */

            var m_015_000_CABECALHOS_DB_SELECT_1_Query1 = new M_015_000_CABECALHOS_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = M_015_000_CABECALHOS_DB_SELECT_1_Query1.Execute(m_015_000_CABECALHOS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1EMPRESA_NOM_EMP, V1EMPRESA_NOM_EMP);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_015_999_EXIT*/

        [StopWatch]
        /*" M-020-000-LIMPA-TAB-MOVIM-SECTION */
        private void M_020_000_LIMPA_TAB_MOVIM_SECTION()
        {
            /*" -1554- MOVE SPACES TO NOME-BENEF-OCC(WS-IND1) PTESCO-BNF-OCC(WS-IND1). */
            _.Move("", W.CAB_MOV_OCC[W.WS_IND1].NOME_BENEF_OCC, W.CAB_MOV_OCC[W.WS_IND1].PTESCO_BNF_OCC);

            /*" -1554- MOVE ZEROS TO PERC-BENEF-OCC(WS-IND1). */
            _.Move(0, W.CAB_MOV_OCC[W.WS_IND1].PERC_BENEF_OCC);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_020_000_EXIT*/

        [StopWatch]
        /*" M-025-000-LIMPA-TAB-FAVOR-SECTION */
        private void M_025_000_LIMPA_TAB_FAVOR_SECTION()
        {
            /*" -1567- MOVE SPACES TO NOMFAV-OCC(WS-IND1) VENCDD-OCC(WS-IND1) TIPFAV-OCC(WS-IND1) VENCMM-OCC(WS-IND1) TIPPAG-OCC(WS-IND1) VENCAA-OCC(WS-IND1) VENCB1-OCC(WS-IND1) VENCB2-OCC(WS-IND1) FONPAG-OCC(WS-IND1) JURID-OCC(WS-IND1). */
            _.Move("", W.DETALHE_OCC[W.WS_IND1].NOMFAV_OCC, W.DETALHE_OCC[W.WS_IND1].VENCTO_OCC.VENCDD_OCC, W.DETALHE_OCC[W.WS_IND1].TIPFAV_OCC, W.DETALHE_OCC[W.WS_IND1].VENCTO_OCC.VENCMM_OCC, W.DETALHE_OCC[W.WS_IND1].TIPPAG_OCC, W.DETALHE_OCC[W.WS_IND1].VENCTO_OCC.VENCAA_OCC, W.DETALHE_OCC[W.WS_IND1].VENCTO_OCC.VENCB1_OCC, W.DETALHE_OCC[W.WS_IND1].VENCTO_OCC.VENCB2_OCC, W.DETALHE_OCC[W.WS_IND1].FONPAG_OCC, W.DETALHE_OCC[W.WS_IND1].JURID_OCC);

            /*" -1567- MOVE ZEROS TO CODFAV-OCC(WS-IND1) VAL-OP-OCC(WS-IND1). */
            _.Move(0, W.DETALHE_OCC[W.WS_IND1].CODFAV_OCC, W.DETALHE_OCC[W.WS_IND1].VAL_OP_OCC);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_025_000_EXIT*/

        [StopWatch]
        /*" M-030-000-INICIO-SECTION */
        private void M_030_000_INICIO_SECTION()
        {
            /*" -1575- OPEN OUTPUT SI0133M1 */
            SI0133M1.Open(REG_SI0133M1);

            /*" -1576- INITIALIZE WTABG-CORRETGRUPO */
            _.Initialize(
                W.WTABG_CORRETORES.WTABG_CORRET_ZERA.WTABG_CORRETGRUPO
            );

            /*" -1577- INITIALIZE WTABG-FONTEGRUPO */
            _.Initialize(
                W.WTABG_FONTES.WTABG_FONTE_ZERA.WTABG_FONTEGRUPO
            );

            /*" -1578- INITIALIZE WTABG-RAMOGRUPO */
            _.Initialize(
                W.WTABG_RAMOS.WTABG_RAMO_ZERA.WTABG_RAMOGRUPO
            );

            /*" -1579- INITIALIZE WTABG-CAUSAGRUPO. */
            _.Initialize(
                W.WTABG_CAUSAS.WTABG_CAUSA_ZERA.WTABG_CAUSAGRUPO
            );

            /*" -1579- INITIALIZE WLIDOS-E. */
            _.Initialize(
                W.WLIDOS_E
            );

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_030_999_EXIT*/

        [StopWatch]
        /*" M-060-000-LER-TSISTEMA-SECTION */
        private void M_060_000_LER_TSISTEMA_SECTION()
        {
            /*" -1592- MOVE '001' TO WNR-EXEC-SQL. */
            _.Move("001", WABEND.WNR_EXEC_SQL);

            /*" -1597- PERFORM M_060_000_LER_TSISTEMA_DB_SELECT_1 */

            M_060_000_LER_TSISTEMA_DB_SELECT_1();

            /*" -1602- DISPLAY 'SIST-DTMOVABE = ' SIST-DTMOVABE */
            _.Display($"SIST-DTMOVABE = {SIST_DTMOVABE}");

            /*" -1603- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1604- DISPLAY 'SI0133B - NAO CONSTA REGISTRO NA TSISTEMA' */
                _.Display($"SI0133B - NAO CONSTA REGISTRO NA TSISTEMA");

                /*" -1604- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-060-000-LER-TSISTEMA-DB-SELECT-1 */
        public void M_060_000_LER_TSISTEMA_DB_SELECT_1()
        {
            /*" -1597- EXEC SQL SELECT DTMOVABE, CURRENT DATE INTO :SIST-DTMOVABE, :SIST-DTCURRENT FROM SEGUROS.V1SISTEMA WHERE IDSISTEM = 'SI' END-EXEC. */

            var m_060_000_LER_TSISTEMA_DB_SELECT_1_Query1 = new M_060_000_LER_TSISTEMA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = M_060_000_LER_TSISTEMA_DB_SELECT_1_Query1.Execute(m_060_000_LER_TSISTEMA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SIST_DTMOVABE, SIST_DTMOVABE);
                _.Move(executed_1.SIST_DTCURRENT, SIST_DTCURRENT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_060_999_EXIT*/

        [StopWatch]
        /*" M-090-000-CURSOR-TRELSIN-JOIN-E-SECTION */
        private void M_090_000_CURSOR_TRELSIN_JOIN_E_SECTION()
        {
            /*" -1612- MOVE '002' TO WNR-EXEC-SQL. */
            _.Move("002", WABEND.WNR_EXEC_SQL);

            /*" -1686- PERFORM M_090_000_CURSOR_TRELSIN_JOIN_E_DB_DECLARE_1 */

            M_090_000_CURSOR_TRELSIN_JOIN_E_DB_DECLARE_1();

            /*" -1698- PERFORM M_090_000_CURSOR_TRELSIN_JOIN_E_DB_OPEN_1 */

            M_090_000_CURSOR_TRELSIN_JOIN_E_DB_OPEN_1();

        }

        [StopWatch]
        /*" M-090-000-CURSOR-TRELSIN-JOIN-E-DB-DECLARE-1 */
        public void M_090_000_CURSOR_TRELSIN_JOIN_E_DB_DECLARE_1()
        {
            /*" -1686- EXEC SQL DECLARE V1RELATSINI CURSOR FOR SELECT R.NUM_APOL_SINISTRO, R.DTMOVTO, R.OPERACAO, R.OCORHIST, R.CODPSVI, R.CODUSU, M.MOVPCSAT, M.TIPREG, M.NUM_APOLICE, M.NRENDOS, M.NRCERTIF, M.DIGCERT, M.IDTPSEGU, M.DATCMD, M.DATTEC, M.DATORR, M.FONTE, M.DAC, M.PCPARTIC, M.PCTRES, M.TOTPAGBT, M.TOTDSABT, M.TOTHONBT, M.TOTRSDBT, M.SDORCPBT, M.SDOADTBT, M.CODCAU, M.PROTSINI, M.CODSUBES, M.OCORHIST, M.COD_MOEDA_SINI, M.NUMIRB, M.CODPRODU, M.RAMO, P.DESCR_PRODUTO FROM SEGUROS.V1HISTSINI R, SEGUROS.V1MESTSINI M, SEGUROS.GE_OPERACAO O, SEGUROS.PRODUTO P WHERE R.NUM_APOL_SINISTRO = M.NUM_APOL_SINISTRO AND R.DTMOVTO = :SIST-DTMOVABE AND M.TIPREG <> '0' AND (NOM_PROGRAMA <> ( 'SI3025B' ) OR NOM_PROGRAMA IS NULL) AND ( (M.RAMO IN ( 61 , 65 , 68 )) OR (M.RAMO = 66 AND (R.NOM_PROGRAMA NOT IN ( 'SI0600B' , 'SI0601B' , 'SI0602B' ) OR R.NOM_PROGRAMA IS NULL) ) ) AND O.IDE_SISTEMA = 'SI' AND R.OPERACAO = O.COD_OPERACAO AND R.CODUSU <> 'CAPAL114' AND O.FUNCAO_OPERACAO IN ( 'PRE' , 'DMOV' , 'HMOV' , 'JPIND' , 'JBDES' , 'JBHON' , 'JCDES' , 'JCHON' , 'JEDES' , 'JEHON' , 'JPDES' , 'JPHON' ) AND M.CODPRODU = P.COD_PRODUTO ORDER BY R.CODUSU, M.NUM_APOL_SINISTRO, M.CODPRODU END-EXEC. */
            V1RELATSINI = new SI0133B_V1RELATSINI(true);
            string GetQuery_V1RELATSINI()
            {
                var query = @$"SELECT R.NUM_APOL_SINISTRO
							, 
							R.DTMOVTO
							, 
							R.OPERACAO
							, R.OCORHIST
							, 
							R.CODPSVI
							, 
							R.CODUSU
							, 
							M.MOVPCSAT
							, 
							M.TIPREG
							, 
							M.NUM_APOLICE
							, 
							M.NRENDOS
							, 
							M.NRCERTIF
							, M.DIGCERT
							, 
							M.IDTPSEGU
							, 
							M.DATCMD
							, 
							M.DATTEC
							, 
							M.DATORR
							, M.FONTE
							, 
							M.DAC
							, M.PCPARTIC
							, 
							M.PCTRES
							, M.TOTPAGBT
							, 
							M.TOTDSABT
							, M.TOTHONBT
							, 
							M.TOTRSDBT
							, M.SDORCPBT
							, 
							M.SDOADTBT
							, M.CODCAU
							, 
							M.PROTSINI
							, M.CODSUBES
							, 
							M.OCORHIST
							, 
							M.COD_MOEDA_SINI
							, 
							M.NUMIRB
							, 
							M.CODPRODU
							, 
							M.RAMO
							, 
							P.DESCR_PRODUTO 
							FROM SEGUROS.V1HISTSINI R
							, 
							SEGUROS.V1MESTSINI M
							, 
							SEGUROS.GE_OPERACAO O
							, 
							SEGUROS.PRODUTO P 
							WHERE R.NUM_APOL_SINISTRO = M.NUM_APOL_SINISTRO 
							AND R.DTMOVTO = '{SIST_DTMOVABE}' 
							AND M.TIPREG <> '0' 
							AND (NOM_PROGRAMA <> ( 'SI3025B' ) 
							OR NOM_PROGRAMA IS NULL) 
							AND ( (M.RAMO IN ( 61
							, 65
							, 68 )) 
							OR 
							(M.RAMO = 66 AND (R.NOM_PROGRAMA NOT IN ( 'SI0600B'
							, 
							'SI0601B'
							, 'SI0602B' ) 
							OR R.NOM_PROGRAMA IS NULL) 
							) 
							) 
							AND O.IDE_SISTEMA = 'SI' 
							AND R.OPERACAO = O.COD_OPERACAO 
							AND R.CODUSU <> 'CAPAL114' 
							AND O.FUNCAO_OPERACAO IN ( 'PRE'
							, 'DMOV'
							, 'HMOV'
							, 'JPIND'
							, 
							'JBDES'
							, 'JBHON'
							, 'JCDES'
							, 
							'JCHON'
							, 'JEDES'
							, 'JEHON'
							, 
							'JPDES'
							, 'JPHON' ) 
							AND M.CODPRODU = P.COD_PRODUTO 
							ORDER BY R.CODUSU
							, M.NUM_APOL_SINISTRO
							, M.CODPRODU";

                return query;
            }
            V1RELATSINI.GetQueryEvent += GetQuery_V1RELATSINI;

        }

        [StopWatch]
        /*" M-090-000-CURSOR-TRELSIN-JOIN-E-DB-OPEN-1 */
        public void M_090_000_CURSOR_TRELSIN_JOIN_E_DB_OPEN_1()
        {
            /*" -1698- EXEC SQL OPEN V1RELATSINI END-EXEC. */

            V1RELATSINI.Open();

        }

        [StopWatch]
        /*" M-140-000-BENEFICIARIOS-DB-DECLARE-1 */
        public void M_140_000_BENEFICIARIOS_DB_DECLARE_1()
        {
            /*" -2420- EXEC SQL DECLARE V1BENEF CURSOR FOR SELECT NOME_BENEFICIARIO, GRAU_PARENTESCO, PCT_PART_BENEFICIA FROM SEGUROS.V1BENEFICIA T1 WHERE NUM_APOLICE = :MEST-NUM-APOL AND COD_SUBGRUPO = :MEST-CODSUBES AND NUM_CERTIFICADO = :MEST-NRCERTIF AND DATA_TERVIGENCIA = '1999-12-31' ORDER BY PCT_PART_BENEFICIA DESC END-EXEC. */
            V1BENEF = new SI0133B_V1BENEF(true);
            string GetQuery_V1BENEF()
            {
                var query = @$"SELECT NOME_BENEFICIARIO
							, 
							GRAU_PARENTESCO
							, 
							PCT_PART_BENEFICIA 
							FROM SEGUROS.V1BENEFICIA T1 
							WHERE 
							NUM_APOLICE = '{MEST_NUM_APOL}' AND 
							COD_SUBGRUPO = '{MEST_CODSUBES}' AND 
							NUM_CERTIFICADO = '{MEST_NRCERTIF}' AND 
							DATA_TERVIGENCIA = '1999-12-31' 
							ORDER BY PCT_PART_BENEFICIA DESC";

                return query;
            }
            V1BENEF.GetQueryEvent += GetQuery_V1BENEF;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_090_999_EXIT*/

        [StopWatch]
        /*" M-095-000-LER-TRELSIN-JOIN-E-SECTION */
        private void M_095_000_LER_TRELSIN_JOIN_E_SECTION()
        {
            /*" -1706- MOVE '003' TO WNR-EXEC-SQL. */
            _.Move("003", WABEND.WNR_EXEC_SQL);

            /*" -1732- PERFORM M_095_000_LER_TRELSIN_JOIN_E_DB_FETCH_1 */

            M_095_000_LER_TRELSIN_JOIN_E_DB_FETCH_1();

            /*" -1737- DISPLAY 'SQLCODE JOIN RELSIN ......' SQLCODE ' CODPSI: ' RELSIN-CODPSI */

            $"SQLCODE JOIN RELSIN ......{DB.SQLCODE} CODPSI: {RELSIN_CODPSI}"
            .Display();

            /*" -1738- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1738- PERFORM M_095_000_LER_TRELSIN_JOIN_E_DB_CLOSE_1 */

                M_095_000_LER_TRELSIN_JOIN_E_DB_CLOSE_1();

                /*" -1740- DISPLAY 'FIM ARQUIVO ' WLIDOS-E */
                _.Display($"FIM ARQUIVO {W.WLIDOS_E}");

                /*" -1741- DISPLAY 'SIST-DTMOVABE ' SIST-DTMOVABE */
                _.Display($"SIST-DTMOVABE {SIST_DTMOVABE}");

                /*" -1742- MOVE 'S' TO WFIM-TRELSIN */
                _.Move("S", W.WFIM_TRELSIN);

                /*" -1743- ELSE */
            }
            else
            {


                /*" -1744- ADD 1 TO WLIDOS-E */
                W.WLIDOS_E.Value = W.WLIDOS_E + 1;

                /*" -1746- IF WMOVPCS-ANT EQUAL RELSIN-MOVPCS AND W-APOL-SINI EQUAL RELSIN-APOL-SINI */

                if (W.WMOVPCS_ANT == RELSIN_MOVPCS && W.W_APOL_SINI == RELSIN_APOL_SINI)
                {

                    /*" -1747- ADD 1 TO WDUPLICADOS-E */
                    W.WDUPLICADOS_E.Value = W.WDUPLICADOS_E + 1;

                    /*" -1748- GO TO 095-000-LER-TRELSIN-JOIN-E */
                    new Task(() => M_095_000_LER_TRELSIN_JOIN_E_SECTION()).RunSynchronously(); //GOTO
                    return;//Recursividade detectada, cuidado...

                    /*" -1749- ELSE */
                }
                else
                {


                    /*" -1750- MOVE RELSIN-MOVPCS TO WMOVPCS-ANT */
                    _.Move(RELSIN_MOVPCS, W.WMOVPCS_ANT);

                    /*" -1751- MOVE RELSIN-APOL-SINI TO W-APOL-SINI */
                    _.Move(RELSIN_APOL_SINI, W.W_APOL_SINI);

                    /*" -1752- MOVE RELSIN-APOL-SINI TO WSINI-AUX */
                    _.Move(RELSIN_APOL_SINI, W.WSINI_AUX);

                    /*" -1753- MOVE WRMOSIN-AUX TO MEST-RAMO */
                    _.Move(W.FILLER_160.WRMOSIN_AUX, MEST_RAMO);

                    /*" -1754- PERFORM 650-000-ACERTA-VALORES */

                    M_650_000_ACERTA_VALORES_SECTION();

                    /*" -1755- MOVE RELSIN-APOL-SINI TO SINISTRO-C03 */
                    _.Move(RELSIN_APOL_SINI, W.CAB03.SINISTRO_C03);

                    /*" -1756- MOVE RELSIN-MOVPCS TO MOVPCS-C02 */
                    _.Move(RELSIN_MOVPCS, W.CAB02.MOVPCS_C02);

                    /*" -1757- MOVE MEST-FONTE TO WS-FONTE-C04 */
                    _.Move(MEST_FONTE, W.WS_FONTE_C04);

                    /*" -1758- MOVE MEST-PROTSINI TO WS-PROTSINI-C04 */
                    _.Move(MEST_PROTSINI, W.WS_PROTSINI_C04);

                    /*" -1759- MOVE MEST-DAC TO WS-DAC-C04 */
                    _.Move(MEST_DAC, W.WS_DAC_C04);

                    /*" -1760- MOVE MEST-NUM-APOL TO APOLICE-C05 */
                    _.Move(MEST_NUM_APOL, W.CAB05.APOLICE_C05);

                    /*" -1761- MOVE MEST-DATORR TO WDATA-R */
                    _.Move(MEST_DATORR, W.WDATA_R);

                    /*" -1762- MOVE WDATA-DD TO WDIA-IMP */
                    _.Move(W.WDATA.WDATA_DD, W.WDATA_IMP.WDIA_IMP);

                    /*" -1763- MOVE WDATA-MM TO WMES-IMP */
                    _.Move(W.WDATA.WDATA_MM, W.WDATA_IMP.WMES_IMP);

                    /*" -1764- MOVE WDATA-AA TO WANO-IMP */
                    _.Move(W.WDATA.WDATA_AA, W.WDATA_IMP.WANO_IMP);

                    /*" -1765- MOVE WDATA-IMP TO DATORR-C03 */
                    _.Move(W.WDATA_IMP, W.CAB03.DATORR_C03);

                    /*" -1766- MOVE MEST-DATCMD TO WDATA-R */
                    _.Move(MEST_DATCMD, W.WDATA_R);

                    /*" -1767- MOVE WDATA-DD TO WDIA-IMP */
                    _.Move(W.WDATA.WDATA_DD, W.WDATA_IMP.WDIA_IMP);

                    /*" -1768- MOVE WDATA-MM TO WMES-IMP */
                    _.Move(W.WDATA.WDATA_MM, W.WDATA_IMP.WMES_IMP);

                    /*" -1769- MOVE WDATA-AA TO WANO-IMP */
                    _.Move(W.WDATA.WDATA_AA, W.WDATA_IMP.WANO_IMP);

                    /*" -1771- MOVE WDATA-IMP TO DTCOMUN-C04 */
                    _.Move(W.WDATA_IMP, W.CAB04.DTCOMUN_C04);

                    /*" -1772- MOVE MEST-NUMIRB TO NUMIRB-C07 */
                    _.Move(MEST_NUMIRB, W.CAB07.NUMIRB_C07);

                    /*" -1773- MOVE MEST-PCTRES TO PCTRES-C11 */
                    _.Move(MEST_PCTRES, W.CAB10.PCTRES_C11);

                    /*" -1775- MOVE 0 TO SDORCP-C17 RESERVA-C17 DESPREC-C18. */
                    _.Move(0, W.SDORCP_C17, W.RESERVA_C17, W.DESPREC_C18);
                }

            }


        }

        [StopWatch]
        /*" M-095-000-LER-TRELSIN-JOIN-E-DB-FETCH-1 */
        public void M_095_000_LER_TRELSIN_JOIN_E_DB_FETCH_1()
        {
            /*" -1732- EXEC SQL FETCH V1RELATSINI INTO :RELSIN-APOL-SINI, :RELSIN-DTMOVTO, :RELSIN-OPERACAO, :RELSIN-OCORHIST, :RELSIN-CODPSI, :RELSIN-CODUSU, :RELSIN-MOVPCS, :MEST-TIPREG, :MEST-NUM-APOL, :MEST-NRENDOS, :MEST-NRCERTIF, :MEST-DIGCERT, :MEST-IDTPSEGU, :MEST-DATCMD, :MEST-DATTEC, :MEST-DATORR, :MEST-FONTE, :MEST-DAC, :MEST-PCPARTIC, :MEST-PCTRES, :MEST-TOTPAGBT, :MEST-TOTDSABT, :MEST-TOTHONBT, :MEST-TOTRSDBT, :MEST-SDORCPBT, :MEST-SDOADTBT, :MEST-CODCAU, :MEST-PROTSINI, :MEST-CODSUBES, :MEST-OCORHIST, :MEST-COD-MOEDA-SIN, :MEST-NUMIRB, :MEST-CODPRODU, :MEST-RAMO, :PRODUTO-DESCR-PRODUTO END-EXEC. */

            if (V1RELATSINI.Fetch())
            {
                _.Move(V1RELATSINI.RELSIN_APOL_SINI, RELSIN_APOL_SINI);
                _.Move(V1RELATSINI.RELSIN_DTMOVTO, RELSIN_DTMOVTO);
                _.Move(V1RELATSINI.RELSIN_OPERACAO, RELSIN_OPERACAO);
                _.Move(V1RELATSINI.RELSIN_OCORHIST, RELSIN_OCORHIST);
                _.Move(V1RELATSINI.RELSIN_CODPSI, RELSIN_CODPSI);
                _.Move(V1RELATSINI.RELSIN_CODUSU, RELSIN_CODUSU);
                _.Move(V1RELATSINI.RELSIN_MOVPCS, RELSIN_MOVPCS);
                _.Move(V1RELATSINI.MEST_TIPREG, MEST_TIPREG);
                _.Move(V1RELATSINI.MEST_NUM_APOL, MEST_NUM_APOL);
                _.Move(V1RELATSINI.MEST_NRENDOS, MEST_NRENDOS);
                _.Move(V1RELATSINI.MEST_NRCERTIF, MEST_NRCERTIF);
                _.Move(V1RELATSINI.MEST_DIGCERT, MEST_DIGCERT);
                _.Move(V1RELATSINI.MEST_IDTPSEGU, MEST_IDTPSEGU);
                _.Move(V1RELATSINI.MEST_DATCMD, MEST_DATCMD);
                _.Move(V1RELATSINI.MEST_DATTEC, MEST_DATTEC);
                _.Move(V1RELATSINI.MEST_DATORR, MEST_DATORR);
                _.Move(V1RELATSINI.MEST_FONTE, MEST_FONTE);
                _.Move(V1RELATSINI.MEST_DAC, MEST_DAC);
                _.Move(V1RELATSINI.MEST_PCPARTIC, MEST_PCPARTIC);
                _.Move(V1RELATSINI.MEST_PCTRES, MEST_PCTRES);
                _.Move(V1RELATSINI.MEST_TOTPAGBT, MEST_TOTPAGBT);
                _.Move(V1RELATSINI.MEST_TOTDSABT, MEST_TOTDSABT);
                _.Move(V1RELATSINI.MEST_TOTHONBT, MEST_TOTHONBT);
                _.Move(V1RELATSINI.MEST_TOTRSDBT, MEST_TOTRSDBT);
                _.Move(V1RELATSINI.MEST_SDORCPBT, MEST_SDORCPBT);
                _.Move(V1RELATSINI.MEST_SDOADTBT, MEST_SDOADTBT);
                _.Move(V1RELATSINI.MEST_CODCAU, MEST_CODCAU);
                _.Move(V1RELATSINI.MEST_PROTSINI, MEST_PROTSINI);
                _.Move(V1RELATSINI.MEST_CODSUBES, MEST_CODSUBES);
                _.Move(V1RELATSINI.MEST_OCORHIST, MEST_OCORHIST);
                _.Move(V1RELATSINI.MEST_COD_MOEDA_SIN, MEST_COD_MOEDA_SIN);
                _.Move(V1RELATSINI.MEST_NUMIRB, MEST_NUMIRB);
                _.Move(V1RELATSINI.MEST_CODPRODU, MEST_CODPRODU);
                _.Move(V1RELATSINI.MEST_RAMO, MEST_RAMO);
                _.Move(V1RELATSINI.PRODUTO_DESCR_PRODUTO, PRODUTO.DCLPRODUTO.PRODUTO_DESCR_PRODUTO);
            }

        }

        [StopWatch]
        /*" M-095-000-LER-TRELSIN-JOIN-E-DB-CLOSE-1 */
        public void M_095_000_LER_TRELSIN_JOIN_E_DB_CLOSE_1()
        {
            /*" -1738- EXEC SQL CLOSE V1RELATSINI END-EXEC */

            V1RELATSINI.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_095_999_EXIT*/

        [StopWatch]
        /*" M-120-000-PROCESSA-SECTION */
        private void M_120_000_PROCESSA_SECTION()
        {
            /*" -1783- MOVE SPACES TO VISTORIADOR-C19. */
            _.Move("", W.CAB19.VISTORIADOR_C19);

            /*" -1792- MOVE MEST-NUMIRB TO NUMIRB-C07. */
            _.Move(MEST_NUMIRB, W.CAB07.NUMIRB_C07);

            /*" -1795- IF (MEST-CODPRODU EQUAL 6801) OR (MEST-CODPRODU EQUAL 6600 AND MEST-NUM-APOL EQUAL 66001000001 OR 0106600000001) */

            if ((MEST_CODPRODU == 6801) || (MEST_CODPRODU == 6600 && MEST_NUM_APOL.In("66001000001", "0106600000001")))
            {

                /*" -1796- PERFORM 126-000-PELA-V0SINI-ITEM */

                M_126_000_PELA_V0SINI_ITEM_SECTION();

                /*" -1797- ELSE */
            }
            else
            {


                /*" -1799- IF MEST-CODPRODU EQUAL 6800 AND MEST-DATTEC LESS '1999-09-27' */

                if (MEST_CODPRODU == 6800 && MEST_DATTEC < "1999-09-27")
                {

                    /*" -1800- PERFORM 126-000-PELA-V0SINI-ITEM */

                    M_126_000_PELA_V0SINI_ITEM_SECTION();

                    /*" -1801- ELSE */
                }
                else
                {


                    /*" -1803- PERFORM 125-000-CREDITO-HABITACIONAL. */

                    M_125_000_CREDITO_HABITACIONAL_SECTION();
                }

            }


            /*" -1804- IF MEST-CODPRODU EQUAL 4801 OR 4804 OR 4811 */

            if (MEST_CODPRODU.In("4801", "4804", "4811"))
            {

                /*" -1805- MOVE V0HABIT01-PONTO-VENDA TO V0AG-COD-AGENCIA */
                _.Move(V0HABIT01_PONTO_VENDA, V0AG_COD_AGENCIA);

                /*" -1806- PERFORM 127-000-SELECT-V0AGENCIACEF */

                M_127_000_SELECT_V0AGENCIACEF_SECTION();

                /*" -1808- END-IF */
            }


            /*" -1810- PERFORM 129-000-ACESSA-PRODUTO. */

            M_129_000_ACESSA_PRODUTO_SECTION();

            /*" -1812- PERFORM 170-000-CURSOR-THISTSIN. */

            M_170_000_CURSOR_THISTSIN_SECTION();

            /*" -1814- PERFORM 180-000-LER-THISTSIN. */

            M_180_000_LER_THISTSIN_SECTION();

            /*" -1816- MOVE THIST-CODPSVI TO CODPSVI-C19 (1). */
            _.Move(THIST_CODPSVI, W.CAB19.VISTORIADOR_C19.TAB_VIST_C19[1].CODPSVI_C19);

            /*" -1817- IF RELSIN-OPERACAO EQUAL 101 */

            if (RELSIN_OPERACAO == 101)
            {

                /*" -1818- MOVE THIST-VALPRI TO VALPRI-C13 */
                _.Move(THIST_VALPRI, W.VALPRI_C13);

                /*" -1819- MOVE THIST-DTMOVTO TO WDATA-R */
                _.Move(THIST_DTMOVTO, W.WDATA_R);

                /*" -1820- MOVE WDATA-DD TO WDIA-IMP */
                _.Move(W.WDATA.WDATA_DD, W.WDATA_IMP.WDIA_IMP);

                /*" -1821- MOVE WDATA-MM TO WMES-IMP */
                _.Move(W.WDATA.WDATA_MM, W.WDATA_IMP.WMES_IMP);

                /*" -1822- MOVE WDATA-AA TO WANO-IMP */
                _.Move(W.WDATA.WDATA_AA, W.WDATA_IMP.WANO_IMP);

                /*" -1823- ELSE */
            }
            else
            {


                /*" -1825- PERFORM 190-000-ACESSA-AVISO. */

                M_190_000_ACESSA_AVISO_SECTION();
            }


            /*" -1826- IF GEOPERAC-FUNCAO-OPERACAO EQUAL 'IND' */

            if (GEOPERAC.DCLGE_OPERACAO.GEOPERAC_FUNCAO_OPERACAO == "IND")
            {

                /*" -1827- MOVE THIST-FONPAG TO MEST-FONTE */
                _.Move(THIST_FONPAG, MEST_FONTE);

                /*" -1828- PERFORM 220-000-LER-TGEFONTE */

                M_220_000_LER_TGEFONTE_SECTION();

                /*" -1829- MOVE FONTE-NOMEFTE TO NOMEFTE-C03 */
                _.Move(FONTE_NOMEFTE, W.CAB03.NOMEFTE_C03);

                /*" -1831- END-IF */
            }


            /*" -1832- IF RELSIN-APOL-SINI NOT EQUAL WSINISTRO-ANT */

            if (RELSIN_APOL_SINI != W.WSINISTRO_ANT)
            {

                /*" -1833- PERFORM 220-000-LER-TGEFONTE */

                M_220_000_LER_TGEFONTE_SECTION();

                /*" -1834- MOVE FONTE-NOMEFTE TO NOMEFTE-C03 */
                _.Move(FONTE_NOMEFTE, W.CAB03.NOMEFTE_C03);

                /*" -1835- PERFORM 230-000-LER-TGERAMO */

                M_230_000_LER_TGERAMO_SECTION();

                /*" -1836- PERFORM 240-000-LER-TAPOLICE */

                M_240_000_LER_TAPOLICE_SECTION();

                /*" -1837- PERFORM 270-000-LER-TENDOSSO */

                M_270_000_LER_TENDOSSO_SECTION();

                /*" -1838- MOVE 'SIM' TO W-CHAVE-ACHOU-APOLCORRET */
                _.Move("SIM", W.W_CHAVE_ACHOU_APOLCORRET);

                /*" -1839- PERFORM 300-000-CURSOR-TAPDCORR */

                M_300_000_CURSOR_TAPDCORR_SECTION();

                /*" -1853- PERFORM 330-000-LER-TAPDCORR */

                M_330_000_LER_TAPDCORR_SECTION();

                /*" -1854- IF W-CHAVE-ACHOU-APOLCORRET EQUAL 'SIM' */

                if (W.W_CHAVE_ACHOU_APOLCORRET == "SIM")
                {

                    /*" -1855- PERFORM 360-000-LER-PRODUTOR */

                    M_360_000_LER_PRODUTOR_SECTION();

                    /*" -1857- END-IF */
                }


                /*" -1859- PERFORM 391-003-LER-TCAUSA. */

                M_391_003_LER_TCAUSA_SECTION();
            }


            /*" -1860- MOVE 'N' TO WACHOU-THISTSIN. */
            _.Move("N", W.WACHOU_THISTSIN);

            /*" -1863- MOVE ZEROS TO WAUMENTO-RESERVA WREDUCAO-RESERVA WCALC-DIF-RESERVA */
            _.Move(0, W.WAUMENTO_RESERVA, W.WREDUCAO_RESERVA, W.WCALC_DIF_RESERVA);

            /*" -1865- PERFORM 400-000-CURSOR-THISTSIN-RESERV */

            M_400_000_CURSOR_THISTSIN_RESERV_SECTION();

            /*" -1868- PERFORM 410-000-LER-THISTSIN-RESERVA UNTIL WFIM-RESERVA EQUAL 'S' */

            while (!(W.WFIM_RESERVA == "S"))
            {

                M_410_000_LER_THISTSIN_RESERVA_SECTION();
            }

            /*" -1870- MOVE 'N' TO WFIM-RESERVA */
            _.Move("N", W.WFIM_RESERVA);

            /*" -1873- COMPUTE WCALC-DIF-RESERVA = WAUMENTO-RESERVA - WREDUCAO-RESERVA */
            W.WCALC_DIF_RESERVA.Value = W.WAUMENTO_RESERVA - W.WREDUCAO_RESERVA;

            /*" -1875- MOVE WCALC-DIF-RESERVA TO RESERVA-C17. */
            _.Move(W.WCALC_DIF_RESERVA, W.RESERVA_C17);

            /*" -1876- IF WACHOU-THISTSIN EQUAL 'N' */

            if (W.WACHOU_THISTSIN == "N")
            {

                /*" -1877- IF WETAPA EQUAL 'R' */

                if (W.WETAPA == "R")
                {

                    /*" -1878- ADD 1 TO WDESPREZADOS-R */
                    W.WDESPREZADOS_R.Value = W.WDESPREZADOS_R + 1;

                    /*" -1879- GO TO 120-010-LEITURA */

                    M_120_010_LEITURA(); //GOTO
                    return;

                    /*" -1880- ELSE */
                }
                else
                {


                    /*" -1881- ADD 1 TO WDESPREZADOS-E */
                    W.WDESPREZADOS_E.Value = W.WDESPREZADOS_E + 1;

                    /*" -1885- GO TO 120-010-LEITURA. */

                    M_120_010_LEITURA(); //GOTO
                    return;
                }

            }


            /*" -1890- PERFORM 185-000-LER-SALVADOS-RECUPER. */

            M_185_000_LER_SALVADOS_RECUPER_SECTION();

            /*" -1895- PERFORM 130-000-RESSARCIMENTOS. */

            M_130_000_RESSARCIMENTOS_SECTION();

            /*" -1900- PERFORM 131-000-INDENIZACOES. */

            M_131_000_INDENIZACOES_SECTION();

            /*" -1905- PERFORM 132-000-ADIANTAMENTOS. */

            M_132_000_ADIANTAMENTOS_SECTION();

            /*" -1910- PERFORM 133-000-DESPESAS. */

            M_133_000_DESPESAS_SECTION();

            /*" -1915- PERFORM 134-000-REATIVACAO. */

            M_134_000_REATIVACAO_SECTION();

            /*" -1920- PERFORM 135-000-CANCELAMENTO */

            M_135_000_CANCELAMENTO_SECTION();

            /*" -1924- PERFORM 140-000-BENEFICIARIOS. */

            M_140_000_BENEFICIARIOS_SECTION();

            /*" -1926- PERFORM 182-000-CURSOR-FAVOREC. */

            M_182_000_CURSOR_FAVOREC_SECTION();

            /*" -1929- PERFORM 183-000-LER-HISTFAV THRU 183-999-EXIT UNTIL WFIM-THISTFAV EQUAL 'S' */

            while (!(W.WFIM_THISTFAV == "S"))
            {

                M_183_000_LER_HISTFAV_SECTION();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_183_999_EXIT*/

            }

            /*" -1931- PERFORM 492-000-CLOSE-TFAVOREC. */

            M_492_000_CLOSE_TFAVOREC_SECTION();

            /*" -1933- MOVE 'N' TO WFIM-THISTFAV. */
            _.Move("N", W.WFIM_THISTFAV);

            /*" -1935- IF WS-PRODUTO-ANT NOT EQUAL MEST-CODPRODU */

            if (W.WS_QUEBRA.WS_PRODUTO_ANT != MEST_CODPRODU)
            {

                /*" -1936- MOVE MEST-CODPRODU TO WS-PRODUTO-ANT */
                _.Move(MEST_CODPRODU, W.WS_QUEBRA.WS_PRODUTO_ANT);

                /*" -1937- END-IF */
            }


            /*" -1938- IF RELSIN-CODUSU NOT EQUAL WS-GD-CODUSU */

            if (RELSIN_CODUSU != W.WS_GD_CODUSU)
            {

                /*" -1939- PERFORM 510-FOLHA-SEPARADORA */

                M_510_FOLHA_SEPARADORA_SECTION();

                /*" -1941- END-IF */
            }


            /*" -1945- DISPLAY ' VAI TESTAR CODPSI: ' RELSIN-CODPSI ' GRUPO CAUSAS: ' CAUSA-GRUPO-CAUSAS */

            $" VAI TESTAR CODPSI: {RELSIN_CODPSI} GRUPO CAUSAS: {CAUSA_GRUPO_CAUSAS}"
            .Display();

            /*" -1947- IF RELSIN-CODPSI = 925613 AND CAUSA-GRUPO-CAUSAS = 'M.I.P.' */

            if (RELSIN_CODPSI == 925613 && CAUSA_GRUPO_CAUSAS == "M.I.P.")
            {

                /*" -1948- IF W-LIDO-FORNECEDORES = 'N' */

                if (W_LIDO_FORNECEDORES == "N")
                {

                    /*" -1949- MOVE 'S' TO W-LIDO-FORNECEDORES */
                    _.Move("S", W_LIDO_FORNECEDORES);

                    /*" -1950- PERFORM 500-000-LER-FORNECEDOR */

                    M_500_000_LER_FORNECEDOR_SECTION();

                    /*" -1952- END-IF */
                }


                /*" -1954- DISPLAY ' CTA: ' FORNECED-NUM-CTA-CORRENTE */
                _.Display($" CTA: {FORNECED.DCLFORNECEDORES.FORNECED_NUM_CTA_CORRENTE}");

                /*" -1955- MOVE FORNECED-COD-BANCO TO BANCO-DET */
                _.Move(FORNECED.DCLFORNECEDORES.FORNECED_COD_BANCO, W.CAB28.BANCO_DET);

                /*" -1956- MOVE FORNECED-COD-AGENCIA TO COD-AGENCIA-DET */
                _.Move(FORNECED.DCLFORNECEDORES.FORNECED_COD_AGENCIA, W.CAB28.COD_AGENCIA_DET);

                /*" -1957- MOVE FORNECED-NUM-CTA-CORRENTE TO W-OPER-CONTA */
                _.Move(FORNECED.DCLFORNECEDORES.FORNECED_NUM_CTA_CORRENTE, W_OPER_CONTA);

                /*" -1958- MOVE W-OPER TO OPERACAO-DET */
                _.Move(FILLER_0.W_OPER, W.CAB28.OPERACAO_DET);

                /*" -1961- MOVE W-CONTA TO CONTA-DET. */
                _.Move(FILLER_0.W_CONTA, W.CAB28.CONTA_DET);
            }


            /*" -1961- PERFORM 500-000-IMPRIME. */

            M_500_000_IMPRIME_SECTION();

            /*" -0- FLUXCONTROL_PERFORM M_120_010_LEITURA */

            M_120_010_LEITURA();

        }

        [StopWatch]
        /*" M-120-010-LEITURA */
        private void M_120_010_LEITURA(bool isPerform = false)
        {
            /*" -1965- PERFORM 095-000-LER-TRELSIN-JOIN-E. */

            M_095_000_LER_TRELSIN_JOIN_E_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_120_999_EXIT*/

        [StopWatch]
        /*" M-125-000-CREDITO-HABITACIONAL-SECTION */
        private void M_125_000_CREDITO_HABITACIONAL_SECTION()
        {
            /*" -2039- MOVE ALL '*' TO V0HABIT01-NOME-SEGURADO NOME-SEGURADO-C08 NUM-CGCCPF-C08. */
            _.MoveAll("*", V0HABIT01_NOME_SEGURADO, W.CAB08.NOME_SEGURADO_C08, W.CAB08.NUM_CGCCPF_C08);

            /*" -2046- MOVE 99999999 TO OPERACAO-C07 PONTO-VENDA-C07 NUM-CONTRATO-C07 V0HABIT01-OPERACAO V0HABIT01-PONTO-VENDA V0HABIT01-NUM-CONTRATO. */
            _.Move(99999999, W.CAB07.OPERACAO_C07, W.CAB07.PONTO_VENDA_C07, W.CAB07.NUM_CONTRATO_C07, V0HABIT01_OPERACAO, V0HABIT01_PONTO_VENDA, V0HABIT01_NUM_CONTRATO);

            /*" -2048- MOVE '005' TO WNR-EXEC-SQL. */
            _.Move("005", WABEND.WNR_EXEC_SQL);

            /*" -2061- PERFORM M_125_000_CREDITO_HABITACIONAL_DB_SELECT_1 */

            M_125_000_CREDITO_HABITACIONAL_DB_SELECT_1();

            /*" -2064- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -2066- DISPLAY 'ERRO SELECT V0SINISTRO_HABIT01. SIN. = ' RELSIN-APOL-SINI */
                _.Display($"ERRO SELECT V0SINISTRO_HABIT01. SIN. = {RELSIN_APOL_SINI}");

                /*" -2067- DISPLAY 'SQLCODE = ' SQLCODE */
                _.Display($"SQLCODE = {DB.SQLCODE}");

                /*" -2069- GO TO 125-999-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_125_999_EXIT*/ //GOTO
                return;
            }


            /*" -2071- IF (SQLCODE NOT EQUAL ZERO) AND (SQLCODE NOT EQUAL 100) */

            if ((DB.SQLCODE != 00) && (DB.SQLCODE != 100))
            {

                /*" -2073- DISPLAY 'ERRO SELECT V0SINISTRO_HABIT01. SIN. = ' RELSIN-APOL-SINI */
                _.Display($"ERRO SELECT V0SINISTRO_HABIT01. SIN. = {RELSIN_APOL_SINI}");

                /*" -2075- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2076- MOVE V0HABIT01-OPERACAO TO OPERACAO-C07 */
            _.Move(V0HABIT01_OPERACAO, W.CAB07.OPERACAO_C07);

            /*" -2077- MOVE V0HABIT01-PONTO-VENDA TO PONTO-VENDA-C07 */
            _.Move(V0HABIT01_PONTO_VENDA, W.CAB07.PONTO_VENDA_C07);

            /*" -2078- MOVE V0HABIT01-NUM-CONTRATO TO NUM-CONTRATO-C07 */
            _.Move(V0HABIT01_NUM_CONTRATO, W.CAB07.NUM_CONTRATO_C07);

            /*" -2079- MOVE V0HABIT01-CGCCPF TO NUM-CGCCPF-C08 */
            _.Move(V0HABIT01_CGCCPF, W.CAB08.NUM_CGCCPF_C08);

            /*" -2079- MOVE V0HABIT01-NOME-SEGURADO TO NOME-SEGURADO-C08. */
            _.Move(V0HABIT01_NOME_SEGURADO, W.CAB08.NOME_SEGURADO_C08);

        }

        [StopWatch]
        /*" M-125-000-CREDITO-HABITACIONAL-DB-SELECT-1 */
        public void M_125_000_CREDITO_HABITACIONAL_DB_SELECT_1()
        {
            /*" -2061- EXEC SQL SELECT OPERACAO, PONTO_VENDA, NUM_CONTRATO, CGCCPF, NOME_SEGURADO INTO :V0HABIT01-OPERACAO, :V0HABIT01-PONTO-VENDA, :V0HABIT01-NUM-CONTRATO, :V0HABIT01-CGCCPF, :V0HABIT01-NOME-SEGURADO FROM SEGUROS.V0SINISTRO_HABIT01 WHERE NUM_APOL_SINISTRO = :RELSIN-APOL-SINI END-EXEC. */

            var m_125_000_CREDITO_HABITACIONAL_DB_SELECT_1_Query1 = new M_125_000_CREDITO_HABITACIONAL_DB_SELECT_1_Query1()
            {
                RELSIN_APOL_SINI = RELSIN_APOL_SINI.ToString(),
            };

            var executed_1 = M_125_000_CREDITO_HABITACIONAL_DB_SELECT_1_Query1.Execute(m_125_000_CREDITO_HABITACIONAL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0HABIT01_OPERACAO, V0HABIT01_OPERACAO);
                _.Move(executed_1.V0HABIT01_PONTO_VENDA, V0HABIT01_PONTO_VENDA);
                _.Move(executed_1.V0HABIT01_NUM_CONTRATO, V0HABIT01_NUM_CONTRATO);
                _.Move(executed_1.V0HABIT01_CGCCPF, V0HABIT01_CGCCPF);
                _.Move(executed_1.V0HABIT01_NOME_SEGURADO, V0HABIT01_NOME_SEGURADO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_125_999_EXIT*/

        [StopWatch]
        /*" M-126-000-PELA-V0SINI-ITEM-SECTION */
        private void M_126_000_PELA_V0SINI_ITEM_SECTION()
        {
            /*" -2088- MOVE ALL '*' TO CLIE-NOME-RAZAO NOME-SEGURADO-C08 NUM-CGCCPF-C08. */
            _.MoveAll("*", CLIE_NOME_RAZAO, W.CAB08.NOME_SEGURADO_C08, W.CAB08.NUM_CGCCPF_C08);

            /*" -2092- MOVE 99999999 TO OPERACAO-C07 PONTO-VENDA-C07 NUM-CONTRATO-C07 . */
            _.Move(99999999, W.CAB07.OPERACAO_C07, W.CAB07.PONTO_VENDA_C07, W.CAB07.NUM_CONTRATO_C07);

            /*" -2094- MOVE '006' TO WNR-EXEC-SQL. */
            _.Move("006", WABEND.WNR_EXEC_SQL);

            /*" -2101- PERFORM M_126_000_PELA_V0SINI_ITEM_DB_SELECT_1 */

            M_126_000_PELA_V0SINI_ITEM_DB_SELECT_1();

            /*" -2104- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -2106- DISPLAY 'ERRO SELECT V0SINI_ITEM/V0CLIENTE. SIN. = ' RELSIN-APOL-SINI */
                _.Display($"ERRO SELECT V0SINI_ITEM/V0CLIENTE. SIN. = {RELSIN_APOL_SINI}");

                /*" -2107- DISPLAY 'SQLCODE = ' SQLCODE */
                _.Display($"SQLCODE = {DB.SQLCODE}");

                /*" -2109- GO TO 126-999-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_126_999_EXIT*/ //GOTO
                return;
            }


            /*" -2111- IF (SQLCODE NOT EQUAL ZERO) AND (SQLCODE NOT EQUAL 100) */

            if ((DB.SQLCODE != 00) && (DB.SQLCODE != 100))
            {

                /*" -2113- DISPLAY 'ERRO SELECT V0SINI_ITEM/V0CLIENTE. SIN. = ' RELSIN-APOL-SINI */
                _.Display($"ERRO SELECT V0SINI_ITEM/V0CLIENTE. SIN. = {RELSIN_APOL_SINI}");

                /*" -2115- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2115- MOVE CLIE-NOME-RAZAO TO NOME-SEGURADO-C08. */
            _.Move(CLIE_NOME_RAZAO, W.CAB08.NOME_SEGURADO_C08);

        }

        [StopWatch]
        /*" M-126-000-PELA-V0SINI-ITEM-DB-SELECT-1 */
        public void M_126_000_PELA_V0SINI_ITEM_DB_SELECT_1()
        {
            /*" -2101- EXEC SQL SELECT C.NOME_RAZAO INTO :CLIE-NOME-RAZAO FROM SEGUROS.V0SINI_ITEM S, SEGUROS.V0CLIENTE C WHERE S.NUM_APOL_SINISTRO = :RELSIN-APOL-SINI AND C.COD_CLIENTE = S.COD_CLIENTE END-EXEC. */

            var m_126_000_PELA_V0SINI_ITEM_DB_SELECT_1_Query1 = new M_126_000_PELA_V0SINI_ITEM_DB_SELECT_1_Query1()
            {
                RELSIN_APOL_SINI = RELSIN_APOL_SINI.ToString(),
            };

            var executed_1 = M_126_000_PELA_V0SINI_ITEM_DB_SELECT_1_Query1.Execute(m_126_000_PELA_V0SINI_ITEM_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CLIE_NOME_RAZAO, CLIE_NOME_RAZAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_126_999_EXIT*/

        [StopWatch]
        /*" M-127-000-SELECT-V0AGENCIACEF-SECTION */
        private void M_127_000_SELECT_V0AGENCIACEF_SECTION()
        {
            /*" -2131- PERFORM M_127_000_SELECT_V0AGENCIACEF_DB_SELECT_1 */

            M_127_000_SELECT_V0AGENCIACEF_DB_SELECT_1();

            /*" -2134- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2135- MOVE 'NAO INFORMADO' TO V0AG-NOME-AGENCIA */
                _.Move("NAO INFORMADO", V0AG_NOME_AGENCIA);

                /*" -2137- END-IF */
            }


            /*" -2138- IF V0AG-AGE-CENTRAL-PROD01 EQUAL ZEROS */

            if (V0AG_AGE_CENTRAL_PROD01 == 00)
            {

                /*" -2139- MOVE 9999 TO V0AG-AGE-CENTRAL-PROD01 */
                _.Move(9999, V0AG_AGE_CENTRAL_PROD01);

                /*" -2143- END-IF */
            }


            /*" -2148- PERFORM M_127_000_SELECT_V0AGENCIACEF_DB_SELECT_2 */

            M_127_000_SELECT_V0AGENCIACEF_DB_SELECT_2();

            /*" -2151- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2152- MOVE 'NAO INFORMADO' TO V0AG-NOME-AGENCIA */
                _.Move("NAO INFORMADO", V0AG_NOME_AGENCIA);

                /*" -2154- END-IF */
            }


            /*" -2155- MOVE V0AG-AGE-CENTRAL-PROD01 TO NUM-AG-CENT-C07A */
            _.Move(V0AG_AGE_CENTRAL_PROD01, W.CAB07A.NUM_AG_CENT_C07A);

            /*" -2156- MOVE V0AG-COD-AGENCIA TO NUM-AG-CTRT-C07A */
            _.Move(V0AG_COD_AGENCIA, W.CAB07A.NUM_AG_CTRT_C07A);

            /*" -2157- MOVE V0AG-NOME-AGENCIA TO AG-CTRT-C07A */
            _.Move(V0AG_NOME_AGENCIA, W.CAB07A.AG_CTRT_C07A);

            /*" -2157- MOVE V0AG-NOME-AGENCIA-CENTR TO AG-CENTR-C07A. */
            _.Move(V0AG_NOME_AGENCIA_CENTR, W.CAB07A.AG_CENTR_C07A);

        }

        [StopWatch]
        /*" M-127-000-SELECT-V0AGENCIACEF-DB-SELECT-1 */
        public void M_127_000_SELECT_V0AGENCIACEF_DB_SELECT_1()
        {
            /*" -2131- EXEC SQL SELECT DISTINCT NOME_AGENCIA, AGE_CENTRAL_PROD01 INTO :V0AG-NOME-AGENCIA, :V0AG-AGE-CENTRAL-PROD01 FROM SEGUROS.V0AGENCIACEF WHERE COD_AGENCIA = :V0AG-COD-AGENCIA END-EXEC */

            var m_127_000_SELECT_V0AGENCIACEF_DB_SELECT_1_Query1 = new M_127_000_SELECT_V0AGENCIACEF_DB_SELECT_1_Query1()
            {
                V0AG_COD_AGENCIA = V0AG_COD_AGENCIA.ToString(),
            };

            var executed_1 = M_127_000_SELECT_V0AGENCIACEF_DB_SELECT_1_Query1.Execute(m_127_000_SELECT_V0AGENCIACEF_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0AG_NOME_AGENCIA, V0AG_NOME_AGENCIA);
                _.Move(executed_1.V0AG_AGE_CENTRAL_PROD01, V0AG_AGE_CENTRAL_PROD01);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_127_999_EXIT*/

        [StopWatch]
        /*" M-127-000-SELECT-V0AGENCIACEF-DB-SELECT-2 */
        public void M_127_000_SELECT_V0AGENCIACEF_DB_SELECT_2()
        {
            /*" -2148- EXEC SQL SELECT DISTINCT NOME_AGENCIA INTO :V0AG-NOME-AGENCIA-CENTR FROM SEGUROS.V0AGENCIACEF WHERE COD_AGENCIA = :V0AG-AGE-CENTRAL-PROD01 END-EXEC */

            var m_127_000_SELECT_V0AGENCIACEF_DB_SELECT_2_Query1 = new M_127_000_SELECT_V0AGENCIACEF_DB_SELECT_2_Query1()
            {
                V0AG_AGE_CENTRAL_PROD01 = V0AG_AGE_CENTRAL_PROD01.ToString(),
            };

            var executed_1 = M_127_000_SELECT_V0AGENCIACEF_DB_SELECT_2_Query1.Execute(m_127_000_SELECT_V0AGENCIACEF_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0AG_NOME_AGENCIA_CENTR, V0AG_NOME_AGENCIA_CENTR);
            }


        }

        [StopWatch]
        /*" M-129-000-ACESSA-PRODUTO-SECTION */
        private void M_129_000_ACESSA_PRODUTO_SECTION()
        {
            /*" -2166- MOVE ALL '*' TO V0PROD-DESCRPROD. */
            _.MoveAll("*", V0PROD_DESCRPROD);

            /*" -2168- MOVE '007' TO WNR-EXEC-SQL. */
            _.Move("007", WABEND.WNR_EXEC_SQL);

            /*" -2174- PERFORM M_129_000_ACESSA_PRODUTO_DB_SELECT_1 */

            M_129_000_ACESSA_PRODUTO_DB_SELECT_1();

            /*" -2177- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -2179- DISPLAY 'ERRO SELECT V0PRODUTO. SIN. = ' RELSIN-APOL-SINI */
                _.Display($"ERRO SELECT V0PRODUTO. SIN. = {RELSIN_APOL_SINI}");

                /*" -2180- DISPLAY 'CODPRODU  = ' MEST-CODPRODU */
                _.Display($"CODPRODU  = {MEST_CODPRODU}");

                /*" -2182- GO TO 129-999-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_129_999_EXIT*/ //GOTO
                return;
            }


            /*" -2184- IF (SQLCODE NOT EQUAL ZERO) AND (SQLCODE NOT EQUAL 100) */

            if ((DB.SQLCODE != 00) && (DB.SQLCODE != 100))
            {

                /*" -2186- DISPLAY 'ERRO SELECT V0PRODUTO. SIN. = ' RELSIN-APOL-SINI */
                _.Display($"ERRO SELECT V0PRODUTO. SIN. = {RELSIN_APOL_SINI}");

                /*" -2188- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2189- MOVE MEST-CODPRODU TO CODPRODU-C04. */
            _.Move(MEST_CODPRODU, W.CAB04A.CODPRODU_C04);

            /*" -2189- MOVE V0PROD-DESCRPROD TO NOME-CODPRODU-C04. */
            _.Move(V0PROD_DESCRPROD, W.CAB04A.NOME_CODPRODU_C04);

        }

        [StopWatch]
        /*" M-129-000-ACESSA-PRODUTO-DB-SELECT-1 */
        public void M_129_000_ACESSA_PRODUTO_DB_SELECT_1()
        {
            /*" -2174- EXEC SQL SELECT DESCRPROD INTO :V0PROD-DESCRPROD FROM SEGUROS.V0PRODUTO WHERE CODPRODU = :MEST-CODPRODU AND SITUACAO IN ( '0' , '1' ) END-EXEC. */

            var m_129_000_ACESSA_PRODUTO_DB_SELECT_1_Query1 = new M_129_000_ACESSA_PRODUTO_DB_SELECT_1_Query1()
            {
                MEST_CODPRODU = MEST_CODPRODU.ToString(),
            };

            var executed_1 = M_129_000_ACESSA_PRODUTO_DB_SELECT_1_Query1.Execute(m_129_000_ACESSA_PRODUTO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0PROD_DESCRPROD, V0PROD_DESCRPROD);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_129_999_EXIT*/

        [StopWatch]
        /*" M-130-000-RESSARCIMENTOS-SECTION */
        private void M_130_000_RESSARCIMENTOS_SECTION()
        {
            /*" -2196- MOVE '130-000-RESSARCIMENTOS ' TO PARAGRAFO. */
            _.Move("130-000-RESSARCIMENTOS ", WABEND.PARAGRAFO);

            /*" -2200- MOVE '008' TO WNR-EXEC-SQL. */
            _.Move("008", WABEND.WNR_EXEC_SQL);

            /*" -2202- INITIALIZE SI1001S-PARAMETROS. */
            _.Initialize(
                LBSI1001.SI1001S_PARAMETROS
            );

            /*" -2204- MOVE RELSIN-APOL-SINI TO SI1001S-NUM-APOL-SINISTRO */
            _.Move(RELSIN_APOL_SINI, LBSI1001.SI1001S_PARAMETROS.SI1001S_ENTRADA.SI1001S_NUM_APOL_SINISTRO);

            /*" -2206- CALL SI1024S USING SI1001S-PARAMETROS */
            _.Call(SI1024S, LBSI1001.SI1001S_PARAMETROS);

            /*" -2207- IF SI1001S-ERRO-MENSAGEM NOT EQUAL SPACES */

            if (!LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_ERRO_MENSAGEM.IsEmpty())
            {

                /*" -2209- DISPLAY 'PROBLEMA CALL SI1024S ' ' ' RELSIN-APOL-SINI */

                $"PROBLEMA CALL SI1024S  {RELSIN_APOL_SINI}"
                .Display();

                /*" -2210- DISPLAY 'SQLCODE = ' SI1001S-ERRO-SQLCODE */
                _.Display($"SQLCODE = {LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_ERRO_SQLCODE}");

                /*" -2211- DISPLAY SI1001S-ERRO-MENSAGEM */
                _.Display(LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_ERRO_MENSAGEM);

                /*" -2212- GO TO 999-999-ROT-ERRO */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2213- ELSE */
            }
            else
            {


                /*" -2215- MOVE SI1001S-VALOR-CALCULADO TO THIST-VALPRI. */
                _.Move(LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_VALOR_CALCULADO, THIST_VALPRI);
            }


            /*" -2215- MOVE THIST-VALPRI TO RESSARC-C13. */
            _.Move(THIST_VALPRI, W.RESSARC_C13);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_130_999_EXIT*/

        [StopWatch]
        /*" M-131-000-INDENIZACOES-SECTION */
        private void M_131_000_INDENIZACOES_SECTION()
        {
            /*" -2229- MOVE '131-000-INDENIZACOES' TO PARAGRAFO. */
            _.Move("131-000-INDENIZACOES", WABEND.PARAGRAFO);

            /*" -2233- MOVE '009' TO WNR-EXEC-SQL. */
            _.Move("009", WABEND.WNR_EXEC_SQL);

            /*" -2235- INITIALIZE SI1001S-PARAMETROS. */
            _.Initialize(
                LBSI1001.SI1001S_PARAMETROS
            );

            /*" -2237- MOVE RELSIN-APOL-SINI TO SI1001S-NUM-APOL-SINISTRO */
            _.Move(RELSIN_APOL_SINI, LBSI1001.SI1001S_PARAMETROS.SI1001S_ENTRADA.SI1001S_NUM_APOL_SINISTRO);

            /*" -2239- CALL SI1002S USING SI1001S-PARAMETROS */
            _.Call(SI1002S, LBSI1001.SI1001S_PARAMETROS);

            /*" -2240- IF SI1001S-ERRO-MENSAGEM NOT EQUAL SPACES */

            if (!LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_ERRO_MENSAGEM.IsEmpty())
            {

                /*" -2242- DISPLAY 'PROBLEMA CALL SI1002S ' ' ' RELSIN-APOL-SINI */

                $"PROBLEMA CALL SI1002S  {RELSIN_APOL_SINI}"
                .Display();

                /*" -2243- DISPLAY 'SQLCODE = ' SI1001S-ERRO-SQLCODE */
                _.Display($"SQLCODE = {LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_ERRO_SQLCODE}");

                /*" -2244- DISPLAY SI1001S-ERRO-MENSAGEM */
                _.Display(LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_ERRO_MENSAGEM);

                /*" -2245- GO TO 999-999-ROT-ERRO */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2246- ELSE */
            }
            else
            {


                /*" -2248- MOVE SI1001S-VALOR-CALCULADO TO THIST-VALPRI. */
                _.Move(LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_VALOR_CALCULADO, THIST_VALPRI);
            }


            /*" -2248- MOVE THIST-VALPRI TO TOTPAG-C14. */
            _.Move(THIST_VALPRI, W.TOTPAG_C14);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_131_999_EXIT*/

        [StopWatch]
        /*" M-132-000-ADIANTAMENTOS-SECTION */
        private void M_132_000_ADIANTAMENTOS_SECTION()
        {
            /*" -2262- MOVE '132-000-ADIANTAMENTOS' TO PARAGRAFO. */
            _.Move("132-000-ADIANTAMENTOS", WABEND.PARAGRAFO);

            /*" -2266- MOVE '010' TO WNR-EXEC-SQL. */
            _.Move("010", WABEND.WNR_EXEC_SQL);

            /*" -2268- INITIALIZE SI1001S-PARAMETROS. */
            _.Initialize(
                LBSI1001.SI1001S_PARAMETROS
            );

            /*" -2270- MOVE RELSIN-APOL-SINI TO SI1001S-NUM-APOL-SINISTRO */
            _.Move(RELSIN_APOL_SINI, LBSI1001.SI1001S_PARAMETROS.SI1001S_ENTRADA.SI1001S_NUM_APOL_SINISTRO);

            /*" -2272- CALL SI1025S USING SI1001S-PARAMETROS */
            _.Call(SI1025S, LBSI1001.SI1001S_PARAMETROS);

            /*" -2273- IF SI1001S-ERRO-MENSAGEM NOT EQUAL SPACES */

            if (!LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_ERRO_MENSAGEM.IsEmpty())
            {

                /*" -2275- DISPLAY 'PROBLEMA CALL SI1025S ' ' ' RELSIN-APOL-SINI */

                $"PROBLEMA CALL SI1025S  {RELSIN_APOL_SINI}"
                .Display();

                /*" -2276- DISPLAY 'SQLCODE = ' SI1001S-ERRO-SQLCODE */
                _.Display($"SQLCODE = {LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_ERRO_SQLCODE}");

                /*" -2277- DISPLAY SI1001S-ERRO-MENSAGEM */
                _.Display(LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_ERRO_MENSAGEM);

                /*" -2278- GO TO 999-999-ROT-ERRO */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2279- ELSE */
            }
            else
            {


                /*" -2281- MOVE SI1001S-VALOR-CALCULADO TO THIST-VALPRI. */
                _.Move(LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_VALOR_CALCULADO, THIST_VALPRI);
            }


            /*" -2281- MOVE THIST-VALPRI TO SDOADT-C15. */
            _.Move(THIST_VALPRI, W.SDOADT_C15);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_132_999_EXIT*/

        [StopWatch]
        /*" M-133-000-DESPESAS-SECTION */
        private void M_133_000_DESPESAS_SECTION()
        {
            /*" -2295- MOVE '133-000-LER-SALVADOS-RECUPER' TO PARAGRAFO. */
            _.Move("133-000-LER-SALVADOS-RECUPER", WABEND.PARAGRAFO);

            /*" -2299- MOVE '011' TO WNR-EXEC-SQL. */
            _.Move("011", WABEND.WNR_EXEC_SQL);

            /*" -2301- INITIALIZE SI1001S-PARAMETROS. */
            _.Initialize(
                LBSI1001.SI1001S_PARAMETROS
            );

            /*" -2303- MOVE RELSIN-APOL-SINI TO SI1001S-NUM-APOL-SINISTRO */
            _.Move(RELSIN_APOL_SINI, LBSI1001.SI1001S_PARAMETROS.SI1001S_ENTRADA.SI1001S_NUM_APOL_SINISTRO);

            /*" -2305- CALL SI1005S USING SI1001S-PARAMETROS */
            _.Call(SI1005S, LBSI1001.SI1001S_PARAMETROS);

            /*" -2306- IF SI1001S-ERRO-MENSAGEM NOT EQUAL SPACES */

            if (!LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_ERRO_MENSAGEM.IsEmpty())
            {

                /*" -2308- DISPLAY 'PROBLEMA CALL SI1005S ' ' ' RELSIN-APOL-SINI */

                $"PROBLEMA CALL SI1005S  {RELSIN_APOL_SINI}"
                .Display();

                /*" -2309- DISPLAY 'SQLCODE = ' SI1001S-ERRO-SQLCODE */
                _.Display($"SQLCODE = {LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_ERRO_SQLCODE}");

                /*" -2310- DISPLAY SI1001S-ERRO-MENSAGEM */
                _.Display(LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_ERRO_MENSAGEM);

                /*" -2311- GO TO 999-999-ROT-ERRO */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2312- ELSE */
            }
            else
            {


                /*" -2314- MOVE SI1001S-VALOR-CALCULADO TO THIST-VALPRI. */
                _.Move(LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_VALOR_CALCULADO, THIST_VALPRI);
            }


            /*" -2318- MOVE THIST-VALPRI TO DESPHON-C16. */
            _.Move(THIST_VALPRI, W.DESPHON_C16);

            /*" -2320- INITIALIZE SI1001S-PARAMETROS. */
            _.Initialize(
                LBSI1001.SI1001S_PARAMETROS
            );

            /*" -2322- MOVE RELSIN-APOL-SINI TO SI1001S-NUM-APOL-SINISTRO */
            _.Move(RELSIN_APOL_SINI, LBSI1001.SI1001S_PARAMETROS.SI1001S_ENTRADA.SI1001S_NUM_APOL_SINISTRO);

            /*" -2324- CALL SI1006S USING SI1001S-PARAMETROS */
            _.Call(SI1006S, LBSI1001.SI1001S_PARAMETROS);

            /*" -2325- IF SI1001S-ERRO-MENSAGEM NOT EQUAL SPACES */

            if (!LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_ERRO_MENSAGEM.IsEmpty())
            {

                /*" -2327- DISPLAY 'PROBLEMA CALL SI1006S ' ' ' RELSIN-APOL-SINI */

                $"PROBLEMA CALL SI1006S  {RELSIN_APOL_SINI}"
                .Display();

                /*" -2328- DISPLAY 'SQLCODE = ' SI1001S-ERRO-SQLCODE */
                _.Display($"SQLCODE = {LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_ERRO_SQLCODE}");

                /*" -2329- DISPLAY SI1001S-ERRO-MENSAGEM */
                _.Display(LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_ERRO_MENSAGEM);

                /*" -2330- GO TO 999-999-ROT-ERRO */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2331- ELSE */
            }
            else
            {


                /*" -2333- MOVE SI1001S-VALOR-CALCULADO TO THIST-VALPRI. */
                _.Move(LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_VALOR_CALCULADO, THIST_VALPRI);
            }


            /*" -2333- ADD THIST-VALPRI TO DESPHON-C16. */
            W.DESPHON_C16.Value = W.DESPHON_C16 + THIST_VALPRI;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_133_999_EXIT*/

        [StopWatch]
        /*" M-134-000-REATIVACAO-SECTION */
        private void M_134_000_REATIVACAO_SECTION()
        {
            /*" -2347- MOVE '134-000-REATIVACOES' TO PARAGRAFO. */
            _.Move("134-000-REATIVACOES", WABEND.PARAGRAFO);

            /*" -2349- MOVE '012' TO WNR-EXEC-SQL. */
            _.Move("012", WABEND.WNR_EXEC_SQL);

            /*" -2357- PERFORM M_134_000_REATIVACAO_DB_SELECT_1 */

            M_134_000_REATIVACAO_DB_SELECT_1();

            /*" -2360- IF WVARIAV-IND NOT EQUAL 0 */

            if (WVARIAV_IND != 0)
            {

                /*" -2361- MOVE ZEROS TO REATIVACAO-C16 */
                _.Move(0, W.REATIVACAO_C16);

                /*" -2362- ELSE */
            }
            else
            {


                /*" -2362- MOVE THIST-VALPRI TO REATIVACAO-C16. */
                _.Move(THIST_VALPRI, W.REATIVACAO_C16);
            }


        }

        [StopWatch]
        /*" M-134-000-REATIVACAO-DB-SELECT-1 */
        public void M_134_000_REATIVACAO_DB_SELECT_1()
        {
            /*" -2357- EXEC SQL SELECT SUM(VAL_OPERACAO) INTO :THIST-VALPRI:WVARIAV-IND FROM SEGUROS.V1HISTSINI WHERE NUM_APOL_SINISTRO = :RELSIN-APOL-SINI AND (OPERACAO = 104 OR OPERACAO = 114) AND SITUACAO = '0' END-EXEC */

            var m_134_000_REATIVACAO_DB_SELECT_1_Query1 = new M_134_000_REATIVACAO_DB_SELECT_1_Query1()
            {
                RELSIN_APOL_SINI = RELSIN_APOL_SINI.ToString(),
            };

            var executed_1 = M_134_000_REATIVACAO_DB_SELECT_1_Query1.Execute(m_134_000_REATIVACAO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.THIST_VALPRI, THIST_VALPRI);
                _.Move(executed_1.WVARIAV_IND, WVARIAV_IND);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_134_999_EXIT*/

        [StopWatch]
        /*" M-135-000-CANCELAMENTO-SECTION */
        private void M_135_000_CANCELAMENTO_SECTION()
        {
            /*" -2376- MOVE '135-000-CANCELAMENTO' TO PARAGRAFO. */
            _.Move("135-000-CANCELAMENTO", WABEND.PARAGRAFO);

            /*" -2378- MOVE '013' TO WNR-EXEC-SQL. */
            _.Move("013", WABEND.WNR_EXEC_SQL);

            /*" -2388- PERFORM M_135_000_CANCELAMENTO_DB_SELECT_1 */

            M_135_000_CANCELAMENTO_DB_SELECT_1();

            /*" -2391- IF WVARIAV-IND NOT EQUAL 0 */

            if (WVARIAV_IND != 0)
            {

                /*" -2392- MOVE ZEROS TO CANCELAMENTO-C15 */
                _.Move(0, W.CANCELAMENTO_C15);

                /*" -2393- ELSE */
            }
            else
            {


                /*" -2393- MOVE THIST-VALPRI TO CANCELAMENTO-C15. */
                _.Move(THIST_VALPRI, W.CANCELAMENTO_C15);
            }


        }

        [StopWatch]
        /*" M-135-000-CANCELAMENTO-DB-SELECT-1 */
        public void M_135_000_CANCELAMENTO_DB_SELECT_1()
        {
            /*" -2388- EXEC SQL SELECT SUM(VAL_OPERACAO) INTO :THIST-VALPRI:WVARIAV-IND FROM SEGUROS.V1HISTSINI WHERE NUM_APOL_SINISTRO = :RELSIN-APOL-SINI AND (OPERACAO = 107 OR OPERACAO = 108 OR OPERACAO = 117 OR OPERACAO = 118) AND SITUACAO = '0' END-EXEC. */

            var m_135_000_CANCELAMENTO_DB_SELECT_1_Query1 = new M_135_000_CANCELAMENTO_DB_SELECT_1_Query1()
            {
                RELSIN_APOL_SINI = RELSIN_APOL_SINI.ToString(),
            };

            var executed_1 = M_135_000_CANCELAMENTO_DB_SELECT_1_Query1.Execute(m_135_000_CANCELAMENTO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.THIST_VALPRI, THIST_VALPRI);
                _.Move(executed_1.WVARIAV_IND, WVARIAV_IND);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_135_999_EXIT*/

        [StopWatch]
        /*" M-140-000-BENEFICIARIOS-SECTION */
        private void M_140_000_BENEFICIARIOS_SECTION()
        {
            /*" -2406- MOVE '140-000-BENEFICIARIOS' TO PARAGRAFO. */
            _.Move("140-000-BENEFICIARIOS", WABEND.PARAGRAFO);

            /*" -2408- MOVE '014' TO WNR-EXEC-SQL. */
            _.Move("014", WABEND.WNR_EXEC_SQL);

            /*" -2420- PERFORM M_140_000_BENEFICIARIOS_DB_DECLARE_1 */

            M_140_000_BENEFICIARIOS_DB_DECLARE_1();

            /*" -2422- PERFORM M_140_000_BENEFICIARIOS_DB_OPEN_1 */

            M_140_000_BENEFICIARIOS_DB_OPEN_1();

            /*" -2428- PERFORM 020-000-LIMPA-TAB-MOVIM THRU 020-000-EXIT VARYING WS-IND1 FROM 1 BY 1 UNTIL WS-IND1 = 16 */

            for (W.WS_IND1.Value = 1; !(W.WS_IND1 == 16); W.WS_IND1.Value += 1)
            {

                M_020_000_LIMPA_TAB_MOVIM_SECTION();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_020_000_EXIT*/

            }

            /*" -2430- MOVE 0 TO WS-IND1 */
            _.Move(0, W.WS_IND1);

            /*" -2433- PERFORM 145-000-FETCH-BENEF UNTIL WFIM-BENEFIC = 'S' . */

            while (!(W.WFIM_BENEFIC == "S"))
            {

                M_145_000_FETCH_BENEF_SECTION();
            }

            /*" -2434- IF WS-IND1 GREATER WS-INDMAX1 */

            if (W.WS_IND1 > W.WS_INDMAX1)
            {

                /*" -2435- MOVE WS-IND1 TO WS-INDMAX1 */
                _.Move(W.WS_IND1, W.WS_INDMAX1);

                /*" -2436- ELSE */
            }
            else
            {


                /*" -2440- MOVE 11 TO WS-INDMAX1. */
                _.Move(11, W.WS_INDMAX1);
            }


            /*" -2440- MOVE 'N' TO WFIM-BENEFIC. */
            _.Move("N", W.WFIM_BENEFIC);

        }

        [StopWatch]
        /*" M-140-000-BENEFICIARIOS-DB-OPEN-1 */
        public void M_140_000_BENEFICIARIOS_DB_OPEN_1()
        {
            /*" -2422- EXEC SQL OPEN V1BENEF END-EXEC. */

            V1BENEF.Open();

        }

        [StopWatch]
        /*" M-170-000-CURSOR-THISTSIN-DB-DECLARE-1 */
        public void M_170_000_CURSOR_THISTSIN_DB_DECLARE_1()
        {
            /*" -2524- EXEC SQL DECLARE V1HISTSINI CURSOR FOR SELECT H.VAL_OPERACAO, H.OCORHIST, H.DTMOVTO, H.SITUACAO, H.OPERACAO, H.FONPAG, H.NOMFAV, H.CODPSVI, H.TIPFAV, H.LIMCRR, H.MOVPCS, H.NUMOPG, O.FUNCAO_OPERACAO FROM SEGUROS.V1HISTSINI H, SEGUROS.GE_OPERACAO O WHERE NUM_APOL_SINISTRO = :RELSIN-APOL-SINI AND O.IDE_SISTEMA = 'SI' AND H.OPERACAO = O.COD_OPERACAO AND H.OPERACAO �= 102 AND H.OPERACAO �= 105 AND H.OPERACAO �= 112 AND H.OPERACAO �= 115 ORDER BY DTMOVTO ASC, VAL_OPERACAO DESC END-EXEC. */
            V1HISTSINI = new SI0133B_V1HISTSINI(true);
            string GetQuery_V1HISTSINI()
            {
                var query = @$"SELECT H.VAL_OPERACAO
							, H.OCORHIST
							, 
							H.DTMOVTO
							, H.SITUACAO
							, 
							H.OPERACAO
							, H.FONPAG
							, 
							H.NOMFAV
							, H.CODPSVI
							, 
							H.TIPFAV
							, H.LIMCRR
							, 
							H.MOVPCS
							, H.NUMOPG
							, 
							O.FUNCAO_OPERACAO 
							FROM SEGUROS.V1HISTSINI H
							, 
							SEGUROS.GE_OPERACAO O 
							WHERE NUM_APOL_SINISTRO = '{RELSIN_APOL_SINI}' 
							AND O.IDE_SISTEMA = 'SI' 
							AND H.OPERACAO = O.COD_OPERACAO 
							AND H.OPERACAO �= 102 
							AND H.OPERACAO �= 105 
							AND H.OPERACAO �= 112 
							AND H.OPERACAO �= 115 
							ORDER BY DTMOVTO ASC
							, 
							VAL_OPERACAO DESC";

                return query;
            }
            V1HISTSINI.GetQueryEvent += GetQuery_V1HISTSINI;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_140_000_FIM*/

        [StopWatch]
        /*" M-145-000-FETCH-BENEF-SECTION */
        private void M_145_000_FETCH_BENEF_SECTION()
        {
            /*" -2450- MOVE '145-000-FETCH-BENEF' TO PARAGRAFO. */
            _.Move("145-000-FETCH-BENEF", WABEND.PARAGRAFO);

            /*" -2452- MOVE '015' TO WNR-EXEC-SQL. */
            _.Move("015", WABEND.WNR_EXEC_SQL);

            /*" -2457- PERFORM M_145_000_FETCH_BENEF_DB_FETCH_1 */

            M_145_000_FETCH_BENEF_DB_FETCH_1();

            /*" -2461- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -2461- PERFORM M_145_000_FETCH_BENEF_DB_CLOSE_1 */

                M_145_000_FETCH_BENEF_DB_CLOSE_1();

                /*" -2464- MOVE 'S' TO WFIM-BENEFIC */
                _.Move("S", W.WFIM_BENEFIC);

                /*" -2465- GO TO 145-000-FIM */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_145_000_FIM*/ //GOTO
                return;

                /*" -2467- ELSE */
            }
            else
            {


                /*" -2468- MOVE 'BENEFICIARIOS:' TO BENEF-TIT1-CAB12 */
                _.Move("BENEFICIARIOS:", W.CAB12.BENEF_TIT1_CAB12);

                /*" -2470- MOVE 'PERCENTUAL PARENTESCO' TO BENEF-TIT2-CAB12 */
                _.Move("PERCENTUAL PARENTESCO", W.CAB12.BENEF_TIT2_CAB12);

                /*" -2472- ADD 1 TO WS-IND1 */
                W.WS_IND1.Value = W.WS_IND1 + 1;

                /*" -2473- MOVE TBENEF-NOME-BENEFIC TO NOME-BENEF-OCC(WS-IND1) */
                _.Move(TBENEF_NOME_BENEFIC, W.CAB_MOV_OCC[W.WS_IND1].NOME_BENEF_OCC);

                /*" -2474- MOVE TBENEF-GRAU-PARENT TO PTESCO-BNF-OCC(WS-IND1) */
                _.Move(TBENEF_GRAU_PARENT, W.CAB_MOV_OCC[W.WS_IND1].PTESCO_BNF_OCC);

                /*" -2474- MOVE TBENEF-PCT-PART-BENEF TO PERC-BENEF-OCC(WS-IND1). */
                _.Move(TBENEF_PCT_PART_BENEF, W.CAB_MOV_OCC[W.WS_IND1].PERC_BENEF_OCC);
            }


        }

        [StopWatch]
        /*" M-145-000-FETCH-BENEF-DB-FETCH-1 */
        public void M_145_000_FETCH_BENEF_DB_FETCH_1()
        {
            /*" -2457- EXEC SQL FETCH V1BENEF INTO :TBENEF-NOME-BENEFIC, :TBENEF-GRAU-PARENT, :TBENEF-PCT-PART-BENEF END-EXEC. */

            if (V1BENEF.Fetch())
            {
                _.Move(V1BENEF.TBENEF_NOME_BENEFIC, TBENEF_NOME_BENEFIC);
                _.Move(V1BENEF.TBENEF_GRAU_PARENT, TBENEF_GRAU_PARENT);
                _.Move(V1BENEF.TBENEF_PCT_PART_BENEF, TBENEF_PCT_PART_BENEF);
            }

        }

        [StopWatch]
        /*" M-145-000-FETCH-BENEF-DB-CLOSE-1 */
        public void M_145_000_FETCH_BENEF_DB_CLOSE_1()
        {
            /*" -2461- EXEC SQL CLOSE V1BENEF END-EXEC */

            V1BENEF.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_145_000_FIM*/

        [StopWatch]
        /*" M-170-000-CURSOR-THISTSIN-SECTION */
        private void M_170_000_CURSOR_THISTSIN_SECTION()
        {
            /*" -2495- MOVE '170-000-CURSOR-THISTSIN' TO PARAGRAFO. */
            _.Move("170-000-CURSOR-THISTSIN", WABEND.PARAGRAFO);

            /*" -2499- MOVE '016' TO WNR-EXEC-SQL. */
            _.Move("016", WABEND.WNR_EXEC_SQL);

            /*" -2500- IF CH1-ON1 = 0 */

            if (W.CH1_ON1 == 0)
            {

                /*" -2501- MOVE 1 TO CH1-ON1 */
                _.Move(1, W.CH1_ON1);

                /*" -2502- ELSE */
            }
            else
            {


                /*" -2504- PERFORM 490-000-CLOSE-THISTSIN. */

                M_490_000_CLOSE_THISTSIN_SECTION();
            }


            /*" -2524- PERFORM M_170_000_CURSOR_THISTSIN_DB_DECLARE_1 */

            M_170_000_CURSOR_THISTSIN_DB_DECLARE_1();

            /*" -2526- PERFORM M_170_000_CURSOR_THISTSIN_DB_OPEN_1 */

            M_170_000_CURSOR_THISTSIN_DB_OPEN_1();

        }

        [StopWatch]
        /*" M-170-000-CURSOR-THISTSIN-DB-OPEN-1 */
        public void M_170_000_CURSOR_THISTSIN_DB_OPEN_1()
        {
            /*" -2526- EXEC SQL OPEN V1HISTSINI END-EXEC. */

            V1HISTSINI.Open();

        }

        [StopWatch]
        /*" M-182-000-CURSOR-FAVOREC-DB-DECLARE-1 */
        public void M_182_000_CURSOR_FAVOREC_DB_DECLARE_1()
        {
            /*" -2624- EXEC SQL DECLARE V1HISTFAV CURSOR FOR SELECT H.VAL_OPERACAO, H.OCORHIST, H.DTMOVTO, H.SITUACAO, H.OPERACAO, H.FONPAG, H.NOMFAV, H.CODPSVI, H.TIPFAV, H.LIMCRR, H.MOVPCS, H.NUMOPG, O.IND_TIPO_FUNCAO FROM SEGUROS.V1HISTSINI H, SEGUROS.GE_OPERACAO O WHERE H.NUM_APOL_SINISTRO = :RELSIN-APOL-SINI AND O.IDE_SISTEMA = 'SI' AND H.OPERACAO = O.COD_OPERACAO AND O.FUNCAO_OPERACAO IN ( 'PRE' , 'DMOV' , 'HMOV' , 'JPIND' , 'JBDES' , 'JBHON' , 'JCDES' , 'JCHON' , 'JEDES' , 'JEHON' , 'JPDES' , 'JPHON' ) AND SITUACAO �= '2' ORDER BY OCORHIST ASC, OPERACAO ASC, DTMOVTO ASC, VAL_OPERACAO DESC END-EXEC. */
            V1HISTFAV = new SI0133B_V1HISTFAV(true);
            string GetQuery_V1HISTFAV()
            {
                var query = @$"SELECT H.VAL_OPERACAO
							, H.OCORHIST
							, 
							H.DTMOVTO
							, H.SITUACAO
							, 
							H.OPERACAO
							, H.FONPAG
							, 
							H.NOMFAV
							, H.CODPSVI
							, 
							H.TIPFAV
							, H.LIMCRR
							, 
							H.MOVPCS
							, H.NUMOPG
							, 
							O.IND_TIPO_FUNCAO 
							FROM SEGUROS.V1HISTSINI H
							, 
							SEGUROS.GE_OPERACAO O 
							WHERE 
							H.NUM_APOL_SINISTRO = '{RELSIN_APOL_SINI}' 
							AND O.IDE_SISTEMA = 'SI' 
							AND H.OPERACAO = O.COD_OPERACAO 
							AND O.FUNCAO_OPERACAO IN ( 'PRE'
							, 'DMOV'
							, 'HMOV'
							, 'JPIND'
							, 
							'JBDES'
							, 'JBHON'
							, 'JCDES'
							, 
							'JCHON'
							, 'JEDES'
							, 'JEHON'
							, 
							'JPDES'
							, 'JPHON' ) 
							AND SITUACAO �= '2' 
							ORDER BY OCORHIST ASC
							, OPERACAO ASC
							, DTMOVTO ASC
							, 
							VAL_OPERACAO DESC";

                return query;
            }
            V1HISTFAV.GetQueryEvent += GetQuery_V1HISTFAV;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_170_999_EXIT*/

        [StopWatch]
        /*" M-180-000-LER-THISTSIN-SECTION */
        private void M_180_000_LER_THISTSIN_SECTION()
        {
            /*" -2543- MOVE '180-000-LER-THISTSIN' TO PARAGRAFO. */
            _.Move("180-000-LER-THISTSIN", WABEND.PARAGRAFO);

            /*" -2545- MOVE '017' TO WNR-EXEC-SQL. */
            _.Move("017", WABEND.WNR_EXEC_SQL);

            /*" -2554- PERFORM M_180_000_LER_THISTSIN_DB_FETCH_1 */

            M_180_000_LER_THISTSIN_DB_FETCH_1();

            /*" -2557- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -2558- MOVE 'S' TO WFIM-THISTSIN */
                _.Move("S", W.WFIM_THISTSIN);

                /*" -2560- GO TO 180-999-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_180_999_EXIT*/ //GOTO
                return;
            }


            /*" -2561- PERFORM 187-000-ULT-MOVIMENTACAO. */

            M_187_000_ULT_MOVIMENTACAO_SECTION();

            /*" -2562- MOVE THIST-DTMOVTO2 TO WDATA-R */
            _.Move(THIST_DTMOVTO2, W.WDATA_R);

            /*" -2563- MOVE WDATA-DD TO CAB21-DIA */
            _.Move(W.WDATA.WDATA_DD, W.CAB20.CAB21_DIA);

            /*" -2564- MOVE WDATA-MM TO CAB21-MES */
            _.Move(W.WDATA.WDATA_MM, W.CAB20.CAB21_MES);

            /*" -2565- MOVE WDATA-AA TO CAB21-ANO */
            _.Move(W.WDATA.WDATA_AA, W.CAB20.CAB21_ANO);

            /*" -2566- PERFORM 600-000-CALCULA-VALOR. */

            M_600_000_CALCULA_VALOR_SECTION();

            /*" -2567- MOVE THIST-VALPRI4 TO CAB21-VALOR. */
            _.Move(THIST_VALPRI4, W.CAB20.CAB21_VALOR);

            /*" -2569- MOVE RELSIN-CODUSU TO CAB21-COD-USU. */
            _.Move(RELSIN_CODUSU, W.CAB20.CAB21_COD_USU);

            /*" -2570- MOVE THIST-OPERACAO2 TO GEOPERAC-COD-OPERACAO */
            _.Move(THIST_OPERACAO2, GEOPERAC.DCLGE_OPERACAO.GEOPERAC_COD_OPERACAO);

            /*" -2571- PERFORM 200-000-ACESSA-OPERACAO */

            M_200_000_ACESSA_OPERACAO_SECTION();

            /*" -2571- MOVE GEOPERAC-DES-OPERACAO TO CAB21-MOVIMEN. */
            _.Move(GEOPERAC.DCLGE_OPERACAO.GEOPERAC_DES_OPERACAO, W.CAB20.CAB21_MOVIMEN);

        }

        [StopWatch]
        /*" M-180-000-LER-THISTSIN-DB-FETCH-1 */
        public void M_180_000_LER_THISTSIN_DB_FETCH_1()
        {
            /*" -2554- EXEC SQL FETCH V1HISTSINI INTO :THIST-VALPRI, :THIST-OCORHIST, :THIST-DTMOVTO, :THIST-SITUACAO, :THIST-OPERACAO, :THIST-FONPAG:WVARIAV-IND, :THIST-NOMFAV, :THIST-CODPSVI, :THIST-TIPFAV, :THIST-LIMCRR, :THIST-MOVPCS, :THIST-NUMOPG, :GEOPERAC-FUNCAO-OPERACAO END-EXEC. */

            if (V1HISTSINI.Fetch())
            {
                _.Move(V1HISTSINI.THIST_VALPRI, THIST_VALPRI);
                _.Move(V1HISTSINI.THIST_OCORHIST, THIST_OCORHIST);
                _.Move(V1HISTSINI.THIST_DTMOVTO, THIST_DTMOVTO);
                _.Move(V1HISTSINI.THIST_SITUACAO, THIST_SITUACAO);
                _.Move(V1HISTSINI.THIST_OPERACAO, THIST_OPERACAO);
                _.Move(V1HISTSINI.THIST_FONPAG, THIST_FONPAG);
                _.Move(V1HISTSINI.WVARIAV_IND, WVARIAV_IND);
                _.Move(V1HISTSINI.THIST_NOMFAV, THIST_NOMFAV);
                _.Move(V1HISTSINI.THIST_CODPSVI, THIST_CODPSVI);
                _.Move(V1HISTSINI.THIST_TIPFAV, THIST_TIPFAV);
                _.Move(V1HISTSINI.THIST_LIMCRR, THIST_LIMCRR);
                _.Move(V1HISTSINI.THIST_MOVPCS, THIST_MOVPCS);
                _.Move(V1HISTSINI.THIST_NUMOPG, THIST_NUMOPG);
                _.Move(V1HISTSINI.GEOPERAC_FUNCAO_OPERACAO, GEOPERAC.DCLGE_OPERACAO.GEOPERAC_FUNCAO_OPERACAO);
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_180_999_EXIT*/

        [StopWatch]
        /*" M-182-000-CURSOR-FAVOREC-SECTION */
        private void M_182_000_CURSOR_FAVOREC_SECTION()
        {
            /*" -2588- MOVE '182-000-CURSOR-FAVOREC' TO PARAGRAFO. */
            _.Move("182-000-CURSOR-FAVOREC", WABEND.PARAGRAFO);

            /*" -2590- MOVE '018' TO WNR-EXEC-SQL. */
            _.Move("018", WABEND.WNR_EXEC_SQL);

            /*" -2598- MOVE ZEROS TO WS-IND2 PREMIO-IOF OCORHIST-PREMIO. */
            _.Move(0, W.WS_IND2, W.PREMIO_IOF, W.OCORHIST_PREMIO);

            /*" -2600- DISPLAY 'RELSIN-APOL-SINI = ' RELSIN-APOL-SINI */
            _.Display($"RELSIN-APOL-SINI = {RELSIN_APOL_SINI}");

            /*" -2624- PERFORM M_182_000_CURSOR_FAVOREC_DB_DECLARE_1 */

            M_182_000_CURSOR_FAVOREC_DB_DECLARE_1();

            /*" -2626- PERFORM M_182_000_CURSOR_FAVOREC_DB_OPEN_1 */

            M_182_000_CURSOR_FAVOREC_DB_OPEN_1();

            /*" -2633- PERFORM 025-000-LIMPA-TAB-FAVOR THRU 025-000-EXIT VARYING WS-IND1 FROM 1 BY 1 UNTIL WS-IND1 = 100001. */

            for (W.WS_IND1.Value = 1; !(W.WS_IND1 == 100001); W.WS_IND1.Value += 1)
            {

                M_025_000_LIMPA_TAB_FAVOR_SECTION();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_025_000_EXIT*/

            }

        }

        [StopWatch]
        /*" M-182-000-CURSOR-FAVOREC-DB-OPEN-1 */
        public void M_182_000_CURSOR_FAVOREC_DB_OPEN_1()
        {
            /*" -2626- EXEC SQL OPEN V1HISTFAV END-EXEC. */

            V1HISTFAV.Open();

        }

        [StopWatch]
        /*" M-187-000-ULT-MOVIMENTACAO-DB-DECLARE-1 */
        public void M_187_000_ULT_MOVIMENTACAO_DB_DECLARE_1()
        {
            /*" -2876- EXEC SQL DECLARE V1HISTSIN2 CURSOR FOR SELECT H.VAL_OPERACAO, H.DTMOVTO, H.OPERACAO, H.OCORHIST, H.TIMESTAMP FROM SEGUROS.V1HISTSINI H, SEGUROS.GE_OPERACAO O WHERE H.NUM_APOL_SINISTRO = :RELSIN-APOL-SINI AND H.OPERACAO NOT IN (11, 1, 2) AND O.IDE_SISTEMA = 'SI' AND H.OPERACAO = O.COD_OPERACAO AND O.IND_TIPO_FUNCAO NOT IN ( 'RE' , 'SA' ) ORDER BY OCORHIST DESC, TIMESTAMP DESC END-EXEC. */
            V1HISTSIN2 = new SI0133B_V1HISTSIN2(true);
            string GetQuery_V1HISTSIN2()
            {
                var query = @$"SELECT H.VAL_OPERACAO
							, 
							H.DTMOVTO
							, 
							H.OPERACAO
							, 
							H.OCORHIST
							, 
							H.TIMESTAMP 
							FROM SEGUROS.V1HISTSINI H
							, 
							SEGUROS.GE_OPERACAO O 
							WHERE H.NUM_APOL_SINISTRO = '{RELSIN_APOL_SINI}' 
							AND H.OPERACAO NOT IN (11
							, 1
							, 2) 
							AND O.IDE_SISTEMA = 'SI' 
							AND H.OPERACAO = O.COD_OPERACAO 
							AND O.IND_TIPO_FUNCAO NOT IN ( 'RE'
							, 'SA' ) 
							ORDER BY OCORHIST DESC
							, 
							TIMESTAMP DESC";

                return query;
            }
            V1HISTSIN2.GetQueryEvent += GetQuery_V1HISTSIN2;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_182_999_EXIT*/

        [StopWatch]
        /*" M-183-000-LER-HISTFAV-SECTION */
        private void M_183_000_LER_HISTFAV_SECTION()
        {
            /*" -2650- MOVE '183-000-LER-HISTFAV' TO PARAGRAFO. */
            _.Move("183-000-LER-HISTFAV", WABEND.PARAGRAFO);

            /*" -2652- MOVE '019' TO WNR-EXEC-SQL. */
            _.Move("019", WABEND.WNR_EXEC_SQL);

            /*" -2661- PERFORM M_183_000_LER_HISTFAV_DB_FETCH_1 */

            M_183_000_LER_HISTFAV_DB_FETCH_1();

            /*" -2664- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -2665- MOVE 'S' TO WFIM-THISTFAV */
                _.Move("S", W.WFIM_THISTFAV);

                /*" -2667- GO TO 183-999-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_183_999_EXIT*/ //GOTO
                return;
            }


            /*" -2669- IF THIST-DTMOVTO < SIST-DTMOVABE AND MEST-RAMO = 66 */

            if (THIST_DTMOVTO < SIST_DTMOVABE && MEST_RAMO == 66)
            {

                /*" -2671- GO TO 183-999-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_183_999_EXIT*/ //GOTO
                return;
            }


            /*" -2672- IF THIST-OPERACAO EQUAL 0011 */

            if (THIST_OPERACAO == 0011)
            {

                /*" -2673- MOVE THIST-VALPRI TO PREMIO-IOF */
                _.Move(THIST_VALPRI, W.PREMIO_IOF);

                /*" -2674- MOVE THIST-OCORHIST TO OCORHIST-PREMIO */
                _.Move(THIST_OCORHIST, W.OCORHIST_PREMIO);

                /*" -2675- ELSE */
            }
            else
            {


                /*" -2677- IF SQLCODE EQUAL ZEROS AND THIST-OPERACAO NOT EQUAL 101 */

                if (DB.SQLCODE == 00 && THIST_OPERACAO != 101)
                {

                    /*" -2678- ADD 1 TO WS-IND2 */
                    W.WS_IND2.Value = W.WS_IND2 + 1;

                    /*" -2679- MOVE THIST-NOMFAV TO NOMFAV-OCC(WS-IND2) */
                    _.Move(THIST_NOMFAV, W.DETALHE_OCC[W.WS_IND2].NOMFAV_OCC);

                    /*" -2680- PERFORM 183-050-DETERM-TIPFAV THRU 183-050-FIM */

                    M_183_050_DETERM_TIPFAV();
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_183_050_FIM*/


                    /*" -2681- MOVE THIST-CODPSVI TO CODFAV-OCC(WS-IND2) */
                    _.Move(THIST_CODPSVI, W.DETALHE_OCC[W.WS_IND2].CODFAV_OCC);

                    /*" -2682- MOVE THIST-VALPRI TO VAL-OP-OCC(WS-IND2) */
                    _.Move(THIST_VALPRI, W.DETALHE_OCC[W.WS_IND2].VAL_OP_OCC);

                    /*" -2683- MOVE THIST-LIMCRR TO WS-DTCONV */
                    _.Move(THIST_LIMCRR, W.WS_DTCONV);

                    /*" -2684- MOVE '/' TO VENCB1-OCC(WS-IND2) */
                    _.Move("/", W.DETALHE_OCC[W.WS_IND2].VENCTO_OCC.VENCB1_OCC);

                    /*" -2685- MOVE '/' TO VENCB2-OCC(WS-IND2) */
                    _.Move("/", W.DETALHE_OCC[W.WS_IND2].VENCTO_OCC.VENCB2_OCC);

                    /*" -2686- MOVE WS-DDCONV TO VENCDD-OCC(WS-IND2) */
                    _.Move(W.WS_DTCONV.WS_DDCONV, W.DETALHE_OCC[W.WS_IND2].VENCTO_OCC.VENCDD_OCC);

                    /*" -2687- MOVE WS-MMCONV TO VENCMM-OCC(WS-IND2) */
                    _.Move(W.WS_DTCONV.WS_MMCONV, W.DETALHE_OCC[W.WS_IND2].VENCTO_OCC.VENCMM_OCC);

                    /*" -2689- MOVE WS-A2CONV TO VENCAA-OCC(WS-IND2) */
                    _.Move(W.WS_DTCONV.WS_A2CONV, W.DETALHE_OCC[W.WS_IND2].VENCTO_OCC.VENCAA_OCC);

                    /*" -2690- MOVE THIST-FONPAG TO MEST-FONTE */
                    _.Move(THIST_FONPAG, MEST_FONTE);

                    /*" -2691- PERFORM 220-000-LER-TGEFONTE */

                    M_220_000_LER_TGEFONTE_SECTION();

                    /*" -2693- MOVE FONTE-NOMEFTE TO FONPAG-OCC(WS-IND2) */
                    _.Move(FONTE_NOMEFTE, W.DETALHE_OCC[W.WS_IND2].FONPAG_OCC);

                    /*" -2695- PERFORM 184-000-DETERM-TIPPAG THRU 184-000-FIM */

                    M_184_000_DETERM_TIPPAG_SECTION();
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_184_000_FIM*/


                    /*" -2697- PERFORM 184-050-DETERM-VAL-OPER THRU 184-050-FIM */

                    M_184_050_DETERM_VAL_OPER_SECTION();
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_184_050_FIM*/


                    /*" -2699- IF THIST-OPERACAO NOT LESS 8000 AND THIST-OPERACAO NOT GREATER 8999 */

                    if (THIST_OPERACAO >= 8000 && THIST_OPERACAO <= 8999)
                    {

                        /*" -2700- PERFORM 186-000-ACESSA-PROC-JURID THRU 186-999-EXIT */

                        M_186_000_ACESSA_PROC_JURID_SECTION();
                        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_186_999_EXIT*/


                        /*" -2701- ELSE */
                    }
                    else
                    {


                        /*" -2702- MOVE SPACES TO JURID-OCC(WS-IND2) */
                        _.Move("", W.DETALHE_OCC[W.WS_IND2].JURID_OCC);

                        /*" -2704- END-IF. */
                    }

                }

            }


            /*" -2704- MOVE WS-IND2 TO WS-INDMAX2. */
            _.Move(W.WS_IND2, W.WS_INDMAX2);

        }

        [StopWatch]
        /*" M-183-000-LER-HISTFAV-DB-FETCH-1 */
        public void M_183_000_LER_HISTFAV_DB_FETCH_1()
        {
            /*" -2661- EXEC SQL FETCH V1HISTFAV INTO :THIST-VALPRI, :THIST-OCORHIST, :THIST-DTMOVTO, :THIST-SITUACAO, :THIST-OPERACAO, :THIST-FONPAG:WVARIAV-IND, :THIST-NOMFAV, :THIST-CODPSVI, :THIST-TIPFAV, :THIST-LIMCRR, :THIST-MOVPCS, :THIST-NUMOPG, :GEOPERAC-IND-TIPO-FUNCAO END-EXEC. */

            if (V1HISTFAV.Fetch())
            {
                _.Move(V1HISTFAV.THIST_VALPRI, THIST_VALPRI);
                _.Move(V1HISTFAV.THIST_OCORHIST, THIST_OCORHIST);
                _.Move(V1HISTFAV.THIST_DTMOVTO, THIST_DTMOVTO);
                _.Move(V1HISTFAV.THIST_SITUACAO, THIST_SITUACAO);
                _.Move(V1HISTFAV.THIST_OPERACAO, THIST_OPERACAO);
                _.Move(V1HISTFAV.THIST_FONPAG, THIST_FONPAG);
                _.Move(V1HISTFAV.WVARIAV_IND, WVARIAV_IND);
                _.Move(V1HISTFAV.THIST_NOMFAV, THIST_NOMFAV);
                _.Move(V1HISTFAV.THIST_CODPSVI, THIST_CODPSVI);
                _.Move(V1HISTFAV.THIST_TIPFAV, THIST_TIPFAV);
                _.Move(V1HISTFAV.THIST_LIMCRR, THIST_LIMCRR);
                _.Move(V1HISTFAV.THIST_MOVPCS, THIST_MOVPCS);
                _.Move(V1HISTFAV.THIST_NUMOPG, THIST_NUMOPG);
                _.Move(V1HISTFAV.GEOPERAC_IND_TIPO_FUNCAO, GEOPERAC.DCLGE_OPERACAO.GEOPERAC_IND_TIPO_FUNCAO);
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_183_999_EXIT*/

        [StopWatch]
        /*" M-183-050-DETERM-TIPFAV */
        private void M_183_050_DETERM_TIPFAV(bool isPerform = false)
        {
            /*" -2712- EVALUATE THIST-TIPFAV */
            switch (THIST_TIPFAV.Value.Trim())
            {

                /*" -2713- WHEN '1' */
                case "1":

                    /*" -2714- MOVE 'SEGURADO' TO TIPFAV-OCC(WS-IND2) */
                    _.Move("SEGURADO", W.DETALHE_OCC[W.WS_IND2].TIPFAV_OCC);

                    /*" -2715- WHEN '2' */
                    break;
                case "2":

                    /*" -2716- MOVE 'TERCEIROS' TO TIPFAV-OCC(WS-IND2) */
                    _.Move("TERCEIROS", W.DETALHE_OCC[W.WS_IND2].TIPFAV_OCC);

                    /*" -2717- WHEN '3' */
                    break;
                case "3":

                    /*" -2718- MOVE 'OFICINA' TO TIPFAV-OCC(WS-IND2) */
                    _.Move("OFICINA", W.DETALHE_OCC[W.WS_IND2].TIPFAV_OCC);

                    /*" -2719- WHEN '4' */
                    break;
                case "4":

                    /*" -2720- MOVE 'INDENIZ.' TO TIPFAV-OCC(WS-IND2) */
                    _.Move("INDENIZ.", W.DETALHE_OCC[W.WS_IND2].TIPFAV_OCC);

                    /*" -2721- WHEN '7' */
                    break;
                case "7":

                    /*" -2722- MOVE 'OFC-ISS' TO TIPFAV-OCC(WS-IND2) */
                    _.Move("OFC-ISS", W.DETALHE_OCC[W.WS_IND2].TIPFAV_OCC);

                    /*" -2723- WHEN '9' */
                    break;
                case "9":

                    /*" -2724- MOVE 'OUTROS' TO TIPFAV-OCC(WS-IND2) */
                    _.Move("OUTROS", W.DETALHE_OCC[W.WS_IND2].TIPFAV_OCC);

                    /*" -2726- END-EVALUATE */
                    break;
            }


            /*" -2727- IF GEOPERAC-IND-TIPO-FUNCAO EQUAL 'DE' */

            if (GEOPERAC.DCLGE_OPERACAO.GEOPERAC_IND_TIPO_FUNCAO == "DE")
            {

                /*" -2728- MOVE 'DESPESAS' TO TIPFAV-OCC(WS-IND2) */
                _.Move("DESPESAS", W.DETALHE_OCC[W.WS_IND2].TIPFAV_OCC);

                /*" -2730- END-IF */
            }


            /*" -2731- IF GEOPERAC-IND-TIPO-FUNCAO EQUAL 'HO' */

            if (GEOPERAC.DCLGE_OPERACAO.GEOPERAC_IND_TIPO_FUNCAO == "HO")
            {

                /*" -2732- MOVE 'HONORARIO' TO TIPFAV-OCC(WS-IND2) */
                _.Move("HONORARIO", W.DETALHE_OCC[W.WS_IND2].TIPFAV_OCC);

                /*" -2734- END-IF. */
            }


            /*" -2735- IF GEOPERAC-IND-TIPO-FUNCAO EQUAL 'JUR-INDENI' */

            if (GEOPERAC.DCLGE_OPERACAO.GEOPERAC_IND_TIPO_FUNCAO == "JUR-INDENI")
            {

                /*" -2736- MOVE 'JURIDICO' TO TIPFAV-OCC(WS-IND2) */
                _.Move("JURIDICO", W.DETALHE_OCC[W.WS_IND2].TIPFAV_OCC);

                /*" -2738- END-IF. */
            }


            /*" -2739- IF GEOPERAC-IND-TIPO-FUNCAO EQUAL 'IN' */

            if (GEOPERAC.DCLGE_OPERACAO.GEOPERAC_IND_TIPO_FUNCAO == "IN")
            {

                /*" -2740- MOVE 'SEGURO' TO TIPFAV-OCC(WS-IND2) */
                _.Move("SEGURO", W.DETALHE_OCC[W.WS_IND2].TIPFAV_OCC);

                /*" -2740- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_183_050_FIM*/

        [StopWatch]
        /*" M-184-000-DETERM-TIPPAG-SECTION */
        private void M_184_000_DETERM_TIPPAG_SECTION()
        {
            /*" -2748- IF THIST-OPERACAO EQUAL 1181 */

            if (THIST_OPERACAO == 1181)
            {

                /*" -2749- MOVE 'PARCIAL' TO TIPPAG-OCC(WS-IND2) */
                _.Move("PARCIAL", W.DETALHE_OCC[W.WS_IND2].TIPPAG_OCC);

                /*" -2750- ELSE */
            }
            else
            {


                /*" -2751- IF THIST-OPERACAO EQUAL 1182 */

                if (THIST_OPERACAO == 1182)
                {

                    /*" -2752- MOVE 'FINAL' TO TIPPAG-OCC(WS-IND2) */
                    _.Move("FINAL", W.DETALHE_OCC[W.WS_IND2].TIPPAG_OCC);

                    /*" -2753- ELSE */
                }
                else
                {


                    /*" -2754- IF THIST-OPERACAO EQUAL 1183 */

                    if (THIST_OPERACAO == 1183)
                    {

                        /*" -2755- MOVE 'TOTAL' TO TIPPAG-OCC(WS-IND2) */
                        _.Move("TOTAL", W.DETALHE_OCC[W.WS_IND2].TIPPAG_OCC);

                        /*" -2756- ELSE */
                    }
                    else
                    {


                        /*" -2757- IF THIST-OPERACAO EQUAL 1184 */

                        if (THIST_OPERACAO == 1184)
                        {

                            /*" -2758- MOVE 'COMPLEM.' TO TIPPAG-OCC(WS-IND2) */
                            _.Move("COMPLEM.", W.DETALHE_OCC[W.WS_IND2].TIPPAG_OCC);

                            /*" -2759- ELSE */
                        }
                        else
                        {


                            /*" -2759- MOVE 'TOTAL' TO TIPPAG-OCC(WS-IND2). */
                            _.Move("TOTAL", W.DETALHE_OCC[W.WS_IND2].TIPPAG_OCC);
                        }

                    }

                }

            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_184_000_FIM*/

        [StopWatch]
        /*" M-184-050-DETERM-VAL-OPER-SECTION */
        private void M_184_050_DETERM_VAL_OPER_SECTION()
        {
            /*" -2767- IF THIST-OCORHIST EQUAL OCORHIST-PREMIO */

            if (THIST_OCORHIST == W.OCORHIST_PREMIO)
            {

                /*" -2768- MOVE ZEROS TO VAL-OP-OCC(WS-IND2) */
                _.Move(0, W.DETALHE_OCC[W.WS_IND2].VAL_OP_OCC);

                /*" -2769- COMPUTE VALPRI-LIQ EQUAL THIST-VALPRI - PREMIO-IOF */
                W.VALPRI_LIQ.Value = THIST_VALPRI - W.PREMIO_IOF;

                /*" -2770- MOVE ZEROS TO OCORHIST-PREMIO PREMIO-IOF */
                _.Move(0, W.OCORHIST_PREMIO, W.PREMIO_IOF);

                /*" -2770- MOVE VALPRI-LIQ TO VAL-OP-OCC(WS-IND2). */
                _.Move(W.VALPRI_LIQ, W.DETALHE_OCC[W.WS_IND2].VAL_OP_OCC);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_184_050_FIM*/

        [StopWatch]
        /*" M-185-000-LER-SALVADOS-RECUPER-SECTION */
        private void M_185_000_LER_SALVADOS_RECUPER_SECTION()
        {
            /*" -2787- MOVE '185-000-LER-SALVADOS-RECUPER' TO PARAGRAFO. */
            _.Move("185-000-LER-SALVADOS-RECUPER", WABEND.PARAGRAFO);

            /*" -2791- MOVE '020' TO WNR-EXEC-SQL. */
            _.Move("020", WABEND.WNR_EXEC_SQL);

            /*" -2793- INITIALIZE SI1001S-PARAMETROS. */
            _.Initialize(
                LBSI1001.SI1001S_PARAMETROS
            );

            /*" -2795- MOVE RELSIN-APOL-SINI TO SI1001S-NUM-APOL-SINISTRO */
            _.Move(RELSIN_APOL_SINI, LBSI1001.SI1001S_PARAMETROS.SI1001S_ENTRADA.SI1001S_NUM_APOL_SINISTRO);

            /*" -2797- CALL SI1023S USING SI1001S-PARAMETROS */
            _.Call(SI1023S, LBSI1001.SI1001S_PARAMETROS);

            /*" -2798- IF SI1001S-ERRO-MENSAGEM NOT EQUAL SPACES */

            if (!LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_ERRO_MENSAGEM.IsEmpty())
            {

                /*" -2800- DISPLAY 'PROBLEMA CALL SI1023S ' ' ' RELSIN-APOL-SINI */

                $"PROBLEMA CALL SI1023S  {RELSIN_APOL_SINI}"
                .Display();

                /*" -2801- DISPLAY 'SQLCODE = ' SI1001S-ERRO-SQLCODE */
                _.Display($"SQLCODE = {LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_ERRO_SQLCODE}");

                /*" -2802- DISPLAY SI1001S-ERRO-MENSAGEM */
                _.Display(LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_ERRO_MENSAGEM);

                /*" -2803- GO TO 999-999-ROT-ERRO */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2804- ELSE */
            }
            else
            {


                /*" -2806- MOVE SI1001S-VALOR-CALCULADO TO THIST-VALPRI. */
                _.Move(LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_VALOR_CALCULADO, THIST_VALPRI);
            }


            /*" -2806- MOVE THIST-VALPRI TO SALVADOS-C14. */
            _.Move(THIST_VALPRI, W.SALVADOS_C14);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_185_999_EXIT*/

        [StopWatch]
        /*" M-186-000-ACESSA-PROC-JURID-SECTION */
        private void M_186_000_ACESSA_PROC_JURID_SECTION()
        {
            /*" -2819- MOVE '021' TO WNR-EXEC-SQL */
            _.Move("021", WABEND.WNR_EXEC_SQL);

            /*" -2826- PERFORM M_186_000_ACESSA_PROC_JURID_DB_SELECT_1 */

            M_186_000_ACESSA_PROC_JURID_DB_SELECT_1();

            /*" -2829- IF SQLCODE EQUAL ZERO */

            if (DB.SQLCODE == 00)
            {

                /*" -2830- MOVE SI042-COD-PROCESSO-JURID TO JURID-OCC(WS-IND2) */
                _.Move(SI042.DCLSI_DETALHE_PROC_JURID.SI042_COD_PROCESSO_JURID, W.DETALHE_OCC[W.WS_IND2].JURID_OCC);

                /*" -2831- ELSE */
            }
            else
            {


                /*" -2832- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2833- MOVE SPACES TO JURID-OCC(WS-IND2) */
                    _.Move("", W.DETALHE_OCC[W.WS_IND2].JURID_OCC);

                    /*" -2834- ELSE */
                }
                else
                {


                    /*" -2835- DISPLAY 'ERRO DE ACESSO EM SI_DETALHE_PROC_JURID' */
                    _.Display($"ERRO DE ACESSO EM SI_DETALHE_PROC_JURID");

                    /*" -2836- DISPLAY 'SINISTRO = ' RELSIN-APOL-SINI */
                    _.Display($"SINISTRO = {RELSIN_APOL_SINI}");

                    /*" -2837- DISPLAY 'OCORHIST = ' RELSIN-OCORHIST */
                    _.Display($"OCORHIST = {RELSIN_OCORHIST}");

                    /*" -2838- DISPLAY 'OPERACAO = ' RELSIN-OPERACAO */
                    _.Display($"OPERACAO = {RELSIN_OPERACAO}");

                    /*" -2839- GO TO 999-999-ROT-ERRO */

                    M_999_999_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2840- END-IF */
                }


                /*" -2841- END-IF. */
            }


        }

        [StopWatch]
        /*" M-186-000-ACESSA-PROC-JURID-DB-SELECT-1 */
        public void M_186_000_ACESSA_PROC_JURID_DB_SELECT_1()
        {
            /*" -2826- EXEC SQL SELECT COD_PROCESSO_JURID INTO :SI042-COD-PROCESSO-JURID FROM SEGUROS.SI_DETALHE_PROC_JURID WHERE NUM_APOL_SINISTRO = :RELSIN-APOL-SINI AND OCORR_HISTORICO = :THIST-OCORHIST AND COD_OPERACAO = :THIST-OPERACAO END-EXEC. */

            var m_186_000_ACESSA_PROC_JURID_DB_SELECT_1_Query1 = new M_186_000_ACESSA_PROC_JURID_DB_SELECT_1_Query1()
            {
                RELSIN_APOL_SINI = RELSIN_APOL_SINI.ToString(),
                THIST_OCORHIST = THIST_OCORHIST.ToString(),
                THIST_OPERACAO = THIST_OPERACAO.ToString(),
            };

            var executed_1 = M_186_000_ACESSA_PROC_JURID_DB_SELECT_1_Query1.Execute(m_186_000_ACESSA_PROC_JURID_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SI042_COD_PROCESSO_JURID, SI042.DCLSI_DETALHE_PROC_JURID.SI042_COD_PROCESSO_JURID);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_186_999_EXIT*/

        [StopWatch]
        /*" M-187-000-ULT-MOVIMENTACAO-SECTION */
        private void M_187_000_ULT_MOVIMENTACAO_SECTION()
        {
            /*" -2856- MOVE '187-000-CURSOR-THISTSIN' TO PARAGRAFO. */
            _.Move("187-000-CURSOR-THISTSIN", WABEND.PARAGRAFO);

            /*" -2859- MOVE '022' TO WNR-EXEC-SQL. */
            _.Move("022", WABEND.WNR_EXEC_SQL);

            /*" -2876- PERFORM M_187_000_ULT_MOVIMENTACAO_DB_DECLARE_1 */

            M_187_000_ULT_MOVIMENTACAO_DB_DECLARE_1();

            /*" -2878- PERFORM M_187_000_ULT_MOVIMENTACAO_DB_OPEN_1 */

            M_187_000_ULT_MOVIMENTACAO_DB_OPEN_1();

            /*" -2887- PERFORM M_187_000_ULT_MOVIMENTACAO_DB_FETCH_1 */

            M_187_000_ULT_MOVIMENTACAO_DB_FETCH_1();

            /*" -2889- PERFORM M_187_000_ULT_MOVIMENTACAO_DB_CLOSE_1 */

            M_187_000_ULT_MOVIMENTACAO_DB_CLOSE_1();

        }

        [StopWatch]
        /*" M-187-000-ULT-MOVIMENTACAO-DB-OPEN-1 */
        public void M_187_000_ULT_MOVIMENTACAO_DB_OPEN_1()
        {
            /*" -2878- EXEC SQL OPEN V1HISTSIN2 END-EXEC. */

            V1HISTSIN2.Open();

        }

        [StopWatch]
        /*" M-300-000-CURSOR-TAPDCORR-DB-DECLARE-1 */
        public void M_300_000_CURSOR_TAPDCORR_DB_DECLARE_1()
        {
            /*" -3157- EXEC SQL DECLARE V1APOLCORRET CURSOR FOR SELECT CODCORR, NUM_APOLICE FROM SEGUROS.V1APOLCORRET WHERE NUM_APOLICE = :MEST-NUM-APOL AND CODSUBES = :MEST-CODSUBES AND INDCRT = '1' ORDER BY NUM_APOLICE, CODCORR END-EXEC. */
            V1APOLCORRET = new SI0133B_V1APOLCORRET(true);
            string GetQuery_V1APOLCORRET()
            {
                var query = @$"SELECT CODCORR
							, NUM_APOLICE 
							FROM SEGUROS.V1APOLCORRET 
							WHERE NUM_APOLICE = '{MEST_NUM_APOL}' 
							AND CODSUBES = '{MEST_CODSUBES}' 
							AND INDCRT = '1' 
							ORDER BY NUM_APOLICE
							, CODCORR";

                return query;
            }
            V1APOLCORRET.GetQueryEvent += GetQuery_V1APOLCORRET;

        }

        [StopWatch]
        /*" M-187-000-ULT-MOVIMENTACAO-DB-FETCH-1 */
        public void M_187_000_ULT_MOVIMENTACAO_DB_FETCH_1()
        {
            /*" -2887- EXEC SQL FETCH V1HISTSIN2 INTO :THIST-VALPRI4, :THIST-DTMOVTO2, :THIST-OPERACAO2, :THIST-OCORHIST2, :THIST-TIMESTAMP END-EXEC. */

            if (V1HISTSIN2.Fetch())
            {
                _.Move(V1HISTSIN2.THIST_VALPRI4, THIST_VALPRI4);
                _.Move(V1HISTSIN2.THIST_DTMOVTO2, THIST_DTMOVTO2);
                _.Move(V1HISTSIN2.THIST_OPERACAO2, THIST_OPERACAO2);
                _.Move(V1HISTSIN2.THIST_OCORHIST2, THIST_OCORHIST2);
                _.Move(V1HISTSIN2.THIST_TIMESTAMP, THIST_TIMESTAMP);
            }

        }

        [StopWatch]
        /*" M-187-000-ULT-MOVIMENTACAO-DB-CLOSE-1 */
        public void M_187_000_ULT_MOVIMENTACAO_DB_CLOSE_1()
        {
            /*" -2889- EXEC SQL CLOSE V1HISTSIN2 END-EXEC. */

            V1HISTSIN2.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_187_999_EXIT*/

        [StopWatch]
        /*" M-190-000-ACESSA-AVISO-SECTION */
        private void M_190_000_ACESSA_AVISO_SECTION()
        {
            /*" -2903- MOVE '190-000-ACESSA-AVISO' TO PARAGRAFO. */
            _.Move("190-000-ACESSA-AVISO", WABEND.PARAGRAFO);

            /*" -2906- MOVE '023' TO WNR-EXEC-SQL. */
            _.Move("023", WABEND.WNR_EXEC_SQL);

            /*" -2913- PERFORM M_190_000_ACESSA_AVISO_DB_SELECT_1 */

            M_190_000_ACESSA_AVISO_DB_SELECT_1();

            /*" -2916- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -2917- DISPLAY 'SI0133B - NAO HA REGISTRO NA THISTSIN' */
                _.Display($"SI0133B - NAO HA REGISTRO NA THISTSIN");

                /*" -2919- DISPLAY 'NUM_APOL_SINISTRO = ' RELSIN-APOL-SINI ' DTMOVTO = ' RELSIN-DTMOVTO ' OPERACAO = 101' */

                $"NUM_APOL_SINISTRO = {RELSIN_APOL_SINI} DTMOVTO = {RELSIN_DTMOVTO} OPERACAO = 101"
                .Display();

                /*" -2921- GO TO 190-999-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_190_999_EXIT*/ //GOTO
                return;
            }


            /*" -2922- MOVE THIST-VALPRI2 TO VALPRI-C13. */
            _.Move(THIST_VALPRI2, W.VALPRI_C13);

            /*" -2923- MOVE THIST-DTMOVTO1 TO WDATA-R. */
            _.Move(THIST_DTMOVTO1, W.WDATA_R);

            /*" -2924- MOVE WDATA-DD TO WDIA-IMP. */
            _.Move(W.WDATA.WDATA_DD, W.WDATA_IMP.WDIA_IMP);

            /*" -2925- MOVE WDATA-MM TO WMES-IMP. */
            _.Move(W.WDATA.WDATA_MM, W.WDATA_IMP.WMES_IMP);

            /*" -2925- MOVE WDATA-AA TO WANO-IMP. */
            _.Move(W.WDATA.WDATA_AA, W.WDATA_IMP.WANO_IMP);

        }

        [StopWatch]
        /*" M-190-000-ACESSA-AVISO-DB-SELECT-1 */
        public void M_190_000_ACESSA_AVISO_DB_SELECT_1()
        {
            /*" -2913- EXEC SQL SELECT VAL_OPERACAO, DTMOVTO INTO :THIST-VALPRI2, :THIST-DTMOVTO1 FROM SEGUROS.V1HISTSINI WHERE NUM_APOL_SINISTRO = :RELSIN-APOL-SINI AND OPERACAO = 101 END-EXEC. */

            var m_190_000_ACESSA_AVISO_DB_SELECT_1_Query1 = new M_190_000_ACESSA_AVISO_DB_SELECT_1_Query1()
            {
                RELSIN_APOL_SINI = RELSIN_APOL_SINI.ToString(),
            };

            var executed_1 = M_190_000_ACESSA_AVISO_DB_SELECT_1_Query1.Execute(m_190_000_ACESSA_AVISO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.THIST_VALPRI2, THIST_VALPRI2);
                _.Move(executed_1.THIST_DTMOVTO1, THIST_DTMOVTO1);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_190_999_EXIT*/

        [StopWatch]
        /*" M-200-000-ACESSA-OPERACAO-SECTION */
        private void M_200_000_ACESSA_OPERACAO_SECTION()
        {
            /*" -2935- MOVE '200-000-ACESSA-OPERACAO' TO PARAGRAFO. */
            _.Move("200-000-ACESSA-OPERACAO", WABEND.PARAGRAFO);

            /*" -2937- MOVE '200' TO WNR-EXEC-SQL. */
            _.Move("200", WABEND.WNR_EXEC_SQL);

            /*" -2943- PERFORM M_200_000_ACESSA_OPERACAO_DB_SELECT_1 */

            M_200_000_ACESSA_OPERACAO_DB_SELECT_1();

            /*" -2946- IF SQLCODE NOT EQUAL ZEROS AND SQLCODE NOT EQUAL 100 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != 100)
            {

                /*" -2947- DISPLAY '/////////////////////////////////////////////////' */
                _.Display($"/////////////////////////////////////////////////");

                /*" -2948- DISPLAY 'SI0133B - ERRO ACESSO A TABELA GE_OPERACAO' */
                _.Display($"SI0133B - ERRO ACESSO A TABELA GE_OPERACAO");

                /*" -2949- DISPLAY 'OPERACAO = ' GEOPERAC-COD-OPERACAO */
                _.Display($"OPERACAO = {GEOPERAC.DCLGE_OPERACAO.GEOPERAC_COD_OPERACAO}");

                /*" -2950- DISPLAY '/////////////////////////////////////////////////' */
                _.Display($"/////////////////////////////////////////////////");

                /*" -2951- GO TO 999-999-ROT-ERRO */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2953- END-IF */
            }


            /*" -2954- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -2955- MOVE ALL 'X' TO GEOPERAC-DES-OPERACAO */
                _.MoveAll("X", GEOPERAC.DCLGE_OPERACAO.GEOPERAC_DES_OPERACAO);

                /*" -2956- DISPLAY '/////////////////////////////' */
                _.Display($"/////////////////////////////");

                /*" -2957- DISPLAY 'OPERACAO NAO CADASTRADA' */
                _.Display($"OPERACAO NAO CADASTRADA");

                /*" -2958- DISPLAY 'OPERACAO = ' GEOPERAC-COD-OPERACAO */
                _.Display($"OPERACAO = {GEOPERAC.DCLGE_OPERACAO.GEOPERAC_COD_OPERACAO}");

                /*" -2959- DISPLAY '/////////////////////////////' */
                _.Display($"/////////////////////////////");

                /*" -2959- END-IF. */
            }


        }

        [StopWatch]
        /*" M-200-000-ACESSA-OPERACAO-DB-SELECT-1 */
        public void M_200_000_ACESSA_OPERACAO_DB_SELECT_1()
        {
            /*" -2943- EXEC SQL SELECT DES_OPERACAO INTO :GEOPERAC-DES-OPERACAO FROM SEGUROS.GE_OPERACAO WHERE IDE_SISTEMA = 'SI' AND COD_OPERACAO = :GEOPERAC-COD-OPERACAO END-EXEC */

            var m_200_000_ACESSA_OPERACAO_DB_SELECT_1_Query1 = new M_200_000_ACESSA_OPERACAO_DB_SELECT_1_Query1()
            {
                GEOPERAC_COD_OPERACAO = GEOPERAC.DCLGE_OPERACAO.GEOPERAC_COD_OPERACAO.ToString(),
            };

            var executed_1 = M_200_000_ACESSA_OPERACAO_DB_SELECT_1_Query1.Execute(m_200_000_ACESSA_OPERACAO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.GEOPERAC_DES_OPERACAO, GEOPERAC.DCLGE_OPERACAO.GEOPERAC_DES_OPERACAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_200_999_EXIT*/

        [StopWatch]
        /*" M-220-000-LER-TGEFONTE-SECTION */
        private void M_220_000_LER_TGEFONTE_SECTION()
        {
            /*" -2965- SET I01 TO WZEROS. */
            I01.Value = W.WZEROS;

            /*" -0- FLUXCONTROL_PERFORM M_220_100_LOOP */

            M_220_100_LOOP();

        }

        [StopWatch]
        /*" M-220-100-LOOP */
        private void M_220_100_LOOP(bool isPerform = false)
        {
            /*" -2971- SET I01 UP BY WHUM. */
            I01.Value += W.WHUM;

            /*" -2972- IF I01 GREATER 100 */

            if (I01 > 100)
            {

                /*" -2973- DISPLAY 'SI0133B - ESTOURO DE TABELA INTERNA DE FONTE' */
                _.Display($"SI0133B - ESTOURO DE TABELA INTERNA DE FONTE");

                /*" -2975- GO TO 220-200-ACESSA-TGEFONTE. */

                M_220_200_ACESSA_TGEFONTE(); //GOTO
                return;
            }


            /*" -2976- IF WTABG-NOMEFTE (I01) EQUAL SPACES */

            if (W.WTABG_FONTES.WTABG_FONTE_ZERA.WTABG_FONTEGRUPO.WTABG_OCORREFONTE[I01].WTABG_NOMEFTE == string.Empty)
            {

                /*" -2978- GO TO 220-200-ACESSA-TGEFONTE. */

                M_220_200_ACESSA_TGEFONTE(); //GOTO
                return;
            }


            /*" -2979- IF MEST-FONTE EQUAL WTABG-FONTE (I01) */

            if (MEST_FONTE == W.WTABG_FONTES.WTABG_FONTE_ZERA.WTABG_FONTEGRUPO.WTABG_OCORREFONTE[I01].WTABG_FONTE)
            {

                /*" -2980- MOVE WTABG-NOMEFTE (I01) TO FONTE-NOMEFTE */
                _.Move(W.WTABG_FONTES.WTABG_FONTE_ZERA.WTABG_FONTEGRUPO.WTABG_OCORREFONTE[I01].WTABG_NOMEFTE, FONTE_NOMEFTE);

                /*" -2981- GO TO 220-999-EXIT */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_220_999_EXIT*/ //GOTO
                return;

                /*" -2982- ELSE */
            }
            else
            {


                /*" -2982- GO TO 220-100-LOOP. */
                new Task(() => M_220_100_LOOP()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


        }

        [StopWatch]
        /*" M-220-200-ACESSA-TGEFONTE */
        private void M_220_200_ACESSA_TGEFONTE(bool isPerform = false)
        {
            /*" -2988- MOVE '024' TO WNR-EXEC-SQL. */
            _.Move("024", WABEND.WNR_EXEC_SQL);

            /*" -2993- PERFORM M_220_200_ACESSA_TGEFONTE_DB_SELECT_1 */

            M_220_200_ACESSA_TGEFONTE_DB_SELECT_1();

            /*" -2996- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -2997- DISPLAY 'SI0133B-FONTE NAO CADASTRADA' */
                _.Display($"SI0133B-FONTE NAO CADASTRADA");

                /*" -2998- DISPLAY 'FONTE   = ' MEST-FONTE */
                _.Display($"FONTE   = {MEST_FONTE}");

                /*" -2999- MOVE ' ' TO FONTE-NOMEFTE */
                _.Move(" ", FONTE_NOMEFTE);

                /*" -3000- ELSE */
            }
            else
            {


                /*" -3001- IF I01 NOT GREATER 100 */

                if (I01 <= 100)
                {

                    /*" -3002- MOVE MEST-FONTE TO WTABG-FONTE (I01) */
                    _.Move(MEST_FONTE, W.WTABG_FONTES.WTABG_FONTE_ZERA.WTABG_FONTEGRUPO.WTABG_OCORREFONTE[I01].WTABG_FONTE);

                    /*" -3002- MOVE FONTE-NOMEFTE TO WTABG-NOMEFTE (I01). */
                    _.Move(FONTE_NOMEFTE, W.WTABG_FONTES.WTABG_FONTE_ZERA.WTABG_FONTEGRUPO.WTABG_OCORREFONTE[I01].WTABG_NOMEFTE);
                }

            }


        }

        [StopWatch]
        /*" M-220-200-ACESSA-TGEFONTE-DB-SELECT-1 */
        public void M_220_200_ACESSA_TGEFONTE_DB_SELECT_1()
        {
            /*" -2993- EXEC SQL SELECT NOMEFTE INTO :FONTE-NOMEFTE FROM SEGUROS.V1FONTE WHERE FONTE = :MEST-FONTE END-EXEC. */

            var m_220_200_ACESSA_TGEFONTE_DB_SELECT_1_Query1 = new M_220_200_ACESSA_TGEFONTE_DB_SELECT_1_Query1()
            {
                MEST_FONTE = MEST_FONTE.ToString(),
            };

            var executed_1 = M_220_200_ACESSA_TGEFONTE_DB_SELECT_1_Query1.Execute(m_220_200_ACESSA_TGEFONTE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.FONTE_NOMEFTE, FONTE_NOMEFTE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_220_999_EXIT*/

        [StopWatch]
        /*" M-230-000-LER-TGERAMO-SECTION */
        private void M_230_000_LER_TGERAMO_SECTION()
        {
            /*" -3008- SET I02 TO WZEROS. */
            I02.Value = W.WZEROS;

            /*" -0- FLUXCONTROL_PERFORM M_230_100_LOOP */

            M_230_100_LOOP();

        }

        [StopWatch]
        /*" M-230-100-LOOP */
        private void M_230_100_LOOP(bool isPerform = false)
        {
            /*" -3014- SET I02 UP BY WHUM. */
            I02.Value += W.WHUM;

            /*" -3015- IF I02 GREATER 200 */

            if (I02 > 200)
            {

                /*" -3016- DISPLAY 'SI0133B - ESTOURO DE TABELA INTERNA DE RAMO' */
                _.Display($"SI0133B - ESTOURO DE TABELA INTERNA DE RAMO");

                /*" -3018- GO TO 230-200-ACESSA-TGERAMO. */

                M_230_200_ACESSA_TGERAMO(); //GOTO
                return;
            }


            /*" -3019- IF WTABG-NOMERAMO (I02) EQUAL SPACES */

            if (W.WTABG_RAMOS.WTABG_RAMO_ZERA.WTABG_RAMOGRUPO.WTABG_OCORRERAMO[I02].WTABG_NOMERAMO == string.Empty)
            {

                /*" -3021- GO TO 230-200-ACESSA-TGERAMO. */

                M_230_200_ACESSA_TGERAMO(); //GOTO
                return;
            }


            /*" -3022- IF MEST-RAMO EQUAL WTABG-RAMO (I02) */

            if (MEST_RAMO == W.WTABG_RAMOS.WTABG_RAMO_ZERA.WTABG_RAMOGRUPO.WTABG_OCORRERAMO[I02].WTABG_RAMO)
            {

                /*" -3023- MOVE WTABG-NOMERAMO (I02) TO NOMERAMO-C04 */
                _.Move(W.WTABG_RAMOS.WTABG_RAMO_ZERA.WTABG_RAMOGRUPO.WTABG_OCORRERAMO[I02].WTABG_NOMERAMO, W.CAB04.NOMERAMO_C04);

                /*" -3024- GO TO 230-999-EXIT */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_230_999_EXIT*/ //GOTO
                return;

                /*" -3025- ELSE */
            }
            else
            {


                /*" -3025- GO TO 230-100-LOOP. */
                new Task(() => M_230_100_LOOP()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


        }

        [StopWatch]
        /*" M-230-200-ACESSA-TGERAMO */
        private void M_230_200_ACESSA_TGERAMO(bool isPerform = false)
        {
            /*" -3031- MOVE '025' TO WNR-EXEC-SQL. */
            _.Move("025", WABEND.WNR_EXEC_SQL);

            /*" -3037- PERFORM M_230_200_ACESSA_TGERAMO_DB_SELECT_1 */

            M_230_200_ACESSA_TGERAMO_DB_SELECT_1();

            /*" -3040- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -3041- DISPLAY 'SI0133B-RAMO NAO CADASTRADA' */
                _.Display($"SI0133B-RAMO NAO CADASTRADA");

                /*" -3042- DISPLAY 'RAMO   = ' MEST-RAMO ' MODALIDA = 0' */

                $"RAMO   = {MEST_RAMO} MODALIDA = 0"
                .Display();

                /*" -3043- MOVE ' ' TO NOMERAMO-C04 */
                _.Move(" ", W.CAB04.NOMERAMO_C04);

                /*" -3044- ELSE */
            }
            else
            {


                /*" -3045- IF I02 NOT GREATER 100 */

                if (I02 <= 100)
                {

                    /*" -3046- MOVE MEST-RAMO TO WTABG-RAMO (I02) */
                    _.Move(MEST_RAMO, W.WTABG_RAMOS.WTABG_RAMO_ZERA.WTABG_RAMOGRUPO.WTABG_OCORRERAMO[I02].WTABG_RAMO);

                    /*" -3048- MOVE GERAMO-NOMERAMO TO WTABG-NOMERAMO (I02). */
                    _.Move(GERAMO_NOMERAMO, W.WTABG_RAMOS.WTABG_RAMO_ZERA.WTABG_RAMOGRUPO.WTABG_OCORRERAMO[I02].WTABG_NOMERAMO);
                }

            }


            /*" -3048- MOVE GERAMO-NOMERAMO TO NOMERAMO-C04. */
            _.Move(GERAMO_NOMERAMO, W.CAB04.NOMERAMO_C04);

        }

        [StopWatch]
        /*" M-230-200-ACESSA-TGERAMO-DB-SELECT-1 */
        public void M_230_200_ACESSA_TGERAMO_DB_SELECT_1()
        {
            /*" -3037- EXEC SQL SELECT NOMERAMO INTO :GERAMO-NOMERAMO FROM SEGUROS.V1RAMO WHERE RAMO = :MEST-RAMO AND MODALIDA = 0 END-EXEC. */

            var m_230_200_ACESSA_TGERAMO_DB_SELECT_1_Query1 = new M_230_200_ACESSA_TGERAMO_DB_SELECT_1_Query1()
            {
                MEST_RAMO = MEST_RAMO.ToString(),
            };

            var executed_1 = M_230_200_ACESSA_TGERAMO_DB_SELECT_1_Query1.Execute(m_230_200_ACESSA_TGERAMO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.GERAMO_NOMERAMO, GERAMO_NOMERAMO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_230_999_EXIT*/

        [StopWatch]
        /*" M-240-000-LER-TAPOLICE-SECTION */
        private void M_240_000_LER_TAPOLICE_SECTION()
        {
            /*" -3056- MOVE '026' TO WNR-EXEC-SQL. */
            _.Move("026", WABEND.WNR_EXEC_SQL);

            /*" -3063- PERFORM M_240_000_LER_TAPOLICE_DB_SELECT_1 */

            M_240_000_LER_TAPOLICE_DB_SELECT_1();

            /*" -3066- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -3068- DISPLAY 'SI0133B - NAO HA REGISTRO NA TAQPOLICE CORRESPOND 'ENTE AO TMESTSIN' */

                $"SI0133B - NAO HA REGISTRO NA TAQPOLICE CORRESPOND ENTEAOTMESTSIN"
                .Display();

                /*" -3071- DISPLAY 'NUM_APOLICE = ' MEST-NUM-APOL 'NRENDOS     = ' MEST-NRENDOS 'CODSUBES    = ' MEST-CODSUBES */

                $"NUM_APOLICE = {MEST_NUM_APOL}NRENDOS     = {MEST_NRENDOS}CODSUBES    = {MEST_CODSUBES}"
                .Display();

                /*" -3072- MOVE SPACES TO APOL-NOME */
                _.Move("", APOL_NOME);

                /*" -3073- MOVE ZEROS TO APOL-PCTCED */
                _.Move(0, APOL_PCTCED);

                /*" -3074- ELSE */
            }
            else
            {


                /*" -3076- PERFORM 241-000-LER-APOLCOSCED. */

                M_241_000_LER_APOLCOSCED_SECTION();
            }


            /*" -3077- MOVE APOL-PCTCED TO PCPARTIC-C11. */
            _.Move(APOL_PCTCED, W.CAB11.PCPARTIC_C11);

            /*" -3078- MOVE GEUNIMO-SIGLUNIM TO CORRECAO-C05. */
            _.Move(GEUNIMO_SIGLUNIM, W.CAB03.CORRECAO_C05);

            /*" -3078- MOVE APOL-NOME TO NOME-APOLICE. */
            _.Move(APOL_NOME, W.CAB05.NOME_APOLICE);

        }

        [StopWatch]
        /*" M-240-000-LER-TAPOLICE-DB-SELECT-1 */
        public void M_240_000_LER_TAPOLICE_DB_SELECT_1()
        {
            /*" -3063- EXEC SQL SELECT NOME, PCTCED INTO :APOL-NOME, :APOL-PCTCED FROM SEGUROS.V1APOLICE WHERE NUM_APOLICE = :MEST-NUM-APOL END-EXEC. */

            var m_240_000_LER_TAPOLICE_DB_SELECT_1_Query1 = new M_240_000_LER_TAPOLICE_DB_SELECT_1_Query1()
            {
                MEST_NUM_APOL = MEST_NUM_APOL.ToString(),
            };

            var executed_1 = M_240_000_LER_TAPOLICE_DB_SELECT_1_Query1.Execute(m_240_000_LER_TAPOLICE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.APOL_NOME, APOL_NOME);
                _.Move(executed_1.APOL_PCTCED, APOL_PCTCED);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_240_999_EXIT*/

        [StopWatch]
        /*" M-241-000-LER-APOLCOSCED-SECTION */
        private void M_241_000_LER_APOLCOSCED_SECTION()
        {
            /*" -3086- MOVE '027' TO WNR-EXEC-SQL. */
            _.Move("027", WABEND.WNR_EXEC_SQL);

            /*" -3093- PERFORM M_241_000_LER_APOLCOSCED_DB_SELECT_1 */

            M_241_000_LER_APOLCOSCED_DB_SELECT_1();

            /*" -3096- IF WPCPARTIC-IND NOT EQUAL ZEROS */

            if (WPCPARTIC_IND != 00)
            {

                /*" -3097- MOVE ZEROS TO APOL-PCTCED */
                _.Move(0, APOL_PCTCED);

                /*" -3098- ELSE */
            }
            else
            {


                /*" -3098- MOVE COSS-PCPARTIC TO APOL-PCTCED. */
                _.Move(COSS_PCPARTIC, APOL_PCTCED);
            }


        }

        [StopWatch]
        /*" M-241-000-LER-APOLCOSCED-DB-SELECT-1 */
        public void M_241_000_LER_APOLCOSCED_DB_SELECT_1()
        {
            /*" -3093- EXEC SQL SELECT SUM(PCPARTIC) INTO :COSS-PCPARTIC:WPCPARTIC-IND FROM SEGUROS.V1APOLCOSCED WHERE NUM_APOLICE = :MEST-NUM-APOL AND DTINIVIG <= :MEST-DATORR AND DTTERVIG >= :MEST-DATORR END-EXEC. */

            var m_241_000_LER_APOLCOSCED_DB_SELECT_1_Query1 = new M_241_000_LER_APOLCOSCED_DB_SELECT_1_Query1()
            {
                MEST_NUM_APOL = MEST_NUM_APOL.ToString(),
                MEST_DATORR = MEST_DATORR.ToString(),
            };

            var executed_1 = M_241_000_LER_APOLCOSCED_DB_SELECT_1_Query1.Execute(m_241_000_LER_APOLCOSCED_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.COSS_PCPARTIC, COSS_PCPARTIC);
                _.Move(executed_1.WPCPARTIC_IND, WPCPARTIC_IND);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_241_999_EXIT*/

        [StopWatch]
        /*" M-270-000-LER-TENDOSSO-SECTION */
        private void M_270_000_LER_TENDOSSO_SECTION()
        {
            /*" -3106- MOVE '028' TO WNR-EXEC-SQL. */
            _.Move("028", WABEND.WNR_EXEC_SQL);

            /*" -3116- PERFORM M_270_000_LER_TENDOSSO_DB_SELECT_1 */

            M_270_000_LER_TENDOSSO_DB_SELECT_1();

            /*" -3119- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -3120- DISPLAY 'SI0133B - NAO EXISTE TENDOSSO CORRESP. AO TMESTSIN' */
                _.Display($"SI0133B - NAO EXISTE TENDOSSO CORRESP. AO TMESTSIN");

                /*" -3122- DISPLAY 'NUM_APOLICE = ' MEST-NUM-APOL 'NRENDOS     = ' MEST-NRENDOS */

                $"NUM_APOLICE = {MEST_NUM_APOL}NRENDOS     = {MEST_NRENDOS}"
                .Display();

                /*" -3123- MOVE 0 TO ENDOS-DTINIVIG */
                _.Move(0, ENDOS_DTINIVIG);

                /*" -3124- MOVE 0 TO ENDOS-DTTERVIG */
                _.Move(0, ENDOS_DTTERVIG);

                /*" -3125- MOVE 0 TO ENDOS-QTPARCEL */
                _.Move(0, ENDOS_QTPARCEL);

                /*" -3126- MOVE 0 TO ENDOS-FONTE */
                _.Move(0, ENDOS_FONTE);

                /*" -3128- MOVE '0' TO ENDOS-SITUACAO. */
                _.Move("0", ENDOS_SITUACAO);
            }


            /*" -3129- MOVE ENDOS-DTINIVIG TO WDATA-R. */
            _.Move(ENDOS_DTINIVIG, W.WDATA_R);

            /*" -3130- MOVE WDATA-DD TO WDIA-IMP. */
            _.Move(W.WDATA.WDATA_DD, W.WDATA_IMP.WDIA_IMP);

            /*" -3131- MOVE WDATA-MM TO WMES-IMP. */
            _.Move(W.WDATA.WDATA_MM, W.WDATA_IMP.WMES_IMP);

            /*" -3132- MOVE WDATA-AA TO WANO-IMP. */
            _.Move(W.WDATA.WDATA_AA, W.WDATA_IMP.WANO_IMP);

            /*" -3133- MOVE ENDOS-DTTERVIG TO WDATA-R. */
            _.Move(ENDOS_DTTERVIG, W.WDATA_R);

            /*" -3134- MOVE WDATA-DD TO WDIA-IMP. */
            _.Move(W.WDATA.WDATA_DD, W.WDATA_IMP.WDIA_IMP);

            /*" -3135- MOVE WDATA-MM TO WMES-IMP. */
            _.Move(W.WDATA.WDATA_MM, W.WDATA_IMP.WMES_IMP);

            /*" -3136- MOVE WDATA-AA TO WANO-IMP. */
            _.Move(W.WDATA.WDATA_AA, W.WDATA_IMP.WANO_IMP);

            /*" -3138- MOVE ENDOS-QTPARCEL TO QTPARCEL-C32. */
            _.Move(ENDOS_QTPARCEL, W.CAB32.QTPARCEL_C32);

            /*" -3139- IF ENDOS-SITUACAO EQUAL '0' OR '1' */

            if (ENDOS_SITUACAO.In("0", "1"))
            {

                /*" -3140- MOVE 'PENDENTE' TO SITUACAO-C04 */
                _.Move("PENDENTE", W.CAB04.SITUACAO_C04);

                /*" -3141- ELSE */
            }
            else
            {


                /*" -3142- IF ENDOS-SITUACAO EQUAL '2' */

                if (ENDOS_SITUACAO == "2")
                {

                    /*" -3142- MOVE 'CANCELADO' TO SITUACAO-C04. */
                    _.Move("CANCELADO", W.CAB04.SITUACAO_C04);
                }

            }


        }

        [StopWatch]
        /*" M-270-000-LER-TENDOSSO-DB-SELECT-1 */
        public void M_270_000_LER_TENDOSSO_DB_SELECT_1()
        {
            /*" -3116- EXEC SQL SELECT DTINIVIG, DTTERVIG, QTPARCEL, SITUACAO, FONTE INTO :ENDOS-DTINIVIG, :ENDOS-DTTERVIG, :ENDOS-QTPARCEL, :ENDOS-SITUACAO, :ENDOS-FONTE FROM SEGUROS.V1ENDOSSO WHERE NUM_APOLICE = :MEST-NUM-APOL AND NRENDOS = :MEST-NRENDOS END-EXEC. */

            var m_270_000_LER_TENDOSSO_DB_SELECT_1_Query1 = new M_270_000_LER_TENDOSSO_DB_SELECT_1_Query1()
            {
                MEST_NUM_APOL = MEST_NUM_APOL.ToString(),
                MEST_NRENDOS = MEST_NRENDOS.ToString(),
            };

            var executed_1 = M_270_000_LER_TENDOSSO_DB_SELECT_1_Query1.Execute(m_270_000_LER_TENDOSSO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.ENDOS_DTINIVIG, ENDOS_DTINIVIG);
                _.Move(executed_1.ENDOS_DTTERVIG, ENDOS_DTTERVIG);
                _.Move(executed_1.ENDOS_QTPARCEL, ENDOS_QTPARCEL);
                _.Move(executed_1.ENDOS_SITUACAO, ENDOS_SITUACAO);
                _.Move(executed_1.ENDOS_FONTE, ENDOS_FONTE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_270_999_EXIT*/

        [StopWatch]
        /*" M-300-000-CURSOR-TAPDCORR-SECTION */
        private void M_300_000_CURSOR_TAPDCORR_SECTION()
        {
            /*" -3150- MOVE '029' TO WNR-EXEC-SQL. */
            _.Move("029", WABEND.WNR_EXEC_SQL);

            /*" -3157- PERFORM M_300_000_CURSOR_TAPDCORR_DB_DECLARE_1 */

            M_300_000_CURSOR_TAPDCORR_DB_DECLARE_1();

            /*" -3159- PERFORM M_300_000_CURSOR_TAPDCORR_DB_OPEN_1 */

            M_300_000_CURSOR_TAPDCORR_DB_OPEN_1();

        }

        [StopWatch]
        /*" M-300-000-CURSOR-TAPDCORR-DB-OPEN-1 */
        public void M_300_000_CURSOR_TAPDCORR_DB_OPEN_1()
        {
            /*" -3159- EXEC SQL OPEN V1APOLCORRET END-EXEC. */

            V1APOLCORRET.Open();

        }

        [StopWatch]
        /*" M-400-000-CURSOR-THISTSIN-RESERV-DB-DECLARE-1 */
        public void M_400_000_CURSOR_THISTSIN_RESERV_DB_DECLARE_1()
        {
            /*" -3320- EXEC SQL DECLARE RESERVA CURSOR FOR SELECT OPERACAO, VAL_OPERACAO FROM SEGUROS.V1HISTSINI WHERE NUM_APOL_SINISTRO = :RELSIN-APOL-SINI AND OPERACAO IN (102, 103, 105, 106, 112, 113, 115, 116, 122, 123) END-EXEC. */
            RESERVA = new SI0133B_RESERVA(true);
            string GetQuery_RESERVA()
            {
                var query = @$"SELECT OPERACAO
							, VAL_OPERACAO 
							FROM SEGUROS.V1HISTSINI 
							WHERE NUM_APOL_SINISTRO = '{RELSIN_APOL_SINI}' 
							AND OPERACAO IN (102
							, 103
							, 105
							, 106
							, 
							112
							, 113
							, 115
							, 116
							, 
							122
							, 123)";

                return query;
            }
            RESERVA.GetQueryEvent += GetQuery_RESERVA;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_300_999_EXIT*/

        [StopWatch]
        /*" M-330-000-LER-TAPDCORR-SECTION */
        private void M_330_000_LER_TAPDCORR_SECTION()
        {
            /*" -3167- MOVE '030' TO WNR-EXEC-SQL. */
            _.Move("030", WABEND.WNR_EXEC_SQL);

            /*" -3169- PERFORM M_330_000_LER_TAPDCORR_DB_FETCH_1 */

            M_330_000_LER_TAPDCORR_DB_FETCH_1();

            /*" -3172- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -3173- DISPLAY 'SI0133B - NAO HA TAPDCORR CORRESPOND. AO TMESTSIN' */
                _.Display($"SI0133B - NAO HA TAPDCORR CORRESPOND. AO TMESTSIN");

                /*" -3174- DISPLAY 'NUM_APOLICE = ' MEST-NUM-APOL */
                _.Display($"NUM_APOLICE = {MEST_NUM_APOL}");

                /*" -3175- MOVE ZEROS TO APDCORR-CODCORR APDCORR-NUM-APOL */
                _.Move(0, APDCORR_CODCORR, APDCORR_NUM_APOL);

                /*" -3176- MOVE 'NAO' TO W-CHAVE-ACHOU-APOLCORRET */
                _.Move("NAO", W.W_CHAVE_ACHOU_APOLCORRET);

                /*" -3176- PERFORM M_330_000_LER_TAPDCORR_DB_CLOSE_1 */

                M_330_000_LER_TAPDCORR_DB_CLOSE_1();

                /*" -3178- GO TO 330-999-EXIT */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_330_999_EXIT*/ //GOTO
                return;

                /*" -3179- ELSE */
            }
            else
            {


                /*" -3180- MOVE ZEROS TO SQLCODE */
                _.Move(0, DB.SQLCODE);

                /*" -3180- PERFORM M_330_000_LER_TAPDCORR_DB_CLOSE_2 */

                M_330_000_LER_TAPDCORR_DB_CLOSE_2();

                /*" -3181- END-IF. */
            }


        }

        [StopWatch]
        /*" M-330-000-LER-TAPDCORR-DB-FETCH-1 */
        public void M_330_000_LER_TAPDCORR_DB_FETCH_1()
        {
            /*" -3169- EXEC SQL FETCH V1APOLCORRET INTO :APDCORR-CODCORR, :APDCORR-NUM-APOL END-EXEC. */

            if (V1APOLCORRET.Fetch())
            {
                _.Move(V1APOLCORRET.APDCORR_CODCORR, APDCORR_CODCORR);
                _.Move(V1APOLCORRET.APDCORR_NUM_APOL, APDCORR_NUM_APOL);
            }

        }

        [StopWatch]
        /*" M-330-000-LER-TAPDCORR-DB-CLOSE-1 */
        public void M_330_000_LER_TAPDCORR_DB_CLOSE_1()
        {
            /*" -3176- EXEC SQL CLOSE V1APOLCORRET END-EXEC */

            V1APOLCORRET.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_330_999_EXIT*/

        [StopWatch]
        /*" M-330-000-LER-TAPDCORR-DB-CLOSE-2 */
        public void M_330_000_LER_TAPDCORR_DB_CLOSE_2()
        {
            /*" -3180- EXEC SQL CLOSE V1APOLCORRET END-EXEC */

            V1APOLCORRET.Close();

        }

        [StopWatch]
        /*" M-360-000-LER-PRODUTOR-SECTION */
        private void M_360_000_LER_PRODUTOR_SECTION()
        {
            /*" -3187- SET I03 TO WZEROS. */
            I03.Value = W.WZEROS;

            /*" -0- FLUXCONTROL_PERFORM M_360_100_LOOP */

            M_360_100_LOOP();

        }

        [StopWatch]
        /*" M-360-100-LOOP */
        private void M_360_100_LOOP(bool isPerform = false)
        {
            /*" -3193- SET I03 UP BY WHUM. */
            I03.Value += W.WHUM;

            /*" -3194- IF I03 GREATER 400 */

            if (I03 > 400)
            {

                /*" -3195- DISPLAY 'SI0133B - ESTOURO DE TABELA INTERNA DE CORRETOR' */
                _.Display($"SI0133B - ESTOURO DE TABELA INTERNA DE CORRETOR");

                /*" -3197- GO TO 360-200-ACESSA-PRODUTOR. */

                M_360_200_ACESSA_PRODUTOR(); //GOTO
                return;
            }


            /*" -3198- IF WTABG-NOMPDT (I03) EQUAL SPACES */

            if (W.WTABG_CORRETORES.WTABG_CORRET_ZERA.WTABG_CORRETGRUPO.WTABG_OCORRECORRET[I03].WTABG_NOMPDT == string.Empty)
            {

                /*" -3200- GO TO 360-200-ACESSA-PRODUTOR. */

                M_360_200_ACESSA_PRODUTOR(); //GOTO
                return;
            }


            /*" -3202- IF APDCORR-CODCORR EQUAL WTABG-CODPDT (I03) AND ENDOS-FONTE EQUAL WTABG-FONTE1 (I03) */

            if (APDCORR_CODCORR == W.WTABG_CORRETORES.WTABG_CORRET_ZERA.WTABG_CORRETGRUPO.WTABG_OCORRECORRET[I03].WTABG_CODPDT && ENDOS_FONTE == W.WTABG_CORRETORES.WTABG_CORRET_ZERA.WTABG_CORRETGRUPO.WTABG_OCORRECORRET[I03].WTABG_FONTE1)
            {

                /*" -3203- MOVE WTABG-NOMPDT (I03) TO NOMPDT-C10 */
                _.Move(W.WTABG_CORRETORES.WTABG_CORRET_ZERA.WTABG_CORRETGRUPO.WTABG_OCORRECORRET[I03].WTABG_NOMPDT, W.CAB11.NOMPDT_C10);

                /*" -3204- GO TO 360-999-EXIT */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_360_999_EXIT*/ //GOTO
                return;

                /*" -3205- ELSE */
            }
            else
            {


                /*" -3205- GO TO 360-100-LOOP. */
                new Task(() => M_360_100_LOOP()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


        }

        [StopWatch]
        /*" M-360-200-ACESSA-PRODUTOR */
        private void M_360_200_ACESSA_PRODUTOR(bool isPerform = false)
        {
            /*" -3212- MOVE '031' TO WNR-EXEC-SQL. */
            _.Move("031", WABEND.WNR_EXEC_SQL);

            /*" -3218- PERFORM M_360_200_ACESSA_PRODUTOR_DB_SELECT_1 */

            M_360_200_ACESSA_PRODUTOR_DB_SELECT_1();

            /*" -3221- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -3222- MOVE ' ' TO NOMPDT-C10 */
                _.Move(" ", W.CAB11.NOMPDT_C10);

                /*" -3223- GO TO 360-999-EXIT */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_360_999_EXIT*/ //GOTO
                return;

                /*" -3224- ELSE */
            }
            else
            {


                /*" -3225- IF I03 NOT GREATER 400 */

                if (I03 <= 400)
                {

                    /*" -3226- MOVE APDCORR-CODCORR TO WTABG-CODPDT (I03) */
                    _.Move(APDCORR_CODCORR, W.WTABG_CORRETORES.WTABG_CORRET_ZERA.WTABG_CORRETGRUPO.WTABG_OCORRECORRET[I03].WTABG_CODPDT);

                    /*" -3228- MOVE PROD-NOMPDT TO WTABG-NOMPDT (I03). */
                    _.Move(PROD_NOMPDT, W.WTABG_CORRETORES.WTABG_CORRET_ZERA.WTABG_CORRETGRUPO.WTABG_OCORRECORRET[I03].WTABG_NOMPDT);
                }

            }


            /*" -3229- MOVE ENDOS-FONTE TO WTABG-FONTE1 (I03). */
            _.Move(ENDOS_FONTE, W.WTABG_CORRETORES.WTABG_CORRET_ZERA.WTABG_CORRETGRUPO.WTABG_OCORRECORRET[I03].WTABG_FONTE1);

            /*" -3229- MOVE PROD-NOMPDT TO NOMPDT-C10. */
            _.Move(PROD_NOMPDT, W.CAB11.NOMPDT_C10);

        }

        [StopWatch]
        /*" M-360-200-ACESSA-PRODUTOR-DB-SELECT-1 */
        public void M_360_200_ACESSA_PRODUTOR_DB_SELECT_1()
        {
            /*" -3218- EXEC SQL SELECT NOMPDT INTO :PROD-NOMPDT FROM SEGUROS.V1PRODUTOR WHERE CODPDT = :APDCORR-CODCORR AND FONTE = :ENDOS-FONTE END-EXEC. */

            var m_360_200_ACESSA_PRODUTOR_DB_SELECT_1_Query1 = new M_360_200_ACESSA_PRODUTOR_DB_SELECT_1_Query1()
            {
                APDCORR_CODCORR = APDCORR_CODCORR.ToString(),
                ENDOS_FONTE = ENDOS_FONTE.ToString(),
            };

            var executed_1 = M_360_200_ACESSA_PRODUTOR_DB_SELECT_1_Query1.Execute(m_360_200_ACESSA_PRODUTOR_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PROD_NOMPDT, PROD_NOMPDT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_360_999_EXIT*/

        [StopWatch]
        /*" M-390-000-LER-TCAUSA-SECTION */
        private void M_390_000_LER_TCAUSA_SECTION()
        {
            /*" -3235- SET I04 TO WZEROS. */
            I04.Value = W.WZEROS;

            /*" -0- FLUXCONTROL_PERFORM M_390_100_LOOP */

            M_390_100_LOOP();

        }

        [StopWatch]
        /*" M-390-100-LOOP */
        private void M_390_100_LOOP(bool isPerform = false)
        {
            /*" -3241- SET I04 UP BY WHUM. */
            I04.Value += W.WHUM;

            /*" -3242- IF I04 GREATER 100 */

            if (I04 > 100)
            {

                /*" -3243- DISPLAY 'SI0133B - ESTOURO DE TABELA INTERNA DE CAUSA' */
                _.Display($"SI0133B - ESTOURO DE TABELA INTERNA DE CAUSA");

                /*" -3245- GO TO 390-200-ACESSA-TCAUSA. */

                M_390_200_ACESSA_TCAUSA(); //GOTO
                return;
            }


            /*" -3246- IF WTABG-DESCAU (I04) EQUAL SPACES */

            if (W.WTABG_CAUSAS.WTABG_CAUSA_ZERA.WTABG_CAUSAGRUPO.WTABG_OCORRECAUSA[I04].WTABG_DESCAU == string.Empty)
            {

                /*" -3248- GO TO 390-200-ACESSA-TCAUSA. */

                M_390_200_ACESSA_TCAUSA(); //GOTO
                return;
            }


            /*" -3250- IF MEST-CODCAU EQUAL WTABG-CODCAU (I04) AND MEST-RAMO EQUAL WTABG-RAMO-CAUSA (I04) */

            if (MEST_CODCAU == W.WTABG_CAUSAS.WTABG_CAUSA_ZERA.WTABG_CAUSAGRUPO.WTABG_OCORRECAUSA[I04].WTABG_CODCAU && MEST_RAMO == W.WTABG_CAUSAS.WTABG_CAUSA_ZERA.WTABG_CAUSAGRUPO.WTABG_OCORRECAUSA[I04].WTABG_RAMO_CAUSA)
            {

                /*" -3251- MOVE WTABG-DESCAU (I04) TO DESCAU-C05 */
                _.Move(W.WTABG_CAUSAS.WTABG_CAUSA_ZERA.WTABG_CAUSAGRUPO.WTABG_OCORRECAUSA[I04].WTABG_DESCAU, W.CAB05.DESCAU_C05);

                /*" -3252- GO TO 390-999-EXIT */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_390_999_EXIT*/ //GOTO
                return;

                /*" -3253- ELSE */
            }
            else
            {


                /*" -3253- GO TO 390-100-LOOP. */
                new Task(() => M_390_100_LOOP()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


        }

        [StopWatch]
        /*" M-390-200-ACESSA-TCAUSA */
        private void M_390_200_ACESSA_TCAUSA(bool isPerform = false)
        {
            /*" -3259- MOVE '032' TO WNR-EXEC-SQL. */
            _.Move("032", WABEND.WNR_EXEC_SQL);

            /*" -3265- PERFORM M_390_200_ACESSA_TCAUSA_DB_SELECT_1 */

            M_390_200_ACESSA_TCAUSA_DB_SELECT_1();

            /*" -3268- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -3270- DISPLAY 'CAUSA ' MEST-CODCAU ' NAO CADASTRADA - ' ' RAMO = ' MEST-RAMO */

                $"CAUSA {MEST_CODCAU} NAO CADASTRADA -  RAMO = {MEST_RAMO}"
                .Display();

                /*" -3272- DISPLAY 'DOCTO ' MEST-NUM-APOL ' ' MEST-NRENDOS ' SINISTRO ' RELSIN-APOL-SINI */

                $"DOCTO {MEST_NUM_APOL} {MEST_NRENDOS} SINISTRO {RELSIN_APOL_SINI}"
                .Display();

                /*" -3273- MOVE ' ' TO DESCAU-C05 */
                _.Move(" ", W.CAB05.DESCAU_C05);

                /*" -3274- GO TO 390-999-EXIT */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_390_999_EXIT*/ //GOTO
                return;

                /*" -3275- ELSE */
            }
            else
            {


                /*" -3276- IF I04 NOT GREATER 100 */

                if (I04 <= 100)
                {

                    /*" -3277- MOVE MEST-CODCAU TO WTABG-CODCAU (I04) */
                    _.Move(MEST_CODCAU, W.WTABG_CAUSAS.WTABG_CAUSA_ZERA.WTABG_CAUSAGRUPO.WTABG_OCORRECAUSA[I04].WTABG_CODCAU);

                    /*" -3278- MOVE MEST-RAMO TO WTABG-RAMO-CAUSA (I04) */
                    _.Move(MEST_RAMO, W.WTABG_CAUSAS.WTABG_CAUSA_ZERA.WTABG_CAUSAGRUPO.WTABG_OCORRECAUSA[I04].WTABG_RAMO_CAUSA);

                    /*" -3280- MOVE CAUSA-DESCAU TO WTABG-DESCAU (I04). */
                    _.Move(CAUSA_DESCAU, W.WTABG_CAUSAS.WTABG_CAUSA_ZERA.WTABG_CAUSAGRUPO.WTABG_OCORRECAUSA[I04].WTABG_DESCAU);
                }

            }


            /*" -3280- MOVE CAUSA-DESCAU TO DESCAU-C05. */
            _.Move(CAUSA_DESCAU, W.CAB05.DESCAU_C05);

        }

        [StopWatch]
        /*" M-390-200-ACESSA-TCAUSA-DB-SELECT-1 */
        public void M_390_200_ACESSA_TCAUSA_DB_SELECT_1()
        {
            /*" -3265- EXEC SQL SELECT DESCAU INTO :CAUSA-DESCAU FROM SEGUROS.V1SINICAUSA WHERE RAMO = :MEST-RAMO AND CODCAU = :MEST-CODCAU END-EXEC. */

            var m_390_200_ACESSA_TCAUSA_DB_SELECT_1_Query1 = new M_390_200_ACESSA_TCAUSA_DB_SELECT_1_Query1()
            {
                MEST_CODCAU = MEST_CODCAU.ToString(),
                MEST_RAMO = MEST_RAMO.ToString(),
            };

            var executed_1 = M_390_200_ACESSA_TCAUSA_DB_SELECT_1_Query1.Execute(m_390_200_ACESSA_TCAUSA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CAUSA_DESCAU, CAUSA_DESCAU);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_390_999_EXIT*/

        [StopWatch]
        /*" M-391-003-LER-TCAUSA-SECTION */
        private void M_391_003_LER_TCAUSA_SECTION()
        {
            /*" -3288- MOVE '033' TO WNR-EXEC-SQL. */
            _.Move("033", WABEND.WNR_EXEC_SQL);

            /*" -3295- PERFORM M_391_003_LER_TCAUSA_DB_SELECT_1 */

            M_391_003_LER_TCAUSA_DB_SELECT_1();

            /*" -3298- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -3300- DISPLAY 'CAUSA = ' MEST-CODCAU ' NAO CADASTRADA - RAMO = ' MEST-RAMO */

                $"CAUSA = {MEST_CODCAU} NAO CADASTRADA - RAMO = {MEST_RAMO}"
                .Display();

                /*" -3301- DISPLAY 'SINISTRO NUMERO = ' RELSIN-APOL-SINI */
                _.Display($"SINISTRO NUMERO = {RELSIN_APOL_SINI}");

                /*" -3302- MOVE ALL '*' TO DESCAU-C05 */
                _.MoveAll("*", W.CAB05.DESCAU_C05);

                /*" -3303- ELSE */
            }
            else
            {


                /*" -3305- MOVE CAUSA-DESCAU TO DESCAU-C05. */
                _.Move(CAUSA_DESCAU, W.CAB05.DESCAU_C05);
            }


            /*" -3305- MOVE MEST-CODCAU TO CODCAU-C05. */
            _.Move(MEST_CODCAU, W.CAB05.CODCAU_C05);

        }

        [StopWatch]
        /*" M-391-003-LER-TCAUSA-DB-SELECT-1 */
        public void M_391_003_LER_TCAUSA_DB_SELECT_1()
        {
            /*" -3295- EXEC SQL SELECT DESCAU, GRUPO_CAUSAS INTO :CAUSA-DESCAU, :CAUSA-GRUPO-CAUSAS FROM SEGUROS.V1SINICAUSA WHERE RAMO = :MEST-RAMO AND CODCAU = :MEST-CODCAU END-EXEC. */

            var m_391_003_LER_TCAUSA_DB_SELECT_1_Query1 = new M_391_003_LER_TCAUSA_DB_SELECT_1_Query1()
            {
                MEST_CODCAU = MEST_CODCAU.ToString(),
                MEST_RAMO = MEST_RAMO.ToString(),
            };

            var executed_1 = M_391_003_LER_TCAUSA_DB_SELECT_1_Query1.Execute(m_391_003_LER_TCAUSA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CAUSA_DESCAU, CAUSA_DESCAU);
                _.Move(executed_1.CAUSA_GRUPO_CAUSAS, CAUSA_GRUPO_CAUSAS);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_391_003_EXIT*/

        [StopWatch]
        /*" M-400-000-CURSOR-THISTSIN-RESERV-SECTION */
        private void M_400_000_CURSOR_THISTSIN_RESERV_SECTION()
        {
            /*" -3313- MOVE '034' TO WNR-EXEC-SQL. */
            _.Move("034", WABEND.WNR_EXEC_SQL);

            /*" -3320- PERFORM M_400_000_CURSOR_THISTSIN_RESERV_DB_DECLARE_1 */

            M_400_000_CURSOR_THISTSIN_RESERV_DB_DECLARE_1();

            /*" -3322- PERFORM M_400_000_CURSOR_THISTSIN_RESERV_DB_OPEN_1 */

            M_400_000_CURSOR_THISTSIN_RESERV_DB_OPEN_1();

        }

        [StopWatch]
        /*" M-400-000-CURSOR-THISTSIN-RESERV-DB-OPEN-1 */
        public void M_400_000_CURSOR_THISTSIN_RESERV_DB_OPEN_1()
        {
            /*" -3322- EXEC SQL OPEN RESERVA END-EXEC. */

            RESERVA.Open();

        }

        [StopWatch]
        /*" M-420-000-CURSOR-TPARCELA-DB-DECLARE-1 */
        public void M_420_000_CURSOR_TPARCELA_DB_DECLARE_1()
        {
            /*" -3364- EXEC SQL DECLARE V1PARCELA CURSOR FOR SELECT NRPARCEL, SITUACAO, OCORHIST, NUM_APOLICE, NRENDOS FROM SEGUROS.V1PARCELA WHERE NUM_APOLICE = :MEST-NUM-APOL AND NRENDOS = :MEST-NRENDOS ORDER BY NRPARCEL END-EXEC. */
            V1PARCELA = new SI0133B_V1PARCELA(true);
            string GetQuery_V1PARCELA()
            {
                var query = @$"SELECT NRPARCEL
							, SITUACAO
							, 
							OCORHIST
							, NUM_APOLICE
							, NRENDOS 
							FROM SEGUROS.V1PARCELA 
							WHERE NUM_APOLICE = '{MEST_NUM_APOL}' 
							AND NRENDOS = '{MEST_NRENDOS}' 
							ORDER BY NRPARCEL";

                return query;
            }
            V1PARCELA.GetQueryEvent += GetQuery_V1PARCELA;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_400_999_EXIT*/

        [StopWatch]
        /*" M-410-000-LER-THISTSIN-RESERVA-SECTION */
        private void M_410_000_LER_THISTSIN_RESERVA_SECTION()
        {
            /*" -3330- MOVE '035' TO WNR-EXEC-SQL. */
            _.Move("035", WABEND.WNR_EXEC_SQL);

            /*" -3332- PERFORM M_410_000_LER_THISTSIN_RESERVA_DB_FETCH_1 */

            M_410_000_LER_THISTSIN_RESERVA_DB_FETCH_1();

            /*" -3335- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -3335- PERFORM M_410_000_LER_THISTSIN_RESERVA_DB_CLOSE_1 */

                M_410_000_LER_THISTSIN_RESERVA_DB_CLOSE_1();

                /*" -3337- MOVE 'S' TO WACHOU-THISTSIN */
                _.Move("S", W.WACHOU_THISTSIN);

                /*" -3338- MOVE 'S' TO WFIM-RESERVA */
                _.Move("S", W.WFIM_RESERVA);

                /*" -3340- GO TO 410-999-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_410_999_EXIT*/ //GOTO
                return;
            }


            /*" -3342- MOVE 'S' TO WACHOU-THISTSIN. */
            _.Move("S", W.WACHOU_THISTSIN);

            /*" -3345- IF THIST-OPERACAO1 EQUAL 102 OR 103 OR 112 OR 113 OR 122 OR 123 */

            if (THIST_OPERACAO1.In("102", "103", "112", "113", "122", "123"))
            {

                /*" -3346- ADD THIST-VALPRI1 TO WAUMENTO-RESERVA */
                W.WAUMENTO_RESERVA.Value = W.WAUMENTO_RESERVA + THIST_VALPRI1;

                /*" -3347- ELSE */
            }
            else
            {


                /*" -3349- IF THIST-OPERACAO1 EQUAL 105 OR 106 OR 115 OR 116 */

                if (THIST_OPERACAO1.In("105", "106", "115", "116"))
                {

                    /*" -3349- ADD THIST-VALPRI1 TO WREDUCAO-RESERVA. */
                    W.WREDUCAO_RESERVA.Value = W.WREDUCAO_RESERVA + THIST_VALPRI1;
                }

            }


        }

        [StopWatch]
        /*" M-410-000-LER-THISTSIN-RESERVA-DB-FETCH-1 */
        public void M_410_000_LER_THISTSIN_RESERVA_DB_FETCH_1()
        {
            /*" -3332- EXEC SQL FETCH RESERVA INTO :THIST-OPERACAO1, :THIST-VALPRI1 END-EXEC. */

            if (RESERVA.Fetch())
            {
                _.Move(RESERVA.THIST_OPERACAO1, THIST_OPERACAO1);
                _.Move(RESERVA.THIST_VALPRI1, THIST_VALPRI1);
            }

        }

        [StopWatch]
        /*" M-410-000-LER-THISTSIN-RESERVA-DB-CLOSE-1 */
        public void M_410_000_LER_THISTSIN_RESERVA_DB_CLOSE_1()
        {
            /*" -3335- EXEC SQL CLOSE RESERVA END-EXEC */

            RESERVA.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_410_999_EXIT*/

        [StopWatch]
        /*" M-420-000-CURSOR-TPARCELA-SECTION */
        private void M_420_000_CURSOR_TPARCELA_SECTION()
        {
            /*" -3357- MOVE '036' TO WNR-EXEC-SQL. */
            _.Move("036", WABEND.WNR_EXEC_SQL);

            /*" -3364- PERFORM M_420_000_CURSOR_TPARCELA_DB_DECLARE_1 */

            M_420_000_CURSOR_TPARCELA_DB_DECLARE_1();

            /*" -3366- PERFORM M_420_000_CURSOR_TPARCELA_DB_OPEN_1 */

            M_420_000_CURSOR_TPARCELA_DB_OPEN_1();

        }

        [StopWatch]
        /*" M-420-000-CURSOR-TPARCELA-DB-OPEN-1 */
        public void M_420_000_CURSOR_TPARCELA_DB_OPEN_1()
        {
            /*" -3366- EXEC SQL OPEN V1PARCELA END-EXEC. */

            V1PARCELA.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_420_999_EXIT*/

        [StopWatch]
        /*" M-450-000-LER-TPARCELA-SECTION */
        private void M_450_000_LER_TPARCELA_SECTION()
        {
            /*" -3374- MOVE '037' TO WNR-EXEC-SQL. */
            _.Move("037", WABEND.WNR_EXEC_SQL);

            /*" -3378- PERFORM M_450_000_LER_TPARCELA_DB_FETCH_1 */

            M_450_000_LER_TPARCELA_DB_FETCH_1();

            /*" -3381- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -3381- PERFORM M_450_000_LER_TPARCELA_DB_CLOSE_1 */

                M_450_000_LER_TPARCELA_DB_CLOSE_1();

                /*" -3383- MOVE 'S' TO WFIM-TPARCELA */
                _.Move("S", W.WFIM_TPARCELA);

                /*" -3384- GO TO 450-999-EXIT */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_450_999_EXIT*/ //GOTO
                return;

                /*" -3385- ELSE */
            }
            else
            {


                /*" -3386- IF WTEM-PARCELA EQUAL 'N' */

                if (W.WTEM_PARCELA == "N")
                {

                    /*" -3387- PERFORM 501-000-CABECALHO */

                    M_501_000_CABECALHO_SECTION();

                    /*" -3388- SET LINHA-NORMAL TO TRUE */
                    REG_SI0133M1.LINHA_ASACODE["LINHA_NORMAL"] = true;

                    /*" -3389- MOVE CAB30 TO LINHA */
                    _.Move(W.CAB30, REG_SI0133M1.LINHA);

                    /*" -3391- WRITE REG-SI0133M1 */
                    SI0133M1.Write(REG_SI0133M1.GetMoveValues().ToString());

                    /*" -3392- SET PULA-LINHA TO TRUE */
                    REG_SI0133M1.LINHA_ASACODE["PULA_LINHA"] = true;

                    /*" -3393- MOVE CAB31 TO LINHA */
                    _.Move(W.CAB31, REG_SI0133M1.LINHA);

                    /*" -3395- WRITE REG-SI0133M1 */
                    SI0133M1.Write(REG_SI0133M1.GetMoveValues().ToString());

                    /*" -3397- MOVE 'S' TO WTEM-PARCELA. */
                    _.Move("S", W.WTEM_PARCELA);
                }

            }


            /*" -3399- MOVE PARCEL-NRPARCEL TO NRPARCEL-C32 */
            _.Move(PARCEL_NRPARCEL, W.CAB32.NRPARCEL_C32);

            /*" -3400- IF PARCEL-SITUACAO EQUAL '0' */

            if (PARCEL_SITUACAO == "0")
            {

                /*" -3401- MOVE 'PENDENTE' TO SITUACAO-C32 */
                _.Move("PENDENTE", W.CAB32.SITUACAO_C32);

                /*" -3402- ELSE */
            }
            else
            {


                /*" -3403- IF PARCEL-SITUACAO EQUAL '1' */

                if (PARCEL_SITUACAO == "1")
                {

                    /*" -3404- MOVE 'PAGO' TO SITUACAO-C32 */
                    _.Move("PAGO", W.CAB32.SITUACAO_C32);

                    /*" -3405- ELSE */
                }
                else
                {


                    /*" -3406- IF PARCEL-SITUACAO EQUAL '2' */

                    if (PARCEL_SITUACAO == "2")
                    {

                        /*" -3407- MOVE 'CANCELADO' TO SITUACAO-C32 */
                        _.Move("CANCELADO", W.CAB32.SITUACAO_C32);

                        /*" -3408- ELSE */
                    }
                    else
                    {


                        /*" -3410- MOVE ' ' TO SITUACAO-C32. */
                        _.Move(" ", W.CAB32.SITUACAO_C32);
                    }

                }

            }


            /*" -3412- PERFORM 480-000-LER-THISTPAR. */

            M_480_000_LER_THISTPAR_SECTION();

            /*" -3413- SET LINHA-NORMAL TO TRUE */
            REG_SI0133M1.LINHA_ASACODE["LINHA_NORMAL"] = true;

            /*" -3414- MOVE CAB32 TO LINHA */
            _.Move(W.CAB32, REG_SI0133M1.LINHA);

            /*" -3414- WRITE REG-SI0133M1. */
            SI0133M1.Write(REG_SI0133M1.GetMoveValues().ToString());

        }

        [StopWatch]
        /*" M-450-000-LER-TPARCELA-DB-FETCH-1 */
        public void M_450_000_LER_TPARCELA_DB_FETCH_1()
        {
            /*" -3378- EXEC SQL FETCH V1PARCELA INTO :PARCEL-NRPARCEL, :PARCEL-SITUACAO, :PARCEL-OCORHIST, :PARCEL-NUM-APOL, :PARCEL-NRENDOS END-EXEC. */

            if (V1PARCELA.Fetch())
            {
                _.Move(V1PARCELA.PARCEL_NRPARCEL, PARCEL_NRPARCEL);
                _.Move(V1PARCELA.PARCEL_SITUACAO, PARCEL_SITUACAO);
                _.Move(V1PARCELA.PARCEL_OCORHIST, PARCEL_OCORHIST);
                _.Move(V1PARCELA.PARCEL_NUM_APOL, PARCEL_NUM_APOL);
                _.Move(V1PARCELA.PARCEL_NRENDOS, PARCEL_NRENDOS);
            }

        }

        [StopWatch]
        /*" M-450-000-LER-TPARCELA-DB-CLOSE-1 */
        public void M_450_000_LER_TPARCELA_DB_CLOSE_1()
        {
            /*" -3381- EXEC SQL CLOSE V1PARCELA END-EXEC */

            V1PARCELA.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_450_999_EXIT*/

        [StopWatch]
        /*" M-480-000-LER-THISTPAR-SECTION */
        private void M_480_000_LER_THISTPAR_SECTION()
        {
            /*" -3426- MOVE '480-000-LER-THISTPAR' TO PARAGRAFO. */
            _.Move("480-000-LER-THISTPAR", WABEND.PARAGRAFO);

            /*" -3429- MOVE '038' TO WNR-EXEC-SQL. */
            _.Move("038", WABEND.WNR_EXEC_SQL);

            /*" -3440- PERFORM M_480_000_LER_THISTPAR_DB_SELECT_1 */

            M_480_000_LER_THISTPAR_DB_SELECT_1();

            /*" -3444- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -3445- DISPLAY 'SI0133B - NAO HA THISTPAR CORRESP. AO TPARCELA' */
                _.Display($"SI0133B - NAO HA THISTPAR CORRESP. AO TPARCELA");

                /*" -3450- DISPLAY 'NUM_APOLICE = ' PARCEL-NUM-APOL 'NRENDOS     = ' PARCEL-NRENDOS 'NRPARCEL    = ' PARCEL-NRPARCEL 'OCORHIST    = ' PARCEL-OCORHIST */

                $"NUM_APOLICE = {PARCEL_NUM_APOL}NRENDOS     = {PARCEL_NRENDOS}NRPARCEL    = {PARCEL_NRPARCEL}OCORHIST    = {PARCEL_OCORHIST}"
                .Display();

                /*" -3451- GO TO 999-999-ROT-ERRO */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -3452- ELSE */
            }
            else
            {


                /*" -3453- MOVE THISTPAR-DTMOVTO TO WDATA-R */
                _.Move(THISTPAR_DTMOVTO, W.WDATA_R);

                /*" -3454- MOVE WDATA-DD TO WDIA-IMP */
                _.Move(W.WDATA.WDATA_DD, W.WDATA_IMP.WDIA_IMP);

                /*" -3455- MOVE WDATA-MM TO WMES-IMP */
                _.Move(W.WDATA.WDATA_MM, W.WDATA_IMP.WMES_IMP);

                /*" -3456- MOVE WDATA-AA TO WANO-IMP */
                _.Move(W.WDATA.WDATA_AA, W.WDATA_IMP.WANO_IMP);

                /*" -3457- MOVE WDATA-IMP TO DTMOVTO-C32 */
                _.Move(W.WDATA_IMP, W.CAB32.DTMOVTO_C32);

                /*" -3458- MOVE THISTPAR-DTVENCTO TO WDATA1-R */
                _.Move(THISTPAR_DTVENCTO, W.WDATA1_R);

                /*" -3459- MOVE WDATA1-DD TO WDIA-IMP */
                _.Move(W.WDATA1.WDATA1_DD, W.WDATA_IMP.WDIA_IMP);

                /*" -3460- MOVE WDATA1-MM TO WMES-IMP */
                _.Move(W.WDATA1.WDATA1_MM, W.WDATA_IMP.WMES_IMP);

                /*" -3461- MOVE WDATA1-AA TO WANO-IMP */
                _.Move(W.WDATA1.WDATA1_AA, W.WDATA_IMP.WANO_IMP);

                /*" -3461- MOVE WDATA-IMP TO DTVENCTO-C32. */
                _.Move(W.WDATA_IMP, W.CAB32.DTVENCTO_C32);
            }


        }

        [StopWatch]
        /*" M-480-000-LER-THISTPAR-DB-SELECT-1 */
        public void M_480_000_LER_THISTPAR_DB_SELECT_1()
        {
            /*" -3440- EXEC SQL SELECT DTMOVTO, DTVENCTO INTO :THISTPAR-DTMOVTO, :THISTPAR-DTVENCTO FROM SEGUROS.V1HISTOPARC WHERE NUM_APOLICE = :PARCEL-NUM-APOL AND NRENDOS = :PARCEL-NRENDOS AND NRPARCEL = :PARCEL-NRPARCEL AND OCORHIST = :PARCEL-OCORHIST END-EXEC. */

            var m_480_000_LER_THISTPAR_DB_SELECT_1_Query1 = new M_480_000_LER_THISTPAR_DB_SELECT_1_Query1()
            {
                PARCEL_NUM_APOL = PARCEL_NUM_APOL.ToString(),
                PARCEL_NRPARCEL = PARCEL_NRPARCEL.ToString(),
                PARCEL_OCORHIST = PARCEL_OCORHIST.ToString(),
                PARCEL_NRENDOS = PARCEL_NRENDOS.ToString(),
            };

            var executed_1 = M_480_000_LER_THISTPAR_DB_SELECT_1_Query1.Execute(m_480_000_LER_THISTPAR_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.THISTPAR_DTMOVTO, THISTPAR_DTMOVTO);
                _.Move(executed_1.THISTPAR_DTVENCTO, THISTPAR_DTVENCTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_480_999_EXIT*/

        [StopWatch]
        /*" M-490-000-CLOSE-THISTSIN-SECTION */
        private void M_490_000_CLOSE_THISTSIN_SECTION()
        {
            /*" -3474- MOVE '490-000-CLOSE-THISTSIN' TO PARAGRAFO. */
            _.Move("490-000-CLOSE-THISTSIN", WABEND.PARAGRAFO);

            /*" -3476- MOVE '039' TO WNR-EXEC-SQL. */
            _.Move("039", WABEND.WNR_EXEC_SQL);

            /*" -3476- PERFORM M_490_000_CLOSE_THISTSIN_DB_CLOSE_1 */

            M_490_000_CLOSE_THISTSIN_DB_CLOSE_1();

        }

        [StopWatch]
        /*" M-490-000-CLOSE-THISTSIN-DB-CLOSE-1 */
        public void M_490_000_CLOSE_THISTSIN_DB_CLOSE_1()
        {
            /*" -3476- EXEC SQL CLOSE V1HISTSINI END-EXEC. */

            V1HISTSINI.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_490_999_EXIT*/

        [StopWatch]
        /*" M-492-000-CLOSE-TFAVOREC-SECTION */
        private void M_492_000_CLOSE_TFAVOREC_SECTION()
        {
            /*" -3485- MOVE '492-000-CLOSE-TFAVOREC' TO PARAGRAFO. */
            _.Move("492-000-CLOSE-TFAVOREC", WABEND.PARAGRAFO);

            /*" -3487- MOVE '040' TO WNR-EXEC-SQL. */
            _.Move("040", WABEND.WNR_EXEC_SQL);

            /*" -3487- PERFORM M_492_000_CLOSE_TFAVOREC_DB_CLOSE_1 */

            M_492_000_CLOSE_TFAVOREC_DB_CLOSE_1();

        }

        [StopWatch]
        /*" M-492-000-CLOSE-TFAVOREC-DB-CLOSE-1 */
        public void M_492_000_CLOSE_TFAVOREC_DB_CLOSE_1()
        {
            /*" -3487- EXEC SQL CLOSE V1HISTFAV END-EXEC. */

            V1HISTFAV.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_492_999_EXIT*/

        [StopWatch]
        /*" M-500-000-LER-FORNECEDOR-SECTION */
        private void M_500_000_LER_FORNECEDOR_SECTION()
        {
            /*" -3498- MOVE '043' TO WNR-EXEC-SQL. */
            _.Move("043", WABEND.WNR_EXEC_SQL);

            /*" -3512- PERFORM M_500_000_LER_FORNECEDOR_DB_SELECT_1 */

            M_500_000_LER_FORNECEDOR_DB_SELECT_1();

            /*" -3514- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -3515- DISPLAY 'JOIN FORNECEDOR / BANCO/ AGENCIA  NAO ENCONTRADO' */
                _.Display($"JOIN FORNECEDOR / BANCO/ AGENCIA  NAO ENCONTRADO");

                /*" -3516- DISPLAY 'SINISTRO NUMERO = ' RELSIN-APOL-SINI */
                _.Display($"SINISTRO NUMERO = {RELSIN_APOL_SINI}");

                /*" -3517- DISPLAY 'COD. FORNECEDOR ' THIST-CODPSVI */
                _.Display($"COD. FORNECEDOR {THIST_CODPSVI}");

                /*" -3519- MOVE ALL '*' TO BANCOS-NOME-BANCO AGENCIAS-NOME-AGENCIA */
                _.MoveAll("*", BANCOS.DCLBANCOS.BANCOS_NOME_BANCO, AGENCIAS.DCLAGENCIAS.AGENCIAS_NOME_AGENCIA);

                /*" -3520- MOVE ZEROS TO FORNECED-NUM-CTA-CORRENTE FORNECED-COD-AGENCIA. */
                _.Move(0, FORNECED.DCLFORNECEDORES.FORNECED_NUM_CTA_CORRENTE, FORNECED.DCLFORNECEDORES.FORNECED_COD_AGENCIA);
            }


        }

        [StopWatch]
        /*" M-500-000-LER-FORNECEDOR-DB-SELECT-1 */
        public void M_500_000_LER_FORNECEDOR_DB_SELECT_1()
        {
            /*" -3512- EXEC SQL SELECT B.NOME_BANCO, A.NOME_AGENCIA, F.COD_AGENCIA, F.NUM_CTA_CORRENTE, F.COD_BANCO INTO :BANCOS-NOME-BANCO, :AGENCIAS-NOME-AGENCIA, :FORNECED-COD-AGENCIA, :FORNECED-NUM-CTA-CORRENTE, :FORNECED-COD-BANCO FROM SEGUROS.FORNECEDORES F, SEGUROS.AGENCIAS A, SEGUROS.BANCOS B WHERE F.COD_FORNECEDOR = :THIST-CODPSVI AND F.COD_BANCO = B.COD_BANCO AND F.COD_BANCO = A.COD_BANCO AND F.COD_AGENCIA = A.COD_AGENCIA END-EXEC. */

            var m_500_000_LER_FORNECEDOR_DB_SELECT_1_Query1 = new M_500_000_LER_FORNECEDOR_DB_SELECT_1_Query1()
            {
                THIST_CODPSVI = THIST_CODPSVI.ToString(),
            };

            var executed_1 = M_500_000_LER_FORNECEDOR_DB_SELECT_1_Query1.Execute(m_500_000_LER_FORNECEDOR_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.BANCOS_NOME_BANCO, BANCOS.DCLBANCOS.BANCOS_NOME_BANCO);
                _.Move(executed_1.AGENCIAS_NOME_AGENCIA, AGENCIAS.DCLAGENCIAS.AGENCIAS_NOME_AGENCIA);
                _.Move(executed_1.FORNECED_COD_AGENCIA, FORNECED.DCLFORNECEDORES.FORNECED_COD_AGENCIA);
                _.Move(executed_1.FORNECED_NUM_CTA_CORRENTE, FORNECED.DCLFORNECEDORES.FORNECED_NUM_CTA_CORRENTE);
                _.Move(executed_1.FORNECED_COD_BANCO, FORNECED.DCLFORNECEDORES.FORNECED_COD_BANCO);
            }


        }

        [StopWatch]
        /*" M-500-000-IMPRIME-SECTION */
        private void M_500_000_IMPRIME_SECTION()
        {
            /*" -3528- MOVE '044' TO WNR-EXEC-SQL. */
            _.Move("044", WABEND.WNR_EXEC_SQL);

            /*" -3529- PERFORM 501-000-CABECALHO. */

            M_501_000_CABECALHO_SECTION();

            /*" -3530- SET LINHA-NORMAL TO TRUE */
            REG_SI0133M1.LINHA_ASACODE["LINHA_NORMAL"] = true;

            /*" -3531- MOVE CAB03 TO LINHA */
            _.Move(W.CAB03, REG_SI0133M1.LINHA);

            /*" -3533- WRITE REG-SI0133M1 */
            SI0133M1.Write(REG_SI0133M1.GetMoveValues().ToString());

            /*" -3534- MOVE WS-FONTE-C04 TO FONTE-C04 */
            _.Move(W.WS_FONTE_C04, W.CAB04.FONTE_C04);

            /*" -3535- MOVE WS-PROTSINI-C04 TO PROTSINI-C04 */
            _.Move(W.WS_PROTSINI_C04, W.CAB04.PROTSINI_C04);

            /*" -3536- MOVE WS-DAC-C04 TO DAC-C04 */
            _.Move(W.WS_DAC_C04, W.CAB04.DAC_C04);

            /*" -3537- SET LINHA-NORMAL TO TRUE */
            REG_SI0133M1.LINHA_ASACODE["LINHA_NORMAL"] = true;

            /*" -3538- MOVE CAB04 TO LINHA */
            _.Move(W.CAB04, REG_SI0133M1.LINHA);

            /*" -3539- WRITE REG-SI0133M1 */
            SI0133M1.Write(REG_SI0133M1.GetMoveValues().ToString());

            /*" -3540- SET LINHA-NORMAL TO TRUE */
            REG_SI0133M1.LINHA_ASACODE["LINHA_NORMAL"] = true;

            /*" -3541- MOVE CAB04A TO LINHA */
            _.Move(W.CAB04A, REG_SI0133M1.LINHA);

            /*" -3542- WRITE REG-SI0133M1 */
            SI0133M1.Write(REG_SI0133M1.GetMoveValues().ToString());

            /*" -3543- SET PULA-LINHA TO TRUE */
            REG_SI0133M1.LINHA_ASACODE["PULA_LINHA"] = true;

            /*" -3544- MOVE CAB05 TO LINHA */
            _.Move(W.CAB05, REG_SI0133M1.LINHA);

            /*" -3545- WRITE REG-SI0133M1 */
            SI0133M1.Write(REG_SI0133M1.GetMoveValues().ToString());

            /*" -3546- SET LINHA-NORMAL TO TRUE */
            REG_SI0133M1.LINHA_ASACODE["LINHA_NORMAL"] = true;

            /*" -3547- MOVE CAB08 TO LINHA */
            _.Move(W.CAB08, REG_SI0133M1.LINHA);

            /*" -3559- WRITE REG-SI0133M1 */
            SI0133M1.Write(REG_SI0133M1.GetMoveValues().ToString());

            /*" -3560- SET LINHA-NORMAL TO TRUE */
            REG_SI0133M1.LINHA_ASACODE["LINHA_NORMAL"] = true;

            /*" -3561- MOVE CAB07 TO LINHA */
            _.Move(W.CAB07, REG_SI0133M1.LINHA);

            /*" -3565- WRITE REG-SI0133M1 */
            SI0133M1.Write(REG_SI0133M1.GetMoveValues().ToString());

            /*" -3566- IF MEST-CODPRODU EQUAL 4801 OR 4804 OR 4811 */

            if (MEST_CODPRODU.In("4801", "4804", "4811"))
            {

                /*" -3567- SET LINHA-NORMAL TO TRUE */
                REG_SI0133M1.LINHA_ASACODE["LINHA_NORMAL"] = true;

                /*" -3568- MOVE CAB07A TO LINHA */
                _.Move(W.CAB07A, REG_SI0133M1.LINHA);

                /*" -3570- WRITE REG-SI0133M1 */
                SI0133M1.Write(REG_SI0133M1.GetMoveValues().ToString());

                /*" -3572- END-IF */
            }


            /*" -3573- SET PULA-LINHA TO TRUE */
            REG_SI0133M1.LINHA_ASACODE["PULA_LINHA"] = true;

            /*" -3574- MOVE CAB10 TO LINHA */
            _.Move(W.CAB10, REG_SI0133M1.LINHA);

            /*" -3575- WRITE REG-SI0133M1 */
            SI0133M1.Write(REG_SI0133M1.GetMoveValues().ToString());

            /*" -3576- SET LINHA-NORMAL TO TRUE */
            REG_SI0133M1.LINHA_ASACODE["LINHA_NORMAL"] = true;

            /*" -3577- MOVE CAB11 TO LINHA */
            _.Move(W.CAB11, REG_SI0133M1.LINHA);

            /*" -3578- WRITE REG-SI0133M1 */
            SI0133M1.Write(REG_SI0133M1.GetMoveValues().ToString());

            /*" -3579- SET LINHA-NORMAL TO TRUE */
            REG_SI0133M1.LINHA_ASACODE["LINHA_NORMAL"] = true;

            /*" -3580- MOVE TRACO TO LINHA */
            _.Move(W.TRACO, REG_SI0133M1.LINHA);

            /*" -3581- WRITE REG-SI0133M1 */
            SI0133M1.Write(REG_SI0133M1.GetMoveValues().ToString());

            /*" -3582- SET LINHA-NORMAL TO TRUE */
            REG_SI0133M1.LINHA_ASACODE["LINHA_NORMAL"] = true;

            /*" -3583- MOVE CAB12 TO LINHA */
            _.Move(W.CAB12, REG_SI0133M1.LINHA);

            /*" -3584- WRITE REG-SI0133M1 */
            SI0133M1.Write(REG_SI0133M1.GetMoveValues().ToString());

            /*" -3585- SET LINHA-NORMAL TO TRUE */
            REG_SI0133M1.LINHA_ASACODE["LINHA_NORMAL"] = true;

            /*" -3586- MOVE BRANCO TO LINHA */
            _.Move(W.BRANCO, REG_SI0133M1.LINHA);

            /*" -3593- WRITE REG-SI0133M1 */
            SI0133M1.Write(REG_SI0133M1.GetMoveValues().ToString());

            /*" -3597- PERFORM 550-000-IMP-MOVIM THRU 550-000-FIM VARYING WS-IND1 FROM 1 BY 1 UNTIL WS-IND1 > WS-INDMAX1. */

            for (W.WS_IND1.Value = 1; !(W.WS_IND1 > W.WS_INDMAX1); W.WS_IND1.Value += 1)
            {

                M_550_000_IMP_MOVIM_SECTION();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_550_000_FIM*/

            }

            /*" -3598- MOVE ZEROS TO WS-INDMAX1 */
            _.Move(0, W.WS_INDMAX1);

            /*" -3599- SET LINHA-NORMAL TO TRUE */
            REG_SI0133M1.LINHA_ASACODE["LINHA_NORMAL"] = true;

            /*" -3600- MOVE TRACO TO LINHA */
            _.Move(W.TRACO, REG_SI0133M1.LINHA);

            /*" -3601- WRITE REG-SI0133M1 */
            SI0133M1.Write(REG_SI0133M1.GetMoveValues().ToString());

            /*" -3602- SET LINHA-NORMAL TO TRUE */
            REG_SI0133M1.LINHA_ASACODE["LINHA_NORMAL"] = true;

            /*" -3603- MOVE CAB20 TO LINHA */
            _.Move(W.CAB20, REG_SI0133M1.LINHA);

            /*" -3604- WRITE REG-SI0133M1 */
            SI0133M1.Write(REG_SI0133M1.GetMoveValues().ToString());

            /*" -3605- SET LINHA-NORMAL TO TRUE */
            REG_SI0133M1.LINHA_ASACODE["LINHA_NORMAL"] = true;

            /*" -3606- MOVE TRACO TO LINHA */
            _.Move(W.TRACO, REG_SI0133M1.LINHA);

            /*" -3607- WRITE REG-SI0133M1 */
            SI0133M1.Write(REG_SI0133M1.GetMoveValues().ToString());

            /*" -3608- SET LINHA-NORMAL TO TRUE */
            REG_SI0133M1.LINHA_ASACODE["LINHA_NORMAL"] = true;

            /*" -3609- MOVE CAB23 TO LINHA */
            _.Move(W.CAB23, REG_SI0133M1.LINHA);

            /*" -3615- WRITE REG-SI0133M1 */
            SI0133M1.Write(REG_SI0133M1.GetMoveValues().ToString());

            /*" -3616- IF WS-INDMAX2 GREATER ZEROS */

            if (W.WS_INDMAX2 > 00)
            {

                /*" -3619- PERFORM 570-000-IMPRIME-DETALHE THRU 570-000-FIM VARYING WS-IND1 FROM 1 BY 1 UNTIL WS-IND1 GREATER WS-INDMAX2 */

                for (W.WS_IND1.Value = 1; !(W.WS_IND1 > W.WS_INDMAX2); W.WS_IND1.Value += 1)
                {

                    M_570_000_IMPRIME_DETALHE_SECTION();
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_570_000_FIM*/

                }

                /*" -3621- END-IF */
            }


            /*" -3626- MOVE ZEROS TO WS-INDMAX2 */
            _.Move(0, W.WS_INDMAX2);

            /*" -3627- IF RELSIN-CODPSI = 925613 */

            if (RELSIN_CODPSI == 925613)
            {

                /*" -3628- MOVE 12 TO W-LINHA */
                _.Move(12, W_LINHA);

                /*" -3629- ELSE */
            }
            else
            {


                /*" -3630- MOVE 15 TO W-LINHA. */
                _.Move(15, W_LINHA);
            }


            /*" -3631- PERFORM VARYING I FROM 1 BY 1 UNTIL I > W-LINHA */

            for (W.I.Value = 1; !(W.I > W_LINHA); W.I.Value += 1)
            {

                /*" -3632- SET LINHA-NORMAL TO TRUE */
                REG_SI0133M1.LINHA_ASACODE["LINHA_NORMAL"] = true;

                /*" -3633- MOVE BRANCO TO LINHA */
                _.Move(W.BRANCO, REG_SI0133M1.LINHA);

                /*" -3634- WRITE REG-SI0133M1 */
                SI0133M1.Write(REG_SI0133M1.GetMoveValues().ToString());

                /*" -3635- END-PERFORM */
            }

            /*" -3636- IF RELSIN-CODPSI = 925613 */

            if (RELSIN_CODPSI == 925613)
            {

                /*" -3637- SET LINHA-NORMAL TO TRUE */
                REG_SI0133M1.LINHA_ASACODE["LINHA_NORMAL"] = true;

                /*" -3638- MOVE CAB28 TO LINHA */
                _.Move(W.CAB28, REG_SI0133M1.LINHA);

                /*" -3639- WRITE REG-SI0133M1 */
                SI0133M1.Write(REG_SI0133M1.GetMoveValues().ToString());

                /*" -3640- MOVE BRANCO TO LINHA */
                _.Move(W.BRANCO, REG_SI0133M1.LINHA);

                /*" -3641- SET LINHA-NORMAL TO TRUE */
                REG_SI0133M1.LINHA_ASACODE["LINHA_NORMAL"] = true;

                /*" -3642- PERFORM VARYING I FROM 1 BY 1 UNTIL I > 3 */

                for (W.I.Value = 1; !(W.I > 3); W.I.Value += 1)
                {

                    /*" -3643- SET LINHA-NORMAL TO TRUE */
                    REG_SI0133M1.LINHA_ASACODE["LINHA_NORMAL"] = true;

                    /*" -3644- MOVE BRANCO TO LINHA */
                    _.Move(W.BRANCO, REG_SI0133M1.LINHA);

                    /*" -3645- WRITE REG-SI0133M1 */
                    SI0133M1.Write(REG_SI0133M1.GetMoveValues().ToString());

                    /*" -3646- END-PERFORM. */
                }
            }


            /*" -3647- SET LINHA-NORMAL TO TRUE */
            REG_SI0133M1.LINHA_ASACODE["LINHA_NORMAL"] = true;

            /*" -3648- MOVE CAB26 TO LINHA */
            _.Move(W.CAB26, REG_SI0133M1.LINHA);

            /*" -3650- WRITE REG-SI0133M1 */
            SI0133M1.Write(REG_SI0133M1.GetMoveValues().ToString());

            /*" -3651- SET LINHA-NORMAL TO TRUE */
            REG_SI0133M1.LINHA_ASACODE["LINHA_NORMAL"] = true;

            /*" -3652- MOVE CAB27 TO LINHA */
            _.Move(W.CAB27, REG_SI0133M1.LINHA);

            /*" -3655- WRITE REG-SI0133M1 */
            SI0133M1.Write(REG_SI0133M1.GetMoveValues().ToString());

            /*" -3655- ADD 1 TO WIMPRES-E. */
            W.WIMPRES_E.Value = W.WIMPRES_E + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_500_999_EXIT*/

        [StopWatch]
        /*" M-510-FOLHA-SEPARADORA-SECTION */
        private void M_510_FOLHA_SEPARADORA_SECTION()
        {
            /*" -3670- MOVE 'GEPOC' TO LOTACAO-SEP07 */
            _.Move("GEPOC", W.SEP07.LOTACAO_SEP07);

            /*" -3671- MOVE RELSIN-CODUSU TO COD-ANAL-SEP05 */
            _.Move(RELSIN_CODUSU, W.SEP05.COD_ANAL_SEP05);

            /*" -3672- IF RELSIN-CODUSU NOT EQUAL WS-GD-CODUSU */

            if (RELSIN_CODUSU != W.WS_GD_CODUSU)
            {

                /*" -3673- MOVE RELSIN-CODUSU TO WS-GD-CODUSU */
                _.Move(RELSIN_CODUSU, W.WS_GD_CODUSU);

                /*" -3674- MOVE 1 TO WS-IND-USU */
                _.Move(1, W.WS_IND_USU);

                /*" -3675- ELSE */
            }
            else
            {


                /*" -3676- MOVE 0 TO WS-IND-USU */
                _.Move(0, W.WS_IND_USU);

                /*" -3677- END-IF */
            }


            /*" -3683- PERFORM M_510_FOLHA_SEPARADORA_DB_SELECT_1 */

            M_510_FOLHA_SEPARADORA_DB_SELECT_1();

            /*" -3685- IF SQLCODE EQUAL 0 */

            if (DB.SQLCODE == 0)
            {

                /*" -3686- MOVE USUARIOS-NOME-USUARIO TO NOME-ANAL-SEP05 */
                _.Move(USUARIOS.DCLUSUARIOS.USUARIOS_NOME_USUARIO, W.SEP05.NOME_ANAL_SEP05);

                /*" -3687- ELSE */
            }
            else
            {


                /*" -3688- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -3689- DISPLAY 'ERRO SELECT NOME SEGUROS.USUARIOS' */
                    _.Display($"ERRO SELECT NOME SEGUROS.USUARIOS");

                    /*" -3690- DISPLAY 'COD-USU = ' RELSIN-CODUSU */
                    _.Display($"COD-USU = {RELSIN_CODUSU}");

                    /*" -3691- DISPLAY 'SQLCODE = ' SQLCODE */
                    _.Display($"SQLCODE = {DB.SQLCODE}");

                    /*" -3692- MOVE SPACES TO NOME-ANAL-SEP05 */
                    _.Move("", W.SEP05.NOME_ANAL_SEP05);

                    /*" -3693- ELSE */
                }
                else
                {


                    /*" -3694- DISPLAY 'ERRO SELECT SEGUROS.USUARIOS' */
                    _.Display($"ERRO SELECT SEGUROS.USUARIOS");

                    /*" -3695- DISPLAY 'COD-USU = ' RELSIN-CODUSU */
                    _.Display($"COD-USU = {RELSIN_CODUSU}");

                    /*" -3696- GO TO 999-999-ROT-ERRO */

                    M_999_999_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -3697- END-IF */
                }


                /*" -3698- END-IF */
            }


            /*" -3725- MOVE SPACES TO TP-OPERACAO-SEP08 */
            _.Move("", W.SEP08.TP_OPERACAO_SEP08);

            /*" -3726- IF WS-IND-USU EQUAL 1 */

            if (W.WS_IND_USU == 1)
            {

                /*" -3727- SET NOVA-PAGINA TO TRUE */
                REG_SI0133M1.LINHA_ASACODE["NOVA_PAGINA"] = true;

                /*" -3728- MOVE BRANCO TO LINHA */
                _.Move(W.BRANCO, REG_SI0133M1.LINHA);

                /*" -3729- WRITE REG-SI0133M1 */
                SI0133M1.Write(REG_SI0133M1.GetMoveValues().ToString());

                /*" -3730- SET LINHA-NORMAL TO TRUE */
                REG_SI0133M1.LINHA_ASACODE["LINHA_NORMAL"] = true;

                /*" -3731- MOVE BRANCO TO LINHA */
                _.Move(W.BRANCO, REG_SI0133M1.LINHA);

                /*" -3732- WRITE REG-SI0133M1 */
                SI0133M1.Write(REG_SI0133M1.GetMoveValues().ToString());

                /*" -3733- SET LINHA-NORMAL TO TRUE */
                REG_SI0133M1.LINHA_ASACODE["LINHA_NORMAL"] = true;

                /*" -3734- MOVE BRANCO TO LINHA */
                _.Move(W.BRANCO, REG_SI0133M1.LINHA);

                /*" -3735- WRITE REG-SI0133M1 */
                SI0133M1.Write(REG_SI0133M1.GetMoveValues().ToString());

                /*" -3736- SET LINHA-NORMAL TO TRUE */
                REG_SI0133M1.LINHA_ASACODE["LINHA_NORMAL"] = true;

                /*" -3737- MOVE BRANCO TO LINHA */
                _.Move(W.BRANCO, REG_SI0133M1.LINHA);

                /*" -3738- WRITE REG-SI0133M1 */
                SI0133M1.Write(REG_SI0133M1.GetMoveValues().ToString());

                /*" -3739- SET LINHA-NORMAL TO TRUE */
                REG_SI0133M1.LINHA_ASACODE["LINHA_NORMAL"] = true;

                /*" -3740- MOVE SEP02 TO LINHA */
                _.Move(W.SEP02, REG_SI0133M1.LINHA);

                /*" -3741- WRITE REG-SI0133M1 */
                SI0133M1.Write(REG_SI0133M1.GetMoveValues().ToString());

                /*" -3742- SET LINHA-NORMAL TO TRUE */
                REG_SI0133M1.LINHA_ASACODE["LINHA_NORMAL"] = true;

                /*" -3743- MOVE SEP03 TO LINHA */
                _.Move(W.SEP03, REG_SI0133M1.LINHA);

                /*" -3744- WRITE REG-SI0133M1 */
                SI0133M1.Write(REG_SI0133M1.GetMoveValues().ToString());

                /*" -3745- SET LINHA-NORMAL TO TRUE */
                REG_SI0133M1.LINHA_ASACODE["LINHA_NORMAL"] = true;

                /*" -3746- MOVE SEP03 TO LINHA */
                _.Move(W.SEP03, REG_SI0133M1.LINHA);

                /*" -3747- WRITE REG-SI0133M1 */
                SI0133M1.Write(REG_SI0133M1.GetMoveValues().ToString());

                /*" -3748- SET LINHA-NORMAL TO TRUE */
                REG_SI0133M1.LINHA_ASACODE["LINHA_NORMAL"] = true;

                /*" -3749- MOVE SEP04 TO LINHA */
                _.Move(W.SEP04, REG_SI0133M1.LINHA);

                /*" -3750- WRITE REG-SI0133M1 */
                SI0133M1.Write(REG_SI0133M1.GetMoveValues().ToString());

                /*" -3751- SET LINHA-NORMAL TO TRUE */
                REG_SI0133M1.LINHA_ASACODE["LINHA_NORMAL"] = true;

                /*" -3752- MOVE SEP03 TO LINHA */
                _.Move(W.SEP03, REG_SI0133M1.LINHA);

                /*" -3753- WRITE REG-SI0133M1 */
                SI0133M1.Write(REG_SI0133M1.GetMoveValues().ToString());

                /*" -3754- SET LINHA-NORMAL TO TRUE */
                REG_SI0133M1.LINHA_ASACODE["LINHA_NORMAL"] = true;

                /*" -3755- MOVE SEP07 TO LINHA */
                _.Move(W.SEP07, REG_SI0133M1.LINHA);

                /*" -3756- WRITE REG-SI0133M1 */
                SI0133M1.Write(REG_SI0133M1.GetMoveValues().ToString());

                /*" -3757- SET LINHA-NORMAL TO TRUE */
                REG_SI0133M1.LINHA_ASACODE["LINHA_NORMAL"] = true;

                /*" -3758- MOVE SEP03 TO LINHA */
                _.Move(W.SEP03, REG_SI0133M1.LINHA);

                /*" -3759- WRITE REG-SI0133M1 */
                SI0133M1.Write(REG_SI0133M1.GetMoveValues().ToString());

                /*" -3760- SET LINHA-NORMAL TO TRUE */
                REG_SI0133M1.LINHA_ASACODE["LINHA_NORMAL"] = true;

                /*" -3761- MOVE SEP05 TO LINHA */
                _.Move(W.SEP05, REG_SI0133M1.LINHA);

                /*" -3768- WRITE REG-SI0133M1 */
                SI0133M1.Write(REG_SI0133M1.GetMoveValues().ToString());

                /*" -3769- SET LINHA-NORMAL TO TRUE */
                REG_SI0133M1.LINHA_ASACODE["LINHA_NORMAL"] = true;

                /*" -3770- MOVE SEP03 TO LINHA */
                _.Move(W.SEP03, REG_SI0133M1.LINHA);

                /*" -3771- WRITE REG-SI0133M1 */
                SI0133M1.Write(REG_SI0133M1.GetMoveValues().ToString());

                /*" -3772- SET LINHA-NORMAL TO TRUE */
                REG_SI0133M1.LINHA_ASACODE["LINHA_NORMAL"] = true;

                /*" -3773- MOVE SEP03 TO LINHA */
                _.Move(W.SEP03, REG_SI0133M1.LINHA);

                /*" -3774- WRITE REG-SI0133M1 */
                SI0133M1.Write(REG_SI0133M1.GetMoveValues().ToString());

                /*" -3775- SET LINHA-NORMAL TO TRUE */
                REG_SI0133M1.LINHA_ASACODE["LINHA_NORMAL"] = true;

                /*" -3776- MOVE SEP08 TO LINHA */
                _.Move(W.SEP08, REG_SI0133M1.LINHA);

                /*" -3777- WRITE REG-SI0133M1 */
                SI0133M1.Write(REG_SI0133M1.GetMoveValues().ToString());

                /*" -3778- SET LINHA-NORMAL TO TRUE */
                REG_SI0133M1.LINHA_ASACODE["LINHA_NORMAL"] = true;

                /*" -3779- MOVE SEP02 TO LINHA */
                _.Move(W.SEP02, REG_SI0133M1.LINHA);

                /*" -3780- WRITE REG-SI0133M1 */
                SI0133M1.Write(REG_SI0133M1.GetMoveValues().ToString());

                /*" -3781- SET LINHA-NORMAL TO TRUE */
                REG_SI0133M1.LINHA_ASACODE["LINHA_NORMAL"] = true;

                /*" -3782- MOVE BRANCO TO LINHA */
                _.Move(W.BRANCO, REG_SI0133M1.LINHA);

                /*" -3783- WRITE REG-SI0133M1 */
                SI0133M1.Write(REG_SI0133M1.GetMoveValues().ToString());

                /*" -3783- END-IF. */
            }


        }

        [StopWatch]
        /*" M-510-FOLHA-SEPARADORA-DB-SELECT-1 */
        public void M_510_FOLHA_SEPARADORA_DB_SELECT_1()
        {
            /*" -3683- EXEC SQL SELECT NOME_USUARIO INTO :USUARIOS-NOME-USUARIO FROM SEGUROS.USUARIOS WHERE COD_USUARIO = :RELSIN-CODUSU WITH UR END-EXEC */

            var m_510_FOLHA_SEPARADORA_DB_SELECT_1_Query1 = new M_510_FOLHA_SEPARADORA_DB_SELECT_1_Query1()
            {
                RELSIN_CODUSU = RELSIN_CODUSU.ToString(),
            };

            var executed_1 = M_510_FOLHA_SEPARADORA_DB_SELECT_1_Query1.Execute(m_510_FOLHA_SEPARADORA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.USUARIOS_NOME_USUARIO, USUARIOS.DCLUSUARIOS.USUARIOS_NOME_USUARIO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_510_999_EXIT*/

        [StopWatch]
        /*" M-550-000-IMP-MOVIM-SECTION */
        private void M_550_000_IMP_MOVIM_SECTION()
        {
            /*" -3792- IF WS-IND1 EQUAL 1 */

            if (W.WS_IND1 == 1)
            {

                /*" -3794- MOVE 'VALOR DO MOVIMENTO ............................' TO DESC-MOVIM-C13 */
                _.Move("VALOR DO MOVIMENTO ............................", W.CAB_MOV.DESC_MOVIM_C13);

                /*" -3795- MOVE VALPRI-C13 TO VALOR-MOVIM-C13 */
                _.Move(W.VALPRI_C13, W.CAB_MOV.VALOR_MOVIM_C13);

                /*" -3796- MOVE NOME-BENEF-OCC(1) TO NOME-BENEF-C13 */
                _.Move(W.CAB_MOV_OCC[1].NOME_BENEF_OCC, W.CAB_MOV.NOME_BENEF_C13);

                /*" -3797- MOVE PERC-BENEF-OCC(1) TO PERC-BENEF-C13 */
                _.Move(W.CAB_MOV_OCC[1].PERC_BENEF_OCC, W.CAB_MOV.PERC_BENEF_C13);

                /*" -3798- MOVE PTESCO-BNF-OCC(1) TO PTESCO-BNF-C13 */
                _.Move(W.CAB_MOV_OCC[1].PTESCO_BNF_OCC, W.CAB_MOV.PTESCO_BNF_C13);

                /*" -3799- ELSE */
            }
            else
            {


                /*" -3800- IF WS-IND1 EQUAL 2 */

                if (W.WS_IND1 == 2)
                {

                    /*" -3802- MOVE 'RESSARCIMENTOS RECUPERADOS ....................' TO DESC-MOVIM-C13 */
                    _.Move("RESSARCIMENTOS RECUPERADOS ....................", W.CAB_MOV.DESC_MOVIM_C13);

                    /*" -3803- MOVE RESSARC-C13 TO VALOR-MOVIM-C13 */
                    _.Move(W.RESSARC_C13, W.CAB_MOV.VALOR_MOVIM_C13);

                    /*" -3804- MOVE NOME-BENEF-OCC(2) TO NOME-BENEF-C13 */
                    _.Move(W.CAB_MOV_OCC[2].NOME_BENEF_OCC, W.CAB_MOV.NOME_BENEF_C13);

                    /*" -3805- MOVE PERC-BENEF-OCC(2) TO PERC-BENEF-C13 */
                    _.Move(W.CAB_MOV_OCC[2].PERC_BENEF_OCC, W.CAB_MOV.PERC_BENEF_C13);

                    /*" -3806- MOVE PTESCO-BNF-OCC(2) TO PTESCO-BNF-C13 */
                    _.Move(W.CAB_MOV_OCC[2].PTESCO_BNF_OCC, W.CAB_MOV.PTESCO_BNF_C13);

                    /*" -3807- ELSE */
                }
                else
                {


                    /*" -3808- IF WS-IND1 EQUAL 3 */

                    if (W.WS_IND1 == 3)
                    {

                        /*" -3810- MOVE 'INDENIZACOES PAGAS ............................' TO DESC-MOVIM-C13 */
                        _.Move("INDENIZACOES PAGAS ............................", W.CAB_MOV.DESC_MOVIM_C13);

                        /*" -3811- MOVE TOTPAG-C14 TO VALOR-MOVIM-C13 */
                        _.Move(W.TOTPAG_C14, W.CAB_MOV.VALOR_MOVIM_C13);

                        /*" -3812- MOVE NOME-BENEF-OCC(3) TO NOME-BENEF-C13 */
                        _.Move(W.CAB_MOV_OCC[3].NOME_BENEF_OCC, W.CAB_MOV.NOME_BENEF_C13);

                        /*" -3813- MOVE PERC-BENEF-OCC(3) TO PERC-BENEF-C13 */
                        _.Move(W.CAB_MOV_OCC[3].PERC_BENEF_OCC, W.CAB_MOV.PERC_BENEF_C13);

                        /*" -3814- MOVE PTESCO-BNF-OCC(3) TO PTESCO-BNF-C13 */
                        _.Move(W.CAB_MOV_OCC[3].PTESCO_BNF_OCC, W.CAB_MOV.PTESCO_BNF_C13);

                        /*" -3815- ELSE */
                    }
                    else
                    {


                        /*" -3816- IF WS-IND1 EQUAL 4 */

                        if (W.WS_IND1 == 4)
                        {

                            /*" -3818- MOVE 'SALVADOS RECUPERADOS ..........................' TO DESC-MOVIM-C13 */
                            _.Move("SALVADOS RECUPERADOS ..........................", W.CAB_MOV.DESC_MOVIM_C13);

                            /*" -3819- MOVE SALVADOS-C14 TO VALOR-MOVIM-C13 */
                            _.Move(W.SALVADOS_C14, W.CAB_MOV.VALOR_MOVIM_C13);

                            /*" -3820- MOVE NOME-BENEF-OCC(4) TO NOME-BENEF-C13 */
                            _.Move(W.CAB_MOV_OCC[4].NOME_BENEF_OCC, W.CAB_MOV.NOME_BENEF_C13);

                            /*" -3821- MOVE PERC-BENEF-OCC(4) TO PERC-BENEF-C13 */
                            _.Move(W.CAB_MOV_OCC[4].PERC_BENEF_OCC, W.CAB_MOV.PERC_BENEF_C13);

                            /*" -3822- MOVE PTESCO-BNF-OCC(4) TO PTESCO-BNF-C13 */
                            _.Move(W.CAB_MOV_OCC[4].PTESCO_BNF_OCC, W.CAB_MOV.PTESCO_BNF_C13);

                            /*" -3823- ELSE */
                        }
                        else
                        {


                            /*" -3824- IF WS-IND1 EQUAL 5 */

                            if (W.WS_IND1 == 5)
                            {

                                /*" -3826- MOVE 'ADIANTAMENTOS EFETUADOS .......................' TO DESC-MOVIM-C13 */
                                _.Move("ADIANTAMENTOS EFETUADOS .......................", W.CAB_MOV.DESC_MOVIM_C13);

                                /*" -3827- MOVE SDOADT-C15 TO VALOR-MOVIM-C13 */
                                _.Move(W.SDOADT_C15, W.CAB_MOV.VALOR_MOVIM_C13);

                                /*" -3828- MOVE NOME-BENEF-OCC(5) TO NOME-BENEF-C13 */
                                _.Move(W.CAB_MOV_OCC[5].NOME_BENEF_OCC, W.CAB_MOV.NOME_BENEF_C13);

                                /*" -3829- MOVE PERC-BENEF-OCC(5) TO PERC-BENEF-C13 */
                                _.Move(W.CAB_MOV_OCC[5].PERC_BENEF_OCC, W.CAB_MOV.PERC_BENEF_C13);

                                /*" -3830- MOVE PTESCO-BNF-OCC(5) TO PTESCO-BNF-C13 */
                                _.Move(W.CAB_MOV_OCC[5].PTESCO_BNF_OCC, W.CAB_MOV.PTESCO_BNF_C13);

                                /*" -3831- ELSE */
                            }
                            else
                            {


                                /*" -3832- IF WS-IND1 EQUAL 6 */

                                if (W.WS_IND1 == 6)
                                {

                                    /*" -3834- MOVE 'CANCELAMENTO ..................................' TO DESC-MOVIM-C13 */
                                    _.Move("CANCELAMENTO ..................................", W.CAB_MOV.DESC_MOVIM_C13);

                                    /*" -3835- MOVE CANCELAMENTO-C15 TO VALOR-MOVIM-C13 */
                                    _.Move(W.CANCELAMENTO_C15, W.CAB_MOV.VALOR_MOVIM_C13);

                                    /*" -3836- MOVE NOME-BENEF-OCC(6) TO NOME-BENEF-C13 */
                                    _.Move(W.CAB_MOV_OCC[6].NOME_BENEF_OCC, W.CAB_MOV.NOME_BENEF_C13);

                                    /*" -3837- MOVE PERC-BENEF-OCC(6) TO PERC-BENEF-C13 */
                                    _.Move(W.CAB_MOV_OCC[6].PERC_BENEF_OCC, W.CAB_MOV.PERC_BENEF_C13);

                                    /*" -3838- MOVE PTESCO-BNF-OCC(6) TO PTESCO-BNF-C13 */
                                    _.Move(W.CAB_MOV_OCC[6].PTESCO_BNF_OCC, W.CAB_MOV.PTESCO_BNF_C13);

                                    /*" -3839- ELSE */
                                }
                                else
                                {


                                    /*" -3840- IF WS-IND1 EQUAL 7 */

                                    if (W.WS_IND1 == 7)
                                    {

                                        /*" -3842- MOVE 'DESPESAS E HONORARIOS PAGOS ...................' TO DESC-MOVIM-C13 */
                                        _.Move("DESPESAS E HONORARIOS PAGOS ...................", W.CAB_MOV.DESC_MOVIM_C13);

                                        /*" -3843- MOVE DESPHON-C16 TO VALOR-MOVIM-C13 */
                                        _.Move(W.DESPHON_C16, W.CAB_MOV.VALOR_MOVIM_C13);

                                        /*" -3844- MOVE NOME-BENEF-OCC(7) TO NOME-BENEF-C13 */
                                        _.Move(W.CAB_MOV_OCC[7].NOME_BENEF_OCC, W.CAB_MOV.NOME_BENEF_C13);

                                        /*" -3845- MOVE PERC-BENEF-OCC(7) TO PERC-BENEF-C13 */
                                        _.Move(W.CAB_MOV_OCC[7].PERC_BENEF_OCC, W.CAB_MOV.PERC_BENEF_C13);

                                        /*" -3846- MOVE PTESCO-BNF-OCC(7) TO PTESCO-BNF-C13 */
                                        _.Move(W.CAB_MOV_OCC[7].PTESCO_BNF_OCC, W.CAB_MOV.PTESCO_BNF_C13);

                                        /*" -3847- ELSE */
                                    }
                                    else
                                    {


                                        /*" -3848- IF WS-IND1 EQUAL 8 */

                                        if (W.WS_IND1 == 8)
                                        {

                                            /*" -3850- MOVE 'REATIVACAO ....................................' TO DESC-MOVIM-C13 */
                                            _.Move("REATIVACAO ....................................", W.CAB_MOV.DESC_MOVIM_C13);

                                            /*" -3851- MOVE REATIVACAO-C16 TO VALOR-MOVIM-C13 */
                                            _.Move(W.REATIVACAO_C16, W.CAB_MOV.VALOR_MOVIM_C13);

                                            /*" -3852- MOVE NOME-BENEF-OCC(8) TO NOME-BENEF-C13 */
                                            _.Move(W.CAB_MOV_OCC[8].NOME_BENEF_OCC, W.CAB_MOV.NOME_BENEF_C13);

                                            /*" -3853- MOVE PERC-BENEF-OCC(8) TO PERC-BENEF-C13 */
                                            _.Move(W.CAB_MOV_OCC[8].PERC_BENEF_OCC, W.CAB_MOV.PERC_BENEF_C13);

                                            /*" -3854- MOVE PTESCO-BNF-OCC(8) TO PTESCO-BNF-C13 */
                                            _.Move(W.CAB_MOV_OCC[8].PTESCO_BNF_OCC, W.CAB_MOV.PTESCO_BNF_C13);

                                            /*" -3855- ELSE */
                                        }
                                        else
                                        {


                                            /*" -3856- IF WS-IND1 EQUAL 9 */

                                            if (W.WS_IND1 == 9)
                                            {

                                                /*" -3858- MOVE 'INDENIZACOES A RECUPERAR IRB/COSSEGURADORAS ...' TO DESC-MOVIM-C13 */
                                                _.Move("INDENIZACOES A RECUPERAR IRB/COSSEGURADORAS ...", W.CAB_MOV.DESC_MOVIM_C13);

                                                /*" -3859- MOVE SDORCP-C17 TO VALOR-MOVIM-C13 */
                                                _.Move(W.SDORCP_C17, W.CAB_MOV.VALOR_MOVIM_C13);

                                                /*" -3860- MOVE NOME-BENEF-OCC(9) TO NOME-BENEF-C13 */
                                                _.Move(W.CAB_MOV_OCC[9].NOME_BENEF_OCC, W.CAB_MOV.NOME_BENEF_C13);

                                                /*" -3861- MOVE PERC-BENEF-OCC(9) TO PERC-BENEF-C13 */
                                                _.Move(W.CAB_MOV_OCC[9].PERC_BENEF_OCC, W.CAB_MOV.PERC_BENEF_C13);

                                                /*" -3862- MOVE PTESCO-BNF-OCC(9) TO PTESCO-BNF-C13 */
                                                _.Move(W.CAB_MOV_OCC[9].PTESCO_BNF_OCC, W.CAB_MOV.PTESCO_BNF_C13);

                                                /*" -3863- ELSE */
                                            }
                                            else
                                            {


                                                /*" -3864- IF WS-IND1 EQUAL 10 */

                                                if (W.WS_IND1 == 10)
                                                {

                                                    /*" -3866- MOVE 'ALTERACOES/AJUSTES DE RESERVA .................' TO DESC-MOVIM-C13 */
                                                    _.Move("ALTERACOES/AJUSTES DE RESERVA .................", W.CAB_MOV.DESC_MOVIM_C13);

                                                    /*" -3867- MOVE RESERVA-C17 TO VALOR-MOVIM-C13 */
                                                    _.Move(W.RESERVA_C17, W.CAB_MOV.VALOR_MOVIM_C13);

                                                    /*" -3868- MOVE NOME-BENEF-OCC(10) TO NOME-BENEF-C13 */
                                                    _.Move(W.CAB_MOV_OCC[10].NOME_BENEF_OCC, W.CAB_MOV.NOME_BENEF_C13);

                                                    /*" -3869- MOVE PERC-BENEF-OCC(10) TO PERC-BENEF-C13 */
                                                    _.Move(W.CAB_MOV_OCC[10].PERC_BENEF_OCC, W.CAB_MOV.PERC_BENEF_C13);

                                                    /*" -3870- MOVE PTESCO-BNF-OCC(10) TO PTESCO-BNF-C13 */
                                                    _.Move(W.CAB_MOV_OCC[10].PTESCO_BNF_OCC, W.CAB_MOV.PTESCO_BNF_C13);

                                                    /*" -3871- ELSE */
                                                }
                                                else
                                                {


                                                    /*" -3872- IF WS-IND1 EQUAL 11 */

                                                    if (W.WS_IND1 == 11)
                                                    {

                                                        /*" -3874- MOVE 'DESPESAS A RECUPERAR IRB/COSSEGURADORAS .......' TO DESC-MOVIM-C13 */
                                                        _.Move("DESPESAS A RECUPERAR IRB/COSSEGURADORAS .......", W.CAB_MOV.DESC_MOVIM_C13);

                                                        /*" -3875- MOVE DESPREC-C18 TO VALOR-MOVIM-C13 */
                                                        _.Move(W.DESPREC_C18, W.CAB_MOV.VALOR_MOVIM_C13);

                                                        /*" -3876- MOVE NOME-BENEF-OCC(11) TO NOME-BENEF-C13 */
                                                        _.Move(W.CAB_MOV_OCC[11].NOME_BENEF_OCC, W.CAB_MOV.NOME_BENEF_C13);

                                                        /*" -3877- MOVE PERC-BENEF-OCC(11) TO PERC-BENEF-C13 */
                                                        _.Move(W.CAB_MOV_OCC[11].PERC_BENEF_OCC, W.CAB_MOV.PERC_BENEF_C13);

                                                        /*" -3878- MOVE PTESCO-BNF-OCC(11) TO PTESCO-BNF-C13 */
                                                        _.Move(W.CAB_MOV_OCC[11].PTESCO_BNF_OCC, W.CAB_MOV.PTESCO_BNF_C13);

                                                        /*" -3879- ELSE */
                                                    }
                                                    else
                                                    {


                                                        /*" -3880- IF WS-IND1 EQUAL 12 */

                                                        if (W.WS_IND1 == 12)
                                                        {

                                                            /*" -3881- MOVE '  ' TO DESC-MOVIM-C13 */
                                                            _.Move("  ", W.CAB_MOV.DESC_MOVIM_C13);

                                                            /*" -3882- MOVE SPACES TO VALOR-LIN-BENEF */
                                                            _.Move("", W.CAB_MOV.FILLER_56.VALOR_LIN_BENEF);

                                                            /*" -3883- MOVE NOME-BENEF-OCC(12) TO NOME-BENEF-C13 */
                                                            _.Move(W.CAB_MOV_OCC[12].NOME_BENEF_OCC, W.CAB_MOV.NOME_BENEF_C13);

                                                            /*" -3884- MOVE PERC-BENEF-OCC(12) TO PERC-BENEF-C13 */
                                                            _.Move(W.CAB_MOV_OCC[12].PERC_BENEF_OCC, W.CAB_MOV.PERC_BENEF_C13);

                                                            /*" -3885- MOVE PTESCO-BNF-OCC(12) TO PTESCO-BNF-C13 */
                                                            _.Move(W.CAB_MOV_OCC[12].PTESCO_BNF_OCC, W.CAB_MOV.PTESCO_BNF_C13);

                                                            /*" -3886- ELSE */
                                                        }
                                                        else
                                                        {


                                                            /*" -3887- IF WS-IND1 EQUAL 13 */

                                                            if (W.WS_IND1 == 13)
                                                            {

                                                                /*" -3888- MOVE '  ' TO DESC-MOVIM-C13 */
                                                                _.Move("  ", W.CAB_MOV.DESC_MOVIM_C13);

                                                                /*" -3889- MOVE SPACES TO VALOR-LIN-BENEF */
                                                                _.Move("", W.CAB_MOV.FILLER_56.VALOR_LIN_BENEF);

                                                                /*" -3890- MOVE NOME-BENEF-OCC(13) TO NOME-BENEF-C13 */
                                                                _.Move(W.CAB_MOV_OCC[13].NOME_BENEF_OCC, W.CAB_MOV.NOME_BENEF_C13);

                                                                /*" -3891- MOVE PERC-BENEF-OCC(13) TO PERC-BENEF-C13 */
                                                                _.Move(W.CAB_MOV_OCC[13].PERC_BENEF_OCC, W.CAB_MOV.PERC_BENEF_C13);

                                                                /*" -3892- MOVE PTESCO-BNF-OCC(13) TO PTESCO-BNF-C13 */
                                                                _.Move(W.CAB_MOV_OCC[13].PTESCO_BNF_OCC, W.CAB_MOV.PTESCO_BNF_C13);

                                                                /*" -3893- ELSE */
                                                            }
                                                            else
                                                            {


                                                                /*" -3894- IF WS-IND1 EQUAL 14 */

                                                                if (W.WS_IND1 == 14)
                                                                {

                                                                    /*" -3895- MOVE '  ' TO DESC-MOVIM-C13 */
                                                                    _.Move("  ", W.CAB_MOV.DESC_MOVIM_C13);

                                                                    /*" -3896- MOVE SPACES TO VALOR-LIN-BENEF */
                                                                    _.Move("", W.CAB_MOV.FILLER_56.VALOR_LIN_BENEF);

                                                                    /*" -3897- MOVE NOME-BENEF-OCC(14) TO NOME-BENEF-C13 */
                                                                    _.Move(W.CAB_MOV_OCC[14].NOME_BENEF_OCC, W.CAB_MOV.NOME_BENEF_C13);

                                                                    /*" -3898- MOVE PERC-BENEF-OCC(14) TO PERC-BENEF-C13 */
                                                                    _.Move(W.CAB_MOV_OCC[14].PERC_BENEF_OCC, W.CAB_MOV.PERC_BENEF_C13);

                                                                    /*" -3899- MOVE PTESCO-BNF-OCC(14) TO PTESCO-BNF-C13 */
                                                                    _.Move(W.CAB_MOV_OCC[14].PTESCO_BNF_OCC, W.CAB_MOV.PTESCO_BNF_C13);

                                                                    /*" -3900- ELSE */
                                                                }
                                                                else
                                                                {


                                                                    /*" -3901- IF WS-IND1 EQUAL 15 */

                                                                    if (W.WS_IND1 == 15)
                                                                    {

                                                                        /*" -3902- MOVE '  ' TO DESC-MOVIM-C13 */
                                                                        _.Move("  ", W.CAB_MOV.DESC_MOVIM_C13);

                                                                        /*" -3903- MOVE SPACES TO VALOR-LIN-BENEF */
                                                                        _.Move("", W.CAB_MOV.FILLER_56.VALOR_LIN_BENEF);

                                                                        /*" -3904- MOVE NOME-BENEF-OCC(15) TO NOME-BENEF-C13 */
                                                                        _.Move(W.CAB_MOV_OCC[15].NOME_BENEF_OCC, W.CAB_MOV.NOME_BENEF_C13);

                                                                        /*" -3905- MOVE PERC-BENEF-OCC(15) TO PERC-BENEF-C13 */
                                                                        _.Move(W.CAB_MOV_OCC[15].PERC_BENEF_OCC, W.CAB_MOV.PERC_BENEF_C13);

                                                                        /*" -3907- MOVE PTESCO-BNF-OCC(15) TO PTESCO-BNF-C13. */
                                                                        _.Move(W.CAB_MOV_OCC[15].PTESCO_BNF_OCC, W.CAB_MOV.PTESCO_BNF_C13);
                                                                    }

                                                                }

                                                            }

                                                        }

                                                    }

                                                }

                                            }

                                        }

                                    }

                                }

                            }

                        }

                    }

                }

            }


            /*" -3908- SET LINHA-NORMAL TO TRUE */
            REG_SI0133M1.LINHA_ASACODE["LINHA_NORMAL"] = true;

            /*" -3909- MOVE CAB-MOV TO LINHA */
            _.Move(W.CAB_MOV, REG_SI0133M1.LINHA);

            /*" -3909- WRITE REG-SI0133M1. */
            SI0133M1.Write(REG_SI0133M1.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_550_000_FIM*/

        [StopWatch]
        /*" M-501-000-CABECALHO-SECTION */
        private void M_501_000_CABECALHO_SECTION()
        {
            /*" -3923- MOVE '501-000-CABECALHO' TO PARAGRAFO. */
            _.Move("501-000-CABECALHO", WABEND.PARAGRAFO);

            /*" -3924- ADD 1 TO WS-CONT-PAGINA. */
            W.WS_CONT_PAGINA.Value = W.WS_CONT_PAGINA + 1;

            /*" -3926- MOVE ZEROS TO WS-CONT-LINHA. */
            _.Move(0, W.WS_CONT_LINHA);

            /*" -3927- SET NOVA-PAGINA TO TRUE */
            REG_SI0133M1.LINHA_ASACODE["NOVA_PAGINA"] = true;

            /*" -3928- MOVE CAB01 TO LINHA */
            _.Move(W.CAB01, REG_SI0133M1.LINHA);

            /*" -3931- WRITE REG-SI0133M1 */
            SI0133M1.Write(REG_SI0133M1.GetMoveValues().ToString());

            /*" -3932- SET LINHA-NORMAL TO TRUE */
            REG_SI0133M1.LINHA_ASACODE["LINHA_NORMAL"] = true;

            /*" -3933- MOVE CAB02 TO LINHA */
            _.Move(W.CAB02, REG_SI0133M1.LINHA);

            /*" -3937- WRITE REG-SI0133M1 */
            SI0133M1.Write(REG_SI0133M1.GetMoveValues().ToString());

            /*" -3938- SET LINHA-NORMAL TO TRUE */
            REG_SI0133M1.LINHA_ASACODE["LINHA_NORMAL"] = true;

            /*" -3939- MOVE CAB02B TO LINHA */
            _.Move(W.CAB02B, REG_SI0133M1.LINHA);

            /*" -3943- WRITE REG-SI0133M1 */
            SI0133M1.Write(REG_SI0133M1.GetMoveValues().ToString());

            /*" -3944- SET LINHA-NORMAL TO TRUE */
            REG_SI0133M1.LINHA_ASACODE["LINHA_NORMAL"] = true;

            /*" -3945- MOVE TRACO TO LINHA */
            _.Move(W.TRACO, REG_SI0133M1.LINHA);

            /*" -3945- WRITE REG-SI0133M1. */
            SI0133M1.Write(REG_SI0133M1.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_501_999_EXIT*/

        [StopWatch]
        /*" M-503-000-PARTE02-SECTION */
        private void M_503_000_PARTE02_SECTION()
        {
            /*" -3961- MOVE '503-000-PARTE02' TO PARAGRAFO. */
            _.Move("503-000-PARTE02", WABEND.PARAGRAFO);

            /*" -3961- PERFORM 180-000-LER-THISTSIN. */

            M_180_000_LER_THISTSIN_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_503_999_EXIT*/

        [StopWatch]
        /*" M-570-000-IMPRIME-DETALHE-SECTION */
        private void M_570_000_IMPRIME_DETALHE_SECTION()
        {
            /*" -3969- MOVE NOMFAV-OCC(WS-IND1) TO NOMFAV-DET */
            _.Move(W.DETALHE_OCC[W.WS_IND1].NOMFAV_OCC, W.DETALHE.NOMFAV_DET);

            /*" -3970- MOVE TIPFAV-OCC(WS-IND1) TO TIPFAV-DET */
            _.Move(W.DETALHE_OCC[W.WS_IND1].TIPFAV_OCC, W.DETALHE.TIPFAV_DET);

            /*" -3972- MOVE TIPPAG-OCC(WS-IND1) TO TIPPAG-DET */
            _.Move(W.DETALHE_OCC[W.WS_IND1].TIPPAG_OCC, W.DETALHE.TIPPAG_DET);

            /*" -3973- MOVE VAL-OP-OCC(WS-IND1) TO VAL-OP-DET */
            _.Move(W.DETALHE_OCC[W.WS_IND1].VAL_OP_OCC, W.DETALHE.VAL_OP_DET);

            /*" -3974- MOVE VENCB1-OCC(WS-IND1) TO VENCB1-DET */
            _.Move(W.DETALHE_OCC[W.WS_IND1].VENCTO_OCC.VENCB1_OCC, W.DETALHE.VENCTO_DET.VENCB1_DET);

            /*" -3975- MOVE VENCB2-OCC(WS-IND1) TO VENCB2-DET */
            _.Move(W.DETALHE_OCC[W.WS_IND1].VENCTO_OCC.VENCB2_OCC, W.DETALHE.VENCTO_DET.VENCB2_DET);

            /*" -3976- MOVE VENCDD-OCC(WS-IND1) TO VENCDD-DET */
            _.Move(W.DETALHE_OCC[W.WS_IND1].VENCTO_OCC.VENCDD_OCC, W.DETALHE.VENCTO_DET.VENCDD_DET);

            /*" -3977- MOVE VENCMM-OCC(WS-IND1) TO VENCMM-DET */
            _.Move(W.DETALHE_OCC[W.WS_IND1].VENCTO_OCC.VENCMM_OCC, W.DETALHE.VENCTO_DET.VENCMM_DET);

            /*" -3978- MOVE VENCAA-OCC(WS-IND1) TO VENCAA-DET */
            _.Move(W.DETALHE_OCC[W.WS_IND1].VENCTO_OCC.VENCAA_OCC, W.DETALHE.VENCTO_DET.VENCAA_DET);

            /*" -3979- MOVE FONPAG-OCC(WS-IND1) TO FONPAG-DET */
            _.Move(W.DETALHE_OCC[W.WS_IND1].FONPAG_OCC, W.DETALHE.FONPAG_DET);

            /*" -3981- MOVE JURID-OCC(WS-IND1) TO COD-PROC-JUR-DET */
            _.Move(W.DETALHE_OCC[W.WS_IND1].JURID_OCC, W.DETALHE.COD_PROC_JUR_DET);

            /*" -3982- SET LINHA-NORMAL TO TRUE */
            REG_SI0133M1.LINHA_ASACODE["LINHA_NORMAL"] = true;

            /*" -3983- MOVE DETALHE TO LINHA */
            _.Move(W.DETALHE, REG_SI0133M1.LINHA);

            /*" -3983- WRITE REG-SI0133M1. */
            SI0133M1.Write(REG_SI0133M1.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_570_000_FIM*/

        [StopWatch]
        /*" M-600-000-CALCULA-VALOR-SECTION */
        private void M_600_000_CALCULA_VALOR_SECTION()
        {
            /*" -3999- MOVE MEST-COD-MOEDA-SIN TO WGEUNIMO-CODUNIMO WMOEDA. */
            _.Move(MEST_COD_MOEDA_SIN, WGEUNIMO_CODUNIMO, WMOEDA);

            /*" -4002- MOVE THIST-DTMOVTO TO WGEUNIMO-DTINIVIG WGEUNIMO-DTTERVIG. */
            _.Move(THIST_DTMOVTO, WGEUNIMO_DTINIVIG, WGEUNIMO_DTTERVIG);

            /*" -4004- PERFORM 610-000-LER-TGEUNIMO. */

            M_610_000_LER_TGEUNIMO_SECTION();

            /*" -4008- COMPUTE WQTD-MOEDA = THIST-VALPRI / GEUNIMO-VLCRUZAD. */
            W.WQTD_MOEDA.Value = THIST_VALPRI / GEUNIMO_VLCRUZAD;

            /*" -4011- MOVE SIST-DTMOVABE TO WGEUNIMO-DTINIVIG WGEUNIMO-DTTERVIG. */
            _.Move(SIST_DTMOVABE, WGEUNIMO_DTINIVIG, WGEUNIMO_DTTERVIG);

            /*" -4013- PERFORM 610-000-LER-TGEUNIMO. */

            M_610_000_LER_TGEUNIMO_SECTION();

            /*" -4014- COMPUTE WC-VALOR = WQTD-MOEDA * GEUNIMO-VLCRUZAD. */
            W.WC_VALOR.Value = W.WQTD_MOEDA * GEUNIMO_VLCRUZAD;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_600_999_EXIT*/

        [StopWatch]
        /*" M-610-000-LER-TGEUNIMO-SECTION */
        private void M_610_000_LER_TGEUNIMO_SECTION()
        {
            /*" -4025- MOVE '041' TO WNR-EXEC-SQL */
            _.Move("041", WABEND.WNR_EXEC_SQL);

            /*" -4029- MOVE '610-000-LER-TGEUNIMO' TO PARAGRAFO. */
            _.Move("610-000-LER-TGEUNIMO", WABEND.PARAGRAFO);

            /*" -4038- PERFORM M_610_000_LER_TGEUNIMO_DB_SELECT_1 */

            M_610_000_LER_TGEUNIMO_DB_SELECT_1();

            /*" -4041- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -4045- DISPLAY 'SI0133B  - NAO CONSTA REGISTRO NA V1MOEDA ' ' - CODUNIMO = ' WMOEDA ' - DTINIVIG = ' WGEUNIMO-DTINIVIG ' - DTTERVIG = ' WGEUNIMO-DTTERVIG */

                $"SI0133B  - NAO CONSTA REGISTRO NA V1MOEDA  - CODUNIMO = {WMOEDA} - DTINIVIG = {WGEUNIMO_DTINIVIG} - DTTERVIG = {WGEUNIMO_DTTERVIG}"
                .Display();

                /*" -4045- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-610-000-LER-TGEUNIMO-DB-SELECT-1 */
        public void M_610_000_LER_TGEUNIMO_DB_SELECT_1()
        {
            /*" -4038- EXEC SQL SELECT VLCRUZAD, SIGLUNIM INTO :GEUNIMO-VLCRUZAD, :GEUNIMO-SIGLUNIM FROM SEGUROS.V1MOEDA WHERE CODUNIMO = :WMOEDA AND DTINIVIG <= :WGEUNIMO-DTINIVIG AND DTTERVIG >= :WGEUNIMO-DTTERVIG END-EXEC. */

            var m_610_000_LER_TGEUNIMO_DB_SELECT_1_Query1 = new M_610_000_LER_TGEUNIMO_DB_SELECT_1_Query1()
            {
                WGEUNIMO_DTINIVIG = WGEUNIMO_DTINIVIG.ToString(),
                WGEUNIMO_DTTERVIG = WGEUNIMO_DTTERVIG.ToString(),
                WMOEDA = WMOEDA.ToString(),
            };

            var executed_1 = M_610_000_LER_TGEUNIMO_DB_SELECT_1_Query1.Execute(m_610_000_LER_TGEUNIMO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.GEUNIMO_VLCRUZAD, GEUNIMO_VLCRUZAD);
                _.Move(executed_1.GEUNIMO_SIGLUNIM, GEUNIMO_SIGLUNIM);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_610_999_EXIT*/

        [StopWatch]
        /*" M-650-000-ACERTA-VALORES-SECTION */
        private void M_650_000_ACERTA_VALORES_SECTION()
        {
            /*" -4058- MOVE MEST-COD-MOEDA-SIN TO WGEUNIMO-CODUNIMO WMOEDA. */
            _.Move(MEST_COD_MOEDA_SIN, WGEUNIMO_CODUNIMO, WMOEDA);

            /*" -4060- MOVE SIST-DTMOVABE TO WGEUNIMO-DTINIVIG WGEUNIMO-DTTERVIG. */
            _.Move(SIST_DTMOVABE, WGEUNIMO_DTINIVIG, WGEUNIMO_DTTERVIG);

            /*" -4061- PERFORM 610-000-LER-TGEUNIMO. */

            M_610_000_LER_TGEUNIMO_SECTION();

            /*" -4063- COMPUTE MEST-TOTPAG = MEST-TOTPAGBT * GEUNIMO-VLCRUZAD. */
            MEST_TOTPAG.Value = MEST_TOTPAGBT * GEUNIMO_VLCRUZAD;

            /*" -4065- COMPUTE MEST-TOTDSA = MEST-TOTDSABT * GEUNIMO-VLCRUZAD. */
            MEST_TOTDSA.Value = MEST_TOTDSABT * GEUNIMO_VLCRUZAD;

            /*" -4067- COMPUTE MEST-TOTHON = MEST-TOTHONBT * GEUNIMO-VLCRUZAD. */
            MEST_TOTHON.Value = MEST_TOTHONBT * GEUNIMO_VLCRUZAD;

            /*" -4069- COMPUTE MEST-TOTRSD = MEST-TOTRSDBT * GEUNIMO-VLCRUZAD. */
            MEST_TOTRSD.Value = MEST_TOTRSDBT * GEUNIMO_VLCRUZAD;

            /*" -4071- COMPUTE MEST-SDORCP = MEST-SDORCPBT * GEUNIMO-VLCRUZAD. */
            MEST_SDORCP.Value = MEST_SDORCPBT * GEUNIMO_VLCRUZAD;

            /*" -4072- COMPUTE MEST-SDOADT = MEST-SDOADTBT * GEUNIMO-VLCRUZAD. */
            MEST_SDOADT.Value = MEST_SDOADTBT * GEUNIMO_VLCRUZAD;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_650_999_EXIT*/

        [StopWatch]
        /*" M-900-000-FINALIZA-SECTION */
        private void M_900_000_FINALIZA_SECTION()
        {
            /*" -4090- MOVE '900-000-FINALIZA' TO PARAGRAFO. */
            _.Move("900-000-FINALIZA", WABEND.PARAGRAFO);

            /*" -4093- MOVE '042' TO WNR-EXEC-SQL. */
            _.Move("042", WABEND.WNR_EXEC_SQL);

            /*" -4095- CLOSE SI0133M1. */
            SI0133M1.Close();

            /*" -4096- IF WLIDOS-E NOT EQUAL 0 */

            if (W.WLIDOS_E != 0)
            {

                /*" -4097- DISPLAY 'TOTAL LIDOS EMISSAO       = ' WLIDOS-E */
                _.Display($"TOTAL LIDOS EMISSAO       = {W.WLIDOS_E}");

                /*" -4098- DISPLAY 'TOTAL DUPLICADOS EMISSAO  = ' WDUPLICADOS-E */
                _.Display($"TOTAL DUPLICADOS EMISSAO  = {W.WDUPLICADOS_E}");

                /*" -4099- DISPLAY 'TOTAL DESPREZADOS EMISSAO = ' WDESPREZADOS-E */
                _.Display($"TOTAL DESPREZADOS EMISSAO = {W.WDESPREZADOS_E}");

                /*" -4101- DISPLAY 'TOTAL IMPRESSOS EMISSAO   = ' WIMPRES-E. */
                _.Display($"TOTAL IMPRESSOS EMISSAO   = {W.WIMPRES_E}");
            }


            /*" -4102- MOVE ZEROS TO RETURN-CODE */
            _.Move(0, RETURN_CODE);

            /*" -4103- DISPLAY '/////////////////////////////////////////' */
            _.Display($"/////////////////////////////////////////");

            /*" -4104- DISPLAY '/////////////////////////////////////////' */
            _.Display($"/////////////////////////////////////////");

            /*" -4105- DISPLAY '//                                     //' */
            _.Display($"//                                     //");

            /*" -4106- DISPLAY '//     ==>     SI0133B      <==        //' */
            _.Display($"//     ==>     SI0133B      <==        //");

            /*" -4107- DISPLAY '//                                     //' */
            _.Display($"//                                     //");

            /*" -4108- DISPLAY '//     ==>  TERMINO NORMAL  <==        //' */
            _.Display($"//     ==>  TERMINO NORMAL  <==        //");

            /*" -4109- DISPLAY '//                                     //' */
            _.Display($"//                                     //");

            /*" -4110- DISPLAY '/////////////////////////////////////////' */
            _.Display($"/////////////////////////////////////////");

            /*" -4110- DISPLAY '/////////////////////////////////////////' . */
            _.Display($"/////////////////////////////////////////");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_900_999_EXIT*/

        [StopWatch]
        /*" M-999-999-ROT-ERRO-SECTION */
        private void M_999_999_ROT_ERRO_SECTION()
        {
            /*" -4123- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4124- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, WABEND.WSQLCODE);

                /*" -4125- MOVE SQLERRD(1) TO WSQLCODE1 */
                _.Move(DB.SQLERRD[1], WABEND.WSQLCODE1);

                /*" -4126- MOVE SQLERRD(2) TO WSQLCODE2 */
                _.Move(DB.SQLERRD[2], WABEND.WSQLCODE2);

                /*" -4127- MOVE SQLCODE TO WSQLCODE3 */
                _.Move(DB.SQLCODE, W.WSQLCODE3);

                /*" -4128- DISPLAY WABEND */
                _.Display(WABEND);

                /*" -4129- DISPLAY ' ' */
                _.Display($" ");

                /*" -4130- DISPLAY SQLERRML ' ' SQLERRMC */

                $"SQLERRML {DB.SQLERRMC}"
                .Display();

                /*" -4137- DISPLAY SQLERRD (1) ' ' SQLERRD (2) ' ' SQLERRD (3) ' ' SQLERRD (4) ' ' SQLERRD (5) ' ' SQLERRD (6). */

                $"{DB.SQLERRD[1]} {DB.SQLERRD[2]} {DB.SQLERRD[3]} {DB.SQLERRD[4]} {DB.SQLERRD[5]} {DB.SQLERRD[6]}"
                .Display();
            }


            /*" -4138- CLOSE SI0133M1. */
            SI0133M1.Close();

            /*" -4138- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -4139- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -4141- MOVE 99 TO RETURN-CODE */
            _.Move(99, RETURN_CODE);

            /*" -4141- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -4142- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_999_999_EXIT_ROT_ERRO*/
    }
}