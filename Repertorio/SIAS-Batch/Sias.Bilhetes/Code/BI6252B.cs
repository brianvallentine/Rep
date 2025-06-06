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
using Sias.Bilhetes.DB2.BI6252B;

namespace Code
{
    public class BI6252B
    {
        public bool IsCall { get; set; }

        public BI6252B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------                                 */
        /*"      *                                                                       */
        /*"      *                                                                       */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  BILHETES                           *      */
        /*"      *   PROGRAMA ...............  BI6252B                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA /PROGRAMADOR...  CLOVIS                             *      */
        /*"      *   DATA CODIFICACAO .......  24/07/2012                         *      */
        /*"      *   PROGRAMA ORIGEM ........  CB6252B                            *      */
        /*"      *   CADMUS   ORIGEM ........  60449                              *      */
        /*"      *   VERSAO .................  V.00                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *    VER NOTA01 / NOTA02 NO FINAL DO PROGRAMA                    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO .................  CONVENIO DE ARRECADACAO - SICAP    *      */
        /*"      *                             PRODUTOS EXTRA REDE.               *      */
        /*"      *                             CONVENIO DE ARRECADACAO - SUPERPAY *      */
        /*"      *                             CONVENIO - 021000 - ORIGEM - 1006  *      */
        /*"      *                                                                *      */
        /*"      *   A PARTIR DA LEITURA DA TABELA MOVIMENTO_COBRANCA COM         *      */
        /*"      *   SIT_REGISTRO IGUAL ' ' E TIPO_MOVIMENTO IGUAL 'Y'.           *      */
        /*"      *   REGISTROS GRAVADOS PELO PGM BI6251B.                         *      */
        /*"      *                                                                *      */
        /*"      *   1 - GERA ARQUIVO DE INCONSISTENCIA PARA PROPOSTAS NAO        *      */
        /*"      *       CADASTRADAS.                                             *      */
        /*"      *                                                                *      */
        /*"      *   2 - LIBERA PARCELA DE ADESAO ALTERANDO SIT_REGISTRO COM '0'  *      */
        /*"      *       PARA BAIXA NO PROGRAMA BI6253B.                          *      */
        /*"      *                                                                *      */
        /*"      *   3 - EMITE ENDOSSOS (0,1,2).                                  *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   Verificado em 23/01/2019 - LUIZ FERNANDO                            */
        /*"      ******************************************************************      */
        /*"V.05  *  VERSAO 05  - DEMANDA 455.132                                  *      */
        /*"      *             - ACERTO DO INSERT NA PROPOSTA_FIDELIZ E RETIRADO  *      */
        /*"      *               CAMPO INCLUIDO NO INSERT DA PROPOSTA_FIDELI POR  *      */
        /*"      *               NAO EXISTIR EM PRODUCAO                          *      */
        /*"      *                                                                *      */
        /*"      *  EM 27/02/2023 - HUSNI ALI HUSNI                               *      */
        /*"      *                                        PROCURE POR V.05        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.04  *  VERSAO 04  - DEMANDA 455.132                                  *      */
        /*"      *             - FAZ GRAVACAO DE CAMPOS NUM_CERTIFICADO E COD_IDLG*      */
        /*"      *               NA MOVTO_DEBITOCC_CEF                            *      */
        /*"      *                                                                *      */
        /*"      *  EM 17/02/2023 - ELIERMES OLIVEIRA                             *      */
        /*"      *                                        PROCURE POR V.04        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 03...: DEMANDA 306086/TAREFA 307563                     *      */
        /*"      *               CADASTRAR APOLICE CORRETOR COMO CAIXA SEGURIDADE *      */
        /*"      *               (25267) PARA PROPOSTAS COM PRODUTO XS2 E DATA DE *      */
        /*"      *               EMISSAO MAIOR IGUAL A 16/08/2021 E TIPO COMISSAO *      */
        /*"      *               = 1 (CORRETAGEM) QUE HOJE S�O TRATADOS PELO      *      */
        /*"      *               WIZ                                              *      */
        /*"      * DATA .......: 13/08/2021                                       *      */
        /*"      * RESPONSAVEL.: RAUL BASILI ROTTA                                *      */
        /*"      *                                                   PROCURE V.03 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 02 - DEMANDA 175.167                                  *      */
        /*"      *             - IMPACTO DA INCLUSAO DO CAMPO IND_TP_CONTA NA     *      */
        /*"      *               TABELA PROPOSTA_FIDELIZ.                         *      */
        /*"      *                                                                *      */
        /*"      *    EM 05/02/2018 - MARCUS VALERIO                              *      */
        /*"      *                                        PROCURE POR V.02        *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 01 - CADMUS - 140.553                                 *      */
        /*"      *             - IMPACTO DA INCLUSAO DO CAMPO IND_TP_PROPOSTA NA  *      */
        /*"      *               TABELA PROPOSTA_FIDELIZ.                         *      */
        /*"      *                                                                *      */
        /*"      *    EM 04/08/2016 - FRANK CARVALHO                              *      */
        /*"      *                                        PROCURE POR V.01        *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        #endregion


        #region VARIABLES

        public FileBasis _BI6252B1 { get; set; } = new FileBasis(new PIC("X", "300", "X(300)"));

        public FileBasis BI6252B1
        {
            get
            {
                _.Move(REG_BI6252B, _BI6252B1); VarBasis.RedefinePassValue(REG_BI6252B, _BI6252B1, REG_BI6252B); return _BI6252B1;
            }
        }
        /*"01        REG-BI6252B                 PIC  X(300).*/
        public StringBasis REG_BI6252B { get; set; } = new StringBasis(new PIC("X", "300", "X(300)."), @"");

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"*/
        public IntBasis WS_IPC { get; set; } = new IntBasis(new PIC("9", "4", "9(4)"));
        /*"77    VIND-DTNASC               PIC S9(004)     COMP.*/
        public IntBasis VIND_DTNASC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-SEXO                 PIC S9(004)     COMP.*/
        public IntBasis VIND_SEXO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-ESTCIVIL             PIC S9(004)     COMP.*/
        public IntBasis VIND_ESTCIVIL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-NUM-IDENT            PIC S9(004)     COMP.*/
        public IntBasis VIND_NUM_IDENT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-ORGAO-EXP            PIC S9(004)     COMP.*/
        public IntBasis VIND_ORGAO_EXP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-UF-EXP               PIC S9(004)     COMP.*/
        public IntBasis VIND_UF_EXP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-DTEXPEDI             PIC S9(004)     COMP.*/
        public IntBasis VIND_DTEXPEDI { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-COD-CBO              PIC S9(004)     COMP.*/
        public IntBasis VIND_COD_CBO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-TP-IDENT             PIC S9(004)     COMP.*/
        public IntBasis VIND_TP_IDENT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-DTNASC-ESPOSA        PIC S9(004)     COMP.*/
        public IntBasis VIND_DTNASC_ESPOSA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-CBO-CONJ             PIC S9(004)     COMP.*/
        public IntBasis VIND_CBO_CONJ { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-DIADEB               PIC S9(004)     COMP.*/
        public IntBasis VIND_DIADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-AGEDEB               PIC S9(004)     COMP.*/
        public IntBasis VIND_AGEDEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-OPEDEB               PIC S9(004)     COMP.*/
        public IntBasis VIND_OPEDEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-CTADEB               PIC S9(004)     COMP.*/
        public IntBasis VIND_CTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-DIGDEB               PIC S9(004)     COMP.*/
        public IntBasis VIND_DIGDEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-DTENVIO              PIC S9(004)     COMP.*/
        public IntBasis VIND_DTENVIO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-USUARIO              PIC S9(004)     COMP.*/
        public IntBasis VIND_USUARIO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-REQUISICAO           PIC S9(004)     COMP.*/
        public IntBasis VIND_REQUISICAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-DTRETORNO            PIC S9(004)     COMP.*/
        public IntBasis VIND_DTRETORNO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-CODRET               PIC S9(004)     COMP.*/
        public IntBasis VIND_CODRET { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-CARTAO               PIC S9(004)     COMP.*/
        public IntBasis VIND_CARTAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-SEQUENCIA            PIC S9(004)     COMP.*/
        public IntBasis VIND_SEQUENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-LOTE                 PIC S9(004)     COMP.*/
        public IntBasis VIND_LOTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-DTCREDITO            PIC S9(004)     COMP.*/
        public IntBasis VIND_DTCREDITO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-STATUS               PIC S9(004)     COMP.*/
        public IntBasis VIND_STATUS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-VLCREDITO            PIC S9(004)     COMP.*/
        public IntBasis VIND_VLCREDITO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-NULL01               PIC S9(004)     COMP.*/
        public IntBasis VIND_NULL01 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-NULL02               PIC S9(004)     COMP.*/
        public IntBasis VIND_NULL02 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-NULL03               PIC S9(004)     COMP.*/
        public IntBasis VIND_NULL03 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-NULL04               PIC S9(004)     COMP.*/
        public IntBasis VIND_NULL04 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-NULL05               PIC S9(004)     COMP.*/
        public IntBasis VIND_NULL05 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-NULL06               PIC S9(004)     COMP.*/
        public IntBasis VIND_NULL06 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-NULL07               PIC S9(004)     COMP.*/
        public IntBasis VIND_NULL07 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-NULL08               PIC S9(004)     COMP.*/
        public IntBasis VIND_NULL08 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-NULL09               PIC S9(004)     COMP.*/
        public IntBasis VIND_NULL09 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-NULL10               PIC S9(004)     COMP.*/
        public IntBasis VIND_NULL10 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-DATARCAP             PIC S9(004)     COMP.*/
        public IntBasis VIND_DATARCAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-CODEMP               PIC S9(004)     COMP.*/
        public IntBasis VIND_CODEMP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-CORRECAO             PIC S9(004)     COMP.*/
        public IntBasis VIND_CORRECAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-ISENTA               PIC S9(004)     COMP.*/
        public IntBasis VIND_ISENTA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-DTVENCTO             PIC S9(004)     COMP.*/
        public IntBasis VIND_DTVENCTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-PREFIX               PIC S9(004)     COMP.*/
        public IntBasis VIND_PREFIX { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-CUSEMIS              PIC S9(004)     COMP.*/
        public IntBasis VIND_CUSEMIS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-SIT-COBRANCA         PIC S9(004)     COMP.*/
        public IntBasis VIND_SIT_COBRANCA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-DTQITBCO             PIC S9(004)     COMP.*/
        public IntBasis VIND_DTQITBCO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-SITUACAO             PIC S9(004)     COMP.*/
        public IntBasis VIND_SITUACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    WSHOST-DTMOVABE20         PIC  X(010).*/
        public StringBasis WSHOST_DTMOVABE20 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    WSHOST-NOME-RAZAO         PIC  X(040).*/
        public StringBasis WSHOST_NOME_RAZAO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"77    WSHOST-CIDADE             PIC  X(020).*/
        public StringBasis WSHOST_CIDADE { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
        /*"77    WSHOST-SIGLA-UF           PIC  X(002).*/
        public StringBasis WSHOST_SIGLA_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
        /*"77    WSHOST-DTTERCOT           PIC  X(010).*/
        public StringBasis WSHOST_DTTERCOT { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    WSHOST-DTINICOT           PIC  X(010).*/
        public StringBasis WSHOST_DTINICOT { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    WSCOR99-DATA-INIVIGENCIA  PIC  X(010).*/
        public StringBasis WSCOR99_DATA_INIVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    WSGER00-DATA-INIVIGENCIA  PIC  X(010).*/
        public StringBasis WSGER00_DATA_INIVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    WSGER00-DATA-TERVIGENCIA  PIC  X(010).*/
        public StringBasis WSGER00_DATA_TERVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    WSGER00-DATA-VENCIMENTO   PIC  X(010).*/
        public StringBasis WSGER00_DATA_VENCIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    WSGER01-DATA-INIVIGENCIA  PIC  X(010).*/
        public StringBasis WSGER01_DATA_INIVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    WSGER01-DATA-TERVIGENCIA  PIC  X(010).*/
        public StringBasis WSGER01_DATA_TERVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    WSGER02-DATA-INIVIGENCIA  PIC  X(010).*/
        public StringBasis WSGER02_DATA_INIVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    WSGER02-DATA-TERVIGENCIA  PIC  X(010).*/
        public StringBasis WSGER02_DATA_TERVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    WSGER03-DATA-INIVIGENCIA  PIC  X(010).*/
        public StringBasis WSGER03_DATA_INIVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    WSGER03-DATA-TERVIGENCIA  PIC  X(010).*/
        public StringBasis WSGER03_DATA_TERVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    WSGER04-DATA-INIVIGENCIA  PIC  X(010).*/
        public StringBasis WSGER04_DATA_INIVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    WSGER04-DATA-TERVIGENCIA  PIC  X(010).*/
        public StringBasis WSGER04_DATA_TERVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    WSGER05-DATA-INIVIGENCIA  PIC  X(010).*/
        public StringBasis WSGER05_DATA_INIVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    WSGER05-DATA-TERVIGENCIA  PIC  X(010).*/
        public StringBasis WSGER05_DATA_TERVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    WSGER06-DATA-INIVIGENCIA  PIC  X(010).*/
        public StringBasis WSGER06_DATA_INIVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    WSGER06-DATA-TERVIGENCIA  PIC  X(010).*/
        public StringBasis WSGER06_DATA_TERVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    WSGER07-DATA-INIVIGENCIA  PIC  X(010).*/
        public StringBasis WSGER07_DATA_INIVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    WSGER07-DATA-TERVIGENCIA  PIC  X(010).*/
        public StringBasis WSGER07_DATA_TERVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    WSGER08-DATA-INIVIGENCIA  PIC  X(010).*/
        public StringBasis WSGER08_DATA_INIVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    WSGER08-DATA-TERVIGENCIA  PIC  X(010).*/
        public StringBasis WSGER08_DATA_TERVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    WSGER09-DATA-INIVIGENCIA  PIC  X(010).*/
        public StringBasis WSGER09_DATA_INIVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    WSGER09-DATA-TERVIGENCIA  PIC  X(010).*/
        public StringBasis WSGER09_DATA_TERVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    WSGER10-DATA-INIVIGENCIA  PIC  X(010).*/
        public StringBasis WSGER10_DATA_INIVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    WSGER10-DATA-TERVIGENCIA  PIC  X(010).*/
        public StringBasis WSGER10_DATA_TERVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    WSGER11-DATA-INIVIGENCIA  PIC  X(010).*/
        public StringBasis WSGER11_DATA_INIVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    WSGER11-DATA-TERVIGENCIA  PIC  X(010).*/
        public StringBasis WSGER11_DATA_TERVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    WSGER12-DATA-INIVIGENCIA  PIC  X(010).*/
        public StringBasis WSGER12_DATA_INIVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    WSGER12-DATA-TERVIGENCIA  PIC  X(010).*/
        public StringBasis WSGER12_DATA_TERVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    WSGER13-DATA-INIVIGENCIA  PIC  X(010).*/
        public StringBasis WSGER13_DATA_INIVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    WSGER13-DATA-TERVIGENCIA  PIC  X(010).*/
        public StringBasis WSGER13_DATA_TERVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    WSGER14-DATA-INIVIGENCIA  PIC  X(010).*/
        public StringBasis WSGER14_DATA_INIVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    WSGER14-DATA-TERVIGENCIA  PIC  X(010).*/
        public StringBasis WSGER14_DATA_TERVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    WSGER15-DATA-INIVIGENCIA  PIC  X(010).*/
        public StringBasis WSGER15_DATA_INIVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    WSGER15-DATA-TERVIGENCIA  PIC  X(010).*/
        public StringBasis WSGER15_DATA_TERVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    WSGER01-DATA-VENCIMENTO   PIC  X(010).*/
        public StringBasis WSGER01_DATA_VENCIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    WSGER02-DATA-VENCIMENTO   PIC  X(010).*/
        public StringBasis WSGER02_DATA_VENCIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    WSGER03-DATA-VENCIMENTO   PIC  X(010).*/
        public StringBasis WSGER03_DATA_VENCIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    WSGER04-DATA-VENCIMENTO   PIC  X(010).*/
        public StringBasis WSGER04_DATA_VENCIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    WSGER05-DATA-VENCIMENTO   PIC  X(010).*/
        public StringBasis WSGER05_DATA_VENCIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    WSGER06-DATA-VENCIMENTO   PIC  X(010).*/
        public StringBasis WSGER06_DATA_VENCIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    WSGER07-DATA-VENCIMENTO   PIC  X(010).*/
        public StringBasis WSGER07_DATA_VENCIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    WSGER08-DATA-VENCIMENTO   PIC  X(010).*/
        public StringBasis WSGER08_DATA_VENCIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    WSGER09-DATA-VENCIMENTO   PIC  X(010).*/
        public StringBasis WSGER09_DATA_VENCIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    WSGER10-DATA-VENCIMENTO   PIC  X(010).*/
        public StringBasis WSGER10_DATA_VENCIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    WSGER11-DATA-VENCIMENTO   PIC  X(010).*/
        public StringBasis WSGER11_DATA_VENCIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    WSGER12-DATA-VENCIMENTO   PIC  X(010).*/
        public StringBasis WSGER12_DATA_VENCIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    WSGER13-DATA-VENCIMENTO   PIC  X(010).*/
        public StringBasis WSGER13_DATA_VENCIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    WSGER14-DATA-VENCIMENTO   PIC  X(010).*/
        public StringBasis WSGER14_DATA_VENCIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    WSGER15-DATA-VENCIMENTO   PIC  X(010).*/
        public StringBasis WSGER15_DATA_VENCIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    WSHOST-PCT-IOCC           PIC S9(003)V9999    COMP-3.*/
        public DoubleBasis WSHOST_PCT_IOCC { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9999"), 4);
        /*"77    WSHOST-VAL-IOCC           PIC S9(013)V99      COMP-3.*/
        public DoubleBasis WSHOST_VAL_IOCC { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    WSHOST-IMP-SEGURADA-IX    PIC S9(013)V99      COMP-3.*/
        public DoubleBasis WSHOST_IMP_SEGURADA_IX { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    WSHOST-PRM-TOTAL          PIC S9(013)V99      COMP-3.*/
        public DoubleBasis WSHOST_PRM_TOTAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01         WS-COD-CORRETOR      PIC  9(009)     VALUE 0.*/

        public SelectorBasis WS_COD_CORRETOR { get; set; } = new SelectorBasis("009", "0")
        {
            Items = new List<SelectorItemBasis> {
                            /*" 88       N88-COD-CORRETOR    VALUES  2496,  2933,  6327,  7005,                                      9440, 17256, 17604, 17752,                                     18040, 19224, 23914, 23922,                                     23931, 23949, 23957, 24112,                                     24121, 24163, 24236, 24287,                                     24295, 24309, 24317, 24333,                                     24341, 24368, 24384, 24392,                                     24431, 24449, 24457, 24481,                                     24716, 24937, 24945, 24970,                                     24996, 25003, 101150. */
							new SelectorItemBasis("N88_COD_CORRETOR", "2496,2933,6327,7005,9440,17256,17604,17752,18040,19224,23914,23922,23931,23949,23957,24112,24121,24163,24236,24287,24295,24309,24317,24333,24341,24368,24384,24392,24431,24449,24457,24481,24716,24937,24945,24970,24996,25003,101150")
                }
        };

        /*"01  W.*/
        public BI6252B_W W { get; set; } = new BI6252B_W();
        public class BI6252B_W : VarBasis
        {
            /*"  03  WFIM-MOVIMENTO            PIC  X(001)         VALUE SPACES*/
            public StringBasis WFIM_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  03  WFIM-COTACAO              PIC  X(001)         VALUE SPACES*/
            public StringBasis WFIM_COTACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  03  LD-COTACAO                PIC  9(007)         VALUE ZEROS.*/
            public IntBasis LD_COTACAO { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  DP-COTACAO                PIC  9(007)         VALUE ZEROS.*/
            public IntBasis DP_COTACAO { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  LD-MOVIMCOB               PIC  9(007)         VALUE ZEROS.*/
            public IntBasis LD_MOVIMCOB { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  DP-CONVENIO               PIC  9(007)         VALUE ZEROS.*/
            public IntBasis DP_CONVENIO { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  DP-DATA                   PIC  9(007)         VALUE ZEROS.*/
            public IntBasis DP_DATA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  NT-BILHETE                PIC  9(007)         VALUE ZEROS.*/
            public IntBasis NT_BILHETE { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  AC-ERRO                   PIC  9(007)         VALUE ZEROS.*/
            public IntBasis AC_ERRO { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  DP-PARCELA                PIC  9(007)         VALUE ZEROS.*/
            public IntBasis DP_PARCELA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  LB-PARCELA                PIC  9(007)         VALUE ZEROS.*/
            public IntBasis LB_PARCELA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  TT-RELACAO                PIC  9(007)         VALUE ZEROS.*/
            public IntBasis TT_RELACAO { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  IN-PESSOA                 PIC  9(007)         VALUE ZEROS.*/
            public IntBasis IN_PESSOA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  IN-RTPRELAC               PIC  9(007)         VALUE ZEROS.*/
            public IntBasis IN_RTPRELAC { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  IN-IDENTREL               PIC  9(007)         VALUE ZEROS.*/
            public IntBasis IN_IDENTREL { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  IN-PROPOFID               PIC  9(007)         VALUE ZEROS.*/
            public IntBasis IN_PROPOFID { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  UP-PROPOSTA               PIC  9(007)         VALUE ZEROS.*/
            public IntBasis UP_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  UP-PROPOFID               PIC  9(007)         VALUE ZEROS.*/
            public IntBasis UP_PROPOFID { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  UP-BILHETE                PIC  9(007)         VALUE ZEROS.*/
            public IntBasis UP_BILHETE { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  WTEM-PROPOSTA             PIC  X(001)         VALUE SPACES*/
            public StringBasis WTEM_PROPOSTA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  03  WTEM-PESSOA               PIC  X(001)         VALUE SPACES*/
            public StringBasis WTEM_PESSOA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  03  WTEM-RELACAO              PIC  X(001)         VALUE SPACES*/
            public StringBasis WTEM_RELACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  03  WTEM-FILIAL               PIC  X(001)         VALUE SPACES*/
            public StringBasis WTEM_FILIAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  03  GV-SAIDA                  PIC  9(007)         VALUE ZEROS.*/
            public IntBasis GV_SAIDA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  AC-MOVDEBCE               PIC  9(007)         VALUE ZEROS.*/
            public IntBasis AC_MOVDEBCE { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  AC-CONTROLE               PIC  9(007)         VALUE ZEROS.*/
            public IntBasis AC_CONTROLE { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  WTEM-COBERTURA            PIC  X(001)         VALUE SPACES*/
            public StringBasis WTEM_COBERTURA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  03  NT-BILHECOB               PIC  9(007)         VALUE ZEROS.*/
            public IntBasis NT_BILHECOB { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  WS-SUBS                   PIC  9(003)         VALUE ZEROS.*/
            public IntBasis WS_SUBS { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
            /*"  03  WS-IND                    PIC  9(003)         VALUE ZEROS.*/
            public IntBasis WS_IND { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
            /*"  03  WS-IPCA-ACUM              PIC S9(6)V9(9)  COMP-3  VALUE 0.*/
            public DoubleBasis WS_IPCA_ACUM { get; set; } = new DoubleBasis(new PIC("S9", "6", "S9(6)V9(9)"), 9);
            /*"  03  WS-IPCA-ACUM-DISPLAY      PIC ----.--9,999999999.*/
            public DoubleBasis WS_IPCA_ACUM_DISPLAY { get; set; } = new DoubleBasis(new PIC("9", "7", "----.--9V999999999."), 9);
            /*"  03         WNUMERO-APOL      PIC  9(013)    VALUE ZEROS.*/
            public IntBasis WNUMERO_APOL { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
            /*"  03         FILLER            REDEFINES      WNUMERO-APOL.*/
            private _REDEF_BI6252B_FILLER_0 _filler_0 { get; set; }
            public _REDEF_BI6252B_FILLER_0 FILLER_0
            {
                get { _filler_0 = new _REDEF_BI6252B_FILLER_0(); _.Move(WNUMERO_APOL, _filler_0); VarBasis.RedefinePassValue(WNUMERO_APOL, _filler_0, WNUMERO_APOL); _filler_0.ValueChanged += () => { _.Move(_filler_0, WNUMERO_APOL); }; return _filler_0; }
                set { VarBasis.RedefinePassValue(value, _filler_0, WNUMERO_APOL); }
            }  //Redefines
            public class _REDEF_BI6252B_FILLER_0 : VarBasis
            {
                /*"    10       WNUM-APOL-ORG     PIC  9(003).*/
                public IntBasis WNUM_APOL_ORG { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"    10       WNUM-APOL-RAM     PIC  9(002).*/
                public IntBasis WNUM_APOL_RAM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       WNUM-APOL-SEQ     PIC  9(008).*/
                public IntBasis WNUM_APOL_SEQ { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"  03         WDATA-REL         PIC  X(010)    VALUE SPACES.*/

                public _REDEF_BI6252B_FILLER_0()
                {
                    WNUM_APOL_ORG.ValueChanged += OnValueChanged;
                    WNUM_APOL_RAM.ValueChanged += OnValueChanged;
                    WNUM_APOL_SEQ.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WDATA_REL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  03         FILLER            REDEFINES      WDATA-REL.*/
            private _REDEF_BI6252B_FILLER_1 _filler_1 { get; set; }
            public _REDEF_BI6252B_FILLER_1 FILLER_1
            {
                get { _filler_1 = new _REDEF_BI6252B_FILLER_1(); _.Move(WDATA_REL, _filler_1); VarBasis.RedefinePassValue(WDATA_REL, _filler_1, WDATA_REL); _filler_1.ValueChanged += () => { _.Move(_filler_1, WDATA_REL); }; return _filler_1; }
                set { VarBasis.RedefinePassValue(value, _filler_1, WDATA_REL); }
            }  //Redefines
            public class _REDEF_BI6252B_FILLER_1 : VarBasis
            {
                /*"    10       WDAT-REL-ANO      PIC  9(004).*/
                public IntBasis WDAT_REL_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDAT-REL-MES      PIC  9(002).*/
                public IntBasis WDAT_REL_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDAT-REL-DIA      PIC  9(002).*/
                public IntBasis WDAT_REL_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03         WDATA-CABEC.*/

                public _REDEF_BI6252B_FILLER_1()
                {
                    WDAT_REL_ANO.ValueChanged += OnValueChanged;
                    FILLER_2.ValueChanged += OnValueChanged;
                    WDAT_REL_MES.ValueChanged += OnValueChanged;
                    FILLER_3.ValueChanged += OnValueChanged;
                    WDAT_REL_DIA.ValueChanged += OnValueChanged;
                }

            }
            public BI6252B_WDATA_CABEC WDATA_CABEC { get; set; } = new BI6252B_WDATA_CABEC();
            public class BI6252B_WDATA_CABEC : VarBasis
            {
                /*"    05       WDATA-DD-CABEC    PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WDATA_DD_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    05       FILLER            PIC  X(001)    VALUE '/'.*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    05       WDATA-MM-CABEC    PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WDATA_MM_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    05       FILLER            PIC  X(001)    VALUE '/'.*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    05       WDATA-AA-CABEC    PIC  9(004)    VALUE ZEROS.*/
                public IntBasis WDATA_AA_CABEC { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"  03         WS-ANOMES          PIC  X(006)    VALUE   SPACES.*/
            }
            public StringBasis WS_ANOMES { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"");
            /*"  03         FILLER             REDEFINES      WS-ANOMES.*/
            private _REDEF_BI6252B_FILLER_6 _filler_6 { get; set; }
            public _REDEF_BI6252B_FILLER_6 FILLER_6
            {
                get { _filler_6 = new _REDEF_BI6252B_FILLER_6(); _.Move(WS_ANOMES, _filler_6); VarBasis.RedefinePassValue(WS_ANOMES, _filler_6, WS_ANOMES); _filler_6.ValueChanged += () => { _.Move(_filler_6, WS_ANOMES); }; return _filler_6; }
                set { VarBasis.RedefinePassValue(value, _filler_6, WS_ANOMES); }
            }  //Redefines
            public class _REDEF_BI6252B_FILLER_6 : VarBasis
            {
                /*"      10     WS-ANO             PIC  9(004).*/
                public IntBasis WS_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      10     WS-MES             PIC  9(002).*/
                public IntBasis WS_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03         WSHOST-DTVENCTO    PIC  X(010)    VALUE   SPACES.*/

                public _REDEF_BI6252B_FILLER_6()
                {
                    WS_ANO.ValueChanged += OnValueChanged;
                    WS_MES.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WSHOST_DTVENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  03         FILLER             REDEFINES      WSHOST-DTVENCTO.*/
            private _REDEF_BI6252B_FILLER_7 _filler_7 { get; set; }
            public _REDEF_BI6252B_FILLER_7 FILLER_7
            {
                get { _filler_7 = new _REDEF_BI6252B_FILLER_7(); _.Move(WSHOST_DTVENCTO, _filler_7); VarBasis.RedefinePassValue(WSHOST_DTVENCTO, _filler_7, WSHOST_DTVENCTO); _filler_7.ValueChanged += () => { _.Move(_filler_7, WSHOST_DTVENCTO); }; return _filler_7; }
                set { VarBasis.RedefinePassValue(value, _filler_7, WSHOST_DTVENCTO); }
            }  //Redefines
            public class _REDEF_BI6252B_FILLER_7 : VarBasis
            {
                /*"    10       WSHOST-ANO        PIC  9(004).*/
                public IntBasis WSHOST_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WSHOST-MES        PIC  9(002).*/
                public IntBasis WSHOST_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WSHOST-DIA        PIC  9(002).*/
                public IntBasis WSHOST_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"01            AUX-RELATORIO.*/

                public _REDEF_BI6252B_FILLER_7()
                {
                    WSHOST_ANO.ValueChanged += OnValueChanged;
                    FILLER_8.ValueChanged += OnValueChanged;
                    WSHOST_MES.ValueChanged += OnValueChanged;
                    FILLER_9.ValueChanged += OnValueChanged;
                    WSHOST_DIA.ValueChanged += OnValueChanged;
                }

            }
        }
        public BI6252B_AUX_RELATORIO AUX_RELATORIO { get; set; } = new BI6252B_AUX_RELATORIO();
        public class BI6252B_AUX_RELATORIO : VarBasis
        {
            /*"  03          LC00.*/
            public BI6252B_LC00 LC00 { get; set; } = new BI6252B_LC00();
            public class BI6252B_LC00 : VarBasis
            {
                /*"    10        FILLER              PIC  X(008)  VALUE             'CONVENIO'.*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"CONVENIO");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(016)  VALUE             'PROPOSTA'.*/
                public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "16", "X(016)"), @"PROPOSTA");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(011)  VALUE             'BILHETE'.*/
                public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"BILHETE");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(010)  VALUE             'PAGAMENTO'.*/
                public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"PAGAMENTO");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(010)  VALUE             'CREDITO'.*/
                public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"CREDITO");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(008)  VALUE             'NSA RET.'.*/
                public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"NSA RET.");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(015)  VALUE             '         VALOR'.*/
                public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"         VALOR");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(007)  VALUE             'PRODUTO'.*/
                public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"PRODUTO");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(013)  VALUE             'APOLICE'.*/
                public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"APOLICE");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(009)  VALUE             'ENDOSSO'.*/
                public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"ENDOSSO");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(007)  VALUE             'PARCELA'.*/
                public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"PARCELA");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(040)  VALUE             'MENSAGEM'.*/
                public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"MENSAGEM");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(009)  VALUE             'COBERTURA'.*/
                public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"COBERTURA");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(016)  VALUE             'VALOR PREMIO   '.*/
                public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "16", "X(016)"), @"VALOR PREMIO   ");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(016)  VALUE             'IMPSEG - IPCA  '.*/
                public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "16", "X(016)"), @"IMPSEG - IPCA  ");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(016)  VALUE             'PREMIO - IPCA  '.*/
                public StringBasis FILLER_40 { get; set; } = new StringBasis(new PIC("X", "16", "X(016)"), @"PREMIO - IPCA  ");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        FILLER              PIC  X(018)  VALUE             'IPCA ACUMULADO '.*/
                public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "18", "X(018)"), @"IPCA ACUMULADO ");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_43 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"  03          LD01.*/
            }
            public BI6252B_LD01 LD01 { get; set; } = new BI6252B_LD01();
            public class BI6252B_LD01 : VarBasis
            {
                /*"    10        LD01-CONVENIO       PIC  ZZZZZZZ9.*/
                public IntBasis LD01_CONVENIO { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZZZZ9."));
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_44 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-PROPOSTA       PIC  ZZZZZZZZZZZZZZZ9.*/
                public IntBasis LD01_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "16", "ZZZZZZZZZZZZZZZ9."));
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_45 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-BILHETE        PIC  ZZZZZZZZZZ9.*/
                public IntBasis LD01_BILHETE { get; set; } = new IntBasis(new PIC("9", "11", "ZZZZZZZZZZ9."));
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_46 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-DTPAGTO        PIC  X(010).*/
                public StringBasis LD01_DTPAGTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_47 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-DTCREDITO      PIC  X(010).*/
                public StringBasis LD01_DTCREDITO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_48 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-NSAS           PIC  ZZZZZZZ9.*/
                public IntBasis LD01_NSAS { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZZZZ9."));
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_49 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-VALOR          PIC  ZZZ.ZZZ.ZZ9,99-.*/
                public DoubleBasis LD01_VALOR { get; set; } = new DoubleBasis(new PIC("9", "9", "ZZZ.ZZZ.ZZ9V99-."), 3);
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_50 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-CODPRODU       PIC  ZZZZZZ9.*/
                public IntBasis LD01_CODPRODU { get; set; } = new IntBasis(new PIC("9", "7", "ZZZZZZ9."));
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_51 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-APOLICE        PIC  ZZZZZZZZZZZZ9.*/
                public IntBasis LD01_APOLICE { get; set; } = new IntBasis(new PIC("9", "13", "ZZZZZZZZZZZZ9."));
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_52 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-ENDOSSO        PIC  ZZZZZZZZ9.*/
                public IntBasis LD01_ENDOSSO { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZZZZ9."));
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_53 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-PARCELA        PIC  ZZZZZZ9.*/
                public IntBasis LD01_PARCELA { get; set; } = new IntBasis(new PIC("9", "7", "ZZZZZZ9."));
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_54 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-MENSAGEM       PIC  X(040).*/
                public StringBasis LD01_MENSAGEM { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_55 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-OPCAO          PIC  9(004).*/
                public IntBasis LD01_OPCAO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10        FILLER              PIC  X(005)  VALUE  SPACES.*/
                public StringBasis FILLER_56 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_57 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-PRM-TOTAL      PIC  ZZZZ.ZZZ.ZZ9,99-.*/
                public DoubleBasis LD01_PRM_TOTAL { get; set; } = new DoubleBasis(new PIC("9", "10", "ZZZZ.ZZZ.ZZ9V99-."), 3);
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_58 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-IMP-IPCA       PIC  ZZZZ.ZZZ.ZZ9,99-.*/
                public DoubleBasis LD01_IMP_IPCA { get; set; } = new DoubleBasis(new PIC("9", "10", "ZZZZ.ZZZ.ZZ9V99-."), 3);
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_59 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-PRM-IPCA       PIC  ZZZZ.ZZZ.ZZ9,99-.*/
                public DoubleBasis LD01_PRM_IPCA { get; set; } = new DoubleBasis(new PIC("9", "10", "ZZZZ.ZZZ.ZZ9V99-."), 3);
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_60 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"    10        LD01-IND-IPCA       PIC  ZZZ.ZZ9,999999999-.*/
                public DoubleBasis LD01_IND_IPCA { get; set; } = new DoubleBasis(new PIC("9", "6", "ZZZ.ZZ9V999999999-."), 10);
                /*"    10        FILLER              PIC  X(003)  VALUE ' ;'.*/
                public StringBasis FILLER_61 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"  03         MVPAY-NOME.*/
            }
            public BI6252B_MVPAY_NOME MVPAY_NOME { get; set; } = new BI6252B_MVPAY_NOME();
            public class BI6252B_MVPAY_NOME : VarBasis
            {
                /*"      10     MVPAY-NRSEQREG    PIC  9(009).*/
                public IntBasis MVPAY_NRSEQREG { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
                /*"      10     FILLER            PIC  X(031).*/
                public StringBasis FILLER_62 { get; set; } = new StringBasis(new PIC("X", "31", "X(031)."), @"");
                /*"  03        WABEND.*/
            }
            public BI6252B_WABEND WABEND { get; set; } = new BI6252B_WABEND();
            public class BI6252B_WABEND : VarBasis
            {
                /*"    05      FILLER              PIC  X(010) VALUE           ' BI6252B  '.*/
                public StringBasis FILLER_63 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" BI6252B  ");
                /*"    05      FILLER              PIC  X(028) VALUE           ' *** ERRO  EXEC SQL  NUMERO '.*/
                public StringBasis FILLER_64 { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @" *** ERRO  EXEC SQL  NUMERO ");
                /*"    05      WNR-EXEC-SQL        PIC  X(004) VALUE    SPACES.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                /*"    05      FILLER              PIC  X(014) VALUE           '    SQLCODE = '.*/
                public StringBasis FILLER_65 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE = ");
                /*"    05      WSQLCODE            PIC  ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                /*"    05      FILLER              PIC  X(014) VALUE           '   SQLERRD1 = '.*/
                public StringBasis FILLER_66 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD1 = ");
                /*"    05      WSQLERRD1           PIC  ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLERRD1 { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                /*"    05      FILLER              PIC  X(014) VALUE           '   SQLERRD2 = '.*/
                public StringBasis FILLER_67 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD2 = ");
                /*"    05      WSQLERRD2           PIC  ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLERRD2 { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                /*"    05      WSQLERRO.*/
                public BI6252B_WSQLERRO WSQLERRO { get; set; } = new BI6252B_WSQLERRO();
                public class BI6252B_WSQLERRO : VarBasis
                {
                    /*"      10    FILLER               PIC  X(014) VALUE            ' *** SQLERRMC '.*/
                    public StringBasis FILLER_68 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @" *** SQLERRMC ");
                    /*"      10    WSQLERRMC            PIC  X(070) VALUE  SPACES.*/
                    public StringBasis WSQLERRMC { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"");
                    /*"01          LD99-ABEND.*/
                }
            }
        }
        public BI6252B_LD99_ABEND LD99_ABEND { get; set; } = new BI6252B_LD99_ABEND();
        public class BI6252B_LD99_ABEND : VarBasis
        {
            /*"      10    FILLER              PIC  X(050) VALUE           ' REINICIAR JOB NO PROXIMO STEP               '.*/
            public StringBasis FILLER_69 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @" REINICIAR JOB NO PROXIMO STEP               ");
            /*"01          TABELA-IPCA.*/
        }
        public BI6252B_TABELA_IPCA TABELA_IPCA { get; set; } = new BI6252B_TABELA_IPCA();
        public class BI6252B_TABELA_IPCA : VarBasis
        {
            /*"  05        WTIPC-OCORREIPC     OCCURS      300   TIMES                                INDEXED     BY    WS-IPC.*/
            public ListBasis<BI6252B_WTIPC_OCORREIPC> WTIPC_OCORREIPC { get; set; } = new ListBasis<BI6252B_WTIPC_OCORREIPC>(300);
            public class BI6252B_WTIPC_OCORREIPC : VarBasis
            {
                /*"    10      TB-DTINIVIG-IPCA    PIC  X(010).*/
                public StringBasis TB_DTINIVIG_IPCA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"    10      TB-DTTERVIG-IPCA    PIC  X(010).*/
                public StringBasis TB_DTTERVIG_IPCA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"    10      TB-VAL-IPCA         PIC S9(006)V9(9)  COMP-3.*/
                public DoubleBasis TB_VAL_IPCA { get; set; } = new DoubleBasis(new PIC("S9", "6", "S9(006)V9(9)"), 9);
            }
        }


        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.MOVIMCOB MOVIMCOB { get; set; } = new Dclgens.MOVIMCOB();
        public Dclgens.CONVERSI CONVERSI { get; set; } = new Dclgens.CONVERSI();
        public Dclgens.BILHETE BILHETE { get; set; } = new Dclgens.BILHETE();
        public Dclgens.CLIENTES CLIENTES { get; set; } = new Dclgens.CLIENTES();
        public Dclgens.ENDERECO ENDERECO { get; set; } = new Dclgens.ENDERECO();
        public Dclgens.AGENCCEF AGENCCEF { get; set; } = new Dclgens.AGENCCEF();
        public Dclgens.MALHACEF MALHACEF { get; set; } = new Dclgens.MALHACEF();
        public Dclgens.FONTES FONTES { get; set; } = new Dclgens.FONTES();
        public Dclgens.AGENCIAS AGENCIAS { get; set; } = new Dclgens.AGENCIAS();
        public Dclgens.PESSOFIS PESSOFIS { get; set; } = new Dclgens.PESSOFIS();
        public Dclgens.PESSOA PESSOA { get; set; } = new Dclgens.PESSOA();
        public Dclgens.RTPRELAC RTPRELAC { get; set; } = new Dclgens.RTPRELAC();
        public Dclgens.IDENTREL IDENTREL { get; set; } = new Dclgens.IDENTREL();
        public Dclgens.PROPOFID PROPOFID { get; set; } = new Dclgens.PROPOFID();
        public Dclgens.CALENDAR CALENDAR { get; set; } = new Dclgens.CALENDAR();
        public Dclgens.MOVDEBCE MOVDEBCE { get; set; } = new Dclgens.MOVDEBCE();
        public Dclgens.BILHECOB BILHECOB { get; set; } = new Dclgens.BILHECOB();
        public Dclgens.RAMOCOMP RAMOCOMP { get; set; } = new Dclgens.RAMOCOMP();
        public Dclgens.NUMERAES NUMERAES { get; set; } = new Dclgens.NUMERAES();
        public Dclgens.APOLICES APOLICES { get; set; } = new Dclgens.APOLICES();
        public Dclgens.ENDOSSOS ENDOSSOS { get; set; } = new Dclgens.ENDOSSOS();
        public Dclgens.PARCELAS PARCELAS { get; set; } = new Dclgens.PARCELAS();
        public Dclgens.PARCEHIS PARCEHIS { get; set; } = new Dclgens.PARCEHIS();
        public Dclgens.APOLICOB APOLICOB { get; set; } = new Dclgens.APOLICOB();
        public Dclgens.APOLICOR APOLICOR { get; set; } = new Dclgens.APOLICOR();
        public Dclgens.MOEDACOT MOEDACOT { get; set; } = new Dclgens.MOEDACOT();
        public Dclgens.PRODUTO PRODUTO { get; set; } = new Dclgens.PRODUTO();
        public BI6252B_V0COTACAO V0COTACAO { get; set; } = new BI6252B_V0COTACAO();
        public BI6252B_V0MOVIMCOB V0MOVIMCOB { get; set; } = new BI6252B_V0MOVIMCOB();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string BI6252B1_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                BI6252B1.SetFile(BI6252B1_FILE_NAME_P);

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
            /*" -504- MOVE '0000' TO WNR-EXEC-SQL. */
            _.Move("0000", AUX_RELATORIO.WABEND.WNR_EXEC_SQL);

            /*" -505- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -507- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -509- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -512- DISPLAY '--------------------------------' . */
            _.Display($"--------------------------------");

            /*" -513- DISPLAY ' PROGRAMA EM EXECUCAO BI6252B   ' . */
            _.Display($" PROGRAMA EM EXECUCAO BI6252B   ");

            /*" -514- DISPLAY '                                ' . */
            _.Display($"                                ");

            /*" -518- DISPLAY ' VERSAO V.04 455.132 17/02/2023 ' */
            _.Display($" VERSAO V.04 455.132 17/02/2023 ");

            /*" -519- DISPLAY '                                ' */
            _.Display($"                                ");

            /*" -522- DISPLAY '--------------------------------' . */
            _.Display($"--------------------------------");

            /*" -525- PERFORM R0050-00-INICIO. */

            R0050_00_INICIO_SECTION();

            /*" -525- PERFORM R0200-00-PROCESSA. */

            R0200_00_PROCESSA_SECTION();

            /*" -0- FLUXCONTROL_PERFORM R0000_90_FINALIZA */

            R0000_90_FINALIZA();

        }

        [StopWatch]
        /*" R0000-90-FINALIZA */
        private void R0000_90_FINALIZA(bool isPerform = false)
        {
            /*" -530- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -534- CLOSE BI6252B1. */
            BI6252B1.Close();

            /*" -536- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -537- DISPLAY ' ' */
            _.Display($" ");

            /*" -538- DISPLAY 'BI6252B - FIM NORMAL' . */
            _.Display($"BI6252B - FIM NORMAL");

            /*" -541- DISPLAY ' ' . */
            _.Display($" ");

            /*" -541- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0050-00-INICIO-SECTION */
        private void R0050_00_INICIO_SECTION()
        {
            /*" -554- MOVE '0050' TO WNR-EXEC-SQL. */
            _.Move("0050", AUX_RELATORIO.WABEND.WNR_EXEC_SQL);

            /*" -556- OPEN OUTPUT BI6252B1. */
            BI6252B1.Open(REG_BI6252B);

            /*" -558- PERFORM R0100-00-SELECT-V0SISTEMA. */

            R0100_00_SELECT_V0SISTEMA_SECTION();

            /*" -560- DISPLAY ' DATA DO PROCESSAMENTO ...............  ' SISTEMAS-DATA-MOV-ABERTO. */
            _.Display($" DATA DO PROCESSAMENTO ...............  {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}");

            /*" -562- DISPLAY ' ' . */
            _.Display($" ");

            /*" -565- WRITE REG-BI6252B FROM LC00. */
            _.Move(AUX_RELATORIO.LC00.GetMoveValues(), REG_BI6252B);

            BI6252B1.Write(REG_BI6252B.GetMoveValues().ToString());

            /*" -566- SET WS-IPC TO 1. */
            WS_IPC.Value = 1;

            /*" -569- PERFORM R0110-00-LIMPA-COTACAO 300 TIMES. */

            for (int i = 0; i < 300; i++)
            {

                R0110_00_LIMPA_COTACAO_SECTION();

            }

            /*" -570- SET WS-IPC TO 1. */
            WS_IPC.Value = 1;

            /*" -571- MOVE SPACES TO WFIM-MOVIMENTO. */
            _.Move("", W.WFIM_MOVIMENTO);

            /*" -573- PERFORM R0120-00-DECLARE-COTACAO. */

            R0120_00_DECLARE_COTACAO_SECTION();

            /*" -577- PERFORM R0130-00-FETCH-COTACAO UNTIL WFIM-MOVIMENTO NOT EQUAL SPACES. */

            while (!(!W.WFIM_MOVIMENTO.IsEmpty()))
            {

                R0130_00_FETCH_COTACAO_SECTION();
            }

            /*" -578- DISPLAY ' ' . */
            _.Display($" ");

            /*" -579- DISPLAY 'LIDOS CODUNIMO - 28 - IPCA   ' LD-COTACAO. */
            _.Display($"LIDOS CODUNIMO - 28 - IPCA   {W.LD_COTACAO}");

            /*" -580- DISPLAY 'DESPREZA COTACAO             ' DP-COTACAO. */
            _.Display($"DESPREZA COTACAO             {W.DP_COTACAO}");

            /*" -583- DISPLAY ' ' . */
            _.Display($" ");

            /*" -583- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0050_99_SAIDA*/

        [StopWatch]
        /*" R0100-00-SELECT-V0SISTEMA-SECTION */
        private void R0100_00_SELECT_V0SISTEMA_SECTION()
        {
            /*" -596- MOVE '0100' TO WNR-EXEC-SQL. */
            _.Move("0100", AUX_RELATORIO.WABEND.WNR_EXEC_SQL);

            /*" -608- PERFORM R0100_00_SELECT_V0SISTEMA_DB_SELECT_1 */

            R0100_00_SELECT_V0SISTEMA_DB_SELECT_1();

            /*" -611- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -612- DISPLAY 'R0100-00 - PROBLEMAS NO SELECT(SISTEMAS)' */
                _.Display($"R0100-00 - PROBLEMAS NO SELECT(SISTEMAS)");

                /*" -615- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -617- MOVE WSHOST-DTINICOT TO WDATA-REL. */
            _.Move(WSHOST_DTINICOT, W.WDATA_REL);

            /*" -619- MOVE 01 TO WDAT-REL-DIA. */
            _.Move(01, W.FILLER_1.WDAT_REL_DIA);

            /*" -622- MOVE WDATA-REL TO WSHOST-DTINICOT. */
            _.Move(W.WDATA_REL, WSHOST_DTINICOT);

            /*" -623- MOVE SISTEMAS-DATA-MOV-ABERTO TO WDATA-REL. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, W.WDATA_REL);

        }

        [StopWatch]
        /*" R0100-00-SELECT-V0SISTEMA-DB-SELECT-1 */
        public void R0100_00_SELECT_V0SISTEMA_DB_SELECT_1()
        {
            /*" -608- EXEC SQL SELECT DATA_MOV_ABERTO , (DATA_MOV_ABERTO + 020 DAYS), (DATA_MOV_ABERTO - 001 MONTH), (DATA_MOV_ABERTO - 015 MONTH) INTO :SISTEMAS-DATA-MOV-ABERTO , :WSHOST-DTMOVABE20 , :WSHOST-DTTERCOT , :WSHOST-DTINICOT FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'CB' WITH UR END-EXEC. */

            var r0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1 = new R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1.Execute(r0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);
                _.Move(executed_1.WSHOST_DTMOVABE20, WSHOST_DTMOVABE20);
                _.Move(executed_1.WSHOST_DTTERCOT, WSHOST_DTTERCOT);
                _.Move(executed_1.WSHOST_DTINICOT, WSHOST_DTINICOT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/

        [StopWatch]
        /*" R0110-00-LIMPA-COTACAO-SECTION */
        private void R0110_00_LIMPA_COTACAO_SECTION()
        {
            /*" -635- MOVE '0110' TO WNR-EXEC-SQL. */
            _.Move("0110", AUX_RELATORIO.WABEND.WNR_EXEC_SQL);

            /*" -638- MOVE SPACES TO TB-DTINIVIG-IPCA(WS-IPC) TB-DTTERVIG-IPCA(WS-IPC). */
            _.Move("", TABELA_IPCA.WTIPC_OCORREIPC[WS_IPC].TB_DTINIVIG_IPCA, TABELA_IPCA.WTIPC_OCORREIPC[WS_IPC].TB_DTTERVIG_IPCA);

            /*" -642- MOVE ZEROS TO TB-VAL-IPCA(WS-IPC). */
            _.Move(0, TABELA_IPCA.WTIPC_OCORREIPC[WS_IPC].TB_VAL_IPCA);

            /*" -642- SET WS-IPC UP BY 1. */
            WS_IPC.Value += 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0110_99_SAIDA*/

        [StopWatch]
        /*" R0120-00-DECLARE-COTACAO-SECTION */
        private void R0120_00_DECLARE_COTACAO_SECTION()
        {
            /*" -663- MOVE '0120' TO WNR-EXEC-SQL. */
            _.Move("0120", AUX_RELATORIO.WABEND.WNR_EXEC_SQL);

            /*" -673- PERFORM R0120_00_DECLARE_COTACAO_DB_DECLARE_1 */

            R0120_00_DECLARE_COTACAO_DB_DECLARE_1();

            /*" -675- PERFORM R0120_00_DECLARE_COTACAO_DB_OPEN_1 */

            R0120_00_DECLARE_COTACAO_DB_OPEN_1();

            /*" -679- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -680- DISPLAY 'R0120-00 - PROBLEMAS DECLARE (MOEDACOT)   ' */
                _.Display($"R0120-00 - PROBLEMAS DECLARE (MOEDACOT)   ");

                /*" -680- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0120-00-DECLARE-COTACAO-DB-DECLARE-1 */
        public void R0120_00_DECLARE_COTACAO_DB_DECLARE_1()
        {
            /*" -673- EXEC SQL DECLARE V0COTACAO CURSOR WITH HOLD FOR SELECT DATA_INIVIGENCIA , DATA_TERVIGENCIA , VAL_VENDA FROM SEGUROS.MOEDAS_COTACAO WHERE COD_MOEDA = 28 AND DATA_INIVIGENCIA >= :WSHOST-DTINICOT ORDER BY DATA_INIVIGENCIA END-EXEC. */
            V0COTACAO = new BI6252B_V0COTACAO(true);
            string GetQuery_V0COTACAO()
            {
                var query = @$"SELECT DATA_INIVIGENCIA
							, 
							DATA_TERVIGENCIA
							, 
							VAL_VENDA 
							FROM SEGUROS.MOEDAS_COTACAO 
							WHERE COD_MOEDA = 28 
							AND DATA_INIVIGENCIA >= '{WSHOST_DTINICOT}' 
							ORDER BY DATA_INIVIGENCIA";

                return query;
            }
            V0COTACAO.GetQueryEvent += GetQuery_V0COTACAO;

        }

        [StopWatch]
        /*" R0120-00-DECLARE-COTACAO-DB-OPEN-1 */
        public void R0120_00_DECLARE_COTACAO_DB_OPEN_1()
        {
            /*" -675- EXEC SQL OPEN V0COTACAO END-EXEC. */

            V0COTACAO.Open();

        }

        [StopWatch]
        /*" R0300-00-DECLARE-MOVIMCOB-DB-DECLARE-1 */
        public void R0300_00_DECLARE_MOVIMCOB_DB_DECLARE_1()
        {
            /*" -825- EXEC SQL DECLARE V0MOVIMCOB CURSOR WITH HOLD FOR SELECT COD_EMPRESA , COD_MOVIMENTO , COD_BANCO , COD_AGENCIA , NUM_AVISO , NUM_FITA , DATA_MOVIMENTO , DATA_QUITACAO , NUM_TITULO , NUM_APOLICE , NUM_ENDOSSO , NUM_PARCELA , VAL_TITULO , VAL_CREDITO , SIT_REGISTRO , NOME_SEGURADO , NUM_NOSSO_TITULO , TIPO_MOVIMENTO , DATA_MOVIMENTO , (DATA_MOVIMENTO + 005 YEARS) , DATA_MOVIMENTO FROM SEGUROS.MOVIMENTO_COBRANCA WHERE SIT_REGISTRO = ' ' AND TIPO_MOVIMENTO = 'Y' FOR UPDATE OF NUM_TITULO , NUM_APOLICE , SIT_REGISTRO END-EXEC. */
            V0MOVIMCOB = new BI6252B_V0MOVIMCOB(false);
            string GetQuery_V0MOVIMCOB()
            {
                var query = @$"SELECT COD_EMPRESA
							, 
							COD_MOVIMENTO
							, 
							COD_BANCO
							, 
							COD_AGENCIA
							, 
							NUM_AVISO
							, 
							NUM_FITA
							, 
							DATA_MOVIMENTO
							, 
							DATA_QUITACAO
							, 
							NUM_TITULO
							, 
							NUM_APOLICE
							, 
							NUM_ENDOSSO
							, 
							NUM_PARCELA
							, 
							VAL_TITULO
							, 
							VAL_CREDITO
							, 
							SIT_REGISTRO
							, 
							NOME_SEGURADO
							, 
							NUM_NOSSO_TITULO
							, 
							TIPO_MOVIMENTO
							, 
							DATA_MOVIMENTO
							, 
							(DATA_MOVIMENTO + 005 YEARS)
							, 
							DATA_MOVIMENTO 
							FROM SEGUROS.MOVIMENTO_COBRANCA 
							WHERE SIT_REGISTRO = ' ' 
							AND TIPO_MOVIMENTO = 'Y'";

                return query;
            }
            V0MOVIMCOB.GetQueryEvent += GetQuery_V0MOVIMCOB;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0120_99_SAIDA*/

        [StopWatch]
        /*" R0130-00-FETCH-COTACAO-SECTION */
        private void R0130_00_FETCH_COTACAO_SECTION()
        {
            /*" -693- MOVE '0130' TO WNR-EXEC-SQL. */
            _.Move("0130", AUX_RELATORIO.WABEND.WNR_EXEC_SQL);

            /*" -697- PERFORM R0130_00_FETCH_COTACAO_DB_FETCH_1 */

            R0130_00_FETCH_COTACAO_DB_FETCH_1();

            /*" -701- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -701- PERFORM R0130_00_FETCH_COTACAO_DB_CLOSE_1 */

                R0130_00_FETCH_COTACAO_DB_CLOSE_1();

                /*" -703- MOVE 'S' TO WFIM-MOVIMENTO */
                _.Move("S", W.WFIM_MOVIMENTO);

                /*" -705- MOVE SISTEMAS-DATA-MOV-ABERTO TO MOEDACOT-DATA-INIVIGENCIA */
                _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, MOEDACOT.DCLMOEDAS_COTACAO.MOEDACOT_DATA_INIVIGENCIA);

                /*" -707- MOVE ZEROS TO MOEDACOT-VAL-VENDA */
                _.Move(0, MOEDACOT.DCLMOEDAS_COTACAO.MOEDACOT_VAL_VENDA);

                /*" -710- GO TO R0130-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0130_99_SAIDA*/ //GOTO
                return;
            }


            /*" -711- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -712- DISPLAY 'R0130-00 - PROBLEMAS FETCH   (MOEDACOT)   ' */
                _.Display($"R0130-00 - PROBLEMAS FETCH   (MOEDACOT)   ");

                /*" -713- DISPLAY 'CODUNIMO = 28    ' WSHOST-DTINICOT */
                _.Display($"CODUNIMO = 28    {WSHOST_DTINICOT}");

                /*" -716- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -719- ADD 1 TO LD-COTACAO. */
            W.LD_COTACAO.Value = W.LD_COTACAO + 1;

            /*" -720- IF MOEDACOT-VAL-VENDA NOT GREATER ZEROS */

            if (MOEDACOT.DCLMOEDAS_COTACAO.MOEDACOT_VAL_VENDA <= 00)
            {

                /*" -721- ADD 1 TO DP-COTACAO */
                W.DP_COTACAO.Value = W.DP_COTACAO + 1;

                /*" -724- GO TO R0130-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0130_99_SAIDA*/ //GOTO
                return;
            }


            /*" -726- SET WS-IND TO WS-IPC. */
            W.WS_IND.Value = WS_IPC;

            /*" -727- IF WS-IND GREATER 300 */

            if (W.WS_IND > 300)
            {

                /*" -728- DISPLAY '*** BI6252B ESTOURO TAB. INTERNA TB-IPCA ' */
                _.Display($"*** BI6252B ESTOURO TAB. INTERNA TB-IPCA ");

                /*" -731- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -733- MOVE MOEDACOT-DATA-INIVIGENCIA TO TB-DTINIVIG-IPCA(WS-IPC). */
            _.Move(MOEDACOT.DCLMOEDAS_COTACAO.MOEDACOT_DATA_INIVIGENCIA, TABELA_IPCA.WTIPC_OCORREIPC[WS_IPC].TB_DTINIVIG_IPCA);

            /*" -735- MOVE MOEDACOT-DATA-TERVIGENCIA TO TB-DTTERVIG-IPCA(WS-IPC). */
            _.Move(MOEDACOT.DCLMOEDAS_COTACAO.MOEDACOT_DATA_TERVIGENCIA, TABELA_IPCA.WTIPC_OCORREIPC[WS_IPC].TB_DTTERVIG_IPCA);

            /*" -739- MOVE MOEDACOT-VAL-VENDA TO TB-VAL-IPCA(WS-IPC). */
            _.Move(MOEDACOT.DCLMOEDAS_COTACAO.MOEDACOT_VAL_VENDA, TABELA_IPCA.WTIPC_OCORREIPC[WS_IPC].TB_VAL_IPCA);

            /*" -739- SET WS-IPC UP BY 1. */
            WS_IPC.Value += 1;

        }

        [StopWatch]
        /*" R0130-00-FETCH-COTACAO-DB-FETCH-1 */
        public void R0130_00_FETCH_COTACAO_DB_FETCH_1()
        {
            /*" -697- EXEC SQL FETCH V0COTACAO INTO :MOEDACOT-DATA-INIVIGENCIA , :MOEDACOT-DATA-TERVIGENCIA , :MOEDACOT-VAL-VENDA END-EXEC. */

            if (V0COTACAO.Fetch())
            {
                _.Move(V0COTACAO.MOEDACOT_DATA_INIVIGENCIA, MOEDACOT.DCLMOEDAS_COTACAO.MOEDACOT_DATA_INIVIGENCIA);
                _.Move(V0COTACAO.MOEDACOT_DATA_TERVIGENCIA, MOEDACOT.DCLMOEDAS_COTACAO.MOEDACOT_DATA_TERVIGENCIA);
                _.Move(V0COTACAO.MOEDACOT_VAL_VENDA, MOEDACOT.DCLMOEDAS_COTACAO.MOEDACOT_VAL_VENDA);
            }

        }

        [StopWatch]
        /*" R0130-00-FETCH-COTACAO-DB-CLOSE-1 */
        public void R0130_00_FETCH_COTACAO_DB_CLOSE_1()
        {
            /*" -701- EXEC SQL CLOSE V0COTACAO END-EXEC */

            V0COTACAO.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0130_99_SAIDA*/

        [StopWatch]
        /*" R0200-00-PROCESSA-SECTION */
        private void R0200_00_PROCESSA_SECTION()
        {
            /*" -752- MOVE '0200' TO WNR-EXEC-SQL. */
            _.Move("0200", AUX_RELATORIO.WABEND.WNR_EXEC_SQL);

            /*" -753- MOVE SPACES TO WFIM-MOVIMENTO. */
            _.Move("", W.WFIM_MOVIMENTO);

            /*" -755- PERFORM R0300-00-DECLARE-MOVIMCOB. */

            R0300_00_DECLARE_MOVIMCOB_SECTION();

            /*" -757- PERFORM R0310-00-FETCH-MOVIMCOB. */

            R0310_00_FETCH_MOVIMCOB_SECTION();

            /*" -761- PERFORM R0350-00-PROCESSA-MOVIMCOB UNTIL WFIM-MOVIMENTO NOT EQUAL SPACES. */

            while (!(!W.WFIM_MOVIMENTO.IsEmpty()))
            {

                R0350_00_PROCESSA_MOVIMCOB_SECTION();
            }

            /*" -762- DISPLAY ' ' . */
            _.Display($" ");

            /*" -763- DISPLAY 'LIDOS MOVIMCOB ............. ' LD-MOVIMCOB. */
            _.Display($"LIDOS MOVIMCOB ............. {W.LD_MOVIMCOB}");

            /*" -764- DISPLAY 'DESPREZA CONVENIO .......... ' DP-CONVENIO. */
            _.Display($"DESPREZA CONVENIO .......... {W.DP_CONVENIO}");

            /*" -765- DISPLAY 'DESPREZA DATA .............. ' DP-DATA. */
            _.Display($"DESPREZA DATA .............. {W.DP_DATA}");

            /*" -766- DISPLAY 'SEM   PROPOSTA ............. ' NT-BILHETE. */
            _.Display($"SEM   PROPOSTA ............. {W.NT_BILHETE}");

            /*" -767- DISPLAY 'REGISTROS REJEITADOS ....... ' DP-PARCELA. */
            _.Display($"REGISTROS REJEITADOS ....... {W.DP_PARCELA}");

            /*" -768- DISPLAY 'REGISTROS COM ERRO ......... ' AC-ERRO. */
            _.Display($"REGISTROS COM ERRO ......... {W.AC_ERRO}");

            /*" -769- DISPLAY 'LIBERA DEMAIS PARCELAS ..... ' LB-PARCELA. */
            _.Display($"LIBERA DEMAIS PARCELAS ..... {W.LB_PARCELA}");

            /*" -770- DISPLAY 'ALTERA MOVIMENTO COBRANCA .. ' UP-PROPOSTA. */
            _.Display($"ALTERA MOVIMENTO COBRANCA .. {W.UP_PROPOSTA}");

            /*" -771- DISPLAY ' ' . */
            _.Display($" ");

            /*" -772- DISPLAY 'TRATA RELACIONAMENTO ....... ' TT-RELACAO. */
            _.Display($"TRATA RELACIONAMENTO ....... {W.TT_RELACAO}");

            /*" -773- DISPLAY 'INCLUI PESSOA .............. ' IN-PESSOA. */
            _.Display($"INCLUI PESSOA .............. {W.IN_PESSOA}");

            /*" -774- DISPLAY 'INCLUI RELACIONAMENTO ...... ' IN-RTPRELAC. */
            _.Display($"INCLUI RELACIONAMENTO ...... {W.IN_RTPRELAC}");

            /*" -775- DISPLAY 'INCLUI IDENTIFICACAO ....... ' IN-IDENTREL. */
            _.Display($"INCLUI IDENTIFICACAO ....... {W.IN_IDENTREL}");

            /*" -776- DISPLAY ' ' . */
            _.Display($" ");

            /*" -777- DISPLAY 'INCLUI MOVDEBCE ............ ' AC-MOVDEBCE. */
            _.Display($"INCLUI MOVDEBCE ............ {W.AC_MOVDEBCE}");

            /*" -778- DISPLAY 'ALTERA BILHETE ............. ' UP-BILHETE. */
            _.Display($"ALTERA BILHETE ............. {W.UP_BILHETE}");

            /*" -779- DISPLAY ' ' . */
            _.Display($" ");

            /*" -780- DISPLAY 'ALTERA PROPOSTA FIDELIZ .... ' UP-PROPOFID. */
            _.Display($"ALTERA PROPOSTA FIDELIZ .... {W.UP_PROPOFID}");

            /*" -781- DISPLAY 'INCLUI PROPOSTA FIDELIZ .... ' IN-PROPOFID. */
            _.Display($"INCLUI PROPOSTA FIDELIZ .... {W.IN_PROPOFID}");

            /*" -782- DISPLAY 'GRAVA INCONSISTENCIAS ...... ' GV-SAIDA */
            _.Display($"GRAVA INCONSISTENCIAS ...... {W.GV_SAIDA}");

            /*" -782- DISPLAY ' ' . */
            _.Display($" ");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_99_SAIDA*/

        [StopWatch]
        /*" R0300-00-DECLARE-MOVIMCOB-SECTION */
        private void R0300_00_DECLARE_MOVIMCOB_SECTION()
        {
            /*" -795- MOVE '0300' TO WNR-EXEC-SQL. */
            _.Move("0300", AUX_RELATORIO.WABEND.WNR_EXEC_SQL);

            /*" -825- PERFORM R0300_00_DECLARE_MOVIMCOB_DB_DECLARE_1 */

            R0300_00_DECLARE_MOVIMCOB_DB_DECLARE_1();

            /*" -827- PERFORM R0300_00_DECLARE_MOVIMCOB_DB_OPEN_1 */

            R0300_00_DECLARE_MOVIMCOB_DB_OPEN_1();

            /*" -831- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -832- DISPLAY 'R0300-00 - PROBLEMAS DECLARE (MOVIMCOB)   ' */
                _.Display($"R0300-00 - PROBLEMAS DECLARE (MOVIMCOB)   ");

                /*" -832- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0300-00-DECLARE-MOVIMCOB-DB-OPEN-1 */
        public void R0300_00_DECLARE_MOVIMCOB_DB_OPEN_1()
        {
            /*" -827- EXEC SQL OPEN V0MOVIMCOB END-EXEC. */

            V0MOVIMCOB.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_99_SAIDA*/

        [StopWatch]
        /*" R0310-00-FETCH-MOVIMCOB-SECTION */
        private void R0310_00_FETCH_MOVIMCOB_SECTION()
        {
            /*" -845- MOVE '0310' TO WNR-EXEC-SQL. */
            _.Move("0310", AUX_RELATORIO.WABEND.WNR_EXEC_SQL);

            /*" -867- PERFORM R0310_00_FETCH_MOVIMCOB_DB_FETCH_1 */

            R0310_00_FETCH_MOVIMCOB_DB_FETCH_1();

            /*" -871- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -871- PERFORM R0310_00_FETCH_MOVIMCOB_DB_CLOSE_1 */

                R0310_00_FETCH_MOVIMCOB_DB_CLOSE_1();

                /*" -873- MOVE 'S' TO WFIM-MOVIMENTO */
                _.Move("S", W.WFIM_MOVIMENTO);

                /*" -875- GO TO R0310-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0310_99_SAIDA*/ //GOTO
                return;
            }


            /*" -876- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -877- DISPLAY 'R0310-00 - PROBLEMAS FETCH   (MOVIMCOB)   ' */
                _.Display($"R0310-00 - PROBLEMAS FETCH   (MOVIMCOB)   ");

                /*" -878- DISPLAY 'SIT-REGISTRO    =' MOVIMCOB-SIT-REGISTRO */
                _.Display($"SIT-REGISTRO    ={MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_SIT_REGISTRO}");

                /*" -879- DISPLAY 'COD-BANCO       =' MOVIMCOB-COD-BANCO */
                _.Display($"COD-BANCO       ={MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_BANCO}");

                /*" -880- DISPLAY 'COD-AGENCIA     =' MOVIMCOB-COD-AGENCIA */
                _.Display($"COD-AGENCIA     ={MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_AGENCIA}");

                /*" -881- DISPLAY 'NUM-AVISO       =' MOVIMCOB-NUM-AVISO */
                _.Display($"NUM-AVISO       ={MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_AVISO}");

                /*" -882- DISPLAY 'NUM-NOSSO-TITULO=' MOVIMCOB-NUM-NOSSO-TITULO */
                _.Display($"NUM-NOSSO-TITULO={MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_NOSSO_TITULO}");

                /*" -883- DISPLAY 'COD-MOVIMENTO   =' MOVIMCOB-COD-MOVIMENTO */
                _.Display($"COD-MOVIMENTO   ={MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_MOVIMENTO}");

                /*" -884- DISPLAY 'NOME-SEGURADO   =' MOVIMCOB-NOME-SEGURADO */
                _.Display($"NOME-SEGURADO   ={MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NOME_SEGURADO}");

                /*" -887- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -887- ADD 1 TO LD-MOVIMCOB. */
            W.LD_MOVIMCOB.Value = W.LD_MOVIMCOB + 1;

        }

        [StopWatch]
        /*" R0310-00-FETCH-MOVIMCOB-DB-FETCH-1 */
        public void R0310_00_FETCH_MOVIMCOB_DB_FETCH_1()
        {
            /*" -867- EXEC SQL FETCH V0MOVIMCOB INTO :MOVIMCOB-COD-EMPRESA , :MOVIMCOB-COD-MOVIMENTO , :MOVIMCOB-COD-BANCO , :MOVIMCOB-COD-AGENCIA , :MOVIMCOB-NUM-AVISO , :MOVIMCOB-NUM-FITA , :MOVIMCOB-DATA-MOVIMENTO , :MOVIMCOB-DATA-QUITACAO , :MOVIMCOB-NUM-TITULO , :MOVIMCOB-NUM-APOLICE , :MOVIMCOB-NUM-ENDOSSO , :MOVIMCOB-NUM-PARCELA , :MOVIMCOB-VAL-TITULO , :MOVIMCOB-VAL-CREDITO , :MOVIMCOB-SIT-REGISTRO , :MOVIMCOB-NOME-SEGURADO , :MOVIMCOB-NUM-NOSSO-TITULO , :MOVIMCOB-TIPO-MOVIMENTO , :WSGER00-DATA-INIVIGENCIA , :WSGER00-DATA-TERVIGENCIA , :WSGER00-DATA-VENCIMENTO END-EXEC. */

            if (V0MOVIMCOB.Fetch())
            {
                _.Move(V0MOVIMCOB.MOVIMCOB_COD_EMPRESA, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_EMPRESA);
                _.Move(V0MOVIMCOB.MOVIMCOB_COD_MOVIMENTO, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_MOVIMENTO);
                _.Move(V0MOVIMCOB.MOVIMCOB_COD_BANCO, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_BANCO);
                _.Move(V0MOVIMCOB.MOVIMCOB_COD_AGENCIA, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_AGENCIA);
                _.Move(V0MOVIMCOB.MOVIMCOB_NUM_AVISO, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_AVISO);
                _.Move(V0MOVIMCOB.MOVIMCOB_NUM_FITA, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_FITA);
                _.Move(V0MOVIMCOB.MOVIMCOB_DATA_MOVIMENTO, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_DATA_MOVIMENTO);
                _.Move(V0MOVIMCOB.MOVIMCOB_DATA_QUITACAO, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_DATA_QUITACAO);
                _.Move(V0MOVIMCOB.MOVIMCOB_NUM_TITULO, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_TITULO);
                _.Move(V0MOVIMCOB.MOVIMCOB_NUM_APOLICE, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_APOLICE);
                _.Move(V0MOVIMCOB.MOVIMCOB_NUM_ENDOSSO, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_ENDOSSO);
                _.Move(V0MOVIMCOB.MOVIMCOB_NUM_PARCELA, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_PARCELA);
                _.Move(V0MOVIMCOB.MOVIMCOB_VAL_TITULO, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_VAL_TITULO);
                _.Move(V0MOVIMCOB.MOVIMCOB_VAL_CREDITO, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_VAL_CREDITO);
                _.Move(V0MOVIMCOB.MOVIMCOB_SIT_REGISTRO, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_SIT_REGISTRO);
                _.Move(V0MOVIMCOB.MOVIMCOB_NOME_SEGURADO, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NOME_SEGURADO);
                _.Move(V0MOVIMCOB.MOVIMCOB_NUM_NOSSO_TITULO, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_NOSSO_TITULO);
                _.Move(V0MOVIMCOB.MOVIMCOB_TIPO_MOVIMENTO, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_TIPO_MOVIMENTO);
                _.Move(V0MOVIMCOB.WSGER00_DATA_INIVIGENCIA, WSGER00_DATA_INIVIGENCIA);
                _.Move(V0MOVIMCOB.WSGER00_DATA_TERVIGENCIA, WSGER00_DATA_TERVIGENCIA);
                _.Move(V0MOVIMCOB.WSGER00_DATA_VENCIMENTO, WSGER00_DATA_VENCIMENTO);
            }

        }

        [StopWatch]
        /*" R0310-00-FETCH-MOVIMCOB-DB-CLOSE-1 */
        public void R0310_00_FETCH_MOVIMCOB_DB_CLOSE_1()
        {
            /*" -871- EXEC SQL CLOSE V0MOVIMCOB END-EXEC */

            V0MOVIMCOB.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0310_99_SAIDA*/

        [StopWatch]
        /*" R0350-00-PROCESSA-MOVIMCOB-SECTION */
        private void R0350_00_PROCESSA_MOVIMCOB_SECTION()
        {
            /*" -900- MOVE '0350' TO WNR-EXEC-SQL. */
            _.Move("0350", AUX_RELATORIO.WABEND.WNR_EXEC_SQL);

            /*" -915- MOVE ZEROS TO LD01-CONVENIO LD01-PROPOSTA LD01-BILHETE LD01-NSAS LD01-VALOR LD01-CODPRODU LD01-APOLICE LD01-ENDOSSO LD01-PARCELA LD01-OPCAO LD01-PRM-TOTAL LD01-IMP-IPCA LD01-PRM-IPCA LD01-IND-IPCA. */
            _.Move(0, AUX_RELATORIO.LD01.LD01_CONVENIO, AUX_RELATORIO.LD01.LD01_PROPOSTA, AUX_RELATORIO.LD01.LD01_BILHETE, AUX_RELATORIO.LD01.LD01_NSAS, AUX_RELATORIO.LD01.LD01_VALOR, AUX_RELATORIO.LD01.LD01_CODPRODU, AUX_RELATORIO.LD01.LD01_APOLICE, AUX_RELATORIO.LD01.LD01_ENDOSSO, AUX_RELATORIO.LD01.LD01_PARCELA, AUX_RELATORIO.LD01.LD01_OPCAO, AUX_RELATORIO.LD01.LD01_PRM_TOTAL, AUX_RELATORIO.LD01.LD01_IMP_IPCA, AUX_RELATORIO.LD01.LD01_PRM_IPCA, AUX_RELATORIO.LD01.LD01_IND_IPCA);

            /*" -924- MOVE SPACES TO LD01-DTPAGTO LD01-DTCREDITO LD01-MENSAGEM. */
            _.Move("", AUX_RELATORIO.LD01.LD01_DTPAGTO, AUX_RELATORIO.LD01.LD01_DTCREDITO, AUX_RELATORIO.LD01.LD01_MENSAGEM);

            /*" -925- IF MOVIMCOB-NUM-AVISO NOT EQUAL 21000 */

            if (MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_AVISO != 21000)
            {

                /*" -926- ADD 1 TO DP-CONVENIO */
                W.DP_CONVENIO.Value = W.DP_CONVENIO + 1;

                /*" -929- GO TO R0350-90-LEITURA. */

                R0350_90_LEITURA(); //GOTO
                return;
            }


            /*" -936- MOVE MOVIMCOB-NOME-SEGURADO TO MVPAY-NOME. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NOME_SEGURADO, AUX_RELATORIO.MVPAY_NOME);

            /*" -938- IF MOVIMCOB-DATA-MOVIMENTO GREATER SISTEMAS-DATA-MOV-ABERTO */

            if (MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_DATA_MOVIMENTO > SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO)
            {

                /*" -939- ADD 1 TO DP-DATA */
                W.DP_DATA.Value = W.DP_DATA + 1;

                /*" -946- GO TO R0350-90-LEITURA. */

                R0350_90_LEITURA(); //GOTO
                return;
            }


            /*" -947- MOVE 'S' TO WTEM-PROPOSTA. */
            _.Move("S", W.WTEM_PROPOSTA);

            /*" -949- PERFORM R0360-00-SELECT-BILHETE. */

            R0360_00_SELECT_BILHETE_SECTION();

            /*" -950- IF WTEM-PROPOSTA NOT EQUAL 'S' */

            if (W.WTEM_PROPOSTA != "S")
            {

                /*" -951- PERFORM R9000-00-GRAVA-ARQUIVO */

                R9000_00_GRAVA_ARQUIVO_SECTION();

                /*" -956- GO TO R0350-90-LEITURA. */

                R0350_90_LEITURA(); //GOTO
                return;
            }


            /*" -965- IF BILHETE-NUM-BILHETE EQUAL 95414536254 OR 95414459888 OR 95414969428 OR 95415313089 OR 95416170575 OR 95417985556 OR 95415545346 OR 95419168270 OR 95415238591 */

            if (BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE.In("95414536254", "95414459888", "95414969428", "95415313089", "95416170575", "95417985556", "95415545346", "95419168270", "95415238591"))
            {

                /*" -966- PERFORM R8000-00-CANCELA-BILHETE */

                R8000_00_CANCELA_BILHETE_SECTION();

                /*" -973- GO TO R0350-90-LEITURA. */

                R0350_90_LEITURA(); //GOTO
                return;
            }


            /*" -974- IF CLIENTES-NOME-RAZAO EQUAL SPACES */

            if (CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO.IsEmpty())
            {

                /*" -975- ADD 1 TO AC-ERRO */
                W.AC_ERRO.Value = W.AC_ERRO + 1;

                /*" -977- MOVE 'NOME CLIENTE NAO INFORMADO              ' TO LD01-MENSAGEM */
                _.Move("NOME CLIENTE NAO INFORMADO              ", AUX_RELATORIO.LD01.LD01_MENSAGEM);

                /*" -978- PERFORM R9000-00-GRAVA-ARQUIVO */

                R9000_00_GRAVA_ARQUIVO_SECTION();

                /*" -980- GO TO R0350-90-LEITURA. */

                R0350_90_LEITURA(); //GOTO
                return;
            }


            /*" -981- IF CLIENTES-TIPO-PESSOA NOT EQUAL 'F' */

            if (CLIENTES.DCLCLIENTES.CLIENTES_TIPO_PESSOA != "F")
            {

                /*" -982- ADD 1 TO AC-ERRO */
                W.AC_ERRO.Value = W.AC_ERRO + 1;

                /*" -984- MOVE 'CLIENTE DIFERENTE PESSOA FISICA         ' TO LD01-MENSAGEM */
                _.Move("CLIENTE DIFERENTE PESSOA FISICA         ", AUX_RELATORIO.LD01.LD01_MENSAGEM);

                /*" -985- PERFORM R9000-00-GRAVA-ARQUIVO */

                R9000_00_GRAVA_ARQUIVO_SECTION();

                /*" -987- GO TO R0350-90-LEITURA. */

                R0350_90_LEITURA(); //GOTO
                return;
            }


            /*" -988- IF CLIENTES-DATA-NASCIMENTO EQUAL SPACES */

            if (CLIENTES.DCLCLIENTES.CLIENTES_DATA_NASCIMENTO.IsEmpty())
            {

                /*" -989- ADD 1 TO AC-ERRO */
                W.AC_ERRO.Value = W.AC_ERRO + 1;

                /*" -991- MOVE 'DATA NASCIMENTO NAO INFORMADA           ' TO LD01-MENSAGEM */
                _.Move("DATA NASCIMENTO NAO INFORMADA           ", AUX_RELATORIO.LD01.LD01_MENSAGEM);

                /*" -992- PERFORM R9000-00-GRAVA-ARQUIVO */

                R9000_00_GRAVA_ARQUIVO_SECTION();

                /*" -998- GO TO R0350-90-LEITURA. */

                R0350_90_LEITURA(); //GOTO
                return;
            }


            /*" -1005- PERFORM R0500-00-AJUSTA-FILIAL. */

            R0500_00_AJUSTA_FILIAL_SECTION();

            /*" -1011- PERFORM R1000-00-TRATA-RELACAO. */

            R1000_00_TRATA_RELACAO_SECTION();

            /*" -1013- MOVE 'S' TO WTEM-COBERTURA. */
            _.Move("S", W.WTEM_COBERTURA);

            /*" -1015- PERFORM R1700-00-SELECT-BILHECOB. */

            R1700_00_SELECT_BILHECOB_SECTION();

            /*" -1016- IF WTEM-COBERTURA NOT EQUAL 'S' */

            if (W.WTEM_COBERTURA != "S")
            {

                /*" -1017- PERFORM R9000-00-GRAVA-ARQUIVO */

                R9000_00_GRAVA_ARQUIVO_SECTION();

                /*" -1020- GO TO R0350-90-LEITURA. */

                R0350_90_LEITURA(); //GOTO
                return;
            }


            /*" -1022- PERFORM R1750-00-VERIFICA-VIGENCIA. */

            R1750_00_VERIFICA_VIGENCIA_SECTION();

            /*" -1024- IF WSHOST-DTMOVABE20 GREATER WSGER15-DATA-VENCIMENTO */

            if (WSHOST_DTMOVABE20 > WSGER15_DATA_VENCIMENTO)
            {

                /*" -1026- MOVE 'ADESAO COM QUINZE MESES DE ATRASO       ' TO LD01-MENSAGEM */
                _.Move("ADESAO COM QUINZE MESES DE ATRASO       ", AUX_RELATORIO.LD01.LD01_MENSAGEM);

                /*" -1027- PERFORM R9000-00-GRAVA-ARQUIVO */

                R9000_00_GRAVA_ARQUIVO_SECTION();

                /*" -1033- GO TO R0350-90-LEITURA. */

                R0350_90_LEITURA(); //GOTO
                return;
            }


            /*" -1039- PERFORM R2500-00-EMITE-APOLICE. */

            R2500_00_EMITE_APOLICE_SECTION();

            /*" -1042- MOVE '9' TO BILHETE-SITUACAO. */
            _.Move("9", BILHETE.DCLBILHETE.BILHETE_SITUACAO);

            /*" -1050- PERFORM R8500-00-UPDATE-V0BILHETE. */

            R8500_00_UPDATE_V0BILHETE_SECTION();

            /*" -1051- ADD 1 TO LB-PARCELA. */
            W.LB_PARCELA.Value = W.LB_PARCELA + 1;

            /*" -1054- MOVE '0' TO MOVIMCOB-SIT-REGISTRO. */
            _.Move("0", MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_SIT_REGISTRO);

            /*" -1054- PERFORM R8900-00-UPDATE-V0MOVICOB. */

            R8900_00_UPDATE_V0MOVICOB_SECTION();

            /*" -0- FLUXCONTROL_PERFORM R0350_90_LEITURA */

            R0350_90_LEITURA();

        }

        [StopWatch]
        /*" R0350-90-LEITURA */
        private void R0350_90_LEITURA(bool isPerform = false)
        {
            /*" -1059- PERFORM R0310-00-FETCH-MOVIMCOB. */

            R0310_00_FETCH_MOVIMCOB_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0350_99_SAIDA*/

        [StopWatch]
        /*" R0360-00-SELECT-BILHETE-SECTION */
        private void R0360_00_SELECT_BILHETE_SECTION()
        {
            /*" -1071- MOVE '0360' TO WNR-EXEC-SQL. */
            _.Move("0360", AUX_RELATORIO.WABEND.WNR_EXEC_SQL);

            /*" -1074- MOVE MOVIMCOB-NUM-NOSSO-TITULO TO CONVERSI-NUM-PROPOSTA-SIVPF. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_NOSSO_TITULO, CONVERSI.DCLCONVERSAO_SICOB.CONVERSI_NUM_PROPOSTA_SIVPF);

            /*" -1160- PERFORM R0360_00_SELECT_BILHETE_DB_SELECT_1 */

            R0360_00_SELECT_BILHETE_DB_SELECT_1();

            /*" -1163- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1166- MOVE ZEROS TO CONVERSI-COD-PRODUTO-SIVPF BILHETE-OPC-COBERTURA */
                _.Move(0, CONVERSI.DCLCONVERSAO_SICOB.CONVERSI_COD_PRODUTO_SIVPF, BILHETE.DCLBILHETE.BILHETE_OPC_COBERTURA);

                /*" -1168- MOVE 'REGISTRO SEM PROPOSTA                   ' TO LD01-MENSAGEM */
                _.Move("REGISTRO SEM PROPOSTA                   ", AUX_RELATORIO.LD01.LD01_MENSAGEM);

                /*" -1169- MOVE 'N' TO WTEM-PROPOSTA */
                _.Move("N", W.WTEM_PROPOSTA);

                /*" -1170- ADD 1 TO NT-BILHETE */
                W.NT_BILHETE.Value = W.NT_BILHETE + 1;

                /*" -1173- GO TO R0360-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0360_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1174- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1175- DISPLAY 'R0360-00 - PROBLEMAS SELECT  (BILHETE )   ' */
                _.Display($"R0360-00 - PROBLEMAS SELECT  (BILHETE )   ");

                /*" -1176- DISPLAY 'SIT-REGISTRO    = ' MOVIMCOB-SIT-REGISTRO */
                _.Display($"SIT-REGISTRO    = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_SIT_REGISTRO}");

                /*" -1177- DISPLAY 'COD-BANCO       = ' MOVIMCOB-COD-BANCO */
                _.Display($"COD-BANCO       = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_BANCO}");

                /*" -1178- DISPLAY 'COD-AGENCIA     = ' MOVIMCOB-COD-AGENCIA */
                _.Display($"COD-AGENCIA     = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_AGENCIA}");

                /*" -1179- DISPLAY 'NUM-AVISO       = ' MOVIMCOB-NUM-AVISO */
                _.Display($"NUM-AVISO       = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_AVISO}");

                /*" -1180- DISPLAY 'NUM-FITA        = ' MOVIMCOB-NUM-FITA */
                _.Display($"NUM-FITA        = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_FITA}");

                /*" -1181- DISPLAY 'NUM-NOSSO-TITULO= ' MOVIMCOB-NUM-NOSSO-TITULO */
                _.Display($"NUM-NOSSO-TITULO= {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_NOSSO_TITULO}");

                /*" -1182- DISPLAY 'NUM-APOLICE     = ' MOVIMCOB-NUM-APOLICE */
                _.Display($"NUM-APOLICE     = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_APOLICE}");

                /*" -1183- DISPLAY 'NUM-ENDOSSO     = ' MOVIMCOB-NUM-ENDOSSO */
                _.Display($"NUM-ENDOSSO     = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_ENDOSSO}");

                /*" -1184- DISPLAY 'NUM-PARCELA     = ' MOVIMCOB-NUM-PARCELA */
                _.Display($"NUM-PARCELA     = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_PARCELA}");

                /*" -1185- DISPLAY 'COD-MOVIMENTO   = ' MOVIMCOB-COD-MOVIMENTO */
                _.Display($"COD-MOVIMENTO   = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_MOVIMENTO}");

                /*" -1186- DISPLAY 'NOME-SEGURADO   = ' MOVIMCOB-NOME-SEGURADO */
                _.Display($"NOME-SEGURADO   = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NOME_SEGURADO}");

                /*" -1189- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1190- IF VIND-DTNASC LESS ZEROS */

            if (VIND_DTNASC < 00)
            {

                /*" -1193- MOVE SPACES TO CLIENTES-DATA-NASCIMENTO. */
                _.Move("", CLIENTES.DCLCLIENTES.CLIENTES_DATA_NASCIMENTO);
            }


            /*" -1194- IF VIND-SEXO LESS ZEROS */

            if (VIND_SEXO < 00)
            {

                /*" -1197- MOVE SPACES TO CLIENTES-IDE-SEXO. */
                _.Move("", CLIENTES.DCLCLIENTES.CLIENTES_IDE_SEXO);
            }


            /*" -1198- IF VIND-ESTCIVIL LESS ZEROS */

            if (VIND_ESTCIVIL < 00)
            {

                /*" -1202- MOVE SPACES TO CLIENTES-ESTADO-CIVIL. */
                _.Move("", CLIENTES.DCLCLIENTES.CLIENTES_ESTADO_CIVIL);
            }


            /*" -1203- IF BILHETE-SITUACAO EQUAL '9' */

            if (BILHETE.DCLBILHETE.BILHETE_SITUACAO == "9")
            {

                /*" -1205- MOVE 'BILHETE EMITIDO                         ' TO LD01-MENSAGEM */
                _.Move("BILHETE EMITIDO                         ", AUX_RELATORIO.LD01.LD01_MENSAGEM);

                /*" -1206- MOVE 'N' TO WTEM-PROPOSTA */
                _.Move("N", W.WTEM_PROPOSTA);

                /*" -1207- ADD 1 TO NT-BILHETE */
                W.NT_BILHETE.Value = W.NT_BILHETE + 1;

                /*" -1208- ELSE */
            }
            else
            {


                /*" -1209- IF BILHETE-SITUACAO EQUAL '8' */

                if (BILHETE.DCLBILHETE.BILHETE_SITUACAO == "8")
                {

                    /*" -1211- MOVE 'BILHETE CANCELADO                       ' TO LD01-MENSAGEM */
                    _.Move("BILHETE CANCELADO                       ", AUX_RELATORIO.LD01.LD01_MENSAGEM);

                    /*" -1212- MOVE 'N' TO WTEM-PROPOSTA */
                    _.Move("N", W.WTEM_PROPOSTA);

                    /*" -1213- ADD 1 TO NT-BILHETE */
                    W.NT_BILHETE.Value = W.NT_BILHETE + 1;

                    /*" -1214- ELSE */
                }
                else
                {


                    /*" -1215- IF BILHETE-SITUACAO NOT EQUAL 'L' */

                    if (BILHETE.DCLBILHETE.BILHETE_SITUACAO != "L")
                    {

                        /*" -1217- MOVE 'BILHETE COM SITUACAO DIVERGENTE         ' TO LD01-MENSAGEM */
                        _.Move("BILHETE COM SITUACAO DIVERGENTE         ", AUX_RELATORIO.LD01.LD01_MENSAGEM);

                        /*" -1218- MOVE 'N' TO WTEM-PROPOSTA */
                        _.Move("N", W.WTEM_PROPOSTA);

                        /*" -1218- ADD 1 TO NT-BILHETE. */
                        W.NT_BILHETE.Value = W.NT_BILHETE + 1;
                    }

                }

            }


        }

        [StopWatch]
        /*" R0360-00-SELECT-BILHETE-DB-SELECT-1 */
        public void R0360_00_SELECT_BILHETE_DB_SELECT_1()
        {
            /*" -1160- EXEC SQL SELECT A.NUM_PROPOSTA_SIVPF , A.COD_PRODUTO_SIVPF , B.NUM_BILHETE , B.NUM_APOLICE , B.FONTE , B.AGE_COBRANCA , B.NUM_MATRICULA , B.COD_AGENCIA , B.OPERACAO_CONTA , B.NUM_CONTA , B.DIG_CONTA , B.COD_CLIENTE , B.OCORR_ENDERECO , B.COD_AGENCIA_DEB , B.OPERACAO_CONTA_DEB , B.NUM_CONTA_DEB , B.DIG_CONTA_DEB , B.OPC_COBERTURA , B.DATA_QUITACAO , B.VAL_RCAP , B.RAMO , B.DATA_VENDA , B.SITUACAO , C.NOME_RAZAO , UCASE(C.NOME_RAZAO) , C.TIPO_PESSOA , C.CGCCPF , C.DATA_NASCIMENTO , C.IDE_SEXO , C.ESTADO_CIVIL , D.CIDADE , UCASE(D.CIDADE) , D.SIGLA_UF , UCASE(D.SIGLA_UF) INTO :CONVERSI-NUM-PROPOSTA-SIVPF , :CONVERSI-COD-PRODUTO-SIVPF , :BILHETE-NUM-BILHETE , :BILHETE-NUM-APOLICE , :BILHETE-FONTE , :BILHETE-AGE-COBRANCA , :BILHETE-NUM-MATRICULA , :BILHETE-COD-AGENCIA , :BILHETE-OPERACAO-CONTA , :BILHETE-NUM-CONTA , :BILHETE-DIG-CONTA , :BILHETE-COD-CLIENTE , :BILHETE-OCORR-ENDERECO , :BILHETE-COD-AGENCIA-DEB , :BILHETE-OPERACAO-CONTA-DEB , :BILHETE-NUM-CONTA-DEB , :BILHETE-DIG-CONTA-DEB , :BILHETE-OPC-COBERTURA , :BILHETE-DATA-QUITACAO , :BILHETE-VAL-RCAP , :BILHETE-RAMO , :BILHETE-DATA-VENDA , :BILHETE-SITUACAO , :CLIENTES-NOME-RAZAO , :WSHOST-NOME-RAZAO , :CLIENTES-TIPO-PESSOA , :CLIENTES-CGCCPF , :CLIENTES-DATA-NASCIMENTO:VIND-DTNASC , :CLIENTES-IDE-SEXO:VIND-SEXO , :CLIENTES-ESTADO-CIVIL:VIND-ESTCIVIL , :ENDERECO-CIDADE , :WSHOST-CIDADE , :ENDERECO-SIGLA-UF , :WSHOST-SIGLA-UF FROM SEGUROS.CONVERSAO_SICOB A , SEGUROS.BILHETE B , SEGUROS.CLIENTES C , SEGUROS.ENDERECOS D WHERE A.NUM_PROPOSTA_SIVPF = :CONVERSI-NUM-PROPOSTA-SIVPF AND A.NUM_SICOB = B.NUM_BILHETE AND B.COD_CLIENTE = C.COD_CLIENTE AND B.COD_CLIENTE = D.COD_CLIENTE AND B.OCORR_ENDERECO = D.OCORR_ENDERECO FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var r0360_00_SELECT_BILHETE_DB_SELECT_1_Query1 = new R0360_00_SELECT_BILHETE_DB_SELECT_1_Query1()
            {
                CONVERSI_NUM_PROPOSTA_SIVPF = CONVERSI.DCLCONVERSAO_SICOB.CONVERSI_NUM_PROPOSTA_SIVPF.ToString(),
            };

            var executed_1 = R0360_00_SELECT_BILHETE_DB_SELECT_1_Query1.Execute(r0360_00_SELECT_BILHETE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CONVERSI_NUM_PROPOSTA_SIVPF, CONVERSI.DCLCONVERSAO_SICOB.CONVERSI_NUM_PROPOSTA_SIVPF);
                _.Move(executed_1.CONVERSI_COD_PRODUTO_SIVPF, CONVERSI.DCLCONVERSAO_SICOB.CONVERSI_COD_PRODUTO_SIVPF);
                _.Move(executed_1.BILHETE_NUM_BILHETE, BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE);
                _.Move(executed_1.BILHETE_NUM_APOLICE, BILHETE.DCLBILHETE.BILHETE_NUM_APOLICE);
                _.Move(executed_1.BILHETE_FONTE, BILHETE.DCLBILHETE.BILHETE_FONTE);
                _.Move(executed_1.BILHETE_AGE_COBRANCA, BILHETE.DCLBILHETE.BILHETE_AGE_COBRANCA);
                _.Move(executed_1.BILHETE_NUM_MATRICULA, BILHETE.DCLBILHETE.BILHETE_NUM_MATRICULA);
                _.Move(executed_1.BILHETE_COD_AGENCIA, BILHETE.DCLBILHETE.BILHETE_COD_AGENCIA);
                _.Move(executed_1.BILHETE_OPERACAO_CONTA, BILHETE.DCLBILHETE.BILHETE_OPERACAO_CONTA);
                _.Move(executed_1.BILHETE_NUM_CONTA, BILHETE.DCLBILHETE.BILHETE_NUM_CONTA);
                _.Move(executed_1.BILHETE_DIG_CONTA, BILHETE.DCLBILHETE.BILHETE_DIG_CONTA);
                _.Move(executed_1.BILHETE_COD_CLIENTE, BILHETE.DCLBILHETE.BILHETE_COD_CLIENTE);
                _.Move(executed_1.BILHETE_OCORR_ENDERECO, BILHETE.DCLBILHETE.BILHETE_OCORR_ENDERECO);
                _.Move(executed_1.BILHETE_COD_AGENCIA_DEB, BILHETE.DCLBILHETE.BILHETE_COD_AGENCIA_DEB);
                _.Move(executed_1.BILHETE_OPERACAO_CONTA_DEB, BILHETE.DCLBILHETE.BILHETE_OPERACAO_CONTA_DEB);
                _.Move(executed_1.BILHETE_NUM_CONTA_DEB, BILHETE.DCLBILHETE.BILHETE_NUM_CONTA_DEB);
                _.Move(executed_1.BILHETE_DIG_CONTA_DEB, BILHETE.DCLBILHETE.BILHETE_DIG_CONTA_DEB);
                _.Move(executed_1.BILHETE_OPC_COBERTURA, BILHETE.DCLBILHETE.BILHETE_OPC_COBERTURA);
                _.Move(executed_1.BILHETE_DATA_QUITACAO, BILHETE.DCLBILHETE.BILHETE_DATA_QUITACAO);
                _.Move(executed_1.BILHETE_VAL_RCAP, BILHETE.DCLBILHETE.BILHETE_VAL_RCAP);
                _.Move(executed_1.BILHETE_RAMO, BILHETE.DCLBILHETE.BILHETE_RAMO);
                _.Move(executed_1.BILHETE_DATA_VENDA, BILHETE.DCLBILHETE.BILHETE_DATA_VENDA);
                _.Move(executed_1.BILHETE_SITUACAO, BILHETE.DCLBILHETE.BILHETE_SITUACAO);
                _.Move(executed_1.CLIENTES_NOME_RAZAO, CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO);
                _.Move(executed_1.WSHOST_NOME_RAZAO, WSHOST_NOME_RAZAO);
                _.Move(executed_1.CLIENTES_TIPO_PESSOA, CLIENTES.DCLCLIENTES.CLIENTES_TIPO_PESSOA);
                _.Move(executed_1.CLIENTES_CGCCPF, CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF);
                _.Move(executed_1.CLIENTES_DATA_NASCIMENTO, CLIENTES.DCLCLIENTES.CLIENTES_DATA_NASCIMENTO);
                _.Move(executed_1.VIND_DTNASC, VIND_DTNASC);
                _.Move(executed_1.CLIENTES_IDE_SEXO, CLIENTES.DCLCLIENTES.CLIENTES_IDE_SEXO);
                _.Move(executed_1.VIND_SEXO, VIND_SEXO);
                _.Move(executed_1.CLIENTES_ESTADO_CIVIL, CLIENTES.DCLCLIENTES.CLIENTES_ESTADO_CIVIL);
                _.Move(executed_1.VIND_ESTCIVIL, VIND_ESTCIVIL);
                _.Move(executed_1.ENDERECO_CIDADE, ENDERECO.DCLENDERECOS.ENDERECO_CIDADE);
                _.Move(executed_1.WSHOST_CIDADE, WSHOST_CIDADE);
                _.Move(executed_1.ENDERECO_SIGLA_UF, ENDERECO.DCLENDERECOS.ENDERECO_SIGLA_UF);
                _.Move(executed_1.WSHOST_SIGLA_UF, WSHOST_SIGLA_UF);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0360_99_SAIDA*/

        [StopWatch]
        /*" R0500-00-AJUSTA-FILIAL-SECTION */
        private void R0500_00_AJUSTA_FILIAL_SECTION()
        {
            /*" -1236- MOVE '0500' TO WNR-EXEC-SQL. */
            _.Move("0500", AUX_RELATORIO.WABEND.WNR_EXEC_SQL);

            /*" -1238- MOVE 'S' TO WTEM-FILIAL. */
            _.Move("S", W.WTEM_FILIAL);

            /*" -1239- IF BILHETE-COD-AGENCIA EQUAL 104 */

            if (BILHETE.DCLBILHETE.BILHETE_COD_AGENCIA == 104)
            {

                /*" -1240- PERFORM R0510-00-SELECT-AGENCIACEF */

                R0510_00_SELECT_AGENCIACEF_SECTION();

                /*" -1241- ELSE */
            }
            else
            {


                /*" -1244- PERFORM R0520-00-SELECT-AGENCIAS. */

                R0520_00_SELECT_AGENCIAS_SECTION();
            }


            /*" -1245- IF WTEM-FILIAL NOT EQUAL 'S' */

            if (W.WTEM_FILIAL != "S")
            {

                /*" -1248- PERFORM R0530-00-MOVE-FILIAL. */

                R0530_00_MOVE_FILIAL_SECTION();
            }


            /*" -1249- MOVE FONTES-COD-FONTE TO BILHETE-FONTE. */
            _.Move(FONTES.DCLFONTES.FONTES_COD_FONTE, BILHETE.DCLBILHETE.BILHETE_FONTE);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0500_99_SAIDA*/

        [StopWatch]
        /*" R0510-00-SELECT-AGENCIACEF-SECTION */
        private void R0510_00_SELECT_AGENCIACEF_SECTION()
        {
            /*" -1262- MOVE '0510' TO WNR-EXEC-SQL. */
            _.Move("0510", AUX_RELATORIO.WABEND.WNR_EXEC_SQL);

            /*" -1265- MOVE BILHETE-COD-AGENCIA TO AGENCCEF-COD-AGENCIA. */
            _.Move(BILHETE.DCLBILHETE.BILHETE_COD_AGENCIA, AGENCCEF.DCLAGENCIAS_CEF.AGENCCEF_COD_AGENCIA);

            /*" -1278- PERFORM R0510_00_SELECT_AGENCIACEF_DB_SELECT_1 */

            R0510_00_SELECT_AGENCIACEF_DB_SELECT_1();

            /*" -1281- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1282- MOVE 'N' TO WTEM-FILIAL */
                _.Move("N", W.WTEM_FILIAL);

                /*" -1285- GO TO R0510-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0510_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1286- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1287- DISPLAY 'R0510-00 - PROBLEMAS SELECT  (AGENCCEF)   ' */
                _.Display($"R0510-00 - PROBLEMAS SELECT  (AGENCCEF)   ");

                /*" -1288- DISPLAY 'SIT-REGISTRO    = ' MOVIMCOB-SIT-REGISTRO */
                _.Display($"SIT-REGISTRO    = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_SIT_REGISTRO}");

                /*" -1289- DISPLAY 'COD-BANCO       = ' MOVIMCOB-COD-BANCO */
                _.Display($"COD-BANCO       = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_BANCO}");

                /*" -1290- DISPLAY 'COD-AGENCIA     = ' MOVIMCOB-COD-AGENCIA */
                _.Display($"COD-AGENCIA     = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_AGENCIA}");

                /*" -1291- DISPLAY 'NUM-AVISO       = ' MOVIMCOB-NUM-AVISO */
                _.Display($"NUM-AVISO       = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_AVISO}");

                /*" -1292- DISPLAY 'NUM-FITA        = ' MOVIMCOB-NUM-FITA */
                _.Display($"NUM-FITA        = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_FITA}");

                /*" -1293- DISPLAY 'NUM-NOSSO-TITULO= ' MOVIMCOB-NUM-NOSSO-TITULO */
                _.Display($"NUM-NOSSO-TITULO= {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_NOSSO_TITULO}");

                /*" -1294- DISPLAY 'NUM-APOLICE     = ' MOVIMCOB-NUM-APOLICE */
                _.Display($"NUM-APOLICE     = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_APOLICE}");

                /*" -1295- DISPLAY 'NUM-ENDOSSO     = ' MOVIMCOB-NUM-ENDOSSO */
                _.Display($"NUM-ENDOSSO     = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_ENDOSSO}");

                /*" -1296- DISPLAY 'NUM-PARCELA     = ' MOVIMCOB-NUM-PARCELA */
                _.Display($"NUM-PARCELA     = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_PARCELA}");

                /*" -1297- DISPLAY 'COD-MOVIMENTO   = ' MOVIMCOB-COD-MOVIMENTO */
                _.Display($"COD-MOVIMENTO   = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_MOVIMENTO}");

                /*" -1298- DISPLAY 'NOME-SEGURADO   = ' MOVIMCOB-NOME-SEGURADO */
                _.Display($"NOME-SEGURADO   = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NOME_SEGURADO}");

                /*" -1299- DISPLAY 'AGENCIA CEF     = ' AGENCCEF-COD-AGENCIA */
                _.Display($"AGENCIA CEF     = {AGENCCEF.DCLAGENCIAS_CEF.AGENCCEF_COD_AGENCIA}");

                /*" -1299- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0510-00-SELECT-AGENCIACEF-DB-SELECT-1 */
        public void R0510_00_SELECT_AGENCIACEF_DB_SELECT_1()
        {
            /*" -1278- EXEC SQL SELECT D.COD_FONTE INTO :FONTES-COD-FONTE FROM SEGUROS.AGENCIAS_CEF B , SEGUROS.MALHA_CEF C , SEGUROS.FONTES D WHERE B.COD_AGENCIA = :AGENCCEF-COD-AGENCIA AND B.COD_SUREG BETWEEN 2500 AND 5000 AND B.COD_SUREG = C.COD_SUREG AND C.COD_FONTE = D.COD_FONTE FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var r0510_00_SELECT_AGENCIACEF_DB_SELECT_1_Query1 = new R0510_00_SELECT_AGENCIACEF_DB_SELECT_1_Query1()
            {
                AGENCCEF_COD_AGENCIA = AGENCCEF.DCLAGENCIAS_CEF.AGENCCEF_COD_AGENCIA.ToString(),
            };

            var executed_1 = R0510_00_SELECT_AGENCIACEF_DB_SELECT_1_Query1.Execute(r0510_00_SELECT_AGENCIACEF_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.FONTES_COD_FONTE, FONTES.DCLFONTES.FONTES_COD_FONTE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0510_99_SAIDA*/

        [StopWatch]
        /*" R0520-00-SELECT-AGENCIAS-SECTION */
        private void R0520_00_SELECT_AGENCIAS_SECTION()
        {
            /*" -1312- MOVE '0520' TO WNR-EXEC-SQL. */
            _.Move("0520", AUX_RELATORIO.WABEND.WNR_EXEC_SQL);

            /*" -1314- MOVE 104 TO AGENCIAS-COD-BANCO. */
            _.Move(104, AGENCIAS.DCLAGENCIAS.AGENCIAS_COD_BANCO);

            /*" -1316- MOVE WSHOST-CIDADE TO AGENCIAS-CIDADE. */
            _.Move(WSHOST_CIDADE, AGENCIAS.DCLAGENCIAS.AGENCIAS_CIDADE);

            /*" -1319- MOVE WSHOST-SIGLA-UF TO AGENCIAS-SIGLA-UF. */
            _.Move(WSHOST_SIGLA_UF, AGENCIAS.DCLAGENCIAS.AGENCIAS_SIGLA_UF);

            /*" -1337- PERFORM R0520_00_SELECT_AGENCIAS_DB_SELECT_1 */

            R0520_00_SELECT_AGENCIAS_DB_SELECT_1();

            /*" -1340- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1341- MOVE 'N' TO WTEM-FILIAL */
                _.Move("N", W.WTEM_FILIAL);

                /*" -1344- GO TO R0520-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0520_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1345- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1346- DISPLAY 'R0520-00 - PROBLEMAS SELECT  (AGENCIAS)   ' */
                _.Display($"R0520-00 - PROBLEMAS SELECT  (AGENCIAS)   ");

                /*" -1347- DISPLAY 'SIT-REGISTRO    = ' MOVIMCOB-SIT-REGISTRO */
                _.Display($"SIT-REGISTRO    = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_SIT_REGISTRO}");

                /*" -1348- DISPLAY 'COD-BANCO       = ' MOVIMCOB-COD-BANCO */
                _.Display($"COD-BANCO       = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_BANCO}");

                /*" -1349- DISPLAY 'COD-AGENCIA     = ' MOVIMCOB-COD-AGENCIA */
                _.Display($"COD-AGENCIA     = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_AGENCIA}");

                /*" -1350- DISPLAY 'NUM-AVISO       = ' MOVIMCOB-NUM-AVISO */
                _.Display($"NUM-AVISO       = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_AVISO}");

                /*" -1351- DISPLAY 'NUM-FITA        = ' MOVIMCOB-NUM-FITA */
                _.Display($"NUM-FITA        = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_FITA}");

                /*" -1352- DISPLAY 'NUM-NOSSO-TITULO= ' MOVIMCOB-NUM-NOSSO-TITULO */
                _.Display($"NUM-NOSSO-TITULO= {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_NOSSO_TITULO}");

                /*" -1353- DISPLAY 'NUM-APOLICE     = ' MOVIMCOB-NUM-APOLICE */
                _.Display($"NUM-APOLICE     = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_APOLICE}");

                /*" -1354- DISPLAY 'NUM-ENDOSSO     = ' MOVIMCOB-NUM-ENDOSSO */
                _.Display($"NUM-ENDOSSO     = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_ENDOSSO}");

                /*" -1355- DISPLAY 'NUM-PARCELA     = ' MOVIMCOB-NUM-PARCELA */
                _.Display($"NUM-PARCELA     = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_PARCELA}");

                /*" -1356- DISPLAY 'COD-MOVIMENTO   = ' MOVIMCOB-COD-MOVIMENTO */
                _.Display($"COD-MOVIMENTO   = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_MOVIMENTO}");

                /*" -1357- DISPLAY 'NOME-SEGURADO   = ' MOVIMCOB-NOME-SEGURADO */
                _.Display($"NOME-SEGURADO   = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NOME_SEGURADO}");

                /*" -1358- DISPLAY 'CIDADE          = ' AGENCIAS-CIDADE */
                _.Display($"CIDADE          = {AGENCIAS.DCLAGENCIAS.AGENCIAS_CIDADE}");

                /*" -1359- DISPLAY 'SIGLA UF        = ' AGENCIAS-SIGLA-UF */
                _.Display($"SIGLA UF        = {AGENCIAS.DCLAGENCIAS.AGENCIAS_SIGLA_UF}");

                /*" -1359- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0520-00-SELECT-AGENCIAS-DB-SELECT-1 */
        public void R0520_00_SELECT_AGENCIAS_DB_SELECT_1()
        {
            /*" -1337- EXEC SQL SELECT D.COD_FONTE INTO :FONTES-COD-FONTE FROM SEGUROS.AGENCIAS A , SEGUROS.AGENCIAS_CEF B , SEGUROS.MALHA_CEF C , SEGUROS.FONTES D WHERE A.COD_BANCO = :AGENCIAS-COD-BANCO AND A.CIDADE = :AGENCIAS-CIDADE AND A.SIGLA_UF = :AGENCIAS-SIGLA-UF AND A.COD_AGENCIA = B.COD_AGENCIA AND B.COD_SUREG BETWEEN 2500 AND 5000 AND B.COD_SUREG = C.COD_SUREG AND D.COD_FONTE = C.COD_FONTE AND D.SIGLA_UF = A.SIGLA_UF FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var r0520_00_SELECT_AGENCIAS_DB_SELECT_1_Query1 = new R0520_00_SELECT_AGENCIAS_DB_SELECT_1_Query1()
            {
                AGENCIAS_COD_BANCO = AGENCIAS.DCLAGENCIAS.AGENCIAS_COD_BANCO.ToString(),
                AGENCIAS_SIGLA_UF = AGENCIAS.DCLAGENCIAS.AGENCIAS_SIGLA_UF.ToString(),
                AGENCIAS_CIDADE = AGENCIAS.DCLAGENCIAS.AGENCIAS_CIDADE.ToString(),
            };

            var executed_1 = R0520_00_SELECT_AGENCIAS_DB_SELECT_1_Query1.Execute(r0520_00_SELECT_AGENCIAS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.FONTES_COD_FONTE, FONTES.DCLFONTES.FONTES_COD_FONTE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0520_99_SAIDA*/

        [StopWatch]
        /*" R0530-00-MOVE-FILIAL-SECTION */
        private void R0530_00_MOVE_FILIAL_SECTION()
        {
            /*" -1372- MOVE '0530' TO WNR-EXEC-SQL. */
            _.Move("0530", AUX_RELATORIO.WABEND.WNR_EXEC_SQL);

            /*" -1374- IF WSHOST-SIGLA-UF EQUAL 'ES' OR 'RJ' */

            if (WSHOST_SIGLA_UF.In("ES", "RJ"))
            {

                /*" -1375- MOVE 01 TO FONTES-COD-FONTE */
                _.Move(01, FONTES.DCLFONTES.FONTES_COD_FONTE);

                /*" -1376- ELSE */
            }
            else
            {


                /*" -1378- IF WSHOST-SIGLA-UF EQUAL 'BA' OR 'SE' */

                if (WSHOST_SIGLA_UF.In("BA", "SE"))
                {

                    /*" -1379- MOVE 04 TO FONTES-COD-FONTE */
                    _.Move(04, FONTES.DCLFONTES.FONTES_COD_FONTE);

                    /*" -1380- ELSE */
                }
                else
                {


                    /*" -1382- IF WSHOST-SIGLA-UF EQUAL 'DF' OR 'MT' */

                    if (WSHOST_SIGLA_UF.In("DF", "MT"))
                    {

                        /*" -1383- MOVE 05 TO FONTES-COD-FONTE */
                        _.Move(05, FONTES.DCLFONTES.FONTES_COD_FONTE);

                        /*" -1384- ELSE */
                    }
                    else
                    {


                        /*" -1387- IF WSHOST-SIGLA-UF EQUAL 'CE' OR 'MA' OR 'PI' */

                        if (WSHOST_SIGLA_UF.In("CE", "MA", "PI"))
                        {

                            /*" -1388- MOVE 06 TO FONTES-COD-FONTE */
                            _.Move(06, FONTES.DCLFONTES.FONTES_COD_FONTE);

                            /*" -1389- ELSE */
                        }
                        else
                        {


                            /*" -1391- IF WSHOST-SIGLA-UF EQUAL 'GO' OR 'TO' */

                            if (WSHOST_SIGLA_UF.In("GO", "TO"))
                            {

                                /*" -1392- MOVE 09 TO FONTES-COD-FONTE */
                                _.Move(09, FONTES.DCLFONTES.FONTES_COD_FONTE);

                                /*" -1393- ELSE */
                            }
                            else
                            {


                                /*" -1394- IF WSHOST-SIGLA-UF EQUAL 'MG' */

                                if (WSHOST_SIGLA_UF == "MG")
                                {

                                    /*" -1395- MOVE 12 TO FONTES-COD-FONTE */
                                    _.Move(12, FONTES.DCLFONTES.FONTES_COD_FONTE);

                                    /*" -1396- ELSE */
                                }
                                else
                                {


                                    /*" -1402- IF WSHOST-SIGLA-UF EQUAL 'AC' OR 'AM' OR 'AP' OR 'PA' OR 'RO' OR 'RR' */

                                    if (WSHOST_SIGLA_UF.In("AC", "AM", "AP", "PA", "RO", "RR"))
                                    {

                                        /*" -1403- MOVE 13 TO FONTES-COD-FONTE */
                                        _.Move(13, FONTES.DCLFONTES.FONTES_COD_FONTE);

                                        /*" -1404- ELSE */
                                    }
                                    else
                                    {


                                        /*" -1405- IF WSHOST-SIGLA-UF EQUAL 'PR' */

                                        if (WSHOST_SIGLA_UF == "PR")
                                        {

                                            /*" -1406- MOVE 15 TO FONTES-COD-FONTE */
                                            _.Move(15, FONTES.DCLFONTES.FONTES_COD_FONTE);

                                            /*" -1407- ELSE */
                                        }
                                        else
                                        {


                                            /*" -1411- IF WSHOST-SIGLA-UF EQUAL 'AL' OR 'PB' OR 'PE' OR 'RN' */

                                            if (WSHOST_SIGLA_UF.In("AL", "PB", "PE", "RN"))
                                            {

                                                /*" -1412- MOVE 16 TO FONTES-COD-FONTE */
                                                _.Move(16, FONTES.DCLFONTES.FONTES_COD_FONTE);

                                                /*" -1413- ELSE */
                                            }
                                            else
                                            {


                                                /*" -1414- IF WSHOST-SIGLA-UF EQUAL 'RS' */

                                                if (WSHOST_SIGLA_UF == "RS")
                                                {

                                                    /*" -1415- MOVE 19 TO FONTES-COD-FONTE */
                                                    _.Move(19, FONTES.DCLFONTES.FONTES_COD_FONTE);

                                                    /*" -1416- ELSE */
                                                }
                                                else
                                                {


                                                    /*" -1417- IF WSHOST-SIGLA-UF EQUAL 'SC' */

                                                    if (WSHOST_SIGLA_UF == "SC")
                                                    {

                                                        /*" -1418- MOVE 20 TO FONTES-COD-FONTE */
                                                        _.Move(20, FONTES.DCLFONTES.FONTES_COD_FONTE);

                                                        /*" -1419- ELSE */
                                                    }
                                                    else
                                                    {


                                                        /*" -1420- IF WSHOST-SIGLA-UF EQUAL 'SP' */

                                                        if (WSHOST_SIGLA_UF == "SP")
                                                        {

                                                            /*" -1421- MOVE 21 TO FONTES-COD-FONTE */
                                                            _.Move(21, FONTES.DCLFONTES.FONTES_COD_FONTE);

                                                            /*" -1422- ELSE */
                                                        }
                                                        else
                                                        {


                                                            /*" -1423- IF WSHOST-SIGLA-UF EQUAL 'MS' */

                                                            if (WSHOST_SIGLA_UF == "MS")
                                                            {

                                                                /*" -1424- MOVE 23 TO FONTES-COD-FONTE */
                                                                _.Move(23, FONTES.DCLFONTES.FONTES_COD_FONTE);

                                                                /*" -1425- ELSE */
                                                            }
                                                            else
                                                            {


                                                                /*" -1425- MOVE 10 TO FONTES-COD-FONTE. */
                                                                _.Move(10, FONTES.DCLFONTES.FONTES_COD_FONTE);
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
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0530_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-TRATA-RELACAO-SECTION */
        private void R1000_00_TRATA_RELACAO_SECTION()
        {
            /*" -1438- MOVE '1000' TO WNR-EXEC-SQL. */
            _.Move("1000", AUX_RELATORIO.WABEND.WNR_EXEC_SQL);

            /*" -1440- ADD 1 TO TT-RELACAO. */
            W.TT_RELACAO.Value = W.TT_RELACAO + 1;

            /*" -1441- MOVE 'S' TO WTEM-PESSOA. */
            _.Move("S", W.WTEM_PESSOA);

            /*" -1443- PERFORM R1050-00-SELECT-PESSOFIS. */

            R1050_00_SELECT_PESSOFIS_SECTION();

            /*" -1444- IF WTEM-PESSOA NOT EQUAL 'S' */

            if (W.WTEM_PESSOA != "S")
            {

                /*" -1445- ADD 1 TO IN-PESSOA */
                W.IN_PESSOA.Value = W.IN_PESSOA + 1;

                /*" -1446- PERFORM R1150-00-INSERT-PESSOA */

                R1150_00_INSERT_PESSOA_SECTION();

                /*" -1449- PERFORM R1160-00-INSERT-PESSOA-FISICA. */

                R1160_00_INSERT_PESSOA_FISICA_SECTION();
            }


            /*" -1450- MOVE 'S' TO WTEM-RELACAO. */
            _.Move("S", W.WTEM_RELACAO);

            /*" -1452- PERFORM R1200-00-SELECT-RTPRELAC. */

            R1200_00_SELECT_RTPRELAC_SECTION();

            /*" -1453- IF WTEM-RELACAO NOT EQUAL 'S' */

            if (W.WTEM_RELACAO != "S")
            {

                /*" -1454- ADD 1 TO IN-RTPRELAC */
                W.IN_RTPRELAC.Value = W.IN_RTPRELAC + 1;

                /*" -1457- PERFORM R1250-00-INSERT-RTPRELAC. */

                R1250_00_INSERT_RTPRELAC_SECTION();
            }


            /*" -1458- ADD 1 TO IN-IDENTREL. */
            W.IN_IDENTREL.Value = W.IN_IDENTREL + 1;

            /*" -1461- PERFORM R1350-00-INSERT-IDENTREL. */

            R1350_00_INSERT_IDENTREL_SECTION();

            /*" -1462- MOVE 'S' TO WTEM-PROPOSTA. */
            _.Move("S", W.WTEM_PROPOSTA);

            /*" -1465- PERFORM R1400-00-SELECT-FIDELIZ. */

            R1400_00_SELECT_FIDELIZ_SECTION();

            /*" -1469- MOVE 'POB' TO PROPOFID-SIT-PROPOSTA. */
            _.Move("POB", PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_SIT_PROPOSTA);

            /*" -1470- IF WTEM-PROPOSTA NOT EQUAL 'S' */

            if (W.WTEM_PROPOSTA != "S")
            {

                /*" -1471- ADD 1 TO IN-PROPOFID */
                W.IN_PROPOFID.Value = W.IN_PROPOFID + 1;

                /*" -1472- PERFORM R1450-00-INSERT-FIDELIZ */

                R1450_00_INSERT_FIDELIZ_SECTION();

                /*" -1473- ELSE */
            }
            else
            {


                /*" -1474- ADD 1 TO UP-PROPOFID */
                W.UP_PROPOFID.Value = W.UP_PROPOFID + 1;

                /*" -1474- PERFORM R1500-00-UPDATE-FIDELIZ. */

                R1500_00_UPDATE_FIDELIZ_SECTION();
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1050-00-SELECT-PESSOFIS-SECTION */
        private void R1050_00_SELECT_PESSOFIS_SECTION()
        {
            /*" -1487- MOVE '1050' TO WNR-EXEC-SQL. */
            _.Move("1050", AUX_RELATORIO.WABEND.WNR_EXEC_SQL);

            /*" -1521- PERFORM R1050_00_SELECT_PESSOFIS_DB_SELECT_1 */

            R1050_00_SELECT_PESSOFIS_DB_SELECT_1();

            /*" -1525- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1526- MOVE 'N' TO WTEM-PESSOA */
                _.Move("N", W.WTEM_PESSOA);

                /*" -1529- GO TO R1050-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1050_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1530- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1531- DISPLAY 'R1050-00 - PROBLEMAS SELECT  (PESSOFIS)   ' */
                _.Display($"R1050-00 - PROBLEMAS SELECT  (PESSOFIS)   ");

                /*" -1532- DISPLAY 'SIT-REGISTRO    = ' MOVIMCOB-SIT-REGISTRO */
                _.Display($"SIT-REGISTRO    = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_SIT_REGISTRO}");

                /*" -1533- DISPLAY 'COD-BANCO       = ' MOVIMCOB-COD-BANCO */
                _.Display($"COD-BANCO       = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_BANCO}");

                /*" -1534- DISPLAY 'COD-AGENCIA     = ' MOVIMCOB-COD-AGENCIA */
                _.Display($"COD-AGENCIA     = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_AGENCIA}");

                /*" -1535- DISPLAY 'NUM-AVISO       = ' MOVIMCOB-NUM-AVISO */
                _.Display($"NUM-AVISO       = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_AVISO}");

                /*" -1536- DISPLAY 'NUM-FITA        = ' MOVIMCOB-NUM-FITA */
                _.Display($"NUM-FITA        = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_FITA}");

                /*" -1537- DISPLAY 'NUM-NOSSO-TITULO= ' MOVIMCOB-NUM-NOSSO-TITULO */
                _.Display($"NUM-NOSSO-TITULO= {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_NOSSO_TITULO}");

                /*" -1538- DISPLAY 'NUM-APOLICE     = ' MOVIMCOB-NUM-APOLICE */
                _.Display($"NUM-APOLICE     = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_APOLICE}");

                /*" -1539- DISPLAY 'NUM-ENDOSSO     = ' MOVIMCOB-NUM-ENDOSSO */
                _.Display($"NUM-ENDOSSO     = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_ENDOSSO}");

                /*" -1540- DISPLAY 'NUM-PARCELA     = ' MOVIMCOB-NUM-PARCELA */
                _.Display($"NUM-PARCELA     = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_PARCELA}");

                /*" -1541- DISPLAY 'COD-MOVIMENTO   = ' MOVIMCOB-COD-MOVIMENTO */
                _.Display($"COD-MOVIMENTO   = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_MOVIMENTO}");

                /*" -1542- DISPLAY 'NOME-SEGURADO   = ' MOVIMCOB-NOME-SEGURADO */
                _.Display($"NOME-SEGURADO   = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NOME_SEGURADO}");

                /*" -1543- DISPLAY 'CPF             = ' CLIENTES-CGCCPF */
                _.Display($"CPF             = {CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF}");

                /*" -1544- DISPLAY 'DATA_NASCIMENTO = ' CLIENTES-DATA-NASCIMENTO */
                _.Display($"DATA_NASCIMENTO = {CLIENTES.DCLCLIENTES.CLIENTES_DATA_NASCIMENTO}");

                /*" -1547- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1548- IF VIND-NUM-IDENT LESS ZEROS */

            if (VIND_NUM_IDENT < 00)
            {

                /*" -1551- MOVE SPACES TO PESSOFIS-NUM-IDENTIDADE. */
                _.Move("", PESSOFIS.DCLPESSOA_FISICA.PESSOFIS_NUM_IDENTIDADE);
            }


            /*" -1552- IF VIND-ORGAO-EXP LESS ZEROS */

            if (VIND_ORGAO_EXP < 00)
            {

                /*" -1555- MOVE SPACES TO PESSOFIS-ORGAO-EXPEDIDOR. */
                _.Move("", PESSOFIS.DCLPESSOA_FISICA.PESSOFIS_ORGAO_EXPEDIDOR);
            }


            /*" -1556- IF VIND-UF-EXP LESS ZEROS */

            if (VIND_UF_EXP < 00)
            {

                /*" -1559- MOVE SPACES TO PESSOFIS-UF-EXPEDIDORA. */
                _.Move("", PESSOFIS.DCLPESSOA_FISICA.PESSOFIS_UF_EXPEDIDORA);
            }


            /*" -1560- IF VIND-DTEXPEDI LESS ZEROS */

            if (VIND_DTEXPEDI < 00)
            {

                /*" -1563- MOVE SPACES TO PESSOFIS-DATA-EXPEDICAO. */
                _.Move("", PESSOFIS.DCLPESSOA_FISICA.PESSOFIS_DATA_EXPEDICAO);
            }


            /*" -1564- IF VIND-COD-CBO LESS ZEROS */

            if (VIND_COD_CBO < 00)
            {

                /*" -1567- MOVE ZEROS TO PESSOFIS-COD-CBO. */
                _.Move(0, PESSOFIS.DCLPESSOA_FISICA.PESSOFIS_COD_CBO);
            }


            /*" -1568- IF VIND-TP-IDENT LESS ZEROS */

            if (VIND_TP_IDENT < 00)
            {

                /*" -1569- MOVE SPACES TO PESSOFIS-TIPO-IDENT-SIVPF. */
                _.Move("", PESSOFIS.DCLPESSOA_FISICA.PESSOFIS_TIPO_IDENT_SIVPF);
            }


        }

        [StopWatch]
        /*" R1050-00-SELECT-PESSOFIS-DB-SELECT-1 */
        public void R1050_00_SELECT_PESSOFIS_DB_SELECT_1()
        {
            /*" -1521- EXEC SQL SELECT A.COD_PESSOA , A.CPF , A.DATA_NASCIMENTO , A.SEXO , A.COD_USUARIO , A.ESTADO_CIVIL , A.NUM_IDENTIDADE , A.ORGAO_EXPEDIDOR , A.UF_EXPEDIDORA , A.DATA_EXPEDICAO , A.COD_CBO , A.TIPO_IDENT_SIVPF , B.NOME_PESSOA INTO :PESSOFIS-COD-PESSOA , :PESSOFIS-CPF , :PESSOFIS-DATA-NASCIMENTO , :PESSOFIS-SEXO , :PESSOFIS-COD-USUARIO , :PESSOFIS-ESTADO-CIVIL , :PESSOFIS-NUM-IDENTIDADE:VIND-NUM-IDENT , :PESSOFIS-ORGAO-EXPEDIDOR:VIND-ORGAO-EXP , :PESSOFIS-UF-EXPEDIDORA:VIND-UF-EXP , :PESSOFIS-DATA-EXPEDICAO:VIND-DTEXPEDI , :PESSOFIS-COD-CBO:VIND-COD-CBO , :PESSOFIS-TIPO-IDENT-SIVPF:VIND-TP-IDENT , :PESSOA-NOME-PESSOA FROM SEGUROS.PESSOA_FISICA A, SEGUROS.PESSOA B WHERE A.CPF = :CLIENTES-CGCCPF AND A.DATA_NASCIMENTO = :CLIENTES-DATA-NASCIMENTO AND A.COD_PESSOA = B.COD_PESSOA ORDER BY A.COD_PESSOA DESC FETCH FIRST 1 ROWS ONLY END-EXEC. */

            var r1050_00_SELECT_PESSOFIS_DB_SELECT_1_Query1 = new R1050_00_SELECT_PESSOFIS_DB_SELECT_1_Query1()
            {
                CLIENTES_DATA_NASCIMENTO = CLIENTES.DCLCLIENTES.CLIENTES_DATA_NASCIMENTO.ToString(),
                CLIENTES_CGCCPF = CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF.ToString(),
            };

            var executed_1 = R1050_00_SELECT_PESSOFIS_DB_SELECT_1_Query1.Execute(r1050_00_SELECT_PESSOFIS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PESSOFIS_COD_PESSOA, PESSOFIS.DCLPESSOA_FISICA.PESSOFIS_COD_PESSOA);
                _.Move(executed_1.PESSOFIS_CPF, PESSOFIS.DCLPESSOA_FISICA.PESSOFIS_CPF);
                _.Move(executed_1.PESSOFIS_DATA_NASCIMENTO, PESSOFIS.DCLPESSOA_FISICA.PESSOFIS_DATA_NASCIMENTO);
                _.Move(executed_1.PESSOFIS_SEXO, PESSOFIS.DCLPESSOA_FISICA.PESSOFIS_SEXO);
                _.Move(executed_1.PESSOFIS_COD_USUARIO, PESSOFIS.DCLPESSOA_FISICA.PESSOFIS_COD_USUARIO);
                _.Move(executed_1.PESSOFIS_ESTADO_CIVIL, PESSOFIS.DCLPESSOA_FISICA.PESSOFIS_ESTADO_CIVIL);
                _.Move(executed_1.PESSOFIS_NUM_IDENTIDADE, PESSOFIS.DCLPESSOA_FISICA.PESSOFIS_NUM_IDENTIDADE);
                _.Move(executed_1.VIND_NUM_IDENT, VIND_NUM_IDENT);
                _.Move(executed_1.PESSOFIS_ORGAO_EXPEDIDOR, PESSOFIS.DCLPESSOA_FISICA.PESSOFIS_ORGAO_EXPEDIDOR);
                _.Move(executed_1.VIND_ORGAO_EXP, VIND_ORGAO_EXP);
                _.Move(executed_1.PESSOFIS_UF_EXPEDIDORA, PESSOFIS.DCLPESSOA_FISICA.PESSOFIS_UF_EXPEDIDORA);
                _.Move(executed_1.VIND_UF_EXP, VIND_UF_EXP);
                _.Move(executed_1.PESSOFIS_DATA_EXPEDICAO, PESSOFIS.DCLPESSOA_FISICA.PESSOFIS_DATA_EXPEDICAO);
                _.Move(executed_1.VIND_DTEXPEDI, VIND_DTEXPEDI);
                _.Move(executed_1.PESSOFIS_COD_CBO, PESSOFIS.DCLPESSOA_FISICA.PESSOFIS_COD_CBO);
                _.Move(executed_1.VIND_COD_CBO, VIND_COD_CBO);
                _.Move(executed_1.PESSOFIS_TIPO_IDENT_SIVPF, PESSOFIS.DCLPESSOA_FISICA.PESSOFIS_TIPO_IDENT_SIVPF);
                _.Move(executed_1.VIND_TP_IDENT, VIND_TP_IDENT);
                _.Move(executed_1.PESSOA_NOME_PESSOA, PESSOA.DCLPESSOA.PESSOA_NOME_PESSOA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1050_99_SAIDA*/

        [StopWatch]
        /*" R1150-00-INSERT-PESSOA-SECTION */
        private void R1150_00_INSERT_PESSOA_SECTION()
        {
            /*" -1582- MOVE '1150' TO WNR-EXEC-SQL. */
            _.Move("1150", AUX_RELATORIO.WABEND.WNR_EXEC_SQL);

            /*" -1586- PERFORM R1150_00_INSERT_PESSOA_DB_SELECT_1 */

            R1150_00_INSERT_PESSOA_DB_SELECT_1();

            /*" -1590- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1591- DISPLAY 'R1150-00 - PROBLEMAS SELECT  (PESSOA  )   ' */
                _.Display($"R1150-00 - PROBLEMAS SELECT  (PESSOA  )   ");

                /*" -1592- DISPLAY 'SIT-REGISTRO    = ' MOVIMCOB-SIT-REGISTRO */
                _.Display($"SIT-REGISTRO    = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_SIT_REGISTRO}");

                /*" -1593- DISPLAY 'COD-BANCO       = ' MOVIMCOB-COD-BANCO */
                _.Display($"COD-BANCO       = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_BANCO}");

                /*" -1594- DISPLAY 'COD-AGENCIA     = ' MOVIMCOB-COD-AGENCIA */
                _.Display($"COD-AGENCIA     = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_AGENCIA}");

                /*" -1595- DISPLAY 'NUM-AVISO       = ' MOVIMCOB-NUM-AVISO */
                _.Display($"NUM-AVISO       = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_AVISO}");

                /*" -1596- DISPLAY 'NUM-FITA        = ' MOVIMCOB-NUM-FITA */
                _.Display($"NUM-FITA        = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_FITA}");

                /*" -1597- DISPLAY 'NUM-NOSSO-TITULO= ' MOVIMCOB-NUM-NOSSO-TITULO */
                _.Display($"NUM-NOSSO-TITULO= {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_NOSSO_TITULO}");

                /*" -1598- DISPLAY 'NUM-APOLICE     = ' MOVIMCOB-NUM-APOLICE */
                _.Display($"NUM-APOLICE     = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_APOLICE}");

                /*" -1599- DISPLAY 'NUM-ENDOSSO     = ' MOVIMCOB-NUM-ENDOSSO */
                _.Display($"NUM-ENDOSSO     = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_ENDOSSO}");

                /*" -1600- DISPLAY 'NUM-PARCELA     = ' MOVIMCOB-NUM-PARCELA */
                _.Display($"NUM-PARCELA     = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_PARCELA}");

                /*" -1601- DISPLAY 'COD-MOVIMENTO   = ' MOVIMCOB-COD-MOVIMENTO */
                _.Display($"COD-MOVIMENTO   = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_MOVIMENTO}");

                /*" -1602- DISPLAY 'NOME-SEGURADO   = ' MOVIMCOB-NOME-SEGURADO */
                _.Display($"NOME-SEGURADO   = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NOME_SEGURADO}");

                /*" -1605- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1607- ADD 1 TO PESSOA-COD-PESSOA. */
            PESSOA.DCLPESSOA.PESSOA_COD_PESSOA.Value = PESSOA.DCLPESSOA.PESSOA_COD_PESSOA + 1;

            /*" -1609- MOVE CLIENTES-NOME-RAZAO TO PESSOA-NOME-PESSOA. */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO, PESSOA.DCLPESSOA.PESSOA_NOME_PESSOA);

            /*" -1611- MOVE CLIENTES-TIPO-PESSOA TO PESSOA-TIPO-PESSOA. */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_TIPO_PESSOA, PESSOA.DCLPESSOA.PESSOA_TIPO_PESSOA);

            /*" -1615- MOVE 'BI6252B' TO PESSOA-COD-USUARIO. */
            _.Move("BI6252B", PESSOA.DCLPESSOA.PESSOA_COD_USUARIO);

            /*" -1623- PERFORM R1150_00_INSERT_PESSOA_DB_INSERT_1 */

            R1150_00_INSERT_PESSOA_DB_INSERT_1();

            /*" -1627- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1628- DISPLAY 'R1150-00 - PROBLEMAS INSERT  (PESSOA  )   ' */
                _.Display($"R1150-00 - PROBLEMAS INSERT  (PESSOA  )   ");

                /*" -1629- DISPLAY 'SIT-REGISTRO    = ' MOVIMCOB-SIT-REGISTRO */
                _.Display($"SIT-REGISTRO    = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_SIT_REGISTRO}");

                /*" -1630- DISPLAY 'COD-BANCO       = ' MOVIMCOB-COD-BANCO */
                _.Display($"COD-BANCO       = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_BANCO}");

                /*" -1631- DISPLAY 'COD-AGENCIA     = ' MOVIMCOB-COD-AGENCIA */
                _.Display($"COD-AGENCIA     = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_AGENCIA}");

                /*" -1632- DISPLAY 'NUM-AVISO       = ' MOVIMCOB-NUM-AVISO */
                _.Display($"NUM-AVISO       = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_AVISO}");

                /*" -1633- DISPLAY 'NUM-FITA        = ' MOVIMCOB-NUM-FITA */
                _.Display($"NUM-FITA        = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_FITA}");

                /*" -1634- DISPLAY 'NUM-NOSSO-TITULO= ' MOVIMCOB-NUM-NOSSO-TITULO */
                _.Display($"NUM-NOSSO-TITULO= {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_NOSSO_TITULO}");

                /*" -1635- DISPLAY 'NUM-APOLICE     = ' MOVIMCOB-NUM-APOLICE */
                _.Display($"NUM-APOLICE     = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_APOLICE}");

                /*" -1636- DISPLAY 'NUM-ENDOSSO     = ' MOVIMCOB-NUM-ENDOSSO */
                _.Display($"NUM-ENDOSSO     = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_ENDOSSO}");

                /*" -1637- DISPLAY 'NUM-PARCELA     = ' MOVIMCOB-NUM-PARCELA */
                _.Display($"NUM-PARCELA     = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_PARCELA}");

                /*" -1638- DISPLAY 'COD-MOVIMENTO   = ' MOVIMCOB-COD-MOVIMENTO */
                _.Display($"COD-MOVIMENTO   = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_MOVIMENTO}");

                /*" -1639- DISPLAY 'NOME-SEGURADO   = ' MOVIMCOB-NOME-SEGURADO */
                _.Display($"NOME-SEGURADO   = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NOME_SEGURADO}");

                /*" -1640- DISPLAY 'COD-PESSOA      = ' PESSOA-COD-PESSOA */
                _.Display($"COD-PESSOA      = {PESSOA.DCLPESSOA.PESSOA_COD_PESSOA}");

                /*" -1641- DISPLAY 'NOME PESSOA     = ' PESSOA-NOME-PESSOA */
                _.Display($"NOME PESSOA     = {PESSOA.DCLPESSOA.PESSOA_NOME_PESSOA}");

                /*" -1641- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1150-00-INSERT-PESSOA-DB-SELECT-1 */
        public void R1150_00_INSERT_PESSOA_DB_SELECT_1()
        {
            /*" -1586- EXEC SQL SELECT VALUE(MAX(COD_PESSOA),0) INTO :PESSOA-COD-PESSOA FROM SEGUROS.PESSOA END-EXEC. */

            var r1150_00_INSERT_PESSOA_DB_SELECT_1_Query1 = new R1150_00_INSERT_PESSOA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R1150_00_INSERT_PESSOA_DB_SELECT_1_Query1.Execute(r1150_00_INSERT_PESSOA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PESSOA_COD_PESSOA, PESSOA.DCLPESSOA.PESSOA_COD_PESSOA);
            }


        }

        [StopWatch]
        /*" R1150-00-INSERT-PESSOA-DB-INSERT-1 */
        public void R1150_00_INSERT_PESSOA_DB_INSERT_1()
        {
            /*" -1623- EXEC SQL INSERT INTO SEGUROS.PESSOA VALUES (:PESSOA-COD-PESSOA , :PESSOA-NOME-PESSOA , CURRENT TIMESTAMP , :PESSOA-COD-USUARIO , :PESSOA-TIPO-PESSOA , NULL) END-EXEC. */

            var r1150_00_INSERT_PESSOA_DB_INSERT_1_Insert1 = new R1150_00_INSERT_PESSOA_DB_INSERT_1_Insert1()
            {
                PESSOA_COD_PESSOA = PESSOA.DCLPESSOA.PESSOA_COD_PESSOA.ToString(),
                PESSOA_NOME_PESSOA = PESSOA.DCLPESSOA.PESSOA_NOME_PESSOA.ToString(),
                PESSOA_COD_USUARIO = PESSOA.DCLPESSOA.PESSOA_COD_USUARIO.ToString(),
                PESSOA_TIPO_PESSOA = PESSOA.DCLPESSOA.PESSOA_TIPO_PESSOA.ToString(),
            };

            R1150_00_INSERT_PESSOA_DB_INSERT_1_Insert1.Execute(r1150_00_INSERT_PESSOA_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1150_99_SAIDA*/

        [StopWatch]
        /*" R1160-00-INSERT-PESSOA-FISICA-SECTION */
        private void R1160_00_INSERT_PESSOA_FISICA_SECTION()
        {
            /*" -1654- MOVE '1160' TO WNR-EXEC-SQL. */
            _.Move("1160", AUX_RELATORIO.WABEND.WNR_EXEC_SQL);

            /*" -1655- MOVE PESSOA-COD-PESSOA TO PESSOFIS-COD-PESSOA. */
            _.Move(PESSOA.DCLPESSOA.PESSOA_COD_PESSOA, PESSOFIS.DCLPESSOA_FISICA.PESSOFIS_COD_PESSOA);

            /*" -1656- MOVE CLIENTES-CGCCPF TO PESSOFIS-CPF. */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF, PESSOFIS.DCLPESSOA_FISICA.PESSOFIS_CPF);

            /*" -1657- MOVE CLIENTES-DATA-NASCIMENTO TO PESSOFIS-DATA-NASCIMENTO. */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_DATA_NASCIMENTO, PESSOFIS.DCLPESSOA_FISICA.PESSOFIS_DATA_NASCIMENTO);

            /*" -1658- MOVE CLIENTES-IDE-SEXO TO PESSOFIS-SEXO. */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_IDE_SEXO, PESSOFIS.DCLPESSOA_FISICA.PESSOFIS_SEXO);

            /*" -1659- MOVE PESSOA-COD-USUARIO TO PESSOFIS-COD-USUARIO. */
            _.Move(PESSOA.DCLPESSOA.PESSOA_COD_USUARIO, PESSOFIS.DCLPESSOA_FISICA.PESSOFIS_COD_USUARIO);

            /*" -1660- MOVE SPACES TO PESSOFIS-TIPO-IDENT-SIVPF. */
            _.Move("", PESSOFIS.DCLPESSOA_FISICA.PESSOFIS_TIPO_IDENT_SIVPF);

            /*" -1661- MOVE ZEROS TO PESSOFIS-NUM-IDENTIDADE. */
            _.Move(0, PESSOFIS.DCLPESSOA_FISICA.PESSOFIS_NUM_IDENTIDADE);

            /*" -1662- MOVE SPACES TO PESSOFIS-UF-EXPEDIDORA. */
            _.Move("", PESSOFIS.DCLPESSOA_FISICA.PESSOFIS_UF_EXPEDIDORA);

            /*" -1663- MOVE SPACES TO PESSOFIS-ORGAO-EXPEDIDOR. */
            _.Move("", PESSOFIS.DCLPESSOA_FISICA.PESSOFIS_ORGAO_EXPEDIDOR);

            /*" -1664- MOVE SISTEMAS-DATA-MOV-ABERTO TO PESSOFIS-DATA-EXPEDICAO. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, PESSOFIS.DCLPESSOA_FISICA.PESSOFIS_DATA_EXPEDICAO);

            /*" -1665- MOVE ZEROS TO PESSOFIS-COD-CBO. */
            _.Move(0, PESSOFIS.DCLPESSOA_FISICA.PESSOFIS_COD_CBO);

            /*" -1666- MOVE CLIENTES-ESTADO-CIVIL TO PESSOFIS-ESTADO-CIVIL. */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_ESTADO_CIVIL, PESSOFIS.DCLPESSOA_FISICA.PESSOFIS_ESTADO_CIVIL);

            /*" -1674- MOVE ZEROS TO VIND-NUM-IDENT VIND-ORGAO-EXP VIND-UF-EXP VIND-DTEXPEDI VIND-COD-CBO VIND-TP-IDENT. */
            _.Move(0, VIND_NUM_IDENT, VIND_ORGAO_EXP, VIND_UF_EXP, VIND_DTEXPEDI, VIND_COD_CBO, VIND_TP_IDENT);

            /*" -1689- PERFORM R1160_00_INSERT_PESSOA_FISICA_DB_INSERT_1 */

            R1160_00_INSERT_PESSOA_FISICA_DB_INSERT_1();

            /*" -1693- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1694- DISPLAY 'R1160-00 - PROBLEMAS INSERT  (PESSOFIS)   ' */
                _.Display($"R1160-00 - PROBLEMAS INSERT  (PESSOFIS)   ");

                /*" -1695- DISPLAY 'SIT-REGISTRO    = ' MOVIMCOB-SIT-REGISTRO */
                _.Display($"SIT-REGISTRO    = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_SIT_REGISTRO}");

                /*" -1696- DISPLAY 'COD-BANCO       = ' MOVIMCOB-COD-BANCO */
                _.Display($"COD-BANCO       = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_BANCO}");

                /*" -1697- DISPLAY 'COD-AGENCIA     = ' MOVIMCOB-COD-AGENCIA */
                _.Display($"COD-AGENCIA     = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_AGENCIA}");

                /*" -1698- DISPLAY 'NUM-AVISO       = ' MOVIMCOB-NUM-AVISO */
                _.Display($"NUM-AVISO       = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_AVISO}");

                /*" -1699- DISPLAY 'NUM-FITA        = ' MOVIMCOB-NUM-FITA */
                _.Display($"NUM-FITA        = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_FITA}");

                /*" -1700- DISPLAY 'NUM-NOSSO-TITULO= ' MOVIMCOB-NUM-NOSSO-TITULO */
                _.Display($"NUM-NOSSO-TITULO= {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_NOSSO_TITULO}");

                /*" -1701- DISPLAY 'NUM-APOLICE     = ' MOVIMCOB-NUM-APOLICE */
                _.Display($"NUM-APOLICE     = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_APOLICE}");

                /*" -1702- DISPLAY 'NUM-ENDOSSO     = ' MOVIMCOB-NUM-ENDOSSO */
                _.Display($"NUM-ENDOSSO     = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_ENDOSSO}");

                /*" -1703- DISPLAY 'NUM-PARCELA     = ' MOVIMCOB-NUM-PARCELA */
                _.Display($"NUM-PARCELA     = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_PARCELA}");

                /*" -1704- DISPLAY 'COD-MOVIMENTO   = ' MOVIMCOB-COD-MOVIMENTO */
                _.Display($"COD-MOVIMENTO   = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_MOVIMENTO}");

                /*" -1705- DISPLAY 'NOME-SEGURADO   = ' MOVIMCOB-NOME-SEGURADO */
                _.Display($"NOME-SEGURADO   = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NOME_SEGURADO}");

                /*" -1706- DISPLAY 'COD-PESSOA      = ' PESSOA-COD-PESSOA */
                _.Display($"COD-PESSOA      = {PESSOA.DCLPESSOA.PESSOA_COD_PESSOA}");

                /*" -1707- DISPLAY 'NOME PESSOA     = ' PESSOA-NOME-PESSOA */
                _.Display($"NOME PESSOA     = {PESSOA.DCLPESSOA.PESSOA_NOME_PESSOA}");

                /*" -1707- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1160-00-INSERT-PESSOA-FISICA-DB-INSERT-1 */
        public void R1160_00_INSERT_PESSOA_FISICA_DB_INSERT_1()
        {
            /*" -1689- EXEC SQL INSERT INTO SEGUROS.PESSOA_FISICA VALUES (:PESSOFIS-COD-PESSOA , :PESSOFIS-CPF , :PESSOFIS-DATA-NASCIMENTO , :PESSOFIS-SEXO , :PESSOFIS-COD-USUARIO , :PESSOFIS-ESTADO-CIVIL , CURRENT TIMESTAMP , :PESSOFIS-NUM-IDENTIDADE:VIND-NUM-IDENT , :PESSOFIS-ORGAO-EXPEDIDOR:VIND-ORGAO-EXP , :PESSOFIS-UF-EXPEDIDORA:VIND-UF-EXP , :PESSOFIS-DATA-EXPEDICAO:VIND-DTEXPEDI , :PESSOFIS-COD-CBO:VIND-COD-CBO , :PESSOFIS-TIPO-IDENT-SIVPF:VIND-TP-IDENT) END-EXEC. */

            var r1160_00_INSERT_PESSOA_FISICA_DB_INSERT_1_Insert1 = new R1160_00_INSERT_PESSOA_FISICA_DB_INSERT_1_Insert1()
            {
                PESSOFIS_COD_PESSOA = PESSOFIS.DCLPESSOA_FISICA.PESSOFIS_COD_PESSOA.ToString(),
                PESSOFIS_CPF = PESSOFIS.DCLPESSOA_FISICA.PESSOFIS_CPF.ToString(),
                PESSOFIS_DATA_NASCIMENTO = PESSOFIS.DCLPESSOA_FISICA.PESSOFIS_DATA_NASCIMENTO.ToString(),
                PESSOFIS_SEXO = PESSOFIS.DCLPESSOA_FISICA.PESSOFIS_SEXO.ToString(),
                PESSOFIS_COD_USUARIO = PESSOFIS.DCLPESSOA_FISICA.PESSOFIS_COD_USUARIO.ToString(),
                PESSOFIS_ESTADO_CIVIL = PESSOFIS.DCLPESSOA_FISICA.PESSOFIS_ESTADO_CIVIL.ToString(),
                PESSOFIS_NUM_IDENTIDADE = PESSOFIS.DCLPESSOA_FISICA.PESSOFIS_NUM_IDENTIDADE.ToString(),
                VIND_NUM_IDENT = VIND_NUM_IDENT.ToString(),
                PESSOFIS_ORGAO_EXPEDIDOR = PESSOFIS.DCLPESSOA_FISICA.PESSOFIS_ORGAO_EXPEDIDOR.ToString(),
                VIND_ORGAO_EXP = VIND_ORGAO_EXP.ToString(),
                PESSOFIS_UF_EXPEDIDORA = PESSOFIS.DCLPESSOA_FISICA.PESSOFIS_UF_EXPEDIDORA.ToString(),
                VIND_UF_EXP = VIND_UF_EXP.ToString(),
                PESSOFIS_DATA_EXPEDICAO = PESSOFIS.DCLPESSOA_FISICA.PESSOFIS_DATA_EXPEDICAO.ToString(),
                VIND_DTEXPEDI = VIND_DTEXPEDI.ToString(),
                PESSOFIS_COD_CBO = PESSOFIS.DCLPESSOA_FISICA.PESSOFIS_COD_CBO.ToString(),
                VIND_COD_CBO = VIND_COD_CBO.ToString(),
                PESSOFIS_TIPO_IDENT_SIVPF = PESSOFIS.DCLPESSOA_FISICA.PESSOFIS_TIPO_IDENT_SIVPF.ToString(),
                VIND_TP_IDENT = VIND_TP_IDENT.ToString(),
            };

            R1160_00_INSERT_PESSOA_FISICA_DB_INSERT_1_Insert1.Execute(r1160_00_INSERT_PESSOA_FISICA_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1160_99_SAIDA*/

        [StopWatch]
        /*" R1200-00-SELECT-RTPRELAC-SECTION */
        private void R1200_00_SELECT_RTPRELAC_SECTION()
        {
            /*" -1720- MOVE '1200' TO WNR-EXEC-SQL. */
            _.Move("1200", AUX_RELATORIO.WABEND.WNR_EXEC_SQL);

            /*" -1723- MOVE PESSOFIS-COD-PESSOA TO COD-PESSOA OF DCLR-PESSOA-TIPORELAC. */
            _.Move(PESSOFIS.DCLPESSOA_FISICA.PESSOFIS_COD_PESSOA, RTPRELAC.DCLR_PESSOA_TIPORELAC.COD_PESSOA);

            /*" -1727- MOVE 4 TO COD-RELAC OF DCLR-PESSOA-TIPORELAC. */
            _.Move(4, RTPRELAC.DCLR_PESSOA_TIPORELAC.COD_RELAC);

            /*" -1735- PERFORM R1200_00_SELECT_RTPRELAC_DB_SELECT_1 */

            R1200_00_SELECT_RTPRELAC_DB_SELECT_1();

            /*" -1739- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1740- MOVE 'N' TO WTEM-RELACAO */
                _.Move("N", W.WTEM_RELACAO);

                /*" -1743- GO TO R1200-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1744- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1745- DISPLAY 'R1200-00 - PROBLEMAS SELECT  (RTPRELAC)   ' */
                _.Display($"R1200-00 - PROBLEMAS SELECT  (RTPRELAC)   ");

                /*" -1746- DISPLAY 'SIT-REGISTRO    = ' MOVIMCOB-SIT-REGISTRO */
                _.Display($"SIT-REGISTRO    = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_SIT_REGISTRO}");

                /*" -1747- DISPLAY 'COD-BANCO       = ' MOVIMCOB-COD-BANCO */
                _.Display($"COD-BANCO       = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_BANCO}");

                /*" -1748- DISPLAY 'COD-AGENCIA     = ' MOVIMCOB-COD-AGENCIA */
                _.Display($"COD-AGENCIA     = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_AGENCIA}");

                /*" -1749- DISPLAY 'NUM-AVISO       = ' MOVIMCOB-NUM-AVISO */
                _.Display($"NUM-AVISO       = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_AVISO}");

                /*" -1750- DISPLAY 'NUM-FITA        = ' MOVIMCOB-NUM-FITA */
                _.Display($"NUM-FITA        = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_FITA}");

                /*" -1751- DISPLAY 'NUM-NOSSO-TITULO= ' MOVIMCOB-NUM-NOSSO-TITULO */
                _.Display($"NUM-NOSSO-TITULO= {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_NOSSO_TITULO}");

                /*" -1752- DISPLAY 'NUM-APOLICE     = ' MOVIMCOB-NUM-APOLICE */
                _.Display($"NUM-APOLICE     = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_APOLICE}");

                /*" -1753- DISPLAY 'NUM-ENDOSSO     = ' MOVIMCOB-NUM-ENDOSSO */
                _.Display($"NUM-ENDOSSO     = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_ENDOSSO}");

                /*" -1754- DISPLAY 'NUM-PARCELA     = ' MOVIMCOB-NUM-PARCELA */
                _.Display($"NUM-PARCELA     = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_PARCELA}");

                /*" -1755- DISPLAY 'COD-MOVIMENTO   = ' MOVIMCOB-COD-MOVIMENTO */
                _.Display($"COD-MOVIMENTO   = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_MOVIMENTO}");

                /*" -1756- DISPLAY 'NOME-SEGURADO   = ' MOVIMCOB-NOME-SEGURADO */
                _.Display($"NOME-SEGURADO   = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NOME_SEGURADO}");

                /*" -1757- DISPLAY 'COD-PESSOA      = ' DCLR-PESSOA-TIPORELAC */
                _.Display($"COD-PESSOA      = {RTPRELAC.DCLR_PESSOA_TIPORELAC}");

                /*" -1757- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1200-00-SELECT-RTPRELAC-DB-SELECT-1 */
        public void R1200_00_SELECT_RTPRELAC_DB_SELECT_1()
        {
            /*" -1735- EXEC SQL SELECT COD_PESSOA , COD_RELAC INTO :DCLR-PESSOA-TIPORELAC.COD-PESSOA , :DCLR-PESSOA-TIPORELAC.COD-RELAC FROM SEGUROS.R_PESSOA_TIPORELAC WHERE COD_PESSOA = :DCLR-PESSOA-TIPORELAC.COD-PESSOA AND COD_RELAC = :DCLR-PESSOA-TIPORELAC.COD-RELAC END-EXEC. */

            var r1200_00_SELECT_RTPRELAC_DB_SELECT_1_Query1 = new R1200_00_SELECT_RTPRELAC_DB_SELECT_1_Query1()
            {
                COD_PESSOA = RTPRELAC.DCLR_PESSOA_TIPORELAC.COD_PESSOA.ToString(),
                COD_RELAC = RTPRELAC.DCLR_PESSOA_TIPORELAC.COD_RELAC.ToString(),
            };

            var executed_1 = R1200_00_SELECT_RTPRELAC_DB_SELECT_1_Query1.Execute(r1200_00_SELECT_RTPRELAC_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.COD_PESSOA, RTPRELAC.DCLR_PESSOA_TIPORELAC.COD_PESSOA);
                _.Move(executed_1.COD_RELAC, RTPRELAC.DCLR_PESSOA_TIPORELAC.COD_RELAC);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/

        [StopWatch]
        /*" R1250-00-INSERT-RTPRELAC-SECTION */
        private void R1250_00_INSERT_RTPRELAC_SECTION()
        {
            /*" -1770- MOVE '1250' TO WNR-EXEC-SQL. */
            _.Move("1250", AUX_RELATORIO.WABEND.WNR_EXEC_SQL);

            /*" -1773- MOVE PESSOFIS-COD-PESSOA TO COD-PESSOA OF DCLR-PESSOA-TIPORELAC. */
            _.Move(PESSOFIS.DCLPESSOA_FISICA.PESSOFIS_COD_PESSOA, RTPRELAC.DCLR_PESSOA_TIPORELAC.COD_PESSOA);

            /*" -1777- MOVE 4 TO COD-RELAC OF DCLR-PESSOA-TIPORELAC. */
            _.Move(4, RTPRELAC.DCLR_PESSOA_TIPORELAC.COD_RELAC);

            /*" -1781- PERFORM R1250_00_INSERT_RTPRELAC_DB_INSERT_1 */

            R1250_00_INSERT_RTPRELAC_DB_INSERT_1();

            /*" -1785- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1786- DISPLAY 'R1250-00 - PROBLEMAS INSERT  (RTPRELAC)   ' */
                _.Display($"R1250-00 - PROBLEMAS INSERT  (RTPRELAC)   ");

                /*" -1787- DISPLAY 'SIT-REGISTRO    = ' MOVIMCOB-SIT-REGISTRO */
                _.Display($"SIT-REGISTRO    = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_SIT_REGISTRO}");

                /*" -1788- DISPLAY 'COD-BANCO       = ' MOVIMCOB-COD-BANCO */
                _.Display($"COD-BANCO       = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_BANCO}");

                /*" -1789- DISPLAY 'COD-AGENCIA     = ' MOVIMCOB-COD-AGENCIA */
                _.Display($"COD-AGENCIA     = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_AGENCIA}");

                /*" -1790- DISPLAY 'NUM-AVISO       = ' MOVIMCOB-NUM-AVISO */
                _.Display($"NUM-AVISO       = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_AVISO}");

                /*" -1791- DISPLAY 'NUM-FITA        = ' MOVIMCOB-NUM-FITA */
                _.Display($"NUM-FITA        = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_FITA}");

                /*" -1792- DISPLAY 'NUM-NOSSO-TITULO= ' MOVIMCOB-NUM-NOSSO-TITULO */
                _.Display($"NUM-NOSSO-TITULO= {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_NOSSO_TITULO}");

                /*" -1793- DISPLAY 'NUM-APOLICE     = ' MOVIMCOB-NUM-APOLICE */
                _.Display($"NUM-APOLICE     = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_APOLICE}");

                /*" -1794- DISPLAY 'NUM-ENDOSSO     = ' MOVIMCOB-NUM-ENDOSSO */
                _.Display($"NUM-ENDOSSO     = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_ENDOSSO}");

                /*" -1795- DISPLAY 'NUM-PARCELA     = ' MOVIMCOB-NUM-PARCELA */
                _.Display($"NUM-PARCELA     = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_PARCELA}");

                /*" -1796- DISPLAY 'COD-MOVIMENTO   = ' MOVIMCOB-COD-MOVIMENTO */
                _.Display($"COD-MOVIMENTO   = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_MOVIMENTO}");

                /*" -1797- DISPLAY 'NOME-SEGURADO   = ' MOVIMCOB-NOME-SEGURADO */
                _.Display($"NOME-SEGURADO   = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NOME_SEGURADO}");

                /*" -1798- DISPLAY 'COD-PESSOA      = ' DCLR-PESSOA-TIPORELAC */
                _.Display($"COD-PESSOA      = {RTPRELAC.DCLR_PESSOA_TIPORELAC}");

                /*" -1798- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1250-00-INSERT-RTPRELAC-DB-INSERT-1 */
        public void R1250_00_INSERT_RTPRELAC_DB_INSERT_1()
        {
            /*" -1781- EXEC SQL INSERT INTO SEGUROS.R_PESSOA_TIPORELAC VALUES (:DCLR-PESSOA-TIPORELAC.COD-PESSOA, :DCLR-PESSOA-TIPORELAC.COD-RELAC) END-EXEC. */

            var r1250_00_INSERT_RTPRELAC_DB_INSERT_1_Insert1 = new R1250_00_INSERT_RTPRELAC_DB_INSERT_1_Insert1()
            {
                COD_PESSOA = RTPRELAC.DCLR_PESSOA_TIPORELAC.COD_PESSOA.ToString(),
                COD_RELAC = RTPRELAC.DCLR_PESSOA_TIPORELAC.COD_RELAC.ToString(),
            };

            R1250_00_INSERT_RTPRELAC_DB_INSERT_1_Insert1.Execute(r1250_00_INSERT_RTPRELAC_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1250_99_SAIDA*/

        [StopWatch]
        /*" R1350-00-INSERT-IDENTREL-SECTION */
        private void R1350_00_INSERT_IDENTREL_SECTION()
        {
            /*" -1811- MOVE '1350' TO WNR-EXEC-SQL. */
            _.Move("1350", AUX_RELATORIO.WABEND.WNR_EXEC_SQL);

            /*" -1815- PERFORM R1350_00_INSERT_IDENTREL_DB_SELECT_1 */

            R1350_00_INSERT_IDENTREL_DB_SELECT_1();

            /*" -1819- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1820- DISPLAY 'R1350-00 - PROBLEMAS SELECT  (IDENTREL)   ' */
                _.Display($"R1350-00 - PROBLEMAS SELECT  (IDENTREL)   ");

                /*" -1821- DISPLAY 'SIT-REGISTRO    = ' MOVIMCOB-SIT-REGISTRO */
                _.Display($"SIT-REGISTRO    = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_SIT_REGISTRO}");

                /*" -1822- DISPLAY 'COD-BANCO       = ' MOVIMCOB-COD-BANCO */
                _.Display($"COD-BANCO       = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_BANCO}");

                /*" -1823- DISPLAY 'COD-AGENCIA     = ' MOVIMCOB-COD-AGENCIA */
                _.Display($"COD-AGENCIA     = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_AGENCIA}");

                /*" -1824- DISPLAY 'NUM-AVISO       = ' MOVIMCOB-NUM-AVISO */
                _.Display($"NUM-AVISO       = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_AVISO}");

                /*" -1825- DISPLAY 'NUM-FITA        = ' MOVIMCOB-NUM-FITA */
                _.Display($"NUM-FITA        = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_FITA}");

                /*" -1826- DISPLAY 'NUM-NOSSO-TITULO= ' MOVIMCOB-NUM-NOSSO-TITULO */
                _.Display($"NUM-NOSSO-TITULO= {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_NOSSO_TITULO}");

                /*" -1827- DISPLAY 'NUM-APOLICE     = ' MOVIMCOB-NUM-APOLICE */
                _.Display($"NUM-APOLICE     = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_APOLICE}");

                /*" -1828- DISPLAY 'NUM-ENDOSSO     = ' MOVIMCOB-NUM-ENDOSSO */
                _.Display($"NUM-ENDOSSO     = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_ENDOSSO}");

                /*" -1829- DISPLAY 'NUM-PARCELA     = ' MOVIMCOB-NUM-PARCELA */
                _.Display($"NUM-PARCELA     = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_PARCELA}");

                /*" -1830- DISPLAY 'COD-MOVIMENTO   = ' MOVIMCOB-COD-MOVIMENTO */
                _.Display($"COD-MOVIMENTO   = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_MOVIMENTO}");

                /*" -1831- DISPLAY 'NOME-SEGURADO   = ' MOVIMCOB-NOME-SEGURADO */
                _.Display($"NOME-SEGURADO   = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NOME_SEGURADO}");

                /*" -1834- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1836- ADD 1 TO IDENTREL-NUM-IDENTIFICACAO. */
            IDENTREL.DCLIDENTIFICA_RELAC.IDENTREL_NUM_IDENTIFICACAO.Value = IDENTREL.DCLIDENTIFICA_RELAC.IDENTREL_NUM_IDENTIFICACAO + 1;

            /*" -1838- MOVE PESSOFIS-COD-PESSOA TO IDENTREL-COD-PESSOA. */
            _.Move(PESSOFIS.DCLPESSOA_FISICA.PESSOFIS_COD_PESSOA, IDENTREL.DCLIDENTIFICA_RELAC.IDENTREL_COD_PESSOA);

            /*" -1840- MOVE 4 TO IDENTREL-COD-RELAC. */
            _.Move(4, IDENTREL.DCLIDENTIFICA_RELAC.IDENTREL_COD_RELAC);

            /*" -1844- MOVE 'BI6252B' TO IDENTREL-COD-USUARIO. */
            _.Move("BI6252B", IDENTREL.DCLIDENTIFICA_RELAC.IDENTREL_COD_USUARIO);

            /*" -1851- PERFORM R1350_00_INSERT_IDENTREL_DB_INSERT_1 */

            R1350_00_INSERT_IDENTREL_DB_INSERT_1();

            /*" -1855- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1856- DISPLAY 'R1350-00 - PROBLEMAS INSERT  (IDENTREL)   ' */
                _.Display($"R1350-00 - PROBLEMAS INSERT  (IDENTREL)   ");

                /*" -1857- DISPLAY 'SIT-REGISTRO    = ' MOVIMCOB-SIT-REGISTRO */
                _.Display($"SIT-REGISTRO    = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_SIT_REGISTRO}");

                /*" -1858- DISPLAY 'COD-BANCO       = ' MOVIMCOB-COD-BANCO */
                _.Display($"COD-BANCO       = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_BANCO}");

                /*" -1859- DISPLAY 'COD-AGENCIA     = ' MOVIMCOB-COD-AGENCIA */
                _.Display($"COD-AGENCIA     = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_AGENCIA}");

                /*" -1860- DISPLAY 'NUM-AVISO       = ' MOVIMCOB-NUM-AVISO */
                _.Display($"NUM-AVISO       = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_AVISO}");

                /*" -1861- DISPLAY 'NUM-FITA        = ' MOVIMCOB-NUM-FITA */
                _.Display($"NUM-FITA        = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_FITA}");

                /*" -1862- DISPLAY 'NUM-NOSSO-TITULO= ' MOVIMCOB-NUM-NOSSO-TITULO */
                _.Display($"NUM-NOSSO-TITULO= {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_NOSSO_TITULO}");

                /*" -1863- DISPLAY 'NUM-APOLICE     = ' MOVIMCOB-NUM-APOLICE */
                _.Display($"NUM-APOLICE     = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_APOLICE}");

                /*" -1864- DISPLAY 'NUM-ENDOSSO     = ' MOVIMCOB-NUM-ENDOSSO */
                _.Display($"NUM-ENDOSSO     = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_ENDOSSO}");

                /*" -1865- DISPLAY 'NUM-PARCELA     = ' MOVIMCOB-NUM-PARCELA */
                _.Display($"NUM-PARCELA     = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_PARCELA}");

                /*" -1866- DISPLAY 'COD-MOVIMENTO   = ' MOVIMCOB-COD-MOVIMENTO */
                _.Display($"COD-MOVIMENTO   = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_MOVIMENTO}");

                /*" -1867- DISPLAY 'NOME-SEGURADO   = ' MOVIMCOB-NOME-SEGURADO */
                _.Display($"NOME-SEGURADO   = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NOME_SEGURADO}");

                /*" -1868- DISPLAY 'COD-PESSOA      = ' PESSOA-COD-PESSOA */
                _.Display($"COD-PESSOA      = {PESSOA.DCLPESSOA.PESSOA_COD_PESSOA}");

                /*" -1869- DISPLAY 'NOME PESSOA     = ' PESSOA-NOME-PESSOA */
                _.Display($"NOME PESSOA     = {PESSOA.DCLPESSOA.PESSOA_NOME_PESSOA}");

                /*" -1869- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1350-00-INSERT-IDENTREL-DB-SELECT-1 */
        public void R1350_00_INSERT_IDENTREL_DB_SELECT_1()
        {
            /*" -1815- EXEC SQL SELECT VALUE(MAX(NUM_IDENTIFICACAO),0) INTO :IDENTREL-NUM-IDENTIFICACAO FROM SEGUROS.IDENTIFICA_RELAC END-EXEC. */

            var r1350_00_INSERT_IDENTREL_DB_SELECT_1_Query1 = new R1350_00_INSERT_IDENTREL_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R1350_00_INSERT_IDENTREL_DB_SELECT_1_Query1.Execute(r1350_00_INSERT_IDENTREL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.IDENTREL_NUM_IDENTIFICACAO, IDENTREL.DCLIDENTIFICA_RELAC.IDENTREL_NUM_IDENTIFICACAO);
            }


        }

        [StopWatch]
        /*" R1350-00-INSERT-IDENTREL-DB-INSERT-1 */
        public void R1350_00_INSERT_IDENTREL_DB_INSERT_1()
        {
            /*" -1851- EXEC SQL INSERT INTO SEGUROS.IDENTIFICA_RELAC VALUES (:IDENTREL-NUM-IDENTIFICACAO, :IDENTREL-COD-PESSOA, :IDENTREL-COD-RELAC , :IDENTREL-COD-USUARIO, CURRENT TIMESTAMP) END-EXEC. */

            var r1350_00_INSERT_IDENTREL_DB_INSERT_1_Insert1 = new R1350_00_INSERT_IDENTREL_DB_INSERT_1_Insert1()
            {
                IDENTREL_NUM_IDENTIFICACAO = IDENTREL.DCLIDENTIFICA_RELAC.IDENTREL_NUM_IDENTIFICACAO.ToString(),
                IDENTREL_COD_PESSOA = IDENTREL.DCLIDENTIFICA_RELAC.IDENTREL_COD_PESSOA.ToString(),
                IDENTREL_COD_RELAC = IDENTREL.DCLIDENTIFICA_RELAC.IDENTREL_COD_RELAC.ToString(),
                IDENTREL_COD_USUARIO = IDENTREL.DCLIDENTIFICA_RELAC.IDENTREL_COD_USUARIO.ToString(),
            };

            R1350_00_INSERT_IDENTREL_DB_INSERT_1_Insert1.Execute(r1350_00_INSERT_IDENTREL_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1350_99_SAIDA*/

        [StopWatch]
        /*" R1400-00-SELECT-FIDELIZ-SECTION */
        private void R1400_00_SELECT_FIDELIZ_SECTION()
        {
            /*" -1882- MOVE '1400' TO WNR-EXEC-SQL. */
            _.Move("1400", AUX_RELATORIO.WABEND.WNR_EXEC_SQL);

            /*" -1885- MOVE MOVIMCOB-NUM-NOSSO-TITULO TO PROPOFID-NUM-PROPOSTA-SIVPF. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_NOSSO_TITULO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF);

            /*" -1893- PERFORM R1400_00_SELECT_FIDELIZ_DB_SELECT_1 */

            R1400_00_SELECT_FIDELIZ_DB_SELECT_1();

            /*" -1896- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1897- MOVE 'N' TO WTEM-PROPOSTA */
                _.Move("N", W.WTEM_PROPOSTA);

                /*" -1900- GO TO R1400-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1400_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1901- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1902- DISPLAY 'R1400-00 - PROBLEMAS SELECT  (PROPOFID)   ' */
                _.Display($"R1400-00 - PROBLEMAS SELECT  (PROPOFID)   ");

                /*" -1903- DISPLAY 'SIT-REGISTRO    =' MOVIMCOB-SIT-REGISTRO */
                _.Display($"SIT-REGISTRO    ={MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_SIT_REGISTRO}");

                /*" -1904- DISPLAY 'COD-BANCO       =' MOVIMCOB-COD-BANCO */
                _.Display($"COD-BANCO       ={MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_BANCO}");

                /*" -1905- DISPLAY 'COD-AGENCIA     =' MOVIMCOB-COD-AGENCIA */
                _.Display($"COD-AGENCIA     ={MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_AGENCIA}");

                /*" -1906- DISPLAY 'NUM-AVISO       =' MOVIMCOB-NUM-AVISO */
                _.Display($"NUM-AVISO       ={MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_AVISO}");

                /*" -1907- DISPLAY 'NUM-FITA        =' MOVIMCOB-NUM-FITA */
                _.Display($"NUM-FITA        ={MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_FITA}");

                /*" -1908- DISPLAY 'NUM-NOSSO-TITULO=' MOVIMCOB-NUM-NOSSO-TITULO */
                _.Display($"NUM-NOSSO-TITULO={MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_NOSSO_TITULO}");

                /*" -1909- DISPLAY 'NUM-APOLICE     =' MOVIMCOB-NUM-APOLICE */
                _.Display($"NUM-APOLICE     ={MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_APOLICE}");

                /*" -1910- DISPLAY 'NUM-ENDOSSO     =' MOVIMCOB-NUM-ENDOSSO */
                _.Display($"NUM-ENDOSSO     ={MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_ENDOSSO}");

                /*" -1911- DISPLAY 'NUM-PARCELA     =' MOVIMCOB-NUM-PARCELA */
                _.Display($"NUM-PARCELA     ={MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_PARCELA}");

                /*" -1912- DISPLAY 'COD-MOVIMENTO   =' MOVIMCOB-COD-MOVIMENTO */
                _.Display($"COD-MOVIMENTO   ={MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_MOVIMENTO}");

                /*" -1913- DISPLAY 'NOME-SEGURADO   =' MOVIMCOB-NOME-SEGURADO */
                _.Display($"NOME-SEGURADO   ={MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NOME_SEGURADO}");

                /*" -1913- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1400-00-SELECT-FIDELIZ-DB-SELECT-1 */
        public void R1400_00_SELECT_FIDELIZ_DB_SELECT_1()
        {
            /*" -1893- EXEC SQL SELECT NUM_PROPOSTA_SIVPF INTO :PROPOFID-NUM-PROPOSTA-SIVPF FROM SEGUROS.PROPOSTA_FIDELIZ WHERE NUM_PROPOSTA_SIVPF = :PROPOFID-NUM-PROPOSTA-SIVPF WITH UR END-EXEC. */

            var r1400_00_SELECT_FIDELIZ_DB_SELECT_1_Query1 = new R1400_00_SELECT_FIDELIZ_DB_SELECT_1_Query1()
            {
                PROPOFID_NUM_PROPOSTA_SIVPF = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF.ToString(),
            };

            var executed_1 = R1400_00_SELECT_FIDELIZ_DB_SELECT_1_Query1.Execute(r1400_00_SELECT_FIDELIZ_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PROPOFID_NUM_PROPOSTA_SIVPF, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1400_99_SAIDA*/

        [StopWatch]
        /*" R1450-00-INSERT-FIDELIZ-SECTION */
        private void R1450_00_INSERT_FIDELIZ_SECTION()
        {
            /*" -1926- MOVE '1450' TO WNR-EXEC-SQL. */
            _.Move("1450", AUX_RELATORIO.WABEND.WNR_EXEC_SQL);

            /*" -1928- MOVE MOVIMCOB-NUM-NOSSO-TITULO TO PROPOFID-NUM-PROPOSTA-SIVPF. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_NOSSO_TITULO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF);

            /*" -1930- MOVE IDENTREL-NUM-IDENTIFICACAO TO PROPOFID-NUM-IDENTIFICACAO. */
            _.Move(IDENTREL.DCLIDENTIFICA_RELAC.IDENTREL_NUM_IDENTIFICACAO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_IDENTIFICACAO);

            /*" -1932- MOVE 1 TO PROPOFID-COD-EMPRESA-SIVPF. */
            _.Move(1, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_EMPRESA_SIVPF);

            /*" -1934- MOVE PESSOFIS-COD-PESSOA TO PROPOFID-COD-PESSOA. */
            _.Move(PESSOFIS.DCLPESSOA_FISICA.PESSOFIS_COD_PESSOA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PESSOA);

            /*" -1936- MOVE BILHETE-NUM-BILHETE TO PROPOFID-NUM-SICOB. */
            _.Move(BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_SICOB);

            /*" -1938- MOVE BILHETE-DATA-VENDA TO PROPOFID-DATA-PROPOSTA. */
            _.Move(BILHETE.DCLBILHETE.BILHETE_DATA_VENDA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_PROPOSTA);

            /*" -1940- MOVE CONVERSI-COD-PRODUTO-SIVPF TO PROPOFID-COD-PRODUTO-SIVPF. */
            _.Move(CONVERSI.DCLCONVERSAO_SICOB.CONVERSI_COD_PRODUTO_SIVPF, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF);

            /*" -1942- MOVE BILHETE-AGE-COBRANCA TO PROPOFID-AGECOBR. */
            _.Move(BILHETE.DCLBILHETE.BILHETE_AGE_COBRANCA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGECOBR);

            /*" -1944- MOVE MOVIMCOB-DATA-QUITACAO TO WDATA-REL. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_DATA_QUITACAO, W.WDATA_REL);

            /*" -1947- MOVE WDAT-REL-DIA TO PROPOFID-DIA-DEBITO. */
            _.Move(W.FILLER_1.WDAT_REL_DIA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DIA_DEBITO);

            /*" -1949- MOVE 1006 TO PROPOFID-ORIGEM-PROPOSTA. */
            _.Move(1006, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_ORIGEM_PROPOSTA);

            /*" -1951- MOVE MVPAY-NRSEQREG TO PROPOFID-NSL. */
            _.Move(AUX_RELATORIO.MVPAY_NOME.MVPAY_NRSEQREG, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NSL);

            /*" -1954- MOVE '1' TO PROPOFID-OPCAOPAG. */
            _.Move("1", PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPCAOPAG);

            /*" -1956- MOVE BILHETE-COD-AGENCIA-DEB TO PROPOFID-AGECTADEB. */
            _.Move(BILHETE.DCLBILHETE.BILHETE_COD_AGENCIA_DEB, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGECTADEB);

            /*" -1958- MOVE BILHETE-OPERACAO-CONTA-DEB TO PROPOFID-OPRCTADEB. */
            _.Move(BILHETE.DCLBILHETE.BILHETE_OPERACAO_CONTA_DEB, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPRCTADEB);

            /*" -1960- MOVE BILHETE-NUM-CONTA-DEB TO PROPOFID-NUMCTADEB. */
            _.Move(BILHETE.DCLBILHETE.BILHETE_NUM_CONTA_DEB, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUMCTADEB);

            /*" -1962- MOVE BILHETE-DIG-CONTA-DEB TO PROPOFID-DIGCTADEB. */
            _.Move(BILHETE.DCLBILHETE.BILHETE_DIG_CONTA_DEB, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DIGCTADEB);

            /*" -1964- MOVE ZEROS TO PROPOFID-PERC-DESCONTO. */
            _.Move(0, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_PERC_DESCONTO);

            /*" -1966- MOVE BILHETE-NUM-MATRICULA TO PROPOFID-NRMATRVEN. */
            _.Move(BILHETE.DCLBILHETE.BILHETE_NUM_MATRICULA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NRMATRVEN);

            /*" -1968- MOVE ZEROS TO PROPOFID-PERC-DESCONTO. */
            _.Move(0, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_PERC_DESCONTO);

            /*" -1970- MOVE BILHETE-COD-AGENCIA TO PROPOFID-AGECTAVEN. */
            _.Move(BILHETE.DCLBILHETE.BILHETE_COD_AGENCIA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGECTAVEN);

            /*" -1972- MOVE BILHETE-OPERACAO-CONTA TO PROPOFID-OPRCTAVEN. */
            _.Move(BILHETE.DCLBILHETE.BILHETE_OPERACAO_CONTA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPRCTAVEN);

            /*" -1974- MOVE BILHETE-NUM-CONTA TO PROPOFID-NUMCTAVEN. */
            _.Move(BILHETE.DCLBILHETE.BILHETE_NUM_CONTA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUMCTAVEN);

            /*" -1976- MOVE BILHETE-DIG-CONTA TO PROPOFID-DIGCTAVEN. */
            _.Move(BILHETE.DCLBILHETE.BILHETE_DIG_CONTA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DIGCTAVEN);

            /*" -1978- MOVE ZEROS TO PROPOFID-CGC-CONVENENTE. */
            _.Move(0, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_CGC_CONVENENTE);

            /*" -1980- MOVE SPACES TO PROPOFID-NOME-CONVENENTE. */
            _.Move("", PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NOME_CONVENENTE);

            /*" -1982- MOVE ZEROS TO PROPOFID-NRMATRCON. */
            _.Move(0, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NRMATRCON);

            /*" -1984- MOVE MOVIMCOB-DATA-QUITACAO TO PROPOFID-DTQITBCO. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_DATA_QUITACAO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DTQITBCO);

            /*" -1986- MOVE MOVIMCOB-VAL-TITULO TO PROPOFID-VAL-PAGO. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_VAL_TITULO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_VAL_PAGO);

            /*" -1988- MOVE ZEROS TO PROPOFID-AGEPGTO. */
            _.Move(0, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGEPGTO);

            /*" -1990- MOVE ZEROS TO PROPOFID-VAL-TARIFA. */
            _.Move(0, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_VAL_TARIFA);

            /*" -1992- MOVE ZEROS TO PROPOFID-VAL-IOF. */
            _.Move(0, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_VAL_IOF);

            /*" -1994- MOVE MOVIMCOB-DATA-QUITACAO TO PROPOFID-DATA-CREDITO. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_DATA_QUITACAO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_CREDITO);

            /*" -1996- MOVE ZEROS TO PROPOFID-VAL-COMISSAO. */
            _.Move(0, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_VAL_COMISSAO);

            /*" -1998- MOVE 'BI6252B' TO PROPOFID-COD-USUARIO. */
            _.Move("BI6252B", PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_USUARIO);

            /*" -2000- MOVE 9 TO PROPOFID-CANAL-PROPOSTA. */
            _.Move(9, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_CANAL_PROPOSTA);

            /*" -2002- MOVE ZEROS TO PROPOFID-NSAS-SIVPF. */
            _.Move(0, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NSAS_SIVPF);

            /*" -2004- MOVE MOVIMCOB-NUM-FITA TO PROPOFID-NSAC-SIVPF. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_FITA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NSAC_SIVPF);

            /*" -2006- MOVE 'S' TO PROPOFID-SITUACAO-ENVIO. */
            _.Move("S", PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_SITUACAO_ENVIO);

            /*" -2008- MOVE BILHETE-OPC-COBERTURA TO PROPOFID-OPCAO-COBER. */
            _.Move(BILHETE.DCLBILHETE.BILHETE_OPC_COBERTURA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPCAO_COBER);

            /*" -2010- MOVE ZEROS TO PROPOFID-COD-PLANO. */
            _.Move(0, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PLANO);

            /*" -2012- MOVE SPACES TO PROPOFID-NOME-CONJUGE. */
            _.Move("", PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NOME_CONJUGE);

            /*" -2014- MOVE SPACES TO PROPOFID-DATA-NASC-CONJUGE. */
            _.Move("", PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_NASC_CONJUGE);

            /*" -2016- MOVE ZEROS TO PROPOFID-PROFISSAO-CONJUGE. */
            _.Move(0, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_PROFISSAO_CONJUGE);

            /*" -2018- MOVE 1 TO PROPOFID-FAIXA-RENDA-IND. */
            _.Move(1, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_FAIXA_RENDA_IND);

            /*" -2020- MOVE 1 TO PROPOFID-FAIXA-RENDA-FAM. */
            _.Move(1, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_FAIXA_RENDA_FAM);

            /*" -2022- MOVE -1 TO VIND-DTNASC-ESPOSA. */
            _.Move(-1, VIND_DTNASC_ESPOSA);

            /*" -2024- MOVE ZEROS TO VIND-CBO-CONJ. */
            _.Move(0, VIND_CBO_CONJ);

            /*" -2027- MOVE 'N' TO PROPOFID-IND-TIPO-CONTA. */
            _.Move("N", PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_IND_TIPO_CONTA);

            /*" -2129- PERFORM R1450_00_INSERT_FIDELIZ_DB_INSERT_1 */

            R1450_00_INSERT_FIDELIZ_DB_INSERT_1();

            /*" -2132- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2133- DISPLAY 'R1450-00 - PROBLEMAS INSERT  (PROPOFID)   ' */
                _.Display($"R1450-00 - PROBLEMAS INSERT  (PROPOFID)   ");

                /*" -2134- DISPLAY 'SIT-REGISTRO    = ' MOVIMCOB-SIT-REGISTRO */
                _.Display($"SIT-REGISTRO    = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_SIT_REGISTRO}");

                /*" -2135- DISPLAY 'COD-BANCO       = ' MOVIMCOB-COD-BANCO */
                _.Display($"COD-BANCO       = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_BANCO}");

                /*" -2136- DISPLAY 'COD-AGENCIA     = ' MOVIMCOB-COD-AGENCIA */
                _.Display($"COD-AGENCIA     = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_AGENCIA}");

                /*" -2137- DISPLAY 'NUM-AVISO       = ' MOVIMCOB-NUM-AVISO */
                _.Display($"NUM-AVISO       = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_AVISO}");

                /*" -2138- DISPLAY 'NUM-FITA        = ' MOVIMCOB-NUM-FITA */
                _.Display($"NUM-FITA        = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_FITA}");

                /*" -2139- DISPLAY 'NUM-NOSSO-TITULO= ' MOVIMCOB-NUM-NOSSO-TITULO */
                _.Display($"NUM-NOSSO-TITULO= {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_NOSSO_TITULO}");

                /*" -2140- DISPLAY 'NUM-APOLICE     = ' MOVIMCOB-NUM-APOLICE */
                _.Display($"NUM-APOLICE     = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_APOLICE}");

                /*" -2141- DISPLAY 'NUM-ENDOSSO     = ' MOVIMCOB-NUM-ENDOSSO */
                _.Display($"NUM-ENDOSSO     = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_ENDOSSO}");

                /*" -2142- DISPLAY 'NUM-PARCELA     = ' MOVIMCOB-NUM-PARCELA */
                _.Display($"NUM-PARCELA     = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_PARCELA}");

                /*" -2143- DISPLAY 'COD-MOVIMENTO   = ' MOVIMCOB-COD-MOVIMENTO */
                _.Display($"COD-MOVIMENTO   = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_MOVIMENTO}");

                /*" -2144- DISPLAY 'NOME-SEGURADO   = ' MOVIMCOB-NOME-SEGURADO */
                _.Display($"NOME-SEGURADO   = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NOME_SEGURADO}");

                /*" -2145- DISPLAY 'IDENTIFICACAO   = ' PROPOFID-NUM-IDENTIFICACAO */
                _.Display($"IDENTIFICACAO   = {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_IDENTIFICACAO}");

                /*" -2145- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1450-00-INSERT-FIDELIZ-DB-INSERT-1 */
        public void R1450_00_INSERT_FIDELIZ_DB_INSERT_1()
        {
            /*" -2129- EXEC SQL INSERT INTO SEGUROS.PROPOSTA_FIDELIZ ( NUM_PROPOSTA_SIVPF ,NUM_IDENTIFICACAO ,COD_EMPRESA_SIVPF ,COD_PESSOA ,NUM_SICOB ,DATA_PROPOSTA ,COD_PRODUTO_SIVPF ,AGECOBR ,DIA_DEBITO ,OPCAOPAG ,AGECTADEB ,OPRCTADEB ,NUMCTADEB ,DIGCTADEB ,PERC_DESCONTO ,NRMATRVEN ,AGECTAVEN ,OPRCTAVEN ,NUMCTAVEN ,DIGCTAVEN ,CGC_CONVENENTE ,NOME_CONVENENTE ,NRMATRCON ,DTQITBCO ,VAL_PAGO ,AGEPGTO ,VAL_TARIFA ,VAL_IOF ,DATA_CREDITO ,VAL_COMISSAO ,SIT_PROPOSTA ,COD_USUARIO ,CANAL_PROPOSTA ,NSAS_SIVPF ,ORIGEM_PROPOSTA ,TIMESTAMP ,NSL ,NSAC_SIVPF ,SITUACAO_ENVIO ,OPCAO_COBER ,COD_PLANO ,NOME_CONJUGE ,DATA_NASC_CONJUGE ,PROFISSAO_CONJUGE ,FAIXA_RENDA_IND ,FAIXA_RENDA_FAM ,IND_TP_PROPOSTA ,IND_TIPO_CONTA ) VALUES (:PROPOFID-NUM-PROPOSTA-SIVPF, :PROPOFID-NUM-IDENTIFICACAO, :PROPOFID-COD-EMPRESA-SIVPF, :PROPOFID-COD-PESSOA, :PROPOFID-NUM-SICOB, :PROPOFID-DATA-PROPOSTA, :PROPOFID-COD-PRODUTO-SIVPF, :PROPOFID-AGECOBR, :PROPOFID-DIA-DEBITO, :PROPOFID-OPCAOPAG, :PROPOFID-AGECTADEB, :PROPOFID-OPRCTADEB, :PROPOFID-NUMCTADEB, :PROPOFID-DIGCTADEB, :PROPOFID-PERC-DESCONTO, :PROPOFID-NRMATRVEN, :PROPOFID-AGECTAVEN, :PROPOFID-OPRCTAVEN, :PROPOFID-NUMCTAVEN, :PROPOFID-DIGCTAVEN, :PROPOFID-CGC-CONVENENTE, :PROPOFID-NOME-CONVENENTE, :PROPOFID-NRMATRCON, :PROPOFID-DATA-PROPOSTA, :PROPOFID-VAL-PAGO, :PROPOFID-AGEPGTO, :PROPOFID-VAL-TARIFA, :PROPOFID-VAL-IOF, :PROPOFID-DATA-CREDITO, :PROPOFID-VAL-COMISSAO, :PROPOFID-SIT-PROPOSTA, :PROPOFID-COD-USUARIO, :PROPOFID-CANAL-PROPOSTA, :PROPOFID-NSAS-SIVPF, :PROPOFID-ORIGEM-PROPOSTA, CURRENT TIMESTAMP, :PROPOFID-NSL, :PROPOFID-NSAC-SIVPF, :PROPOFID-SITUACAO-ENVIO, :PROPOFID-OPCAO-COBER, :PROPOFID-COD-PLANO, :PROPOFID-NOME-CONJUGE, :PROPOFID-DATA-NASC-CONJUGE :VIND-DTNASC-ESPOSA, :PROPOFID-PROFISSAO-CONJUGE :VIND-CBO-CONJ, :PROPOFID-FAIXA-RENDA-IND, :PROPOFID-FAIXA-RENDA-FAM, NULL, :PROPOFID-IND-TIPO-CONTA ) END-EXEC. */

            var r1450_00_INSERT_FIDELIZ_DB_INSERT_1_Insert1 = new R1450_00_INSERT_FIDELIZ_DB_INSERT_1_Insert1()
            {
                PROPOFID_NUM_PROPOSTA_SIVPF = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF.ToString(),
                PROPOFID_NUM_IDENTIFICACAO = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_IDENTIFICACAO.ToString(),
                PROPOFID_COD_EMPRESA_SIVPF = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_EMPRESA_SIVPF.ToString(),
                PROPOFID_COD_PESSOA = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PESSOA.ToString(),
                PROPOFID_NUM_SICOB = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_SICOB.ToString(),
                PROPOFID_DATA_PROPOSTA = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_PROPOSTA.ToString(),
                PROPOFID_COD_PRODUTO_SIVPF = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF.ToString(),
                PROPOFID_AGECOBR = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGECOBR.ToString(),
                PROPOFID_DIA_DEBITO = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DIA_DEBITO.ToString(),
                PROPOFID_OPCAOPAG = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPCAOPAG.ToString(),
                PROPOFID_AGECTADEB = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGECTADEB.ToString(),
                PROPOFID_OPRCTADEB = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPRCTADEB.ToString(),
                PROPOFID_NUMCTADEB = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUMCTADEB.ToString(),
                PROPOFID_DIGCTADEB = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DIGCTADEB.ToString(),
                PROPOFID_PERC_DESCONTO = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_PERC_DESCONTO.ToString(),
                PROPOFID_NRMATRVEN = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NRMATRVEN.ToString(),
                PROPOFID_AGECTAVEN = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGECTAVEN.ToString(),
                PROPOFID_OPRCTAVEN = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPRCTAVEN.ToString(),
                PROPOFID_NUMCTAVEN = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUMCTAVEN.ToString(),
                PROPOFID_DIGCTAVEN = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DIGCTAVEN.ToString(),
                PROPOFID_CGC_CONVENENTE = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_CGC_CONVENENTE.ToString(),
                PROPOFID_NOME_CONVENENTE = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NOME_CONVENENTE.ToString(),
                PROPOFID_NRMATRCON = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NRMATRCON.ToString(),
                PROPOFID_VAL_PAGO = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_VAL_PAGO.ToString(),
                PROPOFID_AGEPGTO = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGEPGTO.ToString(),
                PROPOFID_VAL_TARIFA = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_VAL_TARIFA.ToString(),
                PROPOFID_VAL_IOF = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_VAL_IOF.ToString(),
                PROPOFID_DATA_CREDITO = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_CREDITO.ToString(),
                PROPOFID_VAL_COMISSAO = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_VAL_COMISSAO.ToString(),
                PROPOFID_SIT_PROPOSTA = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_SIT_PROPOSTA.ToString(),
                PROPOFID_COD_USUARIO = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_USUARIO.ToString(),
                PROPOFID_CANAL_PROPOSTA = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_CANAL_PROPOSTA.ToString(),
                PROPOFID_NSAS_SIVPF = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NSAS_SIVPF.ToString(),
                PROPOFID_ORIGEM_PROPOSTA = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_ORIGEM_PROPOSTA.ToString(),
                PROPOFID_NSL = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NSL.ToString(),
                PROPOFID_NSAC_SIVPF = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NSAC_SIVPF.ToString(),
                PROPOFID_SITUACAO_ENVIO = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_SITUACAO_ENVIO.ToString(),
                PROPOFID_OPCAO_COBER = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPCAO_COBER.ToString(),
                PROPOFID_COD_PLANO = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PLANO.ToString(),
                PROPOFID_NOME_CONJUGE = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NOME_CONJUGE.ToString(),
                PROPOFID_DATA_NASC_CONJUGE = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_NASC_CONJUGE.ToString(),
                VIND_DTNASC_ESPOSA = VIND_DTNASC_ESPOSA.ToString(),
                PROPOFID_PROFISSAO_CONJUGE = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_PROFISSAO_CONJUGE.ToString(),
                VIND_CBO_CONJ = VIND_CBO_CONJ.ToString(),
                PROPOFID_FAIXA_RENDA_IND = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_FAIXA_RENDA_IND.ToString(),
                PROPOFID_FAIXA_RENDA_FAM = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_FAIXA_RENDA_FAM.ToString(),
                PROPOFID_IND_TIPO_CONTA = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_IND_TIPO_CONTA.ToString(),
            };

            R1450_00_INSERT_FIDELIZ_DB_INSERT_1_Insert1.Execute(r1450_00_INSERT_FIDELIZ_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1450_99_SAIDA*/

        [StopWatch]
        /*" R1500-00-UPDATE-FIDELIZ-SECTION */
        private void R1500_00_UPDATE_FIDELIZ_SECTION()
        {
            /*" -2158- MOVE '1500' TO WNR-EXEC-SQL. */
            _.Move("1500", AUX_RELATORIO.WABEND.WNR_EXEC_SQL);

            /*" -2165- PERFORM R1500_00_UPDATE_FIDELIZ_DB_UPDATE_1 */

            R1500_00_UPDATE_FIDELIZ_DB_UPDATE_1();

            /*" -2168- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2169- DISPLAY 'R1500-00 - PROBLEMAS UPDATE (PROPOFID )   ' */
                _.Display($"R1500-00 - PROBLEMAS UPDATE (PROPOFID )   ");

                /*" -2170- DISPLAY 'SIT-REGISTRO    = ' MOVIMCOB-SIT-REGISTRO */
                _.Display($"SIT-REGISTRO    = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_SIT_REGISTRO}");

                /*" -2171- DISPLAY 'COD-BANCO       = ' MOVIMCOB-COD-BANCO */
                _.Display($"COD-BANCO       = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_BANCO}");

                /*" -2172- DISPLAY 'COD-AGENCIA     = ' MOVIMCOB-COD-AGENCIA */
                _.Display($"COD-AGENCIA     = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_AGENCIA}");

                /*" -2173- DISPLAY 'NUM-AVISO       = ' MOVIMCOB-NUM-AVISO */
                _.Display($"NUM-AVISO       = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_AVISO}");

                /*" -2174- DISPLAY 'NUM-FITA        = ' MOVIMCOB-NUM-FITA */
                _.Display($"NUM-FITA        = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_FITA}");

                /*" -2175- DISPLAY 'NUM-NOSSO-TITULO= ' MOVIMCOB-NUM-NOSSO-TITULO */
                _.Display($"NUM-NOSSO-TITULO= {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_NOSSO_TITULO}");

                /*" -2176- DISPLAY 'NUM-APOLICE     = ' MOVIMCOB-NUM-APOLICE */
                _.Display($"NUM-APOLICE     = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_APOLICE}");

                /*" -2177- DISPLAY 'NUM-ENDOSSO     = ' MOVIMCOB-NUM-ENDOSSO */
                _.Display($"NUM-ENDOSSO     = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_ENDOSSO}");

                /*" -2178- DISPLAY 'NUM-PARCELA     = ' MOVIMCOB-NUM-PARCELA */
                _.Display($"NUM-PARCELA     = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_PARCELA}");

                /*" -2179- DISPLAY 'COD-MOVIMENTO   = ' MOVIMCOB-COD-MOVIMENTO */
                _.Display($"COD-MOVIMENTO   = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_MOVIMENTO}");

                /*" -2180- DISPLAY 'NOME-SEGURADO   = ' MOVIMCOB-NOME-SEGURADO */
                _.Display($"NOME-SEGURADO   = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NOME_SEGURADO}");

                /*" -2181- DISPLAY 'IDENTIFICACAO   = ' PROPOFID-NUM-IDENTIFICACAO */
                _.Display($"IDENTIFICACAO   = {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_IDENTIFICACAO}");

                /*" -2181- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1500-00-UPDATE-FIDELIZ-DB-UPDATE-1 */
        public void R1500_00_UPDATE_FIDELIZ_DB_UPDATE_1()
        {
            /*" -2165- EXEC SQL UPDATE SEGUROS.PROPOSTA_FIDELIZ SET SIT_PROPOSTA = :PROPOFID-SIT-PROPOSTA WHERE NUM_PROPOSTA_SIVPF = :PROPOFID-NUM-PROPOSTA-SIVPF END-EXEC. */

            var r1500_00_UPDATE_FIDELIZ_DB_UPDATE_1_Update1 = new R1500_00_UPDATE_FIDELIZ_DB_UPDATE_1_Update1()
            {
                PROPOFID_SIT_PROPOSTA = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_SIT_PROPOSTA.ToString(),
                PROPOFID_NUM_PROPOSTA_SIVPF = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF.ToString(),
            };

            R1500_00_UPDATE_FIDELIZ_DB_UPDATE_1_Update1.Execute(r1500_00_UPDATE_FIDELIZ_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1500_99_SAIDA*/

        [StopWatch]
        /*" R1700-00-SELECT-BILHECOB-SECTION */
        private void R1700_00_SELECT_BILHECOB_SECTION()
        {
            /*" -2194- MOVE '1700' TO WNR-EXEC-SQL. */
            _.Move("1700", AUX_RELATORIO.WABEND.WNR_EXEC_SQL);

            /*" -2196- MOVE BILHETE-RAMO TO BILHECOB-RAMO-COBERTURA. */
            _.Move(BILHETE.DCLBILHETE.BILHETE_RAMO, BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_RAMO_COBERTURA);

            /*" -2198- MOVE ZEROS TO BILHECOB-MODALI-COBERTURA. */
            _.Move(0, BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_MODALI_COBERTURA);

            /*" -2200- MOVE BILHETE-OPC-COBERTURA TO BILHECOB-COD-OPCAO-PLANO. */
            _.Move(BILHETE.DCLBILHETE.BILHETE_OPC_COBERTURA, BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_COD_OPCAO_PLANO);

            /*" -2202- MOVE CONVERSI-COD-PRODUTO-SIVPF TO BILHECOB-COD-PRODUTO. */
            _.Move(CONVERSI.DCLCONVERSAO_SICOB.CONVERSI_COD_PRODUTO_SIVPF, BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_COD_PRODUTO);

            /*" -2204- MOVE BILHETE-DATA-QUITACAO TO BILHECOB-DATA-INIVIGENCIA. */
            _.Move(BILHETE.DCLBILHETE.BILHETE_DATA_QUITACAO, BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_DATA_INIVIGENCIA);

            /*" -2206- MOVE BILHETE-DATA-QUITACAO TO BILHECOB-DATA-TERVIGENCIA. */
            _.Move(BILHETE.DCLBILHETE.BILHETE_DATA_QUITACAO, BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_DATA_TERVIGENCIA);

            /*" -2210- MOVE '1' TO BILHECOB-IDE-COBERTURA. */
            _.Move("1", BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_IDE_COBERTURA);

            /*" -2252- PERFORM R1700_00_SELECT_BILHECOB_DB_SELECT_1 */

            R1700_00_SELECT_BILHECOB_DB_SELECT_1();

            /*" -2256- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -2258- MOVE 'REGISTRO SEM COBERTURA                  ' TO LD01-MENSAGEM */
                _.Move("REGISTRO SEM COBERTURA                  ", AUX_RELATORIO.LD01.LD01_MENSAGEM);

                /*" -2259- MOVE 'N' TO WTEM-COBERTURA */
                _.Move("N", W.WTEM_COBERTURA);

                /*" -2261- GO TO R1700-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1700_99_SAIDA*/ //GOTO
                return;
            }


            /*" -2262- IF SQLCODE EQUAL -811 */

            if (DB.SQLCODE == -811)
            {

                /*" -2264- MOVE 'COBERTURA DUPLICADA                     ' TO LD01-MENSAGEM */
                _.Move("COBERTURA DUPLICADA                     ", AUX_RELATORIO.LD01.LD01_MENSAGEM);

                /*" -2265- MOVE 'N' TO WTEM-COBERTURA */
                _.Move("N", W.WTEM_COBERTURA);

                /*" -2268- GO TO R1700-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1700_99_SAIDA*/ //GOTO
                return;
            }


            /*" -2269- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2270- DISPLAY 'R1700-00 - PROBLEMAS NO SELECT(BILHECOB)' */
                _.Display($"R1700-00 - PROBLEMAS NO SELECT(BILHECOB)");

                /*" -2271- DISPLAY 'NUM-NOSSO-TITULO = ' MOVIMCOB-NUM-NOSSO-TITULO */
                _.Display($"NUM-NOSSO-TITULO = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_NOSSO_TITULO}");

                /*" -2272- DISPLAY 'NUM-BILHETE      = ' BILHETE-NUM-BILHETE */
                _.Display($"NUM-BILHETE      = {BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE}");

                /*" -2273- DISPLAY 'COD-FONTE        = ' BILHETE-FONTE */
                _.Display($"COD-FONTE        = {BILHETE.DCLBILHETE.BILHETE_FONTE}");

                /*" -2274- DISPLAY 'RAMO             = ' BILHECOB-RAMO-COBERTURA */
                _.Display($"RAMO             = {BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_RAMO_COBERTURA}");

                /*" -2275- DISPLAY 'COD_OPCAO        = ' BILHECOB-COD-OPCAO-PLANO */
                _.Display($"COD_OPCAO        = {BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_COD_OPCAO_PLANO}");

                /*" -2276- DISPLAY 'PRODUTO          = ' BILHECOB-COD-PRODUTO */
                _.Display($"PRODUTO          = {BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_COD_PRODUTO}");

                /*" -2277- DISPLAY 'INIVIGENCIA      = ' BILHECOB-DATA-INIVIGENCIA */
                _.Display($"INIVIGENCIA      = {BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_DATA_INIVIGENCIA}");

                /*" -2280- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2281- IF VIND-NULL01 LESS ZEROS */

            if (VIND_NULL01 < 00)
            {

                /*" -2284- MOVE ZEROS TO BILHECOB-PRM-TOTAL. */
                _.Move(0, BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_PRM_TOTAL);
            }


            /*" -2285- IF VIND-NULL02 LESS ZEROS */

            if (VIND_NULL02 < 00)
            {

                /*" -2289- MOVE ZEROS TO BILHECOB-PCT-IOCC. */
                _.Move(0, BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_PCT_IOCC);
            }


            /*" -2293- MOVE BILHECOB-PRM-TOTAL TO LD01-PRM-TOTAL. */
            _.Move(BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_PRM_TOTAL, AUX_RELATORIO.LD01.LD01_PRM_TOTAL);

            /*" -2296- IF BILHECOB-IMP-SEGURADA-IX EQUAL ZEROS OR BILHECOB-PRM-TARIFARIO-IX EQUAL ZEROS OR BILHECOB-PRM-TOTAL EQUAL ZEROS */

            if (BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_IMP_SEGURADA_IX == 00 || BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_PRM_TARIFARIO_IX == 00 || BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_PRM_TOTAL == 00)
            {

                /*" -2298- MOVE 'COBERTURA SEM VALORES                   ' TO LD01-MENSAGEM */
                _.Move("COBERTURA SEM VALORES                   ", AUX_RELATORIO.LD01.LD01_MENSAGEM);

                /*" -2299- MOVE 'N' TO WTEM-COBERTURA */
                _.Move("N", W.WTEM_COBERTURA);

                /*" -2302- GO TO R1700-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1700_99_SAIDA*/ //GOTO
                return;
            }


            /*" -2304- IF BILHECOB-PRM-TOTAL NOT EQUAL MOVIMCOB-VAL-TITULO */

            if (BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_PRM_TOTAL != MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_VAL_TITULO)
            {

                /*" -2306- MOVE 'COBERTURA COM VALOR DIVERGENTE          ' TO LD01-MENSAGEM */
                _.Move("COBERTURA COM VALOR DIVERGENTE          ", AUX_RELATORIO.LD01.LD01_MENSAGEM);

                /*" -2306- MOVE 'N' TO WTEM-COBERTURA. */
                _.Move("N", W.WTEM_COBERTURA);
            }


        }

        [StopWatch]
        /*" R1700-00-SELECT-BILHECOB-DB-SELECT-1 */
        public void R1700_00_SELECT_BILHECOB_DB_SELECT_1()
        {
            /*" -2252- EXEC SQL SELECT A.COD_MOEDA , A.PCT_COM_CORRETOR , A.IMP_SEGURADA_IX , A.PRM_TARIFARIO_IX , A.PRM_TOTAL , A.PCT_IOCC , B.PCT_IOCC_RAMO , (B.PCT_IOCC_RAMO / 100) INTO :BILHECOB-COD-MOEDA , :BILHECOB-PCT-COM-CORRETOR , :BILHECOB-IMP-SEGURADA-IX , :BILHECOB-PRM-TARIFARIO-IX , :BILHECOB-PRM-TOTAL:VIND-NULL01 , :BILHECOB-PCT-IOCC:VIND-NULL02 , :RAMOCOMP-PCT-IOCC-RAMO , :WSHOST-PCT-IOCC FROM SEGUROS.BILHETE_COBERTURA A, SEGUROS.RAMO_COMPLEMENTAR B WHERE A.RAMO_COBERTURA = :BILHECOB-RAMO-COBERTURA AND A.MODALI_COBERTURA = :BILHECOB-MODALI-COBERTURA AND A.COD_OPCAO_PLANO = :BILHECOB-COD-OPCAO-PLANO AND A.COD_PRODUTO = :BILHECOB-COD-PRODUTO AND A.DATA_INIVIGENCIA <= :BILHECOB-DATA-INIVIGENCIA AND A.DATA_TERVIGENCIA >= :BILHECOB-DATA-TERVIGENCIA AND A.IDE_COBERTURA = :BILHECOB-IDE-COBERTURA AND B.RAMO_EMISSOR = A.RAMO_COBERTURA AND B.DATA_INIVIGENCIA <= :BILHECOB-DATA-INIVIGENCIA AND B.DATA_TERVIGENCIA >= :BILHECOB-DATA-TERVIGENCIA WITH UR END-EXEC. */

            var r1700_00_SELECT_BILHECOB_DB_SELECT_1_Query1 = new R1700_00_SELECT_BILHECOB_DB_SELECT_1_Query1()
            {
                BILHECOB_MODALI_COBERTURA = BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_MODALI_COBERTURA.ToString(),
                BILHECOB_DATA_INIVIGENCIA = BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_DATA_INIVIGENCIA.ToString(),
                BILHECOB_DATA_TERVIGENCIA = BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_DATA_TERVIGENCIA.ToString(),
                BILHECOB_COD_OPCAO_PLANO = BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_COD_OPCAO_PLANO.ToString(),
                BILHECOB_RAMO_COBERTURA = BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_RAMO_COBERTURA.ToString(),
                BILHECOB_IDE_COBERTURA = BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_IDE_COBERTURA.ToString(),
                BILHECOB_COD_PRODUTO = BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_COD_PRODUTO.ToString(),
            };

            var executed_1 = R1700_00_SELECT_BILHECOB_DB_SELECT_1_Query1.Execute(r1700_00_SELECT_BILHECOB_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.BILHECOB_COD_MOEDA, BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_COD_MOEDA);
                _.Move(executed_1.BILHECOB_PCT_COM_CORRETOR, BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_PCT_COM_CORRETOR);
                _.Move(executed_1.BILHECOB_IMP_SEGURADA_IX, BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_IMP_SEGURADA_IX);
                _.Move(executed_1.BILHECOB_PRM_TARIFARIO_IX, BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_PRM_TARIFARIO_IX);
                _.Move(executed_1.BILHECOB_PRM_TOTAL, BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_PRM_TOTAL);
                _.Move(executed_1.VIND_NULL01, VIND_NULL01);
                _.Move(executed_1.BILHECOB_PCT_IOCC, BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_PCT_IOCC);
                _.Move(executed_1.VIND_NULL02, VIND_NULL02);
                _.Move(executed_1.RAMOCOMP_PCT_IOCC_RAMO, RAMOCOMP.DCLRAMO_COMPLEMENTAR.RAMOCOMP_PCT_IOCC_RAMO);
                _.Move(executed_1.WSHOST_PCT_IOCC, WSHOST_PCT_IOCC);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1700_99_SAIDA*/

        [StopWatch]
        /*" R1750-00-VERIFICA-VIGENCIA-SECTION */
        private void R1750_00_VERIFICA_VIGENCIA_SECTION()
        {
            /*" -2323- MOVE '1750' TO WNR-EXEC-SQL. */
            _.Move("1750", AUX_RELATORIO.WABEND.WNR_EXEC_SQL);

            /*" -2329- PERFORM R1800-00-SELECT-CALENDAR. */

            R1800_00_SELECT_CALENDAR_SECTION();

            /*" -2333- MOVE MOVIMCOB-DATA-QUITACAO TO WSGER01-DATA-VENCIMENTO WDATA-REL. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_DATA_QUITACAO, WSGER01_DATA_VENCIMENTO, W.WDATA_REL);

            /*" -2334- MOVE 2 TO WS-SUBS. */
            _.Move(2, W.WS_SUBS);

            /*" -2334- PERFORM R1810-00-VER-VENCIMENTO 14 TIMES. */

            for (int i = 0; i < 14; i++)
            {

                R1810_00_VER_VENCIMENTO_SECTION();

            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1750_99_SAIDA*/

        [StopWatch]
        /*" R1800-00-SELECT-CALENDAR-SECTION */
        private void R1800_00_SELECT_CALENDAR_SECTION()
        {
            /*" -2347- MOVE '1800' TO WNR-EXEC-SQL. */
            _.Move("1800", AUX_RELATORIO.WABEND.WNR_EXEC_SQL);

            /*" -2350- MOVE MOVIMCOB-DATA-MOVIMENTO TO CALENDAR-DATA-CALENDARIO. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_DATA_MOVIMENTO, CALENDAR.DCLCALENDARIO.CALENDAR_DATA_CALENDARIO);

            /*" -2416- PERFORM R1800_00_SELECT_CALENDAR_DB_SELECT_1 */

            R1800_00_SELECT_CALENDAR_DB_SELECT_1();

            /*" -2420- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2421- DISPLAY 'R1800-00 - PROBLEMAS SELECT  (CALENDAR)   ' */
                _.Display($"R1800-00 - PROBLEMAS SELECT  (CALENDAR)   ");

                /*" -2422- DISPLAY 'SIT-REGISTRO    = ' MOVIMCOB-SIT-REGISTRO */
                _.Display($"SIT-REGISTRO    = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_SIT_REGISTRO}");

                /*" -2423- DISPLAY 'COD-BANCO       = ' MOVIMCOB-COD-BANCO */
                _.Display($"COD-BANCO       = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_BANCO}");

                /*" -2424- DISPLAY 'COD-AGENCIA     = ' MOVIMCOB-COD-AGENCIA */
                _.Display($"COD-AGENCIA     = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_AGENCIA}");

                /*" -2425- DISPLAY 'NUM-AVISO       = ' MOVIMCOB-NUM-AVISO */
                _.Display($"NUM-AVISO       = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_AVISO}");

                /*" -2426- DISPLAY 'NUM-FITA        = ' MOVIMCOB-NUM-FITA */
                _.Display($"NUM-FITA        = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_FITA}");

                /*" -2427- DISPLAY 'NUM-NOSSO-TITULO= ' MOVIMCOB-NUM-NOSSO-TITULO */
                _.Display($"NUM-NOSSO-TITULO= {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_NOSSO_TITULO}");

                /*" -2428- DISPLAY 'NUM-APOLICE     = ' MOVIMCOB-NUM-APOLICE */
                _.Display($"NUM-APOLICE     = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_APOLICE}");

                /*" -2429- DISPLAY 'NUM-ENDOSSO     = ' MOVIMCOB-NUM-ENDOSSO */
                _.Display($"NUM-ENDOSSO     = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_ENDOSSO}");

                /*" -2430- DISPLAY 'NUM-PARCELA     = ' MOVIMCOB-NUM-PARCELA */
                _.Display($"NUM-PARCELA     = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_PARCELA}");

                /*" -2431- DISPLAY 'COD-MOVIMENTO   = ' MOVIMCOB-COD-MOVIMENTO */
                _.Display($"COD-MOVIMENTO   = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_MOVIMENTO}");

                /*" -2432- DISPLAY 'NOME-SEGURADO   = ' MOVIMCOB-NOME-SEGURADO */
                _.Display($"NOME-SEGURADO   = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NOME_SEGURADO}");

                /*" -2433- DISPLAY 'DATA-MOVIMENTO  = ' MOVIMCOB-DATA-MOVIMENTO */
                _.Display($"DATA-MOVIMENTO  = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_DATA_MOVIMENTO}");

                /*" -2433- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1800-00-SELECT-CALENDAR-DB-SELECT-1 */
        public void R1800_00_SELECT_CALENDAR_DB_SELECT_1()
        {
            /*" -2416- EXEC SQL SELECT DATA_CALENDARIO , (DATA_CALENDARIO + 030 DAYS), (DATA_CALENDARIO + 031 DAYS), (DATA_CALENDARIO + 060 DAYS), (DATA_CALENDARIO + 061 DAYS), (DATA_CALENDARIO + 090 DAYS), (DATA_CALENDARIO + 091 DAYS), (DATA_CALENDARIO + 120 DAYS), (DATA_CALENDARIO + 121 DAYS), (DATA_CALENDARIO + 150 DAYS), (DATA_CALENDARIO + 151 DAYS), (DATA_CALENDARIO + 180 DAYS), (DATA_CALENDARIO + 181 DAYS), (DATA_CALENDARIO + 210 DAYS), (DATA_CALENDARIO + 211 DAYS), (DATA_CALENDARIO + 240 DAYS), (DATA_CALENDARIO + 241 DAYS), (DATA_CALENDARIO + 270 DAYS), (DATA_CALENDARIO + 271 DAYS), (DATA_CALENDARIO + 300 DAYS), (DATA_CALENDARIO + 301 DAYS), (DATA_CALENDARIO + 330 DAYS), (DATA_CALENDARIO + 331 DAYS), (DATA_CALENDARIO + 360 DAYS), (DATA_CALENDARIO + 361 DAYS), (DATA_CALENDARIO + 390 DAYS), (DATA_CALENDARIO + 391 DAYS), (DATA_CALENDARIO + 420 DAYS), (DATA_CALENDARIO + 421 DAYS), (DATA_CALENDARIO + 450 DAYS) INTO :WSGER01-DATA-INIVIGENCIA , :WSGER01-DATA-TERVIGENCIA , :WSGER02-DATA-INIVIGENCIA , :WSGER02-DATA-TERVIGENCIA , :WSGER03-DATA-INIVIGENCIA , :WSGER03-DATA-TERVIGENCIA , :WSGER04-DATA-INIVIGENCIA , :WSGER04-DATA-TERVIGENCIA , :WSGER05-DATA-INIVIGENCIA , :WSGER05-DATA-TERVIGENCIA , :WSGER06-DATA-INIVIGENCIA , :WSGER06-DATA-TERVIGENCIA , :WSGER07-DATA-INIVIGENCIA , :WSGER07-DATA-TERVIGENCIA , :WSGER08-DATA-INIVIGENCIA , :WSGER08-DATA-TERVIGENCIA , :WSGER09-DATA-INIVIGENCIA , :WSGER09-DATA-TERVIGENCIA , :WSGER10-DATA-INIVIGENCIA , :WSGER10-DATA-TERVIGENCIA , :WSGER11-DATA-INIVIGENCIA , :WSGER11-DATA-TERVIGENCIA , :WSGER12-DATA-INIVIGENCIA , :WSGER12-DATA-TERVIGENCIA , :WSGER13-DATA-INIVIGENCIA , :WSGER13-DATA-TERVIGENCIA , :WSGER14-DATA-INIVIGENCIA , :WSGER14-DATA-TERVIGENCIA , :WSGER15-DATA-INIVIGENCIA , :WSGER15-DATA-TERVIGENCIA FROM SEGUROS.CALENDARIO WHERE DATA_CALENDARIO = :CALENDAR-DATA-CALENDARIO WITH UR END-EXEC. */

            var r1800_00_SELECT_CALENDAR_DB_SELECT_1_Query1 = new R1800_00_SELECT_CALENDAR_DB_SELECT_1_Query1()
            {
                CALENDAR_DATA_CALENDARIO = CALENDAR.DCLCALENDARIO.CALENDAR_DATA_CALENDARIO.ToString(),
            };

            var executed_1 = R1800_00_SELECT_CALENDAR_DB_SELECT_1_Query1.Execute(r1800_00_SELECT_CALENDAR_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WSGER01_DATA_INIVIGENCIA, WSGER01_DATA_INIVIGENCIA);
                _.Move(executed_1.WSGER01_DATA_TERVIGENCIA, WSGER01_DATA_TERVIGENCIA);
                _.Move(executed_1.WSGER02_DATA_INIVIGENCIA, WSGER02_DATA_INIVIGENCIA);
                _.Move(executed_1.WSGER02_DATA_TERVIGENCIA, WSGER02_DATA_TERVIGENCIA);
                _.Move(executed_1.WSGER03_DATA_INIVIGENCIA, WSGER03_DATA_INIVIGENCIA);
                _.Move(executed_1.WSGER03_DATA_TERVIGENCIA, WSGER03_DATA_TERVIGENCIA);
                _.Move(executed_1.WSGER04_DATA_INIVIGENCIA, WSGER04_DATA_INIVIGENCIA);
                _.Move(executed_1.WSGER04_DATA_TERVIGENCIA, WSGER04_DATA_TERVIGENCIA);
                _.Move(executed_1.WSGER05_DATA_INIVIGENCIA, WSGER05_DATA_INIVIGENCIA);
                _.Move(executed_1.WSGER05_DATA_TERVIGENCIA, WSGER05_DATA_TERVIGENCIA);
                _.Move(executed_1.WSGER06_DATA_INIVIGENCIA, WSGER06_DATA_INIVIGENCIA);
                _.Move(executed_1.WSGER06_DATA_TERVIGENCIA, WSGER06_DATA_TERVIGENCIA);
                _.Move(executed_1.WSGER07_DATA_INIVIGENCIA, WSGER07_DATA_INIVIGENCIA);
                _.Move(executed_1.WSGER07_DATA_TERVIGENCIA, WSGER07_DATA_TERVIGENCIA);
                _.Move(executed_1.WSGER08_DATA_INIVIGENCIA, WSGER08_DATA_INIVIGENCIA);
                _.Move(executed_1.WSGER08_DATA_TERVIGENCIA, WSGER08_DATA_TERVIGENCIA);
                _.Move(executed_1.WSGER09_DATA_INIVIGENCIA, WSGER09_DATA_INIVIGENCIA);
                _.Move(executed_1.WSGER09_DATA_TERVIGENCIA, WSGER09_DATA_TERVIGENCIA);
                _.Move(executed_1.WSGER10_DATA_INIVIGENCIA, WSGER10_DATA_INIVIGENCIA);
                _.Move(executed_1.WSGER10_DATA_TERVIGENCIA, WSGER10_DATA_TERVIGENCIA);
                _.Move(executed_1.WSGER11_DATA_INIVIGENCIA, WSGER11_DATA_INIVIGENCIA);
                _.Move(executed_1.WSGER11_DATA_TERVIGENCIA, WSGER11_DATA_TERVIGENCIA);
                _.Move(executed_1.WSGER12_DATA_INIVIGENCIA, WSGER12_DATA_INIVIGENCIA);
                _.Move(executed_1.WSGER12_DATA_TERVIGENCIA, WSGER12_DATA_TERVIGENCIA);
                _.Move(executed_1.WSGER13_DATA_INIVIGENCIA, WSGER13_DATA_INIVIGENCIA);
                _.Move(executed_1.WSGER13_DATA_TERVIGENCIA, WSGER13_DATA_TERVIGENCIA);
                _.Move(executed_1.WSGER14_DATA_INIVIGENCIA, WSGER14_DATA_INIVIGENCIA);
                _.Move(executed_1.WSGER14_DATA_TERVIGENCIA, WSGER14_DATA_TERVIGENCIA);
                _.Move(executed_1.WSGER15_DATA_INIVIGENCIA, WSGER15_DATA_INIVIGENCIA);
                _.Move(executed_1.WSGER15_DATA_TERVIGENCIA, WSGER15_DATA_TERVIGENCIA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1800_99_SAIDA*/

        [StopWatch]
        /*" R1810-00-VER-VENCIMENTO-SECTION */
        private void R1810_00_VER_VENCIMENTO_SECTION()
        {
            /*" -2446- MOVE '1810' TO WNR-EXEC-SQL. */
            _.Move("1810", AUX_RELATORIO.WABEND.WNR_EXEC_SQL);

            /*" -2447- MOVE WDAT-REL-ANO TO WS-ANO */
            _.Move(W.FILLER_1.WDAT_REL_ANO, W.FILLER_6.WS_ANO);

            /*" -2449- MOVE WDAT-REL-MES TO WS-MES. */
            _.Move(W.FILLER_1.WDAT_REL_MES, W.FILLER_6.WS_MES);

            /*" -2451- ADD 1 TO WS-MES. */
            W.FILLER_6.WS_MES.Value = W.FILLER_6.WS_MES + 1;

            /*" -2452- IF WS-MES EQUAL 13 */

            if (W.FILLER_6.WS_MES == 13)
            {

                /*" -2453- MOVE 01 TO WS-MES */
                _.Move(01, W.FILLER_6.WS_MES);

                /*" -2456- ADD 1 TO WS-ANO. */
                W.FILLER_6.WS_ANO.Value = W.FILLER_6.WS_ANO + 1;
            }


            /*" -2457- MOVE WS-ANO TO WDAT-REL-ANO */
            _.Move(W.FILLER_6.WS_ANO, W.FILLER_1.WDAT_REL_ANO);

            /*" -2459- MOVE WS-MES TO WDAT-REL-MES. */
            _.Move(W.FILLER_6.WS_MES, W.FILLER_1.WDAT_REL_MES);

            /*" -2462- MOVE WDATA-REL TO WSHOST-DTVENCTO. */
            _.Move(W.WDATA_REL, W.WSHOST_DTVENCTO);

            /*" -2463- IF WSHOST-DIA GREATER 28 */

            if (W.FILLER_7.WSHOST_DIA > 28)
            {

                /*" -2465- MOVE 28 TO WSHOST-DIA. */
                _.Move(28, W.FILLER_7.WSHOST_DIA);
            }


            /*" -2468- MOVE WSHOST-DTVENCTO TO CALENDAR-DATA-CALENDARIO. */
            _.Move(W.WSHOST_DTVENCTO, CALENDAR.DCLCALENDARIO.CALENDAR_DATA_CALENDARIO);

            /*" -2470- PERFORM R1850-00-SELECT-CALENDAR. */

            R1850_00_SELECT_CALENDAR_SECTION();

            /*" -2472- IF WDATA-REL GREATER CALENDAR-DTH-ULT-DIA-MES */

            if (W.WDATA_REL > CALENDAR.DCLCALENDARIO.CALENDAR_DTH_ULT_DIA_MES)
            {

                /*" -2474- MOVE CALENDAR-DTH-ULT-DIA-MES TO CALENDAR-DATA-CALENDARIO */
                _.Move(CALENDAR.DCLCALENDARIO.CALENDAR_DTH_ULT_DIA_MES, CALENDAR.DCLCALENDARIO.CALENDAR_DATA_CALENDARIO);

                /*" -2475- ELSE */
            }
            else
            {


                /*" -2479- MOVE WDATA-REL TO CALENDAR-DATA-CALENDARIO. */
                _.Move(W.WDATA_REL, CALENDAR.DCLCALENDARIO.CALENDAR_DATA_CALENDARIO);
            }


            /*" -2480- IF WS-SUBS EQUAL 02 */

            if (W.WS_SUBS == 02)
            {

                /*" -2482- MOVE CALENDAR-DATA-CALENDARIO TO WSGER02-DATA-VENCIMENTO */
                _.Move(CALENDAR.DCLCALENDARIO.CALENDAR_DATA_CALENDARIO, WSGER02_DATA_VENCIMENTO);

                /*" -2483- ELSE */
            }
            else
            {


                /*" -2484- IF WS-SUBS EQUAL 03 */

                if (W.WS_SUBS == 03)
                {

                    /*" -2486- MOVE CALENDAR-DATA-CALENDARIO TO WSGER03-DATA-VENCIMENTO */
                    _.Move(CALENDAR.DCLCALENDARIO.CALENDAR_DATA_CALENDARIO, WSGER03_DATA_VENCIMENTO);

                    /*" -2487- ELSE */
                }
                else
                {


                    /*" -2488- IF WS-SUBS EQUAL 04 */

                    if (W.WS_SUBS == 04)
                    {

                        /*" -2490- MOVE CALENDAR-DATA-CALENDARIO TO WSGER04-DATA-VENCIMENTO */
                        _.Move(CALENDAR.DCLCALENDARIO.CALENDAR_DATA_CALENDARIO, WSGER04_DATA_VENCIMENTO);

                        /*" -2491- ELSE */
                    }
                    else
                    {


                        /*" -2492- IF WS-SUBS EQUAL 05 */

                        if (W.WS_SUBS == 05)
                        {

                            /*" -2494- MOVE CALENDAR-DATA-CALENDARIO TO WSGER05-DATA-VENCIMENTO */
                            _.Move(CALENDAR.DCLCALENDARIO.CALENDAR_DATA_CALENDARIO, WSGER05_DATA_VENCIMENTO);

                            /*" -2495- ELSE */
                        }
                        else
                        {


                            /*" -2496- IF WS-SUBS EQUAL 06 */

                            if (W.WS_SUBS == 06)
                            {

                                /*" -2498- MOVE CALENDAR-DATA-CALENDARIO TO WSGER06-DATA-VENCIMENTO */
                                _.Move(CALENDAR.DCLCALENDARIO.CALENDAR_DATA_CALENDARIO, WSGER06_DATA_VENCIMENTO);

                                /*" -2499- ELSE */
                            }
                            else
                            {


                                /*" -2500- IF WS-SUBS EQUAL 07 */

                                if (W.WS_SUBS == 07)
                                {

                                    /*" -2502- MOVE CALENDAR-DATA-CALENDARIO TO WSGER07-DATA-VENCIMENTO */
                                    _.Move(CALENDAR.DCLCALENDARIO.CALENDAR_DATA_CALENDARIO, WSGER07_DATA_VENCIMENTO);

                                    /*" -2503- ELSE */
                                }
                                else
                                {


                                    /*" -2504- IF WS-SUBS EQUAL 08 */

                                    if (W.WS_SUBS == 08)
                                    {

                                        /*" -2506- MOVE CALENDAR-DATA-CALENDARIO TO WSGER08-DATA-VENCIMENTO */
                                        _.Move(CALENDAR.DCLCALENDARIO.CALENDAR_DATA_CALENDARIO, WSGER08_DATA_VENCIMENTO);

                                        /*" -2507- ELSE */
                                    }
                                    else
                                    {


                                        /*" -2508- IF WS-SUBS EQUAL 09 */

                                        if (W.WS_SUBS == 09)
                                        {

                                            /*" -2510- MOVE CALENDAR-DATA-CALENDARIO TO WSGER09-DATA-VENCIMENTO */
                                            _.Move(CALENDAR.DCLCALENDARIO.CALENDAR_DATA_CALENDARIO, WSGER09_DATA_VENCIMENTO);

                                            /*" -2511- ELSE */
                                        }
                                        else
                                        {


                                            /*" -2512- IF WS-SUBS EQUAL 10 */

                                            if (W.WS_SUBS == 10)
                                            {

                                                /*" -2514- MOVE CALENDAR-DATA-CALENDARIO TO WSGER10-DATA-VENCIMENTO */
                                                _.Move(CALENDAR.DCLCALENDARIO.CALENDAR_DATA_CALENDARIO, WSGER10_DATA_VENCIMENTO);

                                                /*" -2515- ELSE */
                                            }
                                            else
                                            {


                                                /*" -2516- IF WS-SUBS EQUAL 11 */

                                                if (W.WS_SUBS == 11)
                                                {

                                                    /*" -2518- MOVE CALENDAR-DATA-CALENDARIO TO WSGER11-DATA-VENCIMENTO */
                                                    _.Move(CALENDAR.DCLCALENDARIO.CALENDAR_DATA_CALENDARIO, WSGER11_DATA_VENCIMENTO);

                                                    /*" -2519- ELSE */
                                                }
                                                else
                                                {


                                                    /*" -2520- IF WS-SUBS EQUAL 12 */

                                                    if (W.WS_SUBS == 12)
                                                    {

                                                        /*" -2522- MOVE CALENDAR-DATA-CALENDARIO TO WSGER12-DATA-VENCIMENTO */
                                                        _.Move(CALENDAR.DCLCALENDARIO.CALENDAR_DATA_CALENDARIO, WSGER12_DATA_VENCIMENTO);

                                                        /*" -2523- ELSE */
                                                    }
                                                    else
                                                    {


                                                        /*" -2524- IF WS-SUBS EQUAL 13 */

                                                        if (W.WS_SUBS == 13)
                                                        {

                                                            /*" -2526- MOVE CALENDAR-DATA-CALENDARIO TO WSGER13-DATA-VENCIMENTO */
                                                            _.Move(CALENDAR.DCLCALENDARIO.CALENDAR_DATA_CALENDARIO, WSGER13_DATA_VENCIMENTO);

                                                            /*" -2527- ELSE */
                                                        }
                                                        else
                                                        {


                                                            /*" -2528- IF WS-SUBS EQUAL 14 */

                                                            if (W.WS_SUBS == 14)
                                                            {

                                                                /*" -2530- MOVE CALENDAR-DATA-CALENDARIO TO WSGER14-DATA-VENCIMENTO */
                                                                _.Move(CALENDAR.DCLCALENDARIO.CALENDAR_DATA_CALENDARIO, WSGER14_DATA_VENCIMENTO);

                                                                /*" -2531- ELSE */
                                                            }
                                                            else
                                                            {


                                                                /*" -2532- IF WS-SUBS EQUAL 15 */

                                                                if (W.WS_SUBS == 15)
                                                                {

                                                                    /*" -2536- MOVE CALENDAR-DATA-CALENDARIO TO WSGER15-DATA-VENCIMENTO. */
                                                                    _.Move(CALENDAR.DCLCALENDARIO.CALENDAR_DATA_CALENDARIO, WSGER15_DATA_VENCIMENTO);
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


            /*" -2536- ADD 1 TO WS-SUBS. */
            W.WS_SUBS.Value = W.WS_SUBS + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1810_99_SAIDA*/

        [StopWatch]
        /*" R1850-00-SELECT-CALENDAR-SECTION */
        private void R1850_00_SELECT_CALENDAR_SECTION()
        {
            /*" -2549- MOVE '1850' TO WNR-EXEC-SQL. */
            _.Move("1850", AUX_RELATORIO.WABEND.WNR_EXEC_SQL);

            /*" -2559- PERFORM R1850_00_SELECT_CALENDAR_DB_SELECT_1 */

            R1850_00_SELECT_CALENDAR_DB_SELECT_1();

            /*" -2563- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2564- DISPLAY 'R1850-00 - PROBLEMAS SELECT  (CALENDAR)   ' */
                _.Display($"R1850-00 - PROBLEMAS SELECT  (CALENDAR)   ");

                /*" -2565- DISPLAY 'SIT-REGISTRO    = ' MOVIMCOB-SIT-REGISTRO */
                _.Display($"SIT-REGISTRO    = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_SIT_REGISTRO}");

                /*" -2566- DISPLAY 'COD-BANCO       = ' MOVIMCOB-COD-BANCO */
                _.Display($"COD-BANCO       = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_BANCO}");

                /*" -2567- DISPLAY 'COD-AGENCIA     = ' MOVIMCOB-COD-AGENCIA */
                _.Display($"COD-AGENCIA     = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_AGENCIA}");

                /*" -2568- DISPLAY 'NUM-AVISO       = ' MOVIMCOB-NUM-AVISO */
                _.Display($"NUM-AVISO       = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_AVISO}");

                /*" -2569- DISPLAY 'NUM-FITA        = ' MOVIMCOB-NUM-FITA */
                _.Display($"NUM-FITA        = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_FITA}");

                /*" -2570- DISPLAY 'NUM-NOSSO-TITULO= ' MOVIMCOB-NUM-NOSSO-TITULO */
                _.Display($"NUM-NOSSO-TITULO= {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_NOSSO_TITULO}");

                /*" -2571- DISPLAY 'NUM-APOLICE     = ' MOVIMCOB-NUM-APOLICE */
                _.Display($"NUM-APOLICE     = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_APOLICE}");

                /*" -2572- DISPLAY 'NUM-ENDOSSO     = ' MOVIMCOB-NUM-ENDOSSO */
                _.Display($"NUM-ENDOSSO     = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_ENDOSSO}");

                /*" -2573- DISPLAY 'NUM-PARCELA     = ' MOVIMCOB-NUM-PARCELA */
                _.Display($"NUM-PARCELA     = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_PARCELA}");

                /*" -2574- DISPLAY 'COD-MOVIMENTO   = ' MOVIMCOB-COD-MOVIMENTO */
                _.Display($"COD-MOVIMENTO   = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_MOVIMENTO}");

                /*" -2575- DISPLAY 'NOME-SEGURADO   = ' MOVIMCOB-NOME-SEGURADO */
                _.Display($"NOME-SEGURADO   = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NOME_SEGURADO}");

                /*" -2576- DISPLAY 'DATA-CALENDARIO = ' CALENDAR-DATA-CALENDARIO */
                _.Display($"DATA-CALENDARIO = {CALENDAR.DCLCALENDARIO.CALENDAR_DATA_CALENDARIO}");

                /*" -2576- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1850-00-SELECT-CALENDAR-DB-SELECT-1 */
        public void R1850_00_SELECT_CALENDAR_DB_SELECT_1()
        {
            /*" -2559- EXEC SQL SELECT DATA_CALENDARIO , DTH_ULT_DIA_MES INTO :CALENDAR-DATA-CALENDARIO , :CALENDAR-DTH-ULT-DIA-MES FROM SEGUROS.CALENDARIO WHERE DATA_CALENDARIO = :CALENDAR-DATA-CALENDARIO WITH UR END-EXEC. */

            var r1850_00_SELECT_CALENDAR_DB_SELECT_1_Query1 = new R1850_00_SELECT_CALENDAR_DB_SELECT_1_Query1()
            {
                CALENDAR_DATA_CALENDARIO = CALENDAR.DCLCALENDARIO.CALENDAR_DATA_CALENDARIO.ToString(),
            };

            var executed_1 = R1850_00_SELECT_CALENDAR_DB_SELECT_1_Query1.Execute(r1850_00_SELECT_CALENDAR_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CALENDAR_DATA_CALENDARIO, CALENDAR.DCLCALENDARIO.CALENDAR_DATA_CALENDARIO);
                _.Move(executed_1.CALENDAR_DTH_ULT_DIA_MES, CALENDAR.DCLCALENDARIO.CALENDAR_DTH_ULT_DIA_MES);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1850_99_SAIDA*/

        [StopWatch]
        /*" R2500-00-EMITE-APOLICE-SECTION */
        private void R2500_00_EMITE_APOLICE_SECTION()
        {
            /*" -2592- MOVE '2500' TO WNR-EXEC-SQL. */
            _.Move("2500", AUX_RELATORIO.WABEND.WNR_EXEC_SQL);

            /*" -2598- PERFORM R2550-00-SELECT-FONTES. */

            R2550_00_SELECT_FONTES_SECTION();

            /*" -2604- PERFORM R3000-00-MONTA-APOLICES. */

            R3000_00_MONTA_APOLICES_SECTION();

            /*" -2610- PERFORM R3200-00-MONTA-ENDOSSOS00. */

            R3200_00_MONTA_ENDOSSOS00_SECTION();

            /*" -2617- PERFORM R4000-00-MONTA-ENDOSSOS01. */

            R4000_00_MONTA_ENDOSSOS01_SECTION();

            /*" -2619- PERFORM R4900-00-VERIFICA-ENDOSSO. */

            R4900_00_VERIFICA_ENDOSSO_SECTION();

            /*" -2622- PERFORM R5000-00-MONTA-ENDOSSOS02. */

            R5000_00_MONTA_ENDOSSOS02_SECTION();

            /*" -2622- PERFORM R6000-00-MONTA-CORRETAGEM. */

            R6000_00_MONTA_CORRETAGEM_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2500_99_SAIDA*/

        [StopWatch]
        /*" R2550-00-SELECT-FONTES-SECTION */
        private void R2550_00_SELECT_FONTES_SECTION()
        {
            /*" -2635- MOVE '2550' TO WNR-EXEC-SQL. */
            _.Move("2550", AUX_RELATORIO.WABEND.WNR_EXEC_SQL);

            /*" -2638- MOVE BILHETE-FONTE TO FONTES-COD-FONTE. */
            _.Move(BILHETE.DCLBILHETE.BILHETE_FONTE, FONTES.DCLFONTES.FONTES_COD_FONTE);

            /*" -2645- PERFORM R2550_00_SELECT_FONTES_DB_SELECT_1 */

            R2550_00_SELECT_FONTES_DB_SELECT_1();

            /*" -2649- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2650- DISPLAY 'R2550-00 - PROBLEMAS NO SELECT(FONTES)  ' */
                _.Display($"R2550-00 - PROBLEMAS NO SELECT(FONTES)  ");

                /*" -2651- DISPLAY 'NUM-NOSSO-TITULO = ' MOVIMCOB-NUM-NOSSO-TITULO */
                _.Display($"NUM-NOSSO-TITULO = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_NOSSO_TITULO}");

                /*" -2652- DISPLAY 'NUM-BILHETE      = ' BILHETE-NUM-BILHETE */
                _.Display($"NUM-BILHETE      = {BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE}");

                /*" -2653- DISPLAY 'COD-FONTE        = ' BILHETE-FONTE */
                _.Display($"COD-FONTE        = {BILHETE.DCLBILHETE.BILHETE_FONTE}");

                /*" -2653- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2550-00-SELECT-FONTES-DB-SELECT-1 */
        public void R2550_00_SELECT_FONTES_DB_SELECT_1()
        {
            /*" -2645- EXEC SQL SELECT ORGAO_EMISSOR INTO :FONTES-ORGAO-EMISSOR FROM SEGUROS.FONTES WHERE COD_FONTE = :FONTES-COD-FONTE WITH UR END-EXEC. */

            var r2550_00_SELECT_FONTES_DB_SELECT_1_Query1 = new R2550_00_SELECT_FONTES_DB_SELECT_1_Query1()
            {
                FONTES_COD_FONTE = FONTES.DCLFONTES.FONTES_COD_FONTE.ToString(),
            };

            var executed_1 = R2550_00_SELECT_FONTES_DB_SELECT_1_Query1.Execute(r2550_00_SELECT_FONTES_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.FONTES_ORGAO_EMISSOR, FONTES.DCLFONTES.FONTES_ORGAO_EMISSOR);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2550_99_SAIDA*/

        [StopWatch]
        /*" R3000-00-MONTA-APOLICES-SECTION */
        private void R3000_00_MONTA_APOLICES_SECTION()
        {
            /*" -2666- MOVE '3000' TO WNR-EXEC-SQL. */
            _.Move("3000", AUX_RELATORIO.WABEND.WNR_EXEC_SQL);

            /*" -2667- IF BILHETE-NUM-APOLICE EQUAL ZEROS */

            if (BILHETE.DCLBILHETE.BILHETE_NUM_APOLICE == 00)
            {

                /*" -2670- PERFORM R3050-00-SELECT-NUMERAES. */

                R3050_00_SELECT_NUMERAES_SECTION();
            }


            /*" -2672- MOVE BILHETE-COD-CLIENTE TO APOLICES-COD-CLIENTE. */
            _.Move(BILHETE.DCLBILHETE.BILHETE_COD_CLIENTE, APOLICES.DCLAPOLICES.APOLICES_COD_CLIENTE);

            /*" -2674- MOVE BILHETE-NUM-APOLICE TO APOLICES-NUM-APOLICE. */
            _.Move(BILHETE.DCLBILHETE.BILHETE_NUM_APOLICE, APOLICES.DCLAPOLICES.APOLICES_NUM_APOLICE);

            /*" -2676- MOVE 1 TO APOLICES-NUM-ITEM. */
            _.Move(1, APOLICES.DCLAPOLICES.APOLICES_NUM_ITEM);

            /*" -2678- MOVE ZEROS TO APOLICES-COD-MODALIDADE. */
            _.Move(0, APOLICES.DCLAPOLICES.APOLICES_COD_MODALIDADE);

            /*" -2680- MOVE FONTES-ORGAO-EMISSOR TO APOLICES-ORGAO-EMISSOR. */
            _.Move(FONTES.DCLFONTES.FONTES_ORGAO_EMISSOR, APOLICES.DCLAPOLICES.APOLICES_ORGAO_EMISSOR);

            /*" -2682- MOVE BILHETE-RAMO TO APOLICES-RAMO-EMISSOR. */
            _.Move(BILHETE.DCLBILHETE.BILHETE_RAMO, APOLICES.DCLAPOLICES.APOLICES_RAMO_EMISSOR);

            /*" -2684- MOVE CONVERSI-COD-PRODUTO-SIVPF TO APOLICES-COD-PRODUTO. */
            _.Move(CONVERSI.DCLCONVERSAO_SICOB.CONVERSI_COD_PRODUTO_SIVPF, APOLICES.DCLAPOLICES.APOLICES_COD_PRODUTO);

            /*" -2686- MOVE ZEROS TO APOLICES-NUM-APOL-ANTERIOR. */
            _.Move(0, APOLICES.DCLAPOLICES.APOLICES_NUM_APOL_ANTERIOR);

            /*" -2688- MOVE BILHETE-NUM-BILHETE TO APOLICES-NUM-BILHETE. */
            _.Move(BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE, APOLICES.DCLAPOLICES.APOLICES_NUM_BILHETE);

            /*" -2690- MOVE '1' TO APOLICES-TIPO-SEGURO. */
            _.Move("1", APOLICES.DCLAPOLICES.APOLICES_TIPO_SEGURO);

            /*" -2692- MOVE '2' TO APOLICES-TIPO-APOLICE. */
            _.Move("2", APOLICES.DCLAPOLICES.APOLICES_TIPO_APOLICE);

            /*" -2694- MOVE '3' TO APOLICES-TIPO-CALCULO. */
            _.Move("3", APOLICES.DCLAPOLICES.APOLICES_TIPO_CALCULO);

            /*" -2696- MOVE 'N' TO APOLICES-IND-SORTEIO. */
            _.Move("N", APOLICES.DCLAPOLICES.APOLICES_IND_SORTEIO);

            /*" -2698- MOVE ZEROS TO APOLICES-NUM-ATA. */
            _.Move(0, APOLICES.DCLAPOLICES.APOLICES_NUM_ATA);

            /*" -2700- MOVE ZEROS TO APOLICES-ANO-ATA. */
            _.Move(0, APOLICES.DCLAPOLICES.APOLICES_ANO_ATA);

            /*" -2702- MOVE SPACES TO APOLICES-IND-ENDOS-MANUAL. */
            _.Move("", APOLICES.DCLAPOLICES.APOLICES_IND_ENDOS_MANUAL);

            /*" -2704- MOVE ZEROS TO APOLICES-PCT-DESC-PREMIO. */
            _.Move(0, APOLICES.DCLAPOLICES.APOLICES_PCT_DESC_PREMIO);

            /*" -2706- MOVE RAMOCOMP-PCT-IOCC-RAMO TO APOLICES-PCT-IOCC. */
            _.Move(RAMOCOMP.DCLRAMO_COMPLEMENTAR.RAMOCOMP_PCT_IOCC_RAMO, APOLICES.DCLAPOLICES.APOLICES_PCT_IOCC);

            /*" -2708- MOVE '4' TO APOLICES-TIPO-COSSEGURO-CED. */
            _.Move("4", APOLICES.DCLAPOLICES.APOLICES_TIPO_COSSEGURO_CED);

            /*" -2710- MOVE ZEROS TO APOLICES-QTD-COSSEGURADORA. */
            _.Move(0, APOLICES.DCLAPOLICES.APOLICES_QTD_COSSEGURADORA);

            /*" -2712- MOVE ZEROS TO APOLICES-PCT-COSSEGURO-CED. */
            _.Move(0, APOLICES.DCLAPOLICES.APOLICES_PCT_COSSEGURO_CED);

            /*" -2714- MOVE SPACES TO APOLICES-DATA-SORTEIO. */
            _.Move("", APOLICES.DCLAPOLICES.APOLICES_DATA_SORTEIO);

            /*" -2716- MOVE ZEROS TO APOLICES-COD-EMPRESA. */
            _.Move(0, APOLICES.DCLAPOLICES.APOLICES_COD_EMPRESA);

            /*" -2719- MOVE '2' TO APOLICES-TIPO-CORRETAGEM. */
            _.Move("2", APOLICES.DCLAPOLICES.APOLICES_TIPO_CORRETAGEM);

            /*" -2721- MOVE -1 TO VIND-NULL01. */
            _.Move(-1, VIND_NULL01);

            /*" -2724- MOVE ZEROS TO VIND-NULL02 VIND-NULL03. */
            _.Move(0, VIND_NULL02, VIND_NULL03);

            /*" -2724- PERFORM R3150-00-INSERT-APOLICES. */

            R3150_00_INSERT_APOLICES_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_99_SAIDA*/

        [StopWatch]
        /*" R3050-00-SELECT-NUMERAES-SECTION */
        private void R3050_00_SELECT_NUMERAES_SECTION()
        {
            /*" -2737- MOVE '3050' TO WNR-EXEC-SQL. */
            _.Move("3050", AUX_RELATORIO.WABEND.WNR_EXEC_SQL);

            /*" -2739- MOVE FONTES-ORGAO-EMISSOR TO NUMERAES-ORGAO-EMISSOR. */
            _.Move(FONTES.DCLFONTES.FONTES_ORGAO_EMISSOR, NUMERAES.DCLNUMERO_AES.NUMERAES_ORGAO_EMISSOR);

            /*" -2742- MOVE BILHETE-RAMO TO NUMERAES-RAMO-EMISSOR. */
            _.Move(BILHETE.DCLBILHETE.BILHETE_RAMO, NUMERAES.DCLNUMERO_AES.NUMERAES_RAMO_EMISSOR);

            /*" -2751- PERFORM R3050_00_SELECT_NUMERAES_DB_SELECT_1 */

            R3050_00_SELECT_NUMERAES_DB_SELECT_1();

            /*" -2755- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2756- DISPLAY 'R3050-00 - PROBLEMAS NO SELECT(NUMERAES)' */
                _.Display($"R3050-00 - PROBLEMAS NO SELECT(NUMERAES)");

                /*" -2757- DISPLAY 'NUM-NOSSO-TITULO = ' MOVIMCOB-NUM-NOSSO-TITULO */
                _.Display($"NUM-NOSSO-TITULO = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_NOSSO_TITULO}");

                /*" -2758- DISPLAY 'NUM-BILHETE      = ' BILHETE-NUM-BILHETE */
                _.Display($"NUM-BILHETE      = {BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE}");

                /*" -2759- DISPLAY 'ORGAO            = ' NUMERAES-ORGAO-EMISSOR */
                _.Display($"ORGAO            = {NUMERAES.DCLNUMERO_AES.NUMERAES_ORGAO_EMISSOR}");

                /*" -2760- DISPLAY 'RAMO             = ' NUMERAES-RAMO-EMISSOR */
                _.Display($"RAMO             = {NUMERAES.DCLNUMERO_AES.NUMERAES_RAMO_EMISSOR}");

                /*" -2762- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2766- COMPUTE NUMERAES-SEQ-APOLICE EQUAL (NUMERAES-SEQ-APOLICE + 1). */
            NUMERAES.DCLNUMERO_AES.NUMERAES_SEQ_APOLICE.Value = (NUMERAES.DCLNUMERO_AES.NUMERAES_SEQ_APOLICE + 1);

            /*" -2769- PERFORM R3100-00-UPDATE-NUMEROAES. */

            R3100_00_UPDATE_NUMEROAES_SECTION();

            /*" -2771- MOVE NUMERAES-ORGAO-EMISSOR TO WNUM-APOL-ORG. */
            _.Move(NUMERAES.DCLNUMERO_AES.NUMERAES_ORGAO_EMISSOR, W.FILLER_0.WNUM_APOL_ORG);

            /*" -2773- MOVE NUMERAES-RAMO-EMISSOR TO WNUM-APOL-RAM. */
            _.Move(NUMERAES.DCLNUMERO_AES.NUMERAES_RAMO_EMISSOR, W.FILLER_0.WNUM_APOL_RAM);

            /*" -2775- MOVE NUMERAES-SEQ-APOLICE TO WNUM-APOL-SEQ. */
            _.Move(NUMERAES.DCLNUMERO_AES.NUMERAES_SEQ_APOLICE, W.FILLER_0.WNUM_APOL_SEQ);

            /*" -2776- MOVE WNUMERO-APOL TO BILHETE-NUM-APOLICE. */
            _.Move(W.WNUMERO_APOL, BILHETE.DCLBILHETE.BILHETE_NUM_APOLICE);

        }

        [StopWatch]
        /*" R3050-00-SELECT-NUMERAES-DB-SELECT-1 */
        public void R3050_00_SELECT_NUMERAES_DB_SELECT_1()
        {
            /*" -2751- EXEC SQL SELECT SEQ_APOLICE INTO :NUMERAES-SEQ-APOLICE FROM SEGUROS.NUMERO_AES WHERE ORGAO_EMISSOR = :NUMERAES-ORGAO-EMISSOR AND RAMO_EMISSOR = :NUMERAES-RAMO-EMISSOR WITH UR END-EXEC. */

            var r3050_00_SELECT_NUMERAES_DB_SELECT_1_Query1 = new R3050_00_SELECT_NUMERAES_DB_SELECT_1_Query1()
            {
                NUMERAES_ORGAO_EMISSOR = NUMERAES.DCLNUMERO_AES.NUMERAES_ORGAO_EMISSOR.ToString(),
                NUMERAES_RAMO_EMISSOR = NUMERAES.DCLNUMERO_AES.NUMERAES_RAMO_EMISSOR.ToString(),
            };

            var executed_1 = R3050_00_SELECT_NUMERAES_DB_SELECT_1_Query1.Execute(r3050_00_SELECT_NUMERAES_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.NUMERAES_SEQ_APOLICE, NUMERAES.DCLNUMERO_AES.NUMERAES_SEQ_APOLICE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3050_99_SAIDA*/

        [StopWatch]
        /*" R3100-00-UPDATE-NUMEROAES-SECTION */
        private void R3100_00_UPDATE_NUMEROAES_SECTION()
        {
            /*" -2789- MOVE '3100' TO WNR-EXEC-SQL. */
            _.Move("3100", AUX_RELATORIO.WABEND.WNR_EXEC_SQL);

            /*" -2797- PERFORM R3100_00_UPDATE_NUMEROAES_DB_UPDATE_1 */

            R3100_00_UPDATE_NUMEROAES_DB_UPDATE_1();

            /*" -2801- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2802- DISPLAY 'R3100-00 - PROBLEMAS NO UPDATE(NUMERAES)' */
                _.Display($"R3100-00 - PROBLEMAS NO UPDATE(NUMERAES)");

                /*" -2803- DISPLAY 'NUM-NOSSO-TITULO = ' MOVIMCOB-NUM-NOSSO-TITULO */
                _.Display($"NUM-NOSSO-TITULO = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_NOSSO_TITULO}");

                /*" -2804- DISPLAY 'NUM-BILHETE      = ' BILHETE-NUM-BILHETE */
                _.Display($"NUM-BILHETE      = {BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE}");

                /*" -2805- DISPLAY 'ORGAO            = ' NUMERAES-ORGAO-EMISSOR */
                _.Display($"ORGAO            = {NUMERAES.DCLNUMERO_AES.NUMERAES_ORGAO_EMISSOR}");

                /*" -2806- DISPLAY 'RAMO             = ' NUMERAES-RAMO-EMISSOR */
                _.Display($"RAMO             = {NUMERAES.DCLNUMERO_AES.NUMERAES_RAMO_EMISSOR}");

                /*" -2807- DISPLAY 'SEQ APOLICE      = ' NUMERAES-SEQ-APOLICE */
                _.Display($"SEQ APOLICE      = {NUMERAES.DCLNUMERO_AES.NUMERAES_SEQ_APOLICE}");

                /*" -2807- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R3100-00-UPDATE-NUMEROAES-DB-UPDATE-1 */
        public void R3100_00_UPDATE_NUMEROAES_DB_UPDATE_1()
        {
            /*" -2797- EXEC SQL UPDATE SEGUROS.NUMERO_AES SET SEQ_APOLICE = :NUMERAES-SEQ-APOLICE WHERE ORGAO_EMISSOR = :NUMERAES-ORGAO-EMISSOR AND RAMO_EMISSOR = :NUMERAES-RAMO-EMISSOR END-EXEC. */

            var r3100_00_UPDATE_NUMEROAES_DB_UPDATE_1_Update1 = new R3100_00_UPDATE_NUMEROAES_DB_UPDATE_1_Update1()
            {
                NUMERAES_SEQ_APOLICE = NUMERAES.DCLNUMERO_AES.NUMERAES_SEQ_APOLICE.ToString(),
                NUMERAES_ORGAO_EMISSOR = NUMERAES.DCLNUMERO_AES.NUMERAES_ORGAO_EMISSOR.ToString(),
                NUMERAES_RAMO_EMISSOR = NUMERAES.DCLNUMERO_AES.NUMERAES_RAMO_EMISSOR.ToString(),
            };

            R3100_00_UPDATE_NUMEROAES_DB_UPDATE_1_Update1.Execute(r3100_00_UPDATE_NUMEROAES_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3100_99_SAIDA*/

        [StopWatch]
        /*" R3150-00-INSERT-APOLICES-SECTION */
        private void R3150_00_INSERT_APOLICES_SECTION()
        {
            /*" -2820- MOVE '3150' TO WNR-EXEC-SQL. */
            _.Move("3150", AUX_RELATORIO.WABEND.WNR_EXEC_SQL);

            /*" -2873- PERFORM R3150_00_INSERT_APOLICES_DB_INSERT_1 */

            R3150_00_INSERT_APOLICES_DB_INSERT_1();

            /*" -2876- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2877- DISPLAY 'R3150-00 - PROBLEMAS NO INSERT(APOLICES)   ' */
                _.Display($"R3150-00 - PROBLEMAS NO INSERT(APOLICES)   ");

                /*" -2878- DISPLAY 'SIT-REGISTRO    = ' MOVIMCOB-SIT-REGISTRO */
                _.Display($"SIT-REGISTRO    = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_SIT_REGISTRO}");

                /*" -2879- DISPLAY 'COD-BANCO       = ' MOVIMCOB-COD-BANCO */
                _.Display($"COD-BANCO       = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_BANCO}");

                /*" -2880- DISPLAY 'COD-AGENCIA     = ' MOVIMCOB-COD-AGENCIA */
                _.Display($"COD-AGENCIA     = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_AGENCIA}");

                /*" -2881- DISPLAY 'NUM-AVISO       = ' MOVIMCOB-NUM-AVISO */
                _.Display($"NUM-AVISO       = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_AVISO}");

                /*" -2882- DISPLAY 'NUM-NOSSO-TITULO= ' MOVIMCOB-NUM-NOSSO-TITULO */
                _.Display($"NUM-NOSSO-TITULO= {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_NOSSO_TITULO}");

                /*" -2883- DISPLAY 'COD-MOVIMENTO   = ' MOVIMCOB-COD-MOVIMENTO */
                _.Display($"COD-MOVIMENTO   = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_MOVIMENTO}");

                /*" -2884- DISPLAY 'NOME-SEGURADO   = ' MOVIMCOB-NOME-SEGURADO */
                _.Display($"NOME-SEGURADO   = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NOME_SEGURADO}");

                /*" -2885- DISPLAY 'NUM-APOLICE     = ' APOLICES-NUM-APOLICE */
                _.Display($"NUM-APOLICE     = {APOLICES.DCLAPOLICES.APOLICES_NUM_APOLICE}");

                /*" -2885- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R3150-00-INSERT-APOLICES-DB-INSERT-1 */
        public void R3150_00_INSERT_APOLICES_DB_INSERT_1()
        {
            /*" -2873- EXEC SQL INSERT INTO SEGUROS.APOLICES (COD_CLIENTE , NUM_APOLICE , NUM_ITEM , COD_MODALIDADE , ORGAO_EMISSOR , RAMO_EMISSOR , COD_PRODUTO , NUM_APOL_ANTERIOR , NUM_BILHETE , TIPO_SEGURO , TIPO_APOLICE , TIPO_CALCULO , IND_SORTEIO , NUM_ATA , ANO_ATA , IND_ENDOS_MANUAL , PCT_DESC_PREMIO , PCT_IOCC , TIPO_COSSEGURO_CED , QTD_COSSEGURADORA , PCT_COSSEGURO_CED , DATA_SORTEIO , COD_EMPRESA , TIMESTAMP , TIPO_CORRETAGEM) VALUES (:APOLICES-COD-CLIENTE , :APOLICES-NUM-APOLICE , :APOLICES-NUM-ITEM , :APOLICES-COD-MODALIDADE , :APOLICES-ORGAO-EMISSOR , :APOLICES-RAMO-EMISSOR , :APOLICES-COD-PRODUTO , :APOLICES-NUM-APOL-ANTERIOR , :APOLICES-NUM-BILHETE , :APOLICES-TIPO-SEGURO , :APOLICES-TIPO-APOLICE , :APOLICES-TIPO-CALCULO , :APOLICES-IND-SORTEIO , :APOLICES-NUM-ATA , :APOLICES-ANO-ATA , :APOLICES-IND-ENDOS-MANUAL , :APOLICES-PCT-DESC-PREMIO , :APOLICES-PCT-IOCC , :APOLICES-TIPO-COSSEGURO-CED , :APOLICES-QTD-COSSEGURADORA , :APOLICES-PCT-COSSEGURO-CED , :APOLICES-DATA-SORTEIO:VIND-NULL01 , :APOLICES-COD-EMPRESA:VIND-NULL02 , CURRENT TIMESTAMP , :APOLICES-TIPO-CORRETAGEM:VIND-NULL03) END-EXEC. */

            var r3150_00_INSERT_APOLICES_DB_INSERT_1_Insert1 = new R3150_00_INSERT_APOLICES_DB_INSERT_1_Insert1()
            {
                APOLICES_COD_CLIENTE = APOLICES.DCLAPOLICES.APOLICES_COD_CLIENTE.ToString(),
                APOLICES_NUM_APOLICE = APOLICES.DCLAPOLICES.APOLICES_NUM_APOLICE.ToString(),
                APOLICES_NUM_ITEM = APOLICES.DCLAPOLICES.APOLICES_NUM_ITEM.ToString(),
                APOLICES_COD_MODALIDADE = APOLICES.DCLAPOLICES.APOLICES_COD_MODALIDADE.ToString(),
                APOLICES_ORGAO_EMISSOR = APOLICES.DCLAPOLICES.APOLICES_ORGAO_EMISSOR.ToString(),
                APOLICES_RAMO_EMISSOR = APOLICES.DCLAPOLICES.APOLICES_RAMO_EMISSOR.ToString(),
                APOLICES_COD_PRODUTO = APOLICES.DCLAPOLICES.APOLICES_COD_PRODUTO.ToString(),
                APOLICES_NUM_APOL_ANTERIOR = APOLICES.DCLAPOLICES.APOLICES_NUM_APOL_ANTERIOR.ToString(),
                APOLICES_NUM_BILHETE = APOLICES.DCLAPOLICES.APOLICES_NUM_BILHETE.ToString(),
                APOLICES_TIPO_SEGURO = APOLICES.DCLAPOLICES.APOLICES_TIPO_SEGURO.ToString(),
                APOLICES_TIPO_APOLICE = APOLICES.DCLAPOLICES.APOLICES_TIPO_APOLICE.ToString(),
                APOLICES_TIPO_CALCULO = APOLICES.DCLAPOLICES.APOLICES_TIPO_CALCULO.ToString(),
                APOLICES_IND_SORTEIO = APOLICES.DCLAPOLICES.APOLICES_IND_SORTEIO.ToString(),
                APOLICES_NUM_ATA = APOLICES.DCLAPOLICES.APOLICES_NUM_ATA.ToString(),
                APOLICES_ANO_ATA = APOLICES.DCLAPOLICES.APOLICES_ANO_ATA.ToString(),
                APOLICES_IND_ENDOS_MANUAL = APOLICES.DCLAPOLICES.APOLICES_IND_ENDOS_MANUAL.ToString(),
                APOLICES_PCT_DESC_PREMIO = APOLICES.DCLAPOLICES.APOLICES_PCT_DESC_PREMIO.ToString(),
                APOLICES_PCT_IOCC = APOLICES.DCLAPOLICES.APOLICES_PCT_IOCC.ToString(),
                APOLICES_TIPO_COSSEGURO_CED = APOLICES.DCLAPOLICES.APOLICES_TIPO_COSSEGURO_CED.ToString(),
                APOLICES_QTD_COSSEGURADORA = APOLICES.DCLAPOLICES.APOLICES_QTD_COSSEGURADORA.ToString(),
                APOLICES_PCT_COSSEGURO_CED = APOLICES.DCLAPOLICES.APOLICES_PCT_COSSEGURO_CED.ToString(),
                APOLICES_DATA_SORTEIO = APOLICES.DCLAPOLICES.APOLICES_DATA_SORTEIO.ToString(),
                VIND_NULL01 = VIND_NULL01.ToString(),
                APOLICES_COD_EMPRESA = APOLICES.DCLAPOLICES.APOLICES_COD_EMPRESA.ToString(),
                VIND_NULL02 = VIND_NULL02.ToString(),
                APOLICES_TIPO_CORRETAGEM = APOLICES.DCLAPOLICES.APOLICES_TIPO_CORRETAGEM.ToString(),
                VIND_NULL03 = VIND_NULL03.ToString(),
            };

            R3150_00_INSERT_APOLICES_DB_INSERT_1_Insert1.Execute(r3150_00_INSERT_APOLICES_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3150_99_SAIDA*/

        [StopWatch]
        /*" R3200-00-MONTA-ENDOSSOS00-SECTION */
        private void R3200_00_MONTA_ENDOSSOS00_SECTION()
        {
            /*" -2901- MOVE '3200' TO WNR-EXEC-SQL. */
            _.Move("3200", AUX_RELATORIO.WABEND.WNR_EXEC_SQL);

            /*" -2907- PERFORM R3250-00-SELECT-FONTES. */

            R3250_00_SELECT_FONTES_SECTION();

            /*" -2909- MOVE APOLICES-NUM-APOLICE TO ENDOSSOS-NUM-APOLICE. */
            _.Move(APOLICES.DCLAPOLICES.APOLICES_NUM_APOLICE, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE);

            /*" -2911- MOVE ZEROS TO ENDOSSOS-NUM-ENDOSSO. */
            _.Move(0, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO);

            /*" -2913- MOVE APOLICES-RAMO-EMISSOR TO ENDOSSOS-RAMO-EMISSOR. */
            _.Move(APOLICES.DCLAPOLICES.APOLICES_RAMO_EMISSOR, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_RAMO_EMISSOR);

            /*" -2915- MOVE APOLICES-COD-PRODUTO TO ENDOSSOS-COD-PRODUTO. */
            _.Move(APOLICES.DCLAPOLICES.APOLICES_COD_PRODUTO, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_PRODUTO);

            /*" -2917- MOVE ZEROS TO ENDOSSOS-COD-SUBGRUPO. */
            _.Move(0, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_SUBGRUPO);

            /*" -2919- MOVE BILHETE-FONTE TO ENDOSSOS-COD-FONTE. */
            _.Move(BILHETE.DCLBILHETE.BILHETE_FONTE, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_FONTE);

            /*" -2921- MOVE FONTES-ULT-PROP-AUTOMAT TO ENDOSSOS-NUM-PROPOSTA. */
            _.Move(FONTES.DCLFONTES.FONTES_ULT_PROP_AUTOMAT, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_PROPOSTA);

            /*" -2923- MOVE BILHETE-DATA-VENDA TO ENDOSSOS-DATA-PROPOSTA. */
            _.Move(BILHETE.DCLBILHETE.BILHETE_DATA_VENDA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_PROPOSTA);

            /*" -2925- MOVE SISTEMAS-DATA-MOV-ABERTO TO ENDOSSOS-DATA-LIBERACAO. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_LIBERACAO);

            /*" -2927- MOVE SISTEMAS-DATA-MOV-ABERTO TO ENDOSSOS-DATA-EMISSAO. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_EMISSAO);

            /*" -2929- MOVE ZEROS TO ENDOSSOS-NUM-RCAP. */
            _.Move(0, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_RCAP);

            /*" -2931- MOVE ZEROS TO ENDOSSOS-VAL-RCAP. */
            _.Move(0, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_VAL_RCAP);

            /*" -2933- MOVE ZEROS TO ENDOSSOS-BCO-RCAP. */
            _.Move(0, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_BCO_RCAP);

            /*" -2935- MOVE ZEROS TO ENDOSSOS-AGE-RCAP. */
            _.Move(0, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_AGE_RCAP);

            /*" -2937- MOVE '0' TO ENDOSSOS-DAC-RCAP. */
            _.Move("0", ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DAC_RCAP);

            /*" -2939- MOVE '0' TO ENDOSSOS-TIPO-RCAP. */
            _.Move("0", ENDOSSOS.DCLENDOSSOS.ENDOSSOS_TIPO_RCAP);

            /*" -2941- MOVE 104 TO ENDOSSOS-BCO-COBRANCA. */
            _.Move(104, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_BCO_COBRANCA);

            /*" -2943- MOVE ZEROS TO ENDOSSOS-AGE-COBRANCA. */
            _.Move(0, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_AGE_COBRANCA);

            /*" -2945- MOVE '0' TO ENDOSSOS-DAC-COBRANCA. */
            _.Move("0", ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DAC_COBRANCA);

            /*" -2947- MOVE WSGER00-DATA-INIVIGENCIA TO ENDOSSOS-DATA-INIVIGENCIA. */
            _.Move(WSGER00_DATA_INIVIGENCIA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA);

            /*" -2949- MOVE WSGER00-DATA-TERVIGENCIA TO ENDOSSOS-DATA-TERVIGENCIA. */
            _.Move(WSGER00_DATA_TERVIGENCIA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_TERVIGENCIA);

            /*" -2951- MOVE ZEROS TO ENDOSSOS-PLANO-SEGURO. */
            _.Move(0, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_PLANO_SEGURO);

            /*" -2953- MOVE ZEROS TO ENDOSSOS-PCT-ENTRADA. */
            _.Move(0, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_PCT_ENTRADA);

            /*" -2955- MOVE ZEROS TO ENDOSSOS-PCT-ADIC-FRACIO. */
            _.Move(0, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_PCT_ADIC_FRACIO);

            /*" -2957- MOVE ZEROS TO ENDOSSOS-QTD-DIAS-PRIMEIRA. */
            _.Move(0, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_QTD_DIAS_PRIMEIRA);

            /*" -2959- MOVE 60 TO ENDOSSOS-QTD-PARCELAS. */
            _.Move(60, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_QTD_PARCELAS);

            /*" -2961- MOVE ZEROS TO ENDOSSOS-QTD-PRESTACOES. */
            _.Move(0, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_QTD_PRESTACOES);

            /*" -2963- MOVE 1 TO ENDOSSOS-QTD-ITENS. */
            _.Move(1, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_QTD_ITENS);

            /*" -2965- MOVE SPACES TO ENDOSSOS-COD-TEXTO-PADRAO. */
            _.Move("", ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_TEXTO_PADRAO);

            /*" -2967- MOVE '0' TO ENDOSSOS-COD-ACEITACAO. */
            _.Move("0", ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_ACEITACAO);

            /*" -2969- MOVE BILHECOB-COD-MOEDA TO ENDOSSOS-COD-MOEDA-IMP. */
            _.Move(BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_COD_MOEDA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_MOEDA_IMP);

            /*" -2971- MOVE BILHECOB-COD-MOEDA TO ENDOSSOS-COD-MOEDA-PRM. */
            _.Move(BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_COD_MOEDA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_MOEDA_PRM);

            /*" -2973- MOVE '0' TO ENDOSSOS-TIPO-ENDOSSO. */
            _.Move("0", ENDOSSOS.DCLENDOSSOS.ENDOSSOS_TIPO_ENDOSSO);

            /*" -2975- MOVE 'BI6252B' TO ENDOSSOS-COD-USUARIO. */
            _.Move("BI6252B", ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_USUARIO);

            /*" -2977- MOVE BILHETE-OCORR-ENDERECO TO ENDOSSOS-OCORR-ENDERECO. */
            _.Move(BILHETE.DCLBILHETE.BILHETE_OCORR_ENDERECO, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_OCORR_ENDERECO);

            /*" -2979- MOVE '0' TO ENDOSSOS-SIT-REGISTRO. */
            _.Move("0", ENDOSSOS.DCLENDOSSOS.ENDOSSOS_SIT_REGISTRO);

            /*" -2981- MOVE SPACES TO ENDOSSOS-DATA-RCAP. */
            _.Move("", ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_RCAP);

            /*" -2983- MOVE -1 TO VIND-DATARCAP. */
            _.Move(-1, VIND_DATARCAP);

            /*" -2985- MOVE ZEROS TO ENDOSSOS-COD-EMPRESA. */
            _.Move(0, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_EMPRESA);

            /*" -2987- MOVE ZEROS TO VIND-CODEMP. */
            _.Move(0, VIND_CODEMP);

            /*" -2989- MOVE '1' TO ENDOSSOS-TIPO-CORRECAO. */
            _.Move("1", ENDOSSOS.DCLENDOSSOS.ENDOSSOS_TIPO_CORRECAO);

            /*" -2991- MOVE ZEROS TO VIND-CORRECAO. */
            _.Move(0, VIND_CORRECAO);

            /*" -2993- MOVE 'S' TO ENDOSSOS-ISENTA-CUSTO. */
            _.Move("S", ENDOSSOS.DCLENDOSSOS.ENDOSSOS_ISENTA_CUSTO);

            /*" -2995- MOVE ZEROS TO VIND-ISENTA. */
            _.Move(0, VIND_ISENTA);

            /*" -2997- MOVE SPACES TO ENDOSSOS-DATA-VENCIMENTO. */
            _.Move("", ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_VENCIMENTO);

            /*" -2999- MOVE -1 TO VIND-DTVENCTO. */
            _.Move(-1, VIND_DTVENCTO);

            /*" -3001- MOVE ZEROS TO ENDOSSOS-COEF-PREFIX. */
            _.Move(0, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COEF_PREFIX);

            /*" -3003- MOVE -1 TO VIND-PREFIX. */
            _.Move(-1, VIND_PREFIX);

            /*" -3005- MOVE ZEROS TO ENDOSSOS-VAL-CUSTO-EMISSAO. */
            _.Move(0, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_VAL_CUSTO_EMISSAO);

            /*" -3012- MOVE -1 TO VIND-CUSEMIS. */
            _.Move(-1, VIND_CUSEMIS);

            /*" -3018- PERFORM R3520-00-INSERT-ENDOSSOS. */

            R3520_00_INSERT_ENDOSSOS_SECTION();

            /*" -3020- MOVE ENDOSSOS-NUM-APOLICE TO PARCELAS-NUM-APOLICE. */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE, PARCELAS.DCLPARCELAS.PARCELAS_NUM_APOLICE);

            /*" -3022- MOVE ENDOSSOS-NUM-ENDOSSO TO PARCELAS-NUM-ENDOSSO. */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO, PARCELAS.DCLPARCELAS.PARCELAS_NUM_ENDOSSO);

            /*" -3024- MOVE ZEROS TO PARCELAS-NUM-PARCELA. */
            _.Move(0, PARCELAS.DCLPARCELAS.PARCELAS_NUM_PARCELA);

            /*" -3026- MOVE '0' TO PARCELAS-DAC-PARCELA. */
            _.Move("0", PARCELAS.DCLPARCELAS.PARCELAS_DAC_PARCELA);

            /*" -3028- MOVE ENDOSSOS-COD-FONTE TO PARCELAS-COD-FONTE. */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_FONTE, PARCELAS.DCLPARCELAS.PARCELAS_COD_FONTE);

            /*" -3030- MOVE ZEROS TO PARCELAS-NUM-TITULO. */
            _.Move(0, PARCELAS.DCLPARCELAS.PARCELAS_NUM_TITULO);

            /*" -3032- MOVE ZEROS TO PARCELAS-PRM-TARIFARIO-IX. */
            _.Move(0, PARCELAS.DCLPARCELAS.PARCELAS_PRM_TARIFARIO_IX);

            /*" -3034- MOVE ZEROS TO PARCELAS-VAL-DESCONTO-IX. */
            _.Move(0, PARCELAS.DCLPARCELAS.PARCELAS_VAL_DESCONTO_IX);

            /*" -3036- MOVE ZEROS TO PARCELAS-PRM-LIQUIDO-IX. */
            _.Move(0, PARCELAS.DCLPARCELAS.PARCELAS_PRM_LIQUIDO_IX);

            /*" -3038- MOVE ZEROS TO PARCELAS-ADICIONAL-FRAC-IX. */
            _.Move(0, PARCELAS.DCLPARCELAS.PARCELAS_ADICIONAL_FRAC_IX);

            /*" -3040- MOVE ZEROS TO PARCELAS-VAL-CUSTO-EMIS-IX. */
            _.Move(0, PARCELAS.DCLPARCELAS.PARCELAS_VAL_CUSTO_EMIS_IX);

            /*" -3042- MOVE ZEROS TO PARCELAS-VAL-IOCC-IX. */
            _.Move(0, PARCELAS.DCLPARCELAS.PARCELAS_VAL_IOCC_IX);

            /*" -3044- MOVE ZEROS TO PARCELAS-VAL-CUSTO-EMIS-IX */
            _.Move(0, PARCELAS.DCLPARCELAS.PARCELAS_VAL_CUSTO_EMIS_IX);

            /*" -3046- MOVE ZEROS TO PARCELAS-PRM-TOTAL-IX. */
            _.Move(0, PARCELAS.DCLPARCELAS.PARCELAS_PRM_TOTAL_IX);

            /*" -3048- MOVE 1 TO PARCELAS-OCORR-HISTORICO. */
            _.Move(1, PARCELAS.DCLPARCELAS.PARCELAS_OCORR_HISTORICO);

            /*" -3050- MOVE ZEROS TO PARCELAS-QTD-DOCUMENTOS. */
            _.Move(0, PARCELAS.DCLPARCELAS.PARCELAS_QTD_DOCUMENTOS);

            /*" -3052- MOVE '0' TO PARCELAS-SIT-REGISTRO. */
            _.Move("0", PARCELAS.DCLPARCELAS.PARCELAS_SIT_REGISTRO);

            /*" -3054- MOVE ENDOSSOS-COD-EMPRESA TO PARCELAS-COD-EMPRESA. */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_EMPRESA, PARCELAS.DCLPARCELAS.PARCELAS_COD_EMPRESA);

            /*" -3056- MOVE ZEROS TO VIND-CODEMP. */
            _.Move(0, VIND_CODEMP);

            /*" -3058- MOVE SPACES TO PARCELAS-SITUACAO-COBRANCA. */
            _.Move("", PARCELAS.DCLPARCELAS.PARCELAS_SITUACAO_COBRANCA);

            /*" -3065- MOVE -1 TO VIND-SIT-COBRANCA. */
            _.Move(-1, VIND_SIT_COBRANCA);

            /*" -3071- PERFORM R3530-00-INSERT-PARCELAS. */

            R3530_00_INSERT_PARCELAS_SECTION();

            /*" -3073- MOVE PARCELAS-NUM-APOLICE TO PARCEHIS-NUM-APOLICE. */
            _.Move(PARCELAS.DCLPARCELAS.PARCELAS_NUM_APOLICE, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE);

            /*" -3075- MOVE PARCELAS-NUM-ENDOSSO TO PARCEHIS-NUM-ENDOSSO. */
            _.Move(PARCELAS.DCLPARCELAS.PARCELAS_NUM_ENDOSSO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO);

            /*" -3077- MOVE PARCELAS-NUM-PARCELA TO PARCEHIS-NUM-PARCELA. */
            _.Move(PARCELAS.DCLPARCELAS.PARCELAS_NUM_PARCELA, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_PARCELA);

            /*" -3079- MOVE PARCELAS-DAC-PARCELA TO PARCEHIS-DAC-PARCELA. */
            _.Move(PARCELAS.DCLPARCELAS.PARCELAS_DAC_PARCELA, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DAC_PARCELA);

            /*" -3081- MOVE SISTEMAS-DATA-MOV-ABERTO TO PARCEHIS-DATA-MOVIMENTO. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_MOVIMENTO);

            /*" -3083- MOVE 101 TO PARCEHIS-COD-OPERACAO. */
            _.Move(101, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_COD_OPERACAO);

            /*" -3085- MOVE 1 TO PARCEHIS-OCORR-HISTORICO. */
            _.Move(1, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_OCORR_HISTORICO);

            /*" -3087- MOVE PARCELAS-PRM-TARIFARIO-IX TO PARCEHIS-PRM-TARIFARIO. */
            _.Move(PARCELAS.DCLPARCELAS.PARCELAS_PRM_TARIFARIO_IX, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_PRM_TARIFARIO);

            /*" -3089- MOVE PARCELAS-VAL-DESCONTO-IX TO PARCEHIS-VAL-DESCONTO. */
            _.Move(PARCELAS.DCLPARCELAS.PARCELAS_VAL_DESCONTO_IX, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_VAL_DESCONTO);

            /*" -3091- MOVE PARCELAS-PRM-LIQUIDO-IX TO PARCEHIS-PRM-LIQUIDO. */
            _.Move(PARCELAS.DCLPARCELAS.PARCELAS_PRM_LIQUIDO_IX, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_PRM_LIQUIDO);

            /*" -3093- MOVE PARCELAS-ADICIONAL-FRAC-IX TO PARCEHIS-ADICIONAL-FRACIO. */
            _.Move(PARCELAS.DCLPARCELAS.PARCELAS_ADICIONAL_FRAC_IX, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_ADICIONAL_FRACIO);

            /*" -3095- MOVE PARCELAS-VAL-CUSTO-EMIS-IX TO PARCEHIS-VAL-CUSTO-EMISSAO. */
            _.Move(PARCELAS.DCLPARCELAS.PARCELAS_VAL_CUSTO_EMIS_IX, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_VAL_CUSTO_EMISSAO);

            /*" -3097- MOVE PARCELAS-VAL-IOCC-IX TO PARCEHIS-VAL-IOCC. */
            _.Move(PARCELAS.DCLPARCELAS.PARCELAS_VAL_IOCC_IX, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_VAL_IOCC);

            /*" -3099- MOVE PARCELAS-PRM-TOTAL-IX TO PARCEHIS-PRM-TOTAL. */
            _.Move(PARCELAS.DCLPARCELAS.PARCELAS_PRM_TOTAL_IX, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_PRM_TOTAL);

            /*" -3101- MOVE ZEROS TO PARCEHIS-VAL-OPERACAO. */
            _.Move(0, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_VAL_OPERACAO);

            /*" -3103- MOVE WSGER00-DATA-VENCIMENTO TO PARCEHIS-DATA-VENCIMENTO. */
            _.Move(WSGER00_DATA_VENCIMENTO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_VENCIMENTO);

            /*" -3105- MOVE ENDOSSOS-BCO-COBRANCA TO PARCEHIS-BCO-COBRANCA. */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_BCO_COBRANCA, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_BCO_COBRANCA);

            /*" -3107- MOVE ENDOSSOS-AGE-COBRANCA TO PARCEHIS-AGE-COBRANCA. */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_AGE_COBRANCA, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_AGE_COBRANCA);

            /*" -3109- MOVE ZEROS TO PARCEHIS-NUM-AVISO-CREDITO. */
            _.Move(0, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_AVISO_CREDITO);

            /*" -3111- MOVE ZEROS TO PARCEHIS-ENDOS-CANCELA. */
            _.Move(0, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_ENDOS_CANCELA);

            /*" -3113- MOVE '0' TO PARCEHIS-SIT-CONTABIL. */
            _.Move("0", PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_SIT_CONTABIL);

            /*" -3115- MOVE ENDOSSOS-COD-USUARIO TO PARCEHIS-COD-USUARIO. */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_USUARIO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_COD_USUARIO);

            /*" -3117- MOVE ZEROS TO PARCEHIS-RENUM-DOCUMENTO. */
            _.Move(0, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_RENUM_DOCUMENTO);

            /*" -3119- MOVE SPACES TO PARCEHIS-DATA-QUITACAO. */
            _.Move("", PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_QUITACAO);

            /*" -3121- MOVE -1 TO VIND-DTQITBCO. */
            _.Move(-1, VIND_DTQITBCO);

            /*" -3123- MOVE PARCELAS-COD-EMPRESA TO PARCEHIS-COD-EMPRESA. */
            _.Move(PARCELAS.DCLPARCELAS.PARCELAS_COD_EMPRESA, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_COD_EMPRESA);

            /*" -3130- MOVE ZEROS TO VIND-CODEMP. */
            _.Move(0, VIND_CODEMP);

            /*" -3136- PERFORM R3550-00-INSERT-PARCEHIS. */

            R3550_00_INSERT_PARCEHIS_SECTION();

            /*" -3138- MOVE PARCELAS-NUM-APOLICE TO APOLICOB-NUM-APOLICE. */
            _.Move(PARCELAS.DCLPARCELAS.PARCELAS_NUM_APOLICE, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_NUM_APOLICE);

            /*" -3140- MOVE PARCELAS-NUM-ENDOSSO TO APOLICOB-NUM-ENDOSSO. */
            _.Move(PARCELAS.DCLPARCELAS.PARCELAS_NUM_ENDOSSO, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_NUM_ENDOSSO);

            /*" -3142- MOVE ZEROS TO APOLICOB-NUM-ITEM. */
            _.Move(0, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_NUM_ITEM);

            /*" -3144- MOVE ZEROS TO APOLICOB-OCORR-HISTORICO. */
            _.Move(0, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_OCORR_HISTORICO);

            /*" -3146- MOVE ENDOSSOS-RAMO-EMISSOR TO APOLICOB-RAMO-COBERTURA. */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_RAMO_EMISSOR, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_RAMO_COBERTURA);

            /*" -3148- MOVE APOLICES-COD-MODALIDADE TO APOLICOB-MODALI-COBERTURA. */
            _.Move(APOLICES.DCLAPOLICES.APOLICES_COD_MODALIDADE, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_MODALI_COBERTURA);

            /*" -3150- MOVE ZEROS TO APOLICOB-COD-COBERTURA. */
            _.Move(0, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_COD_COBERTURA);

            /*" -3152- MOVE ZEROS TO APOLICOB-IMP-SEGURADA-IX. */
            _.Move(0, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_IMP_SEGURADA_IX);

            /*" -3154- MOVE ZEROS TO APOLICOB-PRM-TARIFARIO-IX. */
            _.Move(0, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_PRM_TARIFARIO_IX);

            /*" -3156- MOVE ZEROS TO APOLICOB-IMP-SEGURADA-VAR. */
            _.Move(0, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_IMP_SEGURADA_VAR);

            /*" -3158- MOVE ZEROS TO APOLICOB-PRM-TARIFARIO-VAR. */
            _.Move(0, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_PRM_TARIFARIO_VAR);

            /*" -3160- MOVE 100 TO APOLICOB-PCT-COBERTURA. */
            _.Move(100, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_PCT_COBERTURA);

            /*" -3162- MOVE 1 TO APOLICOB-FATOR-MULTIPLICA. */
            _.Move(1, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_FATOR_MULTIPLICA);

            /*" -3164- MOVE ENDOSSOS-DATA-INIVIGENCIA TO APOLICOB-DATA-INIVIGENCIA. */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_DATA_INIVIGENCIA);

            /*" -3166- MOVE ENDOSSOS-DATA-TERVIGENCIA TO APOLICOB-DATA-TERVIGENCIA. */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_TERVIGENCIA, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_DATA_TERVIGENCIA);

            /*" -3168- MOVE ENDOSSOS-COD-EMPRESA TO APOLICOB-COD-EMPRESA. */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_EMPRESA, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_COD_EMPRESA);

            /*" -3169- MOVE ZEROS TO VIND-CODEMP. */
            _.Move(0, VIND_CODEMP);

            /*" -3171- MOVE '0' TO APOLICOB-SIT-REGISTRO. */
            _.Move("0", APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_SIT_REGISTRO);

            /*" -3177- MOVE ZEROS TO VIND-SITUACAO. */
            _.Move(0, VIND_SITUACAO);

            /*" -3177- PERFORM R3600-00-INSERT-APOLICOB. */

            R3600_00_INSERT_APOLICOB_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3200_99_SAIDA*/

        [StopWatch]
        /*" R3250-00-SELECT-FONTES-SECTION */
        private void R3250_00_SELECT_FONTES_SECTION()
        {
            /*" -3190- MOVE '3250' TO WNR-EXEC-SQL. */
            _.Move("3250", AUX_RELATORIO.WABEND.WNR_EXEC_SQL);

            /*" -3193- MOVE BILHETE-FONTE TO FONTES-COD-FONTE. */
            _.Move(BILHETE.DCLBILHETE.BILHETE_FONTE, FONTES.DCLFONTES.FONTES_COD_FONTE);

            /*" -3202- PERFORM R3250_00_SELECT_FONTES_DB_SELECT_1 */

            R3250_00_SELECT_FONTES_DB_SELECT_1();

            /*" -3206- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3207- DISPLAY 'R3250-00 - PROBLEMAS NO SELECT(FONTES)  ' */
                _.Display($"R3250-00 - PROBLEMAS NO SELECT(FONTES)  ");

                /*" -3208- DISPLAY 'NUM-NOSSO-TITULO = ' MOVIMCOB-NUM-NOSSO-TITULO */
                _.Display($"NUM-NOSSO-TITULO = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_NOSSO_TITULO}");

                /*" -3209- DISPLAY 'NUM-BILHETE      = ' BILHETE-NUM-BILHETE */
                _.Display($"NUM-BILHETE      = {BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE}");

                /*" -3210- DISPLAY 'COD-FONTE        = ' BILHETE-FONTE */
                _.Display($"COD-FONTE        = {BILHETE.DCLBILHETE.BILHETE_FONTE}");

                /*" -3212- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3215- COMPUTE FONTES-ULT-PROP-AUTOMAT EQUAL (FONTES-ULT-PROP-AUTOMAT + 1). */
            FONTES.DCLFONTES.FONTES_ULT_PROP_AUTOMAT.Value = (FONTES.DCLFONTES.FONTES_ULT_PROP_AUTOMAT + 1);

            /*" -3217- MOVE ZEROS TO AC-CONTROLE. */
            _.Move(0, W.AC_CONTROLE);

            /*" -3219- PERFORM R3300-00-SELECT-ENDOSSOS. */

            R3300_00_SELECT_ENDOSSOS_SECTION();

            /*" -3219- PERFORM R3350-00-UPDATE-FONTES. */

            R3350_00_UPDATE_FONTES_SECTION();

        }

        [StopWatch]
        /*" R3250-00-SELECT-FONTES-DB-SELECT-1 */
        public void R3250_00_SELECT_FONTES_DB_SELECT_1()
        {
            /*" -3202- EXEC SQL SELECT ORGAO_EMISSOR , ULT_PROP_AUTOMAT INTO :FONTES-ORGAO-EMISSOR , :FONTES-ULT-PROP-AUTOMAT FROM SEGUROS.FONTES WHERE COD_FONTE = :FONTES-COD-FONTE WITH UR END-EXEC. */

            var r3250_00_SELECT_FONTES_DB_SELECT_1_Query1 = new R3250_00_SELECT_FONTES_DB_SELECT_1_Query1()
            {
                FONTES_COD_FONTE = FONTES.DCLFONTES.FONTES_COD_FONTE.ToString(),
            };

            var executed_1 = R3250_00_SELECT_FONTES_DB_SELECT_1_Query1.Execute(r3250_00_SELECT_FONTES_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.FONTES_ORGAO_EMISSOR, FONTES.DCLFONTES.FONTES_ORGAO_EMISSOR);
                _.Move(executed_1.FONTES_ULT_PROP_AUTOMAT, FONTES.DCLFONTES.FONTES_ULT_PROP_AUTOMAT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3250_99_SAIDA*/

        [StopWatch]
        /*" R3300-00-SELECT-ENDOSSOS-SECTION */
        private void R3300_00_SELECT_ENDOSSOS_SECTION()
        {
            /*" -3232- MOVE '3300' TO WNR-EXEC-SQL. */
            _.Move("3300", AUX_RELATORIO.WABEND.WNR_EXEC_SQL);

            /*" -3241- PERFORM R3300_00_SELECT_ENDOSSOS_DB_SELECT_1 */

            R3300_00_SELECT_ENDOSSOS_DB_SELECT_1();

            /*" -3245- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -3247- GO TO R3300-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3300_99_SAIDA*/ //GOTO
                return;
            }


            /*" -3248- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3249- DISPLAY 'R3300-00 - PROBLEMAS NO SELECT(ENDOSSOS)' */
                _.Display($"R3300-00 - PROBLEMAS NO SELECT(ENDOSSOS)");

                /*" -3250- DISPLAY 'NUM-NOSSO-TITULO = ' MOVIMCOB-NUM-NOSSO-TITULO */
                _.Display($"NUM-NOSSO-TITULO = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_NOSSO_TITULO}");

                /*" -3251- DISPLAY 'NUM-BILHETE      = ' BILHETE-NUM-BILHETE */
                _.Display($"NUM-BILHETE      = {BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE}");

                /*" -3252- DISPLAY 'COD-FONTE        = ' BILHETE-FONTE */
                _.Display($"COD-FONTE        = {BILHETE.DCLBILHETE.BILHETE_FONTE}");

                /*" -3253- DISPLAY 'NUM_PROPOSTA     = ' FONTES-ULT-PROP-AUTOMAT */
                _.Display($"NUM_PROPOSTA     = {FONTES.DCLFONTES.FONTES_ULT_PROP_AUTOMAT}");

                /*" -3256- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3258- ADD 1 TO AC-CONTROLE. */
            W.AC_CONTROLE.Value = W.AC_CONTROLE + 1;

            /*" -3259- IF AC-CONTROLE GREATER 100 */

            if (W.AC_CONTROLE > 100)
            {

                /*" -3260- DISPLAY 'R3300-00 - PROPOSTA DUPLICIDADE ENDOSSOS' */
                _.Display($"R3300-00 - PROPOSTA DUPLICIDADE ENDOSSOS");

                /*" -3262- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3265- COMPUTE FONTES-ULT-PROP-AUTOMAT EQUAL (FONTES-ULT-PROP-AUTOMAT + 1). */
            FONTES.DCLFONTES.FONTES_ULT_PROP_AUTOMAT.Value = (FONTES.DCLFONTES.FONTES_ULT_PROP_AUTOMAT + 1);

            /*" -3265- GO TO R3300-00-SELECT-ENDOSSOS. */
            new Task(() => R3300_00_SELECT_ENDOSSOS_SECTION()).RunSynchronously(); //GOTO
            return;//Recursividade detectada, cuidado...

        }

        [StopWatch]
        /*" R3300-00-SELECT-ENDOSSOS-DB-SELECT-1 */
        public void R3300_00_SELECT_ENDOSSOS_DB_SELECT_1()
        {
            /*" -3241- EXEC SQL SELECT NUM_PROPOSTA INTO :ENDOSSOS-NUM-PROPOSTA FROM SEGUROS.ENDOSSOS WHERE COD_FONTE = :FONTES-COD-FONTE AND NUM_PROPOSTA = :FONTES-ULT-PROP-AUTOMAT WITH UR END-EXEC. */

            var r3300_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1 = new R3300_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1()
            {
                FONTES_ULT_PROP_AUTOMAT = FONTES.DCLFONTES.FONTES_ULT_PROP_AUTOMAT.ToString(),
                FONTES_COD_FONTE = FONTES.DCLFONTES.FONTES_COD_FONTE.ToString(),
            };

            var executed_1 = R3300_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1.Execute(r3300_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.ENDOSSOS_NUM_PROPOSTA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_PROPOSTA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3300_99_SAIDA*/

        [StopWatch]
        /*" R3350-00-UPDATE-FONTES-SECTION */
        private void R3350_00_UPDATE_FONTES_SECTION()
        {
            /*" -3278- MOVE '3350' TO WNR-EXEC-SQL. */
            _.Move("3350", AUX_RELATORIO.WABEND.WNR_EXEC_SQL);

            /*" -3284- PERFORM R3350_00_UPDATE_FONTES_DB_UPDATE_1 */

            R3350_00_UPDATE_FONTES_DB_UPDATE_1();

            /*" -3288- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3289- DISPLAY 'R3350-00 - PROBLEMAS UPDATE (FONTES)      ' */
                _.Display($"R3350-00 - PROBLEMAS UPDATE (FONTES)      ");

                /*" -3290- DISPLAY 'NUM-NOSSO-TITULO = ' MOVIMCOB-NUM-NOSSO-TITULO */
                _.Display($"NUM-NOSSO-TITULO = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_NOSSO_TITULO}");

                /*" -3291- DISPLAY 'NUM-BILHETE      = ' BILHETE-NUM-BILHETE */
                _.Display($"NUM-BILHETE      = {BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE}");

                /*" -3292- DISPLAY 'COD-FONTE        = ' BILHETE-FONTE */
                _.Display($"COD-FONTE        = {BILHETE.DCLBILHETE.BILHETE_FONTE}");

                /*" -3293- DISPLAY 'NUM_PROPOSTA     = ' FONTES-ULT-PROP-AUTOMAT */
                _.Display($"NUM_PROPOSTA     = {FONTES.DCLFONTES.FONTES_ULT_PROP_AUTOMAT}");

                /*" -3293- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R3350-00-UPDATE-FONTES-DB-UPDATE-1 */
        public void R3350_00_UPDATE_FONTES_DB_UPDATE_1()
        {
            /*" -3284- EXEC SQL UPDATE SEGUROS.FONTES SET ULT_PROP_AUTOMAT = :FONTES-ULT-PROP-AUTOMAT WHERE COD_FONTE = :FONTES-COD-FONTE END-EXEC. */

            var r3350_00_UPDATE_FONTES_DB_UPDATE_1_Update1 = new R3350_00_UPDATE_FONTES_DB_UPDATE_1_Update1()
            {
                FONTES_ULT_PROP_AUTOMAT = FONTES.DCLFONTES.FONTES_ULT_PROP_AUTOMAT.ToString(),
                FONTES_COD_FONTE = FONTES.DCLFONTES.FONTES_COD_FONTE.ToString(),
            };

            R3350_00_UPDATE_FONTES_DB_UPDATE_1_Update1.Execute(r3350_00_UPDATE_FONTES_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3350_99_SAIDA*/

        [StopWatch]
        /*" R3520-00-INSERT-ENDOSSOS-SECTION */
        private void R3520_00_INSERT_ENDOSSOS_SECTION()
        {
            /*" -3306- MOVE '3520' TO WNR-EXEC-SQL. */
            _.Move("3520", AUX_RELATORIO.WABEND.WNR_EXEC_SQL);

            /*" -3397- PERFORM R3520_00_INSERT_ENDOSSOS_DB_INSERT_1 */

            R3520_00_INSERT_ENDOSSOS_DB_INSERT_1();

            /*" -3400- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3401- DISPLAY 'R3520-00 - PROBLEMAS NO INSERT(ENDOSSOS)   ' */
                _.Display($"R3520-00 - PROBLEMAS NO INSERT(ENDOSSOS)   ");

                /*" -3402- DISPLAY 'SIT-REGISTRO    = ' MOVIMCOB-SIT-REGISTRO */
                _.Display($"SIT-REGISTRO    = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_SIT_REGISTRO}");

                /*" -3403- DISPLAY 'COD-BANCO       = ' MOVIMCOB-COD-BANCO */
                _.Display($"COD-BANCO       = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_BANCO}");

                /*" -3404- DISPLAY 'COD-AGENCIA     = ' MOVIMCOB-COD-AGENCIA */
                _.Display($"COD-AGENCIA     = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_AGENCIA}");

                /*" -3405- DISPLAY 'NUM-AVISO       = ' MOVIMCOB-NUM-AVISO */
                _.Display($"NUM-AVISO       = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_AVISO}");

                /*" -3406- DISPLAY 'NUM-NOSSO-TITULO= ' MOVIMCOB-NUM-NOSSO-TITULO */
                _.Display($"NUM-NOSSO-TITULO= {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_NOSSO_TITULO}");

                /*" -3407- DISPLAY 'COD-MOVIMENTO   = ' MOVIMCOB-COD-MOVIMENTO */
                _.Display($"COD-MOVIMENTO   = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_MOVIMENTO}");

                /*" -3408- DISPLAY 'NOME-SEGURADO   = ' MOVIMCOB-NOME-SEGURADO */
                _.Display($"NOME-SEGURADO   = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NOME_SEGURADO}");

                /*" -3409- DISPLAY 'NUM-APOLICE     = ' ENDOSSOS-NUM-APOLICE */
                _.Display($"NUM-APOLICE     = {ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE}");

                /*" -3410- DISPLAY 'NUM-ENDOSSO     = ' ENDOSSOS-NUM-ENDOSSO */
                _.Display($"NUM-ENDOSSO     = {ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO}");

                /*" -3410- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R3520-00-INSERT-ENDOSSOS-DB-INSERT-1 */
        public void R3520_00_INSERT_ENDOSSOS_DB_INSERT_1()
        {
            /*" -3397- EXEC SQL INSERT INTO SEGUROS.ENDOSSOS (NUM_APOLICE , NUM_ENDOSSO , RAMO_EMISSOR , COD_PRODUTO , COD_SUBGRUPO , COD_FONTE , NUM_PROPOSTA , DATA_PROPOSTA , DATA_LIBERACAO , DATA_EMISSAO , NUM_RCAP , VAL_RCAP , BCO_RCAP , AGE_RCAP , DAC_RCAP , TIPO_RCAP , BCO_COBRANCA , AGE_COBRANCA , DAC_COBRANCA , DATA_INIVIGENCIA , DATA_TERVIGENCIA , PLANO_SEGURO , PCT_ENTRADA , PCT_ADIC_FRACIO , QTD_DIAS_PRIMEIRA , QTD_PARCELAS , QTD_PRESTACOES , QTD_ITENS , COD_TEXTO_PADRAO , COD_ACEITACAO , COD_MOEDA_IMP , COD_MOEDA_PRM , TIPO_ENDOSSO , COD_USUARIO , OCORR_ENDERECO , SIT_REGISTRO , DATA_RCAP , COD_EMPRESA , TIPO_CORRECAO , ISENTA_CUSTO , TIMESTAMP , DATA_VENCIMENTO , COEF_PREFIX , VAL_CUSTO_EMISSAO) VALUES (:ENDOSSOS-NUM-APOLICE , :ENDOSSOS-NUM-ENDOSSO , :ENDOSSOS-RAMO-EMISSOR , :ENDOSSOS-COD-PRODUTO , :ENDOSSOS-COD-SUBGRUPO , :ENDOSSOS-COD-FONTE , :ENDOSSOS-NUM-PROPOSTA , :ENDOSSOS-DATA-PROPOSTA , :ENDOSSOS-DATA-LIBERACAO , :ENDOSSOS-DATA-EMISSAO , :ENDOSSOS-NUM-RCAP , :ENDOSSOS-VAL-RCAP , :ENDOSSOS-BCO-RCAP , :ENDOSSOS-AGE-RCAP , :ENDOSSOS-DAC-RCAP , :ENDOSSOS-TIPO-RCAP , :ENDOSSOS-BCO-COBRANCA , :ENDOSSOS-AGE-COBRANCA , :ENDOSSOS-DAC-COBRANCA , :ENDOSSOS-DATA-INIVIGENCIA , :ENDOSSOS-DATA-TERVIGENCIA , :ENDOSSOS-PLANO-SEGURO , :ENDOSSOS-PCT-ENTRADA , :ENDOSSOS-PCT-ADIC-FRACIO , :ENDOSSOS-QTD-DIAS-PRIMEIRA , :ENDOSSOS-QTD-PARCELAS , :ENDOSSOS-QTD-PRESTACOES , :ENDOSSOS-QTD-ITENS , :ENDOSSOS-COD-TEXTO-PADRAO , :ENDOSSOS-COD-ACEITACAO , :ENDOSSOS-COD-MOEDA-IMP , :ENDOSSOS-COD-MOEDA-PRM , :ENDOSSOS-TIPO-ENDOSSO , :ENDOSSOS-COD-USUARIO , :ENDOSSOS-OCORR-ENDERECO , :ENDOSSOS-SIT-REGISTRO , :ENDOSSOS-DATA-RCAP:VIND-DATARCAP , :ENDOSSOS-COD-EMPRESA:VIND-CODEMP , :ENDOSSOS-TIPO-CORRECAO:VIND-CORRECAO , :ENDOSSOS-ISENTA-CUSTO:VIND-ISENTA , CURRENT TIMESTAMP , :ENDOSSOS-DATA-VENCIMENTO:VIND-DTVENCTO , :ENDOSSOS-COEF-PREFIX:VIND-PREFIX , :ENDOSSOS-VAL-CUSTO-EMISSAO:VIND-CUSEMIS) END-EXEC. */

            var r3520_00_INSERT_ENDOSSOS_DB_INSERT_1_Insert1 = new R3520_00_INSERT_ENDOSSOS_DB_INSERT_1_Insert1()
            {
                ENDOSSOS_NUM_APOLICE = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE.ToString(),
                ENDOSSOS_NUM_ENDOSSO = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO.ToString(),
                ENDOSSOS_RAMO_EMISSOR = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_RAMO_EMISSOR.ToString(),
                ENDOSSOS_COD_PRODUTO = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_PRODUTO.ToString(),
                ENDOSSOS_COD_SUBGRUPO = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_SUBGRUPO.ToString(),
                ENDOSSOS_COD_FONTE = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_FONTE.ToString(),
                ENDOSSOS_NUM_PROPOSTA = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_PROPOSTA.ToString(),
                ENDOSSOS_DATA_PROPOSTA = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_PROPOSTA.ToString(),
                ENDOSSOS_DATA_LIBERACAO = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_LIBERACAO.ToString(),
                ENDOSSOS_DATA_EMISSAO = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_EMISSAO.ToString(),
                ENDOSSOS_NUM_RCAP = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_RCAP.ToString(),
                ENDOSSOS_VAL_RCAP = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_VAL_RCAP.ToString(),
                ENDOSSOS_BCO_RCAP = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_BCO_RCAP.ToString(),
                ENDOSSOS_AGE_RCAP = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_AGE_RCAP.ToString(),
                ENDOSSOS_DAC_RCAP = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DAC_RCAP.ToString(),
                ENDOSSOS_TIPO_RCAP = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_TIPO_RCAP.ToString(),
                ENDOSSOS_BCO_COBRANCA = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_BCO_COBRANCA.ToString(),
                ENDOSSOS_AGE_COBRANCA = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_AGE_COBRANCA.ToString(),
                ENDOSSOS_DAC_COBRANCA = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DAC_COBRANCA.ToString(),
                ENDOSSOS_DATA_INIVIGENCIA = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA.ToString(),
                ENDOSSOS_DATA_TERVIGENCIA = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_TERVIGENCIA.ToString(),
                ENDOSSOS_PLANO_SEGURO = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_PLANO_SEGURO.ToString(),
                ENDOSSOS_PCT_ENTRADA = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_PCT_ENTRADA.ToString(),
                ENDOSSOS_PCT_ADIC_FRACIO = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_PCT_ADIC_FRACIO.ToString(),
                ENDOSSOS_QTD_DIAS_PRIMEIRA = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_QTD_DIAS_PRIMEIRA.ToString(),
                ENDOSSOS_QTD_PARCELAS = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_QTD_PARCELAS.ToString(),
                ENDOSSOS_QTD_PRESTACOES = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_QTD_PRESTACOES.ToString(),
                ENDOSSOS_QTD_ITENS = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_QTD_ITENS.ToString(),
                ENDOSSOS_COD_TEXTO_PADRAO = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_TEXTO_PADRAO.ToString(),
                ENDOSSOS_COD_ACEITACAO = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_ACEITACAO.ToString(),
                ENDOSSOS_COD_MOEDA_IMP = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_MOEDA_IMP.ToString(),
                ENDOSSOS_COD_MOEDA_PRM = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_MOEDA_PRM.ToString(),
                ENDOSSOS_TIPO_ENDOSSO = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_TIPO_ENDOSSO.ToString(),
                ENDOSSOS_COD_USUARIO = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_USUARIO.ToString(),
                ENDOSSOS_OCORR_ENDERECO = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_OCORR_ENDERECO.ToString(),
                ENDOSSOS_SIT_REGISTRO = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_SIT_REGISTRO.ToString(),
                ENDOSSOS_DATA_RCAP = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_RCAP.ToString(),
                VIND_DATARCAP = VIND_DATARCAP.ToString(),
                ENDOSSOS_COD_EMPRESA = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_EMPRESA.ToString(),
                VIND_CODEMP = VIND_CODEMP.ToString(),
                ENDOSSOS_TIPO_CORRECAO = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_TIPO_CORRECAO.ToString(),
                VIND_CORRECAO = VIND_CORRECAO.ToString(),
                ENDOSSOS_ISENTA_CUSTO = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_ISENTA_CUSTO.ToString(),
                VIND_ISENTA = VIND_ISENTA.ToString(),
                ENDOSSOS_DATA_VENCIMENTO = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_VENCIMENTO.ToString(),
                VIND_DTVENCTO = VIND_DTVENCTO.ToString(),
                ENDOSSOS_COEF_PREFIX = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COEF_PREFIX.ToString(),
                VIND_PREFIX = VIND_PREFIX.ToString(),
                ENDOSSOS_VAL_CUSTO_EMISSAO = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_VAL_CUSTO_EMISSAO.ToString(),
                VIND_CUSEMIS = VIND_CUSEMIS.ToString(),
            };

            R3520_00_INSERT_ENDOSSOS_DB_INSERT_1_Insert1.Execute(r3520_00_INSERT_ENDOSSOS_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3520_99_SAIDA*/

        [StopWatch]
        /*" R3530-00-INSERT-PARCELAS-SECTION */
        private void R3530_00_INSERT_PARCELAS_SECTION()
        {
            /*" -3423- MOVE '3530' TO WNR-EXEC-SQL. */
            _.Move("3530", AUX_RELATORIO.WABEND.WNR_EXEC_SQL);

            /*" -3464- PERFORM R3530_00_INSERT_PARCELAS_DB_INSERT_1 */

            R3530_00_INSERT_PARCELAS_DB_INSERT_1();

            /*" -3467- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3468- DISPLAY 'R3530-00 - PROBLEMAS NO INSERT(PARCELAS)   ' */
                _.Display($"R3530-00 - PROBLEMAS NO INSERT(PARCELAS)   ");

                /*" -3469- DISPLAY 'SIT-REGISTRO    = ' MOVIMCOB-SIT-REGISTRO */
                _.Display($"SIT-REGISTRO    = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_SIT_REGISTRO}");

                /*" -3470- DISPLAY 'COD-BANCO       = ' MOVIMCOB-COD-BANCO */
                _.Display($"COD-BANCO       = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_BANCO}");

                /*" -3471- DISPLAY 'COD-AGENCIA     = ' MOVIMCOB-COD-AGENCIA */
                _.Display($"COD-AGENCIA     = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_AGENCIA}");

                /*" -3472- DISPLAY 'NUM-AVISO       = ' MOVIMCOB-NUM-AVISO */
                _.Display($"NUM-AVISO       = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_AVISO}");

                /*" -3473- DISPLAY 'NUM-NOSSO-TITULO= ' MOVIMCOB-NUM-NOSSO-TITULO */
                _.Display($"NUM-NOSSO-TITULO= {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_NOSSO_TITULO}");

                /*" -3474- DISPLAY 'COD-MOVIMENTO   = ' MOVIMCOB-COD-MOVIMENTO */
                _.Display($"COD-MOVIMENTO   = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_MOVIMENTO}");

                /*" -3475- DISPLAY 'NOME-SEGURADO   = ' MOVIMCOB-NOME-SEGURADO */
                _.Display($"NOME-SEGURADO   = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NOME_SEGURADO}");

                /*" -3476- DISPLAY 'NUM-APOLICE     = ' PARCELAS-NUM-APOLICE */
                _.Display($"NUM-APOLICE     = {PARCELAS.DCLPARCELAS.PARCELAS_NUM_APOLICE}");

                /*" -3477- DISPLAY 'NUM-ENDOSSO     = ' PARCELAS-NUM-ENDOSSO */
                _.Display($"NUM-ENDOSSO     = {PARCELAS.DCLPARCELAS.PARCELAS_NUM_ENDOSSO}");

                /*" -3477- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R3530-00-INSERT-PARCELAS-DB-INSERT-1 */
        public void R3530_00_INSERT_PARCELAS_DB_INSERT_1()
        {
            /*" -3464- EXEC SQL INSERT INTO SEGUROS.PARCELAS (NUM_APOLICE , NUM_ENDOSSO , NUM_PARCELA , DAC_PARCELA , COD_FONTE , NUM_TITULO , PRM_TARIFARIO_IX , VAL_DESCONTO_IX , PRM_LIQUIDO_IX , ADICIONAL_FRAC_IX , VAL_CUSTO_EMIS_IX , VAL_IOCC_IX , PRM_TOTAL_IX , OCORR_HISTORICO , QTD_DOCUMENTOS , SIT_REGISTRO , COD_EMPRESA , TIMESTAMP , SITUACAO_COBRANCA) VALUES (:PARCELAS-NUM-APOLICE , :PARCELAS-NUM-ENDOSSO , :PARCELAS-NUM-PARCELA , :PARCELAS-DAC-PARCELA , :PARCELAS-COD-FONTE , :PARCELAS-NUM-TITULO , :PARCELAS-PRM-TARIFARIO-IX , :PARCELAS-VAL-DESCONTO-IX , :PARCELAS-PRM-LIQUIDO-IX , :PARCELAS-ADICIONAL-FRAC-IX , :PARCELAS-VAL-CUSTO-EMIS-IX , :PARCELAS-VAL-IOCC-IX , :PARCELAS-PRM-TOTAL-IX , :PARCELAS-OCORR-HISTORICO , :PARCELAS-QTD-DOCUMENTOS , :PARCELAS-SIT-REGISTRO , :PARCELAS-COD-EMPRESA:VIND-CODEMP , CURRENT TIMESTAMP , :PARCELAS-SITUACAO-COBRANCA:VIND-SIT-COBRANCA) END-EXEC. */

            var r3530_00_INSERT_PARCELAS_DB_INSERT_1_Insert1 = new R3530_00_INSERT_PARCELAS_DB_INSERT_1_Insert1()
            {
                PARCELAS_NUM_APOLICE = PARCELAS.DCLPARCELAS.PARCELAS_NUM_APOLICE.ToString(),
                PARCELAS_NUM_ENDOSSO = PARCELAS.DCLPARCELAS.PARCELAS_NUM_ENDOSSO.ToString(),
                PARCELAS_NUM_PARCELA = PARCELAS.DCLPARCELAS.PARCELAS_NUM_PARCELA.ToString(),
                PARCELAS_DAC_PARCELA = PARCELAS.DCLPARCELAS.PARCELAS_DAC_PARCELA.ToString(),
                PARCELAS_COD_FONTE = PARCELAS.DCLPARCELAS.PARCELAS_COD_FONTE.ToString(),
                PARCELAS_NUM_TITULO = PARCELAS.DCLPARCELAS.PARCELAS_NUM_TITULO.ToString(),
                PARCELAS_PRM_TARIFARIO_IX = PARCELAS.DCLPARCELAS.PARCELAS_PRM_TARIFARIO_IX.ToString(),
                PARCELAS_VAL_DESCONTO_IX = PARCELAS.DCLPARCELAS.PARCELAS_VAL_DESCONTO_IX.ToString(),
                PARCELAS_PRM_LIQUIDO_IX = PARCELAS.DCLPARCELAS.PARCELAS_PRM_LIQUIDO_IX.ToString(),
                PARCELAS_ADICIONAL_FRAC_IX = PARCELAS.DCLPARCELAS.PARCELAS_ADICIONAL_FRAC_IX.ToString(),
                PARCELAS_VAL_CUSTO_EMIS_IX = PARCELAS.DCLPARCELAS.PARCELAS_VAL_CUSTO_EMIS_IX.ToString(),
                PARCELAS_VAL_IOCC_IX = PARCELAS.DCLPARCELAS.PARCELAS_VAL_IOCC_IX.ToString(),
                PARCELAS_PRM_TOTAL_IX = PARCELAS.DCLPARCELAS.PARCELAS_PRM_TOTAL_IX.ToString(),
                PARCELAS_OCORR_HISTORICO = PARCELAS.DCLPARCELAS.PARCELAS_OCORR_HISTORICO.ToString(),
                PARCELAS_QTD_DOCUMENTOS = PARCELAS.DCLPARCELAS.PARCELAS_QTD_DOCUMENTOS.ToString(),
                PARCELAS_SIT_REGISTRO = PARCELAS.DCLPARCELAS.PARCELAS_SIT_REGISTRO.ToString(),
                PARCELAS_COD_EMPRESA = PARCELAS.DCLPARCELAS.PARCELAS_COD_EMPRESA.ToString(),
                VIND_CODEMP = VIND_CODEMP.ToString(),
                PARCELAS_SITUACAO_COBRANCA = PARCELAS.DCLPARCELAS.PARCELAS_SITUACAO_COBRANCA.ToString(),
                VIND_SIT_COBRANCA = VIND_SIT_COBRANCA.ToString(),
            };

            R3530_00_INSERT_PARCELAS_DB_INSERT_1_Insert1.Execute(r3530_00_INSERT_PARCELAS_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3530_99_SAIDA*/

        [StopWatch]
        /*" R3550-00-INSERT-PARCEHIS-SECTION */
        private void R3550_00_INSERT_PARCEHIS_SECTION()
        {
            /*" -3490- MOVE '3550' TO WNR-EXEC-SQL. */
            _.Move("3550", AUX_RELATORIO.WABEND.WNR_EXEC_SQL);

            /*" -3547- PERFORM R3550_00_INSERT_PARCEHIS_DB_INSERT_1 */

            R3550_00_INSERT_PARCEHIS_DB_INSERT_1();

            /*" -3550- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3551- DISPLAY 'R3550-00 - PROBLEMAS NO INSERT(PARCEHIS)   ' */
                _.Display($"R3550-00 - PROBLEMAS NO INSERT(PARCEHIS)   ");

                /*" -3552- DISPLAY 'SIT-REGISTRO    = ' MOVIMCOB-SIT-REGISTRO */
                _.Display($"SIT-REGISTRO    = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_SIT_REGISTRO}");

                /*" -3553- DISPLAY 'COD-BANCO       = ' MOVIMCOB-COD-BANCO */
                _.Display($"COD-BANCO       = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_BANCO}");

                /*" -3554- DISPLAY 'COD-AGENCIA     = ' MOVIMCOB-COD-AGENCIA */
                _.Display($"COD-AGENCIA     = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_AGENCIA}");

                /*" -3555- DISPLAY 'NUM-AVISO       = ' MOVIMCOB-NUM-AVISO */
                _.Display($"NUM-AVISO       = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_AVISO}");

                /*" -3556- DISPLAY 'NUM-NOSSO-TITULO= ' MOVIMCOB-NUM-NOSSO-TITULO */
                _.Display($"NUM-NOSSO-TITULO= {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_NOSSO_TITULO}");

                /*" -3557- DISPLAY 'COD-MOVIMENTO   = ' MOVIMCOB-COD-MOVIMENTO */
                _.Display($"COD-MOVIMENTO   = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_MOVIMENTO}");

                /*" -3558- DISPLAY 'NOME-SEGURADO   = ' MOVIMCOB-NOME-SEGURADO */
                _.Display($"NOME-SEGURADO   = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NOME_SEGURADO}");

                /*" -3559- DISPLAY 'NUM-APOLICE     = ' PARCEHIS-NUM-APOLICE */
                _.Display($"NUM-APOLICE     = {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE}");

                /*" -3560- DISPLAY 'NUM-ENDOSSO     = ' PARCEHIS-NUM-ENDOSSO */
                _.Display($"NUM-ENDOSSO     = {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO}");

                /*" -3560- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R3550-00-INSERT-PARCEHIS-DB-INSERT-1 */
        public void R3550_00_INSERT_PARCEHIS_DB_INSERT_1()
        {
            /*" -3547- EXEC SQL INSERT INTO SEGUROS.PARCELA_HISTORICO (NUM_APOLICE , NUM_ENDOSSO , NUM_PARCELA , DAC_PARCELA , DATA_MOVIMENTO , COD_OPERACAO , HORA_OPERACAO , OCORR_HISTORICO , PRM_TARIFARIO , VAL_DESCONTO , PRM_LIQUIDO , ADICIONAL_FRACIO , VAL_CUSTO_EMISSAO , VAL_IOCC , PRM_TOTAL , VAL_OPERACAO , DATA_VENCIMENTO , BCO_COBRANCA , AGE_COBRANCA , NUM_AVISO_CREDITO , ENDOS_CANCELA , SIT_CONTABIL , COD_USUARIO , RENUM_DOCUMENTO , DATA_QUITACAO , COD_EMPRESA , TIMESTAMP) VALUES (:PARCEHIS-NUM-APOLICE , :PARCEHIS-NUM-ENDOSSO , :PARCEHIS-NUM-PARCELA , :PARCEHIS-DAC-PARCELA , :PARCEHIS-DATA-MOVIMENTO , :PARCEHIS-COD-OPERACAO , CURRENT TIME , :PARCEHIS-OCORR-HISTORICO , :PARCEHIS-PRM-TARIFARIO , :PARCEHIS-VAL-DESCONTO , :PARCEHIS-PRM-LIQUIDO , :PARCEHIS-ADICIONAL-FRACIO , :PARCEHIS-VAL-CUSTO-EMISSAO , :PARCEHIS-VAL-IOCC , :PARCEHIS-PRM-TOTAL , :PARCEHIS-VAL-OPERACAO , :PARCEHIS-DATA-VENCIMENTO , :PARCEHIS-BCO-COBRANCA , :PARCEHIS-AGE-COBRANCA , :PARCEHIS-NUM-AVISO-CREDITO , :PARCEHIS-ENDOS-CANCELA , :PARCEHIS-SIT-CONTABIL , :PARCEHIS-COD-USUARIO , :PARCEHIS-RENUM-DOCUMENTO , :PARCEHIS-DATA-QUITACAO:VIND-DTQITBCO, :PARCEHIS-COD-EMPRESA:VIND-CODEMP , CURRENT TIMESTAMP) END-EXEC. */

            var r3550_00_INSERT_PARCEHIS_DB_INSERT_1_Insert1 = new R3550_00_INSERT_PARCEHIS_DB_INSERT_1_Insert1()
            {
                PARCEHIS_NUM_APOLICE = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE.ToString(),
                PARCEHIS_NUM_ENDOSSO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO.ToString(),
                PARCEHIS_NUM_PARCELA = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_PARCELA.ToString(),
                PARCEHIS_DAC_PARCELA = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DAC_PARCELA.ToString(),
                PARCEHIS_DATA_MOVIMENTO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_MOVIMENTO.ToString(),
                PARCEHIS_COD_OPERACAO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_COD_OPERACAO.ToString(),
                PARCEHIS_OCORR_HISTORICO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_OCORR_HISTORICO.ToString(),
                PARCEHIS_PRM_TARIFARIO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_PRM_TARIFARIO.ToString(),
                PARCEHIS_VAL_DESCONTO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_VAL_DESCONTO.ToString(),
                PARCEHIS_PRM_LIQUIDO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_PRM_LIQUIDO.ToString(),
                PARCEHIS_ADICIONAL_FRACIO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_ADICIONAL_FRACIO.ToString(),
                PARCEHIS_VAL_CUSTO_EMISSAO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_VAL_CUSTO_EMISSAO.ToString(),
                PARCEHIS_VAL_IOCC = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_VAL_IOCC.ToString(),
                PARCEHIS_PRM_TOTAL = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_PRM_TOTAL.ToString(),
                PARCEHIS_VAL_OPERACAO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_VAL_OPERACAO.ToString(),
                PARCEHIS_DATA_VENCIMENTO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_VENCIMENTO.ToString(),
                PARCEHIS_BCO_COBRANCA = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_BCO_COBRANCA.ToString(),
                PARCEHIS_AGE_COBRANCA = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_AGE_COBRANCA.ToString(),
                PARCEHIS_NUM_AVISO_CREDITO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_AVISO_CREDITO.ToString(),
                PARCEHIS_ENDOS_CANCELA = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_ENDOS_CANCELA.ToString(),
                PARCEHIS_SIT_CONTABIL = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_SIT_CONTABIL.ToString(),
                PARCEHIS_COD_USUARIO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_COD_USUARIO.ToString(),
                PARCEHIS_RENUM_DOCUMENTO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_RENUM_DOCUMENTO.ToString(),
                PARCEHIS_DATA_QUITACAO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_QUITACAO.ToString(),
                VIND_DTQITBCO = VIND_DTQITBCO.ToString(),
                PARCEHIS_COD_EMPRESA = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_COD_EMPRESA.ToString(),
                VIND_CODEMP = VIND_CODEMP.ToString(),
            };

            R3550_00_INSERT_PARCEHIS_DB_INSERT_1_Insert1.Execute(r3550_00_INSERT_PARCEHIS_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3550_99_SAIDA*/

        [StopWatch]
        /*" R3600-00-INSERT-APOLICOB-SECTION */
        private void R3600_00_INSERT_APOLICOB_SECTION()
        {
            /*" -3573- MOVE '3600' TO WNR-EXEC-SQL. */
            _.Move("3600", AUX_RELATORIO.WABEND.WNR_EXEC_SQL);

            /*" -3612- PERFORM R3600_00_INSERT_APOLICOB_DB_INSERT_1 */

            R3600_00_INSERT_APOLICOB_DB_INSERT_1();

            /*" -3615- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3616- DISPLAY 'R3600-00 - PROBLEMAS NO INSERT(APOLICOB)   ' */
                _.Display($"R3600-00 - PROBLEMAS NO INSERT(APOLICOB)   ");

                /*" -3617- DISPLAY 'SIT-REGISTRO    = ' MOVIMCOB-SIT-REGISTRO */
                _.Display($"SIT-REGISTRO    = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_SIT_REGISTRO}");

                /*" -3618- DISPLAY 'COD-BANCO       = ' MOVIMCOB-COD-BANCO */
                _.Display($"COD-BANCO       = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_BANCO}");

                /*" -3619- DISPLAY 'COD-AGENCIA     = ' MOVIMCOB-COD-AGENCIA */
                _.Display($"COD-AGENCIA     = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_AGENCIA}");

                /*" -3620- DISPLAY 'NUM-AVISO       = ' MOVIMCOB-NUM-AVISO */
                _.Display($"NUM-AVISO       = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_AVISO}");

                /*" -3621- DISPLAY 'NUM-NOSSO-TITULO= ' MOVIMCOB-NUM-NOSSO-TITULO */
                _.Display($"NUM-NOSSO-TITULO= {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_NOSSO_TITULO}");

                /*" -3622- DISPLAY 'COD-MOVIMENTO   = ' MOVIMCOB-COD-MOVIMENTO */
                _.Display($"COD-MOVIMENTO   = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_MOVIMENTO}");

                /*" -3623- DISPLAY 'NOME-SEGURADO   = ' MOVIMCOB-NOME-SEGURADO */
                _.Display($"NOME-SEGURADO   = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NOME_SEGURADO}");

                /*" -3624- DISPLAY 'NUM-APOLICE     = ' APOLICOB-NUM-APOLICE */
                _.Display($"NUM-APOLICE     = {APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_NUM_APOLICE}");

                /*" -3625- DISPLAY 'NUM-ENDOSSO     = ' APOLICOB-NUM-ENDOSSO */
                _.Display($"NUM-ENDOSSO     = {APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_NUM_ENDOSSO}");

                /*" -3625- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R3600-00-INSERT-APOLICOB-DB-INSERT-1 */
        public void R3600_00_INSERT_APOLICOB_DB_INSERT_1()
        {
            /*" -3612- EXEC SQL INSERT INTO SEGUROS.APOLICE_COBERTURAS (NUM_APOLICE , NUM_ENDOSSO , NUM_ITEM , OCORR_HISTORICO , RAMO_COBERTURA , MODALI_COBERTURA , COD_COBERTURA , IMP_SEGURADA_IX , PRM_TARIFARIO_IX , IMP_SEGURADA_VAR , PRM_TARIFARIO_VAR , PCT_COBERTURA , FATOR_MULTIPLICA , DATA_INIVIGENCIA , DATA_TERVIGENCIA , COD_EMPRESA , TIMESTAMP , SIT_REGISTRO) VALUES (:APOLICOB-NUM-APOLICE , :APOLICOB-NUM-ENDOSSO , :APOLICOB-NUM-ITEM , :APOLICOB-OCORR-HISTORICO , :APOLICOB-RAMO-COBERTURA , :APOLICOB-MODALI-COBERTURA , :APOLICOB-COD-COBERTURA , :APOLICOB-IMP-SEGURADA-IX , :APOLICOB-PRM-TARIFARIO-IX , :APOLICOB-IMP-SEGURADA-VAR , :APOLICOB-PRM-TARIFARIO-VAR , :APOLICOB-PCT-COBERTURA , :APOLICOB-FATOR-MULTIPLICA , :APOLICOB-DATA-INIVIGENCIA , :APOLICOB-DATA-TERVIGENCIA , :APOLICOB-COD-EMPRESA:VIND-CODEMP, CURRENT TIMESTAMP , :APOLICOB-SIT-REGISTRO:VIND-SITUACAO) END-EXEC. */

            var r3600_00_INSERT_APOLICOB_DB_INSERT_1_Insert1 = new R3600_00_INSERT_APOLICOB_DB_INSERT_1_Insert1()
            {
                APOLICOB_NUM_APOLICE = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_NUM_APOLICE.ToString(),
                APOLICOB_NUM_ENDOSSO = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_NUM_ENDOSSO.ToString(),
                APOLICOB_NUM_ITEM = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_NUM_ITEM.ToString(),
                APOLICOB_OCORR_HISTORICO = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_OCORR_HISTORICO.ToString(),
                APOLICOB_RAMO_COBERTURA = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_RAMO_COBERTURA.ToString(),
                APOLICOB_MODALI_COBERTURA = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_MODALI_COBERTURA.ToString(),
                APOLICOB_COD_COBERTURA = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_COD_COBERTURA.ToString(),
                APOLICOB_IMP_SEGURADA_IX = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_IMP_SEGURADA_IX.ToString(),
                APOLICOB_PRM_TARIFARIO_IX = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_PRM_TARIFARIO_IX.ToString(),
                APOLICOB_IMP_SEGURADA_VAR = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_IMP_SEGURADA_VAR.ToString(),
                APOLICOB_PRM_TARIFARIO_VAR = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_PRM_TARIFARIO_VAR.ToString(),
                APOLICOB_PCT_COBERTURA = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_PCT_COBERTURA.ToString(),
                APOLICOB_FATOR_MULTIPLICA = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_FATOR_MULTIPLICA.ToString(),
                APOLICOB_DATA_INIVIGENCIA = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_DATA_INIVIGENCIA.ToString(),
                APOLICOB_DATA_TERVIGENCIA = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_DATA_TERVIGENCIA.ToString(),
                APOLICOB_COD_EMPRESA = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_COD_EMPRESA.ToString(),
                VIND_CODEMP = VIND_CODEMP.ToString(),
                APOLICOB_SIT_REGISTRO = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_SIT_REGISTRO.ToString(),
                VIND_SITUACAO = VIND_SITUACAO.ToString(),
            };

            R3600_00_INSERT_APOLICOB_DB_INSERT_1_Insert1.Execute(r3600_00_INSERT_APOLICOB_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3600_99_SAIDA*/

        [StopWatch]
        /*" R4000-00-MONTA-ENDOSSOS01-SECTION */
        private void R4000_00_MONTA_ENDOSSOS01_SECTION()
        {
            /*" -3641- MOVE '4000' TO WNR-EXEC-SQL. */
            _.Move("4000", AUX_RELATORIO.WABEND.WNR_EXEC_SQL);

            /*" -3647- PERFORM R3250-00-SELECT-FONTES. */

            R3250_00_SELECT_FONTES_SECTION();

            /*" -3649- MOVE APOLICES-NUM-APOLICE TO ENDOSSOS-NUM-APOLICE. */
            _.Move(APOLICES.DCLAPOLICES.APOLICES_NUM_APOLICE, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE);

            /*" -3651- MOVE 01 TO ENDOSSOS-NUM-ENDOSSO. */
            _.Move(01, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO);

            /*" -3653- MOVE APOLICES-RAMO-EMISSOR TO ENDOSSOS-RAMO-EMISSOR. */
            _.Move(APOLICES.DCLAPOLICES.APOLICES_RAMO_EMISSOR, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_RAMO_EMISSOR);

            /*" -3655- MOVE APOLICES-COD-PRODUTO TO ENDOSSOS-COD-PRODUTO. */
            _.Move(APOLICES.DCLAPOLICES.APOLICES_COD_PRODUTO, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_PRODUTO);

            /*" -3657- MOVE ZEROS TO ENDOSSOS-COD-SUBGRUPO. */
            _.Move(0, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_SUBGRUPO);

            /*" -3659- MOVE BILHETE-FONTE TO ENDOSSOS-COD-FONTE. */
            _.Move(BILHETE.DCLBILHETE.BILHETE_FONTE, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_FONTE);

            /*" -3661- MOVE FONTES-ULT-PROP-AUTOMAT TO ENDOSSOS-NUM-PROPOSTA. */
            _.Move(FONTES.DCLFONTES.FONTES_ULT_PROP_AUTOMAT, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_PROPOSTA);

            /*" -3663- MOVE BILHETE-DATA-VENDA TO ENDOSSOS-DATA-PROPOSTA. */
            _.Move(BILHETE.DCLBILHETE.BILHETE_DATA_VENDA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_PROPOSTA);

            /*" -3665- MOVE SISTEMAS-DATA-MOV-ABERTO TO ENDOSSOS-DATA-LIBERACAO. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_LIBERACAO);

            /*" -3667- MOVE SISTEMAS-DATA-MOV-ABERTO TO ENDOSSOS-DATA-EMISSAO. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_EMISSAO);

            /*" -3669- MOVE ZEROS TO ENDOSSOS-NUM-RCAP. */
            _.Move(0, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_RCAP);

            /*" -3671- MOVE ZEROS TO ENDOSSOS-VAL-RCAP. */
            _.Move(0, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_VAL_RCAP);

            /*" -3673- MOVE ZEROS TO ENDOSSOS-BCO-RCAP. */
            _.Move(0, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_BCO_RCAP);

            /*" -3675- MOVE ZEROS TO ENDOSSOS-AGE-RCAP. */
            _.Move(0, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_AGE_RCAP);

            /*" -3677- MOVE '0' TO ENDOSSOS-DAC-RCAP. */
            _.Move("0", ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DAC_RCAP);

            /*" -3679- MOVE '0' TO ENDOSSOS-TIPO-RCAP. */
            _.Move("0", ENDOSSOS.DCLENDOSSOS.ENDOSSOS_TIPO_RCAP);

            /*" -3681- MOVE 104 TO ENDOSSOS-BCO-COBRANCA. */
            _.Move(104, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_BCO_COBRANCA);

            /*" -3683- MOVE ZEROS TO ENDOSSOS-AGE-COBRANCA. */
            _.Move(0, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_AGE_COBRANCA);

            /*" -3685- MOVE '0' TO ENDOSSOS-DAC-COBRANCA. */
            _.Move("0", ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DAC_COBRANCA);

            /*" -3687- MOVE ZEROS TO ENDOSSOS-PLANO-SEGURO. */
            _.Move(0, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_PLANO_SEGURO);

            /*" -3689- MOVE ZEROS TO ENDOSSOS-PCT-ENTRADA. */
            _.Move(0, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_PCT_ENTRADA);

            /*" -3691- MOVE ZEROS TO ENDOSSOS-PCT-ADIC-FRACIO. */
            _.Move(0, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_PCT_ADIC_FRACIO);

            /*" -3693- MOVE ZEROS TO ENDOSSOS-QTD-DIAS-PRIMEIRA. */
            _.Move(0, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_QTD_DIAS_PRIMEIRA);

            /*" -3695- MOVE ZEROS TO ENDOSSOS-QTD-PARCELAS. */
            _.Move(0, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_QTD_PARCELAS);

            /*" -3697- MOVE ZEROS TO ENDOSSOS-QTD-PRESTACOES. */
            _.Move(0, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_QTD_PRESTACOES);

            /*" -3699- MOVE 1 TO ENDOSSOS-QTD-ITENS. */
            _.Move(1, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_QTD_ITENS);

            /*" -3701- MOVE SPACES TO ENDOSSOS-COD-TEXTO-PADRAO. */
            _.Move("", ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_TEXTO_PADRAO);

            /*" -3703- MOVE '0' TO ENDOSSOS-COD-ACEITACAO. */
            _.Move("0", ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_ACEITACAO);

            /*" -3705- MOVE BILHECOB-COD-MOEDA TO ENDOSSOS-COD-MOEDA-IMP. */
            _.Move(BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_COD_MOEDA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_MOEDA_IMP);

            /*" -3707- MOVE BILHECOB-COD-MOEDA TO ENDOSSOS-COD-MOEDA-PRM. */
            _.Move(BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_COD_MOEDA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_MOEDA_PRM);

            /*" -3709- MOVE '1' TO ENDOSSOS-TIPO-ENDOSSO. */
            _.Move("1", ENDOSSOS.DCLENDOSSOS.ENDOSSOS_TIPO_ENDOSSO);

            /*" -3711- MOVE 'BI6252B' TO ENDOSSOS-COD-USUARIO. */
            _.Move("BI6252B", ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_USUARIO);

            /*" -3713- MOVE BILHETE-OCORR-ENDERECO TO ENDOSSOS-OCORR-ENDERECO. */
            _.Move(BILHETE.DCLBILHETE.BILHETE_OCORR_ENDERECO, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_OCORR_ENDERECO);

            /*" -3715- MOVE '0' TO ENDOSSOS-SIT-REGISTRO. */
            _.Move("0", ENDOSSOS.DCLENDOSSOS.ENDOSSOS_SIT_REGISTRO);

            /*" -3717- MOVE SPACES TO ENDOSSOS-DATA-RCAP. */
            _.Move("", ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_RCAP);

            /*" -3719- MOVE -1 TO VIND-DATARCAP. */
            _.Move(-1, VIND_DATARCAP);

            /*" -3721- MOVE ZEROS TO ENDOSSOS-COD-EMPRESA. */
            _.Move(0, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_EMPRESA);

            /*" -3723- MOVE ZEROS TO VIND-CODEMP. */
            _.Move(0, VIND_CODEMP);

            /*" -3725- MOVE '1' TO ENDOSSOS-TIPO-CORRECAO. */
            _.Move("1", ENDOSSOS.DCLENDOSSOS.ENDOSSOS_TIPO_CORRECAO);

            /*" -3727- MOVE ZEROS TO VIND-CORRECAO. */
            _.Move(0, VIND_CORRECAO);

            /*" -3729- MOVE 'S' TO ENDOSSOS-ISENTA-CUSTO. */
            _.Move("S", ENDOSSOS.DCLENDOSSOS.ENDOSSOS_ISENTA_CUSTO);

            /*" -3731- MOVE ZEROS TO VIND-ISENTA. */
            _.Move(0, VIND_ISENTA);

            /*" -3733- MOVE SPACES TO ENDOSSOS-DATA-VENCIMENTO. */
            _.Move("", ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_VENCIMENTO);

            /*" -3735- MOVE -1 TO VIND-DTVENCTO. */
            _.Move(-1, VIND_DTVENCTO);

            /*" -3737- MOVE ZEROS TO ENDOSSOS-COEF-PREFIX. */
            _.Move(0, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COEF_PREFIX);

            /*" -3739- MOVE -1 TO VIND-PREFIX. */
            _.Move(-1, VIND_PREFIX);

            /*" -3741- MOVE ZEROS TO ENDOSSOS-VAL-CUSTO-EMISSAO. */
            _.Move(0, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_VAL_CUSTO_EMISSAO);

            /*" -3748- MOVE -1 TO VIND-CUSEMIS. */
            _.Move(-1, VIND_CUSEMIS);

            /*" -3754- PERFORM R4100-00-TRATA-FIM-VIGENCIA. */

            R4100_00_TRATA_FIM_VIGENCIA_SECTION();

            /*" -3760- PERFORM R3520-00-INSERT-ENDOSSOS. */

            R3520_00_INSERT_ENDOSSOS_SECTION();

            /*" -3762- MOVE ENDOSSOS-NUM-APOLICE TO PARCELAS-NUM-APOLICE. */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE, PARCELAS.DCLPARCELAS.PARCELAS_NUM_APOLICE);

            /*" -3764- MOVE ENDOSSOS-NUM-ENDOSSO TO PARCELAS-NUM-ENDOSSO. */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO, PARCELAS.DCLPARCELAS.PARCELAS_NUM_ENDOSSO);

            /*" -3766- MOVE ZEROS TO PARCELAS-NUM-PARCELA. */
            _.Move(0, PARCELAS.DCLPARCELAS.PARCELAS_NUM_PARCELA);

            /*" -3768- MOVE '0' TO PARCELAS-DAC-PARCELA. */
            _.Move("0", PARCELAS.DCLPARCELAS.PARCELAS_DAC_PARCELA);

            /*" -3770- MOVE ENDOSSOS-COD-FONTE TO PARCELAS-COD-FONTE. */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_FONTE, PARCELAS.DCLPARCELAS.PARCELAS_COD_FONTE);

            /*" -3772- MOVE BILHETE-NUM-BILHETE TO PARCELAS-NUM-TITULO. */
            _.Move(BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE, PARCELAS.DCLPARCELAS.PARCELAS_NUM_TITULO);

            /*" -3774- MOVE ZEROS TO PARCELAS-PRM-TARIFARIO-IX. */
            _.Move(0, PARCELAS.DCLPARCELAS.PARCELAS_PRM_TARIFARIO_IX);

            /*" -3776- MOVE ZEROS TO PARCELAS-VAL-DESCONTO-IX. */
            _.Move(0, PARCELAS.DCLPARCELAS.PARCELAS_VAL_DESCONTO_IX);

            /*" -3778- MOVE ZEROS TO PARCELAS-PRM-LIQUIDO-IX. */
            _.Move(0, PARCELAS.DCLPARCELAS.PARCELAS_PRM_LIQUIDO_IX);

            /*" -3780- MOVE ZEROS TO PARCELAS-ADICIONAL-FRAC-IX. */
            _.Move(0, PARCELAS.DCLPARCELAS.PARCELAS_ADICIONAL_FRAC_IX);

            /*" -3782- MOVE ZEROS TO PARCELAS-VAL-CUSTO-EMIS-IX. */
            _.Move(0, PARCELAS.DCLPARCELAS.PARCELAS_VAL_CUSTO_EMIS_IX);

            /*" -3784- MOVE ZEROS TO PARCELAS-VAL-IOCC-IX. */
            _.Move(0, PARCELAS.DCLPARCELAS.PARCELAS_VAL_IOCC_IX);

            /*" -3786- MOVE ZEROS TO PARCELAS-VAL-CUSTO-EMIS-IX */
            _.Move(0, PARCELAS.DCLPARCELAS.PARCELAS_VAL_CUSTO_EMIS_IX);

            /*" -3788- MOVE ZEROS TO PARCELAS-PRM-TOTAL-IX. */
            _.Move(0, PARCELAS.DCLPARCELAS.PARCELAS_PRM_TOTAL_IX);

            /*" -3790- MOVE 1 TO PARCELAS-OCORR-HISTORICO. */
            _.Move(1, PARCELAS.DCLPARCELAS.PARCELAS_OCORR_HISTORICO);

            /*" -3792- MOVE ZEROS TO PARCELAS-QTD-DOCUMENTOS. */
            _.Move(0, PARCELAS.DCLPARCELAS.PARCELAS_QTD_DOCUMENTOS);

            /*" -3794- MOVE '0' TO PARCELAS-SIT-REGISTRO. */
            _.Move("0", PARCELAS.DCLPARCELAS.PARCELAS_SIT_REGISTRO);

            /*" -3796- MOVE ENDOSSOS-COD-EMPRESA TO PARCELAS-COD-EMPRESA. */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_EMPRESA, PARCELAS.DCLPARCELAS.PARCELAS_COD_EMPRESA);

            /*" -3798- MOVE ZEROS TO VIND-CODEMP. */
            _.Move(0, VIND_CODEMP);

            /*" -3800- MOVE SPACES TO PARCELAS-SITUACAO-COBRANCA. */
            _.Move("", PARCELAS.DCLPARCELAS.PARCELAS_SITUACAO_COBRANCA);

            /*" -3808- MOVE -1 TO VIND-SIT-COBRANCA. */
            _.Move(-1, VIND_SIT_COBRANCA);

            /*" -3809- MOVE ZEROS TO WSHOST-VAL-IOCC. */
            _.Move(0, WSHOST_VAL_IOCC);

            /*" -3812- COMPUTE WSHOST-VAL-IOCC EQUAL (BILHECOB-PRM-TOTAL * WSHOST-PCT-IOCC). */
            WSHOST_VAL_IOCC.Value = (BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_PRM_TOTAL * WSHOST_PCT_IOCC);

            /*" -3813- MOVE BILHECOB-PRM-TOTAL TO PARCELAS-PRM-TOTAL-IX. */
            _.Move(BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_PRM_TOTAL, PARCELAS.DCLPARCELAS.PARCELAS_PRM_TOTAL_IX);

            /*" -3814- MOVE WSHOST-VAL-IOCC TO PARCELAS-VAL-IOCC-IX. */
            _.Move(WSHOST_VAL_IOCC, PARCELAS.DCLPARCELAS.PARCELAS_VAL_IOCC_IX);

            /*" -3817- COMPUTE PARCELAS-PRM-TARIFARIO-IX EQUAL (PARCELAS-PRM-TOTAL-IX - PARCELAS-VAL-IOCC-IX). */
            PARCELAS.DCLPARCELAS.PARCELAS_PRM_TARIFARIO_IX.Value = (PARCELAS.DCLPARCELAS.PARCELAS_PRM_TOTAL_IX - PARCELAS.DCLPARCELAS.PARCELAS_VAL_IOCC_IX);

            /*" -3824- MOVE PARCELAS-PRM-TARIFARIO-IX TO PARCELAS-PRM-LIQUIDO-IX. */
            _.Move(PARCELAS.DCLPARCELAS.PARCELAS_PRM_TARIFARIO_IX, PARCELAS.DCLPARCELAS.PARCELAS_PRM_LIQUIDO_IX);

            /*" -3830- PERFORM R3530-00-INSERT-PARCELAS. */

            R3530_00_INSERT_PARCELAS_SECTION();

            /*" -3832- MOVE PARCELAS-NUM-APOLICE TO PARCEHIS-NUM-APOLICE. */
            _.Move(PARCELAS.DCLPARCELAS.PARCELAS_NUM_APOLICE, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE);

            /*" -3834- MOVE PARCELAS-NUM-ENDOSSO TO PARCEHIS-NUM-ENDOSSO. */
            _.Move(PARCELAS.DCLPARCELAS.PARCELAS_NUM_ENDOSSO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO);

            /*" -3836- MOVE PARCELAS-NUM-PARCELA TO PARCEHIS-NUM-PARCELA. */
            _.Move(PARCELAS.DCLPARCELAS.PARCELAS_NUM_PARCELA, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_PARCELA);

            /*" -3838- MOVE PARCELAS-DAC-PARCELA TO PARCEHIS-DAC-PARCELA. */
            _.Move(PARCELAS.DCLPARCELAS.PARCELAS_DAC_PARCELA, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DAC_PARCELA);

            /*" -3840- MOVE SISTEMAS-DATA-MOV-ABERTO TO PARCEHIS-DATA-MOVIMENTO. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_MOVIMENTO);

            /*" -3842- MOVE 101 TO PARCEHIS-COD-OPERACAO. */
            _.Move(101, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_COD_OPERACAO);

            /*" -3844- MOVE 1 TO PARCEHIS-OCORR-HISTORICO. */
            _.Move(1, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_OCORR_HISTORICO);

            /*" -3846- MOVE PARCELAS-PRM-TARIFARIO-IX TO PARCEHIS-PRM-TARIFARIO. */
            _.Move(PARCELAS.DCLPARCELAS.PARCELAS_PRM_TARIFARIO_IX, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_PRM_TARIFARIO);

            /*" -3848- MOVE PARCELAS-VAL-DESCONTO-IX TO PARCEHIS-VAL-DESCONTO. */
            _.Move(PARCELAS.DCLPARCELAS.PARCELAS_VAL_DESCONTO_IX, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_VAL_DESCONTO);

            /*" -3850- MOVE PARCELAS-PRM-LIQUIDO-IX TO PARCEHIS-PRM-LIQUIDO. */
            _.Move(PARCELAS.DCLPARCELAS.PARCELAS_PRM_LIQUIDO_IX, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_PRM_LIQUIDO);

            /*" -3852- MOVE PARCELAS-ADICIONAL-FRAC-IX TO PARCEHIS-ADICIONAL-FRACIO. */
            _.Move(PARCELAS.DCLPARCELAS.PARCELAS_ADICIONAL_FRAC_IX, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_ADICIONAL_FRACIO);

            /*" -3854- MOVE PARCELAS-VAL-CUSTO-EMIS-IX TO PARCEHIS-VAL-CUSTO-EMISSAO. */
            _.Move(PARCELAS.DCLPARCELAS.PARCELAS_VAL_CUSTO_EMIS_IX, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_VAL_CUSTO_EMISSAO);

            /*" -3856- MOVE PARCELAS-VAL-IOCC-IX TO PARCEHIS-VAL-IOCC. */
            _.Move(PARCELAS.DCLPARCELAS.PARCELAS_VAL_IOCC_IX, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_VAL_IOCC);

            /*" -3858- MOVE PARCELAS-PRM-TOTAL-IX TO PARCEHIS-PRM-TOTAL. */
            _.Move(PARCELAS.DCLPARCELAS.PARCELAS_PRM_TOTAL_IX, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_PRM_TOTAL);

            /*" -3860- MOVE ZEROS TO PARCEHIS-VAL-OPERACAO. */
            _.Move(0, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_VAL_OPERACAO);

            /*" -3862- MOVE ENDOSSOS-BCO-COBRANCA TO PARCEHIS-BCO-COBRANCA. */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_BCO_COBRANCA, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_BCO_COBRANCA);

            /*" -3864- MOVE ENDOSSOS-AGE-COBRANCA TO PARCEHIS-AGE-COBRANCA. */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_AGE_COBRANCA, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_AGE_COBRANCA);

            /*" -3866- MOVE ZEROS TO PARCEHIS-NUM-AVISO-CREDITO. */
            _.Move(0, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_AVISO_CREDITO);

            /*" -3868- MOVE ZEROS TO PARCEHIS-ENDOS-CANCELA. */
            _.Move(0, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_ENDOS_CANCELA);

            /*" -3870- MOVE '0' TO PARCEHIS-SIT-CONTABIL. */
            _.Move("0", PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_SIT_CONTABIL);

            /*" -3872- MOVE ENDOSSOS-COD-USUARIO TO PARCEHIS-COD-USUARIO. */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_USUARIO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_COD_USUARIO);

            /*" -3874- MOVE ZEROS TO PARCEHIS-RENUM-DOCUMENTO. */
            _.Move(0, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_RENUM_DOCUMENTO);

            /*" -3876- MOVE SPACES TO PARCEHIS-DATA-QUITACAO. */
            _.Move("", PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_QUITACAO);

            /*" -3878- MOVE -1 TO VIND-DTQITBCO. */
            _.Move(-1, VIND_DTQITBCO);

            /*" -3880- MOVE PARCELAS-COD-EMPRESA TO PARCEHIS-COD-EMPRESA. */
            _.Move(PARCELAS.DCLPARCELAS.PARCELAS_COD_EMPRESA, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_COD_EMPRESA);

            /*" -3882- MOVE ZEROS TO VIND-CODEMP. */
            _.Move(0, VIND_CODEMP);

            /*" -3889- MOVE WSGER01-DATA-VENCIMENTO TO PARCEHIS-DATA-VENCIMENTO. */
            _.Move(WSGER01_DATA_VENCIMENTO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_VENCIMENTO);

            /*" -3895- PERFORM R3550-00-INSERT-PARCEHIS. */

            R3550_00_INSERT_PARCEHIS_SECTION();

            /*" -3897- MOVE PARCELAS-NUM-APOLICE TO APOLICOB-NUM-APOLICE. */
            _.Move(PARCELAS.DCLPARCELAS.PARCELAS_NUM_APOLICE, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_NUM_APOLICE);

            /*" -3899- MOVE PARCELAS-NUM-ENDOSSO TO APOLICOB-NUM-ENDOSSO. */
            _.Move(PARCELAS.DCLPARCELAS.PARCELAS_NUM_ENDOSSO, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_NUM_ENDOSSO);

            /*" -3901- MOVE ZEROS TO APOLICOB-NUM-ITEM. */
            _.Move(0, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_NUM_ITEM);

            /*" -3903- MOVE ZEROS TO APOLICOB-OCORR-HISTORICO. */
            _.Move(0, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_OCORR_HISTORICO);

            /*" -3905- MOVE ENDOSSOS-RAMO-EMISSOR TO APOLICOB-RAMO-COBERTURA. */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_RAMO_EMISSOR, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_RAMO_COBERTURA);

            /*" -3907- MOVE APOLICES-COD-MODALIDADE TO APOLICOB-MODALI-COBERTURA. */
            _.Move(APOLICES.DCLAPOLICES.APOLICES_COD_MODALIDADE, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_MODALI_COBERTURA);

            /*" -3909- MOVE ZEROS TO APOLICOB-COD-COBERTURA. */
            _.Move(0, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_COD_COBERTURA);

            /*" -3911- MOVE BILHECOB-IMP-SEGURADA-IX TO APOLICOB-IMP-SEGURADA-IX. */
            _.Move(BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_IMP_SEGURADA_IX, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_IMP_SEGURADA_IX);

            /*" -3913- MOVE PARCELAS-PRM-TARIFARIO-IX TO APOLICOB-PRM-TARIFARIO-IX. */
            _.Move(PARCELAS.DCLPARCELAS.PARCELAS_PRM_TARIFARIO_IX, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_PRM_TARIFARIO_IX);

            /*" -3915- MOVE BILHECOB-IMP-SEGURADA-IX TO APOLICOB-IMP-SEGURADA-VAR. */
            _.Move(BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_IMP_SEGURADA_IX, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_IMP_SEGURADA_VAR);

            /*" -3917- MOVE PARCELAS-PRM-TARIFARIO-IX TO APOLICOB-PRM-TARIFARIO-VAR. */
            _.Move(PARCELAS.DCLPARCELAS.PARCELAS_PRM_TARIFARIO_IX, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_PRM_TARIFARIO_VAR);

            /*" -3919- MOVE 100 TO APOLICOB-PCT-COBERTURA. */
            _.Move(100, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_PCT_COBERTURA);

            /*" -3921- MOVE 1 TO APOLICOB-FATOR-MULTIPLICA. */
            _.Move(1, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_FATOR_MULTIPLICA);

            /*" -3923- MOVE ENDOSSOS-DATA-INIVIGENCIA TO APOLICOB-DATA-INIVIGENCIA. */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_DATA_INIVIGENCIA);

            /*" -3925- MOVE ENDOSSOS-DATA-TERVIGENCIA TO APOLICOB-DATA-TERVIGENCIA. */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_TERVIGENCIA, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_DATA_TERVIGENCIA);

            /*" -3927- MOVE ENDOSSOS-COD-EMPRESA TO APOLICOB-COD-EMPRESA. */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_EMPRESA, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_COD_EMPRESA);

            /*" -3928- MOVE ZEROS TO VIND-CODEMP. */
            _.Move(0, VIND_CODEMP);

            /*" -3930- MOVE '0' TO APOLICOB-SIT-REGISTRO. */
            _.Move("0", APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_SIT_REGISTRO);

            /*" -3936- MOVE ZEROS TO VIND-SITUACAO. */
            _.Move(0, VIND_SITUACAO);

            /*" -3936- PERFORM R3600-00-INSERT-APOLICOB. */

            R3600_00_INSERT_APOLICOB_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4000_99_SAIDA*/

        [StopWatch]
        /*" R4100-00-TRATA-FIM-VIGENCIA-SECTION */
        private void R4100_00_TRATA_FIM_VIGENCIA_SECTION()
        {
            /*" -3949- MOVE '4100' TO WNR-EXEC-SQL. */
            _.Move("4100", AUX_RELATORIO.WABEND.WNR_EXEC_SQL);

            /*" -3953- MOVE WSGER01-DATA-INIVIGENCIA TO ENDOSSOS-DATA-INIVIGENCIA. */
            _.Move(WSGER01_DATA_INIVIGENCIA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA);

            /*" -3955- IF WSHOST-DTMOVABE20 GREATER WSGER15-DATA-VENCIMENTO */

            if (WSHOST_DTMOVABE20 > WSGER15_DATA_VENCIMENTO)
            {

                /*" -3956- MOVE 16 TO WS-IND */
                _.Move(16, W.WS_IND);

                /*" -3958- MOVE WSGER15-DATA-TERVIGENCIA TO ENDOSSOS-DATA-TERVIGENCIA */
                _.Move(WSGER15_DATA_TERVIGENCIA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_TERVIGENCIA);

                /*" -3959- ELSE */
            }
            else
            {


                /*" -3961- IF WSHOST-DTMOVABE20 GREATER WSGER14-DATA-VENCIMENTO */

                if (WSHOST_DTMOVABE20 > WSGER14_DATA_VENCIMENTO)
                {

                    /*" -3962- MOVE 15 TO WS-IND */
                    _.Move(15, W.WS_IND);

                    /*" -3964- MOVE WSGER14-DATA-TERVIGENCIA TO ENDOSSOS-DATA-TERVIGENCIA */
                    _.Move(WSGER14_DATA_TERVIGENCIA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_TERVIGENCIA);

                    /*" -3966- ELSE */
                }
                else
                {


                    /*" -3968- IF WSHOST-DTMOVABE20 GREATER WSGER13-DATA-VENCIMENTO */

                    if (WSHOST_DTMOVABE20 > WSGER13_DATA_VENCIMENTO)
                    {

                        /*" -3969- MOVE 14 TO WS-IND */
                        _.Move(14, W.WS_IND);

                        /*" -3971- MOVE WSGER13-DATA-TERVIGENCIA TO ENDOSSOS-DATA-TERVIGENCIA */
                        _.Move(WSGER13_DATA_TERVIGENCIA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_TERVIGENCIA);

                        /*" -3972- ELSE */
                    }
                    else
                    {


                        /*" -3974- IF WSHOST-DTMOVABE20 GREATER WSGER12-DATA-VENCIMENTO */

                        if (WSHOST_DTMOVABE20 > WSGER12_DATA_VENCIMENTO)
                        {

                            /*" -3975- MOVE 13 TO WS-IND */
                            _.Move(13, W.WS_IND);

                            /*" -3977- MOVE WSGER12-DATA-TERVIGENCIA TO ENDOSSOS-DATA-TERVIGENCIA */
                            _.Move(WSGER12_DATA_TERVIGENCIA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_TERVIGENCIA);

                            /*" -3978- ELSE */
                        }
                        else
                        {


                            /*" -3980- IF WSHOST-DTMOVABE20 GREATER WSGER11-DATA-VENCIMENTO */

                            if (WSHOST_DTMOVABE20 > WSGER11_DATA_VENCIMENTO)
                            {

                                /*" -3981- MOVE 12 TO WS-IND */
                                _.Move(12, W.WS_IND);

                                /*" -3983- MOVE WSGER11-DATA-TERVIGENCIA TO ENDOSSOS-DATA-TERVIGENCIA */
                                _.Move(WSGER11_DATA_TERVIGENCIA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_TERVIGENCIA);

                                /*" -3984- ELSE */
                            }
                            else
                            {


                                /*" -3986- IF WSHOST-DTMOVABE20 GREATER WSGER10-DATA-VENCIMENTO */

                                if (WSHOST_DTMOVABE20 > WSGER10_DATA_VENCIMENTO)
                                {

                                    /*" -3987- MOVE 11 TO WS-IND */
                                    _.Move(11, W.WS_IND);

                                    /*" -3989- MOVE WSGER10-DATA-TERVIGENCIA TO ENDOSSOS-DATA-TERVIGENCIA */
                                    _.Move(WSGER10_DATA_TERVIGENCIA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_TERVIGENCIA);

                                    /*" -3990- ELSE */
                                }
                                else
                                {


                                    /*" -3992- IF WSHOST-DTMOVABE20 GREATER WSGER09-DATA-VENCIMENTO */

                                    if (WSHOST_DTMOVABE20 > WSGER09_DATA_VENCIMENTO)
                                    {

                                        /*" -3993- MOVE 10 TO WS-IND */
                                        _.Move(10, W.WS_IND);

                                        /*" -3995- MOVE WSGER09-DATA-TERVIGENCIA TO ENDOSSOS-DATA-TERVIGENCIA */
                                        _.Move(WSGER09_DATA_TERVIGENCIA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_TERVIGENCIA);

                                        /*" -3996- ELSE */
                                    }
                                    else
                                    {


                                        /*" -3998- IF WSHOST-DTMOVABE20 GREATER WSGER08-DATA-VENCIMENTO */

                                        if (WSHOST_DTMOVABE20 > WSGER08_DATA_VENCIMENTO)
                                        {

                                            /*" -3999- MOVE 09 TO WS-IND */
                                            _.Move(09, W.WS_IND);

                                            /*" -4001- MOVE WSGER08-DATA-TERVIGENCIA TO ENDOSSOS-DATA-TERVIGENCIA */
                                            _.Move(WSGER08_DATA_TERVIGENCIA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_TERVIGENCIA);

                                            /*" -4002- ELSE */
                                        }
                                        else
                                        {


                                            /*" -4004- IF WSHOST-DTMOVABE20 GREATER WSGER07-DATA-VENCIMENTO */

                                            if (WSHOST_DTMOVABE20 > WSGER07_DATA_VENCIMENTO)
                                            {

                                                /*" -4005- MOVE 08 TO WS-IND */
                                                _.Move(08, W.WS_IND);

                                                /*" -4007- MOVE WSGER07-DATA-TERVIGENCIA TO ENDOSSOS-DATA-TERVIGENCIA */
                                                _.Move(WSGER07_DATA_TERVIGENCIA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_TERVIGENCIA);

                                                /*" -4008- ELSE */
                                            }
                                            else
                                            {


                                                /*" -4010- IF WSHOST-DTMOVABE20 GREATER WSGER06-DATA-VENCIMENTO */

                                                if (WSHOST_DTMOVABE20 > WSGER06_DATA_VENCIMENTO)
                                                {

                                                    /*" -4011- MOVE 07 TO WS-IND */
                                                    _.Move(07, W.WS_IND);

                                                    /*" -4013- MOVE WSGER06-DATA-TERVIGENCIA TO ENDOSSOS-DATA-TERVIGENCIA */
                                                    _.Move(WSGER06_DATA_TERVIGENCIA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_TERVIGENCIA);

                                                    /*" -4014- ELSE */
                                                }
                                                else
                                                {


                                                    /*" -4016- IF WSHOST-DTMOVABE20 GREATER WSGER05-DATA-VENCIMENTO */

                                                    if (WSHOST_DTMOVABE20 > WSGER05_DATA_VENCIMENTO)
                                                    {

                                                        /*" -4017- MOVE 06 TO WS-IND */
                                                        _.Move(06, W.WS_IND);

                                                        /*" -4019- MOVE WSGER05-DATA-TERVIGENCIA TO ENDOSSOS-DATA-TERVIGENCIA */
                                                        _.Move(WSGER05_DATA_TERVIGENCIA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_TERVIGENCIA);

                                                        /*" -4020- ELSE */
                                                    }
                                                    else
                                                    {


                                                        /*" -4022- IF WSHOST-DTMOVABE20 GREATER WSGER04-DATA-VENCIMENTO */

                                                        if (WSHOST_DTMOVABE20 > WSGER04_DATA_VENCIMENTO)
                                                        {

                                                            /*" -4023- MOVE 05 TO WS-IND */
                                                            _.Move(05, W.WS_IND);

                                                            /*" -4025- MOVE WSGER04-DATA-TERVIGENCIA TO ENDOSSOS-DATA-TERVIGENCIA */
                                                            _.Move(WSGER04_DATA_TERVIGENCIA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_TERVIGENCIA);

                                                            /*" -4026- ELSE */
                                                        }
                                                        else
                                                        {


                                                            /*" -4028- IF WSHOST-DTMOVABE20 GREATER WSGER03-DATA-VENCIMENTO */

                                                            if (WSHOST_DTMOVABE20 > WSGER03_DATA_VENCIMENTO)
                                                            {

                                                                /*" -4029- MOVE 04 TO WS-IND */
                                                                _.Move(04, W.WS_IND);

                                                                /*" -4031- MOVE WSGER03-DATA-TERVIGENCIA TO ENDOSSOS-DATA-TERVIGENCIA */
                                                                _.Move(WSGER03_DATA_TERVIGENCIA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_TERVIGENCIA);

                                                                /*" -4032- ELSE */
                                                            }
                                                            else
                                                            {


                                                                /*" -4034- IF WSHOST-DTMOVABE20 GREATER WSGER02-DATA-VENCIMENTO */

                                                                if (WSHOST_DTMOVABE20 > WSGER02_DATA_VENCIMENTO)
                                                                {

                                                                    /*" -4035- MOVE 03 TO WS-IND */
                                                                    _.Move(03, W.WS_IND);

                                                                    /*" -4037- MOVE WSGER02-DATA-TERVIGENCIA TO ENDOSSOS-DATA-TERVIGENCIA */
                                                                    _.Move(WSGER02_DATA_TERVIGENCIA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_TERVIGENCIA);

                                                                    /*" -4038- ELSE */
                                                                }
                                                                else
                                                                {


                                                                    /*" -4039- MOVE 02 TO WS-IND */
                                                                    _.Move(02, W.WS_IND);

                                                                    /*" -4040- MOVE WSGER01-DATA-TERVIGENCIA TO ENDOSSOS-DATA-TERVIGENCIA. */
                                                                    _.Move(WSGER01_DATA_TERVIGENCIA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_TERVIGENCIA);
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
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4100_99_SAIDA*/

        [StopWatch]
        /*" R4900-00-VERIFICA-ENDOSSO-SECTION */
        private void R4900_00_VERIFICA_ENDOSSO_SECTION()
        {
            /*" -4053- MOVE '4900' TO WNR-EXEC-SQL. */
            _.Move("4900", AUX_RELATORIO.WABEND.WNR_EXEC_SQL);

            /*" -4054- IF WS-IND EQUAL 15 */

            if (W.WS_IND == 15)
            {

                /*" -4056- MOVE 15 TO ENDOSSOS-NUM-ENDOSSO */
                _.Move(15, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO);

                /*" -4058- MOVE WSGER15-DATA-INIVIGENCIA TO ENDOSSOS-DATA-INIVIGENCIA */
                _.Move(WSGER15_DATA_INIVIGENCIA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA);

                /*" -4060- MOVE WSGER15-DATA-TERVIGENCIA TO ENDOSSOS-DATA-TERVIGENCIA */
                _.Move(WSGER15_DATA_TERVIGENCIA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_TERVIGENCIA);

                /*" -4062- MOVE WSGER15-DATA-VENCIMENTO TO PARCEHIS-DATA-VENCIMENTO */
                _.Move(WSGER15_DATA_VENCIMENTO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_VENCIMENTO);

                /*" -4063- ELSE */
            }
            else
            {


                /*" -4064- IF WS-IND EQUAL 14 */

                if (W.WS_IND == 14)
                {

                    /*" -4066- MOVE 14 TO ENDOSSOS-NUM-ENDOSSO */
                    _.Move(14, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO);

                    /*" -4068- MOVE WSGER14-DATA-INIVIGENCIA TO ENDOSSOS-DATA-INIVIGENCIA */
                    _.Move(WSGER14_DATA_INIVIGENCIA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA);

                    /*" -4070- MOVE WSGER14-DATA-TERVIGENCIA TO ENDOSSOS-DATA-TERVIGENCIA */
                    _.Move(WSGER14_DATA_TERVIGENCIA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_TERVIGENCIA);

                    /*" -4072- MOVE WSGER14-DATA-VENCIMENTO TO PARCEHIS-DATA-VENCIMENTO */
                    _.Move(WSGER14_DATA_VENCIMENTO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_VENCIMENTO);

                    /*" -4073- ELSE */
                }
                else
                {


                    /*" -4074- IF WS-IND EQUAL 13 */

                    if (W.WS_IND == 13)
                    {

                        /*" -4076- MOVE 13 TO ENDOSSOS-NUM-ENDOSSO */
                        _.Move(13, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO);

                        /*" -4078- MOVE WSGER13-DATA-INIVIGENCIA TO ENDOSSOS-DATA-INIVIGENCIA */
                        _.Move(WSGER13_DATA_INIVIGENCIA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA);

                        /*" -4080- MOVE WSGER13-DATA-TERVIGENCIA TO ENDOSSOS-DATA-TERVIGENCIA */
                        _.Move(WSGER13_DATA_TERVIGENCIA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_TERVIGENCIA);

                        /*" -4082- MOVE WSGER13-DATA-VENCIMENTO TO PARCEHIS-DATA-VENCIMENTO */
                        _.Move(WSGER13_DATA_VENCIMENTO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_VENCIMENTO);

                        /*" -4083- ELSE */
                    }
                    else
                    {


                        /*" -4084- IF WS-IND EQUAL 12 */

                        if (W.WS_IND == 12)
                        {

                            /*" -4086- MOVE 12 TO ENDOSSOS-NUM-ENDOSSO */
                            _.Move(12, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO);

                            /*" -4088- MOVE WSGER12-DATA-INIVIGENCIA TO ENDOSSOS-DATA-INIVIGENCIA */
                            _.Move(WSGER12_DATA_INIVIGENCIA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA);

                            /*" -4090- MOVE WSGER12-DATA-TERVIGENCIA TO ENDOSSOS-DATA-TERVIGENCIA */
                            _.Move(WSGER12_DATA_TERVIGENCIA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_TERVIGENCIA);

                            /*" -4092- MOVE WSGER12-DATA-VENCIMENTO TO PARCEHIS-DATA-VENCIMENTO */
                            _.Move(WSGER12_DATA_VENCIMENTO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_VENCIMENTO);

                            /*" -4093- ELSE */
                        }
                        else
                        {


                            /*" -4094- IF WS-IND EQUAL 11 */

                            if (W.WS_IND == 11)
                            {

                                /*" -4096- MOVE 11 TO ENDOSSOS-NUM-ENDOSSO */
                                _.Move(11, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO);

                                /*" -4098- MOVE WSGER11-DATA-INIVIGENCIA TO ENDOSSOS-DATA-INIVIGENCIA */
                                _.Move(WSGER11_DATA_INIVIGENCIA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA);

                                /*" -4100- MOVE WSGER11-DATA-TERVIGENCIA TO ENDOSSOS-DATA-TERVIGENCIA */
                                _.Move(WSGER11_DATA_TERVIGENCIA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_TERVIGENCIA);

                                /*" -4102- MOVE WSGER11-DATA-VENCIMENTO TO PARCEHIS-DATA-VENCIMENTO */
                                _.Move(WSGER11_DATA_VENCIMENTO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_VENCIMENTO);

                                /*" -4103- ELSE */
                            }
                            else
                            {


                                /*" -4104- IF WS-IND EQUAL 10 */

                                if (W.WS_IND == 10)
                                {

                                    /*" -4106- MOVE 10 TO ENDOSSOS-NUM-ENDOSSO */
                                    _.Move(10, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO);

                                    /*" -4108- MOVE WSGER10-DATA-INIVIGENCIA TO ENDOSSOS-DATA-INIVIGENCIA */
                                    _.Move(WSGER10_DATA_INIVIGENCIA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA);

                                    /*" -4110- MOVE WSGER10-DATA-TERVIGENCIA TO ENDOSSOS-DATA-TERVIGENCIA */
                                    _.Move(WSGER10_DATA_TERVIGENCIA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_TERVIGENCIA);

                                    /*" -4112- MOVE WSGER10-DATA-VENCIMENTO TO PARCEHIS-DATA-VENCIMENTO */
                                    _.Move(WSGER10_DATA_VENCIMENTO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_VENCIMENTO);

                                    /*" -4113- ELSE */
                                }
                                else
                                {


                                    /*" -4114- IF WS-IND EQUAL 09 */

                                    if (W.WS_IND == 09)
                                    {

                                        /*" -4116- MOVE 09 TO ENDOSSOS-NUM-ENDOSSO */
                                        _.Move(09, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO);

                                        /*" -4118- MOVE WSGER09-DATA-INIVIGENCIA TO ENDOSSOS-DATA-INIVIGENCIA */
                                        _.Move(WSGER09_DATA_INIVIGENCIA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA);

                                        /*" -4120- MOVE WSGER09-DATA-TERVIGENCIA TO ENDOSSOS-DATA-TERVIGENCIA */
                                        _.Move(WSGER09_DATA_TERVIGENCIA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_TERVIGENCIA);

                                        /*" -4122- MOVE WSGER09-DATA-VENCIMENTO TO PARCEHIS-DATA-VENCIMENTO */
                                        _.Move(WSGER09_DATA_VENCIMENTO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_VENCIMENTO);

                                        /*" -4123- ELSE */
                                    }
                                    else
                                    {


                                        /*" -4124- IF WS-IND EQUAL 08 */

                                        if (W.WS_IND == 08)
                                        {

                                            /*" -4126- MOVE 08 TO ENDOSSOS-NUM-ENDOSSO */
                                            _.Move(08, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO);

                                            /*" -4128- MOVE WSGER08-DATA-INIVIGENCIA TO ENDOSSOS-DATA-INIVIGENCIA */
                                            _.Move(WSGER08_DATA_INIVIGENCIA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA);

                                            /*" -4130- MOVE WSGER08-DATA-TERVIGENCIA TO ENDOSSOS-DATA-TERVIGENCIA */
                                            _.Move(WSGER08_DATA_TERVIGENCIA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_TERVIGENCIA);

                                            /*" -4132- MOVE WSGER08-DATA-VENCIMENTO TO PARCEHIS-DATA-VENCIMENTO */
                                            _.Move(WSGER08_DATA_VENCIMENTO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_VENCIMENTO);

                                            /*" -4133- ELSE */
                                        }
                                        else
                                        {


                                            /*" -4134- IF WS-IND EQUAL 07 */

                                            if (W.WS_IND == 07)
                                            {

                                                /*" -4136- MOVE 07 TO ENDOSSOS-NUM-ENDOSSO */
                                                _.Move(07, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO);

                                                /*" -4138- MOVE WSGER07-DATA-INIVIGENCIA TO ENDOSSOS-DATA-INIVIGENCIA */
                                                _.Move(WSGER07_DATA_INIVIGENCIA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA);

                                                /*" -4140- MOVE WSGER07-DATA-TERVIGENCIA TO ENDOSSOS-DATA-TERVIGENCIA */
                                                _.Move(WSGER07_DATA_TERVIGENCIA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_TERVIGENCIA);

                                                /*" -4142- MOVE WSGER07-DATA-VENCIMENTO TO PARCEHIS-DATA-VENCIMENTO */
                                                _.Move(WSGER07_DATA_VENCIMENTO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_VENCIMENTO);

                                                /*" -4143- ELSE */
                                            }
                                            else
                                            {


                                                /*" -4144- IF WS-IND EQUAL 06 */

                                                if (W.WS_IND == 06)
                                                {

                                                    /*" -4146- MOVE 06 TO ENDOSSOS-NUM-ENDOSSO */
                                                    _.Move(06, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO);

                                                    /*" -4148- MOVE WSGER06-DATA-INIVIGENCIA TO ENDOSSOS-DATA-INIVIGENCIA */
                                                    _.Move(WSGER06_DATA_INIVIGENCIA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA);

                                                    /*" -4150- MOVE WSGER06-DATA-TERVIGENCIA TO ENDOSSOS-DATA-TERVIGENCIA */
                                                    _.Move(WSGER06_DATA_TERVIGENCIA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_TERVIGENCIA);

                                                    /*" -4152- MOVE WSGER06-DATA-VENCIMENTO TO PARCEHIS-DATA-VENCIMENTO */
                                                    _.Move(WSGER06_DATA_VENCIMENTO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_VENCIMENTO);

                                                    /*" -4153- ELSE */
                                                }
                                                else
                                                {


                                                    /*" -4154- IF WS-IND EQUAL 05 */

                                                    if (W.WS_IND == 05)
                                                    {

                                                        /*" -4156- MOVE 05 TO ENDOSSOS-NUM-ENDOSSO */
                                                        _.Move(05, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO);

                                                        /*" -4158- MOVE WSGER05-DATA-INIVIGENCIA TO ENDOSSOS-DATA-INIVIGENCIA */
                                                        _.Move(WSGER05_DATA_INIVIGENCIA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA);

                                                        /*" -4160- MOVE WSGER05-DATA-TERVIGENCIA TO ENDOSSOS-DATA-TERVIGENCIA */
                                                        _.Move(WSGER05_DATA_TERVIGENCIA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_TERVIGENCIA);

                                                        /*" -4162- MOVE WSGER05-DATA-VENCIMENTO TO PARCEHIS-DATA-VENCIMENTO */
                                                        _.Move(WSGER05_DATA_VENCIMENTO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_VENCIMENTO);

                                                        /*" -4163- ELSE */
                                                    }
                                                    else
                                                    {


                                                        /*" -4164- IF WS-IND EQUAL 04 */

                                                        if (W.WS_IND == 04)
                                                        {

                                                            /*" -4166- MOVE 04 TO ENDOSSOS-NUM-ENDOSSO */
                                                            _.Move(04, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO);

                                                            /*" -4168- MOVE WSGER04-DATA-INIVIGENCIA TO ENDOSSOS-DATA-INIVIGENCIA */
                                                            _.Move(WSGER04_DATA_INIVIGENCIA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA);

                                                            /*" -4170- MOVE WSGER04-DATA-TERVIGENCIA TO ENDOSSOS-DATA-TERVIGENCIA */
                                                            _.Move(WSGER04_DATA_TERVIGENCIA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_TERVIGENCIA);

                                                            /*" -4172- MOVE WSGER04-DATA-VENCIMENTO TO PARCEHIS-DATA-VENCIMENTO */
                                                            _.Move(WSGER04_DATA_VENCIMENTO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_VENCIMENTO);

                                                            /*" -4173- ELSE */
                                                        }
                                                        else
                                                        {


                                                            /*" -4174- IF WS-IND EQUAL 03 */

                                                            if (W.WS_IND == 03)
                                                            {

                                                                /*" -4176- MOVE 03 TO ENDOSSOS-NUM-ENDOSSO */
                                                                _.Move(03, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO);

                                                                /*" -4178- MOVE WSGER03-DATA-INIVIGENCIA TO ENDOSSOS-DATA-INIVIGENCIA */
                                                                _.Move(WSGER03_DATA_INIVIGENCIA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA);

                                                                /*" -4180- MOVE WSGER03-DATA-TERVIGENCIA TO ENDOSSOS-DATA-TERVIGENCIA */
                                                                _.Move(WSGER03_DATA_TERVIGENCIA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_TERVIGENCIA);

                                                                /*" -4182- MOVE WSGER03-DATA-VENCIMENTO TO PARCEHIS-DATA-VENCIMENTO */
                                                                _.Move(WSGER03_DATA_VENCIMENTO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_VENCIMENTO);

                                                                /*" -4183- ELSE */
                                                            }
                                                            else
                                                            {


                                                                /*" -4185- MOVE 02 TO ENDOSSOS-NUM-ENDOSSO */
                                                                _.Move(02, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO);

                                                                /*" -4187- MOVE WSGER02-DATA-INIVIGENCIA TO ENDOSSOS-DATA-INIVIGENCIA */
                                                                _.Move(WSGER02_DATA_INIVIGENCIA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA);

                                                                /*" -4189- MOVE WSGER02-DATA-TERVIGENCIA TO ENDOSSOS-DATA-TERVIGENCIA */
                                                                _.Move(WSGER02_DATA_TERVIGENCIA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_TERVIGENCIA);

                                                                /*" -4190- MOVE WSGER02-DATA-VENCIMENTO TO PARCEHIS-DATA-VENCIMENTO. */
                                                                _.Move(WSGER02_DATA_VENCIMENTO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_VENCIMENTO);
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
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4900_99_SAIDA*/

        [StopWatch]
        /*" R5000-00-MONTA-ENDOSSOS02-SECTION */
        private void R5000_00_MONTA_ENDOSSOS02_SECTION()
        {
            /*" -4206- MOVE '5000' TO WNR-EXEC-SQL. */
            _.Move("5000", AUX_RELATORIO.WABEND.WNR_EXEC_SQL);

            /*" -4212- PERFORM R3250-00-SELECT-FONTES. */

            R3250_00_SELECT_FONTES_SECTION();

            /*" -4214- MOVE APOLICES-NUM-APOLICE TO ENDOSSOS-NUM-APOLICE. */
            _.Move(APOLICES.DCLAPOLICES.APOLICES_NUM_APOLICE, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE);

            /*" -4216- MOVE APOLICES-RAMO-EMISSOR TO ENDOSSOS-RAMO-EMISSOR. */
            _.Move(APOLICES.DCLAPOLICES.APOLICES_RAMO_EMISSOR, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_RAMO_EMISSOR);

            /*" -4218- MOVE APOLICES-COD-PRODUTO TO ENDOSSOS-COD-PRODUTO. */
            _.Move(APOLICES.DCLAPOLICES.APOLICES_COD_PRODUTO, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_PRODUTO);

            /*" -4220- MOVE ZEROS TO ENDOSSOS-COD-SUBGRUPO. */
            _.Move(0, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_SUBGRUPO);

            /*" -4222- MOVE BILHETE-FONTE TO ENDOSSOS-COD-FONTE. */
            _.Move(BILHETE.DCLBILHETE.BILHETE_FONTE, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_FONTE);

            /*" -4224- MOVE FONTES-ULT-PROP-AUTOMAT TO ENDOSSOS-NUM-PROPOSTA. */
            _.Move(FONTES.DCLFONTES.FONTES_ULT_PROP_AUTOMAT, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_PROPOSTA);

            /*" -4226- MOVE BILHETE-DATA-VENDA TO ENDOSSOS-DATA-PROPOSTA. */
            _.Move(BILHETE.DCLBILHETE.BILHETE_DATA_VENDA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_PROPOSTA);

            /*" -4228- MOVE SISTEMAS-DATA-MOV-ABERTO TO ENDOSSOS-DATA-LIBERACAO. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_LIBERACAO);

            /*" -4230- MOVE SISTEMAS-DATA-MOV-ABERTO TO ENDOSSOS-DATA-EMISSAO. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_EMISSAO);

            /*" -4232- MOVE ZEROS TO ENDOSSOS-NUM-RCAP. */
            _.Move(0, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_RCAP);

            /*" -4234- MOVE ZEROS TO ENDOSSOS-VAL-RCAP. */
            _.Move(0, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_VAL_RCAP);

            /*" -4236- MOVE ZEROS TO ENDOSSOS-BCO-RCAP. */
            _.Move(0, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_BCO_RCAP);

            /*" -4238- MOVE ZEROS TO ENDOSSOS-AGE-RCAP. */
            _.Move(0, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_AGE_RCAP);

            /*" -4240- MOVE '0' TO ENDOSSOS-DAC-RCAP. */
            _.Move("0", ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DAC_RCAP);

            /*" -4242- MOVE '0' TO ENDOSSOS-TIPO-RCAP. */
            _.Move("0", ENDOSSOS.DCLENDOSSOS.ENDOSSOS_TIPO_RCAP);

            /*" -4244- MOVE 104 TO ENDOSSOS-BCO-COBRANCA. */
            _.Move(104, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_BCO_COBRANCA);

            /*" -4246- MOVE ZEROS TO ENDOSSOS-AGE-COBRANCA. */
            _.Move(0, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_AGE_COBRANCA);

            /*" -4248- MOVE '0' TO ENDOSSOS-DAC-COBRANCA. */
            _.Move("0", ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DAC_COBRANCA);

            /*" -4250- MOVE ZEROS TO ENDOSSOS-PLANO-SEGURO. */
            _.Move(0, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_PLANO_SEGURO);

            /*" -4252- MOVE ZEROS TO ENDOSSOS-PCT-ENTRADA. */
            _.Move(0, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_PCT_ENTRADA);

            /*" -4254- MOVE ZEROS TO ENDOSSOS-PCT-ADIC-FRACIO. */
            _.Move(0, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_PCT_ADIC_FRACIO);

            /*" -4256- MOVE ZEROS TO ENDOSSOS-QTD-DIAS-PRIMEIRA. */
            _.Move(0, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_QTD_DIAS_PRIMEIRA);

            /*" -4258- MOVE ZEROS TO ENDOSSOS-QTD-PARCELAS. */
            _.Move(0, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_QTD_PARCELAS);

            /*" -4260- MOVE ZEROS TO ENDOSSOS-QTD-PRESTACOES. */
            _.Move(0, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_QTD_PRESTACOES);

            /*" -4262- MOVE 1 TO ENDOSSOS-QTD-ITENS. */
            _.Move(1, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_QTD_ITENS);

            /*" -4264- MOVE SPACES TO ENDOSSOS-COD-TEXTO-PADRAO. */
            _.Move("", ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_TEXTO_PADRAO);

            /*" -4266- MOVE '0' TO ENDOSSOS-COD-ACEITACAO. */
            _.Move("0", ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_ACEITACAO);

            /*" -4268- MOVE BILHECOB-COD-MOEDA TO ENDOSSOS-COD-MOEDA-IMP. */
            _.Move(BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_COD_MOEDA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_MOEDA_IMP);

            /*" -4270- MOVE BILHECOB-COD-MOEDA TO ENDOSSOS-COD-MOEDA-PRM. */
            _.Move(BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_COD_MOEDA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_MOEDA_PRM);

            /*" -4272- MOVE '1' TO ENDOSSOS-TIPO-ENDOSSO. */
            _.Move("1", ENDOSSOS.DCLENDOSSOS.ENDOSSOS_TIPO_ENDOSSO);

            /*" -4274- MOVE 'BI6252B' TO ENDOSSOS-COD-USUARIO. */
            _.Move("BI6252B", ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_USUARIO);

            /*" -4276- MOVE BILHETE-OCORR-ENDERECO TO ENDOSSOS-OCORR-ENDERECO. */
            _.Move(BILHETE.DCLBILHETE.BILHETE_OCORR_ENDERECO, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_OCORR_ENDERECO);

            /*" -4278- MOVE '0' TO ENDOSSOS-SIT-REGISTRO. */
            _.Move("0", ENDOSSOS.DCLENDOSSOS.ENDOSSOS_SIT_REGISTRO);

            /*" -4280- MOVE SPACES TO ENDOSSOS-DATA-RCAP. */
            _.Move("", ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_RCAP);

            /*" -4282- MOVE -1 TO VIND-DATARCAP. */
            _.Move(-1, VIND_DATARCAP);

            /*" -4284- MOVE ZEROS TO ENDOSSOS-COD-EMPRESA. */
            _.Move(0, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_EMPRESA);

            /*" -4286- MOVE ZEROS TO VIND-CODEMP. */
            _.Move(0, VIND_CODEMP);

            /*" -4288- MOVE '1' TO ENDOSSOS-TIPO-CORRECAO. */
            _.Move("1", ENDOSSOS.DCLENDOSSOS.ENDOSSOS_TIPO_CORRECAO);

            /*" -4290- MOVE ZEROS TO VIND-CORRECAO. */
            _.Move(0, VIND_CORRECAO);

            /*" -4292- MOVE 'S' TO ENDOSSOS-ISENTA-CUSTO. */
            _.Move("S", ENDOSSOS.DCLENDOSSOS.ENDOSSOS_ISENTA_CUSTO);

            /*" -4294- MOVE ZEROS TO VIND-ISENTA. */
            _.Move(0, VIND_ISENTA);

            /*" -4296- MOVE SPACES TO ENDOSSOS-DATA-VENCIMENTO. */
            _.Move("", ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_VENCIMENTO);

            /*" -4298- MOVE -1 TO VIND-DTVENCTO. */
            _.Move(-1, VIND_DTVENCTO);

            /*" -4300- MOVE ZEROS TO ENDOSSOS-COEF-PREFIX. */
            _.Move(0, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COEF_PREFIX);

            /*" -4302- MOVE -1 TO VIND-PREFIX. */
            _.Move(-1, VIND_PREFIX);

            /*" -4304- MOVE ZEROS TO ENDOSSOS-VAL-CUSTO-EMISSAO. */
            _.Move(0, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_VAL_CUSTO_EMISSAO);

            /*" -4311- MOVE -1 TO VIND-CUSEMIS. */
            _.Move(-1, VIND_CUSEMIS);

            /*" -4317- PERFORM R3520-00-INSERT-ENDOSSOS. */

            R3520_00_INSERT_ENDOSSOS_SECTION();

            /*" -4319- MOVE ENDOSSOS-NUM-APOLICE TO PARCELAS-NUM-APOLICE. */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE, PARCELAS.DCLPARCELAS.PARCELAS_NUM_APOLICE);

            /*" -4321- MOVE ENDOSSOS-NUM-ENDOSSO TO PARCELAS-NUM-ENDOSSO. */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO, PARCELAS.DCLPARCELAS.PARCELAS_NUM_ENDOSSO);

            /*" -4323- MOVE ZEROS TO PARCELAS-NUM-PARCELA. */
            _.Move(0, PARCELAS.DCLPARCELAS.PARCELAS_NUM_PARCELA);

            /*" -4325- MOVE '0' TO PARCELAS-DAC-PARCELA. */
            _.Move("0", PARCELAS.DCLPARCELAS.PARCELAS_DAC_PARCELA);

            /*" -4327- MOVE ENDOSSOS-COD-FONTE TO PARCELAS-COD-FONTE. */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_FONTE, PARCELAS.DCLPARCELAS.PARCELAS_COD_FONTE);

            /*" -4329- MOVE ZEROS TO PARCELAS-NUM-TITULO. */
            _.Move(0, PARCELAS.DCLPARCELAS.PARCELAS_NUM_TITULO);

            /*" -4331- MOVE ZEROS TO PARCELAS-PRM-TARIFARIO-IX. */
            _.Move(0, PARCELAS.DCLPARCELAS.PARCELAS_PRM_TARIFARIO_IX);

            /*" -4333- MOVE ZEROS TO PARCELAS-VAL-DESCONTO-IX. */
            _.Move(0, PARCELAS.DCLPARCELAS.PARCELAS_VAL_DESCONTO_IX);

            /*" -4335- MOVE ZEROS TO PARCELAS-PRM-LIQUIDO-IX. */
            _.Move(0, PARCELAS.DCLPARCELAS.PARCELAS_PRM_LIQUIDO_IX);

            /*" -4337- MOVE ZEROS TO PARCELAS-ADICIONAL-FRAC-IX. */
            _.Move(0, PARCELAS.DCLPARCELAS.PARCELAS_ADICIONAL_FRAC_IX);

            /*" -4339- MOVE ZEROS TO PARCELAS-VAL-CUSTO-EMIS-IX. */
            _.Move(0, PARCELAS.DCLPARCELAS.PARCELAS_VAL_CUSTO_EMIS_IX);

            /*" -4341- MOVE ZEROS TO PARCELAS-VAL-IOCC-IX. */
            _.Move(0, PARCELAS.DCLPARCELAS.PARCELAS_VAL_IOCC_IX);

            /*" -4343- MOVE ZEROS TO PARCELAS-VAL-CUSTO-EMIS-IX */
            _.Move(0, PARCELAS.DCLPARCELAS.PARCELAS_VAL_CUSTO_EMIS_IX);

            /*" -4345- MOVE ZEROS TO PARCELAS-PRM-TOTAL-IX. */
            _.Move(0, PARCELAS.DCLPARCELAS.PARCELAS_PRM_TOTAL_IX);

            /*" -4347- MOVE 1 TO PARCELAS-OCORR-HISTORICO. */
            _.Move(1, PARCELAS.DCLPARCELAS.PARCELAS_OCORR_HISTORICO);

            /*" -4349- MOVE ZEROS TO PARCELAS-QTD-DOCUMENTOS. */
            _.Move(0, PARCELAS.DCLPARCELAS.PARCELAS_QTD_DOCUMENTOS);

            /*" -4351- MOVE '0' TO PARCELAS-SIT-REGISTRO. */
            _.Move("0", PARCELAS.DCLPARCELAS.PARCELAS_SIT_REGISTRO);

            /*" -4353- MOVE ENDOSSOS-COD-EMPRESA TO PARCELAS-COD-EMPRESA. */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_EMPRESA, PARCELAS.DCLPARCELAS.PARCELAS_COD_EMPRESA);

            /*" -4355- MOVE ZEROS TO VIND-CODEMP. */
            _.Move(0, VIND_CODEMP);

            /*" -4357- MOVE SPACES TO PARCELAS-SITUACAO-COBRANCA. */
            _.Move("", PARCELAS.DCLPARCELAS.PARCELAS_SITUACAO_COBRANCA);

            /*" -4366- MOVE -1 TO VIND-SIT-COBRANCA. */
            _.Move(-1, VIND_SIT_COBRANCA);

            /*" -4367- IF ENDOSSOS-NUM-ENDOSSO GREATER 12 */

            if (ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO > 12)
            {

                /*" -4374- PERFORM R5200-00-CORRIGE-IPCA. */

                R5200_00_CORRIGE_IPCA_SECTION();
            }


            /*" -4375- MOVE ZEROS TO WSHOST-VAL-IOCC. */
            _.Move(0, WSHOST_VAL_IOCC);

            /*" -4378- COMPUTE WSHOST-VAL-IOCC EQUAL (BILHECOB-PRM-TOTAL * WSHOST-PCT-IOCC). */
            WSHOST_VAL_IOCC.Value = (BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_PRM_TOTAL * WSHOST_PCT_IOCC);

            /*" -4379- MOVE BILHECOB-PRM-TOTAL TO PARCELAS-PRM-TOTAL-IX. */
            _.Move(BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_PRM_TOTAL, PARCELAS.DCLPARCELAS.PARCELAS_PRM_TOTAL_IX);

            /*" -4380- MOVE WSHOST-VAL-IOCC TO PARCELAS-VAL-IOCC-IX. */
            _.Move(WSHOST_VAL_IOCC, PARCELAS.DCLPARCELAS.PARCELAS_VAL_IOCC_IX);

            /*" -4383- COMPUTE PARCELAS-PRM-TARIFARIO-IX EQUAL (PARCELAS-PRM-TOTAL-IX - PARCELAS-VAL-IOCC-IX). */
            PARCELAS.DCLPARCELAS.PARCELAS_PRM_TARIFARIO_IX.Value = (PARCELAS.DCLPARCELAS.PARCELAS_PRM_TOTAL_IX - PARCELAS.DCLPARCELAS.PARCELAS_VAL_IOCC_IX);

            /*" -4390- MOVE PARCELAS-PRM-TARIFARIO-IX TO PARCELAS-PRM-LIQUIDO-IX. */
            _.Move(PARCELAS.DCLPARCELAS.PARCELAS_PRM_TARIFARIO_IX, PARCELAS.DCLPARCELAS.PARCELAS_PRM_LIQUIDO_IX);

            /*" -4396- PERFORM R3530-00-INSERT-PARCELAS. */

            R3530_00_INSERT_PARCELAS_SECTION();

            /*" -4398- MOVE PARCELAS-NUM-APOLICE TO PARCEHIS-NUM-APOLICE. */
            _.Move(PARCELAS.DCLPARCELAS.PARCELAS_NUM_APOLICE, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE);

            /*" -4400- MOVE PARCELAS-NUM-ENDOSSO TO PARCEHIS-NUM-ENDOSSO. */
            _.Move(PARCELAS.DCLPARCELAS.PARCELAS_NUM_ENDOSSO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO);

            /*" -4402- MOVE PARCELAS-NUM-PARCELA TO PARCEHIS-NUM-PARCELA. */
            _.Move(PARCELAS.DCLPARCELAS.PARCELAS_NUM_PARCELA, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_PARCELA);

            /*" -4404- MOVE PARCELAS-DAC-PARCELA TO PARCEHIS-DAC-PARCELA. */
            _.Move(PARCELAS.DCLPARCELAS.PARCELAS_DAC_PARCELA, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DAC_PARCELA);

            /*" -4406- MOVE SISTEMAS-DATA-MOV-ABERTO TO PARCEHIS-DATA-MOVIMENTO. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_MOVIMENTO);

            /*" -4408- MOVE 101 TO PARCEHIS-COD-OPERACAO. */
            _.Move(101, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_COD_OPERACAO);

            /*" -4410- MOVE 1 TO PARCEHIS-OCORR-HISTORICO. */
            _.Move(1, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_OCORR_HISTORICO);

            /*" -4412- MOVE PARCELAS-PRM-TARIFARIO-IX TO PARCEHIS-PRM-TARIFARIO. */
            _.Move(PARCELAS.DCLPARCELAS.PARCELAS_PRM_TARIFARIO_IX, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_PRM_TARIFARIO);

            /*" -4414- MOVE PARCELAS-VAL-DESCONTO-IX TO PARCEHIS-VAL-DESCONTO. */
            _.Move(PARCELAS.DCLPARCELAS.PARCELAS_VAL_DESCONTO_IX, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_VAL_DESCONTO);

            /*" -4416- MOVE PARCELAS-PRM-LIQUIDO-IX TO PARCEHIS-PRM-LIQUIDO. */
            _.Move(PARCELAS.DCLPARCELAS.PARCELAS_PRM_LIQUIDO_IX, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_PRM_LIQUIDO);

            /*" -4418- MOVE PARCELAS-ADICIONAL-FRAC-IX TO PARCEHIS-ADICIONAL-FRACIO. */
            _.Move(PARCELAS.DCLPARCELAS.PARCELAS_ADICIONAL_FRAC_IX, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_ADICIONAL_FRACIO);

            /*" -4420- MOVE PARCELAS-VAL-CUSTO-EMIS-IX TO PARCEHIS-VAL-CUSTO-EMISSAO. */
            _.Move(PARCELAS.DCLPARCELAS.PARCELAS_VAL_CUSTO_EMIS_IX, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_VAL_CUSTO_EMISSAO);

            /*" -4422- MOVE PARCELAS-VAL-IOCC-IX TO PARCEHIS-VAL-IOCC. */
            _.Move(PARCELAS.DCLPARCELAS.PARCELAS_VAL_IOCC_IX, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_VAL_IOCC);

            /*" -4424- MOVE PARCELAS-PRM-TOTAL-IX TO PARCEHIS-PRM-TOTAL. */
            _.Move(PARCELAS.DCLPARCELAS.PARCELAS_PRM_TOTAL_IX, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_PRM_TOTAL);

            /*" -4426- MOVE ZEROS TO PARCEHIS-VAL-OPERACAO. */
            _.Move(0, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_VAL_OPERACAO);

            /*" -4428- MOVE ENDOSSOS-BCO-COBRANCA TO PARCEHIS-BCO-COBRANCA. */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_BCO_COBRANCA, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_BCO_COBRANCA);

            /*" -4430- MOVE ENDOSSOS-AGE-COBRANCA TO PARCEHIS-AGE-COBRANCA. */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_AGE_COBRANCA, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_AGE_COBRANCA);

            /*" -4432- MOVE ZEROS TO PARCEHIS-NUM-AVISO-CREDITO. */
            _.Move(0, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_AVISO_CREDITO);

            /*" -4434- MOVE ZEROS TO PARCEHIS-ENDOS-CANCELA. */
            _.Move(0, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_ENDOS_CANCELA);

            /*" -4436- MOVE '0' TO PARCEHIS-SIT-CONTABIL. */
            _.Move("0", PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_SIT_CONTABIL);

            /*" -4438- MOVE ENDOSSOS-COD-USUARIO TO PARCEHIS-COD-USUARIO. */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_USUARIO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_COD_USUARIO);

            /*" -4440- MOVE ZEROS TO PARCEHIS-RENUM-DOCUMENTO. */
            _.Move(0, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_RENUM_DOCUMENTO);

            /*" -4442- MOVE SPACES TO PARCEHIS-DATA-QUITACAO. */
            _.Move("", PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_QUITACAO);

            /*" -4444- MOVE -1 TO VIND-DTQITBCO. */
            _.Move(-1, VIND_DTQITBCO);

            /*" -4446- MOVE PARCELAS-COD-EMPRESA TO PARCEHIS-COD-EMPRESA. */
            _.Move(PARCELAS.DCLPARCELAS.PARCELAS_COD_EMPRESA, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_COD_EMPRESA);

            /*" -4453- MOVE ZEROS TO VIND-CODEMP. */
            _.Move(0, VIND_CODEMP);

            /*" -4459- PERFORM R3550-00-INSERT-PARCEHIS. */

            R3550_00_INSERT_PARCEHIS_SECTION();

            /*" -4461- MOVE PARCELAS-NUM-APOLICE TO APOLICOB-NUM-APOLICE. */
            _.Move(PARCELAS.DCLPARCELAS.PARCELAS_NUM_APOLICE, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_NUM_APOLICE);

            /*" -4463- MOVE PARCELAS-NUM-ENDOSSO TO APOLICOB-NUM-ENDOSSO. */
            _.Move(PARCELAS.DCLPARCELAS.PARCELAS_NUM_ENDOSSO, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_NUM_ENDOSSO);

            /*" -4465- MOVE ZEROS TO APOLICOB-NUM-ITEM. */
            _.Move(0, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_NUM_ITEM);

            /*" -4467- MOVE ZEROS TO APOLICOB-OCORR-HISTORICO. */
            _.Move(0, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_OCORR_HISTORICO);

            /*" -4469- MOVE ENDOSSOS-RAMO-EMISSOR TO APOLICOB-RAMO-COBERTURA. */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_RAMO_EMISSOR, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_RAMO_COBERTURA);

            /*" -4471- MOVE APOLICES-COD-MODALIDADE TO APOLICOB-MODALI-COBERTURA. */
            _.Move(APOLICES.DCLAPOLICES.APOLICES_COD_MODALIDADE, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_MODALI_COBERTURA);

            /*" -4473- MOVE ZEROS TO APOLICOB-COD-COBERTURA. */
            _.Move(0, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_COD_COBERTURA);

            /*" -4475- MOVE BILHECOB-IMP-SEGURADA-IX TO APOLICOB-IMP-SEGURADA-IX. */
            _.Move(BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_IMP_SEGURADA_IX, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_IMP_SEGURADA_IX);

            /*" -4477- MOVE PARCELAS-PRM-TARIFARIO-IX TO APOLICOB-PRM-TARIFARIO-IX. */
            _.Move(PARCELAS.DCLPARCELAS.PARCELAS_PRM_TARIFARIO_IX, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_PRM_TARIFARIO_IX);

            /*" -4479- MOVE BILHECOB-IMP-SEGURADA-IX TO APOLICOB-IMP-SEGURADA-VAR. */
            _.Move(BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_IMP_SEGURADA_IX, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_IMP_SEGURADA_VAR);

            /*" -4481- MOVE PARCELAS-PRM-TARIFARIO-IX TO APOLICOB-PRM-TARIFARIO-VAR. */
            _.Move(PARCELAS.DCLPARCELAS.PARCELAS_PRM_TARIFARIO_IX, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_PRM_TARIFARIO_VAR);

            /*" -4483- MOVE 100 TO APOLICOB-PCT-COBERTURA. */
            _.Move(100, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_PCT_COBERTURA);

            /*" -4485- MOVE 1 TO APOLICOB-FATOR-MULTIPLICA. */
            _.Move(1, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_FATOR_MULTIPLICA);

            /*" -4487- MOVE ENDOSSOS-DATA-INIVIGENCIA TO APOLICOB-DATA-INIVIGENCIA. */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_DATA_INIVIGENCIA);

            /*" -4489- MOVE ENDOSSOS-DATA-TERVIGENCIA TO APOLICOB-DATA-TERVIGENCIA. */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_TERVIGENCIA, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_DATA_TERVIGENCIA);

            /*" -4491- MOVE ENDOSSOS-COD-EMPRESA TO APOLICOB-COD-EMPRESA. */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_EMPRESA, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_COD_EMPRESA);

            /*" -4492- MOVE ZEROS TO VIND-CODEMP. */
            _.Move(0, VIND_CODEMP);

            /*" -4494- MOVE '0' TO APOLICOB-SIT-REGISTRO. */
            _.Move("0", APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_SIT_REGISTRO);

            /*" -4500- MOVE ZEROS TO VIND-SITUACAO. */
            _.Move(0, VIND_SITUACAO);

            /*" -4521- PERFORM R3600-00-INSERT-APOLICOB. */

            R3600_00_INSERT_APOLICOB_SECTION();

            /*" -4521- PERFORM R5050-00-MONTA-MOVDEBCE. */

            R5050_00_MONTA_MOVDEBCE_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R5000_99_SAIDA*/

        [StopWatch]
        /*" R5050-00-MONTA-MOVDEBCE-SECTION */
        private void R5050_00_MONTA_MOVDEBCE_SECTION()
        {
            /*" -4537- MOVE '5050' TO WNR-EXEC-SQL. */
            _.Move("5050", AUX_RELATORIO.WABEND.WNR_EXEC_SQL);

            /*" -4539- MOVE ZEROS TO MOVDEBCE-COD-EMPRESA. */
            _.Move(0, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_EMPRESA);

            /*" -4541- MOVE PARCEHIS-NUM-APOLICE TO MOVDEBCE-NUM-APOLICE. */
            _.Move(PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE);

            /*" -4543- MOVE PARCEHIS-NUM-ENDOSSO TO MOVDEBCE-NUM-ENDOSSO. */
            _.Move(PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO);

            /*" -4546- MOVE PARCEHIS-NUM-PARCELA TO MOVDEBCE-NUM-PARCELA. */
            _.Move(PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_PARCELA, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA);

            /*" -4548- MOVE SPACES TO MOVDEBCE-SITUACAO-COBRANCA. */
            _.Move("", MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_SITUACAO_COBRANCA);

            /*" -4550- MOVE SISTEMAS-DATA-MOV-ABERTO TO MOVDEBCE-DATA-MOVIMENTO. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_MOVIMENTO);

            /*" -4552- MOVE 023000 TO MOVDEBCE-COD-CONVENIO. */
            _.Move(023000, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO);

            /*" -4554- MOVE SISTEMAS-DATA-MOV-ABERTO TO MOVDEBCE-DATA-ENVIO. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_ENVIO);

            /*" -4556- MOVE SPACES TO MOVDEBCE-DATA-RETORNO. */
            _.Move("", MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_RETORNO);

            /*" -4558- MOVE ZEROS TO MOVDEBCE-COD-RETORNO-CEF. */
            _.Move(0, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_RETORNO_CEF);

            /*" -4560- MOVE ZEROS TO MOVDEBCE-NSAS. */
            _.Move(0, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NSAS);

            /*" -4562- MOVE 'BI6252B' TO MOVDEBCE-COD-USUARIO. */
            _.Move("BI6252B", MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_USUARIO);

            /*" -4564- MOVE ZEROS TO MOVDEBCE-NUM-REQUISICAO. */
            _.Move(0, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_REQUISICAO);

            /*" -4566- MOVE MOVIMCOB-NUM-NOSSO-TITULO TO MOVDEBCE-NUM-CARTAO. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_NOSSO_TITULO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_CARTAO);

            /*" -4568- MOVE ZEROS TO MOVDEBCE-SEQUENCIA. */
            _.Move(0, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_SEQUENCIA);

            /*" -4570- MOVE ZEROS TO MOVDEBCE-NUM-LOTE. */
            _.Move(0, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_LOTE);

            /*" -4572- MOVE SPACES TO MOVDEBCE-DTCREDITO. */
            _.Move("", MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DTCREDITO);

            /*" -4574- MOVE SPACES TO MOVDEBCE-STATUS-CARTAO. */
            _.Move("", MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_STATUS_CARTAO);

            /*" -4577- MOVE ZEROS TO MOVDEBCE-VLR-CREDITO. */
            _.Move(0, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_VLR_CREDITO);

            /*" -4579- MOVE ZEROS TO MOVDEBCE-COD-AGENCIA-DEB. */
            _.Move(0, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_AGENCIA_DEB);

            /*" -4581- MOVE ZEROS TO MOVDEBCE-OPER-CONTA-DEB. */
            _.Move(0, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_OPER_CONTA_DEB);

            /*" -4583- MOVE ZEROS TO MOVDEBCE-NUM-CONTA-DEB. */
            _.Move(0, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_CONTA_DEB);

            /*" -4585- MOVE ZEROS TO MOVDEBCE-DIG-CONTA-DEB. */
            _.Move(0, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DIG_CONTA_DEB);

            /*" -4588- MOVE PARCEHIS-PRM-TOTAL TO MOVDEBCE-VALOR-DEBITO. */
            _.Move(PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_PRM_TOTAL, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_VALOR_DEBITO);

            /*" -4591- MOVE PARCEHIS-DATA-VENCIMENTO TO MOVDEBCE-DATA-VENCIMENTO WDATA-REL. */
            _.Move(PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_VENCIMENTO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_VENCIMENTO, W.WDATA_REL);

            /*" -4594- MOVE WDAT-REL-DIA TO MOVDEBCE-DIA-DEBITO. */
            _.Move(W.FILLER_1.WDAT_REL_DIA, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DIA_DEBITO);

            /*" -4601- MOVE BILHETE-NUM-BILHETE TO MOVDEBCE-NUM-CERTIFICADO. */
            _.Move(BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_CERTIFICADO);

            /*" -4615- MOVE ZEROS TO VIND-DIADEB VIND-AGEDEB VIND-OPEDEB VIND-CTADEB VIND-DIGDEB VIND-DTENVIO VIND-USUARIO VIND-CARTAO VIND-REQUISICAO. */
            _.Move(0, VIND_DIADEB, VIND_AGEDEB, VIND_OPEDEB, VIND_CTADEB, VIND_DIGDEB, VIND_DTENVIO, VIND_USUARIO, VIND_CARTAO, VIND_REQUISICAO);

            /*" -4624- MOVE -1 TO VIND-DTRETORNO VIND-CODRET VIND-SEQUENCIA VIND-LOTE VIND-DTCREDITO VIND-STATUS VIND-VLCREDITO. */
            _.Move(-1, VIND_DTRETORNO, VIND_CODRET, VIND_SEQUENCIA, VIND_LOTE, VIND_DTCREDITO, VIND_STATUS, VIND_VLCREDITO);

            /*" -4624- PERFORM R5100-00-INSERT-MOVDEBCE. */

            R5100_00_INSERT_MOVDEBCE_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R5050_99_SAIDA*/

        [StopWatch]
        /*" R5100-00-INSERT-MOVDEBCE-SECTION */
        private void R5100_00_INSERT_MOVDEBCE_SECTION()
        {
            /*" -4637- MOVE '5100' TO WNR-EXEC-SQL. */
            _.Move("5100", AUX_RELATORIO.WABEND.WNR_EXEC_SQL);

            /*" -4696- PERFORM R5100_00_INSERT_MOVDEBCE_DB_INSERT_1 */

            R5100_00_INSERT_MOVDEBCE_DB_INSERT_1();

            /*" -4700- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4703- DISPLAY 'R5100-00 -  INSERT(MOVDEBCE)   ' 'BILHETE   = ' MOVDEBCE-NUM-APOLICE 'CONVENIO  = ' MOVDEBCE-COD-CONVENIO */

                $"R5100-00 -  INSERT(MOVDEBCE)   BILHETE   = {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE}CONVENIO  = {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO}"
                .Display();

                /*" -4706- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -4706- ADD 1 TO AC-MOVDEBCE. */
            W.AC_MOVDEBCE.Value = W.AC_MOVDEBCE + 1;

        }

        [StopWatch]
        /*" R5100-00-INSERT-MOVDEBCE-DB-INSERT-1 */
        public void R5100_00_INSERT_MOVDEBCE_DB_INSERT_1()
        {
            /*" -4696- EXEC SQL INSERT INTO SEGUROS.MOVTO_DEBITOCC_CEF (COD_EMPRESA , NUM_APOLICE , NUM_ENDOSSO , NUM_PARCELA , SITUACAO_COBRANCA , DATA_VENCIMENTO , VALOR_DEBITO , DATA_MOVIMENTO , TIMESTAMP , DIA_DEBITO , COD_AGENCIA_DEB , OPER_CONTA_DEB , NUM_CONTA_DEB , DIG_CONTA_DEB , COD_CONVENIO , DATA_ENVIO , DATA_RETORNO , COD_RETORNO_CEF , NSAS , COD_USUARIO , NUM_REQUISICAO , NUM_CARTAO , SEQUENCIA , NUM_LOTE , DTCREDITO , STATUS_CARTAO , VLR_CREDITO , NUM_CERTIFICADO) VALUES (:MOVDEBCE-COD-EMPRESA , :MOVDEBCE-NUM-APOLICE , :MOVDEBCE-NUM-ENDOSSO , :MOVDEBCE-NUM-PARCELA , :MOVDEBCE-SITUACAO-COBRANCA , :MOVDEBCE-DATA-VENCIMENTO , :MOVDEBCE-VALOR-DEBITO , :MOVDEBCE-DATA-MOVIMENTO , CURRENT TIMESTAMP , :MOVDEBCE-DIA-DEBITO:VIND-DIADEB , :MOVDEBCE-COD-AGENCIA-DEB:VIND-AGEDEB , :MOVDEBCE-OPER-CONTA-DEB:VIND-OPEDEB , :MOVDEBCE-NUM-CONTA-DEB:VIND-CTADEB , :MOVDEBCE-DIG-CONTA-DEB:VIND-DIGDEB , :MOVDEBCE-COD-CONVENIO , :MOVDEBCE-DATA-ENVIO:VIND-DTENVIO , :MOVDEBCE-DATA-RETORNO:VIND-DTRETORNO , :MOVDEBCE-COD-RETORNO-CEF:VIND-CODRET , :MOVDEBCE-NSAS , :MOVDEBCE-COD-USUARIO:VIND-USUARIO , :MOVDEBCE-NUM-REQUISICAO:VIND-REQUISICAO , :MOVDEBCE-NUM-CARTAO:VIND-CARTAO , :MOVDEBCE-SEQUENCIA:VIND-SEQUENCIA , :MOVDEBCE-NUM-LOTE:VIND-LOTE , :MOVDEBCE-DTCREDITO:VIND-DTCREDITO , :MOVDEBCE-STATUS-CARTAO:VIND-STATUS , :MOVDEBCE-VLR-CREDITO:VIND-VLCREDITO , :MOVDEBCE-NUM-CERTIFICADO ) END-EXEC. */

            var r5100_00_INSERT_MOVDEBCE_DB_INSERT_1_Insert1 = new R5100_00_INSERT_MOVDEBCE_DB_INSERT_1_Insert1()
            {
                MOVDEBCE_COD_EMPRESA = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_EMPRESA.ToString(),
                MOVDEBCE_NUM_APOLICE = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE.ToString(),
                MOVDEBCE_NUM_ENDOSSO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO.ToString(),
                MOVDEBCE_NUM_PARCELA = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA.ToString(),
                MOVDEBCE_SITUACAO_COBRANCA = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_SITUACAO_COBRANCA.ToString(),
                MOVDEBCE_DATA_VENCIMENTO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_VENCIMENTO.ToString(),
                MOVDEBCE_VALOR_DEBITO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_VALOR_DEBITO.ToString(),
                MOVDEBCE_DATA_MOVIMENTO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_MOVIMENTO.ToString(),
                MOVDEBCE_DIA_DEBITO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DIA_DEBITO.ToString(),
                VIND_DIADEB = VIND_DIADEB.ToString(),
                MOVDEBCE_COD_AGENCIA_DEB = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_AGENCIA_DEB.ToString(),
                VIND_AGEDEB = VIND_AGEDEB.ToString(),
                MOVDEBCE_OPER_CONTA_DEB = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_OPER_CONTA_DEB.ToString(),
                VIND_OPEDEB = VIND_OPEDEB.ToString(),
                MOVDEBCE_NUM_CONTA_DEB = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_CONTA_DEB.ToString(),
                VIND_CTADEB = VIND_CTADEB.ToString(),
                MOVDEBCE_DIG_CONTA_DEB = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DIG_CONTA_DEB.ToString(),
                VIND_DIGDEB = VIND_DIGDEB.ToString(),
                MOVDEBCE_COD_CONVENIO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO.ToString(),
                MOVDEBCE_DATA_ENVIO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_ENVIO.ToString(),
                VIND_DTENVIO = VIND_DTENVIO.ToString(),
                MOVDEBCE_DATA_RETORNO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_RETORNO.ToString(),
                VIND_DTRETORNO = VIND_DTRETORNO.ToString(),
                MOVDEBCE_COD_RETORNO_CEF = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_RETORNO_CEF.ToString(),
                VIND_CODRET = VIND_CODRET.ToString(),
                MOVDEBCE_NSAS = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NSAS.ToString(),
                MOVDEBCE_COD_USUARIO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_USUARIO.ToString(),
                VIND_USUARIO = VIND_USUARIO.ToString(),
                MOVDEBCE_NUM_REQUISICAO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_REQUISICAO.ToString(),
                VIND_REQUISICAO = VIND_REQUISICAO.ToString(),
                MOVDEBCE_NUM_CARTAO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_CARTAO.ToString(),
                VIND_CARTAO = VIND_CARTAO.ToString(),
                MOVDEBCE_SEQUENCIA = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_SEQUENCIA.ToString(),
                VIND_SEQUENCIA = VIND_SEQUENCIA.ToString(),
                MOVDEBCE_NUM_LOTE = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_LOTE.ToString(),
                VIND_LOTE = VIND_LOTE.ToString(),
                MOVDEBCE_DTCREDITO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DTCREDITO.ToString(),
                VIND_DTCREDITO = VIND_DTCREDITO.ToString(),
                MOVDEBCE_STATUS_CARTAO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_STATUS_CARTAO.ToString(),
                VIND_STATUS = VIND_STATUS.ToString(),
                MOVDEBCE_VLR_CREDITO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_VLR_CREDITO.ToString(),
                VIND_VLCREDITO = VIND_VLCREDITO.ToString(),
                MOVDEBCE_NUM_CERTIFICADO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_CERTIFICADO.ToString(),
            };

            R5100_00_INSERT_MOVDEBCE_DB_INSERT_1_Insert1.Execute(r5100_00_INSERT_MOVDEBCE_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R5100_99_SAIDA*/

        [StopWatch]
        /*" R5200-00-CORRIGE-IPCA-SECTION */
        private void R5200_00_CORRIGE_IPCA_SECTION()
        {
            /*" -4719- MOVE '5200' TO WNR-EXEC-SQL. */
            _.Move("5200", AUX_RELATORIO.WABEND.WNR_EXEC_SQL);

            /*" -4721- MOVE MOVIMCOB-NUM-AVISO TO LD01-CONVENIO. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_AVISO, AUX_RELATORIO.LD01.LD01_CONVENIO);

            /*" -4723- MOVE MOVIMCOB-NUM-NOSSO-TITULO TO LD01-PROPOSTA. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_NOSSO_TITULO, AUX_RELATORIO.LD01.LD01_PROPOSTA);

            /*" -4725- MOVE MOVIMCOB-NUM-TITULO TO LD01-BILHETE. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_TITULO, AUX_RELATORIO.LD01.LD01_BILHETE);

            /*" -4727- MOVE MOVIMCOB-NUM-FITA TO LD01-NSAS. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_FITA, AUX_RELATORIO.LD01.LD01_NSAS);

            /*" -4729- MOVE MOVIMCOB-VAL-TITULO TO LD01-VALOR. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_VAL_TITULO, AUX_RELATORIO.LD01.LD01_VALOR);

            /*" -4731- MOVE MOVIMCOB-NUM-APOLICE TO LD01-APOLICE. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_APOLICE, AUX_RELATORIO.LD01.LD01_APOLICE);

            /*" -4733- MOVE ENDOSSOS-NUM-ENDOSSO TO LD01-ENDOSSO. */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO, AUX_RELATORIO.LD01.LD01_ENDOSSO);

            /*" -4735- MOVE MOVIMCOB-NUM-PARCELA TO LD01-PARCELA. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_PARCELA, AUX_RELATORIO.LD01.LD01_PARCELA);

            /*" -4737- MOVE CONVERSI-COD-PRODUTO-SIVPF TO LD01-CODPRODU. */
            _.Move(CONVERSI.DCLCONVERSAO_SICOB.CONVERSI_COD_PRODUTO_SIVPF, AUX_RELATORIO.LD01.LD01_CODPRODU);

            /*" -4740- MOVE BILHETE-OPC-COBERTURA TO LD01-OPCAO. */
            _.Move(BILHETE.DCLBILHETE.BILHETE_OPC_COBERTURA, AUX_RELATORIO.LD01.LD01_OPCAO);

            /*" -4742- MOVE PARCEHIS-DATA-VENCIMENTO TO WDATA-REL */
            _.Move(PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_VENCIMENTO, W.WDATA_REL);

            /*" -4743- MOVE WDAT-REL-DIA TO WDATA-DD-CABEC */
            _.Move(W.FILLER_1.WDAT_REL_DIA, W.WDATA_CABEC.WDATA_DD_CABEC);

            /*" -4744- MOVE WDAT-REL-MES TO WDATA-MM-CABEC */
            _.Move(W.FILLER_1.WDAT_REL_MES, W.WDATA_CABEC.WDATA_MM_CABEC);

            /*" -4745- MOVE WDAT-REL-ANO TO WDATA-AA-CABEC */
            _.Move(W.FILLER_1.WDAT_REL_ANO, W.WDATA_CABEC.WDATA_AA_CABEC);

            /*" -4747- MOVE WDATA-CABEC TO LD01-DTPAGTO. */
            _.Move(W.WDATA_CABEC, AUX_RELATORIO.LD01.LD01_DTPAGTO);

            /*" -4749- MOVE PARCEHIS-DATA-VENCIMENTO TO WDATA-REL */
            _.Move(PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_VENCIMENTO, W.WDATA_REL);

            /*" -4750- MOVE WDAT-REL-DIA TO WDATA-DD-CABEC */
            _.Move(W.FILLER_1.WDAT_REL_DIA, W.WDATA_CABEC.WDATA_DD_CABEC);

            /*" -4751- MOVE WDAT-REL-MES TO WDATA-MM-CABEC */
            _.Move(W.FILLER_1.WDAT_REL_MES, W.WDATA_CABEC.WDATA_MM_CABEC);

            /*" -4752- MOVE WDAT-REL-ANO TO WDATA-AA-CABEC */
            _.Move(W.FILLER_1.WDAT_REL_ANO, W.WDATA_CABEC.WDATA_AA_CABEC);

            /*" -4759- MOVE WDATA-CABEC TO LD01-DTCREDITO. */
            _.Move(W.WDATA_CABEC, AUX_RELATORIO.LD01.LD01_DTCREDITO);

            /*" -4762- PERFORM R5210-00-SELECT-CALENDAR. */

            R5210_00_SELECT_CALENDAR_SECTION();

            /*" -4763- SET WS-IPC TO 1. */
            WS_IPC.Value = 1;

            /*" -4764- MOVE SPACES TO WFIM-COTACAO. */
            _.Move("", W.WFIM_COTACAO);

            /*" -4766- MOVE ZEROS TO WS-IPCA-ACUM. */
            _.Move(0, W.WS_IPCA_ACUM);

            /*" -4775- PERFORM R5250-00-VER-COTACAO UNTIL WFIM-COTACAO NOT EQUAL SPACES. */

            while (!(!W.WFIM_COTACAO.IsEmpty()))
            {

                R5250_00_VER_COTACAO_SECTION();
            }

            /*" -4778- COMPUTE WS-IPCA-ACUM ROUNDED EQUAL (WS-IPCA-ACUM / 100). */
            W.WS_IPCA_ACUM.Value = (W.WS_IPCA_ACUM / 100f);

            /*" -4780- MOVE WS-IPCA-ACUM TO LD01-IND-IPCA. */
            _.Move(W.WS_IPCA_ACUM, AUX_RELATORIO.LD01.LD01_IND_IPCA);

            /*" -4783- COMPUTE WSHOST-IMP-SEGURADA-IX EQUAL BILHECOB-IMP-SEGURADA-IX * WS-IPCA-ACUM. */
            WSHOST_IMP_SEGURADA_IX.Value = BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_IMP_SEGURADA_IX * W.WS_IPCA_ACUM;

            /*" -4787- COMPUTE WSHOST-PRM-TOTAL EQUAL BILHECOB-PRM-TOTAL * WS-IPCA-ACUM. */
            WSHOST_PRM_TOTAL.Value = BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_PRM_TOTAL * W.WS_IPCA_ACUM;

            /*" -4790- ADD WSHOST-IMP-SEGURADA-IX TO BILHECOB-IMP-SEGURADA-IX. */
            BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_IMP_SEGURADA_IX.Value = BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_IMP_SEGURADA_IX + WSHOST_IMP_SEGURADA_IX;

            /*" -4793- ADD WSHOST-PRM-TOTAL TO BILHECOB-PRM-TOTAL. */
            BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_PRM_TOTAL.Value = BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_PRM_TOTAL + WSHOST_PRM_TOTAL;

            /*" -4795- MOVE BILHECOB-PRM-TOTAL TO LD01-PRM-IPCA. */
            _.Move(BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_PRM_TOTAL, AUX_RELATORIO.LD01.LD01_PRM_IPCA);

            /*" -4798- MOVE BILHECOB-IMP-SEGURADA-IX TO LD01-IMP-IPCA. */
            _.Move(BILHECOB.DCLBILHETE_COBERTURA.BILHECOB_IMP_SEGURADA_IX, AUX_RELATORIO.LD01.LD01_IMP_IPCA);

            /*" -4801- MOVE 'PARCELA GERADA COM CORRECAO IPCA        ' TO LD01-MENSAGEM. */
            _.Move("PARCELA GERADA COM CORRECAO IPCA        ", AUX_RELATORIO.LD01.LD01_MENSAGEM);

            /*" -4802- WRITE REG-BI6252B FROM LD01. */
            _.Move(AUX_RELATORIO.LD01.GetMoveValues(), REG_BI6252B);

            BI6252B1.Write(REG_BI6252B.GetMoveValues().ToString());

            /*" -4802- ADD 1 TO GV-SAIDA. */
            W.GV_SAIDA.Value = W.GV_SAIDA + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R5200_99_SAIDA*/

        [StopWatch]
        /*" R5210-00-SELECT-CALENDAR-SECTION */
        private void R5210_00_SELECT_CALENDAR_SECTION()
        {
            /*" -4815- MOVE '5210' TO WNR-EXEC-SQL. */
            _.Move("5210", AUX_RELATORIO.WABEND.WNR_EXEC_SQL);

            /*" -4818- MOVE WSGER13-DATA-INIVIGENCIA TO CALENDAR-DATA-CALENDARIO. */
            _.Move(WSGER13_DATA_INIVIGENCIA, CALENDAR.DCLCALENDARIO.CALENDAR_DATA_CALENDARIO);

            /*" -4826- PERFORM R5210_00_SELECT_CALENDAR_DB_SELECT_1 */

            R5210_00_SELECT_CALENDAR_DB_SELECT_1();

            /*" -4830- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4831- DISPLAY 'R5210-00 - PROBLEMAS SELECT  (CALENDAR)   ' */
                _.Display($"R5210-00 - PROBLEMAS SELECT  (CALENDAR)   ");

                /*" -4832- DISPLAY 'DATA-CALENDARIO = ' CALENDAR-DATA-CALENDARIO */
                _.Display($"DATA-CALENDARIO = {CALENDAR.DCLCALENDARIO.CALENDAR_DATA_CALENDARIO}");

                /*" -4832- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R5210-00-SELECT-CALENDAR-DB-SELECT-1 */
        public void R5210_00_SELECT_CALENDAR_DB_SELECT_1()
        {
            /*" -4826- EXEC SQL SELECT (DATA_CALENDARIO - 012 MONTH) INTO :WSCOR99-DATA-INIVIGENCIA FROM SEGUROS.CALENDARIO WHERE DATA_CALENDARIO = :CALENDAR-DATA-CALENDARIO WITH UR END-EXEC. */

            var r5210_00_SELECT_CALENDAR_DB_SELECT_1_Query1 = new R5210_00_SELECT_CALENDAR_DB_SELECT_1_Query1()
            {
                CALENDAR_DATA_CALENDARIO = CALENDAR.DCLCALENDARIO.CALENDAR_DATA_CALENDARIO.ToString(),
            };

            var executed_1 = R5210_00_SELECT_CALENDAR_DB_SELECT_1_Query1.Execute(r5210_00_SELECT_CALENDAR_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WSCOR99_DATA_INIVIGENCIA, WSCOR99_DATA_INIVIGENCIA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R5210_99_SAIDA*/

        [StopWatch]
        /*" R5250-00-VER-COTACAO-SECTION */
        private void R5250_00_VER_COTACAO_SECTION()
        {
            /*" -4845- MOVE '5250' TO WNR-EXEC-SQL. */
            _.Move("5250", AUX_RELATORIO.WABEND.WNR_EXEC_SQL);

            /*" -4847- SET WS-IND TO WS-IPC. */
            W.WS_IND.Value = WS_IPC;

            /*" -4848- IF WS-IND GREATER 300 */

            if (W.WS_IND > 300)
            {

                /*" -4849- MOVE 'S' TO WFIM-COTACAO */
                _.Move("S", W.WFIM_COTACAO);

                /*" -4852- GO TO R5250-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R5250_99_SAIDA*/ //GOTO
                return;
            }


            /*" -4853- IF TB-DTINIVIG-IPCA(WS-IPC) EQUAL SPACES */

            if (TABELA_IPCA.WTIPC_OCORREIPC[WS_IPC].TB_DTINIVIG_IPCA == string.Empty)
            {

                /*" -4854- MOVE 'S' TO WFIM-COTACAO */
                _.Move("S", W.WFIM_COTACAO);

                /*" -4857- GO TO R5250-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R5250_99_SAIDA*/ //GOTO
                return;
            }


            /*" -4859- IF WSCOR99-DATA-INIVIGENCIA GREATER TB-DTTERVIG-IPCA(WS-IPC) */

            if (WSCOR99_DATA_INIVIGENCIA > TABELA_IPCA.WTIPC_OCORREIPC[WS_IPC].TB_DTTERVIG_IPCA)
            {

                /*" -4860- SET WS-IPC UP BY 1 */
                WS_IPC.Value += 1;

                /*" -4863- GO TO R5250-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R5250_99_SAIDA*/ //GOTO
                return;
            }


            /*" -4867- MOVE TB-VAL-IPCA(WS-IPC) TO WS-IPCA-ACUM. */
            _.Move(TABELA_IPCA.WTIPC_OCORREIPC[WS_IPC].TB_VAL_IPCA, W.WS_IPCA_ACUM);

            /*" -4868- SET WS-IPC UP BY 1. */
            WS_IPC.Value += 1;

            /*" -4870- MOVE 1 TO WS-SUBS. */
            _.Move(1, W.WS_SUBS);

            /*" -4871- PERFORM R5300-00-CALCULA-IPCA UNTIL WFIM-COTACAO NOT EQUAL SPACES. */

            while (!(!W.WFIM_COTACAO.IsEmpty()))
            {

                R5300_00_CALCULA_IPCA_SECTION();
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R5250_99_SAIDA*/

        [StopWatch]
        /*" R5300-00-CALCULA-IPCA-SECTION */
        private void R5300_00_CALCULA_IPCA_SECTION()
        {
            /*" -4884- MOVE '5300' TO WNR-EXEC-SQL. */
            _.Move("5300", AUX_RELATORIO.WABEND.WNR_EXEC_SQL);

            /*" -4886- SET WS-IND TO WS-IPC. */
            W.WS_IND.Value = WS_IPC;

            /*" -4887- IF WS-IND GREATER 300 */

            if (W.WS_IND > 300)
            {

                /*" -4888- MOVE 'S' TO WFIM-COTACAO */
                _.Move("S", W.WFIM_COTACAO);

                /*" -4891- GO TO R5300-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R5300_99_SAIDA*/ //GOTO
                return;
            }


            /*" -4892- IF TB-DTINIVIG-IPCA(WS-IPC) EQUAL SPACES */

            if (TABELA_IPCA.WTIPC_OCORREIPC[WS_IPC].TB_DTINIVIG_IPCA == string.Empty)
            {

                /*" -4893- MOVE 'S' TO WFIM-COTACAO */
                _.Move("S", W.WFIM_COTACAO);

                /*" -4896- GO TO R5300-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R5300_99_SAIDA*/ //GOTO
                return;
            }


            /*" -4897- IF WS-SUBS GREATER 12 */

            if (W.WS_SUBS > 12)
            {

                /*" -4898- MOVE 'S' TO WFIM-COTACAO */
                _.Move("S", W.WFIM_COTACAO);

                /*" -4901- GO TO R5300-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R5300_99_SAIDA*/ //GOTO
                return;
            }


            /*" -4905- MOVE TB-VAL-IPCA(WS-IPC) TO MOEDACOT-VAL-VENDA. */
            _.Move(TABELA_IPCA.WTIPC_OCORREIPC[WS_IPC].TB_VAL_IPCA, MOEDACOT.DCLMOEDAS_COTACAO.MOEDACOT_VAL_VENDA);

            /*" -4910- COMPUTE WS-IPCA-ACUM EQUAL (((MOEDACOT-VAL-VENDA / 100 + 1) * (WS-IPCA-ACUM / 100 + 1) - 1 ) * 100). */
            W.WS_IPCA_ACUM.Value = (((MOEDACOT.DCLMOEDAS_COTACAO.MOEDACOT_VAL_VENDA / 100f + 1) * (W.WS_IPCA_ACUM / 100f + 1) - 1) * 100);

            /*" -4911- SET WS-IPC UP BY 1. */
            WS_IPC.Value += 1;

            /*" -4911- ADD 1 TO WS-SUBS. */
            W.WS_SUBS.Value = W.WS_SUBS + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R5300_99_SAIDA*/

        [StopWatch]
        /*" R6000-00-MONTA-CORRETAGEM-SECTION */
        private void R6000_00_MONTA_CORRETAGEM_SECTION()
        {
            /*" -4961- MOVE '6000' TO WNR-EXEC-SQL. */
            _.Move("6000", AUX_RELATORIO.WABEND.WNR_EXEC_SQL);

            /*" -4963- MOVE APOLICOB-NUM-APOLICE TO APOLICOR-NUM-APOLICE. */
            _.Move(APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_NUM_APOLICE, APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_NUM_APOLICE);

            /*" -4965- MOVE APOLICOB-RAMO-COBERTURA TO APOLICOR-RAMO-COBERTURA. */
            _.Move(APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_RAMO_COBERTURA, APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_RAMO_COBERTURA);

            /*" -4967- MOVE APOLICOB-MODALI-COBERTURA TO APOLICOR-MODALI-COBERTURA. */
            _.Move(APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_MODALI_COBERTURA, APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_MODALI_COBERTURA);

            /*" -4969- MOVE 100081 TO APOLICOR-COD-CORRETOR. */
            _.Move(100081, APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_COD_CORRETOR);

            /*" -4971- MOVE ENDOSSOS-COD-SUBGRUPO TO APOLICOR-COD-SUBGRUPO. */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_SUBGRUPO, APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_COD_SUBGRUPO);

            /*" -4973- MOVE WSGER00-DATA-INIVIGENCIA TO APOLICOR-DATA-INIVIGENCIA. */
            _.Move(WSGER00_DATA_INIVIGENCIA, APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_DATA_INIVIGENCIA);

            /*" -4975- MOVE WSGER03-DATA-TERVIGENCIA TO APOLICOR-DATA-TERVIGENCIA. */
            _.Move(WSGER03_DATA_TERVIGENCIA, APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_DATA_TERVIGENCIA);

            /*" -4977- MOVE 100 TO APOLICOR-PCT-PART-CORRETOR. */
            _.Move(100, APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_PCT_PART_CORRETOR);

            /*" -4979- MOVE 60 TO APOLICOR-PCT-COM-CORRETOR. */
            _.Move(60, APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_PCT_COM_CORRETOR);

            /*" -4981- MOVE '2' TO APOLICOR-TIPO-COMISSAO. */
            _.Move("2", APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_TIPO_COMISSAO);

            /*" -4983- MOVE '1' TO APOLICOR-IND-CORRETOR-PRIN. */
            _.Move("1", APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_IND_CORRETOR_PRIN);

            /*" -4985- MOVE ENDOSSOS-COD-EMPRESA TO APOLICOR-COD-EMPRESA. */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_EMPRESA, APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_COD_EMPRESA);

            /*" -4986- MOVE ZEROS TO VIND-CODEMP. */
            _.Move(0, VIND_CODEMP);

            /*" -4990- MOVE 'BI6252B' TO APOLICOR-COD-USUARIO. */
            _.Move("BI6252B", APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_COD_USUARIO);

            /*" -4997- PERFORM R6200-00-INSERT-APOLICOR. */

            R6200_00_INSERT_APOLICOR_SECTION();

            /*" -4999- MOVE APOLICOB-NUM-APOLICE TO APOLICOR-NUM-APOLICE. */
            _.Move(APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_NUM_APOLICE, APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_NUM_APOLICE);

            /*" -5001- MOVE APOLICOB-RAMO-COBERTURA TO APOLICOR-RAMO-COBERTURA. */
            _.Move(APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_RAMO_COBERTURA, APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_RAMO_COBERTURA);

            /*" -5003- MOVE APOLICOB-MODALI-COBERTURA TO APOLICOR-MODALI-COBERTURA. */
            _.Move(APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_MODALI_COBERTURA, APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_MODALI_COBERTURA);

            /*" -5005- MOVE 24317 TO APOLICOR-COD-CORRETOR. */
            _.Move(24317, APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_COD_CORRETOR);

            /*" -5007- MOVE ENDOSSOS-COD-SUBGRUPO TO APOLICOR-COD-SUBGRUPO. */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_SUBGRUPO, APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_COD_SUBGRUPO);

            /*" -5009- MOVE WSGER00-DATA-INIVIGENCIA TO APOLICOR-DATA-INIVIGENCIA. */
            _.Move(WSGER00_DATA_INIVIGENCIA, APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_DATA_INIVIGENCIA);

            /*" -5011- MOVE WSGER00-DATA-TERVIGENCIA TO APOLICOR-DATA-TERVIGENCIA. */
            _.Move(WSGER00_DATA_TERVIGENCIA, APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_DATA_TERVIGENCIA);

            /*" -5013- MOVE 100 TO APOLICOR-PCT-PART-CORRETOR. */
            _.Move(100, APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_PCT_PART_CORRETOR);

            /*" -5015- MOVE 40 TO APOLICOR-PCT-COM-CORRETOR. */
            _.Move(40, APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_PCT_COM_CORRETOR);

            /*" -5017- MOVE '1' TO APOLICOR-TIPO-COMISSAO. */
            _.Move("1", APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_TIPO_COMISSAO);

            /*" -5019- MOVE '1' TO APOLICOR-IND-CORRETOR-PRIN. */
            _.Move("1", APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_IND_CORRETOR_PRIN);

            /*" -5021- MOVE ENDOSSOS-COD-EMPRESA TO APOLICOR-COD-EMPRESA. */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_EMPRESA, APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_COD_EMPRESA);

            /*" -5022- MOVE ZEROS TO VIND-CODEMP. */
            _.Move(0, VIND_CODEMP);

            /*" -5026- MOVE 'BI6252B' TO APOLICOR-COD-USUARIO. */
            _.Move("BI6252B", APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_COD_USUARIO);

            /*" -5029- PERFORM R6200-00-INSERT-APOLICOR. */

            R6200_00_INSERT_APOLICOR_SECTION();

            /*" -5030- IF ENDOSSOS-NUM-ENDOSSO GREATER 12 */

            if (ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO > 12)
            {

                /*" -5030- PERFORM R6100-00-MONTA-AGENCIAMENTO. */

                R6100_00_MONTA_AGENCIAMENTO_SECTION();
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R6000_99_SAIDA*/

        [StopWatch]
        /*" R6100-00-MONTA-AGENCIAMENTO-SECTION */
        private void R6100_00_MONTA_AGENCIAMENTO_SECTION()
        {
            /*" -5059- MOVE '6100' TO WNR-EXEC-SQL. */
            _.Move("6100", AUX_RELATORIO.WABEND.WNR_EXEC_SQL);

            /*" -5061- MOVE APOLICOB-NUM-APOLICE TO APOLICOR-NUM-APOLICE. */
            _.Move(APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_NUM_APOLICE, APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_NUM_APOLICE);

            /*" -5063- MOVE APOLICOB-RAMO-COBERTURA TO APOLICOR-RAMO-COBERTURA. */
            _.Move(APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_RAMO_COBERTURA, APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_RAMO_COBERTURA);

            /*" -5065- MOVE APOLICOB-MODALI-COBERTURA TO APOLICOR-MODALI-COBERTURA. */
            _.Move(APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_MODALI_COBERTURA, APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_MODALI_COBERTURA);

            /*" -5067- MOVE 100081 TO APOLICOR-COD-CORRETOR. */
            _.Move(100081, APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_COD_CORRETOR);

            /*" -5069- MOVE ENDOSSOS-COD-SUBGRUPO TO APOLICOR-COD-SUBGRUPO. */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_SUBGRUPO, APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_COD_SUBGRUPO);

            /*" -5071- MOVE WSGER13-DATA-INIVIGENCIA TO APOLICOR-DATA-INIVIGENCIA. */
            _.Move(WSGER13_DATA_INIVIGENCIA, APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_DATA_INIVIGENCIA);

            /*" -5073- MOVE WSGER14-DATA-TERVIGENCIA TO APOLICOR-DATA-TERVIGENCIA. */
            _.Move(WSGER14_DATA_TERVIGENCIA, APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_DATA_TERVIGENCIA);

            /*" -5075- MOVE 100 TO APOLICOR-PCT-PART-CORRETOR. */
            _.Move(100, APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_PCT_PART_CORRETOR);

            /*" -5077- MOVE 30 TO APOLICOR-PCT-COM-CORRETOR. */
            _.Move(30, APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_PCT_COM_CORRETOR);

            /*" -5079- MOVE '2' TO APOLICOR-TIPO-COMISSAO. */
            _.Move("2", APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_TIPO_COMISSAO);

            /*" -5081- MOVE '1' TO APOLICOR-IND-CORRETOR-PRIN. */
            _.Move("1", APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_IND_CORRETOR_PRIN);

            /*" -5083- MOVE ENDOSSOS-COD-EMPRESA TO APOLICOR-COD-EMPRESA. */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_EMPRESA, APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_COD_EMPRESA);

            /*" -5084- MOVE ZEROS TO VIND-CODEMP. */
            _.Move(0, VIND_CODEMP);

            /*" -5088- MOVE 'BI6252B' TO APOLICOR-COD-USUARIO. */
            _.Move("BI6252B", APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_COD_USUARIO);

            /*" -5088- PERFORM R6200-00-INSERT-APOLICOR. */

            R6200_00_INSERT_APOLICOR_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R6100_99_SAIDA*/

        [StopWatch]
        /*" R6200-00-INSERT-APOLICOR-SECTION */
        private void R6200_00_INSERT_APOLICOR_SECTION()
        {
            /*" -5100- MOVE '6200' TO WNR-EXEC-SQL. */
            _.Move("6200", AUX_RELATORIO.WABEND.WNR_EXEC_SQL);

            /*" -5105- PERFORM R6200_00_INSERT_APOLICOR_DB_SELECT_1 */

            R6200_00_INSERT_APOLICOR_DB_SELECT_1();

            /*" -5108- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5109- DISPLAY 'R6200-00 (ERRO - SELECT PARAMETROS_GERAIS)' */
                _.Display($"R6200-00 (ERRO - SELECT PARAMETROS_GERAIS)");

                /*" -5110- DISPLAY 'COD PRODUTO: ' APOLICES-COD-PRODUTO */
                _.Display($"COD PRODUTO: {APOLICES.DCLAPOLICES.APOLICES_COD_PRODUTO}");

                /*" -5112- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -5113- MOVE APOLICOR-COD-CORRETOR TO WS-COD-CORRETOR */
            _.Move(APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_COD_CORRETOR, WS_COD_CORRETOR);

            /*" -5117- IF PRODUTO-COD-EMPRESA = 11 AND N88-COD-CORRETOR AND APOLICOR-TIPO-COMISSAO = '1' AND SISTEMAS-DATA-MOV-ABERTO >= '2021-08-16' */

            if (PRODUTO.DCLPRODUTO.PRODUTO_COD_EMPRESA == 11 && WS_COD_CORRETOR["N88_COD_CORRETOR"] && APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_TIPO_COMISSAO == "1" && SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO >= "2021-08-16")
            {

                /*" -5118- MOVE 25267 TO APOLICOR-COD-CORRETOR */
                _.Move(25267, APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_COD_CORRETOR);

                /*" -5120- END-IF */
            }


            /*" -5151- PERFORM R6200_00_INSERT_APOLICOR_DB_INSERT_1 */

            R6200_00_INSERT_APOLICOR_DB_INSERT_1();

            /*" -5154- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5155- DISPLAY 'R6200-00 - PROBLEMAS NO INSERT(APOLICOR)   ' */
                _.Display($"R6200-00 - PROBLEMAS NO INSERT(APOLICOR)   ");

                /*" -5156- DISPLAY 'SIT-REGISTRO    = ' MOVIMCOB-SIT-REGISTRO */
                _.Display($"SIT-REGISTRO    = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_SIT_REGISTRO}");

                /*" -5157- DISPLAY 'COD-BANCO       = ' MOVIMCOB-COD-BANCO */
                _.Display($"COD-BANCO       = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_BANCO}");

                /*" -5158- DISPLAY 'COD-AGENCIA     = ' MOVIMCOB-COD-AGENCIA */
                _.Display($"COD-AGENCIA     = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_AGENCIA}");

                /*" -5159- DISPLAY 'NUM-AVISO       = ' MOVIMCOB-NUM-AVISO */
                _.Display($"NUM-AVISO       = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_AVISO}");

                /*" -5160- DISPLAY 'NUM-NOSSO-TITULO= ' MOVIMCOB-NUM-NOSSO-TITULO */
                _.Display($"NUM-NOSSO-TITULO= {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_NOSSO_TITULO}");

                /*" -5161- DISPLAY 'COD-MOVIMENTO   = ' MOVIMCOB-COD-MOVIMENTO */
                _.Display($"COD-MOVIMENTO   = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_MOVIMENTO}");

                /*" -5162- DISPLAY 'NOME-SEGURADO   = ' MOVIMCOB-NOME-SEGURADO */
                _.Display($"NOME-SEGURADO   = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NOME_SEGURADO}");

                /*" -5163- DISPLAY 'NUM-APOLICE     = ' APOLICOR-NUM-APOLICE */
                _.Display($"NUM-APOLICE     = {APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_NUM_APOLICE}");

                /*" -5164- DISPLAY 'COD-SUBGRUPO    = ' APOLICOR-COD-SUBGRUPO */
                _.Display($"COD-SUBGRUPO    = {APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_COD_SUBGRUPO}");

                /*" -5165- DISPLAY 'COD-CORRETOR    = ' APOLICOR-COD-CORRETOR */
                _.Display($"COD-CORRETOR    = {APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_COD_CORRETOR}");

                /*" -5165- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R6200-00-INSERT-APOLICOR-DB-SELECT-1 */
        public void R6200_00_INSERT_APOLICOR_DB_SELECT_1()
        {
            /*" -5105- EXEC SQL SELECT PD.COD_EMPRESA INTO :PRODUTO-COD-EMPRESA FROM SEGUROS.PRODUTO PD WHERE PD.COD_PRODUTO = :APOLICES-COD-PRODUTO END-EXEC */

            var r6200_00_INSERT_APOLICOR_DB_SELECT_1_Query1 = new R6200_00_INSERT_APOLICOR_DB_SELECT_1_Query1()
            {
                APOLICES_COD_PRODUTO = APOLICES.DCLAPOLICES.APOLICES_COD_PRODUTO.ToString(),
            };

            var executed_1 = R6200_00_INSERT_APOLICOR_DB_SELECT_1_Query1.Execute(r6200_00_INSERT_APOLICOR_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PRODUTO_COD_EMPRESA, PRODUTO.DCLPRODUTO.PRODUTO_COD_EMPRESA);
            }


        }

        [StopWatch]
        /*" R6200-00-INSERT-APOLICOR-DB-INSERT-1 */
        public void R6200_00_INSERT_APOLICOR_DB_INSERT_1()
        {
            /*" -5151- EXEC SQL INSERT INTO SEGUROS.APOLICE_CORRETOR (NUM_APOLICE , RAMO_COBERTURA , MODALI_COBERTURA , COD_CORRETOR , COD_SUBGRUPO , DATA_INIVIGENCIA , DATA_TERVIGENCIA , PCT_PART_CORRETOR , PCT_COM_CORRETOR , TIPO_COMISSAO , IND_CORRETOR_PRIN , COD_EMPRESA , TIMESTAMP , COD_USUARIO) VALUES (:APOLICOR-NUM-APOLICE , :APOLICOR-RAMO-COBERTURA , :APOLICOR-MODALI-COBERTURA , :APOLICOR-COD-CORRETOR , :APOLICOR-COD-SUBGRUPO , :APOLICOR-DATA-INIVIGENCIA , :APOLICOR-DATA-TERVIGENCIA , :APOLICOR-PCT-PART-CORRETOR , :APOLICOR-PCT-COM-CORRETOR , :APOLICOR-TIPO-COMISSAO , :APOLICOR-IND-CORRETOR-PRIN , :APOLICOR-COD-EMPRESA:VIND-CODEMP, CURRENT TIMESTAMP , :APOLICOR-COD-USUARIO) END-EXEC. */

            var r6200_00_INSERT_APOLICOR_DB_INSERT_1_Insert1 = new R6200_00_INSERT_APOLICOR_DB_INSERT_1_Insert1()
            {
                APOLICOR_NUM_APOLICE = APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_NUM_APOLICE.ToString(),
                APOLICOR_RAMO_COBERTURA = APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_RAMO_COBERTURA.ToString(),
                APOLICOR_MODALI_COBERTURA = APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_MODALI_COBERTURA.ToString(),
                APOLICOR_COD_CORRETOR = APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_COD_CORRETOR.ToString(),
                APOLICOR_COD_SUBGRUPO = APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_COD_SUBGRUPO.ToString(),
                APOLICOR_DATA_INIVIGENCIA = APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_DATA_INIVIGENCIA.ToString(),
                APOLICOR_DATA_TERVIGENCIA = APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_DATA_TERVIGENCIA.ToString(),
                APOLICOR_PCT_PART_CORRETOR = APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_PCT_PART_CORRETOR.ToString(),
                APOLICOR_PCT_COM_CORRETOR = APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_PCT_COM_CORRETOR.ToString(),
                APOLICOR_TIPO_COMISSAO = APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_TIPO_COMISSAO.ToString(),
                APOLICOR_IND_CORRETOR_PRIN = APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_IND_CORRETOR_PRIN.ToString(),
                APOLICOR_COD_EMPRESA = APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_COD_EMPRESA.ToString(),
                VIND_CODEMP = VIND_CODEMP.ToString(),
                APOLICOR_COD_USUARIO = APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_COD_USUARIO.ToString(),
            };

            R6200_00_INSERT_APOLICOR_DB_INSERT_1_Insert1.Execute(r6200_00_INSERT_APOLICOR_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R6200_99_SAIDA*/

        [StopWatch]
        /*" R8000-00-CANCELA-BILHETE-SECTION */
        private void R8000_00_CANCELA_BILHETE_SECTION()
        {
            /*" -5178- MOVE '8000' TO WNR-EXEC-SQL. */
            _.Move("8000", AUX_RELATORIO.WABEND.WNR_EXEC_SQL);

            /*" -5180- ADD 1 TO AC-ERRO. */
            W.AC_ERRO.Value = W.AC_ERRO + 1;

            /*" -5183- MOVE 'BILHETE CANCELADO A PEDIDO DA BU        ' TO LD01-MENSAGEM. */
            _.Move("BILHETE CANCELADO A PEDIDO DA BU        ", AUX_RELATORIO.LD01.LD01_MENSAGEM);

            /*" -5189- PERFORM R9000-00-GRAVA-ARQUIVO. */

            R9000_00_GRAVA_ARQUIVO_SECTION();

            /*" -5192- MOVE '8' TO BILHETE-SITUACAO. */
            _.Move("8", BILHETE.DCLBILHETE.BILHETE_SITUACAO);

            /*" -5199- PERFORM R8500-00-UPDATE-V0BILHETE. */

            R8500_00_UPDATE_V0BILHETE_SECTION();

            /*" -5202- MOVE '4' TO MOVIMCOB-SIT-REGISTRO. */
            _.Move("4", MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_SIT_REGISTRO);

            /*" -5202- PERFORM R8900-00-UPDATE-V0MOVICOB. */

            R8900_00_UPDATE_V0MOVICOB_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8000_99_SAIDA*/

        [StopWatch]
        /*" R8500-00-UPDATE-V0BILHETE-SECTION */
        private void R8500_00_UPDATE_V0BILHETE_SECTION()
        {
            /*" -5215- MOVE '8500' TO WNR-EXEC-SQL. */
            _.Move("8500", AUX_RELATORIO.WABEND.WNR_EXEC_SQL);

            /*" -5224- PERFORM R8500_00_UPDATE_V0BILHETE_DB_UPDATE_1 */

            R8500_00_UPDATE_V0BILHETE_DB_UPDATE_1();

            /*" -5227- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5228- DISPLAY 'R8500-00 - PROBLEMAS UPDATE (V0BILHETE)   ' */
                _.Display($"R8500-00 - PROBLEMAS UPDATE (V0BILHETE)   ");

                /*" -5229- DISPLAY 'NUM-NOSSO-TITULO= ' MOVIMCOB-NUM-NOSSO-TITULO */
                _.Display($"NUM-NOSSO-TITULO= {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_NOSSO_TITULO}");

                /*" -5230- DISPLAY 'NUM-BILHETE     = ' BILHETE-NUM-BILHETE */
                _.Display($"NUM-BILHETE     = {BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE}");

                /*" -5232- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -5232- ADD 1 TO UP-BILHETE. */
            W.UP_BILHETE.Value = W.UP_BILHETE + 1;

        }

        [StopWatch]
        /*" R8500-00-UPDATE-V0BILHETE-DB-UPDATE-1 */
        public void R8500_00_UPDATE_V0BILHETE_DB_UPDATE_1()
        {
            /*" -5224- EXEC SQL UPDATE SEGUROS.BILHETE SET NUM_APOLICE = :BILHETE-NUM-APOLICE , FONTE = :BILHETE-FONTE , DATA_QUITACAO = :BILHETE-DATA-QUITACAO , SITUACAO = :BILHETE-SITUACAO , COD_USUARIO = 'BI6252B' WHERE NUM_BILHETE = :BILHETE-NUM-BILHETE END-EXEC. */

            var r8500_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1 = new R8500_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1()
            {
                BILHETE_DATA_QUITACAO = BILHETE.DCLBILHETE.BILHETE_DATA_QUITACAO.ToString(),
                BILHETE_NUM_APOLICE = BILHETE.DCLBILHETE.BILHETE_NUM_APOLICE.ToString(),
                BILHETE_SITUACAO = BILHETE.DCLBILHETE.BILHETE_SITUACAO.ToString(),
                BILHETE_FONTE = BILHETE.DCLBILHETE.BILHETE_FONTE.ToString(),
                BILHETE_NUM_BILHETE = BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE.ToString(),
            };

            R8500_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1.Execute(r8500_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8500_99_SAIDA*/

        [StopWatch]
        /*" R8900-00-UPDATE-V0MOVICOB-SECTION */
        private void R8900_00_UPDATE_V0MOVICOB_SECTION()
        {
            /*" -5245- MOVE '8900' TO WNR-EXEC-SQL. */
            _.Move("8900", AUX_RELATORIO.WABEND.WNR_EXEC_SQL);

            /*" -5252- PERFORM R8900_00_UPDATE_V0MOVICOB_DB_UPDATE_1 */

            R8900_00_UPDATE_V0MOVICOB_DB_UPDATE_1();

            /*" -5255- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5256- DISPLAY 'R8900-00 - PROBLEMAS UPDATE (V0MOVICOB)   ' */
                _.Display($"R8900-00 - PROBLEMAS UPDATE (V0MOVICOB)   ");

                /*" -5257- DISPLAY 'SIT-REGISTRO    = ' MOVIMCOB-SIT-REGISTRO */
                _.Display($"SIT-REGISTRO    = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_SIT_REGISTRO}");

                /*" -5258- DISPLAY 'COD-BANCO       = ' MOVIMCOB-COD-BANCO */
                _.Display($"COD-BANCO       = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_BANCO}");

                /*" -5259- DISPLAY 'COD-AGENCIA     = ' MOVIMCOB-COD-AGENCIA */
                _.Display($"COD-AGENCIA     = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_AGENCIA}");

                /*" -5260- DISPLAY 'NUM-AVISO       = ' MOVIMCOB-NUM-AVISO */
                _.Display($"NUM-AVISO       = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_AVISO}");

                /*" -5261- DISPLAY 'NUM-FITA        = ' MOVIMCOB-NUM-FITA */
                _.Display($"NUM-FITA        = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_FITA}");

                /*" -5262- DISPLAY 'NUM-NOSSO-TITULO= ' MOVIMCOB-NUM-NOSSO-TITULO */
                _.Display($"NUM-NOSSO-TITULO= {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_NOSSO_TITULO}");

                /*" -5263- DISPLAY 'NUM-APOLICE     = ' MOVIMCOB-NUM-APOLICE */
                _.Display($"NUM-APOLICE     = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_APOLICE}");

                /*" -5264- DISPLAY 'NUM-ENDOSSO     = ' MOVIMCOB-NUM-ENDOSSO */
                _.Display($"NUM-ENDOSSO     = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_ENDOSSO}");

                /*" -5265- DISPLAY 'NUM-PARCELA     = ' MOVIMCOB-NUM-PARCELA */
                _.Display($"NUM-PARCELA     = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_PARCELA}");

                /*" -5266- DISPLAY 'COD-MOVIMENTO   = ' MOVIMCOB-COD-MOVIMENTO */
                _.Display($"COD-MOVIMENTO   = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_MOVIMENTO}");

                /*" -5267- DISPLAY 'NOME-SEGURADO   = ' MOVIMCOB-NOME-SEGURADO */
                _.Display($"NOME-SEGURADO   = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NOME_SEGURADO}");

                /*" -5269- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -5269- ADD 1 TO UP-PROPOSTA. */
            W.UP_PROPOSTA.Value = W.UP_PROPOSTA + 1;

        }

        [StopWatch]
        /*" R8900-00-UPDATE-V0MOVICOB-DB-UPDATE-1 */
        public void R8900_00_UPDATE_V0MOVICOB_DB_UPDATE_1()
        {
            /*" -5252- EXEC SQL UPDATE SEGUROS.MOVIMENTO_COBRANCA SET NUM_TITULO = :MOVIMCOB-NUM-TITULO , NUM_APOLICE = :MOVIMCOB-NUM-APOLICE , SIT_REGISTRO = :MOVIMCOB-SIT-REGISTRO WHERE CURRENT OF V0MOVIMCOB END-EXEC. */

            var r8900_00_UPDATE_V0MOVICOB_DB_UPDATE_1_Update1 = new R8900_00_UPDATE_V0MOVICOB_DB_UPDATE_1_Update1(V0MOVIMCOB)
            {
                MOVIMCOB_SIT_REGISTRO = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_SIT_REGISTRO.ToString(),
                MOVIMCOB_NUM_APOLICE = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_APOLICE.ToString(),
                MOVIMCOB_NUM_TITULO = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_TITULO.ToString(),
            };

            R8900_00_UPDATE_V0MOVICOB_DB_UPDATE_1_Update1.Execute(r8900_00_UPDATE_V0MOVICOB_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8900_99_SAIDA*/

        [StopWatch]
        /*" R9000-00-GRAVA-ARQUIVO-SECTION */
        private void R9000_00_GRAVA_ARQUIVO_SECTION()
        {
            /*" -5282- MOVE '9000' TO WNR-EXEC-SQL. */
            _.Move("9000", AUX_RELATORIO.WABEND.WNR_EXEC_SQL);

            /*" -5284- MOVE MOVIMCOB-NUM-AVISO TO LD01-CONVENIO. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_AVISO, AUX_RELATORIO.LD01.LD01_CONVENIO);

            /*" -5286- MOVE MOVIMCOB-NUM-NOSSO-TITULO TO LD01-PROPOSTA. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_NOSSO_TITULO, AUX_RELATORIO.LD01.LD01_PROPOSTA);

            /*" -5288- MOVE MOVIMCOB-NUM-TITULO TO LD01-BILHETE. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_TITULO, AUX_RELATORIO.LD01.LD01_BILHETE);

            /*" -5290- MOVE MOVIMCOB-NUM-FITA TO LD01-NSAS. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_FITA, AUX_RELATORIO.LD01.LD01_NSAS);

            /*" -5292- MOVE MOVIMCOB-VAL-TITULO TO LD01-VALOR. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_VAL_TITULO, AUX_RELATORIO.LD01.LD01_VALOR);

            /*" -5294- MOVE MOVIMCOB-NUM-APOLICE TO LD01-APOLICE. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_APOLICE, AUX_RELATORIO.LD01.LD01_APOLICE);

            /*" -5296- MOVE MOVIMCOB-NUM-ENDOSSO TO LD01-ENDOSSO. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_ENDOSSO, AUX_RELATORIO.LD01.LD01_ENDOSSO);

            /*" -5298- MOVE MOVIMCOB-NUM-PARCELA TO LD01-PARCELA. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_PARCELA, AUX_RELATORIO.LD01.LD01_PARCELA);

            /*" -5300- MOVE CONVERSI-COD-PRODUTO-SIVPF TO LD01-CODPRODU. */
            _.Move(CONVERSI.DCLCONVERSAO_SICOB.CONVERSI_COD_PRODUTO_SIVPF, AUX_RELATORIO.LD01.LD01_CODPRODU);

            /*" -5303- MOVE BILHETE-OPC-COBERTURA TO LD01-OPCAO. */
            _.Move(BILHETE.DCLBILHETE.BILHETE_OPC_COBERTURA, AUX_RELATORIO.LD01.LD01_OPCAO);

            /*" -5305- MOVE MOVIMCOB-DATA-MOVIMENTO TO WDATA-REL */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_DATA_MOVIMENTO, W.WDATA_REL);

            /*" -5306- MOVE WDAT-REL-DIA TO WDATA-DD-CABEC */
            _.Move(W.FILLER_1.WDAT_REL_DIA, W.WDATA_CABEC.WDATA_DD_CABEC);

            /*" -5307- MOVE WDAT-REL-MES TO WDATA-MM-CABEC */
            _.Move(W.FILLER_1.WDAT_REL_MES, W.WDATA_CABEC.WDATA_MM_CABEC);

            /*" -5308- MOVE WDAT-REL-ANO TO WDATA-AA-CABEC */
            _.Move(W.FILLER_1.WDAT_REL_ANO, W.WDATA_CABEC.WDATA_AA_CABEC);

            /*" -5310- MOVE WDATA-CABEC TO LD01-DTPAGTO. */
            _.Move(W.WDATA_CABEC, AUX_RELATORIO.LD01.LD01_DTPAGTO);

            /*" -5312- MOVE MOVIMCOB-DATA-QUITACAO TO WDATA-REL */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_DATA_QUITACAO, W.WDATA_REL);

            /*" -5313- MOVE WDAT-REL-DIA TO WDATA-DD-CABEC */
            _.Move(W.FILLER_1.WDAT_REL_DIA, W.WDATA_CABEC.WDATA_DD_CABEC);

            /*" -5314- MOVE WDAT-REL-MES TO WDATA-MM-CABEC */
            _.Move(W.FILLER_1.WDAT_REL_MES, W.WDATA_CABEC.WDATA_MM_CABEC);

            /*" -5315- MOVE WDAT-REL-ANO TO WDATA-AA-CABEC */
            _.Move(W.FILLER_1.WDAT_REL_ANO, W.WDATA_CABEC.WDATA_AA_CABEC);

            /*" -5318- MOVE WDATA-CABEC TO LD01-DTCREDITO. */
            _.Move(W.WDATA_CABEC, AUX_RELATORIO.LD01.LD01_DTCREDITO);

            /*" -5319- WRITE REG-BI6252B FROM LD01. */
            _.Move(AUX_RELATORIO.LD01.GetMoveValues(), REG_BI6252B);

            BI6252B1.Write(REG_BI6252B.GetMoveValues().ToString());

            /*" -5319- ADD 1 TO GV-SAIDA. */
            W.GV_SAIDA.Value = W.GV_SAIDA + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9000_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -5330- MOVE SQLCODE TO WSQLCODE */
            _.Move(DB.SQLCODE, AUX_RELATORIO.WABEND.WSQLCODE);

            /*" -5331- MOVE SQLERRD(1) TO WSQLERRD1 */
            _.Move(DB.SQLERRD[1], AUX_RELATORIO.WABEND.WSQLERRD1);

            /*" -5332- MOVE SQLERRD(2) TO WSQLERRD2 */
            _.Move(DB.SQLERRD[2], AUX_RELATORIO.WABEND.WSQLERRD2);

            /*" -5333- MOVE SQLERRMC TO WSQLERRMC */
            _.Move(DB.SQLERRMC, AUX_RELATORIO.WABEND.WSQLERRO.WSQLERRMC);

            /*" -5335- DISPLAY WABEND. */
            _.Display(AUX_RELATORIO.WABEND);

            /*" -5337- DISPLAY LD99-ABEND. */
            _.Display(LD99_ABEND);

            /*" -5337- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -5341- CLOSE BI6252B1. */
            BI6252B1.Close();

            /*" -5344- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -5344- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}