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
using Sias.Geral.DB2.GE0080B;

namespace Code
{
    public class GE0080B
    {
        public bool IsCall { get; set; }

        public GE0080B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------                                 */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  SINISTRO/FINANCEIRO                *      */
        /*"      *   PROGRAMA ...............  GE0080B                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  HEIDER COELHO                      *      */
        /*"      *   PROGRAMADOR ............  HEIDER COELHO                      *      */
        /*"      *   DATA CODIFICACAO .......  JUNHO / 2010                       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO:                                                      *      */
        /*"      *   SUB-ROTINA DE RECUPERACAO DO DIGITO VERIFICADOR DE BANCO     *      */
        /*"      *   INFORMADO. A RELACAO DE BANCOS FOI FORNECIDA PELA EQUIPE     *      */
        /*"      *   DE IMPLEMENTA��O DO SAP                                      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.23  * VERSAO  : 022                                                         */
        /*"      * MOTIVO  : INCLUSAO BANCO 085-0 COOP CENTRAL AILOS                     */
        /*"      *         : INCLUSAO BANCO 085-0 TABELA SIUS.GE_BANCO_SAP(SCRIPT)       */
        /*"      * JAZZ    : 396508                                                      */
        /*"      * DATA    : 20/06/2022                                                  */
        /*"      * NOME    : HERVAL SOUZA                                                */
        /*"      *----------------------------------------------------------------*      */
        /*"V.22  * VERSAO  : 022                                                         */
        /*"      * MOTIVO  : INCLUSAO BANCO 380-0  - PICPAY                              */
        /*"      *         : INCLUSAO BANCO 380-0 TABELA SIUS.GE_BANCO_SAP(SCRIPT)       */
        /*"      * JAZZ    : 376394                                                      */
        /*"      * DATA    : 28/03/2022                                                  */
        /*"      * NOME    : DIOGO MATHEUS                                               */
        /*"      * MARCADOR: V.22                                                        */
        /*"      *----------------------------------------------------------------*      */
        /*"V.21  * VERSAO  : 021                                                         */
        /*"      * MOTIVO  : INCLUSAO BANCO 136-0  - BANCO UNICRED                       */
        /*"      *         : INCLUSAO BANCO 136-0 TABELA SIUS.GE_BANCO_SAP(SCRIPT)       */
        /*"      * JAZZ    : 354549                                                      */
        /*"      * DATA    : 11/01/2022                                                  */
        /*"      * NOME    : DIOGO MATHEUS                                               */
        /*"      * MARCADOR: V.21                                                        */
        /*"      *----------------------------------------------------------------*      */
        /*"V.20  * VERSAO  : 020                                                         */
        /*"      * MOTIVO  : INCLUSAO BANCO 403 - CORA SOCIEDADE DE CR�DITO DIRETO       */
        /*"      * JAZZ    : 352378                                                      */
        /*"      * DATA    : 05/01/2021                                                  */
        /*"      * NOME    : EDIJANE INACIO                                              */
        /*"      * MARCADOR: V.20                                                        */
        /*"      *----------------------------------------------------------------*      */
        /*"V.19  * VERSAO  : 019                                                         */
        /*"      * MOTIVO  : INCLUSAO BANCO 121-0  - BANCO AGIPLAN S/A.                  */
        /*"      *         : INCLUSAO BANCO 121-0 TABELA SIUS.GE_BANCO_SAP(SCRIPT)       */
        /*"      * JAZZ    : 336675                                                      */
        /*"      * DATA    : 12/11/2021                                                  */
        /*"      * NOME    : DIOGO MATHEUS                                               */
        /*"      * MARCADOR: V.19                                                        */
        /*"      *----------------------------------------------------------------*      */
        /*"V.18  * VERSAO  : 018                                                         */
        /*"      * MOTIVO  : INCLUSAO BANCO 087-6 UNICRED CENTRAL SANTA CATARINA         */
        /*"      *         : INCLUSAO BANCO 087-6 TABELA SIUS.GE_BANCO_SAP(SCRIPT)       */
        /*"      * JAZZ    : 334595                                                      */
        /*"      * DATA    : 05/11/2021                                                  */
        /*"      * NOME    : DIOGO MATHEUS                                               */
        /*"      * MARCADOR: V.18                                                        */
        /*"      *----------------------------------------------------------------*      */
        /*"V.17  * VERSAO  : 017                                                         */
        /*"      * MOTIVO  : INCLUSAO BANCO 084-1 UNIPRIME NORTE DO PARANA               */
        /*"      *         : INCLUSAO BANCO 084-1 TABELA SIUS.GE_BANCO_SAP(SCRIPT)       */
        /*"      * JAZZ    : 318428                                                      */
        /*"      * DATA    : 17/09/2021                                                  */
        /*"      * NOME    : DIOGO MATHEUS                                               */
        /*"      * MARCADOR: V.17                                                        */
        /*"      *----------------------------------------------------------------*      */
        /*"V.16  * VERSAO  : 016                                                         */
        /*"      * MOTIVO  : INCLUSAO BANCO 336 C6                                       */
        /*"      * JAZZ    : 311509                                                      */
        /*"      * DATA    : 26/08/2021                                                  */
        /*"      * NOME    : Rildo                                                       */
        /*"      * MARCADOR: V.16                                                        */
        /*"      *----------------------------------------------------------------*      */
        /*"V.15  * VERSAO  : 015                                                         */
        /*"      * MOTIVO  : INCLUSAO BANCO 290 PAGSEGURO                                */
        /*"      * JAZZ    : 307631                                                      */
        /*"      * DATA    : 13/08/2021                                                  */
        /*"      * NOME    : DIOGO MATHEUS                                               */
        /*"      * MARCADOR: V.15                                                        */
        /*"      *----------------------------------------------------------------*      */
        /*"V.14  * VERSAO  : 014                                                         */
        /*"      * MOTIVO  : RETIRADA DE DISPLAY NA SYSOUT DE CHAMADA DESSA SUBROT.      */
        /*"      * JAZZ    : 290247                                                      */
        /*"      * DATA    : 08/06/2021                                                  */
        /*"      * NOME    : ALCIONE ARAUJO                                              */
        /*"      * MARCADOR: V.14                                                        */
        /*"      *----------------------------------------------------------------*      */
        /*"V.13  * VERSAO  : 013                                                         */
        /*"      * MOTIVO  : INCLUSAO BANCO 323.9-MERCADOPAGO.COM REPRESENTACOES         */
        /*"      * JAZZ    :                                                             */
        /*"      * DATA    : 30/03/2021                                                  */
        /*"      * NOME    : EDIJANE INACIO                                              */
        /*"      * MARCADOR: V.13                                                        */
        /*"      *----------------------------------------------------------------*      */
        /*"V.12  * VERSAO  : 012                                                  *      */
        /*"      * MOTIVO  : INCLUSAO DO BANCO 075-2 BANCO CR2 S/A                *      */
        /*"      * JAZZ    : 277280                                               *      */
        /*"      * DATA    : 09/02/2021                                           *      */
        /*"      * NOME    : DIOGO MATHEUS                                        *      */
        /*"      * MARCADOR: V.12                                                 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.11  * VERSAO  : 011                                                  *      */
        /*"      * MOTIVO  : ALTERAR DIGITO DO BANCO 099-X BANCO UNIPRIME CENTRAL *      */
        /*"      * JAZZ    : 268230                                               *      */
        /*"      * DATA    : 10/12/2020                                           *      */
        /*"      * NOME    : DIOGO MATHEUS                                        *      */
        /*"      * MARCADOR: V.11                                                 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.10  * VERSAO  : 010                                                  *      */
        /*"      * MOTIVO  : INCLUSAO DO BANCO 099-X BANCO UNIPRIME CENTRAL       *      */
        /*"      * JAZZ    : 268230                                               *      */
        /*"      * DATA    : 04/12/2020                                           *      */
        /*"      * NOME    : DIOGO MATHEUS                                        *      */
        /*"      * MARCADOR: V.10                                                 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.9   * VERSAO  : 009                                                  *      */
        /*"      * MOTIVO  : INCLUSAO DO BANCO 069-8 BANCO CREFISA S/A            *      */
        /*"      * JAZZ    : 268230                                               *      */
        /*"      * DATA    : 03/12/2020                                           *      */
        /*"      * NOME    : DIOGO MATHEUS                                        *      */
        /*"      * MARCADOR: V.9                                                  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.8   * VERSAO  : 008                                                  *      */
        /*"      * MOTIVO  : INCLUSAO DO BANCO 097                                *      */
        /*"      * JAZZ    : 266997                                               *      */
        /*"      * DATA    : 24/11/2020                                           *      */
        /*"      * NOME    : DIOGO MATHEUS                                        *      */
        /*"      * MARCADOR: V.8                                                  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.7   * VERSAO  : 007                                                  *      */
        /*"      * MOTIVO  : AJUSTE NOME DO BANCO 212                             *      */
        /*"      * JAZZ    : 253264                                               *      */
        /*"      * DATA    : 30/07/2020                                           *      */
        /*"      * NOME    : DIOGO MATHEUS                                        *      */
        /*"      * MARCADOR: V.7                                                  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO  : 006                                                  *      */
        /*"      * MOTIVO  : RETIRAR O BANCO BANESPA                              *      */
        /*"      * JAZZ    : 248856                                               *      */
        /*"      * DATA    : 22/06/2020                                           *      */
        /*"      * NOME    : DIOGO MATHEUS                                        *      */
        /*"      * MARCADOR: V.6                                                  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO  : 05                                                   *      */
        /*"      * MOTIVO  : INCLUSAO DO BANCO 197 OCORR�NCIA DE FALHA N�: 182862 *      */
        /*"      * JAZZ    :                                                      *      */
        /*"      * DATA    : 19/06/2020                                           *      */
        /*"      * NOME    : EVILASIO O. SILVA                                    *      */
        /*"      * MARCADOR: V.5                                                  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO  : 04                                                   *      */
        /*"      * MOTIVO  : INCLUSAO DO BANCO 260                                *      */
        /*"      * JAZZ    : 245050                                               *      */
        /*"      * DATA    : 18/05/2020                                           *      */
        /*"      * NOME    : DIOGO MATHEUS                                        *      */
        /*"      * MARCADOR: V.4                                                  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO  : 03                                                   *      */
        /*"      * MOTIVO  : INCLUSAO DO BANCO 330                                *      */
        /*"      * JAZZ    : 226736                                               *      */
        /*"      * DATA    : 13/12/2019                                           *      */
        /*"      * NOME    : DIOGO MATHEUS                                        *      */
        /*"      * MARCADOR: V.3                                                  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO  : 02                                                   *      */
        /*"      * MOTIVO  : INCLUSAO DOS BANCOS 077-9 E 133-3                    *      */
        /*"      * JAZZ    : 226386                                               *      */
        /*"      * DATA    : 09/12/2019                                           *      */
        /*"      * NOME    : DIOGO MATHEUS                                        *      */
        /*"      * MARCADOR: V.2                                                  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  ALTERACAO - AJUSTAR O DIGITO VERIFICADOR DO NUMERO DO BANCO   *      */
        /*"      *              SANTANDER DE 033-4 PARA 033-7                     *      */
        /*"      * 11-06-2014 - WELLINGTON VERAS (TE39902)    PROCURAR POR C99147 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   HISTORICO DE ALTERACAO                                       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        #endregion


        #region VARIABLES

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"01           AREA-DE-WORK.*/
        public GE0080B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new GE0080B_AREA_DE_WORK();
        public class GE0080B_AREA_DE_WORK : VarBasis
        {
            /*"  05         WSL-SQLCODE       PIC  9(009)    VALUE ZEROS.*/
            public IntBasis WSL_SQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05  IND                      PIC  9(003)    VALUE ZEROS.*/
            public IntBasis IND { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
            /*"01  AUX-BANCOS.*/
        }
        public GE0080B_AUX_BANCOS AUX_BANCOS { get; set; } = new GE0080B_AUX_BANCOS();
        public class GE0080B_AUX_BANCOS : VarBasis
        {
            /*"  05 TAB-BANCOS-FILLER.*/
            public GE0080B_TAB_BANCOS_FILLER TAB_BANCOS_FILLER { get; set; } = new GE0080B_TAB_BANCOS_FILLER();
            public class GE0080B_TAB_BANCOS_FILLER : VarBasis
            {
                /*"    10  FILLER         PIC X(51) VALUE        '001-9 BANCO DO BRASIL S.A.'.*/
                public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"001-9 BANCO DO BRASIL S.A.");
                /*"    10  FILLER         PIC X(51) VALUE        '002-7 BANCO CENTRAL DO BRASIL                      '.*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"002-7 BANCO CENTRAL DO BRASIL                      ");
                /*"    10  FILLER         PIC X(51) VALUE        '003-5 BANCO DA AMAZONIA S.A.                       '.*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"003-5 BANCO DA AMAZONIA S.A.                       ");
                /*"    10  FILLER         PIC X(51) VALUE        '004-3 BANCO DO NORDESTE DO BRASIL S.A.             '.*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"004-3 BANCO DO NORDESTE DO BRASIL S.A.             ");
                /*"    10  FILLER         PIC X(51) VALUE        '007-8 BANCO NACIONAL DESENV.ECONOMICO E SOCIAL     '.*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"007-8 BANCO NACIONAL DESENV.ECONOMICO E SOCIAL     ");
                /*"    10  FILLER         PIC X(51) VALUE        '008-6 BANCO SANTANDER MERIDIONAL S.A.              '.*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"008-6 BANCO SANTANDER MERIDIONAL S.A.              ");
                /*"    10  FILLER         PIC X(51) VALUE        '021-3 BANCO DO ESTADO DO ESPIRITO SANTO S.A.       '.*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"021-3 BANCO DO ESTADO DO ESPIRITO SANTO S.A.       ");
                /*"    10  FILLER         PIC X(51) VALUE        '023-0 BANCO DE DESEN. DE MINAS GERAIS S.A.         '.*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"023-0 BANCO DE DESEN. DE MINAS GERAIS S.A.         ");
                /*"    10  FILLER         PIC X(51) VALUE        '024-8 BANCO DO ESTADO DE PERNAMBUCO S.A.           '.*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"024-8 BANCO DO ESTADO DE PERNAMBUCO S.A.           ");
                /*"    10  FILLER         PIC X(51) VALUE        '025-1 BANCO ALFA S.A.                              '.*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"025-1 BANCO ALFA S.A.                              ");
                /*"    10  FILLER         PIC X(51) VALUE        '025-6 BANCO ALFA S.A.                              '.*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"025-6 BANCO ALFA S.A.                              ");
                /*"    10  FILLER         PIC X(51) VALUE        '027-2 BANCO DO ESTADO DE SANTA CATARINA S.A.       '.*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"027-2 BANCO DO ESTADO DE SANTA CATARINA S.A.       ");
                /*"    10  FILLER         PIC X(51) VALUE        '028-0 BANCO DO ESTADO DA BAHIA S.A.                '.*/
                public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"028-0 BANCO DO ESTADO DA BAHIA S.A.                ");
                /*"    10  FILLER         PIC X(51) VALUE        '029-9 BANCO BANERJ S.A.                            '.*/
                public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"029-9 BANCO BANERJ S.A.                            ");
                /*"    10  FILLER         PIC X(51) VALUE        '030-2 BANCO DO ESTADO DA PARAIBA S.A.              '.*/
                public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"030-2 BANCO DO ESTADO DA PARAIBA S.A.              ");
                /*"    10  FILLER         PIC X(51) VALUE        '031-0 BANCO DO ESTADO DE GOIAS S.A.                '.*/
                public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"031-0 BANCO DO ESTADO DE GOIAS S.A.                ");
                /*"    10  FILLER         PIC X(51) VALUE        '033-7 BANCO SANTANDER BRASIL S.A.                  '.*/
                public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"033-7 BANCO SANTANDER BRASIL S.A.                  ");
                /*"    10  FILLER         PIC X(51) VALUE        '034-5 BANCO DO ESTADO DO AMAZONAS S.A.             '.*/
                public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"034-5 BANCO DO ESTADO DO AMAZONAS S.A.             ");
                /*"    10  FILLER         PIC X(51) VALUE        '035-3 BANCO DO ESTADO DO CEARA S.A.                '.*/
                public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"035-3 BANCO DO ESTADO DO CEARA S.A.                ");
                /*"    10  FILLER         PIC X(51) VALUE        '036-1 BANCO DO ESTADO DO MARANHAO S.A.             '.*/
                public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"036-1 BANCO DO ESTADO DO MARANHAO S.A.             ");
                /*"    10  FILLER         PIC X(51) VALUE        '037-0 BANCO DO ESTADO DO PARA S.A.                 '.*/
                public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"037-0 BANCO DO ESTADO DO PARA S.A.                 ");
                /*"    10  FILLER         PIC X(51) VALUE        '038-8 BANCO DO ESTADO DO PARANA S.A.               '.*/
                public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"038-8 BANCO DO ESTADO DO PARANA S.A.               ");
                /*"    10  FILLER         PIC X(51) VALUE        '039-6 BANCO DO ESTADO DO PIAUI S.A.                '.*/
                public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"039-6 BANCO DO ESTADO DO PIAUI S.A.                ");
                /*"    10  FILLER         PIC X(51) VALUE        '041-8 BANCO DO ESTADO DO RIO GRANDE DO SUL S.A.    '.*/
                public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"041-8 BANCO DO ESTADO DO RIO GRANDE DO SUL S.A.    ");
                /*"    10  FILLER         PIC X(51) VALUE        '042-6 BANCO J. SAFRA S.A.                          '.*/
                public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"042-6 BANCO J. SAFRA S.A.                          ");
                /*"    10  FILLER         PIC X(51) VALUE        '044-2 BANCO BVA S.A.                               '.*/
                public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"044-2 BANCO BVA S.A.                               ");
                /*"    10  FILLER         PIC X(51) VALUE        '045-0 BANCO OPPORTUNITY S.A.                       '.*/
                public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"045-0 BANCO OPPORTUNITY S.A.                       ");
                /*"    10  FILLER         PIC X(51) VALUE        '046-9 BANCO REGIONAL DE DESEN.DO EXTREMO SUL       '.*/
                public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"046-9 BANCO REGIONAL DE DESEN.DO EXTREMO SUL       ");
                /*"    10  FILLER         PIC X(51) VALUE        '047-7 BANCO DO ESTADO DE SERGIPE S.A.              '.*/
                public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"047-7 BANCO DO ESTADO DE SERGIPE S.A.              ");
                /*"    10  FILLER         PIC X(51) VALUE        '048-5 BANCO BEMGE S.A.                             '.*/
                public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"048-5 BANCO BEMGE S.A.                             ");
                /*"    10  FILLER         PIC X(51) VALUE        '049-3 BANCO DE DESEN. DO ESTADO DA BAHIA S.A.      '.*/
                public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"049-3 BANCO DE DESEN. DO ESTADO DA BAHIA S.A.      ");
                /*"    10  FILLER         PIC X(51) VALUE        '051-5 BANCO DE DESEN. DO ESPIRITO SANTO S.A.       '.*/
                public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"051-5 BANCO DE DESEN. DO ESPIRITO SANTO S.A.       ");
                /*"    10  FILLER         PIC X(51) VALUE        '057-2 BANCO DE DESEN.DO EST.SANTA CATARINA S.A.    '.*/
                public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"057-2 BANCO DE DESEN.DO EST.SANTA CATARINA S.A.    ");
                /*"    10  FILLER         PIC X(51) VALUE        '063-9 BANCO IBI S.A.- BANCO MÿLTIPLO              '.*/
                public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"063-9 BANCO IBI S.A.- BANCO MÿLTIPLO              ");
                /*"    10  FILLER         PIC X(51) VALUE        '064-0 GOLDMAN SACHS DO BRASIL BANCO MÿLTIPLO AS   '.*/
                public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"064-0 GOLDMAN SACHS DO BRASIL BANCO MÿLTIPLO AS   ");
                /*"    10  FILLER         PIC X(51) VALUE        '069-8 BANCO CREFISA S.A.                           '.*/
                public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"069-8 BANCO CREFISA S.A.                           ");
                /*"    10  FILLER         PIC X(51) VALUE        '065-0 LEMON BANK BANCO MÿLTIPLO S.A.              '.*/
                public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"065-0 LEMON BANK BANCO MÿLTIPLO S.A.              ");
                /*"    10  FILLER         PIC X(51) VALUE        '070-1 BRB - BANCO DE BRASILIA S.A.                 '.*/
                public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"070-1 BRB - BANCO DE BRASILIA S.A.                 ");
                /*"    10  FILLER         PIC X(51) VALUE        '075-2 BANCO CR2 S/A                                '.*/
                public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"075-2 BANCO CR2 S/A                                ");
                /*"    10  FILLER         PIC X(51) VALUE        '077-9 BANCO INTER                                  '.*/
                public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"077-9 BANCO INTER                                  ");
                /*"    10  FILLER         PIC X(51) VALUE        '084-1 UNIPRIME NORTE DO PARANA                     '.*/
                public StringBasis FILLER_40 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"084-1 UNIPRIME NORTE DO PARANA                     ");
                /*"    10  FILLER         PIC X(51) VALUE        '085-0 COOP CENTRAL AILOS                           '.*/
                public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"085-0 COOP CENTRAL AILOS                           ");
                /*"    10  FILLER         PIC X(51) VALUE        '087-6 UNICRED CENTRAL SANTA CATARINA               '.*/
                public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"087-6 UNICRED CENTRAL SANTA CATARINA               ");
                /*"    10  FILLER         PIC X(51) VALUE        '097-3 COOP. CENTRAL DE CR�DITO NOROESTECOOP.       '.*/
                public StringBasis FILLER_43 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"097-3 COOP. CENTRAL DE CR�DITO NOROESTECOOP.       ");
                /*"    10  FILLER         PIC X(51) VALUE        '099-0 UNIPRIME CENTRAL - CENTRAL INT DE COOP CRED. '.*/
                public StringBasis FILLER_44 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"099-0 UNIPRIME CENTRAL - CENTRAL INT DE COOP CRED. ");
                /*"    10  FILLER         PIC X(51) VALUE        '104-0 CAIXA ECONOMICA FEDERAL                      '.*/
                public StringBasis FILLER_45 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"104-0 CAIXA ECONOMICA FEDERAL                      ");
                /*"    10  FILLER         PIC X(51) VALUE        '107-4 BANCO BBM S.A.                               '.*/
                public StringBasis FILLER_46 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"107-4 BANCO BBM S.A.                               ");
                /*"    10  FILLER         PIC X(51) VALUE        '109-0 BANCO CREDIBANCO S.A.                        '.*/
                public StringBasis FILLER_47 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"109-0 BANCO CREDIBANCO S.A.                        ");
                /*"    10  FILLER         PIC X(51) VALUE        '116-3 BANCO BNL DO BRASIL S.A.                     '.*/
                public StringBasis FILLER_48 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"116-3 BANCO BNL DO BRASIL S.A.                     ");
                /*"    10  FILLER         PIC X(51) VALUE        '121-0 BANCO AGIPLAN S/A                        '.*/
                public StringBasis FILLER_49 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"121-0 BANCO AGIPLAN S/A                        ");
                /*"    10  FILLER         PIC X(51) VALUE        '133-3 CRESOL CONFEDERACAO                          '.*/
                public StringBasis FILLER_50 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"133-3 CRESOL CONFEDERACAO                          ");
                /*"    10  FILLER         PIC X(51) VALUE        '136-0 UNICRED                                      '.*/
                public StringBasis FILLER_51 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"136-0 UNICRED                                      ");
                /*"    10  FILLER         PIC X(51) VALUE        '148-1 MULTI BANCO S.A.                             '.*/
                public StringBasis FILLER_52 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"148-1 MULTI BANCO S.A.                             ");
                /*"    10  FILLER         PIC X(51) VALUE        '151-1 NOSSA CAIXA-NOSSO BANCO S.A.                 '.*/
                public StringBasis FILLER_53 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"151-1 NOSSA CAIXA-NOSSO BANCO S.A.                 ");
                /*"    10  FILLER         PIC X(51) VALUE        '168-6 BANCO CCF BRASIL S.A.                        '.*/
                public StringBasis FILLER_54 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"168-6 BANCO CCF BRASIL S.A.                        ");
                /*"    10  FILLER         PIC X(51) VALUE        '175-9 CONTINENTAL BANCO S.A.                       '.*/
                public StringBasis FILLER_55 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"175-9 CONTINENTAL BANCO S.A.                       ");
                /*"    10  FILLER         PIC X(51) VALUE        '184-8 BANCO BBA-CREDITANSTALT S.A.                 '.*/
                public StringBasis FILLER_56 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"184-8 BANCO BBA-CREDITANSTALT S.A.                 ");
                /*"    10  FILLER         PIC X(51) VALUE        '197-8 STONE PAGAMENTOS S.A.                        '.*/
                public StringBasis FILLER_57 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"197-8 STONE PAGAMENTOS S.A.                        ");
                /*"    10  FILLER         PIC X(51) VALUE        '200-3 BANCO FICRISA AXELRUD S.A.                   '.*/
                public StringBasis FILLER_58 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"200-3 BANCO FICRISA AXELRUD S.A.                   ");
                /*"    10  FILLER         PIC X(51) VALUE        '201-1 BANCO AXIAL S.A.                             '.*/
                public StringBasis FILLER_59 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"201-1 BANCO AXIAL S.A.                             ");
                /*"    10  FILLER         PIC X(51) VALUE        '204-6 BANCO INTER AMERICAN EXPRESS S.A.            '.*/
                public StringBasis FILLER_60 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"204-6 BANCO INTER AMERICAN EXPRESS S.A.            ");
                /*"    10  FILLER         PIC X(51) VALUE        '205-4 BANCO SUL AMERICA S.A.                       '.*/
                public StringBasis FILLER_61 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"205-4 BANCO SUL AMERICA S.A.                       ");
                /*"    10  FILLER         PIC X(51) VALUE        '208-9 BANCO PACTUAL S.A.                           '.*/
                public StringBasis FILLER_62 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"208-9 BANCO PACTUAL S.A.                           ");
                /*"    10  FILLER         PIC X(51) VALUE        '210-0 DRESDNER BANK LATEINAMERIKA AG               '.*/
                public StringBasis FILLER_63 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"210-0 DRESDNER BANK LATEINAMERIKA AG               ");
                /*"    10  FILLER         PIC X(51) VALUE        '211-9 BANCO SISTEMA S.A.                           '.*/
                public StringBasis FILLER_64 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"211-9 BANCO SISTEMA S.A.                           ");
                /*"    10  FILLER         PIC X(51) VALUE        '212-7 BANCO ORIGINAL S.A                           '.*/
                public StringBasis FILLER_65 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"212-7 BANCO ORIGINAL S.A                           ");
                /*"    10  FILLER         PIC X(51) VALUE        '213-5 BANCO ARBI S.A.                              '.*/
                public StringBasis FILLER_66 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"213-5 BANCO ARBI S.A.                              ");
                /*"    10  FILLER         PIC X(51) VALUE        '214-3 BANCO DIBENS S.A.                            '.*/
                public StringBasis FILLER_67 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"214-3 BANCO DIBENS S.A.                            ");
                /*"    10  FILLER         PIC X(51) VALUE        '215-1 BANCO AMERICA DO SUL S.A.                    '.*/
                public StringBasis FILLER_68 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"215-1 BANCO AMERICA DO SUL S.A.                    ");
                /*"    10  FILLER         PIC X(51) VALUE        '216-0 BANCO REGIONAL MALCON S.A.COM.CRED.CONS.     '.*/
                public StringBasis FILLER_69 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"216-0 BANCO REGIONAL MALCON S.A.COM.CRED.CONS.     ");
                /*"    10  FILLER         PIC X(51) VALUE        '217-8 BANCO JOHN DEERE S.A.                        '.*/
                public StringBasis FILLER_70 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"217-8 BANCO JOHN DEERE S.A.                        ");
                /*"    10  FILLER         PIC X(51) VALUE        '218-6 BBS BANCO BONSUCESSO S.A.                    '.*/
                public StringBasis FILLER_71 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"218-6 BBS BANCO BONSUCESSO S.A.                    ");
                /*"    10  FILLER         PIC X(51) VALUE        '219-4 BANCO DE CREDITO DE SAO PAULO S.A.           '.*/
                public StringBasis FILLER_72 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"219-4 BANCO DE CREDITO DE SAO PAULO S.A.           ");
                /*"    10  FILLER         PIC X(51) VALUE        '221-6 BANCO FLEMING GRAPHUS S.A.                   '.*/
                public StringBasis FILLER_73 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"221-6 BANCO FLEMING GRAPHUS S.A.                   ");
                /*"    10  FILLER         PIC X(51) VALUE        '222-2 Protesto                                     '.*/
                public StringBasis FILLER_74 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"222-2 Protesto                                     ");
                /*"    10  FILLER         PIC X(51) VALUE        '222-4 BANCO CREDIT LYONNAIS BRASIL S.A.            '.*/
                public StringBasis FILLER_75 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"222-4 BANCO CREDIT LYONNAIS BRASIL S.A.            ");
                /*"    10  FILLER         PIC X(51) VALUE        '222-9 BANCO CALYON BRASIL S.A.                     '.*/
                public StringBasis FILLER_76 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"222-9 BANCO CALYON BRASIL S.A.                     ");
                /*"    10  FILLER         PIC X(51) VALUE        '224-0 BANCO FIBRA S.A.                             '.*/
                public StringBasis FILLER_77 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"224-0 BANCO FIBRA S.A.                             ");
                /*"    10  FILLER         PIC X(51) VALUE        '225-9 BANCO BRASCAN S.A.                           '.*/
                public StringBasis FILLER_78 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"225-9 BANCO BRASCAN S.A.                           ");
                /*"    10  FILLER         PIC X(51) VALUE        '228-3 BANCO ICATU S.A.                             '.*/
                public StringBasis FILLER_79 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"228-3 BANCO ICATU S.A.                             ");
                /*"    10  FILLER         PIC X(51) VALUE        '229-1 BANCO CRUZEIRO DO SUL S.A.                   '.*/
                public StringBasis FILLER_80 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"229-1 BANCO CRUZEIRO DO SUL S.A.                   ");
                /*"    10  FILLER         PIC X(51) VALUE        '230-5 BANCO BANDEIRANTES S.A.                      '.*/
                public StringBasis FILLER_81 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"230-5 BANCO BANDEIRANTES S.A.                      ");
                /*"    10  FILLER         PIC X(51) VALUE        '231-1 BANCO BOAVISTA INTERATLANTICO S.A.           '.*/
                public StringBasis FILLER_82 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"231-1 BANCO BOAVISTA INTERATLANTICO S.A.           ");
                /*"    10  FILLER         PIC X(51) VALUE        '232-1 BANCO INTERPART S.A.                         '.*/
                public StringBasis FILLER_83 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"232-1 BANCO INTERPART S.A.                         ");
                /*"    10  FILLER         PIC X(51) VALUE        '233-0 BANCO GE CAPITAL S.A.                        '.*/
                public StringBasis FILLER_84 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"233-0 BANCO GE CAPITAL S.A.                        ");
                /*"    10  FILLER         PIC X(51) VALUE        '234-8 BANCO LAVRA S.A.                             '.*/
                public StringBasis FILLER_85 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"234-8 BANCO LAVRA S.A.                             ");
                /*"    10  FILLER         PIC X(51) VALUE        '235-6 BANCO LIBERAL S.A.                           '.*/
                public StringBasis FILLER_86 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"235-6 BANCO LIBERAL S.A.                           ");
                /*"    10  FILLER         PIC X(51) VALUE        '237-2 BANCO BRADESCO S.A.                          '.*/
                public StringBasis FILLER_87 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"237-2 BANCO BRADESCO S.A.                          ");
                /*"    10  FILLER         PIC X(51) VALUE        '241-0 BANCO CLASSICO S.A.                          '.*/
                public StringBasis FILLER_88 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"241-0 BANCO CLASSICO S.A.                          ");
                /*"    10  FILLER         PIC X(51) VALUE        '242-9 BANCO EUROINVEST S.A. EUROBANCO              '.*/
                public StringBasis FILLER_89 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"242-9 BANCO EUROINVEST S.A. EUROBANCO              ");
                /*"    10  FILLER         PIC X(51) VALUE        '243-7 BANCO MULTISTOCK S.A.                        '.*/
                public StringBasis FILLER_90 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"243-7 BANCO MULTISTOCK S.A.                        ");
                /*"    10  FILLER         PIC X(51) VALUE        '244-5 BANCO CIDADE S.A.                            '.*/
                public StringBasis FILLER_91 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"244-5 BANCO CIDADE S.A.                            ");
                /*"    10  FILLER         PIC X(51) VALUE        '246-1 BANCO ABC-BRASIL S.A.                        '.*/
                public StringBasis FILLER_92 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"246-1 BANCO ABC-BRASIL S.A.                        ");
                /*"    10  FILLER         PIC X(51) VALUE        '247-0 BANCO UBS S.A.                               '.*/
                public StringBasis FILLER_93 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"247-0 BANCO UBS S.A.                               ");
                /*"    10  FILLER         PIC X(51) VALUE        '249-6 BANCO INVESTCRED UNIBANCO S.A.               '.*/
                public StringBasis FILLER_94 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"249-6 BANCO INVESTCRED UNIBANCO S.A.               ");
                /*"    10  FILLER         PIC X(51) VALUE        '250-6 BANCO SCHAHIN S.A.                           '.*/
                public StringBasis FILLER_95 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"250-6 BANCO SCHAHIN S.A.                           ");
                /*"    10  FILLER         PIC X(51) VALUE        '252-6 BANCO FININVEST S.A.                         '.*/
                public StringBasis FILLER_96 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"252-6 BANCO FININVEST S.A.                         ");
                /*"    10  FILLER         PIC X(51) VALUE        '254-2 PARANA BANCO S.A.                            '.*/
                public StringBasis FILLER_97 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"254-2 PARANA BANCO S.A.                            ");
                /*"    10  FILLER         PIC X(51) VALUE        '258-5 BANCO INDUSCRED S.A.                         '.*/
                public StringBasis FILLER_98 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"258-5 BANCO INDUSCRED S.A.                         ");
                /*"    10  FILLER         PIC X(51) VALUE        '260-1 NUBANK BANCO DIGITAL S.A                     '.*/
                public StringBasis FILLER_99 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"260-1 NUBANK BANCO DIGITAL S.A                     ");
                /*"    10  FILLER         PIC X(51) VALUE        '262-3 BANCO BOREAL S.A.                            '.*/
                public StringBasis FILLER_100 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"262-3 BANCO BOREAL S.A.                            ");
                /*"    10  FILLER         PIC X(51) VALUE        '263-1 BANCO CACIQUE S.A.                           '.*/
                public StringBasis FILLER_101 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"263-1 BANCO CACIQUE S.A.                           ");
                /*"    10  FILLER         PIC X(51) VALUE        '265-8 BANCO FATOR S.A.                             '.*/
                public StringBasis FILLER_102 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"265-8 BANCO FATOR S.A.                             ");
                /*"    10  FILLER         PIC X(51) VALUE        '266-6 BANCO CEDULA S.A.                            '.*/
                public StringBasis FILLER_103 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"266-6 BANCO CEDULA S.A.                            ");
                /*"    10  FILLER         PIC X(51) VALUE        '277-1 BANCO PLANIBANC S.A.                         '.*/
                public StringBasis FILLER_104 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"277-1 BANCO PLANIBANC S.A.                         ");
                /*"    10  FILLER         PIC X(51) VALUE        '290-0 BANCO PAGSEGURO LTDA.                        '.*/
                public StringBasis FILLER_105 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"290-0 BANCO PAGSEGURO LTDA.                        ");
                /*"    10  FILLER         PIC X(51) VALUE        '291-7 BANCO DE CREDITO NACIONAL S.A.               '.*/
                public StringBasis FILLER_106 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"291-7 BANCO DE CREDITO NACIONAL S.A.               ");
                /*"    10  FILLER         PIC X(51) VALUE        '300-0 BANCO DE LA NACION ARGENTINA                 '.*/
                public StringBasis FILLER_107 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"300-0 BANCO DE LA NACION ARGENTINA                 ");
                /*"    10  FILLER         PIC X(51) VALUE        '318-2 BANCO BMG S.A.                               '.*/
                public StringBasis FILLER_108 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"318-2 BANCO BMG S.A.                               ");
                /*"    10  FILLER         PIC X(51) VALUE        '320-4 BANCO INDUSTRIAL E COMERCIAL S.A.            '.*/
                public StringBasis FILLER_109 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"320-4 BANCO INDUSTRIAL E COMERCIAL S.A.            ");
                /*"    10  FILLER         PIC X(51) VALUE        '323-9 MERCADOPAGO.COM REPRESENTACOES LTDA.         '.*/
                public StringBasis FILLER_110 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"323-9 MERCADOPAGO.COM REPRESENTACOES LTDA.         ");
                /*"    10  FILLER         PIC X(51) VALUE        '330-5 BARIGUI S/A CREDITO FINANCIAMENTO E INVEST   '.*/
                public StringBasis FILLER_111 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"330-5 BARIGUI S/A CREDITO FINANCIAMENTO E INVEST   ");
                /*"    10  FILLER         PIC X(51) VALUE        '336-0 C6 BANK.                                     '.*/
                public StringBasis FILLER_112 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"336-0 C6 BANK.                                     ");
                /*"    10  FILLER         PIC X(51) VALUE        '341-7 BANCO ITAU S.A.                              '.*/
                public StringBasis FILLER_113 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"341-7 BANCO ITAU S.A.                              ");
                /*"    10  FILLER         PIC X(51) VALUE        '346-8 BANCO FRANCES E BRASILEIRO S.A.              '.*/
                public StringBasis FILLER_114 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"346-8 BANCO FRANCES E BRASILEIRO S.A.              ");
                /*"    10  FILLER         PIC X(51) VALUE        '347-6 BANCO SUDAMERIS BRASIL S.A.                  '.*/
                public StringBasis FILLER_115 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"347-6 BANCO SUDAMERIS BRASIL S.A.                  ");
                /*"    10  FILLER         PIC X(51) VALUE        '351-4 BANCO BOZANO SIMONSEN S.A.                   '.*/
                public StringBasis FILLER_116 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"351-4 BANCO BOZANO SIMONSEN S.A.                   ");
                /*"    10  FILLER         PIC X(51) VALUE        '353-0 BANCO SANTANDER BRASIL S.A.                  '.*/
                public StringBasis FILLER_117 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"353-0 BANCO SANTANDER BRASIL S.A.                  ");
                /*"    10  FILLER         PIC X(51) VALUE        '356-5 BANCO ABN AMRO REAL S.A.                     '.*/
                public StringBasis FILLER_118 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"356-5 BANCO ABN AMRO REAL S.A.                     ");
                /*"    10  FILLER         PIC X(51) VALUE        '366-2 BANCO SOCIETE GENERALE BRASIL S.A.           '.*/
                public StringBasis FILLER_119 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"366-2 BANCO SOCIETE GENERALE BRASIL S.A.           ");
                /*"    10  FILLER         PIC X(51) VALUE        '370-0 BANCO EUROPEU P/ AMERICA LATINA (BEAL) SA    '.*/
                public StringBasis FILLER_120 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"370-0 BANCO EUROPEU P/ AMERICA LATINA (BEAL) SA    ");
                /*"    10  FILLER         PIC X(51) VALUE        '375-1 BANCO FENICIA S.A.                           '.*/
                public StringBasis FILLER_121 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"375-1 BANCO FENICIA S.A.                           ");
                /*"    10  FILLER         PIC X(51) VALUE        '376-0 BANCO CHASE MANHATTAN S.A.                   '.*/
                public StringBasis FILLER_122 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"376-0 BANCO CHASE MANHATTAN S.A.                   ");
                /*"    10  FILLER         PIC X(51) VALUE        '380-0 PICPAY SERVICOS S.A                          '.*/
                public StringBasis FILLER_123 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"380-0 PICPAY SERVICOS S.A                          ");
                /*"    10  FILLER         PIC X(51) VALUE        '389-1 BANCO MERCANTIL DO BRASIL S.A.               '.*/
                public StringBasis FILLER_124 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"389-1 BANCO MERCANTIL DO BRASIL S.A.               ");
                /*"    10  FILLER         PIC X(51) VALUE        '392-1 BANCO MERCANTIL FINASA S.A.                  '.*/
                public StringBasis FILLER_125 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"392-1 BANCO MERCANTIL FINASA S.A.                  ");
                /*"    10  FILLER         PIC X(51) VALUE        '394-8 BANCO BMC S.A.                               '.*/
                public StringBasis FILLER_126 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"394-8 BANCO BMC S.A.                               ");
                /*"    10  FILLER         PIC X(51) VALUE        '399-9 HSBC BANK BRASIL S.A. BANCO MULTIPLO         '.*/
                public StringBasis FILLER_127 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"399-9 HSBC BANK BRASIL S.A. BANCO MULTIPLO         ");
                /*"    10  FILLER         PIC X(51) VALUE        '403-0 CORA SOCIEDADE DE CREDITO DIRETO S/A         '.*/
                public StringBasis FILLER_128 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"403-0 CORA SOCIEDADE DE CREDITO DIRETO S/A         ");
                /*"    10  FILLER         PIC X(51) VALUE        '409-0 UNIBANCO UNIAO DE BANCOS BRASILEIROS SA      '.*/
                public StringBasis FILLER_129 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"409-0 UNIBANCO UNIAO DE BANCOS BRASILEIROS SA      ");
                /*"    10  FILLER         PIC X(51) VALUE        '412-0 BANCO CAPITAL S.A.                           '.*/
                public StringBasis FILLER_130 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"412-0 BANCO CAPITAL S.A.                           ");
                /*"    10  FILLER         PIC X(51) VALUE        '422-7 BANCO SAFRA S.A.                             '.*/
                public StringBasis FILLER_131 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"422-7 BANCO SAFRA S.A.                             ");
                /*"    10  FILLER         PIC X(51) VALUE        '424-3 BANCO SANTANDER NOROESTE S.A.                '.*/
                public StringBasis FILLER_132 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"424-3 BANCO SANTANDER NOROESTE S.A.                ");
                /*"    10  FILLER         PIC X(51) VALUE        '444-4 Jur�dico                                     '.*/
                public StringBasis FILLER_133 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"444-4 Jur�dico                                     ");
                /*"    10  FILLER         PIC X(51) VALUE        '453-7 BANCO RURAL S.A.                             '.*/
                public StringBasis FILLER_134 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"453-7 BANCO RURAL S.A.                             ");
                /*"    10  FILLER         PIC X(51) VALUE        '456-1 BANCO DE TOKYO-MITSUBISHI BRASIL S.A.        '.*/
                public StringBasis FILLER_135 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"456-1 BANCO DE TOKYO-MITSUBISHI BRASIL S.A.        ");
                /*"    10  FILLER         PIC X(51) VALUE        '464-2 BANCO SUMITOMO MITSUI BRASILEIRO S.A.        '.*/
                public StringBasis FILLER_136 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"464-2 BANCO SUMITOMO MITSUI BRASILEIRO S.A.        ");
                /*"    10  FILLER         PIC X(51) VALUE        '472-3 LLOYDS BANK PLC                              '.*/
                public StringBasis FILLER_137 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"472-3 LLOYDS BANK PLC                              ");
                /*"    10  FILLER         PIC X(51) VALUE        '479-0 BANKBOSTON BANCO MULTIPLO S.A.               '.*/
                public StringBasis FILLER_138 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"479-0 BANKBOSTON BANCO MULTIPLO S.A.               ");
                /*"    10  FILLER         PIC X(51) VALUE        '480-4 BANCO WACHOVIA S.A.                          '.*/
                public StringBasis FILLER_139 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"480-4 BANCO WACHOVIA S.A.                          ");
                /*"    10  FILLER         PIC X(51) VALUE        '487-1 DEUTSCHE BANK S.A. - BANCO ALEMAO            '.*/
                public StringBasis FILLER_140 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"487-1 DEUTSCHE BANK S.A. - BANCO ALEMAO            ");
                /*"    10  FILLER         PIC X(51) VALUE        '487-2 DEUTSCHE BANK S.A. - BANCO ALEMAO            '.*/
                public StringBasis FILLER_141 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"487-2 DEUTSCHE BANK S.A. - BANCO ALEMAO            ");
                /*"    10  FILLER         PIC X(51) VALUE        '488-0 BANCO J.P.MORGAN S.A.                        '.*/
                public StringBasis FILLER_142 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"488-0 BANCO J.P.MORGAN S.A.                        ");
                /*"    10  FILLER         PIC X(51) VALUE        '489-6 BANCO FRANCES INTERNACIONAL (BRASIL) S.A.    '.*/
                public StringBasis FILLER_143 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"489-6 BANCO FRANCES INTERNACIONAL (BRASIL) S.A.    ");
                /*"    10  FILLER         PIC X(51) VALUE        '492-8 ING BANK N.V.                                '.*/
                public StringBasis FILLER_144 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"492-8 ING BANK N.V.                                ");
                /*"    10  FILLER         PIC X(51) VALUE        '493-6 BANCO UNION S.A.C.A.                         '.*/
                public StringBasis FILLER_145 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"493-6 BANCO UNION S.A.C.A.                         ");
                /*"    10  FILLER         PIC X(51) VALUE        '494-4 BANCO DE LA REPUB. ORIENTAL DEL URUGUAY      '.*/
                public StringBasis FILLER_146 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"494-4 BANCO DE LA REPUB. ORIENTAL DEL URUGUAY      ");
                /*"    10  FILLER         PIC X(51) VALUE        '495-2 BANCO DE LA PROVINCIA DE BUENOS AIRES        '.*/
                public StringBasis FILLER_147 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"495-2 BANCO DE LA PROVINCIA DE BUENOS AIRES        ");
                /*"    10  FILLER         PIC X(51) VALUE        '496-0 BANCO EXTERIOR DE ESPANA S.A.                '.*/
                public StringBasis FILLER_148 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"496-0 BANCO EXTERIOR DE ESPANA S.A.                ");
                /*"    10  FILLER         PIC X(51) VALUE        '498-7 CENTRO HISPANO BANCO                         '.*/
                public StringBasis FILLER_149 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"498-7 CENTRO HISPANO BANCO                         ");
                /*"    10  FILLER         PIC X(51) VALUE        '501-0 BANCO BRASILEIRO IRAQUIANO S.A.              '.*/
                public StringBasis FILLER_150 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"501-0 BANCO BRASILEIRO IRAQUIANO S.A.              ");
                /*"    10  FILLER         PIC X(51) VALUE        '502-9 BANCO DE SANTANDER DE NEGOCIOS S.A.          '.*/
                public StringBasis FILLER_151 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"502-9 BANCO DE SANTANDER DE NEGOCIOS S.A.          ");
                /*"    10  FILLER         PIC X(51) VALUE        '505-3 BANCO CREDIT SUISSE FIRST BOSTON S.A.        '.*/
                public StringBasis FILLER_152 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"505-3 BANCO CREDIT SUISSE FIRST BOSTON S.A.        ");
                /*"    10  FILLER         PIC X(51) VALUE        '600-9 BANCO LUSO BRASILEIRO S.A.                   '.*/
                public StringBasis FILLER_153 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"600-9 BANCO LUSO BRASILEIRO S.A.                   ");
                /*"    10  FILLER         PIC X(51) VALUE        '602-5 BANCO PATENTE S.A.                           '.*/
                public StringBasis FILLER_154 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"602-5 BANCO PATENTE S.A.                           ");
                /*"    10  FILLER         PIC X(51) VALUE        '604-1 BANCO INDUSTRIAL DO BRASIL S.A.              '.*/
                public StringBasis FILLER_155 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"604-1 BANCO INDUSTRIAL DO BRASIL S.A.              ");
                /*"    10  FILLER         PIC X(51) VALUE        '607-6 BANCO SANTOS NEVES S.A.                      '.*/
                public StringBasis FILLER_156 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"607-6 BANCO SANTOS NEVES S.A.                      ");
                /*"    10  FILLER         PIC X(51) VALUE        '610-6 BANCO VR S.A.                                '.*/
                public StringBasis FILLER_157 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"610-6 BANCO VR S.A.                                ");
                /*"    10  FILLER         PIC X(51) VALUE        '611-4 BANCO PAULISTA S.A.                          '.*/
                public StringBasis FILLER_158 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"611-4 BANCO PAULISTA S.A.                          ");
                /*"    10  FILLER         PIC X(51) VALUE        '612-2 BANCO GUANABARA S.A.                         '.*/
                public StringBasis FILLER_159 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"612-2 BANCO GUANABARA S.A.                         ");
                /*"    10  FILLER         PIC X(51) VALUE        '613-0 BANCO PECUNIA S.A.                           '.*/
                public StringBasis FILLER_160 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"613-0 BANCO PECUNIA S.A.                           ");
                /*"    10  FILLER         PIC X(51) VALUE        '618-1 BANCO TENDENCIA S.A.                         '.*/
                public StringBasis FILLER_161 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"618-1 BANCO TENDENCIA S.A.                         ");
                /*"    10  FILLER         PIC X(51) VALUE        '623-8 BANCO PANAMERICANO S.A.                      '.*/
                public StringBasis FILLER_162 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"623-8 BANCO PANAMERICANO S.A.                      ");
                /*"    10  FILLER         PIC X(51) VALUE        '624-7 BANCO GENERAL MOTORS S.A.                    '.*/
                public StringBasis FILLER_163 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"624-7 BANCO GENERAL MOTORS S.A.                    ");
                /*"    10  FILLER         PIC X(51) VALUE        '625-4 BANCO ARAUCARIA S.A.                         '.*/
                public StringBasis FILLER_164 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"625-4 BANCO ARAUCARIA S.A.                         ");
                /*"    10  FILLER         PIC X(51) VALUE        '626-2 BANCO FICSA S.A.                             '.*/
                public StringBasis FILLER_165 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"626-2 BANCO FICSA S.A.                             ");
                /*"    10  FILLER         PIC X(51) VALUE        '627-0 BANCO DESTAK S.A.                            '.*/
                public StringBasis FILLER_166 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"627-0 BANCO DESTAK S.A.                            ");
                /*"    10  FILLER         PIC X(51) VALUE        '630-0 BANCO INTERCAP S.A.                          '.*/
                public StringBasis FILLER_167 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"630-0 BANCO INTERCAP S.A.                          ");
                /*"    10  FILLER         PIC X(51) VALUE        '633-5 BANCO RENDIMENTO S.A.                        '.*/
                public StringBasis FILLER_168 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"633-5 BANCO RENDIMENTO S.A.                        ");
                /*"    10  FILLER         PIC X(51) VALUE        '634-3 BANCO TRIANGULO S.A.                         '.*/
                public StringBasis FILLER_169 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"634-3 BANCO TRIANGULO S.A.                         ");
                /*"    10  FILLER         PIC X(51) VALUE        '637-8 BANCO SOFISA S.A.                            '.*/
                public StringBasis FILLER_170 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"637-8 BANCO SOFISA S.A.                            ");
                /*"    10  FILLER         PIC X(51) VALUE        '638-6 BANCO PROSPER S.A.                           '.*/
                public StringBasis FILLER_171 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"638-6 BANCO PROSPER S.A.                           ");
                /*"    10  FILLER         PIC X(51) VALUE        '641-6 BANCO BILBAO VIZCAYA BRASIL S.A.             '.*/
                public StringBasis FILLER_172 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"641-6 BANCO BILBAO VIZCAYA BRASIL S.A.             ");
                /*"    10  FILLER         PIC X(51) VALUE        '643-2 BANCO PINE S.A.                              '.*/
                public StringBasis FILLER_173 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"643-2 BANCO PINE S.A.                              ");
                /*"    10  FILLER         PIC X(51) VALUE        '650-5 BANCO PEBB S.A.                              '.*/
                public StringBasis FILLER_174 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"650-5 BANCO PEBB S.A.                              ");
                /*"    10  FILLER         PIC X(51) VALUE        '653-0 BANCO INDUSVAL S.A.                          '.*/
                public StringBasis FILLER_175 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"653-0 BANCO INDUSVAL S.A.                          ");
                /*"    10  FILLER         PIC X(51) VALUE        '654-8 BANCO A.J. RENNER S.A.                       '.*/
                public StringBasis FILLER_176 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"654-8 BANCO A.J. RENNER S.A.                       ");
                /*"    10  FILLER         PIC X(51) VALUE        '655-6 BANCO VOTORANTIM S.A.                        '.*/
                public StringBasis FILLER_177 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"655-6 BANCO VOTORANTIM S.A.                        ");
                /*"    10  FILLER         PIC X(51) VALUE        '656-4 BANCO MATRIX S.A.                            '.*/
                public StringBasis FILLER_178 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"656-4 BANCO MATRIX S.A.                            ");
                /*"    10  FILLER         PIC X(51) VALUE        '657-2 BANCO TECNICORP S.A.                         '.*/
                public StringBasis FILLER_179 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"657-2 BANCO TECNICORP S.A.                         ");
                /*"    10  FILLER         PIC X(51) VALUE        '658-0 BANCO PORTO REAL S.A.                        '.*/
                public StringBasis FILLER_180 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"658-0 BANCO PORTO REAL S.A.                        ");
                /*"    10  FILLER         PIC X(51) VALUE        '702-1 BANCO SANTOS  S.A.                           '.*/
                public StringBasis FILLER_181 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"702-1 BANCO SANTOS  S.A.                           ");
                /*"    10  FILLER         PIC X(51) VALUE        '707-2 BANCO DAYCOVAL S.A.                          '.*/
                public StringBasis FILLER_182 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"707-2 BANCO DAYCOVAL S.A.                          ");
                /*"    10  FILLER         PIC X(51) VALUE        '719-6 BANIF BANCO INTERNAC.  DO FUNCHAL BRASIL S.A.'.*/
                public StringBasis FILLER_183 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"719-6 BANIF BANCO INTERNAC.  DO FUNCHAL BRASIL S.A.");
                /*"    10  FILLER         PIC X(51) VALUE        '720-0 BANCO MAXINVEST S.A.                         '.*/
                public StringBasis FILLER_184 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"720-0 BANCO MAXINVEST S.A.                         ");
                /*"    10  FILLER         PIC X(51) VALUE        '721-8 BANCO CREDIBEL S.A.                          '.*/
                public StringBasis FILLER_185 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"721-8 BANCO CREDIBEL S.A.                          ");
                /*"    10  FILLER         PIC X(51) VALUE        '722-6 BANCO INTERIOR DE SAO PAULO S.A.             '.*/
                public StringBasis FILLER_186 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"722-6 BANCO INTERIOR DE SAO PAULO S.A.             ");
                /*"    10  FILLER         PIC X(51) VALUE        '725-0 BANCO FINANSINOS S.A.                        '.*/
                public StringBasis FILLER_187 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"725-0 BANCO FINANSINOS S.A.                        ");
                /*"    10  FILLER         PIC X(51) VALUE        '732-3 BANCO MINAS S.A.                             '.*/
                public StringBasis FILLER_188 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"732-3 BANCO MINAS S.A.                             ");
                /*"    10  FILLER         PIC X(51) VALUE        '733-1 BANCO DAS NACOES S.A.                        '.*/
                public StringBasis FILLER_189 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"733-1 BANCO DAS NACOES S.A.                        ");
                /*"    10  FILLER         PIC X(51) VALUE        '734-0 BANCO GERDAU S.A.                            '.*/
                public StringBasis FILLER_190 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"734-0 BANCO GERDAU S.A.                            ");
                /*"    10  FILLER         PIC X(51) VALUE        '735-8 BANCO POTTENCIAL S.A.                        '.*/
                public StringBasis FILLER_191 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"735-8 BANCO POTTENCIAL S.A.                        ");
                /*"    10  FILLER         PIC X(51) VALUE        '737-4 BANCO THECA S.A.                             '.*/
                public StringBasis FILLER_192 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"737-4 BANCO THECA S.A.                             ");
                /*"    10  FILLER         PIC X(51) VALUE        '738-2 BANCO MORADA S.A.                            '.*/
                public StringBasis FILLER_193 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"738-2 BANCO MORADA S.A.                            ");
                /*"    10  FILLER         PIC X(51) VALUE        '739-0 BANCO BGN S.A.                               '.*/
                public StringBasis FILLER_194 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"739-0 BANCO BGN S.A.                               ");
                /*"    10  FILLER         PIC X(51) VALUE        '740-4 BANCO BARCLAYS S.A.                          '.*/
                public StringBasis FILLER_195 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"740-4 BANCO BARCLAYS S.A.                          ");
                /*"    10  FILLER         PIC X(51) VALUE        '741-2 BRP - BANCO RIBEIRAO PRETO S.A.              '.*/
                public StringBasis FILLER_196 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"741-2 BRP - BANCO RIBEIRAO PRETO S.A.              ");
                /*"    10  FILLER         PIC X(51) VALUE        '742-0 BANCO EQUATORIAL S.A.                        '.*/
                public StringBasis FILLER_197 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"742-0 BANCO EQUATORIAL S.A.                        ");
                /*"    10  FILLER         PIC X(51) VALUE        '743-9 BANCO EMBLEMA S.A.                           '.*/
                public StringBasis FILLER_198 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"743-9 BANCO EMBLEMA S.A.                           ");
                /*"    10  FILLER         PIC X(51) VALUE        '745-5 BANCO CITIBANK S.A.                          '.*/
                public StringBasis FILLER_199 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"745-5 BANCO CITIBANK S.A.                          ");
                /*"    10  FILLER         PIC X(51) VALUE        '746-3 BANCO MODAL S.A.                             '.*/
                public StringBasis FILLER_200 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"746-3 BANCO MODAL S.A.                             ");
                /*"    10  FILLER         PIC X(51) VALUE        '747-1 BANCO RAIBOBANK INTERNACIONAL BRASIL S.A.    '.*/
                public StringBasis FILLER_201 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"747-1 BANCO RAIBOBANK INTERNACIONAL BRASIL S.A.    ");
                /*"    10  FILLER         PIC X(51) VALUE        '748-0 BANCO COOPERATIVO SICREDI S.A.               '.*/
                public StringBasis FILLER_202 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"748-0 BANCO COOPERATIVO SICREDI S.A.               ");
                /*"    10  FILLER         PIC X(51) VALUE        '749-8 BANCO SIMPLES S.A.                           '.*/
                public StringBasis FILLER_203 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"749-8 BANCO SIMPLES S.A.                           ");
                /*"    10  FILLER         PIC X(51) VALUE        '750-1 BANCO REPUBLIC NATIONAL BANK NY BRASIL SA    '.*/
                public StringBasis FILLER_204 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"750-1 BANCO REPUBLIC NATIONAL BANK NY BRASIL SA    ");
                /*"    10  FILLER         PIC X(51) VALUE        '751-0 DRESDNER BANK BRASIL S.A. BANCO MULTIPLO     '.*/
                public StringBasis FILLER_205 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"751-0 DRESDNER BANK BRASIL S.A. BANCO MULTIPLO     ");
                /*"    10  FILLER         PIC X(51) VALUE        '752-8 BANCO BNP PARIBAS BRASIL S.A.                '.*/
                public StringBasis FILLER_206 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"752-8 BANCO BNP PARIBAS BRASIL S.A.                ");
                /*"    10  FILLER         PIC X(51) VALUE        '753-6 BANCO COMERCIAL URUGUAI S.A.                 '.*/
                public StringBasis FILLER_207 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"753-6 BANCO COMERCIAL URUGUAI S.A.                 ");
                /*"    10  FILLER         PIC X(51) VALUE        '755-2 BANCO MERRILL LYNCH S.A.                     '.*/
                public StringBasis FILLER_208 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"755-2 BANCO MERRILL LYNCH S.A.                     ");
                /*"    10  FILLER         PIC X(51) VALUE        '756-0 BANCO COOPERATIVO DO BRASIL S.A.             '.*/
                public StringBasis FILLER_209 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"756-0 BANCO COOPERATIVO DO BRASIL S.A.             ");
                /*"    10  FILLER         PIC X(51) VALUE        '757-9 BANCO KEB DO BRASIL S.A.                     '.*/
                public StringBasis FILLER_210 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"757-9 BANCO KEB DO BRASIL S.A.                     ");
                /*"    10  FILLER         PIC X(51) VALUE        '915-6 BANCO BRJ S.A.                               '.*/
                public StringBasis FILLER_211 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"915-6 BANCO BRJ S.A.                               ");
                /*"    10  FILLER         PIC X(51) VALUE        '920-2 BANCO BVA S.A.                               '.*/
                public StringBasis FILLER_212 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"920-2 BANCO BVA S.A.                               ");
                /*"    10  FILLER         PIC X(51) VALUE        '930-0 BANCO CARGILL S.A.                           '.*/
                public StringBasis FILLER_213 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"930-0 BANCO CARGILL S.A.                           ");
                /*"    10  FILLER         PIC X(51) VALUE        '932-0 BANCO CNH CAPITAL S.A.                       '.*/
                public StringBasis FILLER_214 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"932-0 BANCO CNH CAPITAL S.A.                       ");
                /*"    10  FILLER         PIC X(51) VALUE        '935-0 BANCO DAIMLER-CHRYSLER S.A.                  '.*/
                public StringBasis FILLER_215 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"935-0 BANCO DAIMLER-CHRYSLER S.A.                  ");
                /*"    10  FILLER         PIC X(51) VALUE        '940-7 BANCO FIAT S.A.                              '.*/
                public StringBasis FILLER_216 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"940-7 BANCO FIAT S.A.                              ");
                /*"    10  FILLER         PIC X(51) VALUE        '942-3 BANCO FORD S.A.                              '.*/
                public StringBasis FILLER_217 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"942-3 BANCO FORD S.A.                              ");
                /*"    10  FILLER         PIC X(51) VALUE        '945-8 BANCO HEXABANCO S.A.                         '.*/
                public StringBasis FILLER_218 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"945-8 BANCO HEXABANCO S.A.                         ");
                /*"    10  FILLER         PIC X(51) VALUE        '950-0 BANCO HONDA S.A.                             '.*/
                public StringBasis FILLER_219 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"950-0 BANCO HONDA S.A.                             ");
                /*"    10  FILLER         PIC X(51) VALUE        '957-0 BANCO MONEO S.A.                             '.*/
                public StringBasis FILLER_220 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"957-0 BANCO MONEO S.A.                             ");
                /*"    10  FILLER         PIC X(51) VALUE        '960-0 BANCO MORGAN STANLEY DEAN WITTER S.A.        '.*/
                public StringBasis FILLER_221 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"960-0 BANCO MORGAN STANLEY DEAN WITTER S.A.        ");
                /*"    10  FILLER         PIC X(51) VALUE        '970-9 BANCO OPPORTUNITY S.A.                       '.*/
                public StringBasis FILLER_222 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"970-9 BANCO OPPORTUNITY S.A.                       ");
                /*"    10  FILLER         PIC X(51) VALUE        '972-1 BANCO OURINVEST S.A.                         '.*/
                public StringBasis FILLER_223 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"972-1 BANCO OURINVEST S.A.                         ");
                /*"    10  FILLER         PIC X(51) VALUE        '976-8 BANCO PERFORMANCE S.A.                       '.*/
                public StringBasis FILLER_224 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"976-8 BANCO PERFORMANCE S.A.                       ");
                /*"    10  FILLER         PIC X(51) VALUE        '978-0 BANCO PSA FINANCE BRASIL S.A.                '.*/
                public StringBasis FILLER_225 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"978-0 BANCO PSA FINANCE BRASIL S.A.                ");
                /*"    10  FILLER         PIC X(51) VALUE        '980-6 BANCO RODOBENS S.A.                          '.*/
                public StringBasis FILLER_226 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"980-6 BANCO RODOBENS S.A.                          ");
                /*"    10  FILLER         PIC X(51) VALUE        '985-8 BANCO TOYOTA DO BRASIL S.A.                  '.*/
                public StringBasis FILLER_227 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"985-8 BANCO TOYOTA DO BRASIL S.A.                  ");
                /*"    10  FILLER         PIC X(51) VALUE        '992-0 BANCO TRICURY S.A.                           '.*/
                public StringBasis FILLER_228 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"992-0 BANCO TRICURY S.A.                           ");
                /*"    10  FILLER         PIC X(51) VALUE        '996-9 OPERA��ES MERCADO EXTERNO                    '.*/
                public StringBasis FILLER_229 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"996-9 OPERA��ES MERCADO EXTERNO                    ");
                /*"    10  FILLER         PIC X(51) VALUE        '997-0 BANCO VOLKSWAGEN S.A.                        '.*/
                public StringBasis FILLER_230 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"997-0 BANCO VOLKSWAGEN S.A.                        ");
                /*"  05 TAB-BANCOS         REDEFINES    TAB-BANCOS-FILLER.*/
            }
            private _REDEF_GE0080B_TAB_BANCOS _tab_bancos { get; set; }
            public _REDEF_GE0080B_TAB_BANCOS TAB_BANCOS
            {
                get { _tab_bancos = new _REDEF_GE0080B_TAB_BANCOS(); _.Move(TAB_BANCOS_FILLER, _tab_bancos); VarBasis.RedefinePassValue(TAB_BANCOS_FILLER, _tab_bancos, TAB_BANCOS_FILLER); _tab_bancos.ValueChanged += () => { _.Move(_tab_bancos, TAB_BANCOS_FILLER); }; return _tab_bancos; }
                set { VarBasis.RedefinePassValue(value, _tab_bancos, TAB_BANCOS_FILLER); }
            }  //Redefines
            public class _REDEF_GE0080B_TAB_BANCOS : VarBasis
            {
                /*"     10 FILLER                 OCCURS 231 TIMES.*/
                public ListBasis<GE0080B_FILLER_231> FILLER_231 { get; set; } = new ListBasis<GE0080B_FILLER_231>(231);
                public class GE0080B_FILLER_231 : VarBasis
                {
                    /*"         15 TAB-COD-BANCO          PIC  9(03).*/
                    public IntBasis TAB_COD_BANCO { get; set; } = new IntBasis(new PIC("9", "3", "9(03)."));
                    /*"         15 FILLER                 PIC  X(01).*/
                    public StringBasis FILLER_232 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                    /*"         15 TAB-DV-BANCO           PIC  X(01).*/
                    public StringBasis TAB_DV_BANCO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                    /*"         15 FILLER                 PIC  X(01).*/
                    public StringBasis FILLER_233 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                    /*"         15 TAB-NOME-BANCO         PIC  X(45).*/
                    public StringBasis TAB_NOME_BANCO { get; set; } = new StringBasis(new PIC("X", "45", "X(45)."), @"");
                    /*"01          WABEND.*/

                    public GE0080B_FILLER_231()
                    {
                        TAB_COD_BANCO.ValueChanged += OnValueChanged;
                        FILLER_232.ValueChanged += OnValueChanged;
                        TAB_DV_BANCO.ValueChanged += OnValueChanged;
                        FILLER_233.ValueChanged += OnValueChanged;
                        TAB_NOME_BANCO.ValueChanged += OnValueChanged;
                    }

                }

                public _REDEF_GE0080B_TAB_BANCOS()
                {
                    FILLER_231.ValueChanged += OnValueChanged;
                }

            }
        }
        public GE0080B_WABEND WABEND { get; set; } = new GE0080B_WABEND();
        public class GE0080B_WABEND : VarBasis
        {
            /*"  05        FILLER              PIC  X(010)     VALUE           ' GE0080B'.*/
            public StringBasis FILLER_234 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" GE0080B");
            /*"  05        FILLER              PIC  X(026)     VALUE           ' *** ERRO EXEC SQL NUMERO '.*/
            public StringBasis FILLER_235 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @" *** ERRO EXEC SQL NUMERO ");
            /*"  05        WNR-EXEC-SQL        PIC  X(004)     VALUE '0000'.*/
            public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"0000");
            /*"  05        FILLER              PIC  X(013)     VALUE           ' *** SQLCODE '.*/
            public StringBasis FILLER_236 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
            /*"  05        WSQLCODE            PIC  ZZZZZ999-  VALUE ZEROS.*/
            public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
            /*"01  REG-LK-BANCOS.*/
        }
        public GE0080B_REG_LK_BANCOS REG_LK_BANCOS { get; set; } = new GE0080B_REG_LK_BANCOS();
        public class GE0080B_REG_LK_BANCOS : VarBasis
        {
            /*"    05 LK-BANCO-COD-BANCO            PIC  9(03).*/
            public IntBasis LK_BANCO_COD_BANCO { get; set; } = new IntBasis(new PIC("9", "3", "9(03)."));
            /*"    05 LK-BANCO-DV-BANCO             PIC  X(01).*/
            public StringBasis LK_BANCO_DV_BANCO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    05 LK-BANCO-NOME                 PIC  X(60).*/
            public StringBasis LK_BANCO_NOME { get; set; } = new StringBasis(new PIC("X", "60", "X(60)."), @"");
            /*"    05 LK-BANCO-COD-RETORNO          PIC  X(01).*/
            public StringBasis LK_BANCO_COD_RETORNO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    05 LK-BANCO-MENSAGEM-RETORNO     PIC  X(80).*/
            public StringBasis LK_BANCO_MENSAGEM_RETORNO { get; set; } = new StringBasis(new PIC("X", "80", "X(80)."), @"");
        }


        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(GE0080B_REG_LK_BANCOS GE0080B_REG_LK_BANCOS_P) //PROCEDURE DIVISION USING 
        /*REG_LK_BANCOS*/
        {
            try
            {
                this.REG_LK_BANCOS = GE0080B_REG_LK_BANCOS_P;

                /*" -740- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

                /*" -742- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

                /*" -744- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

                /*" -746- MOVE ' ' TO LK-BANCO-COD-RETORNO LK-BANCO-MENSAGEM-RETORNO */
                _.Move(" ", REG_LK_BANCOS.LK_BANCO_COD_RETORNO, REG_LK_BANCOS.LK_BANCO_MENSAGEM_RETORNO);

                /*" -752- PERFORM Execute_DB_SELECT_1 */

                Execute_DB_SELECT_1();

                /*" -755- IF SQLCODE NOT = 0 */

                if (DB.SQLCODE != 0)
                {

                    /*" -756- DISPLAY 'GE0080B - ERRO NO ACESSO SISTEMAS - FI' */
                    _.Display($"GE0080B - ERRO NO ACESSO SISTEMAS - FI");

                    /*" -758- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO(); //GOTO
                    return Result;
                }


                /*" -760- MOVE 1 TO IND */
                _.Move(1, AREA_DE_WORK.IND);

                /*" -762- MOVE ' ' TO LK-BANCO-DV-BANCO LK-BANCO-NOME. */
                _.Move(" ", REG_LK_BANCOS.LK_BANCO_DV_BANCO, REG_LK_BANCOS.LK_BANCO_NOME);

                /*" -766- PERFORM R010-PESQUISA-BANCO THRU R010-EXIT VARYING IND FROM 1 BY 1 UNTIL IND > 231. */

                for (AREA_DE_WORK.IND.Value = 1; !(AREA_DE_WORK.IND > 231); AREA_DE_WORK.IND.Value += 1)
                {

                    R010_PESQUISA_BANCO(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R010_EXIT*/

                }

                /*" -767- IF LK-BANCO-NOME EQUAL SPACES */

                if (REG_LK_BANCOS.LK_BANCO_NOME.IsEmpty())
                {

                    /*" -768- MOVE '1' TO LK-BANCO-COD-RETORNO */
                    _.Move("1", REG_LK_BANCOS.LK_BANCO_COD_RETORNO);

                    /*" -770- MOVE ' GE0080B - BANCO NAO ENCONTRADO' TO LK-BANCO-MENSAGEM-RETORNO */
                    _.Move(" GE0080B - BANCO NAO ENCONTRADO", REG_LK_BANCOS.LK_BANCO_MENSAGEM_RETORNO);

                    /*" -771- ELSE */
                }
                else
                {


                    /*" -772- MOVE ' ' TO LK-BANCO-COD-RETORNO */
                    _.Move(" ", REG_LK_BANCOS.LK_BANCO_COD_RETORNO);

                    /*" -785- MOVE ' ' TO LK-BANCO-MENSAGEM-RETORNO . */
                    _.Move(" ", REG_LK_BANCOS.LK_BANCO_MENSAGEM_RETORNO);
                }


                /*" -785- GOBACK. */

                throw new GoBack();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { REG_LK_BANCOS, CodigoRetorno = RETURN_CODE.Value };
            return Result;
        }

        [StopWatch]
        /*" Execute-DB-SELECT-1 */
        public void Execute_DB_SELECT_1()
        {
            /*" -752- EXEC SQL SELECT DATA_MOV_ABERTO INTO :SISTEMAS-DATA-MOV-ABERTO FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'FI' WITH UR END-EXEC. */

            var execute_DB_SELECT_1_Query1 = new Execute_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = Execute_DB_SELECT_1_Query1.Execute(execute_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);
            }


        }

        [StopWatch]
        /*" R010-PESQUISA-BANCO */
        private void R010_PESQUISA_BANCO(bool isPerform = false)
        {
            /*" -791- IF TAB-COD-BANCO(IND) EQUAL LK-BANCO-COD-BANCO */

            if (AUX_BANCOS.TAB_BANCOS.FILLER_231[AREA_DE_WORK.IND].TAB_COD_BANCO == REG_LK_BANCOS.LK_BANCO_COD_BANCO)
            {

                /*" -792- MOVE TAB-DV-BANCO(IND) TO LK-BANCO-DV-BANCO */
                _.Move(AUX_BANCOS.TAB_BANCOS.FILLER_231[AREA_DE_WORK.IND].TAB_DV_BANCO, REG_LK_BANCOS.LK_BANCO_DV_BANCO);

                /*" -793- MOVE TAB-NOME-BANCO(IND) TO LK-BANCO-NOME */
                _.Move(AUX_BANCOS.TAB_BANCOS.FILLER_231[AREA_DE_WORK.IND].TAB_NOME_BANCO, REG_LK_BANCOS.LK_BANCO_NOME);

                /*" -793- MOVE 500 TO IND. */
                _.Move(500, AREA_DE_WORK.IND);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R010_EXIT*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO */
        private void R9999_00_ROT_ERRO(bool isPerform = false)
        {
            /*" -805- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, WABEND.WSQLCODE);

            /*" -807- DISPLAY WABEND. */
            _.Display(WABEND);

            /*" -807- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -811- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -811- GOBACK. */

            throw new GoBack();

        }
    }
}