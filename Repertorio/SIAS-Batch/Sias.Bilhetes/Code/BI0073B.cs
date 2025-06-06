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
using Sias.Bilhetes.DB2.BI0073B;

namespace Code
{
    public class BI0073B
    {
        public bool IsCall { get; set; }

        public BI0073B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------                                 */
        /*"      *                                                                       */
        /*"      *                                                                       */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  COBRANCA                           *      */
        /*"      *   PROGRAMA ...............  BI0073B                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  FAST                               *      */
        /*"      *   PROGRAMADOR ............  FAST                               *      */
        /*"      *   DATA CODIFICACAO .......  08/07/2008                         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO .................  CONSISTENCIA E CONTROLE DO         *      */
        /*"      *                             MOVIMENTO DE COBRANCA              *      */
        /*"      *                             CONVENIO DE ARRECADACAO - SICAP    *      */
        /*"      *                             CAIXA SEGURADORA - 1028370056      *      */
        /*"      *                                                                *      */
        /*"      *              8114 - AP VIDA TRANQUILA PREMIADO EDUCACIONAL     *      */
        /*"      *              8115 - AP VIDA TRANQUILA PREMIADO SAF             *      */
        /*"      *              8116 - AP VIDA TRANQUILA PREMIADO CHECK LAR       *      */
        /*"      *              8117 - AP VIDA TRANQUILA PREMIADO HELP DESK       *      */
        /*"      *              8118 - AP VIDA TRANQUILA PREMIADO NUTRICIONAL     *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 14 ..............  CLOVIS EM 11/08/2015    V.14       *      */
        /*"      *                             CADMUS      .                      *      */
        /*"      *                             TRATA DUPLICIDADE NO ARQUIVO       *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 13 -   NSGD - CADMUS 103659.                          *      */
        /*"      *               - NOVA SOLUCAO DE GESTAO DE DEPOSITOS            *      */
        /*"      *                                                                *      */
        /*"      *   EM 25/06/2015 - COREON                                       *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.13         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 12 - CAD 107.004                                      *      */
        /*"      *             - AJUSTE DE INTEGRACAO SAP/BACKSEG - BANCO 104     *      */
        /*"      *                                                                *      */
        /*"      *   EM 08/02/2015 - CLOVIS/ELIERMES                              *      */
        /*"      *                                       PROCURE POR V.12         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 11 - CAD 85.727                                       *      */
        /*"      *             - AJUSTE  PARA CAPTURAR O NUM_ENDOSSO.             *      */
        /*"      *                                                                *      */
        /*"      *   EM 02/09/2013 - EDIVALDO GOMES (FAST COMPUTER)               *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.11         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 10 - CAD 53.577                                       *      */
        /*"      *             - AJUSTES NO PROCESSO DE RETENCAO SYSTEM CRED:     *      */
        /*"      *               INIBIR GERACAO DO ARQUIVO DE STATUS E            *      */
        /*"      *               NAO FAZER ALTERACAO DE BILHETE CAIXA PARA SIT. 5 *      */
        /*"      *                                                                *      */
        /*"      *   EM 11/03/2011 - TERCIO FREITAS (FAST COMPUTER)               *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.10         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 09 - CAD 52.124                                       *      */
        /*"      *               - AJUSTE NA AGENCIA DO AVISO PARA CONTABILIZACAO *      */
        /*"      *                                                                *      */
        /*"      *   EM 06/01/2011 - TERCIO FREITAS (FAST COMPUTER)               *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.09         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 08 - CAD 50.292                                       *      */
        /*"      *               - AJUSTE NO LAYOUT DO ARQUIVO DE ENTRADA.        *      */
        /*"      *               - PASSA A TRATAR O DOMICILIO BANCARIO.           *      */
        /*"      *                                                                *      */
        /*"      *   EM 17/11/2010 - TERCIO FREITAS (FAST COMPUTER)               *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.08         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 07 - CAD 49.161                                       *      */
        /*"      *               - AJUSTE NA DATA DE MOVIMENTO.                   *      */
        /*"      *                                                                *      */
        /*"      *   EM 20/10/2010 - TERCIO FREITAS (FAST COMPUTER)               *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.07         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 06 - CAD 48.480                                       *      */
        /*"      *               - AJUSTE AO INSERIR NUM-TITULO NA TABELA         *      */
        /*"      *                 MOVCOB.                                        *      */
        /*"      *                                                                *      */
        /*"      *   EM 29/09/2010 - TERCIO FREITAS (FAST COMPUTER)               *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.06         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 05 - CAD 47.704                                       *      */
        /*"      *               - PASSA A TRATAR O ARQUIVO DE ENTRADA QUANDO O   *      */
        /*"      *                 MESMO ESTIVER VAZIO.                           *      */
        /*"      *                                                                *      */
        /*"      *   EM 16/09/2010 - TERCIO FREITAS (FAST COMPUTER)               *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.05         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ALTERACAO ..............  FAST   EM 31/08/2009    V.04       *      */
        /*"      *                             CADMUS 47034.                      *      */
        /*"      *                             PASSA A GERAR ARQUIVO DE SAIDA     *      */
        /*"      *                             DA COBRANCA.                       *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ALTERACAO ..............  FAST   EM 18/08/2009    V.03       *      */
        /*"      *                             CADMUS 45765.                      *      */
        /*"      *                             TRATA MOVIMENTO PROVENIENTE DA     *      */
        /*"      *                             SYSTEM CRED PARA O PROJETO         *      */
        /*"      *                             RETENCAO DE CLIENTES.              *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ALTERACAO ..............  FAST   EM 18/05/2009    V.02       *      */
        /*"      *                             CADMUS 24245.                      *      */
        /*"      *                             TRATA CODIGO RETORNO -803.         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ALTERACAO ..............  CLOVIS EM 13/11/2008    V.01       *      */
        /*"      *                             CADMUS 17209.                      *      */
        /*"      *                             TRATA DUPLICIDADE NO ARQUIVO       *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        #endregion


        #region VARIABLES

        public FileBasis _MOVIMENTO { get; set; } = new FileBasis(new PIC("X", "150", "X(150)"));

        public FileBasis MOVIMENTO
        {
            get
            {
                _.Move(MOVCC_REGISTRO, _MOVIMENTO); VarBasis.RedefinePassValue(MOVCC_REGISTRO, _MOVIMENTO, MOVCC_REGISTRO); return _MOVIMENTO;
            }
        }
        /*"01        MOVCC-REGISTRO.*/
        public BI0073B_MOVCC_REGISTRO MOVCC_REGISTRO { get; set; } = new BI0073B_MOVCC_REGISTRO();
        public class BI0073B_MOVCC_REGISTRO : VarBasis
        {
            /*"  05      MOVCC-CODREGISTRO  PIC  X(001).*/
            public StringBasis MOVCC_CODREGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  05      MOVCC-CTACOBRANCA.*/
            public BI0073B_MOVCC_CTACOBRANCA MOVCC_CTACOBRANCA { get; set; } = new BI0073B_MOVCC_CTACOBRANCA();
            public class BI0073B_MOVCC_CTACOBRANCA : VarBasis
            {
                /*"    10    MOVCC-AGENCIA      PIC  9(004).*/
                public IntBasis MOVCC_AGENCIA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10    MOVCC-OPERACAO     PIC  9(003).*/
                public IntBasis MOVCC_OPERACAO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"    10    MOVCC-NUMCTA       PIC  9(008).*/
                public IntBasis MOVCC_NUMCTA { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"    10    MOVCC-DIGCTA       PIC  9(001).*/
                public IntBasis MOVCC_DIGCTA { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    10    FILLER             PIC  X(004).*/
                public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)."), @"");
                /*"  05      MOVCC-DTPAGTO.*/
            }
            public BI0073B_MOVCC_DTPAGTO MOVCC_DTPAGTO { get; set; } = new BI0073B_MOVCC_DTPAGTO();
            public class BI0073B_MOVCC_DTPAGTO : VarBasis
            {
                /*"    10    MOVCC-ANOPAG       PIC  9(004).*/
                public IntBasis MOVCC_ANOPAG { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10    MOVCC-MESPAG       PIC  9(002).*/
                public IntBasis MOVCC_MESPAG { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10    MOVCC-DIAPAG       PIC  9(002).*/
                public IntBasis MOVCC_DIAPAG { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05      MOVCC-DTCREDITO.*/
            }
            public BI0073B_MOVCC_DTCREDITO MOVCC_DTCREDITO { get; set; } = new BI0073B_MOVCC_DTCREDITO();
            public class BI0073B_MOVCC_DTCREDITO : VarBasis
            {
                /*"    10    MOVCC-ANOCRE       PIC  9(004).*/
                public IntBasis MOVCC_ANOCRE { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10    MOVCC-MESCRE       PIC  9(002).*/
                public IntBasis MOVCC_MESCRE { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10    MOVCC-DIACRE       PIC  9(002).*/
                public IntBasis MOVCC_DIACRE { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05      MOVCC-CODBARRA.*/
            }
            public BI0073B_MOVCC_CODBARRA MOVCC_CODBARRA { get; set; } = new BI0073B_MOVCC_CODBARRA();
            public class BI0073B_MOVCC_CODBARRA : VarBasis
            {
                /*"    10    MOVCC-COD-BANCO    PIC  9(003).*/
                public IntBasis MOVCC_COD_BANCO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"    10    MOVCC-AGENCIA-DEB  PIC  9(004).*/
                public IntBasis MOVCC_AGENCIA_DEB { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10    MOVCC-OPERACAO-DEB PIC  9(004).*/
                public IntBasis MOVCC_OPERACAO_DEB { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10    MOVCC-NUMCTA-DEB   PIC  9(012).*/
                public IntBasis MOVCC_NUMCTA_DEB { get; set; } = new IntBasis(new PIC("9", "12", "9(012)."));
                /*"    10    MOVCC-DIGCTA-DEB   PIC  X(001).*/
                public StringBasis MOVCC_DIGCTA_DEB { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10    FILLER             PIC  X(001).*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10    MOVCC-NUM-PROPOSTA PIC  9(013).*/
                public IntBasis MOVCC_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
                /*"    10    MOVCC-NUM-PARCELA  PIC  9(004).*/
                public IntBasis MOVCC_NUM_PARCELA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10    MOVCC-BARRA3       PIC  X(004).*/
                public StringBasis MOVCC_BARRA3 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)."), @"");
                /*"  05      MOVCC-VLRPAGO      PIC  9(010)V99.*/
            }
            public DoubleBasis MOVCC_VLRPAGO { get; set; } = new DoubleBasis(new PIC("9", "10", "9(010)V99."), 2);
            /*"  05      MOVCC-VLRTARIFA    PIC  9(005)V99.*/
            public DoubleBasis MOVCC_VLRTARIFA { get; set; } = new DoubleBasis(new PIC("9", "5", "9(005)V99."), 2);
            /*"  05      MOVCC-NRSEQREG     PIC  9(008).*/
            public IntBasis MOVCC_NRSEQREG { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"  05      MOVCC-AGENCIA-ARREC PIC X(008).*/
            public StringBasis MOVCC_AGENCIA_ARREC { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"  05      MOVCC-FORMA-ARREC  PIC  X(001).*/
            public StringBasis MOVCC_FORMA_ARREC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  05      MOVCC-NUM-AUTENTIC.*/
            public BI0073B_MOVCC_NUM_AUTENTIC MOVCC_NUM_AUTENTIC { get; set; } = new BI0073B_MOVCC_NUM_AUTENTIC();
            public class BI0073B_MOVCC_NUM_AUTENTIC : VarBasis
            {
                /*"    10    MOVCC-NUM-CARTAO   PIC  9(016).*/
                public IntBasis MOVCC_NUM_CARTAO { get; set; } = new IntBasis(new PIC("9", "16", "9(016)."));
                /*"    10    MOVCC-COD-RETORNO  PIC  9(002).*/
                public IntBasis MOVCC_COD_RETORNO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10    MOVCC-RESERVADO    PIC  9(005).*/
                public IntBasis MOVCC_RESERVADO { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                /*"  05      MOVCC-FORMAPAG     PIC  9(001).*/
            }
            public IntBasis MOVCC_FORMAPAG { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"  05      FILLER             PIC  X(007).*/
            public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)."), @"");
        }

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77    VIND-NULL01               PIC S9(004)     COMP VALUE +0.*/
        public IntBasis VIND_NULL01 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-NULL02               PIC S9(004)     COMP VALUE +0.*/
        public IntBasis VIND_NULL02 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    WSHOST-NUMSIV01           PIC S9(015)     COMP-3.*/
        public IntBasis WSHOST_NUMSIV01 { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77    WSHOST-NUMSIV02           PIC S9(015)     COMP-3.*/
        public IntBasis WSHOST_NUMSIV02 { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77    WSHOST-COUNT              PIC S9(009)     COMP VALUE +0.*/
        public IntBasis WSHOST_COUNT { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    VIND-DTENVIO              PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis VIND_DTENVIO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-REQUISICAO           PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis VIND_REQUISICAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-SEQUENCIA            PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis VIND_SEQUENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-NUM-LOTE             PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis VIND_NUM_LOTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-DTCREDITO            PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis VIND_DTCREDITO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-STATUS               PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis VIND_STATUS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-VLCREDITO            PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis VIND_VLCREDITO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-CODRET               PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis VIND_CODRET { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01        HEADER-REGISTRO.*/
        public BI0073B_HEADER_REGISTRO HEADER_REGISTRO { get; set; } = new BI0073B_HEADER_REGISTRO();
        public class BI0073B_HEADER_REGISTRO : VarBasis
        {
            /*"  05      HEADER-CODREGISTRO  PIC  X(001).*/
            public StringBasis HEADER_CODREGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  05      HEADER-CODREMESSA   PIC  9(001).*/
            public IntBasis HEADER_CODREMESSA { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"  05      HEADER-CODCONVENIO  PIC  9(010).*/
            public IntBasis HEADER_CODCONVENIO { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
            /*"  05      FILLER              PIC  X(010).*/
            public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  05      HEADER-NOMEMPRESA   PIC  X(020).*/
            public StringBasis HEADER_NOMEMPRESA { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
            /*"  05      HEADER-CODBANCO     PIC  9(003).*/
            public IntBasis HEADER_CODBANCO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
            /*"  05      HEADER-NOMBANCO     PIC  X(020).*/
            public StringBasis HEADER_NOMBANCO { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
            /*"  05      HEADER-DATGERACAO.*/
            public BI0073B_HEADER_DATGERACAO HEADER_DATGERACAO { get; set; } = new BI0073B_HEADER_DATGERACAO();
            public class BI0073B_HEADER_DATGERACAO : VarBasis
            {
                /*"    10    HEADER-ANO          PIC  9(004).*/
                public IntBasis HEADER_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10    HEADER-MES          PIC  9(002).*/
                public IntBasis HEADER_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10    HEADER-DIA          PIC  9(002).*/
                public IntBasis HEADER_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05      HEADER-NSA          PIC  9(006).*/
            }
            public IntBasis HEADER_NSA { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"  05      HEADER-VERSAO       PIC  9(002).*/
            public IntBasis HEADER_VERSAO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"  05      FILLER              PIC  X(069).*/
            public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "69", "X(069)."), @"");
            /*"01        TRAILL-REGISTRO.*/
        }
        public BI0073B_TRAILL_REGISTRO TRAILL_REGISTRO { get; set; } = new BI0073B_TRAILL_REGISTRO();
        public class BI0073B_TRAILL_REGISTRO : VarBasis
        {
            /*"  05      TRAILL-CODREGISTRO  PIC  X(001).*/
            public StringBasis TRAILL_CODREGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  05      TRAILL-TOTREGISTRO  PIC  9(006).*/
            public IntBasis TRAILL_TOTREGISTRO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"  05      TRAILL-VLRTOTPAG    PIC  9(015)V99.*/
            public DoubleBasis TRAILL_VLRTOTPAG { get; set; } = new DoubleBasis(new PIC("9", "15", "9(015)V99."), 2);
            /*"  05      FILLER              PIC  X(126).*/
            public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "126", "X(126)."), @"");
            /*"01           AREA-DE-WORK.*/
        }
        public BI0073B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new BI0073B_AREA_DE_WORK();
        public class BI0073B_AREA_DE_WORK : VarBasis
        {
            /*"  03    W-NSAS                        PIC 9(006).*/
            public IntBasis W_NSAS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"  03    W-NSL                         PIC 9(006).*/
            public IntBasis W_NSL { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"  03    WS-COD-ERRO                   PIC 9(003)  VALUE ZEROS.*/
            public IntBasis WS_COD_ERRO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
            /*"  03    W-DATA-TRABALHO               PIC 9(008)  VALUE ZEROS.*/
            public IntBasis W_DATA_TRABALHO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"  03    FILLER REDEFINES W-DATA-TRABALHO.*/
            private _REDEF_BI0073B_FILLER_6 _filler_6 { get; set; }
            public _REDEF_BI0073B_FILLER_6 FILLER_6
            {
                get { _filler_6 = new _REDEF_BI0073B_FILLER_6(); _.Move(W_DATA_TRABALHO, _filler_6); VarBasis.RedefinePassValue(W_DATA_TRABALHO, _filler_6, W_DATA_TRABALHO); _filler_6.ValueChanged += () => { _.Move(_filler_6, W_DATA_TRABALHO); }; return _filler_6; }
                set { VarBasis.RedefinePassValue(value, _filler_6, W_DATA_TRABALHO); }
            }  //Redefines
            public class _REDEF_BI0073B_FILLER_6 : VarBasis
            {
                /*"        07  W-DIA-TRABALHO            PIC 9(002).*/
                public IntBasis W_DIA_TRABALHO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"        07  W-MES-TRABALHO            PIC 9(002).*/
                public IntBasis W_MES_TRABALHO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"        07  W-ANO-TRABALHO            PIC 9(004).*/
                public IntBasis W_ANO_TRABALHO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"  03    WDAT-REL-LIT                  PIC X(010).*/

                public _REDEF_BI0073B_FILLER_6()
                {
                    W_DIA_TRABALHO.ValueChanged += OnValueChanged;
                    W_MES_TRABALHO.ValueChanged += OnValueChanged;
                    W_ANO_TRABALHO.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WDAT_REL_LIT { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  03    FILLER REDEFINES WDAT-REL-LIT.*/
            private _REDEF_BI0073B_FILLER_7 _filler_7 { get; set; }
            public _REDEF_BI0073B_FILLER_7 FILLER_7
            {
                get { _filler_7 = new _REDEF_BI0073B_FILLER_7(); _.Move(WDAT_REL_LIT, _filler_7); VarBasis.RedefinePassValue(WDAT_REL_LIT, _filler_7, WDAT_REL_LIT); _filler_7.ValueChanged += () => { _.Move(_filler_7, WDAT_REL_LIT); }; return _filler_7; }
                set { VarBasis.RedefinePassValue(value, _filler_7, WDAT_REL_LIT); }
            }  //Redefines
            public class _REDEF_BI0073B_FILLER_7 : VarBasis
            {
                /*"        07  WDAT-LIT-DIA              PIC 9(002).*/
                public IntBasis WDAT_LIT_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"        07  W-BARRA3                  PIC X(001).*/
                public StringBasis W_BARRA3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"        07  WDAT-LIT-MES              PIC 9(002).*/
                public IntBasis WDAT_LIT_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"        07  W-BARRA4                  PIC X(001).*/
                public StringBasis W_BARRA4 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"        07  WDAT-LIT-ANO              PIC 9(004).*/
                public IntBasis WDAT_LIT_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"  03    W-DTMOVABE                    PIC X(010).*/

                public _REDEF_BI0073B_FILLER_7()
                {
                    WDAT_LIT_DIA.ValueChanged += OnValueChanged;
                    W_BARRA3.ValueChanged += OnValueChanged;
                    WDAT_LIT_MES.ValueChanged += OnValueChanged;
                    W_BARRA4.ValueChanged += OnValueChanged;
                    WDAT_LIT_ANO.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis W_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  03    W-DTMOVABE1 REDEFINES W-DTMOVABE.*/
            private _REDEF_BI0073B_W_DTMOVABE1 _w_dtmovabe1 { get; set; }
            public _REDEF_BI0073B_W_DTMOVABE1 W_DTMOVABE1
            {
                get { _w_dtmovabe1 = new _REDEF_BI0073B_W_DTMOVABE1(); _.Move(W_DTMOVABE, _w_dtmovabe1); VarBasis.RedefinePassValue(W_DTMOVABE, _w_dtmovabe1, W_DTMOVABE); _w_dtmovabe1.ValueChanged += () => { _.Move(_w_dtmovabe1, W_DTMOVABE); }; return _w_dtmovabe1; }
                set { VarBasis.RedefinePassValue(value, _w_dtmovabe1, W_DTMOVABE); }
            }  //Redefines
            public class _REDEF_BI0073B_W_DTMOVABE1 : VarBasis
            {
                /*"        07  W-ANO-MOVABE              PIC 9(004).*/
                public IntBasis W_ANO_MOVABE { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"        07  W-BARRA1                  PIC X(001).*/
                public StringBasis W_BARRA1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"        07  W-MES-MOVABE              PIC 9(002).*/
                public IntBasis W_MES_MOVABE { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"        07  W-BARRA2                  PIC X(001).*/
                public StringBasis W_BARRA2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"        07  W-DIA-MOVABE              PIC 9(002).*/
                public IntBasis W_DIA_MOVABE { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03    W-DATA-SQL                    PIC X(010).*/

                public _REDEF_BI0073B_W_DTMOVABE1()
                {
                    W_ANO_MOVABE.ValueChanged += OnValueChanged;
                    W_BARRA1.ValueChanged += OnValueChanged;
                    W_MES_MOVABE.ValueChanged += OnValueChanged;
                    W_BARRA2.ValueChanged += OnValueChanged;
                    W_DIA_MOVABE.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis W_DATA_SQL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  03    W-DATA-SQL1 REDEFINES W-DATA-SQL.*/
            private _REDEF_BI0073B_W_DATA_SQL1 _w_data_sql1 { get; set; }
            public _REDEF_BI0073B_W_DATA_SQL1 W_DATA_SQL1
            {
                get { _w_data_sql1 = new _REDEF_BI0073B_W_DATA_SQL1(); _.Move(W_DATA_SQL, _w_data_sql1); VarBasis.RedefinePassValue(W_DATA_SQL, _w_data_sql1, W_DATA_SQL); _w_data_sql1.ValueChanged += () => { _.Move(_w_data_sql1, W_DATA_SQL); }; return _w_data_sql1; }
                set { VarBasis.RedefinePassValue(value, _w_data_sql1, W_DATA_SQL); }
            }  //Redefines
            public class _REDEF_BI0073B_W_DATA_SQL1 : VarBasis
            {
                /*"        07  W-ANO-SQL                 PIC 9(004).*/
                public IntBasis W_ANO_SQL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"        07  W-BARRA1                  PIC X(001).*/
                public StringBasis W_BARRA1_0 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"        07  W-MES-SQL                 PIC 9(002).*/
                public IntBasis W_MES_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"        07  W-BARRA2                  PIC X(001).*/
                public StringBasis W_BARRA2_0 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"        07  W-DIA-SQL                 PIC 9(002).*/
                public IntBasis W_DIA_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03         W-QTD-LD-TIPO-0        PIC  9(08)  VALUE ZEROS.*/

                public _REDEF_BI0073B_W_DATA_SQL1()
                {
                    W_ANO_SQL.ValueChanged += OnValueChanged;
                    W_BARRA1_0.ValueChanged += OnValueChanged;
                    W_MES_SQL.ValueChanged += OnValueChanged;
                    W_BARRA2_0.ValueChanged += OnValueChanged;
                    W_DIA_SQL.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis W_QTD_LD_TIPO_0 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"  03         W-QTD-LD-TIPO-1        PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_TIPO_1 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"  03         W-QTD-LD-TIPO-2        PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_TIPO_2 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"  03         W-QTD-LD-TIPO-3        PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_TIPO_3 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"  03         W-QTD-LD-TIPO-4        PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_TIPO_4 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"  03         W-QTD-LD-TIPO-5        PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_TIPO_5 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"  03         W-QTD-LD-TIPO-6        PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_TIPO_6 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"  03         W-QTD-LD-TIPO-7        PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_TIPO_7 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"  03         W-QTD-LD-TIPO-8        PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_TIPO_8 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"  03         W-QTD-LD-TIPO-9        PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_TIPO_9 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"  03         W-ABEND-CTR            PIC  9(06)  VALUE ZEROS.*/
            public IntBasis W_ABEND_CTR { get; set; } = new IntBasis(new PIC("9", "6", "9(06)"));
            /*"  03         WTEM-CONVERSI     PIC  X(003)    VALUE SPACES.*/
            public StringBasis WTEM_CONVERSI { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"  03         WFIM-MOVIMENTO    PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  03         LD-ENTRADA        PIC  9(007)    VALUE ZEROS.*/
            public IntBasis LD_ENTRADA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03         LD-HEADER         PIC  9(007)    VALUE ZEROS.*/
            public IntBasis LD_HEADER { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03         LD-TRAILLER       PIC  9(007)    VALUE ZEROS.*/
            public IntBasis LD_TRAILLER { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03         LD-DETALHE        PIC  9(007)    VALUE ZEROS.*/
            public IntBasis LD_DETALHE { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03         DP-ENTRADA        PIC  9(007)    VALUE ZEROS.*/
            public IntBasis DP_ENTRADA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03         NT-BILHETE        PIC  9(007)    VALUE ZEROS.*/
            public IntBasis NT_BILHETE { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03         AC-MOVIMCOB       PIC  9(007)    VALUE ZEROS.*/
            public IntBasis AC_MOVIMCOB { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03         AC-CONVERSI       PIC  9(007)    VALUE ZEROS.*/
            public IntBasis AC_CONVERSI { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03         AC-BILHETE        PIC  9(007)    VALUE ZEROS.*/
            public IntBasis AC_BILHETE { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03         WS-RESULT         PIC  9(006)    VALUE ZEROS.*/
            public IntBasis WS_RESULT { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  03         WS-RESTO          PIC  9(004)    VALUE ZEROS.*/
            public IntBasis WS_RESTO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  03         WPARM13-AUX       PIC S9(007) VALUE ZEROS COMP-3.*/
            public IntBasis WPARM13_AUX { get; set; } = new IntBasis(new PIC("S9", "7", "S9(007)"));
            /*"  03         WPARM11-AUX       PIC S9(007) VALUE ZEROS COMP-3.*/
            public IntBasis WPARM11_AUX { get; set; } = new IntBasis(new PIC("S9", "7", "S9(007)"));
            /*"  03         WDATA-REL         PIC  X(010)    VALUE SPACES.*/
            public StringBasis WDATA_REL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  03         FILLER            REDEFINES      WDATA-REL.*/
            private _REDEF_BI0073B_FILLER_8 _filler_8 { get; set; }
            public _REDEF_BI0073B_FILLER_8 FILLER_8
            {
                get { _filler_8 = new _REDEF_BI0073B_FILLER_8(); _.Move(WDATA_REL, _filler_8); VarBasis.RedefinePassValue(WDATA_REL, _filler_8, WDATA_REL); _filler_8.ValueChanged += () => { _.Move(_filler_8, WDATA_REL); }; return _filler_8; }
                set { VarBasis.RedefinePassValue(value, _filler_8, WDATA_REL); }
            }  //Redefines
            public class _REDEF_BI0073B_FILLER_8 : VarBasis
            {
                /*"    10       WDAT-REL-ANO      PIC  9(004).*/
                public IntBasis WDAT_REL_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDAT-REL-MES      PIC  9(002).*/
                public IntBasis WDAT_REL_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDAT-REL-DIA      PIC  9(002).*/
                public IntBasis WDAT_REL_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03         WS-NRAVISO        PIC  9(009)    VALUE  ZEROS.*/

                public _REDEF_BI0073B_FILLER_8()
                {
                    WDAT_REL_ANO.ValueChanged += OnValueChanged;
                    FILLER_9.ValueChanged += OnValueChanged;
                    WDAT_REL_MES.ValueChanged += OnValueChanged;
                    FILLER_10.ValueChanged += OnValueChanged;
                    WDAT_REL_DIA.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WS_NRAVISO { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03         FILLER            REDEFINES      WS-NRAVISO.*/
            private _REDEF_BI0073B_FILLER_11 _filler_11 { get; set; }
            public _REDEF_BI0073B_FILLER_11 FILLER_11
            {
                get { _filler_11 = new _REDEF_BI0073B_FILLER_11(); _.Move(WS_NRAVISO, _filler_11); VarBasis.RedefinePassValue(WS_NRAVISO, _filler_11, WS_NRAVISO); _filler_11.ValueChanged += () => { _.Move(_filler_11, WS_NRAVISO); }; return _filler_11; }
                set { VarBasis.RedefinePassValue(value, _filler_11, WS_NRAVISO); }
            }  //Redefines
            public class _REDEF_BI0073B_FILLER_11 : VarBasis
            {
                /*"      10     WS-AUXAVISO       PIC  9(004).*/
                public IntBasis WS_AUXAVISO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      10     WS-AUXNSAS        PIC  9(005).*/
                public IntBasis WS_AUXNSAS { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                /*"  03         WS-NRTIT          PIC  9(014)    VALUE  ZEROS.*/

                public _REDEF_BI0073B_FILLER_11()
                {
                    WS_AUXAVISO.ValueChanged += OnValueChanged;
                    WS_AUXNSAS.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WS_NRTIT { get; set; } = new IntBasis(new PIC("9", "14", "9(014)"));
            /*"  03         FILLER            REDEFINES      WS-NRTIT.*/
            private _REDEF_BI0073B_FILLER_12 _filler_12 { get; set; }
            public _REDEF_BI0073B_FILLER_12 FILLER_12
            {
                get { _filler_12 = new _REDEF_BI0073B_FILLER_12(); _.Move(WS_NRTIT, _filler_12); VarBasis.RedefinePassValue(WS_NRTIT, _filler_12, WS_NRTIT); _filler_12.ValueChanged += () => { _.Move(_filler_12, WS_NRTIT); }; return _filler_12; }
                set { VarBasis.RedefinePassValue(value, _filler_12, WS_NRTIT); }
            }  //Redefines
            public class _REDEF_BI0073B_FILLER_12 : VarBasis
            {
                /*"      10     WS-NUMTIT         PIC  9(013).*/
                public IntBasis WS_NUMTIT { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
                /*"      10     WS-DIGTIT         PIC  9(001).*/
                public IntBasis WS_DIGTIT { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"  03         WWORK-MIN-NRTIT   PIC  9(011)    VALUE  ZEROS.*/

                public _REDEF_BI0073B_FILLER_12()
                {
                    WS_NUMTIT.ValueChanged += OnValueChanged;
                    WS_DIGTIT.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WWORK_MIN_NRTIT { get; set; } = new IntBasis(new PIC("9", "11", "9(011)"));
            /*"  03         FILLER            REDEFINES      WWORK-MIN-NRTIT.*/
            private _REDEF_BI0073B_FILLER_13 _filler_13 { get; set; }
            public _REDEF_BI0073B_FILLER_13 FILLER_13
            {
                get { _filler_13 = new _REDEF_BI0073B_FILLER_13(); _.Move(WWORK_MIN_NRTIT, _filler_13); VarBasis.RedefinePassValue(WWORK_MIN_NRTIT, _filler_13, WWORK_MIN_NRTIT); _filler_13.ValueChanged += () => { _.Move(_filler_13, WWORK_MIN_NRTIT); }; return _filler_13; }
                set { VarBasis.RedefinePassValue(value, _filler_13, WWORK_MIN_NRTIT); }
            }  //Redefines
            public class _REDEF_BI0073B_FILLER_13 : VarBasis
            {
                /*"    10       WWORK-MINNRO      PIC  9(010).*/
                public IntBasis WWORK_MINNRO { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
                /*"    10       WWORK-MINDIG      PIC  9(001).*/
                public IntBasis WWORK_MINDIG { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"  03         WWORK-MAX-NRTIT   PIC  9(011)    VALUE  ZEROS.*/

                public _REDEF_BI0073B_FILLER_13()
                {
                    WWORK_MINNRO.ValueChanged += OnValueChanged;
                    WWORK_MINDIG.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WWORK_MAX_NRTIT { get; set; } = new IntBasis(new PIC("9", "11", "9(011)"));
            /*"  03         FILLER            REDEFINES      WWORK-MAX-NRTIT.*/
            private _REDEF_BI0073B_FILLER_14 _filler_14 { get; set; }
            public _REDEF_BI0073B_FILLER_14 FILLER_14
            {
                get { _filler_14 = new _REDEF_BI0073B_FILLER_14(); _.Move(WWORK_MAX_NRTIT, _filler_14); VarBasis.RedefinePassValue(WWORK_MAX_NRTIT, _filler_14, WWORK_MAX_NRTIT); _filler_14.ValueChanged += () => { _.Move(_filler_14, WWORK_MAX_NRTIT); }; return _filler_14; }
                set { VarBasis.RedefinePassValue(value, _filler_14, WWORK_MAX_NRTIT); }
            }  //Redefines
            public class _REDEF_BI0073B_FILLER_14 : VarBasis
            {
                /*"    10       WWORK-MAXNRO      PIC  9(010).*/
                public IntBasis WWORK_MAXNRO { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
                /*"    10       WWORK-MAXDIG      PIC  9(001).*/
                public IntBasis WWORK_MAXDIG { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"  03        WABEND.*/

                public _REDEF_BI0073B_FILLER_14()
                {
                    WWORK_MAXNRO.ValueChanged += OnValueChanged;
                    WWORK_MAXDIG.ValueChanged += OnValueChanged;
                }

            }
            public BI0073B_WABEND WABEND { get; set; } = new BI0073B_WABEND();
            public class BI0073B_WABEND : VarBasis
            {
                /*"    10      FILLER              PIC  X(010) VALUE           ' BI0073B'.*/
                public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" BI0073B");
                /*"    05      FILLER              PIC  X(028) VALUE           ' *** ERRO  EXEC SQL  NUMERO '.*/
                public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @" *** ERRO  EXEC SQL  NUMERO ");
                /*"    05      WNR-EXEC-SQL        PIC  X(004) VALUE    SPACES.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                /*"    05      FILLER              PIC  X(014) VALUE           '    SQLCODE = '.*/
                public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE = ");
                /*"    05      WSQLCODE            PIC  ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                /*"    05      FILLER              PIC  X(014) VALUE           '   SQLERRD1 = '.*/
                public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD1 = ");
                /*"    05      WSQLERRD1           PIC  ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLERRD1 { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                /*"    05      FILLER              PIC  X(014) VALUE           '   SQLERRD2 = '.*/
                public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD2 = ");
                /*"    05      WSQLERRD2           PIC  ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLERRD2 { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                /*"  03        WSQLERR.*/
            }
            public BI0073B_WSQLERR WSQLERR { get; set; } = new BI0073B_WSQLERR();
            public class BI0073B_WSQLERR : VarBasis
            {
                /*"    05      FILLER              PIC  X(014) VALUE           ' *** SQLERRMC '.*/
                public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @" *** SQLERRMC ");
                /*"    05      WSQLERRMC           PIC  X(070) VALUE SPACES.*/
                public StringBasis WSQLERRMC { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"");
                /*"01             LPARM11X.*/
            }
        }
        public BI0073B_LPARM11X LPARM11X { get; set; } = new BI0073B_LPARM11X();
        public class BI0073B_LPARM11X : VarBasis
        {
            /*"  03           LPARM11            PIC  9(010).*/
            public IntBasis LPARM11 { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
            /*"  03           FILLER             REDEFINES   LPARM11.*/
            private _REDEF_BI0073B_FILLER_21 _filler_21 { get; set; }
            public _REDEF_BI0073B_FILLER_21 FILLER_21
            {
                get { _filler_21 = new _REDEF_BI0073B_FILLER_21(); _.Move(LPARM11, _filler_21); VarBasis.RedefinePassValue(LPARM11, _filler_21, LPARM11); _filler_21.ValueChanged += () => { _.Move(_filler_21, LPARM11); }; return _filler_21; }
                set { VarBasis.RedefinePassValue(value, _filler_21, LPARM11); }
            }  //Redefines
            public class _REDEF_BI0073B_FILLER_21 : VarBasis
            {
                /*"    05         LPARM11-1          PIC  9(001).*/
                public IntBasis LPARM11_1 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    05         LPARM11-2          PIC  9(001).*/
                public IntBasis LPARM11_2 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    05         LPARM11-3          PIC  9(001).*/
                public IntBasis LPARM11_3 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    05         LPARM11-4          PIC  9(001).*/
                public IntBasis LPARM11_4 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    05         LPARM11-5          PIC  9(001).*/
                public IntBasis LPARM11_5 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    05         LPARM11-6          PIC  9(001).*/
                public IntBasis LPARM11_6 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    05         LPARM11-7          PIC  9(001).*/
                public IntBasis LPARM11_7 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    05         LPARM11-8          PIC  9(001).*/
                public IntBasis LPARM11_8 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    05         LPARM11-9          PIC  9(001).*/
                public IntBasis LPARM11_9 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    05         LPARM11-10         PIC  9(001).*/
                public IntBasis LPARM11_10 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"01             LPARM13X.*/

                public _REDEF_BI0073B_FILLER_21()
                {
                    LPARM11_1.ValueChanged += OnValueChanged;
                    LPARM11_2.ValueChanged += OnValueChanged;
                    LPARM11_3.ValueChanged += OnValueChanged;
                    LPARM11_4.ValueChanged += OnValueChanged;
                    LPARM11_5.ValueChanged += OnValueChanged;
                    LPARM11_6.ValueChanged += OnValueChanged;
                    LPARM11_7.ValueChanged += OnValueChanged;
                    LPARM11_8.ValueChanged += OnValueChanged;
                    LPARM11_9.ValueChanged += OnValueChanged;
                    LPARM11_10.ValueChanged += OnValueChanged;
                }

            }
        }
        public BI0073B_LPARM13X LPARM13X { get; set; } = new BI0073B_LPARM13X();
        public class BI0073B_LPARM13X : VarBasis
        {
            /*"  03           LPARM13            PIC  9(013).*/
            public IntBasis LPARM13 { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
            /*"  03           FILLER             REDEFINES   LPARM13.*/
            private _REDEF_BI0073B_FILLER_22 _filler_22 { get; set; }
            public _REDEF_BI0073B_FILLER_22 FILLER_22
            {
                get { _filler_22 = new _REDEF_BI0073B_FILLER_22(); _.Move(LPARM13, _filler_22); VarBasis.RedefinePassValue(LPARM13, _filler_22, LPARM13); _filler_22.ValueChanged += () => { _.Move(_filler_22, LPARM13); }; return _filler_22; }
                set { VarBasis.RedefinePassValue(value, _filler_22, LPARM13); }
            }  //Redefines
            public class _REDEF_BI0073B_FILLER_22 : VarBasis
            {
                /*"    05         LPARM13-1          PIC  9(001).*/
                public IntBasis LPARM13_1 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    05         LPARM13-2          PIC  9(001).*/
                public IntBasis LPARM13_2 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    05         LPARM13-3          PIC  9(001).*/
                public IntBasis LPARM13_3 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    05         LPARM13-4          PIC  9(001).*/
                public IntBasis LPARM13_4 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    05         LPARM13-5          PIC  9(001).*/
                public IntBasis LPARM13_5 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    05         LPARM13-6          PIC  9(001).*/
                public IntBasis LPARM13_6 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    05         LPARM13-7          PIC  9(001).*/
                public IntBasis LPARM13_7 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    05         LPARM13-8          PIC  9(001).*/
                public IntBasis LPARM13_8 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    05         LPARM13-9          PIC  9(001).*/
                public IntBasis LPARM13_9 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    05         LPARM13-10         PIC  9(001).*/
                public IntBasis LPARM13_10 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    05         LPARM13-11         PIC  9(001).*/
                public IntBasis LPARM13_11 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    05         LPARM13-12         PIC  9(001).*/
                public IntBasis LPARM13_12 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    05         LPARM13-13         PIC  9(001).*/
                public IntBasis LPARM13_13 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));

                public _REDEF_BI0073B_FILLER_22()
                {
                    LPARM13_1.ValueChanged += OnValueChanged;
                    LPARM13_2.ValueChanged += OnValueChanged;
                    LPARM13_3.ValueChanged += OnValueChanged;
                    LPARM13_4.ValueChanged += OnValueChanged;
                    LPARM13_5.ValueChanged += OnValueChanged;
                    LPARM13_6.ValueChanged += OnValueChanged;
                    LPARM13_7.ValueChanged += OnValueChanged;
                    LPARM13_8.ValueChanged += OnValueChanged;
                    LPARM13_9.ValueChanged += OnValueChanged;
                    LPARM13_10.ValueChanged += OnValueChanged;
                    LPARM13_11.ValueChanged += OnValueChanged;
                    LPARM13_12.ValueChanged += OnValueChanged;
                    LPARM13_13.ValueChanged += OnValueChanged;
                }

            }
        }


        public Copies.LBFCT011 LBFCT011 { get; set; } = new Copies.LBFCT011();
        public Copies.LBFCT016 LBFCT016 { get; set; } = new Copies.LBFCT016();
        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.MOVIMCOB MOVIMCOB { get; set; } = new Dclgens.MOVIMCOB();
        public Dclgens.CONVERSI CONVERSI { get; set; } = new Dclgens.CONVERSI();
        public Dclgens.BILHETE BILHETE { get; set; } = new Dclgens.BILHETE();
        public Dclgens.CEDENTE CEDENTE { get; set; } = new Dclgens.CEDENTE();
        public Dclgens.PROPOFID PROPOFID { get; set; } = new Dclgens.PROPOFID();
        public Dclgens.CODERRBI CODERRBI { get; set; } = new Dclgens.CODERRBI();
        public Dclgens.ARQSIVPF ARQSIVPF { get; set; } = new Dclgens.ARQSIVPF();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string MOVIMENTO_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                MOVIMENTO.SetFile(MOVIMENTO_FILE_NAME_P);

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
            /*" -449- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -452- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -455- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -458- DISPLAY '------------------------------' */
            _.Display($"------------------------------");

            /*" -459- DISPLAY 'PROGRAMA EM EXECUCAO BI0073B  ' */
            _.Display($"PROGRAMA EM EXECUCAO BI0073B  ");

            /*" -460- DISPLAY '                              ' */
            _.Display($"                              ");

            /*" -471- DISPLAY 'VERSAO V.14 AVISO  11/08/2015 ' */
            _.Display($"VERSAO V.14 AVISO  11/08/2015 ");

            /*" -472- DISPLAY '------------------------------' . */
            _.Display($"------------------------------");

            /*" -474- DISPLAY ' ' . */
            _.Display($" ");

            /*" -476- PERFORM R0020-00-OBTER-MAX-NSAS */

            R0020_00_OBTER_MAX_NSAS_SECTION();

            /*" -478- PERFORM R0050-00-INICIO. */

            R0050_00_INICIO_SECTION();

            /*" -480- PERFORM R0080-00-GERAR-HEADER */

            R0080_00_GERAR_HEADER_SECTION();

            /*" -480- PERFORM R0300-00-SELECIONA. */

            R0300_00_SELECIONA_SECTION();

            /*" -0- FLUXCONTROL_PERFORM R0000_90_FINALIZA */

            R0000_90_FINALIZA();

        }

        [StopWatch]
        /*" R0000-90-FINALIZA */
        private void R0000_90_FINALIZA(bool isPerform = false)
        {
            /*" -484- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -488- PERFORM R0800-00-GERAR-TRAILLER. */

            R0800_00_GERAR_TRAILLER_SECTION();

            /*" -490- PERFORM R0850-00-CONTROLAR-ARQ-ENVIADO. */

            R0850_00_CONTROLAR_ARQ_ENVIADO_SECTION();

            /*" -493- CLOSE MOVIMENTO. */
            MOVIMENTO.Close();

            /*" -495- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -495- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0020-00-OBTER-MAX-NSAS-SECTION */
        private void R0020_00_OBTER_MAX_NSAS_SECTION()
        {
            /*" -505- MOVE '0050' TO WNR-EXEC-SQL. */
            _.Move("0050", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -508- MOVE 'STASCADE' TO ARQSIVPF-SIGLA-ARQUIVO */
            _.Move("STASCADE", ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SIGLA_ARQUIVO);

            /*" -511- MOVE 4 TO ARQSIVPF-SISTEMA-ORIGEM */
            _.Move(4, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SISTEMA_ORIGEM);

            /*" -519- PERFORM R0020_00_OBTER_MAX_NSAS_DB_SELECT_1 */

            R0020_00_OBTER_MAX_NSAS_DB_SELECT_1();

            /*" -522- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -523- DISPLAY 'BI3605B - FIM ANORMAL' */
                _.Display($"BI3605B - FIM ANORMAL");

                /*" -524- DISPLAY '          ERRO SELECT MAX ARQUIVOS-SIVPF' */
                _.Display($"          ERRO SELECT MAX ARQUIVOS-SIVPF");

                /*" -526- DISPLAY '          SQLCODE....................... ' SQLCODE */
                _.Display($"          SQLCODE....................... {DB.SQLCODE}");

                /*" -528- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -531- MOVE ARQSIVPF-NSAS-SIVPF TO W-NSAS. */
            _.Move(ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF, AREA_DE_WORK.W_NSAS);

            /*" -533- ADD 1 TO W-NSAS. */
            AREA_DE_WORK.W_NSAS.Value = AREA_DE_WORK.W_NSAS + 1;

            /*" -534- MOVE W-NSAS TO ARQSIVPF-NSAS-SIVPF. */
            _.Move(AREA_DE_WORK.W_NSAS, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF);

        }

        [StopWatch]
        /*" R0020-00-OBTER-MAX-NSAS-DB-SELECT-1 */
        public void R0020_00_OBTER_MAX_NSAS_DB_SELECT_1()
        {
            /*" -519- EXEC SQL SELECT VALUE(MAX(NSAS_SIVPF),0) INTO :ARQSIVPF-NSAS-SIVPF FROM SEGUROS.ARQUIVOS_SIVPF WHERE SIGLA_ARQUIVO = :ARQSIVPF-SIGLA-ARQUIVO AND SISTEMA_ORIGEM = :ARQSIVPF-SISTEMA-ORIGEM END-EXEC. */

            var r0020_00_OBTER_MAX_NSAS_DB_SELECT_1_Query1 = new R0020_00_OBTER_MAX_NSAS_DB_SELECT_1_Query1()
            {
                ARQSIVPF_SISTEMA_ORIGEM = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SISTEMA_ORIGEM.ToString(),
                ARQSIVPF_SIGLA_ARQUIVO = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SIGLA_ARQUIVO.ToString(),
            };

            var executed_1 = R0020_00_OBTER_MAX_NSAS_DB_SELECT_1_Query1.Execute(r0020_00_OBTER_MAX_NSAS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.ARQSIVPF_NSAS_SIVPF, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0020_SAIDA*/

        [StopWatch]
        /*" R0050-00-INICIO-SECTION */
        private void R0050_00_INICIO_SECTION()
        {
            /*" -544- MOVE '0050' TO WNR-EXEC-SQL. */
            _.Move("0050", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -547- OPEN INPUT MOVIMENTO. */
            MOVIMENTO.Open(MOVCC_REGISTRO);

            /*" -553- PERFORM R0100-00-SELECT-V0SISTEMA. */

            R0100_00_SELECT_V0SISTEMA_SECTION();

            /*" -553- PERFORM R0150-00-SELECT-MOVIMCOB. */

            R0150_00_SELECT_MOVIMCOB_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0050_99_SAIDA*/

        [StopWatch]
        /*" R0080-00-GERAR-HEADER-SECTION */
        private void R0080_00_GERAR_HEADER_SECTION()
        {
            /*" -564- MOVE '0080' TO WNR-EXEC-SQL. */
            _.Move("0080", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -566- MOVE SPACES TO REG-HEADER-STA. */
            _.Move("", LBFCT011.REG_HEADER_STA);

            /*" -568- MOVE 'H' TO RH-TIPO-REG */
            _.Move("H", LBFCT011.REG_HEADER_STA.RH_TIPO_REG);

            /*" -570- MOVE 'STASCADE' TO RH-NOME-EMPRESA */
            _.Move("STASCADE", LBFCT011.REG_HEADER_STA.RH_NOME_EMPRESA);

            /*" -571- MOVE W-DIA-MOVABE TO W-DIA-TRABALHO */
            _.Move(AREA_DE_WORK.W_DTMOVABE1.W_DIA_MOVABE, AREA_DE_WORK.FILLER_6.W_DIA_TRABALHO);

            /*" -572- MOVE W-MES-MOVABE TO W-MES-TRABALHO */
            _.Move(AREA_DE_WORK.W_DTMOVABE1.W_MES_MOVABE, AREA_DE_WORK.FILLER_6.W_MES_TRABALHO);

            /*" -574- MOVE W-ANO-MOVABE TO W-ANO-TRABALHO */
            _.Move(AREA_DE_WORK.W_DTMOVABE1.W_ANO_MOVABE, AREA_DE_WORK.FILLER_6.W_ANO_TRABALHO);

            /*" -576- MOVE W-DATA-TRABALHO TO RH-DATA-GERACAO */
            _.Move(AREA_DE_WORK.W_DATA_TRABALHO, LBFCT011.REG_HEADER_STA.RH_DATA_GERACAO);

            /*" -578- MOVE 4 TO RH-SIST-ORIGEM */
            _.Move(4, LBFCT011.REG_HEADER_STA.RH_SIST_ORIGEM);

            /*" -580- MOVE 1 TO RH-SIST-DESTINO */
            _.Move(1, LBFCT011.REG_HEADER_STA.RH_SIST_DESTINO);

            /*" -580- MOVE ARQSIVPF-NSAS-SIVPF TO RH-NSAS. */
            _.Move(ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF, LBFCT011.REG_HEADER_STA.RH_NSAS);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0080_SAIDA*/

        [StopWatch]
        /*" R0100-00-SELECT-V0SISTEMA-SECTION */
        private void R0100_00_SELECT_V0SISTEMA_SECTION()
        {
            /*" -591- MOVE '0100' TO WNR-EXEC-SQL. */
            _.Move("0100", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -597- PERFORM R0100_00_SELECT_V0SISTEMA_DB_SELECT_1 */

            R0100_00_SELECT_V0SISTEMA_DB_SELECT_1();

            /*" -600- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -601- DISPLAY 'R0100-00 - PROBLEMAS NO SELECT(SISTEMAS)' */
                _.Display($"R0100-00 - PROBLEMAS NO SELECT(SISTEMAS)");

                /*" -603- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -607- MOVE SISTEMAS-DATA-MOV-ABERTO TO WDATA-REL W-DTMOVABE. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, AREA_DE_WORK.WDATA_REL, AREA_DE_WORK.W_DTMOVABE);

            /*" -609- DISPLAY ' DATA DO PROCESSAMENTO ...............  ' SISTEMAS-DATA-MOV-ABERTO. */
            _.Display($" DATA DO PROCESSAMENTO ...............  {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}");

            /*" -609- DISPLAY ' ' . */
            _.Display($" ");

        }

        [StopWatch]
        /*" R0100-00-SELECT-V0SISTEMA-DB-SELECT-1 */
        public void R0100_00_SELECT_V0SISTEMA_DB_SELECT_1()
        {
            /*" -597- EXEC SQL SELECT DATA_MOV_ABERTO INTO :SISTEMAS-DATA-MOV-ABERTO FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'CB' WITH UR END-EXEC. */

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
        /*" R0150-00-SELECT-MOVIMCOB-SECTION */
        private void R0150_00_SELECT_MOVIMCOB_SECTION()
        {
            /*" -619- MOVE '0150' TO WNR-EXEC-SQL. */
            _.Move("0150", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -621- MOVE 104 TO MOVIMCOB-COD-BANCO. */
            _.Move(104, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_BANCO);

            /*" -624- MOVE 9581 TO MOVIMCOB-COD-AGENCIA. */
            _.Move(9581, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_AGENCIA);

            /*" -635- PERFORM R0150_00_SELECT_MOVIMCOB_DB_SELECT_1 */

            R0150_00_SELECT_MOVIMCOB_DB_SELECT_1();

            /*" -638- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -640- MOVE 802800001 TO WS-NRAVISO */
                _.Move(802800001, AREA_DE_WORK.WS_NRAVISO);

                /*" -641- ELSE */
            }
            else
            {


                /*" -642- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -643- DISPLAY 'R0150-00 - PROBLEMAS NO SELECT MOVIMCOB' */
                    _.Display($"R0150-00 - PROBLEMAS NO SELECT MOVIMCOB");

                    /*" -644- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -645- ELSE */
                }
                else
                {


                    /*" -646- IF VIND-NULL01 LESS ZEROS */

                    if (VIND_NULL01 < 00)
                    {

                        /*" -648- MOVE 802800001 TO WS-NRAVISO */
                        _.Move(802800001, AREA_DE_WORK.WS_NRAVISO);

                        /*" -649- ELSE */
                    }
                    else
                    {


                        /*" -651- MOVE MOVIMCOB-NUM-AVISO TO WS-NRAVISO */
                        _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_AVISO, AREA_DE_WORK.WS_NRAVISO);

                        /*" -655- ADD 1 TO WS-NRAVISO. */
                        AREA_DE_WORK.WS_NRAVISO.Value = AREA_DE_WORK.WS_NRAVISO + 1;
                    }

                }

            }


            /*" -656- IF WS-NRAVISO GREATER 802899999 */

            if (AREA_DE_WORK.WS_NRAVISO > 802899999)
            {

                /*" -657- DISPLAY 'R0150-00 - AVISO EXCEDE VALOR MAXIMO   ' */
                _.Display($"R0150-00 - AVISO EXCEDE VALOR MAXIMO   ");

                /*" -659- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0150-00-SELECT-MOVIMCOB-DB-SELECT-1 */
        public void R0150_00_SELECT_MOVIMCOB_DB_SELECT_1()
        {
            /*" -635- EXEC SQL SELECT MAX(NUM_AVISO) INTO :MOVIMCOB-NUM-AVISO:VIND-NULL01 FROM SEGUROS.MOVIMENTO_COBRANCA WHERE COD_BANCO = :MOVIMCOB-COD-BANCO AND COD_AGENCIA = :MOVIMCOB-COD-AGENCIA AND NUM_AVISO >= 802800000 AND NUM_AVISO <= 802899999 WITH UR END-EXEC. */

            var r0150_00_SELECT_MOVIMCOB_DB_SELECT_1_Query1 = new R0150_00_SELECT_MOVIMCOB_DB_SELECT_1_Query1()
            {
                MOVIMCOB_COD_AGENCIA = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_AGENCIA.ToString(),
                MOVIMCOB_COD_BANCO = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_BANCO.ToString(),
            };

            var executed_1 = R0150_00_SELECT_MOVIMCOB_DB_SELECT_1_Query1.Execute(r0150_00_SELECT_MOVIMCOB_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.MOVIMCOB_NUM_AVISO, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_AVISO);
                _.Move(executed_1.VIND_NULL01, VIND_NULL01);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0150_99_SAIDA*/

        [StopWatch]
        /*" R0190-00-GERAR-REGISTRO-TP1-SECTION */
        private void R0190_00_GERAR_REGISTRO_TP1_SECTION()
        {
            /*" -669- MOVE '0190' TO WNR-EXEC-SQL. */
            _.Move("0190", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -671- MOVE SPACES TO REG-STA-PROPOSTA. */
            _.Move("", LBFCT011.REG_STA_PROPOSTA);

            /*" -673- MOVE '1' TO R1-TIPO-REG */
            _.Move("1", LBFCT011.REG_STA_PROPOSTA.R1_TIPO_REG);

            /*" -676- MOVE CONVERSI-NUM-PROPOSTA-SIVPF TO R1-NUM-PROPOSTA */
            _.Move(CONVERSI.DCLCONVERSAO_SICOB.CONVERSI_NUM_PROPOSTA_SIVPF, LBFCT011.REG_STA_PROPOSTA.R1_NUM_PROPOSTA);

            /*" -678- MOVE 'POB' TO R1-SIT-PROPOSTA. */
            _.Move("POB", LBFCT011.REG_STA_PROPOSTA.R1_SIT_PROPOSTA);

            /*" -680- MOVE 'PEN' TO R1-SIT-COBRANCA. */
            _.Move("PEN", LBFCT011.REG_STA_PROPOSTA.R1_SIT_COBRANCA);

            /*" -683- MOVE WS-COD-ERRO TO R1-SIT-MOTIVO. */
            _.Move(AREA_DE_WORK.WS_COD_ERRO, LBFCT011.REG_STA_PROPOSTA.R1_SIT_MOTIVO);

            /*" -686- MOVE SISTEMAS-DATA-MOV-ABERTO TO W-DATA-SQL. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, AREA_DE_WORK.W_DATA_SQL);

            /*" -687- MOVE W-DIA-SQL TO W-DIA-TRABALHO. */
            _.Move(AREA_DE_WORK.W_DATA_SQL1.W_DIA_SQL, AREA_DE_WORK.FILLER_6.W_DIA_TRABALHO);

            /*" -688- MOVE W-MES-SQL TO W-MES-TRABALHO. */
            _.Move(AREA_DE_WORK.W_DATA_SQL1.W_MES_SQL, AREA_DE_WORK.FILLER_6.W_MES_TRABALHO);

            /*" -690- MOVE W-ANO-SQL TO W-ANO-TRABALHO. */
            _.Move(AREA_DE_WORK.W_DATA_SQL1.W_ANO_SQL, AREA_DE_WORK.FILLER_6.W_ANO_TRABALHO);

            /*" -692- MOVE W-DATA-TRABALHO TO R1-DATA-SITUACAO */
            _.Move(AREA_DE_WORK.W_DATA_TRABALHO, LBFCT011.REG_STA_PROPOSTA.R1_DATA_SITUACAO);

            /*" -695- MOVE ARQSIVPF-NSAS-SIVPF TO R1-NSAS */
            _.Move(ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF, LBFCT011.REG_STA_PROPOSTA.R1_NSAS);

            /*" -698- ADD 1 TO W-QTD-LD-TIPO-1, W-ABEND-CTR. */
            AREA_DE_WORK.W_QTD_LD_TIPO_1.Value = AREA_DE_WORK.W_QTD_LD_TIPO_1 + 1;
            AREA_DE_WORK.W_ABEND_CTR.Value = AREA_DE_WORK.W_ABEND_CTR + 1;

            /*" -698- MOVE W-QTD-LD-TIPO-1 TO R1-NSL. */
            _.Move(AREA_DE_WORK.W_QTD_LD_TIPO_1, LBFCT011.REG_STA_PROPOSTA.R1_NSL);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0190_SAIDA*/

        [StopWatch]
        /*" R0300-00-SELECIONA-SECTION */
        private void R0300_00_SELECIONA_SECTION()
        {
            /*" -710- MOVE '0300' TO WNR-EXEC-SQL. */
            _.Move("0300", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -711- DISPLAY ' CONVENIO 1028370056 (CIELO)         - RETORNO ' */
            _.Display($" CONVENIO 1028370056 (CIELO)         - RETORNO ");

            /*" -713- DISPLAY ' ' . */
            _.Display($" ");

            /*" -715- MOVE SPACES TO WFIM-MOVIMENTO. */
            _.Move("", AREA_DE_WORK.WFIM_MOVIMENTO);

            /*" -717- PERFORM R0310-00-LER-ENTRADA. */

            R0310_00_LER_ENTRADA_SECTION();

            /*" -718- IF WFIM-MOVIMENTO NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WFIM_MOVIMENTO.IsEmpty())
            {

                /*" -719- DISPLAY '****** ARQUIVO VAZIO ******' */
                _.Display($"****** ARQUIVO VAZIO ******");

                /*" -720- PERFORM R9800-00-ENCERRA-SEM-MOVTO */

                R9800_00_ENCERRA_SEM_MOVTO_SECTION();

                /*" -722- END-IF. */
            }


            /*" -723- PERFORM R0320-00-PROCESSA-ENTRADA UNTIL WFIM-MOVIMENTO NOT EQUAL SPACES. */

            while (!(!AREA_DE_WORK.WFIM_MOVIMENTO.IsEmpty()))
            {

                R0320_00_PROCESSA_ENTRADA_SECTION();
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_99_SAIDA*/

        [StopWatch]
        /*" R0310-00-LER-ENTRADA-SECTION */
        private void R0310_00_LER_ENTRADA_SECTION()
        {
            /*" -733- MOVE '0310' TO WNR-EXEC-SQL. */
            _.Move("0310", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -733- READ MOVIMENTO AT END */
            try
            {
                MOVIMENTO.Read(() =>
                {

                    /*" -735- MOVE 'S' TO WFIM-MOVIMENTO */
                    _.Move("S", AREA_DE_WORK.WFIM_MOVIMENTO);

                    /*" -737- GO TO R0310-99-SAIDA. */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0310_99_SAIDA*/ //GOTO
                    return;
                });

                _.Move(MOVIMENTO.Value, MOVCC_REGISTRO);

            }
            catch (GoToException ex)
            {
                return;
            }
            /*" -737- ADD 1 TO LD-ENTRADA. */
            AREA_DE_WORK.LD_ENTRADA.Value = AREA_DE_WORK.LD_ENTRADA + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0310_99_SAIDA*/

        [StopWatch]
        /*" R0320-00-PROCESSA-ENTRADA-SECTION */
        private void R0320_00_PROCESSA_ENTRADA_SECTION()
        {
            /*" -747- MOVE '0320' TO WNR-EXEC-SQL. */
            _.Move("0320", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -748- IF MOVCC-CODREGISTRO EQUAL 'A' */

            if (MOVCC_REGISTRO.MOVCC_CODREGISTRO == "A")
            {

                /*" -749- ADD 1 TO LD-HEADER */
                AREA_DE_WORK.LD_HEADER.Value = AREA_DE_WORK.LD_HEADER + 1;

                /*" -750- MOVE MOVCC-REGISTRO TO HEADER-REGISTRO */
                _.Move(MOVIMENTO?.Value, HEADER_REGISTRO);

                /*" -751- PERFORM R0330-00-TRATA-HEADER */

                R0330_00_TRATA_HEADER_SECTION();

                /*" -753- GO TO R0320-50-LEITURA. */

                R0320_50_LEITURA(); //GOTO
                return;
            }


            /*" -754- IF MOVCC-CODREGISTRO EQUAL 'Z' */

            if (MOVCC_REGISTRO.MOVCC_CODREGISTRO == "Z")
            {

                /*" -755- ADD 1 TO LD-TRAILLER */
                AREA_DE_WORK.LD_TRAILLER.Value = AREA_DE_WORK.LD_TRAILLER + 1;

                /*" -756- MOVE MOVCC-REGISTRO TO TRAILL-REGISTRO */
                _.Move(MOVIMENTO?.Value, TRAILL_REGISTRO);

                /*" -757- PERFORM R0350-00-TRATA-TRAILLER */

                R0350_00_TRATA_TRAILLER_SECTION();

                /*" -759- GO TO R0320-50-LEITURA. */

                R0320_50_LEITURA(); //GOTO
                return;
            }


            /*" -760- IF MOVCC-CODREGISTRO NOT EQUAL 'G' */

            if (MOVCC_REGISTRO.MOVCC_CODREGISTRO != "G")
            {

                /*" -762- DISPLAY 'DESPREZA  CODREGISTRO    ' MOVCC-REGISTRO */
                _.Display($"DESPREZA  CODREGISTRO    {MOVCC_REGISTRO}");

                /*" -763- ADD 1 TO DP-ENTRADA */
                AREA_DE_WORK.DP_ENTRADA.Value = AREA_DE_WORK.DP_ENTRADA + 1;

                /*" -765- GO TO R0320-50-LEITURA. */

                R0320_50_LEITURA(); //GOTO
                return;
            }


            /*" -765- PERFORM R0400-00-PROCESSA-DETALHE. */

            R0400_00_PROCESSA_DETALHE_SECTION();

            /*" -0- FLUXCONTROL_PERFORM R0320_50_LEITURA */

            R0320_50_LEITURA();

        }

        [StopWatch]
        /*" R0320-50-LEITURA */
        private void R0320_50_LEITURA(bool isPerform = false)
        {
            /*" -769- PERFORM R0310-00-LER-ENTRADA. */

            R0310_00_LER_ENTRADA_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0320_99_SAIDA*/

        [StopWatch]
        /*" R0330-00-TRATA-HEADER-SECTION */
        private void R0330_00_TRATA_HEADER_SECTION()
        {
            /*" -779- MOVE '0330' TO WNR-EXEC-SQL. */
            _.Move("0330", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -780- IF HEADER-CODCONVENIO NOT EQUAL 1028370056 */

            if (HEADER_REGISTRO.HEADER_CODCONVENIO != 1028370056)
            {

                /*" -782- DISPLAY 'R0330-00 - CONVENIO NAO PREVISTO         ' HEADER-REGISTRO */
                _.Display($"R0330-00 - CONVENIO NAO PREVISTO         {HEADER_REGISTRO}");

                /*" -784- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -785- IF HEADER-CODREMESSA NOT EQUAL 2 */

            if (HEADER_REGISTRO.HEADER_CODREMESSA != 2)
            {

                /*" -787- DISPLAY 'R0330-00 - CODIGO REMESSA INVALIDO       ' HEADER-REGISTRO */
                _.Display($"R0330-00 - CODIGO REMESSA INVALIDO       {HEADER_REGISTRO}");

                /*" -789- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -790- IF HEADER-CODBANCO NOT EQUAL 104 */

            if (HEADER_REGISTRO.HEADER_CODBANCO != 104)
            {

                /*" -792- DISPLAY 'R0330-00 - CODIGO BANCO   INVALIDO       ' HEADER-REGISTRO */
                _.Display($"R0330-00 - CODIGO BANCO   INVALIDO       {HEADER_REGISTRO}");

                /*" -794- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -795- DISPLAY ' ' . */
            _.Display($" ");

            /*" -796- DISPLAY ' SEQUENCIA ARQUIVO ..... ' HEADER-NSA. */
            _.Display($" SEQUENCIA ARQUIVO ..... {HEADER_REGISTRO.HEADER_NSA}");

            /*" -796- DISPLAY ' ' . */
            _.Display($" ");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0330_99_SAIDA*/

        [StopWatch]
        /*" R0350-00-TRATA-TRAILLER-SECTION */
        private void R0350_00_TRATA_TRAILLER_SECTION()
        {
            /*" -807- MOVE '0350' TO WNR-EXEC-SQL. */
            _.Move("0350", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -808- DISPLAY ' ' . */
            _.Display($" ");

            /*" -809- DISPLAY ' LIDOS    ENTRADA ...... ' LD-ENTRADA. */
            _.Display($" LIDOS    ENTRADA ...... {AREA_DE_WORK.LD_ENTRADA}");

            /*" -810- DISPLAY ' LIDOS    HEADER ....... ' LD-HEADER. */
            _.Display($" LIDOS    HEADER ....... {AREA_DE_WORK.LD_HEADER}");

            /*" -811- DISPLAY ' LIDOS    TRAILLER ..... ' LD-TRAILLER. */
            _.Display($" LIDOS    TRAILLER ..... {AREA_DE_WORK.LD_TRAILLER}");

            /*" -812- DISPLAY ' DESPREZA ENTRADA ...... ' DP-ENTRADA. */
            _.Display($" DESPREZA ENTRADA ...... {AREA_DE_WORK.DP_ENTRADA}");

            /*" -813- DISPLAY ' ' . */
            _.Display($" ");

            /*" -814- DISPLAY ' LIDOS DETALHE ......... ' LD-DETALHE. */
            _.Display($" LIDOS DETALHE ......... {AREA_DE_WORK.LD_DETALHE}");

            /*" -815- DISPLAY ' BILHETE NAO CADASTRADO. ' NT-BILHETE. */
            _.Display($" BILHETE NAO CADASTRADO. {AREA_DE_WORK.NT_BILHETE}");

            /*" -816- DISPLAY ' CADASTRA CONVERSAO .... ' AC-CONVERSI. */
            _.Display($" CADASTRA CONVERSAO .... {AREA_DE_WORK.AC_CONVERSI}");

            /*" -817- DISPLAY ' ' . */
            _.Display($" ");

            /*" -818- DISPLAY ' CADASTRADOS BILHETE ... ' AC-BILHETE. */
            _.Display($" CADASTRADOS BILHETE ... {AREA_DE_WORK.AC_BILHETE}");

            /*" -819- DISPLAY ' ' . */
            _.Display($" ");

            /*" -820- DISPLAY ' CADASTRADOS MOVIMENTO . ' AC-MOVIMCOB. */
            _.Display($" CADASTRADOS MOVIMENTO . {AREA_DE_WORK.AC_MOVIMCOB}");

            /*" -822- DISPLAY ' ' . */
            _.Display($" ");

            /*" -831- MOVE ZEROS TO LD-ENTRADA LD-HEADER LD-TRAILLER LD-DETALHE DP-ENTRADA NT-BILHETE AC-CONVERSI AC-BILHETE AC-MOVIMCOB. */
            _.Move(0, AREA_DE_WORK.LD_ENTRADA, AREA_DE_WORK.LD_HEADER, AREA_DE_WORK.LD_TRAILLER, AREA_DE_WORK.LD_DETALHE, AREA_DE_WORK.DP_ENTRADA, AREA_DE_WORK.NT_BILHETE, AREA_DE_WORK.AC_CONVERSI, AREA_DE_WORK.AC_BILHETE, AREA_DE_WORK.AC_MOVIMCOB);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0350_99_SAIDA*/

        [StopWatch]
        /*" R0400-00-PROCESSA-DETALHE-SECTION */
        private void R0400_00_PROCESSA_DETALHE_SECTION()
        {
            /*" -841- MOVE '0400' TO WNR-EXEC-SQL. */
            _.Move("0400", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -845- ADD 1 TO LD-DETALHE. */
            AREA_DE_WORK.LD_DETALHE.Value = AREA_DE_WORK.LD_DETALHE + 1;

            /*" -847- PERFORM R0410-00-MONTA-MOVIMCOB. */

            R0410_00_MONTA_MOVIMCOB_SECTION();

            /*" -849- MOVE 'NAO' TO WTEM-CONVERSI */
            _.Move("NAO", AREA_DE_WORK.WTEM_CONVERSI);

            /*" -859- PERFORM R0420-00-SELECT-CONVERSI. */

            R0420_00_SELECT_CONVERSI_SECTION();

            /*" -863- PERFORM R0450-00-SELECT-MOVIMCOB. */

            R0450_00_SELECT_MOVIMCOB_SECTION();

            /*" -864- IF MOVIMCOB-SIT-REGISTRO NOT EQUAL SPACES */

            if (!MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_SIT_REGISTRO.IsEmpty())
            {

                /*" -866- DISPLAY ' REGISTRO JA CADASTRADO MOVIMCOB         ' MOVCC-REGISTRO */
                _.Display($" REGISTRO JA CADASTRADO MOVIMCOB         {MOVCC_REGISTRO}");

                /*" -889- MOVE SPACES TO MOVIMCOB-SIT-REGISTRO. */
                _.Move("", MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_SIT_REGISTRO);
            }


            /*" -890- IF MOVCC-COD-BANCO EQUAL 104 */

            if (MOVCC_REGISTRO.MOVCC_CODBARRA.MOVCC_COD_BANCO == 104)
            {

                /*" -892- MOVE 'T' TO MOVIMCOB-TIPO-MOVIMENTO */
                _.Move("T", MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_TIPO_MOVIMENTO);

                /*" -894- MOVE 'C' TO MOVIMCOB-SIT-REGISTRO */
                _.Move("C", MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_SIT_REGISTRO);

                /*" -895- PERFORM R3900-00-SELECT-MOVIMCOB */

                R3900_00_SELECT_MOVIMCOB_SECTION();

                /*" -896- ELSE */
            }
            else
            {


                /*" -896- PERFORM R4000-00-INSERT-MOVIMCOB. */

                R4000_00_INSERT_MOVIMCOB_SECTION();
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0400_99_SAIDA*/

        [StopWatch]
        /*" R0410-00-MONTA-MOVIMCOB-SECTION */
        private void R0410_00_MONTA_MOVIMCOB_SECTION()
        {
            /*" -907- MOVE '0410' TO WNR-EXEC-SQL. */
            _.Move("0410", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -909- MOVE ZEROS TO MOVIMCOB-COD-EMPRESA. */
            _.Move(0, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_EMPRESA);

            /*" -911- MOVE MOVCC-NRSEQREG TO MOVIMCOB-COD-MOVIMENTO. */
            _.Move(MOVCC_REGISTRO.MOVCC_NRSEQREG, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_MOVIMENTO);

            /*" -913- MOVE WS-NRAVISO TO MOVIMCOB-NUM-AVISO. */
            _.Move(AREA_DE_WORK.WS_NRAVISO, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_AVISO);

            /*" -916- MOVE WS-AUXNSAS TO MOVIMCOB-NUM-FITA. */
            _.Move(AREA_DE_WORK.FILLER_11.WS_AUXNSAS, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_FITA);

            /*" -917- IF MOVCC-COD-RETORNO IS NUMERIC */

            if (MOVCC_REGISTRO.MOVCC_NUM_AUTENTIC.MOVCC_COD_RETORNO.IsNumeric())
            {

                /*" -919- MOVE MOVCC-COD-RETORNO TO MOVIMCOB-VAL-IOCC */
                _.Move(MOVCC_REGISTRO.MOVCC_NUM_AUTENTIC.MOVCC_COD_RETORNO, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_VAL_IOCC);

                /*" -920- ELSE */
            }
            else
            {


                /*" -922- MOVE 999 TO MOVIMCOB-VAL-IOCC */
                _.Move(999, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_VAL_IOCC);

                /*" -924- END-IF */
            }


            /*" -927- MOVE SPACES TO MOVIMCOB-SIT-REGISTRO. */
            _.Move("", MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_SIT_REGISTRO);

            /*" -928- IF MOVCC-COD-RETORNO EQUAL ZEROS */

            if (MOVCC_REGISTRO.MOVCC_NUM_AUTENTIC.MOVCC_COD_RETORNO == 00)
            {

                /*" -930- MOVE 'T' TO MOVIMCOB-TIPO-MOVIMENTO */
                _.Move("T", MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_TIPO_MOVIMENTO);

                /*" -931- ELSE */
            }
            else
            {


                /*" -932- IF MOVCC-COD-BANCO EQUAL 104 */

                if (MOVCC_REGISTRO.MOVCC_CODBARRA.MOVCC_COD_BANCO == 104)
                {

                    /*" -934- MOVE 'T' TO MOVIMCOB-TIPO-MOVIMENTO */
                    _.Move("T", MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_TIPO_MOVIMENTO);

                    /*" -936- MOVE 'C' TO MOVIMCOB-SIT-REGISTRO */
                    _.Move("C", MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_SIT_REGISTRO);

                    /*" -937- ELSE */
                }
                else
                {


                    /*" -939- MOVE 'U' TO MOVIMCOB-TIPO-MOVIMENTO */
                    _.Move("U", MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_TIPO_MOVIMENTO);

                    /*" -940- MOVE 717 TO WS-COD-ERRO */
                    _.Move(717, AREA_DE_WORK.WS_COD_ERRO);

                    /*" -941- PERFORM R0190-00-GERAR-REGISTRO-TP1 */

                    R0190_00_GERAR_REGISTRO_TP1_SECTION();

                    /*" -943- END-IF. */
                }

            }


            /*" -945- MOVE MOVCC-VLRPAGO TO MOVIMCOB-VAL-TITULO. */
            _.Move(MOVCC_REGISTRO.MOVCC_VLRPAGO, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_VAL_TITULO);

            /*" -948- MOVE MOVCC-VLRTARIFA TO MOVIMCOB-VAL-CREDITO. */
            _.Move(MOVCC_REGISTRO.MOVCC_VLRTARIFA, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_VAL_CREDITO);

            /*" -963- COMPUTE MOVIMCOB-VAL-CREDITO EQUAL (MOVIMCOB-VAL-TITULO - MOVIMCOB-VAL-CREDITO). */
            MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_VAL_CREDITO.Value = (MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_VAL_TITULO - MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_VAL_CREDITO);

            /*" -966- MOVE SISTEMAS-DATA-MOV-ABERTO TO MOVIMCOB-DATA-MOVIMENTO. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_DATA_MOVIMENTO);

            /*" -967- MOVE MOVCC-ANOCRE TO WDAT-REL-ANO */
            _.Move(MOVCC_REGISTRO.MOVCC_DTCREDITO.MOVCC_ANOCRE, AREA_DE_WORK.FILLER_8.WDAT_REL_ANO);

            /*" -968- MOVE MOVCC-MESCRE TO WDAT-REL-MES */
            _.Move(MOVCC_REGISTRO.MOVCC_DTCREDITO.MOVCC_MESCRE, AREA_DE_WORK.FILLER_8.WDAT_REL_MES);

            /*" -969- MOVE MOVCC-DIACRE TO WDAT-REL-DIA */
            _.Move(MOVCC_REGISTRO.MOVCC_DTCREDITO.MOVCC_DIACRE, AREA_DE_WORK.FILLER_8.WDAT_REL_DIA);

            /*" -972- MOVE WDATA-REL TO MOVIMCOB-DATA-QUITACAO. */
            _.Move(AREA_DE_WORK.WDATA_REL, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_DATA_QUITACAO);

            /*" -975- MOVE MOVCC-NUM-PROPOSTA TO MOVIMCOB-NUM-APOLICE. */
            _.Move(MOVCC_REGISTRO.MOVCC_CODBARRA.MOVCC_NUM_PROPOSTA, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_APOLICE);

            /*" -980- MOVE ZEROS TO MOVIMCOB-NUM-TITULO MOVIMCOB-NUM-ENDOSSO MOVIMCOB-NUM-PARCELA. */
            _.Move(0, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_TITULO, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_ENDOSSO, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_PARCELA);

            /*" -981- IF MOVCC-NUM-PARCELA IS NUMERIC */

            if (MOVCC_REGISTRO.MOVCC_CODBARRA.MOVCC_NUM_PARCELA.IsNumeric())
            {

                /*" -984- MOVE MOVCC-NUM-PARCELA TO MOVIMCOB-NUM-ENDOSSO. */
                _.Move(MOVCC_REGISTRO.MOVCC_CODBARRA.MOVCC_NUM_PARCELA, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_ENDOSSO);
            }


            /*" -987- MOVE SPACES TO MOVIMCOB-NOME-SEGURADO. */
            _.Move("", MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NOME_SEGURADO);

            /*" -988- IF MOVCC-COD-RETORNO EQUAL ZEROS */

            if (MOVCC_REGISTRO.MOVCC_NUM_AUTENTIC.MOVCC_COD_RETORNO == 00)
            {

                /*" -990- MOVE MOVCC-CODBARRA TO MOVIMCOB-NOME-SEGURADO */
                _.Move(MOVCC_REGISTRO.MOVCC_CODBARRA, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NOME_SEGURADO);

                /*" -991- ELSE */
            }
            else
            {


                /*" -993- MOVE WS-COD-ERRO TO MOVIMCOB-NOME-SEGURADO */
                _.Move(AREA_DE_WORK.WS_COD_ERRO, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NOME_SEGURADO);

                /*" -993- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0410_99_SAIDA*/

        [StopWatch]
        /*" R0420-00-SELECT-CONVERSI-SECTION */
        private void R0420_00_SELECT_CONVERSI_SECTION()
        {
            /*" -1003- MOVE '0420' TO WNR-EXEC-SQL. */
            _.Move("0420", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1004- MOVE ZEROS TO WS-NRTIT. */
            _.Move(0, AREA_DE_WORK.WS_NRTIT);

            /*" -1005- MOVE MOVCC-NUM-PROPOSTA TO WS-NUMTIT. */
            _.Move(MOVCC_REGISTRO.MOVCC_CODBARRA.MOVCC_NUM_PROPOSTA, AREA_DE_WORK.FILLER_12.WS_NUMTIT);

            /*" -1006- MOVE ZEROS TO WS-DIGTIT. */
            _.Move(0, AREA_DE_WORK.FILLER_12.WS_DIGTIT);

            /*" -1008- MOVE WS-NRTIT TO WSHOST-NUMSIV01. */
            _.Move(AREA_DE_WORK.WS_NRTIT, WSHOST_NUMSIV01);

            /*" -1009- MOVE 9 TO WS-DIGTIT. */
            _.Move(9, AREA_DE_WORK.FILLER_12.WS_DIGTIT);

            /*" -1012- MOVE WS-NRTIT TO WSHOST-NUMSIV02. */
            _.Move(AREA_DE_WORK.WS_NRTIT, WSHOST_NUMSIV02);

            /*" -1023- PERFORM R0420_00_SELECT_CONVERSI_DB_SELECT_1 */

            R0420_00_SELECT_CONVERSI_DB_SELECT_1();

            /*" -1026- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1027- PERFORM R0430-00-SELECT-BILHETE */

                R0430_00_SELECT_BILHETE_SECTION();

                /*" -1028- GO TO R0420-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0420_99_SAIDA*/ //GOTO
                return;

                /*" -1030- END-IF. */
            }


            /*" -1032- MOVE 'SIM' TO WTEM-CONVERSI */
            _.Move("SIM", AREA_DE_WORK.WTEM_CONVERSI);

            /*" -1034- MOVE PROPOFID-NUM-SICOB TO MOVIMCOB-NUM-TITULO */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_SICOB, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_TITULO);

            /*" -1036- MOVE MOVCC-NUM-PROPOSTA TO MOVIMCOB-NUM-APOLICE */
            _.Move(MOVCC_REGISTRO.MOVCC_CODBARRA.MOVCC_NUM_PROPOSTA, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_APOLICE);

            /*" -1037- MOVE CONVERSI-NUM-PROPOSTA-SIVPF TO MOVIMCOB-NUM-NOSSO-TITULO. */
            _.Move(CONVERSI.DCLCONVERSAO_SICOB.CONVERSI_NUM_PROPOSTA_SIVPF, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_NOSSO_TITULO);

        }

        [StopWatch]
        /*" R0420-00-SELECT-CONVERSI-DB-SELECT-1 */
        public void R0420_00_SELECT_CONVERSI_DB_SELECT_1()
        {
            /*" -1023- EXEC SQL SELECT A.NUM_PROPOSTA_SIVPF , B.NUM_SICOB INTO :CONVERSI-NUM-PROPOSTA-SIVPF , :PROPOFID-NUM-SICOB FROM SEGUROS.CONVERSAO_SICOB A , SEGUROS.PROPOSTA_FIDELIZ B WHERE A.NUM_PROPOSTA_SIVPF >= :WSHOST-NUMSIV01 AND A.NUM_PROPOSTA_SIVPF <= :WSHOST-NUMSIV02 AND A.NUM_PROPOSTA_SIVPF = B.NUM_PROPOSTA_SIVPF WITH UR END-EXEC. */

            var r0420_00_SELECT_CONVERSI_DB_SELECT_1_Query1 = new R0420_00_SELECT_CONVERSI_DB_SELECT_1_Query1()
            {
                WSHOST_NUMSIV01 = WSHOST_NUMSIV01.ToString(),
                WSHOST_NUMSIV02 = WSHOST_NUMSIV02.ToString(),
            };

            var executed_1 = R0420_00_SELECT_CONVERSI_DB_SELECT_1_Query1.Execute(r0420_00_SELECT_CONVERSI_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CONVERSI_NUM_PROPOSTA_SIVPF, CONVERSI.DCLCONVERSAO_SICOB.CONVERSI_NUM_PROPOSTA_SIVPF);
                _.Move(executed_1.PROPOFID_NUM_SICOB, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_SICOB);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0420_99_SAIDA*/

        [StopWatch]
        /*" R0430-00-SELECT-BILHETE-SECTION */
        private void R0430_00_SELECT_BILHETE_SECTION()
        {
            /*" -1047- MOVE '0430' TO WNR-EXEC-SQL. */
            _.Move("0430", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1120- PERFORM R0430_00_SELECT_BILHETE_DB_SELECT_1 */

            R0430_00_SELECT_BILHETE_DB_SELECT_1();

            /*" -1123- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1124- PERFORM R0440-00-CALCULA-PROPOSTA */

                R0440_00_CALCULA_PROPOSTA_SECTION();

                /*" -1126- GO TO R0430-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0430_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1126- PERFORM R0500-00-TRATA-PROPOSTA. */

            R0500_00_TRATA_PROPOSTA_SECTION();

        }

        [StopWatch]
        /*" R0430-00-SELECT-BILHETE-DB-SELECT-1 */
        public void R0430_00_SELECT_BILHETE_DB_SELECT_1()
        {
            /*" -1120- EXEC SQL SELECT NUM_BILHETE , NUM_APOLICE , FONTE , AGE_COBRANCA , NUM_MATRICULA , COD_AGENCIA , OPERACAO_CONTA , NUM_CONTA , DIG_CONTA , COD_CLIENTE , PROFISSAO , IDE_SEXO , ESTADO_CIVIL , OCORR_ENDERECO , COD_AGENCIA_DEB , OPERACAO_CONTA_DEB , NUM_CONTA_DEB , DIG_CONTA_DEB , OPC_COBERTURA , DATA_QUITACAO , VAL_RCAP , RAMO , DATA_VENDA , DATA_MOVIMENTO , NUM_APOL_ANTERIOR , SITUACAO , TIP_CANCELAMENTO , SIT_SINISTRO , COD_USUARIO , TIMESTAMP , DATA_CANCELAMENTO , BI_FAIXA_RENDA_IND , BI_FAIXA_RENDA_FAM INTO :BILHETE-NUM-BILHETE , :BILHETE-NUM-APOLICE , :BILHETE-FONTE , :BILHETE-AGE-COBRANCA , :BILHETE-NUM-MATRICULA , :BILHETE-COD-AGENCIA , :BILHETE-OPERACAO-CONTA , :BILHETE-NUM-CONTA , :BILHETE-DIG-CONTA , :BILHETE-COD-CLIENTE , :BILHETE-PROFISSAO , :BILHETE-IDE-SEXO , :BILHETE-ESTADO-CIVIL , :BILHETE-OCORR-ENDERECO , :BILHETE-COD-AGENCIA-DEB , :BILHETE-OPERACAO-CONTA-DEB , :BILHETE-NUM-CONTA-DEB , :BILHETE-DIG-CONTA-DEB , :BILHETE-OPC-COBERTURA , :BILHETE-DATA-QUITACAO , :BILHETE-VAL-RCAP , :BILHETE-RAMO , :BILHETE-DATA-VENDA , :BILHETE-DATA-MOVIMENTO , :BILHETE-NUM-APOL-ANTERIOR , :BILHETE-SITUACAO , :BILHETE-TIP-CANCELAMENTO , :BILHETE-SIT-SINISTRO , :BILHETE-COD-USUARIO , :BILHETE-TIMESTAMP , :BILHETE-DATA-CANCELAMENTO:VIND-NULL01 , :BILHETE-BI-FAIXA-RENDA-IND , :BILHETE-BI-FAIXA-RENDA-FAM FROM SEGUROS.BILHETE WHERE NUM_BILHETE >= :WSHOST-NUMSIV01 AND NUM_BILHETE <= :WSHOST-NUMSIV02 WITH UR END-EXEC. */

            var r0430_00_SELECT_BILHETE_DB_SELECT_1_Query1 = new R0430_00_SELECT_BILHETE_DB_SELECT_1_Query1()
            {
                WSHOST_NUMSIV01 = WSHOST_NUMSIV01.ToString(),
                WSHOST_NUMSIV02 = WSHOST_NUMSIV02.ToString(),
            };

            var executed_1 = R0430_00_SELECT_BILHETE_DB_SELECT_1_Query1.Execute(r0430_00_SELECT_BILHETE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
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
                _.Move(executed_1.BILHETE_PROFISSAO, BILHETE.DCLBILHETE.BILHETE_PROFISSAO);
                _.Move(executed_1.BILHETE_IDE_SEXO, BILHETE.DCLBILHETE.BILHETE_IDE_SEXO);
                _.Move(executed_1.BILHETE_ESTADO_CIVIL, BILHETE.DCLBILHETE.BILHETE_ESTADO_CIVIL);
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
                _.Move(executed_1.BILHETE_DATA_MOVIMENTO, BILHETE.DCLBILHETE.BILHETE_DATA_MOVIMENTO);
                _.Move(executed_1.BILHETE_NUM_APOL_ANTERIOR, BILHETE.DCLBILHETE.BILHETE_NUM_APOL_ANTERIOR);
                _.Move(executed_1.BILHETE_SITUACAO, BILHETE.DCLBILHETE.BILHETE_SITUACAO);
                _.Move(executed_1.BILHETE_TIP_CANCELAMENTO, BILHETE.DCLBILHETE.BILHETE_TIP_CANCELAMENTO);
                _.Move(executed_1.BILHETE_SIT_SINISTRO, BILHETE.DCLBILHETE.BILHETE_SIT_SINISTRO);
                _.Move(executed_1.BILHETE_COD_USUARIO, BILHETE.DCLBILHETE.BILHETE_COD_USUARIO);
                _.Move(executed_1.BILHETE_TIMESTAMP, BILHETE.DCLBILHETE.BILHETE_TIMESTAMP);
                _.Move(executed_1.BILHETE_DATA_CANCELAMENTO, BILHETE.DCLBILHETE.BILHETE_DATA_CANCELAMENTO);
                _.Move(executed_1.VIND_NULL01, VIND_NULL01);
                _.Move(executed_1.BILHETE_BI_FAIXA_RENDA_IND, BILHETE.DCLBILHETE.BILHETE_BI_FAIXA_RENDA_IND);
                _.Move(executed_1.BILHETE_BI_FAIXA_RENDA_FAM, BILHETE.DCLBILHETE.BILHETE_BI_FAIXA_RENDA_FAM);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0430_99_SAIDA*/

        [StopWatch]
        /*" R0440-00-CALCULA-PROPOSTA-SECTION */
        private void R0440_00_CALCULA_PROPOSTA_SECTION()
        {
            /*" -1136- MOVE '0440' TO WNR-EXEC-SQL. */
            _.Move("0440", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1138- MOVE MOVCC-NUM-PROPOSTA TO LPARM13. */
            _.Move(MOVCC_REGISTRO.MOVCC_CODBARRA.MOVCC_NUM_PROPOSTA, LPARM13X.LPARM13);

            /*" -1152- COMPUTE WPARM13-AUX = LPARM13-1 * 6 + LPARM13-2 * 5 + LPARM13-3 * 4 + LPARM13-4 * 3 + LPARM13-5 * 2 + LPARM13-6 * 9 + LPARM13-7 * 8 + LPARM13-8 * 7 + LPARM13-9 * 6 + LPARM13-10 * 5 + LPARM13-11 * 4 + LPARM13-12 * 3 + LPARM13-13 * 2. */
            AREA_DE_WORK.WPARM13_AUX.Value = LPARM13X.FILLER_22.LPARM13_1 * 6 + LPARM13X.FILLER_22.LPARM13_2 * 5 + LPARM13X.FILLER_22.LPARM13_3 * 4 + LPARM13X.FILLER_22.LPARM13_4 * 3 + LPARM13X.FILLER_22.LPARM13_5 * 2 + LPARM13X.FILLER_22.LPARM13_6 * 9 + LPARM13X.FILLER_22.LPARM13_7 * 8 + LPARM13X.FILLER_22.LPARM13_8 * 7 + LPARM13X.FILLER_22.LPARM13_9 * 6 + LPARM13X.FILLER_22.LPARM13_10 * 5 + LPARM13X.FILLER_22.LPARM13_11 * 4 + LPARM13X.FILLER_22.LPARM13_12 * 3 + LPARM13X.FILLER_22.LPARM13_13 * 2;

            /*" -1155- DIVIDE WPARM13-AUX BY 11 GIVING WS-RESULT REMAINDER WS-RESTO. */
            _.Divide(AREA_DE_WORK.WPARM13_AUX, 11, AREA_DE_WORK.WS_RESULT, AREA_DE_WORK.WS_RESTO);

            /*" -1156- IF WS-RESTO EQUAL ZEROS */

            if (AREA_DE_WORK.WS_RESTO == 00)
            {

                /*" -1157- MOVE 0 TO WS-DIGTIT */
                _.Move(0, AREA_DE_WORK.FILLER_12.WS_DIGTIT);

                /*" -1158- ELSE */
            }
            else
            {


                /*" -1161- SUBTRACT WS-RESTO FROM 11 GIVING WS-DIGTIT. */
                AREA_DE_WORK.FILLER_12.WS_DIGTIT.Value = 11 - AREA_DE_WORK.WS_RESTO;
            }


            /*" -1164- MOVE WS-NRTIT TO MOVIMCOB-NUM-NOSSO-TITULO. */
            _.Move(AREA_DE_WORK.WS_NRTIT, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_NOSSO_TITULO);

            /*" -1164- ADD 1 TO NT-BILHETE. */
            AREA_DE_WORK.NT_BILHETE.Value = AREA_DE_WORK.NT_BILHETE + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0440_99_SAIDA*/

        [StopWatch]
        /*" R0450-00-SELECT-MOVIMCOB-SECTION */
        private void R0450_00_SELECT_MOVIMCOB_SECTION()
        {
            /*" -1174- MOVE '0450' TO WNR-EXEC-SQL. */
            _.Move("0450", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1195- PERFORM R0450_00_SELECT_MOVIMCOB_DB_SELECT_1 */

            R0450_00_SELECT_MOVIMCOB_DB_SELECT_1();

            /*" -1198- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -1200- MOVE '*' TO MOVIMCOB-SIT-REGISTRO */
                _.Move("*", MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_SIT_REGISTRO);

                /*" -1201- ELSE */
            }
            else
            {


                /*" -1202- MOVE SPACES TO MOVIMCOB-SIT-REGISTRO. */
                _.Move("", MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_SIT_REGISTRO);
            }


        }

        [StopWatch]
        /*" R0450-00-SELECT-MOVIMCOB-DB-SELECT-1 */
        public void R0450_00_SELECT_MOVIMCOB_DB_SELECT_1()
        {
            /*" -1195- EXEC SQL SELECT SIT_REGISTRO INTO :MOVIMCOB-SIT-REGISTRO FROM SEGUROS.MOVIMENTO_COBRANCA WHERE COD_BANCO = :MOVIMCOB-COD-BANCO AND COD_AGENCIA = :MOVIMCOB-COD-AGENCIA AND NUM_AVISO = :MOVIMCOB-NUM-AVISO AND NUM_TITULO = :MOVIMCOB-NUM-TITULO AND NUM_APOLICE = :MOVIMCOB-NUM-APOLICE AND NUM_ENDOSSO = :MOVIMCOB-NUM-ENDOSSO AND NUM_PARCELA = :MOVIMCOB-NUM-PARCELA AND NUM_NOSSO_TITULO = :MOVIMCOB-NUM-NOSSO-TITULO WITH UR END-EXEC. */

            var r0450_00_SELECT_MOVIMCOB_DB_SELECT_1_Query1 = new R0450_00_SELECT_MOVIMCOB_DB_SELECT_1_Query1()
            {
                MOVIMCOB_NUM_NOSSO_TITULO = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_NOSSO_TITULO.ToString(),
                MOVIMCOB_COD_AGENCIA = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_AGENCIA.ToString(),
                MOVIMCOB_NUM_APOLICE = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_APOLICE.ToString(),
                MOVIMCOB_NUM_ENDOSSO = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_ENDOSSO.ToString(),
                MOVIMCOB_NUM_PARCELA = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_PARCELA.ToString(),
                MOVIMCOB_NUM_TITULO = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_TITULO.ToString(),
                MOVIMCOB_COD_BANCO = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_BANCO.ToString(),
                MOVIMCOB_NUM_AVISO = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_AVISO.ToString(),
            };

            var executed_1 = R0450_00_SELECT_MOVIMCOB_DB_SELECT_1_Query1.Execute(r0450_00_SELECT_MOVIMCOB_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.MOVIMCOB_SIT_REGISTRO, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_SIT_REGISTRO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0450_99_SAIDA*/

        [StopWatch]
        /*" R0500-00-TRATA-PROPOSTA-SECTION */
        private void R0500_00_TRATA_PROPOSTA_SECTION()
        {
            /*" -1212- MOVE '0500' TO WNR-EXEC-SQL. */
            _.Move("0500", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1214- PERFORM R0510-00-SELECT-V0CEDENTE. */

            R0510_00_SELECT_V0CEDENTE_SECTION();

            /*" -1216- PERFORM R0530-00-CALCULA-TITULO. */

            R0530_00_CALCULA_TITULO_SECTION();

            /*" -1218- PERFORM R0550-00-UPDATE-V0CEDENTE. */

            R0550_00_UPDATE_V0CEDENTE_SECTION();

            /*" -1220- PERFORM R1000-00-DELETE-BILHETE. */

            R1000_00_DELETE_BILHETE_SECTION();

            /*" -1222- PERFORM R1100-00-INSERT-CONVERSI. */

            R1100_00_INSERT_CONVERSI_SECTION();

            /*" -1224- PERFORM R1200-00-INSERT-BILHETE. */

            R1200_00_INSERT_BILHETE_SECTION();

            /*" -1226- MOVE BILHETE-NUM-BILHETE TO MOVIMCOB-NUM-TITULO */
            _.Move(BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_TITULO);

            /*" -1228- MOVE BILHETE-NUM-APOLICE TO MOVIMCOB-NUM-APOLICE */
            _.Move(BILHETE.DCLBILHETE.BILHETE_NUM_APOLICE, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_APOLICE);

            /*" -1231- MOVE CONVERSI-NUM-PROPOSTA-SIVPF TO MOVIMCOB-NUM-NOSSO-TITULO. */
            _.Move(CONVERSI.DCLCONVERSAO_SICOB.CONVERSI_NUM_PROPOSTA_SIVPF, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_NOSSO_TITULO);

            /*" -1231- ADD 1 TO AC-CONVERSI. */
            AREA_DE_WORK.AC_CONVERSI.Value = AREA_DE_WORK.AC_CONVERSI + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0500_99_SAIDA*/

        [StopWatch]
        /*" R0510-00-SELECT-V0CEDENTE-SECTION */
        private void R0510_00_SELECT_V0CEDENTE_SECTION()
        {
            /*" -1241- MOVE '0510' TO WNR-EXEC-SQL. */
            _.Move("0510", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1248- PERFORM R0510_00_SELECT_V0CEDENTE_DB_SELECT_1 */

            R0510_00_SELECT_V0CEDENTE_DB_SELECT_1();

            /*" -1251- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1252- DISPLAY 'R0510-00 - PROBLEMAS NO SELECT(V0CEDENTE)' */
                _.Display($"R0510-00 - PROBLEMAS NO SELECT(V0CEDENTE)");

                /*" -1254- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1256- MOVE CEDENTE-NUM-TITULO TO WWORK-MIN-NRTIT. */
            _.Move(CEDENTE.DCLCEDENTE.CEDENTE_NUM_TITULO, AREA_DE_WORK.WWORK_MIN_NRTIT);

            /*" -1257- MOVE CEDENTE-NUM-TITULO-MAX TO WWORK-MAX-NRTIT. */
            _.Move(CEDENTE.DCLCEDENTE.CEDENTE_NUM_TITULO_MAX, AREA_DE_WORK.WWORK_MAX_NRTIT);

        }

        [StopWatch]
        /*" R0510-00-SELECT-V0CEDENTE-DB-SELECT-1 */
        public void R0510_00_SELECT_V0CEDENTE_DB_SELECT_1()
        {
            /*" -1248- EXEC SQL SELECT NUM_TITULO , NUM_TITULO_MAX INTO :CEDENTE-NUM-TITULO , :CEDENTE-NUM-TITULO-MAX FROM SEGUROS.CEDENTE WHERE COD_CEDENTE = 26 END-EXEC. */

            var r0510_00_SELECT_V0CEDENTE_DB_SELECT_1_Query1 = new R0510_00_SELECT_V0CEDENTE_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0510_00_SELECT_V0CEDENTE_DB_SELECT_1_Query1.Execute(r0510_00_SELECT_V0CEDENTE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CEDENTE_NUM_TITULO, CEDENTE.DCLCEDENTE.CEDENTE_NUM_TITULO);
                _.Move(executed_1.CEDENTE_NUM_TITULO_MAX, CEDENTE.DCLCEDENTE.CEDENTE_NUM_TITULO_MAX);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0510_99_SAIDA*/

        [StopWatch]
        /*" R0520-00-UPDATE-BILHETE-SECTION */
        private void R0520_00_UPDATE_BILHETE_SECTION()
        {
            /*" -1267- MOVE '0520' TO WNR-EXEC-SQL. */
            _.Move("0520", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1272- PERFORM R0520_00_UPDATE_BILHETE_DB_UPDATE_1 */

            R0520_00_UPDATE_BILHETE_DB_UPDATE_1();

            /*" -1275- IF SQLCODE NOT EQUAL ZEROS AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -1276- DISPLAY 'R0550-00 - PROBLEMAS UPDATE (BILHETE)     ' */
                _.Display($"R0550-00 - PROBLEMAS UPDATE (BILHETE)     ");

                /*" -1276- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0520-00-UPDATE-BILHETE-DB-UPDATE-1 */
        public void R0520_00_UPDATE_BILHETE_DB_UPDATE_1()
        {
            /*" -1272- EXEC SQL UPDATE SEGUROS.BILHETE SET DATA_QUITACAO = :MOVIMCOB-DATA-QUITACAO, SITUACAO = '5' WHERE NUM_BILHETE = :PROPOFID-NUM-SICOB END-EXEC. */

            var r0520_00_UPDATE_BILHETE_DB_UPDATE_1_Update1 = new R0520_00_UPDATE_BILHETE_DB_UPDATE_1_Update1()
            {
                MOVIMCOB_DATA_QUITACAO = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_DATA_QUITACAO.ToString(),
                PROPOFID_NUM_SICOB = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_SICOB.ToString(),
            };

            R0520_00_UPDATE_BILHETE_DB_UPDATE_1_Update1.Execute(r0520_00_UPDATE_BILHETE_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0520_99_SAIDA*/

        [StopWatch]
        /*" R0530-00-CALCULA-TITULO-SECTION */
        private void R0530_00_CALCULA_TITULO_SECTION()
        {
            /*" -1286- MOVE '0530' TO WNR-EXEC-SQL. */
            _.Move("0530", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1287- ADD 1 TO WWORK-MINNRO */
            AREA_DE_WORK.FILLER_13.WWORK_MINNRO.Value = AREA_DE_WORK.FILLER_13.WWORK_MINNRO + 1;

            /*" -1289- MOVE WWORK-MINNRO TO LPARM11. */
            _.Move(AREA_DE_WORK.FILLER_13.WWORK_MINNRO, LPARM11X.LPARM11);

            /*" -1300- COMPUTE WPARM11-AUX = LPARM11-1 * 3 + LPARM11-2 * 2 + LPARM11-3 * 9 + LPARM11-4 * 8 + LPARM11-5 * 7 + LPARM11-6 * 6 + LPARM11-7 * 5 + LPARM11-8 * 4 + LPARM11-9 * 3 + LPARM11-10 * 2. */
            AREA_DE_WORK.WPARM11_AUX.Value = LPARM11X.FILLER_21.LPARM11_1 * 3 + LPARM11X.FILLER_21.LPARM11_2 * 2 + LPARM11X.FILLER_21.LPARM11_3 * 9 + LPARM11X.FILLER_21.LPARM11_4 * 8 + LPARM11X.FILLER_21.LPARM11_5 * 7 + LPARM11X.FILLER_21.LPARM11_6 * 6 + LPARM11X.FILLER_21.LPARM11_7 * 5 + LPARM11X.FILLER_21.LPARM11_8 * 4 + LPARM11X.FILLER_21.LPARM11_9 * 3 + LPARM11X.FILLER_21.LPARM11_10 * 2;

            /*" -1303- DIVIDE WPARM11-AUX BY 11 GIVING WS-RESULT REMAINDER WS-RESTO. */
            _.Divide(AREA_DE_WORK.WPARM11_AUX, 11, AREA_DE_WORK.WS_RESULT, AREA_DE_WORK.WS_RESTO);

            /*" -1304- IF WS-RESTO EQUAL ZEROS */

            if (AREA_DE_WORK.WS_RESTO == 00)
            {

                /*" -1305- MOVE 0 TO WWORK-MINDIG */
                _.Move(0, AREA_DE_WORK.FILLER_13.WWORK_MINDIG);

                /*" -1306- ELSE */
            }
            else
            {


                /*" -1309- SUBTRACT WS-RESTO FROM 11 GIVING WWORK-MINDIG. */
                AREA_DE_WORK.FILLER_13.WWORK_MINDIG.Value = 11 - AREA_DE_WORK.WS_RESTO;
            }


            /*" -1310- IF WWORK-MIN-NRTIT GREATER WWORK-MAX-NRTIT */

            if (AREA_DE_WORK.WWORK_MIN_NRTIT > AREA_DE_WORK.WWORK_MAX_NRTIT)
            {

                /*" -1311- DISPLAY 'R0530-00 - ABEND CONTROLADO                ' */
                _.Display($"R0530-00 - ABEND CONTROLADO                ");

                /*" -1312- DISPLAY '*  ESTOURO FAIXA NUMERACAO CEDENTE = 26    ' */
                _.Display($"*  ESTOURO FAIXA NUMERACAO CEDENTE = 26    ");

                /*" -1313- DISPLAY '    ' WWORK-MIN-NRTIT */
                _.Display($"    {AREA_DE_WORK.WWORK_MIN_NRTIT}");

                /*" -1313- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0530_99_SAIDA*/

        [StopWatch]
        /*" R0550-00-UPDATE-V0CEDENTE-SECTION */
        private void R0550_00_UPDATE_V0CEDENTE_SECTION()
        {
            /*" -1323- MOVE '0550' TO WNR-EXEC-SQL. */
            _.Move("0550", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1326- MOVE WWORK-MIN-NRTIT TO CEDENTE-NUM-TITULO. */
            _.Move(AREA_DE_WORK.WWORK_MIN_NRTIT, CEDENTE.DCLCEDENTE.CEDENTE_NUM_TITULO);

            /*" -1330- PERFORM R0550_00_UPDATE_V0CEDENTE_DB_UPDATE_1 */

            R0550_00_UPDATE_V0CEDENTE_DB_UPDATE_1();

            /*" -1333- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1334- DISPLAY 'R0550-00 - PROBLEMAS UPDATE (V0CEDENTE)   ' */
                _.Display($"R0550-00 - PROBLEMAS UPDATE (V0CEDENTE)   ");

                /*" -1334- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0550-00-UPDATE-V0CEDENTE-DB-UPDATE-1 */
        public void R0550_00_UPDATE_V0CEDENTE_DB_UPDATE_1()
        {
            /*" -1330- EXEC SQL UPDATE SEGUROS.CEDENTE SET NUM_TITULO = :CEDENTE-NUM-TITULO WHERE COD_CEDENTE = 26 END-EXEC. */

            var r0550_00_UPDATE_V0CEDENTE_DB_UPDATE_1_Update1 = new R0550_00_UPDATE_V0CEDENTE_DB_UPDATE_1_Update1()
            {
                CEDENTE_NUM_TITULO = CEDENTE.DCLCEDENTE.CEDENTE_NUM_TITULO.ToString(),
            };

            R0550_00_UPDATE_V0CEDENTE_DB_UPDATE_1_Update1.Execute(r0550_00_UPDATE_V0CEDENTE_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0550_99_SAIDA*/

        [StopWatch]
        /*" R0800-00-GERAR-TRAILLER-SECTION */
        private void R0800_00_GERAR_TRAILLER_SECTION()
        {
            /*" -1344- MOVE '0550' TO WNR-EXEC-SQL. */
            _.Move("0550", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1346- MOVE SPACES TO REG-TRAILLER-STA. */
            _.Move("", LBFCT011.REG_TRAILLER_STA);

            /*" -1348- MOVE 'T' TO RT-TIPO-REG */
            _.Move("T", LBFCT011.REG_TRAILLER_STA.RT_TIPO_REG);

            /*" -1350- MOVE 'STASCADE' TO RT-NOME-EMPRESA */
            _.Move("STASCADE", LBFCT011.REG_TRAILLER_STA.RT_NOME_EMPRESA);

            /*" -1352- MOVE W-QTD-LD-TIPO-1 TO RT-QTDE-TIPO-1 */
            _.Move(AREA_DE_WORK.W_QTD_LD_TIPO_1, LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_1);

            /*" -1354- MOVE W-QTD-LD-TIPO-2 TO RT-QTDE-TIPO-2 */
            _.Move(AREA_DE_WORK.W_QTD_LD_TIPO_2, LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_2);

            /*" -1356- MOVE W-QTD-LD-TIPO-3 TO RT-QTDE-TIPO-3 */
            _.Move(AREA_DE_WORK.W_QTD_LD_TIPO_3, LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_3);

            /*" -1358- MOVE W-QTD-LD-TIPO-4 TO RT-QTDE-TIPO-4 */
            _.Move(AREA_DE_WORK.W_QTD_LD_TIPO_4, LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_4);

            /*" -1360- MOVE W-QTD-LD-TIPO-5 TO RT-QTDE-TIPO-5 */
            _.Move(AREA_DE_WORK.W_QTD_LD_TIPO_5, LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_5);

            /*" -1362- MOVE W-QTD-LD-TIPO-6 TO RT-QTDE-TIPO-6 */
            _.Move(AREA_DE_WORK.W_QTD_LD_TIPO_6, LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_6);

            /*" -1364- MOVE W-QTD-LD-TIPO-7 TO RT-QTDE-TIPO-7 */
            _.Move(AREA_DE_WORK.W_QTD_LD_TIPO_7, LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_7);

            /*" -1366- MOVE W-QTD-LD-TIPO-8 TO RT-QTDE-TIPO-8 */
            _.Move(AREA_DE_WORK.W_QTD_LD_TIPO_8, LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_8);

            /*" -1368- MOVE W-QTD-LD-TIPO-9 TO RT-QTDE-TIPO-9 */
            _.Move(AREA_DE_WORK.W_QTD_LD_TIPO_9, LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_9);

            /*" -1377- COMPUTE RT-QTDE-TOTAL OF REG-TRAILLER-STA = RT-QTDE-TIPO-1 + RT-QTDE-TIPO-2 + RT-QTDE-TIPO-3 + RT-QTDE-TIPO-4 + RT-QTDE-TIPO-5 + RT-QTDE-TIPO-6 + RT-QTDE-TIPO-7 + RT-QTDE-TIPO-8 + RT-QTDE-TIPO-9. */
            LBFCT011.REG_TRAILLER_STA.RT_QTDE_TOTAL.Value = LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_1 + LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_2 + LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_3 + LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_4 + LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_5 + LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_6 + LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_7 + LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_8 + LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_9;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0800_SAIDA*/

        [StopWatch]
        /*" R0850-00-CONTROLAR-ARQ-ENVIADO-SECTION */
        private void R0850_00_CONTROLAR_ARQ_ENVIADO_SECTION()
        {
            /*" -1389- MOVE '0850' TO WNR-EXEC-SQL. */
            _.Move("0850", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1392- MOVE 'STASCADE' TO ARQSIVPF-SIGLA-ARQUIVO OF DCLARQUIVOS-SIVPF. */
            _.Move("STASCADE", ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SIGLA_ARQUIVO);

            /*" -1395- MOVE 4 TO ARQSIVPF-SISTEMA-ORIGEM OF DCLARQUIVOS-SIVPF. */
            _.Move(4, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SISTEMA_ORIGEM);

            /*" -1399- MOVE SISTEMAS-DATA-MOV-ABERTO OF DCLSISTEMAS TO ARQSIVPF-DATA-PROCESSAMENTO OF DCLARQUIVOS-SIVPF, ARQSIVPF-DATA-GERACAO OF DCLARQUIVOS-SIVPF. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_PROCESSAMENTO, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_GERACAO);

            /*" -1402- MOVE RT-QTDE-TIPO-1 OF REG-TRAILLER-STA TO ARQSIVPF-QTDE-REG-GER OF DCLARQUIVOS-SIVPF. */
            _.Move(LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_1, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_QTDE_REG_GER);

            /*" -1410- PERFORM R0850_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1 */

            R0850_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1();

            /*" -1413- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -1414- DISPLAY 'BI3605B - FIM ANORMAL' */
                _.Display($"BI3605B - FIM ANORMAL");

                /*" -1415- DISPLAY '          ERRO INSERT TABELA ARQUIVOS-SIVPF' */
                _.Display($"          ERRO INSERT TABELA ARQUIVOS-SIVPF");

                /*" -1417- DISPLAY '          SIGLA DO ARQIVO...............  ' ARQSIVPF-SIGLA-ARQUIVO OF DCLARQUIVOS-SIVPF */
                _.Display($"          SIGLA DO ARQIVO...............  {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SIGLA_ARQUIVO}");

                /*" -1419- DISPLAY '          NSAS SIVPF....................  ' ARQSIVPF-NSAS-SIVPF OF DCLARQUIVOS-SIVPF */
                _.Display($"          NSAS SIVPF....................  {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF}");

                /*" -1421- DISPLAY '          DATA GERACAO..................  ' ARQSIVPF-DATA-GERACAO OF DCLARQUIVOS-SIVPF */
                _.Display($"          DATA GERACAO..................  {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_GERACAO}");

                /*" -1423- DISPLAY '          QTDE. REGISTROS...............  ' ARQSIVPF-QTDE-REG-GER OF DCLARQUIVOS-SIVPF */
                _.Display($"          QTDE. REGISTROS...............  {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_QTDE_REG_GER}");

                /*" -1425- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -1425- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0850-00-CONTROLAR-ARQ-ENVIADO-DB-INSERT-1 */
        public void R0850_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1()
        {
            /*" -1410- EXEC SQL INSERT INTO SEGUROS.ARQUIVOS_SIVPF VALUES (:DCLARQUIVOS-SIVPF.ARQSIVPF-SIGLA-ARQUIVO, :DCLARQUIVOS-SIVPF.ARQSIVPF-SISTEMA-ORIGEM, :DCLARQUIVOS-SIVPF.ARQSIVPF-NSAS-SIVPF, :DCLARQUIVOS-SIVPF.ARQSIVPF-DATA-GERACAO, :DCLARQUIVOS-SIVPF.ARQSIVPF-QTDE-REG-GER, :DCLARQUIVOS-SIVPF.ARQSIVPF-DATA-PROCESSAMENTO) END-EXEC. */

            var r0850_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1_Insert1 = new R0850_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1_Insert1()
            {
                ARQSIVPF_SIGLA_ARQUIVO = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SIGLA_ARQUIVO.ToString(),
                ARQSIVPF_SISTEMA_ORIGEM = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SISTEMA_ORIGEM.ToString(),
                ARQSIVPF_NSAS_SIVPF = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF.ToString(),
                ARQSIVPF_DATA_GERACAO = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_GERACAO.ToString(),
                ARQSIVPF_QTDE_REG_GER = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_QTDE_REG_GER.ToString(),
                ARQSIVPF_DATA_PROCESSAMENTO = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_PROCESSAMENTO.ToString(),
            };

            R0850_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1_Insert1.Execute(r0850_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0850_SAIDA*/

        [StopWatch]
        /*" R1000-00-DELETE-BILHETE-SECTION */
        private void R1000_00_DELETE_BILHETE_SECTION()
        {
            /*" -1434- MOVE '1000' TO WNR-EXEC-SQL. */
            _.Move("1000", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1438- PERFORM R1000_00_DELETE_BILHETE_DB_DELETE_1 */

            R1000_00_DELETE_BILHETE_DB_DELETE_1();

            /*" -1441- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1442- DISPLAY 'R1000-00 - PROBLEMAS DELETE (BILHETE)     ' */
                _.Display($"R1000-00 - PROBLEMAS DELETE (BILHETE)     ");

                /*" -1442- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1000-00-DELETE-BILHETE-DB-DELETE-1 */
        public void R1000_00_DELETE_BILHETE_DB_DELETE_1()
        {
            /*" -1438- EXEC SQL DELETE FROM SEGUROS.BILHETE WHERE NUM_BILHETE = :BILHETE-NUM-BILHETE END-EXEC. */

            var r1000_00_DELETE_BILHETE_DB_DELETE_1_Delete1 = new R1000_00_DELETE_BILHETE_DB_DELETE_1_Delete1()
            {
                BILHETE_NUM_BILHETE = BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE.ToString(),
            };

            R1000_00_DELETE_BILHETE_DB_DELETE_1_Delete1.Execute(r1000_00_DELETE_BILHETE_DB_DELETE_1_Delete1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1100-00-INSERT-CONVERSI-SECTION */
        private void R1100_00_INSERT_CONVERSI_SECTION()
        {
            /*" -1452- MOVE '1100' TO WNR-EXEC-SQL. */
            _.Move("1100", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1455- MOVE BILHETE-NUM-BILHETE TO CONVERSI-NUM-PROPOSTA-SIVPF. */
            _.Move(BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE, CONVERSI.DCLCONVERSAO_SICOB.CONVERSI_NUM_PROPOSTA_SIVPF);

            /*" -1457- MOVE WWORK-MIN-NRTIT TO CONVERSI-NUM-SICOB. */
            _.Move(AREA_DE_WORK.WWORK_MIN_NRTIT, CONVERSI.DCLCONVERSAO_SICOB.CONVERSI_NUM_SICOB);

            /*" -1459- MOVE 1 TO CONVERSI-COD-EMPRESA-SIVPF. */
            _.Move(1, CONVERSI.DCLCONVERSAO_SICOB.CONVERSI_COD_EMPRESA_SIVPF);

            /*" -1461- MOVE 8105 TO CONVERSI-COD-PRODUTO-SIVPF. */
            _.Move(8105, CONVERSI.DCLCONVERSAO_SICOB.CONVERSI_COD_PRODUTO_SIVPF);

            /*" -1463- MOVE BILHETE-AGE-COBRANCA TO CONVERSI-AGEPGTO. */
            _.Move(BILHETE.DCLBILHETE.BILHETE_AGE_COBRANCA, CONVERSI.DCLCONVERSAO_SICOB.CONVERSI_AGEPGTO);

            /*" -1465- MOVE BILHETE-DATA-VENDA TO CONVERSI-DATA-OPERACAO. */
            _.Move(BILHETE.DCLBILHETE.BILHETE_DATA_VENDA, CONVERSI.DCLCONVERSAO_SICOB.CONVERSI_DATA_OPERACAO);

            /*" -1467- MOVE BILHETE-DATA-QUITACAO TO CONVERSI-DATA-QUITACAO. */
            _.Move(BILHETE.DCLBILHETE.BILHETE_DATA_QUITACAO, CONVERSI.DCLCONVERSAO_SICOB.CONVERSI_DATA_QUITACAO);

            /*" -1469- MOVE BILHETE-VAL-RCAP TO CONVERSI-VAL-RCAP. */
            _.Move(BILHETE.DCLBILHETE.BILHETE_VAL_RCAP, CONVERSI.DCLCONVERSAO_SICOB.CONVERSI_VAL_RCAP);

            /*" -1472- MOVE BILHETE-COD-USUARIO TO CONVERSI-COD-USUARIO. */
            _.Move(BILHETE.DCLBILHETE.BILHETE_COD_USUARIO, CONVERSI.DCLCONVERSAO_SICOB.CONVERSI_COD_USUARIO);

            /*" -1495- PERFORM R1100_00_INSERT_CONVERSI_DB_INSERT_1 */

            R1100_00_INSERT_CONVERSI_DB_INSERT_1();

            /*" -1498- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1499- IF SQLCODE EQUAL -803 */

                if (DB.SQLCODE == -803)
                {

                    /*" -1500- PERFORM R1150-00-TRATA-DUPLICI-SICOB */

                    R1150_00_TRATA_DUPLICI_SICOB_SECTION();

                    /*" -1501- ELSE */
                }
                else
                {


                    /*" -1504- DISPLAY 'R1100-00 - PROBLEMAS NO INSERT(CONVERSI) ' '   ' CONVERSI-NUM-PROPOSTA-SIVPF '   ' CONVERSI-NUM-SICOB */

                    $"R1100-00 - PROBLEMAS NO INSERT(CONVERSI)    {CONVERSI.DCLCONVERSAO_SICOB.CONVERSI_NUM_PROPOSTA_SIVPF}   {CONVERSI.DCLCONVERSAO_SICOB.CONVERSI_NUM_SICOB}"
                    .Display();

                    /*" -1504- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R1100-00-INSERT-CONVERSI-DB-INSERT-1 */
        public void R1100_00_INSERT_CONVERSI_DB_INSERT_1()
        {
            /*" -1495- EXEC SQL INSERT INTO SEGUROS.CONVERSAO_SICOB (NUM_PROPOSTA_SIVPF , NUM_SICOB , COD_EMPRESA_SIVPF , COD_PRODUTO_SIVPF , AGEPGTO , DATA_OPERACAO , DATA_QUITACAO , VAL_RCAP , COD_USUARIO , TIMESTAMP) VALUES (:CONVERSI-NUM-PROPOSTA-SIVPF , :CONVERSI-NUM-SICOB , :CONVERSI-COD-EMPRESA-SIVPF , :CONVERSI-COD-PRODUTO-SIVPF , :CONVERSI-AGEPGTO , :CONVERSI-DATA-OPERACAO , :CONVERSI-DATA-QUITACAO , :CONVERSI-VAL-RCAP , :CONVERSI-COD-USUARIO , CURRENT TIMESTAMP) END-EXEC. */

            var r1100_00_INSERT_CONVERSI_DB_INSERT_1_Insert1 = new R1100_00_INSERT_CONVERSI_DB_INSERT_1_Insert1()
            {
                CONVERSI_NUM_PROPOSTA_SIVPF = CONVERSI.DCLCONVERSAO_SICOB.CONVERSI_NUM_PROPOSTA_SIVPF.ToString(),
                CONVERSI_NUM_SICOB = CONVERSI.DCLCONVERSAO_SICOB.CONVERSI_NUM_SICOB.ToString(),
                CONVERSI_COD_EMPRESA_SIVPF = CONVERSI.DCLCONVERSAO_SICOB.CONVERSI_COD_EMPRESA_SIVPF.ToString(),
                CONVERSI_COD_PRODUTO_SIVPF = CONVERSI.DCLCONVERSAO_SICOB.CONVERSI_COD_PRODUTO_SIVPF.ToString(),
                CONVERSI_AGEPGTO = CONVERSI.DCLCONVERSAO_SICOB.CONVERSI_AGEPGTO.ToString(),
                CONVERSI_DATA_OPERACAO = CONVERSI.DCLCONVERSAO_SICOB.CONVERSI_DATA_OPERACAO.ToString(),
                CONVERSI_DATA_QUITACAO = CONVERSI.DCLCONVERSAO_SICOB.CONVERSI_DATA_QUITACAO.ToString(),
                CONVERSI_VAL_RCAP = CONVERSI.DCLCONVERSAO_SICOB.CONVERSI_VAL_RCAP.ToString(),
                CONVERSI_COD_USUARIO = CONVERSI.DCLCONVERSAO_SICOB.CONVERSI_COD_USUARIO.ToString(),
            };

            R1100_00_INSERT_CONVERSI_DB_INSERT_1_Insert1.Execute(r1100_00_INSERT_CONVERSI_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/

        [StopWatch]
        /*" R1150-00-TRATA-DUPLICI-SICOB-SECTION */
        private void R1150_00_TRATA_DUPLICI_SICOB_SECTION()
        {
            /*" -1514- MOVE '1150' TO WNR-EXEC-SQL. */
            _.Move("1150", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1515- PERFORM R0530-00-CALCULA-TITULO */

            R0530_00_CALCULA_TITULO_SECTION();

            /*" -1516- PERFORM R0550-00-UPDATE-V0CEDENTE */

            R0550_00_UPDATE_V0CEDENTE_SECTION();

            /*" -1517- PERFORM R1100-00-INSERT-CONVERSI. */

            R1100_00_INSERT_CONVERSI_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1150_99_SAIDA*/

        [StopWatch]
        /*" R1200-00-INSERT-BILHETE-SECTION */
        private void R1200_00_INSERT_BILHETE_SECTION()
        {
            /*" -1526- MOVE '1200' TO WNR-EXEC-SQL. */
            _.Move("1200", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1529- MOVE WWORK-MIN-NRTIT TO BILHETE-NUM-BILHETE. */
            _.Move(AREA_DE_WORK.WWORK_MIN_NRTIT, BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE);

            /*" -1598- PERFORM R1200_00_INSERT_BILHETE_DB_INSERT_1 */

            R1200_00_INSERT_BILHETE_DB_INSERT_1();

            /*" -1601- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1603- DISPLAY 'R1200-00 - PROBLEMAS NO INSERT(BILHETE)   ' '   ' BILHETE-NUM-BILHETE */

                $"R1200-00 - PROBLEMAS NO INSERT(BILHETE)      {BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE}"
                .Display();

                /*" -1605- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1605- ADD 1 TO AC-BILHETE. */
            AREA_DE_WORK.AC_BILHETE.Value = AREA_DE_WORK.AC_BILHETE + 1;

        }

        [StopWatch]
        /*" R1200-00-INSERT-BILHETE-DB-INSERT-1 */
        public void R1200_00_INSERT_BILHETE_DB_INSERT_1()
        {
            /*" -1598- EXEC SQL INSERT INTO SEGUROS.BILHETE (NUM_BILHETE , NUM_APOLICE , FONTE , AGE_COBRANCA , NUM_MATRICULA , COD_AGENCIA , OPERACAO_CONTA , NUM_CONTA , DIG_CONTA , COD_CLIENTE , PROFISSAO , IDE_SEXO , ESTADO_CIVIL , OCORR_ENDERECO , COD_AGENCIA_DEB , OPERACAO_CONTA_DEB , NUM_CONTA_DEB , DIG_CONTA_DEB , OPC_COBERTURA , DATA_QUITACAO , VAL_RCAP , RAMO , DATA_VENDA , DATA_MOVIMENTO , NUM_APOL_ANTERIOR , SITUACAO , TIP_CANCELAMENTO , SIT_SINISTRO , COD_USUARIO , TIMESTAMP , DATA_CANCELAMENTO , BI_FAIXA_RENDA_IND , BI_FAIXA_RENDA_FAM) VALUES (:BILHETE-NUM-BILHETE , :BILHETE-NUM-APOLICE , :BILHETE-FONTE , :BILHETE-AGE-COBRANCA , :BILHETE-NUM-MATRICULA , :BILHETE-COD-AGENCIA , :BILHETE-OPERACAO-CONTA , :BILHETE-NUM-CONTA , :BILHETE-DIG-CONTA , :BILHETE-COD-CLIENTE , :BILHETE-PROFISSAO , :BILHETE-IDE-SEXO , :BILHETE-ESTADO-CIVIL , :BILHETE-OCORR-ENDERECO , :BILHETE-COD-AGENCIA-DEB , :BILHETE-OPERACAO-CONTA-DEB , :BILHETE-NUM-CONTA-DEB , :BILHETE-DIG-CONTA-DEB , :BILHETE-OPC-COBERTURA , :BILHETE-DATA-QUITACAO , :BILHETE-VAL-RCAP , :BILHETE-RAMO , :BILHETE-DATA-VENDA , :BILHETE-DATA-MOVIMENTO , :BILHETE-NUM-APOL-ANTERIOR , :BILHETE-SITUACAO , :BILHETE-TIP-CANCELAMENTO , :BILHETE-SIT-SINISTRO , :BILHETE-COD-USUARIO , :BILHETE-TIMESTAMP , :BILHETE-DATA-CANCELAMENTO:VIND-NULL01 , :BILHETE-BI-FAIXA-RENDA-IND , :BILHETE-BI-FAIXA-RENDA-FAM) END-EXEC. */

            var r1200_00_INSERT_BILHETE_DB_INSERT_1_Insert1 = new R1200_00_INSERT_BILHETE_DB_INSERT_1_Insert1()
            {
                BILHETE_NUM_BILHETE = BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE.ToString(),
                BILHETE_NUM_APOLICE = BILHETE.DCLBILHETE.BILHETE_NUM_APOLICE.ToString(),
                BILHETE_FONTE = BILHETE.DCLBILHETE.BILHETE_FONTE.ToString(),
                BILHETE_AGE_COBRANCA = BILHETE.DCLBILHETE.BILHETE_AGE_COBRANCA.ToString(),
                BILHETE_NUM_MATRICULA = BILHETE.DCLBILHETE.BILHETE_NUM_MATRICULA.ToString(),
                BILHETE_COD_AGENCIA = BILHETE.DCLBILHETE.BILHETE_COD_AGENCIA.ToString(),
                BILHETE_OPERACAO_CONTA = BILHETE.DCLBILHETE.BILHETE_OPERACAO_CONTA.ToString(),
                BILHETE_NUM_CONTA = BILHETE.DCLBILHETE.BILHETE_NUM_CONTA.ToString(),
                BILHETE_DIG_CONTA = BILHETE.DCLBILHETE.BILHETE_DIG_CONTA.ToString(),
                BILHETE_COD_CLIENTE = BILHETE.DCLBILHETE.BILHETE_COD_CLIENTE.ToString(),
                BILHETE_PROFISSAO = BILHETE.DCLBILHETE.BILHETE_PROFISSAO.ToString(),
                BILHETE_IDE_SEXO = BILHETE.DCLBILHETE.BILHETE_IDE_SEXO.ToString(),
                BILHETE_ESTADO_CIVIL = BILHETE.DCLBILHETE.BILHETE_ESTADO_CIVIL.ToString(),
                BILHETE_OCORR_ENDERECO = BILHETE.DCLBILHETE.BILHETE_OCORR_ENDERECO.ToString(),
                BILHETE_COD_AGENCIA_DEB = BILHETE.DCLBILHETE.BILHETE_COD_AGENCIA_DEB.ToString(),
                BILHETE_OPERACAO_CONTA_DEB = BILHETE.DCLBILHETE.BILHETE_OPERACAO_CONTA_DEB.ToString(),
                BILHETE_NUM_CONTA_DEB = BILHETE.DCLBILHETE.BILHETE_NUM_CONTA_DEB.ToString(),
                BILHETE_DIG_CONTA_DEB = BILHETE.DCLBILHETE.BILHETE_DIG_CONTA_DEB.ToString(),
                BILHETE_OPC_COBERTURA = BILHETE.DCLBILHETE.BILHETE_OPC_COBERTURA.ToString(),
                BILHETE_DATA_QUITACAO = BILHETE.DCLBILHETE.BILHETE_DATA_QUITACAO.ToString(),
                BILHETE_VAL_RCAP = BILHETE.DCLBILHETE.BILHETE_VAL_RCAP.ToString(),
                BILHETE_RAMO = BILHETE.DCLBILHETE.BILHETE_RAMO.ToString(),
                BILHETE_DATA_VENDA = BILHETE.DCLBILHETE.BILHETE_DATA_VENDA.ToString(),
                BILHETE_DATA_MOVIMENTO = BILHETE.DCLBILHETE.BILHETE_DATA_MOVIMENTO.ToString(),
                BILHETE_NUM_APOL_ANTERIOR = BILHETE.DCLBILHETE.BILHETE_NUM_APOL_ANTERIOR.ToString(),
                BILHETE_SITUACAO = BILHETE.DCLBILHETE.BILHETE_SITUACAO.ToString(),
                BILHETE_TIP_CANCELAMENTO = BILHETE.DCLBILHETE.BILHETE_TIP_CANCELAMENTO.ToString(),
                BILHETE_SIT_SINISTRO = BILHETE.DCLBILHETE.BILHETE_SIT_SINISTRO.ToString(),
                BILHETE_COD_USUARIO = BILHETE.DCLBILHETE.BILHETE_COD_USUARIO.ToString(),
                BILHETE_TIMESTAMP = BILHETE.DCLBILHETE.BILHETE_TIMESTAMP.ToString(),
                BILHETE_DATA_CANCELAMENTO = BILHETE.DCLBILHETE.BILHETE_DATA_CANCELAMENTO.ToString(),
                VIND_NULL01 = VIND_NULL01.ToString(),
                BILHETE_BI_FAIXA_RENDA_IND = BILHETE.DCLBILHETE.BILHETE_BI_FAIXA_RENDA_IND.ToString(),
                BILHETE_BI_FAIXA_RENDA_FAM = BILHETE.DCLBILHETE.BILHETE_BI_FAIXA_RENDA_FAM.ToString(),
            };

            R1200_00_INSERT_BILHETE_DB_INSERT_1_Insert1.Execute(r1200_00_INSERT_BILHETE_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/

        [StopWatch]
        /*" R3900-00-SELECT-MOVIMCOB-SECTION */
        private void R3900_00_SELECT_MOVIMCOB_SECTION()
        {
            /*" -1616- MOVE '3900' TO WNR-EXEC-SQL. */
            _.Move("3900", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1623- PERFORM R3900_00_SELECT_MOVIMCOB_DB_SELECT_1 */

            R3900_00_SELECT_MOVIMCOB_DB_SELECT_1();

            /*" -1626- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1628- MOVE 'C' TO MOVIMCOB-SIT-REGISTRO */
                _.Move("C", MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_SIT_REGISTRO);

                /*" -1629- PERFORM R4000-00-INSERT-MOVIMCOB */

                R4000_00_INSERT_MOVIMCOB_SECTION();

                /*" -1630- ELSE */
            }
            else
            {


                /*" -1632- IF SQLCODE NOT EQUAL ZEROS AND SQLCODE NOT EQUAL -803 */

                if (DB.SQLCODE != 00 && DB.SQLCODE != -803)
                {

                    /*" -1634- DISPLAY 'R3900-00 - PROBLEMAS NO SELECT(MOVIMCOB)  ' ' PROPOSTA   ' MOVIMCOB-NUM-NOSSO-TITULO */

                    $"R3900-00 - PROBLEMAS NO SELECT(MOVIMCOB)   PROPOSTA   {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_NOSSO_TITULO}"
                    .Display();

                    /*" -1634- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R3900-00-SELECT-MOVIMCOB-DB-SELECT-1 */
        public void R3900_00_SELECT_MOVIMCOB_DB_SELECT_1()
        {
            /*" -1623- EXEC SQL SELECT SIT_REGISTRO INTO :MOVIMCOB-SIT-REGISTRO FROM SEGUROS.MOVIMENTO_COBRANCA WHERE NUM_NOSSO_TITULO = :MOVIMCOB-NUM-NOSSO-TITULO WITH UR END-EXEC. */

            var r3900_00_SELECT_MOVIMCOB_DB_SELECT_1_Query1 = new R3900_00_SELECT_MOVIMCOB_DB_SELECT_1_Query1()
            {
                MOVIMCOB_NUM_NOSSO_TITULO = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_NOSSO_TITULO.ToString(),
            };

            var executed_1 = R3900_00_SELECT_MOVIMCOB_DB_SELECT_1_Query1.Execute(r3900_00_SELECT_MOVIMCOB_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.MOVIMCOB_SIT_REGISTRO, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_SIT_REGISTRO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3900_99_SAIDA*/

        [StopWatch]
        /*" R4000-00-INSERT-MOVIMCOB-SECTION */
        private void R4000_00_INSERT_MOVIMCOB_SECTION()
        {
            /*" -1647- MOVE '4000' TO WNR-EXEC-SQL. */
            _.Move("4000", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1690- PERFORM R4000_00_INSERT_MOVIMCOB_DB_INSERT_1 */

            R4000_00_INSERT_MOVIMCOB_DB_INSERT_1();

            /*" -1693- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1698- DISPLAY 'R4000-00 - PROBLEMAS NO INSERT(CBCONDEV)   ' '   ' MOVCC-REGISTRO '   ' MOVIMCOB-NUM-AVISO '   ' MOVIMCOB-NUM-TITULO '   ' MOVIMCOB-NUM-NOSSO-TITULO */

                $"R4000-00 - PROBLEMAS NO INSERT(CBCONDEV)      {MOVCC_REGISTRO}   {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_AVISO}   {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_TITULO}   {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_NOSSO_TITULO}"
                .Display();

                /*" -1700- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1700- ADD 1 TO AC-MOVIMCOB. */
            AREA_DE_WORK.AC_MOVIMCOB.Value = AREA_DE_WORK.AC_MOVIMCOB + 1;

        }

        [StopWatch]
        /*" R4000-00-INSERT-MOVIMCOB-DB-INSERT-1 */
        public void R4000_00_INSERT_MOVIMCOB_DB_INSERT_1()
        {
            /*" -1690- EXEC SQL INSERT INTO SEGUROS.MOVIMENTO_COBRANCA (COD_EMPRESA , COD_MOVIMENTO , COD_BANCO , COD_AGENCIA , NUM_AVISO , NUM_FITA , DATA_MOVIMENTO , DATA_QUITACAO , NUM_TITULO , NUM_APOLICE , NUM_ENDOSSO , NUM_PARCELA , VAL_TITULO , VAL_IOCC , VAL_CREDITO , SIT_REGISTRO , TIMESTAMP , NOME_SEGURADO , TIPO_MOVIMENTO , NUM_NOSSO_TITULO) VALUES (:MOVIMCOB-COD-EMPRESA , :MOVIMCOB-COD-MOVIMENTO , :MOVIMCOB-COD-BANCO , :MOVIMCOB-COD-AGENCIA , :MOVIMCOB-NUM-AVISO , :MOVIMCOB-NUM-FITA , :MOVIMCOB-DATA-MOVIMENTO , :MOVIMCOB-DATA-QUITACAO , :MOVIMCOB-NUM-TITULO , :MOVIMCOB-NUM-APOLICE , :MOVIMCOB-NUM-ENDOSSO , :MOVIMCOB-NUM-PARCELA , :MOVIMCOB-VAL-TITULO , :MOVIMCOB-VAL-IOCC , :MOVIMCOB-VAL-CREDITO , :MOVIMCOB-SIT-REGISTRO , CURRENT TIMESTAMP , :MOVIMCOB-NOME-SEGURADO , :MOVIMCOB-TIPO-MOVIMENTO , :MOVIMCOB-NUM-NOSSO-TITULO) END-EXEC. */

            var r4000_00_INSERT_MOVIMCOB_DB_INSERT_1_Insert1 = new R4000_00_INSERT_MOVIMCOB_DB_INSERT_1_Insert1()
            {
                MOVIMCOB_COD_EMPRESA = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_EMPRESA.ToString(),
                MOVIMCOB_COD_MOVIMENTO = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_MOVIMENTO.ToString(),
                MOVIMCOB_COD_BANCO = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_BANCO.ToString(),
                MOVIMCOB_COD_AGENCIA = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_AGENCIA.ToString(),
                MOVIMCOB_NUM_AVISO = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_AVISO.ToString(),
                MOVIMCOB_NUM_FITA = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_FITA.ToString(),
                MOVIMCOB_DATA_MOVIMENTO = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_DATA_MOVIMENTO.ToString(),
                MOVIMCOB_DATA_QUITACAO = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_DATA_QUITACAO.ToString(),
                MOVIMCOB_NUM_TITULO = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_TITULO.ToString(),
                MOVIMCOB_NUM_APOLICE = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_APOLICE.ToString(),
                MOVIMCOB_NUM_ENDOSSO = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_ENDOSSO.ToString(),
                MOVIMCOB_NUM_PARCELA = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_PARCELA.ToString(),
                MOVIMCOB_VAL_TITULO = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_VAL_TITULO.ToString(),
                MOVIMCOB_VAL_IOCC = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_VAL_IOCC.ToString(),
                MOVIMCOB_VAL_CREDITO = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_VAL_CREDITO.ToString(),
                MOVIMCOB_SIT_REGISTRO = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_SIT_REGISTRO.ToString(),
                MOVIMCOB_NOME_SEGURADO = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NOME_SEGURADO.ToString(),
                MOVIMCOB_TIPO_MOVIMENTO = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_TIPO_MOVIMENTO.ToString(),
                MOVIMCOB_NUM_NOSSO_TITULO = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_NOSSO_TITULO.ToString(),
            };

            R4000_00_INSERT_MOVIMCOB_DB_INSERT_1_Insert1.Execute(r4000_00_INSERT_MOVIMCOB_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4000_99_SAIDA*/

        [StopWatch]
        /*" R9800-00-ENCERRA-SEM-MOVTO-SECTION */
        private void R9800_00_ENCERRA_SEM_MOVTO_SECTION()
        {
            /*" -1711- MOVE '9800' TO WNR-EXEC-SQL. */
            _.Move("9800", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1712- MOVE SISTEMAS-DATA-MOV-ABERTO TO WDATA-REL. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, AREA_DE_WORK.WDATA_REL);

            /*" -1713- MOVE WDAT-REL-DIA TO WDAT-LIT-DIA. */
            _.Move(AREA_DE_WORK.FILLER_8.WDAT_REL_DIA, AREA_DE_WORK.FILLER_7.WDAT_LIT_DIA);

            /*" -1714- MOVE WDAT-REL-MES TO WDAT-LIT-MES. */
            _.Move(AREA_DE_WORK.FILLER_8.WDAT_REL_MES, AREA_DE_WORK.FILLER_7.WDAT_LIT_MES);

            /*" -1715- MOVE WDAT-REL-ANO TO WDAT-LIT-ANO. */
            _.Move(AREA_DE_WORK.FILLER_8.WDAT_REL_ANO, AREA_DE_WORK.FILLER_7.WDAT_LIT_ANO);

            /*" -1716- MOVE '/' TO W-BARRA3. */
            _.Move("/", AREA_DE_WORK.FILLER_7.W_BARRA3);

            /*" -1718- MOVE '/' TO W-BARRA4. */
            _.Move("/", AREA_DE_WORK.FILLER_7.W_BARRA4);

            /*" -1719- DISPLAY '*---------------------------------------------*' */
            _.Display($"*---------------------------------------------*");

            /*" -1720- DISPLAY '*                                             *' */
            _.Display($"*                                             *");

            /*" -1721- DISPLAY '*  BI0073B - PROCESSA FITA RETORNO - COBRANCA *' */
            _.Display($"*  BI0073B - PROCESSA FITA RETORNO - COBRANCA *");

            /*" -1722- DISPLAY '*  -------   -------- ---- ------- ----- ---- *' */
            _.Display($"*  -------   -------- ---- ------- ----- ---- *");

            /*" -1723- DISPLAY '*                                             *' */
            _.Display($"*                                             *");

            /*" -1724- DISPLAY '*   NAO HOUVE MOVIMENTACAO NESTA DATA         *' */
            _.Display($"*   NAO HOUVE MOVIMENTACAO NESTA DATA         *");

            /*" -1725- DISPLAY '*               ' WDAT-REL-LIT '                *' */

            $"*               {AREA_DE_WORK.WDAT_REL_LIT}                *"
            .Display();

            /*" -1726- DISPLAY '*                                             *' */
            _.Display($"*                                             *");

            /*" -1727- DISPLAY '*---------------------------------------------*' . */
            _.Display($"*---------------------------------------------*");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9800_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -1736- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, AREA_DE_WORK.WABEND.WSQLCODE);

            /*" -1737- MOVE SQLERRD(1) TO WSQLERRD1. */
            _.Move(DB.SQLERRD[1], AREA_DE_WORK.WABEND.WSQLERRD1);

            /*" -1738- MOVE SQLERRD(2) TO WSQLERRD2. */
            _.Move(DB.SQLERRD[2], AREA_DE_WORK.WABEND.WSQLERRD2);

            /*" -1740- MOVE SQLERRMC TO WSQLERRMC. */
            _.Move(DB.SQLERRMC, AREA_DE_WORK.WSQLERR.WSQLERRMC);

            /*" -1741- DISPLAY WABEND. */
            _.Display(AREA_DE_WORK.WABEND);

            /*" -1743- DISPLAY WSQLERR. */
            _.Display(AREA_DE_WORK.WSQLERR);

            /*" -1743- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -1747- CLOSE MOVIMENTO. */
            MOVIMENTO.Close();

            /*" -1749- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -1749- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}