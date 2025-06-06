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
using Sias.Sinistro.DB2.SI0007B;

namespace Code
{
    public class SI0007B
    {
        public bool IsCall { get; set; }

        public SI0007B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  SINISTRO / LOTERICO                *      */
        /*"      *   PROGRAMA ...............  SI0007B                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  MAURICIO LINKE - CONTRASTE         *      */
        /*"      *   PROGRAMADOR ............  MAURICIO LINKE - CONTRASTE         *      */
        /*"      *   DATA CODIFICACAO .......  JANEIRO / 2005.                    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO ....... PROGRAMA PARA EMISSAO, EM MEIO MAGNETICO E C/ *      */
        /*"      *                  FORMATO TXT, DE RELATORIO DIARIO DE ACOMPANHA-*      */
        /*"      *                  MENTO DE SINISTROS AVISADOS. BATCH            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ALTERACAO .... INCLUIR COD_PRODUTO 1805 CCA. CADMUS 95992    *      */
        /*"      *                  DAIRO LOPES  01/04/2014            V.01       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        #endregion


        #region VARIABLES

        public FileBasis _RAVISO { get; set; } = new FileBasis(new PIC("X", "264", "X(264)"));

        public FileBasis RAVISO
        {
            get
            {
                _.Move(REGISTRO_AVISADOS, _RAVISO); VarBasis.RedefinePassValue(REGISTRO_AVISADOS, _RAVISO, REGISTRO_AVISADOS); return _RAVISO;
            }
        }
        /*"01  REGISTRO-AVISADOS.*/
        public SI0007B_REGISTRO_AVISADOS REGISTRO_AVISADOS { get; set; } = new SI0007B_REGISTRO_AVISADOS();
        public class SI0007B_REGISTRO_AVISADOS : VarBasis
        {
            /*"    05 RA-NUM-APOLICE                 PIC  9(13).*/
            public IntBasis RA_NUM_APOLICE { get; set; } = new IntBasis(new PIC("9", "13", "9(13)."));
            /*"    05 RA-PV1                         PIC  X(01).*/
            public StringBasis RA_PV1 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    05 RA-COD-PRODUTO                 PIC  9(04).*/
            public IntBasis RA_COD_PRODUTO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
            /*"    05 RA-PV1A                        PIC  X(01).*/
            public StringBasis RA_PV1A { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    05 RA-COD-LOT-CEF                 PIC  X(13).*/
            public StringBasis RA_COD_LOT_CEF { get; set; } = new StringBasis(new PIC("X", "13", "X(13)."), @"");
            /*"    05 RA-PV2                         PIC  X(01).*/
            public StringBasis RA_PV2 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    05 RA-NOME-RAZAO                  PIC  X(40).*/
            public StringBasis RA_NOME_RAZAO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
            /*"    05 RA-PV3                         PIC  X(01).*/
            public StringBasis RA_PV3 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    05 RA-ENDERECO                    PIC  X(40).*/
            public StringBasis RA_ENDERECO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
            /*"    05 RA-PV4                         PIC  X(01).*/
            public StringBasis RA_PV4 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    05 RA-SIGLA-UF                    PIC  X(02).*/
            public StringBasis RA_SIGLA_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(02)."), @"");
            /*"    05 RA-PV5                         PIC  X(01).*/
            public StringBasis RA_PV5 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    05 RA-NUM-APOL-SINISTRO           PIC  9(13).*/
            public IntBasis RA_NUM_APOL_SINISTRO { get; set; } = new IntBasis(new PIC("9", "13", "9(13)."));
            /*"    05 RA-PV6                         PIC  X(01).*/
            public StringBasis RA_PV6 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    05 RA-DATA-OCORRENCIA             PIC  X(10).*/
            public StringBasis RA_DATA_OCORRENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"    05 RA-PV7                         PIC  X(01).*/
            public StringBasis RA_PV7 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    05 RA-DATA-MOV-ABERTO             PIC  X(10).*/
            public StringBasis RA_DATA_MOV_ABERTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"    05 RA-PV8                         PIC  X(01).*/
            public StringBasis RA_PV8 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    05 RA-DATA-MOVIMENTO              PIC  X(10).*/
            public StringBasis RA_DATA_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"    05 RA-PV9                         PIC  X(01).*/
            public StringBasis RA_PV9 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    05 RA-VAL-OPERACAO                PIC  9(13)V99.*/
            public DoubleBasis RA_VAL_OPERACAO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(13)V99."), 2);
            /*"    05 RA-PV10                        PIC  X(01).*/
            public StringBasis RA_PV10 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    05 RA-VALOR-INFORMADO             PIC  9(13)V99.*/
            public DoubleBasis RA_VALOR_INFORMADO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(13)V99."), 2);
            /*"    05 RA-PV11                        PIC  X(01).*/
            public StringBasis RA_PV11 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    05 RA-DESCR-CAUSA                 PIC  X(40).*/
            public StringBasis RA_DESCR_CAUSA { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
            /*"    05 RA-PV12                        PIC  X(01).*/
            public StringBasis RA_PV12 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    05 RA-DATA-COMUNICADO             PIC  X(10).*/
            public StringBasis RA_DATA_COMUNICADO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"    05 RA-PV13                        PIC  X(01).*/
            public StringBasis RA_PV13 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    05 RA-QTD-PORTADORES              PIC  9(02).*/
            public IntBasis RA_QTD_PORTADORES { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
            /*"    05 RA-PV14                        PIC  X(01).*/
            public StringBasis RA_PV14 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    05 RA-IND-ADIANTAMENTO            PIC  X(01).*/
            public StringBasis RA_IND_ADIANTAMENTO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    05 RA-PV15                        PIC  X(01).*/
            public StringBasis RA_PV15 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"01  TITULO-RELATORIO.*/
        }
        public SI0007B_TITULO_RELATORIO TITULO_RELATORIO { get; set; } = new SI0007B_TITULO_RELATORIO();
        public class SI0007B_TITULO_RELATORIO : VarBasis
        {
            /*"    05 TR-TITULO1                     PIC  X(10).*/
            public StringBasis TR_TITULO1 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"    05 TR-PV1                         PIC  X(01).*/
            public StringBasis TR_PV1 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    05 TR-TITULO2                     PIC  X(25).*/
            public StringBasis TR_TITULO2 { get; set; } = new StringBasis(new PIC("X", "25", "X(25)."), @"");
            /*"    05 TR-PV2                         PIC  X(01).*/
            public StringBasis TR_PV2 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    05 TR-TITULO3                     PIC  X(14).*/
            public StringBasis TR_TITULO3 { get; set; } = new StringBasis(new PIC("X", "14", "X(14)."), @"");
            /*"    05 TR-PV3                         PIC  X(01).*/
            public StringBasis TR_PV3 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    05 TR-TITULO4                     PIC  X(08).*/
            public StringBasis TR_TITULO4 { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
            /*"    05 TR-PV4                         PIC  X(01).*/
            public StringBasis TR_PV4 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    05 TR-TITULO5                     PIC  X(02).*/
            public StringBasis TR_TITULO5 { get; set; } = new StringBasis(new PIC("X", "2", "X(02)."), @"");
            /*"    05 TR-PV5                         PIC  X(01).*/
            public StringBasis TR_PV5 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    05 TR-TITULO6                     PIC  X(21).*/
            public StringBasis TR_TITULO6 { get; set; } = new StringBasis(new PIC("X", "21", "X(21)."), @"");
            /*"    05 TR-PV6                         PIC  X(01).*/
            public StringBasis TR_PV6 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    05 TR-DATA-PROCESSAMENTO          PIC  X(15).*/
            public StringBasis TR_DATA_PROCESSAMENTO { get; set; } = new StringBasis(new PIC("X", "15", "X(15)."), @"");
            /*"    05 TR-PV7                         PIC  X(01).*/
            public StringBasis TR_PV7 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    05 TR-TITULO7                     PIC  X(13).*/
            public StringBasis TR_TITULO7 { get; set; } = new StringBasis(new PIC("X", "13", "X(13)."), @"");
            /*"    05 TR-PV8                         PIC  X(01).*/
            public StringBasis TR_PV8 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    05 TR-DATA-PESQUISA               PIC  X(17).*/
            public StringBasis TR_DATA_PESQUISA { get; set; } = new StringBasis(new PIC("X", "17", "X(17)."), @"");
            /*"    05 TR-PV9                         PIC  X(01).*/
            public StringBasis TR_PV9 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    05 TR-FILLER1                     PIC  X(18).*/
            public StringBasis TR_FILLER1 { get; set; } = new StringBasis(new PIC("X", "18", "X(18)."), @"");
            /*"    05 TR-PV10                        PIC  X(01).*/
            public StringBasis TR_PV10 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    05 TR-FILLER2                     PIC  X(17).*/
            public StringBasis TR_FILLER2 { get; set; } = new StringBasis(new PIC("X", "17", "X(17)."), @"");
            /*"    05 TR-PV11                        PIC  X(01).*/
            public StringBasis TR_PV11 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    05 TR-FILLER3                     PIC  X(15).*/
            public StringBasis TR_FILLER3 { get; set; } = new StringBasis(new PIC("X", "15", "X(15)."), @"");
            /*"    05 TR-PV12                        PIC  X(01).*/
            public StringBasis TR_PV12 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    05 TR-FILLER4                     PIC  X(15).*/
            public StringBasis TR_FILLER4 { get; set; } = new StringBasis(new PIC("X", "15", "X(15)."), @"");
            /*"    05 TR-PV13                        PIC  X(01).*/
            public StringBasis TR_PV13 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    05 TR-FILLER5                     PIC  X(21).*/
            public StringBasis TR_FILLER5 { get; set; } = new StringBasis(new PIC("X", "21", "X(21)."), @"");
            /*"    05 TR-PV14                        PIC  X(01).*/
            public StringBasis TR_PV14 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    05 TR-FILLER6                     PIC  X(23).*/
            public StringBasis TR_FILLER6 { get; set; } = new StringBasis(new PIC("X", "23", "X(23)."), @"");
            /*"    05 TR-PV15                        PIC  X(01).*/
            public StringBasis TR_PV15 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"01  CABECALHO-AVISADOS.*/
        }
        public SI0007B_CABECALHO_AVISADOS CABECALHO_AVISADOS { get; set; } = new SI0007B_CABECALHO_AVISADOS();
        public class SI0007B_CABECALHO_AVISADOS : VarBasis
        {
            /*"    05 CA-NUMERO-APOLICE              PIC  X(14).*/
            public StringBasis CA_NUMERO_APOLICE { get; set; } = new StringBasis(new PIC("X", "14", "X(14)."), @"");
            /*"    05 CA-PV1                         PIC  X(01).*/
            public StringBasis CA_PV1 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    05 CA-CODIGO-PRODUTO              PIC  X(14).*/
            public StringBasis CA_CODIGO_PRODUTO { get; set; } = new StringBasis(new PIC("X", "14", "X(14)."), @"");
            /*"    05 CA-PV1A                        PIC  X(01).*/
            public StringBasis CA_PV1A { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    05 CA-CODIGO-LOTERICO-CAIXA       PIC  X(21).*/
            public StringBasis CA_CODIGO_LOTERICO_CAIXA { get; set; } = new StringBasis(new PIC("X", "21", "X(21)."), @"");
            /*"    05 CA-PV2                         PIC  X(01).*/
            public StringBasis CA_PV2 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    05 CA-RAZAO-SOCIAL                PIC  X(12).*/
            public StringBasis CA_RAZAO_SOCIAL { get; set; } = new StringBasis(new PIC("X", "12", "X(12)."), @"");
            /*"    05 CA-PV3                         PIC  X(01).*/
            public StringBasis CA_PV3 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    05 CA-ENDERECO                    PIC  X(08).*/
            public StringBasis CA_ENDERECO { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
            /*"    05 CA-PV4                         PIC  X(01).*/
            public StringBasis CA_PV4 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    05 CA-UF                          PIC  X(02).*/
            public StringBasis CA_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(02)."), @"");
            /*"    05 CA-PV5                         PIC  X(01).*/
            public StringBasis CA_PV5 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    05 CA-NUMERO-APOLICE-SINISTRO     PIC  X(23).*/
            public StringBasis CA_NUMERO_APOLICE_SINISTRO { get; set; } = new StringBasis(new PIC("X", "23", "X(23)."), @"");
            /*"    05 CA-PV6                         PIC  X(01).*/
            public StringBasis CA_PV6 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    05 CA-DATA-OCORRENCIA             PIC  X(15).*/
            public StringBasis CA_DATA_OCORRENCIA { get; set; } = new StringBasis(new PIC("X", "15", "X(15)."), @"");
            /*"    05 CA-PV7                         PIC  X(01).*/
            public StringBasis CA_PV7 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    05 CA-DATA-CADASTRO               PIC  X(13).*/
            public StringBasis CA_DATA_CADASTRO { get; set; } = new StringBasis(new PIC("X", "13", "X(13)."), @"");
            /*"    05 CA-PV8                         PIC  X(01).*/
            public StringBasis CA_PV8 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    05 CA-DATA-ADIANTAMENTO           PIC  X(17).*/
            public StringBasis CA_DATA_ADIANTAMENTO { get; set; } = new StringBasis(new PIC("X", "17", "X(17)."), @"");
            /*"    05 CA-PV9                         PIC  X(01).*/
            public StringBasis CA_PV9 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    05 CA-VALOR-ADIANTAMENTO          PIC  X(18).*/
            public StringBasis CA_VALOR_ADIANTAMENTO { get; set; } = new StringBasis(new PIC("X", "18", "X(18)."), @"");
            /*"    05 CA-PV10                        PIC  X(01).*/
            public StringBasis CA_PV10 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    05 CA-VALOR-AVISO                 PIC  X(17).*/
            public StringBasis CA_VALOR_AVISO { get; set; } = new StringBasis(new PIC("X", "17", "X(17)."), @"");
            /*"    05 CA-PV11                        PIC  X(01).*/
            public StringBasis CA_PV11 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    05 CA-DESCRICAO-CAUSA             PIC  X(15).*/
            public StringBasis CA_DESCRICAO_CAUSA { get; set; } = new StringBasis(new PIC("X", "15", "X(15)."), @"");
            /*"    05 CA-PV12                        PIC  X(01).*/
            public StringBasis CA_PV12 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    05 CA-DATA-COMUNICADO             PIC  X(15).*/
            public StringBasis CA_DATA_COMUNICADO { get; set; } = new StringBasis(new PIC("X", "15", "X(15)."), @"");
            /*"    05 CA-PV13                        PIC  X(01).*/
            public StringBasis CA_PV13 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    05 CA-QUANTIDADE-PORTADORES       PIC  X(21).*/
            public StringBasis CA_QUANTIDADE_PORTADORES { get; set; } = new StringBasis(new PIC("X", "21", "X(21)."), @"");
            /*"    05 CA-PV14                        PIC  X(01).*/
            public StringBasis CA_PV14 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    05 CA-INDICATIVO-ADIANTAMENTO     PIC  X(23).*/
            public StringBasis CA_INDICATIVO_ADIANTAMENTO { get; set; } = new StringBasis(new PIC("X", "23", "X(23)."), @"");
            /*"    05 CA-PV15                        PIC  X(01).*/
            public StringBasis CA_PV15 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"01  TOTAL-AVISADOS.*/
        }
        public SI0007B_TOTAL_AVISADOS TOTAL_AVISADOS { get; set; } = new SI0007B_TOTAL_AVISADOS();
        public class SI0007B_TOTAL_AVISADOS : VarBasis
        {
            /*"    05 TA-TOTAL-AVISADOS              PIC  X(14).*/
            public StringBasis TA_TOTAL_AVISADOS { get; set; } = new StringBasis(new PIC("X", "14", "X(14)."), @"");
            /*"    05 TA-PV1                         PIC  X(01).*/
            public StringBasis TA_PV1 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    05 TA-TOTAL-REG                   PIC  X(21).*/
            public StringBasis TA_TOTAL_REG { get; set; } = new StringBasis(new PIC("X", "21", "X(21)."), @"");
            /*"    05 TA-PV2                         PIC  X(01).*/
            public StringBasis TA_PV2 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    05 TA-FILLER1                     PIC  X(12).*/
            public StringBasis TA_FILLER1 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)."), @"");
            /*"    05 TA-PV3                         PIC  X(01).*/
            public StringBasis TA_PV3 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    05 TA-FILLER2                     PIC  X(08).*/
            public StringBasis TA_FILLER2 { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
            /*"    05 TA-PV4                         PIC  X(01).*/
            public StringBasis TA_PV4 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    05 TA-FILLER3                     PIC  X(02).*/
            public StringBasis TA_FILLER3 { get; set; } = new StringBasis(new PIC("X", "2", "X(02)."), @"");
            /*"    05 TA-PV5                         PIC  X(01).*/
            public StringBasis TA_PV5 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    05 TA-FILLER4                     PIC  X(23).*/
            public StringBasis TA_FILLER4 { get; set; } = new StringBasis(new PIC("X", "23", "X(23)."), @"");
            /*"    05 TA-PV6                         PIC  X(01).*/
            public StringBasis TA_PV6 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    05 TA-FILLER5                     PIC  X(15).*/
            public StringBasis TA_FILLER5 { get; set; } = new StringBasis(new PIC("X", "15", "X(15)."), @"");
            /*"    05 TA-PV7                         PIC  X(01).*/
            public StringBasis TA_PV7 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    05 TA-FILLER6                     PIC  X(13).*/
            public StringBasis TA_FILLER6 { get; set; } = new StringBasis(new PIC("X", "13", "X(13)."), @"");
            /*"    05 TA-PV8                         PIC  X(01).*/
            public StringBasis TA_PV8 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    05 TA-FILLER7                     PIC  X(17).*/
            public StringBasis TA_FILLER7 { get; set; } = new StringBasis(new PIC("X", "17", "X(17)."), @"");
            /*"    05 TA-PV9                         PIC  X(01).*/
            public StringBasis TA_PV9 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    05 TA-FILLER8                     PIC  X(18).*/
            public StringBasis TA_FILLER8 { get; set; } = new StringBasis(new PIC("X", "18", "X(18)."), @"");
            /*"    05 TA-PV10                        PIC  X(01).*/
            public StringBasis TA_PV10 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    05 TA-FILLER9                     PIC  X(17).*/
            public StringBasis TA_FILLER9 { get; set; } = new StringBasis(new PIC("X", "17", "X(17)."), @"");
            /*"    05 TA-PV11                        PIC  X(01).*/
            public StringBasis TA_PV11 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    05 TA-FILLER10                    PIC  X(15).*/
            public StringBasis TA_FILLER10 { get; set; } = new StringBasis(new PIC("X", "15", "X(15)."), @"");
            /*"    05 TA-PV12                        PIC  X(01).*/
            public StringBasis TA_PV12 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    05 TA-FILLER11                    PIC  X(15).*/
            public StringBasis TA_FILLER11 { get; set; } = new StringBasis(new PIC("X", "15", "X(15)."), @"");
            /*"    05 TA-PV13                        PIC  X(01).*/
            public StringBasis TA_PV13 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    05 TA-FILLER12                    PIC  X(21).*/
            public StringBasis TA_FILLER12 { get; set; } = new StringBasis(new PIC("X", "21", "X(21)."), @"");
            /*"    05 TA-PV14                        PIC  X(01).*/
            public StringBasis TA_PV14 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    05 TA-FILLER13                    PIC  X(23).*/
            public StringBasis TA_FILLER13 { get; set; } = new StringBasis(new PIC("X", "23", "X(23)."), @"");
            /*"    05 TA-PV15                        PIC  X(01).*/
            public StringBasis TA_PV15 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        }

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77  HOST-COUNT                     PIC S9(09) COMP VALUE +0.*/
        public IntBasis HOST_COUNT { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"01          AREAS-DE-WORK.*/
        public SI0007B_AREAS_DE_WORK AREAS_DE_WORK { get; set; } = new SI0007B_AREAS_DE_WORK();
        public class SI0007B_AREAS_DE_WORK : VarBasis
        {
            /*"    05 W-TEM-ADIANTAMENTO          PIC X(03)   VALUE 'SIM'.*/
            public StringBasis W_TEM_ADIANTAMENTO { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"SIM");
            /*"    05 W-FIM-AVISOS                PIC X(03)   VALUE 'NAO'.*/
            public StringBasis W_FIM_AVISOS { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"NAO");
            /*"    05 W-TOTAL-REG                 PIC 9(09)   VALUE ZEROS.*/
            public IntBasis W_TOTAL_REG { get; set; } = new IntBasis(new PIC("9", "9", "9(09)"));
            /*"    05 W-DATA-PESQUISA             PIC X(10)   VALUE SPACES.*/
            public StringBasis W_DATA_PESQUISA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
            /*"    05 W-DATA-SISTEMA.*/
            public SI0007B_W_DATA_SISTEMA W_DATA_SISTEMA { get; set; } = new SI0007B_W_DATA_SISTEMA();
            public class SI0007B_W_DATA_SISTEMA : VarBasis
            {
                /*"       07 W-ANO-SISTEMA            PIC 9(04)   VALUE ZEROS.*/
                public IntBasis W_ANO_SISTEMA { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
                /*"       07 W-MES-SISTEMA            PIC 9(02)   VALUE ZEROS.*/
                public IntBasis W_MES_SISTEMA { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"       07 W-DIA-SISTEMA            PIC 9(02)   VALUE ZEROS.*/
                public IntBasis W_DIA_SISTEMA { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"    05 W-DATA-DD-MM-AAAA.*/
            }
            public SI0007B_W_DATA_DD_MM_AAAA W_DATA_DD_MM_AAAA { get; set; } = new SI0007B_W_DATA_DD_MM_AAAA();
            public class SI0007B_W_DATA_DD_MM_AAAA : VarBasis
            {
                /*"       10 W-DATA-DD-MM-AAAA-DD     PIC 9(02)   VALUE ZEROS.*/
                public IntBasis W_DATA_DD_MM_AAAA_DD { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"       10 W-BARRA1                 PIC X(01)   VALUE '/'.*/
                public StringBasis W_BARRA1 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"/");
                /*"       10 W-DATA-DD-MM-AAAA-MM     PIC 9(02)   VALUE ZEROS.*/
                public IntBasis W_DATA_DD_MM_AAAA_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"       10 W-BARRA2                 PIC X(01)   VALUE '/'.*/
                public StringBasis W_BARRA2 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"/");
                /*"       10 W-DATA-DD-MM-AAAA-AAAA   PIC 9(04)   VALUE ZEROS.*/
                public IntBasis W_DATA_DD_MM_AAAA_AAAA { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
                /*"    05 W-DATA-AAAA-MM-DD.*/
            }
            public SI0007B_W_DATA_AAAA_MM_DD W_DATA_AAAA_MM_DD { get; set; } = new SI0007B_W_DATA_AAAA_MM_DD();
            public class SI0007B_W_DATA_AAAA_MM_DD : VarBasis
            {
                /*"       10 W-DATA-AAAA-MM-DD-AAAA   PIC 9(04)   VALUE ZEROS.*/
                public IntBasis W_DATA_AAAA_MM_DD_AAAA { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
                /*"       10 W-HIFEN1                 PIC X(01)   VALUE '-'.*/
                public StringBasis W_HIFEN1 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
                /*"       10 W-DATA-AAAA-MM-DD-MM     PIC 9(02)   VALUE ZEROS.*/
                public IntBasis W_DATA_AAAA_MM_DD_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"       10 W-HIFEN2                 PIC X(01)   VALUE '-'.*/
                public StringBasis W_HIFEN2 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
                /*"       10 W-DATA-AAAA-MM-DD-DD     PIC 9(02)   VALUE ZEROS.*/
                public IntBasis W_DATA_AAAA_MM_DD_DD { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"    05 WABEND.*/
            }
            public SI0007B_WABEND WABEND { get; set; } = new SI0007B_WABEND();
            public class SI0007B_WABEND : VarBasis
            {
                /*"       07 WABEND1.*/
                public SI0007B_WABEND1 WABEND1 { get; set; } = new SI0007B_WABEND1();
                public class SI0007B_WABEND1 : VarBasis
                {
                    /*"       10 FILLER                   PIC  X(08) VALUE  'SI0007B'.*/
                    public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"SI0007B");
                    /*"       07 WABEND2.*/
                    public SI0007B_WABEND2 WABEND2 { get; set; } = new SI0007B_WABEND2();
                    public class SI0007B_WABEND2 : VarBasis
                    {
                        /*"       10 FILLER                   PIC  X(25) VALUE          '*** ERRO EXEC SQL NUMERO '.*/
                        public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "25", "X(25)"), @"*** ERRO EXEC SQL NUMERO ");
                        /*"       10 WNR-EXEC-SQL             PIC  X(04) VALUE  '0000'.*/
                        public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(04)"), @"0000");
                        /*"       07 WABEND3.*/
                        public SI0007B_WABEND3 WABEND3 { get; set; } = new SI0007B_WABEND3();
                        public class SI0007B_WABEND3 : VarBasis
                        {
                            /*"       10 FILLER                   PIC  X(13) VALUE          ' *** SQLCODE '.*/
                            public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "13", "X(13)"), @" *** SQLCODE ");
                            /*"       10 WSQLCODE                 PIC  ZZZZZ999-  VALUE  ZEROS.*/
                            public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                        }
                    }
                }
            }
        }


        public Dclgens.SINISHIS SINISHIS { get; set; } = new Dclgens.SINISHIS();
        public Dclgens.SINILT01 SINILT01 { get; set; } = new Dclgens.SINILT01();
        public Dclgens.SINISMES SINISMES { get; set; } = new Dclgens.SINISMES();
        public Dclgens.LOTERI01 LOTERI01 { get; set; } = new Dclgens.LOTERI01();
        public Dclgens.CLIENTES CLIENTES { get; set; } = new Dclgens.CLIENTES();
        public Dclgens.SIMOLOT1 SIMOLOT1 { get; set; } = new Dclgens.SIMOLOT1();
        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.SINISCAU SINISCAU { get; set; } = new Dclgens.SINISCAU();
        public SI0007B_HIST_AVISOS HIST_AVISOS { get; set; } = new SI0007B_HIST_AVISOS();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string RAVISO_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                RAVISO.SetFile(RAVISO_FILE_NAME_P);

                /*" -0- FLUXCONTROL_PERFORM M-000-00-PRINCIPAL */

                M_000_00_PRINCIPAL();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { CodigoRetorno = RETURN_CODE.Value };
            return Result;
        }

        [StopWatch]
        /*" M-000-00-PRINCIPAL */
        private void M_000_00_PRINCIPAL(bool isPerform = false)
        {
            /*" -264- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -265- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -266- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -270- PERFORM 100-00-INICIALIZACOES THRU 100-99-EXIT. */

            M_100_00_INICIALIZACOES(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_100_99_EXIT*/


            /*" -272- PERFORM 200-00-PROCESSAMENTO THRU 200-99-EXIT. */

            M_200_00_PROCESSAMENTO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_200_99_EXIT*/


            /*" -274- PERFORM 300-00-FINALIZACOES THRU 300-99-EXIT. */

            M_300_00_FINALIZACOES(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_300_99_EXIT*/


            /*" -274- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" M-100-00-INICIALIZACOES */
        private void M_100_00_INICIALIZACOES(bool isPerform = false)
        {
            /*" -282- OPEN OUTPUT RAVISO. */
            RAVISO.Open(REGISTRO_AVISADOS);

            /*" -284- PERFORM 110-00-TAB-SISTEMAS THRU 110-99-EXIT. */

            M_110_00_TAB_SISTEMAS(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_110_99_EXIT*/


            /*" -286- PERFORM M-120-00-IMPRIME-TITULO-RELAT THRU 120-99-EXIT. */

            M_120_00_IMPRIME_TITULO_RELAT(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_120_99_EXIT*/


            /*" -286- PERFORM 130-00-IMPRIME-CABECALHO THRU 130-99-EXIT. */

            M_130_00_IMPRIME_CABECALHO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_130_99_EXIT*/


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_100_99_EXIT*/

        [StopWatch]
        /*" M-110-00-TAB-SISTEMAS */
        private void M_110_00_TAB_SISTEMAS(bool isPerform = false)
        {
            /*" -297- MOVE '001' TO WNR-EXEC-SQL. */
            _.Move("001", AREAS_DE_WORK.WABEND.WABEND1.WABEND2.WNR_EXEC_SQL);

            /*" -302- PERFORM M_110_00_TAB_SISTEMAS_DB_SELECT_1 */

            M_110_00_TAB_SISTEMAS_DB_SELECT_1();

            /*" -305- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -306- DISPLAY 'ERRO SELECT - SISTEMA SI NAO CADASTRADO' */
                _.Display($"ERRO SELECT - SISTEMA SI NAO CADASTRADO");

                /*" -306- GO TO 999-00-ROT-ERRO. */

                M_999_00_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-110-00-TAB-SISTEMAS-DB-SELECT-1 */
        public void M_110_00_TAB_SISTEMAS_DB_SELECT_1()
        {
            /*" -302- EXEC SQL SELECT DATA_MOV_ABERTO INTO :SISTEMAS-DATA-MOV-ABERTO FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'SI' END-EXEC. */

            var m_110_00_TAB_SISTEMAS_DB_SELECT_1_Query1 = new M_110_00_TAB_SISTEMAS_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = M_110_00_TAB_SISTEMAS_DB_SELECT_1_Query1.Execute(m_110_00_TAB_SISTEMAS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_110_99_EXIT*/

        [StopWatch]
        /*" M-120-00-IMPRIME-TITULO-RELAT */
        private void M_120_00_IMPRIME_TITULO_RELAT(bool isPerform = false)
        {
            /*" -317- INITIALIZE TITULO-RELATORIO. */
            _.Initialize(
                TITULO_RELATORIO
            );

            /*" -321- MOVE ';' TO TR-PV1 TR-PV2 TR-PV3 TR-PV4 TR-PV5 TR-PV6 TR-PV7 TR-PV8 TR-PV9 TR-PV10 TR-PV11 TR-PV12 TR-PV13 TR-PV14 TR-PV15. */
            _.Move(";", TITULO_RELATORIO.TR_PV1, TITULO_RELATORIO.TR_PV2, TITULO_RELATORIO.TR_PV3, TITULO_RELATORIO.TR_PV4, TITULO_RELATORIO.TR_PV5, TITULO_RELATORIO.TR_PV6, TITULO_RELATORIO.TR_PV7, TITULO_RELATORIO.TR_PV8, TITULO_RELATORIO.TR_PV9, TITULO_RELATORIO.TR_PV10, TITULO_RELATORIO.TR_PV11, TITULO_RELATORIO.TR_PV12, TITULO_RELATORIO.TR_PV13, TITULO_RELATORIO.TR_PV14, TITULO_RELATORIO.TR_PV15);

            /*" -322- MOVE 'RELATORIO' TO TR-TITULO1. */
            _.Move("RELATORIO", TITULO_RELATORIO.TR_TITULO1);

            /*" -323- MOVE 'DIARIO DE ACOMPANHAMENTO' TO TR-TITULO2. */
            _.Move("DIARIO DE ACOMPANHAMENTO", TITULO_RELATORIO.TR_TITULO2);

            /*" -324- MOVE 'DOS SINISTROS' TO TR-TITULO3. */
            _.Move("DOS SINISTROS", TITULO_RELATORIO.TR_TITULO3);

            /*" -325- MOVE 'AVISADOS' TO TR-TITULO4. */
            _.Move("AVISADOS", TITULO_RELATORIO.TR_TITULO4);

            /*" -326- MOVE SPACES TO TR-TITULO5. */
            _.Move("", TITULO_RELATORIO.TR_TITULO5);

            /*" -327- MOVE 'DATA PROCESSAMENTO' TO TR-TITULO6. */
            _.Move("DATA PROCESSAMENTO", TITULO_RELATORIO.TR_TITULO6);

            /*" -328- MOVE FUNCTION CURRENT-DATE(1:8) TO W-DATA-SISTEMA. */
            _.Move(_.CurrentDate(0, 8), AREAS_DE_WORK.W_DATA_SISTEMA);

            /*" -329- MOVE W-ANO-SISTEMA TO W-DATA-DD-MM-AAAA-AAAA. */
            _.Move(AREAS_DE_WORK.W_DATA_SISTEMA.W_ANO_SISTEMA, AREAS_DE_WORK.W_DATA_DD_MM_AAAA.W_DATA_DD_MM_AAAA_AAAA);

            /*" -330- MOVE W-MES-SISTEMA TO W-DATA-DD-MM-AAAA-MM. */
            _.Move(AREAS_DE_WORK.W_DATA_SISTEMA.W_MES_SISTEMA, AREAS_DE_WORK.W_DATA_DD_MM_AAAA.W_DATA_DD_MM_AAAA_MM);

            /*" -331- MOVE W-DIA-SISTEMA TO W-DATA-DD-MM-AAAA-DD. */
            _.Move(AREAS_DE_WORK.W_DATA_SISTEMA.W_DIA_SISTEMA, AREAS_DE_WORK.W_DATA_DD_MM_AAAA.W_DATA_DD_MM_AAAA_DD);

            /*" -332- MOVE W-DATA-DD-MM-AAAA TO TR-DATA-PROCESSAMENTO. */
            _.Move(AREAS_DE_WORK.W_DATA_DD_MM_AAAA, TITULO_RELATORIO.TR_DATA_PROCESSAMENTO);

            /*" -333- MOVE 'DATA PESQUISA' TO TR-TITULO7. */
            _.Move("DATA PESQUISA", TITULO_RELATORIO.TR_TITULO7);

            /*" -334- MOVE SISTEMAS-DATA-MOV-ABERTO TO W-DATA-AAAA-MM-DD. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, AREAS_DE_WORK.W_DATA_AAAA_MM_DD);

            /*" -335- MOVE W-DATA-AAAA-MM-DD-DD TO W-DATA-DD-MM-AAAA-DD. */
            _.Move(AREAS_DE_WORK.W_DATA_AAAA_MM_DD.W_DATA_AAAA_MM_DD_DD, AREAS_DE_WORK.W_DATA_DD_MM_AAAA.W_DATA_DD_MM_AAAA_DD);

            /*" -336- MOVE W-DATA-AAAA-MM-DD-MM TO W-DATA-DD-MM-AAAA-MM. */
            _.Move(AREAS_DE_WORK.W_DATA_AAAA_MM_DD.W_DATA_AAAA_MM_DD_MM, AREAS_DE_WORK.W_DATA_DD_MM_AAAA.W_DATA_DD_MM_AAAA_MM);

            /*" -337- MOVE W-DATA-AAAA-MM-DD-AAAA TO W-DATA-DD-MM-AAAA-AAAA. */
            _.Move(AREAS_DE_WORK.W_DATA_AAAA_MM_DD.W_DATA_AAAA_MM_DD_AAAA, AREAS_DE_WORK.W_DATA_DD_MM_AAAA.W_DATA_DD_MM_AAAA_AAAA);

            /*" -338- MOVE W-DATA-DD-MM-AAAA TO TR-DATA-PESQUISA. */
            _.Move(AREAS_DE_WORK.W_DATA_DD_MM_AAAA, TITULO_RELATORIO.TR_DATA_PESQUISA);

            /*" -341- MOVE SPACES TO TR-FILLER1 TR-FILLER2 TR-FILLER3 TR-FILLER4 TR-FILLER5 TR-FILLER6. */
            _.Move("", TITULO_RELATORIO.TR_FILLER1, TITULO_RELATORIO.TR_FILLER2, TITULO_RELATORIO.TR_FILLER3, TITULO_RELATORIO.TR_FILLER4, TITULO_RELATORIO.TR_FILLER5, TITULO_RELATORIO.TR_FILLER6);

            /*" -341- WRITE TITULO-RELATORIO. */
            RAVISO.Write(TITULO_RELATORIO.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_120_99_EXIT*/

        [StopWatch]
        /*" M-130-00-IMPRIME-CABECALHO */
        private void M_130_00_IMPRIME_CABECALHO(bool isPerform = false)
        {
            /*" -352- INITIALIZE CABECALHO-AVISADOS. */
            _.Initialize(
                CABECALHO_AVISADOS
            );

            /*" -356- MOVE ';' TO CA-PV1 CA-PV1A CA-PV2 CA-PV3 CA-PV4 CA-PV5 CA-PV6 CA-PV7 CA-PV8 CA-PV9 CA-PV10 CA-PV11 CA-PV12 CA-PV13 CA-PV14 CA-PV15. */
            _.Move(";", CABECALHO_AVISADOS.CA_PV1, CABECALHO_AVISADOS.CA_PV1A, CABECALHO_AVISADOS.CA_PV2, CABECALHO_AVISADOS.CA_PV3, CABECALHO_AVISADOS.CA_PV4, CABECALHO_AVISADOS.CA_PV5, CABECALHO_AVISADOS.CA_PV6, CABECALHO_AVISADOS.CA_PV7, CABECALHO_AVISADOS.CA_PV8, CABECALHO_AVISADOS.CA_PV9, CABECALHO_AVISADOS.CA_PV10, CABECALHO_AVISADOS.CA_PV11, CABECALHO_AVISADOS.CA_PV12, CABECALHO_AVISADOS.CA_PV13, CABECALHO_AVISADOS.CA_PV14, CABECALHO_AVISADOS.CA_PV15);

            /*" -357- MOVE 'NUMERO APOLICE' TO CA-NUMERO-APOLICE. */
            _.Move("NUMERO APOLICE", CABECALHO_AVISADOS.CA_NUMERO_APOLICE);

            /*" -358- MOVE 'CODIGO PRODUTO' TO CA-CODIGO-PRODUTO. */
            _.Move("CODIGO PRODUTO", CABECALHO_AVISADOS.CA_CODIGO_PRODUTO);

            /*" -359- MOVE 'CODIGO LOTERICO CAIXA' TO CA-CODIGO-LOTERICO-CAIXA. */
            _.Move("CODIGO LOTERICO CAIXA", CABECALHO_AVISADOS.CA_CODIGO_LOTERICO_CAIXA);

            /*" -360- MOVE 'RAZAO SOCIAL' TO CA-RAZAO-SOCIAL. */
            _.Move("RAZAO SOCIAL", CABECALHO_AVISADOS.CA_RAZAO_SOCIAL);

            /*" -361- MOVE 'ENDERECO' TO CA-ENDERECO. */
            _.Move("ENDERECO", CABECALHO_AVISADOS.CA_ENDERECO);

            /*" -362- MOVE 'UF' TO CA-UF. */
            _.Move("UF", CABECALHO_AVISADOS.CA_UF);

            /*" -363- MOVE 'NUMERO APOLICE SINISTRO' TO CA-NUMERO-APOLICE-SINISTRO. */
            _.Move("NUMERO APOLICE SINISTRO", CABECALHO_AVISADOS.CA_NUMERO_APOLICE_SINISTRO);

            /*" -364- MOVE 'DATA OCORRENCIA' TO CA-DATA-OCORRENCIA. */
            _.Move("DATA OCORRENCIA", CABECALHO_AVISADOS.CA_DATA_OCORRENCIA);

            /*" -365- MOVE 'DATA CADASTRO' TO CA-DATA-CADASTRO. */
            _.Move("DATA CADASTRO", CABECALHO_AVISADOS.CA_DATA_CADASTRO);

            /*" -366- MOVE 'DATA ADIANTAMENTO' TO CA-DATA-ADIANTAMENTO. */
            _.Move("DATA ADIANTAMENTO", CABECALHO_AVISADOS.CA_DATA_ADIANTAMENTO);

            /*" -367- MOVE 'VALOR ADIANTAMENTO' TO CA-VALOR-ADIANTAMENTO. */
            _.Move("VALOR ADIANTAMENTO", CABECALHO_AVISADOS.CA_VALOR_ADIANTAMENTO);

            /*" -368- MOVE 'VALOR AVISO' TO CA-VALOR-AVISO. */
            _.Move("VALOR AVISO", CABECALHO_AVISADOS.CA_VALOR_AVISO);

            /*" -369- MOVE 'DESCRICAO CAUSA' TO CA-DESCRICAO-CAUSA. */
            _.Move("DESCRICAO CAUSA", CABECALHO_AVISADOS.CA_DESCRICAO_CAUSA);

            /*" -370- MOVE 'DATA COMUNICADO' TO CA-DATA-COMUNICADO. */
            _.Move("DATA COMUNICADO", CABECALHO_AVISADOS.CA_DATA_COMUNICADO);

            /*" -371- MOVE 'QUANTIDADE PORTADORES' TO CA-QUANTIDADE-PORTADORES. */
            _.Move("QUANTIDADE PORTADORES", CABECALHO_AVISADOS.CA_QUANTIDADE_PORTADORES);

            /*" -373- MOVE 'INDICATIVO ADIANTAMENTO' TO CA-INDICATIVO-ADIANTAMENTO. */
            _.Move("INDICATIVO ADIANTAMENTO", CABECALHO_AVISADOS.CA_INDICATIVO_ADIANTAMENTO);

            /*" -373- WRITE CABECALHO-AVISADOS. */
            RAVISO.Write(CABECALHO_AVISADOS.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_130_99_EXIT*/

        [StopWatch]
        /*" M-200-00-PROCESSAMENTO */
        private void M_200_00_PROCESSAMENTO(bool isPerform = false)
        {
            /*" -391- MOVE SISTEMAS-DATA-MOV-ABERTO TO W-DATA-PESQUISA. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, AREAS_DE_WORK.W_DATA_PESQUISA);

            /*" -392- PERFORM 210-00-DECLARE-HIST-AVISOS THRU 210-99-EXIT. */

            M_210_00_DECLARE_HIST_AVISOS(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_210_99_EXIT*/


            /*" -394- MOVE 'NAO' TO W-FIM-AVISOS. */
            _.Move("NAO", AREAS_DE_WORK.W_FIM_AVISOS);

            /*" -396- PERFORM 220-00-FETCH-HIST-AVISOS THRU 220-99-EXIT. */

            M_220_00_FETCH_HIST_AVISOS(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_220_99_EXIT*/


            /*" -397- PERFORM 230-00-PROCESSA-HIST-AVISOS THRU 230-99-EXIT UNTIL (W-FIM-AVISOS EQUAL 'SIM' ). */

            while (!((AREAS_DE_WORK.W_FIM_AVISOS == "SIM")))
            {

                M_230_00_PROCESSA_HIST_AVISOS(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_230_99_EXIT*/

            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_200_99_EXIT*/

        [StopWatch]
        /*" M-210-00-DECLARE-HIST-AVISOS */
        private void M_210_00_DECLARE_HIST_AVISOS(bool isPerform = false)
        {
            /*" -408- MOVE '002' TO WNR-EXEC-SQL. */
            _.Move("002", AREAS_DE_WORK.WABEND.WABEND1.WABEND2.WNR_EXEC_SQL);

            /*" -409- DISPLAY 'DATA PESQUISA' */
            _.Display($"DATA PESQUISA");

            /*" -410- DISPLAY W-DATA-PESQUISA */
            _.Display(AREAS_DE_WORK.W_DATA_PESQUISA);

            /*" -412- DISPLAY ' ' */
            _.Display($" ");

            /*" -447- PERFORM M_210_00_DECLARE_HIST_AVISOS_DB_DECLARE_1 */

            M_210_00_DECLARE_HIST_AVISOS_DB_DECLARE_1();

            /*" -449- PERFORM M_210_00_DECLARE_HIST_AVISOS_DB_OPEN_1 */

            M_210_00_DECLARE_HIST_AVISOS_DB_OPEN_1();

            /*" -452- IF SQLCODE NOT EQUAL ZERO */

            if (DB.SQLCODE != 00)
            {

                /*" -453- DISPLAY 'ERRO SELECT HISTORICO DE AVISOS.....' */
                _.Display($"ERRO SELECT HISTORICO DE AVISOS.....");

                /*" -453- GO TO 999-00-ROT-ERRO. */

                M_999_00_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-210-00-DECLARE-HIST-AVISOS-DB-DECLARE-1 */
        public void M_210_00_DECLARE_HIST_AVISOS_DB_DECLARE_1()
        {
            /*" -447- EXEC SQL DECLARE HIST_AVISOS CURSOR FOR SELECT H.NUM_APOLICE , H.COD_PRODUTO , H.NUM_APOL_SINISTRO , SL.COD_LOT_CEF , C.NOME_RAZAO , L.SIGLA_UF , L.ENDERECO , M.DATA_OCORRENCIA , M.DATA_COMUNICADO , SC.DESCR_CAUSA , ML.VALOR_INFORMADO , ML.QTD_PORTADORES , ML.IND_ADIANTAMENTO FROM SEGUROS.SINISTRO_HISTORICO H, SEGUROS.SINISTRO_MESTRE M, SEGUROS.LOTERICO01 L, SEGUROS.SINI_LOTERICO01 SL, SEGUROS.CLIENTES C, SEGUROS.SINISTRO_CAUSA SC, SEGUROS.SI_MOV_LOTERICO1 ML WHERE H.DATA_MOVIMENTO = :W-DATA-PESQUISA AND H.COD_OPERACAO = 101 AND H.COD_PRODUTO IN (1803, 1805) AND SL.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO AND M.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO AND C.COD_CLIENTE = SL.COD_CLIENTE AND L.DTINIVIG <= M.DATA_OCORRENCIA AND L.DTTERVIG >= M.DATA_OCORRENCIA AND L.COD_LOT_CEF = SL.COD_LOT_CEF AND L.NUM_APOLICE = H.NUM_APOLICE AND SC.RAMO_EMISSOR = M.RAMO AND SC.COD_CAUSA = M.COD_CAUSA AND ML.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO ORDER BY SL.COD_LOT_CEF END-EXEC. */
            HIST_AVISOS = new SI0007B_HIST_AVISOS(true);
            string GetQuery_HIST_AVISOS()
            {
                var query = @$"SELECT H.NUM_APOLICE
							, 
							H.COD_PRODUTO
							, 
							H.NUM_APOL_SINISTRO
							, 
							SL.COD_LOT_CEF
							, 
							C.NOME_RAZAO
							, 
							L.SIGLA_UF
							, 
							L.ENDERECO
							, 
							M.DATA_OCORRENCIA
							, 
							M.DATA_COMUNICADO
							, 
							SC.DESCR_CAUSA
							, 
							ML.VALOR_INFORMADO
							, 
							ML.QTD_PORTADORES
							, 
							ML.IND_ADIANTAMENTO 
							FROM SEGUROS.SINISTRO_HISTORICO H
							, 
							SEGUROS.SINISTRO_MESTRE M
							, 
							SEGUROS.LOTERICO01 L
							, 
							SEGUROS.SINI_LOTERICO01 SL
							, 
							SEGUROS.CLIENTES C
							, 
							SEGUROS.SINISTRO_CAUSA SC
							, 
							SEGUROS.SI_MOV_LOTERICO1 ML 
							WHERE H.DATA_MOVIMENTO = '{AREAS_DE_WORK.W_DATA_PESQUISA}' 
							AND H.COD_OPERACAO = 101 
							AND H.COD_PRODUTO IN (1803
							, 1805) 
							AND SL.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO 
							AND M.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO 
							AND C.COD_CLIENTE = SL.COD_CLIENTE 
							AND L.DTINIVIG <= M.DATA_OCORRENCIA 
							AND L.DTTERVIG >= M.DATA_OCORRENCIA 
							AND L.COD_LOT_CEF = SL.COD_LOT_CEF 
							AND L.NUM_APOLICE = H.NUM_APOLICE 
							AND SC.RAMO_EMISSOR = M.RAMO 
							AND SC.COD_CAUSA = M.COD_CAUSA 
							AND ML.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO 
							ORDER BY SL.COD_LOT_CEF";

                return query;
            }
            HIST_AVISOS.GetQueryEvent += GetQuery_HIST_AVISOS;

        }

        [StopWatch]
        /*" M-210-00-DECLARE-HIST-AVISOS-DB-OPEN-1 */
        public void M_210_00_DECLARE_HIST_AVISOS_DB_OPEN_1()
        {
            /*" -449- EXEC SQL OPEN HIST_AVISOS END-EXEC. */

            HIST_AVISOS.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_210_99_EXIT*/

        [StopWatch]
        /*" M-220-00-FETCH-HIST-AVISOS */
        private void M_220_00_FETCH_HIST_AVISOS(bool isPerform = false)
        {
            /*" -464- MOVE '003' TO WNR-EXEC-SQL. */
            _.Move("003", AREAS_DE_WORK.WABEND.WABEND1.WABEND2.WNR_EXEC_SQL);

            /*" -478- PERFORM M_220_00_FETCH_HIST_AVISOS_DB_FETCH_1 */

            M_220_00_FETCH_HIST_AVISOS_DB_FETCH_1();

            /*" -481- IF SQLCODE NOT EQUAL ZERO */

            if (DB.SQLCODE != 00)
            {

                /*" -482- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -483- MOVE 'SIM' TO W-FIM-AVISOS */
                    _.Move("SIM", AREAS_DE_WORK.W_FIM_AVISOS);

                    /*" -483- PERFORM M_220_00_FETCH_HIST_AVISOS_DB_CLOSE_1 */

                    M_220_00_FETCH_HIST_AVISOS_DB_CLOSE_1();

                    /*" -485- ELSE */
                }
                else
                {


                    /*" -486- DISPLAY 'ERRO FETCH HISTORICO DE AVISOS.....' */
                    _.Display($"ERRO FETCH HISTORICO DE AVISOS.....");

                    /*" -486- GO TO 999-00-ROT-ERRO. */

                    M_999_00_ROT_ERRO(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" M-220-00-FETCH-HIST-AVISOS-DB-FETCH-1 */
        public void M_220_00_FETCH_HIST_AVISOS_DB_FETCH_1()
        {
            /*" -478- EXEC SQL FETCH HIST_AVISOS INTO :SINISHIS-NUM-APOLICE , :SINISHIS-COD-PRODUTO , :SINISHIS-NUM-APOL-SINISTRO, :SINILT01-COD-LOT-CEF , :CLIENTES-NOME-RAZAO , :LOTERI01-SIGLA-UF , :LOTERI01-ENDERECO , :SINISMES-DATA-OCORRENCIA , :SINISMES-DATA-COMUNICADO , :SINISCAU-DESCR-CAUSA , :SIMOLOT1-VALOR-INFORMADO , :SIMOLOT1-QTD-PORTADORES , :SIMOLOT1-IND-ADIANTAMENTO END-EXEC. */

            if (HIST_AVISOS.Fetch())
            {
                _.Move(HIST_AVISOS.SINISHIS_NUM_APOLICE, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOLICE);
                _.Move(HIST_AVISOS.SINISHIS_COD_PRODUTO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_PRODUTO);
                _.Move(HIST_AVISOS.SINISHIS_NUM_APOL_SINISTRO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO);
                _.Move(HIST_AVISOS.SINILT01_COD_LOT_CEF, SINILT01.DCLSINI_LOTERICO01.SINILT01_COD_LOT_CEF);
                _.Move(HIST_AVISOS.CLIENTES_NOME_RAZAO, CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO);
                _.Move(HIST_AVISOS.LOTERI01_SIGLA_UF, LOTERI01.DCLLOTERICO01.LOTERI01_SIGLA_UF);
                _.Move(HIST_AVISOS.LOTERI01_ENDERECO, LOTERI01.DCLLOTERICO01.LOTERI01_ENDERECO);
                _.Move(HIST_AVISOS.SINISMES_DATA_OCORRENCIA, SINISMES.DCLSINISTRO_MESTRE.SINISMES_DATA_OCORRENCIA);
                _.Move(HIST_AVISOS.SINISMES_DATA_COMUNICADO, SINISMES.DCLSINISTRO_MESTRE.SINISMES_DATA_COMUNICADO);
                _.Move(HIST_AVISOS.SINISCAU_DESCR_CAUSA, SINISCAU.DCLSINISTRO_CAUSA.SINISCAU_DESCR_CAUSA);
                _.Move(HIST_AVISOS.SIMOLOT1_VALOR_INFORMADO, SIMOLOT1.DCLSI_MOV_LOTERICO1.SIMOLOT1_VALOR_INFORMADO);
                _.Move(HIST_AVISOS.SIMOLOT1_QTD_PORTADORES, SIMOLOT1.DCLSI_MOV_LOTERICO1.SIMOLOT1_QTD_PORTADORES);
                _.Move(HIST_AVISOS.SIMOLOT1_IND_ADIANTAMENTO, SIMOLOT1.DCLSI_MOV_LOTERICO1.SIMOLOT1_IND_ADIANTAMENTO);
            }

        }

        [StopWatch]
        /*" M-220-00-FETCH-HIST-AVISOS-DB-CLOSE-1 */
        public void M_220_00_FETCH_HIST_AVISOS_DB_CLOSE_1()
        {
            /*" -483- EXEC SQL CLOSE HIST_AVISOS END-EXEC */

            HIST_AVISOS.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_220_99_EXIT*/

        [StopWatch]
        /*" M-230-00-PROCESSA-HIST-AVISOS */
        private void M_230_00_PROCESSA_HIST_AVISOS(bool isPerform = false)
        {
            /*" -497- PERFORM 231-00-ADIANTAMENTO THRU 231-99-EXIT. */

            M_231_00_ADIANTAMENTO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_231_99_EXIT*/


            /*" -501- MOVE ';' TO RA-PV1 RA-PV1A RA-PV2 RA-PV3 RA-PV4 RA-PV5 RA-PV6 RA-PV7 RA-PV8 RA-PV9 RA-PV10 RA-PV11 RA-PV12 RA-PV13 RA-PV14 RA-PV15. */
            _.Move(";", REGISTRO_AVISADOS.RA_PV1, REGISTRO_AVISADOS.RA_PV1A, REGISTRO_AVISADOS.RA_PV2, REGISTRO_AVISADOS.RA_PV3, REGISTRO_AVISADOS.RA_PV4, REGISTRO_AVISADOS.RA_PV5, REGISTRO_AVISADOS.RA_PV6, REGISTRO_AVISADOS.RA_PV7, REGISTRO_AVISADOS.RA_PV8, REGISTRO_AVISADOS.RA_PV9, REGISTRO_AVISADOS.RA_PV10, REGISTRO_AVISADOS.RA_PV11, REGISTRO_AVISADOS.RA_PV12, REGISTRO_AVISADOS.RA_PV13, REGISTRO_AVISADOS.RA_PV14, REGISTRO_AVISADOS.RA_PV15);

            /*" -504- MOVE '/' TO W-BARRA1 W-BARRA2. */
            _.Move("/", AREAS_DE_WORK.W_DATA_DD_MM_AAAA.W_BARRA1, AREAS_DE_WORK.W_DATA_DD_MM_AAAA.W_BARRA2);

            /*" -505- MOVE SINISHIS-NUM-APOLICE TO RA-NUM-APOLICE. */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOLICE, REGISTRO_AVISADOS.RA_NUM_APOLICE);

            /*" -506- MOVE SINISHIS-COD-PRODUTO TO RA-COD-PRODUTO. */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_PRODUTO, REGISTRO_AVISADOS.RA_COD_PRODUTO);

            /*" -507- MOVE SINILT01-COD-LOT-CEF TO RA-COD-LOT-CEF. */
            _.Move(SINILT01.DCLSINI_LOTERICO01.SINILT01_COD_LOT_CEF, REGISTRO_AVISADOS.RA_COD_LOT_CEF);

            /*" -508- MOVE CLIENTES-NOME-RAZAO TO RA-NOME-RAZAO. */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO, REGISTRO_AVISADOS.RA_NOME_RAZAO);

            /*" -509- MOVE LOTERI01-ENDERECO TO RA-ENDERECO. */
            _.Move(LOTERI01.DCLLOTERICO01.LOTERI01_ENDERECO, REGISTRO_AVISADOS.RA_ENDERECO);

            /*" -510- MOVE LOTERI01-SIGLA-UF TO RA-SIGLA-UF. */
            _.Move(LOTERI01.DCLLOTERICO01.LOTERI01_SIGLA_UF, REGISTRO_AVISADOS.RA_SIGLA_UF);

            /*" -511- MOVE SINISHIS-NUM-APOL-SINISTRO TO RA-NUM-APOL-SINISTRO. */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO, REGISTRO_AVISADOS.RA_NUM_APOL_SINISTRO);

            /*" -512- MOVE SINISMES-DATA-OCORRENCIA TO W-DATA-AAAA-MM-DD. */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_DATA_OCORRENCIA, AREAS_DE_WORK.W_DATA_AAAA_MM_DD);

            /*" -513- MOVE W-DATA-AAAA-MM-DD-AAAA TO W-DATA-DD-MM-AAAA-AAAA. */
            _.Move(AREAS_DE_WORK.W_DATA_AAAA_MM_DD.W_DATA_AAAA_MM_DD_AAAA, AREAS_DE_WORK.W_DATA_DD_MM_AAAA.W_DATA_DD_MM_AAAA_AAAA);

            /*" -514- MOVE W-DATA-AAAA-MM-DD-MM TO W-DATA-DD-MM-AAAA-MM. */
            _.Move(AREAS_DE_WORK.W_DATA_AAAA_MM_DD.W_DATA_AAAA_MM_DD_MM, AREAS_DE_WORK.W_DATA_DD_MM_AAAA.W_DATA_DD_MM_AAAA_MM);

            /*" -515- MOVE W-DATA-AAAA-MM-DD-DD TO W-DATA-DD-MM-AAAA-DD. */
            _.Move(AREAS_DE_WORK.W_DATA_AAAA_MM_DD.W_DATA_AAAA_MM_DD_DD, AREAS_DE_WORK.W_DATA_DD_MM_AAAA.W_DATA_DD_MM_AAAA_DD);

            /*" -516- MOVE W-DATA-DD-MM-AAAA TO RA-DATA-OCORRENCIA. */
            _.Move(AREAS_DE_WORK.W_DATA_DD_MM_AAAA, REGISTRO_AVISADOS.RA_DATA_OCORRENCIA);

            /*" -517- MOVE SISTEMAS-DATA-MOV-ABERTO TO W-DATA-AAAA-MM-DD. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, AREAS_DE_WORK.W_DATA_AAAA_MM_DD);

            /*" -518- MOVE W-DATA-AAAA-MM-DD-AAAA TO W-DATA-DD-MM-AAAA-AAAA. */
            _.Move(AREAS_DE_WORK.W_DATA_AAAA_MM_DD.W_DATA_AAAA_MM_DD_AAAA, AREAS_DE_WORK.W_DATA_DD_MM_AAAA.W_DATA_DD_MM_AAAA_AAAA);

            /*" -519- MOVE W-DATA-AAAA-MM-DD-MM TO W-DATA-DD-MM-AAAA-MM. */
            _.Move(AREAS_DE_WORK.W_DATA_AAAA_MM_DD.W_DATA_AAAA_MM_DD_MM, AREAS_DE_WORK.W_DATA_DD_MM_AAAA.W_DATA_DD_MM_AAAA_MM);

            /*" -520- MOVE W-DATA-AAAA-MM-DD-DD TO W-DATA-DD-MM-AAAA-DD. */
            _.Move(AREAS_DE_WORK.W_DATA_AAAA_MM_DD.W_DATA_AAAA_MM_DD_DD, AREAS_DE_WORK.W_DATA_DD_MM_AAAA.W_DATA_DD_MM_AAAA_DD);

            /*" -521- MOVE W-DATA-DD-MM-AAAA TO RA-DATA-MOV-ABERTO. */
            _.Move(AREAS_DE_WORK.W_DATA_DD_MM_AAAA, REGISTRO_AVISADOS.RA_DATA_MOV_ABERTO);

            /*" -522- IF W-TEM-ADIANTAMENTO EQUAL 'SIM' */

            if (AREAS_DE_WORK.W_TEM_ADIANTAMENTO == "SIM")
            {

                /*" -523- MOVE SINISHIS-DATA-MOVIMENTO TO W-DATA-AAAA-MM-DD */
                _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_DATA_MOVIMENTO, AREAS_DE_WORK.W_DATA_AAAA_MM_DD);

                /*" -524- MOVE W-DATA-AAAA-MM-DD-AAAA TO W-DATA-DD-MM-AAAA-AAAA */
                _.Move(AREAS_DE_WORK.W_DATA_AAAA_MM_DD.W_DATA_AAAA_MM_DD_AAAA, AREAS_DE_WORK.W_DATA_DD_MM_AAAA.W_DATA_DD_MM_AAAA_AAAA);

                /*" -525- MOVE W-DATA-AAAA-MM-DD-MM TO W-DATA-DD-MM-AAAA-MM */
                _.Move(AREAS_DE_WORK.W_DATA_AAAA_MM_DD.W_DATA_AAAA_MM_DD_MM, AREAS_DE_WORK.W_DATA_DD_MM_AAAA.W_DATA_DD_MM_AAAA_MM);

                /*" -526- MOVE W-DATA-AAAA-MM-DD-DD TO W-DATA-DD-MM-AAAA-DD */
                _.Move(AREAS_DE_WORK.W_DATA_AAAA_MM_DD.W_DATA_AAAA_MM_DD_DD, AREAS_DE_WORK.W_DATA_DD_MM_AAAA.W_DATA_DD_MM_AAAA_DD);

                /*" -527- MOVE W-DATA-DD-MM-AAAA TO RA-DATA-MOVIMENTO */
                _.Move(AREAS_DE_WORK.W_DATA_DD_MM_AAAA, REGISTRO_AVISADOS.RA_DATA_MOVIMENTO);

                /*" -528- MOVE SINISHIS-VAL-OPERACAO TO RA-VAL-OPERACAO */
                _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO, REGISTRO_AVISADOS.RA_VAL_OPERACAO);

                /*" -529- ELSE */
            }
            else
            {


                /*" -530- MOVE SPACES TO RA-DATA-MOVIMENTO */
                _.Move("", REGISTRO_AVISADOS.RA_DATA_MOVIMENTO);

                /*" -531- MOVE ZEROS TO RA-VAL-OPERACAO. */
                _.Move(0, REGISTRO_AVISADOS.RA_VAL_OPERACAO);
            }


            /*" -532- MOVE SIMOLOT1-VALOR-INFORMADO TO RA-VALOR-INFORMADO. */
            _.Move(SIMOLOT1.DCLSI_MOV_LOTERICO1.SIMOLOT1_VALOR_INFORMADO, REGISTRO_AVISADOS.RA_VALOR_INFORMADO);

            /*" -533- MOVE SINISCAU-DESCR-CAUSA TO RA-DESCR-CAUSA. */
            _.Move(SINISCAU.DCLSINISTRO_CAUSA.SINISCAU_DESCR_CAUSA, REGISTRO_AVISADOS.RA_DESCR_CAUSA);

            /*" -534- MOVE SINISMES-DATA-COMUNICADO TO W-DATA-AAAA-MM-DD. */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_DATA_COMUNICADO, AREAS_DE_WORK.W_DATA_AAAA_MM_DD);

            /*" -535- MOVE W-DATA-AAAA-MM-DD-AAAA TO W-DATA-DD-MM-AAAA-AAAA. */
            _.Move(AREAS_DE_WORK.W_DATA_AAAA_MM_DD.W_DATA_AAAA_MM_DD_AAAA, AREAS_DE_WORK.W_DATA_DD_MM_AAAA.W_DATA_DD_MM_AAAA_AAAA);

            /*" -536- MOVE W-DATA-AAAA-MM-DD-MM TO W-DATA-DD-MM-AAAA-MM. */
            _.Move(AREAS_DE_WORK.W_DATA_AAAA_MM_DD.W_DATA_AAAA_MM_DD_MM, AREAS_DE_WORK.W_DATA_DD_MM_AAAA.W_DATA_DD_MM_AAAA_MM);

            /*" -537- MOVE W-DATA-AAAA-MM-DD-DD TO W-DATA-DD-MM-AAAA-DD. */
            _.Move(AREAS_DE_WORK.W_DATA_AAAA_MM_DD.W_DATA_AAAA_MM_DD_DD, AREAS_DE_WORK.W_DATA_DD_MM_AAAA.W_DATA_DD_MM_AAAA_DD);

            /*" -538- MOVE W-DATA-DD-MM-AAAA TO RA-DATA-COMUNICADO. */
            _.Move(AREAS_DE_WORK.W_DATA_DD_MM_AAAA, REGISTRO_AVISADOS.RA_DATA_COMUNICADO);

            /*" -539- MOVE SIMOLOT1-QTD-PORTADORES TO RA-QTD-PORTADORES. */
            _.Move(SIMOLOT1.DCLSI_MOV_LOTERICO1.SIMOLOT1_QTD_PORTADORES, REGISTRO_AVISADOS.RA_QTD_PORTADORES);

            /*" -541- MOVE SIMOLOT1-IND-ADIANTAMENTO TO RA-IND-ADIANTAMENTO. */
            _.Move(SIMOLOT1.DCLSI_MOV_LOTERICO1.SIMOLOT1_IND_ADIANTAMENTO, REGISTRO_AVISADOS.RA_IND_ADIANTAMENTO);

            /*" -543- WRITE REGISTRO-AVISADOS. */
            RAVISO.Write(REGISTRO_AVISADOS.GetMoveValues().ToString());

            /*" -545- ADD 1 TO W-TOTAL-REG. */
            AREAS_DE_WORK.W_TOTAL_REG.Value = AREAS_DE_WORK.W_TOTAL_REG + 1;

            /*" -545- PERFORM 220-00-FETCH-HIST-AVISOS THRU 220-99-EXIT. */

            M_220_00_FETCH_HIST_AVISOS(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_220_99_EXIT*/


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_230_99_EXIT*/

        [StopWatch]
        /*" M-231-00-ADIANTAMENTO */
        private void M_231_00_ADIANTAMENTO(bool isPerform = false)
        {
            /*" -556- MOVE '004' TO WNR-EXEC-SQL. */
            _.Move("004", AREAS_DE_WORK.WABEND.WABEND1.WABEND2.WNR_EXEC_SQL);

            /*" -564- PERFORM M_231_00_ADIANTAMENTO_DB_SELECT_1 */

            M_231_00_ADIANTAMENTO_DB_SELECT_1();

            /*" -567- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -568- MOVE 'SIM' TO W-TEM-ADIANTAMENTO */
                _.Move("SIM", AREAS_DE_WORK.W_TEM_ADIANTAMENTO);

                /*" -569- ELSE */
            }
            else
            {


                /*" -570- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -571- MOVE 'NAO' TO W-TEM-ADIANTAMENTO */
                    _.Move("NAO", AREAS_DE_WORK.W_TEM_ADIANTAMENTO);

                    /*" -572- ELSE */
                }
                else
                {


                    /*" -573- DISPLAY 'ERRO SELECT - ADIANTAMENTO AVISO' */
                    _.Display($"ERRO SELECT - ADIANTAMENTO AVISO");

                    /*" -573- GO TO 999-00-ROT-ERRO. */

                    M_999_00_ROT_ERRO(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" M-231-00-ADIANTAMENTO-DB-SELECT-1 */
        public void M_231_00_ADIANTAMENTO_DB_SELECT_1()
        {
            /*" -564- EXEC SQL SELECT DATA_MOVIMENTO, VAL_OPERACAO INTO :SINISHIS-DATA-MOVIMENTO, :SINISHIS-VAL-OPERACAO FROM SEGUROS.SINISTRO_HISTORICO WHERE NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO AND COD_OPERACAO = 1070 END-EXEC. */

            var m_231_00_ADIANTAMENTO_DB_SELECT_1_Query1 = new M_231_00_ADIANTAMENTO_DB_SELECT_1_Query1()
            {
                SINISHIS_NUM_APOL_SINISTRO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.ToString(),
            };

            var executed_1 = M_231_00_ADIANTAMENTO_DB_SELECT_1_Query1.Execute(m_231_00_ADIANTAMENTO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SINISHIS_DATA_MOVIMENTO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_DATA_MOVIMENTO);
                _.Move(executed_1.SINISHIS_VAL_OPERACAO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_231_99_EXIT*/

        [StopWatch]
        /*" M-300-00-FINALIZACOES */
        private void M_300_00_FINALIZACOES(bool isPerform = false)
        {
            /*" -584- PERFORM 310-00-TOTAL-AVISADOS THRU 310-99-EXIT. */

            M_310_00_TOTAL_AVISADOS(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_310_99_EXIT*/


            /*" -585- DISPLAY ' ' . */
            _.Display($" ");

            /*" -586- DISPLAY 'TOTAL DE REGISTROS GRAVADOS' . */
            _.Display($"TOTAL DE REGISTROS GRAVADOS");

            /*" -588- DISPLAY W-TOTAL-REG. */
            _.Display(AREAS_DE_WORK.W_TOTAL_REG);

            /*" -589- DISPLAY ' ' . */
            _.Display($" ");

            /*" -590- DISPLAY '*************************************' . */
            _.Display($"*************************************");

            /*" -591- DISPLAY '*                                   *' . */
            _.Display($"*                                   *");

            /*" -592- DISPLAY '*           SI0007B                 *' . */
            _.Display($"*           SI0007B                 *");

            /*" -593- DISPLAY '*                                   *' . */
            _.Display($"*                                   *");

            /*" -594- DISPLAY '*  TERMINO NORMAL DE PROCESSAMENTO  *' . */
            _.Display($"*  TERMINO NORMAL DE PROCESSAMENTO  *");

            /*" -595- DISPLAY '*                                   *' . */
            _.Display($"*                                   *");

            /*" -597- DISPLAY '*************************************' . */
            _.Display($"*************************************");

            /*" -599- CLOSE RAVISO. */
            RAVISO.Close();

            /*" -599- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -602- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_300_99_EXIT*/

        [StopWatch]
        /*" M-310-00-TOTAL-AVISADOS */
        private void M_310_00_TOTAL_AVISADOS(bool isPerform = false)
        {
            /*" -612- INITIALIZE TOTAL-AVISADOS. */
            _.Initialize(
                TOTAL_AVISADOS
            );

            /*" -616- MOVE ';' TO TA-PV1 TA-PV2 TA-PV3 TA-PV4 TA-PV5 TA-PV6 TA-PV7 TA-PV8 TA-PV9 TA-PV10 TA-PV11 TA-PV12 TA-PV13 TA-PV14 TA-PV15. */
            _.Move(";", TOTAL_AVISADOS.TA_PV1, TOTAL_AVISADOS.TA_PV2, TOTAL_AVISADOS.TA_PV3, TOTAL_AVISADOS.TA_PV4, TOTAL_AVISADOS.TA_PV5, TOTAL_AVISADOS.TA_PV6, TOTAL_AVISADOS.TA_PV7, TOTAL_AVISADOS.TA_PV8, TOTAL_AVISADOS.TA_PV9, TOTAL_AVISADOS.TA_PV10, TOTAL_AVISADOS.TA_PV11, TOTAL_AVISADOS.TA_PV12, TOTAL_AVISADOS.TA_PV13, TOTAL_AVISADOS.TA_PV14, TOTAL_AVISADOS.TA_PV15);

            /*" -617- MOVE 'TOTAL AVISOS..' TO TA-TOTAL-AVISADOS. */
            _.Move("TOTAL AVISOS..", TOTAL_AVISADOS.TA_TOTAL_AVISADOS);

            /*" -618- MOVE W-TOTAL-REG TO TA-TOTAL-REG. */
            _.Move(AREAS_DE_WORK.W_TOTAL_REG, TOTAL_AVISADOS.TA_TOTAL_REG);

            /*" -624- MOVE SPACES TO TA-FILLER1 TA-FILLER2 TA-FILLER3 TA-FILLER4 TA-FILLER5 TA-FILLER6 TA-FILLER7 TA-FILLER8 TA-FILLER9 TA-FILLER10 TA-FILLER11 TA-FILLER12 TA-FILLER13. */
            _.Move("", TOTAL_AVISADOS.TA_FILLER1, TOTAL_AVISADOS.TA_FILLER2, TOTAL_AVISADOS.TA_FILLER3, TOTAL_AVISADOS.TA_FILLER4, TOTAL_AVISADOS.TA_FILLER5, TOTAL_AVISADOS.TA_FILLER6, TOTAL_AVISADOS.TA_FILLER7, TOTAL_AVISADOS.TA_FILLER8, TOTAL_AVISADOS.TA_FILLER9, TOTAL_AVISADOS.TA_FILLER10, TOTAL_AVISADOS.TA_FILLER11, TOTAL_AVISADOS.TA_FILLER12, TOTAL_AVISADOS.TA_FILLER13);

            /*" -624- WRITE TOTAL-AVISADOS. */
            RAVISO.Write(TOTAL_AVISADOS.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_310_99_EXIT*/

        [StopWatch]
        /*" M-999-00-ROT-ERRO */
        private void M_999_00_ROT_ERRO(bool isPerform = false)
        {
            /*" -634- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, AREAS_DE_WORK.WABEND.WABEND1.WABEND2.WABEND3.WSQLCODE);

            /*" -635- DISPLAY ' ' */
            _.Display($" ");

            /*" -636- DISPLAY '=====  PROGRAMA ABENDADO  =====' */
            _.Display($"=====  PROGRAMA ABENDADO  =====");

            /*" -637- DISPLAY ' ' */
            _.Display($" ");

            /*" -638- DISPLAY WABEND1. */
            _.Display(AREAS_DE_WORK.WABEND.WABEND1);

            /*" -639- DISPLAY WABEND2. */
            _.Display(AREAS_DE_WORK.WABEND.WABEND1.WABEND2);

            /*" -640- DISPLAY WABEND3. */
            _.Display(AREAS_DE_WORK.WABEND.WABEND1.WABEND2.WABEND3);

            /*" -640- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -641- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -642- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_999_99_EXIT*/
    }
}